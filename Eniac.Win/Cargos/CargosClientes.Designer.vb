<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargosClientes
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CargosClientes))
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
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selec")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCargo")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("cantidad")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioListaNuevo")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1Nuevo")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MontoNuevo")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteNuevo")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim RowLayout1 As Infragistics.Win.UltraWinGrid.RowLayout = New Infragistics.Win.UltraWinGrid.RowLayout("Default")
      Dim RowLayoutColumnInfo1 As Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo = New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo(Infragistics.Win.UltraWinGrid.RowLayoutColumnInfoContext.Column, "Selec", -1, Infragistics.Win.DefaultableBoolean.[False])
      Dim RowLayoutColumnInfo2 As Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo = New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo(Infragistics.Win.UltraWinGrid.RowLayoutColumnInfoContext.Column, "NombreCargo", -1, Infragistics.Win.DefaultableBoolean.[False])
      Dim RowLayoutColumnInfo3 As Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo = New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo(Infragistics.Win.UltraWinGrid.RowLayoutColumnInfoContext.Column, "cantidad", -1, Infragistics.Win.DefaultableBoolean.[False])
      Dim RowLayoutColumnInfo4 As Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo = New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo(Infragistics.Win.UltraWinGrid.RowLayoutColumnInfoContext.Column, "PrecioLista", -1, Infragistics.Win.DefaultableBoolean.[False])
      Dim RowLayoutColumnInfo5 As Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo = New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo(Infragistics.Win.UltraWinGrid.RowLayoutColumnInfoContext.Column, "DescuentoRecargoPorc1", -1, Infragistics.Win.DefaultableBoolean.[False])
      Dim RowLayoutColumnInfo6 As Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo = New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo(Infragistics.Win.UltraWinGrid.RowLayoutColumnInfoContext.Column, "Monto", -1, Infragistics.Win.DefaultableBoolean.[False])
      Dim RowLayoutColumnInfo7 As Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo = New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo(Infragistics.Win.UltraWinGrid.RowLayoutColumnInfoContext.Column, "importeTotal", -1, Infragistics.Win.DefaultableBoolean.[False])
      Dim RowLayoutColumnInfo8 As Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo = New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo(Infragistics.Win.UltraWinGrid.RowLayoutColumnInfoContext.Column, "observaciones", -1, Infragistics.Win.DefaultableBoolean.[False])
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodoLiquidacion")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCargo")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteSinIVA")
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc1")
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorcGral")
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioListaSinIVA")
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoComprobante")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubSubRubro")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc")
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorcGral")
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaImpuesto")
        Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotalNeto")
        Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteImpuesto")
        Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteImpuestoInterno")
        Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
        Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
        Dim Appearance72 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCentroCosto")
        Dim Appearance73 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCentroCosto")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DetalleProducto")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim Appearance74 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
        Dim Appearance75 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VerEstandar")
        Dim Appearance76 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imprimir")
        Dim Appearance77 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormula")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFormula")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantComponentes")
        Dim Appearance78 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance79 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja")
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
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.lblNumeroInmueble = New Eniac.Controles.Label()
        Me.txtCodigoCliente = New Eniac.Controles.TextBox()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.ugClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbcCargos = New System.Windows.Forms.TabControl()
        Me.tbpCargos = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chbSoloConImportes = New Eniac.Controles.CheckBox()
        Me.ugCargos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label2 = New Eniac.Controles.Label()
        Me.cmbTiposLiquidacion = New Eniac.Controles.ComboBox()
        Me.chbObservaciones = New Eniac.Controles.CheckBox()
        Me.tbpObservaciones = New System.Windows.Forms.TabPage()
        Me.grbObservaciones = New System.Windows.Forms.GroupBox()
        Me.dgvObservaciones = New Eniac.Controles.DataGridView()
        Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Linea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEliminarObservacion = New Eniac.Controles.Button()
        Me.btnInsertarObservacion = New Eniac.Controles.Button()
        Me.bscObservacionDetalle = New Eniac.Controles.Buscador()
        Me.lblObservacionDetalle = New Eniac.Controles.Label()
        Me.tbcLiquidacion = New System.Windows.Forms.TabControl()
        Me.tbpCarga = New System.Windows.Forms.TabPage()
        Me.pnlSplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tbpResumen = New System.Windows.Forms.TabPage()
        Me.rdbMontoSinCambiar = New Eniac.Controles.RadioButton()
        Me.rdbMontoDesdeLista = New Eniac.Controles.RadioButton()
        Me.rdbMontoSiMismo = New Eniac.Controles.RadioButton()
        Me.btnCalcular = New Eniac.Controles.Button()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtAjustePrecioLista = New Eniac.Controles.TextBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.txtAjusteMonto = New Eniac.Controles.TextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.ugResumen = New Eniac.Win.UltraGridEditable()
        Me.tbpHistorial = New System.Windows.Forms.TabPage()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.lblVieneDeTab = New Eniac.Controles.Label()
        Me.Label4 = New Eniac.Controles.Label()
        Me.bscNombreClienteHistorial = New Eniac.Controles.Buscador2()
        Me.lblNombreCliente = New Eniac.Controles.Label()
        Me.bscCodigoClienteHistorial = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.lblPeriodo = New Eniac.Controles.Label()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.btnConsultar2 = New Eniac.Controles.Button()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.tbpFacturacion = New System.Windows.Forms.TabPage()
        Me.ugDetalleFacturacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblVieneDeTabFac = New Eniac.Controles.Label()
        Me.Label9 = New Eniac.Controles.Label()
        Me.chkExpandAllTwo = New System.Windows.Forms.CheckBox()
        Me.Label8 = New Eniac.Controles.Label()
        Me.DtpDesdeFact = New Eniac.Controles.DateTimePicker()
        Me.Label6 = New Eniac.Controles.Label()
        Me.BtnConsultar3 = New Eniac.Controles.Button()
        Me.bscCodigoClienteFacturacion = New Eniac.Controles.Buscador2()
        Me.Label7 = New Eniac.Controles.Label()
        Me.Label5 = New Eniac.Controles.Label()
        Me.bscNombreClienteFacturacion = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.DtpHastaFact = New Eniac.Controles.DateTimePicker()
        Me.grpFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbTipoCliente = New Eniac.Controles.ComboBox()
        Me.chkTipoCliente = New Eniac.Controles.CheckBox()
        Me.llbCliente = New Eniac.Controles.LinkLabel()
        Me.Label10 = New Eniac.Controles.Label()
        Me.lblActivo = New Eniac.Controles.Label()
        Me.cmbActivo = New Eniac.Controles.ComboBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscNombreCliente = New Eniac.Controles.Buscador2()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.txtPcs = New System.Windows.Forms.TextBox()
        Me.cmbCobrador = New Eniac.Controles.ComboBox()
        Me.chbZonaGeografica = New System.Windows.Forms.CheckBox()
        Me.cmbFiltrosPcs = New Eniac.Controles.ComboBox()
        Me.chbCategoria = New Eniac.Controles.CheckBox()
        Me.chbCantidadPcs = New Eniac.Controles.CheckBox()
        Me.chbCobrador = New Eniac.Controles.CheckBox()
        Me.cmbCategorias = New Eniac.Controles.ComboBox()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.tstBarra.SuspendLayout()
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.tbcCargos.SuspendLayout()
        Me.tbpCargos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ugCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpObservaciones.SuspendLayout()
        Me.grbObservaciones.SuspendLayout()
        CType(Me.dgvObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcLiquidacion.SuspendLayout()
        Me.tbpCarga.SuspendLayout()
        CType(Me.pnlSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSplitContainer1.Panel1.SuspendLayout()
        Me.pnlSplitContainer1.Panel2.SuspendLayout()
        Me.pnlSplitContainer1.SuspendLayout()
        Me.tbpResumen.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpHistorial.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbConsultar.SuspendLayout()
        Me.tbpFacturacion.SuspendLayout()
        CType(Me.ugDetalleFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grpFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbGrabar, Me.ToolStripSeparator4, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.ToolStripSeparator5, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(967, 31)
        Me.tstBarra.TabIndex = 44
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(106, 28)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(93, 28)
        Me.tsbGrabar.Text = "Grabar (F4)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(81, 28)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 28)
        Me.tsddExportar.Text = "&Exportar"
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(99, 28)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(67, 28)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'lblNumeroInmueble
        '
        Me.lblNumeroInmueble.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNumeroInmueble.AutoSize = True
        Me.lblNumeroInmueble.LabelAsoc = Nothing
        Me.lblNumeroInmueble.Location = New System.Drawing.Point(813, 9)
        Me.lblNumeroInmueble.Name = "lblNumeroInmueble"
        Me.lblNumeroInmueble.Size = New System.Drawing.Size(42, 13)
        Me.lblNumeroInmueble.TabIndex = 47
        Me.lblNumeroInmueble.Text = "Cliente:"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodigoCliente.BackColor = System.Drawing.Color.PaleGreen
        Me.txtCodigoCliente.BindearPropiedadControl = Nothing
        Me.txtCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.txtCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoCliente.Formato = ""
        Me.txtCodigoCliente.IsDecimal = False
        Me.txtCodigoCliente.IsNumber = False
        Me.txtCodigoCliente.IsPK = False
        Me.txtCodigoCliente.IsRequired = False
        Me.txtCodigoCliente.Key = ""
        Me.txtCodigoCliente.LabelAsoc = Me.lblNumeroInmueble
        Me.txtCodigoCliente.Location = New System.Drawing.Point(860, 4)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.ReadOnly = True
        Me.txtCodigoCliente.Size = New System.Drawing.Size(72, 21)
        Me.txtCodigoCliente.TabIndex = 48
        Me.txtCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbTodos
        '
        Me.chbTodos.AutoSize = True
        Me.chbTodos.BindearPropiedadControl = Nothing
        Me.chbTodos.BindearPropiedadEntidad = Nothing
        Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTodos.Image = CType(resources.GetObject("chbTodos.Image"), System.Drawing.Image)
        Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbTodos.IsPK = False
        Me.chbTodos.IsRequired = False
        Me.chbTodos.Key = Nothing
        Me.chbTodos.LabelAsoc = Nothing
        Me.chbTodos.Location = New System.Drawing.Point(482, 2)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(125, 24)
        Me.chbTodos.TabIndex = 49
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'ugClientes
        '
        Me.ugClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugClientes.DisplayLayout.Appearance = Appearance1
        Me.ugClientes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugClientes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugClientes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugClientes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugClientes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugClientes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugClientes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugClientes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugClientes.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugClientes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugClientes.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugClientes.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugClientes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugClientes.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugClientes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugClientes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugClientes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugClientes.Location = New System.Drawing.Point(4, 24)
        Me.ugClientes.Name = "ugClientes"
        Me.ugClientes.Size = New System.Drawing.Size(949, 175)
        Me.ugClientes.TabIndex = 50
        Me.ugClientes.Text = "UltraGrid1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ugClientes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(953, 202)
        Me.Panel1.TabIndex = 0
        '
        'tbcCargos
        '
        Me.tbcCargos.Controls.Add(Me.tbpCargos)
        Me.tbcCargos.Controls.Add(Me.tbpObservaciones)
        Me.tbcCargos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcCargos.Location = New System.Drawing.Point(0, 0)
        Me.tbcCargos.Name = "tbcCargos"
        Me.tbcCargos.SelectedIndex = 0
        Me.tbcCargos.Size = New System.Drawing.Size(953, 194)
        Me.tbcCargos.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tbcCargos.TabIndex = 7
        '
        'tbpCargos
        '
        Me.tbpCargos.Controls.Add(Me.Panel2)
        Me.tbpCargos.Location = New System.Drawing.Point(4, 22)
        Me.tbpCargos.Name = "tbpCargos"
        Me.tbpCargos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCargos.Size = New System.Drawing.Size(945, 168)
        Me.tbpCargos.TabIndex = 0
        Me.tbpCargos.Text = "Cargos"
        Me.tbpCargos.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chbSoloConImportes)
        Me.Panel2.Controls.Add(Me.chbTodos)
        Me.Panel2.Controls.Add(Me.ugCargos)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cmbTiposLiquidacion)
        Me.Panel2.Controls.Add(Me.chbObservaciones)
        Me.Panel2.Controls.Add(Me.lblNumeroInmueble)
        Me.Panel2.Controls.Add(Me.txtCodigoCliente)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(939, 162)
        Me.Panel2.TabIndex = 1
        '
        'chbSoloConImportes
        '
        Me.chbSoloConImportes.AutoSize = True
        Me.chbSoloConImportes.BindearPropiedadControl = Nothing
        Me.chbSoloConImportes.BindearPropiedadEntidad = Nothing
        Me.chbSoloConImportes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSoloConImportes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSoloConImportes.IsPK = False
        Me.chbSoloConImportes.IsRequired = False
        Me.chbSoloConImportes.Key = Nothing
        Me.chbSoloConImportes.LabelAsoc = Nothing
        Me.chbSoloConImportes.Location = New System.Drawing.Point(341, 6)
        Me.chbSoloConImportes.Name = "chbSoloConImportes"
        Me.chbSoloConImportes.Size = New System.Drawing.Size(130, 17)
        Me.chbSoloConImportes.TabIndex = 53
        Me.chbSoloConImportes.Text = "Ver Solo con Importes"
        Me.chbSoloConImportes.UseVisualStyleBackColor = True
        '
        'ugCargos
        '
        Me.ugCargos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugCargos.DisplayLayout.Appearance = Appearance13
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.RowLayoutColumnInfo.OriginX = 0
        UltraGridColumn1.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn1.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(38, 0)
        UltraGridColumn1.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn1.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn1.Width = 78
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.Header.Caption = "Nombre Cargo"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn2.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn2.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(105, 0)
        UltraGridColumn2.RowLayoutColumnInfo.SpanX = 3
        UltraGridColumn2.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn2.Width = 234
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance14
        UltraGridColumn3.Header.Caption = "Cant."
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.RowLayoutColumnInfo.OriginX = 9
        UltraGridColumn3.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn3.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(47, 0)
        UltraGridColumn3.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn3.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn3.Width = 59
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance15
        UltraGridColumn4.Header.Caption = "Lista"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.RowLayoutColumnInfo.OriginX = 5
        UltraGridColumn4.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn4.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(52, 0)
        UltraGridColumn4.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn4.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn4.Width = 74
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance16
        UltraGridColumn5.Header.Caption = "%"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.RowLayoutColumnInfo.OriginX = 7
        UltraGridColumn5.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn5.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(40, 0)
        UltraGridColumn5.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn5.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn5.Width = 56
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn6.Header.Caption = "Precio"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.RowLayoutColumnInfo.OriginX = 11
        UltraGridColumn6.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn6.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(41, 0)
        UltraGridColumn6.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn6.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn6.Width = 80
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn7.Header.Caption = "Monto"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.RowLayoutColumnInfo.OriginX = 13
        UltraGridColumn7.RowLayoutColumnInfo.OriginY = 0
        UltraGridColumn7.RowLayoutColumnInfo.SpanX = 2
        UltraGridColumn7.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn7.Width = 80
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.Header.Caption = "Observaciones"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.MaxLength = 60
        UltraGridColumn8.RowLayoutColumnInfo.OriginX = 2
        UltraGridColumn8.RowLayoutColumnInfo.OriginY = 2
        UltraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(335, 0)
        UltraGridColumn8.RowLayoutColumnInfo.SpanX = 13
        UltraGridColumn8.RowLayoutColumnInfo.SpanY = 2
        UltraGridColumn8.Width = 244
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
        RowLayoutColumnInfo1.OriginX = 0
        RowLayoutColumnInfo1.OriginY = 0
        RowLayoutColumnInfo1.PreferredCellSize = New System.Drawing.Size(38, 0)
        RowLayoutColumnInfo1.SpanX = 2
        RowLayoutColumnInfo1.SpanY = 2
        RowLayoutColumnInfo2.OriginX = 2
        RowLayoutColumnInfo2.OriginY = 0
        RowLayoutColumnInfo2.PreferredCellSize = New System.Drawing.Size(105, 0)
        RowLayoutColumnInfo2.SpanX = 3
        RowLayoutColumnInfo2.SpanY = 2
        RowLayoutColumnInfo3.OriginX = 9
        RowLayoutColumnInfo3.OriginY = 0
        RowLayoutColumnInfo3.PreferredCellSize = New System.Drawing.Size(47, 0)
        RowLayoutColumnInfo3.SpanX = 2
        RowLayoutColumnInfo3.SpanY = 2
        RowLayoutColumnInfo4.OriginX = 5
        RowLayoutColumnInfo4.OriginY = 0
        RowLayoutColumnInfo4.PreferredCellSize = New System.Drawing.Size(52, 0)
        RowLayoutColumnInfo4.SpanX = 2
        RowLayoutColumnInfo4.SpanY = 2
        RowLayoutColumnInfo5.OriginX = 7
        RowLayoutColumnInfo5.OriginY = 0
        RowLayoutColumnInfo5.PreferredCellSize = New System.Drawing.Size(40, 0)
        RowLayoutColumnInfo5.SpanX = 2
        RowLayoutColumnInfo5.SpanY = 2
        RowLayoutColumnInfo6.OriginX = 11
        RowLayoutColumnInfo6.OriginY = 0
        RowLayoutColumnInfo6.PreferredCellSize = New System.Drawing.Size(41, 0)
        RowLayoutColumnInfo6.SpanX = 2
        RowLayoutColumnInfo6.SpanY = 2
        RowLayoutColumnInfo7.OriginX = 13
        RowLayoutColumnInfo7.OriginY = 0
        RowLayoutColumnInfo7.SpanX = 2
        RowLayoutColumnInfo7.SpanY = 2
        RowLayoutColumnInfo8.OriginX = 2
        RowLayoutColumnInfo8.OriginY = 2
        RowLayoutColumnInfo8.PreferredCellSize = New System.Drawing.Size(335, 0)
        RowLayoutColumnInfo8.SpanX = 13
        RowLayoutColumnInfo8.SpanY = 2
        RowLayout1.ColumnInfos.AddRange(New Infragistics.Win.UltraWinGrid.RowLayoutColumnInfo() {RowLayoutColumnInfo1, RowLayoutColumnInfo2, RowLayoutColumnInfo3, RowLayoutColumnInfo4, RowLayoutColumnInfo5, RowLayoutColumnInfo6, RowLayoutColumnInfo7, RowLayoutColumnInfo8})
        RowLayout1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout
        UltraGridBand1.RowLayouts.AddRange(New Infragistics.Win.UltraWinGrid.RowLayout() {RowLayout1})
        Me.ugCargos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugCargos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCargos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCargos.DisplayLayout.GroupByBox.Appearance = Appearance17
        Appearance18.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCargos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance18
        Me.ugCargos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance19.BackColor2 = System.Drawing.SystemColors.Control
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCargos.DisplayLayout.GroupByBox.PromptAppearance = Appearance19
        Me.ugCargos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugCargos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Appearance20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugCargos.DisplayLayout.Override.ActiveCellAppearance = Appearance20
        Appearance21.BackColor = System.Drawing.SystemColors.Highlight
        Appearance21.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugCargos.DisplayLayout.Override.ActiveRowAppearance = Appearance21
        Me.ugCargos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugCargos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugCargos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugCargos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Me.ugCargos.DisplayLayout.Override.CardAreaAppearance = Appearance22
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Appearance23.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugCargos.DisplayLayout.Override.CellAppearance = Appearance23
        Me.ugCargos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugCargos.DisplayLayout.Override.CellPadding = 0
        Appearance24.BackColor = System.Drawing.SystemColors.Control
        Appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance24.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCargos.DisplayLayout.Override.GroupByRowAppearance = Appearance24
        Appearance25.TextHAlignAsString = "Left"
        Me.ugCargos.DisplayLayout.Override.HeaderAppearance = Appearance25
        Me.ugCargos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugCargos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.BorderColor = System.Drawing.Color.Silver
        Me.ugCargos.DisplayLayout.Override.RowAppearance = Appearance26
        Me.ugCargos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugCargos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance27
        Me.ugCargos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugCargos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugCargos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugCargos.Location = New System.Drawing.Point(4, 29)
        Me.ugCargos.Name = "ugCargos"
        Me.ugCargos.Size = New System.Drawing.Size(930, 133)
        Me.ugCargos.TabIndex = 55
        Me.ugCargos.Text = "UltraGrid2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(5, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Tipo Liquidacion"
        '
        'cmbTiposLiquidacion
        '
        Me.cmbTiposLiquidacion.BindearPropiedadControl = ""
        Me.cmbTiposLiquidacion.BindearPropiedadEntidad = ""
        Me.cmbTiposLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposLiquidacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposLiquidacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposLiquidacion.FormattingEnabled = True
        Me.cmbTiposLiquidacion.IsPK = False
        Me.cmbTiposLiquidacion.IsRequired = True
        Me.cmbTiposLiquidacion.Key = Nothing
        Me.cmbTiposLiquidacion.LabelAsoc = Nothing
        Me.cmbTiposLiquidacion.Location = New System.Drawing.Point(93, 4)
        Me.cmbTiposLiquidacion.Name = "cmbTiposLiquidacion"
        Me.cmbTiposLiquidacion.Size = New System.Drawing.Size(120, 21)
        Me.cmbTiposLiquidacion.TabIndex = 53
        '
        'chbObservaciones
        '
        Me.chbObservaciones.AutoSize = True
        Me.chbObservaciones.BindearPropiedadControl = Nothing
        Me.chbObservaciones.BindearPropiedadEntidad = Nothing
        Me.chbObservaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.chbObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbObservaciones.IsPK = False
        Me.chbObservaciones.IsRequired = False
        Me.chbObservaciones.Key = Nothing
        Me.chbObservaciones.LabelAsoc = Nothing
        Me.chbObservaciones.Location = New System.Drawing.Point(219, 6)
        Me.chbObservaciones.Name = "chbObservaciones"
        Me.chbObservaciones.Size = New System.Drawing.Size(116, 17)
        Me.chbObservaciones.TabIndex = 52
        Me.chbObservaciones.Text = "Ver Observaciones"
        Me.chbObservaciones.UseVisualStyleBackColor = True
        '
        'tbpObservaciones
        '
        Me.tbpObservaciones.Controls.Add(Me.grbObservaciones)
        Me.tbpObservaciones.Location = New System.Drawing.Point(4, 22)
        Me.tbpObservaciones.Name = "tbpObservaciones"
        Me.tbpObservaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpObservaciones.Size = New System.Drawing.Size(945, 168)
        Me.tbpObservaciones.TabIndex = 1
        Me.tbpObservaciones.Text = "Observaciones"
        Me.tbpObservaciones.UseVisualStyleBackColor = True
        '
        'grbObservaciones
        '
        Me.grbObservaciones.Controls.Add(Me.dgvObservaciones)
        Me.grbObservaciones.Controls.Add(Me.btnEliminarObservacion)
        Me.grbObservaciones.Controls.Add(Me.btnInsertarObservacion)
        Me.grbObservaciones.Controls.Add(Me.bscObservacionDetalle)
        Me.grbObservaciones.Controls.Add(Me.lblObservacionDetalle)
        Me.grbObservaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbObservaciones.Location = New System.Drawing.Point(3, 3)
        Me.grbObservaciones.Name = "grbObservaciones"
        Me.grbObservaciones.Size = New System.Drawing.Size(939, 162)
        Me.grbObservaciones.TabIndex = 6
        Me.grbObservaciones.TabStop = False
        Me.grbObservaciones.Text = "Observaciones Detalle"
        '
        'dgvObservaciones
        '
        Me.dgvObservaciones.AllowUserToAddRows = False
        Me.dgvObservaciones.AllowUserToDeleteRows = False
        Me.dgvObservaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvObservaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvObservaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvObservaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSucursal, Me.IdCliente, Me.Linea, Me.Observacion, Me.Usuario, Me.Password})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvObservaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvObservaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvObservaciones.Location = New System.Drawing.Point(8, 54)
        Me.dgvObservaciones.MultiSelect = False
        Me.dgvObservaciones.Name = "dgvObservaciones"
        Me.dgvObservaciones.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvObservaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvObservaciones.RowHeadersVisible = False
        Me.dgvObservaciones.RowHeadersWidth = 10
        Me.dgvObservaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvObservaciones.Size = New System.Drawing.Size(925, 102)
        Me.dgvObservaciones.TabIndex = 87
        '
        'IdSucursal
        '
        Me.IdSucursal.DataPropertyName = "IdSucursal"
        Me.IdSucursal.HeaderText = "IdSucursal"
        Me.IdSucursal.Name = "IdSucursal"
        Me.IdSucursal.ReadOnly = True
        Me.IdSucursal.Visible = False
        '
        'IdCliente
        '
        Me.IdCliente.DataPropertyName = "IdCliente"
        Me.IdCliente.HeaderText = "IdCliente"
        Me.IdCliente.Name = "IdCliente"
        Me.IdCliente.ReadOnly = True
        Me.IdCliente.Visible = False
        '
        'Linea
        '
        Me.Linea.DataPropertyName = "Linea"
        Me.Linea.HeaderText = "Linea"
        Me.Linea.Name = "Linea"
        Me.Linea.ReadOnly = True
        Me.Linea.Visible = False
        '
        'Observacion
        '
        Me.Observacion.DataPropertyName = "Observacion"
        Me.Observacion.HeaderText = "Observacion"
        Me.Observacion.Name = "Observacion"
        Me.Observacion.ReadOnly = True
        Me.Observacion.Width = 785
        '
        'Usuario
        '
        Me.Usuario.DataPropertyName = "Usuario"
        Me.Usuario.HeaderText = "Usuario"
        Me.Usuario.Name = "Usuario"
        Me.Usuario.ReadOnly = True
        Me.Usuario.Visible = False
        '
        'Password
        '
        Me.Password.DataPropertyName = "Password"
        Me.Password.HeaderText = "Password"
        Me.Password.Name = "Password"
        Me.Password.ReadOnly = True
        Me.Password.Visible = False
        '
        'btnEliminarObservacion
        '
        Me.btnEliminarObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarObservacion.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminarObservacion.Location = New System.Drawing.Point(896, 11)
        Me.btnEliminarObservacion.Name = "btnEliminarObservacion"
        Me.btnEliminarObservacion.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminarObservacion.TabIndex = 86
        Me.btnEliminarObservacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarObservacion.UseVisualStyleBackColor = True
        '
        'btnInsertarObservacion
        '
        Me.btnInsertarObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarObservacion.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertarObservacion.Location = New System.Drawing.Point(857, 11)
        Me.btnInsertarObservacion.Name = "btnInsertarObservacion"
        Me.btnInsertarObservacion.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertarObservacion.TabIndex = 85
        Me.btnInsertarObservacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarObservacion.UseVisualStyleBackColor = True
        '
        'bscObservacionDetalle
        '
        Me.bscObservacionDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscObservacionDetalle.AyudaAncho = 600
        Me.bscObservacionDetalle.BindearPropiedadControl = Nothing
        Me.bscObservacionDetalle.BindearPropiedadEntidad = Nothing
        Me.bscObservacionDetalle.ColumnasAlineacion = Nothing
        Me.bscObservacionDetalle.ColumnasAncho = Nothing
        Me.bscObservacionDetalle.ColumnasFormato = Nothing
        Me.bscObservacionDetalle.ColumnasOcultas = Nothing
        Me.bscObservacionDetalle.ColumnasTitulos = Nothing
        Me.bscObservacionDetalle.Datos = Nothing
        Me.bscObservacionDetalle.FilaDevuelta = Nothing
        Me.bscObservacionDetalle.ForeColorFocus = System.Drawing.Color.Red
        Me.bscObservacionDetalle.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscObservacionDetalle.IsDecimal = False
        Me.bscObservacionDetalle.IsNumber = False
        Me.bscObservacionDetalle.IsPK = False
        Me.bscObservacionDetalle.IsRequired = False
        Me.bscObservacionDetalle.Key = ""
        Me.bscObservacionDetalle.LabelAsoc = Me.lblObservacionDetalle
        Me.bscObservacionDetalle.Location = New System.Drawing.Point(8, 19)
        Me.bscObservacionDetalle.MaxLengh = "100"
        Me.bscObservacionDetalle.Name = "bscObservacionDetalle"
        Me.bscObservacionDetalle.Permitido = True
        Me.bscObservacionDetalle.Selecciono = False
        Me.bscObservacionDetalle.Size = New System.Drawing.Size(835, 20)
        Me.bscObservacionDetalle.TabIndex = 84
        Me.bscObservacionDetalle.Titulo = Nothing
        '
        'lblObservacionDetalle
        '
        Me.lblObservacionDetalle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblObservacionDetalle.AutoSize = True
        Me.lblObservacionDetalle.LabelAsoc = Nothing
        Me.lblObservacionDetalle.Location = New System.Drawing.Point(81, 26)
        Me.lblObservacionDetalle.Name = "lblObservacionDetalle"
        Me.lblObservacionDetalle.Size = New System.Drawing.Size(44, 13)
        Me.lblObservacionDetalle.TabIndex = 83
        Me.lblObservacionDetalle.Text = "Observ."
        '
        'tbcLiquidacion
        '
        Me.tbcLiquidacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcLiquidacion.Controls.Add(Me.tbpCarga)
        Me.tbcLiquidacion.Controls.Add(Me.tbpResumen)
        Me.tbcLiquidacion.Controls.Add(Me.tbpHistorial)
        Me.tbcLiquidacion.Controls.Add(Me.tbpFacturacion)
        Me.tbcLiquidacion.Location = New System.Drawing.Point(0, 124)
        Me.tbcLiquidacion.Name = "tbcLiquidacion"
        Me.tbcLiquidacion.SelectedIndex = 0
        Me.tbcLiquidacion.Size = New System.Drawing.Size(967, 436)
        Me.tbcLiquidacion.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tbcLiquidacion.TabIndex = 1
        '
        'tbpCarga
        '
        Me.tbpCarga.Controls.Add(Me.pnlSplitContainer1)
        Me.tbpCarga.Location = New System.Drawing.Point(4, 22)
        Me.tbpCarga.Name = "tbpCarga"
        Me.tbpCarga.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCarga.Size = New System.Drawing.Size(959, 410)
        Me.tbpCarga.TabIndex = 0
        Me.tbpCarga.Text = "Carga"
        Me.tbpCarga.UseVisualStyleBackColor = True
        '
        'pnlSplitContainer1
        '
        Me.pnlSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.pnlSplitContainer1.Name = "pnlSplitContainer1"
        Me.pnlSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'pnlSplitContainer1.Panel1
        '
        Me.pnlSplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'pnlSplitContainer1.Panel2
        '
        Me.pnlSplitContainer1.Panel2.Controls.Add(Me.tbcCargos)
        Me.pnlSplitContainer1.Size = New System.Drawing.Size(953, 404)
        Me.pnlSplitContainer1.SplitterDistance = 202
        Me.pnlSplitContainer1.SplitterWidth = 8
        Me.pnlSplitContainer1.TabIndex = 53
        '
        'tbpResumen
        '
        Me.tbpResumen.BackColor = System.Drawing.SystemColors.Control
        Me.tbpResumen.Controls.Add(Me.rdbMontoSinCambiar)
        Me.tbpResumen.Controls.Add(Me.rdbMontoDesdeLista)
        Me.tbpResumen.Controls.Add(Me.rdbMontoSiMismo)
        Me.tbpResumen.Controls.Add(Me.btnCalcular)
        Me.tbpResumen.Controls.Add(Me.stsStado)
        Me.tbpResumen.Controls.Add(Me.txtAjustePrecioLista)
        Me.tbpResumen.Controls.Add(Me.Label3)
        Me.tbpResumen.Controls.Add(Me.txtAjusteMonto)
        Me.tbpResumen.Controls.Add(Me.Label1)
        Me.tbpResumen.Controls.Add(Me.btnTodos)
        Me.tbpResumen.Controls.Add(Me.cmbTodos)
        Me.tbpResumen.Controls.Add(Me.ugResumen)
        Me.tbpResumen.Location = New System.Drawing.Point(4, 22)
        Me.tbpResumen.Name = "tbpResumen"
        Me.tbpResumen.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpResumen.Size = New System.Drawing.Size(959, 410)
        Me.tbpResumen.TabIndex = 1
        Me.tbpResumen.Text = "Resumen"
        '
        'rdbMontoSinCambiar
        '
        Me.rdbMontoSinCambiar.AutoSize = True
        Me.rdbMontoSinCambiar.BindearPropiedadControl = Nothing
        Me.rdbMontoSinCambiar.BindearPropiedadEntidad = Nothing
        Me.rdbMontoSinCambiar.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbMontoSinCambiar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbMontoSinCambiar.IsPK = False
        Me.rdbMontoSinCambiar.IsRequired = False
        Me.rdbMontoSinCambiar.Key = Nothing
        Me.rdbMontoSinCambiar.LabelAsoc = Nothing
        Me.rdbMontoSinCambiar.Location = New System.Drawing.Point(608, 6)
        Me.rdbMontoSinCambiar.Name = "rdbMontoSinCambiar"
        Me.rdbMontoSinCambiar.Size = New System.Drawing.Size(81, 17)
        Me.rdbMontoSinCambiar.TabIndex = 11
        Me.rdbMontoSinCambiar.Text = "Sin Cambiar"
        Me.rdbMontoSinCambiar.UseVisualStyleBackColor = True
        Me.rdbMontoSinCambiar.Visible = False
        '
        'rdbMontoDesdeLista
        '
        Me.rdbMontoDesdeLista.AutoSize = True
        Me.rdbMontoDesdeLista.BindearPropiedadControl = Nothing
        Me.rdbMontoDesdeLista.BindearPropiedadEntidad = Nothing
        Me.rdbMontoDesdeLista.Checked = True
        Me.rdbMontoDesdeLista.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbMontoDesdeLista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbMontoDesdeLista.IsPK = False
        Me.rdbMontoDesdeLista.IsRequired = False
        Me.rdbMontoDesdeLista.Key = Nothing
        Me.rdbMontoDesdeLista.LabelAsoc = Nothing
        Me.rdbMontoDesdeLista.Location = New System.Drawing.Point(400, 6)
        Me.rdbMontoDesdeLista.Name = "rdbMontoDesdeLista"
        Me.rdbMontoDesdeLista.Size = New System.Drawing.Size(94, 17)
        Me.rdbMontoDesdeLista.TabIndex = 4
        Me.rdbMontoDesdeLista.TabStop = True
        Me.rdbMontoDesdeLista.Text = "Desde P. Lista"
        Me.rdbMontoDesdeLista.UseVisualStyleBackColor = True
        '
        'rdbMontoSiMismo
        '
        Me.rdbMontoSiMismo.AutoSize = True
        Me.rdbMontoSiMismo.BindearPropiedadControl = Nothing
        Me.rdbMontoSiMismo.BindearPropiedadEntidad = Nothing
        Me.rdbMontoSiMismo.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbMontoSiMismo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbMontoSiMismo.IsPK = False
        Me.rdbMontoSiMismo.IsRequired = False
        Me.rdbMontoSiMismo.Key = Nothing
        Me.rdbMontoSiMismo.LabelAsoc = Nothing
        Me.rdbMontoSiMismo.Location = New System.Drawing.Point(502, 6)
        Me.rdbMontoSiMismo.Name = "rdbMontoSiMismo"
        Me.rdbMontoSiMismo.Size = New System.Drawing.Size(98, 17)
        Me.rdbMontoSiMismo.TabIndex = 5
        Me.rdbMontoSiMismo.Text = "Sobre Si Mismo"
        Me.rdbMontoSiMismo.UseVisualStyleBackColor = True
        '
        'btnCalcular
        '
        Me.btnCalcular.Image = Global.Eniac.Win.My.Resources.Resources.calculator
        Me.btnCalcular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalcular.Location = New System.Drawing.Point(732, 3)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(103, 40)
        Me.btnCalcular.TabIndex = 8
        Me.btnCalcular.Text = "Ca&lcular (F8)"
        Me.btnCalcular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(3, 385)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(953, 22)
        Me.stsStado.TabIndex = 10
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(874, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'txtAjustePrecioLista
        '
        Me.txtAjustePrecioLista.BindearPropiedadControl = Nothing
        Me.txtAjustePrecioLista.BindearPropiedadEntidad = Nothing
        Me.txtAjustePrecioLista.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAjustePrecioLista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAjustePrecioLista.Formato = "##0.00"
        Me.txtAjustePrecioLista.IsDecimal = True
        Me.txtAjustePrecioLista.IsNumber = True
        Me.txtAjustePrecioLista.IsPK = False
        Me.txtAjustePrecioLista.IsRequired = False
        Me.txtAjustePrecioLista.Key = ""
        Me.txtAjustePrecioLista.LabelAsoc = Me.Label3
        Me.txtAjustePrecioLista.Location = New System.Drawing.Point(335, 26)
        Me.txtAjustePrecioLista.Name = "txtAjustePrecioLista"
        Me.txtAjustePrecioLista.Size = New System.Drawing.Size(50, 20)
        Me.txtAjustePrecioLista.TabIndex = 3
        Me.txtAjustePrecioLista.Text = "0,00"
        Me.txtAjustePrecioLista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(227, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "% Ajuste Precio Lista"
        '
        'txtAjusteMonto
        '
        Me.txtAjusteMonto.BindearPropiedadControl = Nothing
        Me.txtAjusteMonto.BindearPropiedadEntidad = Nothing
        Me.txtAjusteMonto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAjusteMonto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAjusteMonto.Formato = "##0.00"
        Me.txtAjusteMonto.IsDecimal = True
        Me.txtAjusteMonto.IsNumber = True
        Me.txtAjusteMonto.IsPK = False
        Me.txtAjusteMonto.IsRequired = False
        Me.txtAjusteMonto.Key = ""
        Me.txtAjusteMonto.LabelAsoc = Me.Label1
        Me.txtAjusteMonto.Location = New System.Drawing.Point(494, 26)
        Me.txtAjusteMonto.Name = "txtAjusteMonto"
        Me.txtAjusteMonto.Size = New System.Drawing.Size(50, 20)
        Me.txtAjusteMonto.TabIndex = 7
        Me.txtAjusteMonto.Text = "0,00"
        Me.txtAjusteMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(411, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "% Ajuste Monto"
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(126, 25)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 1
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
        Me.cmbTodos.Location = New System.Drawing.Point(4, 26)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 0
        '
        'ugResumen
        '
        Me.ugResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugResumen.DisplayLayout.Appearance = Appearance28
        Me.ugResumen.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance29.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.GroupByBox.Appearance = Appearance29
        Appearance30.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance30
        Me.ugResumen.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugResumen.DisplayLayout.GroupByBox.Hidden = True
        Appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance31.BackColor2 = System.Drawing.SystemColors.Control
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance31.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugResumen.DisplayLayout.GroupByBox.PromptAppearance = Appearance31
        Me.ugResumen.DisplayLayout.MaxColScrollRegions = 1
        Me.ugResumen.DisplayLayout.MaxRowScrollRegions = 1
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugResumen.DisplayLayout.Override.ActiveCellAppearance = Appearance32
        Appearance33.BackColor = System.Drawing.SystemColors.Highlight
        Appearance33.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugResumen.DisplayLayout.Override.ActiveRowAppearance = Appearance33
        Me.ugResumen.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugResumen.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.CardAreaAppearance = Appearance34
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugResumen.DisplayLayout.Override.CellAppearance = Appearance35
        Me.ugResumen.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugResumen.DisplayLayout.Override.CellPadding = 0
        Appearance36.BackColor = System.Drawing.SystemColors.Control
        Appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance36.BorderColor = System.Drawing.SystemColors.Window
        Me.ugResumen.DisplayLayout.Override.GroupByRowAppearance = Appearance36
        Appearance37.TextHAlignAsString = "Left"
        Me.ugResumen.DisplayLayout.Override.HeaderAppearance = Appearance37
        Me.ugResumen.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugResumen.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance38.BackColor = System.Drawing.SystemColors.Window
        Appearance38.BorderColor = System.Drawing.Color.Silver
        Me.ugResumen.DisplayLayout.Override.RowAppearance = Appearance38
        Me.ugResumen.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance39.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugResumen.DisplayLayout.Override.TemplateAddRowAppearance = Appearance39
        Me.ugResumen.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugResumen.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugResumen.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugResumen.Location = New System.Drawing.Point(3, 52)
        Me.ugResumen.Name = "ugResumen"
        Me.ugResumen.Size = New System.Drawing.Size(953, 336)
        Me.ugResumen.TabIndex = 9
        Me.ugResumen.Text = "UltraGrid1"
        Me.ugResumen.ToolStripLabelRegistros = Nothing
        Me.ugResumen.ToolStripMenuExpandir = Nothing
        '
        'tbpHistorial
        '
        Me.tbpHistorial.BackColor = System.Drawing.SystemColors.Control
        Me.tbpHistorial.Controls.Add(Me.ugDetalle)
        Me.tbpHistorial.Controls.Add(Me.grbConsultar)
        Me.tbpHistorial.Location = New System.Drawing.Point(4, 22)
        Me.tbpHistorial.Name = "tbpHistorial"
        Me.tbpHistorial.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpHistorial.Size = New System.Drawing.Size(959, 410)
        Me.tbpHistorial.TabIndex = 2
        Me.tbpHistorial.Text = "Historial"
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        UltraGridColumn9.Format = "0000/00"
        UltraGridColumn9.Header.Caption = "Periodo"
        UltraGridColumn9.Header.VisiblePosition = 0
        UltraGridColumn9.Width = 60
        Appearance40.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance40
        UltraGridColumn10.Header.Caption = "Codigo"
        UltraGridColumn10.Header.VisiblePosition = 1
        UltraGridColumn10.Width = 59
        UltraGridColumn11.Header.Caption = "Nombre Cliente"
        UltraGridColumn11.Header.VisiblePosition = 2
        UltraGridColumn11.Width = 182
        UltraGridColumn12.Header.Caption = "Nombre Fantasía"
        UltraGridColumn12.Header.VisiblePosition = 3
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.Caption = "Categoría"
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Width = 114
        UltraGridColumn14.Header.Caption = "Zona Geográfica"
        UltraGridColumn14.Header.VisiblePosition = 4
        UltraGridColumn14.Hidden = True
        Appearance41.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance41
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.VisiblePosition = 10
        UltraGridColumn15.Width = 80
        UltraGridColumn16.Header.Caption = "Cargo"
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn16.Width = 153
        Appearance42.TextHAlignAsString = "Right"
        UltraGridColumn17.CellAppearance = Appearance42
        UltraGridColumn17.Format = "N2"
        UltraGridColumn17.Header.Caption = "Importe S/ IVA"
        UltraGridColumn17.Header.VisiblePosition = 11
        UltraGridColumn17.Width = 81
        Appearance43.TextHAlignAsString = "Right"
        UltraGridColumn18.CellAppearance = Appearance43
        UltraGridColumn18.Format = "N2"
        UltraGridColumn18.Header.Caption = "Precio Lista"
        UltraGridColumn18.Header.VisiblePosition = 6
        UltraGridColumn18.Width = 80
        Appearance44.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance44
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "DR %"
        UltraGridColumn19.Header.VisiblePosition = 8
        UltraGridColumn19.Width = 80
        Appearance45.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance45
        UltraGridColumn20.Format = "N2"
        UltraGridColumn20.Header.Caption = "DR % Gral"
        UltraGridColumn20.Header.VisiblePosition = 9
        UltraGridColumn20.Width = 80
        Appearance46.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance46
        UltraGridColumn21.Format = "N2"
        UltraGridColumn21.Header.Caption = "Precio Lista S/ IVA"
        UltraGridColumn21.Header.VisiblePosition = 7
        UltraGridColumn21.Width = 80
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21})
        UltraGridBand2.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Appearance47.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance47
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Appearance48.ForeColor = System.Drawing.Color.Gray
        Me.ugDetalle.DisplayLayout.Override.FixedHeaderAppearance = Appearance48
        Appearance49.ForeColor = System.Drawing.Color.ForestGreen
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance49
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance50.ForeColor = System.Drawing.Color.Gray
        Me.ugDetalle.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance50
        Appearance51.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance51
        Appearance52.ForeColor = System.Drawing.Color.Gray
        Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance52
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(3, 101)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(953, 312)
        Me.ugDetalle.TabIndex = 23
        Me.ugDetalle.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChange
        '
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.lblVieneDeTab)
        Me.grbConsultar.Controls.Add(Me.Label4)
        Me.grbConsultar.Controls.Add(Me.bscNombreClienteHistorial)
        Me.grbConsultar.Controls.Add(Me.bscCodigoClienteHistorial)
        Me.grbConsultar.Controls.Add(Me.lblPeriodo)
        Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.lblNombreCliente)
        Me.grbConsultar.Controls.Add(Me.chkExpandAll)
        Me.grbConsultar.Controls.Add(Me.btnConsultar2)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbConsultar.Location = New System.Drawing.Point(3, 3)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(953, 97)
        Me.grbConsultar.TabIndex = 1
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Filtros"
        '
        'lblVieneDeTab
        '
        Me.lblVieneDeTab.AutoSize = True
        Me.lblVieneDeTab.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVieneDeTab.LabelAsoc = Nothing
        Me.lblVieneDeTab.Location = New System.Drawing.Point(470, 73)
        Me.lblVieneDeTab.Name = "lblVieneDeTab"
        Me.lblVieneDeTab.Size = New System.Drawing.Size(0, 13)
        Me.lblVieneDeTab.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(12, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Cliente"
        '
        'bscNombreClienteHistorial
        '
        Me.bscNombreClienteHistorial.ActivarFiltroEnGrilla = True
        Me.bscNombreClienteHistorial.BindearPropiedadControl = Nothing
        Me.bscNombreClienteHistorial.BindearPropiedadEntidad = Nothing
        Me.bscNombreClienteHistorial.ConfigBuscador = Nothing
        Me.bscNombreClienteHistorial.Datos = Nothing
        Me.bscNombreClienteHistorial.FilaDevuelta = Nothing
        Me.bscNombreClienteHistorial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreClienteHistorial.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreClienteHistorial.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreClienteHistorial.IsDecimal = False
        Me.bscNombreClienteHistorial.IsNumber = False
        Me.bscNombreClienteHistorial.IsPK = False
        Me.bscNombreClienteHistorial.IsRequired = False
        Me.bscNombreClienteHistorial.Key = ""
        Me.bscNombreClienteHistorial.LabelAsoc = Me.lblNombreCliente
        Me.bscNombreClienteHistorial.Location = New System.Drawing.Point(194, 67)
        Me.bscNombreClienteHistorial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscNombreClienteHistorial.MaxLengh = "32767"
        Me.bscNombreClienteHistorial.Name = "bscNombreClienteHistorial"
        Me.bscNombreClienteHistorial.Permitido = True
        Me.bscNombreClienteHistorial.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreClienteHistorial.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreClienteHistorial.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreClienteHistorial.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreClienteHistorial.Selecciono = False
        Me.bscNombreClienteHistorial.Size = New System.Drawing.Size(272, 23)
        Me.bscNombreClienteHistorial.TabIndex = 11
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.LabelAsoc = Nothing
        Me.lblNombreCliente.Location = New System.Drawing.Point(194, 51)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreCliente.TabIndex = 10
        Me.lblNombreCliente.Text = "Nombre"
        '
        'bscCodigoClienteHistorial
        '
        Me.bscCodigoClienteHistorial.ActivarFiltroEnGrilla = True
        Me.bscCodigoClienteHistorial.BindearPropiedadControl = Nothing
        Me.bscCodigoClienteHistorial.BindearPropiedadEntidad = Nothing
        Me.bscCodigoClienteHistorial.ConfigBuscador = Nothing
        Me.bscCodigoClienteHistorial.Datos = Nothing
        Me.bscCodigoClienteHistorial.FilaDevuelta = Nothing
        Me.bscCodigoClienteHistorial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoClienteHistorial.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoClienteHistorial.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoClienteHistorial.IsDecimal = False
        Me.bscCodigoClienteHistorial.IsNumber = False
        Me.bscCodigoClienteHistorial.IsPK = False
        Me.bscCodigoClienteHistorial.IsRequired = False
        Me.bscCodigoClienteHistorial.Key = ""
        Me.bscCodigoClienteHistorial.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoClienteHistorial.Location = New System.Drawing.Point(55, 67)
        Me.bscCodigoClienteHistorial.MaxLengh = "32767"
        Me.bscCodigoClienteHistorial.Name = "bscCodigoClienteHistorial"
        Me.bscCodigoClienteHistorial.Permitido = True
        Me.bscCodigoClienteHistorial.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoClienteHistorial.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoClienteHistorial.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoClienteHistorial.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoClienteHistorial.Selecciono = False
        Me.bscCodigoClienteHistorial.Size = New System.Drawing.Size(133, 23)
        Me.bscCodigoClienteHistorial.TabIndex = 9
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(55, 51)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 8
        Me.lblCodigoCliente.Text = "Codigo"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.LabelAsoc = Nothing
        Me.lblPeriodo.Location = New System.Drawing.Point(12, 27)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(100, 13)
        Me.lblPeriodo.TabIndex = 0
        Me.lblPeriodo.Text = "Periodo Liquidacion"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(655, 69)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 19)
        Me.chkExpandAll.TabIndex = 13
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'btnConsultar2
        '
        Me.btnConsultar2.Image = CType(resources.GetObject("btnConsultar2.Image"), System.Drawing.Image)
        Me.btnConsultar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar2.Location = New System.Drawing.Point(655, 21)
        Me.btnConsultar2.Name = "btnConsultar2"
        Me.btnConsultar2.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar2.TabIndex = 12
        Me.btnConsultar2.Text = "&Consultar"
        Me.btnConsultar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar2.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(294, 23)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(80, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(254, 27)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "MM/yyyy"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(160, 23)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(80, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(116, 27)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'tbpFacturacion
        '
        Me.tbpFacturacion.BackColor = System.Drawing.SystemColors.Control
        Me.tbpFacturacion.Controls.Add(Me.ugDetalleFacturacion)
        Me.tbpFacturacion.Controls.Add(Me.GroupBox1)
        Me.tbpFacturacion.Location = New System.Drawing.Point(4, 22)
        Me.tbpFacturacion.Name = "tbpFacturacion"
        Me.tbpFacturacion.Size = New System.Drawing.Size(959, 410)
        Me.tbpFacturacion.TabIndex = 3
        Me.tbpFacturacion.Text = "Facturación"
        '
        'ugDetalleFacturacion
        '
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalleFacturacion.DisplayLayout.Appearance = Appearance53
        Appearance54.TextHAlignAsString = "Center"
        UltraGridColumn22.CellAppearance = Appearance54
        UltraGridColumn22.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn22.Header.VisiblePosition = 3
        UltraGridColumn22.Width = 100
        UltraGridColumn23.Header.VisiblePosition = 4
        UltraGridColumn23.Hidden = True
        UltraGridColumn24.Header.Caption = "Comprobante"
        UltraGridColumn24.Header.VisiblePosition = 6
        UltraGridColumn24.Width = 80
        Appearance55.TextHAlignAsString = "Center"
        UltraGridColumn25.CellAppearance = Appearance55
        UltraGridColumn25.Header.Caption = "L."
        UltraGridColumn25.Header.VisiblePosition = 7
        UltraGridColumn25.Width = 20
        Appearance56.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance56
        UltraGridColumn26.Header.Caption = "Emisor"
        UltraGridColumn26.Header.VisiblePosition = 8
        UltraGridColumn26.Width = 40
        Appearance57.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance57
        UltraGridColumn27.Header.Caption = "Número"
        UltraGridColumn27.Header.VisiblePosition = 9
        UltraGridColumn27.Width = 52
        UltraGridColumn28.Header.VisiblePosition = 10
        UltraGridColumn28.Hidden = True
        UltraGridColumn29.Header.Caption = "Nombre Cliente"
        UltraGridColumn29.Header.VisiblePosition = 11
        UltraGridColumn29.Width = 119
        UltraGridColumn30.Header.Caption = "Categ. Fiscal"
        UltraGridColumn30.Header.VisiblePosition = 18
        UltraGridColumn30.Width = 100
        UltraGridColumn31.Header.Caption = "F. de Pago"
        UltraGridColumn31.Header.VisiblePosition = 19
        UltraGridColumn31.Width = 80
        Appearance58.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance58
        UltraGridColumn32.Header.Caption = "Producto"
        UltraGridColumn32.Header.VisiblePosition = 12
        UltraGridColumn32.Width = 79
        UltraGridColumn33.Header.Caption = "Nombre Producto"
        UltraGridColumn33.Header.VisiblePosition = 13
        UltraGridColumn33.Width = 152
        UltraGridColumn34.Header.Caption = "Marca"
        UltraGridColumn34.Header.VisiblePosition = 25
        UltraGridColumn34.Width = 150
        UltraGridColumn35.Header.Caption = "Rubro"
        UltraGridColumn35.Header.VisiblePosition = 26
        UltraGridColumn35.Width = 150
        UltraGridColumn36.Header.Caption = "Subrubro"
        UltraGridColumn36.Header.VisiblePosition = 27
        UltraGridColumn36.Width = 150
        UltraGridColumn37.Header.Caption = "Subsubrubro"
        UltraGridColumn37.Header.VisiblePosition = 28
        UltraGridColumn37.Width = 150
        Appearance59.TextHAlignAsString = "Right"
        UltraGridColumn38.CellAppearance = Appearance59
        UltraGridColumn38.Format = "##,##0.00"
        UltraGridColumn38.Header.VisiblePosition = 29
        UltraGridColumn38.Width = 70
        Appearance60.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance60
        UltraGridColumn39.Format = "##,##0.00"
        UltraGridColumn39.Header.Caption = "Prec. Lista"
        UltraGridColumn39.Header.VisiblePosition = 30
        UltraGridColumn39.Width = 70
        Appearance61.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance61
        UltraGridColumn40.Format = "##,##0.00"
        UltraGridColumn40.Header.VisiblePosition = 31
        UltraGridColumn40.Width = 70
        Appearance62.TextHAlignAsString = "Right"
        UltraGridColumn41.CellAppearance = Appearance62
        UltraGridColumn41.Format = "##0.00"
        UltraGridColumn41.Header.Caption = "D/R %1"
        UltraGridColumn41.Header.VisiblePosition = 32
        UltraGridColumn41.Width = 50
        Appearance63.TextHAlignAsString = "Right"
        UltraGridColumn42.CellAppearance = Appearance63
        UltraGridColumn42.Format = "##0.00"
        UltraGridColumn42.Header.Caption = "D/R %2"
        UltraGridColumn42.Header.VisiblePosition = 33
        UltraGridColumn42.Width = 50
        Appearance64.TextHAlignAsString = "Right"
        UltraGridColumn43.CellAppearance = Appearance64
        UltraGridColumn43.Format = "##0.00"
        UltraGridColumn43.Header.Caption = "D/R % G."
        UltraGridColumn43.Header.VisiblePosition = 34
        UltraGridColumn43.Width = 50
        Appearance65.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance65
        UltraGridColumn44.Format = "##,##0.00"
        UltraGridColumn44.Header.Caption = "Prec. Neto"
        UltraGridColumn44.Header.VisiblePosition = 35
        UltraGridColumn44.Width = 70
        Appearance66.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance66
        UltraGridColumn45.Format = "##0.00"
        UltraGridColumn45.Header.Caption = "IVA %"
        UltraGridColumn45.Header.VisiblePosition = 36
        UltraGridColumn45.Width = 50
        Appearance67.TextHAlignAsString = "Right"
        UltraGridColumn46.CellAppearance = Appearance67
        UltraGridColumn46.Format = "##,##0.00"
        UltraGridColumn46.Header.Caption = "Neto"
        UltraGridColumn46.Header.VisiblePosition = 14
        UltraGridColumn46.Width = 70
        Appearance68.TextHAlignAsString = "Right"
        UltraGridColumn47.CellAppearance = Appearance68
        UltraGridColumn47.Format = "N2"
        UltraGridColumn47.Header.Caption = "IVA"
        UltraGridColumn47.Header.VisiblePosition = 15
        UltraGridColumn47.Width = 61
        Appearance69.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance69
        UltraGridColumn48.Format = "N2"
        UltraGridColumn48.Header.Caption = "Imp.Internos"
        UltraGridColumn48.Header.VisiblePosition = 16
        UltraGridColumn48.Width = 70
        Appearance70.TextHAlignAsString = "Right"
        UltraGridColumn49.CellAppearance = Appearance70
        UltraGridColumn49.Format = "##,##0.00"
        UltraGridColumn49.Header.Caption = "Total"
        UltraGridColumn49.Header.VisiblePosition = 17
        UltraGridColumn49.Width = 70
        UltraGridColumn50.Header.VisiblePosition = 41
        UltraGridColumn50.Width = 80
        Appearance71.TextHAlignAsString = "Right"
        UltraGridColumn51.CellAppearance = Appearance71
        UltraGridColumn51.Header.Caption = "Tamaño"
        UltraGridColumn51.Header.VisiblePosition = 23
        UltraGridColumn51.Width = 60
        Appearance72.TextHAlignAsString = "Center"
        UltraGridColumn52.CellAppearance = Appearance72
        UltraGridColumn52.Header.Caption = "UM"
        UltraGridColumn52.Header.VisiblePosition = 24
        UltraGridColumn52.Width = 40
        UltraGridColumn53.Header.Caption = "Vendedor"
        UltraGridColumn53.Header.VisiblePosition = 21
        UltraGridColumn54.Header.Caption = "Zona Geografica"
        UltraGridColumn54.Header.VisiblePosition = 20
        UltraGridColumn54.Width = 110
        UltraGridColumn55.Header.Caption = "Localidad"
        UltraGridColumn55.Header.VisiblePosition = 42
        UltraGridColumn55.Width = 130
        UltraGridColumn56.Header.Caption = "Provincia"
        UltraGridColumn56.Header.VisiblePosition = 43
        UltraGridColumn56.Width = 110
        UltraGridColumn57.Header.Caption = "Lista Precios"
        UltraGridColumn57.Header.VisiblePosition = 37
        UltraGridColumn58.Header.Caption = "Categoría"
        UltraGridColumn58.Header.VisiblePosition = 44
        UltraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance73.TextHAlignAsString = "Right"
        UltraGridColumn59.CellAppearance = Appearance73
        UltraGridColumn59.Header.Caption = "C. C."
        UltraGridColumn59.Header.VisiblePosition = 45
        UltraGridColumn59.Hidden = True
        UltraGridColumn59.Width = 43
        UltraGridColumn60.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn60.Header.Caption = "Centro de Costo"
        UltraGridColumn60.Header.VisiblePosition = 48
        UltraGridColumn60.Width = 120
        UltraGridColumn61.Header.VisiblePosition = 49
        UltraGridColumn61.Width = 250
        UltraGridColumn62.Header.Caption = "Detalle del Producto"
        UltraGridColumn62.Header.VisiblePosition = 50
        UltraGridColumn62.Width = 250
        UltraGridColumn63.Header.Caption = "Tp. Oper."
        UltraGridColumn63.Header.VisiblePosition = 39
        UltraGridColumn63.Hidden = True
        UltraGridColumn63.Width = 80
        UltraGridColumn64.Header.VisiblePosition = 40
        UltraGridColumn64.Hidden = True
        UltraGridColumn64.Width = 150
        Appearance74.TextHAlignAsString = "Right"
        UltraGridColumn65.CellAppearance = Appearance74
        UltraGridColumn65.Header.Caption = "Código Transportista"
        UltraGridColumn65.Header.VisiblePosition = 51
        UltraGridColumn65.Hidden = True
        UltraGridColumn66.Header.Caption = "Transportista"
        UltraGridColumn66.Header.VisiblePosition = 22
        UltraGridColumn66.Width = 106
        UltraGridColumn67.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance75.TextHAlignAsString = "Center"
        UltraGridColumn67.CellAppearance = Appearance75
        UltraGridColumn67.Header.VisiblePosition = 0
        UltraGridColumn67.MaxWidth = 30
        UltraGridColumn67.MinWidth = 30
        UltraGridColumn67.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn67.Width = 30
        UltraGridColumn68.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance76.TextHAlignAsString = "Center"
        UltraGridColumn68.CellAppearance = Appearance76
        UltraGridColumn68.Header.Caption = "V.E."
        UltraGridColumn68.Header.VisiblePosition = 2
        UltraGridColumn68.Hidden = True
        UltraGridColumn68.MaxWidth = 30
        UltraGridColumn68.MinWidth = 30
        UltraGridColumn68.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn68.Width = 30
        UltraGridColumn69.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance77.TextHAlignAsString = "Center"
        UltraGridColumn69.CellAppearance = Appearance77
        UltraGridColumn69.Header.Caption = "Imp."
        UltraGridColumn69.Header.VisiblePosition = 1
        UltraGridColumn69.Hidden = True
        UltraGridColumn69.MaxWidth = 30
        UltraGridColumn69.MinWidth = 30
        UltraGridColumn69.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn69.Width = 30
        UltraGridColumn70.Header.VisiblePosition = 52
        UltraGridColumn70.Hidden = True
        UltraGridColumn71.Header.Caption = "Formula"
        UltraGridColumn71.Header.VisiblePosition = 46
        UltraGridColumn72.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance78.TextHAlignAsString = "Center"
        UltraGridColumn72.CellAppearance = Appearance78
        UltraGridColumn72.Header.Caption = ""
        UltraGridColumn72.Header.VisiblePosition = 47
        UltraGridColumn72.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn72.Width = 27
        Appearance79.TextHAlignAsString = "Right"
        UltraGridColumn73.CellAppearance = Appearance79
        UltraGridColumn73.Header.Caption = "Suc."
        UltraGridColumn73.Header.VisiblePosition = 5
        UltraGridColumn73.Hidden = True
        UltraGridColumn73.Width = 40
        UltraGridColumn74.Header.VisiblePosition = 53
        UltraGridColumn74.Hidden = True
        UltraGridColumn75.Header.Caption = "Caja"
        UltraGridColumn75.Header.VisiblePosition = 38
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75})
        Me.ugDetalleFacturacion.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugDetalleFacturacion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalleFacturacion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance80.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance80.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance80.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalleFacturacion.DisplayLayout.GroupByBox.Appearance = Appearance80
        Appearance81.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalleFacturacion.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance81
        Me.ugDetalleFacturacion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalleFacturacion.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance82.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance82.BackColor2 = System.Drawing.SystemColors.Control
        Appearance82.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance82.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalleFacturacion.DisplayLayout.GroupByBox.PromptAppearance = Appearance82
        Me.ugDetalleFacturacion.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalleFacturacion.DisplayLayout.MaxRowScrollRegions = 1
        Appearance83.BackColor = System.Drawing.SystemColors.Window
        Appearance83.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalleFacturacion.DisplayLayout.Override.ActiveCellAppearance = Appearance83
        Appearance84.BackColor = System.Drawing.SystemColors.Highlight
        Appearance84.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalleFacturacion.DisplayLayout.Override.ActiveRowAppearance = Appearance84
        Me.ugDetalleFacturacion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalleFacturacion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalleFacturacion.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalleFacturacion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalleFacturacion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance85.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalleFacturacion.DisplayLayout.Override.CardAreaAppearance = Appearance85
        Appearance86.BorderColor = System.Drawing.Color.Silver
        Appearance86.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalleFacturacion.DisplayLayout.Override.CellAppearance = Appearance86
        Me.ugDetalleFacturacion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalleFacturacion.DisplayLayout.Override.CellPadding = 0
        Appearance87.BackColor = System.Drawing.SystemColors.Control
        Appearance87.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance87.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance87.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance87.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalleFacturacion.DisplayLayout.Override.GroupByRowAppearance = Appearance87
        Appearance88.TextHAlignAsString = "Left"
        Me.ugDetalleFacturacion.DisplayLayout.Override.HeaderAppearance = Appearance88
        Me.ugDetalleFacturacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalleFacturacion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance89.BackColor = System.Drawing.SystemColors.Window
        Appearance89.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalleFacturacion.DisplayLayout.Override.RowAppearance = Appearance89
        Me.ugDetalleFacturacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalleFacturacion.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance90.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalleFacturacion.DisplayLayout.Override.TemplateAddRowAppearance = Appearance90
        Me.ugDetalleFacturacion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalleFacturacion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalleFacturacion.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalleFacturacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalleFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalleFacturacion.Location = New System.Drawing.Point(0, 97)
        Me.ugDetalleFacturacion.Name = "ugDetalleFacturacion"
        Me.ugDetalleFacturacion.Size = New System.Drawing.Size(959, 313)
        Me.ugDetalleFacturacion.TabIndex = 48
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblVieneDeTabFac)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.chkExpandAllTwo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DtpDesdeFact)
        Me.GroupBox1.Controls.Add(Me.BtnConsultar3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.bscCodigoClienteFacturacion)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.bscNombreClienteFacturacion)
        Me.GroupBox1.Controls.Add(Me.DtpHastaFact)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblNombre)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(959, 97)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'lblVieneDeTabFac
        '
        Me.lblVieneDeTabFac.AutoSize = True
        Me.lblVieneDeTabFac.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVieneDeTabFac.LabelAsoc = Nothing
        Me.lblVieneDeTabFac.Location = New System.Drawing.Point(468, 73)
        Me.lblVieneDeTabFac.Name = "lblVieneDeTabFac"
        Me.lblVieneDeTabFac.Size = New System.Drawing.Size(0, 13)
        Me.lblVieneDeTabFac.TabIndex = 50
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.LabelAsoc = Nothing
        Me.Label9.Location = New System.Drawing.Point(10, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Cliente"
        '
        'chkExpandAllTwo
        '
        Me.chkExpandAllTwo.Location = New System.Drawing.Point(658, 72)
        Me.chkExpandAllTwo.Name = "chkExpandAllTwo"
        Me.chkExpandAllTwo.Size = New System.Drawing.Size(104, 19)
        Me.chkExpandAllTwo.TabIndex = 48
        Me.chkExpandAllTwo.Text = "Expandir Grupos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.LabelAsoc = Nothing
        Me.Label8.Location = New System.Drawing.Point(12, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Periodo Liquidacion"
        '
        'DtpDesdeFact
        '
        Me.DtpDesdeFact.BindearPropiedadControl = Nothing
        Me.DtpDesdeFact.BindearPropiedadEntidad = Nothing
        Me.DtpDesdeFact.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.DtpDesdeFact.ForeColorFocus = System.Drawing.Color.Red
        Me.DtpDesdeFact.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.DtpDesdeFact.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDesdeFact.IsPK = False
        Me.DtpDesdeFact.IsRequired = False
        Me.DtpDesdeFact.Key = ""
        Me.DtpDesdeFact.LabelAsoc = Me.Label6
        Me.DtpDesdeFact.Location = New System.Drawing.Point(160, 23)
        Me.DtpDesdeFact.Name = "DtpDesdeFact"
        Me.DtpDesdeFact.Size = New System.Drawing.Size(128, 20)
        Me.DtpDesdeFact.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(116, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Desde"
        '
        'BtnConsultar3
        '
        Me.BtnConsultar3.Image = CType(resources.GetObject("BtnConsultar3.Image"), System.Drawing.Image)
        Me.BtnConsultar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConsultar3.Location = New System.Drawing.Point(658, 24)
        Me.BtnConsultar3.Name = "BtnConsultar3"
        Me.BtnConsultar3.Size = New System.Drawing.Size(100, 45)
        Me.BtnConsultar3.TabIndex = 46
        Me.BtnConsultar3.Text = "&Consultar"
        Me.BtnConsultar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnConsultar3.UseVisualStyleBackColor = True
        '
        'bscCodigoClienteFacturacion
        '
        Me.bscCodigoClienteFacturacion.ActivarFiltroEnGrilla = True
        Me.bscCodigoClienteFacturacion.BindearPropiedadControl = Nothing
        Me.bscCodigoClienteFacturacion.BindearPropiedadEntidad = Nothing
        Me.bscCodigoClienteFacturacion.ConfigBuscador = Nothing
        Me.bscCodigoClienteFacturacion.Datos = Nothing
        Me.bscCodigoClienteFacturacion.FilaDevuelta = Nothing
        Me.bscCodigoClienteFacturacion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoClienteFacturacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoClienteFacturacion.IsDecimal = False
        Me.bscCodigoClienteFacturacion.IsNumber = False
        Me.bscCodigoClienteFacturacion.IsPK = False
        Me.bscCodigoClienteFacturacion.IsRequired = False
        Me.bscCodigoClienteFacturacion.Key = ""
        Me.bscCodigoClienteFacturacion.LabelAsoc = Me.Label7
        Me.bscCodigoClienteFacturacion.Location = New System.Drawing.Point(55, 67)
        Me.bscCodigoClienteFacturacion.MaxLengh = "32767"
        Me.bscCodigoClienteFacturacion.Name = "bscCodigoClienteFacturacion"
        Me.bscCodigoClienteFacturacion.Permitido = True
        Me.bscCodigoClienteFacturacion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoClienteFacturacion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoClienteFacturacion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoClienteFacturacion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoClienteFacturacion.Selecciono = False
        Me.bscCodigoClienteFacturacion.Size = New System.Drawing.Size(133, 23)
        Me.bscCodigoClienteFacturacion.TabIndex = 43
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(55, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Código"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(294, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Hasta"
        '
        'bscNombreClienteFacturacion
        '
        Me.bscNombreClienteFacturacion.ActivarFiltroEnGrilla = True
        Me.bscNombreClienteFacturacion.AutoSize = True
        Me.bscNombreClienteFacturacion.BindearPropiedadControl = Nothing
        Me.bscNombreClienteFacturacion.BindearPropiedadEntidad = Nothing
        Me.bscNombreClienteFacturacion.ConfigBuscador = Nothing
        Me.bscNombreClienteFacturacion.Datos = Nothing
        Me.bscNombreClienteFacturacion.Enabled = False
        Me.bscNombreClienteFacturacion.FilaDevuelta = Nothing
        Me.bscNombreClienteFacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreClienteFacturacion.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreClienteFacturacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreClienteFacturacion.IsDecimal = False
        Me.bscNombreClienteFacturacion.IsNumber = False
        Me.bscNombreClienteFacturacion.IsPK = False
        Me.bscNombreClienteFacturacion.IsRequired = False
        Me.bscNombreClienteFacturacion.Key = ""
        Me.bscNombreClienteFacturacion.LabelAsoc = Me.lblNombre
        Me.bscNombreClienteFacturacion.Location = New System.Drawing.Point(194, 67)
        Me.bscNombreClienteFacturacion.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreClienteFacturacion.MaxLengh = "32767"
        Me.bscNombreClienteFacturacion.Name = "bscNombreClienteFacturacion"
        Me.bscNombreClienteFacturacion.Permitido = True
        Me.bscNombreClienteFacturacion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreClienteFacturacion.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreClienteFacturacion.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreClienteFacturacion.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreClienteFacturacion.Selecciono = False
        Me.bscNombreClienteFacturacion.Size = New System.Drawing.Size(270, 23)
        Me.bscNombreClienteFacturacion.TabIndex = 45
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(191, 51)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 44
        Me.lblNombre.Text = "Nombre"
        '
        'DtpHastaFact
        '
        Me.DtpHastaFact.BindearPropiedadControl = Nothing
        Me.DtpHastaFact.BindearPropiedadEntidad = Nothing
        Me.DtpHastaFact.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.DtpHastaFact.ForeColorFocus = System.Drawing.Color.Red
        Me.DtpHastaFact.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.DtpHastaFact.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpHastaFact.IsPK = False
        Me.DtpHastaFact.IsRequired = False
        Me.DtpHastaFact.Key = ""
        Me.DtpHastaFact.LabelAsoc = Me.Label5
        Me.DtpHastaFact.Location = New System.Drawing.Point(335, 23)
        Me.DtpHastaFact.Name = "DtpHastaFact"
        Me.DtpHastaFact.Size = New System.Drawing.Size(128, 20)
        Me.DtpHastaFact.TabIndex = 9
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.cmbTipoCliente)
        Me.grpFiltros.Controls.Add(Me.chkTipoCliente)
        Me.grpFiltros.Controls.Add(Me.llbCliente)
        Me.grpFiltros.Controls.Add(Me.Label10)
        Me.grpFiltros.Controls.Add(Me.lblActivo)
        Me.grpFiltros.Controls.Add(Me.cmbActivo)
        Me.grpFiltros.Controls.Add(Me.chbCliente)
        Me.grpFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grpFiltros.Controls.Add(Me.bscNombreCliente)
        Me.grpFiltros.Controls.Add(Me.btnConsultar)
        Me.grpFiltros.Controls.Add(Me.txtPcs)
        Me.grpFiltros.Controls.Add(Me.cmbCobrador)
        Me.grpFiltros.Controls.Add(Me.chbZonaGeografica)
        Me.grpFiltros.Controls.Add(Me.cmbFiltrosPcs)
        Me.grpFiltros.Controls.Add(Me.chbCategoria)
        Me.grpFiltros.Controls.Add(Me.chbCantidadPcs)
        Me.grpFiltros.Controls.Add(Me.chbCobrador)
        Me.grpFiltros.Controls.Add(Me.cmbCategorias)
        Me.grpFiltros.Controls.Add(Me.cmbZonaGeografica)
        Me.grpFiltros.Location = New System.Drawing.Point(4, 27)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(959, 91)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        Me.grpFiltros.Text = "Filtros"
        '
        'cmbTipoCliente
        '
        Me.cmbTipoCliente.BindearPropiedadControl = Nothing
        Me.cmbTipoCliente.BindearPropiedadEntidad = Nothing
        Me.cmbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCliente.Enabled = False
        Me.cmbTipoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoCliente.FormattingEnabled = True
        Me.cmbTipoCliente.IsPK = False
        Me.cmbTipoCliente.IsRequired = False
        Me.cmbTipoCliente.Key = Nothing
        Me.cmbTipoCliente.LabelAsoc = Nothing
        Me.cmbTipoCliente.Location = New System.Drawing.Point(714, 59)
        Me.cmbTipoCliente.Name = "cmbTipoCliente"
        Me.cmbTipoCliente.Size = New System.Drawing.Size(118, 21)
        Me.cmbTipoCliente.TabIndex = 62
        '
        'chkTipoCliente
        '
        Me.chkTipoCliente.AutoSize = True
        Me.chkTipoCliente.BindearPropiedadControl = Nothing
        Me.chkTipoCliente.BindearPropiedadEntidad = Nothing
        Me.chkTipoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chkTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkTipoCliente.IsPK = False
        Me.chkTipoCliente.IsRequired = False
        Me.chkTipoCliente.Key = Nothing
        Me.chkTipoCliente.LabelAsoc = Nothing
        Me.chkTipoCliente.Location = New System.Drawing.Point(661, 62)
        Me.chkTipoCliente.Name = "chkTipoCliente"
        Me.chkTipoCliente.Size = New System.Drawing.Size(47, 17)
        Me.chkTipoCliente.TabIndex = 61
        Me.chkTipoCliente.Text = "Tipo"
        Me.chkTipoCliente.UseVisualStyleBackColor = True
        '
        'llbCliente
        '
        Me.llbCliente.AutoSize = True
        Me.llbCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.llbCliente.LabelAsoc = Nothing
        Me.llbCliente.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llbCliente.Location = New System.Drawing.Point(271, 43)
        Me.llbCliente.Name = "llbCliente"
        Me.llbCliente.Size = New System.Drawing.Size(55, 13)
        Me.llbCliente.TabIndex = 60
        Me.llbCliente.TabStop = True
        Me.llbCliente.Text = "más info..."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.LabelAsoc = Nothing
        Me.Label10.Location = New System.Drawing.Point(221, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "&Nombre"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.LabelAsoc = Nothing
        Me.lblActivo.Location = New System.Drawing.Point(492, 64)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 58
        Me.lblActivo.Text = "Activo"
        '
        'cmbActivo
        '
        Me.cmbActivo.BindearPropiedadControl = ""
        Me.cmbActivo.BindearPropiedadEntidad = ""
        Me.cmbActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActivo.FormattingEnabled = True
        Me.cmbActivo.IsPK = False
        Me.cmbActivo.IsRequired = True
        Me.cmbActivo.Key = Nothing
        Me.cmbActivo.LabelAsoc = Nothing
        Me.cmbActivo.Location = New System.Drawing.Point(535, 60)
        Me.cmbActivo.Name = "cmbActivo"
        Me.cmbActivo.Size = New System.Drawing.Size(120, 21)
        Me.cmbActivo.TabIndex = 57
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
        Me.chbCliente.Location = New System.Drawing.Point(13, 61)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 56
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
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(87, 59)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(121, 23)
        Me.bscCodigoCliente.TabIndex = 55
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.ActivarFiltroEnGrilla = True
        Me.bscNombreCliente.AutoSize = True
        Me.bscNombreCliente.BindearPropiedadControl = Nothing
        Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
        Me.bscNombreCliente.ConfigBuscador = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.Enabled = False
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Nothing
        Me.bscNombreCliente.Location = New System.Drawing.Point(215, 59)
        Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = True
        Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(270, 23)
        Me.bscNombreCliente.TabIndex = 53
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(849, 18)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 9
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'txtPcs
        '
        Me.txtPcs.Enabled = False
        Me.txtPcs.Location = New System.Drawing.Point(761, 20)
        Me.txtPcs.Name = "txtPcs"
        Me.txtPcs.Size = New System.Drawing.Size(43, 20)
        Me.txtPcs.TabIndex = 8
        Me.txtPcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPcs.Visible = False
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
        Me.cmbCobrador.Location = New System.Drawing.Point(287, 17)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.Size = New System.Drawing.Size(98, 21)
        Me.cmbCobrador.TabIndex = 3
        '
        'chbZonaGeografica
        '
        Me.chbZonaGeografica.AutoSize = True
        Me.chbZonaGeografica.Location = New System.Drawing.Point(397, 21)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
        Me.chbZonaGeografica.TabIndex = 4
        Me.chbZonaGeografica.Text = "Zona Geográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
        '
        'cmbFiltrosPcs
        '
        Me.cmbFiltrosPcs.BindearPropiedadControl = Nothing
        Me.cmbFiltrosPcs.BindearPropiedadEntidad = Nothing
        Me.cmbFiltrosPcs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltrosPcs.Enabled = False
        Me.cmbFiltrosPcs.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFiltrosPcs.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFiltrosPcs.FormattingEnabled = True
        Me.cmbFiltrosPcs.IsPK = False
        Me.cmbFiltrosPcs.IsRequired = False
        Me.cmbFiltrosPcs.Key = Nothing
        Me.cmbFiltrosPcs.LabelAsoc = Nothing
        Me.cmbFiltrosPcs.Location = New System.Drawing.Point(714, 19)
        Me.cmbFiltrosPcs.Name = "cmbFiltrosPcs"
        Me.cmbFiltrosPcs.Size = New System.Drawing.Size(44, 21)
        Me.cmbFiltrosPcs.TabIndex = 7
        Me.cmbFiltrosPcs.Visible = False
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
        Me.chbCategoria.Location = New System.Drawing.Point(13, 19)
        Me.chbCategoria.Name = "chbCategoria"
        Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoria.TabIndex = 0
        Me.chbCategoria.Text = "Categoria"
        Me.chbCategoria.UseVisualStyleBackColor = True
        '
        'chbCantidadPcs
        '
        Me.chbCantidadPcs.AutoSize = True
        Me.chbCantidadPcs.BindearPropiedadControl = Nothing
        Me.chbCantidadPcs.BindearPropiedadEntidad = Nothing
        Me.chbCantidadPcs.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCantidadPcs.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCantidadPcs.IsPK = False
        Me.chbCantidadPcs.IsRequired = False
        Me.chbCantidadPcs.Key = Nothing
        Me.chbCantidadPcs.LabelAsoc = Nothing
        Me.chbCantidadPcs.Location = New System.Drawing.Point(622, 21)
        Me.chbCantidadPcs.Name = "chbCantidadPcs"
        Me.chbCantidadPcs.Size = New System.Drawing.Size(90, 17)
        Me.chbCantidadPcs.TabIndex = 6
        Me.chbCantidadPcs.Text = "Cantidad PCs"
        Me.chbCantidadPcs.UseVisualStyleBackColor = True
        Me.chbCantidadPcs.Visible = False
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
        Me.chbCobrador.Location = New System.Drawing.Point(215, 21)
        Me.chbCobrador.Name = "chbCobrador"
        Me.chbCobrador.Size = New System.Drawing.Size(69, 17)
        Me.chbCobrador.TabIndex = 2
        Me.chbCobrador.Text = "Cobrador"
        Me.chbCobrador.UseVisualStyleBackColor = True
        '
        'cmbCategorias
        '
        Me.cmbCategorias.BindearPropiedadControl = ""
        Me.cmbCategorias.BindearPropiedadEntidad = ""
        Me.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategorias.Enabled = False
        Me.cmbCategorias.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategorias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategorias.FormattingEnabled = True
        Me.cmbCategorias.IsPK = False
        Me.cmbCategorias.IsRequired = True
        Me.cmbCategorias.Key = Nothing
        Me.cmbCategorias.LabelAsoc = Nothing
        Me.cmbCategorias.Location = New System.Drawing.Point(87, 17)
        Me.cmbCategorias.Name = "cmbCategorias"
        Me.cmbCategorias.Size = New System.Drawing.Size(119, 21)
        Me.cmbCategorias.TabIndex = 1
        '
        'cmbZonaGeografica
        '
        Me.cmbZonaGeografica.BindearPropiedadControl = ""
        Me.cmbZonaGeografica.BindearPropiedadEntidad = ""
        Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaGeografica.Enabled = False
        Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbZonaGeografica.FormattingEnabled = True
        Me.cmbZonaGeografica.IsPK = False
        Me.cmbZonaGeografica.IsRequired = True
        Me.cmbZonaGeografica.Key = Nothing
        Me.cmbZonaGeografica.LabelAsoc = Nothing
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(506, 19)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(107, 21)
        Me.cmbZonaGeografica.TabIndex = 5
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
        Appearance91.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance91.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance91.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance91
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
        'CargosClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 561)
        Me.Controls.Add(Me.grpFiltros)
        Me.Controls.Add(Me.tbcLiquidacion)
        Me.Controls.Add(Me.tstBarra)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CargosClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación de cargos a clientes"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.tbcCargos.ResumeLayout(False)
        Me.tbpCargos.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.ugCargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpObservaciones.ResumeLayout(False)
        Me.grbObservaciones.ResumeLayout(False)
        Me.grbObservaciones.PerformLayout()
        CType(Me.dgvObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcLiquidacion.ResumeLayout(False)
        Me.tbpCarga.ResumeLayout(False)
        Me.pnlSplitContainer1.Panel1.ResumeLayout(False)
        Me.pnlSplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.pnlSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSplitContainer1.ResumeLayout(False)
        Me.tbpResumen.ResumeLayout(False)
        Me.tbpResumen.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpHistorial.ResumeLayout(False)
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.tbpFacturacion.ResumeLayout(False)
        CType(Me.ugDetalleFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblNumeroInmueble As Eniac.Controles.Label
   Friend WithEvents txtCodigoCliente As Eniac.Controles.TextBox
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents ugClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tbcLiquidacion As System.Windows.Forms.TabControl
    Friend WithEvents tbpCarga As System.Windows.Forms.TabPage
    Friend WithEvents tbpResumen As System.Windows.Forms.TabPage
    Friend WithEvents ugResumen As UltraGridEditable
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents grbObservaciones As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminarObservacion As Eniac.Controles.Button
    Friend WithEvents btnInsertarObservacion As Eniac.Controles.Button
    Friend WithEvents bscObservacionDetalle As Eniac.Controles.Buscador
    Friend WithEvents lblObservacionDetalle As Eniac.Controles.Label
    Friend WithEvents dgvObservaciones As Eniac.Controles.DataGridView
    Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Linea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Password As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents chbObservaciones As Eniac.Controles.CheckBox
    Friend WithEvents cmbTiposLiquidacion As Eniac.Controles.ComboBox
    Friend WithEvents Label2 As Eniac.Controles.Label
    Friend WithEvents tbcCargos As System.Windows.Forms.TabControl
    Friend WithEvents tbpCargos As System.Windows.Forms.TabPage
    Friend WithEvents tbpObservaciones As System.Windows.Forms.TabPage
    Friend WithEvents ugCargos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chbCobrador As Eniac.Controles.CheckBox
    Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
    Friend WithEvents chbZonaGeografica As System.Windows.Forms.CheckBox
    Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
    Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
    Friend WithEvents cmbCategorias As Eniac.Controles.ComboBox
    Friend WithEvents btnConsultar As Eniac.Controles.Button
    Friend WithEvents chbCantidadPcs As Eniac.Controles.CheckBox
    Friend WithEvents txtPcs As System.Windows.Forms.TextBox
    Friend WithEvents cmbFiltrosPcs As Eniac.Controles.ComboBox
    Friend WithEvents grpFiltros As System.Windows.Forms.GroupBox
    Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtAjustePrecioLista As Eniac.Controles.TextBox
    Friend WithEvents Label3 As Eniac.Controles.Label
    Friend WithEvents txtAjusteMonto As Eniac.Controles.TextBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents btnTodos As System.Windows.Forms.Button
    Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbpHistorial As System.Windows.Forms.TabPage
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
    Friend WithEvents bscNombreClienteHistorial As Eniac.Controles.Buscador2
    Friend WithEvents lblNombreCliente As Eniac.Controles.Label
    Friend WithEvents bscCodigoClienteHistorial As Eniac.Controles.Buscador2
    Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
    Friend WithEvents lblPeriodo As Eniac.Controles.Label
    Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnConsultar2 As Eniac.Controles.Button
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblHasta As Eniac.Controles.Label
    Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label4 As Eniac.Controles.Label
    Friend WithEvents btnCalcular As Eniac.Controles.Button
    Friend WithEvents rdbMontoDesdeLista As Eniac.Controles.RadioButton
    Friend WithEvents rdbMontoSiMismo As Eniac.Controles.RadioButton
    Friend WithEvents tbpFacturacion As System.Windows.Forms.TabPage
    Friend WithEvents DtpHastaFact As Eniac.Controles.DateTimePicker
    Friend WithEvents Label5 As Eniac.Controles.Label
    Friend WithEvents DtpDesdeFact As Eniac.Controles.DateTimePicker
    Friend WithEvents Label6 As Eniac.Controles.Label
    Friend WithEvents bscCodigoClienteFacturacion As Eniac.Controles.Buscador2
    Friend WithEvents Label7 As Eniac.Controles.Label
    Friend WithEvents bscNombreClienteFacturacion As Eniac.Controles.Buscador2
    Friend WithEvents lblNombre As Eniac.Controles.Label
    Friend WithEvents BtnConsultar3 As Eniac.Controles.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected WithEvents ugDetalleFacturacion As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkExpandAllTwo As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As Eniac.Controles.Label
    Friend WithEvents Label9 As Eniac.Controles.Label
    Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
    Friend WithEvents chbCliente As Eniac.Controles.CheckBox
    Friend WithEvents rdbMontoSinCambiar As Eniac.Controles.RadioButton
    Friend WithEvents chbSoloConImportes As Eniac.Controles.CheckBox
    Friend WithEvents lblVieneDeTab As Eniac.Controles.Label
    Friend WithEvents lblVieneDeTabFac As Eniac.Controles.Label
    Friend WithEvents lblActivo As Controles.Label
    Friend WithEvents cmbActivo As Controles.ComboBox
    Friend WithEvents pnlSplitContainer1 As SplitContainer
    Friend WithEvents llbCliente As Controles.LinkLabel
    Friend WithEvents Label10 As Controles.Label
    Friend WithEvents cmbTipoCliente As Controles.ComboBox
    Friend WithEvents chkTipoCliente As Controles.CheckBox
End Class
