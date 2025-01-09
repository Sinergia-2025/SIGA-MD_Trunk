Imports Eniac.Entidades
Public Class EstadosOrdenesProduccionSucursales
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.EstadoOrdenProduccionSucursal.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoOrdenProduccionSucursal), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoOrdenProduccionSucursal), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoOrdenProduccionSucursal), TipoSP._D))
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

   Private Function NewEntidad(entidad As Eniac.Entidades.Entidad) As Entidades.EstadoOrdenProduccionSucursal
      Dim eEOPSuc = New Entidades.EstadoOrdenProduccionSucursal
      With eEOPSuc
         .IdEstado = DirectCast(entidad, Entidades.EstadoOrdenProduccion).IdEstado
         .IdSucursal = DirectCast(entidad, Entidades.EstadoOrdenProduccion).IdSucursal
         .IdDeposito = DirectCast(entidad, Entidades.EstadoOrdenProduccion).IdDeposito
         .IdUbicacion = DirectCast(entidad, Entidades.EstadoOrdenProduccion).IdUbicacion
      End With
      Return eEOPSuc
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosOrdenesProduccionSucursales(Me.da).EstadosOrdenesProduccionSucursales_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.EstadoOrdenProduccionSucursal, tipo As TipoSP)
      Dim sqlC = New SqlServer.EstadosOrdenesProduccionSucursales(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.EstadosOrdenesProduccionSucursales_I(en.IdEstado, en.IdSucursal, en.IdDeposito, en.IdUbicacion)
         Case TipoSP._U
            sqlC.EstadosOrdenesProduccionSucursales_U(en.IdEstado, en.IdSucursal, en.IdDeposito, en.IdUbicacion)
         Case TipoSP._M
            sqlC.EstadosOrdenesProduccionSucursales_M(en.IdEstado, en.IdSucursal, en.IdDeposito, en.IdUbicacion)
         Case TipoSP._D
            sqlC.EstadosOrdenesProduccionSucursales_D(en.IdEstado, en.IdSucursal)
      End Select

   End Sub
   Private Sub CargarUno(o As Entidades.EstadoOrdenProduccionSucursal, dr As DataRow)
      With o
         .IdEstado = dr.Field(Of String)(Entidades.EstadoOrdenProduccionSucursal.Columnas.IdEstado.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.EstadoOrdenProduccionSucursal.Columnas.IdSucursal.ToString())
         .IdDeposito = dr.Field(Of Integer)(Entidades.EstadoOrdenProduccionSucursal.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.EstadoOrdenProduccionSucursal.Columnas.IdUbicacion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Function ValidaEstadosOPSucursalesDepositos(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.EstadosOrdenesProduccionSucursales(da).GetCantidadSucursalesDepositos(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function
#End Region
End Class
