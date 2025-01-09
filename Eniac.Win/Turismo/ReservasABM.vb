Public Class ReservasABM

   Private Const usuarioTodos As String = "(TODOS)"
   Private Const estadoTodos As String = "Todos"
   Private Const estadoActivos As String = "Activos"
   Private Const estadoFinalizados As String = "Finalizados"

   Private cargando As Boolean = False
   '   Private _PermiteAbrirMultiplesNovedadesNuevas As Boolean = False
   ' Private _muestraSolapaMasInfo As Boolean = False
   '  Private Property Modo As Eniac.Entidades.Cliente.ModoClienteProspecto?
   Private _publicos As Publicos

   Private _tienePermisoParaVerOtrosUsuarios As Boolean = True
   Private _tienePermisoParaEliminarRegistros As Boolean = True

   Private _usr As Entidades.Usuario


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Try
         'If TipoNovedad IsNot Nothing Then
         '   Text = TipoNovedad.NombreTipoNovedad
         '   dgvDatos.FindForm().Name = dgvDatos.FindForm().Name + "_" + TipoNovedad.IdTipoNovedad
         ' End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      Try

         Me._publicos = New Publicos()

         cargando = True

         Me.dtpFechaDesde.Value = DateTime.Today
         Me.dtpFechaHasta.Value = DateTime.Today.UltimoSegundoDelDia()

         'If TipoNovedad IsNot Nothing Then
         '   _tienePermisoParaVerOtrosUsuarios = New Eniac.Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, TipoNovedad.IdTipoNovedad + "-VerOtrosUsuarios")
         '   _tienePermisoParaEliminarRegistros = New Eniac.Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, TipoNovedad.IdTipoNovedad + "-PuedeEliminar")
         'End If

         tsbBorrar.Visible = _tienePermisoParaEliminarRegistros

         If Reglas.Publicos.CRMSoloMuestraUsuariosActivos Then
            Me._publicos.CargaComboUsuariosActivos(Me.cmbUsuarioAsignado)
         Else
            Me._publicos.CargaComboUsuarios(Me.cmbUsuarioAsignado)
         End If

         _usr = New Reglas.Usuarios().GetUno(actual.Nombre)

         chbUsuarioAsignado.Checked = False
         cmbUsuarioAsignado.SelectedValue = _usr.Id

         _publicos.CargaComboDesdeEnum(cmbFinalizado, GetType(Entidades.Publicos.SiNoTodos))
         cmbFinalizado.SelectedValue = Entidades.Publicos.SiNoTodos.NO

         'If Not _tienePermisoParaVerOtrosUsuarios Then
         '   chbUsuarioAsignado.Enabled = False
         '   cmbUsuarioAsignado.Enabled = False
         'End If

         _publicos.CargaComboEstadosTurismo(cmbEstadoNovedad)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         cargando = False
      End Try

      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ReservasDetalle(DirectCast(Me.GetEntidad(), Entidades.ReservaTurismo))
      End If
      Return New ReservasDetalle(New Eniac.Entidades.ReservaTurismo())
   End Function

   Protected Overrides Sub AbrirFormularioNuevo(detalle As BaseDetalle)
      'If _PermiteAbrirMultiplesNovedadesNuevas Then
      '   '>1 permitida
      '   detalle.MdiParent = MdiParent
      '   detalle.Show()
      'Else
      '1 permitida
      detalle.ShowDialog()
      '  End If
   End Sub

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return GetGrillaDetalle(buscarABM:=Nothing)
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return GetGrillaDetalle(bus)
   End Function

   Protected Overrides Sub LimpiarFiltros()
      MyBase.LimpiarFiltros()
      Try
         cargando = True
         Me.RefrescarDatosGrilla()
      Finally
         cargando = False
      End Try
   End Sub

   'Private Function GetUsuarioAsignado() As String
   '   If tsCmbUsuarioAsignado.SelectedItem IsNot Nothing AndAlso tsCmbUsuarioAsignado.SelectedItem.ToString() <> usuarioTodos Then
   '      Return tsCmbUsuarioAsignado.SelectedItem.ToString()
   '   End If
   '   Return String.Empty
   'End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ReservasTurismo()
   End Function

   Protected Function GetReglasTipado() As Eniac.Reglas.ReservasTurismo
      Return DirectCast(GetReglas(), Eniac.Reglas.ReservasTurismo)
   End Function

   Protected Overrides Sub Borrar()
      Try

         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If

         If Me.dgvDatos.ActiveCell IsNot Nothing Then
            If Me.dgvDatos.ActiveCell.Row.Index <> -1 Then
               Dim cl As Reglas.Base = GetReglas()
               Me._entidad = Me.GetEntidad()
               Dim _entro As Boolean = False
               For Each Pasajero As Entidades.ReservaTurismoPasajero In DirectCast(_entidad, Entidades.ReservaTurismo).Pasajeros
                  If Pasajero.IdTipoComprobante <> "" Then
                     _entro = True
                     MessageBox.Show("No se puede eliminar la Reserva, hay pasajeros con comprobantes emitidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                     Exit Sub
                  End If
               Next

               '  If Me.dgvDatos.ActiveCell IsNot Nothing Then
               If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  cl.Borrar(Me._entidad)
                  Me.RefreshGrid()
               End If
               'End If
            End If
         End If

      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.ReservasTurismo().GetUno(Integer.Parse(.Cells(Entidades.ReservaTurismo.Columnas.IdSucursal.ToString()).Value.ToString()),
                                             .Cells(Entidades.ReservaTurismo.Columnas.IdTipoReserva.ToString()).Value.ToString(),
                                         .Cells(Entidades.ReservaTurismo.Columnas.Letra.ToString()).Value.ToString(),
                                         Short.Parse(.Cells(Entidades.ReservaTurismo.Columnas.CentroEmisor.ToString()).Value.ToString()),
                                         Long.Parse(.Cells(Entidades.ReservaTurismo.Columnas.NumeroReserva.ToString()).Value.ToString()), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()

      dgvDatos.DisplayLayout.UseFixedHeaders = True
      dgvDatos.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None

      With Me.dgvDatos.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next

         If Not .Columns.Exists(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1") Then
            .Columns.Add(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1", String.Empty)
         End If

         If Not .Columns.Exists("Ver") Then
            .Columns.Add("Ver", String.Empty)
         End If

         Dim pos As Integer = 0

         FormatearColumna(.Columns("Ver"), "Ver", pos, 30)
         .Columns("Ver").Style = UltraWinGrid.ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always


         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1"), "", pos, 60)
         .Columns(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1").Header.Fixed = True
         .Columns(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1").CellActivation = Activation.NoEdit

         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString()), "", 1000, 30, , True)



         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.NombreTipoReserva.ToString()), "Tipo", pos, 80)
         'FormatearColumna(.Columns(Entidades.Reserva.Columnas.Letra.ToString()), "L.", pos, 25, HAlign.Center)
         'FormatearColumna(.Columns(Entidades.Reserva.Columnas.CentroEmisor.ToString()), "Emisor", pos, 45, HAlign.Right, True)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.NumeroReserva.ToString()), "Número", pos, 60, HAlign.Right)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Fecha.ToString()), "Fecha / Hora", pos, 120, HAlign.Center, hidden:=True)
         .Columns(Entidades.ReservaTurismo.Columnas.Fecha.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Fecha.ToString() + "_Fecha"), "Fecha", pos, 80, HAlign.Center)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Fecha.ToString() + "_Hora"), "Hora", pos, 40, HAlign.Center)



         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.IdUsuarioAlta.ToString()), "Usuario Alta", pos, 70)

         FormatearColumna(.Columns(Entidades.EstadoTurismo.Columnas.NombreEstadoTurismo.ToString()), "Estado", 2, 90)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.IdUsuarioEstadoTurismo.ToString()), "Usuario Estado", pos, 70)

         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.FechaEstadoTurismo.ToString()), "Fecha/Hora Estado", pos, 80, HAlign.Center, hidden:=True)
         .Columns(Entidades.ReservaTurismo.Columnas.FechaEstadoTurismo.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.FechaEstadoTurismo.ToString() + "_Fecha"), "Fecha Estado", pos, 80, HAlign.Center)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.FechaEstadoTurismo.ToString() + "_Hora"), "Hora Estado", pos, 40, HAlign.Center)

         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.NombreEstablecimiento.ToString()), "Nombre Establecimiento", pos, 180)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.NombrePrograma.ToString()), "Programa", pos, 180)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Costo.ToString()), "Costo", pos, 80, HAlign.Right)
         'FormatearColumna(.Columns("NombreCategoriaCliente"), "Categoria Cliente", pos, 120)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.NombreContacto.ToString()), "Nombre Responsable", pos, 180)

         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.NombreCurso.ToString()), "Año", pos, 80)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Division.ToString()), "Division", pos, 80)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.NombreTurno.ToString()), "Turno", pos, 80)

         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Mes.ToString()), "Mes", pos, 80)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.QuincenaSemana.ToString()), "Quincena o Semana", pos, 80)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Dia.ToString()), "Dia", pos, 80)

         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.NombreTipoVehiculo.ToString()), "Tipo Vehiculo", pos, 100)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.CapacidadMax.ToString()), "Capacidad Maxima", pos, 80, HAlign.Right)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.LugarSalida.ToString()), "Lugar Salida", pos, 100)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.CantidadAlumnos.ToString()), "Cantidad alumnos", pos, 80, HAlign.Right)

         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.BaseAlumnos.ToString()), "Base alumnos", pos, 80, HAlign.Right)
         FormatearColumna(.Columns(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString()), "Forma de Pago", pos, 100)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Liberados.ToString()), "Liberados", pos, 100)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.Seguimiento.ToString()), "Seguimiento", pos, 80)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.CDDigital.ToString()), "CD Digital", pos, 80)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.ObservacionesVendedor.ToString()), "Observaciones Vendedor", pos, 250)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.ObservacionesInternas.ToString()), "Observaciones Internas", pos, 250)
         FormatearColumna(.Columns(Entidades.ReservaTurismo.Columnas.ErroresSincronizacion.ToString()), "Errores de Sincronizacion", pos, 250)

         FormatearColumna(.Columns(Entidades.TurismoTipoViaje.Columnas.DescripcionTipoViaje.ToString()), "Tipo de Viaje", pos, 120)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.ReservaTurismo.Columnas.NombreTipoReserva.ToString(),
                                     Entidades.ReservaTurismo.Columnas.NombreEstablecimiento.ToString(),
                                     Entidades.ReservaTurismo.Columnas.NombrePrograma.ToString(),
                                     Entidades.ReservaTurismo.Columnas.ObservacionesVendedor.ToString(),
                                     Entidades.ReservaTurismo.Columnas.ObservacionesInternas.ToString()})

      Me.CargarColumnasASumar()


   End Sub

   Protected Sub FormatearColumna(col As UltraGridColumn, caption As String, ByRef posicion As Integer, ancho As Integer,
                                  Optional alineacion As HAlign = HAlign.Default, Optional hidden As Boolean = False)
      col.Hidden = hidden
      col.Header.Caption = caption
      col.Header.VisiblePosition = posicion
      col.Width = ancho
      col.CellAppearance.TextHAlign = alineacion
      posicion += 1
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         If e.Row IsNot Nothing And e.Row.Cells.Exists(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1") Then
            Dim color As Color = SystemColors.Control

            If Not String.IsNullOrWhiteSpace(e.Row.Cells(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString()).Value.ToString()) Then
               color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString()).Value.ToString()))
               e.Row.Cells(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1").Appearance.BackColor = color
               e.Row.Cells(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1").Appearance.ForeColor = color
               e.Row.Cells(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1").ActiveAppearance.BackColor = color
               e.Row.Cells(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1").ActiveAppearance.ForeColor = color

               Dim nombreColor As String = Entidades.ReservaTurismo.NombreBanderaColor(color)
               e.Row.Cells(Entidades.ReservaTurismo.Columnas.BanderaColor.ToString() + "1").Value = nombreColor
            End If

            If IsNumeric(e.Row.Cells("ColorEstado").Value) Then
               color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells("ColorEstado").Value.ToString()))
               e.Row.Cells(Entidades.EstadoTurismo.Columnas.NombreEstadoTurismo.ToString()).Appearance.BackColor = color
               e.Row.Cells(Entidades.EstadoTurismo.Columnas.NombreEstadoTurismo.ToString()).ActiveAppearance.BackColor = color
               e.Row.Cells(Entidades.EstadoTurismo.Columnas.NombreEstadoTurismo.ToString()).ActiveAppearance.ForeColor = Drawing.Color.Black
            End If

            'If IsNumeric(e.Row.Cells("ColorCategoria").Value) Then
            '   color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells("ColorCategoria").Value.ToString()))
            '   e.Row.Cells(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).Appearance.BackColor = color
            '   e.Row.Cells(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).ActiveAppearance.BackColor = color

            'End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvDatos_ClickCellButton(sender As Object, e As CellEventArgs) Handles dgvDatos.ClickCellButton
      'If e.Cell.Row.Index <> -1 And e.Cell.Column.Header.Caption = "Ver" Then
      '   Try
      '      With Me.dgvDatos.ActiveRow

      '         Dim novedadImprimir As Entidades.Reserva = GetReglasTipado().GetUno(.Cells(Entidades.Reserva.Columnas.IdTipoNovedad.ToString()).Value.ToString(),
      '                                              .Cells(Entidades.Reserva.Columnas.Letra.ToString()).Value.ToString(),
      '                                              Short.Parse(.Cells(Entidades.Reserva.Columnas.CentroEmisor.ToString()).Value.ToString()),
      '                                              Long.Parse(.Cells(Entidades.Reserva.Columnas.IdNovedad.ToString()).Value.ToString()))



      '         If novedadImprimir.EstadoNovedad.Imprime Then
      '            Cursor = Cursors.WaitCursor

      '            Dim oNovImp As ReservaesImpresion = New ReservaesImpresion(novedadImprimir)

      '            oNovImp.ImprimirNovedad()
      '         Else
      '            MessageBox.Show("El Estado no tiene impresión.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '         End If
      '      End With
      '   Catch ex As Exception
      '      MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Finally
      '      Cursor = Cursors.Default
      '   End Try
      'End If
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick

      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)

         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then

            Me.CargarDatosCliente(e.FilaDevuelta)

            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then

            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbUsuarioAsignado_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuarioAsignado.CheckedChanged
      Try
         Me.cmbUsuarioAsignado.Enabled = Me.chbUsuarioAsignado.Checked
         If Not Me.chbUsuarioAsignado.Checked Then
            Me.cmbUsuarioAsignado.SelectedIndex = -1
         Else
            If Me.cmbUsuarioAsignado.Items.Count > 0 Then
               Me.cmbUsuarioAsignado.SelectedIndex = 0
            End If
         End If
         Me.cmbUsuarioAsignado.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      Try
         Me.cmbEstadoNovedad.Enabled = Me.chbEstado.Checked
         If Not Me.chbEstado.Checked Then
            Me.cmbEstadoNovedad.SelectedIndex = -1
         Else
            If Me.cmbEstadoNovedad.Items.Count > 0 Then
               Me.cmbEstadoNovedad.SelectedIndex = 0
            End If
            Me.cmbEstadoNovedad.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpFechaDesde.Value.Year, Me.dtpFechaDesde.Value.Month, 1)
            Me.dtpFechaDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpFechaDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpFechaHasta.Value = FechaTemp

         End If

         Me.dtpFechaDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpFechaHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked


      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then

            MessageBox.Show(String.Format("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information))
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If
         If Me.chbNumero.Checked And Me.txtNumero.Text = "0" Then
            MessageBox.Show("ATENCION: No ingreso un número de Novedad aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle(GetBuscar())

         '  dgvDatos.AgregarTotalesSuma({Entidades.Reserva.Columnas.Cantidad.ToString()})

         If dgvDatos.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged

      chkMesCompleto.Enabled = chbFecha.Checked
      dtpFechaDesde.Enabled = chbFecha.Checked
      dtpFechaHasta.Enabled = chbFecha.Checked
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      Try

         Me.txtNumero.Enabled = Me.chbNumero.Checked
         If Not Me.chbNumero.Checked Then
            Me.txtNumero.Text = ""
         Else
            Me.txtNumero.Text = "0"
            Me.txtNumero.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
      If e.KeyCode = Keys.Enter Then
         If Not String.IsNullOrWhiteSpace(Me.txtNumero.Text) Then
            Me.btnConsultar.PerformClick()
         End If
      End If
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarColumnasASumar()

      'If Not Me.dgvDatos.DisplayLayout.Bands(0).Summaries.Exists("Costo") Then

      '   Me.dgvDatos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      '   Me.dgvDatos.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      '   Dim columnToSummarize1 As UltraGridColumn = Me.dgvDatos.DisplayLayout.Bands(0).Columns("Costo")
      '   Dim summary1 As SummarySettings = Me.dgvDatos.DisplayLayout.Bands(0).Summaries.Add("Avance", SummaryType.Sum, columnToSummarize1)
      '   summary1.DisplayFormat = "{0:N2}"
      '   summary1.Appearance.TextHAlign = HAlign.Right

      '   Me.dgvDatos.DisplayLayout.Bands(0).SummaryFooterCaption = "Total:"

      'End If

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdProveedor").Value.ToString()

   End Sub

   Private Function GetGrillaDetalle(buscarABM As Eniac.Entidades.Buscar) As DataTable
      Dim idCliente As Long = 0
      Dim idProspecto As Long = 0
      Dim idProveedor As Long = 0
      Dim idNovedad As Integer = 0

      If Me.chbCliente.Checked Then
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.chbNumero.Checked Then
         idNovedad = Integer.Parse(Me.txtNumero.Text)
      End If

      Dim fechaDesde As DateTime? = Nothing
      If chbFecha.Checked Then fechaDesde = dtpFechaDesde.Value
      Dim fechaHasta As DateTime? = Nothing
      If chbFecha.Checked Then fechaHasta = dtpFechaHasta.Value

      Return New Reglas.ReservasTurismo().GetReservas(buscarABM, idCliente, fechaDesde, fechaHasta, If(chbUsuarioAsignado.Checked, Me.cmbUsuarioAsignado.SelectedValue.ToString(), String.Empty),
                                                If(chbEstado.Checked, Integer.Parse(Me.cmbEstadoNovedad.SelectedValue.ToString()), 0),
                                                If(chbNumero.Checked, Long.Parse(Me.txtNumero.Text.ToString()), 0),
                                                finalizado:=Me.cmbFinalizado.SelectedValue.ToString())


   End Function

   Private Sub CargaGrillaDetalle(buscarABM As Eniac.Entidades.Buscar)
      Dim dtDetalle As DataTable = GetGrillaDetalle(buscarABM)

      Me.dgvDatos.DataSource = dtDetalle
      Me.FormatearGrilla()
      Me.PreferenciasLeer(Me.dgvDatos, tsbPreferencias)
      Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub RefrescarDatosGrilla()
      chbFecha.Checked = False
      Me.chkMesCompleto.Checked = False

      Me.dtpFechaDesde.Value = DateTime.Today
      Me.dtpFechaHasta.Value = DateTime.Today.UltimoSegundoDelDia()


      Me.chbEstado.Checked = False
      Me.chbCliente.Checked = False
      Me.chbUsuarioAsignado.Checked = False
      cmbFinalizado.SelectedValue = Entidades.Publicos.SiNoTodos.NO

      chbUsuarioAsignado.Checked = False
      cmbUsuarioAsignado.SelectedValue = _usr.Id

      'If Not _tienePermisoParaVerOtrosUsuarios Then
      '   chbUsuarioAsignado.Enabled = False
      '   cmbUsuarioAsignado.Enabled = False
      'End If
      chbNumero.Checked = False

   End Sub

#End Region

End Class