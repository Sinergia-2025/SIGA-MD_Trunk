Public Class ListaControlItemLinks
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdListaControl
      Item
      ItemLink
      Descripcion
      Link

   End Enum

   Public Property IdListaControl() As Integer
   Public Property Item() As Integer
   Public Property ItemLink() As Integer
   Public Property Descripcion As String
   Public Property Link As String


End Class
