Public Class SeleccionMultipleNrosSerie
   Inherits SeleccionMultipleBase
   Public Property NroSerie As String
   Public Sub New()
      MyBase.New()
      Cantidad = 1
   End Sub
   Public Sub New(ubicacionAdmin As SeleccionMultipleUbicaciones, nroSerie As String)
      MyBase.New(ubicacionAdmin)
      Me.NroSerie = nroSerie
      Cantidad = 1
   End Sub
End Class