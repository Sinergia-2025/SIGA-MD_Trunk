Public Class Proyectos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Proyectos_I(idProyecto As Integer,
                          nombreProyecto As String,
                          idCliente As Long,
                          fechaInicio As DateTime,
                          fechaFin As DateTime,
                          estimado As Decimal,
                          presupuestado As Decimal,
                          idPrioridadImporte As Integer,
                          idPrioridadEstrategico As Integer,
                          idPrioridadComplejidad As Integer,
                          idPrioridadReplicabilidad As Integer,
                          idPrioridadProyecto As Decimal,
                          idClasificacion As Integer,
                          idEstado As Integer,
                          fechaFinReal As Date?,
                          hsRealEstimadas As Decimal,
                          hsInformadas As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO Proyectos")
         .Append("           (IdProyecto")
         .Append("           ,NombreProyecto")
         .Append("           ,IdCliente")
         .Append("           ,FechaInicio")
         .Append("           ,FechaFin")
         .Append("           ,Estimado")
         .Append("           ,Presupuestado")
         .Append("           ,IdPrioridadImporte")
         .Append("           ,IdPrioridadEstrategico")
         .Append("           ,IdPrioridadComplejidad")
         .Append("           ,IdPrioridadReplicabilidad")
         .Append("           ,IdPrioridadProyecto")
         .Append("           ,IdClasificacion")
         .Append("           ,IdEstado")
         .Append("           ,FechaFinReal")
         .Append("           ,HsRealEstimadas")
         .Append("           ,HsInformadas")
         .AppendLine(")     VALUES (")
         .AppendFormat("  {0}, '{1}', {2}, '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}",
                       idProyecto,
                       nombreProyecto,
                       idCliente,
                       fechaInicio.ToString("yyyyMMdd 00:00:00"),
                       fechaFin.ToString("yyyyMMdd 00:00:00"),
                       estimado,
                       presupuestado,
                       idPrioridadImporte,
                       idPrioridadEstrategico,
                       idPrioridadComplejidad,
                       idPrioridadReplicabilidad,
                       idPrioridadProyecto,
                       idClasificacion,
                       idEstado,
                       If(fechaFinReal.HasValue, String.Format("'{0}'", ObtenerFecha(fechaFinReal.Value, True)), "NULL"),
                       hsRealEstimadas,
                       hsInformadas)
         .Append(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Proyectos_U(idProyecto As Integer,
                          nombreProyecto As String,
                          idCliente As Long,
                          fechaInicio As DateTime,
                          fechaFin As DateTime,
                          estimado As Decimal,
                          presupuestado As Decimal,
                          idPrioridadImporte As Integer,
                          idPrioridadEstrategico As Integer,
                          idPrioridadComplejidad As Integer,
                          idPrioridadReplicabilidad As Integer,
                          idPrioridadProyecto As Decimal,
                          idClasificacion As Integer,
                          idEstado As Integer,
                          fechaFinReal As Date?,
                          hsRealEstimadas As Decimal,
                          hsInformadas As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Append("UPDATE Proyectos")
         .Append("   SET ")
         .AppendFormat("      [NombreProyecto] = '{0}'", nombreProyecto)
         .AppendFormat("      ,[IdCliente] = {0}", idCliente)
         .AppendFormat("      ,[FechaInicio] = '{0}'", fechaInicio.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("      ,[FechaFin] = '{0}'", fechaFin.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("      ,[Estimado] = {0}", estimado)
         .AppendFormat("      ,[Presupuestado] = {0}", presupuestado)
         .AppendFormat("      ,IdPrioridadImporte = {0}", idPrioridadImporte)
         .AppendFormat("      ,IdPrioridadEstrategico = {0}", idPrioridadEstrategico)
         .AppendFormat("      ,IdPrioridadComplejidad = {0}", idPrioridadComplejidad)
         .AppendFormat("      ,IdPrioridadReplicabilidad = {0}", idPrioridadReplicabilidad)
         .AppendFormat("      ,IdPrioridadProyecto = {0}", idPrioridadProyecto)
         .AppendFormat("      ,IdClasificacion = {0}", idClasificacion)
         .AppendFormat("      ,IdEstado = {0}", idEstado)

         If fechaFinReal.HasValue Then
            .AppendFormatLine("      ,FechaFinReal = '{0}'", ObtenerFecha(fechaFinReal.Value, True))
         Else
            .AppendFormatLine("      ,FechaFinReal = NULL")
         End If

         .AppendFormatLine("      ,HsRealEstimadas = {0}", hsRealEstimadas)
         .AppendFormatLine("      ,HsInformadas = {0}", hsInformadas)

         .AppendFormat(" WHERE [IdProyecto] = {0}", idProyecto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Proyectos_D(IdProyecto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM Proyectos WHERE {0} = {1}", Entidades.Proyecto.Columnas.IdProyecto.ToString(), IdProyecto)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, joinClienteVinculado As Boolean, idCliente As Long)
      With stb
         .AppendLine("SELECT P.IdProyecto")
         .AppendLine("      ,P.NombreProyecto")
         .AppendLine("      ,P.IdCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,P.FechaInicio")
         .AppendLine("      ,P.FechaFin")
         .AppendLine("      ,P.Estimado")
         .AppendLine("      ,ISNULL((SELECT SUM(H.Cantidad) FROM CRMNovedades H WHERE H.IdProyecto   = P.IdProyecto), 0) CantidadHorasHijos")
         .AppendLine("      ,P.Estimado - ISNULL((SELECT SUM(H.Cantidad) FROM CRMNovedades H WHERE H.IdProyecto   = P.IdProyecto), 0) AS DifHsCobradas")
         .AppendLine("      ,P.Presupuestado")
         .AppendLine("      ,P.IdPrioridadImporte")
         .AppendLine("      ,P.IdPrioridadEstrategico")
         .AppendLine("      ,P.IdPrioridadComplejidad")
         .AppendLine("      ,P.IdPrioridadReplicabilidad")
         .AppendLine("      ,CONVERT(DECIMAL(5,2), CONVERT(DECIMAL(5,2), (P.IdPrioridadImporte + P.IdPrioridadEstrategico + P.IdPrioridadComplejidad + P.IdPrioridadReplicabilidad)) / 4) AS IdPrioridadCalculada")
         .AppendLine("      ,P.IdPrioridadProyecto")
         .AppendLine("      ,P.IdClasificacion")
         .AppendLine("      ,CL.NombreClasificacion")
         .AppendLine("      ,P.IdEstado")
         .AppendLine("      ,PE.NombreEstado")
         .AppendLine("      ,P.FechaFinReal")
         .AppendLine("      ,P.HsRealEstimadas")
         .AppendLine("      ,P.HsInformadas")
         .AppendLine("      ,P.HsInformadas - ISNULL((SELECT SUM(H.Cantidad) FROM CRMNovedades H WHERE H.IdProyecto   = P.IdProyecto), 0) AS DifHsInformadas")
         .AppendLine("      ,PE.Finalizado")
         .AppendFormatLine(",ISNULL((SELECT SUM(CN.TiempoEstimado) FROM CRMNovedades CN WHERE CN.IdProyecto = P.IdProyecto AND CN.IdTipoNovedad = 'REQUER'),0) EstimadoRequerimientos") '# Se decidio que vaya hardcodeado
         .AppendFormatLine(",ISNULL((SELECT SUM(CN.TiempoEstimado) FROM CRMNovedades CN WHERE CN.IdProyecto = P.IdProyecto AND CN.IdTipoNovedad = 'PENDIENTE'),0) EstimadoPendientes") '# Se decidio que vaya hardcodeado
         .AppendLine("  FROM Proyectos P ")
         .AppendLine("  LEFT JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         If joinClienteVinculado Then
            If idCliente > 0 Then
               .AppendFormatLine("  LEFT JOIN Clientes CV ON P.IdCliente = CV.IdClienteCtaCte AND CV.IdCliente = {0}", idCliente)
            Else
               .AppendFormatLine("  LEFT JOIN Clientes CV ON P.IdCliente = CV.IdClienteCtaCte")
            End If
         End If
         .AppendLine(" INNER JOIN Clasificaciones CL ON P.IdClasificacion = CL.IdClasificacion ")
         .AppendLine(" INNER JOIN ProyectosEstados PE ON P.IdEstado = PE.IdEstado ")
      End With
   End Sub

   Public Function Proyectos_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery, joinClienteVinculado:=False, idCliente:=0)
         .AppendLine("  ORDER BY P.IdPrioridadProyecto, C.NombreCliente,P.IdProyecto")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Proyectos_G1(IdProyecto As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb, joinClienteVinculado:=False, idCliente:=0)
         .AppendFormat(" WHERE {0} = {1}", Entidades.Proyecto.Columnas.IdProyecto.ToString(), IdProyecto)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb, joinClienteVinculado:=False, idCliente:=0)
         If columna = "NombreEstado" Then
            columna = "PE." + columna
         ElseIf columna = "NombreCliente" Then
            columna = "C." + columna
         ElseIf columna = "NombreDeFantasia" Then
            columna = "C." + columna
         ElseIf columna = "NombreClasificacion" Then
            columna = "CL." + columna
         Else
            columna = "P." + columna
         End If
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetFiltradoPorCodigoNombre(IdProyecto As Integer?, nombre As String, idCliente As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      If idCliente.HasValue Then
         Me.SelectTexto(stb, joinClienteVinculado:=True, idCliente:=idCliente.Value)
      Else
         Me.SelectTexto(stb, joinClienteVinculado:=False, idCliente:=0)
      End If
      With stb
         .AppendFormatLine(" WHERE 1 = 1")
         '.AppendFormat(" WHERE P.Estado = '{0}' ", Entidades.Proyecto.Estados.Ejecutando.ToString())
         If IdProyecto.HasValue Then
            .AppendFormat(" AND P.IdProyecto = {0}", IdProyecto.Value)
         End If
         If Not String.IsNullOrEmpty(nombre) Then
            .AppendFormat(" AND P.NombreProyecto LIKE '%{0}%'", nombre)
         End If
         If idCliente.HasValue Then
            '.AppendFormat(" AND P.IdCliente = {0}", idCliente.Value)
            .AppendFormat(" AND (P.IdCliente = {0} OR CV.IdCliente = {0})", idCliente.Value)
         End If
         '.Append(" ORDER BY P.IdProyecto ")
         .Append(" ORDER BY PE.Posicion ")

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.Proyecto.Columnas.IdProyecto.ToString(), "Proyectos"))
   End Function

   Public Function Existe(idProyecto As Integer) As Boolean

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query, joinClienteVinculado:=False, idCliente:=0)
         .AppendFormat(" WHERE IdProyecto = {0}", idProyecto)
      End With
      If (Me.GetDataTable(query.ToString())).Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If

   End Function

End Class
