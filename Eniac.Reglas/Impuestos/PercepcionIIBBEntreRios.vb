Option Strict On
Public Class PercepcionIIBBEntreRios
   Inherits PercepcionIIBBSantaFe
   'POR LO QUE SE RELEVÓ EL CALCULO SERÍA IGUAL AL DE SANTA FE
   'SI TUVIERAMOS LA NECESIDAD DE CAMBIAR LA LÓGICA DE CALCULO, COPIAR LA DE SANTA FE Y MODIFICARLA
   'MIENTRAS SIGAN SIENDO IGUAL, DEJAR COMO HERENCIA

   Public Sub New(idProvincia As String)
      MyBase.New(idProvincia)
   End Sub
End Class