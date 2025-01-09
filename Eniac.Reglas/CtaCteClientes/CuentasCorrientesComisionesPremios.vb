
Imports System.Security.Cryptography
Imports Eniac.Reglas.WSFEv1
Imports Eniac.SqlServer

Public Class CuentasCorrientesComisionesPremios
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      da = accesoDatos
   End Sub
#End Region


   Public Function CalculoComisionesPremiosCobranzas(sucursales As Entidades.Sucursal(),
                                                     idTipoComprobante As String,
                                                     desde As Date,
                                                     hasta As Date,
                                                     grabaLibro As Entidades.Publicos.SiNoTodos,
                                                     afectaCaja As Entidades.Publicos.SiNoTodos,
                                                     idCliente As Long,
                                                     porVendedor As Boolean,
                                                     idLocalidad As Integer,
                                                     idProvincia As String,
                                                     conIva As Boolean, diasCobro As Integer) As List(Of ComisionesPremiosCobranzas)

      Dim lPremiosCobranzas As New List(Of ComisionesPremiosCobranzas)
      Dim sql = New SqlServer.CuentasCorrientesComisionesPremios(da)

      '-- Carga Comisiones Por Venta.- --------------------------------------------------------------------------------------------------------
      Dim dtVentas = sql.GetComisionesPorVentas(sucursales, idTipoComprobante, desde, hasta, grabaLibro, afectaCaja, idCliente, idLocalidad, idProvincia, conIva, porVendedor)
      For Each dr As DataRow In dtVentas.Rows
         Dim drPC = New ComisionesPremiosCobranzas
         With drPC
            .IdEmpleado = dr.Field(Of Integer)("IdVendedor")
            .NombreEmpleado = dr.Field(Of String)("NombreEmpleado")
            .IdSucursal = dr.Field(Of Integer)("IdSucursal")
            .IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
            .Letra = dr.Field(Of String)("Letra")
            .CentroEmisor = dr.Field(Of Integer)("CentroEmisor")
            .NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
            .FechaEmision = dr.Field(Of Date)("Fecha")
            .IdCliente = dr.Field(Of Long)("IdCliente")
            .NombreCliente = dr.Field(Of String)("NombreCliente")
            .ImporteBruto = dr.Field(Of Decimal)("ImporteBruto")
            .PorcentajeComision = ((dr.Field(Of Decimal)("ComisionVendedor") * 100) / dr.Field(Of Decimal)("ImporteBruto"))
            .ImporteComision = dr.Field(Of Decimal)("ComisionVendedor")
         End With
         lPremiosCobranzas.Add(drPC)
      Next

      '-- Carga Comisiones Por Cobranzas.- ----------------------------------------------------------------------------------------------------
      Dim dtCobranza = sql.GetComisionesPorCobranzas(sucursales, idTipoComprobante, desde, hasta, grabaLibro, afectaCaja, idCliente, porVendedor, idLocalidad, idProvincia, conIva)
      If dtCobranza IsNot Nothing Then

         For Each drC As DataRow In dtCobranza.Rows
            '-- Comprobantes.- -----------------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim lCuentasCorrientesPagos = New List(Of Entidades.CuentaCorrientePago)
            Dim dtCobPagos = sql.GetComisionesPorCobranzasPagos(drC.Field(Of Integer)("IdSucursal"),
                                                                drC.Field(Of String)("IdTipoComprobante"),
                                                                drC.Field(Of String)("Letra"),
                                                                drC.Field(Of Integer)("CentroEmisor"),
                                                                drC.Field(Of Long)("NumeroComprobante"),
                                                                porVendedor)
            '-- Calcula Comisiones.- -----------------------------------------------------------------------------------------------------------------------------------------------------------
            Dim impPesos = drC.Field(Of Decimal)("ImportePesos")
            Dim impDolar = drC.Field(Of Decimal)("ImporteDolares") * drC.Field(Of Decimal)("CotizacionDolar")
            Dim impReten = drC.Field(Of Decimal)("ImporteRetenciones")
            Dim impTrans = drC.Field(Of Decimal)("ImporteTransfBancaria")
            Dim impChequ = drC.Field(Of Decimal)("ImporteCheques")
            Dim impTarje = drC.Field(Of Decimal)("ImporteTarjetas")

            For Each rCtaCteP As DataRow In dtCobPagos.Rows
               Dim impPaga = rCtaCteP.Field(Of Decimal)("ImportePaga")
               '-- Pesos.- -------------------------------------
               If impPesos > 0 Then
                  Dim drPCP = New ComisionesPremiosCobranzas
                  With drPCP
                     '-- Datos Recibo.- --------------------------------------------------------------
                     .IdEmpleado = drC.Field(Of Integer)("IdVendedor")
                     .NombreEmpleado = drC.Field(Of String)("NombreEmpleado")
                     .IdSucursal = drC.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobante = drC.Field(Of String)("IdTipoComprobante")
                     .Letra = drC.Field(Of String)("Letra")
                     .CentroEmisor = drC.Field(Of Integer)("CentroEmisor")
                     .NumeroComprobante = drC.Field(Of Long)("NumeroComprobante")
                     .FechaEmision = drC.Field(Of Date)("Fecha")
                     '-- Datos Comprobante.- ---------------------------------------------------------
                     .IdSucursalVinc = rCtaCteP.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobanteVinc = rCtaCteP.Field(Of String)("IdTipoComprobante2")
                     .LetraVinc = rCtaCteP.Field(Of String)("Letra2")
                     .CentroEmisorVinc = rCtaCteP.Field(Of Integer)("CentroEmisor2")
                     .NumeroComprobanteVinc = rCtaCteP.Field(Of Long)("NumeroComprobante2")
                     .FechaEmisionVinc = rCtaCteP.Field(Of Date)("Fecha2")
                     '-- Cliente.- --------------------------------------------------------------------
                     .IdCliente = drC.Field(Of Long)("IdCliente")
                     .NombreCliente = drC.Field(Of String)("NombreCliente")

                     .FormaPago = "Efectivo $"

                     If conIva Then
                        .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga")
                     Else
                        .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga") / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                     End If

                     If impPaga <= impPesos Then
                        If conIva Then
                           .NetoCobro = impPaga
                        Else
                           .NetoCobro = impPaga / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impPesos -= impPaga
                     Else
                        If conIva Then
                           .NetoCobro = impPesos
                        Else
                           .NetoCobro = impPesos / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impPaga -= impPesos
                        impPesos = 0
                     End If
                     .FechaCobro = drC.Field(Of Date)("Fecha")
                     .DiaCobro = DateDiff(DateInterval.Day, rCtaCteP.Field(Of Date)("Fecha2"), drC.Field(Of Date)("Fecha"))

                     .PorcentajeComision = ((rCtaCteP.Field(Of Decimal)("ComisionVendedor") * 100) / rCtaCteP.Field(Of Decimal)("ImporteBruto"))
                     .ImporteComision = (.NetoCobro.IfNull * .PorcentajeComision) / 100

                     If drC.Field(Of Boolean)("CobraPremioCobranza") And .DiaCobro <= diasCobro Then
                        .PorcentajePremio = .PorcentajeComision
                        .ImportePremio = .ImporteComision
                     End If
                     lPremiosCobranzas.Add(drPCP)
                     If impPesos > 0 Then
                        Continue For
                     End If
                  End With
               End If
               '-- Dolares.- -----------------------------------
               If impDolar > 0 Then
                  Dim drPCD = New ComisionesPremiosCobranzas
                  With drPCD
                     '-- Datos Recibo.- --------------------------------------------------------------
                     .IdEmpleado = drC.Field(Of Integer)("IdVendedor")
                     .NombreEmpleado = drC.Field(Of String)("NombreEmpleado")
                     .IdSucursal = drC.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobante = drC.Field(Of String)("IdTipoComprobante")
                     .Letra = drC.Field(Of String)("Letra")
                     .CentroEmisor = drC.Field(Of Integer)("CentroEmisor")
                     .NumeroComprobante = drC.Field(Of Long)("NumeroComprobante")
                     .FechaEmision = drC.Field(Of Date)("Fecha")
                     '-- Datos Comprobante.- ---------------------------------------------------------
                     .IdSucursalVinc = rCtaCteP.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobanteVinc = rCtaCteP.Field(Of String)("IdTipoComprobante2")
                     .LetraVinc = rCtaCteP.Field(Of String)("Letra2")
                     .CentroEmisorVinc = rCtaCteP.Field(Of Integer)("CentroEmisor2")
                     .NumeroComprobanteVinc = rCtaCteP.Field(Of Long)("NumeroComprobante2")
                     .FechaEmisionVinc = rCtaCteP.Field(Of Date)("Fecha2")
                     '-- Cliente.- --------------------------------------------------------------------
                     .IdCliente = drC.Field(Of Long)("IdCliente")
                     .NombreCliente = drC.Field(Of String)("NombreCliente")

                     .FormaPago = "Efectivo U$s (Pesificados)"

                     If conIva Then
                        .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga")
                     Else
                        .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga") / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                     End If

                     If impPaga <= impDolar Then
                        If conIva Then
                           .NetoCobro = impPaga
                        Else
                           .NetoCobro = impPaga / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impDolar -= impPaga
                     Else
                        If conIva Then
                           .NetoCobro = impDolar
                        Else
                           .NetoCobro = impDolar / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impPaga -= impDolar
                        impDolar = 0
                     End If

                     .FechaCobro = drC.Field(Of Date)("Fecha")
                     .DiaCobro = DateDiff(DateInterval.Day, drC.Field(Of Date)("Fecha"), rCtaCteP.Field(Of Date)("Fecha2"))

                     .PorcentajeComision = ((rCtaCteP.Field(Of Decimal)("ComisionVendedor") * 100) / rCtaCteP.Field(Of Decimal)("ImporteBruto"))
                     .ImporteComision = (.NetoCobro.IfNull * .PorcentajeComision) / 100

                     If drC.Field(Of Boolean)("CobraPremioCobranza") And .DiaCobro <= diasCobro Then
                        .PorcentajePremio = .PorcentajeComision
                        .ImportePremio = .ImporteComision
                     End If
                     lPremiosCobranzas.Add(drPCD)
                     If impDolar > 0 Then
                        Continue For
                     End If
                  End With
               End If
               '-- Retenciones.- -------------------------------
               If impReten > 0 Then
                  Dim drPCR = New ComisionesPremiosCobranzas
                  With drPCR
                     '-- Datos Recibo.- --------------------------------------------------------------
                     .IdEmpleado = drC.Field(Of Integer)("IdVendedor")
                     .NombreEmpleado = drC.Field(Of String)("NombreEmpleado")
                     .IdSucursal = drC.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobante = drC.Field(Of String)("IdTipoComprobante")
                     .Letra = drC.Field(Of String)("Letra")
                     .CentroEmisor = drC.Field(Of Integer)("CentroEmisor")
                     .NumeroComprobante = drC.Field(Of Long)("NumeroComprobante")
                     .FechaEmision = drC.Field(Of Date)("Fecha")
                     '-- Datos Comprobante.- ---------------------------------------------------------
                     .IdSucursalVinc = rCtaCteP.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobanteVinc = rCtaCteP.Field(Of String)("IdTipoComprobante2")
                     .LetraVinc = rCtaCteP.Field(Of String)("Letra2")
                     .CentroEmisorVinc = rCtaCteP.Field(Of Integer)("CentroEmisor2")
                     .NumeroComprobanteVinc = rCtaCteP.Field(Of Long)("NumeroComprobante2")
                     .FechaEmisionVinc = rCtaCteP.Field(Of Date)("Fecha2")
                     '-- Cliente.- --------------------------------------------------------------------
                     .IdCliente = drC.Field(Of Long)("IdCliente")
                     .NombreCliente = drC.Field(Of String)("NombreCliente")

                     .FormaPago = "Retenciones"

                     If conIva Then
                        .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga")
                     Else
                        .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga") / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                     End If

                     If impPaga <= impReten Then
                        If conIva Then
                           .NetoCobro = impPaga
                        Else
                           .NetoCobro = impPaga / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impReten -= impPaga
                     Else
                        If conIva Then
                           .NetoCobro = impReten
                        Else
                           .NetoCobro = impReten / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impPaga -= impReten
                        impReten = 0
                     End If
                     .FechaCobro = drC.Field(Of Date)("Fecha")
                     .DiaCobro = DateDiff(DateInterval.Day, drC.Field(Of Date)("Fecha"), rCtaCteP.Field(Of Date)("Fecha2"))

                     .PorcentajeComision = ((rCtaCteP.Field(Of Decimal)("ComisionVendedor") * 100) / rCtaCteP.Field(Of Decimal)("ImporteBruto"))
                     .ImporteComision = (.NetoCobro.IfNull * .PorcentajeComision) / 100

                     If drC.Field(Of Boolean)("CobraPremioCobranza") And .DiaCobro <= diasCobro Then
                        .PorcentajePremio = .PorcentajeComision
                        .ImportePremio = .ImporteComision
                     End If
                     lPremiosCobranzas.Add(drPCR)
                     If impReten > 0 Then
                        Continue For
                     End If
                  End With
               End If
               '-- Transferencias Bancarias.- ------------------
               If impTrans > 0 Then
                  Dim drPCT = New ComisionesPremiosCobranzas
                  With drPCT
                     .IdEmpleado = drC.Field(Of Integer)("IdVendedor")
                     .NombreEmpleado = drC.Field(Of String)("NombreEmpleado")
                     .IdSucursal = drC.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobante = drC.Field(Of String)("IdTipoComprobante")
                     .Letra = drC.Field(Of String)("Letra")
                     .CentroEmisor = drC.Field(Of Integer)("CentroEmisor")
                     .NumeroComprobante = drC.Field(Of Long)("NumeroComprobante")
                     .FechaEmision = drC.Field(Of Date)("Fecha")

                     .IdSucursalVinc = rCtaCteP.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobanteVinc = rCtaCteP.Field(Of String)("IdTipoComprobante2")
                     .LetraVinc = rCtaCteP.Field(Of String)("Letra2")
                     .CentroEmisorVinc = rCtaCteP.Field(Of Integer)("CentroEmisor2")
                     .NumeroComprobanteVinc = rCtaCteP.Field(Of Long)("NumeroComprobante2")
                     .FechaEmisionVinc = rCtaCteP.Field(Of Date)("Fecha2")

                     .IdCliente = drC.Field(Of Long)("IdCliente")
                     .NombreCliente = drC.Field(Of String)("NombreCliente")

                     .FormaPago = "Transferencias"
                     If impPaga <= impTrans Then
                        If conIva Then
                           .ImporteBruto = impPaga
                        Else
                           .ImporteBruto = impPaga / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impTrans -= impPaga
                     Else
                        If conIva Then
                           .ImporteBruto = impTrans
                        Else
                           .ImporteBruto = impTrans / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impPaga -= impTrans
                        impTrans = 0
                     End If
                     .FechaCobro = drC.Field(Of Date)("Fecha")
                     .DiaCobro = DateDiff(DateInterval.Day, rCtaCteP.Field(Of Date)("Fecha2"), drC.Field(Of Date)("Fecha"))
                     If conIva Then
                        .NetoCobro = .ImporteBruto
                     Else
                        .NetoCobro = .ImporteBruto
                     End If

                     .PorcentajeComision = ((rCtaCteP.Field(Of Decimal)("ComisionVendedor") * 100) / rCtaCteP.Field(Of Decimal)("ImporteBruto"))
                     .ImporteComision = (.NetoCobro.IfNull * .PorcentajeComision) / 100

                     If drC.Field(Of Boolean)("CobraPremioCobranza") And .DiaCobro <= diasCobro Then
                        .PorcentajePremio = .PorcentajeComision
                        .ImportePremio = .ImporteComision
                     End If
                     lPremiosCobranzas.Add(drPCT)
                     If impTrans > 0 Then
                        Continue For
                     End If
                  End With
               End If
               '-- Tarjetas.- ------------------
               If impTarje > 0 Then
                  Dim drPCT = New ComisionesPremiosCobranzas
                  With drPCT
                     .IdEmpleado = drC.Field(Of Integer)("IdVendedor")
                     .NombreEmpleado = drC.Field(Of String)("NombreEmpleado")
                     .IdSucursal = drC.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobante = drC.Field(Of String)("IdTipoComprobante")
                     .Letra = drC.Field(Of String)("Letra")
                     .CentroEmisor = drC.Field(Of Integer)("CentroEmisor")
                     .NumeroComprobante = drC.Field(Of Long)("NumeroComprobante")
                     .FechaEmision = drC.Field(Of Date)("Fecha")

                     .IdSucursalVinc = rCtaCteP.Field(Of Integer)("IdSucursal")
                     .IdTipoComprobanteVinc = rCtaCteP.Field(Of String)("IdTipoComprobante2")
                     .LetraVinc = rCtaCteP.Field(Of String)("Letra2")
                     .CentroEmisorVinc = rCtaCteP.Field(Of Integer)("CentroEmisor2")
                     .NumeroComprobanteVinc = rCtaCteP.Field(Of Long)("NumeroComprobante2")
                     .FechaEmisionVinc = rCtaCteP.Field(Of Date)("Fecha2")

                     .IdCliente = drC.Field(Of Long)("IdCliente")
                     .NombreCliente = drC.Field(Of String)("NombreCliente")

                     .FormaPago = "Tarjetas"
                     If impPaga <= impTarje Then
                        If conIva Then
                           .ImporteBruto = impPaga
                        Else
                           .ImporteBruto = impPaga / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impTarje -= impPaga
                     Else
                        If conIva Then
                           .ImporteBruto = impTarje
                        Else
                           .ImporteBruto = impTrans / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If
                        impPaga -= impTarje
                        impTarje = 0
                     End If
                     .FechaCobro = drC.Field(Of Date)("Fecha")
                     .DiaCobro = DateDiff(DateInterval.Day, drC.Field(Of Date)("Fecha"), rCtaCteP.Field(Of Date)("Fecha2"))
                     If conIva Then
                        .NetoCobro = .ImporteBruto
                     Else
                        .NetoCobro = .ImporteBruto
                     End If

                     .PorcentajeComision = ((rCtaCteP.Field(Of Decimal)("ComisionVendedor") * 100) / rCtaCteP.Field(Of Decimal)("ImporteBruto"))
                     .ImporteComision = (.NetoCobro.IfNull * .PorcentajeComision) / 100

                     If drC.Field(Of Boolean)("CobraPremioCobranza") And .DiaCobro <= diasCobro Then
                        .PorcentajePremio = .PorcentajeComision
                        .ImportePremio = .ImporteComision
                     End If
                     lPremiosCobranzas.Add(drPCT)
                     If impTarje > 0 Then
                        Continue For
                     End If
                  End With
               End If
               '-- Cheques.- ----------------------
               If impChequ > 0 Then
                  Dim dtC = New SqlServer.CuentasCorrientesCheques(da).RecuperaCantidadDiasCobro(drC.Field(Of Integer)("IdSucursal"),
                                                                                                 drC.Field(Of String)("IdTipoComprobante"),
                                                                                                 drC.Field(Of String)("Letra"),
                                                                                                 drC.Field(Of Integer)("CentroEmisor"),
                                                                                                 drC.Field(Of Long)("NumeroComprobante"))
                  For Each drCC As DataRow In dtC.Rows
                     Dim drPCC = New ComisionesPremiosCobranzas
                     With drPCC
                        '-- Datos Recibo.- --------------------------------------------------------------
                        .IdEmpleado = drC.Field(Of Integer)("IdVendedor")
                        .NombreEmpleado = drC.Field(Of String)("NombreEmpleado")
                        .IdSucursal = drC.Field(Of Integer)("IdSucursal")
                        .IdTipoComprobante = drC.Field(Of String)("IdTipoComprobante")
                        .Letra = drC.Field(Of String)("Letra")
                        .CentroEmisor = drC.Field(Of Integer)("CentroEmisor")
                        .NumeroComprobante = drC.Field(Of Long)("NumeroComprobante")
                        .FechaEmision = drC.Field(Of Date)("Fecha")
                        '-- Datos Comprobante.- ---------------------------------------------------------
                        .IdSucursalVinc = rCtaCteP.Field(Of Integer)("IdSucursal")
                        .IdTipoComprobanteVinc = rCtaCteP.Field(Of String)("IdTipoComprobante2")
                        .LetraVinc = rCtaCteP.Field(Of String)("Letra2")
                        .CentroEmisorVinc = rCtaCteP.Field(Of Integer)("CentroEmisor2")
                        .NumeroComprobanteVinc = rCtaCteP.Field(Of Long)("NumeroComprobante2")
                        .FechaEmisionVinc = rCtaCteP.Field(Of Date)("Fecha2")
                        '-- Cliente.- --------------------------------------------------------------------
                        .IdCliente = drC.Field(Of Long)("IdCliente")
                        .NombreCliente = drC.Field(Of String)("NombreCliente")

                        .FormaPago = String.Format("Cheque Nro. {0}", drCC.Field(Of Integer)("NumeroCheque"))

                        If conIva Then
                           .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga")
                        Else
                           .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga") / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If

                        If impPaga <= drCC.Field(Of Decimal)("Importe") Then
                           If conIva Then
                              .NetoCobro = impPaga
                           Else
                              .NetoCobro = impPaga / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                           End If
                           impChequ -= impPaga
                        Else
                           If conIva Then
                              .NetoCobro = drCC.Field(Of Decimal)("Importe")
                           Else
                              .NetoCobro = drCC.Field(Of Decimal)("Importe") / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                           End If
                           impPaga -= drCC.Field(Of Decimal)("Importe")
                           impChequ -= drCC.Field(Of Decimal)("Importe")
                        End If
                        .FechaCobro = drCC.Field(Of Date)("FechaCobro")
                        .DiaCobro = DateDiff(DateInterval.Day, rCtaCteP.Field(Of Date)("Fecha2"), drCC.Field(Of Date)("FechaCobro"))

                        .PorcentajeComision = ((rCtaCteP.Field(Of Decimal)("ComisionVendedor") * 100) / rCtaCteP.Field(Of Decimal)("ImporteBruto"))
                        .ImporteComision = (.NetoCobro.IfNull * .PorcentajeComision) / 100

                        If drC.Field(Of Boolean)("CobraPremioCobranza") And .DiaCobro <= diasCobro Then
                           .PorcentajePremio = .PorcentajeComision
                           .ImportePremio = .ImporteComision
                        End If
                        lPremiosCobranzas.Add(drPCC)
                        If impChequ > 0 Then
                           Continue For
                        End If
                     End With
                  Next
                  If impChequ > 0 Then
                     Continue For
                  End If
               End If
               '-- Anticipos.- ----------------------
               Dim dtA = New SqlServer.CuentasCorrientesPagos(da).RecuperaAnticiposPremios(drC.Field(Of Integer)("IdSucursal"),
                                                                                           drC.Field(Of String)("IdTipoComprobante"),
                                                                                           drC.Field(Of String)("Letra"),
                                                                                           drC.Field(Of Integer)("CentroEmisor"),
                                                                                           drC.Field(Of Long)("NumeroComprobante"))
               If dtA.Rows.Count > 0 Then
                  Dim impAnti As Decimal = Decimal.Parse(dtA.Compute("SUM(ImporteCuota)", Nothing).ToString())
                  For Each drCA As DataRow In dtA.Rows
                     Dim drPCA = New ComisionesPremiosCobranzas
                     With drPCA
                        '-- Datos Recibo.- --------------------------------------------------------------
                        .IdEmpleado = drC.Field(Of Integer)("IdVendedor")
                        .NombreEmpleado = drC.Field(Of String)("NombreEmpleado")
                        .IdSucursal = drC.Field(Of Integer)("IdSucursal")
                        .IdTipoComprobante = drC.Field(Of String)("IdTipoComprobante")
                        .Letra = drC.Field(Of String)("Letra")
                        .CentroEmisor = drC.Field(Of Integer)("CentroEmisor")
                        .NumeroComprobante = drC.Field(Of Long)("NumeroComprobante")
                        .FechaEmision = drC.Field(Of Date)("Fecha")
                        '-- Datos Comprobante.- ---------------------------------------------------------
                        .IdSucursalVinc = rCtaCteP.Field(Of Integer)("IdSucursal")
                        .IdTipoComprobanteVinc = rCtaCteP.Field(Of String)("IdTipoComprobante2")
                        .LetraVinc = rCtaCteP.Field(Of String)("Letra2")
                        .CentroEmisorVinc = rCtaCteP.Field(Of Integer)("CentroEmisor2")
                        .NumeroComprobanteVinc = rCtaCteP.Field(Of Long)("NumeroComprobante2")
                        .FechaEmisionVinc = rCtaCteP.Field(Of Date)("Fecha2")
                        '-- Cliente.- --------------------------------------------------------------------
                        .IdCliente = drC.Field(Of Long)("IdCliente")
                        .NombreCliente = drC.Field(Of String)("NombreCliente")

                        .FormaPago = String.Format("Anticipo Nro. {0}", drCA.Field(Of Long)("NumeroComprobante2"))

                        If conIva Then
                           .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga")
                        Else
                           .ImporteBruto = rCtaCteP.Field(Of Decimal)("ImportePaga") / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                        End If

                        If impPaga <= drCA.Field(Of Decimal)("ImporteCuota") Then
                           If conIva Then
                              .NetoCobro = impPaga
                           Else
                              .NetoCobro = impPaga / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                           End If
                           impAnti -= impPaga
                        Else
                           If conIva Then
                              .NetoCobro = drCA.Field(Of Decimal)("ImporteCuota")
                           Else
                              .NetoCobro = drCA.Field(Of Decimal)("ImporteCuota") / (1 + (drC.Field(Of Decimal)("AlicuotaImpuesto") / 100))
                           End If
                           impPaga -= drCA.Field(Of Decimal)("ImporteCuota")
                           impAnti -= drCA.Field(Of Decimal)("ImporteCuota")
                        End If
                        .FechaCobro = drCA.Field(Of Date)("Fecha")
                        .DiaCobro = DateDiff(DateInterval.Day, rCtaCteP.Field(Of Date)("Fecha2"), drCA.Field(Of Date)("Fecha"))

                        .PorcentajeComision = ((rCtaCteP.Field(Of Decimal)("ComisionVendedor") * 100) / rCtaCteP.Field(Of Decimal)("ImporteBruto"))
                        .ImporteComision = (.NetoCobro.IfNull * .PorcentajeComision) / 100

                        If drC.Field(Of Boolean)("CobraPremioCobranza") And .DiaCobro <= diasCobro Then
                           .PorcentajePremio = .PorcentajeComision
                           .ImportePremio = .ImporteComision
                        End If
                        lPremiosCobranzas.Add(drPCA)
                        If impAnti > 0 Then
                           Continue For
                        End If
                     End With
                  Next
                  If impAnti > 0 Then
                     Continue For
                  End If
               End If
            Next
         Next

      End If
      '----------------------------------------------------------------------------------------------------------------------------------------
      Return lPremiosCobranzas
   End Function

   Public Class ComisionesPremiosCobranzas
      Public Property IdEmpleado As Integer
      Public Property NombreEmpleado As String
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroComprobante As Long
      Public Property FechaEmision As Date
      Public Property FormaPago As String
      Public Property IdSucursalVinc As Integer?
      Public Property IdTipoComprobanteVinc As String
      Public Property LetraVinc As String
      Public Property CentroEmisorVinc As Integer?
      Public Property NumeroComprobanteVinc As Long?
      Public Property FechaEmisionVinc As Date?

      Public Property IdCliente As Long
      Public Property NombreCliente As String
      Public Property ImporteBruto As Decimal

      Public Property FechaCobro As Date?
      Public Property DiaCobro As Decimal?
      Public Property NetoCobro As Decimal?

      Public Property PorcentajeComision As Decimal
      Public Property ImporteComision As Decimal

      Public Property PorcentajePremio As Decimal?
      Public Property ImportePremio As Decimal?

   End Class
End Class