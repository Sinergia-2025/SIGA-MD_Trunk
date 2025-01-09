Public Class Stock
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Stock"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

#End Region

#Region "Metodos Publicos"

   Public Function GetDetallePorProducto(idSucursal As Integer,
                                         desde As Date, hasta As Date,
                                         idTipoMovimiento As String,
                                         idTipoComprobante As String,
                                         idLote As String) As DataTable
      Return GetDetallePorProducto(idSucursal, desde, hasta, idTipoMovimiento, idTipoComprobante, idLote,
                                   idProducto:="", marca:=0, rubro:=0, idSubRubro:=0, idCliente:=0, idProveedor:=0,
                                   idEmpleado:=0)
   End Function


   Public Function GetDetallePorProducto(idSucursal As Integer,
                                         desde As Date, hasta As Date,
                                         idTipoMovimiento As String,
                                         idTipoComprobante As String,
                                         idLote As String,
                                         idProducto As String,
                                         marca As Integer,
                                         rubro As Integer,
                                         idSubRubro As Integer,
                                         idCliente As Long,
                                         idProveedor As Long,
                                         idEmpleado As Integer) As DataTable
      Dim IdSucAsociada = New Reglas.Sucursales(da).GetUna(idSucursal, False).IdSucursalAsociada
      Dim stb = New StringBuilder()
      With stb
         'Obtengo los Movimiento del tipo "Compras"
         .AppendLine("SELECT MC.FechaMovimiento")
         .AppendLine("     , MC.IdTipoMovimiento")
         .AppendLine("     , TM.Descripcion as TipoMovimiento")
         .AppendLine("     , MC.NumeroMovimiento")
         .AppendLine("     , TC.Descripcion as TipoComprobante")
         .AppendLine("     , MC.Letra")
         .AppendLine("     , MC.CentroEmisor")
         .AppendLine("     , MC.NumeroComprobante")
         .AppendLine("     , P.IdProveedor AS IdClienteProveedor")
         .AppendLine("     , P.CodigoProveedor AS CodigoClienteProveedor")
         .AppendLine("     , P.NombreProveedor AS NombreClienteProveedor")
         .AppendLine("     , RIGHT(REPLICATE(' ',15) + MCP.IdProducto,15) as IdProducto")
         .AppendLine("     , MCP.Precio")
         .AppendLine("     ,  (CASE WHEN MCP.Cantidad > 0 THEN MCP.Cantidad ELSE 0 END) AS INGRESO ")
         .AppendLine("     ,  (CASE WHEN MCP.Cantidad < 0 THEN MCP.Cantidad ELSE 0 END) AS EGRESO")
         ' .AppendLine("     , MCP.Cantidad")
         .AppendLine("     , S.Nombre as NombreSucursalDeA")

         'No mostraba los movimientos desde Stock, ejemplo: AJUSTE.
         .AppendLine("     , (CASE WHEN CP.NombreProducto IS NULL THEN Prod.NombreProducto ELSE CP.NombreProducto END) AS NombreProducto")
         .AppendLine("     , M.NombreMarca")
         .AppendLine("     , R.NombreRubro")
         .AppendLine("     , SR.NombreSubRubro")
         .AppendLine("     , MC.Usuario")
         .AppendLine("     , MCP.IdLote")
         .AppendLine("     , MC.Observacion")
         .AppendLine("     , MC.IdEmpleado")
         .AppendLine("     , E.NombreEmpleado")
         .AppendLine("     , TM.MuestraCombo")
         .AppendLine("     , MC.IdProduccion")
         .AppendLine("     , Prod.IdFormula")
         .AppendLine("  FROM MovimientosStock MC")
         .AppendLine(" LEFT JOIN TiposMovimientos TM ON  MC.IdTipoMovimiento = TM.IdTipoMovimiento")
         .AppendLine(" INNER JOIN MovimientosStockProductos MCP ON MC.IdSucursal = MCP.IdSucursal ")
         .AppendLine(" AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento ")
         .AppendLine(" AND MC.NumeroMovimiento = MCP.NumeroMovimiento ")
         .AppendLine(" INNER JOIN Productos Prod ON MCP.IdProducto = Prod.IdProducto ")
         .AppendLine(" LEFT OUTER JOIN Sucursales S ON MC.IdSucursal2 = S.IdSucursal ")
         .AppendLine(" LEFT OUTER JOIN Proveedores P ON MC.IdProveedor = P.IdProveedor ")
         .AppendLine(" LEFT OUTER JOIN TiposComprobantes TC ON MC.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" LEFT OUTER JOIN SubRubros SR ON Prod.IdSubrubro = SR.IdSubrubro ")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = Prod.IdMarca ")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = Prod.IdRubro ")
         .AppendLine(" LEFT JOIN Empleados E ON E.IdEmpleado = MC.IdEmpleado ")
         .AppendLine(" LEFT JOIN ComprasProductos CP ")
         .AppendLine(" ON CP.IdSucursal = MC.IdSucursal ")
         .AppendLine(" AND CP.IdTipoComprobante = MC.IdTipoComprobante")
         .AppendLine(" AND CP.Letra = MC.Letra")
         .AppendLine(" AND CP.CentroEmisor = MC.CentroEmisor")
         .AppendLine(" AND CP.NumeroComprobante = MC.NumeroComprobante")
         .AppendLine(" AND CP.IdProveedor = MC.IdProveedor")
         .AppendLine(" AND CP.IdProducto = MCP.IdProducto")
         .AppendLine(" AND CP.Orden = MCP.Orden")

         .AppendLine("  WHERE ")

         If IdSucAsociada > 0 Then
            .AppendLine("	  (MC.IdSucursal = " & idSucursal.ToString())
            .AppendLine("	   OR MC.IdSucursal = " & IdSucAsociada.ToString() & ")")
         Else
            .AppendLine("	  MC.IdSucursal = " & idSucursal.ToString())
         End If

         .AppendLine("	  AND MC.FechaMovimiento >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("	  AND MC.FechaMovimiento <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If Not String.IsNullOrEmpty(idLote) Then
            .AppendFormat("	AND MCP.IdLote = '{0}'", idLote).AppendLine()
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND MCP.IdProducto = '" & idProducto & "'")
         End If

         If Not String.IsNullOrEmpty(idTipoMovimiento) Then
            .AppendLine("  AND TM.IdTipoMovimiento = '" & idTipoMovimiento & "'")
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("  AND MC.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If marca > 0 Then
            .AppendLine("  AND Prod.IdMarca = " & marca.ToString())
         End If

         If rubro > 0 Then
            .AppendLine("  AND Prod.IdRubro = " & rubro.ToString())
         End If

         If idSubRubro > 0 Then
            .AppendLine("  AND Prod.IdSubRubro = " & idSubRubro.ToString())
         End If

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If idCliente > 0 Then
            .AppendLine("	AND 1 = 2") 'Fuerzo que no devuelva nada en Compras
         End If

         'SI FILTRA POR CLIENTE
         If idEmpleado > 0 Then
            .AppendFormat("	AND MC.IdEmpleado = {0}", idEmpleado)
         Else
            'SI NO FILTRA POR CLIENTE HAGO EL UNION CON MovimientosVentas.
            'SI FILTRO POR CLIENTE NO HAGO EL UNION PORQUE MovimientosVentas 
            '     NO TIENE EMPLEADO Y NO VALE LA PENA PENALIZAR LA PERFORMACE

            .AppendLine("UNION ALL")

            'Obtengo los Movimiento del tipo "Ventas"
            .AppendLine("SELECT MV.FechaMovimiento")
            .AppendLine("     , MV.IdTipoMovimiento")
            .AppendLine("     , TM.Descripcion as TipoMovimiento")
            .AppendLine("     , MV.NumeroMovimiento")
            .AppendLine("     , TC.Descripcion as TipoComprobante")
            .AppendLine("     , MV.Letra")
            .AppendLine("     , MV.CentroEmisor")
            .AppendLine("     , MV.NumeroComprobante")
            .AppendLine("     , C.IdCliente AS IdClienteProveedor")
            .AppendLine("     , C.CodigoCliente AS CodigoClienteProveedor")
            .AppendLine("     , C.NombreCliente AS NombreClienteProveedor")
            .AppendLine("     , RIGHT(REPLICATE(' ',15) + MVP.IdProducto,15) AS IdProducto")
            .AppendLine("     , MVP.Precio")
            .AppendFormatLine(",  (CASE WHEN ISNULL(MVPL.Cantidad, MVP.Cantidad) > 0 THEN ISNULL(MVPL.Cantidad, MVP.Cantidad) ELSE 0 END) AS INGRESO")
            .AppendFormatLine(",  (CASE WHEN ISNULL(MVPL.Cantidad, MVP.Cantidad) < 0 THEN ISNULL(MVPL.Cantidad, MVP.Cantidad) ELSE 0 END) AS EGRESO ")
            '.AppendLine("     , MVP.Cantidad")
            .AppendLine("     , '' AS NombreSucursalDeA, VP.NombreProducto, M.NombreMarca, R.NombreRubro, SR.NombreSubRubro")
            .AppendLine("     , MV.Usuario, MVPL.IdLote, MV.Observacion")
            .AppendLine("     , NULL IdEmpleado")
            .AppendLine("     , NULL NombreEmpleado")
            .AppendLine("     , TM.MuestraCombo")
            .AppendLine("     , NULL IdProduccion")
            .AppendLine("     , Prod.IdFormula")
            .AppendLine("  FROM TiposMovimientos TM ")
            .AppendLine("  LEFT JOIN MovimientosStock MV ON MV.IdTipoMovimiento = TM.IdTipoMovimiento ")
            .AppendLine("  INNER JOIN MovimientosStockProductos MVP ON MV.IdSucursal = MVP.IdSucursal AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento AND MV.NumeroMovimiento = MVP.NumeroMovimiento ")
            .AppendFormatLine("  LEFT JOIN MovimientosStockProductosLotes MVPL ON MV.IdSucursal = MVPL.IdSucursal AND MV.IdTipoMovimiento = MVPL.IdTipoMovimiento AND MV.NumeroMovimiento = MVPL.NumeroMovimiento AND MVP.IdProducto = MVPL.IdProducto AND MVP.Orden = MVPL.Orden")
            .AppendLine("  INNER JOIN Productos Prod ON MVP.IdProducto = Prod.IdProducto ")
            .AppendLine("  INNER JOIN Clientes C ON MV.IdCliente = C.IdCliente ")
            .AppendLine("  INNER JOIN TiposComprobantes TC ON MV.IdTipoComprobante = TC.IdTipoComprobante ")
            .AppendLine("  LEFT OUTER JOIN SubRubros SR ON Prod.IdSubrubro = SR.IdSubrubro ")
            .AppendLine("  LEFT JOIN Marcas M ON M.IdMarca = Prod.IdMarca ")
            .AppendLine("  LEFT JOIN Rubros R ON R.IdRubro = Prod.IdRubro ")
            .AppendLine("  LEFT JOIN VentasProductos VP ")
            .AppendLine(" 	ON VP.IdSucursal = MV.IdSucursal ")
            .AppendLine("  AND VP.IdTipoComprobante = MV.IdTipoComprobante")
            .AppendLine("	AND VP.Letra = MV.Letra")
            .AppendLine(" 	AND VP.CentroEmisor = MV.CentroEmisor")
            .AppendLine("  AND VP.NumeroComprobante = MV.NumeroComprobante")
            .AppendLine("  AND VP.IdProducto = MVP.IdProducto")
            .AppendLine(" 	AND VP.Orden = MVP.Orden")

            .AppendLine("  WHERE ")

            If IdSucAsociada > 0 Then
               .AppendLine("	  (MV.IdSucursal = " & idSucursal.ToString())
               .AppendLine("	   OR MV.IdSucursal = " & IdSucAsociada.ToString() & ")")
            Else
               .AppendLine("	  MV.IdSucursal = " & idSucursal.ToString())
            End If

            '.AppendLine("	  AND CONVERT(varchar(11), MV.FechaMovimiento, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
            '.AppendLine("	  AND CONVERT(varchar(11), MV.FechaMovimiento, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	  AND MV.FechaMovimiento >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	  AND MV.FechaMovimiento <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

            If Not String.IsNullOrEmpty(idLote) Then
               .AppendFormat("	AND MVPL.IdLote = '{0}'", idLote).AppendLine()
            End If

            If Not String.IsNullOrEmpty(idProducto) Then
               .AppendLine("	AND MVP.IdProducto = '" & idProducto & "'")
            End If

            If Not String.IsNullOrEmpty(idTipoMovimiento) Then
               .AppendLine("  AND TM.IdTipoMovimiento = '" & idTipoMovimiento & "'")
            End If

            If Not String.IsNullOrEmpty(idTipoComprobante) Then
               .AppendLine("  AND MV.IdTipoComprobante = '" & idTipoComprobante & "'")
            End If

            If marca > 0 Then
               .AppendLine("  AND Prod.IdMarca = " & marca.ToString())
            End If

            If rubro > 0 Then
               .AppendLine("  AND Prod.IdRubro = " & rubro.ToString())
            End If

            If idSubRubro > 0 Then
               .AppendLine("  AND Prod.IdSubRubro = " & idSubRubro.ToString())
            End If

            If idCliente > 0 Then
               .AppendLine("	AND C.IdCliente = " & idCliente)
            End If

            If idProveedor > 0 Then
               .AppendLine("	AND 1 = 2") 'Fuerzo que no devuelva nada en Ventas
            End If

         End If            ' ELSE - If Not String.IsNullOrWhiteSpace(tipoDocEmpleado) AndAlso Not String.IsNullOrWhiteSpace(nroDocEmpleado) Then
         .AppendLine(" ORDER BY 1")

      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetInformeDetallePorProducto(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                                                idTipoMovimiento As String, idTipoComprobante As String,
                                                idProducto As String, idLote As String,
                                                marcas As Entidades.Marca(), modelos As Entidades.Modelo(), rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(),
                                                subsubrubros As Entidades.SubSubRubro(),
                                                idCliente As Long, idProveedor As Long, idEmpleado As Integer) As DataTable
      Return New SqlServer.Stock(da).
                  GetInformeDetallePorProducto(sucursales, desde, hasta, idTipoMovimiento, idTipoComprobante,
                                               idProducto, idLote,
                                               marcas, modelos, rubros, subrubros, subsubrubros,
                                               idCliente, idProveedor, idEmpleado)
   End Function

   Public Function GetInformeDetallePorProductoNrosSerie(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito(),
                                                         idTipoMovimiento As String, idTipoComprobante As String,
                                                         desde As Date, hasta As Date,
                                                         idEmpleado As Integer,
                                                         idProducto As String, nroSerie As String, idLote As String,
                                                         idCliente As Long, idProveedor As Long,
                                                         marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                                         rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataTable
      Return New SqlServer.Stock(da).GetInformeDetallePorProductoNrosSerie(sucursales, depositos, idTipoMovimiento, idTipoComprobante, desde, hasta, idEmpleado,
                                                                           idProducto, nroSerie, idLote, idCliente, idProveedor,
                                                                           marcas, modelos, rubros, subRubros, subSubRubros)
   End Function

   Public Function GetResumenPorProducto(sucursal As Integer,
                                         desde As Date, hasta As Date,
                                         tipoMovimiento As String,
                                         idProducto As String,
                                         idMarca As Integer,
                                         idRubro As Integer,
                                         idSubRubro As Integer,
                                         idCliente As Long,
                                         idProveedor As Long,
                                         mostrarProdSinMov As Boolean) As DataTable
      Return New SqlServer.Stock(da).GetResumenPorProducto(sucursal, desde, hasta, tipoMovimiento, idProducto, idMarca, idRubro, idSubRubro, idCliente, idProveedor, mostrarProdSinMov)
   End Function

   Public Function GetProductosLotes(sucursales() As Integer,
                                     desde As Date, hasta As Date,
                                     soloVencidos As Boolean,
                                     idProducto As String,
                                     idMarca As Integer,
                                     idRubro As Integer,
                                     idSubRubro As Integer,
                                     conStock As Boolean,
                                     depositos As Entidades.SucursalDeposito(),
                                     stockUnificado As Boolean,
                                     tipoDeposito As Entidades.SucursalDeposito.TiposDepositos?) As DataTable

      Return New SqlServer.Stock(da).GetProductosLotes(sucursales, desde, hasta, soloVencidos, idProducto, idMarca, idRubro, idSubRubro,
                                                       conStock, depositos, stockUnificado, tipoDeposito)


   End Function

   Public Function GetProductosNumeroDeSerie(sucursales As Entidades.Sucursal(), idMarca As Integer, idRubro As Integer, idSubRubro As Integer, idProducto As String, idProveedor As Long,
                                             disponible As Entidades.Publicos.SiNoTodos, nroSerie As String) As DataTable
      Dim sql = New SqlServer.Stock(da)
      Dim dt = sql.GetProductosNumeroDeSerie(sucursales, idMarca, idRubro, idSubRubro, idProducto, idProveedor, disponible, nroSerie)
      If Not dt.Columns.Contains("Disponible") Then
         dt.Columns.Add("Disponible", GetType(Boolean))
         For Each fila As DataRow In dt.Rows
            fila("Disponible") = Not CBool(fila("Vendido"))
         Next
      End If
      Return dt
   End Function


   Public Class GetSaldoDetallePorProductoResult
      Public Property SaldoInicial As Decimal
      Public Property SaldoInicialDefectuoso As Decimal
      Public Property SaldoInicialReservado As Decimal
      Public Property SaldoInicialFuturo As Decimal
      Public Property SaldoInicialFuturoReservado As Decimal

   End Class
   Public Function GetSaldoDetallePorProducto(idSucursal As Integer, desde As Date, hasta As Date, idProducto As String) As GetSaldoDetallePorProductoResult
      Dim result = New GetSaldoDetallePorProductoResult()
      Dim IdSucAsociada = New Sucursales(da).GetUna(idSucursal, False).IdSucursalAsociada

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MCP.IdProducto, SUM(MCP.Cantidad) as Cantidad ")
         '.AppendLine("      ,SUM(MCP.CantidadDefectuoso) AS CantidadDefectuoso")
         '.AppendLine("      ,SUM(MCP.CantidadReservado) AS CantidadReservado")
         '.AppendLine("      ,SUM(MCP.CantidadFuturo) AS CantidadFuturo")
         '.AppendLine("      ,SUM(MCP.CantidadFuturoReservado) AS CantidadFuturoReservado")
         .AppendLine("  FROM MovimientosStock MC, MovimientosStockProductos MCP ")
         .AppendLine(" WHERE MC.IdSucursal = MCP.IdSucursal ")
         .AppendLine("   AND MC.IdTipoMovimiento = MCP.IdTipoMovimiento ")
         .AppendLine("   AND MC.NumeroMovimiento = MCP.NumeroMovimiento ")

         If IdSucAsociada > 0 Then
            .AppendLine("	  AND (MC.IdSucursal = " & idSucursal.ToString())
            .AppendLine("	   OR MC.IdSucursal = " & IdSucAsociada.ToString() & ")")
         Else
            .AppendLine("	  AND MC.IdSucursal = " & idSucursal.ToString())
         End If

         .AppendLine("	 AND CONVERT(varchar(11), MC.FechaMovimiento, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	 AND CONVERT(varchar(11), MC.FechaMovimiento, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	 AND MCP.IdProducto = '" & idProducto & "'")

         .AppendLine(" GROUP BY MCP.IdProducto ")

      End With

      Dim dt As DataTable
      'Dim decSaldo As Decimal = 0

      dt = Me.DataServer.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         result.SaldoInicial = Decimal.Parse(dt.Rows(0).Item("Cantidad").ToString)

         'result.SaldoInicialDefectuoso = Decimal.Parse(dt.Rows(0).Item("CantidadDefectuoso").ToString)
         'result.SaldoInicialReservado = Decimal.Parse(dt.Rows(0).Item("CantidadReservado").ToString)
         'result.SaldoInicialFuturo = Decimal.Parse(dt.Rows(0).Item("CantidadFuturo").ToString)
         'result.SaldoInicialFuturoReservado = Decimal.Parse(dt.Rows(0).Item("CantidadFuturoReservado").ToString)
      End If

      'With stb
      '   .Length = 0

      '   .AppendLine("SELECT MVP.IdProducto, SUM(MVP.Cantidad) as Cantidad ")
      '   .AppendLine("  FROM MovimientosStock MV, MovimientosStockProductos MVP ")
      '   .AppendLine(" WHERE MV.IdSucursal = MVP.IdSucursal ")
      '   .AppendLine("   AND MV.IdTipoMovimiento = MVP.IdTipoMovimiento ")
      '   .AppendLine("   AND MV.NumeroMovimiento = MVP.NumeroMovimiento ")

      '   If IdSucAsociada > 0 Then
      '      .AppendLine("	  AND (MV.IdSucursal = " & idSucursal.ToString())
      '      .AppendLine("	   OR MV.IdSucursal = " & IdSucAsociada.ToString() & ")")
      '   Else
      '      .AppendLine("	  AND MV.IdSucursal = " & idSucursal.ToString())
      '   End If

      '   .AppendLine("	 AND CONVERT(varchar(11), MV.FechaMovimiento, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
      '   .AppendLine("	 AND CONVERT(varchar(11), MV.FechaMovimiento, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
      '   .AppendLine("	 AND MVP.IdProducto = '" & idProducto & "'")

      '   .AppendLine(" GROUP BY MVP.IdProducto ")

      'End With

      'dt = Me.DataServer.GetDataTable(stb.ToString())

      'If dt.Rows.Count > 0 Then
      '   result.SaldoInicial = result.SaldoInicial + Decimal.Parse(dt.Rows(0).Item("Cantidad").ToString)
      'End If

      Return result

   End Function


   Public Function GetProductosMasMovimientos(sucursal As Integer,
                                              desde As Date, hasta As Date,
                                              tipoMovimiento As String,
                                              cantidad As Integer,
                                              orden As String,
                                              idMarca As Integer,
                                              idRubro As Integer,
                                              idSubRubro As Integer,
                                              idCliente As Long,
                                              idProveedor As Long) As DataTable
      Dim sql As SqlServer.Stock = New SqlServer.Stock(da)
      Dim dt As DataTable = sql.GetProductosMasMovimientos(actual.Sucursal.Id,
                                                           desde, hasta, tipoMovimiento, cantidad, orden,
                                                           idMarca, idRubro, idSubRubro, idCliente, idProveedor)
      Return dt
   End Function

#End Region

#Region "Overrides"


#End Region

#Region "Metodos Control de Stock para Facturacion"
#Region "Metodos Publicos"
   Public Function ControlarStockVenta(idSucursal As Integer, tipoComprobante As Entidades.TipoComprobante,
                                       ventasProductos As List(Of Entidades.VentaProducto),
                                       comprobantesSeleccionados As List(Of Entidades.Venta),
                                       idProductoInsertar As String, cantidadInsertar As Decimal) As Entidades.ProductosSinStock()
      Return EjecutaConConexion(Function() _ControlarStockVenta(idSucursal, tipoComprobante, ventasProductos, comprobantesSeleccionados, idProductoInsertar, cantidadInsertar))
   End Function
   Public Function ControlarStockVenta(idSucursal As Integer, tipoComprobante As Entidades.TipoComprobante,
                                       ventasProductos As List(Of Entidades.VentaProducto),
                                       comprobantesSeleccionados As List(Of Entidades.Venta)) As Entidades.ProductosSinStock()
      Return EjecutaConConexion(Function() _ControlarStockVenta(idSucursal, tipoComprobante, ventasProductos, comprobantesSeleccionados, idProductoInsertar:=String.Empty, cantidadInsertar:=0))
   End Function
#End Region

#Region "Metodos Privados"
   Private Function _ControlarStockVenta(idSucursal As Integer, tipoComprobante As Entidades.TipoComprobante,
                                         ventasProductos As List(Of Entidades.VentaProducto),
                                         comprobantesSeleccionados As List(Of Entidades.Venta),
                                         idProductoInsertar As String, cantidadInsertar As Decimal) As Entidades.ProductosSinStock()
      'Determino si se debe o no controlar Stock
      'Tiene en cuenta:
      '     1.- Si el tipo de comprobante descuenta stock
      '        1.1.- Si el coeficiente de stock es 0, pero está parametrizado para que lo haga, controla de todas maneras
      '        1.2.- Si el comprobante invocado ya descontó stock no controla, ya que yo no voy a descontar, ya se hizo
      '     2.- Si está seteado que permite stock negativo directamente no controla (no tiene sentido procesar si no se va a controlar)
      If DeterminarSiControlaStock(tipoComprobante, comprobantesSeleccionados) Then
         'Lista con los productos sin stock a retornar
         Dim result = New List(Of Entidades.ProductosSinStock)()

         'En caso de estar controlando el agregado de un producto, aquí guardo su ID o el ID de los componentes a controlar
         Dim idProductosControlar As String() = {}

         'Acumulado de cantidad para cada IdProducto. En caso de ser un producto Compuesto aquí se guardan sus compuestos con sus cantidades.
         Dim productosConCantidad = New Dictionary(Of String, Decimal)()
         'Cache de productos livianos para control de stock (en caso de que se repita el producto no vuelvo a BD)
         Dim productos = New Dictionary(Of String, Entidades.ProductoLivianoParaControlStock)()


         'Si estoy agregando un producto al comprobante idProductoInsertar recibe el producto que se quiere agregar
         If Not String.IsNullOrWhiteSpace(idProductoInsertar) Then
            'Agrego el producto que se está agregando a productosConCantidad para acumular la cantidad del mismo
            AgregaProducto(idSucursal, idProductoInsertar, cantidadInsertar, productosConCantidad, productos)
            'En idProductosControlar guardo la lista de productos que debo controlar al final si estoy agregando un producto
            idProductosControlar = (From p In productosConCantidad Select p.Key Distinct).ToArray()
         End If

         Dim oInvocadoPedido As Boolean = False
         'Agrego cada producto en VentasProductos a productosConCantidad junto con los componentes que correspondan
         For Each vp In ventasProductos
            AgregaProducto(idSucursal, vp.IdProducto, vp.Cantidad, productosConCantidad, productos)
            '-- REQ-32986.- -----------------------------
            If vp.InvocaDesdePedido Then
               oInvocadoPedido = True
            End If
            '--------------------------------------------
         Next
         '-- REQ-32986.- -----------------------------
         Dim eEstadoPedido = New EstadosPedidos().GetUno(Publicos.EstadoPedidoPendiente, "PEDIDOSCLIE")
         '--------------------------------------------

         'Realizo el control de stock para todos los productos
         For Each prodCantidad In productosConCantidad
            'El Producto Liviano donde tengo el Stock disponible
            Dim prodLiviando As Entidades.ProductoLivianoParaControlStock = productos(prodCantidad.Key)
            If prodLiviando.AfectaStock Then

               'Si el Stock disponible es inferior a la cantidad cargada en la venta se agrega el registro en ProductosSinStock
               Dim stock = prodLiviando.Stock
               '-- REQ-32986.- -----------------------------
               If oInvocadoPedido Then
                  If eEstadoPedido.ReservaStock Then
                     stock += prodLiviando.StockReservado
                  End If
               End If
               '--------------------------------------------
               If stock < prodCantidad.Value Then
                  result.Add(New Entidades.ProductosSinStock(prodLiviando, prodCantidad.Value, prodLiviando.Stock))
               End If
            End If
         Next

         If String.IsNullOrWhiteSpace(idProductoInsertar) Then
            'Si estoy validando una grabación (idProductoInsertar es blanco) devuelvo la lista de productos sin stock completa
            Return result.ToArray()
         Else
            'Si estoy agregando un producto a la venta (idProductoInsertar tiene valor) devuelvo solo los productos a controlar
            Return result.Where(Function(x) idProductosControlar.Contains(x.Producto.IdProducto)).ToArray()
         End If

      Else
         'Si no debo controlar stock devuelvo una array vacio
         Return {}
      End If

   End Function

   Private Sub AgregaProducto(idSucursal As Integer,
                              idProducto As String,
                              cantidad As Decimal,
                              productosConCantidad As Dictionary(Of String, Decimal),
                              productos As Dictionary(Of String, Entidades.ProductoLivianoParaControlStock))

      'Busco el producto en el Cache de Productos Livianos
      Dim prod As Entidades.ProductoLivianoParaControlStock = GetProducto(idSucursal, idProducto, productos)

      'Si el producto EsCompuesto y debe DescontarStockComponentes entonces evaluo sus componentes
      If prod.EsCompuesto And prod.DescontarStockComponentes Then
         AgregarComponentesCantidadProductos(idSucursal, productos, productosConCantidad, prod.IdProducto, prod.IdFormula, cantidad)
      Else
         'En caso de no existir el producto en productosConCantidad lo agrego en 0 para luego acumular
         If Not productosConCantidad.ContainsKey(prod.IdProducto) Then
            productosConCantidad.Add(prod.IdProducto, 0)
         End If
         'Acumulo la cantidad dada para luego controlar el stock
         productosConCantidad(prod.IdProducto) += cantidad
      End If

   End Sub

   Private Function GetProducto(idSucursal As Integer, idProducto As String, productos As Dictionary(Of String, Entidades.ProductoLivianoParaControlStock)) As Entidades.ProductoLivianoParaControlStock
      'Busco el Producto Liviano en el Cache.
      If Not productos.ContainsKey(idProducto) Then
         'Si no lo encuentro lo busco en BD y lo agrego en el mismo
         productos.Add(idProducto, New Reglas.Stock().GetUnoProductoLivianoParaControlStock(idSucursal, idProducto))
      End If
      'Retorno el Producto Liviano del Cache
      Return productos(idProducto)
   End Function

   Private Sub AgregarComponentesCantidadProductos(idSucursal As Integer,
                                                   productos As Dictionary(Of String, Entidades.ProductoLivianoParaControlStock),
                                                   productosConCantidad As Dictionary(Of String, Decimal),
                                                   idProductoCompuesto As String, idFormula As Integer, cantidadCompuesto As Decimal)
      Dim rComponentes As New Reglas.ProductosComponentes(da)
      'Busco los componentes del producto compuesto
      Dim dtComponentes As DataTable = rComponentes.GetComponentes(actual.Sucursal.IdSucursal, idProductoCompuesto, idFormula, Publicos.ListaPreciosPredeterminada)

      For Each drComponente As DataRow In dtComponentes.Rows
         Dim idProductoComponente As String = drComponente("IdProductoComponente").ToString()
         Dim cantidadNecesaria As Decimal = drComponente.ValorNumericoPorDefecto("Cantidad", 0D)

         'Agrego el componente a productosConCantidad para acumular la cantidad del mismo
         AgregaProducto(idSucursal, idProductoComponente, cantidadCompuesto * cantidadNecesaria, productosConCantidad, productos)
      Next

   End Sub

   Private Function DeterminarSiControlaStock(tipoComprobante As Entidades.TipoComprobante, comprobantesSeleccionados As List(Of Entidades.Venta)) As Boolean

      'Si permite ingresar movimientos de venta sin Stock, no tiene sentido realizar el control del mismo.
      If Publicos.Facturacion.FacturarSinStock = "PERMITIR" Then
         Return False
      End If

      Dim blnControlarStock As Boolean = False
      'PRIMERO: Cheque si el comprobante afecta stock negativo (solo si descuenta), o no afecta pero en Parametros se configuró que controle igualmente
      '         (los valores posibles para el coeficientestock son 0, 1 y -1)
      If (tipoComprobante.CoeficienteStock < 0) Or
         (tipoComprobante.CoeficienteStock = 0 AndAlso Publicos.Facturacion.FacturarSinStockControlaNoAfectaStock) Then

         'Si NO facturo otros (ej: Factura sin Facturables).
         'O Facturo y ese facturado NO desconto Stock (ej: PRESUPUESTO).
         If comprobantesSeleccionados Is Nothing OrElse comprobantesSeleccionados.Count = 0 OrElse comprobantesSeleccionados(0).TipoComprobante.CoeficienteStock = 0 Then
            blnControlarStock = True
         End If
      End If
      Return blnControlarStock
   End Function
#End Region

#Region "Metodos CargaUno/GerUno - ProductoLivianoParaControlStock"
   Private Sub CargarUno(o As Entidades.ProductoLivianoParaControlStock, dr As DataRow)
      With o
         .IdProducto = dr("IdProducto").ToString()
         .NombreProducto = dr("NombreProducto").ToString()
         .EsCompuesto = Boolean.Parse(dr("EsCompuesto").ToString())
         .DescontarStockComponentes = Boolean.Parse(dr("DescontarStockComponentes").ToString())
         .IdFormula = dr.ValorNumericoPorDefecto("IdFormula", 0I)
         .AfectaStock = Boolean.Parse(dr("AfectaStock").ToString())
         .Stock = dr.ValorNumericoPorDefecto("Stock", 0D)
         '-- REQ-32986.- -----------------------------
         '.StockReservado = dr.ValorNumericoPorDefecto("StockReservado", 0D)
         '--------------------------------------------
      End With
   End Sub
   Private Function GetUnoProductoLivianoParaControlStock(idSucursal As Integer, idProducto As String) As Entidades.ProductoLivianoParaControlStock
      Return CargaEntidad(New SqlServer.Stock(da).GetProductoLivianoParaControlStock(idSucursal, idProducto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoLivianoParaControlStock(),
                          AccionesSiNoExisteRegistro.Excepcion,
                          Function() String.Format("No se encontró información de Stock para el producto {0} en la sucursal {1}",
                                                   idProducto, idSucursal))
   End Function
#End Region
#End Region

End Class