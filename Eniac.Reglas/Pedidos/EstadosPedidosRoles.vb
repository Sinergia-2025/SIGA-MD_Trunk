Public Class EstadosPedidosRoles
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("EstadosPedidosRoles", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.EstadoPedidoRol)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.EstadoPedidoRol)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.EstadoPedidoRol)))
   End Sub
   Public Overrides Function Buscar(args As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(args.Columna, args.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().EstadosPedidosRoles_GA()
   End Function
   Public Overloads Function GetAll(tipoEstadoPedido As String, idEstado As String) As DataTable
      Return GetSql().EstadosPedidosRoles_GA(tipoEstadoPedido, idEstado)
   End Function
   Public Overloads Function GetAll(idRol As String) As DataTable
      Return GetSql().EstadosPedidosRoles_GA(idRol)
   End Function
   Public Function Get1(tipoEstadoPedido As String, idEstado As String, idRol As String) As DataTable
      Return GetSql().EstadosPedidosRoles_G1(tipoEstadoPedido, idEstado, idRol)
   End Function

#End Region

#Region "Metodos Privados"

   Private Function GetSql() As SqlServer.EstadosPedidosRoles
      Return New SqlServer.EstadosPedidosRoles(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.EstadoPedidoRol, tipo As TipoSP)
      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            sql.EstadosPedidosRoles_I(en.TipoEstadoPedido, en.IdEstado, en.IdRol, en.PermitirEscritura)
         Case TipoSP._U
            sql.EstadosPedidosRoles_U(en.TipoEstadoPedido, en.IdEstado, en.IdRol, en.PermitirEscritura)
         Case TipoSP._D
            sql.EstadosPedidosRoles_D(en.TipoEstadoPedido, en.IdEstado, en.IdRol)
      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.EstadoPedidoRol, dr As DataRow)
      With o
         .TipoEstadoPedido = dr.Field(Of String)(Entidades.EstadoPedidoRol.Columnas.TipoEstadoPedido.ToString())
         .IdEstado = dr.Field(Of String)(Entidades.EstadoPedidoRol.Columnas.IdEstado.ToString())
         .Rol = New Roles(da).GetUno(dr.Field(Of String)(Entidades.EstadoPedidoRol.Columnas.IdRol.ToString()))
         .PermitirEscritura = dr.Field(Of Boolean)(Entidades.EstadoPedidoRol.Columnas.PermitirEscritura.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.EstadoPedidoRol)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.EstadoPedidoRol)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.EstadoPedidoRol)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.EstadoPedido)
      entidad.Roles.ForEach(
         Sub(en)
            en.TipoEstadoPedido = entidad.TipoEstadoPedido
            en.IdEstado = entidad.IdEstado
            _Insertar(en)
         End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.EstadoPedido)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.EstadoPedido)
      _Borrar(New Entidades.EstadoPedidoRol() With
               {
                  .TipoEstadoPedido = entidad.TipoEstadoPedido,
                  .IdEstado = entidad.IdEstado
               })
   End Sub

   Public Function GetTodos(tipoEstadoPedido As String, idEstado As String) As List(Of Entidades.EstadoPedidoRol)
      Return CargaLista(GetAll(tipoEstadoPedido, idEstado),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoRol())
   End Function
   Public Function GetTodos(tipoEstadoPedido As String) As List(Of Entidades.EstadoPedidoRol)
      Return CargaLista(GetAll(tipoEstadoPedido),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoRol())
   End Function
   Public Function GetTodos() As List(Of Entidades.EstadoPedidoRol)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoRol())
   End Function
   Public Function GetUno(tipoEstadoPedido As String, idEstado As String, idRol As String) As Entidades.EstadoPedidoRol
      Return GetUno(tipoEstadoPedido, idEstado, idRol, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(tipoEstadoPedido As String, idEstado As String, idRol As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoPedidoRol
      Return CargaEntidad(Get1(tipoEstadoPedido, idEstado, idRol),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoRol(),
                          accion, Function() String.Format("No existe rol {2} para el estado {1} del tipo {0}",
                                                           tipoEstadoPedido, idEstado, idRol))
   End Function
#End Region
End Class