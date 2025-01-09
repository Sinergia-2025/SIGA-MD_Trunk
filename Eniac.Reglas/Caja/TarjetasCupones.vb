Public Class TarjetasCupones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.TarjetaCupon.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.TarjetaCupon)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.TarjetaCupon)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.TarjetaCupon)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.TarjetasCupones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.TarjetasCupones(da).TarjetasCupones_GA()
   End Function
#End Region

#Region "Metodos Privados"


   Private Sub EjecutaSP(en As Entidades.TarjetaCupon, tipo As TipoSP)
      Dim sql = New SqlServer.TarjetasCupones(da)
      Select Case tipo
         Case TipoSP._I
            sql.TarjetasCupones_I(en.IdSucursal, en.IdTarjetaCupon, en.IdTarjeta, en.IdBanco, en.Monto, en.Cuotas, en.NumeroLote,
                                  en.NumeroCupon, en.FechaEmision, en.IdEstadoTarjeta, en.IdCajaIngreso, en.NroPlanillaIngreso,
                                  en.NroMovimientoIngreso, en.IdCajaEgreso, en.NroPlanillaEgreso, en.NroMovimientoEgreso,
                                  en.IdUsuarioActualizacion, en.FechaActualizacion, en.IdCliente, en.IdProveedor, en.IdSituacionCupon)
         Case TipoSP._U
            sql.TarjetasCupones_U(en.IdTarjetaCupon, en.IdSituacionCupon)
         Case TipoSP._D
            sql.TarjetasCupones_D(en.IdTarjetaCupon)

      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.TarjetaCupon, dr As DataRow)
      With o
         .IdTarjetaCupon = dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.IdSucursal.ToString())
         .IdTarjeta = dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.IdTarjeta.ToString())
         .IdBanco = dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.IdBanco.ToString())
         .Monto = dr.Field(Of Decimal)(Entidades.TarjetaCupon.Columnas.Monto.ToString())
         .Cuotas = dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.Cuotas.ToString())
         .NumeroLote = dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.NumeroLote.ToString())
         .NumeroCupon = dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.NumeroCupon.ToString())
         .FechaEmision = dr.Field(Of Date)(Entidades.TarjetaCupon.Columnas.FechaEmision.ToString())

         .IdEstadoTarjeta = dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString()).StringToEnum(Entidades.TarjetaCupon.Estados.NINGUNO)
         .IdEstadoTarjetaAnt = dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.IdEstadoTarjetaAnt.ToString()).IfNull().StringToEnum(Entidades.TarjetaCupon.Estados.NINGUNO)

         .IdCajaIngreso = dr.Field(Of Integer?)(Entidades.TarjetaCupon.Columnas.IdCajaIngreso.ToString()).IfNull()
         .NroPlanillaIngreso = dr.Field(Of Integer?)(Entidades.TarjetaCupon.Columnas.NroPlanillaIngreso.ToString()).IfNull()
         .NroMovimientoIngreso = dr.Field(Of Integer?)(Entidades.TarjetaCupon.Columnas.NroMovimientoIngreso.ToString()).IfNull()

         .IdCajaEgreso = dr.Field(Of Integer?)(Entidades.TarjetaCupon.Columnas.IdCajaEgreso.ToString()).IfNull()
         .NroPlanillaEgreso = dr.Field(Of Integer?)(Entidades.TarjetaCupon.Columnas.NroPlanillaEgreso.ToString()).IfNull()
         .NroMovimientoEgreso = dr.Field(Of Integer?)(Entidades.TarjetaCupon.Columnas.NroMovimientoEgreso.ToString()).IfNull()

         .IdUsuarioActualizacion = dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.IdUsuarioActualizacion.ToString()).IfNull()
         .FechaActualizacion = dr.Field(Of Date)(Entidades.TarjetaCupon.Columnas.FechaActualizacion.ToString())

         .IdCliente = dr.Field(Of Long?)("IdCliente").IfNull()
         .IdProveedor = dr.Field(Of Long?)("IdProveedor").IfNull()

         .IdSituacionCupon = dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.IdSituacionCupon.ToString())
         .NombreBanco = dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.NombreBanco.ToString())
         .NombreTarjeta = dr.Field(Of String)(Entidades.TarjetaCupon.Columnas.NombreTarjeta.ToString())

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Insertar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.TarjetaCupon), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.TarjetaCupon), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.TarjetaCupon), TipoSP._D)
   End Sub


   Public Function GetPorCuentaCorriente(ent As Entidades.CuentaCorriente) As List(Of Entidades.TarjetaCupon)
      Return CargaLista(New SqlServer.TarjetasCupones(da).
                           TarjetasCupones_GA_PorComprobanteCtaCte(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante,
                                                                   ent.Letra, ent.CentroEmisor, ent.NumeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TarjetaCupon())
   End Function

   Public Function GetPorComprobanteCompra(ent As Entidades.Compra) As List(Of Entidades.TarjetaCupon)
      Return CargaLista(New SqlServer.TarjetasCupones(da).
                           TarjetasCupones_GA_PorComprobanteCompra(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante,
                                                                   ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Proveedor.IdProveedor),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TarjetaCupon())
   End Function

   Public Sub AnularCupones(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String)
      Dim sql As SqlServer.TarjetasCupones = New SqlServer.TarjetasCupones(da)
      Dim rDepositosTarjetasCupones As Reglas.DepositosTarjetasCupones = New Reglas.DepositosTarjetasCupones(da)

      '# Por cada Cupón devuelto
      For Each cupon As Entidades.DepositosTarjetasCupones In rDepositosTarjetasCupones.GetTodas(idSucursal, numeroDeposito, idTipoComprobante, Nothing)

         '# Vuelvo a su estado anterior 
         ActualizaEstadoAnular(cupon.IdTarjetaCupon)
      Next

      '# Elimino el registro de la tabla relacionada DepositosTarjetasCupones
      rDepositosTarjetasCupones.BorrarTodos(idSucursal, numeroDeposito, idTipoComprobante)

   End Sub

   Public Sub ActualizaEstadoAnular(idTarjetaCupon As Integer)
      ActualizaEstado(idTarjetaCupon, volverAEstadoAnterior:=True, nuevoEstado:=Nothing, nuevoEstadoAnt:=Nothing)
   End Sub
   Public Sub ActualizaEstado(idTarjetaCupon As Integer, nuevoEstado As Entidades.TarjetaCupon.Estados)
      ActualizaEstado(idTarjetaCupon, volverAEstadoAnterior:=False, nuevoEstado, nuevoEstadoAnt:=Nothing)
   End Sub
   Public Sub ActualizaEstado(idTarjetaCupon As Integer, nuevoEstado As Entidades.TarjetaCupon.Estados, nuevoEstadoAnt As Entidades.TarjetaCupon.Estados)
      ActualizaEstado(idTarjetaCupon, volverAEstadoAnterior:=False, nuevoEstado, nuevoEstadoAnt)
   End Sub
   Private Sub ActualizaEstado(idTarjetaCupon As Integer, volverAEstadoAnterior As Boolean, nuevoEstado As Entidades.TarjetaCupon.Estados, nuevoEstadoAnt As Entidades.TarjetaCupon.Estados?)
      Dim sql = New SqlServer.TarjetasCupones(da)
      sql.ActualizaEstado(idTarjetaCupon, volverAEstadoAnterior, nuevoEstado, nuevoEstadoAnt)
   End Sub
   Public Function GetTodos() As List(Of Entidades.TarjetaCupon)
      Return GetTodos(GetAll())
   End Function
   Public Function GetTodos(dt As DataTable) As List(Of Entidades.TarjetaCupon)
      If dt.Any() Then
         Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TarjetaCupon())
      Else
         Return New List(Of Entidades.TarjetaCupon)()
      End If
   End Function

   Public Overloads Function GetAll(venta As Entidades.Venta) As DataTable
      Return New SqlServer.TarjetasCupones(da).TarjetasCupones_GA_Venta(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)
   End Function
   Public Function GetTodos(venta As Entidades.Venta) As List(Of Entidades.TarjetaCupon)
      Return CargaLista(GetAll(venta), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TarjetaCupon())
   End Function

   Public Overloads Function GetAll(ctacte As Entidades.CuentaCorriente) As DataTable
      Return New SqlServer.TarjetasCupones(da).TarjetasCupones_GA_CtaCte(ctacte.IdSucursal, ctacte.TipoComprobante.IdTipoComprobante, ctacte.Letra, ctacte.CentroEmisor, ctacte.NumeroComprobante)
   End Function
   Public Function GetTodos(ctacte As Entidades.CuentaCorriente) As List(Of Entidades.TarjetaCupon)
      Return CargaLista(GetAll(ctacte), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TarjetaCupon())
   End Function

   Public Function Get1(idTarjetasCupon As Integer) As DataTable
      Return New SqlServer.TarjetasCupones(da).TarjetasCupones_G1(idTarjetasCupon)
   End Function
   Public Function GetUno(idTarjetasCupon As Integer) As Entidades.TarjetaCupon
      Return GetUno(idTarjetasCupon, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTarjetasCupon As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TarjetaCupon
      Return CargaEntidad(Get1(idTarjetasCupon), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TarjetaCupon(),
                          accion, Function() String.Format("El cupón de Tarjeta con el siguiente código de cupon {0} no existe. Por favor verifique.", idTarjetasCupon))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TarjetasCupones(da).GetCodigoMaximo()
   End Function
   Public Function GetInformeCupones(sucursales As Entidades.Sucursal(), idTarjetaCupon As Integer,
                                     fechaIngresoDesde As Date?, fechaIngresoHasta As Date?,
                                     idEstadoTarjeta As String,
                                     fechaLiquidacionDesde As Date?, fechaLiquidacionHasta As Date?,
                                     numeroCupon As Integer, numeroLote As Integer,
                                     fechaEnCarteraAl As Date?,
                                     idCaja As Integer, idBanco As Integer,
                                     idCliente As Long, idTarjeta As Integer, idSituacion As Integer) As DataTable
      Return New SqlServer.TarjetasCupones(da).
               TarjetasCupones_GA(sucursales, idTarjetaCupon,
                                  fechaIngresoDesde, fechaIngresoHasta,
                                  idEstadoTarjeta,
                                  fechaLiquidacionDesde, fechaLiquidacionHasta,
                                  numeroCupon, numeroLote,
                                  fechaEnCarteraAl,
                                  idCaja, idBanco,
                                  idCliente, idTarjeta, idSituacion)
   End Function

   Public Function GetCupon(idSucursal As Integer, numeroCupon As Integer, numeroLote As Integer) As DataTable
      Return New SqlServer.TarjetasCupones(da).TarjetasCupones_GCupon(idSucursal, numeroCupon, numeroLote)
   End Function
   Public Sub _Insertar(idTarjetaCupon As Integer,
                        idSucursal As Integer,
                        idTarjeta As Integer,
                        idBanco As Integer,
                        monto As Decimal,
                        cuotas As Integer,
                        numerolote As Integer,
                        numeroCupon As Integer,
                        fechaEmision As Date,
                        idEstadoTarjeta As Entidades.TarjetaCupon.Estados,
                        idCajaIngreso As Integer,
                        nroPlanillaIngreso As Integer,
                        nroMovimientoIngreso As Integer,
                        idCajaEgreso As Integer,
                        nroPlanillaEgreso As Integer,
                        nroMovimientoEgreso As Integer,
                        idUsuarioActualizacion As String,
                        fechaActualizacion As Date,
                        idCliente As Long,
                        idProveedor As Long,
                        idSituacionCupon As Integer)

      Dim sql = New SqlServer.TarjetasCupones(da)

      sql.TarjetasCupones_I(idSucursal,
                            idTarjetaCupon,
                           idTarjeta,
                           idBanco,
                           monto,
                           cuotas,
                           numerolote,
                           numeroCupon,
                           fechaEmision,
                           idEstadoTarjeta,
                           idCajaIngreso,
                           nroPlanillaIngreso,
                           nroMovimientoIngreso,
                           idCajaEgreso,
                           nroPlanillaEgreso,
                           nroMovimientoEgreso,
                           idUsuarioActualizacion,
                           fechaActualizacion,
                           idCliente,
                           idProveedor,
                           idSituacionCupon)

   End Sub

   Public Sub _ActualizaCupon(idTarjetaCupon As Integer,
                              idCajaIngreso As Integer,
                              nroPlanillaIngreso As Integer,
                              nroMovimientoIngreso As Integer)

      Dim sql = New SqlServer.TarjetasCupones(da)

      sql.TarjetasCupones_UC(idTarjetaCupon,
                             idCajaIngreso,
                             nroPlanillaIngreso,
                             nroMovimientoIngreso)

   End Sub
   Public Function Existe(idTarjetaCupon As Integer) As Boolean
      Return Get1(idTarjetaCupon).Any()
   End Function

   Public Function GetTodosDeMovimientoCaja(eCajaDetalles As Entidades.CajaDetalles) As List(Of Entidades.TarjetaCupon)
      Return GetTodosDeMovimientoCaja(eCajaDetalles.IdSucursal, eCajaDetalles.IdCaja, eCajaDetalles.NumeroPlanilla, eCajaDetalles.NumeroMovimiento)
   End Function
   Public Function GetTodosDeMovimientoCaja(idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer) As List(Of Entidades.TarjetaCupon)
      Return CargaLista(GetAllDeMovimientoCaja(idSucursal, idCaja, nroPlanilla, nroMovimiento),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TarjetaCupon)
   End Function
   Public Function GetAllDeMovimientoCaja(idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer) As DataTable
      Return New SqlServer.TarjetasCupones(da).TarjetasCupones_GA_DeMovimientoCaja(idSucursal, idCaja, nroPlanilla, nroMovimiento)
   End Function

   Public Sub AsociarCuponAMovimientoIngreso(cupon As Entidades.TarjetaCupon, cajaDetalle As Entidades.CajaDetalles)
      AsociarCuponAMovimientoIngreso(cupon.IdTarjetaCupon, cajaDetalle.IdSucursal, cajaDetalle.IdCaja, cajaDetalle.NumeroPlanilla, cajaDetalle.NumeroMovimiento,
                                     cupon.IdEstadoTarjeta)
   End Sub
   Public Sub AsociarCuponAMovimientoIngreso(idTarjetaCupon As Integer, idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer,
                                             idEstadoTarjeta As Entidades.TarjetaCupon.Estados)
      AsociarCuponAMovimiento(idTarjetaCupon, idSucursal, idCaja, nroPlanilla, nroMovimiento, idEstadoTarjeta, ingresoEgreso:=True)
   End Sub

   Public Sub AsociarCuponAMovimientoEgreso(cupon As Entidades.TarjetaCupon, cajaDetalle As Entidades.CajaDetalles)
      AsociarCuponAMovimientoEgreso(cupon.IdTarjetaCupon, cajaDetalle.IdSucursal, cajaDetalle.IdCaja, cajaDetalle.NumeroPlanilla, cajaDetalle.NumeroMovimiento,
                                    cupon.IdEstadoTarjeta)
   End Sub
   Public Sub AsociarCuponAMovimientoEgreso(idTarjetaCupon As Integer, idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer,
                                            idEstadoTarjeta As Entidades.TarjetaCupon.Estados)
      AsociarCuponAMovimiento(idTarjetaCupon, idSucursal, idCaja, nroPlanilla, nroMovimiento, idEstadoTarjeta, ingresoEgreso:=False)
   End Sub

   Private Sub AsociarCuponAMovimiento(idTarjetaCupon As Integer, idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer,
                                       idEstadoTarjeta As Entidades.TarjetaCupon.Estados, ingresoEgreso As Boolean)
      Dim sql = New SqlServer.TarjetasCupones(da)
      sql.TarjetasCupones_U_MovimientoAsociar(idTarjetaCupon, idSucursal, idCaja, nroPlanilla, nroMovimiento,
                                              idEstadoTarjeta, idUsuarioActualizacion:=actual.Nombre, ingresoEgreso)
   End Sub

   Public Sub DesasociarCuponAMovimiento(cajaDetalle As Entidades.CajaDetalles, idEstadoTarjeta As Entidades.TarjetaCupon.Estados)
      DesasociarCuponAMovimiento(cajaDetalle.IdSucursal, cajaDetalle.IdCaja, cajaDetalle.NumeroPlanilla, cajaDetalle.NumeroMovimiento,
                                 idEstadoTarjeta, idEstadoTarjetaAnt:=idEstadoTarjeta,
                                 cajaDetalle.IdTipoMovimiento)
   End Sub

   Public Sub DesasociarCuponAMovimiento(idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer,
                                         idEstadoTarjeta As Entidades.TarjetaCupon.Estados?, idEstadoTarjetaAnt As Entidades.TarjetaCupon.Estados?,
                                         idTipoMovimiento As String)
      Dim sql = New SqlServer.TarjetasCupones(da)
      sql.TarjetasCupones_U_MovimientoDesasociar(idSucursal, idCaja, nroPlanilla, nroMovimiento, idEstadoTarjeta, idEstadoTarjetaAnt,
                                                 fechaActualizacion:=Nothing, idUsuarioActualizacion:=actual.Nombre, idTipoMovimiento = Entidades.CajaDetalles.TipoMovimiento.Ingreso)
   End Sub


   Public Function GetCajaDetallesAyudaCuponesTarjetas(estados As Entidades.TarjetaCupon.Estados(), fechaEmisionDesde As Date?, fechaEmisionHasta As Date?,
                                                       idTarjeta As Integer, idBanco As Integer, numeroLote As Integer, numeroCupon As Integer,
                                                       idCliente As Long, idProveedor As Long, idCaja As Integer) As DataTable
      Dim sql = New SqlServer.TarjetasCupones(da)
      Dim dt = sql.GetCajaDetallesAyudaCuponesTarjetas(estados, fechaEmisionDesde, fechaEmisionHasta,
                                                       idTarjeta, idBanco, numeroLote, numeroCupon,
                                                       idCliente, idProveedor, idCaja)
      dt.Columns.Add("Selec", GetType(Boolean))
      dt.AsEnumerable().ToList().ForEach(Sub(dr) dr("Selec") = False)
      Return dt
   End Function

   Public Function GetSaldoCuponesEnCartera(IdSucursal As Integer,
                                            IdCaja As Integer) As Decimal

      Dim sql = New SqlServer.TarjetasCupones(da)

      Try
         Dim Saldo As Decimal

         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Saldo = sql.GetSaldoCuponesEnCartera(IdSucursal, IdCaja)

         Me.da.CommitTransaction()

         Return Saldo

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

#End Region

End Class