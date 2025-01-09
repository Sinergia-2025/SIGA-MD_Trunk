Public Class CRMEstadosCiclosPlanificacion
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMEstadosCiclosPlanificacion_I(idEstadoCicloPlanificacion As String, tipoEstadoCicloPlanificacion As Entidades.CRMEstadoCicloPlanificacion.TiposEstadosCicloPlanificacion,
                                              orden As Integer, porDefecto As Boolean, backColor As Integer?, foreColor As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CRMEstadoCicloPlanificacion.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMEstadoCicloPlanificacion.Columnas.TipoEstadoCicloPlanificacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMEstadoCicloPlanificacion.Columnas.Orden.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMEstadoCicloPlanificacion.Columnas.PorDefecto.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMEstadoCicloPlanificacion.Columnas.BackColor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMEstadoCicloPlanificacion.Columnas.ForeColor.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	   '{0}'", idEstadoCicloPlanificacion)
         .AppendFormatLine("	 , '{0}'", tipoEstadoCicloPlanificacion)
         .AppendFormatLine("	 ,  {0} ", orden)
         .AppendFormatLine("	 ,  {0} ", GetStringFromBoolean(porDefecto))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(backColor))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(foreColor))
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMEstadosCiclosPlanificacion_U(idEstadoCicloPlanificacion As String, tipoEstadoCicloPlanificacion As Entidades.CRMEstadoCicloPlanificacion.TiposEstadosCicloPlanificacion,
                                              orden As Integer, porDefecto As Boolean, backColor As Integer?, foreColor As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CRMEstadoCicloPlanificacion.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMEstadoCicloPlanificacion.Columnas.TipoEstadoCicloPlanificacion.ToString(), tipoEstadoCicloPlanificacion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoCicloPlanificacion.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoCicloPlanificacion.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoCicloPlanificacion.Columnas.BackColor.ToString(), GetStringFromNumber(backColor))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMEstadoCicloPlanificacion.Columnas.ForeColor.ToString(), GetStringFromNumber(foreColor))

         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString(), idEstadoCicloPlanificacion)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMEstadosCiclosPlanificacion_D(idEstadoCicloPlanificacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CRMEstadoCicloPlanificacion.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString(), idEstadoCicloPlanificacion)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ECP.*")
         .AppendFormatLine("  FROM {0} AS ECP", Entidades.CRMEstadoCicloPlanificacion.NombreTabla)
      End With
   End Sub

   Private Function CRMEstadosCiclosPlanificacion_G(idEstadoCicloPlanificacion As String, tipoEstadoCicloPlanificacion As Entidades.CRMEstadoCicloPlanificacion.TiposEstadosCicloPlanificacion?,
                                                    porDefecto As Boolean?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idEstadoCicloPlanificacion) Then
            .AppendFormatLine("   AND ECP.IdEstadoCicloPlanificacion = '{0}'", idEstadoCicloPlanificacion)
         End If
         If tipoEstadoCicloPlanificacion.HasValue Then
            .AppendFormatLine("   AND ECP.TipoEstadoCicloPlanificacion = '{0}'", tipoEstadoCicloPlanificacion.Value)
         End If
         If porDefecto.HasValue Then
            .AppendFormatLine("   AND ECP.PorDefecto = {0}", GetStringFromBoolean(porDefecto))
         End If
         .AppendLine(" ORDER BY ECP.Orden")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function CRMEstadosCiclosPlanificacion_GA() As DataTable
      Return CRMEstadosCiclosPlanificacion_G(idEstadoCicloPlanificacion:=Nothing, tipoEstadoCicloPlanificacion:=Nothing, porDefecto:=Nothing)
   End Function
   Public Function CRMEstadosCiclosPlanificacion_G1(idEstadoCicloPlanificacion As String) As DataTable
      Return CRMEstadosCiclosPlanificacion_G(idEstadoCicloPlanificacion, tipoEstadoCicloPlanificacion:=Nothing, porDefecto:=Nothing)
   End Function

   Public Function CRMEstadosCiclosPlanificacion_GA(tipoEstadoCicloPlanificacion As Entidades.CRMEstadoCicloPlanificacion.TiposEstadosCicloPlanificacion) As DataTable
      Return CRMEstadosCiclosPlanificacion_G(idEstadoCicloPlanificacion:=Nothing, tipoEstadoCicloPlanificacion, porDefecto:=Nothing)
   End Function

   Public Function CRMEstadosCiclosPlanificacion_GA(porDefecto As Boolean) As DataTable
      Return CRMEstadosCiclosPlanificacion_G(idEstadoCicloPlanificacion:=Nothing, tipoEstadoCicloPlanificacion:=Nothing, porDefecto)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "ECP.") '',
   End Function

   Public Function GetOrdenMaximo() As Integer
      Return GetCodigoMaximo(Entidades.CRMEstadoCicloPlanificacion.Columnas.Orden.ToString(), Entidades.CRMEstadoCicloPlanificacion.NombreTabla).ToInteger()
   End Function

End Class