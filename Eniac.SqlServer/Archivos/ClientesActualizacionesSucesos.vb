Public Class ClientesActualizacionesSucesos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub ClientesActualizacionesSucesos_I(idCliente As Long,
                                               nombreServidor As String,
                                               baseDatos As String,
                                               fechaEjecucion As DateTime,
                                               tipoSuceso As Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso,
                                               orden As Integer,
                                               datos As String,
                                               mensaje As String,
                                               nombreScript As String,
                                               script As String,
                                               estado As Entidades.ClienteActualizacion.EstadoActualizacion)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.ClienteActualizacionSuceso.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.TipoSucesoValue.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.Mensaje.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.NombreScript.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.Script.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idCliente)
         .AppendFormatLine("           ,'{0}'", nombreServidor)
         .AppendFormatLine("           ,'{0}'", baseDatos)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaEjecucion, True))
         .AppendFormatLine("           , {0} ", DirectCast(tipoSuceso, Integer))
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           ,'{0}'", tipoSuceso.ToString())
         .AppendFormatLine("           ,'{0}'", datos)
         .AppendFormatLine("           ,'{0}'", mensaje)
         .AppendFormatLine("           ,'{0}'", nombreScript)
         .AppendFormatLine("           ,'{0}'", script)
         .AppendFormatLine("           ,'{0}'", estado.ToString())

         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesActualizacionesSucesos_U(idCliente As Long,
                                               nombreServidor As String,
                                               baseDatos As String,
                                               fechaEjecucion As DateTime,
                                               tipoSuceso As Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso,
                                               orden As Integer,
                                               datos As String,
                                               mensaje As String,
                                               nombreScript As String,
                                               script As String,
                                               estado As Entidades.ClienteActualizacion.EstadoActualizacion)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ClienteActualizacionSuceso.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString(), datos)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.Mensaje.ToString(), mensaje)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.NombreScript.ToString(), nombreScript)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.Script.ToString(), script)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString(), estado)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion, True))
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString(), DirectCast(tipoSuceso, Integer))
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString(), orden)

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesActualizacionesSucesos_M(idCliente As Long,
                                               nombreServidor As String,
                                               baseDatos As String,
                                               fechaEjecucion As DateTime,
                                               tipoSuceso As Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso,
                                               orden As Integer,
                                               datos As String,
                                               mensaje As String,
                                               nombreScript As String,
                                               script As String,
                                               estado As Entidades.ClienteActualizacion.EstadoActualizacion)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO ClientesActualizacionesSucesos AS D")
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion, True))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString(), DirectCast(tipoSuceso, Integer))
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.TipoSucesoValue.ToString(), tipoSuceso.ToString())
         .AppendFormatLine("                    , @dato AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString()) ', datos)
         .AppendFormatLine("                    , @mensaje AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.Mensaje.ToString()) ', mensaje.ToString())
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.NombreScript.ToString(), nombreScript.ToString())
         .AppendFormatLine("                    , @script AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.Script.ToString()) ', script)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString(), estado.ToString())

         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1} AND O.{2} = D.{2} AND O.{3} = D.{3} AND O.{4} = D.{4} AND O.{5} = D.{5}",
                           Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = O.{0}, D.{1} = O.{1}, D.{2} = O.{2}, D.{3} = O.{3}, D.{4} = O.{4}",
                           Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Mensaje.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.NombreScript.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Script.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormat("        INSERT ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11})",
                           Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.TipoSucesoValue.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Mensaje.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.NombreScript.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Script.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString())

         .AppendFormat("VALUES (O.{0}, O.{1}, O.{2}, O.{3}, O.{4}, O.{5}, O.{6}, O.{7}, O.{8}, O.{9}, O.{10}, O.{11}",
                           Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.TipoSucesoValue.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Mensaje.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.NombreScript.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Script.ToString(),
                           Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString())
         .AppendLine(")")

         .AppendFormatLine(";")
      End With
      'Me.Execute(myQuery.ToString())

      Me._da.Command.Parameters.Clear()
      ''Aquí defino el parámetro
      Me._da.Command.CommandText = myQuery.ToString()
      Me._da.Command.CommandType = CommandType.Text

      Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
      oParameter.ParameterName = "@dato"
      oParameter.DbType = DbType.String
      oParameter.Size = datos.Length
      oParameter.Value = datos
      Me._da.Command.Parameters.Add(oParameter)

      oParameter = Me._da.Command.CreateParameter()
      oParameter.ParameterName = "@script"
      oParameter.DbType = DbType.String
      oParameter.Size = script.Length
      oParameter.Value = script
      Me._da.Command.Parameters.Add(oParameter)

      oParameter = Me._da.Command.CreateParameter()
      oParameter.ParameterName = "@mensaje"
      oParameter.DbType = DbType.String
      oParameter.Size = mensaje.Length
      oParameter.Value = mensaje
      Me._da.Command.Parameters.Add(oParameter)

      Me._da.Command.Connection = Me._da.Connection

      ''Me.Execute(myQuery.ToString())
      Me._da.ExecuteNonQuery(Me._da.Command)

   End Sub

   Public Sub ClientesActualizacionesSucesos_D(idCliente As Long)
      ClientesActualizacionesSucesos_D(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing,
                                       tipoSuceso:=Nothing, orden:=Nothing)
   End Sub
   Public Sub ClientesActualizacionesSucesos_D(idCliente As Long,
                                               nombreServidor As String,
                                               baseDatos As String,
                                               fechaEjecucion As DateTime?,
                                               tipoSuceso As Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso?,
                                               orden As Integer?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.ClienteActualizacionSuceso.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString(), idCliente)
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If fechaEjecucion.HasValue Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion.Value, True))
         End If
         If tipoSuceso.HasValue Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString(), DirectCast(tipoSuceso.Value, Integer))
         End If
         If orden.HasValue Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString(), orden)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
