Namespace ServiciosRest.CobranzasMovil
   Public Class ProductosClientes
      Public Function GetProductosClientes(idEmpresa As Integer,
                                           incluirClientes As Clientes.IncluirClientes,
                                           exportarConIVA As Boolean,
                                           soloProductosConStock As Boolean) As List(Of Entidades.JSonEntidades.CobranzasMovil.ProductosClientes)

         Dim result As List(Of Entidades.JSonEntidades.CobranzasMovil.ProductosClientes) = New List(Of Entidades.JSonEntidades.CobranzasMovil.ProductosClientes)

         '# Filtros Publicar En
         Dim publicarEn As New Entidades.Filtros.ProductosPublicarEnFiltros(Entidades.Publicos.AndOr.Or)
         publicarEn.Gestion = Entidades.Publicos.SiNoTodos.SI
         publicarEn.Empresarial = Entidades.Publicos.SiNoTodos.SI

         Dim rProductosClientes As Reglas.ProductosClientes = New Reglas.ProductosClientes
         Dim dt As DataTable = rProductosClientes.GetParaSincronizacionMovil(actual.Sucursal.Id,
                                                                             incluirClientes.ToString(),
                                                                             incluidoEnRuta:=False,
                                                                             idCategoria:=0,
                                                                             modulo:="VENTAS",
                                                                             publicarEn:=publicarEn,
                                                                             soloProductosConStock:=soloProductosConStock)
         Dim eProductoCliente As Entidades.JSonEntidades.CobranzasMovil.ProductosClientes

         For Each dr As DataRow In dt.Rows
            eProductoCliente = New Entidades.JSonEntidades.CobranzasMovil.ProductosClientes(idEmpresa)
            eProductoCliente.IdCliente = dr.Field(Of Long)(Entidades.Cliente.Columnas.IdCliente.ToString())
            eProductoCliente.IdProducto = dr.Field(Of String)(Entidades.Producto.Columnas.IdProducto.ToString())
            result.Add(eProductoCliente)
         Next

         Return result
      End Function
   End Class
End Namespace
