Imports Eniac.Entidades
Imports Eniac.SqlServer

Partial Class CuentasCorrientesPagos
   Public Function GetParaSincronizacionMovilDebeHaber(mesesEnviar As Integer, sucs As IEnumerable(Of Integer)) As DataTable
      Return New SqlServer.CuentasCorrientesPagos(da).GetParaSincronizacionMovilDebeHaber(mesesEnviar, sucs)
   End Function
   Public Function GetParaAlerta(sucursales As Entidades.Sucursal(),
                                 fechaVancimientoHasta As Date?,
                                 saldoMinimoAlerta As Decimal,
                                 cantidadComprobanteAdeudados As Integer,
                                 incluirEmbarcacion As Boolean) As DataTable

      Dim dt = New SqlServer.CuentasCorrientesPagos(da).
                     GetParaAlerta(sucursales, fechaVancimientoHasta, saldoMinimoAlerta, cantidadComprobanteAdeudados, incluirEmbarcacion)

      Dim p = Sub(dc As DataColumn, caption As String, ByRef orden As Integer)
                 dc.Caption = caption
                 dc.SetOrdinal(orden)
                 orden += 1
              End Sub

      Dim pos = 0I
      'p(dt.Columns("TipoDocCliente"), "Tipo", pos)
      'p(dt.Columns("NroDocCliente"), "Documento", pos)
      p(dt.Columns("CodigoCliente"), "Código", pos)
      p(dt.Columns("NombreCliente"), "Cliente", pos)
      'p(dt.Columns("NombreDeFantasia"), "Nombre de Fantasia", pos)
      p(dt.Columns("NombreCategoria"), "Categoria", pos)
      p(dt.Columns("NombreZonaGeografica"), "Zona Geograf.", pos)
      p(dt.Columns("Telefono"), "Teléfono", pos)
      p(dt.Columns("Celular"), "Celular", pos)
      If incluirEmbarcacion Then
         p(dt.Columns("NombreEmbarcacion"), "Embarcación", pos)
      End If
      p(dt.Columns("Saldo"), "Saldo", pos)

      'dt.Columns("TipoDocCliente").Caption = "Tipo"
      'dt.Columns("NroDocCliente").Caption = "Documento"
      'dt.Columns("CodigoCliente").Caption = "Código"
      'dt.Columns("NombreCliente").Caption = "Cliente"
      'dt.Columns("Telefono").Caption = "Teléfono"
      'If incluirEmbarcacion Then
      '   dt.Columns("NombreEmbarcacion").Caption = "Embarcación"
      'End If

      dt.Columns.Remove("IdCliente")
      If incluirEmbarcacion Then
         dt.Columns.Remove("IdEmbarcacion")
         dt.Columns.Remove("CodigoEmbarcacion")
      End If
      dt.Columns.Remove("Total")
      dt.Columns.Remove("Cantidad")

      Return dt
   End Function

   '-- REQ-35667.- -----------------------------------------------------------------
   Public Function GetPorCodigoBarra(codigoBarra As String, codigoBarraSirplus As String) As DataTable
      Return New SqlServer.CuentasCorrientesPagos(da).GetPorCodigoBarra(codigoBarra, codigoBarraSirplus, idCliente:=Nothing, fechaVencimiento:=Nothing, importe:=Nothing)
   End Function
   Public Function GetPorCodigoBarraAlternativo(idCliente As Long, fechaVencimiento As Date, importe As Decimal) As DataTable
      Return New SqlServer.CuentasCorrientesPagos(da).GetPorCodigoBarra(codigoBarra:=Nothing, codigoBarraSirplus:=Nothing, idCliente, fechaVencimiento, importe)
   End Function
   '--------------------------------------------------------------------------------

   Public Shared Function CalcularPromedioPagoPonderados(fechaAplicacionPago As Date,
                                                         comprobantes As List(Of Entidades.CuentaCorrientePago),
                                                         pesos As Decimal, dolares As Decimal, tarjetas As Decimal,
                                                         transferencia As Decimal, fechaTransf As Date?,
                                                         cheques As List(Of Entidades.Cheque),
                                                         retenciones As List(Of Entidades.Retencion), tipoComprobante As TipoComprobante) As PagosPromediosResult

      Dim PromedioPonderadoFinal As New PagosPromediosResult

      Dim comprobantePrin = tipoComprobante.IdTipoComprobante
      Dim comprobanteSecu = tipoComprobante.IdTipoComprobanteSecundario

      '-- Declara Lista de Pagos.- ----------------------------------------------------------------------------------------------
      Dim lPagos As New List(Of PagosPromedios)
      Dim totalPagos As Decimal
      '-- Efectivos.- -----------------------------------------------------------------------------------------------------------
      If pesos > 0 Then
         Dim drP As New PagosPromedios With
               {
                  .Medio = "Efectivo $",
                  .NumeroPago = 1,
                  .FechaPago = fechaAplicacionPago.Date,
                  .Importe = pesos,
                  .ImportePago = 0,
                  .PorcentajeAfecta = 0,
                  .DiasDirectos = 0,
                  .PorcentajeDias = 0,
                  .Procesado = False,
                  .Orden = 1
               }
         lPagos.Add(drP)
         '-- Sumariza Importes Pagos
         totalPagos += drP.Importe
      End If
      '-- Dolares.- -------------------------------------------------------------------------------------------------------------
      If dolares > 0 Then
         Dim cotizacion = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion
         Dim drP As New PagosPromedios With
               {
                  .Medio = "Efectivo U$s",
                  .NumeroPago = 1,
                  .FechaPago = fechaAplicacionPago.Date,
                  .Importe = (dolares * cotizacion),
                  .ImportePago = 0,
                  .PorcentajeAfecta = 0,
                  .DiasDirectos = 0,
                  .PorcentajeDias = 0,
                  .Procesado = False,
                  .Orden = 2
               }
         lPagos.Add(drP)
         '-- Sumariza Importes Pagos
         totalPagos += drP.Importe
      End If
      '-- Tarjetas.- ------------------------------------------------------------------------------------------------------------
      If tarjetas > 0 Then
         Dim drP As New PagosPromedios With
               {
                  .Medio = "Tarjeta",
                  .NumeroPago = 1,
                  .FechaPago = fechaAplicacionPago.Date,
                  .Importe = tarjetas,
                  .ImportePago = 0,
                  .PorcentajeAfecta = 0,
                  .DiasDirectos = 0,
                  .PorcentajeDias = 0,
                  .Procesado = False,
                  .Orden = 3
               }
         lPagos.Add(drP)
         '-- Sumariza Importes Pagos
         totalPagos += drP.Importe

      End If
      '-- Transferencias.- ------------------------------------------------------------------------------------------------------
      If transferencia > 0 Then
         Dim drP As New PagosPromedios With
               {
                  .Medio = "Transferencia",
                  .NumeroPago = 1,
                  .FechaPago = If(fechaTransf.Date.IfNull() < fechaAplicacionPago.Date, fechaAplicacionPago.Date, fechaTransf.Date.IfNull()),
                  .Importe = transferencia,
                  .ImportePago = 0,
                  .PorcentajeAfecta = 0,
                  .DiasDirectos = 0,
                  .PorcentajeDias = 0,
                  .Procesado = False,
                  .Orden = 4
               }
         lPagos.Add(drP)
         '-- Sumariza Importes Pagos
         totalPagos += drP.Importe
      End If
      '-- Anticipos.- -----------------------------------------------------------------------------------------------------------
      For Each drAnticipos In comprobantes.Where(Function(x) x.TipoComprobante.EsAnticipo = True And x.TipoComprobante.EsFacturable = False And x.TipoComprobante.Grupo = "CTACTE").OrderBy(Function(x) x.FechaEmision)
         '-- Calcula Fecha de Anticipo.- ----------------------------------------------------------------------------------------
         Dim fechaAnticipo As Date
         If drAnticipos.CantidadDiasCobro.HasValue Then
            fechaAnticipo = DateAdd(DateInterval.Day, drAnticipos.CantidadDiasCobro.IfNull(), drAnticipos.FechaEmision.Date)
         Else
            Dim diasCobro As Long = 0
            Dim fechaCobro As Date?

            If New Reglas.CuentasCorrientesCheques().RecuperaCantidadDiasCobro(drAnticipos, comprobantePrin, fechaCobro) Then
               diasCobro = DateDiff(DateInterval.Day, drAnticipos.FechaEmision.Date, fechaCobro.IfNull().Date)
               drAnticipos.CantidadDiasCobro = diasCobro
            End If
            fechaAnticipo = DateAdd(DateInterval.Day, diasCobro, drAnticipos.FechaEmision.Date)
         End If
         Dim drP As New PagosPromedios With
               {
                  .Medio = "Anticipos $",
                  .NumeroPago = 1,
                  .FechaPago = If(fechaAnticipo < fechaAplicacionPago, fechaAplicacionPago.Date, fechaAnticipo.Date),
                  .Importe = (drAnticipos.Paga * -1),
                  .ImportePago = 0,
                  .PorcentajeAfecta = 0,
                  .DiasDirectos = 0,
                  .PorcentajeDias = 0,
                  .Procesado = False,
                  .Orden = 5
               }
         lPagos.Add(drP)
         '-- Sumariza Importes Pagos
         totalPagos += drP.Importe
      Next
      '-- Notas Credito.- -----------------------------------------------------------------------------------------------------------
      For Each drNotaCred In comprobantes.Where(Function(x) x.TipoComprobante.EsAnticipo = False And x.TipoComprobante.CoeficienteValores = -1 And x.TipoComprobante.Grupo = "VENTAS").OrderBy(Function(x) x.FechaEmision)
         Dim drP As New PagosPromedios With
               {
                  .Medio = "Nota Credito $",
                  .NumeroPago = 1,
                  .FechaPago = fechaAplicacionPago,
                  .Importe = (drNotaCred.Paga * -1),
                  .ImportePago = 0,
                  .PorcentajeAfecta = 0,
                  .DiasDirectos = 0,
                  .PorcentajeDias = 0,
                  .Procesado = False,
                  .Orden = 6
               }
         lPagos.Add(drP)
         '-- Actualiza Grilla.-
         drNotaCred.CantidadDiasCobro = 0
         drNotaCred.PromedioDiasCobro = 0
         '-- Sumariza Importes Pagos
         totalPagos += drP.Importe
      Next

      '-- Retenciones.- ---------------------------------------------------------------------------------------------------------
      For Each drReten In retenciones.OrderBy(Function(x) x.FechaEmision)
         Dim drP As New PagosPromedios With
               {
                  .Medio = String.Format("Retencion {0}", drReten.NumeroRetencion),
                  .NumeroPago = 1,
                  .FechaPago = If(drReten.FechaEmision < fechaAplicacionPago, fechaAplicacionPago.Date, drReten.FechaEmision.Date),
                  .Importe = drReten.ImporteTotal,
                  .ImportePago = 0,
                  .PorcentajeAfecta = 0,
                  .DiasDirectos = 0,
                  .PorcentajeDias = 0,
                  .Procesado = False,
                  .Orden = 7
               }
         lPagos.Add(drP)
         '-- Sumariza Importes Pagos
         totalPagos += drP.Importe
      Next
      '-- Cheques.- -------------------------------------------------------------------------------------------------------------
      For Each drCheques In cheques.OrderBy(Function(x) x.FechaEmision)
         Dim drP As New PagosPromedios With
               {
                  .Medio = String.Format("Cheque {0}", drCheques.NumeroCheque),
                  .NumeroPago = drCheques.NumeroCheque,
                  .FechaPago = If(drCheques.FechaCobro < fechaAplicacionPago, fechaAplicacionPago.Date, drCheques.FechaCobro.Date),
                  .Importe = drCheques.Importe,
                  .ImportePago = 0,
                  .PorcentajeAfecta = 0,
                  .DiasDirectos = 0,
                  .PorcentajeDias = 0,
                  .Procesado = False,
                  .Orden = 8
               }
         lPagos.Add(drP)
         '-- Sumariza Importes Pagos
         totalPagos += drP.Importe
      Next

      If comprobantes.Where(Function(x) x.TipoComprobante.EsAnticipo = False And x.TipoComprobante.CoeficienteValores = 1 And x.TipoComprobante.Grupo = "VENTAS").OrderBy(Function(x) x.FechaEmision).Count > 0 Then
         '-- Calcula Valores para comprobantes Comprobantes.- -------------------------------------------------------------------------------------
         Dim lComprobantes As New List(Of ComprobantesPromedios)
         Dim sumTotalComprobantes = comprobantes.Where(Function(x) x.TipoComprobante.EsAnticipo = False And x.TipoComprobante.CoeficienteValores = 1 And x.TipoComprobante.Grupo = "VENTAS").Sum(Function(x) x.Paga)
         For Each drComprobante In comprobantes.Where(Function(x) x.TipoComprobante.EsAnticipo = False And x.TipoComprobante.CoeficienteValores = 1 And x.TipoComprobante.Grupo = "VENTAS").OrderBy(Function(x) x.FechaEmision)
            Dim drC As New ComprobantesPromedios With
                  {
                     .IdSucursal = drComprobante.IdSucursal,
                     .IdTipoComprobante = drComprobante.IdTipoComprobante,
                     .Letra = drComprobante.Letra,
                     .CentroEmisor = drComprobante.CentroEmisor,
                     .NumeroComprobante = drComprobante.NumeroComprobante,
                     .FechaEmision = drComprobante.FechaEmision.Date,
                     .MotonComprobante = drComprobante.Paga,
                     .PorcentajeAfecta = (.MotonComprobante / sumTotalComprobantes) * 100,
                     .DiasDirectos = DateDiff(DateInterval.Day, drComprobante.FechaEmision.Date, fechaAplicacionPago.Date),
                     .PorcentajeDias = Math.Round((drComprobante.Paga / sumTotalComprobantes) * DateDiff(DateInterval.Day, drComprobante.FechaEmision.Date, fechaAplicacionPago.Date), 0, MidpointRounding.AwayFromZero)
                  }
            lComprobantes.Add(drC)
         Next
         '--------------------------------------------------------------------------------------------------------------------------
         Dim sumaPorcentajeDias = lComprobantes.Sum(Function(x) x.PorcentajeDias)
         Dim emisionPagoPromedio = DateAdd(DateInterval.Day, (sumaPorcentajeDias * -1), fechaAplicacionPago)
         Dim totalSumPagos = If(sumTotalComprobantes >= totalPagos, totalPagos, sumTotalComprobantes)
         Dim saldoSumPagos = sumTotalComprobantes

         For Each ePagos In lPagos.OrderBy(Function(x) x.FechaPago.Date).ThenBy(Function(x) x.Orden)
            With ePagos
               .ImportePago = If(saldoSumPagos - .Importe > 0, .Importe, saldoSumPagos)
               .DiasDirectos = DateDiff(DateInterval.Day, emisionPagoPromedio.Date, .FechaPago.Date)
               .PorcentajeAfecta = (If(.ImportePago = totalPagos, 1, .ImportePago / totalSumPagos)) * 100
               .PorcentajeDias = Math.Round(((If(.ImportePago = totalPagos, 1, .ImportePago / totalSumPagos)) * .DiasDirectos), 0, MidpointRounding.AwayFromZero)
            End With
            saldoSumPagos -= ePagos.Importe
         Next

         '--------------------------------------------------------------------------------------------------------------------------
         Dim sumatoriaDiasPromedioPagos = lPagos.Sum(Function(x) x.PorcentajeDias)
         Dim emisionPagoPromedioPagos = DateAdd(DateInterval.Day, sumatoriaDiasPromedioPagos, emisionPagoPromedio)
         '--------------------------------------------------------------------------------------------------------------------------
         Dim lResultado As New List(Of ComprobantesFinalesPromedios)
         Dim resto As Decimal = 0
         Dim fechaResto As Date = Nothing

         For Each drC In lComprobantes.OrderBy(Function(x) x.FechaEmision)
            Dim eResult As New ComprobantesFinalesPromedios With
                            {
                              .NumeroComprobante = drC.NumeroComprobante,
                              .FechaEmision = drC.FechaEmision.Date,
                              .SaldoComprobante = drC.MotonComprobante,
                              .Medio = String.Empty,
                              .FechaPago = Nothing,
                              .ImporteComprobante = Nothing,
                              .DiasDirectos = drC.DiasDirectos,
                              .PorcentajeDias = Nothing
                            }
            lResultado.Add(eResult)
            Dim saldoComprobante = drC.MotonComprobante
            Dim sumPorDia As Decimal = 0
            Dim maxDiasProm As Decimal = 0
            For Each drP In lPagos.Where(Function(x) x.Procesado = False).OrderBy(Function(x) x.FechaPago.Date).ThenBy(Function(x) x.Orden)
               Dim eResPag As New ComprobantesFinalesPromedios With
                            {
                              .NumeroComprobante = drC.NumeroComprobante,
                              .FechaEmision = Nothing,
                              .SaldoComprobante = If(saldoComprobante - drP.Importe <= 0, 0, saldoComprobante - drP.Importe),
                              .Medio = drP.Medio,
                              .FechaPago = drP.FechaPago,
                              .ImporteComprobante = If(saldoComprobante - drP.Importe <= 0, saldoComprobante, drP.Importe),
                              .DiasDirectos = DateDiff(DateInterval.Day, drC.FechaEmision.Date, drP.FechaPago.Date),
                              .PorcentajeDias = Math.Round((If(saldoComprobante - drP.Importe <= 0, saldoComprobante, drP.Importe) / drC.MotonComprobante) * DateDiff(DateInterval.Day, drC.FechaEmision.Date, drP.FechaPago.Date), 0, MidpointRounding.AwayFromZero)
                            }
               lResultado.Add(eResPag)
               '-- Marca Registro Para no volver a Levantarlo.-
               drP.Procesado = True

               saldoComprobante -= drP.Importe
               sumPorDia += eResPag.PorcentajeDias.IfNull()
               maxDiasProm = If(maxDiasProm > eResPag.DiasDirectos, maxDiasProm, eResPag.DiasDirectos)
               If saldoComprobante <= 0 Then
                  resto = (saldoComprobante * -1)
                  If resto > 0 Then
                     Dim drPR As New PagosPromedios With
                        {
                           .Medio = String.Format("Saldo {0}", drP.Medio),
                           .NumeroPago = 0,
                           .FechaPago = drP.FechaPago.Date,
                           .Importe = resto,
                           .ImportePago = resto,
                           .PorcentajeAfecta = 0,
                           .DiasDirectos = DateDiff(DateInterval.Day, drC.FechaEmision.Date, drP.FechaPago.Date),
                           .PorcentajeDias = 0,
                           .Procesado = False,
                           .Orden = 99
                        }
                     lPagos.Add(drPR)
                  End If
                  Exit For
               End If
            Next
            '-- Asigna Fecha y Cantidades a Cuentas Corrientes Pagos.-
            Dim eComprobante = comprobantes.Where(Function(x) x.IdSucursal = drC.IdSucursal And x.IdTipoComprobante = drC.IdTipoComprobante And x.Letra = drC.Letra And x.CentroEmisor = drC.CentroEmisor And x.NumeroComprobante = drC.NumeroComprobante).ToList()
            With eComprobante(0)
               .FechaPromedioCobro = DateAdd(DateInterval.Day, sumPorDia, drC.FechaEmision.Date)
               .PromedioDiasCobro = sumPorDia
               .CantidadDiasCobro = maxDiasProm
            End With
         Next
         For Each drS In lPagos.Where(Function(x) x.Procesado = False).OrderBy(Function(x) x.FechaPago)
            Dim eResult As New ComprobantesFinalesPromedios With
                   {
                     .NumeroComprobante = Nothing,
                     .FechaEmision = Nothing,
                     .SaldoComprobante = 0,
                     .Medio = drS.Medio,
                     .FechaPago = drS.FechaPago.Date,
                     .ImporteComprobante = drS.ImportePago,
                     .DiasDirectos = 0,
                     .PorcentajeDias = 0
                   }
            lResultado.Add(eResult)
         Next
         '-- Carga los datos.- ----------------------------------------------------------------------------------------------------
         With PromedioPonderadoFinal
            .EmisionPromedioPagos = emisionPagoPromedio
            .FechaPromedioPagos = emisionPagoPromedioPagos
            .Comprobantes = lResultado
            If lPagos.Count > 0 Then
               .DiasPromedioPago = Math.Round(lPagos.Sum(Function(x) x.PorcentajeDias), 0, MidpointRounding.AwayFromZero)
               .DiasDirectos = Math.Round(lPagos.Max(Function(x) x.DiasDirectos), 0, MidpointRounding.AwayFromZero)
               .Pagos = lPagos.OrderBy(Function(x) x.Orden).ToList()
            End If
         End With
      Else
         If lPagos.Count > 0 Then
            With PromedioPonderadoFinal
               .DiasDirectos = DateDiff(DateInterval.Day, fechaAplicacionPago.Date, lPagos.Max(Function(x) x.FechaPago).Date)
            End With
         End If
      End If

      Return PromedioPonderadoFinal
   End Function

   Public Class ComprobantesPromedios
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroComprobante As Long
      Public Property FechaEmision As Date
      Public Property MotonComprobante As Decimal
      Public Property PorcentajeAfecta As Decimal
      Public Property DiasDirectos As Long
      Public Property PorcentajeDias As Decimal
      Public Property FechaPagoPromedioPonderado As Date
      Public Property DiasPagoPromedioPonderado As Decimal
   End Class

   Public Class PagosPromedios
      Public Property Medio As String
      Public Property NumeroPago As Integer
      Public Property FechaPago As Date
      Public Property Importe As Decimal
      Public Property ImportePago As Decimal
      Public Property PorcentajeAfecta As Decimal
      Public Property DiasDirectos As Long
      Public Property PorcentajeDias As Decimal
      Public Property Procesado As Boolean
      Public Property Orden As Integer
   End Class

   Public Class ComprobantesFinalesPromedios
      Public Property NumeroComprobante As Long?
      Public Property FechaEmision As Date?
      Public Property SaldoComprobante As Decimal
      Public Property Medio As String
      Public Property FechaPago As Date?
      Public Property ImporteComprobante As Decimal?
      Public Property DiasDirectos As Long
      Public Property PorcentajeDias As Decimal?
   End Class

   Public Class PagosPromediosResult
      Public Property Comprobantes As List(Of ComprobantesFinalesPromedios)
      Public Property Pagos As List(Of PagosPromedios)

      Public Property EmisionPromedioPagos As Date
      Public Property FechaPromedioPagos As Date
      Public Property DiasPromedioPago As Decimal
      Public Property DiasDirectos As Decimal

   End Class

End Class
