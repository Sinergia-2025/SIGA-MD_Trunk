Public Class EstadosPedidos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("EstadosPedidos", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.EstadoPedido)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.EstadoPedido)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.EstadoPedido)))
   End Sub

   <Obsolete("Usar Buscar(Eniac.Entidades.Buscar, String)", True)>
   Public Overrides Function Buscar(args As Entidades.Buscar) As DataTable
      Throw New NotImplementedException()
   End Function
   Public Overloads Function Buscar(entidad As Entidades.Buscar, TipoEstadoPedido As String) As DataTable
      Return New SqlServer.EstadosPedidos(da).Buscar(entidad.Columna, entidad.Valor.ToString(), TipoEstadoPedido)
   End Function

   <Obsolete("Usar GetAll(String)", True)>
   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException()
   End Function

   Public Overloads Function GetAll(TipoEstadoPedido As String) As DataTable
      Return GetAll(TipoEstadoPedido, Entidades.Publicos.LecturaEscrituraTodos.TODOS, activos:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Overloads Function GetAll(TipoEstadoPedido As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos, activos As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.EstadosPedidos(da).EstadosPedidos_GA(TipoEstadoPedido, False, String.Empty, seguridadRol, activos)
   End Function

   Public Overloads Function GetAll(TipoEstadoPedido As String, todos As Boolean) As DataTable
      Return New SqlServer.EstadosPedidos(da).EstadosPedidos_GA(TipoEstadoPedido, todos, String.Empty, Entidades.Publicos.LecturaEscrituraTodos.TODOS, activos:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Function GetPorTipoComprobanteGenerado(idTipoComprobante As String) As List(Of Entidades.EstadoPedido)
      Return CargaLista(New SqlServer.EstadosPedidos(da).EstadosPedidos_GA(String.Empty, False, idTipoComprobante, Entidades.Publicos.LecturaEscrituraTodos.TODOS, activos:=Entidades.Publicos.SiNoTodos.TODOS),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedido())
   End Function

   Public Function GetEstados(agregarTODOS As Boolean, agregarSOLOPendientes As Boolean,
                              agregarSOLOEnProceso As Boolean, agregarAnulado As Boolean, agregarEstadosPendientes As Boolean,
                              tipoEstadoPedido As String, seguridadRol As Entidades.Publicos.LecturaEscrituraTodos) As DataTable
      Return New SqlServer.EstadosPedidos(da).GetEstados(agregarTODOS, agregarSOLOPendientes, agregarSOLOEnProceso, agregarAnulado, agregarEstadosPendientes, tipoEstadoPedido, seguridadRol)
   End Function

   Public Function GetTiposEstados(TipoEstadoPedido As String) As DataTable
      Return New SqlServer.EstadosPedidos(da).GetTiposEstados(TipoEstadoPedido)
   End Function

   Public Function GetIdEstadosXTipo(tipo As String, TipoEstadoPedido As String) As DataTable
      Return New SqlServer.EstadosPedidos(da).GetIdEstadosXTipo(tipo, TipoEstadoPedido)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.EstadoPedido, tipo As TipoSP)
      Dim sql = New SqlServer.EstadosPedidos(da)
      Dim rSuc = New Reglas.EstadosPedidosSucursales(da)
      Dim rRoles = New EstadosPedidosRoles(da)

      Select Case tipo
         Case TipoSP._I
            sql.EstadosPedidos_I(en.IdEstado, en.IdTipoComprobante, en.IdTipoEstado, en.Orden, en.AfectaPendiente, en.TipoEstadoPedido, en.Color, en.ReservaStock,
                                 en.Divide, en.IdEstadoDivideA, en.IdEstadoDivideB, en.PorcDivideA, en.PorcDivideB, en.SolicitaSucursalParaTipoComprobante)
            '-- Incorpora Estado Pedidos Sucursales.-
            rSuc._Merge(en)
            rRoles._Insertar(en)
         Case TipoSP._U
            sql.EstadosPedidos_U(en.IdEstado, en.IdTipoComprobante, en.IdTipoEstado, en.Orden, en.AfectaPendiente, en.TipoEstadoPedido, en.Color, en.ReservaStock,
                                 en.Divide, en.IdEstadoDivideA, en.IdEstadoDivideB, en.PorcDivideA, en.PorcDivideB, en.SolicitaSucursalParaTipoComprobante)
            '-- Modifica Estado Pedidos Sucursales.-
            rSuc._Merge(en)
            rRoles._Actualizar(en)
         Case TipoSP._D
            rRoles._Borrar(en)
            sql.EstadosPedidos_D(en.IdEstado, en.TipoEstadoPedido)
            '-- Elimina Estado Pedidos Sucursales.-
            rSuc._Borrar(en)
      End Select
   End Sub

   Private Sub CargarUna(o As Entidades.EstadoPedido, dr As DataRow)
      With o
         .IdEstado = dr(Entidades.EstadoPedido.Columnas.IdEstado.ToString()).ToString()
         .IdTipoComprobante = dr(Entidades.EstadoPedido.Columnas.idTipoComprobante.ToString()).ToString()
         .IdTipoEstado = dr(Entidades.EstadoPedido.Columnas.IdTipoEstado.ToString()).ToString()
         .Orden = Integer.Parse(dr(Entidades.EstadoPedido.Columnas.Orden.ToString()).ToString())
         .AfectaPendiente = Boolean.Parse(CStr(dr(Entidades.EstadoPedido.Columnas.AfectaPendiente.ToString())))
         .TipoEstadoPedido = dr(Entidades.EstadoPedido.Columnas.TipoEstadoPedido.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.EstadoPedido.Columnas.Color.ToString()).ToString()) Then
            .Color = Integer.Parse(dr(Entidades.EstadoPedido.Columnas.Color.ToString()).ToString())
         Else
            .Color = 0
         End If
         .ReservaStock = Boolean.Parse(dr(Entidades.EstadoPedido.Columnas.ReservaStock.ToString()).ToString())

         .Divide = Boolean.Parse(dr(Entidades.EstadoPedido.Columnas.Divide.ToString()).ToString())
         .IdEstadoDivideA = dr(Entidades.EstadoPedido.Columnas.IdEstadoDivideA.ToString()).ToString()
         .IdEstadoDivideB = dr(Entidades.EstadoPedido.Columnas.IdEstadoDivideB.ToString()).ToString()
         .PorcDivideA = Decimal.Parse(dr(Entidades.EstadoPedido.Columnas.PorcDivideA.ToString()).ToString())
         .PorcDivideB = Decimal.Parse(dr(Entidades.EstadoPedido.Columnas.PorcDivideB.ToString()).ToString())
         .SolicitaSucursalParaTipoComprobante = Boolean.Parse(dr(Entidades.EstadoPedido.Columnas.SolicitaSucursalParaTipoComprobante.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.EstadoPedido.Columnas.IdDeposito.ToString()).ToString()) Then
            .IdDeposito = Integer.Parse(dr(Entidades.EstadoPedido.Columnas.IdDeposito.ToString()).ToString())
            .IdUbicacion = Integer.Parse(dr(Entidades.EstadoPedido.Columnas.IdUbicacion.ToString()).ToString())
         End If

         .Roles = New EstadosPedidosRoles(da).GetTodos(.TipoEstadoPedido, .IdEstado)
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Insertar(entidad As Entidades.EstadoPedido)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.EstadoPedido)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.EstadoPedido)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetTodos(TipoEstadoPedido As String) As List(Of Entidades.EstadoPedido)
      Return CargaLista(GetAll(TipoEstadoPedido), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedido())
   End Function

   Public Function GetUno(IdEstado As String, TipoEstadoPedido As String) As Entidades.EstadoPedido
      Return GetUno(IdEstado, TipoEstadoPedido, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetUno(IdEstado As String, TipoEstadoPedido As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoPedido
      Return CargaEntidad(Get1(IdEstado, TipoEstadoPedido), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedido(),
                          accion, Function() String.Format("No existe el Estado ´{0}´.", IdEstado))
   End Function

   Public Function Get1(IdEstado As String, TipoEstadoPedido As String) As DataTable
      Return New SqlServer.EstadosPedidos(da).EstadosPedidos_G1(IdEstado, TipoEstadoPedido)
   End Function

   Public Function GetPorNombre(IdEstado As String, TipoEstadoPedido As String) As DataTable
      Return New SqlServer.EstadosPedidos(da).GetPorNombre(IdEstado, TipoEstadoPedido)
   End Function

#End Region

End Class