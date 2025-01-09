Namespace ServiciosRest.CobranzasMovil
   Public Class Productos
      Public Function GetProductos(idEmpresa As Integer, exportarConIVA As Boolean, soloProductosConStock As Boolean) As List(Of Entidades.JSonEntidades.CobranzasMovil.Productos)
         Dim result As List(Of Entidades.JSonEntidades.CobranzasMovil.Productos) = New List(Of Entidades.JSonEntidades.CobranzasMovil.Productos)()

         Dim publicarEn As New Entidades.Filtros.ProductosPublicarEnFiltros(Entidades.Publicos.AndOr.Or)
         publicarEn.Gestion = Entidades.Publicos.SiNoTodos.SI
         publicarEn.Empresarial = Entidades.Publicos.SiNoTodos.SI

         Dim dtClientes As DataTable = New Reglas.Productos().GetPorCodigo(idProducto:=String.Empty, idSucursal:=Entidades.Usuario.Actual.Sucursal.Id,
                                                                           idListaPrecios:=Publicos.ListaPreciosPredeterminada, modulo:="VENTAS",
                                                                           publicarEn:=publicarEn, soloProductosConStock:=soloProductosConStock)
         Dim o As Entidades.JSonEntidades.CobranzasMovil.Productos

         For Each dr As DataRow In dtClientes.Rows
            o = New Entidades.JSonEntidades.CobranzasMovil.Productos(idEmpresa)

            o.IdProducto = dr(Entidades.Producto.Columnas.IdProducto.ToString()).ToString().Trim()
            o.NombreProducto = dr(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
            o.NombreCorto = dr(Entidades.Producto.Columnas.NombreCorto.ToString()).ToString()
            o.IdRubro = Integer.Parse(dr(Entidades.Producto.Columnas.IdRubro.ToString()).ToString())

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
               o.PrecioVenta *= dr.Field(Of Decimal)("FactorConversion")
            End If
            o.Embalaje = Integer.Parse(dr(Entidades.Producto.Columnas.Embalaje.ToString()).ToString())
            o.EsCambiable = Boolean.Parse(dr(Entidades.Producto.Columnas.EsCambiable.ToString()).ToString())
            o.EsBonificable = Boolean.Parse(dr(Entidades.Producto.Columnas.EsBonificable.ToString()).ToString())
            o.EsDevuelto = Boolean.Parse(dr(Entidades.Producto.Columnas.EsDevuelto.ToString()).ToString())
            o.Stock = Decimal.Parse(dr("Stock").ToString())
            o.CalidadNumeroChasis = dr.Field(Of String)(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString())
            o.CalidadNroCarroceria = dr.Field(Of Integer?)(Entidades.Producto.Columnas.CalidadNroCarroceria.ToString())
            result.Add(o)
         Next

         Return result
      End Function
   End Class
End Namespace