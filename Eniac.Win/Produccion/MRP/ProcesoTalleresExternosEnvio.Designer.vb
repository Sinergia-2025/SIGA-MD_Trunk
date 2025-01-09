<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcesoTalleresExternosEnvio
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcesoTalleresExternosEnvio))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraDataBand1 As Infragistics.Win.UltraWinDataSource.UltraDataBand = New Infragistics.Win.UltraWinDataSource.UltraDataBand("Band 1")
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Código")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Producto")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cant. Pendiente")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad a Remitir")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Lote")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Masivo")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Tarea")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("C. Productor")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Código")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Producto")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cant. Pendiente")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad a Rendir")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Vincular")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Tipo")
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("L.")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Emisor")
        Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Nùmero OP")
        Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cliente")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoProceso")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoResultante")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSolicitada")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadProcesada")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadPendiente")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSeleccionada")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedidaProceso")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LoteSeleccionado")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroSerieSeleccionado")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDepositoUbicacion")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NormasMetodos")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedidaCompra")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSeleccionadaCompra")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Vincular")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoProceso")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoResultante")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSolicitada")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadProcesada")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadPendiente")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSeleccionada")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedidaProceso")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Masivo")
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionTipoComprobanteOP")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraComprobante")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdOperacion")
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCentroProductor")
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCentroProductorOperacion")
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionCentroProductorOperacion")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProcesoProductivo")
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoProceso")
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoResultante")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsProductoNecesario")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSolicitada")
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadProcesada")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadPendiente")
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSeleccionada")
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalPedido")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobantePedido")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionTipoComprobantePedido")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraPedido")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorPedido")
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenPedido")
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoPedido")
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tspBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCalcular = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.grpFiltros = New System.Windows.Forms.GroupBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.bscNombreTareas = New Eniac.Controles.Buscador2()
        Me.chbTarea = New Eniac.Controles.CheckBox()
        Me.Label4 = New Eniac.Controles.Label()
        Me.cmbTipoComprobantePedido = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.txtLineaPedido = New Eniac.Controles.TextBox()
        Me.lblLineaVta = New Eniac.Controles.Label()
        Me.chbPedidoVta = New Eniac.Controles.CheckBox()
        Me.txtNroPedido = New Eniac.Controles.TextBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.cmbTipoComprobanteOP = New Eniac.Controles.ComboBox()
        Me.chbOrdenProduccion = New Eniac.Controles.CheckBox()
        Me.txtIdOrdenProduccion = New Eniac.Controles.TextBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.chbCentroProductor = New Eniac.Controles.CheckBox()
        Me.bscCodigoCentroProductor = New Eniac.Controles.Buscador2()
        Me.bscNombreCentrosProductores = New Eniac.Controles.Buscador2()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
        Me.bscNombreProveedor = New Eniac.Controles.Buscador2()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblLote = New Eniac.Controles.Label()
        Me.lblBultos = New Eniac.Controles.Label()
        Me.txtNumeroLote = New Eniac.Controles.TextBox()
        Me.bscTransportista = New Eniac.Controles.Buscador2()
        Me.lblTransportista = New Eniac.Controles.Label()
        Me.txtValorDeclarado = New Eniac.Controles.TextBox()
        Me.lblValorDeclarado = New Eniac.Controles.Label()
        Me.txtBultos = New Eniac.Controles.TextBox()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.ugProductosNecesarios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugProductosResultantes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugOperaciones = New Eniac.Win.UltraGridEditable()
        Me.tbcGeneral = New System.Windows.Forms.TabControl()
        Me.tbpSeleccion = New System.Windows.Forms.TabPage()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.tbpGenerar = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tspBarra.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltros.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ugProductosNecesarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugProductosResultantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugOperaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcGeneral.SuspendLayout()
        Me.tbpSeleccion.SuspendLayout()
        Me.tbpGenerar.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tspBarra
        '
        Me.tspBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tspBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator5, Me.tsbCalcular, Me.tsbGrabar, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tspBarra.Location = New System.Drawing.Point(0, 0)
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(984, 29)
        Me.tspBarra.TabIndex = 3
        Me.tspBarra.Text = "ToolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCalcular
        '
        Me.tsbCalcular.Enabled = False
        Me.tsbCalcular.Image = Global.Eniac.Win.My.Resources.Resources.calculator
        Me.tsbCalcular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCalcular.Name = "tsbCalcular"
        Me.tsbCalcular.Size = New System.Drawing.Size(99, 26)
        Me.tsbCalcular.Text = "Calcular (F4)"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(149, 26)
        Me.tsbGrabar.Text = "Grabar e Imprimir (F4)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(905, 17)
        Me.tssInfo.Spring = True
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ToolStripProgressBar1.Visible = False
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Appearance1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance1.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance1
        Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Header.TextCenter = ""
        Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
        Me.UltraGridPrintDocument1.Page.Margins.Left = 2
        Me.UltraGridPrintDocument1.Page.Margins.Right = 2
        Me.UltraGridPrintDocument1.Page.Margins.Top = 2
        Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
        '
        'UltraDataSource1
        '
        UltraDataBand1.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6})
        Me.UltraDataSource1.Band.ChildBands.AddRange(New Object() {UltraDataBand1})
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21})
        Me.UltraDataSource1.Rows.AddRange(New Object() {New Infragistics.Win.UltraWinDataSource.UltraDataRow(New Object() {CType("Masivo", Object), CType("FALSE", Object), CType("Tarea", Object), CType("GALVANIZADO", Object), CType("C. Productor", Object), CType("EXTERNO", Object), CType("Código", Object), CType("A25", Object), CType("Producto", Object), CType("PRODUCTO A25", Object), CType("Cantidad", Object), CType("100", Object), CType("Cant. Pendiente", Object), CType("80", Object), CType("Cantidad a Rendir", Object), CType("0", Object), CType("Fecha", Object), CType("10/08/2023", Object), CType("Tipo", Object), CType("OP", Object), CType("L.", Object), CType("X", Object), CType("Emisor", Object), CType("1", Object), CType("Nùmero OP", Object), CType("20", Object), CType("Cliente", Object), CType("CLIENTE", Object)}, New Object() {CType("Band 1", Object), CType(New Infragistics.Win.UltraWinDataSource.UltraDataRowsCollection(New Infragistics.Win.UltraWinDataSource.UltraDataRow() {New Infragistics.Win.UltraWinDataSource.UltraDataRow(New Object() {CType("Código", Object), CType("X11", Object), CType("Producto", Object), CType("PRODUCTO X11", Object), CType("Cantidad", Object), CType("100", Object), CType("Cant. Pendiente", Object), CType("80", Object), CType("Cantidad a Remitir", Object), CType("0", Object)}), New Infragistics.Win.UltraWinDataSource.UltraDataRow(New Object() {CType("Código", Object), CType("X22", Object), CType("Producto", Object), CType("PRODUCTO X22", Object), CType("Cantidad", Object), CType("100", Object), CType("Cant. Pendiente", Object), CType("80", Object), CType("Cantidad a Remitir", Object), CType("0", Object)})}, Nothing), Object)}), New Infragistics.Win.UltraWinDataSource.UltraDataRow(New Object() {CType("Masivo", Object), CType("FALSE", Object), CType("Tarea", Object), CType("GALVANIZADO", Object), CType("C. Productor", Object), CType("EXTERNO", Object), CType("Código", Object), CType("A12", Object), CType("Producto", Object), CType("PRODUCTO A25", Object), CType("Cantidad", Object), CType("100", Object), CType("Cant. Pendiente", Object), CType("100", Object), CType("Cantidad a Rendir", Object), CType("0", Object), CType("Fecha", Object), CType("15/08/2023", Object), CType("Tipo", Object), CType("OP", Object), CType("L.", Object), CType("X", Object), CType("Emisor", Object), CType("1", Object), CType("Nùmero OP", Object), CType("22", Object), CType("Cliente", Object), CType("CLIENTE", Object)}, New Object() {CType("Band 1", Object), CType(New Infragistics.Win.UltraWinDataSource.UltraDataRowsCollection(New Infragistics.Win.UltraWinDataSource.UltraDataRow() {New Infragistics.Win.UltraWinDataSource.UltraDataRow(New Object() {CType("Código", Object), CType("X11", Object), CType("Producto", Object), CType("PRODUCTO X11", Object), CType("Cantidad", Object), CType("100", Object), CType("Cant. Pendiente", Object), CType("100", Object), CType("Cantidad a Remitir", Object), CType("0", Object)}), New Infragistics.Win.UltraWinDataSource.UltraDataRow(New Object() {CType("Código", Object), CType("X22", Object), CType("Producto", Object), CType("PRODUCTO X22", Object), CType("Cantidad", Object), CType("100", Object), CType("Cant. Pendiente", Object), CType("100", Object), CType("Cantidad a Remitir", Object), CType("0", Object)})}, Nothing), Object)})})
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.chbFecha)
        Me.grpFiltros.Controls.Add(Me.bscNombreTareas)
        Me.grpFiltros.Controls.Add(Me.chbTarea)
        Me.grpFiltros.Controls.Add(Me.Label4)
        Me.grpFiltros.Controls.Add(Me.cmbTipoComprobantePedido)
        Me.grpFiltros.Controls.Add(Me.btnConsultar)
        Me.grpFiltros.Controls.Add(Me.txtLineaPedido)
        Me.grpFiltros.Controls.Add(Me.lblLineaVta)
        Me.grpFiltros.Controls.Add(Me.chbPedidoVta)
        Me.grpFiltros.Controls.Add(Me.txtNroPedido)
        Me.grpFiltros.Controls.Add(Me.Label3)
        Me.grpFiltros.Controls.Add(Me.cmbTipoComprobanteOP)
        Me.grpFiltros.Controls.Add(Me.chbOrdenProduccion)
        Me.grpFiltros.Controls.Add(Me.txtIdOrdenProduccion)
        Me.grpFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grpFiltros.Controls.Add(Me.dtpHasta)
        Me.grpFiltros.Controls.Add(Me.dtpDesde)
        Me.grpFiltros.Controls.Add(Me.lblHasta)
        Me.grpFiltros.Controls.Add(Me.lblDesde)
        Me.grpFiltros.Controls.Add(Me.chbCentroProductor)
        Me.grpFiltros.Controls.Add(Me.bscCodigoCentroProductor)
        Me.grpFiltros.Controls.Add(Me.bscNombreCentrosProductores)
        Me.grpFiltros.Controls.Add(Me.bscCodigoProveedor)
        Me.grpFiltros.Controls.Add(Me.bscNombreProveedor)
        Me.grpFiltros.Controls.Add(Me.chbProveedor)
        Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(984, 104)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        Me.grpFiltros.Text = "Producción"
        '
        'chbFecha
        '
        Me.chbFecha.AutoSize = True
        Me.chbFecha.BindearPropiedadControl = Nothing
        Me.chbFecha.BindearPropiedadEntidad = Nothing
        Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFecha.IsPK = False
        Me.chbFecha.IsRequired = False
        Me.chbFecha.Key = Nothing
        Me.chbFecha.LabelAsoc = Nothing
        Me.chbFecha.Location = New System.Drawing.Point(428, 20)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 3
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'bscNombreTareas
        '
        Me.bscNombreTareas.ActivarFiltroEnGrilla = True
        Me.bscNombreTareas.BindearPropiedadControl = Nothing
        Me.bscNombreTareas.BindearPropiedadEntidad = Nothing
        Me.bscNombreTareas.ConfigBuscador = Nothing
        Me.bscNombreTareas.Datos = Nothing
        Me.bscNombreTareas.FilaDevuelta = Nothing
        Me.bscNombreTareas.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreTareas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreTareas.IsDecimal = False
        Me.bscNombreTareas.IsNumber = False
        Me.bscNombreTareas.IsPK = False
        Me.bscNombreTareas.IsRequired = False
        Me.bscNombreTareas.Key = ""
        Me.bscNombreTareas.LabelAsoc = Nothing
        Me.bscNombreTareas.Location = New System.Drawing.Point(79, 69)
        Me.bscNombreTareas.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreTareas.MaxLengh = "32767"
        Me.bscNombreTareas.Name = "bscNombreTareas"
        Me.bscNombreTareas.Permitido = False
        Me.bscNombreTareas.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreTareas.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreTareas.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreTareas.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreTareas.Selecciono = False
        Me.bscNombreTareas.Size = New System.Drawing.Size(342, 20)
        Me.bscNombreTareas.TabIndex = 17
        '
        'chbTarea
        '
        Me.chbTarea.AutoSize = True
        Me.chbTarea.BindearPropiedadControl = Nothing
        Me.chbTarea.BindearPropiedadEntidad = Nothing
        Me.chbTarea.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTarea.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTarea.IsPK = False
        Me.chbTarea.IsRequired = False
        Me.chbTarea.Key = Nothing
        Me.chbTarea.LabelAsoc = Nothing
        Me.chbTarea.Location = New System.Drawing.Point(10, 71)
        Me.chbTarea.Name = "chbTarea"
        Me.chbTarea.Size = New System.Drawing.Size(54, 17)
        Me.chbTarea.TabIndex = 16
        Me.chbTarea.Text = "Tarea"
        Me.chbTarea.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(685, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Comp."
        '
        'cmbTipoComprobantePedido
        '
        Me.cmbTipoComprobantePedido.BindearPropiedadControl = ""
        Me.cmbTipoComprobantePedido.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobantePedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobantePedido.Enabled = False
        Me.cmbTipoComprobantePedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobantePedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobantePedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobantePedido.FormattingEnabled = True
        Me.cmbTipoComprobantePedido.IsPK = False
        Me.cmbTipoComprobantePedido.IsRequired = False
        Me.cmbTipoComprobantePedido.Key = Nothing
        Me.cmbTipoComprobantePedido.LabelAsoc = Nothing
        Me.cmbTipoComprobantePedido.Location = New System.Drawing.Point(728, 69)
        Me.cmbTipoComprobantePedido.Name = "cmbTipoComprobantePedido"
        Me.cmbTipoComprobantePedido.Size = New System.Drawing.Size(136, 21)
        Me.cmbTipoComprobantePedido.TabIndex = 23
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnConsultar.Location = New System.Drawing.Point(869, 60)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 32)
        Me.btnConsultar.TabIndex = 24
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtLineaPedido
        '
        Me.txtLineaPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtLineaPedido.BindearPropiedadControl = Nothing
        Me.txtLineaPedido.BindearPropiedadEntidad = Nothing
        Me.txtLineaPedido.Enabled = False
        Me.txtLineaPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLineaPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLineaPedido.Formato = ""
        Me.txtLineaPedido.IsDecimal = False
        Me.txtLineaPedido.IsNumber = True
        Me.txtLineaPedido.IsPK = False
        Me.txtLineaPedido.IsRequired = False
        Me.txtLineaPedido.Key = ""
        Me.txtLineaPedido.LabelAsoc = Nothing
        Me.txtLineaPedido.Location = New System.Drawing.Point(637, 68)
        Me.txtLineaPedido.MaxLength = 8
        Me.txtLineaPedido.Name = "txtLineaPedido"
        Me.txtLineaPedido.Size = New System.Drawing.Size(45, 20)
        Me.txtLineaPedido.TabIndex = 21
        Me.txtLineaPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLineaVta
        '
        Me.lblLineaVta.AutoSize = True
        Me.lblLineaVta.LabelAsoc = Nothing
        Me.lblLineaVta.Location = New System.Drawing.Point(598, 70)
        Me.lblLineaVta.Name = "lblLineaVta"
        Me.lblLineaVta.Size = New System.Drawing.Size(33, 13)
        Me.lblLineaVta.TabIndex = 20
        Me.lblLineaVta.Text = "Linea"
        '
        'chbPedidoVta
        '
        Me.chbPedidoVta.AutoSize = True
        Me.chbPedidoVta.BindearPropiedadControl = Nothing
        Me.chbPedidoVta.BindearPropiedadEntidad = Nothing
        Me.chbPedidoVta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPedidoVta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPedidoVta.IsPK = False
        Me.chbPedidoVta.IsRequired = False
        Me.chbPedidoVta.Key = Nothing
        Me.chbPedidoVta.LabelAsoc = Nothing
        Me.chbPedidoVta.Location = New System.Drawing.Point(428, 70)
        Me.chbPedidoVta.Name = "chbPedidoVta"
        Me.chbPedidoVta.Size = New System.Drawing.Size(81, 17)
        Me.chbPedidoVta.TabIndex = 18
        Me.chbPedidoVta.Text = "Pedido Vta."
        Me.chbPedidoVta.UseVisualStyleBackColor = True
        '
        'txtNroPedido
        '
        Me.txtNroPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtNroPedido.BindearPropiedadControl = Nothing
        Me.txtNroPedido.BindearPropiedadEntidad = Nothing
        Me.txtNroPedido.Enabled = False
        Me.txtNroPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPedido.Formato = ""
        Me.txtNroPedido.IsDecimal = False
        Me.txtNroPedido.IsNumber = True
        Me.txtNroPedido.IsPK = False
        Me.txtNroPedido.IsRequired = False
        Me.txtNroPedido.Key = ""
        Me.txtNroPedido.LabelAsoc = Nothing
        Me.txtNroPedido.Location = New System.Drawing.Point(515, 67)
        Me.txtNroPedido.MaxLength = 8
        Me.txtNroPedido.Name = "txtNroPedido"
        Me.txtNroPedido.Size = New System.Drawing.Size(80, 20)
        Me.txtNroPedido.TabIndex = 19
        Me.txtNroPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(602, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Tipo Comp."
        '
        'cmbTipoComprobanteOP
        '
        Me.cmbTipoComprobanteOP.BindearPropiedadControl = ""
        Me.cmbTipoComprobanteOP.BindearPropiedadEntidad = ""
        Me.cmbTipoComprobanteOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobanteOP.Enabled = False
        Me.cmbTipoComprobanteOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobanteOP.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobanteOP.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobanteOP.FormattingEnabled = True
        Me.cmbTipoComprobanteOP.IsPK = False
        Me.cmbTipoComprobanteOP.IsRequired = False
        Me.cmbTipoComprobanteOP.Key = Nothing
        Me.cmbTipoComprobanteOP.LabelAsoc = Me.Label3
        Me.cmbTipoComprobanteOP.Location = New System.Drawing.Point(670, 43)
        Me.cmbTipoComprobanteOP.Name = "cmbTipoComprobanteOP"
        Me.cmbTipoComprobanteOP.Size = New System.Drawing.Size(194, 21)
        Me.cmbTipoComprobanteOP.TabIndex = 15
        '
        'chbOrdenProduccion
        '
        Me.chbOrdenProduccion.AutoSize = True
        Me.chbOrdenProduccion.BindearPropiedadControl = Nothing
        Me.chbOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.chbOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenProduccion.IsPK = False
        Me.chbOrdenProduccion.IsRequired = False
        Me.chbOrdenProduccion.Key = Nothing
        Me.chbOrdenProduccion.LabelAsoc = Nothing
        Me.chbOrdenProduccion.Location = New System.Drawing.Point(428, 44)
        Me.chbOrdenProduccion.Name = "chbOrdenProduccion"
        Me.chbOrdenProduccion.Size = New System.Drawing.Size(98, 17)
        Me.chbOrdenProduccion.TabIndex = 12
        Me.chbOrdenProduccion.Text = "Orden de Prod."
        Me.chbOrdenProduccion.UseVisualStyleBackColor = True
        '
        'txtIdOrdenProduccion
        '
        Me.txtIdOrdenProduccion.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdOrdenProduccion.BindearPropiedadControl = Nothing
        Me.txtIdOrdenProduccion.BindearPropiedadEntidad = Nothing
        Me.txtIdOrdenProduccion.Enabled = False
        Me.txtIdOrdenProduccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdOrdenProduccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdOrdenProduccion.Formato = ""
        Me.txtIdOrdenProduccion.IsDecimal = False
        Me.txtIdOrdenProduccion.IsNumber = True
        Me.txtIdOrdenProduccion.IsPK = False
        Me.txtIdOrdenProduccion.IsRequired = False
        Me.txtIdOrdenProduccion.Key = ""
        Me.txtIdOrdenProduccion.LabelAsoc = Nothing
        Me.txtIdOrdenProduccion.Location = New System.Drawing.Point(527, 43)
        Me.txtIdOrdenProduccion.MaxLength = 6
        Me.txtIdOrdenProduccion.Name = "txtIdOrdenProduccion"
        Me.txtIdOrdenProduccion.Size = New System.Drawing.Size(69, 20)
        Me.txtIdOrdenProduccion.TabIndex = 13
        Me.txtIdOrdenProduccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(490, 20)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 4
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(813, 18)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 8
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.Enabled = False
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(768, 22)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 7
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(630, 18)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(132, 20)
        Me.dtpDesde.TabIndex = 6
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.Enabled = False
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(586, 22)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 5
        Me.lblDesde.Text = "Desde"
        '
        'chbCentroProductor
        '
        Me.chbCentroProductor.AutoSize = True
        Me.chbCentroProductor.BindearPropiedadControl = Nothing
        Me.chbCentroProductor.BindearPropiedadEntidad = Nothing
        Me.chbCentroProductor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCentroProductor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCentroProductor.IsPK = False
        Me.chbCentroProductor.IsRequired = False
        Me.chbCentroProductor.Key = Nothing
        Me.chbCentroProductor.LabelAsoc = Nothing
        Me.chbCentroProductor.Location = New System.Drawing.Point(10, 44)
        Me.chbCentroProductor.Name = "chbCentroProductor"
        Me.chbCentroProductor.Size = New System.Drawing.Size(106, 17)
        Me.chbCentroProductor.TabIndex = 9
        Me.chbCentroProductor.Text = "Centro Productor"
        Me.chbCentroProductor.UseVisualStyleBackColor = True
        '
        'bscCodigoCentroProductor
        '
        Me.bscCodigoCentroProductor.ActivarFiltroEnGrilla = True
        Me.bscCodigoCentroProductor.BindearPropiedadControl = Nothing
        Me.bscCodigoCentroProductor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCentroProductor.ConfigBuscador = Nothing
        Me.bscCodigoCentroProductor.Datos = Nothing
        Me.bscCodigoCentroProductor.FilaDevuelta = Nothing
        Me.bscCodigoCentroProductor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCentroProductor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCentroProductor.IsDecimal = False
        Me.bscCodigoCentroProductor.IsNumber = False
        Me.bscCodigoCentroProductor.IsPK = False
        Me.bscCodigoCentroProductor.IsRequired = False
        Me.bscCodigoCentroProductor.Key = ""
        Me.bscCodigoCentroProductor.LabelAsoc = Nothing
        Me.bscCodigoCentroProductor.Location = New System.Drawing.Point(125, 42)
        Me.bscCodigoCentroProductor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoCentroProductor.MaxLengh = "32767"
        Me.bscCodigoCentroProductor.Name = "bscCodigoCentroProductor"
        Me.bscCodigoCentroProductor.Permitido = False
        Me.bscCodigoCentroProductor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCentroProductor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCentroProductor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCentroProductor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCentroProductor.Selecciono = False
        Me.bscCodigoCentroProductor.Size = New System.Drawing.Size(103, 20)
        Me.bscCodigoCentroProductor.TabIndex = 10
        '
        'bscNombreCentrosProductores
        '
        Me.bscNombreCentrosProductores.ActivarFiltroEnGrilla = True
        Me.bscNombreCentrosProductores.BindearPropiedadControl = Nothing
        Me.bscNombreCentrosProductores.BindearPropiedadEntidad = Nothing
        Me.bscNombreCentrosProductores.ConfigBuscador = Nothing
        Me.bscNombreCentrosProductores.Datos = Nothing
        Me.bscNombreCentrosProductores.FilaDevuelta = Nothing
        Me.bscNombreCentrosProductores.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCentrosProductores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCentrosProductores.IsDecimal = False
        Me.bscNombreCentrosProductores.IsNumber = False
        Me.bscNombreCentrosProductores.IsPK = False
        Me.bscNombreCentrosProductores.IsRequired = False
        Me.bscNombreCentrosProductores.Key = ""
        Me.bscNombreCentrosProductores.LabelAsoc = Nothing
        Me.bscNombreCentrosProductores.Location = New System.Drawing.Point(236, 42)
        Me.bscNombreCentrosProductores.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCentrosProductores.MaxLengh = "32767"
        Me.bscNombreCentrosProductores.Name = "bscNombreCentrosProductores"
        Me.bscNombreCentrosProductores.Permitido = False
        Me.bscNombreCentrosProductores.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCentrosProductores.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCentrosProductores.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCentrosProductores.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCentrosProductores.Selecciono = False
        Me.bscNombreCentrosProductores.Size = New System.Drawing.Size(185, 20)
        Me.bscNombreCentrosProductores.TabIndex = 11
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(92, 18)
        Me.bscCodigoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(110, 20)
        Me.bscCodigoProveedor.TabIndex = 1
        '
        'bscNombreProveedor
        '
        Me.bscNombreProveedor.ActivarFiltroEnGrilla = True
        Me.bscNombreProveedor.BindearPropiedadControl = Nothing
        Me.bscNombreProveedor.BindearPropiedadEntidad = Nothing
        Me.bscNombreProveedor.ConfigBuscador = Nothing
        Me.bscNombreProveedor.Datos = Nothing
        Me.bscNombreProveedor.FilaDevuelta = Nothing
        Me.bscNombreProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProveedor.IsDecimal = False
        Me.bscNombreProveedor.IsNumber = False
        Me.bscNombreProveedor.IsPK = False
        Me.bscNombreProveedor.IsRequired = False
        Me.bscNombreProveedor.Key = ""
        Me.bscNombreProveedor.LabelAsoc = Nothing
        Me.bscNombreProveedor.Location = New System.Drawing.Point(210, 18)
        Me.bscNombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreProveedor.MaxLengh = "32767"
        Me.bscNombreProveedor.Name = "bscNombreProveedor"
        Me.bscNombreProveedor.Permitido = True
        Me.bscNombreProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.Selecciono = False
        Me.bscNombreProveedor.Size = New System.Drawing.Size(211, 20)
        Me.bscNombreProveedor.TabIndex = 2
        '
        'chbProveedor
        '
        Me.chbProveedor.AutoSize = True
        Me.chbProveedor.BindearPropiedadControl = Nothing
        Me.chbProveedor.BindearPropiedadEntidad = Nothing
        Me.chbProveedor.Checked = True
        Me.chbProveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Location = New System.Drawing.Point(10, 20)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 0
        Me.chbProveedor.Text = "Proveedor"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.ToolStripProgressBar1, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(984, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblLote)
        Me.GroupBox2.Controls.Add(Me.lblBultos)
        Me.GroupBox2.Controls.Add(Me.txtNumeroLote)
        Me.GroupBox2.Controls.Add(Me.bscTransportista)
        Me.GroupBox2.Controls.Add(Me.txtValorDeclarado)
        Me.GroupBox2.Controls.Add(Me.lblTransportista)
        Me.GroupBox2.Controls.Add(Me.lblValorDeclarado)
        Me.GroupBox2.Controls.Add(Me.txtBultos)
        Me.GroupBox2.Controls.Add(Me.cmbTiposComprobantes)
        Me.GroupBox2.Controls.Add(Me.lblTipoComprobante)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(3, 341)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(970, 36)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Remito"
        '
        'lblLote
        '
        Me.lblLote.AutoSize = True
        Me.lblLote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLote.LabelAsoc = Nothing
        Me.lblLote.Location = New System.Drawing.Point(862, 17)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(28, 13)
        Me.lblLote.TabIndex = 8
        Me.lblLote.Text = "Lote"
        '
        'lblBultos
        '
        Me.lblBultos.AutoSize = True
        Me.lblBultos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBultos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBultos.LabelAsoc = Nothing
        Me.lblBultos.Location = New System.Drawing.Point(280, 17)
        Me.lblBultos.Name = "lblBultos"
        Me.lblBultos.Size = New System.Drawing.Size(63, 13)
        Me.lblBultos.TabIndex = 2
        Me.lblBultos.Text = "Total Bultos"
        '
        'txtNumeroLote
        '
        Me.txtNumeroLote.BindearPropiedadControl = Nothing
        Me.txtNumeroLote.BindearPropiedadEntidad = Nothing
        Me.txtNumeroLote.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroLote.Formato = ""
        Me.txtNumeroLote.IsDecimal = False
        Me.txtNumeroLote.IsNumber = True
        Me.txtNumeroLote.IsPK = False
        Me.txtNumeroLote.IsRequired = False
        Me.txtNumeroLote.Key = ""
        Me.txtNumeroLote.LabelAsoc = Nothing
        Me.txtNumeroLote.Location = New System.Drawing.Point(898, 12)
        Me.txtNumeroLote.MaxLength = 8
        Me.txtNumeroLote.Name = "txtNumeroLote"
        Me.txtNumeroLote.Size = New System.Drawing.Size(63, 20)
        Me.txtNumeroLote.TabIndex = 9
        Me.txtNumeroLote.Text = "0"
        Me.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscTransportista
        '
        Me.bscTransportista.ActivarFiltroEnGrilla = True
        Me.bscTransportista.AutoSize = True
        Me.bscTransportista.BindearPropiedadControl = Nothing
        Me.bscTransportista.BindearPropiedadEntidad = Nothing
        Me.bscTransportista.ConfigBuscador = Nothing
        Me.bscTransportista.Datos = Nothing
        Me.bscTransportista.FilaDevuelta = Nothing
        Me.bscTransportista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.bscTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscTransportista.IsDecimal = False
        Me.bscTransportista.IsNumber = False
        Me.bscTransportista.IsPK = False
        Me.bscTransportista.IsRequired = False
        Me.bscTransportista.Key = ""
        Me.bscTransportista.LabelAsoc = Me.lblTransportista
        Me.bscTransportista.Location = New System.Drawing.Point(613, 11)
        Me.bscTransportista.Margin = New System.Windows.Forms.Padding(4)
        Me.bscTransportista.MaxLengh = "32767"
        Me.bscTransportista.Name = "bscTransportista"
        Me.bscTransportista.Permitido = True
        Me.bscTransportista.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscTransportista.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscTransportista.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscTransportista.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscTransportista.Selecciono = False
        Me.bscTransportista.Size = New System.Drawing.Size(242, 23)
        Me.bscTransportista.TabIndex = 7
        '
        'lblTransportista
        '
        Me.lblTransportista.AutoSize = True
        Me.lblTransportista.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTransportista.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransportista.LabelAsoc = Nothing
        Me.lblTransportista.Location = New System.Drawing.Point(567, 17)
        Me.lblTransportista.Name = "lblTransportista"
        Me.lblTransportista.Size = New System.Drawing.Size(43, 13)
        Me.lblTransportista.TabIndex = 6
        Me.lblTransportista.Text = "Transp."
        '
        'txtValorDeclarado
        '
        Me.txtValorDeclarado.BindearPropiedadControl = Nothing
        Me.txtValorDeclarado.BindearPropiedadEntidad = Nothing
        Me.txtValorDeclarado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtValorDeclarado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtValorDeclarado.Formato = "N2"
        Me.txtValorDeclarado.IsDecimal = True
        Me.txtValorDeclarado.IsNumber = True
        Me.txtValorDeclarado.IsPK = False
        Me.txtValorDeclarado.IsRequired = False
        Me.txtValorDeclarado.Key = ""
        Me.txtValorDeclarado.LabelAsoc = Me.lblValorDeclarado
        Me.txtValorDeclarado.Location = New System.Drawing.Point(487, 12)
        Me.txtValorDeclarado.Name = "txtValorDeclarado"
        Me.txtValorDeclarado.Size = New System.Drawing.Size(69, 20)
        Me.txtValorDeclarado.TabIndex = 5
        Me.txtValorDeclarado.Text = "0.00"
        Me.txtValorDeclarado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblValorDeclarado
        '
        Me.lblValorDeclarado.AutoSize = True
        Me.lblValorDeclarado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblValorDeclarado.LabelAsoc = Nothing
        Me.lblValorDeclarado.Location = New System.Drawing.Point(400, 17)
        Me.lblValorDeclarado.Name = "lblValorDeclarado"
        Me.lblValorDeclarado.Size = New System.Drawing.Size(83, 13)
        Me.lblValorDeclarado.TabIndex = 4
        Me.lblValorDeclarado.Text = "Valor Declarado"
        '
        'txtBultos
        '
        Me.txtBultos.BindearPropiedadControl = Nothing
        Me.txtBultos.BindearPropiedadEntidad = Nothing
        Me.txtBultos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBultos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBultos.Formato = ""
        Me.txtBultos.IsDecimal = False
        Me.txtBultos.IsNumber = True
        Me.txtBultos.IsPK = False
        Me.txtBultos.IsRequired = False
        Me.txtBultos.Key = ""
        Me.txtBultos.LabelAsoc = Me.lblBultos
        Me.txtBultos.Location = New System.Drawing.Point(350, 12)
        Me.txtBultos.MaxLength = 10
        Me.txtBultos.Name = "txtBultos"
        Me.txtBultos.Size = New System.Drawing.Size(44, 20)
        Me.txtBultos.TabIndex = 3
        Me.txtBultos.Text = "0"
        Me.txtBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(105, 12)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(169, 21)
        Me.cmbTiposComprobantes.TabIndex = 1
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(5, 17)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoComprobante.TabIndex = 0
        Me.lblTipoComprobante.Text = "&Tipo Comprobante"
        '
        'ugProductosNecesarios
        '
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugProductosNecesarios.DisplayLayout.Appearance = Appearance2
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.Header.Caption = "Código"
        UltraGridColumn8.Header.VisiblePosition = 0
        UltraGridColumn8.Width = 100
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn9.Header.Caption = "Producto"
        UltraGridColumn9.Header.VisiblePosition = 1
        UltraGridColumn9.Width = 150
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance3
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.Caption = "Cantidad Solicitada"
        UltraGridColumn10.Header.VisiblePosition = 2
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 80
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance4
        UltraGridColumn11.Format = "N2"
        UltraGridColumn11.Header.Caption = "Cantidad Procesada"
        UltraGridColumn11.Header.VisiblePosition = 3
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 80
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance5
        UltraGridColumn12.Format = "N2"
        UltraGridColumn12.Header.Caption = "Cantidad Pendiente"
        UltraGridColumn12.Header.VisiblePosition = 4
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 80
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance6
        UltraGridColumn13.Format = "N2"
        UltraGridColumn13.Header.Caption = "Cantidad Seleccionada"
        UltraGridColumn13.Header.VisiblePosition = 5
        UltraGridColumn13.MaskInput = "{double:9.2}"
        UltraGridColumn13.Width = 80
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn14.Header.Caption = "U.M."
        UltraGridColumn14.Header.VisiblePosition = 9
        UltraGridColumn14.Width = 60
        UltraGridColumn71.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn71.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn71.CellAppearance = Appearance7
        UltraGridColumn71.Header.Caption = "Lote"
        UltraGridColumn71.Header.VisiblePosition = 7
        UltraGridColumn71.NullText = "(seleccionar)"
        UltraGridColumn71.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn28.CellAppearance = Appearance8
        UltraGridColumn28.Header.Caption = "Nro. Serie"
        UltraGridColumn28.Header.VisiblePosition = 8
        UltraGridColumn28.NullText = "(seleccionar)"
        UltraGridColumn28.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn29.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn29.CellAppearance = Appearance9
        UltraGridColumn29.Header.Caption = "Depósito / Ubicación"
        UltraGridColumn29.Header.VisiblePosition = 6
        UltraGridColumn29.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance10.TextHAlignAsString = "Left"
        Appearance10.TextVAlignAsString = "Middle"
        UltraGridColumn23.CellAppearance = Appearance10
        UltraGridColumn23.Header.Caption = "Normas Metodos"
        UltraGridColumn23.Header.VisiblePosition = 12
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn24.Header.Caption = "U.M.C."
        UltraGridColumn24.Header.VisiblePosition = 11
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn25.Header.Caption = "Cant. UMC"
        UltraGridColumn25.Header.VisiblePosition = 10
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn71, UltraGridColumn28, UltraGridColumn29, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25})
        Me.ugProductosNecesarios.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugProductosNecesarios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance11.FontData.BoldAsString = "True"
        Me.ugProductosNecesarios.DisplayLayout.CaptionAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductosNecesarios.DisplayLayout.GroupByBox.Appearance = Appearance12
        Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductosNecesarios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance13
        Me.ugProductosNecesarios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance14.BackColor2 = System.Drawing.SystemColors.Control
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductosNecesarios.DisplayLayout.GroupByBox.PromptAppearance = Appearance14
        Me.ugProductosNecesarios.DisplayLayout.MaxBandDepth = 1
        Me.ugProductosNecesarios.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductosNecesarios.DisplayLayout.MaxRowScrollRegions = 1
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductosNecesarios.DisplayLayout.Override.ActiveCellAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.SystemColors.Highlight
        Appearance16.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductosNecesarios.DisplayLayout.Override.ActiveRowAppearance = Appearance16
        Me.ugProductosNecesarios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugProductosNecesarios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductosNecesarios.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductosNecesarios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductosNecesarios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductosNecesarios.DisplayLayout.Override.CardAreaAppearance = Appearance17
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductosNecesarios.DisplayLayout.Override.CellAppearance = Appearance18
        Me.ugProductosNecesarios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugProductosNecesarios.DisplayLayout.Override.CellPadding = 0
        Appearance19.BackColor = System.Drawing.SystemColors.Control
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductosNecesarios.DisplayLayout.Override.GroupByRowAppearance = Appearance19
        Appearance20.TextHAlignAsString = "Left"
        Me.ugProductosNecesarios.DisplayLayout.Override.HeaderAppearance = Appearance20
        Me.ugProductosNecesarios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductosNecesarios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Me.ugProductosNecesarios.DisplayLayout.Override.RowAppearance = Appearance21
        Me.ugProductosNecesarios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance22.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductosNecesarios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance22
        Me.ugProductosNecesarios.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductosNecesarios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductosNecesarios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductosNecesarios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugProductosNecesarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugProductosNecesarios.Location = New System.Drawing.Point(0, 0)
        Me.ugProductosNecesarios.Name = "ugProductosNecesarios"
        Me.ugProductosNecesarios.Size = New System.Drawing.Size(481, 338)
        Me.ugProductosNecesarios.TabIndex = 0
        Me.ugProductosNecesarios.Text = "Productos Necesarios (para Remito)"
        '
        'ugProductosResultantes
        '
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugProductosResultantes.DisplayLayout.Appearance = Appearance23
        UltraGridColumn33.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance24.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance24
        UltraGridColumn33.Header.VisiblePosition = 0
        UltraGridColumn33.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn33.Width = 60
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn1.Header.Caption = "Código"
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Width = 100
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.Header.Caption = "Producto"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 160
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance25
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "Cantidad Solicitada"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 80
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance26.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance26
        UltraGridColumn4.Format = "N2"
        UltraGridColumn4.Header.Caption = "Cantidad Procesada"
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 80
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance27.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance27
        UltraGridColumn5.Format = "N2"
        UltraGridColumn5.Header.Caption = "Cantidad Pendiente"
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 80
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance28
        UltraGridColumn6.Format = "N2"
        UltraGridColumn6.Header.Caption = "Cantidad Seleccionada"
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.MaskInput = "{double:9.2}"
        UltraGridColumn6.Width = 80
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn7.Header.Caption = "U.M."
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 60
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn33, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
        Me.ugProductosResultantes.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugProductosResultantes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance29.FontData.BoldAsString = "True"
        Me.ugProductosResultantes.DisplayLayout.CaptionAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance30.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductosResultantes.DisplayLayout.GroupByBox.Appearance = Appearance30
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductosResultantes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance31
        Me.ugProductosResultantes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance32.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance32.BackColor2 = System.Drawing.SystemColors.Control
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductosResultantes.DisplayLayout.GroupByBox.PromptAppearance = Appearance32
        Me.ugProductosResultantes.DisplayLayout.MaxBandDepth = 1
        Me.ugProductosResultantes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductosResultantes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Appearance33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductosResultantes.DisplayLayout.Override.ActiveCellAppearance = Appearance33
        Appearance34.BackColor = System.Drawing.SystemColors.Highlight
        Appearance34.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductosResultantes.DisplayLayout.Override.ActiveRowAppearance = Appearance34
        Me.ugProductosResultantes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugProductosResultantes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductosResultantes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductosResultantes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductosResultantes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductosResultantes.DisplayLayout.Override.CardAreaAppearance = Appearance35
        Appearance36.BorderColor = System.Drawing.Color.Silver
        Appearance36.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductosResultantes.DisplayLayout.Override.CellAppearance = Appearance36
        Me.ugProductosResultantes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugProductosResultantes.DisplayLayout.Override.CellPadding = 0
        Appearance37.BackColor = System.Drawing.SystemColors.Control
        Appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance37.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance37.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductosResultantes.DisplayLayout.Override.GroupByRowAppearance = Appearance37
        Appearance38.TextHAlignAsString = "Left"
        Me.ugProductosResultantes.DisplayLayout.Override.HeaderAppearance = Appearance38
        Me.ugProductosResultantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductosResultantes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance39.BackColor = System.Drawing.SystemColors.Window
        Appearance39.BorderColor = System.Drawing.Color.Silver
        Me.ugProductosResultantes.DisplayLayout.Override.RowAppearance = Appearance39
        Me.ugProductosResultantes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductosResultantes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance40
        Me.ugProductosResultantes.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugProductosResultantes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductosResultantes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductosResultantes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugProductosResultantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugProductosResultantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugProductosResultantes.Location = New System.Drawing.Point(0, 0)
        Me.ugProductosResultantes.Name = "ugProductosResultantes"
        Me.ugProductosResultantes.Size = New System.Drawing.Size(485, 338)
        Me.ugProductosResultantes.TabIndex = 0
        Me.ugProductosResultantes.Text = "Productos Resultantes (para Orden De Compra)"
        '
        'ugOperaciones
        '
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugOperaciones.DisplayLayout.Appearance = Appearance41
        Appearance42.BackColor = System.Drawing.Color.Cyan
        UltraGridColumn34.CellAppearance = Appearance42
        UltraGridColumn34.Header.VisiblePosition = 0
        UltraGridColumn34.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn34.Width = 50
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance43.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance43
        UltraGridColumn35.Header.Caption = "S."
        UltraGridColumn35.Header.VisiblePosition = 4
        UltraGridColumn35.Hidden = True
        UltraGridColumn35.Width = 40
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.Caption = "Id Tp Comp. OP"
        UltraGridColumn36.Header.VisiblePosition = 5
        UltraGridColumn36.Hidden = True
        UltraGridColumn36.Width = 80
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn37.Header.Caption = "Tipo OP"
        UltraGridColumn37.Header.VisiblePosition = 6
        UltraGridColumn37.Width = 80
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn38.Header.Caption = "L. OP"
        UltraGridColumn38.Header.VisiblePosition = 7
        UltraGridColumn38.Hidden = True
        UltraGridColumn38.Width = 30
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance44.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance44
        UltraGridColumn39.Header.Caption = "Emisor OP"
        UltraGridColumn39.Header.VisiblePosition = 8
        UltraGridColumn39.Hidden = True
        UltraGridColumn39.Width = 50
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance45.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance45
        UltraGridColumn40.Header.Caption = "Número OP"
        UltraGridColumn40.Header.VisiblePosition = 9
        UltraGridColumn40.Width = 80
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance46.TextHAlignAsString = "Right"
        UltraGridColumn47.CellAppearance = Appearance46
        UltraGridColumn47.Header.VisiblePosition = 13
        UltraGridColumn47.Width = 50
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn48.Header.Caption = "Código Producto"
        UltraGridColumn48.Header.VisiblePosition = 10
        UltraGridColumn48.Hidden = True
        UltraGridColumn48.Width = 80
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn49.Header.Caption = "Nombre Producto"
        UltraGridColumn49.Header.VisiblePosition = 11
        UltraGridColumn49.Hidden = True
        UltraGridColumn49.Width = 150
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance47.TextHAlignAsString = "Right"
        UltraGridColumn50.CellAppearance = Appearance47
        UltraGridColumn50.Header.Caption = "Código Operación"
        UltraGridColumn50.Header.VisiblePosition = 12
        UltraGridColumn50.Width = 65
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance48.TextHAlignAsString = "Right"
        UltraGridColumn51.CellAppearance = Appearance48
        UltraGridColumn51.Header.Caption = "Id Centro Productor"
        UltraGridColumn51.Header.VisiblePosition = 14
        UltraGridColumn51.Hidden = True
        UltraGridColumn51.Width = 80
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance49.TextHAlignAsString = "Right"
        UltraGridColumn52.CellAppearance = Appearance49
        UltraGridColumn52.Header.Caption = "Código Centro Productor"
        UltraGridColumn52.Header.VisiblePosition = 15
        UltraGridColumn52.Width = 80
        UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn56.Header.Caption = "Descripción Centro Productor"
        UltraGridColumn56.Header.VisiblePosition = 16
        UltraGridColumn56.Width = 150
        UltraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance50.TextHAlignAsString = "Right"
        UltraGridColumn57.CellAppearance = Appearance50
        UltraGridColumn57.Header.Caption = "Id Proceso Productivo"
        UltraGridColumn57.Header.VisiblePosition = 29
        UltraGridColumn57.Hidden = True
        UltraGridColumn57.Width = 80
        UltraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance51.TextHAlignAsString = "Right"
        UltraGridColumn58.CellAppearance = Appearance51
        UltraGridColumn58.Header.Caption = "Código Producto Resultante"
        UltraGridColumn58.Header.VisiblePosition = 17
        UltraGridColumn58.Width = 80
        UltraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn59.Header.Caption = "Nombre Producto Resultante"
        UltraGridColumn59.Header.VisiblePosition = 18
        UltraGridColumn59.Width = 150
        UltraGridColumn60.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance52.TextHAlignAsString = "Right"
        UltraGridColumn60.CellAppearance = Appearance52
        UltraGridColumn60.Header.Caption = "Id Proveedor"
        UltraGridColumn60.Header.VisiblePosition = 26
        UltraGridColumn60.Hidden = True
        UltraGridColumn60.Width = 80
        UltraGridColumn61.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance53.TextHAlignAsString = "Right"
        UltraGridColumn61.CellAppearance = Appearance53
        UltraGridColumn61.Header.Caption = "Código Proveedor"
        UltraGridColumn61.Header.VisiblePosition = 27
        UltraGridColumn61.Width = 80
        UltraGridColumn62.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn62.Header.Caption = "Nombre Proveedor"
        UltraGridColumn62.Header.VisiblePosition = 28
        UltraGridColumn62.Width = 150
        UltraGridColumn63.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance54.TextHAlignAsString = "Right"
        UltraGridColumn63.CellAppearance = Appearance54
        UltraGridColumn63.Header.Caption = "Id Cliente"
        UltraGridColumn63.Header.VisiblePosition = 21
        UltraGridColumn63.Hidden = True
        UltraGridColumn63.Width = 80
        UltraGridColumn64.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance55.TextHAlignAsString = "Right"
        UltraGridColumn64.CellAppearance = Appearance55
        UltraGridColumn64.Header.Caption = "Código Cliente"
        UltraGridColumn64.Header.VisiblePosition = 24
        UltraGridColumn64.Width = 80
        UltraGridColumn65.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn65.Header.Caption = "Nombre Cliente"
        UltraGridColumn65.Header.VisiblePosition = 25
        UltraGridColumn65.Width = 150
        UltraGridColumn66.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn66.Header.VisiblePosition = 30
        UltraGridColumn66.Hidden = True
        UltraGridColumn67.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance56.TextHAlignAsString = "Right"
        UltraGridColumn67.CellAppearance = Appearance56
        UltraGridColumn67.Format = "N2"
        UltraGridColumn67.Header.Caption = "Cantidad OP"
        UltraGridColumn67.Header.VisiblePosition = 22
        UltraGridColumn67.Width = 80
        UltraGridColumn68.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance57.TextHAlignAsString = "Right"
        UltraGridColumn68.CellAppearance = Appearance57
        UltraGridColumn68.Format = "N2"
        UltraGridColumn68.Header.Caption = "Cantidad Enviada"
        UltraGridColumn68.Header.VisiblePosition = 23
        UltraGridColumn68.Width = 80
        UltraGridColumn69.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance58.TextHAlignAsString = "Right"
        UltraGridColumn69.CellAppearance = Appearance58
        UltraGridColumn69.Format = "N2"
        UltraGridColumn69.Header.Caption = "Cantidad Pendiente"
        UltraGridColumn69.Header.VisiblePosition = 19
        UltraGridColumn69.Width = 80
        UltraGridColumn70.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance59.TextHAlignAsString = "Right"
        UltraGridColumn70.CellAppearance = Appearance59
        UltraGridColumn70.Format = "N2"
        UltraGridColumn70.Header.Caption = "Cantidad Seleccionada"
        UltraGridColumn70.Header.VisiblePosition = 20
        UltraGridColumn70.Width = 80
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance60.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance60
        UltraGridColumn22.Header.Caption = "S. Pedido"
        UltraGridColumn22.Header.VisiblePosition = 31
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 40
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn15.Header.Caption = "Id Tp Comp. Pedido"
        UltraGridColumn15.Header.VisiblePosition = 32
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 80
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn16.Header.Caption = "Tipo Pedido"
        UltraGridColumn16.Header.VisiblePosition = 1
        UltraGridColumn16.Width = 80
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn17.Header.Caption = "L. Pedido"
        UltraGridColumn17.Header.VisiblePosition = 33
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 30
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance61.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance61
        UltraGridColumn18.Header.Caption = "Emisor Pedido"
        UltraGridColumn18.Header.VisiblePosition = 34
        UltraGridColumn18.Hidden = True
        UltraGridColumn18.Width = 50
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance62.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance62
        UltraGridColumn19.Header.Caption = "Número Pedido"
        UltraGridColumn19.Header.VisiblePosition = 2
        UltraGridColumn19.Width = 80
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance63.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance63
        UltraGridColumn20.Header.Caption = "Orden Pedido"
        UltraGridColumn20.Header.VisiblePosition = 3
        UltraGridColumn20.Width = 50
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.Caption = "Código Producto Pedido"
        UltraGridColumn21.Header.VisiblePosition = 35
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 80
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn22, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
        Me.ugOperaciones.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugOperaciones.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugOperaciones.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance64.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance64.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance64.BorderColor = System.Drawing.SystemColors.Window
        Me.ugOperaciones.DisplayLayout.GroupByBox.Appearance = Appearance64
        Appearance65.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugOperaciones.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance65
        Me.ugOperaciones.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugOperaciones.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance66.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance66.BackColor2 = System.Drawing.SystemColors.Control
        Appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance66.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugOperaciones.DisplayLayout.GroupByBox.PromptAppearance = Appearance66
        Me.ugOperaciones.DisplayLayout.MaxBandDepth = 1
        Me.ugOperaciones.DisplayLayout.MaxColScrollRegions = 1
        Me.ugOperaciones.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugOperaciones.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance67.BackColor = System.Drawing.SystemColors.Window
        Appearance67.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugOperaciones.DisplayLayout.Override.ActiveCellAppearance = Appearance67
        Appearance68.BackColor = System.Drawing.SystemColors.Highlight
        Appearance68.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugOperaciones.DisplayLayout.Override.ActiveRowAppearance = Appearance68
        Me.ugOperaciones.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugOperaciones.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugOperaciones.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugOperaciones.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugOperaciones.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance69.BackColor = System.Drawing.SystemColors.Window
        Me.ugOperaciones.DisplayLayout.Override.CardAreaAppearance = Appearance69
        Appearance70.BorderColor = System.Drawing.Color.Silver
        Appearance70.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugOperaciones.DisplayLayout.Override.CellAppearance = Appearance70
        Me.ugOperaciones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugOperaciones.DisplayLayout.Override.CellPadding = 0
        Appearance71.BackColor = System.Drawing.SystemColors.Control
        Appearance71.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance71.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance71.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance71.BorderColor = System.Drawing.SystemColors.Window
        Me.ugOperaciones.DisplayLayout.Override.GroupByRowAppearance = Appearance71
        Appearance72.TextHAlignAsString = "Left"
        Me.ugOperaciones.DisplayLayout.Override.HeaderAppearance = Appearance72
        Me.ugOperaciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugOperaciones.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance73.BackColor = System.Drawing.SystemColors.Window
        Appearance73.BorderColor = System.Drawing.Color.Silver
        Me.ugOperaciones.DisplayLayout.Override.RowAppearance = Appearance73
        Me.ugOperaciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance74.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugOperaciones.DisplayLayout.Override.TemplateAddRowAppearance = Appearance74
        Me.ugOperaciones.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugOperaciones.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugOperaciones.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugOperaciones.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugOperaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugOperaciones.ExitEditModeOnLeave = False
        Me.ugOperaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugOperaciones.Location = New System.Drawing.Point(3, 3)
        Me.ugOperaciones.Name = "ugOperaciones"
        Me.ugOperaciones.Size = New System.Drawing.Size(970, 374)
        Me.ugOperaciones.TabIndex = 0
        Me.ugOperaciones.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugOperaciones.ToolStripMenuExpandir = Nothing
        '
        'tbcGeneral
        '
        Me.tbcGeneral.Controls.Add(Me.tbpSeleccion)
        Me.tbcGeneral.Controls.Add(Me.tbpGenerar)
        Me.tbcGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcGeneral.Location = New System.Drawing.Point(0, 133)
        Me.tbcGeneral.Name = "tbcGeneral"
        Me.tbcGeneral.SelectedIndex = 0
        Me.tbcGeneral.Size = New System.Drawing.Size(984, 406)
        Me.tbcGeneral.TabIndex = 1
        '
        'tbpSeleccion
        '
        Me.tbpSeleccion.Controls.Add(Me.btnTodos)
        Me.tbpSeleccion.Controls.Add(Me.cmbTodos)
        Me.tbpSeleccion.Controls.Add(Me.ugOperaciones)
        Me.tbpSeleccion.Location = New System.Drawing.Point(4, 22)
        Me.tbpSeleccion.Name = "tbpSeleccion"
        Me.tbpSeleccion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSeleccion.Size = New System.Drawing.Size(976, 380)
        Me.tbpSeleccion.TabIndex = 0
        Me.tbpSeleccion.Text = "Selección"
        Me.tbpSeleccion.UseVisualStyleBackColor = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(892, 10)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 5
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(765, 12)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 4
        '
        'tbpGenerar
        '
        Me.tbpGenerar.Controls.Add(Me.SplitContainer1)
        Me.tbpGenerar.Controls.Add(Me.GroupBox2)
        Me.tbpGenerar.Location = New System.Drawing.Point(4, 22)
        Me.tbpGenerar.Name = "tbpGenerar"
        Me.tbpGenerar.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpGenerar.Size = New System.Drawing.Size(976, 380)
        Me.tbpGenerar.TabIndex = 1
        Me.tbpGenerar.Text = "Generar"
        Me.tbpGenerar.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ugProductosResultantes)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ugProductosNecesarios)
        Me.SplitContainer1.Size = New System.Drawing.Size(970, 338)
        Me.SplitContainer1.SplitterDistance = 485
        Me.SplitContainer1.TabIndex = 0
        '
        'ProcesoTalleresExternosEnvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.tbcGeneral)
        Me.Controls.Add(Me.grpFiltros)
        Me.Controls.Add(Me.tspBarra)
        Me.Controls.Add(Me.stsStado)
        Me.Name = "ProcesoTalleresExternosEnvio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Talleres Externos Envio"
        Me.tspBarra.ResumeLayout(False)
        Me.tspBarra.PerformLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ugProductosNecesarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugProductosResultantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugOperaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcGeneral.ResumeLayout(False)
        Me.tbpSeleccion.ResumeLayout(False)
        Me.tbpGenerar.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tspBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
   Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
   Friend WithEvents tsbGrabar As ToolStripButton
   Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
   Friend WithEvents tsbSalir As ToolStripButton
   Protected WithEvents tssRegistros As ToolStripStatusLabel
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
   Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
   Friend WithEvents sfdExportar As SaveFileDialog
   Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridPrintDocument1 As UltraGridPrintDocument
   Friend WithEvents grpFiltros As GroupBox
   Protected Friend WithEvents stsStado As StatusStrip
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraDataSource1 As UltraWinDataSource.UltraDataSource
   Friend WithEvents bscCodigoCentroProductor As Controles.Buscador2
   Friend WithEvents bscNombreCentrosProductores As Controles.Buscador2
   Friend WithEvents bscCodigoProveedor As Controles.Buscador2
   Friend WithEvents bscNombreProveedor As Controles.Buscador2
   Friend WithEvents chbProveedor As Controles.CheckBox
   Friend WithEvents Label3 As Controles.Label
    Friend WithEvents cmbTipoComprobanteOP As Controles.ComboBox
    Friend WithEvents chbOrdenProduccion As Controles.CheckBox
    Friend WithEvents txtIdOrdenProduccion As Controles.TextBox
    Friend WithEvents chkMesCompleto As Controles.CheckBox
    Friend WithEvents dtpHasta As Controles.DateTimePicker
    Friend WithEvents lblHasta As Controles.Label
    Friend WithEvents dtpDesde As Controles.DateTimePicker
    Friend WithEvents lblDesde As Controles.Label
    Friend WithEvents chbCentroProductor As Controles.CheckBox
    Friend WithEvents txtLineaPedido As Controles.TextBox
    Friend WithEvents lblLineaVta As Controles.Label
    Friend WithEvents chbPedidoVta As Controles.CheckBox
    Friend WithEvents txtNroPedido As Controles.TextBox
    Friend WithEvents Label4 As Controles.Label
    Friend WithEvents cmbTipoComprobantePedido As Controles.ComboBox
    Friend WithEvents btnConsultar As Controles.Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblLote As Controles.Label
    Friend WithEvents lblBultos As Controles.Label
    Friend WithEvents txtNumeroLote As Controles.TextBox
   Friend WithEvents bscTransportista As Controles.Buscador2
   Friend WithEvents lblTransportista As Controles.Label
    Friend WithEvents txtValorDeclarado As Controles.TextBox
    Friend WithEvents lblValorDeclarado As Controles.Label
    Friend WithEvents txtBultos As Controles.TextBox
    Friend WithEvents cmbTiposComprobantes As Controles.ComboBox
    Friend WithEvents lblTipoComprobante As Controles.Label
    Friend WithEvents bscNombreTareas As Controles.Buscador2
    Friend WithEvents chbTarea As Controles.CheckBox
    Friend WithEvents ugProductosNecesarios As UltraGrid
    Friend WithEvents ugProductosResultantes As UltraGrid
    Friend WithEvents ugOperaciones As UltraGridEditable
    Friend WithEvents tbcGeneral As TabControl
    Friend WithEvents tbpSeleccion As TabPage
    Friend WithEvents tbpGenerar As TabPage
    Friend WithEvents chbFecha As Controles.CheckBox
    Friend WithEvents tsbCalcular As ToolStripButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btnTodos As Button
    Friend WithEvents cmbTodos As Controles.ComboBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Public WithEvents tsbPreferencias As ToolStripButton
End Class
