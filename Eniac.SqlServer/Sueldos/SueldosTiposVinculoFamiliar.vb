Public Class SueldosTiposVinculoFamiliar
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosTiposVinculoFamiliar_I(ByVal idTipoVinculoFamiliar As String, _
                            ByVal NombreVinculoFamiliar As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("SueldosTiposVinculoFamiliar  ")
         .Append("(idTipoVinculoFamiliar, ")
         .Append("NombreVinculoFamiliar)  ")
         .Append("VALUES(")
         .Append(idTipoVinculoFamiliar & ", ")
         .Append("'" & NombreVinculoFamiliar & "') ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosTiposVinculoFamiliar")
   End Sub

   Public Sub SueldosTiposVinculoFamiliar_U(ByVal idTipoVinculoFamiliar As String, _
                           ByVal NombreVinculoFamiliar As String)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosTiposVinculoFamiliar  ")
         .Append("SET  ")

         .Append("NombreVinculoFamiliar = '" & NombreVinculoFamiliar & "' ")

         .Append("WHERE ")
         .Append("idTipoVinculoFamiliar = " & idTipoVinculoFamiliar)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosTiposVinculoFamiliar")
   End Sub

   Public Sub SueldosTiposVinculoFamiliar_D(ByVal idTipoVinculoFamiliar As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("SueldosTiposVinculoFamiliar  ")
         .Append("WHERE  ")
         .Append("idTipoVinculoFamiliar = " & idTipoVinculoFamiliar)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosTiposVinculoFamiliar")
   End Sub

   Public Function SueldosTiposVinculoFamiliar_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("R.idTipoVinculoFamiliar, ")
         .Append("R.NombreVinculoFamiliar ")
         .Append("FROM SueldosTiposVinculoFamiliar R ")
         .Append("ORDER BY R.NombreVinculoFamiliar ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function SueldosTiposVinculoFamiliar_G1(ByVal IdSueldoTipoVinculoFamiliar As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("idTipoVinculoFamiliar, ")
         .Append("NombreVinculoFamiliar ")
         .Append("FROM SueldosTiposVinculoFamiliar ")
         .AppendFormat("WHERE idTipoVinculoFamiliar = '{0}' ", IdSueldoTipoVinculoFamiliar)
         .Append("ORDER BY idTipoVinculoFamiliar ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function


End Class

