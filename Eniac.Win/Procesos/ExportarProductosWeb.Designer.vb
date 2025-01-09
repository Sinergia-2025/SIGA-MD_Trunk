<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportarProductosWeb
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Productos", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Stock")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MesesGarantia")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsNoGravado")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AfectaStock")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Lote")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroSerie")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoImpuesto")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alicuota")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Activo")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubRubro")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Embalaje")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Kilos")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsServicio")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsDeCompras")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsDeVentas")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PagaIngresosBrutos")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PermiteModificarDescripcion")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PublicarListaDePreciosClientes")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCosto")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMoneda")
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeBarras")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMonedaCorto")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PORCENTAJE")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoLargoProducto")
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PublicarEnWeb")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubSubRubro")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreSubSubRubro")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Caracteristica1")
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Caracteristica2")
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Caracteristica3")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorCaracteristica1")
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorCaracteristica2")
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorCaracteristica3")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alto")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ancho")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Largo")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsParaConstructora")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsParaIndustria")
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsParaCooperativaElectrica")
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsParaMayorista")
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsParaMinorista")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoMercosur")
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProductoProveedor")
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProductoWeb")
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Check", 0)
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoNumerico", 1)
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
      Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraDataColumn105 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
        Dim UltraDataColumn106 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
        Dim UltraDataColumn107 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Tamano")
        Dim UltraDataColumn108 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUnidadDeMedida")
        Dim UltraDataColumn109 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Stock")
        Dim UltraDataColumn110 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdMarca")
        Dim UltraDataColumn111 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
        Dim UltraDataColumn112 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdRubro")
        Dim UltraDataColumn113 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
        Dim UltraDataColumn114 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("MesesGarantia")
        Dim UltraDataColumn115 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsNoGravado")
        Dim UltraDataColumn116 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AfectaStock")
        Dim UltraDataColumn117 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Lote")
        Dim UltraDataColumn118 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroSerie")
        Dim UltraDataColumn119 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoImpuesto")
        Dim UltraDataColumn120 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Alicuota")
        Dim UltraDataColumn121 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Activo")
        Dim UltraDataColumn122 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSubRubro")
        Dim UltraDataColumn123 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
        Dim UltraDataColumn124 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Embalaje")
        Dim UltraDataColumn125 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Kilos")
        Dim UltraDataColumn126 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsServicio")
        Dim UltraDataColumn127 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsDeCompras")
        Dim UltraDataColumn128 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsDeVentas")
        Dim UltraDataColumn129 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PagaIngresosBrutos")
        Dim UltraDataColumn130 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PermiteModificarDescripcion")
        Dim UltraDataColumn131 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PublicarListaDePreciosClientes")
        Dim UltraDataColumn132 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioCosto")
        Dim UltraDataColumn133 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioVenta")
        Dim UltraDataColumn134 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMoneda")
        Dim UltraDataColumn135 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoDeBarras")
        Dim UltraDataColumn136 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMonedaCorto")
        Dim UltraDataColumn137 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PORCENTAJE")
        Dim UltraDataColumn138 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CodigoLargoProducto")
        Dim UltraDataColumn139 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaActualizacion")
        Dim UltraDataColumn140 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PublicarEnWeb")
        Dim UltraDataColumn141 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSubSubRubro")
        Dim UltraDataColumn142 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubSubRubro")
        Dim UltraDataColumn143 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Caracteristica1")
        Dim UltraDataColumn144 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Caracteristica2")
        Dim UltraDataColumn145 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Caracteristica3")
        Dim UltraDataColumn146 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ValorCaracteristica1")
        Dim UltraDataColumn147 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ValorCaracteristica2")
        Dim UltraDataColumn148 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ValorCaracteristica3")
        Dim UltraDataColumn149 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Alto")
        Dim UltraDataColumn150 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Ancho")
        Dim UltraDataColumn151 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Largo")
        Dim UltraDataColumn152 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsParaConstructora")
        Dim UltraDataColumn153 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsParaIndustria")
        Dim UltraDataColumn154 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsParaCooperativaElectrica")
        Dim UltraDataColumn155 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsParaMayorista")
        Dim UltraDataColumn156 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("EsParaMinorista")
        Me.lblEmbalaje = New Eniac.Controles.Label()
        Me.txtEmbalaje = New Eniac.Controles.TextBox()
        Me.cmbActivo = New Eniac.Controles.ComboBox()
        Me.lblActivo = New Eniac.Controles.Label()
        Me.cmbAfectaStock = New Eniac.Controles.ComboBox()
        Me.lblAfectaStock = New Eniac.Controles.Label()
        Me.bscCodigoMarca = New Eniac.Controles.Buscador()
        Me.bscCodigoRubro = New Eniac.Controles.Buscador()
        Me.lnkFiltroMultiplesRubros = New System.Windows.Forms.LinkLabel()
        Me.lnkFiltroMultiplesMarcas = New System.Windows.Forms.LinkLabel()
        Me.lblCodigo = New Eniac.Controles.Label()
        Me.txtCodigo = New Eniac.Controles.TextBox()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.txtProducto = New Eniac.Controles.TextBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
        Me.tsbSubirArchivosALaWeb = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbFiltros = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.chbTodos = New Eniac.Controles.CheckBox()
        Me.cmbSubRubro = New Eniac.Controles.ComboBox()
        Me.chbSubRubro = New Eniac.Controles.CheckBox()
        Me.lblPublicarEnListaDePreciosParaClientes = New Eniac.Controles.Label()
        Me.cmbPublicarEnListaDePreciosParaClientes = New Eniac.Controles.ComboBox()
        Me.lblEsServicio = New Eniac.Controles.Label()
        Me.lblPagaIngBrutos = New Eniac.Controles.Label()
        Me.lblEsDeCompras = New Eniac.Controles.Label()
        Me.lblEsDeVentas = New Eniac.Controles.Label()
        Me.lblPermiteModDesc = New Eniac.Controles.Label()
        Me.cmbPermiteModDesc = New Eniac.Controles.ComboBox()
        Me.cmbPagaIngBrutos = New Eniac.Controles.ComboBox()
        Me.cmbEsDeVentas = New Eniac.Controles.ComboBox()
        Me.cmbEsDeCompras = New Eniac.Controles.ComboBox()
        Me.cmbEsServicio = New Eniac.Controles.ComboBox()
        Me.gbFiltros = New Eniac.Controles.GroupBox()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Controles.ComboBox()
        Me.lblListaPreciosMayorista = New Eniac.Controles.Label()
        Me.cmbListaPreciosMayorista = New Eniac.Controles.ComboBox()
        Me.grpPublicarEn = New Eniac.Controles.GroupBox()
        Me.cmbPublicarEnEmpresarial = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnEmpresarial = New Eniac.Controles.Label()
        Me.cmbPublicarEnGestion = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnGestion = New Eniac.Controles.Label()
        Me.cmbPublicarEnWeb = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnWeb = New Eniac.Controles.Label()
        Me.cmbPublicarEnMercadoLibre = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnMercadoLibre = New Eniac.Controles.Label()
        Me.cmbPublicarEnSincronizarSucursal = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnSincronizacionSucursal = New Eniac.Controles.Label()
        Me.cmbPublicarEnTiendaNube = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnTiendaNube = New Eniac.Controles.Label()
        Me.cmbPublicarEnBalanza = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnBalanza = New Eniac.Controles.Label()
        Me.cmbPublicarEnArborea = New Eniac.Controles.ComboBox()
        Me.lblPublicarEnArborea = New Eniac.Controles.Label()
        Me.dtpEnviando = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.lblEnviando = New Eniac.Controles.Label()
        Me.cmbEnviando = New Eniac.Controles.ComboBox()
        Me.lblSubirImagenes = New Eniac.Controles.Label()
        Me.cmbSubirImagenes = New Eniac.Controles.ComboBox()
        Me.lblRedondeoDecimales2 = New Eniac.Controles.Label()
        Me.lblRedondeoDecimales = New Eniac.Controles.Label()
        Me.txtRedondeoDecimales = New Eniac.Controles.TextBox()
        Me.chbConIVA = New Eniac.Controles.CheckBox()
        Me.lnkFiltroMultiplesSubRubros = New System.Windows.Forms.LinkLabel()
        Me.lnkFiltroMultiplesSubSubRubros = New System.Windows.Forms.LinkLabel()
        Me.chbFechaActualizado = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.cmbListaPrecios = New Eniac.Controles.ComboBox()
        Me.lblListaPrecios = New Eniac.Controles.Label()
        Me.cmbFormato = New Eniac.Controles.ComboBox()
        Me.lblFormato = New Eniac.Controles.Label()
        Me.lblMoneda = New Eniac.Controles.Label()
        Me.lblTipoCambio = New Eniac.Controles.Label()
        Me.txtTipoCambio = New Eniac.Controles.TextBox()
        Me.cmbMoneda = New Eniac.Controles.ComboBox()
        Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.ProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SistemaDataSet = New Eniac.Win.SistemaDataSet()
        Me.txtArchivoDestino = New Eniac.Controles.TextBox()
        Me.lblArchivoDestino = New Eniac.Controles.Label()
        Me.btnExaminar = New Eniac.Controles.Button()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.FiltersManager1 = New Eniac.Win.FilterManager.FilterManager(Me.components)
        Me.pnlDestino = New System.Windows.Forms.Panel()
        Me.cmbTipoInforme = New Eniac.Controles.ComboBox()
        Me.lblTipoInforme = New Eniac.Controles.Label()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.gbFiltros.SuspendLayout()
        Me.grpPublicarEn.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SistemaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDestino.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblEmbalaje
        '
        Me.lblEmbalaje.AutoSize = True
        Me.lblEmbalaje.LabelAsoc = Nothing
        Me.lblEmbalaje.Location = New System.Drawing.Point(260, 106)
        Me.lblEmbalaje.Name = "lblEmbalaje"
        Me.lblEmbalaje.Size = New System.Drawing.Size(50, 13)
        Me.lblEmbalaje.TabIndex = 27
        Me.lblEmbalaje.Text = "Embalaje"
        '
        'txtEmbalaje
        '
        Me.txtEmbalaje.BindearPropiedadControl = ""
        Me.txtEmbalaje.BindearPropiedadEntidad = ""
        Me.txtEmbalaje.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEmbalaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEmbalaje.Formato = ""
        Me.txtEmbalaje.IsDecimal = False
        Me.txtEmbalaje.IsNumber = True
        Me.txtEmbalaje.IsPK = False
        Me.txtEmbalaje.IsRequired = False
        Me.txtEmbalaje.Key = ""
        Me.txtEmbalaje.LabelAsoc = Me.lblEmbalaje
        Me.txtEmbalaje.Location = New System.Drawing.Point(349, 102)
        Me.txtEmbalaje.MaxLength = 4
        Me.txtEmbalaje.Name = "txtEmbalaje"
        Me.txtEmbalaje.Size = New System.Drawing.Size(42, 20)
        Me.txtEmbalaje.TabIndex = 28
        Me.txtEmbalaje.Text = "0"
        Me.txtEmbalaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbActivo
        '
        Me.cmbActivo.BindearPropiedadControl = Nothing
        Me.cmbActivo.BindearPropiedadEntidad = Nothing
        Me.cmbActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActivo.FormattingEnabled = True
        Me.cmbActivo.IsPK = False
        Me.cmbActivo.IsRequired = False
        Me.cmbActivo.Key = Nothing
        Me.cmbActivo.LabelAsoc = Me.lblActivo
        Me.cmbActivo.Location = New System.Drawing.Point(889, 29)
        Me.cmbActivo.Name = "cmbActivo"
        Me.cmbActivo.Size = New System.Drawing.Size(83, 21)
        Me.cmbActivo.TabIndex = 10
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.LabelAsoc = Nothing
        Me.lblActivo.Location = New System.Drawing.Point(852, 33)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 9
        Me.lblActivo.Text = "Activo"
        '
        'cmbAfectaStock
        '
        Me.cmbAfectaStock.BindearPropiedadControl = Nothing
        Me.cmbAfectaStock.BindearPropiedadEntidad = Nothing
        Me.cmbAfectaStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaStock.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAfectaStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAfectaStock.FormattingEnabled = True
        Me.cmbAfectaStock.IsPK = False
        Me.cmbAfectaStock.IsRequired = False
        Me.cmbAfectaStock.Key = Nothing
        Me.cmbAfectaStock.LabelAsoc = Me.lblAfectaStock
        Me.cmbAfectaStock.Location = New System.Drawing.Point(889, 54)
        Me.cmbAfectaStock.Name = "cmbAfectaStock"
        Me.cmbAfectaStock.Size = New System.Drawing.Size(83, 21)
        Me.cmbAfectaStock.TabIndex = 18
        '
        'lblAfectaStock
        '
        Me.lblAfectaStock.AutoSize = True
        Me.lblAfectaStock.LabelAsoc = Nothing
        Me.lblAfectaStock.Location = New System.Drawing.Point(820, 58)
        Me.lblAfectaStock.Name = "lblAfectaStock"
        Me.lblAfectaStock.Size = New System.Drawing.Size(69, 13)
        Me.lblAfectaStock.TabIndex = 17
        Me.lblAfectaStock.Text = "Afecta Stock"
        '
        'bscCodigoMarca
        '
        Me.bscCodigoMarca.AyudaAncho = 608
        Me.bscCodigoMarca.BindearPropiedadControl = "Text"
        Me.bscCodigoMarca.BindearPropiedadEntidad = "IdMarca"
        Me.bscCodigoMarca.ColumnasAlineacion = Nothing
        Me.bscCodigoMarca.ColumnasAncho = Nothing
        Me.bscCodigoMarca.ColumnasFormato = Nothing
        Me.bscCodigoMarca.ColumnasOcultas = Nothing
        Me.bscCodigoMarca.ColumnasTitulos = Nothing
        Me.bscCodigoMarca.Datos = Nothing
        Me.bscCodigoMarca.FilaDevuelta = Nothing
        Me.bscCodigoMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoMarca.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoMarca.IsDecimal = False
        Me.bscCodigoMarca.IsNumber = False
        Me.bscCodigoMarca.IsPK = False
        Me.bscCodigoMarca.IsRequired = False
        Me.bscCodigoMarca.Key = ""
        Me.bscCodigoMarca.LabelAsoc = Nothing
        Me.bscCodigoMarca.Location = New System.Drawing.Point(883, 7)
        Me.bscCodigoMarca.MaxLengh = "32767"
        Me.bscCodigoMarca.Name = "bscCodigoMarca"
        Me.bscCodigoMarca.Permitido = True
        Me.bscCodigoMarca.Selecciono = False
        Me.bscCodigoMarca.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoMarca.TabIndex = 4
        Me.bscCodigoMarca.Titulo = Nothing
        Me.bscCodigoMarca.Visible = False
        '
        'bscCodigoRubro
        '
        Me.bscCodigoRubro.AyudaAncho = 608
        Me.bscCodigoRubro.BindearPropiedadControl = "Text"
        Me.bscCodigoRubro.BindearPropiedadEntidad = "IdRubro"
        Me.bscCodigoRubro.ColumnasAlineacion = Nothing
        Me.bscCodigoRubro.ColumnasAncho = Nothing
        Me.bscCodigoRubro.ColumnasFormato = Nothing
        Me.bscCodigoRubro.ColumnasOcultas = Nothing
        Me.bscCodigoRubro.ColumnasTitulos = Nothing
        Me.bscCodigoRubro.Datos = Nothing
        Me.bscCodigoRubro.FilaDevuelta = Nothing
        Me.bscCodigoRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro.IsDecimal = False
        Me.bscCodigoRubro.IsNumber = False
        Me.bscCodigoRubro.IsPK = False
        Me.bscCodigoRubro.IsRequired = False
        Me.bscCodigoRubro.Key = ""
        Me.bscCodigoRubro.LabelAsoc = Nothing
        Me.bscCodigoRubro.Location = New System.Drawing.Point(883, 7)
        Me.bscCodigoRubro.MaxLengh = "32767"
        Me.bscCodigoRubro.Name = "bscCodigoRubro"
        Me.bscCodigoRubro.Permitido = True
        Me.bscCodigoRubro.Selecciono = False
        Me.bscCodigoRubro.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoRubro.TabIndex = 9
        Me.bscCodigoRubro.Titulo = Nothing
        Me.bscCodigoRubro.Visible = False
        '
        'lnkFiltroMultiplesRubros
        '
        Me.lnkFiltroMultiplesRubros.AutoSize = True
        Me.lnkFiltroMultiplesRubros.Location = New System.Drawing.Point(131, 58)
        Me.lnkFiltroMultiplesRubros.Name = "lnkFiltroMultiplesRubros"
        Me.lnkFiltroMultiplesRubros.Size = New System.Drawing.Size(90, 13)
        Me.lnkFiltroMultiplesRubros.TabIndex = 12
        Me.lnkFiltroMultiplesRubros.TabStop = True
        Me.lnkFiltroMultiplesRubros.Text = "Todos los Rubros"
        '
        'lnkFiltroMultiplesMarcas
        '
        Me.lnkFiltroMultiplesMarcas.AutoSize = True
        Me.lnkFiltroMultiplesMarcas.Location = New System.Drawing.Point(9, 58)
        Me.lnkFiltroMultiplesMarcas.Name = "lnkFiltroMultiplesMarcas"
        Me.lnkFiltroMultiplesMarcas.Size = New System.Drawing.Size(91, 13)
        Me.lnkFiltroMultiplesMarcas.TabIndex = 11
        Me.lnkFiltroMultiplesMarcas.TabStop = True
        Me.lnkFiltroMultiplesMarcas.Text = "Todas las Marcas"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(9, 13)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Codigo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BindearPropiedadControl = Nothing
        Me.txtCodigo.BindearPropiedadEntidad = Nothing
        Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigo.Formato = ""
        Me.txtCodigo.IsDecimal = False
        Me.txtCodigo.IsNumber = False
        Me.txtCodigo.IsPK = False
        Me.txtCodigo.IsRequired = False
        Me.txtCodigo.Key = ""
        Me.txtCodigo.LabelAsoc = Me.lblCodigo
        Me.txtCodigo.Location = New System.Drawing.Point(12, 29)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(110, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(122, 13)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 2
        Me.lblProducto.Text = "Producto"
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
        Me.txtProducto.LabelAsoc = Me.lblProducto
        Me.txtProducto.Location = New System.Drawing.Point(125, 29)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(255, 20)
        Me.txtProducto.TabIndex = 3
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(862, 219)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 53
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbExportar, Me.tsbSubirArchivosALaWeb, Me.ToolStripSeparator1, Me.tsbFiltros, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 4
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Enabled = False
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(118, 26)
        Me.tsbExportar.Text = "&Generar Archivo"
        Me.tsbExportar.ToolTipText = "Imprimir"
        '
        'tsbSubirArchivosALaWeb
        '
        Me.tsbSubirArchivosALaWeb.Enabled = False
        Me.tsbSubirArchivosALaWeb.Image = Global.Eniac.Win.My.Resources.Resources.world_up_32
        Me.tsbSubirArchivosALaWeb.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSubirArchivosALaWeb.Name = "tsbSubirArchivosALaWeb"
        Me.tsbSubirArchivosALaWeb.Size = New System.Drawing.Size(155, 26)
        Me.tsbSubirArchivosALaWeb.Text = "&Subir archivos a la Web"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbFiltros
        '
        Me.tsbFiltros.Image = Global.Eniac.Win.My.Resources.Resources.filter_data_24
        Me.tsbFiltros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFiltros.Name = "tsbFiltros"
        Me.tsbFiltros.Size = New System.Drawing.Size(65, 26)
        Me.tsbFiltros.Text = "Filtros"
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
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 568)
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
        Me.chbTodos.Location = New System.Drawing.Point(12, 3)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(122, 24)
        Me.chbTodos.TabIndex = 0
        Me.chbTodos.Text = "Chequear todos"
        Me.chbTodos.UseVisualStyleBackColor = True
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
        Me.cmbSubRubro.LabelAsoc = Me.chbSubRubro
        Me.cmbSubRubro.Location = New System.Drawing.Point(624, 54)
        Me.cmbSubRubro.Name = "cmbSubRubro"
        Me.cmbSubRubro.Size = New System.Drawing.Size(180, 21)
        Me.cmbSubRubro.TabIndex = 16
        Me.cmbSubRubro.Visible = False
        '
        'chbSubRubro
        '
        Me.chbSubRubro.AutoSize = True
        Me.chbSubRubro.BindearPropiedadControl = Nothing
        Me.chbSubRubro.BindearPropiedadEntidad = Nothing
        Me.chbSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSubRubro.IsPK = False
        Me.chbSubRubro.IsRequired = False
        Me.chbSubRubro.Key = Nothing
        Me.chbSubRubro.LabelAsoc = Nothing
        Me.chbSubRubro.Location = New System.Drawing.Point(540, 56)
        Me.chbSubRubro.Name = "chbSubRubro"
        Me.chbSubRubro.Size = New System.Drawing.Size(74, 17)
        Me.chbSubRubro.TabIndex = 15
        Me.chbSubRubro.Text = "SubRubro"
        Me.chbSubRubro.UseVisualStyleBackColor = True
        Me.chbSubRubro.Visible = False
        '
        'lblPublicarEnListaDePreciosParaClientes
        '
        Me.lblPublicarEnListaDePreciosParaClientes.AutoSize = True
        Me.lblPublicarEnListaDePreciosParaClientes.LabelAsoc = Nothing
        Me.lblPublicarEnListaDePreciosParaClientes.Location = New System.Drawing.Point(185, 91)
        Me.lblPublicarEnListaDePreciosParaClientes.Name = "lblPublicarEnListaDePreciosParaClientes"
        Me.lblPublicarEnListaDePreciosParaClientes.Size = New System.Drawing.Size(122, 13)
        Me.lblPublicarEnListaDePreciosParaClientes.TabIndex = 16
        Me.lblPublicarEnListaDePreciosParaClientes.Text = "Lista de Precios Clientes"
        '
        'cmbPublicarEnListaDePreciosParaClientes
        '
        Me.cmbPublicarEnListaDePreciosParaClientes.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnListaDePreciosParaClientes.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnListaDePreciosParaClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnListaDePreciosParaClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnListaDePreciosParaClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnListaDePreciosParaClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnListaDePreciosParaClientes.FormattingEnabled = True
        Me.cmbPublicarEnListaDePreciosParaClientes.IsPK = False
        Me.cmbPublicarEnListaDePreciosParaClientes.IsRequired = False
        Me.cmbPublicarEnListaDePreciosParaClientes.Key = Nothing
        Me.cmbPublicarEnListaDePreciosParaClientes.LabelAsoc = Me.lblPublicarEnListaDePreciosParaClientes
        Me.cmbPublicarEnListaDePreciosParaClientes.Location = New System.Drawing.Point(313, 87)
        Me.cmbPublicarEnListaDePreciosParaClientes.Name = "cmbPublicarEnListaDePreciosParaClientes"
        Me.cmbPublicarEnListaDePreciosParaClientes.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnListaDePreciosParaClientes.TabIndex = 17
        '
        'lblEsServicio
        '
        Me.lblEsServicio.AutoSize = True
        Me.lblEsServicio.LabelAsoc = Nothing
        Me.lblEsServicio.Location = New System.Drawing.Point(9, 81)
        Me.lblEsServicio.Name = "lblEsServicio"
        Me.lblEsServicio.Size = New System.Drawing.Size(60, 13)
        Me.lblEsServicio.TabIndex = 19
        Me.lblEsServicio.Text = "Es Servicio"
        '
        'lblPagaIngBrutos
        '
        Me.lblPagaIngBrutos.AutoSize = True
        Me.lblPagaIngBrutos.LabelAsoc = Nothing
        Me.lblPagaIngBrutos.Location = New System.Drawing.Point(9, 131)
        Me.lblPagaIngBrutos.Name = "lblPagaIngBrutos"
        Me.lblPagaIngBrutos.Size = New System.Drawing.Size(86, 13)
        Me.lblPagaIngBrutos.TabIndex = 29
        Me.lblPagaIngBrutos.Text = "Paga Ing. Brutos"
        '
        'lblEsDeCompras
        '
        Me.lblEsDeCompras.AutoSize = True
        Me.lblEsDeCompras.LabelAsoc = Nothing
        Me.lblEsDeCompras.Location = New System.Drawing.Point(192, 81)
        Me.lblEsDeCompras.Name = "lblEsDeCompras"
        Me.lblEsDeCompras.Size = New System.Drawing.Size(78, 13)
        Me.lblEsDeCompras.TabIndex = 21
        Me.lblEsDeCompras.Text = "Es de Compras"
        '
        'lblEsDeVentas
        '
        Me.lblEsDeVentas.AutoSize = True
        Me.lblEsDeVentas.LabelAsoc = Nothing
        Me.lblEsDeVentas.Location = New System.Drawing.Point(388, 81)
        Me.lblEsDeVentas.Name = "lblEsDeVentas"
        Me.lblEsDeVentas.Size = New System.Drawing.Size(70, 13)
        Me.lblEsDeVentas.TabIndex = 23
        Me.lblEsDeVentas.Text = "Es de Ventas"
        '
        'lblPermiteModDesc
        '
        Me.lblPermiteModDesc.AutoSize = True
        Me.lblPermiteModDesc.LabelAsoc = Nothing
        Me.lblPermiteModDesc.Location = New System.Drawing.Point(9, 106)
        Me.lblPermiteModDesc.Name = "lblPermiteModDesc"
        Me.lblPermiteModDesc.Size = New System.Drawing.Size(147, 13)
        Me.lblPermiteModDesc.TabIndex = 25
        Me.lblPermiteModDesc.Text = "Permite Modificar Descripcion"
        '
        'cmbPermiteModDesc
        '
        Me.cmbPermiteModDesc.BindearPropiedadControl = Nothing
        Me.cmbPermiteModDesc.BindearPropiedadEntidad = Nothing
        Me.cmbPermiteModDesc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPermiteModDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPermiteModDesc.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPermiteModDesc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPermiteModDesc.FormattingEnabled = True
        Me.cmbPermiteModDesc.IsPK = False
        Me.cmbPermiteModDesc.IsRequired = False
        Me.cmbPermiteModDesc.Key = Nothing
        Me.cmbPermiteModDesc.LabelAsoc = Me.lblPermiteModDesc
        Me.cmbPermiteModDesc.Location = New System.Drawing.Point(158, 102)
        Me.cmbPermiteModDesc.Name = "cmbPermiteModDesc"
        Me.cmbPermiteModDesc.Size = New System.Drawing.Size(83, 21)
        Me.cmbPermiteModDesc.TabIndex = 26
        '
        'cmbPagaIngBrutos
        '
        Me.cmbPagaIngBrutos.BindearPropiedadControl = Nothing
        Me.cmbPagaIngBrutos.BindearPropiedadEntidad = Nothing
        Me.cmbPagaIngBrutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPagaIngBrutos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPagaIngBrutos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPagaIngBrutos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPagaIngBrutos.FormattingEnabled = True
        Me.cmbPagaIngBrutos.IsPK = False
        Me.cmbPagaIngBrutos.IsRequired = False
        Me.cmbPagaIngBrutos.Key = Nothing
        Me.cmbPagaIngBrutos.LabelAsoc = Me.lblPagaIngBrutos
        Me.cmbPagaIngBrutos.Location = New System.Drawing.Point(158, 127)
        Me.cmbPagaIngBrutos.Name = "cmbPagaIngBrutos"
        Me.cmbPagaIngBrutos.Size = New System.Drawing.Size(83, 21)
        Me.cmbPagaIngBrutos.TabIndex = 30
        '
        'cmbEsDeVentas
        '
        Me.cmbEsDeVentas.BindearPropiedadControl = Nothing
        Me.cmbEsDeVentas.BindearPropiedadEntidad = Nothing
        Me.cmbEsDeVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsDeVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEsDeVentas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsDeVentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsDeVentas.FormattingEnabled = True
        Me.cmbEsDeVentas.IsPK = False
        Me.cmbEsDeVentas.IsRequired = False
        Me.cmbEsDeVentas.Key = Nothing
        Me.cmbEsDeVentas.LabelAsoc = Me.lblEsDeVentas
        Me.cmbEsDeVentas.Location = New System.Drawing.Point(464, 77)
        Me.cmbEsDeVentas.Name = "cmbEsDeVentas"
        Me.cmbEsDeVentas.Size = New System.Drawing.Size(83, 21)
        Me.cmbEsDeVentas.TabIndex = 24
        '
        'cmbEsDeCompras
        '
        Me.cmbEsDeCompras.BindearPropiedadControl = Nothing
        Me.cmbEsDeCompras.BindearPropiedadEntidad = Nothing
        Me.cmbEsDeCompras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsDeCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEsDeCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsDeCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsDeCompras.FormattingEnabled = True
        Me.cmbEsDeCompras.IsPK = False
        Me.cmbEsDeCompras.IsRequired = False
        Me.cmbEsDeCompras.Key = Nothing
        Me.cmbEsDeCompras.LabelAsoc = Me.lblEsDeCompras
        Me.cmbEsDeCompras.Location = New System.Drawing.Point(276, 77)
        Me.cmbEsDeCompras.Name = "cmbEsDeCompras"
        Me.cmbEsDeCompras.Size = New System.Drawing.Size(83, 21)
        Me.cmbEsDeCompras.TabIndex = 22
        '
        'cmbEsServicio
        '
        Me.cmbEsServicio.BindearPropiedadControl = Nothing
        Me.cmbEsServicio.BindearPropiedadEntidad = Nothing
        Me.cmbEsServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEsServicio.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsServicio.FormattingEnabled = True
        Me.cmbEsServicio.IsPK = False
        Me.cmbEsServicio.IsRequired = False
        Me.cmbEsServicio.Key = Nothing
        Me.cmbEsServicio.LabelAsoc = Me.lblEsServicio
        Me.cmbEsServicio.Location = New System.Drawing.Point(75, 77)
        Me.cmbEsServicio.Name = "cmbEsServicio"
        Me.cmbEsServicio.Size = New System.Drawing.Size(83, 21)
        Me.cmbEsServicio.TabIndex = 20
        '
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.cmbTipoInforme)
        Me.gbFiltros.Controls.Add(Me.lblTipoInforme)
        Me.gbFiltros.Controls.Add(Me.lblSucursal)
        Me.gbFiltros.Controls.Add(Me.cmbSucursal)
        Me.gbFiltros.Controls.Add(Me.lblListaPreciosMayorista)
        Me.gbFiltros.Controls.Add(Me.cmbListaPreciosMayorista)
        Me.gbFiltros.Controls.Add(Me.grpPublicarEn)
        Me.gbFiltros.Controls.Add(Me.dtpEnviando)
        Me.gbFiltros.Controls.Add(Me.lblEnviando)
        Me.gbFiltros.Controls.Add(Me.cmbEnviando)
        Me.gbFiltros.Controls.Add(Me.lblSubirImagenes)
        Me.gbFiltros.Controls.Add(Me.cmbSubirImagenes)
        Me.gbFiltros.Controls.Add(Me.lblRedondeoDecimales2)
        Me.gbFiltros.Controls.Add(Me.lblRedondeoDecimales)
        Me.gbFiltros.Controls.Add(Me.txtRedondeoDecimales)
        Me.gbFiltros.Controls.Add(Me.chbConIVA)
        Me.gbFiltros.Controls.Add(Me.lnkFiltroMultiplesSubRubros)
        Me.gbFiltros.Controls.Add(Me.lnkFiltroMultiplesSubSubRubros)
        Me.gbFiltros.Controls.Add(Me.chbFechaActualizado)
        Me.gbFiltros.Controls.Add(Me.dtpHasta)
        Me.gbFiltros.Controls.Add(Me.dtpDesde)
        Me.gbFiltros.Controls.Add(Me.lblHasta)
        Me.gbFiltros.Controls.Add(Me.lblDesde)
        Me.gbFiltros.Controls.Add(Me.cmbListaPrecios)
        Me.gbFiltros.Controls.Add(Me.cmbFormato)
        Me.gbFiltros.Controls.Add(Me.cmbSubRubro)
        Me.gbFiltros.Controls.Add(Me.cmbAfectaStock)
        Me.gbFiltros.Controls.Add(Me.chbSubRubro)
        Me.gbFiltros.Controls.Add(Me.lnkFiltroMultiplesRubros)
        Me.gbFiltros.Controls.Add(Me.lblEsServicio)
        Me.gbFiltros.Controls.Add(Me.lnkFiltroMultiplesMarcas)
        Me.gbFiltros.Controls.Add(Me.lblMoneda)
        Me.gbFiltros.Controls.Add(Me.lblTipoCambio)
        Me.gbFiltros.Controls.Add(Me.lblFormato)
        Me.gbFiltros.Controls.Add(Me.lblPagaIngBrutos)
        Me.gbFiltros.Controls.Add(Me.lblAfectaStock)
        Me.gbFiltros.Controls.Add(Me.lblEsDeCompras)
        Me.gbFiltros.Controls.Add(Me.lblCodigo)
        Me.gbFiltros.Controls.Add(Me.lblListaPrecios)
        Me.gbFiltros.Controls.Add(Me.lblEsDeVentas)
        Me.gbFiltros.Controls.Add(Me.txtCodigo)
        Me.gbFiltros.Controls.Add(Me.lblPermiteModDesc)
        Me.gbFiltros.Controls.Add(Me.lblActivo)
        Me.gbFiltros.Controls.Add(Me.cmbPermiteModDesc)
        Me.gbFiltros.Controls.Add(Me.lblProducto)
        Me.gbFiltros.Controls.Add(Me.cmbPagaIngBrutos)
        Me.gbFiltros.Controls.Add(Me.cmbActivo)
        Me.gbFiltros.Controls.Add(Me.cmbEsDeVentas)
        Me.gbFiltros.Controls.Add(Me.btnConsultar)
        Me.gbFiltros.Controls.Add(Me.cmbEsDeCompras)
        Me.gbFiltros.Controls.Add(Me.txtTipoCambio)
        Me.gbFiltros.Controls.Add(Me.txtEmbalaje)
        Me.gbFiltros.Controls.Add(Me.cmbMoneda)
        Me.gbFiltros.Controls.Add(Me.cmbEsServicio)
        Me.gbFiltros.Controls.Add(Me.txtProducto)
        Me.gbFiltros.Controls.Add(Me.lblEmbalaje)
        Me.gbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbFiltros.Location = New System.Drawing.Point(0, 29)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Size = New System.Drawing.Size(984, 254)
        Me.gbFiltros.TabIndex = 0
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Filtros"
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(260, 154)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 35
        Me.lblSucursal.Text = "Sucursal"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.Items.AddRange(New Object() {"del producto"})
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(349, 151)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(151, 21)
        Me.cmbSucursal.TabIndex = 36
        '
        'lblListaPreciosMayorista
        '
        Me.lblListaPreciosMayorista.AutoSize = True
        Me.lblListaPreciosMayorista.LabelAsoc = Nothing
        Me.lblListaPreciosMayorista.Location = New System.Drawing.Point(9, 155)
        Me.lblListaPreciosMayorista.Name = "lblListaPreciosMayorista"
        Me.lblListaPreciosMayorista.Size = New System.Drawing.Size(130, 13)
        Me.lblListaPreciosMayorista.TabIndex = 33
        Me.lblListaPreciosMayorista.Text = "Lista de Precios Mayorista"
        '
        'cmbListaPreciosMayorista
        '
        Me.cmbListaPreciosMayorista.BindearPropiedadControl = Nothing
        Me.cmbListaPreciosMayorista.BindearPropiedadEntidad = Nothing
        Me.cmbListaPreciosMayorista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPreciosMayorista.Enabled = False
        Me.cmbListaPreciosMayorista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPreciosMayorista.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPreciosMayorista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPreciosMayorista.FormattingEnabled = True
        Me.cmbListaPreciosMayorista.IsPK = False
        Me.cmbListaPreciosMayorista.IsRequired = False
        Me.cmbListaPreciosMayorista.Items.AddRange(New Object() {"del producto"})
        Me.cmbListaPreciosMayorista.Key = Nothing
        Me.cmbListaPreciosMayorista.LabelAsoc = Me.lblListaPreciosMayorista
        Me.cmbListaPreciosMayorista.Location = New System.Drawing.Point(158, 152)
        Me.cmbListaPreciosMayorista.Name = "cmbListaPreciosMayorista"
        Me.cmbListaPreciosMayorista.Size = New System.Drawing.Size(96, 21)
        Me.cmbListaPreciosMayorista.TabIndex = 34
        '
        'grpPublicarEn
        '
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnEmpresarial)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnGestion)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnWeb)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnEmpresarial)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnMercadoLibre)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnSincronizarSucursal)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnTiendaNube)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnMercadoLibre)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnBalanza)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnArborea)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnSincronizacionSucursal)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnTiendaNube)
        Me.grpPublicarEn.Controls.Add(Me.cmbPublicarEnListaDePreciosParaClientes)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnBalanza)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnArborea)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnGestion)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnListaDePreciosParaClientes)
        Me.grpPublicarEn.Controls.Add(Me.lblPublicarEnWeb)
        Me.grpPublicarEn.Location = New System.Drawing.Point(570, 78)
        Me.grpPublicarEn.Name = "grpPublicarEn"
        Me.grpPublicarEn.Size = New System.Drawing.Size(402, 138)
        Me.grpPublicarEn.TabIndex = 52
        Me.grpPublicarEn.TabStop = False
        Me.grpPublicarEn.Text = "Publicar En..."
        '
        'cmbPublicarEnEmpresarial
        '
        Me.cmbPublicarEnEmpresarial.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnEmpresarial.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnEmpresarial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnEmpresarial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnEmpresarial.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnEmpresarial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnEmpresarial.FormattingEnabled = True
        Me.cmbPublicarEnEmpresarial.IsPK = False
        Me.cmbPublicarEnEmpresarial.IsRequired = False
        Me.cmbPublicarEnEmpresarial.Key = Nothing
        Me.cmbPublicarEnEmpresarial.LabelAsoc = Me.lblPublicarEnEmpresarial
        Me.cmbPublicarEnEmpresarial.Location = New System.Drawing.Point(96, 37)
        Me.cmbPublicarEnEmpresarial.Name = "cmbPublicarEnEmpresarial"
        Me.cmbPublicarEnEmpresarial.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnEmpresarial.TabIndex = 3
        '
        'lblPublicarEnEmpresarial
        '
        Me.lblPublicarEnEmpresarial.AutoSize = True
        Me.lblPublicarEnEmpresarial.LabelAsoc = Nothing
        Me.lblPublicarEnEmpresarial.Location = New System.Drawing.Point(4, 41)
        Me.lblPublicarEnEmpresarial.Name = "lblPublicarEnEmpresarial"
        Me.lblPublicarEnEmpresarial.Size = New System.Drawing.Size(83, 13)
        Me.lblPublicarEnEmpresarial.TabIndex = 2
        Me.lblPublicarEnEmpresarial.Text = "App Empresarial"
        '
        'cmbPublicarEnGestion
        '
        Me.cmbPublicarEnGestion.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnGestion.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnGestion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnGestion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnGestion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnGestion.FormattingEnabled = True
        Me.cmbPublicarEnGestion.IsPK = False
        Me.cmbPublicarEnGestion.IsRequired = False
        Me.cmbPublicarEnGestion.Key = Nothing
        Me.cmbPublicarEnGestion.LabelAsoc = Me.lblPublicarEnGestion
        Me.cmbPublicarEnGestion.Location = New System.Drawing.Point(96, 12)
        Me.cmbPublicarEnGestion.Name = "cmbPublicarEnGestion"
        Me.cmbPublicarEnGestion.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnGestion.TabIndex = 1
        '
        'lblPublicarEnGestion
        '
        Me.lblPublicarEnGestion.AutoSize = True
        Me.lblPublicarEnGestion.LabelAsoc = Nothing
        Me.lblPublicarEnGestion.Location = New System.Drawing.Point(4, 16)
        Me.lblPublicarEnGestion.Name = "lblPublicarEnGestion"
        Me.lblPublicarEnGestion.Size = New System.Drawing.Size(65, 13)
        Me.lblPublicarEnGestion.TabIndex = 0
        Me.lblPublicarEnGestion.Text = "App Gestión"
        '
        'cmbPublicarEnWeb
        '
        Me.cmbPublicarEnWeb.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnWeb.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnWeb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnWeb.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnWeb.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnWeb.FormattingEnabled = True
        Me.cmbPublicarEnWeb.IsPK = False
        Me.cmbPublicarEnWeb.IsRequired = False
        Me.cmbPublicarEnWeb.Key = Nothing
        Me.cmbPublicarEnWeb.LabelAsoc = Me.lblPublicarEnWeb
        Me.cmbPublicarEnWeb.Location = New System.Drawing.Point(313, 12)
        Me.cmbPublicarEnWeb.Name = "cmbPublicarEnWeb"
        Me.cmbPublicarEnWeb.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnWeb.TabIndex = 11
        '
        'lblPublicarEnWeb
        '
        Me.lblPublicarEnWeb.AutoSize = True
        Me.lblPublicarEnWeb.LabelAsoc = Nothing
        Me.lblPublicarEnWeb.Location = New System.Drawing.Point(185, 16)
        Me.lblPublicarEnWeb.Name = "lblPublicarEnWeb"
        Me.lblPublicarEnWeb.Size = New System.Drawing.Size(71, 13)
        Me.lblPublicarEnWeb.TabIndex = 10
        Me.lblPublicarEnWeb.Text = "Web / Carrito"
        '
        'cmbPublicarEnMercadoLibre
        '
        Me.cmbPublicarEnMercadoLibre.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnMercadoLibre.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnMercadoLibre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnMercadoLibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnMercadoLibre.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnMercadoLibre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnMercadoLibre.FormattingEnabled = True
        Me.cmbPublicarEnMercadoLibre.IsPK = False
        Me.cmbPublicarEnMercadoLibre.IsRequired = False
        Me.cmbPublicarEnMercadoLibre.Key = Nothing
        Me.cmbPublicarEnMercadoLibre.LabelAsoc = Me.lblPublicarEnMercadoLibre
        Me.cmbPublicarEnMercadoLibre.Location = New System.Drawing.Point(96, 87)
        Me.cmbPublicarEnMercadoLibre.Name = "cmbPublicarEnMercadoLibre"
        Me.cmbPublicarEnMercadoLibre.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnMercadoLibre.TabIndex = 7
        '
        'lblPublicarEnMercadoLibre
        '
        Me.lblPublicarEnMercadoLibre.AutoSize = True
        Me.lblPublicarEnMercadoLibre.LabelAsoc = Nothing
        Me.lblPublicarEnMercadoLibre.Location = New System.Drawing.Point(4, 91)
        Me.lblPublicarEnMercadoLibre.Name = "lblPublicarEnMercadoLibre"
        Me.lblPublicarEnMercadoLibre.Size = New System.Drawing.Size(75, 13)
        Me.lblPublicarEnMercadoLibre.TabIndex = 6
        Me.lblPublicarEnMercadoLibre.Text = "Mercado Libre"
        '
        'cmbPublicarEnSincronizarSucursal
        '
        Me.cmbPublicarEnSincronizarSucursal.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnSincronizarSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnSincronizarSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnSincronizarSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnSincronizarSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnSincronizarSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnSincronizarSucursal.FormattingEnabled = True
        Me.cmbPublicarEnSincronizarSucursal.IsPK = False
        Me.cmbPublicarEnSincronizarSucursal.IsRequired = False
        Me.cmbPublicarEnSincronizarSucursal.Key = Nothing
        Me.cmbPublicarEnSincronizarSucursal.LabelAsoc = Me.lblPublicarEnSincronizacionSucursal
        Me.cmbPublicarEnSincronizarSucursal.Location = New System.Drawing.Point(313, 62)
        Me.cmbPublicarEnSincronizarSucursal.Name = "cmbPublicarEnSincronizarSucursal"
        Me.cmbPublicarEnSincronizarSucursal.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnSincronizarSucursal.TabIndex = 15
        '
        'lblPublicarEnSincronizacionSucursal
        '
        Me.lblPublicarEnSincronizacionSucursal.AutoSize = True
        Me.lblPublicarEnSincronizacionSucursal.LabelAsoc = Nothing
        Me.lblPublicarEnSincronizacionSucursal.Location = New System.Drawing.Point(185, 66)
        Me.lblPublicarEnSincronizacionSucursal.Name = "lblPublicarEnSincronizacionSucursal"
        Me.lblPublicarEnSincronizacionSucursal.Size = New System.Drawing.Size(103, 13)
        Me.lblPublicarEnSincronizacionSucursal.TabIndex = 14
        Me.lblPublicarEnSincronizacionSucursal.Text = "Sincronizar Sucursal"
        '
        'cmbPublicarEnTiendaNube
        '
        Me.cmbPublicarEnTiendaNube.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnTiendaNube.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnTiendaNube.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnTiendaNube.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnTiendaNube.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnTiendaNube.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnTiendaNube.FormattingEnabled = True
        Me.cmbPublicarEnTiendaNube.IsPK = False
        Me.cmbPublicarEnTiendaNube.IsRequired = False
        Me.cmbPublicarEnTiendaNube.Key = Nothing
        Me.cmbPublicarEnTiendaNube.LabelAsoc = Me.lblPublicarEnTiendaNube
        Me.cmbPublicarEnTiendaNube.Location = New System.Drawing.Point(96, 62)
        Me.cmbPublicarEnTiendaNube.Name = "cmbPublicarEnTiendaNube"
        Me.cmbPublicarEnTiendaNube.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnTiendaNube.TabIndex = 5
        '
        'lblPublicarEnTiendaNube
        '
        Me.lblPublicarEnTiendaNube.AutoSize = True
        Me.lblPublicarEnTiendaNube.LabelAsoc = Nothing
        Me.lblPublicarEnTiendaNube.Location = New System.Drawing.Point(4, 66)
        Me.lblPublicarEnTiendaNube.Name = "lblPublicarEnTiendaNube"
        Me.lblPublicarEnTiendaNube.Size = New System.Drawing.Size(69, 13)
        Me.lblPublicarEnTiendaNube.TabIndex = 4
        Me.lblPublicarEnTiendaNube.Text = "Tienda Nube"
        '
        'cmbPublicarEnBalanza
        '
        Me.cmbPublicarEnBalanza.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnBalanza.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnBalanza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnBalanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnBalanza.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnBalanza.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnBalanza.FormattingEnabled = True
        Me.cmbPublicarEnBalanza.IsPK = False
        Me.cmbPublicarEnBalanza.IsRequired = False
        Me.cmbPublicarEnBalanza.Key = Nothing
        Me.cmbPublicarEnBalanza.LabelAsoc = Me.lblPublicarEnBalanza
        Me.cmbPublicarEnBalanza.Location = New System.Drawing.Point(313, 37)
        Me.cmbPublicarEnBalanza.Name = "cmbPublicarEnBalanza"
        Me.cmbPublicarEnBalanza.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnBalanza.TabIndex = 13
        '
        'lblPublicarEnBalanza
        '
        Me.lblPublicarEnBalanza.AutoSize = True
        Me.lblPublicarEnBalanza.LabelAsoc = Nothing
        Me.lblPublicarEnBalanza.Location = New System.Drawing.Point(185, 41)
        Me.lblPublicarEnBalanza.Name = "lblPublicarEnBalanza"
        Me.lblPublicarEnBalanza.Size = New System.Drawing.Size(45, 13)
        Me.lblPublicarEnBalanza.TabIndex = 12
        Me.lblPublicarEnBalanza.Text = "Balanza"
        '
        'cmbPublicarEnArborea
        '
        Me.cmbPublicarEnArborea.BindearPropiedadControl = Nothing
        Me.cmbPublicarEnArborea.BindearPropiedadEntidad = Nothing
        Me.cmbPublicarEnArborea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPublicarEnArborea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPublicarEnArborea.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPublicarEnArborea.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPublicarEnArborea.FormattingEnabled = True
        Me.cmbPublicarEnArborea.IsPK = False
        Me.cmbPublicarEnArborea.IsRequired = False
        Me.cmbPublicarEnArborea.Key = Nothing
        Me.cmbPublicarEnArborea.LabelAsoc = Me.lblPublicarEnArborea
        Me.cmbPublicarEnArborea.Location = New System.Drawing.Point(96, 112)
        Me.cmbPublicarEnArborea.Name = "cmbPublicarEnArborea"
        Me.cmbPublicarEnArborea.Size = New System.Drawing.Size(83, 21)
        Me.cmbPublicarEnArborea.TabIndex = 9
        '
        'lblPublicarEnArborea
        '
        Me.lblPublicarEnArborea.AutoSize = True
        Me.lblPublicarEnArborea.LabelAsoc = Nothing
        Me.lblPublicarEnArborea.Location = New System.Drawing.Point(4, 116)
        Me.lblPublicarEnArborea.Name = "lblPublicarEnArborea"
        Me.lblPublicarEnArborea.Size = New System.Drawing.Size(44, 13)
        Me.lblPublicarEnArborea.TabIndex = 8
        Me.lblPublicarEnArborea.Text = "Arborea"
        '
        'dtpEnviando
        '
        Me.dtpEnviando.BindearPropiedadControl = Nothing
        Me.dtpEnviando.BindearPropiedadEntidad = Nothing
        Me.dtpEnviando.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpEnviando.Enabled = False
        Me.dtpEnviando.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpEnviando.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpEnviando.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnviando.IsPK = False
        Me.dtpEnviando.IsRequired = False
        Me.dtpEnviando.Key = ""
        Me.dtpEnviando.LabelAsoc = Me.lblDesde
        Me.dtpEnviando.Location = New System.Drawing.Point(223, 227)
        Me.dtpEnviando.Name = "dtpEnviando"
        Me.dtpEnviando.Size = New System.Drawing.Size(125, 20)
        Me.dtpEnviando.TabIndex = 48
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(512, 33)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 5
        Me.lblDesde.Text = "Desde"
        '
        'lblEnviando
        '
        Me.lblEnviando.AutoSize = True
        Me.lblEnviando.LabelAsoc = Nothing
        Me.lblEnviando.Location = New System.Drawing.Point(7, 231)
        Me.lblEnviando.Name = "lblEnviando"
        Me.lblEnviando.Size = New System.Drawing.Size(52, 13)
        Me.lblEnviando.TabIndex = 46
        Me.lblEnviando.Text = "Enviando"
        '
        'cmbEnviando
        '
        Me.cmbEnviando.BindearPropiedadControl = Nothing
        Me.cmbEnviando.BindearPropiedadEntidad = Nothing
        Me.cmbEnviando.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEnviando.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEnviando.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEnviando.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEnviando.FormattingEnabled = True
        Me.cmbEnviando.IsPK = False
        Me.cmbEnviando.IsRequired = False
        Me.cmbEnviando.Key = Nothing
        Me.cmbEnviando.LabelAsoc = Me.lblEnviando
        Me.cmbEnviando.Location = New System.Drawing.Point(60, 227)
        Me.cmbEnviando.Name = "cmbEnviando"
        Me.cmbEnviando.Size = New System.Drawing.Size(157, 21)
        Me.cmbEnviando.TabIndex = 47
        '
        'lblSubirImagenes
        '
        Me.lblSubirImagenes.AutoSize = True
        Me.lblSubirImagenes.LabelAsoc = Nothing
        Me.lblSubirImagenes.Location = New System.Drawing.Point(222, 181)
        Me.lblSubirImagenes.Name = "lblSubirImagenes"
        Me.lblSubirImagenes.Size = New System.Drawing.Size(189, 13)
        Me.lblSubirImagenes.TabIndex = 39
        Me.lblSubirImagenes.Text = "Incuir Fotos al Subir archivos a la Web"
        '
        'cmbSubirImagenes
        '
        Me.cmbSubirImagenes.BindearPropiedadControl = Nothing
        Me.cmbSubirImagenes.BindearPropiedadEntidad = Nothing
        Me.cmbSubirImagenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubirImagenes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubirImagenes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubirImagenes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubirImagenes.FormattingEnabled = True
        Me.cmbSubirImagenes.IsPK = False
        Me.cmbSubirImagenes.IsRequired = False
        Me.cmbSubirImagenes.Key = Nothing
        Me.cmbSubirImagenes.LabelAsoc = Me.lblSubirImagenes
        Me.cmbSubirImagenes.Location = New System.Drawing.Point(417, 177)
        Me.cmbSubirImagenes.Name = "cmbSubirImagenes"
        Me.cmbSubirImagenes.Size = New System.Drawing.Size(60, 21)
        Me.cmbSubirImagenes.TabIndex = 40
        '
        'lblRedondeoDecimales2
        '
        Me.lblRedondeoDecimales2.AutoSize = True
        Me.lblRedondeoDecimales2.LabelAsoc = Me.lblRedondeoDecimales
        Me.lblRedondeoDecimales2.Location = New System.Drawing.Point(496, 231)
        Me.lblRedondeoDecimales2.Name = "lblRedondeoDecimales2"
        Me.lblRedondeoDecimales2.Size = New System.Drawing.Size(54, 13)
        Me.lblRedondeoDecimales2.TabIndex = 51
        Me.lblRedondeoDecimales2.Text = "decimales"
        '
        'lblRedondeoDecimales
        '
        Me.lblRedondeoDecimales.AutoSize = True
        Me.lblRedondeoDecimales.LabelAsoc = Nothing
        Me.lblRedondeoDecimales.Location = New System.Drawing.Point(366, 231)
        Me.lblRedondeoDecimales.Name = "lblRedondeoDecimales"
        Me.lblRedondeoDecimales.Size = New System.Drawing.Size(95, 13)
        Me.lblRedondeoDecimales.TabIndex = 49
        Me.lblRedondeoDecimales.Text = "Redondeo Precios"
        '
        'txtRedondeoDecimales
        '
        Me.txtRedondeoDecimales.BindearPropiedadControl = ""
        Me.txtRedondeoDecimales.BindearPropiedadEntidad = ""
        Me.txtRedondeoDecimales.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRedondeoDecimales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRedondeoDecimales.Formato = "N2"
        Me.txtRedondeoDecimales.IsDecimal = False
        Me.txtRedondeoDecimales.IsNumber = True
        Me.txtRedondeoDecimales.IsPK = False
        Me.txtRedondeoDecimales.IsRequired = False
        Me.txtRedondeoDecimales.Key = ""
        Me.txtRedondeoDecimales.LabelAsoc = Me.lblRedondeoDecimales
        Me.txtRedondeoDecimales.Location = New System.Drawing.Point(466, 227)
        Me.txtRedondeoDecimales.MaxLength = 4
        Me.txtRedondeoDecimales.Name = "txtRedondeoDecimales"
        Me.txtRedondeoDecimales.Size = New System.Drawing.Size(24, 20)
        Me.txtRedondeoDecimales.TabIndex = 50
        Me.txtRedondeoDecimales.Text = "2"
        Me.txtRedondeoDecimales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbConIVA
        '
        Me.chbConIVA.AutoSize = True
        Me.chbConIVA.BindearPropiedadControl = Nothing
        Me.chbConIVA.BindearPropiedadEntidad = Nothing
        Me.chbConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConIVA.IsPK = False
        Me.chbConIVA.IsRequired = False
        Me.chbConIVA.Key = Nothing
        Me.chbConIVA.LabelAsoc = Nothing
        Me.chbConIVA.Location = New System.Drawing.Point(485, 204)
        Me.chbConIVA.Name = "chbConIVA"
        Me.chbConIVA.Size = New System.Drawing.Size(65, 17)
        Me.chbConIVA.TabIndex = 45
        Me.chbConIVA.Text = "Con IVA"
        Me.chbConIVA.UseVisualStyleBackColor = True
        '
        'lnkFiltroMultiplesSubRubros
        '
        Me.lnkFiltroMultiplesSubRubros.AutoSize = True
        Me.lnkFiltroMultiplesSubRubros.Location = New System.Drawing.Point(239, 58)
        Me.lnkFiltroMultiplesSubRubros.Name = "lnkFiltroMultiplesSubRubros"
        Me.lnkFiltroMultiplesSubRubros.Size = New System.Drawing.Size(109, 13)
        Me.lnkFiltroMultiplesSubRubros.TabIndex = 13
        Me.lnkFiltroMultiplesSubRubros.TabStop = True
        Me.lnkFiltroMultiplesSubRubros.Text = "Todos los SubRubros"
        Me.lnkFiltroMultiplesSubRubros.Visible = False
        '
        'lnkFiltroMultiplesSubSubRubros
        '
        Me.lnkFiltroMultiplesSubSubRubros.AutoSize = True
        Me.lnkFiltroMultiplesSubSubRubros.Location = New System.Drawing.Point(372, 58)
        Me.lnkFiltroMultiplesSubSubRubros.Name = "lnkFiltroMultiplesSubSubRubros"
        Me.lnkFiltroMultiplesSubSubRubros.Size = New System.Drawing.Size(128, 13)
        Me.lnkFiltroMultiplesSubSubRubros.TabIndex = 14
        Me.lnkFiltroMultiplesSubSubRubros.TabStop = True
        Me.lnkFiltroMultiplesSubSubRubros.Text = "Todos los SubSubRubros"
        Me.lnkFiltroMultiplesSubSubRubros.Visible = False
        '
        'chbFechaActualizado
        '
        Me.chbFechaActualizado.AutoSize = True
        Me.chbFechaActualizado.BindearPropiedadControl = Nothing
        Me.chbFechaActualizado.BindearPropiedadEntidad = Nothing
        Me.chbFechaActualizado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaActualizado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaActualizado.IsPK = False
        Me.chbFechaActualizado.IsRequired = False
        Me.chbFechaActualizado.Key = Nothing
        Me.chbFechaActualizado.LabelAsoc = Nothing
        Me.chbFechaActualizado.Location = New System.Drawing.Point(399, 31)
        Me.chbFechaActualizado.Name = "chbFechaActualizado"
        Me.chbFechaActualizado.Size = New System.Drawing.Size(114, 17)
        Me.chbFechaActualizado.TabIndex = 4
        Me.chbFechaActualizado.Text = "Fecha Actualizado"
        Me.chbFechaActualizado.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(721, 29)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 8
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(684, 33)
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
        Me.dtpDesde.Location = New System.Drawing.Point(553, 29)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 6
        '
        'cmbListaPrecios
        '
        Me.cmbListaPrecios.BindearPropiedadControl = Nothing
        Me.cmbListaPrecios.BindearPropiedadEntidad = Nothing
        Me.cmbListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaPrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaPrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaPrecios.FormattingEnabled = True
        Me.cmbListaPrecios.IsPK = False
        Me.cmbListaPrecios.IsRequired = False
        Me.cmbListaPrecios.Key = Nothing
        Me.cmbListaPrecios.LabelAsoc = Me.lblListaPrecios
        Me.cmbListaPrecios.Location = New System.Drawing.Point(349, 127)
        Me.cmbListaPrecios.Name = "cmbListaPrecios"
        Me.cmbListaPrecios.Size = New System.Drawing.Size(190, 21)
        Me.cmbListaPrecios.TabIndex = 32
        '
        'lblListaPrecios
        '
        Me.lblListaPrecios.AutoSize = True
        Me.lblListaPrecios.LabelAsoc = Nothing
        Me.lblListaPrecios.Location = New System.Drawing.Point(260, 131)
        Me.lblListaPrecios.Name = "lblListaPrecios"
        Me.lblListaPrecios.Size = New System.Drawing.Size(82, 13)
        Me.lblListaPrecios.TabIndex = 31
        Me.lblListaPrecios.Text = "Lista de Precios"
        '
        'cmbFormato
        '
        Me.cmbFormato.BindearPropiedadControl = Nothing
        Me.cmbFormato.BindearPropiedadEntidad = Nothing
        Me.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormato.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormato.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormato.FormattingEnabled = True
        Me.cmbFormato.IsPK = False
        Me.cmbFormato.IsRequired = False
        Me.cmbFormato.Key = Nothing
        Me.cmbFormato.LabelAsoc = Me.lblFormato
        Me.cmbFormato.Location = New System.Drawing.Point(60, 177)
        Me.cmbFormato.Name = "cmbFormato"
        Me.cmbFormato.Size = New System.Drawing.Size(157, 21)
        Me.cmbFormato.TabIndex = 38
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.LabelAsoc = Nothing
        Me.lblFormato.Location = New System.Drawing.Point(9, 181)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(45, 13)
        Me.lblFormato.TabIndex = 37
        Me.lblFormato.Text = "Formato"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.LabelAsoc = Nothing
        Me.lblMoneda.Location = New System.Drawing.Point(9, 206)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(202, 13)
        Me.lblMoneda.TabIndex = 41
        Me.lblMoneda.Text = "Exportar los Precios Utilizando la Moneda"
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.LabelAsoc = Nothing
        Me.lblTipoCambio.Location = New System.Drawing.Point(332, 206)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(81, 13)
        Me.lblTipoCambio.TabIndex = 43
        Me.lblTipoCambio.Text = "Tipo de Cambio"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BindearPropiedadControl = ""
        Me.txtTipoCambio.BindearPropiedadEntidad = ""
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoCambio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoCambio.Formato = "N2"
        Me.txtTipoCambio.IsDecimal = True
        Me.txtTipoCambio.IsNumber = True
        Me.txtTipoCambio.IsPK = False
        Me.txtTipoCambio.IsRequired = False
        Me.txtTipoCambio.Key = ""
        Me.txtTipoCambio.LabelAsoc = Me.lblTipoCambio
        Me.txtTipoCambio.Location = New System.Drawing.Point(419, 202)
        Me.txtTipoCambio.MaxLength = 4
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(58, 20)
        Me.txtTipoCambio.TabIndex = 44
        Me.txtTipoCambio.Text = "1.00"
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.cmbMoneda.Location = New System.Drawing.Point(226, 202)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(100, 21)
        Me.cmbMoneda.TabIndex = 42
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance2.TextHAlignAsString = "Left"
        Appearance2.TextVAlignAsString = "Middle"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Codigo"
        UltraGridColumn1.Header.VisiblePosition = 2
        UltraGridColumn1.Width = 100
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn2.Header.Caption = "Nombre Producto"
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.Width = 249
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance3
        UltraGridColumn3.Header.VisiblePosition = 14
        UltraGridColumn3.Width = 52
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance4
        UltraGridColumn4.Header.Caption = "UM"
        UltraGridColumn4.Header.VisiblePosition = 15
        UltraGridColumn4.Width = 37
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn5.Header.VisiblePosition = 16
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn6.Header.VisiblePosition = 17
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn7.Header.Caption = "Nombre Marca"
        UltraGridColumn7.Header.VisiblePosition = 5
        UltraGridColumn7.Width = 144
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn8.Header.VisiblePosition = 18
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn9.Header.Caption = "Nombre Rubro"
        UltraGridColumn9.Header.VisiblePosition = 6
        UltraGridColumn9.Width = 158
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn10.Header.VisiblePosition = 19
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn11.Header.VisiblePosition = 20
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn12.CellAppearance = Appearance5
        UltraGridColumn12.Header.Caption = "Af. Stock"
        UltraGridColumn12.Header.VisiblePosition = 28
        UltraGridColumn12.Width = 57
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn13.Header.VisiblePosition = 21
        UltraGridColumn13.Hidden = True
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn14.Header.VisiblePosition = 22
        UltraGridColumn14.Hidden = True
        UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn15.Header.VisiblePosition = 23
        UltraGridColumn15.Hidden = True
        UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance6
        UltraGridColumn16.Header.VisiblePosition = 24
        UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn17.CellAppearance = Appearance7
        UltraGridColumn17.Header.VisiblePosition = 9
        UltraGridColumn17.Width = 42
        UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn18.Header.VisiblePosition = 25
        UltraGridColumn18.Hidden = True
        UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn19.Header.Caption = "Nombre SubRubro"
        UltraGridColumn19.Header.VisiblePosition = 7
        UltraGridColumn19.Hidden = True
        UltraGridColumn20.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance8
        UltraGridColumn20.Header.VisiblePosition = 26
        UltraGridColumn20.Width = 59
        UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance9
        UltraGridColumn21.Header.VisiblePosition = 27
        UltraGridColumn21.Width = 61
        UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn22.CellAppearance = Appearance10
        UltraGridColumn22.Header.Caption = "Es Servicio"
        UltraGridColumn22.Header.VisiblePosition = 29
        UltraGridColumn22.Width = 69
        UltraGridColumn27.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn27.CellAppearance = Appearance11
        UltraGridColumn27.Header.Caption = "Es Compras"
        UltraGridColumn27.Header.VisiblePosition = 30
        UltraGridColumn27.Width = 75
        UltraGridColumn29.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn29.CellAppearance = Appearance12
        UltraGridColumn29.Header.Caption = "Es Ventas"
        UltraGridColumn29.Header.VisiblePosition = 31
        UltraGridColumn29.Width = 65
        UltraGridColumn25.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance13.TextHAlignAsString = "Center"
        UltraGridColumn25.CellAppearance = Appearance13
        UltraGridColumn25.Header.Caption = "Paga IB"
        UltraGridColumn25.Header.VisiblePosition = 32
        UltraGridColumn25.Width = 55
        UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance14.TextHAlignAsString = "Center"
        UltraGridColumn24.CellAppearance = Appearance14
        UltraGridColumn24.Header.Caption = "Mod. Descrip"
        UltraGridColumn24.Header.VisiblePosition = 33
        UltraGridColumn24.Width = 82
        UltraGridColumn28.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn28.CellAppearance = Appearance15
        UltraGridColumn28.Header.Caption = "L. Prec. Client."
        UltraGridColumn28.Header.VisiblePosition = 34
        UltraGridColumn28.Width = 84
        UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance16
        UltraGridColumn23.Format = "N2"
        UltraGridColumn23.Header.Caption = "Precio Costo"
        UltraGridColumn23.Header.VisiblePosition = 11
        UltraGridColumn23.Width = 77
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance17
        UltraGridColumn30.Format = "N2"
        UltraGridColumn30.Header.Caption = "Precio Venta"
        UltraGridColumn30.Header.VisiblePosition = 12
        UltraGridColumn30.Width = 78
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn31.Header.Caption = "Moneda"
        UltraGridColumn31.Header.VisiblePosition = 10
        UltraGridColumn31.Width = 51
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn32.Header.Caption = "Codigo de Barras"
        UltraGridColumn32.Header.VisiblePosition = 36
        UltraGridColumn33.Header.VisiblePosition = 37
        UltraGridColumn33.Hidden = True
        UltraGridColumn34.Header.VisiblePosition = 38
        UltraGridColumn34.Hidden = True
        UltraGridColumn35.Header.Caption = "Codigo Web"
        UltraGridColumn35.Header.VisiblePosition = 39
        Appearance18.TextHAlignAsString = "Center"
        UltraGridColumn36.CellAppearance = Appearance18
        UltraGridColumn36.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn36.Header.Caption = "Actualizacion"
        UltraGridColumn36.Header.VisiblePosition = 13
        UltraGridColumn36.Width = 100
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance19.TextHAlignAsString = "Center"
        UltraGridColumn37.CellAppearance = Appearance19
        UltraGridColumn37.Header.VisiblePosition = 35
        UltraGridColumn37.Width = 88
        UltraGridColumn38.Header.VisiblePosition = 40
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.Header.Caption = "Nombre SubSubRubro"
        UltraGridColumn39.Header.VisiblePosition = 8
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.Header.VisiblePosition = 41
        UltraGridColumn40.Hidden = True
        UltraGridColumn41.Header.VisiblePosition = 42
        UltraGridColumn41.Hidden = True
        UltraGridColumn42.Header.VisiblePosition = 43
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.Header.Caption = "Valor Caract 1"
        UltraGridColumn43.Header.VisiblePosition = 44
        UltraGridColumn43.Hidden = True
        UltraGridColumn46.Header.Caption = "Valor Caract 2"
        UltraGridColumn46.Header.VisiblePosition = 45
        UltraGridColumn46.Hidden = True
        UltraGridColumn45.Header.Caption = "Valor Caract 3"
        UltraGridColumn45.Header.VisiblePosition = 46
        UltraGridColumn45.Hidden = True
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance20
        UltraGridColumn44.Header.VisiblePosition = 47
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn47.CellAppearance = Appearance21
        UltraGridColumn47.Header.VisiblePosition = 48
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance22
        UltraGridColumn48.Header.VisiblePosition = 49
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn49.Header.VisiblePosition = 50
        UltraGridColumn50.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn50.Header.VisiblePosition = 51
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn51.Header.VisiblePosition = 52
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn52.Header.VisiblePosition = 53
        UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn53.Header.VisiblePosition = 54
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn54.CellAppearance = Appearance23
        UltraGridColumn54.Header.Caption = "Código Mercosur"
        UltraGridColumn54.Header.VisiblePosition = 55
        UltraGridColumn55.Header.Caption = "Codigo  Producto Proveedor"
        UltraGridColumn55.Header.VisiblePosition = 56
        UltraGridColumn55.Width = 154
        UltraGridColumn56.Header.Caption = "Proveedor"
        UltraGridColumn56.Header.VisiblePosition = 57
        UltraGridColumn56.Width = 170
        UltraGridColumn58.Header.VisiblePosition = 58
        UltraGridColumn58.Hidden = True
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn57.CellAppearance = Appearance24
        UltraGridColumn57.Header.Caption = "Suc."
        UltraGridColumn57.Header.VisiblePosition = 1
        UltraGridColumn57.Hidden = True
        UltraGridColumn57.Width = 50
        Appearance25.TextHAlignAsString = "Center"
        UltraGridColumn26.CellAppearance = Appearance25
        UltraGridColumn26.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        UltraGridColumn26.DataType = GetType(Boolean)
        UltraGridColumn26.Header.Caption = ""
        UltraGridColumn26.Header.VisiblePosition = 0
        UltraGridColumn26.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn26.Width = 32
        UltraGridColumn59.Header.Caption = "Cód. Numérico"
        UltraGridColumn59.Header.VisiblePosition = 3
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn27, UltraGridColumn29, UltraGridColumn25, UltraGridColumn24, UltraGridColumn28, UltraGridColumn23, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn46, UltraGridColumn45, UltraGridColumn44, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn58, UltraGridColumn57, UltraGridColumn26, UltraGridColumn59})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna para agrupar"
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance35
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 283)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 252)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        Me.ugDetalle.UseAppStyling = False
        '
        'UltraDataSource1
        '
        UltraDataColumn149.DataType = GetType(Decimal)
        UltraDataColumn150.DataType = GetType(Decimal)
        UltraDataColumn151.DataType = GetType(Decimal)
        UltraDataColumn152.DataType = GetType(Boolean)
        UltraDataColumn153.DataType = GetType(Boolean)
        UltraDataColumn154.DataType = GetType(Boolean)
        UltraDataColumn155.DataType = GetType(Boolean)
        UltraDataColumn156.DataType = GetType(Boolean)
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn105, UltraDataColumn106, UltraDataColumn107, UltraDataColumn108, UltraDataColumn109, UltraDataColumn110, UltraDataColumn111, UltraDataColumn112, UltraDataColumn113, UltraDataColumn114, UltraDataColumn115, UltraDataColumn116, UltraDataColumn117, UltraDataColumn118, UltraDataColumn119, UltraDataColumn120, UltraDataColumn121, UltraDataColumn122, UltraDataColumn123, UltraDataColumn124, UltraDataColumn125, UltraDataColumn126, UltraDataColumn127, UltraDataColumn128, UltraDataColumn129, UltraDataColumn130, UltraDataColumn131, UltraDataColumn132, UltraDataColumn133, UltraDataColumn134, UltraDataColumn135, UltraDataColumn136, UltraDataColumn137, UltraDataColumn138, UltraDataColumn139, UltraDataColumn140, UltraDataColumn141, UltraDataColumn142, UltraDataColumn143, UltraDataColumn144, UltraDataColumn145, UltraDataColumn146, UltraDataColumn147, UltraDataColumn148, UltraDataColumn149, UltraDataColumn150, UltraDataColumn151, UltraDataColumn152, UltraDataColumn153, UltraDataColumn154, UltraDataColumn155, UltraDataColumn156})
        Me.UltraDataSource1.Band.Key = "Productos"
        '
        'ProductosBindingSource
        '
        Me.ProductosBindingSource.DataMember = "Productos"
        Me.ProductosBindingSource.DataSource = Me.SistemaDataSet
        '
        'SistemaDataSet
        '
        Me.SistemaDataSet.DataSetName = "SistemaDataSet"
        Me.SistemaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtArchivoDestino
        '
        Me.txtArchivoDestino.BindearPropiedadControl = ""
        Me.txtArchivoDestino.BindearPropiedadEntidad = ""
        Me.txtArchivoDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoDestino.Formato = ""
        Me.txtArchivoDestino.IsDecimal = False
        Me.txtArchivoDestino.IsNumber = False
        Me.txtArchivoDestino.IsPK = False
        Me.txtArchivoDestino.IsRequired = False
        Me.txtArchivoDestino.Key = ""
        Me.txtArchivoDestino.LabelAsoc = Me.lblArchivoDestino
        Me.txtArchivoDestino.Location = New System.Drawing.Point(238, 5)
        Me.txtArchivoDestino.Name = "txtArchivoDestino"
        Me.txtArchivoDestino.Size = New System.Drawing.Size(556, 20)
        Me.txtArchivoDestino.TabIndex = 2
        '
        'lblArchivoDestino
        '
        Me.lblArchivoDestino.AutoSize = True
        Me.lblArchivoDestino.LabelAsoc = Nothing
        Me.lblArchivoDestino.Location = New System.Drawing.Point(147, 9)
        Me.lblArchivoDestino.Name = "lblArchivoDestino"
        Me.lblArchivoDestino.Size = New System.Drawing.Size(85, 13)
        Me.lblArchivoDestino.TabIndex = 1
        Me.lblArchivoDestino.Text = "Archivo Destino:"
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_16
        Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar.Location = New System.Drawing.Point(805, 0)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(98, 30)
        Me.btnExaminar.TabIndex = 3
        Me.btnExaminar.Text = "&Examinar..."
        Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'FiltersManager1
        '
        Me.FiltersManager1.BotonRefrescar = Me.tsbRefrescar
        Me.FiltersManager1.PanelFiltro = Me.gbFiltros
        '
        'pnlDestino
        '
        Me.pnlDestino.AutoSize = True
        Me.pnlDestino.Controls.Add(Me.btnExaminar)
        Me.pnlDestino.Controls.Add(Me.txtArchivoDestino)
        Me.pnlDestino.Controls.Add(Me.lblArchivoDestino)
        Me.pnlDestino.Controls.Add(Me.chbTodos)
        Me.pnlDestino.Controls.Add(Me.bscCodigoMarca)
        Me.pnlDestino.Controls.Add(Me.bscCodigoRubro)
        Me.pnlDestino.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDestino.Location = New System.Drawing.Point(0, 535)
        Me.pnlDestino.Name = "pnlDestino"
        Me.pnlDestino.Size = New System.Drawing.Size(984, 33)
        Me.pnlDestino.TabIndex = 2
        '
        'cmbTipoInforme
        '
        Me.cmbTipoInforme.BindearPropiedadControl = Nothing
        Me.cmbTipoInforme.BindearPropiedadEntidad = Nothing
        Me.cmbTipoInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoInforme.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoInforme.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoInforme.FormattingEnabled = True
        Me.cmbTipoInforme.IsPK = False
        Me.cmbTipoInforme.IsRequired = False
        Me.cmbTipoInforme.Key = Nothing
        Me.cmbTipoInforme.LabelAsoc = Me.lblTipoInforme
        Me.cmbTipoInforme.Location = New System.Drawing.Point(654, 227)
        Me.cmbTipoInforme.Name = "cmbTipoInforme"
        Me.cmbTipoInforme.Size = New System.Drawing.Size(176, 21)
        Me.cmbTipoInforme.TabIndex = 55
        '
        'lblTipoInforme
        '
        Me.lblTipoInforme.AutoSize = True
        Me.lblTipoInforme.LabelAsoc = Nothing
        Me.lblTipoInforme.Location = New System.Drawing.Point(574, 231)
        Me.lblTipoInforme.Name = "lblTipoInforme"
        Me.lblTipoInforme.Size = New System.Drawing.Size(69, 13)
        Me.lblTipoInforme.TabIndex = 54
        Me.lblTipoInforme.Text = "Tipo Informe:"
        '
        'ExportarProductosWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 590)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.pnlDestino)
        Me.Controls.Add(Me.gbFiltros)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "ExportarProductosWeb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Productos"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.grpPublicarEn.ResumeLayout(False)
        Me.grpPublicarEn.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SistemaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDestino.ResumeLayout(False)
        Me.pnlDestino.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents lnkFiltroMultiplesRubros As System.Windows.Forms.LinkLabel
   Friend WithEvents lnkFiltroMultiplesMarcas As System.Windows.Forms.LinkLabel
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents txtProducto As Eniac.Controles.TextBox
   Friend WithEvents bscCodigoMarca As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoRubro As Eniac.Controles.Buscador
   Friend WithEvents cmbAfectaStock As Eniac.Controles.ComboBox
   Friend WithEvents lblAfectaStock As Eniac.Controles.Label
   Friend WithEvents cmbActivo As Eniac.Controles.ComboBox
   Friend WithEvents lblActivo As Eniac.Controles.Label
   Friend WithEvents lblEmbalaje As Eniac.Controles.Label
   Friend WithEvents txtEmbalaje As Eniac.Controles.TextBox
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblEsServicio As Eniac.Controles.Label
   Friend WithEvents lblPagaIngBrutos As Eniac.Controles.Label
   Friend WithEvents lblEsDeCompras As Eniac.Controles.Label
   Friend WithEvents lblEsDeVentas As Eniac.Controles.Label
   Friend WithEvents lblPermiteModDesc As Eniac.Controles.Label
   Friend WithEvents cmbPermiteModDesc As Eniac.Controles.ComboBox
   Friend WithEvents cmbPagaIngBrutos As Eniac.Controles.ComboBox
   Friend WithEvents cmbEsDeVentas As Eniac.Controles.ComboBox
   Friend WithEvents cmbEsDeCompras As Eniac.Controles.ComboBox
   Friend WithEvents cmbEsServicio As Eniac.Controles.ComboBox
   Friend WithEvents lblPublicarEnListaDePreciosParaClientes As Eniac.Controles.Label
   Friend WithEvents cmbPublicarEnListaDePreciosParaClientes As Eniac.Controles.ComboBox
   Friend WithEvents cmbSubRubro As Eniac.Controles.ComboBox
   Friend WithEvents chbSubRubro As Eniac.Controles.CheckBox
   Friend WithEvents gbFiltros As Eniac.Controles.GroupBox
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents ProductosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents SistemaDataSet As Eniac.Win.SistemaDataSet
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtArchivoDestino As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoDestino As Eniac.Controles.Label
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Friend WithEvents cmbListaPrecios As Eniac.Controles.ComboBox
   Friend WithEvents cmbFormato As Eniac.Controles.ComboBox
   Friend WithEvents lblFormato As Eniac.Controles.Label
   Friend WithEvents lblListaPrecios As Eniac.Controles.Label
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents lblMoneda As Eniac.Controles.Label
   Friend WithEvents cmbMoneda As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoCambio As Eniac.Controles.Label
   Friend WithEvents txtTipoCambio As Eniac.Controles.TextBox
   Friend WithEvents chbFechaActualizado As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents cmbPublicarEnWeb As Eniac.Controles.ComboBox
   Friend WithEvents lblPublicarEnWeb As Eniac.Controles.Label
   Friend WithEvents tsbSubirArchivosALaWeb As System.Windows.Forms.ToolStripButton
   Friend WithEvents lnkFiltroMultiplesSubRubros As System.Windows.Forms.LinkLabel
   Friend WithEvents lnkFiltroMultiplesSubSubRubros As System.Windows.Forms.LinkLabel
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents chbConIVA As Eniac.Controles.CheckBox
   Friend WithEvents lblRedondeoDecimales2 As Eniac.Controles.Label
   Friend WithEvents lblRedondeoDecimales As Eniac.Controles.Label
   Friend WithEvents txtRedondeoDecimales As Eniac.Controles.TextBox
   Friend WithEvents dtpEnviando As Eniac.Controles.DateTimePicker
   Friend WithEvents lblEnviando As Eniac.Controles.Label
   Friend WithEvents cmbEnviando As Eniac.Controles.ComboBox
   Friend WithEvents lblSubirImagenes As Eniac.Controles.Label
   Friend WithEvents cmbSubirImagenes As Eniac.Controles.ComboBox
   Friend WithEvents grpPublicarEn As Eniac.Controles.GroupBox
   Friend WithEvents cmbPublicarEnEmpresarial As Eniac.Controles.ComboBox
   Friend WithEvents cmbPublicarEnGestion As Eniac.Controles.ComboBox
   Friend WithEvents lblPublicarEnEmpresarial As Eniac.Controles.Label
   Friend WithEvents cmbPublicarEnSincronizarSucursal As Eniac.Controles.ComboBox
   Friend WithEvents lblPublicarEnSincronizacionSucursal As Eniac.Controles.Label
   Friend WithEvents cmbPublicarEnBalanza As Eniac.Controles.ComboBox
   Friend WithEvents lblPublicarEnBalanza As Eniac.Controles.Label
   Friend WithEvents lblPublicarEnGestion As Eniac.Controles.Label
   Friend WithEvents tsbFiltros As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents FiltersManager1 As Eniac.Win.FilterManager.FilterManager
    Friend WithEvents lblSucursal As Controles.Label
    Friend WithEvents cmbSucursal As Controles.ComboBox
    Friend WithEvents lblListaPreciosMayorista As Controles.Label
    Friend WithEvents cmbListaPreciosMayorista As Controles.ComboBox
    Friend WithEvents cmbPublicarEnMercadoLibre As Controles.ComboBox
    Friend WithEvents lblPublicarEnMercadoLibre As Controles.Label
    Friend WithEvents cmbPublicarEnTiendaNube As Controles.ComboBox
    Friend WithEvents lblPublicarEnTiendaNube As Controles.Label
    Friend WithEvents cmbPublicarEnArborea As Controles.ComboBox
    Friend WithEvents lblPublicarEnArborea As Controles.Label
    Friend WithEvents pnlDestino As Panel
    Friend WithEvents cmbTipoInforme As Controles.ComboBox
    Friend WithEvents lblTipoInforme As Controles.Label
End Class
