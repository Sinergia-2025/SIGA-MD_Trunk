Namespace Extensiones
   Public Module ObjectExtensions
      Public Function ValorNumericoPorDefecto(Of T)(valor As Object, porDefecto As T) As T
         If IsNumeric(valor) Then
            Return DirectCast(Convert.ChangeType(valor, GetType(T)), T)
         End If
         Return porDefecto
      End Function

      Public Function ValorDateTimePorDefecto(valor As Object, porDefecto As DateTime) As DateTime
         Dim fecha As DateTime
         If valor IsNot Nothing AndAlso DateTime.TryParse(valor.ToString(), fecha) Then
            Return fecha
         End If
         Return porDefecto
      End Function

   End Module
End Namespace