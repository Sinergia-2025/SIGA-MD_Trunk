Public Class TurismoCursos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TurismoCursos_I(idCurso As Integer,
                                    nombreCurso As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO TurismoCursos ({0}, {1})",
                           Entidades.TurismoCurso.Columnas.IdCurso.ToString(),
                           Entidades.TurismoCurso.Columnas.NombreCurso.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}'",
                           idCurso, nombreCurso)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurismoCursos_U(idCurso As Integer,
                                    nombreCurso As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE TurismoCursos ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TurismoCurso.Columnas.NombreCurso.ToString(), nombreCurso)
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TurismoCurso.Columnas.IdCurso.ToString(), idCurso)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TurismoCursos_D(IdCurso As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM TurismoCursos WHERE {0} = '{1}'", Entidades.TurismoCurso.Columnas.IdCurso.ToString(), IdCurso)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EN.* ")
         .AppendFormatLine("  FROM TurismoCursos AS EN")

      End With
   End Sub

   Public Function TurismoCursos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" ORDER BY  EN.NombreCurso")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TurismoCursos_G1(IdCurso As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE EN.{0} = {1}", Entidades.TurismoCurso.Columnas.IdCurso.ToString(), IdCurso)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.TurismoCurso.Columnas.IdCurso.ToString(), "TurismoCursos"))
   End Function


End Class
