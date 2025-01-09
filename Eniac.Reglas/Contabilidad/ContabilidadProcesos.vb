Imports System.Runtime.InteropServices.ComTypes
Imports System.Web.UI.WebControls
Imports System.Windows.Forms
Imports Eniac.Entidades
Public Class ContabilidadProcesos
   Inherits Base

   Private _progressBar As ToolStripProgressBar
   Private _textoAvance As ToolStripLabel '   tstAvance

#Region "Constructores"

   Public Sub New(prg As ToolStripProgressBar, tst As ToolStripLabel)
      Me.New()
      _progressBar = prg
      _textoAvance = tst
   End Sub

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ContabilidadProcesos"
      da = accesoDatos
   End Sub

#End Region

#Region "COMUNES"
   ' funcion para el proceso MASIVO
   Private Function ArmarTablaDetalle(fila As DataRow,
                                      idEjercicio As Integer,
                                      idPlanCuenta As Integer,
                                      idUltimoAsiento As Integer,
                                      tipoproceso As String,
                                      ByRef dtResultados As DataTable) As DataTable
      Dim dtDetalle As DataTable = Contabilidad.CrearTablaDetalle()

      Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
      Dim dtaux As DataTable = sql.ObtenerDatosDetalleTmp(fila)

      For Each filaAux As DataRow In dtaux.Rows
         Dim idCentroCosto As Integer? = Nothing
         If IsNumeric(filaAux("IdCentroCosto")) AndAlso Integer.Parse(filaAux("IdCentroCosto").ToString()) > 0 Then
            idCentroCosto = Integer.Parse(filaAux("IdCentroCosto").ToString())
         End If
         Contabilidad.AgregarFila(dtDetalle, filaAux("idCuenta").ToString & "-" & filaAux("nombreCuenta").ToString,
                                  Decimal.Parse(filaAux("debe").ToString()), Decimal.Parse(filaAux("haber").ToString()),
                                  idUltimoAsiento, Int32.Parse(filaAux("idCuenta").ToString()),
                                  filaAux("IdTipoReferencia").ToString(), filaAux("Referencia").ToString(),
                                  idCentroCosto)
      Next

      AgregarResultados(dtResultados,
                        dtDetalle,
                        idEjercicio,
                        idPlanCuenta,
                        idUltimoAsiento,
                        tipoproceso,
                        fila("nombreAsiento").ToString(),
                        DateTime.Parse(fila("FechaAsiento").ToString()))

      Return dtDetalle
   End Function

   Public Function CrearTablaResultados() As DataTable

      Dim datosResultado As New DataTable()
      datosResultado.Columns.Add("TipoProceso", GetType(String))
      datosResultado.Columns.Add("IdEjercicio", GetType(Integer))
      datosResultado.Columns.Add("IdPlanCuenta", GetType(Integer))
      datosResultado.Columns.Add("IdAsiento", GetType(Integer))
      datosResultado.Columns.Add("DscAsiento", GetType(String))
      datosResultado.Columns.Add("FechaAsiento", GetType(DateTime))
      datosResultado.Columns.Add("Cuenta", GetType(String)) 'Cuentas.CodCuenta + desc
      datosResultado.Columns.Add("Debe", GetType(Decimal))
      datosResultado.Columns.Add("Haber", GetType(Decimal))
      datosResultado.Columns.Add("Observaciones", GetType(String))

      Return datosResultado
   End Function

   Private Sub AgregarResultados(ByRef dtresultado As DataTable,
                                 dtDetalle As DataTable,
                                 idEjercicio As Integer,
                                 idPlanCuenta As Integer,
                                 idAsiento As Integer,
                                 tipoproceso As String,
                                 dscAsiento As String,
                                 fechaAsiento As Date)

      For Each filaDetalle As DataRow In dtDetalle.Rows
         Dim fila As DataRow
         fila = dtresultado.NewRow
         fila("IdEjercicio") = idEjercicio
         fila("IdPlanCuenta") = idPlanCuenta
         fila("IdAsiento") = idAsiento
         fila("DscAsiento") = dscAsiento
         fila("FechaAsiento") = fechaAsiento
         fila("Cuenta") = filaDetalle("Cuenta")
         fila("TipoProceso") = tipoproceso
         If IsNumeric(filaDetalle("debe")) And CDec(filaDetalle("debe")) <> 0 Then
            fila("debe") = filaDetalle("debe")
         End If
         If IsNumeric(filaDetalle("haber")) And CDec(filaDetalle("haber")) <> 0 Then
            fila("haber") = filaDetalle("haber")
         End If
         dtresultado.Rows.Add(fila)
      Next
   End Sub

   Public Function GetCantRubrosProducto(idplanCuenta As Integer, tipomov As String, idproducto As Integer) As Integer
      Return New SqlServer.ContabilidadProcesos(da).GetCantRubrosProducto(idplanCuenta, tipomov, idproducto)
   End Function

   Public Function GetCantRubrosCompra(mov As Entidades.MovimientoStock, idplanCuenta As Integer) As Integer
      Return New SqlServer.ContabilidadProcesos(da).GetCantRubrosCompra(mov, idplanCuenta)
   End Function

   Public Function GetCantRubrosVenta(ventas As Entidades.Venta) As Integer
      Return New SqlServer.ContabilidadProcesos(da).GetCantRubrosVenta(ventas)
   End Function

   Public Function GetRubroVenta(ventas As Entidades.Venta) As DataTable
      Return New SqlServer.ContabilidadProcesos(da).GetRubroVenta(ventas)
   End Function

   Public Function getPlanCtaxDoc(idTipoComprobante As String) As Integer
      Return New SqlServer.ContabilidadProcesos(da).getPlanCtaxDoc(idTipoComprobante)
   End Function

   Public Function getPlanCtaxMovimiento(idTipomov As String) As Integer
      Return New SqlServer.ContabilidadProcesos(da).getPlanCtaxMovimiento(idTipomov)
   End Function


   Public Function GetRubroCompra(mov As Entidades.MovimientoStock, idplanCuenta As Integer) As DataTable
      Return New SqlServer.ContabilidadProcesos(da).GetRubroCompras(mov, idplanCuenta)
   End Function

   ' GetRubroProducto
   Public Function GetRubroProducto(idproducto As Integer, idplanCuenta As Integer, mismoRubro As Boolean) As DataTable
      Return New SqlServer.ContabilidadProcesos(da).GetRubroProducto(idproducto, idplanCuenta, mismoRubro)
   End Function
