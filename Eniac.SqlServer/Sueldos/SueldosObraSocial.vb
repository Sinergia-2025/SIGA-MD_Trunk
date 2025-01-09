Public Class SueldosObraSocial
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosObraSocial_I(ByVal idObraSocial As Integer, _
                            ByVal NombreObraSocial As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("SueldosObraSocial  ")
         .Append("(idObraSocial, ")
         .Append("NombreObraSocial)  ")
         .Append("VALUES(")
         .Append(idObraSocial & ", ")
         .Append("'" & NombreObraSocial & "') ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosObraSocial")
   End Sub

   Public Sub SueldosObraSocial_U(ByVal idObraSocial As Integer, _
                           ByVal NombreObraSocial As String)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosObraSocial  ")
         .Append("SET  ")

         .Append("NombreObraSocial = '" & NombreObraSocial & "' ")

         .Append("WHERE ")
         .Append("idObraSocial = " & idObraSocial)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosObraSocial")
   End Sub

   Public Sub SueldosObraSocial_D(ByVal idObraSocial As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("SueldosObraSocial  ")
         .Append("WHERE  ")
         .Append("idObraSocial = " & idObraSocial)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosObraSocial")
   End Sub

   Public Function SueldosObraSocial_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("R.idObraSocial, ")
         .Append("R.NombreObraSocial ")
         .Append("FROM SueldosObraSocial R ")
         .Append("ORDER BY R.NombreObraSocial ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(idObraSocial) AS maximo ")
         .Append(" FROM SueldosObraSocial")
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

   Public Function SueldosObraSocial_G1(ByVal IdSueldoCategoria As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("idObraSocial, ")
         .Append("NombreObraSocial ")
         .Append("FROM SueldosObraSocial ")
         .AppendFormat("WHERE idObraSocial = '{0}' ", IdSueldoCategoria)
         .Append("ORDER BY idObraSocial ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function
End Class
