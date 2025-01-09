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
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotalNeto")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Retornable")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
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
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalResumenComprobante")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalResumenEfectivo")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalResumenCtaCte")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalResumenCheques")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalResumenNCred")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalResumenReenvio")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalResumenSaldoGeneral")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver", 0)
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoComprobante")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
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
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioEnvase")
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePagado")
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CopiarValor", 0)
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdReparto")
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdGasto")
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaCaja")
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaCaja")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePesos")
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCaja")
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPlanilla")
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimiento")
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
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdReparto")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarRepartos))
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.tbcDetalle = New System.Windows.Forms.TabControl()
        Me.tbpDetalle = New System.Windows.Forms.TabPage()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpComprobantes = New System.Windows.Forms.TabPage()
        Me.ugComprobantes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpProductos = New System.Windows.Forms.TabPage()
        Me.lblOrdenarPor = New System.Windows.Forms.Label()
        Me.optOrdenarPorNombre = New System.Windows.Forms.RadioButton()
        Me.optOrdenarPorCodigo = New System.Windows.Forms.RadioButton()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.tbpConsolidadoPorModelo = New System.Windows.Forms.TabPage()
        Me.ugConsolidadoPorModelo = New Eniac.Win.UltraGridEditable()
        Me.tbpGastos = New System.Windows.Forms.TabPage()
        Me.ugGastos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpProductosSinDescargo = New System.Windows.Forms.TabPage()
        Me.ugvProductosSinDescargar = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbpResumen = New System.Windows.Forms.TabPage()
        Me.btnImprimirDetallado = New System.Windows.Forms.Button()
        Me.cmdImprimirResumen = New System.Windows.Forms.Button()
        Me.grbIVAs = New System.Windows.Forms.GroupBox()
        Me.lblTotalTransferencia = New Eniac.Controles.Label()
        Me.txtTotalTransferencia = New Eniac.Controles.TextBox()
        Me.Label5 = New Eniac.Controles.Label()
        Me.txtTotalComprobantes = New Eniac.Controles.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDescRecGral = New Eniac.Controles.Label()
        Me.txttotalCC = New Eniac.Controles.TextBox()
        Me.lblTotalReenvios = New Eniac.Controles.Label()
        Me.txtTotalReenvios = New Eniac.Controles.TextBox()
        Me.lblTotalSubtotales = New Eniac.Controles.Label()
        Me.lblTotalImpuestos = New Eniac.Controles.Label()
        Me.txtTotalSubtotales = New Eniac.Controles.TextBox()
        Me.lblTotalNeto = New Eniac.Controles.Label()
        Me.lblTotalBruto = New Eniac.Controles.Label()
        Me.txtTotalNC = New Eniac.Controles.TextBox()
        Me.txtTotalEfectivo = New Eniac.Controles.TextBox()
        Me.txttotalCheque = New Eniac.Controles.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tss1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.tss2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddListadoClientes = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsbListadoClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbListadoClientesConEnvases = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsddConsolidados = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsbConsolidadoCarga = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbConsolidadoCargaTipoOperacion = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.chbFormaPago = New Eniac.Controles.CheckBox()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcDetalle.SuspendLayout()
        Me.tbpDetalle.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpComprobantes.SuspendLayout()
        CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpProductos.SuspendLayout()
        Me.tbpConsolidadoPorModelo.SuspendLayout()
        CType(Me.ugConsolidadoPorModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpGastos.SuspendLayout()
        CType(Me.ugGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpProductosSinDescargo.SuspendLayout()
        CType(Me.ugvProductosSinDescargar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpResumen.SuspendLayout()
        Me.grbIVAs.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbFiltros.SuspendLayout()
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
        Me.UltraGridPrintDocument1.Grid = Me.ugProductos
        Appearance20.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance20
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
        'ugProductos
        '
        Me.ugProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugProductos.DisplayLayout.Appearance = Appearance1
        UltraGridColumn14.Header.Caption = "Marca"
        UltraGridColumn14.Header.VisiblePosition = 0
        UltraGridColumn14.Width = 140
        UltraGridColumn15.Header.Caption = "Rubro"
        UltraGridColumn15.Header.VisiblePosition = 1
        UltraGridColumn15.Width = 140
        UltraGridColumn16.Header.Caption = "Subrubro"
        UltraGridColumn16.Header.VisiblePosition = 4
        UltraGridColumn16.Hidden = True
        UltraGridColumn16.Width = 150
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance2
        UltraGridColumn17.Header.Caption = "Producto"
        UltraGridColumn17.Header.VisiblePosition = 2
        UltraGridColumn17.Width = 90
        UltraGridColumn18.Header.Caption = "Nombre Producto"
        UltraGridColumn18.Header.VisiblePosition = 3
        UltraGridColumn18.Width = 290
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance3
        UltraGridColumn19.Format = "##,##0.00"
        UltraGridColumn19.Header.Caption = "Neto"
        UltraGridColumn19.Header.VisiblePosition = 5
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 80
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance4
        UltraGridColumn20.Format = "##,##0.00"
        UltraGridColumn20.Header.Caption = "Total"
        UltraGridColumn20.Header.VisiblePosition = 6
        UltraGridColumn20.Hidden = True
        UltraGridColumn20.Width = 80
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance5
        UltraGridColumn21.Format = "##,##0.00"
        UltraGridColumn21.Header.VisiblePosition = 9
        UltraGridColumn21.Width = 80
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance6
        UltraGridColumn22.Format = "##,##0.00"
        UltraGridColumn22.Header.VisiblePosition = 7
        UltraGridColumn22.Width = 80
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance7
        UltraGridColumn24.Format = "##,##0.00"
        UltraGridColumn24.Header.VisiblePosition = 8
        UltraGridColumn24.Width = 80
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance8
        UltraGridColumn23.Format = "##,##0.00"
        UltraGridColumn23.Header.VisiblePosition = 10
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 70
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn24, UltraGridColumn23})
        Me.ugProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.GroupByBox.Appearance = Appearance9
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance10
        Me.ugProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugProductos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance11.BackColor2 = System.Drawing.SystemColors.Control
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance11
        Me.ugProductos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugProductos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.Highlight
        Appearance13.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance13
        Me.ugProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.Override.CardAreaAppearance = Appearance14
        Appearance15.BorderColor = System.Drawing.Color.Silver
        Appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugProductos.DisplayLayout.Override.CellAppearance = Appearance15
        Me.ugProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugProductos.DisplayLayout.Override.CellPadding = 0
        Appearance16.BackColor = System.Drawing.SystemColors.Control
        Appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.BorderColor = System.Drawing.SystemColors.Window
        Me.ugProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance16
        Appearance17.TextHAlignAsString = "Left"
        Me.ugProductos.DisplayLayout.Override.HeaderAppearance = Appearance17
        Me.ugProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.BorderColor = System.Drawing.Color.Silver
        Me.ugProductos.DisplayLayout.Override.RowAppearance = Appearance18
        Me.ugProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance19
        Me.ugProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugProductos.Location = New System.Drawing.Point(4, 27)
        Me.ugProductos.Name = "ugProductos"
        Me.ugProductos.Size = New System.Drawing.Size(844, 313)
        Me.ugProductos.TabIndex = 5
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle.Controls.Add(Me.tbpDetalle)
        Me.tbcDetalle.Controls.Add(Me.tbpComprobantes)
        Me.tbcDetalle.Controls.Add(Me.tbpProductos)
        Me.tbcDetalle.Controls.Add(Me.tbpConsolidadoPorModelo)
        Me.tbcDetalle.Controls.Add(Me.tbpGastos)
        Me.tbcDetalle.Controls.Add(Me.tbpProductosSinDescargo)
        Me.tbcDetalle.Controls.Add(Me.tbpResumen)
        Me.tbcDetalle.Location = New System.Drawing.Point(12, 166)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(860, 371)
        Me.tbcDetalle.TabIndex = 8
        '
        'tbpDetalle
        '
        Me.tbpDetalle.Controls.Add(Me.ugDetalle)
        Me.tbpDetalle.Location = New System.Drawing.Point(4, 22)
        Me.tbpDetalle.Name = "tbpDetalle"
        Me.tbpDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDetalle.Size = New System.Drawing.Size(852, 345)
        Me.tbpDetalle.TabIndex = 0
        Me.tbpDetalle.Text = "Detalle"
        Me.tbpDetalle.UseVisualStyleBackColor = True
        '
        'ugDetalle
        '
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance21
        UltraGridColumn44.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn44.Header.Caption = "Fecha Envio"
        UltraGridColumn44.Header.VisiblePosition = 1
        UltraGridColumn44.Width = 133
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance22
        UltraGridColumn27.Header.Caption = "Numero Reparto"
        UltraGridColumn27.Header.VisiblePosition = 2
        UltraGridColumn27.Width = 97
        UltraGridColumn28.Header.VisiblePosition = 3
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.Header.Caption = "Transportista"
        UltraGridColumn29.Header.VisiblePosition = 4
        UltraGridColumn29.Width = 520
        UltraGridColumn25.Header.VisiblePosition = 5
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.Header.VisiblePosition = 6
        UltraGridColumn26.Hidden = True
        UltraGridColumn39.Header.VisiblePosition = 7
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.Header.VisiblePosition = 8
        UltraGridColumn40.Hidden = True
        UltraGridColumn41.Header.VisiblePosition = 9
        UltraGridColumn41.Hidden = True
        UltraGridColumn45.Header.VisiblePosition = 10
        UltraGridColumn45.Hidden = True
        UltraGridColumn46.Header.VisiblePosition = 11
        UltraGridColumn46.Hidden = True
        UltraGridColumn43.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn43.Header.VisiblePosition = 0
        UltraGridColumn43.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn43.Width = 42
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn44, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn25, UltraGridColumn26, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn45, UltraGridColumn46, UltraGridColumn43})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance23
        Appearance24.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance24
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance25.BackColor2 = System.Drawing.SystemColors.Control
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance26
        Appearance27.BackColor = System.Drawing.SystemColors.Highlight
        Appearance27.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance28
        Appearance29.BorderColor = System.Drawing.Color.Silver
        Appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance30.BackColor = System.Drawing.SystemColors.Control
        Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance30.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance30
        Appearance31.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance31
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance33.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(846, 339)
        Me.ugDetalle.TabIndex = 5
        '
        'tbpComprobantes
        '
        Me.tbpComprobantes.BackColor = System.Drawing.SystemColors.Control
        Me.tbpComprobantes.Controls.Add(Me.ugComprobantes)
        Me.tbpComprobantes.Location = New System.Drawing.Point(4, 22)
        Me.tbpComprobantes.Name = "tbpComprobantes"
        Me.tbpComprobantes.Size = New System.Drawing.Size(852, 345)
        Me.tbpComprobantes.TabIndex = 2
        Me.tbpComprobantes.Text = "Comprobantes"
        '
        'ugComprobantes
        '
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Appearance34.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugComprobantes.DisplayLayout.Appearance = Appearance34
        Appearance35.TextHAlignAsString = "Center"
        UltraGridColumn30.CellAppearance = Appearance35
        UltraGridColumn30.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn30.Header.VisiblePosition = 0
        UltraGridColumn30.Width = 100
        UltraGridColumn31.Header.VisiblePosition = 1
        UltraGridColumn31.Hidden = True
        UltraGridColumn32.Header.Caption = "Comprobante"
        UltraGridColumn32.Header.VisiblePosition = 2
        UltraGridColumn32.Width = 90
        Appearance36.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance36
        UltraGridColumn33.Header.Caption = "L."
        UltraGridColumn33.Header.VisiblePosition = 3
        UltraGridColumn33.Width = 20
        Appearance37.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance37
        UltraGridColumn34.Header.Caption = "Emisor"
        UltraGridColumn34.Header.VisiblePosition = 4
        UltraGridColumn34.Width = 40
        Appearance38.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance38
        UltraGridColumn35.Header.Caption = "Número"
        UltraGridColumn35.Header.VisiblePosition = 5
        UltraGridColumn35.Width = 70
        UltraGridColumn36.Header.VisiblePosition = 6
        UltraGridColumn36.Hidden = True
        UltraGridColumn37.Header.VisiblePosition = 7
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.Header.Caption = "Nombre Cliente"
        UltraGridColumn38.Header.VisiblePosition = 8
        UltraGridColumn38.Width = 150
        UltraGridColumn2.Header.Caption = "Venderdor"
        UltraGridColumn2.Header.VisiblePosition = 12
        UltraGridColumn2.Width = 150
        UltraGridColumn52.Header.Caption = "F. de Pago"
        UltraGridColumn52.Header.VisiblePosition = 10
        UltraGridColumn52.Width = 80
        Appearance39.TextHAlignAsString = "Right"
        UltraGridColumn53.CellAppearance = Appearance39
        UltraGridColumn53.Format = "##,##0.00"
        UltraGridColumn53.Header.Caption = "Total"
        UltraGridColumn53.Header.VisiblePosition = 11
        UltraGridColumn53.Width = 70
        UltraGridColumn54.Header.VisiblePosition = 13
        UltraGridColumn54.Width = 80
        UltraGridColumn42.Header.VisiblePosition = 14
        UltraGridColumn42.Width = 200
        UltraGridColumn1.Header.VisiblePosition = 9
        UltraGridColumn1.Width = 146
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn2, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn42, UltraGridColumn1})
        Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugComprobantes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComprobantes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance40.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance40.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance40.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.GroupByBox.Appearance = Appearance40
        Appearance41.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance41
        Me.ugComprobantes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComprobantes.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance42.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance42.BackColor2 = System.Drawing.SystemColors.Control
        Appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance42.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantes.DisplayLayout.GroupByBox.PromptAppearance = Appearance42
        Me.ugComprobantes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugComprobantes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance43.BackColor = System.Drawing.SystemColors.Window
        Appearance43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugComprobantes.DisplayLayout.Override.ActiveCellAppearance = Appearance43
        Appearance44.BackColor = System.Drawing.SystemColors.Highlight
        Appearance44.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugComprobantes.DisplayLayout.Override.ActiveRowAppearance = Appearance44
        Me.ugComprobantes.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugComprobantes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugComprobantes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugComprobantes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugComprobantes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance45.BackColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.Override.CardAreaAppearance = Appearance45
        Appearance46.BorderColor = System.Drawing.Color.Silver
        Appearance46.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugComprobantes.DisplayLayout.Override.CellAppearance = Appearance46
        Me.ugComprobantes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugComprobantes.DisplayLayout.Override.CellPadding = 0
        Appearance47.BackColor = System.Drawing.SystemColors.Control
        Appearance47.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance47.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance47.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.Override.GroupByRowAppearance = Appearance47
        Appearance48.TextHAlignAsString = "Left"
        Me.ugComprobantes.DisplayLayout.Override.HeaderAppearance = Appearance48
        Me.ugComprobantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugComprobantes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.BorderColor = System.Drawing.Color.Silver
        Me.ugComprobantes.DisplayLayout.Override.RowAppearance = Appearance49
        Me.ugComprobantes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugComprobantes.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance50.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugComprobantes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance50
        Me.ugComprobantes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugComprobantes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugComprobantes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugComprobantes.Location = New System.Drawing.Point(0, 0)
        Me.ugComprobantes.Name = "ugComprobantes"
        Me.ugComprobantes.Size = New System.Drawing.Size(852, 345)
        Me.ugComprobantes.TabIndex = 2
        '
        'tbpProductos
        '
        Me.tbpProductos.Controls.Add(Me.lblOrdenarPor)
        Me.tbpProductos.Controls.Add(Me.optOrdenarPorNombre)
        Me.tbpProductos.Controls.Add(Me.optOrdenarPorCodigo)
        Me.tbpProductos.Controls.Add(Me.chkExpandAll)
        Me.tbpProductos.Controls.Add(Me.ugProductos)
        Me.tbpProductos.Location = New System.Drawing.Point(4, 22)
        Me.tbpProductos.Name = "tbpProductos"
        Me.tbpProductos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpProductos.Size = New System.Drawing.Size(852, 345)
        Me.tbpProductos.TabIndex = 1
        Me.tbpProductos.Text = "Productos"
        Me.tbpProductos.UseVisualStyleBackColor = True
        '
        'lblOrdenarPor
        '
        Me.lblOrdenarPor.AutoSize = True
        Me.lblOrdenarPor.Location = New System.Drawing.Point(370, 8)
        Me.lblOrdenarPor.Name = "lblOrdenarPor"
        Me.lblOrdenarPor.Size = New System.Drawing.Size(205, 13)
        Me.lblOrdenarPor.TabIndex = 85
        Me.lblOrdenarPor.Text = "Consolidado: Ordenar Línea Producto Por"
        '
        'optOrdenarPorNombre
        '
        Me.optOrdenarPorNombre.AutoSize = True
        Me.optOrdenarPorNombre.Checked = True
        Me.optOrdenarPorNombre.Location = New System.Drawing.Point(658, 6)
        Me.optOrdenarPorNombre.Name = "optOrdenarPorNombre"
        Me.optOrdenarPorNombre.Size = New System.Drawing.Size(72, 17)
        Me.optOrdenarPorNombre.TabIndex = 84
        Me.optOrdenarPorNombre.TabStop = True
        Me.optOrdenarPorNombre.Text = "Alfabético"
        Me.optOrdenarPorNombre.UseVisualStyleBackColor = True
        '
        'optOrdenarPorCodigo
        '
        Me.optOrdenarPorCodigo.AutoSize = True
        Me.optOrdenarPorCodigo.Location = New System.Drawing.Point(587, 6)
        Me.optOrdenarPorCodigo.Name = "optOrdenarPorCodigo"
        Me.optOrdenarPorCodigo.Size = New System.Drawing.Size(58, 17)
        Me.optOrdenarPorCodigo.TabIndex = 83
        Me.optOrdenarPorCodigo.Text = "Código"
        Me.optOrdenarPorCodigo.UseVisualStyleBackColor = True
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(7, 6)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 82
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'tbpConsolidadoPorModelo
        '
        Me.tbpConsolidadoPorModelo.BackColor = System.Drawing.SystemColors.Control
        Me.tbpConsolidadoPorModelo.Controls.Add(Me.ugConsolidadoPorModelo)
        Me.tbpConsolidadoPorModelo.Location = New System.Drawing.Point(4, 22)
        Me.tbpConsolidadoPorModelo.Name = "tbpConsolidadoPorModelo"
        Me.tbpConsolidadoPorModelo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpConsolidadoPorModelo.Size = New System.Drawing.Size(852, 345)
        Me.tbpConsolidadoPorModelo.TabIndex = 3
        Me.tbpConsolidadoPorModelo.Text = "Consolidado por Modelo"
        '
        'ugConsolidadoPorModelo
        '
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Appearance51.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugConsolidadoPorModelo.DisplayLayout.Appearance = Appearance51
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance52.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance52
        UltraGridColumn4.Header.VisiblePosition = 0
        UltraGridColumn4.Hidden = True
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance53.TextHAlignAsString = "Right"
        UltraGridColumn55.CellAppearance = Appearance53
        UltraGridColumn55.Header.Caption = "Código"
        UltraGridColumn55.Header.VisiblePosition = 2
        UltraGridColumn55.Width = 49
        UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn56.Header.Caption = "Cliente"
        UltraGridColumn56.Header.VisiblePosition = 3
        UltraGridColumn56.Width = 170
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn7.Header.Caption = "Dirección"
        UltraGridColumn7.Header.VisiblePosition = 1
        UltraGridColumn7.Width = 170
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance54.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance54
        UltraGridColumn8.Format = "N2"
        UltraGridColumn8.Header.Caption = "Envase"
        UltraGridColumn8.Header.VisiblePosition = 4
        UltraGridColumn8.Width = 70
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance55.TextHAlignAsString = "Right"
        UltraGridColumn9.CellAppearance = Appearance55
        UltraGridColumn9.Format = "N2"
        UltraGridColumn9.Header.Caption = "A Pagar"
        UltraGridColumn9.Header.VisiblePosition = 5
        UltraGridColumn9.Width = 70
        Appearance56.BackColor = System.Drawing.Color.LightCyan
        Appearance56.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance56
        UltraGridColumn10.Format = "N2"
        UltraGridColumn10.Header.Caption = "Pagado"
        UltraGridColumn10.Header.VisiblePosition = 7
        UltraGridColumn10.Width = 70
        UltraGridColumn11.Header.VisiblePosition = 8
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.VisiblePosition = 9
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance57.Image = Global.Eniac.Win.My.Resources.Resources.navigate_right
        Appearance57.ImageHAlign = Infragistics.Win.HAlign.Center
        UltraGridColumn13.CellButtonAppearance = Appearance57
        UltraGridColumn13.Header.Caption = ""
        UltraGridColumn13.Header.VisiblePosition = 6
        UltraGridColumn13.MaxWidth = 20
        UltraGridColumn13.MinWidth = 20
        UltraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn13.Width = 20
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn55, UltraGridColumn56, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
        Me.ugConsolidadoPorModelo.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.ugConsolidadoPorModelo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugConsolidadoPorModelo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance58.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance58.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance58.BorderColor = System.Drawing.SystemColors.Window
        Me.ugConsolidadoPorModelo.DisplayLayout.GroupByBox.Appearance = Appearance58
        Appearance59.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugConsolidadoPorModelo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance59
        Me.ugConsolidadoPorModelo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance60.BackColor2 = System.Drawing.SystemColors.Control
        Appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance60.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugConsolidadoPorModelo.DisplayLayout.GroupByBox.PromptAppearance = Appearance60
        Me.ugConsolidadoPorModelo.DisplayLayout.MaxColScrollRegions = 1
        Me.ugConsolidadoPorModelo.DisplayLayout.MaxRowScrollRegions = 1
        Appearance61.BackColor = System.Drawing.SystemColors.Window
        Appearance61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.ActiveCellAppearance = Appearance61
        Appearance62.BackColor = System.Drawing.SystemColors.Highlight
        Appearance62.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.ActiveRowAppearance = Appearance62
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance63.BackColor = System.Drawing.SystemColors.Window
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.CardAreaAppearance = Appearance63
        Appearance64.BorderColor = System.Drawing.Color.Silver
        Appearance64.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.CellAppearance = Appearance64
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.CellPadding = 0
        Appearance65.BackColor = System.Drawing.SystemColors.Control
        Appearance65.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance65.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance65.BorderColor = System.Drawing.SystemColors.Window
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.GroupByRowAppearance = Appearance65
        Appearance66.TextHAlignAsString = "Left"
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.HeaderAppearance = Appearance66
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance67.BackColor = System.Drawing.SystemColors.Window
        Appearance67.BorderColor = System.Drawing.Color.Silver
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.RowAppearance = Appearance67
        Appearance68.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance68
        Me.ugConsolidadoPorModelo.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugConsolidadoPorModelo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugConsolidadoPorModelo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugConsolidadoPorModelo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugConsolidadoPorModelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugConsolidadoPorModelo.Location = New System.Drawing.Point(3, 3)
        Me.ugConsolidadoPorModelo.Name = "ugConsolidadoPorModelo"
        Me.ugConsolidadoPorModelo.Size = New System.Drawing.Size(846, 339)
        Me.ugConsolidadoPorModelo.TabIndex = 3
        Me.ugConsolidadoPorModelo.Text = "UltraGrid1"
        Me.ugConsolidadoPorModelo.ToolStripLabelRegistros = Nothing
        Me.ugConsolidadoPorModelo.ToolStripMenuExpandir = Nothing
        '
        'tbpGastos
        '
        Me.tbpGastos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpGastos.Controls.Add(Me.ugGastos)
        Me.tbpGastos.Location = New System.Drawing.Point(4, 22)
        Me.tbpGastos.Name = "tbpGastos"
        Me.tbpGastos.Size = New System.Drawing.Size(852, 345)
        Me.tbpGastos.TabIndex = 4
        Me.tbpGastos.Text = "Gastos"
        '
        'ugGastos
        '
        Appearance69.BackColor = System.Drawing.SystemColors.Window
        Appearance69.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugGastos.DisplayLayout.Appearance = Appearance69
        Appearance70.TextHAlignAsString = "Right"
        UltraGridColumn58.CellAppearance = Appearance70
        UltraGridColumn58.Header.Caption = "Suc."
        UltraGridColumn58.Header.VisiblePosition = 0
        UltraGridColumn58.Hidden = True
        Appearance71.TextHAlignAsString = "Right"
        UltraGridColumn59.CellAppearance = Appearance71
        UltraGridColumn59.Header.Caption = "Reparto"
        UltraGridColumn59.Header.VisiblePosition = 1
        UltraGridColumn59.Hidden = True
        Appearance72.TextHAlignAsString = "Right"
        UltraGridColumn60.CellAppearance = Appearance72
        UltraGridColumn60.Header.Caption = "Gasto"
        UltraGridColumn60.Header.VisiblePosition = 2
        UltraGridColumn60.Hidden = True
        Appearance73.TextHAlignAsString = "Right"
        UltraGridColumn61.CellAppearance = Appearance73
        UltraGridColumn61.Header.Caption = "Código"
        UltraGridColumn61.Header.VisiblePosition = 3
        UltraGridColumn62.Header.Caption = "Cuenta Caja"
        UltraGridColumn62.Header.VisiblePosition = 4
        UltraGridColumn62.Width = 229
        Appearance74.TextHAlignAsString = "Right"
        UltraGridColumn63.CellAppearance = Appearance74
        UltraGridColumn63.Format = "N2"
        UltraGridColumn63.Header.Caption = "Importe Pesos"
        UltraGridColumn63.Header.VisiblePosition = 5
        UltraGridColumn63.Width = 87
        UltraGridColumn64.Header.Caption = "Observación"
        UltraGridColumn64.Header.VisiblePosition = 6
        UltraGridColumn64.Width = 237
        Appearance75.TextHAlignAsString = "Right"
        UltraGridColumn65.CellAppearance = Appearance75
        UltraGridColumn65.Header.Caption = "Caja"
        UltraGridColumn65.Header.VisiblePosition = 7
        UltraGridColumn65.Width = 36
        Appearance76.TextHAlignAsString = "Right"
        UltraGridColumn66.CellAppearance = Appearance76
        UltraGridColumn66.Header.Caption = "Planilla"
        UltraGridColumn66.Header.VisiblePosition = 8
        UltraGridColumn66.Width = 64
        Appearance77.TextHAlignAsString = "Right"
        UltraGridColumn67.CellAppearance = Appearance77
        UltraGridColumn67.Header.Caption = "Movimiento"
        UltraGridColumn67.Header.VisiblePosition = 9
        UltraGridColumn67.Width = 70
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67})
        Me.ugGastos.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.ugGastos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugGastos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance78.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance78.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance78.BorderColor = System.Drawing.SystemColors.Window
        Me.ugGastos.DisplayLayout.GroupByBox.Appearance = Appearance78
        Appearance79.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugGastos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance79
        Me.ugGastos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance80.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance80.BackColor2 = System.Drawing.SystemColors.Control
        Appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance80.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugGastos.DisplayLayout.GroupByBox.PromptAppearance = Appearance80
        Me.ugGastos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugGastos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance81.BackColor = System.Drawing.SystemColors.Window
        Appearance81.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugGastos.DisplayLayout.Override.ActiveCellAppearance = Appearance81
        Appearance82.BackColor = System.Drawing.SystemColors.Highlight
        Appearance82.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugGastos.DisplayLayout.Override.ActiveRowAppearance = Appearance82
        Me.ugGastos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugGastos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugGastos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance83.BackColor = System.Drawing.SystemColors.Window
        Me.ugGastos.DisplayLayout.Override.CardAreaAppearance = Appearance83
        Appearance84.BorderColor = System.Drawing.Color.Silver
        Appearance84.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugGastos.DisplayLayout.Override.CellAppearance = Appearance84
        Me.ugGastos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugGastos.DisplayLayout.Override.CellPadding = 0
        Appearance85.BackColor = System.Drawing.SystemColors.Control
        Appearance85.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance85.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance85.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance85.BorderColor = System.Drawing.SystemColors.Window
        Me.ugGastos.DisplayLayout.Override.GroupByRowAppearance = Appearance85
        Appearance86.TextHAlignAsString = "Left"
        Me.ugGastos.DisplayLayout.Override.HeaderAppearance = Appearance86
        Me.ugGastos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugGastos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance87.BackColor = System.Drawing.SystemColors.Window
        Appearance87.BorderColor = System.Drawing.Color.Silver
        Me.ugGastos.DisplayLayout.Override.RowAppearance = Appearance87
        Me.ugGastos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance88.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugGastos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance88
        Me.ugGastos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugGastos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugGastos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugGastos.Location = New System.Drawing.Point(0, 0)
        Me.ugGastos.Name = "ugGastos"
        Me.ugGastos.Size = New System.Drawing.Size(852, 345)
        Me.ugGastos.TabIndex = 0
        Me.ugGastos.Text = "UltraGrid1"
        '
        'tbpProductosSinDescargo
        '
        Me.tbpProductosSinDescargo.BackColor = System.Drawing.SystemColors.Control
        Me.tbpProductosSinDescargo.Controls.Add(Me.ugvProductosSinDescargar)
        Me.tbpProductosSinDescargo.Location = New System.Drawing.Point(4, 22)
        Me.tbpProductosSinDescargo.Name = "tbpProductosSinDescargo"
        Me.tbpProductosSinDescargo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpProductosSinDescargo.Size = New System.Drawing.Size(852, 345)
        Me.tbpProductosSinDescargo.TabIndex = 6
        Me.tbpProductosSinDescargo.Text = "Productos Devueltos"
        '
        'ugvProductosSinDescargar
        '
        Appearance89.BackColor = System.Drawing.SystemColors.Window
        Appearance89.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvProductosSinDescargar.DisplayLayout.Appearance = Appearance89
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn3.Hidden = True
        UltraGridColumn5.Header.VisiblePosition = 2
        UltraGridColumn5.Hidden = True
        Appearance90.TextHAlignAsString = "Right"
        UltraGridColumn68.CellAppearance = Appearance90
        UltraGridColumn68.Header.Caption = "Código"
        UltraGridColumn68.Header.VisiblePosition = 1
        UltraGridColumn68.Width = 116
        UltraGridColumn70.Header.VisiblePosition = 3
        UltraGridColumn70.Width = 411
        Appearance91.TextHAlignAsString = "Right"
        UltraGridColumn72.CellAppearance = Appearance91
        UltraGridColumn72.Format = "N2"
        UltraGridColumn72.Header.VisiblePosition = 4
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn3, UltraGridColumn5, UltraGridColumn68, UltraGridColumn70, UltraGridColumn72, UltraGridColumn6})
        Me.ugvProductosSinDescargar.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.ugvProductosSinDescargar.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvProductosSinDescargar.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance92.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance92.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance92.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance92.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Appearance = Appearance92
        Appearance93.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance93
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Prompt = " "
        Appearance94.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance94.BackColor2 = System.Drawing.SystemColors.Control
        Appearance94.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance94.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.PromptAppearance = Appearance94
        Me.ugvProductosSinDescargar.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvProductosSinDescargar.DisplayLayout.MaxRowScrollRegions = 1
        Appearance95.BackColor = System.Drawing.SystemColors.Window
        Appearance95.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.ActiveCellAppearance = Appearance95
        Appearance96.BackColor = System.Drawing.SystemColors.Highlight
        Appearance96.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.ActiveRowAppearance = Appearance96
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvProductosSinDescargar.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvProductosSinDescargar.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance97.BackColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CardAreaAppearance = Appearance97
        Appearance98.BorderColor = System.Drawing.Color.Silver
        Appearance98.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellAppearance = Appearance98
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellPadding = 0
        Appearance99.BackColor = System.Drawing.SystemColors.Control
        Appearance99.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance99.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance99.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance99.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.Override.GroupByRowAppearance = Appearance99
        Appearance100.TextHAlignAsString = "Left"
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderAppearance = Appearance100
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance101.BackColor = System.Drawing.SystemColors.Window
        Appearance101.BorderColor = System.Drawing.Color.Silver
        Me.ugvProductosSinDescargar.DisplayLayout.Override.RowAppearance = Appearance101
        Me.ugvProductosSinDescargar.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance102.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvProductosSinDescargar.DisplayLayout.Override.TemplateAddRowAppearance = Appearance102
        Me.ugvProductosSinDescargar.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvProductosSinDescargar.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvProductosSinDescargar.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvProductosSinDescargar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugvProductosSinDescargar.Location = New System.Drawing.Point(3, 3)
        Me.ugvProductosSinDescargar.Name = "ugvProductosSinDescargar"
        Me.ugvProductosSinDescargar.Size = New System.Drawing.Size(846, 339)
        Me.ugvProductosSinDescargar.TabIndex = 1
        Me.ugvProductosSinDescargar.Text = "UltraGrid1"
        '
        'tbpResumen
        '
        Me.tbpResumen.BackColor = System.Drawing.SystemColors.Control
        Me.tbpResumen.Controls.Add(Me.btnImprimirDetallado)
        Me.tbpResumen.Controls.Add(Me.cmdImprimirResumen)
        Me.tbpResumen.Controls.Add(Me.grbIVAs)
        Me.tbpResumen.Location = New System.Drawing.Point(4, 22)
        Me.tbpResumen.Name = "tbpResumen"
        Me.tbpResumen.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpResumen.Size = New System.Drawing.Size(852, 345)
        Me.tbpResumen.TabIndex = 5
        Me.tbpResumen.Text = "Resumen"
        '
        'btnImprimirDetallado
        '
        Me.btnImprimirDetallado.Location = New System.Drawing.Point(403, 42)
        Me.btnImprimirDetallado.Name = "btnImprimirDetallado"
        Me.btnImprimirDetallado.Size = New System.Drawing.Size(107, 24)
        Me.btnImprimirDetallado.TabIndex = 4
        Me.btnImprimirDetallado.Text = "Imprimir Detallado"
        Me.btnImprimirDetallado.UseVisualStyleBackColor = True
        '
        'cmdImprimirResumen
        '
        Me.cmdImprimirResumen.Location = New System.Drawing.Point(403, 12)
        Me.cmdImprimirResumen.Name = "cmdImprimirResumen"
        Me.cmdImprimirResumen.Size = New System.Drawing.Size(107, 24)
        Me.cmdImprimirResumen.TabIndex = 3
        Me.cmdImprimirResumen.Text = "Imprimir Resumen"
        Me.cmdImprimirResumen.UseVisualStyleBackColor = True
        '
        'grbIVAs
        '
        Me.grbIVAs.Controls.Add(Me.lblTotalTransferencia)
        Me.grbIVAs.Controls.Add(Me.txtTotalTransferencia)
        Me.grbIVAs.Controls.Add(Me.Label5)
        Me.grbIVAs.Controls.Add(Me.txtTotalComprobantes)
        Me.grbIVAs.Controls.Add(Me.Label4)
        Me.grbIVAs.Controls.Add(Me.lblDescRecGral)
        Me.grbIVAs.Controls.Add(Me.txttotalCC)
        Me.grbIVAs.Controls.Add(Me.lblTotalReenvios)
        Me.grbIVAs.Controls.Add(Me.txtTotalReenvios)
        Me.grbIVAs.Controls.Add(Me.lblTotalSubtotales)
        Me.grbIVAs.Controls.Add(Me.lblTotalImpuestos)
        Me.grbIVAs.Controls.Add(Me.txtTotalSubtotales)
        Me.grbIVAs.Controls.Add(Me.lblTotalNeto)
        Me.grbIVAs.Controls.Add(Me.lblTotalBruto)
        Me.grbIVAs.Controls.Add(Me.txtTotalNC)
        Me.grbIVAs.Controls.Add(Me.txtTotalEfectivo)
        Me.grbIVAs.Controls.Add(Me.txttotalCheque)
        Me.grbIVAs.Controls.Add(Me.Label8)
        Me.grbIVAs.Location = New System.Drawing.Point(22, 3)
        Me.grbIVAs.Name = "grbIVAs"
        Me.grbIVAs.Size = New System.Drawing.Size(375, 336)
        Me.grbIVAs.TabIndex = 2
        Me.grbIVAs.TabStop = False
        '
        'lblTotalTransferencia
        '
        Me.lblTotalTransferencia.AutoSize = True
        Me.lblTotalTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalTransferencia.LabelAsoc = Nothing
        Me.lblTotalTransferencia.Location = New System.Drawing.Point(12, 93)
        Me.lblTotalTransferencia.Name = "lblTotalTransferencia"
        Me.lblTotalTransferencia.Size = New System.Drawing.Size(106, 20)
        Me.lblTotalTransferencia.TabIndex = 17
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
        Me.txtTotalTransferencia.Location = New System.Drawing.Point(223, 90)
        Me.txtTotalTransferencia.Name = "txtTotalTransferencia"
        Me.txtTotalTransferencia.ReadOnly = True
        Me.txtTotalTransferencia.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalTransferencia.TabIndex = 18
        Me.txtTotalTransferencia.TabStop = False
        Me.txtTotalTransferencia.Text = "0.00"
        Me.txtTotalTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(9, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(197, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "TOTAL COMPROBANTES"
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
        Me.txtTotalComprobantes.LabelAsoc = Nothing
        Me.txtTotalComprobantes.Location = New System.Drawing.Point(221, 9)
        Me.txtTotalComprobantes.Name = "txtTotalComprobantes"
        Me.txtTotalComprobantes.ReadOnly = True
        Me.txtTotalComprobantes.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalComprobantes.TabIndex = 1
        Me.txtTotalComprobantes.TabStop = False
        Me.txtTotalComprobantes.Text = "0.00"
        Me.txtTotalComprobantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(355, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "__________________________________________________________"
        '
        'lblDescRecGral
        '
        Me.lblDescRecGral.AutoSize = True
        Me.lblDescRecGral.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescRecGral.LabelAsoc = Nothing
        Me.lblDescRecGral.Location = New System.Drawing.Point(12, 125)
        Me.lblDescRecGral.Name = "lblDescRecGral"
        Me.lblDescRecGral.Size = New System.Drawing.Size(146, 20)
        Me.lblDescRecGral.TabIndex = 5
        Me.lblDescRecGral.Text = "Cuentas Corrientes"
        Me.lblDescRecGral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttotalCC
        '
        Me.txttotalCC.BackColor = System.Drawing.SystemColors.Control
        Me.txttotalCC.BindearPropiedadControl = Nothing
        Me.txttotalCC.BindearPropiedadEntidad = Nothing
        Me.txttotalCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalCC.ForeColorFocus = System.Drawing.Color.Red
        Me.txttotalCC.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txttotalCC.Formato = "##0.00"
        Me.txttotalCC.IsDecimal = True
        Me.txttotalCC.IsNumber = True
        Me.txttotalCC.IsPK = False
        Me.txttotalCC.IsRequired = False
        Me.txttotalCC.Key = ""
        Me.txttotalCC.LabelAsoc = Me.lblDescRecGral
        Me.txttotalCC.Location = New System.Drawing.Point(223, 122)
        Me.txttotalCC.Name = "txttotalCC"
        Me.txttotalCC.ReadOnly = True
        Me.txttotalCC.Size = New System.Drawing.Size(140, 26)
        Me.txttotalCC.TabIndex = 6
        Me.txttotalCC.Text = "0.00"
        Me.txttotalCC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalReenvios
        '
        Me.lblTotalReenvios.AutoSize = True
        Me.lblTotalReenvios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalReenvios.LabelAsoc = Nothing
        Me.lblTotalReenvios.Location = New System.Drawing.Point(13, 230)
        Me.lblTotalReenvios.Name = "lblTotalReenvios"
        Me.lblTotalReenvios.Size = New System.Drawing.Size(75, 20)
        Me.lblTotalReenvios.TabIndex = 11
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
        Me.txtTotalReenvios.Location = New System.Drawing.Point(223, 227)
        Me.txtTotalReenvios.MaxLength = 30
        Me.txtTotalReenvios.Name = "txtTotalReenvios"
        Me.txtTotalReenvios.ReadOnly = True
        Me.txtTotalReenvios.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalReenvios.TabIndex = 12
        Me.txtTotalReenvios.TabStop = False
        Me.txtTotalReenvios.Text = "0.00"
        Me.txtTotalReenvios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalSubtotales
        '
        Me.lblTotalSubtotales.AutoSize = True
        Me.lblTotalSubtotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSubtotales.ForeColor = System.Drawing.Color.Red
        Me.lblTotalSubtotales.LabelAsoc = Nothing
        Me.lblTotalSubtotales.Location = New System.Drawing.Point(11, 277)
        Me.lblTotalSubtotales.Name = "lblTotalSubtotales"
        Me.lblTotalSubtotales.Size = New System.Drawing.Size(146, 20)
        Me.lblTotalSubtotales.TabIndex = 14
        Me.lblTotalSubtotales.Text = "SALDO GENERAL"
        '
        'lblTotalImpuestos
        '
        Me.lblTotalImpuestos.AutoSize = True
        Me.lblTotalImpuestos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalImpuestos.LabelAsoc = Nothing
        Me.lblTotalImpuestos.Location = New System.Drawing.Point(12, 195)
        Me.lblTotalImpuestos.Name = "lblTotalImpuestos"
        Me.lblTotalImpuestos.Size = New System.Drawing.Size(128, 20)
        Me.lblTotalImpuestos.TabIndex = 9
        Me.lblTotalImpuestos.Text = "Notas de Crédito"
        '
        'txtTotalSubtotales
        '
        Me.txtTotalSubtotales.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalSubtotales.BindearPropiedadControl = Nothing
        Me.txtTotalSubtotales.BindearPropiedadEntidad = Nothing
        Me.txtTotalSubtotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSubtotales.ForeColor = System.Drawing.Color.Red
        Me.txtTotalSubtotales.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotalSubtotales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotalSubtotales.Formato = "##0.00"
        Me.txtTotalSubtotales.IsDecimal = True
        Me.txtTotalSubtotales.IsNumber = True
        Me.txtTotalSubtotales.IsPK = False
        Me.txtTotalSubtotales.IsRequired = False
        Me.txtTotalSubtotales.Key = ""
        Me.txtTotalSubtotales.LabelAsoc = Nothing
        Me.txtTotalSubtotales.Location = New System.Drawing.Point(223, 270)
        Me.txtTotalSubtotales.Name = "txtTotalSubtotales"
        Me.txtTotalSubtotales.ReadOnly = True
        Me.txtTotalSubtotales.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalSubtotales.TabIndex = 15
        Me.txtTotalSubtotales.TabStop = False
        Me.txtTotalSubtotales.Text = "0.00"
        Me.txtTotalSubtotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalNeto
        '
        Me.lblTotalNeto.AutoSize = True
        Me.lblTotalNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNeto.LabelAsoc = Nothing
        Me.lblTotalNeto.Location = New System.Drawing.Point(13, 160)
        Me.lblTotalNeto.Name = "lblTotalNeto"
        Me.lblTotalNeto.Size = New System.Drawing.Size(73, 20)
        Me.lblTotalNeto.TabIndex = 7
        Me.lblTotalNeto.Text = "Cheques"
        '
        'lblTotalBruto
        '
        Me.lblTotalBruto.AutoSize = True
        Me.lblTotalBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBruto.LabelAsoc = Nothing
        Me.lblTotalBruto.Location = New System.Drawing.Point(12, 59)
        Me.lblTotalBruto.Name = "lblTotalBruto"
        Me.lblTotalBruto.Size = New System.Drawing.Size(105, 20)
        Me.lblTotalBruto.TabIndex = 3
        Me.lblTotalBruto.Text = "Total Efectivo"
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
        Me.txtTotalNC.LabelAsoc = Me.lblTotalImpuestos
        Me.txtTotalNC.Location = New System.Drawing.Point(223, 192)
        Me.txtTotalNC.Name = "txtTotalNC"
        Me.txtTotalNC.ReadOnly = True
        Me.txtTotalNC.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalNC.TabIndex = 10
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
        Me.txtTotalEfectivo.LabelAsoc = Me.lblTotalBruto
        Me.txtTotalEfectivo.Location = New System.Drawing.Point(223, 56)
        Me.txtTotalEfectivo.Name = "txtTotalEfectivo"
        Me.txtTotalEfectivo.ReadOnly = True
        Me.txtTotalEfectivo.Size = New System.Drawing.Size(140, 26)
        Me.txtTotalEfectivo.TabIndex = 4
        Me.txtTotalEfectivo.TabStop = False
        Me.txtTotalEfectivo.Text = "0.00"
        Me.txtTotalEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotalCheque
        '
        Me.txttotalCheque.BackColor = System.Drawing.SystemColors.Control
        Me.txttotalCheque.BindearPropiedadControl = Nothing
        Me.txttotalCheque.BindearPropiedadEntidad = Nothing
        Me.txttotalCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txttotalCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txttotalCheque.Formato = "##0.00"
        Me.txttotalCheque.IsDecimal = True
        Me.txttotalCheque.IsNumber = True
        Me.txttotalCheque.IsPK = False
        Me.txttotalCheque.IsRequired = False
        Me.txttotalCheque.Key = ""
        Me.txttotalCheque.LabelAsoc = Me.lblTotalNeto
        Me.txttotalCheque.Location = New System.Drawing.Point(223, 157)
        Me.txttotalCheque.Name = "txttotalCheque"
        Me.txttotalCheque.ReadOnly = True
        Me.txttotalCheque.Size = New System.Drawing.Size(140, 26)
        Me.txttotalCheque.TabIndex = 8
        Me.txttotalCheque.TabStop = False
        Me.txttotalCheque.Text = "0.00"
        Me.txttotalCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 248)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(355, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "__________________________________________________________"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 540)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(884, 22)
        Me.stsStado.TabIndex = 6
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(805, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tss1, Me.tsbImprimir, Me.tss2, Me.tsddListadoClientes, Me.tsddConsolidados, Me.tsddExportar, Me.tss3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(884, 29)
        Me.tstBarra.TabIndex = 7
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
        'tss1
        '
        Me.tss1.Name = "tss1"
        Me.tss1.Size = New System.Drawing.Size(6, 29)
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
        'tss2
        '
        Me.tss2.Name = "tss2"
        Me.tss2.Size = New System.Drawing.Size(6, 29)
        '
        'tsddListadoClientes
        '
        Me.tsddListadoClientes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbListadoClientes, Me.tsbListadoClientesConEnvases})
        Me.tsddListadoClientes.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsddListadoClientes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddListadoClientes.Name = "tsddListadoClientes"
        Me.tsddListadoClientes.Size = New System.Drawing.Size(146, 26)
        Me.tsddListadoClientes.Text = "Listados de Clientes"
        '
        'tsbListadoClientes
        '
        Me.tsbListadoClientes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbListadoClientes.Name = "tsbListadoClientes"
        Me.tsbListadoClientes.Size = New System.Drawing.Size(242, 22)
        Me.tsbListadoClientes.Text = "&Listado de Clientes Estandar"
        '
        'tsbListadoClientesConEnvases
        '
        Me.tsbListadoClientesConEnvases.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbListadoClientesConEnvases.Name = "tsbListadoClientesConEnvases"
        Me.tsbListadoClientesConEnvases.Size = New System.Drawing.Size(242, 22)
        Me.tsbListadoClientesConEnvases.Text = "&Listado de Clientes Con Envases"
        '
        'tsddConsolidados
        '
        Me.tsddConsolidados.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbConsolidadoCarga, Me.tsbConsolidadoCargaTipoOperacion})
        Me.tsddConsolidados.Image = Global.Eniac.Win.My.Resources.Resources.printer
        Me.tsddConsolidados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddConsolidados.Name = "tsddConsolidados"
        Me.tsddConsolidados.Size = New System.Drawing.Size(164, 26)
        Me.tsddConsolidados.Text = "Consolidados de Carga"
        '
        'tsbConsolidadoCarga
        '
        Me.tsbConsolidadoCarga.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsolidadoCarga.Name = "tsbConsolidadoCarga"
        Me.tsbConsolidadoCarga.Size = New System.Drawing.Size(255, 22)
        Me.tsbConsolidadoCarga.Text = "&Consolidado Carga"
        Me.tsbConsolidadoCarga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsbConsolidadoCargaTipoOperacion
        '
        Me.tsbConsolidadoCargaTipoOperacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbConsolidadoCargaTipoOperacion.Name = "tsbConsolidadoCargaTipoOperacion"
        Me.tsbConsolidadoCargaTipoOperacion.Size = New System.Drawing.Size(255, 22)
        Me.tsbConsolidadoCargaTipoOperacion.Text = "Consolidado Carga por Tipo &Oper."
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
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(109, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
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
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
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
        Me.grbFiltros.Controls.Add(Me.chbFormaPago)
        Me.grbFiltros.Controls.Add(Me.cmbFormaPago)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.bscCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombre)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(856, 122)
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
        Me.chbTransportista.Location = New System.Drawing.Point(490, 22)
        Me.chbTransportista.Name = "chbTransportista"
        Me.chbTransportista.Size = New System.Drawing.Size(87, 17)
        Me.chbTransportista.TabIndex = 31
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
        Me.bscTransportista.Location = New System.Drawing.Point(608, 20)
        Me.bscTransportista.Margin = New System.Windows.Forms.Padding(4)
        Me.bscTransportista.MaxLengh = "32767"
        Me.bscTransportista.Name = "bscTransportista"
        Me.bscTransportista.Permitido = True
        Me.bscTransportista.Selecciono = False
        Me.bscTransportista.Size = New System.Drawing.Size(240, 23)
        Me.bscTransportista.TabIndex = 30
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
        Me.chbNumero.Location = New System.Drawing.Point(490, 99)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(104, 17)
        Me.chbNumero.TabIndex = 7
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
        Me.txtNumero.Location = New System.Drawing.Point(609, 96)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(73, 20)
        Me.txtNumero.TabIndex = 8
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
        Me.chbUsuario.Location = New System.Drawing.Point(490, 73)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 16
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
        Me.cmbUsuario.Location = New System.Drawing.Point(609, 69)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(115, 21)
        Me.cmbUsuario.TabIndex = 17
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
        Me.chbFormaPago.Location = New System.Drawing.Point(239, 96)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFormaPago.TabIndex = 24
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
        Me.cmbFormaPago.Location = New System.Drawing.Point(340, 94)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(119, 21)
        Me.cmbFormaPago.TabIndex = 25
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
        Me.chbVendedor.Location = New System.Drawing.Point(12, 96)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 22
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
        Me.cmbVendedor.Location = New System.Drawing.Point(87, 94)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(129, 21)
        Me.cmbVendedor.TabIndex = 23
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(75, 60)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 12
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(72, 44)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 13
        Me.lblCodigoCliente.Text = "Código"
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
        Me.bscCliente.Location = New System.Drawing.Point(172, 60)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 14
        Me.bscCliente.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(169, 44)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Nombre"
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
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(609, 44)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(115, 21)
        Me.cmbTiposComprobantes.TabIndex = 6
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(746, 68)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(102, 45)
        Me.btnConsultar.TabIndex = 28
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.chbCliente.Location = New System.Drawing.Point(13, 63)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 9
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
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
        Me.chbTipoComprobante.Location = New System.Drawing.Point(490, 47)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 5
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(13, 23)
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
        Me.dtpHasta.Location = New System.Drawing.Point(310, 22)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(273, 25)
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
        Me.dtpDesde.Location = New System.Drawing.Point(144, 21)
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
        'ConsultarRepartos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 562)
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
        CType(Me.ugProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpDetalle.ResumeLayout(False)
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpComprobantes.ResumeLayout(False)
        CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpProductos.ResumeLayout(False)
        Me.tbpProductos.PerformLayout()
        Me.tbpConsolidadoPorModelo.ResumeLayout(False)
        CType(Me.ugConsolidadoPorModelo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpGastos.ResumeLayout(False)
        CType(Me.ugGastos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpProductosSinDescargo.ResumeLayout(False)
        CType(Me.ugvProductosSinDescargar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpResumen.ResumeLayout(False)
        Me.grbIVAs.ResumeLayout(False)
        Me.grbIVAs.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Private WithEvents tss3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents tbpDetalle As System.Windows.Forms.TabPage
   Friend WithEvents tbpProductos As System.Windows.Forms.TabPage
   Friend WithEvents ugProductos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents ugComprobantes As Infragistics.Win.UltraWinGrid.UltraGrid
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
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents lblOrdenarPor As System.Windows.Forms.Label
   Friend WithEvents optOrdenarPorNombre As System.Windows.Forms.RadioButton
   Friend WithEvents optOrdenarPorCodigo As System.Windows.Forms.RadioButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbTransportista As Eniac.Controles.CheckBox
   Friend WithEvents bscTransportista As Eniac.Controles.Buscador
   Friend WithEvents tbpConsolidadoPorModelo As System.Windows.Forms.TabPage
   Friend WithEvents ugConsolidadoPorModelo As Eniac.Win.UltraGridEditable
   Friend WithEvents tbpGastos As System.Windows.Forms.TabPage
   Friend WithEvents ugGastos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tbpResumen As System.Windows.Forms.TabPage
   Friend WithEvents cmdImprimirResumen As System.Windows.Forms.Button
   Friend WithEvents grbIVAs As System.Windows.Forms.GroupBox
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents txtTotalComprobantes As Eniac.Controles.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents lblDescRecGral As Eniac.Controles.Label
   Friend WithEvents txttotalCC As Eniac.Controles.TextBox
   Friend WithEvents lblTotalReenvios As Eniac.Controles.Label
   Friend WithEvents txtTotalReenvios As Eniac.Controles.TextBox
   Friend WithEvents lblTotalSubtotales As Eniac.Controles.Label
   Friend WithEvents lblTotalImpuestos As Eniac.Controles.Label
   Friend WithEvents txtTotalSubtotales As Eniac.Controles.TextBox
   Friend WithEvents lblTotalNeto As Eniac.Controles.Label
   Friend WithEvents lblTotalBruto As Eniac.Controles.Label
   Friend WithEvents txtTotalNC As Eniac.Controles.TextBox
   Friend WithEvents txtTotalEfectivo As Eniac.Controles.TextBox
   Friend WithEvents txttotalCheque As Eniac.Controles.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents tbpProductosSinDescargo As System.Windows.Forms.TabPage
   Friend WithEvents ugvProductosSinDescargar As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tsddListadoClientes As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsddConsolidados As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsbListadoClientes As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsbListadoClientesConEnvases As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsbConsolidadoCarga As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsbConsolidadoCargaTipoOperacion As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents btnImprimirDetallado As System.Windows.Forms.Button
   Friend WithEvents lblTotalTransferencia As Controles.Label
   Friend WithEvents txtTotalTransferencia As Controles.TextBox
End Class
