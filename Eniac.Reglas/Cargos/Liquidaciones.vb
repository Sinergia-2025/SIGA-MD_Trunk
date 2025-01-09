Option Strict On
Option Explicit On
Imports System.Text
Imports Eniac.Entidades

Public Class Liquidaciones
   Inherits Eniac.Reglas.Base

   Public Const NombreDataTableCargosClientes As String = "CargosClientes"
   Public Const NombreDataTableCargosClientesCamas As String = "CargosClientesCamas"
   Public Const NombreDataTableCargosClientesDetalle As String = "CargosClientesDetalle"
   Public Const NombreDataTableLiquidacionDetalle As String = "LiquidacionDetalle"
   Public Const NombreDataTableLiquidacionObservaciones As String = "LiquidacionObservacion"

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Liquidaciones"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Liquidaciones"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"
   Private Sub CargarUno(ByVal o As Entidades.Liquidacion, ByVal dr As DataRow)
      With o
         .PeriodoLiquidacion = Integer.Parse(dr(Entidades.Liquidacion.Columnas.PeriodoLiquidacion.ToString()).ToString())
         .FechaLiquidacion = Date.Parse(dr(Entidades.Liquidacion.Columnas.FechaLiquidacion.ToString()).ToString())
         .TotalExpensas = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalExpensas.ToString()).ToString())
         .TotalAlquiler = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalAlquiler.ToString()).ToString())
         .TotalServicios = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalServicios.ToString()).ToString())
         .TotalGastosAdmin = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosAdmin.ToString()).ToString())
         .TotalLiquidacion = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalLiquidacion.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Liquidacion.Columnas.FechaFacturado.ToString()).ToString()) Then
            .FechaFacturado = Date.Parse(dr(Entidades.Liquidacion.Columnas.FechaFacturado.ToString()).ToString())
            .TotalGastosNoGravado = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosNoGravado.ToString()).ToString())
            .TotalGastosIVA105 = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosIVA105.ToString()).ToString())
            .TotalGastosIVA210 = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosIVA210.ToString()).ToString())
            .TotalGastosIVA270 = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosIVA270.ToString()).ToString())
            .TotalGastosNeto105 = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosNeto105.ToString()).ToString())
            .TotalGastosNeto210 = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosNeto210.ToString()).ToString())
            .TotalGastosNeto270 = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosNeto270.ToString()).ToString())
         End If

         .TotalAlquilerAnterior = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalAlquilerAnterior.ToString()).ToString())
         .TotalGastosOperativos = Decimal.Parse(dr(Entidades.Liquidacion.Columnas.TotalGastosOperativos.ToString()).ToString())

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetUno(ByVal PeriodoLiquidacion As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As Entidades.Liquidacion
      Try
         Me.da.OpenConection()

         Return Me._GetUno(PeriodoLiquidacion, IdSucursal, IdTipoLiquidacion)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetUno(ByVal PeriodoLiquidacion As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As Entidades.Liquidacion
      Dim dt As DataTable = New SqlServer.Liquidaciones(Me.da).Liquidaciones_G1(PeriodoLiquidacion, IdSucursal, IdTipoLiquidacion)
      Dim o As Entidades.Liquidacion = New Entidades.Liquidacion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetUltimoPeriodoLiquidacion(ByVal IdTipoLiquidacion As Integer) As Integer
      Me.da.OpenConection()
      Try
         Return New SqlServer.Liquidaciones(Me.da).GetUltimoPeriodoLiquidacion(IdTipoLiquidacion)
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Sub EliminarLiquidacionYCargos(ByVal Periodo As Integer, ByVal IdTipoLiquidacion As Integer, ByVal IdSucursal As Integer)
      Dim openConnection As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Dim beginTransaction As Boolean = da.Transaction Is Nothing
      Try
         If openConnection Then da.OpenConection()
         If beginTransaction Then da.BeginTransaction()

         Dim sql As SqlServer.Liquidaciones = New SqlServer.Liquidaciones(da)
         Dim sqlC As SqlServer.LiquidacionesCargos = New SqlServer.LiquidacionesCargos(da)
         Dim sqlDC As SqlServer.LiquidacionesDetallesClientes = New SqlServer.LiquidacionesDetallesClientes(da)
         Dim sqlLO As SqlServer.LiquidacionesObservaciones = New SqlServer.LiquidacionesObservaciones(da)

         sqlLO.LiquidacionesObservaciones_D(Periodo, IdSucursal, IdTipoLiquidacion)
         sqlDC.LiquidacionesDetallesClientes_D(Periodo, IdSucursal, IdTipoLiquidacion)
         sqlC.LiquidacionesCargos_D(Periodo, IdTipoLiquidacion, IdSucursal)
         sql.Liquidaciones_D(Periodo, IdSucursal, IdTipoLiquidacion)


         If beginTransaction Then da.CommitTransaction()
      Catch ex As Exception
         If beginTransaction Then da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         If openConnection Then da.CloseConection()
      End Try

   End Sub

   Public Function GetUltimaLiquidacion(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As Integer

      Dim sql As SqlServer.Liquidaciones
      Dim Periodo As Integer

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Liquidaciones(Me.da)
         Periodo = sql.GetUltimaLiquidacion(IdSucursal, IdTipoLiquidacion)

         Me.da.CommitTransaction()

         Return Periodo

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetLiquidacionParaFacturar(ByVal Periodo As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable

      Dim sql As SqlServer.Liquidaciones
      Dim ret As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Liquidaciones(Me.da)
         ret = sql.GetLiquidacionParaFacturar(Periodo, IdSucursal, IdTipoLiquidacion)

         Me.da.CommitTransaction()

         Return ret

      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetFechaFactura(Periodo As Integer, fechaFacturacion As String) As Date
      Dim Fecha As Date
      If fechaFacturacion = Reglas.Publicos.FechaFacturacionEnum.FechaActual.ToString() Then
         Fecha = Today
      ElseIf fechaFacturacion = Reglas.Publicos.FechaFacturacionEnum.PrimerDiaPeriodoActual.ToString() Then
         Fecha = Date.Parse(Periodo.ToString("0000-00") & "-01 00:00:00")
      ElseIf fechaFacturacion = Reglas.Publicos.FechaFacturacionEnum.UltimoDiaPeriodoActual.ToString() Then
         Fecha = Date.Parse(Periodo.ToString("0000-00") & "-01 00:00:00").AddMonths(1).AddDays(-1)
      ElseIf fechaFacturacion = Reglas.Publicos.FechaFacturacionEnum.PrimerDiaPeriodoAnterior.ToString() Then
         Fecha = Date.Parse(Periodo.ToString("0000-00") & "-01 00:00:00").AddMonths(-1)
      ElseIf fechaFacturacion = Reglas.Publicos.FechaFacturacionEnum.UltimoDiaPeriodoAnterior.ToString() Then
         Fecha = Date.Parse(Periodo.ToString("0000-00") & "-01 00:00:00").AddDays(-1)
      ElseIf fechaFacturacion = Reglas.Publicos.FechaFacturacionEnum.PrimerDiaPeriodoSiguiente.ToString() Then
         Fecha = Date.Parse(Periodo.ToString("0000-00") & "-01 00:00:00").AddMonths(1)
      ElseIf fechaFacturacion = Reglas.Publicos.FechaFacturacionEnum.UltimoDiaPeriodoSiguiente.ToString() Then
         Fecha = Date.Parse(Periodo.ToString("0000-00") & "-01 00:00:00").AddMonths(2).AddDays(-1)
      End If
      Return Fecha
   End Function

   Public Function GetPeriodoFactura(Periodo As Integer, periodoFacturacion As String) As Integer
      Dim Fecha As Integer = Periodo
      If periodoFacturacion = Reglas.Publicos.PeriodoFacturacionEnum.PeriodoActual.ToString() Then
         Fecha = Periodo
      ElseIf periodoFacturacion = Reglas.Publicos.PeriodoFacturacionEnum.PeriodoSiguiente.ToString() Then
         Fecha = Integer.Parse(Date.Parse(Periodo.ToString("0000-00") & "-01 00:00:00").AddMonths(1).ToString("yyyyMM"))
      End If
      Return Fecha
   End Function

   Public Sub GrabarFacturasDeCargos(idSucursal As Integer, periodo As Integer, fechaEmisionComprobante As DateTime, idFormaDePagoComprobante As Integer,
                                     idCajaComprobante As Integer, observacionComprobante As String,
                                     totalGastosNoGravado As Decimal, totalGastosIVA105 As Decimal, totalGastosNeto105 As Decimal,
                                     totalGastosIVA210 As Decimal, totalGastosNeto210 As Decimal, totalGastosIVA270 As Decimal, totalGastosNeto270 As Decimal,
                                     datos As DataTable, metodoGrabacion As Entidad.MetodoGrabacion, idFuncion As String, idTipoLiquidacion As Integer)

      Dim periodoExpensa As Integer = GetPeriodoFactura(periodo, Publicos.ExpensasPeriodoFactura)

      'Dim FechaExpensa As Date = GetFechaFactura(Periodo, Publicos.ExpensasFechaFactura)

      Dim comprobante As Eniac.Entidades.Venta
      'Dim FechaComprobante As Date

      Dim idTipoComprobanteExpensa As String
      Dim idTipoComprobanteAsignar As String

      idTipoComprobanteExpensa = Reglas.Publicos.ExpensasTipoComprobantes.ToString()

      Dim idCliente As Long

      Dim idFormaDePagoAsignar As Integer
      Dim idCajaAsignar As Integer

      'Dim Observacion As String

      Dim importeExpensas As Decimal
      Dim importeExpensaAdicionalEslora As Decimal
      Dim importeExpensaAdicionalAlturaTotal As Decimal
      Dim importeServicios As Decimal
      Dim importeGastosAdmin As Decimal
      Dim importeVarios As Decimal
      Dim importeAdicionales As Decimal

      Dim importeAlquiler As Decimal
      Dim importeGastosIntermAlq As Decimal
      Dim importeTotal As Decimal

      Dim blnGeneroFactExpensa As Boolean

      Dim colVentasProducto As List(Of Eniac.Entidades.VentaProducto)
      Dim oLineaVP As Eniac.Entidades.VentaProducto

      Dim colVentasObservaciones As List(Of Eniac.Entidades.VentaObservacion) = New List(Of Eniac.Entidades.VentaObservacion)

      Dim oLineaVO As Eniac.Entidades.VentaObservacion

      Dim reglasLiquidacionesObservaciones As Reglas.LiquidacionesObservaciones = New LiquidacionesObservaciones()
      Dim colLiquidacionesObservaciones As List(Of Entidades.LiquidacionObservacion) = New List(Of Entidades.LiquidacionObservacion)
      colLiquidacionesObservaciones = reglasLiquidacionesObservaciones.GetPorSucursal(idSucursal, periodo, idTipoLiquidacion)

      Dim dtAdicionales As DataTable = New SqlServer.LiquidacionesDetallesClientes(da).LiquidacionesDetallesClientes_GA(periodo, True, idSucursal, idTipoLiquidacion)
      Dim productoObservacion As Entidades.Producto = Nothing

      If dtAdicionales.Select(String.Format("{0} IS NOT NULL AND {0} <> ''", Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString())).Length > 0 Then
         Dim prodCol As List(Of Producto) = New Reglas.Productos().GetTodosObservacion()
         If prodCol.Count = 0 Then
            Throw New Exception("Tiene cargos con observaciones y no ha definido ningún producto tipo observacion. Por favor agregue un producto observación en Archivo -> Productos y vuelva a intentar.")
         End If
         productoObservacion = prodCol(0)
      End If

      Dim _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal = New Eniac.Reglas.CategoriasFiscales(da)._GetUno(Publicos.CategoriaFiscalEmpresa)

      For Each dr As DataRow In datos.Rows
         If String.IsNullOrEmpty(dr("IdTipoComprobante").ToString()) Then
            Comprobante = New Entidades.Venta()

            Dim idLiquidacionCargo As Integer = Integer.Parse(dr(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString()).ToString())
            IdCliente = Long.Parse(dr(Entidades.LiquidacionCargo.Columnas.IdCliente.ToString()).ToString)

            Dim cliente As Eniac.Entidades.Cliente = New Eniac.Reglas.Clientes().GetUno(IdCliente)

            'Asigno la Caja, pero tomo la del cliente si tiene una configurada.
            IdCajaAsignar = idCajaComprobante
            If cliente.IdCaja > 0 Then
               IdCajaAsignar = cliente.IdCaja
            End If


            'Asigno la forma de pago general, pero toemo la del cliente si tiene una configurada.
            idFormaDePagoAsignar = idFormaDePagoComprobante
            If cliente.IdFormasPago > 0 Then
               idFormaDePagoAsignar = cliente.IdFormasPago
            End If

            ImporteVarios = Decimal.Parse(dr(Entidades.LiquidacionCargo.Columnas.ImporteVarios.ToString()).ToString)
            ImporteTotal = Decimal.Parse(dr(Entidades.LiquidacionCargo.Columnas.ImporteTotal.ToString()).ToString)
            ImporteAdicionales = Decimal.Parse(dr("ImporteTotalAdicionales").ToString())
            ImporteVarios = ImporteVarios - ImporteAdicionales

            blnGeneroFactExpensa = Not String.IsNullOrEmpty(dr(Entidades.LiquidacionCargo.Columnas.IdTipoComprobante.ToString()).ToString)

            If (ImporteExpensas + ImporteVarios + ImporteAdicionales > 0 And ImporteAlquiler = 0) Or (ImporteServicios > 0 And ImporteAlquiler > 0) And Not blnGeneroFactExpensa Then

               colVentasProducto = New List(Of Eniac.Entidades.VentaProducto)

               IdTipoComprobanteAsignar = IdTipoComprobanteExpensa

               If Not String.IsNullOrEmpty(cliente.IdTipoComprobante) Then
                  IdTipoComprobanteAsignar = cliente.IdTipoComprobante
               End If

               Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(IdTipoComprobanteAsignar)

               'Solo se cobra los adicionales, el resto va dentro del alquiler
               If ImporteVarios <> 0 Then
                  For Each drAdicionales As DataRow In dtAdicionales.Select(String.Format("{0} = {1}",
                                                                                          Entidades.LiquidacionDetalleCliente.Columnas.IdLiquidacionCargo.ToString(),
                                                                                          idLiquidacionCargo))
                     Dim importe As Decimal = CDec(drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.Importe.ToString()))
                     If importe <> 0 Then
                        oLineaVP = New Eniac.Entidades.VentaProducto()
                        With oLineaVP
                           .Orden = colVentasProducto.Count + 1
                           .Producto = New Eniac.Reglas.Productos().GetUno(drAdicionales(Entidades.Cargo.Columnas.IdProducto.ToString()).ToString())
                           If Not tipoComprobante.UtilizaImpuestos Then
                              .Producto.Alicuota = 0
                           End If
                           .Cantidad = CDec(drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString()))
                           .PrecioLista = CDec(drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString()))
                           .DescuentoRecargoPorc1 = CDec(drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString()))
                           If CDec(drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString())) <> 0 Then
                              .DescuentoRecargoPorc2 = CDec(drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()))
                           End If
                           .Precio = CDec(drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString()))
                        End With
                        colVentasProducto.Add(oLineaVP)
                        If Not String.IsNullOrWhiteSpace(drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString()).ToString()) AndAlso
                           productoObservacion IsNot Nothing Then
                           oLineaVP = New Eniac.Entidades.VentaProducto()
                           With oLineaVP
                              .Orden = colVentasProducto.Count + 1
                              .Producto = productoObservacion
                              .Producto.NombreProducto = drAdicionales(Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString()).ToString()
                              .Cantidad = 1
                              .Precio = 1
                           End With
                           colVentasProducto.Add(oLineaVP)
                        End If
                     End If
                  Next
               End If

               'Le coloco la hora, min, seg y mil para que se orden en las consultas de Ventas!
               Dim FechaComprobante As DateTime = fechaEmisionComprobante.Date.Add(Now.TimeOfDay) 'Date.Parse(FechaExpensa.ToString("yyyy-MM-dd") & " " & Date.Now.ToString("HH:mm:ss.ffff"))

               colVentasObservaciones.Clear()

               Dim tipObs = New Entidades.TipoObservacion()
               tipObs = New Reglas.TiposObservaciones().GetUno(New Reglas.TiposObservaciones().GetIdTipoObservacionDefecto())

               'agregar primero la observación con el periodo
               Dim linea As Integer = 1
               oLineaVO = New Eniac.Entidades.VentaObservacion()
               With oLineaVO
                  .Linea = linea
                  .Observacion = observacionComprobante
                  .IdTipoObservacion = tipObs.IdObservaciones
                  .DescripcionTipoObservacion = tipObs.Descripcion
               End With
               colVentasObservaciones.Add(oLineaVO)
               linea = linea + 1

               Dim VO As Entidades.VentaObservacion
               Dim listaLiquidacionObservaciones As List(Of Entidades.LiquidacionObservacion) = New List(Of Entidades.LiquidacionObservacion)

               listaLiquidacionObservaciones = colLiquidacionesObservaciones.FindAll(Function(LObs) LObs.IdCliente = IdCliente)
               If listaLiquidacionObservaciones.Count <> 0 Then
                  For Each LObs As Entidades.LiquidacionObservacion In listaLiquidacionObservaciones

                     VO = New Entidades.VentaObservacion()
                     VO.Observacion = LObs.Observacion
                     VO.Linea = linea
                     VO.IdTipoObservacion = tipObs.IdObservaciones
                     VO.DescripcionTipoObservacion = tipObs.Descripcion
                     colVentasObservaciones.Add(VO)
                     linea = linea + 1

                  Next
               End If

               If Not String.IsNullOrWhiteSpace(cliente.Cobrador.Observacion) Then
                  VO = New Entidades.VentaObservacion()
                  VO.Observacion = cliente.Cobrador.Observacion
                  VO.Linea = linea
                  VO.IdTipoObservacion = tipObs.IdObservaciones
                  VO.DescripcionTipoObservacion = tipObs.Descripcion
                  colVentasObservaciones.Add(VO)
                  linea = linea + 1
               End If

               Try
                  da.OpenConection()
                  da.BeginTransaction()

                  Dim oRegVentas As Reglas.Ventas = New Reglas.Ventas(da)
                  comprobante = oRegVentas.GrabarComprobante(Eniac.Entidades.Usuario.Actual.Sucursal.Id,
                                                             idTipoComprobanteAsignar,
                                                             idCliente,
                                                             idCajaAsignar,
                                                             FechaComprobante,
                                                             cliente.Vendedor,
                                                             idFormaDePagoAsignar,
                                                             observacionComprobante,
                                                             importeTotal,
                                                             colVentasProducto,
                                                             colVentasObservaciones,
                                                             False,
                                                             metodoGrabacion,
                                                             idFuncion, cuota:=0,
                                                             CuentaCorrientePago:=Nothing,
                                                             CuentaCorriente:=Nothing)

                  Dim oRegCargos As Reglas.LiquidacionesCargos = New Reglas.LiquidacionesCargos(da)
                  oRegCargos.ActualizarComprobante(Integer.Parse(dr("IdLiquidacionCargo").ToString()),
                                                   periodo, idCliente,
                                                   comprobante.IdSucursal, comprobante.IdTipoComprobante,
                                                   comprobante.LetraComprobante, comprobante.CentroEmisor,
                                                   comprobante.NumeroComprobante, comprobante.ImporteTotal,
                                                  idTipoLiquidacion)

                  da.CommitTransaction()
               Catch ex As Exception
                  da.RollbakTransaction()
                  Throw New Exception(ex.Message, ex)
               Finally
                  da.CloseConection()
               End Try
            End If
         End If
      Next

      'Actualizo la fecha de Facturacion en la liquidacion

      Me.da.OpenConection()
      Me.da.BeginTransaction()

      Dim sqlLiq As SqlServer.Liquidaciones = New SqlServer.Liquidaciones(Me.da)

      sqlLiq.Liquidaciones_U_DatosFacturacion(periodo, idSucursal, Date.Now, totalGastosNoGravado, totalGastosIVA105, TotalGastosNeto105, totalGastosIVA210, totalGastosNeto210, totalGastosIVA270, totalGastosNeto270, idTipoLiquidacion)

      Me.da.CommitTransaction()
      Me.da.CloseConection()

   End Sub

   Public Sub EliminarFacturasDeCargos(periodo As Integer, idSucursal As Integer, idTipoLiquidacion As Integer,
                                       metodoGrabacion As Entidad.MetodoGrabacion, idFuncion As String)

      Try
         'Si hay algun pago efectuado en ese Periodo lanza una excepcion

         Dim liq As Entidades.Liquidacion = _GetUno(periodo, idSucursal, idTipoLiquidacion)
         Dim tipoLiq As Entidades.Liquidacion.TipoLiquidacion? = Nothing
         ' tipoLiq = Entidades.Liquidacion.TipoLiquidacion.Expensas

         Dim dtPagos As DataTable
         Dim oCtaCtePagos As Eniac.Reglas.CuentasCorrientesPagos = New Eniac.Reglas.CuentasCorrientesPagos()
         dtPagos = oCtaCtePagos.GetPagos(idSucursal, periodo, tipoLiq)

         If dtPagos.Rows.Count > 0 Then
            Dim stbMensaje As StringBuilder = New StringBuilder("Hay Pagos efectuados para este Período. No se puede Eliminar la Liquidación")
            stbMensaje.AppendLine().AppendLine()
            Dim maximo As Integer = 3
            For i As Integer = 0 To Math.Min(maximo, dtPagos.Rows.Count) - 1
               Dim dr As DataRow = dtPagos.Rows(i)
               stbMensaje.AppendFormatLine("    - {1} {2} {3:0000}-{4:00000000}", dr("IdSucursal"), dr("IdTipoComprobante"), dr("Letra"), dr("CentroEmisor"), dr("NumeroComprobante"))
            Next
            If dtPagos.Rows.Count > maximo Then
               stbMensaje.Append("...")
            End If
            Throw New Exception(stbMensaje.ToString())
         End If

         'Anulo los Comprobantes, Luego los elimino
         Dim Orden As String = "DESC"
         Dim dtCargos As DataTable
         Dim EsInversionista As String = "TODOS"

         dtCargos = New Reglas.Cargos().GetCargosPorPeriodo(periodo, idSucursal, idTipoLiquidacion)

         Dim oComprobante As Eniac.Entidades.Venta = New Eniac.Entidades.Venta()
         Dim _comprobantes As List(Of Eniac.Entidades.Venta) = New List(Of Eniac.Entidades.Venta)

         Dim oRegTC As Eniac.Reglas.TiposComprobantes = New Eniac.Reglas.TiposComprobantes()

         Dim IdEmbarcacion As Long
         Dim TipoCargo As String = ""
         Dim blnGeneroFact As Boolean

         For Each dr As DataRow In dtCargos.Rows
            blnGeneroFact = Not String.IsNullOrEmpty(dr(Eniac.Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString()).ToString())

            If blnGeneroFact Then
               Try
                  da.OpenConection()
                  da.BeginTransaction()

                  Dim oRegVentas As Eniac.Reglas.Ventas
                  oRegVentas = New Eniac.Reglas.Ventas(da)
                  oComprobante = oRegVentas.GetUna(Integer.Parse(dr("IdSucursal").ToString()), dr("IdTipoComprobante" & TipoCargo).ToString(), _
                                                dr("Letra" & TipoCargo).ToString(), Short.Parse(dr("CentroEmisor" & TipoCargo).ToString()), _
                                                Long.Parse(dr("NumeroComprobante" & TipoCargo).ToString()))
                  oComprobante.Usuario = Eniac.Entidades.Usuario.Actual.Nombre

                  'Limpio la Factura Relacionada al Cargo
                  Dim oRegCargos As Reglas.Cargos = New Reglas.Cargos(da)
                  oRegCargos.ActualizarComprobante(CInt(dr("IdLiquidacionCargo")), periodo, oComprobante.Cliente.IdCliente,
                                                   idSucursal, "", "", 0, 0, 0, idTipoLiquidacion)

                  oRegVentas.AnularComprobante(oComprobante, metodoGrabacion, idFuncion)

                  '**** Por ahora NO SE CONTROLA SI FUE IMPRESO.
                  oRegVentas.EliminaComprobantes(New List(Of Eniac.Entidades.Venta)({oComprobante}))

                  'Tiro para Atras la Numeracion
                  'Dim oVN As Eniac.Entidades.VentaNumero = New Eniac.Entidades.VentaNumero()
                  'With oVN
                  '   .IdSucursal = oComprobante.IdSucursal
                  '   .IdTipoComprobante = oComprobante.TipoComprobante.IdTipoComprobante
                  '   .LetraFiscal = oComprobante.LetraComprobante
                  '   .CentroEmisor = oComprobante.CentroEmisor
                  '   .Numero = oComprobante.NumeroComprobante - 1
                  '   .Fecha = Date.Now
                  'End With

                  'Dim oRegVN As Eniac.Reglas.VentasNumeros = New Eniac.Reglas.VentasNumeros(da)
                  'oRegVN.ActualizarNumero(oVN)

                  '**********************************************
                  da.CommitTransaction()
               Catch ex As Exception
                  da.RollbakTransaction()
                  Throw New Exception(ex.Message, ex)
               Finally
                  da.CloseConection()
               End Try
            End If
         Next

         'Limpio la fecha de Facturacion en la liquidacion
         Try
            Me.da.OpenConection()
            Me.da.BeginTransaction()

            Dim sqlLiq As SqlServer.Liquidaciones = New SqlServer.Liquidaciones(Me.da)
            sqlLiq.Liquidaciones_U_DatosFacturacion(periodo, idSucursal, Nothing, 0, 0, 0, 0, 0, 0, 0, idTipoLiquidacion)

            Me.da.CommitTransaction()
         Catch ex As Exception
            da.RollbakTransaction()
            Throw New Exception(ex.Message, ex)
         Finally
            Me.da.CloseConection()
         End Try
      Finally
      End Try

   End Sub

   Public Sub GuardarLiquidacionCliente(dsExpensas As DataSet, periodo As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim _now As DateTime = Now

         Dim sqlD As SqlServer.LiquidacionesDetallesClientes = New SqlServer.LiquidacionesDetallesClientes(Me.da)
         Dim sqlL As SqlServer.Liquidaciones = New SqlServer.Liquidaciones(Me.da)
         Dim sqlC As SqlServer.LiquidacionesCargos = New SqlServer.LiquidacionesCargos(Me.da)
         Dim sqlLO As SqlServer.LiquidacionesObservaciones = New SqlServer.LiquidacionesObservaciones(da)

         Dim totalImporte As Decimal = 0
         Dim totalAlquiler As Decimal = 0
         Dim totalCamas As Integer = 0
         For Each dr As DataRow In dsExpensas.Tables(NombreDataTableCargosClientes).Select("Select")
            totalImporte += CDec(dr("importe"))
            totalAlquiler += CDec(dr("importeAlquiler"))
            totalCamas += CInt(dr("CantidadCamas"))
         Next

         sqlL.Liquidaciones_I(periodo, IdSucursal, _now, totalImporte, 0, 0, totalAlquiler, 0, 0, 0, totalImporte + totalAlquiler, IdTipoLiquidacion)

         dsExpensas.AcceptChanges()
         For Each dr As DataRow In dsExpensas.Tables(NombreDataTableCargosClientes).Rows

            Dim IdLiquidacionCargo As Integer = Convert.ToInt32(sqlC.GetProximoCodigoCargos(IdSucursal, IdTipoLiquidacion))
            Dim selecciono As Boolean = dr.Field(Of Boolean)("Select")

            sqlC.LiquidacionesCargos_I(periodo, IdLiquidacionCargo, IdSucursal,
                          CLng(dr(Entidades.Cliente.Columnas.IdCliente.ToString())),
                          dr(Entidades.Categoria.Columnas.NombreCategoria.ToString()).ToString(),
                          0,
                           CDec(dr("importeAlquiler")), 0, 0, CDec(dr("importe")) + CDec(dr("importeAlquiler")),
                           New Date(Today.Year, Today.Month, 15), CDec(dr("importe")) + CDec(dr("importeAlquiler")),
                           New Date(Today.Year, Today.Month, 1).AddMonths(1).AddDays(-1),
                           CDec(dr("importe")) + CDec(dr("importeAlquiler")),
                          0, 0, IdTipoLiquidacion, Integer.Parse("0" & dr("CantidadDePCs").ToString()), If(selecciono, "SI", "NO"))

            Dim i As Integer = 0
            For Each drClientesDetalle As DataRow In dsExpensas.Tables(NombreDataTableCargosClientesDetalle).Select(String.Format("{0} = {1} AND Select",
                                                                                                                                  Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString(),
                                                                                                                                  dr(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString())))
               i += 1
               sqlD.LiquidacionesDetallesClientes_I(periodo, IdSucursal,
                                                    i,
                                                    IdLiquidacionCargo,
                                                    CLng(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.IdCliente.ToString())),
                                                    CInt(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.IdCargo.ToString())),
                                                    CLng(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.CodigoCliente.ToString())),
                                                    drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.NombreCliente.ToString()).ToString(),
                                                    CInt(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.IdCategoria.ToString())),
                                                    drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.NombreCategoria.ToString()).ToString(),
                                                    drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.NombreCargo.ToString()).ToString(),
                                                    CDec(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.Importe.ToString())),
                                                    CDec(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.ImporteAlquiler.ToString())),
                                                    CDec(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString())),
                                                    CDec(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString())),
                                                    CDec(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString())),
                                                    CDec(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString())),
                                                    CDec(drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString())),
                                                    drClientesDetalle(Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString()).ToString(),
                                                    IdTipoLiquidacion)
            Next
         Next

         For Each drObs As DataRow In dsExpensas.Tables(NombreDataTableLiquidacionObservaciones).Rows
            If dsExpensas.Tables(NombreDataTableCargosClientes).Select(String.Format("Select AND IdCliente = {0}", Integer.Parse(drObs("IdCliente").ToString()))).Count > 0 Then
               sqlLO.LiquidacionesObservaciones_I(IdSucursal, periodo, CLng(drObs("IdCliente")), CInt(drObs("Linea")), CStr(drObs("Observacion")),
                                                  IdTipoLiquidacion)
            End If
         Next

         Me.da.CommitTransaction()
      Catch
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub EliminarLiquidacion(periodo As Integer, ByVal idSucursal As Integer, ByVal IdTipoLiquidacion As Integer)

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         'DELETE LIQUIDACIONDETALLECLIENTE   
         'DELETE LIQUIDACIONCARGOS  
         'DELETE LIQUIDACION     
         EliminarLiquidacionYCargos(periodo, IdTipoLiquidacion, idSucursal)

         Me.da.CommitTransaction()
      Catch
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Function GetUltimaLiquidacionPorCliente(ByVal IdSucursal As Integer, ByVal periodo As Integer, ByVal IdTipoLiquidacion As Integer) As DataSet

      Dim ds As DataSet = New DataSet()

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.LiquidacionesDetallesClientes = New SqlServer.LiquidacionesDetallesClientes(Me.da)
         Dim sqlC As SqlServer.Liquidaciones = New SqlServer.Liquidaciones(Me.da)
         Dim dt As DataTable = sql.LiquidacionesDetallesClientes_GA(periodo, IdSucursal, IdTipoLiquidacion)
         dt.TableName = NombreDataTableCargosClientesDetalle
         ds.Tables.Add(dt)

         dt = sqlC.GetCargosUltimaLiquidacion(IdSucursal, periodo, IdTipoLiquidacion)

         dt.TableName = NombreDataTableCargosClientes
         ds.Tables.Add(dt)

         dt.Columns.Add("importeTotal", GetType(Decimal)).Expression = "importe"

         Dim ReglasLiquidacionesObservaciones As Reglas.LiquidacionesObservaciones = New LiquidacionesObservaciones()
         'obtener el idliquidacioncargo
         dt = ReglasLiquidacionesObservaciones.GetPorSucursalConDatosCliente(IdSucursal, periodo, IdTipoLiquidacion)
         dt.TableName = NombreDataTableLiquidacionObservaciones
         ds.Tables.Add(dt)

         Return ds

      Catch
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetMovimientosLiquidacionPorCliente(ByVal IdSucursal As Integer, periodoLiquidacion As Integer, IdTipoLiquidacion As Integer) As DataSet

      Dim dsResult As DataSet = New DataSet()
      Dim dtLiquidacionesCargos As DataTable = CreaTablaCargosClientes()
      Dim dtClienteDetalle As DataTable = CreaTablaCargosClientesAdicionales()
      Dim dtObservaciones As DataTable = CreaTablaLiquidacionObservaciones()
      Dim drClienteDetalle As DataRow
      Dim drObservacion As DataRow
      dsResult.Tables.Add(dtLiquidacionesCargos)
      dsResult.Tables.Add(dtClienteDetalle)

      Dim reglasCargosObservaciones As Reglas.CargosClientesObservaciones = New CargosClientesObservaciones()

      'no debería ser necesario pero parece que se sobreescribe el nombre de la tabla en el form con el de la que envia la regla
      dtObservaciones = reglasCargosObservaciones.GetPorSucursalConDatosCliente(IdSucursal, IdTipoLiquidacion)
      dtObservaciones.TableName = NombreDataTableLiquidacionObservaciones
      dsResult.Tables.Add(dtObservaciones)

      Try
         Me.da.OpenConection()

         Dim dtTodosClientes As DataTable = New Clientes(Me.da).GetAll()
         Dim dtCargoCliente As DataTable = New CargosClientes(Me.da).GetAll(True, IdSucursal, IdTipoLiquidacion, False)

         For Each drTodosCliente As DataRow In dtTodosClientes.Rows
            For Each drCargoCliente As DataRow In dtCargoCliente.Select(String.Format("{0} = {1}",
                                                                                      Entidades.CargoCliente.Columnas.IdCliente.ToString(),
                                                                                      drTodosCliente(Entidades.Cliente.Columnas.IdCliente.ToString())))
               Dim monto As Decimal = CDec(drCargoCliente(Entidades.CargoCliente.Columnas.Monto.ToString()))
               Dim cantidad As Decimal = CDec(drCargoCliente(Entidades.CargoCliente.Columnas.Cantidad.ToString()))
               If Publicos.CargosGenerarComprobantePorItem Then
                  For i As Integer = 1 To Convert.ToInt32(Decimal.Round(cantidad, 0))
                     AgregaCargo(dtLiquidacionesCargos, dtClienteDetalle, drTodosCliente, drCargoCliente, monto, 1)
                  Next
               Else
                  AgregaCargo(dtLiquidacionesCargos, dtClienteDetalle, drTodosCliente, drCargoCliente, monto, cantidad)
               End If
            Next
         Next

         '# Observaciones
         '# Si el cliente tiene cargos x $0, no se muestra en pantalla, por lo tanto tampoco las observaciones.
         For Each obs As DataRow In dtObservaciones.Rows
            If Not dtClienteDetalle.Select(String.Format("IdCliente = {0} AND Importe <> 0", Integer.Parse(obs("IdCliente").ToString()))).Count > 0 Then
               obs.Delete()
            End If
         Next

         Return dsResult
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Private Sub AgregaCargo(dtLiquidacionesCargos As DataTable, dtClienteDetalle As DataTable, drTodosCliente As DataRow, drCargoCliente As DataRow,
                           monto As Decimal, cantidad As Decimal)
      Dim drLiquidacionesCargos As DataRow = BuscaCargosClientes(dtLiquidacionesCargos, drTodosCliente)

      drLiquidacionesCargos("importe") = CDec(drLiquidacionesCargos("importe")) + (monto * cantidad)

      Dim drClienteDetalle As DataRow
      drClienteDetalle = BuscaCargosClientesAdicionales(dtClienteDetalle, drLiquidacionesCargos, drCargoCliente)

      drClienteDetalle(Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString()) = CDec(drClienteDetalle(Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString())) + cantidad

      'GAR: 14/07/2018. No entiendo la logica. buaaahhh!!! porque suma??
      'Hasta entender leo directo el valor

      drClienteDetalle(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString()) = CDec(drCargoCliente(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString()))
      drClienteDetalle(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString()) = CDec(drCargoCliente(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString()))
      drClienteDetalle(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()) = CDec(drCargoCliente(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()))


      drClienteDetalle(Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString()) = CDec(drClienteDetalle(Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString())) + monto
      drClienteDetalle(Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString()) = drCargoCliente(Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString())
      drClienteDetalle("importe") = CDec(drClienteDetalle("importe")) + (monto * cantidad)

      If drLiquidacionesCargos IsNot Nothing AndAlso (CDec(drLiquidacionesCargos("importe")) = 0) Then
         dtLiquidacionesCargos.Rows.Remove(drLiquidacionesCargos)
      End If
   End Sub

   Private Function CreaTablaCargosClientesAdicionales() As DataTable
      Dim dt As DataTable = New DataTable(NombreDataTableCargosClientesDetalle)

      dt.Columns.Add(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString(), GetType(Integer))

      dt.Columns.Add(Entidades.Cliente.Columnas.IdCliente.ToString(), GetType(Long))
      dt.Columns.Add(Entidades.Cliente.Columnas.CodigoCliente.ToString(), GetType(Long))
      dt.Columns.Add(Entidades.Cliente.Columnas.NombreCliente.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Cliente.Columnas.IdCategoria.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.Categoria.Columnas.NombreCategoria.ToString(), GetType(String))

      dt.Columns.Add("IdClienteAdherente", GetType(Long))
      dt.Columns.Add("CodigoClienteAdherente", GetType(Long))
      dt.Columns.Add("NombreClienteAdherente", GetType(String))
      dt.Columns.Add("IdCategoriaAdherente", GetType(Integer))
      dt.Columns.Add("NombreCategoriaAdherente", GetType(String))

      dt.Columns.Add(Entidades.Cargo.Columnas.IdCargo.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.Cargo.Columnas.NombreCargo.ToString(), GetType(String))

      dt.Columns.Add(Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString(), GetType(Decimal))
      dt.Columns.Add(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString(), GetType(Decimal))
      dt.Columns.Add(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString(), GetType(Decimal))
      dt.Columns.Add(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString(), GetType(Decimal))
      dt.Columns.Add(Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString(), GetType(Decimal))
      dt.Columns.Add(Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString(), GetType(String))

      dt.Columns.Add("importe", GetType(Decimal))
      dt.Columns.Add("importeAlquiler", GetType(Decimal))

      Return dt
   End Function

   Private Function CreaTablaCargosClientes() As DataTable
      Dim dt As DataTable = New DataTable(NombreDataTableCargosClientes)

      dt.Columns.Add(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString(), GetType(Integer))

      dt.Columns.Add(Entidades.Cliente.Columnas.IdCliente.ToString(), GetType(Long))
      dt.Columns.Add(Entidades.Cliente.Columnas.CodigoCliente.ToString(), GetType(Long))

      '-- REQ-44281.- ------------------------------------------------------------------------------
      dt.Columns.Add(Entidades.Cliente.Columnas.CodigoClienteLetras.ToString(), GetType(String))
      '---------------------------------------------------------------------------------------------

      dt.Columns.Add(Entidades.Cliente.Columnas.NombreCliente.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Cliente.Columnas.Activo.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Cliente.Columnas.IdCategoria.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.Categoria.Columnas.NombreCategoria.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Cliente.Columnas.IdZonaGeografica.ToString(), GetType(String))
      dt.Columns.Add(Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Cliente.Columnas.CantidadDePCs.ToString(), GetType(Integer))

      dt.Columns.Add("CantidadCamas", GetType(Integer))

      dt.Columns.Add("importe", GetType(Decimal))
      dt.Columns.Add("importeTasaMunicipal", GetType(Decimal))
      dt.Columns.Add("importeAlquiler", GetType(Decimal))
      dt.Columns.Add("ImporteExpensaAdicionalEslora", GetType(Decimal))
      dt.Columns.Add("ImporteExpensaAdicionalAlturaTotal", GetType(Decimal))

      dt.Columns.Add("importeTotal", GetType(Decimal)).Expression = "importe + importeTasaMunicipal + importeAlquiler + ImporteExpensaAdicionalEslora + ImporteExpensaAdicionalAlturaTotal"
      Return dt
   End Function

   Private Function CreaTablaLiquidacionObservaciones() As DataTable
      Dim dt As DataTable = New DataTable(NombreDataTableLiquidacionObservaciones)

      'dt.Columns.Add(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.Cliente.Columnas.IdCliente.ToString(), GetType(Long))
      dt.Columns.Add(Entidades.Cliente.Columnas.CodigoCliente.ToString(), GetType(Long))
      dt.Columns.Add(Entidades.Cliente.Columnas.NombreCliente.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), GetType(String))
      dt.Columns.Add(Entidades.LiquidacionObservacion.Columnas.Linea.ToString(), GetType(Integer))
      dt.Columns.Add(Entidades.LiquidacionObservacion.Columnas.Observacion.ToString(), GetType(String))
      Return dt
   End Function

   Private Function BuscaCargosClientes(dtCliente As DataTable, drExpensas As DataRow) As DataRow
      Dim result As DataRow
      Dim dr As DataRow()
      If Not Publicos.CargosGenerarComprobantePorItem Then
         dr = dtCliente.Select(String.Format("{0} = {1}", Entidades.Cliente.Columnas.IdCliente.ToString(), drExpensas(Entidades.Cliente.Columnas.IdCliente.ToString())))
      End If
      If dr Is Nothing OrElse dr.Length = 0 Then
         result = dtCliente.NewRow()
         dtCliente.Rows.Add(result)
         result(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString()) = dtCliente.Rows.Count
         result(Entidades.Cliente.Columnas.IdCliente.ToString()) = drExpensas(Entidades.Cliente.Columnas.IdCliente.ToString())
         result(Entidades.Cliente.Columnas.CodigoCliente.ToString()) = drExpensas(Entidades.Cliente.Columnas.CodigoCliente.ToString())

         result(Entidades.Cliente.Columnas.CodigoClienteLetras.ToString()) = drExpensas(Entidades.Cliente.Columnas.CodigoClienteLetras.ToString())

         result(Entidades.Cliente.Columnas.NombreCliente.ToString()) = drExpensas(Entidades.Cliente.Columnas.NombreCliente.ToString())
         result(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()) = drExpensas(Entidades.Cliente.Columnas.NombreDeFantasia.ToString())
         result(Entidades.Cliente.Columnas.Activo.ToString()) = drExpensas(Entidades.Cliente.Columnas.Activo.ToString())
         'If drExpensas.Table.Columns.Contains(Entidades.Cliente.Columnas.IdCategoria.ToString()) Then
         result(Entidades.Cliente.Columnas.IdCategoria.ToString()) = drExpensas(Entidades.Cliente.Columnas.IdCategoria.ToString())
         'End If
         result(Entidades.Categoria.Columnas.NombreCategoria.ToString()) = drExpensas(Entidades.Categoria.Columnas.NombreCategoria.ToString())
         result(Entidades.Cliente.Columnas.IdZonaGeografica.ToString()) = drExpensas(Entidades.Cliente.Columnas.IdZonaGeografica.ToString())
         result(Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString()) = drExpensas(Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString())
         result(Entidades.Cliente.Columnas.CantidadDePCs.ToString()) = drExpensas(Entidades.Cliente.Columnas.CantidadDePCs.ToString())
         result("CantidadCamas") = 0
         result("importe") = 0
         result("importeAlquiler") = 0
         result("ImporteExpensaAdicionalEslora") = 0
         result("ImporteExpensaAdicionalAlturaTotal") = 0

         result("importeTasaMunicipal") = 0
      Else
         result = dr(0)
      End If
      Return result
   End Function

   Private Function BuscaCargosClientesAdicionales(dtClienteDetalle As DataTable,
                                                   drLiquidacionesCargos As DataRow,
                                                   drAdicionalLiquidacion As DataRow) As DataRow

      Dim where As String = String.Empty
      Dim result As DataRow
      If drLiquidacionesCargos IsNot Nothing Then
         where = String.Format("{0} = {1}", Entidades.Cliente.Columnas.IdCliente.ToString(), drLiquidacionesCargos(Entidades.Cliente.Columnas.IdCliente.ToString()))
         If Not String.IsNullOrWhiteSpace(drLiquidacionesCargos(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString()).ToString()) Then
            where += String.Format(" AND {0} = {1}", Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString(),
                                                     drLiquidacionesCargos(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString()).ToString())
         End If
      End If
      If drAdicionalLiquidacion IsNot Nothing Then
         where += String.Format(" AND {0} = {1}", Entidades.Cargo.Columnas.IdCargo.ToString(), drAdicionalLiquidacion(Entidades.Cargo.Columnas.IdCargo.ToString()))
      Else
         where += String.Format(" AND {0} IS NULL", Entidades.Cargo.Columnas.IdCargo.ToString())
      End If

      Dim dr As DataRow() = dtClienteDetalle.Select(where)
      If dr.Length = 0 Then
         result = dtClienteDetalle.NewRow()
         dtClienteDetalle.Rows.Add(result)
         result(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString()) = drLiquidacionesCargos(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString())
         result(Entidades.Cliente.Columnas.IdCliente.ToString()) = drLiquidacionesCargos(Entidades.Cliente.Columnas.IdCliente.ToString())
         result(Entidades.Cliente.Columnas.CodigoCliente.ToString()) = drLiquidacionesCargos(Entidades.Cliente.Columnas.CodigoCliente.ToString())
         result(Entidades.Cliente.Columnas.NombreCliente.ToString()) = drLiquidacionesCargos(Entidades.Cliente.Columnas.NombreCliente.ToString())
         result(Entidades.Cliente.Columnas.IdCategoria.ToString()) = drLiquidacionesCargos(Entidades.Cliente.Columnas.IdCategoria.ToString())
         result(Entidades.Categoria.Columnas.NombreCategoria.ToString()) = drLiquidacionesCargos(Entidades.Categoria.Columnas.NombreCategoria.ToString())
         If drAdicionalLiquidacion IsNot Nothing Then
            result(Entidades.Cargo.Columnas.IdCargo.ToString()) = drAdicionalLiquidacion(Entidades.Cargo.Columnas.IdCargo.ToString())
            result(Entidades.Cargo.Columnas.NombreCargo.ToString()) = drAdicionalLiquidacion(Entidades.Cargo.Columnas.NombreCargo.ToString())
         End If

         result(Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString()) = 0
         result(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString()) = 0
         result(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString()) = 0
         result(Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString()) = 0

         result("importe") = 0
         result("importeAlquiler") = 0

      Else
         result = dr(0)
      End If
      Return result
   End Function

#End Region

End Class
