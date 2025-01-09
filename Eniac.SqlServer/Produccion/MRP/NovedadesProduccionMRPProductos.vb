Imports Eniac.Entidades

Public Class NovedadesProduccionMRPProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub NovedadesProduccionMRPProductos_I(NumeroNovedadesProducccion As Integer,
                                                CodigoOperacion As String,
                                                IdProducto As String,
                                                EsProductoNecesario As Boolean,
                                                EsProductoAgregado As Boolean,
                                                Cantidad As Decimal,
                                                IdSucursal As Integer,
                                                IdDeposito As Integer,
                                                IdUbicacion As Integer,
                                                PrecioCosto As Decimal,
                                                InformeCalidadNumero As String,
                                                InformeCalidadLink As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12})",
                       NovedadProduccionMRPProducto.NombreTabla,
                       NovedadProduccionMRPProducto.Columnas.NumeroNovedadesProducccion.ToString(),
                       NovedadProduccionMRPProducto.Columnas.CodigoOperacion.ToString(),
                       NovedadProduccionMRPProducto.Columnas.IdProducto.ToString(),
                       NovedadProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(),
                       NovedadProduccionMRPProducto.Columnas.EsProductoAgregado.ToString(),
                       NovedadProduccionMRPProducto.Columnas.Cantidad.ToString(),
                       NovedadProduccionMRPProducto.Columnas.IdSucursal.ToString(),
                       NovedadProduccionMRPProducto.Columnas.IdDeposito.ToString(),
                       NovedadProduccionMRPProducto.Columnas.IdUbicacion.ToString(),
                       NovedadProduccionMRPProducto.Columnas.PrecioCosto.ToString(),
                       NovedadProduccionMRPProducto.Columnas.InformeCalidadNumero.ToString(),
                       NovedadProduccionMRPProducto.Columnas.InformeCalidadLink.ToString()).AppendLine()

         .AppendFormat("  VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                        NumeroNovedadesProducccion,
                        CodigoOperacion,
                        IdProducto,
                        GetStringFromBoolean(EsProductoNecesario),
                        GetStringFromBoolean(EsProductoAgregado),
                        Cantidad,
                        IdSucursal,
                        IdDeposito,
                        IdUbicacion,
                        PrecioCosto,
                        IIf(String.IsNullOrEmpty(InformeCalidadNumero), "NULL", InformeCalidadNumero),
                        IIf(String.IsNullOrEmpty(InformeCalidadLink), "NULL", InformeCalidadLink))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Function GetInformeDeclaraciones(idResponsable As Integer, idTarea As Integer, fechaDesde As Date?, fechaHasta As Date?,
                                           idProductoDeclarado As String, esNecesario As Entidades.Publicos.NecesarioResultanteTodos, esAgregado As Entidades.Publicos.SiNoTodos,
                                           idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroDesde As Long, numeroHasta As Long,
                                           idProducto As String, idCliente As Long?, idProcesoProductivo As Long,
                                           idTipoComprobantePedido As String, letraFiscalPedido As String, centroEmisorPedido As Integer, numeroPedidoDesde As Long, numeroPedidoHasta As Long, lineaPedido As Integer,
                                           planMaestroNumero As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT N.NumeroNovedadesProducccion")
         .AppendFormatLine("     , N.CodigoOperacion")
         .AppendFormatLine("     , N.FechaNovedad")
         .AppendFormatLine("     , N.IdEmpleado")
         .AppendFormatLine("     , E.NombreEmpleado")

         .AppendFormatLine("     , NP.IdProducto IdProductoDeclarado")
         .AppendFormatLine("     , PNP.NombreProducto NombreProductoDeclarado")
         .AppendFormatLine("     , NP.Cantidad")
         .AppendFormatLine("     , CASE WHEN NP.EsProductoNecesario = 'True' THEN NP.Cantidad ELSE NULL END CantidadUtilizada")
         .AppendFormatLine("     , CASE WHEN NP.EsProductoNecesario = 'True' THEN NULL ELSE NP.Cantidad END CantidadProducida")

         .AppendFormatLine("     , NP.IdSucursal            IdSucursalStock")
         .AppendFormatLine("     , S.Nombre                 NombreSucursalStock")
         .AppendFormatLine("     , NP.IdDeposito            IdDepositoStock")
         .AppendFormatLine("     , SD.CodigoDeposito        CodigoDepositoStock")
         .AppendFormatLine("     , SD.NombreDeposito        NombreDepositoStock")
         .AppendFormatLine("     , NP.IdUbicacion           IdUbicacionStock")
         .AppendFormatLine("     , SU.CodigoUbicacion       CodigoUbicacionStock")
         .AppendFormatLine("     , SU.NombreUbicacion       NombreUbicacionStock")

         .AppendFormatLine("     , NP.EsProductoNecesario")
         .AppendFormatLine("     , CASE WHEN NP.EsProductoNecesario = 'True' THEN 'NECESARIO' ELSE 'RESULTANTE' END DescripcionEsProductoNecesario")
         .AppendFormatLine("     , NP.EsProductoAgregado")

         .AppendFormatLine("     , (SELECT COUNT(1)")
         .AppendFormatLine("          FROM NovedadesProduccionMRPProductosLotes NPL")
         .AppendFormatLine("         WHERE NPL.NumeroNovedadesProducccion = NP.NumeroNovedadesProducccion")
         .AppendFormatLine("           AND NPL.CodigoOperacion = NP.CodigoOperacion")
         .AppendFormatLine("           AND NPL.EsProductoNecesario = NP.EsProductoNecesario")
         .AppendFormatLine("           AND NPL.IdProducto = NP.IdProducto) Lotes")

         .AppendFormatLine("     , N.IdSucursal")
         .AppendFormatLine("     , N.IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion AS DescripcionTipoComprobante")
         .AppendFormatLine("     , N.LetraComprobante")
         .AppendFormatLine("     , N.CentroEmisor")
         .AppendFormatLine("     , N.NumeroOrdenProduccion")
         .AppendFormatLine("     , N.IdProducto")
         .AppendFormatLine("     , P.NombreProducto")
         .AppendFormatLine("     , N.Orden")
         .AppendFormatLine("     , N.IdProcesoProductivo")
         .AppendFormatLine("     , PP.CodigoProcesoProductivo")
         .AppendFormatLine("     , PP.DescripcionProceso")
         .AppendFormatLine("     , N.UsuarioAlta")
         .AppendFormatLine("     , N.FechaAlta")

         .AppendFormatLine("     , OP.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , OPP.IdSucursalPedido")
         .AppendFormatLine("     , OPP.IdTipoComprobantePedido")
         .AppendFormatLine("     , TPP.Descripcion DescripcionTipoComprobantePedido")
         .AppendFormatLine("     , OPP.LetraPedido")
         .AppendFormatLine("     , OPP.CentroEmisorPedido")
         .AppendFormatLine("     , OPP.NumeroPedido")
         .AppendFormatLine("     , OPP.IdProductoPedido")
         .AppendFormatLine("     , OPP.OrdenPedido")
         .AppendFormatLine("     , OPO.DescripcionOperacion ")

         .AppendFormatLine("  FROM NovedadesProduccionMRPPRoductos NP")
         .AppendFormatLine(" INNER JOIN NovedadesProduccionMRP N ON N.NumeroNovedadesProducccion = NP.NumeroNovedadesProducccion AND N.CodigoOperacion = NP.CodigoOperacion")
         .AppendFormatLine(" INNER JOIN Empleados E ON E.IdEmpleado = N.IdEmpleado")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = N.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = N.IdProducto")
         .AppendFormatLine(" INNER JOIN Productos PNP ON PNP.IdProducto = NP.IdProducto")
         .AppendFormatLine(" INNER JOIN MRPProcesosProductivos PP ON PP.IdProcesoProductivo = N.IdProcesoProductivo")
         .AppendFormatLine("  LEFT JOIN Sucursales S ON S.IdSucursal = NP.IdSucursal")
         .AppendFormatLine("  LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = NP.IdSucursal AND SD.IdDeposito = NP.IdDeposito")
         .AppendFormatLine("  LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = NP.IdSucursal AND SU.IdDeposito = NP.IdDeposito AND SU.IdUbicacion = NP.IdUbicacion")

         .AppendFormatLine("  LEFT JOIN OrdenesProduccionProductos OPP")
         .AppendFormatLine("         ON OPP.IdSucursal = N.IdSucursal")
         .AppendFormatLine("        AND OPP.IdTipoComprobante = N.IdTipoComprobante")
         .AppendFormatLine("        AND OPP.Letra = N.LetraComprobante")
         .AppendFormatLine("        AND OPP.CentroEmisor = N.CentroEmisor")
         .AppendFormatLine("        AND OPP.NumeroOrdenProduccion = N.NumeroOrdenProduccion")
         .AppendFormatLine("        AND OPP.IdProducto = N.IdProducto")
         .AppendFormatLine("        AND OPP.Orden = N.Orden")
         .AppendFormatLine("  LEFT JOIN OrdenesProduccion OP")
         .AppendFormatLine("         ON OP.IdSucursal = N.IdSucursal")
         .AppendFormatLine("        AND OP.IdTipoComprobante = N.IdTipoComprobante")
         .AppendFormatLine("        AND OP.Letra = N.LetraComprobante")
         .AppendFormatLine("        AND OP.CentroEmisor = N.CentroEmisor")
         .AppendFormatLine("        AND OP.NumeroOrdenProduccion = N.NumeroOrdenProduccion")
         .AppendFormatLine("  LEFT JOIN Clientes C ON C.IdCliente = OP.IdCliente")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TPP ON TPP.IdTipoComprobante = OPP.IdTipoComprobantePedido")

         .AppendFormatLine("         INNER JOIN OrdenesProduccionMRPOperaciones OPO
                                     ON OPO.IdSucursal = N.IdSucursal
                                     AND OPO.IdTipoComprobante = N.IdTipoComprobante
                                     AND OPO.LetraComprobante = N.LetraComprobante
                                     AND OPO.CentroEmisor = N.CentroEmisor
                                     AND OPO.NumeroOrdenProduccion = N.NumeroOrdenProduccion
                                     AND OPO.IdProducto = N.IdProducto
                                     AND OPO.Orden = N.Orden
                                     AND OPO.IdProcesoProductivo = N.IdProcesoProductivo
    	                               AND OPO.CodigoProcProdOperacion = N.CodigoOperacion ")

         .AppendFormatLine(" WHERE 1 = 1")

         If idResponsable <> 0 Then
            .AppendFormatLine("   AND N.IdEmpleado = {0}", idResponsable)
         End If
         If idTarea > 0 Then
            .AppendFormatLine("   AND OPO.IdcodigoTarea = {0}", idTarea)
         End If
         'If Not String.IsNullOrWhiteSpace(codigoOperacion) Then
         '   .AppendFormatLine("   AND N.CodigoOperacion = '{0}'", codigoOperacion)
         'End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND N.FechaNovedad >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND N.FechaNovedad <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If
         If Not String.IsNullOrWhiteSpace(idProductoDeclarado) Then
            .AppendFormatLine("   AND NP.IdProducto = '{0}'", idProductoDeclarado)
         End If
         If esNecesario <> Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND NP.EsProductoNecesario = {0}", GetStringFromBoolean(esNecesario = Publicos.NecesarioResultanteTodos.NECESARIO))
         End If
         If esAgregado <> Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND NP.EsProductoAgregado = {0}", GetStringFromBoolean(esAgregado = Publicos.SiNoTodos.SI))
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND N.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letraFiscal) Then
            .AppendFormatLine("   AND N.LetraComprobante = '{0}'", letraFiscal)
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine("   AND N.CentroEmisor = {0}", centroEmisor)
         End If
         If numeroDesde <> 0 Then
            .AppendFormatLine("   AND N.NumeroOrdenProduccion >= {0}", numeroDesde)
         End If
         If numeroHasta <> 0 Then
            .AppendFormatLine("   AND N.NumeroOrdenProduccion <= {0}", numeroHasta)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND N.IdProducto = '{0}'", idProducto)
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND OP.IdCliente = {0}", idCliente)
         End If
         If idProcesoProductivo <> 0 Then
            .AppendFormatLine("   AND N.IdProcesoProductivo = {0}", idProcesoProductivo)
         End If

         If Not String.IsNullOrWhiteSpace(idTipoComprobantePedido) Then
            .AppendFormatLine("   AND OPP.IdTipoComprobantePedido = '{0}'", idTipoComprobantePedido)
         End If
         If Not String.IsNullOrWhiteSpace(letraFiscalPedido) Then
            .AppendFormatLine("   AND OPP.LetraPedido = '{0}'", letraFiscalPedido)
         End If
         If centroEmisorPedido <> 0 Then
            .AppendFormatLine("   AND OPP.CentroEmisorPedido = {0}", centroEmisorPedido)
         End If
         If numeroPedidoDesde <> 0 Then
            .AppendFormatLine("   AND OPP.NumeroPedido >= {0}", numeroPedidoDesde)
         End If
         If numeroPedidoHasta <> 0 Then
            .AppendFormatLine("   AND OPP.NumeroPedido <= {0}", numeroPedidoHasta)
         End If
         If lineaPedido <> 0 Then
            .AppendFormatLine("   AND OPP.OrdenPedido = {0}", lineaPedido)
         End If

         If planMaestroNumero <> 0 Then
            .AppendFormatLine("   AND EXISTS (SELECT 1")
            .AppendFormatLine("                 FROM OrdenesProduccionEstados OPE")
            .AppendFormatLine("                WHERE OPE.IdSucursal = N.IdSucursal")
            .AppendFormatLine("                  AND OPE.IdTipoComprobante = N.IdTipoComprobante")
            .AppendFormatLine("                  AND OPE.Letra = N.LetraComprobante")
            .AppendFormatLine("                  AND OPE.CentroEmisor = N.CentroEmisor")
            .AppendFormatLine("                  AND OPE.NumeroOrdenProduccion = N.NumeroOrdenProduccion")
            .AppendFormatLine("                  AND OPE.IdProducto = N.IdProducto")
            .AppendFormatLine("                  AND OPE.Orden = N.Orden")
            .AppendFormatLine("                  AND OPE.PlanMaestroNumero = {0})", planMaestroNumero)
         End If

         .AppendFormatLine(" ORDER BY N.FechaNovedad")
      End With

      Return GetDataTable(stb)
   End Function


End Class