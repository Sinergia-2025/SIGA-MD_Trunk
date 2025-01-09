Public Class PercepcionesFabrica

   Public Shared Function GetPercepcion(idProvincia As String) As IPercepcionIIBB
      Select Case idProvincia
         Case Is = "SF" 'Santa Fe
            Return New PercepcionIIBBSantaFe(idProvincia)
         Case Is = "BS"
            Return New PercepcionIIBBBuenosAires(Publicos.NombreBaseARBA, idProvincia)
         Case Is = "CF"
            Return New PercepcionIIBBCaba(Publicos.NombreBaseARBA, idProvincia)
         Case Is = "ER" 'Entre Rios
            Return New PercepcionIIBBSantaFe(idProvincia)
         Case Is = "MZ" 'Mendoza
            Return New PercepcionIIBBSantaFe(idProvincia)
         Case Else
            Return Nothing
      End Select
   End Function

End Class
