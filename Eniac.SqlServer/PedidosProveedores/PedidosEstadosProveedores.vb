Public Class PedidosEstadosProveedores
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT PE.*, EP.IdTipoEstado")
         .AppendLine("     , TC.Descripcion AS DescripcionTipoComprobante")
         .AppendLine("     , P.FechaPedido")
         .AppendLine("     , PP.Costo")
         .AppendLine("     , PP.DescuentoRecargoPorc")
         .AppendLine("  FROM PedidosEstadosProveedores PE")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine(" INNER JOIN PedidosProveedores P")
         .AppendLine("         ON P.IdSucursal = PE.IdSucursal")
         .AppendLine("        AND P.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine("        AND P.Letra = PE.Letra")
         .AppendLine("        AND P.CentroEmisor = PE.CentroEmisor")
         .AppendLine("        AND P.NumeroPedido = PE.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosProductosProveedores PP")
         .AppendLine("         ON PP.IdSucursal = PE.IdSucursal")
         .AppendLine("        AND PP.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine("        AND PP.Letra = PE.Letra")
         .AppendLine("        AND PP.CentroEmisor = PE.CentroEmisor")
         .AppendLine("        AND PP.NumeroPedido = PE.NumeroPedido")
         .AppendLine("        AND PP.IdProducto = PE.IdProducto")
         .AppendLine("        AND PP.Orden = PE.Orden")



      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PE.")
   End Function

   Public Sub PedidosEstadosProveedores_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                          orden As Integer?, idProducto As String, fechaEstado As Date?)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormat("DELETE FROM PedidosEstadosProveedores").AppendLine()
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
         If fechaEstado.HasValue Then
            .AppendFormat("   AND FechaEstado = '{0}'", ObtenerFecha(fechaEstado.Value, True))
         End If
         'If Not String.IsNullOrWhiteSpace(IdEstado) Then
         '   .AppendFormat("   AND IdEstado = '{0}'", IdEstado)
         '   .AppendFormat("   AND TipoEstadoPedido = '{0}'", TipoEstadoPedido)
         'End If
      End With

      Execute(stb)

   End Sub

   Public Function PedidosEstadosProveedores_GA() As DataTable
      Return PedidosEstadosProveedores_G(Nothing, String.Empty, String.Empty, Nothing, Nothing, Nothing, String.Empty, Nothing, String.Empty)
   End Function

   Public Function PedidosEstadosProveedores_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                idTipoEstado As String) As DataTable
      Return PedidosEstadosProveedores_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, Nothing, String.Empty, Nothing, idTipoEstado)
   End Function

   Public Function PedidosEstadosProveedores_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                orden As Integer, idProducto As String) As DataTable
      Return PedidosEstadosProveedores_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, Nothing, String.Empty)
   End Function

   Public Function PedidosEstadosProveedores_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                orden As Integer, idProducto As String, fechaEstado As Date?) As DataTable
      Return PedidosEstadosProveedores_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, fechaEstado, String.Empty)
   End Function

   Private Function PedidosEstadosProveedores_G(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Integer?, numeroPedido As Long?,
                                                orden As Integer?, idProducto As String, fechaEstado As Date?, idTipoEstado As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal.HasValue Then
            .AppendFormat("   AND PE.IdSucursal = {0}", idSucursal.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND PE.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND PE.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor.HasValue Then
            .AppendFormat("   AND PE.CentroEmisor = {0}", centroEmisor.Value).AppendLine()
         End If
         If numeroPedido.HasValue Then
            .AppendFormat("   AND PE.NumeroPedido = {0}", numeroPedido.Value).AppendLine()
         End If
         If orden.HasValue Then
            .AppendFormat("   AND PE.Orden = {0}", orden.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND PE.IdProducto = '{0}'", idProducto).AppendLine()
         End If
         If fechaEstado.HasValue Then
            .AppendFormat("   AND PE.FechaEstado = '{0}'", ObtenerFecha(fechaEstado.Value, True)).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoEstado) Then
            .AppendFormat("   AND EP.IdTipoEstado = '{0}'", idTipoEstado).AppendLine()
         End If
         .AppendFormat(" ORDER BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden, PE.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function PedidosEstadosProveedores_GPrimerFechaEntrega(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Integer?, numeroPedido As Long?,
                                                                 orden As Integer?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal.HasValue Then
            .AppendFormat("   AND PE.IdSucursal = {0}", idSucursal.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND PE.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND PE.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor.HasValue Then
            .AppendFormat("   AND PE.CentroEmisor = {0}", centroEmisor.Value).AppendLine()
         End If
         If numeroPedido.HasValue Then
            .AppendFormat("   AND PE.NumeroPedido = {0}", numeroPedido.Value).AppendLine()
         End If
         If orden.HasValue Then
            .AppendFormat("   AND PE.Orden = {0}", orden.Value).AppendLine()
         End If
         .AppendFormat(" ORDER BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden, PE.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Private Function PedidosEstadosProveedores_G_PorPedidoGenerado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PE.*, EP.IdTipoEstado")
         .AppendLine("  FROM (SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido")
         .AppendLine("          FROM PedidosEstadosProveedores PE1")
         .AppendFormat("         WHERE IdSucursalGenerado = {0}", idSucursal).AppendLine()
         .AppendFormat("           AND IdTipoComprobanteGenerado = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("           AND LetraGenerado = '{0}'", letra).AppendLine()
         .AppendFormat("           AND CentroEmisorGenerado = {0}", centroEmisor).AppendLine()
         .AppendFormat("           AND NumeroPedidoGenerado = {0}", numeroPedido).AppendLine()
         .AppendLine("         GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido) P")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = P.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")

         .AppendFormat(" ORDER BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden, PE.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Private Function PedidosEstadosProveedores_G_PorPedidoProduccion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PE.*, EP.IdTipoEstado")
         .AppendLine("  FROM (SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido")
         .AppendLine("          FROM PedidosEstadosProveedores PE1")
         .AppendFormat("         WHERE IdSucursalProduccion = {0}", idSucursal).AppendLine()
         .AppendFormat("           AND IdTipoComprobanteProduccion = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("           AND LetraProduccion = '{0}'", letra).AppendLine()
         .AppendFormat("           AND CentroEmisorProduccion = {0}", centroEmisor).AppendLine()
         .AppendFormat("           AND NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()
         .AppendLine("         GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido) P")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = P.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")

         .AppendFormat(" ORDER BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden, PE.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function


   Public Sub PedidosEstadosProveedores_I(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroPedido As Long,
                                          idproducto As String,
                                          fechaEstado As Date,
                                          idProveedor As Long,
                                          idEstado As String,
                                          IdUsuario As String,
                                          observacion As String,
                                          cantEstado As Decimal,
                                          idTipoComprobanteFact As String,
                                          letraFact As String,
                                          centroEmisorFact As Integer,
                                          numeroComprobanteFact As Long,
                                          Orden As Integer,
                                          criticidad As String,
                                          fechaEntrega As Date?,
                                          TipoEstadoPedido As String,
                                          numeroReparto As Integer,
                                          idSucursalGenerado As Integer,
                                          idTipoComprobanteGenerado As String,
                                          letraGenerado As String,
                                          centroEmisorGenerado As Integer,
                                          numeroPedidoGenerado As Long,
                                          idSucursalRemito As Integer,
                                          idTipoComprobanteRemito As String,
                                          letraRemito As String,
                                          centroEmisorRemito As Integer,
                                          numeroComprobanteRemito As Long,
                                          idEstadoProducto As String,
                                          idEstadoCantidad As String,
                                          idEstadoPrecio As String,
                                          idEstadoFechaEntrega As String,
                                          fechaEstadoProducto As Date?,
                                          fechaEstadoCantidad As Date?,
                                          fechaEstadoPrecio As Date?,
                                          fechaEstadoFechaEntrega As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO PedidosEstadosProveedores")
         .AppendFormatLine("         ({0}", Entidades.Pedido.Columnas.IdSucursal.ToString())
         .AppendFormatLine("         ,{0}", Entidades.Pedido.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("         ,{0}", Entidades.Pedido.Columnas.Letra.ToString())
         .AppendFormatLine("         ,{0}", Entidades.Pedido.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("         ,{0}", Entidades.Pedido.Columnas.NumeroPedido.ToString())
         .AppendFormatLine("         ,idProducto")
         .AppendFormatLine("         ,fechaEstado")
         .AppendFormatLine("         ,IdProveedor")
         .AppendFormatLine("         ,idEstado")
         .AppendFormatLine("         ,TipoEstadoPedido")
         .AppendFormatLine("         ,IdUsuario")
         .AppendFormatLine("         ,observacion")
         .AppendFormatLine("         ,CantEstado")
         .AppendFormatLine("         ,IdTipoComprobanteFact")
         .AppendFormatLine("         ,LetraFact")
         .AppendFormatLine("         ,CentroEmisorFact")
         .AppendFormatLine("         ,NumeroComprobanteFact")
         .AppendFormatLine("         ,Orden")
         .AppendFormatLine("         ,IdCriticidad")
         .AppendFormatLine("         ,FechaEntrega")
         .AppendFormatLine("         ,NumeroReparto")

         .AppendFormatLine("         ,IdSucursalGenerado")
         .AppendFormatLine("         ,IdTipoComprobanteGenerado")
         .AppendFormatLine("         ,LetraGenerado")
         .AppendFormatLine("         ,CentroEmisorGenerado")
         .AppendFormatLine("         ,NumeroPedidoGenerado")

         .AppendFormatLine("         ,IdSucursalRemito")
         .AppendFormatLine("         ,IdTipoComprobanteRemito")
         .AppendFormatLine("         ,LetraRemito")
         .AppendFormatLine("         ,CentroEmisorRemito")
         .AppendFormatLine("         ,NumeroComprobanteRemito")

         .AppendFormatLine("         ,IdEstadoProducto")
         .AppendFormatLine("         ,IdEstadoCantidad")
         .AppendFormatLine("         ,IdEstadoPrecio")
         .AppendFormatLine("         ,IdEstadoFechaEntrega")
         .AppendFormatLine("         ,FechaEstadoProducto")
         .AppendFormatLine("         ,FechaEstadoCantidad")
         .AppendFormatLine("         ,FechaEstadoPrecio")
         .AppendFormatLine("         ,FechaEstadoFechaEntrega")

         .AppendFormat(" ) VALUES (").AppendLine()

         .AppendFormat("            {0} ", idSucursal).AppendLine()
         .AppendFormat("          ,'{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("          ,'{0}'", letra).AppendLine()
         .AppendFormat("          , {0} ", centroEmisor).AppendLine()
         .AppendFormat("          , {0} ", numeroPedido).AppendLine()
         .AppendFormat("          ,'{0}'", idproducto).AppendLine()
         .AppendFormat("          ,'{0}'", Me.ObtenerFecha(fechaEstado, True)).AppendLine()
         .AppendFormat("          , {0} ", idProveedor).AppendLine()
         .AppendFormat("          ,'{0}'", idEstado).AppendLine()
         .AppendFormat("          ,'{0}'", TipoEstadoPedido).AppendLine()
         .AppendFormat("          ,'{0}'", IdUsuario).AppendLine()
         .AppendFormat("          ,'{0}'", observacion).AppendLine()
         .AppendFormat("          , {0} ", cantEstado).AppendLine()
         If idTipoComprobante = "" Then
            .AppendFormat("  ,{0}", "NULL").AppendLine()
         Else
            .AppendFormat("  ,'{0}'", idTipoComprobanteFact).AppendLine()
         End If
         If letra = "" Then
            .AppendFormat("  ,{0}", "NULL").AppendLine()
         Else
            .AppendFormat("  ,'{0}'", letraFact).AppendLine()
         End If
         If centroEmisor = 0 Then
            .AppendFormat("   ,{0}", "NULL").AppendLine()
         Else
            .AppendFormat("  ,{0}", centroEmisorFact).AppendLine()
         End If
         If numeroComprobanteFact = 0 Then
            .AppendFormat("   ,{0}", "NULL").AppendLine()
         Else
            .AppendFormat("  ,{0}", numeroComprobanteFact).AppendLine()
         End If
         .AppendFormat("  ,{0}", Orden).AppendLine()
         .AppendFormat("  ,'{0}'", criticidad).AppendLine()

         If fechaEntrega.HasValue Then
            .AppendFormat("  ,'{0}'", Me.ObtenerFecha(fechaEntrega.Value(), False)).AppendLine()
         Else
            .AppendFormat("   ,{0}", "NULL").AppendLine()
         End If

         If numeroReparto > 0 Then
            .AppendFormat("   ,{0}", numeroReparto).AppendLine()
         Else
            .AppendFormat("   ,{0}", "NULL").AppendLine()
         End If

         'Para FK a PedidosEstadosProveedores que se generó
         If idSucursalGenerado > 0 Then
            .AppendFormat("         ,{0}", idSucursalGenerado).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteGenerado) Then
            .AppendFormat("         ,'{0}'", idTipoComprobanteGenerado).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraGenerado) Then
            .AppendFormat("         ,'{0}'", letraGenerado).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If
         If centroEmisorGenerado > 0 Then
            .AppendFormat("         ,{0}", centroEmisorGenerado).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If
         If numeroPedidoGenerado > 0 Then
            .AppendFormat("         ,{0}", numeroPedidoGenerado).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If

         'Para FK a Compras Remitos que se generó
         If idSucursalRemito > 0 Then
            .AppendFormat("         ,{0}", idSucursalRemito).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteRemito) Then
            .AppendFormat("         ,'{0}'", idTipoComprobanteRemito).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraRemito) Then
            .AppendFormat("         ,'{0}'", letraRemito).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If
         If centroEmisorRemito > 0 Then
            .AppendFormat("         ,{0}", centroEmisorRemito).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If
         If numeroComprobanteRemito > 0 Then
            .AppendFormat("         ,{0}", numeroComprobanteRemito).AppendLine()
         Else
            .AppendFormat("         ,NULL").AppendLine()
         End If

         .AppendFormatLine("         ,{0}", GetStringParaQueryConComillas(idEstadoProducto))
         .AppendFormatLine("         ,{0}", GetStringParaQueryConComillas(idEstadoCantidad))
         .AppendFormatLine("         ,{0}", GetStringParaQueryConComillas(idEstadoPrecio))
         .AppendFormatLine("         ,{0}", GetStringParaQueryConComillas(idEstadoFechaEntrega))
         If fechaEstadoProducto.HasValue Then
            .AppendFormatLine("         ,'{0}'", ObtenerFecha(fechaEstadoProducto.Value, True))
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If fechaEstadoCantidad.HasValue Then
            .AppendFormatLine("         ,'{0}'", ObtenerFecha(fechaEstadoCantidad.Value, True))
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If fechaEstadoPrecio.HasValue Then
            .AppendFormatLine("         ,'{0}'", ObtenerFecha(fechaEstadoPrecio.Value, True))
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If fechaEstadoFechaEntrega.HasValue Then
            .AppendFormatLine("         ,'{0}'", ObtenerFecha(fechaEstadoFechaEntrega.Value, True))
         Else
            .AppendFormatLine("         ,NULL")
         End If

         .Append(")").AppendLine()

      End With

      Execute(myQuery)

   End Sub

   Public Sub PedidosEstadosProveedores_U_Cantidad(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Integer,
                                        numeroPedido As Long,
                                        idproducto As String,
                                        orden As Integer,
                                        fechaEstado As Date,
                                        deltaCantEstado As Decimal)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET CantEstado = CantEstado + " & deltaCantEstado.ToString())
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
      End With
      Execute(stbQuery)
   End Sub

   Public Sub PedidosEstadosProveedores_U_Estados(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                  idproducto As String, orden As Integer,
                                                  idEstadoProducto As String, idEstadoCantidad As String, idEstadoPrecio As String, idEstadoFechaEntrega As String,
                                                  fechaEstadoProducto As Date?, fechaEstadoCantidad As Date?, fechaEstadoPrecio As Date?, fechaEstadoFechaEntrega As Date?)
      Dim stbQuery As StringBuilder = New StringBuilder()

      With stbQuery
         .AppendFormatLine("UPDATE PedidosEstadosProveedores")
         .AppendFormatLine("   SET {0} = {1}", Entidades.PedidoEstadoProveedor.Columnas.IdEstadoProducto.ToString(), GetStringParaQueryConComillas(idEstadoProducto))
         .AppendFormatLine("     , {0} = {1}", Entidades.PedidoEstadoProveedor.Columnas.IdEstadoCantidad.ToString(), GetStringParaQueryConComillas(idEstadoCantidad))
         .AppendFormatLine("     , {0} = {1}", Entidades.PedidoEstadoProveedor.Columnas.IdEstadoPrecio.ToString(), GetStringParaQueryConComillas(idEstadoPrecio))
         .AppendFormatLine("     , {0} = {1}", Entidades.PedidoEstadoProveedor.Columnas.IdEstadoFechaEntrega.ToString(), GetStringParaQueryConComillas(idEstadoFechaEntrega))

         If fechaEstadoProducto.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoProducto.ToString(), ObtenerFecha(fechaEstadoProducto.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoProducto.ToString())
         End If
         If fechaEstadoCantidad.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoCantidad.ToString(), ObtenerFecha(fechaEstadoCantidad.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoCantidad.ToString())
         End If
         If fechaEstadoPrecio.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoPrecio.ToString(), ObtenerFecha(fechaEstadoPrecio.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoPrecio.ToString())
         End If
         If fechaEstadoFechaEntrega.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoFechaEntrega.ToString(), ObtenerFecha(fechaEstadoFechaEntrega.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.PedidoEstadoProveedor.Columnas.FechaEstadoFechaEntrega.ToString())
         End If

         .AppendFormatLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendFormatLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendFormatLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendFormatLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendFormatLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendFormatLine("   AND IdProducto = '" & idproducto & "'")
         .AppendFormatLine("   AND Orden = " & orden.ToString)
      End With

      Execute(stbQuery)
   End Sub

   Public Sub PedidosEstadosProveedores_U_Estado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                 idproducto As String, fechaEstado As Date, idEstado As String, tipoEstadoPedido As String,
                                                 cantEstado As Decimal, fechaNuevoEstado As Date,
                                                 observacion As String,
                                                 orden As Integer,
                                                 criticidad As String, fechaEntrega As Date, numeroReparto As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET CantEstado = " & cantEstado.ToString)
         .AppendLine("      ,IdEstado = '" & idEstado & "'")
         .AppendFormat("      ,TipoEstadoPedido = '{0}'", tipoEstadoPedido).AppendLine()
         .AppendLine("      ,FechaEstado = '" & ObtenerFecha(fechaNuevoEstado, True) & "'")
         .AppendLine("      ,Observacion = '" & observacion & "'")
         .AppendLine("      ,IdCriticidad = '" & criticidad & "'")
         .AppendLine("      ,FechaEntrega = '" & ObtenerFecha(fechaEntrega, True) & "'")
         If numeroReparto > 0 Then
            .AppendLine("      ,NumeroReparto = " & numeroReparto)
         End If
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With
      Execute(stbQuery)
   End Sub
   Public Sub PedidosEstadosProveedores_U_EstadoCalidad(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                        idproducto As String, fechaEstado As Date, idEstado As String, tipoEstadoPedido As String,
                                                        cantEstado As Decimal, fechaNuevoEstado As Date,
                                                        observacion As String,
                                                        orden As Integer, criticidad As String, fechaEntrega As Date,
                                                        numeroReparto As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET CantEstado = " & cantEstado.ToString)
         .AppendLine("      ,IdEstado = '" & idEstado & "'")
         .AppendFormat("      ,TipoEstadoPedido = '{0}'", tipoEstadoPedido).AppendLine()
         .AppendLine("      ,FechaEstado = '" & ObtenerFecha(fechaNuevoEstado, True) & "'")
         .AppendLine("      ,Observacion = '" & observacion & "'")
         .AppendLine("      ,IdCriticidad = '" & criticidad & "'")
         .AppendLine("      ,FechaEntrega = '" & ObtenerFecha(fechaEntrega, True) & "'")
         If numeroReparto > 0 Then
            .AppendLine("      ,NumeroReparto = " & numeroReparto)
         End If
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With
      Execute(stbQuery)
   End Sub
   Public Sub PedidosEstados_U_Anular_Estado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                             idproducto As String, fechaEstado As Date, orden As Integer, idEstadoNuevo As String,
                                             tipoEstadoPedidoNuevo As String, fechaNuevoEstado As Date, observacion As String)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET IdEstado = '" & idEstadoNuevo & "'")
         .AppendFormat("      ,TipoEstadoPedido = '{0}'", tipoEstadoPedidoNuevo).AppendLine()
         .AppendLine("      ,FechaEstado = '" & ObtenerFecha(fechaNuevoEstado, True) & "'")
         .AppendLine("      ,Observacion = '" & observacion & "'")
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)

      End With
      Execute(stbQuery)
   End Sub

   Public Sub PedidosEstadosProveedores_U_Anular_Fact(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                      idproducto As String, fechaEstado As Date, orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET IdTipoComprobanteFact = null ")
         .AppendLine("      ,LetraFact = null ")
         .AppendLine("      ,CentroEmisorFact = null ")
         .AppendLine("      ,NumeroComprobanteFact = null ")
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With
      Execute(stbQuery)
   End Sub

   Public Sub PedidosEstados_U_Anular_Remito(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                             idproducto As String, fechaEstado As Date, orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET IdSucursalRemito = null ")
         .AppendLine("      ,IdTipoComprobanteRemito = null ")
         .AppendLine("      ,LetraRemito = null ")
         .AppendLine("      ,CentroEmisorRemito = null ")
         .AppendLine("      ,NumeroComprobanteRemito = null ")
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)

      End With
      Execute(stbQuery)
   End Sub

   Public Sub PedidosEstadosProveedores_U_Fact(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                               idProducto As String, fechaEstado As Date,
                                               idTipoComprobanteFact As String, letraFact As String, centroEmisorFact As Integer, numeroComprobanteFact As Long, Orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET IdTipoComprobanteFact = '" & idTipoComprobanteFact & "'")
         .AppendLine("      ,LetraFact = '" & letraFact & "'")
         .AppendLine("      ,CentroEmisorFact =" & centroEmisorFact.ToString)
         .AppendLine("      ,NumeroComprobanteFact = " & numeroComprobanteFact.ToString)
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
         .AppendLine("   AND Orden = " & Orden.ToString)
      End With
      Dim count = Execute(stbQuery)
      Console.WriteLine(count)
   End Sub

   Public Sub PedidosEstadosProveedores_U_OpOperacionTallerExt_Limpiar(
                        idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, idProducto As String, fechaEstado As Date, orden As Integer)
      PedidosEstadosProveedores_U_OpOperacionTallerExt(
                        idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, idProducto, fechaEstado, orden,
                        idSucursalOpOperacionTallerExt:=Nothing, idTipoComprobanteOpOperacionTallerExt:=Nothing, letraOpOperacionTallerExt:=Nothing,
                        centroEmisorOpOperacionTallerExt:=Nothing, numeroOrdenProduccionOpOperacionTallerExt:=Nothing, ordenOpOperacionTallerExt:=Nothing,
                        idProductoOpOperacionTallerExt:=Nothing, idProcesoProductivoOpOperacionTallerExt:=Nothing, idOperacionOpOperacionTallerExt:=Nothing)
   End Sub

   Public Sub PedidosEstadosProveedores_U_OpOperacionTallerExt(
                        idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long, idProducto As String, fechaEstado As Date, orden As Integer,
                        idSucursalOpOperacionTallerExt As Integer?, idTipoComprobanteOpOperacionTallerExt As String, letraOpOperacionTallerExt As String,
                        centroEmisorOpOperacionTallerExt As Integer?, numeroOrdenProduccionOpOperacionTallerExt As Integer?, ordenOpOperacionTallerExt As Integer?,
                        idProductoOpOperacionTallerExt As String, idProcesoProductivoOpOperacionTallerExt As Long?, idOperacionOpOperacionTallerExt As Integer?)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("UPDATE PedidosEstadosProveedores SET")
         If numeroOrdenProduccionOpOperacionTallerExt.HasValue Then
            .AppendFormatLine("       IdSucursalOpOperacionTallerExt             =  {0} ", idSucursalOpOperacionTallerExt)
            .AppendFormatLine("     , IdTipoComprobanteOpOperacionTallerExt      = '{0}'", idTipoComprobanteOpOperacionTallerExt)
            .AppendFormatLine("     , LetraOpOperacionTallerExt                  = '{0}'", letraOpOperacionTallerExt)
            .AppendFormatLine("     , CentroEmisorOpOperacionTallerExt           =  {0} ", centroEmisorOpOperacionTallerExt)
            .AppendFormatLine("     , NumeroOrdenProduccionOpOperacionTallerExt  =  {0} ", numeroOrdenProduccionOpOperacionTallerExt)
            .AppendFormatLine("     , OrdenOpOperacionTallerExt                  =  {0} ", ordenOpOperacionTallerExt)
            .AppendFormatLine("     , IdProductoOpOperacionTallerExt             = '{0}'", idProductoOpOperacionTallerExt)
            .AppendFormatLine("     , IdProcesoProductivoOpOperacionTallerExt    =  {0} ", idProcesoProductivoOpOperacionTallerExt)
            .AppendFormatLine("     , IdOperacionOpOperacionTallerExt            =  {0} ", idOperacionOpOperacionTallerExt)
         Else
            .AppendFormatLine("       IdSucursalOpOperacionTallerExt             =  NULL")
            .AppendFormatLine("     , IdTipoComprobanteOpOperacionTallerExt      =  NULL")
            .AppendFormatLine("     , LetraOpOperacionTallerExt                  =  NULL")
            .AppendFormatLine("     , CentroEmisorOpOperacionTallerExt           =  NULL")
            .AppendFormatLine("     , NumeroOrdenProduccionOpOperacionTallerExt  =  NULL")
            .AppendFormatLine("     , OrdenOpOperacionTallerExt                  =  NULL")
            .AppendFormatLine("     , IdProductoOpOperacionTallerExt             =  NULL")
            .AppendFormatLine("     , IdProcesoProductivoOpOperacionTallerExt    =  NULL")
            .AppendFormatLine("     , IdOperacionOpOperacionTallerExt            =  NULL")
         End If
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroPedido = {0}", numeroPedido)
         .AppendFormatLine("   AND FechaEstado = '{0}'", ObtenerFecha(fechaEstado, True))
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND Orden = {0}", orden)
      End With
      Dim count = Execute(stbQuery)
      Console.WriteLine(count)
   End Sub

   Public Sub PedidosEstadosProveedores_U_Remito(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                 idProducto As String, fechaEstado As Date,
                                                 idSucursalRemito As Integer, idTipoComprobanteRemito As String, letraRemito As String, centroEmisorRemito As Integer, numeroComprobanteRemito As Long, orden As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendFormat("   SET IdSucursalRemito = {0}", idSucursalRemito).AppendLine()
         .AppendFormat("      ,IdTipoComprobanteRemito = '{0}'", idTipoComprobanteRemito).AppendLine()
         .AppendFormat("      ,LetraRemito = '{0}'", letraRemito).AppendLine()
         .AppendFormat("      ,CentroEmisorRemito = {0}", centroEmisorRemito).AppendLine()
         .AppendFormat("      ,NumeroComprobanteRemito = {0}", numeroComprobanteRemito).AppendLine()
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)
      End With
      Execute(stbQuery)
   End Sub

   Public Function PedidosEstadosProveedores_G_PorComprobanteFact(idSucursal As Integer, idTipoComprobanteFact As String, letraFact As String, centroEmisorFact As Short, numeroComprobanteFact As Long) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.IdProveedor, PV.CodigoProveedor, PV.NombreProveedor")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano, Pr.IdUnidadDeMedida, pp.Orden")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, PE.TipoEstadoPedido, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE ")
         .AppendLine("           (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE PE.CantEstado END) END) AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")
         .AppendLine(" FROM PedidosProveedores P")

         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendLine(" WHERE P.IdSucursal = " & idSucursal.ToString())
         '.AppendLine("   AND P.IdTipoComprobante = '" & idTipoComprobante & "'")
         '.AppendLine("   AND P.Letra = '" & letra & "'")
         '.AppendLine("   AND P.CentroEmisor = " & centroEmisor.ToString())
         '.AppendLine("   AND P.NumeroPedido = " & numeroPedido.ToString())
         .AppendLine("   AND PE.IdTipoComprobanteFact = '" & idTipoComprobanteFact & "'")
         .AppendLine("   AND PE.LetraFact = '" & letraFact & "'")
         .AppendLine("   AND PE.CentroEmisorFact = " & centroEmisorFact.ToString())
         .AppendLine("   AND PE.NumeroComprobanteFact = " & numeroComprobanteFact.ToString())

         .AppendLine(" ORDER BY p.fechaPedido")
      End With
      Return GetDataTable(stbQuery)
   End Function


   'TODO: Para revisar
   Public Function GetPedidosEstadosProveedoresUno(IdSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                   idProducto As String, fechaEstado As Date, orden As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT '' as Color")
         .AppendLine("      ,'False' as masivo")
         .AppendLine("      ,pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.IdProveedor, PV.NombreProveedor")
         ' Agrego orden ############## 17*03*13
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pp.Costo, pp.Orden")
         .AppendLine("      ,pe.CantEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, PE.TipoEstadoPedido, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE ")
         .AppendLine(" (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE PE.CantEstado END) END) AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
         .AppendLine("      ,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdSucursalGenerado, pe.IdTipoComprobanteGenerado, pe.LetraGenerado, pe.CentroEmisorGenerado, pe.NumeroPedidoGenerado")
         .AppendLine("      ,pe.IdSucursalRemito, pe.IdTipoComprobanteRemito, pe.LetraRemito, pe.CentroEmisorRemito, pe.NumeroComprobanteRemito")
         '.AppendLine("      ,pe.IdSucursalProduccion, pe.IdTipoComprobanteProduccion, pe.LetraProduccion, pe.CentroEmisorProduccion, pe.NumeroOrdenProduccion")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine(" FROM PedidosProveedores P")
         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstadosProveedores PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidosProveedores EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Productos PR ON PR.IdProducto = PE.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = PR.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = PR.IdRubro")

         .AppendLine(" WHERE p.IdSucursal = " & IdSucursal.ToString())

         .AppendFormat("   AND P.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND P.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND P.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND P.NumeroPedido = {0}", numeroPedido).AppendLine()

         .AppendLine("   AND pe.FechaEstado = '" & Me.ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND pe.IdProducto = '" & idProducto & "'")

         .AppendLine("   AND pe.Orden = " & orden.ToString)

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidosEstadosProveedoresPorComprobanteFact(IdSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                   idProducto As String, fechaEstado As Date, orden As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT PEP.IdSucursal
		               ,PEP.IdTipoComprobante
		               ,PEP.Letra
		               ,PEP.CentroEmisor
		               ,PEP.NumeroPedido
                     FROM PedidosEstadosProveedores PEP")

         .AppendLine(" WHERE PEP.IdSucursal = " & IdSucursal.ToString())

         .AppendFormat("   AND PEP.IdTipoComprobanteFact = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND PEP.LetraFact = '{0}'", letra).AppendLine()
         .AppendFormat("   AND PEP.CentroEmisorFact = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND PEP.NumeroComprobantefact = {0}", numeroPedido).AppendLine()
         .AppendLine("   AND PEP.IdProducto = '" & idProducto & "'")

      End With
      Return GetDataTable(stbQuery)
   End Function


   Public Sub PedidosEstadosProveedores_U_Ped(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                              idProducto As String, fechaEstado As Date, fechaEstadoHasta As Date?, orden As Integer,
                                              idSucursalGenerado As Integer, idTipoComprobanteGenerado As String, letraGenerado As String, centroEmisorGenerado As Integer, numeroPedidoGenerado As Long)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormat("UPDATE PedidosEstadosProveedores")
         If idSucursalGenerado > 0 Then
            .AppendFormat("   SET IdSucursalGenerado = {0}", idSucursalGenerado).AppendLine()
         Else
            .AppendFormat("   SET IdSucursalGenerado = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteGenerado) Then
            .AppendFormat("      ,IdTipoComprobanteGenerado = '{0}'", idTipoComprobanteGenerado).AppendLine()
         Else
            .AppendFormat("      ,IdTipoComprobanteGenerado = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraGenerado) Then
            .AppendFormat("      ,LetraGenerado = '{0}'", letraGenerado).AppendLine()
         Else
            .AppendFormat("      ,LetraGenerado = NULL").AppendLine()
         End If
         If centroEmisorGenerado > 0 Then
            .AppendFormat("      ,CentroEmisorGenerado = {0}", centroEmisorGenerado).AppendLine()
         Else
            .AppendFormat("      ,CentroEmisorGenerado = NULL").AppendLine()
         End If
         If numeroPedidoGenerado > 0 Then
            .AppendFormat("      ,NumeroPedidoGenerado = {0}", numeroPedidoGenerado).AppendLine()
         Else
            .AppendFormat("      ,NumeroPedidoGenerado = NULL").AppendLine()
         End If
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         If fechaEstadoHasta.HasValue Then
            .AppendFormat("   AND FechaEstado >= '{0}'", ObtenerFecha(fechaEstado, True)).AppendLine()
            .AppendFormat("   AND FechaEstado <= '{0}'", ObtenerFecha(fechaEstadoHasta.Value, True)).AppendLine()
         Else
            .AppendFormat("   AND FechaEstado = '{0}'", ObtenerFecha(fechaEstado, True)).AppendLine()
         End If
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
      End With
      Execute(stbQuery)
   End Sub

   Public Sub PedidosEstadosProveedores_U_Remito(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                 idProducto As String, fechaEstado As Date, fechaEstadoHasta As Date?, orden As Integer,
                                                 idSucursalRemito As Integer, idTipoComprobanteRemito As String, letraRemito As String, centroEmisorRemito As Integer, numeroComprobanteRemito As Long)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormat("UPDATE PedidosEstadosProveedores")
         If idSucursalRemito > 0 Then
            .AppendFormat("   SET IdSucursalRemito = {0}", idSucursalRemito).AppendLine()
         Else
            .AppendFormat("   SET IdSucursalRemito = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteRemito) Then
            .AppendFormat("      ,IdTipoComprobanteRemito = '{0}'", idTipoComprobanteRemito).AppendLine()
         Else
            .AppendFormat("      ,IdTipoComprobanteRemito = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraRemito) Then
            .AppendFormat("      ,LetraRemito = '{0}'", letraRemito).AppendLine()
         Else
            .AppendFormat("      ,LetraRemito = NULL").AppendLine()
         End If
         If centroEmisorRemito > 0 Then
            .AppendFormat("      ,CentroEmisorRemito = {0}", centroEmisorRemito).AppendLine()
         Else
            .AppendFormat("      ,CentroEmisorRemito = NULL").AppendLine()
         End If
         If numeroComprobanteRemito > 0 Then
            .AppendFormat("      ,NumeroComprobanteRemito = {0}", numeroComprobanteRemito).AppendLine()
         Else
            .AppendFormat("      ,NumeroComprobanteRemito = NULL").AppendLine()
         End If
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         If fechaEstadoHasta.HasValue Then
            .AppendFormat("   AND FechaEstado >= '{0}'", ObtenerFecha(fechaEstado, True)).AppendLine()
            .AppendFormat("   AND FechaEstado <= '{0}'", ObtenerFecha(fechaEstadoHasta.Value, True)).AppendLine()
         Else
            .AppendFormat("   AND FechaEstado = '{0}'", ObtenerFecha(fechaEstado, True)).AppendLine()
         End If
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()
      End With
      Execute(stbQuery)
   End Sub

   Public Sub PedidosEstadosProveedores_U_OP(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                             idProducto As String, fechaEstado As Date, fechaEstadoHasta As Date?, orden As Integer,
                                             idSucursalProduccion As Integer, idTipoComprobanteProduccion As String, letraProduccion As String, centroEmisorProduccion As Integer, numeroOrdenProduccion As Long,
                                             idProductoProduccion As String, ordenProduccion As Integer)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormat("UPDATE PedidosEstadosProveedores")
         If idSucursalProduccion > 0 Then
            .AppendFormat("   SET IdSucursalProduccion = {0}", idSucursalProduccion).AppendLine()
         Else
            .AppendFormat("   SET IdSucursalProduccion = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteProduccion) Then
            .AppendFormat("      ,IdTipoComprobanteProduccion = '{0}'", idTipoComprobanteProduccion).AppendLine()
         Else
            .AppendFormat("      ,IdTipoComprobanteProduccion = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraProduccion) Then
            .AppendFormat("      ,LetraProduccion = '{0}'", letraProduccion).AppendLine()
         Else
            .AppendFormat("      ,LetraProduccion = NULL").AppendLine()
         End If
         If centroEmisorProduccion > 0 Then
            .AppendFormat("      ,CentroEmisorProduccion = {0}", centroEmisorProduccion).AppendLine()
         Else
            .AppendFormat("      ,CentroEmisorProduccion = NULL").AppendLine()
         End If
         If numeroOrdenProduccion > 0 Then
            .AppendFormat("      ,NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()
         Else
            .AppendFormat("      ,NumeroOrdenProduccion = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProductoProduccion) Then
            .AppendFormat("      ,IdProductoProduccion = '{0}'", idProductoProduccion).AppendLine()
         Else
            .AppendFormat("      ,IdProductoProduccion = NULL").AppendLine()
         End If
         If ordenProduccion > 0 Then
            .AppendFormat("      ,OrdenProduccion = {0}", ordenProduccion).AppendLine()
         Else
            .AppendFormat("      ,OrdenProduccion = NULL").AppendLine()
         End If
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()
         If fechaEstadoHasta.HasValue Then
            .AppendFormat("   AND FechaEstado >= '{0}'", ObtenerFecha(fechaEstado, True)).AppendLine()
            .AppendFormat("   AND FechaEstado <= '{0}'", ObtenerFecha(fechaEstadoHasta.Value, True)).AppendLine()
         Else
            .AppendFormat("   AND FechaEstado = '{0}'", ObtenerFecha(fechaEstado, True)).AppendLine()
         End If
         .AppendFormat("   AND IdProducto = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND Orden = {0}", orden).AppendLine()

      End With
      Execute(stbQuery)
   End Sub

   Public Function PedidosEstadosProveedores_G_PorComprobanteGenerado(idSucursalGenerado As Integer, idTipoComprobanteGenerado As String, letraGenerado As String, centroEmisorGenerado As Short, numeroPedidoGenerado As Long) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery)
      With stbQuery
         .AppendLine(" WHERE 1 = 1")
         If idSucursalGenerado > 0 Then
            .AppendFormat("   AND PE.IdSucursalGenerado = {0}", idSucursalGenerado).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteGenerado) Then
            .AppendFormat("   AND PE.IdTipoComprobanteGenerado = '{0}'", idTipoComprobanteGenerado).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraGenerado) Then
            .AppendFormat("   AND PE.LetraGenerado = '{0}'", letraGenerado).AppendLine()
         End If
         If centroEmisorGenerado > 0 Then
            .AppendFormat("   AND PE.CentroEmisorGenerado = {0}", centroEmisorGenerado).AppendLine()
         End If
         If numeroPedidoGenerado > 0 Then
            .AppendFormat("   AND PE.NumeroPedidoGenerado = {0}", numeroPedidoGenerado).AppendLine()
         End If
         '.AppendLine(" ORDER BY p.fechaPedido")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function PedidosEstadosProveedores_G_PorComprobanteProduccion(idSucursalProduccion As Integer, idTipoComprobanteProduccion As String, letraProduccion As String, centroEmisorProduccion As Integer, numeroOrdenProduccion As Long,
                                                                        idProducto As String, orden As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery)
      With stbQuery
         .AppendLine(" WHERE 1 = 1")
         If idSucursalProduccion > 0 Then
            .AppendFormat("   AND PE.IdSucursalProduccion = {0}", idSucursalProduccion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteProduccion) Then
            .AppendFormat("   AND PE.IdTipoComprobanteProduccion = '{0}'", idTipoComprobanteProduccion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraProduccion) Then
            .AppendFormat("   AND PE.LetraProduccion = '{0}'", letraProduccion).AppendLine()
         End If
         If centroEmisorProduccion > 0 Then
            .AppendFormat("   AND PE.CentroEmisorProduccion = {0}", centroEmisorProduccion).AppendLine()
         End If
         If numeroOrdenProduccion > 0 Then
            .AppendFormat("   AND PE.NumeroOrdenProduccion = {0}", numeroOrdenProduccion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND PE.IdProductoProduccion = '{0}'", idProducto).AppendLine()
         End If
         If orden > 0 Then
            .AppendFormat("   AND PE.OrdenProduccion = {0}", orden).AppendLine()
         End If
         '.AppendLine(" ORDER BY p.fechaPedido")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidoParaVincular(idEstado As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT PE.IdSucursal, PE.IdTipoComprobante, TC.DescripcionAbrev, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden")
         .AppendLine("     , P.IdProveedor")
         .AppendLine("     , C.CodigoProveedor")
         .AppendLine("     , C.NombreProveedor")
         .AppendLine("     , PE.IdProducto")
         .AppendLine("     , PP.NombreProducto")
         .AppendLine("     , PE.IdEstado")
         .AppendLine("     , PE.CantEstado")
         .AppendLine("     , P.IdComprador")

         .AppendLine("     , E.NombreEmpleado AS NombreComprador")
         .AppendLine("     , P.FechaPedido")
         .AppendLine("     , PE.FechaEstado")
         .AppendLine("     , PE.Observacion")

         .AppendLine("     , CONVERT(INT, NULL) AS IdSucursalVinculado")
         .AppendLine("     , '' AS IdTipoComprobanteVinculado")
         .AppendLine("     , '' AS DescripcionAbrevVinculado")
         .AppendLine("     , '' AS LetraVinculado")
         .AppendLine("     , CONVERT(INT, NULL) AS CentroEmisorVinculado")
         .AppendLine("     , CONVERT(INT, NULL) AS NumeroPedidoVinculado")
         .AppendLine("     , CONVERT(INT, NULL) AS OrdenVinculado")
         .AppendLine("     , CONVERT(DATETIME, NULL) AS FechaEstadoVinculado")
         .AppendLine("     , '' AS IdProductoVinculado")
         .AppendLine("     , '' AS NombreClienteVinculado")
         .AppendLine("     , '' AS Vinculado")
         .AppendLine("  FROM PedidosEstadosProveedores PE")
         .AppendLine(" INNER JOIN PedidosProductosProveedores PP ON PP.IdSucursal = PE.IdSucursal AND PP.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = PE.Letra AND PP.CentroEmisor = PE.CentroEmisor AND PP.NumeroPedido = PE.NumeroPedido")
         .AppendLine("                               AND PP.Orden = PE.Orden AND PP.IdProducto = PE.IDProducto")
         .AppendLine(" INNER JOIN PedidosProveedores P ON P.IdSucursal = PE.IdSucursal AND P.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine("                     AND P.Letra = PE.Letra AND P.CentroEmisor = PE.CentroEmisor AND P.NumeroPedido = PE.NumeroPedido")
         .AppendLine(" INNER JOIN Proveedores C ON C.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = P.IdComprador ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendFormat(" WHERE PE.IdEstado = '{0}'", idEstado).AppendLine()

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Sub PedidosEstadosProveedores_U_FechaEntrega(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                                       idproducto As String, fechaEstado As Date, orden As Integer, fechaEntrega As Date)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstadosProveedores")
         .AppendLine("   SET FechaEntrega = '" & ObtenerFecha(fechaEntrega, True) & "'")
         .AppendLine(" WHERE idSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante.ToString() & "'")
         .AppendLine("   AND Letra = '" & letra.ToString() & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroPedido = " & numeroPedido.ToString())
         '.AppendLine("   AND FechaEstado = '" & ObtenerFecha(fechaEstado, True) & "'")
         .AppendLine("   AND IdProducto = '" & idproducto & "'")
         .AppendLine("   AND Orden = " & orden.ToString)

      End With
      Execute(stbQuery)
   End Sub

End Class