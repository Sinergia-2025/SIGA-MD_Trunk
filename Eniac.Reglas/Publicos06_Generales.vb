Partial Class Publicos
   Public Class Generales
      Public Enum UbicacionSubtotalesEnGrillas
         InGroupByRows
         GroupByRowsFooter
      End Enum

      Public Shared ReadOnly Property SubtotalesEnGrillas() As UbicacionSubtotalesEnGrillas
         Get
            Dim result = New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.GENERALESSUBTOTALESENGRILLAS.ToString(), "InGroupByRows")
            Return result.StringToEnum(Of UbicacionSubtotalesEnGrillas)(UbicacionSubtotalesEnGrillas.InGroupByRows)
         End Get
      End Property

      ''' <summary>
      ''' Decodifica Base 64.- --
      ''' </summary>
      ''' <param name="valor"></param>
      ''' <returns></returns>
      Public Shared Function DecodeBase64ToString(valor As String) As String
         Dim myBase64ret As Byte() = Convert.FromBase64String(valor)
         Dim myStr As String = System.Text.Encoding.UTF8.GetString(myBase64ret)
         Return myStr
      End Function
      ''' <summary>
      ''' Codifica en Base 64.- -- 
      ''' </summary>
      ''' <param name="valor"></param>
      ''' <returns></returns>
      Public Shared Function EncodeStringToBase64(valor As String) As String
         Dim myByte As Byte() = System.Text.Encoding.UTF8.GetBytes(valor)
         Dim myBase64 As String = Convert.ToBase64String(myByte)
         Return myBase64
      End Function

   End Class
End Class