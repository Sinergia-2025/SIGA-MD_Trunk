Public Class Repartos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.Reparto.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.Reparto)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.Reparto)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.Reparto)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Repartos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetAll(actual.Sucursal.Id)
   End Function
   Public Overloads Function GetAll(idSucursal As Integer) As DataTable
      Return New SqlServer.Repartos(da).Repartos_GA(idSucursal)
   End Function
#End Region

#Region "Metodos Privados"

   Public Sub Inserta(entidad As Entidades.Reparto)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub Inserta(idReparto As Integer, fechaReparto As Date, transportista As Entidades.Transportista)
      Dim reparto As Entidades.Reparto = New Entidades.Reparto()

      reparto.IdSucursal = actual.Sucursal.IdSucursal
      reparto.IdReparto = idReparto
      reparto.FechaReparto = fechaReparto
      reparto.Transportista = transportista
      reparto.IdEstado = Entidades.Reparto.EstadosReparto.ACTIVO.ToString()
      reparto.IdUsuario = actual.Nombre
      reparto.FechaActualizacion = Now

      Inserta(reparto)
   End Sub

   Public Sub Actualiza(entidad As Entidades.Reparto)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Merge(entidad As Entidades.Reparto)
      EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub ActualizaEstado(idSucursal As Integer, idReparto As Integer, idEstado As String, fechaActualizacion As Date)
      Dim sRepartos = New SqlServer.Repartos(da)
      sRepartos.Repartos_U_Estado(idSucursal, idReparto, idEstado, fechaActualizacion)
   End Sub

   Public Sub Borra(entidad As Entidades.Reparto)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.Reparto, tipo As TipoSP)

      Dim sqlC = New SqlServer.Repartos(da)
      Dim rRepCom = New RepartosComprobantes(da)
      Dim rRepGasto = New RepartosGastos(da)
      Select Case tipo
         Case TipoSP._I

            If en.IdReparto = 0 Then
               en.IdReparto = GetCodigoMaximo(en.IdSucursal)
            End If
            en.FechaActualizacion = Now

            sqlC.Repartos_I(en.IdSucursal,
                           en.IdReparto,
                           en.FechaReparto,
                           en.IdTransportista,
                           en.IdEstado,
                           en.IdUsuario,
                           en.FechaActualizacion,
                           en.IdSucursalSalida,
                           en.IdTipoComprobanteSalida,
                           en.LetraSalida,
                           en.CentroEmisorSalida,
                           en.NumeroComprobanteSalida,
                           en.IdSucursalEntrada,
                           en.IdTipoComprobanteEntrada,
                           en.LetraEntrada,
                           en.CentroEmisorEntrada,
                           en.NumeroComprobanteEntrada,
                           en.TotalGastos,
                           en.TotalGastosCompras,
                           en.TotalGastosCaja,
                           en.TotalResumenComprobante,
                           en.TotalResumenEfectivo,
                           en.TotalResumenTransferencia,
                           en.TotalResumenCtaCte,
                           en.TotalResumenNCred,
                           en.TotalResumenCheques,
                           en.TotalResumenReenvio,
                           en.TotalResumenSaldoGeneral)

            rRepCom.InsertaDesdeReparto(en)
            rRepGasto.InsertaDesdeReparto(en)
         Case TipoSP._U
            sqlC.Repartos_U(en.IdSucursal,
                           en.IdReparto,
                           en.TotalResumenComprobante,
                           en.TotalResumenEfectivo,
                           en.TotalResumenTransferencia,
                           en.TotalResumenCtaCte,
                           en.TotalResumenCheques,
                           en.TotalResumenNCred,
                           en.TotalResumenReenvio,
                           en.TotalResumenSaldoGeneral)
         Case TipoSP._D
            rRepCom.Borra(New Entidades.RepartoComprobante() With {.IdSucursal = en.IdSucursal, .IdReparto = en.IdReparto})
            rRepGasto.Borra(New Entidades.RepartoGasto() With {.IdSucursal = en.IdSucursal, .IdReparto = en.IdReparto})
            sqlC.Repartos_D(en.IdSucursal, en.IdReparto)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.Reparto, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.Reparto.Columnas.IdSucursal.ToString).ToString())
         .IdReparto = Integer.Parse(dr(Entidades.Reparto.Columnas.IdReparto.ToString).ToString())
         If IsDate(dr(Entidades.Reparto.Columnas.FechaReparto.ToString)) Then
            .FechaReparto = DateTime.Parse(dr(Entidades.Reparto.Columnas.FechaReparto.ToString).ToString())
         End If
         If IsNumeric(dr(Entidades.Reparto.Columnas.IdTransportista.ToString)) Then
            .Transportista = New Transportistas(da).GetUno(Integer.Parse(dr(Entidades.Reparto.Columnas.IdTransportista.ToString).ToString()))
         End If
         .IdEstado = dr(Entidades.Reparto.Columnas.IdEstado.ToString).ToString()
         .IdUsuario = dr(Entidades.Reparto.Columnas.IdUsuario.ToString).ToString()
         .FechaActualizacion = DateTime.Parse(dr(Entidades.Reparto.Columnas.FechaActualizacion.ToString).ToString())

         If IsNumeric(dr(Entidades.Reparto.Columnas.IdSucursalSalida.ToString)) Then
            .IdSucursalSalida = Integer.Parse(dr(Entidades.Reparto.Columnas.IdSucursalSalida.ToString).ToString())
         End If
         .IdTipoComprobanteSalida = dr(Entidades.Reparto.Columnas.IdTipoComprobanteSalida.ToString).ToString()
         .LetraSalida = dr(Entidades.Reparto.Columnas.LetraSalida.ToString).ToString()
         If IsNumeric(dr(Entidades.Reparto.Columnas.CentroEmisorSalida.ToString)) Then
            .CentroEmisorSalida = Short.Parse(dr(Entidades.Reparto.Columnas.CentroEmisorSalida.ToString).ToString())
         End If
         If IsNumeric(dr(Entidades.Reparto.Columnas.NumeroComprobanteSalida.ToString)) Then
            .NumeroComprobanteSalida = Long.Parse(dr(Entidades.Reparto.Columnas.NumeroComprobanteSalida.ToString).ToString())
         End If

         If IsNumeric(dr(Entidades.Reparto.Columnas.IdSucursalEntrada.ToString)) Then
            .IdSucursalEntrada = Integer.Parse(dr(Entidades.Reparto.Columnas.IdSucursalEntrada.ToString).ToString())
         End If
         .IdTipoComprobanteEntrada = dr(Entidades.Reparto.Columnas.IdTipoComprobanteEntrada.ToString).ToString()
         .LetraEntrada = dr(Entidades.Reparto.Columnas.LetraEntrada.ToString).ToString()
         If IsNumeric(dr(Entidades.Reparto.Columnas.CentroEmisorEntrada.ToString)) Then
            .CentroEmisorEntrada = Short.Parse(dr(Entidades.Reparto.Columnas.CentroEmisorEntrada.ToString).ToString())
         End If
         If IsNumeric(dr(Entidades.Reparto.Columnas.NumeroComprobanteEntrada.ToString)) Then
            .NumeroComprobanteEntrada = Long.Parse(dr(Entidades.Reparto.Columnas.NumeroComprobanteEntrada.ToString).ToString())
         End If
         .TotalGastos = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalGastos.ToString()).ToString())
         .TotalGastosCompras = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalGastosCompras.ToString()).ToString())
         .TotalGastosCaja = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalGastosCaja.ToString()).ToString())

         .Comprobantes = New Reglas.RepartosComprobantes(da).GetTodos(.IdSucursal, .IdReparto)
         .Gastos = New Reglas.RepartosGastos(da).GetTodos(.IdSucursal, .IdReparto)

         .TotalResumenComprobante = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalResumenComprobante.ToString()).ToString())
         .TotalResumenEfectivo = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalResumenEfectivo.ToString()).ToString())
         .TotalResumenTransferencia = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalResumenTransferencia.ToString()).ToString())
         .TotalResumenCtaCte = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalResumenCtaCte.ToString()).ToString())
         .TotalResumenCheques = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalResumenCheques.ToString()).ToString())
         .TotalResumenNCred = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalResumenNCred.ToString()).ToString())
         .TotalResumenReenvio = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalResumenReenvio.ToString()).ToString())
         .TotalResumenSaldoGeneral = Decimal.Parse(dr(Entidades.Reparto.Columnas.TotalResumenSaldoGeneral.ToString()).ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function Get1(idSucursal As Integer, idReparto As Integer) As DataTable
      Return New SqlServer.Repartos(da).Repartos_G1(idSucursal, idReparto)
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.Reparto
      Dim dt As DataTable = Get1(idSucursal, idReparto)
      Dim o As Entidades.Reparto = New Entidades.Reparto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         ElseIf accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No se encontró el Reparto con Sucursal = {0} y Número = {1}", idSucursal, idReparto))
         End If
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.Reparto)
      Return GetTodos(actual.Sucursal.Id)
   End Function
   Public Function GetTodos(idSucursal As Integer) As List(Of Entidades.Reparto)
      Return CargaLista(New SqlServer.Repartos(da).Repartos_GA(idSucursal), Sub(o, dr) CargarUno(DirectCast(o, Entidades.Reparto), dr), Function() New Entidades.Reparto())
   End Function

   Public Function GetCodigoMaximo(idSucursal As Integer) As Integer
      Return New SqlServer.Repartos(da).GetCodigoMaximo(idSucursal)
   End Function

   Public Function GetConsolidadPorModelo(idSucursal As Integer, idReparto As Integer) As Ventas.RegistrarRepartoDatos
      Try
         da.OpenConection()
         Dim sqlV As SqlServer.Ventas = New SqlServer.Ventas(da)
         Dim sql As SqlServer.Repartos = New SqlServer.Repartos(da)

         Dim dtProductos As DataTable = sqlV.GetProductosParaRegistrarReparto()
         Dim dtGrilla As DataTable = Nothing
         If dtProductos.Rows.Count > 0 Then
            dtGrilla = sql.GetConsolidadPorModelo(dtProductos, idSucursal, idReparto, mostrarPrecioConIva:=True)
         End If
         Return New Ventas.RegistrarRepartoDatos() With {.dtProductos = dtProductos, .dtGrilla = dtGrilla}
      Finally
         da.CloseConection()
      End Try

   End Function
   Public Function GetInfConsolidadPorModelo(idSucursal As Integer,
                                             desde As Date,
                                             hasta As Date,
                                             idVendedor As Integer,
                                             idCliente As Long,
                                             tipoComprobante As String,
                                             numeroReparto As Long,
                                             idFormasPago As Integer,
                                             idUsuario As String,
                                             idTransportista As Integer,
                                             idCategoria As Integer) As Ventas.RegistrarRepartoDatos


      Try
         da.OpenConection()
         Dim sqlV As SqlServer.Ventas = New SqlServer.Ventas(da)
         Dim sql As SqlServer.Repartos = New SqlServer.Repartos(da)

         Dim dtProductos As DataTable = sqlV.GetProductosParaRegistrarReparto()
         Dim dtGrilla As DataTable = Nothing
         If dtProductos.Rows.Count > 0 Then
            dtGrilla = sql.GetInfConsolidadPorModelo(dtProductos, idSucursal, desde, hasta, idVendedor, idCliente,
                                                                tipoComprobante, numeroReparto, idFormasPago, idUsuario, idTransportista, idCategoria)
         End If
         Return New Ventas.RegistrarRepartoDatos() With {.dtProductos = dtProductos, .dtGrilla = dtGrilla}
      Finally
         da.CloseConection()
      End Try

   End Function

   Public Sub AnularReparto(idSucursal As Integer, numeroReparto As Integer)
      Dim blnAgreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAgreConexion Then da.OpenConection()
         If blnAgreConexion Then da.BeginTransaction()

         'Dim reparto As Entidades.Reparto = GetUno(idSucursal, numeroReparto, AccionesSiNoExisteRegistro.Nulo)

         Using dtRepComp = New RegistracionPagos(da)._GetPedidos(actual.Sucursal.IdSucursal, 0, 0, numeroReparto, Date.MaxValue, False,
                                                                 Entidades.RegistracionPagos.ModoConsultarComprobantes.SoloRepartoSeleccionado,
                                                                 IdEmpleado:=0, idRuta:=0, dia:=Nothing)
            Dim oPedido = New Reglas.Ventas(da)
            Dim rCtaCte = New CuentasCorrientes(da)
            Dim strFiltro As String
            For Each drRepComp As DataRow In dtRepComp.Rows
               strFiltro =
                  String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                drRepComp("IdSucursal"), drRepComp("IdTipoComprobante"), drRepComp("Letra"), drRepComp("CentroEmisor"), drRepComp("NumeroComprobante"))
               oPedido._ActualizarPedidoPorReenvio(strFiltro, Nothing, Nothing, Nothing)
               rCtaCte._ActualizarNumeroReparto(drRepComp.Field(Of Integer)("IdSucursal"),
                                                drRepComp.Field(Of String)("IdTipoComprobante"),
                                                drRepComp.Field(Of String)("Letra"),
                                                Integer.Parse(drRepComp("CentroEmisor").ToString()),
                                                drRepComp.Field(Of Long)("NumeroComprobante"),
                                                numeroReparto:=Nothing)
            Next
         End Using

         ActualizaEstado(idSucursal, numeroReparto, Entidades.Reparto.EstadosReparto.ANULADO.ToString(), Now)

         If blnAgreConexion Then da.CommitTransaction()
      Catch
         If blnAgreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAgreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Function ModificarReparto(idSucursal As Integer, numeroReparto As Integer, dt As DataTable,
                                    fechaEnvio As DateTime?, transportista As Entidades.Transportista) As Integer
      Dim numeroRepartoResult As Integer
      'ModoAnulación: TRUE  : Anula el Reparto Original y crea uno nuevo con los comprobantes que están en el DataTable
      'ModoAnulación: FALSE : Elimina los Comprobantes del Reparto Original, agrego los comprobantes que estan en el DataTable
      '                       y por último debo liberar los comprobantes que estaban en el reparto original y no están en el DataTable
      'Por ahora parametrizado en código. Cuando se necesite comportamientos diferentes lo parametrizamos en BD.
      Dim modoAnulacion As Boolean = False
      Dim reparto As Entidades.Reparto
      Dim repCompOrigenCol As List(Of Entidades.RepartoComprobante)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim rRepComp As Reglas.RepartosComprobantes = New RepartosComprobantes(da)

         reparto = GetUno(idSucursal, numeroReparto, AccionesSiNoExisteRegistro.Nulo)

         repCompOrigenCol = rRepComp._GetTodos(idSucursal, numeroReparto)

         If modoAnulacion Then
            AnularReparto(idSucursal, numeroReparto)
            numeroRepartoResult = GetCodigoMaximo(idSucursal) + 1
            Dim nuevoReparto As Entidades.Reparto = New Entidades.Reparto()
            nuevoReparto.IdSucursal = idSucursal
            nuevoReparto.IdReparto = numeroRepartoResult
            If fechaEnvio.HasValue Then
               nuevoReparto.FechaReparto = fechaEnvio.Value
            Else
               nuevoReparto.FechaReparto = reparto.FechaReparto
            End If
            If transportista IsNot Nothing Then
               nuevoReparto.Transportista = transportista
            Else
               nuevoReparto.Transportista = reparto.Transportista
            End If
            nuevoReparto.IdEstado = Entidades.Reparto.EstadosReparto.ACTIVO.ToString()
            nuevoReparto.IdUsuario = actual.Nombre
            nuevoReparto.FechaActualizacion = Now
            Inserta(nuevoReparto)
         Else
            rRepComp.Borrar(idSucursal, numeroReparto)
            numeroRepartoResult = numeroReparto
            reparto.IdUsuario = actual.Nombre
            reparto.FechaActualizacion = Now
            If fechaEnvio.HasValue Then
               reparto.FechaReparto = fechaEnvio.Value
            End If
            If transportista IsNot Nothing Then
               reparto.Transportista = transportista
            End If
            Actualiza(reparto)
         End If

         Dim venta As Entidades.Venta
         Dim rVenta As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas(da)
         Dim rVentaLive As Reglas.Ventas = New Reglas.Ventas(da)
         Dim rCtaCte = New CuentasCorrientes(da)
         Dim repComp As Entidades.RepartoComprobante
         Dim orden As Integer = 0
         Dim strFiltro As String

         For Each dr As DataRow In dt.Rows
            venta = Nothing
            If IsNumeric(dr("NumeroComprobante")) Then
               venta = rVenta.GetUna(Integer.Parse(dr(Eniac.Entidades.Venta.Columnas.IdSucursal.ToString()).ToString()),
                                     dr(Eniac.Entidades.Venta.Columnas.IdTipoComprobante.ToString()).ToString(),
                                     dr(Eniac.Entidades.Venta.Columnas.Letra.ToString()).ToString(),
                                     Short.Parse(dr(Eniac.Entidades.Venta.Columnas.CentroEmisor.ToString()).ToString()),
                                     Long.Parse(dr(Eniac.Entidades.Venta.Columnas.NumeroComprobante.ToString()).ToString()))
            End If

            repComp = New Entidades.RepartoComprobante()
            repComp.IdSucursal = idSucursal
            repComp.IdReparto = numeroRepartoResult
            orden += 1
            repComp.Orden = orden
            repComp.Venta = venta

            rRepComp.Inserta(repComp)

            strFiltro =
                  String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                dr("IdSucursal"), dr("IdTipoComprobante"), dr("Letra"), dr("CentroEmisor"), dr("NumeroComprobante"))
            rVentaLive._ActualizarPedidoPorReenvio(strFiltro, numeroRepartoResult, reparto.IdTransportista, reparto.FechaReparto, True, True)
            rCtaCte._ActualizarNumeroReparto(dr.Field(Of Integer)("IdSucursal"),
                                             dr.Field(Of String)("IdTipoComprobante"),
                                             dr.Field(Of String)("Letra"),
                                             Integer.Parse(dr("CentroEmisor").ToString()),
                                             dr.Field(Of Long)("NumeroComprobante"), numeroRepartoResult)
         Next

         If Not modoAnulacion Then
            For Each repCompOriginal As Entidades.RepartoComprobante In repCompOrigenCol
               strFiltro =
                     String.Format("IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4}",
                                   repCompOriginal.Venta.IdSucursal, repCompOriginal.Venta.IdTipoComprobante, repCompOriginal.Venta.LetraComprobante,
                                          repCompOriginal.Venta.CentroEmisor, repCompOriginal.Venta.NumeroComprobante)
               If dt.Select(strFiltro).Length = 0 Then
                  rVentaLive._ActualizarPedidoPorReenvio(strFiltro, Nothing, Nothing, Nothing)
                  rCtaCte._ActualizarNumeroReparto(repCompOriginal.Venta.IdSucursal, repCompOriginal.Venta.IdTipoComprobante, repCompOriginal.Venta.LetraComprobante,
                                                   repCompOriginal.Venta.CentroEmisor, repCompOriginal.Venta.NumeroComprobante, numeroReparto:=Nothing)
               End If
            Next
         End If

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

      Return numeroRepartoResult
   End Function

   Public Sub ActualizaTotalesResumenes(idSucursal As Integer,
                        idReparto As Integer,
                        totalResumenComprobante As Decimal,
                        totalResumenEfectivo As Decimal,
                        totalResumenTransferencia As Decimal,
                        totalResumenCtaCte As Decimal,
                        totalResumenCheques As Decimal,
                        totalResumenNCred As Decimal,
                        totalResumenReenvio As Decimal,
                        totalResumenSaldoGeneral As Decimal)
      Dim sRepartos = New SqlServer.Repartos(da)
      sRepartos.ActualizaTotalesResumenes(idSucursal, idReparto, totalResumenComprobante, totalResumenEfectivo, totalResumenTransferencia, totalResumenCtaCte, totalResumenCheques, totalResumenNCred, totalResumenReenvio, totalResumenSaldoGeneral)
   End Sub
#End Region

End Class