#End Region

#Region "VENTAS"
   Public Function ProcesarVentas(FDesde As Date, FHasta As Date) As DataTable
      Return Me.ProcesarDesdeTemporal(FDesde, FHasta, Entidades.ContabilidadProceso.Procesos.VENTAS)
   End Function
#End Region

#Region "CTACTECLTE"
   Public Function ProcesarCtaCteClte(FDesde As Date, FHasta As Date) As DataTable
      Return Me.ProcesarDesdeTemporal(FDesde, FHasta, Entidades.ContabilidadProceso.Procesos.CuentaCte)
   End Function
#End Region

#Region "COMPRAS"
   Public Function ProcesarCompras(FDesde As Date, FHasta As Date) As DataTable
      Return Me.ProcesarDesdeTemporal(FDesde, FHasta, Entidades.ContabilidadProceso.Procesos.COMPRAS)
   End Function
#End Region

#Region "CTACTEPROV"
   Public Function ProcesarCtaCteProv(FDesde As Date, FHasta As Date) As DataTable
      Return Me.ProcesarDesdeTemporal(FDesde, FHasta, Entidades.ContabilidadProceso.Procesos.PagoProv)
   End Function
#End Region

#Region "BANCOS"
   Public Function ProcesarBancos(FDesde As Date, FHasta As Date) As DataTable
      Return ProcesarDesdeTemporal(FDesde, FHasta, Entidades.ContabilidadProceso.Procesos.MOVBANCO)
   End Function
#End Region

#Region "CAJA"
   Public Function ProcesarCaja(FDesde As Date, FHasta As Date) As DataTable
      Return Me.ProcesarDesdeTemporal(FDesde, FHasta, Entidades.ContabilidadProceso.Procesos.MOVCAJA)
   End Function
#End Region

#Region "STOCK"

   Public Function ProcesarStock(FDesde As Date, FHasta As Date) As DataTable
      Return Me.ProcesarDesdeTemporal(FDesde, FHasta, Entidades.ContabilidadProceso.Procesos.STOCK)
   End Function

   Public Function ProcesarStockVentas(FDesde As Date, FHasta As Date) As DataTable
      Return Me.ProcesarDesdeTemporal(FDesde, FHasta, Entidades.ContabilidadProceso.Procesos.STOCKXVTAS)
   End Function

