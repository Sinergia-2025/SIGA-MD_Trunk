#Region "Option/Imports"
Option Explicit On
Option Strict On
Option Infer On

Imports Eniac.Entidades
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
#End Region
Partial Class Ventas

   ''CALCULOS  /  VALIDACIONES

#Region "Percepciones de IIBB"
   Public Function GetMontoPercepcionIIBB(cliente As Entidades.Cliente,
                                       dtActividades As DataTable,
                                       montoNeto As Decimal,
                                       montoTotal As Decimal,
                                       fecha As DateTime) As List(Of Entidades.PercepcionVentaCalculo)
      Dim result As List(Of PercepcionVentaCalculo) = New List(Of PercepcionVentaCalculo)()
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then Me.da.OpenConection()
         For Each drActicidad As DataRow In dtActividades.Rows
            Dim yaCalculado As Boolean = False
            For Each e As Entidades.PercepcionVentaCalculo In result
               If e.IdProvincia = drActicidad("IdProvincia").ToString() Then
                  yaCalculado = True
               End If
            Next
            If yaCalculado Then Continue For
            Dim idProvincia As String = drActicidad("IdProvincia").ToString()
            Dim idActividad As Integer = Integer.Parse(drActicidad("IdActividad").ToString())
            Dim iibb As IPercepcionIIBB = PercepcionesFabrica.GetPercepcion(idProvincia)

            If iibb IsNot Nothing Then
               Dim sqlVe As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
               Dim montoFacturado As Decimal = sqlVe.GetMontoFacturadoPorCliente(cliente.IdCliente, fecha)

               Dim act As Entidades.Actividad = New Reglas.Actividades(Me.da).GetUno(idProvincia, idActividad)

               result.Add(iibb.GetMontoPercepcion(cliente, act, montoNeto, montoTotal, montoFacturado, fecha, Me.da))
            End If
         Next

         Return result
      Catch ex As Exception
         Throw New Exception(ex.Message, ex)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Function
   Public Function GetMontoPercepcionIIBB(cliente As Entidades.Cliente,
                                       idActividad As Integer,
                                       idProvincia As String,
                                       montoNeto As Decimal,
                                       montoTotal As Decimal,
                                       fecha As DateTime) As Entidades.PercepcionVentaCalculo
      Try
         Me.da.OpenConection()

         Dim iibb As IPercepcionIIBB = PercepcionesFabrica.GetPercepcion(idProvincia)

         If iibb IsNot Nothing Then
            Dim sqlVe As SqlServer.Ventas = New SqlServer.Ventas(Me.da)
            Dim montoFacturado As Decimal = sqlVe.GetMontoFacturadoPorCliente(cliente.IdCliente, fecha)

            Dim act As Entidades.Actividad = New Reglas.Actividades(Me.da).GetUno(idProvincia, idActividad)

            Return iibb.GetMontoPercepcion(cliente, act, montoNeto, montoTotal, montoFacturado, fecha, Me.da)
         Else
            Return Nothing
         End If

      Catch ex As Exception
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Function
#End Region

