#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid
Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Text
Imports System.ComponentModel
#End Region
Public Class RegistrarReparto

   Private _dtDetalle As DataTable
   Private _publicos As Publicos
   Private _gastos As List(Of Entidades.RepartoGasto)
   Private _titGastos As Dictionary(Of String, String)
   Private _totalesEntregadosPorProducto As Dictionary(Of String, Decimal) = New Dictionary(Of String, Decimal)()

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try

         Me._publicos = New Publicos()

         tbcReparto.SelectedTab = tbpGastos
         _titGastos = GetColumnasVisiblesGrilla(ugGastos)
         tbcReparto.SelectedTab = tbpReparto

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantesSalida, True, "VENTAS", , , , True, , , , , -1)
         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantesEntrada, True, "VENTAS", , , , True, , , , , 1)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "VENTAS", , , , True)

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         _publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, MiraUsuario:=True, MiraPC:=Not Reglas.Publicos.CtaCte.ReciboIgnorarPCdeCaja, CajasModificables:=True)

         '_publicos.CargaComboRutas(Me.cmbRutas, True, False, False)
         cmbRutas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, cargarListaPrecios:=False)
         _publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS", contado:=False)


         Rerfescar()


         ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         ugDetalle.AgregarTotalesSuma({"ImporteTotal", "ImportePagado"})
         ugGastos.AgregarTotalesSuma({"ImportePesos"})

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "Direccion"})
         ugGastos.AgregarFiltroEnLinea({"NombreCuentaCaja"})

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F5 Then
            tsbRefrescar.PerformClick()
            Return True
         End If
         If keyData = Keys.F4 Then
            tsbGrabar.PerformClick()
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Rerfescar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Cursor = Cursors.WaitCursor
         GrabarReparto()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region

#Region "Eventos Grilla"
   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.AfterCellUpdate
      Try
         If e.Cell.Row IsNot Nothing AndAlso
            e.Cell.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row

            Dim importeTotal As Decimal = 0
            For Each dc As DataColumn In dr.Table.Columns
               If dc.ColumnName.EndsWith("___cantidad") Then
                  Dim cantidad As Decimal = Decimal.Parse(dr(dc.ColumnName).ToString())
                  Dim precio As Decimal = Decimal.Parse(dr(dc.ColumnName.Replace("___cantidad", "") + "___precio").ToString())
                  importeTotal += cantidad * precio
               End If
            Next

            dr("ImporteTotal") = importeTotal

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         If e.Cell.Column.Key = "CopiarValor" Then
            e.Cell.Row.Cells("ImportePagado").Value = e.Cell.Row.Cells("ImporteTotal").Value
         End If
         e.Cell.Row.Band.Layout.Grid.UpdateData()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub cmbTiposComprobantesSalida_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesSalida.SelectedValueChanged
      Try
         If cmbTiposComprobantesSalida.SelectedIndex < 0 Then
            txtLetraSalida.Text = ""
         ElseIf String.IsNullOrWhiteSpace(GetTipoComprobanteSalida().LetrasHabilitadas) Then
            txtLetraSalida.Text = ""
         Else
            txtLetraSalida.Text = GetTipoComprobanteSalida().LetrasHabilitadas.Split(","c)(0)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub cmbTiposComprobantesEntrada_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTiposComprobantesEntrada.SelectedValueChanged
      Try
         If cmbTiposComprobantesEntrada.SelectedIndex < 0 Then
            txtLetraEntrada.Text = ""
         ElseIf String.IsNullOrWhiteSpace(GetTipoComprobanteEntrada().LetrasHabilitadas) Then
            txtLetraEntrada.Text = ""
         Else
            txtLetraEntrada.Text = GetTipoComprobanteEntrada().LetrasHabilitadas.Split(","c)(0)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbMostrarPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbMostrarPrecios.CheckedChanged
      Try
         For Each columna As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
            If columna.Key.EndsWith("___precio") Then
               columna.Hidden = Not chbMostrarPrecios.Checked
            End If
         Next
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbMostrarCambios_CheckedChanged(sender As Object, e As EventArgs) Handles chbMostrarCambios.CheckedChanged
      Try
         For Each columna As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
            If columna.Key.EndsWith("___cantidadCambio") Then
               columna.Hidden = Not chbMostrarCambios.Checked
            End If
         Next
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If _dtDetalle.Rows.Count > 0 Then
            ugDetalle.Focus()
         Else
            ShowMessage("No hay registros que cumplan con la selección !!!")
         End If
      Catch ex As Exception
         MuestraCantidadRegistros()
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         bscCodigoCliente.Visible = True
         bscCodigoCliente.Text = ""
         bscCodigoCliente.PresionarBoton()
      Catch ex As Exception
         ShowError(ex)
      Finally
         bscCodigoCliente.Visible = False
      End Try
   End Sub

