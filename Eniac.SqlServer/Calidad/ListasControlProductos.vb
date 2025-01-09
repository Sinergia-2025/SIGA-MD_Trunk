
Public Class ListasControlProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ListasControlProductos_I(IdProducto As String,
                                      IdListaControl As Integer,
                                      fecha As DateTime,
                                       IdUsuario As String,
                                       Aplica As Boolean,
                                       IdEstadoCalidad As Integer)
      'FecIngreso As DateTime,
      'FecEgreso As DateTime,
      'CincoS As String,
      'CincoSComment As String,
      'CincoSC As String,
      'CincoSCommentC As String,
      'CincoSUsr As String,
      'CincoSFecha As DateTime,
      'CincoSUsrC As String,
      'CincoSFechaC As DateTime,


      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadListasControlProductos ({0}, {1} ,{2} ,{3}, {4}, {5})",
                        Entidades.ListaControlProducto.Columnas.IdProducto.ToString(),
                        Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                        Entidades.ListaControlProducto.Columnas.fecha.ToString(),
                        Entidades.ListaControlProducto.Columnas.Idusuario.ToString(),
                        Entidades.ListaControlProducto.Columnas.Aplica.ToString(),
                        Entidades.ListaControlProducto.Columnas.IdEstadoCalidad.ToString()).AppendLine()
         'Entidades.ListaControlProducto.Columnas.FecIngreso.ToString(),
         'Entidades.ListaControlProducto.Columnas.FecEgreso.ToString(),
         'Entidades.ListaControlProducto.Columnas.FecIngreso.ToString(),
         'Entidades.ListaControlProducto.Columnas.CincoS.ToString(),
         'Entidades.ListaControlProducto.Columnas.CincoSComment.ToString(),
         'Entidades.ListaControlProducto.Columnas.CincoSC.ToString(),
         'Entidades.ListaControlProducto.Columnas.CincoSCommentC.ToString(),
         'Entidades.ListaControlProducto.Columnas.CincoSUsr.ToString(),
         'Entidades.ListaControlProducto.Columnas.CincoSFecha.ToString(),
         'Entidades.ListaControlProducto.Columnas.CincoSUsrC.ToString(),
         'Entidades.ListaControlProducto.Columnas.CincoSUsrC.ToString(),

         .AppendFormat("     VALUES ('{0}', {1} ,'{2}' ,'{3}','{4}', {5})",
                      IdProducto, IdListaControl, ObtenerFecha(fecha, True), IdUsuario, Aplica, IdEstadoCalidad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlProductos_U(IdProducto As String,
                                      IdListaControl As Integer,
                                      FecIngreso As DateTime,
                                      FecEgreso As DateTime,
                                      CincoS As String,
                                      CincoSComment As String,
                                      CincoSC As String,
                                      CincoSCommentC As String,
                                      CincoSUsr As String,
                                      CincoSFecha As DateTime,
                                      CincoSUsrC As String,
                                      CincoSFechaC As DateTime,
                                      IdUsuario As String,
                                      Aplica As Boolean,
                                       IdEstadoCalidad As Integer,
                                       Observacion As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadListasControlProductos ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdEstadoCalidad.ToString(), IdEstadoCalidad).AppendLine()

         '   .AppendFormat("   SET {0} = '{1}'", Entidades.ListaControlProducto.Columnas.fecha.ToString(), fecha).AppendLine()

         If FecIngreso <> Nothing Then
            .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.FecIngreso.ToString(), ObtenerFecha(FecIngreso, True)).AppendLine()
            'Else
            '   .AppendFormat("     , {0} = NULL ", Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).AppendLine()
         End If
         If FecEgreso <> Nothing Then
            .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.FecEgreso.ToString(), ObtenerFecha(FecEgreso, True)).AppendLine()
            'Else
            '   .AppendFormat("     , {0} = NULL ", Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).AppendLine()
         End If
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.CincoS.ToString(), CincoS).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.CincoSComment.ToString(), CincoSComment).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.CincoSC.ToString(), CincoSC).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.CincoSCommentC.ToString(), CincoSCommentC).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.CincoSUsr.ToString(), CincoSUsr).AppendLine()

         If CincoSFecha <> Nothing Then
            .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.CincoSFecha.ToString(), ObtenerFecha(CincoSFecha, True)).AppendLine()
         Else
            .AppendFormat("     , {0} = NULL ", Entidades.ListaControlProducto.Columnas.CincoSFecha.ToString()).AppendLine()
         End If

         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.CincoSUsrC.ToString(), CincoSUsrC).AppendLine()

         If CincoSFechaC <> Nothing Then
            .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.CincoSFechaC.ToString(), ObtenerFecha(CincoSFechaC, True)).AppendLine()
         Else
            .AppendFormat("     , {0} = NULL ", Entidades.ListaControlProducto.Columnas.CincoSFechaC.ToString()).AppendLine()
         End If

         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.Idusuario.ToString(), IdUsuario).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.Aplica.ToString(), Aplica).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProducto.Columnas.Observacion.ToString(), Observacion).AppendLine()

         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(), IdListaControl)
         .AppendFormat(" AND {0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), IdProducto)


      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlProductos_D(idProducto As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlProductos ")
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlProductos_D(idProducto As String, idListaControl As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlProductos ")
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormat(" AND {0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(), idListaControl)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlProductos_UAplica(idProducto As String, idListaControl As Integer, Aplica As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadListasControlProductos SET Aplica = '" & Aplica & "'")
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormat(" AND {0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(), idListaControl)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function CalidadListasControl_G1(IdProducto As String, idListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), IdProducto)
         .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(), idListaControl)

         .AppendFormat(" ORDER BY LCU.IdListaControl")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function CalidadListasControl_GetListasControlSiguienteOrden(IdProducto As String, orden As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         ' .AppendLine("  LEFT JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = LCU.IdEstadoCalidad")
         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), IdProducto)
         .AppendFormat(" AND LC.{0} > {1}", Entidades.ListaControl.Columnas.Orden.ToString(), orden)
         ' .AppendLine("  AND CE.PorDefecto = 1")
         .AppendLine(" AND LCU.IdEstadoCalidad <> 4")

         .AppendFormat(" ORDER BY LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT LCU.*, LC.NombreListaControl, ELC.NombreEstadoCalidad , LC.Orden FROM CalidadListasControlProductos AS LCU").AppendLine()
         '.AppendFormat(" LEFT JOIN Usuarios AS U ON U.Id = LCU.IdUsuario")
         .AppendFormat(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendFormat(" LEFT JOIN CalidadEstadosListasControl AS ELC ON ELC.IdEstadoCalidad = LCU.IdEstadoCalidad")

      End With
   End Sub

   Public Function ListasControlProductos_GA(idProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         End If

         .AppendFormat(" ORDER BY LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function ListasControlProductos_GxLista(idListaConhtrol As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If idListaConhtrol > 0 Then
            .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(), idListaConhtrol)
         End If

         .AppendFormat(" ORDER BY LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function ListasControlProductos_GProductos(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                IdestadoCalidad As Integer, Liberado As Boolean,
                                                Entregado As Boolean, IdListaControl As Integer,
                                                IdTipoListaControl As Integer, IdCliente As Long,
                                                CincoS As String, Ubicacion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT LCU.*, LC.NombreListaControl, ELC.NombreEstadoCalidad ,P.CalidadStatusLiberado, P.CalidadStatusEntregado ")
         .AppendLine(" ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia ")
         .AppendLine(" , P.NombreProducto , LC.DiasMaximoProceso , CLCT.NombreListaControlTipo ")
         .AppendLine("  ,CASE WHEN LCU.FecEgreso is not NULL THEN DateDiff(Day,LCU.FecIngreso, LCU.FecEgreso) ELSE  DateDiff(Day,LCU.FecIngreso, GETDATE()) END  AS Dias   ")
         .AppendLine("  ,CASE WHEN LCU.FecEgreso is not NULL THEN DateDiff(Day,LCU.FecIngreso, LCU.FecEgreso) ELSE  DateDiff(Day,LCU.FecIngreso, GETDATE()) END - LC.DiasMaximoProceso  AS Diferencia ")

         .AppendLine("  FROM CalidadListasControlProductos AS LCU ")
         .AppendLine(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendLine(" LEFT JOIN CalidadEstadosListasControl AS ELC ON ELC.IdEstadoCalidad = LCU.IdEstadoCalidad")
         .AppendLine(" LEFT JOIN CalidadListasControlTipos CLCT ON CLCT.IdListaControlTipo = LC.IdListaControlTipo")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = LCU.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)
         .AppendLine("WHERE 1 = 1")

         If CincoS = "DIFERENCIAS" Then
            .AppendLine("  AND LCU.CincoS <> LCU.CincoSC ")
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

         .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))

         If IdestadoCalidad <> 0 Then
            .AppendFormatLine("           AND LCU.IdEstadoCalidad = '{0}'", IdestadoCalidad)
         End If

         If IdListaControl <> 0 Then
            .AppendFormatLine("           AND LCU.IdListaControl = '{0}'", IdListaControl)
         End If

         If IdTipoListaControl <> 0 Then
            .AppendFormatLine("           AND LC.IdListaControlTipo  = '{0}'", IdTipoListaControl)
         End If

         If Liberado Then
            .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", Liberado)
         End If
         If Entregado Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", Entregado)
         End If
         If IdCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", IdCliente)
         End If
         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PS.Ubicacion = '" & Ubicacion & "'")
         End If
         .AppendFormat(" ORDER BY C.NombreCliente, P.NombreProducto, LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Function ListasControlProductos_LeadTime(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                             IdestadoCalidad As Integer, IdListaControl As Integer,
                                             IdCliente As Long, Ubicacion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT LCU.IdProducto, P.CalidadFechaIngreso, P.CalidadFechaEgreso, P.CalidadFechaPreEnt, P.CalidadFechaLiberado ")
         .AppendLine("  ,CASE WHEN P.CalidadFechaEgreso is not NULL THEN DateDiff(Day,P.CalidadFechaIngreso, P.CalidadFechaEgreso) ELSE NULL END  AS Produc   ")
         .AppendLine("  ,CASE WHEN  P.CalidadFechaEgreso is not NULL THEN DateDiff(Day, P.CalidadFechaEgreso,P.CalidadFechaPreEnt) ELSE NULL END  AS Proces   ")
         .AppendLine("  ,CASE WHEN  P.CalidadFechaPreEnt is not NULL THEN DateDiff(Day,P.CalidadFechaPreEnt,P.CalidadFechaLiberado) ELSE NULL END  AS Pre   ")
         .AppendLine("  , CASE WHEN P.CalidadFechaEgreso is not NULL THEN DateDiff(Day,P.CalidadFechaIngreso, P.CalidadFechaEgreso) ELSE NULL END + ")
         .AppendLine("  CASE WHEN  P.CalidadFechaEgreso is not NULL THEN DateDiff(Day, P.CalidadFechaEgreso,P.CalidadFechaPreEnt) ELSE NULL END   + ")
         .AppendLine("  CASE WHEN   P.CalidadFechaPreEnt is not NULL THEN DateDiff(Day,  P.CalidadFechaPreEnt,P.CalidadFechaLiberado) ELSE NULL END  AS Total ")
         .AppendLine("  , LC.NombreListaControl, ELC.NombreEstadoCalidad,LCU.FecIngreso, LCU.FecEgreso ")
         .AppendLine("   ,CASE WHEN LCU.FecEgreso is not NULL THEN DateDiff(Day,LCU.FecIngreso, LCU.FecEgreso) ELSE  DateDiff(Day,LCU.FecIngreso, GETDATE()) END  AS Dias   ")
         .AppendLine("  ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia ")
         .AppendLine("  , P.NombreProducto   ")

         .AppendLine("  FROM CalidadListasControlProductos AS LCU ")
         .AppendLine(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendLine(" LEFT JOIN CalidadEstadosListasControl AS ELC ON ELC.IdEstadoCalidad = LCU.IdEstadoCalidad")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = LCU.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)

         .AppendLine("WHERE 1 = 1")
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

         .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))

         If IdestadoCalidad <> 0 Then
            .AppendFormatLine("           AND LCU.IdEstadoCalidad = '{0}'", IdestadoCalidad)
         End If

         If IdListaControl <> 0 Then
            .AppendFormatLine("           AND LCU.IdListaControl = '{0}'", IdListaControl)
         End If

         If IdCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", IdCliente)
         End If

         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PS.Ubicacion = '" & Ubicacion & "'")
         End If

         .AppendFormat(" ORDER BY C.NombreCliente, P.NombreProducto, LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductos_PreEntrega(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                     IdCliente As Long, PreEntrega As String, Ubicacion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT P.IdProducto, P.CalidadFechaIngreso, P.CalidadFechaEgreso, P.CalidadFechaPreEnt, ")
         .AppendLine(" P.CalidadFechaLiberado, P.CalidadFechaEntregado , P.CalidadUserLiberado, P.CalidadStatusLiberado")
         .AppendLine(" ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia ")
         .AppendLine("  , P.NombreProducto    ")
         .AppendLine("  FROM  Productos P  ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)

         .AppendLine("WHERE 1 = 1")
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND P.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If PreEntrega = "PENDIENTES" Then
            .AppendFormat("	  AND P.CalidadFechaPreEnt IS NULL")
         ElseIf PreEntrega = "TODOS" Then
            .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

            .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))
         Else
            .AppendFormat("	  AND P.CalidadFechaPreEnt >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

            .AppendFormat("  AND P.CalidadFechaPreEnt <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))
         End If

         If IdCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", IdCliente)
         End If

         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PS.Ubicacion = '" & Ubicacion & "'")
         End If

         .AppendFormat(" ORDER BY P.CalidadFechaPreEnt ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductos_LiberarProducto(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                    IdCliente As Long, Liberado As String, Ubicacion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT P.IdProducto, P.CalidadFechaIngreso, P.CalidadFechaEgreso, P.CalidadFechaPreEnt, ")
         .AppendLine(" P.CalidadFechaLiberado, P.CalidadFechaEntregado , P.CalidadUserLiberado, P.CalidadStatusLiberado")
         .AppendLine(" ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia ")
         .AppendLine("  , P.NombreProducto    ")
         .AppendLine("  FROM  Productos P  ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)

         .AppendLine("WHERE 1 = 1")
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND P.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If Liberado = "PENDIENTES" Then
            .AppendFormat("	  AND P.CalidadStatusLiberado = 'False'")
         ElseIf Liberado = "TODOS" Then
            .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

            .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))
         Else
            .AppendFormat("	  AND P.CalidadFechaLiberado >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

            .AppendFormat("  AND P.CalidadFechaLiberado <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))
         End If

         If IdCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", IdCliente)
         End If

         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PS.Ubicacion = '" & Ubicacion & "'")
         End If

         .AppendFormat(" ORDER BY P.CalidadFechaPreEnt ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductos_EntregadoACLiente(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                  IdCliente As Long, Entregado As String, Ubicacion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT P.IdProducto, P.CalidadFechaIngreso, P.CalidadFechaEgreso, P.CalidadFechaPreEnt, ")
         .AppendLine(" P.CalidadFechaLiberado, P.CalidadFechaEntregado , P.CalidadUserLiberado, P.CalidadStatusLiberado")
         .AppendLine(" ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia ")
         .AppendLine("  , P.NombreProducto    ")
         .AppendLine("  FROM  Productos P  ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)

         .AppendLine("WHERE 1 = 1")
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND P.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If Entregado = "PENDIENTES" Then
            .AppendFormat("	  AND P.CalidadStatusEntregado = 'False'")
         ElseIf Entregado = "TODOS" Then
            .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

            .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))
         Else
            .AppendFormat("	  AND P.CalidadFechaEntregado >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

            .AppendFormat("  AND P.CalidadFechaEntregado <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))
         End If

         If IdCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", IdCliente)
         End If

         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PS.Ubicacion = '" & Ubicacion & "'")
         End If

         .AppendFormat(" ORDER BY P.CalidadFechaPreEnt ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Function ListasControlProductos_GxRoles(idProducto As String, Roles As DataTable) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery

         .AppendFormat("SELECT CASE WHEN LCR.IdRol IS NULL THEN 'False' ELSE 'True' END AS Hab, ")
         .AppendLine(" LCU.*, LC.NombreListaControl, ELC.NombreEstadoCalidad, ELC.Color ,LC.Orden , LC.DiasMaximoProceso ")
         .AppendLine("  ,CASE WHEN LCU.FecEgreso is not NULL THEN DateDiff(Day,LCU.FecIngreso, LCU.FecEgreso) ELSE  DateDiff(Day,LCU.FecIngreso, GETDATE()) END  AS Dias   ")
         .AppendLine("  ,CASE WHEN LCU.FecEgreso is not NULL THEN DateDiff(Day,LCU.FecIngreso, LCU.FecEgreso) ELSE  DateDiff(Day,LCU.FecIngreso, GETDATE()) END - LC.DiasMaximoProceso  AS Diferencia ")
         .AppendLine(" FROM CalidadListasControlProductos AS LCU").AppendLine()
         .AppendFormat(" INNER JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendFormat(" LEFT JOIN CalidadEstadosListasControl AS ELC ON ELC.IdEstadoCalidad = LCU.IdEstadoCalidad")
         .AppendLine("  LEFT JOIN CalidadListasControlRoles LCR ON LCR.IdListaControl = LC.IdListaControl")
         .AppendLine("	And LCR.IdRol IN (")
         For Each rol As DataRow In Roles.Rows
            .AppendFormat("'{0}',", rol("IdRol").ToString())
         Next
         .Remove(.Length - 1, 1)
         .AppendLine(")")
         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         ' .AppendLine(" AND LCU.Aplica = 'True'")
         .AppendFormat(" ORDER BY LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetListasControlEnproceso(idProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery

         .AppendFormat("SELECT LCU.*, LC.NombreListaControl")
         .AppendLine(" FROM CalidadListasControlProductos AS LCU").AppendLine()
         .AppendFormat(" INNER JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormat(" AND LCU.idEstadoCalidad = 2")
         ' .AppendLine(" AND LCU.Aplica = 'True'")
         .AppendFormat(" ORDER BY LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetEstadosPorListasControl_ColumnasPivot(idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT 'IdListaControl__' + CONVERT(VARCHAR(MAX), P.IdListaControl) NombreColumma, P.IdListaControl, LC.NombreListaControl, LC.Orden ")
         .AppendLine(" FROM CalidadListasControlProductos P ")
         .AppendLine(" INNER JOIN CalidadListasControl LC ON LC.IdListaControl = P.IdListaControl ")


         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   WHERE P.IdProducto = '{0}'", idProducto)
         End If
         .AppendLine("  order by LC.Orden")
      End With
      Return GetDataTable(stb.ToString())
   End Function
   Public Function GetEstadosPorListasControlTipo_ColumnasPivot(idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT 'IdListaControlTipo__' + CONVERT(VARCHAR(MAX), LC.IdListaControlTipo) NombreColumma, ")
         .AppendLine("  LC.IdListaControlTipo, CT.NombreListaControlTipo, CT.RangoHasta ")
         .AppendLine(" FROM CalidadListasControlProductos P ")
         .AppendLine(" INNER JOIN CalidadListasControl LC ON LC.IdListaControl = P.IdListaControl ")
         .AppendLine("  INNER JOIN CalidadListasControlTipos CT ON CT.IdListaControlTipo = LC.IdListaControlTipo")
         .AppendLine("  WHERE CT.VisiblePanelControl = 'True'")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If
         .AppendLine("    order by CT.RangoHasta ")
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetEstadosPorListasControlTipo_ColumnasPivotPCW(idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT 'IdListaControlTipo__' + CONVERT(VARCHAR(MAX), LC.IdListaControlTipo) NombreColumma, ")
         .AppendLine("  LC.IdListaControlTipo, CT.NombreListaControlTipo, CT.RangoHasta ")
         .AppendLine(" FROM CalidadListasControlProductos P ")
         .AppendLine(" INNER JOIN CalidadListasControl LC ON LC.IdListaControl = P.IdListaControl ")
         .AppendLine("  INNER JOIN CalidadListasControlTipos CT ON CT.IdListaControlTipo = LC.IdListaControlTipo")
         .AppendLine("  WHERE CT.VisiblePanelControl = 'True'")
         .AppendLine("  AND CT.IdListaControlTipo <> 8")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If
         .AppendLine("    order by CT.RangoHasta ")
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetEstadosPorListasControlTipoEstado_ColumnasPivot(idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT  'EIdListaControlTipo__' + CONVERT(VARCHAR(MAX), LC.IdListaControlTipo) NombreColumma, ")
         .AppendLine("  LC.IdListaControlTipo, CT.NombreListaControlTipo, CT.RangoHasta ")
         .AppendLine(" FROM CalidadListasControlProductos P ")
         .AppendLine(" INNER JOIN CalidadListasControl LC ON LC.IdListaControl = P.IdListaControl ")
         .AppendLine("  INNER JOIN CalidadListasControlTipos CT ON CT.IdListaControlTipo = LC.IdListaControlTipo")
         .AppendLine("  WHERE CT.VisiblePanelControl = 'True'")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If
         .AppendLine("    order by CT.RangoHasta ")
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetEstadosPorListasControlTipoEstado_ColumnasPivotPCW(idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT  'EIdListaControlTipo__' + CONVERT(VARCHAR(MAX), LC.IdListaControlTipo) NombreColumma, ")
         .AppendLine("  LC.IdListaControlTipo, CT.NombreListaControlTipo, CT.RangoHasta ")
         .AppendLine(" FROM CalidadListasControlProductos P ")
         .AppendLine(" INNER JOIN CalidadListasControl LC ON LC.IdListaControl = P.IdListaControl ")
         .AppendLine("  INNER JOIN CalidadListasControlTipos CT ON CT.IdListaControlTipo = LC.IdListaControlTipo")
         .AppendLine("  WHERE CT.VisiblePanelControl = 'True'")
         .AppendLine("  AND CT.IdListaControlTipo <> 8")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If
         .AppendLine("    order by CT.RangoHasta ")
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetLeadTimePorListasControlTipo_ColumnasPivot(idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT  'FIdListaControlTipo__' + CONVERT(VARCHAR(MAX), LC.IdListaControlTipo) NombreColumma, ")
         .AppendLine("  LC.IdListaControlTipo, CT.NombreListaControlTipo, CT.RangoHasta ")
         .AppendLine(" FROM CalidadListasControlProductos P ")
         .AppendLine(" INNER JOIN CalidadListasControl LC ON LC.IdListaControl = P.IdListaControl ")
         .AppendLine("  INNER JOIN CalidadListasControlTipos CT ON CT.IdListaControlTipo = LC.IdListaControlTipo")

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   WHERE P.IdProducto = '{0}'", idProducto)
         End If
         .AppendLine("    order by CT.RangoHasta ")
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetEstadosPorListasControl(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                IdestadoCalidad As Integer, Liberado As Boolean,
                                                Entregado As Boolean,
                                               pivotcolName As String,
                                               sumPivot As String, IdCliente As Long, Ubicacion As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT  P1.IdProducto ")
         .AppendLine(" 	,P1.NombreProducto ")
         .AppendLine(" 	,P1.NombreCliente")
         .AppendLine("  ,P1.CalidadFechaIngreso ")
         .AppendLine("  ,P1.CalidadFechaEgreso ")
         .AppendLine(" 	,P1.CalidadStatusLiberado ")
         .AppendLine(" 	,P1.CalidadStatusEntregado")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         .AppendFormatLine("   FROM (SELECT PS.IdProducto ")
         .AppendLine("   , P.NombreProducto ")
         .AppendLine(" 	 ,P.CalidadFechaIngreso ")
         .AppendLine(" 	 ,P.CalidadFechaEgreso ")
         .AppendLine("   ,P.CalidadStatusLiberado ")
         .AppendLine(" 	 ,P.CalidadStatusEntregado ")
         .AppendLine("   ,PS.IdEstadoCalidad ")
         .AppendLine("   ,CE.NombreEstadoCalidad ")
         .AppendLine("   ,C.NombreCliente")
         .AppendLine("   , 'IdListaControl__' + CONVERT(VARCHAR(MAX), PS.IdListaControl) IdListaControl ")
         .AppendLine("   FROM CalidadListasControlProductos PS ")
         .AppendLine("   INNER JOIN Productos P ON P.IdProducto = PS.IdProducto ")
         .AppendLine(" 	 INNER JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = PS.IdEstadoCalidad ")
         .AppendLine("   LEFT JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto ")
         .AppendLine("   LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")
         .AppendLine(" LEFT JOIN ProductosSucursales PSU ON PSU.IdProducto = P.IdProducto AND PSU.IdSucursal = " & actual.Sucursal.Id)

         .AppendLine("   WHERE 1 = 1")

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("           AND P.IdProducto = '{0}'", idProducto)
         End If

         .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

         .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))

         If IdestadoCalidad <> 0 Then
            .AppendFormat("     AND EXISTS (SELECT * FROM CalidadListasControlProductos PS1 WHERE PS1.IdProducto = PS.IdProducto AND PS1.IdEstadoCalidad = {0})", IdestadoCalidad)
         End If
         If Liberado Then
            .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", Liberado)
         End If
         If Entregado Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", Entregado)
         End If
         If IdCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", IdCliente)
         End If
         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PSU.Ubicacion = '" & Ubicacion & "'")
         End If

         .AppendFormatLine("        ) P")
         .AppendFormatLine("  PIVOT(MAX(NombreEstadoCalidad) FOR P.IdListaControl in ({0})) AS P1", pivotcolName)
         .AppendFormatLine("  GROUP BY  P1.IdProducto ")
         .AppendLine(" 	,P1.NombreProducto ")
         .AppendLine("  ,P1.NombreCliente")
         .AppendLine("  ,P1.CalidadFechaIngreso ")
         .AppendLine("  ,P1.CalidadFechaEgreso ")
         .AppendLine(" 	,P1.CalidadStatusLiberado ")
         .AppendLine(" 	,P1.CalidadStatusEntregado ")
         .AppendLine("  ORDER BY P1.CalidadFechaIngreso")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetEstadosPorListasControlTipo(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                  idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                  liberados As Entidades.Publicos.SiNoTodos, entregados As Entidades.Publicos.SiNoTodos,
                                                  liberadosPDI As Entidades.Publicos.SiNoTodos, PanelGerencia As Boolean, MostrarReparaciones As Boolean,
                                                  pivotcolName As String, sumPivot As String, pivotcolName2 As String, sumPivot2 As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P1.IdProducto ")
         .AppendFormatLine(" 	   , P1.NombreProducto ")
         .AppendFormatLine("     , P1.CalidadNumeroChasis")
         .AppendFormatLine(" 	   , P1.NombreCliente")
         ' .AppendFormatLine("     , P1.CalidadFechaIngreso ")
         .AppendFormatLine("    	 , ISNULL((SELECT MIN(CASE WHEN CLCP.CincoSFecha is null THEN CLCP.CincoSFechaC ELSE CASE WHEN CLCP.CincoSFechaC IS NULL THEN CLCP.CincoSFecha ELSE CASE WHEN CLCP.CincoSFecha < CLCP.CincoSFechaC THEN CLCP.CincoSFecha ELSE CLCP.CincoSFechaC END END END)")
         .AppendFormatLine("      FROM CalidadListasControlProductos CLCP")
         .AppendFormatLine("      INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CLCP.IdListaControl")
         .AppendFormatLine("      WHERE CLCP.IdProducto = P1.IdProducto")
         .AppendFormatLine("      AND CLC.BloqueaFechaIngreso = 'True'), P1.CalidadFechaIngreso ) CalidadFechaIngreso")
         .AppendFormatLine("     , P1.CalidadFechaEntProg ")
         .AppendFormatLine("     ,P1.CalidadFechaEntReProg")
         .AppendFormatLine("     , P1.CalidadFechaEgreso ")
         .AppendFormatLine("     , P1.CalidadFechaLiberado")
         .AppendFormatLine(" 	   , P1.CalidadStatusLiberado ")
         .AppendFormatLine(" 	   , P1.CalidadStatusEntregado")
         .AppendFormatLine("     , P1.CalidadFechaLiberadoPDI")
         .AppendFormatLine(" 	   , P1.CalidadStatusLiberadoPDI")
         .AppendFormatLine("     ,P1.NombreProductoModelo")
         .AppendFormatLine("     ,P1.NombreProductoModeloTipo")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         .AppendFormatLine("     , {0}", sumPivot2.ToString())
         .AppendFormatLine("  FROM (SELECT PS.IdProducto ")
         .AppendFormatLine("             , P.NombreProducto ")
         .AppendFormatLine("             , P.CalidadNumeroChasis")
         .AppendFormatLine(" 	           , P.CalidadFechaIngreso ")
         .AppendFormatLine(" 	           , P.CalidadFechaEntProg ")
         .AppendFormatLine("             ,P.CalidadFechaEntReProg")
         .AppendFormatLine(" 	           , P.CalidadFechaEgreso ")
         .AppendFormatLine("             , P.CalidadFechaLiberado")
         .AppendFormatLine("             , P.CalidadStatusLiberado ")
         .AppendFormatLine(" 	           , P.CalidadStatusEntregado ")
         .AppendFormatLine("             , P.CalidadFechaLiberadoPDI")
         .AppendFormatLine("             , P.CalidadStatusLiberadoPDI")
         .AppendFormatLine("             , PS.IdEstadoCalidad ")
         '  .AppendFormatLine("             , case when PS.CincoSFecha is null THEN CASE WHEN PS.CincoSFechaC is NULL THEN  NULL ELSE PS.CincoSFechaC  END ELSE CASE WHEN PS.CincoSFechaC is null THEN PS.CincoSFecha ELSE CASE WHEN PS.CincoSFecha < Ps.CincoSFechaC THEN PS.CincoSFecha ELSE PS.CincoSFechaC END END  END AS Fecha  ")
         .AppendFormatLine("             , CASE WHEN PS.CincoSFechaC is NULL THEN  NULL ELSE PS.CincoSFechaC  END AS Fecha  ")
         .AppendFormatLine("             , PS.CincoSFecha ")
         .AppendFormatLine("             , PS.CincoSFechaC ")
         .AppendFormatLine("             , CE.NombreEstadoCalidad ")
         .AppendFormatLine("             , C.NombreCliente")
         .AppendFormatLine("             , CPM.NombreProductoModelo")
         .AppendFormatLine("             , PMT.NombreProductoModeloTipo")
         .AppendFormatLine("             , 'IdListaControlTipo__' + CONVERT(VARCHAR(MAX), CL.IdListaControlTipo) IdListaControlTipo ")
         .AppendFormatLine("             , 'EIdListaControlTipo__' + CONVERT(VARCHAR(MAX), CL.IdListaControlTipo) IdListaControlTipoE ")
         .AppendFormatLine("          FROM CalidadListasControlProductos PS ")
         .AppendFormatLine("         INNER JOIN Productos P ON P.IdProducto = PS.IdProducto ")
         .AppendFormatLine("         INNER JOIN CalidadListasControl CL ON CL.IdListaControl = PS.IdListaControl ")
         .AppendFormatLine("         INNER JOIN CalidadListasControlTipos CT ON CT.IdListaControlTipo = CL.IdListaControlTipo ")
         .AppendFormatLine(" 	       INNER JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = PS.IdEstadoCalidad ")
         .AppendFormatLine("          LEFT JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto ")
         .AppendFormatLine("          LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")
         .AppendFormatLine("          LEFT JOIN ProductosSucursales PSU ON PSU.IdProducto = P.IdProducto AND PSU.IdSucursal = " & actual.Sucursal.Id)
         .AppendFormatLine("          LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo")
         .AppendFormatLine("          LEFT JOIN CalidadProductosModelosTipos PMT ON PMT.IdProductoModeloTipo = CPM.IdProductoModeloTipo")
         .AppendLine("   WHERE 1 = 1")

         If Not MostrarReparaciones Then
            .AppendLine("   AND P.IdProducto not LIKE '%R%'")
         End If

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("           AND P.IdProducto = '{0}'", idProducto)
         End If

         If fechaDesde.HasValue Then
            .AppendFormat("	   AND P.CalidadFechaIngreso >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormat("      AND P.CalidadFechaIngreso <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         End If

         If idestadoCalidad <> 0 Then
            .AppendFormat("     AND EXISTS (SELECT * FROM CalidadListasControlProductos PS1 WHERE PS1.IdProducto = PS.IdProducto AND PS1.IdEstadoCalidad = {0})", idestadoCalidad)
         End If

         If PanelGerencia Then
            .AppendFormatLine(" AND ((P.CalidadStatusLiberadoPDI = 'False' or  P.CalidadStatusLiberado = 'False')")
            .AppendFormatLine(" OR (P.CalidadStatusLiberadoPDI = 'True' and  P.CalidadStatusLiberado = 'True' AND P.CalidadStatusEntregado = 'False'))")

         Else
            If liberados <> Entidades.Publicos.SiNoTodos.TODOS Then
               .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", liberados = Entidades.Publicos.SiNoTodos.SI)
            End If

            If liberadosPDI <> Entidades.Publicos.SiNoTodos.TODOS Then
               .AppendFormatLine("           AND P.CalidadStatusLiberadoPDI = '{0}'", liberadosPDI = Entidades.Publicos.SiNoTodos.SI)
            End If
         End If


         If entregados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", entregados = Entidades.Publicos.SiNoTodos.SI)
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", idCliente)
         End If
         If Not String.IsNullOrEmpty(ubicacion) Then
            .AppendFormatLine(" AND PSU.Ubicacion = '{0}'", ubicacion)
         End If


         .AppendFormatLine("        ) P")
         .AppendFormatLine("  PIVOT(MAX(P.IdEstadoCalidad) FOR P.IdListaControlTipoE in ({0})) AS P1", pivotcolName2)
         .AppendFormatLine("  PIVOT(MIN(Fecha) FOR P1.IdListaControlTipo in ({0})) AS P1", pivotcolName)
         .AppendFormatLine("  GROUP BY  P1.IdProducto ")
         .AppendLine(" 	,P1.NombreProducto ")
         .AppendLine("  ,P1.CalidadNumeroChasis")
         .AppendLine("  ,P1.NombreCliente")
         .AppendLine("  ,P1.CalidadFechaIngreso ")
         .AppendLine("  ,P1.CalidadFechaEntProg ")
         .AppendLine("  ,P1.CalidadFechaEntReProg")
         .AppendLine("  ,P1.CalidadFechaEgreso ")
         .AppendLine("  ,P1.CalidadFechaLiberado")
         .AppendLine(" 	,P1.CalidadStatusLiberado ")
         .AppendLine("  ,P1.CalidadFechaLiberadoPDI")
         .AppendLine(" 	,P1.CalidadStatusLiberadoPDI")
         .AppendLine(" 	,P1.CalidadStatusEntregado ")
         .AppendLine("  ,P1.NombreProductoModelo")
         .AppendLine("  ,P1.NombreProductoModeloTipo")
         .AppendLine("  ORDER BY P1.CalidadFechaIngreso")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetLeadTimeListasControlTipo(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                   fechaDesdeLiberado As DateTime?, fechaHastaLiberado As DateTime?,
                                                  idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                  liberados As Entidades.Publicos.SiNoTodos, entregados As Entidades.Publicos.SiNoTodos,
                                                  liberadosPDI As Entidades.Publicos.SiNoTodos, IdProductoModeloTipo As Integer,
                                                  pivotcolName As String, sumPivot As String, pivotcolName2 As String, sumPivot2 As String,
                                                  pivotcolName3 As String, sumPivot3 As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P1.IdProducto ")
         .AppendFormatLine(" 	   , P1.NombreProducto ")
         .AppendFormatLine("     , P1.CalidadNumeroChasis")
         .AppendFormatLine(" 	   , P1.NombreCliente")
         ' .AppendFormatLine("     , P1.CalidadFechaIngreso ")
         .AppendFormatLine("    	 , ISNULL((SELECT MIN(CASE WHEN CLCP.CincoSFecha is null THEN CLCP.CincoSFechaC ELSE CASE WHEN CLCP.CincoSFechaC IS NULL THEN CLCP.CincoSFecha ELSE CASE WHEN CLCP.CincoSFecha < CLCP.CincoSFechaC THEN CLCP.CincoSFecha ELSE CLCP.CincoSFechaC END END END)")
         .AppendFormatLine("      FROM CalidadListasControlProductos CLCP")
         .AppendFormatLine("      INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CLCP.IdListaControl")
         .AppendFormatLine("      WHERE CLCP.IdProducto = P1.IdProducto")
         .AppendFormatLine("      AND CLC.BloqueaFechaIngreso = 'True'), P1.CalidadFechaIngreso ) CalidadFechaIngreso")
         .AppendFormatLine("     , P1.CalidadFechaEntProg ")
         .AppendFormatLine("     ,P1.CalidadFechaEntReProg")
         .AppendFormatLine("     , P1.CalidadFechaEgreso ")
         .AppendFormatLine("     , P1.CalidadFechaLiberado")
         .AppendFormatLine(" 	   , P1.CalidadStatusLiberado ")
         .AppendFormatLine("     , P1.CalidadFechaEntregado")
         .AppendFormatLine(" 	   , P1.CalidadStatusEntregado")
         .AppendFormatLine("     ,P1.NombreProductoModelo")
         .AppendFormatLine("     ,P1.NombreProductoModeloTipo")
         .AppendFormatLine("     ,P1.LeadTimeLiberado")
         .AppendFormatLine("     ,P1.LeadTimeLiberadoPDI")
         .AppendFormatLine("     ,P1.DifLeadTimeLeadTimePDI")

         .AppendFormatLine("     ,P1.CalidadFechaLiberadoPDI")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         .AppendFormatLine("     , {0}", sumPivot2.ToString())
         .AppendFormatLine("     , {0}", sumPivot3.ToString())

         .AppendFormatLine("  FROM (SELECT PS.IdProducto ")
         .AppendFormatLine("             , P.NombreProducto ")
         .AppendFormatLine("             , P.CalidadNumeroChasis")
         .AppendFormatLine(" 	           , P.CalidadFechaIngreso ")
         .AppendFormatLine(" 	           , P.CalidadFechaEntProg ")
         .AppendFormatLine("             ,P.CalidadFechaEntReProg")
         .AppendFormatLine(" 	           , P.CalidadFechaEgreso ")
         .AppendFormatLine("             , P.CalidadFechaLiberado")
         .AppendFormatLine("             , P.CalidadStatusLiberado ")
         .AppendFormatLine("             , P.CalidadFechaEntregado")
         .AppendFormatLine(" 	           , P.CalidadStatusEntregado ")
         .AppendFormatLine("             , PS.IdEstadoCalidad ")
         '  .AppendFormatLine("             , case when PS.CincoSFecha is null THEN CASE WHEN PS.CincoSFechaC is NULL THEN  NULL ELSE PS.CincoSFechaC  END ELSE CASE WHEN PS.CincoSFechaC is null THEN PS.CincoSFecha ELSE CASE WHEN PS.CincoSFecha < Ps.CincoSFechaC THEN PS.CincoSFecha ELSE PS.CincoSFechaC END END  END AS Fecha  ")
         .AppendFormatLine("             , CASE WHEN PS.CincoSFechaC is NULL THEN  NULL ELSE PS.CincoSFechaC  END AS Fecha  ")
         .AppendFormatLine("             , PS.CincoSFecha ")
         .AppendFormatLine("             , PS.CincoSFechaC ")
         .AppendFormatLine("             , CE.NombreEstadoCalidad ")
         .AppendFormatLine("             , C.NombreCliente")
         .AppendFormatLine("             , CPM.NombreProductoModelo")
         .AppendFormatLine("             , PMT.NombreProductoModeloTipo")
         .AppendFormatLine("             ,'' as LeadTimeLiberado")
         .AppendFormatLine("             ,'' as LeadTimeLiberadoPDI")
         .AppendFormatLine("             ,'' as DifLeadTimeLeadTimePDI")
         .AppendFormatLine("             , P.CalidadFechaLiberadoPDI")
         .AppendFormatLine("             , 'IdListaControlTipo__' + CONVERT(VARCHAR(MAX), CL.IdListaControlTipo) IdListaControlTipo ")
         .AppendFormatLine("             , 'EIdListaControlTipo__' + CONVERT(VARCHAR(MAX), CL.IdListaControlTipo) IdListaControlTipoE ")
         .AppendFormatLine("             , 'FIdListaControlTipo__' + CONVERT(VARCHAR(MAX), CL.IdListaControlTipo) IdListaControlTipoF ")

         .AppendFormatLine("          FROM CalidadListasControlProductos PS ")
         .AppendFormatLine("         INNER JOIN Productos P ON P.IdProducto = PS.IdProducto ")
         .AppendFormatLine("         INNER JOIN CalidadListasControl CL ON CL.IdListaControl = PS.IdListaControl ")
         .AppendFormatLine("         INNER JOIN CalidadListasControlTipos CT ON CT.IdListaControlTipo = CL.IdListaControlTipo ")
         .AppendFormatLine(" 	       INNER JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = PS.IdEstadoCalidad ")
         .AppendFormatLine("          LEFT JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto ")
         .AppendFormatLine("          LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")
         .AppendFormatLine("          LEFT JOIN ProductosSucursales PSU ON PSU.IdProducto = P.IdProducto AND PSU.IdSucursal = " & actual.Sucursal.Id)
         .AppendFormatLine("          LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo")
         .AppendFormatLine("          LEFT JOIN CalidadProductosModelosTipos PMT ON PMT.IdProductoModeloTipo = CPM.IdProductoModeloTipo")
         .AppendLine("   WHERE 1 = 1")
         .AppendLine("   AND P.IdProducto not LIKE '%R%'")
         '.AppendLine("    AND P.CalidadFechaIngreso is not null")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("           AND P.IdProducto = '{0}'", idProducto)
         End If

         'If fechaDesde.HasValue Then
         '   .AppendFormat("	   AND P.CalidadFechaIngreso >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         'End If
         'If fechaHasta.HasValue Then
         '   .AppendFormat("      AND P.CalidadFechaIngreso <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         'End If

         If fechaDesdeLiberado.HasValue Then
            .AppendFormat("	   AND P.CalidadFechaLiberado >= '{0}'", ObtenerFecha(fechaDesdeLiberado.Value, False))
         End If
         If fechaHastaLiberado.HasValue Then
            .AppendFormat("      AND P.CalidadFechaLiberado <= '{0}'", ObtenerFecha(fechaHastaLiberado.Value.UltimoSegundoDelDia, True))
         End If

         If IdProductoModeloTipo <> 0 Then
            .AppendFormatLine("     AND  PMT.IdProductoModeloTipo = {0}", IdProductoModeloTipo)
         End If


         If idestadoCalidad <> 0 Then
            .AppendFormat("     AND EXISTS (SELECT * FROM CalidadListasControlProductos PS1 WHERE PS1.IdProducto = PS.IdProducto AND PS1.IdEstadoCalidad = {0})", idestadoCalidad)
         End If
         If liberados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", liberados = Entidades.Publicos.SiNoTodos.SI)
         End If
         If entregados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", entregados = Entidades.Publicos.SiNoTodos.SI)
         End If

         If liberadosPDI <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusLiberadoPDI = '{0}'", liberadosPDI = Entidades.Publicos.SiNoTodos.SI)
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", idCliente)
         End If
         If Not String.IsNullOrEmpty(ubicacion) Then
            .AppendFormatLine(" AND PSU.Ubicacion = '{0}'", ubicacion)
         End If


         .AppendFormatLine("        ) P")
         .AppendFormatLine("  PIVOT(MAX(P.IdEstadoCalidad) FOR P.IdListaControlTipoE in ({0})) AS P1", pivotcolName2)
         .AppendFormatLine("  PIVOT(MIN(Fecha) FOR P1.IdListaControlTipo in ({0})) AS P1", pivotcolName)
         .AppendFormatLine(" WHERE 1 = 1")
         If fechaDesde.HasValue Then
            .AppendFormat("	   AND  ISNULL((SELECT MIN(CASE WHEN CLCP.CincoSFecha is null THEN CLCP.CincoSFechaC ELSE CASE WHEN CLCP.CincoSFechaC IS NULL THEN CLCP.CincoSFecha ELSE CASE WHEN CLCP.CincoSFecha < CLCP.CincoSFechaC THEN CLCP.CincoSFecha ELSE CLCP.CincoSFechaC END END END)
      FROM CalidadListasControlProductos CLCP
      INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CLCP.IdListaControl
      WHERE CLCP.IdProducto = P1.IdProducto
      AND CLC.BloqueaFechaIngreso = 'True'), P1.CalidadFechaIngreso ) >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormat("      AND  ISNULL((SELECT MIN(CASE WHEN CLCP.CincoSFecha is null THEN CLCP.CincoSFechaC ELSE CASE WHEN CLCP.CincoSFechaC IS NULL THEN CLCP.CincoSFecha ELSE CASE WHEN CLCP.CincoSFecha < CLCP.CincoSFechaC THEN CLCP.CincoSFecha ELSE CLCP.CincoSFechaC END END END)
      FROM CalidadListasControlProductos CLCP
      INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CLCP.IdListaControl
      WHERE CLCP.IdProducto = P1.IdProducto
      AND CLC.BloqueaFechaIngreso = 'True'), P1.CalidadFechaIngreso ) <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         End If
         ' .AppendFormatLine(" Where p1.IdListaControlTipo__1 <> ''")
         .AppendFormatLine("  GROUP BY  P1.IdProducto ")
         .AppendLine(" 	,P1.NombreProducto ")
         .AppendLine("  ,P1.CalidadNumeroChasis")
         .AppendLine("  ,P1.NombreCliente")
         .AppendLine("  ,P1.CalidadFechaIngreso ")
         .AppendLine("  ,P1.CalidadFechaEntProg ")
         .AppendLine("  ,P1.CalidadFechaEntReProg")
         .AppendLine("  ,P1.CalidadFechaEgreso ")
         .AppendLine("  ,P1.CalidadFechaLiberado")
         .AppendLine(" 	,P1.CalidadStatusLiberado ")
         .AppendLine("  , P1.CalidadFechaEntregado")
         .AppendLine(" 	,P1.CalidadStatusEntregado ")
         .AppendLine("  ,P1.NombreProductoModelo")
         .AppendLine("  ,P1.NombreProductoModeloTipo")
         .AppendLine("  ,P1.LeadTimeLiberado")
         .AppendLine("  ,P1.LeadTimeLiberadoPDI")
         .AppendLine("  ,P1.CalidadFechaLiberadoPDI")
         .AppendLine("  ,P1.DifLeadTimeLeadTimePDI")
         .AppendLine("  ORDER BY P1.CalidadFechaIngreso")
      End With

      Return GetDataTable(stb.ToString())
   End Function


   Public Function GetPanelDeControlWeb(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                  idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                  liberados As Entidades.Publicos.SiNoTodos, entregados As Entidades.Publicos.SiNoTodos,
                                                  liberadosPDI As Entidades.Publicos.SiNoTodos,
                                                  IdProductoModeloTipo As Integer,
                                                  pivotcolName As String, sumPivot As String, pivotcolName2 As String, sumPivot2 As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P1.IdProducto     
		                     , P1.NombreProductoModelo
                           ,P1.IdProductoModeloTipo
                           ,P1.NombreProductoModeloTipo
		                     , P1.NombreCliente
 	                        , ISNULL((SELECT MIN(CASE WHEN CLCP.CincoSFecha is null THEN CLCP.CincoSFechaC ELSE CASE WHEN CLCP.CincoSFechaC IS NULL THEN CLCP.CincoSFecha ELSE CASE WHEN CLCP.CincoSFecha < CLCP.CincoSFechaC THEN CLCP.CincoSFecha ELSE CLCP.CincoSFechaC END END END)
			                  FROM CalidadListasControlProductos CLCP
			                  INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CLCP.IdListaControl
                           WHERE CLCP.IdProducto = P1.IdProducto
			                  AND CLC.BloqueaFechaIngreso = 'True'), P1.CalidadFechaIngreso ) CalidadFechaIngreso
                           ,P1.CalidadFechaEntReProg")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         .AppendFormatLine("     , {0}", sumPivot2.ToString())
         .AppendFormatLine("     , P1.CalidadFechaLiberado")
         .AppendFormatLine("    FROM (SELECT PS.IdProducto 
                           , C.NombreCliente
							      , P.CalidadFechaEntReProg 
                           , P.CalidadNumeroChasis
 	                        , P.CalidadFechaIngreso 
                           , P.CalidadFechaLiberado
 	                        , PS.IdEstadoCalidad 
                       		, CASE WHEN PS.CincoSFechaC is NULL THEN  NULL ELSE PS.CincoSFechaC  END AS Fecha                            
                           , CE.NombreEstadoCalidad 
                           , CPM.NombreProductoModelo
                           ,PMT.IdProductoModeloTipo
                           , PMT.NombreProductoModeloTipo
                           ,CE.Color
                           , 'IdListaControlTipo__' + CONVERT(VARCHAR(MAX), CL.IdListaControlTipo) IdListaControlTipo 
                           , 'EIdListaControlTipo__' + CONVERT(VARCHAR(MAX), CL.IdListaControlTipo) IdListaControlTipoE 
                           FROM CalidadListasControlProductos PS 
                           INNER JOIN Productos P ON P.IdProducto = PS.IdProducto 
                           INNER JOIN CalidadListasControl CL ON CL.IdListaControl = PS.IdListaControl 
                           INNER JOIN CalidadListasControlTipos CT ON CT.IdListaControlTipo = CL.IdListaControlTipo 
 	                        INNER JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = PS.IdEstadoCalidad 
                           LEFT JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto 
                           LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente 
                           LEFT JOIN ProductosSucursales PSU ON PSU.IdProducto = P.IdProducto AND PSU.IdSucursal = 1
                           LEFT JOIN CalidadProductosModelos CPM ON CPM.IdProductoModelo = P.IdProductoModelo
                           LEFT JOIN CalidadProductosModelosTipos PMT ON PMT.IdProductoModeloTipo = CPM.IdProductoModeloTipo
                           WHERE 1 = 1")
         .AppendLine("   AND P.IdProducto not LIKE '%R%'")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("           AND P.IdProducto = '{0}'", idProducto)
         End If

         If fechaDesde.HasValue Then
            .AppendFormat("	   AND P.CalidadFechaIngreso >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormat("      AND P.CalidadFechaIngreso <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         End If

         If idestadoCalidad <> 0 Then
            .AppendFormat("     AND EXISTS (SELECT * FROM CalidadListasControlProductos PS1 WHERE PS1.IdProducto = PS.IdProducto AND PS1.IdEstadoCalidad = {0})", idestadoCalidad)
         End If

         .AppendFormatLine(" AND (P.CalidadStatusLiberadoPDI = 'False' or  P.CalidadStatusLiberado = 'False')")
         .AppendFormatLine(" OR (P.CalidadStatusLiberadoPDI = 'True' and  P.CalidadStatusLiberado = 'True' AND P.CalidadStatusEntregado = 'False')")

         If IdProductoModeloTipo > 0 Then

         End If
         'If liberados <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", liberados = Entidades.Publicos.SiNoTodos.SI)
         'End If

         'If liberadosPDI <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormatLine("           AND P.CalidadStatusLiberadoPDI = '{0}'", liberadosPDI = Entidades.Publicos.SiNoTodos.SI)
         'End If

         If entregados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", entregados = Entidades.Publicos.SiNoTodos.SI)
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", idCliente)
         End If
         If Not String.IsNullOrEmpty(ubicacion) Then
            .AppendFormatLine(" AND PSU.Ubicacion = '{0}'", ubicacion)
         End If


         .AppendFormatLine("        ) P")
         .AppendFormatLine("  PIVOT(MAX(P.IdEstadoCalidad) FOR P.IdListaControlTipoE in ({0})) AS P1", pivotcolName2)
         .AppendFormatLine("  PIVOT(MIN(Fecha) FOR P1.IdListaControlTipo in ({0})) AS P1", pivotcolName)
         If IdProductoModeloTipo > 0 Then
            .AppendFormatLine(" WHERE P1.IdProductoModeloTipo = {0}", IdProductoModeloTipo)
         End If
         .AppendFormatLine("  GROUP BY  P1.IdProducto 
                              ,P1.NombreProductoModelo
                              ,P1.IdProductoModeloTipo
                              ,P1.NombreProductoModeloTipo
                              ,P1.NombreCliente
                              ,P1.CalidadFechaIngreso 
                              ,P1.CalidadFechaEntReProg
                              ,P1.CalidadFechaLiberado
                              ORDER BY P1.CalidadFechaIngreso")
      End With

      Return GetDataTable(stb.ToString())
   End Function
   Public Function ListasControlProductos_GetAuditoria(idProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT LCU.*, LC.NombreListaControl, ELC.NombreEstadoCalidad ")
         .AppendLine(" FROM AuditoriaCalidadListasControlProductos AS LCU")
         .AppendFormat(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendFormat(" LEFT JOIN CalidadEstadosListasControl AS ELC ON ELC.IdEstadoCalidad = LCU.IdEstadoCalidad")

         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProducto.Columnas.IdProducto.ToString(), idProducto)

         .AppendFormat(" ORDER BY LCU.FechaAuditoria  DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductos_GetProductosPanelControl(IdProductoModeloTipo As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PS.IdProducto, P.NombreProducto , CMT.NombreProductoModeloTipo, M.IdProductoModeloTipo  
                     FROM CalidadListasControlProductos PS 
                     INNER JOIN Productos P ON P.IdProducto = PS.IdProducto 
                     LEFT JOIN CalidadProductosModelos M ON M.IdProductoModelo = P.IdProductoModelo
					      LEFT JOIN CalidadProductosModelosTipos CMT ON CMT.IdProductoModeloTipo = M.IdProductoModeloTipo   
                     WHERE P.CalidadStatusLiberadoPDI = 'False'
	                  AND P.CalidadStatusLiberado = 'False'
	                  AND P.IdProducto not LIKE '%R%'")
         If IdProductoModeloTipo > 0 Then
            .AppendFormat(" AND M.IdProductoModeloTipo   = {0} ", IdProductoModeloTipo)
         End If
         .AppendLine(" GROUP BY  PS.IdProducto, NombreProducto , CMT.NombreProductoModeloTipo, M.IdProductoModeloTipo  ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductos_GetProductosPanelControlMetas(IdProductoModeloTipo As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PS.IdProducto, P.NombreProducto , CMT.NombreProductoModeloTipo, M.IdProductoModeloTipo  
                     FROM CalidadListasControlProductos PS 
                     INNER JOIN Productos P ON P.IdProducto = PS.IdProducto 
                     LEFT JOIN CalidadProductosModelos M ON M.IdProductoModelo = P.IdProductoModelo
					      LEFT JOIN CalidadProductosModelosTipos CMT ON CMT.IdProductoModeloTipo = M.IdProductoModeloTipo   
                     WHERE 1 = 1")
         .AppendFormatLine(" AND ((P.CalidadStatusLiberadoPDI = 'False' or  P.CalidadStatusLiberado = 'False')")
         .AppendFormatLine(" OR (P.CalidadStatusLiberadoPDI = 'True' and  P.CalidadStatusLiberado = 'True' AND P.CalidadStatusEntregado = 'False'))")
         .AppendLine(" AND P.IdProducto not LIKE '%R%'")
         If IdProductoModeloTipo > 0 Then
            .AppendFormat(" AND M.IdProductoModeloTipo   = {0} ", IdProductoModeloTipo)
         End If
         .AppendLine(" GROUP BY  PS.IdProducto, NombreProducto , CMT.NombreProductoModeloTipo, M.IdProductoModeloTipo  ")

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetProximoNroCertificado() As Integer

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT MAX(" & Entidades.Producto.Columnas.CalidadNroCertificado.ToString & ") AS Maximo FROM Productos")
      End With

      Dim dt As DataTable = Me._da.GetDataTable(stb.ToString())

      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString()) + 1
         Else
            val = 1
         End If
      End If

      Return val

   End Function

   Public Function GetProximoNroCertEntregado() As Integer

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT MAX(" & Entidades.Producto.Columnas.CalidadNroCertEntregado.ToString & ") AS Maximo FROM Productos")
      End With

      Dim dt As DataTable = Me._da.GetDataTable(stb.ToString())

      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString()) + 1
         Else
            val = 1
         End If
      End If

      Return val

   End Function

   Public Function ListasControlProductos_GListasxProductoPendientesAuditoria(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                           IdListaControl As Integer, Liberado As Boolean,
                                           Entregado As Boolean, IdCliente As Long, IdEstado As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT   LC.NombreListaControl ,LCU.FechaAuditoria, LCU.OperacionAuditoria,LCU.UsuarioAuditoria, 
                     LCU.IdProducto, LCU.IdListaControl, CP.Observacion
                     ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia, P.NombreProducto, CE.NombreEstadoCalidad, CE.Color
                     FROM AuditoriaCalidadListasControlProductos AS LCU
                     INNER JOIN CalidadListasControlProductos CP ON CP.IdProducto = LCU.IdProducto AND CP.IdListaControl = LCU.IdListaControl
                     LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl
                     LEFT JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = CP.IdEstadoCalidad
                     INNER JOIN Productos P ON P.IdProducto = LCU.IdProducto 
                     LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto 
                     LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")

         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)

         .AppendLine(" WHERE 1 = 1")


         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
         End If
         .AppendFormat("	  AND LCU.FechaAuditoria >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))
         .AppendFormat("  AND LCU.FechaAuditoria <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))

         If IdListaControl <> 0 Then
            .AppendFormatLine("           AND LCU.IdListaControl = '{0}'", IdListaControl)
         End If
         If IdEstado <> 0 Then
            .AppendFormatLine("           AND CP.IdEstadoCalidad = '{0}'", IdEstado)
         End If

         If Liberado Then
            .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", Liberado)
         End If
         If Entregado Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", Entregado)
         End If
         If IdCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", IdCliente)

         End If

         .AppendFormat(" ORDER BY LCU.FechaAuditoria, LCU.IdProducto, LCU.IdListaControl, LC.IdListaControl")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class