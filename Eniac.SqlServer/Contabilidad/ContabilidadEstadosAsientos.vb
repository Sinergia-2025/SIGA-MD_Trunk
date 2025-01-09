Public Class ContabilidadEstadosAsientos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ContabilidadEstadosAsientos_I(idEstadoAsiento As Integer, nombreEstadoAsiento As String,
                                            porDefectoManual As Boolean, porDefectoAutomatico As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.ContabilidadEstadoAsiento.NombreTabla)
         .AppendFormatLine("        {0} ", Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.ContabilidadEstadoAsiento.Columnas.NombreEstadoAsiento.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoManual.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoAutomatico.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("        {0} ", idEstadoAsiento)
         .AppendFormatLine("     , '{0}'", nombreEstadoAsiento)
         .AppendFormatLine("     ,  {0} ", GetStringFromBoolean(porDefectoManual))
         .AppendFormatLine("     ,  {0} ", GetStringFromBoolean(porDefectoAutomatico))
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ContabilidadEstadosAsientos_U(idEstadoAsiento As Integer, nombreEstadoAsiento As String,
                                            porDefectoManual As Boolean, porDefectoAutomatico As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ContabilidadEstadoAsiento.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ContabilidadEstadoAsiento.Columnas.NombreEstadoAsiento.ToString(), nombreEstadoAsiento)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoManual.ToString(), GetStringFromBoolean(porDefectoManual))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoAutomatico.ToString(), GetStringFromBoolean(porDefectoAutomatico))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString(), idEstadoAsiento)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ContabilidadEstadosAsientos_D(idEstadoAsiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.ContabilidadEstadoAsiento.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString(), idEstadoAsiento)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EA.*")
         .AppendFormatLine("  FROM {0} AS EA", Entidades.ContabilidadEstadoAsiento.NombreTabla)
      End With
   End Sub

   Public Function ContabilidadEstadosAsientos_G(idEstadoAsiento As Integer, idEstadoAsientoCeroTodos As Boolean, porDefectoManual As Boolean?, porDefectoAutomatico As Boolean?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idEstadoAsiento <> 0 OrElse Not idEstadoAsientoCeroTodos Then
            .AppendFormatLine("   AND EA.{0} = {1} ", Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString(), idEstadoAsiento)
         End If
         If porDefectoManual.HasValue Then
            .AppendFormatLine("   AND EA.{0} = {1} ", Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoManual.ToString(), GetStringFromBoolean(porDefectoManual.Value))
         End If
         If porDefectoAutomatico.HasValue Then
            .AppendFormatLine("   AND EA.{0} = {1} ", Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoAutomatico.ToString(), GetStringFromBoolean(porDefectoAutomatico.Value))
         End If
         .AppendFormatLine(" ORDER BY EA.{0}", Entidades.ContabilidadEstadoAsiento.Columnas.NombreEstadoAsiento.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ContabilidadEstadosAsientos_GA() As DataTable
      Return ContabilidadEstadosAsientos_G(idEstadoAsiento:=0, idEstadoAsientoCeroTodos:=True, porDefectoManual:=Nothing, porDefectoAutomatico:=Nothing)
   End Function

   Public Function ContabilidadEstadosAsientos_G1(idEstadoAsiento As Integer) As DataTable
      Return ContabilidadEstadosAsientos_G(idEstadoAsiento, idEstadoAsientoCeroTodos:=False, porDefectoManual:=Nothing, porDefectoAutomatico:=Nothing)
   End Function
   Public Function ContabilidadEstadosAsientos_G1_PorDefectoManual() As DataTable
      Return ContabilidadEstadosAsientos_G(idEstadoAsiento:=0, idEstadoAsientoCeroTodos:=True, porDefectoManual:=True, porDefectoAutomatico:=Nothing)
   End Function
   Public Function ContabilidadEstadosAsientos_G1_PorDefectoAutomatico() As DataTable
      Return ContabilidadEstadosAsientos_G(idEstadoAsiento:=0, idEstadoAsientoCeroTodos:=True, porDefectoManual:=Nothing, porDefectoAutomatico:=True)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "EA.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString(), Entidades.ContabilidadEstadoAsiento.NombreTabla).ToInteger()
   End Function

End Class