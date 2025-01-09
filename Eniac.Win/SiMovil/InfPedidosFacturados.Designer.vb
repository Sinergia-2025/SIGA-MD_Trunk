<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfPedidosFacturados
   Inherits Eniac.Win.BaseForm

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
      Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Cabecera", -1)
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal_Pedido")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante_Pedido")
      Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra_Pedido")
      Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor_Pedido")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado")
      Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal_Venta")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante_Venta")
      Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra_Venta")
      Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor_Venta")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVenta")
      Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPedidoWeb")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnicoPedidoWeb")
      Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedidoWeb")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroVersionRemoto")
      Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Detalle")
      Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia", 0)
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Detalle", 0)
      Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal_Pedido")
      Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante_Pedido")
      Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra_Pedido")
      Dim UltraGridColumn83 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor_Pedido")
      Dim UltraGridColumn84 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim UltraGridColumn85 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado")
      Dim UltraGridColumn86 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido")
      Dim UltraGridColumn87 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal_Venta")
      Dim UltraGridColumn88 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante_Venta")
      Dim UltraGridColumn89 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra_Venta")
      Dim UltraGridColumn90 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor_Venta")
      Dim UltraGridColumn91 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim UltraGridColumn92 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVenta")
      Dim UltraGridColumn93 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim UltraGridColumn94 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn95 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn96 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto", -1, Nothing, 119997284, 0, 0)
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn97 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto", -1, Nothing, 119997284, 1, 0)
      Dim UltraGridColumn98 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad_Pedido", -1, Nothing, 119997282, 0, 0)
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn99 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio_Pedido", -1, Nothing, 119997282, 1, 0)
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn100 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc_Pedido", -1, Nothing, 119997282, 2, 0)
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn101 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2_Pedido", -1, Nothing, 119997282, 3, 0)
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn102 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto_Pedido", -1, Nothing, 119997282, 4, 0)
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn103 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad_Venta", -1, Nothing, 119997283, 0, 0)
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn104 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio_Venta", -1, Nothing, 119997283, 1, 0)
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn105 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc_Venta", -1, Nothing, 119997283, 2, 0)
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn106 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2_Venta", -1, Nothing, 119997283, 3, 0)
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn107 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto_Venta", -1, Nothing, 119997283, 4, 0)
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn108 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_PedidoVenta", -1, Nothing, 119997283, 5, 0)
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn109 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad_PedidoWeb", -1, Nothing, 120090797, 0, 0)
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn110 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio_PedidoWeb", -1, Nothing, 120090797, 1, 0)
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn111 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc_PedidoWeb", -1, Nothing, 120090797, 2, 0)
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn112 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_PedidoWebPedido", -1, Nothing, 119997282, 5, 0)
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn113 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_PedidoVenta_Imagen", 0, Nothing, 119997283, 6, 0)
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn114 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_PedidoWebPedido_Imagen", 1, Nothing, 119997282, 6, 0)
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup1 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Pedido", 119997282)
      Dim UltraGridGroup2 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Venta", 119997283)
      Dim UltraGridGroup3 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(119997284)
      Dim UltraGridGroup4 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Pedido Web", 120090797)
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
      Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand3 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPedidoWeb", -1, Nothing, 105808329, 0, 0)
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnicoPedidoWeb")
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedidoWeb", -1, Nothing, 105808329, 1, 0)
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroVersionRemoto")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal_Pedido", -1, Nothing, 105808330, 0, 0)
      Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante_Pedido", -1, Nothing, 105808330, 1, 0)
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra_Pedido", -1, Nothing, 105808330, 2, 0)
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor_Pedido", -1, Nothing, 105808330, 3, 0)
      Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido", -1, Nothing, 105808330, 4, 0)
      Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado", -1, Nothing, 105808330, 5, 0)
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaPedido", -1, Nothing, 105808330, 6, 0)
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal_Venta", -1, Nothing, 105808331, 0, 0)
      Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante_Venta", -1, Nothing, 105808331, 1, 0)
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra_Venta", -1, Nothing, 105808331, 2, 0)
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor_Venta", -1, Nothing, 105808331, 3, 0)
      Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante", -1, Nothing, 105808331, 4, 0)
      Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVenta", -1, Nothing, 105808331, 5, 0)
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente", -1, Nothing, 105808332, 0, 0)
      Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente", -1, Nothing, 105808332, 1, 0)
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto", -1, Nothing, 105808332, 2, 0)
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto", -1, Nothing, 105808332, 3, 0)
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad_Pedido", -1, Nothing, 105808330, 7, 0)
      Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad_Venta", -1, Nothing, 105808332, 4, 0)
      Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio_Pedido", -1, Nothing, 105808333, 0, 0)
      Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc_Pedido", -1, Nothing, 105808333, 1, 0)
      Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2_Pedido", -1, Nothing, 105808333, 2, 0)
      Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto_Pedido", -1, Nothing, 105808333, 3, 0)
      Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio_Venta", -1, Nothing, 105808334, 0, 0)
      Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc_Venta", -1, Nothing, 105808334, 1, 0)
      Dim Appearance61 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc2_Venta", -1, Nothing, 105808334, 2, 0)
      Dim Appearance62 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioNeto_Venta", -1, Nothing, 105808334, 3, 0)
      Dim Appearance63 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_PedidoVenta", -1, Nothing, 105808334, 4, 0)
      Dim Appearance64 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_PedidoVenta_tolerancia")
      Dim Appearance65 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad_PedidoWeb", -1, Nothing, 105808329, 2, 0)
      Dim Appearance66 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Precio_PedidoWeb", -1, Nothing, 105808344, 0, 0)
      Dim Appearance67 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoPorc_PedidoWeb", -1, Nothing, 105808344, 1, 0)
      Dim Appearance68 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_PedidoWebPedido", -1, Nothing, 105808333, 4, 0)
      Dim Appearance69 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_PedidoWebPedido_tolerancia")
      Dim Appearance70 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Diferencia_Consolidada", -1, Nothing, 105824126, 0, 0)
      Dim Appearance71 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup5 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(105808329)
      Dim UltraGridGroup6 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Pedido", 105808330)
      Dim UltraGridGroup7 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Venta", 105808331)
      Dim UltraGridGroup8 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(105808332)
      Dim UltraGridGroup9 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(105808333)
      Dim UltraGridGroup10 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(105808334)
      Dim UltraGridGroup11 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Pedido Web", 105808344)
      Dim UltraGridGroup12 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("NewGroup7", 105824126)
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tssQuitarMarcaProcesado = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.lblEvaluar = New Eniac.Controles.Label()
      Me.cmbEvaluar = New Eniac.Controles.ComboBox()
      Me.lblTolerancia = New Eniac.Controles.Label()
      Me.txtTolerancia = New Eniac.Controles.TextBox()
      Me.chbFechaPedido = New Eniac.Controles.CheckBox()
      Me.chbMesCompletoFechaPedidos = New Eniac.Controles.CheckBox()
      Me.dtpHastaFechaPedidos = New Eniac.Controles.DateTimePicker()
      Me.lblHastaFechaPedidos = New Eniac.Controles.Label()
      Me.dtpDesdeFechaPedidos = New Eniac.Controles.DateTimePicker()
      Me.lblDesdeFechaPedidos = New Eniac.Controles.Label()
      Me.bscNombreCliente = New Eniac.Controles.Buscador2()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.tbpComprobantes = New System.Windows.Forms.TabPage()
      Me.tbpDetallado = New System.Windows.Forms.TabPage()
      Me.ugDetalleDetallado = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFiltros.SuspendLayout()
      Me.stsStado.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.tbpComprobantes.SuspendLayout()
      Me.tbpDetallado.SuspendLayout()
      CType(Me.ugDetalleDetallado, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.tssQuitarMarcaProcesado, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1067, 29)
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
      'tssQuitarMarcaProcesado
      '
      Me.tssQuitarMarcaProcesado.Name = "tssQuitarMarcaProcesado"
      Me.tssQuitarMarcaProcesado.Size = New System.Drawing.Size(6, 29)
      '
      'tsbPreferencias
      '
      Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPreferencias.Name = "tsbPreferencias"
      Me.tsbPreferencias.Size = New System.Drawing.Size(75, 26)
      Me.tsbPreferencias.Text = "&Preferencias"
      Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
      Me.tsbPreferencias.Visible = False
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
      'UltraGridPrintDocument1
      '
      Me.UltraGridPrintDocument1.DocumentName = "Informe"
      Me.UltraGridPrintDocument1.Footer.TextCenter = ""
      Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
      Appearance43.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Appearance43.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
      Me.UltraGridPrintDocument1.Header.Appearance = Appearance43
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
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn58.CellAppearance = Appearance2
      UltraGridColumn58.Header.Caption = "S."
      UltraGridColumn58.Header.VisiblePosition = 3
      UltraGridColumn58.Width = 30
      UltraGridColumn59.Header.Caption = "Tipo"
      UltraGridColumn59.Header.VisiblePosition = 4
      UltraGridColumn60.Header.Caption = "L"
      UltraGridColumn60.Header.VisiblePosition = 5
      UltraGridColumn60.Width = 30
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn61.CellAppearance = Appearance3
      UltraGridColumn61.Header.Caption = "Emisor"
      UltraGridColumn61.Header.VisiblePosition = 6
      UltraGridColumn61.Width = 50
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn62.CellAppearance = Appearance4
      UltraGridColumn62.Header.Caption = "Número"
      UltraGridColumn62.Header.VisiblePosition = 7
      UltraGridColumn62.Width = 70
      UltraGridColumn63.Header.Caption = "Estado"
      UltraGridColumn63.Header.VisiblePosition = 8
      Appearance5.TextHAlignAsString = "Center"
      UltraGridColumn64.CellAppearance = Appearance5
      UltraGridColumn64.Format = "dd/MM/yyyy"
      UltraGridColumn64.Header.Caption = "Fecha"
      UltraGridColumn64.Header.VisiblePosition = 9
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn65.CellAppearance = Appearance6
      UltraGridColumn65.Header.Caption = "S."
      UltraGridColumn65.Header.VisiblePosition = 10
      UltraGridColumn65.Width = 30
      UltraGridColumn66.Header.Caption = "Tipo"
      UltraGridColumn66.Header.VisiblePosition = 11
      UltraGridColumn67.Header.Caption = "L"
      UltraGridColumn67.Header.VisiblePosition = 12
      UltraGridColumn67.Width = 30
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn68.CellAppearance = Appearance7
      UltraGridColumn68.Header.Caption = "Emisor"
      UltraGridColumn68.Header.VisiblePosition = 13
      UltraGridColumn68.Width = 50
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn69.CellAppearance = Appearance8
      UltraGridColumn69.Header.Caption = "Número"
      UltraGridColumn69.Header.VisiblePosition = 14
      UltraGridColumn69.Width = 70
      UltraGridColumn70.Format = "dd/MM/yyyy"
      UltraGridColumn70.Header.Caption = "Fecha"
      UltraGridColumn70.Header.VisiblePosition = 15
      Appearance9.TextHAlignAsString = "Right"
      UltraGridColumn71.CellAppearance = Appearance9
      UltraGridColumn71.Header.VisiblePosition = 16
      UltraGridColumn71.Hidden = True
      Appearance10.TextHAlignAsString = "Right"
      UltraGridColumn72.CellAppearance = Appearance10
      UltraGridColumn72.Header.Caption = "Código"
      UltraGridColumn72.Header.VisiblePosition = 17
      UltraGridColumn72.Width = 64
      UltraGridColumn73.Header.Caption = "Cliente"
      UltraGridColumn73.Header.VisiblePosition = 18
      UltraGridColumn73.Width = 332
      Appearance11.TextHAlignAsString = "Right"
      UltraGridColumn74.CellAppearance = Appearance11
      UltraGridColumn74.Header.Caption = "Pedido Web"
      UltraGridColumn74.Header.VisiblePosition = 1
      UltraGridColumn74.Width = 67
      UltraGridColumn75.Header.VisiblePosition = 19
      UltraGridColumn75.Hidden = True
      Appearance12.TextHAlignAsString = "Center"
      UltraGridColumn76.CellAppearance = Appearance12
      UltraGridColumn76.Format = "dd/MM/yyyy"
      UltraGridColumn76.Header.Caption = "Fecha Pedido Web"
      UltraGridColumn76.Header.VisiblePosition = 2
      UltraGridColumn77.Header.VisiblePosition = 20
      UltraGridColumn77.Hidden = True
      UltraGridColumn78.Header.VisiblePosition = 21
      Appearance13.ImageHAlign = Infragistics.Win.HAlign.Center
      UltraGridColumn79.CellAppearance = Appearance13
      UltraGridColumn79.Header.Caption = "Dif."
      UltraGridColumn79.Header.VisiblePosition = 0
      UltraGridColumn79.Width = 37
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79})
      UltraGridColumn80.Header.VisiblePosition = 0
      UltraGridColumn80.Hidden = True
      UltraGridColumn81.Header.VisiblePosition = 1
      UltraGridColumn81.Hidden = True
      UltraGridColumn82.Header.VisiblePosition = 2
      UltraGridColumn82.Hidden = True
      UltraGridColumn83.Header.VisiblePosition = 3
      UltraGridColumn83.Hidden = True
      UltraGridColumn84.Header.VisiblePosition = 4
      UltraGridColumn84.Hidden = True
      UltraGridColumn85.Header.VisiblePosition = 5
      UltraGridColumn85.Hidden = True
      UltraGridColumn86.Header.VisiblePosition = 6
      UltraGridColumn86.Hidden = True
      UltraGridColumn87.Header.VisiblePosition = 7
      UltraGridColumn87.Hidden = True
      UltraGridColumn88.Header.VisiblePosition = 8
      UltraGridColumn88.Hidden = True
      UltraGridColumn89.Header.VisiblePosition = 9
      UltraGridColumn89.Hidden = True
      UltraGridColumn90.Header.VisiblePosition = 10
      UltraGridColumn90.Hidden = True
      UltraGridColumn91.Header.VisiblePosition = 11
      UltraGridColumn91.Hidden = True
      UltraGridColumn92.Header.VisiblePosition = 12
      UltraGridColumn92.Hidden = True
      UltraGridColumn93.Header.VisiblePosition = 13
      UltraGridColumn93.Hidden = True
      UltraGridColumn94.Header.VisiblePosition = 14
      UltraGridColumn94.Hidden = True
      UltraGridColumn95.Header.VisiblePosition = 15
      UltraGridColumn95.Hidden = True
      Appearance14.TextHAlignAsString = "Right"
      UltraGridColumn96.CellAppearance = Appearance14
      UltraGridColumn96.Header.Caption = "Código"
      UltraGridColumn96.Width = 77
      UltraGridColumn97.Header.Caption = "Producto"
      UltraGridColumn97.Width = 131
      Appearance15.TextHAlignAsString = "Right"
      UltraGridColumn98.CellAppearance = Appearance15
      UltraGridColumn98.Format = "N2"
      UltraGridColumn98.Header.Caption = "Cantidad"
      UltraGridColumn98.Width = 90
      Appearance16.TextHAlignAsString = "Right"
      UltraGridColumn99.CellAppearance = Appearance16
      UltraGridColumn99.Format = "N2"
      UltraGridColumn99.Header.Caption = "Precio"
      UltraGridColumn99.Width = 90
      Appearance17.TextHAlignAsString = "Right"
      UltraGridColumn100.CellAppearance = Appearance17
      UltraGridColumn100.Format = "N2"
      UltraGridColumn100.Header.Caption = "D/R 1"
      UltraGridColumn100.Width = 90
      Appearance18.TextHAlignAsString = "Right"
      UltraGridColumn101.CellAppearance = Appearance18
      UltraGridColumn101.Format = "N2"
      UltraGridColumn101.Header.Caption = "D/R 2"
      UltraGridColumn101.Width = 90
      Appearance19.TextHAlignAsString = "Right"
      UltraGridColumn102.CellAppearance = Appearance19
      UltraGridColumn102.Format = "N2"
      UltraGridColumn102.Header.Caption = "Precio Neto"
      UltraGridColumn102.Width = 90
      Appearance20.TextHAlignAsString = "Right"
      UltraGridColumn103.CellAppearance = Appearance20
      UltraGridColumn103.Format = "N2"
      UltraGridColumn103.Header.Caption = "Cantidad"
      UltraGridColumn103.Width = 90
      Appearance21.TextHAlignAsString = "Right"
      UltraGridColumn104.CellAppearance = Appearance21
      UltraGridColumn104.Format = "N2"
      UltraGridColumn104.Header.Caption = "Precio"
      UltraGridColumn104.Width = 90
      Appearance22.TextHAlignAsString = "Right"
      UltraGridColumn105.CellAppearance = Appearance22
      UltraGridColumn105.Format = "N2"
      UltraGridColumn105.Header.Caption = "D/R 1"
      UltraGridColumn105.Width = 90
      Appearance23.TextHAlignAsString = "Right"
      UltraGridColumn106.CellAppearance = Appearance23
      UltraGridColumn106.Format = "N2"
      UltraGridColumn106.Header.Caption = "D/R 2"
      UltraGridColumn106.Width = 90
      Appearance24.TextHAlignAsString = "Right"
      UltraGridColumn107.CellAppearance = Appearance24
      UltraGridColumn107.Format = "N2"
      UltraGridColumn107.Header.Caption = "Precio Neto"
      UltraGridColumn107.Width = 90
      Appearance25.TextHAlignAsString = "Right"
      UltraGridColumn108.CellAppearance = Appearance25
      UltraGridColumn108.Header.Caption = "Diferencia"
      UltraGridColumn108.Width = 50
      Appearance26.TextHAlignAsString = "Right"
      UltraGridColumn109.CellAppearance = Appearance26
      UltraGridColumn109.Format = "N2"
      UltraGridColumn109.Header.Caption = "Cantidad"
      UltraGridColumn109.Width = 90
      Appearance27.TextHAlignAsString = "Right"
      UltraGridColumn110.CellAppearance = Appearance27
      UltraGridColumn110.Format = "N2"
      UltraGridColumn110.Header.Caption = "Precio"
      UltraGridColumn110.Width = 90
      Appearance28.TextHAlignAsString = "Right"
      UltraGridColumn111.CellAppearance = Appearance28
      UltraGridColumn111.Format = "N2"
      UltraGridColumn111.Header.Caption = "D/R"
      UltraGridColumn111.Width = 90
      Appearance29.TextHAlignAsString = "Right"
      UltraGridColumn112.CellAppearance = Appearance29
      UltraGridColumn112.Format = "N2"
      UltraGridColumn112.Header.Caption = "Diferencia"
      UltraGridColumn112.Width = 50
      Appearance30.ImageHAlign = Infragistics.Win.HAlign.Center
      UltraGridColumn113.CellAppearance = Appearance30
      UltraGridColumn113.DataType = GetType(System.Drawing.Bitmap)
      UltraGridColumn113.Header.Caption = "Dif"
      Appearance31.ImageHAlign = Infragistics.Win.HAlign.Center
      UltraGridColumn114.CellAppearance = Appearance31
      UltraGridColumn114.DataType = GetType(System.Drawing.Bitmap)
      UltraGridColumn114.Header.Caption = "Dif."
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn83, UltraGridColumn84, UltraGridColumn85, UltraGridColumn86, UltraGridColumn87, UltraGridColumn88, UltraGridColumn89, UltraGridColumn90, UltraGridColumn91, UltraGridColumn92, UltraGridColumn93, UltraGridColumn94, UltraGridColumn95, UltraGridColumn96, UltraGridColumn97, UltraGridColumn98, UltraGridColumn99, UltraGridColumn100, UltraGridColumn101, UltraGridColumn102, UltraGridColumn103, UltraGridColumn104, UltraGridColumn105, UltraGridColumn106, UltraGridColumn107, UltraGridColumn108, UltraGridColumn109, UltraGridColumn110, UltraGridColumn111, UltraGridColumn112, UltraGridColumn113, UltraGridColumn114})
      UltraGridGroup1.Header.VisiblePosition = 2
      UltraGridGroup1.Key = "Pedido"
      UltraGridGroup2.Header.VisiblePosition = 3
      UltraGridGroup2.Key = "Venta"
      UltraGridGroup3.Header.VisiblePosition = 0
      UltraGridGroup4.Header.VisiblePosition = 1
      UltraGridGroup4.Key = "Pedido Web"
      UltraGridBand2.Groups.AddRange(New Infragistics.Win.UltraWinGrid.UltraGridGroup() {UltraGridGroup1, UltraGridGroup2, UltraGridGroup3, UltraGridGroup4})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance32.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance32.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance32
      Appearance33.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance33
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar."
      Appearance34.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance34.BackColor2 = System.Drawing.SystemColors.Control
      Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance34.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance34
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance35.BackColor = System.Drawing.SystemColors.Window
      Appearance35.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance35
      Appearance36.BackColor = System.Drawing.SystemColors.Highlight
      Appearance36.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance36
      Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance37.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance37
      Appearance38.BorderColor = System.Drawing.Color.Silver
      Appearance38.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance38
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance39.BackColor = System.Drawing.SystemColors.Control
      Appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance39.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance39.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance39
      Appearance40.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance40
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance41.BackColor = System.Drawing.SystemColors.Window
      Appearance41.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance41
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
      Appearance42.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance42
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(1025, 360)
      Me.ugDetalle.TabIndex = 1
      '
      'UltraPrintPreviewDialog1
      '
      Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
      '
      'grbFiltros
      '
      Me.grbFiltros.Controls.Add(Me.lblEvaluar)
      Me.grbFiltros.Controls.Add(Me.cmbEvaluar)
      Me.grbFiltros.Controls.Add(Me.lblTolerancia)
      Me.grbFiltros.Controls.Add(Me.txtTolerancia)
      Me.grbFiltros.Controls.Add(Me.chbFechaPedido)
      Me.grbFiltros.Controls.Add(Me.chbMesCompletoFechaPedidos)
      Me.grbFiltros.Controls.Add(Me.dtpHastaFechaPedidos)
      Me.grbFiltros.Controls.Add(Me.dtpDesdeFechaPedidos)
      Me.grbFiltros.Controls.Add(Me.lblHastaFechaPedidos)
      Me.grbFiltros.Controls.Add(Me.lblDesdeFechaPedidos)
      Me.grbFiltros.Controls.Add(Me.bscNombreCliente)
      Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grbFiltros.Controls.Add(Me.chkExpandAll)
      Me.grbFiltros.Controls.Add(Me.btnConsultar)
      Me.grbFiltros.Controls.Add(Me.chbCliente)
      Me.grbFiltros.Location = New System.Drawing.Point(12, 32)
      Me.grbFiltros.Name = "grbFiltros"
      Me.grbFiltros.Size = New System.Drawing.Size(1039, 84)
      Me.grbFiltros.TabIndex = 0
      Me.grbFiltros.TabStop = False
      Me.grbFiltros.Text = "Filtros"
      '
      'lblEvaluar
      '
      Me.lblEvaluar.AutoSize = True
      Me.lblEvaluar.LabelAsoc = Nothing
      Me.lblEvaluar.Location = New System.Drawing.Point(711, 49)
      Me.lblEvaluar.Name = "lblEvaluar"
      Me.lblEvaluar.Size = New System.Drawing.Size(43, 13)
      Me.lblEvaluar.TabIndex = 23
      Me.lblEvaluar.Text = "Evaluar"
      '
      'cmbEvaluar
      '
      Me.cmbEvaluar.BindearPropiedadControl = ""
      Me.cmbEvaluar.BindearPropiedadEntidad = ""
      Me.cmbEvaluar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEvaluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEvaluar.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEvaluar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEvaluar.FormattingEnabled = True
      Me.cmbEvaluar.IsPK = False
      Me.cmbEvaluar.IsRequired = False
      Me.cmbEvaluar.Key = Nothing
      Me.cmbEvaluar.LabelAsoc = Me.lblEvaluar
      Me.cmbEvaluar.Location = New System.Drawing.Point(760, 45)
      Me.cmbEvaluar.Name = "cmbEvaluar"
      Me.cmbEvaluar.Size = New System.Drawing.Size(140, 21)
      Me.cmbEvaluar.TabIndex = 24
      '
      'lblTolerancia
      '
      Me.lblTolerancia.AutoSize = True
      Me.lblTolerancia.LabelAsoc = Nothing
      Me.lblTolerancia.Location = New System.Drawing.Point(565, 47)
      Me.lblTolerancia.Name = "lblTolerancia"
      Me.lblTolerancia.Size = New System.Drawing.Size(57, 13)
      Me.lblTolerancia.TabIndex = 21
      Me.lblTolerancia.Text = "Tolerancia"
      '
      'txtTolerancia
      '
      Me.txtTolerancia.BackColor = System.Drawing.SystemColors.Window
      Me.txtTolerancia.BindearPropiedadControl = Nothing
      Me.txtTolerancia.BindearPropiedadEntidad = Nothing
      Me.txtTolerancia.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTolerancia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTolerancia.Formato = ""
      Me.txtTolerancia.IsDecimal = False
      Me.txtTolerancia.IsNumber = True
      Me.txtTolerancia.IsPK = False
      Me.txtTolerancia.IsRequired = False
      Me.txtTolerancia.Key = ""
      Me.txtTolerancia.LabelAsoc = Me.lblTolerancia
      Me.txtTolerancia.Location = New System.Drawing.Point(628, 45)
      Me.txtTolerancia.MaxLength = 8
      Me.txtTolerancia.Name = "txtTolerancia"
      Me.txtTolerancia.Size = New System.Drawing.Size(65, 20)
      Me.txtTolerancia.TabIndex = 22
      Me.txtTolerancia.Text = "0.10"
      Me.txtTolerancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbFechaPedido
      '
      Me.chbFechaPedido.AutoSize = True
      Me.chbFechaPedido.BindearPropiedadControl = Nothing
      Me.chbFechaPedido.BindearPropiedadEntidad = Nothing
      Me.chbFechaPedido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaPedido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaPedido.IsPK = False
      Me.chbFechaPedido.IsRequired = False
      Me.chbFechaPedido.Key = Nothing
      Me.chbFechaPedido.LabelAsoc = Nothing
      Me.chbFechaPedido.Location = New System.Drawing.Point(10, 19)
      Me.chbFechaPedido.Name = "chbFechaPedido"
      Me.chbFechaPedido.Size = New System.Drawing.Size(107, 17)
      Me.chbFechaPedido.TabIndex = 0
      Me.chbFechaPedido.Text = "Fecha de Pedido"
      Me.chbFechaPedido.UseVisualStyleBackColor = True
      '
      'chbMesCompletoFechaPedidos
      '
      Me.chbMesCompletoFechaPedidos.AutoSize = True
      Me.chbMesCompletoFechaPedidos.BindearPropiedadControl = Nothing
      Me.chbMesCompletoFechaPedidos.BindearPropiedadEntidad = Nothing
      Me.chbMesCompletoFechaPedidos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMesCompletoFechaPedidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMesCompletoFechaPedidos.IsPK = False
      Me.chbMesCompletoFechaPedidos.IsRequired = False
      Me.chbMesCompletoFechaPedidos.Key = Nothing
      Me.chbMesCompletoFechaPedidos.LabelAsoc = Nothing
      Me.chbMesCompletoFechaPedidos.Location = New System.Drawing.Point(129, 21)
      Me.chbMesCompletoFechaPedidos.Name = "chbMesCompletoFechaPedidos"
      Me.chbMesCompletoFechaPedidos.Size = New System.Drawing.Size(93, 17)
      Me.chbMesCompletoFechaPedidos.TabIndex = 1
      Me.chbMesCompletoFechaPedidos.Text = "Mes Completo"
      Me.chbMesCompletoFechaPedidos.UseVisualStyleBackColor = True
      '
      'dtpHastaFechaPedidos
      '
      Me.dtpHastaFechaPedidos.BindearPropiedadControl = Nothing
      Me.dtpHastaFechaPedidos.BindearPropiedadEntidad = Nothing
      Me.dtpHastaFechaPedidos.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpHastaFechaPedidos.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHastaFechaPedidos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHastaFechaPedidos.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHastaFechaPedidos.IsPK = False
      Me.dtpHastaFechaPedidos.IsRequired = False
      Me.dtpHastaFechaPedidos.Key = ""
      Me.dtpHastaFechaPedidos.LabelAsoc = Me.lblHastaFechaPedidos
      Me.dtpHastaFechaPedidos.Location = New System.Drawing.Point(450, 19)
      Me.dtpHastaFechaPedidos.Name = "dtpHastaFechaPedidos"
      Me.dtpHastaFechaPedidos.Size = New System.Drawing.Size(125, 20)
      Me.dtpHastaFechaPedidos.TabIndex = 5
      '
      'lblHastaFechaPedidos
      '
      Me.lblHastaFechaPedidos.AutoSize = True
      Me.lblHastaFechaPedidos.LabelAsoc = Nothing
      Me.lblHastaFechaPedidos.Location = New System.Drawing.Point(413, 23)
      Me.lblHastaFechaPedidos.Name = "lblHastaFechaPedidos"
      Me.lblHastaFechaPedidos.Size = New System.Drawing.Size(35, 13)
      Me.lblHastaFechaPedidos.TabIndex = 4
      Me.lblHastaFechaPedidos.Text = "Hasta"
      '
      'dtpDesdeFechaPedidos
      '
      Me.dtpDesdeFechaPedidos.BindearPropiedadControl = Nothing
      Me.dtpDesdeFechaPedidos.BindearPropiedadEntidad = Nothing
      Me.dtpDesdeFechaPedidos.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpDesdeFechaPedidos.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesdeFechaPedidos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesdeFechaPedidos.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesdeFechaPedidos.IsPK = False
      Me.dtpDesdeFechaPedidos.IsRequired = False
      Me.dtpDesdeFechaPedidos.Key = ""
      Me.dtpDesdeFechaPedidos.LabelAsoc = Me.lblDesdeFechaPedidos
      Me.dtpDesdeFechaPedidos.Location = New System.Drawing.Point(270, 19)
      Me.dtpDesdeFechaPedidos.Name = "dtpDesdeFechaPedidos"
      Me.dtpDesdeFechaPedidos.Size = New System.Drawing.Size(125, 20)
      Me.dtpDesdeFechaPedidos.TabIndex = 3
      '
      'lblDesdeFechaPedidos
      '
      Me.lblDesdeFechaPedidos.AutoSize = True
      Me.lblDesdeFechaPedidos.LabelAsoc = Nothing
      Me.lblDesdeFechaPedidos.Location = New System.Drawing.Point(226, 23)
      Me.lblDesdeFechaPedidos.Name = "lblDesdeFechaPedidos"
      Me.lblDesdeFechaPedidos.Size = New System.Drawing.Size(38, 13)
      Me.lblDesdeFechaPedidos.TabIndex = 2
      Me.lblDesdeFechaPedidos.Text = "Desde"
      '
      'bscNombreCliente
      '
      Me.bscNombreCliente.ActivarFiltroEnGrilla = True
      Me.bscNombreCliente.BindearPropiedadControl = Nothing
      Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
      Me.bscNombreCliente.ConfigBuscador = Nothing
      Me.bscNombreCliente.Datos = Nothing
      Me.bscNombreCliente.Enabled = False
      Me.bscNombreCliente.FilaDevuelta = Nothing
      Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreCliente.IsDecimal = False
      Me.bscNombreCliente.IsNumber = False
      Me.bscNombreCliente.IsPK = False
      Me.bscNombreCliente.IsRequired = False
      Me.bscNombreCliente.Key = ""
      Me.bscNombreCliente.LabelAsoc = Nothing
      Me.bscNombreCliente.Location = New System.Drawing.Point(266, 44)
      Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
      Me.bscNombreCliente.MaxLengh = "32767"
      Me.bscNombreCliente.Name = "bscNombreCliente"
      Me.bscNombreCliente.Permitido = True
      Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreCliente.Selecciono = False
      Me.bscNombreCliente.Size = New System.Drawing.Size(272, 23)
      Me.bscNombreCliente.TabIndex = 18
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
      Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Nothing
      Me.bscCodigoCliente.Location = New System.Drawing.Point(129, 44)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(133, 23)
      Me.bscCodigoCliente.TabIndex = 17
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Location = New System.Drawing.Point(933, 61)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(96, 20)
      Me.chkExpandAll.TabIndex = 20
      Me.chkExpandAll.Text = "Expandir todo"
      '
      'btnConsultar
      '
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(933, 13)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 19
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
      Me.chbCliente.Location = New System.Drawing.Point(10, 47)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 16
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 517)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(1067, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(988, 17)
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
      'TabControl1
      '
      Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl1.Controls.Add(Me.tbpComprobantes)
      Me.TabControl1.Controls.Add(Me.tbpDetallado)
      Me.TabControl1.Location = New System.Drawing.Point(12, 122)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(1039, 392)
      Me.TabControl1.TabIndex = 4
      '
      'tbpComprobantes
      '
      Me.tbpComprobantes.Controls.Add(Me.ugDetalle)
      Me.tbpComprobantes.Location = New System.Drawing.Point(4, 22)
      Me.tbpComprobantes.Name = "tbpComprobantes"
      Me.tbpComprobantes.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpComprobantes.Size = New System.Drawing.Size(1031, 366)
      Me.tbpComprobantes.TabIndex = 0
      Me.tbpComprobantes.Text = "Comprobantes"
      Me.tbpComprobantes.UseVisualStyleBackColor = True
      '
      'tbpDetallado
      '
      Me.tbpDetallado.Controls.Add(Me.ugDetalleDetallado)
      Me.tbpDetallado.Location = New System.Drawing.Point(4, 22)
      Me.tbpDetallado.Name = "tbpDetallado"
      Me.tbpDetallado.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpDetallado.Size = New System.Drawing.Size(1031, 366)
      Me.tbpDetallado.TabIndex = 1
      Me.tbpDetallado.Text = "Detallado"
      Me.tbpDetallado.UseVisualStyleBackColor = True
      '
      'ugDetalleDetallado
      '
      Appearance44.BackColor = System.Drawing.SystemColors.Window
      Appearance44.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalleDetallado.DisplayLayout.Appearance = Appearance44
      Appearance45.TextHAlignAsString = "Right"
      UltraGridColumn36.CellAppearance = Appearance45
      UltraGridColumn36.Header.Caption = "Pedido Web"
      UltraGridColumn36.Width = 67
      UltraGridColumn37.Header.VisiblePosition = 1
      UltraGridColumn37.Hidden = True
      UltraGridColumn38.Header.Caption = "Fecha Pedido Web"
      UltraGridColumn38.Width = 90
      UltraGridColumn39.Header.VisiblePosition = 3
      UltraGridColumn39.Hidden = True
      Appearance46.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance46
      UltraGridColumn1.Header.Caption = "S."
      UltraGridColumn1.Width = 30
      UltraGridColumn2.Header.Caption = "Tipo"
      UltraGridColumn3.Header.Caption = "L"
      UltraGridColumn3.Width = 30
      Appearance47.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance47
      UltraGridColumn4.Header.Caption = "Emisor"
      UltraGridColumn4.Width = 50
      Appearance48.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance48
      UltraGridColumn5.Header.Caption = "Número"
      UltraGridColumn5.Width = 70
      UltraGridColumn33.Header.Caption = "Estado"
      UltraGridColumn34.Header.Caption = "Fecha"
      Appearance49.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance49
      UltraGridColumn6.Header.Caption = "S."
      UltraGridColumn6.Width = 30
      UltraGridColumn7.Header.Caption = "Tipo"
      UltraGridColumn8.Header.Caption = "L"
      UltraGridColumn8.Width = 30
      Appearance50.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance50
      UltraGridColumn9.Header.Caption = "Emisor"
      UltraGridColumn9.Width = 50
      Appearance51.TextHAlignAsString = "Right"
      UltraGridColumn10.CellAppearance = Appearance51
      UltraGridColumn10.Header.Caption = "Número"
      UltraGridColumn10.Width = 70
      UltraGridColumn35.Header.Caption = "Fecha"
      Appearance52.TextHAlignAsString = "Right"
      UltraGridColumn30.CellAppearance = Appearance52
      UltraGridColumn30.Header.VisiblePosition = 8
      UltraGridColumn30.Hidden = True
      Appearance53.TextHAlignAsString = "Right"
      UltraGridColumn31.CellAppearance = Appearance53
      UltraGridColumn31.Header.Caption = "Código"
      UltraGridColumn32.Header.Caption = "Cliente"
      UltraGridColumn32.Width = 330
      UltraGridColumn11.Header.Caption = "Código"
      UltraGridColumn11.Width = 77
      UltraGridColumn12.Header.Caption = "Producto"
      UltraGridColumn12.Width = 131
      Appearance54.TextHAlignAsString = "Right"
      UltraGridColumn13.CellAppearance = Appearance54
      UltraGridColumn13.Format = "N2"
      UltraGridColumn13.Header.Caption = "Cantidad"
      UltraGridColumn13.Width = 90
      Appearance55.TextHAlignAsString = "Right"
      UltraGridColumn14.CellAppearance = Appearance55
      UltraGridColumn14.Format = "N2"
      UltraGridColumn14.Header.Caption = "Cantidad"
      UltraGridColumn14.Width = 90
      Appearance56.TextHAlignAsString = "Right"
      UltraGridColumn15.CellAppearance = Appearance56
      UltraGridColumn15.Format = "N2"
      UltraGridColumn15.Header.Caption = "Precio"
      UltraGridColumn15.Width = 90
      Appearance57.TextHAlignAsString = "Right"
      UltraGridColumn16.CellAppearance = Appearance57
      UltraGridColumn16.Format = "N2"
      UltraGridColumn16.Header.Caption = "D/R 1"
      UltraGridColumn16.Width = 90
      Appearance58.TextHAlignAsString = "Right"
      UltraGridColumn17.CellAppearance = Appearance58
      UltraGridColumn17.Format = "N2"
      UltraGridColumn17.Header.Caption = "D/R 2"
      UltraGridColumn17.Width = 90
      Appearance59.TextHAlignAsString = "Right"
      UltraGridColumn18.CellAppearance = Appearance59
      UltraGridColumn18.Format = "N2"
      UltraGridColumn18.Header.Caption = "Precio Neto"
      UltraGridColumn18.Width = 90
      Appearance60.TextHAlignAsString = "Right"
      UltraGridColumn19.CellAppearance = Appearance60
      UltraGridColumn19.Format = "N2"
      UltraGridColumn19.Header.Caption = "Precio"
      UltraGridColumn19.Width = 90
      Appearance61.TextHAlignAsString = "Right"
      UltraGridColumn20.CellAppearance = Appearance61
      UltraGridColumn20.Format = "N2"
      UltraGridColumn20.Header.Caption = "D/R 1"
      UltraGridColumn20.Width = 90
      Appearance62.TextHAlignAsString = "Right"
      UltraGridColumn21.CellAppearance = Appearance62
      UltraGridColumn21.Format = "N2"
      UltraGridColumn21.Header.Caption = "D/R 2"
      UltraGridColumn21.Width = 90
      Appearance63.TextHAlignAsString = "Right"
      UltraGridColumn22.CellAppearance = Appearance63
      UltraGridColumn22.Format = "N2"
      UltraGridColumn22.Header.Caption = "Precio Neto"
      UltraGridColumn22.Width = 90
      Appearance64.TextHAlignAsString = "Right"
      UltraGridColumn23.CellAppearance = Appearance64
      UltraGridColumn23.Format = "N2"
      UltraGridColumn23.Header.Caption = "Dif."
      UltraGridColumn23.Width = 50
      Appearance65.TextHAlignAsString = "Right"
      UltraGridColumn24.CellAppearance = Appearance65
      UltraGridColumn24.Format = "N2"
      UltraGridColumn24.Header.VisiblePosition = 13
      UltraGridColumn24.Width = 50
      Appearance66.TextHAlignAsString = "Right"
      UltraGridColumn25.CellAppearance = Appearance66
      UltraGridColumn25.Format = "N2"
      UltraGridColumn25.Header.Caption = "Cantidad"
      UltraGridColumn25.Width = 90
      Appearance67.TextHAlignAsString = "Right"
      UltraGridColumn26.CellAppearance = Appearance67
      UltraGridColumn26.Format = "N2"
      UltraGridColumn26.Header.Caption = "Precio"
      UltraGridColumn26.Width = 90
      Appearance68.TextHAlignAsString = "Right"
      UltraGridColumn27.CellAppearance = Appearance68
      UltraGridColumn27.Format = "N2"
      UltraGridColumn27.Header.Caption = "D/R"
      UltraGridColumn27.Width = 90
      Appearance69.TextHAlignAsString = "Right"
      UltraGridColumn28.CellAppearance = Appearance69
      UltraGridColumn28.Format = "N2"
      UltraGridColumn28.Header.Caption = "Dif."
      UltraGridColumn28.Width = 50
      Appearance70.TextHAlignAsString = "Right"
      UltraGridColumn29.CellAppearance = Appearance70
      UltraGridColumn29.Format = "N2"
      UltraGridColumn29.Header.VisiblePosition = 19
      UltraGridColumn29.Width = 50
      Appearance71.TextHAlignAsString = "Right"
      UltraGridColumn40.CellAppearance = Appearance71
      UltraGridColumn40.Format = "N2"
      UltraGridColumn40.Header.Caption = "Dif. Neta"
      UltraGridColumn40.Width = 49
      UltraGridBand3.Columns.AddRange(New Object() {UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn33, UltraGridColumn34, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn35, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn40})
      UltraGridGroup5.Header.Caption = "Pedido Web"
      UltraGridGroup5.Header.VisiblePosition = 1
      UltraGridGroup6.Header.VisiblePosition = 2
      UltraGridGroup6.Key = "Pedido"
      UltraGridGroup7.Header.VisiblePosition = 3
      UltraGridGroup7.Key = "Venta"
      UltraGridGroup8.Header.VisiblePosition = 4
      UltraGridGroup9.Header.Caption = "Pedido"
      UltraGridGroup9.Header.VisiblePosition = 6
      UltraGridGroup10.Header.Caption = "Venta"
      UltraGridGroup10.Header.VisiblePosition = 7
      UltraGridGroup11.Header.VisiblePosition = 5
      UltraGridGroup11.Key = "Pedido Web"
      UltraGridGroup12.Header.Caption = ""
      UltraGridGroup12.Header.VisiblePosition = 0
      UltraGridGroup12.Key = "NewGroup7"
      UltraGridBand3.Groups.AddRange(New Infragistics.Win.UltraWinGrid.UltraGridGroup() {UltraGridGroup5, UltraGridGroup6, UltraGridGroup7, UltraGridGroup8, UltraGridGroup9, UltraGridGroup10, UltraGridGroup11, UltraGridGroup12})
      Me.ugDetalleDetallado.DisplayLayout.BandsSerializer.Add(UltraGridBand3)
      Me.ugDetalleDetallado.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance72.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance72.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance72.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance72.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalleDetallado.DisplayLayout.GroupByBox.Appearance = Appearance72
      Appearance73.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalleDetallado.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance73
      Me.ugDetalleDetallado.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalleDetallado.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar."
      Appearance74.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance74.BackColor2 = System.Drawing.SystemColors.Control
      Appearance74.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance74.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalleDetallado.DisplayLayout.GroupByBox.PromptAppearance = Appearance74
      Me.ugDetalleDetallado.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalleDetallado.DisplayLayout.MaxRowScrollRegions = 1
      Appearance75.BackColor = System.Drawing.SystemColors.Window
      Appearance75.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalleDetallado.DisplayLayout.Override.ActiveCellAppearance = Appearance75
      Appearance76.BackColor = System.Drawing.SystemColors.Highlight
      Appearance76.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalleDetallado.DisplayLayout.Override.ActiveRowAppearance = Appearance76
      Me.ugDetalleDetallado.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
      Me.ugDetalleDetallado.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalleDetallado.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalleDetallado.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalleDetallado.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance77.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalleDetallado.DisplayLayout.Override.CardAreaAppearance = Appearance77
      Appearance78.BorderColor = System.Drawing.Color.Silver
      Appearance78.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalleDetallado.DisplayLayout.Override.CellAppearance = Appearance78
      Me.ugDetalleDetallado.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalleDetallado.DisplayLayout.Override.CellPadding = 0
      Appearance79.BackColor = System.Drawing.SystemColors.Control
      Appearance79.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance79.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance79.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalleDetallado.DisplayLayout.Override.GroupByRowAppearance = Appearance79
      Appearance80.TextHAlignAsString = "Left"
      Me.ugDetalleDetallado.DisplayLayout.Override.HeaderAppearance = Appearance80
      Me.ugDetalleDetallado.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalleDetallado.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance81.BackColor = System.Drawing.SystemColors.Window
      Appearance81.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalleDetallado.DisplayLayout.Override.RowAppearance = Appearance81
      Me.ugDetalleDetallado.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalleDetallado.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalleDetallado.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.ugDetalleDetallado.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
      Appearance82.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalleDetallado.DisplayLayout.Override.TemplateAddRowAppearance = Appearance82
      Me.ugDetalleDetallado.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalleDetallado.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalleDetallado.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalleDetallado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalleDetallado.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalleDetallado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalleDetallado.Location = New System.Drawing.Point(3, 3)
      Me.ugDetalleDetallado.Name = "ugDetalleDetallado"
      Me.ugDetalleDetallado.Size = New System.Drawing.Size(1025, 360)
      Me.ugDetalleDetallado.TabIndex = 2
      '
      'InfPedidosFacturados
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1067, 539)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.grbFiltros)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "InfPedidosFacturados"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Informe de Pedidos Web de SiMovil"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFiltros.ResumeLayout(False)
      Me.grbFiltros.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.tbpComprobantes.ResumeLayout(False)
      Me.tbpDetallado.ResumeLayout(False)
      CType(Me.ugDetalleDetallado, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tssQuitarMarcaProcesado As System.Windows.Forms.ToolStripSeparator
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Protected WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Protected WithEvents btnConsultar As Eniac.Controles.Button
   Protected WithEvents chbCliente As Eniac.Controles.CheckBox
   Protected WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected WithEvents bscNombreCliente As Eniac.Controles.Buscador2
   Protected WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Protected WithEvents chbMesCompletoFechaPedidos As Eniac.Controles.CheckBox
   Protected WithEvents dtpHastaFechaPedidos As Eniac.Controles.DateTimePicker
   Protected WithEvents lblHastaFechaPedidos As Eniac.Controles.Label
   Protected WithEvents dtpDesdeFechaPedidos As Eniac.Controles.DateTimePicker
   Protected WithEvents lblDesdeFechaPedidos As Eniac.Controles.Label
   Protected WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Protected WithEvents chbFechaPedido As Eniac.Controles.CheckBox
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents tbpComprobantes As System.Windows.Forms.TabPage
   Friend WithEvents tbpDetallado As System.Windows.Forms.TabPage
   Protected WithEvents ugDetalleDetallado As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents lblTolerancia As Eniac.Controles.Label
   Friend WithEvents txtTolerancia As Eniac.Controles.TextBox
   Friend WithEvents lblEvaluar As Eniac.Controles.Label
   Friend WithEvents cmbEvaluar As Eniac.Controles.ComboBox
End Class
