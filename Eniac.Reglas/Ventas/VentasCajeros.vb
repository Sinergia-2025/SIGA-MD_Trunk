Public Class VentasCajeros
   Inherits Base

   Private _cache As BusquedasCacheadas

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "VentasCajeros"
      da = accesoDatos
      _cache = New BusquedasCacheadas()
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.VentaCajero)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.VentaCajero)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.VentaCajero)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.VentasCajeros = New SqlServer.VentasCajeros(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.VentasCajeros(Me.da).VentasCajeros_GA(actual.Sucursal.Id)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.VentaCajero, tipo As TipoSP)
      Dim sqlC = New SqlServer.VentasCajeros(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.VentasCajeros_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                 en.IdCliente, en.CodigoCliente, en.NombreCliente,
                                 en.IdVendedor, en.NombreVendedor, en.Fecha,
                                 en.IdFormasPago, en.DescripcionFormasPago, en.ImporteTotal, en.DescuentoRecargoPorc,
                                 en.IdCategoria, en.IdCategoriaFiscal, en.NombreCategoriaFiscal)
         Case TipoSP._U
            sqlC.VentasCajeros_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                 en.IdCliente, en.CodigoCliente, en.NombreCliente,
                                 en.IdVendedor, en.NombreVendedor, en.Fecha,
                                 en.IdFormasPago, en.DescripcionFormasPago, en.ImporteTotal, en.DescuentoRecargoPorc,
                                 en.IdCategoria, en.IdCategoriaFiscal, en.NombreCategoriaFiscal)
         Case TipoSP._D
            sqlC.VentasCajeros_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.VentaCajero, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.VentaCajero.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.VentaCajero.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Integer.Parse(dr(Entidades.VentaCajero.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroComprobante = Long.Parse(dr(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString()).ToString())
         .IdCliente = Long.Parse(dr(Entidades.VentaCajero.Columnas.IdCliente.ToString()).ToString())
         .CodigoCliente = Long.Parse(dr(Entidades.VentaCajero.Columnas.CodigoCliente.ToString()).ToString())
         .NombreCliente = dr(Entidades.VentaCajero.Columnas.NombreCliente.ToString()).ToString()
         .IdVendedor = Integer.Parse(dr(Entidades.VentaCajero.Columnas.IdVendedor.ToString()).ToString())
         .NombreVendedor = dr(Entidades.VentaCajero.Columnas.NombreVendedor.ToString()).ToString()
         .Fecha = DateTime.Parse(dr(Entidades.VentaCajero.Columnas.Fecha.ToString()).ToString())
         .IdFormasPago = Integer.Parse(dr(Entidades.VentaCajero.Columnas.IdFormasPago.ToString()).ToString())
         .DescripcionFormasPago = dr(Entidades.VentaCajero.Columnas.DescripcionFormasPago.ToString()).ToString()
         .ImporteTotal = Decimal.Parse(dr(Entidades.VentaCajero.Columnas.ImporteTotal.ToString()).ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr(Entidades.VentaCajero.Columnas.DescuentoRecargoPorc.ToString()).ToString())
         .IdCategoria = Integer.Parse(dr(Entidades.VentaCajero.Columnas.IdCategoria.ToString()).ToString())
         .IdCategoriaFiscal = Short.Parse(dr(Entidades.VentaCajero.Columnas.IdCategoriaFiscal.ToString()).ToString())
         .NombreCategoriaFiscal = dr(Entidades.VentaCajero.Columnas.NombreCategoriaFiscal.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.VentaCajero)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.VentaCajero)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.VentaCajero)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Sub Borrar(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      EjecutaConTransaccion(Sub() _Borrar(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
   End Sub
   Public Sub _Borrar(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      _Borrar(New Entidades.VentaCajero() With {.IdSucursal = idSucursal,
                                                .IdTipoComprobante = idTipoComprobante,
                                                .Letra = letra,
                                                .CentroEmisor = centroEmisor,
                                                .NumeroComprobante = numeroComprobante})
   End Sub

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Entidades.VentaCajero
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          accion As AccionesSiNoExisteRegistro) As Entidades.VentaCajero
      Return CargaEntidad(New SqlServer.VentasCajeros(Me.da).VentasCajeros_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.VentaCajero(),
                          accion, Function() String.Format("No existe Ventas Cajero con {0} {1} {2} {3:0000} {4:00000000}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
   End Function

   Public Function GetTodos() As List(Of Entidades.VentaCajero)
      Return CargaLista(Me.GetAll(), Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.VentaCajero())
   End Function

   Public Sub CobroRapido(ventaCajero As Entidades.VentaCajero, fecha As Date, tipoComprobante As Entidades.TipoComprobante, idCaja As Integer,
                          MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      Dim venta As Entidades.Venta
      Try
         Dim redondeoEnCalculo = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         Dim _categoriaFiscalEmpresa = New Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)

         da.OpenConection()

         Dim rVentas As Ventas = New Ventas(da)
         Dim presup As Entidades.Venta = rVentas.GetUna(ventaCajero.IdSucursal, ventaCajero.IdTipoComprobante, ventaCajero.Letra, CShort(ventaCajero.CentroEmisor), ventaCajero.NumeroComprobante)

         venta = rVentas.CreaVenta(actual.Sucursal.Id, tipoComprobante, "", 0, Nothing, presup.Cliente, Nothing, fecha, presup.Vendedor, Nothing,
                                   presup.FormaPago, presup.DescuentoRecargoPorc, idCaja, Nothing, True,
                                   Nothing, Nothing, Nothing, String.Empty, Nothing, Nothing, nroOrdenCompra:=0)

         For Each vp As Entidades.VentaProducto In presup.VentasProductos

            Dim precio As Decimal = vp.Precio
            If Not venta.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
               precio = Decimal.Round(precio * (1 + vp.AlicuotaImpuesto / 100), redondeoEnCalculo)
            End If

            rVentas.AgregarVentaProducto(venta,
                                         rVentas.CreaVentaProducto(vp.Producto,
                                                                   vp.Producto.NombreProducto,
                                                                   vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2,
                                                                   precio, vp.Cantidad, vp.TipoImpuesto,
                                                                   vp.AlicuotaImpuesto,
                                                                   _cache.BuscaListaDePrecios(vp.IdListaPrecios), vp.FechaEntrega,
                                                                   vp.TipoOperacion, vp.Nota, Nothing,
                                                                   venta, redondeoEnCalculo),
                                         redondeoEnCalculo)
         Next

         For Each Contacto As Entidades.VentaClienteContacto In presup.VentasContactos
            rVentas.AgregarVentaContactos(venta, Contacto.Contacto)
         Next

         rVentas.AgregarInvocado(venta, presup)
      Finally
         da.CloseConection()
      End Try

      Dim rVentas2 As Ventas = New Ventas()
      rVentas2.Insertar(venta, MetodoGrabacion, IdFuncion)

   End Sub

#End Region
End Class