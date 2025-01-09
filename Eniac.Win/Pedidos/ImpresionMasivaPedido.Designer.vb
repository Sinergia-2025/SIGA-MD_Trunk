<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionMasivaPedido
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Cabecera", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcPendiente")
      Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anula")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Detalle")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadContactos", 0)
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Detalle", -1)
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocumento")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idProducto", -1, Nothing, 1625488251, 0, 0)
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto", -1, Nothing, 1625488251, 1, 0)
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano", -1, Nothing, 1625488251, 2, 0)
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida", -1, Nothing, 1625488251, 3, 0)
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fechaEstado", -1, Nothing, 1625488251, 5, 0)
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado", -1, Nothing, 1625488251, 6, 0)
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEstado", -1, Nothing, 1625488251, 8, 0)
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantPendiente", -1, Nothing, 1625488251, 7, 0)
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteFact", -1, Nothing, 1625488266, 0, 0)
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraFact", -1, Nothing, 1625488266, 1, 0)
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorFact", -1, Nothing, 1625488266, 2, 0)
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteFact", -1, Nothing, 1625488266, 3, 0)
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imprimir")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCriticidad")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios", -1, Nothing, 1625488251, 9, 0)
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalRemito")
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteRemito", -1, Nothing, 1625488267, 0, 0)
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraRemito", -1, Nothing, 1625488267, 1, 0)
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorRemito", -1, Nothing, 1625488267, 2, 0)
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteRemito", -1, Nothing, 1625488267, 3, 0)
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion", -1, Nothing, 1625488251, 10, 0)
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota", -1, Nothing, 1625488251, 11, 0)
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalGenerado", -1, Nothing, 1625488268, 0, 0)
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteGenerado", -1, Nothing, 1625488268, 1, 0)
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraGenerado", -1, Nothing, 1625488268, 2, 0)
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorGenerado", -1, Nothing, 1625488268, 3, 0)
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedidoGenerado", -1, Nothing, 1625488268, 4, 0)
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalProduccion", -1, Nothing, 1625488269, 0, 0)
      Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteProduccion", -1, Nothing, 1625488269, 1, 0)
      Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraProduccion", -1, Nothing, 1625488269, 2, 0)
      Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorProduccion", -1, Nothing, 1625488269, 3, 0)
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion", -1, Nothing, 1625488269, 4, 0)
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoProduccion", -1, Nothing, 1625488269, 5, 0)
      Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenProduccion", -1, Nothing, 1625488269, 6, 0)
      Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalVinculado", -1, Nothing, 1625488270, 0, 0)
      Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteVinculado", -1, Nothing, 1625488270, 1, 0)
      Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraVinculado", -1, Nothing, 1625488270, 2, 0)
      Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorVinculado", -1, Nothing, 1625488270, 3, 0)
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedidoVinculado", -1, Nothing, 1625488270, 4, 0)
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoVinculado", -1, Nothing, 1625488270, 5, 0)
      Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenVinculado", -1, Nothing, 1625488270, 6, 0)
      Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstadoVinculado", -1, Nothing, 1625488270, 7, 0)
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobante")
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ClipArchivoAdjunto", 0, Nothing, 1625488251, 4, 0)
      Dim UltraGridGroup1 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Detalle", 1625488251)
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup2 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("FACT", 1625488266)
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup3 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("REMITO", 1625488267)
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup4 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("GENERADO", 1625488268)
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup5 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("PRODUCCION", 1625488269)
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup6 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("VINCULADO", 1625488270)
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobante", -1)
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCaja")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPlanilla")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimiento")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePesos")
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.lblImpreso = New Eniac.Controles.Label()
      Me.cmbImpreso = New Eniac.Controles.ComboBox()
      Me.lblEstadoComprobante = New Eniac.Controles.Label()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.cmbOrigenCategoria = New Eniac.Controles.ComboBox()
      Me.cmbCategoria = New Eniac.Win.ComboBoxCategorias()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.txtNroRepartoHasta = New Eniac.Controles.TextBox()
      Me.lblNroRepartoHasta = New Eniac.Controles.Label()
      Me.txtNroReparto = New Eniac.Controles.TextBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.chbFormaPago = New Eniac.Controles.CheckBox()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.cmbEstadoComprobante = New Eniac.Controles.ComboBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador()
      Me.bscCliente = New Eniac.Controles.Buscador()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbLetra = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.txtEmisor = New Eniac.Controles.TextBox()
      Me.lblEmisor = New Eniac.Controles.Label()
      Me.cmbLetras = New Eniac.Controles.ComboBox()
      Me.txtNroHasta = New Eniac.Controles.TextBox()
      Me.lblNroHasta = New Eniac.Controles.Label()
      Me.txtNroDesde = New Eniac.Controles.TextBox()
      Me.lblNroDesde = New Eniac.Controles.Label()
      Me.chbNumeroRep = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'FolderBrowserDialog1
      '
      Me.FolderBrowserDialog1.Description = "Seleccione la carpeta donde desea exportar los archivos"
      '
      'ugDetalle
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn1.Header.Caption = "Sucursal"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn4.Header.Caption = "Tipo"
      UltraGridColumn4.Header.VisiblePosition = 2
      UltraGridColumn4.Width = 70
      UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn5.Header.Caption = "L."
      UltraGridColumn5.Header.VisiblePosition = 3
      UltraGridColumn5.Width = 25
      UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn44.Header.Caption = "Emisor"
      UltraGridColumn44.Header.VisiblePosition = 4
      UltraGridColumn44.Width = 50
      UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn45.Header.Caption = "Número"
      UltraGridColumn45.Header.VisiblePosition = 5
      UltraGridColumn45.Width = 70
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn3.Format = "dd/MM/yyyy HH:mm"
      UltraGridColumn3.Header.Caption = "Fecha"
      UltraGridColumn3.Header.VisiblePosition = 6
      UltraGridColumn3.Width = 100
      UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn42.Header.VisiblePosition = 7
      UltraGridColumn42.Hidden = True
      UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn43.Header.Caption = "Codigo"
      UltraGridColumn43.Header.VisiblePosition = 8
      UltraGridColumn43.Width = 70
      UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn6.Header.Caption = "Cliente"
      UltraGridColumn6.Header.VisiblePosition = 9
      UltraGridColumn6.Width = 200
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn8.Header.Caption = "Observación"
      UltraGridColumn8.Header.VisiblePosition = 15
      UltraGridColumn8.Width = 250
      UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn9.Header.VisiblePosition = 14
      UltraGridColumn9.Width = 70
      UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn12.Header.Caption = "Orden Compra"
      UltraGridColumn12.Header.VisiblePosition = 11
      UltraGridColumn12.Width = 74
      UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn22.Format = "N2"
      UltraGridColumn22.Header.Caption = "Total"
      UltraGridColumn22.Header.VisiblePosition = 12
      UltraGridColumn22.Width = 70
      UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn51.Format = "N2"
      UltraGridColumn51.Header.Caption = "% Pendiente"
      UltraGridColumn51.Header.VisiblePosition = 13
      UltraGridColumn51.Width = 66
      UltraGridColumn83.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
      UltraGridColumn83.Header.Caption = ""
      UltraGridColumn83.Header.VisiblePosition = 1
      UltraGridColumn83.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn83.Width = 40
      UltraGridColumn10.Header.VisiblePosition = 16
      UltraGridColumn28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
      UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn28.Header.Caption = "Contactos"
      UltraGridColumn28.Header.VisiblePosition = 10
      UltraGridColumn28.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
      UltraGridColumn28.Width = 63
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn4, UltraGridColumn5, UltraGridColumn44, UltraGridColumn45, UltraGridColumn3, UltraGridColumn42, UltraGridColumn43, UltraGridColumn6, UltraGridColumn8, UltraGridColumn9, UltraGridColumn12, UltraGridColumn22, UltraGridColumn51, UltraGridColumn83, UltraGridColumn10, UltraGridColumn28})
      UltraGridBand1.SummaryFooterCaption = "Totales:"
      UltraGridColumn11.Header.Caption = "Sucursal"
      UltraGridColumn11.Header.VisiblePosition = 0
      UltraGridColumn11.Hidden = True
      UltraGridColumn11.Width = 41
      UltraGridColumn25.Header.Caption = "Tipo Comprobante"
      UltraGridColumn25.Header.VisiblePosition = 7
      UltraGridColumn25.Hidden = True
      UltraGridColumn26.Header.VisiblePosition = 8
      UltraGridColumn26.Hidden = True
      UltraGridColumn27.Header.Caption = "Centro Emisor"
      UltraGridColumn27.Header.VisiblePosition = 13
      UltraGridColumn27.Hidden = True
      UltraGridColumn50.Header.VisiblePosition = 3
      UltraGridColumn50.Hidden = True
      UltraGridColumn13.Header.Caption = "Fecha Pedido"
      UltraGridColumn13.Header.VisiblePosition = 1
      UltraGridColumn13.Hidden = True
      UltraGridColumn13.Width = 200
      UltraGridColumn14.Header.Caption = "Tipo Documento"
      UltraGridColumn14.Header.VisiblePosition = 2
      UltraGridColumn14.Hidden = True
      UltraGridColumn14.Width = 70
      UltraGridColumn15.Header.Caption = "Nro Documento"
      UltraGridColumn15.Header.VisiblePosition = 4
      UltraGridColumn15.Hidden = True
      UltraGridColumn15.Width = 250
      UltraGridColumn16.Header.Caption = "Cliente"
      UltraGridColumn16.Header.VisiblePosition = 5
      UltraGridColumn16.Hidden = True
      UltraGridColumn17.Header.Caption = "Nro.Prod."
      UltraGridColumn18.Header.Caption = "Producto"
      UltraGridColumn18.Width = 200
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn19.CellAppearance = Appearance2
      UltraGridColumn19.Format = "N2"
      UltraGridColumn19.Header.Caption = "Tamaño"
      UltraGridColumn19.Width = 60
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn7.CellAppearance = Appearance3
      UltraGridColumn7.Header.Caption = "U.M."
      UltraGridColumn7.Width = 40
      UltraGridColumn20.Header.VisiblePosition = 6
      UltraGridColumn20.Hidden = True
      Appearance4.TextHAlignAsString = "Center"
      UltraGridColumn21.CellAppearance = Appearance4
      UltraGridColumn21.Header.Caption = "Fecha Estado"
      UltraGridColumn21.Width = 90
      Appearance5.FontData.BoldAsString = "True"
      UltraGridColumn2.CellAppearance = Appearance5
      UltraGridColumn2.Header.Caption = "Estado"
      UltraGridColumn2.Width = 90
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn23.CellAppearance = Appearance6
      UltraGridColumn23.Header.Caption = "Cant. Estado"
      UltraGridColumn23.Width = 75
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn24.CellAppearance = Appearance7
      UltraGridColumn24.Header.Caption = "Cant. Pendiente"
      UltraGridColumn24.Width = 75
      UltraGridColumn46.Header.Caption = "Comprob."
      UltraGridColumn46.Width = 65
      UltraGridColumn47.Header.Caption = "L."
      UltraGridColumn47.Width = 20
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn48.CellAppearance = Appearance8
      UltraGridColumn48.Header.Caption = "Emis."
      UltraGridColumn48.Width = 40
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn49.CellAppearance = Appearance9
      UltraGridColumn49.Header.Caption = "Número"
      UltraGridColumn49.Width = 70
      UltraGridColumn29.Header.Caption = "Usuario"
      UltraGridColumn29.Header.VisiblePosition = 22
      UltraGridColumn29.Hidden = True
      UltraGridColumn30.Header.Caption = "Observación"
      UltraGridColumn30.Header.VisiblePosition = 23
      UltraGridColumn30.Hidden = True
      UltraGridColumn31.Header.VisiblePosition = 24
      UltraGridColumn31.Hidden = True
      UltraGridColumn32.Header.Caption = "Criticidad"
      UltraGridColumn32.Header.VisiblePosition = 25
      UltraGridColumn32.Hidden = True
      UltraGridColumn33.Format = "dd/MM/yyyy"
      UltraGridColumn33.Header.Caption = "Fecha Entrega"
      UltraGridColumn33.Header.VisiblePosition = 26
      UltraGridColumn33.Hidden = True
      UltraGridColumn53.Header.VisiblePosition = 27
      UltraGridColumn53.Hidden = True
      UltraGridColumn54.Header.Caption = "Lista de Precios"
      UltraGridColumn54.Width = 100
      UltraGridColumn55.Header.VisiblePosition = 29
      UltraGridColumn55.Hidden = True
      UltraGridColumn56.Header.Caption = "Comprob."
      UltraGridColumn56.Width = 65
      UltraGridColumn57.Header.Caption = "L."
      UltraGridColumn57.Width = 20
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn58.CellAppearance = Appearance10
      UltraGridColumn58.Header.Caption = "Emis."
      UltraGridColumn58.Width = 40
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn59.CellAppearance = Appearance11
      UltraGridColumn59.Header.Caption = "Número"
      UltraGridColumn59.Width = 70
      UltraGridColumn61.Header.Caption = "Tp. Oper."
      UltraGridColumn61.Width = 62
      UltraGridColumn62.Width = 150
      UltraGridColumn63.Hidden = True
      UltraGridColumn64.Header.Caption = "Comprob."
      UltraGridColumn64.Width = 65
      UltraGridColumn65.Header.Caption = "L."
      UltraGridColumn65.Width = 20
      Appearance12.TextHAlignAsString = "Right"
      UltraGridColumn66.CellAppearance = Appearance12
      UltraGridColumn66.Header.Caption = "Emis."
      UltraGridColumn66.Width = 40
      Appearance13.TextHAlignAsString = "Right"
      UltraGridColumn67.CellAppearance = Appearance13
      UltraGridColumn67.Header.Caption = "Número"
      UltraGridColumn67.Width = 70
      UltraGridColumn68.Hidden = True
      UltraGridColumn69.Header.Caption = "Comprob."
      UltraGridColumn69.Width = 65
      UltraGridColumn70.Header.Caption = "L."
      UltraGridColumn70.Width = 20
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn71.CellAppearance = Appearance14
      UltraGridColumn71.Header.Caption = "Emis."
      UltraGridColumn71.Width = 40
      Appearance15.TextHAlignAsString = "Right"
      UltraGridColumn72.CellAppearance = Appearance15
      UltraGridColumn72.Header.Caption = "Número"
      UltraGridColumn72.Width = 70
      UltraGridColumn73.Hidden = True
      UltraGridColumn74.Hidden = True
      UltraGridColumn75.Hidden = True
      UltraGridColumn76.Header.Caption = "Comprob."
      UltraGridColumn76.Width = 65
      UltraGridColumn77.Header.Caption = "L."
      UltraGridColumn77.Width = 20
      Appearance16.TextHAlignAsString = "Right"
      UltraGridColumn78.CellAppearance = Appearance16
      UltraGridColumn78.Header.Caption = "Emis."
      UltraGridColumn78.Width = 40
      Appearance17.TextHAlignAsString = "Right"
      UltraGridColumn79.CellAppearance = Appearance17
      UltraGridColumn79.Header.Caption = "Número"
      UltraGridColumn79.Width = 70
      UltraGridColumn80.Hidden = True
      UltraGridColumn81.Hidden = True
      UltraGridColumn82.Hidden = True
      UltraGridColumn34.Header.VisiblePosition = 56
      UltraGridColumn52.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
      UltraGridColumn52.Header.Caption = ""
      UltraGridColumn52.MaxWidth = 20
      UltraGridColumn52.Width = 14
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn11, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn50, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn7, UltraGridColumn20, UltraGridColumn21, UltraGridColumn2, UltraGridColumn23, UltraGridColumn24, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn34, UltraGridColumn52})
      Appearance18.FontData.BoldAsString = "True"
      UltraGridGroup1.Header.Appearance = Appearance18
      UltraGridGroup1.Key = "Detalle"
      UltraGridGroup1.RowLayoutGroupInfo.LabelSpan = 1
      Appearance19.FontData.BoldAsString = "True"
      UltraGridGroup2.Header.Appearance = Appearance19
      UltraGridGroup2.Header.Caption = "Facturó"
      UltraGridGroup2.Key = "FACT"
      UltraGridGroup2.RowLayoutGroupInfo.LabelSpan = 1
      Appearance20.FontData.BoldAsString = "True"
      UltraGridGroup3.Header.Appearance = Appearance20
      UltraGridGroup3.Header.Caption = "Remitió"
      UltraGridGroup3.Key = "REMITO"
      UltraGridGroup3.RowLayoutGroupInfo.LabelSpan = 1
      Appearance21.FontData.BoldAsString = "True"
      UltraGridGroup4.Header.Appearance = Appearance21
      UltraGridGroup4.Header.Caption = "Pedido Generado"
      UltraGridGroup4.Key = "GENERADO"
      UltraGridGroup4.RowLayoutGroupInfo.LabelSpan = 1
      Appearance22.FontData.BoldAsString = "True"
      UltraGridGroup5.Header.Appearance = Appearance22
      UltraGridGroup5.Header.Caption = "Orden de Producción"
      UltraGridGroup5.Key = "PRODUCCION"
      UltraGridGroup5.RowLayoutGroupInfo.LabelSpan = 1
      Appearance23.FontData.BoldAsString = "True"
      UltraGridGroup6.Header.Appearance = Appearance23
      UltraGridGroup6.Header.Caption = "Pedido de Compra Vinculado"
      UltraGridGroup6.Key = "VINCULADO"
      UltraGridGroup6.RowLayoutGroupInfo.LabelSpan = 1
      UltraGridBand2.Groups.AddRange(New Infragistics.Win.UltraWinGrid.UltraGridGroup() {UltraGridGroup1, UltraGridGroup2, UltraGridGroup3, UltraGridGroup4, UltraGridGroup5, UltraGridGroup6})
      UltraGridColumn35.Header.VisiblePosition = 1
      UltraGridColumn35.Width = 79
      UltraGridColumn36.Header.VisiblePosition = 2
      UltraGridColumn36.Width = 318
      UltraGridColumn37.Header.Caption = "Id Caja"
      UltraGridColumn37.Header.VisiblePosition = 3
      UltraGridColumn37.Width = 54
      UltraGridColumn38.Header.Caption = "Numero Planilla"
      UltraGridColumn38.Header.VisiblePosition = 4
      UltraGridColumn38.Width = 96
      UltraGridColumn39.Header.Caption = "Numero Movimiento"
      UltraGridColumn39.Header.VisiblePosition = 5
      UltraGridColumn39.Width = 114
      UltraGridColumn40.Header.Caption = "Importe Pesos"
      UltraGridColumn40.Header.VisiblePosition = 6
      UltraGridColumn41.Header.Caption = "Importe Total"
      UltraGridColumn41.Header.VisiblePosition = 7
      UltraGridColumn60.Header.Caption = "Comprob."
      UltraGridColumn60.Header.VisiblePosition = 0
      UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn60})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance24.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance24.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance24
      Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance25
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance26.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance26.BackColor2 = System.Drawing.SystemColors.Control
      Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance26
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance27.BackColor = System.Drawing.SystemColors.Window
      Appearance27.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance27
      Appearance28.BackColor = System.Drawing.SystemColors.Highlight
      Appearance28.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance28
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance29.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance29
      Appearance30.BorderColor = System.Drawing.Color.Silver
      Appearance30.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance30
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance31.BackColor = System.Drawing.SystemColors.Control
      Appearance31.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance31.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance31.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance31
      Appearance32.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance32
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance33.BackColor = System.Drawing.SystemColors.Window
      Appearance33.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance33
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance34.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance34
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(0, 150)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(984, 389)
      Me.ugDetalle.TabIndex = 5
      Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
      Me.ugDetalle.ToolStripMenuExpandir = Nothing
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.lblImpreso)
      Me.grbFiltros.Controls.Add(Me.cmbImpreso)
      Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbFiltros.Controls.Add(Me.cmbOrigenCategoria)
      Me.grbFiltros.Controls.Add(Me.cmbCategoria)
      Me.grbFiltros.Controls.Add(Me.lblCategoria)
      Me.grbFiltros.Controls.Add(Me.txtNroRepartoHasta)
      Me.grbFiltros.Controls.Add(Me.txtNroReparto)
      Me.grbFiltros.Controls.Add(Me.chbUsuario)
      Me.grbFiltros.Controls.Add(Me.cmbUsuario)
      Me.grbFiltros.Controls.Add(Me.chbFormaPago)
      Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
      Me.grbFiltros.Controls.Add(Me.chbVendedor)
      Me.grbFiltros.Controls.Add(Me.cmbVendedor)
      Me.grbFiltros.Controls.Add(Me.lblNroRepartoHasta)
      Me.grbFiltros.Controls.Add(Me.cmbEstadoComprobante)
      Me.grbFiltros.Controls.Add(Me.lblEstadoComprobante)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.bscCliente)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Controls.Add(Me.chbLetra)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Controls.Add(Me.txtEmisor)
      Me.grbFiltros.Controls.Add(Me.lblEmisor)
      Me.grbFiltros.Controls.Add(Me.cmbLetras)
      Me.grbFiltros.Controls.Add(Me.txtNroHasta)
      Me.grbFiltros.Controls.Add(Me.lblNroHasta)
      Me.grbFiltros.Controls.Add(Me.txtNroDesde)
      Me.grbFiltros.Controls.Add(Me.lblNroDesde)
      Me.grbFiltros.Controls.Add(Me.lblTipoComprobante)
      Me.grbFiltros.Controls.Add(Me.chbNumeroRep)
      Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
      Me.grbFiltros.Location = New System.Drawing.Point(0, 29)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(984, 121)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'lblImpreso
      '
      Me.lblImpreso.AutoSize = True
      Me.lblImpreso.LabelAsoc = Nothing
      Me.lblImpreso.Location = New System.Drawing.Point(520, 19)
      Me.lblImpreso.Name = "lblImpreso"
      Me.lblImpreso.Size = New System.Drawing.Size(44, 13)
      Me.lblImpreso.TabIndex = 5
      Me.lblImpreso.Text = "Impreso"
      '
      'cmbImpreso
      '
      Me.cmbImpreso.BindearPropiedadControl = Nothing
      Me.cmbImpreso.BindearPropiedadEntidad = Nothing
      Me.cmbImpreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbImpreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbImpreso.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbImpreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbImpreso.FormattingEnabled = True
      Me.cmbImpreso.IsPK = False
      Me.cmbImpreso.IsRequired = False
      Me.cmbImpreso.Key = Nothing
      Me.cmbImpreso.LabelAsoc = Me.lblEstadoComprobante
      Me.cmbImpreso.Location = New System.Drawing.Point(570, 15)
      Me.cmbImpreso.Name = "cmbImpreso"
      Me.cmbImpreso.Size = New System.Drawing.Size(67, 21)
      Me.cmbImpreso.TabIndex = 6
      '
      'lblEstadoComprobante
      '
      Me.lblEstadoComprobante.AutoSize = True
      Me.lblEstadoComprobante.LabelAsoc = Nothing
      Me.lblEstadoComprobante.Location = New System.Drawing.Point(679, 19)
      Me.lblEstadoComprobante.Name = "lblEstadoComprobante"
      Me.lblEstadoComprobante.Size = New System.Drawing.Size(40, 13)
      Me.lblEstadoComprobante.TabIndex = 7
      Me.lblEstadoComprobante.Text = "Estado"
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
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(91, 69)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(162, 21)
      Me.cmbTiposComprobantes.TabIndex = 18
      '
      'lblTipoComprobante
      '
      Me.lblTipoComprobante.AutoSize = True
      Me.lblTipoComprobante.LabelAsoc = Nothing
      Me.lblTipoComprobante.Location = New System.Drawing.Point(5, 73)
      Me.lblTipoComprobante.Name = "lblTipoComprobante"
      Me.lblTipoComprobante.Size = New System.Drawing.Size(70, 13)
      Me.lblTipoComprobante.TabIndex = 17
      Me.lblTipoComprobante.Text = "Comprobante"
      '
      'cmbOrigenCategoria
      '
      Me.cmbOrigenCategoria.BindearPropiedadControl = Nothing
      Me.cmbOrigenCategoria.BindearPropiedadEntidad = Nothing
      Me.cmbOrigenCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbOrigenCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbOrigenCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbOrigenCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbOrigenCategoria.FormattingEnabled = True
      Me.cmbOrigenCategoria.IsPK = False
      Me.cmbOrigenCategoria.IsRequired = False
      Me.cmbOrigenCategoria.Key = Nothing
      Me.cmbOrigenCategoria.LabelAsoc = Nothing
      Me.cmbOrigenCategoria.Location = New System.Drawing.Point(883, 42)
      Me.cmbOrigenCategoria.Name = "cmbOrigenCategoria"
      Me.cmbOrigenCategoria.Size = New System.Drawing.Size(83, 21)
      Me.cmbOrigenCategoria.TabIndex = 16
      '
      'cmbCategoria
      '
      Me.cmbCategoria.BindearPropiedadControl = Nothing
      Me.cmbCategoria.BindearPropiedadEntidad = Nothing
      Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoria.FormattingEnabled = True
      Me.cmbCategoria.IsPK = False
      Me.cmbCategoria.IsRequired = False
      Me.cmbCategoria.Key = Nothing
      Me.cmbCategoria.LabelAsoc = Me.lblCategoria
      Me.cmbCategoria.Location = New System.Drawing.Point(734, 42)
      Me.cmbCategoria.Name = "cmbCategoria"
      Me.cmbCategoria.Size = New System.Drawing.Size(147, 21)
      Me.cmbCategoria.TabIndex = 15
      '
      'lblCategoria
      '
      Me.lblCategoria.AutoSize = True
      Me.lblCategoria.LabelAsoc = Nothing
      Me.lblCategoria.Location = New System.Drawing.Point(679, 46)
      Me.lblCategoria.Name = "lblCategoria"
      Me.lblCategoria.Size = New System.Drawing.Size(54, 13)
      Me.lblCategoria.TabIndex = 14
      Me.lblCategoria.Text = "Categoría"
      '
      'txtNroRepartoHasta
      '
      Me.txtNroRepartoHasta.BindearPropiedadControl = Nothing
      Me.txtNroRepartoHasta.BindearPropiedadEntidad = Nothing
      Me.txtNroRepartoHasta.Enabled = False
      Me.txtNroRepartoHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroRepartoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroRepartoHasta.Formato = "##0"
      Me.txtNroRepartoHasta.IsDecimal = False
      Me.txtNroRepartoHasta.IsNumber = True
      Me.txtNroRepartoHasta.IsPK = False
      Me.txtNroRepartoHasta.IsRequired = False
      Me.txtNroRepartoHasta.Key = ""
      Me.txtNroRepartoHasta.LabelAsoc = Me.lblNroRepartoHasta
      Me.txtNroRepartoHasta.Location = New System.Drawing.Point(789, 69)
      Me.txtNroRepartoHasta.MaxLength = 8
      Me.txtNroRepartoHasta.Name = "txtNroRepartoHasta"
      Me.txtNroRepartoHasta.Size = New System.Drawing.Size(57, 20)
      Me.txtNroRepartoHasta.TabIndex = 30
      Me.txtNroRepartoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNroRepartoHasta
      '
      Me.lblNroRepartoHasta.AutoSize = True
      Me.lblNroRepartoHasta.LabelAsoc = Nothing
      Me.lblNroRepartoHasta.Location = New System.Drawing.Point(776, 73)
      Me.lblNroRepartoHasta.Name = "lblNroRepartoHasta"
      Me.lblNroRepartoHasta.Size = New System.Drawing.Size(13, 13)
      Me.lblNroRepartoHasta.TabIndex = 29
      Me.lblNroRepartoHasta.Text = "a"
      '
      'txtNroReparto
      '
      Me.txtNroReparto.BindearPropiedadControl = Nothing
      Me.txtNroReparto.BindearPropiedadEntidad = Nothing
      Me.txtNroReparto.Enabled = False
      Me.txtNroReparto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroReparto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroReparto.Formato = "##0"
      Me.txtNroReparto.IsDecimal = False
      Me.txtNroReparto.IsNumber = True
      Me.txtNroReparto.IsPK = False
      Me.txtNroReparto.IsRequired = False
      Me.txtNroReparto.Key = ""
      Me.txtNroReparto.LabelAsoc = Nothing
      Me.txtNroReparto.Location = New System.Drawing.Point(718, 69)
      Me.txtNroReparto.MaxLength = 8
      Me.txtNroReparto.Name = "txtNroReparto"
      Me.txtNroReparto.Size = New System.Drawing.Size(57, 20)
      Me.txtNroReparto.TabIndex = 28
      Me.txtNroReparto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.chbUsuario.Location = New System.Drawing.Point(493, 97)
      Me.chbUsuario.Name = "chbUsuario"
      Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuario.TabIndex = 35
      Me.chbUsuario.Text = "Usuario"
      Me.chbUsuario.UseVisualStyleBackColor = True
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
      Me.cmbUsuario.Location = New System.Drawing.Point(566, 95)
      Me.cmbUsuario.Name = "cmbUsuario"
      Me.cmbUsuario.Size = New System.Drawing.Size(148, 21)
      Me.cmbUsuario.TabIndex = 36
      '
      'chbFormaPago
      '
      Me.chbFormaPago.AutoSize = True
      Me.chbFormaPago.BindearPropiedadControl = Nothing
      Me.chbFormaPago.BindearPropiedadEntidad = Nothing
      Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFormaPago.IsPK = False
      Me.chbFormaPago.IsRequired = False
      Me.chbFormaPago.Key = Nothing
      Me.chbFormaPago.LabelAsoc = Nothing
      Me.chbFormaPago.Location = New System.Drawing.Point(260, 97)
      Me.chbFormaPago.Name = "chbFormaPago"
      Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
      Me.chbFormaPago.TabIndex = 33
      Me.chbFormaPago.Text = "Forma de Pago"
      Me.chbFormaPago.UseVisualStyleBackColor = True
      '
      'cmbFormaPago
      '
      Me.cmbFormaPago.BindearPropiedadControl = Nothing
      Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
      Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormaPago.Enabled = False
      Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormaPago.FormattingEnabled = True
      Me.cmbFormaPago.IsPK = False
      Me.cmbFormaPago.IsRequired = False
      Me.cmbFormaPago.Key = Nothing
      Me.cmbFormaPago.LabelAsoc = Nothing
      Me.cmbFormaPago.Location = New System.Drawing.Point(362, 95)
      Me.cmbFormaPago.Name = "cmbFormaPago"
      Me.cmbFormaPago.Size = New System.Drawing.Size(119, 21)
      Me.cmbFormaPago.TabIndex = 34
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
      Me.chbVendedor.Location = New System.Drawing.Point(5, 97)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 31
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
      Me.cmbVendedor.Location = New System.Drawing.Point(91, 95)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(162, 21)
      Me.cmbVendedor.TabIndex = 32
      '
      'cmbEstadoComprobante
      '
      Me.cmbEstadoComprobante.BindearPropiedadControl = Nothing
      Me.cmbEstadoComprobante.BindearPropiedadEntidad = Nothing
      Me.cmbEstadoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEstadoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoComprobante.FormattingEnabled = True
      Me.cmbEstadoComprobante.IsPK = False
      Me.cmbEstadoComprobante.IsRequired = False
      Me.cmbEstadoComprobante.Key = Nothing
      Me.cmbEstadoComprobante.LabelAsoc = Me.lblEstadoComprobante
      Me.cmbEstadoComprobante.Location = New System.Drawing.Point(734, 15)
      Me.cmbEstadoComprobante.Name = "cmbEstadoComprobante"
      Me.cmbEstadoComprobante.Size = New System.Drawing.Size(147, 21)
      Me.cmbEstadoComprobante.TabIndex = 8
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
      Me.bscCodigoCliente.LabelAsoc = Nothing
      Me.bscCodigoCliente.Location = New System.Drawing.Point(83, 41)
      Me.bscCodigoCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 11
      Me.bscCodigoCliente.Titulo = Nothing
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
      Me.bscCliente.LabelAsoc = Nothing
      Me.bscCliente.Location = New System.Drawing.Point(180, 39)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(290, 27)
      Me.bscCliente.TabIndex = 13
      Me.bscCliente.Titulo = Nothing
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
      Me.chbCliente.Location = New System.Drawing.Point(5, 44)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 9
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'chbLetra
      '
      Me.chbLetra.AutoSize = True
      Me.chbLetra.BindearPropiedadControl = Nothing
      Me.chbLetra.BindearPropiedadEntidad = Nothing
      Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLetra.IsPK = False
      Me.chbLetra.IsRequired = False
      Me.chbLetra.Key = Nothing
      Me.chbLetra.LabelAsoc = Nothing
      Me.chbLetra.Location = New System.Drawing.Point(260, 71)
      Me.chbLetra.Name = "chbLetra"
      Me.chbLetra.Size = New System.Drawing.Size(50, 17)
      Me.chbLetra.TabIndex = 19
      Me.chbLetra.Text = "Letra"
      Me.chbLetra.UseVisualStyleBackColor = True
      '
      'chkMesCompleto
      '
      Me.chkMesCompleto.AutoSize = True
      Me.chkMesCompleto.BindearPropiedadControl = Nothing
      Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
      Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
      Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkMesCompleto.IsPK = False
      Me.chkMesCompleto.IsRequired = False
      Me.chkMesCompleto.Key = Nothing
      Me.chkMesCompleto.LabelAsoc = Nothing
      Me.chkMesCompleto.Location = New System.Drawing.Point(5, 17)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 0
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(314, 15)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(277, 19)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 3
      Me.lblHasta.Text = "Hasta"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(146, 15)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(102, 19)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'txtEmisor
      '
      Me.txtEmisor.BindearPropiedadControl = Nothing
      Me.txtEmisor.BindearPropiedadEntidad = Nothing
      Me.txtEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEmisor.Formato = ""
      Me.txtEmisor.IsDecimal = False
      Me.txtEmisor.IsNumber = True
      Me.txtEmisor.IsPK = False
      Me.txtEmisor.IsRequired = False
      Me.txtEmisor.Key = ""
      Me.txtEmisor.LabelAsoc = Me.lblEmisor
      Me.txtEmisor.Location = New System.Drawing.Point(401, 69)
      Me.txtEmisor.MaxLength = 12
      Me.txtEmisor.Name = "txtEmisor"
      Me.txtEmisor.Size = New System.Drawing.Size(35, 20)
      Me.txtEmisor.TabIndex = 22
      Me.txtEmisor.Text = "1"
      Me.txtEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblEmisor
      '
      Me.lblEmisor.AutoSize = True
      Me.lblEmisor.LabelAsoc = Nothing
      Me.lblEmisor.Location = New System.Drawing.Point(360, 73)
      Me.lblEmisor.Name = "lblEmisor"
      Me.lblEmisor.Size = New System.Drawing.Size(38, 13)
      Me.lblEmisor.TabIndex = 21
      Me.lblEmisor.Text = "Emisor"
      '
      'cmbLetras
      '
      Me.cmbLetras.BindearPropiedadControl = Nothing
      Me.cmbLetras.BindearPropiedadEntidad = Nothing
      Me.cmbLetras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLetras.Enabled = False
      Me.cmbLetras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbLetras.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLetras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLetras.FormattingEnabled = True
      Me.cmbLetras.IsPK = False
      Me.cmbLetras.IsRequired = False
      Me.cmbLetras.ItemHeight = 13
      Me.cmbLetras.Items.AddRange(New Object() {"X", "A", "B", "C"})
      Me.cmbLetras.Key = Nothing
      Me.cmbLetras.LabelAsoc = Nothing
      Me.cmbLetras.Location = New System.Drawing.Point(311, 69)
      Me.cmbLetras.Name = "cmbLetras"
      Me.cmbLetras.Size = New System.Drawing.Size(44, 21)
      Me.cmbLetras.TabIndex = 20
      '
      'txtNroHasta
      '
      Me.txtNroHasta.BindearPropiedadControl = Nothing
      Me.txtNroHasta.BindearPropiedadEntidad = Nothing
      Me.txtNroHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroHasta.Formato = ""
      Me.txtNroHasta.IsDecimal = False
      Me.txtNroHasta.IsNumber = True
      Me.txtNroHasta.IsPK = False
      Me.txtNroHasta.IsRequired = False
      Me.txtNroHasta.Key = ""
      Me.txtNroHasta.LabelAsoc = Me.lblNroHasta
      Me.txtNroHasta.Location = New System.Drawing.Point(570, 69)
      Me.txtNroHasta.MaxLength = 12
      Me.txtNroHasta.Name = "txtNroHasta"
      Me.txtNroHasta.Size = New System.Drawing.Size(67, 20)
      Me.txtNroHasta.TabIndex = 26
      Me.txtNroHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNroHasta
      '
      Me.lblNroHasta.AutoSize = True
      Me.lblNroHasta.LabelAsoc = Nothing
      Me.lblNroHasta.Location = New System.Drawing.Point(556, 73)
      Me.lblNroHasta.Name = "lblNroHasta"
      Me.lblNroHasta.Size = New System.Drawing.Size(13, 13)
      Me.lblNroHasta.TabIndex = 25
      Me.lblNroHasta.Text = "a"
      '
      'txtNroDesde
      '
      Me.txtNroDesde.BindearPropiedadControl = Nothing
      Me.txtNroDesde.BindearPropiedadEntidad = Nothing
      Me.txtNroDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroDesde.Formato = ""
      Me.txtNroDesde.IsDecimal = False
      Me.txtNroDesde.IsNumber = True
      Me.txtNroDesde.IsPK = False
      Me.txtNroDesde.IsRequired = False
      Me.txtNroDesde.Key = ""
      Me.txtNroDesde.LabelAsoc = Me.lblNroDesde
      Me.txtNroDesde.Location = New System.Drawing.Point(485, 69)
      Me.txtNroDesde.MaxLength = 12
      Me.txtNroDesde.Name = "txtNroDesde"
      Me.txtNroDesde.Size = New System.Drawing.Size(67, 20)
      Me.txtNroDesde.TabIndex = 24
      Me.txtNroDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblNroDesde
      '
      Me.lblNroDesde.AutoSize = True
      Me.lblNroDesde.LabelAsoc = Nothing
      Me.lblNroDesde.Location = New System.Drawing.Point(441, 73)
      Me.lblNroDesde.Name = "lblNroDesde"
      Me.lblNroDesde.Size = New System.Drawing.Size(44, 13)
      Me.lblNroDesde.TabIndex = 23
      Me.lblNroDesde.Text = "Número"
      '
      'chbNumeroRep
      '
      Me.chbNumeroRep.AutoSize = True
      Me.chbNumeroRep.BindearPropiedadControl = Nothing
      Me.chbNumeroRep.BindearPropiedadEntidad = Nothing
      Me.chbNumeroRep.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumeroRep.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumeroRep.IsPK = False
      Me.chbNumeroRep.IsRequired = False
      Me.chbNumeroRep.Key = Nothing
      Me.chbNumeroRep.LabelAsoc = Nothing
      Me.chbNumeroRep.Location = New System.Drawing.Point(655, 71)
      Me.chbNumeroRep.Name = "chbNumeroRep"
      Me.chbNumeroRep.Size = New System.Drawing.Size(64, 17)
      Me.chbNumeroRep.TabIndex = 27
      Me.chbNumeroRep.Text = "Reparto"
      Me.chbNumeroRep.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(869, 154)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
      Me.btnConsultar.TabIndex = 37
      Me.btnConsultar.Text = "&Consultar (F3)"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.ImageScalingSize = New System.Drawing.Size(20, 20)
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(984, 22)
      Me.stsStado.TabIndex = 4
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(905, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbExportar, Me.ToolStripSeparator5, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 3
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbExportar
      '
      Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbExportar.Name = "tsbExportar"
      Me.tsbExportar.Size = New System.Drawing.Size(77, 26)
      Me.tsbExportar.Text = "&Exportar"
      Me.tsbExportar.ToolTipText = "Imprimir"
      Me.tsbExportar.Visible = False
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
      Me.ToolStripSeparator5.Visible = False
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
      'chbTodos
      '
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(741, 158)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(124, 22)
      Me.chbTodos.TabIndex = 1
      Me.chbTodos.Text = "Chequear todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'ImpresionMasivaPedido
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Controls.Add(Me.chbTodos)
      Me.Controls.Add(Me.btnConsultar)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "ImpresionMasivaPedido"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Impresión Masiva de Pedidos"
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents txtNroDesde As Eniac.Controles.TextBox
   Friend WithEvents lblNroDesde As Eniac.Controles.Label
   Friend WithEvents txtNroHasta As Eniac.Controles.TextBox
   Friend WithEvents lblNroHasta As Eniac.Controles.Label
   Friend WithEvents txtEmisor As Eniac.Controles.TextBox
   Friend WithEvents lblEmisor As Eniac.Controles.Label
   Friend WithEvents cmbLetras As Eniac.Controles.ComboBox
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
    Friend WithEvents bscCliente As Eniac.Controles.Buscador
    Friend WithEvents chbCliente As Eniac.Controles.CheckBox
    Friend WithEvents cmbEstadoComprobante As Eniac.Controles.ComboBox
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents txtNroReparto As Eniac.Controles.TextBox
   Friend WithEvents chbNumeroRep As Eniac.Controles.CheckBox
   Friend WithEvents txtNroRepartoHasta As Eniac.Controles.TextBox
   Friend WithEvents lblNroRepartoHasta As Eniac.Controles.Label
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Private WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
   Friend WithEvents lblCategoria As Eniac.Controles.Label
   Friend WithEvents cmbCategoria As Eniac.Win.ComboBoxCategorias
   Friend WithEvents cmbOrigenCategoria As Eniac.Controles.ComboBox
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents lblEstadoComprobante As Eniac.Controles.Label
   Friend WithEvents lblImpreso As Eniac.Controles.Label
   Friend WithEvents cmbImpreso As Eniac.Controles.ComboBox
End Class
