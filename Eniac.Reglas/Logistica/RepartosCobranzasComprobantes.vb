Public Class RepartosCobranzasComprobantes
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.RepartoCobranzaComprobante.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RepartoCobranzaComprobante)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RepartoCobranzaComprobante)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RepartoCobranzaComprobante)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.RepartosCobranzasComprobantes(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RepartosCobranzasComprobantes(da).RepartosCobranzasComprobantes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.RepartoCobranzaComprobante, tipo As TipoSP)
      Dim sqlC As SqlServer.RepartosCobranzasComprobantes = New SqlServer.RepartosCobranzasComprobantes(da)

      Dim rProducto = New RepartosCobranzasProductos(da)
      Dim rCheque = New RepartosCobranzasCheques(da)
      Dim rNCAplicado = New RepartosCobranzasNCAplicadas(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.RepartosCobranzasComprobantes_I(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                                 en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                                 en.MedioPagoSeleccionado, en.SaldoComprobante, en.TotalEfectivo, en.TotalCuentaCorriente, en.TotalCheques, en.TotalNC, en.TotalAplicado, en.TotalReenvio,
                                                 en.TotalTransferencia, en.IdCuentaBancaria, en.FechaTransferencia,
                                                 en.IdSucursalRecibo, en.IdTipoComprobanteRecibo, en.LetraRecibo, en.CentroEmisorRecibo, en.NumeroComprobanteRecibo)
            rProducto._Insertar(en)
            rCheque._Insertar(en)
            rNCAplicado._Insertar(en)
         Case TipoSP._U
            sqlC.RepartosCobranzasComprobantes_U(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                                 en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                                 en.MedioPagoSeleccionado, en.SaldoComprobante, en.TotalEfectivo, en.TotalCuentaCorriente, en.TotalCheques, en.TotalNC, en.TotalAplicado, en.TotalReenvio,
                                                 en.TotalTransferencia, en.IdCuentaBancaria, en.FechaTransferencia,
                                                 en.IdSucursalRecibo, en.IdTipoComprobanteRecibo, en.LetraRecibo, en.CentroEmisorRecibo, en.NumeroComprobanteRecibo)
            rProducto._Borrar(en)._Insertar(en)
            rCheque._Borrar(en)._Insertar(en)
            rNCAplicado._Borrar(en)._Insertar(en)
         Case TipoSP._D
            rProducto._Borrar(en)
            rCheque._Borrar(en)
            rNCAplicado._Borrar(en)
            sqlC.RepartosCobranzasComprobantes_D(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                                 en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RepartoCobranzaComprobante, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.RepartoCobranzaComprobante.Columnas.IdSucursal.ToString())
         .IdReparto = dr.Field(Of Integer)(Entidades.RepartoCobranzaComprobante.Columnas.IdReparto.ToString())
         .IdCobranza = dr.Field(Of Integer)(Entidades.RepartoCobranzaComprobante.Columnas.IdCobranza.ToString())

         .IdSucursalComp = dr.Field(Of Integer)(Entidades.RepartoCobranzaComprobante.Columnas.IdSucursalComp.ToString())
         .IdTipoComprobanteComp = dr.Field(Of String)(Entidades.RepartoCobranzaComprobante.Columnas.IdTipoComprobanteComp.ToString())
         .LetraComp = dr.Field(Of String)(Entidades.RepartoCobranzaComprobante.Columnas.LetraComp.ToString())
         .CentroEmisorComp = Convert.ToInt16(dr.Field(Of Integer)(Entidades.RepartoCobranzaComprobante.Columnas.CentroEmisorComp.ToString()))
         .NumeroComprobanteComp = dr.Field(Of Long)(Entidades.RepartoCobranzaComprobante.Columnas.NumeroComprobanteComp.ToString())

         .MedioPagoSeleccionado = dr.Field(Of String)(Entidades.RepartoCobranzaComprobante.Columnas.MedioPagoSeleccionado.ToString())

         .SaldoComprobante = dr.Field(Of Decimal)(Entidades.RepartoCobranzaComprobante.Columnas.SaldoComprobante.ToString())

         .TotalEfectivo = dr.Field(Of Decimal)(Entidades.RepartoCobranzaComprobante.Columnas.TotalEfectivo.ToString())
         .TotalCuentaCorriente = dr.Field(Of Decimal)(Entidades.RepartoCobranzaComprobante.Columnas.TotalCuentaCorriente.ToString())
         .TotalCheques = dr.Field(Of Decimal)(Entidades.RepartoCobranzaComprobante.Columnas.TotalCheques.ToString())
         .TotalNC = dr.Field(Of Decimal)(Entidades.RepartoCobranzaComprobante.Columnas.TotalNC.ToString())
         .TotalAplicado = dr.Field(Of Decimal)(Entidades.RepartoCobranzaComprobante.Columnas.TotalAplicado.ToString())
         .TotalReenvio = dr.Field(Of Decimal)(Entidades.RepartoCobranzaComprobante.Columnas.TotalReenvio.ToString())

         .TotalTransferencia = dr.Field(Of Decimal)(Entidades.RepartoCobranzaComprobante.Columnas.TotalTransferencia.ToString())
         .IdCuentaBancaria = dr.Field(Of Integer?)(Entidades.RepartoCobranzaComprobante.Columnas.IdCuentaBancaria.ToString())
         .FechaTransferencia = dr.Field(Of Date?)(Entidades.RepartoCobranzaComprobante.Columnas.FechaTransferencia.ToString())

         .Productos = New RepartosCobranzasProductos(da).GetTodos(.IdSucursal, .IdReparto, .IdCobranza,
                                                                  .IdSucursalComp, .IdTipoComprobanteComp, .LetraComp, .CentroEmisorComp, .NumeroComprobanteComp)
         .Cheques = New RepartosCobranzasCheques(da).GetTodos(.IdSucursal, .IdReparto, .IdCobranza,
                                                              .IdSucursalComp, .IdTipoComprobanteComp, .LetraComp, .CentroEmisorComp, .NumeroComprobanteComp)
         .NCAplicadas = New RepartosCobranzasNCAplicadas(da).GetTodos(.IdSucursal, .IdReparto, .IdCobranza,
                                                                      .IdSucursalComp, .IdTipoComprobanteComp, .LetraComp, .CentroEmisorComp, .NumeroComprobanteComp)

         .IdSucursalRecibo = dr.Field(Of Integer?)(Entidades.RepartoCobranzaComprobante.Columnas.IdSucursalRecibo.ToString()).IfNull()
         .IdTipoComprobanteRecibo = dr.Field(Of String)(Entidades.RepartoCobranzaComprobante.Columnas.IdTipoComprobanteRecibo.ToString())
         .LetraRecibo = dr.Field(Of String)(Entidades.RepartoCobranzaComprobante.Columnas.LetraRecibo.ToString())
         .CentroEmisorRecibo = Convert.ToInt16(dr.Field(Of Integer?)(Entidades.RepartoCobranzaComprobante.Columnas.CentroEmisorRecibo.ToString()).IfNull())
         .NumeroComprobanteRecibo = dr.Field(Of Long?)(Entidades.RepartoCobranzaComprobante.Columnas.NumeroComprobanteRecibo.ToString()).IfNull()

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.RepartoCobranzaComprobante)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Insertar(entidad As Entidades.RepartoCobranza)
      entidad.Comprobantes.All(Function(x)
                                  x.IdSucursal = entidad.IdSucursal
                                  x.IdReparto = entidad.IdReparto
                                  x.IdCobranza = entidad.IdCobranza
                                  _Insertar(x)
                                  Return True
                               End Function)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.RepartoCobranzaComprobante)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.RepartoCobranzaComprobante)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RepartoCobranza)
      _Borrar(New Entidades.RepartoCobranzaComprobante() With {.IdSucursal = entidad.IdSucursal, .IdReparto = entidad.IdReparto, .IdCobranza = entidad.IdCobranza})
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          idCobranza As Integer,
                          idSucursalComp As Integer,
                          idTipoComprobanteComp As String,
                          letraComp As String,
                          centroEmisorComp As Short,
                          numeroComprobanteComp As Long) As Entidades.RepartoCobranzaComprobante
      Return GetUno(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          idCobranza As Integer,
                          idSucursalComp As Integer,
                          idTipoComprobanteComp As String,
                          letraComp As String,
                          centroEmisorComp As Short,
                          numeroComprobanteComp As Long,
                          accion As AccionesSiNoExisteRegistro) As Entidades.RepartoCobranzaComprobante
      Return CargaEntidad(New SqlServer.RepartosCobranzasComprobantes(da).RepartosCobranzasComprobantes_G1(idSucursal, idReparto, idCobranza,
                                                                                                              idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaComprobante(),
                          accion, Function()
                                     Dim stb = New StringBuilder("No existe Comprobante de Cobranza de Reparto con ")
                                     stb.AppendFormat("IdSucursal: {0}, IdReparto: {1}, IdCobranza: {2} ", idSucursal, idReparto, idCobranza)
                                     stb.AppendFormat("IdSucursalComp: {0}, IdTipoComprobanteComp: {1}, LetraComp: {2}, CentroEmisorComp: {3}, NumeroComprobanteComp: {4} ", idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp)
                                     Return stb.ToString()
                                  End Function)
   End Function

   Public Function GetTodos(idSucursal As Integer, idReparto As Integer, idCobranza As Integer) As List(Of Entidades.RepartoCobranzaComprobante)
      Return CargaLista(New SqlServer.RepartosCobranzasComprobantes(da).RepartosCobranzasComprobantes_GA(idSucursal, idReparto, idCobranza),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaComprobante())
   End Function

   Public Function GetTodos() As List(Of Entidades.RepartoCobranzaComprobante)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaComprobante())
   End Function

