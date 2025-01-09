<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrganizarEntregasV2
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
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PASA")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Palets")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PaletsMaximo")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KilosMaximo")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Reenvio")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Band 1")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Productos")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("D⁮ias")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SolicitaCUIT")
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota2deProducto")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("HorarioClienteCompleto")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionFormasPago", 0)
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("tipoCompCliente", 1)
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MuestraCuitDni", 2)
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
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("KilosMaximo")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Palets")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PaletsMaximo")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("ProductosSinStock", -1)
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSolicitada")
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadFaltante")
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductosSinStockDetalle")
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("ProductosSinStockDetalle", 0)
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadDividir")
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPRODUCTO")
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDPRODUCTOCOMPONENTE")
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NOMBREPRODUCTO")
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadNec")
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NECESITOX1")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadComp")
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ubicacion")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdenProducto")
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance80 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance81 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance82 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance83 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance84 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance85 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance86 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand7 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdReparto")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaReparto")
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
        Dim UltraGridBand8 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocVendedor")
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocVendedor")
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CategoriaFiscal")
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCheques")
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrganizarEntregasV2))
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.chkExpandAllPedidos = New Eniac.Controles.CheckBox()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevoPedido = New System.Windows.Forms.ToolStripButton()
        Me.tsbModificarPedido = New System.Windows.Forms.ToolStripButton()
        Me.tsbDividirPedido = New System.Windows.Forms.ToolStripButton()
        Me.tsbEliminarPedido = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbModificarRespDist = New System.Windows.Forms.ToolStripButton()
        Me.tsbModificarPalets = New System.Windows.Forms.ToolStripButton()
        Me.tsbCambiarFechaEnvio = New System.Windows.Forms.ToolStripButton()
        Me.tsbCambiarFPago = New System.Windows.Forms.ToolStripButton()
        Me.tsbCambiarComprobante = New System.Windows.Forms.ToolStripButton()
        Me.ugvDetallePedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.chkExpandAllRespDist = New Eniac.Controles.CheckBox()
        Me.ugvPedidosPorDistribucion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.chkExpandAll = New Eniac.Controles.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbRecalcularStock = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDividirPedidoPorFaltante = New System.Windows.Forms.ToolStripButton()
        Me.ugvArticulosSinStock = New Eniac.Win.UltraGridEditable()
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugvConsolidadoEsqueletos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugvConsolidado = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grpRepartos = New System.Windows.Forms.GroupBox()
        Me.ugRepartos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.gpbFacturas = New System.Windows.Forms.GroupBox()
        Me.ugvFacturas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.btnSolicitarCAE = New Eniac.Controles.Button()
        Me.btnImprimirFacturas = New Eniac.Controles.Button()
        Me.CheckBox3 = New Eniac.Controles.CheckBox()
        Me.btnFacturas = New Eniac.Controles.Button()
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.btnListadoClientesConEnvases = New Eniac.Controles.Button()
        Me.chkVend = New Eniac.Controles.CheckBox()
        Me.chkRD = New Eniac.Controles.CheckBox()
        Me.cboVendListados = New Eniac.Controles.ComboBox()
        Me.cboRespDistListado = New Eniac.Controles.ComboBox()
        Me.btnConsolidadoMercaderia = New Eniac.Controles.Button()
        Me.btnConsolidadoMercaderiaTipoOperacion = New Eniac.Controles.Button()
        Me.btnListadoClientes = New Eniac.Controles.Button()
        Me.chbArtSinStock = New Eniac.Controles.CheckBox()
        Me.chbProdDesc = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.txtProducto = New Eniac.Controles.TextBox()
        Me.chbRespDistribucion = New Eniac.Controles.CheckBox()
        Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.cmbRespDistribucion = New Eniac.Controles.ComboBox()
        Me.bscProducto = New Eniac.Controles.Buscador2()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.lblNumeroReparto = New System.Windows.Forms.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.utcPreventa = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.grbFecha = New System.Windows.Forms.GroupBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
        Me.chbOrdenProducto = New Eniac.Controles.CheckBox()
        Me.cmbOrdenProducto = New Eniac.Controles.ComboBox()
        Me.lblOrigen = New Eniac.Controles.Label()
        Me.cmbOrigen = New Eniac.Controles.ComboBox()
        Me.chbPendientes = New Eniac.Controles.CheckBox()
        Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaHasta = New Eniac.Controles.Label()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaDesde = New Eniac.Controles.Label()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.ProductoSinStockBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl3.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.ugvDetallePedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.ugvPedidosPorDistribucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ugvArticulosSinStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl5.SuspendLayout()
        CType(Me.ugvConsolidadoEsqueletos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugvConsolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        Me.grpRepartos.SuspendLayout()
        CType(Me.ugRepartos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.gpbFacturas.SuspendLayout()
        CType(Me.ugvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.UltraTabPageControl6.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.utcPreventa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utcPreventa.SuspendLayout()
        Me.grbFecha.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.ProductoSinStockBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.chkExpandAllPedidos)
        Me.UltraTabPageControl3.Controls.Add(Me.chbTodos)
        Me.UltraTabPageControl3.Controls.Add(Me.ToolStrip3)
        Me.UltraTabPageControl3.Controls.Add(Me.ugvDetallePedidos)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(1016, 350)
        '
        'chkExpandAllPedidos
        '
        Me.chkExpandAllPedidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkExpandAllPedidos.AutoSize = True
        Me.chkExpandAllPedidos.BindearPropiedadControl = Nothing
        Me.chkExpandAllPedidos.BindearPropiedadEntidad = Nothing
        Me.chkExpandAllPedidos.ForeColorFocus = System.Drawing.Color.Red
        Me.chkExpandAllPedidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkExpandAllPedidos.IsPK = False
        Me.chkExpandAllPedidos.IsRequired = False
        Me.chkExpandAllPedidos.Key = Nothing
        Me.chkExpandAllPedidos.LabelAsoc = Nothing
        Me.chkExpandAllPedidos.Location = New System.Drawing.Point(908, 33)
        Me.chkExpandAllPedidos.Name = "chkExpandAllPedidos"
        Me.chkExpandAllPedidos.Size = New System.Drawing.Size(104, 17)
        Me.chkExpandAllPedidos.TabIndex = 2
        Me.chkExpandAllPedidos.Text = "Expandir Grupos"
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
        Me.chbTodos.Location = New System.Drawing.Point(10, 30)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(122, 24)
        Me.chbTodos.TabIndex = 1
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AllowItemReorder = True
        Me.ToolStrip3.BackColor = System.Drawing.Color.Silver
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevoPedido, Me.tsbModificarPedido, Me.tsbDividirPedido, Me.tsbEliminarPedido, Me.ToolStripSeparator1, Me.tsbModificarRespDist, Me.tsbModificarPalets, Me.tsbCambiarFechaEnvio, Me.tsbCambiarFPago, Me.tsbCambiarComprobante})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(1016, 29)
        Me.ToolStrip3.TabIndex = 4
        Me.ToolStrip3.Text = "toolStrip1"
        '
        'tsbNuevoPedido
        '
        Me.tsbNuevoPedido.Image = Global.Eniac.Win.My.Resources.Resources.add_16
        Me.tsbNuevoPedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevoPedido.Name = "tsbNuevoPedido"
        Me.tsbNuevoPedido.Size = New System.Drawing.Size(108, 26)
        Me.tsbNuevoPedido.Text = "&Nuevo Pedido"
        '
        'tsbModificarPedido
        '
        Me.tsbModificarPedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbModificarPedido.Name = "tsbModificarPedido"
        Me.tsbModificarPedido.Size = New System.Drawing.Size(62, 26)
        Me.tsbModificarPedido.Text = "&Modificar"
        Me.tsbModificarPedido.ToolTipText = "Modificar Pedido"
        '
        'tsbDividirPedido
        '
        Me.tsbDividirPedido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDividirPedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDividirPedido.Name = "tsbDividirPedido"
        Me.tsbDividirPedido.Size = New System.Drawing.Size(45, 26)
        Me.tsbDividirPedido.Text = "Dividir"
        '
        'tsbEliminarPedido
        '
        Me.tsbEliminarPedido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEliminarPedido.Name = "tsbEliminarPedido"
        Me.tsbEliminarPedido.Size = New System.Drawing.Size(46, 26)
        Me.tsbEliminarPedido.Text = "&Anular"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbModificarRespDist
        '
        Me.tsbModificarRespDist.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbModificarRespDist.Name = "tsbModificarRespDist"
        Me.tsbModificarRespDist.Size = New System.Drawing.Size(154, 26)
        Me.tsbModificarRespDist.Text = "&Cambiar Resp. Distribución"
        '
        'tsbModificarPalets
        '
        Me.tsbModificarPalets.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbModificarPalets.Name = "tsbModificarPalets"
        Me.tsbModificarPalets.Size = New System.Drawing.Size(96, 26)
        Me.tsbModificarPalets.Text = "&Modificar Palets"
        '
        'tsbCambiarFechaEnvio
        '
        Me.tsbCambiarFechaEnvio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCambiarFechaEnvio.Name = "tsbCambiarFechaEnvio"
        Me.tsbCambiarFechaEnvio.Size = New System.Drawing.Size(122, 26)
        Me.tsbCambiarFechaEnvio.Text = "Cambiar &Fecha Envío"
        '
        'tsbCambiarFPago
        '
        Me.tsbCambiarFPago.Image = Global.Eniac.Win.My.Resources.Resources.money2
        Me.tsbCambiarFPago.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCambiarFPago.Name = "tsbCambiarFPago"
        Me.tsbCambiarFPago.Size = New System.Drawing.Size(145, 26)
        Me.tsbCambiarFPago.Text = "Cambiar Forma Pago"
        '
        'tsbCambiarComprobante
        '
        Me.tsbCambiarComprobante.Image = Global.Eniac.Win.My.Resources.Resources.note_edit
        Me.tsbCambiarComprobante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCambiarComprobante.Name = "tsbCambiarComprobante"
        Me.tsbCambiarComprobante.Size = New System.Drawing.Size(155, 26)
        Me.tsbCambiarComprobante.Text = "Cambiar Comprobante"
        '
        'ugvDetallePedidos
        '
        Me.ugvDetallePedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvDetallePedidos.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "Sel."
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn1.Width = 31
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.Header.Caption = "R. Distrib."
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 62
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.Header.Caption = "Vendedor"
        UltraGridColumn3.Header.VisiblePosition = 3
        UltraGridColumn3.Width = 60
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.Header.Caption = "Origen"
        UltraGridColumn4.Header.VisiblePosition = 14
        UltraGridColumn4.Width = 70
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.VisiblePosition = 13
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 39
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "# Ped."
        UltraGridColumn6.Header.VisiblePosition = 16
        UltraGridColumn6.Width = 64
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Format = "dd/MM/yyyy"
        UltraGridColumn7.Header.Caption = "F.Pedido"
        UltraGridColumn7.Header.VisiblePosition = 12
        UltraGridColumn7.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn7.Width = 65
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.Format = "dd/MM/yyyy"
        UltraGridColumn8.Header.Caption = "F.Envio"
        UltraGridColumn8.Header.VisiblePosition = 17
        UltraGridColumn8.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn8.Width = 65
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "Tipo Doc."
        UltraGridColumn9.Header.VisiblePosition = 23
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 58
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.Caption = "Nro. Doc."
        UltraGridColumn10.Header.VisiblePosition = 25
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 62
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.Caption = "Código"
        UltraGridColumn11.Header.VisiblePosition = 4
        UltraGridColumn11.Width = 48
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.Caption = "Cliente"
        UltraGridColumn12.Header.VisiblePosition = 5
        UltraGridColumn12.Width = 149
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.Caption = "Dirección"
        UltraGridColumn13.Header.VisiblePosition = 6
        UltraGridColumn13.Width = 147
        UltraGridColumn14.Format = "N0"
        UltraGridColumn14.Header.VisiblePosition = 9
        UltraGridColumn14.Width = 70
        UltraGridColumn15.Format = "N0"
        UltraGridColumn15.Header.VisiblePosition = 15
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 70
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance2
        UltraGridColumn16.Format = "N2"
        UltraGridColumn16.Header.VisiblePosition = 8
        UltraGridColumn16.Width = 70
        UltraGridColumn17.Format = "N0"
        UltraGridColumn17.Header.VisiblePosition = 18
        UltraGridColumn17.Hidden = True
        UltraGridColumn17.Width = 70
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance3
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.Caption = "Total"
        UltraGridColumn18.Header.VisiblePosition = 10
        UltraGridColumn18.Width = 70
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn19.Header.VisiblePosition = 26
        UltraGridColumn19.Hidden = True
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn20.Header.VisiblePosition = 27
        UltraGridColumn20.Hidden = True
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn21.Header.VisiblePosition = 21
        UltraGridColumn21.Hidden = True
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn22.Header.Caption = "Categ. Fiscal"
        UltraGridColumn22.Header.VisiblePosition = 20
        UltraGridColumn22.Width = 80
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn23.Header.VisiblePosition = 19
        UltraGridColumn23.Width = 359
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn24.Header.VisiblePosition = 29
        UltraGridColumn24.Hidden = True
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn25.Header.VisiblePosition = 28
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn26.Header.VisiblePosition = 30
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn27.Header.VisiblePosition = 35
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn28.Header.VisiblePosition = 34
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.Header.VisiblePosition = 31
        UltraGridColumn29.Hidden = True
        UltraGridColumn30.Header.VisiblePosition = 32
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.Header.Caption = "Localidad"
        UltraGridColumn31.Header.VisiblePosition = 7
        UltraGridColumn31.Width = 80
        UltraGridColumn32.Header.Caption = "Utiliza Alicuota 2 de Prod."
        UltraGridColumn32.Header.VisiblePosition = 24
        UltraGridColumn32.Width = 140
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn33.Header.Caption = "Horario Cliente"
        UltraGridColumn33.Header.VisiblePosition = 33
        UltraGridColumn33.Width = 268
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn34.Header.Caption = "F. Pago"
        UltraGridColumn34.Header.VisiblePosition = 1
        UltraGridColumn34.Width = 70
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn35.Header.Caption = "Comprob."
        UltraGridColumn35.Header.VisiblePosition = 11
        UltraGridColumn35.Width = 89
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.Caption = "CUIT / DNI"
        UltraGridColumn36.Header.VisiblePosition = 22
        UltraGridColumn36.Width = 98
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36})
        Me.ugvDetallePedidos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugvDetallePedidos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvDetallePedidos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.ugvDetallePedidos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvDetallePedidos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvDetallePedidos.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvDetallePedidos.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvDetallePedidos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvDetallePedidos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvDetallePedidos.DisplayLayout.Override.CellAppearance = Appearance10
        Me.ugvDetallePedidos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvDetallePedidos.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance12.TextHAlignAsString = "Left"
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.ugvDetallePedidos.DisplayLayout.Override.RowAppearance = Appearance13
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance14.BackColor = System.Drawing.Color.White
        Appearance14.BackColor2 = System.Drawing.Color.White
        Appearance14.TextVAlignAsString = "Bottom"
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryFooterAppearance = Appearance14
        Appearance15.BackColor = System.Drawing.Color.Tomato
        Appearance15.BackColor2 = System.Drawing.Color.Silver
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance15
        Appearance16.BackColor = System.Drawing.Color.Tomato
        Appearance16.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance16.TextHAlignAsString = "Right"
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryValueAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvDetallePedidos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
        Me.ugvDetallePedidos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvDetallePedidos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvDetallePedidos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvDetallePedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvDetallePedidos.Location = New System.Drawing.Point(6, 52)
        Me.ugvDetallePedidos.Name = "ugvDetallePedidos"
        Me.ugvDetallePedidos.Size = New System.Drawing.Size(1007, 295)
        Me.ugvDetallePedidos.TabIndex = 3
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.chkExpandAllRespDist)
        Me.UltraTabPageControl2.Controls.Add(Me.ugvPedidosPorDistribucion)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1016, 350)
        '
        'chkExpandAllRespDist
        '
        Me.chkExpandAllRespDist.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkExpandAllRespDist.AutoSize = True
        Me.chkExpandAllRespDist.BindearPropiedadControl = Nothing
        Me.chkExpandAllRespDist.BindearPropiedadEntidad = Nothing
        Me.chkExpandAllRespDist.ForeColorFocus = System.Drawing.Color.Red
        Me.chkExpandAllRespDist.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkExpandAllRespDist.IsPK = False
        Me.chkExpandAllRespDist.IsRequired = False
        Me.chkExpandAllRespDist.Key = Nothing
        Me.chkExpandAllRespDist.LabelAsoc = Nothing
        Me.chkExpandAllRespDist.Location = New System.Drawing.Point(895, 3)
        Me.chkExpandAllRespDist.Name = "chkExpandAllRespDist"
        Me.chkExpandAllRespDist.Size = New System.Drawing.Size(104, 17)
        Me.chkExpandAllRespDist.TabIndex = 59
        Me.chkExpandAllRespDist.Text = "Expandir Grupos"
        '
        'ugvPedidosPorDistribucion
        '
        Me.ugvPedidosPorDistribucion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvPedidosPorDistribucion.DisplayLayout.Appearance = Appearance18
        Me.ugvPedidosPorDistribucion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn37.Header.Caption = "Resp. Distribución"
        UltraGridColumn37.Header.VisiblePosition = 0
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn38.Header.Caption = "Vendedor"
        UltraGridColumn38.Header.VisiblePosition = 3
        UltraGridColumn38.Width = 128
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn39.Header.Caption = "Tipo"
        UltraGridColumn39.Header.VisiblePosition = 4
        UltraGridColumn39.Width = 31
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn40.Header.VisiblePosition = 5
        UltraGridColumn40.Width = 30
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn41.CellAppearance = Appearance19
        UltraGridColumn41.Header.Caption = "Nro."
        UltraGridColumn41.Header.VisiblePosition = 6
        UltraGridColumn41.Width = 52
        UltraGridColumn42.Format = "dd/MM/yyyy"
        UltraGridColumn42.Header.Caption = "Fecha Envio"
        UltraGridColumn42.Header.VisiblePosition = 2
        UltraGridColumn42.Hidden = True
        UltraGridColumn42.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn42.Width = 67
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn43.Header.Caption = "Tipo Doc."
        UltraGridColumn43.Header.VisiblePosition = 7
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.Width = 58
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance20
        UltraGridColumn44.Header.Caption = "Nro. Doc."
        UltraGridColumn44.Header.VisiblePosition = 8
        UltraGridColumn44.Hidden = True
        UltraGridColumn44.Width = 67
        UltraGridColumn45.Header.Caption = "Código"
        UltraGridColumn45.Header.VisiblePosition = 9
        UltraGridColumn45.Width = 41
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn46.Header.Caption = "Cliente"
        UltraGridColumn46.Header.VisiblePosition = 10
        UltraGridColumn46.Width = 212
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn47.Header.Caption = "Dirección"
        UltraGridColumn47.Header.VisiblePosition = 11
        UltraGridColumn47.Width = 122
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance21
        UltraGridColumn48.Format = "N2"
        UltraGridColumn48.Header.VisiblePosition = 12
        UltraGridColumn48.Width = 41
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn49.CellAppearance = Appearance22
        UltraGridColumn49.Format = "N2"
        UltraGridColumn49.Header.Caption = "Kilos Maximo"
        UltraGridColumn49.Header.VisiblePosition = 13
        UltraGridColumn49.Width = 41
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn50.CellAppearance = Appearance23
        UltraGridColumn50.Format = "N0"
        UltraGridColumn50.Header.VisiblePosition = 14
        UltraGridColumn50.Width = 41
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn51.CellAppearance = Appearance24
        UltraGridColumn51.Format = "N0"
        UltraGridColumn51.Header.Caption = "Palets Maximo"
        UltraGridColumn51.Header.VisiblePosition = 15
        UltraGridColumn51.Width = 41
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn52.CellAppearance = Appearance25
        UltraGridColumn52.Format = "N2"
        UltraGridColumn52.Header.Caption = "Total"
        UltraGridColumn52.Header.VisiblePosition = 16
        UltraGridColumn52.Width = 71
        Appearance26.TextHAlignAsString = "Center"
        UltraGridColumn53.CellAppearance = Appearance26
        UltraGridColumn53.Header.VisiblePosition = 17
        UltraGridColumn53.Hidden = True
        UltraGridColumn54.Header.VisiblePosition = 18
        UltraGridColumn54.Hidden = True
        Appearance27.TextHAlignAsString = "Center"
        UltraGridColumn55.CellAppearance = Appearance27
        UltraGridColumn55.Header.VisiblePosition = 1
        UltraGridColumn55.Hidden = True
        UltraGridColumn55.Width = 73
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55})
        Me.ugvPedidosPorDistribucion.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugvPedidosPorDistribucion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvPedidosPorDistribucion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance28.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvPedidosPorDistribucion.DisplayLayout.GroupByBox.Appearance = Appearance28
        Appearance29.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvPedidosPorDistribucion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance29
        Me.ugvPedidosPorDistribucion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvPedidosPorDistribucion.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvPedidosPorDistribucion.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance30.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance30.BackColor2 = System.Drawing.SystemColors.Control
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvPedidosPorDistribucion.DisplayLayout.GroupByBox.PromptAppearance = Appearance30
        Me.ugvPedidosPorDistribucion.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvPedidosPorDistribucion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Appearance31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.ActiveCellAppearance = Appearance31
        Appearance32.BackColor = System.Drawing.SystemColors.Highlight
        Appearance32.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.ActiveRowAppearance = Appearance32
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance33.BackColor = System.Drawing.SystemColors.Window
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.CardAreaAppearance = Appearance33
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Appearance34.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.CellAppearance = Appearance34
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.CellPadding = 0
        Appearance35.BackColor = System.Drawing.Color.Honeydew
        Appearance35.BackColor2 = System.Drawing.Color.Silver
        Appearance35.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance35.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.GroupByRowAppearance = Appearance35
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance36.TextHAlignAsString = "Right"
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.GroupBySummaryValueAppearance = Appearance36
        Appearance37.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance37.TextHAlignAsString = "Left"
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.Color.Silver
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.RowAppearance = Appearance38
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.SummaryDisplayArea = CType((((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.InGroupByRows) _
            Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter) _
            Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.HideDataRowFooters), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance39.BackColor = System.Drawing.Color.Tomato
        Appearance39.BackColor2 = System.Drawing.Color.Silver
        Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance39
        Appearance40.BackColor = System.Drawing.Color.Coral
        Appearance40.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance40.TextHAlignAsString = "Right"
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.SummaryValueAppearance = Appearance40
        Appearance41.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance41
        Me.ugvPedidosPorDistribucion.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvPedidosPorDistribucion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvPedidosPorDistribucion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvPedidosPorDistribucion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvPedidosPorDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvPedidosPorDistribucion.Location = New System.Drawing.Point(6, 3)
        Me.ugvPedidosPorDistribucion.Name = "ugvPedidosPorDistribucion"
        Me.ugvPedidosPorDistribucion.Size = New System.Drawing.Size(887, 344)
        Me.ugvPedidosPorDistribucion.TabIndex = 54
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.chkExpandAll)
        Me.UltraTabPageControl1.Controls.Add(Me.ToolStrip1)
        Me.UltraTabPageControl1.Controls.Add(Me.ugvArticulosSinStock)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1016, 350)
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkExpandAll.AutoSize = True
        Me.chkExpandAll.BindearPropiedadControl = Nothing
        Me.chkExpandAll.BindearPropiedadEntidad = Nothing
        Me.chkExpandAll.ForeColorFocus = System.Drawing.Color.Red
        Me.chkExpandAll.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkExpandAll.IsPK = False
        Me.chkExpandAll.IsRequired = False
        Me.chkExpandAll.Key = Nothing
        Me.chkExpandAll.LabelAsoc = Nothing
        Me.chkExpandAll.Location = New System.Drawing.Point(894, 42)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
        Me.chkExpandAll.TabIndex = 58
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowItemReorder = True
        Me.ToolStrip1.BackColor = System.Drawing.Color.Silver
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRecalcularStock, Me.ToolStripSeparator3, Me.tsbDividirPedidoPorFaltante})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1016, 29)
        Me.ToolStrip1.TabIndex = 54
        Me.ToolStrip1.Text = "toolStrip1"
        '
        'tsbRecalcularStock
        '
        Me.tsbRecalcularStock.Image = Global.Eniac.Win.My.Resources.Resources.houses
        Me.tsbRecalcularStock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRecalcularStock.Name = "tsbRecalcularStock"
        Me.tsbRecalcularStock.Size = New System.Drawing.Size(119, 26)
        Me.tsbRecalcularStock.Text = "&Recalcular Stock"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbDividirPedidoPorFaltante
        '
        Me.tsbDividirPedidoPorFaltante.Image = Global.Eniac.Win.My.Resources.Resources.exchange1
        Me.tsbDividirPedidoPorFaltante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDividirPedidoPorFaltante.Name = "tsbDividirPedidoPorFaltante"
        Me.tsbDividirPedidoPorFaltante.Size = New System.Drawing.Size(199, 26)
        Me.tsbDividirPedidoPorFaltante.Text = "Dividir pedidos por faltante (F9)"
        '
        'ugvArticulosSinStock
        '
        Me.ugvArticulosSinStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance42.BackColor = System.Drawing.SystemColors.Window
        Appearance42.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvArticulosSinStock.DisplayLayout.Appearance = Appearance42
        UltraGridColumn56.Header.Caption = "Código"
        UltraGridColumn56.Header.VisiblePosition = 0
        UltraGridColumn56.Width = 142
        UltraGridColumn57.Header.Caption = "Producto"
        UltraGridColumn57.Header.VisiblePosition = 1
        UltraGridColumn57.Width = 378
        Appearance43.TextHAlignAsString = "Right"
        UltraGridColumn58.CellAppearance = Appearance43
        UltraGridColumn58.Format = "N2"
        UltraGridColumn58.Header.VisiblePosition = 2
        UltraGridColumn58.Width = 109
        Appearance44.TextHAlignAsString = "Right"
        UltraGridColumn59.CellAppearance = Appearance44
        UltraGridColumn59.Format = "N2"
        UltraGridColumn59.Header.Caption = "Solicitado"
        UltraGridColumn59.Header.VisiblePosition = 3
        Appearance45.TextHAlignAsString = "Right"
        UltraGridColumn60.CellAppearance = Appearance45
        UltraGridColumn60.Format = "N2"
        UltraGridColumn60.Header.Caption = "Faltante"
        UltraGridColumn60.Header.VisiblePosition = 4
        UltraGridColumn61.Header.VisiblePosition = 5
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61})
        UltraGridColumn62.Header.VisiblePosition = 0
        UltraGridColumn62.Hidden = True
        UltraGridColumn63.Header.VisiblePosition = 1
        UltraGridColumn63.Hidden = True
        UltraGridColumn64.Header.VisiblePosition = 2
        UltraGridColumn64.Hidden = True
        UltraGridColumn65.Header.Caption = "Tipo"
        UltraGridColumn65.Header.VisiblePosition = 3
        UltraGridColumn65.Width = 88
        UltraGridColumn66.Header.Caption = "L."
        UltraGridColumn66.Header.VisiblePosition = 4
        UltraGridColumn66.Width = 22
        UltraGridColumn67.Header.Caption = "Emisor"
        UltraGridColumn67.Header.VisiblePosition = 5
        UltraGridColumn67.Width = 56
        Appearance46.TextHAlignAsString = "Right"
        UltraGridColumn68.CellAppearance = Appearance46
        UltraGridColumn68.Format = ""
        UltraGridColumn68.Header.Caption = "Número"
        UltraGridColumn68.Header.VisiblePosition = 6
        Appearance47.TextHAlignAsString = "Right"
        UltraGridColumn69.CellAppearance = Appearance47
        UltraGridColumn69.Header.VisiblePosition = 7
        UltraGridColumn69.Width = 70
        Appearance48.TextHAlignAsString = "Right"
        UltraGridColumn70.CellAppearance = Appearance48
        UltraGridColumn70.Format = "N2"
        UltraGridColumn70.Header.Caption = "Solicitado"
        UltraGridColumn70.Header.VisiblePosition = 8
        UltraGridColumn70.Width = 70
        UltraGridColumn71.Header.Caption = "Código"
        UltraGridColumn71.Header.VisiblePosition = 9
        UltraGridColumn72.Header.Caption = "Cliente"
        UltraGridColumn72.Header.VisiblePosition = 10
        UltraGridColumn72.Width = 241
        UltraGridColumn73.Header.Caption = "Tipo de Operación"
        UltraGridColumn73.Header.VisiblePosition = 11
        UltraGridColumn115.Format = "N2"
        UltraGridColumn115.Header.Caption = "Cantidad a Dividir"
        UltraGridColumn115.Header.VisiblePosition = 12
        UltraGridColumn115.MaskInput = "{double:-9.2}"
        UltraGridColumn115.Width = 70
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn115})
        Me.ugvArticulosSinStock.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugvArticulosSinStock.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.ugvArticulosSinStock.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvArticulosSinStock.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance49.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance49.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvArticulosSinStock.DisplayLayout.GroupByBox.Appearance = Appearance49
        Appearance50.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvArticulosSinStock.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance50
        Me.ugvArticulosSinStock.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvArticulosSinStock.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvArticulosSinStock.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance51.BackColor2 = System.Drawing.SystemColors.Control
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvArticulosSinStock.DisplayLayout.GroupByBox.PromptAppearance = Appearance51
        Me.ugvArticulosSinStock.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvArticulosSinStock.DisplayLayout.MaxRowScrollRegions = 1
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Appearance52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvArticulosSinStock.DisplayLayout.Override.ActiveCellAppearance = Appearance52
        Appearance53.BackColor = System.Drawing.SystemColors.Highlight
        Appearance53.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvArticulosSinStock.DisplayLayout.Override.ActiveRowAppearance = Appearance53
        Me.ugvArticulosSinStock.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvArticulosSinStock.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugvArticulosSinStock.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvArticulosSinStock.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvArticulosSinStock.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvArticulosSinStock.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance54.BackColor = System.Drawing.SystemColors.Window
        Me.ugvArticulosSinStock.DisplayLayout.Override.CardAreaAppearance = Appearance54
        Appearance55.BorderColor = System.Drawing.Color.Silver
        Appearance55.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvArticulosSinStock.DisplayLayout.Override.CellAppearance = Appearance55
        Me.ugvArticulosSinStock.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvArticulosSinStock.DisplayLayout.Override.CellPadding = 0
        Appearance56.BackColor = System.Drawing.SystemColors.Control
        Appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance56.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance56.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvArticulosSinStock.DisplayLayout.Override.GroupByRowAppearance = Appearance56
        Appearance57.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance57.TextHAlignAsString = "Left"
        Me.ugvArticulosSinStock.DisplayLayout.Override.HeaderAppearance = Appearance57
        Me.ugvArticulosSinStock.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvArticulosSinStock.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Appearance58.BorderColor = System.Drawing.Color.Silver
        Me.ugvArticulosSinStock.DisplayLayout.Override.RowAppearance = Appearance58
        Me.ugvArticulosSinStock.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugvArticulosSinStock.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance59.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvArticulosSinStock.DisplayLayout.Override.TemplateAddRowAppearance = Appearance59
        Me.ugvArticulosSinStock.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvArticulosSinStock.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvArticulosSinStock.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvArticulosSinStock.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvArticulosSinStock.EnterMueveACeldaDeAbajo = True
        Me.ugvArticulosSinStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvArticulosSinStock.Location = New System.Drawing.Point(6, 40)
        Me.ugvArticulosSinStock.Name = "ugvArticulosSinStock"
        Me.ugvArticulosSinStock.Size = New System.Drawing.Size(882, 289)
        Me.ugvArticulosSinStock.TabIndex = 0
        Me.ugvArticulosSinStock.Text = "UltraGrid1"
        Me.ugvArticulosSinStock.ToolStripLabelRegistros = Nothing
        Me.ugvArticulosSinStock.ToolStripMenuExpandir = Nothing
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.ugvConsolidadoEsqueletos)
        Me.UltraTabPageControl5.Controls.Add(Me.ugvConsolidado)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(1016, 350)
        '
        'ugvConsolidadoEsqueletos
        '
        Me.ugvConsolidadoEsqueletos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance60.BackColor = System.Drawing.SystemColors.Window
        Appearance60.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Appearance = Appearance60
        Me.ugvConsolidadoEsqueletos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn74.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn74.Header.VisiblePosition = 0
        UltraGridColumn74.Hidden = True
        UltraGridColumn75.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn75.Header.Caption = "Transportista"
        UltraGridColumn75.Header.VisiblePosition = 1
        UltraGridColumn76.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn76.Header.Caption = "Código"
        UltraGridColumn76.Header.VisiblePosition = 2
        UltraGridColumn76.Hidden = True
        UltraGridColumn77.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn77.Header.Caption = "Código"
        UltraGridColumn77.Header.VisiblePosition = 3
        UltraGridColumn77.Width = 84
        UltraGridColumn78.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn78.Header.Caption = "Producto"
        UltraGridColumn78.Header.VisiblePosition = 4
        UltraGridColumn78.Width = 189
        UltraGridColumn79.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance61.TextHAlignAsString = "Right"
        UltraGridColumn79.CellAppearance = Appearance61
        UltraGridColumn79.Format = "N2"
        UltraGridColumn79.Header.Caption = "Cantidad"
        UltraGridColumn79.Header.VisiblePosition = 5
        UltraGridColumn79.Width = 86
        UltraGridColumn80.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn80.Header.VisiblePosition = 6
        UltraGridColumn80.Hidden = True
        UltraGridColumn81.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn81.Header.VisiblePosition = 7
        UltraGridColumn81.Hidden = True
        UltraGridColumn82.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn82.Header.VisiblePosition = 8
        UltraGridColumn82.Hidden = True
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82})
        Me.ugvConsolidadoEsqueletos.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.ugvConsolidadoEsqueletos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvConsolidadoEsqueletos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance62.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance62.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance62.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvConsolidadoEsqueletos.DisplayLayout.GroupByBox.Appearance = Appearance62
        Appearance63.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvConsolidadoEsqueletos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance63
        Me.ugvConsolidadoEsqueletos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvConsolidadoEsqueletos.DisplayLayout.GroupByBox.Hidden = True
        Appearance64.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance64.BackColor2 = System.Drawing.SystemColors.Control
        Appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance64.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvConsolidadoEsqueletos.DisplayLayout.GroupByBox.PromptAppearance = Appearance64
        Me.ugvConsolidadoEsqueletos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvConsolidadoEsqueletos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance65.BackColor = System.Drawing.SystemColors.Window
        Appearance65.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.ActiveCellAppearance = Appearance65
        Appearance66.BackColor = System.Drawing.SystemColors.Highlight
        Appearance66.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.ActiveRowAppearance = Appearance66
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance67.BackColor = System.Drawing.SystemColors.Window
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.CardAreaAppearance = Appearance67
        Appearance68.BorderColor = System.Drawing.Color.Silver
        Appearance68.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.CellAppearance = Appearance68
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.CellPadding = 0
        Appearance69.BackColor = System.Drawing.SystemColors.Control
        Appearance69.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance69.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance69.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance69.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.GroupByRowAppearance = Appearance69
        Appearance70.TextHAlignAsString = "Left"
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.HeaderAppearance = Appearance70
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance71.BackColor = System.Drawing.SystemColors.Window
        Appearance71.BorderColor = System.Drawing.Color.Silver
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.RowAppearance = Appearance71
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance72.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvConsolidadoEsqueletos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance72
        Me.ugvConsolidadoEsqueletos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvConsolidadoEsqueletos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvConsolidadoEsqueletos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvConsolidadoEsqueletos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvConsolidadoEsqueletos.Location = New System.Drawing.Point(622, 3)
        Me.ugvConsolidadoEsqueletos.Name = "ugvConsolidadoEsqueletos"
        Me.ugvConsolidadoEsqueletos.Size = New System.Drawing.Size(376, 344)
        Me.ugvConsolidadoEsqueletos.TabIndex = 1
        Me.ugvConsolidadoEsqueletos.Text = "UltraGrid2"
        '
        'ugvConsolidado
        '
        Me.ugvConsolidado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance73.BackColor = System.Drawing.SystemColors.Window
        Appearance73.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvConsolidado.DisplayLayout.Appearance = Appearance73
        UltraGridColumn83.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn83.Header.VisiblePosition = 0
        UltraGridColumn83.Hidden = True
        UltraGridColumn84.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn84.Header.Caption = "Transportista"
        UltraGridColumn84.Header.VisiblePosition = 1
        UltraGridColumn85.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn85.Header.VisiblePosition = 2
        UltraGridColumn85.Hidden = True
        UltraGridColumn86.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn86.Header.Caption = "Rubro"
        UltraGridColumn86.Header.VisiblePosition = 3
        UltraGridColumn87.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn87.Header.Caption = "Código"
        UltraGridColumn87.Header.VisiblePosition = 4
        UltraGridColumn88.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn88.Header.Caption = "Producto"
        UltraGridColumn88.Header.VisiblePosition = 5
        UltraGridColumn88.Width = 300
        UltraGridColumn89.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance74.TextHAlignAsString = "Right"
        UltraGridColumn89.CellAppearance = Appearance74
        UltraGridColumn89.Format = "N2"
        UltraGridColumn89.Header.VisiblePosition = 6
        UltraGridColumn89.Width = 62
        UltraGridColumn90.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn90.Header.Caption = "Ubicación"
        UltraGridColumn90.Header.VisiblePosition = 7
        UltraGridColumn91.Header.VisiblePosition = 8
        UltraGridColumn91.Hidden = True
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91})
        Me.ugvConsolidado.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.ugvConsolidado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvConsolidado.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance75.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance75.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance75.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance75.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvConsolidado.DisplayLayout.GroupByBox.Appearance = Appearance75
        Appearance76.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvConsolidado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance76
        Me.ugvConsolidado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvConsolidado.DisplayLayout.GroupByBox.Hidden = True
        Appearance77.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance77.BackColor2 = System.Drawing.SystemColors.Control
        Appearance77.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance77.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvConsolidado.DisplayLayout.GroupByBox.PromptAppearance = Appearance77
        Me.ugvConsolidado.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvConsolidado.DisplayLayout.MaxRowScrollRegions = 1
        Appearance78.BackColor = System.Drawing.SystemColors.Window
        Appearance78.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvConsolidado.DisplayLayout.Override.ActiveCellAppearance = Appearance78
        Appearance79.BackColor = System.Drawing.SystemColors.Highlight
        Appearance79.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvConsolidado.DisplayLayout.Override.ActiveRowAppearance = Appearance79
        Me.ugvConsolidado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvConsolidado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance80.BackColor = System.Drawing.SystemColors.Window
        Me.ugvConsolidado.DisplayLayout.Override.CardAreaAppearance = Appearance80
        Appearance81.BorderColor = System.Drawing.Color.Silver
        Appearance81.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvConsolidado.DisplayLayout.Override.CellAppearance = Appearance81
        Me.ugvConsolidado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvConsolidado.DisplayLayout.Override.CellPadding = 0
        Appearance82.BackColor = System.Drawing.SystemColors.Control
        Appearance82.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance82.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance82.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance82.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvConsolidado.DisplayLayout.Override.GroupByRowAppearance = Appearance82
        Appearance83.TextHAlignAsString = "Left"
        Me.ugvConsolidado.DisplayLayout.Override.HeaderAppearance = Appearance83
        Me.ugvConsolidado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvConsolidado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance84.BackColor = System.Drawing.SystemColors.Window
        Appearance84.BorderColor = System.Drawing.Color.Silver
        Me.ugvConsolidado.DisplayLayout.Override.RowAppearance = Appearance84
        Me.ugvConsolidado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance85.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvConsolidado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance85
        Me.ugvConsolidado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvConsolidado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvConsolidado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvConsolidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvConsolidado.Location = New System.Drawing.Point(6, 3)
        Me.ugvConsolidado.Name = "ugvConsolidado"
        Me.ugvConsolidado.Size = New System.Drawing.Size(610, 344)
        Me.ugvConsolidado.TabIndex = 0
        Me.ugvConsolidado.Text = "UltraGrid1"
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.grpRepartos)
        Me.UltraTabPageControl4.Controls.Add(Me.ToolStrip2)
        Me.UltraTabPageControl4.Controls.Add(Me.gpbFacturas)
        Me.UltraTabPageControl4.Controls.Add(Me.GroupBox2)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(1016, 350)
        '
        'grpRepartos
        '
        Me.grpRepartos.Controls.Add(Me.ugRepartos)
        Me.grpRepartos.Location = New System.Drawing.Point(232, 29)
        Me.grpRepartos.Name = "grpRepartos"
        Me.grpRepartos.Size = New System.Drawing.Size(339, 342)
        Me.grpRepartos.TabIndex = 74
        Me.grpRepartos.TabStop = False
        Me.grpRepartos.Text = "Repartos"
        '
        'ugRepartos
        '
        Appearance86.BackColor = System.Drawing.SystemColors.Window
        Appearance86.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugRepartos.DisplayLayout.Appearance = Appearance86
        Me.ugRepartos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn92.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn92.Header.Caption = "Reparto"
        UltraGridColumn92.Header.VisiblePosition = 0
        UltraGridColumn92.Width = 61
        UltraGridColumn93.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn93.Header.VisiblePosition = 1
        UltraGridColumn93.Hidden = True
        UltraGridColumn94.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn94.Header.Caption = "Transportista"
        UltraGridColumn94.Header.VisiblePosition = 2
        UltraGridColumn94.Width = 264
        UltraGridColumn95.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn95.Header.Caption = "Fecha"
        UltraGridColumn95.Header.VisiblePosition = 3
        UltraGridColumn95.Hidden = True
        UltraGridColumn95.Width = 80
        UltraGridBand7.Columns.AddRange(New Object() {UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95})
        Me.ugRepartos.DisplayLayout.BandsSerializer.Add(UltraGridBand7)
        Me.ugRepartos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugRepartos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance87.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance87.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance87.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance87.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRepartos.DisplayLayout.GroupByBox.Appearance = Appearance87
        Appearance88.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRepartos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance88
        Me.ugRepartos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance89.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance89.BackColor2 = System.Drawing.SystemColors.Control
        Appearance89.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance89.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRepartos.DisplayLayout.GroupByBox.PromptAppearance = Appearance89
        Me.ugRepartos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugRepartos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance90.BackColor = System.Drawing.SystemColors.Window
        Appearance90.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugRepartos.DisplayLayout.Override.ActiveCellAppearance = Appearance90
        Appearance91.BackColor = System.Drawing.SystemColors.Highlight
        Appearance91.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugRepartos.DisplayLayout.Override.ActiveRowAppearance = Appearance91
        Me.ugRepartos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugRepartos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance92.BackColor = System.Drawing.SystemColors.Window
        Me.ugRepartos.DisplayLayout.Override.CardAreaAppearance = Appearance92
        Appearance93.BorderColor = System.Drawing.Color.Silver
        Appearance93.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugRepartos.DisplayLayout.Override.CellAppearance = Appearance93
        Me.ugRepartos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugRepartos.DisplayLayout.Override.CellPadding = 0
        Appearance94.BackColor = System.Drawing.SystemColors.Control
        Appearance94.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance94.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance94.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRepartos.DisplayLayout.Override.GroupByRowAppearance = Appearance94
        Appearance95.TextHAlignAsString = "Left"
        Me.ugRepartos.DisplayLayout.Override.HeaderAppearance = Appearance95
        Me.ugRepartos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugRepartos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance96.BackColor = System.Drawing.SystemColors.Window
        Appearance96.BorderColor = System.Drawing.Color.Silver
        Me.ugRepartos.DisplayLayout.Override.RowAppearance = Appearance96
        Me.ugRepartos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance97.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugRepartos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance97
        Me.ugRepartos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugRepartos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugRepartos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugRepartos.Location = New System.Drawing.Point(6, 19)
        Me.ugRepartos.Name = "ugRepartos"
        Me.ugRepartos.Size = New System.Drawing.Size(327, 296)
        Me.ugRepartos.TabIndex = 0
        Me.ugRepartos.Text = "UltraGrid1"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AllowItemReorder = True
        Me.ToolStrip2.BackColor = System.Drawing.Color.Silver
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbImprimir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1016, 25)
        Me.ToolStrip2.TabIndex = 73
        Me.ToolStrip2.Text = "toolStrip1"
        '
        'tsbImprimir
        '
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(57, 22)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'gpbFacturas
        '
        Me.gpbFacturas.Controls.Add(Me.ugvFacturas)
        Me.gpbFacturas.Location = New System.Drawing.Point(577, 29)
        Me.gpbFacturas.Name = "gpbFacturas"
        Me.gpbFacturas.Size = New System.Drawing.Size(482, 342)
        Me.gpbFacturas.TabIndex = 72
        Me.gpbFacturas.TabStop = False
        Me.gpbFacturas.Text = "Comprobantes del Reparto"
        '
        'ugvFacturas
        '
        Me.ugvFacturas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance98.BackColor = System.Drawing.SystemColors.Window
        Appearance98.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvFacturas.DisplayLayout.Appearance = Appearance98
        UltraGridColumn96.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn96.Header.Caption = "Resp. Distribución"
        UltraGridColumn96.Header.VisiblePosition = 0
        UltraGridColumn96.Hidden = True
        UltraGridColumn96.Width = 137
        UltraGridColumn97.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn97.Header.Caption = "Vendedor"
        UltraGridColumn97.Header.VisiblePosition = 1
        UltraGridColumn97.Width = 85
        UltraGridColumn98.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn98.Header.Caption = "Tipo"
        UltraGridColumn98.Header.VisiblePosition = 2
        UltraGridColumn98.Width = 60
        UltraGridColumn99.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn99.Header.Caption = "L."
        UltraGridColumn99.Header.VisiblePosition = 3
        UltraGridColumn99.Width = 25
        UltraGridColumn100.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance99.TextHAlignAsString = "Right"
        UltraGridColumn100.CellAppearance = Appearance99
        UltraGridColumn100.Header.Caption = "Nro."
        UltraGridColumn100.Header.VisiblePosition = 5
        UltraGridColumn100.Width = 60
        UltraGridColumn101.Header.VisiblePosition = 6
        UltraGridColumn101.Width = 77
        UltraGridColumn102.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn102.Header.Caption = "Tipo Doc."
        UltraGridColumn102.Header.VisiblePosition = 7
        UltraGridColumn102.Hidden = True
        UltraGridColumn102.Width = 58
        UltraGridColumn103.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance100.TextHAlignAsString = "Right"
        UltraGridColumn103.CellAppearance = Appearance100
        UltraGridColumn103.Header.Caption = "Nro. Doc."
        UltraGridColumn103.Header.VisiblePosition = 8
        UltraGridColumn103.Hidden = True
        UltraGridColumn103.Width = 62
        UltraGridColumn104.Header.Caption = "Código"
        UltraGridColumn104.Header.VisiblePosition = 9
        UltraGridColumn104.Width = 56
        UltraGridColumn105.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn105.Header.Caption = "Cliente"
        UltraGridColumn105.Header.VisiblePosition = 10
        UltraGridColumn105.Width = 130
        UltraGridColumn106.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn106.Header.Caption = "Dirección"
        UltraGridColumn106.Header.VisiblePosition = 11
        UltraGridColumn106.Width = 107
        UltraGridColumn107.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance101.TextHAlignAsString = "Right"
        UltraGridColumn107.CellAppearance = Appearance101
        UltraGridColumn107.Format = "N2"
        UltraGridColumn107.Header.Caption = "Total"
        UltraGridColumn107.Header.VisiblePosition = 12
        UltraGridColumn107.Width = 76
        Appearance102.TextHAlignAsString = "Right"
        UltraGridColumn108.CellAppearance = Appearance102
        UltraGridColumn108.Header.Caption = "Emisor"
        UltraGridColumn108.Header.VisiblePosition = 4
        UltraGridColumn108.Width = 50
        UltraGridColumn109.Header.VisiblePosition = 13
        UltraGridColumn109.Hidden = True
        UltraGridColumn110.Header.VisiblePosition = 14
        UltraGridColumn110.Hidden = True
        UltraGridColumn111.Header.VisiblePosition = 15
        UltraGridColumn111.Hidden = True
        UltraGridColumn112.Header.VisiblePosition = 16
        UltraGridColumn112.Hidden = True
        UltraGridColumn113.Header.VisiblePosition = 17
        UltraGridColumn113.Hidden = True
        UltraGridColumn114.Header.VisiblePosition = 18
        UltraGridColumn114.Hidden = True
        UltraGridBand8.Columns.AddRange(New Object() {UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114})
        Me.ugvFacturas.DisplayLayout.BandsSerializer.Add(UltraGridBand8)
        Me.ugvFacturas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvFacturas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance103.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance103.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance103.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance103.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvFacturas.DisplayLayout.GroupByBox.Appearance = Appearance103
        Appearance104.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvFacturas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance104
        Me.ugvFacturas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvFacturas.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance105.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance105.BackColor2 = System.Drawing.SystemColors.Control
        Appearance105.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance105.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvFacturas.DisplayLayout.GroupByBox.PromptAppearance = Appearance105
        Me.ugvFacturas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvFacturas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance106.BackColor = System.Drawing.SystemColors.Window
        Appearance106.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvFacturas.DisplayLayout.Override.ActiveCellAppearance = Appearance106
        Appearance107.BackColor = System.Drawing.SystemColors.Highlight
        Appearance107.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvFacturas.DisplayLayout.Override.ActiveRowAppearance = Appearance107
        Me.ugvFacturas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvFacturas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvFacturas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance108.BackColor = System.Drawing.SystemColors.Window
        Me.ugvFacturas.DisplayLayout.Override.CardAreaAppearance = Appearance108
        Appearance109.BorderColor = System.Drawing.Color.Silver
        Appearance109.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvFacturas.DisplayLayout.Override.CellAppearance = Appearance109
        Me.ugvFacturas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvFacturas.DisplayLayout.Override.CellPadding = 0
        Appearance110.BackColor = System.Drawing.SystemColors.Control
        Appearance110.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance110.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance110.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance110.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvFacturas.DisplayLayout.Override.GroupByRowAppearance = Appearance110
        Appearance111.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance111.TextHAlignAsString = "Left"
        Me.ugvFacturas.DisplayLayout.Override.HeaderAppearance = Appearance111
        Me.ugvFacturas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvFacturas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance112.BackColor = System.Drawing.SystemColors.Window
        Appearance112.BorderColor = System.Drawing.Color.Silver
        Me.ugvFacturas.DisplayLayout.Override.RowAppearance = Appearance112
        Me.ugvFacturas.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugvFacturas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvFacturas.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugvFacturas.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance113.BackColor = System.Drawing.Color.White
        Appearance113.BackColor2 = System.Drawing.Color.White
        Appearance113.TextVAlignAsString = "Bottom"
        Me.ugvFacturas.DisplayLayout.Override.SummaryFooterAppearance = Appearance113
        Appearance114.BackColor = System.Drawing.Color.Tomato
        Appearance114.BackColor2 = System.Drawing.Color.Silver
        Appearance114.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvFacturas.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance114
        Appearance115.BackColor = System.Drawing.Color.Tomato
        Appearance115.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance115.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance115.TextHAlignAsString = "Right"
        Me.ugvFacturas.DisplayLayout.Override.SummaryValueAppearance = Appearance115
        Appearance116.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvFacturas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance116
        Me.ugvFacturas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvFacturas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvFacturas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvFacturas.Location = New System.Drawing.Point(7, 19)
        Me.ugvFacturas.Name = "ugvFacturas"
        Me.ugvFacturas.Size = New System.Drawing.Size(415, 296)
        Me.ugvFacturas.TabIndex = 71
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbCajas)
        Me.GroupBox2.Controls.Add(Me.lblCaja)
        Me.GroupBox2.Controls.Add(Me.btnSolicitarCAE)
        Me.GroupBox2.Controls.Add(Me.btnImprimirFacturas)
        Me.GroupBox2.Controls.Add(Me.CheckBox3)
        Me.GroupBox2.Controls.Add(Me.btnFacturas)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(217, 321)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
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
        Me.cmbCajas.Location = New System.Drawing.Point(6, 58)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(103, 21)
        Me.cmbCajas.TabIndex = 81
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(9, 43)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 80
        Me.lblCaja.Text = "Ca&ja"
        '
        'btnSolicitarCAE
        '
        Me.btnSolicitarCAE.Enabled = False
        Me.btnSolicitarCAE.Location = New System.Drawing.Point(6, 169)
        Me.btnSolicitarCAE.Name = "btnSolicitarCAE"
        Me.btnSolicitarCAE.Size = New System.Drawing.Size(175, 70)
        Me.btnSolicitarCAE.TabIndex = 79
        Me.btnSolicitarCAE.Text = "&Solicitar CAE"
        Me.btnSolicitarCAE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSolicitarCAE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSolicitarCAE.UseVisualStyleBackColor = True
        '
        'btnImprimirFacturas
        '
        Me.btnImprimirFacturas.Enabled = False
        Me.btnImprimirFacturas.Location = New System.Drawing.Point(6, 245)
        Me.btnImprimirFacturas.Name = "btnImprimirFacturas"
        Me.btnImprimirFacturas.Size = New System.Drawing.Size(175, 70)
        Me.btnImprimirFacturas.TabIndex = 79
        Me.btnImprimirFacturas.Text = "&Imprimir Comprobantes"
        Me.btnImprimirFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImprimirFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimirFacturas.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.BindearPropiedadControl = Nothing
        Me.CheckBox3.BindearPropiedadEntidad = Nothing
        Me.CheckBox3.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox3.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox3.IsPK = False
        Me.CheckBox3.IsRequired = False
        Me.CheckBox3.Key = Nothing
        Me.CheckBox3.LabelAsoc = Nothing
        Me.CheckBox3.Location = New System.Drawing.Point(4, 16)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(212, 17)
        Me.CheckBox3.TabIndex = 72
        Me.CheckBox3.Text = "Incluir en Facturas la deuda del Cliente "
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'btnFacturas
        '
        Me.btnFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturas.ForeColor = System.Drawing.Color.ForestGreen
        Me.btnFacturas.Location = New System.Drawing.Point(6, 93)
        Me.btnFacturas.Name = "btnFacturas"
        Me.btnFacturas.Size = New System.Drawing.Size(175, 70)
        Me.btnFacturas.TabIndex = 9
        Me.btnFacturas.Text = "&Generar Reparto (F4)"
        Me.btnFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFacturas.UseVisualStyleBackColor = True
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.btnListadoClientesConEnvases)
        Me.UltraTabPageControl6.Controls.Add(Me.chkVend)
        Me.UltraTabPageControl6.Controls.Add(Me.chkRD)
        Me.UltraTabPageControl6.Controls.Add(Me.cboVendListados)
        Me.UltraTabPageControl6.Controls.Add(Me.cboRespDistListado)
        Me.UltraTabPageControl6.Controls.Add(Me.btnConsolidadoMercaderia)
        Me.UltraTabPageControl6.Controls.Add(Me.btnConsolidadoMercaderiaTipoOperacion)
        Me.UltraTabPageControl6.Controls.Add(Me.btnListadoClientes)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(1016, 350)
        '
        'btnListadoClientesConEnvases
        '
        Me.btnListadoClientesConEnvases.Enabled = False
        Me.btnListadoClientesConEnvases.Image = Global.Eniac.Win.My.Resources.Resources.businessmen
        Me.btnListadoClientesConEnvases.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListadoClientesConEnvases.Location = New System.Drawing.Point(401, 96)
        Me.btnListadoClientesConEnvases.Name = "btnListadoClientesConEnvases"
        Me.btnListadoClientesConEnvases.Size = New System.Drawing.Size(244, 41)
        Me.btnListadoClientesConEnvases.TabIndex = 89
        Me.btnListadoClientesConEnvases.Text = "&Listado de Clientes con Envases"
        Me.btnListadoClientesConEnvases.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnListadoClientesConEnvases.UseVisualStyleBackColor = True
        '
        'chkVend
        '
        Me.chkVend.AutoSize = True
        Me.chkVend.BindearPropiedadControl = Nothing
        Me.chkVend.BindearPropiedadEntidad = Nothing
        Me.chkVend.ForeColorFocus = System.Drawing.Color.Red
        Me.chkVend.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkVend.IsPK = False
        Me.chkVend.IsRequired = False
        Me.chkVend.Key = Nothing
        Me.chkVend.LabelAsoc = Nothing
        Me.chkVend.Location = New System.Drawing.Point(29, 112)
        Me.chkVend.Name = "chkVend"
        Me.chkVend.Size = New System.Drawing.Size(72, 17)
        Me.chkVend.TabIndex = 88
        Me.chkVend.Text = "Vendedor"
        Me.chkVend.UseVisualStyleBackColor = True
        '
        'chkRD
        '
        Me.chkRD.AutoSize = True
        Me.chkRD.BindearPropiedadControl = Nothing
        Me.chkRD.BindearPropiedadEntidad = Nothing
        Me.chkRD.ForeColorFocus = System.Drawing.Color.Red
        Me.chkRD.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkRD.IsPK = False
        Me.chkRD.IsRequired = False
        Me.chkRD.Key = Nothing
        Me.chkRD.LabelAsoc = Nothing
        Me.chkRD.Location = New System.Drawing.Point(29, 76)
        Me.chkRD.Name = "chkRD"
        Me.chkRD.Size = New System.Drawing.Size(112, 17)
        Me.chkRD.TabIndex = 87
        Me.chkRD.Text = "Resp. Distribución"
        Me.chkRD.UseVisualStyleBackColor = True
        '
        'cboVendListados
        '
        Me.cboVendListados.BindearPropiedadControl = "SelectedValue"
        Me.cboVendListados.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cboVendListados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVendListados.Enabled = False
        Me.cboVendListados.ForeColorFocus = System.Drawing.Color.Red
        Me.cboVendListados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboVendListados.FormattingEnabled = True
        Me.cboVendListados.IsPK = False
        Me.cboVendListados.IsRequired = True
        Me.cboVendListados.Key = Nothing
        Me.cboVendListados.LabelAsoc = Me.chkVend
        Me.cboVendListados.Location = New System.Drawing.Point(142, 110)
        Me.cboVendListados.Name = "cboVendListados"
        Me.cboVendListados.Size = New System.Drawing.Size(181, 21)
        Me.cboVendListados.TabIndex = 86
        '
        'cboRespDistListado
        '
        Me.cboRespDistListado.BindearPropiedadControl = "SelectedValue"
        Me.cboRespDistListado.BindearPropiedadEntidad = "TipoCliente.IdTipoCliente"
        Me.cboRespDistListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRespDistListado.Enabled = False
        Me.cboRespDistListado.ForeColorFocus = System.Drawing.Color.Red
        Me.cboRespDistListado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboRespDistListado.FormattingEnabled = True
        Me.cboRespDistListado.IsPK = False
        Me.cboRespDistListado.IsRequired = True
        Me.cboRespDistListado.Key = Nothing
        Me.cboRespDistListado.LabelAsoc = Me.chkRD
        Me.cboRespDistListado.Location = New System.Drawing.Point(142, 70)
        Me.cboRespDistListado.Name = "cboRespDistListado"
        Me.cboRespDistListado.Size = New System.Drawing.Size(181, 21)
        Me.cboRespDistListado.TabIndex = 85
        '
        'btnConsolidadoMercaderia
        '
        Me.btnConsolidadoMercaderia.Enabled = False
        Me.btnConsolidadoMercaderia.Image = Global.Eniac.Win.My.Resources.Resources.box_next
        Me.btnConsolidadoMercaderia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsolidadoMercaderia.Location = New System.Drawing.Point(401, 192)
        Me.btnConsolidadoMercaderia.Name = "btnConsolidadoMercaderia"
        Me.btnConsolidadoMercaderia.Size = New System.Drawing.Size(244, 41)
        Me.btnConsolidadoMercaderia.TabIndex = 82
        Me.btnConsolidadoMercaderia.Text = "Consolidado Carga &Mercadería"
        Me.btnConsolidadoMercaderia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsolidadoMercaderia.UseVisualStyleBackColor = True
        '
        'btnConsolidadoMercaderiaTipoOperacion
        '
        Me.btnConsolidadoMercaderiaTipoOperacion.Enabled = False
        Me.btnConsolidadoMercaderiaTipoOperacion.Image = Global.Eniac.Win.My.Resources.Resources.box_next
        Me.btnConsolidadoMercaderiaTipoOperacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsolidadoMercaderiaTipoOperacion.Location = New System.Drawing.Point(401, 239)
        Me.btnConsolidadoMercaderiaTipoOperacion.Name = "btnConsolidadoMercaderiaTipoOperacion"
        Me.btnConsolidadoMercaderiaTipoOperacion.Size = New System.Drawing.Size(244, 41)
        Me.btnConsolidadoMercaderiaTipoOperacion.TabIndex = 81
        Me.btnConsolidadoMercaderiaTipoOperacion.Text = "&Consolidado de Carga (por Tp. Oper.)"
        Me.btnConsolidadoMercaderiaTipoOperacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConsolidadoMercaderiaTipoOperacion.UseVisualStyleBackColor = True
        '
        'btnListadoClientes
        '
        Me.btnListadoClientes.Enabled = False
        Me.btnListadoClientes.Image = Global.Eniac.Win.My.Resources.Resources.businessmen
        Me.btnListadoClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListadoClientes.Location = New System.Drawing.Point(401, 50)
        Me.btnListadoClientes.Name = "btnListadoClientes"
        Me.btnListadoClientes.Size = New System.Drawing.Size(244, 41)
        Me.btnListadoClientes.TabIndex = 79
        Me.btnListadoClientes.Text = "&Listado de Clientes"
        Me.btnListadoClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnListadoClientes.UseVisualStyleBackColor = True
        '
        'chbArtSinStock
        '
        Me.chbArtSinStock.AutoSize = True
        Me.chbArtSinStock.BindearPropiedadControl = Nothing
        Me.chbArtSinStock.BindearPropiedadEntidad = Nothing
        Me.chbArtSinStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbArtSinStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbArtSinStock.IsPK = False
        Me.chbArtSinStock.IsRequired = False
        Me.chbArtSinStock.Key = Nothing
        Me.chbArtSinStock.LabelAsoc = Nothing
        Me.chbArtSinStock.Location = New System.Drawing.Point(677, 71)
        Me.chbArtSinStock.Name = "chbArtSinStock"
        Me.chbArtSinStock.Size = New System.Drawing.Size(137, 17)
        Me.chbArtSinStock.TabIndex = 19
        Me.chbArtSinStock.Text = "Con Artículos sin Stock"
        Me.chbArtSinStock.UseVisualStyleBackColor = True
        '
        'chbProdDesc
        '
        Me.chbProdDesc.AutoSize = True
        Me.chbProdDesc.BindearPropiedadControl = Nothing
        Me.chbProdDesc.BindearPropiedadEntidad = Nothing
        Me.chbProdDesc.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProdDesc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProdDesc.IsPK = False
        Me.chbProdDesc.IsRequired = False
        Me.chbProdDesc.Key = Nothing
        Me.chbProdDesc.LabelAsoc = Nothing
        Me.chbProdDesc.Location = New System.Drawing.Point(294, 71)
        Me.chbProdDesc.Name = "chbProdDesc"
        Me.chbProdDesc.Size = New System.Drawing.Size(124, 17)
        Me.chbProdDesc.TabIndex = 17
        Me.chbProdDesc.Text = "Nombre de Producto"
        Me.chbProdDesc.UseVisualStyleBackColor = True
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
        Me.chbVendedor.Location = New System.Drawing.Point(10, 71)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 15
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'txtProducto
        '
        Me.txtProducto.BindearPropiedadControl = Nothing
        Me.txtProducto.BindearPropiedadEntidad = Nothing
        Me.txtProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtProducto.Formato = ""
        Me.txtProducto.IsDecimal = False
        Me.txtProducto.IsNumber = False
        Me.txtProducto.IsPK = False
        Me.txtProducto.IsRequired = False
        Me.txtProducto.Key = ""
        Me.txtProducto.LabelAsoc = Me.chbProdDesc
        Me.txtProducto.Location = New System.Drawing.Point(424, 69)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(247, 20)
        Me.txtProducto.TabIndex = 18
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
        Me.chbRespDistribucion.Location = New System.Drawing.Point(10, 44)
        Me.chbRespDistribucion.Name = "chbRespDistribucion"
        Me.chbRespDistribucion.Size = New System.Drawing.Size(112, 17)
        Me.chbRespDistribucion.TabIndex = 8
        Me.chbRespDistribucion.Text = "Resp. Distribución"
        Me.chbRespDistribucion.UseVisualStyleBackColor = True
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Me.chbProducto
        Me.bscCodigoProducto.Location = New System.Drawing.Point(369, 43)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = False
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = True
        Me.bscCodigoProducto.Size = New System.Drawing.Size(108, 20)
        Me.bscCodigoProducto.TabIndex = 11
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
        Me.chbProducto.Location = New System.Drawing.Point(294, 44)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 10
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
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
        Me.cmbRespDistribucion.LabelAsoc = Me.chbRespDistribucion
        Me.cmbRespDistribucion.Location = New System.Drawing.Point(123, 42)
        Me.cmbRespDistribucion.Name = "cmbRespDistribucion"
        Me.cmbRespDistribucion.Size = New System.Drawing.Size(165, 21)
        Me.cmbRespDistribucion.TabIndex = 9
        '
        'bscProducto
        '
        Me.bscProducto.ActivarFiltroEnGrilla = True
        Me.bscProducto.BindearPropiedadControl = Nothing
        Me.bscProducto.BindearPropiedadEntidad = Nothing
        Me.bscProducto.ConfigBuscador = Nothing
        Me.bscProducto.Datos = Nothing
        Me.bscProducto.FilaDevuelta = Nothing
        Me.bscProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto.IsDecimal = False
        Me.bscProducto.IsNumber = False
        Me.bscProducto.IsPK = False
        Me.bscProducto.IsRequired = False
        Me.bscProducto.Key = ""
        Me.bscProducto.LabelAsoc = Me.chbProducto
        Me.bscProducto.Location = New System.Drawing.Point(478, 43)
        Me.bscProducto.MaxLengh = "32767"
        Me.bscProducto.Name = "bscProducto"
        Me.bscProducto.Permitido = False
        Me.bscProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto.Selecciono = True
        Me.bscProducto.Size = New System.Drawing.Size(193, 20)
        Me.bscProducto.TabIndex = 12
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
        Me.cmbVendedor.Location = New System.Drawing.Point(123, 69)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(165, 21)
        Me.cmbVendedor.TabIndex = 16
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Lista de Precios Múltiples"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Appearance117.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance117.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance117.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance117
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
        'lblNumeroReparto
        '
        Me.lblNumeroReparto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumeroReparto.AutoSize = True
        Me.lblNumeroReparto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroReparto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNumeroReparto.Location = New System.Drawing.Point(739, 16)
        Me.lblNumeroReparto.Name = "lblNumeroReparto"
        Me.lblNumeroReparto.Size = New System.Drawing.Size(0, 20)
        Me.lblNumeroReparto.TabIndex = 7
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1023, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(944, 17)
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
        'utcPreventa
        '
        Appearance118.ForeColor = System.Drawing.Color.Black
        Me.utcPreventa.ActiveTabAppearance = Appearance118
        Me.utcPreventa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.utcPreventa.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl1)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl3)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl4)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl2)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl6)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl5)
        Me.utcPreventa.Enabled = False
        Me.utcPreventa.Location = New System.Drawing.Point(5, 163)
        Me.utcPreventa.Name = "utcPreventa"
        Me.utcPreventa.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.utcPreventa.Size = New System.Drawing.Size(1018, 373)
        Me.utcPreventa.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.utcPreventa.TabIndex = 1
        Appearance119.BackColor = System.Drawing.Color.Honeydew
        UltraTab1.ActiveAppearance = Appearance119
        Appearance120.ForeColor = System.Drawing.Color.Black
        UltraTab1.Appearance = Appearance120
        UltraTab1.Key = "tbpDetallePedidos"
        UltraTab1.TabPage = Me.UltraTabPageControl3
        UltraTab1.Text = "Pedidos/Comprobante"
        Appearance121.BackColor = System.Drawing.Color.Honeydew
        UltraTab2.ActiveAppearance = Appearance121
        Appearance122.ForeColor = System.Drawing.Color.Black
        UltraTab2.Appearance = Appearance122
        UltraTab2.Key = "tbpPedidosSinResponsable"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Comprobantes S/ Resp. Distribución"
        Appearance123.BackColor = System.Drawing.Color.Honeydew
        UltraTab3.ActiveAppearance = Appearance123
        Appearance124.ForeColor = System.Drawing.Color.Black
        UltraTab3.Appearance = Appearance124
        UltraTab3.Key = "tbpArticulosSinStock"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "Artículos sin Stock (F9)"
        Appearance125.BackColor = System.Drawing.Color.Honeydew
        UltraTab4.ActiveAppearance = Appearance125
        Appearance126.ForeColor = System.Drawing.Color.Black
        UltraTab4.Appearance = Appearance126
        UltraTab4.Key = "tbpConsolidado"
        UltraTab4.TabPage = Me.UltraTabPageControl5
        UltraTab4.Text = "Consolidado"
        Appearance127.BackColor = System.Drawing.Color.Honeydew
        UltraTab5.ActiveAppearance = Appearance127
        Appearance128.ForeColor = System.Drawing.Color.Black
        UltraTab5.Appearance = Appearance128
        UltraTab5.Key = "tbpComprobantes"
        UltraTab5.TabPage = Me.UltraTabPageControl4
        UltraTab5.Text = "Comprobantes (F4)"
        UltraTab6.Key = "tbpListados"
        UltraTab6.TabPage = Me.UltraTabPageControl6
        UltraTab6.Text = "Listados"
        Me.utcPreventa.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3, UltraTab4, UltraTab5, UltraTab6})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1016, 350)
        '
        'grbFecha
        '
        Me.grbFecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFecha.Controls.Add(Me.bscCodigoCliente)
        Me.grbFecha.Controls.Add(Me.bscCliente)
        Me.grbFecha.Controls.Add(Me.chbCliente)
        Me.grbFecha.Controls.Add(Me.chbLocalidad)
        Me.grbFecha.Controls.Add(Me.bscCodigoLocalidad)
        Me.grbFecha.Controls.Add(Me.bscNombreLocalidad)
        Me.grbFecha.Controls.Add(Me.chbOrdenProducto)
        Me.grbFecha.Controls.Add(Me.cmbOrdenProducto)
        Me.grbFecha.Controls.Add(Me.lblOrigen)
        Me.grbFecha.Controls.Add(Me.cmbOrigen)
        Me.grbFecha.Controls.Add(Me.chbArtSinStock)
        Me.grbFecha.Controls.Add(Me.lblNumeroReparto)
        Me.grbFecha.Controls.Add(Me.chbProdDesc)
        Me.grbFecha.Controls.Add(Me.chbPendientes)
        Me.grbFecha.Controls.Add(Me.chbVendedor)
        Me.grbFecha.Controls.Add(Me.dtpFechaHasta)
        Me.grbFecha.Controls.Add(Me.txtProducto)
        Me.grbFecha.Controls.Add(Me.btnBuscar)
        Me.grbFecha.Controls.Add(Me.chbRespDistribucion)
        Me.grbFecha.Controls.Add(Me.dtpFechaDesde)
        Me.grbFecha.Controls.Add(Me.lblFechaHasta)
        Me.grbFecha.Controls.Add(Me.bscCodigoProducto)
        Me.grbFecha.Controls.Add(Me.lblFechaDesde)
        Me.grbFecha.Controls.Add(Me.cmbRespDistribucion)
        Me.grbFecha.Controls.Add(Me.bscProducto)
        Me.grbFecha.Controls.Add(Me.cmbVendedor)
        Me.grbFecha.Controls.Add(Me.chbProducto)
        Me.grbFecha.Location = New System.Drawing.Point(6, 32)
        Me.grbFecha.Name = "grbFecha"
        Me.grbFecha.Size = New System.Drawing.Size(1014, 125)
        Me.grbFecha.TabIndex = 0
        Me.grbFecha.TabStop = False
        Me.grbFecha.Text = "FIltros"
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
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(123, 95)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 21
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
        Me.bscCliente.Location = New System.Drawing.Point(220, 95)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = False
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(259, 23)
        Me.bscCliente.TabIndex = 22
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
        Me.chbCliente.Location = New System.Drawing.Point(10, 98)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 20
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
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
        Me.chbLocalidad.Location = New System.Drawing.Point(528, 98)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 23
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.AyudaAncho = 608
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidad"
        Me.bscCodigoLocalidad.ColumnasAlineacion = Nothing
        Me.bscCodigoLocalidad.ColumnasAncho = Nothing
        Me.bscCodigoLocalidad.ColumnasFormato = Nothing
        Me.bscCodigoLocalidad.ColumnasOcultas = Nothing
        Me.bscCodigoLocalidad.ColumnasTitulos = Nothing
        Me.bscCodigoLocalidad.Datos = Nothing
        Me.bscCodigoLocalidad.FilaDevuelta = Nothing
        Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoLocalidad.IsDecimal = False
        Me.bscCodigoLocalidad.IsNumber = False
        Me.bscCodigoLocalidad.IsPK = False
        Me.bscCodigoLocalidad.IsRequired = False
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Me.chbLocalidad
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(606, 95)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = False
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(85, 20)
        Me.bscCodigoLocalidad.TabIndex = 24
        Me.bscCodigoLocalidad.Titulo = Nothing
        '
        'bscNombreLocalidad
        '
        Me.bscNombreLocalidad.AyudaAncho = 608
        Me.bscNombreLocalidad.BindearPropiedadControl = Nothing
        Me.bscNombreLocalidad.BindearPropiedadEntidad = Nothing
        Me.bscNombreLocalidad.ColumnasAlineacion = Nothing
        Me.bscNombreLocalidad.ColumnasAncho = Nothing
        Me.bscNombreLocalidad.ColumnasFormato = Nothing
        Me.bscNombreLocalidad.ColumnasOcultas = Nothing
        Me.bscNombreLocalidad.ColumnasTitulos = Nothing
        Me.bscNombreLocalidad.Datos = Nothing
        Me.bscNombreLocalidad.FilaDevuelta = Nothing
        Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreLocalidad.IsDecimal = False
        Me.bscNombreLocalidad.IsNumber = False
        Me.bscNombreLocalidad.IsPK = False
        Me.bscNombreLocalidad.IsRequired = False
        Me.bscNombreLocalidad.Key = ""
        Me.bscNombreLocalidad.LabelAsoc = Me.chbLocalidad
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(697, 95)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = False
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(147, 20)
        Me.bscNombreLocalidad.TabIndex = 25
        Me.bscNombreLocalidad.Titulo = Nothing
        '
        'chbOrdenProducto
        '
        Me.chbOrdenProducto.AutoSize = True
        Me.chbOrdenProducto.BindearPropiedadControl = Nothing
        Me.chbOrdenProducto.BindearPropiedadEntidad = Nothing
        Me.chbOrdenProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenProducto.IsPK = False
        Me.chbOrdenProducto.IsRequired = False
        Me.chbOrdenProducto.Key = Nothing
        Me.chbOrdenProducto.LabelAsoc = Nothing
        Me.chbOrdenProducto.Location = New System.Drawing.Point(677, 44)
        Me.chbOrdenProducto.Name = "chbOrdenProducto"
        Me.chbOrdenProducto.Size = New System.Drawing.Size(55, 17)
        Me.chbOrdenProducto.TabIndex = 13
        Me.chbOrdenProducto.Text = "Orden"
        '
        'cmbOrdenProducto
        '
        Me.cmbOrdenProducto.BindearPropiedadControl = ""
        Me.cmbOrdenProducto.BindearPropiedadEntidad = ""
        Me.cmbOrdenProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrdenProducto.Enabled = False
        Me.cmbOrdenProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrdenProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrdenProducto.FormattingEnabled = True
        Me.cmbOrdenProducto.IsPK = False
        Me.cmbOrdenProducto.IsRequired = True
        Me.cmbOrdenProducto.Key = Nothing
        Me.cmbOrdenProducto.LabelAsoc = Me.chbOrdenProducto
        Me.cmbOrdenProducto.Location = New System.Drawing.Point(738, 40)
        Me.cmbOrdenProducto.Name = "cmbOrdenProducto"
        Me.cmbOrdenProducto.Size = New System.Drawing.Size(76, 21)
        Me.cmbOrdenProducto.TabIndex = 14
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.LabelAsoc = Nothing
        Me.lblOrigen.Location = New System.Drawing.Point(369, 20)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(38, 13)
        Me.lblOrigen.TabIndex = 4
        Me.lblOrigen.Text = "Origen"
        '
        'cmbOrigen
        '
        Me.cmbOrigen.BindearPropiedadControl = ""
        Me.cmbOrigen.BindearPropiedadEntidad = ""
        Me.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.IsPK = False
        Me.cmbOrigen.IsRequired = True
        Me.cmbOrigen.Key = Nothing
        Me.cmbOrigen.LabelAsoc = Me.lblOrigen
        Me.cmbOrigen.Location = New System.Drawing.Point(413, 16)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(96, 21)
        Me.cmbOrigen.TabIndex = 5
        '
        'chbPendientes
        '
        Me.chbPendientes.AutoSize = True
        Me.chbPendientes.BindearPropiedadControl = Nothing
        Me.chbPendientes.BindearPropiedadEntidad = Nothing
        Me.chbPendientes.Checked = True
        Me.chbPendientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPendientes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPendientes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPendientes.IsPK = False
        Me.chbPendientes.IsRequired = False
        Me.chbPendientes.Key = Nothing
        Me.chbPendientes.LabelAsoc = Nothing
        Me.chbPendientes.Location = New System.Drawing.Point(528, 18)
        Me.chbPendientes.Name = "chbPendientes"
        Me.chbPendientes.Size = New System.Drawing.Size(205, 17)
        Me.chbPendientes.TabIndex = 6
        Me.chbPendientes.TabStop = False
        Me.chbPendientes.Text = "Verifica pedidos anteriores pendientes"
        Me.chbPendientes.UseVisualStyleBackColor = True
        Me.chbPendientes.Visible = False
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
        Me.dtpFechaHasta.LabelAsoc = Me.lblFechaHasta
        Me.dtpFechaHasta.Location = New System.Drawing.Point(265, 16)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaHasta.TabIndex = 3
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.LabelAsoc = Nothing
        Me.lblFechaHasta.Location = New System.Drawing.Point(226, 20)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(33, 13)
        Me.lblFechaHasta.TabIndex = 2
        Me.lblFechaHasta.Text = "hasta"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnBuscar.Location = New System.Drawing.Point(898, 90)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(110, 30)
        Me.btnBuscar.TabIndex = 26
        Me.btnBuscar.Text = "&Buscar (F3)"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaDesde.IsPK = False
        Me.dtpFechaDesde.IsRequired = False
        Me.dtpFechaDesde.Key = ""
        Me.dtpFechaDesde.LabelAsoc = Me.lblFechaDesde
        Me.dtpFechaDesde.Location = New System.Drawing.Point(123, 16)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaDesde.TabIndex = 1
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.LabelAsoc = Nothing
        Me.lblFechaDesde.Location = New System.Drawing.Point(7, 20)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(105, 13)
        Me.lblFechaDesde.TabIndex = 0
        Me.lblFechaDesde.Text = "Fecha Pedido desde"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbPrint, Me.tsddExportar, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbCerrar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1023, 29)
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
        'tsbPrint
        '
        Me.tsbPrint.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(79, 26)
        Me.tsbPrint.Text = "Imprimir"
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
        'tsbCerrar
        '
        Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
        Me.tsbCerrar.Text = "&Cerrar"
        Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
        '
        'OrganizarEntregasV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 561)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.utcPreventa)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFecha)
        Me.KeyPreview = True
        Me.Name = "OrganizarEntregasV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Organizar Entregas (v2)"
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.ugvDetallePedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.ugvPedidosPorDistribucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ugvArticulosSinStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        CType(Me.ugvConsolidadoEsqueletos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugvConsolidado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.UltraTabPageControl4.PerformLayout()
        Me.grpRepartos.ResumeLayout(False)
        CType(Me.ugRepartos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.gpbFacturas.ResumeLayout(False)
        CType(Me.ugvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.UltraTabPageControl6.ResumeLayout(False)
        Me.UltraTabPageControl6.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.utcPreventa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utcPreventa.ResumeLayout(False)
        Me.grbFecha.ResumeLayout(False)
        Me.grbFecha.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ProductoSinStockBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents utcPreventa As Infragistics.Win.UltraWinTabControl.UltraTabControl
   Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
   Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents grbFecha As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents ugvArticulosSinStock As UltraGridEditable
   Friend WithEvents ugvDetallePedidos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Public WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
   Public WithEvents tsbNuevoPedido As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbModificarPedido As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents cmbRespDistribucion As Eniac.Controles.ComboBox
   Friend WithEvents chbArtSinStock As Eniac.Controles.CheckBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents chbRespDistribucion As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProducto As Eniac.Controles.Buscador2
   Friend WithEvents bscProducto As Eniac.Controles.Buscador2
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents tsbEliminarPedido As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbCambiarFechaEnvio As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ugvPedidosPorDistribucion As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents CheckBox3 As Eniac.Controles.CheckBox
   Friend WithEvents btnFacturas As Eniac.Controles.Button
   Friend WithEvents gpbFacturas As System.Windows.Forms.GroupBox
   Friend WithEvents ugvFacturas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnImprimirFacturas As Eniac.Controles.Button
   Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRecalcularStock As System.Windows.Forms.ToolStripButton
   Public WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
   Public WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents tsbModificarRespDist As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblNumeroReparto As System.Windows.Forms.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents tsbCambiarFPago As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents chkVend As Eniac.Controles.CheckBox
   Friend WithEvents chkRD As Eniac.Controles.CheckBox
   Friend WithEvents cboVendListados As Eniac.Controles.ComboBox
   Friend WithEvents cboRespDistListado As Eniac.Controles.ComboBox
   Friend WithEvents btnConsolidadoMercaderia As Eniac.Controles.Button
   Friend WithEvents btnConsolidadoMercaderiaTipoOperacion As Eniac.Controles.Button
   Friend WithEvents btnListadoClientes As Eniac.Controles.Button
   Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCambiarComprobante As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtProducto As Eniac.Controles.TextBox
   Friend WithEvents chbProdDesc As Eniac.Controles.CheckBox
   Friend WithEvents tsbDividirPedido As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnSolicitarCAE As Eniac.Controles.Button
   Friend WithEvents chbPendientes As Eniac.Controles.CheckBox
   Friend WithEvents UltraTabPageControl5 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents ugvConsolidado As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugvConsolidadoEsqueletos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpFechaDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaHasta As Eniac.Controles.Label
   Friend WithEvents lblFechaDesde As Eniac.Controles.Label
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents grpRepartos As System.Windows.Forms.GroupBox
   Friend WithEvents ugRepartos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chkExpandAll As Eniac.Controles.CheckBox
   Friend WithEvents chkExpandAllRespDist As Eniac.Controles.CheckBox
   Friend WithEvents chkExpandAllPedidos As Eniac.Controles.CheckBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbModificarPalets As System.Windows.Forms.ToolStripButton
   Friend WithEvents ProductoSinStockBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents lblOrigen As Eniac.Controles.Label
   Friend WithEvents cmbOrigen As Eniac.Controles.ComboBox
   Friend WithEvents btnListadoClientesConEnvases As Eniac.Controles.Button
   Friend WithEvents chbOrdenProducto As Eniac.Controles.CheckBox
   Friend WithEvents cmbOrdenProducto As Eniac.Controles.ComboBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents tsbDividirPedidoPorFaltante As ToolStripButton
   Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
End Class
