Public Class PedidosProductosProveedores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PedidosProductosProveedores_I(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long,
                                            idProducto As String,
                                            Orden As Integer,
                                            idProveedor As Long,
                                            cantidad As Decimal,
                                            costoLista As Decimal,
                                            costo As Decimal,
                                            costoNeto As Decimal,
                                            descuentoRecargoPorc1 As Decimal,
                                            descuentoRecargoPorc2 As Decimal,
                                            descuentoRecargoProducto As Decimal,
                                            descRecGeneral As Decimal,
                                            descRecGeneralProducto As Decimal,
                                            idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                            alicuotaImpuesto As Decimal,
                                            importeImpuesto As Decimal,
                                            impuestoInterno As Decimal,
                                            importeImpuestoInterno As Decimal,
                                            porcImpuestoInterno As Decimal,
                                            importeTotal As Decimal,
                                            importeTotalNeto As Decimal,
                                            nombreProducto As String,
                                            cantPendiente As Decimal,
                                            cantEntregada As Decimal,
                                            cantEnProceso As Decimal,
                                            cantAnulada As Decimal,
                                            fechaActualizacion As Date,
                                            idUnidadDeMedidaCompra As String,
                                            cantidadUMCompra As Decimal,
                                            factorConversionCompra As Decimal,
                                            precioPorUMCompra As Decimal,
                                            idCriticidad As String,
                                            fechaEntrega As Date,
                                            costoConImpuestos As Decimal,
                                            costoNetoConImpuestos As Decimal,
                                            importeTotalConImpuestos As Decimal,
                                            importeTotalNetoConImpuestos As Decimal,
                                            idUnidadDeMedida As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO PedidosProductosProveedores")
         .AppendFormat("           (IdSucursal").AppendLine()
         .AppendFormat("           ,IdTipoComprobante").AppendLine()
         .AppendFormat("           ,Letra").AppendLine()
         .AppendFormat("           ,CentroEmisor").AppendLine()
         .AppendFormat("           ,NumeroPedido").AppendLine()
         .AppendFormat("           ,idProducto").AppendLine()
         .AppendFormat("           ,Orden").AppendLine()

         .AppendFormat("           ,IdProveedor").AppendLine()
         .AppendFormat("           ,Cantidad").AppendLine()

         .AppendFormat("           ,CostoLista").AppendLine()
         .AppendFormat("           ,Costo").AppendLine()
         .AppendFormat("           ,CostoNeto").AppendLine()

         .AppendFormat("           ,DescuentoRecargoPorc").AppendLine()
         .AppendFormat("           ,DescuentoRecargoPorc2").AppendLine()
         .AppendFormat("           ,DescuentoRecargoProducto").AppendLine()
         .AppendFormat("           ,DescRecGeneral").AppendLine()
         .AppendFormat("           ,DescRecGeneralProducto").AppendLine()

         .AppendFormat("           ,IdTipoImpuesto").AppendLine()
         .AppendFormat("           ,AlicuotaImpuesto").AppendLine()
         .AppendFormat("           ,ImporteImpuesto").AppendLine()

         .AppendFormat("           ,ImpuestoInterno").AppendLine()
         .AppendFormat("           ,ImporteImpuestoInterno").AppendLine()
         .AppendFormat("           ,PorcImpuestoInterno").AppendLine()

         .AppendFormat("           ,ImporteTotal").AppendLine()
         .AppendFormat("           ,ImporteTotalNeto").AppendLine()

         .AppendFormat("           ,NombreProducto").AppendLine()

         .AppendFormat("           ,CantPendiente").AppendLine()
         .AppendFormat("           ,CantEntregada").AppendLine()
         .AppendFormat("           ,CantEnProceso").AppendLine()
         .AppendFormat("           ,CantAnulada").AppendLine()

         .AppendFormat("           ,FechaActualizacion").AppendLine()

         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoProveedor.Columnas.IdUnidadDeMedidaCompra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoProveedor.Columnas.CantidadUMCompra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoProveedor.Columnas.FactorConversionCompra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.PedidoProductoProveedor.Columnas.PrecioPorUMCompra.ToString())
         .AppendFormat("           ,IdCriticidad").AppendLine()
         .AppendFormat("           ,FechaEntrega").AppendLine()

         .AppendFormat("           ,CostoConImpuestos").AppendLine()
         .AppendFormat("           ,CostoNetoConImpuestos").AppendLine()
         .AppendFormat("           ,ImporteTotalConImpuestos").AppendLine()
         .AppendFormat("           ,ImporteTotalNetoConImpuestos").AppendLine()
         .AppendFormat("           ,IdUnidadDeMedida").AppendLine()

         .AppendFormat(" ) VALUES (").AppendLine()
         .AppendFormat("            {0} ", idSucursal).AppendLine()
         .AppendFormat("          ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("          ,'{0}'", letra).AppendLine()
         .AppendFormat("          , {0} ", centroEmisor).AppendLine()
         .AppendFormat("          , {0} ", numeroPedido).AppendLine()
         .AppendFormat("          ,'{0}'", idProducto).AppendLine()
         .AppendFormat("          , {0} ", Orden).AppendLine()

         .AppendFormat("          , {0} ", idProveedor).AppendLine()
         .AppendFormat("          , {0} ", cantidad).AppendLine()

         .AppendFormat("          , {0} ", costoLista).AppendLine()
         .AppendFormat("          , {0} ", costo).AppendLine()
         .AppendFormat("          , {0} ", costoNeto).AppendLine()

         .AppendFormat("          , {0} ", descuentoRecargoPorc1.ToString()).AppendLine()
         .AppendFormat("          , {0} ", descuentoRecargoPorc2.ToString()).AppendLine()
         .AppendFormat("          , {0} ", descuentoRecargoProducto.ToString()).AppendLine()
         .AppendFormat("          , {0} ", descRecGeneral).AppendLine()
         .AppendFormat("          , {0} ", descRecGeneralProducto).AppendLine()

         .AppendFormat("          ,'{0}'", idTipoImpuesto.ToString()).AppendLine()
         .AppendFormat("          , {0} ", alicuotaImpuesto).AppendLine()
         .AppendFormat("          , {0} ", importeImpuesto).AppendLine()

         .AppendFormat("          , {0} ", impuestoInterno).AppendLine()
         .AppendFormat("          , {0} ", importeImpuestoInterno).AppendLine()
         .AppendFormat("          , {0} ", porcImpuestoInterno).AppendLine()

         .AppendFormat("          , {0} ", importeTotal).AppendLine()
         .AppendFormat("          , {0} ", importeTotalNeto).AppendLine()

         .AppendFormat("          ,'{0}'", nombreProducto).AppendLine()

         .AppendFormat("          , {0} ", cantPendiente).AppendLine()
         .AppendFormat("          , {0} ", cantEntregada).AppendLine()
         .AppendFormat("          , {0} ", cantEnProceso).AppendLine()
         .AppendFormat("          , {0} ", cantAnulada).AppendLine()

         .AppendFormat("          ,'{0}'", ObtenerFecha(fechaActualizacion, True))

         .AppendFormat("          ,'{0}'", idUnidadDeMedidaCompra).AppendLine()
         .AppendFormat("          , {0} ", cantidadUMCompra).AppendLine()
         .AppendFormat("          , {0} ", factorConversionCompra).AppendLine()
         .AppendFormat("          , {0} ", precioPorUMCompra).AppendLine()

         .AppendFormat("          ,'{0}'", idCriticidad).AppendLine()
         .AppendFormat("          ,'{0}'", ObtenerFecha(fechaEntrega, True)).AppendLine()

         .AppendFormat("          , {0} ", costoConImpuestos).AppendLine()
         .AppendFormat("          , {0} ", costoNetoConImpuestos).AppendLine()
         .AppendFormat("          , {0} ", importeTotalConImpuestos).AppendLine()
         .AppendFormat("          , {0} ", importeTotalNetoConImpuestos).AppendLine()
         If Not String.IsNullOrWhiteSpace(idUnidadDeMedida) Then
            .AppendFormat("          ,'{0}'", idUnidadDeMedida).AppendLine()
         Else
            .AppendFormat("          ,NULL").AppendLine()
         End If

         .AppendFormat(")").AppendLine()
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PP.* ")
         .AppendFormatLine("     , PS.Stock")
         .AppendFormatLine("     , PV.CodigoProductoProveedor")
         .AppendFormatLine("     , UMS.NombreUnidadDeMedida NombreUnidadDeMedidaStock")
         .AppendFormatLine("     , UMC.NombreUnidadDeMedida NombreUnidadDeMedidaCompra")
         '.AppendFormatLine("     , P.IdUnidadDeMedida")
         .AppendFormatLine("  FROM PedidosProductosProveedores PP")
         .AppendFormatLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PP.IdProducto AND PS.IdSucursal = {0}", actual.Sucursal.IdSucursal)
         .AppendFormatLine("  LEFT JOIN ProductosProveedores PV ON PV.IdProducto = PP.IdProducto AND PV.IdProveedor = PP.IdProveedor")
         .AppendFormatLine("  LEFT JOIN Productos P ON PP.IdProducto = P.IdProducto")
         .AppendFormatLine("  LEFT JOIN UnidadesDeMedidas UMS ON UMS.IdUnidadDeMedida = PP.IdUnidadDeMedida")
         .AppendFormatLine("  LEFT JOIN UnidadesDeMedidas UMC ON UMC.IdUnidadDeMedida = PP.IdUnidadDeMedidaCompra")
      End With
   End Sub
   Public Sub PedidosProductosProveedores_UDescripcion(idProducto As String, nombreProducto As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE PedidosProductosProveedores  SET ")
         .AppendLine("  NombreProducto = '" & nombreProducto.ToString() & "'")
         .AppendLine("  FROM PedidosProductosProveedores  PPP ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PPP.IdTipoComprobante")
         .AppendLine(" WHERE IdProducto = '" & idProducto & "'")
         .AppendLine(" AND (TC.EsElectronico = 'False' OR TC.EsPREElectronico = 'True' ) ")
         .AppendLine(" AND TC.EsFiscal = 'False'")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "PedidosProductos")
   End Sub
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PP.",
                    New Dictionary(Of String, String) From {{"Stock", "PS.Stock"},
                                                            {"NombreProduccionProceso", "PRP.NombreProduccionProceso"},
                                                            {"NombreProduccionForma", "PRF.NombreProduccionForma"},
                                                            {"NombreFormula", "PF.NombreFormula"}})
   End Function

   Public Sub PedidosProductosProveedores_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                            orden As Integer?, idProducto As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormat("DELETE FROM PedidosProductosProveedores").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", letra)
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido)
         If orden.HasValue Then
            .AppendFormat("   AND Orden = {0}", orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND IdProducto = '{0}'", idProducto)
         End If
      End With
      Execute(stb)
   End Sub

   Public Function PedidosProductosProveedores_GA() As DataTable
      Return PedidosProductosProveedores_G(Nothing, String.Empty, String.Empty, Nothing, Nothing, Nothing, String.Empty)
   End Function

   Public Function PedidosProductosProveedores_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Return PedidosProductosProveedores_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, Nothing, String.Empty)
   End Function

   Public Function PedidosProductosProveedores_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                  orden As Integer, idProducto As String) As DataTable
      Return PedidosProductosProveedores_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto)
   End Function

   Private Function PedidosProductosProveedores_G(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Integer?, numeroPedido As Long?,
                                                  orden As Integer?, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal.HasValue Then
            .AppendFormat("   AND PP.IdSucursal = {0}", idSucursal.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND PP.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND PP.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor.HasValue Then
            .AppendFormat("   AND PP.CentroEmisor = {0}", centroEmisor.Value).AppendLine()
         End If
         If numeroPedido.HasValue Then
            .AppendFormat("   AND PP.NumeroPedido = {0}", numeroPedido.Value).AppendLine()
         End If
         If orden.HasValue Then
            .AppendFormat("   AND PP.Orden = {0}", orden.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND PP.IdProducto = '{0}'", idProducto).AppendLine()
         End If

         .AppendFormat(" ORDER BY PP.IdSucursal, PP.IdTipoComprobante, PP.Letra, PP.CentroEmisor, PP.NumeroPedido, PP.Orden, PP.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub ReseteaCantidades(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                idProducto As String, orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("UPDATE PedidosProductos")
         .AppendFormatLine("   SET Cantidad = Cantidad")
         .AppendFormatLine("     , CantPendiente = Cantidad")
         .AppendFormatLine("     , CantEnProceso = 0")
         .AppendFormatLine("     , CantEntregada = 0")
         .AppendFormatLine("     , CantAnulada   = 0")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroPedido = {0}", numeroPedido)
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND Orden = {0}", orden)
      End With
      Execute(stbQuery)
   End Sub

   Public Sub ActualizarCantidades(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                   idProducto As String, orden As Integer,
                                   deltaCantidadPendiente As Decimal, deltaCantidadEnProceso As Decimal, deltaCantidadEntregada As Decimal, deltaCantidadAnulada As Decimal)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosProductosProveedores")
         .AppendLine("   SET Cantidad = Cantidad")
         .AppendFormat("     , CantPendiente = CantPendiente + {0}", deltaCantidadPendiente).AppendLine()
         .AppendFormat("     , CantEnProceso = CantEnProceso + {0}", deltaCantidadEnProceso).AppendLine()
         .AppendFormat("     , CantEntregada = CantEntregada + {0}", deltaCantidadEntregada).AppendLine()
         .AppendFormat("     , CantAnulada   = CantAnulada   + {0}", deltaCantidadAnulada).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
      End With
      Execute(stbQuery)
   End Sub
   Public Sub ActualizarCantidadesCalidad(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                          idProducto As String, orden As Integer,
                                          deltaCantidadPendiente As Decimal, deltaCantidadEnProceso As Decimal, deltaCantidadEntregada As Decimal, deltaCantidadAnulada As Decimal,
                                          Precio As Decimal, Cantidad As Decimal, FechaEntrega As Date)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosProductosProveedores")
         .AppendLine("   SET Cantidad = Cantidad")
         '.AppendFormat("   SET Cantidad = {0}", Cantidad).AppendLine()
         .AppendFormat("     , CantPendiente = {0}", deltaCantidadPendiente).AppendLine()
         .AppendFormat("     , CantEnProceso = {0}", deltaCantidadEnProceso).AppendLine()
         .AppendFormat("     , CantEntregada = {0}", deltaCantidadEntregada).AppendLine()
         .AppendFormat("     , CantAnulada   = {0}", deltaCantidadAnulada).AppendLine()
         .AppendFormat("     ,FechaEntrega   = '{0}'", ObtenerFecha(FechaEntrega, True))
         '.AppendFormat("     , CostoLista   = {0}", Precio).AppendLine()
         '.AppendFormat("     , Costo   = {0}", Precio).AppendLine()
         '.AppendFormat("     , CostoNeto   = {0}", Precio).AppendLine()
         '.AppendFormat("     , ImporteTotal   = {0}", Precio * Cantidad).AppendLine()
         '.AppendFormat("     , ImporteTotalNeto   = {0}", Precio * Cantidad).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
      End With
      Execute(stbQuery)
   End Sub

   Public Sub ActualizarPreciosCalidad(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                       idProducto As String, orden As Integer,
                                       importeImpuesto As Decimal, costoConImpuesto As Decimal,
                                       importeTotalConImpuestos As Decimal, porcImpuesto As Decimal, cantidad As Decimal,
                                       idUnidadDeMedida As String)

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosProductosProveedores")
         '  .AppendLine("   SET Cantidad = Cantidad")
         .AppendFormat("   SET Cantidad = {0}", cantidad).AppendLine()
         .AppendFormat("     , CostoConImpuestos   = {0}", costoConImpuesto).AppendLine()
         .AppendFormat("     , CostoNetoConImpuestos   = {0}", costoConImpuesto).AppendLine()
         .AppendFormat("     , ImporteImpuesto   = {0}", importeImpuesto).AppendLine()
         .AppendFormat("     , ImporteTotalConImpuestos   = {0}", importeTotalConImpuestos).AppendLine()
         .AppendFormat("     , AlicuotaImpuesto   = {0}", porcImpuesto).AppendLine()
         .AppendFormat("     , IdUnidadDeMedida   = '{0}'", idUnidadDeMedida).AppendLine()

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
      End With
      Execute(stbQuery)
   End Sub

   Public Sub AnularCantidadEntregada(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                      idProducto As String, cantidad As Decimal, orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosProductosProveedores")
         If cantidad = 0 Then
            .AppendLine("   SET CantEntregada = " & cantidad)
         Else
            .AppendLine("   SET CantEntregada = CantEntregada - " & cantidad)
         End If
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With
      Execute(stbQuery)
   End Sub


   Public Sub CopiarPedidoProducto(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                   idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Integer, numeroPedidoNuevo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO PedidosProductosProveedores").AppendLine()
         .AppendFormat("      (IdSucursal").AppendLine()
         .AppendFormat("      ,IdTipoComprobante").AppendLine()
         .AppendFormat("      ,Letra").AppendLine()
         .AppendFormat("      ,CentroEmisor").AppendLine()
         .AppendFormat("      ,NumeroPedido").AppendLine()
         .AppendFormat("      ,IdProducto").AppendLine()
         .AppendFormat("      ,Orden").AppendLine()
         .AppendFormat("      ,IdProveedor").AppendLine()
         .AppendFormat("      ,Cantidad,CantEntregada,CantEnProceso,CantAnulada,CantPendiente").AppendLine()
         .AppendFormat("      ,Precio,Costo,ImporteTotal,NombreProducto").AppendLine()
         .AppendFormat("      ,DescuentoRecargoProducto,DescuentoRecargoPorc2,DescuentoRecargoPorc").AppendLine()
         .AppendFormat("      ,IdTipoImpuesto,AlicuotaImpuesto,ImporteImpuesto,PrecioLista,FechaActualizacion").AppendLine()
         .AppendFormat("      ,IdListaPrecios,NombreListaPrecios,ImporteImpuestoInterno,PrecioNeto,ImporteTotalNeto").AppendLine()
         .AppendFormat("      ,DescRecGeneral,DescRecGeneralProducto,IdUnidadDeMedidaCompra,CantidadUMCompra,FactorConversionCompra,PrecioPorUMCompra,IdCriticidad,FechaEntrega,PrecioConImpuestos").AppendLine()
         .AppendFormat("      ,PrecioNetoConImpuestos,ImporteTotalConImpuestos,ImporteTotalNetoConImpuestos").AppendLine()
         .AppendFormat("      )").AppendLine()
         .AppendFormat("SELECT {0} IdSucursal", idSucursalNuevo).AppendLine()
         .AppendFormat("      ,'{0}' IdTipoComprobante", idTipoComprobanteNuevo).AppendLine()
         .AppendFormat("      ,'{0}' Letra", letraNuevo).AppendLine()
         .AppendFormat("      ,{0} CentroEmisor", centroEmisorNuevo).AppendLine()
         .AppendFormat("      ,{0} NumeroPedido", numeroPedidoNuevo).AppendLine()
         .AppendFormat("      ,IdProducto").AppendLine()
         .AppendFormat("      ,Orden").AppendLine()
         .AppendFormat("      ,IdProveedor").AppendLine()
         .AppendFormat("      ,Cantidad,0 CantEntregada,0 CantEnProceso,0 CantAnulada,Cantidad CantPendiente").AppendLine()
         .AppendFormat("      ,Precio,Costo,ImporteTotal,NombreProducto").AppendLine()
         .AppendFormat("      ,DescuentoRecargoProducto,DescuentoRecargoPorc2,DescuentoRecargoPorc").AppendLine()
         .AppendFormat("      ,IdTipoImpuesto,AlicuotaImpuesto,ImporteImpuesto,PrecioLista,FechaActualizacion").AppendLine()
         .AppendFormat("      ,IdListaPrecios,NombreListaPrecios,ImporteImpuestoInterno,PrecioNeto,ImporteTotalNeto").AppendLine()
         .AppendFormat("      ,DescRecGeneral,DescRecGeneralProducto,IdUnidadDeMedidaCompra,CantidadUMCompra,FactorConversionCompra,PrecioPorUMCompra,IdCriticidad,FechaEntrega,PrecioConImpuestos").AppendLine()
         .AppendFormat("      ,PrecioNetoConImpuestos,ImporteTotalConImpuestos,ImporteTotalNetoConImpuestos").AppendLine()
         .AppendFormat("  FROM PedidosProductosProveedores").AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
      End With
      Execute(myQuery)
   End Sub

   Public Sub CreaPedidoEstado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                               idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Integer, numeroPedidoNuevo As Long,
                               fechaPedidoNuevo As Date, estadoNuevo As String, observacionNuevo As String, usuarioNuevo As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO PedidosEstados").AppendLine()
         .AppendFormat("           (IdSucursal").AppendLine()
         .AppendFormat("           ,IdTipoComprobante").AppendLine()
         .AppendFormat("           ,Letra").AppendLine()
         .AppendFormat("           ,CentroEmisor").AppendLine()
         .AppendFormat("           ,NumeroPedido").AppendLine()
         .AppendFormat("           ,IdProducto").AppendLine()
         .AppendFormat("           ,Orden").AppendLine()
         .AppendFormat("           ,FechaEstado").AppendLine()
         .AppendFormat("           ,IdProveedor").AppendLine()
         .AppendFormat("           ,IdEstado,IdUsuario,Observacion").AppendLine()
         .AppendFormat("           ,IdTipoComprobanteFact,LetraFact,CentroEmisorFact,NumeroComprobanteFact").AppendLine()
         .AppendFormat("           ,IdCriticidad,FechaEntrega,NumeroReparto").AppendLine()
         .AppendFormat("           ,CantEstado").AppendLine()
         .AppendFormat("           ,TipoEstadoPedido").AppendLine()
         .AppendFormat("           ,IdSucursalGenerado,IdTipoComprobanteGenerado,LetraGenerado").AppendLine()
         .AppendFormat("           ,CentroEmisorGenerado,NumeroPedidoGenerado").AppendLine()
         .AppendFormat("           ,IdSucursalRemito,IdTipoComprobanteRemito,LetraRemito").AppendLine()
         .AppendFormat("           ,CentroEmisorRemito,NumeroComprobanteRemito)").AppendLine()
         .AppendFormat("SELECT {0} IdSucursal", idSucursalNuevo).AppendLine()
         .AppendFormat("      ,'{0}' IdTipoComprobante", idTipoComprobanteNuevo).AppendLine()
         .AppendFormat("      ,'{0}' Letra", letraNuevo).AppendLine()
         .AppendFormat("      ,{0} CentroEmisor", centroEmisorNuevo).AppendLine()
         .AppendFormat("      ,{0} NumeroPedido", numeroPedidoNuevo).AppendLine()
         .AppendFormat("      ,PP.IdProducto").AppendLine()
         .AppendFormat("      ,PP.Orden").AppendLine()
         .AppendFormat("      ,'{0}' FechaEstado", ObtenerFecha(fechaPedidoNuevo, True)).AppendLine()
         .AppendFormat("      ,PP.IdProveedor").AppendLine()
         .AppendFormat("      ,'{0}' IdEstado, '{1}' IdUsuario, '{2}' Observacion", estadoNuevo, usuarioNuevo, observacionNuevo).AppendLine()
         .AppendFormat("      ,NULL IdTipoComprobanteFact,NULL LetraFact,NULL CentroEmisorFact,NULL NumeroComprobanteFact").AppendLine()
         .AppendFormat("      ,PP.IdCriticidad,PP.FechaEntrega,NULL NumeroReparto").AppendLine()
         .AppendFormat("      ,PP.Cantidad").AppendLine()
         .AppendFormat("      ,TC.Tipo").AppendLine()
         .AppendFormat("      ,NULL IdSucursalGenerado,NULL IdTipoComprobanteGenerado,NULL LetraGenerado").AppendLine()
         .AppendFormat("      ,NULL CentroEmisorGenerado,NULL NumeroPedidoGenerado").AppendLine()
         .AppendFormat("      ,NULL IdSucursalRemito,NULL IdTipoComprobanteRemito,NULL LetraRemito").AppendLine()
         .AppendFormat("      ,NULL CentroEmisorRemito,NULL NumeroComprobanteRemito").AppendLine()
         .AppendFormat("  FROM PedidosProductosProveedores PP").AppendLine()
         .AppendFormat(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PP.IdTipoComprobante").AppendLine()
         .AppendFormat(" WHERE PP.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND PP.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND PP.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND PP.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND PP.NumeroPedido = {0}", numeroPedido).AppendLine()
      End With
      Execute(myQuery)
   End Sub

End Class