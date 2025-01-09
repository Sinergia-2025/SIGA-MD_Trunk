Imports Eniac.Entidades

Public Class SeleccionMultipleUbicaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(String.Empty, accesoDatos)
   End Sub
#End Region

   Public Function CreaSeleccionMultipleProducto(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, cantidad As Decimal, listObject As Object) As SeleccionMultipleProducto
      Return _CreaSeleccionMultipleProducto(idProducto, idSucursal, idDeposito, idUbicacion, cantidad, listObject)
   End Function
   Public Function _CreaSeleccionMultipleProducto(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, cantidad As Decimal, listObject As Object) As SeleccionMultipleProducto
      Dim producto = New Productos(da)._GetUnoParaM(idProducto)
      Dim ubic = New SucursalesUbicaciones(da).GetUno(idDeposito, idSucursal, idUbicacion)

      Return _CreaSeleccionMultipleProducto(producto, ubic, cantidad, listObject)

   End Function
   Private Function _CreaSeleccionMultipleProducto(producto As ProductoLivianoParaImportarProducto, ubic As SucursalUbicacion, cantidad As Decimal, listObject As Object) As SeleccionMultipleProducto
      Dim prodUbic = New ProductosUbicaciones(da).GetUno(producto.IdProducto, ubic.IdSucursal, ubic.IdDeposito, ubic.IdUbicacion)
      Return New SeleccionMultipleProducto() With {
                     .Producto = producto,
                     .Ubicaciones = New List(Of Entidades.SeleccionMultipleUbicaciones)() From
                                          {New Entidades.SeleccionMultipleUbicaciones() With
                                                   {.Producto = producto, .Ubicacion = ubic, .Cantidad = cantidad, .Stock = prodUbic.Stock}},
                     .Cantidad = cantidad,
                     .ListObject = listObject}
   End Function
End Class