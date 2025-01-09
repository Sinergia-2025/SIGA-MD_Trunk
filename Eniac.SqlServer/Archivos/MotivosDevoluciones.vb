Public Class MotivosDevoluciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MotivosDevoluciones_I(idMotivoDevolucion As Integer,
                                    nombreMotivoDevolucion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO MotivosDevoluciones ({0},{1}) ",
                       Entidades.MotivoDevolucion.Columnas.IdMotivoDevolucion.ToString(),
                       Entidades.MotivoDevolucion.Columnas.NombreMotivoDevolucion.ToString())
         .AppendFormat(" VALUES ({0},'{1}')",
                       idMotivoDevolucion,
                       nombreMotivoDevolucion)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub MotivosDevoluciones_U(idMotivoDevolucion As Integer,
                                    nombreMotivoDevolucion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE MotivosDevoluciones")
         .AppendFormat("   SET {0} = '{1}'", Entidades.MotivoDevolucion.Columnas.NombreMotivoDevolucion.ToString(), nombreMotivoDevolucion)
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.MotivoDevolucion.Columnas.IdMotivoDevolucion.ToString(), idMotivoDevolucion)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub MotivosDevoluciones_D(ByVal idMotivoDevolucion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM MotivosDevoluciones ")
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.MotivoDevolucion.Columnas.IdMotivoDevolucion.ToString(), idMotivoDevolucion)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT MD.*")
         .AppendLine("  FROM MotivosDevoluciones MD ")
      End With
   End Sub

   Public Function MotivosDevoluciones_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" ORDER BY MD.{0}", Entidades.MotivoDevolucion.Columnas.NombreMotivoDevolucion.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function MotivosDevoluciones_G1(ByVal IdMotivoDevolucion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE MD.{0} = {1}", Entidades.MotivoDevolucion.Columnas.IdMotivoDevolucion.ToString(), IdMotivoDevolucion.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder()

      entidad.Columna = "MD." + entidad.Columna

      With stbQuery
         Me.SelectTexto(stbQuery)
         .AppendFormat(" WHERE {0} LIKE '%{1}%'", entidad.Columna, entidad.Valor)
      End With
      Return Me.GetDataTable(stbQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Dim dt As DataTable = GetDataTable("SELECT MAX(IdMotivosDevoluciones) AS MAXIMO FROM MotivosDevoluciones")
      Dim val As Integer = 0

      If dt.Rows.Count > 0 AndAlso Not String.IsNullOrEmpty(dt.Rows(0)("MAXIMO").ToString()) Then
         val = Integer.Parse(dt.Rows(0)("MAXIMO").ToString())
      End If

      Return val
   End Function

End Class
