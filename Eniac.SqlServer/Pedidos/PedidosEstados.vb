Public Class PedidosEstados
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT PE.*, EP.IdTipoEstado")
         .AppendLine("      ,PE.CantEstado AS CantEntregada")
         .AppendLine("      ,ISNULL(PE.IdDepositoAnterior,0) as IdDepositoDefecto")
         .AppendLine("      ,ISNULL(PE.IdUbicacionAnterior,0) as IdUbicacionDefecto")
         .AppendLine("  FROM PedidosEstados PE")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PE.")
   End Function

   Public Sub PedidosEstados_D(idSucursal As Integer,
                               idTipoComprobante As String, letra As String,
                               centroEmisor As Integer, numeroPedido As Long,
                               orden As Integer?, idProducto As String,
                               fechaEstado As Date?)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM PedidosEstados")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroPedido = {0}", numeroPedido)
         If orden.HasValue Then
            .AppendFormatLine("   AND Orden = {0}", orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         End If
         If fechaEstado.HasValue Then
            .AppendFormatLine("   AND FechaEstado = '{0}'", ObtenerFecha(fechaEstado.Value, True))
         End If
         'If Not String.IsNullOrWhiteSpace(IdEstado) Then
         '   .AppendFormat("   AND IdEstado = '{0}'", IdEstado)
         '   .AppendFormat("   AND TipoEstadoPedido = '{0}'", TipoEstadoPedido)
         'End If
      End With
      Execute(stb)
   End Sub

   Public Function PedidosEstados_GA() As DataTable
      Return PedidosEstados_G(Nothing, String.Empty, String.Empty, Nothing, Nothing, Nothing, String.Empty, Nothing, String.Empty)
   End Function

   Public Function PedidosEstados_GA(idSucursal As Integer,
                                     idTipoComprobante As String, letra As String,
                                     centroEmisor As Integer, numeroPedido As Long,
                                     Optional idTipoEstado As String = "") As DataTable
      Return PedidosEstados_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, Nothing, String.Empty, Nothing, idTipoEstado)
   End Function

   Public Function PedidosEstados_GA(idSucursal As Integer,
                                     idTipoComprobante As String, letra As String,
                                     centroEmisor As Integer, numeroPedido As Long,
                                     orden As Integer?, idProducto As String) As DataTable
      Return PedidosEstados_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, Nothing, String.Empty)
   End Function

   Public Function PedidosEstados_G1(idSucursal As Integer,
                                     idTipoComprobante As String, letra As String,
                                     centroEmisor As Integer, numeroPedido As Long,
                                     orden As Integer, idProducto As String,
                                     fechaEstado As Date) As DataTable
      Return PedidosEstados_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido, orden, idProducto, fechaEstado, String.Empty)
   End Function

   Private Function PedidosEstados_G(idSucursal As Integer?,
                                     idTipoComprobante As String, letra As String,
                                     centroEmisor As Integer?, numeroPedido As Long?,
                                     orden As Integer?, idProducto As String,
                                     fechaEstado As Date?,
                                     idTipoEstado As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal.HasValue Then
            .AppendFormatLine("   AND PE.IdSucursal = {0}", idSucursal.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND PE.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND PE.Letra = '{0}'", letra)
         End If
         If centroEmisor.HasValue Then
            .AppendFormatLine("   AND PE.CentroEmisor = {0}", centroEmisor.Value)
         End If
         If numeroPedido.HasValue Then
            .AppendFormatLine("   AND PE.NumeroPedido = {0}", numeroPedido.Value)
         End If
         If orden.HasValue Then
            .AppendFormatLine("   AND PE.Orden = {0}", orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND PE.IdProducto = '{0}'", idProducto)
         End If
         If fechaEstado.HasValue Then
            .AppendFormatLine("   AND PE.FechaEstado = '{0}'", ObtenerFecha(fechaEstado.Value, True))
         End If
         If Not String.IsNullOrWhiteSpace(idTipoEstado) Then
            .AppendFormatLine("   AND EP.IdTipoEstado = '{0}'", idTipoEstado)
         End If
         .AppendFormatLine(" ORDER BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden, PE.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Private Function PedidosEstados_G_PorPedidoGenerado(idSucursal As Integer,
                                                       idTipoComprobante As String, letra As String,
                                                       centroEmisor As Integer, numeroPedido As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PE.*, EP.IdTipoEstado")
         .AppendLine("  FROM (SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido")
         .AppendLine("          FROM PedidosEstados PE1")
         .AppendFormatLine("         WHERE IdSucursalGenerado = {0}", idSucursal)
         .AppendFormatLine("           AND IdTipoComprobanteGenerado = '{0}'", idTipoComprobante)
         .AppendFormatLine("           AND LetraGenerado = '{0}'", letra)
         .AppendFormatLine("           AND CentroEmisorGenerado = {0}", centroEmisor)
         .AppendFormatLine("           AND NumeroPedidoGenerado = {0}", numeroPedido)
         .AppendLine("         GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido) P")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = P.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")

         .AppendFormat(" ORDER BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden, PE.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Private Function PedidosEstados_G_PorPedidoProduccion(idSucursal As Integer,
                                                         idTipoComprobante As String, letra As String,
                                                         centroEmisor As Integer, numeroOrdenProduccion As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PE.*, EP.IdTipoEstado")
         .AppendLine("  FROM (SELECT IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido")
         .AppendLine("          FROM PedidosEstados PE1")
         .AppendFormatLine("         WHERE IdSucursalProduccion = {0}", idSucursal)
         .AppendFormatLine("           AND IdTipoComprobanteProduccion = '{0}'", idTipoComprobante)
         .AppendFormatLine("           AND LetraProduccion = '{0}'", letra)
         .AppendFormatLine("           AND CentroEmisorProduccion = {0}", centroEmisor)
         .AppendFormatLine("           AND NumeroOrdenProduccion = {0}", numeroOrdenProduccion)
         .AppendLine("         GROUP BY IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroPedido) P")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = P.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")

         .AppendFormat(" ORDER BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden, PE.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function


   Public Sub PedidosEstados_I(idSucursal As Integer,
                               idTipoComprobante As String,
                               letra As String,
                               centroEmisor As Integer,
                               numeroPedido As Long,
                               idproducto As String,
                               fechaEstado As Date,
                               idEstado As String,
                               idUsuario As String,
                               observacion As String,
                               cantEstado As Decimal,
                               idSucursalFact As Integer,
                               idTipoComprobanteFact As String,
                               letraFact As String,
                               centroEmisorFact As Integer,
                               numeroComprobanteFact As Long,
                               orden As Integer,
                               criticidad As String,
                               fechaEntrega As Date?,
                               tipoEstadoPedido As String,
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
                               idSucursalProduccion As Integer,
                               idTipoComprobanteProduccion As String,
                               letraProduccion As String,
                               centroEmisorProduccion As Integer,
                               numeroOrdenProduccion As Long,
                               idSucursalVinculado As Integer,
                               idTipoComprobanteVinculado As String,
                               letraVinculado As String,
                               centroEmisorVinculado As Short,
                               numeroPedidoVinculado As Long,
                               idProductoVinculado As String,
                               ordenVinculado As Integer,
                               fechaEstadoVinculado As Date?,
                               anulacionPorModificacion As Boolean,
                               idSucursalAnterior As Integer,
                               IdDepositoAnterior As Integer,
                               IdUbicacionAnterior As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO PedidosEstados")
         .AppendFormatLine("         ({0}", Entidades.Pedido.Columnas.IdSucursal.ToString())
         .AppendFormatLine("         ,{0}", Entidades.Pedido.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("         ,{0}", Entidades.Pedido.Columnas.Letra.ToString())
         .AppendFormatLine("         ,{0}", Entidades.Pedido.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("         ,{0}", Entidades.Pedido.Columnas.NumeroPedido.ToString())
         .AppendFormatLine("         ,idProducto")
         .AppendFormatLine("         ,fechaEstado")
         .AppendFormatLine("         ,idEstado")
         .AppendFormatLine("         ,TipoEstadoPedido")
         .AppendFormatLine("         ,IdUsuario")
         .AppendFormatLine("         ,observacion")
         .AppendFormatLine("         ,CantEstado")
         .AppendFormatLine("         ,IdSucursalFact")
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

         .AppendFormatLine("         ,IdSucursalProduccion")
         .AppendFormatLine("         ,IdTipoComprobanteProduccion")
         .AppendFormatLine("         ,LetraProduccion")
         .AppendFormatLine("         ,CentroEmisorProduccion")
         .AppendFormatLine("         ,NumeroOrdenProduccion")

         .AppendFormatLine("         ,IdSucursalVinculado")
         .AppendFormatLine("         ,IdTipoComprobanteVinculado")
         .AppendFormatLine("         ,LetraVinculado")
         .AppendFormatLine("         ,CentroEmisorVinculado")
         .AppendFormatLine("         ,NumeroPedidoVinculado")
         .AppendFormatLine("         ,IdProductoVinculado")
         .AppendFormatLine("         ,OrdenVinculado")
         .AppendFormatLine("         ,FechaEstadoVinculado")
         .AppendFormatLine("         ,AnulacionPorModificacion")
         '-- MultiDeposito.- -----------------------------------
         .AppendFormatLine("         ,IdSucursalAnterior")
         .AppendFormatLine("         ,IdDepositoAnterior")
         .AppendFormatLine("         ,IdUbicacionAnterior")
         '------------------------------------------------------
         .AppendFormatLine(" ) VALUES ( ")

         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          ,'{0}'", idTipoComprobante)
         .AppendFormatLine("          ,'{0}'", letra)
         .AppendFormatLine("          , {0} ", centroEmisor)
         .AppendFormatLine("          , {0} ", numeroPedido)
         .AppendFormatLine("          ,'{0}'", idproducto)
         .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaEstado, True))
         .AppendFormatLine("          ,'{0}'", idEstado)
         .AppendFormatLine("          ,'{0}'", tipoEstadoPedido)
         .AppendFormatLine("          ,'{0}'", idUsuario)
         .AppendFormatLine("          ,'{0}'", observacion)
         .AppendFormatLine("          , {0} ", cantEstado)
         If idSucursalFact > 0 Then
            .AppendFormatLine("  ,{0}", idSucursalFact)
         Else
            .AppendFormatLine("  ,{0}", "NULL")
         End If
         If idTipoComprobante = "" Then
            .AppendFormatLine("  ,{0}", "NULL")
         Else
            .AppendFormatLine("  ,'{0}'", idTipoComprobanteFact)
         End If
         If letra = "" Then
            .AppendFormatLine("  ,{0}", "NULL")
         Else
            .AppendFormatLine("  ,'{0}'", letraFact)
         End If
         If centroEmisor = 0 Then
            .AppendFormatLine("   ,{0}", "NULL")
         Else
            .AppendFormatLine("  ,{0}", centroEmisorFact)
         End If
         If numeroComprobanteFact = 0 Then
            .AppendFormatLine("   ,{0}", "NULL")
         Else
            .AppendFormatLine("  ,{0}", numeroComprobanteFact)
         End If
         .AppendFormatLine("  ,{0}", orden)
         .AppendFormatLine("  ,'{0}'", criticidad)

         If fechaEntrega.HasValue Then
            .AppendFormatLine("  ,'{0}'", Me.ObtenerFecha(fechaEntrega.Value(), False))
         Else
            .AppendFormatLine("   ,{0}", "NULL")
         End If

         If numeroReparto > 0 Then
            .AppendFormatLine("   ,{0}", numeroReparto)
         Else
            .AppendFormatLine("   ,{0}", "NULL")
         End If

         'Para FK a PedidosEstados que se generó
         If idSucursalGenerado > 0 Then
            .AppendFormatLine("         ,{0}", idSucursalGenerado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteGenerado) Then
            .AppendFormatLine("         ,'{0}'", idTipoComprobanteGenerado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(letraGenerado) Then
            .AppendFormatLine("         ,'{0}'", letraGenerado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If centroEmisorGenerado > 0 Then
            .AppendFormatLine("         ,{0}", centroEmisorGenerado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If numeroPedidoGenerado > 0 Then
            .AppendFormatLine("         ,{0}", numeroPedidoGenerado)
         Else
            .AppendFormatLine("         ,NULL")
         End If

         'Para FK a Ventas Remitos que se generó
         If idSucursalRemito > 0 Then
            .AppendFormatLine("         ,{0}", idSucursalRemito)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteRemito) Then
            .AppendFormatLine("         ,'{0}'", idTipoComprobanteRemito)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(letraRemito) Then
            .AppendFormatLine("         ,'{0}'", letraRemito)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If centroEmisorRemito > 0 Then
            .AppendFormatLine("         ,{0}", centroEmisorRemito)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If numeroComprobanteRemito > 0 Then
            .AppendFormatLine("         ,{0}", numeroComprobanteRemito)
         Else
            .AppendFormatLine("         ,NULL")
         End If

         'Para FK a OrdenesProduccion que se generó
         If idSucursalProduccion > 0 Then
            .AppendFormatLine("         ,{0}", idSucursalProduccion)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteProduccion) Then
            .AppendFormatLine("         ,'{0}'", idTipoComprobanteProduccion)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(letraProduccion) Then
            .AppendFormatLine("         ,'{0}'", letraProduccion)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If centroEmisorProduccion > 0 Then
            .AppendFormatLine("         ,{0}", centroEmisorProduccion)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If numeroOrdenProduccion > 0 Then
            .AppendFormatLine("         ,{0}", numeroOrdenProduccion)
         Else
            .AppendFormatLine("         ,NULL")
         End If


         'Para FK a PedidosEstadosProveedores que se vinculó
         If idSucursalVinculado > 0 Then
            .AppendFormatLine("         ,{0}", idSucursalVinculado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteVinculado) Then
            .AppendFormatLine("         ,'{0}'", idTipoComprobanteVinculado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(letraVinculado) Then
            .AppendFormatLine("         ,'{0}'", letraVinculado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If centroEmisorVinculado > 0 Then
            .AppendFormatLine("         ,{0}", centroEmisorVinculado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If numeroPedidoVinculado > 0 Then
            .AppendFormatLine("         ,{0}", numeroPedidoVinculado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idProductoVinculado) Then
            .AppendFormatLine("         ,'{0}'", idProductoVinculado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If ordenVinculado > 0 Then
            .AppendFormatLine("         ,{0}", ordenVinculado)
         Else
            .AppendFormatLine("         ,NULL")
         End If
         If fechaEstadoVinculado.HasValue Then
            .AppendFormatLine("         ,'{0}'", ObtenerFecha(fechaEstadoVinculado.Value, True))
         Else
            .AppendFormatLine("         ,NULL")
         End If

         .AppendFormatLine("         , {0}", GetStringFromBoolean(anulacionPorModificacion))

         '-- MultiDeposito.- --------------------------------------------------------------------
         If idSucursalAnterior > 0 Then
            .AppendFormatLine("  ,{0}", idSucursalAnterior)
         Else
            .AppendFormatLine("  ,{0}", "NULL")
         End If
         If IdDepositoAnterior > 0 Then
            .AppendFormatLine("  ,{0}", IdDepositoAnterior)
         Else
            .AppendFormatLine("  ,{0}", "NULL")
         End If
         If IdUbicacionAnterior > 0 Then
            .AppendFormatLine("  ,{0}", IdUbicacionAnterior)
         Else
            .AppendFormatLine("  ,{0}", "NULL")
         End If
         '---------------------------------------------------------------------------------------
         .AppendLine(")")

      End With

      Execute(myQuery)

   End Sub

   Public Sub PedidosEstados_U_Cantidad(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                        idproducto As String, orden As Integer, fechaEstado As Date,
                                        deltaCantEstado As Decimal)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstados")
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

   Public Sub PedidosEstados_U_Estado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                      idproducto As String, fechaEstado As Date,
                                      idEstado As String,
                                      tipoEstadoPedido As String,
                                      cantEstado As Decimal,
                                      fechaNuevoEstado As Date,
                                      observacion As String,
                                      orden As Integer,
                                      criticidad As String,
                                      fechaEntrega As Date?,
                                      numeroReparto As Integer,
                                      anulacionPorModificacion As Boolean)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstados")
         .AppendLine("   SET CantEstado = " & cantEstado.ToString)
         .AppendLine("      ,IdEstado = '" & idEstado & "'")
         .AppendFormat("      ,TipoEstadoPedido = '{0}'", tipoEstadoPedido).AppendLine()
         .AppendLine("      ,FechaEstado = '" & ObtenerFecha(fechaNuevoEstado, True) & "'")
         .AppendLine("      ,Observacion = '" & observacion & "'")
         If Not String.IsNullOrEmpty(criticidad) Then
            .AppendLine("      ,IdCriticidad = '" & criticidad & "'")
         End If
         If fechaEntrega.HasValue Then
            .AppendLine("      ,FechaEntrega = '" & ObtenerFecha(fechaEntrega.Value, True) & "'")
         End If
         If numeroReparto > 0 Then
            .AppendLine("      ,NumeroReparto = " & numeroReparto)
         End If
         .AppendFormatLine("      ,AnulacionPorModificacion = {0}", GetStringFromBoolean(anulacionPorModificacion))

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


   Public Sub PedidosEstados_U_Anular_Estado(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                   idproducto As String, fechaEstado As Date, orden As Integer,
                                   idEstadoNuevo As String,
                                   tipoEstadoPedidoNuevo As String,
                                   fechaNuevoEstado As Date,
                                   observacion As String)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("UPDATE PedidosEstados")
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

   Public Sub PedidosEstados_U_Anular_Fact(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numeroPedido As Long,
                                      idproducto As String,
                                      fechaEstado As Date,
                                      orden As Integer)

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("UPDATE PedidosEstados")
         .AppendLine("   SET IdSucursalFact = null ")
         .AppendLine("      ,IdTipoComprobanteFact = null ")
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

   Public Sub PedidosEstados_U_Libera_Produccion(idSucursalProduccion As Integer,
                                                 idTipoComprobanteProduccion As String,
                                                 letraProduccion As String,
                                                 centroEmisorProduccion As Integer,
                                                 numeroPedidoProduccion As Long,
                                                 idproductoProduccion As String,
                                                 ordenProduccion As Integer)

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendFormatLine("UPDATE PedidosEstados")
         .AppendFormatLine("   SET IdSucursalProduccion = NULL ")
         .AppendFormatLine("      ,IdTipoComprobanteProduccion = NULL ")
         .AppendFormatLine("      ,LetraProduccion = NULL ")
         .AppendFormatLine("      ,CentroEmisorProduccion = NULL ")
         .AppendFormatLine("      ,NumeroOrdenProduccion = NULL ")
         .AppendFormatLine("      ,IdProductoProduccion = NULL ")
         .AppendFormatLine("      ,OrdenProduccion = NULL ")
         .AppendFormatLine(" WHERE IdSucursalProduccion = {0}", idSucursalProduccion)
         .AppendFormatLine("   AND IdTipoComprobanteProduccion = '{0}'", idTipoComprobanteProduccion)
         .AppendFormatLine("   AND LetraProduccion = '{0}'", letraProduccion)
         .AppendFormatLine("   AND CentroEmisorProduccion = {0}", centroEmisorProduccion)
         .AppendFormatLine("   AND NumeroOrdenProduccion = {0}", numeroPedidoProduccion)
         If Not String.IsNullOrWhiteSpace(idproductoProduccion) Then
            .AppendFormatLine("   AND IdProductoProduccion = '{0}'", idproductoProduccion)
         End If
         If ordenProduccion > 0 Then
            .AppendFormatLine("   AND OrdenProduccion = {0}", ordenProduccion)
         End If
      End With

      Execute(stbQuery)

   End Sub

   Public Sub PedidosEstados_U_Anular_Remito(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numeroPedido As Long,
                                      idproducto As String,
                                      fechaEstado As Date,
                                      orden As Integer)

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("UPDATE PedidosEstados")
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

   Public Sub PedidosEstados_U_Fact(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Integer,
                                    numeroPedido As Long,
                                    idProducto As String,
                                    fechaEstado As Date,
                                    idSucursalFact As Integer,
                                    idTipoComprobanteFact As String,
                                    letraFact As String,
                                    centroEmisorFact As Integer,
                                    numeroComprobanteFact As Long,
                                    orden As Integer)

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .Length = 0
         .AppendLine("UPDATE PedidosEstados")
         .AppendLine("   SET IdSucursalFact = " & idSucursalFact.ToString())
         .AppendLine("      ,IdTipoComprobanteFact = '" & idTipoComprobanteFact & "'")
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
         .AppendLine("   AND Orden = " & orden.ToString)
      End With

      Execute(stbQuery)

   End Sub

   Public Sub PedidosEstados_U_Remito(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numeroPedido As Long,
                                      idProducto As String,
                                      fechaEstado As Date,
                                      idSucursalRemito As Integer,
                                      idTipoComprobanteRemito As String,
                                      letraRemito As String,
                                      centroEmisorRemito As Integer,
                                      numeroComprobanteRemito As Long,
                                      Orden As Integer)

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .Length = 0
         .AppendLine("UPDATE PedidosEstados")
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
         .AppendLine("   AND Orden = " & Orden.ToString)
      End With

      Execute(stbQuery)

   End Sub

   Public Function PedidosEstados_G_PorComprobanteFact(idSucursalFact As Integer,
                                                       idTipoComprobanteFact As String,
                                                       letraFact As String,
                                                       centroEmisorFact As Short,
                                                       numeroComprobanteFact As Long) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .Length = 0
         .AppendLine("SELECT pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pr.tamano, Pr.IdUnidadDeMedida, pp.Orden")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, PE.TipoEstadoPedido, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE ")
         .AppendLine("           (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE PE.CantEstado END) END) AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,pe.IdSucursalFact,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine("      ,PE.IdCriticidad")
         .AppendLine("      ,PE.FechaEntrega")
         .AppendLine("      ,PE.IdSucursalAnterior")
         .AppendLine("      ,PE.IdDepositoAnterior")
         .AppendLine("      ,PE.IdUbicacionAnterior")

         .AppendLine(" FROM Pedidos P")

         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal ")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Productos Pr ON Pr.IdProducto = pp.IdProducto")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = Pr.IdProducto AND PS.IdSucursal = P.IdSucursal")

         .AppendFormat(" WHERE (PE.IdSucursalFact = {0} AND", idSucursalFact).AppendLine()
         .AppendFormat("        PE.IdTipoComprobanteFact = '{0}' AND", idTipoComprobanteFact).AppendLine()
         .AppendFormat("        PE.LetraFact = '{0}' AND", letraFact).AppendLine()
         .AppendFormat("        PE.CentroEmisorFact = {0} AND", centroEmisorFact).AppendLine()
         .AppendFormat("        PE.NumeroComprobanteFact = {0})", numeroComprobanteFact).AppendLine()

         .AppendFormat("    OR (PE.IdSucursalRemito = {0} AND", idSucursalFact).AppendLine()
         .AppendFormat("        PE.IdTipoComprobanteRemito = '{0}' AND", idTipoComprobanteFact).AppendLine()
         .AppendFormat("        PE.LetraRemito = '{0}' AND", letraFact).AppendLine()
         .AppendFormat("        PE.CentroEmisorRemito = {0} AND", centroEmisorFact).AppendLine()
         .AppendFormat("        PE.NumeroComprobanteRemito = {0})", numeroComprobanteFact).AppendLine()

         .AppendLine(" ORDER BY p.fechaPedido")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetCantidadPedidosEstado(IdSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroPedido As Long,
                                            idEstado As String,
                                            idProducto As String,
                                            orden As Integer) As Decimal

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .AppendLine("SELECT SUM(PEE.CantEstado) as CantEstado")
         .AppendLine(" FROM PedidosEstados PEE")
         .AppendLine(" WHERE   PEE.IdSucursal        = " & IdSucursal.ToString())
         .AppendFormat("   AND PEE.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND PEE.Letra             = '{0}'", letra).AppendLine()
         .AppendFormat("   AND PEE.CentroEmisor      =  {0} ", centroEmisor).AppendLine()
         .AppendFormat("   AND PEE.NumeroPedido      =  {0} ", numeroPedido).AppendLine()
         .AppendFormat("   AND PEE.IdEstado          = '{0}'", idEstado).AppendLine()
         .AppendFormat("   AND PEE.IdProducto        = '{0}'", idProducto).AppendLine()
         .AppendFormat("   AND PEE.Orden             =  {0} ", orden).AppendLine()
      End With
      Dim cantResultado = GetDataTable(stbQuery)

      Return If(String.IsNullOrEmpty(cantResultado.Rows(0)("CantEstado").ToString()), 0, Decimal.Parse(cantResultado.Rows(0)("CantEstado").ToString()))

   End Function

   'TODO: Para revisar
   Public Function GetPedidosEstadosUno(IdSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroPedido As Long,
                                     idProducto As String,
                                     fechaEstado As Date,
                                     orden As Integer) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT '' as Color")
         .AppendLine("      ,'False' as masivo")
         .AppendLine("      ,pe.IdSucursal")
         .AppendLine("      ,P.IdTipoComprobante")
         .AppendLine("      ,P.Letra")
         .AppendLine("      ,P.CentroEmisor")
         .AppendLine("      ,P.NumeroPedido")
         .AppendLine("      ,P.FechaPedido")
         .AppendLine("      ,P.IdCliente, C.NombreCliente")
         ' Agrego orden ############## 17*03*13
         .AppendLine("      ,pp.idProducto, pp.NombreProducto, pp.Precio, pp.Orden")
         .AppendLine("      ,pe.CantEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad ELSE 0 END) AS Cantidad")
         .AppendLine("      ,pe.fechaEstado, PE.IdEstado, PE.TipoEstadoPedido, EP.IdTipoEstado")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE ")
         .AppendLine(" (CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE PE.CantEstado END) END) AS CantEntregada")
         .AppendLine("      ,(CASE WHEN EP.IdTipoEstado = 'EN PROCESO' THEN pp.CantEnProceso ELSE (CASE WHEN EP.IdTipoEstado = 'PENDIENTE' THEN pp.Cantidad-pp.CantEnProceso-pp.CantEntregada ELSE 0 END) END) AS CantPendiente")
         .AppendLine("      ,pe.IdSucursalFact,pe.IdTipoComprobanteFact, pe.LetraFact, pe.CentroEmisorFact, pe.NumeroComprobanteFact")
         .AppendLine("      ,pe.IdSucursalGenerado, pe.IdTipoComprobanteGenerado, pe.LetraGenerado, pe.CentroEmisorGenerado, pe.NumeroPedidoGenerado")
         .AppendLine("      ,pe.IdSucursalRemito, pe.IdTipoComprobanteRemito, pe.LetraRemito, pe.CentroEmisorRemito, pe.NumeroComprobanteRemito")
         .AppendLine("      ,pe.IdSucursalProduccion, pe.IdTipoComprobanteProduccion, pe.LetraProduccion, pe.CentroEmisorProduccion, pe.NumeroOrdenProduccion")
         .AppendLine("      ,pe.IdSucursalVinculado, pe.IdTipoComprobanteVinculado, pe.LetraVinculado, pe.CentroEmisorVinculado, pe.NumeroPedidoVinculado, pe.IdProductoVinculado, pe.OrdenVinculado, pe.FechaEstadoVinculado")
         .AppendLine("      ,pe.IdUsuario")
         .AppendLine("      ,pe.observacion")
         .AppendLine(" FROM Pedidos P")
         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = P.IdSucursal")
         .AppendLine("                               AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = P.Letra")
         .AppendLine("                               AND PP.CentroEmisor = P.CentroEmisor")
         .AppendLine("                               AND PP.NumeroPedido = P.NumeroPedido")
         .AppendLine(" INNER JOIN PedidosEstados PE ON PE.IdSucursal = PP.IdSucursal")
         .AppendLine("                             AND PE.IdTipoComprobante = P.IdTipoComprobante")
         .AppendLine("                             AND PE.Letra = P.Letra")
         .AppendLine("                             AND PE.CentroEmisor = P.CentroEmisor")
         .AppendLine("                             AND PE.NumeroPedido = P.NumeroPedido")
         .AppendLine("                             AND PE.IdProducto = PP.IdProducto")
         .AppendLine("                             AND PE.Orden = PP.Orden")
         .AppendLine(" INNER JOIN EstadosPedidos EP ON EP.IdEstado = PE.IdEstado AND EP.TipoEstadoPedido = PE.TipoEstadoPedido")
         .AppendLine(" INNER JOIN Clientes C ON P.IdCliente = C.IdCliente")
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


   Public Sub PedidosEstados_U_Ped(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Integer,
                                   numeroPedido As Long,
                                   idProducto As String,
                                   fechaEstado As Date,
                                   fechaEstadoHasta As Date?,
                                   orden As Integer,
                                   idSucursalGenerado As Integer,
                                   idTipoComprobanteGenerado As String,
                                   letraGenerado As String,
                                   centroEmisorGenerado As Integer,
                                   numeroPedidoGenerado As Long)

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormat("UPDATE PedidosEstados")
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

   Public Sub PedidosEstados_U_Remito(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroPedido As Long,
                                idProducto As String,
                                fechaEstado As Date,
                                fechaEstadoHasta As Date?,
                                orden As Integer,
                                idSucursalRemito As Integer,
                                idTipoComprobanteRemito As String,
                                letraRemito As String,
                                centroEmisorRemito As Integer,
                                numeroComprobanteRemito As Long)

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormat("UPDATE PedidosEstados")
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

   Public Sub PedidosEstados_U_OP(idSucursal As Integer,
                                  idTipoComprobante As String,
                                  letra As String,
                                  centroEmisor As Integer,
                                  numeroPedido As Long,
                                  idProducto As String,
                                  fechaEstado As Date,
                                  fechaEstadoHasta As Date?,
                                  orden As Integer,
                                  idSucursalProduccion As Integer,
                                  idTipoComprobanteProduccion As String,
                                  letraProduccion As String,
                                  centroEmisorProduccion As Integer,
                                  numeroOrdenProduccion As Long,
                                  idProductoProduccion As String,
                                  ordenProduccion As Integer)

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormat("UPDATE PedidosEstados")
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

   Public Sub PedidosEstados_U_Vinculado(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroPedido As Long,
                                         idProducto As String,
                                         fechaEstado As Date,
                                         fechaEstadoHasta As Date?,
                                         orden As Integer,
                                         idSucursalVinculado As Integer,
                                         idTipoComprobanteVinculado As String,
                                         letraVinculado As String,
                                         centroEmisorVinculado As Integer,
                                         numeroPedidoVinculado As Long,
                                         idProductoVinculado As String,
                                         ordenVinculado As Integer,
                                         fechaEstadoVinculado As DateTime?)

      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormat("UPDATE PedidosEstados")
         If idSucursalVinculado > 0 Then
            .AppendFormat("   SET IdSucursalVinculado = {0}", idSucursalVinculado).AppendLine()
         Else
            .AppendFormat("   SET IdSucursalVinculado = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteVinculado) Then
            .AppendFormat("      ,IdTipoComprobanteVinculado = '{0}'", idTipoComprobanteVinculado).AppendLine()
         Else
            .AppendFormat("      ,IdTipoComprobanteVinculado = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraVinculado) Then
            .AppendFormat("      ,LetraVinculado = '{0}'", letraVinculado).AppendLine()
         Else
            .AppendFormat("      ,LetraVinculado = NULL").AppendLine()
         End If
         If centroEmisorVinculado > 0 Then
            .AppendFormat("      ,CentroEmisorVinculado = {0}", centroEmisorVinculado).AppendLine()
         Else
            .AppendFormat("      ,CentroEmisorVinculado = NULL").AppendLine()
         End If
         If numeroPedidoVinculado > 0 Then
            .AppendFormat("      ,NumeroPedidoVinculado = {0}", numeroPedidoVinculado).AppendLine()
         Else
            .AppendFormat("      ,NumeroPedidoVinculado = NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProductoVinculado) Then
            .AppendFormat("      ,IdProductoVinculado = '{0}'", idProductoVinculado).AppendLine()
         Else
            .AppendFormat("      ,IdProductoVinculado = NULL").AppendLine()
         End If
         If ordenVinculado > 0 Then
            .AppendFormat("      ,OrdenVinculado = {0}", ordenVinculado).AppendLine()
         Else
            .AppendFormat("      ,OrdenVinculado = NULL").AppendLine()
         End If
         If fechaEstadoVinculado.HasValue Then
            .AppendFormat("      ,FechaEstadoVinculado = '{0}'", ObtenerFecha(fechaEstadoVinculado.Value, True)).AppendLine()
         Else
            .AppendFormat("      ,FechaEstadoVinculado = NULL").AppendLine()
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

   Public Function PedidosEstados_G_PorComprobanteGenerado(idSucursalGenerado As Integer,
                                                           idTipoComprobanteGenerado As String,
                                                           letraGenerado As String,
                                                           centroEmisorGenerado As Short,
                                                           numeroPedidoGenerado As Long) As DataTable
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

   Public Function PedidosEstados_G_PorComprobanteProduccion(idSucursalProduccion As Integer,
                                                             idTipoComprobanteProduccion As String,
                                                             letraProduccion As String,
                                                             centroEmisorProduccion As Integer,
                                                             numeroOrdenProduccion As Long,
                                                             idProducto As String,
                                                             orden As Integer) As DataTable
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

   Public Function PedidosEstados_G_PorComprobanteVinculado(idSucursalVinculado As Integer,
                                                            idTipoComprobanteVinculado As String,
                                                            letraVinculado As String,
                                                            centroEmisorVinculado As Integer,
                                                            numeroOrdenVinculado As Long,
                                                            idProductoVinculado As String,
                                                            ordenVinculado As Integer,
                                                            fechaEstado As DateTime?) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery)
      With stbQuery
         .AppendLine(" WHERE 1 = 1")
         If idSucursalVinculado > 0 Then
            .AppendFormat("   AND PE.IdSucursalVinculado = {0}", idSucursalVinculado).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteVinculado) Then
            .AppendFormat("   AND PE.IdTipoComprobanteVinculado = '{0}'", idTipoComprobanteVinculado).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letraVinculado) Then
            .AppendFormat("   AND PE.LetraVinculado = '{0}'", letraVinculado).AppendLine()
         End If
         If centroEmisorVinculado > 0 Then
            .AppendFormat("   AND PE.CentroEmisorVinculado = {0}", centroEmisorVinculado).AppendLine()
         End If
         If numeroOrdenVinculado > 0 Then
            .AppendFormat("   AND PE.NumeroPedidoVinculado = {0}", numeroOrdenVinculado).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProductoVinculado) Then
            .AppendFormat("   AND PE.IdProductoVinculado = '{0}'", idProductoVinculado).AppendLine()
         End If
         If ordenVinculado > 0 Then
            .AppendFormat("   AND PE.OrdenVinculado = {0}", ordenVinculado).AppendLine()
         End If
         If fechaEstado.HasValue Then
            .AppendFormat("   AND PE.FechaEstadoVinculado = '{0}'", ObtenerFecha(fechaEstado.Value, True)).AppendLine()
         End If
         '.AppendLine(" ORDER BY p.fechaPedido")
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPedidoParaVincular(idEstado As String) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT PE.IdSucursal, PE.IdTipoComprobante, TC.DescripcionAbrev, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden")
         .AppendLine("     , P.IdCliente")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , PE.IdProducto")
         .AppendLine("     , PP.NombreProducto")
         .AppendLine("     , PE.IdEstado")
         .AppendLine("     , PE.CantEstado")
         .AppendLine("     , P.IdVendedor")
         .AppendLine("     , E.NombreEmpleado AS NombreVendedor")

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
         .AppendLine("     , '' AS NombreProveedorVinculado")
         .AppendLine("     , '' AS Vinculado")

         .AppendLine("  FROM PedidosEstados PE")
         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = PE.IdSucursal AND PP.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = PE.Letra AND PP.CentroEmisor = PE.CentroEmisor AND PP.NumeroPedido = PE.NumeroPedido")
         .AppendLine("                               AND PP.Orden = PE.Orden AND PP.IdProducto = PE.IDProducto")
         .AppendLine(" INNER JOIN Pedidos P ON P.IdSucursal = PE.IdSucursal AND P.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine("                     AND P.Letra = PE.Letra AND P.CentroEmisor = PE.CentroEmisor AND P.NumeroPedido = PE.NumeroPedido")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = P.IdCliente")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = P.IdVendedor ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendFormat(" WHERE PE.IdEstado = '{0}'", idEstado).AppendLine()


      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Function GetPedidosVinculados(idEstadoCliente As String, idEstadoProveedor As String) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT PE.IdSucursal, PE.IdTipoComprobante, TC.DescripcionAbrev, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.Orden")
         .AppendLine("     , P.IdCliente")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , PE.IdProducto")
         .AppendLine("     , PP.NombreProducto")
         .AppendLine("     , PE.IdEstado")
         .AppendLine("     , PE.CantEstado")
         .AppendLine("     , P.IdVendedor")
         .AppendLine("     , E.NombreEmpleado AS NombreVendedor")

         .AppendLine("     , P.FechaPedido")
         .AppendLine("     , PE.FechaEstado")
         .AppendLine("     , PE.Observacion")
         .AppendLine("     , PE.TipoEstadoPedido")

         .AppendLine("     , PE.IdSucursalVinculado, PE.IdTipoComprobanteVinculado, TCP.DescripcionAbrev DescripcionAbrevVinculado, PE.LetraVinculado")
         .AppendLine("     , PE.CentroEmisorVinculado, PE.NumeroPedidoVinculado, PE.OrdenVinculado")
         .AppendLine("     , PEPR.IdProveedor IdProveedorVinculado")
         .AppendLine("     , PR.CodigoProveedor CodigoProveedorVinculado")
         .AppendLine("     , PR.NombreProveedor NombreProveedorVinculado")
         .AppendLine("     , PE.IdProductoVinculado")
         .AppendLine("     , PEPR.IdEstado IdEstadoVinculado")
         .AppendLine("     , PPR.IdComprador IdCompradorVinculado")
         .AppendLine("     , EPR.NombreEmpleado NombreCompradorVinculado")
         .AppendLine("     , PPR.FechaPedido FechaPedidoVinculado")
         .AppendLine("     , PE.FechaEstadoVinculado")
         .AppendLine("     , PEPR.Observacion ObservacionVinculado")
         .AppendLine("     , PEPR.TipoEstadoPedido TipoEstadoPedidoVinculado")

         .AppendLine("  FROM PedidosEstados PE")
         .AppendLine(" INNER JOIN PedidosProductos PP ON PP.IdSucursal = PE.IdSucursal AND PP.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine("                               AND PP.Letra = PE.Letra AND PP.CentroEmisor = PE.CentroEmisor AND PP.NumeroPedido = PE.NumeroPedido")
         .AppendLine("                               AND PP.Orden = PE.Orden AND PP.IdProducto = PE.IDProducto")
         .AppendLine(" INNER JOIN Pedidos P ON P.IdSucursal = PE.IdSucursal AND P.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendLine("                     AND P.Letra = PE.Letra AND P.CentroEmisor = PE.CentroEmisor AND P.NumeroPedido = PE.NumeroPedido")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = P.IdCliente")
         .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = P.IdVendedor ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = PE.IdTipoComprobante")

         .AppendLine(" INNER JOIN PedidosEstadosProveedores PEPR ON PEPR.IdSucursal = PE.IdSucursalVinculado")
         .AppendLine("                                          AND PEPR.IdTipoComprobante = PE.IdTipoComprobanteVinculado")
         .AppendLine("                                          AND PEPR.Letra = PE.LetraVinculado")
         .AppendLine("                                          AND PEPR.CentroEmisor = PE.CentroEmisorVinculado")
         .AppendLine("                                          AND PEPR.NumeroPedido = PE.NumeroPedidoVinculado")
         .AppendLine("                                          AND PEPR.Orden = PE.OrdenVinculado")
         .AppendLine("                                          AND PEPR.FechaEstado = PE.FechaEstadoVinculado")
         .AppendLine("                                          AND PEPR.IdProducto = PE.IdProductoVinculado")
         .AppendLine(" INNER JOIN TiposComprobantes TCP ON TCP.IdTipoComprobante = PEPR.IdTipoComprobante")
         .AppendLine(" INNER JOIN Proveedores PR ON PR.IdProveedor = PEPR.IdProveedor")
         .AppendLine(" INNER JOIN PedidosProveedores PPR ON PPR.IdSucursal = PEPR.IdSucursal AND PPR.IdTipoComprobante = PEPR.IdTipoComprobante")
         .AppendLine("                                  AND PPR.Letra = PEPR.Letra AND PPR.CentroEmisor = PEPR.CentroEmisor AND PPR.NumeroPedido = PEPR.NumeroPedido")
         .AppendLine(" INNER JOIN Empleados EPR ON EPR.IdEmpleado = PPR.IdComprador ")

         .AppendFormat(" WHERE PE.IdSucursalVinculado IS NOT NULL")
         .AppendFormat("   AND PE.IdEstado = '{0}' AND PEPR.IdEstado = '{1}'", idEstadoCliente, idEstadoProveedor)

      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Sub PedidosEstados_G_ParaGetVinculados_Interno(stb As StringBuilder, tipo As String,
                                                         idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      With stb
         .AppendFormatLine("SELECT PE.IdSucursal, PE.IdTipoComprobante{0} IdTipoComprobante, PE.Letra{0} Letra, PE.CentroEmisor{0} CentroEmisor, PE.NumeroComprobante{0} NumeroComprobante", tipo)
         .AppendFormatLine("     , PE.IdSucursal IdSucursalInvocado, PE.IdTipoComprobante IdTipoComprobanteInvocado, PE.Letra LetraInvocado, PE.CentroEmisor CentroEmisorInvocado, CONVERT(BIGINT, PE.NumeroPedido) NumeroComprobanteInvocado")
         .AppendFormatLine("     , VOrigen.IdCliente, VOrigen.Cuit, VOrigen.Fecha, TCOrigen.Tipo TipoTipoComprobante, TCOrigen.CoeficienteStock")
         .AppendFormatLine("     , VOrigen.IdProveedor, TCOrigen.IdTipoComprobanteContraMovInvocar")
         .AppendFormatLine("     , TCOrigen.Descripcion DescripcionTipoComprobante")
         .AppendFormatLine("     , VDestino.IdCliente IdClienteInvocado, VDestino.Cuit CuitInvocado, VDestino.FechaPedido FechaInvocado, TCDestino.Tipo TipoTipoComprobanteInvocado, TCDestino.CoeficienteStock CoeficienteStockInvocado")
         .AppendFormatLine("     , VOrigen.IdProveedor IdProveedorInvocado, TCOrigen.IdTipoComprobanteContraMovInvocar IdTipoComprobanteContraMovInvocarInvocado")
         .AppendFormatLine("     , TCDestino.Descripcion DescripcionTipoComprobanteInvocado")
         .AppendFormatLine("  FROM PedidosEstados PE")
         .AppendFormatLine(" INNER JOIN Ventas VOrigen ON VOrigen.IdSucursal = PE.IdSucursal{0}", tipo)
         .AppendFormatLine("                          AND VOrigen.IdTipoComprobante = PE.IdTipoComprobante{0}", tipo)
         .AppendFormatLine("                          AND VOrigen.Letra = PE.Letra{0}", tipo)
         .AppendFormatLine("                          AND VOrigen.CentroEmisor = PE.CentroEmisor{0}", tipo)
         .AppendFormatLine("                          AND VOrigen.NumeroComprobante = PE.NumeroComprobante{0}", tipo)
         .AppendFormatLine(" INNER JOIN Pedidos VDestino ON VDestino.IdSucursal = PE.IdSucursal")
         .AppendFormatLine("                            AND VDestino.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendFormatLine("                            AND VDestino.Letra = PE.Letra")
         .AppendFormatLine("                            AND VDestino.CentroEmisor = PE.CentroEmisor")
         .AppendFormatLine("                            AND VDestino.NumeroPedido = PE.NumeroPedido")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TCOrigen ON TCOrigen.IdTipoComprobante = VOrigen.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TCDestino ON TCDestino.IdTipoComprobante = VDestino.IdTipoComprobante")
         .AppendFormatLine(" WHERE PE.IdSucursal{0} = {1}", tipo, idSucursal)
         .AppendFormatLine("   AND PE.IdTipoComprobante{0} = '{1}'", tipo, idTipoComprobante)
         .AppendFormatLine("   AND PE.Letra{0} = '{1}'", tipo, letra)
         .AppendFormatLine("   AND PE.CentroEmisor{0} = {1}", tipo, centroEmisor)
         .AppendFormatLine("   AND PE.NumeroComprobante{0} = {1}", tipo, numeroComprobante)
      End With
   End Sub

   Public Function PedidosEstados_G_ParaGetVinculados(idSucursalInvocador As Integer,
                                                      idTipoComprobanteInvocador As String,
                                                      letraInvocador As String,
                                                      centroEmisorInvocador As Integer,
                                                      numeroOrdenInvocador As Long) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         PedidosEstados_G_ParaGetVinculados_Interno(stbQuery, "Fact",
                                                    idSucursalInvocador, idTipoComprobanteInvocador, letraInvocador, centroEmisorInvocador, numeroOrdenInvocador)

         .AppendFormatLine(" UNION ")

         PedidosEstados_G_ParaGetVinculados_Interno(stbQuery, "Remito",
                                                    idSucursalInvocador, idTipoComprobanteInvocador, letraInvocador, centroEmisorInvocador, numeroOrdenInvocador)

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Sub PedidosEstados_U_CambiarInvocador(tipo As String,
         idSucursalOrigen As Integer, idTipoComprobanteOrigen As String, letraOrigen As String, centroEmisorOrigen As Integer, numeroComprobanteOrigen As Long,
         idSucursalDestino As Integer, idTipoComprobanteDestino As String, letraDestino As String, centroEmisorDestino As Integer, numeroComprobanteDestino As Long)
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("UPDATE PedidosEstados")
         .AppendFormatLine("   SET IdSucursal{0}         =  {1} ", tipo, idSucursalDestino)
         .AppendFormatLine("     , IdTipoComprobante{0}  = '{1}'", tipo, idTipoComprobanteDestino)
         .AppendFormatLine("     , Letra{0}              = '{1}'", tipo, letraDestino)
         .AppendFormatLine("     , CentroEmisor{0}       =  {1} ", tipo, centroEmisorDestino)
         .AppendFormatLine("     , NumeroComprobante{0}  =  {1} ", tipo, numeroComprobanteDestino)

         .AppendFormatLine(" WHERE IdSucursal{0}         =  {1} ", tipo, idSucursalOrigen)
         .AppendFormatLine("   AND IdTipoComprobante{0}  = '{1}'", tipo, idTipoComprobanteOrigen)
         .AppendFormatLine("   AND Letra{0}              = '{1}'", tipo, letraOrigen)
         .AppendFormatLine("   AND CentroEmisor{0}       =  {1} ", tipo, centroEmisorOrigen)
         .AppendFormatLine("   AND NumeroComprobante{0}  =  {1} ", tipo, numeroComprobanteOrigen)
      End With
      Execute(stbQuery)
   End Sub

   Public Function GetPedidosEstadosCantidadSucursalesDepositos(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM PedidosEstados as PE")

         .AppendFormatLine("     INNER JOIN EstadosPedidosSucursales EPS")
         .AppendFormatLine("     	ON PE.IdEstado = EPS.idEstado")

         .AppendFormatLine("     WHERE EPS.IdSucursal = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND EPS.IdDeposito = {0}", IdDeposito)
         End If
      End With

      Return GetDataTable(stb)
   End Function

End Class