#End Region

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CAS.*")
         .AppendFormatLine("  FROM {0} AS CAS", Entidades.ClienteActualizacionSuceso.NombreTabla)
      End With
   End Sub

#Region "GetAll"
   Public Function ClientesActualizacionesSucesos_GA() As DataTable
      Return ClientesActualizacionesSucesos_G(idCliente:=0, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing, tipoSuceso:=Nothing, orden:=Nothing)
   End Function
   Public Function InfClientesActualizacionesSucesos(idCliente As Long) As DataTable
      Return ClientesActualizacionesSucesos_G(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing, tipoSuceso:=Nothing, orden:=Nothing)
   End Function
   Private Function ClientesActualizacionesSucesos_G(idCliente As Long,
                                                     nombreServidor As String,
                                                     baseDatos As String,
                                                     fechaEjecucion As DateTime?,
                                                     tipoSuceso As Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso?,
                                                     orden As Integer?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCliente <> 0 Then
            .AppendFormatLine("   AND CAS.{0} =  {1} ", Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString(), idCliente)
         End If
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND CAS.{0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND CAS.{0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If fechaEjecucion.HasValue Then
            .AppendFormatLine("   AND CAS.{0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion.Value, True))
         End If
         If tipoSuceso.HasValue Then
            .AppendFormatLine("   AND CAS.{0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString(), DirectCast(tipoSuceso.Value, Integer))
         End If
         If orden.HasValue Then
            .AppendFormatLine("   AND CAS.{0} = '{1}'", Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString(), orden)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetInfClientesActualizacionesSucesos(idCliente As Long, desde As DateTime?, hasta As DateTime?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      ' armo el query
      stb.AppendLine("SELECT  c.idCliente,")
      stb.AppendLine("        CodigoCliente,")
      stb.AppendLine("        NombreCliente,")
      stb.AppendLine("        NombreServidor,")
      stb.AppendLine("        BaseDatos,")
      stb.AppendLine("        FechaEjecucion,")
      stb.AppendLine("        FechaInicioBackup,")
      stb.AppendLine("        FechaFinBackup,")
      stb.AppendLine("        CAS.Activo FROM ClientesActualizacionesSucesos CAS")
      stb.AppendLine("INNER JOIN Clientes c on CAS.IdCliente = c.IdCliente ")
      stb.AppendLine("WHERE 1=1 ")

      If idCliente > 0 Then
         stb.AppendFormatLine("AND c.idCliente = {0}", idCliente)
      End If
      If desde.HasValue Then
         stb.AppendFormatLine("AND FechaEjecucion >= '{0}'", ObtenerFecha(desde.Value, True))
      End If
      If hasta.HasValue Then
         stb.AppendFormatLine("AND FechaEjecucion <= '{0}'", ObtenerFecha(hasta.Value, True))
      End If

      Return GetDataTable(stb.ToString())
   End Function
   Public Function ClientesActualizacionesSucesos_GA(idCliente As Long,
                                                     nombreServidor As String,
                                                     baseDatos As String,
                                                     fechaEjecucion As DateTime) As DataTable
      Return ClientesActualizacionesSucesos_G(idCliente, nombreServidor, baseDatos, fechaEjecucion, tipoSuceso:=Nothing, orden:=Nothing)
   End Function

   Public Function ClientesActualizacionesSucesos_G1(idCliente As Long,
                                                     nombreServidor As String,
                                                     baseDatos As String,
                                                     fechaEjecucion As DateTime,
                                                     tipoSuceso As Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso?,
                                                     orden As Integer?) As DataTable
      Return ClientesActualizacionesSucesos_G(idCliente, nombreServidor, baseDatos, fechaEjecucion, tipoSuceso, orden)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "CategoriaParametro" Or columna = "DescripcionParametro" Then
      '   columna = "P." + columna
      'ElseIf columna = "ValorParametroOriginal" Then
      '   columna = "P.ValorParametro"
      'Else
      columna = "CAS." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{0}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
#End Region

End Class