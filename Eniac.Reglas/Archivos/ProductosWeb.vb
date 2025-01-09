Public Class ProductosWeb
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ProductosWeb"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ProductosWeb"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)

      Dim produ As Entidades.ProductoWeb = DirectCast(entidad, Entidades.ProductoWeb)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Inserta(produ)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Inserta(ByVal produ As Eniac.Entidades.ProductoWeb)

      'Inserto el Registro en la tabla Maestra
      Me.EjecutaSP(produ, TipoSP._I)



   End Sub

   'Private Sub GrabaPrecios(produ As Entidades.Producto)
   '   Dim precioFabrica As Decimal = 0
   '   Dim precioCosto As Decimal = 0

   '   If produ.ProductoProveedorHabitual IsNot Nothing Then
   '      precioFabrica = produ.ProductoProveedorHabitual.UltimoPrecioFabrica
   '   End If

   '   precioCosto = produ.PrecioCosto

   '   If produ.Precios IsNot Nothing Then
   '      Dim reglaPS As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(Me.da)
   '      Dim precios As List(Of Entidades.ProductoSucursal) = New List(Of Entidades.ProductoSucursal)()
   '      Dim prc As Entidades.ProductoSucursal = New Entidades.ProductoSucursal()

   '      prc.Producto = produ
   '      prc.Sucursal.IdSucursal = actual.Sucursal.IdSucursal
   '      prc.Sucursal.Id = actual.Sucursal.IdSucursal
   '      prc.IdSucursal = actual.Sucursal.IdSucursal
   '      prc.Precios = New List(Of Entidades.ProductoSucursalPrecio)()
   '      prc.Usuario = actual.Nombre
   '      prc.FechaActualizacion = Now

   '      prc.PrecioFabrica = precioFabrica
   '      prc.PrecioCosto = precioCosto
   '      precios.Add(prc)

   '      For Each dr As DataRow In produ.Precios.Rows
   '         'If CInt(dr("IdListaPrecios")) = 0 Then
   '         '   prc.PrecioVenta = CDec(dr("PrecioVenta"))
   '         'End If

   '         Dim lprc As Entidades.ProductoSucursalPrecio = New Entidades.ProductoSucursalPrecio()
   '         lprc.ProductoSucursal = prc
   '         lprc.ListaDePrecios = New Entidades.ListaDePrecios()
   '         lprc.ListaDePrecios.IdListaPrecios = CInt(dr("IdListaPrecios"))
   '         lprc.PrecioVenta = CDec(dr("PrecioVenta"))
   '         lprc.Usuario = actual.Nombre
   '         lprc.IdSucursal = actual.Sucursal.IdSucursal
   '         lprc.FechaActualizacion = Now

   '         prc.Precios.Add(lprc)
   '      Next

   '      reglaPS._ModificarPrecios(precios)

   '   End If
   'End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim produ As Entidades.Producto = DirectCast(entidad, Entidades.Producto)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Actualiza(produ)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Actualiza(ByVal produ As Eniac.Entidades.Producto)
      Me.EjecutaSP(produ, TipoSP._U)
      'GrabaPrecios(produ)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim produ As Entidades.ProductoWeb = DirectCast(entidad, Entidades.ProductoWeb)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(produ, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Borra(ByVal produ As Eniac.Entidades.Producto)
      Me.EjecutaSP(produ, TipoSP._D)
   End Sub

   Public Sub AjustarStock(ByVal idSucursal As Integer,
                           ByVal idProducto As String,
                           ByVal tablaContabilidad As DataTable,
                           ByVal grabaAutomatico As Boolean,
                           ByVal esMultipleRubro As Boolean,
                           ByVal nuevoStock As Decimal,
                           ByVal MetodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                           ByVal IdFuncion As String)

      Try

         Dim TipoMovimiento As Entidades.TipoMovimiento = New Reglas.TiposMovimientos().GetUno("AJUSTE")

         Dim oProdSuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales
         Dim ProdSuc As Entidades.ProductoSucursal
         ProdSuc = oProdSuc.GetUno(idSucursal, idProducto)

         Dim LineaProductoCompra As New System.Collections.Generic.List(Of Entidades.MovimientoStockProducto)
         Dim oLineaDetalle As Entidades.MovimientoStockProducto = New Entidades.MovimientoStockProducto()

         With oLineaDetalle
            .IdProducto = idProducto
            .NombreProducto = ProdSuc.Producto.NombreProducto
            .DescuentoRecargo = 0
            If TipoMovimiento.CargaPrecio = "PrecioCosto" Then
               .Precio = ProdSuc.PrecioCosto
            ElseIf TipoMovimiento.CargaPrecio = "PrecioVenta" Then
               .Precio = oProdSuc.GetPrecioVentaPredeterminado(idSucursal, idProducto)
            Else
               .Precio = 0
            End If

            .Cantidad = nuevoStock

            .ImporteTotal = Decimal.Round(.Precio * .Cantidad, 2)
            .PorcentajeIVA = 0
            .IVA = 0
            .TotalProducto = .ImporteTotal
            .Stock = ProdSuc.Stock
            .IdSucursal = actual.Sucursal.Id
            .Usuario = actual.Nombre
            .IdLote = ""
            .VtoLote = Nothing
            .Orden = 1
         End With

         LineaProductoCompra.Add(oLineaDetalle)

         '---------------------------------------------

         Dim oMov = New Entidades.MovimientoStock()
         Dim oCF As Entidades.CategoriaFiscal = Nothing

         With oMov
            .Sucursal = New Reglas.Sucursales().GetUna(idSucursal, False)

            '.Sucursal2 = 0

            .TipoMovimiento = TipoMovimiento
            .FechaMovimiento = Date.Now

            .DescuentoRecargo = 0

            .Total = oLineaDetalle.ImporteTotal

            '.Proveedor.CategoriaFiscal.IvaDiscriminado = Me._categoriaFiscal.IvaDiscriminado

            .PercepcionIVA = 0
            .PercepcionIB = 0
            .PercepcionGanancias = 0
            .PercepcionVarias = 0

            .Comentarios = "** AJUSTE AUTOMATICO ***"
            .Observacion = "** AJUSTE AUTOMATICO ***"

            .Productos = LineaProductoCompra
            .ProductosLotes = Nothing

            .Usuario = actual.Nombre

            'vml 3/12/12, agrego la parte contable
            .tablaContabilidad = tablaContabilidad
            ' fin parte contable

         End With

         da.OpenConection()
         da.BeginTransaction()

         If ProdSuc.Producto.Lote Then
            'Si bien lo mas prolijo seria elegir lo que hay, por ahora (para siempre) lo limpia
            Dim sqlPL As SqlServer.ProductosLotes = New SqlServer.ProductosLotes(da)
            sqlPL.ProductosLotes_DProd(idSucursal, idProducto)
            '------------------------
         End If

         If ProdSuc.Producto.NroSerie Then
            'Si bien lo mas prolijo seria elegir lo que hay, por ahora (para siempre) lo limpia
            Dim sqlPS As SqlServer.ProductosNrosSerie = New SqlServer.ProductosNrosSerie(da)
            sqlPS.ProductosNrosSerie_DProd(idSucursal, idProducto)
            '------------------------
         End If

         Dim oMovimientos = New MovimientosStock(da)

         oMovimientos.CargarMovimientoStock(oMov, MetodoGrabacion, IdFuncion)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub InactivarProductos(ByVal idMarca As Integer)
      Dim sql As SqlServer.Productos = New SqlServer.Productos(Me.da)
      sql.Productos_InactivarProductos(idMarca)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable

      Select Case entidad.Columna
         Case "NombreMarca"
            entidad.Columna = "M." + entidad.Columna
         Case "NombreModelo"
            entidad.Columna = "MO." + entidad.Columna
         Case "NombreRubro"
            entidad.Columna = "R." + entidad.Columna
         Case "NombreSubRubro"
            entidad.Columna = "SR." + entidad.Columna
         Case "NombreMoneda"
            entidad.Columna = "Mn." + entidad.Columna
         Case "Ubicacion", "FechaActualizacion", "StockMinimo", "PuntoDePedido", "StockMaximo"
            entidad.Columna = "PS." + entidad.Columna
         Case "StockActual"
            entidad.Columna = "PS.Stock"
         Case "NombreCentroCosto"
            entidad.Columna = "CECO." + entidad.Columna
         Case "NombreProduccionProceso"
            entidad.Columna = "PRP." + entidad.Columna
         Case "NombreProduccionForma"
            entidad.Columna = "PRF." + entidad.Columna
         Case Else
            entidad.Columna = "P." + entidad.Columna
      End Select

      Dim stbQuery As StringBuilder = New StringBuilder("")

      Dim consultaFoto As Boolean = False
      Dim espaciosID As Boolean = True
      Dim base As String = Publicos.NombreBaseProductosWeb

      With stbQuery
         Me.SelectFiltrado(stbQuery, consultaFoto, espaciosID, base)
         '.AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")

         .AppendLine("  WHERE 1=1 ")

         Dim Palabras() As String = entidad.Valor.ToString.Split(" "c)

         For Each Palabra As String In Palabras
            .AppendLine("   AND " & entidad.Columna & " LIKE '%" & Palabra & "%'")
         Next

         .AppendLine(" ORDER BY P.NombreProducto ")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Productos(Me.da).Productos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal produ As Entidades.ProductoWeb, ByVal tipo As TipoSP)

      'Dim sql As SqlServer.Productos = New SqlServer.Productos(Me.da)
      'Dim sql1 As SqlServer.ProductosConceptos = New SqlServer.ProductosConceptos(Me.da)
      'Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
      'Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
      'Dim dtAudit As DataTable = New DataTable()
      'Dim OperacAudit As SqlServer.Auditorias.Operaciones

      'Dim idProveedor As Long = 0
      'If produ.Proveedor IsNot Nothing Then
      '   idProveedor = produ.Proveedor.IdProveedor
      'End If

      'Dim idCuentaCompras As Long?
      'Dim idCuentaVentas As Long?
      'Dim IdCuentaComprasSecundaria As Long?

      'If produ.CuentaCompras IsNot Nothing AndAlso produ.CuentaCompras.IdCuenta > 0 Then idCuentaCompras = produ.CuentaCompras.IdCuenta
      'If produ.CuentaVentas IsNot Nothing AndAlso produ.CuentaVentas.IdCuenta > 0 Then idCuentaVentas = produ.CuentaVentas.IdCuenta
      'If produ.CuentaComprasSecundaria IsNot Nothing AndAlso produ.CuentaComprasSecundaria.IdCuenta > 0 Then IdCuentaComprasSecundaria = produ.CuentaComprasSecundaria.IdCuenta

      'Select Case tipo
      '   Case TipoSP._I
      '      sql.Productos_I(produ.IdProducto, produ.NombreProducto, produ.Tamano, produ.UnidadDeMedida.IdUnidadDeMedida, _
      '                        produ.IdMarca, produ.IdModelo, produ.IdRubro, produ.IdSubRubro, produ.MesesGarantia, produ.IdTipoImpuesto, _
      '                        produ.Alicuota, produ.Alicuota2, produ.AfectaStock, produ.Activo, produ.Lote, produ.NroSerie, produ.CodigoDeBarras, _
      '                        produ.EsServicio, produ.PublicarEnWeb, produ.Observacion, produ.EsCompuesto, produ.DescontarStockComponentes, _
      '                        produ.EsDeCompras, produ.EsDeVentas, produ.Moneda.IdMoneda, produ.CodigoDeBarrasConPrecio, produ.PermiteModificarDescripcion, _
      '                        produ.EsAlquilable, produ.EquipoMarca, produ.EquipoModelo, produ.CaractSII, produ.NumeroSerie, produ.Anio, _
      '                        produ.PagaIngresosBrutos, produ.Embalaje, produ.Kilos, produ.IdFormula, produ.IdProductoMercosur, produ.IdProductoSecretaria, _
      '                        produ.PublicarListaDePreciosClientes, produ.FacturacionCantidadNegativa, produ.SolicitaEnvase, produ.AlertaDeCaja, _
      '                        produ.nombreCorto, produ.EsRetornable, produ.Orden, idProveedor, produ.CodigoLargoProducto, produ.ModalidadCodigoDeBarras,
      '                        produ.EsObservacion, produ.UnidHasta1, produ.UnidHasta2, produ.UnidHasta3, produ.UnidHasta4, produ.UnidHasta5,
      '                        produ.UHPorc1, produ.UHPorc2, produ.UHPorc3, produ.UHPorc4, produ.UHPorc5, _
      '                        produ.PrecioPorEmbalaje, idCuentaCompras, idCuentaVentas, produ.ImporteImpuestoInterno, produ.EsOferta, IdCuentaComprasSecundaria,
      '                        produ.IncluirExpensas, produ.IdCentroCosto, produ.ObservacionCompras, produ.SolicitaPrecioVentaPorTamano,
      '                        produ.Espmm, produ.EspPulgadas, produ.CodigoSAE, produ.IdProduccionProceso, produ.IdProduccionForma,
      '                        produ.CalculaPreciosSegunFormula, produ.IdSubSubRubro, produ.Caracteristica1, produ.ValorCaracteristica1,
      '                        produ.Caracteristica2, produ.ValorCaracteristica2, produ.Caracteristica3, produ.ValorCaracteristica3)

      '      sql.GrabarFoto(produ.Foto, produ.IdProducto)

      '      rAudit.Insertar("Productos", SqlServer.Auditorias.Operaciones.Alta, actual.Nombre, "IdProducto = '" & produ.IdProducto & "'")


      '      'Graba Conceptos
      '      '  sql1.ProductosConceptos_D(produ.IdProducto)

      '      For Each dr As Entidades.ProductoConcepto In produ.Conceptos
      '         sql1.ProductosConceptos_I(dr.IdProducto, dr.IdConcepto)
      '      Next

      '      If produ.Proveedor IsNot Nothing AndAlso produ.ProductoProveedorHabitual IsNot Nothing Then
      '         Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(Me.da)
      '         sqlPP.ProductosProveedores_I(idProveedor, produ.IdProducto, produ.ProductoProveedorHabitual.CodigoProductoProveedor,
      '                                      produ.ProductoProveedorHabitual.UltimoPrecioCompra,
      '                                      produ.ProductoProveedorHabitual.UltimaFechaCompra,
      '                                      produ.ProductoProveedorHabitual.UltimoPrecioFabrica,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc1,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc2,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc3,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc4,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc5,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc6)
      '      End If

      '   Case TipoSP._U
      '      'Modifica descripcion si producto NO PermiteModificarDescripcion
      '      Dim NombreProductoAnterior As String
      '      NombreProductoAnterior = sql.GetDescripcionProducto(produ.IdProducto)
      '      Dim sqlVentaProducto As SqlServer.VentasProductos = New SqlServer.VentasProductos(Me.da)
      '      Dim sqlCompraProducto As SqlServer.ComprasProductos = New SqlServer.ComprasProductos(Me.da)

      '      If NombreProductoAnterior <> produ.NombreProducto And produ.PermiteModificarDescripcion = False Then
      '         sqlVentaProducto.VentasProductos_UDescripcion(produ.IdProducto, produ.NombreProducto)
      '         sqlCompraProducto.ComprasProductos_UDescripcion(produ.IdProducto, produ.NombreProducto)
      '      End If

      '      sql.Productos_U(produ.IdProducto, produ.NombreProducto, produ.Tamano, produ.UnidadDeMedida.IdUnidadDeMedida, _
      '                        produ.IdMarca, produ.IdModelo, produ.IdRubro, produ.IdSubRubro, produ.MesesGarantia, produ.IdTipoImpuesto, _
      '                        produ.Alicuota, produ.Alicuota2, produ.AfectaStock, produ.Activo, produ.Lote, produ.NroSerie, produ.CodigoDeBarras, _
      '                        produ.EsServicio, produ.PublicarEnWeb, produ.Observacion, produ.EsCompuesto, produ.DescontarStockComponentes, _
      '                        produ.EsDeCompras, produ.EsDeVentas, produ.Moneda.IdMoneda, produ.CodigoDeBarrasConPrecio, produ.PermiteModificarDescripcion, _
      '                        produ.EsAlquilable, produ.EquipoMarca, produ.EquipoModelo, produ.CaractSII, produ.NumeroSerie, produ.Anio, _
      '                        produ.PagaIngresosBrutos, produ.Embalaje, produ.Kilos, produ.IdFormula, produ.IdProductoMercosur, produ.IdProductoSecretaria, _
      '                        produ.PublicarListaDePreciosClientes, produ.FacturacionCantidadNegativa, produ.SolicitaEnvase, produ.AlertaDeCaja, _
      '                        produ.nombreCorto, produ.EsRetornable, produ.Orden, idProveedor, produ.CodigoLargoProducto, produ.ModalidadCodigoDeBarras,
      '                        produ.EsObservacion, produ.UnidHasta1, produ.UnidHasta2, produ.UnidHasta3, produ.UnidHasta4, produ.UnidHasta5,
      '                        produ.UHPorc1, produ.UHPorc2, produ.UHPorc3, produ.UHPorc4, produ.UHPorc5, _
      '                        produ.PrecioPorEmbalaje, idCuentaCompras, idCuentaVentas, produ.ImporteImpuestoInterno, produ.EsOferta, IdCuentaComprasSecundaria,
      '                        produ.IncluirExpensas, produ.IdCentroCosto, produ.ObservacionCompras, produ.SolicitaPrecioVentaPorTamano,
      '                        produ.Espmm, produ.EspPulgadas, produ.CodigoSAE, produ.IdProduccionProceso, produ.IdProduccionForma,
      '                        produ.CalculaPreciosSegunFormula, produ.IdSubSubRubro, produ.Caracteristica1, produ.ValorCaracteristica1,
      '                        produ.Caracteristica2, produ.ValorCaracteristica2, produ.Caracteristica3, produ.ValorCaracteristica3)

      '      sql.GrabarFoto(produ.Foto, produ.IdProducto)

      '      'Por las dudas lanzo la actualizacion de los precios de listas. Esto esta por si reactive un producto inactivo.
      '      Dim sqlPSP As SqlServer.ProductosSucursalesPrecios = New SqlServer.ProductosSucursalesPrecios(Me.da)
      '      sqlPSP.ProductosSucursalesPrecios_IFaltante(produ.IdProducto, actual.Nombre)

      '      'Por las dudas lanzo la actualizacion de los Lotes. Esto esta por si Califica de Lote uno con Stock.
      '      If produ.Lote Then
      '         Dim sqlPL As SqlServer.ProductosLotes = New SqlServer.ProductosLotes(Me.da)
      '         sqlPL.ProductosLotes_IFaltante(produ.IdProducto)
      '      End If

      '      'Graba Conceptos
      '      sql1.ProductosConceptos_D(produ.IdProducto)

      '      For Each dr As Entidades.ProductoConcepto In produ.Conceptos
      '         sql1.ProductosConceptos_I(dr.IdProducto, dr.IdConcepto)
      '      Next

      '      Dim PS As SqlServer.ProductosSucursales = New SqlServer.ProductosSucursales(Me.da)
      '      PS.ProductosSucursales_UEstadistica(actual.Sucursal.Id, produ.IdProducto, produ.PuntoDePedido, produ.StockMinimo, produ.StockMaximo, produ.Ubicacion)
      '      'If produ.Ubicacion <> "" Then
      '      '   PS.ProductosSucursales_Ubicacion(produ.IdProducto, actual.Sucursal.Id, produ.Ubicacion)
      '      'End If

      '      If produ.Proveedor IsNot Nothing AndAlso produ.ProductoProveedorHabitual IsNot Nothing Then
      '         Dim sqlPP As SqlServer.ProductosProveedores = New SqlServer.ProductosProveedores(Me.da)
      '         sqlPP.ProductosProveedores_D(idProveedor, produ.IdProducto)
      '         sqlPP.ProductosProveedores_I(idProveedor, produ.IdProducto, produ.ProductoProveedorHabitual.CodigoProductoProveedor,
      '                                      produ.ProductoProveedorHabitual.UltimoPrecioCompra,
      '                                      produ.ProductoProveedorHabitual.UltimaFechaCompra,
      '                                      produ.ProductoProveedorHabitual.UltimoPrecioFabrica,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc1,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc2,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc3,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc4,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc5,
      '                                      produ.ProductoProveedorHabitual.DescuentoRecargoPorc6)
      '      End If



      '      'Graba Auditoria
      '      dtAudit = sqlAudit.Auditorias_G1("Productos", "IdProducto = '" & produ.IdProducto & "'")

      '      'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
      '      If dtAudit.Rows.Count > 0 Then

      '         Select Case True
      '            Case Not produ.Activo And Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
      '               'Lo inactivo
      '               OperacAudit = SqlServer.Auditorias.Operaciones.Inactivar
      '            Case produ.Activo And Not Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
      '               'Lo activo
      '               OperacAudit = SqlServer.Auditorias.Operaciones.Alta
      '            Case Else
      '               OperacAudit = SqlServer.Auditorias.Operaciones.Modificacion
      '         End Select

      '      Else

      '         OperacAudit = SqlServer.Auditorias.Operaciones.Alta

      '      End If

      '      rAudit.Insertar("Productos", OperacAudit, actual.Nombre, "IdProducto = '" & produ.IdProducto & "'")



      '   Case TipoSP._D

      '      rAudit.Insertar("Productos", SqlServer.Auditorias.Operaciones.Baja, actual.Nombre, "IdProducto = '" & produ.IdProducto & "'")

      '      'Si Borro de la Central... borro todo. (Por perfiles de Seguridad solo deberia ser asi...)
      '      If actual.Sucursal.SoyLaCentral Then
      '         sql.Productos_D(produ.IdProducto, 0)
      '      Else
      '         sql.Productos_D(produ.IdProducto, actual.Sucursal.Id)
      '      End If

      'End Select

   End Sub

   Private Sub SelectFiltrado(ByRef stb As StringBuilder, ByVal incluirFoto As Boolean, ByVal espaciosID As Boolean, ByVal Base As String)

      Dim strAnchoIdProducto As String = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()

      With stb
         .Length = 0
         If espaciosID Then
            .AppendLine("SELECT RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto")
         Else
            .AppendLine("SELECT P.IdProducto")
         End If
         .AppendLine("      ,P.Caracteristica1")
         .AppendLine("      ,P.ValorCaracteristica1")
         .AppendLine("      ,P.Caracteristica2")
         .AppendLine("      ,P.ValorCaracteristica2")
         .AppendLine("      ,P.Caracteristica3")
         .AppendLine("      ,P.ValorCaracteristica3")

         .AppendLine(" FROM " & Base & "ProductosWeb P ")

      End With

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ProductoWeb, ByVal dr As DataRow)

      With o

         .IdProducto = dr("IdProducto").ToString()


         .Caracteristica1 = dr(Entidades.ProductoWeb.Columnas.Caracteristica1.ToString()).ToString()
         .ValorCaracteristica1 = dr(Entidades.ProductoWeb.Columnas.ValorCaracteristica1.ToString()).ToString()
         .Caracteristica2 = dr(Entidades.ProductoWeb.Columnas.Caracteristica2.ToString()).ToString()
         .ValorCaracteristica2 = dr(Entidades.ProductoWeb.Columnas.ValorCaracteristica2.ToString()).ToString()
         .Caracteristica3 = dr(Entidades.ProductoWeb.Columnas.Caracteristica3.ToString()).ToString()
         .ValorCaracteristica3 = dr(Entidades.ProductoWeb.Columnas.ValorCaracteristica3.ToString()).ToString()


      End With

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function Get1(idProducto As String, base As String) As DataTable
      Return New SqlServer.ProductosWeb(da).ProductosWeb_G1(idProducto, base)
   End Function

   'Public Function GetAll_Ids() As DataTable
   '   Return New SqlServer.Productos(da).Productos_GA_Ids()
   'End Function


   'Public Function GetPorCodigo(ByVal IdProducto As String, _
   '                              ByVal IdSucursal As Integer, _
   '                              ByVal idListaPrecios As Integer, _
   '                              ByVal Modulo As String, _
   '                              Optional ByVal SoloCompuestos As Boolean = False, _
   '                              Optional ByVal Modalidad As String = "NORMAL", _
   '                              Optional ByVal SoloAlquilables As Boolean = False) As DataTable

   '   Dim strAnchoIdProducto As String = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()
   '   Dim blnPreciosConIVA As Boolean = Reglas.Publicos.PreciosConIVA
   '   Dim srtCatFiscalEmp As Short = Reglas.Publicos.CategoriaFiscalEmpresa
   '   Dim redondeo As Integer = Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESREDONDEOENPRECIO.ToString(), "4").ToString())

   '   'Para compensar que algunas lectoras no leen el ultimo digito.
   '   If Publicos.Facturacion.FacturacionIgnorarUltimoDigitoCB And IdProducto.Length >= 10 And Reglas.Publicos.ProductoUtilizaCodigoDeBarras Then
   '      IdProducto = Strings.Left(IdProducto, IdProducto.Length - 1)
   '   End If

   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .Length = 0

   '      If Publicos.ProductoCodigoQuitarBlancos Then
   '         .AppendFormat("SELECT P.IdProducto as IdProducto,")
   '      Else
   '         .AppendFormat("SELECT RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto,", strAnchoIdProducto)
   '      End If

   '      .AppendLine("	P.NombreProducto,")
   '      .AppendLine("	P.NombreCorto,")
   '      .AppendLine("	P.Tamano,")
   '      .AppendLine("	P.IdUnidadDeMedida,")

   '      .AppendLine("   P.Alicuota, ")
   '      .AppendLine("   P.Alicuota2,")
   '      .AppendLine("   Mo.Simbolo,")

   '      .AppendLine("	PS.PrecioFabrica,")
   '      .AppendLine("	PS.PrecioCosto,")
   '      .AppendLine("	PSP.PrecioVenta,")

   '      If blnPreciosConIVA Then
   '         .AppendLine("	ROUND((PSP.PrecioVenta - P.ImporteImpuestoInterno) / (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaSinIVA,")
   '         .AppendLine("	PSP.PrecioVenta as PrecioVentaConIVA,")
   '      Else
   '         .AppendLine("	PSP.PrecioVenta as PrecioVentaSinIVA,")
   '         .AppendLine("	ROUND((PSP.PrecioVenta * (1+(P.Alicuota/100))) + P.ImporteImpuestoInterno, " & redondeo & ") as PrecioVentaConIVA,")
   '      End If

   '      .AppendLine("	PS.FechaActualizacion,")
   '      .AppendLine("	PS.Stock,")
   '      .AppendLine("	PS.StockInicial,")
   '      .AppendLine("	P.IdMarca,")
   '      .AppendLine("	P.IdModelo,")
   '      .AppendLine("	P.IdRubro,")
   '      .AppendLine("	P.IdSubRubro,")
   '      .AppendLine("	P.MesesGarantia,")
   '      .AppendLine("	P.IdTipoImpuesto,")
   '      .AppendLine("	P.AfectaStock,")
   '      .AppendLine("	P.PermiteModificarDescripcion,")
   '      .AppendLine("	P.CodigoDeBarras,")
   '      .AppendLine("	P.IdMoneda,")
   '      .AppendLine("	Mo.NombreMoneda,")
   '      .AppendLine("	Mo.FactorConversion,")
   '      .AppendLine("	P.EsServicio,")
   '      .AppendLine("	P.PublicarEnWeb,")
   '      .AppendLine("	P.Observacion")
   '      .AppendLine("	,P.EquipoMarca")
   '      .AppendLine("	,P.EquipoModelo")
   '      .AppendLine("	,P.NumeroSerie")
   '      .AppendLine("	,P.CaractSII")
   '      .AppendLine("	,P.Anio")
   '      .AppendLine("	,P.Kilos")
   '      .AppendLine("	,P.PublicarListaDePreciosClientes")
   '      .AppendLine("	,P.FacturacionCantidadNegativa")
   '      .AppendLine("	,P.SolicitaEnvase")
   '      .AppendLine("	,P.AlertaDeCaja")
   '      .AppendLine("	,P.DescontarStockComponentes")
   '      .AppendLine("	,P." + Entidades.Producto.Columnas.ModalidadCodigoDeBarras.ToString())
   '      .AppendLine("  ,P.CodigoLargoProducto")
   '      .AppendLine("  ,P.EsObservacion")
   '      .AppendLine("  ,P.PrecioPorEmbalaje")
   '      .AppendLine("  ,P.Embalaje")
   '      .AppendLine("  ,P.UnidHasta1")
   '      .AppendLine("  ,P.UHPorc1")
   '      .AppendLine("  ,P.UnidHasta2")
   '      .AppendLine("  ,P.UHPorc2")
   '      .AppendLine("  ,P.UnidHasta3")
   '      .AppendLine("  ,P.UHPorc3")
   '      .AppendLine("  ,P.UnidHasta4")
   '      .AppendLine("  ,P.UHPorc4")
   '      .AppendLine("  ,P.UnidHasta5")
   '      .AppendLine("  ,P.UHPorc5")
   '      .AppendLine("  ,P.PrecioPorEmbalaje")
   '      .AppendLine("      ,P.IdCuentaCompras")
   '      .AppendLine("      ,CCC.NombreCuenta AS NombreCuentaCompras")
   '      .AppendLine("      ,P.IdCuentaVentas")
   '      .AppendLine("      ,CCV.NombreCuenta AS NombreCuentaVentas")
   '      .AppendLine("  ,P.ImporteImpuestoInterno")
   '      .AppendLine("  ,M.NombreMarca")
   '      .AppendLine("  ,R.NombreRubro")
   '      .AppendLine("  ,P.EsOferta")
   '      .AppendLine("  ,P.IdCuentaComprasSecundaria")
   '      .AppendLine("  ,CCCS.NombreCuenta AS NombreCuentaComprasSecundaria")
   '      .AppendLine("  ,P.IncluirExpensas")
   '      .AppendLine("      ,P.IdCentroCosto")
   '      .AppendLine("      ,CECO.NombreCentroCosto")
   '      .AppendLine("  ,P.ObservacionCompras")
   '      .AppendLine("  ,P.SolicitaPrecioVentaPorTamano")
   '      .AppendLine("      ,P.Espmm")
   '      .AppendLine("      ,P.EspPulgadas")
   '      .AppendLine("      ,P.CodigoSAE")
   '      .AppendLine("      ,P.IdProduccionProceso")
   '      .AppendLine("      ,P.IdProduccionForma")
   '      .AppendLine("      ,PRP.NombreProduccionProceso")
   '      .AppendLine("      ,PRF.NombreProduccionForma")
   '      .AppendLine("      ,P.CalculaPreciosSegunFormula")
   '      .AppendLine("  FROM Productos P")
   '      .AppendLine("	LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
   '      .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")
   '      .AppendLine("   LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCC ON CCC.IdCuenta = P.IdCuentaCompras")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCV ON CCV.IdCuenta = P.IdCuentaVentas")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCCS ON CCCS.IdCuenta = P.IdCuentaComprasSecundaria")
   '      .AppendLine(" LEFT JOIN ContabilidadCentrosCostos CECO ON CECO.IdCentroCosto = P.IdCentroCosto")
   '      .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
   '      .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
   '      .AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = P.IdProduccionForma")
   '      .AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = P.IdProduccionProceso")

   '      '' ''If Boolean.Parse(New Reglas.Parametros().GetValor("PRODUCTOUTILIZACODIGODEBARRAS")) Then
   '      '' ''   .AppendFormat("	WHERE (P.IdProducto = '" & IdProducto & "' OR P.CodigoDeBarras = '" & IdProducto & "')")
   '      '' ''Else
   '      '' ''   .AppendFormat("	WHERE P.IdProducto = '{0}'", IdProducto)
   '      '' ''End If

   '      If String.IsNullOrWhiteSpace(IdProducto) Then
   '         .AppendFormat("	WHERE 1 = 1")
   '      Else
   '         .AppendFormat("	WHERE (P.IdProducto = '{0}'", IdProducto)

   '         If Publicos.ProductoUtilizaCodigoDeBarras Then
   '            .AppendFormat(" OR P.CodigoDeBarras = '{0}'", IdProducto)
   '         End If

   '         If Publicos.ProductoUtilizaCodigoLargoProducto Then
   '            .AppendFormat(" OR P.CodigoLargoProducto = '{0}'", IdProducto)
   '         End If

   '         .Append("	)")
   '      End If

   '      .AppendFormat("	AND PS.IdSucursal = {0}", IdSucursal)
   '      .AppendLine("	AND P.Activo = 'True'")   'Solo permito elegir los productos Activos

   '      .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)

   '      If Modulo <> "TODOS" Then
   '         .AppendLine("	AND P.EsDe" & Modulo & " = 'True'")   'De Ventas o Compras
   '      End If

   '      If SoloCompuestos Then
   '         .AppendLine("	AND P.EsCompuesto = 'True'")   'Tiene una formula asociada
   '      End If

   '      If Modalidad = "PESO" Then
   '         .AppendLine("	AND P.CodigoDeBarrasConPrecio = 'True'")
   '      End If

   '      If SoloAlquilables Then
   '         .AppendLine("	AND P.EsAlquilable = 'True'")
   '      End If

   '      .AppendLine("	ORDER BY P.NombreProducto")
   '   End With

   '   Dim dt As DataTable

   '   dt = Me.da.GetDataTable(stb.ToString())

   '   'Si lo encontro o es Modalidad Peso (precio en el etiqueta, no puedo buscar en general)
   '   If dt.Rows.Count > 0 Or Modalidad = "PESO" Then
   '      Return dt
   '   End If

   '   'Caso Contrario hago la busqueda con el LIKE en el CODIGO para que encuentre todos los posiles.

   '   With stb
   '      .Length = 0

   '      If Publicos.ProductoCodigoQuitarBlancos Then
   '         .AppendFormat("SELECT P.IdProducto as IdProducto,")
   '      Else
   '         .AppendFormat("SELECT RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto,", strAnchoIdProducto)
   '      End If

   '      .AppendLine("	P.NombreProducto,")
   '      .AppendLine("	P.NombreCorto,")
   '      .AppendLine("	P.Tamano,")
   '      .AppendLine("	P.IdUnidadDeMedida,")

   '      .AppendLine("   P.Alicuota, ")
   '      .AppendLine("   P.Alicuota2,")
   '      .AppendLine("   Mo.Simbolo,")

   '      .AppendLine("	PS.PrecioFabrica,")
   '      .AppendLine("	PS.PrecioCosto,")

   '      .AppendLine("	PSP.PrecioVenta,")

   '      If blnPreciosConIVA Then
   '         .AppendLine("	ROUND((PSP.PrecioVenta - P.ImporteImpuestoInterno) / (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaSinIVA,")
   '         .AppendLine("	PSP.PrecioVenta as PrecioVentaConIVA,")
   '      Else
   '         .AppendLine("	PSP.PrecioVenta as PrecioVentaSinIVA,")
   '         .AppendLine("	ROUND((PSP.PrecioVenta * (1+(P.Alicuota/100))) + P.ImporteImpuestoInterno, " & redondeo & ") as PrecioVentaConIVA,")
   '      End If
   '      .AppendLine("	PS.FechaActualizacion,")
   '      .AppendLine("	PS.Stock,")
   '      .AppendLine("	PS.StockInicial,")
   '      .AppendLine("	P.IdMarca,")
   '      .AppendLine("	P.IdModelo,")
   '      .AppendLine("	P.IdRubro,")
   '      .AppendLine("	P.IdSubRubro,")
   '      .AppendLine("	P.MesesGarantia,")
   '      .AppendLine("	P.IdTipoImpuesto,")
   '      .AppendLine("	P.AfectaStock,")
   '      .AppendLine("	P.PermiteModificarDescripcion,")
   '      .AppendLine("	P.CodigoDeBarras,")
   '      .AppendLine("	P.IdMoneda,")
   '      .AppendLine("	Mo.NombreMoneda,")
   '      .AppendLine("	Mo.FactorConversion,")
   '      .AppendLine("	P.EsServicio,")
   '      .AppendLine("	P.PublicarEnWeb,")
   '      .AppendLine("	P.Observacion")
   '      .AppendLine("	,P.EquipoMarca")
   '      .AppendLine("	,P.EquipoModelo")
   '      .AppendLine("	,P.NumeroSerie")
   '      .AppendLine("	,P.CaractSII")
   '      .AppendLine("	,P.Anio")
   '      .AppendLine("	,P.Kilos")
   '      .AppendLine("	,P.PublicarListaDePreciosClientes")
   '      .AppendLine("	,P.FacturacionCantidadNegativa")
   '      .AppendLine("	,P.SolicitaEnvase")
   '      .AppendLine("	,P.AlertaDeCaja")
   '      .AppendLine("	,P.DescontarStockComponentes")
   '      .AppendLine("	,P." + Entidades.Producto.Columnas.ModalidadCodigoDeBarras.ToString())
   '      .AppendLine("  ,P.CodigoLargoProducto")
   '      .AppendLine("  ,P.EsObservacion")
   '      .AppendLine("  ,P.PrecioPorEmbalaje")
   '      .AppendLine("  ,P.Embalaje")
   '      .AppendLine("  ,P.UnidHasta1")
   '      .AppendLine("  ,P.UHPorc1")
   '      .AppendLine("  ,P.UnidHasta2")
   '      .AppendLine("  ,P.UHPorc2")
   '      .AppendLine("  ,P.UnidHasta3")
   '      .AppendLine("  ,P.UHPorc3")
   '      .AppendLine("  ,P.UnidHasta4")
   '      .AppendLine("  ,P.UHPorc4")
   '      .AppendLine("  ,P.UnidHasta5")
   '      .AppendLine("  ,P.UHPorc5")
   '      .AppendLine("      ,P.IdCuentaCompras")
   '      .AppendLine("      ,CCC.NombreCuenta AS NombreCuentaCompras")
   '      .AppendLine("      ,P.IdCuentaVentas")
   '      .AppendLine("      ,CCV.NombreCuenta AS NombreCuentaVentas")
   '      .AppendLine("  ,P.ImporteImpuestoInterno")
   '      .AppendLine("  ,M.NombreMarca")
   '      .AppendLine("  ,R.NombreRubro")
   '      .AppendLine("  ,P.EsOferta")
   '      .AppendLine("  ,P.IdCuentaComprasSecundaria")
   '      .AppendLine("  ,CCCS.NombreCuenta AS NombreCuentaComprasSecundaria")
   '      .AppendLine("  ,P.IncluirExpensas")
   '      .AppendLine("      ,P.IdCentroCosto")
   '      .AppendLine("      ,CECO.NombreCentroCosto")
   '      .AppendLine("  ,P.ObservacionCompras")
   '      .AppendLine("  ,P.SolicitaPrecioVentaPorTamano")
   '      .AppendLine("      ,P.Espmm")
   '      .AppendLine("      ,P.EspPulgadas")
   '      .AppendLine("      ,P.CodigoSAE")
   '      .AppendLine("      ,P.IdProduccionProceso")
   '      .AppendLine("      ,P.IdProduccionForma")
   '      .AppendLine("      ,PRP.NombreProduccionProceso")
   '      .AppendLine("      ,PRF.NombreProduccionForma")
   '      .AppendLine("      ,P.CalculaPreciosSegunFormula")
   '      .AppendLine("  FROM Productos P")
   '      .AppendLine("	LEFT JOIN Monedas Mo ON P.IdMoneda = Mo.IdMoneda")
   '      .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")
   '      .AppendLine("   LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCC ON CCC.IdCuenta = P.IdCuentaCompras")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCV ON CCV.IdCuenta = P.IdCuentaVentas")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCCS ON CCCS.IdCuenta = P.IdCuentaComprasSecundaria")
   '      .AppendLine(" LEFT JOIN ContabilidadCentrosCostos CECO ON CECO.IdCentroCosto = P.IdCentroCosto")
   '      .AppendLine(" LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
   '      .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
   '      .AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = P.IdProduccionForma")
   '      .AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = P.IdProduccionProceso")

   '      .AppendFormat("	WHERE (P.IdProducto LIKE '%{0}%'", IdProducto)

   '      If Publicos.ProductoUtilizaCodigoDeBarras Then
   '         .AppendFormat(" OR P.CodigoDeBarras LIKE '%{0}%'", IdProducto)
   '      End If

   '      If Publicos.ProductoUtilizaCodigoLargoProducto Then
   '         .AppendFormat(" OR P.CodigoLargoProducto LIKE '%{0}%'", IdProducto)
   '      End If

   '      .Append("	)")

   '      .AppendFormat("	AND PS.IdSucursal = {0}", IdSucursal)
   '      .AppendLine("	AND P.Activo = 1")   'Solo permito elegir los productos Activos

   '      .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)

   '      If Modulo <> "TODOS" Then
   '         .AppendLine("	AND P.EsDe" & Modulo & " = 'True'")   'De Ventas o Compras
   '      End If

   '      If SoloCompuestos Then
   '         .AppendLine("	AND P.EsCompuesto = 'True'")   'Tiene una formula asociada
   '      End If

   '      If Modalidad = "PESO" Then
   '         .AppendLine("	AND P.CodigoDeBarrasConPrecio = 'True'")
   '      End If

   '      If SoloAlquilables Then
   '         .AppendLine("	AND P.EsAlquilable = 'True'")
   '      End If

   '      .AppendLine("	ORDER BY P.NombreProducto")
   '   End With

   '   Return Me.da.GetDataTable(stb.ToString())

   'End Function

   'Public Function GetPorCodigoTodos(ByVal codigo As String, ByVal sucursal As Integer, ByVal idListaPrecios As Integer) As DataTable

   '   Dim strAnchoIdProducto As String = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto").ToString()
   '   Dim blnPreciosConIVA As Boolean = Reglas.Publicos.PreciosConIVA
   '   Dim srtCatFiscalEmp As Short = Reglas.Publicos.CategoriaFiscalEmpresa
   '   Dim redondeo As Integer = Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONDECIMALESREDONDEOENPRECIO.ToString(), "4").ToString())

   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb

   '      If Publicos.ProductoCodigoQuitarBlancos Then
   '         .AppendFormat("SELECT P.IdProducto as IdProducto,")
   '      Else
   '         .AppendFormat("SELECT RIGHT(REPLICATE(' ',{0}) + P.IdProducto,{0}) as IdProducto,", strAnchoIdProducto)
   '      End If

   '      .AppendLine("	P.NombreProducto,")
   '      .AppendLine("	P.NombreCorto,")
   '      .AppendLine("	P.Tamano,")
   '      .AppendLine("	P.IdUnidadDeMedida,")
   '      .AppendLine("	PS.PrecioFabrica,")
   '      .AppendLine("	PS.PrecioCosto,")

   '      .AppendLine("	PSP.PrecioVenta,")

   '      If blnPreciosConIVA Then
   '         .AppendLine("	ROUND((PSP.PrecioVenta - P.ImporteImpuestoInterno) / (1+(P.Alicuota/100)), " & redondeo & ") as PrecioVentaSinIVA,")
   '         .AppendLine("	PSP.PrecioVenta as PrecioVentaConIVA,")
   '      Else
   '         .AppendLine("	PSP.PrecioVenta as PrecioVentaSinIVA,")
   '         .AppendLine("	ROUND((PSP.PrecioVenta * (1+(P.Alicuota/100))) + P.ImporteImpuestoInterno, " & redondeo & ") as PrecioVentaConIVA,")
   '      End If
   '      .AppendLine(" P.Alicuota2,")
   '      .AppendLine("	PS.Stock,")
   '      .AppendLine("	PS.StockInicial,")
   '      .AppendLine("	P.IdMarca,")
   '      .AppendLine("	P.IdModelo,")
   '      .AppendLine("	P.IdRubro,")
   '      .AppendLine("	P.IdSubRubro,")
   '      .AppendLine("	P.MesesGarantia,")
   '      .AppendLine("	P.IdTipoImpuesto,")
   '      .AppendLine("	P.AfectaStock,")
   '      .AppendLine("	P.CodigoDeBarras,")
   '      .AppendLine("	P.EsServicio,")
   '      .AppendLine("	P.PublicarEnWeb,")
   '      .AppendLine("	P.Observacion")
   '      .AppendLine("	,P.EquipoMarca")
   '      .AppendLine("	,P.EquipoModelo")
   '      .AppendLine("	,P.NumeroSerie")
   '      .AppendLine("	,P.CaractSII")
   '      .AppendLine("	,P.Anio")
   '      .AppendLine("	,P.Kilos")
   '      .AppendLine("	,P.PublicarListaDePreciosClientes")
   '      .AppendLine("	,P.FacturacionCantidadNegativa")
   '      .AppendLine("	,P.SolicitaEnvase")
   '      .AppendLine("	,P.AlertaDeCaja")
   '      .AppendLine("  ,P.EsObservacion")
   '      .AppendLine("  ,P.IdCuentaCompras")
   '      .AppendLine("  ,CCC.NombreCuenta AS NombreCuentaCompras")
   '      .AppendLine("  ,P.IdCuentaVentas")
   '      .AppendLine("  ,CCV.NombreCuenta AS NombreCuentaVentas")
   '      .AppendLine("  ,P.ImporteImpuestoInterno")
   '      .AppendLine("  ,P.EsOferta")
   '      .AppendLine("  ,P.IdCuentaComprasSecundaria")
   '      .AppendLine("  ,CCCS.NombreCuenta AS NombreCuentaComprasSecundaria")
   '      .AppendLine("  ,P.IncluirExpensas")
   '      .AppendLine("      ,P.IdCentroCosto")
   '      .AppendLine("      ,CECO.NombreCentroCosto")
   '      .AppendLine("  ,P.ObservacionCompras")
   '      .AppendLine("  ,P.SolicitaPrecioVentaPorTamano")
   '      .AppendLine("      ,P.Espmm")
   '      .AppendLine("      ,P.EspPulgadas")
   '      .AppendLine("      ,P.CodigoSAE")
   '      .AppendLine("      ,P.IdProduccionProceso")
   '      .AppendLine("      ,P.IdProduccionForma")
   '      .AppendLine("      ,PRP.NombreProduccionProceso")
   '      .AppendLine("      ,PRF.NombreProduccionForma")
   '      .AppendLine("      ,P.CalculaPreciosSegunFormula")
   '      .AppendLine("  FROM Productos P")
   '      .AppendLine("	LEFT JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto")
   '      .AppendLine("   LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCC ON CCC.IdCuenta = P.IdCuentaCompras")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCV ON CCV.IdCuenta = P.IdCuentaVentas")
   '      .AppendLine(" LEFT JOIN ContabilidadCuentas CCCS ON CCCS.IdCuenta = P.IdCuentaComprasSecundaria")
   '      .AppendLine(" LEFT JOIN ContabilidadCentrosCostos CECO ON CECO.IdCentroCosto = P.IdCentroCosto")
   '      .AppendLine(" LEFT JOIN ProduccionFormas PRF ON PRF.IdProduccionForma = P.IdProduccionForma")
   '      .AppendLine(" LEFT JOIN ProduccionProcesos PRP ON PRP.IdProduccionProceso = P.IdProduccionProceso")

   '      '.AppendFormat("	WHERE P.IdProducto LIKE '%{0}%'", codigo)
   '      .AppendFormat("	WHERE P.IdProducto = '{0}'", codigo)
   '      .AppendFormat("	  AND PS.IdSucursal = {0}", sucursal)
   '      '.AppendLine("	AND P.Activo = 1")   'Solo permito elegir los productos Activos
   '      .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)
   '      .AppendLine("	ORDER BY P.NombreProducto")
   '   End With

   '   Return Me.da.GetDataTable(stb.ToString())

   'End Function

   Public Function GetUno(idProducto As String, incluirFoto As Boolean) As Entidades.ProductoWeb
      Dim o As Entidades.ProductoWeb
      'Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         'If blnAbreConexion Then da.OpenConection()
         Dim stb As StringBuilder = New StringBuilder("")
         Dim dt As DataTable = New DataTable()

         'Pasa como parametros. Se dio vuelta para que no lo cargue. Solo se usa en ABM de Productos y en FacturacionRapida
         'Dim incluirFoto As Boolean = True
         Dim espaciosID As Boolean = False
         Dim base As String = Publicos.NombreBaseProductosWeb

         Me.SelectFiltrado(stb, incluirFoto, espaciosID, base)

         With stb
            .AppendLine("  WHERE P.IdProducto ='" & idProducto & "'")
         End With

         dt = Me.da.GetDataTable(stb.ToString())

         o = New Entidades.ProductoWeb()

         If dt.Rows.Count > 0 Then
            Me.CargarUno(o, dt.Rows(0))
         Else
            'Throw New Exception("No existe el Producto.")
            o = Nothing
         End If
      Finally
         ' If blnAbreConexion Then da.CloseConection()
      End Try
      Return o

   End Function

   Private Function GetSinCaracteresRaros(texto As String) As String
      texto = texto.Replace("/", "__")
      texto = texto.Replace("\", "__")
      texto = texto.Replace("*", "__")
      texto = texto.Replace(":", "__")
      texto = texto.Replace("<", "__")
      texto = texto.Replace(">", "__")
      texto = texto.Replace("?", "__")

      Return texto
   End Function

   Public Sub CrearProductosWeb(dtProductos As DataTable, ByRef prodWeb As Reglas.ProductosWebArchivo, carpetaImagenes As String)
      Try
         Dim linea As Reglas.ProductosWebLinea

         'eliminar todas las imagenes ---------
         If Not String.IsNullOrEmpty(carpetaImagenes) Then
            If System.IO.Directory.Exists(carpetaImagenes) Then
               For Each archi As String In System.IO.Directory.GetFiles(carpetaImagenes)
                  System.IO.File.Delete(archi)
               Next
            Else
               System.IO.Directory.CreateDirectory(carpetaImagenes)
            End If
         End If
         '-------------------------------------

         For Each dr As DataRow In dtProductos.Rows
            If Boolean.Parse(dr("Check").ToString()) Then

               linea = prodWeb.GetLinea()

               linea.IdProducto = dr("IdProducto").ToString()

               linea.IdproductoNumerico = If(Not String.IsNullOrWhiteSpace(dr("IdProductoNumerico").ToString()), Long.Parse(dr("IdProductoNumerico").ToString()), Nothing)

               linea.NombreProducto = dr("NombreProducto").ToString()
               '-.PE-31924.-
               linea.NombreProductoWeb = dr("NombreProductoWeb").ToString()

               linea.NombreCorto = dr("NombreCorto").ToString()
               linea.IdMarca = Integer.Parse(dr("IdMarca").ToString())
               linea.NombreMarca = dr("NombreMarca").ToString()

               linea.IdRubro = Integer.Parse(dr("IdRubro").ToString())
               linea.NombreRubro = dr("NombreRubro").ToString()

               linea.IdSubRubro = Integer.Parse(dr("IdSubRubro").ToString())
               linea.NombreSubRubro = dr("NombreSubRubro").ToString()

               If Not String.IsNullOrEmpty(dr("IdSubSubRubro").ToString()) Then
                  linea.IdSubSubRubro = Integer.Parse(dr("IdSubSubRubro").ToString())
                  linea.NombreSubSubRubro = dr("NombreSubSubRubro").ToString()
               End If

               linea.Alicuota = Decimal.Parse(dr("Alicuota").ToString())

               linea.PrecioCosto = Decimal.Parse(dr("PrecioCosto").ToString())

               linea.PrecioVenta = Decimal.Parse(dr("PrecioVenta").ToString())

               linea.PrecioMayorista = Decimal.Parse(dr("PrecioMayorista").ToString()) '-.PE-32135.-

               If dr("NombreMoneda").ToString() = "Pesos" Then
                  linea.Moneda = "ARS"
               Else
                  linea.Moneda = "USS"
               End If

               linea.CodigoDeBarras = dr("CodigoDeBarras").ToString()

               linea.CodigoLargoProducto = dr("CodigoLargoProducto").ToString()

               If Not String.IsNullOrEmpty(dr("IdUnidadDeMedida").ToString()) Then
                  linea.UnidadDeMedida = New Reglas.UnidadesDeMedidas().GetUno(dr("IdUnidadDeMedida").ToString())
               Else
                  linea.UnidadDeMedida.IdUnidadDeMedida = "UN"
               End If

               linea.Observacion = dr("Observacion").ToString()

               If Not String.IsNullOrEmpty(dr("Foto").ToString()) Then
                  linea.NombreArchivoFoto = Me.GetSinCaracteresRaros(dr("IdProducto").ToString()) + "_1.png"
               End If

               If Not String.IsNullOrEmpty(dr("Foto2").ToString()) Then
                  linea.NombreArchivoFoto2 = Me.GetSinCaracteresRaros(dr("IdProducto").ToString()) + "_2.png"
               End If

               If Not String.IsNullOrEmpty(dr("Foto3").ToString()) Then
                  linea.NombreArchivoFoto3 = Me.GetSinCaracteresRaros(dr("IdProducto").ToString()) + "_3.png"
               End If

               linea.Stock = CInt(dr("Stock"))

               linea.Caracteristica1 = dr("Caracteristica1").ToString()
               linea.Caracteristica2 = dr("Caracteristica2").ToString()
               linea.Caracteristica3 = dr("Caracteristica3").ToString()

               linea.ValorCaracteristica1 = dr("ValorCaracteristica1").ToString()
               linea.ValorCaracteristica2 = dr("ValorCaracteristica2").ToString()
               linea.ValorCaracteristica3 = dr("ValorCaracteristica3").ToString()

               If Not String.IsNullOrEmpty(dr("ModalidadCodigoDeBarras").ToString()) Then
                  linea.ModalidadCodigoDeBarras = dr("ModalidadCodigoDeBarras").ToString()
               End If


               If Not String.IsNullOrEmpty(dr("Foto").ToString()) Then
                  Dim content() As Byte = CType(dr("Foto"), Byte())
                  My.Computer.FileSystem.WriteAllBytes(carpetaImagenes + linea.NombreArchivoFoto, content, False)
               End If

               If Not String.IsNullOrEmpty(dr("Foto2").ToString()) Then
                  Dim content() As Byte = CType(dr("Foto2"), Byte())
                  My.Computer.FileSystem.WriteAllBytes(carpetaImagenes + linea.NombreArchivoFoto2, content, False)
               End If

               If Not String.IsNullOrEmpty(dr("Foto3").ToString()) Then
                  Dim content() As Byte = CType(dr("Foto3"), Byte())
                  My.Computer.FileSystem.WriteAllBytes(carpetaImagenes + linea.NombreArchivoFoto3, content, False)
               End If

               Decimal.TryParse(dr("Kilos").ToString(), linea.Kilos)
               Decimal.TryParse(dr("Alto").ToString(), linea.Alto)
               Decimal.TryParse(dr("Ancho").ToString(), linea.Ancho)
               Decimal.TryParse(dr("Largo").ToString(), linea.Largo)
               Boolean.TryParse(dr("EsParaConstructora").ToString(), linea.EsParaConstructora)
               Boolean.TryParse(dr("EsParaIndustria").ToString(), linea.EsParaIndustria)
               Boolean.TryParse(dr("EsParaCooperativaElectrica").ToString(), linea.EsParaCooperativaElectrica)
               Boolean.TryParse(dr("EsParaMayorista").ToString(), linea.EsParaMayorista)
               Boolean.TryParse(dr("EsParaMinorista").ToString(), linea.EsParaMinorista)

               Dim IdProductoMercosur As String = dr("IdProductoMercosur").ToString()

               linea.IdProductoMercosur = If(Not String.IsNullOrWhiteSpace(dr("IdProductoMercosur").ToString()), IdProductoMercosur.Truncar(6), Nothing)

               prodWeb.Lineas.Add(linea)

            End If

         Next

      Catch ex As Exception
         Throw
      End Try


   End Sub

   Public Event BeforeUploadBegins(sender As Object, e As BeginUploadEventArgs)
   Public Event AfterUploadEnds(sender As Object, e As EventArgs)

   Public Event FileUploadBeginning(sender As Object, e As FileUploadEventArgs)
   Public Event FileUploadFinished(sender As Object, e As FileUploadEventArgs)

   ''' <summary>
   ''' Sube archivos a un FTP
   ''' </summary>
   ''' <param name="servidorFTP"></param>
   ''' <param name="usuarioFTP"></param>
   ''' <param name="claveFTP"></param>
   ''' <param name="nuevoArchivo"></param>
   ''' <param name="conexionPasivaFTP"></param>
   ''' <param name="carpetaRemotaFTP"></param>
   ''' <param name="archivoDestino"></param>
   ''' <param name="carpetaImagenes"></param>
   ''' <returns>La Cantidad de archivos que se subieron al FTP, si es 0 no se subio nada.</returns>
   ''' <remarks></remarks>
   Public Function SubirArchivosALaWeb(servidorFTP As String,
                                       usuarioFTP As String,
                                       claveFTP As String,
                                       nuevoArchivo As String,
                                       conexionPasivaFTP As Boolean,
                                       carpetaRemotaFTP As String,
                                       archivoDestino As String,
                                       carpetaImagenes As String) As Integer
      Try
         Dim ftp As Reglas.IFtp
         Dim iM As Integer = 0

         If String.IsNullOrEmpty(servidorFTP) Or String.IsNullOrEmpty(usuarioFTP) Or String.IsNullOrEmpty(claveFTP) Then
            Return iM
         End If

         ftp = New Reglas.SimpleFtp(servidorFTP, usuarioFTP, claveFTP)
         ftp.UsePassive = conexionPasivaFTP

         Dim Archivo As String = System.IO.Path.GetFileName(archivoDestino)

         If IO.File.Exists(archivoDestino) Then

            IO.File.Copy(archivoDestino, IO.Path.Combine(carpetaImagenes, nuevoArchivo), True)

            iM = 1

            Dim files As IO.FileInfo() = New IO.DirectoryInfo(carpetaImagenes).GetFiles()
            Dim cantidadArchivos As Long = files.LongCount
            Dim tamanioTotal As Long = files.Sum(Function(x) x.Length)

            RaiseEvent BeforeUploadBegins(Me, New BeginUploadEventArgs() With {.CantidadArchivos = cantidadArchivos, .TamanioTotal = tamanioTotal})
            'subo todas las imagenes al FTP
            For Each fi As IO.FileInfo In files
               RaiseEvent FileUploadBeginning(Me, New FileUploadEventArgs(fi.Name) With {.Tamanio = fi.Length})
               ftp.Upload(fi.DirectoryName, fi.Name, carpetaRemotaFTP)
               fi.Delete()
               iM += 1
               RaiseEvent FileUploadFinished(Me, New FileUploadEventArgs(fi.Name) With {.Tamanio = fi.Length, .SubidoExitosamente = True})
            Next
            RaiseEvent AfterUploadEnds(Me, Nothing)

         End If

         'retorno la cantidad de archivos que se subieron al FTP
         Return iM

      Catch ex As Exception
         Throw
      End Try
   End Function

#End Region

   Private Sub EjecutaSP(produ As Entidades.Producto, tipoSP As TipoSP)
      Throw New NotImplementedException
   End Sub

   Public Sub MarcarProductosSubidos(drColProductos As DataRow())
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlP As SqlServer.Productos = New SqlServer.Productos(da)

         Dim fechaExportacionWeb As DateTime = Now
         For Each dr As DataRow In drColProductos
            sqlP.Productos_U_FechaExportacionWeb(dr("IdProducto").ToString(), fechaExportacionWeb)
         Next

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

End Class