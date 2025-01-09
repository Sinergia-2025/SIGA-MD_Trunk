Namespace Filtros
   Public Class ProductosPublicarEnFiltros

      Public Property AndOr As Entidades.Publicos.AndOr
      Public Property Web As Entidades.Publicos.SiNoTodos
      Public Property Gestion As Entidades.Publicos.SiNoTodos
      Public Property TiendaNube As Entidades.Publicos.SiNoTodos
      Public Property MercadoLibre As Entidades.Publicos.SiNoTodos
      Public Property Arborea As Entidades.Publicos.SiNoTodos
      Public Property Empresarial As Entidades.Publicos.SiNoTodos
      Public Property Balanza As Entidades.Publicos.SiNoTodos
      Public Property SincronizacionSucursal As Entidades.Publicos.SiNoTodos
      Public Property ListaPrecioCliente As Entidades.Publicos.SiNoTodos

      Public Sub New()
         Me.New(Publicos.AndOr.And)
      End Sub
      Public Sub New(AndOr As Entidades.Publicos.AndOr)
         Me.AndOr = AndOr
         Web = Publicos.SiNoTodos.TODOS
         Gestion = Publicos.SiNoTodos.TODOS
         Empresarial = Publicos.SiNoTodos.TODOS
         Balanza = Publicos.SiNoTodos.TODOS
         SincronizacionSucursal = Publicos.SiNoTodos.TODOS
         ListaPrecioCliente = Publicos.SiNoTodos.TODOS
         TiendaNube = Publicos.SiNoTodos.TODOS
         MercadoLibre = Publicos.SiNoTodos.TODOS
         Arborea = Publicos.SiNoTodos.TODOS
      End Sub

   End Class
End Namespace