Public Class PlazosEntregas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PlazosEntregas_I(idPlazoEntrega As Integer,
                               descripcion As String,
                               activo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3})",
                       Entidades.PlazoEntrega.NombreTabla,
                       Entidades.PlazoEntrega.Columnas.IdPlazoEntrega.ToString(),
                       Entidades.PlazoEntrega.Columnas.DescripcionPlazoentrega.ToString(),
                       Entidades.PlazoEntrega.Columnas.ActivoPlazoEntrega.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2}", idPlazoEntrega, descripcion, GetStringFromBoolean(activo))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub PlazosEntregas_U(idPlazoEntrega As Integer,
                               descripcion As String,
                               activo As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.PlazoEntrega.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.PlazoEntrega.Columnas.DescripcionPlazoentrega.ToString(), descripcion).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.PlazoEntrega.Columnas.ActivoPlazoEntrega.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.PlazoEntrega.Columnas.IdPlazoEntrega.ToString(), idPlazoEntrega).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub PlazosEntregas_D(idPlazoEntrega As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.PlazoEntrega.NombreTabla, Entidades.PlazoEntrega.Columnas.IdPlazoEntrega.ToString(), idPlazoEntrega)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PE.* FROM {0} AS PE", Entidades.PlazoEntrega.NombreTabla).AppendLine()
      End With
   End Sub
   Public Function PlazosEntregas_G1(IdPlazoEntrega As Integer) As DataTable
      Return PlazosEntregas_G(IdPlazoEntrega:=IdPlazoEntrega, descripcion:=String.Empty)
   End Function
   Private Function PlazosEntregas_G(IdPlazoEntrega As Integer, descripcion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat("   WHERE 1 = 1").AppendLine()
         If IdPlazoEntrega <> 0 Then
            .AppendFormat("   AND PE.IdPlazoEntrega = {0}", IdPlazoEntrega).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat("   AND PE.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "PE." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function PlazosEntregas_GA() As DataTable
      Return PlazosEntregas_G(IdPlazoEntrega:=0, descripcion:=String.Empty)
   End Function
   Public Overloads Function GetCodigoMaximo() As Short
      Return Convert.ToInt16(GetCodigoMaximo(Entidades.PlazoEntrega.Columnas.IdPlazoEntrega.ToString(), "PlazosEntregas"))
   End Function
   Public Function GetFiltradoPorCodigo(codigo As Integer) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         SelectTexto(stbQuery)
         If codigo > 0 Then
            .AppendFormat(" WHERE PE.IdPlazoEntrega = {0}", codigo)
         End If
         .AppendLine(" ORDER BY PE.IdPlazoEntrega")
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      Return dt
   End Function
   Public Function GetFiltradoPorDescripcion(descripcion As String) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         SelectTexto(stbQuery)
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat(" WHERE PE.Descripcion LIKE '%{0}%' ", descripcion)
         End If
         .AppendLine(" ORDER BY PE.IdPlazoEntrega")
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      Return dt
   End Function

End Class
