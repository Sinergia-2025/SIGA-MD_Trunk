﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfOrdenesProduccionDetallado
    Inherits BaseForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaOrdenProduccion")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocumento")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstado")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado")
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEntregada")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteFact")
      Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraFact")
      Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorFact")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteFact")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCriticidad")
      Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TamanoProducto")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedidaProducto")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProduccionProceso")
      Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProduccionProceso")
      Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProduccionForma")
      Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProduccionForma")
      Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Espmm")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoSAE")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LargoExtAlto")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AnchoIntBase")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("UrlPlano")
      Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TamanoTotal")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SubTotal")
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestoInterno")
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestos")
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormula")
      Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFormula")
      Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantComponentes")
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Costo")
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CotizacionDolar")
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ubicacion")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Color")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ObservacionOP")
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalPedido")
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobantePedido")
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorPedido")
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoPedido")
        Dim UltraGridColumn116 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenPedido")
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
        Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
        Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoComprobante")
        Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
        Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
        Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
        Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocCliente")
        Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocCliente")
        Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoriaFiscal")
        Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaDePago")
        Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
        Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
        Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
        Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioLista")
        Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
        Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
        Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
        Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
        Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
        Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
        Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
        Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfOrdenesProduccionDetallado))
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimirPrediseñado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.chbSAE = New Eniac.Controles.CheckBox()
        Me.chbEspmm = New Eniac.Controles.CheckBox()
        Me.chbEspPulgadas = New Eniac.Controles.CheckBox()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.txtSAE = New Eniac.Controles.TextBox()
        Me.txtEspmm = New Eniac.Controles.TextBox()
        Me.txtEspPulgadas = New Eniac.Controles.TextBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.chbTamanio = New Eniac.Controles.CheckBox()
        Me.txtTamanio = New Eniac.Controles.TextBox()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.cmbProduccionProceso = New Eniac.Controles.ComboBox()
        Me.chbProduccionProceso = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.chbIdPedido = New Eniac.Controles.CheckBox()
        Me.txtIdPedido = New Eniac.Controles.TextBox()
        Me.cmbEstados = New Eniac.Controles.ComboBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.chkMesCompletoEntrega = New Eniac.Controles.CheckBox()
        Me.dtpHastaEntrega = New Eniac.Controles.DateTimePicker()
        Me.Label2 = New Eniac.Controles.Label()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesdeEntrega = New Eniac.Controles.DateTimePicker()
        Me.Label1 = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.SuspendLayout()
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'chbUsuario
        '
        Me.chbUsuario.AutoSize = True
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Location = New System.Drawing.Point(572, 127)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 28
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(872, 134)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 37
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(992, 17)
        Me.tssInfo.Spring = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 540)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1071, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance40.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance40.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance40
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
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.Caption = "Numero"
        UltraGridColumn3.Header.VisiblePosition = 5
        UltraGridColumn3.Width = 57
        UltraGridColumn14.Header.Caption = "Fecha"
        UltraGridColumn14.Header.VisiblePosition = 6
        UltraGridColumn14.Width = 69
        UltraGridColumn16.Header.VisiblePosition = 7
        UltraGridColumn16.Hidden = True
        UltraGridColumn30.Header.VisiblePosition = 9
        UltraGridColumn30.Hidden = True
        UltraGridColumn32.Header.Caption = "Cliente"
        UltraGridColumn32.Header.VisiblePosition = 10
        UltraGridColumn32.Width = 150
        UltraGridColumn34.Header.VisiblePosition = 8
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 100
        UltraGridColumn45.Header.Caption = "Producto"
        UltraGridColumn45.Header.VisiblePosition = 11
        UltraGridColumn45.Width = 200
        UltraGridColumn49.Header.VisiblePosition = 12
        UltraGridColumn49.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn50.CellAppearance = Appearance2
        UltraGridColumn50.Format = "N2"
        UltraGridColumn50.Header.Caption = "Cant.Pedida"
        UltraGridColumn50.Header.VisiblePosition = 15
        UltraGridColumn50.Width = 76
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn62.CellAppearance = Appearance3
        UltraGridColumn62.Format = "dd/MM/yyyy"
        UltraGridColumn62.Header.Caption = "Fecha Estado"
        UltraGridColumn62.Header.VisiblePosition = 16
        UltraGridColumn62.Width = 80
        UltraGridColumn63.Header.Caption = "Estado"
        UltraGridColumn63.Header.VisiblePosition = 1
        UltraGridColumn63.Width = 90
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn64.CellAppearance = Appearance4
        UltraGridColumn64.Format = "N2"
        UltraGridColumn64.Header.Caption = "Cant.Invol."
        UltraGridColumn64.Header.VisiblePosition = 17
        UltraGridColumn64.Width = 70
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn65.CellAppearance = Appearance5
        UltraGridColumn65.Format = "N2"
        UltraGridColumn65.Header.VisiblePosition = 27
        UltraGridColumn65.Width = 60
        UltraGridColumn66.Header.Caption = "Comprobante"
        UltraGridColumn66.Header.VisiblePosition = 29
        UltraGridColumn66.Width = 79
        UltraGridColumn67.Header.Caption = "Let."
        UltraGridColumn67.Header.VisiblePosition = 30
        UltraGridColumn67.Width = 30
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn68.CellAppearance = Appearance6
        UltraGridColumn68.Header.Caption = "Emisor"
        UltraGridColumn68.Header.VisiblePosition = 31
        UltraGridColumn68.Width = 50
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn69.CellAppearance = Appearance7
        UltraGridColumn69.Header.Caption = "Número"
        UltraGridColumn69.Header.VisiblePosition = 32
        UltraGridColumn69.Width = 70
        UltraGridColumn70.Header.Caption = "Tipo"
        UltraGridColumn70.Header.VisiblePosition = 2
        UltraGridColumn70.Width = 84
        Appearance8.TextHAlignAsString = "Center"
        UltraGridColumn71.CellAppearance = Appearance8
        UltraGridColumn71.Header.Caption = "L."
        UltraGridColumn71.Header.VisiblePosition = 3
        UltraGridColumn71.Width = 25
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn72.CellAppearance = Appearance9
        UltraGridColumn72.Header.Caption = "Emisor"
        UltraGridColumn72.Header.VisiblePosition = 4
        UltraGridColumn72.Width = 50
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn73.CellAppearance = Appearance10
        UltraGridColumn73.Header.Caption = "Nro. Comprobante"
        UltraGridColumn73.Header.VisiblePosition = 33
        UltraGridColumn73.Hidden = True
        UltraGridColumn73.Width = 80
        UltraGridColumn74.Header.Caption = "Usuario"
        UltraGridColumn74.Header.VisiblePosition = 34
        UltraGridColumn74.Width = 75
        UltraGridColumn75.Header.VisiblePosition = 37
        UltraGridColumn75.Width = 200
        UltraGridColumn76.Header.Caption = "Criticidad"
        UltraGridColumn76.Header.VisiblePosition = 13
        UltraGridColumn76.Width = 70
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn77.CellAppearance = Appearance11
        UltraGridColumn77.Format = "dd/MM/yyyy"
        UltraGridColumn77.Header.Caption = "Entrega"
        UltraGridColumn77.Header.VisiblePosition = 14
        UltraGridColumn77.Width = 70
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn78.CellAppearance = Appearance12
        UltraGridColumn78.Format = "N2"
        UltraGridColumn78.Header.Caption = "Tamaño Unitario"
        UltraGridColumn78.Header.VisiblePosition = 24
        UltraGridColumn78.Width = 60
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn79.CellAppearance = Appearance13
        UltraGridColumn79.Format = "#,##0.00"
        UltraGridColumn79.Header.Caption = "Tamaño"
        UltraGridColumn79.Header.VisiblePosition = 35
        UltraGridColumn79.Hidden = True
        UltraGridColumn79.Width = 60
        Appearance14.TextHAlignAsString = "Center"
        UltraGridColumn80.CellAppearance = Appearance14
        UltraGridColumn80.Header.Caption = "U.M."
        UltraGridColumn80.Header.VisiblePosition = 26
        UltraGridColumn80.Width = 40
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn81.CellAppearance = Appearance15
        UltraGridColumn81.Header.Caption = "U.M."
        UltraGridColumn81.Header.VisiblePosition = 38
        UltraGridColumn81.Hidden = True
        UltraGridColumn81.Width = 40
        UltraGridColumn82.Header.VisiblePosition = 39
        UltraGridColumn82.Hidden = True
        UltraGridColumn83.Header.Caption = "Proceso"
        UltraGridColumn83.Header.VisiblePosition = 40
        UltraGridColumn83.Width = 150
        UltraGridColumn84.Header.VisiblePosition = 41
        UltraGridColumn84.Hidden = True
        UltraGridColumn85.Header.Caption = "Forma"
        UltraGridColumn85.Header.VisiblePosition = 42
        UltraGridColumn85.Width = 150
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn86.CellAppearance = Appearance16
        UltraGridColumn86.Format = "N2"
        UltraGridColumn86.Header.Caption = "Esp. mm"
        UltraGridColumn86.Header.VisiblePosition = 43
        UltraGridColumn86.Width = 70
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn88.CellAppearance = Appearance17
        UltraGridColumn88.Header.Caption = "SAE"
        UltraGridColumn88.Header.VisiblePosition = 44
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn89.CellAppearance = Appearance18
        UltraGridColumn89.Format = "N0"
        UltraGridColumn89.Header.Caption = "Largo Øe Alto"
        UltraGridColumn89.Header.VisiblePosition = 45
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn90.CellAppearance = Appearance19
        UltraGridColumn90.Format = "N0"
        UltraGridColumn90.Header.Caption = "Ancho Øi Base"
        UltraGridColumn90.Header.VisiblePosition = 46
        UltraGridColumn91.Header.Caption = "Adjunto"
        UltraGridColumn91.Header.VisiblePosition = 47
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn92.CellAppearance = Appearance20
        UltraGridColumn92.Header.Caption = "Orden Compra"
        UltraGridColumn92.Header.VisiblePosition = 28
        UltraGridColumn92.Hidden = True
        UltraGridColumn92.Width = 86
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn93.CellAppearance = Appearance21
        UltraGridColumn93.Format = "N2"
        UltraGridColumn93.Header.Caption = "Tamaño Total"
        UltraGridColumn93.Header.VisiblePosition = 25
        UltraGridColumn93.Width = 60
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn94.CellAppearance = Appearance22
        UltraGridColumn94.Format = "N2"
        UltraGridColumn94.Header.Caption = "Importe Total"
        UltraGridColumn94.Header.VisiblePosition = 22
        UltraGridColumn94.Width = 80
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn95.CellAppearance = Appearance23
        UltraGridColumn95.Format = "N2"
        UltraGridColumn95.Header.VisiblePosition = 19
        UltraGridColumn95.Width = 80
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn96.CellAppearance = Appearance24
        UltraGridColumn96.Format = "N2"
        UltraGridColumn96.Header.Caption = "Total Imp. Int."
        UltraGridColumn96.Header.VisiblePosition = 21
        UltraGridColumn96.Width = 80
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn97.CellAppearance = Appearance25
        UltraGridColumn97.Format = "N2"
        UltraGridColumn97.Header.Caption = "Total Impuestos"
        UltraGridColumn97.Header.VisiblePosition = 20
        UltraGridColumn97.Width = 80
        UltraGridColumn98.Header.VisiblePosition = 48
        UltraGridColumn98.Hidden = True
        UltraGridColumn99.Header.Caption = "Fórmula"
        UltraGridColumn99.Header.VisiblePosition = 49
        UltraGridColumn100.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance26.TextHAlignAsString = "Center"
        UltraGridColumn100.CellAppearance = Appearance26
        UltraGridColumn100.Header.Caption = ""
        UltraGridColumn100.Header.VisiblePosition = 50
        UltraGridColumn100.Hidden = True
        UltraGridColumn100.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn100.Width = 30
        Appearance27.TextHAlignAsString = "Right"
        UltraGridColumn101.CellAppearance = Appearance27
        UltraGridColumn101.Format = "N2"
        UltraGridColumn101.Header.VisiblePosition = 18
        UltraGridColumn101.Width = 80
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn102.CellAppearance = Appearance28
        UltraGridColumn102.Format = "N2"
        UltraGridColumn102.Header.Caption = "Cotización Dólar"
        UltraGridColumn102.Header.VisiblePosition = 23
        UltraGridColumn102.Width = 80
        UltraGridColumn1.Header.VisiblePosition = 51
        UltraGridColumn1.Hidden = True
        UltraGridColumn4.Header.VisiblePosition = 52
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.VisiblePosition = 53
        UltraGridColumn5.Hidden = True
        UltraGridColumn6.Header.VisiblePosition = 54
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.Caption = "Obser. Ord. Prod."
        UltraGridColumn7.Header.VisiblePosition = 36
        UltraGridColumn7.Hidden = True
        UltraGridColumn111.Header.VisiblePosition = 55
        UltraGridColumn111.Hidden = True
        UltraGridColumn112.Header.Caption = "Comprobante Pedido"
        UltraGridColumn112.Header.VisiblePosition = 56
        UltraGridColumn113.Header.Caption = "Emisor Pedido"
        UltraGridColumn113.Header.VisiblePosition = 57
        UltraGridColumn114.Header.Caption = "Numero Pedido"
        UltraGridColumn114.Header.VisiblePosition = 58
        UltraGridColumn115.Header.Caption = "Producto Pedido"
        UltraGridColumn115.Header.VisiblePosition = 59
        UltraGridColumn116.Header.Caption = "Orden Pedido"
        UltraGridColumn116.Header.VisiblePosition = 60
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn2, UltraGridColumn3, UltraGridColumn14, UltraGridColumn16, UltraGridColumn30, UltraGridColumn32, UltraGridColumn34, UltraGridColumn45, UltraGridColumn49, UltraGridColumn50, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn1, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114, UltraGridColumn115, UltraGridColumn116})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance31.BackColor2 = System.Drawing.SystemColors.Control
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance31
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance32
        Appearance33.BackColor = System.Drawing.SystemColors.Highlight
        Appearance33.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance34
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance35
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance36.BackColor = System.Drawing.SystemColors.Control
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance36
        Appearance37.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance38
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance39.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance39
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(12, 186)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1047, 351)
        Me.ugDetalle.TabIndex = 1
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(872, 86)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 32
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 608
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ColumnasAlineacion = Nothing
        Me.bscCodigoCliente.ColumnasAncho = Nothing
        Me.bscCodigoCliente.ColumnasFormato = Nothing
        Me.bscCodigoCliente.ColumnasOcultas = Nothing
        Me.bscCodigoCliente.ColumnasTitulos = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(80, 68)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 20
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(77, 54)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 19
        Me.lblCodigoCliente.Text = "Código"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'bscCliente
        '
        Me.bscCliente.AutoSize = True
        Me.bscCliente.AyudaAncho = 608
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ColumnasAlineacion = Nothing
        Me.bscCliente.ColumnasAncho = Nothing
        Me.bscCliente.ColumnasFormato = Nothing
        Me.bscCliente.ColumnasOcultas = Nothing
        Me.bscCliente.ColumnasTitulos = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.Enabled = False
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Me.lblNombre
        Me.bscCliente.Location = New System.Drawing.Point(177, 68)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 16
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(174, 54)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Nombre"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimirPrediseñado, Me.ToolStripSeparator4, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1071, 29)
        Me.tstBarra.TabIndex = 3
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbImprimirPrediseñado
        '
        Me.tsbImprimirPrediseñado.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimirPrediseñado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirPrediseñado.Name = "tsbImprimirPrediseñado"
        Me.tsbImprimirPrediseñado.Size = New System.Drawing.Size(147, 26)
        Me.tsbImprimirPrediseñado.Text = "&Imprimir Prediseñado"
        Me.tsbImprimirPrediseñado.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(15, 71)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 18
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(304, 19)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompleto.TabIndex = 3
        Me.chkMesCompleto.Text = "Mes C."
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'grbConsultar
        '
        Me.grbConsultar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbConsultar.Controls.Add(Me.chbSAE)
        Me.grbConsultar.Controls.Add(Me.chbEspmm)
        Me.grbConsultar.Controls.Add(Me.chbEspPulgadas)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.txtSAE)
        Me.grbConsultar.Controls.Add(Me.txtEspmm)
        Me.grbConsultar.Controls.Add(Me.txtEspPulgadas)
        Me.grbConsultar.Controls.Add(Me.chbVendedor)
        Me.grbConsultar.Controls.Add(Me.cmbVendedor)
        Me.grbConsultar.Controls.Add(Me.bscProducto2)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProducto2)
        Me.grbConsultar.Controls.Add(Me.chbFechaEntrega)
        Me.grbConsultar.Controls.Add(Me.chbFecha)
        Me.grbConsultar.Controls.Add(Me.lblEstado)
        Me.grbConsultar.Controls.Add(Me.chbTamanio)
        Me.grbConsultar.Controls.Add(Me.txtTamanio)
        Me.grbConsultar.Controls.Add(Me.chbProducto)
        Me.grbConsultar.Controls.Add(Me.cmbProduccionProceso)
        Me.grbConsultar.Controls.Add(Me.chbProduccionProceso)
        Me.grbConsultar.Controls.Add(Me.cmbMarca)
        Me.grbConsultar.Controls.Add(Me.chbMarca)
        Me.grbConsultar.Controls.Add(Me.cmbRubro)
        Me.grbConsultar.Controls.Add(Me.chbRubro)
        Me.grbConsultar.Controls.Add(Me.chbIdPedido)
        Me.grbConsultar.Controls.Add(Me.txtIdPedido)
        Me.grbConsultar.Controls.Add(Me.cmbEstados)
        Me.grbConsultar.Controls.Add(Me.chkExpandAll)
        Me.grbConsultar.Controls.Add(Me.chbUsuario)
        Me.grbConsultar.Controls.Add(Me.cmbUsuario)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.bscCliente)
        Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.lblNombre)
        Me.grbConsultar.Controls.Add(Me.chbCliente)
        Me.grbConsultar.Controls.Add(Me.chkMesCompletoEntrega)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpHastaEntrega)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesdeEntrega)
        Me.grbConsultar.Controls.Add(Me.Label2)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.Label1)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(1047, 157)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Filtros"
        '
        'chbSAE
        '
        Me.chbSAE.AutoSize = True
        Me.chbSAE.BindearPropiedadControl = Nothing
        Me.chbSAE.BindearPropiedadEntidad = Nothing
        Me.chbSAE.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSAE.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSAE.IsPK = False
        Me.chbSAE.IsRequired = False
        Me.chbSAE.Key = Nothing
        Me.chbSAE.LabelAsoc = Nothing
        Me.chbSAE.Location = New System.Drawing.Point(353, 156)
        Me.chbSAE.Name = "chbSAE"
        Me.chbSAE.Size = New System.Drawing.Size(47, 17)
        Me.chbSAE.TabIndex = 16
        Me.chbSAE.Text = "SAE"
        Me.chbSAE.UseVisualStyleBackColor = True
        Me.chbSAE.Visible = False
        '
        'chbEspmm
        '
        Me.chbEspmm.AutoSize = True
        Me.chbEspmm.BindearPropiedadControl = Nothing
        Me.chbEspmm.BindearPropiedadEntidad = Nothing
        Me.chbEspmm.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEspmm.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEspmm.IsPK = False
        Me.chbEspmm.IsRequired = False
        Me.chbEspmm.Key = Nothing
        Me.chbEspmm.LabelAsoc = Nothing
        Me.chbEspmm.Location = New System.Drawing.Point(179, 156)
        Me.chbEspmm.Name = "chbEspmm"
        Me.chbEspmm.Size = New System.Drawing.Size(66, 17)
        Me.chbEspmm.TabIndex = 16
        Me.chbEspmm.Text = "Esp. mm"
        Me.chbEspmm.UseVisualStyleBackColor = True
        Me.chbEspmm.Visible = False
        '
        'chbEspPulgadas
        '
        Me.chbEspPulgadas.AutoSize = True
        Me.chbEspPulgadas.BindearPropiedadControl = Nothing
        Me.chbEspPulgadas.BindearPropiedadEntidad = Nothing
        Me.chbEspPulgadas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEspPulgadas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEspPulgadas.IsPK = False
        Me.chbEspPulgadas.IsRequired = False
        Me.chbEspPulgadas.Key = Nothing
        Me.chbEspPulgadas.LabelAsoc = Nothing
        Me.chbEspPulgadas.Location = New System.Drawing.Point(15, 156)
        Me.chbEspPulgadas.Name = "chbEspPulgadas"
        Me.chbEspPulgadas.Size = New System.Drawing.Size(55, 17)
        Me.chbEspPulgadas.TabIndex = 16
        Me.chbEspPulgadas.Text = "Esp. """
        Me.chbEspPulgadas.UseVisualStyleBackColor = True
        Me.chbEspPulgadas.Visible = False
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(807, 17)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
        Me.cmbTiposComprobantes.TabIndex = 9
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(725, 21)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(76, 13)
        Me.lblTipoComprobante.TabIndex = 8
        Me.lblTipoComprobante.Text = "Tipo Comprob."
        '
        'txtSAE
        '
        Me.txtSAE.BackColor = System.Drawing.SystemColors.Window
        Me.txtSAE.BindearPropiedadControl = Nothing
        Me.txtSAE.BindearPropiedadEntidad = Nothing
        Me.txtSAE.Enabled = False
        Me.txtSAE.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSAE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSAE.Formato = ""
        Me.txtSAE.IsDecimal = False
        Me.txtSAE.IsNumber = True
        Me.txtSAE.IsPK = False
        Me.txtSAE.IsRequired = False
        Me.txtSAE.Key = ""
        Me.txtSAE.LabelAsoc = Nothing
        Me.txtSAE.Location = New System.Drawing.Point(406, 154)
        Me.txtSAE.MaxLength = 6
        Me.txtSAE.Name = "txtSAE"
        Me.txtSAE.Size = New System.Drawing.Size(90, 20)
        Me.txtSAE.TabIndex = 17
        Me.txtSAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSAE.Visible = False
        '
        'txtEspmm
        '
        Me.txtEspmm.BackColor = System.Drawing.SystemColors.Window
        Me.txtEspmm.BindearPropiedadControl = Nothing
        Me.txtEspmm.BindearPropiedadEntidad = Nothing
        Me.txtEspmm.Enabled = False
        Me.txtEspmm.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEspmm.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEspmm.Formato = "N3"
        Me.txtEspmm.IsDecimal = True
        Me.txtEspmm.IsNumber = True
        Me.txtEspmm.IsPK = False
        Me.txtEspmm.IsRequired = False
        Me.txtEspmm.Key = ""
        Me.txtEspmm.LabelAsoc = Nothing
        Me.txtEspmm.Location = New System.Drawing.Point(251, 154)
        Me.txtEspmm.MaxLength = 6
        Me.txtEspmm.Name = "txtEspmm"
        Me.txtEspmm.Size = New System.Drawing.Size(90, 20)
        Me.txtEspmm.TabIndex = 17
        Me.txtEspmm.Text = "0.000"
        Me.txtEspmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEspmm.Visible = False
        '
        'txtEspPulgadas
        '
        Me.txtEspPulgadas.BackColor = System.Drawing.SystemColors.Window
        Me.txtEspPulgadas.BindearPropiedadControl = Nothing
        Me.txtEspPulgadas.BindearPropiedadEntidad = Nothing
        Me.txtEspPulgadas.Enabled = False
        Me.txtEspPulgadas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEspPulgadas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEspPulgadas.Formato = ""
        Me.txtEspPulgadas.IsDecimal = False
        Me.txtEspPulgadas.IsNumber = False
        Me.txtEspPulgadas.IsPK = False
        Me.txtEspPulgadas.IsRequired = False
        Me.txtEspPulgadas.Key = ""
        Me.txtEspPulgadas.LabelAsoc = Nothing
        Me.txtEspPulgadas.Location = New System.Drawing.Point(80, 154)
        Me.txtEspPulgadas.MaxLength = 6
        Me.txtEspPulgadas.Name = "txtEspPulgadas"
        Me.txtEspPulgadas.Size = New System.Drawing.Size(90, 20)
        Me.txtEspPulgadas.TabIndex = 17
        Me.txtEspPulgadas.Visible = False
        '
        'chbVendedor
        '
        Me.chbVendedor.AutoSize = True
        Me.chbVendedor.BindearPropiedadControl = Nothing
        Me.chbVendedor.BindearPropiedadEntidad = Nothing
        Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVendedor.IsPK = False
        Me.chbVendedor.IsRequired = False
        Me.chbVendedor.Key = Nothing
        Me.chbVendedor.LabelAsoc = Nothing
        Me.chbVendedor.Location = New System.Drawing.Point(572, 101)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 23
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Enabled = False
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Location = New System.Drawing.Point(649, 99)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(140, 21)
        Me.cmbVendedor.TabIndex = 24
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.Enabled = False
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(234, 100)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(306, 20)
        Me.bscProducto2.TabIndex = 27
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.Enabled = False
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(80, 100)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto2.TabIndex = 26
        '
        'chbFechaEntrega
        '
        Me.chbFechaEntrega.AutoSize = True
        Me.chbFechaEntrega.BindearPropiedadControl = Nothing
        Me.chbFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.chbFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEntrega.IsPK = False
        Me.chbFechaEntrega.IsRequired = False
        Me.chbFechaEntrega.Key = Nothing
        Me.chbFechaEntrega.LabelAsoc = Nothing
        Me.chbFechaEntrega.Location = New System.Drawing.Point(207, 42)
        Me.chbFechaEntrega.Name = "chbFechaEntrega"
        Me.chbFechaEntrega.Size = New System.Drawing.Size(96, 17)
        Me.chbFechaEntrega.TabIndex = 10
        Me.chbFechaEntrega.Text = "Fecha Entrega"
        Me.chbFechaEntrega.UseVisualStyleBackColor = True
        Me.chbFechaEntrega.Visible = False
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
        Me.chbFecha.Location = New System.Drawing.Point(207, 19)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(116, 17)
        Me.chbFecha.TabIndex = 2
        Me.chbFecha.Text = "Fecha Orden Prod."
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(12, 21)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Estado"
        '
        'chbTamanio
        '
        Me.chbTamanio.AutoSize = True
        Me.chbTamanio.BindearPropiedadControl = Nothing
        Me.chbTamanio.BindearPropiedadEntidad = Nothing
        Me.chbTamanio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTamanio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTamanio.IsPK = False
        Me.chbTamanio.IsRequired = False
        Me.chbTamanio.Key = Nothing
        Me.chbTamanio.LabelAsoc = Nothing
        Me.chbTamanio.Location = New System.Drawing.Point(762, 156)
        Me.chbTamanio.Name = "chbTamanio"
        Me.chbTamanio.Size = New System.Drawing.Size(65, 17)
        Me.chbTamanio.TabIndex = 30
        Me.chbTamanio.Text = "Tamaño"
        Me.chbTamanio.UseVisualStyleBackColor = True
        Me.chbTamanio.Visible = False
        '
        'txtTamanio
        '
        Me.txtTamanio.BindearPropiedadControl = "Text"
        Me.txtTamanio.BindearPropiedadEntidad = "Tamano"
        Me.txtTamanio.Enabled = False
        Me.txtTamanio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanio.Formato = "#0.000"
        Me.txtTamanio.IsDecimal = True
        Me.txtTamanio.IsNumber = True
        Me.txtTamanio.IsPK = False
        Me.txtTamanio.IsRequired = False
        Me.txtTamanio.Key = ""
        Me.txtTamanio.LabelAsoc = Nothing
        Me.txtTamanio.Location = New System.Drawing.Point(828, 154)
        Me.txtTamanio.MaxLength = 7
        Me.txtTamanio.Name = "txtTamanio"
        Me.txtTamanio.Size = New System.Drawing.Size(65, 20)
        Me.txtTamanio.TabIndex = 31
        Me.txtTamanio.Text = "0.000"
        Me.txtTamanio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTamanio.Visible = False
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(15, 102)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 25
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'cmbProduccionProceso
        '
        Me.cmbProduccionProceso.BindearPropiedadControl = Nothing
        Me.cmbProduccionProceso.BindearPropiedadEntidad = Nothing
        Me.cmbProduccionProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProduccionProceso.Enabled = False
        Me.cmbProduccionProceso.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProduccionProceso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProduccionProceso.FormattingEnabled = True
        Me.cmbProduccionProceso.IsPK = False
        Me.cmbProduccionProceso.IsRequired = False
        Me.cmbProduccionProceso.Key = Nothing
        Me.cmbProduccionProceso.LabelAsoc = Nothing
        Me.cmbProduccionProceso.Location = New System.Drawing.Point(574, 154)
        Me.cmbProduccionProceso.Name = "cmbProduccionProceso"
        Me.cmbProduccionProceso.Size = New System.Drawing.Size(166, 21)
        Me.cmbProduccionProceso.TabIndex = 31
        Me.cmbProduccionProceso.Visible = False
        '
        'chbProduccionProceso
        '
        Me.chbProduccionProceso.AutoSize = True
        Me.chbProduccionProceso.BindearPropiedadControl = Nothing
        Me.chbProduccionProceso.BindearPropiedadEntidad = Nothing
        Me.chbProduccionProceso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProduccionProceso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProduccionProceso.IsPK = False
        Me.chbProduccionProceso.IsRequired = False
        Me.chbProduccionProceso.Key = Nothing
        Me.chbProduccionProceso.LabelAsoc = Nothing
        Me.chbProduccionProceso.Location = New System.Drawing.Point(509, 156)
        Me.chbProduccionProceso.Name = "chbProduccionProceso"
        Me.chbProduccionProceso.Size = New System.Drawing.Size(65, 17)
        Me.chbProduccionProceso.TabIndex = 30
        Me.chbProduccionProceso.Text = "Proceso"
        Me.chbProduccionProceso.UseVisualStyleBackColor = True
        Me.chbProduccionProceso.Visible = False
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = Nothing
        Me.cmbMarca.BindearPropiedadEntidad = Nothing
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = False
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Nothing
        Me.cmbMarca.Location = New System.Drawing.Point(80, 125)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(200, 21)
        Me.cmbMarca.TabIndex = 31
        '
        'chbMarca
        '
        Me.chbMarca.AutoSize = True
        Me.chbMarca.BindearPropiedadControl = Nothing
        Me.chbMarca.BindearPropiedadEntidad = Nothing
        Me.chbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarca.IsPK = False
        Me.chbMarca.IsRequired = False
        Me.chbMarca.Key = Nothing
        Me.chbMarca.LabelAsoc = Nothing
        Me.chbMarca.Location = New System.Drawing.Point(15, 127)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 30
        Me.chbMarca.Text = "Marca"
        Me.chbMarca.UseVisualStyleBackColor = True
        '
        'cmbRubro
        '
        Me.cmbRubro.BindearPropiedadControl = Nothing
        Me.cmbRubro.BindearPropiedadEntidad = Nothing
        Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubro.Enabled = False
        Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubro.FormattingEnabled = True
        Me.cmbRubro.IsPK = False
        Me.cmbRubro.IsRequired = False
        Me.cmbRubro.Key = Nothing
        Me.cmbRubro.LabelAsoc = Nothing
        Me.cmbRubro.Location = New System.Drawing.Point(353, 125)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(200, 21)
        Me.cmbRubro.TabIndex = 33
        '
        'chbRubro
        '
        Me.chbRubro.AutoSize = True
        Me.chbRubro.BindearPropiedadControl = Nothing
        Me.chbRubro.BindearPropiedadEntidad = Nothing
        Me.chbRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRubro.IsPK = False
        Me.chbRubro.IsRequired = False
        Me.chbRubro.Key = Nothing
        Me.chbRubro.LabelAsoc = Nothing
        Me.chbRubro.Location = New System.Drawing.Point(298, 127)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 32
        Me.chbRubro.Text = "Rubro"
        Me.chbRubro.UseVisualStyleBackColor = True
        '
        'chbIdPedido
        '
        Me.chbIdPedido.AutoSize = True
        Me.chbIdPedido.BindearPropiedadControl = Nothing
        Me.chbIdPedido.BindearPropiedadEntidad = Nothing
        Me.chbIdPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIdPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIdPedido.IsPK = False
        Me.chbIdPedido.IsRequired = False
        Me.chbIdPedido.Key = Nothing
        Me.chbIdPedido.LabelAsoc = Nothing
        Me.chbIdPedido.Location = New System.Drawing.Point(571, 75)
        Me.chbIdPedido.Name = "chbIdPedido"
        Me.chbIdPedido.Size = New System.Drawing.Size(63, 17)
        Me.chbIdPedido.TabIndex = 10
        Me.chbIdPedido.Text = "Número"
        Me.chbIdPedido.UseVisualStyleBackColor = True
        '
        'txtIdPedido
        '
        Me.txtIdPedido.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdPedido.BindearPropiedadControl = Nothing
        Me.txtIdPedido.BindearPropiedadEntidad = Nothing
        Me.txtIdPedido.Enabled = False
        Me.txtIdPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdPedido.Formato = ""
        Me.txtIdPedido.IsDecimal = False
        Me.txtIdPedido.IsNumber = True
        Me.txtIdPedido.IsPK = False
        Me.txtIdPedido.IsRequired = False
        Me.txtIdPedido.Key = ""
        Me.txtIdPedido.LabelAsoc = Nothing
        Me.txtIdPedido.Location = New System.Drawing.Point(648, 73)
        Me.txtIdPedido.MaxLength = 8
        Me.txtIdPedido.Name = "txtIdPedido"
        Me.txtIdPedido.Size = New System.Drawing.Size(65, 20)
        Me.txtIdPedido.TabIndex = 11
        Me.txtIdPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbEstados
        '
        Me.cmbEstados.BindearPropiedadControl = ""
        Me.cmbEstados.BindearPropiedadEntidad = ""
        Me.cmbEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.IsPK = False
        Me.cmbEstados.IsRequired = False
        Me.cmbEstados.Key = Nothing
        Me.cmbEstados.LabelAsoc = Me.lblEstado
        Me.cmbEstados.Location = New System.Drawing.Point(58, 17)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(140, 21)
        Me.cmbEstados.TabIndex = 1
        '
        'cmbUsuario
        '
        Me.cmbUsuario.BindearPropiedadControl = Nothing
        Me.cmbUsuario.BindearPropiedadEntidad = Nothing
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.Enabled = False
        Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.IsPK = False
        Me.cmbUsuario.IsRequired = False
        Me.cmbUsuario.Key = Nothing
        Me.cmbUsuario.LabelAsoc = Nothing
        Me.cmbUsuario.Location = New System.Drawing.Point(649, 125)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(140, 21)
        Me.cmbUsuario.TabIndex = 29
        '
        'chkMesCompletoEntrega
        '
        Me.chkMesCompletoEntrega.AutoSize = True
        Me.chkMesCompletoEntrega.BindearPropiedadControl = Nothing
        Me.chkMesCompletoEntrega.BindearPropiedadEntidad = Nothing
        Me.chkMesCompletoEntrega.Enabled = False
        Me.chkMesCompletoEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompletoEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompletoEntrega.IsPK = False
        Me.chkMesCompletoEntrega.IsRequired = False
        Me.chkMesCompletoEntrega.Key = Nothing
        Me.chkMesCompletoEntrega.LabelAsoc = Nothing
        Me.chkMesCompletoEntrega.Location = New System.Drawing.Point(304, 42)
        Me.chkMesCompletoEntrega.Name = "chkMesCompletoEntrega"
        Me.chkMesCompletoEntrega.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompletoEntrega.TabIndex = 11
        Me.chkMesCompletoEntrega.Text = "Mes C."
        Me.chkMesCompletoEntrega.UseVisualStyleBackColor = True
        Me.chkMesCompletoEntrega.Visible = False
        '
        'dtpHastaEntrega
        '
        Me.dtpHastaEntrega.BindearPropiedadControl = Nothing
        Me.dtpHastaEntrega.BindearPropiedadEntidad = Nothing
        Me.dtpHastaEntrega.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHastaEntrega.Enabled = False
        Me.dtpHastaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHastaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHastaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHastaEntrega.IsPK = False
        Me.dtpHastaEntrega.IsRequired = False
        Me.dtpHastaEntrega.Key = ""
        Me.dtpHastaEntrega.LabelAsoc = Me.Label2
        Me.dtpHastaEntrega.Location = New System.Drawing.Point(585, 40)
        Me.dtpHastaEntrega.Name = "dtpHastaEntrega"
        Me.dtpHastaEntrega.Size = New System.Drawing.Size(128, 20)
        Me.dtpHastaEntrega.TabIndex = 15
        Me.dtpHastaEntrega.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(544, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Hasta"
        Me.Label2.Visible = False
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
        Me.dtpHasta.Location = New System.Drawing.Point(585, 17)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 7
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(544, 21)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 6
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesdeEntrega
        '
        Me.dtpDesdeEntrega.BindearPropiedadControl = Nothing
        Me.dtpDesdeEntrega.BindearPropiedadEntidad = Nothing
        Me.dtpDesdeEntrega.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesdeEntrega.Enabled = False
        Me.dtpDesdeEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesdeEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesdeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesdeEntrega.IsPK = False
        Me.dtpDesdeEntrega.IsRequired = False
        Me.dtpDesdeEntrega.Key = ""
        Me.dtpDesdeEntrega.LabelAsoc = Me.Label1
        Me.dtpDesdeEntrega.Location = New System.Drawing.Point(407, 40)
        Me.dtpDesdeEntrega.Name = "dtpDesdeEntrega"
        Me.dtpDesdeEntrega.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesdeEntrega.TabIndex = 13
        Me.dtpDesdeEntrega.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(363, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Desde"
        Me.Label1.Visible = False
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
        Me.dtpDesde.Location = New System.Drawing.Point(407, 17)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 5
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(363, 21)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 4
        Me.lblDesde.Text = "Desde"
        '
        'InfOrdenesProduccionDetallado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 562)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbConsultar)
        Me.KeyPreview = True
        Me.Name = "InfOrdenesProduccionDetallado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe Ordenes de Produccion Detallado"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents cmbEstados As Eniac.Controles.ComboBox
   Friend WithEvents chbIdPedido As Eniac.Controles.CheckBox
   Friend WithEvents txtIdPedido As Eniac.Controles.TextBox
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbTamanio As Eniac.Controles.CheckBox
   Friend WithEvents txtTamanio As Eniac.Controles.TextBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbFechaEntrega As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompletoEntrega As Eniac.Controles.CheckBox
   Friend WithEvents dtpHastaEntrega As Eniac.Controles.DateTimePicker
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents dtpDesdeEntrega As Eniac.Controles.DateTimePicker
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents chbEspmm As Eniac.Controles.CheckBox
   Friend WithEvents chbEspPulgadas As Eniac.Controles.CheckBox
   Friend WithEvents txtEspmm As Eniac.Controles.TextBox
   Friend WithEvents txtEspPulgadas As Eniac.Controles.TextBox
   Friend WithEvents chbSAE As Eniac.Controles.CheckBox
   Friend WithEvents txtSAE As Eniac.Controles.TextBox
   Friend WithEvents cmbProduccionProceso As Eniac.Controles.ComboBox
   Friend WithEvents chbProduccionProceso As Eniac.Controles.CheckBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbImprimirPrediseñado As ToolStripButton
   Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
End Class