#End Region

   Public Sub EliminaAsiento(modulo As String, drCol As DataRow())
      EjecutaConTransaccion(Sub() _EliminaAsiento(modulo, drCol))
   End Sub
   Private Sub _EliminaAsiento(modulo As String, drCol As DataRow())
      If drCol Is Nothing OrElse drCol.Length = 0 Then Return

      For Each dr As DataRow In drCol
         If dr Is Nothing Then Return

         If Not dr.Table.Columns.Contains("IdEjercicio") OrElse Not dr.Table.Columns.Contains("IdPlanCuenta") OrElse Not dr.Table.Columns.Contains("IdAsiento") Then Return
         If Not IsNumeric(dr("IdEjercicio")) OrElse Not IsNumeric(dr("IdPlanCuenta")) OrElse Not IsNumeric(dr("IdAsiento")) Then Return

         Dim idEjercicioDefinitivo As Integer = dr.ValorNumericoPorDefecto("IdEjercicioDefinitivo", 0I)
         Dim idPlanCuentaDefinitivo As Integer = dr.ValorNumericoPorDefecto("IdPlanCuentaDefinitivo", 0I)
         Dim idAsientoDefinitivo As Integer = dr.ValorNumericoPorDefecto("IdAsientoDefinitivo", 0I)

         Dim idEjercicio As Integer = dr.ValorNumericoPorDefecto("IdEjercicio", 0I)
         Dim idPlanCuenta As Integer = dr.ValorNumericoPorDefecto("IdPlanCuenta", 0I)
         Dim idAsiento As Integer = dr.ValorNumericoPorDefecto("IdAsiento", 0I)

         'Primero desvinculo el asiento temporal de la gestión
         Dim sqlProcesos As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
         sqlProcesos.DesvinculaGestionAsiento(modulo, idEjercicio, idPlanCuenta, idAsiento)

         If modulo = "Ventas" Then
            'Cuando se procesa una Venta que se encuentra en CtaCte también se marca la Cuenta Corriente con el mismo asiento
            sqlProcesos.DesvinculaGestionAsiento("CuentasCorrientes", idEjercicio, idPlanCuenta, idAsiento)
         ElseIf modulo = "Compras" Then
            'Cuando se procesa una Compra que se encuentra en CtaCteProv también se marca la Cuenta Corriente Proveedores con el mismo asiento
            sqlProcesos.DesvinculaGestionAsiento("CuentasCorrientesProv", idEjercicio, idPlanCuenta, idAsiento)
         End If

         'Luego de desvincular la gestión puedo eliminar el asiento temporal
         Dim sqlTemporal As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
         sqlTemporal.Asiento_D_Detalle_Tmp(idEjercicio, idPlanCuenta, idAsiento)
         sqlTemporal.Asiento_D_Tmp(idEjercicio, idPlanCuenta, idAsiento)

         'Por último luego de borrar el temporal, puedo borrar el definitivo
         Dim sqlDefinitivo As SqlServer.ContabilidadAsientos = New SqlServer.ContabilidadAsientos(da)
         sqlDefinitivo.Asiento_D_Detalle(idEjercicioDefinitivo, idPlanCuentaDefinitivo, idAsientoDefinitivo)
         sqlDefinitivo.Asiento_D(idEjercicioDefinitivo, idPlanCuentaDefinitivo, idAsientoDefinitivo)
      Next

   End Sub
   Public Function ProcesarDesdeTemporal(FDesde As Date, FHasta As Date, tipoProceso As Entidades.ContabilidadProceso.Procesos) As DataTable
      ' creo tabla auxiliar para luego cargar los resultados y mostrarlos en pantalla
      Dim dtResultados = CrearTablaResultados()

      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.ContabilidadProcesos(da)
            Dim sqlAsientos = New SqlServer.ContabilidadAsientos(da)
            Dim SqlAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)

            Dim rEjercicio = New ContabilidadEjercicios(da)

            'obtengo los asientos generados para este tipo de proceso.
            Dim dtDatos = sql.ObtenerDatosTmp(FDesde, FHasta, tipoProceso.ToString())
            If dtDatos.Rows.Count > 0 Then

               Dim estadoAsientos = New ContabilidadEstadosAsientos(da).GetUnoPorDefectoAutomatico()

               For Each fila As DataRow In dtDatos.Rows
                  EjecutaSoloConTransaccion(
                     Function()
                        'saco el plan del asiento.
                        Dim idEjercicio = fila.Field(Of Integer)("IdEjercicio")
                        Dim idPlanCuenta = fila.Field(Of Integer)("idplanCuenta")
                        Dim fechaAsiento = fila.Field(Of Date)("FechaAsiento")
                        Dim nombreAsiento = fila.Field(Of String)("nombreAsiento")
                        Dim idSucursal = fila.Field(Of Integer)("IdSucursal")
                        'obtengo el ultimo id del los asientos
                        Dim idUltimoAsiento = fila.Field(Of Integer)("IdAsiento")

                        Try
                           Using dtDetalle = ArmarTablaDetalle(fila, idEjercicio, idPlanCuenta, idUltimoAsiento, tipoProceso.ToString(), dtResultados)
                              Dim idPeriodoActual = rEjercicio.GetPeriodoActual(idEjercicio, fechaAsiento)
                              If Not (rEjercicio.EstaPeriodoCerrado(idEjercicio, idPeriodoActual)) Then
                                 sqlAsientos.Asiento_I(idEjercicio, idPlanCuenta, idUltimoAsiento, fechaAsiento,
                                                       nombreAsiento, 0, idSucursal, tipoProceso.ToString(),
                                                       False, Nothing, estadoAsientos.IdEstadoAsiento, Entidades.ContabilidadAsiento.TiposAsiento.NORMAL.ToString())
                                 sqlAsientos.Asiento_I_Detalle(idEjercicio, idPlanCuenta, idUltimoAsiento, dtDetalle)
                                 SqlAsientosTmp.MarcarContabilidadDefinitiva(fila.ValorNumericoPorDefecto("IdEjercicio", 0I),
                                                                             fila.ValorNumericoPorDefecto("IdPlanCuenta", 0I),
                                                                             fila.ValorNumericoPorDefecto("IdAsiento", 0I),
                                                                             idEjercicio,
                                                                             idPlanCuenta,
                                                                             idUltimoAsiento)
                              Else
                                 For Each dr As DataRow In dtResultados.Select(String.Format("IdEjercicio = {0} AND IdPlanCuenta = {0} AND IdAsiento = {1}", fila("IdEjercicio"), fila("idPlanCuenta"), fila("IdAsiento")))
                                    dr("Observaciones") = String.Format("El ejercicio {0} se encuentra cerrado", idEjercicio)
                                 Next
                              End If
                           End Using
                        Catch ex As Exception
                           For Each dr As DataRow In dtResultados.Select(String.Format("IdEjercicio = {0} AND IdPlanCuenta = {0} AND IdAsiento = {1}", fila("IdEjercicio"), fila("idPlanCuenta"), fila("IdAsiento")))
                              dr("Observaciones") = ex.Message
                           Next
                           Throw
                        End Try
                        Return True
                     End Function)
               Next
            End If
            Return dtResultados
         End Function)
   End Function

