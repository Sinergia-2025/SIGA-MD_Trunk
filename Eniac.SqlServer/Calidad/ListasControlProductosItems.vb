Public Class ListasControlProductosItems
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ListasControlProductosItems_I(IdProducto As String,
                                       IdListaControl As Integer,
                                       Item As Integer,
                                       IdListaControlItem As Integer,
                                       Ok As Boolean,
                                       NoOk As Boolean,
                                       Obs As Boolean,
                                       Mat As Boolean,
                                       NA As Boolean,
                                       Observ As String,
                                       Orden As Integer,
                                       Usuario As String,
                                       FechaMod As DateTime,
                                       OkCalidad As Boolean,
                                       NoOkCalidad As Boolean,
                                       ObsCalidad As Boolean,
                                       MatCalidad As Boolean,
                                       NACalidad As Boolean,
                                       ObservCalidad As String,
                                       UsuarioCalidad As String,
                                       FechaModCalidad As DateTime)



      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadListasControlProductosItems ({0}, {1} ,{2} ,{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20})",
                        Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.IdListaControl.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.IdListaControlItem.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.Ok.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.NoOk.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.Obs.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.Mat.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.NA.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.Observ.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.Orden.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.Usuario.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.FechaMod.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.OkCalidad.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.NoOkCalidad.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.ObsCalidad.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.MatCalidad.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.NACalidad.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.ObservCalidad.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.UsuarioCalidad.ToString(),
                        Entidades.ListaControlProductoItem.Columnas.FechaModCalidad.ToString()).AppendLine()


         .AppendFormat("     VALUES ('{0}', {1} ,{2} ,{3},'{4}','{5}','{6}','{7}','{8}','{9}',{10},'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')",
                      IdProducto, IdListaControl, Item, IdListaControlItem, Ok, NoOk, Obs, Mat, NA, Observ, Orden, Usuario, FechaMod, OkCalidad, NoOkCalidad,
                      ObsCalidad, MatCalidad, NACalidad, ObservCalidad, UsuarioCalidad, FechaModCalidad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlProductosItems_U(IdProducto As String,
                                       IdListaControl As Integer,
                                       Item As Integer,
                                       IdListaControlItem As Integer,
                                       Ok As Boolean,
                                       NoOk As Boolean,
                                       Obs As Boolean,
                                       Mat As Boolean,
                                       NA As Boolean,
                                       Observ As String,
                                       Orden As Integer,
                                       Usuario As String,
                                       FechaMod As DateTime,
                                       OkCalidad As Boolean,
                                       NoOkCalidad As Boolean,
                                       ObsCalidad As Boolean,
                                       MatCalidad As Boolean,
                                       NACalidad As Boolean,
                                       ObservCalidad As String,
                                       UsuarioCalidad As String,
                                       FechaModCalidad As DateTime)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadListasControlProductosItems ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.Ok.ToString(), Ok).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.NoOk.ToString(), NoOk).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.Obs.ToString(), Obs).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.Mat.ToString(), Mat).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.NA.ToString(), NA).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.Observ.ToString(), Observ.Replace("'", "´")).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.Usuario.ToString(), Usuario).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.FechaMod.ToString(), FechaMod).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.OkCalidad.ToString(), OkCalidad).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.NoOkCalidad.ToString(), NoOkCalidad).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.ObsCalidad.ToString(), ObsCalidad).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.MatCalidad.ToString(), MatCalidad).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.NACalidad.ToString(), NACalidad).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.ObservCalidad.ToString(), ObservCalidad.Replace("'", "´")).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.UsuarioCalidad.ToString(), UsuarioCalidad).AppendLine()
         .AppendFormat("   ,{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.FechaModCalidad.ToString(), FechaModCalidad).AppendLine()

         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), IdProducto)
         .AppendFormat(" AND {0} = {1}", Entidades.ListaControlProductoItem.Columnas.IdListaControl.ToString(), IdListaControl)
         .AppendFormat(" AND {0} = {1}", Entidades.ListaControlProductoItem.Columnas.Item.ToString(), Item)


      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlProductosItems_D(idProducto As String, IdListaControl As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlProductosItems ")
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormat(" AND {0} = {1}", Entidades.ListaControlProductoItem.Columnas.IdListaControl.ToString(), IdListaControl)


      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlProductosItems_D(idProducto As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlProductosItems ")
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT  LCI.NombreListaControlItem ,LCU.* , '' as Modif")
         .AppendLine(" FROM CalidadListasControlProductosItems AS LCU")
         .AppendLine(" LEFT JOIN CalidadListasControlItems AS LCI ON LCI.IdListaControlItem = LCU.IdListaControlItem ")

      End With
   End Sub

   Public Function ListasControlProductosItems_GA(idProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
         End If

         .AppendFormat(" ORDER BY LCU.IdListaControl, LCU.IdListaControlItem")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductosItems_GItemsxProducto(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                IdestadoCalidad As Integer, Liberado As Boolean,
                                                Entregado As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = LCU.IdProducto ")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
         End If
         .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))

         .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))

         If IdestadoCalidad <> 0 Then
            .AppendFormatLine("           AND PS.IdEstadoCalidad = '{0}'", IdestadoCalidad)
         End If
         If Liberado Then
            .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", Liberado)
         End If
         If Entregado Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", Entregado)
         End If

         .AppendFormat(" ORDER BY LCU.IdListaControl, LCU.IdListaControlItem")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductosItems_GItemsxProductoPendientes(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                             IdListaControl As Integer, Liberado As Boolean,
                                             Entregado As Boolean, IdCliente As Long, Situacion As String, IdEstado As Integer, Ubicacion As String,
                                             Items As List(Of String), IdListaControlTipo As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT  LCI.NombreListaControlItem ,LCU.*  , LC.NombreListaControl ")
         .AppendLine(" ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia, P.NombreProducto, CE.NombreEstadoCalidad, CE.Color, CLCT.NombreListaControlTipo")
         .AppendLine(" FROM CalidadListasControlProductosItems AS LCU")
         .AppendLine("  INNER JOIN CalidadListasControlProductos CP ON CP.IdProducto = LCU.IdProducto AND CP.IdListaControl = LCU.IdListaControl")
         .AppendLine(" LEFT JOIN CalidadListasControlItems AS LCI ON LCI.IdListaControlItem = LCU.IdListaControlItem ")
         .AppendLine(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendLine("  LEFT JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = CP.IdEstadoCalidad")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = LCU.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)
         .AppendLine(" LEFT JOIN CalidadListasControlTipos CLCT ON CLCT.IdListaControlTipo = LC.IdListaControlTipo")
         .AppendLine(" WHERE 1 = 1")
         Select Case Situacion
            Case "PENDIENTES"
               .AppendLine("  AND ( (LCU.Ok = 0 AND LCU.NoOk = 0 AND LCU.Obs = 0 AND LCU.Mat = 0 AND LCU.NA = 0 AND LC.ControlaProduccion = 'True') ")
               .AppendLine("  OR ( LCU.OkCalidad = 0 AND LCU.NoOkCalidad = 0 AND LCU.ObsCalidad = 0 AND LCU.MatCalidad = 0 AND LCU.NACalidad = 0 AND LC.ControlaCalidad = 'True'))")
               .AppendLine("  AND CE.Finalizado = 0")
            Case "DIFERENCIAS"
               .AppendLine(" AND (LCU.ok <> LCU.OkCalidad OR LCU.NoOk <> LCU.NoOkCalidad)  ")
               .AppendLine(" AND LC. ControlaProduccion = 'True' ")
               .AppendLine(" AND LC.ControlaCalidad = 'True'")
            Case "RECHAZADO"
               .AppendLine(" AND ((LCU.NoOk = 1 AND LC.ControlaProduccion = 'True') OR (LCU.NoOkCalidad = 1 AND LC.ControlaCalidad = 'True') )  ")
            Case Else
         End Select


         '# Items
         If Not String.IsNullOrEmpty(Items.Item(0).ToString()) Then
            Dim i As Integer = 0
            Dim entro As Boolean = False
            .AppendLine("AND (")
            For Each item As String In Items
               ' .AppendFormat("'{0}',", tipo)
               ' If Not String.IsNullOrEmpty(itemSeleccionado) Then
               Select Case item
                  Case Entidades.ListaControlProductoItem.Columnas.Ok.ToString()
                     .AppendLine("  (LCU.Ok = 'True' OR LCU.OkCalidad = 'True')")
                  Case Entidades.ListaControlProductoItem.Columnas.NoOk.ToString()
                     .AppendLine(" (LCU.NoOk = 'True' OR LCU.NoOkCalidad = 'True')")
                  Case Entidades.ListaControlProductoItem.Columnas.Obs.ToString()
                     .AppendLine(" (LCU.Obs = 'True' OR LCU.ObsCalidad = 'True')")
                  Case Entidades.ListaControlProductoItem.Columnas.Mat.ToString()
                     .AppendLine(" (LCU.Mat = 'True' OR LCU.MatCalidad = 'True')")
                  Case Entidades.ListaControlProductoItem.Columnas.NA.ToString()
                     .AppendLine(" (LCU.NA = 'True' OR LCU.NACalidad = 'True')")
               End Select
               i += 1
               If i < Items.Count Then
                  .Append(" OR ")
               End If
               entro = False
            Next
            .AppendLine(")")
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
         End If
         .AppendFormat("	  AND P.CalidadFechaIngreso >= '{0} 00:00:00'", FechaDesde.ToString("yyyyMMdd"))
         .AppendFormat("  AND P.CalidadFechaIngreso <= '{0} 23:59:59'", FechaHasta.ToString("yyyyMMdd"))

         If IdListaControl <> 0 Then
            .AppendFormatLine("           AND LCU.IdListaControl = '{0}'", IdListaControl)
         End If

         If IdListaControlTipo <> 0 Then
            .AppendFormatLine("           AND LC.IdListaControlTipo = '{0}'", IdListaControlTipo)
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

         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PS.Ubicacion = '" & Ubicacion & "'")
         End If

         .AppendFormat(" ORDER BY C.NombreCliente,  P.NombreProducto, LC.Orden, LCU.IdListaControlItem")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductosItems_GItemsxProductoPendientesAuditoria(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                            IdListaControl As Integer, Liberado As Boolean,
                                            Entregado As Boolean, IdCliente As Long, Situacion As String, IdEstado As Integer, Ubicacion As String,
                                            itemSeleccionado As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT   LCI.NombreListaControlItem ,LCU.FechaAuditoria, LCU.OperacionAuditoria,LCU.UsuarioAuditoria, ")
         .AppendLine(" LCU.IdProducto, LCU.IdListaControl, LCU.Item, LCU.IdListaControlItem, LCU.Ok, LCU.NoOk, LCU.Obs, LCU.Mat, ")
         .AppendLine(" LCU.NA, LCU.Observ, LCU.Orden, LCU.OkCalidad, LCU.NoOkCalidad, LCU.ObsCalidad, LCU.MatCalidad, LCU.NACalidad, ")
         .AppendLine(" LCU.ObservCalidad ")
         .AppendLine("  , LC.NombreListaControl ")
         .AppendLine(" ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia, P.NombreProducto, CE.NombreEstadoCalidad, CE.Color")
         .AppendLine(" FROM AuditoriaCalidadListasControlProductosItems AS LCU")
         .AppendLine("  INNER JOIN CalidadListasControlProductos CP ON CP.IdProducto = LCU.IdProducto AND CP.IdListaControl = LCU.IdListaControl")
         .AppendLine(" LEFT JOIN CalidadListasControlItems AS LCI ON LCI.IdListaControlItem = LCU.IdListaControlItem ")
         .AppendLine(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendLine("  LEFT JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = CP.IdEstadoCalidad")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = LCU.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)

         .AppendLine(" WHERE 1 = 1")
         Select Case Situacion
            Case "PENDIENTES"
               .AppendLine("  AND ( (LCU.Ok = 0 AND LCU.NoOk = 0 AND LCU.Obs = 0 AND LCU.Mat = 0 AND LCU.NA = 0 AND LC.ControlaProduccion = 'True') ")
               .AppendLine("  OR ( LCU.OkCalidad = 0 AND LCU.NoOkCalidad = 0 AND LCU.ObsCalidad = 0 AND LCU.MatCalidad = 0 AND LCU.NACalidad = 0 AND LC.ControlaCalidad = 'True'))")
               .AppendLine("  AND CE.Finalizado = 0")
            Case "DIFERENCIAS"
               .AppendLine(" AND (LCU.ok <> LCU.OkCalidad OR LCU.NoOk <> LCU.NoOkCalidad)  ")
               .AppendLine(" AND LC. ControlaProduccion = 'True' ")
               .AppendLine(" AND LC.ControlaCalidad = 'True'")
            Case "RECHAZADO"
               .AppendLine(" AND ((LCU.NoOk = 1 AND LC.ControlaProduccion = 'True') OR (LCU.NoOkCalidad = 1 AND LC.ControlaCalidad = 'True') )  ")
            Case Else
         End Select

         '# Items
         If Not String.IsNullOrEmpty(itemSeleccionado) Then
            Select Case itemSeleccionado
               Case Entidades.ListaControlProductoItem.Columnas.Ok.ToString()
                  .AppendLine("  AND (LCU.Ok = 'True' OR LCU.OkCalidad = 'True')")
               Case Entidades.ListaControlProductoItem.Columnas.NoOk.ToString()
                  .AppendLine("  AND (LCU.NoOk = 'True' OR LCU.NoOkCalidad = 'True')")
               Case Entidades.ListaControlProductoItem.Columnas.Obs.ToString()
                  .AppendLine("  AND (LCU.Obs = 'True' OR LCU.ObsCalidad = 'True')")
               Case Entidades.ListaControlProductoItem.Columnas.Mat.ToString()
                  .AppendLine("  AND (LCU.Mat = 'True' OR LCU.MatCalidad = 'True')")
               Case Entidades.ListaControlProductoItem.Columnas.NA.ToString()
                  .AppendLine("  AND (LCU.NA = 'True' OR LCU.NACalidad = 'True')")
            End Select
         End If

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

         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PS.Ubicacion = '" & Ubicacion & "'")
         End If

         .AppendFormat(" ORDER BY LCU.FechaAuditoria, LCU.IdProducto, LCU.IdListaControl, LCU.IdListaControlItem")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductosItems_GInformeDeMaterialesFaltantes(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                            IdListaControl As Integer, Liberado As Boolean,
                                            Entregado As Boolean, IdCliente As Long, Situacion As String, IdEstado As Integer, Ubicacion As String,
                                            itemSeleccionado As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("  WITH records AS (")
         .AppendLine("SELECT   LCI.NombreListaControlItem ,LCU.FechaAuditoria, LCU.OperacionAuditoria,LCU.UsuarioAuditoria, ")
         .AppendLine(" LCU.IdProducto, LCU.IdListaControl, LCU.Item, LCU.IdListaControlItem, LCU.Ok, LCU.NoOk, LCU.Obs, LCU.Mat, ")
         .AppendLine(" LCU.NA, LCU.Observ, LCU.Orden, LCU.OkCalidad, LCU.NoOkCalidad, LCU.ObsCalidad, LCU.MatCalidad, LCU.NACalidad, ")
         .AppendLine(" LCU.ObservCalidad ")
         .AppendLine("  , LC.NombreListaControl ")
         .AppendLine(" ,C.CodigoCliente, C.NombreCliente, C.NombreDeFantasia, P.NombreProducto, CE.NombreEstadoCalidad, CE.Color")
         .AppendLine(" ,ROW_NUMBER() OVER (PARTITION BY LCU.IdListaControl, LCU.IdListaControlItem, LCU.IdProducto 
                          ORDER BY LCU.FechaAuditoria ASC) AS rn")
         .AppendLine(" FROM AuditoriaCalidadListasControlProductosItems AS LCU")
         .AppendLine("  INNER JOIN CalidadListasControlProductos CP ON CP.IdProducto = LCU.IdProducto AND CP.IdListaControl = LCU.IdListaControl")
         .AppendLine(" LEFT JOIN CalidadListasControlItems AS LCI ON LCI.IdListaControlItem = LCU.IdListaControlItem ")
         .AppendLine(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendLine("  LEFT JOIN CalidadEstadosListasControl CE ON CE.IdEstadoCalidad = CP.IdEstadoCalidad")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = LCU.IdProducto ")
         .AppendLine(" LEFT JOIN ProductosClientes PC   ON PC.IdProducto = P.IdProducto ")
         .AppendLine(" LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente  ")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto AND PS.IdSucursal = " & actual.Sucursal.Id)

         .AppendLine(" WHERE 1 = 1")
         Select Case Situacion
            Case "PENDIENTES"
               .AppendLine("  AND ( (LCU.Ok = 0 AND LCU.NoOk = 0 AND LCU.Obs = 0 AND LCU.Mat = 0 AND LCU.NA = 0 AND LC.ControlaProduccion = 'True') ")
               .AppendLine("  OR ( LCU.OkCalidad = 0 AND LCU.NoOkCalidad = 0 AND LCU.ObsCalidad = 0 AND LCU.MatCalidad = 0 AND LCU.NACalidad = 0 AND LC.ControlaCalidad = 'True'))")
               .AppendLine("  AND CE.Finalizado = 0")
            Case "DIFERENCIAS"
               .AppendLine(" AND (LCU.ok <> LCU.OkCalidad OR LCU.NoOk <> LCU.NoOkCalidad)  ")
               .AppendLine(" AND LC. ControlaProduccion = 'True' ")
               .AppendLine(" AND LC.ControlaCalidad = 'True'")
            Case "RECHAZADO"
               .AppendLine(" AND ((LCU.NoOk = 1 AND LC.ControlaProduccion = 'True') OR (LCU.NoOkCalidad = 1 AND LC.ControlaCalidad = 'True') )  ")
            Case Else
         End Select

         '# Items
         If Not String.IsNullOrEmpty(itemSeleccionado) Then
            Select Case itemSeleccionado
               Case Entidades.ListaControlProductoItem.Columnas.Ok.ToString()
                  .AppendLine("  AND (LCU.Ok = 'True' OR LCU.OkCalidad = 'True')")
               Case Entidades.ListaControlProductoItem.Columnas.NoOk.ToString()
                  .AppendLine("  AND (LCU.NoOk = 'True' OR LCU.NoOkCalidad = 'True')")
               Case Entidades.ListaControlProductoItem.Columnas.Obs.ToString()
                  .AppendLine("  AND (LCU.Obs = 'True' OR LCU.ObsCalidad = 'True')")
               Case Entidades.ListaControlProductoItem.Columnas.Mat.ToString()
                  .AppendLine("  AND LCU.MatCalidad = 'True'")
               Case Entidades.ListaControlProductoItem.Columnas.NA.ToString()
                  .AppendLine("  AND (LCU.NA = 'True' OR LCU.NACalidad = 'True')")
            End Select
         End If

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

         If Not String.IsNullOrEmpty(Ubicacion) Then
            .AppendFormat(" AND PS.Ubicacion = '" & Ubicacion & "'")
         End If
         .AppendLine("   ) SELECT * FROM records WHERE rn = 1")
         '  .AppendFormat(" ORDER BY LCU.FechaAuditoria, LCU.IdProducto, LCU.IdListaControl, LCU.IdListaControlItem")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductosItems_GxProductoListaControl(idProducto As String, IdListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdListaControl.ToString(), IdListaControl)

         .AppendFormat(" ORDER BY LCU.IdListaControl, LCU.IdListaControlItem")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductosItems_GListaControlProductoItemsOK(idProducto As String, IdListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
         .AppendLine("   AND LCU.OkCalidad <> 1 AND LCU.MatCalidad <> 1 AND LCU.NACalidad <> 1")
         .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdListaControl.ToString(), IdListaControl)

         .AppendFormat(" ORDER BY LCU.IdListaControl, LCU.IdListaControlItem")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function ListasControlProductosItems_GListaControlProductoItemsOKProd(idProducto As String, IdListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)
         .AppendLine("   AND LCU.Ok <> 1 AND LCU.Mat <> 1 AND LCU.NA <> 1")
         .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdListaControl.ToString(), IdListaControl)

         .AppendFormat(" ORDER BY LCU.IdListaControl, LCU.IdListaControlItem")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function ListasControlProductosItems_GxRoles(idProducto As String, Roles As DataTable) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" INNER JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
         .AppendLine("  LEFT JOIN CalidadListasControlRoles LCR ON LCR.IdListaControl = LC.IdListaControl")
         .AppendLine("	And LCR.IdRol IN (")
         For Each rol As DataRow In Roles.Rows
            .AppendFormat("'{0}',", rol("IdRol").ToString())
         Next
         .Remove(.Length - 1, 1)
         .AppendLine(")")
         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)

         .AppendFormat(" ORDER BY LCU.IdListaControl, LCU.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductosItems_GetAuditoria(idProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT ' ' AS Modificado")
         .AppendLine("      ,LCU.FechaAuditoria")
         .AppendLine("      ,LCU.OperacionAuditoria")
         .AppendLine("      ,LCU.UsuarioAuditoria")
         .AppendLine(" ,LCI.NombreListaControlItem ,LCU.* ")
         .AppendLine(" FROM AuditoriaCalidadListasControlProductosItems AS LCU")
         .AppendLine(" LEFT JOIN CalidadListasControlItems AS LCI ON LCI.IdListaControlItem = LCU.IdListaControlItem ")

         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)

         .AppendFormat(" ORDER BY LCU.FechaAuditoria  DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlProductosItems_GetInformeAuditoria(idProducto As String, IdListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT ' ' AS Modificado")
         .AppendLine("      ,LCU.FechaAuditoria")
         .AppendLine("      ,LCU.OperacionAuditoria")
         .AppendLine("      ,LCU.UsuarioAuditoria")
         .AppendLine(" ,LCI.NombreListaControlItem ,LCU.* ")
         .AppendLine(" FROM AuditoriaCalidadListasControlProductosItems AS LCU")
         .AppendLine(" LEFT JOIN CalidadListasControlItems AS LCI ON LCI.IdListaControlItem = LCU.IdListaControlItem ")

         .AppendFormat(" WHERE LCU.{0} = '{1}'", Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(), idProducto)

         .AppendFormat(" ORDER BY LCU.FechaAuditoria  DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class