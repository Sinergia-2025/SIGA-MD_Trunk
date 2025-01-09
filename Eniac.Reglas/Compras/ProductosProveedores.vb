Public Class ProductosProveedores
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ProductosProveedores"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProductoProveedor), TipoSP._I))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ProductoProveedor), TipoSP._D))
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Proveedores(da).Proveedores_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProductoProveedor, tipo As TipoSP)
      Dim sql As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)
      Select Case tipo
         Case TipoSP._I
            sql.ProductosProveedores_I(en.IdProveedor, en.IdProducto, en.CodigoProductoProveedor, en.UltimoPrecioCompra, en.UltimaFechaCompra,
                                       en.UltimoPrecioFabrica, en.DescuentoRecargoPorc1, en.DescuentoRecargoPorc2, en.DescuentoRecargoPorc3,
                                       en.DescuentoRecargoPorc4, en.DescuentoRecargoPorc5, en.DescuentoRecargoPorc6)

         Case TipoSP._D
            sql.ProductosProveedores_D(en.IdProveedor)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ProductoProveedor, dr As DataRow)
      With o
         .IdProveedor = dr.Field(Of Long)(Entidades.ProductoProveedor.Columnas.IdProveedor.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.IdProducto.ToString())
         .CodigoProductoProveedor = dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()).IfNull()
         .UltimoPrecioCompra = dr.Field(Of Decimal?)(Entidades.ProductoProveedor.Columnas.UltimoPrecioCompra.ToString()).IfNull()
         .UltimaFechaCompra = dr.Field(Of Date?)(Entidades.ProductoProveedor.Columnas.UltimaFechaCompra.ToString()).IfNull()
         .UltimoPrecioFabrica = dr.Field(Of Decimal?)(Entidades.ProductoProveedor.Columnas.UltimoPrecioFabrica.ToString()).IfNull()

         .DescuentoRecargoPorc1 = dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1.ToString())
         .DescuentoRecargoPorc2 = dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2.ToString())
         .DescuentoRecargoPorc3 = dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3.ToString())
         .DescuentoRecargoPorc4 = dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4.ToString())
         .DescuentoRecargoPorc5 = dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc5.ToString())
         .DescuentoRecargoPorc6 = dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc6.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetPorProveedor(IdProveedor As Long, Optional BusquedaParcial As Boolean = True) As DataTable
      Return New SqlServer.ProductosProveedores(da).ProductosProveedores_GA(IdProveedor, String.Empty, String.Empty, False)
   End Function

   Public Function GetPorProductoYProveedor(IdProveedor As Long?, idProducto As String, ordenardoPor As String, descendente As Boolean) As DataTable
      Return New SqlServer.ProductosProveedores(da).ProductosProveedores_GA(IdProveedor, idProducto, ordenardoPor, descendente)
   End Function
   Public Function GetPorProductoYProveedor(IdProveedor As Long?, idProducto As String) As DataTable
      Return New SqlServer.ProductosProveedores(da).ProductosProveedores_GA(IdProveedor, idProducto, String.Empty, False)
   End Function

   Public Function GetUno(idProveedor As Long, idProducto As String) As Entidades.ProductoProveedor
      Return GetUno(idProveedor, idProducto, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idProveedor As Long, idProducto As String, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoProveedor
      Return CargaEntidad(GetPorProductoYProveedor(idProveedor, idProducto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoProveedor(idProveedor, idProducto, ultimaFechaCompra:=Nothing),
                          accion, Function() String.Format("No se encontró Producto Proveedor con Id proveedor {0} y Id producto {1}", idProveedor, idProducto))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProductoProveedor)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoProveedor())
   End Function

   Public Sub InsertarProductoProveedor(idProveedor As Long,
                                        idProducto As String,
                                        codigoProductoProveedor As String,
                                        precio As Decimal,
                                        fecha As Date,
                                        ultimoPrecioFabrica As Decimal,
                                        descuentoRecargoPorc1 As Decimal,
                                        descuentoRecargoPorc2 As Decimal,
                                        descuentoRecargoPorc3 As Decimal,
                                        descuentoRecargoPorc4 As Decimal,
                                        descuentoRecargoPorc5 As Decimal,
                                        descuentoRecargoPorc6 As Decimal,
                                        proveedorHabitual As Boolean)

      Dim sql As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(da)
      sql.ProductosProveedores_I(idProveedor, idProducto, codigoProductoProveedor, precio, fecha, ultimoPrecioFabrica, descuentoRecargoPorc1, descuentoRecargoPorc2, descuentoRecargoPorc3, descuentoRecargoPorc4, descuentoRecargoPorc5, descuentoRecargoPorc6)
   End Sub

   Public Sub GrabarProductosProveedores(idProveedor As Long, productosProv As DataTable)
      EjecutaConTransaccion(
         Sub()
            Dim sql = New SqlServer.ProductosProveedores(da)

            sql.ProductosProveedores_D(idProveedor)

            sql.ProductosProveedores_M(productosProv.AsEnumerable().ToList())

            'For Each dr As DataRow In productosProv.Rows
            '   Dim fechaCompra = dr.Field(Of Date?)(Entidades.ProductoProveedor.Columnas.UltimaFechaCompra.ToString()).IfNull()

            '   sql.ProductosProveedores_I(dr.Field(Of Long)(Entidades.ProductoProveedor.Columnas.IdProveedor.ToString()),
            '                              dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.IdProducto.ToString()),
            '                              dr.Field(Of String)(Entidades.ProductoProveedor.Columnas.CodigoProductoProveedor.ToString()),
            '                              dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.UltimoPrecioCompra.ToString()),
            '                              fechaCompra,
            '                              dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.UltimoPrecioFabrica),
            '                              dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc1),
            '                              dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc2),
            '                              dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc3),
            '                              dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc4),
            '                              dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc5),
            '                              dr.Field(Of Decimal)(Entidades.ProductoProveedor.Columnas.DescuentoRecargoPorc6))
            'Next
         End Sub)

   End Sub

   Public Sub ActualizarUltimoPrecioCompra(idProveedor As Long, idProducto As String, precio As Decimal, fecha As Date)
      Dim sql = New SqlServer.ProductosProveedores(da)
      sql.ActualizaPrecioUltimaCompra(idProveedor, idProducto, precio, fecha)
   End Sub
   Public Sub ActualizaCodigoProductoProveedor(idProveedor As Long, idProducto As String, codigoProductoProveedor As String)
      Dim sql = New SqlServer.ProductosProveedores(da)
      sql.ActualizaCodigoProductoProveedor(idProveedor, idProducto, codigoProductoProveedor)
   End Sub

   Public Function GetPorCodigoProdProv(idProducto As String, idSucursal As Integer,
                                        idListaPrecios As Integer, modulo As String, idProveedor As Long,
                                        soloCompuestos As Boolean, soloBuscaPorIdProducto As Boolean) As DataTable
      Dim strAnchoIdProducto As String = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()
      Dim condicionParaCombinarCodigoNombre As String = " OR "

      Dim cotDolar = New Monedas(da).GetUna(Entidades.Moneda.Dolar).FactorConversion

      Dim dt = New SqlServer.Productos(da).GetPorCodigoNombreParaBusquedas(idSucursal,
                                                                           idListaPrecios,
                                                                           idProducto, True,
                                                                           String.Empty, False,
                                                                           condicionParaCombinarCodigoNombre,
                                                                           modulo, soloCompuestos,
                                                                           "NORMAL", False, Entidades.Producto.TiposOperaciones.NORMAL,
                                                                           Nothing, strAnchoIdProducto,
                                                                           Publicos.ProductoCodigoQuitarBlancos,
                                                                           Publicos.ProductoUtilizaCodigoDeBarras,
                                                                           Publicos.ProductoUtilizaCodigoLargoProducto,
                                                                           Publicos.ProductoFormatoLikeBuscarPorCodigoResuelto,
                                                                           Publicos.ProductoFormatoLikeBuscarPorNombreResuelto,
                                                                           Publicos.BuscaProductoPorProveedorHabitual,
                                                                           Publicos.PreciosConIVA,
                                                                           Nothing, Nothing, 0, 0,
                                                                           busquedaPorCodigoProductoProveedor:=True,
                                                                           idCliente:=0,
                                                                           productosCliente:=False,
                                                                           soloProductosConStock:=False,
                                                                           soloBuscaPorIdProducto:=soloBuscaPorIdProducto,
                                                                           redondeoEnPreciosVenta:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio,
                                                                           idProveedorDeCompra:=idProveedor,
                                                                           soloCargaProductosDelProveedor:=Reglas.Publicos.ComprasSoloCargaProductosDelProveedor,
                                                                           soloTipoCalidadCompras:=False,
                                                                           cotDolar)

      If dt.Rows.Count > 0 Then
         Return dt
      End If

      dt = New SqlServer.Productos(da).GetPorCodigoNombreParaBusquedas(idSucursal,
                                                                       idListaPrecios,
                                                                       idProducto, False,
                                                                       String.Empty, False,
                                                                       condicionParaCombinarCodigoNombre,
                                                                       modulo, soloCompuestos,
                                                                       "NORMAL", False, Entidades.Producto.TiposOperaciones.NORMAL,
                                                                       Nothing, strAnchoIdProducto,
                                                                       Publicos.ProductoCodigoQuitarBlancos,
                                                                       Publicos.ProductoUtilizaCodigoDeBarras,
                                                                       Publicos.ProductoUtilizaCodigoLargoProducto,
                                                                       Publicos.ProductoFormatoLikeBuscarPorCodigoResuelto,
                                                                       Publicos.ProductoFormatoLikeBuscarPorNombreResuelto,
                                                                       Publicos.BuscaProductoPorProveedorHabitual,
                                                                       Publicos.PreciosConIVA,
                                                                       Nothing, Nothing, 0, 0,
                                                                       busquedaPorCodigoProductoProveedor:=True,
                                                                       idCliente:=0,
                                                                       productosCliente:=False,
                                                                       soloProductosConStock:=False,
                                                                       soloBuscaPorIdProducto:=soloBuscaPorIdProducto,
                                                                       redondeoEnPreciosVenta:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio,
                                                                       idProveedorDeCompra:=idProveedor,
                                                                       soloCargaProductosDelProveedor:=Reglas.Publicos.ComprasSoloCargaProductosDelProveedor,
                                                                       soloTipoCalidadCompras:=False,
                                                                       cotDolar)

      Return dt

   End Function

   Public Function GetInforme(idProveedor As Long, habitual As Boolean, idProducto As String,
                              idMarca As Integer, rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subsubrubros As Entidades.SubSubRubro(),
                              fechaDesde As Date, fechaHasta As Date, idMoneda As Integer) As DataTable
      Return New SqlServer.ProductosProveedores(da).GetInforme(idProveedor, habitual, idProducto,
                                                               idMarca, rubros, subrubros, subsubrubros,
                                                               fechaDesde, fechaHasta, idMoneda)
   End Function

#End Region

End Class