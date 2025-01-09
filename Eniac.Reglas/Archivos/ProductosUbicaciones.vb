Public Class ProductosUbicaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ProductoUbicacion.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.ProductoUbicacion), TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.ProductoUbicacion), TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.ProductoUbicacion), TipoSP._D)
   End Sub

#End Region

   Private Sub CargarUno(o As Entidades.ProductoUbicacion, dr As DataRow)
      With o
         .IdProducto = dr.Field(Of String)(Entidades.ProductoUbicacion.Columnas.IdProducto.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.ProductoUbicacion.Columnas.IdSucursal.ToString())
         .IdDeposito = dr.Field(Of Integer)(Entidades.ProductoUbicacion.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.ProductoUbicacion.Columnas.IdUbicacion.ToString())
         .Stock = dr.Field(Of Decimal)(Entidades.ProductoUbicacion.Columnas.Stock.ToString())
         .Stock2 = dr.Field(Of Decimal)(Entidades.ProductoUbicacion.Columnas.Stock2.ToString())
         '.FechaActualizacion = dr.Field(Of Date?)(Entidades.ProductoUbicacion.Columnas.FechaActualizacion.ToString()).IfNull()
      End With
   End Sub
   Public Function Get1(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As DataTable
      Return New SqlServer.ProductosUbicaciones(da).GetSucursalDepositoProducto(idSucursal, idDeposito, idUbicacion, idProducto, verificaStock:=False)
   End Function
   Public Function GetUno(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As Entidades.ProductoUbicacion
      Return GetUno(idProducto, idSucursal, idDeposito, idUbicacion, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUno(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoUbicacion
      Return CargaEntidad(Get1(idProducto, idSucursal, idDeposito, idUbicacion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoUbicacion(),
                          accion, Function() String.Format("No existe registro de stock para el IdProducto {0}, IdSucursal {1}, IdDeposito {2} y IdUbicacion {3}",
                                                           idProducto, idSucursal, idDeposito, idUbicacion))
   End Function

   Friend Sub EjecutaSP(ent As Entidades.ProductoUbicacion, tipo As TipoSP)
      Dim sql = New SqlServer.ProductosUbicaciones(da)
      Select Case tipo
         Case TipoSP._I
            sql.ProductosUbicaciones_I(ent.IdProducto, ent.IdSucursal, ent.IdDeposito, ent.IdUbicacion, ent.Stock, ent.Stock2)
         Case TipoSP._D
            sql.ProductosUbicaciones_D(ent.IdProducto, ent.IdSucursal, ent.IdDeposito, ent.IdUbicacion)
      End Select
   End Sub
   Public Sub ProductosSucursalesUbicaciones_I(IdDeposito As Integer, idSucursal As Integer, idUbicacion As Integer)
      Dim sql = New SqlServer.ProductosUbicaciones(da)
      sql.ProductosSucursalesUbicaciones_I(IdDeposito, idSucursal, idUbicacion)
   End Sub
   Public Sub ProductosSucursalesUbicaciones_D(IdDeposito As Integer, idSucursal As Integer, idUbicacion As Integer)
      Dim sql = New SqlServer.ProductosUbicaciones(da)
      sql.ProductosSucursalesUbicaciones_D(IdDeposito, idSucursal, idUbicacion)
   End Sub
   Public Function GetSucursalDepositoProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String) As DataTable
      Return _GetSucursalDepositoProducto(idSucursal, idDeposito, idUbicacion, idProducto, False)
   End Function
   Public Function GetSucursalDepositoProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, verificaStock As Boolean) As DataTable
      Return _GetSucursalDepositoProducto(idSucursal, idDeposito, idUbicacion, idProducto, verificaStock)
   End Function

   Public Function _GetSucursalDepositoProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, verificaStock As Boolean) As DataTable
      Return New SqlServer.ProductosUbicaciones(Me.da).GetSucursalDepositoProducto(idSucursal, idDeposito, idUbicacion, idProducto, verificaStock)
   End Function

   Public Function GetInconsistenciaDepositosVsUbicaciones(idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosUbicaciones(da).GetInconsistenciaDepositosVsUbicaciones(idSucursal))
   End Function
   Public Function GetInconsistenciaUbicacionesVsMovStock(idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosUbicaciones(da).GetInconsistenciaUbicacionesVsMovStock(idSucursal))
   End Function
End Class
