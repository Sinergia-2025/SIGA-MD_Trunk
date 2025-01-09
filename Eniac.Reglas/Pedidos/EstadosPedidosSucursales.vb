Imports Eniac.Entidades

Public Class EstadosPedidosSucursales
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.EstadoPedidoSucursal.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoPedidoSucursal), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoPedidoSucursal), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoPedidoSucursal), TipoSP._D))
   End Sub

   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(NewEntidad(entidad), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(NewEntidad(entidad), TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(NewEntidad(entidad), TipoSP._D)
   End Sub

   Public Sub _Merge(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(NewEntidad(entidad), TipoSP._M)
   End Sub

   Private Function NewEntidad(entidad As Eniac.Entidades.Entidad) As Entidades.EstadoPedidoSucursal
      Dim eEPedSuc = New Entidades.EstadoPedidoSucursal
      With eEPedSuc
         .IdEstado = DirectCast(entidad, Entidades.EstadoPedido).IdEstado
         .TipoEstadoPedido = DirectCast(entidad, Entidades.EstadoPedido).TipoEstadoPedido
         .IdSucursal = DirectCast(entidad, Entidades.EstadoPedido).IdSucursal
         .IdDeposito = DirectCast(entidad, Entidades.EstadoPedido).IdDeposito
         .IdUbicacion = DirectCast(entidad, Entidades.EstadoPedido).IdUbicacion
      End With
      Return eEPedSuc
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosPedidosSucursales(Me.da).EstadosPedidosSucursales_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.EstadoPedidoSucursal, tipo As TipoSP)
      Dim sqlC = New SqlServer.EstadosPedidosSucursales(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.EstadosPedidosSucursales_I(en.IdEstado, en.TipoEstadoPedido, en.IdSucursal, en.IdDeposito, en.IdUbicacion)
         Case TipoSP._U
            sqlC.EstadosPedidosSucursales_U(en.IdEstado, en.TipoEstadoPedido, en.IdSucursal, en.IdDeposito, en.IdUbicacion)
         Case TipoSP._M
            sqlC.EstadosPedidosSucursales_M(en.IdEstado, en.TipoEstadoPedido, en.IdSucursal, en.IdDeposito, en.IdUbicacion)
         Case TipoSP._D
            sqlC.EstadosPedidosSucursales_D(en.IdEstado, en.TipoEstadoPedido, en.IdSucursal)
      End Select

   End Sub
   Private Sub CargarUno(o As Entidades.EstadoPedidoSucursal, dr As DataRow)
      With o
         .IdEstado = dr.Field(Of String)(Entidades.EstadoPedidoSucursal.Columnas.IdEstado.ToString())
         .TipoEstadoPedido = dr.Field(Of String)(Entidades.EstadoPedidoSucursal.Columnas.TipoEstadoPedido.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.EstadoPedidoSucursal.Columnas.IdSucursal.ToString())
         .IdDeposito = dr.Field(Of Integer)(Entidades.EstadoPedidoSucursal.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.EstadoPedidoSucursal.Columnas.IdUbicacion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idEstado As String, tipoEstadoPedido As String, idSucursal As Integer) As Entidades.EstadoPedidoSucursal
      Return GetUno(idEstado, tipoEstadoPedido, idSucursal, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstado As String, tipoEstadoPedido As String, idSucursal As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.EstadoPedidoSucursal
      Return CargaEntidad(New SqlServer.EstadosPedidosSucursales(Me.da).EstadosPedidosSucursales_G(idEstado, tipoEstadoPedido, idSucursal),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.EstadoPedidoSucursal(),
                          accion, Function() String.Format("No existe EstadoPedidoSucursal({0})", idSucursal))
   End Function
   Public Function GetTodos() As List(Of Entidades.EstadoPedidoSucursal)
      Return CargaLista(New SqlServer.EstadosPedidosSucursales(Me.da).EstadosPedidosSucursales_GA(),
                      Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.EstadoPedidoSucursal())
   End Function

   Public Function ValidaEstadosPedidosSucursalesDepositos(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.EstadosPedidosSucursales(da).GetCantidadSucursalesDepositos(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function

#End Region

End Class
