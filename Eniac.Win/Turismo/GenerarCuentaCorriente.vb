Public Class GenerarCuentaCorriente
   Implements IGenerarCuentaCorrienteConfirmar
#Region "Campos"
   Private _publicos As Publicos
   'Private _tit As Dictionary(Of String, String)
   Private _reserva As Entidades.ReservaTurismo
   Private _blnMiraUsuario As Boolean = True
   Private _blnMiraPC As Boolean = True
   Private _blnCajasModificables As Boolean = True
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS", False)
            _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, True, "TURISMO")
            _publicos.CargaComboDesdeEnum(cmbGenerado, GetType(Entidades.Publicos.SiNoTodos))
            _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, _blnMiraUsuario, _blnMiraPC, _blnCajasModificables)

            RefrescarDatosGrilla()

            PreferenciasLeer(ugPasajeros, tsbPreferencias)

            '_tit = GetColumnasVisiblesGrilla(ugPasajeros)

            If Not cmbTiposComprobantes.Items.Count > 0 Then
               ShowMessage("No Existe la PC en Configuraciones/Impresoras")
               Close()
            End If

            cmbTiposComprobantesGenerar.Initializar(False, False, False, False, "VENTAS", "CTACTECLIE",,,,, "FICHAS")
            Me.cmbTiposComprobantesGenerar.SelectedIndex = 0

         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbGenerar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla(), Sub(owner) tssRegistros.Text = ugPasajeros.CantidadRegistrosParaStatusbar)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If Not bscReserva.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó la Reserva.")
               bscReserva.Select()
               Exit Sub
            End If
            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle() ' se llama a llenar el detalle

            If ugPasajeros.Rows.Count > 0 Then
               tsbGenerar.Enabled = cmbGenerado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos) <> Entidades.Publicos.SiNoTodos.SI
               btnConsultar.Select()
            Else
               tsbGenerar.Enabled = False
               ShowMessage("NO hay registros que cumplan con la seleccion !!!")
               Exit Sub
            End If
         End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugPasajeros.ColapsarExpandir(expandir:=chkExpandAll.Checked))
   End Sub

   Private Sub ugPasajeros_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugPasajeros.InitializeRow
      TryCatched(
         Sub()
            Dim dr = ugPasajeros.FilaSeleccionada(Of DataRow)(e.Row)

            If dr IsNot Nothing Then
               If dr.Field(Of String)("IdTipoComprobante") Is Nothing Then
                  e.Row.Cells("Selec").Activation = Activation.AllowEdit
                  e.Row.Cells("Selec").Color(Color.Black, Color.Aqua)

                  e.Row.Cells("PrimerVencimiento").Color(Color.Black, Color.LightGray)
                  e.Row.Cells("Anticipo").Color(Color.Black, Color.LightGray)
                  e.Row.Cells("CantidadCuotas").Color(Color.Black, Color.LightGray)
                  e.Row.Cells("ImportePrimerCuota").Color(Color.Black, Color.LightGray)
                  e.Row.Cells("ImporteUltimaCuota").Color(Color.Black, Color.LightGray)

                  e.Row.Cells(Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobante.ToString()).Color(Color.Black, Color.LightGray)
                  e.Row.Cells(Entidades.ReservaTurismoPasajero.Columnas.LetraComprobante.ToString()).Color(Color.Black, Color.LightGray)
                  e.Row.Cells(Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobante.ToString()).Color(Color.Black, Color.LightGray)
                  e.Row.Cells(Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobante.ToString()).Color(Color.Black, Color.LightGray)

               Else
                  e.Row.Cells("Selec").Activation = Activation.Disabled
                  e.Row.Cells("Selec").Color(Nothing, Nothing)

                  e.Row.Cells("PrimerVencimiento").Color(Nothing, Nothing)
                  e.Row.Cells("Anticipo").Color(Nothing, Nothing)
                  e.Row.Cells("CantidadCuotas").Color(Nothing, Nothing)
                  e.Row.Cells("ImportePrimerCuota").Color(Nothing, Nothing)
                  e.Row.Cells("ImporteUltimaCuota").Color(Nothing, Nothing)

                  e.Row.Cells(Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobante.ToString()).Color(Nothing, Nothing)
                  e.Row.Cells(Entidades.ReservaTurismoPasajero.Columnas.LetraComprobante.ToString()).Color(Nothing, Nothing)
                  e.Row.Cells(Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobante.ToString()).Color(Nothing, Nothing)
                  e.Row.Cells(Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobante.ToString()).Color(Nothing, Nothing)

               End If
            End If

         End Sub)

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugPasajeros, tsbPreferencias))
   End Sub

   Private Sub bscReserva_BuscadorClick() Handles bscReserva.BuscadorClick
      TryCatched(
         Sub()
            Dim oReservas = New Reglas.ReservasTurismo()

            PreparaGrillaComprobantes(bscReserva)

            Using dtEstados = New Reglas.EstadosTurismo().GetEstadoSolicitaPasajero()
               Dim estado = dtEstados.Select().ToList().ConvertAll(Function(e) e.Field(Of Integer)("IdEstadoturismo"))

               bscReserva.Datos = oReservas.GetReservasPorEstado(estado, actual.Sucursal.Id,
                                                                 cmbTiposComprobantes.ValorSeleccionado(Of String)(),
                                                                 txtLetraComprobante.Text,
                                                                 txtEmisor.ValorNumericoPorDefecto(0S),
                                                                 bscReserva.Text.ValorNumericoPorDefecto(0L))
            End Using
         End Sub)
   End Sub

   Private Sub bscReserva_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscReserva.BuscadorSeleccion
      TryCatched(Sub() If e.FilaDevuelta IsNot Nothing Then CargarComprobante(e.FilaDevuelta))
   End Sub

   Private Sub tsbGenerar_Click(sender As Object, e As EventArgs) Handles tsbGenerar.Click
      TryCatched(
         Sub()
            Dim inicio As Date = Now
            tsbGenerar.Enabled = False

            If GenerarComprobantes() Then
               Dim ts = Now.Subtract(inicio)
               MessageBox.Show("La Generación de COMPROBANTES se Realizó con EXITO!!" + Environment.NewLine + Environment.NewLine +
                            "Tiempo de proceso: " + ts.ToString("hh\:mm\:ss"), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

         End Sub,
         onFinallyAction:=
         Sub(owner)
            tspBarra.Value = 0
            btnConsultar.PerformClick()
         End Sub)
   End Sub

   Private Sub dtpFechaViaje_ValueChanged(sender As Object, e As EventArgs) Handles dtpPrimerVencimiento.ValueChanged, dtpFechaViaje.ValueChanged
      TryCatched(
         Sub()
            Dim reserva = New Reglas.ReservasTurismo().GetUno(actual.Sucursal.Id, cmbTiposComprobantes.ValorSeleccionado(Of String)(),
                                                              txtLetraComprobante.Text, txtEmisor.ValorNumericoPorDefecto(0S),
                                                              bscReserva.Text.ValorNumericoPorDefecto(0L),
                                                              Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
            If reserva IsNot Nothing Then
               Dim tipoViaje = New Reglas.TurismoTiposViajes().GetUno(reserva.IdTipoViaje.IfNull(), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
               If tipoViaje IsNot Nothing Then
                  txtCantidadCuotas.Text = New Reglas.ReservasTurismoPasajeros().CalculaCantidadCuotas(dtpFechaViaje.Value, dtpPrimerVencimiento.Value, tipoViaje).ToString()
               End If
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      If cmbTiposComprobantes.Items.Count > 0 Then
         cmbTiposComprobantes.SelectedIndex = 0
      Else
         ShowMessage("No Existe la PC en Configuraciones/Impresoras")
      End If
      txtLetraComprobante.Text = ""
      txtEmisor.Text = ""
      bscReserva.Text = ""

      cmbGenerado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      dtpFechaViaje.Value = Today
      dtpPrimerVencimiento.Value = Today
      txtSaldo.Text = "0.00"

      cmbFormaPago.SelectedIndex = 0
      cmbCajas.SelectedIndex = 0

      ugPasajeros.ClearFilas()

      rbtPasajeros.Checked = True

      tsbGenerar.Enabled = True

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim regla = New Reglas.ReservasTurismoPasajeros()

      Dim dtDetalle = regla.GetParaCuentaCorriente(actual.Sucursal.Id, cmbTiposComprobantes.ValorSeleccionado(Of String)(),
                                                   txtLetraComprobante.Text, txtEmisor.ValorNumericoPorDefecto(0S),
                                                   bscReserva.Text.ValorNumericoPorDefecto(0L),
                                                   cmbGenerado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                                   dtpPrimerVencimiento.Value, txtAdelanto.ValorNumericoPorDefecto(0D))
      ugPasajeros.DataSource = dtDetalle
      FormatearGrillaPasajeros()
      tssRegistros.Text = ugPasajeros.CantidadRegistrosParaStatusbar

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      Dim Primero = True
      With filtro
         '.AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)
         'If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
         '   .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         'End If

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Public Sub FormatearGrillaPasajeros()
      FormatearGrillaPasajeros(ugPasajeros)
   End Sub
   Public Sub FormatearGrillaPasajeros(ugPasajeros As UltraGrid) Implements IGenerarCuentaCorrienteConfirmar.FormatearGrillaPasajeros
      With ugPasajeros.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next
         Dim col = 0I
         .Columns("Selec").FormatearColumna("S.", col, 30, cellActivation:=Activation.AllowEdit)
         .Columns("NombrePasajero").FormatearColumna("Pasajero", col, 250)

         .Columns("Costo").FormatearColumna("Costo", col, 80, HAlign.Right, , "N2")
         .Columns("PorcentajeLiberado").FormatearColumna("% Lib.", col, 50, HAlign.Right, , "N2")
         .Columns("Importe").FormatearColumna("Importe", col, 80, HAlign.Right, , "N2")

         .Columns("PrimerVencimiento").FormatearColumna("1° Vto.", col, 80, HAlign.Center, , "dd/MM/yyyy")
         .Columns("Anticipo").FormatearColumna("Anticipo", col, 80, HAlign.Right, , "N2")
         .Columns("CantidadCuotas").FormatearColumna("# Cuotas", col, 80, HAlign.Right, , "N2")
         .Columns("ImportePrimerCuota").FormatearColumna("1° Cuota", col, 80, HAlign.Right, , "N2")
         .Columns("ImporteUltimaCuota").FormatearColumna("Última", col, 80, HAlign.Right, , "N2")

         .Columns(Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Comprobante", col, 100)
         .Columns(Entidades.ReservaTurismoPasajero.Columnas.LetraComprobante.ToString()).FormatearColumna("Letra", col, 50, HAlign.Center)
         .Columns(Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobante.ToString()).FormatearColumna("Emisor", col, 50, HAlign.Right)
         .Columns(Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobante.ToString()).FormatearColumna("Numero", col, 50, HAlign.Right)

         ugPasajeros.AgregarFiltroEnLinea({"NombrePasajero"})
         ugPasajeros.AgregarTotalesSuma({"Importe"})
      End With
   End Sub

   Private Sub CargarComprobante(dr As DataGridViewRow)
      cmbTiposComprobantes.SelectedValue = dr.Cells("IdTipoReserva").Value.ToString()
      txtLetraComprobante.Text = dr.Cells("Letra").Value.ToString()
      txtEmisor.Text = dr.Cells("CentroEmisor").Value.ToString()
      bscReserva.Text = dr.Cells("NumeroReserva").Value.ToString()


      _reserva = New Reglas.ReservasTurismo().GetUno(Integer.Parse(dr.Cells("IdSucursal").Value.ToString()), dr.Cells("IdTipoReserva").Value.ToString(),
                                                     dr.Cells("Letra").Value.ToString(), Short.Parse(dr.Cells("CentroEmisor").Value.ToString()),
                                                     Long.Parse(dr.Cells("NumeroReserva").Value.ToString()), Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)

      cmbFormaPago.SelectedValue = _reserva.IdFormaPago
      dtpFechaViaje.Value = _reserva.FechaViaje

      btnConsultar.PerformClick()
   End Sub

   Private Sub PreparaGrillaComprobantes(buscador As Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() With
                              {
                                 .Titulo = "Comprobantes",
                                 .AnchoAyuda = 900
                              }

         Dim col As Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "IdTipoReserva"
         col.Titulo = "Tipo"
         col.Ancho = 120
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "Letra"
         col.Titulo = "L."
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 25
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "CentroEmisor"
         col.Titulo = "Emisor"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 40
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 4
         col.Nombre = "NumeroReserva"
         col.Titulo = "Número"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 5
         col.Nombre = "Fecha"
         col.Titulo = "Fecha"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 6
         col.Nombre = "Costo"
         col.Titulo = "Costo"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 80
         .ColumnasVisibles.Add(col)

         'col = New Controles.ColumnaBuscador
         'col.Orden = 6
         'col.Nombre = "CodigoCliente"
         'col.Titulo = "Código"
         'col.Alineacion = DataGridViewContentAlignment.MiddleRight
         'col.Ancho = 70
         '.ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 7
         col.Nombre = "NombreEstablecimiento"
         col.Titulo = "Establecimiento"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 250
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 8
         col.Nombre = "NombrePrograma"
         col.Titulo = "Programa"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 250
         .ColumnasVisibles.Add(col)
      End With
   End Sub

   Private Sub ValidarGrabacion()
      If _reserva.FechaViaje = Nothing Then
         Throw New Exception(String.Format("La {0} {1} {2:0000}-{3:00000000} no tiene fecha de viaje.",
                                           _reserva.IdTipoReserva, _reserva.Letra, _reserva.CentroEmisor, _reserva.NumeroReserva))
      End If
   End Sub

   Private Function GenerarComprobantes() As Boolean
      ValidarGrabacion()

      Dim dtPasajeros = DirectCast(ugPasajeros.DataSource, DataTable)
      Using frm = New GenerarCuentaCorrienteConfirmar(dtPasajeros, Me)
         If frm.ShowDialog(Me) = DialogResult.OK Then
            Dim rResTur = New Reglas.ReservasTurismo()
            rResTur.GrabarComprobantesDeReservas(actual.Sucursal.IdSucursal,
                                                 _reserva,
                                                 cmbCajas.ValorSeleccionado(Of Integer),
                                                 dtPasajeros,
                                                 cmbTiposComprobantesGenerar.SelectedValue.ToString(),
                                                 Entidades.Entidad.MetodoGrabacion.Automatico,
                                                 Me.IdFuncion, tspBarra)
            Return True
         End If
      End Using
      Return False
   End Function

#End Region

End Class