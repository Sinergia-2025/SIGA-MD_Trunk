Public Class Traducciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function Traducciones_GA() As DataTable
      Return Traducciones_G(String.Empty, String.Empty, String.Empty, String.Empty)
   End Function

   Public Function Traducciones_G1(idFuncion As String, pantalla As String, control As String, idIdioma As String) As DataTable
      Return Traducciones_G(idFuncion, control, pantalla, idIdioma)
   End Function

   Public Function Traducciones_G(idFuncion As String, pantalla As String, control As String, idIdioma As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormat("   AND T.IdFuncion = '{0}'", idFuncion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormat("   AND T.Pantalla = '{0}'", pantalla).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(control) Then
            .AppendFormat("   AND T.Control = '{0}'", control).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idIdioma) Then
            .AppendFormat("   AND T.IdIdioma = '{0}'", idIdioma).AppendLine()
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorIdioma(ByVal idIdioma As String) As DataTable
      Return Traducciones_G(String.Empty, String.Empty, String.Empty, idIdioma)
   End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT T.* ")
         .AppendLine("  FROM Traducciones T")
      End With
   End Sub
End Class