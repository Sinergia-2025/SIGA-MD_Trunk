<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfVentasDetallePorProductos
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
      Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioConIva")
      Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
      Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
      Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
      Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
      Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
      Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
      Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
      Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
      Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTransportista")
      Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreTransportista")
        Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreClienteVinculado")
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoComprobante")
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreActualProducto")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubSubRubro")
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioLista")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioConIva")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorcGral")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaImpuesto")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotalNeto")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteImpuesto")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteImpuestoInterno")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCentroCosto")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCentroCosto")
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DetalleProducto")
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VerEstandar")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn116 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imprimir")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn117 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormula")
        Dim UltraGridColumn118 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFormula")
        Dim UltraGridColumn119 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantComponentes")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn120 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn121 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn122 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja")
        Dim UltraGridColumn123 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoVenta")
        Dim UltraGridColumn124 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoVenta")
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioListaConIva")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn127 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNetoConIva")
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn128 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPaciente")
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn129 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDoctor")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn130 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePaciente")
        Dim UltraGridColumn131 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDoctor")
        Dim UltraGridColumn132 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCirugia")
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDR1")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDR2")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDRGral")
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDR1ConIva")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDR2ConIva")
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDRGralConIva")
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeBarras")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreClienteVinculado")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TelefonoCliente", 0)
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdaAtributoProducto01", 1)
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAtributo01", 2)
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdaAtributoProducto02", 3)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAtributo02", 4)
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdaAtributoProducto03", 5)
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAtributo03", 6)
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdaAtributoProducto04", 7)
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAtributo04", 8)
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ProveedorHabitual", 9)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProductoProveedor", 10)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ProveedorOC", 11)
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra", 12)
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
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
        Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
        Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoComprobante")
        Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
        Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
        Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
        Dim UltraDataColumn38 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCliente")
        Dim UltraDataColumn39 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
        Dim UltraDataColumn40 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoriaFiscal")
        Dim UltraDataColumn41 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaDePago")
        Dim UltraDataColumn42 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn43 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn44 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreActualProducto")
        Dim UltraDataColumn45 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
        Dim UltraDataColumn46 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
        Dim UltraDataColumn47 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
        Dim UltraDataColumn48 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubSubRubro")
        Dim UltraDataColumn49 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
        Dim UltraDataColumn50 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioLista")
        Dim UltraDataColumn51 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
        Dim UltraDataColumn52 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioConIva")
        Dim UltraDataColumn53 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
        Dim UltraDataColumn54 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
        Dim UltraDataColumn55 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
        Dim UltraDataColumn56 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
        Dim UltraDataColumn57 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
        Dim UltraDataColumn58 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
        Dim UltraDataColumn59 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
        Dim UltraDataColumn60 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuestoInterno")
        Dim UltraDataColumn61 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotal")
        Dim UltraDataColumn62 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim UltraDataColumn63 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Tamano")
        Dim UltraDataColumn64 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUnidadDeMedida")
        Dim UltraDataColumn65 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreVendedor")
        Dim UltraDataColumn66 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreZonaGeografica")
        Dim UltraDataColumn67 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreLocalidad")
        Dim UltraDataColumn68 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProvincia")
        Dim UltraDataColumn69 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreListaPrecios")
        Dim UltraDataColumn70 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoria")
        Dim UltraDataColumn71 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCentroCosto")
        Dim UltraDataColumn72 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCentroCosto")
        Dim UltraDataColumn73 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
        Dim UltraDataColumn74 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DetalleProducto")
        Dim UltraDataColumn75 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoOperacion")
        Dim UltraDataColumn76 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Nota")
        Dim UltraDataColumn77 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTransportista")
        Dim UltraDataColumn78 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreTransportista")
        Dim UltraDataColumn79 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Ver")
        Dim UltraDataColumn80 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("VerEstandar")
        Dim UltraDataColumn81 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Imprimir")
        Dim UltraDataColumn82 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdFormula")
        Dim UltraDataColumn83 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreFormula")
        Dim UltraDataColumn84 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantComponentes")
        Dim UltraDataColumn85 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
        Dim UltraDataColumn86 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Orden")
        Dim UltraDataColumn87 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCaja")
        Dim UltraDataColumn88 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdEstadoVenta")
        Dim UltraDataColumn89 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreEstadoVenta")
        Dim UltraDataColumn90 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Kilos")
        Dim UltraDataColumn91 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioListaConIva")
        Dim UltraDataColumn92 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNetoConIva")
        Dim UltraDataColumn93 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdPaciente")
        Dim UltraDataColumn94 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdDoctor")
        Dim UltraDataColumn95 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombrePaciente")
        Dim UltraDataColumn96 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreDoctor")
        Dim UltraDataColumn97 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaCirugia")
        Dim UltraDataColumn98 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteDR1")
        Dim UltraDataColumn99 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteDR2")
        Dim UltraDataColumn100 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteDRGral")
        Dim UltraDataColumn101 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteDR1ConIva")
        Dim UltraDataColumn102 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteDR2ConIva")
        Dim UltraDataColumn103 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteDRGralConIva")
        Dim UltraDataColumn104 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoDeBarras")
        Dim UltraDataColumn105 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreClienteVinculado")
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraDataSource2 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.cmbTipoCliente = New Eniac.Controles.ComboBox()
        Me.lblCliente = New Eniac.Controles.Label()
        Me.gbHistoriaClinica = New System.Windows.Forms.GroupBox()
        Me.chbFechaCirugia = New Eniac.Controles.CheckBox()
        Me.dtpFechaCirugia = New Eniac.Controles.DateTimePicker()
        Me.lblFechaCirugia = New Eniac.Controles.Label()
        Me.bscCodigoDoctor = New Eniac.Controles.Buscador2()
        Me.Label3 = New Eniac.Controles.Label()
        Me.bscDoctor = New Eniac.Controles.Buscador2()
        Me.Label4 = New Eniac.Controles.Label()
        Me.chbDoctor = New Eniac.Controles.CheckBox()
        Me.bscCodigoPaciente = New Eniac.Controles.Buscador2()
        Me.Label1 = New Eniac.Controles.Label()
        Me.bscPaciente = New Eniac.Controles.Buscador2()
        Me.Label2 = New Eniac.Controles.Label()
        Me.chbPaciente = New Eniac.Controles.CheckBox()
        Me.cmbOrigenCategoria = New Eniac.Controles.ComboBox()
        Me.cmbOrigenVendedor = New Eniac.Controles.ComboBox()
        Me.lblCajas = New Eniac.Controles.Label()
        Me.cmbCajas = New Eniac.Win.ComboBoxCajas()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.cmbSubSubRubro = New Eniac.Controles.ComboBox()
        Me.chbSubSubRubro = New Eniac.Controles.CheckBox()
        Me.cmbSubRubro = New Eniac.Controles.ComboBox()
        Me.chbSubRubro = New Eniac.Controles.CheckBox()
        Me.chbLetra = New Eniac.Controles.CheckBox()
        Me.chbEmisor = New Eniac.Controles.CheckBox()
        Me.cmbEmisor = New Eniac.Controles.ComboBox()
        Me.cboLetra = New Eniac.Controles.ComboBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.txtNumero = New Eniac.Controles.TextBox()
        Me.cmbTipoOperacion = New Eniac.Controles.ComboBox()
        Me.chbTipoOperacion = New Eniac.Controles.CheckBox()
        Me.cmbNota = New Eniac.Controles.ComboBox()
        Me.cmbListaPrecios = New Eniac.Controles.ComboBox()
        Me.chbListaPrecios = New Eniac.Controles.CheckBox()
        Me.chbCategoria = New Eniac.Controles.CheckBox()
        Me.cmbCategoria = New Eniac.Controles.ComboBox()
        Me.chbProvincia = New Eniac.Controles.CheckBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.cmbProvincia = New Eniac.Controles.ComboBox()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.lblProdDescRec = New Eniac.Controles.Label()
        Me.cmbProdDescRec = New Eniac.Controles.ComboBox()
        Me.lblIngresosBrutos = New Eniac.Controles.Label()
        Me.cmbIngresosBrutos = New Eniac.Controles.ComboBox()
        Me.chbCantidad = New Eniac.Controles.CheckBox()
        Me.cmbCantidad = New Eniac.Controles.ComboBox()
        Me.chbProducto = New Eniac.Controles.CheckBox()
        Me.bscLote = New Eniac.Controles.Buscador()
        Me.chbLote = New Eniac.Controles.CheckBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.chbMarca = New Eniac.Controles.CheckBox()
        Me.cmbRubro = New Eniac.Controles.ComboBox()
        Me.chbRubro = New Eniac.Controles.CheckBox()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.chbFormaPago = New Eniac.Controles.CheckBox()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.chbTransportista = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbTransportista = New Eniac.Controles.ComboBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.cmbAfectaCaja = New Eniac.Controles.ComboBox()
        Me.lblAfectaCaja = New Eniac.Controles.Label()
        Me.lblNota = New Eniac.Controles.Label()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpFiltros = New System.Windows.Forms.TabPage()
        Me.tbpDatos = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.txtFiltros = New Eniac.Win.TextBoxParaMostrarFiltros()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.gbHistoriaClinica.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbpFiltros.SuspendLayout()
        Me.tbpDatos.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27, UltraDataColumn28, UltraDataColumn29, UltraDataColumn30, UltraDataColumn31})
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance53.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance53.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance53
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
        Me.TableLayoutPanel1.SetColumnSpan(Me.ugDetalle, 3)
        Me.ugDetalle.DataSource = Me.UltraDataSource2
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn67.CellAppearance = Appearance2
        UltraGridColumn67.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn67.Header.VisiblePosition = 4
        UltraGridColumn67.Width = 100
        UltraGridColumn68.Header.VisiblePosition = 5
        UltraGridColumn68.Hidden = True
        UltraGridColumn69.Header.Caption = "Comprobante"
        UltraGridColumn69.Header.VisiblePosition = 6
        UltraGridColumn69.Width = 80
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn70.CellAppearance = Appearance3
        UltraGridColumn70.Header.Caption = "L."
        UltraGridColumn70.Header.VisiblePosition = 7
        UltraGridColumn70.Width = 20
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn71.CellAppearance = Appearance4
        UltraGridColumn71.Header.Caption = "Emisor"
        UltraGridColumn71.Header.VisiblePosition = 8
        UltraGridColumn71.Width = 40
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn72.CellAppearance = Appearance5
        UltraGridColumn72.Header.Caption = "Número"
        UltraGridColumn72.Header.VisiblePosition = 9
        UltraGridColumn72.Width = 52
        UltraGridColumn73.Header.VisiblePosition = 10
        UltraGridColumn73.Hidden = True
        UltraGridColumn74.Header.Caption = "Nombre Cliente"
        UltraGridColumn74.Header.VisiblePosition = 21
        UltraGridColumn74.Width = 144
        UltraGridColumn75.Header.Caption = "Categ. Fiscal"
        UltraGridColumn75.Header.VisiblePosition = 29
        UltraGridColumn75.Width = 100
        UltraGridColumn76.Header.Caption = "F. de Pago"
        UltraGridColumn76.Header.VisiblePosition = 30
        UltraGridColumn76.Width = 80
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn77.CellAppearance = Appearance6
        UltraGridColumn77.Header.Caption = "Producto"
        UltraGridColumn77.Header.VisiblePosition = 11
        UltraGridColumn77.Width = 79
        UltraGridColumn78.Header.Caption = "Nombre Producto"
        UltraGridColumn78.Header.VisiblePosition = 12
        UltraGridColumn78.Width = 152
        UltraGridColumn79.Header.Caption = "Nombre Actual del Producto"
        UltraGridColumn79.Header.VisiblePosition = 24
        UltraGridColumn79.Hidden = True
        UltraGridColumn79.Width = 152
        UltraGridColumn80.Header.Caption = "Marca"
        UltraGridColumn80.Header.VisiblePosition = 36
        UltraGridColumn80.Width = 150
        UltraGridColumn81.Header.Caption = "Rubro"
        UltraGridColumn81.Header.VisiblePosition = 37
        UltraGridColumn81.Width = 150
        UltraGridColumn82.Header.Caption = "Subrubro"
        UltraGridColumn82.Header.VisiblePosition = 38
        UltraGridColumn82.Width = 150
        UltraGridColumn83.Header.Caption = "Subsubrubro"
        UltraGridColumn83.Header.VisiblePosition = 39
        UltraGridColumn83.Width = 150
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn84.CellAppearance = Appearance7
        UltraGridColumn84.Format = "##,##0.00"
        UltraGridColumn84.Header.VisiblePosition = 40
        UltraGridColumn84.Width = 70
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn85.CellAppearance = Appearance8
        UltraGridColumn85.Format = "##,##0.00"
        UltraGridColumn85.Header.Caption = "Prec. Lista s/Iva"
        UltraGridColumn85.Header.VisiblePosition = 41
        UltraGridColumn85.Width = 92
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn86.CellAppearance = Appearance9
        UltraGridColumn86.Format = "##,##0.00"
        UltraGridColumn86.Header.Caption = "Precio s/Iva"
        UltraGridColumn86.Header.VisiblePosition = 43
        UltraGridColumn86.Width = 92
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn87.CellAppearance = Appearance10
        UltraGridColumn87.Format = "##,##0.00"
        UltraGridColumn87.Header.Caption = "Precio c/Iva"
        UltraGridColumn87.Header.VisiblePosition = 44
        UltraGridColumn87.Hidden = True
        UltraGridColumn87.Width = 92
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn88.CellAppearance = Appearance11
        UltraGridColumn88.Format = "##0.00"
        UltraGridColumn88.Header.Caption = "D/R %1"
        UltraGridColumn88.Header.VisiblePosition = 45
        UltraGridColumn88.Width = 50
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn89.CellAppearance = Appearance12
        UltraGridColumn89.Format = "##0.00"
        UltraGridColumn89.Header.Caption = "D/R %2"
        UltraGridColumn89.Header.VisiblePosition = 48
        UltraGridColumn89.Width = 50
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn90.CellAppearance = Appearance13
        UltraGridColumn90.Format = "##0.00"
        UltraGridColumn90.Header.Caption = "D/R % G."
        UltraGridColumn90.Header.VisiblePosition = 51
        UltraGridColumn90.Width = 65
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn91.CellAppearance = Appearance14
        UltraGridColumn91.Format = "##,##0.00"
        UltraGridColumn91.Header.Caption = "Prec. Neto s/Iva"
        UltraGridColumn91.Header.VisiblePosition = 54
        UltraGridColumn91.Width = 92
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn92.CellAppearance = Appearance15
        UltraGridColumn92.Format = "##0.00"
        UltraGridColumn92.Header.Caption = "IVA %"
        UltraGridColumn92.Header.VisiblePosition = 56
        UltraGridColumn92.Width = 50
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn93.CellAppearance = Appearance16
        UltraGridColumn93.Format = "##,##0.00"
        UltraGridColumn93.Header.Caption = "Neto"
        UltraGridColumn93.Header.VisiblePosition = 25
        UltraGridColumn93.Width = 70
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn94.CellAppearance = Appearance17
        UltraGridColumn94.Format = "N2"
        UltraGridColumn94.Header.Caption = "IVA"
        UltraGridColumn94.Header.VisiblePosition = 26
        UltraGridColumn94.Width = 61
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn95.CellAppearance = Appearance18
        UltraGridColumn95.Format = "N2"
        UltraGridColumn95.Header.Caption = "Imp.Internos"
        UltraGridColumn95.Header.VisiblePosition = 27
        UltraGridColumn95.Width = 70
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn96.CellAppearance = Appearance19
        UltraGridColumn96.Format = "##,##0.00"
        UltraGridColumn96.Header.Caption = "Total"
        UltraGridColumn96.Header.VisiblePosition = 28
        UltraGridColumn96.Width = 70
        UltraGridColumn97.Header.VisiblePosition = 62
        UltraGridColumn97.Width = 80
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn98.CellAppearance = Appearance20
        UltraGridColumn98.Header.Caption = "Tamaño"
        UltraGridColumn98.Header.VisiblePosition = 34
        UltraGridColumn98.Width = 60
        Appearance21.TextHAlignAsString = "Center"
        UltraGridColumn99.CellAppearance = Appearance21
        UltraGridColumn99.Header.Caption = "UM"
        UltraGridColumn99.Header.VisiblePosition = 35
        UltraGridColumn99.Width = 40
        UltraGridColumn100.Header.Caption = "Vendedor"
        UltraGridColumn100.Header.VisiblePosition = 32
        UltraGridColumn101.Header.Caption = "Zona Geografica"
        UltraGridColumn101.Header.VisiblePosition = 31
        UltraGridColumn101.Width = 110
        UltraGridColumn102.Header.Caption = "Localidad"
        UltraGridColumn102.Header.VisiblePosition = 63
        UltraGridColumn102.Width = 130
        UltraGridColumn103.Header.Caption = "Provincia"
        UltraGridColumn103.Header.VisiblePosition = 64
        UltraGridColumn103.Width = 110
        UltraGridColumn104.Header.Caption = "Lista Precios"
        UltraGridColumn104.Header.VisiblePosition = 57
        UltraGridColumn105.Header.Caption = "Categoría"
        UltraGridColumn105.Header.VisiblePosition = 65
        UltraGridColumn106.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn106.CellAppearance = Appearance22
        UltraGridColumn106.Header.Caption = "C. C."
        UltraGridColumn106.Header.VisiblePosition = 66
        UltraGridColumn106.Hidden = True
        UltraGridColumn106.Width = 43
        UltraGridColumn107.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn107.Header.Caption = "Centro de Costo"
        UltraGridColumn107.Header.VisiblePosition = 69
        UltraGridColumn107.Width = 120
        UltraGridColumn108.Header.VisiblePosition = 70
        UltraGridColumn108.Width = 250
        UltraGridColumn109.Header.Caption = "Detalle del Producto"
        UltraGridColumn109.Header.VisiblePosition = 71
        UltraGridColumn109.Width = 250
        UltraGridColumn110.Header.Caption = "Tp. Oper."
        UltraGridColumn110.Header.VisiblePosition = 60
        UltraGridColumn110.Hidden = True
        UltraGridColumn110.Width = 80
        UltraGridColumn111.Header.VisiblePosition = 61
        UltraGridColumn111.Hidden = True
        UltraGridColumn111.Width = 150
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn112.CellAppearance = Appearance23
        UltraGridColumn112.Header.Caption = "Código Transportista"
        UltraGridColumn112.Header.VisiblePosition = 72
        UltraGridColumn112.Hidden = True
        UltraGridColumn113.Header.Caption = "Transportista"
        UltraGridColumn113.Header.VisiblePosition = 33
        UltraGridColumn113.Width = 106
        UltraGridColumn114.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance24.TextHAlignAsString = "Center"
        UltraGridColumn114.CellAppearance = Appearance24
        UltraGridColumn114.Header.VisiblePosition = 0
        UltraGridColumn114.MaxWidth = 30
        UltraGridColumn114.MinWidth = 30
        UltraGridColumn114.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn114.Width = 30
        UltraGridColumn115.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance25.TextHAlignAsString = "Center"
        UltraGridColumn115.CellAppearance = Appearance25
        UltraGridColumn115.Header.Caption = "V.E."
        UltraGridColumn115.Header.VisiblePosition = 2
        UltraGridColumn115.Hidden = True
        UltraGridColumn115.MaxWidth = 30
        UltraGridColumn115.MinWidth = 30
        UltraGridColumn115.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn115.Width = 30
        UltraGridColumn116.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance26.TextHAlignAsString = "Center"
        UltraGridColumn116.CellAppearance = Appearance26
        UltraGridColumn116.Header.Caption = "Imp."
        UltraGridColumn116.Header.VisiblePosition = 1
        UltraGridColumn116.Hidden = True
        UltraGridColumn116.MaxWidth = 30
        UltraGridColumn116.MinWidth = 30
        UltraGridColumn116.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn116.Width = 30
        UltraGridColumn117.Header.VisiblePosition = 73
        UltraGridColumn117.Hidden = True
        UltraGridColumn118.Header.Caption = "Formula"
        UltraGridColumn118.Header.VisiblePosition = 67
        UltraGridColumn119.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance27.TextHAlignAsString = "Center"
        UltraGridColumn119.CellAppearance = Appearance27
        UltraGridColumn119.Header.Caption = ""
        UltraGridColumn119.Header.VisiblePosition = 68
        UltraGridColumn119.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn119.Width = 27
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn120.CellAppearance = Appearance28
        UltraGridColumn120.Header.Caption = "Suc."
        UltraGridColumn120.Header.VisiblePosition = 3
        UltraGridColumn120.Hidden = True
        UltraGridColumn120.Width = 40
        UltraGridColumn121.Header.VisiblePosition = 75
        UltraGridColumn121.Hidden = True
        UltraGridColumn122.Header.Caption = "Caja"
        UltraGridColumn122.Header.VisiblePosition = 59
        UltraGridColumn123.Header.VisiblePosition = 76
        UltraGridColumn123.Hidden = True
        UltraGridColumn124.Header.Caption = "Motivo Nota de Crédito"
        UltraGridColumn124.Header.VisiblePosition = 77
        UltraGridColumn124.Width = 250
        Appearance29.TextHAlignAsString = "Right"
        UltraGridColumn125.CellAppearance = Appearance29
        UltraGridColumn125.Format = "N2"
        UltraGridColumn125.Header.VisiblePosition = 58
        UltraGridColumn125.Width = 68
        Appearance30.TextHAlignAsString = "Right"
        UltraGridColumn126.CellAppearance = Appearance30
        UltraGridColumn126.Format = "##,##0.00"
        UltraGridColumn126.Header.Caption = "Prec. Lista c/Iva"
        UltraGridColumn126.Header.VisiblePosition = 42
        UltraGridColumn126.Hidden = True
        UltraGridColumn126.Width = 92
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn127.CellAppearance = Appearance31
        UltraGridColumn127.Format = "##,##0.00"
        UltraGridColumn127.Header.Caption = "Prec. Neto c/Iva"
        UltraGridColumn127.Header.VisiblePosition = 55
        UltraGridColumn127.Hidden = True
        UltraGridColumn127.Width = 92
        Appearance32.TextHAlignAsString = "Right"
        UltraGridColumn128.CellAppearance = Appearance32
        UltraGridColumn128.Header.VisiblePosition = 78
        UltraGridColumn128.Hidden = True
        Appearance33.TextHAlignAsString = "Right"
        UltraGridColumn129.CellAppearance = Appearance33
        UltraGridColumn129.Header.VisiblePosition = 79
        UltraGridColumn129.Hidden = True
        UltraGridColumn130.Header.Caption = "Paciente"
        UltraGridColumn130.Header.VisiblePosition = 80
        UltraGridColumn130.Hidden = True
        UltraGridColumn130.Width = 187
        UltraGridColumn131.Header.Caption = "Doctor"
        UltraGridColumn131.Header.VisiblePosition = 81
        UltraGridColumn131.Hidden = True
        UltraGridColumn131.Width = 193
        Appearance34.TextHAlignAsString = "Center"
        UltraGridColumn132.CellAppearance = Appearance34
        UltraGridColumn132.Header.Caption = "Fecha de Cirugía"
        UltraGridColumn132.Header.VisiblePosition = 82
        UltraGridColumn132.Hidden = True
        UltraGridColumn132.Width = 129
        Appearance35.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance35
        UltraGridColumn1.Format = "N2"
        UltraGridColumn1.Header.Caption = "Importe D/R 1"
        UltraGridColumn1.Header.VisiblePosition = 46
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance36
        UltraGridColumn4.Format = "N2"
        UltraGridColumn4.Header.Caption = "Importe D/R 2"
        UltraGridColumn4.Header.VisiblePosition = 49
        Appearance37.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance37
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "Importe D/R Gral"
        UltraGridColumn3.Header.VisiblePosition = 52
        Appearance38.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance38
        UltraGridColumn2.Format = "N2"
        UltraGridColumn2.Header.Caption = "Importe D/R 1 c/Iva"
        UltraGridColumn2.Header.VisiblePosition = 47
        UltraGridColumn2.Hidden = True
        Appearance39.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance39
        UltraGridColumn5.Format = "N2"
        UltraGridColumn5.Header.Caption = "Importe D/R 2 c/Iva"
        UltraGridColumn5.Header.VisiblePosition = 50
        UltraGridColumn5.Hidden = True
        Appearance40.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance40
        UltraGridColumn6.Format = "N2"
        UltraGridColumn6.Header.Caption = "Importe D/R Gral c/Iva"
        UltraGridColumn6.Header.VisiblePosition = 53
        UltraGridColumn6.Hidden = True
        UltraGridColumn17.Header.Caption = "Codigo De Barras"
        UltraGridColumn17.Header.VisiblePosition = 74
        UltraGridColumn17.Hidden = True
        UltraGridColumn21.Header.Caption = "Nombre Cliente Vinculado"
        UltraGridColumn21.Header.VisiblePosition = 22
        UltraGridColumn21.Width = 143
        UltraGridColumn7.Header.Caption = "Telefono Cliente"
        UltraGridColumn7.Header.VisiblePosition = 23
        UltraGridColumn8.Header.VisiblePosition = 13
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.Caption = "Descripcion"
        UltraGridColumn9.Header.VisiblePosition = 14
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.Header.VisiblePosition = 15
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.Caption = "Descripcion"
        UltraGridColumn11.Header.VisiblePosition = 16
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.VisiblePosition = 17
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.Caption = "Descripcion"
        UltraGridColumn13.Header.VisiblePosition = 18
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.Header.VisiblePosition = 19
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.Header.Caption = "Descripcion"
        UltraGridColumn15.Header.VisiblePosition = 20
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.Header.Caption = "Proveedor Habitual"
        UltraGridColumn16.Header.VisiblePosition = 83
        UltraGridColumn16.Width = 150
        UltraGridColumn18.Header.Caption = "Codigo Prod.Prov."
        UltraGridColumn18.Header.VisiblePosition = 84
        UltraGridColumn18.Width = 100
        UltraGridColumn19.Header.Caption = "Proveedor OC"
        UltraGridColumn19.Header.VisiblePosition = 85
        UltraGridColumn19.Width = 150
        Appearance41.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance41
        UltraGridColumn20.Header.Caption = "Numero OC"
        UltraGridColumn20.Header.VisiblePosition = 86
        UltraGridColumn20.Width = 80
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114, UltraGridColumn115, UltraGridColumn116, UltraGridColumn117, UltraGridColumn118, UltraGridColumn119, UltraGridColumn120, UltraGridColumn121, UltraGridColumn122, UltraGridColumn123, UltraGridColumn124, UltraGridColumn125, UltraGridColumn126, UltraGridColumn127, UltraGridColumn128, UltraGridColumn129, UltraGridColumn130, UltraGridColumn131, UltraGridColumn132, UltraGridColumn1, UltraGridColumn4, UltraGridColumn3, UltraGridColumn2, UltraGridColumn5, UltraGridColumn6, UltraGridColumn17, UltraGridColumn21, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance42.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance42.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance42.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance42
        Appearance43.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance43
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance44.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance44.BackColor2 = System.Drawing.SystemColors.Control
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance44.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance44
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance45.BackColor = System.Drawing.SystemColors.Window
        Appearance45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance45
        Appearance46.BackColor = System.Drawing.SystemColors.Highlight
        Appearance46.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance46
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance47
        Appearance48.BorderColor = System.Drawing.Color.Silver
        Appearance48.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance48
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance49.BackColor = System.Drawing.SystemColors.Control
        Appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance49.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance49.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance49
        Appearance50.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance50
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Appearance51.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance51
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance52
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(3, 30)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(942, 446)
        Me.ugDetalle.TabIndex = 3
        '
        'UltraDataSource2
        '
        Me.UltraDataSource2.Band.Columns.AddRange(New Object() {UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35, UltraDataColumn36, UltraDataColumn37, UltraDataColumn38, UltraDataColumn39, UltraDataColumn40, UltraDataColumn41, UltraDataColumn42, UltraDataColumn43, UltraDataColumn44, UltraDataColumn45, UltraDataColumn46, UltraDataColumn47, UltraDataColumn48, UltraDataColumn49, UltraDataColumn50, UltraDataColumn51, UltraDataColumn52, UltraDataColumn53, UltraDataColumn54, UltraDataColumn55, UltraDataColumn56, UltraDataColumn57, UltraDataColumn58, UltraDataColumn59, UltraDataColumn60, UltraDataColumn61, UltraDataColumn62, UltraDataColumn63, UltraDataColumn64, UltraDataColumn65, UltraDataColumn66, UltraDataColumn67, UltraDataColumn68, UltraDataColumn69, UltraDataColumn70, UltraDataColumn71, UltraDataColumn72, UltraDataColumn73, UltraDataColumn74, UltraDataColumn75, UltraDataColumn76, UltraDataColumn77, UltraDataColumn78, UltraDataColumn79, UltraDataColumn80, UltraDataColumn81, UltraDataColumn82, UltraDataColumn83, UltraDataColumn84, UltraDataColumn85, UltraDataColumn86, UltraDataColumn87, UltraDataColumn88, UltraDataColumn89, UltraDataColumn90, UltraDataColumn91, UltraDataColumn92, UltraDataColumn93, UltraDataColumn94, UltraDataColumn95, UltraDataColumn96, UltraDataColumn97, UltraDataColumn98, UltraDataColumn99, UltraDataColumn100, UltraDataColumn101, UltraDataColumn102, UltraDataColumn103, UltraDataColumn104, UltraDataColumn105})
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 540)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(962, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(883, 17)
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(962, 29)
        Me.tstBarra.TabIndex = 1
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = Global.Eniac.Win.My.Resources.Resources.window_ok_24
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.cmbTipoCliente)
        Me.grbConsultar.Controls.Add(Me.lblCliente)
        Me.grbConsultar.Controls.Add(Me.gbHistoriaClinica)
        Me.grbConsultar.Controls.Add(Me.cmbOrigenCategoria)
        Me.grbConsultar.Controls.Add(Me.cmbOrigenVendedor)
        Me.grbConsultar.Controls.Add(Me.lblCajas)
        Me.grbConsultar.Controls.Add(Me.cmbCajas)
        Me.grbConsultar.Controls.Add(Me.lblSucursal)
        Me.grbConsultar.Controls.Add(Me.cmbSucursal)
        Me.grbConsultar.Controls.Add(Me.cmbSubSubRubro)
        Me.grbConsultar.Controls.Add(Me.chbSubSubRubro)
        Me.grbConsultar.Controls.Add(Me.cmbSubRubro)
        Me.grbConsultar.Controls.Add(Me.chbSubRubro)
        Me.grbConsultar.Controls.Add(Me.chbLetra)
        Me.grbConsultar.Controls.Add(Me.chbEmisor)
        Me.grbConsultar.Controls.Add(Me.cmbEmisor)
        Me.grbConsultar.Controls.Add(Me.cboLetra)
        Me.grbConsultar.Controls.Add(Me.chbNumero)
        Me.grbConsultar.Controls.Add(Me.txtNumero)
        Me.grbConsultar.Controls.Add(Me.cmbTipoOperacion)
        Me.grbConsultar.Controls.Add(Me.chbTipoOperacion)
        Me.grbConsultar.Controls.Add(Me.cmbNota)
        Me.grbConsultar.Controls.Add(Me.cmbListaPrecios)
        Me.grbConsultar.Controls.Add(Me.chbListaPrecios)
        Me.grbConsultar.Controls.Add(Me.chbCategoria)
        Me.grbConsultar.Controls.Add(Me.cmbCategoria)
        Me.grbConsultar.Controls.Add(Me.chbProvincia)
        Me.grbConsultar.Controls.Add(Me.chbLocalidad)
        Me.grbConsultar.Controls.Add(Me.cmbProvincia)
        Me.grbConsultar.Controls.Add(Me.bscCodigoLocalidad)
        Me.grbConsultar.Controls.Add(Me.bscNombreLocalidad)
        Me.grbConsultar.Controls.Add(Me.chbZonaGeografica)
        Me.grbConsultar.Controls.Add(Me.cmbZonaGeografica)
        Me.grbConsultar.Controls.Add(Me.bscProducto2)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProducto2)
        Me.grbConsultar.Controls.Add(Me.bscProveedor)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.chbProveedor)
        Me.grbConsultar.Controls.Add(Me.lblProdDescRec)
        Me.grbConsultar.Controls.Add(Me.cmbProdDescRec)
        Me.grbConsultar.Controls.Add(Me.lblIngresosBrutos)
        Me.grbConsultar.Controls.Add(Me.cmbIngresosBrutos)
        Me.grbConsultar.Controls.Add(Me.chbCantidad)
        Me.grbConsultar.Controls.Add(Me.cmbCantidad)
        Me.grbConsultar.Controls.Add(Me.chbProducto)
        Me.grbConsultar.Controls.Add(Me.bscLote)
        Me.grbConsultar.Controls.Add(Me.chbLote)
        Me.grbConsultar.Controls.Add(Me.cmbMarca)
        Me.grbConsultar.Controls.Add(Me.chbMarca)
        Me.grbConsultar.Controls.Add(Me.cmbRubro)
        Me.grbConsultar.Controls.Add(Me.chbRubro)
        Me.grbConsultar.Controls.Add(Me.chbUsuario)
        Me.grbConsultar.Controls.Add(Me.cmbUsuario)
        Me.grbConsultar.Controls.Add(Me.chbFormaPago)
        Me.grbConsultar.Controls.Add(Me.cmbFormaPago)
        Me.grbConsultar.Controls.Add(Me.chbTransportista)
        Me.grbConsultar.Controls.Add(Me.chbVendedor)
        Me.grbConsultar.Controls.Add(Me.cmbTransportista)
        Me.grbConsultar.Controls.Add(Me.cmbVendedor)
        Me.grbConsultar.Controls.Add(Me.cmbAfectaCaja)
        Me.grbConsultar.Controls.Add(Me.lblNota)
        Me.grbConsultar.Controls.Add(Me.lblAfectaCaja)
        Me.grbConsultar.Controls.Add(Me.cmbGrabanLibro)
        Me.grbConsultar.Controls.Add(Me.lblGrabanLibro)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.chbTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Controls.Add(Me.bscCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.bscCliente)
        Me.grbConsultar.Controls.Add(Me.lblCodigoCliente)
        Me.grbConsultar.Controls.Add(Me.lblNombre)
        Me.grbConsultar.Controls.Add(Me.chbCliente)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbConsultar.Location = New System.Drawing.Point(3, 3)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(948, 479)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
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
        Me.cmbTipoCliente.Location = New System.Drawing.Point(462, 196)
        Me.cmbTipoCliente.Name = "cmbTipoCliente"
        Me.cmbTipoCliente.Size = New System.Drawing.Size(94, 21)
        Me.cmbTipoCliente.TabIndex = 76
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Location = New System.Drawing.Point(458, 183)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(66, 13)
        Me.lblCliente.TabIndex = 75
        Me.lblCliente.Text = "Tipo Cliente "
        '
        'gbHistoriaClinica
        '
        Me.gbHistoriaClinica.Controls.Add(Me.chbFechaCirugia)
        Me.gbHistoriaClinica.Controls.Add(Me.dtpFechaCirugia)
        Me.gbHistoriaClinica.Controls.Add(Me.lblFechaCirugia)
        Me.gbHistoriaClinica.Controls.Add(Me.bscCodigoDoctor)
        Me.gbHistoriaClinica.Controls.Add(Me.bscDoctor)
        Me.gbHistoriaClinica.Controls.Add(Me.Label3)
        Me.gbHistoriaClinica.Controls.Add(Me.Label4)
        Me.gbHistoriaClinica.Controls.Add(Me.chbDoctor)
        Me.gbHistoriaClinica.Controls.Add(Me.bscCodigoPaciente)
        Me.gbHistoriaClinica.Controls.Add(Me.bscPaciente)
        Me.gbHistoriaClinica.Controls.Add(Me.Label1)
        Me.gbHistoriaClinica.Controls.Add(Me.Label2)
        Me.gbHistoriaClinica.Controls.Add(Me.chbPaciente)
        Me.gbHistoriaClinica.Location = New System.Drawing.Point(3, 369)
        Me.gbHistoriaClinica.Name = "gbHistoriaClinica"
        Me.gbHistoriaClinica.Size = New System.Drawing.Size(616, 104)
        Me.gbHistoriaClinica.TabIndex = 68
        Me.gbHistoriaClinica.TabStop = False
        Me.gbHistoriaClinica.Text = "Historia Clínica"
        Me.gbHistoriaClinica.Visible = False
        '
        'chbFechaCirugia
        '
        Me.chbFechaCirugia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbFechaCirugia.AutoSize = True
        Me.chbFechaCirugia.BindearPropiedadControl = Nothing
        Me.chbFechaCirugia.BindearPropiedadEntidad = Nothing
        Me.chbFechaCirugia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaCirugia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaCirugia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbFechaCirugia.IsPK = False
        Me.chbFechaCirugia.IsRequired = False
        Me.chbFechaCirugia.Key = Nothing
        Me.chbFechaCirugia.LabelAsoc = Nothing
        Me.chbFechaCirugia.Location = New System.Drawing.Point(479, 75)
        Me.chbFechaCirugia.Name = "chbFechaCirugia"
        Me.chbFechaCirugia.Size = New System.Drawing.Size(15, 14)
        Me.chbFechaCirugia.TabIndex = 13
        Me.chbFechaCirugia.UseVisualStyleBackColor = True
        '
        'dtpFechaCirugia
        '
        Me.dtpFechaCirugia.BindearPropiedadControl = Nothing
        Me.dtpFechaCirugia.BindearPropiedadEntidad = Nothing
        Me.dtpFechaCirugia.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCirugia.Enabled = False
        Me.dtpFechaCirugia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFechaCirugia.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCirugia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCirugia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCirugia.IsPK = False
        Me.dtpFechaCirugia.IsRequired = False
        Me.dtpFechaCirugia.Key = ""
        Me.dtpFechaCirugia.LabelAsoc = Me.lblFechaCirugia
        Me.dtpFechaCirugia.Location = New System.Drawing.Point(500, 69)
        Me.dtpFechaCirugia.Name = "dtpFechaCirugia"
        Me.dtpFechaCirugia.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaCirugia.TabIndex = 15
        '
        'lblFechaCirugia
        '
        Me.lblFechaCirugia.AutoSize = True
        Me.lblFechaCirugia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFechaCirugia.LabelAsoc = Nothing
        Me.lblFechaCirugia.Location = New System.Drawing.Point(497, 55)
        Me.lblFechaCirugia.Name = "lblFechaCirugia"
        Me.lblFechaCirugia.Size = New System.Drawing.Size(89, 13)
        Me.lblFechaCirugia.TabIndex = 14
        Me.lblFechaCirugia.Text = "Fecha de Cirugía"
        '
        'bscCodigoDoctor
        '
        Me.bscCodigoDoctor.ActivarFiltroEnGrilla = True
        Me.bscCodigoDoctor.BindearPropiedadControl = Nothing
        Me.bscCodigoDoctor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoDoctor.ConfigBuscador = Nothing
        Me.bscCodigoDoctor.Datos = Nothing
        Me.bscCodigoDoctor.Enabled = False
        Me.bscCodigoDoctor.FilaDevuelta = Nothing
        Me.bscCodigoDoctor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoDoctor.IsDecimal = False
        Me.bscCodigoDoctor.IsNumber = False
        Me.bscCodigoDoctor.IsPK = False
        Me.bscCodigoDoctor.IsRequired = False
        Me.bscCodigoDoctor.Key = ""
        Me.bscCodigoDoctor.LabelAsoc = Me.Label3
        Me.bscCodigoDoctor.Location = New System.Drawing.Point(85, 70)
        Me.bscCodigoDoctor.MaxLengh = "32767"
        Me.bscCodigoDoctor.Name = "bscCodigoDoctor"
        Me.bscCodigoDoctor.Permitido = True
        Me.bscCodigoDoctor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoDoctor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoDoctor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoDoctor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoDoctor.Selecciono = False
        Me.bscCodigoDoctor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoDoctor.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(83, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Código"
        '
        'bscDoctor
        '
        Me.bscDoctor.ActivarFiltroEnGrilla = True
        Me.bscDoctor.AutoSize = True
        Me.bscDoctor.BindearPropiedadControl = Nothing
        Me.bscDoctor.BindearPropiedadEntidad = Nothing
        Me.bscDoctor.ConfigBuscador = Nothing
        Me.bscDoctor.Datos = Nothing
        Me.bscDoctor.Enabled = False
        Me.bscDoctor.FilaDevuelta = Nothing
        Me.bscDoctor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscDoctor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDoctor.IsDecimal = False
        Me.bscDoctor.IsNumber = False
        Me.bscDoctor.IsPK = False
        Me.bscDoctor.IsRequired = False
        Me.bscDoctor.Key = ""
        Me.bscDoctor.LabelAsoc = Me.Label4
        Me.bscDoctor.Location = New System.Drawing.Point(182, 70)
        Me.bscDoctor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscDoctor.MaxLengh = "32767"
        Me.bscDoctor.Name = "bscDoctor"
        Me.bscDoctor.Permitido = True
        Me.bscDoctor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscDoctor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscDoctor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscDoctor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscDoctor.Selecciono = False
        Me.bscDoctor.Size = New System.Drawing.Size(270, 23)
        Me.bscDoctor.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(180, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nombre"
        '
        'chbDoctor
        '
        Me.chbDoctor.AutoSize = True
        Me.chbDoctor.BindearPropiedadControl = Nothing
        Me.chbDoctor.BindearPropiedadEntidad = Nothing
        Me.chbDoctor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDoctor.IsPK = False
        Me.chbDoctor.IsRequired = False
        Me.chbDoctor.Key = Nothing
        Me.chbDoctor.LabelAsoc = Nothing
        Me.chbDoctor.Location = New System.Drawing.Point(6, 72)
        Me.chbDoctor.Name = "chbDoctor"
        Me.chbDoctor.Size = New System.Drawing.Size(58, 17)
        Me.chbDoctor.TabIndex = 5
        Me.chbDoctor.Text = "Doctor"
        Me.chbDoctor.UseVisualStyleBackColor = True
        '
        'bscCodigoPaciente
        '
        Me.bscCodigoPaciente.ActivarFiltroEnGrilla = True
        Me.bscCodigoPaciente.BindearPropiedadControl = Nothing
        Me.bscCodigoPaciente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoPaciente.ConfigBuscador = Nothing
        Me.bscCodigoPaciente.Datos = Nothing
        Me.bscCodigoPaciente.Enabled = False
        Me.bscCodigoPaciente.FilaDevuelta = Nothing
        Me.bscCodigoPaciente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoPaciente.IsDecimal = False
        Me.bscCodigoPaciente.IsNumber = False
        Me.bscCodigoPaciente.IsPK = False
        Me.bscCodigoPaciente.IsRequired = False
        Me.bscCodigoPaciente.Key = ""
        Me.bscCodigoPaciente.LabelAsoc = Me.Label1
        Me.bscCodigoPaciente.Location = New System.Drawing.Point(85, 30)
        Me.bscCodigoPaciente.MaxLengh = "32767"
        Me.bscCodigoPaciente.Name = "bscCodigoPaciente"
        Me.bscCodigoPaciente.Permitido = True
        Me.bscCodigoPaciente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoPaciente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoPaciente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoPaciente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoPaciente.Selecciono = False
        Me.bscCodigoPaciente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoPaciente.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(83, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Código"
        '
        'bscPaciente
        '
        Me.bscPaciente.ActivarFiltroEnGrilla = True
        Me.bscPaciente.AutoSize = True
        Me.bscPaciente.BindearPropiedadControl = Nothing
        Me.bscPaciente.BindearPropiedadEntidad = Nothing
        Me.bscPaciente.ConfigBuscador = Nothing
        Me.bscPaciente.Datos = Nothing
        Me.bscPaciente.Enabled = False
        Me.bscPaciente.FilaDevuelta = Nothing
        Me.bscPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscPaciente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscPaciente.IsDecimal = False
        Me.bscPaciente.IsNumber = False
        Me.bscPaciente.IsPK = False
        Me.bscPaciente.IsRequired = False
        Me.bscPaciente.Key = ""
        Me.bscPaciente.LabelAsoc = Me.Label2
        Me.bscPaciente.Location = New System.Drawing.Point(182, 30)
        Me.bscPaciente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscPaciente.MaxLengh = "32767"
        Me.bscPaciente.Name = "bscPaciente"
        Me.bscPaciente.Permitido = True
        Me.bscPaciente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscPaciente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscPaciente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscPaciente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscPaciente.Selecciono = False
        Me.bscPaciente.Size = New System.Drawing.Size(270, 23)
        Me.bscPaciente.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(180, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'chbPaciente
        '
        Me.chbPaciente.AutoSize = True
        Me.chbPaciente.BindearPropiedadControl = Nothing
        Me.chbPaciente.BindearPropiedadEntidad = Nothing
        Me.chbPaciente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPaciente.IsPK = False
        Me.chbPaciente.IsRequired = False
        Me.chbPaciente.Key = Nothing
        Me.chbPaciente.LabelAsoc = Nothing
        Me.chbPaciente.Location = New System.Drawing.Point(6, 32)
        Me.chbPaciente.Name = "chbPaciente"
        Me.chbPaciente.Size = New System.Drawing.Size(68, 17)
        Me.chbPaciente.TabIndex = 0
        Me.chbPaciente.Text = "Paciente"
        Me.chbPaciente.UseVisualStyleBackColor = True
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
        Me.cmbOrigenCategoria.Location = New System.Drawing.Point(843, 198)
        Me.cmbOrigenCategoria.Name = "cmbOrigenCategoria"
        Me.cmbOrigenCategoria.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenCategoria.TabIndex = 74
        '
        'cmbOrigenVendedor
        '
        Me.cmbOrigenVendedor.BindearPropiedadControl = Nothing
        Me.cmbOrigenVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenVendedor.FormattingEnabled = True
        Me.cmbOrigenVendedor.IsPK = False
        Me.cmbOrigenVendedor.IsRequired = False
        Me.cmbOrigenVendedor.Key = Nothing
        Me.cmbOrigenVendedor.LabelAsoc = Nothing
        Me.cmbOrigenVendedor.Location = New System.Drawing.Point(251, 278)
        Me.cmbOrigenVendedor.Name = "cmbOrigenVendedor"
        Me.cmbOrigenVendedor.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenVendedor.TabIndex = 73
        '
        'lblCajas
        '
        Me.lblCajas.AutoSize = True
        Me.lblCajas.LabelAsoc = Nothing
        Me.lblCajas.Location = New System.Drawing.Point(420, 75)
        Me.lblCajas.Name = "lblCajas"
        Me.lblCajas.Size = New System.Drawing.Size(28, 13)
        Me.lblCajas.TabIndex = 72
        Me.lblCajas.Text = "Caja"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = Nothing
        Me.cmbCajas.BindearPropiedadEntidad = Nothing
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCajas
        Me.cmbCajas.Location = New System.Drawing.Point(451, 71)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(121, 21)
        Me.cmbCajas.SucursalesSeleccionadas = Nothing
        Me.cmbCajas.TabIndex = 71
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(26, 22)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 70
        Me.lblSucursal.Text = "Sucursal"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(90, 19)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(121, 21)
        Me.cmbSucursal.TabIndex = 69
        '
        'cmbSubSubRubro
        '
        Me.cmbSubSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubSubRubro.Enabled = False
        Me.cmbSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubSubRubro.FormattingEnabled = True
        Me.cmbSubSubRubro.IsPK = False
        Me.cmbSubSubRubro.IsRequired = False
        Me.cmbSubSubRubro.Key = Nothing
        Me.cmbSubSubRubro.LabelAsoc = Nothing
        Me.cmbSubSubRubro.Location = New System.Drawing.Point(686, 158)
        Me.cmbSubSubRubro.Name = "cmbSubSubRubro"
        Me.cmbSubSubRubro.Size = New System.Drawing.Size(183, 21)
        Me.cmbSubSubRubro.TabIndex = 35
        '
        'chbSubSubRubro
        '
        Me.chbSubSubRubro.AutoSize = True
        Me.chbSubSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubSubRubro.Enabled = False
        Me.chbSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubSubRubro.IsPK = False
        Me.chbSubSubRubro.IsRequired = False
        Me.chbSubSubRubro.Key = Nothing
        Me.chbSubSubRubro.LabelAsoc = Nothing
        Me.chbSubSubRubro.Location = New System.Drawing.Point(587, 160)
        Me.chbSubSubRubro.Name = "chbSubSubRubro"
        Me.chbSubSubRubro.Size = New System.Drawing.Size(93, 17)
        Me.chbSubSubRubro.TabIndex = 34
        Me.chbSubSubRubro.Text = "SubSubRubro"
        Me.chbSubSubRubro.UseVisualStyleBackColor = True
        '
        'cmbSubRubro
        '
        Me.cmbSubRubro.BindearPropiedadControl = Nothing
        Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
        Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubRubro.Enabled = False
        Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubRubro.FormattingEnabled = True
        Me.cmbSubRubro.IsPK = False
        Me.cmbSubRubro.IsRequired = False
        Me.cmbSubRubro.Key = Nothing
        Me.cmbSubRubro.LabelAsoc = Nothing
        Me.cmbSubRubro.Location = New System.Drawing.Point(373, 158)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(183, 21)
        Me.cmbSubRubro.TabIndex = 33
        '
        'chbSubRubro
        '
        Me.chbSubRubro.AutoSize = True
        Me.chbSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubRubro.Enabled = False
        Me.chbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubRubro.IsPK = False
        Me.chbSubRubro.IsRequired = False
        Me.chbSubRubro.Key = Nothing
        Me.chbSubRubro.LabelAsoc = Nothing
        Me.chbSubRubro.Location = New System.Drawing.Point(294, 160)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 32
        Me.chbSubRubro.Text = "SubRubro"
        Me.chbSubRubro.UseVisualStyleBackColor = True
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
        Me.chbLetra.Location = New System.Drawing.Point(537, 46)
        Me.chbLetra.Name = "chbLetra"
        Me.chbLetra.Size = New System.Drawing.Size(50, 17)
        Me.chbLetra.TabIndex = 7
        Me.chbLetra.Text = "Letra"
        Me.chbLetra.UseVisualStyleBackColor = True
        '
        'chbEmisor
        '
        Me.chbEmisor.AutoSize = True
        Me.chbEmisor.BindearPropiedadControl = Nothing
        Me.chbEmisor.BindearPropiedadEntidad = Nothing
        Me.chbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmisor.IsPK = False
        Me.chbEmisor.IsRequired = False
        Me.chbEmisor.Key = Nothing
        Me.chbEmisor.LabelAsoc = Nothing
        Me.chbEmisor.Location = New System.Drawing.Point(638, 46)
        Me.chbEmisor.Name = "chbEmisor"
        Me.chbEmisor.Size = New System.Drawing.Size(57, 17)
        Me.chbEmisor.TabIndex = 9
        Me.chbEmisor.Text = "Emisor"
        Me.chbEmisor.UseVisualStyleBackColor = True
        '
        'cmbEmisor
        '
        Me.cmbEmisor.BindearPropiedadControl = Nothing
        Me.cmbEmisor.BindearPropiedadEntidad = Nothing
        Me.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmisor.Enabled = False
        Me.cmbEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmisor.FormattingEnabled = True
        Me.cmbEmisor.IsPK = False
        Me.cmbEmisor.IsRequired = False
        Me.cmbEmisor.Key = Nothing
        Me.cmbEmisor.LabelAsoc = Nothing
        Me.cmbEmisor.Location = New System.Drawing.Point(696, 44)
        Me.cmbEmisor.Name = "cmbEmisor"
        Me.cmbEmisor.Size = New System.Drawing.Size(40, 21)
        Me.cmbEmisor.TabIndex = 10
        '
        'cboLetra
        '
        Me.cboLetra.BindearPropiedadControl = Nothing
        Me.cboLetra.BindearPropiedadEntidad = Nothing
        Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLetra.Enabled = False
        Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboLetra.FormattingEnabled = True
        Me.cboLetra.IsPK = False
        Me.cboLetra.IsRequired = False
        Me.cboLetra.Key = Nothing
        Me.cboLetra.LabelAsoc = Nothing
        Me.cboLetra.Location = New System.Drawing.Point(592, 44)
        Me.cboLetra.Name = "cboLetra"
        Me.cboLetra.Size = New System.Drawing.Size(38, 21)
        Me.cboLetra.TabIndex = 8
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
        Me.chbNumero.Location = New System.Drawing.Point(745, 46)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 11
        Me.chbNumero.Text = "Numero"
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
        Me.txtNumero.Location = New System.Drawing.Point(810, 44)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(59, 20)
        Me.txtNumero.TabIndex = 12
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTipoOperacion
        '
        Me.cmbTipoOperacion.BindearPropiedadControl = Nothing
        Me.cmbTipoOperacion.BindearPropiedadEntidad = Nothing
        Me.cmbTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoOperacion.Enabled = False
        Me.cmbTipoOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoOperacion.FormattingEnabled = True
        Me.cmbTipoOperacion.IsPK = False
        Me.cmbTipoOperacion.IsRequired = False
        Me.cmbTipoOperacion.Key = Nothing
        Me.cmbTipoOperacion.LabelAsoc = Nothing
        Me.cmbTipoOperacion.Location = New System.Drawing.Point(89, 331)
        Me.cmbTipoOperacion.Name = "cmbTipoOperacion"
        Me.cmbTipoOperacion.Size = New System.Drawing.Size(150, 21)
        Me.cmbTipoOperacion.TabIndex = 63
        '
        'chbTipoOperacion
        '
        Me.chbTipoOperacion.AutoSize = True
        Me.chbTipoOperacion.BindearPropiedadControl = Nothing
        Me.chbTipoOperacion.BindearPropiedadEntidad = Nothing
        Me.chbTipoOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoOperacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoOperacion.IsPK = False
        Me.chbTipoOperacion.IsRequired = False
        Me.chbTipoOperacion.Key = Nothing
        Me.chbTipoOperacion.LabelAsoc = Nothing
        Me.chbTipoOperacion.Location = New System.Drawing.Point(10, 333)
        Me.chbTipoOperacion.Name = "chbTipoOperacion"
        Me.chbTipoOperacion.Size = New System.Drawing.Size(75, 17)
        Me.chbTipoOperacion.TabIndex = 62
        Me.chbTipoOperacion.Text = "Operación"
        Me.chbTipoOperacion.UseVisualStyleBackColor = True
        '
        'cmbNota
        '
        Me.cmbNota.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbNota.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNota.BindearPropiedadControl = Nothing
        Me.cmbNota.BindearPropiedadEntidad = Nothing
        Me.cmbNota.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbNota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbNota.IsPK = False
        Me.cmbNota.IsRequired = False
        Me.cmbNota.Key = ""
        Me.cmbNota.LabelAsoc = Nothing
        Me.cmbNota.Location = New System.Drawing.Point(287, 331)
        Me.cmbNota.MaxLength = 20
        Me.cmbNota.Name = "cmbNota"
        Me.cmbNota.Size = New System.Drawing.Size(149, 21)
        Me.cmbNota.TabIndex = 67
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.BindearPropiedadControl = Nothing
        Me.cmbListaPrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.Enabled = False
        Me.cmbListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.IsPK = False
        Me.cmbListaPrecios.IsRequired = False
        Me.cmbListaPrecios.Key = Nothing
        Me.cmbListaPrecios.LabelAsoc = Nothing
        Me.cmbListaPrecios.Location = New System.Drawing.Point(687, 221)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(140, 21)
        Me.cmbListaPrecios.TabIndex = 48
        '
        'chbListaPrecios
        '
        Me.chbListaPrecios.AutoSize = True
        Me.chbListaPrecios.BindearPropiedadControl = Nothing
        Me.chbListaPrecios.BindearPropiedadEntidad = Nothing
        Me.chbListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaPrecios.IsPK = False
        Me.chbListaPrecios.IsRequired = False
        Me.chbListaPrecios.Key = Nothing
        Me.chbListaPrecios.LabelAsoc = Nothing
        Me.chbListaPrecios.Location = New System.Drawing.Point(586, 223)
        Me.chbListaPrecios.Name = "chbListaPrecios"
        Me.chbListaPrecios.Size = New System.Drawing.Size(101, 17)
        Me.chbListaPrecios.TabIndex = 47
        Me.chbListaPrecios.Text = "Lista de Precios"
        Me.chbListaPrecios.UseVisualStyleBackColor = True
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
        Me.chbCategoria.Location = New System.Drawing.Point(586, 198)
        Me.chbCategoria.Name = "chbCategoria"
        Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoria.TabIndex = 41
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
        Me.cmbCategoria.Location = New System.Drawing.Point(687, 196)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(140, 21)
        Me.cmbCategoria.TabIndex = 42
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
        Me.chbProvincia.Location = New System.Drawing.Point(586, 250)
        Me.chbProvincia.Name = "chbProvincia"
        Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
        Me.chbProvincia.TabIndex = 52
        Me.chbProvincia.Text = "Provincia"
        Me.chbProvincia.UseVisualStyleBackColor = True
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
        Me.chbLocalidad.Location = New System.Drawing.Point(10, 252)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 49
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
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
        Me.cmbProvincia.Location = New System.Drawing.Point(687, 248)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(140, 21)
        Me.cmbProvincia.TabIndex = 53
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
        Me.bscCodigoLocalidad.Enabled = False
        Me.bscCodigoLocalidad.FilaDevuelta = Nothing
        Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoLocalidad.IsDecimal = False
        Me.bscCodigoLocalidad.IsNumber = False
        Me.bscCodigoLocalidad.IsPK = False
        Me.bscCodigoLocalidad.IsRequired = False
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Nothing
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(89, 250)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = True
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoLocalidad.TabIndex = 50
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
        Me.bscNombreLocalidad.Enabled = False
        Me.bscNombreLocalidad.FilaDevuelta = Nothing
        Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreLocalidad.IsDecimal = False
        Me.bscNombreLocalidad.IsNumber = False
        Me.bscNombreLocalidad.IsPK = False
        Me.bscNombreLocalidad.IsRequired = False
        Me.bscNombreLocalidad.Key = ""
        Me.bscNombreLocalidad.LabelAsoc = Nothing
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(186, 249)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = True
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(270, 22)
        Me.bscNombreLocalidad.TabIndex = 51
        Me.bscNombreLocalidad.Titulo = Nothing
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
        Me.chbZonaGeografica.Location = New System.Drawing.Point(586, 335)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(83, 17)
        Me.chbZonaGeografica.TabIndex = 64
        Me.chbZonaGeografica.Text = "Zona Geog."
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
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
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(687, 333)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(140, 21)
        Me.cmbZonaGeografica.TabIndex = 65
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
        Me.bscProducto2.Location = New System.Drawing.Point(219, 102)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(247, 20)
        Me.bscProducto2.TabIndex = 21
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
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(90, 101)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(123, 20)
        Me.bscCodigoProducto2.TabIndex = 20
        '
        'bscProveedor
        '
        Me.bscProveedor.AutoSize = True
        Me.bscProveedor.AyudaAncho = 608
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ColumnasAlineacion = Nothing
        Me.bscProveedor.ColumnasAncho = Nothing
        Me.bscProveedor.ColumnasFormato = Nothing
        Me.bscProveedor.ColumnasOcultas = Nothing
        Me.bscProveedor.ColumnasTitulos = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.Enabled = False
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Nothing
        Me.bscProveedor.Location = New System.Drawing.Point(186, 223)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(270, 23)
        Me.bscProveedor.TabIndex = 46
        Me.bscProveedor.Titulo = Nothing
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.AyudaAncho = 608
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
        Me.bscCodigoProveedor.ColumnasAncho = Nothing
        Me.bscCodigoProveedor.ColumnasFormato = Nothing
        Me.bscCodigoProveedor.ColumnasOcultas = Nothing
        Me.bscCodigoProveedor.ColumnasTitulos = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.Enabled = False
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(89, 223)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 45
        Me.bscCodigoProveedor.Titulo = Nothing
        '
        'chbProveedor
        '
        Me.chbProveedor.AutoSize = True
        Me.chbProveedor.BindearPropiedadControl = Nothing
        Me.chbProveedor.BindearPropiedadEntidad = Nothing
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Location = New System.Drawing.Point(10, 226)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 44
        Me.chbProveedor.Text = "Pro&veedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'lblProdDescRec
        '
        Me.lblProdDescRec.AutoSize = True
        Me.lblProdDescRec.LabelAsoc = Nothing
        Me.lblProdDescRec.Location = New System.Drawing.Point(731, 134)
        Me.lblProdDescRec.Name = "lblProdDescRec"
        Me.lblProdDescRec.Size = New System.Drawing.Size(97, 13)
        Me.lblProdDescRec.TabIndex = 28
        Me.lblProdDescRec.Text = "Con Desc/Recarg."
        '
        'cmbProdDescRec
        '
        Me.cmbProdDescRec.BindearPropiedadControl = Nothing
        Me.cmbProdDescRec.BindearPropiedadEntidad = Nothing
        Me.cmbProdDescRec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProdDescRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProdDescRec.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProdDescRec.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProdDescRec.FormattingEnabled = True
        Me.cmbProdDescRec.IsPK = False
        Me.cmbProdDescRec.IsRequired = False
        Me.cmbProdDescRec.Key = Nothing
        Me.cmbProdDescRec.LabelAsoc = Me.lblProdDescRec
        Me.cmbProdDescRec.Location = New System.Drawing.Point(832, 130)
        Me.cmbProdDescRec.Name = "cmbProdDescRec"
        Me.cmbProdDescRec.Size = New System.Drawing.Size(80, 21)
        Me.cmbProdDescRec.TabIndex = 29
        '
        'lblIngresosBrutos
        '
        Me.lblIngresosBrutos.AutoSize = True
        Me.lblIngresosBrutos.LabelAsoc = Nothing
        Me.lblIngresosBrutos.Location = New System.Drawing.Point(738, 75)
        Me.lblIngresosBrutos.Name = "lblIngresosBrutos"
        Me.lblIngresosBrutos.Size = New System.Drawing.Size(58, 13)
        Me.lblIngresosBrutos.TabIndex = 17
        Me.lblIngresosBrutos.Text = "Ing. Brutos"
        '
        'cmbIngresosBrutos
        '
        Me.cmbIngresosBrutos.BindearPropiedadControl = Nothing
        Me.cmbIngresosBrutos.BindearPropiedadEntidad = Nothing
        Me.cmbIngresosBrutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIngresosBrutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIngresosBrutos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIngresosBrutos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIngresosBrutos.FormattingEnabled = True
        Me.cmbIngresosBrutos.IsPK = False
        Me.cmbIngresosBrutos.IsRequired = False
        Me.cmbIngresosBrutos.Key = Nothing
        Me.cmbIngresosBrutos.LabelAsoc = Me.lblIngresosBrutos
        Me.cmbIngresosBrutos.Location = New System.Drawing.Point(799, 71)
        Me.cmbIngresosBrutos.Name = "cmbIngresosBrutos"
        Me.cmbIngresosBrutos.Size = New System.Drawing.Size(70, 21)
        Me.cmbIngresosBrutos.TabIndex = 18
        '
        'chbCantidad
        '
        Me.chbCantidad.AutoSize = True
        Me.chbCantidad.BindearPropiedadControl = Nothing
        Me.chbCantidad.BindearPropiedadEntidad = Nothing
        Me.chbCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCantidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCantidad.IsPK = False
        Me.chbCantidad.IsRequired = False
        Me.chbCantidad.Key = Nothing
        Me.chbCantidad.LabelAsoc = Nothing
        Me.chbCantidad.Location = New System.Drawing.Point(478, 132)
        Me.chbCantidad.Name = "chbCantidad"
        Me.chbCantidad.Size = New System.Drawing.Size(68, 17)
        Me.chbCantidad.TabIndex = 26
        Me.chbCantidad.Text = "Cantidad"
        Me.chbCantidad.UseVisualStyleBackColor = True
        '
        'cmbCantidad
        '
        Me.cmbCantidad.BindearPropiedadControl = Nothing
        Me.cmbCantidad.BindearPropiedadEntidad = Nothing
        Me.cmbCantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCantidad.Enabled = False
        Me.cmbCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCantidad.FormattingEnabled = True
        Me.cmbCantidad.IsPK = False
        Me.cmbCantidad.IsRequired = False
        Me.cmbCantidad.Key = Nothing
        Me.cmbCantidad.LabelAsoc = Nothing
        Me.cmbCantidad.Location = New System.Drawing.Point(579, 130)
        Me.cmbCantidad.Name = "cmbCantidad"
        Me.cmbCantidad.Size = New System.Drawing.Size(140, 21)
        Me.cmbCantidad.TabIndex = 27
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
        Me.chbProducto.Location = New System.Drawing.Point(11, 103)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 19
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
        '
        'bscLote
        '
        Me.bscLote.AutoSize = True
        Me.bscLote.AyudaAncho = 608
        Me.bscLote.BindearPropiedadControl = Nothing
        Me.bscLote.BindearPropiedadEntidad = Nothing
        Me.bscLote.ColumnasAlineacion = Nothing
        Me.bscLote.ColumnasAncho = Nothing
        Me.bscLote.ColumnasFormato = Nothing
        Me.bscLote.ColumnasOcultas = Nothing
        Me.bscLote.ColumnasTitulos = Nothing
        Me.bscLote.Datos = Nothing
        Me.bscLote.Enabled = False
        Me.bscLote.FilaDevuelta = Nothing
        Me.bscLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscLote.ForeColorFocus = System.Drawing.Color.Red
        Me.bscLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscLote.IsDecimal = False
        Me.bscLote.IsNumber = False
        Me.bscLote.IsPK = False
        Me.bscLote.IsRequired = False
        Me.bscLote.Key = ""
        Me.bscLote.LabelAsoc = Nothing
        Me.bscLote.Location = New System.Drawing.Point(579, 100)
        Me.bscLote.Margin = New System.Windows.Forms.Padding(4)
        Me.bscLote.MaxLengh = "32767"
        Me.bscLote.Name = "bscLote"
        Me.bscLote.Permitido = True
        Me.bscLote.Selecciono = False
        Me.bscLote.Size = New System.Drawing.Size(212, 23)
        Me.bscLote.TabIndex = 23
        Me.bscLote.Titulo = Nothing
        '
        'chbLote
        '
        Me.chbLote.AutoSize = True
        Me.chbLote.BindearPropiedadControl = Nothing
        Me.chbLote.BindearPropiedadEntidad = Nothing
        Me.chbLote.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLote.IsPK = False
        Me.chbLote.IsRequired = False
        Me.chbLote.Key = Nothing
        Me.chbLote.LabelAsoc = Nothing
        Me.chbLote.Location = New System.Drawing.Point(478, 105)
        Me.chbLote.Name = "chbLote"
        Me.chbLote.Size = New System.Drawing.Size(47, 17)
        Me.chbLote.TabIndex = 22
        Me.chbLote.Text = "Lote"
        Me.chbLote.UseVisualStyleBackColor = True
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
        Me.cmbMarca.Location = New System.Drawing.Point(90, 130)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(183, 21)
        Me.cmbMarca.TabIndex = 25
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
        Me.chbMarca.Location = New System.Drawing.Point(11, 132)
        Me.chbMarca.Name = "chbMarca"
        Me.chbMarca.Size = New System.Drawing.Size(56, 17)
        Me.chbMarca.TabIndex = 24
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
        Me.cmbRubro.Location = New System.Drawing.Point(90, 158)
        Me.cmbRubro.Name = "cmbRubro"
        Me.cmbRubro.Size = New System.Drawing.Size(183, 21)
        Me.cmbRubro.TabIndex = 31
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
        Me.chbRubro.Location = New System.Drawing.Point(11, 160)
        Me.chbRubro.Name = "chbRubro"
        Me.chbRubro.Size = New System.Drawing.Size(55, 17)
        Me.chbRubro.TabIndex = 30
        Me.chbRubro.Text = "Rubro"
        Me.chbRubro.UseVisualStyleBackColor = True
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
        Me.chbUsuario.Location = New System.Drawing.Point(10, 306)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 58
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
        Me.cmbUsuario.Location = New System.Drawing.Point(89, 304)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(150, 21)
        Me.cmbUsuario.TabIndex = 59
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
        Me.chbFormaPago.Location = New System.Drawing.Point(586, 306)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(78, 17)
        Me.chbFormaPago.TabIndex = 60
        Me.chbFormaPago.Text = "F. de Pago"
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
        Me.cmbFormaPago.Location = New System.Drawing.Point(687, 304)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(140, 21)
        Me.cmbFormaPago.TabIndex = 61
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
        Me.chbTransportista.Location = New System.Drawing.Point(586, 279)
        Me.chbTransportista.Name = "chbTransportista"
        Me.chbTransportista.Size = New System.Drawing.Size(87, 17)
        Me.chbTransportista.TabIndex = 56
        Me.chbTransportista.Text = "Transportista"
        Me.chbTransportista.UseVisualStyleBackColor = True
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
        Me.chbVendedor.Location = New System.Drawing.Point(10, 279)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 54
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbTransportista
        '
        Me.cmbTransportista.BindearPropiedadControl = Nothing
        Me.cmbTransportista.BindearPropiedadEntidad = Nothing
        Me.cmbTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransportista.Enabled = False
        Me.cmbTransportista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTransportista.FormattingEnabled = True
        Me.cmbTransportista.IsPK = False
        Me.cmbTransportista.IsRequired = False
        Me.cmbTransportista.Key = Nothing
        Me.cmbTransportista.LabelAsoc = Nothing
        Me.cmbTransportista.Location = New System.Drawing.Point(687, 277)
        Me.cmbTransportista.Name = "cmbTransportista"
        Me.cmbTransportista.Size = New System.Drawing.Size(140, 21)
        Me.cmbTransportista.TabIndex = 57
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
        Me.cmbVendedor.Location = New System.Drawing.Point(89, 277)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(150, 21)
        Me.cmbVendedor.TabIndex = 55
        '
        'cmbAfectaCaja
        '
        Me.cmbAfectaCaja.BindearPropiedadControl = Nothing
        Me.cmbAfectaCaja.BindearPropiedadEntidad = Nothing
        Me.cmbAfectaCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAfectaCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAfectaCaja.FormattingEnabled = True
        Me.cmbAfectaCaja.IsPK = False
        Me.cmbAfectaCaja.IsRequired = False
        Me.cmbAfectaCaja.Key = Nothing
        Me.cmbAfectaCaja.LabelAsoc = Me.lblAfectaCaja
        Me.cmbAfectaCaja.Location = New System.Drawing.Point(340, 71)
        Me.cmbAfectaCaja.Name = "cmbAfectaCaja"
        Me.cmbAfectaCaja.Size = New System.Drawing.Size(70, 21)
        Me.cmbAfectaCaja.TabIndex = 14
        '
        'lblAfectaCaja
        '
        Me.lblAfectaCaja.AutoSize = True
        Me.lblAfectaCaja.LabelAsoc = Nothing
        Me.lblAfectaCaja.Location = New System.Drawing.Point(272, 75)
        Me.lblAfectaCaja.Name = "lblAfectaCaja"
        Me.lblAfectaCaja.Size = New System.Drawing.Size(62, 13)
        Me.lblAfectaCaja.TabIndex = 13
        Me.lblAfectaCaja.Text = "Afecta Caja"
        '
        'lblNota
        '
        Me.lblNota.AutoSize = True
        Me.lblNota.LabelAsoc = Nothing
        Me.lblNota.Location = New System.Drawing.Point(251, 334)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(30, 13)
        Me.lblNota.TabIndex = 66
        Me.lblNota.Text = "Nota"
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
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(659, 71)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(70, 21)
        Me.cmbGrabanLibro.TabIndex = 16
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(586, 75)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 15
        Me.lblGrabanLibro.Text = "Graban Libro"
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
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(386, 44)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(140, 21)
        Me.cmbTiposComprobantes.TabIndex = 6
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
        Me.chbTipoComprobante.Location = New System.Drawing.Point(275, 46)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 5
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(842, 264)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(99, 45)
        Me.btnConsultar.TabIndex = 69
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.bscCodigoCliente.Location = New System.Drawing.Point(89, 196)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 38
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(87, 182)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 37
        Me.lblCodigoCliente.Text = "Código"
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
        Me.bscCliente.Location = New System.Drawing.Point(186, 196)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(270, 23)
        Me.bscCliente.TabIndex = 40
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(184, 182)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 39
        Me.lblNombre.Text = "Nombre"
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
        Me.chbCliente.Location = New System.Drawing.Point(10, 198)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 36
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(11, 48)
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
        Me.dtpHasta.Location = New System.Drawing.Point(124, 72)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(106, 75)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(15, 13)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "H"
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
        Me.dtpDesde.Location = New System.Drawing.Point(124, 46)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(106, 49)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(15, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "D"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tbpFiltros)
        Me.TabControl1.Controls.Add(Me.tbpDatos)
        Me.TabControl1.Location = New System.Drawing.Point(0, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(962, 511)
        Me.TabControl1.TabIndex = 0
        '
        'tbpFiltros
        '
        Me.tbpFiltros.BackColor = System.Drawing.SystemColors.Control
        Me.tbpFiltros.Controls.Add(Me.grbConsultar)
        Me.tbpFiltros.Location = New System.Drawing.Point(4, 22)
        Me.tbpFiltros.Name = "tbpFiltros"
        Me.tbpFiltros.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpFiltros.Size = New System.Drawing.Size(954, 485)
        Me.tbpFiltros.TabIndex = 0
        Me.tbpFiltros.Text = "Filtros"
        '
        'tbpDatos
        '
        Me.tbpDatos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDatos.Controls.Add(Me.TableLayoutPanel1)
        Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatos.Name = "tbpDatos"
        Me.tbpDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDatos.Size = New System.Drawing.Size(954, 485)
        Me.tbpDatos.TabIndex = 1
        Me.tbpDatos.Text = "Datos"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.ugDetalle, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chkExpandAll, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtFiltros, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.chbConIVA, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(948, 479)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(841, 3)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 21)
        Me.chkExpandAll.TabIndex = 2
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'txtFiltros
        '
        Me.txtFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFiltros.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFiltros.Location = New System.Drawing.Point(3, 3)
        Me.txtFiltros.Multiline = True
        Me.txtFiltros.Name = "txtFiltros"
        Me.txtFiltros.ReadOnly = True
        Me.txtFiltros.Size = New System.Drawing.Size(723, 0)
        Me.txtFiltros.TabIndex = 0
        '
        'chbConIVA
        '
        Me.chbConIVA.AutoSize = True
        Me.chbConIVA.BindearPropiedadControl = Nothing
        Me.chbConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConIVA.Dock = System.Windows.Forms.DockStyle.Right
        Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConIVA.IsPK = False
        Me.chbConIVA.IsRequired = False
        Me.chbConIVA.Key = Nothing
        Me.chbConIVA.LabelAsoc = Nothing
        Me.chbConIVA.Location = New System.Drawing.Point(732, 3)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(103, 21)
        Me.chbConIVA.TabIndex = 1
        Me.chbConIVA.Text = "Precios Con IVA"
        Me.chbConIVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chbConIVA.UseVisualStyleBackColor = True
        '
        'InfVentasDetallePorProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 562)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "InfVentasDetallePorProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Venta Detallado por Productos"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.gbHistoriaClinica.ResumeLayout(False)
        Me.gbHistoriaClinica.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpFiltros.ResumeLayout(False)
        Me.tbpDatos.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
   Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents cmbAfectaCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblAfectaCaja As Eniac.Controles.Label
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents lblProdDescRec As Eniac.Controles.Label
   Friend WithEvents cmbProdDescRec As Eniac.Controles.ComboBox
   Friend WithEvents lblIngresosBrutos As Eniac.Controles.Label
   Friend WithEvents cmbIngresosBrutos As Eniac.Controles.ComboBox
   Friend WithEvents chbCantidad As Eniac.Controles.CheckBox
   Friend WithEvents cmbCantidad As Eniac.Controles.ComboBox
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents bscLote As Eniac.Controles.Buscador
   Friend WithEvents chbLote As Eniac.Controles.CheckBox
   Friend WithEvents cmbMarca As Eniac.Controles.ComboBox
   Friend WithEvents chbMarca As Eniac.Controles.CheckBox
   Friend WithEvents cmbRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbRubro As Eniac.Controles.CheckBox
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Public WithEvents cmbProvincia As Eniac.Controles.ComboBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Friend WithEvents chbProvincia As Eniac.Controles.CheckBox
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents cmbListaPrecios As Eniac.Controles.ComboBox
   Friend WithEvents chbListaPrecios As Eniac.Controles.CheckBox
   Friend WithEvents UltraDataSource2 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents tbpFiltros As System.Windows.Forms.TabPage
   Friend WithEvents chbTransportista As Eniac.Controles.CheckBox
   Friend WithEvents cmbTransportista As Eniac.Controles.ComboBox
   Friend WithEvents cmbTipoOperacion As Eniac.Controles.ComboBox
   Friend WithEvents chbTipoOperacion As Eniac.Controles.CheckBox
   Friend WithEvents cmbNota As Eniac.Controles.ComboBox
   Friend WithEvents lblNota As Eniac.Controles.Label
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents chbEmisor As Eniac.Controles.CheckBox
   Friend WithEvents cmbEmisor As Eniac.Controles.ComboBox
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents cmbSubSubRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbSubSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents cmbCajas As Eniac.Win.ComboBoxCajas
   Friend WithEvents lblCajas As Eniac.Controles.Label
   Protected WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents txtFiltros As Eniac.Win.TextBoxParaMostrarFiltros
   Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents cmbOrigenVendedor As Controles.ComboBox
   Friend WithEvents cmbOrigenCategoria As Controles.ComboBox
   Friend WithEvents gbHistoriaClinica As System.Windows.Forms.GroupBox
   Friend WithEvents bscCodigoDoctor As Eniac.Controles.Buscador2
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents bscDoctor As Eniac.Controles.Buscador2
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents chbDoctor As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoPaciente As Eniac.Controles.Buscador2
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents bscPaciente As Eniac.Controles.Buscador2
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents chbPaciente As Eniac.Controles.CheckBox
   Friend WithEvents chbFechaCirugia As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaCirugia As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaCirugia As Eniac.Controles.Label
    Friend WithEvents cmbTipoCliente As Controles.ComboBox
    Friend WithEvents lblCliente As Controles.Label
End Class
