Imports Eniac.Entidades.CRMNovedad.CambioMasivo

Public Class ProductosSucursales
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosSucursales_I(idProducto As String,
                                    idSucursal As Integer,
                                    precioFabrica As Decimal,
                                    precioCosto As Decimal,
                                    stock As Decimal,
                                    stock2 As Decimal,
                                    puntoDePedido As Decimal,
                                    stockMinimo As Decimal,
                                    stockMaximo As Decimal,
                                    usuario As String,
                                    ubicacion As String,
                                    idDepositoDefecto As Integer,
                                    idUbicacionDefecto As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO ProductosSucursales")
         .AppendLine("   (IdProducto, ")
         .AppendLine("   IdSucursal, ")
         .AppendLine("   PrecioFabrica, ")
         .AppendLine("   PrecioCosto, ")
         .AppendLine("   Stock, ")
         .AppendLine("   Stock2, ")
         .AppendLine("   StockInicial, ")
         .AppendLine("   PuntoDePedido, ")
         .AppendLine("   StockMinimo, ")
         .AppendLine("   StockMaximo, ")
         .AppendLine("   Usuario, ")
         .AppendLine("   FechaActualizacion, ")
         .AppendLine("   Ubicacion")
         .AppendLine("  ,IdDepositoDefecto ")
         .AppendLine("  ,IdUbicacionDefecto ")
         .AppendLine("   ) ")
         .AppendLine("   VALUES(")
         .AppendLine("   '" & idProducto & "'")
         .AppendLine("   ," & idSucursal.ToString())
         .AppendLine("   ," & precioFabrica.ToString())
         .AppendLine("   ," & precioCosto.ToString())
         .AppendLine("   ," & stock.ToString())
         .AppendLine("   ," & stock2.ToString())
         .AppendLine("   ," & stock.ToString())
         .AppendLine("   ," & puntoDePedido.ToString())
         .AppendLine("   ," & stockMinimo.ToString())
         .AppendLine("   ," & stockMaximo.ToString())
         .AppendLine("   ,'" & usuario & "'")
         .AppendLine("   ,'" & Me.ObtenerFecha(Date.Now, True) & "'")
         .AppendLine("   ,'" & ubicacion & "'")
         .AppendLine("   ," & idDepositoDefecto.ToString())
         .AppendLine("   ," & idUbicacionDefecto.ToString())
         .AppendLine("   )")

      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

      Dim PSP As ProductosSucursalesPrecios = New ProductosSucursalesPrecios(_da)
      PSP.ProductosSucursalesPrecios_IProdSuc(idProducto, idSucursal, usuario)

   End Sub

   Public Sub ProductosSucursales_U_Actualiza_Producto_PublicarEnSincronizacionSucursal(idProducto As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PS")
         .AppendFormatLine("   SET FechaActualizacionWeb = GETDATE()")
         .AppendFormatLine("  FROM ProductosSucursales PS")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendFormatLine(" WHERE P.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND P.PublicarEnSincronizacionSucursal = 'False'")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProductosSucursales_U(idProducto As String,
                                    idSucursal As Integer,
                                    precioFabrica As Decimal,
                                    precioCosto As Decimal,
                                    stock As Decimal,
                                    puntoDePedido As Decimal,
                                    stockMinimo As Decimal,
                                    stockMaximo As Decimal,
                                    usuario As String,
                                    ubicacion As String,
                                    idDepositoDefecto As Integer,
                                    idUbicacionDefecto As Integer)
      Dim myQuery = New StringBuilder()
      ' TODO: Analizar si corresponde o NO actualizar el campo "StockInicial"
      With myQuery
         .AppendLine("UPDATE ProductosSucursales SET ")
         .AppendLine("   PrecioFabrica = " & precioFabrica.ToString())
         .AppendLine("   ,PrecioCosto = " & precioCosto.ToString())
         .AppendLine("   ,Stock = " & stock.ToString())
         .AppendLine("   ,PuntoDePedido = " & puntoDePedido.ToString())
         .AppendLine("   ,StockMinimo = " & stockMinimo.ToString())
         .AppendLine("   ,StockMaximo = " & stockMaximo.ToString())
         .AppendLine("   ,Usuario = '" & usuario & "'")
         .AppendLine("   ,FechaActualizacion = '" & Me.ObtenerFecha(DateTime.Now, True) & "'")
         .AppendLine("   ,Ubicacion = '" & ubicacion & "'")
         .AppendLine("   ,IdDepositoDefecto = " & idDepositoDefecto.ToString())
         .AppendLine("   ,IdUbicacionDefecto = " & idUbicacionDefecto.ToString())
         .AppendLine(" WHERE IdProducto = '" & idProducto & "'")
         .AppendLine("   AND IdSucursal = " & idSucursal)
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub

   Public Sub ProductosSucursales_DU(idProducto As String,
                                    idSucursal As Integer,
                                    idDepositoDefecto As Integer,
                                    idUbicacionDefecto As Integer)
      Dim myQuery = New StringBuilder()
      ' TODO: Analizar si corresponde o NO actualizar el campo "StockInicial"
      With myQuery
         .AppendLine("UPDATE ProductosSucursales SET ")
         .AppendLine("   IdDepositoDefecto = " & idDepositoDefecto.ToString())
         .AppendLine("   ,IdUbicacionDefecto = " & idUbicacionDefecto.ToString())
         .AppendLine(" WHERE IdProducto = '" & idProducto & "'")
         .AppendLine("   AND IdSucursal = " & idSucursal)
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub
   Public Sub ProductosSucursales_D(idProducto As String, idSucursal As Integer)
      Dim PSP As ProductosSucursalesPrecios = New ProductosSucursalesPrecios(_da)
      PSP.ProductosSucursalesPrecios_DProdSuc(idProducto, idSucursal)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("DELETE FROM ProductosSucursales ")
         .Append(" WHERE IdProducto = '" & idProducto & "'")
         If idSucursal > 0 Then
            .Append(" AND IdSucursal = " & idSucursal.ToString())
         End If
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosSucursales")
   End Sub

   Public Sub ProductosSucursales_DPorSucursal(idSucursal As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM ProductosSucursales ")
         .Append(" WHERE IdSucursal = " & idSucursal.ToString())
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub

   Public Function ProductosSucursales_GA(idListaPrecios As Integer, soloTraeEstoyAca As Boolean, fechaActualizacionDesde As DateTime?) As DataTable
      Return ProductosSucursales_G(String.Empty, Nothing, idListaPrecios, soloTraeEstoyAca, fechaActualizacionDesde, New Entidades.Filtros.ProductosPublicarEnFiltros(), Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function ProductosSucursales_GA(idListaPrecios As Integer, fechaActualizacionDesde As DateTime?,
                                          publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros, publicarEnWebSucursal As Entidades.Publicos.SiNoTodos) As DataTable
      Return ProductosSucursales_G(String.Empty, Nothing, idListaPrecios, False, fechaActualizacionDesde, publicarEn, publicarEnWebSucursal)
   End Function
   Public Function ProductosSucursales_G1(idProducto As String, idSucursal As Integer?, idListaPrecios As Integer, soloTraeEstoyAca As Boolean) As DataTable
      Return ProductosSucursales_G(idProducto, idSucursal, idListaPrecios, soloTraeEstoyAca, Nothing, New Entidades.Filtros.ProductosPublicarEnFiltros(), Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function ProductosSucursales_G(idProducto As String, idSucursal As Integer?, idListaPrecios As Integer, soloTraeEstoyAca As Boolean, fechaActualizacionDesde As DateTime?,
                                         publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros, publicarEnWebSucursal As Entidades.Publicos.SiNoTodos) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine(" SELECT  ")
         .AppendLine("      PS.IdSucursal")
         .AppendLine("      ,RIGHT(REPLICATE(' ',15) + PS.IdProducto,15) as IdProducto")
         .AppendLine("	   ,P.NombreProducto")
         .AppendLine("      ,P.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("	   ,S.Nombre NombreSucursal")
         .AppendLine("      ,PS.PrecioFabrica")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,PSP.PrecioVenta AS PrecioVentaLista")
         .AppendLine("      ,PS.StockInicial")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,PS.PuntoDePedido")
         .AppendLine("      ,PS.StockMinimo")
         .AppendLine("      ,PS.StockMaximo")
         .AppendLine("      ,PS.Usuario")
         .AppendLine("      ,PS.FechaActualizacion")
         .AppendLine("      ,PS.Ubicacion")
         .AppendFormat("      ,PS.{0}", Entidades.ProductoSucursalPrecio.Columnas.FechaActualizacionWeb.ToString()).AppendLine()
         .AppendLine("      ,PS.IdDepositoDefecto")
         .AppendLine("      ,PS.IdUbicacionDefecto")
         .AppendLine("  FROM ProductosSucursales PS")
         .AppendLine(" INNER JOIN ProductosSucursalesPrecios PSP ON PSP.IdSucursal = PS.IdSucursal AND PSP.IdProducto = PS.IdProducto AND PSP.IdListaPrecios = " + idListaPrecios.ToString())
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendLine("  LEFT JOIN Marcas M ON P.IdMarca = M.IdMarca ")
         .AppendLine("  LEFT JOIN Rubros R ON P.IdRubro = R.IdRubro ")

         .AppendLine(" WHERE 1 = 1")

         If soloTraeEstoyAca Then
            .Append(" AND S.EstoyAca = 'True' ")
         End If

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendLine(" AND PS.IdProducto = '" + idProducto + "'")
         End If

         If idSucursal.HasValue Then
            .AppendLine(" AND PS.IdSucursal = " + idSucursal.Value.ToString() + "")
         End If

         If fechaActualizacionDesde.HasValue Then
            .AppendFormatLine("   AND PS.{0} > '{1}'", Entidades.ProductoSucursal.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True))
         End If

         ProductoPublicarEn(myQuery, publicarEn, "P")
         'If publicarEn <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormatLine("   AND P.{0} = {1}", Entidades.Producto.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEnWeb = Entidades.Publicos.SiNoTodos.SI))
         'End If

         If publicarEnWebSucursal <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND S.{0} = {1}", Entidades.Sucursal.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEnWebSucursal = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendLine("  ORDER BY P.NombreProducto, RIGHT(REPLICATE(' ',15) + PS.IdProducto,15), S.Nombre")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function StockValorizado(suc As List(Of Integer), cotizacionDolar As Decimal, blnPreciosConIVA As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      With stb
         .AppendLine("SELECT S.Nombre")
         If blnPreciosConIVA Then
            .AppendFormat("     , SUM(({0}) * M.FactorConversion * PS.Stock / CASE WHEN P.PrecioPorEmbalaje = 'True' THEN P.Embalaje ELSE 1 END) AS ValorSinIVA ",
                          CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioCosto",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
            .AppendLine("     , SUM(PS.PrecioCosto * M.FactorConversion * PS.Stock / CASE WHEN P.PrecioPorEmbalaje = 'True' THEN P.Embalaje ELSE 1 END) AS ValorConIVA ")
         Else
            .AppendLine("     , SUM(PS.PrecioCosto * M.FactorConversion * PS.Stock / CASE WHEN P.PrecioPorEmbalaje = 'True' THEN P.Embalaje ELSE 1 END) AS ValorSinIVA ")
            .AppendFormat("     , SUM(({0}) * M.FactorConversion * PS.Stock / CASE WHEN P.PrecioPorEmbalaje = 'True' THEN P.Embalaje ELSE 1 END) AS ValorConIVA ",
                          CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioCosto",
                                                                        "P.Alicuota",
                                                                        "P.PorcImpuestoInterno",
                                                                        "P.ImporteImpuestoInterno",
                                                                        "P.OrigenPorcImpInt")).AppendLine()
         End If
         .AppendLine("  FROM ProductosSucursales PS ")
         .AppendLine("  INNER JOIN Sucursales S on S.IdSucursal = PS.IdSucursal ")
         .AppendLine("  INNER JOIN Productos P on P.IdProducto = PS.IdProducto ")
         .AppendFormat("  INNER JOIN (SELECT 1 IdMoneda, 1 FactorConversion UNION SELECT 2, {0}) AS M ON M.IdMoneda = P.IdMoneda", cotizacionDolar).AppendLine()
         '.AppendLine("     AND P.Activo = 'True'")
         .AppendLine("     AND P.AfectaStock = 'True' ")
         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat(" AND PS.IdSucursal = 0")
         Else
            .AppendFormat(" AND PS.IdSucursal IN ({0})", sucur)
         End If
         .AppendLine(" GROUP BY S.Nombre ")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
   Public Sub ProductosSucursales_UStock(idSucursal As Integer,
                                         idDeposito As Integer,
                                         idProducto As String,
                                         movimiento As Decimal,
                                         movimientoReservado As Decimal,
                                         movimientoDefectuoso As Decimal,
                                         movimientoFuturo As Decimal,
                                         movimientoFuturoReservado As Decimal)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE PS")
         .AppendFormatLine("   SET Stock = Stock + " & movimiento.ToString())
         '.AppendFormatLine("     , StockReservado = ISNULL(StockReservado, 0) + " & movimientoReservado.ToString())
         '.AppendFormatLine("     , StockDefectuoso = StockDefectuoso + " & movimientoDefectuoso.ToString())
         '.AppendFormatLine("     , StockFuturo = StockFuturo + " & movimientoFuturo.ToString())
         '.AppendFormatLine("     , StockFuturoReservado = StockFuturoReservado + " & movimientoFuturoReservado.ToString())
         .AppendFormatLine("  FROM ProductosSucursales PS")
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = PS.IdSucursal")
         .AppendFormatLine(" WHERE PS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PS.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND SD.IdDeposito = {0}", idDeposito)
         .AppendFormatLine("   AND SD.TipoDeposito = '{0}'", Entidades.SucursalDeposito.TiposDepositos.OPERATIVO.ToString())
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub

   Public Function ProductosSucursales_DepositoUbicacionDefecto(idSucursal As Integer, idProducto As String) As DataTable

      Dim myQuery = New StringBuilder("")
      With myQuery
         .Length = 0
         .Append("SELECT IdDepositoDefecto, IdUbicacionDefecto")
         .Append(" FROM ProductosSucursales")
         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormat(" AND IdSucursal ={0}", idSucursal)
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Sub ProductosSucursales_UStock(idSucursal As Integer, idProducto As String, Stock As Decimal, StockInicial As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE ProductosSucursales SET ")
         .AppendLine(" Stock = " & Stock.ToString())
         .AppendLine(" ,StockInicial = " & StockInicial.ToString())
         .AppendLine("WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("  AND IdProducto = '" & idProducto & "'")
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub

   Public Sub ProductosSucursales_UStockInicial(idSucursal As Integer, idProducto As String, movimiento As Double)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE ProductosSucursales ")
         .AppendLine("   SET StockInicial = StockInicial + " & movimiento.ToString())
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub

   Public Sub ProductosSucursales_UEstadistica(idSucursal As Integer, idProducto As String, puntoDePedido As Decimal?, stockMinimo As Decimal?, stockMaximo As Decimal?, ubicacion As NullableString)

      If stockMinimo.HasValue OrElse stockMaximo.HasValue OrElse puntoDePedido.HasValue OrElse Not ubicacion.EsNull Then

         Dim myQuery = New StringBuilder()

         With myQuery
            Dim prefijo = "SET"
            .AppendLine("UPDATE ProductosSucursales")
            If puntoDePedido.HasValue Then
               .AppendFormatLine("   {0} PuntoDePedido = {1}", prefijo, puntoDePedido.Value)
               prefijo = ","
            End If
            If stockMinimo.HasValue Then
               .AppendFormatLine("   {0} StockMinimo = {1}", prefijo, stockMinimo.Value)
               prefijo = ","
            End If
            If stockMaximo.HasValue Then
               .AppendFormatLine("   {0} StockMaximo = {1}", prefijo, stockMaximo.Value)
               prefijo = ","
            End If
            If Not ubicacion.EsNull Then
               .AppendFormatLine("   {0} Ubicacion = '{1}'", prefijo, ubicacion.Valor)
               prefijo = ","
            End If
            .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
            .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         End With

         Execute(myQuery)
         Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")
      End If

   End Sub

   Public Sub ProductosSucursales_UPrecios(idProducto As String,
                              idSucursal As Integer,
                              precioFabrica As Double,
                              precioCosto As Double,
                              usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE ProductosSucursales SET ")
         .Append("  PrecioFabrica = " & precioFabrica.ToString() & ", ")
         .Append("  PrecioCosto = " & precioCosto.ToString() & ", ")
         .Append("  Usuario = '" & usuario & "',")
         .Append("  FechaActualizacion = '" & Me.ObtenerFecha(DateTime.Now, True) & "'")
         .Append(" WHERE IdProducto = '" & idProducto & "'")
         .Append("   AND IdSucursal = " & idSucursal & "")
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub

   Public Sub ProductosSucursales_UPrecioCosto(idProducto As String,
                              idSucursal As Integer,
                              precioCosto As Double,
                              usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE ProductosSucursales SET ")
         .Append("  PrecioCosto = " & precioCosto.ToString() & ", ")
         .Append("  Usuario = '" & usuario & "',")
         .Append("  FechaActualizacion = '" & Me.ObtenerFecha(DateTime.Now, True) & "'")
         .Append(" WHERE IdProducto = '" & idProducto & "'")
         .Append("   AND IdSucursal = " & idSucursal & "")
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub

   Public Sub ProductosSucursales_Ubicacion(idProducto As String,
                             idSucursal As Integer,
                             Ubicacion As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE ProductosSucursales SET ")
         .Append("  Ubicacion = '" & Ubicacion & "'")
         .Append(" WHERE IdProducto = '" & idProducto & "'")
         .Append("   AND IdSucursal = " & idSucursal & "")
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   End Sub

   Public Sub ProductosSucursales_U_Varios(idProducto As String,
                                           idSucursal As Integer,
                                           puntoDePedido As Decimal,
                                           stockMinimo As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE ProductosSucursales")
         .AppendFormatLine("   SET PuntoDePedido = {0}", puntoDePedido)
         .AppendFormatLine("      ,StockMinimo = {0}", stockMinimo)
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND IdSucursal = {0}", idSucursal)
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")
   End Sub

   'Public Sub ProductosSucursales_UPrecioVenta(idProducto As String, _
   '                              idSucursal As Integer, _
   '                              precioVenta As Double, _
   '                              usuario As String)

   '   Dim myQuery As StringBuilder = New StringBuilder("")

   '   With myQuery
   '      .Append("UPDATE ProductosSucursales SET ")
   '      .Append("  PrecioVenta = " & precioVenta.ToString() & ", ")
   '      .Append("  Usuario = '" & usuario & "',")
   '      .Append("  FechaActualizacion = '" & Me.ObtenerFecha(DateTime.Now, True) & "'")
   '      .Append(" WHERE IdProducto = '" & idProducto & "'")
   '      .Append("   AND IdSucursal = " & idSucursal & "")
   '   End With

   '   Execute(myQuery)
   '   Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

   'End Sub
   Public Sub ProductosSucursales_UPreciosCostoVenta(idProducto As String,
                                                     idSucursal As Integer,
                                                     precioCosto As Decimal,
                                                     precioVenta As Decimal,
                                                     idListaPrecio As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE ProductosSucursales SET ")
         If precioCosto <> 0 Then
            .Append("  PrecioCosto = " & precioCosto.ToString() & ", ")
         End If
         .Append("  FechaActualizacion = '" & Me.ObtenerFecha(DateTime.Now, True) & "'")
         .Append(" WHERE IdProducto = '" & idProducto & "'")
         .Append("   AND IdSucursal = " & idSucursal & "")
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursales")

      With myQuery
         .Append("UPDATE ProductosSucursalesPrecios SET ")
         If precioVenta <> 0 Then
            .AppendFormat("  PrecioVenta = {0}, ", precioVenta)
         End If
         .AppendFormat("  FechaActualizacion = '{0}'", Me.ObtenerFecha(Date.Now, True))
         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormat("   AND IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdListaPrecios = {0}", idListaPrecio)
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursalesPrecios")

   End Sub


   Public Sub ProductosSucursales_UPorSucursal(idSucursal As Integer, idDepositoDefecto As Integer, idUbicacionDefecto As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ProductosSucursales")
         .AppendFormatLine("   SET IdDepositoDefecto  = {0}", idDepositoDefecto)
         .AppendFormatLine("     , IdUbicacionDefecto = {0}", idUbicacionDefecto)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND (IdDepositoDefecto IS NULL OR IdUbicacionDefecto IS NULL)")   '-- Copio de la Sucursal que siempre debe estar.
      End With
      Execute(stb)
   End Sub
   Public Sub ProductosSucursales_IPorSucursal(idSucursal As Integer, usuario As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ProductosSucursales (")
         .AppendFormatLine("            IdProducto")
         .AppendFormatLine("          , IdSucursal")
         .AppendFormatLine("          , PrecioFabrica")
         .AppendFormatLine("          , PrecioCosto")
         .AppendFormatLine("          , Usuario")
         .AppendFormatLine("          , FechaActualizacion")
         .AppendFormatLine("          , Stock")
         .AppendFormatLine("          , Stock2")
         .AppendFormatLine("          , StockInicial")
         .AppendFormatLine("          , PuntoDePedido")
         .AppendFormatLine("          , StockMinimo")
         .AppendFormatLine("          , StockMaximo")
         .AppendFormatLine("          , Ubicacion")

         .AppendFormatLine("          , IdDepositoDefecto")
         .AppendFormatLine("          , IdUbicacionDefecto)")

         '.AppendLine("          , StockReservado")
         '.AppendLine("          , StockDefectuoso")
         '.AppendLine("          , StockFuturo")
         '.AppendLine("          , StockFuturoReservado)")
         .AppendFormatLine(" SELECT PS.IdProducto")
         .AppendFormatLine("      , {0} AS Sucursal", idSucursal)
         .AppendFormatLine("      , PS.PrecioFabrica")
         .AppendFormatLine("      , PS.PrecioCosto")
         .AppendFormatLine("      , '{0}' AS Usuario", usuario)
         .AppendFormatLine("      , GetDATE() as Actualizacion")
         .AppendFormatLine("      , 0 AS Stock")
         .AppendFormatLine("      , 0 AS Stock2")
         .AppendFormatLine("      , 0 AS StockInicial")
         .AppendFormatLine("      , 0 AS PuntoDePedido")
         .AppendFormatLine("      , 0 AS StockMinimo")
         .AppendFormatLine("      , 0 AS StockMaximo")
         .AppendFormatLine("      , PS.Ubicacion")

         'IdDepositoDefecto y IdUbicacionDefecto inicialmente se graba en NULL para luego, cuando se cree la Primer Ubicación, se actualice con dicho dato.
         'Si no se hace así habría problema de FK circulares.
         .AppendFormatLine("      , NULL AS IdDepositoDefecto")
         .AppendFormatLine("      , NULL AS IdUbicacionDefecto")

         '.AppendLine("      , 0 AS StockReservado")
         '.AppendLine("      , 0 AS StockDefectuoso")
         '.AppendLine("      , 0 AS StockFuturo")
         '.AppendLine("      , 0 AS StockFuturoReservado")
         .AppendFormatLine("  FROM ProductosSucursales PS, Sucursales S")
         .AppendFormatLine(" WHERE PS.IdSucursal = S.IdSucursal")
         .AppendFormatLine("   AND S.SoyLaCentral = 'True'")   '-- Copio de la Sucursal que siempre debe estar.
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosSucursales")
   End Sub

   Public Function GetCantidadDeProductosSinStock(idSucursal As Integer) As Integer

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT COUNT(PS.IdProducto) as Cantidad")
         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine(" LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendFormat(" WHERE PS.IdSucursal = {0} ", idSucursal)
         .AppendLine("   AND P.Activo = 'True'")
         .AppendLine("   AND P.AfectaStock = 'True'")
         .AppendLine("   AND PS.Stock <= 0")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("Cantidad").ToString())
      Else
         Return 0
      End If

   End Function

   Public Function GetPrecioVentaPredeterminado(idSucursal As Integer, idProducto As String, idListaPrecios As Integer) As Decimal

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Append("SELECT PSP.PrecioVenta")
         .Append("	FROM ProductosSucursalesPrecios PSP")
         .AppendFormat("	WHERE PSP.IdProducto = '{0}'", idProducto)
         .AppendFormat("	AND PSP.IdSucursal = {0}", idSucursal)
         .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return Decimal.Parse(dt.Rows(0)("PrecioVenta").ToString())
      Else
         Return 0
      End If

   End Function

   Public Function GetProductosSinStock(idSucursal As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT P.IdProducto Codigo")
         .AppendLine("      ,P.NombreProducto Producto")
         .AppendLine("      ,M.NombreMarca [Marca]")
         .AppendLine("      ,R.NombreRubro [Rubro]")
         .AppendLine("      ,cp.NombreProveedor [Ultima compra a]")
         .AppendLine("      ,cp.Fecha [Fecha compra]")
         .AppendLine("      ,PS.Stock [Stock]")
         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine(" LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" LEFT JOIN (select top 1 p1.idproducto, pr.NombreProveedor, c.Fecha from Productos P1")
         .AppendLine(" inner join ComprasProductos CP on p1.IdProducto = cp.IdProducto")
         .AppendLine(" inner join Compras C on cp.IdSucursal = c.IdSucursal and ")
         .AppendLine(" cp.IdTipoComprobante = c.IdTipoComprobante and")
         .AppendLine(" cp.Letra = c.Letra and")
         .AppendLine(" cp.CentroEmisor = c.CentroEmisor and")
         .AppendLine(" cp.NumeroComprobante = c.NumeroComprobante and")
         .AppendLine(" cp.IdProveedor = c.IdProveedor")
         .AppendLine(" inner join Proveedores Pr on pr.IdProveedor = c.IdProveedor")
         .AppendLine(" order by c.Fecha) CP ON CP.IdProducto = PS.IdProducto")
         .AppendLine("  WHERE PS.IdSucursal = " & idSucursal.ToString())
         .AppendLine("    AND P.Activo = 'True'")
         .AppendLine("    AND P.AfectaStock = 'True'")
         .AppendLine("    AND PS.Stock <= 0")
         .AppendLine(" ORDER BY PS.Stock ASC")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetCantidadPuntoDePedidoDeProductos(idSucursal As Integer) As Integer

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT COUNT(PS.IdProducto) as Cantidad")
         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine(" LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendFormat(" WHERE PS.IdSucursal = {0} ", idSucursal)
         .AppendLine("   AND P.Activo = 'True'")
         .AppendLine("   AND P.AfectaStock = 'True'")
         .AppendLine("   AND PS.PuntoDePedido > 0")
         .AppendLine("   AND PS.Stock <= PS.PuntoDePedido")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("Cantidad").ToString())
      Else
         Return 0
      End If

   End Function

   Public Function GetPuntoDePedidoDeProductos(sucursales As Entidades.Sucursal(),
                                               depositos As Entidades.SucursalDeposito(),
                                               ubicacion As Entidades.SucursalUbicacion,
                                               tipoPedido As String,
                                               idProducto As String,
                                               idMarca As Integer, idRubro As Integer, idSubRubro As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PS.IdSucursal")
         .AppendLine("      ,S.Nombre AS NombreSucursal")
         .AppendLine("      ,PS.IdProducto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,PS.PuntoDePedido")
         .AppendLine("      ,PS.StockMaximo")
         .AppendLine("      ,(CASE WHEN PS.Stock < PS.StockMAximo THEN ((PS.StockMaximo-PS.PuntoDePedido)+(PS.PuntoDePedido-PS.Stock)) ELSE 0 END) as Pedido")
         .AppendLine("      ,SD.NombreDeposito")
         .AppendLine("      ,PD.Stock AS StockDeposito")
         .AppendLine("      ,SU.NombreUbicacion")
         .AppendLine("      ,PU.Stock AS StockUbicacion")

         .AppendLine(" FROM ProductosSucursales PS")

         .AppendLine("	LEFT JOIN ProductosDepositos PD ON PS.IdProducto = PD.IdProducto AND PD.IdSucursal = PS.IdSucursal")
         .AppendLine("	LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = PD.IdSucursal AND SD.IdDeposito = PD.IdDeposito ")
         .AppendLine("	LEFT JOIN ProductosUbicaciones PU ON PU.IdProducto = PD.IdProducto AND PU.IdSucursal = PD.IdSucursal AND PU.IdDeposito = PD.IdDeposito ")
         .AppendLine("	LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PU.IdSucursal AND SU.IdDeposito = PU.IdDeposito AND SU.IdUbicacion = PU.IdUbicacion")

         .AppendLine("  INNER JOIN Sucursales S on S.IdSucursal = PS.IdSucursal ")
         .AppendLine("  INNER JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendLine("  INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine("  INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")

         '------------------------------------------------------------------------
         .Append("  WHERE P.Activo = 'True' ")

         GetListaSucursalesMultiples(stb, sucursales, "PS")
         GetListaDepositosMultiples(stb, depositos, "PD")

         If ubicacion IsNot Nothing Then
            .AppendFormatLine("	AND SU.IdDeposito  = {0}", ubicacion.IdDeposito)
            .AppendFormatLine("	AND SU.IdUbicacion = {0}", ubicacion.IdUbicacion)
         End If
         '-------------------------------------------------------------------------
         .AppendLine("    AND P.AfectaStock = 'True'")
         '.AppendLine("    AND PS.PuntoDePedido > 0")

         If tipoPedido <> "TODOS" Then
            .AppendLine("    AND PS.Stock <= PS.PuntoDePedido")
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("    AND PS.IdProducto = '" & idProducto & "'")
         End If

         If idMarca > 0 Then
            .AppendLine("    AND P.IdMarca = " & idMarca.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("    AND P.IdRubro = " & idRubro.ToString())
         End If

         If idSubRubro > 0 Then
            .AppendLine("   AND P.IdSubRubro = " & idSubRubro.ToString())
         End If

         .AppendLine(" ORDER BY PS.IdSucursal, M.NombreMarca, P.NombreProducto, PS.IdProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetCantidadStockMinimoDeProductos(idSucursal As Integer) As Integer

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT COUNT(PS.IdProducto) as Cantidad")
         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine(" LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendFormat(" WHERE PS.IdSucursal = {0} ", idSucursal)
         .AppendLine("   AND P.Activo = 'True'")
         .AppendLine("   AND P.AfectaStock = 'True'")
         .AppendLine("   AND PS.StockMinimo > 0")
         .AppendLine("   AND PS.Stock <= PS.StockMinimo")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("Cantidad").ToString())
      Else
         Return 0
      End If

   End Function

   Public Function GetStockMinimoDeProductos(sucursales As Entidades.Sucursal(),
                                             depositos As Entidades.SucursalDeposito(),
                                             ubicacion As Entidades.SucursalUbicacion,
                                             tipoPedido As String,
                                             idProducto As String,
                                             idMarca As Integer,
                                             idRubro As Integer,
                                             idSubRubro As Integer,
                                             sucursalesTodas As Entidades.Sucursal(),
                                             idProveedor As Long, habitual As Boolean) As DataTable

      Dim dtSuc As DataTable = New SqlServer.Sucursales(Me._da).Sucursales_G1(actual.Sucursal.Id, False)
      Dim IdSucursalAsociada As Integer = 0

      If Not String.IsNullOrEmpty(dtSuc.Rows(0)("IdSucursalAsociada").ToString()) Then
         IdSucursalAsociada = Integer.Parse(dtSuc.Rows(0)("IdSucursalAsociada").ToString())
      End If

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT PS.IdSucursal")
         .AppendFormatLine("     , S.Nombre AS NombreSucursal")
         .AppendFormatLine("     , PS.IdProducto")
         .AppendFormatLine("     , P.NombreProducto")
         .AppendFormatLine("     , M.NombreMarca")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , PS.Stock")
         .AppendFormatLine("     , PS.StockMinimo")
         .AppendFormatLine("     , PS.StockMaximo")
         .AppendFormatLine("     , (CASE WHEN PS.Stock < PS.StockMAximo THEN ((PS.StockMaximo-PS.PuntoDePedido)+(PS.PuntoDePedido-PS.Stock)) ELSE 0 END) as Pedido")
         .AppendFormatLine("     , SD.NombreDeposito")
         .AppendFormatLine("     , PD.Stock AS StockDeposito")
         .AppendFormatLine("     , SU.NombreUbicacion")
         .AppendFormatLine("     , PU.Stock AS StockUbicacion")
         .AppendFormatLine("     ,StockTotal.StockTotal AS [Stock Total]")
         .AppendFormatLine("  FROM ProductosSucursales PS")
         .AppendFormatLine("	LEFT JOIN ProductosDepositos PD ON PS.IdProducto = PD.IdProducto AND PD.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("	LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = PD.IdSucursal AND SD.IdDeposito = PD.IdDeposito ")
         .AppendFormatLine("	LEFT JOIN ProductosUbicaciones PU ON PU.IdProducto = PD.IdProducto AND PU.IdSucursal = PD.IdSucursal AND PU.IdDeposito = PD.IdDeposito ")
         .AppendFormatLine("	LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PU.IdSucursal AND SU.IdDeposito = PU.IdDeposito AND SU.IdUbicacion = PU.IdUbicacion")
         .AppendFormatLine(" INNER JOIN Sucursales S on S.IdSucursal = PS.IdSucursal ")
         .AppendFormatLine(" INNER JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendFormatLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         If idProveedor > 0 Then
            If habitual Then
               .AppendFormatLine("  LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.Idproducto AND PP.IdProveedor = {0}", idProveedor)
            Else
               .AppendFormatLine(" INNER JOIN ProductosProveedores PP ON PP.IdProducto = P.Idproducto AND PP.IdProveedor = {0}", idProveedor)
            End If
         End If
         '------------------------------------------------------------------------
         .AppendLine(" LEFT JOIN (SELECT PS1.IdProducto, SUM(PS1.Stock) AS StockTotal")
         .AppendLine("              FROM ProductosSucursales AS PS1")
         .AppendLine("             WHERE PS1.IdSucursal IN (0")

         If IdSucursalAsociada > 0 Then
            .Append(", " & IdSucursalAsociada.ToString())
         Else
            For Each suc As Entidades.Sucursal In sucursalesTodas
               If Integer.Parse(suc.Id.ToString()) <> 0 Then
                  .Append(", " & suc.Id.ToString())
               End If
            Next
         End If
         .AppendLine(") ")

         .AppendLine("          GROUP BY PS1.IdProducto")
         .AppendLine("            ) StockTotal ON StockTotal.IdProducto = PS.IdProducto")
         '------------------------------------------------------------------------

         .AppendFormatLine("  WHERE P.Activo = 'True' ")

         GetListaSucursalesMultiples(stb, sucursales, "PS")
         GetListaDepositosMultiples(stb, depositos, "PD")

         If ubicacion IsNot Nothing Then
            .AppendFormatLine("	AND SU.IdDeposito  = {0}", ubicacion.IdDeposito)
            .AppendFormatLine("	AND SU.IdUbicacion = {0}", ubicacion.IdUbicacion)
         End If
         '-------------------------------------------------------------------------
         .AppendFormatLine("    AND P.AfectaStock = 'True'")
         .AppendFormatLine("    AND PS.StockMinimo > 0")

         If tipoPedido <> "TODOS" Then
            .AppendFormatLine("    AND PS.Stock <= PS.StockMinimo")
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("    AND PS.IdProducto = '{0}'", idProducto)
         End If

         If idMarca > 0 Then
            .AppendFormatLine("    AND P.IdMarca = {0}", idMarca)
         End If

         If idRubro > 0 Then
            .AppendFormatLine("    AND P.IdRubro = {0}", idRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormatLine("   AND P.IdSubRubro = {0}", idSubRubro)
         End If

         If habitual Then
            .AppendFormatLine("           AND P.IdProveedor = {0}", idProveedor)
         End If

         .AppendFormatLine(" ORDER BY PS.IdSucursal, M.NombreMarca, P.NombreProducto, PS.IdProducto")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetProductosGenerarPedidos(sucursales As Entidades.Sucursal(),
                                              depositos As Entidades.SucursalDeposito(),
                                              ubicacion As Entidades.SucursalUbicacion,
                                              tipoPedido As Entidades.ProductoSucursal.SituacionDeStock,
                                              idProducto As String,
                                              idMarca As Integer, idRubro As Integer, idSubRubro As Integer,
                                              idProveedor As Long, proveedorHabitual As Boolean,
                                              calculaCantidadesVendida As Boolean, fechaDesdeCantidadesVendida As Date?, fechaHastaCantidadesVendida As Date?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PS.IdSucursal")
         .AppendLine("      ,S.Nombre AS NombreSucursal")
         .AppendLine("      ,PS.IdProducto")
         .AppendLine("      ,PP.CodigoProductoProveedor")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,PS.StockMinimo")
         .AppendLine("      ,PS.StockMaximo")
         .AppendLine("      ,PS.PuntoDePedido")
         .AppendLine("      ,(CASE WHEN PS.Stock < PS.StockMAximo THEN ((PS.StockMaximo - PS.Stock)) ELSE 0 END) as Pedido")
         .AppendLine("      ,P.ObservacionCompras AS Observacion")
         .AppendLine("      ,P.IdProveedor")
         '-- REQ-38607.- ------------------------
         .AppendLine("      ,P.Embalaje")
         '---------------------------------------
         .AppendLine("      ,PV.CodigoProveedor")
         .AppendLine("      ,PV.NombreProveedor")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,0.00 Estimativo") 'este campo se agrega para que lo tome la grilla y luego se pueda calcular
         .AppendLine("      ,PS.FechaActualizacion") 'este campo
         .AppendLine("      ,(SELECT PV.NombreProveedor + ' / '")
         .AppendLine("          FROM ProductosProveedores PRPV")
         .AppendLine("         INNER JOIN Proveedores PV ON PV.IdProveedor = PRPV.IdProveedor")
         .AppendLine("         INNER JOIN Productos PR ON PR.IdProducto = PRPV.IdProducto")
         .AppendLine("         WHERE ISNULL(PR.IdProveedor, 0) <> PRPV.IdProveedor")
         .AppendLine("           AND PRPV.IdProducto = P.IdProducto")
         .AppendLine("         FOR XML PATH('')) AS ProveedoresAlternativos")

         If calculaCantidadesVendida Then
            .AppendFormatLine("      ,ISNULL((SELECT SUM(VP.Cantidad) AS Cantidad")
            .AppendFormatLine("                 FROM Ventas V")
            .AppendFormatLine("                INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
            .AppendFormatLine("                INNER JOIN VentasProductos   VP ON VP.IdSucursal = V.IdSucursal")
            .AppendFormatLine("                                               AND VP.IdTipoComprobante = V.IdTipoComprobante")
            .AppendFormatLine("                                               AND VP.Letra = V.Letra")
            .AppendFormatLine("                                               AND VP.CentroEmisor = V.CentroEmisor")
            .AppendFormatLine("                                               AND VP.NumeroComprobante = V.NumeroComprobante")
            .AppendFormatLine("                INNER JOIN Productos PR ON VP.IdProducto = PR.IdProducto")
            .AppendFormatLine("                WHERE TC.AfectaCaja = 'True'")
            .AppendFormatLine("                  AND TC.EsComercial = 'True'")
            If fechaDesdeCantidadesVendida.HasValue Then
               .AppendFormatLine("                  AND V.Fecha >= '{0}'", ObtenerFecha(fechaDesdeCantidadesVendida.Value, False))
            End If
            If fechaHastaCantidadesVendida.HasValue Then
               .AppendFormatLine("                  AND V.Fecha <= '{0}'", ObtenerFecha(fechaHastaCantidadesVendida.Value.UltimoSegundoDelDia, True))
            End If
            .AppendFormatLine("                  AND PR.EsComercial = 'True'")
            .AppendFormatLine("                  AND VP.IdProducto = P.IdProducto), 0) CantidadVendida")
         Else
            .AppendFormatLine("      , 0 CantidadVendida")
         End If

         .AppendLine("      ,SD.NombreDeposito")
         .AppendLine("      ,PD.Stock AS StockDeposito")
         .AppendLine("      ,SU.NombreUbicacion")
         .AppendLine("      ,PU.Stock AS StockUbicacion")

         .AppendLine("  FROM ProductosSucursales PS")

         .AppendLine("	LEFT JOIN ProductosDepositos PD ON PD.IdProducto = PS.IdProducto AND PD.IdSucursal = PS.IdSucursal")
         .AppendLine("	LEFT JOIN SucursalesDepositos SD ON SD.IdSucursal = PD.IdSucursal AND SD.IdDeposito = PD.IdDeposito ")
         .AppendLine("	LEFT JOIN ProductosUbicaciones PU ON PU.IdProducto = PD.IdProducto AND PU.IdSucursal = PD.IdSucursal AND PU.IdDeposito = PD.IdDeposito ")
         .AppendLine("	LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PU.IdSucursal AND SU.IdDeposito = PU.IdDeposito AND SU.IdUbicacion = PU.IdUbicacion")

         .AppendLine(" INNER JOIN Sucursales S on S.IdSucursal = PS.IdSucursal ")
         .AppendLine(" INNER JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")

         .AppendLine("  LEFT JOIN Proveedores PV ON PV.IdProveedor = P.IdProveedor")
         .AppendLine("  LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.IdProducto AND PP.IdProveedor = P.IdProveedor")
         If idProveedor > 0 And Not proveedorHabitual Then
            .AppendLine(" INNER JOIN ProductosProveedores PP1 ON PP1.IdProducto = P.Idproducto")
         End If
         .AppendLine(" WHERE P.Activo = 'True'")
         .AppendLine("   AND P.AfectaStock = 'True'")
         .AppendLine("   AND P.EsDeCompras = 'True'")

         GetListaSucursalesMultiples(stb, sucursales, "PS")
         GetListaDepositosMultiples(stb, depositos, "PD")
         If ubicacion IsNot Nothing Then
            .AppendFormatLine("	AND SU.IdDeposito  = {0}", ubicacion.IdDeposito)
            .AppendFormatLine("	AND SU.IdUbicacion = {0}", ubicacion.IdUbicacion)
         End If

         'If comparaContra = StockControl.StockMinimo Then
         '   .AppendLine("    AND PS.StockMinimo > 0")
         'ElseIf comparaContra = StockControl.PuntoDePedido Then
         '   .AppendLine("    AND PS.PuntoDePedido > 0")
         'End If

         If tipoPedido <> Entidades.ProductoSucursal.SituacionDeStock.Todos Then
            .AppendFormat("    AND PS.Stock < PS.{0}", tipoPedido.ToString()).AppendLine()
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat("    AND PS.IdProducto = '{0}'", idProducto).AppendLine()
         End If

         If idMarca > 0 Then
            .AppendFormat("    AND P.IdMarca = {0}", idMarca).AppendLine()
         End If

         If idRubro > 0 Then
            .AppendFormat("    AND P.IdRubro = {0}", idRubro).AppendLine()
         End If

         If idSubRubro > 0 Then
            .AppendFormat("   AND P.IdSubRubro = {0}", idSubRubro).AppendLine()
         End If

         If idProveedor > 0 Then
            If proveedorHabitual Then
               .AppendFormat("   AND P.IdProveedor = {0}", idProveedor).AppendLine()
            Else
               .AppendFormat("   AND PP1.IdProveedor = {0}", idProveedor).AppendLine()
            End If
         End If

         .AppendLine().AppendFormat(" ORDER BY M.NombreMarca, P.NombreProducto, PS.IdProducto").AppendLine()
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPrecios(idSucursal As Integer, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .Append("SELECT PrecioFabrica, PrecioCosto")
         .Append(" FROM ProductosSucursales")
         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormat(" AND IdSucursal ={0}", idSucursal)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetCantidadDeInconsistenciaStockVsStockLotes(idSucursal As Integer) As Integer

      Dim dtSuc As DataTable = New SqlServer.Sucursales(_da).Sucursales_G1(idSucursal, False)
      Dim IdSucursalAsociada As Integer = 0

      If Not String.IsNullOrEmpty(dtSuc.Rows(0)("IdSucursalAsociada").ToString()) Then
         IdSucursalAsociada = Integer.Parse(dtSuc.Rows(0)("IdSucursalAsociada").ToString())
      End If

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT COUNT(PS.IdProducto) as Cantidad")
         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine(" LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" LEFT JOIN (SELECT PL.IdProducto, SUM(PL.CantidadActual) AS StockLote")
         .AppendLine("              FROM ProductosLotes AS PL")
         .AppendLine("             WHERE PL.IdSucursal = " & idSucursal.ToString())
         If IdSucursalAsociada > 0 Then
            .AppendLine("             OR PL.IdSucursal = " & IdSucursalAsociada.ToString())
         End If
         .AppendLine("          GROUP BY PL.IdProducto")
         .AppendLine("            ) Lotes ON Lotes.IdProducto = PS.IdProducto")
         .AppendLine("  WHERE PS.IdSucursal = " & idSucursal.ToString())
         '---Por ahora no.
         '.AppendLine("    AND P.Activo = 'True'")
         '.AppendLine("    AND P.AfectaStock = 'True'")
         '.AppendLine("    AND PS.Stock > 0")
         '---------------
         .AppendLine("      AND PS.Stock<>Lotes.StockLote")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("Cantidad").ToString())
      Else
         Return 0
      End If

   End Function

   Public Function GetInconsistenciaStockVsStockLotes(idSucursal As Integer) As DataTable

      Dim dtSuc As DataTable = New SqlServer.Sucursales(_da).Sucursales_G1(idSucursal, False)
      Dim IdSucursalAsociada As Integer = 0

      If Not String.IsNullOrEmpty(dtSuc.Rows(0)("IdSucursalAsociada").ToString()) Then
         IdSucursalAsociada = Integer.Parse(dtSuc.Rows(0)("IdSucursalAsociada").ToString())
      End If

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT P.IdProducto AS Codigo")
         .AppendLine("      ,P.NombreProducto AS Producto")
         .AppendLine("      ,M.NombreMarca AS Marca")
         .AppendLine("      ,R.NombreRubro AS Rubro")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,Lotes.StockLote AS [Stock Lote]")
         .AppendLine(" FROM ProductosSucursales PS")
         .AppendLine(" LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" LEFT JOIN (SELECT PL.IdProducto, SUM(PL.CantidadActual) AS StockLote")
         .AppendLine("              FROM ProductosLotes AS PL")
         .AppendLine("             WHERE PL.IdSucursal = " & idSucursal.ToString())
         If IdSucursalAsociada > 0 Then
            .AppendLine("             OR PL.IdSucursal = " & IdSucursalAsociada.ToString())
         End If
         .AppendLine("          GROUP BY PL.IdProducto")
         .AppendLine("            ) Lotes ON Lotes.IdProducto = PS.IdProducto")
         .AppendLine("  WHERE PS.IdSucursal = " & idSucursal.ToString())
         '---Por ahora no.
         '.AppendLine("    AND P.Activo = 'True'")
         '.AppendLine("    AND P.AfectaStock = 'True'")
         '.AppendLine("    AND PS.Stock > 0")
         '---------------
         .AppendLine("      AND PS.Stock<>Lotes.StockLote")
         .AppendLine(" ORDER BY P.NombreProducto")
         .AppendLine("         ,P.IdProducto")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetCantidadDeInconsistenciaStockVsMovimientosDeStock(idSucursal As Integer) As Integer
      Return GetInconsistenciaStockVsMovimientosDeStock(idSucursal).CountSecure()
   End Function

   Public Function GetInconsistenciaStockVsMovimientosDeStock(idSucursal As Integer) As DataTable

      Dim idSucursalAsociada = 0I
      Using dtSuc = New Sucursales(_da).Sucursales_G1(idSucursal, False)
         If dtSuc.Any() Then
            idSucursalAsociada = dtSuc.First().Field(Of Integer?)("IdSucursalAsociada").IfNull()
         End If
      End Using

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT P.IdProducto AS Codigo")
         .AppendLine("      ,P.NombreProducto AS Producto")
         .AppendLine("      ,M.NombreMarca AS Marca")
         .AppendLine("      ,R.NombreRubro AS Rubro")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,PS.StockInicial+Z.Suma2 AS Historico")

         '.AppendLine("SELECT DISTINCT PS.IdProducto, PS.Stock, PS.StockInicial+Z.Suma2 AS Historico FROM ProductosSucursales PS,")

         .AppendLine(" FROM ")

         .AppendLine("(")
         .AppendLine("SELECT IdProducto, SUM(Sumado) as Suma2 FROM")
         .AppendLine(" (")
         .AppendLine("  SELECT IdProducto, SUM(Cantidad) AS Sumado")
         .AppendLine("    FROM MovimientosStockProductos MCP")
         .AppendLine("   INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = MCP.IdSucursal AND SD.IdDeposito = MCP.IdDeposito")
         .AppendFormatLine("   WHERE (MCP.IdSucursal = {0}", idSucursal)
         If idSucursalAsociada > 0 Then
            .AppendFormatLine("      OR MCP.IdSucursal = {0}", idSucursalAsociada)
         End If
         .AppendLine("    )")
         .AppendFormatLine("     AND SD.TipoDeposito = '{0}'", Entidades.SucursalDeposito.TiposDepositos.OPERATIVO.ToString())
         .AppendLine("    GROUP BY IdProducto")
         ''''.AppendLine("  UNION ALL")
         ''''.AppendLine("  SELECT IdProducto, SUM(Cantidad) AS Sumado FROM MovimientosStockProductos MVP")
         ''''.AppendLine("   WHERE MVP.IdSucursal = " & idSucursal.ToString())
         ''''If idSucursalAsociada > 0 Then
         ''''   .AppendLine("      OR MVP.IdSucursal = " & idSucursalAsociada.ToString())
         ''''End If
         ''''.AppendLine("    GROUP BY IdProducto")
         .AppendLine("  ) a")
         .AppendLine("  GROUP BY IdProducto")
         .AppendLine(") Z, ProductosSucursales PS")
         .AppendLine(" LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")

         .AppendLine("  WHERE PS.IdProducto = Z.IdProducto")
         .AppendFormatLine("    AND PS.IdSucursal = {0}", idSucursal)
         .AppendLine("    AND P.AfectaStock = 'True'")
         .AppendLine("    AND NOT (P.EsCompuesto = 'True' AND P.DescontarStockComponentes = 'True') ")

         '---Por ahora no.
         '.AppendLine("    AND P.Activo = 'True'")
         '---------------
         .AppendLine("    AND PS.Stock <> PS.StockInicial+Z.Suma2")

         .AppendLine(" ORDER BY P.NombreProducto")
         .AppendLine("         ,P.IdProducto")
      End With

      Return GetDataTable(stb)

   End Function

   Private Sub SelectFiltrado(ByRef stb As StringBuilder, idListaPrecios As Integer)
      With stb
         .Length = 0
         .AppendLine("SELECT PS.IdProducto")
         .AppendLine("	    ,P.NombreProducto")
         .AppendLine("      ,PS.IdSucursal")
         .AppendLine("	    ,S.Nombre NombreSucursal")
         .AppendLine("      ,PS.PrecioFabrica")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,PSP.PrecioVenta AS PrecioVentaLista")
         .AppendLine("      ,PS.Stock")
         .AppendLine("      ,PS.StockInicial")
         .AppendLine("      ,PS.PuntoDePedido")
         .AppendLine("      ,PS.StockMinimo")
         .AppendLine("      ,PS.StockMaximo")
         .AppendLine("      ,PS.Usuario")
         .AppendLine("      ,PS.FechaActualizacion")
         '.AppendLine("      ,PS.StockReservado")
         '.AppendLine("      ,PS.StockDefectuoso")
         '.AppendLine("      ,PS.StockFuturo")
         '.AppendLine("      ,PS.StockFuturoReservado")
         '-- REQ-35484.- -------------------------------
         .AppendLine("	    ,SR.IdSubRubro")
         '----------------------------------------------
         .AppendLine("  FROM ProductosSucursales PS")
         .AppendLine(" INNER JOIN ProductosSucursalesPrecios PSP ON PSP.IdSucursal = PS.IdSucursal AND PSP.IdProducto = PS.IdProducto AND PSP.IdListaPrecios = " + idListaPrecios.ToString())
         .AppendLine("	LEFT JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendLine("	LEFT JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         '-- REQ-35484.- --------------------------------------------------------
         .AppendLine("	LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         '-----------------------------------------------------------------------
      End With
   End Sub

   Public Function GetProductoConStock(IdProducto As String, IdSucursal As Integer, idListaPrecios As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      Me.SelectFiltrado(stb, idListaPrecios)

      With stb
         .AppendLine(" WHERE PS.IdProducto = '" & IdProducto & "'")
         If IdSucursal > 0 Then
            .AppendLine(" AND PS.IdSucursal = " & IdSucursal.ToString())
         End If
         '---Por ahora no.
         '.AppendLine("    AND P.Activo = 'True'")
         '.AppendLine("    AND P.AfectaStock = 'True'")
         '---------------
         .AppendLine("    AND PS.Stock <> 0")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      Return dt

   End Function
   Public Function GetUbicacionesCalidad() As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine(" SELECT DISTINCT Ubicacion FROM ProductosSucursales")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      Return dt

   End Function

   Public Sub ProductosSucursales_M(idProducto As String,
                                    idSucursal As Integer,
                                    precioFabrica As Decimal,
                                    precioCosto As Decimal,
                                    stock As Decimal,
                                    puntoDePedido As Decimal,
                                    stockInicial As Decimal,
                                    stockMinimo As Decimal,
                                    stockMaximo As Decimal,
                                    usuario As String,
                                    fechaActualizacion As DateTime,
                                    ubicacion As String,
                                    actualizaStock As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("MERGE INTO ProductosSucursales AS D")
         .AppendFormat("     USING (SELECT '{0}' AS IdProducto", idProducto).AppendLine()
         .AppendFormat("                  , {0}  AS IdSucursal", idSucursal).AppendLine()
         .AppendFormat("                  , {0}  AS PrecioFabrica", precioFabrica).AppendLine()
         .AppendFormat("                  , {0}  AS PrecioCosto", precioCosto).AppendLine()
         .AppendFormat("                  ,'{0}' AS Usuario", usuario).AppendLine()
         .AppendFormat("                  ,'{0}' AS FechaActualizacion", ObtenerFecha(fechaActualizacion, False)).AppendLine()
         .AppendFormat("                  , {0}  AS Stock", stock).AppendLine()
         .AppendFormat("                  , {0}  AS StockInicial", stockInicial).AppendLine()
         .AppendFormat("                  , {0}  AS PuntoDePedido", puntoDePedido).AppendLine()
         .AppendFormat("                  , {0}  AS StockMinimo", stockMinimo).AppendLine()
         .AppendFormat("                  , {0}  AS StockMaximo", stockMaximo).AppendLine()
         .AppendFormat("                  ,'{0}' AS Ubicacion", ubicacion).AppendLine()
         .AppendLine("        ) AS O")
         .AppendLine("        ON O.IdProducto = D.IdProducto AND O.IdSucursal = D.IdSucursal")
         .AppendLine(" WHEN MATCHED THEN")
         .AppendLine("    UPDATE")
         .AppendLine("       SET D.PrecioFabrica = O.PrecioFabrica")
         .AppendLine("          ,D.PrecioCosto = O.PrecioCosto")
         .AppendLine("          ,D.Usuario = O.Usuario")
         .AppendLine("          ,D.FechaActualizacion = O.FechaActualizacion")
         .AppendLine("          ,D.PuntoDePedido = O.PuntoDePedido")
         .AppendLine("          ,D.StockMinimo = O.StockMinimo")
         .AppendLine("          ,D.StockMaximo = O.StockMaximo")
         .AppendLine("          ,D.Ubicacion = O.Ubicacion")
         If actualizaStock Then
            .AppendLine("          ,D.StockInicial = O.StockInicial")
            .AppendLine("          ,D.Stock = O.Stock")
            '.AppendLine("          ,D.StockReservado = O.StockReservado")
            '.AppendLine("          ,D.StockDefectuoso = O.StockDefectuoso")
            '.AppendLine("          ,D.StockFuturo = O.StockFuturo")
            '.AppendLine("          ,D.StockFuturoReservado = O.StockFuturoReservado")
         End If
         .AppendLine(" WHEN NOT MATCHED THEN")
         .AppendLine("            INSERT(idProducto, idSucursal, precioFabrica, precioCosto, usuario, FechaActualizacion,")
         .AppendLine("                      stock, StockInicial, puntoDePedido, stockMinimo, stockMaximo, ubicacion, stock2, idDepositoDefecto, idUbicacionDefecto)")
         '         .AppendLine("                      StockReservado, StockDefectuoso, StockFuturo, StockFuturoReservado)")
         .AppendLine("            VALUES(O.IdProducto, O.IdSucursal, O.PrecioFabrica, O.PrecioCosto, O.Usuario, O.FechaActualizacion,")
         .AppendLine("                    O.Stock, O.StockInicial, O.PuntoDePedido, O.StockMinimo, O.StockMaximo, O.Ubicacion, 0, 1, 1);")
         '         .AppendLine("                    O.StockReservado, O.StockDefectuoso, O.StockFuturo, O.StockFuturoReservado);")
      End With
      Execute(myQuery)
   End Sub

   Public Function GetListadoDeStock(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito(), idProducto As String,
                                     marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                     rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubrubros As Entidades.SubSubRubro(),
                                     filtroStock As Entidades.EnumSql.Stock_TipoReporte, ordenPor As Entidades.EnumSql.InformeStock_OrdenadoPor,
                                     idProveedor As Long, habitual As Boolean,
                                     listaPorDefecto As Integer, blnPreciosConIVA As Boolean, idListaPrecios As Integer,
                                     stockUnificado As Entidades.EnumSql.InformeStock_UnificadoPor, tipoDeposito As Entidades.SucursalDeposito.TiposDepositos?,
                                     sucursalesVinculadas As Entidades.EnumSql.InformeStock_SucursalVinculada) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT P.IdProducto")
         .AppendFormatLine("     , P.NombreProducto")

         .AppendFormatLine("     , PU.IdEmpresa")
         .AppendFormatLine("     , E.NombreEmpresa")

         .AppendFormatLine("     , PU.IdSucursal")
         .AppendFormatLine("     , S.Nombre NombreSucursal")

         .AppendFormatLine("     , PU.IdDeposito")
         .AppendFormatLine("     , SD.CodigoDeposito")
         .AppendFormatLine("     , SD.NombreDeposito")
         .AppendFormatLine("     , PU.IdUbicacion")
         .AppendFormatLine("     , SU.CodigoUbicacion")
         .AppendFormatLine("     , SU.NombreUbicacion")

         .AppendFormatLine("     , P.Tamano")
         .AppendFormatLine("     , P.IdUnidadDeMedida")

         .AppendFormatLine("     , P.IdMarca")
         .AppendFormatLine("     , P.IdModelo")
         .AppendFormatLine("     , P.IdRubro")
         .AppendFormatLine("     , P.IdSubRubro")
         .AppendFormatLine("     , P.IdSubSubRubro")

         .AppendFormatLine("     , M.NombreMarca")
         .AppendFormatLine("     , Mo.NombreModelo")
         .AppendFormatLine("     , R.NombreRubro")
         .AppendFormatLine("     , SR.NombreSubRubro")
         .AppendFormatLine("     , SSR.NombreSubSubRubro")

         .AppendFormatLine("     , PU.Stock")

         '.AppendFormatLine("     , PS.StockInicial")

         Dim precioCosto = "PU.PrecioCosto"
         Dim precioVenta = "PU.PrecioVenta"
         If blnPreciosConIVA Then
            .AppendFormatLine("     , ROUND({0}, 2) AS PrecioVentaConImpuestos", precioVenta)
            .AppendFormatLine("     , ROUND({0}, 2) AS PrecioCostoConImpuestos", precioCosto)
            .AppendFormatLine("     , ROUND({0}, 2) AS PrecioVentaSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos(precioVenta, "P"))
            .AppendFormatLine("     , ROUND({0}, 2) AS PrecioCostoSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos(precioCosto, "P"))
         Else
            .AppendFormatLine("     , ROUND({0}, 2) AS PrecioVentaConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos(precioVenta, "P"))
            .AppendFormatLine("     , ROUND({0}, 2) AS PrecioCostoConImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos(precioCosto, "P"))
            .AppendFormatLine("     , ROUND({0}, 2) AS PrecioVentaSinImpuestos", precioVenta)
            .AppendFormatLine("     , ROUND({0}, 2) AS PrecioCostoSinImpuestos", precioCosto)
         End If

         If idProveedor > 0 Then
            .AppendFormatLine("     , PP.CodigoProductoProveedor, P.Embalaje")
         Else
            .AppendFormatLine("     , 0 As CodigoProductoProveedor, 0 As Embalaje")
         End If

         '# Proveedor Habitual
         .AppendFormatLine("     , PH.NombreProveedor")
         .AppendFormatLine("     , PPH.CodigoProductoProveedor CodigoProductoProveedorHabitual")
         '-------------------------------------------------------------------------
         .AppendFormatLine("     , SR.GrupoAtributo01")
         .AppendFormatLine("     , SR.TipoAtributo01")
         .AppendFormatLine("     , SR.GrupoAtributo02")
         .AppendFormatLine("     , SR.TipoAtributo02")
         .AppendFormatLine("     , (CASE WHEN SR.GrupoAtributo01 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo01  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine("     + (CASE WHEN SR.GrupoAtributo02 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo02  IS NULL THEN 0 ELSE 1 END) ")
         .AppendFormatLine("     + (CASE WHEN SR.GrupoAtributo03 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo03  IS NULL THEN 0 ELSE 1 END)")
         .AppendFormatLine("     + (CASE WHEN SR.GrupoAtributo04 IS NULL THEN 0 ELSE 1 END) + (CASE WHEN SR.TipoAtributo04  IS NULL THEN 0 ELSE 1 END) AS Atributos")
         '-------------------------------------------------------------------------

         .AppendFormatLine("  FROM (SELECT PS.IdProducto")
         If stockUnificado >= Entidades.EnumSql.InformeStock_UnificadoPor.Empresa Then
            .AppendFormatLine("             , E.IdEmpresa")
         Else
            .AppendFormatLine("             , 0 IdEmpresa")
         End If
         If stockUnificado >= Entidades.EnumSql.InformeStock_UnificadoPor.Sucursal Then
            .AppendFormatLine("             , PU.IdSucursal")
         Else
            .AppendFormatLine("             , 0 IdSucursal")
         End If

         If stockUnificado >= Entidades.EnumSql.InformeStock_UnificadoPor.Ubicacion Then
            .AppendFormatLine("             , PU.IdUbicacion")
            .AppendFormatLine("             , PU.IdDeposito")
         Else
            .AppendFormatLine("             , 0 IdUbicacion")
            .AppendFormatLine("             , 0 IdDeposito")
         End If

         If stockUnificado = Entidades.EnumSql.InformeStock_UnificadoPor.Ubicacion Then
            .AppendFormatLine("             , PU.Stock")
            .AppendFormatLine("             , PSP.PrecioVenta AS PrecioVenta")
            .AppendFormatLine("             , PS.PrecioCosto  AS PrecioCosto")
         Else
            .AppendFormatLine("             , SUM(PU.Stock) Stock")
            If stockUnificado = Entidades.EnumSql.InformeStock_UnificadoPor.Sucursal Then
               .AppendFormatLine("             , MAX(PSP.PrecioVenta) AS PrecioVenta")
               .AppendFormatLine("             , MAX(PS.PrecioCosto)  AS PrecioCosto")
            Else
               .AppendFormatLine("             , ISNULL(SUM(PU.Stock * PSP.PrecioVenta) / NULLIF(SUM(PU.Stock), 0), 0) AS PrecioVenta")
               .AppendFormatLine("             , ISNULL(SUM(PU.Stock * PS.PrecioCosto)  / NULLIF(SUM(PU.Stock), 0), 0) AS PrecioCosto")
            End If
         End If
         .AppendFormatLine("             , P.IdProveedor")

         .AppendFormatLine("          FROM ProductosSucursales PS")
         .AppendFormatLine("         INNER JOIN ProductosUbicaciones PU ON PU.IdProducto = PS.IdProducto AND PU.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("         INNER JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("         INNER JOIN Empresas E ON E.IdEmpresa = S.IdEmpresa")
         .AppendFormatLine("         INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = PS.IdSucursal AND SD.IdDeposito = PU.IdDeposito")
         .AppendFormatLine("         INNER JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendFormatLine("         INNER JOIN ProductosSucursalesPrecios PSP ON PSP.IdSucursal = PS.IdSucursal AND PSP.IdProducto = PS.IdProducto AND PSP.IdListaPrecios = {0}", idListaPrecios)
         .AppendFormatLine("         WHERE P.Activo = 'True'")
         .AppendFormatLine("           AND P.AfectaStock = 'True'")

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("           AND P.IdProducto = '{0}'", idProducto)
         End If

         If habitual Then
            .AppendFormatLine("           AND P.IdProveedor = {0}", idProveedor)
         End If

         GetListaSucursalesMultiples(stbQuery, sucursales, "PS")
         GetListaMarcasMultiples(stbQuery, marcas, "P")
         GetListaModelosMultiples(stbQuery, modelos, "P")
         GetListaRubrosMultiples(stbQuery, rubros, "P")
         GetListaSubRubrosMultiples(stbQuery, subrubros, "P")
         GetListaSubSubRubrosMultiples(stbQuery, subSubrubros, "P")
         GetListaDepositosMultiples(stbQuery, depositos, "PU")

         If tipoDeposito.HasValue Then
            .AppendFormatLine("   AND SD.TipoDeposito = '{0}'", tipoDeposito.Value.ToString())
         End If

         If sucursalesVinculadas <> Entidades.EnumSql.InformeStock_SucursalVinculada.NoAplica Then
            .AppendFormatLine("   AND S.IdSucursal {0} ISNULL(S.IdSucursalAsociada, S.IdSucursal)",
                              If(sucursalesVinculadas = Entidades.EnumSql.InformeStock_SucursalVinculada.Principales, "<=", ">="))
         End If

         If stockUnificado <> Entidades.EnumSql.InformeStock_UnificadoPor.Ubicacion Then
            .AppendFormatLine("         GROUP BY PS.IdProducto")
            .AppendFormatLine("             , P.IdProveedor")
            If stockUnificado >= Entidades.EnumSql.InformeStock_UnificadoPor.Empresa Then
               .AppendFormatLine("             , E.IdEmpresa")
            End If
            If stockUnificado = Entidades.EnumSql.InformeStock_UnificadoPor.Sucursal Then
               .AppendFormatLine("             , PU.IdSucursal")
            End If

         End If

         .AppendFormatLine("        ) PU")

         .AppendFormatLine("  LEFT JOIN SucursalesDepositos   SD ON SD.IdSucursal = PU.IdSucursal AND SD.IdDeposito = PU.IdDeposito")
         .AppendFormatLine("  LEFT JOIN SucursalesUbicaciones SU ON SU.IdSucursal = PU.IdSucursal AND SU.IdDeposito = PU.IdDeposito AND SU.IdUbicacion = PU.IdUbicacion")

         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = PU.IdProducto")
         .AppendFormatLine("  LEFT JOIN Empresas E ON E.IdEmpresa = PU.IdEmpresa")
         .AppendFormatLine("  LEFT JOIN Sucursales S ON S.IdSucursal = PU.IdSucursal")

         .AppendFormatLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("  LEFT JOIN Modelos  Mo ON Mo.IdModelo = P.IdModelo")
         .AppendFormatLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")

         .AppendFormatLine("  LEFT JOIN Proveedores PH ON PH.IdProveedor = PU.IdProveedor")
         .AppendFormatLine("  LEFT JOIN ProductosProveedores PPH ON PPH.IdProducto = PU.IdProducto AND PPH.IdProveedor = PU.IdProveedor")

         If idProveedor > 0 Then
            'GAR: 13/09/2016 Puede no tener compras
            If habitual Then
               .AppendFormatLine("  LEFT JOIN ProductosProveedores PP ON PP.IdProducto = P.Idproducto AND PP.IdProveedor = {0}", idProveedor)
            Else
               .AppendFormatLine(" INNER JOIN ProductosProveedores PP ON PP.IdProducto = P.Idproducto AND PP.IdProveedor = {0}", idProveedor)
            End If
         End If

         .AppendFormatLine(" WHERE 1 = 1")

         If filtroStock <> Entidades.EnumSql.Stock_TipoReporte.General Then
            .AppendFormatLine("   AND {1}.Stock {0}", ToQuery(filtroStock), "PU") ''If(stockUnificado, "PS", "PU"))
         End If

         Select Case ordenPor
            Case Entidades.EnumSql.InformeStock_OrdenadoPor.Alfabetico
               .AppendFormatLine("  ORDER BY P.NombreProducto")
            Case Entidades.EnumSql.InformeStock_OrdenadoPor.Codigo
               .AppendFormatLine("  ORDER BY P.IdProducto")
            Case Entidades.EnumSql.InformeStock_OrdenadoPor.Marca
               .AppendFormatLine("  ORDER BY M.NombreMarca")
            Case Entidades.EnumSql.InformeStock_OrdenadoPor.Rubro
               .AppendFormatLine("  ORDER BY R.NombreRubro")
            Case Entidades.EnumSql.InformeStock_OrdenadoPor.SubRubro
               .AppendFormatLine("  ORDER BY SR.NombreSubRubro")
            Case Else
         End Select

      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetStockPorModelo_ColumnasPivot(sucursales As Entidades.Sucursal(),
                                                   idProducto As String,
                                                   idMarca As Integer,
                                                   idRubro As Integer,
                                                   idSubRubro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("Select DISTINCT 'IdModelo__' + CONVERT(VARCHAR(MAX), P.IdModelo) NombreColumma, P.IdModelo, MO.NombreModelo")
         .AppendFormatLine("  FROM Productos P")
         .AppendFormatLine(" INNER JOIN Modelos MO ON MO.IdModelo = P.IdModelo")
         .AppendFormatLine(" WHERE P.AfectaStock = 1")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If
         If idMarca > 0 Then
            .AppendFormatLine("   AND P.IdMarca = {0}", idMarca)
         End If
         If idRubro > 0 Then
            .AppendFormatLine("   AND P.IdRubro = {0}", idRubro)
         End If
         If idSubRubro > 0 Then
            .AppendFormatLine("   AND P.IdSubRubro = {0}", idSubRubro)
         End If
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetStockPorModelo(sucursales As Entidades.Sucursal(),
                                     idProducto As String,
                                     idMarca As Integer,
                                     idRubro As Integer,
                                     idSubRubro As Integer,
                                     pivotcolName As String,
                                     sumPivot As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P1.IdSucursal")
         .AppendFormatLine("     , P1.NombreSucursal")
         .AppendFormatLine("     , P1.IdRubro")
         .AppendFormatLine("     , P1.NombreRubro")
         .AppendFormatLine("     , P1.OrdenRubro")
         .AppendFormatLine("     , P1.IdMarca")
         .AppendFormatLine("     , P1.NombreMarca")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         .AppendFormatLine("  FROM (SELECT PS.IdSucursal")
         .AppendFormatLine("             , S.Nombre NombreSucursal")
         .AppendFormatLine("             , PS.IdProducto")
         .AppendFormatLine("             , P.NombreProducto")
         .AppendFormatLine("             , P.IdRubro")
         .AppendFormatLine("             , R.NombreRubro")
         .AppendFormatLine("             , R.Orden OrdenRubro")
         .AppendFormatLine("             , P.IdMarca")
         .AppendFormatLine("             , M.NombreMarca")
         .AppendFormatLine("             , 'IdModelo__' + CONVERT(VARCHAR(MAX), P.IdModelo) IdModelo")
         .AppendFormatLine("             , MO.NombreModelo")
         .AppendFormatLine("             , PS.Stock")
         .AppendFormatLine("          FROM ProductosSucursales PS")
         .AppendFormatLine("         INNER JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendFormatLine("         INNER JOIN Sucursales S ON S.IdSucursal = PS.IdSucursal")
         .AppendFormatLine("         INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendFormatLine("         INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendFormatLine("         INNER JOIN Modelos MO ON MO.IdModelo = P.IdModelo")
         .AppendFormatLine("         WHERE P.AfectaStock = 1")

         GetListaSucursalesMultiples(stb, sucursales, "PS")

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("           AND P.IdProducto = '{0}'", idProducto)
         End If
         If idMarca > 0 Then
            .AppendFormatLine("           AND P.IdMarca = {0}", idMarca)
         End If
         If idRubro > 0 Then
            .AppendFormatLine("           AND P.IdRubro = {0}", idRubro)
         End If
         If idSubRubro > 0 Then
            .AppendFormatLine("           AND P.IdSubRubro = {0}", idSubRubro)
         End If

         .AppendFormatLine("        ) P")
         .AppendFormatLine(" PIVOT(SUM(Stock) FOR P.IdModelo in ({0})) AS P1", pivotcolName)
         .AppendFormatLine(" GROUP BY P1.IdSucursal")
         .AppendFormatLine("        , P1.NombreSucursal")
         .AppendFormatLine("        , P1.IdRubro")
         .AppendFormatLine("        , P1.NombreRubro")
         .AppendFormatLine("        , P1.OrdenRubro")
         .AppendFormatLine("        , P1.IdMarca")
         .AppendFormatLine("        , P1.NombreMarca")
         .AppendFormatLine(" ORDER BY P1.IdSucursal, P1.OrdenRubro")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetListaCosto(idSucursal As Integer,
                                 idListaPrecios As Integer,
                                 idMarca As Integer,
                                 rubros As Entidades.Rubro(),
                                 subrubros As Entidades.SubRubro(),
                                 subsubrubros As Entidades.SubSubRubro(),
                                 fechaActualizadoDesde As Date,
                                 fechaActualizadoHasta As Date,
                                 consultarPreciosOcultarProdNoAfectanStock As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      Dim CampoFecha As String
      With stbQuery
         .AppendLine("SELECT p.idproducto")
         .AppendLine("       ,p.nombreproducto")
         .AppendLine("       ,p.tamano")
         .AppendLine("       ,p.idunidaddemedida")
         .AppendLine("       ,p.idmarca")
         .AppendLine("       ,p.idrubro")
         .AppendLine("       ,pr.CodigoProveedor")
         .AppendLine("       ,pr.NombreProveedor")
         .AppendLine("       ,ps.preciofabrica")
         .AppendLine("       ,ps.preciocosto")
         .AppendLine("       ,psp.precioventa")
         .AppendLine("       ,r.nombrerubro,")
         CampoFecha = "PSP.FechaActualizacion"
         .AppendLine(CampoFecha)
         .AppendLine("       ,m.nombremarca")
         .AppendLine("       ,p.IdTipoImpuesto")
         .AppendLine("       ,p.Alicuota")
         .AppendLine("       ,Mo.NombreMoneda")
         .AppendLine("       ,P.CodigoDeBarras")

         .AppendLine(" FROM productos p")

         .AppendLine(" LEFT JOIN Proveedores pr on p.IdProveedor = pr.IdProveedor")
         .AppendLine(" INNER JOIN Rubros r on p.IdRubro = r.IdRubro")
         .AppendLine(" INNER JOIN Marcas m on p.IdMarca = m.IdMarca")
         .AppendLine(" INNER JOIN Monedas mo on p.IdMoneda = mo.IdMoneda")
         .AppendLine(" INNER JOIN ProductosSucursales ps on p.IdProducto = ps.IdProducto AND ps.Idsucursal = " & idSucursal)
         .AppendLine(" INNER JOIN ProductosSucursalesPrecios PSP on p.IdProducto = PSP.IdProducto AND PSP.IdSucursal = ps.IdSucursal")
         .AppendLine(" WHERE 1=1")

         .AppendLine("   AND P.Activo = 'True'")

         If consultarPreciosOcultarProdNoAfectanStock Then
            .AppendLine(" AND P.AfectaStock = 'True'")
         End If

         'If Not String.IsNullOrEmpty(IdMarca) Then

         If idMarca > 0 Then
            .AppendLine("   AND p.idmarca = " & idMarca.ToString())
         End If

         'If IdRubro > 0 Then
         '   .AppendLine("   AND p.idrubro = " & IdRubro.ToString())
         'End If

         GetListaRubrosMultiples(stbQuery, rubros, "P")
         GetListaSubRubrosMultiples(stbQuery, subrubros, "P")
         GetListaSubSubRubrosMultiples(stbQuery, subsubrubros, "P")

         If fechaActualizadoDesde > Date.Parse("01/01/1990") Then
            .AppendLine("	 AND " & CampoFecha & " >= '" & fechaActualizadoDesde.ToString("yyyyMMdd HH:mm:ss") & "'")
            .AppendLine("	 AND " & CampoFecha & " <= '" & fechaActualizadoHasta.ToString("yyyyMMdd HH:mm:ss") & "'")
         End If

         If idListaPrecios > -1 Then
            .AppendFormatLine("   AND PSP.IdListaPrecios = {0}", idListaPrecios)
         End If

      End With

      Return GetDataTable(stbQuery)
   End Function

   Public Function GetProductosPorUbicacionPredeterminada(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT PS.IdSucursal, PS.IdDepositoDefecto, PS.IdUbicacionDefecto")
         .AppendFormatLine("     , PS.IdProducto, P.NombreProducto")
         .AppendFormatLine("  FROM ProductosSucursales PS")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendFormatLine(" WHERE PS.IdSucursal         = {0}", idSucursal)
         .AppendFormatLine("   AND PS.IdDepositoDefecto  = {0}", idDeposito)
         If idUbicacion > 0 Then
            .AppendFormatLine("   AND PS.IdUbicacionDefecto  = {0}", idUbicacion)
         End If
         .AppendFormatLine(" ORDER BY P.NombreProducto")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function GetSucursalesDepositoStock(idSucursal As Integer, idDeposito As Integer, idProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT PD.IdSucursal, PD.IdDeposito, PD.Stock")
         .AppendFormatLine("     , PD.IdProducto, P.NombreProducto")
         .AppendFormatLine("  FROM ProductosDepositos PD")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = PD.IdProducto")
         .AppendFormatLine(" WHERE PD.IdSucursal  = {0}", idSucursal)
         .AppendFormatLine("   AND PD.IdDeposito  = {0}", idDeposito)
         .AppendFormatLine("   AND PD.IdProducto  = '{0}'", idProducto)
         .AppendFormatLine(" ORDER BY P.NombreProducto")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function GetSucursalProductosStock(idSucursal As Integer, idProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT PS.IdSucursal, PS.IdProducto, P.NombreProducto, PS.Stock")
         .AppendFormatLine("  FROM ProductosSucursales PS")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = PS.IdProducto")
         .AppendFormatLine(" WHERE PS.IdSucursal  = {0}", idSucursal)
         .AppendFormatLine("   AND PS.IdProducto  = '{0}'", idProducto)
         .AppendFormatLine(" ORDER BY P.NombreProducto")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function GetSucursalProductosDeposito(idSucursal As Integer, idProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT PS.IdSucursal, PS.IdProducto, PS.IdDepositoDefecto")
         .AppendFormatLine("  FROM ProductosSucursales PS")
         .AppendFormatLine(" WHERE PS.IdSucursal  = {0}", idSucursal)
         .AppendFormatLine("   AND PS.IdProducto  = '{0}'", idProducto)
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function GetSucursalesPorDepositDefecto(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM ProductosSucursales as PS")
         .AppendFormatLine("     WHERE PS.IdSucursal = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND PS.IdDepositoDefecto = {0}", IdDeposito)
         End If
      End With

      Return GetDataTable(stb)
   End Function
End Class
