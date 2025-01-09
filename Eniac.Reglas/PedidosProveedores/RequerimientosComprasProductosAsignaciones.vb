Public Class RequerimientosComprasProductosAsignaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.RequerimientoCompraProductoAsignacion.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RequerimientoCompraProductoAsignacion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RequerimientoCompraProductoAsignacion)))
   End Sub
   Public Sub Merge(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.RequerimientoCompraProductoAsignacion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RequerimientoCompraProductoAsignacion)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.RequerimientosComprasProductosAsignaciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.RequerimientosComprasProductosAsignaciones(da).RequerimientosComprasProductosAsignaciones_GA()
   End Function
   Public Overloads Function GetAll(idRequerimientoCompra As Long, idProducto As String, orden As Integer) As DataTable
      Return New SqlServer.RequerimientosComprasProductosAsignaciones(da).RequerimientosComprasProductosAsignaciones_GA(idRequerimientoCompra, idProducto, orden)
   End Function
   Public Function GetAllPorAsignacion(idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long) As DataTable
      Return New SqlServer.RequerimientosComprasProductosAsignaciones(da).RequerimientosComprasProductosAsignaciones_GA(idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.RequerimientoCompraProductoAsignacion, tipo As TipoSP)
      Dim sql = New SqlServer.RequerimientosComprasProductosAsignaciones(da)
      Select Case tipo
         Case TipoSP._I
            sql.RequerimientosComprasProductosAsignaciones_I(en.IdRequerimientoCompra, en.IdProducto, en.Orden,
                                                             en.IdSucursalPedido, en.IdTipoComprobantePedido, en.LetraPedido, en.CentroEmisorPedido, en.NumeroPedido,
                                                             en.Cantidad,
                                                             en.FechaAsignacion, en.IdUsuarioAsignacion)
         Case TipoSP._U
            sql.RequerimientosComprasProductosAsignaciones_U(en.IdRequerimientoCompra, en.IdProducto, en.Orden,
                                                             en.IdSucursalPedido, en.IdTipoComprobantePedido, en.LetraPedido, en.CentroEmisorPedido, en.NumeroPedido,
                                                             en.Cantidad,
                                                             en.FechaAsignacion, en.IdUsuarioAsignacion)
         Case TipoSP._M
            sql.RequerimientosComprasProductosAsignaciones_M(en.IdRequerimientoCompra, en.IdProducto, en.Orden,
                                                             en.IdSucursalPedido, en.IdTipoComprobantePedido, en.LetraPedido, en.CentroEmisorPedido, en.NumeroPedido,
                                                             en.Cantidad,
                                                             en.FechaAsignacion, en.IdUsuarioAsignacion)
         Case TipoSP._D
            sql.RequerimientosComprasProductosAsignaciones_D(en.IdRequerimientoCompra, en.IdProducto, en.Orden,
                                                             en.IdSucursalPedido, en.IdTipoComprobantePedido, en.LetraPedido, en.CentroEmisorPedido, en.NumeroPedido)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RequerimientoCompraProductoAsignacion, dr As DataRow)
      With o
         .IdRequerimientoCompra = dr.Field(Of Long)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdRequerimientoCompra.ToString())

         .IdProducto = dr.Field(Of String)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdProducto.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.Orden.ToString())


         .IdSucursalPedido = dr.Field(Of Integer)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdSucursalPedido.ToString())
         .IdTipoComprobantePedido = dr.Field(Of String)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdTipoComprobantePedido.ToString())
         .LetraPedido = dr.Field(Of String)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.LetraPedido.ToString())
         .CentroEmisorPedido = dr.Field(Of Integer)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.CentroEmisorPedido.ToString())
         .NumeroPedido = dr.Field(Of Long)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.NumeroPedido.ToString())

         .Cantidad = dr.Field(Of Decimal)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.Cantidad.ToString())
         .FechaAsignacion = dr.Field(Of Date)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.FechaAsignacion.ToString())
         .IdUsuarioAsignacion = dr.Field(Of String)(Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdUsuarioAsignacion.ToString())

      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.RequerimientoCompraProductoAsignacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.RequerimientoCompraProductoAsignacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Merge(entidad As Entidades.RequerimientoCompraProductoAsignacion)
      EjecutaSP(entidad, TipoSP._M)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RequerimientoCompraProductoAsignacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.RequerimientoCompraProducto)
      entidad.Asignaciones.ForEach(
      Sub(en)
         en.IdRequerimientoCompra = entidad.IdRequerimientoCompra
         en.IdProducto = entidad.IdProducto
         en.Orden = entidad.Orden
         _Insertar(en)
      End Sub)
   End Sub
   Public Sub _Insertar(asignaciones As List(Of Entidades.RequerimientoCompraProductoAsignacion))
      asignaciones.ForEach(
      Sub(en)
         _Insertar(en)
      End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.RequerimientoCompraProducto)
      entidad.Asignaciones.ForEach(
      Sub(en)
         _Merge(en)
      End Sub)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RequerimientoCompraProducto)
      _Borrar(New Entidades.RequerimientoCompraProductoAsignacion() With {.IdRequerimientoCompra = entidad.IdRequerimientoCompra, .IdProducto = entidad.IdProducto, .Orden = entidad.Orden})
   End Sub

   Public Function Get1(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                        idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long) As DataTable
      Return New SqlServer.RequerimientosComprasProductosAsignaciones(da).
                     RequerimientosComprasProductosAsignaciones_G1(idRequerimientoCompra, idProducto, orden,
                                                                   idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido)
   End Function
   Public Function GetUno(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                          idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long) As Entidades.RequerimientoCompraProductoAsignacion
      Return GetUno(idRequerimientoCompra, idProducto, orden,
                    idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido,
                    AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                          idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long, accion As AccionesSiNoExisteRegistro) As Entidades.RequerimientoCompraProductoAsignacion
      Return CargaEntidad(Get1(idRequerimientoCompra, idProducto, orden,
                               idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RequerimientoCompraProductoAsignacion(),
                          accion, Function() String.Format("No existe el Asignacion de Requerimiento de Compra con Id {0} Producto {1} orden {2} Pedido {3}.{4} {5} {6:0000}-{7:00000000}.",
                                                           idRequerimientoCompra, idProducto, orden,
                                                           idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido))
   End Function

   Public Function GetTodos(idRequerimientoCompra As Long, idProducto As String, orden As Integer) As List(Of Entidades.RequerimientoCompraProductoAsignacion)
      Return CargaLista(GetAll(idRequerimientoCompra, idProducto, orden), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RequerimientoCompraProductoAsignacion())
   End Function

   Public Function GetTodosPorAsignacion(idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long) As List(Of Entidades.RequerimientoCompraProductoAsignacion)
      Return CargaLista(GetAllPorAsignacion(idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RequerimientoCompraProductoAsignacion())
   End Function

#End Region

End Class