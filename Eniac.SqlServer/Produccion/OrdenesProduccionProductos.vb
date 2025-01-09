Public Class OrdenesProduccionProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub


   Public Sub OrdenesProduccionProductos_I(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroOrdenProduccion As Long,
                                           idProducto As String,
                                           cantidad As Decimal,
                                           precio As Decimal,
                                           precioLista As Decimal,
                                           costo As Decimal,
                                           importeTotal As Decimal,
                                           nombreProducto As String,
                                           cantPendiente As Decimal,
                                           cantEntregada As Decimal,
                                           cantEnProceso As Decimal,
                                           cantAnulada As Decimal,
                                           DescuentoRecargoProducto As Double,
                                           DescuentoRecargoPorc1 As Double,
                                           DescuentoRecargoPorc2 As Double,
                                           IdTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                           AlicuotaImpuesto As Decimal,
                                           ImporteImpuesto As Decimal,
                                           Orden As Integer,
                                           FechaActualizacion As Date,
                                           idListaPrecios As Integer,
                                           nombreListaPrecios As String,
                                           importeImpuestoInterno As Decimal,
                                           precioNeto As Decimal,
                                           importeTotalNeto As Decimal,
                                           descRecGeneral As Decimal,
                                           descRecGeneralProducto As Decimal,
                                           kilos As Decimal,
                                           idCriticidad As String,
                                           fechaEntrega As Date,
                                           idFormula As Integer,
                                           idProduccionProceso As Integer,
                                           idProduccionForma As Integer,
                                           espmm As Decimal,
                                           espPies As String,
                                           codigoSAE As String,
                                           largoExtAlto As Decimal,
                                           anchoIntBase As Decimal,
                                           architrave As Decimal,
                                           idProduccionModeloForma As Integer,
                                           urlPlano As String,
                                           idResponsable As Integer,
                                           idProcesoProductivo As Long,
                                           idSucursalPedido As Integer,
                                           idTipoComprobantePedido As String,
                                           letraPedido As String,
                                           centroEmisorPedido As Integer,
                                           numeroPedido As Integer,
                                           idProductoPedido As String,
                                           ordenPedido As Integer)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO OrdenesProduccionProductos")
         .AppendFormat("           (IdSucursal").AppendLine()
         .AppendFormat("           ,IdTipoComprobante").AppendLine()
         .AppendFormat("           ,Letra").AppendLine()
         .AppendFormat("           ,CentroEmisor").AppendLine()
         .AppendFormat("           ,NumeroOrdenProduccion").AppendLine()
         .AppendFormat("           ,idProducto").AppendLine()
         .AppendFormat("           ,cantidad").AppendLine()
         .AppendFormat("           ,precio").AppendLine()
         .AppendFormat("           ,precioLista").AppendLine()
         .AppendFormat("           ,costo").AppendLine()
         .AppendFormat("           ,importeTotal").AppendLine()
         .AppendFormat("           ,nombreProducto").AppendLine()

         .AppendFormat("           ,cantPendiente").AppendLine()
         .AppendFormat("           ,cantEntregada").AppendLine()
         .AppendFormat("           ,cantEnProceso").AppendLine()
         .AppendFormat("           ,cantAnulada").AppendLine()

         .AppendFormat("           ,DescuentoRecargoProducto").AppendLine()
         .AppendFormat("           ,DescuentoRecargoPorc").AppendLine()
         .AppendFormat("           ,DescuentoRecargoPorc2").AppendLine()
         .AppendFormat("           ,IdTipoImpuesto").AppendLine()
         .AppendFormat("           ,AlicuotaImpuesto").AppendLine()
         .AppendFormat("           ,ImporteImpuesto").AppendLine()
         .AppendFormat("           ,Orden").AppendLine()
         .AppendFormat("           ,FechaActualizacion").AppendLine()
         .AppendFormat("           ,IdListaPrecios").AppendLine()
         .AppendFormat("           ,NombreListaPrecios").AppendLine()

         .AppendFormat("           ,ImporteImpuestoInterno").AppendLine()
         .AppendFormat("           ,PrecioNeto").AppendLine()
         .AppendFormat("           ,ImporteTotalNeto").AppendLine()
         .AppendFormat("           ,DescRecGeneral").AppendLine()
         .AppendFormat("           ,DescRecGeneralProducto").AppendLine()
         .AppendFormat("           ,Kilos").AppendLine()
         .AppendFormat("           ,IdCriticidad").AppendLine()
         .AppendFormat("           ,FechaEntrega").AppendLine()
         .AppendFormat("           ,IdFormula").AppendLine()

         .AppendFormat("           ,IdProduccionProceso").AppendLine()
         .AppendFormat("           ,IdProduccionForma").AppendLine()
         .AppendFormat("           ,Espmm").AppendLine()
         .AppendFormat("           ,EspPies").AppendLine()
         .AppendFormat("           ,CodigoSAE").AppendLine()
         .AppendFormat("           ,LargoExtAlto").AppendLine()
         .AppendFormat("           ,AnchoIntBase").AppendLine()
         .AppendFormat("           ,Architrave").AppendLine()
         .AppendFormat("           ,IdProduccionModeloForma").AppendLine()
         .AppendFormat("           ,UrlPlano").AppendLine()
         .AppendFormat("           ,IdResponsable").AppendLine()
         .AppendFormatLine("       ,IdProcesoProductivo")
         '-- 
         .AppendFormat("           ,IdSucursalPedido ").AppendLine()
         .AppendFormat("           ,IdTipoComprobantePedido ").AppendLine()
         .AppendFormat("           ,LetraPedido ").AppendLine()
         .AppendFormat("           ,CentroEmisorPedido ").AppendLine()
         .AppendFormat("           ,NumeroPedido ").AppendLine()
         .AppendFormat("           ,IdProductoPedido ").AppendLine()
         .AppendFormat("           ,OrdenPedido ").AppendLine()
         '--

         .AppendFormat(" ) VALUES (").AppendLine()
         .AppendFormat("            {0} ", idSucursal).AppendLine()
         .AppendFormat("          ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("          ,'{0}'", letra).AppendLine()
         .AppendFormat("          , {0} ", centroEmisor).AppendLine()
         .AppendFormat("          , {0} ", numeroOrdenProduccion).AppendLine()
         .AppendFormat("          ,'{0}'", idProducto).AppendLine()
         .AppendFormat("          , {0} ", cantidad).AppendLine()
         .AppendFormat("          , {0} ", precio).AppendLine()
         .AppendFormat("          , {0} ", precioLista).AppendLine()
         .AppendFormat("          , {0} ", costo).AppendLine()
         .AppendFormat("          , {0} ", importeTotal).AppendLine()
         .AppendFormat("          ,'{0}'", nombreProducto).AppendLine()

         .AppendFormat("          , {0} ", cantPendiente).AppendLine()
         .AppendFormat("          , {0} ", cantEntregada).AppendLine()
         .AppendFormat("          , {0} ", cantEnProceso).AppendLine()
         .AppendFormat("          , {0} ", cantAnulada).AppendLine()

         .AppendFormat("          , {0} ", DescuentoRecargoProducto.ToString()).AppendLine()
         .AppendFormat("          , {0} ", DescuentoRecargoPorc1.ToString()).AppendLine()
         .AppendFormat("          , {0} ", DescuentoRecargoPorc2.ToString()).AppendLine()
         .AppendFormat("          ,'{0}'", IdTipoImpuesto.ToString()).AppendLine()
         .AppendFormat("          , {0} ", AlicuotaImpuesto).AppendLine()
         .AppendFormat("          , {0} ", ImporteImpuesto).AppendLine()
         .AppendFormat("          , {0} ", Orden).AppendLine()
         .AppendFormat("          ,'{0}'", ObtenerFecha(FechaActualizacion, True))
         .AppendFormat("          , {0} ", idListaPrecios).AppendLine()
         .AppendFormat("          ,'{0}'", nombreListaPrecios).AppendLine()
         .AppendFormat("          , {0} ", importeImpuestoInterno).AppendLine()
         .AppendFormat("          , {0} ", precioNeto).AppendLine()
         .AppendFormat("          , {0} ", importeTotalNeto).AppendLine()
         .AppendFormat("          , {0} ", descRecGeneral).AppendLine()
         .AppendFormat("          , {0} ", descRecGeneralProducto).AppendLine()
         .AppendFormat("          , {0} ", kilos).AppendLine()

         .AppendFormat("          ,'{0}'", idCriticidad).AppendLine()
         .AppendFormat("          ,'{0}'", ObtenerFecha(fechaEntrega, True)).AppendLine()

         If idFormula > 0 Then
            .AppendFormat("          ,{0}", idFormula).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If

         If idProduccionProceso > 0 Then
            .AppendFormat("          ,{0}", idProduccionProceso).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         If idProduccionForma > 0 Then
            .AppendFormat("          ,{0}", idProduccionForma).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         If espmm > 0 Then
            .AppendFormat("          ,{0}", espmm).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(espPies) Then
            .AppendFormat("          ,'{0}'", espPies).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         If codigoSAE <> "" Then
            .AppendFormat("          ,'{0}'", codigoSAE).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         If largoExtAlto > 0 Then
            .AppendFormat("          ,{0}", largoExtAlto).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         If anchoIntBase > 0 Then
            .AppendFormat("          ,{0}", anchoIntBase).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         .AppendFormatLine("          ,{0}", GetStringFromDecimal(architrave))
         .AppendFormatLine("          ,{0}", GetStringFromNumber(idProduccionModeloForma))
         If Not String.IsNullOrWhiteSpace(urlPlano) Then
            .AppendFormat("          ,'{0}'", urlPlano).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If
         .AppendFormat("          ,{0}", idResponsable).AppendLine()

         .AppendFormatLine("          ,{0}", GetStringFromNumber(idProcesoProductivo))
         '--
         If idSucursalPedido > 0 Then
            .AppendFormat("          ,{0}", idSucursalPedido).AppendLine()
            .AppendFormat("          ,'{0}'", idTipoComprobantePedido).AppendLine()
            .AppendFormat("          ,'{0}'", letraPedido).AppendLine()
            .AppendFormat("          ,{0}", centroEmisorPedido).AppendLine()
            .AppendFormat("          ,{0}", numeroPedido).AppendLine()
            .AppendFormat("          ,'{0}'", idProductoPedido).AppendLine()
            .AppendFormat("          ,{0}", ordenPedido).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
            .AppendFormat("          ,NULL").AppendLine()
            .AppendFormat("          ,NULL").AppendLine()
            .AppendFormat("          ,NULL").AppendLine()
            .AppendFormat("          ,NULL").AppendLine()
            .AppendFormat("          ,NULL").AppendLine()
            .AppendFormat("          ,NULL").AppendLine()
         End If
         '--

         .AppendFormat(")").AppendLine()
      End With

      Execute(myQuery)

   End Sub




   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PP.* ")
         .AppendFormatLine("      ,PS.Stock")
         .AppendFormatLine("      ,PRP.NombreProduccionProceso")
         .AppendFormatLine("      ,PRF.NombreProduccionForma")
         .AppendFormatLine("      ,PF.NombreFormula")
         .AppendFormatLine("      ,E.NombreEmpleado AS NombreResponsable")
         .AppendFormatLine("      ,PrPr.IdProcesoProductivo")
         .AppendFormatLine("      ,PrPr.CodigoProcesoProductivo")
         .AppendFormatLine("      ,PrPr.DescripcionProceso DescripcionProcesoProductivo")
         .AppendFormatLine("  FROM OrdenesProduccionProductos PP")
         .AppendFormatLine("     INNER JOIN ProductosSucursales PS ON PS.IdProducto = PP.IdProducto AND PS.IdSucursal = {0}", actual.Sucursal.IdSucursal)
         .AppendFormatLine("     LEFT JOIN OrdenesProduccionMRP OPMRP ON OPMRP.IdSucursal = PP.IdSucursal AND OPMRP.IdTipoComprobante = PP.IdTipoComprobante AND OPMRP.LetraComprobante = PP.Letra AND OPMRP.CentroEmisor = PP.CentroEmisor AND OPMRP.NumeroOrdenProduccion = PP.NumeroOrdenProduccion AND OPMRP.IdProducto = PP.IdProducto AND OPMRP.ORDEN = PP.ORDEN ")
         .AppendFormatLine("     LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = PP.IdProduccionForma")
         .AppendFormatLine("     LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = PP.IdProduccionProceso")
         .AppendFormatLine("     LEFT JOIN ProductosFormulas PF ON PF.IdProducto = PP.IdProducto AND PF.IdFormula = PP.IdFormula")
         .AppendFormatLine("     LEFT JOIN Empleados E ON PP.IdResponsable = E.IdEmpleado ")
         .AppendFormatLine("     LEFT JOIN MRPProcesosProductivos PrPr ON PrPr.IdProcesoProductivo = OPMRP.IdProcesoProductivo")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PP.")
   End Function

   Public Sub OrdenesProduccionProductos_D(IdSucursal As Integer,
                                 IdTipoComprobante As String, Letra As String,
                                 CentroEmisor As Integer, NumeroOrdenProduccion As Long,
                                 Orden As Integer?, IdProducto As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendFormat("DELETE FROM OrdenesProduccionProductos").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", IdSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", Letra)
         .AppendFormat("   AND CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("   AND NumeroOrdenProduccion = {0}", NumeroOrdenProduccion)
         If Orden.HasValue Then
            .AppendFormat("   AND Orden = {0}", Orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(IdProducto) Then
            .AppendFormat("   AND IdProducto = '{0}'", IdProducto)
         End If
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Function OrdenesProduccionProductos_GA() As DataTable
      Return OrdenesProduccionProductos_G(Nothing, String.Empty, String.Empty, Nothing, Nothing, Nothing, String.Empty) ', fechaEstado:=Nothing)
   End Function

   Public Function OrdenesProduccionProductos_GA(idSucursal As Integer?,
                                                 idTipoComprobante As String, letra As String, centroEmisor As Integer?, numeroOrdenProduccion As Long?) As DataTable
      Return OrdenesProduccionProductos_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, Nothing, String.Empty) ', fechaEstado:=Nothing)
   End Function

   Public Function OrdenesProduccionProductos_G1(idSucursal As Integer,
                                                 idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                 orden As Integer, idProducto As String) As DataTable ', fechaEstado As Date?) As DataTable
      Return OrdenesProduccionProductos_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden, idProducto) ', fechaEstado)
   End Function

   Private Function OrdenesProduccionProductos_G(idSucursal As Integer?,
                                       idTipoComprobante As String, letra As String, centroEmisor As Integer?, numeroOrdenProduccion As Long?,
                                       orden As Integer?, idProducto As String) As DataTable ', fechaEstado As Date?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal.HasValue Then
            .AppendFormatLine("   AND PP.IdSucursal = {0}", idSucursal.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND PP.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND PP.Letra = '{0}'", letra)
         End If
         If centroEmisor.HasValue Then
            .AppendFormatLine("   AND PP.CentroEmisor = {0}", centroEmisor.Value)
         End If
         If numeroOrdenProduccion.HasValue Then
            .AppendFormatLine("   AND PP.NumeroOrdenProduccion = {0}", numeroOrdenProduccion.Value)
         End If
         If orden.HasValue Then
            .AppendFormatLine("   AND PP.Orden = {0}", orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND PP.IdProducto = '{0}'", idProducto)
         End If
         'If fechaEstado.HasValue Then
         '   .AppendFormatLine("   AND PP.FechaEstado = '{0}'", ObtenerFecha(fechaEstado.Value, True))
         'End If

         .AppendFormatLine(" ORDER BY PP.IdSucursal, PP.IdTipoComprobante, PP.Letra, PP.CentroEmisor, PP.NumeroOrdenProduccion, PP.Orden, PP.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub ActualizarCantidades(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Integer,
                                   numeroOrdenProduccion As Long,
                                   idProducto As String,
                                   orden As Integer,
                                   deltaCantidadPendiente As Decimal,
                                   deltaCantidadEnProceso As Decimal,
                                   deltaCantidadEntregada As Decimal,
                                   deltaCantidadAnulada As Decimal)
      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery
         .Length = 0
         .AppendLine("UPDATE OrdenesProduccionProductos")
         .AppendLine("   SET Cantidad = Cantidad")
         .AppendFormat("     , CantPendiente = CantPendiente + {0}", deltaCantidadPendiente).AppendLine()
         .AppendFormat("     , CantEnProceso = CantEnProceso + {0}", deltaCantidadEnProceso).AppendLine()
         .AppendFormat("     , CantEntregada = CantEntregada + {0}", deltaCantidadEntregada).AppendLine()
         .AppendFormat("     , CantAnulada   = CantAnulada   + {0}", deltaCantidadAnulada).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
      End With

      Me.Execute(stbQuery.ToString())
   End Sub



   'Public Sub ActualizarCantidadEnProceso(idSucursal As Integer,
   '                                       idTipoComprobante As String,
   '                                       letra As String,
   '                                       centroEmisor As Integer,
   '                                       numeroOrdenProduccion As Long,
   '                                       idProducto As String,
   '                                       Cantidad As Decimal,
   '                                       Orden As Integer)

   '   Dim stbQuery As StringBuilder = New StringBuilder("")

   '   With stbQuery
   '      .Length = 0
   '      .AppendLine("UPDATE OrdenesProduccionProductos")
   '      .AppendLine("   SET CantEnProceso = CantEnProceso + " & Cantidad.ToString)
   '      .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
   '      .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
   '      .AppendLine("   AND Letra = '" & letra.ToString() & "'")
   '      .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
   '      .AppendLine("   AND NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
   '      .AppendLine("   AND IdProducto = '" & idProducto & "'")
   '      .AppendLine("   AND Orden = " & Orden.ToString)
   '   End With

   '   Me.Execute(stbQuery.ToString())

   'End Sub

   'Public Sub ActualizarCantidadEntregada(idSucursal As Integer,
   '                                       idTipoComprobante As String,
   '                                       letra As String,
   '                                       centroEmisor As Integer,
   '                                       numeroOrdenProduccion As Long,
   '                                       idProducto As String,
   '                                       Cantidad As Decimal,
   '                                       orden As Integer)

   '   Dim stbQuery As StringBuilder = New StringBuilder("")

   '   With stbQuery
   '      .Length = 0
   '      .AppendLine("UPDATE OrdenesProduccionProductos")
   '      .AppendLine("   SET CantEntregada = CantEntregada + " & Cantidad.ToString())
   '      .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
   '      .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
   '      .AppendLine("   AND Letra = '" & letra.ToString() & "'")
   '      .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
   '      .AppendLine("   AND NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
   '      .AppendLine("   AND IdProducto = '" & idProducto & "'")
   '      .AppendLine("   AND Orden = " & orden.ToString())
   '   End With

   '   Me.Execute(stbQuery.ToString())

   'End Sub

   Public Sub AnularCantidadEntregada(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numeroOrdenProduccion As Long,
                                      idProducto As String,
                                      Cantidad As Decimal,
                                      orden As Integer)

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("UPDATE OrdenesProduccionProductos")
         If Cantidad = 0 Then
            .AppendLine("   SET CantEntregada = " & Cantidad)
         Else
            .AppendLine("   SET CantEntregada = CantEntregada - " & Cantidad)
         End If
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroOrdenProduccion = " & numeroOrdenProduccion.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With

      Me.Execute(stbQuery.ToString())

   End Sub

End Class