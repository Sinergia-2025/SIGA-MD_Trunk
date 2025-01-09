Public Class GrupoTipoAtributoProducto
   Inherits Entidad

   Public Const NombreTabla As String = "GruposTiposAtributosProductos"
   Public Enum Columnas
      IdGrupoTipoAtributoProducto
      IdTipoAtributoProducto
      Descripcion
   End Enum

   Public Property IdGrupoTipoAtributoProducto As Integer
   Public Property IdTipoAtributoProducto As Short
   Public Property Descripcion As String

End Class
