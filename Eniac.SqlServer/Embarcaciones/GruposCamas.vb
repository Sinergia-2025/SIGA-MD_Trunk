Public Class GruposCamas
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub GruposCamas_I(en As Entidades.GrupoCama)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO GruposCamas ({0}, {1})",
                           Entidades.GrupoCama.Columnas.IdGrupoCama.ToString(),
                           Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}')",
                           en.IdGrupoCama, en.NombreGrupoCama)
      End With
      Execute(myQuery)
   End Sub
   Public Sub GruposCamas_U(en As Entidades.GrupoCama)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE GruposCamas ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString(), en.NombreGrupoCama)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.GrupoCama.Columnas.IdGrupoCama.ToString(), en.IdGrupoCama)
      End With
      Execute(myQuery)
   End Sub
   Public Sub GruposCamas_D(idGrupoCama As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM GruposCamas ")
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.GrupoCama.Columnas.IdGrupoCama.ToString(), idGrupoCama)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT GC.{0}, GC.{1} FROM GruposCamas AS GC",
                           Entidades.GrupoCama.Columnas.IdGrupoCama.ToString(),
                           Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString())
      End With
   End Sub

   Public Function GruposCamas_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" ORDER BY GC.{0}", Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function GruposCamas_G1(idGrupoCama As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE GC.{0} = {1} ", Entidades.GrupoCama.Columnas.IdGrupoCama.ToString(), idGrupoCama)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "GC.")
   End Function
   Public Overloads Function GetCodigoMaximo(Campo As String) As Long
      Return GetCodigoMaximo(Campo, "GruposCamas", String.Format("{0} <> 999", Campo))
   End Function
End Class