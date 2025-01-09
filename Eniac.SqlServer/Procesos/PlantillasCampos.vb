Public Class PlantillasCampos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PlantillasCampos_I(ByVal IdPlantilla As Integer,
                                 ByVal IdCampo As Integer,
                           ByVal OrdenColumna As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("INSERT INTO  ")
         .AppendLine("PlantillasCampos ")
         .AppendLine("(IdPlantilla, ")
         .AppendLine("IdCampo,")
         .AppendLine("OrdenColumna")
         .AppendLine(") VALUES (")
         .AppendLine(IdPlantilla & ", ")
         .AppendLine(IdCampo & ", ")
         If OrdenColumna <> 0 Then
            .AppendLine(OrdenColumna & ")")
         Else
            .AppendLine("Null)")
         End If

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "PlantillasCampos")
   End Sub

   Public Sub PlantillasCampos_U(ByVal IdPlantilla As Integer, _
                                ByVal IdCampo As Integer,
                                ByVal OrdenColumna As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("UPDATE  ")
         .AppendLine("PlantillasCampos ")
         .AppendLine("SET  ")
         .AppendLine("OrdenColumna = " & OrdenColumna)
         .AppendLine("WHERE ")
         .AppendLine("IdPlantilla = " & IdPlantilla)
         .AppendLine("AND IdCampo = " & IdCampo)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "PlantillasCampos")
   End Sub

   Public Sub PlantillasCampos_D(ByVal IdPlantilla As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM  ")
         .AppendLine("PlantillasCampos ")
         .AppendLine("WHERE  ")
         .AppendLine("IdPlantilla = " & IdPlantilla)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "PlantillasCampos")
   End Sub

   Public Function PlantillasCampos_GA() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .AppendLine("SELECT  ")
         .AppendLine("IdPlantilla, ")
         .AppendLine("IdCampo, ")
         .AppendLine("OrdenColumna  ")
         .AppendLine("FROM Plantillas ")
         .AppendLine("ORDER BY IdPlantilla ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class