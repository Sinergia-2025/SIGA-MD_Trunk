Public Class SueldosEstadoCivil
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosEstadoCivil_I(ByVal idEstadoCivil As Integer, _
                            ByVal NombreEstadoCivil As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("SueldosEstadoCivil  ")
         .Append("(idEstadoCivil, ")
         .Append("NombreEstadoCivil)  ")
         .Append("VALUES(")
         .Append(idEstadoCivil & ", ")
         .Append("'" & NombreEstadoCivil & "') ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosEstadoCivil")
   End Sub

   Public Sub SueldosEstadoCivil_U(ByVal idEstadoCivil As Integer, _
                           ByVal NombreEstadoCivil As String)
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("UPDATE  ")
         .Append("SueldosEstadoCivil  ")
         .Append("SET  ")

         .Append("NombreEstadoCivil = '" & NombreEstadoCivil & "' ")

         .Append("WHERE ")
         .Append("idEstadoCivil = " & idEstadoCivil)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosEstadoCivil")
   End Sub

   Public Sub SueldosEstadoCivil_D(ByVal idEstadoCivil As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM  ")
         .Append("SueldosEstadoCivil  ")
         .Append("WHERE  ")
         .Append("idEstadoCivil = " & idEstadoCivil)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "SueldosEstadoCivil")
   End Sub

   Public Function SueldosEstadoCivil_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("R.idEstadoCivil, ")
         .Append("R.NombreEstadoCivil ")
         .Append("FROM SueldosEstadoCivil R ")
         .Append("ORDER BY R.NombreEstadoCivil ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(idEstadoCivil) AS maximo ")
         .Append(" FROM SueldosEstadoCivil")
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

   Public Function SueldosEstadoCivil_G1(ByVal IdSueldoCategoria As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         .Append("SELECT  ")
         .Append("idEstadoCivil, ")
         .Append("NombreEstadoCivil ")
         .Append("FROM SueldosEstadoCivil ")
         .AppendFormat("WHERE idEstadoCivil = '{0}' ", IdSueldoCategoria)
         .Append("ORDER BY idEstadoCivil ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   'Public Function GetCodigoMaximo() As Integer

   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .Append("SELECT MAX(IdEstadoCivil) AS Maximo ")
   '      .Append(" FROM SueldosEstadoCivil")
   '   End With

   '   Dim dt As DataTable = Me.GetDataTable(stb.ToString())
   '   Dim val As Integer = 0

   '   If dt.Rows.Count > 0 Then
   '      If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
   '         val = Integer.Parse(dt.Rows(0)("Maximo").ToString())
   '      End If
   '   End If

   '   Return val
   'End Function

End Class
