Public Class CRMCiclosPlanificacionNovedades
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMCiclosPlanificacionNovedades_I(idCicloPlanificacion As Integer,
                                                idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long,
                                                orden As Integer, tipoPlanificacion As Entidades.CRMCicloPlanificacionNovedad.TiposPlanificacion, planificada As Boolean,
                                                idEstadoNovedadInicio As Integer?, idEstadoNovedadCierre As Integer?, idEstadoNovedadFinal As Integer?,
                                                idUsuarioAlta As String, fechaAlta As Date, idUsuarioActualizacion As String, fechaActualizacion As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CRMCicloPlanificacionNovedad.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdCicloPlanificacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdTipoNovedad.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.Letra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdNovedad.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.Orden.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.TipoPlanificacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.Planificada.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadInicio.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadCierre.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadFinal.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdUsuarioAlta.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.FechaAlta.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdUsuarioActualizacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CRMCicloPlanificacionNovedad.Columnas.FechaActualizacion.ToString())

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idCicloPlanificacion)
         .AppendFormatLine("	 , '{0}'", idTipoNovedad)
         .AppendFormatLine("	 , '{0}'", letra)
         .AppendFormatLine("	 ,  {0} ", centroEmisor)
         .AppendFormatLine("	 ,  {0} ", idNovedad)
         .AppendFormatLine("	 ,  {0} ", orden)
         .AppendFormatLine("	 , '{0}'", tipoPlanificacion.ToString())
         .AppendFormatLine("	 ,  {0} ", GetStringFromBoolean(planificada))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(idEstadoNovedadInicio))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(idEstadoNovedadCierre))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(idEstadoNovedadFinal))
         .AppendFormatLine("	 , '{0}'", idUsuarioAlta)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("	 , '{0}'", idUsuarioActualizacion)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaActualizacion, True))

         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMCiclosPlanificacionNovedades_U(idCicloPlanificacion As Integer,
                                                idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long,
                                                orden As Integer, tipoPlanificacion As Entidades.CRMCicloPlanificacionNovedad.TiposPlanificacion, planificada As Boolean,
                                                idEstadoNovedadInicio As Integer?, idEstadoNovedadCierre As Integer?, idEstadoNovedadFinal As Integer?,
                                                idUsuarioAlta As String, fechaAlta As Date, idUsuarioActualizacion As String, fechaActualizacion As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CRMCicloPlanificacionNovedad.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.Orden.ToString(), orden.ToString())
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.TipoPlanificacion.ToString(), tipoPlanificacion.ToString())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCicloPlanificacionNovedad.Columnas.Planificada.ToString(), GetStringFromBoolean(planificada))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadInicio.ToString(), GetStringFromNumber(idEstadoNovedadInicio))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadCierre.ToString(), GetStringFromNumber(idEstadoNovedadCierre))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdEstadoNovedadFinal.ToString(), GetStringFromNumber(idEstadoNovedadFinal))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdUsuarioAlta.ToString(), idUsuarioAlta)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.FechaAlta.ToString(), ObtenerFecha(fechaAlta, False))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdUsuarioActualizacion.ToString(), idUsuarioActualizacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.FechaActualizacion.ToString(), ObtenerFecha(fechaActualizacion, False))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdCicloPlanificacion.ToString(), idCicloPlanificacion)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMCicloPlanificacionNovedad.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdNovedad.ToString(), idNovedad)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMCiclosPlanificacionNovedades_D(idCicloPlanificacion As Integer,
                                                idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CRMCicloPlanificacionNovedad.NombreTabla)
         .AppendFormatLine(" WHERE 1 = 1")
         If idCicloPlanificacion <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdCicloPlanificacion.ToString(), idCicloPlanificacion)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMCicloPlanificacionNovedad.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.CRMCicloPlanificacionNovedad.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If idNovedad <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.CRMCicloPlanificacionNovedad.Columnas.IdNovedad.ToString(), idNovedad)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CPN.*")
         .AppendFormatLine("     , CP.{0}", Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString())
         .AppendFormatLine("     , CP.IdEstadoCicloPlanificacion")
         .AppendFormatLine("     , ECP.ForeColor")
         .AppendFormatLine("     , ECP.BackColor")
         .AppendFormatLine("     , CP.FechaInicio")
         .AppendFormatLine("     , CP.FechaCierre")
         .AppendFormatLine("     , CP.FechaFinalizacion")
         .AppendFormatLine("     , TN.NombreTipoNovedad")
         .AppendFormatLine("     , ENI.NombreEstadoNovedad NombreEstadoNovedadInicio")
         .AppendFormatLine("     , ENC.NombreEstadoNovedad NombreEstadoNovedadCierre")
         .AppendFormatLine("     , ENF.NombreEstadoNovedad NombreEstadoNovedadFinal")
         .AppendFormatLine("  FROM {0} AS CPN", Entidades.CRMCicloPlanificacionNovedad.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} AS CP ON CP.IdCicloPlanificacion = CPN.IdCicloPlanificacion", Entidades.CRMCicloPlanificacion.NombreTabla)
         .AppendFormatLine(" INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = CPN.IdTipoNovedad")
         .AppendFormatLine(" INNER JOIN CRMEstadosCiclosPlanificacion ECP ON ECP.IdEstadoCicloPlanificacion = CP.IdEstadoCicloPlanificacion")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades ENI ON ENI.IdEstadoNovedad = CPN.IdEstadoNovedadInicio")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades ENC ON ENC.IdEstadoNovedad = CPN.IdEstadoNovedadCierre")
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades ENF ON ENF.IdEstadoNovedad = CPN.IdEstadoNovedadFinal")
      End With
   End Sub

   Private Function CRMCiclosPlanificacionNovedades_G(idCicloPlanificacion As Integer, idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCicloPlanificacion <> 0 Then
            .AppendFormatLine("   AND CPN.IdCicloPlanificacion = {0}", idCicloPlanificacion)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND CPN.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND CPN.Letra = '{0}'", letra)
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine("   AND CPN.CentroEmisor = {0}", centroEmisor)
         End If
         If idNovedad <> 0 Then
            .AppendFormatLine("   AND CPN.IdNovedad = {0}", idNovedad)
         End If
         .AppendLine(" ORDER BY CP.NombreCicloPlanificacion, CPN.Orden")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function CRMCiclosPlanificacionNovedades_GA() As DataTable
      Return CRMCiclosPlanificacionNovedades_G(idCicloPlanificacion:=0, idTipoNovedad:=Nothing, letra:=Nothing, centroEmisor:=0, idNovedad:=0)
   End Function
   Public Function CRMCiclosPlanificacionNovedades_GA(idCicloPlanificacion As Integer) As DataTable
      Return CRMCiclosPlanificacionNovedades_G(idCicloPlanificacion, idTipoNovedad:=Nothing, letra:=Nothing, centroEmisor:=0, idNovedad:=0)
   End Function
   Public Function CRMCiclosPlanificacionNovedades_GA(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Return CRMCiclosPlanificacionNovedades_G(idCicloPlanificacion:=0, idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function
   Public Function CRMCiclosPlanificacionNovedades_G1(idCicloPlanificacion As Integer, idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Return CRMCiclosPlanificacionNovedades_G(idCicloPlanificacion, idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CPN.") '',
   End Function

   Public Overloads Function GetOrdenMaximo(idCicloPlanificacion As Integer) As Integer
      Return GetCodigoMaximo(Entidades.CRMCicloPlanificacionNovedad.Columnas.Orden.ToString(), Entidades.CRMCicloPlanificacionNovedad.NombreTabla,
                             String.Format("IdCicloPlanificacion = {0}", idCicloPlanificacion)).ToInteger()
   End Function

End Class