#Region "HISTORICOS"

   Public Class ResultadoProcesoHistorico
      Private _procesados As Integer
      Public Property Procesados() As Integer
         Get
            Return _procesados
         End Get
         Set(value As Integer)
            _procesados = value
         End Set
      End Property
      Private _erroneos As Integer
      Public Property Erroneos() As Integer
         Get
            Return _erroneos
         End Get
         Set(value As Integer)
            _erroneos = value
         End Set
      End Property
   End Class

   Public Function ObtenerDatosVentas(fechaDesde As Date, fechaHasta As Date, Optional ConAsiento As Boolean = False, Optional NumeroAsiento As Integer = 0, Optional top As Integer = 0) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ContabilidadProcesos(da).ObtenerDatosVentas(actual.Sucursal.IdEmpresa, fechaDesde, fechaHasta, ConAsiento, NumeroAsiento, top))
   End Function

   Public Function CargarAsientosDeVentas(datosAProcesar As DataTable) As ResultadoProcesoHistorico
      Dim result As ResultadoProcesoHistorico = New ResultadoProcesoHistorico()
      Dim registrosProcesados As Integer = 0
      Dim registrosErronoes As Integer = 0

      Try
         Me.da.OpenConection()

         Dim ven As Reglas.Ventas = New Reglas.Ventas(da)
         Dim ent As Entidades.Venta

         For Each dr As DataRow In datosAProcesar.Rows
            If _progressBar IsNot Nothing Then
               _progressBar.PerformStep()
               Dim modu As Integer
               Math.DivRem(_progressBar.Value, 100, modu)
               If modu = 0 Then Application.DoEvents()
            End If
            If CBool(dr("Procesado")) Then Continue For
            Try
               registrosProcesados += 1
               Me.da.BeginTransaction()

               ent = ven.GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                 dr("IdTipoComprobante").ToString(),
                                 dr("Letra").ToString(),
                                 Int16.Parse(dr("CentroEmisor").ToString()),
                                 Int64.Parse(dr("NumeroComprobante").ToString()))

               ent.tablaContabilidad = Me.GetRubroVenta(ent)

               If ent.tablaContabilidad.Rows.Count = 0 Then
                  Throw New Exception(String.Format("Faltan setear el rubro '{0}' para el plan de cuentas {1}.", ent.VentasProductos(0).Producto.IdRubro, ent.TipoComprobante.IdPlanCuenta))
               End If

               Dim coe As Decimal = ent.TipoComprobante.CoeficienteValores
               ent.ImportePesos = ent.ImportePesos * coe
               ent.ImporteTickets = ent.ImporteTickets * coe
               ent.ImporteTransfBancaria = ent.ImporteTransfBancaria * coe

               'For Each vp As Entidades.VentaProducto In ent.VentasProductos
               '   vp.ImporteTotal = vp.ImporteTotal * coe
               '   vp.ImporteTotalNeto = vp.ImporteTotalNeto * coe
               'Next

               Dim ctbl As Contabilidad = New Contabilidad(da)
               If _textoAvance IsNot Nothing Then
                  _textoAvance.Text = "Ventas: " + ctbl.ObtenerDescAsiento(ent)
                  Application.DoEvents()
               End If

               ctbl.RegistraContabilidad(ent)   ''ven.CargarContabilidad2(ent)
               Me.da.CommitTransaction()
            Catch ex As Exception
               Me.da.RollbakTransaction()
               dr("MensajeError") = ex.Message
               registrosErronoes += 1
               'Throw New Exception(String.Format("Error de generación de Ventas en el registro Nro. {0} ({1}-{2}-{3}-{4}-{5}).",
               '                                  registrosProcesados.ToString(),
               '                                  dr("IdSucursal"),
               '                                  dr("IdTipoComprobante"),
               '                                  dr("Letra"),
               '                                  dr("CentroEmisor"),
               '                                  dr("NumeroComprobante")), ex)
            Finally
               dr("Procesado") = True
            End Try
         Next

         '' ''Me.da.CommitTransaction()
         result.Procesados = registrosProcesados
         result.Erroneos = registrosErronoes

         Return result
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function ObtenerDatosCtaCteClte(fechaDesde As Date, fechaHasta As Date, Optional ConAsiento As Boolean = False, Optional NumeroAsiento As Integer = 0, Optional top As Integer = 0) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ContabilidadProcesos(da).ObtenerDatosCtaCteClte(actual.Sucursal.IdEmpresa, fechaDesde, fechaHasta, ConAsiento, NumeroAsiento, top))
   End Function

   Public Function CargarAsientosDeCtaCteClte(datosAProcesar As DataTable) As ResultadoProcesoHistorico
      Dim result As ResultadoProcesoHistorico = New ResultadoProcesoHistorico()
      Dim registrosProcesados As Integer = 0
      Dim registrosErronoes As Integer = 0

      Try
         Me.da.OpenConection()

         Dim ccc As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes(da)
         Dim ent As Entidades.CuentaCorriente

         For Each dr As DataRow In datosAProcesar.Rows
            If _progressBar IsNot Nothing Then
               _progressBar.PerformStep()
               Dim modu As Integer
               Math.DivRem(_progressBar.Value, 100, modu)
               If modu = 0 Then Application.DoEvents()
            End If
            If CBool(dr("Procesado")) Then Continue For
            Try
               registrosProcesados += 1
               Me.da.BeginTransaction()

               ent = ccc._GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                 dr("IdTipoComprobante").ToString(),
                                 dr("Letra").ToString(),
                                 Int32.Parse(dr("CentroEmisor").ToString()),
                                 Int64.Parse(dr("NumeroComprobante").ToString()))

               Dim ctbl As Contabilidad = New Contabilidad(da)
               If _textoAvance IsNot Nothing Then
                  _textoAvance.Text = "Cta Cte Cliente: " + ctbl.ObtenerDescAsiento(ent)
                  Application.DoEvents()
               End If

               ctbl.RegistraContabilidad(ent)   ''ven.CargarContabilidad2(ent)
               Me.da.CommitTransaction()
            Catch ex As Exception
               Me.da.RollbakTransaction()
               dr("MensajeError") = ex.Message
               registrosErronoes += 1
               'Throw New Exception(String.Format("Error de generación de Ventas en el registro Nro. {0}.", registrosProcesados.ToString()), ex)
            Finally
               dr("Procesado") = True
            End Try
         Next

         '' ''Me.da.CommitTransaction()

         result.Procesados = registrosProcesados
         result.Erroneos = registrosErronoes

         Return result
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function ObtenerDatosCompras(fechaDesde As Date, fechaHasta As Date, Optional ConAsiento As Boolean = False, Optional NumeroAsiento As Integer = 0, Optional top As Integer = 0) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ContabilidadProcesos(da).ObtenerDatosCompra(actual.Sucursal.IdEmpresa, fechaDesde, fechaHasta, ConAsiento, NumeroAsiento, top))
   End Function

   Public Function CargarAsientosDeCompras(datosAProcesar As DataTable) As ResultadoProcesoHistorico
      Dim result As ResultadoProcesoHistorico = New ResultadoProcesoHistorico()
      Dim registrosProcesados As Integer = 0
      Dim registrosErronoes As Integer = 0

      Try
         Me.da.OpenConection()

         Dim ven = New Reglas.MovimientosStock(da)
         Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
         Dim ent As Entidades.MovimientoStock
         Dim idPlanCuenta As Integer

         For Each dr As DataRow In datosAProcesar.Rows
            If _progressBar IsNot Nothing Then
               _progressBar.PerformStep()
               Dim modu As Integer
               Math.DivRem(_progressBar.Value, 100, modu)
               If modu = 0 Then Application.DoEvents()
            End If
            If CBool(dr("Procesado")) Then Continue For
            Try
               registrosProcesados += 1
               Me.da.BeginTransaction()
               ent = ven.GetUnoPorComprobante(Int32.Parse(dr("IdSucursal").ToString()),
                                              dr("IdTipoComprobante").ToString(),
                                              dr("Letra").ToString(),
                                              Int16.Parse(dr("CentroEmisor").ToString()),
                                              Int64.Parse(dr("NumeroComprobante").ToString()),
                                              Int64.Parse(dr("IdProveedor").ToString()))

               idPlanCuenta = ent.Compra.TipoComprobante.IdPlanCuenta '  getPlanCtaxDoc(ent.Compra.TipoComprobante.IdTipoComprobante)  ''Me.getPlanCtaxMovimiento(ent.TipoMovimiento.IdTipoMovimiento)

               ent.tablaContabilidad = Me.GetRubroCompra(ent, idPlanCuenta)

               'YA SE CORRIGIÓ LA CARGA DE MOVIMIENTOS DE COMPRAS Y AHORA 
               'LOS IMPORTES DE LAS LÍNEAS VIENEN CON EL SIGNO CORRECTO.
               'POR LO QUE NO HACE FALTA CAMBIAR MAS EL SIGMO
               'For Each VP As Entidades.CompraProducto In ent.Compra.ComprasProductos
               '   VP.ImporteTotal = VP.ImporteTotal * ent.Compra.TipoComprobante.CoeficienteValores
               '   VP.ImporteTotalNeto = VP.ImporteTotalNeto * ent.Compra.TipoComprobante.CoeficienteValores
               'Next

               Dim ctbl As Contabilidad = New Contabilidad(da)
               If _textoAvance IsNot Nothing Then
                  _textoAvance.Text = "Compras: " + ctbl.ObtenerDescAsiento(ent.Compra)
                  Application.DoEvents()
               End If

               ctbl.RegistraContabilidad(ent)   ''ven.CargarContabilidad(ent)
               Me.da.CommitTransaction()
            Catch ex As Exception
               Me.da.RollbakTransaction()
               dr("MensajeError") = ex.Message
               registrosErronoes += 1
               'Throw New Exception(String.Format("Error de generación de Ventas en el registro Nro. {0}.", registrosProcesados.ToString()), ex)
            Finally
               dr("Procesado") = True
            End Try
         Next

         result.Procesados = registrosProcesados
         result.Erroneos = registrosErronoes

         Return result
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function ObtenerDatosCtaCteProv(fechaDesde As Date, fechaHasta As Date, Optional ConAsiento As Boolean = False, Optional NumeroAsiento As Integer = 0, Optional top As Integer = 0) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ContabilidadProcesos(da).ObtenerDatosCtaCteProv(actual.Sucursal.IdEmpresa, fechaDesde, fechaHasta, ConAsiento, NumeroAsiento, top))
   End Function

   Public Function CargarAsientosDeCtaCteProv(datosAProcesar As DataTable) As ResultadoProcesoHistorico
      Dim result As ResultadoProcesoHistorico = New ResultadoProcesoHistorico()
      Dim registrosProcesados As Integer = 0
      Dim registrosErronoes As Integer = 0

      Try
         Me.da.OpenConection()

         Dim ccp As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv(da)
         Dim ent As Entidades.CuentaCorrienteProv

         For Each dr As DataRow In datosAProcesar.Rows
            If _progressBar IsNot Nothing Then
               _progressBar.PerformStep()
               Dim modu As Integer
               Math.DivRem(_progressBar.Value, 100, modu)
               If modu = 0 Then Application.DoEvents()
            End If
            If CBool(dr("Procesado")) Then Continue For
            Try
               registrosProcesados += 1
               Me.da.BeginTransaction()

               ent = ccp.GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                Int64.Parse(dr("IdProveedor").ToString()),
                                dr("IdTipoComprobante").ToString(),
                                dr("Letra").ToString(),
                                Int32.Parse(dr("CentroEmisor").ToString()),
                                Int64.Parse(dr("NumeroComprobante").ToString()))



               Dim ctbl As Contabilidad = New Contabilidad(da)
               If _textoAvance IsNot Nothing Then
                  _textoAvance.Text = "Cta Cte Proveedor: " + ctbl.ObtenerDescAsiento(ent)
                  Application.DoEvents()
               End If

               ctbl.RegistraContabilidad(ent)   ''ven.CargarContabilidad2(ent)
               Me.da.CommitTransaction()
            Catch ex As Exception
               Me.da.RollbakTransaction()
               dr("MensajeError") = ex.Message
               registrosErronoes += 1
               'Throw New Exception(String.Format("Error de generación de Ventas en el registro Nro. {0}.", registrosProcesados.ToString()), ex)
            Finally
               dr("Procesado") = True
            End Try
         Next

         result.Procesados = registrosProcesados
         result.Erroneos = registrosErronoes

         Return result
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function ObtenerDatosCaja(fechaDesde As Date, fechaHasta As Date, Optional ConAsiento As Boolean = False, Optional NumeroAsiento As Integer = 0, Optional top As Integer = 0) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ContabilidadProcesos(da).ObtenerDatosCaja(actual.Sucursal.IdEmpresa, fechaDesde, fechaHasta, ConAsiento, NumeroAsiento, top))
   End Function

   Public Function CargarAsientosDeCaja(datosAProcesar As DataTable) As ResultadoProcesoHistorico
      Dim result As ResultadoProcesoHistorico = New ResultadoProcesoHistorico()
      Dim registrosProcesados As Integer = 0
      Dim registrosErronoes As Integer = 0

      Try
         Me.da.OpenConection()
         '' ''Me.da.BeginTransaction()

         Dim caj As Reglas.CajaDetalles = New Reglas.CajaDetalles(da)
         Dim ent As Entidades.CajaDetalles

         For Each dr As DataRow In datosAProcesar.Rows
            If _progressBar IsNot Nothing Then
               _progressBar.PerformStep()
               Dim modu As Integer
               Math.DivRem(_progressBar.Value, 100, modu)
               If modu = 0 Then Application.DoEvents()
            End If
            If CBool(dr("Procesado")) Then Continue For
            Try
               registrosProcesados += 1
               Me.da.BeginTransaction()

               ent = caj._GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                 Int32.Parse(dr("IdCaja").ToString()),
                                 Int32.Parse(dr("NumeroPlanilla").ToString()),
                                 Int32.Parse(dr("NumeroMovimiento").ToString()))

               Dim ctbl As Contabilidad = New Contabilidad(da)
               If _textoAvance IsNot Nothing Then
                  _textoAvance.Text = "Caja: " + ctbl.ObtenerDescAsiento(ent)
                  Application.DoEvents()
               End If

               ctbl.RegistraContabilidad(ent)   ''caj.CargarContabilidad2(ent)
               Me.da.CommitTransaction()
            Catch ex As Exception
               Me.da.RollbakTransaction()
               dr("MensajeError") = ex.Message
               registrosErronoes += 1
               'Throw New Exception(String.Format("Error de generación de Ventas en el registro Nro. {0}.", registrosProcesados.ToString()), ex)
            Finally
               dr("Procesado") = True
            End Try
         Next

         '' ''Me.da.CommitTransaction()
         result.Procesados = registrosProcesados
         result.Erroneos = registrosErronoes

         Return result
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function ObtenerDatosLibroBanco(fechaDesde As Date, fechaHasta As Date, Optional ConAsiento As Boolean = False, Optional NumeroAsiento As Integer = 0, Optional top As Integer = 0) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ContabilidadProcesos(da).ObtenerDatosLibroBanco(actual.Sucursal.IdEmpresa, fechaDesde, fechaHasta, ConAsiento, NumeroAsiento, top))
   End Function

   Public Function CargarAsientosDeBancos(datosAProcesar As DataTable) As ResultadoProcesoHistorico
      Dim result As ResultadoProcesoHistorico = New ResultadoProcesoHistorico()
      Dim registrosProcesados As Integer = 0
      Dim registrosErronoes As Integer = 0

      Try
         Me.da.OpenConection()
         '' ''Me.da.BeginTransaction()

         Dim caj As Reglas.LibroBancos = New Reglas.LibroBancos(da)
         Dim ent As Entidades.LibroBanco

         For Each dr As DataRow In datosAProcesar.Rows
            If _progressBar IsNot Nothing Then
               _progressBar.PerformStep()
               Dim modu As Integer
               Math.DivRem(_progressBar.Value, 100, modu)
               If modu = 0 Then Application.DoEvents()
            End If
            If CBool(dr("Procesado")) Then Continue For
            Try
               registrosProcesados += 1
               Me.da.BeginTransaction()

               ent = caj.GetUno(Int32.Parse(dr("IdSucursal").ToString()),
                                Int32.Parse(dr("IdCuentaBancaria").ToString()),
                                Int32.Parse(dr("NumeroMovimiento").ToString()))

               ent.IdSucursal = Int32.Parse(dr("IdSucursal").ToString())

               Dim ctbl As Contabilidad = New Contabilidad(da)
               If _textoAvance IsNot Nothing Then
                  _textoAvance.Text = "Banco: " + ctbl.ObtenerDescAsiento(ent)
                  Application.DoEvents()
               End If

               ctbl.RegistraContabilidad(ent)   ''caj.CargarContabilidad2(ent)
               Me.da.CommitTransaction()
            Catch ex As Exception
               Me.da.RollbakTransaction()
               dr("MensajeError") = ex.Message
               registrosErronoes += 1
               'Throw New Exception(String.Format("Error de generación de Ventas en el registro Nro. {0}.", registrosProcesados.ToString()), ex)
            Finally
               dr("Procesado") = True
            End Try
         Next

         '' ''Me.da.CommitTransaction()
         result.Procesados = registrosProcesados
         result.Erroneos = registrosErronoes

         Return result
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function ObtenerDatosDepositosBancarios(fechaDesde As Date, fechaHasta As Date, Optional ConAsiento As Boolean = False, Optional NumeroAsiento As Integer = 0, Optional top As Integer = 0) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ContabilidadProcesos(da).ObtenerDatosDepositosBancarios(actual.Sucursal.IdEmpresa, fechaDesde, fechaHasta, ConAsiento, NumeroAsiento, top))
   End Function

   Public Function CargarAsientosDeDepositoBancario(datosAProcesar As DataTable) As ResultadoProcesoHistorico
      Dim result As ResultadoProcesoHistorico = New ResultadoProcesoHistorico()
      Dim registrosProcesados As Integer = 0
      Dim registrosErronoes As Integer = 0

      Try
         Me.da.OpenConection()
         '' ''Me.da.BeginTransaction()

         Dim caj As Reglas.Depositos = New Reglas.Depositos(da)
         Dim ent As Entidades.Deposito

         For Each dr As DataRow In datosAProcesar.Rows
            If _progressBar IsNot Nothing Then
               _progressBar.PerformStep()
               Dim modu As Integer
               Math.DivRem(_progressBar.Value, 100, modu)
               If modu = 0 Then Application.DoEvents()
            End If
            If CBool(dr("Procesado")) Then Continue For
            Try
               registrosProcesados += 1
               Me.da.BeginTransaction()

               ent = caj.GetUna(Int32.Parse(dr("IdSucursal").ToString()),
                                Long.Parse(dr("NumeroDeposito").ToString()), dr("IdTipoComprobante").ToString())

               Dim ctbl As Contabilidad = New Contabilidad(da)
               If _textoAvance IsNot Nothing Then
                  _textoAvance.Text = "Deposito Bancario: " + ctbl.ObtenerDescAsiento(ent)
                  Application.DoEvents()
               End If

               ctbl.RegistraContabilidad(ent)   ''caj.CargarContabilidad2(ent)
               Me.da.CommitTransaction()
            Catch ex As Exception
               Me.da.RollbakTransaction()
               dr("MensajeError") = ex.Message
               registrosErronoes += 1
               'Throw New Exception(String.Format("Error de generación de Ventas en el registro Nro. {0}.", registrosProcesados.ToString()), ex)
            Finally
               dr("Procesado") = True
            End Try
         Next

         '' ''Me.da.CommitTransaction()
         result.Procesados = registrosProcesados
         result.Erroneos = registrosErronoes

         Return result
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetAsientoRefundicion(idEjercicio As Int32, sucursales As List(Of Integer), idPlanCuenta As Integer) As DataTable
      Try
         da.OpenConection()

         Dim sql As SqlServer.ContabilidadProcesos
         sql = New SqlServer.ContabilidadProcesos(da)

         Dim dt As DataTable = sql.GetAsientoRefundicion(idEjercicio, sucursales, idPlanCuenta)

         Dim dtPre As DataTable = dt.Clone()
         Dim res As Decimal = 0
         Dim dr2 As DataRow

         For Each dr As DataRow In dt.Rows
            res = Decimal.Parse(dr("Debe").ToString()) - Decimal.Parse(dr("Haber").ToString())
            If res = 0 Then
               Continue For
            End If
            dr2 = dtPre.NewRow()
            dr2("IdCuenta") = dr("IdCuenta")
            dr2("IdCentroCosto") = dr("IdCentroCosto")
            dr2("NombreCentroCosto") = dr("NombreCentroCosto")
            dr2("NombreCuenta") = dr("NombreCuenta")
            If res > 0 Then
               dr2("Debe") = 0
               dr2("Haber") = res
            Else
               dr2("Debe") = Math.Abs(res)
               dr2("Haber") = 0
            End If

            dtPre.Rows.Add(dr2)
         Next

         Return dtPre

      Catch ex As Exception
         Throw
      Finally
         da.CloseConection()
      End Try
   End Function





   Public Function ConsultarAsientosParaAjustePorInflacion(idPlanCuenta As Integer,
                                                           idEjercicio As Integer,
                                                           sucursales As List(Of Integer)) As DataSet
      Try
         da.OpenConection()

         Dim ds As DataSet = New DataSet()

         'Obtener los Periodos del ejercicio con el coeficiente
         Dim rCE = New ContabilidadEjercicios(da)
         Dim sProc = New SqlServer.ContabilidadProcesos(da)

         Dim dtPeriodos As DataTable
         Dim ejercicio As Entidades.ContabilidadEjercicio

         Dim mes As Integer
         Dim ano As Integer
         Dim primerDia As DateTime
         Dim coeAnterior As Decimal
         Dim desde As DateTime
         Dim hasta As DateTime
         Dim dr As DataRow
         Dim P12 As Decimal
         Dim PX As Decimal

         Dim ejercicioAnterior As Entidades.ContabilidadEjercicio
         ejercicio = rCE.GetUna(idEjercicio)

         'del ejercicio actual obtengo el último indice de inflación
         'busco el último periodo
         Dim maxP12 = ejercicio.DetallesPeriodos.AsEnumerable() _
                                    .Where(Function(row) row.Field(Of Decimal?)("CoeficienteAjustePorInflacion").GetValueOrDefault() <> 0) _
                                     .OrderByDescending(Function(row) row.Field(Of Integer)("Orden")) _
                                     .First()

         If maxP12 IsNot Nothing Then
            If Not String.IsNullOrEmpty(maxP12("CoeficienteAjustePorInflacion").ToString()) Then
               P12 = Decimal.Parse(maxP12("CoeficienteAjustePorInflacion").ToString())
            End If
         Else
            MessageBox.Show("No tiene los coeficientes de ajuste por inflación cargados en el sistemas")
            Return Nothing
         End If

         dtPeriodos = ejercicio.DetallesPeriodos

         'Para obtener el último coeficiente previo al ejercicio tengo
         'que restar 1 al ejercicio y ver el nro. de Orden mas grande (normalmente el 12)
         ejercicioAnterior = rCE.GetUna(idEjercicio - 1)
         If ejercicioAnterior.DetallesPeriodos.Count > 0 Then
            'busco el último periodo
            Dim maxRow As DataRow = ejercicioAnterior.DetallesPeriodos.AsEnumerable() _
                                     .OrderByDescending(Function(row) row.Field(Of Integer)("Orden")) _
                                     .First()
            dr = ejercicio.DetallesPeriodos.NewRow()
            dr.CopiarValores(maxRow)
            dtPeriodos.Rows.InsertAt(dr, 0)
         End If

         dtPeriodos.Columns.Add("Desde", GetType(DateTime))
         dtPeriodos.Columns.Add("Hasta", GetType(DateTime))
         dtPeriodos.Columns.Add("IndiceInflacion", GetType(Decimal))

         For Each drPE As DataRow In dtPeriodos.Rows
            mes = Int32.Parse(drPE("IdPeriodo").ToString().Substring(0, 2))
            ano = Int32.Parse(drPE("IdPeriodo").ToString().Substring(3, 4))
            primerDia = New DateTime(ano, mes, 1)
            drPE("Desde") = primerDia
            drPE("Hasta") = primerDia.AddMonths(1).AddDays(-1)
            If coeAnterior <> 0 Then
               If Not String.IsNullOrEmpty(drPE("CoeficienteAjustePorInflacion").ToString()) Then
                  drPE("IndiceInflacion") = Decimal.Round(((-1 + (Decimal.Parse(drPE("CoeficienteAjustePorInflacion").ToString()) / coeAnterior)) * 100), 2)
               Else
                  drPE("IndiceInflacion") = Decimal.Round(0, 2)
               End If
            End If
            If Not String.IsNullOrEmpty(drPE("CoeficienteAjustePorInflacion").ToString()) Then
               coeAnterior = Decimal.Parse(drPE("CoeficienteAjustePorInflacion").ToString())
            Else
               coeAnterior = 0
            End If
         Next
         ds.Tables.Add("Periodos", dtPeriodos)

         'recupera todas las cuentas a ajustar por inflación
         Dim dtAsientos As DataTable = sProc.GetAsientosAjusteInflacionPorPeriodo(idPlanCuenta, idEjercicio, sucursales)
         Dim dtCuentasPeriodos = ArmaDataTablePeriodo()

         For Each drP As DataRow In dtPeriodos.Rows
            If Not String.IsNullOrEmpty(drP("CoeficienteAjustePorInflacion").ToString()) Then
               PX = Decimal.Parse(drP("CoeficienteAjustePorInflacion").ToString())
            Else
               PX = 1
            End If
            desde = DateTime.Parse(drP("Desde").ToString())
            hasta = DateTime.Parse(drP("Hasta").ToString().Replace("00:00:00", " 23:59:59"))
            Dim periodosAsientos = From row In dtAsientos.AsEnumerable()
                                   Where row.Field(Of DateTime)("FechaAsiento") >= desde AndAlso row.Field(Of DateTime)("FechaAsiento") <= hasta

            ' Agrupar y sumar los valores
            Dim periodosAgrupados = From row In periodosAsientos.AsEnumerable()
                                    Group row By IdCuenta = row.Field(Of Int64)("IdCuenta"),
                                 NombreCuenta = row.Field(Of String)("NombreCuenta"),
                                 IdCentroCosto = row.Field(Of Integer?)("IdCentroCosto"),
                                 NombreCentroCosto = row.Field(Of String)("NombreCentroCosto")
                                 Into Grupo = Group Select New With {
                              .IdCuenta = IdCuenta,
                              .NombreCuenta = NombreCuenta,
                               .IdCentroCosto = IdCentroCosto,
                               .NombreCentroCosto = NombreCentroCosto,
                              .Debe = Grupo.Sum(Function(r) r.Field(Of Decimal)("Debe")),
                              .Haber = Grupo.Sum(Function(r) r.Field(Of Decimal)("Haber"))
                          }


            For Each drA In periodosAgrupados
               dr = dtCuentasPeriodos.NewRow()


               dr("IdPeriodo") = drP("IdPeriodo")
               dr("IdCuenta") = drA.IdCuenta
               dr("NombreCuenta") = drA.NombreCuenta
               If drA.IdCentroCosto.HasValue Then
                  dr("IdCentroCosto") = drA.IdCentroCosto.Value
                  dr("NombreCentroCosto") = drA.NombreCentroCosto
               End If
               dr("Debe") = drA.Debe
               dr("Haber") = drA.Haber
               dr("Debe2") = Decimal.Round(drA.Debe * (Decimal.Round(P12, 2) / Decimal.Round(PX, 2)), 2)
               dr("Haber2") = Decimal.Round(drA.Haber * (Decimal.Round(P12, 2) / Decimal.Round(PX, 2)), 2)
               dr("DebeDif") = Decimal.Round((drA.Debe * (Decimal.Round(P12, 2) / Decimal.Round(PX, 2))) - drA.Debe, 2)
               dr("HaberDif") = Decimal.Round((drA.Haber * (Decimal.Round(P12, 2) / Decimal.Round(PX, 2))) - drA.Haber, 2)

               dtCuentasPeriodos.Rows.Add(dr)
            Next
         Next
         ds.Tables.Add("CuentasPeriodos", dtCuentasPeriodos)

         Dim cuentas = From row In dtCuentasPeriodos.AsEnumerable()

         Dim grupoPorCuenta = From ctas In cuentas.AsEnumerable()
                              Group ctas By IdCuenta = ctas.Field(Of Int64)("IdCuenta"),
                                 NombreCuenta = ctas.Field(Of String)("NombreCuenta"),
                                 IdCentroCosto = ctas.Field(Of Int32?)("IdCentroCosto"),
                                 NombreCentroCosto = ctas.Field(Of String)("NombreCentroCosto")
                                 Into Grupo = Group Select New With {
                              .IdCuenta = IdCuenta,
                              .NombreCuenta = NombreCuenta,
                               .IdCentroCosto = IdCentroCosto,
                               .NombreCentroCosto = NombreCentroCosto,
                              .DebeDif = Grupo.Sum(Function(r) r.Field(Of Decimal)("DebeDif")),
                              .HaberDif = Grupo.Sum(Function(r) r.Field(Of Decimal)("HaberDif"))
                  }

         Dim dtCuentasEjercicio = ArmaDataTableEjercicio()
         If grupoPorCuenta.Count > 0 Then

            For Each drB In grupoPorCuenta
               If drB.DebeDif = 0 AndAlso drB.HaberDif = 0 Then
                  'si no hay valores no inserto ningún registro
                  Continue For
               End If
               dr = dtCuentasEjercicio.NewRow()
               dr("IdCuenta") = drB.IdCuenta
               dr("NombreCuenta") = drB.NombreCuenta
               If drB.IdCentroCosto.HasValue Then
                  dr("IdCentroCosto") = drB.IdCentroCosto.Value
                  dr("NombreCentroCosto") = drB.NombreCentroCosto
               End If
               If drB.DebeDif > drB.HaberDif Then
                  dr("Debe") = Decimal.Round(drB.DebeDif - drB.HaberDif, 2)
                  dr("Haber") = 0
               Else
                  dr("Haber") = Decimal.Round(drB.HaberDif - drB.DebeDif, 2)
                  dr("Debe") = 0
               End If
               dtCuentasEjercicio.Rows.Add(dr)
            Next
         End If
         ds.Tables.Add("CuentasEjercicio", dtCuentasEjercicio)


         Return ds
      Catch ex As Exception
         Throw
      Finally
         da.CloseConection()
      End Try
   End Function

   Private Function ArmaDataTablePeriodo() As DataTable
      Dim dt = New DataTable()
      dt.Columns.Add("IdPeriodo", GetType(String))
      dt.Columns.Add("IdCuenta", GetType(Int64))
      dt.Columns.Add("NombreCuenta", GetType(String))
      dt.Columns.Add("IdCentroCosto", GetType(Integer))
      dt.Columns.Add("NombreCentroCosto", GetType(String))
      dt.Columns.Add("Debe", GetType(Decimal))
      dt.Columns.Add("Haber", GetType(Decimal))
      dt.Columns.Add("Debe2", GetType(Decimal))
      dt.Columns.Add("Haber2", GetType(Decimal))
      dt.Columns.Add("DebeDif", GetType(Decimal))
      dt.Columns.Add("HaberDif", GetType(Decimal))
      Return dt
   End Function

   Private Function ArmaDataTableEjercicio() As DataTable
      Dim dt = New DataTable()
      dt.Columns.Add("IdCuenta", GetType(Int64))
      dt.Columns.Add("NombreCuenta", GetType(String))
      dt.Columns.Add("IdCentroCosto", GetType(Integer))
      dt.Columns.Add("NombreCentroCosto", GetType(String))
      dt.Columns.Add("Debe", GetType(Decimal))
      dt.Columns.Add("Haber", GetType(Decimal))
      dt.Columns.Add("IdTipoReferencia", GetType(String))
      dt.Columns.Add("Referencia", GetType(String))
      Return dt
   End Function

#End Region

End Class
