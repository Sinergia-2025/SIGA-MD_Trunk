Namespace JSonEntidades.Extensions
   Public Module JsonExtensions
      Private caracteresEspeciales As KeyValuePair(Of String, String)()
      Sub New()
         caracteresEspeciales = {
                                 New KeyValuePair(Of String, String)(Environment.NewLine, "@@ENTER@@"),
                                 New KeyValuePair(Of String, String)("""", "@@COMILLAS@@")
                                }
      End Sub
      <Extension> Public Function SacarCaracteresEspeciales(valor As String) As String
         Return ReemplazarCaracteresEspeciales(valor, sacar:=True)
      End Function
      <Extension> Public Function RecuperarCaracteresEspeciales(valor As String) As String
         Return ReemplazarCaracteresEspeciales(valor, sacar:=False)
      End Function
      Private Function ReemplazarCaracteresEspeciales(valor As String, sacar As Boolean) As String
         For Each par As KeyValuePair(Of String, String) In caracteresEspeciales
            If sacar Then
               valor = valor.Replace(par.Key, par.Value)
            Else
               valor = valor.Replace(par.Value, par.Key)
            End If
         Next
         Return valor
      End Function
   End Module
End Namespace