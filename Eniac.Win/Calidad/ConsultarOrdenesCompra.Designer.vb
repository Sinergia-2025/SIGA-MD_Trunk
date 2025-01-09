<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultarOrdenesCompra
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim UltraDataBand1 As Infragistics.Win.UltraWinDataSource.UltraDataBand = New Infragistics.Win.UltraWinDataSource.UltraDataBand("Detalle")
      Dim UltraDataBand2 As Infragistics.Win.UltraWinDataSource.UltraDataBand = New Infragistics.Win.UltraWinDataSource.UltraDataBand("Comprobante")
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCaja")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroPlanilla")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroMovimiento")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImportePesos")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotal")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdPedido")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaPedido")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocumento")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocumento")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProveedor")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("idProducto")
      Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Tamano")
      Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
      Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("fechaEstado")
      Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("idEstado")
      Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantEstado")
      Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CantPendiente")
      Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
      Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
      Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
      Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
      Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdUsuario")
      Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
      Dim UltraDataColumn28 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Imprimir")
      Dim UltraDataColumn29 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdCriticidad")
      Dim UltraDataColumn30 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaEntrega")
      Dim UltraDataColumn31 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdSucursal")
      Dim UltraDataColumn32 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdPedido")
      Dim UltraDataColumn33 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FechaPedido")
      Dim UltraDataColumn34 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocumento")
      Dim UltraDataColumn35 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescripcionAbrev")
      Dim UltraDataColumn36 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocumento")
      Dim UltraDataColumn37 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProveedor")
      Dim UltraDataColumn38 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdPeriodo")
      Dim UltraDataColumn39 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Observacion")
      Dim UltraDataColumn40 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultarOrdenesCompra))
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Cabecera", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionAbrev")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcPendiente")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcPendienteImporte")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaReprogEntrega")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAutorizacion")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("acti")
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestos")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteBruto")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaReprogramacion")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Detalle")
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadContactos", 0)
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("VerCabecera", 1)
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dif", 2)
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dif1", 3)
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dif2", 4)
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePendiente", 5)
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("ImporteTotal", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "ImporteTotal", 13, True, "Cabecera", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "ImporteTotal", 13, True)
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Detalle", 0)
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocumento")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idProducto", -1, Nothing, 7796266, 2, 0)
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto", -1, Nothing, 7796266, 3, 0)
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano", -1, Nothing, 7796266, 4, 0)
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida", -1, Nothing, 7796266, 5, 0)
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad", -1, Nothing, 7796266, 6, 0)
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("fechaEstado", -1, Nothing, 7796266, 10, 0)
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado", -1, Nothing, 7796266, 9, 0)
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEstado", -1, Nothing, 7796266, 12, 0)
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantPendiente", -1, Nothing, 7796266, 11, 0)
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteFact", -1, Nothing, 7796282, 0, 0)
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraFact", -1, Nothing, 7796282, 1, 0)
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorFact", -1, Nothing, 7796282, 2, 0)
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteFact", -1, Nothing, 7796282, 3, 0)
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imprimir")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCriticidad", -1, Nothing, 7796266, 14, 0)
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega", -1, Nothing, 7796266, 15, 0)
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios", -1, Nothing, 7796266, 13, 0)
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursalRemito")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteRemito", -1, Nothing, 7796283, 0, 0)
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraRemito", -1, Nothing, 7796283, 1, 0)
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorRemito", -1, Nothing, 7796283, 2, 0)
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteRemito", -1, Nothing, 7796283, 3, 0)
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoProducto", -1, Nothing, 7796266, 16, 0)
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCantidad", -1, Nothing, 7796266, 18, 0)
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoPrecio", -1, Nothing, 7796266, 20, 0)
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoFechaEntrega", -1, Nothing, 7796266, 22, 0)
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstadoProducto", -1, Nothing, 7796266, 17, 0)
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstadoCantidad", -1, Nothing, 7796266, 19, 0)
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstadoPrecio", -1, Nothing, 7796266, 21, 0)
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstadoFechaEntrega", -1, Nothing, 7796266, 23, 0)
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Costo", -1, Nothing, 7796266, 7, 0)
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("acti", -1, Nothing, 7796266, 1, 0)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CostoConImpuestos", -1, Nothing, 7796266, 8, 0)
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ver", 0, Nothing, 7796266, 0, 0)
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridGroup1 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Detalle", 7796266)
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridGroup2 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Factura", 7796282)
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridGroup3 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Remitió", 7796283)
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
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.grbConsultar = New System.Windows.Forms.GroupBox()
        Me.dtpFechaAutorizacionHasta = New Eniac.Controles.DateTimePicker()
        Me.Label14 = New Eniac.Controles.Label()
        Me.dtpFechaAutorizacionDesde = New Eniac.Controles.DateTimePicker()
        Me.Label15 = New Eniac.Controles.Label()
        Me.chbFechaAutorizacion = New Eniac.Controles.CheckBox()
        Me.txtMaxRango = New Eniac.Controles.TextBox()
        Me.txtMinRango = New Eniac.Controles.TextBox()
        Me.chbIdPedido = New Eniac.Controles.CheckBox()
        Me.txtIdPedido = New Eniac.Controles.TextBox()
        Me.chbRangoImporte = New Eniac.Controles.CheckBox()
        Me.dtpFechaEntregaHasta = New Eniac.Controles.DateTimePicker()
        Me.Label2 = New Eniac.Controles.Label()
        Me.dtpFechaEntregaDesde = New Eniac.Controles.DateTimePicker()
        Me.Label3 = New Eniac.Controles.Label()
        Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbActivadas = New Eniac.Controles.ComboBox()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTipoComprobante = New Eniac.Controles.Label()
        Me.chbOrdenCompra = New Eniac.Controles.CheckBox()
        Me.txtOrdenCompra = New Eniac.Controles.TextBox()
        Me.chbComprador = New Eniac.Controles.CheckBox()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.cmbEstados = New Eniac.Controles.ComboBox()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.lblCodigoProveedor = New Eniac.Controles.Label()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.Label4 = New Eniac.Controles.Label()
        Me.Label5 = New Eniac.Controles.Label()
        Me.cmbComprador = New Eniac.Controles.ComboBox()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New Eniac.Controles.Label()
        Me.txtPorcImpPendiente = New Eniac.Controles.TextBox()
        Me.Label12 = New Eniac.Controles.Label()
        Me.Label11 = New Eniac.Controles.Label()
        Me.Label10 = New Eniac.Controles.Label()
        Me.Label9 = New Eniac.Controles.Label()
        Me.Label8 = New Eniac.Controles.Label()
        Me.Label7 = New Eniac.Controles.Label()
        Me.chbDiferenciasFechas = New Eniac.Controles.CheckBox()
        Me.txtFechaEnt = New System.Windows.Forms.TextBox()
        Me.txtTotal = New Eniac.Controles.TextBox()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.txtCodProv = New System.Windows.Forms.TextBox()
        Me.txtFechaE = New System.Windows.Forms.TextBox()
        Me.txtOC = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.Label6 = New Eniac.Controles.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.chbOcultarFiltros = New Eniac.Controles.CheckBox()
        Me.stsStado.SuspendLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbConsultar.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1016, 17)
        Me.tssInfo.Spring = True
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1095, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'UltraDataSource1
        '
        UltraDataBand2.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7})
        UltraDataBand1.ChildBands.AddRange(New Object() {UltraDataBand2})
        UltraDataColumn30.DataType = GetType(Date)
        UltraDataBand1.Columns.AddRange(New Object() {UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27, UltraDataColumn28, UltraDataColumn29, UltraDataColumn30})
        Me.UltraDataSource1.Band.ChildBands.AddRange(New Object() {UltraDataBand1})
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn31, UltraDataColumn32, UltraDataColumn33, UltraDataColumn34, UltraDataColumn35, UltraDataColumn36, UltraDataColumn37, UltraDataColumn38, UltraDataColumn39, UltraDataColumn40})
        Me.UltraDataSource1.Band.Key = "Cabecera"
        '
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.dtpFechaAutorizacionHasta)
        Me.grbConsultar.Controls.Add(Me.dtpFechaAutorizacionDesde)
        Me.grbConsultar.Controls.Add(Me.Label14)
        Me.grbConsultar.Controls.Add(Me.Label15)
        Me.grbConsultar.Controls.Add(Me.chbFechaAutorizacion)
        Me.grbConsultar.Controls.Add(Me.txtMaxRango)
        Me.grbConsultar.Controls.Add(Me.txtMinRango)
        Me.grbConsultar.Controls.Add(Me.chbIdPedido)
        Me.grbConsultar.Controls.Add(Me.txtIdPedido)
        Me.grbConsultar.Controls.Add(Me.chbRangoImporte)
        Me.grbConsultar.Controls.Add(Me.dtpFechaEntregaHasta)
        Me.grbConsultar.Controls.Add(Me.dtpFechaEntregaDesde)
        Me.grbConsultar.Controls.Add(Me.Label2)
        Me.grbConsultar.Controls.Add(Me.Label3)
        Me.grbConsultar.Controls.Add(Me.chbFechaEntrega)
        Me.grbConsultar.Controls.Add(Me.Label1)
        Me.grbConsultar.Controls.Add(Me.cmbActivadas)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.chbOrdenCompra)
        Me.grbConsultar.Controls.Add(Me.txtOrdenCompra)
        Me.grbConsultar.Controls.Add(Me.chbComprador)
        Me.grbConsultar.Controls.Add(Me.chbFecha)
        Me.grbConsultar.Controls.Add(Me.lblEstado)
        Me.grbConsultar.Controls.Add(Me.cmbEstados)
        Me.grbConsultar.Controls.Add(Me.chkExpandAll)
        Me.grbConsultar.Controls.Add(Me.chbUsuario)
        Me.grbConsultar.Controls.Add(Me.cmbUsuario)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.bscProveedor)
        Me.grbConsultar.Controls.Add(Me.lblCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.lblNombre)
        Me.grbConsultar.Controls.Add(Me.chbProveedor)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Controls.Add(Me.Label4)
        Me.grbConsultar.Controls.Add(Me.Label5)
        Me.grbConsultar.Controls.Add(Me.cmbComprador)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbConsultar.Location = New System.Drawing.Point(0, 0)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(1071, 148)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'dtpFechaAutorizacionHasta
        '
        Me.dtpFechaAutorizacionHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaAutorizacionHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAutorizacionHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaAutorizacionHasta.Enabled = False
        Me.dtpFechaAutorizacionHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAutorizacionHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAutorizacionHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaAutorizacionHasta.IsPK = False
        Me.dtpFechaAutorizacionHasta.IsRequired = False
        Me.dtpFechaAutorizacionHasta.Key = ""
        Me.dtpFechaAutorizacionHasta.LabelAsoc = Me.Label14
        Me.dtpFechaAutorizacionHasta.Location = New System.Drawing.Point(332, 118)
        Me.dtpFechaAutorizacionHasta.Name = "dtpFechaAutorizacionHasta"
        Me.dtpFechaAutorizacionHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpFechaAutorizacionHasta.TabIndex = 50
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.LabelAsoc = Nothing
        Me.Label14.Location = New System.Drawing.Point(291, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 13)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Hasta"
        '
        'dtpFechaAutorizacionDesde
        '
        Me.dtpFechaAutorizacionDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaAutorizacionDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAutorizacionDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaAutorizacionDesde.Enabled = False
        Me.dtpFechaAutorizacionDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAutorizacionDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAutorizacionDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaAutorizacionDesde.IsPK = False
        Me.dtpFechaAutorizacionDesde.IsRequired = False
        Me.dtpFechaAutorizacionDesde.Key = ""
        Me.dtpFechaAutorizacionDesde.LabelAsoc = Me.Label15
        Me.dtpFechaAutorizacionDesde.Location = New System.Drawing.Point(160, 118)
        Me.dtpFechaAutorizacionDesde.Name = "dtpFechaAutorizacionDesde"
        Me.dtpFechaAutorizacionDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpFechaAutorizacionDesde.TabIndex = 48
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.LabelAsoc = Nothing
        Me.Label15.Location = New System.Drawing.Point(123, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Desde"
        '
        'chbFechaAutorizacion
        '
        Me.chbFechaAutorizacion.AutoSize = True
        Me.chbFechaAutorizacion.BindearPropiedadControl = Nothing
        Me.chbFechaAutorizacion.BindearPropiedadEntidad = Nothing
        Me.chbFechaAutorizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaAutorizacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaAutorizacion.IsPK = False
        Me.chbFechaAutorizacion.IsRequired = False
        Me.chbFechaAutorizacion.Key = Nothing
        Me.chbFechaAutorizacion.LabelAsoc = Nothing
        Me.chbFechaAutorizacion.Location = New System.Drawing.Point(13, 121)
        Me.chbFechaAutorizacion.Name = "chbFechaAutorizacion"
        Me.chbFechaAutorizacion.Size = New System.Drawing.Size(117, 17)
        Me.chbFechaAutorizacion.TabIndex = 46
        Me.chbFechaAutorizacion.Text = "Fecha Autorización"
        Me.chbFechaAutorizacion.UseVisualStyleBackColor = True
        '
        'txtMaxRango
        '
        Me.txtMaxRango.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaxRango.BindearPropiedadControl = Nothing
        Me.txtMaxRango.BindearPropiedadEntidad = Nothing
        Me.txtMaxRango.Enabled = False
        Me.txtMaxRango.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMaxRango.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMaxRango.Formato = "N2"
        Me.txtMaxRango.IsDecimal = True
        Me.txtMaxRango.IsNumber = True
        Me.txtMaxRango.IsPK = False
        Me.txtMaxRango.IsRequired = False
        Me.txtMaxRango.Key = ""
        Me.txtMaxRango.LabelAsoc = Nothing
        Me.txtMaxRango.Location = New System.Drawing.Point(741, 91)
        Me.txtMaxRango.MaxLength = 8
        Me.txtMaxRango.Name = "txtMaxRango"
        Me.txtMaxRango.Size = New System.Drawing.Size(81, 20)
        Me.txtMaxRango.TabIndex = 45
        Me.txtMaxRango.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinRango
        '
        Me.txtMinRango.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinRango.BindearPropiedadControl = Nothing
        Me.txtMinRango.BindearPropiedadEntidad = Nothing
        Me.txtMinRango.Enabled = False
        Me.txtMinRango.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMinRango.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMinRango.Formato = "N2"
        Me.txtMinRango.IsDecimal = True
        Me.txtMinRango.IsNumber = True
        Me.txtMinRango.IsPK = False
        Me.txtMinRango.IsRequired = False
        Me.txtMinRango.Key = ""
        Me.txtMinRango.LabelAsoc = Nothing
        Me.txtMinRango.Location = New System.Drawing.Point(617, 90)
        Me.txtMinRango.MaxLength = 8
        Me.txtMinRango.Name = "txtMinRango"
        Me.txtMinRango.Size = New System.Drawing.Size(81, 20)
        Me.txtMinRango.TabIndex = 44
        Me.txtMinRango.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.chbIdPedido.Location = New System.Drawing.Point(693, 57)
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
        Me.txtIdPedido.Location = New System.Drawing.Point(760, 55)
        Me.txtIdPedido.MaxLength = 8
        Me.txtIdPedido.Name = "txtIdPedido"
        Me.txtIdPedido.Size = New System.Drawing.Size(65, 20)
        Me.txtIdPedido.TabIndex = 11
        Me.txtIdPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbRangoImporte
        '
        Me.chbRangoImporte.AutoSize = True
        Me.chbRangoImporte.BindearPropiedadControl = Nothing
        Me.chbRangoImporte.BindearPropiedadEntidad = Nothing
        Me.chbRangoImporte.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRangoImporte.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRangoImporte.IsPK = False
        Me.chbRangoImporte.IsRequired = False
        Me.chbRangoImporte.Key = Nothing
        Me.chbRangoImporte.LabelAsoc = Nothing
        Me.chbRangoImporte.Location = New System.Drawing.Point(477, 94)
        Me.chbRangoImporte.Name = "chbRangoImporte"
        Me.chbRangoImporte.Size = New System.Drawing.Size(96, 17)
        Me.chbRangoImporte.TabIndex = 32
        Me.chbRangoImporte.Text = "Rango Importe"
        Me.chbRangoImporte.UseVisualStyleBackColor = True
        '
        'dtpFechaEntregaHasta
        '
        Me.dtpFechaEntregaHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaEntregaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntregaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaEntregaHasta.Enabled = False
        Me.dtpFechaEntregaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntregaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntregaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntregaHasta.IsPK = False
        Me.dtpFechaEntregaHasta.IsRequired = False
        Me.dtpFechaEntregaHasta.Key = ""
        Me.dtpFechaEntregaHasta.LabelAsoc = Me.Label2
        Me.dtpFechaEntregaHasta.Location = New System.Drawing.Point(332, 92)
        Me.dtpFechaEntregaHasta.Name = "dtpFechaEntregaHasta"
        Me.dtpFechaEntregaHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpFechaEntregaHasta.TabIndex = 31
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(291, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Hasta"
        '
        'dtpFechaEntregaDesde
        '
        Me.dtpFechaEntregaDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaEntregaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntregaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaEntregaDesde.Enabled = False
        Me.dtpFechaEntregaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntregaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntregaDesde.IsPK = False
        Me.dtpFechaEntregaDesde.IsRequired = False
        Me.dtpFechaEntregaDesde.Key = ""
        Me.dtpFechaEntregaDesde.LabelAsoc = Me.Label3
        Me.dtpFechaEntregaDesde.Location = New System.Drawing.Point(160, 92)
        Me.dtpFechaEntregaDesde.Name = "dtpFechaEntregaDesde"
        Me.dtpFechaEntregaDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpFechaEntregaDesde.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(123, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Desde"
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
        Me.chbFechaEntrega.Location = New System.Drawing.Point(13, 95)
        Me.chbFechaEntrega.Name = "chbFechaEntrega"
        Me.chbFechaEntrega.Size = New System.Drawing.Size(96, 17)
        Me.chbFechaEntrega.TabIndex = 27
        Me.chbFechaEntrega.Text = "Fecha Entrega"
        Me.chbFechaEntrega.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(10, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Activadas"
        '
        'cmbActivadas
        '
        Me.cmbActivadas.BindearPropiedadControl = ""
        Me.cmbActivadas.BindearPropiedadEntidad = ""
        Me.cmbActivadas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActivadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActivadas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActivadas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActivadas.FormattingEnabled = True
        Me.cmbActivadas.IsPK = False
        Me.cmbActivadas.IsRequired = False
        Me.cmbActivadas.Items.AddRange(New Object() {"SI", "NO", "TODAS"})
        Me.cmbActivadas.Key = Nothing
        Me.cmbActivadas.LabelAsoc = Me.Label1
        Me.cmbActivadas.Location = New System.Drawing.Point(85, 54)
        Me.cmbActivadas.Name = "cmbActivadas"
        Me.cmbActivadas.Size = New System.Drawing.Size(93, 21)
        Me.cmbActivadas.TabIndex = 26
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
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(820, 20)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(140, 21)
        Me.cmbTiposComprobantes.TabIndex = 9
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(738, 23)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(76, 13)
        Me.lblTipoComprobante.TabIndex = 8
        Me.lblTipoComprobante.Text = "Tipo Comprob."
        '
        'chbOrdenCompra
        '
        Me.chbOrdenCompra.AutoSize = True
        Me.chbOrdenCompra.BindearPropiedadControl = Nothing
        Me.chbOrdenCompra.BindearPropiedadEntidad = Nothing
        Me.chbOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOrdenCompra.IsPK = False
        Me.chbOrdenCompra.IsRequired = False
        Me.chbOrdenCompra.Key = Nothing
        Me.chbOrdenCompra.LabelAsoc = Nothing
        Me.chbOrdenCompra.Location = New System.Drawing.Point(15, 100)
        Me.chbOrdenCompra.Name = "chbOrdenCompra"
        Me.chbOrdenCompra.Size = New System.Drawing.Size(109, 17)
        Me.chbOrdenCompra.TabIndex = 21
        Me.chbOrdenCompra.Text = "Orden de Compra"
        Me.chbOrdenCompra.UseVisualStyleBackColor = True
        Me.chbOrdenCompra.Visible = False
        '
        'txtOrdenCompra
        '
        Me.txtOrdenCompra.BackColor = System.Drawing.SystemColors.Window
        Me.txtOrdenCompra.BindearPropiedadControl = Nothing
        Me.txtOrdenCompra.BindearPropiedadEntidad = Nothing
        Me.txtOrdenCompra.Enabled = False
        Me.txtOrdenCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenCompra.Formato = ""
        Me.txtOrdenCompra.IsDecimal = False
        Me.txtOrdenCompra.IsNumber = True
        Me.txtOrdenCompra.IsPK = False
        Me.txtOrdenCompra.IsRequired = False
        Me.txtOrdenCompra.Key = ""
        Me.txtOrdenCompra.LabelAsoc = Nothing
        Me.txtOrdenCompra.Location = New System.Drawing.Point(131, 97)
        Me.txtOrdenCompra.MaxLength = 6
        Me.txtOrdenCompra.Name = "txtOrdenCompra"
        Me.txtOrdenCompra.Size = New System.Drawing.Size(90, 20)
        Me.txtOrdenCompra.TabIndex = 22
        Me.txtOrdenCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtOrdenCompra.Visible = False
        '
        'chbComprador
        '
        Me.chbComprador.AutoSize = True
        Me.chbComprador.BindearPropiedadControl = Nothing
        Me.chbComprador.BindearPropiedadEntidad = Nothing
        Me.chbComprador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprador.IsPK = False
        Me.chbComprador.IsRequired = False
        Me.chbComprador.Key = Nothing
        Me.chbComprador.LabelAsoc = Nothing
        Me.chbComprador.Location = New System.Drawing.Point(686, 57)
        Me.chbComprador.Name = "chbComprador"
        Me.chbComprador.Size = New System.Drawing.Size(77, 17)
        Me.chbComprador.TabIndex = 17
        Me.chbComprador.Text = "Comprador"
        Me.chbComprador.UseVisualStyleBackColor = True
        Me.chbComprador.Visible = False
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
        Me.chbFecha.Location = New System.Drawing.Point(260, 22)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 2
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(4, 26)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(80, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Estado Artículo"
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
        Me.cmbEstados.Location = New System.Drawing.Point(85, 22)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(169, 21)
        Me.cmbEstados.TabIndex = 1
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(949, 124)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 24
        Me.chkExpandAll.Text = "Expandir Grupos"
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
        Me.chbUsuario.Location = New System.Drawing.Point(476, 121)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 19
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        Me.chbUsuario.Visible = False
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
        Me.cmbUsuario.Location = New System.Drawing.Point(544, 119)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(140, 21)
        Me.cmbUsuario.TabIndex = 20
        Me.cmbUsuario.Visible = False
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(946, 72)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(104, 45)
        Me.btnConsultar.TabIndex = 23
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
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
        Me.bscCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(336, 57)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 13
        Me.bscCodigoProveedor.Titulo = Nothing
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(333, 41)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 14
        Me.lblCodigoProveedor.Text = "Código"
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
        Me.bscProveedor.LabelAsoc = Me.lblNombre
        Me.bscProveedor.Location = New System.Drawing.Point(433, 57)
        Me.bscProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Size = New System.Drawing.Size(242, 23)
        Me.bscProveedor.TabIndex = 16
        Me.bscProveedor.Titulo = Nothing
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(430, 41)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Nombre"
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
        Me.chbProveedor.Location = New System.Drawing.Point(261, 59)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 12
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(322, 23)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompleto.TabIndex = 3
        Me.chkMesCompleto.Text = "Mes C."
        Me.chkMesCompleto.UseVisualStyleBackColor = True
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
        Me.dtpHasta.Location = New System.Drawing.Point(603, 20)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 7
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(562, 24)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 6
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
        Me.dtpDesde.Location = New System.Drawing.Point(425, 20)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 5
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(381, 24)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 4
        Me.lblDesde.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(574, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Mínimo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(700, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Máximo"
        '
        'cmbComprador
        '
        Me.cmbComprador.BindearPropiedadControl = Nothing
        Me.cmbComprador.BindearPropiedadEntidad = Nothing
        Me.cmbComprador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprador.Enabled = False
        Me.cmbComprador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbComprador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbComprador.FormattingEnabled = True
        Me.cmbComprador.IsPK = False
        Me.cmbComprador.IsRequired = False
        Me.cmbComprador.Key = Nothing
        Me.cmbComprador.LabelAsoc = Nothing
        Me.cmbComprador.Location = New System.Drawing.Point(762, 55)
        Me.cmbComprador.Name = "cmbComprador"
        Me.cmbComprador.Size = New System.Drawing.Size(140, 21)
        Me.cmbComprador.TabIndex = 18
        Me.cmbComprador.Visible = False
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'UltraGridExcelExporter1
        '
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1095, 29)
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'ugDetalle
        '
        Appearance2.BackColor = System.Drawing.SystemColors.Window
        Appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance2
        UltraGridColumn1.Header.Caption = "Sucursal"
        UltraGridColumn1.Header.VisiblePosition = 2
        UltraGridColumn1.Hidden = True
        UltraGridColumn4.Header.Caption = "Tipo"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 70
        UltraGridColumn61.Header.Caption = "Tipo"
        UltraGridColumn61.Header.VisiblePosition = 4
        UltraGridColumn61.Width = 45
        UltraGridColumn5.Header.Caption = "L."
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Hidden = True
        UltraGridColumn5.Width = 25
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance3
        UltraGridColumn44.Header.Caption = "Emisor"
        UltraGridColumn44.Header.VisiblePosition = 6
        UltraGridColumn44.Hidden = True
        UltraGridColumn44.Width = 50
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance4
        UltraGridColumn45.Header.Caption = "Orden Compra"
        UltraGridColumn45.Header.VisiblePosition = 7
        UltraGridColumn45.Width = 51
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance5
        UltraGridColumn3.Format = "dd/MM/yyyy"
        UltraGridColumn3.Header.Caption = "Fecha Emisión (FEmi)"
        UltraGridColumn3.Header.VisiblePosition = 8
        UltraGridColumn3.Width = 80
        UltraGridColumn42.Header.VisiblePosition = 17
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.Header.Caption = "Cod. Proveedor"
        UltraGridColumn43.Header.VisiblePosition = 18
        UltraGridColumn43.Width = 62
        UltraGridColumn6.Header.Caption = "Razón Social Proveedor"
        UltraGridColumn6.Header.VisiblePosition = 19
        UltraGridColumn6.Width = 182
        UltraGridColumn8.Header.Caption = "Observación"
        UltraGridColumn8.Header.VisiblePosition = 28
        UltraGridColumn8.Width = 250
        UltraGridColumn9.Header.VisiblePosition = 27
        UltraGridColumn9.Width = 70
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance6
        UltraGridColumn12.Header.Caption = "Orden Compra"
        UltraGridColumn12.Header.VisiblePosition = 20
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 74
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance7
        UltraGridColumn22.Format = "N2"
        UltraGridColumn22.Header.Caption = "Total con IVA"
        UltraGridColumn22.Header.VisiblePosition = 23
        UltraGridColumn22.Width = 100
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn51.CellAppearance = Appearance8
        UltraGridColumn51.Format = "N2"
        UltraGridColumn51.Header.Caption = "% Importe Pendiente"
        UltraGridColumn51.Header.VisiblePosition = 24
        UltraGridColumn51.Hidden = True
        UltraGridColumn51.Width = 85
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn74.CellAppearance = Appearance9
        UltraGridColumn74.Format = "N2"
        UltraGridColumn74.Header.Caption = "% Importe Pendiente"
        UltraGridColumn74.Header.VisiblePosition = 25
        UltraGridColumn74.Width = 85
        Appearance10.TextHAlignAsString = "Center"
        UltraGridColumn73.CellAppearance = Appearance10
        UltraGridColumn73.Header.Caption = "Fecha Entrega (FEnt)"
        UltraGridColumn73.Header.VisiblePosition = 10
        UltraGridColumn73.Width = 84
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn78.CellAppearance = Appearance11
        UltraGridColumn78.Header.Caption = "Fecha Gestión (FGest)"
        UltraGridColumn78.Header.VisiblePosition = 11
        UltraGridColumn78.Width = 80
        Appearance12.TextHAlignAsString = "Center"
        UltraGridColumn34.CellAppearance = Appearance12
        UltraGridColumn34.Format = "dd/MM/yyyy"
        UltraGridColumn34.Header.Caption = "Fecha Autorización"
        UltraGridColumn34.Header.VisiblePosition = 9
        UltraGridColumn34.Width = 80
        UltraGridColumn37.Header.Caption = "Act"
        UltraGridColumn37.Header.VisiblePosition = 1
        UltraGridColumn37.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn37.Width = 40
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance13
        UltraGridColumn40.Format = "N2"
        UltraGridColumn40.Header.Caption = "IVA"
        UltraGridColumn40.Header.VisiblePosition = 22
        UltraGridColumn40.Width = 100
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn41.CellAppearance = Appearance14
        UltraGridColumn41.Format = "N2"
        UltraGridColumn41.Header.Caption = "Total Neto"
        UltraGridColumn41.Header.VisiblePosition = 21
        UltraGridColumn41.Width = 100
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn36.CellAppearance = Appearance15
        UltraGridColumn36.Header.Caption = "Fecha Envío"
        UltraGridColumn36.Header.VisiblePosition = 12
        UltraGridColumn36.Width = 80
        Appearance16.TextHAlignAsString = "Center"
        UltraGridColumn39.CellAppearance = Appearance16
        UltraGridColumn39.Format = "dd/MM/yyyy"
        UltraGridColumn39.Header.Caption = "Fecha Reprogramación"
        UltraGridColumn39.Header.VisiblePosition = 29
        UltraGridColumn39.Width = 95
        UltraGridColumn10.Header.VisiblePosition = 30
        UltraGridColumn28.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance17.TextHAlignAsString = "Center"
        UltraGridColumn28.CellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance18.BackColor2 = System.Drawing.Color.Silver
        Appearance18.BorderColor3DBase = System.Drawing.Color.LightGray
        UltraGridColumn28.CellButtonAppearance = Appearance18
        UltraGridColumn28.Header.Caption = "Contactos"
        UltraGridColumn28.Header.VisiblePosition = 16
        UltraGridColumn28.Hidden = True
        UltraGridColumn28.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn28.Width = 63
        UltraGridColumn69.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance19.Image = CType(resources.GetObject("Appearance19.Image"), Object)
        Appearance19.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance19.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn69.CellButtonAppearance = Appearance19
        UltraGridColumn69.Header.Caption = ""
        UltraGridColumn69.Header.VisiblePosition = 0
        UltraGridColumn69.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn69.Width = 30
        Appearance20.TextHAlignAsString = "Center"
        UltraGridColumn79.CellAppearance = Appearance20
        UltraGridColumn79.Header.Caption = "Dias entre FGest-FEnt"
        UltraGridColumn79.Header.VisiblePosition = 13
        UltraGridColumn79.Width = 65
        Appearance21.TextHAlignAsString = "Center"
        UltraGridColumn75.CellAppearance = Appearance21
        UltraGridColumn75.Header.Caption = "Dias entre FEmi-FEnt"
        UltraGridColumn75.Header.VisiblePosition = 14
        UltraGridColumn75.Width = 65
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn76.CellAppearance = Appearance22
        UltraGridColumn76.Header.Caption = "Dias atraso FAct-FEnt"
        UltraGridColumn76.Header.VisiblePosition = 15
        UltraGridColumn76.Width = 65
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn60.CellAppearance = Appearance23
        UltraGridColumn60.DataType = GetType(Decimal)
        UltraGridColumn60.Format = "N2"
        UltraGridColumn60.Header.Caption = "Importe Pendiente"
        UltraGridColumn60.Header.VisiblePosition = 26
        UltraGridColumn60.Width = 85
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn4, UltraGridColumn61, UltraGridColumn5, UltraGridColumn44, UltraGridColumn45, UltraGridColumn3, UltraGridColumn42, UltraGridColumn43, UltraGridColumn6, UltraGridColumn8, UltraGridColumn9, UltraGridColumn12, UltraGridColumn22, UltraGridColumn51, UltraGridColumn74, UltraGridColumn73, UltraGridColumn78, UltraGridColumn34, UltraGridColumn37, UltraGridColumn40, UltraGridColumn41, UltraGridColumn36, UltraGridColumn39, UltraGridColumn10, UltraGridColumn28, UltraGridColumn69, UltraGridColumn79, UltraGridColumn75, UltraGridColumn76, UltraGridColumn60})
        UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[True]
        Appearance24.BackColor = System.Drawing.Color.Gainsboro
        UltraGridBand1.Override.CellAppearance = Appearance24
        UltraGridBand1.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.Button
        UltraGridBand1.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top
        Appearance25.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance25
        SummarySettings1.DisplayFormat = "{0:N2}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance26
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        UltraGridColumn11.Header.Caption = "Sucursal"
        UltraGridColumn11.Header.VisiblePosition = 0
        UltraGridColumn11.Hidden = True
        UltraGridColumn11.Width = 41
        UltraGridColumn25.Header.Caption = "Tipo Comprobante"
        UltraGridColumn25.Header.VisiblePosition = 6
        UltraGridColumn25.Hidden = True
        UltraGridColumn26.Header.VisiblePosition = 7
        UltraGridColumn26.Hidden = True
        UltraGridColumn27.Header.Caption = "Centro Emisor"
        UltraGridColumn27.Header.VisiblePosition = 8
        UltraGridColumn27.Hidden = True
        UltraGridColumn50.Header.VisiblePosition = 3
        UltraGridColumn50.Hidden = True
        Appearance27.TextHAlignAsString = "Center"
        UltraGridColumn13.CellAppearance = Appearance27
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
        UltraGridColumn16.Header.Caption = "Proveedor"
        UltraGridColumn16.Header.VisiblePosition = 5
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.Header.Caption = "Cod. Artículo"
        UltraGridColumn18.Header.Caption = "Descripción Artículo"
        UltraGridColumn18.Width = 288
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn19.CellAppearance = Appearance28
        UltraGridColumn19.Format = "N2"
        UltraGridColumn19.Header.Caption = "Tamaño"
        UltraGridColumn19.Hidden = True
        UltraGridColumn19.Width = 60
        Appearance29.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance29
        UltraGridColumn7.Header.Caption = "UM"
        UltraGridColumn7.Width = 40
        Appearance30.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance30
        UltraGridColumn20.Format = "N2"
        UltraGridColumn20.Header.Caption = "Cantidad Pedida"
        UltraGridColumn20.Width = 96
        Appearance31.TextHAlignAsString = "Center"
        UltraGridColumn21.CellAppearance = Appearance31
        UltraGridColumn21.Header.Caption = "Fecha Estado"
        UltraGridColumn21.Hidden = True
        UltraGridColumn21.Width = 90
        Appearance32.FontData.BoldAsString = "True"
        UltraGridColumn2.CellAppearance = Appearance32
        UltraGridColumn2.Header.Caption = "Estado"
        UltraGridColumn2.Width = 90
        Appearance33.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance33
        UltraGridColumn23.Header.Caption = "Cant. Estado"
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 75
        Appearance34.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance34
        UltraGridColumn24.Header.Caption = "Cant. Pendiente"
        UltraGridColumn24.Width = 92
        UltraGridColumn46.Header.Caption = "Comprob."
        UltraGridColumn46.Hidden = True
        UltraGridColumn46.Width = 65
        UltraGridColumn47.Header.Caption = "L."
        UltraGridColumn47.Hidden = True
        UltraGridColumn47.Width = 20
        Appearance35.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance35
        UltraGridColumn48.Header.Caption = "Emis."
        UltraGridColumn48.Hidden = True
        UltraGridColumn48.Width = 40
        Appearance36.TextHAlignAsString = "Right"
        UltraGridColumn49.CellAppearance = Appearance36
        UltraGridColumn49.Header.Caption = "Número"
        UltraGridColumn49.Hidden = True
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
        UltraGridColumn32.Hidden = True
        Appearance37.TextHAlignAsString = "Center"
        UltraGridColumn33.CellAppearance = Appearance37
        UltraGridColumn33.Format = "dd/MM/yyyy"
        UltraGridColumn33.Header.Caption = "Fecha Entrega"
        UltraGridColumn53.Header.VisiblePosition = 27
        UltraGridColumn53.Hidden = True
        UltraGridColumn54.Header.Caption = "Lista de Precios"
        UltraGridColumn54.Hidden = True
        UltraGridColumn54.Width = 100
        UltraGridColumn55.Header.VisiblePosition = 29
        UltraGridColumn55.Hidden = True
        UltraGridColumn56.Header.Caption = "Comprob."
        UltraGridColumn56.Hidden = True
        UltraGridColumn56.Width = 65
        UltraGridColumn57.Header.Caption = "L."
        UltraGridColumn57.Hidden = True
        UltraGridColumn57.Width = 20
        Appearance38.TextHAlignAsString = "Right"
        UltraGridColumn58.CellAppearance = Appearance38
        UltraGridColumn58.Header.Caption = "Emis."
        UltraGridColumn58.Hidden = True
        UltraGridColumn58.Width = 40
        Appearance39.TextHAlignAsString = "Right"
        UltraGridColumn59.CellAppearance = Appearance39
        UltraGridColumn59.Header.Caption = "Número"
        UltraGridColumn59.Hidden = True
        UltraGridColumn59.Width = 70
        UltraGridColumn52.Header.Caption = "Id Estado Producto"
        UltraGridColumn52.Hidden = True
        UltraGridColumn62.Header.Caption = "Id Estado Cantidad"
        UltraGridColumn62.Hidden = True
        UltraGridColumn63.Header.Caption = "Id Estado Precio"
        UltraGridColumn63.Hidden = True
        UltraGridColumn64.Header.Caption = "Id Estado Fecha Entrega"
        UltraGridColumn64.Hidden = True
        Appearance40.TextHAlignAsString = "Center"
        UltraGridColumn65.CellAppearance = Appearance40
        UltraGridColumn65.Header.Caption = "Fecha Estado Producto"
        UltraGridColumn65.Hidden = True
        Appearance41.TextHAlignAsString = "Center"
        UltraGridColumn66.CellAppearance = Appearance41
        UltraGridColumn66.Header.Caption = "Fecha Estado Cantidad"
        UltraGridColumn66.Hidden = True
        Appearance42.TextHAlignAsString = "Center"
        UltraGridColumn67.CellAppearance = Appearance42
        UltraGridColumn67.Header.Caption = "Fecha Estado Precio"
        UltraGridColumn67.Hidden = True
        Appearance43.TextHAlignAsString = "Center"
        UltraGridColumn68.CellAppearance = Appearance43
        UltraGridColumn68.Header.Caption = "Fecha Estado Fecha Entrega"
        UltraGridColumn68.Hidden = True
        Appearance44.TextHAlignAsString = "Right"
        UltraGridColumn77.CellAppearance = Appearance44
        UltraGridColumn77.Format = "N2"
        UltraGridColumn77.Width = 86
        UltraGridColumn38.Header.Caption = "Act"
        UltraGridColumn38.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn38.Width = 40
        Appearance45.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance45
        UltraGridColumn35.Format = "N2"
        UltraGridColumn35.Header.Caption = "Costo Con Imp."
        UltraGridColumn35.Width = 93
        UltraGridColumn71.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance46.Image = CType(resources.GetObject("Appearance46.Image"), Object)
        Appearance46.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance46.ImageVAlign = Infragistics.Win.VAlign.Middle
        UltraGridColumn71.CellButtonAppearance = Appearance46
        UltraGridColumn71.Header.Caption = ""
        UltraGridColumn71.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn71.Width = 30
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn11, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn50, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn7, UltraGridColumn20, UltraGridColumn21, UltraGridColumn2, UltraGridColumn23, UltraGridColumn24, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn52, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn77, UltraGridColumn38, UltraGridColumn35, UltraGridColumn71})
        Appearance47.FontData.BoldAsString = "True"
        UltraGridGroup1.Header.Appearance = Appearance47
        UltraGridGroup1.Key = "Detalle"
        UltraGridGroup1.RowLayoutGroupInfo.LabelSpan = 1
        Appearance48.FontData.BoldAsString = "True"
        UltraGridGroup2.Header.Appearance = Appearance48
        UltraGridGroup2.Header.Caption = "Facturó"
        UltraGridGroup2.Hidden = True
        UltraGridGroup2.Key = "Factura"
        UltraGridGroup2.RowLayoutGroupInfo.LabelSpan = 1
        Appearance49.FontData.BoldAsString = "True"
        UltraGridGroup3.Header.Appearance = Appearance49
        UltraGridGroup3.Hidden = True
        UltraGridGroup3.Key = "Remitió"
        UltraGridGroup3.RowLayoutGroupInfo.LabelSpan = 1
        UltraGridBand2.Groups.AddRange(New Infragistics.Win.UltraWinGrid.UltraGridGroup() {UltraGridGroup1, UltraGridGroup2, UltraGridGroup3})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance50.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance50.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance50.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance50
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance51
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance52.BackColor2 = System.Drawing.SystemColors.Control
        Appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance52.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance52
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance53.BackColor = System.Drawing.SystemColors.Window
        Appearance53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.SystemColors.Highlight
        Appearance54.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance54
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance55
        Appearance56.BorderColor = System.Drawing.Color.Silver
        Appearance56.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance56
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance57.BackColor = System.Drawing.SystemColors.Control
        Appearance57.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance57.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance57.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance57
        Appearance58.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance58
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance59.BackColor = System.Drawing.SystemColors.Window
        Appearance59.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance59
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
        Appearance60.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance60
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 0)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1071, 289)
        Me.ugDetalle.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtPorcImpPendiente)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chbDiferenciasFechas)
        Me.GroupBox1.Controls.Add(Me.txtFechaEnt)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.txtCodProv)
        Me.GroupBox1.Controls.Add(Me.txtFechaE)
        Me.GroupBox1.Controls.Add(Me.txtOC)
        Me.GroupBox1.Controls.Add(Me.txtTipo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1071, 41)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.LabelAsoc = Nothing
        Me.Label13.Location = New System.Drawing.Point(784, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "% Imp. Pendiente"
        '
        'txtPorcImpPendiente
        '
        Me.txtPorcImpPendiente.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtPorcImpPendiente.BindearPropiedadControl = Nothing
        Me.txtPorcImpPendiente.BindearPropiedadEntidad = Nothing
        Me.txtPorcImpPendiente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcImpPendiente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcImpPendiente.Formato = "N2"
        Me.txtPorcImpPendiente.IsDecimal = False
        Me.txtPorcImpPendiente.IsNumber = True
        Me.txtPorcImpPendiente.IsPK = False
        Me.txtPorcImpPendiente.IsRequired = False
        Me.txtPorcImpPendiente.Key = ""
        Me.txtPorcImpPendiente.LabelAsoc = Nothing
        Me.txtPorcImpPendiente.Location = New System.Drawing.Point(787, 21)
        Me.txtPorcImpPendiente.MaxLength = 8
        Me.txtPorcImpPendiente.Name = "txtPorcImpPendiente"
        Me.txtPorcImpPendiente.ReadOnly = True
        Me.txtPorcImpPendiente.Size = New System.Drawing.Size(91, 20)
        Me.txtPorcImpPendiente.TabIndex = 53
        Me.txtPorcImpPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.LabelAsoc = Nothing
        Me.Label12.Location = New System.Drawing.Point(687, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Total"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.LabelAsoc = Nothing
        Me.Label11.Location = New System.Drawing.Point(482, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 13)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Razón Social Proveedor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.LabelAsoc = Nothing
        Me.Label10.Location = New System.Drawing.Point(413, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Cod. Prov,"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.LabelAsoc = Nothing
        Me.Label9.Location = New System.Drawing.Point(315, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "Fecha Entrega"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.LabelAsoc = Nothing
        Me.Label8.Location = New System.Drawing.Point(220, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Fecha Emisión"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(154, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Ord. Compra"
        '
        'chbDiferenciasFechas
        '
        Me.chbDiferenciasFechas.AutoSize = True
        Me.chbDiferenciasFechas.BindearPropiedadControl = Nothing
        Me.chbDiferenciasFechas.BindearPropiedadEntidad = Nothing
        Me.chbDiferenciasFechas.Checked = True
        Me.chbDiferenciasFechas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbDiferenciasFechas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDiferenciasFechas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDiferenciasFechas.IsPK = False
        Me.chbDiferenciasFechas.IsRequired = False
        Me.chbDiferenciasFechas.Key = Nothing
        Me.chbDiferenciasFechas.LabelAsoc = Nothing
        Me.chbDiferenciasFechas.Location = New System.Drawing.Point(906, 19)
        Me.chbDiferenciasFechas.Name = "chbDiferenciasFechas"
        Me.chbDiferenciasFechas.Size = New System.Drawing.Size(158, 17)
        Me.chbDiferenciasFechas.TabIndex = 46
        Me.chbDiferenciasFechas.Text = "Ver diferencias entre fechas"
        Me.chbDiferenciasFechas.UseVisualStyleBackColor = True
        '
        'txtFechaEnt
        '
        Me.txtFechaEnt.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtFechaEnt.Location = New System.Drawing.Point(318, 21)
        Me.txtFechaEnt.Name = "txtFechaEnt"
        Me.txtFechaEnt.ReadOnly = True
        Me.txtFechaEnt.Size = New System.Drawing.Size(91, 20)
        Me.txtFechaEnt.TabIndex = 44
        Me.txtFechaEnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtTotal.BindearPropiedadControl = Nothing
        Me.txtTotal.BindearPropiedadEntidad = Nothing
        Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTotal.Formato = "N2"
        Me.txtTotal.IsDecimal = False
        Me.txtTotal.IsNumber = True
        Me.txtTotal.IsPK = False
        Me.txtTotal.IsRequired = False
        Me.txtTotal.Key = ""
        Me.txtTotal.LabelAsoc = Nothing
        Me.txtTotal.Location = New System.Drawing.Point(690, 21)
        Me.txtTotal.MaxLength = 8
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(91, 20)
        Me.txtTotal.TabIndex = 43
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtProveedor.Location = New System.Drawing.Point(485, 21)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(199, 20)
        Me.txtProveedor.TabIndex = 41
        '
        'txtCodProv
        '
        Me.txtCodProv.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtCodProv.Location = New System.Drawing.Point(415, 21)
        Me.txtCodProv.Name = "txtCodProv"
        Me.txtCodProv.ReadOnly = True
        Me.txtCodProv.Size = New System.Drawing.Size(64, 20)
        Me.txtCodProv.TabIndex = 40
        Me.txtCodProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaE
        '
        Me.txtFechaE.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtFechaE.Location = New System.Drawing.Point(223, 21)
        Me.txtFechaE.Name = "txtFechaE"
        Me.txtFechaE.ReadOnly = True
        Me.txtFechaE.Size = New System.Drawing.Size(89, 20)
        Me.txtFechaE.TabIndex = 39
        Me.txtFechaE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOC
        '
        Me.txtOC.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtOC.Location = New System.Drawing.Point(156, 21)
        Me.txtOC.Name = "txtOC"
        Me.txtOC.ReadOnly = True
        Me.txtOC.Size = New System.Drawing.Size(61, 20)
        Me.txtOC.TabIndex = 38
        Me.txtOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtTipo.Location = New System.Drawing.Point(79, 21)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(71, 20)
        Me.txtTipo.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(76, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Tipo"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 50)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grbConsultar)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1071, 486)
        Me.SplitContainer1.SplitterDistance = 148
        Me.SplitContainer1.TabIndex = 46
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ugDetalle)
        Me.SplitContainer2.Size = New System.Drawing.Size(1071, 334)
        Me.SplitContainer2.SplitterDistance = 41
        Me.SplitContainer2.TabIndex = 0
        '
        'chbOcultarFiltros
        '
        Me.chbOcultarFiltros.AutoSize = True
        Me.chbOcultarFiltros.BindearPropiedadControl = Nothing
        Me.chbOcultarFiltros.BindearPropiedadEntidad = Nothing
        Me.chbOcultarFiltros.Checked = True
        Me.chbOcultarFiltros.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbOcultarFiltros.ForeColorFocus = System.Drawing.Color.Red
        Me.chbOcultarFiltros.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbOcultarFiltros.IsPK = False
        Me.chbOcultarFiltros.IsRequired = False
        Me.chbOcultarFiltros.Key = Nothing
        Me.chbOcultarFiltros.LabelAsoc = Nothing
        Me.chbOcultarFiltros.Location = New System.Drawing.Point(12, 32)
        Me.chbOcultarFiltros.Name = "chbOcultarFiltros"
        Me.chbOcultarFiltros.Size = New System.Drawing.Size(72, 17)
        Me.chbOcultarFiltros.TabIndex = 105
        Me.chbOcultarFiltros.Text = "Ver Filtros"
        Me.chbOcultarFiltros.UseVisualStyleBackColor = True
        '
        'ConsultarOrdenesCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1095, 561)
        Me.Controls.Add(Me.chbOcultarFiltros)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.KeyPreview = True
        Me.Name = "ConsultarOrdenesCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Ordenes de Compra"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents chbIdPedido As Eniac.Controles.CheckBox
   Friend WithEvents txtIdPedido As Eniac.Controles.TextBox
   Friend WithEvents cmbEstados As Eniac.Controles.ComboBox
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbComprador As Eniac.Controles.CheckBox
   Friend WithEvents cmbComprador As Eniac.Controles.ComboBox
   Friend WithEvents chbOrdenCompra As Eniac.Controles.CheckBox
   Friend WithEvents txtOrdenCompra As Eniac.Controles.TextBox
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobante As Eniac.Controles.Label
   Friend WithEvents Label5 As Controles.Label
   Friend WithEvents Label4 As Controles.Label
   Friend WithEvents chbRangoImporte As Controles.CheckBox
   Friend WithEvents dtpFechaEntregaHasta As Controles.DateTimePicker
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents dtpFechaEntregaDesde As Controles.DateTimePicker
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents chbFechaEntrega As Controles.CheckBox
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents cmbActivadas As Controles.ComboBox
   Friend WithEvents ugDetalle As UltraGrid
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents txtProveedor As TextBox
   Friend WithEvents txtCodProv As TextBox
   Friend WithEvents txtFechaE As TextBox
   Friend WithEvents txtOC As TextBox
   Friend WithEvents txtTipo As TextBox
   Friend WithEvents txtTotal As Controles.TextBox
   Friend WithEvents txtFechaEnt As TextBox
   Friend WithEvents txtMaxRango As Controles.TextBox
   Friend WithEvents txtMinRango As Controles.TextBox
   Friend WithEvents chbDiferenciasFechas As Controles.CheckBox
   Friend WithEvents SplitContainer1 As SplitContainer
   Friend WithEvents SplitContainer2 As SplitContainer
   Friend WithEvents chbOcultarFiltros As Controles.CheckBox
   Friend WithEvents Label13 As Controles.Label
   Friend WithEvents txtPorcImpPendiente As Controles.TextBox
   Friend WithEvents Label12 As Controles.Label
   Friend WithEvents Label11 As Controles.Label
   Friend WithEvents Label10 As Controles.Label
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents Label8 As Controles.Label
   Friend WithEvents Label7 As Controles.Label
   Friend WithEvents Label6 As Controles.Label
   Friend WithEvents dtpFechaAutorizacionHasta As Controles.DateTimePicker
   Friend WithEvents Label14 As Controles.Label
   Friend WithEvents dtpFechaAutorizacionDesde As Controles.DateTimePicker
   Friend WithEvents Label15 As Controles.Label
   Friend WithEvents chbFechaAutorizacion As Controles.CheckBox
End Class
