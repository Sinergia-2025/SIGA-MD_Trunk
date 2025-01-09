Public Class ClientesBackups
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub ClientesBackups_I(idCliente As Long,
                                nombreServidor As String,
                                baseDatos As String,
                                fechaEjecucion As DateTime,
                                fechaInicioBackup As DateTime?,
                                fechaFinBackup As DateTime?,
                                activo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.ClienteBackup.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.ClienteBackup.Columnas.IdCliente.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteBackup.Columnas.NombreServidor.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteBackup.Columnas.BaseDatos.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteBackup.Columnas.Activo.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idCliente)
         .AppendFormatLine("           ,'{0}'", nombreServidor)
         .AppendFormatLine("           ,'{0}'", baseDatos)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaEjecucion, True))
         If fechaInicioBackup.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaInicioBackup.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If
         If fechaFinBackup.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaFinBackup.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If
         .AppendFormatLine("           ,{0}", GetStringFromBoolean(activo))
         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesBackups_U(idCliente As Long,
                                nombreServidor As String,
                                baseDatos As String,
                                fechaEjecucion As DateTime,
                                fechaInicioBackup As DateTime?,
                                fechaFinBackup As DateTime?,
                                activo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ClienteBackup.NombreTabla)
         If fechaInicioBackup.HasValue Then
            .AppendFormatLine("   SET {0} = '{1}'", Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString(), ObtenerFecha(fechaInicioBackup.Value, True))
         Else
            .AppendFormatLine("   SET {0} = NULL", Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString())
         End If
         If fechaInicioBackup.HasValue Then
            .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString(), ObtenerFecha(fechaFinBackup.Value, True))
         Else
            .AppendFormatLine("      ,{0} = NULL", Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString())
         End If
         .AppendFormatLine("      ,{0} = {1}", Entidades.ClienteBackup.Columnas.Activo.ToString(), GetStringFromBoolean(activo))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteBackup.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteBackup.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteBackup.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion, True))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesBackups_M(idCliente As Long,
                                nombreServidor As String,
                                baseDatos As String,
                                fechaEjecucion As DateTime,
                                fechaInicioBackup As DateTime?,
                                fechaFinBackup As DateTime?,
                                activo As Boolean?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO ClientesBackups AS D")
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.ClienteBackup.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteBackup.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteBackup.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion, True))
         If fechaInicioBackup.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString(), ObtenerFecha(fechaInicioBackup.Value, True))
         Else
            .AppendFormatLine("                    , NULL  AS {0}", Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString())
         End If
         If fechaFinBackup.HasValue Then
            .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString(), ObtenerFecha(fechaFinBackup.Value, True))
         Else
            .AppendFormatLine("                    , NULL  AS {0}", Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString())
         End If
         If activo.HasValue Then
            .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ClienteBackup.Columnas.Activo.ToString(), activo)
         End If

         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1} AND O.{2} = D.{2} AND O.{3} = D.{3}",
                           Entidades.ClienteBackup.Columnas.IdCliente.ToString(),
                           Entidades.ClienteBackup.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteBackup.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = O.{0}, D.{1} = O.{1}",
                           Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString(),
                           Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString())
         If activo.HasValue Then
            .AppendFormatLine("                 , D.{0} = O.{1}", Entidades.ClienteBackup.Columnas.Activo.ToString())
         End If
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormat("        INSERT ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                           Entidades.ClienteBackup.Columnas.IdCliente.ToString(),
                           Entidades.ClienteBackup.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteBackup.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString(),
                           Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString(),
                           Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString(),
                           Entidades.ClienteBackup.Columnas.Activo.ToString())

         .AppendFormat("VALUES (O.{0}, O.{1}, O.{2}, O.{3}, O.{4}, O.{5}",
                           Entidades.ClienteBackup.Columnas.IdCliente.ToString(),
                           Entidades.ClienteBackup.Columnas.NombreServidor.ToString(),
                           Entidades.ClienteBackup.Columnas.BaseDatos.ToString(),
                           Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString(),
                           Entidades.ClienteBackup.Columnas.FechaInicioBackup.ToString(),
                           Entidades.ClienteBackup.Columnas.FechaFinBackup.ToString())
         If activo.HasValue Then
            .AppendFormat(", O.{0}", Entidades.ClienteBackup.Columnas.Activo.ToString())
         Else
            .AppendFormat(", 'True'")
         End If
         .AppendLine(")")

         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ClientesBackups_D(idCliente As Long)
      ClientesBackups_D(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing)
   End Sub
   Public Sub ClientesBackups_D(idCliente As Long,
                                nombreServidor As String,
                                baseDatos As String,
                                fechaEjecucion As DateTime?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.ClienteBackup.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteBackup.Columnas.IdCliente.ToString(), idCliente)
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteBackup.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteBackup.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If fechaEjecucion.hasvalue Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion.Value, True))
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
#End Region

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CB.*")
         .AppendFormatLine("  FROM {0} AS CB", Entidades.ClienteBackup.NombreTabla)
      End With
   End Sub

#Region "GetAll"
   Public Function ClientesBackups_GA() As DataTable
      Return ClientesBackups_G(idCliente:=0, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing)
   End Function
   Public Function InfClientesBackups(idCliente As Long) As DataTable
      Return ClientesBackups_G(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, fechaEjecucion:=Nothing)
   End Function
   Private Function ClientesBackups_G(idCliente As Long,
                                      nombreServidor As String,
                                      baseDatos As String,
                                      fechaEjecucion As DateTime?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCliente <> 0 Then
            .AppendFormatLine("   AND CB.{0} =  {1} ", Entidades.ClienteBackup.Columnas.IdCliente.ToString(), idCliente)
         End If
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND CB.{0} = '{1}'", Entidades.ClienteBackup.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND CB.{0} = '{1}'", Entidades.ClienteBackup.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If fechaEjecucion.HasValue Then
            .AppendFormatLine("   AND CB.{0} = '{1}'", Entidades.ClienteBackup.Columnas.FechaEjecucion.ToString(), ObtenerFecha(fechaEjecucion.Value, True))
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetInfClientesBackups(idCliente As Long, desde As DateTime?, hasta As DateTime?) As DataTable
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
      stb.AppendLine("        cb.Activo FROM ClientesBackups cb ")
      stb.AppendLine("INNER JOIN Clientes c on cb.IdCliente = c.IdCliente ")
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
   Public Function ClientesBackups_G1(idCliente As Long,
                                      nombreServidor As String,
                                      baseDatos As String,
                                      fechaEjecucion As DateTime) As DataTable
      Return ClientesBackups_G(idCliente, nombreServidor, baseDatos, fechaEjecucion)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "CategoriaParametro" Or columna = "DescripcionParametro" Then
      '   columna = "P." + columna
      'ElseIf columna = "ValorParametroOriginal" Then
      '   columna = "P.ValorParametro"
      'Else
      columna = "CB." + columna
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