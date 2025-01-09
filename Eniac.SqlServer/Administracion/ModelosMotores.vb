Public Class ModelosMotores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ModelosMotores_I(idModeloMotor As Integer,
                               nombreModeloMotor As String,
                               idMarcaMotor As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ModelosMotores ")
         .AppendFormatLine("  (IdModeloMotor")
         .AppendFormatLine("  ,NombreModeloMotor")
         .AppendFormatLine("  ,idMarcaMotor")
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("    {0} ", idModeloMotor)
         .AppendFormatLine("  ,'{0}'", nombreModeloMotor)
         .AppendFormatLine("  , {0} ", idMarcaMotor)
         .AppendFormatLine("  )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ModelosMotores")
   End Sub

   Public Sub ModelosMotores_U(idModeloMotor As Integer,
                               nombreModeloMotor As String,
                               idMarcaMotor As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ModelosMotores ")
         .AppendFormatLine("   SET NombreModeloMotor = '{0}'", nombreModeloMotor)
         .AppendFormatLine("      ,idMarcaMotor = {0}", idMarcaMotor)
         .AppendFormatLine(" WHERE idModeloMotor = {0}", idModeloMotor)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ModelosMotores")
   End Sub

   Public Sub ModelosMotores_D(idModeloMotor As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM ModelosMotores ")
         .AppendFormatLine(" WHERE idModeloMotor = {0}", idModeloMotor)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ModelosMotores")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT MoM.IdModeloMotor")
         .AppendFormatLine("      ,MoM.NombreModeloMotor")
         .AppendFormatLine("      ,MoM.IdMarcaMotor")
         .AppendFormatLine("      ,MaM.NombreMarcaMotor")
         .AppendFormatLine("  FROM ModelosMotores MoM")
         .AppendFormatLine(" INNER JOIN MarcasMotores MaM ON MaM.IdMarcaMotor = MoM.IdMarcaMotor")
      End With
   End Sub

   Public Function ModelosMotores_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" ORDER BY MaM.NombreMarcaMotor, MoM.NombreModeloMotor")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ModelosMotores_GA(idMarcaMotor As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         If idMarcaMotor > 0 Then
            .AppendFormatLine(" WHERE MoM.IdMarcaMotor = {0}", idMarcaMotor)
         End If
         .AppendLine(" ORDER BY MaM.NombreMarcaMotor, MoM.NombreModeloMotor")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ModelosMotores_G1(idModeloMotor As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE MoM.IdModeloMotor = {0}", idModeloMotor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "MoM.",
                    New Dictionary(Of String, String) From {{"NombreMarcaMotor", "MoM.NombreMarcaMotor"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.ModeloMotor.Columnas.IdModeloMotor.ToString(), Entidades.ModeloMotor.NombreTabla).ToInteger()
   End Function

   '-.PE-31591.-
   Function GetPorModeloMotor(nombreModeloMotor As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ModeloMotor.Columnas.NombreModeloMotor.ToString(), nombreModeloMotor)
      End With
      Return GetDataTable(stb)
   End Function
End Class