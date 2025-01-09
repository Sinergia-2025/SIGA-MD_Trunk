Option Strict On
Option Explicit On
Imports System.IO

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Entidades

Public Class PreVenta
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "PreVenta"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Inserta(entidad)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.PreVenta = New SqlServer.PreVenta(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.PreVenta(Me.da).PreVenta_GA()
   End Function

   '' ''Public Function GetEstadoVisita(ByVal idestado As String) As DataTable
   '' ''   Return New SqlServer.PreVenta(Me.da).GetEstadoVisita(idestado)
   '' ''End Function

   '' ''Public Function GetEstadoVisita(ByVal idestado As Integer) As Eniac.Entidades.EstadoVisita
   '' ''   Return New Eniac.Reglas.EstadosVisitas(da).GetUno(idestado)
   '' ''End Function
#End Region

#Region "Metodos Privados"
   Public Sub Inserta(ByVal entidad As Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Inserta(fileNamePed As String, IdVendedor As Integer)
      Dim oArchivo As Entidades.PreVenta = New Entidades.PreVenta()

      oArchivo.IdPreVenta = GetProximoId()
      oArchivo.IdSucursal = actual.Sucursal.Id
      oArchivo.FileNamePed = fileNamePed
      oArchivo.Usuario = actual.Nombre
      oArchivo.Vendedor = New Eniac.Reglas.Empleados().GetUno(IdVendedor)
      oArchivo.Fecha = Now
      Inserta(oArchivo)
   End Sub

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.PreVenta = DirectCast(entidad, Entidades.PreVenta)

      Dim sql As SqlServer.PreVenta = New SqlServer.PreVenta(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.PreVenta_I(en.IdPreVenta, en.FileNamePed, en.Vendedor.IdEmpleado, en.Fecha)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.PreVenta, ByVal dr As DataRow)
      With o
         .IdPreVenta = Integer.Parse(dr(Entidades.PreVenta.Columnas.Id.ToString()).ToString())
         .Vendedor = New Eniac.Reglas.Empleados().GetUno(Integer.Parse(dr(Entidades.PreVenta.Columnas.IdEmpleado.ToString()).ToString()))
         .FileNamePed = Integer.Parse(dr(Entidades.PreVenta.Columnas.FileNamePed.ToString()).ToString()).ToString()
         .Fecha = Date.Parse(dr(Entidades.PreVenta.Columnas.Fecha.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   '' ''Public Sub GrabarPreVentaFile(ByVal dt As DataTable, ByVal idRuta As Integer)
   '' ''   Try
   '' ''      da.OpenConection()
   '' ''      da.BeginTransaction()

   '' ''      'como todos los campos son Clave primaria, tengo que eliminar todos los registros de la ruta e insertarlos nuevamente

   '' ''      Dim sql As SqlServer.PreVenta = New SqlServer.PreVenta(Me.da)

   '' ''      For Each dr As DataRow In dt.Rows
   '' ''         Me.EjecutaSP(Me.GetUnPreVenta(dr), TipoSP._I)
   '' ''      Next

   '' ''      da.CommitTransaction()

   '' ''   Catch ex As Exception
   '' ''      da.RollbakTransaction()
   '' ''      Throw ex
   '' ''   Finally
   '' ''      da.CloseConection()
   '' ''   End Try
   '' ''End Sub

   '' ''Private Function GetUnPreVenta(ByVal dr As DataRow) As Entidades.PreVenta
   '' ''   Dim rc As Entidades.PreVenta = New Entidades.PreVenta()
   '' ''   rc.Vendedor = New Eniac.Reglas.Empleados().GetUno(dr("TipoDocCliente").ToString(), dr("NroDocCliente").ToString())
   '' ''   rc.IdPreVenta = Int32.Parse(dr("IdPreVenta").ToString())
   '' ''   rc.FileNamePed = Int32.Parse(dr("FileNamePed").ToString()).ToString()
   '' ''   rc.Fecha = Date.Parse(dr("fecha").ToString())
   '' ''   Return rc
   '' ''End Function

   Public Function GetArchivo(ByVal fileName As String) As Boolean
      If New SqlServer.PreVenta(Me.da).GetArchivo(fileName).Rows.Count > 0 Then
         Throw New Exception(String.Format("El archivo '{0}' ya existe en el sistema", fileName))
      Else
         Return True
      End If
   End Function

   Public Function GetProximoId() As Integer
      Return New SqlServer.PreVenta(Me.da).GetProximoId
   End Function

   Public Function PermiteSeleccionarRutasPedidosPendientes() As Boolean
      Dim servRest As ServiciosRest.Pedidos.BasePedidosWeb = NewBasePedidosWeb()
      Return servRest.PermiteSeleccionarRutasPedidosPendientes()
   End Function

#End Region

   '' ''Public Function GetArticulosDeArchivo(ByVal argPreVenta As List(Of Entidades.ArgPreVenta)) As List(Of Eniac.Entidades.VentaProducto)


   '' ''   Dim lvp As List(Of Eniac.Entidades.VentaProducto)
   '' ''   Dim vp As Eniac.Entidades.VentaProducto
   '' ''   Dim ocli As Reglas.Clientes
   '' ''   Dim cliente As Entidades.Cliente
   '' ''   Dim oProductos As Eniac.Reglas.Productos
   '' ''   Dim producto As Eniac.Entidades.Producto
   '' ''   Dim oProductosSuc As Eniac.Reglas.ProductosSucursales
   '' ''   Dim prodSuc As Eniac.Entidades.ProductoSucursal
   '' ''   Dim Kilos As Decimal = 0
   '' ''   Dim KilosProd As Decimal = 0

   '' ''   Dim importeBruto As Decimal = 0
   '' ''   Dim importeNeto As Decimal = 0
   '' ''   Dim importeIva As Decimal = 0
   '' ''   Dim importeTotal As Decimal = 0

   '' ''   Dim precioCosto As Decimal = 0
   '' ''   Dim precioLista As Decimal = 0
   '' ''   Dim alicuotaIVA As Decimal = 0
   '' ''   Dim alicuotaIVASobre100 As Decimal = 0

   '' ''   Dim IdMoneda As Integer = 0

   '' ''   Dim PrecioVentaSinIVA As Decimal = 0
   '' ''   Dim PrecioVentaConIVA As Decimal = 0
   '' ''   Dim precioProducto As Decimal = 0

   '' ''   Dim importeBrutoProducto As Decimal = 0
   '' ''   Dim importeNetoProducto As Decimal = 0
   '' ''   Dim importeIvaProducto As Decimal = 0

   '' ''   Dim descRecPorGeneral As Decimal = 0

   '' ''   Dim precioNeto As Decimal = 0

   '' ''   Dim entro As Boolean

   '' ''   Try
   '' ''      da.OpenConection()

   '' ''      ocli = New Reglas.Clientes(Me.da)
   '' ''      oProductos = New Eniac.Reglas.Productos(Me.da)
   '' ''      oProductosSuc = New Eniac.Reglas.ProductosSucursales(Me.da)

   '' ''      lvp = New List(Of Eniac.Entidades.VentaProducto)()

   '' ''      For Each apv As Entidades.ArgPreVenta In argPreVenta
   '' ''         vp = New Eniac.Entidades.VentaProducto()

   '' ''         cliente = ocli._GetUno(apv.IdCliente)

   '' ''         If oProductos.Existe(apv.IdProducto) Then
   '' ''            producto = oProductos.GetUno(apv.IdProducto)
   '' ''            prodSuc = oProductosSuc._GetUno(apv.IdSucursal, apv.IdProducto)
   '' ''            'Dim precioVentaPredeterminado As Decimal = oProductosSuc.GetPrecioVentaPredeterminado(apv.IdSucursal, apv.IdProducto)

   '' ''            '#################

   '' ''            With vp

   '' ''               alicuotaIVA = producto.Alicuota
   '' ''               IdMoneda = producto.Moneda.IdMoneda

   '' ''               PrecioVentaSinIVA = Decimal.Round(apv.Precio / (1 + alicuotaIVA / 100), 2)
   '' ''               PrecioVentaConIVA = apv.Precio

   '' ''               KilosProd = 0
   '' ''               If vp.Producto.Kilos <> 0 Then
   '' ''                  KilosProd = Decimal.Round(vp.Producto.Kilos * vp.Cantidad, 3)
   '' ''                  Kilos += KilosProd
   '' ''               End If

   '' ''               If Publicos.PreciosConIVA Then
   '' ''                  precioProducto = PrecioVentaSinIVA
   '' ''               Else
   '' ''                  precioProducto = PrecioVentaConIVA
   '' ''               End If

   '' ''               'If (cliente.CategoriaFiscal.IvaDiscriminado And apv.CategoriaFiscalEmpresa.IvaDiscriminado) Or _
   '' ''               '   Not cliente.CategoriaFiscal.UtilizaImpuestos Or Not apv.CategoriaFiscalEmpresa.UtilizaImpuestos Then
   '' ''               '    precioProducto = PrecioVentaSinIVA
   '' ''               'Else
   '' ''               '    'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
   '' ''               '    precioProducto = PrecioVentaConIVA
   '' ''               'End If

   '' ''               alicuotaIVASobre100 = (alicuotaIVA / 100)

   '' ''               precioNeto = precioProducto

   '' ''               If Not cliente.CategoriaFiscal.IvaDiscriminado Or Not apv.CategoriaFiscalEmpresa.IvaDiscriminado Then
   '' ''                  importeIvaProducto = Decimal.Round(precioNeto - precioNeto / (1 + alicuotaIVASobre100), 2)
   '' ''               Else
   '' ''                  importeIvaProducto = Decimal.Round(precioNeto * alicuotaIVASobre100, 2)
   '' ''               End If


   '' ''               .Orden = apv.Orden
   '' ''               .Producto = producto 'New Eniac.Reglas.Productos().GetUno(idProd)
   '' ''               .IdSucursal = apv.IdSucursal
   '' ''               .Usuario = apv.NombreUsuario

   '' ''               .DescuentoRecargoPorc1 = 0
   '' ''               .DescuentoRecargoPorc2 = 0
   '' ''               .DescuentoRecargo = 0
   '' ''               .Precio = precioProducto
   '' ''               .Cantidad = apv.Cantidad
   '' ''               .Stock = 0
   '' ''               .Costo = prodSuc.PrecioCosto
   '' ''               .PrecioLista = prodSuc.PrecioVentaLista     '   precioProducto - (precioProducto * (alicuotaIVA / 100))   'Lo Dejo sin IVA como viene.
   '' ''               .Precio = precioProducto
   '' ''               .Kilos = KilosProd
   '' ''               .PrecioNeto = precioNeto
   '' ''               .AlicuotaImpuesto = alicuotaIVA
   '' ''               .ImporteImpuesto = importeIvaProducto * vp.Cantidad
   '' ''               .TipoImpuesto = New Eniac.Reglas.TiposImpuestos().GetUno(apv.TipoImpuestoIVA)
   '' ''               .ComisionVendedorPorc = 0
   '' ''               .ComisionVendedor = 0
   '' ''               .ImporteTotal = precioProducto * vp.Cantidad

   '' ''               .NumeroComprobante = apv.IdPedido

   '' ''               'Ahora multiplico todo por Cantidades
   '' ''               importeBrutoProducto = precioProducto * vp.Cantidad
   '' ''               importeNetoProducto = precioNeto * vp.Cantidad
   '' ''               importeIvaProducto = importeIvaProducto * vp.Cantidad
   '' ''               '----------------------------------------

   '' ''               'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
   '' ''               If (Not cliente.CategoriaFiscal.IvaDiscriminado Or Not apv.CategoriaFiscalEmpresa.IvaDiscriminado) Then
   '' ''                  importeBrutoProducto = Decimal.Round(importeBrutoProducto / (1 + alicuotaIVA / 100), 2)
   '' ''                  importeNetoProducto = Decimal.Round(importeNetoProducto / (1 + alicuotaIVA / 100), 2)
   '' ''               End If


   '' ''               entro = False

   '' ''               importeBruto += importeBrutoProducto
   '' ''               importeNeto += importeNetoProducto
   '' ''               importeIva += importeIvaProducto
   '' ''               importeTotal += (importeNetoProducto + importeIvaProducto)

   '' ''            End With

   '' ''            lvp.Add(vp)

   '' ''         Else ' no existe el producto


   '' ''         End If
   '' ''      Next

   '' ''      Return lvp

   '' ''   Catch ex As Exception
   '' ''      Throw ex
   '' ''   Finally
   '' ''      da.CloseConection()
   '' ''   End Try

   '' ''End Function


#Region "PreventaV2"

   Public Enum RollbackModeLevel
      PEDIDO
      ARCHIVO
      FULL
   End Enum

   Public Function GrabarPedidos(ds As Entidades.DsPreventa, fechaEnvio As DateTime) As List(Of Entidades.Pedido)
      Return GrabarPedidos(ds, fechaEnvio, RollbackModeLevel.PEDIDO)
   End Function
   Public Function GrabarPedidos(ds As Entidades.DsPreventa, fechaEnvio As DateTime, rollbackMode As RollbackModeLevel) As List(Of Entidades.Pedido)
      Dim result As List(Of Entidades.Pedido) = New List(Of Entidades.Pedido)()
      Try
         da.OpenConection()

         Dim rPedidos As Eniac.Reglas.Pedidos = New Eniac.Reglas.Pedidos(da)
         Dim categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal = New Eniac.Reglas.CategoriasFiscales(da).GetUno(Publicos.CategoriaFiscalEmpresa)

         If rollbackMode = RollbackModeLevel.FULL Then da.BeginTransaction()

         Dim tipoImpuestoIVA As Eniac.Entidades.TipoImpuesto = New Eniac.Reglas.TiposImpuestos().GetUno(Eniac.Entidades.TipoImpuesto.Tipos.IVA)
         Dim rCriticidad As Eniac.Reglas.PedidosCriticidades = New Eniac.Reglas.PedidosCriticidades(da)
         Dim drCriticidad As DataTable = rCriticidad.GetTodosPorOrden()
         Dim criticidad As Eniac.Entidades.CriticidadPedido = rCriticidad.GetUno(drCriticidad.Rows(0)(Eniac.Entidades.CriticidadPedido.Columnas.IdCriticidad.ToString()).ToString())

         Dim pedidosWebFormato As String = Publicos.PedidosWebFormato
         Dim rBasePedidoWeb As ServiciosRest.Pedidos.BasePedidosWeb ' = New PedidosWeb()

         Select Case pedidosWebFormato
            Case Entidades.PreVenta.FormatoWebPeridos.SiWeb.ToString()
               rBasePedidoWeb = New ServiciosRest.Pedidos.PedidosSiWeb()
            Case Entidades.PreVenta.FormatoWebPeridos.SiGA.ToString()
               rBasePedidoWeb = New ServiciosRest.Pedidos.PedidosSiGA()
            Case Entidades.PreVenta.FormatoWebPeridos.SiMovilPedidos.ToString()
               rBasePedidoWeb = New ServiciosRest.Pedidos.PedidosSiMovilPedidos()
            Case Else
               Throw New Exception(String.Format("El formato '{0}' no es soportado.", pedidosWebFormato))
         End Select



         Dim intRedondeoEnCalculos As Integer = Eniac.Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio
         Dim decKilosModificados As Decimal = Nothing

         Dim busquedasCacheadas As BusquedasCacheadas = New BusquedasCacheadas()


         For Each drArchivo As Entidades.DsPreventa.ArchivoRow In ds.Archivo.Rows
            Dim tpArchivo As Entidades.PreVenta.PreventaFormatoArchivo = DirectCast(drArchivo.FormatoArchivo, Entidades.PreVenta.PreventaFormatoArchivo)
            Dim vendedor As Eniac.Entidades.Empleado = New Eniac.Reglas.Empleados(da).GetUno(drArchivo.IdVendedor)
            'Dim tpComp As Eniac.Entidades.TipoComprobante = GetTipoComprobante(tpArchivo)

            Try
               If rollbackMode = RollbackModeLevel.ARCHIVO Then da.BeginTransaction()
               For Each drPedido As Entidades.DsPreventa.PedidoRow In drArchivo.GetPedidoRows().Where(Function(x) x.Pasa And x.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.PENDIENTE.ToString())
                  'If drPedido.Pasa And drPedido.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.PENDIENTE.ToString() Then

                  drPedido.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.PROCESANDO.ToString()
                  System.Windows.Forms.Application.DoEvents()

                  If tpArchivo = Entidades.PreVenta.PreventaFormatoArchivo.Web Then
                     If pedidosWebFormato = Entidades.PreVenta.FormatoWebPeridos.SiGA.ToString() Then
                        If ExistePedidoWeb(drPedido.IdSucursal, drPedido.IdTipoComprobante, drPedido.Letra, drPedido.CentroEmisor, drPedido.NumeroPedido) Then
                           drPedido.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.EXISTE.ToString()
                           System.Windows.Forms.Application.DoEvents()
                           Continue For
                        End If
                     ElseIf pedidosWebFormato = Entidades.PreVenta.FormatoWebPeridos.SiMovilPedidos.ToString() Then
                        If ExistePedidoCliente(actual.Sucursal.Id, drPedido.IdCliente, drPedido.FechaPedido) Then
                           drPedido.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.EXISTE.ToString()
                           System.Windows.Forms.Application.DoEvents()
                           Continue For
                        End If
                     Else
                        If ExistePedidoWeb(actual.Sucursal.Id, drPedido.NumeroPedido) Then
                           drPedido.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.EXISTE.ToString()
                           System.Windows.Forms.Application.DoEvents()
                           Continue For
                        End If
                     End If
                  End If

                  'Para evitar meter dos veces el mismo pedido
                  If tpArchivo = Entidades.PreVenta.PreventaFormatoArchivo.Estandar Then
                     If ExistePedidoCliente(actual.Sucursal.Id, drPedido.IdCliente, drPedido.FechaPedido) Then
                        Continue For
                     End If
                  ElseIf tpArchivo = Entidades.PreVenta.PreventaFormatoArchivo.PDA_CocaCola Then
                     If ExistePedidoPDA(actual.Sucursal.Id, PDACocaCola_CombinarEmisorNumero(drPedido.CentroEmisor, drPedido.NumeroPedido)) Then
                        Continue For
                     End If
                  ElseIf tpArchivo = Entidades.PreVenta.PreventaFormatoArchivo.Web Then
                     If ExistePedidoWeb(actual.Sucursal.Id, drPedido.NumeroPedido) Then
                        Continue For
                     End If
                  End If

                  Try
                     If rollbackMode = RollbackModeLevel.PEDIDO Then da.BeginTransaction()

                     Dim cliente As Entidades.Cliente = New Reglas.Clientes(da)._GetUno(drPedido.IdCliente)
                     Dim clienteVinculado As Entidades.Cliente = If(cliente.IdClienteCtaCte > 0, New Reglas.Clientes(da)._GetUno(cliente.IdClienteCtaCte), Nothing)
                     Dim tpFact As Eniac.Entidades.TipoComprobante

                     If drPedido.IsIdTipoComprobanteFactNull OrElse drPedido.IdTipoComprobante = "" Then
                        If String.IsNullOrWhiteSpace(cliente.IdTipoComprobante) Then
                           Throw New Exception(String.Format("El cliente ({0}) {1} no tiene configurado tipo de comprobante. Por favor verifique el cliente.",
                                                             cliente.CodigoCliente, cliente.NombreCliente))
                        End If
                        Try
                           tpFact = busquedasCacheadas.BuscaTipoComprobante(cliente.IdTipoComprobante)
                        Catch ex As Exception
                           Throw New Exception(String.Format("No se pudo encontrar el tipo de comprobante ({2}) asociado al cliente ({0}) {1}. Por favor verifique el cliente.",
                                                             cliente.CodigoCliente, cliente.NombreCliente, cliente.IdTipoComprobante), ex)
                        End Try
                     Else
                        tpFact = busquedasCacheadas.BuscaTipoComprobante(drPedido.IdTipoComprobanteFact)
                     End If
                     Dim transp As Eniac.Entidades.Transportista = New Eniac.Reglas.Transportistas().GetUno(drPedido.IdTransportista)
                     Dim estadoVisita As Eniac.Entidades.EstadoVisita = New Eniac.Reglas.EstadosVisitas(da).GetUno(drPedido.IdEstadoVenta)

                     Dim nroPedido As Long? = Nothing
                     If tpArchivo = Entidades.PreVenta.PreventaFormatoArchivo.PDA_CocaCola Then
                        'xx000000 donde xx es el centro emisor de la PDA y 000000 es el numero de pedido de la PDA
                        nroPedido = PDACocaCola_CombinarEmisorNumero(drPedido.CentroEmisor, drPedido.NumeroPedido) ' drPedido.CentroEmisor * 1000000 + drPedido.NumeroPedido
                     ElseIf tpArchivo = Entidades.PreVenta.PreventaFormatoArchivo.Web Then
                        nroPedido = drPedido.NumeroPedido
                        If pedidosWebFormato = Entidades.PreVenta.FormatoWebPeridos.SiMovilPedidos.ToString() Then
                           nroPedido = 0
                        End If
                     End If

                     Dim obs As String = String.Empty
                     If Not drPedido.IsObservacionesNull Then
                        obs = drPedido.Observaciones
                     End If

                     Dim tpComp As Entidades.TipoComprobante = busquedasCacheadas.BuscaTipoComprobante(drPedido.IdTipoComprobante)
                     Dim formaPago As Entidades.VentaFormaPago
                     If drPedido.IsIdFormasPagoNull Then
                        formaPago = busquedasCacheadas.BuscaFormasPago(cliente.IdFormasPago)
                     Else
                        formaPago = busquedasCacheadas.BuscaFormasPago(drPedido.IdFormasPago)
                     End If

                     Dim lstOrdenProducto As List(Of Integer) = New List(Of Integer)()
                     For Each drProducto As Entidades.DsPreventa.PedidoProductoRow In drPedido.GetPedidoProductoRows
                        If Not lstOrdenProducto.Contains(drProducto.OrdenProducto) Then
                           lstOrdenProducto.Add(drProducto.OrdenProducto)
                        End If
                     Next

                     For Each ordenProducto As Integer In lstOrdenProducto
                        Dim pedido As Eniac.Entidades.Pedido = rPedidos.CrearPedido(tpComp,
                                                                                    cliente,
                                                                                    drPedido.Letra,
                                                                                    drPedido.CentroEmisor,
                                                                                    nroPedido,
                                                                                    drPedido.FechaPedido,
                                                                                    vendedor, caja:=Nothing,
                                                                                    transp,
                                                                                    formaPago,
                                                                                    tpFact,
                                                                                    obs.Truncar(100),
                                                                                    estadoVisita,
                                                                                    ordenCompra:=Nothing,
                                                                                    descuentoRecargoPorc:=Nothing,
                                                                                    clienteVinculado:=clienteVinculado,
                                                                                    idMoneda:=Entidades.Moneda.Peso, cotizacionDolar:=Nothing, 0, 0)

                        pedido.NroVersionRemoto = drPedido.NroVersionRemoto

                        For Each drProducto As Entidades.DsPreventa.PedidoProductoRow In drPedido.GetPedidoProductoRows.AsEnumerable().Where(Function(x) x.OrdenProducto = ordenProducto)
                           Dim producto As Eniac.Entidades.Producto = Nothing
                           If drProducto.Cantidad <> 0 Or drProducto.CantidadBonif <> 0 Or drProducto.CantidadCambio <> 0 Then
                              producto = New Eniac.Reglas.Productos(da).GetUno(drProducto.IdProducto)
                           End If
                           If drProducto.Cantidad <> 0 Then
                              Dim precio As Decimal = drProducto.Precio

                              'If Publicos.PreciosConIVA Then
                              If tpComp.UtilizaImpuestos Then
                                 If Not pedido.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
                                    precio = drProducto.PrecioConIVA
                                 Else
                                    precio = drProducto.Precio
                                 End If
                              Else
                                 producto.Alicuota = 0
                                 precio = drProducto.Precio
                              End If


                              '-------Calcula kilos
                              If producto.Kilos <> 0 Then
                                 decKilosModificados = Decimal.Round(drProducto.Cantidad * producto.Kilos, 3)
                              Else
                                 decKilosModificados = Nothing
                              End If


                              'Else
                              '   If Not pedido.Cliente.CategoriaFiscal.IvaDiscriminado Or Not categoriaFiscalEmpresa.IvaDiscriminado Then
                              '      precio = drProducto.PrecioConIVA
                              '   Else
                              '      precio = drProducto.Precio
                              '   End If
                              'End If

                              Dim listaPrecios As Eniac.Entidades.ListaDePrecios
                              If Not drProducto.IsIdListaPreciosNull() Then
                                 listaPrecios = busquedasCacheadas.BuscaListaDePrecios(drProducto.IdListaPrecios)
                              Else
                                 listaPrecios = busquedasCacheadas.BuscaListaDePrecios(cliente.IdListaPrecios)
                              End If

                              Dim fechaEntrega As DateTime = fechaEnvio
                              If Not drProducto.IsFechaEntregaNull Then
                                 fechaEntrega = drProducto.FechaEntrega
                              End If

                              Dim tipoOperacion As Producto.TiposOperaciones = Entidades.Producto.TiposOperaciones.NORMAL
                              Dim nota As String = ""

                              rPedidos.AgregarLinea(pedido,
                                                    rPedidos.CrearPedidoProducto(producto,
                                                                                 producto.NombreProducto,
                                                                                 drProducto.PorcDesc1,
                                                                                 drProducto.PorcDesc2,
                                                                                 precio,
                                                                                 drProducto.Cantidad,
                                                                                 tipoImpuestoIVA,
                                                                                 Nothing,
                                                                                 listaPrecios,
                                                                                 criticidad,
                                                                                 fechaEntrega,
                                                                                 pedido,
                                                                                 intRedondeoEnCalculos,
                                                                                 decKilosModificados,
                                                                                 0, producto.Tamano, producto.UnidadDeMedida.IdUnidadDeMedida, producto.Moneda,
                                                                                 producto.Espmm, producto.EspPulgadas, producto.CodigoSAE, Nothing, Nothing,
                                                                                 0, 0, 0, Nothing, "", 0,
                                                                                 tipoOperacion,
                                                                                 nota,
                                                                                 costo:=0))

                           End If
                           If drProducto.CantidadBonif <> 0 Then
                              Dim precio As Decimal = 0

                              Dim listaPrecios As Eniac.Entidades.ListaDePrecios
                              If Not drProducto.IsIdListaPreciosNull() Then
                                 listaPrecios = busquedasCacheadas.BuscaListaDePrecios(drProducto.IdListaPrecios)
                              Else
                                 listaPrecios = busquedasCacheadas.BuscaListaDePrecios(cliente.IdListaPrecios)
                              End If

                              Dim fechaEntrega As DateTime = fechaEnvio
                              If Not drProducto.IsFechaEntregaNull Then
                                 fechaEntrega = drProducto.FechaEntrega
                              End If

                              Dim tipoOperacion As Producto.TiposOperaciones = Entidades.Producto.TiposOperaciones.BONIFICACION
                              Dim nota As String = drProducto.NotaBonif

                              rPedidos.AgregarLinea(pedido,
                                                    rPedidos.CrearPedidoProducto(producto,
                                                                                 producto.NombreProducto,
                                                                                 0,
                                                                                 0,
                                                                                 precio,
                                                                                 drProducto.CantidadBonif,
                                                                                 tipoImpuestoIVA,
                                                                                 Nothing,
                                                                                 listaPrecios,
                                                                                 criticidad,
                                                                                 fechaEntrega,
                                                                                 pedido,
                                                                                 intRedondeoEnCalculos,
                                                                                 decKilosModificados,
                                                                                 0, producto.Tamano, producto.UnidadDeMedida.IdUnidadDeMedida, producto.Moneda,
                                                                                 producto.Espmm, producto.EspPulgadas, producto.CodigoSAE, Nothing, Nothing,
                                                                                 0, 0, 0, Nothing, "", 0,
                                                                                 tipoOperacion,
                                                                                 nota,
                                                                                 costo:=0))

                           End If
                           If drProducto.CantidadCambio <> 0 Then
                              Dim precio As Decimal = 0

                              Dim listaPrecios As Eniac.Entidades.ListaDePrecios
                              If Not drProducto.IsIdListaPreciosNull() Then
                                 listaPrecios = busquedasCacheadas.BuscaListaDePrecios(drProducto.IdListaPrecios)
                              Else
                                 listaPrecios = busquedasCacheadas.BuscaListaDePrecios(cliente.IdListaPrecios)
                              End If

                              Dim fechaEntrega As DateTime = fechaEnvio
                              If Not drProducto.IsFechaEntregaNull Then
                                 fechaEntrega = drProducto.FechaEntrega
                              End If

                              Dim tipoOperacion As Producto.TiposOperaciones = Entidades.Producto.TiposOperaciones.CAMBIO
                              Dim nota As String = drProducto.NotaCambio

                              rPedidos.AgregarLinea(pedido,
                                                    rPedidos.CrearPedidoProducto(producto,
                                                                                 producto.NombreProducto,
                                                                                 0,
                                                                                 0,
                                                                                 precio,
                                                                                 drProducto.CantidadCambio,
                                                                                 tipoImpuestoIVA,
                                                                                 Nothing,
                                                                                 listaPrecios,
                                                                                 criticidad,
                                                                                 fechaEntrega,
                                                                                 pedido,
                                                                                 intRedondeoEnCalculos,
                                                                                 decKilosModificados,
                                                                                 0, producto.Tamano, producto.UnidadDeMedida.IdUnidadDeMedida, producto.Moneda,
                                                                                 producto.Espmm, producto.EspPulgadas, producto.CodigoSAE, Nothing, Nothing,
                                                                                 0, 0, 0, Nothing, "", 0,
                                                                                 tipoOperacion,
                                                                                 nota,
                                                                                 costo:=0))

                           End If
                        Next
                        '--------------------------------------------------------------------------------------------------------------------------------------------------
                        Dim drProdDev = drPedido.GetPedidoProductoRows.AsEnumerable().Where(Function(x) x.CantidadDevolucion <> 0)
                        If drProdDev.Count > 0 Then
                           Dim ncVenta As Entidades.Venta
                           Dim rVenta = New Ventas(da)
                           Dim transportista = busquedasCacheadas.BuscaTransportista(If(drPedido.IsIdTransportistaNull, 0I, drPedido.IdTransportista))
                           Dim caja As Entidades.CajaNombre = New Reglas.CajasNombres().GetTodas(actual.Sucursal.IdSucursal)(0)

                           ncVenta = rVenta.CreaVenta(drPedido.IdSucursal,
                                                      busquedasCacheadas.BuscaTipoComprobante(Publicos.IdNotaCreditoNoGrabaLibro), letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0,
                                                      cliente:=busquedasCacheadas.BuscaClienteEntidadPorId(drPedido.IdCliente), categoriaFiscal:=Nothing,
                                                      fecha:=drPedido.FechaPedido, vendedor:=vendedor,
                                                      transportista, formaPago:=Nothing,
                                                      descuentoRecargoPorc:=Nothing, idCaja:=caja.IdCaja, cotizacionDolar:=Nothing, mercDespachada:=False,
                                                      numeroReparto:=Nothing,
                                                      fechaEnvio:=Nothing, proveedor:=Nothing,
                                                      observaciones:="Nota Credito Parcial",
                                                      cobrador:=Nothing, clienteVinculado:=Nothing, nroOrdenCompra:=0)

                           For Each drProd In drProdDev
                              Dim prod = busquedasCacheadas.BuscaProductoEntidadPorId(drProd.IdProducto)
                              Dim precio = drProd.Precio
                              If ncVenta.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado And
                                 ncVenta.CategoriaFiscal.UtilizaImpuestos And categoriaFiscalEmpresa.UtilizaImpuestos Then
                                 precio = Math.Round(CalculosImpositivos.ObtenerPrecioSinImpuestos(precio, prod), Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio)
                              End If

                              Dim ncProd = rVenta.CreaVentaProducto(prod, drProd.NombreProducto,
                                                                    0, 0,
                                                                    precio, drProd.CantidadDevolucion,
                                                                    busquedasCacheadas.BuscaTiposImpuestos(prod.IdTipoImpuesto), Nothing,
                                                                    busquedasCacheadas.BuscaListaDePrecios(drProd.IdListaPrecios),
                                                                    fechaEntrega:=Nothing, tipoOperacion:=Entidades.Producto.TiposOperaciones.NORMAL, nota:=drProd.NotaDevolucion, Nothing,
                                                                    venta:=ncVenta, redondeoEnCalculo:=Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                              rVenta.AgregarVentaProducto(ncVenta, ncProd, Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio)
                           Next
                           rVenta.Inserta(ncVenta, Entidades.Entidad.MetodoGrabacion.Automatico, Nothing)
                        End If
                        '--------------------------------------------------------------------------------------------------------------------------------------------------
                        If drPedido.GetPedidoProductoRows.AsEnumerable().Where(Function(x) x.Cantidad <> 0).Count > 0 Then
                           result.Add(rPedidos.Inserta(pedido))
                        End If
                        '--------------------------------------------------------------------------------------------------------------------------------------------------
                     Next

                     'If New Random().Next(0, 10) > 7 Then
                     '   Throw New Exception("Corte para pruebas")
                     'End If

                     drPedido.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.GRABADO.ToString()
                     System.Windows.Forms.Application.DoEvents()

                     If rollbackMode = RollbackModeLevel.PEDIDO Then
                        da.CommitTransaction()
                     End If
                  Catch
                     If rollbackMode = RollbackModeLevel.PEDIDO Then da.RollbakTransaction()
                     drPedido.EstadoGrabacion = Entidades.PreVenta.PreventaEstadoGrabacionPedido.CONERROR.ToString()
                     System.Windows.Forms.Application.DoEvents()
                     Throw
                  End Try
                  If rollbackMode = RollbackModeLevel.PEDIDO Then
                     If drArchivo.FormatoArchivo.Equals(Entidades.PreVenta.PreventaFormatoArchivo.Web) Then
                        rBasePedidoWeb.SetEstadoPedidoProcesado(drPedido, ServiciosRest.Pedidos.BasePedidosWeb.EstadoSiWeb.Procesado)
                     End If
                  End If
                  'End If
               Next  'For Each drPedido As Entidades.DsPreventa.PedidoRow In drArchivo.GetPedidoRows()
               If rollbackMode = RollbackModeLevel.ARCHIVO Then
                  da.CommitTransaction()
                  If drArchivo.FormatoArchivo.Equals(Entidades.PreVenta.PreventaFormatoArchivo.Web) Then
                     For Each pedido As DsPreventa.PedidoRow In drArchivo.GetPedidoRows
                        rBasePedidoWeb.SetEstadoPedidoProcesado(pedido, ServiciosRest.Pedidos.BasePedidosWeb.EstadoSiWeb.Procesado)
                     Next
                  End If
               End If
            Catch
               If rollbackMode = RollbackModeLevel.ARCHIVO Then da.RollbakTransaction()
               Throw
            End Try

            Inserta(drArchivo.NombreArchivo, drArchivo.IdVendedor)

         Next  'For Each drArchivo As Entidades.DsPreventa.ArchivoRow In ds.Archivo.Rows
         If rollbackMode = RollbackModeLevel.FULL Then
            da.CommitTransaction()
            For Each drArchivo As DsPreventa.ArchivoRow In ds.Archivo
               If drArchivo.FormatoArchivo.Equals(Entidades.PreVenta.PreventaFormatoArchivo.Web) Then
                  For Each pedido As DsPreventa.PedidoRow In drArchivo.GetPedidoRows
                     rBasePedidoWeb.SetEstadoPedidoProcesado(pedido, ServiciosRest.Pedidos.BasePedidosWeb.EstadoSiWeb.Procesado)
                  Next
               End If
            Next
         End If
      Catch
         If rollbackMode = RollbackModeLevel.FULL Then da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
      Return result
   End Function

   Private Function GetTipoComprobante(formato As Entidades.PreVenta.PreventaFormatoArchivo) As Eniac.Entidades.TipoComprobante
      Select Case formato
         Case Entidades.PreVenta.PreventaFormatoArchivo.Estandar
            Return New Eniac.Reglas.TiposComprobantes(da).GetUno("PEDIDO")
         Case Entidades.PreVenta.PreventaFormatoArchivo.PDA_CocaCola
            Return New Eniac.Reglas.TiposComprobantes(da).GetUno("PEDIDOPDA")
         Case Entidades.PreVenta.PreventaFormatoArchivo.Web
            Return New Eniac.Reglas.TiposComprobantes(da).GetUno("PEDIDOWEB")
         Case Else
            Throw New Exception(String.Format("Formato {0} no soportado", formato.ToString()))
      End Select
   End Function

   Public Sub BorrarArchivo(drArchivo As Entidades.DsPreventa.ArchivoRow)
      Try
         Dim ds As Entidades.DsPreventa = DirectCast(drArchivo.Table.DataSet, Entidades.DsPreventa)

         For Each dr As Entidades.DsPreventa.PedidoProductoRow In drArchivo.GetPedidoProductoRows
            dr.Delete()
         Next
         For Each dr As Entidades.DsPreventa.PedidoRow In drArchivo.GetPedidoRows
            dr.Delete()
         Next
         drArchivo.Delete()

         drArchivo.Table.DataSet.AcceptChanges()
      Catch
         drArchivo.Table.DataSet.RejectChanges()
         Throw
      End Try
   End Sub

   Public Function NewBasePedidosWeb() As ServiciosRest.Pedidos.BasePedidosWeb
      Dim pedidosWebFormato As String = Reglas.Publicos.PedidosWebFormato
      Select Case pedidosWebFormato
         Case Entidades.PreVenta.FormatoWebPeridos.SiWeb.ToString()
            Return New ServiciosRest.Pedidos.PedidosSiWeb()
         Case Entidades.PreVenta.FormatoWebPeridos.SiGA.ToString()
            Return New ServiciosRest.Pedidos.PedidosSiGA()
         Case Entidades.PreVenta.FormatoWebPeridos.SiMovilPedidos.ToString()
            Return New ServiciosRest.Pedidos.PedidosSiMovilPedidos()
         Case Else
            Throw New Exception(String.Format("El formato '{0}' no es soportado.", pedidosWebFormato))
      End Select
   End Function

   Public Function AgregarPedidoWeb(ds As Entidades.DsPreventa, rutasSeleccionadas As List(Of Entidades.JSonEntidades.CobranzasMovil.Rutas)) As Entidades.DsPreventa
      Try
         da.OpenConection()

         Dim servRest As ServiciosRest.Pedidos.BasePedidosWeb = NewBasePedidosWeb()

         servRest.AgregarPedidoWeb(ds, da, rutasSeleccionadas)

         ds.AcceptChanges()
      Catch
         ds.RejectChanges()
         Throw
      Finally
         da.CloseConection()
      End Try
      Return ds

   End Function

   Public Function ValidaEstadoVisita(drPedido As Entidades.DsPreventa.PedidoRow) As String
      Dim estadoVisita As Eniac.Entidades.EstadoVisita
      Try
         estadoVisita = New Reglas.EstadosVisitas(da).GetUno(drPedido.IdEstadoVenta) ' GetEstadoVisita(drPedido.IdEstadoVenta)
      Catch ex As Exception
         estadoVisita = Nothing
      End Try
      If estadoVisita Is Nothing Then
         Return "ESTADO DE VISITA INEXISTENTE"
      Else
         Return ValidaEstadoVisita(estadoVisita, drPedido)
      End If
   End Function

   Public Function ValidaEstadoVisita(estadoVisita As Eniac.Entidades.EstadoVisita, drPedido As Entidades.DsPreventa.PedidoRow) As String
      'Si el Estado de Visita no adminte lineas y el pedido viene con lineas, no puedo guardar el pedido.
      If Not estadoVisita.AdmintePedidoConLineas And drPedido.GetPedidoProductoRows.Count > 0 Then
         Return String.Format("EL ESTADO DE VISITA '{0}' NO ADMITE LINEAS.",
                              estadoVisita.NombreEstadoVisita)
      End If

      'Si el Estado de Visita no adminte sin lineas y el pedido viene sin lineas, no puedo guardar el pedido.
      If Not estadoVisita.AdmitePedidoSinLineas And drPedido.GetPedidoProductoRows.Count = 0 Then
         Return String.Format("EL ESTADO DE VISITA '{0}' REQUIERE AL MENOS UNA LINEA.",
                              estadoVisita.NombreEstadoVisita)
      End If
      Return String.Empty
   End Function

   Public Sub MarcarPedidoComoProcesado(drPedido As Entidades.DsPreventa.PedidoRow)
      Dim pedidosWebFormato As String = Publicos.PedidosWebFormato
      Dim rBasePedidoWeb As ServiciosRest.Pedidos.BasePedidosWeb

      Select Case pedidosWebFormato
         Case Entidades.PreVenta.FormatoWebPeridos.SiWeb.ToString()
            rBasePedidoWeb = New ServiciosRest.Pedidos.PedidosSiWeb()
         Case Entidades.PreVenta.FormatoWebPeridos.SiGA.ToString()
            rBasePedidoWeb = New ServiciosRest.Pedidos.PedidosSiGA()
         Case Entidades.PreVenta.FormatoWebPeridos.SiMovilPedidos.ToString()
            rBasePedidoWeb = New ServiciosRest.Pedidos.PedidosSiMovilPedidos()
         Case Else
            Throw New Exception(String.Format("El formato '{0}' no es soportado.", pedidosWebFormato))
      End Select

      'If pedidosWebFormato = Entidades.PreVenta.FormatoWebPeridos.SiGA.ToString() Then
      '   rBasePedidoWeb = New ServiciosRest.Pedidos.PedidosSiGA()
      'Else
      '   rBasePedidoWeb = New ServiciosRest.Pedidos.PedidosSiWeb()
      'End If

      rBasePedidoWeb.SetEstadoPedidoProcesado(drPedido, ServiciosRest.Pedidos.BasePedidosWeb.EstadoSiWeb.Procesado)
   End Sub

   '' '' '' ''Private Sub AgregarArchivoPDA_CocaCola(fiArchivo As FileInfo, drArchivo As Entidades.DsPreventa.ArchivoRow, ds As Entidades.DsPreventa)
   '' '' '' ''   Dim arPDA As Entidades.ArchivoPDA = New Entidades.ArchivoPDA()

   '' '' '' ''   Dim estadoVisita As List(Of Eniac.Entidades.EstadoVisita) = New Eniac.Reglas.EstadosVisitas().GetTodos(False, True)
   '' '' '' ''   Dim preventaV2ImportaDescuentos As Boolean = Publicos.PreventaV2ImportaDescuentos

   '' '' '' ''   Using stmArchivo As New StreamReader(fiArchivo.FullName)
   '' '' '' ''      arPDA = arPDA.GetInfo(stmArchivo)

   '' '' '' ''      If arPDA.Datos.Count > 0 Then
   '' '' '' ''         Dim ruta As Entidades.Ruta
   '' '' '' ''         Try
   '' '' '' ''            ruta = New SiLIVE.Reglas.Rutas(da)._GetUno(arPDA.Datos(0).CodigoRuta)
   '' '' '' ''         Catch ex As Exception
   '' '' '' ''            Throw New Exception(String.Format("Error buscando la ruta '{0}': {1}", arPDA.Datos(0).CodigoRuta, ex.Message), ex)
   '' '' '' ''         End Try

   '' '' '' ''         drArchivo.IdRuta = ruta.IdRuta
   '' '' '' ''         drArchivo.NombreRuta = ruta.NombreRuta
   '' '' '' ''         drArchivo.TipoDocVendedor = ruta.Vendedor.TipoDocEmpleado
   '' '' '' ''         drArchivo.NroDocVendedor = ruta.Vendedor.NroDocEmpleado
   '' '' '' ''         drArchivo.NombreVendedor = ruta.Vendedor.NombreEmpleado

   '' '' '' ''         For Each lineaPedido As Entidades.ArchivoPDADatos In arPDA.Datos
   '' '' '' ''            Dim cliente As Entidades.Cliente = Nothing

   '' '' '' ''            Dim centroEmisor As Short = Short.Parse(lineaPedido.NroPedido.Split("-"c)(0))
   '' '' '' ''            Dim numeroPedido As Long = Long.Parse(lineaPedido.NroPedido.Split("-"c)(1))
   '' '' '' ''            Dim drPedido As Entidades.DsPreventa.PedidoRow
   '' '' '' ''            Dim drCol() As DataRow
   '' '' '' ''            drCol = ds.Pedido.Select(String.Format("NombreArchivo = '{0}' And CentroEmisor = {1} And NumeroPedido = {2}",
   '' '' '' ''                                                   drArchivo.NombreArchivo, centroEmisor, numeroPedido))
   '' '' '' ''            Try
   '' '' '' ''               cliente = New Reglas.Clientes(da).GetUnoPorCodigo(Long.Parse(lineaPedido.CodigoCliente))
   '' '' '' ''            Catch ex As Exception
   '' '' '' ''               cliente = Nothing
   '' '' '' ''            End Try

   '' '' '' ''            If drCol.Length = 0 Then
   '' '' '' ''               drPedido = ds.Pedido.NewPedidoRow()
   '' '' '' ''               drPedido.ArchivoRow = drArchivo
   '' '' '' ''               drPedido.CentroEmisor = centroEmisor
   '' '' '' ''               drPedido.NumeroPedido = numeroPedido

   '' '' '' ''               drPedido.IdEstadoVenta = estadoVisita(0).IdEstadoVisita
   '' '' '' ''               drPedido.NombreEstadoVenta = estadoVisita(0).NombreEstadoVisita

   '' '' '' ''               drPedido.FechaPedido = lineaPedido.Fecha

   '' '' '' ''               drPedido.Pasa = True
   '' '' '' ''               drPedido.Estado = Entidades.PreventaEstadoPedido.Normal

   '' '' '' ''               drPedido.CodigoCliente = Long.Parse(lineaPedido.CodigoCliente)

   '' '' '' ''               If cliente Is Nothing Then
   '' '' '' ''                  drPedido.Pasa = False
   '' '' '' ''                  drPedido.Estado = Entidades.PreventaEstadoPedido.ConError
   '' '' '' ''                  drPedido.MensajeError = "CLIENTE INACTIVO o INEXISTENTE"
   '' '' '' ''                  drPedido.IdCliente = drPedido.CodigoCliente
   '' '' '' ''               Else
   '' '' '' ''                  drPedido.IdCliente = cliente.IdCliente
   '' '' '' ''                  drPedido.CodigoCliente = cliente.CodigoCliente
   '' '' '' ''                  drPedido.TipoDocCliente = cliente.TipoDocCliente.TipoDocumento
   '' '' '' ''                  drPedido.NroDocCliente = cliente.NroDocCliente
   '' '' '' ''                  drPedido.NombreCliente = cliente.NombreCliente
   '' '' '' ''                  drPedido.Direccion = cliente.Direccion
   '' '' '' ''                  drPedido.NombreCategoriaFiscalAbrev = cliente.CategoriaFiscal.NombreCategoriaFiscalAbrev
   '' '' '' ''                  drPedido.CUIT = cliente.CUIT

   '' '' '' ''                  drPedido.PorcDesc = New Eniac.Reglas.Ventas().DescuentoRecargo(cliente.GetEntidadClienteDelSiGA(), "PEDIDO")

   '' '' '' ''                  If cliente.Transportista.NombreTransportista = ".SIN FLETE" Then
   '' '' '' ''                     drPedido.IdTransportista = ruta.IdTransportista
   '' '' '' ''                     drPedido.NombreTransportista = ruta.Transportista.NombreTransportista
   '' '' '' ''                  Else
   '' '' '' ''                     drPedido.IdTransportista = cliente.Transportista.idTransportista
   '' '' '' ''                     drPedido.NombreTransportista = cliente.Transportista.NombreTransportista
   '' '' '' ''                  End If

   '' '' '' ''                  If ExistePedidoPDA(Long.Parse(lineaPedido.NroPedido.Split("-"c)(1))) Then
   '' '' '' ''                     drPedido.Pasa = False
   '' '' '' ''                     drPedido.Estado = Entidades.PreventaEstadoPedido.ConError
   '' '' '' ''                     drPedido.MensajeError = "PEDIDO YA INGRESADO"
   '' '' '' ''                  End If

   '' '' '' ''               End If

   '' '' '' ''               If Not ds.Archivo.Contains(drArchivo) Then
   '' '' '' ''                  ds.Archivo.AddArchivoRow(drArchivo)
   '' '' '' ''               End If
   '' '' '' ''               ds.Pedido.AddPedidoRow(drPedido)
   '' '' '' ''            Else
   '' '' '' ''               drPedido = DirectCast(drCol(0), Entidades.DsPreventa.PedidoRow)
   '' '' '' ''            End If

   '' '' '' ''            Dim drPedidoProducto As Entidades.DsPreventa.PedidoProductoRow = ds.PedidoProducto.NewPedidoProductoRow()
   '' '' '' ''            drPedidoProducto.PedidoRowParent = drPedido
   '' '' '' ''            drPedidoProducto.IdProducto = lineaPedido.CodigoProducto

   '' '' '' ''            Dim producto As Eniac.Entidades.ProductoSucursal
   '' '' '' ''            Try
   '' '' '' ''               If cliente IsNot Nothing Then
   '' '' '' ''                  producto = New Eniac.Reglas.ProductosSucursales(da).GetUno(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
   '' '' '' ''                                                                             drPedidoProducto.IdProducto,
   '' '' '' ''                                                                             cliente.ListaDePrecios.IdListaPrecios)
   '' '' '' ''               Else
   '' '' '' ''                  producto = New Eniac.Reglas.ProductosSucursales(da).GetUno(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
   '' '' '' ''                                                                             drPedidoProducto.IdProducto,
   '' '' '' ''                                                                             Publicos.ListaPreciosPredeterminada)
   '' '' '' ''               End If
   '' '' '' ''            Catch ex As Exception
   '' '' '' ''               producto = Nothing
   '' '' '' ''            End Try

   '' '' '' ''            drPedidoProducto.Cantidad = lineaPedido.Cantidad
   '' '' '' ''            drPedidoProducto.Precio = lineaPedido.Precio
   '' '' '' ''            drPedidoProducto.Orden = ds.PedidoProducto.Count + 1

   '' '' '' ''            ds.PedidoProducto.AddPedidoProductoRow(drPedidoProducto)

   '' '' '' ''            If producto Is Nothing OrElse String.IsNullOrWhiteSpace(producto.Producto.IdProducto) Then
   '' '' '' ''               drPedido.Pasa = False
   '' '' '' ''               drPedido.Estado = Entidades.PreventaEstadoPedido.ConError
   '' '' '' ''               drPedido.MensajeError = "ARTICULO INACTIVO o INEXISTENTE"
   '' '' '' ''            Else
   '' '' '' ''               drPedidoProducto.NombreProducto = producto.Producto.NombreProducto
   '' '' '' ''               drPedidoProducto.PrecioLista = producto.PrecioVentaLista
   '' '' '' ''               drPedidoProducto.Stock = producto.Stock

   '' '' '' ''               Dim descRec As Eniac.Reglas.Ventas.DescuentoRecargoProducto = New Eniac.Reglas.Ventas().DescuentoRecargo(cliente.GetEntidadClienteDelSiGA(), producto.Producto, drPedidoProducto.Cantidad)
   '' '' '' ''               drPedidoProducto.PorcDesc1 = descRec.DescuentoRecargo1
   '' '' '' ''               drPedidoProducto.PorcDesc2 = descRec.DescuentoRecargo2

   '' '' '' ''               If lineaPedido.Porcentaje <> 0 Then
   '' '' '' ''                  If drPedidoProducto.PorcDesc1 = 0 Then
   '' '' '' ''                     drPedidoProducto.PorcDesc1 = lineaPedido.Porcentaje * -1
   '' '' '' ''                  ElseIf drPedidoProducto.PorcDesc2 = 0 Then
   '' '' '' ''                     drPedidoProducto.PorcDesc2 = lineaPedido.Porcentaje * -1
   '' '' '' ''                  Else
   '' '' '' ''                     Dim desc1 As Decimal = (100 + drPedidoProducto.PorcDesc1) / 100
   '' '' '' ''                     Dim desc2 As Decimal = (100 + lineaPedido.Porcentaje * -1) / 100

   '' '' '' ''                     drPedidoProducto.PorcDesc1 = Decimal.Round(((desc1 * desc2) - 1) * 100, 2)
   '' '' '' ''                  End If
   '' '' '' ''               End If
   '' '' '' ''            End If

   '' '' '' ''            Dim importe As Decimal = Math.Round(drPedidoProducto.PrecioLista, 2) * drPedidoProducto.Cantidad
   '' '' '' ''            If Not Publicos.PreciosConIVA Then
   '' '' '' ''               importe = Math.Round(drPedidoProducto.PrecioLista +
   '' '' '' ''                                    (drPedidoProducto.PrecioLista * drPedidoProducto.IVA / 100), 2) * drPedidoProducto.Cantidad
   '' '' '' ''            End If

   '' '' '' ''            importe = importe + (importe * drPedidoProducto.PorcDesc1 / 100)
   '' '' '' ''            importe = importe + (importe * drPedidoProducto.PorcDesc2 / 100)

   '' '' '' ''            drPedidoProducto.ImporteTotal = importe

   '' '' '' ''            importe = importe + (importe * drPedido.PorcDesc / 100)

   '' '' '' ''            drPedido.ImporteTotal += importe

   '' '' '' ''            drPedidoProducto.CantidadSinCargo = lineaPedido.CantidadSinCargo
   '' '' '' ''            drPedidoProducto.CantidadFaltante = lineaPedido.CantidadFaltante
   '' '' '' ''            drPedidoProducto.CantidadDevolucion = lineaPedido.CantidadDevolucion

   '' '' '' ''            If lineaPedido.Porcentaje <> 0 Then
   '' '' '' ''               If preventaV2ImportaDescuentos Then
   '' '' '' ''                  drPedidoProducto.PorcDesc1 = lineaPedido.Porcentaje * -1
   '' '' '' ''                  drPedidoProducto.PorcDesc2 = 0
   '' '' '' ''                  drPedido.Pasa = True
   '' '' '' ''               Else
   '' '' '' ''                  drPedido.Pasa = False
   '' '' '' ''               End If
   '' '' '' ''               drPedido.Estado = Entidades.PreventaEstadoPedido.Advertencia
   '' '' '' ''               drPedido.MensajeError = "PEDIDO CON ARTICULOS CON DESCUENTO"
   '' '' '' ''            End If

   '' '' '' ''            If drPedidoProducto.CantidadSinCargo <> 0 Or
   '' '' '' ''               drPedidoProducto.CantidadFaltante <> 0 Or
   '' '' '' ''               drPedidoProducto.CantidadDevolucion <> 0 Then
   '' '' '' ''               drPedido.Pasa = False
   '' '' '' ''               drPedido.Estado = Entidades.PreventaEstadoPedido.Advertencia
   '' '' '' ''               drPedido.MensajeError = "PEDIDO CON ARTICULOS CON NOVEDADES"
   '' '' '' ''            End If
   '' '' '' ''         Next
   '' '' '' ''      End If
   '' '' '' ''   End Using
   '' '' '' ''End Sub

   '' '' '' ''Private Function GetFormatoArchivo(fiArchivo As FileInfo) As Entidades.PreventaFormatoArchivo
   '' '' '' ''   Using stmArchivo As New StreamReader(fiArchivo.FullName)
   '' '' '' ''      Dim primerLinea As String = stmArchivo.ReadLine()
   '' '' '' ''      Dim idRuta As Integer
   '' '' '' ''      If Integer.TryParse(primerLinea, idRuta) Then
   '' '' '' ''         Return Entidades.PreventaFormatoArchivo.Estandar
   '' '' '' ''      Else
   '' '' '' ''         Return Entidades.PreventaFormatoArchivo.PDA_CocaCola
   '' '' '' ''      End If
   '' '' '' ''   End Using
   '' '' '' ''End Function

   '' ''Private Function ExistePedidoCliente(IdCliente As Long, fechaPedido As DateTime) As Boolean
   '' ''   Return New Reglas.Pedidos(da).ExistePedido(IdCliente, fechaPedido)
   '' ''End Function

   '' ''Private Function ExistePedidoPDA(ByVal NumeroPedido As Long) As Boolean
   '' ''   Return New Reglas.Pedidos(da).ExistePedido(NumeroPedido)
   '' ''End Function
#End Region

   Private Function ExistePedidoWeb(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroPedido As Long) As Boolean
      Return New Reglas.Pedidos().ExistePedido(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido)
   End Function
   Private Function ExistePedidoWeb(idSucursal As Integer, NumeroPedido As Long) As Boolean
      Return New Reglas.Pedidos().ExistePedido(idSucursal, "PEDIDOWEB", NumeroPedido)
   End Function
End Class