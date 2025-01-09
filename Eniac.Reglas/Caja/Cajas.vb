Imports System.ComponentModel
Public Class Cajas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Cajas"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(enti As Entidades.Entidad)
      EjecutaConTransaccion(
         Sub()
            Dim entidad = DirectCast(enti, Entidades.Caja)
            entidad.NumeroPlanilla = GetProximoNumeroDePlanilla(entidad.IdSucursal, entidad.IdCaja)
            GrabarPlanilla(entidad)
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Public Function GetPlanillaActual(idSucursal As Integer, idCaja As Integer) As Entidades.Caja
      Return GetPlanillaActual(idSucursal, idCaja, AccionesSiNoExisteRegistro.Nulo)
   End Function

   Public Function GetPlanillaActualONuevaConSaldoFinalCalculado(idSucursal As Integer, idCaja As Integer) As Entidades.Caja
      Dim caja = GetPlanillaActual(idSucursal, idCaja)
      If caja Is Nothing Then
         caja = CrearPlanillaNueva(idSucursal, idCaja)
      End If
      Return CargaSaldoFinalPlanillaAbierta(caja)
   End Function
   Public Function CargaSaldoFinalPlanillaAbierta(plActual As Entidades.Caja) As Entidades.Caja

      Dim saldos = GetSaldosActuales(plActual.IdSucursal, plActual.IdCaja, plActual.NumeroPlanilla)

      plActual.PesosSaldoFinal = plActual.PesosSaldoInicial + saldos.PesosSaldoFinal
      plActual.DolaresSaldoFinal = plActual.DolaresSaldoInicial + saldos.DolaresSaldoFinal
      plActual.TicketsSaldoFinal = plActual.TicketsSaldoInicial + saldos.TicketsSaldoFinal
      plActual.ChequesSaldoFinal = plActual.ChequesSaldoInicial + saldos.ChequesSaldoFinal
      plActual.TarjetasSaldoFinal = plActual.TarjetasSaldoInicial + saldos.TarjetasSaldoFinal
      plActual.RetencionesSaldoFinal = plActual.RetencionesSaldoInicial + saldos.RetencionesSaldoFinal
      plActual.BancosSaldoFinal = plActual.BancosSaldoInicial + saldos.BancosSaldoFinal
      plActual.BancosDolaresSaldoFinal = plActual.BancosDolaresSaldoInicial + saldos.BancosDolaresSaldoFinal

      Return plActual
   End Function
   Public Function CrearPlanillaNueva(idSucursal As Integer, idCaja As Integer) As Entidades.Caja
      Dim eCaja = New Entidades.Caja(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      With eCaja
         '.NumeroPlanilla = 0
         .FechaPlanilla = Date.Now()

         .PesosSaldoInicial = 0
         .PesosSaldoFinal = 0
         .DolaresSaldoInicial = 0
         .DolaresSaldoFinal = 0
         .TicketsSaldoInicial = 0
         .TicketsSaldoFinal = 0
         .ChequesSaldoInicial = 0
         .ChequesSaldoFinal = 0
         .TarjetasSaldoInicial = 0
         .TarjetasSaldoFinal = 0
         .PesosSaldoFinalDigit = 0
         .DolaresSaldoFinalDigit = 0
         .TicketsSaldoFinalDigit = 0
         .ChequesSaldoFinalDigit = 0
         .TarjetasSaldoFinalDigit = 0

         .IdCaja = idCaja
      End With

      Dim rCaja = New Cajas()
      rCaja.Insertar(eCaja)
      Return GetPlanillaActual(idSucursal, idCaja, AccionesSiNoExisteRegistro.Nulo)
   End Function

   Public Function GetPlanillaActual(idSucursal As Integer, idCaja As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Caja
      Return CargaEntidad(New SqlServer.Cajas(da).Cajas_G_GetPlanillaActual(idSucursal, idCaja),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Caja(idSucursal, actual.Nombre, actual.Pwd),
                          accion, Function() String.Format("No existe una planilla actual para Sucursal {0} y Caja {1}", idSucursal, idCaja))
   End Function

   Public Function GetPlanilla(idSucursal As Integer, IdCaja As Integer, numeroPlanilla As Integer) As Entidades.Caja

      Dim stbQuery = New StringBuilder()
      With stbQuery

         .Append("   Select ")
         .Append("   	IdSucursal, ")
         .Append("       NumeroPlanilla, ")
         .Append("       FechaPlanilla, ")
         .Append("   	PesosSaldoInicial, ")
         .Append("   	PesosSaldoFinal, ")
         .Append("   	DolaresSaldoInicial, ")
         .Append("   	DolaresSaldoFinal, ")
         .Append("   	TicketsSaldoInicial, ")
         .Append("   	TicketsSaldoFinal, ")
         .Append("   	ChequesSaldoInicial, ")
         .Append("   	ChequesSaldoFinal, ")
         .Append("   	TarjetasSaldoInicial, ")
         .Append("       TarjetasSaldoFinal, ")
         .Append("   	BancosSaldoInicial, ")
         .Append("       BancosSaldoFinal, ")
         .Append("   	BancosDolaresSaldoInicial, ")
         .Append("       BancosDolaresSaldoFinal, ")
         .Append("   	RetencionesSaldoInicial, ")
         .Append("      RetencionesSaldoFinal, ")
         .Append("      FechaCierrePlanilla ")
         .Append("   From Cajas C ")
         .Append("   Where C.IdSucursal = " & idSucursal & " ")
         .AppendLine(" AND C.IdCaja = " & IdCaja)
         .Append("   And C.NumeroPlanilla = " & numeroPlanilla & " ")
         .Append("   Order By C.FechaPlanilla Desc ")

      End With
      Dim dtFicha As DataTable = da.GetDataTable(stbQuery.ToString())

      Dim oCaja As Entidades.Caja

      If dtFicha.Rows.Count > 0 Then

         Dim drFicha As DataRow = dtFicha.Rows(0)
         oCaja = New Entidades.Caja(actual.Sucursal.Id, actual.Nombre, actual.Pwd)

         With oCaja
            .IdSucursal = actual.Sucursal.Id
            .IdCaja = IdCaja
            .NumeroPlanilla = Convert.ToInt32(drFicha("NumeroPlanilla"))
            .FechaPlanilla = Convert.ToDateTime(drFicha("FechaPlanilla"))
            .PesosSaldoInicial = Convert.ToDecimal(drFicha("PesosSaldoInicial"))
            .PesosSaldoFinal = Convert.ToDecimal(drFicha("PesosSaldoFinal"))
            .DolaresSaldoInicial = Convert.ToDecimal(drFicha("DolaresSaldoInicial"))
            .DolaresSaldoFinal = Convert.ToDecimal(drFicha("DolaresSaldoFinal"))
            .TicketsSaldoInicial = Convert.ToDecimal(drFicha("TicketsSaldoInicial"))
            .TicketsSaldoFinal = Convert.ToDecimal(drFicha("TicketsSaldoFinal"))
            .ChequesSaldoInicial = Convert.ToDecimal(drFicha("ChequesSaldoInicial"))
            .ChequesSaldoFinal = Convert.ToDecimal(drFicha("ChequesSaldoFinal"))
            .TarjetasSaldoInicial = Convert.ToDecimal(drFicha("TarjetasSaldoInicial"))
            .TarjetasSaldoFinal = Convert.ToDecimal(drFicha("TarjetasSaldoFinal"))
            .BancosSaldoInicial = Convert.ToDecimal(drFicha("BancosSaldoInicial"))
            .BancosSaldoFinal = Convert.ToDecimal(drFicha("BancosSaldoFinal"))
            .BancosDolaresSaldoInicial = Convert.ToDecimal(drFicha("BancosDolaresSaldoInicial"))
            .BancosDolaresSaldoFinal = Convert.ToDecimal(drFicha("BancosDolaresSaldoFinal"))
            .RetencionesSaldoInicial = Convert.ToDecimal(drFicha("RetencionesSaldoInicial"))
            .RetencionesSaldoFinal = Convert.ToDecimal(drFicha("RetencionesSaldoFinal"))
            .FechaCierrePlanilla = drFicha.Field(Of Date?)("FechaCierrePlanilla")
         End With

         Return oCaja

      End If

      Return Nothing

   End Function

   Public Function GetPlanillaCaja(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Entidades.Caja

      Dim stbQuery As StringBuilder = New StringBuilder()
      With stbQuery

         .Append("   Select ")
         .Append("   	IdSucursal, ")
         .Append("       NumeroPlanilla, ")
         .Append("       FechaPlanilla, ")
         .Append("   	PesosSaldoInicial, ")
         .Append("   	PesosSaldoFinal, ")
         .Append("   	DolaresSaldoInicial, ")
         .Append("   	DolaresSaldoFinal, ")
         .Append("   	TicketsSaldoInicial, ")
         .Append("   	TicketsSaldoFinal, ")
         .Append("   	ChequesSaldoInicial, ")
         .Append("   	ChequesSaldoFinal, ")
         .Append("   	TarjetasSaldoInicial, ")
         .Append("       TarjetasSaldoFinal,")
         .Append("       FechaCierrePlanilla ")
         .Append("   From Cajas C ")
         .Append("   Where C.IdSucursal = " & idSucursal & " ")
         .AppendFormat("   And C.IdCaja = {0} ", idCaja)
         .Append("   And C.NumeroPlanilla = " & numeroPlanilla & " ")
         .Append("   Order By C.FechaPlanilla Desc ")

      End With
      Dim dtFicha As DataTable = da.GetDataTable(stbQuery.ToString())

      Dim oCaja As Entidades.Caja

      If dtFicha.Rows.Count > 0 Then

         Dim drFicha As DataRow = dtFicha.Rows(0)
         oCaja = New Entidades.Caja(actual.Sucursal.Id, actual.Nombre, actual.Pwd)

         With oCaja
            .IdSucursal = actual.Sucursal.Id
            .NumeroPlanilla = Convert.ToInt32(drFicha("NumeroPlanilla"))
            .FechaPlanilla = Convert.ToDateTime(drFicha("FechaPlanilla"))
            .PesosSaldoInicial = Convert.ToDecimal(drFicha("PesosSaldoInicial"))
            .PesosSaldoFinal = Convert.ToDecimal(drFicha("PesosSaldoFinal"))
            .DolaresSaldoInicial = Convert.ToDecimal(drFicha("DolaresSaldoInicial"))
            .DolaresSaldoFinal = Convert.ToDecimal(drFicha("DolaresSaldoFinal"))
            .TicketsSaldoInicial = Convert.ToDecimal(drFicha("TicketsSaldoInicial"))
            .TicketsSaldoFinal = Convert.ToDecimal(drFicha("TicketsSaldoFinal"))
            .ChequesSaldoInicial = Convert.ToDecimal(drFicha("ChequesSaldoInicial"))
            .ChequesSaldoFinal = Convert.ToDecimal(drFicha("ChequesSaldoFinal"))
            .TarjetasSaldoInicial = Convert.ToDecimal(drFicha("TarjetasSaldoInicial"))
            .TarjetasSaldoFinal = Convert.ToDecimal(drFicha("TarjetasSaldoFinal"))
            .FechaCierrePlanilla = drFicha.Field(Of Date?)("FechaCierrePlanilla")
         End With

         Return oCaja

      End If

      Return Nothing

   End Function

   Public Function GetUltimaPlanilla(idSucursal As Integer, idCaja As Integer) As Entidades.Caja
      Return GetUltimaPlanilla(idSucursal, idCaja, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUltimaPlanilla(idSucursal As Integer, idCaja As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Caja
      Return CargaEntidad(New SqlServer.Cajas(da).Cajas_G_UltimaPlanilla(idSucursal, idCaja),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Caja(idSucursal, actual.Nombre, actual.Pwd),
                          accion, Function() String.Format("No existe una última planilla para Sucursal {0} y Caja {1}", idSucursal, idCaja))
   End Function

   Private Sub CargarUno(o As Entidades.Caja, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .IdCaja = dr.Field(Of Integer)("IdCaja")
         .NumeroPlanilla = dr.Field(Of Integer)("NumeroPlanilla")

         .FechaPlanilla = dr.Field(Of Date)("FechaPlanilla")

         .PesosSaldoInicial = dr.Field(Of Decimal)("PesosSaldoInicial")
         .PesosSaldoFinal = dr.Field(Of Decimal)("PesosSaldoFinal")

         .DolaresSaldoInicial = dr.Field(Of Decimal)("DolaresSaldoInicial")
         .DolaresSaldoFinal = dr.Field(Of Decimal)("DolaresSaldoFinal")

         .ChequesSaldoInicial = dr.Field(Of Decimal)("ChequesSaldoInicial")
         .ChequesSaldoFinal = dr.Field(Of Decimal)("ChequesSaldoFinal")

         .TarjetasSaldoInicial = dr.Field(Of Decimal)("TarjetasSaldoInicial")
         .TarjetasSaldoFinal = dr.Field(Of Decimal)("TarjetasSaldoFinal")

         .TicketsSaldoInicial = dr.Field(Of Decimal)("TicketsSaldoInicial")
         .TicketsSaldoFinal = dr.Field(Of Decimal)("TicketsSaldoFinal")

         .RetencionesSaldoInicial = dr.Field(Of Decimal)("RetencionesSaldoInicial")
         .RetencionesSaldoFinal = dr.Field(Of Decimal)("RetencionesSaldoFinal")

         .BancosSaldoInicial = dr.Field(Of Decimal)("BancosSaldoInicial")
         .BancosSaldoFinal = dr.Field(Of Decimal)("BancosSaldoFinal")

         .BancosDolaresSaldoInicial = dr.Field(Of Decimal)("BancosDolaresSaldoInicial")
         .BancosDolaresSaldoFinal = dr.Field(Of Decimal)("BancosDolaresSaldoFinal")

         .PesosSaldoFinalDigit = dr.Field(Of Decimal)("PesosSaldoFinalDigit")
         .DolaresSaldoFinalDigit = dr.Field(Of Decimal)("DolaresSaldoFinalDigit")
         .ChequesSaldoFinalDigit = dr.Field(Of Decimal)("ChequesSaldoFinalDigit")
         .TarjetasSaldoFinalDigit = dr.Field(Of Decimal)("TarjetasSaldoFinalDigit")
         .TicketsSaldoFinalDigit = dr.Field(Of Decimal)("TicketsSaldoFinalDigit")
         .RetencionesSaldoFinalDigit = dr.Field(Of Decimal)("RetencionesSaldoFinalDigit")
         .BancosSaldoFinalDigit = dr.Field(Of Decimal)("BancosSaldoFinalDigit")
         .BancosDolaresSaldoFinalDigit = dr.Field(Of Decimal)("BancosSaldoFinalDigit")
         .FechaCierrePlanilla = dr.Field(Of Date?)("FechaCierrePlanilla")

      End With
   End Sub

   Friend Sub GrabarPlanilla(ent As Entidades.Caja)
      Dim sqlC = New SqlServer.Cajas(da)
      sqlC.Cajas_I(ent.IdSucursal, ent.IdCaja, ent.NumeroPlanilla, ent.FechaPlanilla,
                   ent.PesosSaldoInicial, ent.PesosSaldoFinal, ent.DolaresSaldoInicial, ent.DolaresSaldoFinal, eurosSaldoInicial:=0, eurosSaldoFinal:=0,
                   ent.ChequesSaldoInicial, ent.ChequesSaldoFinal, ent.TarjetasSaldoInicial, ent.TarjetasSaldoFinal,
                   ent.TicketsSaldoInicial, ent.TicketsSaldoFinal, ent.RetencionesSaldoInicial, ent.RetencionesSaldoFinal,
                   ent.BancosSaldoInicial, ent.BancosSaldoFinal, ent.BancosDolaresSaldoInicial, ent.BancosDolaresSaldoFinal,
                   ent.PesosSaldoFinalDigit, ent.DolaresSaldoFinalDigit, ent.TicketsSaldoFinalDigit, ent.ChequesSaldoFinalDigit,
                   ent.TarjetasSaldoFinalDigit, ent.RetencionesSaldoFinalDigit, ent.BancosSaldoFinalDigit, ent.BancosDolaresSaldoFinalDigit,
                   ent.FechaCierrePlanilla)
   End Sub

   Public Function MoverEntreCajas(pesos As Decimal, tarjetas As Decimal, tickets As Decimal,
                                   dolares As Decimal, bancos As Decimal,
                                   cotizacionDolar As Decimal,
                                   cheques As List(Of Entidades.Cheque), cupones As List(Of Entidades.TarjetaCupon),
                                   idSucursalOrigen As Integer, idCajaOrigen As Integer,
                                   idSucursalDestino As Integer, idCajaDestino As Integer,
                                   idUsuario As String, fecha As Date, observacion As String,
                                   idMonedaImporteBancos As Integer) As Entidades.CajaDetalles
      Return EjecutaConTransaccion(
         Function()
            Return _MoverEntreCajas(pesos, tarjetas, tickets,
                                   dolares, bancos,
                                   cotizacionDolar,
                                   cheques, cupones,
                                   idSucursalOrigen, idCajaOrigen,
                                   idSucursalDestino, idCajaDestino,
                                   idUsuario, fecha, observacion,
                                   idMonedaImporteBancos)
         End Function)
   End Function

   Public Function _MoverEntreCajas(pesos As Decimal, tarjetas As Decimal, tickets As Decimal,
                                    dolares As Decimal, bancos As Decimal,
                                    cotizacionDolar As Decimal,
                                    cheques As List(Of Entidades.Cheque),
                                    cupones As List(Of Entidades.TarjetaCupon),
                                    idSucursalOrigen As Integer, idCajaOrigen As Integer,
                                    idSucursalDestino As Integer, idCajaDestino As Integer,
                                    idUsuario As String, fecha As Date, observacion As String,
                                    idMonedaImporteBancos As Integer) As Entidades.CajaDetalles
      Dim nombreSuc = New Sucursales(da).GetUna(idSucursalOrigen, False).Nombre
      Dim nombreSuc2 = New Sucursales(da).GetUna(idSucursalDestino, False).Nombre

      Dim nombreCaja = New CajasNombres(da).GetUna(idSucursalOrigen, idCajaOrigen).NombreCaja
      Dim nombreCaja2 = New CajasNombres(da).GetUna(idSucursalDestino, idCajaDestino).NombreCaja

      Dim totalCheques As Decimal = 0

      Dim ctaCaj = New CuentasDeCajas(da)
      Dim cajaDet = New CajaDetalles(da)

      Dim sqlChe = New SqlServer.Cheques(da)
      Dim sqlTrj = New SqlServer.TarjetasCupones(da)


      Dim ctbl As Contabilidad = Nothing
      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         ctbl = New Contabilidad(da)
      End If

      'hago los movimientos en los cheques
      For Each ch In cheques
         With ch
            'Dim dt = sqlChe.Get1(ch.IdCheque)
            Dim dt = sqlChe.Get1PorNumeroCheque(idSucursalDestino, .NumeroCheque, .IdBanco, .IdBancoSucursal, .Localidad.IdLocalidad)
            If dt.Rows.Count > 0 Then ' sqlChe.Existe(.IdSucursal2, .NumeroCheque, .IdBanco, .IdBancoSucursal, .Localidad.IdLocalidad) Then
               If idSucursalOrigen <> idSucursalDestino Then
                  Dim dr = dt.Rows(0)
                  If dr.Field(Of Long?)("IdCliente").IfNull() <> ch.Cliente.IdCliente Then
                     Throw New Exception(String.Format("Existe el mismo cheque en la sucursal {0} para otro cliente. El cliente en la sucursal {0} es {1} - {2}",
                                                       nombreSuc2, dr.Field(Of Long)("CodigoCliente"), dr.Field(Of String)("NombreCliente")))
                  End If
                  If dr.Field(Of Decimal)("Importe") <> ch.Importe Then
                     Throw New Exception(String.Format("Existe el mismo cheque en la sucursal {0} con un importe diferente a este. El importe en la sucursal {0} es {1}",
                                                          nombreSuc2, dr.Field(Of Decimal)("Importe")))
                  End If
               End If
            Else
               Dim ch2 = New Entidades.Cheque
               ch2.IdSucursal = idSucursalDestino
               ch2.Banco = .Banco
               ch2.IdBancoSucursal = .IdBancoSucursal
               ch2.Localidad = .Localidad
               ch2.NumeroCheque = .NumeroCheque
               ch2.FechaEmision = .FechaEmision
               ch2.FechaCobro = .FechaCobro
               ch2.Titular = .Titular
               ch2.Importe = .Importe
               ch2.EsPropio = .EsPropio
               ch2.CuentaBancaria = .CuentaBancaria
               ch2.IdEstadoCheque = Entidades.Cheque.Estados.ENCARTERA
               ch2.Cliente = .Cliente
               ch2.Proveedor = .Proveedor
               ch2.Cuit = .Cuit
               ch2.IdTipoCheque = ch.IdTipoCheque
               ch2.NroOperacion = ch.NroOperacion

               Dim rCheque = New Cheques(da)
               rCheque._Inserta(ch2)
               'sqlChe.Cheques_I(.IdSucursal2, .IdCheque, .IdBanco, .IdBancoSucursal, .Localidad.IdLocalidad,
               '                 .NumeroCheque, .FechaEmision, .FechaCobro, .Titular, .Importe,
               '                 0, 0, 0, 0, 0, 0, .EsPropio,
               '                 .IdCuentaBancaria, Entidades.Cheque.Estados.ENCARTERA, .Cliente.IdCliente,
               '                 .Proveedor.IdProveedor, .Cuit, 0, actual.Nombre,
               '                 ch.IdTipoCheque, ch.NroOperacion)
            End If
         End With
      Next

      For Each ch In cheques
         totalCheques += ch.Importe
      Next

      'realizo el egreso en la sucursal origen de la caja -------------------------------------------
      Dim detaE = New Entidades.CajaDetalles(idSucursalOrigen, idUsuario, "")
      With detaE
         .FechaMovimiento = fecha
         .IdSucursal = idSucursalOrigen
         .IdCaja = idCajaOrigen
         .IdTipoMovimiento = "E"c
         .NumeroPlanilla = New Reglas.Cajas(da).GetPlanillaActual(idSucursalOrigen, idCajaOrigen).NumeroPlanilla
         .NumeroMovimiento = cajaDet.GetProximoNumeroDeMovimiento(idSucursalOrigen, idCajaOrigen, .NumeroPlanilla)
         '.Observacion = "Movimiento de egreso de cheques a otra sucursal."

         Dim stb As StringBuilder = New StringBuilder()
         With stb
            If Not String.IsNullOrEmpty(observacion) Then .AppendFormat("{0} - ", observacion)
            .Append("Destino: ")
            If idSucursalOrigen <> idSucursalDestino Then .AppendFormat("Sucursal: {0}, ", nombreSuc2)

            stb.AppendFormat("Caja: {0}", nombreCaja2)

            If cheques.Count > 0 Then .AppendFormat(" - Cant. Cheques: {0}", cheques.Count)
         End With

         .Observacion = stb.ToString().Truncar(100) '# Si la observación quedó más larga que el máximo permitido, la trunco.

         .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CTACAJAMOVCHEQUES.ToString(), "7"))

         .ImportePesos = pesos * -1
         .ImporteTarjetas = tarjetas * -1
         .ImporteTickets = tickets * -1
         .ImporteDolares = dolares * -1
         .CotizacionDolar = cotizacionDolar
         'cambio el monto porque es un egreso
         .ImporteCheques = totalCheques * -1
         .ImporteBancos = bancos * -1
         .EsModificable = False
         .GeneraContabilidad = True
         .IdMonedaImporteBancos = idMonedaImporteBancos
      End With
      ' Insertar nuevo movimiento
      cajaDet.InsertarNuevoMovimiento(detaE)
      ' Asociar Cheques de Terceros
      For Each ch In cheques
         With ch
            sqlChe.Cheques_UAsociarNroMovimientoEgreso(.IdSucursal, detaE.IdCaja, detaE.NumeroPlanilla,
                                                          detaE.NumeroMovimiento, .IdBanco, .IdBancoSucursal,
                                                          .Localidad.IdLocalidad, .NumeroCheque,
                                                          Entidades.Cheque.Estados.EGRESOCAJA, 0, actual.Nombre, .IdCheque)
         End With
      Next

      For Each cp In cupones
         With cp
            sqlTrj.TarjetasCupones_U_MovimientoAsociar(.IdTarjetaCupon, .IdSucursal, detaE.IdCaja, detaE.NumeroPlanilla,
                                                       detaE.NumeroMovimiento, Entidades.TarjetaCupon.Estados.EGRESOCAJA, actual.Nombre, False)
         End With
      Next



      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         ctbl.RegistraContabilidad(detaE)
      End If

      '-------------------------------------------

      'realizo el ingreso en la sucursal destino -------------------------------------------
      Dim detaI = New Entidades.CajaDetalles(idSucursalDestino, idUsuario, "")
      With detaI
         .FechaMovimiento = fecha
         .IdSucursal = idSucursalDestino
         .IdCaja = idCajaDestino
         .IdTipoMovimiento = "I"c
         .NumeroPlanilla = New Reglas.Cajas(da).GetPlanillaActual(idSucursalDestino, idCajaDestino).NumeroPlanilla
         .NumeroMovimiento = cajaDet.GetProximoNumeroDeMovimiento(idSucursalDestino, idCajaDestino, .NumeroPlanilla)
         '.Observacion = "Movimiento de ingreso de cheques desde otra sucursal."

         Dim stb = New StringBuilder()
         With stb
            If Not String.IsNullOrEmpty(observacion) Then .AppendFormat("{0} - ", observacion)
            .Append("Origen: ")
            If idSucursalOrigen <> idSucursalDestino Then .AppendFormat("Sucursal: {0}, ", nombreSuc)

            stb.AppendFormat("Caja: {0}", nombreCaja)

            If cheques.Count > 0 Then .AppendFormat(" - Cant. Cheques: {0}", cheques.Count)
         End With

         .Observacion = stb.ToString().Truncar(100) '# Se trunca la observación para que no se pase de la cantidad máxima permitida

         .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros(da).GetValorPD(Entidades.Parametro.Parametros.CTACAJAMOVCHEQUES.ToString(), "7"))
         .ImportePesos = pesos
         .ImporteTarjetas = tarjetas
         .ImporteTickets = tickets
         .ImporteDolares = dolares
         .CotizacionDolar = cotizacionDolar
         .ImporteCheques = totalCheques
         .ImporteBancos = bancos
         .EsModificable = False
         .GeneraContabilidad = True
         .IdMonedaImporteBancos = idMonedaImporteBancos
      End With
      ' Insertar nuevo movimiento
      cajaDet.InsertarNuevoMovimiento(detaI)
      ' Asociar Cheques de Terceros
      For Each ch As Entidades.Cheque In cheques
         With ch
            '-- REQ-32653.- --
            sqlChe.Cheques_UAsociarNroMovimientoIngreso(detaI.IdSucursal, detaI.IdCaja, detaI.NumeroPlanilla,
                                                           detaI.NumeroMovimiento, .IdBanco, .IdBancoSucursal,
                                                           .Localidad.IdLocalidad, .NumeroCheque,
                                                           Entidades.Cheque.Estados.ENCARTERA, 0, actual.Nombre, .Cuit) ', .IdCheque)
         End With
      Next
      For Each cp In cupones
         With cp
            sqlTrj.TarjetasCupones_U_MovimientoAsociar(.IdTarjetaCupon, detaI.IdSucursal, detaI.IdCaja, detaI.NumeroPlanilla,
                                                       detaI.NumeroMovimiento, Entidades.TarjetaCupon.Estados.ENCARTERA, actual.Nombre, True)
         End With
      Next
      If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea Then
         ctbl.RegistraContabilidad(detaI)
      End If
      '-------------------------------------------

      Return detaI
   End Function

   Public Function GetProximoNumeroDePlanilla(idSucursal As Integer, idCaja As Integer) As Integer

      Dim ProximoNumeroPlanilla As Integer = 1

      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery

         .Append("SELECT MAX(NumeroPlanilla) + 1 ")
         .Append("  FROM Cajas C")
         .Append(" WHERE C.IdSucursal = " & idSucursal.ToString())
         .AppendFormat("   AND C.IdCaja = {0}", idCaja)

      End With
      Dim dtFicha As DataTable = Me.da.GetDataTable(stbQuery.ToString())

      If Not dtFicha.Rows(0)(0) Is System.DBNull.Value Then
         ProximoNumeroPlanilla = Integer.Parse(dtFicha.Rows(0)(0).ToString())
      End If

      Return ProximoNumeroPlanilla

   End Function

   Public Sub CerrarPlanilla(idSucursal As Integer, idCaja As Integer, NumeroPlanilla As Integer)
      CerrarPlanilla(idSucursal, idCaja, NumeroPlanilla, 0, 0, 0, 0, 0, 0, 0, 0, Nothing, Nothing,
                     0, False, False, 0, 0, 0, 0, 0)
   End Sub

   Public Enum ModoCerrarPlanilla
      <Description("Cierre de planilla")> CierreCiego
      <Description("Extracción y cierre de planilla")> CierreConMovimiento
   End Enum

   Public Sub CerrarPlanilla(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer,
                             saldoPesosFinalDigit As Decimal, saldoDolaresFinalDigit As Decimal,
                             saldoTicketsFinalDigit As Decimal, saldoChequesFinalDigit As Decimal,
                             saldoTarjetasFinalDigit As Decimal, saldoRetencionesFinalDigit As Decimal,
                             saldoBancosFinalDigit As Decimal, saldoBancosDolaresFinalDigit As Decimal,
                             idSucursalDestino As Integer?, idCajaDestino As Integer?,
                             importePesosTransferir As Decimal,
                             entregaCheques As Boolean, entregaCupones As Boolean,
                             importeTicketsTransferir As Decimal, importeBancosTransferir As Decimal,
                             importeDolaresTransferir As Decimal, importeBancosDolaresTransferir As Decimal,
                             cotizacionDolar As Decimal)
      EjecutaConTransaccion(
         Sub()
            Dim plActual = CargaSaldoFinalPlanillaAbierta(GetPlanillaActual(idSucursal, idCaja))

            If idSucursalDestino.HasValue AndAlso idCajaDestino.HasValue Then
               If idSucursal = idSucursalDestino.Value And idCaja = idCajaDestino.Value Then
                  Throw New Exception("La caja destino debe ser diferente a la caja origen")
               End If

               If importePesosTransferir <> 0 Or importeTicketsTransferir <> 0 Or
                  (entregaCheques And plActual.ChequesSaldoFinal <> 0) Or
                  (entregaCupones And plActual.TarjetasSaldoFinal <> 0) Or
                  importeBancosTransferir <> 0 Or importeDolaresTransferir <> 0 Then

                  Dim cheques = New List(Of Entidades.Cheque)()
                  If entregaCheques Then
                     Dim rCheques = New Cheques(da)
                     Dim caja = New CajasNombres(da).GetUna(idSucursal, idCaja)
                     Dim suc = New Sucursales(da).GetUna(idSucursal, incluirLogo:=False)
                     Dim estadoCheque = New EstadosCheques(da).GetUno(Entidades.Cheque.Estados.ENCARTERA.ToString())
                     Using dtDetalle = rCheques.GetInforme({suc},
                                                        {caja},
                                                        {estadoCheque},
                                                        fechaCobroDesde:=New Date(), fechaCobroHasta:=New Date(),
                                                        fechaEnCarteraAl:=Nothing,
                                                        numero:=0, idBanco:=0, idLocalidad:=0, esPropio:=False,
                                                        idCliente:=0, idProveedor:=0, titular:=String.Empty,
                                                        fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing,
                                                        idCuentaBancaria:=0, orden:=Entidades.Cheque.Ordenamiento.FECHACOBRO,
                                                        tipoCheque:="", conciliado:=Nothing, observacion:=String.Empty)
                        cheques.AddRange(dtDetalle.AsEnumerable().ToList().
                                          ConvertAll(
                                             Function(dr)
                                                Dim chk = rCheques._GetUnoPorNumeroCheque(
                                                                          idSucursal,
                                                                          dr.Field(Of Integer)("NumeroCheque"),
                                                                          dr.Field(Of Integer)("IdBanco"),
                                                                          dr.Field(Of Integer)("IdBancoSucursal"),
                                                                          dr.Field(Of Integer)("IdLocalidad"))
                                                chk.IdSucursal2 = idSucursalDestino.IfNull(idSucursal)
                                                Return chk
                                             End Function))
                     End Using

                  End If

                  Dim cupones = New List(Of Entidades.TarjetaCupon)()
                  If entregaCupones Then
                     Dim rCupones = New Reglas.TarjetasCupones(da)
                     Dim suc = New Sucursales(da).GetUna(idSucursal, incluirLogo:=False)

                     Using dtDetalle = rCupones.GetInformeCupones({suc},
                                                                  0,
                                                                  Nothing,
                                                                  Nothing,
                                                                  Entidades.TarjetaCupon.Estados.ENCARTERA.ToString(),
                                                                  Nothing, Nothing, 0, 0, Nothing, idCaja, 0, 0, 0, 0)
                        cupones.AddRange(dtDetalle.AsEnumerable().ToList().
                                          ConvertAll(
                                             Function(dr)
                                                Dim cupon = rCupones.GetUno(dr.Field(Of Integer)("IdTarjetaCupon"))
                                                cupon.IdSucursal = idSucursalDestino.IfNull(idSucursal)
                                                Return cupon
                                             End Function))
                     End Using
                  End If


                  Dim moviEntreCaj = New Entidades.CajaDetalles()
                  moviEntreCaj = _MoverEntreCajas(importePesosTransferir,
                                                  If(entregaCupones, plActual.TarjetasSaldoFinal, 0),
                                                  importeTicketsTransferir,
                                                  importeDolaresTransferir,
                                                  importeBancosTransferir,
                                                  cotizacionDolar,
                                                  cheques, cupones,
                                                  actual.Sucursal.Id, idCaja,
                                                  idSucursalDestino.Value, idCajaDestino.Value,
                                                  actual.Nombre, Date.Now, observacion:=String.Empty,
                                                  Entidades.Moneda.Peso)
               End If
               If importeBancosDolaresTransferir <> 0 Then
                  Dim moviEntreCaj = New Entidades.CajaDetalles()
                  moviEntreCaj = _MoverEntreCajas(0,
                                                  0,
                                                  0,
                                                  0,
                                                  importeBancosDolaresTransferir,
                                                  cotizacionDolar,
                                                  New List(Of Entidades.Cheque)(),
                                                  New List(Of Entidades.TarjetaCupon)(),
                                                  actual.Sucursal.Id, idCaja,
                                                  idSucursalDestino.Value, idCajaDestino.Value,
                                                  actual.Nombre, Date.Now, observacion:=String.Empty,
                                                  Entidades.Moneda.Dolar)
               End If

               plActual = GetPlanillaActual(idSucursal, idCaja)
            End If


            Dim saldos = GetSaldosActuales(idSucursal, idCaja, numeroPlanilla)

            plActual.PesosSaldoFinal = plActual.PesosSaldoInicial + saldos.PesosSaldoFinal
            plActual.DolaresSaldoFinal = plActual.DolaresSaldoInicial + saldos.DolaresSaldoFinal
            plActual.TicketsSaldoFinal = plActual.TicketsSaldoInicial + saldos.TicketsSaldoFinal
            plActual.ChequesSaldoFinal = plActual.ChequesSaldoInicial + saldos.ChequesSaldoFinal
            plActual.TarjetasSaldoFinal = plActual.TarjetasSaldoInicial + saldos.TarjetasSaldoFinal
            plActual.RetencionesSaldoFinal = plActual.RetencionesSaldoInicial + saldos.RetencionesSaldoFinal
            plActual.BancosSaldoFinal = plActual.BancosSaldoInicial + saldos.BancosSaldoFinal
            plActual.BancosDolaresSaldoFinal = plActual.BancosDolaresSaldoInicial + saldos.BancosDolaresSaldoFinal

            plActual.FechaCierrePlanilla = Date.Now

            ' Actualizar Saldos
            Dim sqlC = New SqlServer.Cajas(da)
            sqlC.Cajas_U(idSucursal, idCaja, numeroPlanilla,
                         plActual.PesosSaldoFinal, plActual.DolaresSaldoFinal,
                         plActual.TicketsSaldoFinal, plActual.ChequesSaldoFinal,
                         plActual.TarjetasSaldoFinal, plActual.RetencionesSaldoFinal,
                         plActual.BancosSaldoFinal, plActual.BancosDolaresSaldoFinal,
                         saldoPesosFinalDigit, saldoDolaresFinalDigit,
                         saldoTicketsFinalDigit, saldoChequesFinalDigit,
                         saldoTarjetasFinalDigit, saldoRetencionesFinalDigit,
                         saldoBancosFinalDigit, saldoBancosDolaresFinalDigit,
                         plActual.FechaCierrePlanilla)

            ' Crear Nueva Planilla
            Dim oCaja = New Entidades.Caja(idSucursal, actual.Nombre, actual.Pwd)
            With oCaja
               .IdSucursal = idSucursal
               .IdCaja = idCaja
               .NumeroPlanilla = GetProximoNumeroDePlanilla(idSucursal, idCaja)
               .FechaPlanilla = plActual.FechaCierrePlanilla.IfNull(Date.Now)
               .PesosSaldoInicial = plActual.PesosSaldoFinal
               .DolaresSaldoInicial = plActual.DolaresSaldoFinal
               .TicketsSaldoInicial = plActual.TicketsSaldoFinal
               .ChequesSaldoInicial = plActual.ChequesSaldoFinal
               .TarjetasSaldoInicial = plActual.TarjetasSaldoFinal
               .RetencionesSaldoInicial = plActual.RetencionesSaldoFinal
               .BancosSaldoInicial = plActual.BancosSaldoFinal
               .BancosDolaresSaldoInicial = plActual.BancosDolaresSaldoFinal
            End With

            GrabarPlanilla(oCaja)
         End Sub)
   End Sub

   Public Function GetSaldosActuales(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Entidades.Caja
      Return CargaEntidad(New SqlServer.CajasDetalles(da).CajaDetalles_G_SaldosActuales(idSucursal, idCaja, numeroPlanilla),
                          Sub(o, dr) CargarUnoSaldos(o, dr), Function() New Entidades.Caja(),
                          AccionesSiNoExisteRegistro.Vacio, String.Empty)
   End Function
   Private Sub CargarUnoSaldos(o As Entidades.Caja, dr As DataRow)
      With o
         .PesosSaldoFinal = dr.Field(Of Decimal)("ImportePesos")
         .DolaresSaldoFinal = dr.Field(Of Decimal)("ImporteDolares")
         .TicketsSaldoFinal = dr.Field(Of Decimal)("ImporteTickets")
         .ChequesSaldoFinal = dr.Field(Of Decimal)("ImporteCheques")
         .TarjetasSaldoFinal = dr.Field(Of Decimal)("ImporteTarjetas")
         .RetencionesSaldoFinal = dr.Field(Of Decimal)("ImporteRetenciones")
         .BancosSaldoFinal = dr.Field(Of Decimal)("ImporteBancos")
         .BancosDolaresSaldoFinal = dr.Field(Of Decimal)("ImporteBancosDolares")
      End With
   End Sub


   Public Function GetSaldoPesos(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("	Select ")
         .Append("		IsNull(( ")
         .Append("	        Select  ")
         .Append("				Sum(IsNull(ImportePesos,0))  ")
         .Append("			From CajasDetalle  ")
         .Append("			Where IdSucursal = " & idSucursal.ToString() & " ")
         .AppendFormat("			And IdCaja = {0}", idCaja)
         .Append("			And NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
         .Append("		),0)  SaldoPesos ")
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("SaldoPesos"))

   End Function

   Public Function GetSaldoPesosFinal(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim SaldoMovimientos As Decimal = Me.GetSaldoPesos(idSucursal, idCaja, numeroPlanilla)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("SELECT PesosSaldoInicial FROM Cajas")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdCaja = " & idCaja.ToString())
         .AppendLine("   AND NumeroPlanilla = " & numeroPlanilla.ToString())
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("PesosSaldoInicial")) + SaldoMovimientos

   End Function

   Public Function GetSaldoDolares(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("	Select ")
         .Append("		IsNull(( ")
         .Append("	        Select  ")
         .Append("				Sum(IsNull(ImporteDolares,0))  ")
         .Append("			From CajasDetalle  ")
         .Append("			Where IdSucursal = " & idSucursal.ToString() & " ")
         .AppendFormat("			And IdCaja = {0}", idCaja)
         .Append("			And NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
         .Append("		),0)  SaldoDolares ")
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("SaldoDolares"))

   End Function

   Public Function GetSaldoBancos(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("	Select ")
         .Append("		IsNull(( ")
         .Append("	        Select  ")
         .Append("				Sum(IsNull(ImporteBancos,0))  ")
         .Append("			From CajasDetalle  ")
         .Append("			Where IdSucursal = " & idSucursal.ToString() & " ")
         .AppendFormat("			And IdCaja = {0}", idCaja)
         .Append("			And NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
         .Append("		),0)  SaldoBancos ")
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("SaldoBancos"))

   End Function

   Public Function GetSaldoRetenciones(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("	Select ")
         .Append("		IsNull(( ")
         .Append("	        Select  ")
         .Append("				Sum(IsNull(ImporteRetenciones,0))  ")
         .Append("			From CajasDetalle  ")
         .Append("			Where IdSucursal = " & idSucursal.ToString() & " ")
         .AppendFormat("			And IdCaja = {0}", idCaja)
         .Append("			And NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
         .Append("		),0)  SaldoRetenciones ")
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("SaldoRetenciones"))

   End Function
   Public Function GetSaldoTickets(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("	Select ")
         .Append("		IsNull(( ")
         .Append("	        Select  ")
         .Append("				Sum(IsNull(ImporteTickets,0))  ")
         .Append("			From CajasDetalle  ")
         .Append("			Where IdSucursal = " & idSucursal.ToString() & " ")
         .AppendFormat("			And IdCaja = {0}", idCaja)
         .Append("			And NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
         .Append("		),0)  SaldoTickets ")
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("SaldoTickets"))

   End Function

   Public Function GetSaldoCheques(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("	Select ")
         .Append("		IsNull(( ")
         .Append("	        Select  ")
         .Append("				Sum(IsNull(ImporteCheques,0))  ")
         .Append("			From CajasDetalle  ")
         .Append("			Where IdSucursal = " & idSucursal.ToString() & " ")
         .AppendFormat("			And IdCaja = {0}", idCaja)
         .Append("			And NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
         .Append("		),0)  SaldoCheques ")
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("SaldoCheques"))

   End Function

   Public Function GetSaldoChequesFinal(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim SaldoMovimientos As Decimal = Me.GetSaldoCheques(idSucursal, idCaja, numeroPlanilla)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("SELECT ChequesSaldoInicial FROM Cajas")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdCaja = " & idCaja.ToString())
         .AppendLine("   AND NumeroPlanilla = " & numeroPlanilla.ToString())
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("ChequesSaldoInicial")) + SaldoMovimientos

   End Function

   Public Function GetSaldoTarjetas(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("	Select ")
         .Append("		IsNull(( ")
         .Append("	        Select  ")
         .Append("				Sum(IsNull(ImporteTarjetas,0))  ")
         .Append("			From CajasDetalle  ")
         .Append("			Where IdSucursal = " & idSucursal.ToString() & " ")
         .AppendFormat("			And IdCaja = {0}", idCaja)
         .Append("			And NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
         .Append("		),0)  SaldoTarjetas ")
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("SaldoTarjetas"))

   End Function

   Public Function GetSaldoTarjetasFinal(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer) As Decimal

      Dim SaldoMovimientos As Decimal = Me.GetSaldoTarjetas(idSucursal, idCaja, numeroPlanilla)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("SELECT TarjetasSaldoInicial FROM Cajas")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdCaja = " & idCaja.ToString())
         .AppendLine("   AND NumeroPlanilla = " & numeroPlanilla.ToString())
      End With

      Return CDec(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("TarjetasSaldoInicial")) + SaldoMovimientos

   End Function


   Public Function getPlanCuentaCaja(idSucursal As Integer _
                                       , idCaja As Integer _
                                       , numeroPlanilla As Integer) As Integer

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("	Select idplanCuenta from cajas ")
         .Append("	Where IdSucursal = " & idSucursal.ToString() & " ")
         .AppendFormat("	And IdCaja = {0}", idCaja)
         .Append(" And NumeroPlanilla = " & numeroPlanilla.ToString() & " ")
      End With

      Return CInt(Me.da.GetDataTable(myQuery.ToString()).Rows(0)("idplanCuenta"))

   End Function
   Public Function GetPorRangoFechas(idSucursal As Integer, idCaja As Integer, desde As Date, hasta As Date, nroPlanilla As Integer) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim dt = New SqlServer.Cajas(da).Cajas_G_GetPorRangoFechas(idSucursal, idCaja, desde, hasta, nroPlanilla)
            dt.AsEnumerable().Where(Function(dr) Not dr.Field(Of Date?)("FechaCierrePlanilla").HasValue).ToList().
                  ForEach(
                  Sub(dr)
                     Dim saldos = GetSaldosActuales(dr.Field(Of Integer)("IdSucursal"),
                                           dr.Field(Of Integer)("IdCaja"),
                                           dr.Field(Of Integer)("NumeroPlanilla"))

                     dr("PesosSaldoFinal") = dr.Field(Of Decimal)("PesosSaldoInicial") + saldos.PesosSaldoFinal
                     dr("DolaresSaldoFinal") = dr.Field(Of Decimal)("DolaresSaldoInicial") + saldos.DolaresSaldoFinal
                     dr("TicketsSaldoFinal") = dr.Field(Of Decimal)("TicketsSaldoInicial") + saldos.TicketsSaldoFinal
                     dr("ChequesSaldoFinal") = dr.Field(Of Decimal)("ChequesSaldoInicial") + saldos.ChequesSaldoFinal
                     dr("TarjetasSaldoFinal") = dr.Field(Of Decimal)("TarjetasSaldoInicial") + saldos.TarjetasSaldoFinal
                     dr("BancosSaldoFinal") = dr.Field(Of Decimal)("BancosSaldoInicial") + saldos.BancosSaldoFinal
                     dr("BancosDolaresSaldoFinal") = dr.Field(Of Decimal)("BancosDolaresSaldoInicial") + saldos.BancosDolaresSaldoFinal

                  End Sub)
            dt.Columns.OfType(Of DataColumn).Where(Function(dc) dc.ColumnName.EndsWith("Inicial")).ToList().
                  ForEach(
                  Sub(dc)
                     dt.Columns.Remove(dc)
                  End Sub)
            Return dt
         End Function)
   End Function

   Public Function GetAniosDePlanillas(idSucursal As Integer) As DataTable

      Dim myQuery = New StringBuilder()

      With myQuery
         .Length = 0
         .Append("SELECT DISTINCT YEAR(FechaPlanilla) Anio FROM Cajas WHERE IdSucursal = " & idSucursal.ToString() & " ORDER BY 1 DESC")
      End With

      Return da.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetCobranzasDetalladas(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                                          idCliente As Long, idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                          tipoComprobanteAplicador As Entidades.TipoComprobante(),
                                          tipoComprobanteAplicados As Entidades.TipoComprobante(),
                                          idFormaPago As Integer, comercial As String, grabalibro As Entidades.Publicos.SiNoTodos, grupos As Entidades.Grupo(),
                                          ordenarPor As Entidades.FiltrosReportes.InfCobranzasRealizadas.OrdenadoPor) As DataTable
      Return New SqlServer.Cajas(da).GetCobranzasDetalladas(sucursales, desde, hasta,
                                                            idCliente, idVendedor, origenVendedor,
                                                            tipoComprobanteAplicador, tipoComprobanteAplicados,
                                                            idFormaPago, comercial, grabalibro, grupos,
                                                            ordenarPor)
   End Function
   Public Function GetComisionesCobranzasDetalladas(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                                          idCliente As Long, idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                          tipoComprobanteAplicador As Entidades.TipoComprobante(),
                                          tipoComprobanteAplicados As Entidades.TipoComprobante(),
                                          idFormaPago As Integer, comercial As String, grabalibro As Entidades.Publicos.SiNoTodos, grupos As Entidades.Grupo(),
                                          ordenarPor As Entidades.FiltrosReportes.InfCobranzasRealizadas.OrdenadoPor,
                                          ComisionPor As Entidades.Empleado.Tipo,
                                          idCobrador As Integer, origenCobrador As Entidades.OrigenFK) As DataTable
      Return New SqlServer.Cajas(da).GetComisionesCobranzasDetalladas(sucursales, desde, hasta,
                                                            idCliente, idVendedor, origenVendedor,
                                                            tipoComprobanteAplicador, tipoComprobanteAplicados,
                                                            idFormaPago, comercial, grabalibro, grupos,
                                                            ordenarPor, ComisionPor, idCobrador, origenCobrador)
   End Function

   Public Function GetPagosDetallados(idSucursal As Integer,
                                      desde As Date, hasta As Date,
                                      comercial As String,
                                      idComprador As Integer,
                                      idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         'Compras al CONTADO
         .AppendLine("SELECT C.IdSucursal ")
         .AppendLine("      ,CONVERT(varchar(11), C.fecha, 120) AS Fecha ")
         .AppendLine("      ,C.IdTipoComprobante ")
         .AppendLine("      ,C.Letra ")
         .AppendLine("      ,C.CentroEmisor ")
         .AppendLine("      ,C.NumeroComprobante ")
         .AppendLine("      ,'COMPRA' AS TipoCobro")
         .AppendLine("      ,C.TotalNeto AS ImporteNeto")
         .AppendLine("      ,C.ImporteTotal ")
         .AppendLine("      ,C.IdProveedor ")
         .AppendLine("      ,P.CodigoProveedor ")
         .AppendLine("      ,P.NombreProveedor ")
         .AppendLine("      ,C.IdComprador ")
         .AppendLine("      ,E1.NombreEmpleado AS NombreComprador ")
         '.AppendLine("      ,P.TipoDocComprador AS TipoDocCompradorProv ")
         '.AppendLine("      ,P.NroDocComprador AS NroDocCompradorProv ")
         '.AppendLine("      ,E2.NombreEmpleado as NombreCompradorProv ")
         .AppendLine("      ,NULL AS IdTipoComprobante2 ")
         .AppendLine("      ,NULL AS Letra2 ")
         .AppendLine("      ,NULL AS CentroEmisor2 ")
         .AppendLine("      ,NULL AS NumeroComprobante2 ")
         .AppendLine("      ,NULL AS CuotaNumero2 ")
         .AppendLine("      ,NULL AS Fecha2 ")
         .AppendLine("      ,0 AS DiasPago")

         .AppendLine(" FROM VentasFormasPago VFP, TiposComprobantes TC, Compras C ")
         .AppendLine("  INNER JOIN Empleados E1 ON C.IdComprador = E1.IdEmpleado ")
         .AppendLine("  INNER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor ")
         '.AppendLine("  INNER JOIN Empleados E2 ON P.TipoDocComprador = E2.TipoDocEmpleado ")
         '.AppendLine("                         AND P.NroDocComprador = E2.NroDocEmpleado ")

         .AppendLine("  WHERE C.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("   AND C.IdTipoComprobante = TC.IdTipoComprobante ")

         '.AppendLine("   AND (C.IdEstadoComprobante<>'ANULADO' OR C.IdEstadoComprobante IS NULL)")
         .AppendLine("   AND VFP.Dias=0 ")   'Contado
         .AppendLine("   AND TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero
         .AppendLine("   AND C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("	 AND CONVERT(varchar(11), C.fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	 AND CONVERT(varchar(11), C.fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")

         If comercial <> "TODOS" Then
            .AppendLine("   AND TC.EsComercial = '" & IIf(comercial = "SI", "True", "False").ToString() & "' ")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)
         End If

         If idComprador > 0 Then
            .AppendLine("	AND C.IdComprador = " & idComprador)
         End If

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor.ToString())
         End If

         .AppendLine("UNION ALL")

         'Cobranza de RECIBOS

         .AppendLine("SELECT CCP.IdSucursal ")
         .AppendLine("      ,CONVERT(varchar(11), CCP.Fecha, 120) AS Fecha ")
         .AppendLine("      ,CCP.IdTipoComprobante ")
         .AppendLine("      ,CCP.Letra ")
         .AppendLine("      ,CCP.CentroEmisor ")
         .AppendLine("      ,CCP.NumeroComprobante ")
         .AppendLine("      ,'CTACTE' AS TipoCobro")

         'Hago el calculo por regla de 3 simple, para calcular un proporcional del monto, sin impuestos. 
         'Puede haber productos sin 
         .AppendLine("      ,CCP.ImporteCuota * (-1) * (C.TotalNeto) / C.ImporteTotal AS ImporteNeto ")
         .AppendLine("      ,CCP.ImporteCuota * (-1) AS ImporteTotal ")
         .AppendLine("      ,CCP.IdProveedor ")
         .AppendLine("      ,P.CodigoProveedor ")
         .AppendLine("      ,P.NombreProveedor ")

         .AppendLine("      ,C.IdComprador ")
         .AppendLine("      ,E1.NombreEmpleado AS NombreComprador")
         '.AppendLine("      ,NULL AS TipoDocComprador ")
         '.AppendLine("      ,NULL AS NroDocComprador ")
         '.AppendLine("      ,NULL AS NombreComprador ")

         '.AppendLine("      ,C.TipoDocComprador AS TipoDocCompradorProv ")
         '.AppendLine("      ,C.NroDocComprador AS NroDocCompradorProv ")
         '.AppendLine("      ,E2.NombreEmpleado as NombreCompradorProv ")
         .AppendLine("      ,CCP.IdTipoComprobante2 ")
         .AppendLine("      ,CCP.Letra2 ")
         .AppendLine("      ,CCP.CentroEmisor2 ")
         .AppendLine("      ,CCP.NumeroComprobante2 ")
         .AppendLine("      ,CCP.CuotaNumero2 ")
         .AppendLine("      ,C.Fecha AS Fecha2")
         .AppendLine("      ,DATEDIFF(""d"", C.Fecha, CCP.Fecha) AS DiasPago")

         .AppendLine("   FROM CuentasCorrientesProvPagos CCP ")

         .AppendLine("  LEFT OUTER JOIN Compras C ON CCP.IdSucursal = C.IdSucursal  ")
         .AppendLine("                              AND CCP.IdTipoComprobante2 = C.IdTipoComprobante ")
         .AppendLine("                              AND CCP.Letra2 = C.Letra ")
         .AppendLine("                              AND CCP.CentroEmisor2 = C.CentroEmisor ")
         .AppendLine("                              AND CCP.NumeroComprobante2 = C.NumeroComprobante ")
         .AppendLine("                              AND CCP.IdProveedor = C.IdProveedor ")

         .AppendLine("  LEFT OUTER JOIN Empleados E1 ON C.IdComprador = E1.IdEmpleado ")

         .AppendLine("  INNER JOIN Proveedores P ON CCP.IdProveedor = P.IdProveedor ")

         .AppendLine("  INNER JOIN CategoriasFiscales CF ON P.IdCategoriaFiscal = CF.IdCategoriaFiscal ")

         .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante ")

         '.AppendLine("  WHERE CCP.IdTipoComprobante IN ('PAGO', 'ANTICIPO') ")
         .AppendLine("  WHERE (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')")

         .AppendLine("   AND CCP.IdSucursal = " & idSucursal.ToString())
         .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")

         If comercial <> "TODOS" Then
            .AppendLine("   AND TC.EsComercial = '" & IIf(comercial = "SI", "True", "False").ToString() & "' ")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)
         End If

         If idComprador > 0 Then
            .AppendLine("	AND C.IdComprador = " & idComprador)
         End If

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor.ToString())
         End If

         'IdSucursal

         .AppendLine(" ORDER BY 1")
         .AppendLine("         ,15")
         .AppendLine("         ,13 ")
         .AppendLine("         ,14 ")

         '.AppendLine("      ,fecha")
         '.AppendLine("      ,IdTipoComprobante ")
         '.AppendLine("      ,Letra ")
         '.AppendLine("      ,CentroEmisor ")
         '.AppendLine("      ,NumeroComprobante ")

         .AppendLine("         ,2, 3, 4, 5, 6 ")

      End With

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetConsultaSaldosDeCaja(sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(), soloConSaldos As Boolean) As DataTable
      Return New SqlServer.Cajas(da).GetConsultaSaldosDeCaja(sucursales, cajas, soloConSaldos)
   End Function

#End Region

End Class