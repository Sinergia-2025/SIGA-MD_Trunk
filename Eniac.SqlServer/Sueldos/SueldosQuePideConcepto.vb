Public Class SueldosQuePideConcepto
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosQuePideConcepto_I(ByVal idQuePide As Integer, _
                            ByVal NombreQuePide As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("SueldosQuePideConcepto  ")
         .Append("(idQuePide, ")
         .Append("NombreQuePide)  ")
         .Append("VALUES(")
         .Append(idQuePide & ", ")
         .Append("'" & NombreQuePide & "') ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosQuePideConcepto")
   End Sub

   Public Sub SueldosQuePideConcepto_U(ByVal idQuePide As Integer, _
                           ByVal NombreQuePide As String)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosQuePideConcepto  ")
         .Append("SET  ")

         .Append("NombreQuePide = '" & NombreQuePide & "' ")

         .Append("WHERE ")
         .Append("idQuePide = " & idQuePide)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosQuePideConcepto")
   End Sub

   Public Sub SueldosQuePideConcepto_D(ByVal idQuePide As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("SueldosQuePideConcepto  ")
         .Append("WHERE  ")
         .Append("idQuePide = " & idQuePide)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosQuePideConcepto")
   End Sub

   Public Function SueldosQuePideConcepto_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT R.idQuePide")
         .Append("      ,R.NombreQuePide")
         .Append("  FROM SueldosQuePideConcepto R ")
         .Append("  ORDER BY R.idQuePide ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("select ")
         .Append(" max(idQuePide) as maximo ")
         .Append(" from  SueldosQuePideConcepto")
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

   Public Function SueldosQuePideConcepto_G1(ByVal idQuePide As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("idQuePide, ")
         .Append("NombreQuePide ")
         .Append("FROM SueldosQuePideConcepto ")
         .AppendFormat("WHERE idQuePide = '{0}' ", idQuePide)
         .Append("ORDER BY idQuePide ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function
End Class
