Public Class TableroControlPanel
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "TablerosControlPaneles"
   Public Enum Columnas
      IdTableroControlPanel
      NombrePanel
      Parametros
      IdController
      BackColor1
      ForeColor1
      BackColor2
      ForeColor2

   End Enum

   Public Property IdTableroControlPanel As Integer
   Public Property NombrePanel As String
   Public Property Parametros As String
   Public Property IdController As String

   Public Property BackColor1 As Integer?
   Public Property ForeColor1 As Integer?
   Public Property BackColor2 As Integer?
   Public Property ForeColor2 As Integer?


End Class