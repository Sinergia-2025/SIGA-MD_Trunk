Public Class PedidosProductos
   Inherits Base

   Private _cache As BusquedasCacheadas

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "PedidosProductos"
      da = accesoDatos
      _cache = New BusquedasCacheadas()
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.PedidoProducto), pedidoReferencia:=Nothing))
   End Sub
#End Region

#Region "Metodos Privados"

   Private Sub CargarUno(o As Entidades.PedidoProducto, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.Pedido.Columnas.IdSucursal.ToString())
         .TipoComprobante = New TiposComprobantes(da).GetUno(dr.Field(Of String)(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()))
         .Letra = dr.Field(Of String)(Entidades.Pedido.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToShort()
         .NumeroPedido = dr.Field(Of Integer)(Entidades.Pedido.Columnas.NumeroPedido.ToString())
         .Orden = dr.Field(Of Integer)("Orden")
         .Producto = New Productos(da).GetUno(dr.Field(Of String)("IdProducto"))
         .Producto.NombreProducto = dr.Field(Of String)("NombreProducto")

         '-- REG-31142.- --
         .CodigoProductoProveedor = dr.Field(Of String)("CodigoProductoProveedor").IfNull()
         '-----------------

         .Cantidad = dr.Field(Of Decimal)("Cantidad")
         .CantidadOriginal = dr.Field(Of Decimal)("Cantidad")
         .Precio = dr.Field(Of Decimal)("Precio")
         .PrecioLista = dr.Field(Of Decimal)("PrecioLista")
         .Costo = dr.Field(Of Decimal)("Costo")
         .ImporteTotal = dr.Field(Of Decimal)("ImporteTotal")

         .CantPendiente = dr.Field(Of Decimal)("CantPendiente")
         .CantEntregada = dr.Field(Of Decimal)("CantEntregada")
         .CantEnProceso = dr.Field(Of Decimal)("CantEnProceso")
         .CantAnulada = dr.Field(Of Decimal)("CantAnulada")
         .CantNoPendienteOriginal = .CantidadOriginal - .CantPendiente

         .DescuentoRecargoProducto = dr.Field(Of Decimal)("DescuentoRecargoProducto")
         .DescuentoRecargoPorc = dr.Field(Of Decimal?)("DescuentoRecargoPorc").IfNull()
         .DescuentoRecargoPorc2 = dr.Field(Of Decimal?)("DescuentoRecargoPorc2").IfNull()

         .TipoImpuesto = New TiposImpuestos(da).GetUno(dr.Field(Of String)("IdTipoImpuesto").StringToEnum(Entidades.TipoImpuesto.Tipos.IVA))
         .AlicuotaImpuesto = dr.Field(Of Decimal)("AlicuotaImpuesto")
         .ImporteImpuesto = dr.Field(Of Decimal)("ImporteImpuesto")
         .ImporteImpuestoInterno = dr.Field(Of Decimal)("ImporteImpuestoInterno")
         .PorcImpuestoInterno = dr.Field(Of Decimal)("PorcImpuestoInterno")
         .OrigenPorcImpInt = dr.Field(Of String)("OrigenPorcImpInt").ToString().StringToEnum(Entidades.OrigenesPorcImpInt.NETO)

         .FechaActualizacion = dr.Field(Of Date?)("FechaActualizacion").IfNull()

         .IdListaPrecios = dr.Field(Of Integer)("IdListaPrecios")
         .NombreListaPrecios = dr.Field(Of String)("NombreListaPrecios")
         .NombreCortoListaPrecios = dr.Field(Of String)("NombreCortoListaPrecios")

         .PrecioNeto = dr.Field(Of Decimal)("PrecioNeto")
         .ImporteTotalNeto = dr.Field(Of Decimal)("ImporteTotalNeto")
         .DescRecGeneral = dr.Field(Of Decimal)("DescRecGeneral")
         .DescRecGeneralProducto = dr.Field(Of Decimal)("DescRecGeneralProducto")
         .Kilos = dr.Field(Of Decimal)("Kilos")

         'VERIFICO QUE ESTÉ LA COLUMNA POR SI FALTÓ AGREGARLA EN ALGÚN QUERY/DATATABLE
         If dr.Table.Columns.Contains(Entidades.VentaProducto.Columnas.CantPendiente.ToString()) Then
            .CantPendiente = dr.Field(Of Decimal?)(Entidades.VentaProducto.Columnas.CantPendiente.ToString()).IfNull()
         End If

         .IdCriticidad = dr.Field(Of String)("IdCriticidad").IfNull()
         .FechaEntrega = dr.Field(Of Date?)("FechaEntrega").IfNull()

         .PrecioConImpuestos = dr.Field(Of Decimal)(Entidades.PedidoProducto.Columnas.PrecioConImpuestos.ToString())
         .PrecioNetoConImpuestos = dr.Field(Of Decimal)(Entidades.PedidoProducto.Columnas.PrecioNetoConImpuestos.ToString())
         .ImporteTotalConImpuestos = dr.Field(Of Decimal)(Entidades.PedidoProducto.Columnas.ImporteTotalConImpuestos.ToString())
         .ImporteTotalNetoConImpuestos = dr.Field(Of Decimal)(Entidades.PedidoProducto.Columnas.ImporteTotalNetoConImpuestos.ToString())

         .PrecioVentaPorTamano = dr.Field(Of Decimal?)(Entidades.PedidoProducto.Columnas.PrecioVentaPorTamano.ToString()).IfNull()
         .Tamano = dr.Field(Of Decimal?)(Entidades.PedidoProducto.Columnas.Tamano.ToString()).IfNull()
         .IdUnidadDeMedida = dr.Field(Of String)(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).IfNull()
         .Moneda = New Monedas(da).GetUna(dr.Field(Of Integer?)(Entidades.PedidoProducto.Columnas.IdMoneda.ToString()).IfNull(Entidades.Moneda.Peso))

         .Espmm = dr.Field(Of Decimal?)(Entidades.PedidoProducto.Columnas.Espmm.ToString()).IfNull()
         .EspPulgadas = dr.Field(Of String)(Entidades.PedidoProducto.Columnas.EspPulgadas.ToString()).IfNull()
         .CodigoSAE = dr.Field(Of String)(Entidades.PedidoProducto.Columnas.CodigoSAE.ToString()).IfNull()

         .ProduccionProceso = New ProduccionProcesos(da).GetUno(dr.Field(Of Integer?)(Entidades.PedidoProducto.Columnas.IdProduccionProceso.ToString()).IfNull(-1), AccionesSiNoExisteRegistro.Nulo)
         .ProduccionForma = New ProduccionFormas(da).GetUno(dr.Field(Of Integer?)(Entidades.PedidoProducto.Columnas.IdProduccionForma.ToString()).IfNull(-1), AccionesSiNoExisteRegistro.Nulo)

         .LargoExtAlto = dr.Field(Of Decimal?)(Entidades.PedidoProducto.Columnas.LargoExtAlto.ToString()).IfNull()
         .AnchoIntBase = dr.Field(Of Decimal?)(Entidades.PedidoProducto.Columnas.AnchoIntBase.ToString()).IfNull()

         .Architrave = dr.Field(Of Decimal?)(Entidades.PedidoProducto.Columnas.Architrave.ToString()).IfNull()
         Dim idProduccionModeloForma = dr.Field(Of Integer?)(Entidades.PedidoProducto.Columnas.IdProduccionModeloForma.ToString())
         If idProduccionModeloForma.HasValue Then
            .ProduccionModeloForma = New Reglas.ProduccionModelosFormas(da).GetUno(idProduccionModeloForma.Value)
         End If

         .UrlPlano = dr.Field(Of String)(Entidades.PedidoProducto.Columnas.UrlPlano.ToString()).IfNull()

         .IdFormula = dr.Field(Of Integer?)(Entidades.PedidoProducto.Columnas.IdFormula.ToString()).IfNull()

         .IdProcesoProductivo = dr.Field(Of Long?)(Entidades.PedidoProducto.Columnas.IdProcesoProductivo.ToString()).IfNull()
         .CodigoProcesoProductivo = dr.Field(Of String)("CodigoProcesoProductivo").IfNull()
         .DescripcionProcesoProductivo = dr.Field(Of String)("DescripcionProcesoProductivo").IfNull()

         .TipoOperacion = dr.Field(Of String)(Entidades.PedidoProducto.Columnas.TipoOperacion.ToString()).StringToEnum(Entidades.Producto.TiposOperaciones.NORMAL)
         .Nota = dr.Field(Of String)(Entidades.PedidoProducto.Columnas.Nota.ToString()).IfNull()


         .PedidosEstados = New PedidosEstados(da).GetTodos(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroPedido)
         .PedidosProductosFormulas = New PedidosProductosFormulas(da).GetTodos(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroPedido, .IdProducto, .Orden)

         .Stock = dr.Field(Of Decimal)("Stock")

         .Automatico = dr.Field(Of Boolean)(Entidades.PedidoProducto.Columnas.Automatico.ToString())
         .ModificoPrecioManualmente = dr.Field(Of Boolean)(Entidades.PedidoProducto.Columnas.ModificoPrecioManualmente.ToString())
         .CantidadManual = dr.Field(Of Decimal)(Entidades.PedidoProducto.Columnas.CantidadManual.ToString())
         .Conversion = dr.Field(Of Decimal)(Entidades.PedidoProducto.Columnas.Conversion.ToString())
         .ModificoDescuentos = dr.Field(Of Boolean)(Entidades.PedidoProducto.Columnas.ModificoDescuentos.ToString())
         .EsObservacion = dr.Field(Of Boolean)(Entidades.PedidoProducto.Columnas.EsObservacion.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Sub InsertaDetalleDesdePedido(oPedidos As Entidades.Pedido)
      Dim CategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      Dim orden As Integer = 0
      For Each Prod As Entidades.PedidoProducto In oPedidos.PedidosProductos.OrderBy(Function(x) x.Orden)
         'grabo los productos del comprobante de venta
         Prod.TipoComprobante = oPedidos.TipoComprobante
         Prod.Letra = oPedidos.LetraComprobante
         Prod.CentroEmisor = oPedidos.CentroEmisor
         Prod.NumeroPedido = oPedidos.NumeroPedido

         If Not CategoriaFiscalEmpresa.IvaDiscriminado Or Not oPedidos.CategoriaFiscal.IvaDiscriminado Then
            Prod.PrecioConImpuestos = Prod.Precio
            Prod.PrecioNetoConImpuestos = Prod.PrecioNeto
            Prod.ImporteTotalConImpuestos = Prod.ImporteTotal
            Prod.ImporteTotalNetoConImpuestos = Prod.ImporteTotalNeto

            '  Prod.PrecioLista = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.PrecioLista, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, If(Prod.PorcImpuestoInterno = 0, Prod.ImporteImpuestoInterno / Prod.Cantidad, 0), Prod.OrigenPorcImpInt)
            Prod.Precio = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.Precio, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, If(Prod.PorcImpuestoInterno = 0, Prod.ImporteImpuestoInterno / Prod.Cantidad, 0), Prod.OrigenPorcImpInt)
            Prod.DescuentoRecargoProducto = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.DescuentoRecargoProducto, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, If(Prod.PorcImpuestoInterno = 0, Prod.ImporteImpuestoInterno / Prod.Cantidad, 0), Prod.OrigenPorcImpInt)
            Prod.DescRecGeneral = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.DescRecGeneral, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, If(Prod.PorcImpuestoInterno = 0, Prod.ImporteImpuestoInterno / Prod.Cantidad, 0), Prod.OrigenPorcImpInt)
            Prod.ImporteTotal = CalculosImpositivos.ObtenerPrecioSinImpuestos(Prod.ImporteTotal, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, If(Prod.PorcImpuestoInterno = 0, Prod.ImporteImpuestoInterno / Prod.Cantidad, 0), Prod.OrigenPorcImpInt)

         Else
            Prod.PrecioConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.Precio, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, Prod.ImporteImpuestoInterno / Prod.Cantidad, Prod.OrigenPorcImpInt)
            Prod.PrecioNetoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.PrecioNeto, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, Prod.ImporteImpuestoInterno / Prod.Cantidad, Prod.OrigenPorcImpInt)
            Prod.ImporteTotalConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.ImporteTotal, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, Prod.ImporteImpuestoInterno / Prod.Cantidad, Prod.OrigenPorcImpInt)
            Prod.ImporteTotalNetoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(Prod.ImporteTotalNeto, Prod.AlicuotaImpuesto, Prod.PorcImpuestoInterno, Prod.ImporteImpuestoInterno / Prod.Cantidad, Prod.OrigenPorcImpInt)

         End If

         'Los calculo Antes.
         Prod.DescuentoRecargoProducto = Decimal.Round(Prod.DescuentoRecargoProducto / Prod.Cantidad, 2)
         Prod.DescRecGeneralProducto = Decimal.Round(Prod.DescRecGeneral / Prod.Cantidad, 2)
         Prod.PrecioNeto = Decimal.Round(Prod.Precio + Prod.DescuentoRecargoProducto + Prod.DescRecGeneralProducto, 2)
         Prod.ImporteTotalNeto = Decimal.Round(Prod.ImporteTotal + Prod.DescRecGeneral, 2)
         'NO LO USA EN PEDIDOS: Prod.Utilidad = Decimal.Round((Prod.PrecioNeto - Prod.Costo) * Prod.Cantidad, 2)
         '--------------------------------------------------

         orden += 1
         Prod.Orden = orden
         Inserta(Prod, oPedidos)
      Next
   End Sub
   Public Sub ActualizaDetalleDesdePedido(pedido As Entidades.Pedido, idFuncion As String)
      Dim CategoriaFiscalEmpresa = _cache.BuscaCategoriaFiscal(Publicos.CategoriaFiscalEmpresa)

      Dim orden As Integer = 0

      If Publicos.PedidosConservaOrdenProductos Then
         orden = pedido.PedidosProductos.MaxSecure(Function(pp) pp.Orden).IfNull()
      End If

      Dim lstPP = New SqlServer.PedidosProductos(da).PedidosProductos_GA(pedido.IdSucursal, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido).AsEnumerable().ToList()

      For Each vProd In pedido.PedidosProductos.OrderBy(Function(x) x.Orden)
         'grabo los productos del comprobante de venta
         vProd.TipoComprobante = pedido.TipoComprobante
         vProd.Letra = pedido.LetraComprobante
         vProd.CentroEmisor = pedido.CentroEmisor
         vProd.NumeroPedido = pedido.NumeroPedido

         If Not CategoriaFiscalEmpresa.IvaDiscriminado Or Not pedido.CategoriaFiscal.IvaDiscriminado Then
            vProd.PrecioConImpuestos = vProd.Precio
            vProd.PrecioNetoConImpuestos = vProd.PrecioNeto
            vProd.ImporteTotalConImpuestos = vProd.ImporteTotal
            vProd.ImporteTotalNetoConImpuestos = vProd.ImporteTotalNeto

            vProd.PrecioLista = CalculosImpositivos.ObtenerPrecioSinImpuestos(vProd.PrecioLista, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, If(vProd.PorcImpuestoInterno = 0, vProd.ImporteImpuestoInterno / vProd.Cantidad, 0), vProd.OrigenPorcImpInt)
            vProd.Precio = CalculosImpositivos.ObtenerPrecioSinImpuestos(vProd.Precio, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, If(vProd.PorcImpuestoInterno = 0, vProd.ImporteImpuestoInterno / vProd.Cantidad, 0), vProd.OrigenPorcImpInt)
            vProd.DescuentoRecargoProducto = CalculosImpositivos.ObtenerPrecioSinImpuestos(vProd.DescuentoRecargoProducto, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, If(vProd.PorcImpuestoInterno = 0, vProd.ImporteImpuestoInterno / vProd.Cantidad, 0), vProd.OrigenPorcImpInt)
            vProd.DescRecGeneral = CalculosImpositivos.ObtenerPrecioSinImpuestos(vProd.DescRecGeneral, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, If(vProd.PorcImpuestoInterno = 0, vProd.ImporteImpuestoInterno / vProd.Cantidad, 0), vProd.OrigenPorcImpInt)
            vProd.ImporteTotal = CalculosImpositivos.ObtenerPrecioSinImpuestos(vProd.ImporteTotal, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, If(vProd.PorcImpuestoInterno = 0, vProd.ImporteImpuestoInterno / vProd.Cantidad, 0), vProd.OrigenPorcImpInt)

         Else
            vProd.PrecioConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(vProd.Precio, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, vProd.ImporteImpuestoInterno / vProd.Cantidad, vProd.OrigenPorcImpInt)
            vProd.PrecioNetoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(vProd.PrecioNeto, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, vProd.ImporteImpuestoInterno / vProd.Cantidad, vProd.OrigenPorcImpInt)
            vProd.ImporteTotalConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(vProd.ImporteTotal, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, vProd.ImporteImpuestoInterno / vProd.Cantidad, vProd.OrigenPorcImpInt)
            vProd.ImporteTotalNetoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(vProd.ImporteTotalNeto, vProd.AlicuotaImpuesto, vProd.PorcImpuestoInterno, vProd.ImporteImpuestoInterno / vProd.Cantidad, vProd.OrigenPorcImpInt)

         End If

         'Los calculo Antes.
         vProd.DescuentoRecargoProducto = Decimal.Round(vProd.DescuentoRecargoProducto / vProd.Cantidad, 2)
         vProd.DescRecGeneralProducto = Decimal.Round(vProd.DescRecGeneral / vProd.Cantidad, 2)
         vProd.PrecioNeto = Decimal.Round(vProd.Precio + vProd.DescuentoRecargoProducto + vProd.DescRecGeneralProducto, 2)
         vProd.ImporteTotalNeto = Decimal.Round(vProd.ImporteTotal + vProd.DescRecGeneral, 2)
         'NO LO USA EN PEDIDOS: Prod.Utilidad = Decimal.Round((Prod.PrecioNeto - Prod.Costo) * Prod.Cantidad, 2)
         '--------------------------------------------------

         If Not Publicos.PedidosConservaOrdenProductos OrElse vProd.Orden = 0 Then
            orden += 1
            vProd.Orden = orden
         End If

         Dim where = Function(dr As DataRow) dr.Field(Of String)("IdProducto") = vProd.IdProducto And dr.Field(Of Integer)("Orden") = vProd.Orden

         If lstPP.Any(where) Then
            Actualiza(vProd, pedido, idFuncion)
            lstPP.RemoveAll(where)
         Else
            Inserta(vProd, pedido)
         End If
      Next

      lstPP.ForEach(
         Sub(dr)
            Dim pedProd = New Entidades.PedidoProducto() With
                     {
                        .IdSucursal = dr.Field(Of Integer)("IdSucursal"),
                        .TipoComprobante = New Entidades.TipoComprobante() With {.IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante")},
                        .Letra = dr.Field(Of String)("Letra"),
                        .CentroEmisor = dr.Field(Of Integer)("CentroEmisor"),
                        .NumeroPedido = dr.Field(Of Integer)("NumeroPedido"),
                        .Producto = New Entidades.Producto() With {.IdProducto = dr.Field(Of String)("IdProducto")},
                        .Orden = dr.Field(Of Integer)("Orden")
                     }
            PuedeBorrarPedidoProducto(pedProd)
            Borra(pedProd, pedido)
         End Sub)

   End Sub

   Public Sub PuedeBorrarPedidoProducto(pedProd As Entidades.PedidoProducto)
      Dim peCol = New PedidosEstados(da).GetTodos(pedProd.IdSucursal, pedProd.IdTipoComprobante, pedProd.Letra, pedProd.CentroEmisor, pedProd.NumeroPedido,
                                                        pedProd.Orden, pedProd.IdProducto)
      If peCol.Any(Function(pe) pe.IdEstado <> Entidades.EstadoPedido.ESTADO_ALTA And pe.IdEstado <> Entidades.EstadoPedido.ESTADO_ANULADO) Then
         Throw New Exception(String.Format("La línea {0} del pedido con el producto {1} no se puede borrar porque tiene cantidades En Proceso o Entregadas",
                                           pedProd.Orden, pedProd.IdProducto))
      End If
   End Sub

   Public Sub Inserta(prod As Entidades.PedidoProducto, pedidoReferencia As Entidades.Pedido)
      EjecutaSP(prod, TipoSP._I, pedidoReferencia, idFuncion:=String.Empty)
   End Sub
   Public Sub Actualiza(prod As Entidades.PedidoProducto, pedidoReferencia As Entidades.Pedido, idFuncion As String)
      EjecutaSP(prod, TipoSP._U, pedidoReferencia, idFuncion)
   End Sub
   Public Sub Borra(prod As Entidades.PedidoProducto, pedidoReferencia As Entidades.Pedido)
      EjecutaSP(prod, TipoSP._D, pedidoReferencia, idFuncion:=String.Empty)
   End Sub

   Public Sub EjecutaSP(prod As Entidades.PedidoProducto, tipo As TipoSP, pedidoReferencia As Entidades.Pedido, idFuncion As String)

      Dim sql = New SqlServer.PedidosProductos(da)

      Select Case tipo
         Case TipoSP._I

            If String.IsNullOrWhiteSpace(prod.NombreCortoListaPrecios) Then
               prod.NombreCortoListaPrecios = _cache.BuscaListaDePrecios(prod.IdListaPrecios).NombreCortoListaPrecios
            End If

            If prod.CantidadManual = 0 Then
               prod.CantidadManual = prod.Cantidad
               prod.Conversion = prod.Conversion
            End If
            If String.IsNullOrWhiteSpace(prod.IdUnidadDeMedida) Then
               prod.IdUnidadDeMedida = prod.Producto.UnidadDeMedida.IdUnidadDeMedida
            End If

            sql.PedidosProductos_I(prod.IdSucursal,
                                   prod.IdTipoComprobante,
                                   prod.Letra,
                                   prod.CentroEmisor,
                                   prod.NumeroPedido,
                                   prod.IdProducto,
                                   prod.Cantidad,
                                   prod.Precio,
                                   prod.PrecioLista,
                                   prod.Costo,
                                   prod.ImporteTotal,
                                   prod.NombreProducto,
                                   prod.Cantidad,
                                   0,
                                   0,
                                   0,
                                   prod.DescuentoRecargoProducto,
                                   prod.DescuentoRecargoPorc,
                                   prod.DescuentoRecargoPorc2,
                                   prod.TipoImpuesto.IdTipoImpuesto,
                                   prod.AlicuotaImpuesto,
                                   prod.ImporteImpuesto,
                                   prod.Orden,
                                   prod.FechaActualizacion,
                                   prod.IdListaPrecios,
                                   prod.NombreListaPrecios,
                                   prod.ImporteImpuestoInterno,
                                   prod.PrecioNeto,
                                   prod.ImporteTotalNeto,
                                   prod.DescRecGeneral,
                                   prod.DescRecGeneralProducto,
                                   prod.Kilos,
                                   prod.IdCriticidad,
                                   prod.FechaEntrega,
                                   prod.PrecioConImpuestos,
                                   prod.PrecioNetoConImpuestos,
                                   prod.ImporteTotalConImpuestos,
                                   prod.ImporteTotalNetoConImpuestos,
                                   prod.PrecioVentaPorTamano,
                                   prod.Tamano,
                                   prod.IdUnidadDeMedida,
                                   prod.IdMoneda,
                                   prod.Espmm,
                                   prod.EspPulgadas,
                                   prod.CodigoSAE,
                                   prod.IdProduccionProceso,
                                   prod.IdProduccionForma,
                                   prod.LargoExtAlto,
                                   prod.AnchoIntBase,
                                   prod.Architrave,
                                   prod.IdProduccionModeloForma,
                                   prod.UrlPlano,
                                   prod.IdFormula,
                                   prod.IdProcesoProductivo,
                                   prod.PorcImpuestoInterno,
                                   prod.OrigenPorcImpInt,
                                   prod.TipoOperacion.ToString(),
                                   prod.Nota,
                                   prod.NombreCortoListaPrecios,
                                   prod.Automatico,
                                   prod.ModificoPrecioManualmente,
                                   prod.CantidadManual,
                                   prod.Conversion,
                                   prod.ModificoDescuentos)

            Dim rPE = New PedidosEstados(da)
            rPE.Inserta(prod)

            rPE.ReservaProducto(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido,
                                prod.IdProducto, prod.Orden, String.Empty, Entidades.EstadoPedido.ESTADO_ALTA, prod.TipoComprobante.Tipo,
                                prod.Cantidad,
                                Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion, 0, 0, 0, 0)

            Dim rPPF As PedidosProductosFormulas = New PedidosProductosFormulas(da)
            rPPF.InsertaDesdePedidoProducto(prod)

         Case TipoSP._U

            sql.PedidosProductos_U(prod.IdSucursal,
                                   prod.IdTipoComprobante,
                                   prod.Letra,
                                   prod.CentroEmisor,
                                   prod.NumeroPedido,
                                   prod.IdProducto,
                                   prod.Cantidad,
                                   prod.Precio,
                                   prod.PrecioLista,
                                   prod.Costo,
                                   prod.ImporteTotal,
                                   prod.NombreProducto,
                                   0,                                ' cantPendiente - Se le pasa 0 porque luego se ejecuta NormalizaCantidadesSegunEstado para normalizar los datos
                                   0,                                ' cantEntregada - Se le pasa 0 porque luego se ejecuta NormalizaCantidadesSegunEstado para normalizar los datos
                                   0,                                ' cantEnProceso - Se le pasa 0 porque luego se ejecuta NormalizaCantidadesSegunEstado para normalizar los datos
                                   0,                                ' cantAnulada   - Se le pasa 0 porque luego se ejecuta NormalizaCantidadesSegunEstado para normalizar los datos
                                   prod.DescuentoRecargoProducto,
                                   prod.DescuentoRecargoPorc,
                                   prod.DescuentoRecargoPorc2,
                                   prod.TipoImpuesto.IdTipoImpuesto,
                                   prod.AlicuotaImpuesto,
                                   prod.ImporteImpuesto,
                                   prod.Orden,
                                   prod.FechaActualizacion,
                                   prod.IdListaPrecios,
                                   prod.NombreListaPrecios,
                                   prod.ImporteImpuestoInterno,
                                   prod.PrecioNeto,
                                   prod.ImporteTotalNeto,
                                   prod.DescRecGeneral,
                                   prod.DescRecGeneralProducto,
                                   prod.Kilos,
                                   prod.IdCriticidad,
                                   prod.FechaEntrega,
                                   prod.PrecioConImpuestos,
                                   prod.PrecioNetoConImpuestos,
                                   prod.ImporteTotalConImpuestos,
                                   prod.ImporteTotalNetoConImpuestos,
                                   prod.PrecioVentaPorTamano,
                                   prod.Tamano,
                                   prod.IdUnidadDeMedida,
                                   prod.IdMoneda,
                                   prod.Espmm,
                                   prod.EspPulgadas,
                                   prod.CodigoSAE,
                                   prod.IdProduccionProceso,
                                   prod.IdProduccionForma,
                                   prod.LargoExtAlto,
                                   prod.AnchoIntBase,
                                   prod.Architrave,
                                   prod.IdProduccionModeloForma,
                                   prod.UrlPlano,
                                   prod.IdFormula,
                                   prod.IdProcesoProductivo,
                                   prod.PorcImpuestoInterno,
                                   prod.OrigenPorcImpInt,
                                   prod.TipoOperacion.ToString(),
                                   prod.Nota,
                                   prod.NombreCortoListaPrecios,
                                   prod.Automatico,
                                   prod.ModificoPrecioManualmente,
                                   prod.CantidadManual,
                                   prod.Conversion,
                                   prod.ModificoDescuentos)

            If prod.Cantidad > prod.CantidadOriginal Then
               Dim rPE = New PedidosEstados(da)
               rPE.Inserta(prod, prod.Cantidad - prod.CantidadOriginal, "Modificación Pedido")
            ElseIf prod.Cantidad < prod.CantidadOriginal Then
               Dim tipoTipoComprobante = prod.TipoComprobante.Tipo
               Dim rPE = New PedidosEstados(da)
               rPE.ConsumirPedido(Date.Now, numeroReparto:=0, tipoTipoComprobante,
                                  Entidades.EstadoPedido.ESTADO_ALTA, Entidades.EstadoPedido.ESTADO_ANULADO, "Modificación Pedido",
                                  prod.IdProducto, prod.CantidadOriginal - prod.Cantidad, idCliente:=pedidoReferencia.IdCliente, {prod}, prod.IdSucursal,
                                  alInvocarPedidoAfectaFactura:=False, alInvocarPedidoAfectaRemito:=False, invocarPedidosConEstadoEspecifico:=True,
                                  idSucursalInvocador:=0, idTipoComprobanteInvocador:=String.Empty, letraInvocador:=String.Empty, centroEmisorInvocador:=0, numeroComprobanteInvocador:=0,
                                  anulacionPorModificacion:=True,
                                  idFuncion, cont:=0, _cache)
            End If

            'Esta rutina normaliza los valores de cantPendiente, cantEntregada, cantEnProceso y cantAnulada acumulando los Pedidos Estados de cada Pedidos Productos
            NormalizaCantidadesSegunEstado(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido, prod.IdProducto, prod.Orden)

         Case TipoSP._D
            Dim sqlPE As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)
            sqlPE.PedidosEstados_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido, prod.Orden, prod.IdProducto, fechaEstado:=Nothing)
            Dim sqlPPF As SqlServer.PedidosProductosFormulas = New SqlServer.PedidosProductosFormulas(da)
            sqlPPF.PedidosProductosFormulas_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido, prod.IdProducto, prod.Orden,
                                              idProductoElaborado:=Nothing, idUnicoNodoProductoElaborado:=Nothing, idProductoComponente:=Nothing, idUnicoNodoProductoComponente:=Nothing,
                                              idFormula:=0, secuenciaFormula:=0)
            Dim sqlPP As SqlServer.PedidosProductos = New SqlServer.PedidosProductos(da)
            sqlPP.PedidosProductos_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido, prod.Orden, prod.IdProducto)
      End Select

   End Sub

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          orden As Integer, idProducto As String) As Entidades.PedidoProducto
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetTodos(IdSucursal As Integer,
                            IdTipoComprobante As String, Letra As String,
                            CentroEmisor As Integer, NumeroPedido As Long) As List(Of Entidades.PedidoProducto)
      Return GetTodos(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido, estadoPedidos:=Nothing)
   End Function


   Public Function GetTodos(IdSucursal As Integer,
                            IdTipoComprobante As String, Letra As String,
                            CentroEmisor As Integer, NumeroPedido As Long, estadoPedidos As String) As List(Of Entidades.PedidoProducto)
      Dim dt As DataTable = New SqlServer.PedidosProductos(Me.da).PedidosProductos_GA(IdSucursal,
                                                                                      IdTipoComprobante, Letra,
                                                                                      CentroEmisor, NumeroPedido)
      Dim o As Entidades.PedidoProducto
      Dim oLis As List(Of Entidades.PedidoProducto) = New List(Of Entidades.PedidoProducto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.PedidoProducto()
         Me.CargarUno(o, dr)
         If Not String.IsNullOrWhiteSpace(estadoPedidos) Then
            o.CantPendiente = New SqlServer.PedidosEstados(da).GetCantidadPedidosEstado(IdSucursal,
                                                                                        IdTipoComprobante,
                                                                                        Letra,
                                                                                        CentroEmisor,
                                                                                        NumeroPedido,
                                                                                        estadoPedidos,
                                                                                        dr("IdProducto").ToString(),
                                                                                        Integer.Parse(dr("Orden").ToString()))
         End If
         oLis.Add(o)
      Next
      Return oLis
   End Function

   'Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As List(Of Entidades.PedidoProducto)
   '   Return CargaLista(New SqlServer.PedidosProductos(da).PedidosProductos_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido),
   '                     Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoProducto())
   'End Function

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          orden As Integer, idProducto As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.PedidoProducto
      Return CargaEntidad(New SqlServer.PedidosProductos(da).PedidosProductos_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoProducto(),
                          accion, Function() String.Format("No se encuentra Pedido Producto para {0}/{1} {2} {3:0000}-{4:00000000} / {5} / {6}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                           orden, idProducto))
   End Function

   Public Function GetPedidosProductos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      'Dim sql As SqlServer.Pedidos = New SqlServer.Pedidos(da)
      Return New SqlServer.PedidosProductos(da).PedidosProductos_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

   Public Sub ActualizaCantidadesSegunEstadoAnteriorNuevo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                          idProducto As String, orden As Integer,
                                                          idTipoEstadoAnterior As String, idTipoEstadoNuevo As String, cantidad As Decimal)
      Dim sqlPP = New SqlServer.PedidosProductos(da)
      Dim deltaCantidadPendiente = 0D
      Dim deltaCantidadEnProceso = 0D
      Dim deltaCantidadEntregada = 0D
      Dim deltaCantidadAnulada = 0D

      Select Case idTipoEstadoAnterior
         Case Entidades.EstadoPedido.TipoEstado.PENDIENTE
            deltaCantidadPendiente -= cantidad
         Case Entidades.EstadoPedido.TipoEstado.ENPROCESO
            deltaCantidadEnProceso -= cantidad
         Case Entidades.EstadoPedido.TipoEstado.ENTREGADO
            deltaCantidadEntregada -= cantidad
         Case Entidades.EstadoPedido.TipoEstado.ANULADO, Entidades.EstadoPedido.TipoEstado.RECHAZADO
            deltaCantidadAnulada -= cantidad
         Case Else
      End Select

      Select Case idTipoEstadoNuevo
         Case Entidades.EstadoPedido.TipoEstado.PENDIENTE
            deltaCantidadPendiente += cantidad
         Case Entidades.EstadoPedido.TipoEstado.ENPROCESO
            deltaCantidadEnProceso += cantidad
         Case Entidades.EstadoPedido.TipoEstado.ENTREGADO
            deltaCantidadEntregada += cantidad
         Case Entidades.EstadoPedido.TipoEstado.ANULADO, Entidades.EstadoPedido.TipoEstado.RECHAZADO
            deltaCantidadAnulada += cantidad
         Case Else
      End Select

      sqlPP.ActualizarCantidades(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                 idProducto, orden,
                                 deltaCantidadPendiente, deltaCantidadEnProceso, deltaCantidadEntregada, deltaCantidadAnulada)
   End Sub

   Public Sub NormalizaCantidadesSegunEstado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, idProducto As String, orden As Integer)
      Dim sqlPP = New SqlServer.PedidosProductos(da)
      sqlPP.NormalizaCantidadesSegunEstado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProducto, orden)
   End Sub

   Public Function GetListasPreciosPedidosProductos() As DataTable
      Dim sql As SqlServer.PedidosProductos
      Dim dt As DataTable
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.PedidosProductos(da)

         dt = sql.GetListasPreciosPedidosProductos()

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

