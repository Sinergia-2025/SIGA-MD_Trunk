#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On

Imports Eniac.Entidades
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
Imports System.IO
Imports System.Xml.Serialization

#End Region
Partial Class Ventas

#Region "Metodos Privados"

#End Region

#Region "Metodos Publicos"

   Public Function GetFacturasGeneradas(ByVal Sucursal As Integer,
                                    ByVal Desde As DateTime,
                                    ByVal Hasta As DateTime) As DataTable


      Return New SqlServer.Ventas(Me.da).GetFacturasGeneradas(Sucursal, Desde, Hasta)

   End Function

   'Public Sub ModificarTComp(ByVal comprobantes As Eniac.Entidades.Venta)

   '   Dim conectar As Boolean = True
   '   If da.Connection IsNot Nothing AndAlso da.Connection.State = ConnectionState.Open Then conectar = False

   '   Try
   '      If conectar Then
   '         da.OpenConection()
   '         da.BeginTransaction()
   '      End If

   '      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

   '      sql.Ventas_Pedidos_TipoCompFact(comprobantes.IdSucursal, comprobantes.TipoComprobante.IdTipoComprobante, comprobantes.LetraComprobante,
   '                                    comprobantes.CentroEmisor, comprobantes.NumeroComprobante, comprobantes.TipoComprobanteFact)


   '      If conectar Then da.CommitTransaction()

   '   Catch ex As Exception
   '      If conectar Then da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      If conectar Then da.CloseConection()
   '   End Try

   'End Sub

   Public Sub ModificarFormaPago(fila As DataRow, idFormaPago As Integer)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_Pedidos_FormaPago(actual.Sucursal.Id,
                                      fila("IdTipoComprobante").ToString(),
                                      fila("Letra").ToString(),
                                      CShort(fila("CentroEmisor")),
                                      CLng(fila("NumeroPedido")),
                                      idFormaPago,
                                      fechaRendicion:=Nothing,
                                      cambiaFormaPago:=False)

         If blnAbreConexion Then da.CommitTransaction()

      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub ModificarFormaPago(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      EjecutaConTransaccion(Sub() _ModificarFormaPago(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, fechaRendicion:=Today))
   End Sub

   Public Sub _ModificarFormaPago(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                  fechaRendicion As DateTime)
      Dim idFormaPago As Integer = Publicos.OrganizarEntregaFormaDePago

      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      sql.Ventas_Pedidos_FormaPago(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                   idFormaPago, fechaRendicion, cambiaFormaPago:=False)

      Dim sqlCC As SqlServer.RegistracionPagos = New SqlServer.RegistracionPagos(da)
      sqlCC.ActualizarDatosCC(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                              idFormaPago)
   End Sub
   Public Sub ModificarFechaRendicion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      EjecutaConTransaccion(Sub() _ModificarFechaRendicion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, fechaRendicion:=Today))
   End Sub
   Public Sub _ModificarFechaRendicion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, fechaRendicion As DateTime)
      Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
      sql.Ventas_Pedidos_FechaRendicion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, fechaRendicion)
   End Sub
   Public Sub ModificarFormaPago(ByVal comprobantes As Eniac.Entidades.Venta)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_Pedidos_FormaPago(comprobantes.IdSucursal, comprobantes.TipoComprobante.IdTipoComprobante, comprobantes.LetraComprobante,
                                      comprobantes.CentroEmisor, comprobantes.NumeroComprobante, comprobantes.FormaPago.IdFormasPago,
                                      fechaRendicion:=Nothing,
                                      cambiaFormaPago:=False)


         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub ModificarRespDistrib(ByVal comprobantes As Eniac.Entidades.Venta)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_Pedidos_RespDist(comprobantes.IdSucursal, comprobantes.TipoComprobante.IdTipoComprobante, comprobantes.LetraComprobante,
                                       comprobantes.CentroEmisor, comprobantes.NumeroComprobante, comprobantes.Transportista.idTransportista)


         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub ModificarRespDistrib(fila As DataRow, idRespDist As Integer, nomTransp As String)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.Ventas_Pedidos_RespDist(actual.Sucursal.Id,
                           fila("IdTipoComprobante").ToString(),
                           fila("Letra").ToString(),
                           CShort(fila("CentroEmisor")),
                           CLng(fila("NumeroPedido")),
                           idRespDist)
      Catch
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub
   Public Sub ModificarPalets(fila As DataRow, cantidadPalets As Integer)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.Actualizar_Palets(actual.Sucursal.Id,
                           fila("IdTipoComprobante").ToString(),
                           fila("Letra").ToString(),
                           CShort(fila("CentroEmisor")),
                           CLng(fila("NumeroPedido")),
                           cantidadPalets)
      Catch
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Sub CambiarFechaEnvio(ByVal comprobantes As Eniac.Entidades.Venta)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_Pedidos_FechaEnvio(comprobantes.IdSucursal, comprobantes.TipoComprobante.IdTipoComprobante, comprobantes.LetraComprobante,
                                       comprobantes.CentroEmisor, comprobantes.NumeroComprobante, comprobantes.FechaEnvio)


         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub CambiarFechaEnvio(fila As DataRow, fecEnvio As Date)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         sql.Ventas_Pedidos_FechaEnvio(actual.Sucursal.Id,
                           fila("IdTipoComprobante").ToString(),
                           fila("Letra").ToString(),
                           CShort(fila("CentroEmisor")),
                           CLng(fila("NumeroPedido")),
                           fecEnvio.Date)
      Catch
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub


   Public Sub ModificarFechayRespDistrib(ByVal comprobantes As Eniac.Entidades.Venta)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.Ventas_Pedidos_FechaEnvio_respDist(comprobantes.IdSucursal, comprobantes.TipoComprobante.IdTipoComprobante, comprobantes.LetraComprobante,
                                                   comprobantes.CentroEmisor, comprobantes.NumeroComprobante, comprobantes.FechaEnvio, comprobantes.Transportista.idTransportista)


         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try


   End Sub
   Public Sub ModificarObs(ByVal comprobantes As Eniac.Entidades.Venta)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)

         sql.ModificarObs(comprobantes.IdSucursal, comprobantes.TipoComprobante.IdTipoComprobante, comprobantes.LetraComprobante,
                                                   comprobantes.CentroEmisor, comprobantes.NumeroComprobante, comprobantes.Observacion)


         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function ExistePedidoXCli_Fecha(ByVal IdCliente As Long, fechaPed As DateTime) As Boolean

      Return New SqlServer.Ventas(Me.da).ExistePedidoXCli_Fecha(IdCliente, fechaPed)

   End Function

   Public Function ExistePedidoPDA(ByVal NumeroPedido As Long) As Boolean

      Return New SqlServer.Ventas(Me.da).ExistePedidoPDA(NumeroPedido)

   End Function
   Public Function GetCanalesYRubros(ByVal fechaDesde As DateTime,
                                       ByVal fechaHasta As DateTime,
                                       ByVal productos As List(Of Eniac.Entidades.Producto)) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
         Return sql.GetCanalesYRubros(fechaDesde, fechaHasta, productos)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCajonesHectolitros(ByVal fechaDesde As DateTime,
                                          ByVal fechaHasta As DateTime,
                                          ByVal productos As List(Of Eniac.Entidades.Producto),
                                          ByVal localidades As List(Of Eniac.Entidades.Localidad),
                                          ByVal tiposComprobantes As List(Of Eniac.Entidades.TipoComprobante),
                                          ByVal IdVendedor As Integer,
                                          ByVal idTransportista As Integer,
                                          ByVal idTipoCliente As Integer,
                                          ByVal muestraImportes As Boolean) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
         Return sql.GetCajonesHectolitros(fechaDesde, fechaHasta, productos,
                                          localidades, tiposComprobantes, IdVendedor,
                                          idTransportista, idTipoCliente, muestraImportes)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   'Public Sub ActualizarPedidoPorReenvio(ByVal filtro As String, ByVal NumeroReparto As Integer)
   '   ActualizarPedidoPorReenvio(filtro, NumeroReparto, Nothing, Nothing)
   'End Sub
   Public Sub ActualizarPedidoPorReenvio(ByVal filtro As String, ByVal NumeroReparto As Integer?, idTransportista As Integer?, fechaReparto As DateTime?)
      Try
         Me.da.OpenConection()
         _ActualizarPedidoPorReenvio(filtro, NumeroReparto, idTransportista, fechaReparto)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Public Sub _ActualizarPedidoPorReenvio(ByVal filtro As String, ByVal NumeroReparto As Integer?, idTransportista As Integer?, fechaReparto As DateTime?)
      _ActualizarPedidoPorReenvio(filtro, NumeroReparto, idTransportista, fechaReparto, False, True)
   End Sub

   Public Sub _ActualizarPedidoPorReenvio(ByVal filtro As String, ByVal NumeroReparto As Integer?, idTransportista As Integer?, fechaReparto As DateTime?, MercDespachada As Boolean?, esReenvio As Boolean)
      Dim sqlVentas As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
      sqlVentas.ActualizarNumeroReparto(filtro, NumeroReparto, idTransportista, fechaReparto, MercDespachada, esReenvio)
   End Sub

   Public Sub actualizarFRendicion(filtro As String, fecha As DateTime)
      Try
         Me.da.OpenConection()
         Dim sqlVentas As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
         sqlVentas.actualizarFRendicion(filtro, fecha)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub
   Public Sub ActualizoEstadoFactura(ByVal filtro As String, ByVal estado As String)
      'ByVal IdSucursal As Integer, ByVal IdTipoComprobante As String, _
      'ByVal LetraComprobante As String, ByVal CentroEmisor As Short, _
      'ByVal NumeroComprobante As Long,
      Try
         Me.da.OpenConection()
         Dim sqlVentas As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
         sqlVentas.ActualizoEstadoFactura(filtro, estado)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try


   End Sub

