Public Class ListaControlConfig
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdListaControl
      Item
      IdListaControlItem
      Orden
   End Enum

   Public Property IdListaControl() As Integer
   Public Property Item() As Integer
   Public Property IdListaControlItem() As Integer
   Public Property Orden() As Integer
   Public Property NombreListaControlItem As String
   Public Property IdGrupoListaControlItem As String


End Class
