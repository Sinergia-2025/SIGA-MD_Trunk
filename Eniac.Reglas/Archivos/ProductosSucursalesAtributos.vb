Public Class ProductosSucursalesAtributos
   Inherits Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ProductosSucursalesAtributos"
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Sub Merge(prodSucAtri As Entidades.ProductoSucursalAtributo)
      EjecutaSP(prodSucAtri, TipoSP._M)
   End Sub
   Public Sub Elimina(prodSucAtri As Entidades.ProductoSucursalAtributo)
      EjecutaSP(prodSucAtri, TipoSP._D)
   End Sub
#End Region

#Region "Metodos Privados"
   Friend Sub EjecutaSP(ent As Entidades.ProductoSucursalAtributo, tipo As TipoSP)

      Dim sql = New SqlServer.ProductosSucursalesAtributos(da)

      Select Case tipo
         Case TipoSP._M
            sql.ProductosSucursalesAtributos_M_UStock(ent.IdProducto,
                                                      ent.IdSucursal,
                                                      ent.IdProdSucAtributo,
                                                      ent.IdaAtributo01,
                                                      ent.IdaAtributo02,
                                                      ent.IdaAtributo03,
                                                      ent.IdaAtributo04,
                                                      ent.IdDeposito,
                                                      ent.IdUbicacion,
                                                      ent.Stock)

         Case TipoSP._D
            sql.ProductosSucursalesAtributos_D(ent.IdProducto, ent.IdSucursal, ent.IdProdSucAtributo)
      End Select


   End Sub

   Public Function GetStockProductoAtributo(idProducto As String,
                                            idSucursal As Integer,
                                            idaAtributo01 As Integer,
                                            idaAtributo02 As Integer,
                                            idaAtributo03 As Integer,
                                            idaAtributo04 As Integer) As Decimal
      Return New SqlServer.ProductosSucursalesAtributos(da).GetStockProductoAtributo(idProducto,
                                                                                     idSucursal,
                                                                                     idaAtributo01,
                                                                                     idaAtributo02,
                                                                                     idaAtributo03,
                                                                                     idaAtributo04)
   End Function
#End Region
End Class
