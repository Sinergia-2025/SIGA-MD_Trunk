Imports System.Text
Imports Eniac.Entidades

Public Class Tareas
   Inherits Eniac.Reglas.Base

   Public Sub New()
      Me.NombreEntidad = "Tareas"
      Me.da = New Eniac.Datos.DataAccess()
   End Sub

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)

      Dim tarea As Entidades.Tarea = DirectCast(entidad, Entidades.Tarea)

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.Tareas = New SqlServer.Tareas(Me.da)

         sql.Tareas_I(tarea.Fecha, tarea.Tarea, tarea.Usuario)

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim tarea As Entidades.Tarea = DirectCast(entidad, Entidades.Tarea)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Tareas = New SqlServer.Tareas(Me.da)
         sql.Tareas_D(tarea.Id)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Tareas(Me.da).Tareas_GA()
   End Function

   Public Function GetxFecha(ByVal fecha As Date) As DataSet
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Length = 0
         .AppendLine("SELECT Id, Fecha, Tarea, Usuario ")
         .AppendLine(" FROM Tareas")
         .AppendLine("  WHERE Fecha = '" & fecha.Year.ToString("0000") & fecha.Month.ToString("00") & fecha.Day.ToString("00") & " 00:00:00'")
      End With
      Return Me.DataServer().GetDataSet(stbQuery.ToString())
   End Function

   Public Function GetxFechaUsuario(ByVal fecha As Date, ByVal usuario As String) As DataSet
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Length = 0
         .AppendLine("SELECT Id, Fecha, Tarea, Usuario ")
         .AppendLine(" FROM Tareas")
         .AppendLine("  WHERE Fecha = '" & fecha.Year.ToString("0000") & fecha.Month.ToString("00") & fecha.Day.ToString("00") & " 00:00:00'")
         .AppendLine("    AND Usuario = '" & usuario & "'")
      End With
      Return Me.DataServer().GetDataSet(stbQuery.ToString())
   End Function


End Class
