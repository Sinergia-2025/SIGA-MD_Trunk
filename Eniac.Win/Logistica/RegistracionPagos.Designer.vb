<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistracionPagos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistracionPagos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos", -1)
      Dim UltraGridColumn369 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn370 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn371 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn372 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn373 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn374 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn375 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn376 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
      Dim UltraGridColumn377 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn378 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn379 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn380 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
      Dim UltraGridColumn381 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn416 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
      Dim UltraGridColumn418 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
      Dim UltraGridColumn419 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim UltraGridColumn420 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
      Dim UltraGridColumn421 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn422 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn423 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn424 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
      Dim UltraGridColumn425 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
      Dim UltraGridColumn426 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn427 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
      Dim UltraGridColumn428 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
      Dim UltraGridColumn429 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo")
      Dim UltraGridColumn430 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuentaCorriente")
      Dim UltraGridColumn431 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
      Dim UltraGridColumn432 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
      Dim UltraGridColumn433 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
      Dim UltraGridColumn434 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioNueva")
      Dim UltraGridColumn435 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportistaNuevo")
      Dim UltraGridColumn436 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportistaNuevo")
      Dim UltraGridColumn231 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
      Dim UltraGridColumn438 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
      Dim UltraGridColumn439 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, "", "ImporteTotal", 17, True, "Pedidos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "ImporteTotal", 17, True)
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn440 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn441 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn442 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn443 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn444 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn445 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn446 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn447 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn448 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn449 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn450 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn451 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn452 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn453 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn454 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn455 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn456 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn457 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn458 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn459 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn460 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn461 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn462 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn463 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn464 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn465 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn466 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn467 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn468 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn469 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn470 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn471 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn472 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn473 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn474 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn475 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn476 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn477 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
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
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand4 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos", -1)
        Dim UltraGridColumn162 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn163 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn164 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn165 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn166 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn167 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn168 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn169 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn170 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn171 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn172 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn173 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn174 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn175 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
        Dim UltraGridColumn176 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn177 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn178 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn179 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn180 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn181 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn182 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn183 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn184 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn185 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn186 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
        Dim UltraGridColumn187 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo")
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn188 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuentaCorriente")
        Dim UltraGridColumn189 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn190 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn191 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn192 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioNueva")
        Dim UltraGridColumn193 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportistaNuevo")
        Dim UltraGridColumn194 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportistaNuevo")
        Dim UltraGridColumn232 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn195 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn196 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings2 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "Efectivo", 25, True, "Pedidos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand5 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridBand6 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn272 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand7 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos", -1)
        Dim UltraGridColumn235 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn236 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn237 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn238 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn239 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn240 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn241 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn242 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn243 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn244 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn245 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn246 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn247 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn248 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
        Dim UltraGridColumn249 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn250 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn251 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn252 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn253 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn254 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn255 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn256 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn257 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn258 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn259 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
        Dim UltraGridColumn260 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn261 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuentaCorriente")
        Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn262 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn263 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn264 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn265 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioNueva")
        Dim UltraGridColumn266 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportistaNuevo")
        Dim UltraGridColumn267 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportistaNuevo")
        Dim UltraGridColumn233 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn268 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn269 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings3 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "CuentaCorriente", 26, True, "Pedidos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
        Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand8 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridBand9 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn273 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn274 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn275 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
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
        Dim Appearance87 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand10 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos", -1)
        Dim UltraGridColumn309 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn310 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn311 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn312 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance88 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn313 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance89 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn314 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn315 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance90 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn316 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn317 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn318 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn319 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn320 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn321 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn322 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
        Dim UltraGridColumn323 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn324 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn325 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn326 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn327 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn328 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn329 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn330 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn331 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn332 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn333 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
        Dim UltraGridColumn334 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo")
        Dim Appearance91 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn335 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuentaCorriente")
        Dim UltraGridColumn336 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim Appearance92 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn337 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn338 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn339 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioNueva")
        Dim UltraGridColumn340 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportistaNuevo")
        Dim UltraGridColumn341 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportistaNuevo")
        Dim UltraGridColumn234 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn342 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn343 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim Appearance93 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings4 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TotalCheques", 27, True, "Pedidos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
        Dim Appearance94 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance95 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand11 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridBand12 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn115 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn116 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn117 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn118 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn119 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn276 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn277 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn278 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim Appearance96 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance97 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance98 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance99 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance100 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance101 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance102 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance103 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance104 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance105 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance106 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand13 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos", -1)
        Dim UltraGridColumn382 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn383 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn384 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn385 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance107 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn386 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance108 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn387 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn388 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance109 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn389 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn390 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn391 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn392 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn393 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn394 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn395 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
        Dim UltraGridColumn396 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn397 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn398 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn399 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn400 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn401 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn402 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn403 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn404 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn405 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn406 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
        Dim UltraGridColumn407 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo")
        Dim Appearance110 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn408 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuentaCorriente")
        Dim UltraGridColumn409 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn410 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim Appearance111 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn411 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim UltraGridColumn412 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioNueva")
        Dim UltraGridColumn413 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportistaNuevo")
        Dim UltraGridColumn414 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportistaNuevo")
        Dim UltraGridColumn270 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn415 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn417 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim Appearance112 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings5 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TotalNC", 28, True, "Pedidos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
        Dim Appearance113 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance114 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand14 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn120 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn121 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn122 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn123 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn124 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn125 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn126 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn127 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn128 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn129 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn130 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn131 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn132 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn133 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn134 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn135 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn136 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn137 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn138 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn139 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn140 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridBand15 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn141 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn142 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn143 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn144 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn145 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn146 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn147 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn148 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn149 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn150 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn151 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn152 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn153 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn154 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn155 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn156 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn157 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn279 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn280 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn281 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim Appearance115 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance116 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance117 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance118 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance119 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance120 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance121 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance122 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance123 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance124 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance125 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand16 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos", -1)
        Dim UltraGridColumn487 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn488 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn489 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn490 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance126 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn491 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance127 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn492 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn493 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance128 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn494 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn495 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim UltraGridColumn496 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn497 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn498 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn499 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn500 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEmpleado")
        Dim UltraGridColumn501 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim UltraGridColumn502 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim UltraGridColumn503 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvio")
        Dim UltraGridColumn504 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn505 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
        Dim UltraGridColumn506 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim UltraGridColumn507 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAlta")
        Dim UltraGridColumn508 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn509 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFormasPago")
        Dim UltraGridColumn510 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GrabaLibro")
        Dim UltraGridColumn511 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaPago")
        Dim UltraGridColumn512 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo")
        Dim Appearance129 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn513 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuentaCorriente")
        Dim UltraGridColumn514 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalCheques")
        Dim UltraGridColumn515 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalNC")
        Dim UltraGridColumn516 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalReenvio")
        Dim Appearance130 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn517 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioNueva")
        Dim UltraGridColumn518 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportistaNuevo")
        Dim UltraGridColumn519 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportistaNuevo")
        Dim UltraGridColumn271 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCliente")
        Dim UltraGridColumn520 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Productos")
        Dim UltraGridColumn521 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Pedidos_Cheques")
        Dim Appearance131 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim SummarySettings6 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "TotalReenvio", 29, True, "Pedidos", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
        Dim Appearance132 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance133 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand17 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Productos", 0)
        Dim UltraGridColumn158 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn159 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn160 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn161 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn197 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn198 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn199 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn200 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn201 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn202 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio")
        Dim UltraGridColumn203 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim UltraGridColumn204 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Devuelve")
        Dim UltraGridColumn205 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMotivo")
        Dim UltraGridColumn206 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Motivo")
        Dim UltraGridColumn207 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDevuelve")
        Dim UltraGridColumn208 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaIVA")
        Dim UltraGridColumn209 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim UltraGridColumn210 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorcImpuestoInterno")
        Dim UltraGridColumn211 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrigenPorcImpInt")
        Dim UltraGridColumn212 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim UltraGridColumn213 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nota")
        Dim UltraGridBand18 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Pedidos_Cheques", 0)
        Dim UltraGridColumn214 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn215 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn216 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn217 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim UltraGridColumn218 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim UltraGridColumn219 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroCheque")
        Dim UltraGridColumn220 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBanco")
        Dim UltraGridColumn221 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBancoSucursal")
        Dim UltraGridColumn222 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim UltraGridColumn223 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEmision")
        Dim UltraGridColumn224 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCobro")
        Dim UltraGridColumn225 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titular")
        Dim UltraGridColumn226 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importe")
        Dim UltraGridColumn227 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn228 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn229 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCheque")
        Dim UltraGridColumn230 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn282 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuit")
        Dim UltraGridColumn283 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoCheque")
        Dim UltraGridColumn284 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroOperacion")
        Dim Appearance134 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim UltraGridBand19 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("ProductosSinDescargo", -1)
        Dim UltraGridColumn601 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn602 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn603 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim UltraGridColumn604 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductosSinDescargoComprobante")
        Dim UltraGridBand20 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("ProductosSinDescargoComprobante", -1)
        Dim UltraGridColumn605 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim Appearance146 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn606 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn607 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn608 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim UltraGridColumn609 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance147 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn610 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
        Dim Appearance148 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn611 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdReparo")
        Dim UltraGridColumn612 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn613 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance149 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn614 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn615 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn616 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoOperacion")
        Dim Appearance150 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance151 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance152 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance153 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance154 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance155 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance156 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance157 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance158 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance159 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance160 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim CalculatorButton1 As Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton = New Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton(15)
        Dim Appearance161 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance162 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance163 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance164 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance165 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance166 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance167 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance168 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance169 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance170 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance171 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab8 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance172 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.tsbEfectivo = New System.Windows.Forms.ToolStripButton()
        Me.tsbVarias = New System.Windows.Forms.ToolStripButton()
        Me.tsbCC = New System.Windows.Forms.ToolStripButton()
        Me.tsbNC = New System.Windows.Forms.ToolStripButton()
        Me.tsbReenvio = New System.Windows.Forms.ToolStripButton()
        Me.tsbNoRendir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ugvDetallePedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DtsRegistracionPagos = New Eniac.Win.dtsRegistracionPagos()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugEfectivo = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.EfectivoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugCtaCte = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CtaCteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugChequesAUX = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugCheque = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ChequesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugNc = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.NCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.utReenvios = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.lblNumeroReparto = New System.Windows.Forms.Label()
        Me.ugReenvios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ReenviosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl5 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.ugvProductosSinDescargar = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.utResumen = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.cmdImprimirResumen = New System.Windows.Forms.Button()
        Me.grbIVAs = New System.Windows.Forms.GroupBox()
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
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.Label7 = New Eniac.Controles.Label()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.Label6 = New Eniac.Controles.Label()
        Me.dtpFechaRend = New Eniac.Controles.DateTimePicker()
        Me.ucdCalculadora = New Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculatorDropDown()
        Me.utcPreventa = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.grbFecha = New System.Windows.Forms.GroupBox()
        Me.chbDias = New Eniac.Controles.CheckBox()
        Me.cmbDias = New Eniac.Controles.ComboBox()
        Me.cmbRuta = New Eniac.Controles.ComboBox()
        Me.chbRuta = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.cmbModoConsultarComprobantes = New Eniac.Controles.ComboBox()
        Me.txtNumeroReparto = New Eniac.Controles.TextBox()
        Me.lblReparto = New Eniac.Controles.Label()
        Me.cmbLocalidad = New Eniac.Controles.ComboBox()
        Me.btnBuscar = New Eniac.Controles.Button()
        Me.chbRespDistribucion = New System.Windows.Forms.CheckBox()
        Me.cmbRespDistribucion = New Eniac.Controles.ComboBox()
        Me.chbLocalidad = New System.Windows.Forms.CheckBox()
        Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblAl = New Eniac.Controles.Label()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tsbPagarTodo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimirGrilla = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraTabPageControl3.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        CType(Me.ugvDetallePedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtsRegistracionPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.ugEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EfectivoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.ugCtaCte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CtaCteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl4.SuspendLayout()
        CType(Me.ugChequesAUX, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.ucdCalculadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utcPreventa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utcPreventa.SuspendLayout()
        Me.grbFecha.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl3
        '
        Me.UltraTabPageControl3.Controls.Add(Me.ToolStrip4)
        Me.UltraTabPageControl3.Controls.Add(Me.Label3)
        Me.UltraTabPageControl3.Controls.Add(Me.Label2)
        Me.UltraTabPageControl3.Controls.Add(Me.ugvDetallePedidos)
        Me.UltraTabPageControl3.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
        Me.UltraTabPageControl3.Size = New System.Drawing.Size(999, 386)
        '
        'ToolStrip4
        '
        Me.ToolStrip4.AllowItemReorder = True
        Me.ToolStrip4.BackColor = System.Drawing.Color.Silver
        Me.ToolStrip4.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbEfectivo, Me.tsbVarias, Me.tsbCC, Me.tsbNC, Me.tsbReenvio, Me.tsbNoRendir, Me.ToolStripSeparator3, Me.tsbImprimir})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(999, 29)
        Me.ToolStrip4.TabIndex = 0
        Me.ToolStrip4.Text = "toolStrip1"
        '
        'tsbEfectivo
        '
        Me.tsbEfectivo.Image = CType(resources.GetObject("tsbEfectivo.Image"), System.Drawing.Image)
        Me.tsbEfectivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEfectivo.Name = "tsbEfectivo"
        Me.tsbEfectivo.Size = New System.Drawing.Size(72, 26)
        Me.tsbEfectivo.Text = "Pagada"
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
        '
        'tsbNC
        '
        Me.tsbNC.Image = CType(resources.GetObject("tsbNC.Image"), System.Drawing.Image)
        Me.tsbNC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNC.Name = "tsbNC"
        Me.tsbNC.Size = New System.Drawing.Size(78, 26)
        Me.tsbNC.Text = "NC Total"
        '
        'tsbReenvio
        '
        Me.tsbReenvio.Image = CType(resources.GetObject("tsbReenvio.Image"), System.Drawing.Image)
        Me.tsbReenvio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReenvio.Name = "tsbReenvio"
        Me.tsbReenvio.Size = New System.Drawing.Size(83, 26)
        Me.tsbReenvio.Text = "Re-Enviar"
        '
        'tsbNoRendir
        '
        Me.tsbNoRendir.Image = Global.Eniac.Win.My.Resources.Resources.delete2
        Me.tsbNoRendir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNoRendir.Name = "tsbNoRendir"
        Me.tsbNoRendir.Size = New System.Drawing.Size(86, 26)
        Me.tsbNoRendir.Text = "No Rendir"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "Imprimir"
        Me.tsbImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 2
        '
        'ugvDetallePedidos
        '
        Me.ugvDetallePedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ugvDetallePedidos.DataMember = "Pedidos"
        Me.ugvDetallePedidos.DataSource = Me.DtsRegistracionPagos
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvDetallePedidos.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn369.CellAppearance = Appearance2
        UltraGridColumn369.Header.VisiblePosition = 15
        UltraGridColumn369.Hidden = True
        UltraGridColumn370.Header.Caption = "Tipo"
        UltraGridColumn370.Header.VisiblePosition = 6
        UltraGridColumn370.Width = 90
        UltraGridColumn371.Header.Caption = "L"
        UltraGridColumn371.Header.VisiblePosition = 7
        UltraGridColumn371.Width = 25
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn372.CellAppearance = Appearance3
        UltraGridColumn372.Header.VisiblePosition = 17
        UltraGridColumn372.Hidden = True
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn373.CellAppearance = Appearance4
        UltraGridColumn373.Header.Caption = "Nro."
        UltraGridColumn373.Header.VisiblePosition = 8
        UltraGridColumn373.Width = 40
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn374.CellAppearance = Appearance5
        UltraGridColumn374.Header.VisiblePosition = 18
        UltraGridColumn374.Hidden = True
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn375.CellAppearance = Appearance6
        UltraGridColumn375.Header.Caption = "Código"
        UltraGridColumn375.Header.VisiblePosition = 2
        UltraGridColumn375.Width = 50
        UltraGridColumn376.Header.VisiblePosition = 19
        UltraGridColumn376.Hidden = True
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn377.CellAppearance = Appearance7
        UltraGridColumn377.Header.VisiblePosition = 20
        UltraGridColumn377.Hidden = True
        UltraGridColumn378.Header.Caption = "Cliente"
        UltraGridColumn378.Header.VisiblePosition = 3
        UltraGridColumn378.Width = 130
        UltraGridColumn379.Header.VisiblePosition = 4
        UltraGridColumn379.Width = 110
        UltraGridColumn380.Header.Caption = "Resp. Distribución"
        UltraGridColumn380.Header.VisiblePosition = 11
        UltraGridColumn380.Width = 105
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn381.CellAppearance = Appearance8
        UltraGridColumn381.Header.VisiblePosition = 21
        UltraGridColumn381.Hidden = True
        UltraGridColumn416.Header.Caption = "Vendedor"
        UltraGridColumn416.Header.VisiblePosition = 14
        UltraGridColumn416.Width = 100
        UltraGridColumn418.Header.VisiblePosition = 16
        UltraGridColumn418.Hidden = True
        UltraGridColumn419.Format = "dd/MM/yyyy"
        UltraGridColumn419.Header.Caption = "F. Pedido"
        UltraGridColumn419.Header.VisiblePosition = 13
        UltraGridColumn419.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn419.Width = 64
        UltraGridColumn420.Format = "dd/MM/yyyy"
        UltraGridColumn420.Header.Caption = "F. Envio"
        UltraGridColumn420.Header.VisiblePosition = 10
        UltraGridColumn420.MaskInput = "{LOC}dd/mm/yyyy"
        UltraGridColumn420.Width = 64
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn421.CellAppearance = Appearance9
        UltraGridColumn421.Format = "N2"
        UltraGridColumn421.Header.Caption = "Total"
        UltraGridColumn421.Header.VisiblePosition = 5
        UltraGridColumn421.MaskInput = "{double:-12.2}"
        UltraGridColumn421.Width = 70
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn422.CellAppearance = Appearance10
        UltraGridColumn422.Header.VisiblePosition = 22
        UltraGridColumn422.Hidden = True
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn423.CellAppearance = Appearance11
        UltraGridColumn423.Header.Caption = "Reparto"
        UltraGridColumn423.Header.VisiblePosition = 9
        UltraGridColumn424.Header.VisiblePosition = 23
        UltraGridColumn424.Hidden = True
        UltraGridColumn424.Width = 64
        UltraGridColumn425.Header.Caption = "F.P. Cliente"
        UltraGridColumn425.Header.VisiblePosition = 1
        UltraGridColumn425.Width = 69
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn426.CellAppearance = Appearance12
        UltraGridColumn426.Header.VisiblePosition = 24
        UltraGridColumn426.Hidden = True
        UltraGridColumn427.Header.VisiblePosition = 25
        UltraGridColumn427.Hidden = True
        UltraGridColumn428.Header.Caption = "Forma Pago"
        UltraGridColumn428.Header.VisiblePosition = 0
        UltraGridColumn429.Header.VisiblePosition = 26
        UltraGridColumn429.Hidden = True
        UltraGridColumn430.Header.VisiblePosition = 27
        UltraGridColumn430.Hidden = True
        UltraGridColumn431.Header.VisiblePosition = 28
        UltraGridColumn431.Hidden = True
        UltraGridColumn432.Header.VisiblePosition = 29
        UltraGridColumn432.Hidden = True
        UltraGridColumn433.Header.VisiblePosition = 30
        UltraGridColumn433.Hidden = True
        UltraGridColumn434.Header.VisiblePosition = 31
        UltraGridColumn434.Hidden = True
        UltraGridColumn435.Header.VisiblePosition = 32
        UltraGridColumn435.Hidden = True
        UltraGridColumn436.Header.VisiblePosition = 33
        UltraGridColumn436.Hidden = True
        UltraGridColumn231.Header.Caption = "Saldo Cliente"
        UltraGridColumn231.Header.VisiblePosition = 12
        UltraGridColumn438.Header.VisiblePosition = 34
        UltraGridColumn439.Header.VisiblePosition = 35
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn369, UltraGridColumn370, UltraGridColumn371, UltraGridColumn372, UltraGridColumn373, UltraGridColumn374, UltraGridColumn375, UltraGridColumn376, UltraGridColumn377, UltraGridColumn378, UltraGridColumn379, UltraGridColumn380, UltraGridColumn381, UltraGridColumn416, UltraGridColumn418, UltraGridColumn419, UltraGridColumn420, UltraGridColumn421, UltraGridColumn422, UltraGridColumn423, UltraGridColumn424, UltraGridColumn425, UltraGridColumn426, UltraGridColumn427, UltraGridColumn428, UltraGridColumn429, UltraGridColumn430, UltraGridColumn431, UltraGridColumn432, UltraGridColumn433, UltraGridColumn434, UltraGridColumn435, UltraGridColumn436, UltraGridColumn231, UltraGridColumn438, UltraGridColumn439})
        Appearance13.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance13
        SummarySettings1.DisplayFormat = "{0:N2}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance14
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
        UltraGridBand1.SummaryFooterCaption = "Total Pedidos:"
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn440.CellAppearance = Appearance15
        UltraGridColumn440.Header.VisiblePosition = 0
        UltraGridColumn440.Hidden = True
        UltraGridColumn440.Width = 56
        UltraGridColumn441.Header.VisiblePosition = 1
        UltraGridColumn441.Hidden = True
        UltraGridColumn441.Width = 69
        UltraGridColumn442.Header.VisiblePosition = 2
        UltraGridColumn442.Hidden = True
        UltraGridColumn442.Width = 50
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn443.CellAppearance = Appearance16
        UltraGridColumn443.Header.VisiblePosition = 3
        UltraGridColumn443.Hidden = True
        UltraGridColumn443.Width = 130
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn444.CellAppearance = Appearance17
        UltraGridColumn444.Header.VisiblePosition = 4
        UltraGridColumn444.Hidden = True
        UltraGridColumn444.Width = 110
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn445.CellAppearance = Appearance18
        UltraGridColumn445.Header.Caption = "Código"
        UltraGridColumn445.Header.VisiblePosition = 6
        UltraGridColumn445.MaxWidth = 80
        UltraGridColumn445.Width = 80
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn446.CellAppearance = Appearance19
        UltraGridColumn446.Header.VisiblePosition = 5
        UltraGridColumn446.MaxWidth = 50
        UltraGridColumn446.MinWidth = 50
        UltraGridColumn446.Width = 50
        UltraGridColumn447.Header.Caption = "Producto"
        UltraGridColumn447.Header.VisiblePosition = 7
        UltraGridColumn447.Width = 377
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn448.CellAppearance = Appearance20
        UltraGridColumn448.Format = "N2"
        UltraGridColumn448.Header.VisiblePosition = 8
        UltraGridColumn448.MaskInput = "{double:-12.2}"
        UltraGridColumn448.MaxWidth = 60
        UltraGridColumn448.MinWidth = 60
        UltraGridColumn448.Width = 60
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn449.CellAppearance = Appearance21
        UltraGridColumn449.Format = "N2"
        UltraGridColumn449.Header.VisiblePosition = 9
        UltraGridColumn449.MaskInput = "{double:-12.2}"
        UltraGridColumn449.MaxWidth = 60
        UltraGridColumn449.MinWidth = 60
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn450.CellAppearance = Appearance22
        UltraGridColumn450.Format = "N2"
        UltraGridColumn450.Header.Caption = "Total"
        UltraGridColumn450.Header.VisiblePosition = 10
        UltraGridColumn450.MaskInput = "{double:-12.2}"
        UltraGridColumn450.MaxWidth = 60
        UltraGridColumn450.MinWidth = 60
        UltraGridColumn450.Width = 60
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn451.CellAppearance = Appearance23
        UltraGridColumn451.Format = "N2"
        UltraGridColumn451.Header.VisiblePosition = 11
        UltraGridColumn451.Hidden = True
        UltraGridColumn451.MaskInput = "{double:-12.2}"
        UltraGridColumn451.MaxWidth = 60
        UltraGridColumn451.MinWidth = 60
        UltraGridColumn451.Width = 60
        UltraGridColumn452.Header.VisiblePosition = 12
        UltraGridColumn452.Hidden = True
        UltraGridColumn452.MaxWidth = 50
        UltraGridColumn453.Header.VisiblePosition = 13
        UltraGridColumn453.Hidden = True
        UltraGridColumn453.Width = 64
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn454.CellAppearance = Appearance24
        UltraGridColumn454.Format = "N2"
        UltraGridColumn454.Header.VisiblePosition = 14
        UltraGridColumn454.Hidden = True
        UltraGridColumn454.MaskInput = "{double:-12.2}"
        UltraGridColumn454.MaxWidth = 60
        UltraGridColumn454.MinWidth = 60
        UltraGridColumn454.Width = 60
        UltraGridColumn455.Header.VisiblePosition = 15
        UltraGridColumn455.Hidden = True
        UltraGridColumn456.Header.VisiblePosition = 16
        UltraGridColumn456.Hidden = True
        UltraGridColumn457.Header.VisiblePosition = 17
        UltraGridColumn457.Hidden = True
        UltraGridColumn458.Header.VisiblePosition = 18
        UltraGridColumn458.Hidden = True
        UltraGridColumn459.Header.Caption = "Tp. Operación"
        UltraGridColumn459.Header.VisiblePosition = 19
        UltraGridColumn459.Width = 85
        UltraGridColumn460.Header.VisiblePosition = 20
        UltraGridColumn460.Width = 186
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn440, UltraGridColumn441, UltraGridColumn442, UltraGridColumn443, UltraGridColumn444, UltraGridColumn445, UltraGridColumn446, UltraGridColumn447, UltraGridColumn448, UltraGridColumn449, UltraGridColumn450, UltraGridColumn451, UltraGridColumn452, UltraGridColumn453, UltraGridColumn454, UltraGridColumn455, UltraGridColumn456, UltraGridColumn457, UltraGridColumn458, UltraGridColumn459, UltraGridColumn460})
        UltraGridColumn461.Header.VisiblePosition = 0
        UltraGridColumn462.Header.VisiblePosition = 1
        UltraGridColumn463.Header.VisiblePosition = 2
        UltraGridColumn464.Header.VisiblePosition = 3
        UltraGridColumn465.Header.VisiblePosition = 4
        UltraGridColumn466.Header.VisiblePosition = 5
        UltraGridColumn467.Header.VisiblePosition = 6
        UltraGridColumn468.Header.VisiblePosition = 7
        UltraGridColumn469.Header.VisiblePosition = 8
        UltraGridColumn470.Header.VisiblePosition = 9
        UltraGridColumn471.Header.VisiblePosition = 10
        UltraGridColumn472.Header.VisiblePosition = 11
        UltraGridColumn473.Header.VisiblePosition = 12
        UltraGridColumn474.Header.VisiblePosition = 13
        UltraGridColumn475.Header.VisiblePosition = 14
        UltraGridColumn476.Header.VisiblePosition = 15
        UltraGridColumn477.Header.VisiblePosition = 16
        UltraGridColumn1.Header.VisiblePosition = 17
        UltraGridColumn2.Header.VisiblePosition = 18
        UltraGridColumn3.Header.VisiblePosition = 19
        UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn461, UltraGridColumn462, UltraGridColumn463, UltraGridColumn464, UltraGridColumn465, UltraGridColumn466, UltraGridColumn467, UltraGridColumn468, UltraGridColumn469, UltraGridColumn470, UltraGridColumn471, UltraGridColumn472, UltraGridColumn473, UltraGridColumn474, UltraGridColumn475, UltraGridColumn476, UltraGridColumn477, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        UltraGridBand3.Hidden = True
        Me.ugvDetallePedidos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugvDetallePedidos.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugvDetallePedidos.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
        Me.ugvDetallePedidos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvDetallePedidos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance25.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Appearance = Appearance25
        Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance26
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance27.BackColor2 = System.Drawing.SystemColors.Control
        Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvDetallePedidos.DisplayLayout.GroupByBox.PromptAppearance = Appearance27
        Me.ugvDetallePedidos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvDetallePedidos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvDetallePedidos.DisplayLayout.Override.ActiveCellAppearance = Appearance28
        Appearance29.BackColor = System.Drawing.SystemColors.Highlight
        Appearance29.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvDetallePedidos.DisplayLayout.Override.ActiveRowAppearance = Appearance29
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvDetallePedidos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvDetallePedidos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvDetallePedidos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.Override.CardAreaAppearance = Appearance30
        Appearance31.BorderColor = System.Drawing.Color.Silver
        Appearance31.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvDetallePedidos.DisplayLayout.Override.CellAppearance = Appearance31
        Me.ugvDetallePedidos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvDetallePedidos.DisplayLayout.Override.CellPadding = 0
        Appearance32.BackColor = System.Drawing.SystemColors.Control
        Appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance32.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance32.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvDetallePedidos.DisplayLayout.Override.GroupByRowAppearance = Appearance32
        Appearance33.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance33.TextHAlignAsString = "Left"
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderAppearance = Appearance33
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvDetallePedidos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance34.BackColor = System.Drawing.SystemColors.Window
        Appearance34.BorderColor = System.Drawing.Color.Silver
        Me.ugvDetallePedidos.DisplayLayout.Override.RowAppearance = Appearance34
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugvDetallePedidos.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugvDetallePedidos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance35.BackColor = System.Drawing.Color.White
        Appearance35.BackColor2 = System.Drawing.Color.White
        Appearance35.TextVAlignAsString = "Bottom"
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryFooterAppearance = Appearance35
        Appearance36.BackColor = System.Drawing.Color.Tomato
        Appearance36.BackColor2 = System.Drawing.Color.Silver
        Appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryFooterCaptionAppearance = Appearance36
        Appearance37.BackColor = System.Drawing.Color.Tomato
        Appearance37.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance37.TextHAlignAsString = "Right"
        Me.ugvDetallePedidos.DisplayLayout.Override.SummaryValueAppearance = Appearance37
        Appearance38.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvDetallePedidos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance38
        Me.ugvDetallePedidos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvDetallePedidos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvDetallePedidos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvDetallePedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvDetallePedidos.Location = New System.Drawing.Point(6, 32)
        Me.ugvDetallePedidos.Name = "ugvDetallePedidos"
        Me.ugvDetallePedidos.Size = New System.Drawing.Size(987, 351)
        Me.ugvDetallePedidos.TabIndex = 1
        '
        'DtsRegistracionPagos
        '
        Me.DtsRegistracionPagos.DataSetName = "dtsRegistracionPagos"
        Me.DtsRegistracionPagos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.ugEfectivo)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(999, 386)
        '
        'ugEfectivo
        '
        Me.ugEfectivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ugEfectivo.DataSource = Me.EfectivoBindingSource
        Me.ugEfectivo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn162.Header.VisiblePosition = 0
        UltraGridColumn162.Hidden = True
        UltraGridColumn163.Header.Caption = "Tipo"
        UltraGridColumn163.Header.VisiblePosition = 1
        UltraGridColumn163.MaxWidth = 90
        UltraGridColumn163.Width = 58
        UltraGridColumn164.Header.Caption = "L"
        UltraGridColumn164.Header.VisiblePosition = 2
        UltraGridColumn164.MaxWidth = 25
        UltraGridColumn164.MinWidth = 25
        UltraGridColumn164.Width = 25
        Appearance39.TextHAlignAsString = "Right"
        UltraGridColumn165.CellAppearance = Appearance39
        UltraGridColumn165.Header.Caption = "Emisor"
        UltraGridColumn165.Header.VisiblePosition = 3
        UltraGridColumn165.MaxWidth = 50
        UltraGridColumn165.MinWidth = 50
        UltraGridColumn165.Width = 50
        Appearance40.TextHAlignAsString = "Right"
        UltraGridColumn166.CellAppearance = Appearance40
        UltraGridColumn166.Header.Caption = "Nro."
        UltraGridColumn166.Header.VisiblePosition = 4
        UltraGridColumn166.MaxWidth = 60
        UltraGridColumn166.MinWidth = 60
        UltraGridColumn166.Width = 60
        UltraGridColumn167.Header.VisiblePosition = 5
        UltraGridColumn167.Hidden = True
        Appearance41.TextHAlignAsString = "Right"
        UltraGridColumn168.CellAppearance = Appearance41
        UltraGridColumn168.Header.Caption = "Código"
        UltraGridColumn168.Header.VisiblePosition = 6
        UltraGridColumn168.MaxWidth = 50
        UltraGridColumn168.Width = 37
        UltraGridColumn169.Header.VisiblePosition = 7
        UltraGridColumn169.Hidden = True
        UltraGridColumn170.Header.VisiblePosition = 8
        UltraGridColumn170.Hidden = True
        UltraGridColumn171.Header.Caption = "Cliente"
        UltraGridColumn171.Header.VisiblePosition = 9
        UltraGridColumn171.Width = 151
        UltraGridColumn172.Header.Caption = "Dirección"
        UltraGridColumn172.Header.VisiblePosition = 10
        UltraGridColumn172.Width = 134
        UltraGridColumn173.Header.VisiblePosition = 11
        UltraGridColumn173.Hidden = True
        UltraGridColumn174.Header.VisiblePosition = 12
        UltraGridColumn174.Hidden = True
        UltraGridColumn175.Header.VisiblePosition = 13
        UltraGridColumn175.Hidden = True
        UltraGridColumn176.Header.VisiblePosition = 14
        UltraGridColumn176.Width = 61
        UltraGridColumn177.Header.VisiblePosition = 15
        UltraGridColumn177.Hidden = True
        UltraGridColumn178.Header.VisiblePosition = 16
        UltraGridColumn178.Hidden = True
        UltraGridColumn179.Header.VisiblePosition = 17
        UltraGridColumn179.Hidden = True
        UltraGridColumn179.MaxWidth = 70
        UltraGridColumn180.Header.VisiblePosition = 18
        UltraGridColumn180.Hidden = True
        UltraGridColumn181.Header.VisiblePosition = 19
        UltraGridColumn181.Hidden = True
        UltraGridColumn182.Header.VisiblePosition = 20
        UltraGridColumn182.Hidden = True
        UltraGridColumn183.Header.VisiblePosition = 21
        UltraGridColumn183.Hidden = True
        UltraGridColumn184.Header.VisiblePosition = 22
        UltraGridColumn184.Hidden = True
        UltraGridColumn185.Header.VisiblePosition = 23
        UltraGridColumn185.Hidden = True
        UltraGridColumn186.Header.VisiblePosition = 24
        UltraGridColumn186.Hidden = True
        Appearance42.TextHAlignAsString = "Right"
        UltraGridColumn187.CellAppearance = Appearance42
        UltraGridColumn187.Format = "N2"
        UltraGridColumn187.Header.Caption = "Importe"
        UltraGridColumn187.Header.VisiblePosition = 25
        UltraGridColumn187.MaskInput = "{double:-12.2}"
        UltraGridColumn187.MaxWidth = 70
        UltraGridColumn187.Width = 53
        UltraGridColumn188.Header.VisiblePosition = 26
        UltraGridColumn188.Hidden = True
        UltraGridColumn188.Width = 91
        UltraGridColumn189.Header.VisiblePosition = 27
        UltraGridColumn189.Hidden = True
        UltraGridColumn189.Width = 74
        UltraGridColumn190.Header.VisiblePosition = 28
        UltraGridColumn190.Hidden = True
        UltraGridColumn190.Width = 62
        UltraGridColumn191.Header.VisiblePosition = 29
        UltraGridColumn191.Hidden = True
        UltraGridColumn192.Header.VisiblePosition = 30
        UltraGridColumn192.Hidden = True
        UltraGridColumn192.Width = 70
        UltraGridColumn193.Header.VisiblePosition = 31
        UltraGridColumn193.Hidden = True
        UltraGridColumn193.Width = 79
        UltraGridColumn194.Header.VisiblePosition = 32
        UltraGridColumn194.Hidden = True
        UltraGridColumn194.Width = 97
        UltraGridColumn232.Header.VisiblePosition = 33
        UltraGridColumn232.Width = 84
        UltraGridColumn195.Header.VisiblePosition = 34
        UltraGridColumn196.Header.VisiblePosition = 35
        UltraGridBand4.Columns.AddRange(New Object() {UltraGridColumn162, UltraGridColumn163, UltraGridColumn164, UltraGridColumn165, UltraGridColumn166, UltraGridColumn167, UltraGridColumn168, UltraGridColumn169, UltraGridColumn170, UltraGridColumn171, UltraGridColumn172, UltraGridColumn173, UltraGridColumn174, UltraGridColumn175, UltraGridColumn176, UltraGridColumn177, UltraGridColumn178, UltraGridColumn179, UltraGridColumn180, UltraGridColumn181, UltraGridColumn182, UltraGridColumn183, UltraGridColumn184, UltraGridColumn185, UltraGridColumn186, UltraGridColumn187, UltraGridColumn188, UltraGridColumn189, UltraGridColumn190, UltraGridColumn191, UltraGridColumn192, UltraGridColumn193, UltraGridColumn194, UltraGridColumn232, UltraGridColumn195, UltraGridColumn196})
        Appearance43.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        UltraGridBand4.Header.Appearance = Appearance43
        Appearance44.TextHAlignAsString = "Right"
        SummarySettings2.Appearance = Appearance44
        SummarySettings2.DisplayFormat = "{0:N2}"
        SummarySettings2.GroupBySummaryValueAppearance = Appearance45
        UltraGridBand4.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings2})
        UltraGridBand4.SummaryFooterCaption = "Total Efectivo:"
        UltraGridColumn6.Header.VisiblePosition = 0
        UltraGridColumn6.Width = 17
        UltraGridColumn7.Header.VisiblePosition = 1
        UltraGridColumn7.Width = 43
        UltraGridColumn8.Header.VisiblePosition = 2
        UltraGridColumn8.Width = 35
        UltraGridColumn9.Header.VisiblePosition = 3
        UltraGridColumn9.Width = 33
        UltraGridColumn10.Header.VisiblePosition = 4
        UltraGridColumn10.Width = 46
        UltraGridColumn11.Header.VisiblePosition = 5
        UltraGridColumn11.Width = 35
        UltraGridColumn12.Header.VisiblePosition = 6
        UltraGridColumn12.Width = 20
        UltraGridColumn13.Header.VisiblePosition = 7
        UltraGridColumn13.Width = 38
        UltraGridColumn14.Header.VisiblePosition = 8
        UltraGridColumn14.Width = 28
        UltraGridColumn15.Header.VisiblePosition = 9
        UltraGridColumn15.Width = 28
        UltraGridColumn16.Header.VisiblePosition = 10
        UltraGridColumn16.Width = 31
        UltraGridColumn17.Header.VisiblePosition = 11
        UltraGridColumn17.Width = 28
        UltraGridColumn18.Header.VisiblePosition = 12
        UltraGridColumn18.Width = 23
        UltraGridColumn19.Header.VisiblePosition = 13
        UltraGridColumn19.Width = 35
        UltraGridColumn20.Header.VisiblePosition = 14
        UltraGridColumn20.Width = 38
        UltraGridColumn21.Header.VisiblePosition = 15
        UltraGridColumn21.Width = 29
        UltraGridColumn22.Header.VisiblePosition = 16
        UltraGridColumn22.Width = 33
        UltraGridColumn23.Header.VisiblePosition = 17
        UltraGridColumn23.Width = 45
        UltraGridColumn24.Header.VisiblePosition = 18
        UltraGridColumn24.Width = 39
        UltraGridColumn25.Header.VisiblePosition = 19
        UltraGridColumn25.Width = 35
        UltraGridColumn26.Header.VisiblePosition = 20
        UltraGridColumn26.Width = 35
        UltraGridBand5.Columns.AddRange(New Object() {UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26})
        UltraGridColumn27.Header.VisiblePosition = 0
        UltraGridColumn27.Width = 24
        UltraGridColumn28.Header.VisiblePosition = 1
        UltraGridColumn28.Width = 53
        UltraGridColumn29.Header.VisiblePosition = 2
        UltraGridColumn29.Width = 42
        UltraGridColumn30.Header.VisiblePosition = 3
        UltraGridColumn30.Width = 39
        UltraGridColumn31.Header.VisiblePosition = 4
        UltraGridColumn31.Width = 56
        UltraGridColumn32.Header.VisiblePosition = 5
        UltraGridColumn32.Width = 44
        UltraGridColumn33.Header.VisiblePosition = 6
        UltraGridColumn33.Width = 28
        UltraGridColumn34.Header.VisiblePosition = 7
        UltraGridColumn34.Width = 47
        UltraGridColumn35.Header.VisiblePosition = 8
        UltraGridColumn35.Width = 35
        UltraGridColumn36.Header.VisiblePosition = 9
        UltraGridColumn36.Width = 41
        UltraGridColumn37.Header.VisiblePosition = 10
        UltraGridColumn37.Width = 38
        UltraGridColumn38.Header.VisiblePosition = 11
        UltraGridColumn38.Width = 42
        UltraGridColumn39.Header.VisiblePosition = 12
        UltraGridColumn39.Width = 34
        UltraGridColumn40.Header.VisiblePosition = 13
        UltraGridColumn40.Width = 41
        UltraGridColumn41.Header.VisiblePosition = 14
        UltraGridColumn41.Width = 42
        UltraGridColumn42.Header.VisiblePosition = 15
        UltraGridColumn42.Width = 46
        UltraGridColumn43.Header.VisiblePosition = 16
        UltraGridColumn43.Width = 42
        UltraGridColumn4.Header.VisiblePosition = 17
        UltraGridColumn5.Header.VisiblePosition = 18
        UltraGridColumn272.Header.VisiblePosition = 19
        UltraGridBand6.Columns.AddRange(New Object() {UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn4, UltraGridColumn5, UltraGridColumn272})
        Me.ugEfectivo.DisplayLayout.BandsSerializer.Add(UltraGridBand4)
        Me.ugEfectivo.DisplayLayout.BandsSerializer.Add(UltraGridBand5)
        Me.ugEfectivo.DisplayLayout.BandsSerializer.Add(UltraGridBand6)
        Me.ugEfectivo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugEfectivo.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance46.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance46.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance46.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEfectivo.DisplayLayout.GroupByBox.Appearance = Appearance46
        Appearance47.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEfectivo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance47
        Me.ugEfectivo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugEfectivo.DisplayLayout.GroupByBox.Hidden = True
        Appearance48.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance48.BackColor2 = System.Drawing.SystemColors.Control
        Appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance48.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEfectivo.DisplayLayout.GroupByBox.PromptAppearance = Appearance48
        Me.ugEfectivo.DisplayLayout.MaxColScrollRegions = 1
        Me.ugEfectivo.DisplayLayout.MaxRowScrollRegions = 1
        Appearance49.BackColor = System.Drawing.SystemColors.Window
        Appearance49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugEfectivo.DisplayLayout.Override.ActiveCellAppearance = Appearance49
        Appearance50.BackColor = System.Drawing.SystemColors.Highlight
        Appearance50.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugEfectivo.DisplayLayout.Override.ActiveRowAppearance = Appearance50
        Me.ugEfectivo.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugEfectivo.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugEfectivo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugEfectivo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Me.ugEfectivo.DisplayLayout.Override.CardAreaAppearance = Appearance51
        Appearance52.BorderColor = System.Drawing.Color.Silver
        Appearance52.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugEfectivo.DisplayLayout.Override.CellAppearance = Appearance52
        Me.ugEfectivo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugEfectivo.DisplayLayout.Override.CellPadding = 0
        Appearance53.BackColor = System.Drawing.SystemColors.Control
        Appearance53.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance53.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance53.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEfectivo.DisplayLayout.Override.GroupByRowAppearance = Appearance53
        Appearance54.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance54.BackColor2 = System.Drawing.Color.Transparent
        Appearance54.TextHAlignAsString = "Left"
        Me.ugEfectivo.DisplayLayout.Override.HeaderAppearance = Appearance54
        Me.ugEfectivo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugEfectivo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance55.BackColor = System.Drawing.SystemColors.Window
        Appearance55.BorderColor = System.Drawing.Color.Silver
        Me.ugEfectivo.DisplayLayout.Override.RowAppearance = Appearance55
        Me.ugEfectivo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugEfectivo.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance56.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugEfectivo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance56
        Me.ugEfectivo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugEfectivo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugEfectivo.Location = New System.Drawing.Point(3, 3)
        Me.ugEfectivo.Name = "ugEfectivo"
        Me.ugEfectivo.Size = New System.Drawing.Size(734, 360)
        Me.ugEfectivo.TabIndex = 1
        Me.ugEfectivo.Text = "UltraGrid1"
        '
        'EfectivoBindingSource
        '
        Me.EfectivoBindingSource.DataMember = "Pedidos"
        Me.EfectivoBindingSource.DataSource = Me.DtsRegistracionPagos
        Me.EfectivoBindingSource.Filter = "Efectivo <> 0"
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.ugCtaCte)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(999, 386)
        '
        'ugCtaCte
        '
        Me.ugCtaCte.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ugCtaCte.DataSource = Me.CtaCteBindingSource
        Me.ugCtaCte.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn235.Header.VisiblePosition = 0
        UltraGridColumn235.Hidden = True
        UltraGridColumn236.Header.Caption = "Tipo"
        UltraGridColumn236.Header.VisiblePosition = 1
        UltraGridColumn236.MaxWidth = 90
        UltraGridColumn236.Width = 59
        UltraGridColumn237.Header.Caption = "L"
        UltraGridColumn237.Header.VisiblePosition = 2
        UltraGridColumn237.MaxWidth = 25
        UltraGridColumn237.MinWidth = 25
        UltraGridColumn237.Width = 25
        Appearance57.TextHAlignAsString = "Right"
        UltraGridColumn238.CellAppearance = Appearance57
        UltraGridColumn238.Header.Caption = "Emisor"
        UltraGridColumn238.Header.VisiblePosition = 3
        UltraGridColumn238.MaxWidth = 50
        UltraGridColumn238.MinWidth = 50
        UltraGridColumn238.Width = 50
        Appearance58.TextHAlignAsString = "Right"
        UltraGridColumn239.CellAppearance = Appearance58
        UltraGridColumn239.Header.Caption = "Nro."
        UltraGridColumn239.Header.VisiblePosition = 4
        UltraGridColumn239.MaxWidth = 60
        UltraGridColumn239.MinWidth = 60
        UltraGridColumn239.Width = 60
        UltraGridColumn240.Header.VisiblePosition = 5
        UltraGridColumn240.Hidden = True
        Appearance59.TextHAlignAsString = "Right"
        UltraGridColumn241.CellAppearance = Appearance59
        UltraGridColumn241.Header.Caption = "Código"
        UltraGridColumn241.Header.VisiblePosition = 6
        UltraGridColumn241.MaxWidth = 50
        UltraGridColumn241.Width = 37
        UltraGridColumn242.Header.VisiblePosition = 7
        UltraGridColumn242.Hidden = True
        UltraGridColumn243.Header.VisiblePosition = 8
        UltraGridColumn243.Hidden = True
        UltraGridColumn244.Header.Caption = "Cliente"
        UltraGridColumn244.Header.VisiblePosition = 9
        UltraGridColumn244.Width = 149
        UltraGridColumn245.Header.Caption = "Dirección"
        UltraGridColumn245.Header.VisiblePosition = 10
        UltraGridColumn245.Width = 135
        UltraGridColumn246.Header.VisiblePosition = 11
        UltraGridColumn246.Hidden = True
        UltraGridColumn247.Header.VisiblePosition = 12
        UltraGridColumn247.Hidden = True
        UltraGridColumn248.Header.VisiblePosition = 13
        UltraGridColumn248.Hidden = True
        UltraGridColumn249.Header.VisiblePosition = 14
        UltraGridColumn249.Width = 61
        UltraGridColumn250.Header.VisiblePosition = 15
        UltraGridColumn250.Hidden = True
        UltraGridColumn251.Header.VisiblePosition = 16
        UltraGridColumn251.Hidden = True
        UltraGridColumn252.Header.VisiblePosition = 17
        UltraGridColumn252.Hidden = True
        UltraGridColumn253.Header.VisiblePosition = 18
        UltraGridColumn253.Hidden = True
        UltraGridColumn254.Header.VisiblePosition = 19
        UltraGridColumn254.Hidden = True
        UltraGridColumn255.Header.VisiblePosition = 20
        UltraGridColumn255.Hidden = True
        UltraGridColumn256.Header.VisiblePosition = 21
        UltraGridColumn256.Hidden = True
        UltraGridColumn257.Header.VisiblePosition = 22
        UltraGridColumn257.Hidden = True
        UltraGridColumn258.Header.VisiblePosition = 23
        UltraGridColumn258.Hidden = True
        UltraGridColumn259.Header.VisiblePosition = 24
        UltraGridColumn259.Hidden = True
        Appearance60.TextHAlignAsString = "Right"
        UltraGridColumn260.CellAppearance = Appearance60
        UltraGridColumn260.Header.VisiblePosition = 25
        UltraGridColumn260.Hidden = True
        UltraGridColumn260.Width = 77
        Appearance61.TextHAlignAsString = "Right"
        UltraGridColumn261.CellAppearance = Appearance61
        UltraGridColumn261.Format = "N2"
        UltraGridColumn261.Header.Caption = "Importe"
        UltraGridColumn261.Header.VisiblePosition = 26
        UltraGridColumn261.MaskInput = "{double:-12.2}"
        UltraGridColumn261.MaxWidth = 70
        UltraGridColumn261.Width = 53
        UltraGridColumn262.Header.VisiblePosition = 27
        UltraGridColumn262.Hidden = True
        UltraGridColumn262.Width = 76
        UltraGridColumn263.Header.VisiblePosition = 28
        UltraGridColumn263.Hidden = True
        UltraGridColumn263.Width = 64
        UltraGridColumn264.Header.VisiblePosition = 29
        UltraGridColumn264.Hidden = True
        UltraGridColumn265.Header.VisiblePosition = 30
        UltraGridColumn265.Hidden = True
        UltraGridColumn265.Width = 73
        UltraGridColumn266.Header.VisiblePosition = 31
        UltraGridColumn266.Hidden = True
        UltraGridColumn266.Width = 83
        UltraGridColumn267.Header.VisiblePosition = 32
        UltraGridColumn267.Hidden = True
        UltraGridColumn267.Width = 102
        UltraGridColumn233.Header.VisiblePosition = 33
        UltraGridColumn233.Width = 84
        UltraGridColumn268.Header.VisiblePosition = 34
        UltraGridColumn269.Header.VisiblePosition = 35
        UltraGridBand7.Columns.AddRange(New Object() {UltraGridColumn235, UltraGridColumn236, UltraGridColumn237, UltraGridColumn238, UltraGridColumn239, UltraGridColumn240, UltraGridColumn241, UltraGridColumn242, UltraGridColumn243, UltraGridColumn244, UltraGridColumn245, UltraGridColumn246, UltraGridColumn247, UltraGridColumn248, UltraGridColumn249, UltraGridColumn250, UltraGridColumn251, UltraGridColumn252, UltraGridColumn253, UltraGridColumn254, UltraGridColumn255, UltraGridColumn256, UltraGridColumn257, UltraGridColumn258, UltraGridColumn259, UltraGridColumn260, UltraGridColumn261, UltraGridColumn262, UltraGridColumn263, UltraGridColumn264, UltraGridColumn265, UltraGridColumn266, UltraGridColumn267, UltraGridColumn233, UltraGridColumn268, UltraGridColumn269})
        Appearance62.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        UltraGridBand7.Header.Appearance = Appearance62
        Appearance63.TextHAlignAsString = "Right"
        SummarySettings3.Appearance = Appearance63
        SummarySettings3.DisplayFormat = "{0:N2}"
        SummarySettings3.GroupBySummaryValueAppearance = Appearance64
        UltraGridBand7.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings3})
        UltraGridBand7.SummaryFooterCaption = "Total Cta. Cte.:"
        UltraGridColumn44.Header.VisiblePosition = 0
        UltraGridColumn44.Width = 17
        UltraGridColumn45.Header.VisiblePosition = 1
        UltraGridColumn45.Width = 43
        UltraGridColumn46.Header.VisiblePosition = 2
        UltraGridColumn46.Width = 35
        UltraGridColumn47.Header.VisiblePosition = 3
        UltraGridColumn47.Width = 33
        UltraGridColumn48.Header.VisiblePosition = 4
        UltraGridColumn48.Width = 46
        UltraGridColumn49.Header.VisiblePosition = 5
        UltraGridColumn49.Width = 35
        UltraGridColumn50.Header.VisiblePosition = 6
        UltraGridColumn50.Width = 20
        UltraGridColumn51.Header.VisiblePosition = 7
        UltraGridColumn51.Width = 38
        UltraGridColumn52.Header.VisiblePosition = 8
        UltraGridColumn52.Width = 28
        UltraGridColumn53.Header.VisiblePosition = 9
        UltraGridColumn53.Width = 28
        UltraGridColumn54.Header.VisiblePosition = 10
        UltraGridColumn54.Width = 31
        UltraGridColumn55.Header.VisiblePosition = 11
        UltraGridColumn55.Width = 28
        UltraGridColumn56.Header.VisiblePosition = 12
        UltraGridColumn56.Width = 23
        UltraGridColumn57.Header.VisiblePosition = 13
        UltraGridColumn57.Width = 35
        UltraGridColumn58.Header.VisiblePosition = 14
        UltraGridColumn58.Width = 38
        UltraGridColumn59.Header.VisiblePosition = 15
        UltraGridColumn59.Width = 29
        UltraGridColumn60.Header.VisiblePosition = 16
        UltraGridColumn60.Width = 33
        UltraGridColumn61.Header.VisiblePosition = 17
        UltraGridColumn61.Width = 45
        UltraGridColumn62.Header.VisiblePosition = 18
        UltraGridColumn62.Width = 39
        UltraGridColumn63.Header.VisiblePosition = 19
        UltraGridColumn63.Width = 35
        UltraGridColumn64.Header.VisiblePosition = 20
        UltraGridColumn64.Width = 35
        UltraGridBand8.Columns.AddRange(New Object() {UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64})
        UltraGridColumn65.Header.VisiblePosition = 0
        UltraGridColumn65.Width = 24
        UltraGridColumn66.Header.VisiblePosition = 1
        UltraGridColumn66.Width = 53
        UltraGridColumn67.Header.VisiblePosition = 2
        UltraGridColumn67.Width = 42
        UltraGridColumn68.Header.VisiblePosition = 3
        UltraGridColumn68.Width = 39
        UltraGridColumn69.Header.VisiblePosition = 4
        UltraGridColumn69.Width = 56
        UltraGridColumn70.Header.VisiblePosition = 5
        UltraGridColumn70.Width = 44
        UltraGridColumn71.Header.VisiblePosition = 6
        UltraGridColumn71.Width = 28
        UltraGridColumn72.Header.VisiblePosition = 7
        UltraGridColumn72.Width = 47
        UltraGridColumn73.Header.VisiblePosition = 8
        UltraGridColumn73.Width = 35
        UltraGridColumn74.Header.VisiblePosition = 9
        UltraGridColumn74.Width = 41
        UltraGridColumn75.Header.VisiblePosition = 10
        UltraGridColumn75.Width = 38
        UltraGridColumn76.Header.VisiblePosition = 11
        UltraGridColumn76.Width = 42
        UltraGridColumn77.Header.VisiblePosition = 12
        UltraGridColumn77.Width = 34
        UltraGridColumn78.Header.VisiblePosition = 13
        UltraGridColumn78.Width = 41
        UltraGridColumn79.Header.VisiblePosition = 14
        UltraGridColumn79.Width = 42
        UltraGridColumn80.Header.VisiblePosition = 15
        UltraGridColumn80.Width = 46
        UltraGridColumn81.Header.VisiblePosition = 16
        UltraGridColumn81.Width = 42
        UltraGridColumn273.Header.VisiblePosition = 17
        UltraGridColumn274.Header.VisiblePosition = 18
        UltraGridColumn275.Header.VisiblePosition = 19
        UltraGridBand9.Columns.AddRange(New Object() {UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn273, UltraGridColumn274, UltraGridColumn275})
        Me.ugCtaCte.DisplayLayout.BandsSerializer.Add(UltraGridBand7)
        Me.ugCtaCte.DisplayLayout.BandsSerializer.Add(UltraGridBand8)
        Me.ugCtaCte.DisplayLayout.BandsSerializer.Add(UltraGridBand9)
        Me.ugCtaCte.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCtaCte.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance65.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance65.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance65.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance65.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCtaCte.DisplayLayout.GroupByBox.Appearance = Appearance65
        Appearance66.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCtaCte.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance66
        Me.ugCtaCte.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCtaCte.DisplayLayout.GroupByBox.Hidden = True
        Appearance67.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance67.BackColor2 = System.Drawing.SystemColors.Control
        Appearance67.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance67.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCtaCte.DisplayLayout.GroupByBox.PromptAppearance = Appearance67
        Me.ugCtaCte.DisplayLayout.MaxColScrollRegions = 1
        Me.ugCtaCte.DisplayLayout.MaxRowScrollRegions = 1
        Appearance68.BackColor = System.Drawing.SystemColors.Window
        Appearance68.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugCtaCte.DisplayLayout.Override.ActiveCellAppearance = Appearance68
        Appearance69.BackColor = System.Drawing.SystemColors.Highlight
        Appearance69.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugCtaCte.DisplayLayout.Override.ActiveRowAppearance = Appearance69
        Me.ugCtaCte.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugCtaCte.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugCtaCte.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugCtaCte.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance70.BackColor = System.Drawing.SystemColors.Window
        Me.ugCtaCte.DisplayLayout.Override.CardAreaAppearance = Appearance70
        Appearance71.BorderColor = System.Drawing.Color.Silver
        Appearance71.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugCtaCte.DisplayLayout.Override.CellAppearance = Appearance71
        Me.ugCtaCte.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugCtaCte.DisplayLayout.Override.CellPadding = 0
        Appearance72.BackColor = System.Drawing.SystemColors.Control
        Appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance72.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance72.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCtaCte.DisplayLayout.Override.GroupByRowAppearance = Appearance72
        Appearance73.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance73.BackColor2 = System.Drawing.Color.Transparent
        Appearance73.TextHAlignAsString = "Left"
        Me.ugCtaCte.DisplayLayout.Override.HeaderAppearance = Appearance73
        Me.ugCtaCte.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugCtaCte.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance74.BackColor = System.Drawing.SystemColors.Window
        Appearance74.BorderColor = System.Drawing.Color.Silver
        Me.ugCtaCte.DisplayLayout.Override.RowAppearance = Appearance74
        Me.ugCtaCte.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugCtaCte.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance75.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugCtaCte.DisplayLayout.Override.TemplateAddRowAppearance = Appearance75
        Me.ugCtaCte.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugCtaCte.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugCtaCte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugCtaCte.Location = New System.Drawing.Point(3, 3)
        Me.ugCtaCte.Name = "ugCtaCte"
        Me.ugCtaCte.Size = New System.Drawing.Size(734, 360)
        Me.ugCtaCte.TabIndex = 1
        Me.ugCtaCte.Text = "UltraGrid2"
        '
        'CtaCteBindingSource
        '
        Me.CtaCteBindingSource.DataMember = "Pedidos"
        Me.CtaCteBindingSource.DataSource = Me.DtsRegistracionPagos
        Me.CtaCteBindingSource.Filter = "CuentaCorriente <> 0"
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.ugChequesAUX)
        Me.UltraTabPageControl4.Controls.Add(Me.ugCheque)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(999, 386)
        '
        'ugChequesAUX
        '
        Appearance76.BackColor = System.Drawing.SystemColors.Window
        Appearance76.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugChequesAUX.DisplayLayout.Appearance = Appearance76
        Me.ugChequesAUX.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugChequesAUX.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance77.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance77.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance77.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance77.BorderColor = System.Drawing.SystemColors.Window
        Me.ugChequesAUX.DisplayLayout.GroupByBox.Appearance = Appearance77
        Appearance78.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugChequesAUX.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance78
        Me.ugChequesAUX.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugChequesAUX.DisplayLayout.GroupByBox.Hidden = True
        Appearance79.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance79.BackColor2 = System.Drawing.SystemColors.Control
        Appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance79.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugChequesAUX.DisplayLayout.GroupByBox.PromptAppearance = Appearance79
        Me.ugChequesAUX.DisplayLayout.MaxColScrollRegions = 1
        Me.ugChequesAUX.DisplayLayout.MaxRowScrollRegions = 1
        Appearance80.BackColor = System.Drawing.SystemColors.Window
        Appearance80.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugChequesAUX.DisplayLayout.Override.ActiveCellAppearance = Appearance80
        Appearance81.BackColor = System.Drawing.SystemColors.Highlight
        Appearance81.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugChequesAUX.DisplayLayout.Override.ActiveRowAppearance = Appearance81
        Me.ugChequesAUX.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugChequesAUX.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugChequesAUX.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugChequesAUX.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance82.BackColor = System.Drawing.SystemColors.Window
        Me.ugChequesAUX.DisplayLayout.Override.CardAreaAppearance = Appearance82
        Appearance83.BorderColor = System.Drawing.Color.Silver
        Appearance83.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugChequesAUX.DisplayLayout.Override.CellAppearance = Appearance83
        Me.ugChequesAUX.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugChequesAUX.DisplayLayout.Override.CellPadding = 0
        Appearance84.BackColor = System.Drawing.SystemColors.Control
        Appearance84.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance84.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance84.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance84.BorderColor = System.Drawing.SystemColors.Window
        Me.ugChequesAUX.DisplayLayout.Override.GroupByRowAppearance = Appearance84
        Appearance85.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance85.TextHAlignAsString = "Left"
        Me.ugChequesAUX.DisplayLayout.Override.HeaderAppearance = Appearance85
        Me.ugChequesAUX.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugChequesAUX.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance86.BackColor = System.Drawing.SystemColors.Window
        Appearance86.BorderColor = System.Drawing.Color.Silver
        Me.ugChequesAUX.DisplayLayout.Override.RowAppearance = Appearance86
        Me.ugChequesAUX.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance87.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugChequesAUX.DisplayLayout.Override.TemplateAddRowAppearance = Appearance87
        Me.ugChequesAUX.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugChequesAUX.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugChequesAUX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugChequesAUX.Location = New System.Drawing.Point(796, 76)
        Me.ugChequesAUX.Name = "ugChequesAUX"
        Me.ugChequesAUX.Size = New System.Drawing.Size(53, 62)
        Me.ugChequesAUX.TabIndex = 1
        Me.ugChequesAUX.Text = "UltraGrid3"
        Me.ugChequesAUX.Visible = False
        '
        'ugCheque
        '
        Me.ugCheque.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ugCheque.DataSource = Me.ChequesBindingSource
        Me.ugCheque.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn309.Header.VisiblePosition = 0
        UltraGridColumn309.Hidden = True
        UltraGridColumn310.Header.Caption = "Tipo"
        UltraGridColumn310.Header.VisiblePosition = 1
        UltraGridColumn310.MaxWidth = 90
        UltraGridColumn310.Width = 63
        UltraGridColumn311.Header.Caption = "L"
        UltraGridColumn311.Header.VisiblePosition = 2
        UltraGridColumn311.MaxWidth = 25
        UltraGridColumn311.MinWidth = 25
        UltraGridColumn311.Width = 25
        Appearance88.TextHAlignAsString = "Right"
        UltraGridColumn312.CellAppearance = Appearance88
        UltraGridColumn312.Header.Caption = "Emisor"
        UltraGridColumn312.Header.VisiblePosition = 3
        UltraGridColumn312.MaxWidth = 50
        UltraGridColumn312.MinWidth = 50
        UltraGridColumn312.Width = 50
        Appearance89.TextHAlignAsString = "Right"
        UltraGridColumn313.CellAppearance = Appearance89
        UltraGridColumn313.Header.Caption = "Nro."
        UltraGridColumn313.Header.VisiblePosition = 4
        UltraGridColumn313.MaxWidth = 60
        UltraGridColumn313.MinWidth = 60
        UltraGridColumn313.Width = 60
        UltraGridColumn314.Header.VisiblePosition = 5
        UltraGridColumn314.Hidden = True
        Appearance90.TextHAlignAsString = "Right"
        UltraGridColumn315.CellAppearance = Appearance90
        UltraGridColumn315.Header.Caption = "Código"
        UltraGridColumn315.Header.VisiblePosition = 6
        UltraGridColumn315.MaxWidth = 50
        UltraGridColumn315.MinWidth = 50
        UltraGridColumn315.Width = 50
        UltraGridColumn316.Header.VisiblePosition = 7
        UltraGridColumn316.Hidden = True
        UltraGridColumn317.Header.VisiblePosition = 8
        UltraGridColumn317.Hidden = True
        UltraGridColumn318.Header.Caption = "Cliente"
        UltraGridColumn318.Header.VisiblePosition = 9
        UltraGridColumn318.Width = 137
        UltraGridColumn319.Header.Caption = "Dirección"
        UltraGridColumn319.Header.VisiblePosition = 10
        UltraGridColumn319.Width = 133
        UltraGridColumn320.Header.VisiblePosition = 11
        UltraGridColumn320.Hidden = True
        UltraGridColumn321.Header.VisiblePosition = 12
        UltraGridColumn321.Hidden = True
        UltraGridColumn322.Header.VisiblePosition = 13
        UltraGridColumn322.Hidden = True
        UltraGridColumn323.Header.VisiblePosition = 14
        UltraGridColumn323.Width = 60
        UltraGridColumn324.Header.VisiblePosition = 15
        UltraGridColumn324.Hidden = True
        UltraGridColumn325.Header.VisiblePosition = 16
        UltraGridColumn325.Hidden = True
        UltraGridColumn326.Header.VisiblePosition = 17
        UltraGridColumn326.Hidden = True
        UltraGridColumn327.Header.VisiblePosition = 18
        UltraGridColumn327.Hidden = True
        UltraGridColumn328.Header.VisiblePosition = 19
        UltraGridColumn328.Hidden = True
        UltraGridColumn329.Header.VisiblePosition = 20
        UltraGridColumn329.Hidden = True
        UltraGridColumn330.Header.VisiblePosition = 21
        UltraGridColumn330.Hidden = True
        UltraGridColumn331.Header.VisiblePosition = 22
        UltraGridColumn331.Hidden = True
        UltraGridColumn332.Header.VisiblePosition = 23
        UltraGridColumn332.Hidden = True
        UltraGridColumn333.Header.VisiblePosition = 24
        UltraGridColumn333.Hidden = True
        Appearance91.TextHAlignAsString = "Right"
        UltraGridColumn334.CellAppearance = Appearance91
        UltraGridColumn334.Header.Caption = "Importe"
        UltraGridColumn334.Header.VisiblePosition = 25
        UltraGridColumn334.Hidden = True
        UltraGridColumn334.Width = 86
        UltraGridColumn335.Header.VisiblePosition = 26
        UltraGridColumn335.Hidden = True
        UltraGridColumn335.Width = 91
        Appearance92.TextHAlignAsString = "Right"
        UltraGridColumn336.CellAppearance = Appearance92
        UltraGridColumn336.Format = "N2"
        UltraGridColumn336.Header.Caption = "Importe"
        UltraGridColumn336.Header.VisiblePosition = 27
        UltraGridColumn336.MaskInput = "{double:-12.2}"
        UltraGridColumn336.MaxWidth = 70
        UltraGridColumn336.Width = 52
        UltraGridColumn337.Header.VisiblePosition = 28
        UltraGridColumn337.Hidden = True
        UltraGridColumn337.Width = 62
        UltraGridColumn338.Header.VisiblePosition = 29
        UltraGridColumn338.Hidden = True
        UltraGridColumn339.Header.VisiblePosition = 30
        UltraGridColumn339.Hidden = True
        UltraGridColumn339.Width = 72
        UltraGridColumn340.Header.VisiblePosition = 31
        UltraGridColumn340.Hidden = True
        UltraGridColumn340.Width = 82
        UltraGridColumn341.Header.VisiblePosition = 32
        UltraGridColumn341.Hidden = True
        UltraGridColumn341.Width = 101
        UltraGridColumn234.Header.VisiblePosition = 33
        UltraGridColumn234.Width = 83
        UltraGridColumn342.Header.VisiblePosition = 34
        UltraGridColumn343.Header.VisiblePosition = 35
        UltraGridBand10.Columns.AddRange(New Object() {UltraGridColumn309, UltraGridColumn310, UltraGridColumn311, UltraGridColumn312, UltraGridColumn313, UltraGridColumn314, UltraGridColumn315, UltraGridColumn316, UltraGridColumn317, UltraGridColumn318, UltraGridColumn319, UltraGridColumn320, UltraGridColumn321, UltraGridColumn322, UltraGridColumn323, UltraGridColumn324, UltraGridColumn325, UltraGridColumn326, UltraGridColumn327, UltraGridColumn328, UltraGridColumn329, UltraGridColumn330, UltraGridColumn331, UltraGridColumn332, UltraGridColumn333, UltraGridColumn334, UltraGridColumn335, UltraGridColumn336, UltraGridColumn337, UltraGridColumn338, UltraGridColumn339, UltraGridColumn340, UltraGridColumn341, UltraGridColumn234, UltraGridColumn342, UltraGridColumn343})
        Appearance93.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        UltraGridBand10.Header.Appearance = Appearance93
        Appearance94.TextHAlignAsString = "Right"
        SummarySettings4.Appearance = Appearance94
        SummarySettings4.DisplayFormat = "{0:N2}"
        SummarySettings4.GroupBySummaryValueAppearance = Appearance95
        UltraGridBand10.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings4})
        UltraGridBand10.SummaryFooterCaption = "Total Cheques:"
        UltraGridColumn82.Header.VisiblePosition = 0
        UltraGridColumn82.Width = 17
        UltraGridColumn83.Header.VisiblePosition = 1
        UltraGridColumn83.Width = 43
        UltraGridColumn84.Header.VisiblePosition = 2
        UltraGridColumn84.Width = 35
        UltraGridColumn85.Header.VisiblePosition = 3
        UltraGridColumn85.Width = 33
        UltraGridColumn86.Header.VisiblePosition = 4
        UltraGridColumn86.Width = 46
        UltraGridColumn87.Header.VisiblePosition = 5
        UltraGridColumn87.Width = 35
        UltraGridColumn88.Header.VisiblePosition = 6
        UltraGridColumn88.Width = 20
        UltraGridColumn89.Header.VisiblePosition = 7
        UltraGridColumn89.Width = 38
        UltraGridColumn90.Header.VisiblePosition = 8
        UltraGridColumn90.Width = 28
        UltraGridColumn91.Header.VisiblePosition = 9
        UltraGridColumn91.Width = 28
        UltraGridColumn92.Header.VisiblePosition = 10
        UltraGridColumn92.Width = 31
        UltraGridColumn93.Header.VisiblePosition = 11
        UltraGridColumn93.Width = 28
        UltraGridColumn94.Header.VisiblePosition = 12
        UltraGridColumn94.Width = 23
        UltraGridColumn95.Header.VisiblePosition = 13
        UltraGridColumn95.Width = 35
        UltraGridColumn96.Header.VisiblePosition = 14
        UltraGridColumn96.Width = 38
        UltraGridColumn97.Header.VisiblePosition = 15
        UltraGridColumn97.Width = 29
        UltraGridColumn98.Header.VisiblePosition = 16
        UltraGridColumn98.Width = 33
        UltraGridColumn99.Header.VisiblePosition = 17
        UltraGridColumn99.Width = 45
        UltraGridColumn100.Header.VisiblePosition = 18
        UltraGridColumn100.Width = 39
        UltraGridColumn101.Header.VisiblePosition = 19
        UltraGridColumn101.Width = 35
        UltraGridColumn102.Header.VisiblePosition = 20
        UltraGridColumn102.Width = 35
        UltraGridBand11.Columns.AddRange(New Object() {UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102})
        UltraGridColumn103.Header.VisiblePosition = 0
        UltraGridColumn103.Width = 24
        UltraGridColumn104.Header.VisiblePosition = 1
        UltraGridColumn104.Width = 53
        UltraGridColumn105.Header.VisiblePosition = 2
        UltraGridColumn105.Width = 42
        UltraGridColumn106.Header.VisiblePosition = 3
        UltraGridColumn106.Width = 39
        UltraGridColumn107.Header.VisiblePosition = 4
        UltraGridColumn107.Width = 56
        UltraGridColumn108.Header.VisiblePosition = 5
        UltraGridColumn108.Width = 44
        UltraGridColumn109.Header.VisiblePosition = 6
        UltraGridColumn109.Width = 28
        UltraGridColumn110.Header.VisiblePosition = 7
        UltraGridColumn110.Width = 47
        UltraGridColumn111.Header.VisiblePosition = 8
        UltraGridColumn111.Width = 35
        UltraGridColumn112.Header.VisiblePosition = 9
        UltraGridColumn112.Width = 41
        UltraGridColumn113.Header.VisiblePosition = 10
        UltraGridColumn113.Width = 38
        UltraGridColumn114.Header.VisiblePosition = 11
        UltraGridColumn114.Width = 42
        UltraGridColumn115.Header.VisiblePosition = 12
        UltraGridColumn115.Width = 34
        UltraGridColumn116.Header.VisiblePosition = 13
        UltraGridColumn116.Width = 41
        UltraGridColumn117.Header.VisiblePosition = 14
        UltraGridColumn117.Width = 42
        UltraGridColumn118.Header.VisiblePosition = 15
        UltraGridColumn118.Width = 46
        UltraGridColumn119.Header.VisiblePosition = 16
        UltraGridColumn119.Width = 42
        UltraGridColumn276.Header.VisiblePosition = 17
        UltraGridColumn277.Header.VisiblePosition = 18
        UltraGridColumn278.Header.VisiblePosition = 19
        UltraGridBand12.Columns.AddRange(New Object() {UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114, UltraGridColumn115, UltraGridColumn116, UltraGridColumn117, UltraGridColumn118, UltraGridColumn119, UltraGridColumn276, UltraGridColumn277, UltraGridColumn278})
        Me.ugCheque.DisplayLayout.BandsSerializer.Add(UltraGridBand10)
        Me.ugCheque.DisplayLayout.BandsSerializer.Add(UltraGridBand11)
        Me.ugCheque.DisplayLayout.BandsSerializer.Add(UltraGridBand12)
        Me.ugCheque.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCheque.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance96.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance96.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance96.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance96.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCheque.DisplayLayout.GroupByBox.Appearance = Appearance96
        Appearance97.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCheque.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance97
        Me.ugCheque.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugCheque.DisplayLayout.GroupByBox.Hidden = True
        Appearance98.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance98.BackColor2 = System.Drawing.SystemColors.Control
        Appearance98.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance98.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugCheque.DisplayLayout.GroupByBox.PromptAppearance = Appearance98
        Me.ugCheque.DisplayLayout.MaxColScrollRegions = 1
        Me.ugCheque.DisplayLayout.MaxRowScrollRegions = 1
        Appearance99.BackColor = System.Drawing.SystemColors.Window
        Appearance99.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugCheque.DisplayLayout.Override.ActiveCellAppearance = Appearance99
        Appearance100.BackColor = System.Drawing.SystemColors.Highlight
        Appearance100.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugCheque.DisplayLayout.Override.ActiveRowAppearance = Appearance100
        Me.ugCheque.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugCheque.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugCheque.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugCheque.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance101.BackColor = System.Drawing.SystemColors.Window
        Me.ugCheque.DisplayLayout.Override.CardAreaAppearance = Appearance101
        Appearance102.BorderColor = System.Drawing.Color.Silver
        Appearance102.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugCheque.DisplayLayout.Override.CellAppearance = Appearance102
        Me.ugCheque.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugCheque.DisplayLayout.Override.CellPadding = 0
        Appearance103.BackColor = System.Drawing.SystemColors.Control
        Appearance103.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance103.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance103.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance103.BorderColor = System.Drawing.SystemColors.Window
        Me.ugCheque.DisplayLayout.Override.GroupByRowAppearance = Appearance103
        Appearance104.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance104.BackColor2 = System.Drawing.Color.Transparent
        Appearance104.TextHAlignAsString = "Left"
        Me.ugCheque.DisplayLayout.Override.HeaderAppearance = Appearance104
        Me.ugCheque.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugCheque.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance105.BackColor = System.Drawing.SystemColors.Window
        Appearance105.BorderColor = System.Drawing.Color.Silver
        Me.ugCheque.DisplayLayout.Override.RowAppearance = Appearance105
        Me.ugCheque.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugCheque.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance106.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugCheque.DisplayLayout.Override.TemplateAddRowAppearance = Appearance106
        Me.ugCheque.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugCheque.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugCheque.Location = New System.Drawing.Point(3, 3)
        Me.ugCheque.Name = "ugCheque"
        Me.ugCheque.Size = New System.Drawing.Size(734, 360)
        Me.ugCheque.TabIndex = 0
        Me.ugCheque.Text = "UltraGrid3"
        '
        'ChequesBindingSource
        '
        Me.ChequesBindingSource.DataMember = "Pedidos"
        Me.ChequesBindingSource.DataSource = Me.DtsRegistracionPagos
        Me.ChequesBindingSource.Filter = "TotalCheques <> 0"
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.ugNc)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(999, 386)
        '
        'ugNc
        '
        Me.ugNc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ugNc.DataSource = Me.NCBindingSource
        Me.ugNc.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn382.Header.VisiblePosition = 0
        UltraGridColumn382.Hidden = True
        UltraGridColumn383.Header.Caption = "Tipo"
        UltraGridColumn383.Header.VisiblePosition = 1
        UltraGridColumn383.MaxWidth = 90
        UltraGridColumn383.Width = 63
        UltraGridColumn384.Header.Caption = "L"
        UltraGridColumn384.Header.VisiblePosition = 2
        UltraGridColumn384.MaxWidth = 25
        UltraGridColumn384.MinWidth = 25
        UltraGridColumn384.Width = 25
        Appearance107.TextHAlignAsString = "Right"
        UltraGridColumn385.CellAppearance = Appearance107
        UltraGridColumn385.Header.Caption = "Emisor"
        UltraGridColumn385.Header.VisiblePosition = 3
        UltraGridColumn385.MaxWidth = 50
        UltraGridColumn385.MinWidth = 50
        UltraGridColumn385.Width = 50
        Appearance108.TextHAlignAsString = "Right"
        UltraGridColumn386.CellAppearance = Appearance108
        UltraGridColumn386.Header.Caption = "Nro."
        UltraGridColumn386.Header.VisiblePosition = 4
        UltraGridColumn386.MaxWidth = 60
        UltraGridColumn386.MinWidth = 60
        UltraGridColumn386.Width = 60
        UltraGridColumn387.Header.VisiblePosition = 5
        UltraGridColumn387.Hidden = True
        Appearance109.TextHAlignAsString = "Right"
        UltraGridColumn388.CellAppearance = Appearance109
        UltraGridColumn388.Header.Caption = "Código"
        UltraGridColumn388.Header.VisiblePosition = 6
        UltraGridColumn388.MaxWidth = 50
        UltraGridColumn388.MinWidth = 50
        UltraGridColumn388.Width = 50
        UltraGridColumn389.Header.VisiblePosition = 7
        UltraGridColumn389.Hidden = True
        UltraGridColumn390.Header.VisiblePosition = 8
        UltraGridColumn390.Hidden = True
        UltraGridColumn391.Header.Caption = "Cliente"
        UltraGridColumn391.Header.VisiblePosition = 9
        UltraGridColumn391.Width = 136
        UltraGridColumn392.Header.Caption = "Dirección"
        UltraGridColumn392.Header.VisiblePosition = 10
        UltraGridColumn392.Width = 134
        UltraGridColumn393.Header.VisiblePosition = 11
        UltraGridColumn393.Hidden = True
        UltraGridColumn394.Header.VisiblePosition = 12
        UltraGridColumn394.Hidden = True
        UltraGridColumn395.Header.VisiblePosition = 13
        UltraGridColumn395.Hidden = True
        UltraGridColumn396.Header.VisiblePosition = 14
        UltraGridColumn396.Width = 60
        UltraGridColumn397.Header.VisiblePosition = 15
        UltraGridColumn397.Hidden = True
        UltraGridColumn398.Header.VisiblePosition = 16
        UltraGridColumn398.Hidden = True
        UltraGridColumn399.Header.VisiblePosition = 17
        UltraGridColumn399.Hidden = True
        UltraGridColumn400.Header.VisiblePosition = 18
        UltraGridColumn400.Hidden = True
        UltraGridColumn401.Header.VisiblePosition = 19
        UltraGridColumn401.Hidden = True
        UltraGridColumn402.Header.VisiblePosition = 20
        UltraGridColumn402.Hidden = True
        UltraGridColumn403.Header.VisiblePosition = 21
        UltraGridColumn403.Hidden = True
        UltraGridColumn404.Header.VisiblePosition = 22
        UltraGridColumn404.Hidden = True
        UltraGridColumn405.Header.VisiblePosition = 23
        UltraGridColumn405.Hidden = True
        UltraGridColumn406.Header.VisiblePosition = 24
        UltraGridColumn406.Hidden = True
        Appearance110.TextHAlignAsString = "Right"
        UltraGridColumn407.CellAppearance = Appearance110
        UltraGridColumn407.Header.Caption = "Importe"
        UltraGridColumn407.Header.VisiblePosition = 25
        UltraGridColumn407.Hidden = True
        UltraGridColumn407.Width = 83
        UltraGridColumn408.Header.VisiblePosition = 26
        UltraGridColumn408.Hidden = True
        UltraGridColumn408.Width = 91
        UltraGridColumn409.Header.VisiblePosition = 27
        UltraGridColumn409.Hidden = True
        UltraGridColumn409.Width = 74
        Appearance111.TextHAlignAsString = "Right"
        UltraGridColumn410.CellAppearance = Appearance111
        UltraGridColumn410.Format = "N2"
        UltraGridColumn410.Header.Caption = "Importe"
        UltraGridColumn410.Header.VisiblePosition = 28
        UltraGridColumn410.MaskInput = "{double:-12.2}"
        UltraGridColumn410.MaxWidth = 70
        UltraGridColumn410.Width = 52
        UltraGridColumn411.Header.VisiblePosition = 29
        UltraGridColumn411.Hidden = True
        UltraGridColumn412.Header.VisiblePosition = 30
        UltraGridColumn412.Hidden = True
        UltraGridColumn412.Width = 74
        UltraGridColumn413.Header.VisiblePosition = 31
        UltraGridColumn413.Hidden = True
        UltraGridColumn413.Width = 84
        UltraGridColumn414.Header.VisiblePosition = 32
        UltraGridColumn414.Hidden = True
        UltraGridColumn414.Width = 102
        UltraGridColumn270.Header.VisiblePosition = 33
        UltraGridColumn270.Width = 83
        UltraGridColumn415.Header.VisiblePosition = 34
        UltraGridColumn417.Header.VisiblePosition = 35
        UltraGridBand13.Columns.AddRange(New Object() {UltraGridColumn382, UltraGridColumn383, UltraGridColumn384, UltraGridColumn385, UltraGridColumn386, UltraGridColumn387, UltraGridColumn388, UltraGridColumn389, UltraGridColumn390, UltraGridColumn391, UltraGridColumn392, UltraGridColumn393, UltraGridColumn394, UltraGridColumn395, UltraGridColumn396, UltraGridColumn397, UltraGridColumn398, UltraGridColumn399, UltraGridColumn400, UltraGridColumn401, UltraGridColumn402, UltraGridColumn403, UltraGridColumn404, UltraGridColumn405, UltraGridColumn406, UltraGridColumn407, UltraGridColumn408, UltraGridColumn409, UltraGridColumn410, UltraGridColumn411, UltraGridColumn412, UltraGridColumn413, UltraGridColumn414, UltraGridColumn270, UltraGridColumn415, UltraGridColumn417})
        Appearance112.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        UltraGridBand13.Header.Appearance = Appearance112
        Appearance113.TextHAlignAsString = "Right"
        SummarySettings5.Appearance = Appearance113
        SummarySettings5.DisplayFormat = "{0:N2}"
        SummarySettings5.GroupBySummaryValueAppearance = Appearance114
        UltraGridBand13.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings5})
        UltraGridBand13.SummaryFooterCaption = "Total N. Crédito:"
        UltraGridColumn120.Header.VisiblePosition = 0
        UltraGridColumn120.Width = 17
        UltraGridColumn121.Header.VisiblePosition = 1
        UltraGridColumn121.Width = 43
        UltraGridColumn122.Header.VisiblePosition = 2
        UltraGridColumn122.Width = 35
        UltraGridColumn123.Header.VisiblePosition = 3
        UltraGridColumn123.Width = 33
        UltraGridColumn124.Header.VisiblePosition = 4
        UltraGridColumn124.Width = 46
        UltraGridColumn125.Header.VisiblePosition = 5
        UltraGridColumn125.Width = 35
        UltraGridColumn126.Header.VisiblePosition = 6
        UltraGridColumn126.Width = 20
        UltraGridColumn127.Header.VisiblePosition = 7
        UltraGridColumn127.Width = 38
        UltraGridColumn128.Header.VisiblePosition = 8
        UltraGridColumn128.Width = 28
        UltraGridColumn129.Header.VisiblePosition = 9
        UltraGridColumn129.Width = 28
        UltraGridColumn130.Header.VisiblePosition = 10
        UltraGridColumn130.Width = 31
        UltraGridColumn131.Header.VisiblePosition = 11
        UltraGridColumn131.Width = 28
        UltraGridColumn132.Header.VisiblePosition = 12
        UltraGridColumn132.Width = 23
        UltraGridColumn133.Header.VisiblePosition = 13
        UltraGridColumn133.Width = 35
        UltraGridColumn134.Header.VisiblePosition = 14
        UltraGridColumn134.Width = 38
        UltraGridColumn135.Header.VisiblePosition = 15
        UltraGridColumn135.Width = 29
        UltraGridColumn136.Header.VisiblePosition = 16
        UltraGridColumn136.Width = 33
        UltraGridColumn137.Header.VisiblePosition = 17
        UltraGridColumn137.Width = 45
        UltraGridColumn138.Header.VisiblePosition = 18
        UltraGridColumn138.Width = 39
        UltraGridColumn139.Header.VisiblePosition = 19
        UltraGridColumn139.Width = 35
        UltraGridColumn140.Header.VisiblePosition = 20
        UltraGridColumn140.Width = 35
        UltraGridBand14.Columns.AddRange(New Object() {UltraGridColumn120, UltraGridColumn121, UltraGridColumn122, UltraGridColumn123, UltraGridColumn124, UltraGridColumn125, UltraGridColumn126, UltraGridColumn127, UltraGridColumn128, UltraGridColumn129, UltraGridColumn130, UltraGridColumn131, UltraGridColumn132, UltraGridColumn133, UltraGridColumn134, UltraGridColumn135, UltraGridColumn136, UltraGridColumn137, UltraGridColumn138, UltraGridColumn139, UltraGridColumn140})
        UltraGridColumn141.Header.VisiblePosition = 0
        UltraGridColumn141.Width = 24
        UltraGridColumn142.Header.VisiblePosition = 1
        UltraGridColumn142.Width = 53
        UltraGridColumn143.Header.VisiblePosition = 2
        UltraGridColumn143.Width = 42
        UltraGridColumn144.Header.VisiblePosition = 3
        UltraGridColumn144.Width = 39
        UltraGridColumn145.Header.VisiblePosition = 4
        UltraGridColumn145.Width = 56
        UltraGridColumn146.Header.VisiblePosition = 5
        UltraGridColumn146.Width = 44
        UltraGridColumn147.Header.VisiblePosition = 6
        UltraGridColumn147.Width = 28
        UltraGridColumn148.Header.VisiblePosition = 7
        UltraGridColumn148.Width = 47
        UltraGridColumn149.Header.VisiblePosition = 8
        UltraGridColumn149.Width = 35
        UltraGridColumn150.Header.VisiblePosition = 9
        UltraGridColumn150.Width = 41
        UltraGridColumn151.Header.VisiblePosition = 10
        UltraGridColumn151.Width = 38
        UltraGridColumn152.Header.VisiblePosition = 11
        UltraGridColumn152.Width = 42
        UltraGridColumn153.Header.VisiblePosition = 12
        UltraGridColumn153.Width = 34
        UltraGridColumn154.Header.VisiblePosition = 13
        UltraGridColumn154.Width = 41
        UltraGridColumn155.Header.VisiblePosition = 14
        UltraGridColumn155.Width = 42
        UltraGridColumn156.Header.VisiblePosition = 15
        UltraGridColumn156.Width = 46
        UltraGridColumn157.Header.VisiblePosition = 16
        UltraGridColumn157.Width = 42
        UltraGridColumn279.Header.VisiblePosition = 17
        UltraGridColumn280.Header.VisiblePosition = 18
        UltraGridColumn281.Header.VisiblePosition = 19
        UltraGridBand15.Columns.AddRange(New Object() {UltraGridColumn141, UltraGridColumn142, UltraGridColumn143, UltraGridColumn144, UltraGridColumn145, UltraGridColumn146, UltraGridColumn147, UltraGridColumn148, UltraGridColumn149, UltraGridColumn150, UltraGridColumn151, UltraGridColumn152, UltraGridColumn153, UltraGridColumn154, UltraGridColumn155, UltraGridColumn156, UltraGridColumn157, UltraGridColumn279, UltraGridColumn280, UltraGridColumn281})
        Me.ugNc.DisplayLayout.BandsSerializer.Add(UltraGridBand13)
        Me.ugNc.DisplayLayout.BandsSerializer.Add(UltraGridBand14)
        Me.ugNc.DisplayLayout.BandsSerializer.Add(UltraGridBand15)
        Me.ugNc.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugNc.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance115.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance115.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance115.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance115.BorderColor = System.Drawing.SystemColors.Window
        Me.ugNc.DisplayLayout.GroupByBox.Appearance = Appearance115
        Appearance116.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugNc.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance116
        Me.ugNc.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugNc.DisplayLayout.GroupByBox.Hidden = True
        Appearance117.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance117.BackColor2 = System.Drawing.SystemColors.Control
        Appearance117.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance117.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugNc.DisplayLayout.GroupByBox.PromptAppearance = Appearance117
        Me.ugNc.DisplayLayout.MaxColScrollRegions = 1
        Me.ugNc.DisplayLayout.MaxRowScrollRegions = 1
        Appearance118.BackColor = System.Drawing.SystemColors.Window
        Appearance118.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugNc.DisplayLayout.Override.ActiveCellAppearance = Appearance118
        Appearance119.BackColor = System.Drawing.SystemColors.Highlight
        Appearance119.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugNc.DisplayLayout.Override.ActiveRowAppearance = Appearance119
        Me.ugNc.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugNc.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugNc.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNc.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugNc.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance120.BackColor = System.Drawing.SystemColors.Window
        Me.ugNc.DisplayLayout.Override.CardAreaAppearance = Appearance120
        Appearance121.BorderColor = System.Drawing.Color.Silver
        Appearance121.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugNc.DisplayLayout.Override.CellAppearance = Appearance121
        Me.ugNc.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugNc.DisplayLayout.Override.CellPadding = 0
        Appearance122.BackColor = System.Drawing.SystemColors.Control
        Appearance122.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance122.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance122.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance122.BorderColor = System.Drawing.SystemColors.Window
        Me.ugNc.DisplayLayout.Override.GroupByRowAppearance = Appearance122
        Appearance123.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance123.BackColor2 = System.Drawing.Color.Transparent
        Appearance123.TextHAlignAsString = "Left"
        Me.ugNc.DisplayLayout.Override.HeaderAppearance = Appearance123
        Me.ugNc.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugNc.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance124.BackColor = System.Drawing.SystemColors.Window
        Appearance124.BorderColor = System.Drawing.Color.Silver
        Me.ugNc.DisplayLayout.Override.RowAppearance = Appearance124
        Me.ugNc.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.ugNc.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugNc.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance125.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugNc.DisplayLayout.Override.TemplateAddRowAppearance = Appearance125
        Me.ugNc.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugNc.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugNc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugNc.Location = New System.Drawing.Point(3, 3)
        Me.ugNc.Name = "ugNc"
        Me.ugNc.Size = New System.Drawing.Size(734, 360)
        Me.ugNc.TabIndex = 1
        Me.ugNc.Text = "UltraGrid4"
        '
        'NCBindingSource
        '
        Me.NCBindingSource.DataMember = "Pedidos"
        Me.NCBindingSource.DataSource = Me.DtsRegistracionPagos
        Me.NCBindingSource.Filter = "TotalNC <> 0"
        '
        'utReenvios
        '
        Me.utReenvios.Controls.Add(Me.lblNumeroReparto)
        Me.utReenvios.Controls.Add(Me.ugReenvios)
        Me.utReenvios.Location = New System.Drawing.Point(-10000, -10000)
        Me.utReenvios.Name = "utReenvios"
        Me.utReenvios.Size = New System.Drawing.Size(999, 386)
        '
        'lblNumeroReparto
        '
        Me.lblNumeroReparto.AutoSize = True
        Me.lblNumeroReparto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroReparto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNumeroReparto.Location = New System.Drawing.Point(749, 23)
        Me.lblNumeroReparto.Name = "lblNumeroReparto"
        Me.lblNumeroReparto.Size = New System.Drawing.Size(107, 20)
        Me.lblNumeroReparto.TabIndex = 1
        Me.lblNumeroReparto.Text = "Nro Reparto"
        '
        'ugReenvios
        '
        Me.ugReenvios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ugReenvios.DataSource = Me.ReenviosBindingSource
        Me.ugReenvios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn487.Header.VisiblePosition = 0
        UltraGridColumn487.Hidden = True
        UltraGridColumn488.Header.Caption = "Tipo"
        UltraGridColumn488.Header.VisiblePosition = 1
        UltraGridColumn488.MaxWidth = 90
        UltraGridColumn488.Width = 50
        UltraGridColumn489.Header.Caption = "L"
        UltraGridColumn489.Header.VisiblePosition = 2
        UltraGridColumn489.MaxWidth = 25
        UltraGridColumn489.MinWidth = 25
        UltraGridColumn489.Width = 25
        Appearance126.TextHAlignAsString = "Right"
        UltraGridColumn490.CellAppearance = Appearance126
        UltraGridColumn490.Header.Caption = "Emisor"
        UltraGridColumn490.Header.VisiblePosition = 3
        UltraGridColumn490.MaxWidth = 50
        UltraGridColumn490.MinWidth = 50
        UltraGridColumn490.Width = 50
        Appearance127.TextHAlignAsString = "Right"
        UltraGridColumn491.CellAppearance = Appearance127
        UltraGridColumn491.Header.Caption = "Nro."
        UltraGridColumn491.Header.VisiblePosition = 4
        UltraGridColumn491.MaxWidth = 60
        UltraGridColumn491.MinWidth = 60
        UltraGridColumn491.Width = 60
        UltraGridColumn492.Header.VisiblePosition = 5
        UltraGridColumn492.Hidden = True
        Appearance128.TextHAlignAsString = "Right"
        UltraGridColumn493.CellAppearance = Appearance128
        UltraGridColumn493.Header.Caption = "Código"
        UltraGridColumn493.Header.VisiblePosition = 6
        UltraGridColumn493.MaxWidth = 50
        UltraGridColumn493.MinWidth = 50
        UltraGridColumn493.Width = 50
        UltraGridColumn494.Header.VisiblePosition = 7
        UltraGridColumn494.Hidden = True
        UltraGridColumn495.Header.VisiblePosition = 8
        UltraGridColumn495.Hidden = True
        UltraGridColumn496.Header.Caption = "Cliente"
        UltraGridColumn496.Header.VisiblePosition = 9
        UltraGridColumn496.Width = 78
        UltraGridColumn497.Header.Caption = "Dirección"
        UltraGridColumn497.Header.VisiblePosition = 10
        UltraGridColumn497.Width = 78
        UltraGridColumn498.Header.VisiblePosition = 11
        UltraGridColumn498.Hidden = True
        UltraGridColumn499.Header.VisiblePosition = 12
        UltraGridColumn499.Hidden = True
        UltraGridColumn500.Header.VisiblePosition = 13
        UltraGridColumn500.Hidden = True
        UltraGridColumn501.Header.VisiblePosition = 14
        UltraGridColumn501.Width = 60
        UltraGridColumn502.Header.VisiblePosition = 15
        UltraGridColumn502.Hidden = True
        UltraGridColumn503.Header.VisiblePosition = 16
        UltraGridColumn503.Hidden = True
        UltraGridColumn504.Header.VisiblePosition = 17
        UltraGridColumn504.Hidden = True
        UltraGridColumn505.Header.VisiblePosition = 18
        UltraGridColumn505.Hidden = True
        UltraGridColumn506.Header.VisiblePosition = 19
        UltraGridColumn506.Hidden = True
        UltraGridColumn507.Header.VisiblePosition = 20
        UltraGridColumn507.Hidden = True
        UltraGridColumn508.Header.VisiblePosition = 21
        UltraGridColumn508.Hidden = True
        UltraGridColumn509.Header.VisiblePosition = 22
        UltraGridColumn509.Hidden = True
        UltraGridColumn510.Header.VisiblePosition = 23
        UltraGridColumn510.Hidden = True
        UltraGridColumn511.Header.VisiblePosition = 24
        UltraGridColumn511.Hidden = True
        Appearance129.TextHAlignAsString = "Right"
        UltraGridColumn512.CellAppearance = Appearance129
        UltraGridColumn512.Header.Caption = "Importe"
        UltraGridColumn512.Header.VisiblePosition = 25
        UltraGridColumn512.Hidden = True
        UltraGridColumn512.Width = 80
        UltraGridColumn513.Header.VisiblePosition = 26
        UltraGridColumn513.Hidden = True
        UltraGridColumn513.Width = 91
        UltraGridColumn514.Header.VisiblePosition = 27
        UltraGridColumn514.Hidden = True
        UltraGridColumn514.Width = 74
        UltraGridColumn515.Header.VisiblePosition = 28
        UltraGridColumn515.Hidden = True
        UltraGridColumn515.Width = 62
        Appearance130.TextHAlignAsString = "Right"
        UltraGridColumn516.CellAppearance = Appearance130
        UltraGridColumn516.Format = "N2"
        UltraGridColumn516.Header.Caption = "Importe"
        UltraGridColumn516.Header.VisiblePosition = 29
        UltraGridColumn516.MaskInput = "{double:-12.2}"
        UltraGridColumn516.MaxWidth = 70
        UltraGridColumn516.Width = 51
        UltraGridColumn517.Header.Caption = "Reenviar"
        UltraGridColumn517.Header.VisiblePosition = 30
        UltraGridColumn517.MaxWidth = 65
        UltraGridColumn517.Width = 44
        UltraGridColumn518.Header.VisiblePosition = 31
        UltraGridColumn518.Hidden = True
        UltraGridColumn518.Width = 84
        UltraGridColumn519.Header.Caption = "Nuevo Transp."
        UltraGridColumn519.Header.VisiblePosition = 32
        UltraGridColumn519.Width = 84
        UltraGridColumn271.Header.VisiblePosition = 33
        UltraGridColumn271.Width = 83
        UltraGridColumn520.Header.VisiblePosition = 34
        UltraGridColumn521.Header.VisiblePosition = 35
        UltraGridBand16.Columns.AddRange(New Object() {UltraGridColumn487, UltraGridColumn488, UltraGridColumn489, UltraGridColumn490, UltraGridColumn491, UltraGridColumn492, UltraGridColumn493, UltraGridColumn494, UltraGridColumn495, UltraGridColumn496, UltraGridColumn497, UltraGridColumn498, UltraGridColumn499, UltraGridColumn500, UltraGridColumn501, UltraGridColumn502, UltraGridColumn503, UltraGridColumn504, UltraGridColumn505, UltraGridColumn506, UltraGridColumn507, UltraGridColumn508, UltraGridColumn509, UltraGridColumn510, UltraGridColumn511, UltraGridColumn512, UltraGridColumn513, UltraGridColumn514, UltraGridColumn515, UltraGridColumn516, UltraGridColumn517, UltraGridColumn518, UltraGridColumn519, UltraGridColumn271, UltraGridColumn520, UltraGridColumn521})
        Appearance131.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        UltraGridBand16.Header.Appearance = Appearance131
        Appearance132.TextHAlignAsString = "Right"
        SummarySettings6.Appearance = Appearance132
        SummarySettings6.DisplayFormat = "{0:N2}"
        SummarySettings6.GroupBySummaryValueAppearance = Appearance133
        UltraGridBand16.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings6})
        UltraGridColumn158.Header.VisiblePosition = 0
        UltraGridColumn158.Width = 17
        UltraGridColumn159.Header.VisiblePosition = 1
        UltraGridColumn159.Width = 43
        UltraGridColumn160.Header.VisiblePosition = 2
        UltraGridColumn160.Width = 35
        UltraGridColumn161.Header.VisiblePosition = 3
        UltraGridColumn161.Width = 33
        UltraGridColumn197.Header.VisiblePosition = 4
        UltraGridColumn197.Width = 46
        UltraGridColumn198.Header.VisiblePosition = 5
        UltraGridColumn198.Width = 35
        UltraGridColumn199.Header.VisiblePosition = 6
        UltraGridColumn199.Width = 20
        UltraGridColumn200.Header.VisiblePosition = 7
        UltraGridColumn200.Width = 38
        UltraGridColumn201.Header.VisiblePosition = 8
        UltraGridColumn201.Width = 28
        UltraGridColumn202.Header.VisiblePosition = 9
        UltraGridColumn202.Width = 28
        UltraGridColumn203.Header.VisiblePosition = 10
        UltraGridColumn203.Width = 31
        UltraGridColumn204.Header.VisiblePosition = 11
        UltraGridColumn204.Width = 28
        UltraGridColumn205.Header.VisiblePosition = 12
        UltraGridColumn205.Width = 23
        UltraGridColumn206.Header.VisiblePosition = 13
        UltraGridColumn206.Width = 35
        UltraGridColumn207.Header.VisiblePosition = 14
        UltraGridColumn207.Width = 38
        UltraGridColumn208.Header.VisiblePosition = 15
        UltraGridColumn208.Width = 29
        UltraGridColumn209.Header.VisiblePosition = 16
        UltraGridColumn209.Width = 33
        UltraGridColumn210.Header.VisiblePosition = 17
        UltraGridColumn210.Width = 45
        UltraGridColumn211.Header.VisiblePosition = 18
        UltraGridColumn211.Width = 39
        UltraGridColumn212.Header.VisiblePosition = 19
        UltraGridColumn212.Width = 35
        UltraGridColumn213.Header.VisiblePosition = 20
        UltraGridColumn213.Width = 35
        UltraGridBand17.Columns.AddRange(New Object() {UltraGridColumn158, UltraGridColumn159, UltraGridColumn160, UltraGridColumn161, UltraGridColumn197, UltraGridColumn198, UltraGridColumn199, UltraGridColumn200, UltraGridColumn201, UltraGridColumn202, UltraGridColumn203, UltraGridColumn204, UltraGridColumn205, UltraGridColumn206, UltraGridColumn207, UltraGridColumn208, UltraGridColumn209, UltraGridColumn210, UltraGridColumn211, UltraGridColumn212, UltraGridColumn213})
        UltraGridColumn214.Header.VisiblePosition = 0
        UltraGridColumn214.Width = 24
        UltraGridColumn215.Header.VisiblePosition = 1
        UltraGridColumn215.Width = 53
        UltraGridColumn216.Header.VisiblePosition = 2
        UltraGridColumn216.Width = 42
        UltraGridColumn217.Header.VisiblePosition = 3
        UltraGridColumn217.Width = 39
        UltraGridColumn218.Header.VisiblePosition = 4
        UltraGridColumn218.Width = 56
        UltraGridColumn219.Header.VisiblePosition = 5
        UltraGridColumn219.Width = 44
        UltraGridColumn220.Header.VisiblePosition = 6
        UltraGridColumn220.Width = 28
        UltraGridColumn221.Header.VisiblePosition = 7
        UltraGridColumn221.Width = 47
        UltraGridColumn222.Header.VisiblePosition = 8
        UltraGridColumn222.Width = 35
        UltraGridColumn223.Header.VisiblePosition = 9
        UltraGridColumn223.Width = 41
        UltraGridColumn224.Header.VisiblePosition = 10
        UltraGridColumn224.Width = 38
        UltraGridColumn225.Header.VisiblePosition = 11
        UltraGridColumn225.Width = 42
        UltraGridColumn226.Header.VisiblePosition = 12
        UltraGridColumn226.Width = 34
        UltraGridColumn227.Header.VisiblePosition = 13
        UltraGridColumn227.Width = 41
        UltraGridColumn228.Header.VisiblePosition = 14
        UltraGridColumn228.Width = 42
        UltraGridColumn229.Header.VisiblePosition = 15
        UltraGridColumn229.Width = 46
        UltraGridColumn230.Header.VisiblePosition = 16
        UltraGridColumn230.Width = 42
        UltraGridColumn282.Header.VisiblePosition = 17
        UltraGridColumn283.Header.VisiblePosition = 18
        UltraGridColumn284.Header.VisiblePosition = 19
        UltraGridBand18.Columns.AddRange(New Object() {UltraGridColumn214, UltraGridColumn215, UltraGridColumn216, UltraGridColumn217, UltraGridColumn218, UltraGridColumn219, UltraGridColumn220, UltraGridColumn221, UltraGridColumn222, UltraGridColumn223, UltraGridColumn224, UltraGridColumn225, UltraGridColumn226, UltraGridColumn227, UltraGridColumn228, UltraGridColumn229, UltraGridColumn230, UltraGridColumn282, UltraGridColumn283, UltraGridColumn284})
        Me.ugReenvios.DisplayLayout.BandsSerializer.Add(UltraGridBand16)
        Me.ugReenvios.DisplayLayout.BandsSerializer.Add(UltraGridBand17)
        Me.ugReenvios.DisplayLayout.BandsSerializer.Add(UltraGridBand18)
        Me.ugReenvios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugReenvios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance134.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance134.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance134.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance134.BorderColor = System.Drawing.SystemColors.Window
        Me.ugReenvios.DisplayLayout.GroupByBox.Appearance = Appearance134
        Appearance135.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugReenvios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance135
        Me.ugReenvios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugReenvios.DisplayLayout.GroupByBox.Hidden = True
        Appearance136.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance136.BackColor2 = System.Drawing.SystemColors.Control
        Appearance136.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance136.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugReenvios.DisplayLayout.GroupByBox.PromptAppearance = Appearance136
        Me.ugReenvios.DisplayLayout.MaxColScrollRegions = 1
        Me.ugReenvios.DisplayLayout.MaxRowScrollRegions = 1
        Appearance137.BackColor = System.Drawing.SystemColors.Window
        Appearance137.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugReenvios.DisplayLayout.Override.ActiveCellAppearance = Appearance137
        Appearance138.BackColor = System.Drawing.SystemColors.Highlight
        Appearance138.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugReenvios.DisplayLayout.Override.ActiveRowAppearance = Appearance138
        Me.ugReenvios.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.ugReenvios.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugReenvios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugReenvios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance139.BackColor = System.Drawing.SystemColors.Window
        Me.ugReenvios.DisplayLayout.Override.CardAreaAppearance = Appearance139
        Appearance140.BorderColor = System.Drawing.Color.Silver
        Appearance140.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugReenvios.DisplayLayout.Override.CellAppearance = Appearance140
        Me.ugReenvios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugReenvios.DisplayLayout.Override.CellPadding = 0
        Appearance141.BackColor = System.Drawing.SystemColors.Control
        Appearance141.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance141.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance141.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance141.BorderColor = System.Drawing.SystemColors.Window
        Me.ugReenvios.DisplayLayout.Override.GroupByRowAppearance = Appearance141
        Appearance142.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance142.BackColor2 = System.Drawing.Color.Transparent
        Appearance142.TextHAlignAsString = "Left"
        Me.ugReenvios.DisplayLayout.Override.HeaderAppearance = Appearance142
        Me.ugReenvios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugReenvios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance143.BackColor = System.Drawing.SystemColors.Window
        Appearance143.BorderColor = System.Drawing.Color.Silver
        Me.ugReenvios.DisplayLayout.Override.RowAppearance = Appearance143
        Me.ugReenvios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugReenvios.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance144.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugReenvios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance144
        Me.ugReenvios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugReenvios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugReenvios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugReenvios.Location = New System.Drawing.Point(3, 3)
        Me.ugReenvios.Name = "ugReenvios"
        Me.ugReenvios.Size = New System.Drawing.Size(734, 360)
        Me.ugReenvios.TabIndex = 0
        Me.ugReenvios.Text = "UltraGrid4"
        '
        'ReenviosBindingSource
        '
        Me.ReenviosBindingSource.DataMember = "Pedidos"
        Me.ReenviosBindingSource.DataSource = Me.DtsRegistracionPagos
        Me.ReenviosBindingSource.Filter = "TotalReenvio <> 0"
        '
        'UltraTabPageControl5
        '
        Me.UltraTabPageControl5.Controls.Add(Me.ugvProductosSinDescargar)
        Me.UltraTabPageControl5.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl5.Name = "UltraTabPageControl5"
        Me.UltraTabPageControl5.Size = New System.Drawing.Size(999, 386)
        '
        'ugvProductosSinDescargar
        '
        Me.ugvProductosSinDescargar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance145.BackColor = System.Drawing.SystemColors.Window
        Appearance145.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugvProductosSinDescargar.DisplayLayout.Appearance = Appearance145
        UltraGridColumn601.Header.Caption = "Código"
        UltraGridColumn601.Header.VisiblePosition = 0
        UltraGridColumn601.Width = 142
        UltraGridColumn602.Header.Caption = "Producto"
        UltraGridColumn602.Header.VisiblePosition = 1
        UltraGridColumn602.Width = 378
        UltraGridColumn603.Format = "N2"
        UltraGridColumn603.Header.VisiblePosition = 2
        UltraGridColumn604.Header.VisiblePosition = 3
        UltraGridBand19.Columns.AddRange(New Object() {UltraGridColumn601, UltraGridColumn602, UltraGridColumn603, UltraGridColumn604})
        Appearance146.TextHAlignAsString = "Right"
        UltraGridColumn605.CellAppearance = Appearance146
        UltraGridColumn605.Header.Caption = "Código"
        UltraGridColumn605.Header.VisiblePosition = 0
        UltraGridColumn605.Hidden = True
        UltraGridColumn605.Width = 77
        UltraGridColumn606.Header.VisiblePosition = 1
        UltraGridColumn606.Hidden = True
        UltraGridColumn607.Header.Caption = "Comprobante"
        UltraGridColumn607.Header.VisiblePosition = 2
        UltraGridColumn608.Header.VisiblePosition = 3
        UltraGridColumn608.Width = 38
        Appearance147.TextHAlignAsString = "Right"
        UltraGridColumn609.CellAppearance = Appearance147
        UltraGridColumn609.Header.Caption = "Emisor"
        UltraGridColumn609.Header.VisiblePosition = 4
        UltraGridColumn609.Width = 69
        Appearance148.TextHAlignAsString = "Right"
        UltraGridColumn610.CellAppearance = Appearance148
        UltraGridColumn610.Header.Caption = "Numero"
        UltraGridColumn610.Header.VisiblePosition = 5
        UltraGridColumn611.Header.VisiblePosition = 6
        UltraGridColumn612.Header.VisiblePosition = 7
        Appearance149.TextHAlignAsString = "Right"
        UltraGridColumn613.CellAppearance = Appearance149
        UltraGridColumn613.Header.VisiblePosition = 8
        UltraGridColumn613.Width = 62
        UltraGridColumn614.Header.Caption = "Codigo Cliente"
        UltraGridColumn614.Header.VisiblePosition = 9
        UltraGridColumn615.Header.Caption = "Nombre Cliente"
        UltraGridColumn615.Header.VisiblePosition = 10
        UltraGridColumn616.Header.Caption = "Operacion"
        UltraGridColumn616.Header.VisiblePosition = 11
        UltraGridBand20.Columns.AddRange(New Object() {UltraGridColumn605, UltraGridColumn606, UltraGridColumn607, UltraGridColumn608, UltraGridColumn609, UltraGridColumn610, UltraGridColumn611, UltraGridColumn612, UltraGridColumn613, UltraGridColumn614, UltraGridColumn615, UltraGridColumn616})
        Me.ugvProductosSinDescargar.DisplayLayout.BandsSerializer.Add(UltraGridBand19)
        Me.ugvProductosSinDescargar.DisplayLayout.BandsSerializer.Add(UltraGridBand20)
        Me.ugvProductosSinDescargar.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft
        Me.ugvProductosSinDescargar.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance150.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance150.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance150.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance150.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Appearance = Appearance150
        Appearance151.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance151
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Hidden = True
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para Agrupar"
        Appearance152.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance152.BackColor2 = System.Drawing.SystemColors.Control
        Appearance152.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance152.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugvProductosSinDescargar.DisplayLayout.GroupByBox.PromptAppearance = Appearance152
        Me.ugvProductosSinDescargar.DisplayLayout.MaxColScrollRegions = 1
        Me.ugvProductosSinDescargar.DisplayLayout.MaxRowScrollRegions = 1
        Appearance153.BackColor = System.Drawing.SystemColors.Window
        Appearance153.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.ActiveCellAppearance = Appearance153
        Appearance154.BackColor = System.Drawing.SystemColors.Highlight
        Appearance154.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.ActiveRowAppearance = Appearance154
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvProductosSinDescargar.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugvProductosSinDescargar.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugvProductosSinDescargar.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance155.BackColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CardAreaAppearance = Appearance155
        Appearance156.BorderColor = System.Drawing.Color.Silver
        Appearance156.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellAppearance = Appearance156
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugvProductosSinDescargar.DisplayLayout.Override.CellPadding = 0
        Appearance157.BackColor = System.Drawing.SystemColors.Control
        Appearance157.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance157.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance157.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance157.BorderColor = System.Drawing.SystemColors.Window
        Me.ugvProductosSinDescargar.DisplayLayout.Override.GroupByRowAppearance = Appearance157
        Appearance158.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Appearance158.TextHAlignAsString = "Left"
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderAppearance = Appearance158
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugvProductosSinDescargar.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance159.BackColor = System.Drawing.SystemColors.Window
        Appearance159.BorderColor = System.Drawing.Color.Silver
        Me.ugvProductosSinDescargar.DisplayLayout.Override.RowAppearance = Appearance159
        Me.ugvProductosSinDescargar.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.ugvProductosSinDescargar.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance160.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugvProductosSinDescargar.DisplayLayout.Override.TemplateAddRowAppearance = Appearance160
        Me.ugvProductosSinDescargar.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugvProductosSinDescargar.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugvProductosSinDescargar.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugvProductosSinDescargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugvProductosSinDescargar.Location = New System.Drawing.Point(15, 13)
        Me.ugvProductosSinDescargar.Name = "ugvProductosSinDescargar"
        Me.ugvProductosSinDescargar.Size = New System.Drawing.Size(882, 350)
        Me.ugvProductosSinDescargar.TabIndex = 1
        Me.ugvProductosSinDescargar.Text = "UltraGrid1"
        '
        'utResumen
        '
        Me.utResumen.Controls.Add(Me.cmdImprimirResumen)
        Me.utResumen.Controls.Add(Me.grbIVAs)
        Me.utResumen.Location = New System.Drawing.Point(-10000, -10000)
        Me.utResumen.Name = "utResumen"
        Me.utResumen.Size = New System.Drawing.Size(999, 386)
        '
        'cmdImprimirResumen
        '
        Me.cmdImprimirResumen.Location = New System.Drawing.Point(403, 12)
        Me.cmdImprimirResumen.Name = "cmdImprimirResumen"
        Me.cmdImprimirResumen.Size = New System.Drawing.Size(107, 24)
        Me.cmdImprimirResumen.TabIndex = 1
        Me.cmdImprimirResumen.Text = "Imprimir Resumen"
        Me.cmdImprimirResumen.UseVisualStyleBackColor = True
        '
        'grbIVAs
        '
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
        Me.grbIVAs.Size = New System.Drawing.Size(375, 275)
        Me.grbIVAs.TabIndex = 0
        Me.grbIVAs.TabStop = False
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
        Me.lblDescRecGral.Location = New System.Drawing.Point(11, 93)
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
        Me.txttotalCC.Location = New System.Drawing.Point(223, 91)
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
        Me.lblTotalReenvios.Location = New System.Drawing.Point(11, 203)
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
        Me.txtTotalReenvios.Location = New System.Drawing.Point(223, 196)
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
        Me.lblTotalSubtotales.Location = New System.Drawing.Point(11, 246)
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
        Me.lblTotalImpuestos.Location = New System.Drawing.Point(11, 168)
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
        Me.txtTotalSubtotales.Location = New System.Drawing.Point(223, 239)
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
        Me.lblTotalNeto.Location = New System.Drawing.Point(11, 133)
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
        Me.lblTotalBruto.Location = New System.Drawing.Point(11, 63)
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
        Me.txtTotalNC.Location = New System.Drawing.Point(223, 161)
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
        Me.txttotalCheque.Location = New System.Drawing.Point(223, 126)
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
        Me.Label8.Location = New System.Drawing.Point(10, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(355, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "__________________________________________________________"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.FitWidthToPages = 1
        Me.UltraGridPrintDocument1.Grid = Me.ugvDetallePedidos
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(796, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Calculadora"
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
        Me.cmbCajas.Location = New System.Drawing.Point(58, 101)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(127, 21)
        Me.cmbCajas.TabIndex = 3
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(13, 105)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 2
        Me.lblCaja.Text = "Ca&ja"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(204, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Fecha Rendición:"
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
        Me.dtpFechaRend.LabelAsoc = Me.Label6
        Me.dtpFechaRend.Location = New System.Drawing.Point(301, 101)
        Me.dtpFechaRend.Name = "dtpFechaRend"
        Me.dtpFechaRend.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaRend.TabIndex = 5
        '
        'ucdCalculadora
        '
        Me.ucdCalculadora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        CalculatorButton1.Key = "."
        CalculatorButton1.KeyCodeAlternateValue = 190
        CalculatorButton1.KeyCodeValue = 110
        CalculatorButton1.Text = ","
        Me.ucdCalculadora.Buttons.AddRange(New Infragistics.Win.UltraWinEditors.UltraWinCalc.CalculatorButton() {CalculatorButton1})
        Me.ucdCalculadora.Location = New System.Drawing.Point(939, 101)
        Me.ucdCalculadora.Name = "ucdCalculadora"
        Me.ucdCalculadora.Size = New System.Drawing.Size(62, 21)
        Me.ucdCalculadora.TabIndex = 7
        '
        'utcPreventa
        '
        Appearance161.ForeColor = System.Drawing.Color.Black
        Me.utcPreventa.ActiveTabAppearance = Appearance161
        Me.utcPreventa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.utcPreventa.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl1)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl3)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl4)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl2)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl6)
        Me.utcPreventa.Controls.Add(Me.utReenvios)
        Me.utcPreventa.Controls.Add(Me.utResumen)
        Me.utcPreventa.Controls.Add(Me.UltraTabPageControl5)
        Me.utcPreventa.Location = New System.Drawing.Point(0, 127)
        Me.utcPreventa.Name = "utcPreventa"
        Me.utcPreventa.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.utcPreventa.Size = New System.Drawing.Size(1001, 409)
        Me.utcPreventa.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.utcPreventa.TabIndex = 8
        Appearance162.BackColor = System.Drawing.Color.Honeydew
        Appearance162.FontData.BoldAsString = "False"
        UltraTab1.ActiveAppearance = Appearance162
        Appearance163.ForeColor = System.Drawing.Color.Black
        UltraTab1.Appearance = Appearance163
        UltraTab1.Key = "tbcDetallePago"
        UltraTab1.TabPage = Me.UltraTabPageControl3
        UltraTab1.Text = "Detalle de Pagos"
        Appearance164.BackColor = System.Drawing.Color.Honeydew
        UltraTab2.ActiveAppearance = Appearance164
        Appearance165.ForeColor = System.Drawing.Color.Black
        UltraTab2.Appearance = Appearance165
        UltraTab2.Key = "tbcSaldoCliente"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Efectivo"
        Appearance166.BackColor = System.Drawing.Color.Honeydew
        UltraTab3.ActiveAppearance = Appearance166
        Appearance167.ForeColor = System.Drawing.Color.Black
        UltraTab3.Appearance = Appearance167
        UltraTab3.Key = "tbcCuentaCorriente"
        UltraTab3.TabPage = Me.UltraTabPageControl1
        UltraTab3.Text = "Cuentas Corrientes"
        Appearance168.BackColor = System.Drawing.Color.Honeydew
        UltraTab4.ActiveAppearance = Appearance168
        Appearance169.ForeColor = System.Drawing.Color.Black
        UltraTab4.Appearance = Appearance169
        UltraTab4.Key = "tbcCheque"
        UltraTab4.TabPage = Me.UltraTabPageControl4
        UltraTab4.Text = "Cheques"
        Appearance170.ForeColor = System.Drawing.Color.Black
        UltraTab5.Appearance = Appearance170
        UltraTab5.Key = "tbcArticulosNC"
        UltraTab5.TabPage = Me.UltraTabPageControl6
        UltraTab5.Text = "Artículos NC"
        UltraTab6.Key = "tbcReenvios"
        UltraTab6.TabPage = Me.utReenvios
        UltraTab6.Text = "Reenvios"
        Appearance171.ForeColor = System.Drawing.Color.Black
        UltraTab7.Appearance = Appearance171
        UltraTab7.Key = "tbcProductosSinDescargar"
        UltraTab7.TabPage = Me.UltraTabPageControl5
        UltraTab7.Text = "Productos Sin Descargar"
        Appearance172.FontData.BoldAsString = "True"
        UltraTab8.Appearance = Appearance172
        UltraTab8.Key = "tbcResumen"
        UltraTab8.TabPage = Me.utResumen
        UltraTab8.Text = "Resumen"
        Me.utcPreventa.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3, UltraTab4, UltraTab5, UltraTab6, UltraTab7, UltraTab8})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(999, 386)
        '
        'grbFecha
        '
        Me.grbFecha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFecha.Controls.Add(Me.chbDias)
        Me.grbFecha.Controls.Add(Me.cmbDias)
        Me.grbFecha.Controls.Add(Me.cmbRuta)
        Me.grbFecha.Controls.Add(Me.chbRuta)
        Me.grbFecha.Controls.Add(Me.chbVendedor)
        Me.grbFecha.Controls.Add(Me.cmbVendedor)
        Me.grbFecha.Controls.Add(Me.cmbModoConsultarComprobantes)
        Me.grbFecha.Controls.Add(Me.txtNumeroReparto)
        Me.grbFecha.Controls.Add(Me.cmbLocalidad)
        Me.grbFecha.Controls.Add(Me.lblReparto)
        Me.grbFecha.Controls.Add(Me.btnBuscar)
        Me.grbFecha.Controls.Add(Me.chbRespDistribucion)
        Me.grbFecha.Controls.Add(Me.cmbRespDistribucion)
        Me.grbFecha.Controls.Add(Me.chbLocalidad)
        Me.grbFecha.Controls.Add(Me.dtpFechaHasta)
        Me.grbFecha.Controls.Add(Me.lblAl)
        Me.grbFecha.Location = New System.Drawing.Point(10, 32)
        Me.grbFecha.Name = "grbFecha"
        Me.grbFecha.Size = New System.Drawing.Size(991, 65)
        Me.grbFecha.TabIndex = 1
        Me.grbFecha.TabStop = False
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
        Me.chbDias.Location = New System.Drawing.Point(741, 15)
        Me.chbDias.Name = "chbDias"
        Me.chbDias.Size = New System.Drawing.Size(47, 17)
        Me.chbDias.TabIndex = 7
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
        Me.cmbDias.Location = New System.Drawing.Point(792, 12)
        Me.cmbDias.Name = "cmbDias"
        Me.cmbDias.Size = New System.Drawing.Size(75, 21)
        Me.cmbDias.TabIndex = 8
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
        Me.cmbRuta.Location = New System.Drawing.Point(549, 12)
        Me.cmbRuta.Name = "cmbRuta"
        Me.cmbRuta.Size = New System.Drawing.Size(182, 21)
        Me.cmbRuta.TabIndex = 6
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
        Me.chbRuta.Location = New System.Drawing.Point(496, 15)
        Me.chbRuta.Name = "chbRuta"
        Me.chbRuta.Size = New System.Drawing.Size(49, 17)
        Me.chbRuta.TabIndex = 5
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
        Me.chbVendedor.Location = New System.Drawing.Point(610, 40)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 13
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
        Me.cmbVendedor.Location = New System.Drawing.Point(685, 38)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(182, 21)
        Me.cmbVendedor.TabIndex = 14
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
        Me.cmbModoConsultarComprobantes.LabelAsoc = Nothing
        Me.cmbModoConsultarComprobantes.Location = New System.Drawing.Point(159, 13)
        Me.cmbModoConsultarComprobantes.Name = "cmbModoConsultarComprobantes"
        Me.cmbModoConsultarComprobantes.Size = New System.Drawing.Size(152, 21)
        Me.cmbModoConsultarComprobantes.TabIndex = 2
        '
        'txtNumeroReparto
        '
        Me.txtNumeroReparto.BindearPropiedadControl = Nothing
        Me.txtNumeroReparto.BindearPropiedadEntidad = Nothing
        Me.txtNumeroReparto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroReparto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroReparto.Formato = "##0"
        Me.txtNumeroReparto.IsDecimal = False
        Me.txtNumeroReparto.IsNumber = True
        Me.txtNumeroReparto.IsPK = False
        Me.txtNumeroReparto.IsRequired = False
        Me.txtNumeroReparto.Key = ""
        Me.txtNumeroReparto.LabelAsoc = Me.lblReparto
        Me.txtNumeroReparto.Location = New System.Drawing.Point(91, 13)
        Me.txtNumeroReparto.MaxLength = 8
        Me.txtNumeroReparto.Name = "txtNumeroReparto"
        Me.txtNumeroReparto.Size = New System.Drawing.Size(62, 20)
        Me.txtNumeroReparto.TabIndex = 1
        Me.txtNumeroReparto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblReparto
        '
        Me.lblReparto.AutoSize = True
        Me.lblReparto.LabelAsoc = Nothing
        Me.lblReparto.Location = New System.Drawing.Point(6, 16)
        Me.lblReparto.Name = "lblReparto"
        Me.lblReparto.Size = New System.Drawing.Size(85, 13)
        Me.lblReparto.TabIndex = 0
        Me.lblReparto.Text = "Número Reparto"
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
        Me.cmbLocalidad.Location = New System.Drawing.Point(91, 38)
        Me.cmbLocalidad.Name = "cmbLocalidad"
        Me.cmbLocalidad.Size = New System.Drawing.Size(197, 21)
        Me.cmbLocalidad.TabIndex = 10
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(882, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 45)
        Me.btnBuscar.TabIndex = 15
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'chbRespDistribucion
        '
        Me.chbRespDistribucion.AutoSize = True
        Me.chbRespDistribucion.Location = New System.Drawing.Point(304, 41)
        Me.chbRespDistribucion.Name = "chbRespDistribucion"
        Me.chbRespDistribucion.Size = New System.Drawing.Size(112, 17)
        Me.chbRespDistribucion.TabIndex = 11
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
        Me.cmbRespDistribucion.Location = New System.Drawing.Point(422, 38)
        Me.cmbRespDistribucion.Name = "cmbRespDistribucion"
        Me.cmbRespDistribucion.Size = New System.Drawing.Size(182, 21)
        Me.cmbRespDistribucion.TabIndex = 12
        '
        'chbLocalidad
        '
        Me.chbLocalidad.AutoSize = True
        Me.chbLocalidad.Location = New System.Drawing.Point(9, 40)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 9
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
        Me.dtpFechaHasta.Location = New System.Drawing.Point(389, 13)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaHasta.TabIndex = 4
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.LabelAsoc = Nothing
        Me.lblAl.Location = New System.Drawing.Point(317, 16)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(66, 13)
        Me.lblAl.TabIndex = 3
        Me.lblAl.Text = "Fecha hasta"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1008, 22)
        Me.stsStado.TabIndex = 9
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
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbPagarTodo, Me.ToolStripSeparator4, Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbImprimirGrilla, Me.ToolStripSeparator1, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbCerrar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1008, 29)
        Me.tstBarra.TabIndex = 0
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
        'tsbPagarTodo
        '
        Me.tsbPagarTodo.Image = CType(resources.GetObject("tsbPagarTodo.Image"), System.Drawing.Image)
        Me.tsbPagarTodo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPagarTodo.Name = "tsbPagarTodo"
        Me.tsbPagarTodo.Size = New System.Drawing.Size(95, 26)
        Me.tsbPagarTodo.Text = "&Rendir todo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimirGrilla
        '
        Me.tsbImprimirGrilla.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
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
        'BindingSource1
        '
        Me.BindingSource1.DataSource = Me.DtsRegistracionPagos
        Me.BindingSource1.Filter = "Efectivo <> 0"
        Me.BindingSource1.Position = 0
        '
        'RegistracionPagos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 561)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbCajas)
        Me.Controls.Add(Me.lblCaja)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFechaRend)
        Me.Controls.Add(Me.ucdCalculadora)
        Me.Controls.Add(Me.utcPreventa)
        Me.Controls.Add(Me.grbFecha)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RegistracionPagos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registración de Pagos contra Entrega"
        Me.UltraTabPageControl3.ResumeLayout(False)
        Me.UltraTabPageControl3.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        CType(Me.ugvDetallePedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtsRegistracionPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        CType(Me.ugEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EfectivoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.ugCtaCte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CtaCteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl4.ResumeLayout(False)
        CType(Me.ugChequesAUX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugCheque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChequesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl6.ResumeLayout(False)
        CType(Me.ugNc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utReenvios.ResumeLayout(False)
        Me.utReenvios.PerformLayout()
        CType(Me.ugReenvios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReenviosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl5.ResumeLayout(False)
        CType(Me.ugvProductosSinDescargar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utResumen.ResumeLayout(False)
        Me.grbIVAs.ResumeLayout(False)
        Me.grbIVAs.PerformLayout()
        CType(Me.ucdCalculadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utcPreventa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utcPreventa.ResumeLayout(False)
        Me.grbFecha.ResumeLayout(False)
        Me.grbFecha.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
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
   Friend WithEvents grbFecha As System.Windows.Forms.GroupBox
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblAl As Eniac.Controles.Label
   Friend WithEvents chbRespDistribucion As System.Windows.Forms.CheckBox
   Friend WithEvents cmbRespDistribucion As Eniac.Controles.ComboBox
   Friend WithEvents chbLocalidad As System.Windows.Forms.CheckBox
   Friend WithEvents cmbLocalidad As Eniac.Controles.ComboBox
   Friend WithEvents utcPreventa As Infragistics.Win.UltraWinTabControl.UltraTabControl
   Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
   Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents UltraTabPageControl3 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents ugvDetallePedidos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbPagarTodo As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ucdCalculadora As Infragistics.Win.UltraWinEditors.UltraWinCalc.UltraCalculatorDropDown
   Public WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
   Public WithEvents tsbEfectivo As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbVarias As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbCC As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbNC As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbReenvio As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ugCtaCte As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugCheque As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugNc As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents utReenvios As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
   Friend WithEvents ugReenvios As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents lblNumeroReparto As System.Windows.Forms.Label
   Friend WithEvents ugChequesAUX As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents utResumen As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
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
   Friend WithEvents dtpFechaRend As Eniac.Controles.DateTimePicker
   Friend WithEvents Label6 As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents cmdImprimirResumen As System.Windows.Forms.Button
   Friend WithEvents tsbNoRendir As System.Windows.Forms.ToolStripButton
   Friend WithEvents DtsRegistracionPagos As Eniac.Win.dtsRegistracionPagos
   Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
   Friend WithEvents ugEfectivo As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents EfectivoBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents CtaCteBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents NCBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ChequesBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ReenviosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents lblReparto As Eniac.Controles.Label
   Friend WithEvents txtNumeroReparto As Eniac.Controles.TextBox
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
End Class
