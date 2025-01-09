Public Class EstadosPedidosProveedores
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("EstadosPedidosProveedores", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.EstadoPedidoProveedor)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.EstadoPedidoProveedor)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.EstadoPedidoProveedor)))
   End Sub

   <Obsolete("Usar Buscar(Eniac.Entidades.Buscar, String)", True)>
   Public Overrides Function Buscar(args As Entidades.Buscar) As DataTable
      Throw New NotImplementedException()
   End Function
   Public Overloads Function Buscar(entidad As Entidades.Buscar, TipoEstadoPedido As String) As DataTable
      Return New SqlServer.EstadosPedidosProveedores(da).Buscar(entidad.Columna, entidad.Valor.ToString(), TipoEstadoPedido)
   End Function
   <Obsolete("Usar GetAll(String)", True)>
   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException()
   End Function
   Public Overloads Function GetAll(tipoEstadoPedido As String) As DataTable
      Return GetAll(tipoEstadoPedido, Entidades.Publicos.LecturaEscrituraTodos.TODOS, activos:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Overloads Function GetAll(tipoEstadoPedido As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos, activos As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.EstadosPedidosProveedores(da).EstadosPedidosProveedores_GA(tipoEstadoPedido, False, String.Empty, seguridadRol, activos, facturable:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Overloads Function GetAll(tipoEstadoPedido As String, todos As Boolean) As DataTable
      Return New SqlServer.EstadosPedidosProveedores(da).EstadosPedidosProveedores_GA(tipoEstadoPedido, todos, String.Empty, Entidades.Publicos.LecturaEscrituraTodos.TODOS, activos:=Entidades.Publicos.SiNoTodos.TODOS, facturable:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Function GetPorTipoComprobanteGenerado(idTipoComprobante As String) As List(Of Entidades.EstadoPedidoProveedor)
      Return CargaLista(New SqlServer.EstadosPedidosProveedores(da).EstadosPedidosProveedores_GA(String.Empty, False, idTipoComprobante, seguridadRol:=Entidades.Publicos.LecturaEscrituraTodos.TODOS, activos:=Entidades.Publicos.SiNoTodos.TODOS, facturable:=Entidades.Publicos.SiNoTodos.TODOS),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoProveedor())
   End Function
   Public Function GetEstados(agregarTODOS As Boolean, agregarSOLOPendientes As Boolean,
                              agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean, agregarEstadosPendientes As Boolean,
                              tipoEstadoPedido As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Dim sql = New SqlServer.EstadosPedidosProveedores(da)
      Return sql.GetEstados(agregarTODOS, agregarSOLOPendientes, agregarSOLOEnProceso, agregarAnulado, agregarEstadosPendientes, tipoEstadoPedido, seguridadRol)
   End Function
   Public Function GetEstadosCalidad(AgregarTODOS As Boolean, AgregarSOLOPendientes As Boolean,
                                     AgregarSOLOEnProceso As Boolean, AgregarAnulado As Boolean, AgregarEstadosPendientes As Boolean,
                                     TipoEstadoPedido As String) As DataTable
      Dim sql = New SqlServer.EstadosPedidosProveedores(da)
      Return sql.GetEstadosCalidad(AgregarTODOS, AgregarSOLOPendientes, AgregarSOLOEnProceso, AgregarAnulado, AgregarEstadosPendientes, TipoEstadoPedido)
   End Function
   Public Function GetTiposEstados(TipoEstadoPedido As String) As DataTable
      Dim sql = New SqlServer.EstadosPedidosProveedores(da)
      Return sql.GetTiposEstados(TipoEstadoPedido)
   End Function
   Public Function GetIdEstadosXTipo(tipo As String, TipoEstadoPedido As String) As DataTable
      Dim sql = New SqlServer.EstadosPedidosProveedores(da)
      Return sql.GetIdEstadosXTipo(tipo, TipoEstadoPedido)
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.EstadoPedidoProveedor, tipo As TipoSP)
      Dim sql = New SqlServer.EstadosPedidosProveedores(da)
      Dim rRoles = New EstadosPedidosProveedoresRoles(da)

      If tipo <> TipoSP._D AndAlso Not String.IsNullOrWhiteSpace(en.IdEstadoFacturado) Then
         Dim dtEstadosFacturables = sql.EstadosPedidosProveedores_GA_Facturable(en.TipoEstadoPedido)
         Dim drEstadosFacturables = dtEstadosFacturables.FirstOrDefault()
         If drEstadosFacturables IsNot Nothing AndAlso drEstadosFacturables.Field(Of String)(Entidades.EstadoPedidoProveedor.Columnas.IdEstado.ToString()) <> en.IdEstado Then
            Throw New Exception(String.Format("Ya existe un estado con un Estado Pedido Facturado ({0}). No puede haber más de un Estado con esta configuración.",
                                              drEstadosFacturables.Field(Of String)(Entidades.EstadoPedidoProveedor.Columnas.IdEstado.ToString())))
         End If
      End If

      Select Case tipo
         Case TipoSP._I
            sql.EstadosPedidosProveedores_I(en.IdEstado, en.IdTipoComprobante, en.IdTipoEstado, en.Orden, en.TipoEstadoPedido, en.Color,
                                            en.TipoEstadoPedidoCliente, en.IdEstadoPedidoCliente, en.IdTipoMovimiento, en.StockAfectado.ToString(),
                                            en.IdEstadoDestino, en.IdEstadoFacturado, en.GeneraDeclaracionProduccion)
            rRoles._Insertar(en)
         Case TipoSP._U
            sql.EstadosPedidosProveedores_U(en.IdEstado, en.IdTipoComprobante, en.IdTipoEstado, en.Orden, en.TipoEstadoPedido, en.Color,
                                            en.TipoEstadoPedidoCliente, en.IdEstadoPedidoCliente, en.IdTipoMovimiento, en.StockAfectado.ToString(),
                                            en.IdEstadoDestino, en.IdEstadoFacturado, en.GeneraDeclaracionProduccion)
            rRoles._Actualizar(en)
         Case TipoSP._D
            rRoles._Borrar(en)
            sql.EstadosPedidosProveedores_D(en.IdEstado, en.TipoEstadoPedido)
      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.EstadoPedidoProveedor, dr As DataRow)
      With o
         .IdEstado = dr(Entidades.EstadoPedidoProveedor.Columnas.IdEstado.ToString()).ToString()
         .IdTipoComprobante = dr(Entidades.EstadoPedidoProveedor.Columnas.idTipoComprobante.ToString()).ToString()
         .IdTipoEstado = dr(Entidades.EstadoPedidoProveedor.Columnas.IdTipoEstado.ToString()).ToString()
         .Orden = Integer.Parse(dr(Entidades.EstadoPedidoProveedor.Columnas.Orden.ToString()).ToString())
         .TipoEstadoPedido = dr(Entidades.EstadoPedidoProveedor.Columnas.TipoEstadoPedido.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.EstadoPedidoProveedor.Columnas.Color.ToString()).ToString()) Then
            .Color = Integer.Parse(dr(Entidades.EstadoPedidoProveedor.Columnas.Color.ToString()).ToString())
         Else
            .Color = 0
         End If

         .TipoEstadoPedidoCliente = dr(Entidades.EstadoPedidoProveedor.Columnas.TipoEstadoPedidoCliente.ToString()).ToString()
         .IdEstadoPedidoCliente = dr(Entidades.EstadoPedidoProveedor.Columnas.IdEstadoPedidoCliente.ToString()).ToString()

         .IdTipoMovimiento = dr(Entidades.EstadoPedidoProveedor.Columnas.IdTipoMovimiento.ToString()).ToString()
         If Not String.IsNullOrWhiteSpace(dr(Entidades.EstadoPedidoProveedor.Columnas.StockAfectado.ToString()).ToString()) Then
            .StockAfectado = DirectCast([Enum].Parse(GetType(Entidades.MovimientoStockProducto.Afecta),
                                                     dr(Entidades.EstadoPedidoProveedor.Columnas.StockAfectado.ToString()).ToString()),
                                        Entidades.MovimientoStockProducto.Afecta)
         End If
         .IdEstadoDestino = dr(Entidades.EstadoPedidoProveedor.Columnas.IdEstadoDestino.ToString()).ToString()
         .IdEstadoFacturado = dr.Field(Of String)(Entidades.EstadoPedidoProveedor.Columnas.IdEstadoFacturado.ToString())

         .GeneraDeclaracionProduccion = Boolean.Parse(dr("GeneraDeclaracionProduccion").ToString())
         .Roles = New EstadosPedidosProveedoresRoles(da).GetTodos(.TipoEstadoPedido, .IdEstado)
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.EstadoPedidoProveedor)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.EstadoPedidoProveedor)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.EstadoPedidoProveedor)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetTodos(TipoEstadoPedido As String) As List(Of Entidades.EstadoPedidoProveedor)
      Return CargaLista(GetAll(TipoEstadoPedido),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoProveedor())
   End Function

   Public Function GetUno(IdEstado As String, TipoEstadoPedido As String) As Entidades.EstadoPedidoProveedor
      Return GetUno(IdEstado, TipoEstadoPedido, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(IdEstado As String, TipoEstadoPedido As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoPedidoProveedor
      Return CargaEntidad(New SqlServer.EstadosPedidosProveedores(da).EstadosPedidosProveedores_G1(IdEstado, TipoEstadoPedido),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoProveedor(),
                          accion, Function() String.Format("No existe el Estado {0} para el Tipo {1}.", IdEstado, TipoEstadoPedido))
   End Function
   Public Function Get1(IdEstado As String, TipoEstadoPedido As String) As DataTable
      Return New SqlServer.EstadosPedidosProveedores(da).EstadosPedidosProveedores_G1(IdEstado, TipoEstadoPedido)
   End Function
   Public Function GetPorNombre(IdEstado As String, TipoEstadoPedido As String) As DataTable
      Return New SqlServer.EstadosPedidosProveedores(da).GetPorNombre(IdEstado, TipoEstadoPedido)
   End Function

#End Region

End Class