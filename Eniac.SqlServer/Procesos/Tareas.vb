Public Class Tareas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Tareas_D(ByVal id As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM Tareas ")
         .AppendLine(" WHERE Id = " & id)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Function Tareas_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("SELECT Id, Fecha, Tarea, Usuario")
         .AppendLine("  FROM Tareas")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function Tareas_GxFecha(ByVal fecha As Date) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("SELECT Id, Fecha, Tarea, Usuario")
         .AppendLine("  FROM Tareas")
         .AppendLine(" WHERE Fecha = '" & fecha.Year.ToString("0000") & fecha.Month.ToString("00") & fecha.Day.ToString("00") & " 00:00:00'")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Sub Tareas_I(ByVal fecha As Date, ByVal tarea As String, ByVal usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO Tareas (")
         .AppendLine(" Fecha,")
         .AppendLine(" Tarea,")
         .AppendLine(" Usuario")
         .AppendLine(" ) VALUES (")
         .AppendLine("'" & fecha.Year.ToString("0000") & fecha.Month.ToString("00") & fecha.Day.ToString("00") & " 00:00:00', ")
         .AppendLine("'" & tarea & "',")
         .AppendLine("'" & usuario & "'")
         .AppendLine(")  ")
         .AppendLine("	SELECT @@IDENTITY as 'id'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Tareas")
   End Sub

End Class
