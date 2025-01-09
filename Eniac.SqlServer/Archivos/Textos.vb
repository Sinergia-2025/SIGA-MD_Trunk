Imports System.Text

Public Class Textos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Textos_I(ByVal IdTexto As Integer, ByVal Id As String, ByVal Asunto As String, ByVal Cuerpo As String, ByVal Modalidad As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO Textos ")
         .AppendLine("   (IdTexto")
         .AppendLine("   ,Id")
         .AppendLine("   ,Asunto")
         .AppendLine("   ,Cuerpo")
         .AppendLine("  ,Modalidad) VALUES (")
         .AppendLine(IdTexto.ToString())
         .AppendLine("   ,'" & Id & "'")
         .AppendLine("   ,'" & Asunto.ToString() & "'")
         .AppendLine("   ,'" & Cuerpo.ToString() & "'")
         If Not String.IsNullOrEmpty(Modalidad) Then
            .AppendLine("   ,'" & Modalidad.ToString() & "'")
         Else
            .AppendLine("   ,NULL")
         End If
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Textos")

   End Sub

   Public Sub Textos_U(ByVal Id As String, ByVal Asunto As String, ByVal Cuerpo As String, ByVal Modalidad As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Textos SET ")
         .AppendLine(" Asunto = '" & Asunto & "', ")
         .AppendLine(" Cuerpo = '" & Cuerpo & "'")
         .AppendLine(" WHERE Id = '" & Id & "'")
         If Not String.IsNullOrEmpty(Modalidad) Then
            .AppendLine(" AND Modalidad = '" & Modalidad & "'")
         End If


      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Textos")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT T.Id")
         .AppendLine("      ,T.IdTexto")
         .AppendLine("      ,T.Asunto")
         .AppendLine("      ,T.Cuerpo")
         .AppendLine("      ,T.Modalidad")
         .AppendLine("  FROM Textos T")
      End With
   End Sub

   Public Function Textos_G1(ByVal Id As String, ByVal Modalidad As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE T.Id = '" & Id & "'")
         If Not String.IsNullOrEmpty(Modalidad) Then
            .AppendLine(" AND Modalidad = '" & Modalidad & "'")
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Function Textos_GetIdMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT MAX(IdTexto) AS maximo ")
         .AppendLine(" FROM Textos")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
