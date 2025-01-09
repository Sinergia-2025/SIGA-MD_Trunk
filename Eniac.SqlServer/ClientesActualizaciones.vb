Public Class ClientesActualizaciones
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub ClientesActualizaciones_I(idCliente As Long,
                                        nombreServidor As String,
                                        baseDatos As String,
                                        fechaEjecucion As DateTime,
                                        fechaInicioActualizacion As DateTime?,
                                        fechaFinActualizacion As DateTime?,
                                        idUnico As String,
                                        estado As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoDescargaScripts As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoDescargaInstalador As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoBackup As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoEjecucionScripts As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoEjecucionInstalador As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        activo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.ClienteActualizacion.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.ClienteActualizacion.Columnas.IdCliente.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.IdUnico.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.Estado.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.EstadoDescargaScripts.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.EstadoDescargaInstalador.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.EstadoBackup.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionScripts.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionInstalador.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacion.Columnas.Activo.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idCliente)
         .AppendFormatLine("           ,'{0}'", nombreServidor)
         .AppendFormatLine("           ,'{0}'", baseDatos)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaEjecucion, True))
         If fechaInicioActualizacion.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaInicioActualizacion.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If
         If fechaFinActualizacion.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaFinActualizacion.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If

         .AppendFormatLine("           ,'{0}'", idUnico.ToString())
         .AppendFormatLine("           ,'{0}'", estado.ToString())
         .AppendFormatLine("           ,'{0}'", estadoDescargaScripts.ToString())
         .AppendFormatLine("           ,'{0}'", estadoDescargaInstalador.ToString())
         .AppendFormatLine("           ,'{0}'", estadoBackup.ToString())
         .AppendFormatLine("           ,'{0}'", estadoEjecucionScripts.ToString())
         .AppendFormatLine("           ,'{0}'", estadoEjecucionInstalador.ToString())

         .AppendFormatLine("           ,{0}", GetStringFromBoolean(activo))
         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesActualizaciones_U(idCliente As Long,
                                        nombreServidor As String,
                                        baseDatos As String,
                                        fechaEjecucion As DateTime,
                                        fechaInicioActualizacion As DateTime?,
                                        fechaFinActualizacion As DateTime?,
                                        idUnico As String,
                                        estado As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoDescargaScripts As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoDescargaInstalador As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoBackup As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoEjecucionScripts As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        estadoEjecucionInstalador As Entidades.ClienteActualizacion.EstadoActualizacion,
                                        activo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ClienteActualizacion.NombreTabla)
         If fechaInicioActualizacion.HasValue Then
            .AppendFormatLine("   SET {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString(), ObtenerFecha(fechaInicioActualizacion.Value, True))
         Else
            .AppendFormatLine("   SET {0} = NULL", Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString())
         End If
         If fechaFinActualizacion.HasValue Then
            .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString(), ObtenerFecha(fechaFinActualizacion.Value, True))
         Else
            .AppendFormatLine("      ,{0} = NULL", Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString())
         End If
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.IdUnico.ToString(), idUnico.ToString())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.Estado.ToString(), estado.ToString())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.EstadoDescargaScripts.ToString(), estadoDescargaScripts.ToString())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.EstadoDescargaInstalador.ToString(), estadoDescargaInstalador.ToString())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.EstadoBackup.ToString(), estadoBackup.ToString())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionScripts.ToString(), estadoEjecucionScripts.ToString())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionInstalador.ToString(), estadoEjecucionInstalador.ToString())
         .AppendFormatLine("      ,{0} = {1}", Entidades.ClienteActualizacion.Columnas.Activo.ToString(), GetStringFromBoolean(activo))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteActualizacion.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion, True))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesActualizaciones_U_Activo(idCliente As Long,
                                               nombreServidor As String,
                                               baseDatos As String,
                                               fechaEjecucion As DateTime,
                                               activo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ClienteActualizacion.NombreTabla)
         .AppendFormatLine("   SET {0} = {1}", Entidades.ClienteActualizacion.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteActualizacion.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion, True))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesActualizaciones_M(idCliente As Long,
                                        nombreServidor As String,
                                        baseDatos As String,
                                        fechaEjecucion As DateTime,
                                        fechaInicioActualizacion As DateTime?,
                                        fechaFinActualizacion As DateTime?,
                                        idUnico As String,
                                        estado As Entidades.ClienteActualizacion.EstadoActualizacion?,
                                        estadoDescargaScripts As Entidades.ClienteActualizacion.EstadoActualizacion?,
                                        estadoDescargaInstalador As Entidades.ClienteActualizacion.EstadoActualizacion?,
                                        estadoBackup As Entidades.ClienteActualizacion.EstadoActualizacion?,
                                        estadoEjecucionScripts As Entidades.ClienteActualizacion.EstadoActualizacion?,
                                        estadoEjecucionInstalador As Entidades.ClienteActualizacion.EstadoActualizacion?,
                                        activo As Boolean?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO ClientesActualizaciones AS D")
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.ClienteActualizacion.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion, True))
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.IdUnico.ToString(), idUnico)
         If fechaInicioActualizacion.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString(), ObtenerFecha(fechaInicioActualizacion.Value, True))
         Else
            .AppendFormatLine("                    , NULL  AS {0}", Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString())
         End If
         If fechaFinActualizacion.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString(), ObtenerFecha(fechaFinActualizacion.Value, True))
         Else
            .AppendFormatLine("                    , NULL  AS {0}", Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString())
         End If
         If estado.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.Estado.ToString(), estado.ToString())
         End If
         If estadoDescargaScripts.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.EstadoDescargaScripts.ToString(), estadoDescargaScripts.ToString())
         End If
         If estadoDescargaInstalador.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.EstadoDescargaInstalador.ToString(), estadoDescargaInstalador.ToString())
         End If
         If estadoBackup.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.EstadoBackup.ToString(), estadoBackup.ToString())
         End If
         If estadoEjecucionScripts.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionScripts.ToString(), estadoEjecucionScripts.ToString())
         End If
         If estadoEjecucionInstalador.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionInstalador.ToString(), estadoEjecucionInstalador.ToString())
         End If
         If activo.HasValue Then
            .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ClienteActualizacion.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         End If

         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1} AND O.{2} = D.{2} AND O.{3} = D.{3}",
                           Entidades.ClienteActualizacion.Columnas.IdCliente.ToString(),
                           Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = O.{0}, D.{1} = O.{1}, D.{2} = O.{2}",
                           Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString(),
                           Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString(),
                           Entidades.ClienteActualizacion.Columnas.IdUnico.ToString())
         If estado.HasValue Then
            .AppendFormatLine("                 , D.{0} = O.{0}", Entidades.ClienteActualizacion.Columnas.Estado.ToString())
         End If
         If estadoDescargaScripts.HasValue Then
            .AppendFormatLine("                 , D.{0} = O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoDescargaScripts.ToString())
         End If
         If estadoDescargaInstalador.HasValue Then
            .AppendFormatLine("                 , D.{0} = O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoDescargaInstalador.ToString())
         End If
         If estadoBackup.HasValue Then
            .AppendFormatLine("                 , D.{0} = O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoBackup.ToString())
         End If
         If estadoEjecucionScripts.HasValue Then
            .AppendFormatLine("                 , D.{0} = O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionScripts.ToString())
         End If
         If estadoEjecucionInstalador.HasValue Then
            .AppendFormatLine("                 , D.{0} = O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionInstalador.ToString())
         End If
         If activo.HasValue Then
            .AppendFormatLine("                 , D.{0} = O.{0}", Entidades.ClienteActualizacion.Columnas.Activo.ToString())
         End If

         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormat("        INSERT ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13})",
                           Entidades.ClienteActualizacion.Columnas.IdCliente.ToString(),
                           Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString(),
                           Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString(),
                           Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString(),
                           Entidades.ClienteActualizacion.Columnas.IdUnico.ToString(),
                           Entidades.ClienteActualizacion.Columnas.Estado.ToString(),
                           Entidades.ClienteActualizacion.Columnas.EstadoDescargaScripts.ToString(),
                           Entidades.ClienteActualizacion.Columnas.EstadoDescargaInstalador.ToString(),
                           Entidades.ClienteActualizacion.Columnas.EstadoBackup.ToString(),
                           Entidades.ClienteActualizacion.Columnas.EstadoEjecucionScripts.ToString(),
                           Entidades.ClienteActualizacion.Columnas.EstadoEjecucionInstalador.ToString(),
                           Entidades.ClienteActualizacion.Columnas.Activo.ToString())

         .AppendFormat("VALUES (O.{0}, O.{1}, O.{2}, O.{3}, O.{4}, O.{5}, O.{6}",
                           Entidades.ClienteActualizacion.Columnas.IdCliente.ToString(),
                           Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString(),
                           Entidades.ClienteActualizacion.Columnas.FechaInicioActualizacion.ToString(),
                           Entidades.ClienteActualizacion.Columnas.FechaFinActualizacion.ToString(),
                           Entidades.ClienteActualizacion.Columnas.IdUnico.ToString())

         If estado.HasValue Then
            .AppendFormat(", O.{0}", Entidades.ClienteActualizacion.Columnas.Estado.ToString())
         Else
            .AppendFormat(", '{0}'", Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         End If
         If estadoDescargaScripts.HasValue Then
            .AppendFormat(", O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoDescargaScripts.ToString())
         Else
            .AppendFormat(", '{0}'", Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         End If
         If estadoDescargaInstalador.HasValue Then
            .AppendFormat(", O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoDescargaInstalador.ToString())
         Else
            .AppendFormat(", '{0}'", Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         End If
         If estadoBackup.HasValue Then
            .AppendFormat(", O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoBackup.ToString())
         Else
            .AppendFormat(", '{0}'", Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         End If
         If estadoEjecucionScripts.HasValue Then
            .AppendFormat(", O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionScripts.ToString())
         Else
            .AppendFormat(", '{0}'", Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         End If
         If estadoEjecucionInstalador.HasValue Then
            .AppendFormat(", O.{0}", Entidades.ClienteActualizacion.Columnas.EstadoEjecucionInstalador.ToString())
         Else
            .AppendFormat(", '{0}'", Entidades.ClienteActualizacion.EstadoActualizacion.Pendiente)
         End If
         If activo.HasValue Then
            .AppendFormat(", O.{0}", Entidades.ClienteActualizacion.Columnas.Activo.ToString())
         Else
            .AppendFormat(", '{0}'", Boolean.TrueString)
         End If

         .AppendLine(")")

         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesActualizaciones_D(idCliente As Long)
      ClientesActualizaciones_D(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing)
   End Sub
   Public Sub ClientesActualizaciones_D(idCliente As Long,
                                        nombreServidor As String,
                                        baseDatos As String,
                                        fechaEjecucion As DateTime?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.ClienteActualizacion.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteActualizacion.Columnas.IdCliente.ToString(), idCliente)
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If fechaEjecucion.HasValue Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion.Value, True))
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
#End Region

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CA.*, C.{0}, C.{1}", Entidades.Cliente.Columnas.CodigoCliente.ToString(), Entidades.Cliente.Columnas.NombreCliente.ToString())
         .AppendFormatLine("  FROM {0} AS CA", Entidades.ClienteActualizacion.NombreTabla)
         .AppendFormatLine(" INNER JOIN Clientes AS C ON C.IdCliente = CA.IdCliente")
      End With
   End Sub

#Region "GetAll"
   Public Function ClientesActualizaciones_GA() As DataTable
      Return ClientesActualizaciones_G(idCliente:=0, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing)
   End Function
   Public Function InfClientesActualizaciones(idCliente As Long) As DataTable
      Return ClientesActualizaciones_G(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing)
   End Function
   Private Function ClientesActualizaciones_G(idCliente As Long,
                                              nombreServidor As String,
                                              baseDatos As String,
                                              fechaEjecucion As DateTime?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCliente <> 0 Then
            .AppendFormatLine("   AND CA.{0} =  {1} ", Entidades.ClienteActualizacion.Columnas.IdCliente.ToString(), idCliente)
         End If
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND CA.{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND CA.{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If fechaEjecucion.HasValue Then
            .AppendFormatLine("   AND CA.{0} = '{1}'", Entidades.ClienteActualizacion.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion.Value, True))
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetInfClientesActualizaciones(idCliente As Long, desde As DateTime?, hasta As DateTime?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      ' armo el query
      stb.AppendFormatLine("SELECT C.idCliente,")
      stb.AppendFormatLine("       C.CodigoCliente,")
      stb.AppendFormatLine("       C.NombreCliente,")
      stb.AppendFormatLine("       CA.NombreServidor,")
      stb.AppendFormatLine("       CA.BaseDatos,")
      stb.AppendFormatLine("       CA.FechaEjecucion,")
      stb.AppendFormatLine("       CA.Estado,")
      stb.AppendFormatLine("       CA.Activo")
      stb.AppendFormatLine("  FROM ClientesActualizaciones CA ")
      stb.AppendFormatLine(" INNER JOIN Clientes C ON CA.IdCliente = C.IdCliente")
      stb.AppendFormatLine(" WHERE (CA.Estado = '{0}' AND CA.Activo = '{0}' OR", Entidades.ClienteActualizacion.EstadoActualizacion.ConError.ToString(), True)
      stb.AppendFormatLine("        CA.Estado <> '{0}' AND FechaEjecucion >= '{1}' AND FechaEjecucion < '{2}')",
                           Entidades.ClienteActualizacion.EstadoActualizacion.ConError.ToString(),
                           ObtenerFecha(Today, False), ObtenerFecha(Today.UltimoSegundoDelDia, True))

      If idCliente > 0 Then
         stb.AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
      End If
      If desde.HasValue Then
         stb.AppendFormatLine("   AND CA.FechaEjecucion >= '{0}'", ObtenerFecha(desde.Value, True))
      End If
      If hasta.HasValue Then
         stb.AppendFormatLine("   AND CA.FechaEjecucion <= '{0}'", ObtenerFecha(hasta.Value, True))
      End If

      Return GetDataTable(stb.ToString())
   End Function
   Public Function ClientesActualizaciones_G1(idCliente As Long,
                                              nombreServidor As String,
                                              baseDatos As String,
                                              fechaEjecucion As DateTime) As DataTable
      Return ClientesActualizaciones_G(idCliente, nombreServidor, baseDatos, fechaEjecucion)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "CategoriaParametro" Or columna = "DescripcionParametro" Then
      '   columna = "P." + columna
      'ElseIf columna = "ValorParametroOriginal" Then
      '   columna = "P.ValorParametro"
      'Else
      columna = "CA." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
#End Region

End Class