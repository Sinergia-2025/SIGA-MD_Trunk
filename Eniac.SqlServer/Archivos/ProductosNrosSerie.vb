Public Class ProductosNrosSerie
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosNrosSerie_I(IdProducto As String,
                                    NroSerie As String,
                                    IdSucursal As Integer,
                                    IdDeposito As Integer,
                                    IdUbicacion As Integer,
                                    Vendido As Boolean,
                                    IdTipoComprobante As String,
                                    Letra As String,
                                    CentroEmisor As Integer,
                                    NumeroComprobante As Long,
                                    ordenCompra As Integer?,
                                   idProveedor As Long)
      Dim qry = New StringBuilder()
      With qry
         .Append("INSERT INTO ProductosNrosSerie (")
         .Append("           IdProducto")
         .Append("           ,NroSerie")
         .Append("           ,IdSucursal")
         .Append("           ,IdDeposito")
         .Append("           ,IdUbicacion")
         .Append("           ,Vendido")
         .Append("           ,IdTipoCompCompra")
         .Append("           ,LetraCompra")
         .Append("           ,CentroEmisorCompra")
         .Append("           ,NumeroComprobanteCompra")
         .Append("           ,IdProveedor")
         .Append("           ,OrdenCompra")
         .Append(")     VALUES(")
         .AppendFormat("           '{0}'", IdProducto)
         .AppendFormat("           ,'{0}'", NroSerie)
         .AppendFormat("           ,{0}", IdSucursal)
         .AppendFormat("           ,{0}", IdDeposito)
         .AppendFormat("           ,{0}", IdUbicacion)
         .AppendFormat("           ,{0}", Me.GetStringFromBoolean(Vendido))
         If Not String.IsNullOrEmpty(IdTipoComprobante) Then
            .Append(" , '" & IdTipoComprobante & "'")
         Else
            .AppendFormatLine(" , NULL")
         End If
         If Not String.IsNullOrEmpty(letra) Then
            .AppendFormatLine(" , '" & letra & "'")
         Else
            .AppendFormatLine(" , NULL")
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine(" , " & centroEmisor.ToString())
         Else
            .AppendFormatLine(" , NULL")
         End If
         If numeroComprobante <> 0 Then
            .AppendFormatLine(" , " & numeroComprobante.ToString())
         Else
            .AppendFormatLine(" , NULL")
         End If
         If idProveedor <> 0 Then
            .AppendFormatLine(" , " & idProveedor.ToString())
         Else
            .AppendFormatLine(" , NULL")
         End If
         If ordenCompra.HasValue Then
            .AppendFormatLine("  ,{0}", ordenCompra.Value)
         Else
            .AppendFormatLine("  ,NULL")
         End If
         .AppendFormatLine(")")
      End With

      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosNrosSerie")
   End Sub

   Public Sub ProductosNrosSerie_U_CambioSucursal(idProducto As String, nroSerie As String, idSucursal As Integer)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosNrosSerie")
         .AppendFormatLine("   SET IdSucursal = {0}", idSucursal)
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND NroSerie = '{0}'", nroSerie)
      End With
      Execute(qry)
   End Sub

   Public Sub ProductosNrosSerie_U(idProducto As String,
                                   nroSerie As String,
                                   idSucursal As Integer,
                                   idTipoCompVenta As String,
                                   letraVenta As String,
                                   centroEmisorVenta As Integer,
                                   numeroComprobanteVenta As Long,
                                   vendido As Boolean,
                                   ordenVenta As Integer?,
                                   ordenCompra As Integer?,
                                   fechaDevolucionVenta As Date?)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosNrosSerie SET ")
         .AppendFormatLine("      Vendido = '{0}' ", GetStringFromBoolean(vendido))
         .AppendFormatLine("      ,IdSucursalVenta = {0}", idSucursal)
         .AppendFormatLine("      ,IdTipoCompVenta = '" & idTipoCompVenta & "'")
         .AppendFormatLine("      ,LetraVenta = '" & letraVenta & "'")
         .AppendFormatLine("      ,CentroEmisorVenta = {0}", centroEmisorVenta)
         .AppendFormatLine("      ,NumeroComprobanteVenta = {0}", numeroComprobanteVenta)

         If ordenVenta.HasValue Then
            .AppendFormatLine("      ,{0} = {1}", Entidades.ProductoNroSerie.Columnas.OrdenVenta.ToString(), ordenVenta.Value)
         Else
            .AppendFormatLine("      ,{0} = NULL", Entidades.ProductoNroSerie.Columnas.OrdenVenta.ToString())
         End If
         If ordenCompra.HasValue Then
            .AppendFormatLine("      ,{0} = {1}", Entidades.ProductoNroSerie.Columnas.OrdenCompra.ToString(), ordenCompra.Value)
         Else
            .AppendFormatLine("      ,{0} = NULL", Entidades.ProductoNroSerie.Columnas.OrdenCompra.ToString())
         End If
         If fechaDevolucionVenta.HasValue Then
            .AppendFormatLine("      ,{0} = '{1}'", Entidades.ProductoNroSerie.Columnas.FechaDevolucionVenta.ToString(), fechaDevolucionVenta.Value)
         Else
            .AppendFormatLine("      ,{0} = NULL", Entidades.ProductoNroSerie.Columnas.FechaDevolucionVenta.ToString())
         End If

         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND NroSerie = '{0}'", nroSerie)
      End With

      Execute(qry)
   End Sub

   Public Sub ProductosNrosSerie_D(idProducto As String, nroSerie As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("DELETE FROM ProductosNrosSerie WHERE ")
         .AppendFormatLine("       IdProducto = '{0}'", idProducto)
         .AppendFormatLine("      AND NroSerie = '{0}'", nroSerie)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosNrosSerie")
   End Sub

   Public Sub ProductosNrosSerie_DProd(idSucursal As Integer, idProducto As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("DELETE FROM ProductosNrosSerie ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosNrosSerie")
   End Sub

   Public Sub ProductosNrosSerie_DComp(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                       idProveedor As Long)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("DELETE FROM ProductosNrosSerie ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoCompCompra = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and LetraCompra = '{0}'", letra)
         .AppendFormatLine("	and CentroEmisorCompra = {0}", centroEmisor)
         .AppendFormatLine("	and NumeroComprobanteCompra = {0}", numeroComprobante)
         .AppendFormatLine("	and IdProveedor = {0}", idProveedor)
         .AppendFormatLine(" AND Vendido = 'False' ")
      End With
      Execute(qry)
   End Sub

   Public Sub ProductosNrosSerie_UVenta(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosNrosSerie SET Vendido = 'False',  ")
         .AppendFormatLine("  IdSucursalVenta = Null, IdTipoCompVenta = Null, LetraVenta = Null, CentroEmisorVenta = Null, NumeroComprobanteVenta = Null, OrdenVenta = NULL, FechaDevolucionVenta = NULL   ")
         .AppendFormatLine(" WHERE IdSucursalVenta = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoCompVenta = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and LetraVenta = '{0}'", letra)
         .AppendFormatLine("	and CentroEmisorVenta = {0}", centroEmisor)
         .AppendFormatLine("	and NumeroComprobanteVenta = {0}", numeroComprobante)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosNrosSerie")
   End Sub
   Public Sub ProductosNrosSerie_ActualizarComprobantePorComprobante(idSucursalVentaActual As Integer,
                           idTipoCompVentaActual As String, letraVentaActual As String, centroEmisorVentaActual As Integer, numeroComprobanteVentaActual As Long,
                           idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Integer, numeroComprobanteNuevo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ProductosNrosSerie")

         .AppendFormatLine("   SET IdTipoCompVenta = '{0}'", idTipoComprobanteNuevo)
         .AppendFormatLine("      ,LetraVenta = '{0}'", letraNuevo)
         .AppendFormatLine("      ,CentroEmisorVenta = {0}", centroEmisorNuevo)
         .AppendFormatLine("      ,NumeroComprobanteVenta = {0}", numeroComprobanteNuevo)

         .AppendFormatLine("   WHERE IdSucursalVenta = {0}", idSucursalVentaActual)
         .AppendFormatLine("     AND IdTipoCompVenta = '{0}'", idTipoCompVentaActual)
         .AppendFormatLine("     AND LetraVenta = '{0}'", letraVentaActual)
         .AppendFormatLine("     AND CentroEmisorVenta = {0}", centroEmisorVentaActual)
         .AppendFormatLine("     AND NumeroComprobanteVenta = {0}", numeroComprobanteVentaActual)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PNS.*")
         .AppendFormatLine("     , P.NombreProducto")
         .AppendFormatLine("  FROM ProductosNrosSerie PNS")
         .AppendFormatLine(" INNER JOIN Productos P ON PNS.IdProducto = P.IdProducto")
      End With
   End Sub

   Public Function ProductosNrosSerie_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function ProductosNrosSerie_G1(IdProducto As String, NroSerie As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE PNS.IdProducto = '{0}'", IdProducto)
         .AppendFormatLine("   AND PNS.NroSerie = '{0}'", NroSerie)
      End With

      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "PNS.",
                    New Dictionary(Of String, String) From {{"NombreProducto", "P.NombreProducto"}})
   End Function

   Public Function GetVendidos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                               idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE PNS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PNS.IdTipoCompCompra = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and PNS.LetraCompra = '{0}'", letra)
         .AppendFormatLine("	and PNS.CentroEmisorCompra = {0}", centroEmisor)
         .AppendFormatLine("	and PNS.NumeroComprobanteCompra = {0}", numeroComprobante)
         .AppendFormatLine("	and PNS.IdProveedor = {0}", idProveedor)
         .AppendFormatLine(" AND Vendido = 'True' ")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetVendido(idSucursal As Integer, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE PNS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PNS.IdProducto = '{0}'", idProducto)
         .AppendFormatLine(" AND PNS.Vendido = 'True' ")
      End With
      Return GetDataTable(stb)
   End Function

   '-- REQ-32489.- ---------------------------------------------------------
   Public Function GetNrosSerieProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" INNER JOIN SucursalesUbicaciones SU")
         .AppendFormatLine("         ON PNS.IdSucursal = SU.IdSucursal")
         .AppendFormatLine("        AND PNS.IdDeposito = SU.IdDeposito")
         .AppendFormatLine("        AND PNS.IdUbicacion = SU.IdUbicacion")
         .AppendFormatLine(" WHERE PNS.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND ((SU.IdSucursal       = {0} AND SU.IdDeposito       = {1} AND SU.IdUbicacion       = {2}) OR", idSucursal, idDeposito, idUbicacion)
         .AppendFormatLine("        (SU.SucursalAsociada = {0} AND SU.DepositoAsociado = {1} AND SU.UbicacionAsociada = {2}))", idSucursal, idDeposito, idUbicacion)
         '.AppendFormatLine("   AND PNS.IdSucursal IN {0}", idSucursal)
         .AppendFormatLine("   AND PNS.Vendido = 'False' ")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetNrosSerieProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, nrosSerie As IEnumerable(Of String), vendido As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      Dim nsCol = nrosSerie.Where(Function(ns) Not String.IsNullOrWhiteSpace(ns)).ToList().ConvertAll(Function(ns) String.Format("'{0}'", ns))
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" INNER JOIN SucursalesUbicaciones SU")
         .AppendFormatLine("         ON PNS.IdSucursal = SU.IdSucursal")
         .AppendFormatLine("        AND PNS.IdDeposito = SU.IdDeposito")
         .AppendFormatLine("        AND PNS.IdUbicacion = SU.IdUbicacion")
         .AppendFormatLine(" WHERE PNS.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND ((SU.IdSucursal       = {0} AND SU.IdDeposito       = {1} AND SU.IdUbicacion       = {2}) OR", idSucursal, idDeposito, idUbicacion)
         .AppendFormatLine("        (SU.SucursalAsociada = {0} AND SU.DepositoAsociado = {1} AND SU.UbicacionAsociada = {2}))", idSucursal, idDeposito, idUbicacion)
         If nsCol.Any Then
            .AppendFormatLine("   AND PNS.NroSerie IN ({0})", String.Join(",", nsCol))
         End If
         If vendido = Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND PNS.Vendido = {0}", GetStringFromBoolean(vendido = Entidades.Publicos.SiNoTodos.SI))
         End If
      End With
      Return GetDataTable(stb)
   End Function
   '--------------------------------------------------------------------------
   Public Function GetNrosSerieProducto_Comprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                                    idProveedor As Long, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE PNS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PNS.IdTipoCompCompra = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and PNS.LetraCompra = '{0}'", letra)
         .AppendFormatLine("	and PNS.CentroEmisorCompra = {0}", centroEmisor)
         .AppendFormatLine("	and PNS.NumeroComprobanteCompra = {0}", numeroComprobante)
         .AppendFormatLine("	and PNS.IdProveedor = {0}", idProveedor)
         .AppendFormatLine("	and PNS.IdProducto = '{0}'", idProducto)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetNrosSerieProducto_ComprobanteVenta(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                                         idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE PNS.IdSucursalVenta = {0}", idSucursal)
         .AppendFormat("   AND PNS.IdTipoCompVenta = '{0}'", idTipoComprobante)
         .AppendFormat("	and PNS.LetraVenta = '{0}'", letra)
         .AppendFormat("	and PNS.CentroEmisorVenta = {0}", centroEmisor)
         .AppendFormat("	and PNS.NumeroComprobanteVenta = {0}", numeroComprobante)
         .AppendFormat("	and PNS.IdProducto = '{0}'", idProducto)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetNrosSerieProductoConsulta(idSucursal As Integer, idProducto As String,
                                                marca As Integer, rubro As Integer, idSubRubro As Integer,
                                                vendidos As Boolean, todos As Boolean, enStock As Boolean) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT NS.IdProducto")
         .AppendFormatLine(" , P.NombreProducto")
         .AppendFormatLine(" , NS.NroSerie")
         .AppendFormatLine(" , PR.NombreProveedor")
         .AppendFormatLine(" , NS.IdTipoCompCompra + '-' + NS.LetraCompra +'-'+ CONVERT(Varchar(20),NS.CentroEmisorCompra) +'-'+ CONVERT(Varchar(20),NS.NumeroComprobanteCompra) as Compra")
         .AppendFormatLine(" , NS.Vendido")
         .AppendFormatLine(" , NS.IdTipoCompVenta +'-'+ NS.LetraVenta +'-'+ CONVERT(Varchar(20),NS.CentroEmisorVenta) +'-'+ CONVERT(Varchar(20),NS.NumeroComprobanteVenta) as Venta")
         .AppendFormatLine(" FROM ProductosNrosSerie NS")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = NS.IdProducto")
         .AppendFormatLine(" INNER JOIN Proveedores PR ON PR.IdProveedor = NS.IdProveedor")
         .AppendFormatLine(" WHERE NS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND NS.IdProducto = '{0}'", idProducto)
         If vendidos = True Then
            .AppendFormatLine(" AND NS.Vendido = 'True'")
         Else
            If enStock = True Then
               .AppendFormatLine(" AND NS.Vendido = 'False'")
            End If
         End If

         If marca <> 0 Then
            .AppendFormatLine(" AND P.IdMarca = " & marca.ToString())
         End If
         If rubro <> 0 Then
            .AppendFormatLine(" AND P.IdRubro = " & rubro.ToString())
         End If
         If idSubRubro <> 0 Then
            .AppendFormatLine(" AND P.IdSubRubro = " & idSubRubro.ToString())
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetNrosSerieProductoClienteVendido(idSucursal As Integer, idProducto As String, idCliente As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT   NS.IdProducto           ,NS.NroSerie           ,NS.IdSucursal           ,NS.Vendido  ")
         .AppendLine(" FROM ProductosNrosSerie NS ")
         .AppendLine(" INNER JOIN Ventas V ON V.IdSucursal = NS.IdSucursalVenta ")
         .AppendLine(" AND V.IdTipoComprobante = NS.IdTipoCompVenta ")
         .AppendLine(" AND V.CentroEmisor = NS.CentroEmisorVenta ")
         .AppendLine(" AND V.Letra = NS.LetraVenta ")
         .AppendLine(" AND V.NumeroComprobante = NS.NumeroComprobanteVenta")
         .AppendFormat(" WHERE NS.IdSucursalVenta = {0}", idSucursal)
         .AppendFormat("   AND V.IdCliente = {0}", idCliente)
         .AppendFormat("	and NS.IdProducto = '{0}'", idProducto)
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub ProductosNrosSerie_UDevolucion(idProducto As String, nroSerie As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosNrosSerie")
         .AppendFormatLine("   SET Vendido = 'False' ")
         .AppendFormatLine("     , IdSucursalVenta = NULL")
         .AppendFormatLine("     , IdTipoCompVenta = NULL")
         .AppendFormatLine("     , LetraVenta = NULL")
         .AppendFormatLine("     , CentroEmisorVenta = NULL")
         .AppendFormatLine("     , NumeroComprobanteVenta = NULL")
         .AppendFormatLine("     , OrdenVenta = NULL")
         .AppendFormatLine("     , FechaDevolucionVenta = NULL")
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND NroSerie = '{0}'", nroSerie)
      End With

      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosNrosSerie")
   End Sub
   Public Sub ProductosNrosSerie_U_VendidoMPPorGeneraPT(idProducto As String, nroSerie As String, vendido As Boolean)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosNrosSerie")
         .AppendFormatLine("   SET Vendido = {0}", GetStringFromBoolean(vendido))
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND NroSerie = '{0}'", nroSerie)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosNrosSerie")
   End Sub

   Public Sub ProductosNrosSerie_U_DepositoVendido(idProducto As String, nroSerie As String, iddeposito As Integer, idubicacion As Integer, vendido As Boolean)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosNrosSerie")
         .AppendFormatLine("   SET idDeposito = {0}", iddeposito)
         .AppendFormatLine("  , idUbicacion = {0}", idubicacion)
         .AppendFormatLine("  , Vendido = {0}", GetStringFromBoolean(vendido))
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND NroSerie = '{0}'", nroSerie)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosNrosSerie")
   End Sub

   Public Function Existe(idProducto As String, nroSerie As String) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT IdProducto FROM ProductosNrosSerie ")
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND NroSerie = '{0}'", nroSerie)
      End With

      Return GetDataTable(stb).Any()
   End Function

   Public Function EstaVendido(idProducto As String, nroSerie As String, vendido As Boolean) As Boolean
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT PNS.Vendido FROM ProductosNrosSerie PNS")
         .AppendFormatLine("	WHERE PNS.IdProducto = '{0}' ", idProducto)
         .AppendFormatLine("	AND PNS.NroSerie = '{0}'", nroSerie)
         .AppendFormatLine("	AND PNS.Vendido = {0}", GetStringFromBoolean(vendido))
      End With
      Return GetDataTable(query).Any()
   End Function

   Public Function GetEstadoComprobanteAnteriorAFecha(idSucursal As Integer, idTipoComprobante As String,
                                                      idProducto As String, nroSerie As String,
                                                      fecha As Date, esDeVenta As Boolean) As DataTable
      '# Este script es utilizado tanto para Compras como para Ventas.
      Dim tabla As String = If(esDeVenta, "V", "C")

      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT TOP(1)")
         .AppendFormatLine("	 M{0}P.NumeroMovimiento", tabla)
         .AppendFormatLine("	,M{0}.FechaMovimiento", tabla)
         .AppendFormatLine("	,M{0}.IdSucursal", tabla)
         .AppendFormatLine("	,M{0}.IdTipoComprobante", tabla)
         .AppendFormatLine("	,M{0}.Letra", tabla)
         .AppendFormatLine("	,M{0}.CentroEmisor", tabla)
         .AppendFormatLine("	,M{0}.NumeroComprobante", tabla)
         If esDeVenta Then
            .AppendFormatLine("  ,VP.FechaDevolucion") '# Solo de Venta
         Else
            .AppendFormatLine("  ,MC.IdProveedor") '# Solo de Compra
         End If
         .AppendFormatLine("	, M{0}PNS.*", tabla)
         .AppendFormatLine("FROM {1} M{0}PNS", tabla, Entidades.MovimientoStockProductoNrosSerie.NombreTabla)
         .AppendFormatLine("  INNER JOIN {1} M{0} ON M{0}PNS.IdSucursal = M{0}.IdSucursal", tabla, Entidades.MovimientoStock.NombreTabla)
         .AppendFormatLine("									 AND M{0}PNS.IdTipoMovimiento = M{0}.IdTipoMovimiento", tabla)
         .AppendFormatLine("									 AND M{0}PNS.NumeroMovimiento = M{0}.NumeroMovimiento", tabla)
         .AppendFormatLine("  LEFT JOIN {1} M{0}P ON M{0}P.IdSucursal = M{0}P.IdSucursal", tabla, Entidades.MovimientoStockProducto.NombreTabla)
         .AppendFormatLine("									 AND M{0}PNS.IdTipoMovimiento = M{0}P.IdTipoMovimiento", tabla)
         .AppendFormatLine("									 AND M{0}PNS.NumeroMovimiento = M{0}P.NumeroMovimiento", tabla)
         .AppendFormatLine("									 AND M{0}PNS.Orden = M{0}P.Orden", tabla)
         .AppendFormatLine("									 AND M{0}PNS.IdProducto = M{0}P.IdProducto", tabla)
         .AppendFormatLine("  LEFT JOIN {1} {0}P ON M{0}.IdSucursal = {0}P.IdSucursal", tabla, If(esDeVenta, Entidades.VentaProducto.NombreTabla, Entidades.CompraProducto.NombreTabla))
         .AppendFormatLine("								 AND M{0}.IdTipoComprobante = {0}P.IdTipoComprobante", tabla)
         .AppendFormatLine("								 AND M{0}.Letra = {0}P.Letra", tabla)
         .AppendFormatLine("								 AND M{0}.CentroEmisor = {0}P.CentroEmisor", tabla)
         .AppendFormatLine("								 AND M{0}.NumeroComprobante = {0}P.NumeroComprobante", tabla)
         .AppendFormatLine("								 AND M{0}P.Orden = {0}P.Orden", tabla)
         .AppendFormatLine("								 AND M{0}P.IdProducto = {0}P.IdProducto", tabla)
         .AppendFormatLine("  WHERE 1=1")
         .AppendFormatLine("	AND M{1}PNS.IdProducto = '{0}'", idProducto, tabla)
         .AppendFormatLine("	AND M{1}PNS.NroSerie = '{0}'", nroSerie, tabla)
         .AppendFormatLine("	AND M{1}.IdTipoComprobante <> '{0}'", idTipoComprobante, tabla)
         .AppendFormatLine("	AND M{1}.FechaMovimiento < '{0}'", ObtenerFecha(fecha, True), tabla)
         .AppendFormatLine("ORDER BY M{0}.FechaMovimiento DESC", tabla)
      End With
      Return GetDataTable(query)
   End Function

End Class