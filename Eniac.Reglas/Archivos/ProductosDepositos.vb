Imports Eniac.Entidades

Public Class ProductosDepositos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ProductoDeposito.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.ProductoDeposito), TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.ProductoDeposito), TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.ProductoDeposito), TipoSP._D)
   End Sub

#End Region
   Friend Sub EjecutaSP(ent As Entidades.ProductoDeposito, tipo As TipoSP)
      Dim sql = New SqlServer.ProductosDepositos(da)

      Select Case tipo
         Case TipoSP._I
            sql.ProductosDepositos_I(ent.IdProducto, ent.IdSucursal, ent.IdDeposito, ent.Stock, ent.Stock2)

            'Dim dt As DataTable = New Reglas.SucursalesUbicaciones().GetSucursalDeposito(idSucursal:=ent.IdSucursal, idDeposito:=ent.IdDeposito)
            'For Each dr As DataRow In dt.Rows
            '   '-- Carga Producto Ubicacion.-
            '   Dim rProUbi = New Reglas.ProductosUbicaciones(da)
            '   Dim eProUbi = New Entidades.ProductoUbicacion()
            '   With eProUbi
            '      .IdProducto = ent.IdProducto
            '      .IdSucursal = ent.IdSucursal
            '      .IdDeposito = ent.IdDeposito
            '      .IdUbicacion = Integer.Parse(dr("IdUbicacion").ToString())
            '      .Stock = ent.Stock
            '      .Stock2 = ent.Stock2
            '   End With
            '   rProUbi.Insertar(eProUbi)
            'Next

         Case TipoSP._D
            sql.ProductosDepositos_D(ent.IdProducto, ent.IdSucursal, ent.IdDeposito)
            '-- Elimina Producto Ubicacion.-
            Dim rProUbi = New Reglas.ProductosUbicaciones(da)
            Dim eProUbi = New Entidades.ProductoUbicacion()
            With eProUbi
               .IdProducto = ent.IdProducto
               .IdSucursal = ent.IdSucursal
               .IdDeposito = ent.IdDeposito
               .IdUbicacion = ent.IdUbicacion
            End With
            rProUbi.Borrar(eProUbi)
      End Select

   End Sub
   Public Sub ProductosSucursalesDepositos_I(IdDeposito As Integer, idSucursal As Integer)
      Dim sql = New SqlServer.ProductosDepositos(da)
      sql.ProductosSucursalesDepositos_I(IdDeposito, idSucursal)
   End Sub

   Public Sub ProductosSucursalesDepositos_D(IdDeposito As Integer, idSucursal As Integer)
      Dim sql = New SqlServer.ProductosDepositos(da)
      sql.ProductosSucursalesDepositos_D(IdDeposito, idSucursal)
   End Sub
   Public Function GetInconsistenciaDepositosVsSucursales(idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosDepositos(da).GetInconsistenciaDepositosVsSucursales(idSucursal))
   End Function
   Public Function GetInconsistenciaDepositosVsMovStock(idSucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProductosDepositos(da).GetInconsistenciaDepositosVsMovStock(idSucursal))
   End Function

   Public Function ValidaProductosSucursalesDepositosStock(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.ProductosDepositos(da).GetCantidadDepositosConStock(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function
End Class
