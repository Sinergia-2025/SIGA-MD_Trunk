Public Class SueldosTiposConceptos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosTiposConceptos_I(idTipoConcepto As Integer,
                                      NombreTipoConcepto As String,
                                      Orden As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO SueldosTiposConceptos (idTipoConcepto, NombreTipoConcepto, Orden) ")
         .AppendFormat("VALUES ({0}, '{1}', {2})", idTipoConcepto, NombreTipoConcepto, Orden)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosTiposConceptos")
   End Sub

   Public Sub SueldosTiposConceptos_U(idTipoConcepto As Integer,
                                      NombreTipoConcepto As String,
                                      Orden As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE SueldosTiposConceptos")
         .Append("   SET NombreTipoConcepto = '" & NombreTipoConcepto & "' ")
         .Append("     , Orden = " & Orden.tostring())
         .Append("WHERE idTipoConcepto = " & idTipoConcepto)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosTiposConceptos")
   End Sub

   Public Sub SueldosTiposConceptos_D(ByVal idTipoConcepto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendFormat("DELETE FROM SueldosTiposConceptos WHERE idTipoConcepto = {0}", idTipoConcepto)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosTiposConceptos")
   End Sub

   Public Function SueldosTiposConceptos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine("SELECT R.*")
         .AppendLine("  FROM SueldosTiposConceptos R")
         .AppendLine("  ORDER BY R.Orden, R.idTipoConcepto")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(idTipoConcepto) AS maximo ")
         .Append(" FROM SueldosTiposConceptos")
      End With

      'Para el Importador de Productos (Airoldi y Generico)
      'Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   Public Function SueldosTiposConceptos_G1(ByVal IdTipoConcepto As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("idTipoConcepto, ")
         .Append("NombreTipoConcepto ")
         .Append("FROM SueldosTiposConceptos ")
         .AppendFormat("WHERE idTipoConcepto = '{0}' ", IdTipoConcepto)
         .Append("ORDER BY idTipoConcepto ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function
End Class
