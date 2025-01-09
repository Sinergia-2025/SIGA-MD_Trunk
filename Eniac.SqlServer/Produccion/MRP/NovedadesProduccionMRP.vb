Imports Eniac.Entidades

Public Class NovedadesProduccionMRP
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub NovedadesProduccionMRP_I(NumeroNovedadesProducccion As Integer,
                                       IdSucursal As Integer,
                                       IdTipoComprobante As String,
                                       LetraComprobante As String,
                                       CentroEmisor As Integer,
                                       NumeroOrdenProduccion As Integer,
                                       Orden As Integer,
                                       IdProducto As String,
                                       IdProcesoProductivo As Long,
                                       CodigoOperacion As String,
                                       UsuarioAlta As String,
                                       FechaAlta As DateTime,
                                       FechaNovedad As DateTime,
                                       IdEmpleado As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14})",
                       NovedadProduccionMRP.NombreTabla,
                       NovedadProduccionMRP.Columnas.NumeroNovedadesProducccion.ToString(),
                       NovedadProduccionMRP.Columnas.IdSucursal.ToString(),
                       NovedadProduccionMRP.Columnas.IdTipoComprobante.ToString(),
                       NovedadProduccionMRP.Columnas.LetraComprobante.ToString(),
                       NovedadProduccionMRP.Columnas.CentroEmisor.ToString(),
                       NovedadProduccionMRP.Columnas.NumeroOrdenProduccion.ToString(),
                       NovedadProduccionMRP.Columnas.Orden.ToString(),
                       NovedadProduccionMRP.Columnas.IdProducto.ToString(),
                       NovedadProduccionMRP.Columnas.IdProcesoProductivo.ToString(),
                       NovedadProduccionMRP.Columnas.CodigoOperacion.ToString(),
                       NovedadProduccionMRP.Columnas.UsuarioAlta.ToString(),
                       NovedadProduccionMRP.Columnas.FechaAlta.ToString(),
                       NovedadProduccionMRP.Columnas.FechaNovedad.ToString(),
                       NovedadProduccionMRP.Columnas.IdEmpleado.ToString()).AppendLine()

         .AppendFormat("  VALUES ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, '{7}', {8}, '{9}', '{10}', '{11}', '{12}', {13}",
                        NumeroNovedadesProducccion,
                        IdSucursal,
                        IdTipoComprobante,
                        LetraComprobante,
                        CentroEmisor,
                        NumeroOrdenProduccion,
                        Orden,
                        IdProducto,
                        IdProcesoProductivo,
                        CodigoOperacion,
                        UsuarioAlta,
                        ObtenerFecha(FechaAlta, True),
                        ObtenerFecha(FechaNovedad, True),
                        IIf(IdEmpleado = 0, "NULL", IdEmpleado))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(NovedadProduccionMRP.Columnas.NumeroNovedadesProducccion.ToString(), NovedadProduccionMRP.NombreTabla, String.Empty))
   End Function

   Public Function GetInformeDeclaraciones(idResponsable As Integer, idTarea As Integer, fechaDesde As Date?, fechaHasta As Date?,
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
         .AppendFormatLine("     , ISNULL((SELECT SUM(CONVERT(DECIMAL, DATEDIFF(SECOND, T.FechaHoraInicio, T.FechaHoraFin))) / 3600 Horas")
         .AppendFormatLine("                 FROM NovedadesProduccionMRPTiempos T")
         .AppendFormatLine("                WHERE T.NumeroNovedadesProducccion = N.NumeroNovedadesProducccion")
         .AppendFormatLine("                  AND T.CodigoOperacion            = N.CodigoOperacion), 0) TotalHorasReportadas")
         .AppendFormatLine("  FROM NovedadesProduccionMRP N")
         .AppendFormatLine(" INNER JOIN Empleados E ON E.IdEmpleado = N.IdEmpleado")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = N.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = N.IdProducto")
         .AppendFormatLine(" INNER JOIN MRPProcesosProductivos PP ON PP.IdProcesoProductivo = N.IdProcesoProductivo")

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
         'If Not String.IsNullOrWhiteSpace(codigoOperacion) Then
         '   .AppendFormatLine("   AND N.CodigoOperacion = '{0}'", codigoOperacion)
         'End If
         If idTarea > 0 Then
            .AppendFormatLine("   AND OPO.IdcodigoTarea = {0}", idTarea)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND N.FechaNovedad >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND N.FechaNovedad <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
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