Public Class RequerimientosComprasProductosAsignaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RequerimientosComprasProductosAsignaciones_I(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                                           idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long,
                                                           cantidad As Decimal,
                                                           fechaAsignacion As Date, idUsuarioAsignacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.RequerimientoCompraProductoAsignacion.NombreTabla)
         .AppendFormatLine("   ( {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdRequerimientoCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdProducto.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.Orden.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdSucursalPedido.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdTipoComprobantePedido.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.LetraPedido.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.CentroEmisorPedido.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.NumeroPedido.ToString())

         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.Cantidad.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.FechaAsignacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdUsuarioAsignacion.ToString())
         .AppendFormatLine("   ) VALUES (")
         .AppendFormatLine("      {0} ", idRequerimientoCompra)
         .AppendFormatLine("   , '{0}'", idProducto)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   ,  {0} ", idSucursalPedido)
         .AppendFormatLine("   , '{0}'", idTipoComprobantePedido)
         .AppendFormatLine("   , '{0}'", letraPedido)
         .AppendFormatLine("   ,  {0} ", centroEmisorPedido)
         .AppendFormatLine("   ,  {0} ", numeroPedido)

         .AppendFormatLine("   ,  {0} ", cantidad)
         .AppendFormatLine("   , '{0}'", ObtenerFecha(fechaAsignacion, True))
         .AppendFormatLine("   , '{0}'", idUsuarioAsignacion)
         .AppendFormatLine("   )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosComprasProductosAsignaciones")
   End Sub

   Public Sub RequerimientosComprasProductosAsignaciones_U(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                                           idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long,
                                                           cantidad As Decimal,
                                                           fechaAsignacion As Date, idUsuarioAsignacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.RequerimientoCompraProductoAsignacion.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.FechaAsignacion.ToString(), ObtenerFecha(fechaAsignacion, True))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdUsuarioAsignacion.ToString(), GetStringParaQueryConComillas(idUsuarioAsignacion))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdSucursalPedido.ToString(), idSucursalPedido)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdTipoComprobantePedido.ToString(), idTipoComprobantePedido)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.LetraPedido.ToString(), letraPedido)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.CentroEmisorPedido.ToString(), centroEmisorPedido)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.NumeroPedido.ToString(), numeroPedido)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosComprasProductosAsignaciones")
   End Sub

   Public Sub RequerimientosComprasProductosAsignaciones_M(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                                           idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long,
                                                           cantidad As Decimal,
                                                           fechaAsignacion As Date, idUsuarioAsignacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO RequerimientosComprasProductos AS D")
         .AppendFormatLine("        USING (SELECT  {0}  IdRequerimientoCompra,", idRequerimientoCompra)
         .AppendFormatLine("                      '{0}' IdProducto,", idProducto)
         .AppendFormatLine("                       {0}  Orden,", orden)

         .AppendFormatLine("                       {0}  IdSucursalPedido,", idSucursalPedido)
         .AppendFormatLine("                      '{0}' IdTipoComprobantePedido,", idTipoComprobantePedido)
         .AppendFormatLine("                      '{0}' LetraPedido,", letraPedido)
         .AppendFormatLine("                       {0}  CentroEmisorPedido,", centroEmisorPedido)
         .AppendFormatLine("                       {0}  NumeroPedido,", numeroPedido)

         .AppendFormatLine("                       {0}  Cantidad,", cantidad)
         .AppendFormatLine("                       {0}  FechaAsignacion,", ObtenerFecha(fechaAsignacion, True))
         .AppendFormatLine("                       {0}  IdUsuarioAsignacion", GetStringParaQueryConComillas(idUsuarioAsignacion))
         .AppendFormatLine("               ) AS O ON D.IdRequerimientoCompra = O.IdRequerimientoCompra AND D.IdProducto = O.IdProducto AND D.Orden = O.Orden")
         .AppendFormatLine("                     AND D.IdSucursalPedido = O.IdSucursalPedido AND D.IdTipoComprobantePedido = O.IdTipoComprobantePedido AND D.LetraPedido = O.LetraPedido")
         .AppendFormatLine("                     AND D.CentroEmisorPedido = O.CentroEmisorPedido AND D.NumeroPedido = O.NumeroPedido")
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.Cantidad            = O.Cantidad")
         .AppendFormatLine("                 , D.FechaAsignacion     = O.FechaAsignacion")
         .AppendFormatLine("                 , D.IdUsuarioAsignacion = O.IdUsuarioAsignacion")
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT (  IdRequerimientoCompra,   IdProducto,   Orden,   IdSucursalPedido,   IdTipoComprobantePedido,   LetraPedido,   CentroEmisorPedido,   NumeroPedido,   Cantidad,   FechaAsignacion,   IdUsuarioAsignacion)")
         .AppendFormatLine("        VALUES (O.IdRequerimientoCompra, O.IdProducto, O.Orden, O.IdSucursalPedido, O.IdTipoComprobantePedido, O.LetraPedido, O.CentroEmisorPedido, O.NumeroPedido, O.Cantidad, O.FechaAsignacion, O.IdUsuarioAsignacion)")
         .AppendFormatLine(";")
      End With
   End Sub

   Public Sub RequerimientosComprasProductosAsignaciones_D(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                                           idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.RequerimientoCompraProductoAsignacion.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.Orden.ToString(), orden)
         End If

         If idSucursalPedido > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdSucursalPedido.ToString(), idSucursalPedido)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobantePedido) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdTipoComprobantePedido.ToString(), idTipoComprobantePedido)
         End If
         If Not String.IsNullOrWhiteSpace(letraPedido) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.LetraPedido.ToString(), letraPedido)
         End If
         If centroEmisorPedido > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.CentroEmisorPedido.ToString(), centroEmisorPedido)
         End If
         If numeroPedido > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.NumeroPedido.ToString(), numeroPedido)
         End If

      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosComprasProductosAsignaciones")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RCPA.*")
         .AppendFormatLine("  FROM {0} RCPA", Entidades.RequerimientoCompraProductoAsignacion.NombreTabla)
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "RCPA.")
   End Function

   Public Function RequerimientosComprasProductosAsignaciones_GA() As DataTable
      Return RequerimientosComprasProductosAsignaciones_GA(idRequerimientoCompra:=0, idProducto:=String.Empty, orden:=0)
   End Function
   Public Function RequerimientosComprasProductosAsignaciones_GA(idRequerimientoCompra As Long, idProducto As String, orden As Integer) As DataTable
      Return RequerimientosComprasProductosAsignaciones_G(idRequerimientoCompra, idProducto, orden,
                                                          idSucursalPedido:=0, idTipoComprobantePedido:=String.Empty, letraPedido:=String.Empty, centroEmisorPedido:=0, numeroPedido:=0)
   End Function
   Public Function RequerimientosComprasProductosAsignaciones_GA(idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long) As DataTable
      Return RequerimientosComprasProductosAsignaciones_G(idRequerimientoCompra:=0, idProducto:=String.Empty, orden:=0,
                                                          idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido)
   End Function
   Public Function RequerimientosComprasProductosAsignaciones_G(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                                                idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE 1 = 1")
         If idRequerimientoCompra > 0 Then
            .AppendFormatLine("   AND RCPA.{0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND RCPA.{0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND RCPA.{0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.Orden.ToString(), orden)
         End If
         If idSucursalPedido > 0 Then
            .AppendFormatLine("   AND RCPA.{0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdSucursalPedido.ToString(), idSucursalPedido)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobantePedido) Then
            .AppendFormatLine("   AND RCPA.{0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdTipoComprobantePedido.ToString(), idTipoComprobantePedido)
         End If
         If Not String.IsNullOrWhiteSpace(letraPedido) Then
            .AppendFormatLine("   AND RCPA.{0} = '{1}'", Entidades.RequerimientoCompraProductoAsignacion.Columnas.LetraPedido.ToString(), letraPedido)
         End If
         If centroEmisorPedido > 0 Then
            .AppendFormatLine("   AND RCPA.{0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.CentroEmisorPedido.ToString(), centroEmisorPedido)
         End If
         If numeroPedido > 0 Then
            .AppendFormatLine("   AND RCPA.{0} =  {1} ", Entidades.RequerimientoCompraProductoAsignacion.Columnas.NumeroPedido.ToString(), numeroPedido)
         End If

      End With
      Return GetDataTable(stb)
   End Function

   Public Function RequerimientosComprasProductosAsignaciones_G1(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                                                 idSucursalPedido As Integer, idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Integer, numeroPedido As Long) As DataTable
      Return RequerimientosComprasProductosAsignaciones_G(idRequerimientoCompra, idProducto, orden,
                                                          idSucursalPedido, idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido)
   End Function

   Public Function GetParaInfRequerimietos(fechaDesde As Date?, fechaHasta As Date?, fechaEntregaDesde As Date?, fechaEntregaHasta As Date?,
                                           tiposComprobante As Entidades.TipoComprobante(), numeroRequerimiento As Long,
                                           asignados As Entidades.Publicos.SiNoTodos, idUsuario As String,
                                           idProducto As String,
                                           marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                           rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT RCPA.*")
         .AppendFormatLine("     , TCP.Descripcion DescripcionTipoComprobantePedido")
         .AppendFormatLine("     , PR.IdProveedor")
         .AppendFormatLine("     , PR.CodigoProveedor")
         .AppendFormatLine("     , PR.NombreProveedor")
         .AppendFormatLine("  FROM {0} RCPA", Entidades.RequerimientoCompraProductoAsignacion.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} RCP ON RCP.{1} = RCPA.{2} AND RCP.{3} = RCPA.{4} AND RCP.{5} = RCPA.{6}", Entidades.RequerimientoCompraProducto.NombreTabla,
                           Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdRequerimientoCompra.ToString(),
                           Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString(), Entidades.RequerimientoCompraProductoAsignacion.Columnas.IdProducto.ToString(),
                           Entidades.RequerimientoCompraProducto.Columnas.Orden.ToString(), Entidades.RequerimientoCompraProductoAsignacion.Columnas.Orden.ToString())

         .AppendFormatLine(" INNER JOIN {0} RC ON RC.{1} = RCP.{2}", Entidades.RequerimientoCompra.NombreTabla,
                           Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString(), Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString())

         .AppendFormatLine(" INNER JOIN {0} P ON P.{1} = RCP.{2}", Entidades.Producto.NombreTabla, Entidades.Producto.Columnas.IdProducto.ToString(), Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine(" INNER JOIN TiposComprobantes TCP ON TCP.IdTipoComprobante = RCPA.IdTipoComprobantePedido")
         .AppendFormatLine(" INNER JOIN PedidosProveedores PP ON PP.IdSucursal = RCPA.IdSucursalPedido")
         .AppendFormatLine("                                 AND PP.IdTipoComprobante = RCPA.IdTipoComprobantePedido")
         .AppendFormatLine("                                 AND PP.Letra = RCPA.LetraPedido")
         .AppendFormatLine("                                 AND PP.CentroEmisor = RCPA.CentroEmisorPedido")
         .AppendFormatLine("                                 AND PP.NumeroPedido = RCPA.NumeroPedido")
         .AppendFormatLine(" INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor")

         If asignados = Entidades.Publicos.SiNoTodos.NO Then
            .AppendFormatLine(" WHERE 1 = 2")
         Else
            .AppendFormatLine(" WHERE 1 = 1")
         End If

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND RC.{0} BETWEEN '{1}' AND '{2}'", Entidades.RequerimientoCompra.Columnas.Fecha.ToString(), ObtenerFecha(fechaDesde.Value, True), ObtenerFecha(fechaHasta.Value(), True))
         End If
         If fechaEntregaDesde.HasValue Then
            .AppendFormatLine("   AND RCP.{0} BETWEEN '{1}' AND '{2}'", Entidades.RequerimientoCompraProducto.Columnas.FechaEntrega.ToString(), ObtenerFecha(fechaEntregaDesde.Value.Date, False), ObtenerFecha(fechaEntregaHasta.Value.UltimoSegundoDelDia(), True))
         End If

         GetListaTiposComprobantesMultiples(stb, tiposComprobante, "RC")

         If numeroRequerimiento > 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString(), numeroRequerimiento)
         End If

         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString(), idUsuario)
         End If

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
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