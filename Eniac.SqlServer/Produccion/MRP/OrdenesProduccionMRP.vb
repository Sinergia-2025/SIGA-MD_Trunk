Imports Eniac.Entidades

Public Class OrdenesProduccionMRP
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesProduccionMRP_I(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroOrdenProduccion As Long,
                                     orden As Integer,
                                     idProducto As String,
                                     idProcesoProductivo As Long,
                                     codigoProcesoProductivo As String,
                                     descripcionProceso As String,
                                     costoManoObraInterna As Decimal,
                                     costoManoObraExterna As Decimal,
                                     costoMateriaPrima As Decimal,
                                     costoTotalProceso As Decimal,
                                     fechaAltaProceso As DateTime,
                                     fechaModificaProceso As DateTime,
                                     fechaActualizaCostos As DateTime,
                                     tiempoTotalProceso As Decimal,
                                     archivoAdjunto As Integer?,
                                     respetaOrden As Boolean,
                                     activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21})",
                       OrdenProduccionMRP.NombreTabla,
                       OrdenProduccionMRP.Columnas.IdSucursal.ToString(),
                       OrdenProduccionMRP.Columnas.IdTipoComprobante.ToString(),
                       OrdenProduccionMRP.Columnas.LetraComprobante.ToString(),
                       OrdenProduccionMRP.Columnas.CentroEmisor.ToString(),
                       OrdenProduccionMRP.Columnas.NumeroOrdenProduccion.ToString(),
                       OrdenProduccionMRP.Columnas.Orden.ToString(),
                       OrdenProduccionMRP.Columnas.IdProducto.ToString(),
                       OrdenProduccionMRP.Columnas.IdProcesoProductivo.ToString(),
                       OrdenProduccionMRP.Columnas.CodigoProcesoProductivo.ToString(),
                       OrdenProduccionMRP.Columnas.DescripcionProceso.ToString(),
                       OrdenProduccionMRP.Columnas.CostoManoObraInterna.ToString(),
                       OrdenProduccionMRP.Columnas.CostoManoObraExterna.ToString(),
                       OrdenProduccionMRP.Columnas.CostoMateriaPrima.ToString(),
                       OrdenProduccionMRP.Columnas.CostoTotalProceso.ToString(),
                       OrdenProduccionMRP.Columnas.FechaAltaProceso.ToString(),
                       OrdenProduccionMRP.Columnas.FechaModificaProceso.ToString(),
                       OrdenProduccionMRP.Columnas.FechaActualizaCostos.ToString(),
                       OrdenProduccionMRP.Columnas.TiempoTotalProceso.ToString(),
                       OrdenProduccionMRP.Columnas.IdArchivoAdjunto.ToString(),
                       OrdenProduccionMRP.Columnas.RespetaOrden.ToString(),
                       OrdenProduccionMRP.Columnas.Activo.ToString()).AppendLine()
         .AppendFormat("  VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, '{6}', {7}, '{8}', '{9}', {10}, {11}, {12}, {13}, '{14}', '{15}', '{16}', {17}, {18}, {19}, {20}",
                       idSucursal,
                       idTipoComprobante,
                       letra,
                       centroEmisor,
                       numeroOrdenProduccion,
                       orden,
                       idProducto,
                       idProcesoProductivo,
                       codigoProcesoProductivo,
                       descripcionProceso,
                       costoManoObraInterna,
                       costoManoObraExterna,
                       costoMateriaPrima,
                       costoTotalProceso,
                       ObtenerFecha(fechaAltaProceso, True),
                       ObtenerFecha(fechaModificaProceso, True),
                       ObtenerFecha(fechaActualizaCostos, True),
                       tiempoTotalProceso,
                       IIf(archivoAdjunto.HasValue, archivoAdjunto, "NULL"),
                       GetStringFromBoolean(respetaOrden),
                       GetStringFromBoolean(activo))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub OrdenesProduccionMRP_U(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroOrdenProduccion As Long,
                                     orden As Integer,
                                     idProducto As String,
                                     idProcesoProductivo As Long,
                                     codigoProcesoProductivo As String,
                                     descripcionProceso As String,
                                     costoManoObraInterna As Decimal,
                                     costoManoObraExterna As Decimal,
                                     costoMateriaPrima As Decimal,
                                     costoTotalProceso As Decimal,
                                     fechaAltaProceso As Date,
                                     fechaModificaProceso As Date,
                                     fechaActualizaCostos As Date,
                                     tiempoTotalProceso As Decimal,
                                     archivoAdjunto As Integer?,
                                     respetaOrden As Boolean,
                                     activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPProcesoProductivo.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}' ", OrdenProduccionMRP.Columnas.CodigoProcesoProductivo.ToString(), codigoProcesoProductivo).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", OrdenProduccionMRP.Columnas.DescripcionProceso.ToString(), descripcionProceso).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRP.Columnas.CostoManoObraInterna.ToString(), costoManoObraInterna).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRP.Columnas.CostoManoObraExterna.ToString(), costoManoObraExterna).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRP.Columnas.CostoMateriaPrima.ToString(), costoMateriaPrima).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRP.Columnas.CostoTotalProceso.ToString(), costoTotalProceso).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", OrdenProduccionMRP.Columnas.FechaAltaProceso.ToString(), ObtenerFecha(fechaAltaProceso, True)).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", OrdenProduccionMRP.Columnas.FechaModificaProceso.ToString(), ObtenerFecha(fechaModificaProceso, True)).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", OrdenProduccionMRP.Columnas.FechaActualizaCostos.ToString(), ObtenerFecha(fechaActualizaCostos, True)).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRP.Columnas.TiempoTotalProceso.ToString(), tiempoTotalProceso).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRP.Columnas.IdArchivoAdjunto.ToString(), IIf(archivoAdjunto.HasValue, archivoAdjunto, "NULL")).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRP.Columnas.RespetaOrden.ToString(), GetStringFromBoolean(respetaOrden)).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRP.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRP.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub OrdenesProduccionMRP_D(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroOrdenProduccion As Long,
                                     orden As Integer,
                                     idProducto As String,
                                     idProcesoProductivo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", OrdenProduccionMRP.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRP.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT OPMRP.* FROM {0} AS OPMRP ", OrdenProduccionMRP.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function OrdenesProduccionMRP_G(idSucursal As Integer,
                                                    idTipoComprobante As String,
                                                    letra As String,
                                                    centroEmisor As Integer,
                                                    numeroOrdenProduccion As Long,
                                                    orden As Integer,
                                                    idProducto As String,
                                                    idProcesoProductivo As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE {0} =  {1}  ", OrdenProduccionMRP.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         If orden > 0 Then
            .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.Orden.ToString(), orden)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRP.Columnas.IdProducto.ToString(), idProducto)
         End If
         If idProcesoProductivo > 0 Then
            .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRP.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function OrdenesProduccionMRP_GA(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroOrdenProduccion As Long,
                                           orden As Integer,
                                           idProducto As String) As DataTable
      Return OrdenesProduccionMRP_G(idSucursal:=idSucursal,
                                    idTipoComprobante:=idTipoComprobante,
                                    letra:=letra,
                                    centroEmisor:=centroEmisor,
                                    numeroOrdenProduccion:=
                                    numeroOrdenProduccion,
                                    orden:=orden,
                                    idProducto:=idProducto,
                                    idProcesoProductivo:=0)
   End Function
   Public Function OrdenesProduccionMRP_G1(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroOrdenProduccion As Long,
                                           orden As Integer,
                                           idProducto As String,
                                           idProcesoProductivo As Long) As DataTable
      Return OrdenesProduccionMRP_G(idSucursal:=idSucursal,
                                    idTipoComprobante:=idTipoComprobante,
                                    letra:=letra,
                                    centroEmisor:=centroEmisor,
                                    numeroOrdenProduccion:=
                                    numeroOrdenProduccion,
                                    orden:=orden,
                                    idProducto:=idProducto,
                                    idProcesoProductivo:=idProcesoProductivo)
   End Function

   Public Function GetOrdenesProduccionImpresionMasiva(idSucursal As Integer,
                                                       idEstado As String,
                                                       idResponsable As Integer,
                                                       idCliente As Long,
                                                       idProducto As String,
                                                       idSeccion As Integer,
                                                       idTarea As Integer,
                                                       idCentroProductor As Integer,
                                                       fechaDesde As Date?,
                                                       fechaHasta As Date?,
                                                       fechaDesdeEstado As Date?,
                                                       fechaHastaEstado As Date?,
                                                       idPedido As Integer,
                                                       linea As Integer,
                                                       idTipoComprobantePedido As String,
                                                       IdOrdenProduccion As Integer,
                                                       idTipoComprobanteOP As String,
                                                       idPlanMaestro As Integer,
                                                       fechaDesdePlan As Date?,
                                                       fechaHastaPlan As Date?,
                                                       tipoImpresion As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT 'False' as Imprimir,")
         .AppendLine("       '' as Visualizar,")
         .AppendLine("       OPE.IdSucursal,")
         .AppendLine("       OPE.IdTipoComprobante,")
         .AppendLine("       OPE.Letra,")
         .AppendLine("       OPE.CentroEmisor,")
         .AppendLine("       OPE.NumeroOrdenProduccion,")
         .AppendLine("       OPE.Orden,")
         .AppendLine("       OP.FechaOrdenProduccion,")

         .AppendLine("       OP.IdCliente, ")
         .AppendLine("       CL.NombreCliente,")

         .AppendLine("       OPE.PlanMaestroNumero,")
         .AppendLine("       OPE.PlanMaestroFecha,")

         .AppendLine("	     OPP.IdSucursalPedido,")
         .AppendLine("	     OPP.IdTipoComprobantePedido,")
         .AppendLine("	     OPP.LetraPedido,")
         .AppendLine("	     OPP.CentroEmisorPedido,")
         .AppendLine("	     OPP.NumeroPedido,")
         .AppendLine("	     OPP.IdProductoPedido,")
         .AppendLine("	     OPP.OrdenPedido,")
         '-- Tipo Impresion.- -----------------------------------------------------------------------------------------
         If tipoImpresion > 0 Then '-- Hoja de ruta por Productos.- ---------------------------------------------------
            '-- Estado Orden Produccion.- -----------------------------------------------------------------------------
            .AppendLine("       OPE.IdEstado, ")
            .AppendLine("       EOP.IdTipoEstado,")
            .AppendLine("       OPE.FechaEstado,")
            '-- Producto Orden de Produccion.- ------------------------------------------------------------------------
            .AppendLine("       OPE.IdProducto, ")
            .AppendLine("       PR.NombreProducto,")
            .AppendLine("       OPE.CantEstado,")
            .AppendLine("       OPE.FechaEntrega,")
            '-- Proceso productivo Producto orden de Produccion.- -----------------------------------------------------
            .AppendLine("       OPM.CodigoProcesoProductivo,")
            .AppendLine("       OPM.IdProcesoProductivo,")
            .AppendLine("       MPP.DescripcionProceso,")
            .AppendLine("       OPM.IdArchivoAdjunto,")
            If tipoImpresion > 1 Then '-- Hoja de Ruta por operaciones.- ----------------------------------------------
               '-- Operaciones.- --------------------------------------------------------------------------------------
               .AppendLine("	     OPME.IdOperacion,")
               .AppendLine("	     OPME.CodigoProcProdOperacion,")
               .AppendLine("	     OPME.DescripcionOperacion,")
               '-- Centro Productor.- ---------------------------------------------------------------------------------
               .AppendLine("	     OPME.CentroProductorOperacion,")
               .AppendLine("	     MCP.CodigoCentroProductor,")
               .AppendLine("	     MCP.Descripcion as DescripcionCentro,")

               .AppendLine("	     MCP.IdSeccion,")
               .AppendLine("	     MRS.CodigoSeccion,")
               .AppendLine("	     MRS.Descripcion as DescripcionSeccion,")

            End If
            .AppendLine("       OPE.Observacion")
         Else
            .AppendLine("       '' as Observacion")
         End If
         '-------------------------------------------------------------------------------------------------------------
         .AppendLine(" FROM OrdenesProduccion OP")
         '-------------------------------------------------------------------------------------------------------------
         .AppendLine("     INNER JOIN OrdenesProduccionProductos OPP ON OPP.IdSucursal = OP.IdSucursal")
         .AppendLine("                                              AND OPP.IdTipoComprobante = OP.IdTipoComprobante")
         .AppendLine("                                              AND OPP.Letra = OP.Letra")
         .AppendLine("                                              AND OPP.CentroEmisor = OP.CentroEmisor")
         .AppendLine("                                              AND OPP.NumeroOrdenProduccion = OP.NumeroOrdenProduccion")
         '-------------------------------------------------------------------------------------------------------------
         .AppendLine("     INNER JOIN OrdenesProduccionEstados   OPE ON OPE.IdSucursal = OPP.IdSucursal")
         .AppendLine("                                              AND OPE.IdTipoComprobante = OPP.IdTipoComprobante")
         .AppendLine("                                              AND OPE.Letra = OPP.Letra")
         .AppendLine("                                              AND OPE.CentroEmisor = OPP.CentroEmisor")
         .AppendLine("                                              AND OPE.NumeroOrdenProduccion = OPP.NumeroOrdenProduccion")
         .AppendLine("                                              AND OPE.IdProducto = OPP.IdProducto")
         .AppendLine("                                              AND OPE.Orden = OPP.Orden")
         '-------------------------------------------------------------------------------------------------------------
         .AppendLine("     INNER JOIN EstadosOrdenesProduccion	  EOP ON EOP.IdEstado = OPE.IdEstado")
         '-------------------------------------------------------------------------------------------------------------
         .AppendLine("     INNER JOIN Clientes					     CL  ON CL.IdCliente = OP.IdCliente")
         '-------------------------------------------------------------------------------------------------------------
         .AppendLine("     INNER JOIN Productos				        PR  ON PR.IdProducto = OPE.IdProducto")
         '-- Tipo Impresion.- -----------------------------------------------------------------------------------------
         If tipoImpresion > 0 Then '-- Hoja de ruta por Productos.- ---------------------------------------------------
            .AppendLine("     LEFT JOIN OrdenesProduccionMRP		  OPM ON OPM.IdSucursal = OPP.IdSucursal")
            .AppendLine("                                              AND OPM.IdTipoComprobante = OPP.IdTipoComprobante")
            .AppendLine("                                              AND OPM.LetraComprobante = OPP.Letra")
            .AppendLine("                                              AND OPM.CentroEmisor = OPP.CentroEmisor")
            .AppendLine("                                              AND OPM.NumeroOrdenProduccion = OPP.NumeroOrdenProduccion")
            .AppendLine("                                              AND OPM.IdProducto = OPP.IdProducto")
            .AppendLine("                                              AND OPM.Orden = OPP.Orden")
            .AppendLine("     LEFT JOIN MRPProcesosProductivos	     MPP ON MPP.IdProcesoProductivo = OPM.IdProcesoProductivo")
            .AppendLine("                                              AND MPP.IdProductoProceso = OPP.IdProducto")
            If tipoImpresion > 1 Then '-- Hoja de Ruta por operaciones.- ----------------------------------------------             
               .AppendLine("     LEFT JOIN OrdenesProduccionMRPOperaciones		OPME ON OPME.IdSucursal = OPP.IdSucursal")
               .AppendLine("                                                      AND OPME.IdTipoComprobante = OPP.IdTipoComprobante")
               .AppendLine("                                                      AND OPME.LetraComprobante = OPP.Letra")
               .AppendLine("                                                      AND OPME.CentroEmisor = OPP.CentroEmisor")
               .AppendLine("                                                      AND OPME.NumeroOrdenProduccion = OPP.NumeroOrdenProduccion")
               .AppendLine("                                                      AND OPME.IdProducto = OPP.IdProducto")
               .AppendLine("                                                      AND OPME.Orden = OPP.Orden")
               .AppendLine("     LEFT JOIN MRPCentrosProductores		MCP ON OPME.CentroProductorOperacion = MCP.IdCentroProductor")
               .AppendLine("     LEFT JOIN MRPSecciones        		MRS ON MCP.IdSeccion = MRS.IdSeccion")
            End If
         End If
         '-------------------------------------------------------------------------------------------------------------
         .AppendFormatLine(" WHERE OP.IdSucursal = {0}", idSucursal.ToString())
         .AppendLine("           AND PR.IdProcesoProductivoDefecto IS NOT NULL")
         '-- Responsable.- -------------------------------------------------------------------------------------------
         If idResponsable > 0 Then
            .AppendFormatLine("   AND OPP.IdResponsable = {0}", idResponsable)
         End If
         '-- Estado Orden de Produccion.- ----------------------------------------------------------------------------
         If idEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EOP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf idEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EOP.IdTipoEstado = 'EN PROCESO'")
         ElseIf idEstado <> "TODOS" Then
            .AppendFormatLine("   AND OPE.IdEstado = '{0}'", idEstado.ToString())
         End If
         '-- Fecha Orden de Produccion.- -----------------------------------------------------------------------------
         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendFormatLine("   AND OP.FechaOrdenProduccion >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
            .AppendFormatLine("   AND OP.FechaOrdenProduccion <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If
         '-- Cliente Orden de Produccion.- ---------------------------------------------------------------------------
         If idCliente > 0 Then
            .AppendFormatLine("   AND CL.IdCliente = {0}", idCliente)
         End If
         '-- Pedido Origen Orden de Produccion.- ---------------------------------------------------------------------
         If idPedido > 0 Then
            .AppendFormatLine("   AND OPP.NumeroPedido = {0}", idPedido)
            .AppendFormatLine("   AND OPP.OrdenPedido = {0}", linea)
            .AppendFormatLine("   AND OPP.IdTipoComprobantePedido = '{0}'", idTipoComprobantePedido)
         End If
         '-- Orden de Produccion.- -----------------------------------------------------------------------------------
         If IdOrdenProduccion > 0 Then
            .AppendFormatLine("   AND OPE.NumeroOrdenProduccion = {0}", IdOrdenProduccion)
            .AppendFormatLine("   AND OPE.IdTipoComprobante = '{0}'", idTipoComprobanteOP)
         End If
         '-- Numero Plan Maestro Produccion.- ------------------------------------------------------------------------
         If idPlanMaestro > 0 Then
            .AppendFormatLine("   AND OPE.PlanMaestroNumero = {0}", idPlanMaestro)
            '-- Fecha Plan Maestro Orden de Produccion.- -----------------------------------------------------------------------------
            If fechaDesdePlan > Date.Parse("01/01/1990") Then
               .AppendFormatLine("   AND OPE.PlanMaestroFecha >= '{0}'", ObtenerFecha(fechaDesdePlan.Value, True))
               .AppendFormatLine("   AND OPE.PlanMaestroFecha <= '{0}'", ObtenerFecha(fechaHastaPlan.Value, True))
            End If
         End If
         '-- Tipo Impresion.- -----------------------------------------------------------------------------------------
         If tipoImpresion > 0 Then  '-- Hoja de ruta por Productos.- --------------------------------------------------
            '-- Fecha Estado Orden Produccion.- -----------------------------------------------------------------------
            If fechaDesdeEstado > Date.Parse("01/01/1990") Then
               .AppendFormatLine("   AND OPE.FechaEstado >= '{0}'", ObtenerFecha(fechaDesdeEstado.Value, True))
               .AppendFormatLine("   AND OPE.FechaEstado <= '{0}'", ObtenerFecha(fechaHastaEstado.Value, True))
            End If
            '-- Producto Orden de Produccion.- ------------------------------------------------------------------------
            If Not String.IsNullOrEmpty(idProducto) Then
               .AppendFormatLine("   AND OPP.IdProducto = '{0}'", idProducto)
            End If
            If tipoImpresion > 1 Then '-- Hoja de Ruta por operaciones.- ----------------------------------------------
               '-- Seccion.- ------------------------------------------------------------------------------------------ 
               If idSeccion > 0 Then
                  .AppendFormatLine("   AND MCP.IdSeccion = {0}", idSeccion)
               End If
               '-- Tarea.- --------------------------------------------------------------------------------------------
               If idTarea > 0 Then
                  .AppendFormatLine("   AND OPME.IdcodigoTarea = {0}", idTarea)
               End If
               '-- Centro Productor.- ---------------------------------------------------------------------------------
               If idCentroProductor > 0 Then
                  .AppendFormatLine("   AND OPME.CentroProductorOperacion = {0}", idCentroProductor)
               End If
               '.AppendLine("         AND MCP.ClaseCentroProductor = 'INT'")
            End If
         Else
            '----------------------------------------------------------------------------------------------------------
            .AppendLine("     GROUP BY OPE.IdSucursal,")
            .AppendLine("            OPE.IdTipoComprobante,")
            .AppendLine("            OPE.Letra,")
            .AppendLine("            OPE.CentroEmisor,")
            .AppendLine("            OPE.NumeroOrdenProduccion,")
            .AppendLine("            OPE.Orden,")
            .AppendLine("            OP.FechaOrdenProduccion,")
            .AppendLine("            OP.IdCliente, ")
            .AppendLine("            CL.NombreCliente,")
            .AppendLine("            OPE.PlanMaestroNumero,")
            .AppendLine("            OPE.PlanMaestroFecha,")
            .AppendLine("     	    OPP.IdSucursalPedido,")
            .AppendLine("     	    OPP.IdTipoComprobantePedido,")
            .AppendLine("     	    OPP.LetraPedido,")
            .AppendLine("     	    OPP.CentroEmisorPedido,")
            .AppendLine("     	    OPP.NumeroPedido,")
            .AppendLine("     	    OPP.OrdenPedido,")
            .AppendLine("     	    OPP.IdProductoPedido")
            '----------------------------------------------------------------------------------------------------------
         End If
         '-------------------------------------------------------------------------------------------------------------
      End With
      '-- Devuelva valores obtenidos.- --------------------------------------------------------------------------------
      Return GetDataTable(stbQuery)
      '----------------------------------------------------------------------------------------------------------------
   End Function
End Class
