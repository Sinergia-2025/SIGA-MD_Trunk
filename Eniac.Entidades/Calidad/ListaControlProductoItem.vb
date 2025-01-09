Public Class ListaControlProductoItem
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProducto
      IdListaControl
      Item
      IdListaControlItem
      Ok
      NoOk
      Obs
      Mat
      NA
      Observ
      Orden
      Usuario
      FechaMod
      OkCalidad
      NoOkCalidad
      ObsCalidad
      MatCalidad
      NACalidad
      ObservCalidad
      UsuarioCalidad
      FechaModCalidad
   End Enum


   Public Property IdProducto As String
   Public Property IdListaControl As Integer
   Public Property Item As Integer
   Public Property IdListaControlItem As Integer
   Public Property Ok As Boolean
   Public Property NoOk As Boolean
   Public Property Obs As Boolean
   Public Property Mat As Boolean
   Public Property NA As Boolean
   Public Property Observ As String
   Public Property Orden As Integer
   'Public Property Usuario As String
   Public Property FechaMod As DateTime

   Public Property OkCalidad As Boolean
   Public Property NoOkCalidad As Boolean
   Public Property ObsCalidad As Boolean
   Public Property MatCalidad As Boolean
   Public Property NACalidad As Boolean
   Public Property ObservCalidad As String
   Public Property UsuarioCalidad As String
   Public Property FechaModCalidad As DateTime

End Class