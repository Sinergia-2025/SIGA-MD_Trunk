<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistracionPagosV2
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes", -1)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MedioPagoSeleccionado")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedioPagoSeleccionado")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaComprobante")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalEfectivo")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCuentaCorriente")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAplicado")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRendido")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNCred")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReciboGenerado")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalTransferencia")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTransferencia")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobantes_NCAplicadas")
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCheque")
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim UltraGridColumn116 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes_NCAplicadas", 0)
        Dim UltraGridColumn117 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn118 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn119 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn120 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn121 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn122 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn123 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalNC")
        Dim UltraGridColumn124 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNC")
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraNC")
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorNC")
        Dim UltraGridColumn127 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteNC")
        Dim UltraGridColumn128 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn129 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAplicado")
        Dim UltraGridColumn130 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn131 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistracionPagosV2))
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes", -1)
        Dim UltraGridColumn132 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn133 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn134 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn135 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn136 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn137 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn138 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MedioPagoSeleccionado")
        Dim UltraGridColumn139 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedioPagoSeleccionado")
        Dim UltraGridColumn140 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn141 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn142 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn143 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn144 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn145 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn147 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn148 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn149 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn150 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn151 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn152 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn153 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaComprobante")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn154 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn155 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn156 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn157 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn158 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn159 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn160 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn161 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn162 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn163 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn164 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalEfectivo")
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn165 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCuentaCorriente")
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn166 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn167 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn168 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAplicado")
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn169 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn170 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRendido")
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn171 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn172 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNCred")
        Dim UltraGridColumn173 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReciboGenerado")
        Dim UltraGridColumn174 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn175 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalTransferencia")
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn176 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn177 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTransferencia")
        Dim UltraGridColumn178 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn179 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim UltraGridColumn180 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobantes_NCAplicadas")
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn181 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn182 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn183 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn184 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn185 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn186 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn187 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn188 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn189 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn190 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim UltraGridColumn191 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn192 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim UltraGridColumn193 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn194 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn195 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn196 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn197 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn198 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn199 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn200 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn201 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn202 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn203 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn204 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn205 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim UltraGridColumn206 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim UltraGridBand7 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn207 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn208 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn209 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn210 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn211 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn212 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn213 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn214 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn215 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn216 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn217 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn218 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn219 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn220 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn221 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn222 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn223 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn224 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn225 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCheque")
        Dim UltraGridColumn226 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim UltraGridColumn227 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridBand8 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes_NCAplicadas", 0)
        Dim UltraGridColumn228 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn229 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn230 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn231 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn232 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn233 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn234 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalNC")
        Dim UltraGridColumn235 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNC")
        Dim UltraGridColumn236 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraNC")
        Dim UltraGridColumn237 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorNC")
        Dim UltraGridColumn238 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteNC")
        Dim UltraGridColumn239 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn240 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAplicado")
        Dim UltraGridColumn241 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn242 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand9 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes", -1)
        Dim UltraGridColumn243 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn244 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn245 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn246 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn247 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn248 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn249 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MedioPagoSeleccionado")
        Dim UltraGridColumn250 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedioPagoSeleccionado")
        Dim UltraGridColumn251 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn252 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn253 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn254 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn255 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn257 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn258 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn259 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn260 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn261 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn262 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn263 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn264 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaComprobante")
        Dim UltraGridColumn265 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn266 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn267 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn268 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn269 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn270 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn271 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn272 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn273 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn274 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn275 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalEfectivo")
        Dim UltraGridColumn276 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCuentaCorriente")
        Dim UltraGridColumn277 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn278 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn279 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAplicado")
        Dim UltraGridColumn280 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn281 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRendido")
        Dim UltraGridColumn282 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn283 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNCred")
        Dim UltraGridColumn284 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReciboGenerado")
        Dim UltraGridColumn285 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn286 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalTransferencia")
        Dim UltraGridColumn287 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn288 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTransferencia")
        Dim UltraGridColumn289 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn290 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim UltraGridColumn291 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobantes_NCAplicadas")
        Dim UltraGridBand10 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn292 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn293 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn294 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn295 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn296 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn297 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn298 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn299 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn300 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn301 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim UltraGridColumn302 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn303 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim UltraGridColumn304 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn305 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn306 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn307 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn308 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn309 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn310 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn311 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn312 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn313 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn314 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn315 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn316 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim UltraGridColumn317 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim UltraGridBand11 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn318 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn319 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn320 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn321 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn322 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn323 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn324 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn325 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn326 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn327 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn328 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn329 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn330 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn331 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn332 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn333 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn334 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn335 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn336 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCheque")
        Dim UltraGridColumn337 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim UltraGridColumn338 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridBand12 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes_NCAplicadas", 0)
        Dim UltraGridColumn339 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn340 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn341 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn342 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn343 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn344 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn345 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalNC")
        Dim UltraGridColumn346 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNC")
        Dim UltraGridColumn347 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraNC")
        Dim UltraGridColumn348 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorNC")
        Dim UltraGridColumn349 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteNC")
        Dim UltraGridColumn350 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn351 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAplicado")
        Dim UltraGridColumn352 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn353 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand13 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes", -1)
        Dim UltraGridColumn354 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn355 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn356 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn357 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn358 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn359 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn360 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MedioPagoSeleccionado")
        Dim UltraGridColumn361 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedioPagoSeleccionado")
        Dim UltraGridColumn362 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn363 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn364 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn365 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn366 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn367 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn369 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn370 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn371 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn372 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn373 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn374 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn375 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaComprobante")
        Dim UltraGridColumn376 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn377 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn378 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn379 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn380 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn381 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn382 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn383 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn384 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn385 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn386 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalEfectivo")
        Dim UltraGridColumn387 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCuentaCorriente")
        Dim UltraGridColumn388 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn389 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn390 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAplicado")
        Dim UltraGridColumn391 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn392 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRendido")
        Dim UltraGridColumn393 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn394 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNCred")
        Dim UltraGridColumn395 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReciboGenerado")
        Dim UltraGridColumn396 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn397 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalTransferencia")
        Dim UltraGridColumn398 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn399 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTransferencia")
        Dim UltraGridColumn400 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn401 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim UltraGridColumn402 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobantes_NCAplicadas")
        Dim UltraGridBand14 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn403 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn404 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn405 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn406 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn407 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn408 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn409 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn410 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn411 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn412 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim UltraGridColumn413 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn414 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim UltraGridColumn415 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn416 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn417 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn418 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn419 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn420 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn421 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn422 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn423 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn424 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn425 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn426 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn427 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim UltraGridColumn428 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim UltraGridBand15 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn429 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn430 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn431 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn432 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn433 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn434 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn435 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn436 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn437 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn438 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn439 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn440 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn441 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn442 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn443 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn444 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn445 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn446 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn447 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCheque")
        Dim UltraGridColumn448 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim UltraGridColumn449 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridBand16 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes_NCAplicadas", 0)
        Dim UltraGridColumn450 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn451 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn452 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn453 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn454 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn455 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn456 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalNC")
        Dim UltraGridColumn457 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNC")
        Dim UltraGridColumn458 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraNC")
        Dim UltraGridColumn459 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorNC")
        Dim UltraGridColumn460 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteNC")
        Dim UltraGridColumn461 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn462 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAplicado")
        Dim UltraGridColumn463 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn464 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand17 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes", -1)
        Dim UltraGridColumn465 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn466 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn467 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn468 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn469 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn470 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn471 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MedioPagoSeleccionado")
        Dim UltraGridColumn472 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedioPagoSeleccionado")
        Dim UltraGridColumn473 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn474 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn475 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn476 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn477 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn479 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn480 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn481 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn482 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn483 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn484 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn485 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn486 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaComprobante")
        Dim UltraGridColumn487 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn488 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn489 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn490 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn491 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn492 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn493 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn494 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn495 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn496 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn497 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalEfectivo")
        Dim UltraGridColumn498 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCuentaCorriente")
        Dim UltraGridColumn499 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn500 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn501 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAplicado")
        Dim UltraGridColumn502 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn503 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRendido")
        Dim UltraGridColumn504 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn505 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNCred")
        Dim UltraGridColumn506 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReciboGenerado")
        Dim UltraGridColumn507 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn508 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalTransferencia")
        Dim UltraGridColumn509 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn510 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTransferencia")
        Dim UltraGridColumn511 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn512 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim UltraGridColumn513 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobantes_NCAplicadas")
        Dim UltraGridBand18 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn514 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn515 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn516 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn517 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn518 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn519 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn520 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn521 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn522 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn523 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim UltraGridColumn524 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn525 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim UltraGridColumn526 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn527 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn528 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn529 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn530 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn531 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn532 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn533 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn534 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn535 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn536 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn537 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn538 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim UltraGridColumn539 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim UltraGridBand19 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn540 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn541 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn542 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn543 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn544 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn545 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn546 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn547 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn548 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn549 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn550 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn551 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn552 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn553 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn554 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn555 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn556 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn557 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn558 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCheque")
        Dim UltraGridColumn559 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim UltraGridColumn560 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridBand20 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes_NCAplicadas", 0)
        Dim UltraGridColumn561 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn562 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn563 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn564 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn565 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn566 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn567 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalNC")
        Dim UltraGridColumn568 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNC")
        Dim UltraGridColumn569 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraNC")
        Dim UltraGridColumn570 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorNC")
        Dim UltraGridColumn571 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteNC")
        Dim UltraGridColumn572 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn573 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAplicado")
        Dim UltraGridColumn574 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn575 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand21 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes", -1)
        Dim UltraGridColumn576 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn577 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn578 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn579 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn580 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn581 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn582 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MedioPagoSeleccionado")
        Dim UltraGridColumn583 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedioPagoSeleccionado")
        Dim UltraGridColumn584 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn585 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn586 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn587 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn588 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn589 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn590 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn591 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn592 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn593 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn594 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn595 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn597 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaComprobante")
        Dim UltraGridColumn598 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn599 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn600 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn601 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn602 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn603 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn604 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn605 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn606 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn607 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn608 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalEfectivo")
        Dim UltraGridColumn609 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCuentaCorriente")
        Dim UltraGridColumn610 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn611 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn612 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAplicado")
        Dim UltraGridColumn701 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn702 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRendido")
        Dim UltraGridColumn715 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn716 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNCred")
        Dim UltraGridColumn717 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReciboGenerado")
        Dim UltraGridColumn718 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn719 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalTransferencia")
        Dim UltraGridColumn720 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn721 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTransferencia")
        Dim UltraGridColumn722 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn723 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim UltraGridColumn724 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobantes_NCAplicadas")
        Dim UltraGridBand22 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn725 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn742 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn743 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn744 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn745 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn746 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn747 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn749 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn750 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn751 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim UltraGridColumn752 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn753 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim UltraGridColumn754 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn755 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn756 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn757 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn758 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn759 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn760 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn761 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn762 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn763 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn764 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn765 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn766 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim UltraGridColumn767 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim UltraGridBand23 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn768 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn769 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn770 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn771 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn772 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn773 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn774 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn775 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn776 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn777 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn778 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn779 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn780 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn781 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn782 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn783 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn784 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn785 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn786 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCheque")
        Dim UltraGridColumn787 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim UltraGridColumn788 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridBand24 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes_NCAplicadas", 0)
        Dim UltraGridColumn789 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn790 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn791 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn792 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn793 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn794 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn795 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalNC")
        Dim UltraGridColumn796 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNC")
        Dim UltraGridColumn797 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraNC")
        Dim UltraGridColumn798 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorNC")
        Dim UltraGridColumn799 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteNC")
        Dim UltraGridColumn800 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn801 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAplicado")
        Dim UltraGridColumn802 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn803 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim Appearance135 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance136 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance137 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance138 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance139 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance140 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance141 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance142 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance143 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance144 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance145 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance146 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand25 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes", -1)
        Dim UltraGridColumn804 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn805 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn806 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn807 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn808 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn809 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn810 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MedioPagoSeleccionado")
        Dim UltraGridColumn811 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMedioPagoSeleccionado")
        Dim UltraGridColumn812 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn813 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn814 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn815 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn816 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn817 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn818 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn819 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn820 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn821 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn822 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn823 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn824 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaComprobante")
        Dim UltraGridColumn825 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn826 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn827 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn828 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn829 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn830 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn831 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn832 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn833 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn834 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn835 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalEfectivo")
        Dim UltraGridColumn836 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCuentaCorriente")
        Dim UltraGridColumn837 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn838 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn839 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalAplicado")
        Dim UltraGridColumn840 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn841 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalRendido")
        Dim UltraGridColumn842 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn843 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNCred")
        Dim UltraGridColumn844 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ReciboGenerado")
        Dim UltraGridColumn845 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn846 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalTransferencia")
        Dim UltraGridColumn847 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn848 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaTransferencia")
        Dim UltraGridColumn849 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn850 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim UltraGridColumn851 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comprobantes_NCAplicadas")
        Dim UltraGridBand26 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn852 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn853 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn854 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn855 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn857 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn858 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn859 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn860 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn861 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn862 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim UltraGridColumn863 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn864 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim UltraGridColumn865 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn866 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn867 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn868 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn869 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn870 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn871 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn872 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn1515 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn1516 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn1517 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn1518 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn1519 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim UltraGridColumn1520 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim UltraGridBand27 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn1521 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn1522 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn1523 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn1524 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn1525 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn1526 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn1527 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn1528 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn1529 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn1530 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn1531 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn1532 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn1533 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn1534 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn1535 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn1536 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn1537 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn1538 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn1539 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCheque")
        Dim UltraGridColumn1540 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim UltraGridColumn1541 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridBand28 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Comprobantes_NCAplicadas", 0)
        Dim UltraGridColumn1542 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
        Dim UltraGridColumn1543 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn1544 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn1545 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn1546 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn1547 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn1548 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalNC")
        Dim UltraGridColumn1549 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteNC")
        Dim UltraGridColumn1550 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraNC")
        Dim UltraGridColumn1551 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorNC")
        Dim UltraGridColumn1552 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteNC")
        Dim UltraGridColumn1553 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoComprobante")
        Dim UltraGridColumn1554 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteAplicado")
        Dim UltraGridColumn1555 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn1556 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim Appearance147 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance148 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance149 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance150 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance151 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance152 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance155 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand29 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("ProductosSinDescargo", -1)
        Dim UltraGridColumn726 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn727 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn728 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn729 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductosSinDescargoComprobante")
        Dim UltraGridBand30 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("ProductosSinDescargoComprobante", -1)
        Dim UltraGridColumn730 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn731 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn732 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn733 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn734 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn735 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
        Dim Appearance161 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn736 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdReparo")
        Dim UltraGridColumn737 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn738 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance162 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn739 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn740 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn741 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance164 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance165 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance171 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance172 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance173 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance174 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab10 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab11 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance175 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance176 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab12 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance177 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance178 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab13 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance179 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance180 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab14 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance181 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance182 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab15 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance183 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab16 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab17 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance184 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab18 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance185 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl7 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugComprobante = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.bdsComprobantes = New System.Windows.Forms.BindingSource(Me.components)
        Me.DtsRegistracionPagosV2 = New Eniac.Entidades.dtsRegistracionPagosV2()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.btnGrabaDataSetXML = New System.Windows.Forms.Button()
        Me.chbFechaDesde = New Eniac.Controles.CheckBox()
        Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblModoConsultarComprobantes = New Eniac.Controles.Label()
        Me.chbDias = New Eniac.Controles.CheckBox()
        Me.cmbDias = New Eniac.Controles.ComboBox()
        Me.cmbRuta = New Eniac.Controles.ComboBox()
        Me.chbRuta = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.cmbModoConsultarComprobantes = New Eniac.Controles.ComboBox()
        Me.cmbLocalidad = New Eniac.Controles.ComboBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.chbRespDistribucion = New Eniac.Controles.CheckBox()
        Me.cmbRespDistribucion = New Eniac.Controles.ComboBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.chbFechaHasta = New Eniac.Controles.CheckBox()
        Me.tstSecundaria = New System.Windows.Forms.ToolStrip()
        Me.tslNCSeleccionada = New System.Windows.Forms.ToolStripLabel()
        Me.tsbEfectivo = New System.Windows.Forms.ToolStripButton()
        Me.tsbVarias = New System.Windows.Forms.ToolStripButton()
        Me.tsbCC = New System.Windows.Forms.ToolStripButton()
        Me.tsbNC = New System.Windows.Forms.ToolStripButton()
        Me.tsbReenvio = New System.Windows.Forms.ToolStripButton()
        Me.tsbNoRendir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugvDetallePedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.bdsComprobantesSeleccionados = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugEfectivo = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.EfectivoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugCtaCte = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CtaCteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugCheque = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ChequesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugNc = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.NCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.utReenvios = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugReenvios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ReenviosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugvProductosSinDescargar = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.utResumen = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnGrabar = New Eniac.Controles.Button()
        Me.btnImprimirResumen = New System.Windows.Forms.Button()
        Me.grbIVAs = New System.Windows.Forms.GroupBox()
        Me.lblTotalTransferencia = New Eniac.Controles.Label()
        Me.txtTotalTransferencia = New Eniac.Controles.TextBox()
        Me.lblSubTotal = New Eniac.Controles.Label()
        Me.txtSubTotal = New Eniac.Controles.TextBox()
        Me.lblTotalComprobantes = New Eniac.Controles.Label()
        Me.txtTotalComprobantes = New Eniac.Controles.TextBox()
        Me.lblLineaTotal1 = New System.Windows.Forms.Label()
        Me.lblTotalCC = New Eniac.Controles.Label()
        Me.txtTotalCC = New Eniac.Controles.TextBox()
        Me.lblTotalReenvios = New Eniac.Controles.Label()
        Me.txtTotalReenvios = New Eniac.Controles.TextBox()
        Me.lblSaldoGeneral = New Eniac.Controles.Label()
        Me.lblNCAplicadas = New Eniac.Controles.Label()
        Me.lblTotalNC = New Eniac.Controles.Label()
        Me.txtSaldoGeneral = New Eniac.Controles.TextBox()
        Me.lblTotalCheque = New Eniac.Controles.Label()
        Me.lblTotalEfectivo = New Eniac.Controles.Label()
        Me.txtNCAplicadas = New Eniac.Controles.TextBox()
        Me.txtTotalNC = New Eniac.Controles.TextBox()
        Me.txtTotalEfectivo = New Eniac.Controles.TextBox()
        Me.txtTotalCheque = New Eniac.Controles.TextBox()
        Me.lblLineaTotal2 = New System.Windows.Forms.Label()
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.lblFechaRend = New Eniac.Controles.Label()
        Me.dtpFechaRend = New Eniac.Controles.DateTimePicker()
        Me.utcPreventa = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.lblReparto = New Eniac.Controles.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPagarTodo = New System.Windows.Forms.ToolStripButton()
        Me.tsbGrabarBorrador = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimirGrilla = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.bscReparto2 = New Eniac.Controles.Buscador2()
        Me.pnlReparto = New System.Windows.Forms.Panel()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.UltraTabPageControl7.SuspendLayout()
        CType(Me.ugComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bdsComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtsRegistracionPagosV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.tstSecundaria.SuspendLayout()
        Me.UltraTabPageControl3.SuspendLayout()
        CType(Me.ugvDetallePedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bdsComprobantesSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.ugEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EfectivoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.ugCtaCte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CtaCteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.ugCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChequesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.ugNc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utReenvios.SuspendLayout()
        CType(Me.ugReenvios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReenviosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.ugvProductosSinDescargar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utResumen.SuspendLayout()
        Me.grbIVAs.SuspendLayout()
        CType(Me.utcPreventa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utcPreventa.SuspendLayout()
        Me.UltraTabSharedControlsPage1.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.pnlReparto.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl7
        '
        Me.UltraTabPageControl7.Controls.Add(Me.ugComprobante)
        Me.UltraTabPageControl7.Controls.Add(Me.grbFiltros)
        Me.UltraTabPageControl7.Controls.Add(Me.tstSecundaria)
        Me.UltraTabPageControl7.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl7.Name = "UltraTabPageControl7"
        Me.UltraTabPageControl7.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.UltraTabPageControl7.Size = New System.Drawing.Size(1006, 452)
        '
        'ugComprobante
        '
        Me.ugComprobante.DataSource = Me.bdsComprobantes
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugComprobante.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance2
        UltraGridColumn22.Header.Caption = "Id Sucursal"
        UltraGridColumn22.Header.VisiblePosition = 29
        UltraGridColumn22.Hidden = True
        UltraGridColumn23.Header.Caption = "Tipo"
        UltraGridColumn23.Header.VisiblePosition = 13
        UltraGridColumn23.Width = 90
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn24.CellAppearance = Appearance3
        UltraGridColumn24.Header.Caption = "L"
        UltraGridColumn24.Header.VisiblePosition = 14
        UltraGridColumn24.Width = 25
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance4
        UltraGridColumn25.Header.Caption = "Emisor"
        UltraGridColumn25.Header.VisiblePosition = 15
        UltraGridColumn25.Hidden = True
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance5
        UltraGridColumn26.Header.Caption = "Nro."
        UltraGridColumn26.Header.VisiblePosition = 16
        UltraGridColumn26.Width = 40
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn27.CellAppearance = Appearance6
        UltraGridColumn27.Header.VisiblePosition = 0
        UltraGridColumn27.Hidden = True
        UltraGridColumn28.Header.Caption = "Medio Pago"
        UltraGridColumn28.Header.VisiblePosition = 1
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.Header.Caption = "Forma Pago"
        UltraGridColumn29.Header.VisiblePosition = 2
        UltraGridColumn29.Hidden = True
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance7
        UltraGridColumn30.Header.Caption = "Id Cliente"
        UltraGridColumn30.Header.VisiblePosition = 31
        UltraGridColumn30.Hidden = True
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance8
        UltraGridColumn31.Header.Caption = "Código"
        UltraGridColumn31.Header.VisiblePosition = 4
        UltraGridColumn31.Width = 50
        UltraGridColumn32.Header.Caption = "Tipo Doc Cliente"
        UltraGridColumn32.Header.VisiblePosition = 32
        UltraGridColumn32.Hidden = True
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance9
        UltraGridColumn33.Header.Caption = "Nro Doc Cliente"
        UltraGridColumn33.Header.VisiblePosition = 33
        UltraGridColumn33.Hidden = True
        UltraGridColumn34.Header.Caption = "Cliente"
        UltraGridColumn34.Header.VisiblePosition = 5
        UltraGridColumn34.Width = 130
        UltraGridColumn35.Header.VisiblePosition = 6
        UltraGridColumn35.Width = 110
        UltraGridColumn36.Header.Caption = "Localidad"
        UltraGridColumn36.Header.VisiblePosition = 7
        UltraGridColumn36.Hidden = True
        UltraGridColumn37.Header.Caption = "Provincia"
        UltraGridColumn37.Header.VisiblePosition = 8
        UltraGridColumn37.Hidden = True
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn38.CellAppearance = Appearance10
        UltraGridColumn38.Header.Caption = "Id Transportista"
        UltraGridColumn38.Header.VisiblePosition = 34
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.Header.Caption = "Resp. Distribución"
        UltraGridColumn39.Header.VisiblePosition = 19
        UltraGridColumn39.Width = 105
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance11
        UltraGridColumn40.Header.Caption = "Id Vendedor"
        UltraGridColumn40.Header.VisiblePosition = 30
        UltraGridColumn40.Hidden = True
        UltraGridColumn41.Header.Caption = "Vendedor"
        UltraGridColumn41.Header.VisiblePosition = 22
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn42.CellAppearance = Appearance12
        UltraGridColumn42.Format = "dd/MM/yyyy"
        UltraGridColumn42.Header.Caption = "Fecha Comp."
        UltraGridColumn42.Header.VisiblePosition = 21
        Appearance13.TextHAlignAsString = "Center"
        UltraGridColumn43.CellAppearance = Appearance13
        UltraGridColumn43.Format = "dd/MM/yyyy"
        UltraGridColumn43.Header.Caption = "F. Envio"
        UltraGridColumn43.Header.VisiblePosition = 18
        UltraGridColumn43.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn43.Width = 64
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance14
        UltraGridColumn44.Format = "N2"
        UltraGridColumn44.Header.Caption = "Total"
        UltraGridColumn44.Header.VisiblePosition = 10
        UltraGridColumn44.MaskInput = "{double:-12.2}"
        UltraGridColumn44.Width = 70
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance15
        UltraGridColumn45.Format = "N2"
        UltraGridColumn45.Header.Caption = "Saldo"
        UltraGridColumn45.Header.VisiblePosition = 11
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn46.CellAppearance = Appearance16
        UltraGridColumn46.Header.Caption = "Id Categoría Fiscal"
        UltraGridColumn46.Header.VisiblePosition = 35
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.Header.Caption = "Categoria Fiscal"
        UltraGridColumn47.Header.VisiblePosition = 9
        UltraGridColumn47.Hidden = True
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance17
        UltraGridColumn48.Header.Caption = "Reparto"
        UltraGridColumn48.Header.VisiblePosition = 17
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn49.CellAppearance = Appearance18
        UltraGridColumn49.Format = "dd/MM/yyyy"
        UltraGridColumn49.Header.Caption = "Fecha Alta"
        UltraGridColumn49.Header.VisiblePosition = 36
        UltraGridColumn49.Hidden = True
        UltraGridColumn49.Width = 64
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn50.CellAppearance = Appearance19
        UltraGridColumn50.Header.Caption = "Id Formas Pago"
        UltraGridColumn50.Header.VisiblePosition = 37
        UltraGridColumn50.Hidden = True
        UltraGridColumn51.Header.Caption = "F.P. Pedido"
        UltraGridColumn51.Header.VisiblePosition = 3
        UltraGridColumn51.Width = 70
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn52.CellAppearance = Appearance20
        UltraGridColumn52.Format = "N2"
        UltraGridColumn52.Header.Caption = "Saldo Cliente"
        UltraGridColumn52.Header.VisiblePosition = 20
        UltraGridColumn52.Width = 90
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn53.CellAppearance = Appearance21
        UltraGridColumn53.Format = "N2"
        UltraGridColumn53.Header.Caption = "Efectivo"
        UltraGridColumn53.Header.VisiblePosition = 23
        UltraGridColumn53.Width = 90
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn54.CellAppearance = Appearance22
        UltraGridColumn54.Format = "N2"
        UltraGridColumn54.Header.Caption = "Cuenta Corriente"
        UltraGridColumn54.Header.VisiblePosition = 25
        UltraGridColumn54.Width = 90
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn55.CellAppearance = Appearance23
        UltraGridColumn55.Format = "N2"
        UltraGridColumn55.Header.Caption = "Cheques"
        UltraGridColumn55.Header.VisiblePosition = 24
        UltraGridColumn55.Width = 90
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn56.CellAppearance = Appearance24
        UltraGridColumn56.Format = "N2"
        UltraGridColumn56.Header.Caption = "Nota de Crédito"
        UltraGridColumn56.Header.VisiblePosition = 26
        UltraGridColumn56.Width = 90
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn57.CellAppearance = Appearance25
        UltraGridColumn57.Format = "N2"
        UltraGridColumn57.Header.Caption = "Aplicado"
        UltraGridColumn57.Header.VisiblePosition = 27
        UltraGridColumn57.Width = 90
        Appearance26.TextHAlignAsString = "Right"
        UltraGridColumn58.CellAppearance = Appearance26
        UltraGridColumn58.Format = "N2"
        UltraGridColumn58.Header.Caption = "Reenvio"
        UltraGridColumn58.Header.VisiblePosition = 28
        UltraGridColumn58.Width = 90
        Appearance27.TextHAlignAsString = "Right"
        UltraGridColumn59.CellAppearance = Appearance27
        UltraGridColumn59.Format = "N2"
        UltraGridColumn59.Header.Caption = "Rendido"
        UltraGridColumn59.Header.VisiblePosition = 12
        UltraGridColumn59.Hidden = True
        UltraGridColumn59.Width = 90
        UltraGridColumn60.Header.Caption = "Graba Libro"
        UltraGridColumn60.Header.VisiblePosition = 38
        UltraGridColumn60.Hidden = True
        UltraGridColumn61.Header.Caption = "Tipo Comp. NC"
        UltraGridColumn61.Header.VisiblePosition = 39
        UltraGridColumn61.Hidden = True
        UltraGridColumn62.Header.VisiblePosition = 40
        UltraGridColumn63.Header.VisiblePosition = 41
        UltraGridColumn64.Header.VisiblePosition = 42
        UltraGridColumn65.Header.VisiblePosition = 43
        UltraGridColumn66.Header.VisiblePosition = 44
        UltraGridColumn67.Header.VisiblePosition = 45
        UltraGridColumn68.Header.VisiblePosition = 46
        UltraGridColumn69.Header.VisiblePosition = 47
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69})
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn70.CellAppearance = Appearance28
        UltraGridColumn70.Header.VisiblePosition = 0
        UltraGridColumn70.Hidden = True
        UltraGridColumn70.Width = 56
        UltraGridColumn71.Header.VisiblePosition = 1
        UltraGridColumn71.Hidden = True
        UltraGridColumn71.Width = 69
        UltraGridColumn72.Header.VisiblePosition = 2
        UltraGridColumn72.Hidden = True
        UltraGridColumn72.Width = 50
        Appearance29.TextHAlignAsString = "Right"
        UltraGridColumn73.CellAppearance = Appearance29
        UltraGridColumn73.Header.VisiblePosition = 3
        UltraGridColumn73.Hidden = True
        UltraGridColumn73.Width = 130
        Appearance30.TextHAlignAsString = "Right"
        UltraGridColumn74.CellAppearance = Appearance30
        UltraGridColumn74.Header.VisiblePosition = 4
        UltraGridColumn74.Hidden = True
        UltraGridColumn74.Width = 110
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn75.CellAppearance = Appearance31
        UltraGridColumn75.Header.Caption = "Código"
        UltraGridColumn75.Header.VisiblePosition = 6
        UltraGridColumn75.MaxWidth = 80
        UltraGridColumn75.Width = 80
        Appearance32.TextHAlignAsString = "Right"
        UltraGridColumn76.CellAppearance = Appearance32
        UltraGridColumn76.Header.VisiblePosition = 5
        UltraGridColumn76.MaxWidth = 50
        UltraGridColumn76.MinWidth = 50
        UltraGridColumn76.Width = 50
        UltraGridColumn77.Header.Caption = "Producto"
        UltraGridColumn77.Header.VisiblePosition = 7
        UltraGridColumn77.Width = 377
        Appearance33.TextHAlignAsString = "Right"
        UltraGridColumn78.CellAppearance = Appearance33
        UltraGridColumn78.Format = "N2"
        UltraGridColumn78.Header.VisiblePosition = 8
        UltraGridColumn78.MaskInput = "{double:-12.2}"
        UltraGridColumn78.MaxWidth = 60
        UltraGridColumn78.MinWidth = 60
        UltraGridColumn78.Width = 60
        UltraGridColumn79.Header.VisiblePosition = 9
        Appearance34.TextHAlignAsString = "Right"
        UltraGridColumn80.CellAppearance = Appearance34
        UltraGridColumn80.Format = "N2"
        UltraGridColumn80.Header.VisiblePosition = 10
        UltraGridColumn80.MaskInput = "{double:-12.2}"
        UltraGridColumn80.MaxWidth = 60
        UltraGridColumn80.MinWidth = 60
        UltraGridColumn81.Header.VisiblePosition = 12
        Appearance35.TextHAlignAsString = "Right"
        UltraGridColumn82.CellAppearance = Appearance35
        UltraGridColumn82.Format = "N2"
        UltraGridColumn82.Header.Caption = "Total"
        UltraGridColumn82.Header.VisiblePosition = 11
        UltraGridColumn82.MaskInput = "{double:-12.2}"
        UltraGridColumn82.MaxWidth = 60
        UltraGridColumn82.MinWidth = 60
        UltraGridColumn82.Width = 60
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn83.CellAppearance = Appearance36
        UltraGridColumn83.Format = "N2"
        UltraGridColumn83.Header.VisiblePosition = 13
        UltraGridColumn83.Hidden = True
        UltraGridColumn83.MaskInput = "{double:-12.2}"
        UltraGridColumn83.MaxWidth = 60
        UltraGridColumn83.MinWidth = 60
        UltraGridColumn83.Width = 60
        UltraGridColumn84.Header.VisiblePosition = 14
        UltraGridColumn84.Hidden = True
        UltraGridColumn84.MaxWidth = 50
        UltraGridColumn85.Header.VisiblePosition = 15
        UltraGridColumn85.Hidden = True
        UltraGridColumn85.Width = 64
        Appearance37.TextHAlignAsString = "Right"
        UltraGridColumn86.CellAppearance = Appearance37
        UltraGridColumn86.Format = "N2"
        UltraGridColumn86.Header.VisiblePosition = 16
        UltraGridColumn86.Hidden = True
        UltraGridColumn86.MaskInput = "{double:-12.2}"
        UltraGridColumn86.MaxWidth = 60
        UltraGridColumn86.MinWidth = 60
        UltraGridColumn86.Width = 60
        UltraGridColumn87.Header.VisiblePosition = 17
        UltraGridColumn87.Hidden = True
        UltraGridColumn88.Header.VisiblePosition = 18
        UltraGridColumn88.Hidden = True
        UltraGridColumn89.Header.VisiblePosition = 21
        UltraGridColumn90.Header.VisiblePosition = 19
        UltraGridColumn90.Hidden = True
        UltraGridColumn91.Header.VisiblePosition = 20
        UltraGridColumn91.Hidden = True
        UltraGridColumn92.Header.Caption = "Tp. Operación"
        UltraGridColumn92.Header.VisiblePosition = 22
        UltraGridColumn92.Width = 85
        UltraGridColumn93.Header.VisiblePosition = 23
        UltraGridColumn93.Width = 186
        UltraGridColumn94.Header.VisiblePosition = 24
        UltraGridColumn95.Header.VisiblePosition = 25
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95})
        UltraGridColumn96.Header.VisiblePosition = 0
        UltraGridColumn97.Header.VisiblePosition = 1
        UltraGridColumn98.Header.VisiblePosition = 2
        UltraGridColumn99.Header.VisiblePosition = 3
        UltraGridColumn100.Header.VisiblePosition = 4
        UltraGridColumn101.Header.VisiblePosition = 5
        UltraGridColumn102.Header.VisiblePosition = 6
        UltraGridColumn103.Header.VisiblePosition = 7
        UltraGridColumn104.Header.VisiblePosition = 8
        UltraGridColumn105.Header.VisiblePosition = 9
        UltraGridColumn106.Header.VisiblePosition = 10
        UltraGridColumn107.Header.VisiblePosition = 11
        UltraGridColumn108.Header.VisiblePosition = 12
        UltraGridColumn109.Header.VisiblePosition = 13
        UltraGridColumn110.Header.VisiblePosition = 14
        UltraGridColumn111.Header.VisiblePosition = 15
        UltraGridColumn112.Header.VisiblePosition = 16
        UltraGridColumn113.Header.VisiblePosition = 17
        UltraGridColumn114.Header.VisiblePosition = 18
        UltraGridColumn115.Header.VisiblePosition = 19
        UltraGridColumn116.Header.VisiblePosition = 20
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114, UltraGridColumn115, UltraGridColumn116})
        UltraGridBand3.Hidden = True
        UltraGridColumn117.Header.VisiblePosition = 0
        UltraGridColumn118.Header.VisiblePosition = 1
        UltraGridColumn119.Header.VisiblePosition = 2
        UltraGridColumn120.Header.VisiblePosition = 3
        UltraGridColumn121.Header.VisiblePosition = 4
        UltraGridColumn122.Header.VisiblePosition = 5
        UltraGridColumn123.Header.VisiblePosition = 6
        UltraGridColumn124.Header.VisiblePosition = 7
        UltraGridColumn125.Header.VisiblePosition = 8
        UltraGridColumn126.Header.VisiblePosition = 9
        UltraGridColumn127.Header.VisiblePosition = 10
        UltraGridColumn128.Header.VisiblePosition = 11
        UltraGridColumn129.Header.VisiblePosition = 12
        UltraGridColumn130.Header.VisiblePosition = 13
        UltraGridColumn131.Header.VisiblePosition = 14
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn117, UltraGridColumn118, UltraGridColumn119, UltraGridColumn120, UltraGridColumn121, UltraGridColumn122, UltraGridColumn123, UltraGridColumn124, UltraGridColumn125, UltraGridColumn126, UltraGridColumn127, UltraGridColumn128, UltraGridColumn129, UltraGridColumn130, UltraGridColumn131})
        Me.ugComprobante.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugComprobante.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugComprobante.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugComprobante.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.ugComprobante.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugComprobante.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance38.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance38.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance38.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobante.DisplayLayout.GroupByBox.Appearance = Appearance38
        Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobante.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance39
        Me.ugComprobante.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComprobante.DisplayLayout.GroupByBox.Hidden = True
        Me.ugComprobante.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance40.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance40.BackColor2 = System.Drawing.SystemColors.Control
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance40.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobante.DisplayLayout.GroupByBox.PromptAppearance = Appearance40
        Me.ugComprobante.DisplayLayout.MaxColScrollRegions = 1
        Me.ugComprobante.DisplayLayout.MaxRowScrollRegions = 1
        Appearance41.BackColor = System.Drawing.SystemColors.Window
        Appearance41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugComprobante.DisplayLayout.Override.ActiveCellAppearance = Appearance41
        Appearance42.BackColor = System.Drawing.SystemColors.Highlight
        Appearance42.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugComprobante.DisplayLayout.Override.ActiveRowAppearance = Appearance42
        Me.ugComprobante.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugComprobante.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugComprobante.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugComprobante.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugComprobante.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugComprobante.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugComprobante.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Me.ugComprobante.DisplayLayout.Override.CardAreaAppearance = Appearance43
        Appearance44.BorderColor = System.Drawing.Color.Silver
        Appearance44.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugComprobante.DisplayLayout.Override.CellAppearance = Appearance44
        Me.ugComprobante.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugComprobante.DisplayLayout.Override.CellPadding = 0
        Appearance45.BackColor = System.Drawing.SystemColors.Control
        Appearance45.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance45.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance45.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobante.DisplayLayout.Override.GroupByRowAppearance = Appearance45
        Appearance46.TextHAlignAsString = "Left"
        Me.ugComprobante.DisplayLayout.Override.HeaderAppearance = Appearance46
        Me.ugComprobante.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugComprobante.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Me.ugComprobante.DisplayLayout.Override.RowAppearance = Appearance47
        Me.ugComprobante.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugComprobante.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugComprobante.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugComprobante.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugComprobante.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugComprobante.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugComprobante.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugComprobante.DisplayLayout.Override.TemplateAddRowAppearance = Appearance48
        Me.ugComprobante.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugComprobante.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugComprobante.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugComprobante.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugComprobante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugComprobante.Location = New System.Drawing.Point(5, 124)
        Me.ugComprobante.Name = "ugComprobante"
        Me.ugComprobante.Size = New System.Drawing.Size(996, 323)
        Me.ugComprobante.TabIndex = 1
        '
        'bdsComprobantes
        '
        Me.bdsComprobantes.DataMember = "Comprobantes"
        Me.bdsComprobantes.DataSource = Me.DtsRegistracionPagosV2
        Me.bdsComprobantes.Filter = ""
        '
        'DtsRegistracionPagosV2
        '
        Me.DtsRegistracionPagosV2.DataSetName = "dtsRegistracionPagosV2"
        Me.DtsRegistracionPagosV2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.btnGrabaDataSetXML)
        Me.grbFiltros.Controls.Add(Me.chbFechaDesde)
        Me.grbFiltros.Controls.Add(Me.dtpFechaDesde)
        Me.grbFiltros.Controls.Add(Me.lblModoConsultarComprobantes)
        Me.grbFiltros.Controls.Add(Me.chbDias)
        Me.grbFiltros.Controls.Add(Me.cmbDias)
        Me.grbFiltros.Controls.Add(Me.cmbRuta)
        Me.grbFiltros.Controls.Add(Me.chbRuta)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbModoConsultarComprobantes)
        Me.grbFiltros.Controls.Add(Me.cmbLocalidad)
        Me.grbFiltros.Controls.Add(Me.btnBuscar)
        Me.grbFiltros.Controls.Add(Me.chbRespDistribucion)
        Me.grbFiltros.Controls.Add(Me.cmbRespDistribucion)
        Me.grbFiltros.Controls.Add(Me.chbLocalidad)
        Me.grbFiltros.Controls.Add(Me.dtpFechaHasta)
        Me.grbFiltros.Controls.Add(Me.chbFechaHasta)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFiltros.Location = New System.Drawing.Point(5, 29)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(996, 95)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'btnGrabaDataSetXML
        '
        Me.btnGrabaDataSetXML.Location = New System.Drawing.Point(780, 13)
        Me.btnGrabaDataSetXML.Name = "btnGrabaDataSetXML"
        Me.btnGrabaDataSetXML.Size = New System.Drawing.Size(207, 23)
        Me.btnGrabaDataSetXML.TabIndex = 17
        Me.btnGrabaDataSetXML.TabStop = False
        Me.btnGrabaDataSetXML.Text = "Graba DataSet como XML para pruebas"
        Me.btnGrabaDataSetXML.UseVisualStyleBackColor = True
        Me.btnGrabaDataSetXML.Visible = False
        '
        'chbFechaDesde
        '
        Me.chbFechaDesde.AutoSize = True
        Me.chbFechaDesde.BindearPropiedadControl = Nothing
        Me.chbFechaDesde.BindearPropiedadEntidad = Nothing
        Me.chbFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaDesde.IsPK = False
        Me.chbFechaDesde.IsRequired = False
        Me.chbFechaDesde.Key = Nothing
        Me.chbFechaDesde.LabelAsoc = Nothing
        Me.chbFechaDesde.Location = New System.Drawing.Point(345, 15)
        Me.chbFechaDesde.Name = "chbFechaDesde"
        Me.chbFechaDesde.Size = New System.Drawing.Size(88, 17)
        Me.chbFechaDesde.TabIndex = 2
        Me.chbFechaDesde.Text = "Fecha desde"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaDesde.Enabled = False
        Me.dtpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaDesde.IsPK = False
        Me.dtpFechaDesde.IsRequired = False
        Me.dtpFechaDesde.Key = ""
        Me.dtpFechaDesde.LabelAsoc = Me.chbFechaDesde
        Me.dtpFechaDesde.Location = New System.Drawing.Point(439, 13)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaDesde.TabIndex = 3
        '
        'lblModoConsultarComprobantes
        '
        Me.lblModoConsultarComprobantes.AutoSize = True
        Me.lblModoConsultarComprobantes.LabelAsoc = Nothing
        Me.lblModoConsultarComprobantes.Location = New System.Drawing.Point(9, 17)
        Me.lblModoConsultarComprobantes.Name = "lblModoConsultarComprobantes"
        Me.lblModoConsultarComprobantes.Size = New System.Drawing.Size(142, 13)
        Me.lblModoConsultarComprobantes.TabIndex = 0
        Me.lblModoConsultarComprobantes.Text = "Recuperar comprobantes de"
        '
        'chbDias
        '
        Me.chbDias.AutoSize = True
        Me.chbDias.BindearPropiedadControl = Nothing
        Me.chbDias.BindearPropiedadEntidad = Nothing
        Me.chbDias.Enabled = False
        Me.chbDias.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDias.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDias.IsPK = False
        Me.chbDias.IsRequired = False
        Me.chbDias.Key = Nothing
        Me.chbDias.LabelAsoc = Nothing
        Me.chbDias.Location = New System.Drawing.Point(642, 42)
        Me.chbDias.Name = "chbDias"
        Me.chbDias.Size = New System.Drawing.Size(47, 17)
        Me.chbDias.TabIndex = 10
        Me.chbDias.Text = "Dias"
        Me.chbDias.UseVisualStyleBackColor = True
        '
        'cmbDias
        '
        Me.cmbDias.BindearPropiedadControl = "SelectedValue"
        Me.cmbDias.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cmbDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDias.Enabled = False
        Me.cmbDias.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDias.FormattingEnabled = True
        Me.cmbDias.IsPK = False
        Me.cmbDias.IsRequired = True
        Me.cmbDias.Key = Nothing
        Me.cmbDias.LabelAsoc = Nothing
        Me.cmbDias.Location = New System.Drawing.Point(695, 40)
        Me.cmbDias.Name = "cmbDias"
        Me.cmbDias.Size = New System.Drawing.Size(75, 21)
        Me.cmbDias.TabIndex = 11
        '
        'cmbRuta
        '
        Me.cmbRuta.BindearPropiedadControl = "SelectedValue"
        Me.cmbRuta.BindearPropiedadEntidad = "idCancha"
        Me.cmbRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRuta.Enabled = False
        Me.cmbRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRuta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRuta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRuta.FormattingEnabled = True
        Me.cmbRuta.IsPK = False
        Me.cmbRuta.IsRequired = True
        Me.cmbRuta.Key = Nothing
        Me.cmbRuta.LabelAsoc = Nothing
        Me.cmbRuta.Location = New System.Drawing.Point(439, 40)
        Me.cmbRuta.Name = "cmbRuta"
        Me.cmbRuta.Size = New System.Drawing.Size(197, 21)
        Me.cmbRuta.TabIndex = 9
        '
        'chbRuta
        '
        Me.chbRuta.AutoSize = True
        Me.chbRuta.BindearPropiedadControl = Nothing
        Me.chbRuta.BindearPropiedadEntidad = Nothing
        Me.chbRuta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRuta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRuta.IsPK = False
        Me.chbRuta.IsRequired = False
        Me.chbRuta.Key = Nothing
        Me.chbRuta.LabelAsoc = Nothing
        Me.chbRuta.Location = New System.Drawing.Point(345, 42)
        Me.chbRuta.Name = "chbRuta"
        Me.chbRuta.Size = New System.Drawing.Size(49, 17)
        Me.chbRuta.TabIndex = 8
        Me.chbRuta.Text = "Ruta"
        Me.chbRuta.UseVisualStyleBackColor = True
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
        Me.chbVendedor.Location = New System.Drawing.Point(9, 69)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 12
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = "SelectedValue"
        Me.cmbVendedor.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Enabled = False
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = True
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Me.chbVendedor
        Me.cmbVendedor.Location = New System.Drawing.Point(157, 67)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(182, 21)
        Me.cmbVendedor.TabIndex = 13
        '
        'cmbModoConsultarComprobantes
        '
        Me.cmbModoConsultarComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbModoConsultarComprobantes.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cmbModoConsultarComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModoConsultarComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModoConsultarComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModoConsultarComprobantes.FormattingEnabled = True
        Me.cmbModoConsultarComprobantes.IsPK = False
        Me.cmbModoConsultarComprobantes.IsRequired = True
        Me.cmbModoConsultarComprobantes.Key = Nothing
        Me.cmbModoConsultarComprobantes.LabelAsoc = Me.lblModoConsultarComprobantes
        Me.cmbModoConsultarComprobantes.Location = New System.Drawing.Point(157, 13)
        Me.cmbModoConsultarComprobantes.Name = "cmbModoConsultarComprobantes"
        Me.cmbModoConsultarComprobantes.Size = New System.Drawing.Size(182, 21)
        Me.cmbModoConsultarComprobantes.TabIndex = 1
        '
        'cmbLocalidad
        '
        Me.cmbLocalidad.BindearPropiedadControl = "SelectedValue"
        Me.cmbLocalidad.BindearPropiedadEntidad = "idLocalidad"
        Me.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalidad.Enabled = False
        Me.cmbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLocalidad.FormattingEnabled = True
        Me.cmbLocalidad.IsPK = False
        Me.cmbLocalidad.IsRequired = True
        Me.cmbLocalidad.Key = Nothing
        Me.cmbLocalidad.LabelAsoc = Nothing
        Me.cmbLocalidad.Location = New System.Drawing.Point(439, 67)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(197, 21)
        Me.cmbLocalidad.TabIndex = 15
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(887, 43)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 45)
        Me.btnBuscar.TabIndex = 16
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'chbRespDistribucion
        '
        Me.chbRespDistribucion.AutoSize = True
        Me.chbRespDistribucion.BindearPropiedadControl = Nothing
        Me.chbRespDistribucion.BindearPropiedadEntidad = Nothing
        Me.chbRespDistribucion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRespDistribucion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRespDistribucion.IsPK = False
        Me.chbRespDistribucion.IsRequired = False
        Me.chbRespDistribucion.Key = Nothing
        Me.chbRespDistribucion.LabelAsoc = Nothing
        Me.chbRespDistribucion.Location = New System.Drawing.Point(9, 42)
        Me.chbRespDistribucion.Name = "chbRespDistribucion"
        Me.chbRespDistribucion.Size = New System.Drawing.Size(112, 17)
        Me.chbRespDistribucion.TabIndex = 6
        Me.chbRespDistribucion.Text = "Resp. Distribución"
        Me.chbRespDistribucion.UseVisualStyleBackColor = True
        '
        'cmbRespDistribucion
        '
        Me.cmbRespDistribucion.BindearPropiedadControl = "SelectedValue"
        Me.cmbRespDistribucion.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cmbRespDistribucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRespDistribucion.Enabled = False
        Me.cmbRespDistribucion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRespDistribucion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRespDistribucion.FormattingEnabled = True
        Me.cmbRespDistribucion.IsPK = False
        Me.cmbRespDistribucion.IsRequired = True
        Me.cmbRespDistribucion.Key = Nothing
        Me.cmbRespDistribucion.LabelAsoc = Nothing
        Me.cmbRespDistribucion.Location = New System.Drawing.Point(157, 40)
        Me.cmbRespDistribucion.Name = "cmbRespDistribucion"
        Me.cmbRespDistribucion.Size = New System.Drawing.Size(182, 21)
        Me.cmbRespDistribucion.TabIndex = 7
        '
        'chbLocalidad
        '
        Me.chbLocalidad.AutoSize = True
        Me.chbLocalidad.BindearPropiedadControl = Nothing
        Me.chbLocalidad.BindearPropiedadEntidad = Nothing
        Me.chbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLocalidad.IsPK = False
        Me.chbLocalidad.IsRequired = False
        Me.chbLocalidad.Key = Nothing
        Me.chbLocalidad.LabelAsoc = Nothing
        Me.chbLocalidad.Location = New System.Drawing.Point(345, 69)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 14
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHasta.IsPK = False
        Me.dtpFechaHasta.IsRequired = False
        Me.dtpFechaHasta.Key = ""
        Me.dtpFechaHasta.LabelAsoc = Nothing
        Me.dtpFechaHasta.Location = New System.Drawing.Point(602, 13)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaHasta.TabIndex = 5
        '
        'chbFechaHasta
        '
        Me.chbFechaHasta.AutoSize = True
        Me.chbFechaHasta.BindearPropiedadControl = Nothing
        Me.chbFechaHasta.BindearPropiedadEntidad = Nothing
        Me.chbFechaHasta.Checked = True
        Me.chbFechaHasta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaHasta.IsPK = False
        Me.chbFechaHasta.IsRequired = False
        Me.chbFechaHasta.Key = Nothing
        Me.chbFechaHasta.LabelAsoc = Nothing
        Me.chbFechaHasta.Location = New System.Drawing.Point(542, 15)
        Me.chbFechaHasta.Name = "chbFechaHasta"
        Me.chbFechaHasta.Size = New System.Drawing.Size(54, 17)
        Me.chbFechaHasta.TabIndex = 4
        Me.chbFechaHasta.Text = "Hasta"
        '
        'tstSecundaria
        '
        Me.tstSecundaria.AllowItemReorder = True
        Me.tstSecundaria.BackColor = System.Drawing.Color.Silver
        Me.tstSecundaria.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstSecundaria.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslNCSeleccionada, Me.tsbEfectivo, Me.tsbVarias, Me.tsbCC, Me.tsbNC, Me.tsbReenvio, Me.tsbNoRendir, Me.ToolStripSeparator3, Me.tsbImprimir})
        Me.tstSecundaria.Location = New System.Drawing.Point(5, 0)
        Me.tstSecundaria.Name = "tstSecundaria"
        Me.tstSecundaria.Size = New System.Drawing.Size(996, 29)
        Me.tstSecundaria.TabIndex = 2
        Me.tstSecundaria.Text = "toolStrip1"
        '
        'tslNCSeleccionada
        '
        Me.tslNCSeleccionada.Name = "tslNCSeleccionada"
        Me.tslNCSeleccionada.Size = New System.Drawing.Size(502, 26)
        Me.tslNCSeleccionada.Text = "Para aplicar una Nota de Crédito debe seleccionar débito y seleccionar Otra Forma" &
    " de Registro"
        Me.tslNCSeleccionada.Visible = False
        '
        'tsbEfectivo
        '
        Me.tsbEfectivo.Image = CType(resources.GetObject("tsbEfectivo.Image"), System.Drawing.Image)
        Me.tsbEfectivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEfectivo.Name = "tsbEfectivo"
        Me.tsbEfectivo.Size = New System.Drawing.Size(72, 26)
        Me.tsbEfectivo.Text = "Pagada"
        Me.tsbEfectivo.ToolTipText = "Cancela el saldo del comprobante 100% en efectivo"
        '
        'tsbVarias
        '
        Me.tsbVarias.Image = CType(resources.GetObject("tsbVarias.Image"), System.Drawing.Image)
        Me.tsbVarias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVarias.Name = "tsbVarias"
        Me.tsbVarias.Size = New System.Drawing.Size(155, 26)
        Me.tsbVarias.Text = "Otra Forma de Registro"
        '
        'tsbCC
        '
        Me.tsbCC.Image = CType(resources.GetObject("tsbCC.Image"), System.Drawing.Image)
        Me.tsbCC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCC.Name = "tsbCC"
        Me.tsbCC.Size = New System.Drawing.Size(159, 26)
        Me.tsbCC.Text = "Pasa a Cuenta Corriente"
        Me.tsbCC.ToolTipText = "Envia el comprobante seleccionado a Cuenta Corriente sin haberlo cobrado"
        '
        'tsbNC
        '
        Me.tsbNC.Image = CType(resources.GetObject("tsbNC.Image"), System.Drawing.Image)
        Me.tsbNC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNC.Name = "tsbNC"
        Me.tsbNC.Size = New System.Drawing.Size(78, 26)
        Me.tsbNC.Text = "NC Total"
        Me.tsbNC.ToolTipText = "Genera una nota de crédito por el 100% del comprobante"
        '
        'tsbReenvio
        '
        Me.tsbReenvio.Image = CType(resources.GetObject("tsbReenvio.Image"), System.Drawing.Image)
        Me.tsbReenvio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReenvio.Name = "tsbReenvio"
        Me.tsbReenvio.Size = New System.Drawing.Size(83, 26)
        Me.tsbReenvio.Text = "Re-Enviar"
        Me.tsbReenvio.ToolTipText = "Libera el comprobante del reparto para ser reenviado en un reparto futuro"
        '
        'tsbNoRendir
        '
        Me.tsbNoRendir.Image = CType(resources.GetObject("tsbNoRendir.Image"), System.Drawing.Image)
        Me.tsbNoRendir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNoRendir.Name = "tsbNoRendir"
        Me.tsbNoRendir.Size = New System.Drawing.Size(86, 26)
        Me.tsbNoRendir.Text = "No Rendir"
        Me.tsbNoRendir.ToolTipText = "Elimina la marca de rendido del comprobante seleccionado"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.ugvDetallePedidos)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(1006, 452)
        '
        'ugvDetallePedidos
        '
        Me.ugvDetallePedidos.DataSource = Me.bdsComprobantesSeleccionados
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvDetallePedidos.DisplayLayout.Appearance = Appearance49
        Appearance50.TextHAlignAsString = "Right"
        UltraGridColumn132.CellAppearance = Appearance50
        UltraGridColumn132.Header.Caption = "Id Sucursal"
        UltraGridColumn132.Header.VisiblePosition = 30
        UltraGridColumn132.Hidden = True
        UltraGridColumn133.Header.Caption = "Tipo"
        UltraGridColumn133.Header.VisiblePosition = 13
        UltraGridColumn133.Width = 90
        Appearance51.TextHAlignAsString = "Center"
        UltraGridColumn134.CellAppearance = Appearance51
        UltraGridColumn134.Header.Caption = "L"
        UltraGridColumn134.Header.VisiblePosition = 14
        UltraGridColumn134.Width = 25
        Appearance52.TextHAlignAsString = "Right"
        UltraGridColumn135.CellAppearance = Appearance52
        UltraGridColumn135.Header.Caption = "Emisor"
        UltraGridColumn135.Header.VisiblePosition = 15
        UltraGridColumn135.Hidden = True
        Appearance53.TextHAlignAsString = "Right"
        UltraGridColumn136.CellAppearance = Appearance53
        UltraGridColumn136.Header.Caption = "Nro."
        UltraGridColumn136.Header.VisiblePosition = 16
        UltraGridColumn136.Width = 40
        Appearance54.TextHAlignAsString = "Center"
        UltraGridColumn137.CellAppearance = Appearance54
        UltraGridColumn137.Header.VisiblePosition = 0
        UltraGridColumn137.Hidden = True
        UltraGridColumn138.Header.Caption = "Medio Pago"
        UltraGridColumn138.Header.VisiblePosition = 1
        UltraGridColumn138.Hidden = True
        UltraGridColumn139.Header.Caption = "Forma Pago"
        UltraGridColumn139.Header.VisiblePosition = 2
        Appearance55.TextHAlignAsString = "Right"
        UltraGridColumn140.CellAppearance = Appearance55
        UltraGridColumn140.Header.Caption = "Id Cliente"
        UltraGridColumn140.Header.VisiblePosition = 32
        UltraGridColumn140.Hidden = True
        Appearance56.TextHAlignAsString = "Right"
        UltraGridColumn141.CellAppearance = Appearance56
        UltraGridColumn141.Header.Caption = "Código"
        UltraGridColumn141.Header.VisiblePosition = 4
        UltraGridColumn141.Width = 50
        UltraGridColumn142.Header.Caption = "Tipo Doc Cliente"
        UltraGridColumn142.Header.VisiblePosition = 33
        UltraGridColumn142.Hidden = True
        Appearance57.TextHAlignAsString = "Right"
        UltraGridColumn143.CellAppearance = Appearance57
        UltraGridColumn143.Header.Caption = "Nro Doc Cliente"
        UltraGridColumn143.Header.VisiblePosition = 34
        UltraGridColumn143.Hidden = True
        UltraGridColumn144.Header.Caption = "Cliente"
        UltraGridColumn144.Header.VisiblePosition = 5
        UltraGridColumn144.Width = 130
        UltraGridColumn145.Header.VisiblePosition = 6
        UltraGridColumn145.Width = 110
        UltraGridColumn147.Header.Caption = "Localidad"
        UltraGridColumn147.Header.VisiblePosition = 7
        UltraGridColumn147.Hidden = True
        UltraGridColumn148.Header.Caption = "Provincia"
        UltraGridColumn148.Header.VisiblePosition = 8
        UltraGridColumn148.Hidden = True
        Appearance58.TextHAlignAsString = "Right"
        UltraGridColumn149.CellAppearance = Appearance58
        UltraGridColumn149.Header.Caption = "Id Transportista"
        UltraGridColumn149.Header.VisiblePosition = 35
        UltraGridColumn149.Hidden = True
        UltraGridColumn150.Header.Caption = "Resp. Distribución"
        UltraGridColumn150.Header.VisiblePosition = 19
        UltraGridColumn150.Width = 105
        Appearance59.TextHAlignAsString = "Right"
        UltraGridColumn151.CellAppearance = Appearance59
        UltraGridColumn151.Header.Caption = "Id Vendedor"
        UltraGridColumn151.Header.VisiblePosition = 31
        UltraGridColumn151.Hidden = True
        UltraGridColumn152.Header.Caption = "Vendedor"
        UltraGridColumn152.Header.VisiblePosition = 22
        Appearance60.TextHAlignAsString = "Center"
        UltraGridColumn153.CellAppearance = Appearance60
        UltraGridColumn153.Format = "dd/MM/yyyy"
        UltraGridColumn153.Header.Caption = "Fecha Comp."
        UltraGridColumn153.Header.VisiblePosition = 21
        Appearance61.TextHAlignAsString = "Center"
        UltraGridColumn154.CellAppearance = Appearance61
        UltraGridColumn154.Format = "dd/MM/yyyy"
        UltraGridColumn154.Header.Caption = "F. Envio"
        UltraGridColumn154.Header.VisiblePosition = 18
        UltraGridColumn154.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn154.Width = 64
        Appearance62.TextHAlignAsString = "Right"
        UltraGridColumn155.CellAppearance = Appearance62
        UltraGridColumn155.Format = "N2"
        UltraGridColumn155.Header.Caption = "Total"
        UltraGridColumn155.Header.VisiblePosition = 10
        UltraGridColumn155.MaskInput = "{double:-12.2}"
        UltraGridColumn155.Width = 70
        Appearance63.TextHAlignAsString = "Right"
        UltraGridColumn156.CellAppearance = Appearance63
        UltraGridColumn156.Format = "N2"
        UltraGridColumn156.Header.Caption = "Saldo"
        UltraGridColumn156.Header.VisiblePosition = 11
        Appearance64.TextHAlignAsString = "Right"
        UltraGridColumn157.CellAppearance = Appearance64
        UltraGridColumn157.Header.Caption = "Id Categoría Fiscal"
        UltraGridColumn157.Header.VisiblePosition = 36
        UltraGridColumn157.Hidden = True
        UltraGridColumn158.Header.Caption = "Categoria Fiscal"
        UltraGridColumn158.Header.VisiblePosition = 9
        UltraGridColumn158.Hidden = True
        Appearance65.TextHAlignAsString = "Right"
        UltraGridColumn159.CellAppearance = Appearance65
        UltraGridColumn159.Header.Caption = "Reparto"
        UltraGridColumn159.Header.VisiblePosition = 17
        Appearance66.TextHAlignAsString = "Center"
        UltraGridColumn160.CellAppearance = Appearance66
        UltraGridColumn160.Format = "dd/MM/yyyy"
        UltraGridColumn160.Header.Caption = "Fecha Alta"
        UltraGridColumn160.Header.VisiblePosition = 37
        UltraGridColumn160.Hidden = True
        UltraGridColumn160.Width = 64
        Appearance67.TextHAlignAsString = "Right"
        UltraGridColumn161.CellAppearance = Appearance67
        UltraGridColumn161.Header.Caption = "Id Formas Pago"
        UltraGridColumn161.Header.VisiblePosition = 38
        UltraGridColumn161.Hidden = True
        UltraGridColumn162.Header.Caption = "F.P. Pedido"
        UltraGridColumn162.Header.VisiblePosition = 3
        UltraGridColumn162.Width = 70
        Appearance68.TextHAlignAsString = "Right"
        UltraGridColumn163.CellAppearance = Appearance68
        UltraGridColumn163.Format = "N2"
        UltraGridColumn163.Header.Caption = "Saldo Cliente"
        UltraGridColumn163.Header.VisiblePosition = 20
        UltraGridColumn163.Width = 90
        Appearance69.TextHAlignAsString = "Right"
        UltraGridColumn164.CellAppearance = Appearance69
        UltraGridColumn164.Format = "N2"
        UltraGridColumn164.Header.Caption = "Efectivo"
        UltraGridColumn164.Header.VisiblePosition = 23
        UltraGridColumn164.Width = 90
        Appearance70.TextHAlignAsString = "Right"
        UltraGridColumn165.CellAppearance = Appearance70
        UltraGridColumn165.Format = "N2"
        UltraGridColumn165.Header.Caption = "Cuenta Corriente"
        UltraGridColumn165.Header.VisiblePosition = 26
        UltraGridColumn165.Width = 90
        Appearance71.TextHAlignAsString = "Right"
        UltraGridColumn166.CellAppearance = Appearance71
        UltraGridColumn166.Format = "N2"
        UltraGridColumn166.Header.Caption = "Cheques"
        UltraGridColumn166.Header.VisiblePosition = 25
        UltraGridColumn166.Width = 90
        Appearance72.TextHAlignAsString = "Right"
        UltraGridColumn167.CellAppearance = Appearance72
        UltraGridColumn167.Format = "N2"
        UltraGridColumn167.Header.Caption = "Nota de Crédito"
        UltraGridColumn167.Header.VisiblePosition = 27
        UltraGridColumn167.Width = 90
        Appearance73.TextHAlignAsString = "Right"
        UltraGridColumn168.CellAppearance = Appearance73
        UltraGridColumn168.Format = "N2"
        UltraGridColumn168.Header.Caption = "Aplicado"
        UltraGridColumn168.Header.VisiblePosition = 28
        UltraGridColumn168.Width = 90
        Appearance74.TextHAlignAsString = "Right"
        UltraGridColumn169.CellAppearance = Appearance74
        UltraGridColumn169.Format = "N2"
        UltraGridColumn169.Header.Caption = "Reenvio"
        UltraGridColumn169.Header.VisiblePosition = 29
        UltraGridColumn169.Width = 90
        Appearance75.TextHAlignAsString = "Right"
        UltraGridColumn170.CellAppearance = Appearance75
        UltraGridColumn170.Format = "N2"
        UltraGridColumn170.Header.Caption = "Rendido"
        UltraGridColumn170.Header.VisiblePosition = 12
        UltraGridColumn170.Width = 90
        UltraGridColumn171.Header.Caption = "Graba Libro"
        UltraGridColumn171.Header.VisiblePosition = 39
        UltraGridColumn171.Hidden = True
        UltraGridColumn172.Header.Caption = "Tipo Comp. NC"
        UltraGridColumn172.Header.VisiblePosition = 40
        UltraGridColumn172.Hidden = True
        UltraGridColumn173.Header.VisiblePosition = 41
        UltraGridColumn174.Header.VisiblePosition = 42
        Appearance76.TextHAlignAsString = "Right"
        UltraGridColumn175.CellAppearance = Appearance76
        UltraGridColumn175.Format = "N2"
        UltraGridColumn175.Header.Caption = "Transferencia"
        UltraGridColumn175.Header.VisiblePosition = 24
        UltraGridColumn176.Header.VisiblePosition = 43
        UltraGridColumn176.Hidden = True
        UltraGridColumn177.Header.VisiblePosition = 44
        UltraGridColumn177.Hidden = True
        UltraGridColumn177.Width = 90
        UltraGridColumn178.Header.VisiblePosition = 45
        UltraGridColumn179.Header.VisiblePosition = 46
        UltraGridColumn180.Header.VisiblePosition = 47
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn132, UltraGridColumn133, UltraGridColumn134, UltraGridColumn135, UltraGridColumn136, UltraGridColumn137, UltraGridColumn138, UltraGridColumn139, UltraGridColumn140, UltraGridColumn141, UltraGridColumn142, UltraGridColumn143, UltraGridColumn144, UltraGridColumn145, UltraGridColumn147, UltraGridColumn148, UltraGridColumn149, UltraGridColumn150, UltraGridColumn151, UltraGridColumn152, UltraGridColumn153, UltraGridColumn154, UltraGridColumn155, UltraGridColumn156, UltraGridColumn157, UltraGridColumn158, UltraGridColumn159, UltraGridColumn160, UltraGridColumn161, UltraGridColumn162, UltraGridColumn163, UltraGridColumn164, UltraGridColumn165, UltraGridColumn166, UltraGridColumn167, UltraGridColumn168, UltraGridColumn169, UltraGridColumn170, UltraGridColumn171, UltraGridColumn172, UltraGridColumn173, UltraGridColumn174, UltraGridColumn175, UltraGridColumn176, UltraGridColumn177, UltraGridColumn178, UltraGridColumn179, UltraGridColumn180})
        Appearance77.TextHAlignAsString = "Right"
        UltraGridColumn181.CellAppearance = Appearance77
        UltraGridColumn181.Header.VisiblePosition = 0
        UltraGridColumn181.Hidden = True
        UltraGridColumn181.Width = 56
        UltraGridColumn182.Header.VisiblePosition = 1
        UltraGridColumn182.Hidden = True
        UltraGridColumn182.Width = 69
        UltraGridColumn183.Header.VisiblePosition = 2
        UltraGridColumn183.Hidden = True
        UltraGridColumn183.Width = 50
        Appearance78.TextHAlignAsString = "Right"
        UltraGridColumn184.CellAppearance = Appearance78
        UltraGridColumn184.Header.VisiblePosition = 3
        UltraGridColumn184.Hidden = True
        UltraGridColumn184.Width = 130
        Appearance79.TextHAlignAsString = "Right"
        UltraGridColumn185.CellAppearance = Appearance79
        UltraGridColumn185.Header.VisiblePosition = 4
        UltraGridColumn185.Hidden = True
        UltraGridColumn185.Width = 110
        Appearance80.TextHAlignAsString = "Right"
        UltraGridColumn186.CellAppearance = Appearance80
        UltraGridColumn186.Header.Caption = "Código"
        UltraGridColumn186.Header.VisiblePosition = 6
        UltraGridColumn186.MaxWidth = 80
        UltraGridColumn186.Width = 80
        Appearance81.TextHAlignAsString = "Right"
        UltraGridColumn187.CellAppearance = Appearance81
        UltraGridColumn187.Header.VisiblePosition = 5
        UltraGridColumn187.MaxWidth = 50
        UltraGridColumn187.MinWidth = 50
        UltraGridColumn187.Width = 50
        UltraGridColumn188.Header.Caption = "Producto"
        UltraGridColumn188.Header.VisiblePosition = 7
        UltraGridColumn188.Width = 377
        Appearance82.TextHAlignAsString = "Right"
        UltraGridColumn189.CellAppearance = Appearance82
        UltraGridColumn189.Format = "N2"
        UltraGridColumn189.Header.VisiblePosition = 8
        UltraGridColumn189.MaskInput = "{double:-12.2}"
        UltraGridColumn189.MaxWidth = 60
        UltraGridColumn189.MinWidth = 60
        UltraGridColumn189.Width = 60
        UltraGridColumn190.Header.VisiblePosition = 9
        Appearance83.TextHAlignAsString = "Right"
        UltraGridColumn191.CellAppearance = Appearance83
        UltraGridColumn191.Format = "N2"
        UltraGridColumn191.Header.VisiblePosition = 10
        UltraGridColumn191.MaskInput = "{double:-12.2}"
        UltraGridColumn191.MaxWidth = 60
        UltraGridColumn191.MinWidth = 60
        UltraGridColumn192.Header.VisiblePosition = 12
        Appearance84.TextHAlignAsString = "Right"
        UltraGridColumn193.CellAppearance = Appearance84
        UltraGridColumn193.Format = "N2"
        UltraGridColumn193.Header.Caption = "Total"
        UltraGridColumn193.Header.VisiblePosition = 11
        UltraGridColumn193.MaskInput = "{double:-12.2}"
        UltraGridColumn193.MaxWidth = 60
        UltraGridColumn193.MinWidth = 60
        UltraGridColumn193.Width = 60
        Appearance85.TextHAlignAsString = "Right"
        UltraGridColumn194.CellAppearance = Appearance85
        UltraGridColumn194.Format = "N2"
        UltraGridColumn194.Header.VisiblePosition = 13
        UltraGridColumn194.Hidden = True
        UltraGridColumn194.MaskInput = "{double:-12.2}"
        UltraGridColumn194.MaxWidth = 60
        UltraGridColumn194.MinWidth = 60
        UltraGridColumn194.Width = 60
        UltraGridColumn195.Header.VisiblePosition = 14
        UltraGridColumn195.Hidden = True
        UltraGridColumn195.MaxWidth = 50
        UltraGridColumn196.Header.VisiblePosition = 15
        UltraGridColumn196.Hidden = True
        UltraGridColumn196.Width = 64
        Appearance86.TextHAlignAsString = "Right"
        UltraGridColumn197.CellAppearance = Appearance86
        UltraGridColumn197.Format = "N2"
        UltraGridColumn197.Header.VisiblePosition = 16
        UltraGridColumn197.Hidden = True
        UltraGridColumn197.MaskInput = "{double:-12.2}"
        UltraGridColumn197.MaxWidth = 60
        UltraGridColumn197.MinWidth = 60
        UltraGridColumn197.Width = 60
        UltraGridColumn198.Header.VisiblePosition = 17
        UltraGridColumn198.Hidden = True
        UltraGridColumn199.Header.VisiblePosition = 18
        UltraGridColumn199.Hidden = True
        UltraGridColumn200.Header.VisiblePosition = 21
        UltraGridColumn201.Header.VisiblePosition = 19
        UltraGridColumn201.Hidden = True
        UltraGridColumn202.Header.VisiblePosition = 20
        UltraGridColumn202.Hidden = True
        UltraGridColumn203.Header.Caption = "Tp. Operación"
        UltraGridColumn203.Header.VisiblePosition = 22
        UltraGridColumn203.Width = 85
        UltraGridColumn204.Header.VisiblePosition = 23
        UltraGridColumn204.Width = 186
        UltraGridColumn205.Header.VisiblePosition = 24
        UltraGridColumn206.Header.VisiblePosition = 25
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn181, UltraGridColumn182, UltraGridColumn183, UltraGridColumn184, UltraGridColumn185, UltraGridColumn186, UltraGridColumn187, UltraGridColumn188, UltraGridColumn189, UltraGridColumn190, UltraGridColumn191, UltraGridColumn192, UltraGridColumn193, UltraGridColumn194, UltraGridColumn195, UltraGridColumn196, UltraGridColumn197, UltraGridColumn198, UltraGridColumn199, UltraGridColumn200, UltraGridColumn201, UltraGridColumn202, UltraGridColumn203, UltraGridColumn204, UltraGridColumn205, UltraGridColumn206})
        UltraGridColumn207.Header.VisiblePosition = 0
        UltraGridColumn208.Header.VisiblePosition = 1
        UltraGridColumn209.Header.VisiblePosition = 2
        UltraGridColumn210.Header.VisiblePosition = 3
        UltraGridColumn211.Header.VisiblePosition = 4
        UltraGridColumn212.Header.VisiblePosition = 5
        UltraGridColumn213.Header.VisiblePosition = 6
        UltraGridColumn214.Header.VisiblePosition = 7
        UltraGridColumn215.Header.VisiblePosition = 8
        UltraGridColumn216.Header.VisiblePosition = 9
        UltraGridColumn217.Header.VisiblePosition = 10
        UltraGridColumn218.Header.VisiblePosition = 11
        UltraGridColumn219.Header.VisiblePosition = 12
        UltraGridColumn220.Header.VisiblePosition = 13
        UltraGridColumn221.Header.VisiblePosition = 14
        UltraGridColumn222.Header.VisiblePosition = 15
        UltraGridColumn223.Header.VisiblePosition = 16
        UltraGridColumn224.Header.VisiblePosition = 17
        UltraGridColumn225.Header.VisiblePosition = 18
        UltraGridColumn226.Header.VisiblePosition = 19
        UltraGridColumn227.Header.VisiblePosition = 20
        UltraGridBand7.Columns.AddRange(New Object() {UltraGridColumn207, UltraGridColumn208, UltraGridColumn209, UltraGridColumn210, UltraGridColumn211, UltraGridColumn212, UltraGridColumn213, UltraGridColumn214, UltraGridColumn215, UltraGridColumn216, UltraGridColumn217, UltraGridColumn218, UltraGridColumn219, UltraGridColumn220, UltraGridColumn221, UltraGridColumn222, UltraGridColumn223, UltraGridColumn224, UltraGridColumn225, UltraGridColumn226, UltraGridColumn227})
        UltraGridBand7.Hidden = True
        UltraGridColumn228.Header.VisiblePosition = 0
        UltraGridColumn229.Header.VisiblePosition = 1
        UltraGridColumn230.Header.VisiblePosition = 2
        UltraGridColumn231.Header.VisiblePosition = 3
        UltraGridColumn232.Header.VisiblePosition = 4
        UltraGridColumn233.Header.VisiblePosition = 5
        UltraGridColumn234.Header.VisiblePosition = 6
        UltraGridColumn235.Header.VisiblePosition = 7
        UltraGridColumn236.Header.VisiblePosition = 8
        UltraGridColumn237.Header.VisiblePosition = 9
        UltraGridColumn238.Header.VisiblePosition = 10
        UltraGridColumn239.Header.VisiblePosition = 11
        UltraGridColumn240.Header.VisiblePosition = 12
        UltraGridColumn241.Header.VisiblePosition = 13
        UltraGridColumn242.Header.VisiblePosition = 14
        UltraGridBand8.Columns.AddRange(New Object() {UltraGridColumn228, UltraGridColumn229, UltraGridColumn230, UltraGridColumn231, UltraGridColumn232, UltraGridColumn233, UltraGridColumn234, UltraGridColumn235, UltraGridColumn236, UltraGridColumn237, UltraGridColumn238, UltraGridColumn239, UltraGridColumn240, UltraGridColumn241, UltraGridColumn242})
        Me.ugvDetallePedidos.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.ugvDetallePedidos.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.ugvDetallePedidos.DisplayLayout.BandsSerializer.Add(UltraGridBand7)
        Me.ugvDetallePedidos.DisplayLayout.BandsSerializer.Add(UltraGridBand8)
        Me.ugvDetallePedidos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvDetallePedidos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance87.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance87.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance87.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance87.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Appearance = Appearance87
        Appearance88.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance88
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance89.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance89.BackColor2 = System.Drawing.SystemColors.Control
        Appearance89.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance89.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.PromptAppearance = Appearance89
        Me.ugvDetallePedidos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvDetallePedidos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance90.BackColor = System.Drawing.SystemColors.Window
        Appearance90.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvDetallePedidos.DisplayLayout.Override.ActiveCellAppearance = Appearance90
        Appearance91.BackColor = System.Drawing.SystemColors.Highlight
        Appearance91.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvDetallePedidos.DisplayLayout.Override.ActiveRowAppearance = Appearance91
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvDetallePedidos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvDetallePedidos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance92.BackColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.Override.CardAreaAppearance = Appearance92
        Appearance93.BorderColor = System.Drawing.Color.Silver
        Appearance93.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvDetallePedidos.DisplayLayout.Override.CellAppearance = Appearance93
        Me.ugvDetallePedidos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvDetallePedidos.DisplayLayout.Override.CellPadding = 0
        Appearance94.BackColor = System.Drawing.SystemColors.Control
        Appearance94.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance94.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance94.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.Override.GroupByRowAppearance = Appearance94
        Appearance95.TextHAlignAsString = "Left"
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderAppearance = Appearance95
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance96.BackColor = System.Drawing.SystemColors.Window
        Appearance96.BorderColor = System.Drawing.Color.Silver
        Me.ugvDetallePedidos.DisplayLayout.Override.RowAppearance = Appearance96
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance97.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvDetallePedidos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance97
        Me.ugvDetallePedidos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvDetallePedidos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvDetallePedidos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvDetallePedidos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvDetallePedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvDetallePedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvDetallePedidos.Location = New System.Drawing.Point(5, 0)
        Me.ugvDetallePedidos.Name = "ugvDetallePedidos"
        Me.ugvDetallePedidos.Size = New System.Drawing.Size(996, 447)
        Me.ugvDetallePedidos.TabIndex = 1
        '
        'bdsComprobantesSeleccionados
        '
        Me.bdsComprobantesSeleccionados.DataMember = "Comprobantes"
        Me.bdsComprobantesSeleccionados.DataSource = Me.DtsRegistracionPagosV2
        Me.bdsComprobantesSeleccionados.Filter = ""
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.ugEfectivo)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1006, 452)
        '
        'ugEfectivo
        '
        Me.ugEfectivo.DataSource = Me.EfectivoBindingSource
        Appearance98.BackColor = System.Drawing.SystemColors.Window
        Appearance98.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugEfectivo.DisplayLayout.Appearance = Appearance98
        UltraGridColumn243.Header.VisiblePosition = 0
        UltraGridColumn244.Header.VisiblePosition = 1
        UltraGridColumn245.Header.VisiblePosition = 2
        UltraGridColumn246.Header.VisiblePosition = 3
        UltraGridColumn247.Header.VisiblePosition = 4
        UltraGridColumn248.Header.VisiblePosition = 5
        UltraGridColumn249.Header.VisiblePosition = 6
        UltraGridColumn250.Header.VisiblePosition = 7
        UltraGridColumn251.Header.VisiblePosition = 8
        UltraGridColumn252.Header.VisiblePosition = 9
        UltraGridColumn253.Header.VisiblePosition = 10
        UltraGridColumn254.Header.VisiblePosition = 11
        UltraGridColumn255.Header.VisiblePosition = 12
        UltraGridColumn257.Header.VisiblePosition = 13
        UltraGridColumn258.Header.VisiblePosition = 14
        UltraGridColumn259.Header.VisiblePosition = 15
        UltraGridColumn260.Header.VisiblePosition = 16
        UltraGridColumn261.Header.VisiblePosition = 17
        UltraGridColumn262.Header.VisiblePosition = 18
        UltraGridColumn263.Header.VisiblePosition = 19
        UltraGridColumn264.Header.VisiblePosition = 20
        UltraGridColumn265.Header.VisiblePosition = 21
        UltraGridColumn266.Header.VisiblePosition = 22
        UltraGridColumn267.Header.VisiblePosition = 23
        UltraGridColumn268.Header.VisiblePosition = 24
        UltraGridColumn269.Header.VisiblePosition = 25
        UltraGridColumn270.Header.VisiblePosition = 26
        UltraGridColumn271.Header.VisiblePosition = 27
        UltraGridColumn272.Header.VisiblePosition = 28
        UltraGridColumn273.Header.VisiblePosition = 29
        UltraGridColumn274.Header.VisiblePosition = 30
        UltraGridColumn275.Header.VisiblePosition = 31
        UltraGridColumn276.Header.VisiblePosition = 32
        UltraGridColumn277.Header.VisiblePosition = 33
        UltraGridColumn278.Header.VisiblePosition = 34
        UltraGridColumn279.Header.VisiblePosition = 35
        UltraGridColumn280.Header.VisiblePosition = 36
        UltraGridColumn281.Header.VisiblePosition = 37
        UltraGridColumn282.Header.VisiblePosition = 38
        UltraGridColumn283.Header.VisiblePosition = 39
        UltraGridColumn284.Header.VisiblePosition = 40
        UltraGridColumn285.Header.VisiblePosition = 41
        UltraGridColumn286.Header.VisiblePosition = 42
        UltraGridColumn287.Header.VisiblePosition = 43
        UltraGridColumn288.Header.VisiblePosition = 44
        UltraGridColumn289.Header.VisiblePosition = 45
        UltraGridColumn290.Header.VisiblePosition = 46
        UltraGridColumn291.Header.VisiblePosition = 47
        UltraGridBand9.Columns.AddRange(New Object() {UltraGridColumn243, UltraGridColumn244, UltraGridColumn245, UltraGridColumn246, UltraGridColumn247, UltraGridColumn248, UltraGridColumn249, UltraGridColumn250, UltraGridColumn251, UltraGridColumn252, UltraGridColumn253, UltraGridColumn254, UltraGridColumn255, UltraGridColumn257, UltraGridColumn258, UltraGridColumn259, UltraGridColumn260, UltraGridColumn261, UltraGridColumn262, UltraGridColumn263, UltraGridColumn264, UltraGridColumn265, UltraGridColumn266, UltraGridColumn267, UltraGridColumn268, UltraGridColumn269, UltraGridColumn270, UltraGridColumn271, UltraGridColumn272, UltraGridColumn273, UltraGridColumn274, UltraGridColumn275, UltraGridColumn276, UltraGridColumn277, UltraGridColumn278, UltraGridColumn279, UltraGridColumn280, UltraGridColumn281, UltraGridColumn282, UltraGridColumn283, UltraGridColumn284, UltraGridColumn285, UltraGridColumn286, UltraGridColumn287, UltraGridColumn288, UltraGridColumn289, UltraGridColumn290, UltraGridColumn291})
        UltraGridColumn292.Header.VisiblePosition = 0
        UltraGridColumn293.Header.VisiblePosition = 1
        UltraGridColumn294.Header.VisiblePosition = 2
        UltraGridColumn295.Header.VisiblePosition = 3
        UltraGridColumn296.Header.VisiblePosition = 4
        UltraGridColumn297.Header.VisiblePosition = 5
        UltraGridColumn298.Header.VisiblePosition = 6
        UltraGridColumn299.Header.VisiblePosition = 7
        UltraGridColumn300.Header.VisiblePosition = 8
        UltraGridColumn301.Header.VisiblePosition = 9
        UltraGridColumn302.Header.VisiblePosition = 10
        UltraGridColumn303.Header.VisiblePosition = 11
        UltraGridColumn304.Header.VisiblePosition = 12
        UltraGridColumn305.Header.VisiblePosition = 13
        UltraGridColumn306.Header.VisiblePosition = 14
        UltraGridColumn307.Header.VisiblePosition = 15
        UltraGridColumn308.Header.VisiblePosition = 16
        UltraGridColumn309.Header.VisiblePosition = 17
        UltraGridColumn310.Header.VisiblePosition = 18
        UltraGridColumn311.Header.VisiblePosition = 19
        UltraGridColumn312.Header.VisiblePosition = 20
        UltraGridColumn313.Header.VisiblePosition = 21
        UltraGridColumn314.Header.VisiblePosition = 22
        UltraGridColumn315.Header.VisiblePosition = 23
        UltraGridColumn316.Header.VisiblePosition = 24
        UltraGridColumn317.Header.VisiblePosition = 25
        UltraGridBand10.Columns.AddRange(New Object() {UltraGridColumn292, UltraGridColumn293, UltraGridColumn294, UltraGridColumn295, UltraGridColumn296, UltraGridColumn297, UltraGridColumn298, UltraGridColumn299, UltraGridColumn300, UltraGridColumn301, UltraGridColumn302, UltraGridColumn303, UltraGridColumn304, UltraGridColumn305, UltraGridColumn306, UltraGridColumn307, UltraGridColumn308, UltraGridColumn309, UltraGridColumn310, UltraGridColumn311, UltraGridColumn312, UltraGridColumn313, UltraGridColumn314, UltraGridColumn315, UltraGridColumn316, UltraGridColumn317})
        UltraGridColumn318.Header.VisiblePosition = 0
        UltraGridColumn319.Header.VisiblePosition = 1
        UltraGridColumn320.Header.VisiblePosition = 2
        UltraGridColumn321.Header.VisiblePosition = 3
        UltraGridColumn322.Header.VisiblePosition = 4
        UltraGridColumn323.Header.VisiblePosition = 5
        UltraGridColumn324.Header.VisiblePosition = 6
        UltraGridColumn325.Header.VisiblePosition = 7
        UltraGridColumn326.Header.VisiblePosition = 8
        UltraGridColumn327.Header.VisiblePosition = 9
        UltraGridColumn328.Header.VisiblePosition = 10
        UltraGridColumn329.Header.VisiblePosition = 11
        UltraGridColumn330.Header.VisiblePosition = 12
        UltraGridColumn331.Header.VisiblePosition = 13
        UltraGridColumn332.Header.VisiblePosition = 14
        UltraGridColumn333.Header.VisiblePosition = 15
        UltraGridColumn334.Header.VisiblePosition = 16
        UltraGridColumn335.Header.VisiblePosition = 17
        UltraGridColumn336.Header.VisiblePosition = 18
        UltraGridColumn337.Header.VisiblePosition = 19
        UltraGridColumn338.Header.VisiblePosition = 20
        UltraGridBand11.Columns.AddRange(New Object() {UltraGridColumn318, UltraGridColumn319, UltraGridColumn320, UltraGridColumn321, UltraGridColumn322, UltraGridColumn323, UltraGridColumn324, UltraGridColumn325, UltraGridColumn326, UltraGridColumn327, UltraGridColumn328, UltraGridColumn329, UltraGridColumn330, UltraGridColumn331, UltraGridColumn332, UltraGridColumn333, UltraGridColumn334, UltraGridColumn335, UltraGridColumn336, UltraGridColumn337, UltraGridColumn338})
        UltraGridColumn339.Header.VisiblePosition = 0
        UltraGridColumn340.Header.VisiblePosition = 1
        UltraGridColumn341.Header.VisiblePosition = 2
        UltraGridColumn342.Header.VisiblePosition = 3
        UltraGridColumn343.Header.VisiblePosition = 4
        UltraGridColumn344.Header.VisiblePosition = 5
        UltraGridColumn345.Header.VisiblePosition = 6
        UltraGridColumn346.Header.VisiblePosition = 7
        UltraGridColumn347.Header.VisiblePosition = 8
        UltraGridColumn348.Header.VisiblePosition = 9
        UltraGridColumn349.Header.VisiblePosition = 10
        UltraGridColumn350.Header.VisiblePosition = 11
        UltraGridColumn351.Header.VisiblePosition = 12
        UltraGridColumn352.Header.VisiblePosition = 13
        UltraGridColumn353.Header.VisiblePosition = 14
        UltraGridBand12.Columns.AddRange(New Object() {UltraGridColumn339, UltraGridColumn340, UltraGridColumn341, UltraGridColumn342, UltraGridColumn343, UltraGridColumn344, UltraGridColumn345, UltraGridColumn346, UltraGridColumn347, UltraGridColumn348, UltraGridColumn349, UltraGridColumn350, UltraGridColumn351, UltraGridColumn352, UltraGridColumn353})
        Me.ugEfectivo.DisplayLayout.BandsSerializer.Add(UltraGridBand9)
        Me.ugEfectivo.DisplayLayout.BandsSerializer.Add(UltraGridBand10)
        Me.ugEfectivo.DisplayLayout.BandsSerializer.Add(UltraGridBand11)
        Me.ugEfectivo.DisplayLayout.BandsSerializer.Add(UltraGridBand12)
        Me.ugEfectivo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugEfectivo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance99.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance99.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance99.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance99.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEfectivo.DisplayLayout.GroupByBox.Appearance = Appearance99
        Appearance100.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEfectivo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance100
        Me.ugEfectivo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugEfectivo.DisplayLayout.GroupByBox.Hidden = True
        Me.ugEfectivo.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance101.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance101.BackColor2 = System.Drawing.SystemColors.Control
        Appearance101.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance101.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEfectivo.DisplayLayout.GroupByBox.PromptAppearance = Appearance101
        Me.ugEfectivo.DisplayLayout.MaxColScrollRegions = 1
        Me.ugEfectivo.DisplayLayout.MaxRowScrollRegions = 1
        Appearance102.BackColor = System.Drawing.SystemColors.Window
        Appearance102.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugEfectivo.DisplayLayout.Override.ActiveCellAppearance = Appearance102
        Appearance103.BackColor = System.Drawing.SystemColors.Highlight
        Appearance103.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugEfectivo.DisplayLayout.Override.ActiveRowAppearance = Appearance103
        Me.ugEfectivo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugEfectivo.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugEfectivo.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugEfectivo.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugEfectivo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugEfectivo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugEfectivo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance104.BackColor = System.Drawing.SystemColors.Window
        Me.ugEfectivo.DisplayLayout.Override.CardAreaAppearance = Appearance104
        Appearance105.BorderColor = System.Drawing.Color.Silver
        Appearance105.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugEfectivo.DisplayLayout.Override.CellAppearance = Appearance105
        Me.ugEfectivo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugEfectivo.DisplayLayout.Override.CellPadding = 0
        Appearance106.BackColor = System.Drawing.SystemColors.Control
        Appearance106.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance106.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance106.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance106.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEfectivo.DisplayLayout.Override.GroupByRowAppearance = Appearance106
        Appearance107.TextHAlignAsString = "Left"
        Me.ugEfectivo.DisplayLayout.Override.HeaderAppearance = Appearance107
        Me.ugEfectivo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugEfectivo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance108.BackColor = System.Drawing.SystemColors.Window
        Appearance108.BorderColor = System.Drawing.Color.Silver
        Me.ugEfectivo.DisplayLayout.Override.RowAppearance = Appearance108
        Me.ugEfectivo.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugEfectivo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugEfectivo.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugEfectivo.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugEfectivo.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugEfectivo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugEfectivo.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance109.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugEfectivo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance109
        Me.ugEfectivo.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugEfectivo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugEfectivo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugEfectivo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugEfectivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugEfectivo.Location = New System.Drawing.Point(5, 0)
        Me.ugEfectivo.Name = "ugEfectivo"
        Me.ugEfectivo.Size = New System.Drawing.Size(996, 447)
        Me.ugEfectivo.TabIndex = 1
        Me.ugEfectivo.Text = "UltraGrid1"
        '
        'EfectivoBindingSource
        '
        Me.EfectivoBindingSource.DataMember = "Comprobantes"
        Me.EfectivoBindingSource.DataSource = Me.DtsRegistracionPagosV2
        Me.EfectivoBindingSource.Filter = ""
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.ugCtaCte)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1006, 452)
        '
        'ugCtaCte
        '
        Me.ugCtaCte.DataSource = Me.CtaCteBindingSource
        Appearance110.BackColor = System.Drawing.SystemColors.Window
        Appearance110.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugCtaCte.DisplayLayout.Appearance = Appearance110
        UltraGridColumn354.Header.VisiblePosition = 0
        UltraGridColumn355.Header.VisiblePosition = 1
        UltraGridColumn356.Header.VisiblePosition = 2
        UltraGridColumn357.Header.VisiblePosition = 3
        UltraGridColumn358.Header.VisiblePosition = 4
        UltraGridColumn359.Header.VisiblePosition = 5
        UltraGridColumn360.Header.VisiblePosition = 6
        UltraGridColumn361.Header.VisiblePosition = 7
        UltraGridColumn362.Header.VisiblePosition = 8
        UltraGridColumn363.Header.VisiblePosition = 9
        UltraGridColumn364.Header.VisiblePosition = 10
        UltraGridColumn365.Header.VisiblePosition = 11
        UltraGridColumn366.Header.VisiblePosition = 12
        UltraGridColumn367.Header.VisiblePosition = 13
        UltraGridColumn369.Header.VisiblePosition = 14
        UltraGridColumn370.Header.VisiblePosition = 15
        UltraGridColumn371.Header.VisiblePosition = 16
        UltraGridColumn372.Header.VisiblePosition = 17
        UltraGridColumn373.Header.VisiblePosition = 18
        UltraGridColumn374.Header.VisiblePosition = 19
        UltraGridColumn375.Header.VisiblePosition = 20
        UltraGridColumn376.Header.VisiblePosition = 21
        UltraGridColumn377.Header.VisiblePosition = 22
        UltraGridColumn378.Header.VisiblePosition = 23
        UltraGridColumn379.Header.VisiblePosition = 24
        UltraGridColumn380.Header.VisiblePosition = 25
        UltraGridColumn381.Header.VisiblePosition = 26
        UltraGridColumn382.Header.VisiblePosition = 27
        UltraGridColumn383.Header.VisiblePosition = 28
        UltraGridColumn384.Header.VisiblePosition = 29
        UltraGridColumn385.Header.VisiblePosition = 30
        UltraGridColumn386.Header.VisiblePosition = 31
        UltraGridColumn387.Header.VisiblePosition = 32
        UltraGridColumn388.Header.VisiblePosition = 33
        UltraGridColumn389.Header.VisiblePosition = 34
        UltraGridColumn390.Header.VisiblePosition = 35
        UltraGridColumn391.Header.VisiblePosition = 36
        UltraGridColumn392.Header.VisiblePosition = 37
        UltraGridColumn393.Header.VisiblePosition = 38
        UltraGridColumn394.Header.VisiblePosition = 39
        UltraGridColumn395.Header.VisiblePosition = 40
        UltraGridColumn396.Header.VisiblePosition = 41
        UltraGridColumn397.Header.VisiblePosition = 42
        UltraGridColumn398.Header.VisiblePosition = 43
        UltraGridColumn399.Header.VisiblePosition = 44
        UltraGridColumn400.Header.VisiblePosition = 45
        UltraGridColumn401.Header.VisiblePosition = 46
        UltraGridColumn402.Header.VisiblePosition = 47
        UltraGridBand13.Columns.AddRange(New Object() {UltraGridColumn354, UltraGridColumn355, UltraGridColumn356, UltraGridColumn357, UltraGridColumn358, UltraGridColumn359, UltraGridColumn360, UltraGridColumn361, UltraGridColumn362, UltraGridColumn363, UltraGridColumn364, UltraGridColumn365, UltraGridColumn366, UltraGridColumn367, UltraGridColumn369, UltraGridColumn370, UltraGridColumn371, UltraGridColumn372, UltraGridColumn373, UltraGridColumn374, UltraGridColumn375, UltraGridColumn376, UltraGridColumn377, UltraGridColumn378, UltraGridColumn379, UltraGridColumn380, UltraGridColumn381, UltraGridColumn382, UltraGridColumn383, UltraGridColumn384, UltraGridColumn385, UltraGridColumn386, UltraGridColumn387, UltraGridColumn388, UltraGridColumn389, UltraGridColumn390, UltraGridColumn391, UltraGridColumn392, UltraGridColumn393, UltraGridColumn394, UltraGridColumn395, UltraGridColumn396, UltraGridColumn397, UltraGridColumn398, UltraGridColumn399, UltraGridColumn400, UltraGridColumn401, UltraGridColumn402})
        UltraGridColumn403.Header.VisiblePosition = 0
        UltraGridColumn404.Header.VisiblePosition = 1
        UltraGridColumn405.Header.VisiblePosition = 2
        UltraGridColumn406.Header.VisiblePosition = 3
        UltraGridColumn407.Header.VisiblePosition = 4
        UltraGridColumn408.Header.VisiblePosition = 5
        UltraGridColumn409.Header.VisiblePosition = 6
        UltraGridColumn410.Header.VisiblePosition = 7
        UltraGridColumn411.Header.VisiblePosition = 8
        UltraGridColumn412.Header.VisiblePosition = 9
        UltraGridColumn413.Header.VisiblePosition = 10
        UltraGridColumn414.Header.VisiblePosition = 11
        UltraGridColumn415.Header.VisiblePosition = 12
        UltraGridColumn416.Header.VisiblePosition = 13
        UltraGridColumn417.Header.VisiblePosition = 14
        UltraGridColumn418.Header.VisiblePosition = 15
        UltraGridColumn419.Header.VisiblePosition = 16
        UltraGridColumn420.Header.VisiblePosition = 17
        UltraGridColumn421.Header.VisiblePosition = 18
        UltraGridColumn422.Header.VisiblePosition = 19
        UltraGridColumn423.Header.VisiblePosition = 20
        UltraGridColumn424.Header.VisiblePosition = 21
        UltraGridColumn425.Header.VisiblePosition = 22
        UltraGridColumn426.Header.VisiblePosition = 23
        UltraGridColumn427.Header.VisiblePosition = 24
        UltraGridColumn428.Header.VisiblePosition = 25
        UltraGridBand14.Columns.AddRange(New Object() {UltraGridColumn403, UltraGridColumn404, UltraGridColumn405, UltraGridColumn406, UltraGridColumn407, UltraGridColumn408, UltraGridColumn409, UltraGridColumn410, UltraGridColumn411, UltraGridColumn412, UltraGridColumn413, UltraGridColumn414, UltraGridColumn415, UltraGridColumn416, UltraGridColumn417, UltraGridColumn418, UltraGridColumn419, UltraGridColumn420, UltraGridColumn421, UltraGridColumn422, UltraGridColumn423, UltraGridColumn424, UltraGridColumn425, UltraGridColumn426, UltraGridColumn427, UltraGridColumn428})
        UltraGridColumn429.Header.VisiblePosition = 0
        UltraGridColumn430.Header.VisiblePosition = 1
        UltraGridColumn431.Header.VisiblePosition = 2
        UltraGridColumn432.Header.VisiblePosition = 3
        UltraGridColumn433.Header.VisiblePosition = 4
        UltraGridColumn434.Header.VisiblePosition = 5
        UltraGridColumn435.Header.VisiblePosition = 6
        UltraGridColumn436.Header.VisiblePosition = 7
        UltraGridColumn437.Header.VisiblePosition = 8
        UltraGridColumn438.Header.VisiblePosition = 9
        UltraGridColumn439.Header.VisiblePosition = 10
        UltraGridColumn440.Header.VisiblePosition = 11
        UltraGridColumn441.Header.VisiblePosition = 12
        UltraGridColumn442.Header.VisiblePosition = 13
        UltraGridColumn443.Header.VisiblePosition = 14
        UltraGridColumn444.Header.VisiblePosition = 15
        UltraGridColumn445.Header.VisiblePosition = 16
        UltraGridColumn446.Header.VisiblePosition = 17
        UltraGridColumn447.Header.VisiblePosition = 18
        UltraGridColumn448.Header.VisiblePosition = 19
        UltraGridColumn449.Header.VisiblePosition = 20
        UltraGridBand15.Columns.AddRange(New Object() {UltraGridColumn429, UltraGridColumn430, UltraGridColumn431, UltraGridColumn432, UltraGridColumn433, UltraGridColumn434, UltraGridColumn435, UltraGridColumn436, UltraGridColumn437, UltraGridColumn438, UltraGridColumn439, UltraGridColumn440, UltraGridColumn441, UltraGridColumn442, UltraGridColumn443, UltraGridColumn444, UltraGridColumn445, UltraGridColumn446, UltraGridColumn447, UltraGridColumn448, UltraGridColumn449})
        UltraGridColumn450.Header.VisiblePosition = 0
        UltraGridColumn451.Header.VisiblePosition = 1
        UltraGridColumn452.Header.VisiblePosition = 2
        UltraGridColumn453.Header.VisiblePosition = 3
        UltraGridColumn454.Header.VisiblePosition = 4
        UltraGridColumn455.Header.VisiblePosition = 5
        UltraGridColumn456.Header.VisiblePosition = 6
        UltraGridColumn457.Header.VisiblePosition = 7
        UltraGridColumn458.Header.VisiblePosition = 8
        UltraGridColumn459.Header.VisiblePosition = 9
        UltraGridColumn460.Header.VisiblePosition = 10
        UltraGridColumn461.Header.VisiblePosition = 11
        UltraGridColumn462.Header.VisiblePosition = 12
        UltraGridColumn463.Header.VisiblePosition = 13
        UltraGridColumn464.Header.VisiblePosition = 14
        UltraGridBand16.Columns.AddRange(New Object() {UltraGridColumn450, UltraGridColumn451, UltraGridColumn452, UltraGridColumn453, UltraGridColumn454, UltraGridColumn455, UltraGridColumn456, UltraGridColumn457, UltraGridColumn458, UltraGridColumn459, UltraGridColumn460, UltraGridColumn461, UltraGridColumn462, UltraGridColumn463, UltraGridColumn464})
        Me.ugCtaCte.DisplayLayout.BandsSerializer.Add(UltraGridBand13)
        Me.ugCtaCte.DisplayLayout.BandsSerializer.Add(UltraGridBand14)
        Me.ugCtaCte.DisplayLayout.BandsSerializer.Add(UltraGridBand15)
        Me.ugCtaCte.DisplayLayout.BandsSerializer.Add(UltraGridBand16)
        Me.ugCtaCte.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugCtaCte.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance111.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance111.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance111.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance111.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCtaCte.DisplayLayout.GroupByBox.Appearance = Appearance111
        Appearance112.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCtaCte.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance112
        Me.ugCtaCte.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCtaCte.DisplayLayout.GroupByBox.Hidden = True
        Me.ugCtaCte.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance113.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance113.BackColor2 = System.Drawing.SystemColors.Control
        Appearance113.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance113.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCtaCte.DisplayLayout.GroupByBox.PromptAppearance = Appearance113
        Me.ugCtaCte.DisplayLayout.MaxColScrollRegions = 1
        Me.ugCtaCte.DisplayLayout.MaxRowScrollRegions = 1
        Appearance114.BackColor = System.Drawing.SystemColors.Window
        Appearance114.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugCtaCte.DisplayLayout.Override.ActiveCellAppearance = Appearance114
        Appearance115.BackColor = System.Drawing.SystemColors.Highlight
        Appearance115.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugCtaCte.DisplayLayout.Override.ActiveRowAppearance = Appearance115
        Me.ugCtaCte.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugCtaCte.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugCtaCte.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugCtaCte.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugCtaCte.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugCtaCte.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugCtaCte.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance116.BackColor = System.Drawing.SystemColors.Window
        Me.ugCtaCte.DisplayLayout.Override.CardAreaAppearance = Appearance116
        Appearance117.BorderColor = System.Drawing.Color.Silver
        Appearance117.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugCtaCte.DisplayLayout.Override.CellAppearance = Appearance117
        Me.ugCtaCte.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugCtaCte.DisplayLayout.Override.CellPadding = 0
        Appearance118.BackColor = System.Drawing.SystemColors.Control
        Appearance118.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance118.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance118.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance118.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCtaCte.DisplayLayout.Override.GroupByRowAppearance = Appearance118
        Appearance119.TextHAlignAsString = "Left"
        Me.ugCtaCte.DisplayLayout.Override.HeaderAppearance = Appearance119
        Me.ugCtaCte.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugCtaCte.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance120.BackColor = System.Drawing.SystemColors.Window
        Appearance120.BorderColor = System.Drawing.Color.Silver
        Me.ugCtaCte.DisplayLayout.Override.RowAppearance = Appearance120
        Me.ugCtaCte.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugCtaCte.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugCtaCte.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugCtaCte.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugCtaCte.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugCtaCte.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugCtaCte.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance121.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugCtaCte.DisplayLayout.Override.TemplateAddRowAppearance = Appearance121
        Me.ugCtaCte.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugCtaCte.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugCtaCte.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugCtaCte.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugCtaCte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugCtaCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugCtaCte.Location = New System.Drawing.Point(5, 0)
        Me.ugCtaCte.Name = "ugCtaCte"
        Me.ugCtaCte.Size = New System.Drawing.Size(996, 447)
        Me.ugCtaCte.TabIndex = 1
        Me.ugCtaCte.Text = "UltraGrid2"
        '
        'CtaCteBindingSource
        '
        Me.CtaCteBindingSource.DataMember = "Comprobantes"
        Me.CtaCteBindingSource.DataSource = Me.DtsRegistracionPagosV2
        Me.CtaCteBindingSource.Filter = ""
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.ugCheque)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(1006, 452)
        '
        'ugCheque
        '
        Me.ugCheque.DataSource = Me.ChequesBindingSource
        Appearance122.BackColor = System.Drawing.SystemColors.Window
        Appearance122.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugCheque.DisplayLayout.Appearance = Appearance122
        UltraGridColumn465.Header.VisiblePosition = 0
        UltraGridColumn466.Header.VisiblePosition = 1
        UltraGridColumn467.Header.VisiblePosition = 2
        UltraGridColumn468.Header.VisiblePosition = 3
        UltraGridColumn469.Header.VisiblePosition = 4
        UltraGridColumn470.Header.VisiblePosition = 5
        UltraGridColumn471.Header.VisiblePosition = 6
        UltraGridColumn472.Header.VisiblePosition = 7
        UltraGridColumn473.Header.VisiblePosition = 8
        UltraGridColumn474.Header.VisiblePosition = 9
        UltraGridColumn475.Header.VisiblePosition = 10
        UltraGridColumn476.Header.VisiblePosition = 11
        UltraGridColumn477.Header.VisiblePosition = 12
        UltraGridColumn479.Header.VisiblePosition = 13
        UltraGridColumn480.Header.VisiblePosition = 14
        UltraGridColumn481.Header.VisiblePosition = 15
        UltraGridColumn482.Header.VisiblePosition = 16
        UltraGridColumn483.Header.VisiblePosition = 17
        UltraGridColumn484.Header.VisiblePosition = 18
        UltraGridColumn485.Header.VisiblePosition = 19
        UltraGridColumn486.Header.VisiblePosition = 20
        UltraGridColumn487.Header.VisiblePosition = 21
        UltraGridColumn488.Header.VisiblePosition = 22
        UltraGridColumn489.Header.VisiblePosition = 23
        UltraGridColumn490.Header.VisiblePosition = 24
        UltraGridColumn491.Header.VisiblePosition = 25
        UltraGridColumn492.Header.VisiblePosition = 26
        UltraGridColumn493.Header.VisiblePosition = 27
        UltraGridColumn494.Header.VisiblePosition = 28
        UltraGridColumn495.Header.VisiblePosition = 29
        UltraGridColumn496.Header.VisiblePosition = 30
        UltraGridColumn497.Header.VisiblePosition = 31
        UltraGridColumn498.Header.VisiblePosition = 32
        UltraGridColumn499.Header.VisiblePosition = 33
        UltraGridColumn500.Header.VisiblePosition = 34
        UltraGridColumn501.Header.VisiblePosition = 35
        UltraGridColumn502.Header.VisiblePosition = 36
        UltraGridColumn503.Header.VisiblePosition = 37
        UltraGridColumn504.Header.VisiblePosition = 38
        UltraGridColumn505.Header.VisiblePosition = 39
        UltraGridColumn506.Header.VisiblePosition = 40
        UltraGridColumn507.Header.VisiblePosition = 41
        UltraGridColumn508.Header.VisiblePosition = 42
        UltraGridColumn509.Header.VisiblePosition = 43
        UltraGridColumn510.Header.VisiblePosition = 44
        UltraGridColumn511.Header.VisiblePosition = 45
        UltraGridColumn512.Header.VisiblePosition = 46
        UltraGridColumn513.Header.VisiblePosition = 47
        UltraGridBand17.Columns.AddRange(New Object() {UltraGridColumn465, UltraGridColumn466, UltraGridColumn467, UltraGridColumn468, UltraGridColumn469, UltraGridColumn470, UltraGridColumn471, UltraGridColumn472, UltraGridColumn473, UltraGridColumn474, UltraGridColumn475, UltraGridColumn476, UltraGridColumn477, UltraGridColumn479, UltraGridColumn480, UltraGridColumn481, UltraGridColumn482, UltraGridColumn483, UltraGridColumn484, UltraGridColumn485, UltraGridColumn486, UltraGridColumn487, UltraGridColumn488, UltraGridColumn489, UltraGridColumn490, UltraGridColumn491, UltraGridColumn492, UltraGridColumn493, UltraGridColumn494, UltraGridColumn495, UltraGridColumn496, UltraGridColumn497, UltraGridColumn498, UltraGridColumn499, UltraGridColumn500, UltraGridColumn501, UltraGridColumn502, UltraGridColumn503, UltraGridColumn504, UltraGridColumn505, UltraGridColumn506, UltraGridColumn507, UltraGridColumn508, UltraGridColumn509, UltraGridColumn510, UltraGridColumn511, UltraGridColumn512, UltraGridColumn513})
        UltraGridColumn514.Header.VisiblePosition = 0
        UltraGridColumn515.Header.VisiblePosition = 1
        UltraGridColumn516.Header.VisiblePosition = 2
        UltraGridColumn517.Header.VisiblePosition = 3
        UltraGridColumn518.Header.VisiblePosition = 4
        UltraGridColumn519.Header.VisiblePosition = 5
        UltraGridColumn520.Header.VisiblePosition = 6
        UltraGridColumn521.Header.VisiblePosition = 7
        UltraGridColumn522.Header.VisiblePosition = 8
        UltraGridColumn523.Header.VisiblePosition = 9
        UltraGridColumn524.Header.VisiblePosition = 10
        UltraGridColumn525.Header.VisiblePosition = 11
        UltraGridColumn526.Header.VisiblePosition = 12
        UltraGridColumn527.Header.VisiblePosition = 13
        UltraGridColumn528.Header.VisiblePosition = 14
        UltraGridColumn529.Header.VisiblePosition = 15
        UltraGridColumn530.Header.VisiblePosition = 16
        UltraGridColumn531.Header.VisiblePosition = 17
        UltraGridColumn532.Header.VisiblePosition = 18
        UltraGridColumn533.Header.VisiblePosition = 19
        UltraGridColumn534.Header.VisiblePosition = 20
        UltraGridColumn535.Header.VisiblePosition = 21
        UltraGridColumn536.Header.VisiblePosition = 22
        UltraGridColumn537.Header.VisiblePosition = 23
        UltraGridColumn538.Header.VisiblePosition = 24
        UltraGridColumn539.Header.VisiblePosition = 25
        UltraGridBand18.Columns.AddRange(New Object() {UltraGridColumn514, UltraGridColumn515, UltraGridColumn516, UltraGridColumn517, UltraGridColumn518, UltraGridColumn519, UltraGridColumn520, UltraGridColumn521, UltraGridColumn522, UltraGridColumn523, UltraGridColumn524, UltraGridColumn525, UltraGridColumn526, UltraGridColumn527, UltraGridColumn528, UltraGridColumn529, UltraGridColumn530, UltraGridColumn531, UltraGridColumn532, UltraGridColumn533, UltraGridColumn534, UltraGridColumn535, UltraGridColumn536, UltraGridColumn537, UltraGridColumn538, UltraGridColumn539})
        UltraGridColumn540.Header.VisiblePosition = 0
        UltraGridColumn541.Header.VisiblePosition = 1
        UltraGridColumn542.Header.VisiblePosition = 2
        UltraGridColumn543.Header.VisiblePosition = 3
        UltraGridColumn544.Header.VisiblePosition = 4
        UltraGridColumn545.Header.VisiblePosition = 5
        UltraGridColumn546.Header.VisiblePosition = 6
        UltraGridColumn547.Header.VisiblePosition = 7
        UltraGridColumn548.Header.VisiblePosition = 8
        UltraGridColumn549.Header.VisiblePosition = 9
        UltraGridColumn550.Header.VisiblePosition = 10
        UltraGridColumn551.Header.VisiblePosition = 11
        UltraGridColumn552.Header.VisiblePosition = 12
        UltraGridColumn553.Header.VisiblePosition = 13
        UltraGridColumn554.Header.VisiblePosition = 14
        UltraGridColumn555.Header.VisiblePosition = 15
        UltraGridColumn556.Header.VisiblePosition = 16
        UltraGridColumn557.Header.VisiblePosition = 17
        UltraGridColumn558.Header.VisiblePosition = 18
        UltraGridColumn559.Header.VisiblePosition = 19
        UltraGridColumn560.Header.VisiblePosition = 20
        UltraGridBand19.Columns.AddRange(New Object() {UltraGridColumn540, UltraGridColumn541, UltraGridColumn542, UltraGridColumn543, UltraGridColumn544, UltraGridColumn545, UltraGridColumn546, UltraGridColumn547, UltraGridColumn548, UltraGridColumn549, UltraGridColumn550, UltraGridColumn551, UltraGridColumn552, UltraGridColumn553, UltraGridColumn554, UltraGridColumn555, UltraGridColumn556, UltraGridColumn557, UltraGridColumn558, UltraGridColumn559, UltraGridColumn560})
        UltraGridColumn561.Header.VisiblePosition = 0
        UltraGridColumn562.Header.VisiblePosition = 1
        UltraGridColumn563.Header.VisiblePosition = 2
        UltraGridColumn564.Header.VisiblePosition = 3
        UltraGridColumn565.Header.VisiblePosition = 4
        UltraGridColumn566.Header.VisiblePosition = 5
        UltraGridColumn567.Header.VisiblePosition = 6
        UltraGridColumn568.Header.VisiblePosition = 7
        UltraGridColumn569.Header.VisiblePosition = 8
        UltraGridColumn570.Header.VisiblePosition = 9
        UltraGridColumn571.Header.VisiblePosition = 10
        UltraGridColumn572.Header.VisiblePosition = 11
        UltraGridColumn573.Header.VisiblePosition = 12
        UltraGridColumn574.Header.VisiblePosition = 13
        UltraGridColumn575.Header.VisiblePosition = 14
        UltraGridBand20.Columns.AddRange(New Object() {UltraGridColumn561, UltraGridColumn562, UltraGridColumn563, UltraGridColumn564, UltraGridColumn565, UltraGridColumn566, UltraGridColumn567, UltraGridColumn568, UltraGridColumn569, UltraGridColumn570, UltraGridColumn571, UltraGridColumn572, UltraGridColumn573, UltraGridColumn574, UltraGridColumn575})
        Me.ugCheque.DisplayLayout.BandsSerializer.Add(UltraGridBand17)
        Me.ugCheque.DisplayLayout.BandsSerializer.Add(UltraGridBand18)
        Me.ugCheque.DisplayLayout.BandsSerializer.Add(UltraGridBand19)
        Me.ugCheque.DisplayLayout.BandsSerializer.Add(UltraGridBand20)
        Me.ugCheque.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugCheque.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance123.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance123.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance123.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance123.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCheque.DisplayLayout.GroupByBox.Appearance = Appearance123
        Appearance124.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCheque.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance124
        Me.ugCheque.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCheque.DisplayLayout.GroupByBox.Hidden = True
        Me.ugCheque.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance125.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance125.BackColor2 = System.Drawing.SystemColors.Control
        Appearance125.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance125.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCheque.DisplayLayout.GroupByBox.PromptAppearance = Appearance125
        Me.ugCheque.DisplayLayout.MaxColScrollRegions = 1
        Me.ugCheque.DisplayLayout.MaxRowScrollRegions = 1
        Appearance126.BackColor = System.Drawing.SystemColors.Window
        Appearance126.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugCheque.DisplayLayout.Override.ActiveCellAppearance = Appearance126
        Appearance127.BackColor = System.Drawing.SystemColors.Highlight
        Appearance127.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugCheque.DisplayLayout.Override.ActiveRowAppearance = Appearance127
        Me.ugCheque.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugCheque.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugCheque.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugCheque.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugCheque.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugCheque.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugCheque.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance128.BackColor = System.Drawing.SystemColors.Window
        Me.ugCheque.DisplayLayout.Override.CardAreaAppearance = Appearance128
        Appearance129.BorderColor = System.Drawing.Color.Silver
        Appearance129.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugCheque.DisplayLayout.Override.CellAppearance = Appearance129
        Me.ugCheque.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugCheque.DisplayLayout.Override.CellPadding = 0
        Appearance130.BackColor = System.Drawing.SystemColors.Control
        Appearance130.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance130.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance130.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance130.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCheque.DisplayLayout.Override.GroupByRowAppearance = Appearance130
        Appearance131.TextHAlignAsString = "Left"
        Me.ugCheque.DisplayLayout.Override.HeaderAppearance = Appearance131
        Me.ugCheque.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugCheque.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance132.BackColor = System.Drawing.SystemColors.Window
        Appearance132.BorderColor = System.Drawing.Color.Silver
        Me.ugCheque.DisplayLayout.Override.RowAppearance = Appearance132
        Me.ugCheque.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugCheque.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugCheque.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugCheque.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugCheque.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugCheque.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugCheque.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance133.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugCheque.DisplayLayout.Override.TemplateAddRowAppearance = Appearance133
        Me.ugCheque.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugCheque.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugCheque.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugCheque.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugCheque.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugCheque.Location = New System.Drawing.Point(5, 0)
        Me.ugCheque.Name = "ugCheque"
        Me.ugCheque.Size = New System.Drawing.Size(996, 447)
        Me.ugCheque.TabIndex = 0
        Me.ugCheque.Text = "UltraGrid3"
        '
        'ChequesBindingSource
        '
        Me.ChequesBindingSource.DataMember = "Comprobantes"
        Me.ChequesBindingSource.DataSource = Me.DtsRegistracionPagosV2
        Me.ChequesBindingSource.Filter = ""
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.ugNc)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(1006, 452)
        '
        'ugNc
        '
        Me.ugNc.DataSource = Me.NCBindingSource
        Appearance134.BackColor = System.Drawing.SystemColors.Window
        Appearance134.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugNc.DisplayLayout.Appearance = Appearance134
        UltraGridColumn576.Header.VisiblePosition = 0
        UltraGridColumn577.Header.VisiblePosition = 1
        UltraGridColumn578.Header.VisiblePosition = 2
        UltraGridColumn579.Header.VisiblePosition = 3
        UltraGridColumn580.Header.VisiblePosition = 4
        UltraGridColumn581.Header.VisiblePosition = 5
        UltraGridColumn582.Header.VisiblePosition = 6
        UltraGridColumn583.Header.VisiblePosition = 7
        UltraGridColumn584.Header.VisiblePosition = 8
        UltraGridColumn585.Header.VisiblePosition = 9
        UltraGridColumn586.Header.VisiblePosition = 10
        UltraGridColumn587.Header.VisiblePosition = 11
        UltraGridColumn588.Header.VisiblePosition = 12
        UltraGridColumn589.Header.VisiblePosition = 13
        UltraGridColumn590.Header.VisiblePosition = 14
        UltraGridColumn591.Header.VisiblePosition = 15
        UltraGridColumn592.Header.VisiblePosition = 16
        UltraGridColumn593.Header.VisiblePosition = 17
        UltraGridColumn594.Header.VisiblePosition = 18
        UltraGridColumn595.Header.VisiblePosition = 19
        UltraGridColumn597.Header.VisiblePosition = 20
        UltraGridColumn598.Header.VisiblePosition = 21
        UltraGridColumn599.Header.VisiblePosition = 22
        UltraGridColumn600.Header.VisiblePosition = 23
        UltraGridColumn601.Header.VisiblePosition = 24
        UltraGridColumn602.Header.VisiblePosition = 25
        UltraGridColumn603.Header.VisiblePosition = 26
        UltraGridColumn604.Header.VisiblePosition = 27
        UltraGridColumn605.Header.VisiblePosition = 28
        UltraGridColumn606.Header.VisiblePosition = 29
        UltraGridColumn607.Header.VisiblePosition = 30
        UltraGridColumn608.Header.VisiblePosition = 31
        UltraGridColumn609.Header.VisiblePosition = 32
        UltraGridColumn610.Header.VisiblePosition = 33
        UltraGridColumn611.Header.VisiblePosition = 34
        UltraGridColumn612.Header.VisiblePosition = 35
        UltraGridColumn701.Header.VisiblePosition = 36
        UltraGridColumn702.Header.VisiblePosition = 37
        UltraGridColumn715.Header.VisiblePosition = 38
        UltraGridColumn716.Header.VisiblePosition = 39
        UltraGridColumn717.Header.VisiblePosition = 40
        UltraGridColumn718.Header.VisiblePosition = 41
        UltraGridColumn719.Header.VisiblePosition = 42
        UltraGridColumn720.Header.VisiblePosition = 43
        UltraGridColumn721.Header.VisiblePosition = 44
        UltraGridColumn722.Header.VisiblePosition = 45
        UltraGridColumn723.Header.VisiblePosition = 46
        UltraGridColumn724.Header.VisiblePosition = 47
        UltraGridBand21.Columns.AddRange(New Object() {UltraGridColumn576, UltraGridColumn577, UltraGridColumn578, UltraGridColumn579, UltraGridColumn580, UltraGridColumn581, UltraGridColumn582, UltraGridColumn583, UltraGridColumn584, UltraGridColumn585, UltraGridColumn586, UltraGridColumn587, UltraGridColumn588, UltraGridColumn589, UltraGridColumn590, UltraGridColumn591, UltraGridColumn592, UltraGridColumn593, UltraGridColumn594, UltraGridColumn595, UltraGridColumn597, UltraGridColumn598, UltraGridColumn599, UltraGridColumn600, UltraGridColumn601, UltraGridColumn602, UltraGridColumn603, UltraGridColumn604, UltraGridColumn605, UltraGridColumn606, UltraGridColumn607, UltraGridColumn608, UltraGridColumn609, UltraGridColumn610, UltraGridColumn611, UltraGridColumn612, UltraGridColumn701, UltraGridColumn702, UltraGridColumn715, UltraGridColumn716, UltraGridColumn717, UltraGridColumn718, UltraGridColumn719, UltraGridColumn720, UltraGridColumn721, UltraGridColumn722, UltraGridColumn723, UltraGridColumn724})
        UltraGridColumn725.Header.VisiblePosition = 0
        UltraGridColumn742.Header.VisiblePosition = 1
        UltraGridColumn743.Header.VisiblePosition = 2
        UltraGridColumn744.Header.VisiblePosition = 3
        UltraGridColumn745.Header.VisiblePosition = 4
        UltraGridColumn746.Header.VisiblePosition = 5
        UltraGridColumn747.Header.VisiblePosition = 6
        UltraGridColumn749.Header.VisiblePosition = 7
        UltraGridColumn750.Header.VisiblePosition = 8
        UltraGridColumn751.Header.VisiblePosition = 9
        UltraGridColumn752.Header.VisiblePosition = 10
        UltraGridColumn753.Header.VisiblePosition = 11
        UltraGridColumn754.Header.VisiblePosition = 12
        UltraGridColumn755.Header.VisiblePosition = 13
        UltraGridColumn756.Header.VisiblePosition = 14
        UltraGridColumn757.Header.VisiblePosition = 15
        UltraGridColumn758.Header.VisiblePosition = 16
        UltraGridColumn759.Header.VisiblePosition = 17
        UltraGridColumn760.Header.VisiblePosition = 18
        UltraGridColumn761.Header.VisiblePosition = 19
        UltraGridColumn762.Header.VisiblePosition = 20
        UltraGridColumn763.Header.VisiblePosition = 21
        UltraGridColumn764.Header.VisiblePosition = 22
        UltraGridColumn765.Header.VisiblePosition = 23
        UltraGridColumn766.Header.VisiblePosition = 24
        UltraGridColumn767.Header.VisiblePosition = 25
        UltraGridBand22.Columns.AddRange(New Object() {UltraGridColumn725, UltraGridColumn742, UltraGridColumn743, UltraGridColumn744, UltraGridColumn745, UltraGridColumn746, UltraGridColumn747, UltraGridColumn749, UltraGridColumn750, UltraGridColumn751, UltraGridColumn752, UltraGridColumn753, UltraGridColumn754, UltraGridColumn755, UltraGridColumn756, UltraGridColumn757, UltraGridColumn758, UltraGridColumn759, UltraGridColumn760, UltraGridColumn761, UltraGridColumn762, UltraGridColumn763, UltraGridColumn764, UltraGridColumn765, UltraGridColumn766, UltraGridColumn767})
        UltraGridColumn768.Header.VisiblePosition = 0
        UltraGridColumn769.Header.VisiblePosition = 1
        UltraGridColumn770.Header.VisiblePosition = 2
        UltraGridColumn771.Header.VisiblePosition = 3
        UltraGridColumn772.Header.VisiblePosition = 4
        UltraGridColumn773.Header.VisiblePosition = 5
        UltraGridColumn774.Header.VisiblePosition = 6
        UltraGridColumn775.Header.VisiblePosition = 7
        UltraGridColumn776.Header.VisiblePosition = 8
        UltraGridColumn777.Header.VisiblePosition = 9
        UltraGridColumn778.Header.VisiblePosition = 10
        UltraGridColumn779.Header.VisiblePosition = 11
        UltraGridColumn780.Header.VisiblePosition = 12
        UltraGridColumn781.Header.VisiblePosition = 13
        UltraGridColumn782.Header.VisiblePosition = 14
        UltraGridColumn783.Header.VisiblePosition = 15
        UltraGridColumn784.Header.VisiblePosition = 16
        UltraGridColumn785.Header.VisiblePosition = 17
        UltraGridColumn786.Header.VisiblePosition = 18
        UltraGridColumn787.Header.VisiblePosition = 19
        UltraGridColumn788.Header.VisiblePosition = 20
        UltraGridBand23.Columns.AddRange(New Object() {UltraGridColumn768, UltraGridColumn769, UltraGridColumn770, UltraGridColumn771, UltraGridColumn772, UltraGridColumn773, UltraGridColumn774, UltraGridColumn775, UltraGridColumn776, UltraGridColumn777, UltraGridColumn778, UltraGridColumn779, UltraGridColumn780, UltraGridColumn781, UltraGridColumn782, UltraGridColumn783, UltraGridColumn784, UltraGridColumn785, UltraGridColumn786, UltraGridColumn787, UltraGridColumn788})
        UltraGridColumn789.Header.VisiblePosition = 0
        UltraGridColumn790.Header.VisiblePosition = 1
        UltraGridColumn791.Header.VisiblePosition = 2
        UltraGridColumn792.Header.VisiblePosition = 3
        UltraGridColumn793.Header.VisiblePosition = 4
        UltraGridColumn794.Header.VisiblePosition = 5
        UltraGridColumn795.Header.VisiblePosition = 6
        UltraGridColumn796.Header.VisiblePosition = 7
        UltraGridColumn797.Header.VisiblePosition = 8
        UltraGridColumn798.Header.VisiblePosition = 9
        UltraGridColumn799.Header.VisiblePosition = 10
        UltraGridColumn800.Header.VisiblePosition = 11
        UltraGridColumn801.Header.VisiblePosition = 12
        UltraGridColumn802.Header.VisiblePosition = 13
        UltraGridColumn803.Header.VisiblePosition = 14
        UltraGridBand24.Columns.AddRange(New Object() {UltraGridColumn789, UltraGridColumn790, UltraGridColumn791, UltraGridColumn792, UltraGridColumn793, UltraGridColumn794, UltraGridColumn795, UltraGridColumn796, UltraGridColumn797, UltraGridColumn798, UltraGridColumn799, UltraGridColumn800, UltraGridColumn801, UltraGridColumn802, UltraGridColumn803})
        Me.ugNc.DisplayLayout.BandsSerializer.Add(UltraGridBand21)
        Me.ugNc.DisplayLayout.BandsSerializer.Add(UltraGridBand22)
        Me.ugNc.DisplayLayout.BandsSerializer.Add(UltraGridBand23)
        Me.ugNc.DisplayLayout.BandsSerializer.Add(UltraGridBand24)
        Me.ugNc.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugNc.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance135.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance135.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance135.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance135.BorderColor = System.Drawing.SystemColors.Window
        Me.ugNc.DisplayLayout.GroupByBox.Appearance = Appearance135
        Appearance136.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugNc.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance136
        Me.ugNc.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugNc.DisplayLayout.GroupByBox.Hidden = True
        Me.ugNc.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance137.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance137.BackColor2 = System.Drawing.SystemColors.Control
        Appearance137.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance137.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugNc.DisplayLayout.GroupByBox.PromptAppearance = Appearance137
        Me.ugNc.DisplayLayout.MaxColScrollRegions = 1
        Me.ugNc.DisplayLayout.MaxRowScrollRegions = 1
        Appearance138.BackColor = System.Drawing.SystemColors.Window
        Appearance138.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugNc.DisplayLayout.Override.ActiveCellAppearance = Appearance138
        Appearance139.BackColor = System.Drawing.SystemColors.Highlight
        Appearance139.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugNc.DisplayLayout.Override.ActiveRowAppearance = Appearance139
        Me.ugNc.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugNc.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugNc.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugNc.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNc.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNc.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugNc.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance140.BackColor = System.Drawing.SystemColors.Window
        Me.ugNc.DisplayLayout.Override.CardAreaAppearance = Appearance140
        Appearance141.BorderColor = System.Drawing.Color.Silver
        Appearance141.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugNc.DisplayLayout.Override.CellAppearance = Appearance141
        Me.ugNc.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugNc.DisplayLayout.Override.CellPadding = 0
        Appearance142.BackColor = System.Drawing.SystemColors.Control
        Appearance142.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance142.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance142.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance142.BorderColor = System.Drawing.SystemColors.Window
        Me.ugNc.DisplayLayout.Override.GroupByRowAppearance = Appearance142
        Appearance143.TextHAlignAsString = "Left"
        Me.ugNc.DisplayLayout.Override.HeaderAppearance = Appearance143
        Me.ugNc.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugNc.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance144.BackColor = System.Drawing.SystemColors.Window
        Appearance144.BorderColor = System.Drawing.Color.Silver
        Me.ugNc.DisplayLayout.Override.RowAppearance = Appearance144
        Me.ugNc.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugNc.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugNc.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugNc.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugNc.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugNc.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugNc.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance145.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugNc.DisplayLayout.Override.TemplateAddRowAppearance = Appearance145
        Me.ugNc.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugNc.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugNc.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugNc.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugNc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugNc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugNc.Location = New System.Drawing.Point(5, 0)
        Me.ugNc.Name = "ugNc"
        Me.ugNc.Size = New System.Drawing.Size(996, 447)
        Me.ugNc.TabIndex = 1
        Me.ugNc.Text = "UltraGrid4"
        '
        'NCBindingSource
        '
        Me.NCBindingSource.DataMember = "Comprobantes"
        Me.NCBindingSource.DataSource = Me.DtsRegistracionPagosV2
        Me.NCBindingSource.Filter = ""
        '
        'utReenvios
        '
        Me.utReenvios.Controls.Add(Me.ugReenvios)
        Me.utReenvios.Location = New System.Drawing.Point(-10000, -10000)
        Me.utReenvios.Name = "utReenvios"
        Me.utReenvios.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.utReenvios.Size = New System.Drawing.Size(1006, 452)
        '
        'ugReenvios
        '
        Me.ugReenvios.DataSource = Me.ReenviosBindingSource
        Appearance146.BackColor = System.Drawing.SystemColors.Window
        Appearance146.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugReenvios.DisplayLayout.Appearance = Appearance146
        UltraGridColumn804.Header.VisiblePosition = 0
        UltraGridColumn805.Header.VisiblePosition = 1
        UltraGridColumn806.Header.VisiblePosition = 2
        UltraGridColumn807.Header.VisiblePosition = 3
        UltraGridColumn808.Header.VisiblePosition = 4
        UltraGridColumn809.Header.VisiblePosition = 5
        UltraGridColumn810.Header.VisiblePosition = 6
        UltraGridColumn811.Header.VisiblePosition = 7
        UltraGridColumn812.Header.VisiblePosition = 8
        UltraGridColumn813.Header.VisiblePosition = 9
        UltraGridColumn814.Header.VisiblePosition = 10
        UltraGridColumn815.Header.VisiblePosition = 11
        UltraGridColumn816.Header.VisiblePosition = 12
        UltraGridColumn817.Header.VisiblePosition = 13
        UltraGridColumn818.Header.VisiblePosition = 14
        UltraGridColumn819.Header.VisiblePosition = 15
        UltraGridColumn820.Header.VisiblePosition = 16
        UltraGridColumn821.Header.VisiblePosition = 17
        UltraGridColumn822.Header.VisiblePosition = 18
        UltraGridColumn823.Header.VisiblePosition = 19
        UltraGridColumn824.Header.VisiblePosition = 20
        UltraGridColumn825.Header.VisiblePosition = 21
        UltraGridColumn826.Header.VisiblePosition = 22
        UltraGridColumn827.Header.VisiblePosition = 23
        UltraGridColumn828.Header.VisiblePosition = 24
        UltraGridColumn829.Header.VisiblePosition = 25
        UltraGridColumn830.Header.VisiblePosition = 26
        UltraGridColumn831.Header.VisiblePosition = 27
        UltraGridColumn832.Header.VisiblePosition = 28
        UltraGridColumn833.Header.VisiblePosition = 29
        UltraGridColumn834.Header.VisiblePosition = 30
        UltraGridColumn835.Header.VisiblePosition = 31
        UltraGridColumn836.Header.VisiblePosition = 32
        UltraGridColumn837.Header.VisiblePosition = 33
        UltraGridColumn838.Header.VisiblePosition = 34
        UltraGridColumn839.Header.VisiblePosition = 35
        UltraGridColumn840.Header.VisiblePosition = 36
        UltraGridColumn841.Header.VisiblePosition = 37
        UltraGridColumn842.Header.VisiblePosition = 38
        UltraGridColumn843.Header.VisiblePosition = 39
        UltraGridColumn844.Header.VisiblePosition = 40
        UltraGridColumn845.Header.VisiblePosition = 41
        UltraGridColumn846.Header.VisiblePosition = 42
        UltraGridColumn847.Header.VisiblePosition = 43
        UltraGridColumn848.Header.VisiblePosition = 44
        UltraGridColumn849.Header.VisiblePosition = 45
        UltraGridColumn850.Header.VisiblePosition = 46
        UltraGridColumn851.Header.VisiblePosition = 47
        UltraGridBand25.Columns.AddRange(New Object() {UltraGridColumn804, UltraGridColumn805, UltraGridColumn806, UltraGridColumn807, UltraGridColumn808, UltraGridColumn809, UltraGridColumn810, UltraGridColumn811, UltraGridColumn812, UltraGridColumn813, UltraGridColumn814, UltraGridColumn815, UltraGridColumn816, UltraGridColumn817, UltraGridColumn818, UltraGridColumn819, UltraGridColumn820, UltraGridColumn821, UltraGridColumn822, UltraGridColumn823, UltraGridColumn824, UltraGridColumn825, UltraGridColumn826, UltraGridColumn827, UltraGridColumn828, UltraGridColumn829, UltraGridColumn830, UltraGridColumn831, UltraGridColumn832, UltraGridColumn833, UltraGridColumn834, UltraGridColumn835, UltraGridColumn836, UltraGridColumn837, UltraGridColumn838, UltraGridColumn839, UltraGridColumn840, UltraGridColumn841, UltraGridColumn842, UltraGridColumn843, UltraGridColumn844, UltraGridColumn845, UltraGridColumn846, UltraGridColumn847, UltraGridColumn848, UltraGridColumn849, UltraGridColumn850, UltraGridColumn851})
        UltraGridColumn852.Header.VisiblePosition = 0
        UltraGridColumn853.Header.VisiblePosition = 1
        UltraGridColumn854.Header.VisiblePosition = 2
        UltraGridColumn855.Header.VisiblePosition = 3
        UltraGridColumn857.Header.VisiblePosition = 4
        UltraGridColumn858.Header.VisiblePosition = 5
        UltraGridColumn859.Header.VisiblePosition = 6
        UltraGridColumn860.Header.VisiblePosition = 7
        UltraGridColumn861.Header.VisiblePosition = 8
        UltraGridColumn862.Header.VisiblePosition = 9
        UltraGridColumn863.Header.VisiblePosition = 10
        UltraGridColumn864.Header.VisiblePosition = 11
        UltraGridColumn865.Header.VisiblePosition = 12
        UltraGridColumn866.Header.VisiblePosition = 13
        UltraGridColumn867.Header.VisiblePosition = 14
        UltraGridColumn868.Header.VisiblePosition = 15
        UltraGridColumn869.Header.VisiblePosition = 16
        UltraGridColumn870.Header.VisiblePosition = 17
        UltraGridColumn871.Header.VisiblePosition = 18
        UltraGridColumn872.Header.VisiblePosition = 19
        UltraGridColumn1515.Header.VisiblePosition = 20
        UltraGridColumn1516.Header.VisiblePosition = 21
        UltraGridColumn1517.Header.VisiblePosition = 22
        UltraGridColumn1518.Header.VisiblePosition = 23
        UltraGridColumn1519.Header.VisiblePosition = 24
        UltraGridColumn1520.Header.VisiblePosition = 25
        UltraGridBand26.Columns.AddRange(New Object() {UltraGridColumn852, UltraGridColumn853, UltraGridColumn854, UltraGridColumn855, UltraGridColumn857, UltraGridColumn858, UltraGridColumn859, UltraGridColumn860, UltraGridColumn861, UltraGridColumn862, UltraGridColumn863, UltraGridColumn864, UltraGridColumn865, UltraGridColumn866, UltraGridColumn867, UltraGridColumn868, UltraGridColumn869, UltraGridColumn870, UltraGridColumn871, UltraGridColumn872, UltraGridColumn1515, UltraGridColumn1516, UltraGridColumn1517, UltraGridColumn1518, UltraGridColumn1519, UltraGridColumn1520})
        UltraGridColumn1521.Header.VisiblePosition = 0
        UltraGridColumn1522.Header.VisiblePosition = 1
        UltraGridColumn1523.Header.VisiblePosition = 2
        UltraGridColumn1524.Header.VisiblePosition = 3
        UltraGridColumn1525.Header.VisiblePosition = 4
        UltraGridColumn1526.Header.VisiblePosition = 5
        UltraGridColumn1527.Header.VisiblePosition = 6
        UltraGridColumn1528.Header.VisiblePosition = 7
        UltraGridColumn1529.Header.VisiblePosition = 8
        UltraGridColumn1530.Header.VisiblePosition = 9
        UltraGridColumn1531.Header.VisiblePosition = 10
        UltraGridColumn1532.Header.VisiblePosition = 11
        UltraGridColumn1533.Header.VisiblePosition = 12
        UltraGridColumn1534.Header.VisiblePosition = 13
        UltraGridColumn1535.Header.VisiblePosition = 14
        UltraGridColumn1536.Header.VisiblePosition = 15
        UltraGridColumn1537.Header.VisiblePosition = 16
        UltraGridColumn1538.Header.VisiblePosition = 17
        UltraGridColumn1539.Header.VisiblePosition = 18
        UltraGridColumn1540.Header.VisiblePosition = 19
        UltraGridColumn1541.Header.VisiblePosition = 20
        UltraGridBand27.Columns.AddRange(New Object() {UltraGridColumn1521, UltraGridColumn1522, UltraGridColumn1523, UltraGridColumn1524, UltraGridColumn1525, UltraGridColumn1526, UltraGridColumn1527, UltraGridColumn1528, UltraGridColumn1529, UltraGridColumn1530, UltraGridColumn1531, UltraGridColumn1532, UltraGridColumn1533, UltraGridColumn1534, UltraGridColumn1535, UltraGridColumn1536, UltraGridColumn1537, UltraGridColumn1538, UltraGridColumn1539, UltraGridColumn1540, UltraGridColumn1541})
        UltraGridColumn1542.Header.VisiblePosition = 0
        UltraGridColumn1543.Header.VisiblePosition = 1
        UltraGridColumn1544.Header.VisiblePosition = 2
        UltraGridColumn1545.Header.VisiblePosition = 3
        UltraGridColumn1546.Header.VisiblePosition = 4
        UltraGridColumn1547.Header.VisiblePosition = 5
        UltraGridColumn1548.Header.VisiblePosition = 6
        UltraGridColumn1549.Header.VisiblePosition = 7
        UltraGridColumn1550.Header.VisiblePosition = 8
        UltraGridColumn1551.Header.VisiblePosition = 9
        UltraGridColumn1552.Header.VisiblePosition = 10
        UltraGridColumn1553.Header.VisiblePosition = 11
        UltraGridColumn1554.Header.VisiblePosition = 12
        UltraGridColumn1555.Header.VisiblePosition = 13
        UltraGridColumn1556.Header.VisiblePosition = 14
        UltraGridBand28.Columns.AddRange(New Object() {UltraGridColumn1542, UltraGridColumn1543, UltraGridColumn1544, UltraGridColumn1545, UltraGridColumn1546, UltraGridColumn1547, UltraGridColumn1548, UltraGridColumn1549, UltraGridColumn1550, UltraGridColumn1551, UltraGridColumn1552, UltraGridColumn1553, UltraGridColumn1554, UltraGridColumn1555, UltraGridColumn1556})
        Me.ugReenvios.DisplayLayout.BandsSerializer.Add(UltraGridBand25)
        Me.ugReenvios.DisplayLayout.BandsSerializer.Add(UltraGridBand26)
        Me.ugReenvios.DisplayLayout.BandsSerializer.Add(UltraGridBand27)
        Me.ugReenvios.DisplayLayout.BandsSerializer.Add(UltraGridBand28)
        Me.ugReenvios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugReenvios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance147.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance147.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance147.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance147.BorderColor = System.Drawing.SystemColors.Window
        Me.ugReenvios.DisplayLayout.GroupByBox.Appearance = Appearance147
        Appearance148.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugReenvios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance148
        Me.ugReenvios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugReenvios.DisplayLayout.GroupByBox.Hidden = True
        Me.ugReenvios.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance149.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance149.BackColor2 = System.Drawing.SystemColors.Control
        Appearance149.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance149.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugReenvios.DisplayLayout.GroupByBox.PromptAppearance = Appearance149
        Me.ugReenvios.DisplayLayout.MaxColScrollRegions = 1
        Me.ugReenvios.DisplayLayout.MaxRowScrollRegions = 1
        Appearance150.BackColor = System.Drawing.SystemColors.Window
        Appearance150.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugReenvios.DisplayLayout.Override.ActiveCellAppearance = Appearance150
        Appearance151.BackColor = System.Drawing.SystemColors.Highlight
        Appearance151.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugReenvios.DisplayLayout.Override.ActiveRowAppearance = Appearance151
        Me.ugReenvios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugReenvios.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugReenvios.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugReenvios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugReenvios.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugReenvios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugReenvios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance152.BackColor = System.Drawing.SystemColors.Window
        Me.ugReenvios.DisplayLayout.Override.CardAreaAppearance = Appearance152
        Appearance153.BorderColor = System.Drawing.Color.Silver
        Appearance153.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugReenvios.DisplayLayout.Override.CellAppearance = Appearance153
        Me.ugReenvios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugReenvios.DisplayLayout.Override.CellPadding = 0
        Appearance154.BackColor = System.Drawing.SystemColors.Control
        Appearance154.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance154.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance154.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance154.BorderColor = System.Drawing.SystemColors.Window
        Me.ugReenvios.DisplayLayout.Override.GroupByRowAppearance = Appearance154
        Appearance155.TextHAlignAsString = "Left"
        Me.ugReenvios.DisplayLayout.Override.HeaderAppearance = Appearance155
        Me.ugReenvios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugReenvios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance156.BackColor = System.Drawing.SystemColors.Window
        Appearance156.BorderColor = System.Drawing.Color.Silver
        Me.ugReenvios.DisplayLayout.Override.RowAppearance = Appearance156
        Me.ugReenvios.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugReenvios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugReenvios.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugReenvios.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugReenvios.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugReenvios.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugReenvios.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance157.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugReenvios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance157
        Me.ugReenvios.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugReenvios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugReenvios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugReenvios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugReenvios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugReenvios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugReenvios.Location = New System.Drawing.Point(5, 0)
        Me.ugReenvios.Name = "ugReenvios"
        Me.ugReenvios.Size = New System.Drawing.Size(996, 447)
        Me.ugReenvios.TabIndex = 0
        Me.ugReenvios.Text = "UltraGrid4"
        '
        'ReenviosBindingSource
        '
        Me.ReenviosBindingSource.DataMember = "Comprobantes"
        Me.ReenviosBindingSource.DataSource = Me.DtsRegistracionPagosV2
        Me.ReenviosBindingSource.Filter = ""
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.ugvProductosSinDescargar)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(1006, 452)
        '
        'ugvProductosSinDescargar
        '
        Appearance158.BackColor = System.Drawing.SystemColors.Window
        Appearance158.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvProductosSinDescargar.DisplayLayout.Appearance = Appearance158
        UltraGridColumn726.Header.Caption = "Código"
        UltraGridColumn726.Header.VisiblePosition = 0
        UltraGridColumn726.Width = 142
        UltraGridColumn727.Header.Caption = "Producto"
        UltraGridColumn727.Header.VisiblePosition = 1
        UltraGridColumn727.Width = 378
        UltraGridColumn728.Format = "N2"
        UltraGridColumn728.Header.VisiblePosition = 2
        UltraGridColumn729.Header.VisiblePosition = 3
        UltraGridBand29.Columns.AddRange(New Object() {UltraGridColumn726, UltraGridColumn727, UltraGridColumn728, UltraGridColumn729})
        Appearance159.TextHAlignAsString = "Right"
        UltraGridColumn730.CellAppearance = Appearance159
        UltraGridColumn730.Header.Caption = "Código"
        UltraGridColumn730.Header.VisiblePosition = 0
        UltraGridColumn730.Hidden = True
        UltraGridColumn730.Width = 77
        UltraGridColumn731.Header.VisiblePosition = 1
        UltraGridColumn731.Hidden = True
        UltraGridColumn732.Header.Caption = "Comprobante"
        UltraGridColumn732.Header.VisiblePosition = 2
        UltraGridColumn733.Header.VisiblePosition = 3
        UltraGridColumn733.Width = 38
        Appearance160.TextHAlignAsString = "Right"
        UltraGridColumn734.CellAppearance = Appearance160
        UltraGridColumn734.Header.Caption = "Emisor"
        UltraGridColumn734.Header.VisiblePosition = 4
        UltraGridColumn734.Width = 69
        Appearance161.TextHAlignAsString = "Right"
        UltraGridColumn735.CellAppearance = Appearance161
        UltraGridColumn735.Header.Caption = "Numero"
        UltraGridColumn735.Header.VisiblePosition = 5
        UltraGridColumn736.Header.VisiblePosition = 6
        UltraGridColumn737.Header.VisiblePosition = 7
        Appearance162.TextHAlignAsString = "Right"
        UltraGridColumn738.CellAppearance = Appearance162
        UltraGridColumn738.Header.VisiblePosition = 8
        UltraGridColumn738.Width = 62
        UltraGridColumn739.Header.Caption = "Codigo Cliente"
        UltraGridColumn739.Header.VisiblePosition = 9
        UltraGridColumn740.Header.Caption = "Nombre Cliente"
        UltraGridColumn740.Header.VisiblePosition = 10
        UltraGridColumn741.Header.Caption = "Operacion"
        UltraGridColumn741.Header.VisiblePosition = 11
        UltraGridBand30.Columns.AddRange(New Object() {UltraGridColumn730, UltraGridColumn731, UltraGridColumn732, UltraGridColumn733, UltraGridColumn734, UltraGridColumn735, UltraGridColumn736, UltraGridColumn737, UltraGridColumn738, UltraGridColumn739, UltraGridColumn740, UltraGridColumn741})
        Me.ugvProductosSinDescargar.DisplayLayout.BandsSerializer.Add(UltraGridBand29)
        Me.ugvProductosSinDescargar.DisplayLayout.BandsSerializer.Add(UltraGridBand30)
        Me.ugvProductosSinDescargar.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvProductosSinDescargar.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance163.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance163.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance163.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance163.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Appearance = Appearance163
        Appearance164.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance164
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance165.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance165.BackColor2 = System.Drawing.SystemColors.Control
        Appearance165.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance165.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.PromptAppearance = Appearance165
        Me.ugvProductosSinDescargar.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvProductosSinDescargar.DisplayLayout.MaxRowScrollRegions = 1
        Appearance166.BackColor = System.Drawing.SystemColors.Window
        Appearance166.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.ActiveCellAppearance = Appearance166
        Appearance167.BackColor = System.Drawing.SystemColors.Highlight
        Appearance167.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.ActiveRowAppearance = Appearance167
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvProductosSinDescargar.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvProductosSinDescargar.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance168.BackColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CardAreaAppearance = Appearance168
        Appearance169.BorderColor = System.Drawing.Color.Silver
        Appearance169.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellAppearance = Appearance169
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellPadding = 0
        Appearance170.BackColor = System.Drawing.SystemColors.Control
        Appearance170.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance170.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance170.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance170.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.Override.GroupByRowAppearance = Appearance170
        Appearance171.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance171.TextHAlignAsString = "Left"
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderAppearance = Appearance171
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance172.BackColor = System.Drawing.SystemColors.Window
        Appearance172.BorderColor = System.Drawing.Color.Silver
        Me.ugvProductosSinDescargar.DisplayLayout.Override.RowAppearance = Appearance172
        Me.ugvProductosSinDescargar.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugvProductosSinDescargar.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance173.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvProductosSinDescargar.DisplayLayout.Override.TemplateAddRowAppearance = Appearance173
        Me.ugvProductosSinDescargar.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvProductosSinDescargar.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvProductosSinDescargar.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvProductosSinDescargar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvProductosSinDescargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvProductosSinDescargar.Location = New System.Drawing.Point(5, 0)
        Me.ugvProductosSinDescargar.Name = "ugvProductosSinDescargar"
        Me.ugvProductosSinDescargar.Size = New System.Drawing.Size(996, 447)
        Me.ugvProductosSinDescargar.TabIndex = 1
        Me.ugvProductosSinDescargar.Text = "UltraGrid1"
        '
        'utResumen
        '
        Me.utResumen.Controls.Add(Me.btnGrabar)
        Me.utResumen.Controls.Add(Me.btnImprimirResumen)
        Me.utResumen.Controls.Add(Me.grbIVAs)
        Me.utResumen.Location = New System.Drawing.Point(-10000, -10000)
        Me.utResumen.Name = "utResumen"
        Me.utResumen.Padding = New System.Windows.Forms.Padding(5, 0, 5, 5)
        Me.utResumen.Size = New System.Drawing.Size(1006, 452)
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.ForeColor = System.Drawing.Color.ForestGreen
        Me.btnGrabar.Location = New System.Drawing.Point(619, 74)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(175, 70)
        Me.btnGrabar.TabIndex = 10
        Me.btnGrabar.Text = "&Registrar Cobranza (F4)"
        Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnImprimirResumen
        '
        Me.btnImprimirResumen.Location = New System.Drawing.Point(188, 32)
        Me.btnImprimirResumen.Name = "btnImprimirResumen"
        Me.btnImprimirResumen.Size = New System.Drawing.Size(107, 24)
        Me.btnImprimirResumen.TabIndex = 1
        Me.btnImprimirResumen.Text = "Imprimir Resumen"
        Me.btnImprimirResumen.UseVisualStyleBackColor = True
        '
        'grbIVAs
        '
        Me.grbIVAs.Controls.Add(Me.lblTotalTransferencia)
        Me.grbIVAs.Controls.Add(Me.txtTotalTransferencia)
        Me.grbIVAs.Controls.Add(Me.lblSubTotal)
        Me.grbIVAs.Controls.Add(Me.txtSubTotal)
        Me.grbIVAs.Controls.Add(Me.lblTotalComprobantes)
        Me.grbIVAs.Controls.Add(Me.txtTotalComprobantes)
        Me.grbIVAs.Controls.Add(Me.lblLineaTotal1)
        Me.grbIVAs.Controls.Add(Me.lblTotalCC)
        Me.grbIVAs.Controls.Add(Me.txtTotalCC)
        Me.grbIVAs.Controls.Add(Me.lblTotalReenvios)
        Me.grbIVAs.Controls.Add(Me.txtTotalReenvios)
        Me.grbIVAs.Controls.Add(Me.lblSaldoGeneral)
        Me.grbIVAs.Controls.Add(Me.lblNCAplicadas)
        Me.grbIVAs.Controls.Add(Me.lblTotalNC)
        Me.grbIVAs.Controls.Add(Me.txtSaldoGeneral)
        Me.grbIVAs.Controls.Add(Me.lblTotalCheque)
        Me.grbIVAs.Controls.Add(Me.lblTotalEfectivo)
        Me.grbIVAs.Controls.Add(Me.txtNCAplicadas)
        Me.grbIVAs.Controls.Add(Me.txtTotalNC)
        Me.grbIVAs.Controls.Add(Me.txtTotalEfectivo)
        Me.grbIVAs.Controls.Add(Me.txtTotalCheque)
        Me.grbIVAs.Controls.Add(Me.lblLineaTotal2)
        Me.grbIVAs.Location = New System.Drawing.Point(72, 61)
        Me.grbIVAs.Name = "grbIVAs"
        Me.grbIVAs.Size = New System.Drawing.Size(385, 366)
        Me.grbIVAs.TabIndex = 0
        Me.grbIVAs.TabStop = False
        '
        'lblTotalTransferencia
        '
        Me.lblTotalTransferencia.AutoSize = True
        Me.lblTotalTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTransferencia.LabelAsoc = Nothing
        Me.lblTotalTransferencia.Location = New System.Drawing.Point(11, 90)
        Me.lblTotalTransferencia.Name = "lblTotalTransferencia"
        Me.lblTotalTransferencia.Size = New System.Drawing.Size(106, 20)
        Me.lblTotalTransferencia.TabIndex = 5
        Me.lblTotalTransferencia.Text = "Transferencia"
        '
        'txtTotalTransferencia
        '
        Me.txtTotalTransferencia.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalTransferencia.BindearPropiedadControl = Nothing
        Me.txtTotalTransferencia.BindearPropiedadEntidad = Nothing
        Me.txtTotalTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalTransferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalTransferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalTransferencia.Formato = "##,##0.00"
        Me.txtTotalTransferencia.IsDecimal = True
        Me.txtTotalTransferencia.IsNumber = True
        Me.txtTotalTransferencia.IsPK = False
        Me.txtTotalTransferencia.IsRequired = False
        Me.txtTotalTransferencia.Key = ""
        Me.txtTotalTransferencia.LabelAsoc = Me.lblTotalTransferencia
        Me.txtTotalTransferencia.Location = New System.Drawing.Point(223, 85)
        Me.txtTotalTransferencia.Name = "txtTotalTransferencia"
        Me.txtTotalTransferencia.ReadOnly = True
        Me.txtTotalTransferencia.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalTransferencia.TabIndex = 6
        Me.txtTotalTransferencia.TabStop = False
        Me.txtTotalTransferencia.Text = "0.00"
        Me.txtTotalTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSubTotal
        '
        Me.lblSubTotal.AutoSize = True
        Me.lblSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTotal.ForeColor = System.Drawing.Color.Green
        Me.lblSubTotal.LabelAsoc = Nothing
        Me.lblSubTotal.Location = New System.Drawing.Point(11, 288)
        Me.lblSubTotal.Name = "lblSubTotal"
        Me.lblSubTotal.Size = New System.Drawing.Size(97, 20)
        Me.lblSubTotal.TabIndex = 18
        Me.lblSubTotal.Text = "SUB TOTAL"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.SystemColors.Control
        Me.txtSubTotal.BindearPropiedadControl = Nothing
        Me.txtSubTotal.BindearPropiedadEntidad = Nothing
        Me.txtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Green
        Me.txtSubTotal.ForeColorFocus = System.Drawing.Color.Green
        Me.txtSubTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSubTotal.Formato = "##0.00"
        Me.txtSubTotal.IsDecimal = True
        Me.txtSubTotal.IsNumber = True
        Me.txtSubTotal.IsPK = False
        Me.txtSubTotal.IsRequired = False
        Me.txtSubTotal.Key = ""
        Me.txtSubTotal.LabelAsoc = Me.lblSubTotal
        Me.txtSubTotal.Location = New System.Drawing.Point(223, 285)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(140, 26)
        Me.txtSubTotal.TabIndex = 19
        Me.txtSubTotal.TabStop = False
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalComprobantes
        '
        Me.lblTotalComprobantes.AutoSize = True
        Me.lblTotalComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalComprobantes.ForeColor = System.Drawing.Color.Blue
        Me.lblTotalComprobantes.LabelAsoc = Nothing
        Me.lblTotalComprobantes.Location = New System.Drawing.Point(11, 16)
        Me.lblTotalComprobantes.Name = "lblTotalComprobantes"
        Me.lblTotalComprobantes.Size = New System.Drawing.Size(197, 20)
        Me.lblTotalComprobantes.TabIndex = 0
        Me.lblTotalComprobantes.Text = "TOTAL COMPROBANTES"
        '
        'txtTotalComprobantes
        '
        Me.txtTotalComprobantes.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalComprobantes.BindearPropiedadControl = Nothing
        Me.txtTotalComprobantes.BindearPropiedadEntidad = Nothing
        Me.txtTotalComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalComprobantes.ForeColor = System.Drawing.Color.Blue
        Me.txtTotalComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalComprobantes.Formato = "##0.00"
        Me.txtTotalComprobantes.IsDecimal = True
        Me.txtTotalComprobantes.IsNumber = True
        Me.txtTotalComprobantes.IsPK = False
        Me.txtTotalComprobantes.IsRequired = False
        Me.txtTotalComprobantes.Key = ""
        Me.txtTotalComprobantes.LabelAsoc = Me.lblTotalComprobantes
        Me.txtTotalComprobantes.Location = New System.Drawing.Point(221, 13)
        Me.txtTotalComprobantes.Name = "txtTotalComprobantes"
        Me.txtTotalComprobantes.ReadOnly = True
        Me.txtTotalComprobantes.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalComprobantes.TabIndex = 1
        Me.txtTotalComprobantes.TabStop = False
        Me.txtTotalComprobantes.Text = "0.00"
        Me.txtTotalComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLineaTotal1
        '
        Me.lblLineaTotal1.AutoSize = True
        Me.lblLineaTotal1.Location = New System.Drawing.Point(10, 33)
        Me.lblLineaTotal1.Name = "lblLineaTotal1"
        Me.lblLineaTotal1.Size = New System.Drawing.Size(355, 13)
        Me.lblLineaTotal1.TabIndex = 2
        Me.lblLineaTotal1.Text = "__________________________________________________________"
        '
        'lblTotalCC
        '
        Me.lblTotalCC.AutoSize = True
        Me.lblTotalCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCC.LabelAsoc = Nothing
        Me.lblTotalCC.Location = New System.Drawing.Point(11, 152)
        Me.lblTotalCC.Name = "lblTotalCC"
        Me.lblTotalCC.Size = New System.Drawing.Size(146, 20)
        Me.lblTotalCC.TabIndex = 9
        Me.lblTotalCC.Text = "Cuentas Corrientes"
        Me.lblTotalCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalCC
        '
        Me.txtTotalCC.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalCC.BindearPropiedadControl = Nothing
        Me.txtTotalCC.BindearPropiedadEntidad = Nothing
        Me.txtTotalCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCC.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalCC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalCC.Formato = "##0.00"
        Me.txtTotalCC.IsDecimal = True
        Me.txtTotalCC.IsNumber = True
        Me.txtTotalCC.IsPK = False
        Me.txtTotalCC.IsRequired = False
        Me.txtTotalCC.Key = ""
        Me.txtTotalCC.LabelAsoc = Me.lblTotalCC
        Me.txtTotalCC.Location = New System.Drawing.Point(223, 149)
        Me.txtTotalCC.Name = "txtTotalCC"
        Me.txtTotalCC.ReadOnly = True
        Me.txtTotalCC.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalCC.TabIndex = 10
        Me.txtTotalCC.Text = "0.00"
        Me.txtTotalCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalReenvios
        '
        Me.lblTotalReenvios.AutoSize = True
        Me.lblTotalReenvios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalReenvios.LabelAsoc = Nothing
        Me.lblTotalReenvios.Location = New System.Drawing.Point(11, 250)
        Me.lblTotalReenvios.Name = "lblTotalReenvios"
        Me.lblTotalReenvios.Size = New System.Drawing.Size(75, 20)
        Me.lblTotalReenvios.TabIndex = 15
        Me.lblTotalReenvios.Text = "Reenvíos"
        '
        'txtTotalReenvios
        '
        Me.txtTotalReenvios.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalReenvios.BindearPropiedadControl = Nothing
        Me.txtTotalReenvios.BindearPropiedadEntidad = Nothing
        Me.txtTotalReenvios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalReenvios.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalReenvios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalReenvios.Formato = "##0.00"
        Me.txtTotalReenvios.IsDecimal = True
        Me.txtTotalReenvios.IsNumber = True
        Me.txtTotalReenvios.IsPK = False
        Me.txtTotalReenvios.IsRequired = False
        Me.txtTotalReenvios.Key = ""
        Me.txtTotalReenvios.LabelAsoc = Me.lblTotalReenvios
        Me.txtTotalReenvios.Location = New System.Drawing.Point(223, 245)
        Me.txtTotalReenvios.MaxLength = 30
        Me.txtTotalReenvios.Name = "txtTotalReenvios"
        Me.txtTotalReenvios.ReadOnly = True
        Me.txtTotalReenvios.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalReenvios.TabIndex = 16
        Me.txtTotalReenvios.TabStop = False
        Me.txtTotalReenvios.Text = "0.00"
        Me.txtTotalReenvios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoGeneral
        '
        Me.lblSaldoGeneral.AutoSize = True
        Me.lblSaldoGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoGeneral.ForeColor = System.Drawing.Color.Red
        Me.lblSaldoGeneral.LabelAsoc = Nothing
        Me.lblSaldoGeneral.Location = New System.Drawing.Point(11, 320)
        Me.lblSaldoGeneral.Name = "lblSaldoGeneral"
        Me.lblSaldoGeneral.Size = New System.Drawing.Size(146, 20)
        Me.lblSaldoGeneral.TabIndex = 20
        Me.lblSaldoGeneral.Text = "SALDO GENERAL"
        '
        'lblNCAplicadas
        '
        Me.lblNCAplicadas.AutoSize = True
        Me.lblNCAplicadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNCAplicadas.LabelAsoc = Nothing
        Me.lblNCAplicadas.Location = New System.Drawing.Point(11, 216)
        Me.lblNCAplicadas.Name = "lblNCAplicadas"
        Me.lblNCAplicadas.Size = New System.Drawing.Size(112, 20)
        Me.lblNCAplicadas.TabIndex = 13
        Me.lblNCAplicadas.Text = "N.C. Aplicadas"
        '
        'lblTotalNC
        '
        Me.lblTotalNC.AutoSize = True
        Me.lblTotalNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNC.LabelAsoc = Nothing
        Me.lblTotalNC.Location = New System.Drawing.Point(11, 184)
        Me.lblTotalNC.Name = "lblTotalNC"
        Me.lblTotalNC.Size = New System.Drawing.Size(128, 20)
        Me.lblTotalNC.TabIndex = 11
        Me.lblTotalNC.Text = "Notas de Crédito"
        '
        'txtSaldoGeneral
        '
        Me.txtSaldoGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.txtSaldoGeneral.BindearPropiedadControl = Nothing
        Me.txtSaldoGeneral.BindearPropiedadEntidad = Nothing
        Me.txtSaldoGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoGeneral.ForeColor = System.Drawing.Color.Red
        Me.txtSaldoGeneral.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoGeneral.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoGeneral.Formato = "##0.00"
        Me.txtSaldoGeneral.IsDecimal = True
        Me.txtSaldoGeneral.IsNumber = True
        Me.txtSaldoGeneral.IsPK = False
        Me.txtSaldoGeneral.IsRequired = False
        Me.txtSaldoGeneral.Key = ""
        Me.txtSaldoGeneral.LabelAsoc = Me.lblSaldoGeneral
        Me.txtSaldoGeneral.Location = New System.Drawing.Point(223, 317)
        Me.txtSaldoGeneral.Name = "txtSaldoGeneral"
        Me.txtSaldoGeneral.ReadOnly = True
        Me.txtSaldoGeneral.Size = New System.Drawing.Size(140, 26)
        Me.txtSaldoGeneral.TabIndex = 21
        Me.txtSaldoGeneral.TabStop = False
        Me.txtSaldoGeneral.Text = "0.00"
        Me.txtSaldoGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalCheque
        '
        Me.lblTotalCheque.AutoSize = True
        Me.lblTotalCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCheque.LabelAsoc = Nothing
        Me.lblTotalCheque.Location = New System.Drawing.Point(11, 122)
        Me.lblTotalCheque.Name = "lblTotalCheque"
        Me.lblTotalCheque.Size = New System.Drawing.Size(73, 20)
        Me.lblTotalCheque.TabIndex = 7
        Me.lblTotalCheque.Text = "Cheques"
        '
        'lblTotalEfectivo
        '
        Me.lblTotalEfectivo.AutoSize = True
        Me.lblTotalEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEfectivo.LabelAsoc = Nothing
        Me.lblTotalEfectivo.Location = New System.Drawing.Point(11, 58)
        Me.lblTotalEfectivo.Name = "lblTotalEfectivo"
        Me.lblTotalEfectivo.Size = New System.Drawing.Size(66, 20)
        Me.lblTotalEfectivo.TabIndex = 3
        Me.lblTotalEfectivo.Text = "Efectivo"
        '
        'txtNCAplicadas
        '
        Me.txtNCAplicadas.BackColor = System.Drawing.SystemColors.Control
        Me.txtNCAplicadas.BindearPropiedadControl = Nothing
        Me.txtNCAplicadas.BindearPropiedadEntidad = Nothing
        Me.txtNCAplicadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNCAplicadas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNCAplicadas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNCAplicadas.Formato = "##0.00"
        Me.txtNCAplicadas.IsDecimal = True
        Me.txtNCAplicadas.IsNumber = True
        Me.txtNCAplicadas.IsPK = False
        Me.txtNCAplicadas.IsRequired = False
        Me.txtNCAplicadas.Key = ""
        Me.txtNCAplicadas.LabelAsoc = Me.lblNCAplicadas
        Me.txtNCAplicadas.Location = New System.Drawing.Point(223, 213)
        Me.txtNCAplicadas.Name = "txtNCAplicadas"
        Me.txtNCAplicadas.ReadOnly = True
        Me.txtNCAplicadas.Size = New System.Drawing.Size(140, 26)
        Me.txtNCAplicadas.TabIndex = 14
        Me.txtNCAplicadas.TabStop = False
        Me.txtNCAplicadas.Text = "0.00"
        Me.txtNCAplicadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNC
        '
        Me.txtTotalNC.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalNC.BindearPropiedadControl = Nothing
        Me.txtTotalNC.BindearPropiedadEntidad = Nothing
        Me.txtTotalNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNC.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalNC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalNC.Formato = "##0.00"
        Me.txtTotalNC.IsDecimal = True
        Me.txtTotalNC.IsNumber = True
        Me.txtTotalNC.IsPK = False
        Me.txtTotalNC.IsRequired = False
        Me.txtTotalNC.Key = ""
        Me.txtTotalNC.LabelAsoc = Me.lblTotalNC
        Me.txtTotalNC.Location = New System.Drawing.Point(223, 181)
        Me.txtTotalNC.Name = "txtTotalNC"
        Me.txtTotalNC.ReadOnly = True
        Me.txtTotalNC.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalNC.TabIndex = 12
        Me.txtTotalNC.TabStop = False
        Me.txtTotalNC.Text = "0.00"
        Me.txtTotalNC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalEfectivo
        '
        Me.txtTotalEfectivo.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalEfectivo.BindearPropiedadControl = Nothing
        Me.txtTotalEfectivo.BindearPropiedadEntidad = Nothing
        Me.txtTotalEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEfectivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalEfectivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalEfectivo.Formato = "##,##0.00"
        Me.txtTotalEfectivo.IsDecimal = True
        Me.txtTotalEfectivo.IsNumber = True
        Me.txtTotalEfectivo.IsPK = False
        Me.txtTotalEfectivo.IsRequired = False
        Me.txtTotalEfectivo.Key = ""
        Me.txtTotalEfectivo.LabelAsoc = Me.lblTotalEfectivo
        Me.txtTotalEfectivo.Location = New System.Drawing.Point(223, 53)
        Me.txtTotalEfectivo.Name = "txtTotalEfectivo"
        Me.txtTotalEfectivo.ReadOnly = True
        Me.txtTotalEfectivo.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalEfectivo.TabIndex = 4
        Me.txtTotalEfectivo.TabStop = False
        Me.txtTotalEfectivo.Text = "0.00"
        Me.txtTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCheque
        '
        Me.txtTotalCheque.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalCheque.BindearPropiedadControl = Nothing
        Me.txtTotalCheque.BindearPropiedadEntidad = Nothing
        Me.txtTotalCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalCheque.Formato = "##0.00"
        Me.txtTotalCheque.IsDecimal = True
        Me.txtTotalCheque.IsNumber = True
        Me.txtTotalCheque.IsPK = False
        Me.txtTotalCheque.IsRequired = False
        Me.txtTotalCheque.Key = ""
        Me.txtTotalCheque.LabelAsoc = Me.lblTotalCheque
        Me.txtTotalCheque.Location = New System.Drawing.Point(223, 117)
        Me.txtTotalCheque.Name = "txtTotalCheque"
        Me.txtTotalCheque.ReadOnly = True
        Me.txtTotalCheque.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalCheque.TabIndex = 8
        Me.txtTotalCheque.TabStop = False
        Me.txtTotalCheque.Text = "0.00"
        Me.txtTotalCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLineaTotal2
        '
        Me.lblLineaTotal2.AutoSize = True
        Me.lblLineaTotal2.Location = New System.Drawing.Point(10, 265)
        Me.lblLineaTotal2.Name = "lblLineaTotal2"
        Me.lblLineaTotal2.Size = New System.Drawing.Size(355, 13)
        Me.lblLineaTotal2.TabIndex = 17
        Me.lblLineaTotal2.Text = "__________________________________________________________"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.FitWidthToPages = 1
        Me.UltraGridPrintDocument1.Grid = Me.ugvDetallePedidos
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(575, 12)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 2
        Me.lblCaja.Text = "Ca&ja"
        '
        'lblFechaRend
        '
        Me.lblFechaRend.AutoSize = True
        Me.lblFechaRend.LabelAsoc = Nothing
        Me.lblFechaRend.Location = New System.Drawing.Point(756, 12)
        Me.lblFechaRend.Name = "lblFechaRend"
        Me.lblFechaRend.Size = New System.Drawing.Size(91, 13)
        Me.lblFechaRend.TabIndex = 4
        Me.lblFechaRend.Text = "Fecha Rendición:"
        '
        'dtpFechaRend
        '
        Me.dtpFechaRend.BindearPropiedadControl = Nothing
        Me.dtpFechaRend.BindearPropiedadEntidad = Nothing
        Me.dtpFechaRend.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaRend.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaRend.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaRend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaRend.IsPK = False
        Me.dtpFechaRend.IsRequired = False
        Me.dtpFechaRend.Key = ""
        Me.dtpFechaRend.LabelAsoc = Me.lblFechaRend
        Me.dtpFechaRend.Location = New System.Drawing.Point(853, 8)
        Me.dtpFechaRend.Name = "dtpFechaRend"
        Me.dtpFechaRend.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaRend.TabIndex = 5
        '
        'utcPreventa
        '
        Appearance174.ForeColor = System.Drawing.Color.Black
        Me.utcPreventa.ActiveTabAppearance = Appearance174
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl7)
        Me.utcPreventa.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl1)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl3)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl4)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl2)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl6)
        Me.utcPreventa.Controls.Add(Me.utReenvios)
        Me.utcPreventa.Controls.Add(Me.utResumen)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl5)
        Me.utcPreventa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.utcPreventa.Location = New System.Drawing.Point(0, 64)
        Me.utcPreventa.Name = "utcPreventa"
        Me.utcPreventa.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.tstSecundaria})
        Me.utcPreventa.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.utcPreventa.Size = New System.Drawing.Size(1008, 475)
        Me.utcPreventa.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.utcPreventa.TabIndex = 1
        UltraTab10.Key = "tbcComprobantes"
        UltraTab10.TabPage = Me.UltraTabPageControl7
        UltraTab10.Text = "Comprobantes (F9)"
        Appearance175.BackColor = System.Drawing.Color.Honeydew
        Appearance175.FontData.BoldAsString = "False"
        UltraTab11.ActiveAppearance = Appearance175
        Appearance176.ForeColor = System.Drawing.Color.Black
        UltraTab11.Appearance = Appearance176
        UltraTab11.Key = "tbcDetallePago"
        UltraTab11.TabPage = Me.UltraTabPageControl3
        UltraTab11.Text = "Detalle de Pagos (F10)"
        Appearance177.BackColor = System.Drawing.Color.Honeydew
        UltraTab12.ActiveAppearance = Appearance177
        Appearance178.ForeColor = System.Drawing.Color.Black
        UltraTab12.Appearance = Appearance178
        UltraTab12.Key = "tbcSaldoCliente"
        UltraTab12.TabPage = Me.UltraTabPageControl2
        UltraTab12.Text = "Efectivo"
        Appearance179.BackColor = System.Drawing.Color.Honeydew
        UltraTab13.ActiveAppearance = Appearance179
        Appearance180.ForeColor = System.Drawing.Color.Black
        UltraTab13.Appearance = Appearance180
        UltraTab13.Key = "tbcCuentaCorriente"
        UltraTab13.TabPage = Me.UltraTabPageControl1
        UltraTab13.Text = "Cuentas Corrientes"
        Appearance181.BackColor = System.Drawing.Color.Honeydew
        UltraTab14.ActiveAppearance = Appearance181
        Appearance182.ForeColor = System.Drawing.Color.Black
        UltraTab14.Appearance = Appearance182
        UltraTab14.Key = "tbcCheque"
        UltraTab14.TabPage = Me.UltraTabPageControl4
        UltraTab14.Text = "Cheques"
        Appearance183.ForeColor = System.Drawing.Color.Black
        UltraTab15.Appearance = Appearance183
        UltraTab15.Key = "tbcArticulosNC"
        UltraTab15.TabPage = Me.UltraTabPageControl6
        UltraTab15.Text = "Artículos NC"
        UltraTab16.Key = "tbcReenvios"
        UltraTab16.TabPage = Me.utReenvios
        UltraTab16.Text = "Reenvios"
        Appearance184.ForeColor = System.Drawing.Color.Black
        UltraTab17.Appearance = Appearance184
        UltraTab17.Key = "tbcProductosSinDescargar"
        UltraTab17.TabPage = Me.UltraTabPageControl5
        UltraTab17.Text = "Productos Sin Descargar"
        Appearance185.FontData.BoldAsString = "True"
        UltraTab18.Appearance = Appearance185
        UltraTab18.FixedWidth = 90
        UltraTab18.Key = "tbcResumen"
        UltraTab18.TabPage = Me.utResumen
        UltraTab18.Text = "Resumen (F4)"
        Me.utcPreventa.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab10, UltraTab11, UltraTab12, UltraTab13, UltraTab14, UltraTab15, UltraTab16, UltraTab17, UltraTab18})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Controls.Add(Me.tstSecundaria)
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1006, 452)
        '
        'lblReparto
        '
        Me.lblReparto.AutoSize = True
        Me.lblReparto.LabelAsoc = Nothing
        Me.lblReparto.Location = New System.Drawing.Point(11, 11)
        Me.lblReparto.Name = "lblReparto"
        Me.lblReparto.Size = New System.Drawing.Size(83, 13)
        Me.lblReparto.TabIndex = 0
        Me.lblReparto.Text = "Reparto a rendir"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1008, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(929, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbPagarTodo, Me.tsbGrabarBorrador, Me.ToolStripSeparator2, Me.tsbImprimirGrilla, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbCerrar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1008, 29)
        Me.tstBarra.TabIndex = 3
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPagarTodo
        '
        Me.tsbPagarTodo.Image = CType(resources.GetObject("tsbPagarTodo.Image"), System.Drawing.Image)
        Me.tsbPagarTodo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPagarTodo.Name = "tsbPagarTodo"
        Me.tsbPagarTodo.Size = New System.Drawing.Size(95, 26)
        Me.tsbPagarTodo.Text = "&Rendir todo"
        '
        'tsbGrabarBorrador
        '
        Me.tsbGrabarBorrador.Image = CType(resources.GetObject("tsbGrabarBorrador.Image"), System.Drawing.Image)
        Me.tsbGrabarBorrador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabarBorrador.Name = "tsbGrabarBorrador"
        Me.tsbGrabarBorrador.Size = New System.Drawing.Size(117, 26)
        Me.tsbGrabarBorrador.Text = "&Grabar Borrador"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimirGrilla
        '
        Me.tsbImprimirGrilla.Image = CType(resources.GetObject("tsbImprimirGrilla.Image"), System.Drawing.Image)
        Me.tsbImprimirGrilla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirGrilla.Name = "tsbImprimirGrilla"
        Me.tsbImprimirGrilla.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimirGrilla.Text = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCerrar
        '
        Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
        Me.tsbCerrar.Text = "&Cerrar"
        Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
        '
        'bscReparto2
        '
        Me.bscReparto2.ActivarFiltroEnGrilla = True
        Me.bscReparto2.AutoSize = True
        Me.bscReparto2.BindearPropiedadControl = Nothing
        Me.bscReparto2.BindearPropiedadEntidad = Nothing
        Me.bscReparto2.ConfigBuscador = Nothing
        Me.bscReparto2.Datos = Nothing
        Me.bscReparto2.FilaDevuelta = Nothing
        Me.bscReparto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscReparto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscReparto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscReparto2.IsDecimal = False
        Me.bscReparto2.IsNumber = False
        Me.bscReparto2.IsPK = False
        Me.bscReparto2.IsRequired = False
        Me.bscReparto2.Key = ""
        Me.bscReparto2.LabelAsoc = Nothing
        Me.bscReparto2.Location = New System.Drawing.Point(101, 8)
        Me.bscReparto2.Margin = New System.Windows.Forms.Padding(4)
        Me.bscReparto2.MaxLengh = "32767"
        Me.bscReparto2.Name = "bscReparto2"
        Me.bscReparto2.Permitido = True
        Me.bscReparto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscReparto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscReparto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscReparto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscReparto2.Selecciono = False
        Me.bscReparto2.Size = New System.Drawing.Size(92, 23)
        Me.bscReparto2.TabIndex = 1
        '
        'pnlReparto
        '
        Me.pnlReparto.AutoSize = True
        Me.pnlReparto.Controls.Add(Me.bscReparto2)
        Me.pnlReparto.Controls.Add(Me.lblReparto)
        Me.pnlReparto.Controls.Add(Me.dtpFechaRend)
        Me.pnlReparto.Controls.Add(Me.cmbCajas)
        Me.pnlReparto.Controls.Add(Me.lblFechaRend)
        Me.pnlReparto.Controls.Add(Me.lblCaja)
        Me.pnlReparto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlReparto.Location = New System.Drawing.Point(0, 29)
        Me.pnlReparto.Name = "pnlReparto"
        Me.pnlReparto.Size = New System.Drawing.Size(1008, 35)
        Me.pnlReparto.TabIndex = 0
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = ""
        Me.cmbCajas.BindearPropiedadEntidad = ""
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCaja
        Me.cmbCajas.Location = New System.Drawing.Point(620, 8)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(127, 21)
        Me.cmbCajas.TabIndex = 3
        '
        'RegistracionPagosV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.utcPreventa)
        Me.Controls.Add(Me.pnlReparto)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RegistracionPagosV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registración de Pagos contra Entrega"
        Me.UltraTabPageControl7.ResumeLayout(False)
        Me.UltraTabPageControl7.PerformLayout()
        CType(Me.ugComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bdsComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtsRegistracionPagosV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstSecundaria.ResumeLayout(False)
        Me.tstSecundaria.PerformLayout()
        Me.UltraTabPageControl3.ResumeLayout(False)
        CType(Me.ugvDetallePedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bdsComprobantesSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.ugEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EfectivoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.ugCtaCte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CtaCteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        CType(Me.ugCheque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChequesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl6.ResumeLayout(False)
        CType(Me.ugNc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utReenvios.ResumeLayout(False)
        CType(Me.ugReenvios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReenviosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        CType(Me.ugvProductosSinDescargar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utResumen.ResumeLayout(False)
        Me.grbIVAs.ResumeLayout(False)
        Me.grbIVAs.PerformLayout()
        CType(Me.utcPreventa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utcPreventa.ResumeLayout(False)
        Me.UltraTabSharedControlsPage1.ResumeLayout(False)
        Me.UltraTabSharedControlsPage1.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.pnlReparto.ResumeLayout(False)
        Me.pnlReparto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents chbFechaHasta As Eniac.Controles.CheckBox
   Friend WithEvents chbRespDistribucion As Eniac.Controles.CheckBox
   Friend WithEvents cmbRespDistribucion As Eniac.Controles.ComboBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents utcPreventa As Infragistics.Win.UltraWinTabControl.UltraTabControl
   Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
   Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents ugvDetallePedidos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents tsbGrabarBorrador As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbPagarTodo As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ugCtaCte As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugCheque As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugNc As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents utReenvios As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents ugReenvios As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents utResumen As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents grbIVAs As System.Windows.Forms.GroupBox
   Friend WithEvents lblTotalComprobantes As Eniac.Controles.Label
   Friend WithEvents txtTotalComprobantes As Eniac.Controles.TextBox
   Friend WithEvents lblLineaTotal1 As System.Windows.Forms.Label
   Friend WithEvents lblTotalCC As Eniac.Controles.Label
   Friend WithEvents txtTotalCC As Eniac.Controles.TextBox
   Friend WithEvents lblTotalReenvios As Eniac.Controles.Label
   Friend WithEvents txtTotalReenvios As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoGeneral As Eniac.Controles.Label
   Friend WithEvents lblTotalNC As Eniac.Controles.Label
   Friend WithEvents txtSaldoGeneral As Eniac.Controles.TextBox
   Friend WithEvents lblTotalCheque As Eniac.Controles.Label
   Friend WithEvents lblTotalEfectivo As Eniac.Controles.Label
   Friend WithEvents txtTotalNC As Eniac.Controles.TextBox
   Friend WithEvents txtTotalEfectivo As Eniac.Controles.TextBox
   Friend WithEvents txtTotalCheque As Eniac.Controles.TextBox
   Friend WithEvents dtpFechaRend As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaRend As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents btnImprimirResumen As System.Windows.Forms.Button
   Friend WithEvents DtsRegistracionPagosV2 As Eniac.Entidades.dtsRegistracionPagosV2
   Friend WithEvents bdsComprobantes As System.Windows.Forms.BindingSource
   Friend WithEvents ugEfectivo As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents EfectivoBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents CtaCteBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents NCBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ChequesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ReenviosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents lblLineaTotal2 As System.Windows.Forms.Label
   Friend WithEvents lblReparto As Eniac.Controles.Label
   Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents ugvProductosSinDescargar As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tsbImprimirGrilla As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents cmbModoConsultarComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Protected WithEvents cmbRuta As Eniac.Controles.ComboBox
   Protected WithEvents chbRuta As Eniac.Controles.CheckBox
   Friend WithEvents cmbDias As Eniac.Controles.ComboBox
   Protected WithEvents chbDias As Eniac.Controles.CheckBox
   Friend WithEvents UltraTabPageControl7 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents lblModoConsultarComprobantes As Eniac.Controles.Label
   Friend WithEvents chbFechaDesde As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents ugComprobante As Infragistics.Win.UltraWinGrid.UltraGrid
   Public WithEvents tstSecundaria As System.Windows.Forms.ToolStrip
   Public WithEvents tsbEfectivo As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbVarias As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbCC As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbNC As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbReenvio As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbNoRendir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents bdsComprobantesSeleccionados As System.Windows.Forms.BindingSource
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents tslNCSeleccionada As System.Windows.Forms.ToolStripLabel
   Friend WithEvents lblSubTotal As Eniac.Controles.Label
   Friend WithEvents txtSubTotal As Eniac.Controles.TextBox
   Friend WithEvents bscReparto2 As Eniac.Controles.Buscador2
   Friend WithEvents pnlReparto As System.Windows.Forms.Panel
   Friend WithEvents lblNCAplicadas As Eniac.Controles.Label
   Friend WithEvents txtNCAplicadas As Eniac.Controles.TextBox
   Friend WithEvents btnGrabar As Eniac.Controles.Button
   Friend WithEvents btnGrabaDataSetXML As System.Windows.Forms.Button
    Friend WithEvents lblTotalTransferencia As Controles.Label
    Friend WithEvents txtTotalTransferencia As Controles.TextBox
End Class
