Public Class ReservasTurismoPasajeros
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ReservasTurismoPasajeros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ReservaTurismoPasajero)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ReservaTurismoPasajero)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ReservaTurismoPasajero)))
   End Sub

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ReservasTurismoPasajeros(da).ReservaPasajeros_GA()
   End Function

#End Region

#Region "Metodos Privados"
   Public Sub _Insertar(entidad As Entidades.ReservaTurismoPasajero)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.ReservaTurismoPasajero)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.ReservaTurismoPasajero)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Private Sub EjecutaSP(en As Entidades.ReservaTurismoPasajero, tipo As TipoSP)
      Dim sqlC = New SqlServer.ReservasTurismoPasajeros(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ReservasTurismoPasajeros_I(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva,
                                            en.IdPasajero, en.IdResponsablePasajero,
                                            en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisorComprobante, en.NumeroComprobante,
                                            en.PorcentajeLiberado, en.Costo, en.IdClientePasajero,
                                            en.IdSucursalComprobanteFact, en.IdTipoComprobanteFact, en.LetraComprobanteFact, en.CentroEmisorComprobanteFact, en.NumeroComprobanteFact)
         Case TipoSP._U
            sqlC.ReservasTurismoPasajeros_U(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva,
                                            en.IdPasajero, en.IdResponsablePasajero,
                                            en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisorComprobante, en.NumeroComprobante,
                                            en.PorcentajeLiberado, en.Costo, en.IdClientePasajero,
                                            en.IdSucursalComprobanteFact, en.IdTipoComprobanteFact, en.LetraComprobanteFact, en.CentroEmisorComprobanteFact, en.NumeroComprobanteFact)
         Case TipoSP._D
            sqlC.ReservasTurismoPasajeros_D(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva, en.IdPasajero)
      End Select
   End Sub

   Public Sub ActualizaDesdeReserva(reserva As Entidades.ReservaTurismo)
      If reserva.Pasajeros IsNot Nothing Then
         For Each pasajero In reserva.Pasajeros
            pasajero.IdSucursal = reserva.IdSucursal
            pasajero.IdTipoReserva = reserva.IdTipoReserva
            pasajero.Letra = reserva.Letra
            pasajero.CentroEmisor = reserva.CentroEmisor
            pasajero.NumeroReserva = reserva.NumeroReserva

            If pasajero.IdPasajero > 0 Then
               _Actualizar(pasajero)
            Else
               pasajero.IdPasajero = GetCodigoMaximo(reserva.IdSucursal, reserva.IdTipoReserva, reserva.Letra,
                                                     reserva.CentroEmisor, reserva.NumeroReserva) + 1
               _Insertar(pasajero)
            End If
         Next
         For Each Pasajero As Entidades.ReservaTurismoPasajero In reserva.Pasajeros.Borrados
            If Pasajero.IdPasajero > 0 Then
               _Borrar(Pasajero)
            End If
         Next
      End If
   End Sub

   Private Sub CargarUno(o As Entidades.ReservaTurismoPasajero, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.ReservaTurismoPasajero.Columnas.IdSucursal.ToString())
         .IdTipoReserva = dr.Field(Of String)(Entidades.ReservaTurismoPasajero.Columnas.IdTipoReserva.ToString())
         .Letra = dr.Field(Of String)(Entidades.ReservaTurismoPasajero.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.ReservaTurismoPasajero.Columnas.CentroEmisor.ToString())
         .NumeroReserva = dr.Field(Of Long)(Entidades.ReservaTurismoPasajero.Columnas.NumeroReserva.ToString())
         .IdPasajero = dr.Field(Of Integer)(Entidades.ReservaTurismoPasajero.Columnas.IdPasajero.ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.ReservaTurismoPasajero.Columnas.IdResponsablePasajero.ToString()).ToString()) Then
            .IdResponsablePasajero = dr.Field(Of Long)(Entidades.ReservaTurismoPasajero.Columnas.IdResponsablePasajero.ToString())
         End If
         .IdTipoComprobante = dr.Field(Of String)(Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobante.ToString())
         .LetraComprobante = dr.Field(Of String)(Entidades.ReservaTurismoPasajero.Columnas.LetraComprobante.ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobante.ToString()).ToString()) Then
            .CentroEmisorComprobante = dr.Field(Of Integer)(Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobante.ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobante.ToString()).ToString()) Then
            .NumeroComprobante = dr.Field(Of Long)(Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobante.ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.ReservaTurismoPasajero.Columnas.PorcentajeLiberado.ToString()).ToString()) Then
            .PorcentajeLiberado = dr.Field(Of Decimal)(Entidades.ReservaTurismoPasajero.Columnas.PorcentajeLiberado.ToString())
         End If
         .Costo = dr.Field(Of Decimal)(Entidades.ReservaTurismoPasajero.Columnas.Costo.ToString())
         .NombrePasajero = dr.Field(Of String)(Entidades.ReservaTurismoPasajero.Columnas.NombrePasajero.ToString())
         .NombreResponsable = dr.Field(Of String)(Entidades.ReservaTurismoPasajero.Columnas.NombreResponsable.ToString())
         .IdClientePasajero = dr.Field(Of Long)(Entidades.ReservaTurismoPasajero.Columnas.IdClientePasajero.ToString())

         .IdSucursalComprobanteFact = dr.Field(Of Integer?)(Entidades.ReservaTurismoPasajero.Columnas.IdSucursalComprobanteFact.ToString()).IfNull()
         .IdTipoComprobanteFact = dr.Field(Of String)(Entidades.ReservaTurismoPasajero.Columnas.IdTipoComprobanteFact.ToString()).IfNull()
         .LetraComprobanteFact = dr.Field(Of String)(Entidades.ReservaTurismoPasajero.Columnas.LetraComprobanteFact.ToString()).IfNull()
         .CentroEmisorComprobanteFact = dr.Field(Of Integer?)(Entidades.ReservaTurismoPasajero.Columnas.CentroEmisorComprobanteFact.ToString()).IfNull()
         .NumeroComprobanteFact = dr.Field(Of Long?)(Entidades.ReservaTurismoPasajero.Columnas.NumeroComprobanteFact.ToString()).IfNull()

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numero As Long, idPasajero As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.ReservaTurismoPasajero
      Return CargaEntidad(New SqlServer.ReservasTurismoPasajeros(da).ReservaPasajeros_G1(idSucursal, idTipoReserva, letra, centroEmisor, numero, idPasajero),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ReservaTurismoPasajero(),
                          accion, Function() String.Format("No existe el Pasajero Numero: {0}", numero))
   End Function

   Public Function GetTodos(Optional ordenarPosicion As Boolean = False) As List(Of Entidades.ReservaTurismoPasajero)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ReservaTurismoPasajero())
   End Function

   Public Function GetReservasPasajeros(idsucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long) As DataTable
      Return New SqlServer.ReservasTurismoPasajeros(da).GetReservaPasajeros(idsucursal, idTipoReserva, letra, centroEmisor, numeroReserva)
   End Function

   Public Function GetParaCuentaCorriente(idsucursal As Integer, idTipoReserva As String, letra As String, centroemisor As Short, numeroReserva As Long,
                                          generacion As Entidades.Publicos.SiNoTodos,
                                          primerVencimiento As Date, adelanto As Decimal) As DataTable
      Dim dt = New SqlServer.ReservasTurismoPasajeros(da).GetParaCuentaCorriente(idsucursal, idTipoReserva, letra, centroemisor, numeroReserva, generacion)

      Dim reserva = New ReservasTurismo(da).GetUno(idsucursal, idTipoReserva, letra, centroemisor, numeroReserva, AccionesSiNoExisteRegistro.Excepcion)
      Dim tipoViaje = New TurismoTiposViajes(da).GetUno(reserva.IdTipoViaje.IfNull(), AccionesSiNoExisteRegistro.Excepcion)

      If generacion <> Entidades.Publicos.SiNoTodos.SI Then
         dt.AsEnumerable().Where(Function(dr) dr.Field(Of String)("IdTipoComprobante") Is Nothing).ToList().ForEach(
         Sub(dr)
            Dim calculo = CalculoCuotas(dr.Field(Of Date?)("FechaViaje"), primerVencimiento,
                                        dr.Field(Of Decimal)("Importe"), adelanto,
                                        tipoViaje)

            dr.SetField("Selec", True)
            dr.SetField("PrimerVencimiento", calculo.PrimerVencimiento)
            dr.SetField("Anticipo", calculo.Anticipo)
            dr.SetField("CantidadCuotas", calculo.CantidadCuotas)
            dr.SetField("ImportePrimerCuota", calculo.ImportePrimerCuota)
            dr.SetField("ImporteUltimaCuota", calculo.ImporteUltimaCuota)

         End Sub)
      End If

      Return dt
   End Function

   Public Function GetParaFacturacion(idsucursal As Integer, idTipoReserva As String, letra As String, centroemisor As Short, numeroReserva As Long,
                                      generacion As Entidades.Publicos.SiNoTodos) As DataTable '',
      ''                                primerVencimiento As Date, adelanto As Decimal) As DataTable
      Dim dt = New SqlServer.ReservasTurismoPasajeros(da).GetParaFacturacion(idsucursal, idTipoReserva, letra, centroemisor, numeroReserva, generacion)

      'Dim reserva = New ReservasTurismo(da).GetUno(idsucursal, idTipoReserva, letra, centroemisor, numeroReserva, AccionesSiNoExisteRegistro.Excepcion)
      'Dim tipoViaje = New TurismoTiposViajes(da).GetUno(reserva.IdTipoViaje.IfNull(), AccionesSiNoExisteRegistro.Excepcion)

      'If generacion <> Entidades.Publicos.SiNoTodos.SI Then
      '   dt.AsEnumerable().Where(Function(dr) dr.Field(Of String)("IdTipoComprobante") Is Nothing).ToList().ForEach(
      '   Sub(dr)
      '      Dim calculo = CalculoCuotas(dr.Field(Of Date?)("FechaViaje"), primerVencimiento,
      '                                  dr.Field(Of Decimal)("Importe"), adelanto,
      '                                  tipoViaje)

      '      dr.SetField("Selec", True)
      '      dr.SetField("PrimerVencimiento", calculo.PrimerVencimiento)
      '      dr.SetField("Anticipo", calculo.Anticipo)
      '      dr.SetField("CantidadCuotas", calculo.CantidadCuotas)
      '      dr.SetField("ImportePrimerCuota", calculo.ImportePrimerCuota)
      '      dr.SetField("ImporteUltimaCuota", calculo.ImporteUltimaCuota)

      '   End Sub)
      'End If

      Return dt
   End Function

   Public Class CalculoCuotasResult
      Public Property PrimerVencimiento As Date
      Public Property Anticipo As Decimal
      Public Property CantidadCuotas As Integer
      Public Property ImportePrimerCuota As Decimal
      Public Property ImporteUltimaCuota As Decimal
   End Class
   Public Function CalculoCuotas(fechaViaje As Date?, primerVencimiento As Date,
                                 importeTotal As Decimal, adelanto As Decimal,
                                 tipoViaje As Entidades.TurismoTipoViaje) As CalculoCuotasResult
      Dim cantidadCuotas = CalculaCantidadCuotas(fechaViaje, primerVencimiento, tipoViaje)
      Dim importeTotalSinAnticipo = importeTotal - adelanto
      Dim importeCuotasIniciales = (importeTotalSinAnticipo / cantidadCuotas).MidRound(1, 0, 10, MidRoundBehaviour.Ceiling)
      Dim difImporteTotalCuotasTotales = (importeCuotasIniciales * cantidadCuotas) - importeTotalSinAnticipo
      Dim ultimaCuota As Decimal = importeCuotasIniciales - difImporteTotalCuotasTotales

      Return New CalculoCuotasResult() With
         {
            .PrimerVencimiento = primerVencimiento,
            .Anticipo = adelanto,
            .CantidadCuotas = cantidadCuotas,
            .ImportePrimerCuota = importeCuotasIniciales,
            .ImporteUltimaCuota = ultimaCuota
         }

   End Function

   Public Function CalculaCantidadCuotas(fechaViaje As Date?, fechaPrimerVencimiento As Date, tipoViaje As Entidades.TurismoTipoViaje) As Integer
      If fechaViaje.HasValue Then

         'PE-35453 / 1) Obtener la cantidad de cuotas de la diferencia de meses entre la Fecha de Viaje (FV) y
         '              la Fecha del Primer Vencimiento (FPV).
         Dim cantCuotas = Convert.ToInt32(DateDiff(DateInterval.Month, fechaPrimerVencimiento.PrimerDiaMes(), fechaViaje.Value.PrimerDiaMes()))
         ''''Rutina original eliminada.
         ''''If fechaPrimerVencimiento.AddMonths(cantCuotas) > fechaViaje.Value.AddDays(-1) Then
         ''''   cantCuotas -= 1
         ''''End If

         'PE-35453 / 2) Si el día de la FV es mayor a la "Cant días última cuota" (CDUC), se le debe sumar 1 a la cantidad de copias.
         If fechaViaje.Value.Day > tipoViaje.CantidadDiasUltimaCuota Then
            cantCuotas += 1
         End If

         'PE-35453 / 3) Al momento de calcular los vencimientos de las cuotas, si la FPV es mayor a la FV - CDUC debo tomar como
         '              fecha de vencimiento de la cuota FV - CDUC.
         'Esto se determina al momento de calcular los vencimiento al guardar


         'PE-35453 / 4) En caso de que los siguientes vencimientos de la cuota (que se calculan a partir de las tablas de intereses)
         '              es mayor a FV - CDUC, se debe descartar dicho vencimiento (grabar NULL).
         'Esto se determina al momento de calcular los vencimiento al guardar

         Return cantCuotas
      End If
      Return 0
   End Function


   Public Function GetReservaPasajero2(idsucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long) As List(Of Entidades.ReservaTurismoPasajero)
      Return CargaLista(GetReservasPasajeros(idsucursal, idTipoReserva, letra, centroEmisor, numeroReserva),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ReservaTurismoPasajero())
   End Function

   Public Overloads Function GetCodigoMaximo(idsucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long) As Integer
      Return Integer.Parse(New SqlServer.ReservasTurismoPasajeros(da).GetCodigoMaximo(idsucursal, idTipoReserva, letra, centroEmisor, numeroReserva).ToString())
   End Function

   Public Sub ActualizarComprobante(idSucursal As Integer,
                                    idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                    idCliente As Long,
                                    idSucursalComprobante As Integer,
                                    idTipoComprobante As String, letraComprobante As String, centroEmisorComprobante As Integer, numeroComprobanteComprobante As Long,
                                    idTipoLiquidacion As Entidades.ReservaTurismo.TipoGeneracionOpciones)
      Dim sqlC = New SqlServer.ReservasTurismoPasajeros(da)
      Dim sqlR = New SqlServer.ReservasTurismo(da)

      sqlC.ActualizarComprobante(idSucursal,
                                 idTipoReserva, letra, centroEmisor, numeroReserva,
                                 If(idTipoLiquidacion = Entidades.ReservaTurismo.TipoGeneracionOpciones.Establecimiento, 0, idCliente),
                                 idSucursalComprobante,
                                 idTipoComprobante, letraComprobante, centroEmisorComprobante, numeroComprobanteComprobante,
                                 modo:=String.Empty)
      sqlR.ActualizarReserva(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva, idTipoLiquidacion)
   End Sub
   Public Sub ActualizarComprobanteFact(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long, idCliente As Long,
                                        idSucursalComprobanteFact As Integer, idTipoComprobanteFact As String, letraComprobanteFact As String, centroEmisorComprobanteFact As Integer, numeroComprobanteComprobanteFact As Long)
      Dim sqlC = New SqlServer.ReservasTurismoPasajeros(da)

      sqlC.ActualizarComprobante(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva, idCliente,
                                 idSucursalComprobanteFact, idTipoComprobanteFact, letraComprobanteFact, centroEmisorComprobanteFact, numeroComprobanteComprobanteFact,
                                 modo:="Fact")
   End Sub

   Public Sub ActualizarReservasPasajeros(idSucursalComprobante As Integer, idTipoComprobante As String, letraComprobante As String, centroEmisorComprobante As Integer, numeroComprobanteComprobante As Long)
      Dim sqlC = New SqlServer.ReservasTurismoPasajeros(da)
      sqlC.ActualizarReservasTurismoPasajeros(idSucursalComprobante, idTipoComprobante, letraComprobante, centroEmisorComprobante, numeroComprobanteComprobante)
      sqlC.ActualizarReservasTurismoPasajerosFact(idSucursalComprobante, idTipoComprobante, letraComprobante, centroEmisorComprobante, numeroComprobanteComprobante)
   End Sub

   Public Sub ActualizarComprobantePorComprobante(vtaActual As Entidades.Venta, vtaNueva As Entidades.Venta)
      Dim sql = New SqlServer.ReservasTurismoPasajeros(da)
      sql.ActualizarComprobantePorComprobante(vtaNueva.IdSucursal,
                                              vtaActual.IdTipoComprobante, vtaActual.LetraComprobante, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
                                              vtaNueva.IdSucursal,
                                              vtaNueva.IdTipoComprobante, vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)
   End Sub

#End Region

End Class