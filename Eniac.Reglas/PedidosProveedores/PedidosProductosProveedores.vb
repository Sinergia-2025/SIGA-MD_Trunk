Public Class PedidosProductosProveedores
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.PedidoProductoProveedor.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.PedidoProductoProveedor)))
   End Sub
#End Region

#Region "Metodos Privados"

   Private Sub CargarUno(o As Entidades.PedidoProductoProveedor, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.PedidoProveedor.Columnas.IdSucursal.ToString()).ToString())
         .TipoComprobante = New TiposComprobantes(da).GetUno(dr(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString())
         .Letra = dr(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString())
         .Orden = Integer.Parse(dr("Orden").ToString())
         .Producto = New Productos(da).GetUno(dr("IdProducto").ToString())
         .Producto.NombreProducto = dr("NombreProducto").ToString()

         .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dr(Entidades.PedidoProveedor.Columnas.IdProveedor.ToString()).ToString()), False)

         .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
         .CostoLista = Decimal.Parse(dr("CostoLista").ToString())
         .Costo = Decimal.Parse(dr("Costo").ToString())
         .CostoNeto = Decimal.Parse(dr("CostoNeto").ToString())

         .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
         .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
         .DescuentoRecargoProducto = Decimal.Parse(dr("DescuentoRecargoProducto").ToString())

         .DescRecGeneral = Decimal.Parse(dr("DescRecGeneral").ToString())
         .DescRecGeneralProducto = Decimal.Parse(dr("DescRecGeneralProducto").ToString())

         .TipoImpuesto = New Reglas.TiposImpuestos(da).GetUno(DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), dr("IdTipoImpuesto").ToString()), Entidades.TipoImpuesto.Tipos))
         .AlicuotaImpuesto = Decimal.Parse(dr("AlicuotaImpuesto").ToString())
         .ImporteImpuesto = Decimal.Parse(dr("ImporteImpuesto").ToString())
         .ImpuestoInterno = Decimal.Parse(dr("ImpuestoInterno").ToString())
         .ImporteImpuestoInterno = Decimal.Parse(dr("ImporteImpuestoInterno").ToString())
         .PorcImpuestoInterno = Decimal.Parse(dr("PorcImpuestoInterno").ToString())

         .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())
         .ImporteTotalNeto = Decimal.Parse(dr("ImporteTotalNeto").ToString())

         .CantPendiente = Decimal.Parse(dr("CantPendiente").ToString())
         .CantEntregada = Decimal.Parse(dr("CantEntregada").ToString())
         .CantEnProceso = Decimal.Parse(dr("CantEnProceso").ToString())
         .CantAnulada = Decimal.Parse(dr("CantAnulada").ToString())

         If Not String.IsNullOrWhiteSpace(dr("FechaActualizacion").ToString()) Then
            .FechaActualizacion = Date.Parse(dr("FechaActualizacion").ToString())
         End If

         .IdUnidadDeMedidaCompra = dr.Field(Of String)(Entidades.PedidoProductoProveedor.Columnas.IdUnidadDeMedidaCompra.ToString())
         .CantidadUMCompra = dr.Field(Of Decimal)(Entidades.PedidoProductoProveedor.Columnas.CantidadUMCompra.ToString())
         .FactorConversionCompra = dr.Field(Of Decimal)(Entidades.PedidoProductoProveedor.Columnas.FactorConversionCompra.ToString())
         .PrecioPorUMCompra = dr.Field(Of Decimal)(Entidades.PedidoProductoProveedor.Columnas.PrecioPorUMCompra.ToString())

         'VERIFICO QUE ESTÉ LA COLUMNA POR SI FALTÓ AGREGARLA EN ALGÚN QUERY/DATATABLE
         If dr.Table.Columns.Contains(Entidades.VentaProducto.Columnas.CantPendiente.ToString()) AndAlso
            Not String.IsNullOrWhiteSpace(dr(Entidades.VentaProducto.Columnas.CantPendiente.ToString()).ToString()) Then
            .CantPendiente = Decimal.Parse(dr(Entidades.VentaProducto.Columnas.CantPendiente.ToString()).ToString())
         End If

         .IdCriticidad = dr("IdCriticidad").ToString()
         .FechaEntrega = DateTime.Parse(dr("FechaEntrega").ToString())

         'Dim sqlPE As SqlServer.PedidosEstadosProveedor = New SqlServer.PedidosEstadosProveedor(da)
         'Dim dt As DataTable = sqlPE.PedidosEstadosProveedor_GA(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroPedido, .Orden, .IdProducto)
         'If dt.Rows.Count > 0 Then
         '   .Criticidad = dt.Rows(0)("IdCriticidad").ToString()
         '   .FechaEntrega = DateTime.Parse(dt.Rows(0)("FechaEntrega").ToString())
         'End If

         .CostoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProductoProveedor.Columnas.CostoConImpuestos.ToString()).ToString())
         .CostoNetoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProductoProveedor.Columnas.CostoNetoConImpuestos.ToString()).ToString())
         .ImporteTotalConImpuestos = Decimal.Parse(dr(Entidades.PedidoProductoProveedor.Columnas.ImporteTotalConImpuestos.ToString()).ToString())
         .ImporteTotalNetoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProductoProveedor.Columnas.ImporteTotalNetoConImpuestos.ToString()).ToString())


         .PedidosEstados = New PedidosEstadosProveedores(da).GetTodos(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroPedido)

         .Stock = Decimal.Parse(dr("Stock").ToString())

      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Sub InsertaDetalleDesdePedido(oPedidos As Entidades.PedidoProveedor)
      Dim CategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      '-- REQ-32599.- - Se agrega ordenamiento de Pedido-
      Dim orden As Integer = 0
      For Each Prod As Entidades.PedidoProductoProveedor In oPedidos.PedidosProductos.OrderBy(Function(x) x.Orden)
         'grabo los productos del comprobante de venta
         Prod.TipoComprobante = oPedidos.TipoComprobante
         Prod.Letra = oPedidos.LetraComprobante
         Prod.CentroEmisor = oPedidos.CentroEmisor
         Prod.NumeroPedido = oPedidos.NumeroPedido

         If Not CategoriaFiscalEmpresa.IvaDiscriminado Or Not oPedidos.CategoriaFiscal.IvaDiscriminado Then
            Prod.CostoConImpuestos = Prod.Costo
            Prod.CostoNetoConImpuestos = Prod.CostoNeto
            Prod.ImporteTotalConImpuestos = Prod.ImporteTotal
            Prod.ImporteTotalNetoConImpuestos = Prod.ImporteTotalNeto


            Prod.Costo = Decimal.Round((Prod.Costo - (Prod.ImporteImpuestoInterno / Prod.Cantidad)) / (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100)), 2)
            Prod.DescuentoRecargoProducto = Decimal.Round(Prod.DescuentoRecargoProducto / (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100)), 2)
            Prod.DescRecGeneral = Decimal.Round(Prod.DescRecGeneral / (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100)), 2)
            Prod.ImporteTotal = Decimal.Round((Prod.ImporteTotal - (Prod.ImporteImpuestoInterno / Prod.Cantidad)) / (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100)), 2)

            Prod.PrecioPorUMCompra = Decimal.Round((Prod.PrecioPorUMCompra) / (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100)), 2) ' Se deja por fuera Impuestos Internos. Eventualmente analizar como se aplicaría

         Else
            Prod.CostoConImpuestos = (Prod.Costo * (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100))) + (Prod.ImporteImpuestoInterno / Prod.Cantidad)
            Prod.CostoNetoConImpuestos = (Prod.CostoNeto * (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100))) + (Prod.ImporteImpuestoInterno / Prod.Cantidad)
            Prod.ImporteTotalConImpuestos = (Prod.ImporteTotal * (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100))) + (Prod.ImporteImpuestoInterno / Prod.Cantidad)
            Prod.ImporteTotalNetoConImpuestos = (Prod.ImporteTotalNeto * (1 + (Prod.AlicuotaImpuesto / 100) + (Prod.PorcImpuestoInterno / 100))) + (Prod.ImporteImpuestoInterno / Prod.Cantidad)

         End If

         'Los calculo Antes.
         Prod.DescuentoRecargoProducto = Decimal.Round(Prod.DescuentoRecargoProducto / Prod.Cantidad, 2)
         Prod.DescRecGeneralProducto = Decimal.Round(Prod.DescRecGeneral / Prod.Cantidad, 2)
         Prod.CostoNeto = Decimal.Round(Prod.Costo + Prod.DescuentoRecargoProducto + Prod.DescRecGeneralProducto, 2)
         Prod.ImporteTotalNeto = Decimal.Round(Prod.ImporteTotal + Prod.DescRecGeneral, 2)
         'NO LO USA EN PEDIDOS: Prod.Utilidad = Decimal.Round((Prod.PrecioNeto - Prod.Costo) * Prod.Cantidad, 2)
         '--------------------------------------------------

         orden += 1
         Prod.Orden = orden
         Inserta(Prod)
      Next
   End Sub

   Public Sub Inserta(prod As Entidades.PedidoProductoProveedor)
      Me.EjecutaSP(prod, TipoSP._I)
   End Sub

   Public Sub EjecutaSP(prod As Entidades.PedidoProductoProveedor, tipo As TipoSP)

      Dim sql = New SqlServer.PedidosProductosProveedores(da)

      Select Case tipo
         Case TipoSP._I
            sql.PedidosProductosProveedores_I(prod.IdSucursal,
                                              prod.IdTipoComprobante,
                                              prod.Letra,
                                              prod.CentroEmisor,
                                              prod.NumeroPedido,
                                              prod.IdProducto,
                                              prod.Orden,
                                              prod.Proveedor.IdProveedor,
                                              prod.Cantidad,
                                              prod.CostoLista,
                                              prod.Costo,
                                              prod.CostoNeto,
                                              prod.DescuentoRecargoPorc,
                                              prod.DescuentoRecargoPorc2,
                                              prod.DescuentoRecargoProducto,
                                              prod.DescRecGeneral,
                                              prod.DescRecGeneralProducto,
                                              prod.TipoImpuesto.IdTipoImpuesto,
                                              prod.AlicuotaImpuesto,
                                              prod.ImporteImpuesto,
                                              prod.ImpuestoInterno,
                                              prod.ImporteImpuestoInterno,
                                              prod.PorcImpuestoInterno,
                                              prod.ImporteTotal,
                                              prod.ImporteTotalNeto,
                                              prod.NombreProducto,
                                              prod.Cantidad,
                                              0,
                                              0,
                                              0,
                                              prod.FechaActualizacion,
                                              prod.IdUnidadDeMedidaCompra,
                                              prod.CantidadUMCompra,
                                              prod.FactorConversionCompra,
                                              prod.PrecioPorUMCompra,
                                              prod.IdCriticidad,
                                              prod.FechaEntrega,
                                              prod.CostoConImpuestos,
                                              prod.CostoNetoConImpuestos,
                                              prod.ImporteTotalConImpuestos,
                                              prod.ImporteTotalNetoConImpuestos,
                                              prod.IdUnidadDeMedida)

            Dim rPE = New PedidosEstadosProveedores(da)
            rPE.Inserta(prod)

         Case TipoSP._U

         Case TipoSP._D
            Dim sqlPE = New SqlServer.PedidosEstadosProveedores(da)
            sqlPE.PedidosEstadosProveedores_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido, prod.Orden, prod.IdProducto, Nothing)
            Dim sqlPP = New SqlServer.PedidosProductosProveedores(da)
            sqlPP.PedidosProductosProveedores_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido, prod.Orden, prod.IdProducto)
      End Select

   End Sub

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          orden As Integer, idProducto As String) As Entidades.PedidoProductoProveedor
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          orden As Integer, idProducto As String, accion As AccionesSiNoExisteRegistro) As Entidades.PedidoProductoProveedor
      Return CargaEntidad(New SqlServer.PedidosProductosProveedores(da).PedidosProductosProveedores_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoProductoProveedor(),
                          accion, Function() String.Format("No existe detalle para {0}/{1} {2} {3:0000}-{4:00000000} {5} {6}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProducto, orden))
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As List(Of Entidades.PedidoProductoProveedor)
      Return CargaLista(New SqlServer.PedidosProductosProveedores(da).PedidosProductosProveedores_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoProductoProveedor())
   End Function

   Public Function GetPedidosProductosProveedores(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Return New SqlServer.PedidosProductosProveedores(da).PedidosProductosProveedores_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

   Public Sub ActualizaCantidadesSegunEstadoAnteriorNuevo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                          idProducto As String, orden As Integer,
                                                          idTipoEstadoAnterior As String, idTipoEstadoNuevo As String, cantidad As Decimal)
      Dim sqlPP As SqlServer.PedidosProductosProveedores = New SqlServer.PedidosProductosProveedores(da)
      Dim deltaCantidadPendiente As Decimal = 0
      Dim deltaCantidadEnProceso As Decimal = 0
      Dim deltaCantidadEntregada As Decimal = 0
      Dim deltaCantidadAnulada As Decimal = 0

      Select Case idTipoEstadoAnterior
         Case Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE
            deltaCantidadPendiente -= cantidad
         Case Entidades.EstadoPedidoProveedor.TipoEstado.ENPROCESO
            deltaCantidadEnProceso -= cantidad
         Case Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO
            deltaCantidadEntregada -= cantidad
         Case Entidades.EstadoPedidoProveedor.TipoEstado.ANULADO, Entidades.EstadoPedidoProveedor.TipoEstado.RECHAZADO
            deltaCantidadAnulada -= cantidad
         Case Else
      End Select

      Select Case idTipoEstadoNuevo
         Case Entidades.EstadoPedidoProveedor.TipoEstado.PENDIENTE
            deltaCantidadPendiente += cantidad
         Case Entidades.EstadoPedidoProveedor.TipoEstado.ENPROCESO
            deltaCantidadEnProceso += cantidad
         Case Entidades.EstadoPedidoProveedor.TipoEstado.ENTREGADO
            deltaCantidadEntregada += cantidad
         Case Entidades.EstadoPedidoProveedor.TipoEstado.ANULADO, Entidades.EstadoPedidoProveedor.TipoEstado.RECHAZADO
            deltaCantidadAnulada += cantidad
         Case Else
      End Select

      sqlPP.ActualizarCantidades(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProducto, orden,
                                 deltaCantidadPendiente, deltaCantidadEnProceso, deltaCantidadEntregada, deltaCantidadAnulada)
   End Sub

#End Region

   'No se si se va ha hacer algo con JSon. Lo dejo comentado por ahora pero hay que definir que onda.
   ''Public Function GetPedidosProductosProveedoresJSon(idSucursal As Integer,
   ''                                        idTipoComprobante As String,
   ''                                        letra As String,
   ''                                        centroEmisor As Integer,
   ''                                        numeroPedido As Long,
   ''                                        cuitEmpresa As String) As List(Of JSonEntidades.Pedidos.PedidoProductoProveedorJSon)
   ''   Dim lst As List(Of JSonEntidades.Pedidos.PedidoProductoProveedorJSon) = New List(Of JSonEntidades.Pedidos.PedidoProductoProveedorJSon)()

   ''   Dim dt As DataTable = New SqlServer.PedidosProductosProveedores(da).PedidosProductosProveedores_GA(idSucursal,
   ''                                                                                idTipoComprobante,
   ''                                                                                letra,
   ''                                                                                centroEmisor,
   ''                                                                                numeroPedido)
   ''   Dim o As JSonEntidades.Pedidos.PedidoProductoProveedorJSon
   ''   For Each dr As DataRow In dt.Rows
   ''      o = New JSonEntidades.Pedidos.PedidoProductoProveedorJSon()
   ''      CargarUno(o, dr, cuitEmpresa)
   ''      lst.Add(o)
   ''   Next

   ''   Return lst
   ''End Function
   ''Private Sub CargarUno(o As JSonEntidades.Pedidos.PedidoProductoProveedorJSon, dr As DataRow, cuitEmpresa As String)
   ''   With o
   ''      .CuitEmpresa = cuitEmpresa
   ''      .IdSucursal = Integer.Parse(dr(PedidoProductoProveedor.Columnas.IdSucursal.ToString()).ToString())
   ''      .IdTipoComprobante = dr(PedidoProductoProveedor.Columnas.IdTipoComprobante.ToString()).ToString()
   ''      .Letra = dr(PedidoProductoProveedor.Columnas.Letra.ToString()).ToString()
   ''      .CentroEmisor = Integer.Parse(dr(PedidoProductoProveedor.Columnas.CentroEmisor.ToString()).ToString())
   ''      .NumeroPedido = Long.Parse(dr(PedidoProductoProveedor.Columnas.NumeroPedido.ToString()).ToString())
   ''      .IdProducto = dr(PedidoProductoProveedor.Columnas.IdProducto.ToString()).ToString()
   ''      .Orden = Integer.Parse(dr(PedidoProductoProveedor.Columnas.Orden.ToString()).ToString())

   ''      .Cantidad = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.Cantidad.ToString()).ToString())
   ''      .Precio = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.Precio.ToString()).ToString())
   ''      .Costo = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.Costo.ToString()).ToString())
   ''      .ImporteTotal = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.ImporteTotal.ToString()).ToString())
   ''      .NombreProducto = dr(PedidoProductoProveedor.Columnas.NombreProducto.ToString()).ToString()
   ''      .CantEntregada = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.CantEntregada.ToString()).ToString())
   ''      .CantEnProceso = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.CantEnProceso.ToString()).ToString())
   ''      .DescuentoRecargoProducto = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.DescuentoRecargoProducto.ToString()).ToString())
   ''      If IsNumeric(dr(PedidoProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString()).ToString()) Then
   ''         .DescuentoRecargoPorc2 = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
   ''      End If
   ''      If IsNumeric(dr(PedidoProductoProveedor.Columnas.DescuentoRecargoPorc.ToString()).ToString()) Then
   ''         .DescuentoRecargoPorc = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.DescuentoRecargoPorc.ToString()).ToString())
   ''      End If
   ''      .IdTipoImpuesto = dr(PedidoProductoProveedor.Columnas.IdTipoImpuesto.ToString()).ToString()
   ''      .AlicuotaImpuesto = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.AlicuotaImpuesto.ToString()).ToString())
   ''      .ImporteImpuesto = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.ImporteImpuesto.ToString()).ToString())
   ''      .PrecioLista = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.PrecioLista.ToString()).ToString())
   ''      If IsDate(dr(PedidoProductoProveedor.Columnas.FechaActualizacion.ToString()).ToString()) Then
   ''         .FechaActualizacion = DateTime.Parse(dr(PedidoProductoProveedor.Columnas.FechaActualizacion.ToString()).ToString()).ToString("yyyy-MM-dd HH:mm:ss")
   ''      End If
   ''      .IdListaPrecios = Integer.Parse(dr(PedidoProductoProveedor.Columnas.IdListaPrecios.ToString()).ToString())
   ''      .NombreListaPrecios = dr(PedidoProductoProveedor.Columnas.NombreListaPrecios.ToString()).ToString()
   ''      .ImporteImpuestoInterno = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.ImporteImpuestoInterno.ToString()).ToString())
   ''      .PorcImpuestoInterno = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.PorcImpuestoInterno.ToString()).ToString())
   ''      .PrecioNeto = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.PrecioNeto.ToString()).ToString())
   ''      .ImporteTotalNeto = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.ImporteTotalNeto.ToString()).ToString())
   ''      .DescRecGeneral = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.DescRecGeneral.ToString()).ToString())
   ''      .DescRecGeneralProducto = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.DescRecGeneralProducto.ToString()).ToString())
   ''      .Kilos = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.Kilos.ToString()).ToString())
   ''      .IdCriticidad = dr(PedidoEstado.Columnas.IdCriticidad.ToString()).ToString()
   ''      If IsDate(dr(PedidoEstado.Columnas.FechaEntrega.ToString()).ToString()) Then
   ''         .FechaEntrega = DateTime.Parse(dr(PedidoEstado.Columnas.FechaEntrega.ToString()).ToString()).ToString("yyyy-MM-dd HH:mm:ss")
   ''      End If
   ''      .CantAnulada = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.CantAnulada.ToString()).ToString())
   ''      .CantPendiente = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.CantPendiente.ToString()).ToString())
   ''      .PrecioConImpuestos = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.PrecioConImpuestos.ToString()).ToString())
   ''      .PrecioNetoConImpuestos = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.PrecioNetoConImpuestos.ToString()).ToString())
   ''      .ImporteTotalConImpuestos = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.ImporteTotalConImpuestos.ToString()).ToString())
   ''      .ImporteTotalNetoConImpuestos = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.ImporteTotalNetoConImpuestos.ToString()).ToString())

   ''      If IsNumeric(dr(PedidoProductoProveedor.Columnas.Tamano.ToString()).ToString()) Then
   ''         .Tamano = Decimal.Parse(dr(PedidoProductoProveedor.Columnas.Tamano.ToString()).ToString())
   ''      End If
   ''      .IdUnidadDeMedida = dr(PedidoProductoProveedor.Columnas.IdUnidadDeMedida.ToString()).ToString()
   ''      If IsNumeric(dr(PedidoProductoProveedor.Columnas.IdMoneda.ToString()).ToString()) Then
   ''         .IdMoneda = Integer.Parse(dr(PedidoProductoProveedor.Columnas.IdMoneda.ToString()).ToString())
   ''      End If

   ''      'Del Turco
   ''      .IdPlazoEntrega = 0

   ''   End With
   ''End Sub
End Class