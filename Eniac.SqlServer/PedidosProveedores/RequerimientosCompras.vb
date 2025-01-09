Public Class RequerimientosCompras
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RequerimientosCompras_I(idRequerimientoCompra As Long,
                                      idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroRequerimiento As Long,
                                      fecha As Date,
                                      fechaAlta As Date, idUsuarioAlta As String,
                                      observacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.RequerimientoCompra.NombreTabla)
         .AppendFormatLine("   ( {0}", Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.Letra.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.Fecha.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.FechaAlta.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompra.Columnas.Observacion.ToString())
         .AppendFormatLine("   ) VALUES (")
         .AppendFormatLine("      {0} ", idRequerimientoCompra)
         .AppendFormatLine("   ,  {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoComprobante)
         .AppendFormatLine("   , '{0}'", letra)
         .AppendFormatLine("   ,  {0} ", centroEmisor)
         .AppendFormatLine("   ,  {0} ", numeroRequerimiento)
         .AppendFormatLine("   , '{0}'", ObtenerFecha(fecha, True))
         .AppendFormatLine("   , '{0}'", ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("   , '{0}'", idUsuarioAlta)
         .AppendFormatLine("   , '{0}'", observacion)
         .AppendFormatLine("   )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosCompras")
   End Sub

   Public Sub RequerimientosCompras_U(idRequerimientoCompra As Long,
                                      idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroRequerimiento As Long,
                                      fecha As Date,
                                      fechaAlta As Date, idUsuarioAlta As String,
                                      observacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.RequerimientoCompra.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.RequerimientoCompra.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RequerimientoCompra.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompra.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString(), numeroRequerimiento)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RequerimientoCompra.Columnas.Fecha.ToString(), ObtenerFecha(fecha, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RequerimientoCompra.Columnas.FechaAlta.ToString(), ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString(), idUsuarioAlta)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RequerimientoCompra.Columnas.Observacion.ToString(), observacion)

         .AppendFormatLine(" WHERE {0} = {1}", Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosCompras")
   End Sub

   Public Sub RequerimientosCompras_D(idRequerimientoCompra As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.RequerimientoCompra.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosCompras")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RC.*")
         .AppendFormatLine("     , CONVERT(DATE, RC.Fecha) Fecha_Fecha")
         .AppendFormatLine("     , CONVERT(TIME, RC.Fecha) Fecha_Hora")
         .AppendFormatLine("     , CONVERT(DATE, RC.FechaAlta) FechaAlta_Fecha")
         .AppendFormatLine("     , CONVERT(TIME, RC.FechaAlta) FechaAlta_Hora")
         .AppendFormatLine("     , TC.Descripcion DescripcionTipoComprobante")
         .AppendFormatLine("  FROM {0} RC", Entidades.RequerimientoCompra.NombreTabla)
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = RC.IdTipoComprobante")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String, filtroABM As Entidades.Filtros.RequerimientosComprasABMFiltros) As DataTable
      Return Buscar(columna, valor,
                    Sub(stb)
                       SelectTexto(stb)
                       AplicarFiltrosABM(stb, filtroABM)
                    End Sub, "RC.",
                    New Dictionary(Of String, String) From {{"DescripcionTipoComprobante", "TC.Descripcion"}})
   End Function

   Public Function RequerimientosCompras_GA() As DataTable
      Return RequerimientosCompras_GA(filtroABM:=Nothing)
   End Function
   Public Function RequerimientosCompras_GA(filtroABM As Entidades.Filtros.RequerimientosComprasABMFiltros) As DataTable
      Return RequerimientosCompras_G(idRequerimientoCompra:=0, idSucursal:=0, idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroRequerimiento:=0, filtroABM)
   End Function
   Public Function RequerimientosCompras_G(idRequerimientoCompra As Long,
                                           idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroRequerimiento As Long,
                                           filtroABM As Entidades.Filtros.RequerimientosComprasABMFiltros) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE 1 = 1")
         If idRequerimientoCompra > 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
         End If

         If idSucursal > 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RequerimientoCompra.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroRequerimiento > 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString(), numeroRequerimiento)
         End If

         AplicarFiltrosABM(stb, filtroABM)
      End With
      Return GetDataTable(stb)
   End Function

   Private Sub AplicarFiltrosABM(stb As StringBuilder, filtroABM As Entidades.Filtros.RequerimientosComprasABMFiltros)
      With stb
         If filtroABM IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(filtroABM.IdTipoComprobante) Then
               .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString(), filtroABM.IdTipoComprobante)
            End If
            If filtroABM.NumeroRequerimiento > 0 Then
               .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString(), filtroABM.NumeroRequerimiento)
            End If

            If Not String.IsNullOrWhiteSpace(filtroABM.IdUsuarioAlta) Then
               .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString(), filtroABM.IdUsuarioAlta)
            End If
            If filtroABM.FechaDesde.HasValue Then
               .AppendFormatLine("   AND RC.{0} BETWEEN '{1}' AND '{2}'", Entidades.RequerimientoCompra.Columnas.Fecha.ToString(),
                                 ObtenerFecha(filtroABM.FechaDesde.Value.Date, False), ObtenerFecha(filtroABM.FechaHasta.Value.UltimoSegundoDelDia(), True))
            End If
            If filtroABM.FechaEntregaDesde.HasValue Then
               .AppendFormatLine("   AND EXISTS (SELECT 1 FROM {0} RCP", Entidades.RequerimientoCompraProducto.NombreTabla)
               .AppendFormatLine("                WHERE RCP.{0} = RC.{1}", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString())
               .AppendFormatLine("                  AND RCP.{0} BETWEEN '{1}' AND '{2}')", Entidades.RequerimientoCompraProducto.Columnas.FechaEntrega.ToString(),
                                 ObtenerFecha(filtroABM.FechaEntregaDesde.Value.Date, False), ObtenerFecha(filtroABM.FechaEntregaHasta.Value.UltimoSegundoDelDia(), True))
            End If
         End If
      End With
   End Sub

   Public Function RequerimientosCompras_G1(idRequerimientoCompra As Long) As DataTable
      Return RequerimientosCompras_G(idRequerimientoCompra, idSucursal:=0, idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroRequerimiento:=0, filtroABM:=Nothing)
   End Function
   Public Function RequerimientosCompras_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroRequerimiento As Long) As DataTable
      Return RequerimientosCompras_G(idRequerimientoCompra:=0, idSucursal, idTipoComprobante, letra, centroEmisor, numeroRequerimiento, filtroABM:=Nothing)
   End Function

   Public Overloads Function GetCodigoMaximo() As Long
      Return GetCodigoMaximo(Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString(), Entidades.RequerimientoCompra.NombreTabla)
   End Function

   Public Function GetParaInfRequerimietos(fechaDesde As Date?, fechaHasta As Date?, fechaEntregaDesde As Date?, fechaEntregaHasta As Date?,
                                           tiposComprobante As Entidades.TipoComprobante(), numeroRequerimiento As Long,
                                           asignados As Entidades.Publicos.SiNoTodos, idUsuario As String,
                                           idProducto As String,
                                           marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                           rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                                           soloConLineasAnulables As Entidades.Publicos.SiNo) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT RC.*")
         .AppendFormatLine("     , CONVERT(DATE, RC.Fecha) Fecha_Fecha")
         .AppendFormatLine("     , CONVERT(TIME, RC.Fecha) Fecha_Hora")
         .AppendFormatLine("     , CONVERT(DATE, RC.FechaAlta) FechaAlta_Fecha")
         .AppendFormatLine("     , CONVERT(TIME, RC.FechaAlta) FechaAlta_Hora")
         .AppendFormatLine("     , TC.Descripcion DescripcionTipoComprobante")
         .AppendFormatLine("  FROM {0} RC", Entidades.RequerimientoCompra.NombreTabla)
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = RC.IdTipoComprobante")

         .AppendFormatLine(" WHERE 1 = 1")
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND RC.{0} BETWEEN '{1}' AND '{2}'", Entidades.RequerimientoCompra.Columnas.Fecha.ToString(), ObtenerFecha(fechaDesde.Value, True), ObtenerFecha(fechaHasta.Value, True))
         End If
         If fechaEntregaDesde.HasValue Then
            .AppendFormatLine("   AND EXISTS (SELECT 1 FROM {0} RCP", Entidades.RequerimientoCompraProducto.NombreTabla)
            .AppendFormatLine("                WHERE RCP.{0} = RC.{1}", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString())
            .AppendFormatLine("                  AND RCP.{0} BETWEEN '{1}' AND '{2}')", Entidades.RequerimientoCompraProducto.Columnas.FechaEntrega.ToString(),
                                 ObtenerFecha(fechaEntregaDesde.Value.Date, False), ObtenerFecha(fechaEntregaHasta.Value.UltimoSegundoDelDia(), True))
         End If

         GetListaTiposComprobantesMultiples(stb, tiposComprobante, "RC")

         If numeroRequerimiento > 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString(), numeroRequerimiento)
         End If

         'If asignados <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormatLine("   AND {0} EXISTS(SELECT 1 FROM RequerimientosComprasProductosAsignaciones RCPA", If(asignados = Entidades.Publicos.SiNoTodos.NO, "NOT", ""))
         '   .AppendFormatLine("               WHERE RCPA.IdRequerimientoCompra = RC.IdRequerimientoCompra")
         '   .AppendFormatLine("             )")
         'End If

         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString(), idUsuario)
         End If

         If Not String.IsNullOrWhiteSpace(idProducto) Or
            marcas.AnySecure() Or modelos.AnySecure() Or rubros.AnySecure() Or subrubros.AnySecure() Or subSubRubros.AnySecure() Then

            .AppendFormatLine("   AND EXISTS (SELECT 1")
            .AppendFormatLine("                 FROM RequerimientosComprasProductos RCP")
            .AppendFormatLine("                INNER JOIN Productos P ON P.IdProducto = RCP.IdProducto")
            .AppendFormatLine("                WHERE RCP.IdRequerimientoCompra = RC.IdRequerimientoCompra")
            If Not String.IsNullOrWhiteSpace(idProducto) Then
               .AppendFormatLine("                  AND P.IdProducto = '{0}'", idProducto)
            End If
            GetListaMarcasMultiples(stb, marcas, "P")
            GetListaModelosMultiples(stb, modelos, "P")
            GetListaRubrosMultiples(stb, rubros, "P")
            GetListaSubRubrosMultiples(stb, subrubros, "P")
            GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")
            .AppendFormatLine("               )")
         End If

         If soloConLineasAnulables = Entidades.Publicos.SiNo.SI Then
            .AppendFormatLine("   AND EXISTS(SELECT 1 FROM RequerimientosComprasProductos RCP")
            .AppendFormatLine("               WHERE RCP.IdRequerimientoCompra = RC.IdRequerimientoCompra")
            .AppendFormatLine("                 AND RCP.FechaAnulacion IS NULL")
            .AppendFormatLine("                 AND NOT EXISTS (SELECT * FROM RequerimientosComprasProductosAsignaciones RCPA")
            .AppendFormatLine("                                  WHERE RCPA.IdRequerimientoCompra = RCP.IdRequerimientoCompra")
            .AppendFormatLine("                                    AND RCPA.IdProducto = RCP.IdProducto")
            .AppendFormatLine("                                    AND RCPA.Orden = RCP.Orden))")
         End If

      End With
      Return GetDataTable(stb)

   End Function

   Public Function GetInfReqDetProducto(fechaDesde As Date?, fechaHasta As Date?, fechaEntregaDesde As Date?, fechaEntregaHasta As Date?,
                                        tiposComprobante As Entidades.TipoComprobante(), numeroRequerimiento As Long,
                                        asignados As Entidades.Publicos.SiNoTodos, detallesAsignados As Entidades.Publicos.SiNoTodos, idUsuario As String,
                                        idProveedor As Long, idProducto As String,
                                        marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                        rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                                        anulados As Entidades.Publicos.SiNoTodos,
                                        agregarSelec As Boolean, incluyeDetalleAsignados As Boolean,
                                        PlanMaestroNumero As Integer?, PlanMaestroFechaDesde As Date?,
                                        PlanMaestroFechaHasta As Date?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ")
         If agregarSelec Then
            .AppendFormatLine("       CONVERT(BIT, 0) Selec,")
         End If
         .AppendFormatLine("       RC.IdRequerimientoCompra")
         .AppendFormatLine("     , RC.IdTipoComprobante")
         .AppendFormatLine("     , TC.Descripcion                       AS DescripcionTipoComprobante")
         .AppendFormatLine("     , TC.DescripcionAbrev                  AS DescripcionAbrevTipoComprobante")
         .AppendFormatLine("     , RC.Letra")
         .AppendFormatLine("     , RC.CentroEmisor")
         .AppendFormatLine("     , RC.NumeroRequerimiento")
         .AppendFormatLine("     , RC.Fecha")
         .AppendFormatLine("     , CONVERT(DATE, RC.Fecha)              AS Fecha_Fecha")
         .AppendFormatLine("     , CONVERT(TIME, RC.Fecha)              AS Fecha_Hora")
         .AppendFormatLine("     , RC.Observacion")
         .AppendFormatLine("     , RC.IdUsuarioAlta")
         .AppendFormatLine("     , RCP.Orden")
         .AppendFormatLine("     , RCP.IdProducto")
         .AppendFormatLine("     , RCP.NombreProducto")
         .AppendFormatLine("     , RCP.Cantidad")
         .AppendFormatLine("     , RCP.CantidadUMCompra")
         .AppendFormatLine("     , RCP.FactorConversionCompra")
         '.AppendFormatLine("     , P.IdUnidadDeMedida")
         '.AppendFormatLine("     , UN.NombreUnidadDeMedida")

         .AppendFormatLine("     , RCP.IdUnidadDeMedida IdUnidadDeMedida")
         .AppendFormatLine("     , UNS.NombreUnidadDeMedida NombreUnidadDeMedida")

         .AppendFormatLine("     , RCP.IdUnidadDeMedidaCompra")
         .AppendFormatLine("     , UNC.NombreUnidadDeMedida NombreUnidadDeMedidaCompra")

         .AppendFormatLine("     , RCP.FechaEntrega")
         .AppendFormatLine("     , CONVERT(DATE, RCP.FechaEntrega)      AS FechaEntrega_Fecha")
         .AppendFormatLine("     , CONVERT(TIME, RCP.FechaEntrega)      AS FechaEntrega_Hora")
         .AppendFormatLine("     , RCP.Observacion                      AS ObservacionRQProducto")
         .AppendFormatLine("     , P.IdRubro")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , P.IdSubRubro")
         .AppendFormatLine("     , SR.NombreSubRubro")
         .AppendFormatLine("     , P.IdSubSubRubro")
         .AppendFormatLine("     , SSR.NombreSubSubRubro")
         .AppendFormatLine("     , P.IdMarca")
         .AppendFormatLine("     , M.NombreMarca")
         .AppendFormatLine("     , P.IdModelo")
         .AppendFormatLine("     , Mo.NombreModelo")
         .AppendFormatLine("     , P.IdProveedor                        AS IdProveedorHabitual")
         .AppendFormatLine("     , Pr.CodigoProveedor                   AS CodigoProveedorHabitual")
         .AppendFormatLine("     , Pr.NombreProveedor                   AS NombreProveedorHabitual")

         If incluyeDetalleAsignados Then
            .AppendFormatLine("     , RCA.IdSucursalPedido")
            .AppendFormatLine("     , RCA.IdTipoComprobantePedido")
            .AppendFormatLine("     , TCA.Descripcion                      AS DescripcionTipoComprobantePedido")
            .AppendFormatLine("     , TCA.DescripcionAbrev                 AS DescripcionAbrevTipoComprobantePedido")
            .AppendFormatLine("     , RCA.LetraPedido")
            .AppendFormatLine("     , RCA.CentroEmisorPedido")
            .AppendFormatLine("     , RCA.NumeroPedido")
            .AppendFormatLine("     , RCA.Cantidad                         AS CantidadAsignada")
            .AppendFormatLine("     , PP.IdProveedor                       AS IdProveedorAsignado")
            .AppendFormatLine("     , PrA.CodigoProveedor                  AS CodigoProveedorAsignado")
            .AppendFormatLine("     , PrA.NombreProveedor                  AS NombreProveedorAsignado")
            .AppendFormatLine("     , RCA.IdUsuarioAsignacion")
            .AppendFormatLine("     , RCA.FechaAsignacion")
            .AppendFormatLine("     , CONVERT(DATE, RCA.FechaAsignacion)   AS FechaAsignacion_Fecha")
            .AppendFormatLine("     , CONVERT(TIME, RCA.FechaAsignacion)   AS FechaAsignacion_Hora")
         Else
            .AppendFormatLine("     , CONVERT(INT, NULL)                   AS IdSucursalPedido")
            .AppendFormatLine("     , CONVERT(VARCHAR(MAX), NULL)          AS IdTipoComprobantePedido")
            .AppendFormatLine("     , CONVERT(VARCHAR(MAX), NULL)          AS DescripcionTipoComprobantePedido")
            .AppendFormatLine("     , CONVERT(VARCHAR(MAX), NULL)          AS DescripcionAbrevTipoComprobantePedido")
            .AppendFormatLine("     , CONVERT(VARCHAR(MAX), NULL)          AS LetraPedido")
            .AppendFormatLine("     , CONVERT(INT, NULL)                   AS CentroEmisorPedido")
            .AppendFormatLine("     , CONVERT(BIGINT, NULL)                AS NumeroPedido")
            .AppendFormatLine("     , CONVERT(DECIMAL(16,4), NULL)         AS CantidadAsignada")
            .AppendFormatLine("     , CONVERT(BIGINT, NULL)                AS IdProveedorAsignado")
            .AppendFormatLine("     , CONVERT(BIGINT, NULL)                AS CodigoProveedorAsignado")
            .AppendFormatLine("     , CONVERT(VARCHAR(MAX), NULL)          AS NombreProveedorAsignado")
            .AppendFormatLine("     , CONVERT(VARCHAR(MAX), NULL)          AS IdUsuarioAsignacion")
            .AppendFormatLine("     , CONVERT(DATETIME, NULL)              AS FechaAsignacion")
            .AppendFormatLine("     , CONVERT(DATE, NULL)                  AS FechaAsignacion_Fecha")
            .AppendFormatLine("     , CONVERT(TIME, NULL)                  AS FechaAsignacion_Hora")
         End If
         .AppendFormatLine("  FROM RequerimientosCompras RC")
         .AppendFormatLine(" INNER JOIN RequerimientosComprasProductos RCP")
         .AppendFormatLine("         ON RCP.IdRequerimientoCompra = RC.IdRequerimientoCompra")
         If incluyeDetalleAsignados Then
            .AppendFormatLine("  LEFT JOIN RequerimientosComprasProductosAsignaciones RCA")
            .AppendFormatLine("         ON RCA.IdRequerimientoCompra = RCP.IdRequerimientoCompra")
            .AppendFormatLine("        AND RCA.IdProducto = RCP.IdProducto")
            .AppendFormatLine("        AND RCA.Orden = RCP.Orden")
         End If
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = RC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = RCP.IdProducto")
         .AppendFormatLine("  LEFT JOIN UnidadesDeMedidas UN ON UN.IdUnidadDeMedida = P.IdUnidadDeMedida")
         .AppendFormatLine("  LEFT JOIN UnidadesDeMedidas UNS ON UNS.IdUnidadDeMedida = RCP.IdUnidadDeMedida")
         .AppendFormatLine("  LEFT JOIN UnidadesDeMedidas UNC ON UNC.IdUnidadDeMedida = RCP.IdUnidadDeMedidaCompra")
         .AppendFormatLine("  LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendFormatLine("  LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  LEFT JOIN Modelos Mo ON Mo.IdModelo = P.IdModelo")
         .AppendFormatLine("  LEFT JOIN Proveedores Pr ON Pr.IdProveedor = P.IdProveedor")
         If incluyeDetalleAsignados Then
            .AppendFormatLine("  LEFT JOIN PedidosProveedores PP ")
            .AppendFormatLine("         ON PP.IdSucursal = RCA.IdSucursalPedido")
            .AppendFormatLine("        AND PP.IdTipoComprobante = RCA.IdTipoComprobantePedido")
            .AppendFormatLine("        AND PP.Letra = RCA.LetraPedido")
            .AppendFormatLine("        AND PP.CentroEmisor = RCA.CentroEmisorPedido")
            .AppendFormatLine("        AND PP.NumeroPedido = RCA.NumeroPedido")
            .AppendFormatLine("  LEFT JOIN Proveedores PrA ON PrA.IdProveedor = PP.IdProveedor")
            .AppendFormatLine("  LEFT JOIN TiposComprobantes TCA ON TCA.IdTipoComprobante = PP.IdTipoComprobante")
         End If

         .AppendFormatLine(" WHERE 1 = 1")
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND RC.{0} BETWEEN '{1}' AND '{2}'", Entidades.RequerimientoCompra.Columnas.Fecha.ToString(), ObtenerFecha(fechaDesde.Value, True), ObtenerFecha(fechaHasta.Value, True))
         End If
         If fechaEntregaDesde.HasValue Then
            .AppendFormatLine("   AND EXISTS (SELECT 1 FROM {0} RCP", Entidades.RequerimientoCompraProducto.NombreTabla)
            .AppendFormatLine("                WHERE RCP.{0} = RC.{1}", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString())
            .AppendFormatLine("                  AND RCP.{0} BETWEEN '{1}' AND '{2}')", Entidades.RequerimientoCompraProducto.Columnas.FechaEntrega.ToString(),
                                 ObtenerFecha(fechaEntregaDesde.Value.Date, False), ObtenerFecha(fechaEntregaHasta.Value.UltimoSegundoDelDia(), True))
         End If

         GetListaTiposComprobantesMultiples(stb, tiposComprobante, "RC")

         If numeroRequerimiento > 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString(), numeroRequerimiento)
         End If

         If asignados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND {0} EXISTS(SELECT 1 FROM RequerimientosComprasProductosAsignaciones RCPA", If(asignados = Entidades.Publicos.SiNoTodos.NO, "NOT", ""))
            .AppendFormatLine("               WHERE RCPA.IdRequerimientoCompra = RC.IdRequerimientoCompra")
            .AppendFormatLine("             )")
         End If
         If detallesAsignados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND {0} EXISTS(SELECT 1 FROM RequerimientosComprasProductosAsignaciones RCPA", If(detallesAsignados = Entidades.Publicos.SiNoTodos.NO, "NOT", ""))
            .AppendFormatLine("               WHERE RCPA.IdRequerimientoCompra   = RC.IdRequerimientoCompra")
            .AppendFormatLine("                 AND RCPA.IdProducto              = RCP.IdProducto")
            .AppendFormatLine("                 AND RCPA.Orden                   = RCP.Orden")
            .AppendFormatLine("             )")
         End If

         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString(), idUsuario)
         End If

         If anulados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND RCP.{0} IS {1} NULL", Entidades.RequerimientoCompraProducto.Columnas.FechaAnulacion.ToString(),
                              If(anulados = Entidades.Publicos.SiNoTodos.SI, "NOT", ""))
         End If

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("                  AND P.IdProducto = '{0}'", idProducto)
         End If
         If idProveedor <> 0 Then
            .AppendFormatLine("                  AND P.IdProveedor = {0}", idProveedor)
         End If

         If PlanMaestroNumero > 0 Then
            .AppendFormatLine("    AND EXISTS (SELECT 1 FROM OrdenesProduccionEstados OPE
                   LEFT JOIN OrdenesProduccionMRPProductos OPMRPP ON OPMRPP.IdRequerimiento = RCP.IdRequerimientoCompra
                              AND OPMRPP.IdProductoRQ = RCP.IdProducto 
                WHERE OPE.IdSucursal = OPMRPP.IdSucursal 
                             AND OPE.NumeroOrdenProduccion = OPMRPP.NumeroOrdenProduccion
                            AND OPE.IdProducto = OPMRPP.IdProducto")
            .AppendFormatLine("   AND OPE.{0} =  {1}) ", Entidades.OrdenProduccionEstado.Columnas.PlanMaestroNumero.ToString(), PlanMaestroNumero)
         End If

         If PlanMaestroFechaDesde.HasValue Then
            .AppendFormatLine("    AND EXISTS (SELECT 1 FROM OrdenesProduccionEstados OPE
                   LEFT JOIN OrdenesProduccionMRPProductos OPMRPP ON OPMRPP.IdRequerimiento = RCP.IdRequerimientoCompra
                              AND OPMRPP.IdProductoRQ = RCP.IdProducto 
                WHERE OPE.IdSucursal = OPMRPP.IdSucursal 
                             AND OPE.NumeroOrdenProduccion = OPMRPP.NumeroOrdenProduccion
                            AND OPE.IdProducto = OPMRPP.IdProducto")
            .AppendFormatLine("   AND OPE.{0} BETWEEN '{1}' AND '{2}')", Entidades.OrdenProduccionEstado.Columnas.PlanMaestroFecha.ToString(), ObtenerFecha(PlanMaestroFechaDesde.Value, True), ObtenerFecha(PlanMaestroFechaHasta.Value, True))
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaModelosMultiples(stb, modelos, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subrubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

      End With
      Return GetDataTable(stb)

   End Function

End Class