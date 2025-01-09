Public Class AtributoProducto
   Inherits Entidad

   Public Const NombreTabla As String = "AtributosProductos"

   Public Enum Columnas
      IdAtributoProducto
      IdTipoAtributoProducto
      IdGrupoTipoAtributoProducto
      Descripcion
      Orden
      IdaAtributoProducto
   End Enum

   Public Sub New()
   End Sub

   Public Sub New(idTipoAtributoProducto As Short, idGrupoTipoAtributoProducto As Integer)
      Me.New()
      Me.IdTipoAtributoProducto = idTipoAtributoProducto
      Me.IdGrupoTipoAtributoProducto = idGrupoTipoAtributoProducto
   End Sub

   Public Property IdAtributoProducto As Integer
   Public Property IdTipoAtributoProducto As Short
   Public Property IdGrupoTipoAtributoProducto As Integer
   Public Property Descripcion As String
   Public Property Orden As Integer
   Public Property IdaAtributoProducto As Integer

   Public Property DescripcionGrupo As String
   Public Property DescripcionTipo As String

End Class
