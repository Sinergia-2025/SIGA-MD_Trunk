<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarRepartos
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarRepartos))
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocVendedor")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocVendedor")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuentaCorriente")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioNueva")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportistaNuevo")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportistaNuevo")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
      Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "ImporteTotal", 18, True, "Pedidos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
      Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
      Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
      Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
      Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
      Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
      Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
      Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
      Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Productos", -1)
      Dim UltraGridColumn191 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn192 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn193 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn194 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn195 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn196 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn197 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn198 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn199 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
      Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn200 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
      Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn201 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn202 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
      Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn203 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
      Dim UltraGridColumn204 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
      Dim UltraGridColumn205 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
      Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn206 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
      Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
      Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
      Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
      Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
      Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
      Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "ImporteTotal", 10, True, "Productos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
      Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, "", "Cantidad", 8, True, "Productos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
      Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.tsbListadoClientes = New System.Windows.Forms.ToolStripButton()
      Me.tsbConsolidadoCarga = New System.Windows.Forms.ToolStripButton()
      Me.tsbConsolidadoCargaTipoOperacion = New System.Windows.Forms.ToolStripButton()
      Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tss3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbTransportista = New Eniac.Controles.CheckBox()
      Me.bscTransportista = New Eniac.Controles.Buscador()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.chbVendedor = New Eniac.Controles.CheckBox()
      Me.cmbVendedor = New Eniac.Controles.ComboBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.tbpReparto = New System.Windows.Forms.TabPage()
      Me.tbpComprobantes = New System.Windows.Forms.TabPage()
      Me.ugComprobantes = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.PedidosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DtsRegistracionPagos = New Eniac.Win.dtsRegistracionPagos()
      Me.tbpProductos = New System.Windows.Forms.TabPage()
      Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.PedidosProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.grbFiltros.SuspendLayout()
      Me.tbcDetalle.SuspendLayout()
      Me.tbpReparto.SuspendLayout()
      Me.tbpComprobantes.SuspendLayout()
      CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PedidosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DtsRegistracionPagos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpProductos.SuspendLayout()
      CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PedidosProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'UltraDataSource1
      '
      Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
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
      'ugDetalle
      '
      Appearance2.BackColor = System.Drawing.SystemColors.Window
      Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance2
      Me.ugDetalle.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance3.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance3
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance5.BackColor2 = System.Drawing.SystemColors.Control
      Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance6.BackColor = System.Drawing.SystemColors.Window
      Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance6
      Appearance7.BackColor = System.Drawing.SystemColors.Highlight
      Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance8.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance8
      Appearance9.BorderColor = System.Drawing.Color.Silver
      Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance10.BackColor = System.Drawing.SystemColors.Control
      Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance10.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance10
      Appearance11.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(942, 356)
      Me.ugDetalle.TabIndex = 1
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(984, 22)
      Me.stsStado.TabIndex = 3
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
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbImprimir, Me.tsbListadoClientes, Me.tsbConsolidadoCarga, Me.tsbConsolidadoCargaTipoOperacion, Me.tss2, Me.tsddExportar, Me.tss3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 2
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
      'tss1
      '
      Me.tss1.Name = "tss1"
      Me.tss1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImprimir
      '
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      Me.tsbImprimir.ToolTipText = "Imprimir"
      '
      'tsbListadoClientes
      '
      Me.tsbListadoClientes.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbListadoClientes.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbListadoClientes.Name = "tsbListadoClientes"
      Me.tsbListadoClientes.Size = New System.Drawing.Size(132, 26)
      Me.tsbListadoClientes.Text = "&Listado de Clientes"
      '
      'tsbConsolidadoCarga
      '
      Me.tsbConsolidadoCarga.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbConsolidadoCarga.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbConsolidadoCarga.Name = "tsbConsolidadoCarga"
      Me.tsbConsolidadoCarga.Size = New System.Drawing.Size(134, 26)
      Me.tsbConsolidadoCarga.Text = "&Consolidado Carga"
      '
      'tsbConsolidadoCargaTipoOperacion
      '
      Me.tsbConsolidadoCargaTipoOperacion.Image = Global.Eniac.Win.My.Resources.Resources.printer
      Me.tsbConsolidadoCargaTipoOperacion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbConsolidadoCargaTipoOperacion.Name = "tsbConsolidadoCargaTipoOperacion"
      Me.tsbConsolidadoCargaTipoOperacion.Size = New System.Drawing.Size(214, 26)
      Me.tsbConsolidadoCargaTipoOperacion.Text = "Consolidado Carga por Tipo &Oper."
      '
      'tss2
      '
      Me.tss2.Name = "tss2"
      Me.tss2.Size = New System.Drawing.Size(6, 29)
      '
      'tsddExportar
      '
      Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
      Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
      Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsddExportar.Name = "tsddExportar"
      Me.tsddExportar.Size = New System.Drawing.Size(63, 26)
      Me.tsddExportar.Text = "Exportar"
      '
      'tsmiAExcel
      '
      Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
      Me.tsmiAExcel.Name = "tsmiAExcel"
      Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAExcel.Text = "a Excel"
      '
      'tsmiAPDF
      '
      Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
      Me.tsmiAPDF.Name = "tsmiAPDF"
      Me.tsmiAPDF.Size = New System.Drawing.Size(109, 22)
      Me.tsmiAPDF.Text = "a PDF"
      '
      'tss3
      '
      Me.tss3.Name = "tss3"
      Me.tss3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'grbFiltros
      '
      Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFiltros.Controls.Add(Me.chbTransportista)
      Me.grbFiltros.Controls.Add(Me.bscTransportista)
      Me.grbFiltros.Controls.Add(Me.chbNumero)
      Me.grbFiltros.Controls.Add(Me.txtNumero)
      Me.grbFiltros.Controls.Add(Me.chbUsuario)
      Me.grbFiltros.Controls.Add(Me.cmbUsuario)
      Me.grbFiltros.Controls.Add(Me.chbVendedor)
      Me.grbFiltros.Controls.Add(Me.cmbVendedor)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grbFiltros.Controls.Add(Me.dtpHasta)
      Me.grbFiltros.Controls.Add(Me.dtpDesde)
      Me.grbFiltros.Controls.Add(Me.lblHasta)
      Me.grbFiltros.Controls.Add(Me.lblDesde)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(956, 104)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'chbTransportista
      '
      Me.chbTransportista.AutoSize = True
      Me.chbTransportista.BindearPropiedadControl = Nothing
      Me.chbTransportista.BindearPropiedadEntidad = Nothing
      Me.chbTransportista.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTransportista.IsPK = False
      Me.chbTransportista.IsRequired = False
      Me.chbTransportista.Key = Nothing
      Me.chbTransportista.LabelAsoc = Nothing
      Me.chbTransportista.Location = New System.Drawing.Point(13, 50)
      Me.chbTransportista.Name = "chbTransportista"
      Me.chbTransportista.Size = New System.Drawing.Size(87, 17)
      Me.chbTransportista.TabIndex = 7
      Me.chbTransportista.Text = "Transportista"
      Me.chbTransportista.UseVisualStyleBackColor = True
      '
      'bscTransportista
      '
      Me.bscTransportista.AutoSize = True
      Me.bscTransportista.AyudaAncho = 140
      Me.bscTransportista.BindearPropiedadControl = Nothing
      Me.bscTransportista.BindearPropiedadEntidad = Nothing
      Me.bscTransportista.ColumnasAlineacion = Nothing
      Me.bscTransportista.ColumnasAncho = Nothing
      Me.bscTransportista.ColumnasFormato = Nothing
      Me.bscTransportista.ColumnasOcultas = Nothing
      Me.bscTransportista.ColumnasTitulos = Nothing
      Me.bscTransportista.Datos = Nothing
      Me.bscTransportista.Enabled = False
      Me.bscTransportista.FilaDevuelta = Nothing
      Me.bscTransportista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscTransportista.ForeColorFocus = System.Drawing.Color.Red
      Me.bscTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscTransportista.IsDecimal = False
      Me.bscTransportista.IsNumber = False
      Me.bscTransportista.IsPK = False
      Me.bscTransportista.IsRequired = False
      Me.bscTransportista.Key = ""
      Me.bscTransportista.LabelAsoc = Nothing
      Me.bscTransportista.Location = New System.Drawing.Point(110, 47)
      Me.bscTransportista.Margin = New System.Windows.Forms.Padding(4)
      Me.bscTransportista.MaxLengh = "32767"
      Me.bscTransportista.Name = "bscTransportista"
      Me.bscTransportista.Permitido = True
      Me.bscTransportista.Selecciono = False
      Me.bscTransportista.Size = New System.Drawing.Size(240, 23)
      Me.bscTransportista.TabIndex = 8
      Me.bscTransportista.Titulo = Nothing
      '
      'chbNumero
      '
      Me.chbNumero.AutoSize = True
      Me.chbNumero.BindearPropiedadControl = Nothing
      Me.chbNumero.BindearPropiedadEntidad = Nothing
      Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumero.IsPK = False
      Me.chbNumero.IsRequired = False
      Me.chbNumero.Key = Nothing
      Me.chbNumero.LabelAsoc = Nothing
      Me.chbNumero.Location = New System.Drawing.Point(469, 22)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(104, 17)
      Me.chbNumero.TabIndex = 5
      Me.chbNumero.Text = "Numero Reparto"
      Me.chbNumero.UseVisualStyleBackColor = True
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.Enabled = False
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = "##0"
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Nothing
      Me.txtNumero.Location = New System.Drawing.Point(587, 20)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(73, 20)
      Me.txtNumero.TabIndex = 6
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
      Me.chbUsuario.Location = New System.Drawing.Point(286, 75)
      Me.chbUsuario.Name = "chbUsuario"
      Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
      Me.chbUsuario.TabIndex = 11
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
      Me.cmbUsuario.Location = New System.Drawing.Point(360, 73)
      Me.cmbUsuario.Name = "cmbUsuario"
      Me.cmbUsuario.Size = New System.Drawing.Size(115, 21)
      Me.cmbUsuario.TabIndex = 12
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
      Me.chbVendedor.Location = New System.Drawing.Point(13, 75)
      Me.chbVendedor.Name = "chbVendedor"
      Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
      Me.chbVendedor.TabIndex = 9
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
      Me.cmbVendedor.Location = New System.Drawing.Point(110, 73)
      Me.cmbVendedor.Name = "cmbVendedor"
      Me.cmbVendedor.Size = New System.Drawing.Size(129, 21)
      Me.cmbVendedor.TabIndex = 10
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(846, 52)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(102, 45)
      Me.btnConsultar.TabIndex = 13
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(13, 22)
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
      Me.dtpHasta.Location = New System.Drawing.Point(310, 20)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpHasta.TabIndex = 4
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(273, 24)
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
      Me.dtpDesde.Location = New System.Drawing.Point(144, 20)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesde.TabIndex = 2
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(105, 24)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 1
      Me.lblDesde.Text = "Desde"
      '
      'tbcDetalle
      '
      Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tbcDetalle.Controls.Add(Me.tbpReparto)
      Me.tbcDetalle.Controls.Add(Me.tbpComprobantes)
      Me.tbcDetalle.Controls.Add(Me.tbpProductos)
      Me.tbcDetalle.Location = New System.Drawing.Point(12, 148)
      Me.tbcDetalle.Name = "tbcDetalle"
      Me.tbcDetalle.SelectedIndex = 0
      Me.tbcDetalle.Size = New System.Drawing.Size(956, 388)
      Me.tbcDetalle.TabIndex = 4
      '
      'tbpReparto
      '
      Me.tbpReparto.Controls.Add(Me.ugDetalle)
      Me.tbpReparto.Location = New System.Drawing.Point(4, 22)
      Me.tbpReparto.Name = "tbpReparto"
      Me.tbpReparto.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpReparto.Size = New System.Drawing.Size(948, 362)
      Me.tbpReparto.TabIndex = 0
      Me.tbpReparto.Text = "Repartos"
      Me.tbpReparto.UseVisualStyleBackColor = True
      '
      'tbpComprobantes
      '
      Me.tbpComprobantes.Controls.Add(Me.ugComprobantes)
      Me.tbpComprobantes.Location = New System.Drawing.Point(4, 22)
      Me.tbpComprobantes.Name = "tbpComprobantes"
      Me.tbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpComprobantes.Size = New System.Drawing.Size(948, 362)
      Me.tbpComprobantes.TabIndex = 1
      Me.tbpComprobantes.Text = "Comprobantes"
      Me.tbpComprobantes.UseVisualStyleBackColor = True
      '
      'ugComprobantes
      '
      Me.ugComprobantes.DataSource = Me.PedidosBindingSource
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance14
      UltraGridColumn1.Header.VisiblePosition = 14
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Tipo"
      UltraGridColumn2.Header.VisiblePosition = 6
      UltraGridColumn2.Width = 90
      UltraGridColumn3.Header.Caption = "L"
      UltraGridColumn3.Header.VisiblePosition = 7
      UltraGridColumn3.Width = 25
      Appearance15.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance15
      UltraGridColumn4.Header.VisiblePosition = 15
      UltraGridColumn4.Hidden = True
      Appearance16.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance16
      UltraGridColumn5.Header.Caption = "Nro."
      UltraGridColumn5.Header.VisiblePosition = 8
      UltraGridColumn5.Width = 40
      Appearance17.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance17
      UltraGridColumn6.Header.VisiblePosition = 16
      UltraGridColumn6.Hidden = True
      Appearance18.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance18
      UltraGridColumn7.Header.Caption = "Código"
      UltraGridColumn7.Header.VisiblePosition = 2
      UltraGridColumn7.Width = 50
      UltraGridColumn8.Header.VisiblePosition = 17
      UltraGridColumn8.Hidden = True
      Appearance19.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance19
      UltraGridColumn9.Header.VisiblePosition = 18
      UltraGridColumn9.Hidden = True
      UltraGridColumn10.Header.Caption = "Cliente"
      UltraGridColumn10.Header.VisiblePosition = 3
      UltraGridColumn10.Width = 130
      UltraGridColumn11.Header.VisiblePosition = 4
      UltraGridColumn11.Width = 110
      UltraGridColumn12.Header.Caption = "Resp. Distribución"
      UltraGridColumn12.Header.VisiblePosition = 11
      UltraGridColumn12.Width = 105
      Appearance20.TextHAlignAsString = "Right"
      UltraGridColumn13.CellAppearance = Appearance20
      UltraGridColumn13.Header.VisiblePosition = 19
      UltraGridColumn13.Hidden = True
      UltraGridColumn14.Header.Caption = "Vendedor"
      UltraGridColumn14.Header.VisiblePosition = 13
      UltraGridColumn14.Width = 100
      UltraGridColumn15.Header.VisiblePosition = 20
      UltraGridColumn15.Hidden = True
      Appearance21.TextHAlignAsString = "Right"
      UltraGridColumn16.CellAppearance = Appearance21
      UltraGridColumn16.Header.VisiblePosition = 21
      UltraGridColumn16.Hidden = True
      UltraGridColumn17.Header.Caption = "F. Pedido"
      UltraGridColumn17.Header.VisiblePosition = 12
      UltraGridColumn17.Width = 64
      UltraGridColumn18.Header.Caption = "F. Envio"
      UltraGridColumn18.Header.VisiblePosition = 10
      UltraGridColumn18.Width = 64
      Appearance22.TextHAlignAsString = "Right"
      UltraGridColumn19.CellAppearance = Appearance22
      UltraGridColumn19.Format = "N2"
      UltraGridColumn19.Header.Caption = "Total"
      UltraGridColumn19.Header.VisiblePosition = 5
      UltraGridColumn19.MaskInput = "{double:-12.2}"
      UltraGridColumn19.Width = 70
      Appearance23.TextHAlignAsString = "Right"
      UltraGridColumn20.CellAppearance = Appearance23
      UltraGridColumn20.Header.VisiblePosition = 22
      UltraGridColumn20.Hidden = True
      Appearance24.TextHAlignAsString = "Right"
      UltraGridColumn21.CellAppearance = Appearance24
      UltraGridColumn21.Header.Caption = "Reparto"
      UltraGridColumn21.Header.VisiblePosition = 9
      UltraGridColumn22.Header.VisiblePosition = 23
      UltraGridColumn22.Hidden = True
      UltraGridColumn22.Width = 64
      UltraGridColumn23.Header.Caption = "F.P. Cliente"
      UltraGridColumn23.Header.VisiblePosition = 1
      UltraGridColumn23.Width = 69
      Appearance25.TextHAlignAsString = "Right"
      UltraGridColumn24.CellAppearance = Appearance25
      UltraGridColumn24.Header.VisiblePosition = 24
      UltraGridColumn24.Hidden = True
      UltraGridColumn25.Header.VisiblePosition = 25
      UltraGridColumn25.Hidden = True
      UltraGridColumn26.Header.Caption = "Forma Pago"
      UltraGridColumn26.Header.VisiblePosition = 0
      UltraGridColumn26.Hidden = True
      UltraGridColumn27.Header.VisiblePosition = 26
      UltraGridColumn27.Hidden = True
      UltraGridColumn28.Header.VisiblePosition = 27
      UltraGridColumn28.Hidden = True
      UltraGridColumn29.Header.VisiblePosition = 28
      UltraGridColumn29.Hidden = True
      UltraGridColumn30.Header.VisiblePosition = 29
      UltraGridColumn30.Hidden = True
      UltraGridColumn31.Header.VisiblePosition = 30
      UltraGridColumn31.Hidden = True
      UltraGridColumn32.Header.VisiblePosition = 31
      UltraGridColumn32.Hidden = True
      UltraGridColumn33.Header.VisiblePosition = 32
      UltraGridColumn33.Hidden = True
      UltraGridColumn34.Header.VisiblePosition = 33
      UltraGridColumn34.Hidden = True
      UltraGridColumn35.Header.VisiblePosition = 34
      UltraGridColumn36.Header.VisiblePosition = 35
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36})
      SummarySettings1.DisplayFormat = "{0:N2}"
      SummarySettings1.GroupBySummaryValueAppearance = Appearance26
      SummarySettings1.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
      UltraGridBand1.SummaryFooterCaption = "Total Pedidos:"
      Appearance27.TextHAlignAsString = "Right"
      UltraGridColumn37.CellAppearance = Appearance27
      UltraGridColumn37.Header.VisiblePosition = 0
      UltraGridColumn37.Hidden = True
      UltraGridColumn37.Width = 56
      UltraGridColumn38.Header.VisiblePosition = 1
      UltraGridColumn38.Hidden = True
      UltraGridColumn38.Width = 69
      UltraGridColumn39.Header.VisiblePosition = 2
      UltraGridColumn39.Hidden = True
      UltraGridColumn39.Width = 50
      Appearance28.TextHAlignAsString = "Right"
      UltraGridColumn40.CellAppearance = Appearance28
      UltraGridColumn40.Header.VisiblePosition = 3
      UltraGridColumn40.Hidden = True
      UltraGridColumn40.Width = 130
      Appearance29.TextHAlignAsString = "Right"
      UltraGridColumn41.CellAppearance = Appearance29
      UltraGridColumn41.Header.VisiblePosition = 4
      UltraGridColumn41.Hidden = True
      UltraGridColumn41.Width = 110
      Appearance30.TextHAlignAsString = "Right"
      UltraGridColumn42.CellAppearance = Appearance30
      UltraGridColumn42.Header.Caption = "Código"
      UltraGridColumn42.Header.VisiblePosition = 6
      UltraGridColumn42.MaxWidth = 80
      UltraGridColumn42.Width = 80
      Appearance31.TextHAlignAsString = "Right"
      UltraGridColumn43.CellAppearance = Appearance31
      UltraGridColumn43.Header.VisiblePosition = 5
      UltraGridColumn43.MaxWidth = 50
      UltraGridColumn43.MinWidth = 50
      UltraGridColumn43.Width = 50
      UltraGridColumn44.Header.Caption = "Producto"
      UltraGridColumn44.Header.VisiblePosition = 7
      UltraGridColumn44.Width = 377
      Appearance32.TextHAlignAsString = "Right"
      UltraGridColumn45.CellAppearance = Appearance32
      UltraGridColumn45.Format = "N2"
      UltraGridColumn45.Header.VisiblePosition = 8
      UltraGridColumn45.MaskInput = "{double:-12.2}"
      UltraGridColumn45.MaxWidth = 60
      UltraGridColumn45.MinWidth = 60
      UltraGridColumn45.Width = 60
      Appearance33.TextHAlignAsString = "Right"
      UltraGridColumn46.CellAppearance = Appearance33
      UltraGridColumn46.Format = "N2"
      UltraGridColumn46.Header.VisiblePosition = 9
      UltraGridColumn46.Hidden = True
      UltraGridColumn46.MaskInput = "{double:-12.2}"
      UltraGridColumn46.MaxWidth = 60
      UltraGridColumn46.MinWidth = 60
      Appearance34.TextHAlignAsString = "Right"
      UltraGridColumn47.CellAppearance = Appearance34
      UltraGridColumn47.Format = "N2"
      UltraGridColumn47.Header.Caption = "Total"
      UltraGridColumn47.Header.VisiblePosition = 10
      UltraGridColumn47.MaskInput = "{double:-12.2}"
      UltraGridColumn47.MaxWidth = 60
      UltraGridColumn47.MinWidth = 60
      UltraGridColumn47.Width = 60
      Appearance35.TextHAlignAsString = "Right"
      UltraGridColumn48.CellAppearance = Appearance35
      UltraGridColumn48.Format = "N2"
      UltraGridColumn48.Header.VisiblePosition = 11
      UltraGridColumn48.Hidden = True
      UltraGridColumn48.MaskInput = "{double:-12.2}"
      UltraGridColumn48.MaxWidth = 60
      UltraGridColumn48.MinWidth = 60
      UltraGridColumn48.Width = 60
      UltraGridColumn49.Header.VisiblePosition = 12
      UltraGridColumn49.Hidden = True
      UltraGridColumn49.MaxWidth = 50
      UltraGridColumn50.Header.VisiblePosition = 13
      UltraGridColumn50.Hidden = True
      UltraGridColumn50.Width = 64
      Appearance36.TextHAlignAsString = "Right"
      UltraGridColumn51.CellAppearance = Appearance36
      UltraGridColumn51.Format = "N2"
      UltraGridColumn51.Header.VisiblePosition = 14
      UltraGridColumn51.Hidden = True
      UltraGridColumn51.MaskInput = "{double:-12.2}"
      UltraGridColumn51.MaxWidth = 60
      UltraGridColumn51.MinWidth = 60
      UltraGridColumn51.Width = 60
      UltraGridColumn52.Header.VisiblePosition = 15
      UltraGridColumn52.Hidden = True
      UltraGridColumn70.Header.VisiblePosition = 16
      UltraGridColumn71.Header.VisiblePosition = 17
      UltraGridColumn72.Header.VisiblePosition = 18
      UltraGridColumn73.Header.VisiblePosition = 19
      UltraGridColumn74.Header.VisiblePosition = 20
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74})
      UltraGridColumn53.Header.VisiblePosition = 0
      UltraGridColumn54.Header.VisiblePosition = 1
      UltraGridColumn55.Header.VisiblePosition = 2
      UltraGridColumn56.Header.VisiblePosition = 3
      UltraGridColumn57.Header.VisiblePosition = 4
      UltraGridColumn58.Header.VisiblePosition = 5
      UltraGridColumn59.Header.VisiblePosition = 6
      UltraGridColumn60.Header.VisiblePosition = 7
      UltraGridColumn61.Header.VisiblePosition = 8
      UltraGridColumn62.Header.VisiblePosition = 9
      UltraGridColumn63.Header.VisiblePosition = 10
      UltraGridColumn64.Header.VisiblePosition = 11
      UltraGridColumn65.Header.VisiblePosition = 12
      UltraGridColumn66.Header.VisiblePosition = 13
      UltraGridColumn67.Header.VisiblePosition = 14
      UltraGridColumn68.Header.VisiblePosition = 15
      UltraGridColumn69.Header.VisiblePosition = 16
      UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69})
      UltraGridBand3.Hidden = True
      Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
      Me.ugComprobantes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
      Me.ugComprobantes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance37.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance37.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance37.BorderColor = System.Drawing.SystemColors.Window
      Me.ugComprobantes.DisplayLayout.GroupByBox.Appearance = Appearance37
      Appearance38.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugComprobantes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance38
      Me.ugComprobantes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugComprobantes.DisplayLayout.GroupByBox.Hidden = True
      Me.ugComprobantes.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
      Appearance39.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance39.BackColor2 = System.Drawing.SystemColors.Control
      Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance39.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugComprobantes.DisplayLayout.GroupByBox.PromptAppearance = Appearance39
      Me.ugComprobantes.DisplayLayout.MaxColScrollRegions = 1
      Me.ugComprobantes.DisplayLayout.MaxRowScrollRegions = 1
      Appearance40.BackColor = System.Drawing.SystemColors.Window
      Appearance40.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugComprobantes.DisplayLayout.Override.ActiveCellAppearance = Appearance40
      Appearance41.BackColor = System.Drawing.SystemColors.Highlight
      Appearance41.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugComprobantes.DisplayLayout.Override.ActiveRowAppearance = Appearance41
      Me.ugComprobantes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugComprobantes.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
      Me.ugComprobantes.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
      Me.ugComprobantes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugComprobantes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugComprobantes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugComprobantes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance42.BackColor = System.Drawing.SystemColors.Window
      Me.ugComprobantes.DisplayLayout.Override.CardAreaAppearance = Appearance42
      Appearance43.BorderColor = System.Drawing.Color.Silver
      Appearance43.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugComprobantes.DisplayLayout.Override.CellAppearance = Appearance43
      Me.ugComprobantes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.ugComprobantes.DisplayLayout.Override.CellPadding = 0
      Appearance44.BackColor = System.Drawing.SystemColors.Control
      Appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance44.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance44.BorderColor = System.Drawing.SystemColors.Window
      Me.ugComprobantes.DisplayLayout.Override.GroupByRowAppearance = Appearance44
      Appearance45.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Appearance45.TextHAlignAsString = "Left"
      Me.ugComprobantes.DisplayLayout.Override.HeaderAppearance = Appearance45
      Me.ugComprobantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugComprobantes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance46.BackColor = System.Drawing.SystemColors.Window
      Appearance46.BorderColor = System.Drawing.Color.Silver
      Me.ugComprobantes.DisplayLayout.Override.RowAppearance = Appearance46
      Me.ugComprobantes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
      Me.ugComprobantes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugComprobantes.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
      Me.ugComprobantes.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugComprobantes.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugComprobantes.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
      Me.ugComprobantes.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance47.BackColor = System.Drawing.Color.White
      Appearance47.BackColor2 = System.Drawing.Color.White
      Appearance47.TextVAlignAsString = "Bottom"
      Me.ugComprobantes.DisplayLayout.Override.SummaryFooterAppearance = Appearance47
      Appearance48.BackColor = System.Drawing.Color.Tomato
      Appearance48.BackColor2 = System.Drawing.Color.Silver
      Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Me.ugComprobantes.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance48
      Appearance49.BackColor = System.Drawing.Color.Tomato
      Appearance49.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance49.TextHAlignAsString = "Right"
      Me.ugComprobantes.DisplayLayout.Override.SummaryValueAppearance = Appearance49
      Appearance50.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugComprobantes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance50
      Me.ugComprobantes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugComprobantes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugComprobantes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugComprobantes.Location = New System.Drawing.Point(3, 3)
      Me.ugComprobantes.Name = "ugComprobantes"
      Me.ugComprobantes.Size = New System.Drawing.Size(942, 356)
      Me.ugComprobantes.TabIndex = 0
      Me.ugComprobantes.Text = "UltraGrid1"
      '
      'PedidosBindingSource
      '
      Me.PedidosBindingSource.DataMember = "Pedidos"
      Me.PedidosBindingSource.DataSource = Me.DtsRegistracionPagos
      '
      'DtsRegistracionPagos
      '
      Me.DtsRegistracionPagos.DataSetName = "dtsRegistracionPagos"
      Me.DtsRegistracionPagos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'tbpProductos
      '
      Me.tbpProductos.Controls.Add(Me.UltraGrid1)
      Me.tbpProductos.Location = New System.Drawing.Point(4, 22)
      Me.tbpProductos.Name = "tbpProductos"
      Me.tbpProductos.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpProductos.Size = New System.Drawing.Size(948, 362)
      Me.tbpProductos.TabIndex = 2
      Me.tbpProductos.Text = "Productos"
      Me.tbpProductos.UseVisualStyleBackColor = True
      '
      'UltraGrid1
      '
      Me.UltraGrid1.DataSource = Me.PedidosProductosBindingSource
      Appearance51.BackColor = System.Drawing.SystemColors.Window
      Appearance51.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.UltraGrid1.DisplayLayout.Appearance = Appearance51
      Me.UltraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn191.Header.VisiblePosition = 6
      UltraGridColumn191.Hidden = True
      UltraGridColumn192.Header.Caption = "Tipo"
      UltraGridColumn192.Header.VisiblePosition = 7
      UltraGridColumn192.MaxWidth = 90
      UltraGridColumn193.Header.Caption = "L"
      UltraGridColumn193.Header.VisiblePosition = 8
      UltraGridColumn193.MaxWidth = 25
      Appearance52.TextHAlignAsString = "Right"
      UltraGridColumn194.CellAppearance = Appearance52
      UltraGridColumn194.Header.Caption = "Emisor"
      UltraGridColumn194.Header.VisiblePosition = 9
      UltraGridColumn194.MaxWidth = 50
      Appearance53.TextHAlignAsString = "Right"
      UltraGridColumn195.CellAppearance = Appearance53
      UltraGridColumn195.Header.Caption = "Nro."
      UltraGridColumn195.Header.VisiblePosition = 10
      UltraGridColumn195.MaxWidth = 60
      UltraGridColumn196.Header.Caption = "Código"
      UltraGridColumn196.Header.VisiblePosition = 0
      UltraGridColumn196.MaxWidth = 80
      Appearance54.TextHAlignAsString = "Right"
      UltraGridColumn197.CellAppearance = Appearance54
      UltraGridColumn197.Header.VisiblePosition = 11
      UltraGridColumn197.MaxWidth = 50
      UltraGridColumn197.MinWidth = 50
      UltraGridColumn198.Header.Caption = "Nombre"
      UltraGridColumn198.Header.VisiblePosition = 1
      UltraGridColumn198.Width = 317
      Appearance55.TextHAlignAsString = "Right"
      UltraGridColumn199.CellAppearance = Appearance55
      UltraGridColumn199.Format = "N2"
      UltraGridColumn199.Header.VisiblePosition = 2
      UltraGridColumn199.MaskInput = "{double:-9.2}"
      UltraGridColumn199.MaxWidth = 60
      UltraGridColumn199.MinWidth = 60
      Appearance56.TextHAlignAsString = "Right"
      UltraGridColumn200.CellAppearance = Appearance56
      UltraGridColumn200.Format = "N2"
      UltraGridColumn200.Header.VisiblePosition = 3
      UltraGridColumn200.MaskInput = "{double:-9.2}"
      UltraGridColumn200.MaxWidth = 60
      UltraGridColumn200.MinWidth = 60
      Appearance57.TextHAlignAsString = "Right"
      UltraGridColumn201.CellAppearance = Appearance57
      UltraGridColumn201.Format = "N2"
      UltraGridColumn201.Header.Caption = "Importe"
      UltraGridColumn201.Header.VisiblePosition = 5
      UltraGridColumn201.MaskInput = "{double:-9.2}"
      UltraGridColumn201.MaxWidth = 60
      UltraGridColumn201.MinWidth = 60
      Appearance58.TextHAlignAsString = "Right"
      UltraGridColumn202.CellAppearance = Appearance58
      UltraGridColumn202.Format = "N2"
      UltraGridColumn202.Header.VisiblePosition = 12
      UltraGridColumn202.Hidden = True
      UltraGridColumn202.MaskInput = "{double:-9.2}"
      UltraGridColumn202.MaxWidth = 60
      UltraGridColumn202.MinWidth = 60
      UltraGridColumn203.Header.VisiblePosition = 13
      UltraGridColumn203.Hidden = True
      UltraGridColumn204.Header.VisiblePosition = 14
      UltraGridColumn204.Hidden = True
      Appearance59.TextHAlignAsString = "Right"
      UltraGridColumn205.CellAppearance = Appearance59
      UltraGridColumn205.Format = "N2"
      UltraGridColumn205.Header.VisiblePosition = 15
      UltraGridColumn205.Hidden = True
      UltraGridColumn205.MaskInput = "{double:-9.2}"
      UltraGridColumn205.MaxWidth = 60
      UltraGridColumn205.MinWidth = 60
      Appearance60.TextHAlignAsString = "Right"
      UltraGridColumn206.CellAppearance = Appearance60
      UltraGridColumn206.Format = "N2"
      UltraGridColumn206.Header.Caption = "IVA"
      UltraGridColumn206.Header.VisiblePosition = 4
      UltraGridColumn206.MaskInput = "{double:-9.2}"
      UltraGridColumn206.MaxWidth = 60
      UltraGridColumn206.MinWidth = 60
      UltraGridColumn75.Header.VisiblePosition = 16
      UltraGridColumn76.Header.VisiblePosition = 17
      UltraGridColumn77.Header.VisiblePosition = 18
      UltraGridColumn78.Header.VisiblePosition = 19
      UltraGridColumn79.Header.VisiblePosition = 20
      UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn191, UltraGridColumn192, UltraGridColumn193, UltraGridColumn194, UltraGridColumn195, UltraGridColumn196, UltraGridColumn197, UltraGridColumn198, UltraGridColumn199, UltraGridColumn200, UltraGridColumn201, UltraGridColumn202, UltraGridColumn203, UltraGridColumn204, UltraGridColumn205, UltraGridColumn206, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79})
      Appearance61.TextHAlignAsString = "Right"
      SummarySettings2.Appearance = Appearance61
      SummarySettings2.DisplayFormat = "{0:N2}"
      SummarySettings2.GroupBySummaryValueAppearance = Appearance62
      SummarySettings2.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance63.TextHAlignAsString = "Right"
      SummarySettings3.Appearance = Appearance63
      SummarySettings3.DisplayFormat = "{0:N2}"
      SummarySettings3.GroupBySummaryValueAppearance = Appearance64
      SummarySettings3.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      UltraGridBand4.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings2, SummarySettings3})
      UltraGridBand4.SummaryFooterCaption = "Totales:"
      Me.UltraGrid1.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
      Me.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance65.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance65.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance65.BorderColor = System.Drawing.SystemColors.Window
      Me.UltraGrid1.DisplayLayout.GroupByBox.Appearance = Appearance65
      Appearance66.ForeColor = System.Drawing.SystemColors.GrayText
      Me.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance66
      Me.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance67.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance67.BackColor2 = System.Drawing.SystemColors.Control
      Appearance67.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance67.ForeColor = System.Drawing.SystemColors.GrayText
      Me.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance67
      Me.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1
      Me.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1
      Appearance68.BackColor = System.Drawing.SystemColors.Window
      Appearance68.ForeColor = System.Drawing.SystemColors.ControlText
      Me.UltraGrid1.DisplayLayout.Override.ActiveCellAppearance = Appearance68
      Appearance69.BackColor = System.Drawing.SystemColors.Highlight
      Appearance69.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.UltraGrid1.DisplayLayout.Override.ActiveRowAppearance = Appearance69
      Me.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance70.BackColor = System.Drawing.SystemColors.Window
      Me.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = Appearance70
      Appearance71.BorderColor = System.Drawing.Color.Silver
      Appearance71.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.UltraGrid1.DisplayLayout.Override.CellAppearance = Appearance71
      Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.UltraGrid1.DisplayLayout.Override.CellPadding = 0
      Appearance72.BackColor = System.Drawing.SystemColors.Control
      Appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance72.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance72.BorderColor = System.Drawing.SystemColors.Window
      Me.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = Appearance72
      Appearance73.TextHAlignAsString = "Left"
      Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance = Appearance73
      Me.UltraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance74.BackColor = System.Drawing.SystemColors.Window
      Appearance74.BorderColor = System.Drawing.Color.Silver
      Me.UltraGrid1.DisplayLayout.Override.RowAppearance = Appearance74
      Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance75.BackColor = System.Drawing.SystemColors.ControlLight
      Me.UltraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance75
      Me.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.UltraGrid1.Location = New System.Drawing.Point(3, 3)
      Me.UltraGrid1.Name = "UltraGrid1"
      Me.UltraGrid1.Size = New System.Drawing.Size(942, 356)
      Me.UltraGrid1.TabIndex = 0
      Me.UltraGrid1.Text = "UltraGrid1"
      '
      'PedidosProductosBindingSource
      '
      Me.PedidosProductosBindingSource.DataMember = "Productos"
      Me.PedidosProductosBindingSource.DataSource = Me.DtsRegistracionPagos
      '
      'ConsultarRepartos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Controls.Add(Me.tbcDetalle)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbFiltros)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ConsultarRepartos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consulta de Repartos"
      CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.tbcDetalle.ResumeLayout(False)
      Me.tbpReparto.ResumeLayout(False)
      Me.tbpComprobantes.ResumeLayout(False)
      CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PedidosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DtsRegistracionPagos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpProductos.ResumeLayout(False)
      CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PedidosProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Private WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Private WithEvents tss1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents tss2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbTransportista As Eniac.Controles.CheckBox
   Friend WithEvents bscTransportista As Eniac.Controles.Buscador
   Friend WithEvents tsbListadoClientes As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbConsolidadoCarga As System.Windows.Forms.ToolStripButton
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents tbpReparto As System.Windows.Forms.TabPage
   Friend WithEvents tbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents ugComprobantes As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents DtsRegistracionPagos As Eniac.Win.dtsRegistracionPagos
   Friend WithEvents PedidosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents tbpProductos As System.Windows.Forms.TabPage
   Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents PedidosProductosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents tsbConsolidadoCargaTipoOperacion As System.Windows.Forms.ToolStripButton
End Class