#End Region

   Public Shared Function Parse(drCol As IEnumerable(Of Entidades.dtsRegistracionPagosV2.ComprobantesRow)) As List(Of Entidades.RepartoCobranzaComprobante)
      Dim result = New List(Of Entidades.RepartoCobranzaComprobante)()
      drCol.All(Function(dr)
                   result.Add(Parse(dr))
                   Return True
                End Function)
      Return result
   End Function
   Public Shared Function Parse(dr As Entidades.dtsRegistracionPagosV2.ComprobantesRow) As Entidades.RepartoCobranzaComprobante
      Dim comp = New Entidades.RepartoCobranzaComprobante()
      comp.IdSucursalComp = dr.IdSucursal
      comp.IdTipoComprobanteComp = dr.IdTipoComprobante
      comp.LetraComp = dr.Letra
      comp.CentroEmisorComp = Convert.ToInt16(dr.CentroEmisor)
      comp.NumeroComprobanteComp = dr.NumeroComprobante
      comp.MedioPagoSeleccionado = DirectCast(dr.MedioPagoSeleccionado, RegistracionPagosMedioPago).ToString()
      comp.SaldoComprobante = dr.SaldoComprobante
      comp.TotalEfectivo = dr.TotalEfectivo
      comp.TotalCuentaCorriente = dr.TotalCuentaCorriente
      comp.TotalCheques = dr.TotalCheques
      comp.TotalNC = dr.TotalNC
      comp.TotalAplicado = dr.TotalAplicado
      comp.TotalReenvio = dr.TotalReenvio

      comp.TotalTransferencia = dr.TotalTransferencia
      If Not dr.IsIdCuentaBancariaNull() Then
         comp.IdCuentaBancaria = dr.IdCuentaBancaria
      End If
      If Not dr.IsFechaTransferenciaNull() Then
         comp.FechaTransferencia = dr.FechaTransferencia
      End If

      If dr.ReciboGenerado IsNot Nothing Then
         Dim recibo = DirectCast(dr.ReciboGenerado, Entidades.CuentaCorriente)
         comp.IdSucursalRecibo = recibo.IdSucursal
         comp.IdTipoComprobanteRecibo = recibo.TipoComprobante.IdTipoComprobante
         comp.LetraRecibo = recibo.Letra
         comp.CentroEmisorRecibo = recibo.CentroEmisor
         comp.NumeroComprobanteRecibo = recibo.NumeroComprobante
      End If

      comp.Cheques = RepartosCobranzasCheques.Parse(dr.GetChequesRows())
      comp.Productos = RepartosCobranzasProductos.Parse(dr.GetProductosRows().Where(Function(drP) drP.Devuelve <> 0))
      comp.NCAplicadas = RepartosCobranzasNCAplicadas.Parse(dr.GetNCAplicadasRows())

      Return comp

   End Function

   Public Function ObtenerRecibosDetallado(nroReparto As Integer) As DataTable
      Return New SqlServer.RepartosCobranzasComprobantes(da).ObtenerRecibosDetallado(nroReparto)
   End Function

End Class