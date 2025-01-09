Public Class InformeDeNovedadesDetallado
   Implements IConParametros

   Public ReadOnly Property TipoNovedad() As Entidades.CRMTipoNovedad
      Get
         Return TipoNovedadParametro
      End Get
   End Property

   Private Property Modo As Eniac.Entidades.Cliente.ModoClienteProspecto?
   Public Property TipoNovedadParametro As Entidades.CRMTipoNovedad

#Region "Campos"

   Private _publicos As Publicos
   Private _cargando As Boolean = True
   Private _cacheSemaforo As List(Of Entidades.SemaforoVentaUtilidad)

#End Region

   Private Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If Not String.IsNullOrWhiteSpace(parametros) Then
         TipoNovedadParametro = New Reglas.CRMTiposNovedades().GetUno(parametros)
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         _cacheSemaforo = New Reglas.SemaforoVentasUtilidades().GetTodos(Entidades.SemaforoVentaUtilidad.TiposSemaforos.ESTRELLAS)

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         '###########################
         '#      Carga Combos       #
         '###########################
         _publicos.CargaComboUsuarios(Me.cmbIdUsuarioAsignado)
         _publicos.CargaComboDesdeEnum(cmbTipoFechaFiltro, GetType(Entidades.CRMNovedad.TipoFechaFiltro), hideBrowsable:=False, category:="Seguimiento")
         cmbTipoFechaFiltro.SelectedValue = Entidades.CRMNovedad.TipoFechaFiltro.FechaSeguimiento

         _publicos.CargaComboDesdeEnum(cmbTipoUsuario, GetType(Entidades.CRMNovedad.TipoUsuarioFiltro), hideBrowsable:=False)
         cmbTipoUsuario.SelectedValue = Entidades.CRMNovedad.TipoUsuarioFiltro.NS___UsuarioSeguimiento

         _publicos.CargaComboDesdeEnum(cmbFinalizado, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(cmbRevisionAdministrativa, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(cmbActivo, GetType(Entidades.Publicos.SiNoTodos))
         cmbRevisionAdministrativa.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         If cmbIdUsuarioAsignado.DataSource IsNot Nothing AndAlso TypeOf (cmbIdUsuarioAsignado.DataSource) Is List(Of Entidades.Usuario) Then
            Dim lista As List(Of Entidades.Usuario) = DirectCast(cmbIdUsuarioAsignado.DataSource, List(Of Entidades.Usuario))
            Dim usuario As Entidades.Usuario = New Entidades.Usuario()
            usuario.Id = "-"
            usuario.Usuario = "-"
            usuario.Nombre = String.Empty
            lista.Insert(0, usuario)
            'For Each usr As Entidades.Usuario In lista
            '   usr.Id = usr.Id.ToLower()
            '   usr.Usuario = usr.Usuario.ToLower()
            'Next

            cmbIdUsuarioAsignado.DataSource = Nothing
            cmbIdUsuarioAsignado.DisplayMember = "Nombre"
            cmbIdUsuarioAsignado.ValueMember = "Usuario"
            cmbIdUsuarioAsignado.DataSource = lista
         End If

         '# Proyectos
         Me._publicos.CargaComboClasificaciones(Me.cmbClasificacionProyecto)
         Me.cmbClasificacionProyecto.SelectedIndex = -1
         Me._publicos.CargaComboProyectosEstados(Me.cmbEstadoProyecto)
         Me.cmbEstadoProyecto.SelectedIndex = -1

         If TipoNovedadTiene("PROYECTOS") Then
            Me.gbProyecto.Visible = True
         End If

         '# Priorizado
         Me._publicos.CargaComboDesdeEnum(cmbPriorizado, GetType(Entidades.Publicos.SiNoTodos))
         cmbPriorizado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         '# Aplicaciones y Versiones
         Me._publicos.CargaComboAplicacionesEntidad(cmbAplicacion)
         Me._publicos.CargaComboVersiones(cmbVersion, String.Empty)

         '#Misma lógica que muestra la solapa Sinergia en CRMNovedadesDetalle.
         If Not Reglas.Publicos.ExtrasSinergia Then
            Me.cmbAplicacion.Visible = False
            Me.chbAplicacion.Visible = False
            Me.cmbVersion.Visible = False
            Me.chbVersion.Visible = False
         End If

         Me._publicos.CargaComboDesdeEnum(Me.cmbEnGarantia, GetType(Entidades.Publicos.SiNoTodos))
         Me._publicos.CargaComboDesdeEnum(Me.cmbConPrestamo, GetType(Entidades.Publicos.SiNoTodos))
         Me._publicos.CargaComboDesdeEnum(Me.cmbEstadoPrestamo, GetType(Entidades.CRMNovedad.EstadosProductosPrestados))

         Me.cmbEnGarantia.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         Me.cmbConPrestamo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         Me.cmbEstadoPrestamo.SelectedValue = Entidades.CRMNovedad.EstadosProductosPrestados.TODOS

         If TipoNovedad IsNot Nothing AndAlso TipoNovedad.IdTipoNovedad = "SERVICE" Then
            Me.lblEnGarantia.Visible = True
            Me.lblConPrestamo.Visible = True
            Me.lblEstadoPrestamo.Visible = True
            Me.cmbEnGarantia.Visible = True
            Me.cmbConPrestamo.Visible = True
            Me.cmbEstadoPrestamo.Visible = True
         End If

         If TipoNovedadParametro IsNot Nothing Then
            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad, TipoNovedadParametro.IdTipoNovedad)

         Else
            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)
         End If
         Me.cmbTipoNovedad.SelectedIndex = 0

         If TipoNovedadParametro IsNot Nothing Then cmbTipoNovedad.SelectedValue = TipoNovedadParametro.IdTipoNovedad

         Me.cmbEsComentario.Items.Insert(0, "TODOS")
         Me.cmbEsComentario.Items.Insert(1, "SI")
         Me.cmbEsComentario.Items.Insert(2, "NO")
         Me.cmbEsComentario.SelectedIndex = 1

         _cargando = False
         CambiaTipoNovedad()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
      Try
         ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True})
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Me.Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Me.Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As System.Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         ShowError(ex)

      End Try

   End Sub

   Private Sub cmbTipoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoNovedad.SelectedIndexChanged
      Try
         Cursor = Cursors.WaitCursor
         CambiaTipoNovedad()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbProspecto.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            Dim sModo As String = String.Empty
            If Modo.HasValue Then
               sModo = Modo.ToString()
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  sModo = "Proveedor"
               End If
            End If
            ShowMessage(String.Format("ATENCION: NO seleccionó un {0} aunque activó ese Filtro.", Modo.ToString()))
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbProyecto.Checked And Not Me.bscCodigoProyecto.Selecciono And Not Me.bscProyecto.Selecciono Then
            ShowMessage("ATENCION: No seleccionó un Proyecto aunque activó ese Filtro.")
            Exit Sub
         End If

         If Me.chbEstadoProyecto.Checked AndAlso Me.cmbEstadoProyecto.SelectedIndex = -1 Then
            ShowMessage("ATENCION: No seleccionó un Estado de Proyecto aunque activó ese Filtro.")
            Exit Sub
         End If

         If Me.chbClasificacionProyecto.Checked AndAlso Me.cmbClasificacionProyecto.SelectedIndex = -1 Then
            ShowMessage("ATENCION: No seleccionó una Clasificación de Proyecto aunque activó ese Filtro.")
            Exit Sub
         End If

         If Me.chbFuncionNuevo.Checked And Not Me.bscCodigoFuncionNuevo.Selecciono And Not Me.bscFuncionNuevo.Selecciono Then
            ShowMessage("ATENCION: No seleccionó una Funcion aunque activó ese Filtro.")
            Exit Sub
         End If

         If Me.chbNumero.Checked And Me.txtNumero.Text = "0" Then
            ShowMessage("ATENCION: No ingreso un número de Novedad aunque activó ese Filtro.")
            Exit Sub
         End If


         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If TipoNovedadParametro IsNot Nothing AndAlso TipoNovedadParametro.UnidadDeMedida <> "%" Then
            Me.CargarColumnasASumar()
         End If
         LeerPreferencias()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbPrioridad_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrioridad.CheckedChanged
      Try
         Me.cmbPrioridadNovedad.Enabled = Me.chbPrioridad.Checked
         If Not Me.chbPrioridad.Checked Then
            Me.cmbPrioridadNovedad.SelectedIndex = -1
         Else
            If Me.cmbPrioridadNovedad.Items.Count > 0 Then
               Me.cmbPrioridadNovedad.SelectedIndex = 0
            End If
            Me.cmbPrioridadNovedad.Focus()
         End If


      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged

      Try
         Me.cmbCategoriaNovedad.Enabled = Me.chbCategoria.Checked
         If Not Me.chbCategoria.Checked Then
            Me.cmbCategoriaNovedad.SelectedIndex = -1
         Else
            If Me.cmbCategoriaNovedad.Items.Count > 0 Then
               Me.cmbCategoriaNovedad.SelectedIndex = 0
            End If
            Me.cmbCategoriaNovedad.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
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
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbAsignadoA_CheckedChanged(sender As Object, e As EventArgs) Handles chbAsignadoA.CheckedChanged
      Try
         Me.cmbIdUsuarioAsignado.Enabled = Me.chbAsignadoA.Checked
         If Not Me.chbAsignadoA.Checked Then
            Me.cmbIdUsuarioAsignado.SelectedIndex = -1
         Else
            If Me.cmbIdUsuarioAsignado.Items.Count > 0 Then
               Me.cmbIdUsuarioAsignado.SelectedIndex = 0
            End If
            Me.cmbIdUsuarioAsignado.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbMedio_CheckedChanged(sender As Object, e As EventArgs) Handles chbMedio.CheckedChanged
      Try
         Me.cmbMedio.Enabled = Me.chbMedio.Checked
         If Not Me.chbMedio.Checked Then
            Me.cmbMedio.SelectedIndex = -1
         Else
            If Me.cmbMedio.Items.Count > 0 Then
               Me.cmbMedio.SelectedIndex = 0
            End If
            Me.cmbMedio.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
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

   Private Sub chbCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbProspecto.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbProspecto.Checked
      Me.bscCliente.Enabled = Me.chbProspecto.Checked


      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick

      Dim codigoCliente As Long = -1
      Try
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
            Else
               Me._publicos.PreparaGrillaProspectos2(Me.bscCodigoCliente)
            End If
            Dim oClientes As Reglas.Clientes = New Reglas.Clientes(Modo.Value)
            If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
               codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
            End If
            Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
         Else
            If TipoNovedadTiene("PROVEEDORES") Then
               Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoCliente)
               Dim oClientes As Reglas.Proveedores = New Reglas.Proveedores()
               If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
                  codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
               End If
               Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True)
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            If Modo.HasValue Then
               Me.CargarDatosCliente(e.FilaDevuelta)
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  Me.CargarDatosProveedor(e.FilaDevuelta)
               End If
            End If
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
            Else
               Me._publicos.PreparaGrillaProspectos2(Me.bscCliente)
            End If
         Else
            If TipoNovedadTiene("PROVEEDORES") Then
               Me._publicos.PreparaGrillaProveedores2(Me.bscCliente)
            End If
         End If
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes(Modo.Value)
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            If Modo.HasValue Then
               Me.CargarDatosCliente(e.FilaDevuelta)
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  Me.CargarDatosProveedor(e.FilaDevuelta)
               End If
            End If
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow

      Try
         CRMNovedadesABM.InitializeRow(e.Row, TipoNovedad, _cacheSemaforo)
         If e.Row IsNot Nothing Then
            If IsNumeric(e.Row.Cells("ColorEstadoNovedadSeguimiento").Value) Then
               Dim color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells("ColorEstadoNovedadSeguimiento").Value.ToString()))
               e.Row.Cells("NombreEstadoNovedadSeguimiento").Color(Nothing, color)

            End If

            If IsNumeric(e.Row.Cells("ColorTiposComentariosNovedades").Value) Then
               Dim color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells("ColorTiposComentariosNovedades").Value.ToString()))
               e.Row.Cells("NombreTipoComentarioNovedad").Color(Nothing, color)

            End If


         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbCategoria.Checked = False
      chbAsignadoA.Checked = False
      chbEstado.Checked = False
      chbMedio.Checked = False
      chbPrioridad.Checked = False
      chbProspecto.Checked = False
      chkExpandAll.Checked = False
      chbNumero.Checked = False
      chbAplicacion.Checked = False
      chbVersion.Checked = False
      chbMetodoResolucion.Checked = False

      chbFuncionNuevo.Checked = False
      chbProyecto.Checked = False
      chbPrioridadProyecto.Checked = False
      chbEstadoProyecto.Checked = False
      chbClasificacionProyecto.Checked = False

      cmbRevisionAdministrativa.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbFinalizado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbPriorizado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      cmbEnGarantia.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbConPrestamo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbEstadoPrestamo.SelectedValue = Entidades.CRMNovedad.EstadosProductosPrestados.TODOS

      cmbTipoFechaFiltro.SelectedValue = Entidades.CRMNovedad.TipoFechaFiltro.FechaSeguimiento
      cmbTipoUsuario.SelectedValue = Entidades.CRMNovedad.TipoUsuarioFiltro.NS___UsuarioSeguimiento


      cmbActivo.SelectedValue = Entidades.Publicos.SiNoTodos.SI

      ugDetalle.ClearFilas()

      If TipoNovedadParametro IsNot Nothing Then cmbTipoNovedad.SelectedValue = TipoNovedadParametro.IdTipoNovedad

      cmbEsComentario.SelectedIndex = 1

      dtpDesde.Focus()

   End Sub

   Private Sub CambiaTipoNovedad()
      If _cargando Then Return
      Dim tipoNovedad As Entidades.CRMTipoNovedad = GetTipoNovedad()

      Me.RefrescarDatosGrilla()

      If tipoNovedad IsNot Nothing Then
         Dim idTipoNovedad As String = tipoNovedad.IdTipoNovedad
         _publicos.CargaComboCRMPrioridadesNovedades(cmbPrioridadNovedad, idTipoNovedad)
         _publicos.CargaComboCRMEstadosNovedades(cmbEstadoNovedad, idTipoNovedad)
         _publicos.CargaComboCRMCategoriasNovedades(cmbCategoriaNovedad, idTipoNovedad)
         _publicos.CargaComboCRMMediosComunicacionesNovedades(cmbMedio, idTipoNovedad)
         _publicos.CargaComboCRMMetodoResolucionNovedad(cmbMetodoResolucion, idTipoNovedad)
         _publicos.CargaComboCRMTiposComentariosNovedades(cmbTipoComentario, idTipoNovedad)
         For Each dinamico As Entidades.CRMTipoNovedadDinamico In tipoNovedad.Dinamicos
            Select Case dinamico.IdNombreDinamico
               Case "CLIENTES"
                  Modo = Entidades.Cliente.ModoClienteProspecto.Cliente
                  chbProspecto.Text = Modo.ToString()
               Case "PROSPECTOS"
                  Modo = Entidades.Cliente.ModoClienteProspecto.Prospecto
                  chbProspecto.Text = Modo.ToString()
               Case "PROVEEDORES"
                  Modo = Nothing
                  chbProspecto.Text = "Proveedor"
               Case "FUNCIONES"
                  chbFuncionNuevo.Visible = True
                  bscCodigoFuncionNuevo.Visible = False
                  bscFuncionNuevo.Visible = True
               Case Else
            End Select
         Next

      Else
         ClearCombo(cmbPrioridadNovedad)
         ClearCombo(cmbEstadoNovedad)
         ClearCombo(cmbCategoriaNovedad)
         ClearCombo(cmbMedio)
         ClearCombo(cmbMetodoResolucion)
         ClearCombo(cmbTipoComentario)
      End If

   End Sub

   Private Function GetTipoNovedad() As Entidades.CRMTipoNovedad
      If cmbTipoNovedad.SelectedIndex >= 0 Then
         Return DirectCast(cmbTipoNovedad.SelectedItem, Entidades.CRMTipoNovedad)
      Else
         Return Nothing
      End If
   End Function

   Private Sub ClearCombo(cmb As ComboBox)
      If TypeOf (cmb.DataSource) Is IList Then DirectCast(cmb.DataSource, IList).Clear()
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim IdCliente = 0L
      Dim IdProspecto = 0L
      Dim IdProveedor = 0L

      If Me.chbProspecto.Checked Then
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            Else
               IdProspecto = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            End If
         Else
            If TipoNovedadTiene("PROVEEDORES") Then
               IdProveedor = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            End If
         End If
      End If

      Dim idCategoriaNovedad = cmbCategoriaNovedad.ValorSeleccionado(chbCategoria, 0I)
      Dim idEstadoNovedad = cmbEstadoNovedad.ValorSeleccionado(chbEstado, 0I)
      Dim idUsuarioAsignado = cmbIdUsuarioAsignado.ValorSeleccionado(chbAsignadoA, String.Empty)
      Dim idMedioComunicacionNovedad = cmbMedio.ValorSeleccionado(chbMedio, 0I)
      Dim idNovedad = txtNumero.ValorSeleccionado(chbNumero, 0I)
      Dim idNovedadPadre = txtNumeroPadre.ValorSeleccionado(chbNumeroPadre, 0I)
      Dim idPrioridadNovedad = cmbPrioridadNovedad.ValorSeleccionado(chbPrioridad, 0I)
      Dim idProyecto = If(chbProyecto.Checked, bscCodigoProyecto.Text.ValorNumericoPorDefecto(0I), 0I)

      '# Prioridad del Proyecto
      Dim idPrioridadProyectoDesde = If(chbPrioridadProyecto.Checked, nudPrioridadDesde.Value, 0D)
      Dim idPrioridadProyectoHasta = If(chbPrioridadProyecto.Checked, nudPrioridadHasta.Value, 0D)

      '# Estado del Proyecto
      Dim idEstadoProyecto = cmbEstadoProyecto.ValorSeleccionado(chbEstadoProyecto, 0I)

      '# Clasificación del Proyecto
      Dim idClasificacionProyecto = cmbClasificacionProyecto.ValorSeleccionado(chbClasificacionProyecto, 0I)

      'Dim idUsuarioAlta As String = String.Empty
      'If Me.cmbUsuarioAlta.Enabled Then
      '   idUsuarioAlta = Me.cmbUsuarioAlta.SelectedValue.ToString()
      'End If

      Dim rCRM = New Reglas.CRMNovedadesSeguimiento()
      Dim dtDetalle = rCRM.GetNovedadesSeguimientos(dtpDesde.Value, dtpHasta.Value, cmbTipoNovedad.SelectedValue.ToString(),
                                                    idCategoriaNovedad, idEstadoNovedad, idUsuarioAsignado,
                                                    cmbTipoUsuario.ValorSeleccionado(Of Entidades.CRMNovedad.TipoUsuarioFiltro), idMedioComunicacionNovedad,
                                                    idNovedad, idNovedadPadre, IdCliente, IdProspecto, IdProveedor, idPrioridadNovedad,
                                                    cmbEsComentario.Text, cmbTipoFechaFiltro.ValorSeleccionado(Of Entidades.CRMNovedad.TipoFechaFiltro),
                                                    cmbFinalizado.Text,
                                                    bscCodigoFuncionNuevo.Text,
                                                    If(chbMetodoResolucion.Checked, cmbMetodoResolucion.ValorSeleccionado(Of Integer), 0),
                                                    cmbRevisionAdministrativa.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                    cmbPriorizado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                    If(chbAplicacion.Checked, cmbAplicacion.SelectedValue.ToString(), String.Empty),
                                                    If(chbVersion.Checked, cmbVersion.SelectedValue.ToString, String.Empty),
                                                    idProyecto,
                                                    idPrioridadProyectoDesde,
                                                    idPrioridadProyectoHasta,
                                                    idEstadoProyecto,
                                                    idClasificacionProyecto,
                                                    enGarantia:=cmbEnGarantia.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                                    enPrestamo:=cmbConPrestamo.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                                    estadoPrestamo:=cmbEstadoPrestamo.ValorSeleccionado(Of Entidades.CRMNovedad.EstadosProductosPrestados)(),
                                                    activo:=cmbActivo.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                    cmbTipoComentario.ValorSeleccionado(chbTipoComentario, 0I))

      ugDetalle.DataSource = dtDetalle
      FormatearGrilla()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Public Sub FormatearGrilla()

      Dim pos = 0I
      CRMNovedadesABM.FormatearGrilla(ugDetalle, TipoNovedad, pos)

      With ugDetalle.DisplayLayout.Bands(0)

         pos = .Columns(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).Header.VisiblePosition + 1
         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.IdSeguimiento.ToString()).FormatearColumna("Identif.", pos, 50, HAlign.Right)
         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.FechaSeguimiento.ToString()).FormatearColumna("Fecha / Hora Comentario", pos, 120, HAlign.Center, hidden:=True, "dd/MM/yyyy HH:mm:ss")
         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.FechaSeguimiento.ToString() + "_Fecha").FormatearColumna("Fecha Comentario", pos, 80, HAlign.Center)
         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.FechaSeguimiento.ToString() + "_Hora").FormatearColumna("Hora Comentario", pos, 40, HAlign.Center)

         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.UsuarioSeguimiento.ToString()).FormatearColumna("Usuario Comentario", pos, 70)
         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString()).FormatearColumna("Comentario", pos, 200)
         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.EsComentario.ToString()).FormatearColumna("Es Coment.", pos, 60, HAlign.Center)

         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.Interlocutor.ToString()).FormatearColumna("Interlocutor Comentario", pos, 80)


         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.IdTipoComentarioNovedad.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.CRMTipoComentarioNovedad.Columnas.NombreTipoComentarioNovedad.ToString()).FormatearColumna("Tipo Comentario", pos, 200)
         .Columns("ColorTiposComentariosNovedades").OcultoPosicion(True, pos)
         'stb1.AppendFormatLine(" , TCNS.Color ColorTiposComentariosNovedades")

         .Columns(Entidades.CRMNovedadSeguimiento.Columnas.Activo.ToString()).FormatearColumna("Activo", pos, 60, HAlign.Center)

         .Columns("IdEstadoNovedadSeguimiento").OcultoPosicion(True, pos)
         .Columns("NombreEstadoNovedadSeguimiento").FormatearColumna("Estado Comentario", pos, 80)

         .Columns("UsuarioAsignadoSeguimiento").FormatearColumna("Usuario Asignado Comentario", pos, 70)

         .Columns("IdUnico").OcultoPosicion(True, pos)
         .Columns("FechaActualizacionWeb").OcultoPosicion(True, pos)

         If .Columns.Exists("Ver") Then
            .Columns("Ver").Hidden = True
         End If

         ugDetalle.AgregarFiltroEnLinea({Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString()})

      End With
   End Sub

   Protected Function TipoNovedadTiene(dinamico As String) As Boolean
      If TipoNovedad Is Nothing Then Return True
      For Each din As Entidades.CRMTipoNovedadDinamico In TipoNovedad.Dinamicos
         If din.IdNombreDinamico.ToLower().Equals(dinamico.ToLower()) Then
            Return True
         End If
      Next
      Return False
   End Function

   Protected Sub FormatearColumna(col As UltraGridColumn, caption As String, ByRef posicion As Integer, ancho As Integer,
                               Optional alineacion As HAlign = HAlign.Default, Optional hidden As Boolean = False)
      col.Hidden = hidden
      col.Header.Caption = caption
      col.Header.VisiblePosition = posicion
      col.Width = ancho
      col.CellAppearance.TextHAlign = alineacion
      posicion += 1
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("Nombre" + Modo.Value.ToString()).Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("Codigo" + Modo.Value.ToString()).Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("Id" + Modo.Value.ToString()).Value.ToString()

   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdProveedor").Value.ToString()

   End Sub

   Private Sub CargarColumnasASumar()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("Avance") Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Avance")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Avance", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Total:"

      End If

   End Sub


   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         .AppendFormat("{2}: Desde {0} Hasta {1}", Me.dtpDesde.Text, dtpHasta.Text, cmbTipoFechaFiltro.Text)

         If cmbIdUsuarioAsignado.SelectedIndex >= 0 Then .AppendFormat(" - {1}: {0} - ", cmbIdUsuarioAsignado.Text, cmbTipoUsuario.Text)
         If chbProspecto.Checked Then .AppendFormat(" - {2}: {0} - {1}", bscCodigoCliente.Text, bscCliente.Text, chbProspecto.Text)
         If chbCategoria.Checked Then .AppendFormat(" - {1}: {0}", cmbCategoriaNovedad.Text, chbCategoria.Text)
         If chbEstado.Checked Then .AppendFormat(" - {1}: {0}", cmbEstadoNovedad.Text, chbEstado.Text)
         If chbPrioridad.Checked Then .AppendFormat(" - {1}: {0}", cmbPrioridadNovedad.Text, chbPrioridad.Text)
         If chbFuncionNuevo.Checked Then .AppendFormat(" - {1}: {0}", bscFuncionNuevo.Text, chbFuncionNuevo.Text)

         .AppendFormat(" - {1}: {0}", cmbEsComentario.Text, lblEsComentario.Text)

         If chbMedio.Checked Then .AppendFormat(" - {1}: {0}", cmbMedio.Text, chbMedio.Text)
         If chbMetodoResolucion.Checked Then .AppendFormat(" - {1}: {0}", cmbMetodoResolucion.Text, chbMetodoResolucion.Text)

         .AppendFormat(" - {1}: {0}", cmbRevisionAdministrativa.Text, lblRevisionAdministrativa.Text)
         .AppendFormat(" - {1}: {0}", cmbFinalizado.Text, lblFinalizado.Text)
         .AppendFormat(" - {1}: {0}", cmbPriorizado.Text, lblPriodizado.Text)
         .AppendFormat(" - {1}: {0}", cmbEnGarantia.Text, lblEnGarantia.Text)
         .AppendFormat(" - {1}: {0}", cmbConPrestamo.Text, lblConPrestamo.Text)
         .AppendFormat(" - {1}: {0}", cmbEstadoPrestamo.Text, lblEstadoPrestamo.Text)

         If chbAplicacion.Checked Then .AppendFormat(" - {1}: {0}", cmbAplicacion.Text, chbAplicacion.Text)
         If chbVersion.Checked Then .AppendFormat(" - {1}: {0}", cmbVersion.Text, chbVersion.Text)

         If chbNumero.Checked Then .AppendFormat(" - {1}: {0}", txtNumero.Text, chbNumero.Text)
         If chbNumeroPadre.Checked Then .AppendFormat(" - {1}: {0}", txtNumeroPadre.Text, chbNumeroPadre.Text)

         .AppendFormat(" - {1}: {0}", cmbActivo.Text, lblActivo.Text)

         If chbProyecto.Checked Then .AppendFormat(" - {2}: {0} - {1}", bscCodigoProyecto.Text, bscProyecto.Text, chbProyecto.Text)

         If chbPrioridadProyecto.Checked Then .AppendFormat(" - {1} {2}: {0}", nudPrioridadDesde.Value, chbPrioridadProyecto.Text, lblPrioridadProyectoDesde)
         If chbPrioridadProyecto.Checked Then .AppendFormat(" - {1} {2}: {0}", nudPrioridadHasta.Value, chbPrioridadProyecto.Text, lblPrioridadProyectoHasta)

         If chbEstadoProyecto.Checked Then .AppendFormat(" - {1}: {0}", cmbEstadoProyecto.Text, chbEstadoProyecto.Text)
         If chbClasificacionProyecto.Checked Then .AppendFormat(" - {1}: {0}", cmbClasificacionProyecto.Text, chbClasificacionProyecto.Text)

      End With

      Return filtro.ToString()

   End Function


