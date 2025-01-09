Public Class EstadosPedidosProveedoresRoles
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("EstadosPedidosProveedoresRoles", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.EstadoPedidoProveedorRol)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.EstadoPedidoProveedorRol)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.EstadoPedidoProveedorRol)))
   End Sub
   Public Overrides Function Buscar(args As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(args.Columna, args.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().EstadosPedidosProveedoresRoles_GA()
   End Function
   Public Overloads Function GetAll(tipoEstadoPedido As String, idEstado As String) As DataTable
      Return GetSql().EstadosPedidosProveedoresRoles_GA(tipoEstadoPedido, idEstado)
   End Function
   Public Overloads Function GetAll(idRol As String) As DataTable
      Return GetSql().EstadosPedidosProveedoresRoles_GA(idRol)
   End Function
   Public Function Get1(tipoEstadoPedido As String, idEstado As String, idRol As String) As DataTable
      Return GetSql().EstadosPedidosProveedoresRoles_G1(tipoEstadoPedido, idEstado, idRol)
   End Function

#End Region

#Region "Metodos Privados"

   Private Function GetSql() As SqlServer.EstadosPedidosProveedoresRoles
      Return New SqlServer.EstadosPedidosProveedoresRoles(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.EstadoPedidoProveedorRol, tipo As TipoSP)
      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            sql.EstadosPedidosProveedoresRoles_I(en.TipoEstadoPedido, en.IdEstado, en.IdRol, en.PermitirEscritura)
         Case TipoSP._U
            sql.EstadosPedidosProveedoresRoles_U(en.TipoEstadoPedido, en.IdEstado, en.IdRol, en.PermitirEscritura)
         Case TipoSP._D
            sql.EstadosPedidosProveedoresRoles_D(en.TipoEstadoPedido, en.IdEstado, en.IdRol)
      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.EstadoPedidoProveedorRol, dr As DataRow)
      With o
         .TipoEstadoPedido = dr.Field(Of String)(Entidades.EstadoPedidoProveedorRol.Columnas.TipoEstadoPedido.ToString())
         .IdEstado = dr.Field(Of String)(Entidades.EstadoPedidoProveedorRol.Columnas.IdEstado.ToString())
         .Rol = New Roles(da).GetUno(dr.Field(Of String)(Entidades.EstadoPedidoProveedorRol.Columnas.IdRol.ToString()))
         .PermitirEscritura = dr.Field(Of Boolean)(Entidades.EstadoPedidoProveedorRol.Columnas.PermitirEscritura.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.EstadoPedidoProveedorRol)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.EstadoPedidoProveedorRol)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.EstadoPedidoProveedorRol)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.EstadoPedidoProveedor)
      entidad.Roles.ForEach(
         Sub(en)
            en.TipoEstadoPedido = entidad.TipoEstadoPedido
            en.IdEstado = entidad.IdEstado
            _Insertar(en)
         End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.EstadoPedidoProveedor)
      _Borrar(entidad)
      _Insertar (entidad )
   End Sub
   Public Sub _Borrar(entidad As Entidades.EstadoPedidoProveedor)
      _Borrar(New Entidades.EstadoPedidoProveedorRol() With
               {
                  .TipoEstadoPedido = entidad.TipoEstadoPedido,
                  .IdEstado = entidad.IdEstado
               })
   End Sub

   Public Function GetTodos(tipoEstadoPedido As String, idEstado As String) As List(Of Entidades.EstadoPedidoProveedorRol)
      Return CargaLista(GetAll(tipoEstadoPedido, idEstado),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoProveedorRol())
   End Function
   Public Function GetTodos(tipoEstadoPedido As String) As List(Of Entidades.EstadoPedidoProveedorRol)
      Return CargaLista(GetAll(tipoEstadoPedido),
                        Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoProveedorRol())
   End Function
   Public Function GetTodos() As List(Of Entidades.EstadoPedidoProveedorRol)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoProveedorRol())
   End Function
   Public Function GetUno(tipoEstadoPedido As String, idEstado As String, idRol As String) As Entidades.EstadoPedidoProveedorRol
      Return GetUno(tipoEstadoPedido, idEstado, idRol, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(tipoEstadoPedido As String, idEstado As String, idRol As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoPedidoProveedorRol
      Return CargaEntidad(Get1(tipoEstadoPedido, idEstado, idRol),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.EstadoPedidoProveedorRol(),
                          accion, Function() String.Format("No existe rol {2} para el estado {1} del tipo {0}",
                                                           tipoEstadoPedido, idEstado, idRol))
   End Function
#End Region
End Class