#End Region

#Region "Overrides"

#End Region

#Region "Metodos"

   Public Sub GenerarFacturas(ByVal facturasNuevas As List(Of Eniac.Entidades.Venta), facturasReenvio As List(Of Eniac.Entidades.Venta),
                              MetodoGrabacion As Eniac.Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim oVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(Me.da)
         Dim sqlVentas As SqlServer.Ventas = New SqlServer.Ventas(Me.da)

         For Each factura As Eniac.Entidades.Venta In facturasNuevas
            'factura.IdCaja = 1
            factura.MercDespachada = True
            oVentas.Inserta(factura, MetodoGrabacion, IdFuncion)

            'If factura.Facturables IsNot Nothing Then
            For Each vv In factura.Invocados
               Dim pedido = vv.Invocado
               Dim stb As StringBuilder = New StringBuilder()
               stb.AppendFormat("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                pedido.IdSucursal, pedido.IdTipoComprobante, pedido.Letra, pedido.CentroEmisor, pedido.NumeroComprobante)
               sqlVentas.ActualizarNumeroReparto(stb.ToString(), factura.NumeroReparto, factura.Transportista.idTransportista, factura.FechaEnvio, factura.MercDespachada, False)
            Next
            'End If
         Next

         For Each factura As Eniac.Entidades.Venta In facturasReenvio
            Dim stb As StringBuilder = New StringBuilder()
            stb.AppendFormat("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                             factura.IdSucursal, factura.IdTipoComprobante, factura.LetraComprobante, factura.CentroEmisor, factura.NumeroComprobante)
            sqlVentas.ActualizarNumeroReparto(stb.ToString(), factura.NumeroReparto, factura.Transportista.idTransportista, factura.FechaEnvio, True, False)
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Public Function GetProximoNumeroReparto() As Integer
      Return New SqlServer.Ventas(Me.da).GetProximoNumeroReparto()
   End Function

   Public Function GrabarComprobanteAutomaticoConCAE(
                        idSucursal As Integer,
                        idTipoComprobante As String,
                        cliente As Eniac.Entidades.Cliente,
                        fecha As Date,
                        idVendedor As Integer,
                        idFormasPago As Integer,
                        observacion As String,
                        itemsProductos As List(Of Eniac.Entidades.VentaProducto),
                        transportista As Eniac.Entidades.Transportista,
                        fenvio As Date,
                        idCaja As Integer,
                        nroReparto As Integer,
                        mercDespachada As Boolean,
                        comprobantesAsociados As IEnumerable(Of Entidades.Venta),
                        metodoGrabacion As Eniac.Entidades.Entidad.MetodoGrabacion, IdFuncion As String) As Eniac.Entidades.Venta
      Dim redondeoEnCalculo As Integer = Publicos.Facturacion.Redondeo.FacturacionDecimalesRedondeoEnPrecio

      Dim venta As Eniac.Entidades.Venta
      Dim tipoComprobante As Eniac.Entidades.TipoComprobante = New Eniac.Reglas.TiposComprobantes().GetUno(idTipoComprobante)
      Dim rVenta As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)

      Try
         da.OpenConection()

         venta = rVenta.CreaVenta(actual.Sucursal.Id, tipoComprobante, "", 0, Nothing,
                                  cliente, cliente.CategoriaFiscal, fecha,
                                  New Eniac.Reglas.Empleados().GetUno(idVendedor),
                                  transportista,
                                  New Eniac.Reglas.VentasFormasPago().GetUna(idFormasPago), Nothing,
                                  idCaja, Nothing, mercDespachada, nroReparto, fenvio, Nothing, observacion,
                                  cliente.Cobrador, clienteVinculado:=Nothing, nroOrdenCompra:=0)

         Dim _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal = New Eniac.Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)

         Dim cache As BusquedasCacheadas = New BusquedasCacheadas()

         For Each vp As VentaProducto In itemsProductos
            If vp.Cantidad <> 0 Then

               If (Not cliente.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado) And
                  cliente.CategoriaFiscal.UtilizaImpuestos And _categoriaFiscalEmpresa.UtilizaImpuestos Then
                  vp.Precio = Eniac.Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(vp.Precio, vp.Producto.Alicuota,
                                                                                         vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno,
                                                                                         vp.Producto.OrigenPorcImpInt)
                  'Else
                  '   vp.Precio = Eniac.Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(vp.Precio, vp.Producto.Alicuota,
                  '                                                                          vp.Producto.PorcImpuestoInterno, vp.Producto.ImporteImpuestoInterno,
                  '                                                                          vp.Producto.OrigenPorcImpInt)
               End If

               rVenta.AgregarVentaProducto(venta,
                                    rVenta.CreaVentaProducto(vp.Producto, vp.Producto.NombreProducto,
                                                      vp.DescuentoRecargoPorc1, vp.DescuentoRecargoPorc2,
                                                      vp.Precio, vp.Cantidad,
                                                      vp.TipoImpuesto, vp.AlicuotaImpuesto,
                                                      cache.BuscaListaDePrecios(vp.IdListaPrecios), vp.FechaEntrega,
                                                      vp.TipoOperacion, vp.Nota,
                                                      vp.IdEstadoVenta,
                                                      venta, redondeoEnCalculo),
                                    redondeoEnCalculo)
               'Cargo los Comprobantes Facturados (tal vez ninguno)
            End If
         Next

         venta.Invocados.Add(comprobantesAsociados)
         'For Each asoc In comprobantesAsociados
         '   venta.Facturables.Add(asoc)
         'Next

      Finally
         da.CloseConection()
      End Try

      venta.FechaRendicion = Now

      rVenta.Insertar(venta, metodoGrabacion, IdFuncion)

      Dim blnConexionAbierta As Boolean = Me.da.Connection IsNot Nothing AndAlso Me.da.Connection.State = ConnectionState.Open

      Dim ComprobanteAnt As Eniac.Entidades.Venta = New Eniac.Entidades.Venta

      With ComprobanteAnt
         .IdSucursal = venta.IdSucursal
         .TipoComprobante = venta.TipoComprobante
         .LetraComprobante = venta.LetraComprobante
         .CentroEmisor = venta.CentroEmisor
         .NumeroComprobante = venta.NumeroComprobante
      End With


      Try
         If Not blnConexionAbierta Then
            Me.da.OpenConection()
            Me.da.BeginTransaction()
         End If


         If venta IsNot Nothing AndAlso venta.TipoComprobante.EsPreElectronico Then
            '(Boolean.Parse(New Eniac.Reglas.Parametros(Me.da)._GetValor(Eniac.Entidades.Parametro.Parametros.FACTELECTSINCRONICA)) And _
            ' comprobante.TipoComprobante.EsPreElectronico) Then

            Dim eniacVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)

            venta = eniacVentas.GetUna(venta.IdSucursal,
                           venta.TipoComprobante.IdTipoComprobante,
                           venta.LetraComprobante,
                           venta.CentroEmisor,
                           venta.NumeroComprobante)

            If Not Publicos.HayInternet() Then
               Throw New Exception("No tiene internet para realizar esta acción.")
               Exit Function
            End If

            'Actualizo la Fecha de Transmision al AFIP porque Si tiene la Fecha.. no podra anularlo.

            Dim sql As Eniac.SqlServer.Ventas = New Eniac.SqlServer.Ventas(Me.da)
            sql.U_FechaTransmisionAFIP(venta.IdSucursal, venta.TipoComprobante.IdTipoComprobante,
                                                venta.LetraComprobante, venta.Impresora.CentroEmisor,
                                                venta.NumeroComprobante, Date.Now)

            venta.Usuario = actual.Nombre
            venta.IdCaja = idCaja ' Integer.Parse(New Eniac.Reglas.CajasNombres().GetAll().Rows(0)("IdCaja").ToString())

            eniacVentas.ActualizaCAE(venta, AFIPCAE.Secuencia.PrimeraVez,
                                     Eniac.Entidades.Entidad.MetodoGrabacion.Automatico, IdFuncion)

            venta = eniacVentas.GetUna(venta.IdSucursal,
                           venta.TipoComprobante.IdTipoComprobante,
                           venta.LetraComprobante,
                           venta.CentroEmisor,
                           venta.NumeroComprobante)

         End If

         If nroReparto > 0 Then
            Dim rRepComp As RepartosComprobantes = New RepartosComprobantes(da)

            Dim orden As Integer = rRepComp.GetAll(actual.Sucursal.Id, nroReparto).Rows.Count
            Dim eRepComp As Entidades.RepartoComprobante = New Entidades.RepartoComprobante()

            eRepComp.IdSucursal = actual.Sucursal.Id
            eRepComp.IdReparto = nroReparto
            eRepComp.Orden = orden + 1
            eRepComp.Venta = venta

            rRepComp.Inserta(eRepComp)
         End If
         If Not blnConexionAbierta Then Me.da.CommitTransaction()

      Catch ex As Exception
         Dim erro As Eniac.Entidades.EniacException = New Eniac.Entidades.EniacException(ex.Message)
         If ComprobanteAnt IsNot Nothing Then
            With ComprobanteAnt
               venta.IdSucursal = ComprobanteAnt.IdSucursal
               venta.TipoComprobante = ComprobanteAnt.TipoComprobante
               venta.LetraComprobante = ComprobanteAnt.LetraComprobante
               venta.CentroEmisor = ComprobanteAnt.CentroEmisor
               venta.NumeroComprobante = ComprobanteAnt.NumeroComprobante
            End With
         End If

         If Not blnConexionAbierta Then da.RollbakTransaction()
         Throw New Eniac.Reglas.Ventas.ActualizaCAEException(ex, venta)
      Finally
         If Not blnConexionAbierta Then da.CloseConection()
      End Try


      Return venta
   End Function

   Public Function GrabarComprobanteAutomatico(ByVal IdSucursal As Integer,
                                             ByVal IdTipoComprobante As String,
                                             ByVal IdCliente As Long,
                                             ByVal Fecha As Date,
                                             ByVal Vendedor As Empleado,
                                             ByVal IdFormasPago As Integer,
                                             ByVal Observacion As String,
                                             ByVal NumeroCuota As Integer,
                                             ByVal ItemsProductos As List(Of Eniac.Entidades.VentaProducto),
                                             ByVal ObservacionDetalladas As List(Of Eniac.Entidades.VentaObservacion),
                                             ByVal transportista As Eniac.Entidades.Transportista,
                                             ByVal fenvio As Date,
                                             MetodoGrabacion As Eniac.Entidades.Entidad.MetodoGrabacion, IdFuncion As String,
                                             Optional ByVal IdCaja As Integer = 0,
                                             Optional ByVal NumeroPedido As Long = 0) As Eniac.Entidades.Venta

      Dim _subTotales As System.Collections.Generic.List(Of Eniac.Entidades.VentaImpuesto)
      Dim _publicos As Publicos
      Dim _clienteE As Entidades.Cliente
      Dim _clienteEniac As Eniac.Entidades.Cliente
      Dim _tipoImpuestoIVA As Eniac.Entidades.TipoImpuesto.Tipos = Eniac.Entidades.TipoImpuesto.Tipos.IVA
      Dim _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal

      ''Dim IdCaja As Integer = Integer.Parse(New Eniac.Reglas.CajasNombres().GetAll().Rows(0)("IdCaja").ToString())
      If IdCaja = 0 Then
         IdCaja = Integer.Parse(New Eniac.Reglas.CajasNombres().GetAll().Rows(0)("IdCaja").ToString())
      End If

      Dim _decimalesRedondeoEnPrecio As Integer = Integer.Parse(New Eniac.Reglas.Parametros().GetValorPD(Eniac.Entidades.Parametro.Parametros.FACTURACIONDECIMALESREDONDEOENPRECIO.ToString(), "2"))

      'Dim blnTransaccionActiva As Boolean = Me.da.Transaction Is Nothing
      Dim blnConexionAbierta As Boolean = Me.da.Connection IsNot Nothing AndAlso Me.da.Connection.State = ConnectionState.Open

      Try

         If Not blnConexionAbierta Then
            Me.da.OpenConection()
            Me.da.BeginTransaction()
         End If

         _publicos = New Publicos()

         _subTotales = New System.Collections.Generic.List(Of Eniac.Entidades.VentaImpuesto)

         _categoriaFiscalEmpresa = New Eniac.Reglas.CategoriasFiscales(Me.da)._GetUno(Publicos.CategoriaFiscalEmpresa)
         _clienteE = New Reglas.Clientes().GetUno(IdCliente)
         _clienteEniac = New Eniac.Reglas.Clientes(da)._GetUno(_clienteE.IdCliente)

         '*****  GENERO EL PRODUCTO, LOS IMPUESTOS y OTROS ****

         Dim oLineaImpuestos As Eniac.Entidades.VentaImpuesto = New Eniac.Entidades.VentaImpuesto()

         Dim Kilos As Decimal = 0
         Dim KilosProd As Decimal = 0

         Dim importeBruto As Decimal = 0
         Dim importeNeto As Decimal = 0
         Dim importeIva As Decimal = 0
         Dim importeTotal As Decimal = 0

         Dim precioCosto As Decimal = 0
         Dim precioLista As Decimal = 0
         Dim alicuotaIVA As Decimal = 0
         Dim alicuotaIVASobre100 As Decimal = 0

         Dim IdMoneda As Integer = 0

         Dim PrecioVentaSinIVA As Decimal = 0
         Dim PrecioVentaConIVA As Decimal = 0
         Dim precioProducto As Decimal = 0

         Dim importeCostoProducto As Decimal = 0
         Dim importeBrutoProducto As Decimal = 0
         Dim importeNetoProducto As Decimal = 0
         Dim importeIvaProducto As Decimal = 0

         Dim utilidad As Decimal = 0

         Dim descRecPorGeneral As Decimal = 0

         Dim precioNeto As Decimal = 0

         Dim entro As Boolean

         Dim oFacturacion As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)
         Dim tipoComprobante As TipoComprobante = New Eniac.Reglas.TiposComprobantes().GetUno(IdTipoComprobante)

         Dim formaPago As Entidades.VentaFormaPago = New Eniac.Reglas.VentasFormasPago(da).GetUna(IdFormasPago) 'Cuenta Corriente

         Dim calculosDescuentosRecargos = New CalculosDescuentosRecargos(_cache)

         descRecPorGeneral = calculosDescuentosRecargos.DescuentoRecargo(_clienteEniac, tipoComprobante.GrabaLibro, tipoComprobante.EsPreElectronico,
                                                                         formaPago, ItemsProductos.Count)

         For Each vp As Eniac.Entidades.VentaProducto In ItemsProductos

            alicuotaIVA = vp.Producto.Alicuota
            IdMoneda = vp.Producto.Moneda.IdMoneda

            If Publicos.PreciosConIVA Then
               'Le quito el IVA que el producto tiene en forma predeterminada.
               precioCosto = Decimal.Round(vp.Costo / (1 + alicuotaIVA / 100), 2)
               'Supuestamente viene sin IVa, NO deberia tomarse el trabajo ahi.
               'precioLista = Decimal.Round(precioLista / (1 + alicuotaIVA / 100), Me._decimalesRedondeoEnPrecio)
            Else
               precioCosto = vp.Costo
            End If

            'If IdMoneda = 2 Then
            '   precioCosto = Decimal.Round(precioCosto * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
            '   precioLista = Decimal.Round(precioLista * Decimal.Parse(Me.txtCotizacionDolar.Text), 2)
            'End If
            If tipoComprobante.CoeficienteValores < 0 Then
               'If Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
               '   PrecioVentaSinIVA = Decimal.Round(vp.Precio / (1 + alicuotaIVA / 100), 2)
               '   PrecioVentaConIVA = vp.Precio
               'Else
               PrecioVentaSinIVA = vp.Precio
               PrecioVentaConIVA = Decimal.Round(vp.Precio * (1 + alicuotaIVA / 100), 2)
               'End If
            Else
               PrecioVentaSinIVA = vp.PrecioLista
               PrecioVentaConIVA = Decimal.Round(vp.PrecioLista * (1 + alicuotaIVA / 100), 2)
            End If

            KilosProd = 0
            If vp.Producto.Kilos <> 0 Then
               KilosProd = Decimal.Round(vp.Producto.Kilos * vp.Cantidad, 3)
               Kilos += KilosProd
            End If

            Dim descRecr = calculosDescuentosRecargos.DescuentoRecargo(_clienteEniac, vp.Producto.IdProducto, vp.Cantidad, decimalesRedondeoEnPrecio:=2)

            ''Dim descuentoRecargo As Decimal
            If (_clienteE.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
               Not _clienteE.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Then
               precioProducto = PrecioVentaSinIVA
               'descuentoRecargo = vp.DescuentoRecargo
            Else
               'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
               precioProducto = PrecioVentaConIVA
               'descuentoRecargo = Decimal.Round(vp.DescuentoRecargo * (1 + alicuotaIVA / 100), 2)
            End If

            Dim DescRec1 As Decimal = precioProducto * descRecr.DescuentoRecargo1 / 100
            Dim DescRec2 As Decimal = (precioProducto + DescRec1) * descRecr.DescuentoRecargo2 / 100
            Dim descRec As Decimal = Decimal.Round((precioProducto + DescRec1 + DescRec2) * descRecPorGeneral / 100, 2)

            alicuotaIVASobre100 = (alicuotaIVA / 100)

            precioNeto = precioProducto + DescRec1 + DescRec2 + descRec
            ''precioNeto = Math.Round(precioProducto + (descuentoRecargo / vp.Cantidad), 4)

            'If Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
            '   importeIvaProducto = Decimal.Round(precioNeto - precioNeto / (1 + alicuotaIVASobre100), 2)
            'Else
            '   importeIvaProducto = Decimal.Round(precioNeto * alicuotaIVASobre100, 2)
            'End If

            If Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado Then
               importeIvaProducto = Decimal.Round((precioNeto * vp.Cantidad) - (precioNeto * vp.Cantidad) / (1 + alicuotaIVASobre100), _decimalesRedondeoEnPrecio)
            Else
               importeIvaProducto = Decimal.Round((precioNeto * vp.Cantidad) * alicuotaIVASobre100, _decimalesRedondeoEnPrecio)
            End If

            With vp

               .IdSucursal = actual.Sucursal.Id
               .Usuario = actual.Nombre
               '.Producto = Producto
               .DescuentoRecargoPorc1 = descRecr.DescuentoRecargo1  '' vp.DescuentoRecargoPorc1
               .DescuentoRecargoPorc2 = descRecr.DescuentoRecargo2 '' vp.DescuentoRecargoPorc2
               .DescuentoRecargo = Decimal.Round((DescRec1 + DescRec2) * vp.Cantidad, 2) '' descuentoRecargo
               .DescuentoRecargoProducto = .DescuentoRecargo / vp.Cantidad

               .PrecioLista = precioProducto
               .Precio = precioProducto '+ (.DescuentoRecargo / vp.Cantidad)
               '.Cantidad = cantidad
               .Stock = 0
               .Costo = precioCosto
               '.PrecioLista = precioProducto   'Lo Dejo sin IVA como viene.
               '.Precio = precioProducto
               .Kilos = KilosProd
               .PrecioNeto = precioNeto
               .AlicuotaImpuesto = alicuotaIVA
               .ImporteImpuesto = importeIvaProducto ''* vp.Cantidad
               .TipoImpuesto = New Eniac.Reglas.TiposImpuestos().GetUno(_tipoImpuestoIVA)
               .ComisionVendedorPorc = 0
               .ComisionVendedor = 0
               .ImporteTotal = (.Precio + .DescuentoRecargoProducto) * vp.Cantidad
               .NombreListaPrecios = String.Empty

               .DescRecGeneral = Decimal.Round((.ImporteTotal * descRecPorGeneral / 100), _decimalesRedondeoEnPrecio)
            End With

            'Ahora multiplico todo por Cantidades
            importeCostoProducto = precioCosto * vp.Cantidad
            importeBrutoProducto = (vp.Precio * vp.Cantidad) + (vp.DescuentoRecargo)
            importeNetoProducto = precioNeto * vp.Cantidad
            ''importeIvaProducto = importeIvaProducto * vp.Cantidad
            '----------------------------------------

            'SI el CLIENTE es CF/MO o el Emisor; el monto llega CON IVA, hay que sacarselo.
            If (Not _clienteE.CategoriaFiscal.IvaDiscriminado Or Not _categoriaFiscalEmpresa.IvaDiscriminado) Then
               importeBrutoProducto = Decimal.Round(importeBrutoProducto / (1 + alicuotaIVA / 100), _decimalesRedondeoEnPrecio)
               importeNetoProducto = Decimal.Round(importeNetoProducto / (1 + alicuotaIVA / 100), _decimalesRedondeoEnPrecio)
            End If

            utilidad += (importeNetoProducto - importeCostoProducto)


            entro = False
            For Each vi As Eniac.Entidades.VentaImpuesto In _subTotales
               If vi.Alicuota = vp.AlicuotaImpuesto Then
                  vi.TipoImpuesto.IdTipoImpuesto = vp.TipoImpuesto.IdTipoImpuesto
                  vi.Bruto += importeBrutoProducto
                  vi.Neto += importeNetoProducto
                  vi.Importe += importeIvaProducto
                  vi.Total += (importeNetoProducto + importeIvaProducto)
                  entro = True
               End If
            Next

            If Not entro Then
               oLineaImpuestos = New Eniac.Entidades.VentaImpuesto()

               With oLineaImpuestos
                  .TipoImpuesto = New Eniac.Reglas.TiposImpuestos().GetUno(_tipoImpuestoIVA)
                  .Alicuota = alicuotaIVA
                  .Bruto = importeBrutoProducto
                  .Neto = importeNetoProducto
                  .Importe = importeIvaProducto
                  .Total = (.Neto + .Importe)
               End With

               _subTotales.Add(oLineaImpuestos)
            End If

            importeBruto += importeBrutoProducto
            importeNeto += importeNetoProducto
            importeIva += importeIvaProducto
            importeTotal += (importeNetoProducto + importeIvaProducto)

         Next


         'Me.CalcularTotales()
         'Me.CalcularDatosDetalle()

         '---------------------------------------------------------------

         Dim Comprobante As Eniac.Entidades.Venta = New Eniac.Entidades.Venta()

         With Comprobante

            'cargo el comprobante
            .TipoComprobante = tipoComprobante

            'cargo el cliente ----------
            .Cliente = _clienteEniac ''_clienteE.GetEntidadClienteDelSiGA()
            .Direccion = .Cliente.Direccion
            .IdLocalidad = .Cliente.IdLocalidad

            'cargo la Categoria Fiscal (porque puede necesitar cambiarse para una operatoria puntual.
            .CategoriaFiscal = .Cliente.CategoriaFiscal

            .IdCategoria = .Cliente.IdCategoria

            'Si es X es Cotizacion, Dev-Cotizacion, etc, siempre debe tener esa letra, sino dejo la del Cliente.
            If .TipoComprobante.LetrasHabilitadas = "X" Then
               .LetraComprobante = "X"
            Else
               .LetraComprobante = .CategoriaFiscal.LetraFiscal
            End If

            'cargo datos generales del comprobante
            .IdSucursal = IdSucursal
            .Usuario = actual.Nombre

            'cargo la impresora
            .Impresora = New Eniac.Reglas.Impresoras().GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, .TipoComprobante.IdTipoComprobante)
            .CentroEmisor = .Impresora.CentroEmisor

            'If NumeroPedido = 0 Then
            '   .NumeroComprobante = New Eniac.Reglas.VentasNumeros(da).GetProximoNumero(.IdSucursal, .TipoComprobante.IdTipoComprobante, .LetraComprobante, .CentroEmisor)
            'Else
            '   .NumeroComprobante = NumeroPedido
            'End If

            .NumeroLote = NumeroPedido
            .Fecha = Fecha

            .Vendedor = New Eniac.Reglas.Empleados().GetUno(Vendedor.IdEmpleado)

            .FormaPago = formaPago

            .Observacion = Observacion.Truncar(100) ' "Generado Automatico"

            .VentasImpuestos = _subTotales
            .ImpuestosVarios = Nothing '_ImpuestosVarios
            ' = 0  'Me._baseImponibleIIBB

            'cargo valores del comprobante
            .ImporteBruto = importeBruto
            .DescuentoRecargo = importeNeto - importeBruto
            .DescuentoRecargoPorc = descRecPorGeneral
            .Subtotal = importeNeto
            .TotalImpuestos = importeIva
            .ImporteTotal = importeTotal

            .Kilos = Kilos

            'cargo los productos
            .VentasProductos = ItemsProductos

            ''Cargo los Comprobantes Facturados (tal vez ninguno)
            '.Facturables = Nothing 'Me._comprobantesSeleccionados

            'Al marcar que llamo a otro/s no permito que lo elijan y hagan un ciclo. A menos que Sea un PRESUPUESTO !
            'If Me._comprobantesSeleccionados IsNot Nothing AndAlso Me._comprobantesSeleccionados.Count > 0 AndAlso .TipoComprobante.CoeficienteStock <> 0 Then
            '   .IdEstadoComprobante = "INVOCO"
            '   .CantidadInvocados = Me._comprobantesSeleccionados.Count
            'Else
            '.CantidadInvocados = 0
            'End If

            'cargo el Remito Transportista
            .Bultos = 0
            .ValorDeclarado = 0
            .Transportista = transportista   ' Me._transportistaA

            .FechaEnvio = fenvio


            'cargo las Observaciones
            .VentasObservaciones = ObservacionDetalladas

            'If ObservacionDetalladas.Count > 0 Then

            '   Dim Cont As Integer

            '   'Tengo que asignar el numero de comprobante porque se genera a ultima momento.
            '   For Cont = 0 To ObservacionDetalladas.Count - 1
            '      ObservacionDetalladas(Cont).IdSucursal = .IdSucursal
            '      ObservacionDetalladas(Cont).IdTipoComprobante = .IdTipoComprobante
            '      ObservacionDetalladas(Cont).Letra = .LetraComprobante
            '      ObservacionDetalladas(Cont).CentroEmisor = .CentroEmisor
            '      ObservacionDetalladas(Cont).NumeroComprobante = .NumeroComprobante
            '   Next

            'End If

            'carga los importes de pagos y cheques
            .Cheques = Nothing   'Me._cheques
            .Tarjetas = Nothing   'Me._tarjetas

            'Dejo en cero porque se pisa con la funcionalidad de CuentaCorriente Parcial.
            .ImportePesos = 0             '.ImporteTotal
            '--------------------------------------------------------------
            '.ImporteTarjetas = 0 READ-ONLY
            .ImporteTickets = 0

            'If Decimal.Parse(Me.txtTransferenciaBancaria.Text) > 0 And Me.bscCuentaBancariaTransfBanc.Selecciono Then
            '   .ImporteTransfBancaria = Decimal.Parse(Me.txtTransferenciaBancaria.Text)
            '   .CuentaBancariaTransfBanc = New Reglas.CuentasBancarias().GetUna(Integer.Parse(Me.bscCuentaBancariaTransfBanc._filaDevuelta.Cells("IdCuentaBancaria").Value.ToString()))
            'End If

            'carga los cheques rechazados
            .ChequesRechazados = Nothing  'Me._chequesRechazados

            'Informe los Productos que tuvieron Lotes.
            .CantidadLotes = 0   'Me.ProductosConLote()    ---- Luego le cargo el correcto segun la seleccion de lotes.

            'cargo los Lotes
            .VentasProductosLotes = Nothing 'Me._productosLotes

            'Cargo la utilidad
            .Utilidad = utilidad

            .CotizacionDolar = 0

            .ComisionVendedor = 0

            .MercDespachada = False

            'grabo la caja
            .IdCaja = IdCaja

            'If Me.cmbActividades.SelectedIndex <> -1 Then
            '   .IdActividad = Integer.Parse(Me.cmbActividades.SelectedValue.ToString())
            '   .IdProvincia = DirectCast(Me.cmbActividades.SelectedItem, DataRowView)("IdProvincia").ToString()
            'End If

            'If Me.bscCodigoProveedor.Selecciono() Or Me.bscProveedor.Selecciono() Then
            '   .Proveedor = New Reglas.Proveedores()._GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))
            'End If

            .ReemplazaComprobante = False

         End With

         'Si el tipo de pago es cuenta corriente tengo que levantar la pantalla de Cuenta Corriente
         If Comprobante.TipoComprobante.ActualizaCtaCte Then

            If Comprobante.FormaPago.Dias > 0 Then
               'si el cliente compro el modulo de cuenta corriente
               If Publicos.TieneModuloCuentaCorrienteClientes Then

                  Dim oCCP As Eniac.Entidades.CuentaCorrientePago
                  oCCP = New Eniac.Entidades.CuentaCorrientePago()
                  oCCP.ImporteCuota = Comprobante.ImporteTotal
                  oCCP.SaldoCuota = oCCP.ImporteCuota
                  oCCP.FechaVencimiento = Comprobante.Fecha.AddDays(Comprobante.FormaPago.Dias)
                  oCCP.Cuota = NumeroCuota

                  Comprobante.CuentaCorriente.Pagos.Add(oCCP)
               End If

            End If

         End If

         ''si voy a imprimir en una impresora fiscal, primero imprimo y despues obtengo el nro. de comprobante
         ''en otro caso, grabo y despues imprimo
         'If oVentas.TipoComprobante.EsFiscal Then
         '   If Me.ImprimirComprobante(oVentas) Then
         '      oVentas.NumeroComprobante = Me._numeroComprobante
         '      oFacturacion.Insertar(oVentas)
         '      MessageBox.Show(oVentas.TipoComprobante.Descripcion & " Nro. " & oVentas.NumeroComprobante.ToString() & Convert.ToChar(Keys.Enter) & " de " & Me.bscCliente.Text & Convert.ToChar(Keys.Enter) & " fue impreso y grabado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '      If Not String.IsNullOrEmpty(oVentas.TipoComprobante.IdTipoComprobanteSecundario) Then
         '         If MessageBox.Show("¿Desea Cargar Automaticamente el Comprobante Secundario '" & oVentas.TipoComprobante.IdTipoComprobanteSecundario & "'?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         '            'Me.tsbGrabar.Enabled = True
         '            Me.NuevoSecundario(oVentas)
         '            Exit Sub
         '         End If
         '      End If
         '      Me.Nuevo()
         '   End If
         'Else

         'Me.Insertar(Comprobante)
         oFacturacion.Inserta(Comprobante, MetodoGrabacion, IdFuncion)

         '   Dim msg As System.Text.StringBuilder = New System.Text.StringBuilder()
         '   msg.AppendFormat("{0} Nro. {1}", oVentas.TipoComprobante.Descripcion, oVentas.NumeroComprobante.ToString()).AppendLine()
         '   msg.AppendFormat("de {0}", Me.bscCliente.Text).AppendLine()

         '   If oVentas.TipoComprobante.EsElectronico Then
         '      If Not String.IsNullOrEmpty(oVentas.AFIPCAE.CAE) Then
         '         msg.AppendFormat("CAE {0} con vencimiento {1} ", oVentas.AFIPCAE.CAE, oVentas.AFIPCAE.CAEVencimiento.ToString("dd/MM/yyyy")).AppendLine()
         '      End If
         '   End If

         '   'verifica si el tipo de comprobante se puede imprimir, sino no hace nada
         '   If Me.ImprimeComprobante() Then
         '      If Me.ImprimirComprobante(oVentas) Then
         '         msg.AppendFormat(" fue impreso y grabado.")
         '      Else
         '         msg.AppendFormat(" fue grabado.")
         '      End If
         '   Else
         '      msg.AppendFormat(" fue grabado.")
         '   End If

         '   MessageBox.Show(msg.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         '   If Not String.IsNullOrEmpty(oVentas.TipoComprobante.IdTipoComprobanteSecundario) Then
         '      If MessageBox.Show("¿Desea Cargar Automaticamente el Comprobante Secundario '" & oVentas.TipoComprobante.IdTipoComprobanteSecundario & "'?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         '         Me.NuevoSecundario(oVentas)
         '         Exit Sub
         '      End If
         '   End If
         '   Me.Nuevo()
         'End If

         ''Lo asigno completo para que tenga valor en el procedimiento que lo llamo.
         'Dim cb As Entidades.Venta = Me.GetUna(Comprobante.IdSucursal, _
         '                                       Comprobante.TipoComprobante.IdTipoComprobante, _
         '                                       Comprobante.LetraComprobante, _
         '                                       Comprobante.CentroEmisor, _
         '                                       Comprobante.NumeroComprobante)


         'Hago la devolucion liviana, por ahora no necesito todo el objeto.
         Dim cb As Eniac.Entidades.Venta = New Eniac.Entidades.Venta()
         With cb
            .IdSucursal = Comprobante.IdSucursal
            .TipoComprobante = Comprobante.TipoComprobante
            .LetraComprobante = Comprobante.LetraComprobante
            .CentroEmisor = Comprobante.CentroEmisor
            .NumeroComprobante = Comprobante.NumeroComprobante

            'Otros datos que se utilizan
            .Fecha = Fecha
            .FormaPago = New Eniac.Reglas.VentasFormasPago().GetUna(IdFormasPago)
            .ImporteTotal = importeTotal
         End With

         If Not blnConexionAbierta Then
            Me.da.CommitTransaction()
         End If

         Return cb

      Catch ex As Exception
         If Not blnConexionAbierta Then
            Me.da.RollbakTransaction()
         End If
         Throw ex
      Finally
         If Not blnConexionAbierta Then
            Me.da.CloseConection()
         End If
      End Try

   End Function

