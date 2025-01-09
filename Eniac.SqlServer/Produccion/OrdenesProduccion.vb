Option Explicit On
Option Strict On

Public Class OrdenesProduccion

   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesProduccion_D(IdSucursal As Integer,
                        IdTipoComprobante As String, Letra As String,
                        CentroEmisor As Integer, NumeroOrdenProduccion As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendFormat("DELETE FROM OrdenesProduccion").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", IdSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", Letra)
         .AppendFormat("   AND CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("   AND NumeroOrdenProduccion = {0}", NumeroOrdenProduccion)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub OrdenesProduccion_I(idSucursal As Integer,
                        idTipoComprobante As String,
                        letra As String,
                        centroEmisor As Integer,
                        numeroOrdenProduccion As Long,
                        FechaOrdenProduccion As Date,
                        observacion As String,
                        IdUsuario As String,
                        descuentoRecargo As Double,
                        descuentoRecargoPorc As Double,
                        IdCliente As Long,
                        IdVendedor As Integer,
                        idFormaPago As Integer?,
                        idTransportista As Integer?,
                        cotizacionDolar As Decimal?,
                        idTipoComprobanteFact As String,
                        ImporteBruto As Decimal,
                        SubTotal As Decimal,
                        TotalImpuestos As Decimal,
                        TotalImpuestoInterno As Decimal,
                        ImporteTotal As Decimal,
                        idEstadoVisita As Integer,
                        NumeroOrdenCompra As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendFormat("INSERT INTO OrdenesProduccion").AppendLine()
         .AppendFormat("           ({0}", Entidades.OrdenProduccion.Columnas.IdSucursal.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.IdTipoComprobante.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.Letra.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.CentroEmisor.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.NumeroOrdenProduccion.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.FechaOrdenProduccion.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.Observacion.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.IdUsuario.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.DescuentoRecargo.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.DescuentoRecargoPorc.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.IdCliente.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.IdVendedor.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.IdFormasPago.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.IdTransportista.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.CotizacionDolar.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.IdTipoComprobanteFact.ToString()).AppendLine()

         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.ImporteBruto.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.SubTotal.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.TotalImpuestos.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.TotalImpuestoInterno.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.ImporteTotal.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.IdEstadoVisita.ToString()).AppendLine()

         .AppendFormat("           ,{0}", Entidades.OrdenProduccion.Columnas.NumeroOrdenCompra.ToString()).AppendLine()

         .AppendFormat(" ) VALUES (").AppendLine()
         .AppendFormat("            {0} ", idSucursal).AppendLine()
         .AppendFormat("          ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("          ,'{0}'", letra).AppendLine()
         .AppendFormat("          , {0} ", centroEmisor).AppendLine()
         .AppendFormat("          , {0} ", numeroOrdenProduccion).AppendLine()
         .AppendFormat("          ,'{0}'", Me.ObtenerFecha(FechaOrdenProduccion, True)).AppendLine()
         .AppendFormat("          ,'{0}'", observacion).AppendLine()
         .AppendFormat("          ,'{0}'", IdUsuario).AppendLine()
         .AppendFormat("          , {0} ", descuentoRecargo).AppendLine()
         .AppendFormat("          , {0} ", descuentoRecargoPorc).AppendLine()
         .AppendFormat("          , {0} ", IdCliente).AppendLine()

         If IdVendedor > 0 Then
            .AppendFormat("          ,{0}", IdVendedor).AppendLine()
         Else
            .AppendFormat("          , NULL ").AppendLine()
         End If

         If idFormaPago.HasValue Then
            .AppendFormat("          , {0} ", idFormaPago.Value).AppendLine()
         Else
            .AppendFormat("          , NULL ").AppendLine()
         End If
         If idTransportista > 0 Then
            .AppendFormat("          , {0} ", idTransportista.Value).AppendLine()
         Else
            .AppendFormat("          , NULL ").AppendLine()
         End If
         If cotizacionDolar.HasValue Then
            .AppendFormat("          , {0} ", cotizacionDolar.Value).AppendLine()
         Else
            .AppendFormat("          , NULL ").AppendLine()
         End If
         If String.IsNullOrWhiteSpace(idTipoComprobanteFact) Then
            .AppendFormat("          , NULL ").AppendLine()
         Else
            .AppendFormat("          ,'{0}'", idTipoComprobanteFact).AppendLine()
         End If

         .AppendFormat("          ,{0}", ImporteBruto).AppendLine()
         .AppendFormat("          ,{0}", SubTotal).AppendLine()
         .AppendFormat("          ,{0}", TotalImpuestos).AppendLine()
         .AppendFormat("          ,{0}", TotalImpuestoInterno).AppendLine()
         .AppendFormat("          ,{0}", ImporteTotal).AppendLine()
         .AppendFormat("          ,{0} ", idEstadoVisita).AppendLine()

         If NumeroOrdenCompra > 0 Then
            .AppendFormat("          ,{0}", NumeroOrdenCompra).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If

         .AppendFormat(")")
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   'Public Function getOrdenProduccionXid(IdSucursal As Integer,
   '                             idTipoComprobante As String,
   '                             letra As String,
   '                             centroEmisor As Integer,
   '                             numeroOrdenProduccion As Long) As DataTable

   '   Dim stbQuery As StringBuilder = New StringBuilder("")

   '   With stbQuery
   '      .Length = 0
   '      .AppendLine("SELECT pe.IdSucursal")
   '      .AppendLine("      ,P.IdTipoComprobante")
   '      .AppendLine("      ,P.Letra")
   '      .AppendLine("      ,P.CentroEmisor")
   '      .AppendLine("      ,P.NumeroOrdenProduccion")
   '      .AppendLine("      ,P.FechaOrdenProduccion")
   '      .AppendLine("      ,P.IdCliente, C.NombreCliente")
   '      .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano, Pr.IdUnidadDeMedida, pp.Orden")
   '      .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
   '      .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
   '      .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE pe.CantEntregada END) AS CantEntregada")
   '      .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pe.CantEntregada ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
   '      .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
   '      .AppendLine("      ,pe.IdUsuario")
   '      .AppendLine("      ,pe.observacion")
   '      .AppendLine("      ,PE.IdCriticidad")
   '      .AppendLine("      ,PE.FechaEntrega")
   '      .AppendLine(" FROM OrdenesProduccion P")
   '      .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
   '      .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
   '      .AppendLine("                               AND PP.Letra = P.Letra")
   '      .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
   '      .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
   '      .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal")
   '      .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
   '      .AppendLine("                             AND PE.Letra = P.Letra")
   '      .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
   '      .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
   '      .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
   '      .AppendLine("                             AND PE.Orden = PP.Orden")
   '      .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
   '      .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente")
   '      .AppendLine(" INNER JOIN Productos PR ON PR.IdProducto = PE.IdProducto")

   '      .AppendLine(" WHERE p.IdSucursal = " & IdSucursal.ToString())
   '      .AppendLine("   AND P.IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
   '      .AppendLine("   AND P.Letra = '" & letra.ToString() & "'")
   '      .AppendLine("   AND P.CentroEmisor = " & centroEmisor.ToString())
   '      .AppendLine("   AND P.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
   '      .AppendLine(" ORDER BY p.FechaOrdenProduccion")
   '   End With

   '   Return Me.GetDataTable(stbQuery.ToString())

   'End Function

   Public Function GetOrdenesProduccion(idSucursal As Integer, tiposComprobantes As Entidades.TipoComprobante(), idEstado As String,
                                        fechaDesde As Date, fechaHasta As Date, numeroOrdenProduccion As Long,
                                        idProducto As String, idCliente As Long, tamanio As Decimal,
                                        marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                        rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                                        ordenCompra As Long, idResponsable As Integer, idTipoComprobante As String, letra As String,
                                        centroEmisor As Integer, idPlanMaestro As Integer, fechaDesdePlan As Date?, fechaHastaPlan As Date?) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT '' as Color")
         .AppendLine("      , CONVERT(BIT, 0) /*'False'*/ as masivo")
         .AppendLine("      ,pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,TC.Descripcion AS DescripcionTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroOrdenProduccion")
         .AppendLine("      ,P.FechaOrdenProduccion")
         .AppendLine("      ,P.IdCliente, C.NombreCliente")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.Tamano, pr.IdUnidadDeMedida, pp.Orden")

         .AppendFormatLine("     , PS.IdDepositoDefecto, SD.CodigoDeposito CodigoDepositoDefecto, SD.NombreDeposito NombreDepositoDefecto, PS.IdUbicacionDefecto, SU.CodigoUbicacion CodigoUbicacionDefecto, SU.NombreUbicacion NombreUbicacionDefecto")

         .AppendLine("      ,pp.Cantidad")
         .AppendLine("      ,pp.Precio")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN PU.Stock IS NOT NULL THEN PU.Stock ELSE 0 END) AS Stock")
         .AppendLine("      ,PE.CantEstado AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine("      ,m.NombreMarca")
         .AppendLine("      ,r.NombreRubro")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")
         .AppendLine("      ,PE.IdFormula")
         .AppendLine("      ,PP.IdProcesoProductivo")
         .AppendLine("      ,ISNULL(PP.Espmm, 0) Espmm")
         .AppendLine("      ,ISNULL(PP.LargoExtAlto, 0) LargoExtAlto")
         .AppendLine("      ,ISNULL(PP.AnchoIntBase, 0) AnchoIntBase")
         .AppendLine("      ,PE.IdResponsable")
         .AppendLine("      ,PE.PlanMaestroNumero")
         .AppendLine("      ,PE.PlanMaestroFecha")
         .AppendLine("      ,E.NombreEmpleado AS NombreResponsable")
         '-------------------------------------------------------------
         .AppendLine("      ,EP.ReservaMateriaPrima")
         .AppendLine("      ,PS.IdDepositoDefecto")
         .AppendLine("      ,SD.NombreDeposito ")
         .AppendLine("      ,PS.IdUbicacionDefecto")
         .AppendLine("      ,SU.NombreUbicacion ")
         '-------------------------------------------------------------
         .AppendLine("  FROM OrdenesProduccion P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN Productos PR ON PR.IdProducto = PE.IdProducto")
         '-------------------------------------------------------------
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PE.IdProducto AND PS.IdSucursal = P.IdSucursal")
         .AppendLine(" INNER JOIN SucursalesDepositos SD ON  SD.IdSucursal = P.IdSucursal AND SD.IdDeposito = PS.IdDepositoDefecto")
         .AppendLine(" INNER JOIN SucursalesUbicaciones SU ON  SU.IdSucursal = P.IdSucursal AND SU.IdDeposito = PS.IdDepositoDefecto AND SU.IdUbicacion = PS.IdUbicacionDefecto ")
         .AppendLine(" LEFT JOIN ProductosUbicaciones PU ON PU.IdProducto = PE.IdProducto AND PU.IdSucursal = P.IdSucursal AND PU.IdDeposito = PS.IdDepositoDefecto AND PU.IdUbicacion = PS.IdUbicacionDefecto")
         '-------------------------------------------------------------

         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendLine(" INNER JOIN Empleados E ON PE.IdResponsable = E.IdEmpleado")
         .AppendLine(" WHERE p.IdSucursal = " & idSucursal.ToString())

         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobantes, "P")

         If idEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf idEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf idEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & idEstado.ToString() & "'")
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendFormatLine("   AND p.FechaOrdenProduccion >= '{0}'", ObtenerFecha(fechaDesde, False))
            .AppendFormatLine("   AND p.FechaOrdenProduccion <= '{0}'", ObtenerFecha(fechaHasta, True))
         End If


         If idCliente > 0 Then
            .AppendLine("   AND C.IdCliente = " & idCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & idProducto & "'")
         End If

         GetListaMarcasMultiples(stbQuery, marcas, "Pr")
         GetListaModelosMultiples(stbQuery, modelos, "Pr")
         GetListaRubrosMultiples(stbQuery, rubros, "Pr")
         GetListaSubRubrosMultiples(stbQuery, subRubros, "Pr")
         GetListaSubSubRubrosMultiples(stbQuery, subSubRubros, "Pr")

         If tamanio > 0 Then
            .AppendLine("    and pr.Tamano = " & tamanio.ToString())
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idResponsable <> 0 Then
            .AppendFormat("	AND PE.IdResponsable = {0}", idResponsable)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("   AND p.IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         End If
         If Not String.IsNullOrEmpty(letra) Then
            .AppendLine("   AND p.Letra = '" & letra.ToString() & "'")
         End If
         If centroEmisor <> 0 Then
            .AppendFormat("	AND P.CentroEmisor = {0}", centroEmisor)
         End If
         If numeroOrdenProduccion > 0 Then
            .AppendLine("   AND p.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         End If

         '-- Numero Plan Maestro Produccion.- ------------------------------------------------------------------------
         If idPlanMaestro > 0 Then
            .AppendFormatLine("   AND PE.PlanMaestroNumero = {0}", idPlanMaestro)
         End If
         '-- Fecha Plan Maestro Orden de Produccion.- -------------------------------------------------------------
         If fechaDesdePlan.HasValue Then
            .AppendFormatLine("   AND PE.PlanMaestroFecha >= '{0}'", ObtenerFecha(fechaDesdePlan.Value, True))
            .AppendFormatLine("   AND PE.PlanMaestroFecha <= '{0}'", ObtenerFecha(fechaHastaPlan.Value, True))
         End If
         '----------------------------------------------------------------------------------------------------------
         .AppendLine(" ORDER BY p.FechaOrdenProduccion")

      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Function GetOrdenesProduccionTareas(idSucursal As Integer, idEstado As String,
                                              fechaDesde As Date, fechaHasta As Date, numeroOrdenProduccion As Long,
                                              idProducto As String, idCliente As Long, tamanio As Decimal, idMarca As Integer, idRubro As Integer,
                                              ordenCompra As Long, idResponsable As Integer,
                                              idTipoComprobante As String, seccion As Integer, tarea As Integer,
                                              idPedido As Integer, linea As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT PE.IdSucursal")
         .AppendLine("      , P.IdTipoComprobante")
         .AppendLine("      , P.Letra")
         .AppendLine("      , P.CentroEmisor")
         .AppendLine("      , P.NumeroOrdenProduccion")
         .AppendLine("	    , PP.Orden")
         .AppendLine("      , P.FechaOrdenProduccion")
         .AppendLine("      , P.IdCliente, C.NombreCliente")
         .AppendLine("      , PP.idProducto, pp.NombreProducto")
         .AppendLine("      , PE.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      , PE.observacion")
         .AppendLine("      , M.NombreMarca")
         .AppendLine("      , R.NombreRubro")
         .AppendLine("      , PE.FechaEntrega")
         .AppendLine("      , PE.IdResponsable")
         .AppendLine("      , E.NombreEmpleado AS NombreResponsable")
         .AppendLine("	    , PDE.IdSucursal AS IdSucursalPedido")
         .AppendLine("	    , PDE.IdTipoComprobante AS IdTipoComprobantePedido")
         .AppendLine("	    , PDE.Letra AS LetraPedido")
         .AppendLine("	    , PDE.CentroEmisor AS CentroEmisorPedido")
         .AppendLine("	    , PDE.NumeroPedido")
         .AppendLine("	    , PDE.Orden AS OrdenPedido")
         .AppendLine("	    , POP.IdCodigoTarea ")
         .AppendLine("	    , POP.DescripcionOperacion ")
         .AppendLine("	    , POP.CodigoProcProdOperacion ")
         .AppendLine("	    , POP.IdProcesoProductivo ")
         .AppendLine("	    , POP.IdOperacion ")

         .AppendLine("	    , POP.IdEstadoTarea ")
         .AppendLine("	    , POP.FechaComienzo ")
         .AppendLine("	    , POP.IdEmpleado ")
         .AppendLine("      , POE.NombreEmpleado AS NombreEmpleado")

         .AppendLine("	    , POP.CentroProductorOperacion ")
         .AppendLine("	    , CP.CodigoCentroProductor ")
         .AppendLine("	    , CP.Descripcion AS DescripcionCP")
         .AppendLine("	    , CP.ClaseCentroProductor ")
         .AppendLine("	    , SCC.IdSeccion ")
         .AppendLine("	    , SCC.Descripcion as DescripcionSeccion")
         .AppendLine("	    , PCP.IdProveedor ")
         .AppendLine("	    , PCP.CodigoProveedor ")
         .AppendLine("	    , PCP.NombreProveedor ")
         .AppendLine("	    , P.Observacion ")
         .AppendLine("	    , POM.RespetaOrden ")
         '-------------------------------------------------------------
         .AppendLine(" FROM OrdenesProduccion P")
         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")

         .AppendLine(" LEFT JOIN OrdenesProduccionMRP POM ON POM.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND POM.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND POM.LetraComprobante = P.Letra")
         .AppendLine("                               AND POM.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND POM.NumeroOrdenProduccion = P.NumeroOrdenProduccion")

         .AppendLine(" LEFT JOIN OrdenesProduccionMRPOperaciones POP ON POP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND POP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND POP.LetraComprobante = P.Letra")
         .AppendLine("                               AND POP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND POP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" LEFT JOIN MRPCentrosProductores CP ON CP.IdCentroProductor = POP.CentroProductorOperacion")
         .AppendLine(" LEFT JOIN Proveedores PCP ON POP.Proveedor = PCP.IdProveedor ")
         .AppendLine(" LEFT JOIN MRPSecciones SCC ON CP.IdSeccion = SCC.IdSeccion")

         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")

         .AppendLine(" LEFT JOIN PEDIDOSESTADOS PDE ON PDE.IdSucursalProduccion = P.IdSucursal")
         .AppendLine("                               AND PDE.IdTipoComprobanteProduccion = P.IdTipoComprobante")
         .AppendLine("                               AND PDE.LetraProduccion = P.Letra")
         .AppendLine("                               AND PDE.CentroEmisorProduccion = P.CentroEmisor")
         .AppendLine("                               AND PDE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("							   AND PDE.OrdenProduccion = PP.Orden")

         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN Productos PR ON PR.IdProducto = PE.IdProducto")
         '-------------------------------------------------------------
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PE.IdProducto AND PS.IdSucursal = P.IdSucursal")
         .AppendLine(" INNER JOIN SucursalesDepositos SD ON  SD.IdSucursal = P.IdSucursal AND SD.IdDeposito = PS.IdDepositoDefecto")
         .AppendLine(" INNER JOIN SucursalesUbicaciones SU ON  SU.IdSucursal = P.IdSucursal AND SU.IdDeposito = PS.IdDepositoDefecto AND SU.IdUbicacion = PS.IdUbicacionDefecto ")
         .AppendLine(" INNER JOIN ProductosUbicaciones PU ON PU.IdProducto = PE.IdProducto AND PU.IdSucursal = P.IdSucursal AND PU.IdDeposito = PS.IdDepositoDefecto AND PU.IdUbicacion = PS.IdUbicacionDefecto")
         '-------------------------------------------------------------

         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendLine(" INNER JOIN Empleados E ON PE.IdResponsable = E.IdEmpleado")
         .AppendLine(" LEFT JOIN Empleados POE ON POP.IdEmpleado = POE.IdEmpleado")
         .AppendLine(" WHERE p.IdSucursal = " & idSucursal.ToString())

         If idEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf idEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf idEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & idEstado.ToString() & "'")
         End If

         If fechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaOrdenProduccion >= '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaOrdenProduccion <= '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If


         If idCliente > 0 Then
            .AppendLine("   AND C.IdCliente = " & idCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & idProducto & "'")
         End If

         If idMarca <> 0 Then
            .AppendFormat("	AND Pr.IdMarca = '{0}'", idMarca)
         End If

         If idRubro <> 0 Then
            .AppendFormat("	AND Pr.IdRubro = '{0}'", idRubro)
         End If

         If tamanio > 0 Then
            .AppendLine("    and pr.Tamano = " & tamanio.ToString())
         End If

         If ordenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & ordenCompra.ToString())
         End If

         If idResponsable <> 0 Then
            .AppendFormat("	AND PE.IdResponsable = {0}", idResponsable)
         End If

         If numeroOrdenProduccion > 0 Then
            .AppendLine("   AND p.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
            .AppendLine("   AND p.IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         End If

         If seccion > 0 Then
            .AppendLine("   AND SCC.IdSeccion = " & seccion.ToString())
         End If

         If tarea > 0 Then
            .AppendLine("   AND POP.IdCodigoTarea = " & tarea.ToString())
         End If

         If idPedido > 0 Then
            .AppendLine("   AND PDE.NumeroPedido = " & idPedido.ToString())
         End If
         If linea > 0 Then
            .AppendLine("   AND PDE.Orden = '" & linea.ToString() & "'")
         End If

         .AppendLine(" ORDER BY p.FechaOrdenProduccion")

      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Function GetOrdenesProduccionDeclaracion(idSucursal As Integer, fechaDesde As Date?, fechaHasta As Date?, numeroOrdenProduccion As Long,
                                                   idProducto As String, idCliente As Long, idTipoComprobante As String, idPedido As Integer, linea As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT P.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroOrdenProduccion")
         .AppendLine("     , PP.Orden")

         .AppendLine("     , PP.Cantidad AS CantidadPedida")
         .AppendLine("     , CASE WHEN (SELECT SUM(CantidadProcesada) as CantidadPendientes FROM OrdenesProduccionMRPProductos ")
         .AppendLine("     		WHERE NumeroOrdenProduccion = P.NumeroOrdenProduccion and EsProductoNecesario = 0 AND IDProducto = PP.idProducto) = PP.Cantidad THEN 0 ELSE")
         .AppendLine("     	(SELECT SUM(CantidadProcesada) as CantidadPendientes FROM OrdenesProduccionMRPProductos ")
         .AppendLine("     		WHERE NumeroOrdenProduccion = P.NumeroOrdenProduccion and EsProductoNecesario = 0 AND IDProducto = PP.idProducto) END")
         .AppendLine("     		AS CantidadPendiente")

         .AppendLine("     , P.FechaOrdenProduccion")
         .AppendLine("     , P.IdCliente, C.NombreCliente")
         .AppendLine("     , PP.idProducto, pp.NombreProducto")
         .AppendLine("     , POM.IdProcesoProductivo ")
         .AppendLine("     , MPP.DescripcionProceso")
         .AppendLine("     , OPE.IdEstado ")

         .AppendLine("     , PP.IdTipoComprobantePedido")
         .AppendLine("     , PP.LetraPedido")
         .AppendLine("     , PP.CentroEmisorPedido CentroPedido")
         .AppendLine("     , PP.NumeroPedido")
         .AppendLine("     , PP.OrdenPedido")

         '-------------------------------------------------------------
         .AppendLine(" FROM OrdenesProduccion P")

         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")

         .AppendLine(" INNER JOIN OrdenesProduccionEstados OPE ON OPE.IdSucursal = PP.IdSucursal")
         .AppendLine("                                        AND OPE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                                        AND OPE.Letra = P.Letra")
         .AppendLine("                                        AND OPE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                                        AND OPE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                                        AND OPE.IdProducto = PP.IdProducto")
         .AppendLine("                                        AND OPE.Orden = PP.Orden")

         .AppendLine(" LEFT JOIN OrdenesProduccionMRP POM ON POM.IdSucursal = P.IdSucursal")
         .AppendLine("                                   AND POM.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                                   AND POM.LetraComprobante = P.Letra")
         .AppendLine("                                   AND POM.CentroEmisor = P.CentroEmisor")
         .AppendLine("                                   AND POM.NumeroOrdenProduccion = P.NumeroOrdenProduccion")

         .AppendLine(" LEFT JOIN OrdenesProduccionMRPOperaciones OPO ON OPO.IdSucursal = POM.IdSucursal ")
         .AppendLine("                                              AND OPO.IdTipoComprobante = POM.IdTipoComprobante")
         .AppendLine("                                              AND OPO.LetraComprobante = POM.LetraComprobante")
         .AppendLine("                                              AND OPO.CentroEmisor = POM.CentroEmisor")
         .AppendLine("                                              AND OPO.NumeroOrdenProduccion = POM.NumeroOrdenProduccion")

         .AppendLine(" LEFT JOIN OrdenesProduccionMRPProductos OPP ON OPP.IdSucursal = OPO.IdSucursal")
         .AppendLine("                                            AND OPP.IdTipoComprobante = OPO.IdTipoComprobante")
         .AppendLine("                                            AND OPP.LetraComprobante = OPO.LetraComprobante")
         .AppendLine("                                            AND OPP.CentroEmisor = OPO.CentroEmisor")
         .AppendLine("                                            AND OPP.NumeroOrdenProduccion = OPO.NumeroOrdenProduccion")
         .AppendLine("                                            AND OPP.Orden = OPO.Orden")
         .AppendLine("                                            AND OPP.Idproducto = OPO.IdProducto")
         .AppendLine("                                            AND OPP.IdProcesoProductivo = OPO.IdProcesoProductivo")
         .AppendLine("                                            AND OPP.IdOperacion = OPO.IdOperacion")

         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = OPE.IdEstado")
         .AppendLine(" INNER JOIN MRPProcesosProductivos MPP ON MPP.IdProcesoProductivo = POM.IdProcesoProductivo")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN Productos PR ON PR.IdProducto = OPE.IdProducto")
         '-------------------------------------------------------------
         .AppendFormatLine(" WHERE p.IdSucursal = {0}", idSucursal)
         '-------------------------------------------------------------
         .AppendFormatLine("   AND EP.IdTipoEstado = '{0}'", Entidades.EstadoOrdenProduccion.TipoEstado.ENPROCESO.ToString())
         .AppendFormatLine("   AND POM.IdProcesoProductivo IS NOT NULL")
         '-------------------------------------------------------------
         .AppendFormatLine("   AND OPO.IdEstadotarea <> '{0}'", Entidades.MRPProcesoProductivoOperacion.EstadoAsignaTarea.FINALIZADA.ToString())
         .AppendFormatLine("   AND OPP.EsProductoNecesario = 0")
         '-------------------------------------------------------------


         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND P.FechaOrdenProduccion >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND P.FechaOrdenProduccion <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If


         If idCliente > 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND PP.IdProducto = '{0}'", idProducto)
         End If

         If numeroOrdenProduccion > 0 Then
            .AppendFormatLine("   AND P.NumeroOrdenProduccion = {0}", numeroOrdenProduccion)
            .AppendFormatLine("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If idPedido > 0 Then
            .AppendFormatLine("   AND PP.NumeroPedido = {0}", idPedido)
         End If
         If linea > 0 Then
            .AppendFormatLine("   AND PP.OrdenPedido = {0}", linea)
         End If

         .AppendLine("   AND POM.IdProcesoProductivo IS NOT NULL")

         .AppendLine("   GROUP BY P.IdSucursal")
         .AppendLine("          , P.IdTipoComprobante")
         .AppendLine("          , P.Letra")
         .AppendLine("          , P.CentroEmisor")
         .AppendLine("          , P.NumeroOrdenProduccion")
         .AppendLine("          , PP.Orden")
         .AppendLine("          , PP.Cantidad")
         .AppendLine("          , OPP.CantidadSolicitada")
         .AppendLine("          , OPE.CantEstado")
         .AppendLine("          , P.FechaOrdenProduccion")
         .AppendLine("          , POM.IdProcesoProductivo")
         .AppendLine("          , MPP.DescripcionProceso")
         .AppendLine("          , P.IdCliente, C.NombreCliente")
         .AppendLine("          , PP.IdProducto, PP.NombreProducto")
         .AppendLine("          , OPE.IdEstado  ")
         .AppendLine("          , PP.IdTipoComprobantePedido ")
         .AppendLine("          , PP.LetraPedido ")
         .AppendLine("          , PP.CentroEmisorPedido ")
         .AppendLine("          , PP.NumeroPedido ")
         .AppendLine("          , PP.OrdenPedido ")

         .AppendLine(" ORDER BY p.FechaOrdenProduccion")

      End With

      Return GetDataTable(stbQuery)
   End Function
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT P.* ")
         .AppendLine("  FROM OrdenesProduccion P")
      End With
   End Sub

   Public Function OrdenesProduccion_GA(IdSucursal As Integer) As DataTable
      Return OrdenesProduccion_GA(IdSucursal, 0)
   End Function
   Public Function OrdenesProduccion_GA(IdSucursal As Integer, numeroOrdenCompra As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE P.IdSucursal = {0}", IdSucursal).AppendLine()
         If numeroOrdenCompra > 0 Then
            .AppendFormat("   AND P.NumeroOrdenCompra = {0}", numeroOrdenCompra)
         End If
         .AppendLine("  ORDER BY P.IdSucursal, P.IdTipoComprobante, P.Letra, P.CentroEmisor, P.NumeroOrdenProduccion")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function OrdenesProduccion_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE P.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND P.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND P.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND P.NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()
         .AppendLine("  ORDER BY P.IdSucursal, P.IdTipoComprobante, P.Letra, P.CentroEmisor, P.NumeroOrdenProduccion")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

#Region "reporte"

   Public Function GetOrdenesProduccionDetalleComprobante_estructura() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.IdSucursal, ")
         .AppendLine("	V.IdTipoComprobante,")
         .AppendLine("	V.Letra,")
         .AppendLine("	V.CentroEmisor,")
         .AppendLine("	V.NumeroComprobante,")
         .AppendLine("	V.Fecha,")
         .AppendLine("	V.IdCliente,")
         .AppendLine("	V.IdVendedor,")
         .AppendLine("	V.IdCategoriaFiscal,")
         .AppendLine("	V.IdFormasPago,")
         .AppendLine("	V.Observacion,")
         .AppendLine("	I.IdImpresora,")
         .AppendLine("	I.TipoImpresora,")
         .AppendLine("	V.ImporteBruto,")
         .AppendLine("	V.DescuentoRecargo,")
         .AppendLine("	V.DescuentoRecargoPorc,")
         .AppendLine("	V.SubTotal,")
         .AppendLine("	V.TotalImpuestos,")
         .AppendLine("	V.ImporteTotal,")
         .AppendLine("	V.IdEstadoComprobante,")
         .AppendLine("	V.IdTipoComprobanteFact,")
         .AppendLine("	V.LetraFact,")
         .AppendLine("	V.CentroEmisorFact,")
         .AppendLine("	V.NumeroComprobanteFact,")
         .AppendLine("	V.IdCaja,")
         .AppendLine("	V.NumeroPlanilla,")
         .AppendLine("	V.NumeroMovimiento,")
         .AppendLine("	V.ImportePesos,")
         .AppendLine("	V.ImporteTickets,")
         .AppendLine("	V.ImporteTarjetas,")
         .AppendLine("	V.ImporteCheques,")
         .AppendLine("	V.Kilos,")
         .AppendLine("	V.Bultos,")
         .AppendLine("	V.ValorDeclarado,")
         .AppendLine("	V.IdTransportista,")
         .AppendLine("	V.NumeroLote,")
         .AppendLine("	V.CAE,")
         .AppendLine("	V.CAEVencimiento,")
         .AppendLine("	V.Utilidad,")
         .AppendLine("	V.FechaTransmisionAFIP,")
         .AppendLine("	V.CotizacionDolar")
         '.AppendLine("  V.IdPeriodo")

         .AppendLine(" FROM Ventas V, Impresoras I")

         .AppendLine(" WHERE 1=2 ")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Function GetOrdenesProduccionDetalleComprobante(idSucursal As Integer,
                                                IdEstado As String,
                                                FechaDesde As Date,
                                                FechaHasta As Date,
                                                numeroOrdenProduccion As Long,
                                                idProducto As String,
                                                IdMarca As Integer,
                                                IdRubro As Integer,
                                                lote As String,
                                                IdCliente As Long,
                                                IdUsuario As String,
                                                Tamanio As Decimal,
                                                IdVendedor As Integer,
                                                OrdenCompra As Long) As DataTable


      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.IdSucursal ")
         .AppendLine(" ,P.IdTipoComprobante AS IdTipoComprobanteP")
         .AppendLine(" ,P.Letra AS LetraP")
         .AppendLine(" ,P.CentroEmisor AS CentroEmisorP")
         .AppendLine(" ,P.NumeroOrdenProduccion")
         .AppendLine(" ,PE.IdProducto")
         .AppendLine(" ,PE.FechaEstado")
         .AppendLine(" ,PE.Orden,")

         .AppendLine("	V.IdTipoComprobante,")
         .AppendLine("	V.Letra,")
         .AppendLine("	V.CentroEmisor,")
         .AppendLine("	V.NumeroComprobante,")
         .AppendLine("	V.Fecha,")
         .AppendLine("	V.IdCliente,")
         .AppendLine("	V.IdVendedor,")
         .AppendLine("	V.IdCategoriaFiscal,")
         .AppendLine("	V.IdFormasPago,")
         .AppendLine("	V.Observacion,")
         .AppendLine("	I.IdImpresora,")
         .AppendLine("	I.TipoImpresora,")
         .AppendLine("	V.ImporteBruto,")
         .AppendLine("	V.DescuentoRecargo,")
         .AppendLine("	V.DescuentoRecargoPorc,")
         .AppendLine("	V.SubTotal,")
         .AppendLine("	V.TotalImpuestos,")
         .AppendLine("	V.ImporteTotal,")
         .AppendLine("	V.IdEstadoComprobante,")
         '-- REQ-33175.- ---------------------------------
         '.AppendLine("	V.IdTipoComprobanteFact_viejo,")
         '.AppendLine("	V.LetraFact_viejo,")
         '.AppendLine("	V.CentroEmisorFact_viejo,")
         '.AppendLine("	V.NumeroComprobanteFact_viejo,")
         '------------------------------------------------
         .AppendLine("	V.IdCaja,")
         .AppendLine("	V.NumeroPlanilla,")
         .AppendLine("	V.NumeroMovimiento,")
         .AppendLine("	V.ImportePesos,")
         .AppendLine("	V.ImporteTickets,")
         .AppendLine("	V.ImporteTarjetas,")
         .AppendLine("	V.ImporteCheques,")
         .AppendLine("	V.Kilos,")
         .AppendLine("	V.Bultos,")
         .AppendLine("	V.ValorDeclarado,")
         .AppendLine("	V.IdTransportista,")
         .AppendLine("	V.NumeroLote,")
         .AppendLine("	V.CAE,")
         .AppendLine("	V.CAEVencimiento,")
         .AppendLine("	V.Utilidad,")
         .AppendLine("	V.FechaTransmisionAFIP,")
         .AppendLine("	V.CotizacionDolar")
         '.AppendLine("  V.IdPeriodo")

         .AppendLine(" FROM OrdenesProduccion P")
         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN Ventas V ON V.IdTipoComprobante = PE.IdTipoComprobanteFact")
         .AppendLine("                    AND V.Letra = PE.LetraFact")
         .AppendLine("                    AND V.CentroEmisor = PE.CentroEmisorFact")
         .AppendLine("                    AND V.NumeroComprobante = PE.NumeroComprobanteFact")
         .AppendLine(" INNER JOIN Impresoras I ON I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")

         .AppendLine(" WHERE p.IdSucursal = " & idSucursal.ToString())

         If IdEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf IdEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf IdEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstado.ToString() & "'")
         End If

         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaOrdenProduccion >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaOrdenProduccion <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroOrdenProduccion > 0 Then
            .AppendLine("   AND p.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         Else

            If IdCliente > 0 Then
               .AppendLine("   and C.IdCliente = " & IdCliente.ToString())
            End If

            If OrdenCompra > 0 Then
               .AppendLine("   AND P.NumeroOrdenCompra = " & OrdenCompra.ToString())
            End If

            If Not String.IsNullOrEmpty(IdUsuario) Then
               .AppendLine("    and p.IdUsuario = '" & IdUsuario & "'")
            End If

            If IdVendedor > 0 Then
               .AppendLine("   and C.IdVendedor = " & IdVendedor.ToString())
            End If

         End If


         '.AppendLine(" FROM Ventas V, Impresoras I")
         '.AppendLine(" WHERE I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")

         '.AppendLine("   AND V.IdSucursal = " & idSucursal.ToString())
         '.AppendLine("   AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         '.AppendLine("   AND V.Letra = '" & letra & "'")
         '.AppendLine("   AND V.CentroEmisor = " & centroEmisor.ToString())
         '.AppendLine("   AND V.NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetOrdenesProduccionDetalleComprobante(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Short,
                                                numeroComprobante As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.IdSucursal, ")
         .AppendLine("	V.IdTipoComprobante,")
         .AppendLine("	V.Letra,")
         .AppendLine("	V.CentroEmisor,")
         .AppendLine("	V.NumeroComprobante,")
         .AppendLine("	V.Fecha,")
         .AppendLine("	V.IdCliente,")
         .AppendLine("	V.IdVendedor,")
         .AppendLine("	V.IdCategoriaFiscal,")
         .AppendLine("	V.IdFormasPago,")
         .AppendLine("	V.Observacion,")
         .AppendLine("	I.IdImpresora,")
         .AppendLine("	I.TipoImpresora,")
         .AppendLine("	V.ImporteBruto,")
         .AppendLine("	V.DescuentoRecargo,")
         .AppendLine("	V.DescuentoRecargoPorc,")
         .AppendLine("	V.SubTotal,")
         .AppendLine("	V.TotalImpuestos,")
         .AppendLine("	V.ImporteTotal,")
         .AppendLine("	V.IdEstadoComprobante,")
         .AppendLine("	V.IdTipoComprobanteFact,")
         .AppendLine("	V.LetraFact,")
         .AppendLine("	V.CentroEmisorFact,")
         .AppendLine("	V.NumeroComprobanteFact,")
         .AppendLine("	V.IdCaja,")
         .AppendLine("	V.NumeroPlanilla,")
         .AppendLine("	V.NumeroMovimiento,")
         .AppendLine("	V.ImportePesos,")
         .AppendLine("	V.ImporteTickets,")
         .AppendLine("	V.ImporteTarjetas,")
         .AppendLine("	V.ImporteCheques,")
         .AppendLine("	V.Kilos,")
         .AppendLine("	V.Bultos,")
         .AppendLine("	V.ValorDeclarado,")
         .AppendLine("	V.IdTransportista,")
         .AppendLine("	V.NumeroLote,")
         .AppendLine("	V.CAE,")
         .AppendLine("	V.CAEVencimiento,")
         .AppendLine("	V.Utilidad,")
         .AppendLine("	V.FechaTransmisionAFIP,")
         .AppendLine("	V.CotizacionDolar")
         '.AppendLine("  V.IdPeriodo")

         .AppendLine(" FROM Ventas V, Impresoras I")

         .AppendLine(" WHERE I.CentroEmisor = V.CentroEmisor AND I.IdSucursal = V.IdSucursal")

         .AppendLine("   AND V.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND V.Letra = '" & letra & "'")
         .AppendLine("   AND V.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND V.NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetOrdenesProduccionxComprobante(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Short,
                                                numeroComprobante As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroOrdenProduccion ")
         .AppendLine(" FROM OrdenesProduccionEstados  ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobanteFact = '" & idTipoComprobante & "'")
         .AppendLine("   AND LetraFact = '" & letra & "'")
         .AppendLine("   AND CentroEmisorFact = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobanteFact = " & numeroComprobante.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetOrdenesProduccionDetalladoXEstadosTodos(idSucursal As Integer,
                                                              IdEstado As String,
                                                              FechaDesde As Date,
                                                              FechaHasta As Date,
                                                              numeroOrdenProduccion As Long,
                                                              idProducto As String,
                                                              IdMarca As Integer,
                                                              IdRubro As Integer,
                                                              lote As String,
                                                              IdCliente As Long,
                                                              IdUsuario As String,
                                                              Tamanio As Decimal,
                                                              IdVendedor As Integer,
                                                              OrdenCompra As Long,
                                                              idPlanMaestro As Integer,
                                                              fechaDesdePlan As Date?,
                                                              fechaHastaPlan As Date?) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .AppendLine("SELECT P.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroOrdenProduccion")
         .AppendLine("     , P.FechaOrdenProduccion")
         .AppendLine("     , P.IdCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , PP.idProducto")
         .AppendLine("     , PP.NombreProducto")
         .AppendLine("     , PR.Tamano")
         .AppendLine("     , PR.IdUnidadDeMedida")
         .AppendLine("     , PP.Orden")
         .AppendLine("     , PP.Cantidad")
         .AppendLine("     , PE.fechaEstado")
         .AppendLine("     , PE.IdEstado")
         .AppendLine("     , EP.IdTipoEstado")
         .AppendLine("     , (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         '.AppendLine("     , PE.CantEstado AS CantEntregada")
         .AppendLine("     , PE.CantEstado")
         .AppendLine("     , PE.IdTipoComprobanteFact")
         .AppendLine("     , PE.LetraFact")
         .AppendLine("     , PE.CentroEmisorFact")
         .AppendLine("     , PE.NumeroComprobanteFact")
         .AppendLine("     , PE.IdUsuario")
         .AppendLine("     , PE.observacion")
         .AppendLine("     , PE.IdCriticidad")
         .AppendLine("     , PE.FechaEntrega")
         .AppendLine("     , PE.PlanMaestroNumero")
         .AppendLine("     , PE.PlanMaestroFecha")

         .AppendLine(" FROM OrdenesProduccion P")
         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")

         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())

         If IdEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf IdEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf IdEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstado.ToString() & "'")
         End If

         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaOrdenProduccion >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaOrdenProduccion <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroOrdenProduccion > 0 Then
            .AppendLine("   AND p.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         End If

         If IdCliente > 0 Then
            .AppendLine("   and C.IdCliente = " & IdCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(IdUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & IdUsuario & "'")
         End If

         '-- Numero Plan Maestro Produccion.- ------------------------------------------------------------------------
         If idPlanMaestro > 0 Then
            .AppendFormatLine("   AND PE.PlanMaestroNumero = {0}", idPlanMaestro)
         End If
         '-- Fecha Plan Maestro Orden de Produccion.- -----------------------------------------------------------------------------
         If fechaDesdePlan.HasValue Then
            .AppendFormatLine("   AND PE.PlanMaestroFecha >= '{0}'", ObtenerFecha(fechaDesdePlan.Value, True))
            .AppendFormatLine("   AND PE.PlanMaestroFecha <= '{0}'", ObtenerFecha(fechaHastaPlan.Value, True))
         End If

         If OrdenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & OrdenCompra.ToString())
         End If

         If IdVendedor > 0 Then
            .AppendLine("   and C.IdVendedor = " & IdVendedor.ToString())
         End If

         .AppendLine(" ORDER BY p.fechaOrdenProduccion")

      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetOrdenesProduccionDetalladoXEstados(IdSucursal As Integer,
                                             IdEstado As String,
                                             FechaDesde As Date,
                                             FechaHasta As Date,
                                             numeroOrdenProduccion As Long,
                                             IdProducto As String,
                                             IdMarca As Integer,
                                             IdRubro As Integer,
                                             Lote As String,
                                             IdCliente As Long,
                                             IdIdUsuario As String,
                                             Tamanio As Decimal,
                                             IdVendedor As Integer,
                                             OrdenCompra As Long) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine(" ,P.IdTipoComprobante")
         .AppendLine(" ,P.Letra")
         .AppendLine(" ,P.CentroEmisor")
         .AppendLine(" ,P.NumeroOrdenProduccion")
         .AppendLine(" ,P.FechaOrdenProduccion")
         .AppendLine(" ,P.NumeroOrdenCompra")
         .AppendLine("      ,P.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano, Pr.IdUnidadDeMedida, pp.Orden, PS.Ubicacion")
         .AppendLine("      ,pp.Cantidad AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      ,PE.CantEstado AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN PE.CantEstado ELSE 0 END) AS CantPendiente")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")
         .AppendLine(" FROM OrdenesProduccion P")

         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" WHERE P.IdSucursal = " & IdSucursal.ToString())

         If IdEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf IdEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf IdEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstado.ToString() & "'")
         End If

         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaOrdenProduccion >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaOrdenProduccion <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroOrdenProduccion > 0 Then
            .AppendLine("   AND P.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         Else

            If Not String.IsNullOrEmpty(IdProducto) Then
               .AppendLine("   AND pp.IdProducto = '" & IdProducto & "'")
            End If

            If IdMarca > 0 Then
               .AppendLine("    and pr.IdMarca = " & IdMarca.ToString())
            End If

            If IdRubro > 0 Then
               .AppendLine("    and pr.IdRubro = " & IdRubro.ToString())
            End If

            If Not String.IsNullOrEmpty(Lote) Then
               .AppendLine("    and pr.Lote = " & Lote.ToString())
            End If

            If IdCliente > 0 Then
               .AppendLine("   and C.IdCliente = " & IdCliente) ''1'
            End If

            If Not String.IsNullOrEmpty(IdIdUsuario) Then
               .AppendLine("    and p.IdUsuario = '" & IdIdUsuario & "'")
            End If

            If Tamanio > 0 Then
               .AppendLine("    and pr.tamano = " & Tamanio.ToString())
            End If

            If OrdenCompra > 0 Then
               .AppendLine("   AND P.NumeroOrdenCompra = " & OrdenCompra.ToString())
            End If

            If IdVendedor > 0 Then
               .AppendLine("   and C.IdVendedor = " & IdVendedor.ToString()) ''COD'
            End If

         End If

         .AppendLine(" ORDER BY p.fechaOrdenProduccion")

      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetOrdenesProduccionEstadosProductos(IdSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Short,
                                                numeroOrdenProduccion As Long,
                                                IdProducto As String) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine(" ,P.IdTipoComprobante")
         .AppendLine(" ,P.Letra")
         .AppendLine(" ,P.CentroEmisor")
         .AppendLine(" ,P.NumeroOrdenProduccion")
         .AppendLine(" ,P.FechaOrdenProduccion")
         .AppendLine("      ,P.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano, Pr.IdUnidadDeMedida, pp.Orden")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE ")
         .AppendLine(" (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE PE.CantEntregada END) END) AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")
         .AppendLine(" FROM OrdenesProduccion P")

         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" WHERE P.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND P.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND P.Letra = '" & letra & "'")
         .AppendLine("   AND P.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND P.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         .AppendLine("   AND PE.IdProducto = '" & IdProducto & "'")
         .AppendLine(" ORDER BY p.fechaOrdenProduccion")

      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function OrdenesProduccionCabecera(IdSucursal As Integer,
                                 IdEstado As String,
                                 FechaDesde As Date,
                                 FechaHasta As Date,
                                 numeroOrdenProduccion As Long,
                                 IdCliente As Long,
                                 IdIdUsuario As String,
                                 IdVendedor As Integer,
                                 OrdenCompra As Long,
                                 idPlanMaestro As Integer,
                                 fechaDesdePlan As Date?,
                                 fechaHastaPlan As Date?) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT 'FALSE' as anula")
         .AppendLine("     , p.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroOrdenProduccion")
         .AppendLine("     , c.IdCliente")
         .AppendLine("     , c.CodigoCliente")
         .AppendLine("     , c.NombreCliente")
         .AppendLine("     , p.FechaOrdenProduccion")
         .AppendLine("     , p.IdUsuario")
         .AppendLine("     , p.Observacion")
         .AppendLine("     , p.NumeroOrdenCompra")
         .AppendLine("     , DATEDIFF(day, p.FechaOrdenProduccion,  GETDATE()) As DP")

         .AppendLine(" FROM OrdenesProduccion P")

         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")

         .AppendLine(" WHERE P.IdSucursal = " & IdSucursal.ToString())

         If IdEstado <> "TODOS" Then
            .AppendLine("   AND EXISTS(SELECT * FROM OrdenesProduccionEstados PE")
            .AppendLine("                      INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
            .AppendLine("                      WHERE PE.IdSucursal = P.IdSucursal")
            .AppendLine("                        AND PE.IdTipoComprobante = P.IdTipoComprobante")
            .AppendLine("                        AND PE.Letra = P.Letra")
            .AppendLine("                        AND PE.CentroEmisor = P.CentroEmisor")
            .AppendLine("                        AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
            '-- Numero Plan Maestro Produccion.- ------------------------------------------------------------------------
            If idPlanMaestro > 0 Then
               .AppendFormatLine("   AND PE.PlanMaestroNumero = {0}", idPlanMaestro)
            End If
            '-- Fecha Plan Maestro Orden de Produccion.- -------------------------------------------------------------
            If fechaDesdePlan.HasValue Then
               .AppendFormatLine("   AND PE.PlanMaestroFecha >= '{0}'", ObtenerFecha(fechaDesdePlan.Value, True))
               .AppendFormatLine("   AND PE.PlanMaestroFecha <= '{0}'", ObtenerFecha(fechaHastaPlan.Value, True))
            End If
            '----------------------------------------------------------------------------------------------------------

            If IdEstado = "SOLO PENDIENTES" Then
               .AppendLine("                        AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO'))")
            ElseIf IdEstado = "SOLO EN PROCESO" Then
               .AppendLine("                        AND EP.IdTipoEstado = 'EN PROCESO')")
            Else
               .AppendFormat("                        AND EP.IdEstado = '{0}')", IdEstado).AppendLine()
            End If
         End If

         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND P.FechaOrdenProduccion >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND P.FechaOrdenProduccion <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If numeroOrdenProduccion > 0 Then
            .AppendLine("   AND P.NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         End If

         If OrdenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & OrdenCompra.ToString())
         End If

         If IdCliente <> 0 Then
            .AppendLine("   and C.IdCliente = " & IdCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(IdIdUsuario) Then
            .AppendLine("    and P.IdUsuario = '" & IdIdUsuario & "'")
         End If

         If IdVendedor > 0 Then
            .AppendLine("   and C.IdVendedor = " & IdVendedor.ToString())
         End If
         .AppendLine(" ORDER BY P.fechaOrdenProduccion")

      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

#End Region

#Region "PROCESO FACTURA"

   Public Function GetOrdenesProduccionXClienteProducto(IdSucursal As Integer,
                                                IdEstado As String,
                                                IdProducto As String,
                                                IdCliente As Long,
                                                facturables As Entidades.Venta()) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroOrdenProduccion")
         .AppendLine("      ,P.FechaOrdenProduccion")
         .AppendLine("      ,P.IdCliente ")
         .AppendLine("      ,pp.idProducto, pp.orden")
         .AppendLine("      ,pp.Cantidad")
         .AppendLine("      , pe.idEstado ")
         .AppendLine("      ,pe.CantEstado AS CantEntregada ")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' OR EP.IdTipoEstado = 'EN PROCESO' THEN pe.CantEstado ELSE 0 END) AS CantPendiente ")
         .AppendLine("      ,pe.IdTipoComprobanteFact ")
         .AppendLine("      ,pe.LetraFact ")
         .AppendLine("      ,pe.CentroEmisorFact ")
         .AppendLine("      ,pe.NumeroComprobanteFact ")
         .AppendLine("      ,pe.FechaEstado ")
         .AppendLine("      ,pe.IdCriticidad")
         .AppendLine("      ,pe.FechaEntrega")
         .AppendLine(" FROM OrdenesProduccion P ")

         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto ")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")

         .AppendLine(" WHERE p.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND p.IdCliente=" & IdCliente)
         .AppendLine("   AND pp.IdProducto = '" & IdProducto & "'")
         .AppendLine("   AND pe.IdEstado = '" & IdEstado.ToString() & "'")

         If facturables IsNot Nothing AndAlso facturables.Length > 0 Then
            .Append("   AND (1 = 2 ")
            For Each OrdenProduccion As Entidades.Venta In facturables
               .AppendFormat("OR (PE.IdTipoComprobante = '{0}' AND PE.Letra = '{1}' AND PE.CentroEmisor = {2} AND PE.NumeroOrdenProduccion = {3})",
                              OrdenProduccion.IdTipoComprobante, OrdenProduccion.LetraComprobante, OrdenProduccion.CentroEmisor, OrdenProduccion.NumeroComprobante)
            Next
            .AppendLine(")")
         End If

         .AppendLine(" ORDER BY p.fechaOrdenProduccion ")

      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetOrdenesProduccionSumaPorProductos(IdSucursal As Integer,
                                             IdEstado As String,
                                             FechaDesde As Date,
                                             FechaHasta As Date,
                                             IdCliente As Long,
                                             IdVendedor As Integer,
                                             IdMarca As Integer,
                                             IdRubro As Integer,
                                             IdSubRubro As Integer,
                                             IdProducto As String,
                                             Tamanio As Decimal,
                                             OrdenCompra As Decimal) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.Tamano, Pr.IdUnidadDeMedida")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,SUM(PE.CantEstado) AS Cantidad")
         .AppendLine("      ,SUM(PE.CantEstado * Pr.Kilos) AS Kilos")
         .AppendLine(" FROM OrdenesProduccion P")

         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PR.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" WHERE PE.IdSucursal = " & IdSucursal.ToString())

         If IdEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf IdEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf IdEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstado.ToString() & "'")
         End If

         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaOrdenProduccion >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaOrdenProduccion <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If IdCliente > 0 Then
            .AppendLine("   and C.IdCliente = " & IdCliente.ToString())
         End If

         If IdVendedor > 0 Then
            .AppendLine("   and C.IdVendedor = " & IdVendedor.ToString()) ''COD'
         End If

         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & IdProducto & "'")
         End If

         If IdMarca <> 0 Then
            .AppendLine("    and pr.IdMarca = " & IdMarca.ToString())
         End If

         If IdRubro <> 0 Then
            .AppendLine("    and pr.IdRubro = " & IdRubro.ToString())
         End If

         If Tamanio > 0 Then
            .AppendLine("    and pr.Tamano = " & Tamanio.ToString())
         End If

         If OrdenCompra > 0 Then
            .AppendLine("   AND P.NumeroOrdenCompra = " & OrdenCompra.ToString())
         End If

         .AppendLine(" GROUP BY M.NombreMarca, R.NombreRubro, pp.idProducto, pp.NombreProducto, pr.Tamano, Pr.IdUnidadDeMedida, PS.Stock")
         .AppendLine(" ORDER BY pp.NombreProducto, pp.idProducto")
      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

#End Region

   Public Function VerificaOrdenProduccionModificable(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .Length = 0
         .AppendLine("SELECT (SELECT COUNT(1) FROM OrdenesProduccionProductos AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion) AS OrdenesProduccionProductos")
         .AppendLine("      ,(SELECT COUNT(1) FROM OrdenesProduccionEstados   AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion) AS OrdenesProduccionEstados")
         .AppendLine("      ,(SELECT COUNT(1) FROM OrdenesProduccionEstados   AS PP WHERE PP.IdSucursal = P.IdSucursal AND PP.IdTipoComprobante = P.IdTipoComprobante AND PP.Letra = P.Letra AND PP.CentroEmisor = P.CentroEmisor AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                                                      AND PP.IdEstado <> EP.idEstado) AS OrdenesProduccionEstadosNoPendientes")
         .AppendLine("  FROM OrdenesProduccion AS P")
         .AppendLine(" CROSS JOIN EstadosOrdenesProduccion AS EP")
         .AppendFormat(" WHERE P.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND P.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND P.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND P.NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()
         .AppendLine("   AND EP.IdTipoEstado = 'PENDIENTE'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Function VerificaOrdenProduccionParaAnularAsignacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT IdSucursal, NumeroOrdenProduccion FROM OrdenesProduccionMRPOperaciones OPO")
         .AppendFormat(" WHERE OPO.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND OPO.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND OPO.LetraComprobante = '{0}'", letra).AppendLine()
         .AppendFormat("   AND OPO.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND OPO.NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()
         .AppendLine("     AND OPO.IdEstadoTarea <> 'PENDIENTE'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function VerificaOrdenProduccionParaAnularNovedades(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT IdSucursal, NumeroOrdenProduccion FROM NovedadesProduccionMRP NPM")
         .AppendFormat(" WHERE NPM.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND NPM.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND NPM.LetraComprobante = '{0}'", letra).AppendLine()
         .AppendFormat("   AND NPM.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NPM.NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetOrdenProduccion(idTipoComprobante As String, letra As String, centroEmisor As Short?, numeroOrdenProduccion As Long?,
                              idCliente As Long?, fechaPed As DateTime?,
                              ordenCompra As Long?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT * FROM OrdenesProduccion AS P")
         .AppendFormat(" WHERE 1 = 1", idCliente).AppendLine()
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND P.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor.HasValue AndAlso centroEmisor.Value <> 0 Then
            .AppendFormat("   AND P.CentroEmisor = {0}", centroEmisor.Value).AppendLine()
         End If
         If numeroOrdenProduccion.HasValue AndAlso numeroOrdenProduccion.Value <> 0 Then
            .AppendFormat("   AND P.NumeroOrdenProduccion = {0}", numeroOrdenProduccion.Value).AppendLine()
         End If

         If idCliente.HasValue AndAlso idCliente.Value <> 0 Then
            .AppendFormat("   AND P.IdCliente = {0}", idCliente.Value).AppendLine()
         End If

         If ordenCompra.HasValue AndAlso ordenCompra.Value <> 0 Then
            .AppendFormat("   AND P.NumeroOrdenCompra = {0}", ordenCompra.Value).AppendLine()
         End If

         If fechaPed.HasValue Then
            .AppendFormat("   AND P.FechaOrdenProduccion = '{0}'", ObtenerFecha(fechaPed.Value, True)).AppendLine()
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ExisteOrdenProduccion(idCliente As Long, fechaPed As DateTime) As Boolean
      Return GetOrdenProduccion(String.Empty, String.Empty, Nothing, Nothing, idCliente, fechaPed, Nothing).Rows.Count > 0
   End Function

   Public Function ExisteOrdenProduccion(numeroOrdenProduccion As Long) As Boolean
      Return ExisteOrdenProduccion("OrdenProduccionPDA", numeroOrdenProduccion)
   End Function

   Public Function ExisteOrdenProduccion(idTipoComprobante As String, numeroOrdenProduccion As Long) As Boolean
      Return GetOrdenProduccion(idTipoComprobante, String.Empty, Nothing, numeroOrdenProduccion, Nothing, Nothing, Nothing).Rows.Count > 0
   End Function

   Public Function ExisteOrdenProduccion(idTipoComprobante As String, idCliente As Long, ordenCompra As Long) As Boolean
      Return GetOrdenProduccion(idTipoComprobante, String.Empty, Nothing, Nothing, idCliente, Nothing, ordenCompra).Rows.Count > 0
   End Function

   Public Function GetOrdenesProduccionDetalladoXEstados(IdSucursal As Integer,
                                              IdEstado As String,
                                              FechaDesde As Date,
                                              FechaHasta As Date,
                                              FechaDesdeEntrega As Date?,
                                              FechaHastaEntrega As Date?,
                                              numeroPedido As Long,
                                              IdProducto As String,
                                              IdMarca As Integer,
                                              IdRubro As Integer,
                                              Lote As String,
                                              IdCliente As Long,
                                              IdIdUsuario As String,
                                              Tamanio As Decimal,
                                              IdVendedor As Integer,
                                              OrdenCompra As Long,
                                              tipoTipoComprobante As String,
                                              tiposComprobante As Entidades.TipoComprobante(),
                                              espPulgadas As String,
                                              espmm As Decimal?,
                                              sae As Integer?,
                                              idProceso As Integer,
                                              IdProveedor As Long) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT PE.IdSucursal")
         .AppendLine("     , P.IdTipoComprobante")
         .AppendLine("     , P.Letra")
         .AppendLine("     , P.CentroEmisor")
         .AppendLine("     , P.NumeroOrdenProduccion")
         .AppendLine("     , P.FechaOrdenProduccion")
         .AppendLine("     , P.NumeroOrdenCompra")
         .AppendLine("     , P.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine("     , PE.IdEstado")
         .AppendLine("     , PP.IdProducto, PP.NombreProducto")
         .AppendLine("     , PE.IdCriticidad")
         .AppendLine("     , PE.FechaEntrega")
         .AppendLine("     , PP.Cantidad AS Cantidad")
         .AppendLine("     , PE.FechaEstado")
         .AppendLine("     , PE.CantEstado AS CantEntregada")

         .AppendLine("     , (PP.Costo * PE.CantEstado) AS Costo")
         .AppendLine("     , (PP.ImporteTotalNeto / PP.Cantidad * PE.CantEstado) AS SubTotal")
         .AppendLine("     , (PP.ImporteImpuestoInterno / PP.Cantidad * PE.CantEstado) AS TotalImpuestoInterno")
         .AppendLine("     , (PP.ImporteImpuesto / PP.Cantidad * PE.CantEstado) AS TotalImpuestos")
         .AppendLine("     , (PP.ImporteTotalNeto + PP.ImporteImpuestoInterno + PP.ImporteImpuesto / PP.Cantidad * PE.CantEstado) AS ImporteTotal")
         .AppendLine("    	, P.CotizacionDolar")

         .AppendLine("     , PR.Tamano AS TamanoProducto")
         .AppendLine("     , PR.Tamano")
         .AppendLine("     , CONVERT(DECIMAL(9,2), PR.Tamano * PP.Cantidad) TamanoTotal")

         .AppendLine("     , PR.IdUnidadDeMedida")
         .AppendLine("     , PR.IdUnidadDeMedida AS IdUnidadDeMedidaProducto")
         .AppendLine("     , PS.Stock")
         .AppendLine("     , PE.IdTipoComprobanteFact, PE.LetraFact, PE.CentroEmisorFact, pe.NumeroComprobanteFact")

         .AppendLine("     , PE.IdUsuario")
         .AppendLine("     , PE.Observacion")


         .AppendLine("     , PP.IdProduccionProceso")
         .AppendLine("     , PRP.NombreProduccionProceso")
         .AppendLine("     , PP.IdProduccionForma")
         .AppendLine("     , PRF.NombreProduccionForma")

         .AppendLine("     , PP.Espmm")
         '.AppendLine("     , PP.EspPulgadas")
         .AppendLine("     , PP.CodigoSAE")
         .AppendLine("     , PP.LargoExtAlto")
         .AppendLine("     , PP.AnchoIntBase")
         .AppendLine("     , PP.UrlPlano")
         .AppendLine("     , PP.IdFormula")
         .AppendLine("     , PF.NombreFormula")

         .AppendLine("     , pp.Orden")
         .AppendLine("     , PS.Ubicacion")
         .AppendLine("     , EP.Color")
         .AppendLine("     , P.Observacion as ObservacionOP")
         .AppendLine("     , PP.IdSucursalPedido
	                        , PP.IdTipoComprobantePedido
	                        , PP.CentroEmisorPedido
	                        , PP.NumeroPedido
	                        , PP.IdProductoPedido
	                        , PP.OrdenPedido")

         .AppendLine(" FROM OrdenesProduccion P")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = P.IdTipoComprobante")

         .AppendLine(" INNER JOIN OrdenesProduccionProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine(" INNER JOIN OrdenesProduccionEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroOrdenProduccion = P.NumeroOrdenProduccion")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosOrdenesProduccion EP ON EP.IdEstado = PE.IdEstado")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = PP.IdProduccionForma")
         .AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = PP.IdProduccionProceso")
         '.AppendLine(" LEFT JOIN Monedas MO ON MO.IdMoneda = PP.IdMoneda")
         '.AppendLine(" LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = P.NumeroOrdenCompra")
         .AppendLine(" LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
         .AppendLine(" WHERE P.IdSucursal = " & IdSucursal.ToString())
         .AppendFormat("   AND TC.Tipo = '{0}'", tipoTipoComprobante).AppendLine()

         GetListaTiposComprobantesMultiples(stbQuery, tiposComprobante, "P")

         If IdEstado = "SOLO PENDIENTES" Then
            .AppendLine("   AND EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO')")
         ElseIf IdEstado = "SOLO EN PROCESO" Then
            .AppendLine("   AND EP.IdTipoEstado = 'EN PROCESO'")
         ElseIf IdEstado <> "TODOS" Then
            .AppendLine("   AND PE.IdEstado = '" & IdEstado.ToString() & "'")
         End If

         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND p.FechaOrdenProduccion >= '" & FechaDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("   AND p.FechaOrdenProduccion <= '" & FechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         'If FechaDesdeEntrega.HasValue Then
         '   .AppendFormat("   AND p.FechaPedido >= '{0}'", ObtenerFecha(FechaDesdeEntrega.Value, True))
         '   .AppendFormat("   AND p.FechaPedido <= '{0}'", ObtenerFecha(FechaHastaEntrega.Value, True))
         'End If

         If numeroPedido > 0 Then
            .AppendLine("   AND P.NumeroOrdenProduccion = " & numeroPedido.ToString())
         End If

         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("   AND pp.IdProducto = '" & IdProducto & "'")
         End If

         If IdMarca > 0 Then
            .AppendLine("    and pr.IdMarca = " & IdMarca.ToString())
         End If

         If IdRubro > 0 Then
            .AppendLine("    and pr.IdRubro = " & IdRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(Lote) Then
            .AppendLine("    and pr.Lote = " & Lote.ToString())
         End If

         If IdCliente > 0 Then
            .AppendLine("   and C.IdCliente = " & IdCliente) ''1'
         End If

         'If IdProveedor <> 0 Then
         '   .AppendLine("   and OC.IdProveedor = " & IdProveedor.ToString())
         'End If

         If Not String.IsNullOrEmpty(IdIdUsuario) Then
            .AppendLine("    and p.IdUsuario = '" & IdIdUsuario & "'")
         End If

         'If Tamanio > 0 Then
         '   .AppendLine("    and pr.tamano = " & Tamanio.ToString())
         'End If

         'If OrdenCompra > 0 Then
         '   .AppendLine("   AND P.NumeroOrdenCompra = " & OrdenCompra.ToString())
         'End If

         If IdVendedor > 0 Then
            .AppendLine("   and C.IdVendedor = " & IdVendedor.ToString()) ''COD'
         End If

         'If Not String.IsNullOrWhiteSpace(espPulgadas) Then
         '   .AppendFormat("   AND PP.EspPulgadas = '{0}'", espPulgadas)
         'End If

         'If espmm.HasValue Then
         '   .AppendFormat("   AND PP.Espmm = {0}", espmm.Value)
         'End If

         'If sae.HasValue Then
         '   .AppendFormat("   AND PP.CodigoSAE = {0}", sae.Value)
         'End If

         'If idProceso > 0 Then
         '   .AppendFormat("   AND PP.IdProduccionProceso = {0}", idProceso)
         'End If


         .AppendLine(" ORDER BY p.FechaOrdenProduccion")

      End With

      Return GetDataTable(stbQuery)

   End Function

End Class