#Region "Eventos Busquedas Foraneas"
   Private Sub bscComprobanteSalida_BuscadorClick() Handles bscComprobanteSalida.BuscadorClick
      Try
         Dim oComprobantes As Reglas.Ventas = New Reglas.Ventas

         Dim numero As Long = 0

         Long.TryParse(Me.bscComprobanteSalida.Text, numero)

         Me.PreparaGrillaComprobantes(Me.bscComprobanteSalida)

         Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()
         If cmbTiposComprobantesSalida.SelectedIndex > -1 Then
            tiposComprobantes.Add(DirectCast(cmbTiposComprobantesSalida.SelectedItem, Entidades.TipoComprobante))
         End If

         Dim numeroComprobante As Long = If(IsNumeric(bscComprobanteSalida.Text), Long.Parse(bscComprobanteSalida.Text), 0)
         Dim centroEmisor As Integer = If(IsNumeric(txtEmisorSalida.Text), Integer.Parse(txtEmisorSalida.Text), 0)


         bscComprobanteSalida.Datos = oComprobantes.GetInformeDeVentas({actual.Sucursal},
                                                      desde:=New Date(1900, 1, 1), hasta:=New Date(9999, 1, 1),
                                                      idZonaGeografica:="", IdVendedor:=0, vendedor:=Entidades.OrigenFK.Movimiento, idCliente:=0,
                                                      grabaLibro:=Entidades.Publicos.SiNoTodos.TODOS, afectaCaja:=Entidades.Publicos.SiNoTodos.TODOS,
                                                      idFormaDePago:=0, idUsuario:="", idLocalidad:=0, idProvincia:="",
                                                      numeroComprobanteDesde:=numeroComprobante,
                                                      numeroComprobanteHasta:=numeroComprobante,
                                                      letraFiscal:=txtLetraSalida.Text,
                                                      centroEmisor:=centroEmisor,
                                                      mercDespachada:=Entidades.Publicos.SiNoTodos.TODOS, comercial:=Entidades.Publicos.SiNoTodos.TODOS,
                                                      idCategoria:=0, categoria:=Entidades.OrigenFK.Movimiento,
                                                      numeroRepartoDesde:=0, numeroRepartoHasta:=0,
                                                      listaComprobantes:=tiposComprobantes,
                                                      coeficienteStock:=-1,
                                                      esRemitoTransportista:=True,
                                                      incluirAnulados:=False,
                                                      idCentroCosto:=0,
                                                      correoEnviado:=Entidades.Publicos.SiNoTodos.TODOS,
                                                      idPaciente:=Nothing, idDoctor:=Nothing, fechaCirugia:=Nothing, idTransportista:=0)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscComprobanteSalida_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscComprobanteSalida.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarComprobante(e.FilaDevuelta, cmbTiposComprobantesSalida, txtLetraSalida, txtEmisorSalida, bscComprobanteSalida, Nothing)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscComprobanteEntrada_BuscadorClick() Handles bscComprobanteEntrada.BuscadorClick
      Try
         Dim oComprobantes As Reglas.Ventas = New Reglas.Ventas

         Dim numero As Long = 0

         Long.TryParse(Me.bscComprobanteEntrada.Text, numero)

         Me.PreparaGrillaComprobantes(Me.bscComprobanteEntrada)

         Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()
         If cmbTiposComprobantesEntrada.SelectedIndex > -1 Then
            tiposComprobantes.Add(DirectCast(cmbTiposComprobantesEntrada.SelectedItem, Entidades.TipoComprobante))
         End If

         Dim numeroComprobante As Long = If(IsNumeric(bscComprobanteEntrada.Text), Long.Parse(bscComprobanteEntrada.Text), 0)
         Dim centroEmisor As Integer = If(IsNumeric(txtEmisorEntrada.Text), Integer.Parse(txtEmisorEntrada.Text), 0)


         bscComprobanteEntrada.Datos = oComprobantes.GetInformeDeVentas({actual.Sucursal},
                                                      desde:=New Date(1900, 1, 1), hasta:=New Date(9999, 1, 1),
                                                      idZonaGeografica:="", IdVendedor:=0, vendedor:=Entidades.OrigenFK.Movimiento, idCliente:=0,
                                                      grabaLibro:=Entidades.Publicos.SiNoTodos.TODOS, afectaCaja:=Entidades.Publicos.SiNoTodos.TODOS,
                                                      idFormaDePago:=0, idUsuario:="", idLocalidad:=0, idProvincia:="",
                                                      numeroComprobanteDesde:=numeroComprobante,
                                                      numeroComprobanteHasta:=numeroComprobante,
                                                      letraFiscal:=txtLetraEntrada.Text,
                                                      centroEmisor:=centroEmisor,
                                                      mercDespachada:=Entidades.Publicos.SiNoTodos.TODOS, comercial:=Entidades.Publicos.SiNoTodos.TODOS,
                                                      idCategoria:=0, categoria:=Entidades.OrigenFK.Movimiento,
                                                      numeroRepartoDesde:=0, numeroRepartoHasta:=0,
                                                      listaComprobantes:=tiposComprobantes,
                                                      coeficienteStock:=1,
                                                      esRemitoTransportista:=True,
                                                      incluirAnulados:=False,
                                                      idCentroCosto:=0,
                                                      correoEnviado:=Entidades.Publicos.SiNoTodos.TODOS,
                                                      idPaciente:=Nothing, idDoctor:=Nothing, fechaCirugia:=Nothing, idTransportista:=0)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscComprobanteEntrada_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscComprobanteEntrada.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarComprobante(e.FilaDevuelta, cmbTiposComprobantesEntrada, txtLetraEntrada, txtEmisorEntrada, bscComprobanteEntrada,
                                 dtpFecha)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick

      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub


   Private Sub bscCuentaCaja_BuscadorClick() Handles bscCuentaCaja.BuscadorClick
      Try
         Me._publicos.PreparaGrillaCuentasDeCajas(Me.bscCuentaCaja)
         Dim oCuentasDeCaja As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas()
         bscCuentaCaja.Datos = oCuentasDeCaja.GetTodas(Me.bscCuentaCaja.Text)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCuentaCaja_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCuentaCaja.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaDeCaja(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreCuentaCaja_BuscadorClick() Handles bscNombreCuentaCaja.BuscadorClick
      Try
         Me._publicos.PreparaGrillaCuentasDeCajas(Me.bscNombreCuentaCaja)
         Dim oCuentasDeCaja As Reglas.CuentasDeCajas = New Reglas.CuentasDeCajas()
         bscNombreCuentaCaja.Datos = oCuentasDeCaja.GetPorNombre(Me.bscNombreCuentaCaja.Text)

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreCuentaCaja_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCuentaCaja.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaDeCaja(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub



#End Region

#End Region

#Region "Métodos"
   Private Sub Rerfescar()
      cmbRutas.Refrescar()

      cmbTiposComprobantesSalida.SelectedIndex = -1
      cmbTiposComprobantesEntrada.SelectedIndex = -1

      txtLetraSalida.Text = ""
      txtLetraEntrada.Text = ""

      txtEmisorSalida.Text = "0"
      txtEmisorEntrada.Text = "0"

      bscComprobanteSalida.Text = "0"
      bscComprobanteSalida.Selecciono = False
      bscComprobanteEntrada.Text = "0"
      bscComprobanteEntrada.Selecciono = False

      cmbTiposComprobantes.SelectedIndex = -1
      cmbCobrador.SelectedIndex = If(cmbCobrador.Items.Count = 1, 0, -1)
      cmbVendedor.SelectedIndex = If(cmbVendedor.Items.Count = 1, 0, -1)
      cmbCajas.SelectedIndex = If(cmbCajas.Items.Count = 1, 0, -1)

      dtpFecha.Value = Now

      txtTotalGastos.Text = "0.00"
      txtTotalGastosCompras.Text = "0.00"
      CalculaImporteARendir()

      If _dtDetalle IsNot Nothing Then
         _dtDetalle.Clear()
      End If

      RefrescarGrillaGastos()

   End Sub

   Private Sub RefrescarGrillaGastos()
      _gastos = New List(Of Entidades.RepartoGasto)()
      SetDataSourceGastos()
   End Sub

   Private Sub SetDataSourceGastos()
      ugGastos.DataSource = _gastos.ToArray()
      AjustarColumnasGrilla(ugGastos, _titGastos)
   End Sub


   Private Sub CargaGrillaDetalle()

      If cmbRutas.SelectedIndex < 0 Then
         cmbRutas.Focus()
         Throw New ArgumentException("Debe seleccionar una Ruta.")
      End If

      If Not bscComprobanteSalida.Selecciono Then
         bscComprobanteSalida.Focus()
         Throw New ArgumentException("Debe seleccionar el comprobante de Salida.")
      End If

      If Not bscComprobanteEntrada.Selecciono Then
         bscComprobanteEntrada.Focus()
         Throw New ArgumentException("Debe seleccionar el comprobante de Entrada.")
      End If

      Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

      Dim salida As Entidades.Venta = oVenta.GetUna(actual.Sucursal.Id,
                                                    cmbTiposComprobantesSalida.SelectedValue.ToString(),
                                                    txtLetraSalida.Text,
                                                    Short.Parse(txtEmisorSalida.Text),
                                                    Long.Parse(bscComprobanteSalida.Text))
      Dim entrada As Entidades.Venta = oVenta.GetUna(actual.Sucursal.Id,
                                                     cmbTiposComprobantesEntrada.SelectedValue.ToString(),
                                                     txtLetraEntrada.Text,
                                                     Short.Parse(txtEmisorEntrada.Text),
                                                     Long.Parse(bscComprobanteEntrada.Text))


      _totalesEntregadosPorProducto.Clear()
      AcumulaProductos(salida.VentasProductos)
      AcumulaProductos(entrada.VentasProductos)

      Dim result As Reglas.Ventas.RegistrarRepartoDatos
      'result = oVenta.GetParaRegistrarReparto(Integer.Parse(cmbRutas.SelectedValue.ToString()), idCliente:=0)
      result = oVenta.GetParaRegistrarReparto(cmbRutas.GetMovilRutas(todosVacio:=False), idCliente:=0)
      _dtDetalle = result.dtGrilla

      Dim dtTemp As DataTable = Nothing
      If TypeOf (ugDetalle.DataSource) Is DataTable Then
         dtTemp = DirectCast(ugDetalle.DataSource, DataTable)
      End If

      ugDetalle.DataSource = _dtDetalle
      RefrescarGrillaGastos()

      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("CodigoCliente").Header.VisiblePosition = 0
         .Columns("NombreCliente").Header.VisiblePosition = 1
         .Columns("Direccion").Header.VisiblePosition = 2
         .Columns("IdTipoComprobante").Header.VisiblePosition = 3
         .Columns("NombreCategoria").Header.VisiblePosition = 4
         .Columns("Comprobante").Header.VisiblePosition = 5
         Dim col As Integer = 6

         Dim columnasTotalRepartoCantidad As List(Of String) = New List(Of String)()
         Dim columnasTotalCantidad As List(Of String) = New List(Of String)()
         For Each columna As UltraGridColumn In .Columns

            If columna.Key.EndsWith("___precio") Then
               'columna.Hidden = True
               Dim nombreProducto As String = GetNombreProducto(result, columna, "___precio")
               columna.FormatearColumna(String.Format("Precio {0}", nombreProducto), col, 70, HAlign.Right, Not chbMostrarPrecios.Checked, "N2", , Activation.AllowEdit) '.CellAppearance.BackColor = Color.AntiqueWhite
            ElseIf columna.Key.EndsWith("___cantidad") Then
               columnasTotalCantidad.Add(columna.Key)
               columnasTotalRepartoCantidad.Add(columna.Key)
               Dim nombreProducto As String = GetNombreProducto(result, columna, "___cantidad")
               columna.FormatearColumna(nombreProducto, col, 70, HAlign.Right, , "N2", , Activation.AllowEdit).CellAppearance.BackColor = Color.Cyan
            ElseIf columna.Key.EndsWith("___cantidadCambio") Then
               columnasTotalCantidad.Add(columna.Key)
               Dim nombreProducto As String = "Cambio" ' GetNombreProducto(result, columna, "___cantidadCambio")
               columna.FormatearColumna(nombreProducto, col, 50, HAlign.Right, Not chbMostrarCambios.Checked, "N2", , Activation.AllowEdit).CellAppearance.BackColor = Color.GreenYellow
            End If
         Next

         .Columns("ImporteTotal").Header.VisiblePosition = col
         col += 1
         .Columns("CopiarValor").Header.VisiblePosition = col
         col += 1
         .Columns("ImportePagado").Header.VisiblePosition = col

         ugDetalle.DisplayLayout.Bands(0).Summaries.Clear()
         ugDetalle.AgregarTotalesSuma(columnasTotalCantidad.ToArray())
         ugDetalle.AgregarTotalSumaColumna("ImporteTotal")
         ugDetalle.AgregarTotalSumaColumna("ImportePagado")

         For Each columna As String In columnasTotalRepartoCantidad
            With ugDetalle.DisplayLayout.Bands(0)
               Dim summary As SummarySettings
               summary = .Summaries.Add(columna + "_Custom", SummaryType.Custom,
                                        New SummaryTotalesDesdeEntradaSalidaColumna(_totalesEntregadosPorProducto, columna),
                                        .Columns(columna), SummaryPosition.UseSummaryPositionColumn, .Columns(columna))
               summary.DisplayFormat = "{0:N2}"
               summary.Appearance.TextHAlign = HAlign.Right
               summary.Appearance.BackColor = Color.Yellow
            End With
         Next

      End With

      If dtTemp IsNot Nothing Then
         dtTemp.Dispose()
      End If

   End Sub

   Private Sub GrabarReparto()
      ugDetalle.UpdateData()
      If ValidaGrabacion() Then
         Dim rVentas As Reglas.Ventas = New Reglas.Ventas()

         Dim caja As Entidades.CajaNombre
         caja = New Reglas.CajasNombres().GetUna(actual.Sucursal.Id, Integer.Parse(cmbCajas.SelectedValue.ToString()))

         rVentas.GrabarReparto(_dtDetalle,
                               DirectCast(cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante),
                               dtpFecha.Value,
                               DirectCast(cmbFormaPago.SelectedItem, Entidades.VentaFormaPago),
                               DirectCast(cmbVendedor.SelectedItem, Entidades.Empleado),
                               DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado),
                               caja,
                               IdFuncion,
                               actual.Sucursal.Id,
                               cmbTiposComprobantesSalida.SelectedValue.ToString(),
                               txtLetraSalida.Text,
                               Integer.Parse(txtEmisorSalida.Text),
                               Long.Parse(bscComprobanteSalida.Text),
                               actual.Sucursal.Id,
                               cmbTiposComprobantesEntrada.SelectedValue.ToString(),
                               txtLetraEntrada.Text,
                               Integer.Parse(txtEmisorEntrada.Text),
                               Long.Parse(bscComprobanteEntrada.Text),
                               _totalesEntregadosPorProducto,
                               If(IsNumeric(txtTotalGastos.Text), Decimal.Parse(txtTotalGastos.Text), 0),
                               If(IsNumeric(txtTotalGastosCompras.Text), Decimal.Parse(txtTotalGastosCompras.Text), 0),
                               If(IsNumeric(txtTotalGastosCaja.Text), Decimal.Parse(txtTotalGastosCaja.Text), 0),
                               _gastos, 0, 0, 0, 0, 0, 0, 0)

         ShowMessage("Generación finalizada exitosamente.")

         Rerfescar()

      End If
   End Sub

   Private Function ValidaGrabacion() As Boolean

      If Not bscComprobanteSalida.Selecciono Then
         bscComprobanteSalida.Focus()
         ShowMessage("Debe seleccionar el comprobante de Salida.")
         Return False
      End If

      If Not bscComprobanteEntrada.Selecciono Then
         bscComprobanteEntrada.Focus()
         ShowMessage("Debe seleccionar el comprobante de Entrada.")
         Return False
      End If

      If cmbTiposComprobantes.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un tipo de comprobante.")
         cmbTiposComprobantes.Focus()
         Return False
      End If
      If cmbFormaPago.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar una forma de pago.")
         cmbFormaPago.Focus()
         Return False
      End If
      If cmbVendedor.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un Vendedor.")
         cmbVendedor.Focus()
         Return False
      End If
      If cmbCobrador.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar un Cobrador.")
         cmbCobrador.Focus()
         Return False
      End If
      If cmbCajas.SelectedIndex < 0 Then
         ShowMessage("Debe seleccionar una Caja.")
         cmbCajas.Focus()
         Return False
      End If

      '' vvvvvvvvvv  DESDE AQUÍ VALIDO LAS CANTIDADES INGRESADAS  vvvvvvvvvv
      Dim algunErrorEnCantidades As Boolean = False
      Dim stb As StringBuilder = New StringBuilder()
      'Preparo el comienzo del mensaje de error total solo se muestra si algunErrorEnCantidades
      stb.AppendLine("La cantidad ingresada de los siguientes productos no coincide con la cantidad reportada en la Entrada y Salida.")
      With ugDetalle.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            If columna.Key.EndsWith("___cantidad") Then
               Dim totalCargado As Decimal = 0
               'Busco en los totales de la grilla el total ingresado para cadea producto
               If .Summaries.Exists(columna.Key) Then
                  If IsNumeric(ugDetalle.DisplayLayout.Rows.SummaryValues(columna.Key).Value) Then
                     totalCargado += Decimal.Parse(ugDetalle.DisplayLayout.Rows.SummaryValues(columna.Key).Value.ToString())
                  End If
               End If

               Dim columnaCambio As String = String.Concat(columna.Key + "Cambio")
               'Busco en los totales de la grilla el total de cambios ingresado para cadea producto
               If .Summaries.Exists(columnaCambio) Then
                  If IsNumeric(ugDetalle.DisplayLayout.Rows.SummaryValues(columnaCambio).Value) Then
                     totalCargado += Decimal.Parse(ugDetalle.DisplayLayout.Rows.SummaryValues(columnaCambio).Value.ToString())
                  End If
               End If


               Dim idProducto As String = columna.Key.Replace("___cantidad", "")
               Dim totalProducto As Decimal = 0
               'Busco en los saldos de Salida/Entrada cuanto da el total entregado de cada producto
               If _totalesEntregadosPorProducto.ContainsKey(idProducto) Then
                  totalProducto = _totalesEntregadosPorProducto(idProducto)
               End If

               'Si difieren las cantidades, agrego el producto a los que tienen error.
               If totalCargado <> totalProducto Then
                  algunErrorEnCantidades = True
                  stb.AppendFormatLine("    {0} - {1}", idProducto, columna.Header.Caption)
               End If
            End If
         Next
      End With

      If algunErrorEnCantidades Then
         ShowMessage(stb.ToString())
         ugDetalle.Focus()
         ugDetalle.IrPrimerCeldaEditable()
         Return False
      End If
      '' ^^^^^^^^^^  HASTA AQUÍ VALIDO LAS CANTIDADES INGRESADAS  ^^^^^^^^^^

      Return True
   End Function

#Region "Métodos GetEntidad"
   Private Function GetTipoComprobanteSalida() As Entidades.TipoComprobante
      Return GetTipoComprobante(cmbTiposComprobantesSalida)
   End Function
   Private Function GetTipoComprobanteEntrada() As Entidades.TipoComprobante
      Return GetTipoComprobante(cmbTiposComprobantesEntrada)
   End Function
   Private Function GetTipoComprobante(cmb As Eniac.Controles.ComboBox) As Entidades.TipoComprobante
      If cmb.SelectedIndex > -1 AndAlso TypeOf (cmb.SelectedItem) Is Entidades.TipoComprobante Then
         Return DirectCast(cmb.SelectedItem, Entidades.TipoComprobante)
      End If
      Return Nothing
   End Function
#End Region

#Region "Métodos Busqueda Foranea"
   Private Sub PreparaGrillaComprobantes(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Comprobantes",
                                .AnchoAyuda = 712}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "IdTipoComprobante"
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
         col.Nombre = "NumeroComprobante"
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
         col.Nombre = "CodigoCliente"
         col.Titulo = "Código"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 70
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 7
         col.Nombre = "NombreCliente"
         col.Titulo = "Cliente"
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         col.Ancho = 250
         .ColumnasVisibles.Add(col)
      End With
   End Sub
   Private Sub CargarComprobante(dr As DataGridViewRow,
                                 cmbTipoComprobante As Eniac.Controles.ComboBox,
                                 txtLetra As Eniac.Controles.TextBox,
                                 txtEmisor As Eniac.Controles.TextBox,
                                 bscNumero As Eniac.Controles.Buscador2,
                                 dtpFecha As Eniac.Controles.DateTimePicker)
      cmbTipoComprobante.SelectedValue = dr.Cells("IdTipoComprobante").Value.ToString()
      txtLetra.Text = dr.Cells("Letra").Value.ToString()
      txtEmisor.Text = dr.Cells("CentroEmisor").Value.ToString()
      bscNumero.Text = dr.Cells("NumeroComprobante").Value.ToString()
      If dtpFecha IsNot Nothing AndAlso IsDate(dr.Cells("Fecha").Value) Then
         dtpFecha.Value = DateTime.Parse(dr.Cells("Fecha").Value.ToString())
      End If
      'Si cambió la entrada o salida limpio del detalle porque pueden haber diferentes productos afectados con cantidades diferentes.
      'Si se requiere cambiar este comportamiento analizar como impacta en el calculo de los totales de productos entregados.
      If _dtDetalle IsNot Nothing Then _dtDetalle.Clear()
   End Sub
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      If IsNumeric(dr.Cells("IdCliente").Value) Then
         Dim idCliente As Long = Long.Parse(dr.Cells("IdCliente").Value.ToString())
         If _dtDetalle.Select(String.Format("IdCliente = {0}", idCliente)).Length = 0 Then
            Dim oVenta As Reglas.Ventas = New Reglas.Ventas()
            Dim result As Reglas.Ventas.RegistrarRepartoDatos
            result = oVenta.GetParaRegistrarReparto({}, idCliente:=idCliente)
            _dtDetalle.ImportRowRange(result.dtGrilla.Select())
            _dtDetalle.AcceptChanges()
         Else
            For Each drGrilla As UltraGridRow In ugDetalle.DisplayLayout.Bands(0).GetRowEnumerator(GridRowType.DataRow)
               Dim idClienteGrilla As Long = 0
               If IsNumeric(drGrilla.Cells("IdCliente").Value) Then
                  idClienteGrilla = Long.Parse(drGrilla.Cells("IdCliente").Value.ToString())
               End If
               If idCliente = idClienteGrilla Then
                  ugDetalle.ActiveRow = drGrilla
                  Exit For
               End If
            Next
         End If         'If _dtDetalle.Select(String.Format("IdCliente = {0}", idCliente)).Length = 0 Then
      End If            'If IsNumeric(dr.Cells("IdCliente").Value) Then

   End Sub

   Private Sub CargarDatosCuentaDeCaja(ByVal dr As DataGridViewRow)
      Me.bscCuentaCaja.Text = dr.Cells("IdCuentaCaja").Value.ToString()
      Me.bscNombreCuentaCaja.Text = dr.Cells("NombreCuentaCaja").Value.ToString()
      Me.txtPesos.Focus()
   End Sub

#End Region

   Public Shared Function GetNombreProducto(result As Reglas.Ventas.RegistrarRepartoDatos, columna As UltraGridColumn, sufijo As String) As String
      Dim drCol As DataRow() = result.dtProductos.Select(String.Format("{1} = '{0}'", columna.Key.Replace(sufijo, ""), Entidades.Producto.Columnas.IdProducto.ToString()))
      Dim nombreProducto As String = drCol(0)(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
      If Publicos.ProductoUtilizaNombreCorto Then
         nombreProducto = drCol(0)(Entidades.Producto.Columnas.NombreCorto.ToString()).ToString()
      End If
      Return nombreProducto
   End Function
   Private Sub AcumulaProductos(ventasProductos As List(Of Entidades.VentaProducto))
      For Each vp As Entidades.VentaProducto In ventasProductos
         If Not _totalesEntregadosPorProducto.ContainsKey(vp.IdProducto) Then
            _totalesEntregadosPorProducto.Add(vp.IdProducto, vp.Cantidad)
         Else
            _totalesEntregadosPorProducto(vp.IdProducto) += vp.Cantidad
         End If
      Next
   End Sub

   Private Sub MuestraCantidadRegistros()
      Dim cantidad As Integer

      If _dtDetalle IsNot Nothing Then cantidad = _dtDetalle.Rows.Count

      MuestraCantidadRegistros(cantidad)
   End Sub
   Private Sub MuestraCantidadRegistros(cantidad As Integer)
      Me.tssRegistros.Text = String.Format("{0} Registros", cantidad)
   End Sub
#End Region

   Public Class SummaryTotalesDesdeEntradaSalidaColumna
      Implements ICustomSummaryCalculator

      Private Property TotalesPorProducto As Dictionary(Of String, Decimal)
      Private Property IdProducto As String
      Private Property Columna As String

      Public Sub New(totalesPorProducto As Dictionary(Of String, Decimal), columna As String)
         _TotalesPorProducto = totalesPorProducto
         _IdProducto = columna.Replace("___cantidad", "")
         _Columna = columna
      End Sub

      Public Sub AggregateCustomSummary(summarySettings As SummarySettings, row As UltraGridRow) Implements ICustomSummaryCalculator.AggregateCustomSummary
      End Sub

      Public Sub BeginCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) Implements ICustomSummaryCalculator.BeginCustomSummary
      End Sub

      Public Function EndCustomSummary(summarySettings As SummarySettings, rows As RowsCollection) As Object Implements ICustomSummaryCalculator.EndCustomSummary
         Dim total As Decimal = 0
         If _TotalesPorProducto.ContainsKey(IdProducto) Then
            total = _TotalesPorProducto(IdProducto)
         End If

         Dim acumulado As Decimal = CDec(rows.SummaryValues(Columna).Value)
         acumulado += CDec(rows.SummaryValues(String.Concat(Columna + "Cambio")).Value)

         If acumulado > total Then
            summarySettings.Appearance.BackColor = Color.Red
            summarySettings.Appearance.ForeColor = Color.White
         ElseIf acumulado = total Then
            summarySettings.Appearance.BackColor = Nothing
            summarySettings.Appearance.ForeColor = Nothing
         Else
            summarySettings.Appearance.BackColor = Color.Yellow
            summarySettings.Appearance.ForeColor = Nothing
         End If

         Return total
      End Function
   End Class

   Private Sub ugDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles ugDetalle.KeyDown
      Try
         If e.KeyCode = Keys.Add And e.Control And Not e.Alt And Not e.Shift Then
            Dim row As UltraGridRow = ugDetalle.ActiveRow
            row.Cells("ImportePagado").Value = row.Cells("ImporteTotal").Value
         ElseIf e.KeyCode = Keys.Add And e.Control And Not e.Alt And e.Shift Then
            For Each row As UltraGridRow In ugDetalle.DisplayLayout.Bands(0).GetRowEnumerator(GridRowType.DataRow)
               Dim importePagado As Decimal = 0
               If IsNumeric(row.Cells("ImportePagado").Value) Then importePagado = Decimal.Parse(row.Cells("ImportePagado").Value.ToString())
               If importePagado = 0 Then
                  row.Cells("ImportePagado").Value = row.Cells("ImporteTotal").Value
               End If
            Next
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            If ShowPregunta(String.Format("¿Desea eliminar el cliente {0} - {1} / {2}?",
                                          dr("CodigoCliente"), dr("NombreCliente"), dr("Direccion"))) = Windows.Forms.DialogResult.Yes Then
               dr.Delete()
               _dtDetalle.AcceptChanges()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtTotalGastos_Leave(sender As Object, e As EventArgs) Handles txtTotalGastosCompras.Leave, txtTotalGastosCaja.Leave
      Try
         CalculaImporteARendir()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CalculaImporteARendir()

      Dim totalGastosCaja As Decimal = 0
      If ugGastos.DisplayLayout.Bands(0).Summaries.Exists("ImportePesos") AndAlso
         IsNumeric(ugGastos.DisplayLayout.Rows.SummaryValues("ImportePesos").Value) Then
         totalGastosCaja = Decimal.Parse(ugGastos.DisplayLayout.Rows.SummaryValues("ImportePesos").Value.ToString())
      End If

      Dim totalGastosCompras As Decimal = If(IsNumeric(txtTotalGastosCompras.Text), Decimal.Parse(txtTotalGastosCompras.Text), 0)

      txtTotalGastosCaja.Text = totalGastosCaja.ToString("N2")
      txtTotalGastos.Text = (totalGastosCompras + totalGastosCaja).ToString("N2")
      txtTotalGastos1.Text = (totalGastosCompras + totalGastosCaja).ToString("N2")

      Dim totalPagado As Decimal = 0
      If ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("ImportePagado") AndAlso
         IsNumeric(ugDetalle.DisplayLayout.Rows.SummaryValues("ImportePagado").Value) Then
         totalPagado = Decimal.Parse(ugDetalle.DisplayLayout.Rows.SummaryValues("ImportePagado").Value.ToString())
      End If

      txtARendir.Text = (totalPagado - (totalGastosCompras + totalGastosCaja)).ToString("N2")
   End Sub

   Private Sub ugDetalle_SummaryValueChanged(sender As Object, e As SummaryValueChangedEventArgs) Handles ugDetalle.SummaryValueChanged
      Try
         CalculaImporteARendir()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtPesos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPesos.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtObservaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservaciones.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub btnInsertarGastos_Click(sender As Object, e As EventArgs) Handles btnInsertarGastos.Click
      Try
         If Not bscCuentaCaja.Selecciono And Not bscNombreCuentaCaja.Selecciono Then
            ShowMessage("Debe seleccionar una Cuenta de Caja")
            bscCuentaCaja.Focus()
            Exit Sub
         End If
         Dim importePesos As Decimal = 0
         If IsNumeric(txtPesos.Text) Then
            importePesos = Decimal.Parse(txtPesos.Text)
         End If

         If importePesos <= 0 Then
            ShowMessage("El importe debe ser mayor a cero.")
            txtPesos.Focus()
            Exit Sub
         End If

         Dim gasto As Entidades.RepartoGasto = New Entidades.RepartoGasto() _
                                                   With {.CuentaCaja = New Reglas.CuentasDeCajas().GetUna(Integer.Parse(bscCuentaCaja.Text)),
                                                         .ImportePesos = importePesos,
                                                         .Observacion = txtObservaciones.Text}
         _gastos.Add(gasto)
         SetDataSourceGastos()
         CalculaImporteARendir()
         RefrescarGastos()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnEliminarGastos_Click(sender As Object, e As EventArgs) Handles btnEliminarGastos.Click
      Try
         Dim gastoSeleccionado As Entidades.RepartoGasto = ugGastos.FilaSeleccionada(Of Entidades.RepartoGasto)()
         If gastoSeleccionado IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar el gasto seleccionado?") = Windows.Forms.DialogResult.Yes Then
               EliminarGasto(gastoSeleccionado)
            End If
         Else
            ShowMessage("Debe seleccionar un gasto a eliminar.")
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub EliminarGasto(gastoSeleccionado As Entidades.RepartoGasto)
      _gastos.Remove(gastoSeleccionado)
      SetDataSourceGastos()
      CalculaImporteARendir()
   End Sub

   Private Sub RefrescarGastos()
      bscCuentaCaja.Text = String.Empty
      bscNombreCuentaCaja.Text = String.Empty
      txtPesos.Text = "0.00"
      txtObservaciones.Text = String.Empty

      bscCuentaCaja.Focus()
   End Sub

   Private Sub ugGastos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugGastos.DoubleClickRow
      Try
         Dim gastoSeleccionado As Entidades.RepartoGasto = ugGastos.FilaSeleccionada(Of Entidades.RepartoGasto)()
         If gastoSeleccionado IsNot Nothing Then
            bscCuentaCaja.Text = gastoSeleccionado.IdCuentaCaja.ToString()
            bscCuentaCaja.PresionarBoton()
            txtPesos.Text = gastoSeleccionado.ImportePesos.ToString("N2")
            txtObservaciones.Text = gastoSeleccionado.Observacion
            txtPesos.Focus()
            EliminarGasto(gastoSeleccionado)
         Else
            ShowMessage("Debe seleccionar un gasto a modificar.")
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnRefrescarGastos_Click(sender As Object, e As EventArgs) Handles btnRefrescarGastos.Click
      Try
         RefrescarGastos()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub CambiarComprobanteFact()
      Try
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()

         If dr Is Nothing Then
            Throw New Exception("Debe seleccionar una fila.")
         End If

         Me.Cursor = Cursors.WaitCursor

         Using mr As RepartoCambiarTipoComprobante = New RepartoCambiarTipoComprobante()
            mr.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            mr.DescripcionComprobante = dr("Comprobante").ToString()
            mr.NombreCliente = dr("NombreCliente").ToString()
            mr.Direccion = dr("direccion").ToString()
            mr.IdCategoria = Integer.Parse(dr("IdCategoria").ToString())
            mr.NombreCategoria = dr("NombreCategoria").ToString()

            If mr.ShowDialog() = Windows.Forms.DialogResult.Cancel Then Return

            ModificaTipoComprobante(GetRowsParaModificar(mr.CambioMasivoReparto, mr.ModificaTipoComprobante), mr.IdTipoComprobante, mr.DescripcionComprobante, mr.ModificaTipoComprobante)

            ModificaCategoria(GetRowsParaModificar(mr.CambioMasivoRepartoCat, mr.ModificaCategoria), mr.IdCategoria, mr.NombreCategoria, mr.ModificaCategoria)


            MessageBox.Show("Comprobante a generar modificada Exitosamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Using


      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function GetRowsParaModificar(cambioMasivo As ModoCambioMasivoReparto, cambia As Boolean) As DataRow()
      ugDetalle.UpdateData()
      If cambia Then
         If cambioMasivo = ModoCambioMasivoReparto.SoloActual Then
            Return New DataRow() {DirectCast(Me.ugDetalle.ActiveRow.ListObject, DataRowView).Row}
         ElseIf cambioMasivo = ModoCambioMasivoReparto.Todos Then
            Dim list As New List(Of DataRow)
            For Each dr As UltraGridRow In ugDetalle.Rows

               list.Add(DirectCast(dr.ListObject, DataRowView).Row)
            Next
            Return list.ToArray()
         End If
      End If
      Return Nothing
   End Function
   Public Enum ModoCambioMasivoReparto As Integer
      <Description("Solo Actual")>
      SoloActual = 0
      Todos = 1
   End Enum
   Private Sub ModificaTipoComprobante(filas As DataRow(), idTipoComprobante As String, descripcionComprobante As String, cambia As Boolean)
      If cambia Then
         For Each drSelec As DataRow In filas
            drSelec("IdTipoComprobante") = idTipoComprobante
            drSelec("Comprobante") = descripcionComprobante
         Next
         ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub

   Private Sub ModificaCategoria(filas As DataRow(), idCategoria As Integer, NombreCategoria As String, cambia As Boolean)
      If cambia Then
         For Each drSelec As DataRow In filas
            drSelec("IdCategoria") = idCategoria
            drSelec("NombreCategoria") = NombreCategoria
         Next
         ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub

   Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
      Try
         CambiarComprobanteFact()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class