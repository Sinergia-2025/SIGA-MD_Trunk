
Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class RolesFunciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RolesFunciones_I(ByVal IdRol As String, ByVal IdFuncion As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO RolesFunciones ")
         .Append("   (RF.IdRol")
         .Append("   ,RF.IdFuncion)")
         .Append("   VALUES")
         .AppendLine("  ('" & IdRol & "', '" & IdFuncion & "')")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RolesFunciones_D(ByVal IdRol As String, ByVal IdFuncion As String)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM RolesFunciones")
         .AppendFormat(" WHERE IdRol = '{0}' AND IdFuncion = '{1}'", IdRol, IdFuncion)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT RF.IdRol")
         .AppendLine("      ,RF.IdFuncion")
         .AppendLine("      ,F.Nombre")
         .AppendLine("      ,F.Posicion")
         .AppendLine("      ,F.IdPadre")
         .AppendLine(" FROM RolesFunciones RF")
         .AppendLine(" INNER JOIN Funciones F ON F.Id = RF.IdFuncion")
      End With
   End Sub

   Public Function RolesFunciones_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" ORDER BY F.IdPadre, F.Posicion")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function RolesFunciones_GA(ByVal IdRol As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE RF.IdRol = '" & IdRol & "'")
         .AppendLine(" ORDER BY F.IdPadre, F.Posicion")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
