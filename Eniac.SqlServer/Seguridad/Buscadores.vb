Public Class Buscadores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Buscadores_I(idBuscador As Integer,
                           titulo As String, anchoAyuda As Integer,
                           iniciaConFocoEn As Entidades.Buscador.IniciaConFocoEnList, columaBusquedaInicial As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO Buscadores(")
         .AppendFormatLine("     IdBuscador")
         .AppendFormatLine("   , Titulo")
         .AppendFormatLine("   , AnchoAyuda")
         .AppendFormatLine("   , IniciaConFocoEn")
         .AppendFormatLine("   , ColumaBusquedaInicial")
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("  {0} ", idBuscador)
         .AppendFormatLine(",'{0}'", titulo)
         .AppendFormatLine(", {0} ", anchoAyuda)
         .AppendFormatLine(",'{0}'", iniciaConFocoEn.ToString())
         .AppendFormatLine(",'{0}'", columaBusquedaInicial)
         .AppendLine(")")
      End With
      Execute(query)
   End Sub
   Public Sub Buscadores_U(idBuscador As Integer,
                           titulo As String, anchoAyuda As Integer,
                           iniciaConFocoEn As Entidades.Buscador.IniciaConFocoEnList, columaBusquedaInicial As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE Buscadores")
         .AppendFormatLine("   SET Titulo = '{0}'", titulo)
         .AppendFormatLine("     , AnchoAyuda =  {0} ", anchoAyuda)
         .AppendFormatLine("     , IniciaConFocoEn = '{0}'", iniciaConFocoEn.ToString())
         .AppendFormatLine("     , ColumaBusquedaInicial = '{0}'", columaBusquedaInicial)
         .AppendFormatLine(" WHERE IdBuscador = {0}", idBuscador)
      End With
      Execute(query)
   End Sub
   Public Sub Buscadores_D(idBuscador As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormat("DELETE FROM Buscadores WHERE IdBuscador = {0}", idBuscador)
      End With
      Execute(query)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT B.*")
         .AppendLine("     , (SELECT COUNT(1) FROM BuscadoresCampos BC WHERE BC.IdBuscador = B.IdBuscador) CantidadColumnas")
         .AppendLine("  FROM Buscadores B")
      End With
   End Sub

   Public Function Buscadores_GA() As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendLine(" ORDER BY B.Titulo")
      End With
      Return GetDataTable(query)
   End Function
   Public Function Buscadores_G1(idBuscador As Integer) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendFormat(" WHERE B.IdBuscador = {0}", idBuscador)
      End With
      Return GetDataTable(query)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "B.")
   End Function

   Public Function GetBuscador(titulo As String, idBuscador As Integer?) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT B.*")
         .AppendLine("  FROM Buscadores B")
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(titulo) Then
            .AppendFormatLine("   AND B.Titulo = '{0}'", titulo)
         End If
         If idBuscador.HasValue Then
            .AppendFormatLine("   AND B.IdBuscador = {0}", idBuscador)
         End If
      End With
      Return GetDataTable(stbQuery)
   End Function
End Class