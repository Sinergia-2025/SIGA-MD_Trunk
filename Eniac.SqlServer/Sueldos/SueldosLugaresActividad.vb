Public Class SueldosLugaresActividad
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosLugaresActividad_I(ByVal IdLugarActividad As Integer, _
 ByVal NombreLugarActividad As String)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO SueldosLugaresActividad (")
         .Append("           IdLugarActividad")
         .Append("           ,NombreLugarActividad")
         .Append(")     VALUES(")
         .AppendFormat("           {0}", IdLugarActividad)
         .AppendFormat("           ,'{0}'", NombreLugarActividad)
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosLugaresActividad")
   End Sub

   Public Sub SueldosLugaresActividad_U(ByVal IdLugarActividad As Integer, _
   ByVal NombreLugarActividad As String)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE SueldosLugaresActividad SET ")
         .AppendFormat("      IdLugarActividad = {0}", IdLugarActividad)
         .AppendFormat("      ,NombreLugarActividad = '{0}'", NombreLugarActividad)
         .Append(" WHERE ")
         .AppendFormat("      IdLugarActividad = {0}", IdLugarActividad)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosLugaresActividad")
   End Sub

   Public Sub SueldosLugaresActividad_D(ByVal IdLugarActividad As Integer)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM SueldosLugaresActividad WHERE ")
         .AppendFormat("      IdLugarActividad = {0}", IdLugarActividad)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosLugaresActividad")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT ")
         .Append("           IdLugarActividad")
         .Append("           ,NombreLugarActividad")
         .Append("  FROM SueldosLugaresActividad ")
      End With
   End Sub

   Public Function SueldosLugaresActividad_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function SueldosLugaresActividad_G1(ByVal IdLugarActividad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append(" WHERE ")
         .AppendFormat("      IdLugarActividad = {0}", IdLugarActividad)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'columna = "R." + columna
      'If columna = "R.NombreVendedor" Then columna = "V.NombreEmpleado"
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT MAX(IdLugarActividad) AS Maximo ")
         .Append(" FROM SueldosLugaresActividad")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

End Class
