Option Explicit On
Option Strict On
Public Class ActivacionesOC
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ActivacionesOC_I(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     IdProducto As String,
                                     Orden As Integer,
                                     OrdenActivacion As Integer,
                                     Contacto As String,
                                     IdUsuario As String,
                                     FechaActivacion As DateTime,
                                     observacion As String,
                                     IdObservacion As Integer,
                                     FechaReprogEntrega As DateTime,
                                     TelefonoProveedor As String,
                                     CorreoElectronico As String,
                                     Items As Boolean,
                                     Cantidades As Boolean,
                                     Precio As Boolean,
                                     FechaE As Boolean,
                                     Criticidad As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO CalidadOCActivaciones ")
         .AppendLine("   (IdSucursal")
         .AppendLine("   ,IdTipoComprobante")
         .AppendLine("   ,Letra")
         .AppendLine("   ,CentroEmisor")
         .AppendLine("   ,NumeroPedido")
         .AppendLine("   ,IdProducto")
         .AppendLine("   ,Orden")
         .AppendLine("   ,OrdenActivacion")
         .AppendLine("   ,Contacto")
         .AppendLine("   ,IdUsuario")
         .AppendLine("   ,FechaActivacion")
         .AppendLine("   ,Observacion")
         .AppendLine("   ,IdObservacion")
         .AppendLine("   ,FechaReprogEntrega")
         .AppendLine("   ,TelefonoProveedor")
         .AppendLine("   ,CorreoElectronico")
         .AppendLine("   ,Items")
         .AppendLine("   ,Cantidades")
         .AppendLine("   ,Precio")
         .AppendLine("   ,FechaE")
         .AppendLine("   ,Criticidad")

         .AppendLine(") VALUES ")
         .AppendFormat("  ({0}", idSucursal).AppendLine()
         .AppendFormat(" ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat(" ,'{0}'", letra).AppendLine()
         .AppendFormat(" , {0}", centroEmisor).AppendLine()
         .AppendFormat(" , {0}", numeroPedido).AppendLine()
         .AppendFormat(" ,'{0}'", IdProducto).AppendLine()
         .AppendFormat(" , {0}", Orden).AppendLine()
         .AppendFormat(" , {0}", OrdenActivacion).AppendLine()
         .AppendFormat(" ,'{0}'", Contacto).AppendLine()
         .AppendFormat(" ,'{0}'", IdUsuario).AppendLine()
         .AppendFormat(" ,'{0}'", Me.ObtenerFecha(FechaActivacion, True)).AppendLine()
         .AppendFormat(" ,'{0}'", observacion).AppendLine()
         If IdObservacion = 0 Then
            .AppendFormat(" , NULL").AppendLine()
         Else
            .AppendFormat(" , {0}", IdObservacion).AppendLine()
         End If
         If FechaReprogEntrega <> Nothing Then
            .AppendFormat(" ,'{0}'", Me.ObtenerFecha(FechaReprogEntrega, True)).AppendLine()
         Else
            .AppendFormat(" , NULL").AppendLine()
         End If
         .AppendFormat(" ,'{0}'", TelefonoProveedor).AppendLine()
         .AppendFormat(" ,'{0}'", CorreoElectronico).AppendLine()
         .AppendFormat(" ,'{0}'", Items).AppendLine()
         .AppendFormat(" ,'{0}'", Cantidades).AppendLine()
         .AppendFormat(" ,'{0}'", Precio).AppendLine()
         .AppendFormat(" ,'{0}'", FechaE).AppendLine()
         .AppendFormat(" ,'{0}'", Criticidad).AppendLine()

         .AppendFormat(" )").AppendLine()
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadOCActivaciones")
   End Sub

   Public Sub ActivacionesOC_U(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     IdProducto As String,
                                     Orden As Integer,
                                     OrdenActivacion As Integer,
                                     Contacto As String,
                                     IdUsuario As String,
                                     FechaActivacion As DateTime,
                                     observacion As String,
                                     IdObservacion As Integer,
                                     FechaReprogEntrega As DateTime,
                                     TelefonoProveedor As String,
                                     CorreoElectronico As String,
                                     Items As Boolean,
                                     Cantidades As Boolean,
                                     Precio As Boolean,
                                     FechaE As Boolean,
                                     Criticidad As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE CalidadOCActivaciones SET ").AppendLine()
         .AppendFormat("  IdUsuario = '{0}'", IdUsuario).AppendLine()
         .AppendFormat("  ,Contacto = '{0}'", Contacto).AppendLine()
         .AppendFormat("  ,FechaActivacion = '{0}'", Me.ObtenerFecha(FechaActivacion, True)).AppendLine()
         .AppendFormat("  ,Observacion = '{0}'", observacion).AppendLine()
         If IdObservacion = 0 Then
            .AppendFormat("  ,IdObservacion = NULL").AppendLine()
         Else
            .AppendFormat("  ,IdObservacion = {0}", IdObservacion).AppendLine()
         End If
         If FechaReprogEntrega <> Nothing Then
            .AppendFormat("  ,FechaReprogEntrega = '{0}'", Me.ObtenerFecha(FechaReprogEntrega, True)).AppendLine()
         Else
            .AppendFormat("  ,FechaReprogEntrega = NULL").AppendLine()
         End If
         .AppendFormat("  ,TelefonoProveedor = '{0}'", TelefonoProveedor).AppendLine()
         .AppendFormat("  ,CorreoElectronico = '{0}'", CorreoElectronico).AppendLine()
         .AppendFormat("  ,Items = '{0}'", Items).AppendLine()
         .AppendFormat("  ,Cantidades = '{0}'", Cantidades).AppendLine()
         .AppendFormat("  ,Precio = '{0}'", Precio).AppendLine()
         .AppendFormat("  ,FechaE = '{0}'", FechaE).AppendLine()
         .AppendFormat("  ,Criticidad = '{0}'", Criticidad).AppendLine()

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendFormat("   AND IdProducto = '{0}'", IdProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", Orden).AppendLine()
         .AppendFormat("   AND OrdenActivacion = {0}", OrdenActivacion).AppendLine()

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadOCActivaciones")
   End Sub

   Public Sub ActivacionesOC_D(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     Idproducto As String,
                                     Orden As Integer,
                                     OrdenActivacion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM CalidadOCActivaciones ")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendFormat("   AND IdProducto = '{0}'", Idproducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", Orden).AppendLine()
         .AppendFormat("   AND OrdenActivacion = {0}", OrdenActivacion).AppendLine()

         'If linea > 0 Then
         '   .AppendFormat("   AND Linea = {0}", linea).AppendLine()
         'End If
      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalidadOCActivaciones")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT OCA.*, OB.DetalleObservacion").AppendLine()
         .AppendFormat("  FROM CalidadOCActivaciones AS OCA").AppendLine()
         .AppendFormat(" LEFT JOIN Observaciones OB ON OB.IdObservacion = OCA.IdObservacion")
      End With
   End Sub

   Public Function CalidadOCActivaciones_GA(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroPedido As Long,
                                           Idproducto As String) As DataTable
      Return ActivacionesOC_G(idSucursal,
                                    idTipoComprobante,
                                    letra,
                                    centroEmisor,
                                    numeroPedido,
                                    Idproducto, 0, 0)
   End Function
   Private Function ActivacionesOC_G(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long,
                                            IdProducto As String,
                                            Orden As Integer,
                                            OrdenActivacion As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND OCA.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND OCA.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND OCA.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND OCA.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND OCA.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(IdProducto) Then
            .AppendFormat("   AND OCA.IdProducto = '{0}'", IdProducto).AppendLine()
         End If
         'If Orden = 0 Then
         '   .AppendFormat("   AND OCA.Orden = 0").AppendLine()
         'Else
         '   .AppendFormat("   AND OCA.Orden = {0}", Orden).AppendLine()
         'End If
         'If OrdenActivacion > 0 Then
         '   .AppendFormat("   AND OCA.OrdenActivacion = {0}", OrdenActivacion).AppendLine()
         'End If
         .AppendLine(" ORDER BY OCA.NumeroPedido, OCA.IdProducto, OCA.FechaActivacion DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ActivacionesOC_GetUltimaActivacion(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long,
                                            Orden As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine(" SELECT * FROM CalidadOCActivaciones AS OCA ")
         ' Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND OCA.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND OCA.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND OCA.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND OCA.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND OCA.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If
         'If Not String.IsNullOrWhiteSpace(IdProducto) Then
         '   .AppendFormat("   AND OCA.IdProducto = '{0}'", IdProducto).AppendLine()
         'End If
         .AppendFormat("   AND OCA.Orden = 0").AppendLine()

         .AppendLine("  ORDER BY OCA.OrdenActivacion DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Function ActivacionesOC_G1(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroPedido As Long,
                                           idproducto As String,
                                           Orden As Integer,
                                           OrdenActivacion As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND OCA.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND OCA.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND OCA.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND OCA.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND OCA.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idproducto) Then
            .AppendFormat("   AND OCA.IdProducto = '{0}'", idproducto).AppendLine()
         End If
         If Orden = 0 Then
            .AppendFormat("   AND OCA.Orden = 0").AppendLine()
         Else
            .AppendFormat("   AND OCA.Orden = {0}", Orden).AppendLine()
         End If
         If OrdenActivacion > 0 Then
            .AppendFormat("   AND OCA.OrdenActivacion = {0}", OrdenActivacion).AppendLine()
         End If
         .AppendLine(" ORDER BY OCA.NumeroPedido, OCA.IdProducto, OCA.FechaActivacion DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(OC As Entidades.PedidoProveedor, idProducto As String, orden As Integer) As Integer
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         .AppendFormat("   AND OCA.IdSucursal = {0}", OC.IdSucursal).AppendLine()
         .AppendFormat("   AND OCA.IdTipoComprobante = '{0}'", OC.IdTipoComprobante).AppendLine()
         .AppendFormat("   AND OCA.Letra = '{0}'", OC.LetraComprobante).AppendLine()
         .AppendFormat("   AND OCA.CentroEmisor = {0}", OC.CentroEmisor).AppendLine()
         .AppendFormat("   AND OCA.NumeroPedido = {0}", OC.NumeroPedido).AppendLine()
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND OCA.IdProducto = '{0}'", idProducto).AppendLine()
         End If
         If orden = 0 Then
            .AppendFormat("   AND OCA.Orden = 0").AppendLine()
         Else
            .AppendFormat("   AND OCA.Orden = {0}", orden).AppendLine()
         End If
         .AppendFormat(" ORDER BY OCA.OrdenActivacion DESC")

      End With
      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If dt.Rows.Count <> 0 Then
         Return Convert.ToInt32(dt.Rows(0).Item("OrdenActivacion").ToString())
      Else
         Return 0
      End If

   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} = '{1}'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ActivacionesOC_Informe(numeroPedido As Long, IdProducto As String,
                                          Activaciones As String, Criticidad As String,
                                          IdObservacion As Integer,
                                          FechaDesde As Date,
                                          FechaHasta As Date,
                                          fechaDesdeEntrega As Date,
                                          fechaHastaEntrega As Date,
                                          fechaDesdeRepEntrega As Date,
                                          fechaHastaRepEntrega As Date,
                                          tipoTipoComprobante As String,
                                          tiposComprobante As Entidades.TipoComprobante(),
                                          IdProveedor As Long,
                                          IdUsuario As String,
                                          Items As String,
                                          Cantidades As String,
                                          Precio As String,
                                          FechaE As String,
                                          IdEstado As String,
                                          VerUltimaActivacion As Boolean,
                                          FechaAutorizacionDesde As Date,
                                          FechaAutorizacionHasta As Date) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         If VerUltimaActivacion Then
            .AppendLine(" WITH records AS (")
         End If
         .AppendFormat("SELECT P.NombreProveedor, PP.ImporteTotal, PP.TotalImpuestos
         , PP.ImporteBruto , OCA.*, OB.DetalleObservacion, PRO.NombreProducto, PP.FechaAutorizacion").AppendLine()
         .AppendFormat("  ,( SELECT TOP 1 PE.FechaEntrega	FROM PedidosEstadosProveedores PE
           WHERE PE.IdSucursal = PP.IdSucursal
           AND PE.IdTipoComprobante = PP.IdTipoComprobante
           AND PE.Letra = PP.Letra
           AND PE.CentroEmisor = PP.CentroEmisor
           AND PE.NumeroPedido = PP.NumeroPedido
            ORDER BY PE.Orden ) as FechaEntrega")
         .AppendFormatLine(" , CASE WHEN OCA.Orden = 0 THEN case when EXISTS(SELECT * FROM PedidosEstadosProveedores PE
                      INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado
                      WHERE PE.IdSucursal = PP.IdSucursal
                        AND PE.IdTipoComprobante = PP.IdTipoComprobante
                        AND PE.Letra = PP.Letra
                        AND PE.CentroEmisor = PP.CentroEmisor
                        AND PE.NumeroPedido = PP.NumeroPedido
                        AND (EP.IdEstado = 'CANCELADO' OR EP.IdEstado = 'ANULADO' )) then 0 else CONVERT(decimal(9,2), 
               ( SELECT CASE WHEN SUM(PPP.CantEnProceso) = 0 THEN 0 ELSE CASE WHEN PP.ImporteTotal = 0 THEN 0 ELSE (SUM(PPP.CostoConImpuestos * PPP.CantEnProceso) / PP.ImporteTotal) END END
		     FROM PedidosProductosProveedores PPP
           WHERE PPP.IdSucursal = PP.IdSucursal
           AND PPP.IdTipoComprobante = PP.IdTipoComprobante
           AND PPP.Letra = PP.Letra
           AND PPP.CentroEmisor = PP.CentroEmisor
           AND PPP.NumeroPedido = PP.NumeroPedido) * 100) END ELSE ((PPP.CantPendiente /PPP.Cantidad)) * 100 END AS PorcPendiente")
         .AppendLine("       , (SELECT TOP 1 CE.FechaEnvio	FROM CalidadEnviosOC CE
                           WHERE CE.IdSucursal = PP.IdSucursal
                           AND CE.IdTipoComprobante = PP.IdTipoComprobante
                           AND CE.Letra = PP.Letra
                           AND CE.CentroEmisor = PP.CentroEmisor
                           AND CE.NumeroPedido = PP.NumeroPedido
                           ORDER BY CE.FechaEnvio DESC) as FechaEnvio")

         If VerUltimaActivacion Then
            .AppendLine(" ,ROW_NUMBER() OVER (PARTITION BY OCA.IdSucursal, OCA.IdTipoComprobante, OCA.Letra, OCA.CentroEmisor, OCA.NumeroPedido, OCA.Orden 
                          ORDER BY OCA.NumeroPedido, OCA.IdProducto, OCA.FechaActivacion DESC) AS rn")
         End If

         .AppendFormatLine("  FROM CalidadOCActivaciones AS OCA").AppendLine()
         .AppendFormatLine(" LEFT JOIN Observaciones OB ON OB.IdObservacion = OCA.IdObservacion")
         .AppendFormatLine(" LEFT JOIN Productos PRO ON PRO.IdProducto = OCA.IdProducto")
         .AppendLine(" INNER JOIN PedidosProveedores PP ON PP.IdSucursal = OCA.IdSucursal
                        AND PP.IdTipoComprobante = OCA.IdTipoComprobante
                        AND PP.Letra = OCA.Letra
                        AND PP.CentroEmisor = OCA.CentroEmisor
                        AND PP.NumeroPedido = OCA.NumeroPedido")
         .AppendLine(" LEFT JOIN Proveedores P ON P.IdProveedor = PP.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PP.IdTipoComprobante")

         .AppendLine(" LEFT JOIN PedidosProductosProveedores PPP ON PP.IdSucursal = PP.IdSucursal")
         .AppendLine("                               AND PPP.IdTipoComprobante = PP.IdTipoComprobante")
         .AppendLine("                               AND PPP.Letra = PP.Letra")
         .AppendLine("                               AND PPP.CentroEmisor = PP.CentroEmisor")
         .AppendLine("                               AND PPP.NumeroPedido = PP.NumeroPedido")
         .AppendLine("                               AND PPP.Orden = OCA.Orden")
         .AppendLine(" LEFT JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PPP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = PPP.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = PPP.Letra")
         .AppendLine("                             AND PE.CentroEmisor = PPP.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = PPP.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PPP.IdProducto")
         .AppendLine("                             AND PE.Orden = PPP.Orden")

         .AppendLine(" WHERE 1 = 1")

         If IdEstado <> "TODOS" Then
            .AppendLine("   AND EXISTS(SELECT * FROM PedidosEstadosProveedores PE")
            .AppendLine("                      LEFT JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado")
            .AppendLine("                      WHERE PE.IdSucursal = PP.IdSucursal")
            .AppendLine("                        AND PE.IdTipoComprobante = PP.IdTipoComprobante")
            .AppendLine("                        AND PE.Letra = PP.Letra")
            .AppendLine("                        AND PE.CentroEmisor = PP.CentroEmisor")
            .AppendLine("                        AND PE.NumeroPedido = PP.NumeroPedido")

            If IdEstado = "PENDIENTE/EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO'))")
            ElseIf IdEstado = "SOLO EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado = 'EN PROCESO')")
            Else
               .AppendFormat("                        AND EP.IdEstado = '{0}')", IdEstado).AppendLine()
            End If
         End If

         If Not String.IsNullOrWhiteSpace(IdUsuario) Then
            .AppendFormat("   AND OCA.IdUsuario = '{0}'", IdUsuario).AppendLine()
         End If

         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()
         GetListaTiposComprobantesMultiples(myQuery, tiposComprobante, "PP")

         If IdProveedor > 0 Then
            .AppendFormat("   AND PP.IdProveedor = {0}", IdProveedor).AppendLine()
         End If

         If IdObservacion > 0 Then
            .AppendFormat("   AND OCA.IdObservacion = {0}", IdObservacion).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND OCA.NumeroPedido = {0}", numeroPedido).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(IdProducto) Then
            .AppendFormat("   AND OCA.IdProducto = '{0}'", IdProducto).AppendLine()
         End If
         If Activaciones <> "Todas" Then
            If Activaciones = "Cabecera" Then
               .AppendFormat("   AND OCA.Orden = 0").AppendLine()
            Else
               .AppendFormat("   AND OCA.Orden <> 0").AppendLine()
            End If
         End If
         If Criticidad <> "Todas" Then
            If Criticidad = "Normal" Then
               .AppendFormat("   AND OCA.Criticidad = 'Normal'").AppendLine()
            Else
               .AppendFormat("   AND OCA.Criticidad = 'Crítica'").AppendLine()
            End If
         End If

         If Items <> "Todos" Then
            If Items = "Ok" Then
               .AppendFormat("   AND OCA.Items = 'True'").AppendLine()
            Else
               .AppendFormat("   AND OCA.Items = 'False'").AppendLine()
            End If
         End If

         If Cantidades <> "Todas" Then
            If Cantidades = "Ok" Then
               .AppendFormat("   AND OCA.Cantidades = 'True'").AppendLine()
            Else
               .AppendFormat("   AND OCA.Cantidades = 'False'").AppendLine()
            End If
         End If

         If Precio <> "Todos" Then
            If Precio = "Ok" Then
               .AppendFormat("   AND OCA.Precio = 'True'").AppendLine()
            Else
               .AppendFormat("   AND OCA.Precio = 'False'").AppendLine()
            End If
         End If

         If FechaE <> "Todas" Then
            If FechaE = "Ok" Then
               .AppendFormat("   AND OCA.FechaE = 'True'").AppendLine()
            Else
               .AppendFormat("   AND OCA.FechaE = 'False'").AppendLine()
            End If
         End If


         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND OCA.FechaActivacion >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND OCA.FechaActivacion <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If fechaDesdeEntrega > Date.Parse("01/01/1990") Then
            .AppendLine("   AND  ( SELECT TOP 1 PE.FechaEntrega	FROM PedidosEstadosProveedores PE
           WHERE PE.IdSucursal = PP.IdSucursal
           AND PE.IdTipoComprobante = PP.IdTipoComprobante
           AND PE.Letra = PP.Letra
           AND PE.CentroEmisor = PP.CentroEmisor
           AND PE.NumeroPedido = PP.NumeroPedido
            ORDER BY PE.Orden ) >= '" & fechaDesdeEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND ( SELECT TOP 1 PE.FechaEntrega	FROM PedidosEstadosProveedores PE
           WHERE PE.IdSucursal = PP.IdSucursal
           AND PE.IdTipoComprobante = PP.IdTipoComprobante
           AND PE.Letra = PP.Letra
           AND PE.CentroEmisor = PP.CentroEmisor
           AND PE.NumeroPedido = PP.NumeroPedido
            ORDER BY PE.Orden ) <= '" & fechaHastaEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If fechaDesdeRepEntrega > Date.Parse("01/01/1990") Then
            .AppendLine("   AND OCA.FechaReprogEntrega >= '" & fechaDesdeRepEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND OCA.FechaReprogEntrega <= '" & fechaHastaRepEntrega.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If FechaAutorizacionDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND PP.FechaAutorizacion >= '" & FechaAutorizacionDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND PP.FechaAutorizacion <= '" & FechaAutorizacionHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If VerUltimaActivacion Then
            .AppendLine(" ) SELECT * FROM records WHERE rn = 1")
         Else
            .AppendLine(" ORDER BY OCA.NumeroPedido, OCA.IdProducto, OCA.FechaActivacion DESC")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Sub ActualizaFechaReprogramacion(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long,
                                            Orden As Integer,
                                            OrdenActivacion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine(" UPDATE CalidadOCActivaciones ")
         .AppendLine(" SET ")
         .AppendLine(" FechaReprogEntrega = NULL")
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         End If
         .AppendFormat("   AND Orden = 0").AppendLine()
         .AppendFormat("   AND OrdenActivacion = {0}", OrdenActivacion).AppendLine()

      End With
      Me.Execute(myQuery.ToString())

   End Sub
End Class