#Region "GetPrecio"
   Public Function GetPrecio(idTipoComprobante As Eniac.Entidades.TipoComprobante,
                             producto As Eniac.Entidades.Producto,
                             listaPrecios As Eniac.Entidades.ListaDePrecios,
                             cliente As Eniac.Entidades.Cliente,
                             cotizacionDolar As Decimal,
                             redondeoEnCalculo As Integer) As PreciosConSinIVA
      '--------------------------------------------------------------------------------------------------------------------------------
      Dim productoSucursal As Eniac.Entidades.ProductoSucursal
      productoSucursal = New Eniac.Reglas.ProductosSucursales(da).GetUno(actual.Sucursal.IdSucursal,
                                                                         producto.IdProducto,
                                                                         listaPrecios.IdListaPrecios)

      Dim precioVentaLista As Decimal = productoSucursal.PrecioVentaLista

      Dim PrecioPorEmbalaje As Boolean = producto.PrecioPorEmbalaje

      Dim PrecioVentaSinIVA As Decimal = 0
      Dim PrecioVentaConIVA As Decimal = 0
      Dim PrecioVentaConIVA2 As Decimal? = Nothing

      If Eniac.Reglas.Publicos.PreciosConIVA Then
         PrecioVentaConIVA = precioVentaLista
         PrecioVentaSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioVentaConIVA, producto.Alicuota, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
         'PrecioVentaConIVA = productoSucursal.GetPrecioVentaDeLista(listaPrecios.IdListaPrecios)
         '(productoSucursal.GetPrecioVentaDeLista(listaPrecios.IdListaPrecios) - producto.ImporteImpuestoInterno) / ((100 + producto.Alicuota) / 100)
      Else
         'PrecioVentaConIVA = (productoSucursal.GetPrecioVentaDeLista(listaPrecios.IdListaPrecios) * (100 + producto.Alicuota) / 100) + producto.ImporteImpuestoInterno
         'PrecioVentaSinIVA = productoSucursal.GetPrecioVentaDeLista(listaPrecios.IdListaPrecios)
         PrecioVentaSinIVA = precioVentaLista
         PrecioVentaConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioVentaSinIVA, producto.Alicuota, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
      End If

      'Sin importar si manejo PreciosConIVA o no, el Precio Con IVA2 es siempre desde PrecioVentaSinIVA agregandole el IVA2
      If producto.Alicuota2.HasValue Then
         PrecioVentaConIVA2 = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioVentaSinIVA, producto.Alicuota2.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
      End If

      If PrecioPorEmbalaje Then
         PrecioVentaSinIVA = PrecioVentaSinIVA / producto.Embalaje
         PrecioVentaConIVA = PrecioVentaConIVA / producto.Embalaje
         If PrecioVentaConIVA2.HasValue Then
            PrecioVentaConIVA2 = PrecioVentaConIVA2.Value / producto.Embalaje
         End If
      End If

      'Si el producto pertenece a una Marca que tiene lista de Precios especifica.. vuelvo a tomar los precios.

      Dim dt As DataTable
      dt = New Eniac.Reglas.ClientesMarcasListasDePrecios().GetUno(cliente.IdCliente, producto.IdMarca)

      If dt.Rows.Count = 1 Then

         Dim IdListaDePrecio As Integer = Integer.Parse(dt.Rows(0)("IdListaPrecios").ToString())
         dt = Nothing
         dt = New Eniac.Reglas.Productos().GetPorCodigo(producto.IdProducto, actual.Sucursal.Id, IdListaDePrecio, "VENTAS")
         PrecioVentaSinIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaSinIVA").ToString())
         PrecioVentaConIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaConIVA").ToString())

         If producto.Alicuota2.HasValue Then
            PrecioVentaConIVA2 = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioVentaSinIVA, producto.Alicuota2.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
         End If
      End If
      '----------------------------------------------------------------------------------------------------------------------------------

      'Precio de Venta, Opciones: ACTUAL o ULTIMO
      If Publicos.VentasPrecioVenta <> "ACTUAL" Then
         Dim CalculoVenta() As String = Publicos.VentasPrecioVenta.Split(";"c)
         Dim OtroPrecioVenta As Decimal = 0

         Select Case CalculoVenta(0).ToString()
            Case "ULTIMO"
               Dim oVP As Eniac.Reglas.VentasProductos = New Eniac.Reglas.VentasProductos()

               OtroPrecioVenta = oVP.GetUltimoDeProducto(actual.Sucursal.Id,
                                                         idTipoComprobante.IdTipoComprobante,
                                                         producto.IdProducto,
                                                         cliente.IdCliente)
            Case Else
               Throw New Exception("ATENCION: el sistema tiene configurado el Tipo de VENTA '" & CalculoVenta(0).ToString() & "' (incorrecto), verifíquelo en Parametros")
         End Select

         If OtroPrecioVenta <> 0 Then
            PrecioVentaSinIVA = OtroPrecioVenta
            PrecioVentaConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioVentaSinIVA, producto.Alicuota, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
            If producto.Alicuota2.HasValue Then
               PrecioVentaConIVA2 = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(PrecioVentaSinIVA, producto.Alicuota2.Value, producto.PorcImpuestoInterno, producto.ImporteImpuestoInterno, producto.OrigenPorcImpInt)
            End If
         End If
      End If
      '------------------------------------------

      If producto.Moneda.IdMoneda = 2 Then
         PrecioVentaSinIVA = Decimal.Round(PrecioVentaSinIVA * cotizacionDolar, redondeoEnCalculo)
         PrecioVentaConIVA = Decimal.Round(PrecioVentaConIVA * cotizacionDolar, redondeoEnCalculo)
         If PrecioVentaConIVA2.HasValue Then
            PrecioVentaConIVA2 = Decimal.Round(PrecioVentaConIVA2.Value * cotizacionDolar, redondeoEnCalculo)
         End If
      End If


      Return New PreciosConSinIVA(PrecioVentaConIVA, PrecioVentaSinIVA, PrecioVentaConIVA2)
   End Function
   Public Class PreciosConSinIVA
      Public Property PrecioVentaSinIVA As Decimal
      Public Property PrecioVentaConIVA As Decimal
      Public Property PrecioVentaConIVA2 As Decimal?

      Public Sub New()

      End Sub
      Public Sub New(precioVentaConIVA As Decimal, precioVentaSinIVA As Decimal, precioVentaConIVA2 As Decimal?)
         Me.New()
         Me.PrecioVentaConIVA = precioVentaConIVA
         Me.PrecioVentaSinIVA = precioVentaSinIVA
         Me.PrecioVentaConIVA2 = precioVentaConIVA2
      End Sub

   End Class
