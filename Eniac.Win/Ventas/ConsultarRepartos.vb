#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
#End Region
Public Class ConsultarRepartos

#Region "Campos"

   Private _publicos As Publicos
   Private _filtros As List(Of Entidades.Venta)
   Private _CantidadAgregados As Integer
   Private _Comprobantes As DataTable
   Private _Transportista As Entidades.Transportista
   Private _titGastos As Dictionary(Of String, String)

   Private dtDetalle As DataTable
   Private dtProducto As DataTable
   Private dtProductoConsolidado As DataTable
   Private _reparto As Entidades.Reparto
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()
         Me._filtros = New List(Of Entidades.Venta)()


         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         'Tengo que hacerlo en el Insertar porque da error... no entiendo porque no existe las columnas!!
         'Me.CargarColumnasASumar()

         'Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
         Me.ugProductos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton

         Me.ugProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

         ugDetalle.AgregarFiltroEnLinea({"NombreTransportista"})

         tbcDetalle.SelectedTab = tbpComprobantes
         ugComprobantes.AgregarTotalesSuma({"ImporteTotal"})
         ugComprobantes.AgregarFiltroEnLinea({"NombreCliente", "NombreVendedor"})

         tbcDetalle.SelectedTab = tbpProductos
         ugProductos.AgregarTotalesSuma({"Kilos", "Cantidad", "Retornable"})
         ugProductos.AgregarFiltroEnLinea({"NombreProducto"})

         Dim funcion As Entidades.Funcion = New Reglas.Funciones().GetUna("RegistrarReparto", cargaDocumentos:=False, cargaVinculadas:=False, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

         If funcion IsNot Nothing Then
            If funcion.Enabled Then
               tbcDetalle.SelectedTab = tbpConsolidadoPorModelo
               ugConsolidadoPorModelo.AgregarTotalesSuma({"ImporteTotal", "ImportePagado"})
               ugConsolidadoPorModelo.AgregarFiltroEnLinea({"NombreCliente", "Direccion"})

               tbcDetalle.SelectedTab = tbpGastos
               ugGastos.AgregarTotalesSuma({"ImportePesos"})
               ugGastos.AgregarFiltroEnLinea({"NombreCuentaCaja", "Observacion"})
               _titGastos = GetColumnasVisiblesGrilla(ugGastos)
            Else
               Me.tbcDetalle.TabPages.Remove(tbpConsolidadoPorModelo)
               Me.tbcDetalle.TabPages.Remove(tbpGastos)
            End If
         Else
            Me.tbcDetalle.TabPages.Remove(tbpConsolidadoPorModelo)
            Me.tbcDetalle.TabPages.Remove(tbpGastos)
         End If

         Dim existeOrganizarEntrega As Boolean = New Reglas.Funciones().FuncionHabilitada("OrganizarEntregasV2")

         Me.tsddListadoClientes.Visible = existeOrganizarEntrega
         Me.tsddConsolidados.Visible = existeOrganizarEntrega
         'Me.tsbConsolidadoCargaTipoOperacion.Visible = existeOrganizarEntrega


         tbcDetalle.SelectedTab = tbpProductosSinDescargo
         ugvProductosSinDescargar.AgregarFiltroEnLinea({"NombreProducto"})

         tbcDetalle.SelectedTab = tbpDetalle

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarRepartos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugProductos.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraPrintPreviewDialog1.Name = Me.Text
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")
         Me.UltraGridPrintDocument1.FitWidthToPages = 1  'Fuerzo el Ancho en uno por la observacion, tal vez haya que quitar ese campo.

         If Me.tbcDetalle.SelectedTab Is tbpComprobantes Then
            ugComprobantes.Font = New Font("Microsoft Sans Serif", 10)
         End If

         Me.UltraGridPrintDocument1.Grid = GetGrillaImprimirExportar()
         Me.UltraPrintPreviewDialog1.ShowDialog()

         If Me.tbcDetalle.SelectedTab Is tbpComprobantes Then
            ugComprobantes.Font = New Font("Microsoft Sans Serif", 8)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try

         Dim defaultFileName As String = String.Format("{0}.xls", Me.Name)
         Dim Titulo As String = String.Format("{0}", Me.Text)
         If Me.tbcDetalle.SelectedTab Is tbpConsolidadoPorModelo Then
            Dim excelExport As UltraGridExportarExcel = New UltraGridExportarExcel(UltraGridExcelExporter1, String.Empty)
            excelExport.Exportar(defaultFileName,
                                 {New UltraGridExportTituloGrilla() With {.Grilla = ugConsolidadoPorModelo, .NombreHoja = "Productos"},
                                  New UltraGridExportTituloGrilla() With {.Grilla = ugGastos, .NombreHoja = "Gastos"}},
                                  String.Empty)
         Else
            GetGrillaImprimirExportar().Exportar(defaultFileName, Titulo, UltraGridExcelExporter1, CargarFiltrosImpresion())
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Dim defaultFileName As String = String.Format("{0}.pdf", Me.Name)
         Dim Titulo As String = String.Format("{0}", Me.Text)
         If Me.tbcDetalle.SelectedTab Is tbpConsolidadoPorModelo Then
            Dim pdfExport As UltraGridExportarPDF = New UltraGridExportarPDF(UltraGridDocumentExporter1, String.Empty)
            pdfExport.Exportar(defaultFileName,
                               {New UltraGridExportTituloGrilla() With {.Grilla = ugConsolidadoPorModelo, .NombreHoja = "Productos"},
                                New UltraGridExportTituloGrilla() With {.Grilla = ugGastos, .NombreHoja = "Gastos"}},
                                String.Empty)
         Else
            GetGrillaImprimirExportar().Exportar(defaultFileName, Titulo, UltraGridDocumentExporter1, CargarFiltrosImpresion())
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Not Me.tbcDetalle.SelectedTab Is tbpDetalle Then
            .AppendFormat(" Número Reparto: {0} - ", Me.ugDetalle.ActiveRow.Cells("NumeroReparto").Value.ToString())
         End If


         If Me.chbTransportista.Checked Then
            .AppendFormat(" Transportista: {0} - ", Me.bscTransportista.Text)
         End If

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If

         If Me.chbFormaPago.Checked Then
            .AppendFormat(" Forma de Pago: {0} - ", Me.cmbFormaPago.Text)
         End If

         If Me.chbTipoComprobante.Checked Then
            .AppendFormat(" Tipo de Comprobante: {0} - ", Me.cmbTiposComprobantes.Text)
         End If

         If Me.chbUsuario.Checked Then
            .AppendFormat(" Usuario: {0} - ", Me.cmbUsuario.Text)
         End If

         If Me.chbNumero.Checked Then
            .AppendFormat(" Número Reparto: {0} - ", Me.txtNumero.Text)
         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantes.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
         Me.bscCliente.Enabled = Me.chbCliente.Checked

         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty

         Me.bscCodigoCliente.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
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
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
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

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Try
         Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

         If Not Me.chbVendedor.Checked Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            If Me.cmbVendedor.Items.Count > 0 Then
               Me.cmbVendedor.SelectedIndex = 0
            End If
         End If

         Me.cmbVendedor.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFormaPago.CheckedChanged

      Try
         Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

         If Not Me.chbFormaPago.Checked Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me.cmbFormaPago.Items.Count > 0 Then
               Me.cmbFormaPago.SelectedIndex = 0
            End If
         End If

         Me.cmbFormaPago.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbTransportista.Checked And Not Me.bscTransportista.Selecciono Then
            MessageBox.Show("No seleccionó un Transportista aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscTransportista.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then

            Me.ugDetalle.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.dtpDesde.Focus()

            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugProductos.Rows.ExpandAll(True)
      Else
         Me.ugProductos.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate

      If Me.ugDetalle.Rows.Count = 0 Then
         Exit Sub
      Else
         'Me.tbcDetalle.SelectedTab = Me.tbpProductos
         Me.optOrdenarPorNombre.Checked = True
         If Not Me.ugProductos.DataSource Is Nothing Then
            DirectCast(Me.ugProductos.DataSource, DataTable).Rows.Clear()
         End If

         ' Me.tbcDetalle.SelectedTab = Me.tbpComprobantes
         If Not Me.ugComprobantes.DataSource Is Nothing Then
            DirectCast(Me.ugComprobantes.DataSource, DataTable).Rows.Clear()
         End If

         Me.chkExpandAll.Checked = False
         Me.chkExpandAll.Enabled = False
      End If

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim dt As DataTable = Me.CrearDT2()
         Dim drCl As DataRow = Nothing
         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()
         Me._Comprobantes = oVenta.GetConsolidadoComprobantePorReparto(actual.Sucursal.IdSucursal, Integer.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroReparto").Value.ToString()), 0)

         For Each dr As DataRow In Me._Comprobantes.Rows
            drCl = dt.NewRow()

            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("TipoComprobante") = dr("DescripcionAbrev").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("Direccion") = dr("Direccion").ToString()
            drCl("FormaDePago") = dr("FormaDePago").ToString()
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("Usuario") = dr("Usuario").ToString()
            drCl("Observacion") = dr("Observacion").ToString()

            dt.Rows.Add(drCl)
         Next

         Me.ugComprobantes.DataSource = dt

         Me.CargaGrillaProductos()

         If Me.tbcDetalle.TabPages.Contains(Me.tbpConsolidadoPorModelo) Then
            CargaGastos()
            CargaConsolidadoPorModelo()
         End If

         CagarResumen()
         CagarProductosSinDescargo()

         'MessageBox.Show("Se detallaron los Comprobantes y Productos ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargaGastos()
      Dim drReparto As DataRow = GetRepartoRow()
      If drReparto IsNot Nothing Then
         Dim idReparto As Integer = Integer.Parse(drReparto("NumeroReparto").ToString())

         Dim dtRepartoGastos As DataTable = New Reglas.RepartosGastos().GetAll(actual.Sucursal.Id, idReparto)
         Dim drFacturaCompra As DataRow = dtRepartoGastos.NewRow()

         drFacturaCompra("NombreCuentaCaja") = "TOTAL COMPROBANTES DE COMPRA"
         drFacturaCompra("ImportePesos") = 0

         Dim dtReparto As DataTable = New Reglas.Repartos().Get1(actual.Sucursal.Id, idReparto)
         If dtReparto.Rows.Count > 0 Then
            drFacturaCompra("ImportePesos") = dtReparto.Rows(0)("TotalGastosCompras")
         End If

         dtRepartoGastos.Rows.InsertAt(drFacturaCompra, 0)

         ugGastos.DataSource = dtRepartoGastos
         AjustarColumnasGrilla(ugGastos, _titGastos)

      End If
   End Sub
   Private Sub CagarResumen()
      Dim drReparto As DataRow = GetRepartoRow()
      If drReparto IsNot Nothing Then
         Dim mostrar As Func(Of DataRow, String, String) = Function(dr, col)
                                                              Return If(IsNumeric(dr(col).ToString()), Decimal.Parse(dr(col).ToString()), 0).ToString("N2")
                                                           End Function
         Me.txtTotalEfectivo.Text = mostrar(drReparto, "TotalResumenEfectivo")
         Me.txtTotalNC.Text = mostrar(drReparto, "TotalResumenNCred")
         Me.txttotalCheque.Text = mostrar(drReparto, "TotalResumenCheques")
         Me.txttotalCC.Text = mostrar(drReparto, "TotalResumenCtaCte")
         Me.txtTotalReenvios.Text = mostrar(drReparto, "TotalResumenReenvio")
         Me.txtTotalComprobantes.Text = mostrar(drReparto, "TotalResumenComprobante")
         Me.txtTotalSubtotales.Text = mostrar(drReparto, "TotalResumenSaldoGeneral")
         Me.txtTotalTransferencia.Text = mostrar(drReparto, "TotalResumenTransferencia")

      End If
   End Sub

   Private Sub CagarProductosSinDescargo()
      Dim drReparto As DataRow = GetRepartoRow()
      If drReparto IsNot Nothing Then
         Dim idReparto As Integer = Integer.Parse(drReparto("NumeroReparto").ToString())
         Dim rProductosSinDescargar As Reglas.RepartosProductosSinDescargar = New Reglas.RepartosProductosSinDescargar
         ugvProductosSinDescargar.DataSource = rProductosSinDescargar.GetAll(actual.Sucursal.Id, idReparto)
      End If
   End Sub
   Private Sub CargaConsolidadoPorModelo()
      Dim drReparto As DataRow = GetRepartoRow()
      If drReparto IsNot Nothing Then
         Dim idReparto As Integer = Integer.Parse(drReparto("NumeroReparto").ToString())
         Dim result As Reglas.Ventas.RegistrarRepartoDatos
         result = New Reglas.Repartos().GetConsolidadPorModelo(actual.Sucursal.Id, idReparto)
         If result.dtGrilla IsNot Nothing Then
            ugConsolidadoPorModelo.DataSource = result.dtGrilla

            With ugConsolidadoPorModelo.DisplayLayout.Bands(0)
               .Columns("CodigoCliente").Header.VisiblePosition = 0
               .Columns("NombreCliente").Header.VisiblePosition = 1
               .Columns("Direccion").Header.VisiblePosition = 2

               Dim col As Integer = 3

               Dim columnasTotalRepartoCantidad As List(Of String) = New List(Of String)()
               Dim columnasTotalCantidad As List(Of String) = New List(Of String)()
               For Each columna As UltraGridColumn In .Columns

                  If columna.Key.EndsWith("___precio") Then
                     'columna.Hidden = True
                     Dim nombreProducto As String = RegistrarReparto.GetNombreProducto(result, columna, "___precio")
                     columna.FormatearColumna(String.Format("Precio {0}", nombreProducto), col, 70, HAlign.Right, , "N2") '.CellAppearance.BackColor = Color.AntiqueWhite
                  ElseIf columna.Key.EndsWith("___cantidad") Then
                     columnasTotalCantidad.Add(columna.Key)
                     columnasTotalRepartoCantidad.Add(columna.Key)
                     Dim nombreProducto As String = RegistrarReparto.GetNombreProducto(result, columna, "___cantidad")
                     columna.FormatearColumna(nombreProducto, col, 70, HAlign.Right, , "N2").CellAppearance.BackColor = Color.Cyan
                  ElseIf columna.Key.EndsWith("___cantidadCambio") Then
                     columnasTotalCantidad.Add(columna.Key)
                     Dim nombreProducto As String = "Cambio" ' GetNombreProducto(result, columna, "___cantidadCambio")
                     columna.FormatearColumna(nombreProducto, col, 50, HAlign.Right, , "N2").CellAppearance.BackColor = Color.GreenYellow
                  End If
               Next

               .Columns("ImporteTotal").Header.VisiblePosition = col
               col += 1
               .Columns("CopiarValor").Header.VisiblePosition = col
               col += 1
               .Columns("ImportePagado").Header.VisiblePosition = col

               'ugDetalle.DisplayLayout.Bands(0).Summaries.Clear()
               ugConsolidadoPorModelo.AgregarTotalesSuma(columnasTotalCantidad.ToArray())
               ugConsolidadoPorModelo.AgregarTotalSumaColumna("ImporteTotal")
               ugConsolidadoPorModelo.AgregarTotalSumaColumna("ImportePagado")

               'For Each columna As String In columnasTotalRepartoCantidad
               '   With ugDetalle.DisplayLayout.Bands(0)
               '      Dim summary As SummarySettings
               '      summary = .Summaries.Add(columna + "_Custom", SummaryType.Custom,
               '                               New RegistrarReparto.SummaryTotalesDesdeEntradaSalidaColumna(_totalesEntregadosPorProducto, columna),
               '                               .Columns(columna), SummaryPosition.UseSummaryPositionColumn, .Columns(columna))
               '      summary.DisplayFormat = "{0:N2}"
               '      summary.Appearance.TextHAlign = HAlign.Right
               '      summary.Appearance.BackColor = Color.Yellow
               '   End With
               'Next

            End With
         End If


      End If
   End Sub

   Private Function GetRepartoRow() As DataRow
      Return ugDetalle.FilaSeleccionada(Of DataRow)()
   End Function

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         If e.Cell.Column.Key = "Ver" Then
            If dtProducto Is Nothing OrElse dtProducto.Rows.Count = 0 Then Exit Sub
            Dim drReparto As DataRow = GetRepartoRow()
            If drReparto IsNot Nothing Then

               Me.Cursor = Cursors.WaitCursor

               Dim NroReparto As Integer = Integer.Parse(drReparto("NumeroReparto").ToString())
               Dim Transportista As String = drReparto("NombreTransportista").ToString()
               Dim FechaEnvio As DateTime = DateTime.Parse(drReparto("FechaEnvio").ToString())

               Dim importe As ImpresionReparto = New ImpresionReparto(Text)
               importe.Imprimir(dtProducto, NroReparto, Transportista, FechaEnvio, optOrdenarPorCodigo.Checked)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscTransportista_BuscadorClick() Handles bscTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscTransportista)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         Me.bscTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscTransportista.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub bscTransportista_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      Try
         Me.bscTransportista.Enabled = Me.chbTransportista.Checked

         If Not Me.chbTransportista.Checked Then
            Me.bscTransportista.Text = ""
         End If

         Me.bscTransportista.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub Imprimir(ds As dtsRegistracionPagos.RecibosDataTable, detallado As Boolean)

      ' # Parámetros del RDLC
      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))

      '# Resolver Informe Personalizado
      Dim reporte As Entidades.InformePersonalizadoResuelto
      Dim strReporte As String = String.Empty
      Dim frmImprime As VisorReportes

      ' Resolver si el cliente tiene informe personalizado
      reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.RegistracionPagosResumenDetallado, "Eniac.Win.ResumenDetallado.rdlc")

      frmImprime = New VisorReportes(reporte.NombreArchivo, "dtsRecibos", ds, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias
      frmImprime.Text = Me.Text
      frmImprime.WindowState = FormWindowState.Maximized
      frmImprime.ShowDialog()

      Me.Cursor = Cursors.Default

   End Sub

   Private Sub ImprimirDetallado()

      Dim nroReparto As Integer = 0
      If Me.ugDetalle.ActiveRow Is Nothing Then Exit Sub

      nroReparto = CInt(Me.ugDetalle.ActiveRow.Cells("NumeroReparto").Value)

      '# Me traigo todos los recibos cobrados en el reparto
      Dim rRepartosCobranzasComprobantes As Reglas.RepartosCobranzasComprobantes = New Reglas.RepartosCobranzasComprobantes
      Dim dt As DataTable = rRepartosCobranzasComprobantes.ObtenerRecibosDetallado(nroReparto)

      '# Cargo el dataset con los reicbos para luego imprimirlo como resumen detallado
      Dim ds As dtsRegistracionPagos.RecibosDataTable = New dtsRegistracionPagos.RecibosDataTable
      Dim dr As dtsRegistracionPagos.RecibosRow

      For Each row As DataRow In dt.Rows
         dr = ds.NewRecibosRow()
         dr.IdSucursal = row.Field(Of Integer)("IdSucursal")
         dr.IdReparto = row.Field(Of Integer)("IdReparto")
         dr.Orden = row.Field(Of Integer)("Orden")
         dr.IdTipoComprobanteRec = row.Field(Of String)("IdTipoComprobanteRecibo")
         dr.CentroEmisorRec = row.Field(Of Integer)("CentroEmisorRecibo")
         dr.LetraRec = row.Field(Of String)("LetraRecibo")
         dr.NumeroComprobanteRec = row.Field(Of Long)("NumeroComprobanteRecibo")
         dr.ImporteTotalRec = row.Field(Of Decimal)("ImporteTotalRecibo")
         dr.IdSucursalRec = row.Field(Of Integer)("IdSucursalRecibo")
         dr.CodigoCliente = row.Field(Of Long)("IdCliente")
         dr.NombreCliente = row.Field(Of String)("NombreCliente")
         dr.FormaPago = ""
         dr.Observacion = row.Field(Of String)("Observacion")

         ds.AddRecibosRow(dr)
      Next

      '# Imprimo
      Me.Imprimir(ds, detallado:=True)

   End Sub

   Private Sub CargarColumnasASumar()

      If Me.ugComprobantes.DisplayLayout.Bands(0).Summaries.Count = 0 Then

         Me.ugComprobantes.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugComprobantes.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugComprobantes.DisplayLayout.Bands(0).Columns("ImporteTotal")
         Dim summary1 As SummarySettings = Me.ugComprobantes.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Me.ugComprobantes.DisplayLayout.Bands(0).SummaryFooterCaption = "Total:"

      End If

      If Me.ugProductos.DisplayLayout.Bands(0).Summaries.Count = 0 Then

         Me.ugProductos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugProductos.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize3 As UltraGridColumn = Me.ugProductos.DisplayLayout.Bands(0).Columns("Kilos")
         Dim summary3 As SummarySettings = Me.ugProductos.DisplayLayout.Bands(0).Summaries.Add("Kilos", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:N2}"
         summary3.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize4 As UltraGridColumn = Me.ugProductos.DisplayLayout.Bands(0).Columns("Cantidad")
         Dim summary4 As SummarySettings = Me.ugProductos.DisplayLayout.Bands(0).Summaries.Add("Cantidad", SummaryType.Sum, columnToSummarize4)
         summary4.DisplayFormat = "{0:N2}"
         summary4.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize5 As UltraGridColumn = Me.ugProductos.DisplayLayout.Bands(0).Columns("Retornable")
         Dim summary5 As SummarySettings = Me.ugProductos.DisplayLayout.Bands(0).Summaries.Add("Retornable", SummaryType.Sum, columnToSummarize5)
         summary5.DisplayFormat = "{0:N2}"
         summary5.Appearance.TextHAlign = HAlign.Right

         Me.ugProductos.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

      End If

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbNumero.Checked = False
      Me.chbCliente.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbFormaPago.Checked = False
      Me.chbTransportista.Checked = False

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      'Limpio las Grillas.

      Me.tbcDetalle.SelectedTab = Me.tbpProductos
      Me.optOrdenarPorNombre.Checked = True
      If Not Me.ugProductos.DataSource Is Nothing Then
         DirectCast(Me.ugProductos.DataSource, DataTable).Rows.Clear()
      End If

      Me.tbcDetalle.SelectedTab = Me.tbpComprobantes
      If Not Me.ugComprobantes.DataSource Is Nothing Then
         DirectCast(Me.ugComprobantes.DataSource, DataTable).Rows.Clear()
      End If

      Me.tbcDetalle.SelectedTab = Me.tbpDetalle
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugvProductosSinDescargar.DataSource Is Nothing Then
         DirectCast(Me.ugvProductosSinDescargar.DataSource, DataTable).Rows.Clear()
      End If

      _reparto = Nothing
      Me.txttotalCC.Text = "0.00"
      Me.txttotalCheque.Text = "0.00"
      Me.txtTotalComprobantes.Text = "0.00"
      Me.txtTotalEfectivo.Text = "0.00"
      Me.txtTotalNC.Text = "0.00"
      Me.txtTotalReenvios.Text = "0.00"
      Me.txtTotalSubtotales.Text = "0.00"
      Me.txtTotalTransferencia.Text = "0.00"


      Me._filtros.Clear()

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

         Dim totalNeto As Decimal = 0
         Dim totalImpuestos As Decimal = 0
         Dim total As Decimal = 0

         Dim idCliente As Long = 0
         Dim idTransportista As Integer = 0

         Dim idTipoComprobante As String = String.Empty
         Dim numeroReparto As Long = 0

         Dim IdVendedor As Integer = 0

         Dim idFormasPago As Integer = 0
         Dim idUsuario As String = String.Empty

         If Me.bscCodigoCliente.Text.Length > 0 Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            idTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.chbNumero.Checked Then
            numeroReparto = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbFormaPago.Enabled Then
            idFormasPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.cmbUsuario.Enabled Then
            idUsuario = Me.cmbUsuario.SelectedValue.ToString()
         End If

         If Me.bscTransportista.Enabled Then
            idTransportista = Me._Transportista.idTransportista
         End If

         'Dim dtDetalle As DataTable

         dtDetalle = oVenta.GetRepartos({actual.Sucursal},
                                        Me.dtpDesde.Value, Me.dtpHasta.Value,
                                        IdVendedor,
                                        idCliente,
                                        idTipoComprobante,
                                        numeroReparto,
                                        idFormasPago,
                                        idUsuario,
                                        idEstadoComprobante:="",
                                        porcUtilidadDesde:=Nothing,
                                        porcUtilidadHasta:=Nothing,
                                        esComercial:=Entidades.Publicos.SiNoTodos.TODOS,
                                        idCategoria:=0,
                                        idTransportista:=idTransportista)


         Me.ugDetalle.DataSource = dtDetalle

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargaGrillaProductos()

      Try
         dtProducto = OrganizarRepartos.CrearDT2
         dtProductoConsolidado = OrganizarRepartos.CrearDT3()


         Dim rVentasProductos As Reglas.VentasProductos = New Reglas.VentasProductos()
         rVentasProductos.FillDetalleParaOrganizarRepartos(_Comprobantes, dtProducto)


         Dim drProducto As DataRow
         Dim drCol As DataRow()

         For Each drTempProductos As DataRow In dtProducto.Rows

            drCol = dtProductoConsolidado.Select(String.Format("IdProducto = '{0}'", drTempProductos("IdProducto")))

            If drCol.Length > 0 Then
               drProducto = drCol(0)
            Else
               drProducto = dtProductoConsolidado.NewRow()
               drProducto("NombreMarca") = drTempProductos("NombreMarca")
               drProducto("NombreRubro") = drTempProductos("NombreRubro")
               drProducto("IdProducto") = drTempProductos("IdProducto")
               drProducto("NombreProducto") = drTempProductos("NombreProducto")
               drProducto("Cantidad") = 0
               drProducto("Retornable") = 0
               drProducto("Kilos") = 0
               dtProductoConsolidado.Rows.Add(drProducto)
            End If

            drProducto("Cantidad") = Decimal.Parse(drProducto("Cantidad").ToString()) + Decimal.Parse(drTempProductos("Cantidad").ToString())
            If Boolean.Parse(drTempProductos("EsRetornable").ToString()) Then
               drProducto("Retornable") = Decimal.Parse(drProducto("Retornable").ToString()) + Decimal.Parse(drTempProductos("Cantidad").ToString())
            End If
            drProducto("Kilos") = Decimal.Parse(drProducto("Kilos").ToString()) + Decimal.Parse(drTempProductos("Kilos").ToString())
         Next

         Me.ugProductos.DataSource = dtProductoConsolidado

         Me.CargarColumnasASumar()

         Me.chkExpandAll.Enabled = (Me.ugProductos.Rows.Count > 0)
         Me.chkExpandAll.Checked = (Me.ugProductos.Rows.Count > 0)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT2() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         '.Columns.Add("ImporteTotalNeto", System.Type.GetType("System.Decimal"))
         '.Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Private Function GetGrillaImprimirExportar() As UltraGrid
      If Me.tbcDetalle.SelectedTab Is tbpComprobantes Then
         Return Me.ugComprobantes
      ElseIf Me.tbcDetalle.SelectedTab Is tbpProductos Then
         Return Me.ugProductos
      ElseIf Me.tbcDetalle.SelectedTab Is tbpConsolidadoPorModelo Then
         Return Me.ugConsolidadoPorModelo
      ElseIf Me.tbcDetalle.SelectedTab Is tbpGastos Then
         Return Me.ugGastos
      ElseIf Me.tbcDetalle.SelectedTab Is tbpProductosSinDescargo Then
         Return Me.ugvProductosSinDescargar
      Else
         Return Me.ugDetalle
      End If
   End Function

   Private Sub CargarDatosTransportista(ByVal dr As DataGridViewRow)
      Me.bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
      Dim Transp As Reglas.Transportistas = New Reglas.Transportistas()
      Me._Transportista = Transp.GetUno(Long.Parse(dr.Cells("IdTransportista").Value.ToString()))
   End Sub

#End Region

   Private Sub cmdImprimirResumen_Click(sender As Object, e As EventArgs) Handles cmdImprimirResumen.Click
      Try
         If ugDetalle.ActiveRow Is Nothing Then Exit Sub
         Dim row As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()

         Dim Filtros As String = String.Empty
         Dim nroReparto As Integer = 0
         Dim Distribucion As Integer = 0
         Dim localidad As String = String.Empty
         Dim cl As Reglas.OrganizarEntregas = New Reglas.OrganizarEntregas()

         Filtros = " Resp. de Distribución: " & row.Field(Of String)("NombreTransportista") & " -- "

         Filtros = Filtros + " Nro. Reparto: " & row.Field(Of Integer)("NumeroReparto") & " -- "

         Me.Cursor = Cursors.WaitCursor

         Filtros = Filtros + " Fecha Hasta: " & Me.dtpHasta.Text

         Dim dt As New DataTable
         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EFECTIVO", txtTotalEfectivo.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CTACTE", txttotalCC.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CHEQUES", txttotalCheque.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NC", txtTotalNC.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TRANSFERENCIA", txtTotalTransferencia.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("REENVIOS", txtTotalReenvios.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TOTAL", (CDec(txtTotalEfectivo.Text) +
                                                                             CDec(txttotalCC.Text) +
                                                                             CDec(txttotalCheque.Text) +
                                                                             CDec(txtTotalNC.Text) +
                                                                             CDec(txtTotalTransferencia.Text) +
                                                                             CDec(txtTotalReenvios.Text)).ToString("N2")))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Resumen.rdlc", "", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.ShowDialog()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbListadoClientesConEnvases_Click(sender As Object, e As EventArgs) Handles tsbListadoClientesConEnvases.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         ImprimirListadoCliente(Sub(filtros As String,
                                    idSucursal As Integer,
                                    fechaDesde As DateTime, fechaHasta As DateTime,
                                    numeroReparto As Integer, numeroRepartoHasta As Integer,
                                    idTransportista As Integer,
                                    IdVendedor As Integer,
                                    titulo As String)
                                   Dim impresion As New ImprimirRepartosListadoDeClientes()
                                   impresion.ImprimirConEnvases(filtros, idSucursal, fechaDesde, fechaHasta, numeroReparto, numeroRepartoHasta, idTransportista, IdVendedor, titulo)
                                End Sub)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbListadoClientes_Click(sender As Object, e As EventArgs) Handles tsbListadoClientes.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         ImprimirListadoCliente(Sub(filtros As String,
                                    idSucursal As Integer,
                                    fechaDesde As DateTime, fechaHasta As DateTime,
                                    numeroReparto As Integer, numeroRepartoHasta As Integer,
                                    idTransportista As Integer,
                                    IdVendedor As Integer,
                                    titulo As String)
                                   Dim impresion As New ImprimirRepartosListadoDeClientes()
                                   impresion.Imprimir(filtros, idSucursal, fechaDesde, fechaHasta, numeroReparto, numeroRepartoHasta, idTransportista, IdVendedor, titulo)
                                End Sub)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ImprimirListadoCliente(imprimir As Action(Of String, Integer, DateTime, DateTime, Integer, Integer, Integer, Integer, String))

      If ugDetalle.ActiveRow IsNot Nothing AndAlso
            ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then

         Me.Cursor = Cursors.WaitCursor

         Dim dr As DataRow = DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row
         'Dim fechaDesde As DateTime = CDate(dr("FechaEnvio")).Date
         Dim idSucursal As Integer = dr.ValorNumericoPorDefecto("IdSucursal", 0I)
         Dim numeroReparto As Integer = dr.ValorNumericoPorDefecto("NumeroReparto", 0I)

         Dim filtros As String = String.Empty
         Dim IdTransportista As Integer = 0
         Dim IdVendedor As Integer = 0

         If Me.bscTransportista.Enabled AndAlso Me.bscTransportista.Tag IsNot Nothing Then
            IdTransportista = CInt(Me.bscTransportista.Tag)
            filtros = filtros + " Resp. de Distribución: " & Me.bscTransportista.Text & " -- "
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
            filtros = filtros + " Vendedor: " & DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).NombreEmpleado & " -- "
         End If

         filtros = filtros + " Nro. Reparto: " & numeroReparto & " -- "


         filtros = filtros + " Fecha de envío: desde el " & dtpDesde.Value.ToString() & " hasta el " & dtpHasta.Value.ToString()

         imprimir(filtros, idSucursal, Nothing, Nothing, numeroReparto, numeroReparto, IdTransportista, IdVendedor, Me.Text)
      End If

   End Sub

   Private Sub tsbConsolidadoCarga_Click(sender As Object, e As EventArgs) Handles tsbConsolidadoCarga.Click
      Try
         ImprimirConsolidadCarga(False)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbConsolidadoCargaTipoOperacion_Click(sender As Object, e As EventArgs) Handles tsbConsolidadoCargaTipoOperacion.Click
      Try
         ImprimirConsolidadCarga(True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub ImprimirConsolidadCarga(porTipoOperacion As Boolean)
      If ugDetalle.ActiveRow IsNot Nothing AndAlso
         ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then

         Me.Cursor = Cursors.WaitCursor

         Dim dr As DataRow = DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row
         'Dim fechaDesde As DateTime = CDate(dr("FechaEnvio")).Date
         Dim idSucursal As Integer = dr.ValorNumericoPorDefecto("IdSucursal", 0I)
         Dim numeroReparto As Integer = dr.ValorNumericoPorDefecto("NumeroReparto", 0I)

         Dim filtros As String = String.Empty
         Dim IdTransportista As Integer = 0
         Dim IdVendedor As Integer = 0

         If Me.bscTransportista.Enabled AndAlso Me.bscTransportista.Tag IsNot Nothing Then
            IdTransportista = CInt(Me.bscTransportista.Tag)
            filtros = filtros + " Resp. de Distribución: " & Me.bscTransportista.Text & " -- "
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
            filtros = filtros + " Vendedor: " & DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).NombreEmpleado & " -- "
         End If

         filtros = filtros + " Nro. Reparto: " & numeroReparto & ""

         'GAR PENDIENTE PARA EVALUAR LA FECHA
         'filtros = filtros + " Fecha de envío: desde el " & dtpDesde.Value.ToString() & " hasta el " & dtpHasta.Value.ToString()

         Dim impresion As New ImprimirRepartosConsolidadoCargaMercaderia()
         impresion.Imprimir(filtros, idSucursal, dtpDesde.Value, dtpHasta.Value, {numeroReparto}, IdTransportista, IdVendedor, Me.Text, porTipoOperacion)

      End If
   End Sub

   Private Sub btnImprimirDetallado_Click(sender As Object, e As EventArgs) Handles btnImprimirDetallado.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         ImprimirDetallado()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class