Public Class TiposObservaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposObservaciones_I(idObservaciones As Short,
                                   descripcion As String,
                                   activa As Boolean, porDefecto As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4})",
                       Entidades.TipoObservacion.NombreTabla,
                       Entidades.TipoObservacion.Columnas.IdObservaciones.ToString(),
                       Entidades.TipoObservacion.Columnas.Descripcion.ToString(),
                       Entidades.TipoObservacion.Columnas.Activa.ToString(),
                       Entidades.TipoObservacion.Columnas.PorDefecto.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2}, {3}", idObservaciones, descripcion, GetStringFromBoolean(activa), GetStringFromBoolean(porDefecto))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TiposObservaciones_U(idObservaciones As Short,
                                   descripcion As String,
                                   activa As Boolean, porDefecto As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.TipoObservacion.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.TipoObservacion.Columnas.Descripcion.ToString(), descripcion).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.TipoObservacion.Columnas.Activa.ToString(), GetStringFromBoolean(activa)).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.TipoObservacion.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TipoObservacion.Columnas.IdObservaciones.ToString(), idObservaciones).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TiposObservaciones_D(idObservaciones As Short)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.TipoObservacion.NombreTabla, Entidades.TipoObservacion.Columnas.IdObservaciones.ToString(), idObservaciones)
      End With
      Me.Execute(myQuery.ToString())
   End Sub


   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT TOB.* FROM {0} AS TOB", Entidades.TipoObservacion.NombreTabla).AppendLine()
      End With
   End Sub
   Public Function TiposObservaciones_G1(idObservacion As Short) As DataTable
      Return TiposObservaciones_G(idObservacion:=idObservacion, descripcion:=String.Empty, False)
   End Function

   Private Function TiposObservaciones_G(idObservacion As Short, descripcion As String, activa As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat("   WHERE 1 = 1").AppendLine()
         If idObservacion <> 0 Then
            .AppendFormat("   AND TOB.IdObservaciones = {0}", idObservacion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat("   AND TOB.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
         End If
         If activa Then
            .AppendFormat("   AND TOB.Activa = {0} ", GetStringFromBoolean(activa)).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "TOB." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function TiposObservaciones_GA(activa As Boolean) As DataTable
      Return TiposObservaciones_G(idObservacion:=0, descripcion:=String.Empty, activa)
   End Function
   Public Overloads Function GetCodigoMaximo() As Short
      Return Convert.ToInt16(GetCodigoMaximo(Entidades.TipoObservacion.Columnas.IdObservaciones.ToString(), "TiposObservaciones"))
   End Function
   Public Function GetFiltradoPorCodigo(codigo As Short) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         SelectTexto(stbQuery)
         If codigo > 0 Then
            .AppendFormat(" WHERE TOB.IdObservaciones = {0}", codigo)
         End If
         .AppendLine(" ORDER BY TOB.IdObservaciones")
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      Return dt
   End Function
   Public Function GetFiltradoPorDescripcion(descripcion As String) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         SelectTexto(stbQuery)
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat(" WHERE TOB.Descripcion LIKE '%{0}%' ", descripcion)
         End If
         .AppendLine(" ORDER BY TOB.IdObservaciones")
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      Return dt
   End Function

   Public Function GetIdTipoObservacionDefecto() As Short
      Dim result As Short

      Dim stb = New StringBuilder()
      With stb
         .AppendFormat("SELECT {0} FROM {1} WHERE PorDefecto = 1 AND Activa = 1", Entidades.TipoObservacion.Columnas.IdObservaciones.ToString(),
                                                     Entidades.TipoObservacion.NombreTabla)
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 AndAlso Short.TryParse(dt.Rows(0)("IdObservaciones").ToString(), result) Then
         result = Short.Parse(dt.Rows(0)("IdObservaciones").ToString())
      Else
         Throw New Exception("No se ha definido un Tipo de Observaciones por Defecto")
      End If
      Return result

   End Function

End Class
