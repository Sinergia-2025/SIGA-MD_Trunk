Public Class PlantillasListasControl
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadPlantillasListasControl_I(ByVal IdPlantillaCalidad As Integer,
                                 ByVal IdListaControl As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("INSERT INTO  ")
         .AppendLine("CalidadPlantillasListasControl ")
         .AppendLine("(IdPlantillaCalidad, ")
         .AppendLine("IdListaControl) VALUES (")
         .AppendLine(IdPlantillaCalidad & ", ")
         .AppendLine(IdListaControl & ")")

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadPlantillasListasControl")
   End Sub

   Public Sub CalidadPlantillasListasControl_U(ByVal IdPlantillaCalidad As Integer, _
                                ByVal IdListaControl As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      'With myQuery
      '   .AppendLine("UPDATE  ")
      '   .AppendLine("CalidadPlantillasListasControl ")
      '   .AppendLine("SET  ")
      '   .AppendLine("OrdenColumna = " & OrdenColumna)
      '   .AppendLine("WHERE ")
      '   .AppendLine("IdPlantillaCalidad = " & IdPlantillaCalidad)
      '   .AppendLine("AND IdListaControl = " & IdListaControl)
      'End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadPlantillasListasControl")
   End Sub

   Public Sub CalidadPlantillasListasControl_D(ByVal IdPlantillaCalidad As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM  ")
         .AppendLine("CalidadPlantillasListasControl ")
         .AppendLine("WHERE  ")
         .AppendLine("IdPlantillaCalidad = " & IdPlantillaCalidad)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadPlantillasListasControl")
   End Sub

   Public Function CalidadPlantillasListasControl_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("SELECT  ")
         .AppendLine("IdPlantillaCalidad, ")
         .AppendLine("IdListaControl ")
         .AppendLine("FROM Plantillas ")
         .AppendLine("ORDER BY IdPlantillaCalidad ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class