#End Region

   Public Function Copiar(venta As Eniac.Entidades.Venta) As Eniac.Entidades.Venta
      Dim clone As Eniac.Entidades.Venta
      clone = Me.Clone(venta, New Eniac.Entidades.Venta())
      Return clone
   End Function

   Public Function Copiar(ventaProducto As Eniac.Entidades.VentaProducto) As Eniac.Entidades.VentaProducto
      Return Me.Clone(ventaProducto, New Eniac.Entidades.VentaProducto())
   End Function

   Public Function Clonar(Of T)(source As T) As T
      Using strm As MemoryStream = New MemoryStream()
         Dim serializer As XmlSerializer = New XmlSerializer(source.GetType())
         serializer.Serialize(strm, source)
         strm.Position = 0
         Dim serializer2 As XmlSerializer = New XmlSerializer(source.GetType())
         Return DirectCast(serializer2.Deserialize(strm), T)
      End Using
   End Function

   Private Function Clone(Of T)(ByVal source As T, ByRef target As T) As T
      For Each p As System.Reflection.PropertyInfo In source.GetType().GetProperties()
         If p.CanRead And p.CanWrite Then
            target.GetType().GetProperty(p.Name).SetValue(target, p.GetValue(source, Nothing), Nothing)
         End If
      Next
      Return target
   End Function

   Public Function Dividir(origen As Eniac.Entidades.Venta, destinos As List(Of Eniac.Entidades.Venta),
                           MetodoGrabacion As Eniac.Entidades.Entidad.MetodoGrabacion, IdFuncion As String) As List(Of Eniac.Entidades.Venta)
      Dim result As List(Of Eniac.Entidades.Venta) = New List(Of Eniac.Entidades.Venta)()
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim regla As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)
         Dim sql As SqlServer.Ventas = New SqlServer.Ventas(da)
         Dim sqlV As Eniac.SqlServer.Ventas = New Eniac.SqlServer.Ventas(da)
         Dim sqlVP As Eniac.SqlServer.VentasProductos = New Eniac.SqlServer.VentasProductos(da)

         For i As Integer = origen.VentasProductos.Count - 1 To 0 Step -1
            If origen.VentasProductos(i).Cantidad = 0 Then
               origen.VentasProductos.RemoveAt(i)
            End If
         Next
         Dim oorigen As Venta = GrabarComprobanteAutomatico(origen.IdSucursal, origen.IdTipoComprobante, origen.Cliente.IdCliente,
                                     origen.Fecha, origen.Vendedor, origen.FormaPago.IdFormasPago, origen.Observacion, 0, origen.VentasProductos,
                                     origen.VentasObservaciones, origen.Transportista, origen.FechaEnvio,
                                     MetodoGrabacion, IdFuncion)

         result.Add(oorigen)

         For Each destino As Eniac.Entidades.Venta In destinos
            Dim odestino As Venta = GrabarComprobanteAutomatico(destino.IdSucursal, destino.IdTipoComprobante, destino.Cliente.IdCliente,
                                        destino.Fecha, destino.Vendedor, destino.FormaPago.IdFormasPago, destino.Observacion, 0, destino.VentasProductos,
                                        destino.VentasObservaciones, destino.Transportista, destino.FechaEnvio,
                                        MetodoGrabacion, IdFuncion)
            odestino.TipoComprobanteFact = destino.TipoComprobanteFact
            'ModificarTComp(odestino)
            result.Add(odestino)
         Next

         regla.EjecutaSP(origen, Eniac.Reglas.Base.TipoSP._D, Eniac.Entidades.Entidad.MetodoGrabacion.Automatico, "")

         'Throw New Exception("COrte por pruebas")

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
      Return result
   End Function

   Public Function ObtieneCantidadLineas(idTipoComprobante As String, idCliente As Long) As CantidadLineas
      Return ObtieneCantidadLineas(idTipoComprobante, ObtieneLetraDeCliente(idTipoComprobante, idCliente))
   End Function

   Public Function ObtieneCantidadLineas(idTipoComprobante As String, letra As String) As CantidadLineas
      Dim result As CantidadLineas = New CantidadLineas()
      If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
         Dim oComprobanteLetra As Eniac.Entidades.TipoComprobanteLetra
         oComprobanteLetra = New Eniac.Reglas.TiposComprobantesLetras().GetUno(idTipoComprobante, letra)
         If oComprobanteLetra.TipoComprobante.IdTipoComprobante <> "" Then
            'Toma las Lineas del reporte especifico.
            result.CantMaxItems = oComprobanteLetra.CantidadItemsProductos
            result.CantMaxItemsObserv = oComprobanteLetra.CantidadItemsObservaciones
            result.Imprime = oComprobanteLetra.Imprime
         Else
            'Toma las Lineas del Comprobante.
            Dim oTipoComprobante As Eniac.Entidades.TipoComprobante = New Eniac.Reglas.TiposComprobantes().GetUno(idTipoComprobante)
            result.CantMaxItems = oTipoComprobante.CantidadMaximaItems
            result.CantMaxItemsObserv = oTipoComprobante.CantidadMaximaItemsObserv
            result.Imprime = oTipoComprobante.Imprime
         End If
      End If
      Return result
   End Function

   Public Function ObtieneLetraDeCliente(idTipoComprobante As String, idCliente As Long) As String
      If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
         Dim tpComp As Entidades.TipoComprobante = _cache.BuscaTipoComprobante(idTipoComprobante)
         If tpComp.LetrasHabilitadas.Length = 1 Then
            Return tpComp.LetrasHabilitadas
         End If
      End If
      Return _cache.BuscaClienteEntidadPorId(idCliente).CategoriaFiscal.LetraFiscal
   End Function

   Public Sub ValidaCantidadLineas(ByVal idTipoComprobante As String, ByVal idCliente As Long, items As List(Of PedidoProducto))
      ValidaCantidadLineas(idTipoComprobante, ObtieneLetraDeCliente(idTipoComprobante, idCliente), items, New List(Of PedidoObservacion)())
   End Sub

   Public Sub ValidaCantidadLineas(ByVal idTipoComprobante As String, ByVal idCliente As Long, items As List(Of PedidoProducto), obs As List(Of PedidoObservacion))
      ValidaCantidadLineas(idTipoComprobante, ObtieneLetraDeCliente(idTipoComprobante, idCliente), items, obs)
   End Sub

   Public Sub ValidaCantidadLineas(ByVal idTipoComprobante As String, ByVal letra As String, items As List(Of PedidoProducto), obs As List(Of PedidoObservacion))
      Dim cantidadLineas As CantidadLineas = ObtieneCantidadLineas(idTipoComprobante, letra)

      If Not cantidadLineas.Imprime Then Exit Sub

      If obs.Count > cantidadLineas.CantMaxItemsObserv Then
         Throw New Exception(String.Format("No puede ingresar mas de {0} lineas de Observaciones para este tipo de comprobante.", cantidadLineas.CantMaxItemsObserv))
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.
      If items.Count + obs.Count > cantidadLineas.CantMaxItems Then
         Throw New Exception(String.Format("No puede ingresar mas de {0} lineas (Productos y Observaciones)  para este tipo de comprobante.", cantidadLineas.CantMaxItems))
      End If
   End Sub

   Public Sub ValidaCantidadLineas(ByVal idTipoComprobante As String, ByVal idCliente As Long, items As List(Of VentaProducto), obs As List(Of VentaObservacion))
      Dim letra As String = ObtieneLetraDeCliente(idTipoComprobante, idCliente)
      Dim cantidadLineas As CantidadLineas = ObtieneCantidadLineas(idTipoComprobante, letra)

      If Not cantidadLineas.Imprime Then Exit Sub

      If obs.Count > cantidadLineas.CantMaxItemsObserv Then
         Throw New Exception(String.Format("No puede ingresar mas de {0} lineas de Observaciones para este tipo de comprobante.", cantidadLineas.CantMaxItemsObserv))
      End If

      'Sumo Lineas del Comprobante + Lineas de Observaciones.
      If items.Count + obs.Count > cantidadLineas.CantMaxItems Then
         Throw New Exception(String.Format("No puede ingresar mas de {0} lineas (Productos y Observaciones)  para este tipo de comprobante.", cantidadLineas.CantMaxItems))
      End If
   End Sub

End Class