#End Region

   Public Function GetPedidosProductosJSon(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                           cuitEmpresa As String) As List(Of Entidades.JSonEntidades.Pedidos.PedidoProductoJSon)
      Dim lst = New List(Of Entidades.JSonEntidades.Pedidos.PedidoProductoJSon)()
      Using dt = New SqlServer.PedidosProductos(da).PedidosProductos_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      For Each dr As DataRow In dt.Rows
            Dim o = New Entidades.JSonEntidades.Pedidos.PedidoProductoJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next
      End Using

      Return lst
   End Function
   Private Sub CargarUno(o As Entidades.JSonEntidades.Pedidos.PedidoProductoJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa
         .IdSucursal = Integer.Parse(dr(Entidades.PedidoProducto.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.PedidoProducto.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.PedidoProducto.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Integer.Parse(dr(Entidades.PedidoProducto.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.PedidoProducto.Columnas.NumeroPedido.ToString()).ToString())
         .IdProducto = dr(Entidades.PedidoProducto.Columnas.IdProducto.ToString()).ToString()
         .Orden = Integer.Parse(dr(Entidades.PedidoProducto.Columnas.Orden.ToString()).ToString())

         .Cantidad = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.Cantidad.ToString()).ToString())
         .Precio = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.Precio.ToString()).ToString())
         .Costo = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.Costo.ToString()).ToString())
         .ImporteTotal = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteTotal.ToString()).ToString())
         .NombreProducto = dr(Entidades.PedidoProducto.Columnas.NombreProducto.ToString()).ToString()
         .CantEntregada = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.CantEntregada.ToString()).ToString())
         .CantEnProceso = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.CantEnProceso.ToString()).ToString())
         .DescuentoRecargoProducto = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.DescuentoRecargoProducto.ToString()).ToString())
         If IsNumeric(dr(Entidades.PedidoProducto.Columnas.DescuentoRecargoPorc2.ToString()).ToString()) Then
            .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.PedidoProducto.Columnas.DescuentoRecargoPorc.ToString()).ToString()) Then
            .DescuentoRecargoPorc = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.DescuentoRecargoPorc.ToString()).ToString())
         End If
         .IdTipoImpuesto = dr(Entidades.PedidoProducto.Columnas.IdTipoImpuesto.ToString()).ToString()
         .AlicuotaImpuesto = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.AlicuotaImpuesto.ToString()).ToString())
         .ImporteImpuesto = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteImpuesto.ToString()).ToString())
         .PrecioLista = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioLista.ToString()).ToString())
         If IsDate(dr(Entidades.PedidoProducto.Columnas.FechaActualizacion.ToString()).ToString()) Then
            .FechaActualizacion = DateTime.Parse(dr(Entidades.PedidoProducto.Columnas.FechaActualizacion.ToString()).ToString()).ToString("yyyy-MM-dd HH:mm:ss")
         End If
         .IdListaPrecios = Integer.Parse(dr(Entidades.PedidoProducto.Columnas.IdListaPrecios.ToString()).ToString())
         .NombreListaPrecios = dr(Entidades.PedidoProducto.Columnas.NombreListaPrecios.ToString()).ToString()
         .ImporteImpuestoInterno = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteImpuestoInterno.ToString()).ToString())
         .PorcImpuestoInterno = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PorcImpuestoInterno.ToString()).ToString())
         .PrecioNeto = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioNeto.ToString()).ToString())
         .ImporteTotalNeto = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteTotalNeto.ToString()).ToString())
         .DescRecGeneral = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.DescRecGeneral.ToString()).ToString())
         .DescRecGeneralProducto = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.DescRecGeneralProducto.ToString()).ToString())
         .Kilos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.Kilos.ToString()).ToString())
         .IdCriticidad = dr(Entidades.PedidoEstado.Columnas.IdCriticidad.ToString()).ToString()
         If IsDate(dr(Entidades.PedidoEstado.Columnas.FechaEntrega.ToString()).ToString()) Then
            .FechaEntrega = DateTime.Parse(dr(Entidades.PedidoEstado.Columnas.FechaEntrega.ToString()).ToString()).ToString("yyyy-MM-dd HH:mm:ss")
         End If
         .CantAnulada = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.CantAnulada.ToString()).ToString())
         .CantPendiente = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.CantPendiente.ToString()).ToString())
         .PrecioConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioConImpuestos.ToString()).ToString())
         .PrecioNetoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.PrecioNetoConImpuestos.ToString()).ToString())
         .ImporteTotalConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteTotalConImpuestos.ToString()).ToString())
         .ImporteTotalNetoConImpuestos = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.ImporteTotalNetoConImpuestos.ToString()).ToString())

         If IsNumeric(dr(Entidades.PedidoProducto.Columnas.Tamano.ToString()).ToString()) Then
            .Tamano = Decimal.Parse(dr(Entidades.PedidoProducto.Columnas.Tamano.ToString()).ToString())
         End If
         .IdUnidadDeMedida = dr(Entidades.PedidoProducto.Columnas.IdUnidadDeMedida.ToString()).ToString()
         If IsNumeric(dr(Entidades.PedidoProducto.Columnas.IdMoneda.ToString()).ToString()) Then
            .IdMoneda = Integer.Parse(dr(Entidades.PedidoProducto.Columnas.IdMoneda.ToString()).ToString())
         End If
         .ModificoPrecioManualmente = dr.Field(Of Boolean)(Entidades.PedidoProducto.Columnas.ModificoPrecioManualmente.ToString())
         .CantidadManual = dr.Field(Of Decimal)(Entidades.PedidoProducto.Columnas.CantidadManual.ToString())
         .Conversion = dr.Field(Of Decimal)(Entidades.PedidoProducto.Columnas.Conversion.ToString())

         'Del Turco
         .IdPlazoEntrega = 0
         .ModificoDescuentos = dr.Field(Of Boolean)(Entidades.PedidoProducto.Columnas.ModificoDescuentos.ToString())

      End With
   End Sub

End Class