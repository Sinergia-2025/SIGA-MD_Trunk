Public Class Modelos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Modelos_I(idModelo As Integer,
                        nombreModelo As String,
                        idMarca As Integer,
                        orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Modelos ")
         .AppendFormatLine("  (IdModelo")
         .AppendFormatLine("  ,NombreModelo")
         .AppendFormatLine("  ,IdMarca")
         .AppendFormatLine("  ,Orden")
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("   {0}", idModelo)
         .AppendFormatLine(" ,'{0}'", nombreModelo)
         .AppendFormatLine(" , {0} ", idMarca)
         .AppendFormatLine(" , {0} ", orden)
         .AppendFormatLine(" )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Modelos")
   End Sub

   Public Sub Modelos_U(idModelo As Integer,
                        nombreModelo As String,
                        idMarca As Integer,
                        orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Modelos")
         .AppendFormatLine("   SET NombreModelo = '{0}'", nombreModelo)
         .AppendFormatLine("     , IdMarca = {0}", idMarca)
         .AppendFormatLine("     , Orden = {0}", orden)
         .AppendFormatLine(" WHERE IdModelo = {0}", idModelo)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Modelos")
   End Sub

   Public Sub Modelos_D(idModelo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM Modelos ")
         .AppendFormatLine(" WHERE IdModelo = {0}", idModelo)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Modelos")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT M.*")
         .AppendFormatLine("      ,MC.NombreMarca ")
         .AppendFormatLine("  FROM Modelos M")
         .AppendFormatLine("  LEFT JOIN Marcas MC ON M.IdMarca = MC.IdMarca ")
      End With
   End Sub

   Public Function Modelos_GA() As DataTable
      Return Modelos_GA(idMarca:=0, idModelo:=0, nombreModelo:=String.Empty, nombreExacto:=False, marcas:=Nothing)
   End Function
   Public Function Modelos_GA(idMarca As Integer, idModelo As Integer) As DataTable
      Return Modelos_GA(idMarca, idModelo, nombreModelo:=String.Empty, nombreExacto:=False, marcas:=Nothing)
   End Function
   Public Function Modelos_GA(idMarca As Integer, nombreModelo As String) As DataTable
      Return Modelos_GA(idMarca, idModelo:=0, nombreModelo:=nombreModelo, nombreExacto:=False, marcas:=Nothing)
   End Function
   Public Function Modelos_GA(marcas As Entidades.Marca()) As DataTable
      Return Modelos_GA(idMarca:=0, idModelo:=0, nombreModelo:=String.Empty, nombreExacto:=False, marcas)
   End Function
   Public Function Modelos_GA(marcas As Entidades.Marca(), idModelo As Integer) As DataTable
      Return Modelos_GA(idMarca:=0, idModelo, nombreModelo:=String.Empty, nombreExacto:=False, marcas)
   End Function
   Public Function Modelos_GA(marcas As Entidades.Marca(), nombreModelo As String) As DataTable
      Return Modelos_GA(idMarca:=0, idModelo:=0, nombreModelo:=nombreModelo, nombreExacto:=False, marcas)
   End Function
   Private Function Modelos_GA(idMarca As Integer, idModelo As Integer, nombreModelo As String, nombreExacto As Boolean,
                               marcas As Entidades.Marca()) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idMarca > 0 Then
            .AppendFormatLine("   AND M.IdMarca = {0}", idMarca)
         End If
         If idModelo > 0 Then
            .AppendFormatLine("   AND M.IdModelo = {0}", idModelo)
         End If
         If Not String.IsNullOrWhiteSpace(nombreModelo) Then
            If nombreExacto Then
               .AppendFormatLine("   AND M.nombreModelo = '{0}' ", nombreModelo)
            Else
               .AppendFormatLine("   AND M.nombreModelo LIKE '%{0}%' ", nombreModelo)
            End If
         End If
         GetListaMarcasMultiples(myQuery, marcas, "M")
         .AppendFormatLine(" ORDER BY M.NombreModelo")
      End With

      Return GetDataTable(myQuery)
   End Function

   Public Function Modelos_G1(idModelo As Integer) As DataTable
      Return Modelos_GA(idMarca:=0, idModelo:=idModelo, nombreModelo:=String.Empty, nombreExacto:=False, marcas:=Nothing)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "M.",
                    New Dictionary(Of String, String) From {{"NombreMarca", "MC.NombreMarca"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdModelo", "Modelos"))
   End Function
   Public Overloads Function GetOrdenMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("Orden", "Modelos"))
   End Function

End Class