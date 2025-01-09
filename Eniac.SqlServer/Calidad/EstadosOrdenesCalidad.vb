Public Class EstadosOrdenesCalidad
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosOrdenesCalidad_I(idEstadoCalidad As String, tipoEstadoCalidad As Entidades.EstadoOrdenCalidad.TiposEstadosCalidad,
                                      orden As Integer, backColor As Integer?, foreColor As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.EstadoOrdenCalidad.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString())
         .AppendFormatLine("   , {0}", Entidades.EstadoOrdenCalidad.Columnas.TipoEstadoCalidad.ToString())
         .AppendFormatLine("   , {0}", Entidades.EstadoOrdenCalidad.Columnas.Orden.ToString())
         .AppendFormatLine("   , {0}", Entidades.EstadoOrdenCalidad.Columnas.BackColor.ToString())
         .AppendFormatLine("   , {0}", Entidades.EstadoOrdenCalidad.Columnas.ForeColor.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	   '{0}'", idEstadoCalidad)
         .AppendFormatLine("	 , '{0}'", tipoEstadoCalidad)
         .AppendFormatLine("	 ,  {0} ", orden)
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(backColor))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(foreColor))
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub EstadosOrdenesCalidad_U(idEstadoCalidad As String, tipoEstadoCalidad As Entidades.EstadoOrdenCalidad.TiposEstadosCalidad,
                                      orden As Integer, backColor As Integer?, foreColor As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.EstadoOrdenCalidad.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.EstadoOrdenCalidad.Columnas.TipoEstadoCalidad.ToString(), tipoEstadoCalidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoOrdenCalidad.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoOrdenCalidad.Columnas.BackColor.ToString(), GetStringFromNumber(backColor))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoOrdenCalidad.Columnas.ForeColor.ToString(), GetStringFromNumber(foreColor))

         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString(), idEstadoCalidad)
      End With
      Execute(myQuery)
   End Sub

   Public Sub EstadosOrdenesCalidad_D(idEstadoCalidad As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.EstadoOrdenCalidad.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString(), idEstadoCalidad)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EOC.*")
         .AppendFormatLine("  FROM {0} AS EOC", Entidades.EstadoOrdenCalidad.NombreTabla)
      End With
   End Sub

   Private Function EstadosOrdenesCalidad_G(idEstadoCalidad As String, tipoEstadoCalidad As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idEstadoCalidad) Then
            .AppendFormatLine("   AND EOC.IdEstadoCalidad = '{0}'", idEstadoCalidad)
         End If
         If Not String.IsNullOrWhiteSpace(tipoEstadoCalidad) Then
            .AppendFormatLine("   AND EOC.TipoEstadoCalidad = '{0}'", tipoEstadoCalidad)
         End If
         .AppendLine(" ORDER BY EOC.Orden")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function EstadosOrdenesCalidad_GA() As DataTable
      Return EstadosOrdenesCalidad_G(idEstadoCalidad:=Nothing, tipoEstadoCalidad:=Nothing)
   End Function
   Public Function EstadosOrdenesCalidad_G1(idEstadoCalidad As String) As DataTable
      Return EstadosOrdenesCalidad_G(idEstadoCalidad, tipoEstadoCalidad:=Nothing)
   End Function

   Public Function EstadosOrdenesCalidad_GT(tipoEstadoCalidad As String) As DataTable
      Return EstadosOrdenesCalidad_G(idEstadoCalidad:=Nothing, tipoEstadoCalidad)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "EOC.") '',
   End Function

   Public Function GetOrdenMaximo() As Integer
      Return GetCodigoMaximo(Entidades.EstadoOrdenCalidad.Columnas.Orden.ToString(), Entidades.EstadoOrdenCalidad.NombreTabla).ToInteger()
   End Function

End Class