#End Region

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFuncionNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbFuncionNuevo.CheckedChanged
      Me.bscCodigoFuncionNuevo.Enabled = Me.chbFuncionNuevo.Checked
      Me.bscFuncionNuevo.Enabled = Me.chbFuncionNuevo.Checked

      Me.bscCodigoFuncionNuevo.Text = String.Empty
      Me.bscCodigoFuncionNuevo.Tag = Nothing
      Me.bscFuncionNuevo.Text = String.Empty

      Me.bscCodigoFuncionNuevo.Focus()
   End Sub

   Private Sub bscCodigoFuncionNuevo_BuscadorClick() Handles bscCodigoFuncionNuevo.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscCodigoFuncionNuevo)
         Me.bscCodigoFuncionNuevo.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncionNuevo.Text, String.Empty)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCodigoFuncionNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncionNuevo.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscFuncionNuevo_BuscadorClick() Handles bscFuncionNuevo.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscFuncionNuevo)
         Me.bscFuncionNuevo.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, Me.bscFuncionNuevo.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscFuncionNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscFuncionNuevo.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      Me.bscFuncionNuevo.Text = dr.Cells("Nombre").Value.ToString()
      Me.bscCodigoFuncionNuevo.Text = dr.Cells("Id").Value.ToString().Trim()
   End Sub
   Private Sub chbAplicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbAplicacion.CheckedChanged
      Try
         Me.cmbAplicacion.Enabled = Me.chbAplicacion.Checked
         If Not Me.chbAplicacion.Checked Then
            Me.cmbAplicacion.SelectedIndex = -1
         Else
            If Me.cmbAplicacion.Items.Count > 0 Then
               Me.cmbAplicacion.SelectedIndex = 2
            End If
         End If
         Me.cmbAplicacion.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbVersion.CheckedChanged
      Try
         Me.cmbVersion.Enabled = Me.chbVersion.Checked
         If Not Me.chbVersion.Checked Then
            Me.cmbVersion.SelectedIndex = -1
         Else
            If Me.cmbVersion.Items.Count > 0 Then
               Me.cmbVersion.SelectedIndex = 0
            End If
         End If
         Me.cmbVersion.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbAplicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAplicacion.SelectedIndexChanged
      Try
         _publicos.CargaComboVersiones(cmbVersion, If(chbAplicacion.Checked, cmbAplicacion.SelectedValue.ToString(), String.Empty))
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProyecto.CheckedChanged

      Try
         Me.bscCodigoProyecto.Enabled = Me.chbProyecto.Checked
         Me.bscProyecto.Enabled = bscCodigoProyecto.Enabled
         If Not Me.chbProyecto.Checked Then
            Me.bscCodigoProyecto.Text = String.Empty
            Me.bscProyecto.Text = String.Empty
         Else
            Me.bscCodigoProyecto.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbPrioridadProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrioridadProyecto.CheckedChanged
      Try
         Me.nudPrioridadDesde.Enabled = Me.chbPrioridadProyecto.Checked
         Me.nudPrioridadHasta.Enabled = Me.nudPrioridadDesde.Enabled
         If Not Me.chbPrioridadProyecto.Checked Then
            Me.nudPrioridadDesde.Value = 1
            Me.nudPrioridadHasta.Value = 5
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbEstadoProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoProyecto.CheckedChanged

      Try
         Me.cmbEstadoProyecto.Enabled = Me.chbEstadoProyecto.Checked
         If Not Me.chbEstadoProyecto.Checked Then
            Me.cmbEstadoProyecto.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbClasificacionProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbClasificacionProyecto.CheckedChanged

      Try
         Me.cmbClasificacionProyecto.Enabled = Me.chbClasificacionProyecto.Checked
         If Not Me.chbClasificacionProyecto.Checked Then
            Me.cmbClasificacionProyecto.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub bscProyecto_BuscadorClick() Handles bscProyecto.BuscadorClick

      Try
         Me._publicos.PreparaGrillaProyectos(Me.bscProyecto)
         Dim rProyectos As Reglas.Proyectos = New Reglas.Proyectos()
         Dim idCliente = If(chbProspecto.Checked, If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), 0), DirectCast(Nothing, Long?))
         Me.bscProyecto.Datos = rProyectos.GetFiltradoPorNombre(Me.bscProyecto.Text.Trim(), idCliente)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProyecto.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProyecto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProyecto_BuscadorClick() Handles bscCodigoProyecto.BuscadorClick

      Try
         Dim codigoProyecto As Integer? = If(String.IsNullOrEmpty(Me.bscCodigoProyecto.Text), DirectCast(Nothing, Integer?), Integer.Parse(Me.bscCodigoProyecto.Text))
         Me._publicos.PreparaGrillaProyectos(Me.bscCodigoProyecto)
         Dim rProyectos As Reglas.Proyectos = New Reglas.Proyectos()
         Dim idCliente = If(chbProspecto.Checked, If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), 0), DirectCast(Nothing, Long?))
         Me.bscCodigoProyecto.Datos = rProyectos.GetFiltradoPorCodigo(codigoProyecto, idCliente)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProyecto.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProyecto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub CargarDatosProyecto(dr As DataGridViewRow)

      bscCodigoProyecto.Text = dr.Cells("IdProyecto").Value.ToString()
      bscProyecto.Text = dr.Cells("NombreProyecto").Value.ToString()
      bscCodigoProyecto.Selecciono = True
      bscProyecto.Selecciono = True
   End Sub

   Private Sub chbMetodoResolucion_CheckedChanged(sender As Object, e As EventArgs) Handles chbMetodoResolucion.CheckedChanged
      TryCatched(Sub() chbMetodoResolucion.FiltroCheckedChanged(cmbMetodoResolucion))
   End Sub

   Private Sub chbNumeroPadre_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroPadre.CheckedChanged
      TryCatched(Sub()
                    Me.txtNumeroPadre.Enabled = Me.chbNumeroPadre.Checked
                    If Not Me.chbNumeroPadre.Checked Then
                       Me.txtNumeroPadre.Text = ""
                    Else
                       Me.txtNumeroPadre.Text = "0"
                       Me.txtNumeroPadre.Focus()
                    End If
                 End Sub)
   End Sub

   Private Sub chbTipoComentario_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComentario.CheckedChanged
      TryCatched(Sub() chbTipoComentario.FiltroCheckedChanged(cmbTipoComentario))
   End Sub
End Class