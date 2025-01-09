Public Class CRMCiclosPlanificacion
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMCiclosPlanificacion_I(idCicloPlanificacion As Integer,
                                       nombreCicloPlanificacion As String, idEstadoCicloPlanificacion As String,
                                       fechaInicio As Date, fechaCierre As Date, fechaFinalizacion As Date,
                                       idUsuarioAlta As String, fechaAlta As Date, idUsuarioActualizacion As String, fechaActualizacion As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CRMCicloPlanificacion.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CRMCicloPlanificacion.Columnas.IdCicloPlanificacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.FechaInicio.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.FechaCierre.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.FechaFinalizacion.ToString())

         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.IdUsuarioAlta.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.FechaAlta.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.IdUsuarioActualizacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacion.Columnas.FechaActualizacion.ToString())

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idCicloPlanificacion)
         .AppendFormatLine("	 , '{0}'", nombreCicloPlanificacion)
         .AppendFormatLine("	 , '{0}'", idEstadoCicloPlanificacion)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaInicio, False))
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaCierre, False))
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaFinalizacion, False))
         .AppendFormatLine("	 , '{0}'", idUsuarioAlta)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("	 , '{0}'", idUsuarioActualizacion)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaActualizacion, True))

         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMCiclosPlanificacion_U(idCicloPlanificacion As Integer,
                                       nombreCicloPlanificacion As String, idEstadoCicloPlanificacion As String,
                                       fechaInicio As Date, fechaCierre As Date, fechaFinalizacion As Date,
                                       idUsuarioAlta As String, fechaAlta As Date, idUsuarioActualizacion As String, fechaActualizacion As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CRMCicloPlanificacion.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString(), nombreCicloPlanificacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString(), idEstadoCicloPlanificacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.FechaInicio.ToString(), ObtenerFecha(fechaInicio, False))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.FechaCierre.ToString(), ObtenerFecha(fechaCierre, False))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.FechaFinalizacion.ToString(), ObtenerFecha(fechaFinalizacion, False))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.IdUsuarioAlta.ToString(), idUsuarioAlta)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.FechaAlta.ToString(), ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.IdUsuarioActualizacion.ToString(), idUsuarioActualizacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacion.Columnas.FechaActualizacion.ToString(), ObtenerFecha(fechaActualizacion, True))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CRMCicloPlanificacion.Columnas.IdCicloPlanificacion.ToString(), idCicloPlanificacion)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMCiclosPlanificacion_D(idCicloPlanificacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CRMCicloPlanificacion.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.CRMCicloPlanificacion.Columnas.IdCicloPlanificacion.ToString(), idCicloPlanificacion)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CP.*")
         .AppendFormatLine("     , ECP.BackColor")
         .AppendFormatLine("     , ECP.ForeColor")
         .AppendFormatLine("  FROM {0} AS CP", Entidades.CRMCicloPlanificacion.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} AS ECP ON ECP.IdEstadoCicloPlanificacion = CP.IdEstadoCicloPlanificacion", Entidades.CRMEstadoCicloPlanificacion.NombreTabla)
      End With
   End Sub

   Private Function CRMCiclosPlanificacion_G(idCicloPlanificacion As Integer, nombreCicloPlanificacion As String, nombreParcial As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCicloPlanificacion <> 0 Then
            .AppendFormatLine("   AND CP.IdCicloPlanificacion = {0}", idCicloPlanificacion)
         End If
         If Not String.IsNullOrWhiteSpace(nombreCicloPlanificacion) Then
            If nombreParcial Then
               .AppendFormatLine("   AND CP.NombreCicloPlanificacion LIKE '%{0}%'", nombreCicloPlanificacion)
            Else
               .AppendFormatLine("   AND CP.NombreCicloPlanificacion = '{0}'", nombreCicloPlanificacion)
            End If
         End If
         .AppendLine(" ORDER BY CP.NombreCicloPlanificacion")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function CRMCiclosPlanificacion_GA() As DataTable
      Return CRMCiclosPlanificacion_G(idCicloPlanificacion:=Nothing, nombreCicloPlanificacion:=Nothing, nombreParcial:=False)
   End Function
   Public Function CRMCiclosPlanificacion_G1(idCicloPlanificacion As Integer) As DataTable
      Return CRMCiclosPlanificacion_G(idCicloPlanificacion, nombreCicloPlanificacion:=Nothing, nombreParcial:=Nothing)
   End Function
   Public Function CRMCiclosPlanificacion_GA_PorNombre(nombreCicloPlanificacion As String) As DataTable
      Return CRMCiclosPlanificacion_G(idCicloPlanificacion:=Nothing, nombreCicloPlanificacion, nombreParcial:=True)
   End Function


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CP.") '',
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.CRMCicloPlanificacion.Columnas.IdCicloPlanificacion.ToString(), Entidades.CRMCicloPlanificacion.NombreTabla).ToInteger()
   End Function

End Class