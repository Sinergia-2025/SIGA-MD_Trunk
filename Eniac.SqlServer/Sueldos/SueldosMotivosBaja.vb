Public Class SueldosMotivosBaja
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SueldosMotivosBaja_I(ByVal IdMotivoBaja As Integer, ByVal NombreMotivoBaja As String)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO SueldosMotivosBaja (")
         .Append("           IdMotivoBaja")
         .Append("           ,NombreMotivoBaja")
         .Append(")     VALUES(")
         .AppendFormat("           {0}", IdMotivoBaja)
         .AppendFormat("           ,'{0}'", NombreMotivoBaja)
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosMotivosBaja")
   End Sub

   Public Sub SueldosMotivosBaja_U(ByVal IdMotivoBaja As Integer, ByVal NombreMotivoBaja As String)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE SueldosMotivosBaja SET ")
         .AppendFormat("      IdMotivoBaja = {0}", IdMotivoBaja)
         .AppendFormat("      ,NombreMotivoBaja = '{0}'", NombreMotivoBaja)
         .Append(" WHERE ")
         .AppendFormat("      IdMotivoBaja = {0}", IdMotivoBaja)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosMotivosBaja")
   End Sub

   Public Sub SueldosMotivosBaja_D(ByVal IdMotivoBaja As Integer)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM SueldosMotivosBaja WHERE ")
         .AppendFormat("       IdMotivoBaja = {0}", IdMotivoBaja)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "SueldosMotivosBaja")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT ")
         .Append("           IdMotivoBaja")
         .Append("           ,NombreMotivoBaja")
         .Append("  FROM SueldosMotivosBaja")
      End With
   End Sub

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT MAX(IdMotivoBaja) AS Maximo ")
         .Append(" FROM SueldosMotivosBaja")
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

   Public Function SueldosMotivosBaja_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function SueldosMotivosBaja_G1(ByVal IdMotivoBaja As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat("       IdMotivoBaja = {0}", IdMotivoBaja)
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


End Class
