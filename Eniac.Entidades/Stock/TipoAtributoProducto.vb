<Serializable()>
Public Class TipoAtributoProducto
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "TiposAtributosProductos"

#Region "Columnas"
   Public Enum Columnas
      IdTipoAtributoProducto
      Descripcion
   End Enum

#End Region

#Region "Campos"
   Public Property IdTipoAtributoProducto As Short
   Public Property Descripcion As String

#End Region

End Class