#End Region

#Region "Calcula Kilos"
   Public Function CalculaTotalKilosItems(_ventasProductos As List(Of VentaProducto)) As TotalKilosItems
      Dim result As TotalKilosItems = New TotalKilosItems()

      For Each vp As VentaProducto In _ventasProductos
         result.TotalKilos += vp.Kilos

         'Asumimos que:
         '     SI tiene decimales es un item que se vende por peso.
         '     NO tiene decimales es un item que se vende por unidad.
         'Posible problema:
         '     Un producto que se vende por peso pero el peso es redondo (sin decimales).
         '     Ejemplo: Una horma de 4kg de queso será contado como 4 productos, si fuera 4.01 será contado como 1 producto.
         If Decimal.ToInt32(vp.Cantidad) = vp.Cantidad Then
            result.TotalProductos += Decimal.ToInt32(vp.Cantidad)
         Else
            result.TotalProductos += 1
         End If

         result.TotalItems += 1
      Next

      Return result
   End Function
   Public Class TotalKilosItems
      Public Property TotalKilos As Decimal
      Public Property TotalItems As Integer
      Public Property TotalProductos As Integer

      Public Sub New()

      End Sub
   End Class
#End Region

#Region "Validaciones"
   Public Sub ValidaMediosPagoSegunFormaPago(tipoComprobante As Entidades.TipoComprobante,
                                             formaPago As Entidades.VentaFormaPago,
                                             efectivo As Decimal,
                                             dolares As Decimal,
                                             tickets As Decimal,
                                             transferencia As Decimal,
                                             cheques As List(Of Cheque),
                                             tarjetas As List(Of VentaTarjeta))
      If tipoComprobante IsNot Nothing Then
         If tipoComprobante.AfectaCaja Or tipoComprobante.EsPreElectronico Then

            If formaPago IsNot Nothing AndAlso formaPago.RequiereAlgo Then
               Dim algunoValido As Boolean = False
               Dim mediosPagoRequeridos As StringBuilder = New StringBuilder()
               If formaPago.RequierePesos Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Pesos", Function() efectivo <> 0)
               End If

               If formaPago.RequiereDolares Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Dolares", Function() dolares <> 0)
               End If

               If formaPago.RequiereTickets Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Tickets", Function() tickets <> 0)
               End If

               If formaPago.RequiereTransferencia Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Transferencia", Function() transferencia <> 0)
               End If

               If formaPago.RequiereCheques Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Cheques", Function() cheques.Count > 0)
               End If

               If formaPago.RequiereTarjetaDebito Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Tarjeta Débito", Function() tarjetas.Where(Function(x) x.Tarjeta.TipoTarjeta = Tarjeta.TiposTarjetas.Debito).Count > 0)
               End If

               If formaPago.RequiereTarjetaCredito Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Tarjeta Crédito (2 o más Pagos)", Function() tarjetas.Where(Function(x) x.Tarjeta.TipoTarjeta = Tarjeta.TiposTarjetas.Credito And x.Cuotas <> 1).Count > 0)
               End If

               If formaPago.RequiereTarjetaCredito1Pago Then
                  ValidaIndividual(mediosPagoRequeridos, algunoValido, "Tarjeta Crédito (1 Pago)", Function() tarjetas.Where(Function(x) x.Tarjeta.TipoTarjeta = Tarjeta.TiposTarjetas.Credito And x.Cuotas = 1).Count > 0)
               End If

               If Not algunoValido Then
                  Throw New Exception(String.Format("La forma de pago seleccionada ({1}) requiere al menos alguno de los siguientes medios de pago:{0}{0}{2}{0}{0}Verifique los medios de pago seleccionados",
                                                    Environment.NewLine, formaPago.DescripcionFormasPago, mediosPagoRequeridos.ToString()))
               End If
            End If

         End If      'If formaPago IsNot Nothing AndAlso formaPago.RequiereAlgo Then
      End If         'If tipoComprobante IsNot Nothing AndAlso tipoComprobante.AfectaCaja Then
   End Sub

   Private Sub ValidaIndividual(stb As StringBuilder, ByRef algunovalido As Boolean, medioPago As String, controlaValido As Func(Of Boolean))
      stb.AppendFormatLine("    - {0}", medioPago)
      If controlaValido() Then
         algunovalido = True
      End If

   End Sub

#End Region

End Class