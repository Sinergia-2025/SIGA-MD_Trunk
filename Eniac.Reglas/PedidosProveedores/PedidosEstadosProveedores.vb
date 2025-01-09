Public Class PedidosEstadosProveedores
   Inherits Base

   Private _categoriaFiscalEmpresa As Entidades.CategoriaFiscal
   Private _cache As BusquedasCacheadas

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(cache As BusquedasCacheadas)
      Me.New(New Datos.DataAccess(), cache)
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.New(accesoDatos, New BusquedasCacheadas())
   End Sub
   Private Sub New(accesoDatos As Datos.DataAccess, cache As BusquedasCacheadas)
      MyBase.New("PedidosEstadosProveedores", accesoDatos)
      _categoriaFiscalEmpresa = New CategoriasFiscales().GetUno(Publicos.CategoriaFiscalEmpresa)
      _cache = cache
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.PedidoEstadoProveedor)))
   End Sub
#End Region

   Public Sub Inserta(prod As Entidades.PedidoEstadoProveedor)
      EjecutaSP(prod, TipoSP._I)
   End Sub

   Public Sub Inserta(prod As Entidades.PedidoProductoProveedor)
      Dim estado = New Entidades.PedidoEstadoProveedor()

      estado.IdSucursal = prod.IdSucursal
      estado.IdTipoComprobante = prod.IdTipoComprobante
      estado.Letra = prod.Letra
      estado.CentroEmisor = prod.CentroEmisor
      estado.NumeroPedido = prod.NumeroPedido
      estado.IdProducto = prod.IdProducto
      estado.Orden = prod.Orden
      estado.Proveedor = prod.Proveedor
      estado.FechaEstado = Date.Now
      estado.IdEstado = Publicos.PedidoProveedorEstadoNuevo ' EstadoPedidoProveedor.ESTADO_ALTA ' "PENDIENTE"
      estado.TipoEstadoPedido = prod.TipoComprobante.Tipo
      estado.IdUsuario = actual.Nombre
      estado.Observacion = "Alta Pedido"
      estado.CantEstado = prod.Cantidad
      estado.IdTipoComprobanteFact = ""
      estado.LetraFact = ""
      estado.CentroEmisorFact = 0
      estado.NumeroComprobanteFact = 0
      estado.IdCriticidad = prod.IdCriticidad
      estado.FechaEntrega = prod.FechaEntrega

      Inserta(estado)

      RegistraMovimientoStock(estado.IdSucursal, estado.IdTipoComprobante, estado.Letra, estado.CentroEmisor, estado.NumeroPedido,
                          estado.IdProducto, estado.Orden, String.Empty, estado.IdEstado, estado.TipoEstadoPedido,
                          estado.CantEstado, Entidades.Entidad.MetodoGrabacion.Automatico, "PedidosProveedores")

   End Sub

   Public Sub EjecutaSP(prod As Entidades.PedidoEstadoProveedor, tipo As TipoSP)

      Dim sql = New SqlServer.PedidosEstadosProveedores(da)

      Select Case tipo
         Case TipoSP._I
            sql.PedidosEstadosProveedores_I(prod.IdSucursal,
                                    prod.IdTipoComprobante,
                                    prod.Letra,
                                    prod.CentroEmisor,
                                    prod.NumeroPedido,
                                    prod.IdProducto,
                                    prod.FechaEstado,
                                    prod.Proveedor.IdProveedor,
                                    prod.IdEstado,
                                    prod.IdUsuario,
                                    prod.Observacion,
                                    prod.CantEstado,
                                    prod.IdTipoComprobanteFact,
                                    prod.LetraFact,
                                    prod.CentroEmisorFact,
                                    prod.NumeroComprobanteFact,
                                    prod.Orden,
                                    prod.IdCriticidad,
                                    prod.FechaEntrega,
                                    prod.TipoEstadoPedido,
                                    0,
                                    prod.IdSucursalGenerado,
                                    prod.IdTipoComprobanteGenerado,
                                    prod.LetraGenerado,
                                    prod.CentroEmisorGenerado,
                                    prod.NumeroPedidoGenerado,
                                    prod.IdSucursalRemito,
                                    prod.IdTipoComprobanteRemito,
                                    prod.LetraRemito,
                                    prod.CentroEmisorRemito,
                                    prod.NumeroComprobanteRemito,
                                    prod.IdEstadoProducto,
                                    prod.IdEstadoCantidad,
                                    prod.IdEstadoPrecio,
                                    prod.IdEstadoFechaEntrega,
                                    prod.FechaEstadoProducto,
                                    prod.FechaEstadoCantidad,
                                    prod.FechaEstadoPrecio,
                                    prod.FechaEstadoFechaEntrega)

         Case TipoSP._U

         Case TipoSP._D
            Dim sqlPE As SqlServer.PedidosEstadosProveedores = New SqlServer.PedidosEstadosProveedores(da)
            sqlPE.PedidosEstadosProveedores_D(prod.IdSucursal, prod.IdTipoComprobante, prod.Letra, prod.CentroEmisor, prod.NumeroPedido, prod.Orden, prod.IdProducto, Nothing)
      End Select

   End Sub



   Private Sub CargarUno(o As Entidades.PedidoEstadoProveedor, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.PedidoEstadoProveedor.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroPedido.ToString()).ToString())
         .Orden = Integer.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.Orden.ToString()).ToString())
         .FechaEstado = DateTime.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.FechaEstado.ToString()).ToString())
         .IdProducto = dr(Entidades.PedidoEstadoProveedor.Columnas.IdProducto.ToString()).ToString()
         .Proveedor = New Reglas.Proveedores(da)._GetUno(Long.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.IdProveedor.ToString()).ToString()))

         .IdEstado = dr(Entidades.PedidoEstadoProveedor.Columnas.IdEstado.ToString()).ToString()
         .IdUsuario = dr(Entidades.PedidoEstadoProveedor.Columnas.IdUsuario.ToString()).ToString()
         .CantEstado = Decimal.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.CantEstado.ToString()).ToString())
         .Observacion = dr(Entidades.PedidoEstadoProveedor.Columnas.Observacion.ToString()).ToString()
         .IdTipoComprobanteFact = dr(Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobanteFact.ToString()).ToString()
         .LetraFact = dr(Entidades.PedidoEstadoProveedor.Columnas.LetraFact.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorFact.ToString()).ToString()) Then
            .CentroEmisorFact = Integer.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorFact.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroComprobanteFact.ToString()).ToString()) Then
            .NumeroComprobanteFact = Long.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroComprobanteFact.ToString()).ToString())
         End If


         .IdCriticidad = dr(Entidades.PedidoEstadoProveedor.Columnas.IdCriticidad.ToString()).ToString()
         .FechaEntrega = DateTime.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.FechaEntrega.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroReparto.ToString()).ToString()) Then
            .NumeroReparto = Integer.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroReparto.ToString()).ToString())
         End If

         .TipoEstadoPedido = dr(Entidades.PedidoEstadoProveedor.Columnas.TipoEstadoPedido.ToString()).ToString()

         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.IdSucursalGenerado.ToString()).ToString()) Then
            .IdSucursalGenerado = Integer.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.IdSucursalGenerado.ToString()).ToString())
         End If
         .IdTipoComprobanteGenerado = dr(Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobanteGenerado.ToString()).ToString()
         .LetraGenerado = dr(Entidades.PedidoEstadoProveedor.Columnas.LetraGenerado.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorGenerado.ToString()).ToString()) Then
            .CentroEmisorGenerado = Integer.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorGenerado.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroPedidoGenerado.ToString()).ToString()) Then
            .NumeroPedidoGenerado = Long.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroPedidoGenerado.ToString()).ToString())
         End If


         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.IdSucursalRemito.ToString()).ToString()) Then
            .IdSucursalRemito = Integer.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.IdSucursalRemito.ToString()).ToString())
         End If
         .IdTipoComprobanteRemito = dr(Entidades.PedidoEstadoProveedor.Columnas.IdTipoComprobanteRemito.ToString()).ToString()
         .LetraRemito = dr(Entidades.PedidoEstadoProveedor.Columnas.LetraRemito.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorRemito.ToString()).ToString()) Then
            .CentroEmisorRemito = Integer.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.CentroEmisorRemito.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroComprobanteRemito.ToString()).ToString()) Then
            .NumeroComprobanteRemito = Long.Parse(dr(Entidades.PedidoEstadoProveedor.Columnas.NumeroComprobanteRemito.ToString()).ToString())
         End If

         .IdEstadoProducto = dr.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdEstadoProducto.ToString())
         .IdEstadoCantidad = dr.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdEstadoCantidad.ToString())
         .IdEstadoPrecio = dr.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdEstadoPrecio.ToString())
         .IdEstadoFechaEntrega = dr.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdEstadoFechaEntrega.ToString())

         .FechaEstadoProducto = dr.Field(Of Date?)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoProducto.ToString())
         .FechaEstadoCantidad = dr.Field(Of Date?)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoCantidad.ToString())
         .FechaEstadoPrecio = dr.Field(Of Date?)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoPrecio.ToString())
         .FechaEstadoFechaEntrega = dr.Field(Of Date?)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoFechaEntrega.ToString())

      End With
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                        orden As Integer, idProducto As String, fechaEstado As Date?) As DataTable
      Return New SqlServer.PedidosEstadosProveedores(da).
                                 PedidosEstadosProveedores_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, fechaEstado)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          orden As Integer, idProducto As String, fechaEstado As Date?) As Entidades.PedidoEstadoProveedor
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, fechaEstado, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          orden As Integer, idProducto As String, fechaEstado As Date?,
                          accion As AccionesSiNoExisteRegistro) As Entidades.PedidoEstadoProveedor
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, fechaEstado),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoEstadoProveedor(),
                          accion, Function() String.Format("No existe Estado de Pedido de Proveedor con {0}/{1} {2} {3:0000}-{4:00000000} / {5} {6}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto))
   End Function

   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Return New SqlServer.PedidosEstadosProveedores(da).PedidosEstadosProveedores_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, String.Empty)
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As List(Of Entidades.PedidoEstadoProveedor)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoEstadoProveedor())
   End Function

   Public Function GetPrimerFechaEntrega(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, orden As Integer) As DataTable
      Return New SqlServer.PedidosEstadosProveedores(da).PedidosEstadosProveedores_GPrimerFechaEntrega(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden)
   End Function

   Public Function GetTodosPorPedidoGenerado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As List(Of Entidades.PedidoEstadoProveedor)
      Dim dt = New SqlServer.PedidosEstadosProveedores(da).PedidosEstadosProveedores_G_PorComprobanteGenerado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoEstadoProveedor())
   End Function


   Public Sub ActualizarEstadoPedidoProveedorMasivo(idSucursal As Integer, idEstado As String,
                                                    tipoEstadoPedido As String,
                                                    idUsuario As String, observ As String, idCriticidad As String,
                                                    fechaEntrega As Date?, cantidadCambioIndividual As Decimal?,
                                                    idResponsable As Integer, fechaNuevoEstado As Date?,
                                                    tablagrabar As DataTable,
                                                    generaUnPedidoPorProveedor As Boolean,
                                                    MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                                    IdFuncion As String)
      EjecutaConTransaccion(
      Sub()
         _ActualizarEstadoPedidoProveedorMasivo(idSucursal, idEstado,
                                                tipoEstadoPedido,
                                                idUsuario, observ, idCriticidad,
                                                fechaEntrega, cantidadCambioIndividual,
                                                idResponsable, fechaNuevoEstado,
                                                tablagrabar,
                                                generaUnPedidoPorProveedor,
                                                MetodoGrabacion,
                                                IdFuncion)
      End Sub)
   End Sub

   Friend Sub _ActualizarEstadoPedidoProveedorMasivo(idSucursal As Integer, idEstado As String,
                                                     tipoEstadoPedido As String,
                                                     idUsuario As String, observ As String, idCriticidad As String,
                                                     fechaEntrega As Date?, cantidadCambioIndividual As Decimal?,
                                                     idResponsable As Integer, fechaNuevoEstado As Date?,
                                                     tablagrabar As DataTable,
                                                     generaUnPedidoPorProveedor As Boolean,
                                                     MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                                     IdFuncion As String)
      'Viene el Estado pero tambien utilizo el Tipo de Estado

      Dim idTipoEstado = New EstadosPedidosProveedores(da).GetUno(idEstado, tipoEstadoPedido).IdTipoEstado
      '------------------------------------------------------------------------

      If Not fechaNuevoEstado.HasValue Then
         fechaNuevoEstado = Now
      End If
      Dim FechaNuevoEstadoInicial As Date = fechaNuevoEstado.Value

      Dim dicCompraAGenerar As Dictionary(Of String, List(Of DataRow)) = New Dictionary(Of String, List(Of DataRow))()
      Dim dicPedidosAGenerar As Dictionary(Of String, List(Of DataRow)) = New Dictionary(Of String, List(Of DataRow))()
      Dim dicProduccionAGenerar As Dictionary(Of String, List(Of DataRow)) = New Dictionary(Of String, List(Of DataRow))()


      Dim sqlPE As SqlServer.PedidosEstadosProveedores = New SqlServer.PedidosEstadosProveedores(da)
      Dim fechaEntregaNull As Boolean = Not fechaEntrega.HasValue
      For Each filaGrabar In tablagrabar.AsEnumerable()

         ''Lo paso aca porque si el campo de estado genera comprobantes se tilda al buscar el proximo numero en la segunda pasada
         'da.BeginTransaction()

         'Dim sqlEstado As SqlServer.EstadosPedidosProveedores = New SqlServer.EstadosPedidosProveedores(da)

         Dim idTipoComprobante = filaGrabar(Entidades.Pedido.Columnas.IdTipoComprobante.ToString()).ToString()
         Dim letra = filaGrabar(Entidades.Pedido.Columnas.Letra.ToString()).ToString()
         Dim centroEmisor = Integer.Parse(filaGrabar(Entidades.Pedido.Columnas.CentroEmisor.ToString()).ToString())
         Dim numeroPedido = Long.Parse(filaGrabar(Entidades.Pedido.Columnas.NumeroPedido.ToString()).ToString())

         Dim idProd = filaGrabar("idProducto").ToString
         Dim fechaEstado = Date.Parse(filaGrabar("fechaEstado").ToString)
         '' ''IdCriticidad = filaGrabar("IdCriticidad").ToString
         If fechaEntregaNull Then
            fechaEntrega = Date.Parse(filaGrabar("FechaEntrega").ToString)
         End If

         Dim idEstadoAnterior = filaGrabar("IdEstado").ToString()

         Dim orden = Integer.Parse(filaGrabar("Orden").ToString)
         Dim idProveedor = Long.Parse(filaGrabar("IdProveedor").ToString)

         'idEstadoAnterior = filaGrabar("IdEstado").ToString
         Dim idTipoEstadoAnterior = New EstadosPedidosProveedores().GetUno(filaGrabar("IdEstado").ToString(), tipoEstadoPedido).IdTipoEstado

         If cantidadCambioIndividual.HasValue Then
            filaGrabar("CantidadNuevoEstado") = cantidadCambioIndividual.Value
         End If
         Dim cantEstado = Decimal.Parse(filaGrabar("CantidadNuevoEstado").ToString)

         Dim rPP = New PedidosProductosProveedores(da)
         Dim sqlEP = New SqlServer.EstadosPedidosProveedores(da)
         Dim sqlPP = New SqlServer.PedidosProductosProveedores(da)
         Dim dtPedido = GetPedidosEstadosProveedoresUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProd, fechaEstado, orden)

         Dim idTipoComprobanteFactura As String
         Dim letraComprobanteFact As String
         Dim centroEmisorFact As Short
         Dim numeroComprobanteFact As Long
         Dim idSucursalRemito As Integer
         Dim idTipoComprobanteRemito As String
         Dim letraComprobanteRemito As String
         Dim centroEmisorRemito As Short
         Dim numeroComprobanteRemito As Long
         Dim idSucursalGenerado As Integer
         Dim idTipoComprobanteGenerado As String
         Dim letraComprobanteGenerado As String
         Dim centroEmisorGenerado As Short
         Dim numeroPedidoGenerado As Long

         idTipoComprobanteFactura = filaGrabar(Entidades.PedidoEstado.Columnas.IdTipoComprobanteFact.ToString()).ToString()
         letraComprobanteFact = filaGrabar(Entidades.PedidoEstado.Columnas.LetraFact.ToString()).ToString()
         If IsNumeric(filaGrabar(Entidades.PedidoEstado.Columnas.CentroEmisorFact.ToString()).ToString()) Then
            centroEmisorFact = Short.Parse(filaGrabar(Entidades.PedidoEstado.Columnas.CentroEmisorFact.ToString()).ToString())
         End If
         If IsNumeric(filaGrabar(Entidades.PedidoEstado.Columnas.NumeroComprobanteFact.ToString()).ToString()) Then
            numeroComprobanteFact = Long.Parse(filaGrabar(Entidades.PedidoEstado.Columnas.NumeroComprobanteFact.ToString()).ToString())
         End If

         If IsNumeric(filaGrabar(Entidades.PedidoEstado.Columnas.IdSucursalRemito.ToString()).ToString()) Then
            idSucursalRemito = Integer.Parse(filaGrabar(Entidades.PedidoEstado.Columnas.IdSucursalRemito.ToString()).ToString())
         End If
         idTipoComprobanteRemito = filaGrabar(Entidades.PedidoEstado.Columnas.IdTipoComprobanteRemito.ToString()).ToString()
         letraComprobanteRemito = filaGrabar(Entidades.PedidoEstado.Columnas.LetraRemito.ToString()).ToString()
         If IsNumeric(filaGrabar(Entidades.PedidoEstado.Columnas.CentroEmisorRemito.ToString()).ToString()) Then
            centroEmisorRemito = Short.Parse(filaGrabar(Entidades.PedidoEstado.Columnas.CentroEmisorRemito.ToString()).ToString())
         End If
         If IsNumeric(filaGrabar(Entidades.PedidoEstado.Columnas.NumeroComprobanteRemito.ToString()).ToString()) Then
            numeroComprobanteRemito = Long.Parse(filaGrabar(Entidades.PedidoEstado.Columnas.NumeroComprobanteRemito.ToString()).ToString())
         End If

         If IsNumeric(filaGrabar(Entidades.PedidoEstado.Columnas.IdSucursalGenerado.ToString()).ToString()) Then
            idSucursalGenerado = Integer.Parse(filaGrabar(Entidades.PedidoEstado.Columnas.IdSucursalGenerado.ToString()).ToString())
         End If
         idTipoComprobanteGenerado = filaGrabar(Entidades.PedidoEstado.Columnas.IdTipoComprobanteGenerado.ToString()).ToString()
         letraComprobanteGenerado = filaGrabar(Entidades.PedidoEstado.Columnas.LetraGenerado.ToString()).ToString()
         If IsNumeric(filaGrabar(Entidades.PedidoEstado.Columnas.CentroEmisorGenerado.ToString()).ToString()) Then
            centroEmisorGenerado = Short.Parse(filaGrabar(Entidades.PedidoEstado.Columnas.CentroEmisorGenerado.ToString()).ToString())
         End If
         If IsNumeric(filaGrabar(Entidades.PedidoEstado.Columnas.NumeroPedidoGenerado.ToString()).ToString()) Then
            numeroPedidoGenerado = Long.Parse(filaGrabar(Entidades.PedidoEstado.Columnas.NumeroPedidoGenerado.ToString()).ToString())
         End If

         Dim idEstadoProducto As String = filaGrabar.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdEstadoProducto.ToString())
         Dim idEstadoCantidad As String = filaGrabar.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdEstadoCantidad.ToString())
         Dim idEstadoPrecio As String = filaGrabar.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdEstadoPrecio.ToString())
         Dim idEstadoFechaEntrega As String = filaGrabar.Field(Of String)(Entidades.PedidoEstadoProveedor.Columnas.IdEstadoFechaEntrega.ToString())
         Dim fechaEstadoProducto As Date? = filaGrabar.Field(Of Date?)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoProducto.ToString())
         Dim fechaEstadoCantidad As Date? = filaGrabar.Field(Of Date?)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoCantidad.ToString())
         Dim fechaEstadoPrecio As Date? = filaGrabar.Field(Of Date?)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoPrecio.ToString())
         Dim fechaEstadoFechaEntrega As Date? = filaGrabar.Field(Of Date?)(Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoFechaEntrega.ToString())


         If Decimal.Parse(dtPedido.Rows(0)("CantEstado").ToString()) = cantEstado Then
            CambiarEstado(idSucursal,
                          idTipoComprobante, letra, centroEmisor, numeroPedido,
                          idProd,
                          fechaEstado,
                          idEstado,
                          tipoEstadoPedido,
                          cantEstado,
                          fechaNuevoEstado.Value,
                          observ,
                          orden,
                          idCriticidad,
                          fechaEntrega.Value,
                          0,
                          sqlPE)
         Else
            sqlPE.PedidosEstadosProveedores_I(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    numeroPedido,
                                    idProd,
                                    fechaNuevoEstado.Value,
                                    idProveedor,
                                    idEstado,
                                    idUsuario,
                                    observ,
                                    cantEstado,
                                    idTipoComprobanteFactura,
                                    letraComprobanteFact,
                                    centroEmisorFact,
                                    numeroComprobanteFact,
                                    orden,
                                    idCriticidad,
                                    fechaEntrega,
                                    tipoEstadoPedido,
                                    0,
                                    idSucursalGenerado,
                                    idTipoComprobanteGenerado,
                                    letraComprobanteGenerado,
                                    centroEmisorGenerado,
                                    numeroPedidoGenerado,
                                    idSucursalRemito,
                                    idTipoComprobanteRemito,
                                    letraComprobanteRemito,
                                    centroEmisorRemito,
                                    numeroComprobanteRemito,
                                    idEstadoProducto,
                                    idEstadoCantidad,
                                    idEstadoPrecio,
                                    idEstadoFechaEntrega,
                                    fechaEstadoProducto,
                                    fechaEstadoCantidad,
                                    fechaEstadoPrecio,
                                    fechaEstadoFechaEntrega)
            sqlPE.PedidosEstadosProveedores_U_Cantidad(idSucursal,
                                   idTipoComprobante,
                                   letra,
                                   centroEmisor,
                                   numeroPedido,
                                   idProd,
                                   orden,
                                   fechaEstado,
                                   cantEstado * -1)
         End If


         rPP.ActualizaCantidadesSegunEstadoAnteriorNuevo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProd, orden,
                                                         idTipoEstadoAnterior, idTipoEstado, cantEstado)

         RegistraMovimientoStock(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProd, orden,
                             idEstadoAnterior, idEstado, tipoEstadoPedido, cantEstado,
                             Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

         ActualizaPedidoOrigen(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProd, orden, fechaNuevoEstado.Value,
                               idEstadoAnterior, idEstado, tipoEstadoPedido, cantEstado, idResponsable, IdFuncion)


         Dim IdTipoComprobanteFact As String = sqlEP.GetComprobanteXEstado(idEstado, tipoEstadoPedido)

         If Not String.IsNullOrEmpty(IdTipoComprobanteFact) Then
            Dim tipoComprobante = New Reglas.TiposComprobantes(da).GetUno(IdTipoComprobanteFact)

            'clavePedidoFormato
            '  {0} = idSucursal
            '  {1} = idTipoComprobante
            '  {2} = letra
            '  {3} = centroEmisor
            '  {4} = numeroPedido
            '  {5} = IdTipoComprobant
            '  {6} = idSucursalComprobante
            '  {7} = idProveedor
            If tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString() Then
               Dim idSucursalComprobante As Integer = idSucursal
               '   If IsNumeric(filaGrabar("IdSucursal")) AndAlso Integer.Parse(filaGrabar("IdSucursalo").ToString()) > 0 Then
               idSucursalComprobante = Integer.Parse(filaGrabar("IdSucursal").ToString())
               '  End If

               Dim clavePedidoFormato = "{0}\{1}\{2}\{3:0000}\{4:00000000}\{5}\{6}"
               Dim clavePedido = String.Format(clavePedidoFormato, idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, tipoComprobante.IdTipoComprobante,
                                               idSucursalComprobante, idProveedor)
               If Not dicCompraAGenerar.ContainsKey(clavePedido) Then
                  dicCompraAGenerar.Add(clavePedido, New List(Of DataRow))
               End If
               dicCompraAGenerar(clavePedido).Add(filaGrabar)
            ElseIf tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSPROV.ToString() OrElse
                   tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PRESUPPROV.ToString() OrElse
                   tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString() Then
               Dim idSucursalComprobante As Integer = idSucursal
               Dim clavePedidoFormato = "{0}\{1}\{2}\{3:0000}\{4:00000000}\{5}"
               If generaUnPedidoPorProveedor Then
                  clavePedidoFormato = "{0}\{7}\{5}"
               End If
               Dim clavePedido = String.Format(clavePedidoFormato, idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, tipoComprobante.IdTipoComprobante,
                                               idSucursalComprobante, idProveedor)
               If Not dicPedidosAGenerar.ContainsKey(clavePedido) Then
                  dicPedidosAGenerar.Add(clavePedido, New List(Of DataRow))
               End If
               dicPedidosAGenerar(clavePedido).Add(filaGrabar)
            End If      'If tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.COMPRAS.ToString() Then
            'Y DE        ElseIf tipoComprobante.Tipo = Entidades.TipoComprobante.Tipos.PEDIDOSPROV.ToString() OrElse PRESUPPROV.ToString() OrElse ORDENCOMPRAPROV.ToString() Then
         End If

         fechaNuevoEstado = fechaNuevoEstado.Value.AddSeconds(1)
      Next           'For Each filaGrabar As DataRow In tablagrabar.Rows

      CreaCompraDesdePedido(dicCompraAGenerar, FechaNuevoEstadoInicial, fechaNuevoEstado.Value, idResponsable, IdFuncion, sqlPE)

      For Each valores In dicPedidosAGenerar
         Dim valoresCol = valores.Key.Split("\"c)

         Dim primerDR = valores.Value.First()

         Dim tipoComprobante = _cache.BuscaTipoComprobante(If(valoresCol.Length > 3, valoresCol(5), valoresCol(2)))

         Dim idSucursalPresup = primerDR.Field(Of Integer)("IdSucursal") ' Integer.Parse(valoresCol(0))
         Dim idTipoComprobantePresup = primerDR.Field(Of String)("IdTipoComprobante") ' valoresCol(1)
         Dim letraPresup = primerDR.Field(Of String)("Letra") ' valoresCol(2)
         Dim centroEmisorPresup = primerDR.Field(Of Integer)("CentroEmisor") ' Integer.Parse(valoresCol(3))
         Dim numeroPedidoPresup = primerDR.Field(Of Long)("NumeroPedido") ' Long.Parse(valoresCol(4))

         Dim presup = New PedidosProveedores(da).GetUno(idSucursalPresup, idTipoComprobantePresup, letraPresup, centroEmisorPresup, numeroPedidoPresup)

         Dim rPedidos = New PedidosProveedores(da)
         Dim pedido = rPedidos._CrearPedido(presup.Proveedor,
                                            tipoComprobante,
                                            letra:=String.Empty, centroEmisor:=Nothing, numeroComprobante:=Nothing,
                                            fecha:=Today,
                                            presup.Comprador,
                                            presup.Transportista,
                                            presup.FormaPago,
                                            presup.TipoComprobanteFact,
                                            observaciones:=String.Empty,
                                            presup.EstadoVisita,
                                            ordenCompra:=0)

         For Each drFilaGrabar In valores.Value

            idSucursalPresup = drFilaGrabar.Field(Of Integer)("IdSucursal") ' Integer.Parse(valoresCol(0))
            idTipoComprobantePresup = drFilaGrabar.Field(Of String)("IdTipoComprobante") ' valoresCol(1)
            letraPresup = drFilaGrabar.Field(Of String)("Letra") ' valoresCol(2)
            centroEmisorPresup = drFilaGrabar.Field(Of Integer)("CentroEmisor") ' Integer.Parse(valoresCol(3))
            numeroPedidoPresup = drFilaGrabar.Field(Of Long)("NumeroPedido") ' Long.Parse(valoresCol(4))

            Dim idProd = drFilaGrabar("idProducto").ToString()
            Dim oProducto = _cache.BuscaProductoEntidadPorId(idProd)
            Dim ordenPresup = drFilaGrabar.Field(Of Integer)("Orden")
            Dim CantEstadoPresup = drFilaGrabar.Field(Of Decimal)("CantidadNuevoEstado")

            Dim presupProd = New PedidosProductosProveedores(da).GetUno(idSucursalPresup, idTipoComprobantePresup, letraPresup, centroEmisorPresup, numeroPedidoPresup,
                                                                        ordenPresup, idProd)

            Dim costo = presupProd.Costo
            Dim usaPrecioSinIVA = (pedido.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
                                  Not pedido.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos
            Dim alicuota = presupProd.AlicuotaImpuesto
            If Not usaPrecioSinIVA Then
               costo = presupProd.CostoConImpuestos
            End If

            rPedidos.AgregarLinea(pedido,
                                  rPedidos.CrearPedidoProducto(
                                          producto:=oProducto,
                                          productoDescripcion:=presupProd.NombreProducto,
                                          descuentoRecargoPorc1:=presupProd.DescuentoRecargoPorc,
                                          descuentoRecargoPorc2:=presupProd.DescuentoRecargoPorc2,
                                          costo:=costo,
                                          cantidad:=CantEstadoPresup,
                                          tipoImpuesto:=presupProd.TipoImpuesto,
                                          porcentajeIva:=alicuota,
                                          criticidad:=New PedidosCriticidades(da).GetUno(presupProd.IdCriticidad),
                                          fechaEntrega:=Today,
                                          cantidadUMCompra:=presupProd.FactorConversionCompra * CantEstadoPresup,
                                          factorConversionCompra:=presupProd.FactorConversionCompra,
                                          precioPorUMCompra:=presupProd.PrecioPorUMCompra,
                                          pedido:=pedido,
                                          redondeoEnCalculo:=2))

         Next        'For Each drFilaGrabar As DataRow In valores.Value

         'Lo dejamos para cuando se realice el desarrollo de ProveedoresContactos
         'For Each pedCont As PedidoClienteContacto In presup.PedidosContactos
         '   rPedidos.AgregarContacto(pedido, pedCont.Contacto)
         'Next

         For Each pedObs In presup.PedidosObservaciones
            rPedidos.AgregarObservacion(pedido, pedObs)
         Next

         Dim pedidoGenerado = rPedidos.Inserta(pedido)

         For Each drFilaGrabar In valores.Value
            Dim idProdPres = drFilaGrabar.Field(Of String)("idProducto")
            Dim ordenPresup = drFilaGrabar.Field(Of Integer)("Orden")

            sqlPE.PedidosEstadosProveedores_U_Ped(
                        presup.IdSucursal, presup.IdTipoComprobante, presup.LetraComprobante, presup.CentroEmisor,
                        presup.NumeroPedido, idProdPres, FechaNuevoEstadoInicial, fechaNuevoEstado, ordenPresup,
                        pedidoGenerado.IdSucursal, pedidoGenerado.IdTipoComprobante, pedidoGenerado.LetraComprobante,
                        pedidoGenerado.CentroEmisor, pedidoGenerado.NumeroPedido)
         Next
      Next           'For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicPedidosAGenerar

      '' ''CreaProduccionDesdePedido(dicProduccionAGenerar, FechaNuevoEstadoInicial, FechaNuevoEstado, tipoDocResponsable, nroDocResponsable, sqlPE)

   End Sub
   Private Sub CreaCompraDesdePedido(dicCompraAGenerar As Dictionary(Of String, List(Of DataRow)),
                                    fechaNuevoEstadoInicial As Date,
                                    fechaNuevoEstado As Date,
                                    IdResponsable As Integer,
                                    idFuncion As String,
                                    sqlPE As SqlServer.PedidosEstadosProveedores)

      Dim formaDePagoCtaCte = New VentasFormasPago().GetUna("COMPRAS", False)
      Dim dtCajas = New CajasUsuarios(da).GetCajasTodas({actual.Sucursal}, actual.Nombre, nombrePC:=String.Empty, cajasModificables:=True)
      Dim caja = dtCajas.FirstOrDefault()
      If caja Is Nothing Then Throw New Exception("No tiene ninguna caja con permiso de escritura. No podrá continuar.")
      Dim idCaja = caja.IdCaja
      'If Not dtCajas.Any() Then Throw New Exception("No tiene ninguna caja con permiso de escritura. No podrá continuar.")
      'Dim idCaja = dtCajas.First().Field(Of Integer)("IdCaja")

      For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicCompraAGenerar
         Dim valoresCol = valores.Key.Split("\"c)
         Dim tipoComprobanteFact = _cache.BuscaTipoComprobante(valoresCol(5))

         Dim idSucursalPedido = Integer.Parse(valoresCol(0))
         Dim idTipoComprobantePedido = valoresCol(1)
         Dim letraPedido = valoresCol(2)
         Dim centroEmisorPedido = Integer.Parse(valoresCol(3))
         Dim numeroPedidoPedido = Long.Parse(valoresCol(4))

         Dim idSucursalComprobante = If(valoresCol.Length > 6, Integer.Parse(valoresCol(6)), idSucursalPedido)

         Dim pedido = New PedidosProveedores(da).GetUno(idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido)

         Dim regProveedores = New Proveedores(da)
         Dim oProveedor = regProveedores._GetUno(pedido.Proveedor.IdProveedor, False)

         'Corregir para que no habra conexion.
         Dim oReglaCompras = New Compras(da)

         Dim Comprobante As Entidades.Compra
         Dim idProveedor As Long = oProveedor.IdProveedor
         Dim fecha As Date = fechaNuevoEstado
         Dim cache = New BusquedasCacheadas()
         Dim idComprador = cache.GetPrimerComprador()
         Dim asoc As Entidades.Compra() = {}
         Dim rubro As Integer = New RubrosCompras().GetTodos().FirstOrDefault().IdRubro

         Dim idFormaDePagoCtaCte = New VentasFormasPago().GetUna("VENTAS", False).IdFormasPago

         Dim observacion = String.Format("Generado por Cambio de Estado de: {0} {1} {2:0000}-{3:00000000}. Fecha: {4:dd/MM/yyyy}",
                                         idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido, fecha).Truncar(100)

         'Dim ventaContacto As List(Of VentaClienteContacto) = New List(Of VentaClienteContacto)()
         'For Each Contacto As Entidades.PedidoClienteContacto In New Reglas.PedidosClientesContactos(da).GetTodos(IdSucursal, IdTipoComprobante, Letra, Convert.ToInt16(CentroEmisor), NumeroPedido)
         '   ventaContacto.Add(New VentaClienteContacto(Contacto.Contacto))
         'Next

         Dim productos = New List(Of Entidades.CompraProducto)
         Dim importeTotal As Decimal = 0

         For Each filaGrabar As DataRow In valores.Value
            Dim producto = New Entidades.CompraProducto()
            With producto
               .Producto = New Productos().GetUno(filaGrabar.Field(Of String)("IdProducto"))
               .Cantidad = filaGrabar.Field(Of Decimal)("CantidadNuevoEstado")
               .Precio = filaGrabar.Field(Of Decimal)("ImporteTotalConImpuestos") / filaGrabar.Field(Of Decimal)("Cantidad")
            End With
            productos.Add(producto)
            importeTotal += producto.Precio * producto.Cantidad
         Next

         'For Each prod As Entidades.PedidoProductoProveedor In pedido.PedidosProductos
         '   With Producto
         '      .Producto = New Reglas.Productos().GetUno(prod.Producto.IdProducto)
         '      .Cantidad = 1
         '   End With
         '   Productos.Add(Producto)
         'Next


         Comprobante = oReglaCompras._GrabarComprobante(actual.Sucursal.Id,
                                                       tipoComprobanteFact.IdTipoComprobante,
                                                       idProveedor,
                                                       idCaja,
                                                       fecha,
                                                       idComprador,
                                                       idFormaDePagoCtaCte,
                                                       observacion,
                                                       importeTotal,
                                                       productos,
                                                       observacionDetalladas:=Nothing,
                                                       contactos:=Nothing,
                                                       nombreProducto:=String.Empty,
                                                       cobrador:=Nothing,
                                                       comprobantesAsociados:=asoc,
                                                       rubro,
                                                       metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion:=idFuncion)


         'Dim orden As Integer = Integer.Parse(filaGrabar("Orden").ToString)

         'If Comprobante.TipoComprobante.AlInvocarPedidoAfectaFactura Then
         '   sqlPE.PedidosEstadosProveedores_U_Fact(idSucursalPedido,
         '                                  idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido,
         '                                  Producto.IdProducto,
         '                                  fechaNuevoEstado,
         '                                  nuevaVenta.IdSucursal,
         '                                  nuevaVenta.IdTipoComprobante,
         '                                  nuevaVenta.LetraComprobante,
         '                                  nuevaVenta.CentroEmisor,
         '                                  nuevaVenta.NumeroComprobante,
         '                                  orden)
         'End If

         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaFactura Then
         'If nuevaVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then
         '   sqlPE.PedidosEstados_U_Remito(idSucursalPedido,
         '                                 idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedidoPedido,
         '                                 producto.IdProducto,
         '                                 fechaNuevoEstado,
         '                                 nuevaVenta.IdSucursal,
         '                                 nuevaVenta.IdTipoComprobante,
         '                                 nuevaVenta.LetraComprobante,
         '                                 nuevaVenta.CentroEmisor,
         '                                 nuevaVenta.NumeroComprobante,
         '                                 orden)
         'End If         'If oVenta.TipoComprobante.AlInvocarPedidoAfectaRemito Then


         '  oReglaCompras.Inserta(nuevaVenta, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

      Next

   End Sub

   Public Sub ActualizarEstadosWeb(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                   idproducto As String, orden As Integer,
                                   idEstadoProducto As String, idEstadoCantidad As String, idEstadoPrecio As String, idEstadoFechaEntrega As String,
                                   fechaEstadoProducto As Date?, fechaEstadoCantidad As Date?, fechaEstadoPrecio As Date?, fechaEstadoFechaEntrega As Date?)
      EjecutaConTransaccion(Sub()
                               ActualizarEstadosWeb(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                    idproducto, orden,
                                                    idEstadoProducto, idEstadoCantidad, idEstadoPrecio, idEstadoFechaEntrega,
                                                    fechaEstadoProducto, fechaEstadoCantidad, fechaEstadoPrecio, fechaEstadoFechaEntrega)
                            End Sub)
   End Sub
   Public Sub _ActualizarEstadosWeb(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                    idproducto As String, orden As Integer,
                                    idEstadoProducto As String, idEstadoCantidad As String, idEstadoPrecio As String, idEstadoFechaEntrega As String,
                                    fechaEstadoProducto As Date?, fechaEstadoCantidad As Date?, fechaEstadoPrecio As Date?, fechaEstadoFechaEntrega As Date?)
      Dim sql = New SqlServer.PedidosEstadosProveedores(da)
      sql.PedidosEstadosProveedores_U_Estados(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                              idproducto, orden,
                                              idEstadoProducto, idEstadoCantidad, idEstadoPrecio, idEstadoFechaEntrega,
                                              fechaEstadoProducto, fechaEstadoCantidad, fechaEstadoPrecio, fechaEstadoFechaEntrega)
   End Sub

   Friend Sub CambiarEstado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                            idproducto As String, fechaEstado As Date, idEstado As String,
                            tipoEstadoPedido As String, cantEstado As Decimal, fechaNuevoEstado As Date,
                            observacion As String, orden As Integer,
                            idCriticidad As String, fechaEntrega As Date, numeroReparto As Integer)
      CambiarEstado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                    idproducto, fechaEstado, idEstado,
                    tipoEstadoPedido, cantEstado, fechaNuevoEstado,
                    observacion, orden,
                    idCriticidad, fechaEntrega, numeroReparto,
                    New SqlServer.PedidosEstadosProveedores(da))
   End Sub

   Private Sub CambiarEstado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                             idproducto As String, fechaEstado As Date, idEstado As String,
                             tipoEstadoPedido As String, cantEstado As Decimal, fechaNuevoEstado As Date,
                             observacion As String, orden As Integer,
                             idCriticidad As String, fechaEntrega As Date, numeroReparto As Integer,
                             sqlPE As SqlServer.PedidosEstadosProveedores)
      Dim sPE = New SqlServer.PedidosEstados(da)

      Using dtPE = sPE.PedidosEstados_G_PorComprobanteVinculado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                          idproducto, orden, fechaEstado)
         For Each drPE As DataRow In dtPE.Rows
            sPE.PedidosEstados_U_Vinculado(Integer.Parse(drPE("IdSucursal").ToString()),
                                           drPE("IdTipoComprobante").ToString(),
                                           drPE("Letra").ToString(),
                                           Short.Parse(drPE("CentroEmisor").ToString()),
                                           Long.Parse(drPE("NumeroPedido").ToString()),
                                           drPE("IdProducto").ToString(),
                                           DateTime.Parse(drPE("FechaEstado").ToString()), Nothing,
                                           Integer.Parse(drPE("Orden").ToString()),
                                           0,
                                           "",
                                           "",
                                           0,
                                           0,
                                           "",
                                           0,
                                           Nothing)
         Next

         sqlPE.PedidosEstadosProveedores_U_Estado(idSucursal,
                                                idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                idproducto,
                                                fechaEstado,
                                                idEstado,
                                                tipoEstadoPedido,
                                                cantEstado,
                                                fechaNuevoEstado,
                                                observacion,
                                                orden,
                                                idCriticidad,
                                                fechaEntrega, numeroReparto:=0)

         For Each drPE As DataRow In dtPE.Rows
            sPE.PedidosEstados_U_Vinculado(Integer.Parse(drPE("IdSucursal").ToString()),
                                        drPE("IdTipoComprobante").ToString(),
                                        drPE("Letra").ToString(),
                                        Short.Parse(drPE("CentroEmisor").ToString()),
                                        Long.Parse(drPE("NumeroPedido").ToString()),
                                        drPE("IdProducto").ToString(),
                                        DateTime.Parse(drPE("FechaEstado").ToString()), Nothing,
                                        Integer.Parse(drPE("Orden").ToString()),
                                        idSucursal,
                                        idTipoComprobante,
                                        letra,
                                        centroEmisor,
                                        numeroPedido,
                                        idproducto,
                                        orden,
                                        fechaNuevoEstado)
         Next
      End Using
   End Sub

   '' ''Private Sub CreaProduccionDesdePedido(dicProduccionAGenerar As Dictionary(Of String, List(Of DataRow)),
   '' ''                                      fechaNuevoEstadoInicial As Date,
   '' ''                                      fechaNuevoEstado As Date,
   '' ''                                      tipoDocResponsable As String,
   '' ''                                      nroDocResponsable As String,
   '' ''                                      sqlPE As SqlServer.PedidosEstadosProveedores)

   '' ''   Dim valoresCol As String()
   '' ''   Dim tipoComprobante As Entidades.TipoComprobante = New TipoComprobante()
   '' ''   Dim idSucursalPedido As Integer
   '' ''   Dim IdTipoComprobantePedido As String
   '' ''   Dim LetraPedido As String
   '' ''   Dim CentroEmisorPedido As Integer
   '' ''   Dim NumeroPedidoPedido As Long
   '' ''   Dim pedido As Entidades.PedidoProveedor
   '' ''   Dim pedidoProd As Entidades.PedidoProductoProveedor
   '' ''   Dim ordProd As Entidades.OrdenProduccion
   '' ''   Dim oProducto As Entidades.Producto
   '' ''   Dim rOrdProd As OrdenesProduccion
   '' ''   Dim idProd As String
   '' ''   Dim ordenPedido As Integer
   '' ''   Dim cantEstadoPedidoProveedor As Decimal
   '' ''   For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicProduccionAGenerar
   '' ''      valoresCol = valores.Key.Split("\"c)

   '' ''      If tipoComprobante.IdTipoComprobante <> valoresCol(5) Then
   '' ''         tipoComprobante = New Reglas.TiposComprobantes(da).GetUno(valoresCol(5))
   '' ''      End If

   '' ''      idSucursalPedido = Integer.Parse(valoresCol(0))
   '' ''      IdTipoComprobantePedido = valoresCol(1)
   '' ''      LetraPedido = valoresCol(2)
   '' ''      CentroEmisorPedido = Integer.Parse(valoresCol(3))
   '' ''      NumeroPedidoPedido = Long.Parse(valoresCol(4))

   '' ''      pedido = New Pedidos(da).GetUno(idSucursalPedido, IdTipoComprobantePedido, LetraPedido, CentroEmisorPedido, NumeroPedidoPedido)


   '' ''      rOrdProd = New OrdenesProduccion(da)
   '' ''      ordProd = rOrdProd.CrearOrdenProduccion(tipoComprobante,
   '' ''                                              pedido.Cliente,
   '' ''                                              String.Empty, Nothing,
   '' ''                                              Nothing,
   '' ''                                              Today,
   '' ''                                              pedido.Cliente.Vendedor,
   '' ''                                              pedido.Transportista,
   '' ''                                              pedido.FormaPago,
   '' ''                                              pedido.TipoComprobanteFact,
   '' ''                                              String.Empty,
   '' ''                                              pedido.EstadoVisita,
   '' ''                                              0)

   '' ''      For Each drFilaGrabar As DataRow In valores.Value
   '' ''         If Not drFilaGrabar.Table.Columns.Contains("OP") Then
   '' ''            drFilaGrabar.Table.Columns.Add("OP", GetType(Object))
   '' ''         End If


   '' ''         idProd = drFilaGrabar("idProducto").ToString()
   '' ''         oProducto = New Reglas.Productos(da).GetUno(idProd)
   '' ''         ordenPedido = Integer.Parse(drFilaGrabar("Orden").ToString)
   '' ''         cantEstadoPedidoProveedor = Decimal.Parse(drFilaGrabar("CantEntregada").ToString)

   '' ''         pedidoProd = New PedidosProductos(da).GetUno(idSucursalPedido, IdTipoComprobantePedido, LetraPedido, CentroEmisorPedido, NumeroPedidoPedido,
   '' ''                                                      ordenPedido, idProd)

   '' ''         Dim precio As Decimal = pedidoProd.Precio
   '' ''         Dim usaPrecioSinIVA As Boolean = (ordProd.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
   '' ''                                          Not ordProd.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos
   '' ''         If Not usaPrecioSinIVA Then
   '' ''            precio = pedidoProd.PrecioConImpuestos
   '' ''         End If

   '' ''         Dim ordProdProd As Entidades.OrdenProduccionProducto
   '' ''         ordProdProd = rOrdProd.CrearOrdenProduccionProducto(oProducto,
   '' ''                                                             pedidoProd.NombreProducto,
   '' ''                                                             pedidoProd.DescuentoRecargoPorc,
   '' ''                                                             pedidoProd.DescuentoRecargoPorc2,
   '' ''                                                             precio,
   '' ''                                                             cantEstadoPedidoProveedor,
   '' ''                                                             pedidoProd.TipoImpuesto,
   '' ''                                                             oProducto.Alicuota,
   '' ''                                                             pedidoProd.IdListaPrecios,
   '' ''                                                             pedidoProd.IdCriticidad,
   '' ''                                                             Today,
   '' ''                                                             ordProd,
   '' ''                                                             2,
   '' ''                                                             pedidoProd.Espmm,
   '' ''                                                             pedidoProd.EspPulgadas,
   '' ''                                                             pedidoProd.CodigoSAE,
   '' ''                                                             pedidoProd.ProduccionProceso,
   '' ''                                                             pedidoProd.ProduccionForma,
   '' ''                                                             pedidoProd.LargoExtAlto,
   '' ''                                                             pedidoProd.AnchoIntBase,
   '' ''                                                             pedidoProd.UrlPlano,
   '' ''                                                             pedidoProd.IdFormula,
   '' ''                                                             tipoDocResponsable,
   '' ''                                                             nroDocResponsable)
   '' ''         rOrdProd.AgregarLinea(ordProd, ordProdProd)

   '' ''         drFilaGrabar("OP") = ordProdProd

   '' ''      Next        'For Each drFilaGrabar As DataRow In valores.Value

   '' ''      Dim ordProdGenerado As Entidades.OrdenProduccion = rOrdProd.Inserta(ordProd)

   '' ''      For Each drFilaGrabar As DataRow In valores.Value
   '' ''         Dim idProdPres As String = drFilaGrabar("idProducto").ToString()
   '' ''         ordenPedido = Integer.Parse(drFilaGrabar("Orden").ToString)

   '' ''         Dim ordProdProd As OrdenProduccionProducto = DirectCast(drFilaGrabar("OP"), OrdenProduccionProducto)

   '' ''         sqlPE.PedidosEstadosProveedores_U_OP(pedido.IdSucursal, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor,
   '' ''                                   pedido.NumeroPedido, idProdPres, fechaNuevoEstadoInicial, fechaNuevoEstado, ordenPedido,
   '' ''                                   ordProdGenerado.IdSucursal, ordProdGenerado.IdTipoComprobante, ordProdGenerado.LetraComprobante,
   '' ''                                   ordProdGenerado.CentroEmisor, ordProdGenerado.NumeroOrdenProduccion,
   '' ''                                   ordProdProd.IdProducto, ordProdProd.Orden)
   '' ''      Next
   '' ''   Next           'For Each valores As KeyValuePair(Of String, List(Of DataRow)) In dicProduccionAGenerar
   '' ''End Sub

   Public Sub RegistraMovimientoStock(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                      idProducto As String, orden As Integer,
                                      idEstadoAnterior As String, idEstadoNuevo As String, tipoEstadoPedido As String, cantidad As Decimal,
                                      metodoGrabacion As Entidades.Entidad.MetodoGrabacion, idFuncion As String)
      Dim estadoAnterior = If(Not String.IsNullOrWhiteSpace(idEstadoAnterior), _cache.BuscaEstadosPedidoProveedores(idEstadoAnterior, tipoEstadoPedido), Nothing)
      Dim estadoNuevo = _cache.BuscaEstadosPedidoProveedores(idEstadoNuevo, tipoEstadoPedido)

      Dim idTipoMovimientoAnterior = String.Empty
      Dim stockAfectadoAnterior = String.Empty

      Dim idTipoMovimientoNuevo = estadoNuevo.IdTipoMovimiento
      Dim stockAfectadoNuevo = estadoNuevo.StockAfectado.ToString()
      If estadoAnterior IsNot Nothing Then
         idTipoMovimientoAnterior = estadoAnterior.IdTipoMovimiento
         stockAfectadoAnterior = estadoAnterior.StockAfectado.ToString()
      Else
         'Si no tengo definido EstadoAnterior (estadoAnterior IS NOTHING), viene desde la pantalla de carga de Pedido
         'Entonces dejo en blanco el Tipo de Movimiento y Stock Afectado anterior para que:
         '     - Si el nuevo tiene definido Tipo de Movimiento y Stock Afectado, al ser diferente registre el movimiento
         '     - Si el nuevo NO tiene definido Tipo de Movimiento y Stock Afectado, al ser iguales NO registre el movimiento
      End If

      'Solo debo realizar movimientos de Stock si difieren en la propiedad de IdTipoMovimiento y StockAfectado.
      'Si son iguales significa que no cambian las cantidades.
      If idTipoMovimientoAnterior <> idTipoMovimientoNuevo Or stockAfectadoAnterior <> stockAfectadoNuevo Then

         Dim movimientosAGenerar = New Dictionary(Of String, Entidades.MovimientoStock)()
         If Not String.IsNullOrWhiteSpace(idTipoMovimientoAnterior) Then
            'Instancio el Movimiento de Compra poniendo en la Observacion el motivo.
            Dim movi = New Entidades.MovimientoStock With {
               .IdSucursal = idSucursal,
               .Sucursal = _cache.BuscaSucursal(idSucursal),
               .TipoMovimiento = _cache.BuscaTipoMovimiento(idTipoMovimientoAnterior),
               .FechaMovimiento = Date.Now,
               .Usuario = actual.Nombre,
               .Observacion = String.Format("Cambio de estado de: {0} {1} {2:0000}-{3:00000000} Ln: {4}", idTipoComprobante, letra, centroEmisor, numeroPedido, orden)
            }

            movimientosAGenerar.Add(idTipoMovimientoAnterior, movi)

            'Instancio un Movimiento de Compra Producto poniendo el producto y la cantidad.
            'Multiplico por el -1 porque este es el movimiento de salida del estado anterior. (asumo que el tipo está definido positivo)
            '            moviProd.SetCantidadSegunAfecta(cantidad * -1, stockAfectadoAnterior)
            Dim moviProd = New Entidades.MovimientoStockProducto With {
               .IdSucursal = idSucursal,
               .IdProducto = idProducto,
               .Orden = movi.Productos.Count + 1
            }
            movi.Productos.Add(moviProd)
         End If

         If Not String.IsNullOrWhiteSpace(idTipoMovimientoNuevo) Then
            'Instancio el Movimiento de Compra poniendo en la Observacion el motivo.
            Dim movi As Entidades.MovimientoStock
            If Not movimientosAGenerar.ContainsKey(idTipoMovimientoNuevo) Then
               movi = New Entidades.MovimientoStock With {
                  .IdSucursal = idSucursal,
                  .Sucursal = _cache.BuscaSucursal(idSucursal),
                  .TipoMovimiento = _cache.BuscaTipoMovimiento(idTipoMovimientoNuevo),
                  .FechaMovimiento = Now,
                  .Usuario = actual.Nombre,
                  .Observacion = String.Format("Cambio de estado de: {0} {1} {2:0000}-{3:00000000} Ln: {4}", idTipoComprobante, letra, centroEmisor, numeroPedido, orden)
               }
               movimientosAGenerar.Add(idTipoMovimientoNuevo, movi)
            End If

            movi = movimientosAGenerar(idTipoMovimientoNuevo)

            'Instancio un Movimiento de Compra Producto poniendo el producto y la cantidad.
            'NO Multiplico por -1 porque este es el movimiento de entrada del estado nuevo. (asumo que el tipo está definido positivo)
            'moviProd.SetCantidadSegunAfecta(cantidad, stockAfectadoNuevo)
            Dim moviProd = New Entidades.MovimientoStockProducto With {
               .IdSucursal = idSucursal,
               .IdProducto = idProducto,
               .Orden = movi.Productos.Count + 1
            }
            movi.Productos.Add(moviProd)
         End If

         Dim rMovimientoCompra = New MovimientosStock(da)
         For Each m In movimientosAGenerar.Values
            'Grabo los movimiento de stock
            rMovimientoCompra.CargarMovimientoStock(m, metodoGrabacion, idFuncion)
         Next
      End If         'If idTipoMovimientoAnterior <> idTipoMovimientoNuevo And stockAfectadoAnterior <> stockAfectadoNuevo Then
   End Sub

   Public Sub ActualizaPedidoOrigen(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                    idProducto As String, orden As Integer, fechaEstado As Date?,
                                    idEstadoAnterior As String, idEstadoNuevo As String, tipoEstadoPedido As String,
                                    cantidad As Decimal,
                                    idResponsable As Integer, idFuncion As String)

      Dim estadoOP = _cache.BuscaEstadosPedidoProveedores(idEstadoNuevo, tipoEstadoPedido)
      If Not String.IsNullOrWhiteSpace(estadoOP.IdEstadoPedidoCliente) Then
         Dim estadoPE = _cache.BuscaEstadosPedido(estadoOP.IdEstadoPedidoCliente, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString())
         Dim rPE = New PedidosEstados(da)
         Dim sPE = New SqlServer.PedidosEstados(da)

         Using dtPE = sPE.PedidosEstados_G_PorComprobanteVinculado(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                                   idProducto, orden, fechaEstado)
            dtPE.Columns.Add("CantEntregada", GetType(Decimal))
            Dim tablagrabar = dtPE.Clone()
            For Each drPE In dtPE.AsEnumerable()
               tablagrabar.Clear()
               tablagrabar.ImportRow(drPE)
               rPE._ActualizarEstadoPedidoMasivo(estadoOP.IdEstadoPedidoCliente, Entidades.TipoComprobante.Tipos.PEDIDOSCLIE.ToString(), actual.Nombre,
                                                 String.Format("Pedido Proveedor en estado ´{0}´.", idEstadoNuevo),
                                                 drPE("IdCriticidad").ToString(), DateTime.Parse(drPE("FechaEntrega").ToString()), cantidad,
                                                 idResponsable, Nothing, tablagrabar, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)
            Next
         End Using
      End If         'If Not String.IsNullOrWhiteSpace(estadoOP.IdEstadoPedido) Then

   End Sub


   Public Function GetPedidosEstadosProveedoresUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                   idProducto As String, fechaEstado As Date, orden As Integer) As DataTable
      Dim sql = New SqlServer.PedidosEstadosProveedores(da)
      Return sql.GetPedidosEstadosProveedoresUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProducto, fechaEstado, orden)
   End Function

   Public Function GetPedidosEstadosProveedoresPorComprobanteFact(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                   idProducto As String, fechaEstado As Date, orden As Integer) As DataTable
      Dim sql = New SqlServer.PedidosEstadosProveedores(da)
      Return sql.GetPedidosEstadosProveedoresPorComprobanteFact(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProducto, fechaEstado, orden)
   End Function

   Public Function GetPedidoParaVincular(idEstado As String) As DataTable
      Dim sql = New SqlServer.PedidosEstadosProveedores(da)
      Return sql.GetPedidoParaVincular(idEstado)
   End Function

   Public Sub VincularPedidos(dtPedidos As DataTable, idFuncion As String, tipoEstadoPedidoCliente As String, tipoEstadoPedidoProveedor As String)
      Debug.Assert(dtPedidos IsNot Nothing, "dtPedidos no puede ser Nothing")

      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open

      Dim idEstadoCliente As String = Publicos.EstadoPedidoPostVinculacion
      Dim idEstadoProveedor As String = Publicos.EstadoPedidoProvPostVinculacion

      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim rPC As Reglas.Pedidos = New Pedidos(da)
         Dim rPP As Reglas.PedidosProveedores = New PedidosProveedores(da)

         Dim rPEC As Reglas.PedidosEstados = New PedidosEstados(da)
         Dim rPEP As Reglas.PedidosEstadosProveedores = New PedidosEstadosProveedores(da)

         Dim sPEC As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)

         Dim dtPEC As DataTable
         Dim dtPEP As DataTable
         Dim tipoComprobante As Entidades.TipoComprobante
         Dim fechaNuevoEstado As Date = Now
         For Each drPedido As DataRow In dtPedidos.Select("Vinculado <> ''")
            fechaNuevoEstado = fechaNuevoEstado.AddSeconds(1)
            tipoComprobante = _cache.BuscaTipoComprobante(drPedido("IdTipoComprobante").ToString())

            dtPEC = rPC.GetPedidos({New Entidades.Sucursal() With {.Id = Integer.Parse(drPedido("IdSucursal").ToString())}},
                                   "TODOS", Nothing, Nothing,
                                   Long.Parse(drPedido("NumeroPedido").ToString()),
                                   drPedido("IdProducto").ToString(),
                                   0, 0, 0, 0, 0, 0, Entidades.OrigenFK.Movimiento, 0, tipoEstadoPedidoCliente,
                                   {tipoComprobante},
                                   drPedido("Letra").ToString(),
                                   Short.Parse(drPedido("CentroEmisor").ToString()),
                                   Integer.Parse(drPedido("Orden").ToString()),
                                   DateTime.Parse(drPedido("FechaEstado").ToString()),
                                   String.Empty, Entidades.Publicos.LecturaEscrituraTodos.TODOS)

            rPEC._ActualizarEstadoPedidoMasivo(idEstadoCliente, tipoEstadoPedidoCliente, actual.Nombre,
                                               String.Format("Vinculado con {0} {1} {2:0000} {3:00000000} Ln: {4}",
                                                             drPedido("DescripcionAbrevVinculado"),
                                                             drPedido("LetraVinculado"),
                                                             drPedido("CentroEmisorVinculado"),
                                                             drPedido("NumeroPedidoVinculado"),
                                                             drPedido("OrdenVinculado")),
                                               dtPEC.Rows(0)("IdCriticidad").ToString(),
                                               DateTime.Parse(dtPEC.Rows(0)("FechaEntrega").ToString()),
                                               Decimal.Parse(drPedido("CantEstado").ToString()),
                                               0, fechaNuevoEstado, dtPEC, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

            tipoComprobante = _cache.BuscaTipoComprobante(drPedido("IdTipoComprobanteVinculado").ToString())
            dtPEP = rPP.GetPedidos(Integer.Parse(drPedido("IdSucursalVinculado").ToString()),
                                   "TODOS", Nothing, Nothing,
                                   Long.Parse(drPedido("NumeroPedidoVinculado").ToString()),
                                   drPedido("IdProductoVinculado").ToString(),
                                   0, 0, 0, 0, 0, tipoEstadoPedidoProveedor,
                                   {tipoComprobante},
                                   drPedido("LetraVinculado").ToString(),
                                   Short.Parse(drPedido("CentroEmisorVinculado").ToString()),
                                   Integer.Parse(drPedido("OrdenVinculado").ToString()),
                                   DateTime.Parse(drPedido("FechaEstadoVinculado").ToString()), seguridadRol:=Entidades.Publicos.LecturaEscrituraTodos.TODOS)

            rPEP._ActualizarEstadoPedidoProveedorMasivo(Integer.Parse(drPedido("IdSucursalVinculado").ToString()),
                                                        idEstadoProveedor, tipoEstadoPedidoProveedor, actual.Nombre,
                                                        String.Format("Vinculado con {0} {1} {2:0000} {3:00000000} Ln: {4}",
                                                                      drPedido("DescripcionAbrev"),
                                                                      drPedido("Letra"),
                                                                      drPedido("CentroEmisor"),
                                                                      drPedido("NumeroPedido"),
                                                                      drPedido("OrdenVinculado")),
                                                        dtPEP.Rows(0)("IdCriticidad").ToString(),
                                                        DateTime.Parse(dtPEP.Rows(0)("FechaEntrega").ToString()),
                                                        Decimal.Parse(drPedido("CantEstado").ToString()),
                                                        0, fechaNuevoEstado, dtPEP, generaUnPedidoPorProveedor:=False, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

            sPEC.PedidosEstados_U_Vinculado(Integer.Parse(drPedido("IdSucursal").ToString()),
                                            drPedido("IdTipoComprobante").ToString(),
                                            drPedido("Letra").ToString(),
                                            Short.Parse(drPedido("CentroEmisor").ToString()),
                                            Long.Parse(drPedido("NumeroPedido").ToString()),
                                            drPedido("IdProducto").ToString(),
                                            fechaNuevoEstado, Nothing,
                                            Integer.Parse(drPedido("Orden").ToString()),
                                            Integer.Parse(drPedido("IdSucursal").ToString()),
                                            drPedido("IdTipoComprobanteVinculado").ToString(),
                                            drPedido("LetraVinculado").ToString(),
                                            Short.Parse(drPedido("CentroEmisorVinculado").ToString()),
                                            Long.Parse(drPedido("NumeroPedidoVinculado").ToString()),
                                            drPedido("IdProductoVinculado").ToString(),
                                            Integer.Parse(drPedido("Orden").ToString()),
                                            fechaNuevoEstado)
            'fechaNuevoEstado ==> DateTime.Parse(drPedido("FechaEstado").ToString())
            'fechaNuevoEstado ==> DateTime.Parse(drPedido("FechaEstadoVinculado").ToString())
         Next              'For Each drPedido As DataRow In dtPedidos.Select("Vinculado <> ''")

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Sub DesVincularPedidos(drPedidos As DataRow(), idEstadoCliente As String, idEstadoProveedor As String, idFuncion As String)
      Debug.Assert(drPedidos IsNot Nothing, "drPedidos no puede ser Nothing")
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim rPC As Reglas.Pedidos = New Pedidos(da)
         Dim rPP As Reglas.PedidosProveedores = New PedidosProveedores(da)

         Dim rPEC As Reglas.PedidosEstados = New PedidosEstados(da)
         Dim rPEP As Reglas.PedidosEstadosProveedores = New PedidosEstadosProveedores(da)

         Dim sPEC As SqlServer.PedidosEstados = New SqlServer.PedidosEstados(da)

         Dim dtPEC As DataTable
         Dim dtPEP As DataTable
         Dim tipoComprobante As Entidades.TipoComprobante
         Dim fechaNuevoEstado As Date = Now
         Dim tipoEstadoPedidoCliente As String
         Dim tipoEstadoPedidoProveedor As String
         For Each drPedido As DataRow In drPedidos
            tipoEstadoPedidoCliente = drPedido("TipoEstadoPedido").ToString()
            tipoEstadoPedidoProveedor = drPedido("TipoEstadoPedidoVinculado").ToString()

            fechaNuevoEstado = fechaNuevoEstado.AddSeconds(1)
            tipoComprobante = _cache.BuscaTipoComprobante(drPedido("IdTipoComprobante").ToString())
            dtPEC = rPC.GetPedidos({New Entidades.Sucursal() With {.Id = Integer.Parse(drPedido("IdSucursal").ToString())}},
                                   "TODOS", Nothing, Nothing,
                                   Long.Parse(drPedido("NumeroPedido").ToString()),
                                   drPedido("IdProducto").ToString(),
                                   0, 0, 0, 0, 0, 0, Entidades.OrigenFK.Movimiento, 0, tipoEstadoPedidoCliente,
                                   {tipoComprobante},
                                   drPedido("Letra").ToString(),
                                   Short.Parse(drPedido("CentroEmisor").ToString()),
                                   Integer.Parse(drPedido("Orden").ToString()),
                                   DateTime.Parse(drPedido("FechaEstado").ToString()),
                                   String.Empty, Entidades.Publicos.LecturaEscrituraTodos.TODOS)

            rPEC._ActualizarEstadoPedidoMasivo(idEstadoCliente, tipoEstadoPedidoCliente, actual.Nombre,
                                               String.Format("Desvinculado de {0} {1} {2:0000} {3:00000000} Ln: {4}",
                                                             drPedido("DescripcionAbrevVinculado"),
                                                             drPedido("LetraVinculado"),
                                                             drPedido("CentroEmisorVinculado"),
                                                             drPedido("NumeroPedidoVinculado"),
                                                             drPedido("OrdenVinculado")),
                                               dtPEC.Rows(0)("IdCriticidad").ToString(),
                                               DateTime.Parse(dtPEC.Rows(0)("FechaEntrega").ToString()),
                                               Decimal.Parse(drPedido("CantEstado").ToString()),
                                               0, fechaNuevoEstado, dtPEC, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

            tipoComprobante = _cache.BuscaTipoComprobante(drPedido("IdTipoComprobanteVinculado").ToString())
            dtPEP = rPP.GetPedidos(Integer.Parse(drPedido("IdSucursalVinculado").ToString()),
                                   "TODOS", Nothing, Nothing,
                                   Long.Parse(drPedido("NumeroPedidoVinculado").ToString()),
                                   drPedido("IdProductoVinculado").ToString(),
                                   0, 0, 0, 0, 0, tipoEstadoPedidoProveedor,
                                   {tipoComprobante},
                                   drPedido("LetraVinculado").ToString(),
                                   Short.Parse(drPedido("CentroEmisorVinculado").ToString()),
                                   Integer.Parse(drPedido("OrdenVinculado").ToString()),
                                   DateTime.Parse(drPedido("FechaEstadoVinculado").ToString()), seguridadRol:=Entidades.Publicos.LecturaEscrituraTodos.TODOS)

            rPEP._ActualizarEstadoPedidoProveedorMasivo(Integer.Parse(drPedido("IdSucursalVinculado").ToString()),
                                                        idEstadoProveedor, tipoEstadoPedidoProveedor, actual.Nombre,
                                                        String.Format("Desvinculado de {0} {1} {2:0000} {3:00000000} Ln: {4}",
                                                                      drPedido("DescripcionAbrev"),
                                                                      drPedido("Letra"),
                                                                      drPedido("CentroEmisor"),
                                                                      drPedido("NumeroPedido"),
                                                                      drPedido("OrdenVinculado")),
                                                        dtPEP.Rows(0)("IdCriticidad").ToString(),
                                                        DateTime.Parse(dtPEP.Rows(0)("FechaEntrega").ToString()),
                                                        Decimal.Parse(drPedido("CantEstado").ToString()),
                                                        0, fechaNuevoEstado, dtPEP, generaUnPedidoPorProveedor:=False, Entidades.Entidad.MetodoGrabacion.Automatico, idFuncion)

            sPEC.PedidosEstados_U_Vinculado(Integer.Parse(drPedido("IdSucursal").ToString()),
                                            drPedido("IdTipoComprobante").ToString(),
                                            drPedido("Letra").ToString(),
                                            Short.Parse(drPedido("CentroEmisor").ToString()),
                                            Long.Parse(drPedido("NumeroPedido").ToString()),
                                            drPedido("IdProducto").ToString(),
                                            fechaNuevoEstado, Nothing,
                                            Integer.Parse(drPedido("Orden").ToString()),
                                            0,
                                            "",
                                            "",
                                            0,
                                            0,
                                            "",
                                            0,
                                            Nothing)
         Next              'For Each drPedido As DataRow In drPedidos

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

End Class