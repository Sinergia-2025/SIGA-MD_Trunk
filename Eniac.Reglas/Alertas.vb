Public Class Alertas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Alertas"
      da = accesoDatos
   End Sub

#End Region

   Protected Overridable Sub CargaAlertas(idUsuario As String, idSucursal As Integer, oLis As List(Of Entidades.Alerta))


      Dim o As Entidades.Alerta
      Dim oUsuario = New Usuarios()

      If oUsuario.TienePermisos(idUsuario, idSucursal, "AlertaLicenciasVsDispositivos") Then
         Dim cantDifLicencias = New SqlServer.Dispositivos(da).GetLicenciasVsDispositivos(Publicos.DiasControlDeLicencias).Rows.Count
         If cantDifLicencias > 0 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = "Licencias vs Dispositivos."
            o.MensajeDeAlerta = cantDifLicencias.ToString() + " Licencias vs Dispositivos."
            o.Key = Entidades.Alerta.Tipos.LicenciasVsDispositivos
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Blue
            o.OrdenPrioridad = 1
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InfProductosSinStock") Then
         Dim cantSinStock = New SqlServer.ProductosSucursales(da).GetCantidadDeProductosSinStock(idSucursal)
         If cantSinStock > 0 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = "Productos Sin Stock."
            o.MensajeDeAlerta = cantSinStock.ToString() + " Productos Sin Stock."
            o.Key = Entidades.Alerta.Tipos.ProductosSinStock
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InfChequesADepositar") Then
         Dim aDepositar = New SqlServer.Cheques(da).GetCantidadADepositar(idSucursal, Date.Now)
         If aDepositar > 0 Then
            o = New Entidades.Alerta()
            o.MensajeDeAlerta = aDepositar.ToString() + " Cheques a Depositar."
            o.Key = Entidades.Alerta.Tipos.ChequesADepositar
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Yellow
            o.OrdenPrioridad = 200
            oLis.Add(o)
         End If
      End If


      '-- 36589 - Las alertas que se muestran deben ser sólo las de la Sucursal de la misma Empresa (mismo Cuit) y de las sucursales vinculadas por más que tengan diferente CUIT
      Dim SucursalesAlerta As List(Of Entidades.Sucursal) = New Reglas.Sucursales().GetParaAlerta()
      If oUsuario.TienePermisos(idUsuario, idSucursal, "Remitos-RemitosSinFacturar") Then

         Dim count = New SqlServer.Ventas(da).GetRemitosSinFacturar(SucursalesAlerta).Rows.Count
         If count > 0 Then
            o = New Entidades.Alerta With {
               .MensajeDeAlerta = String.Format("Existen {0} remitos sin facturar.", count),
               .Key = Entidades.Alerta.Tipos.RemitosSinFacturar,
               .Grupo = Entidades.Alerta.Grupos.Alertas,
               .Color = Drawing.Color.Red,
               .OrdenPrioridad = 200
            }
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InfPuntoDePedidoDeProductos") Then
         Dim aDepositar As Integer = New SqlServer.ProductosSucursales(da).GetCantidadPuntoDePedidoDeProductos(idSucursal)
         If aDepositar > 0 Then
            o = New Entidades.Alerta()
            o.MensajeDeAlerta = aDepositar.ToString() + " Puntos de Pedidos Alcanzados."
            o.Key = Entidades.Alerta.Tipos.PuntoDePedidosDeProductos
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InfStockMinimoDeProductos") Then
         Dim aDepositar As Integer = New SqlServer.ProductosSucursales(da).GetCantidadStockMinimoDeProductos(idSucursal)
         If aDepositar > 0 Then
            o = New Entidades.Alerta()
            o.MensajeDeAlerta = aDepositar.ToString() + " Stocks Minimos Alcanzados."
            o.Key = Entidades.Alerta.Tipos.StockMinimoDeProductos
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            oLis.Add(o)
         End If
      End If

      '# ALERTA DE VENCIMIENTO DE CERTIFICADO FE
      If Publicos.TieneModuloFacturacionElectronica AndAlso (oUsuario.TienePermisos(idUsuario, idSucursal, "FacturacionRapida") OrElse oUsuario.TienePermisos(idUsuario, idSucursal, "FacturacionV2")) Then
         Dim diasAVencerCE As Integer = DateDiff(DateInterval.Day, Today, Reglas.Publicos.VencimientoCertificadoFE).ToInteger()
         If diasAVencerCE <= 30 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = diasAVencerCE.ToString()
            o.MensajeDeAlerta = If(diasAVencerCE <= 0, "Su certificado digital se encuentra vencido.", String.Format("Su certificado digital está próximo a vencerse ({0} días restantes).", diasAVencerCE))
            o.Key = Entidades.Alerta.Tipos.VencimientoCertificadoDigital
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.MostrarPopUp = diasAVencerCE <= 0
            o.OrdenPrioridad = 1
            oLis.Add(o)
         End If
      End If

      'ALERTAS DE CONSISTENCIA DE LA INFORMACION.
      If oUsuario.TienePermisos(idUsuario, idSucursal, "InconsistStockVsStockLotes") Then
         Dim cantStockDifStockLotes As Integer = New SqlServer.ProductosSucursales(da).GetCantidadDeInconsistenciaStockVsStockLotes(idSucursal)
         If cantStockDifStockLotes > 0 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = "Inconsistencias de Stock vs Stock por Lotes"
            o.MensajeDeAlerta = cantStockDifStockLotes.ToString() + " inconsistencias de Stock vs Stock por Lotes"
            o.Key = Entidades.Alerta.Tipos.InconsistenciaStockVsStockLotes
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InconsistStockVsMovDeStock") Then
         Dim cantStockDifHistorico As Integer = New SqlServer.ProductosSucursales(da).GetCantidadDeInconsistenciaStockVsMovimientosDeStock(idSucursal)
         If cantStockDifHistorico > 0 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = "Inconsistencias de Sucursales vs Movim. de Stock"
            o.MensajeDeAlerta = cantStockDifHistorico.ToString() + " inconsistencias de Sucursales vs Movim. Stock"
            o.Key = Entidades.Alerta.Tipos.InconsistenciaStockVsMovimientosDeStock
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InconsistDepositoVsSucursales") Then
         Dim cantStockDifHistorico As Integer = New SqlServer.ProductosDepositos(da).GetCantidadDeInconsistenciaDepositosVsSucursales(idSucursal)
         If cantStockDifHistorico > 0 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = "Inconsistencias de Depositos vs Sucursales"
            o.MensajeDeAlerta = cantStockDifHistorico.ToString() + " inconsistencias de Depositos vs Sucursales"
            o.Key = Entidades.Alerta.Tipos.InconsistenciaDepositosVsSucursales
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InconsistDepositoVsUbicaciones") Then
         Dim cantStockDifHistorico As Integer = New SqlServer.ProductosUbicaciones(da).GetCantidadDeInconsistenciaDepositosVsUbicaciones(idSucursal)
         If cantStockDifHistorico > 0 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = "Inconsistencias de Depositos vs Ubicaciones"
            o.MensajeDeAlerta = cantStockDifHistorico.ToString() + " inconsistencias de Depositos vs Ubicaciones"
            o.Key = Entidades.Alerta.Tipos.InconsistenciaDepositosVsUbicaciones
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InconsistUbicacionesVsMovStock") Then
         Dim cantStockDifHistorico As Integer = New SqlServer.ProductosUbicaciones(da).GetCantidadDeInconsistenciaUbicacionesVsMovStock(idSucursal)
         If cantStockDifHistorico > 0 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = "Inconsistencias de Ubicaciones vs Movim. de Stock"
            o.MensajeDeAlerta = cantStockDifHistorico.ToString() + " inconsistencias de Ubicaciones vs Movim. Stock"
            o.Key = Entidades.Alerta.Tipos.InconsistenciaUbicacionesVsMovimientoDeStock
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InconsistDepositosVsMovStock") Then
         Dim cantStockDifHistorico As Integer = New SqlServer.ProductosDepositos(da).GetCantidadDeInconsistenciaDepositosVsMovStock(idSucursal)
         If cantStockDifHistorico > 0 Then
            o = New Entidades.Alerta()
            o.TituloConsultaGenerica = "Inconsistencias de Depositos vs Movim. de Stock"
            o.MensajeDeAlerta = cantStockDifHistorico.ToString() + " inconsistencias de Depositos vs Movim. Stock"
            o.Key = Entidades.Alerta.Tipos.InconsistenciaDepositosVsMovimientoDeStock
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If


      If oUsuario.TienePermisos(idUsuario, idSucursal, "InconsistCtaCtevsCtaCtePagos") Then
         Dim ControlInconsistenciasCtaCteClientesVsCtaCtePagos As DataTable = New SqlServer.CuentasCorrientesPagos(da).GetControlInconsistenciasCtaCtevsCtaCtePagos(idSucursal)
         If ControlInconsistenciasCtaCteClientesVsCtaCtePagos.Rows.Count > 0 Then
            o = New Entidades.Alerta()
            o.MensajeDeAlerta = " Inconsistencias Cta.Cte. Clientes vs Cta.Cte. Pagos"
            o.Key = Entidades.Alerta.Tipos.ControlInconsistenciasCtaCteClientesVsCtaCtePagos
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InconsCtaCteProvVsCtaCtePagos") Then
         Dim ControlInconsistenciasCtaCteProveedoresVsCtaCtePagos As DataTable = New SqlServer.CuentasCorrientesProvPagos(da).GetControlInconsistenciasCtaCtevsCtaCtePagos(idSucursal)
         If ControlInconsistenciasCtaCteProveedoresVsCtaCtePagos.Rows.Count > 0 Then
            o = New Entidades.Alerta()
            o.MensajeDeAlerta = " Inconsistencias Cta.Cte. Proveedores vs Cta.Cte. Pagos"
            o.Key = Entidades.Alerta.Tipos.ControlInconsistenciasCtaCteProveedoresVsCtaCtePagos
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If


      Dim cajas As DataTable = New DataTable
      Dim texto As String = ""
      cajas = New Reglas.CajasUsuarios().GetCajas(idSucursal, idUsuario, "", False)
      o = New Entidades.Alerta()

      If oUsuario.TienePermisos(idUsuario, idSucursal, "PlanillaDeCaja") Then
         For Each dr As DataRow In cajas.Rows
            Dim oCaja As Reglas.CajasNombres = New Reglas.CajasNombres()
            Dim caja As Entidades.CajaNombre = New Entidades.CajaNombre()
            Dim oCajas As Reglas.Cajas = New Reglas.Cajas()
            Dim saldoCaja As Decimal

            Dim oPlanilla As Entidades.Caja = oCajas.GetPlanillaActual(Integer.Parse(dr("IdSucursal").ToString()), Integer.Parse(dr("IdCaja").ToString()))

            'GAR: 17/05/2018 - No deberia estar nothing, pero puede suceder por migracion o separacion de sucursales.
            If Not IsNothing(oPlanilla) Then

               saldoCaja = oCajas.GetSaldoPesosFinal(Integer.Parse(dr("IdSucursal").ToString()), Integer.Parse(dr("IdCaja").ToString()), oPlanilla.NumeroPlanilla) + oCajas.GetSaldoChequesFinal(Integer.Parse(dr("IdSucursal").ToString()), Integer.Parse(dr("IdCaja").ToString()), oPlanilla.NumeroPlanilla)

               caja = oCaja.GetUna(Integer.Parse(dr("IdSucursal").ToString()), Integer.Parse(dr("IdCaja").ToString()))
               texto = ""
               If caja.TopeAviso > 0 And saldoCaja >= caja.TopeAviso And saldoCaja < caja.TopeBloqueo Then

                  texto = "Caja " & caja.NombreCaja.Trim.ToString() + ": Superó el Recomendado de " & caja.TopeAviso.ToString("$ ##,##0") + " = " + saldoCaja.ToString("$ ##,##0")
                  o.MensajeDeAlerta = o.MensajeDeAlerta + texto + "."
                  o.Color = Drawing.Color.Yellow

               ElseIf caja.TopeBloqueo > 0 And saldoCaja >= caja.TopeBloqueo Then
                  texto = "Caja " & caja.NombreCaja.Trim.ToString() + ": Llegó al Permitido de" & caja.TopeBloqueo.ToString("$ ##,##0.00")
                  o.MensajeDeAlerta = o.MensajeDeAlerta + texto + "."
                  o.Color = Drawing.Color.Red

               End If

            End If

         Next

         If o.MensajeDeAlerta <> "" Then
            o.Key = Entidades.Alerta.Tipos.TopesCaja
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            oLis.Add(o)
         End If
      End If

      '--------------------------------------------
      Dim oTiposComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes()
      Dim dt As DataTable

      dt = oTiposComprobantes.GetHabilitadosPorPc(Eniac.Entidades.Usuario.Actual.Sucursal.Id, IIf(True, My.Computer.Name, "").ToString(), "")

      If dt.Rows.Count = 0 Then
         o = New Entidades.Alerta()
         o.MensajeDeAlerta = "No Existe la PC en Configuraciones/Impresoras"
         o.Key = Entidades.Alerta.Tipos.ConfiguracionImpresoras
         o.Grupo = Entidades.Alerta.Grupos.Alertas
         oLis.Add(o)
      End If

      '-----------------------------Control de version
      Dim VersionDB() As String
      VersionDB = Publicos.VersionDB.ToString().Split("."c)

      'Dim decVersionDB As Decimal, decVersionExe As Decimal

      Dim decVersionDB As Decimal = VersionDB(0).ToDecimal().IfNull() + (VersionDB(1).ToDecimal().IfNull() / 100) + (VersionDB(2).ToDecimal().IfNull() / 10000) + (VersionDB(3).ToDecimal().IfNull() / 1000000)
      Dim decVersionExe As Decimal = (My.Application.Info.Version.Major + (My.Application.Info.Version.Minor / 100) + (My.Application.Info.Version.Build / 10000) + (My.Application.Info.Version.Revision / 1000000)).ToDecimal()

      If decVersionExe < decVersionDB Then
         o = New Entidades.Alerta()
         o.MensajeDeAlerta = "La Versión Actual es antigüa ( " _
                           & My.Application.Info.Version.ToString() & " ), debe actualizarla a " _
                         & Publicos.VersionDB _
                         & ". Por Favor cierre la aplicación y vuelva a entrar."
         o.Key = Entidades.Alerta.Tipos.ControlVersion
         o.Grupo = Entidades.Alerta.Grupos.Alertas
         o.Color = Drawing.Color.Red
         o.OrdenPrioridad = 100
         o.MostrarPopUp = True
         oLis.Add(o)

      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "AlertaSaltoNumeracion") Then
         Dim rVentasNumeros = New Reglas.VentasNumeros()
         Dim saltos = rVentasNumeros.ControlSaltoNumeracion()
         Dim saltosCount = saltos.Count
         If saltosCount > 0 Then
            o = New Entidades.Alerta With {
               .Color = Drawing.Color.Red,
               .TituloConsultaGenerica = "Saltos en numeración de comprobantes",
               .MensajeDeAlerta = String.Format("{0} comprobantes faltantes en con salto de numeración", saltosCount),
               .Key = Entidades.Alerta.Tipos.ControlSaltoNumeracion,
               .Grupo = Entidades.Alerta.Grupos.Alertas,
               .OrdenPrioridad = 100,
               .MostrarPopUp = True,
               .MostrarEnLista = True,
               .Tag = saltos
            }
            oLis.Add(o)
         End If
      End If

      Dim netVersion = CheckNetFrameworkInstalled()
      If netVersion < NetFramworkVersion.Net4_8 Then
         o = New Entidades.Alerta()
         o.MensajeDeAlerta = String.Format("No tiene instalada la versión 4.6 de .Net Framework o posterior")
         o.Key = Entidades.Alerta.Tipos.ControlNetFwk
         o.Grupo = Entidades.Alerta.Grupos.Alertas
         o.Color = Drawing.Color.Red
         o.OrdenPrioridad = 100
         o.MostrarPopUp = True
         oLis.Add(o)

      End If


      'ALERTAS DE PEDIDOS
      If oUsuario.TienePermisos(idUsuario, idSucursal, "OrganizarEntregasV2") Then
         Dim PreFacturaCosumePedidos As Boolean = Publicos.PreFacturaConsumePedidos
         Dim PedidosPermiteFechaEntregaDistintas As Boolean = Publicos.PedidosPermiteFechaEntregaDistintas
         Dim FacturarPedidoSeleccionado As Boolean = Reglas.Publicos.Facturacion.FacturarPedidoSeleccionado

         If (PreFacturaCosumePedidos = False Or FacturarPedidoSeleccionado = False Or
             PedidosPermiteFechaEntregaDistintas = True) Then
            o = New Entidades.Alerta()
            o.MensajeDeAlerta = "Algunos Parámetros del Sistema deben ser cambiados."
            o.Key = Entidades.Alerta.Tipos.ParámetrosDePedidos
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "Pedidos-PedidosSinFacturar") Then
         Dim count As Integer = New Reglas.Pedidos().GetPedidosSinFacturar(SucursalesAlerta).Rows.Count
         If count > 0 Then
            o = New Entidades.Alerta()
            o.MensajeDeAlerta = String.Format("Existen {0} pedidos sin facturar.", count)
            o.Key = Entidades.Alerta.Tipos.PedidosSinFacturar
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Red
            o.OrdenPrioridad = 100
            oLis.Add(o)
         End If
      End If


      'ALERTAS DE NOVEDADES VENCIDAS
      If oUsuario.TienePermisos(idUsuario, idSucursal, "CRMNovedades-PuedeVerAlerta") Then
         Dim novedadesConFechaVencidas As DataTable = New SqlServer.CRMNovedades(da).GetNovedadesVencidas(Today, idUsuario)
         If novedadesConFechaVencidas.Rows.Count > 0 Then

            For Each col As DataRow In novedadesConFechaVencidas.Rows
               o = New Entidades.Alerta()
               o.MensajeDeAlerta = String.Format("Tiene {1} {0} vencidas.", col("NombreTipoNovedad"), col("Cantidad"))
               o.Key = Entidades.Alerta.Tipos.NovedadesFechasVencidas
               o.Grupo = Entidades.Alerta.Grupos.Alertas
               o.Color = Drawing.Color.Red
               o.OrdenPrioridad = 100
               o.Tag = col("IdTipoNovedad")
               oLis.Add(o)
            Next

         End If
      End If


      'ALERTA DE NOVEDADES POR VENCER
      If oUsuario.TienePermisos(idUsuario, idSucursal, "CRMNovedades-PuedeVerAlerta") Then

         Dim DiasAVencer As Integer = Publicos.CRMNovedadesDiasAVencerAlarma
         'Le sumo un dia y le quito un Segundo para que tenga 23:59:29
         Dim FechaAVencer As Date = Today.AddDays(DiasAVencer + 1).AddSeconds(-1)

         Dim novedadesConFechaVencidas As DataTable = New SqlServer.CRMNovedades(da).GetNovedadesPorVencer(FechaAVencer, idUsuario)

         If novedadesConFechaVencidas.Rows.Count > 0 Then

            For Each col As DataRow In novedadesConFechaVencidas.Rows
               o = New Entidades.Alerta()
               o.MensajeDeAlerta = String.Format("Tiene {1} {0} por vencer.", col("NombreTipoNovedad"), col("Cantidad"))
               o.Key = Entidades.Alerta.Tipos.NovedadesFechasPorVencer
               o.Grupo = Entidades.Alerta.Grupos.Alertas
               o.Color = Drawing.Color.Yellow
               o.OrdenPrioridad = 200
               o.Tag = col("IdTipoNovedad")
               oLis.Add(o)
            Next

         End If
      End If

      'ALERTA DE TURNOS VENCIDOS
      If oUsuario.TienePermisos(idUsuario, idSucursal, "AlertaTurnos") Then
         Dim cantTurnosNoEfectivos As Integer = New SqlServer.TurnosCalendarios(Me.da, Publicos.IDAplicacionSinergia).GetPorRangoFechas(New Entidades.Filtros.GetPorRangoFechasFiltros(Date.Now.Date, Date.Now, False)).Rows.Count() ' , 0, 0, "", "False").Rows.Count()
         If cantTurnosNoEfectivos > 0 Then
            o = New Eniac.Entidades.Alerta()
            o.MensajeDeAlerta = cantTurnosNoEfectivos.ToString() + " Turno(s) No Efectivo(s)"
            o.Key = Entidades.Alerta.Tipos.TurnosNoEfectivos
            o.Grupo = Eniac.Entidades.Alerta.Grupos.Alertas
            o.Color = Drawing.Color.Yellow
            o.OrdenPrioridad = 200
            oLis.Add(o)
         End If
      End If

      'ALERTAS TURNOS DEL DIA POR CALENDARIO
      Dim dtTurnosCalendarios As DataTable = New Reglas.TurnosCalendarios(da).GetTurnosDelDia(actual.Nombre)

      For Each drTurnosCalendario As DataRow In dtTurnosCalendarios.Rows
         o = New Entidades.Alerta()
         o.MensajeDeAlerta = String.Format("{1}: {0} Turnos para hoy.", drTurnosCalendario("Turnos").ToString(), drTurnosCalendario("NombreCalendario").ToString())
         o.Key = Entidades.Alerta.Tipos.TurnosDelDia
         o.Grupo = Entidades.Alerta.Grupos.Alertas
         o.Color = Drawing.Color.Yellow
         o.OrdenPrioridad = 100
         o.Tag = drTurnosCalendario("IdCalendario").ToString()
         oLis.Add(o)
      Next

      'ALERTAS DE PROSPECTO SIN CRM.
      If oUsuario.TienePermisos(idUsuario, idSucursal, "CRMNovedadesABMPROSP") Then
         Dim dtProsp As DataTable = New Reglas.Clientes(da).GetCantidadProspectoSinCRM()
         If dtProsp.Rows.Count > 0 Then
            For Each dr As DataRow In dtProsp.Rows
               If Integer.Parse(dr("Cantidad").ToString()) > 0 Then
                  o = New Entidades.Alerta()
                  o.TituloConsultaGenerica = "Prospectos Sin CRM"
                  o.MensajeDeAlerta = String.Format("Tiene {0} Prospectos sin CRM.", dr("Cantidad"))
                  o.Key = Entidades.Alerta.Tipos.ProspectoSinCRM
                  o.Grupo = Entidades.Alerta.Grupos.Alertas
                  o.Color = Drawing.Color.Red
                  o.OrdenPrioridad = 200
                  oLis.Add(o)
               End If
            Next
         End If
      End If

      If oUsuario.TienePermisos(idUsuario, idSucursal, "InformeChequesPropios") Then
         Dim fechaHoraDesde As DateTime = DateTime.Today.AddDays(-3)
         Dim fechaHoraHasta As DateTime = DateTime.Today.UltimoSegundoDelDia()

         Dim aDebitados As DataTable = New SqlServer.Cheques(da).GetCantidadProximoAPagar(idSucursal, fechaHoraDesde, fechaHoraHasta)
         For Each dr As DataRow In aDebitados.Rows
            If Integer.Parse(dr("Cantidad").ToString()) > 0 Then
               o = New Entidades.Alerta()
               o.MensajeDeAlerta = String.Format("Tiene {0} Cheques propios con disponibilidad de pago", dr("Cantidad"))
               o.Key = Entidades.Alerta.Tipos.ChequesPropiosADebitar
               o.Grupo = Entidades.Alerta.Grupos.Alertas
               o.Color = Drawing.Color.Red
               o.OrdenPrioridad = 200
               o.Tag = {fechaHoraDesde, fechaHoraHasta}
               oLis.Add(o)
            End If
         Next

         fechaHoraDesde = DateTime.Today.AddDays(1)
         fechaHoraHasta = DateTime.Today.AddDays(1).UltimoSegundoDelDia()

         Dim aDebitar As DataTable = New SqlServer.Cheques(da).GetCantidadProximoAPagar(idSucursal, fechaHoraDesde, fechaHoraHasta)
         For Each dr2 As DataRow In aDebitar.Rows
            If Integer.Parse(dr2("Cantidad").ToString()) > 0 Then
               o = New Entidades.Alerta()
               o.MensajeDeAlerta = String.Format("Tiene {0} Cheques propios por pagar", dr2("Cantidad"))
               o.Key = Entidades.Alerta.Tipos.ChequesPropiosADebitar
               o.Grupo = Entidades.Alerta.Grupos.Alertas
               o.Color = Drawing.Color.Yellow
               o.OrdenPrioridad = 100
               o.Tag = {fechaHoraDesde, fechaHoraHasta}
               oLis.Add(o)
            End If
         Next
      End If


      '-.PE-31698.-
      If oUsuario.TienePermisos(idUsuario, idSucursal, "AlertaCambioCategoriaCliente") Then
         'PE-30973
         Dim FechaAlertaCambioCategoriaCliente As Date = Today.Date.AddDays(Publicos.DiasAlertaClientesCategoriaModificar)

         'ALERTA ROJA
         Dim CambioCategoriaClientePorVto As Integer = New Reglas.Clientes(da).GetClientesCambioCategoriaVencidas().Rows.Count()
         If CambioCategoriaClientePorVto > 0 Then
            o = New Entidades.Alerta()
            o.Color = Drawing.Color.Red
            o.MensajeDeAlerta = CambioCategoriaClientePorVto.ToString() + "  Cambio(s) de Categoria(s) con Fecha Vencida"
            o.Key = Entidades.Alerta.Tipos.AlertaClientesCategoriaModificarVencidas
            o.Grupo = Eniac.Entidades.Alerta.Grupos.Alertas
            oLis.Add(o)
         End If
      End If

      '-.PE-32652.-
      If oUsuario.TienePermisos(idUsuario, idSucursal, "AlertaPedidosConCantidadItems") Then
         Dim PedidosParcialesConCantidadItems As Integer = New Reglas.Pedidos(da).GetPedidosPendientesConCantItems("Pendiente", True, SucursalesAlerta).Rows.Count()
         If PedidosParcialesConCantidadItems > 0 Then
            o = New Entidades.Alerta()
            o.Color = Drawing.Color.Yellow
            o.MensajeDeAlerta = PedidosParcialesConCantidadItems.ToString() + " Items de Pedidos Parcialmente Pendientes con Items Facturados"
            o.Key = Entidades.Alerta.Tipos.AlertaPedidosConCantidadItems
            o.Grupo = Eniac.Entidades.Alerta.Grupos.Alertas
            oLis.Add(o)
         End If
      End If
      If oUsuario.TienePermisos(idUsuario, idSucursal, "AlertaPedidosSinCantidadItems") Then
         Dim PedidosTotalSinCantidadItems As Integer = New Reglas.Pedidos(da).GetPedidosPendientesConCantItems("Pendiente", False, SucursalesAlerta).Rows.Count()
         If PedidosTotalSinCantidadItems > 0 Then
            o = New Entidades.Alerta()
            o.Color = Drawing.Color.Yellow
            o.MensajeDeAlerta = PedidosTotalSinCantidadItems.ToString() + " Items de Pedidos Totalmente Pendientes"
            o.Key = Entidades.Alerta.Tipos.AlertaPedidosSinCantidadItems
            o.Grupo = Eniac.Entidades.Alerta.Grupos.Alertas
            oLis.Add(o)
         End If
      End If

      If oUsuario.TienePermisos("AlertaClientesConDeuda") Then
         Dim sucursales = {actual.Sucursal}
         Dim fechaVancimientoHasta = Date.Today
         Dim saldoMinimoAlerta = 0D
         Dim cantidadComprobanteAdeudados = 1I
         Dim incluirEmbarcacion = New Generales().ExisteTabla("Embarcaciones")

         Dim fnc = New Funciones().GetUna("AlertaClientesConDeuda", cargaDocumentos:=False, cargaVinculadas:=False, AccionesSiNoExisteRegistro.Nulo)
         If fnc IsNot Nothing Then
            For Each param In fnc.Parametros.Split(";"c)
               Dim parSplit = param.Split("="c)
               If parSplit.Count > 1 Then
                  Dim valor = parSplit(1)
                  Select Case parSplit(0)
                     Case "DiasVencimiento"
                        fechaVancimientoHasta = Date.Today.AddDays(valor.ValorNumericoPorDefecto(0I))
                     Case "SaldoMinimo"
                        saldoMinimoAlerta = valor.ValorNumericoPorDefecto(0I)
                     Case "CantidadComprobantes"
                        cantidadComprobanteAdeudados = valor.ValorNumericoPorDefecto(1I)
                     Case Else
                  End Select
               End If
            Next
         End If

         Dim dt1 = New CuentasCorrientesPagos().GetParaAlerta(sucursales, fechaVancimientoHasta, saldoMinimoAlerta, cantidadComprobanteAdeudados, incluirEmbarcacion)
         If dt1.Count > 0 Then

            o = New Entidades.Alerta()
            o.Color = Drawing.Color.Yellow
            o.MensajeDeAlerta = String.Format("{0} Clientes clientes con deuda", dt1.Count)
            o.Key = Entidades.Alerta.Tipos.AlertaClientesConDeuda
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Tag = dt1
            oLis.Add(o)

         End If
      End If

      'ALERTA DE SINCRONIZADOR OC Bejerman
      If oUsuario.TienePermisos(idUsuario, idSucursal, "SincronizarOrdenesCompra") Then

         Dim fechaSincOrdenCompra = Publicos.BejermanMetalsur.FechaUltimaSincronizacionOrdenCompra

         o = New Entidades.Alerta()
         o.MensajeDeAlerta = String.Format("Ultima sincronizacion de Ordenes de Compra: {0}", fechaSincOrdenCompra)
         o.Key = Entidades.Alerta.Tipos.UltimaFechaSincroOCBejerman
         o.Grupo = Entidades.Alerta.Grupos.Alertas
         If fechaSincOrdenCompra.Value.AddHours(1) < Date.Now Then
            o.Color = Drawing.Color.Red
         Else
            o.Color = Drawing.Color.Green
         End If

         o.OrdenPrioridad = 200
         o.Tag = fechaSincOrdenCompra
         oLis.Add(o)

      End If

      Dim rAlertas = New Sistema.AlertasSistema(da)
      For Each alerta In rAlertas.GetTodos(actual.Nombre)
         If alerta.EvaluaPermisos(Function(idFuncion) oUsuario.TienePermisos(idFuncion)) Then
            Dim dtAlerta = rAlertas.EjecutaConsulta(alerta)
            Dim count = dtAlerta.Count
            For Each cond In alerta.Condiciones
               If (cond.CondicionCount = Entidades.SistemaE.CondicionesCountAlerta.Diferente And count <> cond.ValorCondicionCount) Or
                  (cond.CondicionCount = Entidades.SistemaE.CondicionesCountAlerta.Igual And count = cond.ValorCondicionCount) Or
                  (cond.CondicionCount = Entidades.SistemaE.CondicionesCountAlerta.Mayor And count > cond.ValorCondicionCount) Or
                  (cond.CondicionCount = Entidades.SistemaE.CondicionesCountAlerta.MayorIgual And count >= cond.ValorCondicionCount) Or
                  (cond.CondicionCount = Entidades.SistemaE.CondicionesCountAlerta.MenorIgual And count <= cond.ValorCondicionCount) Or
                  (cond.CondicionCount = Entidades.SistemaE.CondicionesCountAlerta.Menor And count < cond.ValorCondicionCount) Then

                  o = New Entidades.Alerta()
                  o.Color = cond.ColorCondicionCount
                  o.TituloConsultaGenerica = alerta.TituloAlerta
                  Dim variables = New Sistema.AlertasSistema.VariablesAlerta().Inicializar(Sistema.AlertasSistema.DestinoListaVariables.Mensaje).
                                    Update("@@COUNT@@", count.ToString())

                  o.MensajeDeAlerta = cond.MensajeCount.Replace2(variables.ToReplaceTuple())
                  o.Key = Entidades.Alerta.Tipos.AlertaCustom
                  o.Grupo = Entidades.Alerta.Grupos.Alertas
                  o.OrdenPrioridad = Convert.ToUInt32(cond.OrdenCondicion)
                  o.MostrarPopUp = cond.MostrarPopUp
                  o.MostrarEnLista = True
                  o.Tag = dtAlerta
                  o.AlertaSistema = alerta
                  o.AlertaSistemaCondicion = cond
                  oLis.Add(o)

                  Exit For
               End If
            Next
         End If
      Next

      'Alerta de Proveedores con Comprobantes Vencidos
      If oUsuario.TienePermisos("AlertaProvComprobantesVencidos") Then
         Dim sucursales = {actual.Sucursal}
         Dim fechaVancimientoHasta = Date.Today
         Dim saldoMinimoAlerta = 0D
         Dim cantidadComprobanteAdeudados = 1I

         Dim fnc = New Funciones().GetUna("AlertaProvComprobantesVencidos", cargaDocumentos:=False, cargaVinculadas:=False, AccionesSiNoExisteRegistro.Nulo)
         If fnc IsNot Nothing Then
            For Each param In fnc.Parametros.Split(";"c)
               Dim parSplit = param.Split("="c)
               If parSplit.Count > 1 Then
                  Dim valor = parSplit(1)
                  Select Case parSplit(0)
                     Case "DiasVencimiento"
                        fechaVancimientoHasta = Date.Today.AddDays(valor.ValorNumericoPorDefecto(0I))
                     Case "SaldoMinimo"
                        saldoMinimoAlerta = valor.ValorNumericoPorDefecto(0I)
                     Case "CantidadComprobantes"
                        cantidadComprobanteAdeudados = valor.ValorNumericoPorDefecto(1I)
                     Case Else
                  End Select
               End If
            Next
         End If

         Dim dt1 = New CuentasCorrientesProvPagos().GetParaAlerta(sucursales, fechaVancimientoHasta, saldoMinimoAlerta, cantidadComprobanteAdeudados)
         If dt1.Count > 0 Then

            o = New Entidades.Alerta()
            o.Color = Drawing.Color.Yellow
            o.MensajeDeAlerta = String.Format("{0} Proveedores con comprobantes vencidos", dt1.Count)
            o.Key = Entidades.Alerta.Tipos.AlertaProvComprobantesVencidos
            o.Grupo = Entidades.Alerta.Grupos.Alertas
            o.Tag = dt1
            oLis.Add(o)

         End If
      End If

   End Sub

#Region "Metodos Publicos"

   Public Function GetPorSucursal(idUsuario As String, idSucursal As Integer) As List(Of Entidades.Alerta)
      Try
         Me.da.OpenConection()

         Dim oLis As List(Of Entidades.Alerta) = New List(Of Entidades.Alerta)

         Me.CargaAlertas(idUsuario, idSucursal, oLis)

         Return oLis

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

#End Region

End Class
