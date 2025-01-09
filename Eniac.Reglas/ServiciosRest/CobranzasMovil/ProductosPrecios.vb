Namespace ServiciosRest.CobranzasMovil
   Public Class ProductosPrecios
      Public Function GetProductosPrecios(idEmpresa As Integer, exportarConIVA As Boolean, soloProductosConStock As Boolean) As List(Of Entidades.JSonEntidades.CobranzasMovil.ProductosPrecios)
         Dim result As List(Of Entidades.JSonEntidades.CobranzasMovil.ProductosPrecios) = New List(Of Entidades.JSonEntidades.CobranzasMovil.ProductosPrecios)()

         Dim publicarEn As New Entidades.Filtros.ProductosPublicarEnFiltros(Entidades.Publicos.AndOr.Or)
         publicarEn.Gestion = Entidades.Publicos.SiNoTodos.SI
         publicarEn.Empresarial = Entidades.Publicos.SiNoTodos.SI
         Dim dtClientes As DataTable = New Reglas.ProductosSucursalesPrecios().GetAll(publicarEn, Publicos.Simovil.Subida.AplicaPreciosOferta, soloProductosConStock,
                                                                                      productoActivo:=True, productoModulo:="VENTAS")
         Dim o As Entidades.JSonEntidades.CobranzasMovil.ProductosPrecios

         Dim dolar = New Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion

         For Each dr As DataRow In dtClientes.Rows
            o = New Entidades.JSonEntidades.CobranzasMovil.ProductosPrecios(idEmpresa)

            o.IdProducto = dr(Entidades.ProductoSucursalPrecio.Columnas.IdProducto.ToString()).ToString()
            o.IdListaPrecios = Integer.Parse(dr(Entidades.ProductoSucursalPrecio.Columnas.IdListaPrecios.ToString()).ToString())
            o.NombreListaPrecios = dr(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()).ToString()

            '-- REQ-44258.- --------------------------------------------------------------------------------------------------------------------------------------
            If Not Reglas.Publicos.Simovil.PublicarPrecioEmbalaje AndAlso
                  Boolean.Parse(dr(Entidades.Producto.Columnas.PrecioPorEmbalaje.ToString()).ToString()) AndAlso
                     Integer.Parse(dr(Entidades.Producto.Columnas.Embalaje.ToString()).ToString()) <> 0 Then
               If exportarConIVA Then
                  o.PrecioVenta = (Decimal.Parse(dr("PrecioVentaConIVA").ToString()) / Integer.Parse(dr(Entidades.Producto.Columnas.Embalaje.ToString()).ToString()))
               Else
                  o.PrecioVenta = (Decimal.Parse(dr("PrecioVentaSinIVA").ToString()) / Integer.Parse(dr(Entidades.Producto.Columnas.Embalaje.ToString()).ToString()))
               End If
            Else
               If exportarConIVA Then
                  o.PrecioVenta = Decimal.Parse(dr("PrecioVentaConIVA").ToString())
               Else
                  o.PrecioVenta = Decimal.Parse(dr("PrecioVentaSinIVA").ToString())
               End If
            End If
            '-------------------------------------------------------------------------------------------------------------------------------------------------------
            If dr.Field(Of Integer)("IdMoneda") = Entidades.Moneda.Dolar Then
               o.PrecioVenta *= dolar
            End If
            o.FechaActualizacion = DateTime.Parse(dr(Entidades.ProductoSucursalPrecio.Columnas.FechaActualizacion.ToString()).ToString())

            result.Add(o)
         Next

         Return result
      End Function
   End Class
End Namespace