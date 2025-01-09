<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfCtaCteDetalleClientes
   Inherits Eniac.Win.BaseForm

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
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoImpresora")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuotaNumero")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasFactura")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasVencido")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCuota")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCuota")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Interes")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoVencido")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente2")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoCliente")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCobrador")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCobrador")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CotizacionDolar")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdClienteCtaCte")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodVin")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVin")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEmbarcacion")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoEmbarcacion")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmbarcacion")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCama")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DetalleProducto", 0)
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad", 1)
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad", 2)
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
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Ver")
        Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoImpresora")
        Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreVendedor")
        Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCliente")
        Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoCliente")
        Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDeFantasia")
        Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
        Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
        Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
        Dim UltraDataColumn38 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
        Dim UltraDataColumn39 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CuotaNumero")
        Dim UltraDataColumn40 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn41 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DiasFactura")
        Dim UltraDataColumn42 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaVencimiento")
        Dim UltraDataColumn43 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DiasVencido")
        Dim UltraDataColumn44 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescripcionFormasPago")
        Dim UltraDataColumn45 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteCuota")
        Dim UltraDataColumn46 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("SaldoCuota")
        Dim UltraDataColumn47 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
        Dim UltraDataColumn48 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Total")
        Dim UltraDataColumn49 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoria")
        Dim UltraDataColumn50 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Interes")
        Dim UltraDataColumn51 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreZonaGeografica")
        Dim UltraDataColumn52 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("SaldoVencido")
        Dim UltraDataColumn53 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente2")
        Dim UltraDataColumn54 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
        Dim UltraDataColumn55 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreEstadoCliente")
        Dim UltraDataColumn56 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdFormasPago")
        Dim UltraDataColumn57 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroOrdenCompra")
        Dim UltraDataColumn58 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProveedor")
        Dim UltraDataColumn59 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoProveedor")
        Dim UltraDataColumn60 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProveedor")
        Dim UltraDataColumn61 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCobrador")
        Dim UltraDataColumn62 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCobrador")
        Dim UltraDataColumn63 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CotizacionDolar")
        Dim UltraDataColumn64 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Direccion")
        Dim UltraDataColumn65 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdVendedor")
        Dim UltraDataColumn66 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdClienteCtaCte")
        Dim UltraDataColumn67 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodVin")
        Dim UltraDataColumn68 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreVin")
        Dim UltraDataColumn69 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdEmbarcacion")
        Dim UltraDataColumn70 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoEmbarcacion")
        Dim UltraDataColumn71 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreEmbarcacion")
        Dim UltraDataColumn72 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCama")
        Dim UltraDataColumn73 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Ver")
        Dim UltraDataColumn74 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoImpresora")
        Dim UltraDataColumn75 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocVendedor")
        Dim UltraDataColumn76 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocVendedor")
        Dim UltraDataColumn77 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreVendedor")
        Dim UltraDataColumn78 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCliente")
        Dim UltraDataColumn79 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoCliente")
        Dim UltraDataColumn80 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn81 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDeFantasia")
        Dim UltraDataColumn82 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
        Dim UltraDataColumn83 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
        Dim UltraDataColumn84 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
        Dim UltraDataColumn85 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
        Dim UltraDataColumn86 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CuotaNumero")
        Dim UltraDataColumn87 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn88 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DiasFactura")
        Dim UltraDataColumn89 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaVencimiento")
        Dim UltraDataColumn90 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DiasVencido")
        Dim UltraDataColumn91 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescripcionFormasPago")
        Dim UltraDataColumn92 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteCuota")
        Dim UltraDataColumn93 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("SaldoCuota")
        Dim UltraDataColumn94 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
        Dim UltraDataColumn95 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Total")
        Dim UltraDataColumn96 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoria")
        Dim UltraDataColumn97 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Interes")
        Dim UltraDataColumn98 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreZonaGeografica")
        Dim UltraDataColumn99 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("SaldoVencido")
        Dim UltraDataColumn100 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente2")
        Dim UltraDataColumn101 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
        Dim UltraDataColumn102 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreEstadoCliente")
        Dim UltraDataColumn103 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdFormasPago")
        Dim UltraDataColumn104 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroOrdenCompra")
        Dim UltraDataColumn105 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProveedor")
        Dim UltraDataColumn106 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoProveedor")
        Dim UltraDataColumn107 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProveedor")
        Dim UltraDataColumn108 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCobrador")
        Dim UltraDataColumn109 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCobrador")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfCtaCteDetalleClientes))
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource3 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.chbAgruparIdClienteCtaCte = New System.Windows.Forms.CheckBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador2()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador2()
        Me.chbMostrarDetalleProducto = New Eniac.Controles.CheckBox()
        Me.grbEmbarcacionCama = New System.Windows.Forms.Panel()
        Me.chbEmbarcacionCama = New Eniac.Controles.CheckBox()
        Me.bscCodigoEmbarcacionCama = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscNombreEmbarcacion = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.cmbTipoCliente = New Eniac.Controles.ComboBox()
        Me.lblCliente = New Eniac.Controles.Label()
        Me.cmbTipoCategoria = New Eniac.Controles.ComboBox()
        Me.cmbTipoVendedor = New Eniac.Controles.ComboBox()
        Me.lblGrupoComprobante = New Eniac.Controles.Label()
        Me.cmbGrupos = New Eniac.Win.ComboBoxGrupoTiposComprobantes()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.chbFormaPago = New Eniac.Controles.CheckBox()
        Me.chbGrupoCategoria = New Eniac.Controles.CheckBox()
        Me.cmbGrupoCategoria = New Eniac.Controles.ComboBox()
        Me.cmbTipoConversion = New Eniac.Controles.ComboBox()
        Me.lblMoneda = New Eniac.Controles.Label()
        Me.cmbMoneda = New Eniac.Controles.ComboBox()
        Me.txtCotizacionDolar = New Eniac.Controles.TextBox()
        Me.lblCotizacionDolar = New Eniac.Controles.Label()
        Me.chbFechaInteres = New Eniac.Controles.CheckBox()
        Me.dtpFechaInteres = New Eniac.Controles.DateTimePicker()
        Me.cmbOrigenCobrador = New Eniac.Controles.ComboBox()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.rbtImpresion1PorHoja = New Eniac.Controles.RadioButton()
        Me.lblImpresion = New Eniac.Controles.Label()
        Me.rbtImpresionNormal = New Eniac.Controles.RadioButton()
        Me.chbExcluirMinutas = New Eniac.Controles.CheckBox()
        Me.chbProvincia = New Eniac.Controles.CheckBox()
        Me.cmbProvincia = New Eniac.Controles.ComboBox()
        Me.chbExcluirPreComprobantes = New Eniac.Controles.CheckBox()
        Me.chbExcluirAnticipos = New Eniac.Controles.CheckBox()
        Me.chbExcluirSaldosNegativos = New Eniac.Controles.CheckBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.grbVencimiento = New System.Windows.Forms.GroupBox()
        Me.optVencVencidos = New Eniac.Controles.RadioButton()
        Me.optVencTodos = New Eniac.Controles.RadioButton()
        Me.grbSaldo = New System.Windows.Forms.GroupBox()
        Me.optTodos = New Eniac.Controles.RadioButton()
        Me.optConSaldo = New Eniac.Controles.RadioButton()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.chbCategoria = New Eniac.Controles.CheckBox()
        Me.cmbCategoria = New Eniac.Controles.ComboBox()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.chbCobrador = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbCobrador = New Eniac.Controles.ComboBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
        Me.grbEmbarcacionCama.SuspendLayout()
        Me.grbVencimiento.SuspendLayout()
        Me.grbSaldo.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance36.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance36
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
        Me.ugDetalle.DataSource = Me.UltraDataSource3
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn1.Width = 32
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Header.Caption = "Tipo"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 40
        UltraGridColumn3.Header.Caption = "Vendedor"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Width = 83
        UltraGridColumn4.Header.VisiblePosition = 25
        UltraGridColumn4.Hidden = True
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance4
        UltraGridColumn5.Header.Caption = "Código"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 58
        UltraGridColumn6.Header.Caption = "Cliente"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 181
        UltraGridColumn7.Header.Caption = "Nombre De Fantasia"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn7.Width = 181
        UltraGridColumn8.Header.Caption = "Comprobante"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 81
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn9.CellAppearance = Appearance5
        UltraGridColumn9.Header.Caption = "Let."
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 30
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance6
        UltraGridColumn10.Header.Caption = "Emisor"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 40
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance7
        UltraGridColumn11.Header.Caption = "Numero"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 60
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance8
        UltraGridColumn12.Header.Caption = "Cta."
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Width = 47
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn13.CellAppearance = Appearance9
        UltraGridColumn13.Format = "dd/MM/yyyy"
        UltraGridColumn13.Header.Caption = "Emision"
        UltraGridColumn13.Header.VisiblePosition = 13
        UltraGridColumn13.Width = 70
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance10
        UltraGridColumn14.Header.Caption = "D.F."
        UltraGridColumn14.Header.VisiblePosition = 14
        UltraGridColumn14.Width = 32
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn15.CellAppearance = Appearance11
        UltraGridColumn15.Format = "dd/MM/yyyy"
        UltraGridColumn15.Header.Caption = "Vencimiento"
        UltraGridColumn15.Header.VisiblePosition = 16
        UltraGridColumn15.Width = 70
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance12
        UltraGridColumn16.Header.Caption = "D.V."
        UltraGridColumn16.Header.VisiblePosition = 17
        UltraGridColumn16.Width = 33
        UltraGridColumn17.Header.Caption = "Forma de Pago"
        UltraGridColumn17.Header.VisiblePosition = 15
        UltraGridColumn17.Width = 100
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance13
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.Caption = "Importe"
        UltraGridColumn18.Header.VisiblePosition = 18
        UltraGridColumn18.Width = 80
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance14
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "Saldo"
        UltraGridColumn19.Header.VisiblePosition = 19
        UltraGridColumn19.Width = 80
        UltraGridColumn20.Header.VisiblePosition = 24
        UltraGridColumn20.Width = 400
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance15
        UltraGridColumn21.Format = "N2"
        UltraGridColumn21.Header.VisiblePosition = 21
        UltraGridColumn21.Width = 80
        UltraGridColumn22.Header.Caption = "Categoria"
        UltraGridColumn22.Header.VisiblePosition = 30
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance16
        UltraGridColumn23.Format = "N2"
        UltraGridColumn23.Header.VisiblePosition = 20
        UltraGridColumn23.Width = 80
        UltraGridColumn24.Header.Caption = "Zona Geográfica"
        UltraGridColumn24.Header.VisiblePosition = 29
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance17
        UltraGridColumn25.Format = "N2"
        UltraGridColumn25.Header.Caption = "Saldo Vencido"
        UltraGridColumn25.Header.VisiblePosition = 22
        UltraGridColumn25.Width = 86
        UltraGridColumn26.Header.VisiblePosition = 31
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.Header.Caption = "S."
        UltraGridColumn27.Header.VisiblePosition = 1
        UltraGridColumn27.Width = 21
        UltraGridColumn28.Header.Caption = "Estado"
        UltraGridColumn28.Header.VisiblePosition = 32
        UltraGridColumn29.Header.Caption = "Id Formas Pago"
        UltraGridColumn29.Header.VisiblePosition = 33
        UltraGridColumn29.Hidden = True
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance18
        UltraGridColumn30.Header.Caption = "Orden Compra"
        UltraGridColumn30.Header.VisiblePosition = 34
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance19
        UltraGridColumn31.Header.Caption = "Id Proveedor"
        UltraGridColumn31.Header.VisiblePosition = 35
        UltraGridColumn31.Hidden = True
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance20
        UltraGridColumn32.Header.Caption = "Cod. Prov."
        UltraGridColumn32.Header.VisiblePosition = 36
        UltraGridColumn32.Width = 67
        UltraGridColumn33.Header.Caption = "Proveedor"
        UltraGridColumn33.Header.VisiblePosition = 37
        UltraGridColumn33.Width = 181
        UltraGridColumn34.Header.VisiblePosition = 38
        UltraGridColumn34.Hidden = True
        UltraGridColumn35.Header.Caption = "Cobrador"
        UltraGridColumn35.Header.VisiblePosition = 23
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance21
        UltraGridColumn36.Format = "N2"
        UltraGridColumn36.Header.Caption = "Cotización Dólar"
        UltraGridColumn36.Header.VisiblePosition = 39
        UltraGridColumn36.Width = 98
        UltraGridColumn37.Header.VisiblePosition = 41
        UltraGridColumn37.Width = 200
        UltraGridColumn38.Header.VisiblePosition = 40
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.Header.VisiblePosition = 42
        UltraGridColumn39.Hidden = True
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance22
        UltraGridColumn40.Header.Caption = "Código Vinculado"
        UltraGridColumn40.Header.VisiblePosition = 43
        UltraGridColumn40.Hidden = True
        UltraGridColumn40.Width = 110
        UltraGridColumn41.Header.Caption = "Nombre Vinculado"
        UltraGridColumn41.Header.VisiblePosition = 44
        UltraGridColumn41.Hidden = True
        UltraGridColumn41.Width = 150
        UltraGridColumn42.Header.VisiblePosition = 45
        UltraGridColumn42.Hidden = True
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn43.CellAppearance = Appearance23
        UltraGridColumn43.Header.Caption = "Codigo Embarcación"
        UltraGridColumn43.Header.VisiblePosition = 26
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.Width = 58
        UltraGridColumn44.Header.Caption = "Embarcacion"
        UltraGridColumn44.Header.VisiblePosition = 28
        UltraGridColumn44.Hidden = True
        UltraGridColumn44.Width = 181
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance24
        UltraGridColumn48.Header.Caption = "Cama"
        UltraGridColumn48.Header.VisiblePosition = 27
        UltraGridColumn48.Hidden = True
        UltraGridColumn45.Header.Caption = "Detalle Producto"
        UltraGridColumn45.Header.VisiblePosition = 12
        UltraGridColumn45.Hidden = True
        UltraGridColumn46.Header.VisiblePosition = 46
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.Header.Caption = "Localidad"
        UltraGridColumn47.Header.VisiblePosition = 47
        UltraGridColumn47.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn48, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance25
        Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance26
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance27.BackColor2 = System.Drawing.SystemColors.Control
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance28
        Appearance29.BackColor = System.Drawing.SystemColors.Highlight
        Appearance29.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance30
        Appearance31.BorderColor = System.Drawing.Color.Silver
        Appearance31.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance31
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance32.BackColor = System.Drawing.SystemColors.Control
        Appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance32.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance32
        Appearance33.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance34
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance35.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance35
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(7, 285)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1018, 247)
        Me.ugDetalle.TabIndex = 1
        '
        'UltraDataSource3
        '
        Me.UltraDataSource3.Band.Columns.AddRange(New Object() {UltraDataColumn28, UltraDataColumn29, UltraDataColumn30, UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35, UltraDataColumn36, UltraDataColumn37, UltraDataColumn38, UltraDataColumn39, UltraDataColumn40, UltraDataColumn41, UltraDataColumn42, UltraDataColumn43, UltraDataColumn44, UltraDataColumn45, UltraDataColumn46, UltraDataColumn47, UltraDataColumn48, UltraDataColumn49, UltraDataColumn50, UltraDataColumn51, UltraDataColumn52, UltraDataColumn53, UltraDataColumn54, UltraDataColumn55, UltraDataColumn56, UltraDataColumn57, UltraDataColumn58, UltraDataColumn59, UltraDataColumn60, UltraDataColumn61, UltraDataColumn62, UltraDataColumn63, UltraDataColumn64, UltraDataColumn65, UltraDataColumn66, UltraDataColumn67, UltraDataColumn68, UltraDataColumn69, UltraDataColumn70, UltraDataColumn71, UltraDataColumn72})
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn73, UltraDataColumn74, UltraDataColumn75, UltraDataColumn76, UltraDataColumn77, UltraDataColumn78, UltraDataColumn79, UltraDataColumn80, UltraDataColumn81, UltraDataColumn82, UltraDataColumn83, UltraDataColumn84, UltraDataColumn85, UltraDataColumn86, UltraDataColumn87, UltraDataColumn88, UltraDataColumn89, UltraDataColumn90, UltraDataColumn91, UltraDataColumn92, UltraDataColumn93, UltraDataColumn94, UltraDataColumn95, UltraDataColumn96, UltraDataColumn97, UltraDataColumn98, UltraDataColumn99, UltraDataColumn100, UltraDataColumn101, UltraDataColumn102, UltraDataColumn103, UltraDataColumn104, UltraDataColumn105, UltraDataColumn106, UltraDataColumn107, UltraDataColumn108, UltraDataColumn109})
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'stsStado
        '
        Me.stsStado.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1037, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(958, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator3, Me.tsbImprimir2, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1037, 29)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir2
        '
        Me.tsbImprimir2.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsbImprimir2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir2.Name = "tsbImprimir2"
        Me.tsbImprimir2.Size = New System.Drawing.Size(125, 26)
        Me.tsbImprimir2.Text = "Imp. &Prediseñado"
        Me.tsbImprimir2.ToolTipText = "Imprimir y Grabar (F4)"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.chbAgruparIdClienteCtaCte)
        Me.grbFiltros.Controls.Add(Me.chbLocalidad)
        Me.grbFiltros.Controls.Add(Me.bscCodigoLocalidad)
        Me.grbFiltros.Controls.Add(Me.bscNombreLocalidad)
        Me.grbFiltros.Controls.Add(Me.chbMostrarDetalleProducto)
        Me.grbFiltros.Controls.Add(Me.grbEmbarcacionCama)
        Me.grbFiltros.Controls.Add(Me.cmbTipoCliente)
        Me.grbFiltros.Controls.Add(Me.lblCliente)
        Me.grbFiltros.Controls.Add(Me.cmbTipoCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbTipoVendedor)
        Me.grbFiltros.Controls.Add(Me.lblGrupoComprobante)
        Me.grbFiltros.Controls.Add(Me.cmbGrupos)
        Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
        Me.grbFiltros.Controls.Add(Me.chbFormaPago)
        Me.grbFiltros.Controls.Add(Me.chbGrupoCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbGrupoCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbTipoConversion)
        Me.grbFiltros.Controls.Add(Me.cmbMoneda)
        Me.grbFiltros.Controls.Add(Me.lblMoneda)
        Me.grbFiltros.Controls.Add(Me.txtCotizacionDolar)
        Me.grbFiltros.Controls.Add(Me.lblCotizacionDolar)
        Me.grbFiltros.Controls.Add(Me.chbFechaInteres)
        Me.grbFiltros.Controls.Add(Me.dtpFechaInteres)
        Me.grbFiltros.Controls.Add(Me.cmbOrigenCobrador)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.rbtImpresion1PorHoja)
        Me.grbFiltros.Controls.Add(Me.rbtImpresionNormal)
        Me.grbFiltros.Controls.Add(Me.chbExcluirMinutas)
        Me.grbFiltros.Controls.Add(Me.chbProvincia)
        Me.grbFiltros.Controls.Add(Me.cmbProvincia)
        Me.grbFiltros.Controls.Add(Me.chbExcluirPreComprobantes)
        Me.grbFiltros.Controls.Add(Me.chbExcluirAnticipos)
        Me.grbFiltros.Controls.Add(Me.chbExcluirSaldosNegativos)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.grbVencimiento)
        Me.grbFiltros.Controls.Add(Me.grbSaldo)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grbFiltros.Controls.Add(Me.chbCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.chbCobrador)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbCobrador)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.chbFecha)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grbFiltros.Controls.Add(Me.lblImpresion)
        Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
        Me.grbFiltros.Location = New System.Drawing.Point(7, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1018, 241)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'chbAgruparIdClienteCtaCte
        '
        Me.chbAgruparIdClienteCtaCte.AutoSize = True
        Me.chbAgruparIdClienteCtaCte.Location = New System.Drawing.Point(730, 22)
        Me.chbAgruparIdClienteCtaCte.Name = "chbAgruparIdClienteCtaCte"
        Me.chbAgruparIdClienteCtaCte.Size = New System.Drawing.Size(175, 17)
        Me.chbAgruparIdClienteCtaCte.TabIndex = 69
        Me.chbAgruparIdClienteCtaCte.Text = "Agrupado por Cliente Vinculado"
        Me.chbAgruparIdClienteCtaCte.UseVisualStyleBackColor = True
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
        Me.chbLocalidad.Location = New System.Drawing.Point(571, 53)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 68
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.ActivarFiltroEnGrilla = True
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidad"
        Me.bscCodigoLocalidad.ConfigBuscador = Nothing
        Me.bscCodigoLocalidad.Datos = Nothing
        Me.bscCodigoLocalidad.FilaDevuelta = Nothing
        Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoLocalidad.IsDecimal = False
        Me.bscCodigoLocalidad.IsNumber = False
        Me.bscCodigoLocalidad.IsPK = False
        Me.bscCodigoLocalidad.IsRequired = False
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Nothing
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(655, 51)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = True
        Me.bscCodigoLocalidad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoLocalidad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoLocalidad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoLocalidad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(73, 20)
        Me.bscCodigoLocalidad.TabIndex = 66
        '
        'bscNombreLocalidad
        '
        Me.bscNombreLocalidad.ActivarFiltroEnGrilla = True
        Me.bscNombreLocalidad.BindearPropiedadControl = Nothing
        Me.bscNombreLocalidad.BindearPropiedadEntidad = Nothing
        Me.bscNombreLocalidad.ConfigBuscador = Nothing
        Me.bscNombreLocalidad.Datos = Nothing
        Me.bscNombreLocalidad.FilaDevuelta = Nothing
        Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreLocalidad.IsDecimal = False
        Me.bscNombreLocalidad.IsNumber = False
        Me.bscNombreLocalidad.IsPK = False
        Me.bscNombreLocalidad.IsRequired = False
        Me.bscNombreLocalidad.Key = ""
        Me.bscNombreLocalidad.LabelAsoc = Nothing
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(734, 52)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = True
        Me.bscNombreLocalidad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreLocalidad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreLocalidad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreLocalidad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(171, 20)
        Me.bscNombreLocalidad.TabIndex = 67
        '
        'chbMostrarDetalleProducto
        '
        Me.chbMostrarDetalleProducto.AutoSize = True
        Me.chbMostrarDetalleProducto.BindearPropiedadControl = Nothing
        Me.chbMostrarDetalleProducto.BindearPropiedadEntidad = Nothing
        Me.chbMostrarDetalleProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMostrarDetalleProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMostrarDetalleProducto.IsPK = False
        Me.chbMostrarDetalleProducto.IsRequired = False
        Me.chbMostrarDetalleProducto.Key = Nothing
        Me.chbMostrarDetalleProducto.LabelAsoc = Nothing
        Me.chbMostrarDetalleProducto.Location = New System.Drawing.Point(735, 177)
        Me.chbMostrarDetalleProducto.Name = "chbMostrarDetalleProducto"
        Me.chbMostrarDetalleProducto.Size = New System.Drawing.Size(163, 17)
        Me.chbMostrarDetalleProducto.TabIndex = 64
        Me.chbMostrarDetalleProducto.Text = "Mostrar Detalle de Productos"
        Me.chbMostrarDetalleProducto.UseVisualStyleBackColor = True
        '
        'grbEmbarcacionCama
        '
        Me.grbEmbarcacionCama.Controls.Add(Me.chbEmbarcacionCama)
        Me.grbEmbarcacionCama.Controls.Add(Me.bscCodigoEmbarcacionCama)
        Me.grbEmbarcacionCama.Controls.Add(Me.bscNombreEmbarcacion)
        Me.grbEmbarcacionCama.Location = New System.Drawing.Point(241, 171)
        Me.grbEmbarcacionCama.Name = "grbEmbarcacionCama"
        Me.grbEmbarcacionCama.Size = New System.Drawing.Size(435, 28)
        Me.grbEmbarcacionCama.TabIndex = 63
        Me.grbEmbarcacionCama.Visible = False
        '
        'chbEmbarcacionCama
        '
        Me.chbEmbarcacionCama.AutoSize = True
        Me.chbEmbarcacionCama.BindearPropiedadControl = Nothing
        Me.chbEmbarcacionCama.BindearPropiedadEntidad = Nothing
        Me.chbEmbarcacionCama.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmbarcacionCama.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmbarcacionCama.IsPK = False
        Me.chbEmbarcacionCama.IsRequired = False
        Me.chbEmbarcacionCama.Key = Nothing
        Me.chbEmbarcacionCama.LabelAsoc = Nothing
        Me.chbEmbarcacionCama.Location = New System.Drawing.Point(9, 5)
        Me.chbEmbarcacionCama.Name = "chbEmbarcacionCama"
        Me.chbEmbarcacionCama.Size = New System.Drawing.Size(32, 17)
        Me.chbEmbarcacionCama.TabIndex = 60
        Me.chbEmbarcacionCama.Text = "--"
        Me.chbEmbarcacionCama.UseVisualStyleBackColor = True
        '
        'bscCodigoEmbarcacionCama
        '
        Me.bscCodigoEmbarcacionCama.ActivarFiltroEnGrilla = True
        Me.bscCodigoEmbarcacionCama.BindearPropiedadControl = Nothing
        Me.bscCodigoEmbarcacionCama.BindearPropiedadEntidad = Nothing
        Me.bscCodigoEmbarcacionCama.ConfigBuscador = Nothing
        Me.bscCodigoEmbarcacionCama.Datos = Nothing
        Me.bscCodigoEmbarcacionCama.Enabled = False
        Me.bscCodigoEmbarcacionCama.FilaDevuelta = Nothing
        Me.bscCodigoEmbarcacionCama.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoEmbarcacionCama.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoEmbarcacionCama.IsDecimal = False
        Me.bscCodigoEmbarcacionCama.IsNumber = True
        Me.bscCodigoEmbarcacionCama.IsPK = False
        Me.bscCodigoEmbarcacionCama.IsRequired = False
        Me.bscCodigoEmbarcacionCama.Key = ""
        Me.bscCodigoEmbarcacionCama.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoEmbarcacionCama.Location = New System.Drawing.Point(100, 4)
        Me.bscCodigoEmbarcacionCama.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bscCodigoEmbarcacionCama.MaxLengh = "32767"
        Me.bscCodigoEmbarcacionCama.Name = "bscCodigoEmbarcacionCama"
        Me.bscCodigoEmbarcacionCama.Permitido = True
        Me.bscCodigoEmbarcacionCama.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoEmbarcacionCama.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoEmbarcacionCama.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoEmbarcacionCama.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoEmbarcacionCama.Selecciono = False
        Me.bscCodigoEmbarcacionCama.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoEmbarcacionCama.TabIndex = 61
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(224, 8)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 3
        Me.lblCodigoCliente.Text = "Código"
        '
        'bscNombreEmbarcacion
        '
        Me.bscNombreEmbarcacion.ActivarFiltroEnGrilla = True
        Me.bscNombreEmbarcacion.AutoSize = True
        Me.bscNombreEmbarcacion.BindearPropiedadControl = Nothing
        Me.bscNombreEmbarcacion.BindearPropiedadEntidad = Nothing
        Me.bscNombreEmbarcacion.ConfigBuscador = Nothing
        Me.bscNombreEmbarcacion.Datos = Nothing
        Me.bscNombreEmbarcacion.Enabled = False
        Me.bscNombreEmbarcacion.FilaDevuelta = Nothing
        Me.bscNombreEmbarcacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreEmbarcacion.IsDecimal = False
        Me.bscNombreEmbarcacion.IsNumber = False
        Me.bscNombreEmbarcacion.IsPK = False
        Me.bscNombreEmbarcacion.IsRequired = False
        Me.bscNombreEmbarcacion.Key = ""
        Me.bscNombreEmbarcacion.LabelAsoc = Me.lblNombre
        Me.bscNombreEmbarcacion.Location = New System.Drawing.Point(193, 4)
        Me.bscNombreEmbarcacion.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreEmbarcacion.MaxLengh = "32767"
        Me.bscNombreEmbarcacion.Name = "bscNombreEmbarcacion"
        Me.bscNombreEmbarcacion.Permitido = True
        Me.bscNombreEmbarcacion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreEmbarcacion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreEmbarcacion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreEmbarcacion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreEmbarcacion.Selecciono = False
        Me.bscNombreEmbarcacion.Size = New System.Drawing.Size(238, 23)
        Me.bscNombreEmbarcacion.TabIndex = 62
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(317, 8)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
        '
        'cmbTipoCliente
        '
        Me.cmbTipoCliente.BindearPropiedadControl = Nothing
        Me.cmbTipoCliente.BindearPropiedadEntidad = Nothing
        Me.cmbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoCliente.FormattingEnabled = True
        Me.cmbTipoCliente.IsPK = False
        Me.cmbTipoCliente.IsRequired = False
        Me.cmbTipoCliente.Items.AddRange(New Object() {"CLIENTE", "VINCULADO"})
        Me.cmbTipoCliente.Key = Nothing
        Me.cmbTipoCliente.LabelAsoc = Nothing
        Me.cmbTipoCliente.Location = New System.Drawing.Point(569, 21)
        Me.cmbTipoCliente.Name = "cmbTipoCliente"
        Me.cmbTipoCliente.Size = New System.Drawing.Size(147, 21)
        Me.cmbTipoCliente.TabIndex = 59
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Location = New System.Drawing.Point(568, 8)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(66, 13)
        Me.lblCliente.TabIndex = 58
        Me.lblCliente.Text = "Tipo Cliente "
        '
        'cmbTipoCategoria
        '
        Me.cmbTipoCategoria.BindearPropiedadControl = Nothing
        Me.cmbTipoCategoria.BindearPropiedadEntidad = Nothing
        Me.cmbTipoCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoCategoria.FormattingEnabled = True
        Me.cmbTipoCategoria.IsPK = False
        Me.cmbTipoCategoria.IsRequired = False
        Me.cmbTipoCategoria.Key = Nothing
        Me.cmbTipoCategoria.LabelAsoc = Nothing
        Me.cmbTipoCategoria.Location = New System.Drawing.Point(215, 139)
        Me.cmbTipoCategoria.Name = "cmbTipoCategoria"
        Me.cmbTipoCategoria.Size = New System.Drawing.Size(124, 21)
        Me.cmbTipoCategoria.TabIndex = 56
        '
        'cmbTipoVendedor
        '
        Me.cmbTipoVendedor.BindearPropiedadControl = Nothing
        Me.cmbTipoVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbTipoVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoVendedor.FormattingEnabled = True
        Me.cmbTipoVendedor.IsPK = False
        Me.cmbTipoVendedor.IsRequired = False
        Me.cmbTipoVendedor.Key = Nothing
        Me.cmbTipoVendedor.LabelAsoc = Nothing
        Me.cmbTipoVendedor.Location = New System.Drawing.Point(215, 79)
        Me.cmbTipoVendedor.Name = "cmbTipoVendedor"
        Me.cmbTipoVendedor.Size = New System.Drawing.Size(124, 21)
        Me.cmbTipoVendedor.TabIndex = 55
        '
        'lblGrupoComprobante
        '
        Me.lblGrupoComprobante.AutoSize = True
        Me.lblGrupoComprobante.LabelAsoc = Nothing
        Me.lblGrupoComprobante.Location = New System.Drawing.Point(246, 211)
        Me.lblGrupoComprobante.Name = "lblGrupoComprobante"
        Me.lblGrupoComprobante.Size = New System.Drawing.Size(36, 13)
        Me.lblGrupoComprobante.TabIndex = 34
        Me.lblGrupoComprobante.Text = "Grupo"
        '
        'cmbGrupos
        '
        Me.cmbGrupos.BindearPropiedadControl = Nothing
        Me.cmbGrupos.BindearPropiedadEntidad = Nothing
        Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupos.FormattingEnabled = True
        Me.cmbGrupos.IsPK = False
        Me.cmbGrupos.IsRequired = False
        Me.cmbGrupos.Key = Nothing
        Me.cmbGrupos.LabelAsoc = Me.lblGrupoComprobante
        Me.cmbGrupos.Location = New System.Drawing.Point(288, 208)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(121, 21)
        Me.cmbGrupos.TabIndex = 35
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
        Me.cmbFormaPago.LabelAsoc = Me.chbFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(118, 173)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(122, 21)
        Me.cmbFormaPago.TabIndex = 8
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
        Me.chbFormaPago.Location = New System.Drawing.Point(8, 175)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFormaPago.TabIndex = 7
        Me.chbFormaPago.Text = "Forma de Pago"
        Me.chbFormaPago.UseVisualStyleBackColor = True
        '
        'chbGrupoCategoria
        '
        Me.chbGrupoCategoria.AutoSize = True
        Me.chbGrupoCategoria.BindearPropiedadControl = Nothing
        Me.chbGrupoCategoria.BindearPropiedadEntidad = Nothing
        Me.chbGrupoCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrupoCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrupoCategoria.IsPK = False
        Me.chbGrupoCategoria.IsRequired = False
        Me.chbGrupoCategoria.Key = Nothing
        Me.chbGrupoCategoria.LabelAsoc = Nothing
        Me.chbGrupoCategoria.Location = New System.Drawing.Point(353, 143)
        Me.chbGrupoCategoria.Name = "chbGrupoCategoria"
        Me.chbGrupoCategoria.Size = New System.Drawing.Size(105, 17)
        Me.chbGrupoCategoria.TabIndex = 42
        Me.chbGrupoCategoria.Text = "Grupo Categoría"
        Me.chbGrupoCategoria.UseVisualStyleBackColor = True
        '
        'cmbGrupoCategoria
        '
        Me.cmbGrupoCategoria.BindearPropiedadControl = Nothing
        Me.cmbGrupoCategoria.BindearPropiedadEntidad = Nothing
        Me.cmbGrupoCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupoCategoria.Enabled = False
        Me.cmbGrupoCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrupoCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupoCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupoCategoria.FormattingEnabled = True
        Me.cmbGrupoCategoria.IsPK = False
        Me.cmbGrupoCategoria.IsRequired = False
        Me.cmbGrupoCategoria.Key = Nothing
        Me.cmbGrupoCategoria.LabelAsoc = Nothing
        Me.cmbGrupoCategoria.Location = New System.Drawing.Point(467, 141)
        Me.cmbGrupoCategoria.Name = "cmbGrupoCategoria"
        Me.cmbGrupoCategoria.Size = New System.Drawing.Size(95, 21)
        Me.cmbGrupoCategoria.TabIndex = 43
        '
        'cmbTipoConversion
        '
        Me.cmbTipoConversion.BindearPropiedadControl = Nothing
        Me.cmbTipoConversion.BindearPropiedadEntidad = Nothing
        Me.cmbTipoConversion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoConversion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoConversion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoConversion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoConversion.FormattingEnabled = True
        Me.cmbTipoConversion.IsPK = False
        Me.cmbTipoConversion.IsRequired = False
        Me.cmbTipoConversion.Key = Nothing
        Me.cmbTipoConversion.LabelAsoc = Me.lblMoneda
        Me.cmbTipoConversion.Location = New System.Drawing.Point(667, 208)
        Me.cmbTipoConversion.Name = "cmbTipoConversion"
        Me.cmbTipoConversion.Size = New System.Drawing.Size(103, 21)
        Me.cmbTipoConversion.TabIndex = 46
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.LabelAsoc = Nothing
        Me.lblMoneda.Location = New System.Drawing.Point(568, 212)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(46, 13)
        Me.lblMoneda.TabIndex = 44
        Me.lblMoneda.Text = "Moneda"
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BindearPropiedadControl = Nothing
        Me.cmbMoneda.BindearPropiedadEntidad = Nothing
        Me.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.IsPK = False
        Me.cmbMoneda.IsRequired = False
        Me.cmbMoneda.Items.AddRange(New Object() {"del producto"})
        Me.cmbMoneda.Key = Nothing
        Me.cmbMoneda.LabelAsoc = Me.lblMoneda
        Me.cmbMoneda.Location = New System.Drawing.Point(612, 208)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(54, 21)
        Me.cmbMoneda.TabIndex = 45
        '
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.BackColor = System.Drawing.SystemColors.Window
        Me.txtCotizacionDolar.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolar.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolar.Formato = "##0.00"
        Me.txtCotizacionDolar.IsDecimal = True
        Me.txtCotizacionDolar.IsNumber = True
        Me.txtCotizacionDolar.IsPK = False
        Me.txtCotizacionDolar.IsRequired = False
        Me.txtCotizacionDolar.Key = ""
        Me.txtCotizacionDolar.LabelAsoc = Me.lblCotizacionDolar
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(798, 208)
        Me.txtCotizacionDolar.MaxLength = 7
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(43, 20)
        Me.txtCotizacionDolar.TabIndex = 48
        Me.txtCotizacionDolar.Text = "0.00"
        Me.txtCotizacionDolar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCotizacionDolar.Visible = False
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotizacionDolar.LabelAsoc = Nothing
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(769, 209)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(33, 18)
        Me.lblCotizacionDolar.TabIndex = 47
        Me.lblCotizacionDolar.Text = "Cotiz."
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCotizacionDolar.Visible = False
        '
        'chbFechaInteres
        '
        Me.chbFechaInteres.AutoSize = True
        Me.chbFechaInteres.BindearPropiedadControl = Nothing
        Me.chbFechaInteres.BindearPropiedadEntidad = Nothing
        Me.chbFechaInteres.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaInteres.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaInteres.IsPK = False
        Me.chbFechaInteres.IsRequired = False
        Me.chbFechaInteres.Key = Nothing
        Me.chbFechaInteres.LabelAsoc = Nothing
        Me.chbFechaInteres.Location = New System.Drawing.Point(352, 112)
        Me.chbFechaInteres.Name = "chbFechaInteres"
        Me.chbFechaInteres.Size = New System.Drawing.Size(91, 17)
        Me.chbFechaInteres.TabIndex = 28
        Me.chbFechaInteres.Text = "Fecha Interes"
        Me.chbFechaInteres.UseVisualStyleBackColor = True
        '
        'dtpFechaInteres
        '
        Me.dtpFechaInteres.BindearPropiedadControl = Nothing
        Me.dtpFechaInteres.BindearPropiedadEntidad = Nothing
        Me.dtpFechaInteres.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaInteres.Enabled = False
        Me.dtpFechaInteres.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaInteres.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInteres.IsPK = False
        Me.dtpFechaInteres.IsRequired = False
        Me.dtpFechaInteres.Key = ""
        Me.dtpFechaInteres.LabelAsoc = Nothing
        Me.dtpFechaInteres.Location = New System.Drawing.Point(465, 109)
        Me.dtpFechaInteres.Name = "dtpFechaInteres"
        Me.dtpFechaInteres.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaInteres.TabIndex = 29
        '
        'cmbOrigenCobrador
        '
        Me.cmbOrigenCobrador.BindearPropiedadControl = Nothing
        Me.cmbOrigenCobrador.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenCobrador.FormattingEnabled = True
        Me.cmbOrigenCobrador.IsPK = False
        Me.cmbOrigenCobrador.IsRequired = False
        Me.cmbOrigenCobrador.Key = Nothing
        Me.cmbOrigenCobrador.LabelAsoc = Nothing
        Me.cmbOrigenCobrador.Location = New System.Drawing.Point(215, 109)
        Me.cmbOrigenCobrador.Name = "cmbOrigenCobrador"
        Me.cmbOrigenCobrador.Size = New System.Drawing.Size(124, 21)
        Me.cmbOrigenCobrador.TabIndex = 27
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(6, 25)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(60, 21)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(103, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'rbtImpresion1PorHoja
        '
        Me.rbtImpresion1PorHoja.AutoSize = True
        Me.rbtImpresion1PorHoja.BindearPropiedadControl = Nothing
        Me.rbtImpresion1PorHoja.BindearPropiedadEntidad = Nothing
        Me.rbtImpresion1PorHoja.ForeColorFocus = System.Drawing.Color.Red
        Me.rbtImpresion1PorHoja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rbtImpresion1PorHoja.IsPK = False
        Me.rbtImpresion1PorHoja.IsRequired = False
        Me.rbtImpresion1PorHoja.Key = Nothing
        Me.rbtImpresion1PorHoja.LabelAsoc = Me.lblImpresion
        Me.rbtImpresion1PorHoja.Location = New System.Drawing.Point(952, 209)
        Me.rbtImpresion1PorHoja.Name = "rbtImpresion1PorHoja"
        Me.rbtImpresion1PorHoja.Size = New System.Drawing.Size(64, 17)
        Me.rbtImpresion1PorHoja.TabIndex = 51
        Me.rbtImpresion1PorHoja.Text = "1 x Hoja"
        Me.rbtImpresion1PorHoja.UseVisualStyleBackColor = True
        '
        'lblImpresion
        '
        Me.lblImpresion.AutoSize = True
        Me.lblImpresion.LabelAsoc = Nothing
        Me.lblImpresion.Location = New System.Drawing.Point(841, 211)
        Me.lblImpresion.Name = "lblImpresion"
        Me.lblImpresion.Size = New System.Drawing.Size(52, 13)
        Me.lblImpresion.TabIndex = 49
        Me.lblImpresion.Text = "Impresión"
        '
        'rbtImpresionNormal
        '
        Me.rbtImpresionNormal.AutoSize = True
        Me.rbtImpresionNormal.BindearPropiedadControl = Nothing
        Me.rbtImpresionNormal.BindearPropiedadEntidad = Nothing
        Me.rbtImpresionNormal.Checked = True
        Me.rbtImpresionNormal.ForeColorFocus = System.Drawing.Color.Red
        Me.rbtImpresionNormal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rbtImpresionNormal.IsPK = False
        Me.rbtImpresionNormal.IsRequired = False
        Me.rbtImpresionNormal.Key = Nothing
        Me.rbtImpresionNormal.LabelAsoc = Me.lblImpresion
        Me.rbtImpresionNormal.Location = New System.Drawing.Point(894, 209)
        Me.rbtImpresionNormal.Name = "rbtImpresionNormal"
        Me.rbtImpresionNormal.Size = New System.Drawing.Size(58, 17)
        Me.rbtImpresionNormal.TabIndex = 50
        Me.rbtImpresionNormal.TabStop = True
        Me.rbtImpresionNormal.Text = "Normal"
        Me.rbtImpresionNormal.UseVisualStyleBackColor = True
        '
        'chbExcluirMinutas
        '
        Me.chbExcluirMinutas.AutoSize = True
        Me.chbExcluirMinutas.BindearPropiedadControl = Nothing
        Me.chbExcluirMinutas.BindearPropiedadEntidad = Nothing
        Me.chbExcluirMinutas.Checked = True
        Me.chbExcluirMinutas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbExcluirMinutas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirMinutas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirMinutas.IsPK = False
        Me.chbExcluirMinutas.IsRequired = False
        Me.chbExcluirMinutas.Key = Nothing
        Me.chbExcluirMinutas.LabelAsoc = Nothing
        Me.chbExcluirMinutas.Location = New System.Drawing.Point(571, 146)
        Me.chbExcluirMinutas.Name = "chbExcluirMinutas"
        Me.chbExcluirMinutas.Size = New System.Drawing.Size(97, 17)
        Me.chbExcluirMinutas.TabIndex = 38
        Me.chbExcluirMinutas.Text = "Excluir Minutas"
        Me.chbExcluirMinutas.UseVisualStyleBackColor = True
        '
        'chbProvincia
        '
        Me.chbProvincia.AutoSize = True
        Me.chbProvincia.BindearPropiedadControl = Nothing
        Me.chbProvincia.BindearPropiedadEntidad = Nothing
        Me.chbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProvincia.IsPK = False
        Me.chbProvincia.IsRequired = False
        Me.chbProvincia.Key = Nothing
        Me.chbProvincia.LabelAsoc = Nothing
        Me.chbProvincia.Location = New System.Drawing.Point(365, 52)
        Me.chbProvincia.Name = "chbProvincia"
        Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
        Me.chbProvincia.TabIndex = 15
        Me.chbProvincia.Text = "Provincia"
        Me.chbProvincia.UseVisualStyleBackColor = True
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
        Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Enabled = False
        Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.IsPK = False
        Me.cmbProvincia.IsRequired = True
        Me.cmbProvincia.Key = Nothing
        Me.cmbProvincia.LabelAsoc = Nothing
        Me.cmbProvincia.Location = New System.Drawing.Point(441, 51)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(121, 21)
        Me.cmbProvincia.TabIndex = 16
        '
        'chbExcluirPreComprobantes
        '
        Me.chbExcluirPreComprobantes.AutoSize = True
        Me.chbExcluirPreComprobantes.BindearPropiedadControl = Nothing
        Me.chbExcluirPreComprobantes.BindearPropiedadEntidad = Nothing
        Me.chbExcluirPreComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirPreComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirPreComprobantes.IsPK = False
        Me.chbExcluirPreComprobantes.IsRequired = False
        Me.chbExcluirPreComprobantes.Key = Nothing
        Me.chbExcluirPreComprobantes.LabelAsoc = Nothing
        Me.chbExcluirPreComprobantes.Location = New System.Drawing.Point(571, 124)
        Me.chbExcluirPreComprobantes.Name = "chbExcluirPreComprobantes"
        Me.chbExcluirPreComprobantes.Size = New System.Drawing.Size(147, 17)
        Me.chbExcluirPreComprobantes.TabIndex = 30
        Me.chbExcluirPreComprobantes.Text = "Excluir Pre-Comprobantes"
        Me.chbExcluirPreComprobantes.UseVisualStyleBackColor = True
        '
        'chbExcluirAnticipos
        '
        Me.chbExcluirAnticipos.AutoSize = True
        Me.chbExcluirAnticipos.BindearPropiedadControl = Nothing
        Me.chbExcluirAnticipos.BindearPropiedadEntidad = Nothing
        Me.chbExcluirAnticipos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirAnticipos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirAnticipos.IsPK = False
        Me.chbExcluirAnticipos.IsRequired = False
        Me.chbExcluirAnticipos.Key = Nothing
        Me.chbExcluirAnticipos.LabelAsoc = Nothing
        Me.chbExcluirAnticipos.Location = New System.Drawing.Point(571, 79)
        Me.chbExcluirAnticipos.Name = "chbExcluirAnticipos"
        Me.chbExcluirAnticipos.Size = New System.Drawing.Size(103, 17)
        Me.chbExcluirAnticipos.TabIndex = 17
        Me.chbExcluirAnticipos.Text = "Excluir Anticipos"
        Me.chbExcluirAnticipos.UseVisualStyleBackColor = True
        '
        'chbExcluirSaldosNegativos
        '
        Me.chbExcluirSaldosNegativos.AutoSize = True
        Me.chbExcluirSaldosNegativos.BindearPropiedadControl = Nothing
        Me.chbExcluirSaldosNegativos.BindearPropiedadEntidad = Nothing
        Me.chbExcluirSaldosNegativos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluirSaldosNegativos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluirSaldosNegativos.IsPK = False
        Me.chbExcluirSaldosNegativos.IsRequired = False
        Me.chbExcluirSaldosNegativos.Key = Nothing
        Me.chbExcluirSaldosNegativos.LabelAsoc = Nothing
        Me.chbExcluirSaldosNegativos.Location = New System.Drawing.Point(571, 102)
        Me.chbExcluirSaldosNegativos.Name = "chbExcluirSaldosNegativos"
        Me.chbExcluirSaldosNegativos.Size = New System.Drawing.Size(143, 17)
        Me.chbExcluirSaldosNegativos.TabIndex = 24
        Me.chbExcluirSaldosNegativos.Text = "Excluir Saldos Negativos"
        Me.chbExcluirSaldosNegativos.UseVisualStyleBackColor = True
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
        Me.chbCliente.Location = New System.Drawing.Point(169, 25)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 2
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = True
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(227, 24)
        Me.bscCodigoCliente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 4
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
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
        Me.bscCliente.Location = New System.Drawing.Point(320, 23)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(243, 23)
        Me.bscCliente.TabIndex = 6
        '
        'grbVencimiento
        '
        Me.grbVencimiento.Controls.Add(Me.optVencVencidos)
        Me.grbVencimiento.Controls.Add(Me.optVencTodos)
        Me.grbVencimiento.Location = New System.Drawing.Point(732, 80)
        Me.grbVencimiento.Name = "grbVencimiento"
        Me.grbVencimiento.Size = New System.Drawing.Size(173, 41)
        Me.grbVencimiento.TabIndex = 18
        Me.grbVencimiento.TabStop = False
        Me.grbVencimiento.Text = "Vencimiento"
        '
        'optVencVencidos
        '
        Me.optVencVencidos.AutoSize = True
        Me.optVencVencidos.BindearPropiedadControl = Nothing
        Me.optVencVencidos.BindearPropiedadEntidad = Nothing
        Me.optVencVencidos.ForeColorFocus = System.Drawing.Color.Red
        Me.optVencVencidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optVencVencidos.IsPK = False
        Me.optVencVencidos.IsRequired = False
        Me.optVencVencidos.Key = Nothing
        Me.optVencVencidos.LabelAsoc = Nothing
        Me.optVencVencidos.Location = New System.Drawing.Point(77, 17)
        Me.optVencVencidos.Name = "optVencVencidos"
        Me.optVencVencidos.Size = New System.Drawing.Size(69, 17)
        Me.optVencVencidos.TabIndex = 1
        Me.optVencVencidos.Text = "Vencidos"
        Me.optVencVencidos.UseVisualStyleBackColor = True
        '
        'optVencTodos
        '
        Me.optVencTodos.AutoSize = True
        Me.optVencTodos.BindearPropiedadControl = Nothing
        Me.optVencTodos.BindearPropiedadEntidad = Nothing
        Me.optVencTodos.Checked = True
        Me.optVencTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.optVencTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optVencTodos.IsPK = False
        Me.optVencTodos.IsRequired = False
        Me.optVencTodos.Key = Nothing
        Me.optVencTodos.LabelAsoc = Nothing
        Me.optVencTodos.Location = New System.Drawing.Point(10, 17)
        Me.optVencTodos.Name = "optVencTodos"
        Me.optVencTodos.Size = New System.Drawing.Size(55, 17)
        Me.optVencTodos.TabIndex = 0
        Me.optVencTodos.TabStop = True
        Me.optVencTodos.Text = "Todos"
        Me.optVencTodos.UseVisualStyleBackColor = True
        '
        'grbSaldo
        '
        Me.grbSaldo.Controls.Add(Me.optTodos)
        Me.grbSaldo.Controls.Add(Me.optConSaldo)
        Me.grbSaldo.Location = New System.Drawing.Point(732, 128)
        Me.grbSaldo.Name = "grbSaldo"
        Me.grbSaldo.Size = New System.Drawing.Size(173, 41)
        Me.grbSaldo.TabIndex = 31
        Me.grbSaldo.TabStop = False
        Me.grbSaldo.Text = "Saldo"
        '
        'optTodos
        '
        Me.optTodos.AutoSize = True
        Me.optTodos.BindearPropiedadControl = Nothing
        Me.optTodos.BindearPropiedadEntidad = Nothing
        Me.optTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.optTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optTodos.IsPK = False
        Me.optTodos.IsRequired = False
        Me.optTodos.Key = Nothing
        Me.optTodos.LabelAsoc = Nothing
        Me.optTodos.Location = New System.Drawing.Point(111, 17)
        Me.optTodos.Name = "optTodos"
        Me.optTodos.Size = New System.Drawing.Size(55, 17)
        Me.optTodos.TabIndex = 1
        Me.optTodos.Text = "Todos"
        Me.optTodos.UseVisualStyleBackColor = True
        '
        'optConSaldo
        '
        Me.optConSaldo.AutoSize = True
        Me.optConSaldo.BindearPropiedadControl = Nothing
        Me.optConSaldo.BindearPropiedadEntidad = Nothing
        Me.optConSaldo.Checked = True
        Me.optConSaldo.ForeColorFocus = System.Drawing.Color.Red
        Me.optConSaldo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.optConSaldo.IsPK = False
        Me.optConSaldo.IsRequired = False
        Me.optConSaldo.Key = Nothing
        Me.optConSaldo.LabelAsoc = Nothing
        Me.optConSaldo.Location = New System.Drawing.Point(11, 17)
        Me.optConSaldo.Name = "optConSaldo"
        Me.optConSaldo.Size = New System.Drawing.Size(97, 17)
        Me.optConSaldo.TabIndex = 0
        Me.optConSaldo.TabStop = True
        Me.optConSaldo.Text = "Solo con Saldo"
        Me.optConSaldo.UseVisualStyleBackColor = True
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(911, 133)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 53
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'cmbGrabanLibro
        '
        Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
        Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
        Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrabanLibro.FormattingEnabled = True
        Me.cmbGrabanLibro.IsPK = False
        Me.cmbGrabanLibro.IsRequired = False
        Me.cmbGrabanLibro.Key = Nothing
        Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabanLibro
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(489, 208)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(74, 21)
        Me.cmbGrabanLibro.TabIndex = 37
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(415, 211)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 36
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'chbCategoria
        '
        Me.chbCategoria.AutoSize = True
        Me.chbCategoria.BindearPropiedadControl = Nothing
        Me.chbCategoria.BindearPropiedadEntidad = Nothing
        Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoria.IsPK = False
        Me.chbCategoria.IsRequired = False
        Me.chbCategoria.Key = Nothing
        Me.chbCategoria.LabelAsoc = Nothing
        Me.chbCategoria.Location = New System.Drawing.Point(8, 143)
        Me.chbCategoria.Name = "chbCategoria"
        Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoria.TabIndex = 40
        Me.chbCategoria.Text = "Categoria"
        Me.chbCategoria.UseVisualStyleBackColor = True
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoria.BindearPropiedadEntidad = "Categoria.IdCategoria"
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Enabled = False
        Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.IsPK = False
        Me.cmbCategoria.IsRequired = True
        Me.cmbCategoria.Key = Nothing
        Me.cmbCategoria.LabelAsoc = Nothing
        Me.cmbCategoria.Location = New System.Drawing.Point(87, 139)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(122, 21)
        Me.cmbCategoria.TabIndex = 41
        '
        'cmbZonaGeografica
        '
        Me.cmbZonaGeografica.BindearPropiedadControl = Nothing
        Me.cmbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaGeografica.Enabled = False
        Me.cmbZonaGeografica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbZonaGeografica.FormattingEnabled = True
        Me.cmbZonaGeografica.IsPK = False
        Me.cmbZonaGeografica.IsRequired = False
        Me.cmbZonaGeografica.Key = Nothing
        Me.cmbZonaGeografica.LabelAsoc = Nothing
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(465, 79)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(97, 21)
        Me.cmbZonaGeografica.TabIndex = 23
        '
        'chbCobrador
        '
        Me.chbCobrador.AutoSize = True
        Me.chbCobrador.BindearPropiedadControl = Nothing
        Me.chbCobrador.BindearPropiedadEntidad = Nothing
        Me.chbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCobrador.IsPK = False
        Me.chbCobrador.IsRequired = False
        Me.chbCobrador.Key = Nothing
        Me.chbCobrador.LabelAsoc = Nothing
        Me.chbCobrador.Location = New System.Drawing.Point(8, 111)
        Me.chbCobrador.Name = "chbCobrador"
        Me.chbCobrador.Size = New System.Drawing.Size(69, 17)
        Me.chbCobrador.TabIndex = 25
        Me.chbCobrador.Text = "Cobrador"
        Me.chbCobrador.UseVisualStyleBackColor = True
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
        Me.chbVendedor.Location = New System.Drawing.Point(8, 81)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 19
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbCobrador
        '
        Me.cmbCobrador.BindearPropiedadControl = Nothing
        Me.cmbCobrador.BindearPropiedadEntidad = Nothing
        Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCobrador.Enabled = False
        Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCobrador.FormattingEnabled = True
        Me.cmbCobrador.IsPK = False
        Me.cmbCobrador.IsRequired = False
        Me.cmbCobrador.Key = Nothing
        Me.cmbCobrador.LabelAsoc = Nothing
        Me.cmbCobrador.Location = New System.Drawing.Point(87, 109)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.Size = New System.Drawing.Size(122, 21)
        Me.cmbCobrador.TabIndex = 26
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
        Me.cmbVendedor.Location = New System.Drawing.Point(87, 79)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(122, 21)
        Me.cmbVendedor.TabIndex = 20
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
        Me.chbFecha.Location = New System.Drawing.Point(8, 53)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(78, 17)
        Me.chbFecha.TabIndex = 10
        Me.chbFecha.Text = "Fecha Vto."
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(262, 50)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(97, 20)
        Me.dtpHasta.TabIndex = 14
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(225, 54)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 13
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(122, 50)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(97, 20)
        Me.dtpDesde.TabIndex = 12
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(82, 54)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 11
        Me.lblDesde.Text = "Desde"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Enabled = False
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(118, 208)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(122, 21)
        Me.cmbTiposComprobantes.TabIndex = 33
        '
        'btnConsultar
        '
        Me.btnConsultar.AccessibleRole = System.Windows.Forms.AccessibleRole.Indicator
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(911, 81)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 52
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.BindearPropiedadControl = Nothing
        Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobante.IsPK = False
        Me.chbTipoComprobante.IsRequired = False
        Me.chbTipoComprobante.Key = Nothing
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(8, 210)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 32
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'chbZonaGeografica
        '
        Me.chbZonaGeografica.AutoSize = True
        Me.chbZonaGeografica.BindearPropiedadControl = Nothing
        Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbZonaGeografica.IsPK = False
        Me.chbZonaGeografica.IsRequired = False
        Me.chbZonaGeografica.Key = Nothing
        Me.chbZonaGeografica.LabelAsoc = Nothing
        Me.chbZonaGeografica.Location = New System.Drawing.Point(353, 81)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
        Me.chbZonaGeografica.TabIndex = 22
        Me.chbZonaGeografica.Text = "Zona Geográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
        '
        'InfCtaCteDetalleClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 561)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.KeyPreview = True
        Me.Name = "InfCtaCteDetalleClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Cta. Cte. Detallada de Clientes"
        Me.TopMost = True
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.grbEmbarcacionCama.ResumeLayout(False)
        Me.grbEmbarcacionCama.PerformLayout()
        Me.grbVencimiento.ResumeLayout(False)
        Me.grbVencimiento.PerformLayout()
        Me.grbSaldo.ResumeLayout(False)
        Me.grbSaldo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents grbVencimiento As System.Windows.Forms.GroupBox
   Friend WithEvents optVencVencidos As Eniac.Controles.RadioButton
   Friend WithEvents optVencTodos As Eniac.Controles.RadioButton
   Friend WithEvents grbSaldo As System.Windows.Forms.GroupBox
   Friend WithEvents optTodos As Eniac.Controles.RadioButton
   Friend WithEvents optConSaldo As Eniac.Controles.RadioButton
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbExcluirAnticipos As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirSaldosNegativos As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluirPreComprobantes As Eniac.Controles.CheckBox
   Friend WithEvents chbProvincia As Eniac.Controles.CheckBox
   Public WithEvents cmbProvincia As Eniac.Controles.ComboBox
    Friend WithEvents chbExcluirMinutas As Eniac.Controles.CheckBox
    Friend WithEvents lblImpresion As Eniac.Controles.Label
    Friend WithEvents rbtImpresion1PorHoja As Eniac.Controles.RadioButton
    Friend WithEvents rbtImpresionNormal As Eniac.Controles.RadioButton
    Friend WithEvents tsbImprimir2 As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSucursal As Eniac.Controles.Label
    Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
    Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
    Friend WithEvents chbCobrador As Eniac.Controles.CheckBox
    Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
    Friend WithEvents cmbOrigenCobrador As Eniac.Controles.ComboBox
    Friend WithEvents chbFechaInteres As Eniac.Controles.CheckBox
    Friend WithEvents dtpFechaInteres As Eniac.Controles.DateTimePicker
    Friend WithEvents cmbMoneda As Eniac.Controles.ComboBox
    Friend WithEvents lblMoneda As Eniac.Controles.Label
    Friend WithEvents txtCotizacionDolar As Eniac.Controles.TextBox
    Friend WithEvents lblCotizacionDolar As Eniac.Controles.Label
    Friend WithEvents cmbTipoConversion As Eniac.Controles.ComboBox
    Friend WithEvents chbGrupoCategoria As Eniac.Controles.CheckBox
    Friend WithEvents cmbGrupoCategoria As Eniac.Controles.ComboBox
    Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
    Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
    Friend WithEvents lblGrupoComprobante As Eniac.Controles.Label
    Friend WithEvents cmbGrupos As Eniac.Win.ComboBoxGrupoTiposComprobantes
    Friend WithEvents cmbTipoVendedor As Controles.ComboBox
    Friend WithEvents cmbTipoCategoria As Controles.ComboBox
    Friend WithEvents cmbTipoCliente As Controles.ComboBox
    Friend WithEvents lblCliente As Controles.Label
    Friend WithEvents chbEmbarcacionCama As Controles.CheckBox
    Friend WithEvents bscCodigoEmbarcacionCama As Controles.Buscador2
    Friend WithEvents bscNombreEmbarcacion As Controles.Buscador2
    Friend WithEvents grbEmbarcacionCama As Panel
    Friend WithEvents chbMostrarDetalleProducto As Controles.CheckBox
   Friend WithEvents bscCodigoLocalidad As Controles.Buscador2
   Friend WithEvents bscNombreLocalidad As Controles.Buscador2
   Friend WithEvents chbLocalidad As Controles.CheckBox
    Friend WithEvents chbAgruparIdClienteCtaCte As CheckBox
    Friend WithEvents UltraDataSource3 As UltraWinDataSource.UltraDataSource
End Class
