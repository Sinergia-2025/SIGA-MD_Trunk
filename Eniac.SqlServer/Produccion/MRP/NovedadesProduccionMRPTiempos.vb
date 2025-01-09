Public Class NovedadesProduccionMRPTiempos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub NovedadesProduccionMRPTiempos_I(NumeroNovedadesProducccion As Integer,
                                              CodigoOperacion As String,
                                              FechaHoraInicio As Date,
                                              FechaHoraFin As Date,
                                              IdTipoDeclaracion As String,
                                              IdConcepto As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6})",
                       Entidades.NovedadProduccionMRPTiempo.NombreTabla,
                       Entidades.NovedadProduccionMRPTiempo.Columnas.NumeroNovedadesProducccion.ToString(),
                       Entidades.NovedadProduccionMRPTiempo.Columnas.CodigoOperacion.ToString(),
                       Entidades.NovedadProduccionMRPTiempo.Columnas.FechaHoraInicio.ToString(),
                       Entidades.NovedadProduccionMRPTiempo.Columnas.FechaHoraFin.ToString(),
                       Entidades.NovedadProduccionMRPTiempo.Columnas.IdTipoDeclaracion.ToString(),
                       Entidades.NovedadProduccionMRPTiempo.Columnas.IdConcepto.ToString()).AppendLine()

         .AppendFormat("  VALUES ({0}, '{1}', '{2}', '{3}', '{4}', {5}",
                        NumeroNovedadesProducccion,
                        CodigoOperacion,
                        ObtenerFecha(FechaHoraInicio, True),
                        ObtenerFecha(FechaHoraFin, True),
                        IdTipoDeclaracion,
                        IIf(IdConcepto = 0, "NULL", IdConcepto))
         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Function GetInformeDeclaraciones(idResponsable As Integer, idTarea As Integer, fechaDesde As Date?, fechaHasta As Date?,
                                           idTipoDeclaracion As String, idConceptoNoProductivo As Integer,
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

         .AppendFormatLine("     , T.IdTipoDeclaracion")
         .AppendFormatLine("     , T.Idconcepto")
         .AppendFormatLine("     , CNP.CodigoConceptoNoProductivo")
         .AppendFormatLine("     , CNP.NombreConceptoNoProductivo")

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

         .AppendFormatLine("     , T.FechaHoraInicio")
         .AppendFormatLine("     , CONVERT(DATE, T.FechaHoraInicio) FechaHoraInicio_FECHA")
         .AppendFormatLine("     , CONVERT(TIME, T.FechaHoraInicio) FechaHoraInicio_HORA")
         .AppendFormatLine("     , T.FechaHoraFin")
         .AppendFormatLine("     , CONVERT(DATE, T.FechaHoraFin) FechaHoraFin_FECHA")
         .AppendFormatLine("     , CONVERT(TIME, T.FechaHoraFin) FechaHoraFin_HORA")
         .AppendFormatLine("     , ISNULL(CONVERT(DECIMAL, DATEDIFF(SECOND, T.FechaHoraInicio, T.FechaHoraFin)) / 3600, 0) HorasReportadas")
         .AppendFormatLine("     , OPO.DescripcionOperacion ")
         .AppendFormatLine("  FROM NovedadesProduccionMRPTiempos T")
         .AppendFormatLine(" INNER JOIN NovedadesProduccionMRP N ON N.NumeroNovedadesProducccion = T.NumeroNovedadesProducccion AND N.CodigoOperacion = T.CodigoOperacion")
         .AppendFormatLine(" INNER JOIN Empleados E ON E.IdEmpleado = N.IdEmpleado")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = N.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = N.IdProducto")
         .AppendFormatLine(" INNER JOIN MRPProcesosProductivos PP ON PP.IdProcesoProductivo = N.IdProcesoProductivo")
         .AppendFormatLine("  LEFT JOIN MRPConceptosNoProductivos CNP ON CNP.IdConceptoNoProductivo = T.IdConcepto")

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
         If Not String.IsNullOrWhiteSpace(idTipoDeclaracion) Then
            .AppendFormatLine("   AND T.IdTipoDeclaracion = '{0}'", idTipoDeclaracion)
         End If
         If idConceptoNoProductivo <> 0 Then
            .AppendFormatLine("   AND T.Idconcepto = {0}", idConceptoNoProductivo)
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