Public Class Compras
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Compras_I(idSucursal As Integer,
                        idTipoComprobante As String,
                        letra As String,
                        centroEmisor As Integer,
                        numeroComprobante As Long,
                        fecha As Date,
                        IdComprador As Integer,
                        descuentoRecargo As Double,
                        descuentoRecargoPorc As Double,
                        importeTotal As Double,
                        idProveedor As Long,
                        idCategoriaFiscal As Integer,
                        idFormasPago As Integer,
                        observacion As String,
                        porcentajeIVA As Double,
                        idRubro As Integer,
                        percepcionIVA As Decimal,
                        percepcionIB As Decimal,
                        percepcionGanancias As Decimal,
                        percepcionVarias As Decimal,
                        idEmpresa As Integer,
                        periodoFiscal As Integer,
                        importePesos As Decimal,
                        importeTarjetas As Decimal,
                        importeCheques As Decimal,
                        importeTransfBancaria As Decimal,
                        idCuentaBancaria As Integer,
                        idEstadoComprobante As String,
                        cantidadInvocados As Integer,
                        usuario As String,
                        fechaActualizacion As Date,
                        cotizacionDolar As Decimal,
                        fechaOficializacionDespacho As Date?,
                        idAduana As Integer,
                        idDestinacion As String,
                        numeroDespacho As Long,
                        digitoVerificadorDespacho As String,
                        idDespachante As Integer,
                        idAgenteTransporte As Integer,
                        derechoAduanero As Decimal,
                        bienCapitalDespacho As Boolean,
                        numeroManifiestoDespacho As String,
                        bultos As Integer,
                        valorDeclarado As Decimal,
                        idTransportista As Long,
                        numeroLote As Long,
                        iVAModificadoManual As Boolean,
                        totalBruto As Decimal,
                        totalNeto As Decimal,
                        totalIVA As Decimal,
                        totalPercepciones As Decimal,
                        metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                        idFuncion As String,
                        nombreProveedor As String,
                        cuitProveedor As String,
                        impuestosInternos As Decimal,
                        excluirDePasaje As Boolean,
                        mercEnviada As Boolean,
                        idConceptoCM05 As Integer?,
                        NumeroOrdenCompra As Long?)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO Compras ")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdTipoComprobante")
         .AppendLine("           ,Letra")
         .AppendLine("           ,CentroEmisor")
         .AppendLine("           ,NumeroComprobante")
         .AppendLine("           ,Fecha")
         .AppendLine("           ,IdComprador")
         .AppendLine("           ,DescuentoRecargo")
         .AppendLine("           ,DescuentoRecargoPorc")
         .AppendLine("           ,IVAModificadoManual")
         .AppendLine("           ,ImporteTotal")
         .AppendLine("           ,IdProveedor")
         .AppendLine("           ,IdCategoriaFiscal")
         .AppendLine("           ,IdFormasPago")
         .AppendLine("           ,Observacion")
         .AppendLine("           ,PorcentajeIVA")
         .AppendLine("           ,IdRubro")
         .AppendLine("           ,PercepcionIVA")
         .AppendLine("           ,PercepcionIB")
         .AppendLine("           ,PercepcionGanancias")
         .AppendLine("           ,PercepcionVarias")
         .AppendLine("           ,IdEmpresa")
         .AppendLine("           ,PeriodoFiscal")
         .AppendLine("           ,ImportePesos")
         .AppendLine("           ,ImporteTarjetas")
         .AppendLine("           ,ImporteCheques")
         .AppendLine("           ,importeTransfBancaria")
         .AppendLine("           ,idCuentaBancaria")
         .AppendLine("           ,idEstadoComprobante")
         .AppendLine("           ,CantidadInvocados")
         .AppendLine("           ,Usuario")
         .AppendLine("       ,FechaActualizacion")
         .AppendLine("       ,CotizacionDolar")
         .AppendLine("           ,FechaOficializacionDespacho")
         .AppendLine("           ,IdAduana")
         .AppendLine("           ,IdDestinacion")
         .AppendLine("           ,NumeroDespacho")
         .AppendLine("           ,DigitoVerificadorDespacho")
         .AppendLine("           ,IdDespachante")
         .AppendLine("           ,IdAgenteTransporte")
         .AppendLine("           ,DerechoAduanero")
         .AppendLine("           ,BienCapitalDespacho")
         .AppendLine("           ,NumeroManifiestoDespacho")
         .AppendLine("           ,Bultos")
         .AppendLine("           ,ValorDeclarado")
         .AppendLine("           ,IdTransportista")
         .AppendLine("           ,NumeroLote")
         .AppendLine("           ,TotalBruto")
         .AppendLine("           ,TotalNeto")
         .AppendLine("           ,TotalIVA")
         .AppendLine("           ,TotalPercepciones")
         .AppendLine("       ,MetodoGrabacion")
         .AppendLine("       ,IdFuncion")
         .AppendLine("       ,NombreProveedor")
         .AppendLine("       ,CuitProveedor")
         .AppendLine("       ,ImpuestosInternos")
         .AppendLine("       ,ExcluirDePasaje")
         .AppendLine("       ,MercEnviada")
         .AppendLine("       ,IdConceptoCM05")
         .AppendLine("       ,NumeroOrdenCompra")
         .AppendLine(") VALUES ")
         .AppendLine(" ( " & idSucursal & "")
         .AppendLine(" , '" & idTipoComprobante & "'")
         .AppendLine(" , '" & letra & "'")
         .AppendLine(" , " & centroEmisor)
         .AppendLine(" , " & numeroComprobante)
         .AppendLine(" , '" & Me.ObtenerFecha(fecha, True) & "'")
         If IdComprador > 0 Then
            .AppendLine(" , " & IdComprador)
         Else
            .AppendLine(" , null ")
         End If
         .AppendLine(" , " & descuentoRecargo.ToString())
         .AppendLine(" , " & descuentoRecargoPorc.ToString())
         .AppendFormat(" , {0}", GetStringFromBoolean(iVAModificadoManual)).AppendLine()
         .AppendLine(" , " & importeTotal.ToString())
         .AppendLine(" , " & idProveedor.ToString())
         If idCategoriaFiscal = 0 Then
            .AppendLine(", null ")
         Else
            .AppendLine(", " & idCategoriaFiscal)
         End If
         .AppendLine(" , " & idFormasPago & "")
         .AppendLine(" , '" & observacion & "'")
         .AppendLine(" , " & porcentajeIVA & "")
         If idRubro = 0 Then
            .AppendLine(", null ")
         Else
            .AppendLine(", " & idRubro)
         End If
         .AppendFormat(" , {0}", percepcionIVA)
         .AppendFormat(" , {0}", percepcionIB)
         .AppendFormat(" , {0}", percepcionGanancias)
         .AppendFormat(" , {0}", percepcionVarias)

         If periodoFiscal = 0 Then
            .AppendLine(" , null ")
            .AppendLine(" , null ")
         Else
            .AppendLine(" , " & idEmpresa.ToString())
            .AppendLine(" , " & periodoFiscal.ToString())
         End If
         .AppendFormat("           ,{0}", importePesos)
         .AppendFormat("           ,{0}", importeTarjetas)
         .AppendFormat("           ,{0}", importeCheques)
         .AppendFormat("           ,{0}", importeTransfBancaria)
         If idCuentaBancaria > 0 Then
            .AppendFormat("           ,{0}", idCuentaBancaria)
         Else
            .AppendLine("           ,NULL")
         End If
         If String.IsNullOrEmpty(idEstadoComprobante) Then
            .AppendLine(" , null ")
         Else
            .AppendLine(" , '" & idEstadoComprobante & "'")
         End If
         .AppendFormat("           ,{0}", cantidadInvocados)
         .AppendFormat("           ,'{0}'", usuario)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaActualizacion, True))
         .AppendFormat("           ,{0}", cotizacionDolar)

         If fechaOficializacionDespacho.HasValue Then
            .AppendFormat("           ,'{0}'", ObtenerFecha(fechaOficializacionDespacho.Value, False))
         Else
            .AppendFormat("           ,NULL")
         End If
         If idAduana <> 0 Then
            .AppendFormat("           ,{0}", idAduana)
         Else
            .AppendFormat("           ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(idDestinacion) Then
            .AppendFormat("           ,'{0}'", idDestinacion)
         Else
            .AppendFormat("           ,NULL")
         End If
         If numeroDespacho <> 0 Then
            .AppendFormat("           ,{0}", numeroDespacho)
         Else
            .AppendFormat("           ,NULL")
         End If
         If Not String.IsNullOrWhiteSpace(digitoVerificadorDespacho) Then
            .AppendFormat("           ,'{0}'", digitoVerificadorDespacho)
         Else
            .AppendFormat("           ,NULL")
         End If
         If idDespachante <> 0 Then
            .AppendFormat("           ,{0}", idDespachante)
         Else
            .AppendFormat("           ,NULL")
         End If
         If idAgenteTransporte <> 0 Then
            .AppendFormat("           ,{0}", idAgenteTransporte)
         Else
            .AppendFormat("           ,NULL")
         End If
         If derechoAduanero <> 0 Then
            .AppendFormat("           ,{0}", derechoAduanero)
         Else
            .AppendFormat("           ,NULL")
         End If
         .AppendFormat("           ,{0}", GetStringFromBoolean(bienCapitalDespacho))
         If Not String.IsNullOrWhiteSpace(numeroManifiestoDespacho) Then
            .AppendFormat("           ,'{0}'", numeroManifiestoDespacho)
         Else
            .AppendFormat("           ,NULL")
         End If

         .AppendFormat("           ,{0}", bultos)
         .AppendFormat("           ,{0}", valorDeclarado)
         If idTransportista <> 0 Then
            .AppendFormat("           ,{0}", idTransportista)
         Else
            .AppendFormat("           ,NULL")
         End If
         .AppendFormat("           ,{0}", numeroLote)

         .AppendFormat("           ,{0}", totalBruto).AppendLine()
         .AppendFormat("           ,{0}", totalNeto).AppendLine()
         .AppendFormat("           ,{0}", totalIVA).AppendLine()
         .AppendFormat("           ,{0}", totalPercepciones).AppendLine()

         .AppendFormat("           ,'{0}'", metodoGrabacion.ToString().Substring(0, 1))
         .AppendFormat("           ,'{0}'", idFuncion)
         .AppendFormat("           ,'{0}'", nombreProveedor)
         .AppendFormat("           ,'{0}'", cuitProveedor)
         .AppendFormat("           , {0}", impuestosInternos)
         .AppendFormat("           , {0}", If(excluirDePasaje, "1", "0"))
         .AppendFormat("           ,'{0}'", GetStringFromBoolean(mercEnviada))
         .AppendFormat("           , {0} ", GetStringFromNumber(idConceptoCM05))
         If NumeroOrdenCompra <> 0 Then
            .AppendFormat("           , {0} ", GetStringFromNumber(NumeroOrdenCompra))
         Else
            .AppendFormat("           ,NULL")
         End If
         .AppendLine(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Compras")
   End Sub

   Public Sub Compras_U(idSucursal As Integer,
                        idTipoComprobante As String,
                        letra As String,
                        centroEmisor As Integer,
                        numeroComprobante As Long,
                        idProveedor As Long,
                        fecha As Date,
                        IdComprador As Integer,
                        idRubro As Integer,
                        observacion As String,
                        idEmpresa As Integer,
                        periodoFiscal As Integer,
                        idCaja As Integer,
                        mercEnviada As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE Compras")
         .AppendFormatLine("   SET Fecha = '{0}'", Me.ObtenerFecha(fecha, True))
         .AppendFormatLine("      ,IdComprador = {0}", IdComprador)
         .AppendFormatLine("      ,IdRubro = {0}", idRubro)
         .AppendFormatLine("      ,Observacion = '{0}'", observacion)
         If periodoFiscal > 0 Then
            .AppendFormatLine("  ,IdEmpresa = {0}", idEmpresa)
            .AppendFormatLine("  ,PeriodoFiscal = {0}", periodoFiscal)
         Else
            .AppendFormatLine("  ,IdEmpresa = NULL")
            .AppendFormatLine("  ,PeriodoFiscal = NULL")
         End If
         .AppendFormatLine("      ,IdCaja = {0}", idCaja)
         .AppendFormatLine("  ,MercEnviada = '{0}'", mercEnviada)
         .AppendFormatLine(" WHERE IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor = {0}", idProveedor)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Compras")

   End Sub

   Public Sub Compras_D(IdSucursal As Integer,
                        IdTipoComprobante As String,
                        Letra As String,
                        CentroEmisor As Integer,
                        NumeroComprobante As Long,
                        IdProveedor As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM Compras")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal & "")
         .AppendLine("   AND IdTipoComprobante = '" & IdTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & Letra & "'")
         .AppendLine("   AND CentroEmisor = " & CentroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & NumeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Compras")

   End Sub

   Public Sub Compras_MovimientoCaja_U(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroComprobante As Long,
                                IdProveedor As Long,
                                idCaja As Integer,
                                numeroPlanilla As Integer,
                                numeroMovimiento As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Compras")
         .AppendLine("   SET idCaja = " & idCaja.ToString())
         .AppendLine("      ,numeroPlanilla = " & numeroPlanilla.ToString())
         .AppendLine("      ,numeroMovimiento = " & numeroMovimiento.ToString())
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Compras")

   End Sub

   Public Sub Compras_PlanillaCaja_U(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroComprobante As Long,
                                 IdProveedor As Long,
                                idCaja As Integer,
                                numeroPlanilla As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Compras")
         .AppendLine("   SET idCaja = " & idCaja.ToString())
         .AppendLine("      ,numeroPlanilla = " & numeroPlanilla.ToString())
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub
   'El otro Existe (que recibe idSucursal) si viene en 0 la ignora dejando un query identico a este
   'Public Function Existe(idProveedor As Long, _
   '                       idTipoComprobante As String, _
   '                       letra As String, _
   '                       centroEmisor As Short, _
   '                       numeroComprobante As Long) As Boolean

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT IdSucursal FROM Compras C")
   '      ''.AppendLine("INNER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor")
   '      .AppendLine(" WHERE C.IdTipoComprobante = '" & idTipoComprobante & "'")
   '      .AppendLine("   AND C.Letra = '" & letra & "'")
   '      .AppendLine("   AND C.CentroEmisor = " & centroEmisor.ToString())
   '      .AppendLine("   AND C.NumeroComprobante = " & numeroComprobante.ToString())
   '      'Si vengo a ver si existe el comprobante desde ventas 
   '      '(porque estoy buscando un comprobante con numerador unificado) 
   '      'no voy a recibir el vendedor
   '      If idProveedor > 0 Then
   '         .AppendLine("   AND C.IdProveedor = " & idProveedor.ToString())
   '      End If
   '   End With

   '   Dim dt As DataTable = Me.GetDataTable(stb.ToString())
   '   If dt.Rows.Count > 0 Then
   '      Return True
   '   Else
   '      Return False
   '   End If

   'End Function

   Public Function Existe(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As Boolean
      Dim idEmpresa = If(idSucursal = 0, actual.Sucursal.IdEmpresa, 0I)
      Return Existe(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante, idEmpresa)
   End Function

   Public Function Existe(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                          idEmpresa As Integer) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT C.IdSucursal FROM Compras C")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = C.IdSucursal")

         .AppendFormatLine(" WHERE C.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND C.Letra = '{0}'", letra)
         .AppendFormatLine("   AND C.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND C.NumeroComprobante = {0}", numeroComprobante)
         'Para unificar los dos Existe que estan hoy en uso.
         If idSucursal > 0 Then
            .AppendFormatLine("   AND C.IdSucursal = {0}", idSucursal)
         End If
         'Si vengo a ver si existe el comprobante desde ventas 
         '(porque estoy buscando un comprobante con numerador unificado) 
         'no voy a recibir el vendedor
         If idProveedor > 0 Then
            .AppendFormatLine("   AND C.IdProveedor = {0}", idProveedor)
         End If

         If idEmpresa > 0 Then
            .AppendFormatLine("   AND (TC.InformaLibroIva = 'True' OR S.IdEmpresa = {0})", idEmpresa)
         End If

      End With

      Using dt = GetDataTable(stb)
         Return dt.Any()
      End Using

   End Function

   Public Function ComprasTotalSucursal(suc As List(Of Integer),
                                        Desde As DateTime,
                                       Hasta As DateTime) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      With stb
         .Length = 0
         .AppendLine("SELECT S.Nombre")
         .AppendLine("      ,TC.DescripcionAbrev")
         .AppendLine("      ,SUM(C.ImporteTotal) Total")
         .AppendLine(" FROM Compras C ")
         .AppendLine("INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine("     AND TC.AfectaCaja = 'True' ")
         'Por ahora dejo los Gastos (impuestos) ver si tienen que estar o no.
         '.AppendLine("     AND TC.EsComercial = 'True'")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.
         .AppendLine("INNER JOIN Sucursales S ON C.IdSucursal = S.IdSucursal")
         If Desde <> Nothing Then
            .AppendFormat("	 AND C.Fecha >= '{0} 00:00:00'", Desde.ToString("yyyyMMdd"))
            .AppendFormat("	 AND C.Fecha <= '{0} 23:59:59'", Hasta.ToString("yyyyMMdd"))
         End If
         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat(" AND C.IdSucursal = 0")
         Else
            .AppendFormat(" AND C.IdSucursal IN ({0})", sucur)
         End If
         .AppendLine("  GROUP BY S.Nombre, TC.DescripcionAbrev ")
      End With

      Return Me.GetDataTable(stb.ToString())


   End Function

   Public Sub Compras_Facturables_U(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroComprobante As Long,
                                IdProveedor As Long,
                                idEstadoComprobante As String,
                                idTipoComprobanteFact As String,
                                letraFact As String,
                                centroEmisorFact As Integer,
                                numeroComprobanteFact As Long,
                                IdProveedorFact As Long,
                                MercEnviada As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      'Actualiza el registro (ej: REMITO) con los datos del comprobante que lo cancelo (ej: FACTURA)
      With myQuery
         .Length = 0
         .AppendLine("UPDATE Compras SET ")
         .AppendLine("   IdTipoComprobanteFact = '" & idTipoComprobante & "'")
         .AppendLine("  ,LetraFact = '" & letra & "'")
         .AppendLine("  ,CentroEmisorFact = " & centroEmisor.ToString())
         .AppendLine("  ,NumeroComprobanteFact = " & numeroComprobante.ToString())
         .AppendLine("  ,IdProveedorFact = " & IdProveedor.ToString())
         .AppendLine("  ,IdEstadoComprobante = '" & idEstadoComprobante & "'")
         .AppendLine("  ,MercEnviada = '" & MercEnviada & "'")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobanteFact & "'")
         .AppendLine("   AND Letra = '" & letraFact & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisorFact.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobanteFact.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedorFact.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Compras")

   End Sub

   Public Sub Compras_Facturables_Venta_U(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroComprobante As Long,
                                          IdProveedor As Long,
                                          idSucursalVenta As Integer,
                                          idTipoComprobanteVenta As String,
                                          letraVenta As String,
                                          centroEmisorVenta As Integer,
                                          numeroComprobanteVenta As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      'Actualiza el comprobante de COMPRA (ej: FACTURA/REMITO) con los datos del comprobante de VENTA que lo cancelo (ej: LIQUIDACION)
      With myQuery
         .AppendFormatLine("UPDATE Compras")
         .AppendFormatLine("   SET IdSucursalVenta = {0}", idSucursalVenta)
         .AppendFormatLine("      ,IdTipoComprobanteVenta = '{0}'", idTipoComprobanteVenta)
         .AppendFormatLine("      ,LetraVenta = '{0}'", letraVenta)
         .AppendFormatLine("      ,CentroEmisorVenta = {0}", centroEmisorVenta)
         .AppendFormatLine("      ,NumeroComprobanteVenta = {0}", numeroComprobanteVenta)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND IdProveedor = {0}", IdProveedor)
      End With
      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Compras")
   End Sub

   Public Function GetInvocadosCom(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Short,
                                    numeroComprobante As Long,
                                    IdProveedor As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT C.* ")
         .AppendLine("      ,TC.Descripcion")
         .AppendLine("  FROM Compras C, TiposComprobantes TC")
         .AppendLine(" WHERE C.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("   AND C.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND C.IdTipoComprobanteFact = '" & idTipoComprobante & "'")
         .AppendLine("   AND C.LetraFact = '" & letra & "'")
         .AppendLine("   AND C.CentroEmisorFact = " & centroEmisor.ToString())
         .AppendLine("   AND C.NumeroComprobanteFact = " & numeroComprobante.ToString())
         .AppendLine("   AND C.IdProveedorFact = " & IdProveedor.ToString())
         .AppendLine("   ORDER BY C.Fecha")  '--- tiene la hora
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Sub LiberarInvocadosCom(idSucursal As Integer,
                              idTipoComprobante As String,
                              letra As String,
                              centroEmisor As Short,
                              numeroComprobante As Long,
                              IdProveedor As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("UPDATE Compras  SET IdEstadoComprobante = NULL,  IdTipoComprobanteFact = NULL, LetraFact= NULL,  ")
         .AppendLine(" NumeroComprobanteFact = NULL, IdProveedorFact = NULL  ")
         .AppendLine(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND IdProveedor = " & IdProveedor.ToString())

      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub LiberarInvocadosVenta(idSucursalVenta As Integer,
                                    idTipoComprobanteVenta As String,
                                    letraVenta As String,
                                    centroEmisorVenta As Short,
                                    numeroComprobanteVenta As Long)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("UPDATE Compras")
         .AppendLine("   SET IdSucursalVenta = NULL")
         .AppendLine("      ,IdTipoComprobanteVenta = NULL")
         .AppendLine("      ,LetraVenta= NULL")
         .AppendLine("      ,CentroEmisorVenta= NULL")
         .AppendLine("      ,NumeroComprobanteVenta = NULL")
         .AppendFormatLine(" WHERE IdSucursalVenta = {0}", idSucursalVenta)
         .AppendFormatLine("   AND IdTipoComprobanteVenta = '{0}'", idTipoComprobanteVenta)
         .AppendFormatLine("   AND LetraVenta = '{0}'", letraVenta)
         .AppendFormatLine("   AND CentroEmisorVenta = {0}", centroEmisorVenta)
         .AppendFormatLine("   AND NumeroComprobanteVenta = {0}", numeroComprobanteVenta)

      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Function GetEstadComprasProveedores(suc As List(Of Integer),
                                        cantidad As Integer,
                                        Desde As Date,
                                        Hasta As Date,
                                        discIVA As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      With stb
         .Length = 0
         .AppendLine("SELECT TOP " & cantidad.ToString())
         .AppendLine("  C.IdProveedor, ")
         .AppendLine("  P.CodigoProveedor, ")
         .AppendLine("  P.NombreProveedor, ")

         If discIVA Then
            .AppendLine("   SUM(C.TotalNeto) AS Importe")
         Else
            .AppendLine("   SUM(C.ImporteTotal) AS Importe ")
         End If

         .AppendLine("  FROM Compras C ")
         .AppendLine("  INNER JOIN Proveedores P ON P.IdProveedor = C.IdProveedor ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON C.IdTipoComprobante = TC.IdTipoComprobante ")

         .AppendLine("  WHERE TC.AfectaCaja = 'True' ")
         .AppendLine("    AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
         .AppendLine("   AND C.Fecha >= '" & Desde.ToString("yyyyMMdd") & " 00:00:00'")
         .AppendLine("    AND C.Fecha <= '" & Hasta.ToString("yyyyMMdd") & " 23:59:59'")
         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat(" AND C.IdSucursal = 0")
         Else
            .AppendFormat(" AND C.IdSucursal IN ({0})", sucur)
         End If
         .AppendLine("  GROUP BY  C.IdProveedor, P.CodigoProveedor, P.NombreProveedor  ")
         If discIVA Then
            .AppendLine("   HAVING SUM(C.TotalNeto) <> 0")
         Else
            .AppendLine("   HAVING SUM(C.ImporteTotal) <> 0")
         End If
         .AppendLine(" ORDER BY Importe desc ")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetEstadComprasProveedores(suc As List(Of Integer),
                                       cantidad As Integer,
                                       Desde As Date,
                                       Hasta As Date,
                                       idMarca As Integer,
                                       idModelo As Integer,
                                       idRubro As Integer,
                                       idSubRubro As Integer,
                                       IdProducto As String,
                                       discIVA As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      With stb
         .Length = 0
         .AppendLine("SELECT TOP " & cantidad.ToString())
         .AppendLine("  C.IdProveedor, ")
         .AppendLine("  P.CodigoProveedor, ")
         .AppendLine("  P.NombreProveedor, ")

         If discIVA Then
            .AppendLine("   SUM(CP.ImporteTotalNeto) AS Importe")
         Else
            .AppendLine("   SUM(CP.ImporteTotalNeto + CP.IVA) AS Importe ")
         End If

         .AppendLine("  FROM Compras C ")
         .AppendLine("  INNER JOIN Proveedores P ON P.IdProveedor = C.IdProveedor ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON C.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("  INNER JOIN ComprasProductos CP ON C.IdSucursal = CP.IdSucursal ")
         .AppendLine("  AND C.IdTipoComprobante = CP.IdTipoComprobante ")
         .AppendLine("  AND C.Letra = CP.Letra ")
         .AppendLine("  AND C.CentroEmisor = CP.CentroEmisor")
         .AppendLine("  AND C.NumeroComprobante = CP.NumeroComprobante ")
         .AppendLine(" AND C.IdProveedor = CP.IdProveedor")
         .AppendLine("  INNER JOIN Productos Pr ON Pr.IdProducto = CP.IdProducto")
         .AppendLine("  WHERE TC.AfectaCaja = 'True' ")
         .AppendLine("    AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
         .AppendLine("   AND C.Fecha >= '" & Desde.ToString("yyyyMMdd") & " 00:00:00'")
         .AppendLine("    AND C.Fecha <= '" & Hasta.ToString("yyyyMMdd") & " 23:59:59'")
         If idMarca <> 0 Then
            .AppendFormat("	AND Pr.IdMarca = {0}", idMarca)
         End If
         If idModelo <> 0 Then
            .AppendFormat("	AND Pr.IdModelo = {0}", idModelo)
         End If
         If idRubro <> 0 Then
            .AppendFormat("	AND Pr.IdRubro = {0}", idRubro)
         End If
         If idSubRubro <> 0 Then
            .AppendFormat("	AND Pr.IdSubRubro = {0}", idSubRubro)
         End If
         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat(" AND C.IdSucursal = 0")
         Else
            .AppendFormat(" AND C.IdSucursal IN ({0})", sucur)
         End If
         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("	AND CP.IdProducto = '" & IdProducto & "'")
         End If
         .AppendLine(" GROUP BY  C.IdProveedor, P.CodigoProveedor, P.NombreProveedor  ")
         .AppendLine(" ORDER BY Importe desc ")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

#Region "Metodos Citi Compras"
   Public Function GetParaExportarAFIP(idEmpresa As Integer, periodoFiscal As Integer) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT C.Fecha")
         .AppendLine(" ,C.IdSucursal")
         .AppendLine(" ,C.IdTipoComprobante")
         .AppendLine(" ,TC.DescripcionAbrev ")
         .AppendLine(" ,TC.CoeficienteValores")
         .AppendLine(" ,C.Letra ")
         .AppendLine(" ,C.CentroEmisor")
         .AppendLine(" ,C.NumeroComprobante ")
         .AppendLine(" ,CI.NumeroDespachoCompleto")
         .AppendLine(" ,C.IdProveedor")
         .AppendLine(" ,PR.CodigoProveedor ")
         ' .AppendLine(" ,PR.NombreProveedor ")
         .AppendLine(" ,CASE WHEN PR.EsProveedorGenerico = 'True' THEN C.NombreProveedor ELSE PR.NombreProveedor END AS NombreProveedor")
         .AppendLine(" ,PR.TipoDocProveedor ")
         .AppendLine(" ,PR.NroDocProveedor ")
         .AppendLine(" ,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal")
         .AppendLine(" ,C.IdEstadoComprobante")
         .AppendLine(" ,CASE WHEN  PR.EsProveedorGenerico = 'True' THEN C.CuitProveedor ELSE PR.CuitProveedor END AS CuitProveedor")
         '  .AppendLine(" ,PR.CuitProveedor")
         .AppendLine(" ,C.IdFormasPago")
         .AppendLine(" ,ATCTC.IdAFIPTipoComprobante")
         .AppendLine(" ,ATD.IdAFIPTipoDocumento ")
         .AppendLine(" ,CI.TotalImporteImpuesto")
         .AppendLine(" ,CI.TotalBruto")
         .AppendLine(" ,CI.TotalBaseImponible")
         .AppendLine(" ,CI.TotalNoGrabado")
         .AppendLine(" ,CI.CantidadAlicuotas")
         .AppendLine(" ,CI.CantidadAlicuotasAlicuotaDif0")
         .AppendLine(" ,C.ImporteTotal ")
         .AppendLine(" ,C.PercepcionGanancias")
         .AppendLine(" ,C.PercepcionIB")
         .AppendLine(" ,C.PercepcionIVA")
         .AppendLine(" ,C.PercepcionVarias")
         .AppendLine(" ,C.ImpuestosInternos")
         .AppendLine(" ,CI.EsDespachoImportacion")

         .AppendLine(" ,CASE WHEN CI.EsDespachoImportacion = 'False' THEN 0")
         .AppendLine("  ELSE (SELECT SUM(CID.BaseImponible)")
         .AppendLine("          FROM ComprasImpuestos CID")
         .AppendLine("         WHERE CID.EsDespacho = 'True'")
         .AppendLine("           AND CID.IdSucursal = CI.IdSucursal")
         .AppendLine("           AND CID.IdTipoComprobante = CI.IdTipoComprobante")
         .AppendLine("           AND CID.Letra = CI.Letra")
         .AppendLine("           AND CID.CentroEmisor = CI.CentroEmisor")
         .AppendLine("           AND CID.NumeroComprobante = CI.NumeroComprobante")
         .AppendLine("           AND CID.IdProveedor = CI.IdProveedor) END BaseImponibleDespachoImportacion")

         '-- REQ-34586.- ---------------------------
         .AppendLine(" ,CF.IvaCeroCategoriaFiscal")
         '------------------------------------------
         .AppendLine(" FROM Compras C")
         .AppendLine(" INNER JOIN Proveedores PR ON PR.IdProveedor = C.IdProveedor")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = C.IdSucursal")
         .AppendLine(" INNER JOIN Localidades L ON PR.IdLocalidadProveedor = L.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias P ON L.IdProvincia = P.IdProvincia")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")

         .AppendLine(" LEFT JOIN (SELECT CI.IdSucursal, CI.IdTipoComprobante, CI.DescripcionAbrev, CI.Letra, CI.CentroEmisor, CI.NumeroComprobante, CI.IdProveedor, CI.NumeroDespachoCompleto")
         .AppendLine("                 , SUM(CI.Bruto) TotalBruto, SUM(CI.BaseImponible) TotalBaseImponible, SUM(CI.ImporteImpuesto) TotalImporteImpuesto, SUM(CI.BaseImponibleNoGrabado) TotalNoGrabado, COUNT(1) CantidadAlicuotas,EsDespachoImportacion")
         .AppendLine("                 , COUNT(CASE WHEN CI.Alicuota <> 0 THEN 1 END) CantidadAlicuotasAlicuotaDif0")
         .AppendLine("              FROM (")

         SelectComprasImpuestosParaExportarAFIP(stb, idEmpresa, periodoFiscal, esDespachoImportacion:=Nothing)

         .AppendLine("                    ) CI")
         .AppendLine("             GROUP BY CI.IdSucursal, CI.IdTipoComprobante, CI.DescripcionAbrev, CI.CoeficienteValores, CI.Letra, CI.CentroEmisor, CI.NumeroComprobante, CI.IdProveedor, CI.EsDespachoImportacion, CI.NumeroDespachoCompleto) CI")
         .AppendLine("                ON C.IdSucursal = CI.IdSucursal")
         .AppendLine("               AND C.IdTipoComprobante = CI.IdTipoComprobante")
         .AppendLine("               AND C.Letra = CI.Letra")
         .AppendLine("               AND C.CentroEmisor = CI.CentroEmisor")
         .AppendLine("               AND C.NumeroComprobante = CI.NumeroComprobante")
         .AppendLine("               AND C.IdProveedor = CI.IdProveedor")

         .AppendLine(" LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON C.IdTipoComprobante = ATCTC.IdTipoComprobante AND C.Letra = ATCTC.Letra")
         .AppendLine(" LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = PR.TipoDocProveedor")
         .AppendLine("  WHERE C.IdSucursal > 0 ")  ' & idSucursal.ToString())
         .AppendFormatLine("	  AND S.IdEmpresa = {0}", idEmpresa)
         .AppendLine("	  AND C.PeriodoFiscal = " & periodoFiscal.ToString())
         .AppendLine("    AND TC.InformaLibroIva = 'True'")
         .AppendLine("	ORDER BY C.Fecha")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetParaExportarAFIPAlicuotas(idEmpresa As Integer, periodoFiscal As Integer) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendLine("SELECT CI.IdSucursal")
         .AppendLine("     , CI.IdTipoComprobante")
         .AppendLine("     , CI.DescripcionAbrev")
         .AppendLine("     , CI.Letra")
         .AppendLine("     , CI.CentroEmisor")
         .AppendLine("     , CI.NumeroComprobante")
         .AppendLine("     , CI.IdProveedor")
         .AppendLine("     , TC.CoeficienteValores")
         .AppendLine("     , PR.CodigoProveedor")
         '.AppendLine("     , PR.NombreProveedor")
         .AppendLine(" ,CASE WHEN  PR.EsProveedorGenerico = 'True' THEN CI.NombreProveedor ELSE PR.NombreProveedor END AS NombreProveedor")
         .AppendLine("     , PR.TipoDocProveedor")
         .AppendLine("     , PR.NroDocProveedor")
         '.AppendLine("     , PR.CuitProveedor")
         .AppendLine(" ,CASE WHEN  PR.EsProveedorGenerico = 'True' THEN CI.CuitProveedor ELSE PR.CuitProveedor END AS CuitProveedor")
         .AppendLine("     , ATCTC.IdAFIPTipoComprobante")
         .AppendLine("     , ATD.IdAFIPTipoDocumento")
         .AppendLine("     ,CI.Bruto")
         .AppendLine("     ,CI.BaseImponible")
         .AppendLine("     ,CI.ImporteImpuesto")
         .AppendLine("     ,CI.Alicuota")
         .AppendLine("     ,ATA.CodigoAlicuota")
         .AppendLine("     ,CF.IvaCeroCategoriaFiscal")
         .AppendLine("  FROM (")
         SelectComprasImpuestosParaExportarAFIP(stb, idEmpresa, periodoFiscal, False)
         .AppendLine("        ) CI")
         .AppendLine(" INNER JOIN Proveedores PR ON PR.IdProveedor = CI.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CI.IdTipoComprobante")
         .AppendLine("  LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON CI.IdTipoComprobante = ATCTC.IdTipoComprobante AND CI.Letra = ATCTC.Letra")
         .AppendLine("  LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = PR.TipoDocProveedor ")
         .AppendLine("  LEFT JOIN (SELECT 0 Alicuota, 3 CodigoAlicuota UNION SELECT 10.5, 4 UNION SELECT 21, 5 UNION SELECT 27, 6 UNION SELECT 5, 8 UNION SELECT 2.5, 9) ATA ON ATA.Alicuota = CI.Alicuota")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = CI.IdCategoriaFiscal")

         .AppendFormatLine(" CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'CATEGORIAFISCALEMPRESA' AND IdEmpresa = {0}) P", idEmpresa)
         .AppendFormatLine("  LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON CFC.IdCategoriaFiscalCliente = CF.IdCategoriaFiscal AND CFC.IdCategoriaFiscalEmpresa = ISNULL(P.ValorParametro, 0)")

         .AppendLine(" WHERE CFC.IvaDiscriminado = 'True'")

         .AppendLine("   AND (CI.Alicuota <> 0 OR NOT (CF.IvaCeroCategoriaFiscal = 'NOGRAVADO' OR CF.IvaCeroCategoriaFiscal = 'EXENTO'))")
         .AppendLine("   AND CI.Letra <> 'B' AND CI.Letra <> 'C'")

         .AppendLine(" ORDER BY CI.Fecha")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetParaExportarAFIPDespachoImportacion(idEmpresa As Integer, periodoFiscal As Integer) As DataTable
      Dim stb = New StringBuilder()

      With stb
         .AppendLine("Select CI.IdSucursal")
         .AppendLine("     , CI.IdTipoComprobante")
         .AppendLine("     , CI.DescripcionAbrev")
         .AppendLine("     , CI.NumeroDespachoCompleto")
         '.AppendLine("     , CI.IdAduana")
         '.AppendLine("     , CI.IdDestinacion")
         .AppendLine("     , CI.Letra")
         .AppendLine("     , CI.CentroEmisor")
         .AppendLine("     , CI.NumeroComprobante")
         .AppendLine("     , CI.IdProveedor")
         .AppendLine("     , ATCTC.IdAFIPTipoComprobante")
         .AppendLine("     , ATD.IdAFIPTipoDocumento")
         .AppendLine("     , CI.Bruto AS Bruto")
         .AppendLine("     , CI.BaseImponible AS BaseImponible")
         .AppendLine("     , CI.ImporteImpuesto AS ImporteImpuesto")
         .AppendLine("     , CI.Alicuota")
         .AppendLine("     , ATA.CodigoAlicuota")
         '.AppendLine("     , CI.DigitoVerificadorDespacho")
         '.AppendLine("     , CI.FechaOficializacionDespacho")
         .AppendLine("  FROM (")
         SelectComprasImpuestosParaExportarAFIP(stb, idEmpresa, periodoFiscal, True)
         .AppendLine("        ) CI")
         .AppendLine(" INNER JOIN Proveedores PR ON PR.IdProveedor = CI.IdProveedor")
         .AppendLine("  LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON CI.IdTipoComprobante = ATCTC.IdTipoComprobante AND CI.Letra = ATCTC.Letra")
         .AppendLine("  LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = PR.TipoDocProveedor ")
         .AppendLine("  LEFT JOIN (SELECT 0 Alicuota, 3 CodigoAlicuota UNION SELECT 10.5, 4 UNION SELECT 21, 5 UNION SELECT 27, 6 UNION SELECT 5, 8 UNION SELECT 2.5, 9) ATA ON ATA.Alicuota = CI.Alicuota")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = CI.IdCategoriaFiscal")

         .AppendFormatLine(" CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'CATEGORIAFISCALEMPRESA' AND IdEmpresa = {0}) P", idEmpresa)
         .AppendFormatLine("  LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON CFC.IdCategoriaFiscalCliente = CF.IdCategoriaFiscal AND CFC.IdCategoriaFiscalEmpresa = ISNULL(P.ValorParametro, 0)")

         .AppendLine(" WHERE CFC.IvaDiscriminado = 'True'")
         .AppendLine(" ORDER BY CI.Fecha")

      End With

      Return GetDataTable(stb)
   End Function
   Private Sub SelectComprasImpuestosParaExportarAFIP(stb As StringBuilder, idEmpresa As Integer, periodoFiscal As Integer, esDespachoImportacion As Boolean?)
      With stb
         .AppendLine("SELECT CI.IdSucursal, CI.IdTipoComprobante, TC.DescripcionAbrev, CI.Letra, CI.CentroEmisor, CI.NumeroComprobante, CI.IdProveedor")
         .AppendLine("     , TC.CoeficienteValores")
         .AppendLine("     , SUM(CI.Bruto) Bruto, SUM(CI.BaseImponible) BaseImponible, SUM(CI.Importe) ImporteImpuesto, CI.Alicuota")
         .AppendLine("     , SUM(CASE WHEN CI.Alicuota = 0 THEN CI.BaseImponible ELSE 0 END) BaseImponibleNoGrabado")
         .AppendLine("     , C.IdCategoriaFiscal, C.Fecha, TC.EsDespachoImportacion")
         .AppendLine("     , C.NombreProveedor")
         .AppendLine("     , C.CuitProveedor")
         '.AppendLine("     , C.IdCategoriaFiscal, C.Fecha,C.IdAduana,C.IdDestinacion,C.DigitoVerificadorDespacho,C.FechaOficializacionDespacho,TC.EsDespachoImportacion")

         .AppendFormatLine("     , {0} AS NumeroDespachoCompleto", FormatoComprobantes.ObtenerNumeroDespachoCompleto("C"))

         .AppendLine("  FROM ComprasImpuestos CI")
         .AppendLine(" INNER JOIN Compras C ON C.IdSucursal = CI.IdSucursal")
         .AppendLine("                     AND C.IdTipoComprobante = CI.IdTipoComprobante")
         .AppendLine("                     AND C.Letra = CI.Letra")
         .AppendLine("                     AND C.CentroEmisor = CI.CentroEmisor")
         .AppendLine("                     AND C.NumeroComprobante = CI.NumeroComprobante")
         .AppendLine("                     AND C.IdProveedor = CI.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = C.IdSucursal")
         .AppendLine(" WHERE C.IdSucursal > 0")
         .AppendFormatLine("   AND S.IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND C.PeriodoFiscal = {0}", periodoFiscal)
         .AppendLine("    AND TC.InformaLibroIva = 'True'")
         .AppendLine("   AND CI.IdTipoImpuesto = 'IVA'")

         If esDespachoImportacion.HasValue Then
            .AppendFormatLine("   AND TC.EsDespachoImportacion = {0}", GetStringFromBoolean(esDespachoImportacion.Value))
         End If

         .AppendLine("GROUP BY CI.IdSucursal, CI.IdTipoComprobante, TC.DescripcionAbrev, TC.CoeficienteValores, CI.Letra, CI.CentroEmisor, CI.NumeroComprobante, CI.IdProveedor, TC.EsDespachoImportacion,")
         .AppendLine("         CI.Alicuota, C.IdCategoriaFiscal, C.Fecha, TC.EsDespachoImportacion")
         .AppendLine("       , C.FechaOficializacionDespacho, C.IdAduana, C.IdDestinacion, C.NumeroDespacho, C.DigitoVerificadorDespacho, C.NombreProveedor, C.CuitProveedor")
         '.AppendLine("         CI.Alicuota, C.IdCategoriaFiscal, C.Fecha,C.IdAduana,C.IdDestinacion,C.DigitoVerificadorDespacho,C.FechaOficializacionDespacho,TC.EsDespachoImportacion")
      End With
   End Sub
#End Region

   Public Function GetLibroDeIVA(idEmpresa As Integer,
                                 periodoFiscal As Integer,
                                 orden As String,
                                 IdComprador As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT PP.NombreProvincia")
         .AppendLine("      ,C.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev AS NombreTipoComprobante")
         .AppendLine("      ,C.Letra")
         .AppendLine("      ,C.CentroEmisor")
         .AppendLine("      ,C.NumeroComprobante")
         .AppendFormatLine("      ,CASE WHEN TC.EsDespachoImportacion = 'False'")
         .AppendFormatLine("            THEN {0}", FormatoComprobantes.ObtenerEmisorNumeroComprobante("C"))
         .AppendFormatLine("            ELSE {0} END AS ComprobanteFormat", FormatoComprobantes.ObtenerNumeroDespachoCompleto("C"))
         .AppendLine("      ,C.Fecha")
         .AppendLine("      ,C.IdComprador")
         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,CASE WHEN P.EsProveedorGenerico = 'True' THEN C.NombreProveedor ELSE P.NombreProveedor END AS NombreProveedor")
         ' .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,RC.NombreRubro")
         .AppendLine("      ,CI.IdTipoImpuesto")
         .AppendLine("      ,CASE WHEN TI.Tipo = 'IVA' THEN 'IVA' ELSE TI.NombreTipoImpuesto END AS NombreTipoImpuesto")
         .AppendLine("      ,CASE WHEN TI.Tipo = 'IVA' AND CI.Alicuota = 0 THEN CI.BaseImponible ELSE 0 END AS BaseImponibleNoGrabado")
         .AppendLine("      ,CASE WHEN EsDespacho = 1 THEN 0 ELSE CASE WHEN TI.Tipo = 'IVA' AND CI.Alicuota <> 0 THEN CI.BaseImponible ELSE 0 END END AS BaseImponible")
         .AppendLine("      ,CI.Alicuota")
         .AppendLine("      ,CASE WHEN TI.Tipo <> 'PERCEPCION' THEN CI.Importe ELSE 0 END AS Importe")
         .AppendLine("      ,CASE WHEN TI.Tipo = 'PERCEPCION' THEN CI.Importe ELSE 0 END AS ImportePercepcion")
         .AppendLine("      ,CASE WHEN TI.Tipo = 'IVA' THEN CI.BaseImponible ELSE 0 END + CI.Importe ImporteTotal")

         .AppendLine("      ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         .AppendLine("       ,CASE WHEN  P.EsProveedorGenerico = 'True' THEN C.CuitProveedor ELSE P.CuitProveedor END AS Cuit")
         '   .AppendLine("      ,P.CuitProveedor AS Cuit")
         .AppendLine("      ,CI.EsDespacho")
         .AppendLine("      ,C.IdAduana")
         .AppendLine("      ,C.IdDestinacion")
         .AppendLine("      ,TC.EsDespachoImportacion")
         .AppendLine("   FROM Compras C")

         .AppendLine("  INNER JOIN ComprasImpuestos CI ON CI.IdSucursal = C.IdSucursal")
         .AppendLine("                                AND CI.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine("                                AND CI.Letra = C.Letra")
         .AppendLine("                                AND CI.CentroEmisor = C.CentroEmisor")
         .AppendLine("                                AND CI.NumeroComprobante = C.NumeroComprobante")
         .AppendLine("                                AND CI.IdProveedor = C.IdProveedor")

         .AppendLine("   INNER JOIN Sucursales S ON S.IdSucursal = C.IdSucursal ")
         .AppendLine("   INNER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor ")
         .AppendLine("   INNER JOIN RubrosCompras RC ON RC.IdRubro = C.IdRubro ")
         .AppendLine("   INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine("   INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante ")
         .AppendLine("   INNER JOIN Localidades L ON L.IdLocalidad = P.IdLocalidadProveedor ")
         .AppendLine("   INNER JOIN Provincias PP ON PP.IdProvincia = L.IdProvincia ")
         .AppendLine("   INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = CI.IdTipoImpuesto")

         'El IVA es por EMPRESA, no por SUCURSAL.
         '.AppendLine("  WHERE C.IdSucursal > 0")    ' & idSucursal.ToString())
         .AppendFormatLine("  WHERE S.IdEmpresa = {0}", idEmpresa)
         .AppendLine("   AND TC.InformaLibroIva = 'True'")

         .AppendFormatLine("     AND C.PeriodoFiscal = {0}", periodoFiscal)

         If IdComprador > 0 Then
            .AppendFormatLine("     AND C.IdComprador = {0}", IdComprador)
         End If

         If orden = "PROVINCIA" Then
            .AppendLine("	ORDER BY PP.NombreProvincia")
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	   ,CONVERT(varchar(11), C.fecha, 120) ")
         Else
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	ORDER BY CONVERT(varchar(11), C.fecha, 120) ")
         End If
         .AppendLine("     ,P.NombreProveedor ")
         .AppendLine("     ,C.IdTipoComprobante ")
         .AppendLine("     ,C.Letra ")
         .AppendLine("     ,C.CentroEmisor ")
         .AppendLine("     ,C.NumeroComprobante")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetLibroDeIVADinamico(idEmpresa As Integer, periodoFiscal As Integer,
                                         orden As String,
                                         IdComprador As Integer, agrupa As Boolean) As DataTable

      Dim nombreCampo As String
      nombreCampo = "'____' + CASE WHEN CI.IdTipoImpuesto = 'IVA' THEN CI.IdTipoImpuesto + '_' + 'IVA' + '_' + REPLACE(CONVERT(VARCHAR(MAX), CI.Alicuota), '.', '¿') ELSE CI.IdTipoImpuesto + '_' + TI.NombreTipoImpuesto END"
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT QUOTENAME({0}) campo", nombreCampo)
         .AppendLine("  FROM Impuestos CI")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = CI.IdTipoImpuesto")
         .AppendLine(" WHERE (CI.IdTipoImpuesto <> 'IVA' OR CI.Alicuota <> 0)")
         .AppendLine("   AND TI.Tipo IN ('IVA', 'PERCEPCION', 'INTERNO')")
         .AppendLine(" ORDER BY CASE WHEN CI.IdTipoImpuesto = 'IVA' THEN 0 ELSE 1 END, CI.IdTipoImpuesto, Alicuota")
      End With

      Dim dtCampos As DataTable = GetDataTable(stb.ToString())
      Dim campo_pivot As StringBuilder = New StringBuilder()
      Dim campos_nuevo As StringBuilder = New StringBuilder()
      Dim camposExistentes As List(Of String) = New List(Of String)()

      For Each drCampos As DataRow In dtCampos.Rows
         If Not camposExistentes.Contains(drCampos("campo").ToString()) Then
            campo_pivot.AppendFormat("{0},", drCampos("campo"))

            campos_nuevo.AppendFormatLine(", SUM(ISNULL({0}, 0)) AS {0}", drCampos("campo"))

            camposExistentes.Add(drCampos("campo").ToString())
         End If
      Next

      stb = New StringBuilder()

      With stb
         .AppendLine("SELECT ")
         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         .AppendLine("     Fecha")
         .AppendLine("	  ,NombreTipoComprobante")
         .AppendLine("	  ,Letra ")
         .AppendLine("	  ,CentroEmisor")
         .AppendLine("	  ,NumeroComprobante")
         .AppendLine("	  ,ComprobanteFormat")
         .AppendLine("	  ,NombreProvincia")
         .AppendLine("	  ,Cuit")
         .AppendLine("	  ,NombreProveedor")
         .AppendLine("    ,NombreRubro")
         .AppendLine("	  ,NombreCategoriaFiscal")
         .AppendLine("	  ,SUM(BaseImponibleNoGrabado) As BaseImponibleNoGrabado")
         .AppendLine("	  ,SUM(BaseImponible) As BaseImponible")

         If Not agrupa Then
            ' .AppendLine("	  ,NombreTipoImpuesto")
            .AppendLine("	  ,SUM(ImportePercepcion) As ImportePercepcion")
            .AppendLine("    ,Alicuota")
            .AppendFormatLine("    ,Importe1 AS Importe")
         End If
         ''Importe1
         .AppendLine(campos_nuevo.ToString())
         .AppendLine("	  ,SUM(ImporteTotal) As ImporteTotal")

         .AppendLine("  FROM (")

         .AppendLine("SELECT PP.NombreProvincia")
         .AppendLine("      ,C.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev AS NombreTipoComprobante")
         .AppendLine("      ,C.Letra")
         .AppendLine("      ,C.CentroEmisor")
         .AppendLine("      ,C.NumeroComprobante")
         .AppendFormatLine("      ,CASE WHEN TC.EsDespachoImportacion = 'False'")
         .AppendFormatLine("            THEN {0}", FormatoComprobantes.ObtenerEmisorNumeroComprobante("C"))
         .AppendFormatLine("            ELSE {0} END AS ComprobanteFormat", FormatoComprobantes.ObtenerNumeroDespachoCompleto("C"))
         .AppendLine("      ,C.Fecha")
         .AppendLine("      ,C.IdComprador")
         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,CASE WHEN P.EsProveedorGenerico = 'True' THEN C.NombreProveedor ELSE P.NombreProveedor END AS NombreProveedor")
         '.AppendLine("      ,P.NombreProveedor")

         .AppendLine("      ,CI.IdTipoImpuesto")
         If Not agrupa Then
            .AppendLine("      ,CASE WHEN TI.Tipo = 'IVA' THEN 'IVA' ELSE TI.NombreTipoImpuesto END AS NombreTipoImpuesto")
            .AppendLine("      ,CASE WHEN TI.Tipo = 'PERCEPCION' THEN CI.Importe ELSE 0 END AS ImportePercepcion")
         End If
         .AppendLine("      ,CASE WHEN TI.Tipo = 'IVA' AND CI.Alicuota = 0 THEN CI.BaseImponible ELSE 0 END AS BaseImponibleNoGrabado")
         .AppendLine("      ,CASE WHEN EsDespacho = 1 THEN 0 ELSE CASE WHEN TI.Tipo = 'IVA' AND CI.Alicuota <> 0 THEN CI.BaseImponible ELSE 0 END END AS BaseImponible")
         .AppendFormatLine("      ,{0}Alicuota", If(agrupa, "NULL ", "CI."))
         .AppendLine("      ,CI.Importe")
         .AppendLine("      ,CI.Importe Importe1")
         .AppendLine("      ,CASE WHEN TI.Tipo = 'IVA' THEN CI.BaseImponible ELSE 0 END + CI.Importe ImporteTotal")
         .AppendLine("      ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         .AppendLine("       ,CASE WHEN  P.EsProveedorGenerico = 'True' THEN C.CuitProveedor ELSE P.CuitProveedor END AS Cuit")
         '  .AppendLine("      ,P.CuitProveedor AS Cuit")
         .AppendLine("      ,CI.EsDespacho")
         .AppendLine("      ,C.IdAduana")
         .AppendLine("      ,C.IdDestinacion")
         .AppendLine("      ,TC.EsDespachoImportacion")
         .AppendLine("      ,'____' + CASE WHEN TI.Tipo= 'IVA' THEN CI.IdTipoImpuesto + '_' + 'IVA' + '_' + REPLACE(CONVERT(VARCHAR(MAX), CI.Alicuota), '.', '¿') ELSE CI.IdTipoImpuesto + '_' + TI.NombreTipoImpuesto END AS Impuesto_Importe")
         .AppendLine("      ,RC.NombreRubro")

         .AppendLine("   FROM Compras C")

         .AppendLine("  INNER JOIN ComprasImpuestos CI ON CI.IdSucursal = C.IdSucursal")
         .AppendLine("                                AND CI.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine("                                AND CI.Letra = C.Letra")
         .AppendLine("                                AND CI.CentroEmisor = C.CentroEmisor")
         .AppendLine("                                AND CI.NumeroComprobante = C.NumeroComprobante")
         .AppendLine("                                AND CI.IdProveedor = C.IdProveedor")

         .AppendLine("   INNER JOIN Sucursales S ON S.IdSucursal = C.IdSucursal ")
         .AppendLine("   INNER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor ")
         .AppendLine("   INNER JOIN RubrosCompras RC ON RC.IdRubro = P.IdRubroCompra ")
         .AppendLine("   INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine("   INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante ")
         .AppendLine("   INNER JOIN Localidades L ON L.IdLocalidad = P.IdLocalidadProveedor ")
         .AppendLine("   INNER JOIN Provincias PP ON PP.IdProvincia = L.IdProvincia ")
         .AppendLine("   INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = CI.IdTipoImpuesto")

         'El IVA es por EMPRESA, no por SUCURSAL.
         '.AppendLine("  WHERE C.IdSucursal > 0")    ' & idSucursal.ToString())
         .AppendFormatLine("  WHERE S.IdEmpresa = {0}", idEmpresa)
         .AppendLine("        AND TC.InformaLibroIva = 'True'")

         .AppendFormatLine("     AND C.PeriodoFiscal = {0}", periodoFiscal)

         If IdComprador > 0 Then
            .AppendFormatLine("     AND C.IdComprador = {0}", IdComprador)
         End If

         .AppendLine(" ) AS CI")

         .AppendFormatLine("PIVOT (SUM(Importe) FOR Impuesto_Importe IN ({0}))", campo_pivot.ToString().Trim(","c))

         .AppendLine("AS CIP")

         .AppendLine("	 GROUP BY NombreProvincia")
         .AppendLine("	,IdTipoComprobante")
         .AppendLine("	,NombreTipoComprobante")
         .AppendLine("	,Letra")
         .AppendLine("	,CentroEmisor")
         .AppendLine("	,NumeroComprobante")
         .AppendLine("	,ComprobanteFormat")
         .AppendLine("	,Fecha")
         .AppendLine("	,Cuit")
         .AppendLine("	,NombreProveedor")
         .AppendLine("	,NombreCategoriaFiscal")
         .AppendLine("	,NombreRubro")

         If Not agrupa Then
            .AppendLine("	,Alicuota")
            .AppendLine("	,Importe1")
            .AppendLine("  ,NombreTipoImpuesto")
         End If


         If orden = "PROVINCIA" Then
            .AppendLine(" ORDER BY NombreProvincia")
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	   ,CONVERT(varchar(11), fecha, 120) ")
         Else
            'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
            .AppendLine("	ORDER BY CONVERT(varchar(11), fecha, 120) ")
         End If
         .AppendLine("     ,NombreProveedor ")
         .AppendLine("     ,IdTipoComprobante ")
         .AppendLine("     ,Letra ")
         .AppendLine("     ,CentroEmisor ")
         .AppendLine("     ,NumeroComprobante")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetMovimientosConceptos(IdSucursal As Integer,
                                        Desde As Date?,
                                        Hasta As Date,
                                        IdProveedor As Long,
                                        GrabaLibro As String,
                                        AfectaCaja As String,
                                        IdTipoComprobante As String,
                                        IdRubroConcepto As Integer,
                                        pasajeComprasIncluyeImpuestos As Boolean,
                                        excluirEnPasaje As Entidades.Publicos.SiNoTodos) As DataTable
      Dim incluyePercepciones As Boolean = False

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT CP.IdSucursal")
         .AppendLine("      ,CP.IdTipoComprobante")
         .AppendLine("      ,TP.DescripcionAbrev AS NombreTipoComprobante")
         .AppendLine("      ,CP.Letra")
         .AppendLine("      ,CP.CentroEmisor")
         .AppendLine("      ,CP.NumeroComprobante")
         .AppendLine("      ,C.Fecha")
         .AppendLine("      ,P.NombreProveedor")
         '.AppendLine("      ,CP.TipoDocProveedor")
         '.AppendLine("      ,CP.NroDocProveedor")
         .AppendLine("      ,CP.IdProveedor")
         .AppendLine("      ,CP.IdConcepto")
         .AppendLine("      ,CO.NombreConcepto")
         .AppendLine("      ,CP.Precio")
         .AppendLine("      ,CP.DescuentoRecargo")
         .AppendLine("      ,CP.ImporteTotal AS ImporteTotal")
         .AppendLine("      ,CP.PorcentajeIVA")
         .AppendLine("      ,CP.IVA")
         If pasajeComprasIncluyeImpuestos Then
            If incluyePercepciones Then
               .AppendLine("      ,(CP.ImporteTotalNeto + CP.Iva + CP.ProporcionalImp) AS Importe")
            Else
               .AppendLine("      ,(CP.ImporteTotalNeto + CP.Iva) AS Importe")
            End If
         Else
            .AppendLine("      ,(CP.ImporteTotalNeto ) AS Importe")
         End If
         If incluyePercepciones Then
            .AppendLine("      ,CP.MontoSaldo AS MontoSaldo")
            .AppendLine("      ,CP.MontoSaldo AS MontoAplicar")
         Else
            .AppendLine("      ,((CP.MontoSaldo - CP.ProporcionalImp)) AS MontoSaldo")
            .AppendLine("      ,((CP.MontoSaldo - CP.ProporcionalImp)) AS MontoAplicar")
         End If
         .AppendLine("      ,CP.Orden")
         .AppendLine("      ,TP.CoeficienteValores")
         .AppendLine("      ,C.ExcluirDePasaje")
         .AppendFormatLine("      ,{0}", ConvertirBitSiNo("C", "ExcluirDePasaje"))
         .AppendLine("     FROM ComprasProductos CP")
         .AppendLine("     INNER JOIN Compras C ON C.IdSucursal = CP.IdSucursal ")
         .AppendLine("     And C.IdTipoComprobante = CP.IdTipoComprobante ")
         .AppendLine("     And C.Letra = CP.Letra ")
         .AppendLine("     And C.CentroEmisor = CP.CentroEmisor ")
         .AppendLine("     And C.NumeroComprobante = CP.NumeroComprobante ")
         .AppendLine("     And C.IdProveedor = CP.IdProveedor ")
         .AppendLine("   INNER JOIN Proveedores P On C.IdProveedor = P.IdProveedor ")
         .AppendLine("   INNER JOIN TiposComprobantes TP On TP.IdTipoComprobante = CP.IdTipoComprobante ")
         .AppendLine("    LEFT JOIN Conceptos CO On CP.IdConcepto = CO.IdConcepto ")
         .AppendLine("    LEFT JOIN RubrosConceptos R On CO.IdRubroConcepto = R.IdRubroConcepto")

         .AppendLine("   WHERE CP.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("     And TP.IncluirEnExpensas = 1")

         If Desde.HasValue Then
            .AppendFormatLine("     And C.Fecha >= '{0}'", ObtenerFecha(Desde.Value.Date, True))
         End If
         .AppendFormatLine("     AND C.Fecha <= '{0}'", ObtenerFecha(UltimoSegundoDelDia(Hasta), True))

         If IdProveedor > 0 Then
            .AppendLine(" AND CP.IdProveedor = " & IdProveedor.ToString())
         End If

         If GrabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         End If

         If AfectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(AfectaCaja = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(IdTipoComprobante) Then
            .AppendLine("	 AND CP.IdTipoComprobante = '" & IdTipoComprobante & "'")
         End If

         If IdRubroConcepto > 0 Then
            .AppendLine("	AND R.IdRubroConcepto = " & IdRubroConcepto.ToString())
         End If

         'Dependiendo de la misma condición con la que arma el importe de MontoSaldo (más arriba) debo contemplar diferente el monto para que sea cero.
         If incluyePercepciones Then
            .AppendLine("  AND ROUND(CP.MontoSaldo, 2) <> 0")
         Else
            .AppendLine("  AND ROUND(CP.MontoSaldo - CP.ProporcionalImp, 2) <> 0")
         End If

         .AppendLine("  AND ROUND(CP.MontoSaldo, 2) <> 0")

         If excluirEnPasaje <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("	AND C.ExcluirDePasaje = {0}", GetStringFromBoolean(excluirEnPasaje = Entidades.Publicos.SiNoTodos.SI))
         End If

         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         .AppendLine("	ORDER BY CONVERT(varchar(11), C.Fecha, 120), ")
         .AppendLine("     CP.IdTipoComprobante, ")
         .AppendLine("     CP.Letra, ")
         .AppendLine("     CP.CentroEmisor, ")
         .AppendLine("     CP.NumeroComprobante")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetDespachosPorCodigo(idSucursal As Integer, parteId As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT C.FechaOficializacionDespacho,")
         .AppendLine("       CONVERT(VARCHAR(4), YEAR(C.FechaOficializacionDespacho)) + '-' +")
         .AppendLine("       CONVERT(VARCHAR(MAX), C.IdAduana) + '-' + C.IdDestinacion + '-' +")
         .AppendLine("       CONVERT(VARCHAR(MAX), C.NumeroDespacho) + '-' + C.DigitoVerificadorDespacho Despacho")
         .AppendLine("      ,A.NombreAduana")
         .AppendLine("  FROM Compras C")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine(" INNER JOIN Aduanas A ON A.IdAduana = C.IdAduana")
         .AppendLine(" WHERE TC.EsDespachoImportacion = 1")
         .AppendLine("   AND C.IdSucursal = " + idSucursal.ToString())
         If Not String.IsNullOrWhiteSpace(parteId) Then
            .AppendFormat("   AND CONVERT(VARCHAR(4), YEAR(C.FechaOficializacionDespacho)) + '-' +")
            .AppendFormat("       CONVERT(VARCHAR(MAX), C.IdAduana) + '-' + C.IdDestinacion + '-' +")
            .AppendFormat("       CONVERT(VARCHAR(MAX), C.NumeroDespacho) + '-' + C.DigitoVerificadorDespacho LIKE '%{0}%'", parteId).AppendLine()
         End If
         .AppendLine(" ORDER BY C.FechaOficializacionDespacho DESC")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetDespachosPorManifiesto(idSucursal As Integer, parteId As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT C.FechaOficializacionDespacho,")
         .AppendLine("       C.NumeroManifiestoDespacho Despacho")
         .AppendLine("      ,A.NombreAduana")
         .AppendLine("  FROM Compras C")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine(" INNER JOIN Aduanas A ON A.IdAduana = C.IdAduana")
         .AppendLine(" WHERE TC.EsDespachoImportacion = 1")
         .AppendLine("   AND C.IdSucursal = " + idSucursal.ToString())
         If Not String.IsNullOrWhiteSpace(parteId) Then
            .AppendFormat("   AND C.NumeroManifiestoDespacho LIKE '%{0}%'", parteId).AppendLine()
         End If
         .AppendLine(" ORDER BY C.FechaOficializacionDespacho DESC")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorRangoFechas(sucursales As Entidades.Sucursal(),
                                     idEmpresa As Integer, periodoFiscal As Integer,
                                     desde As Date, hasta As Date,
                                     idProveedor As Long, IdComprador As Integer,
                                     grabaLibro As String, afectaCaja As String, esComercial As String,
                                     tipoComprobante As String, numeroComprobante As Long,
                                     idFormasPago As Integer, idRubro As Integer,
                                     estado As String, idCategoria As Integer, idUsuario As String, idCentroCosto As Integer,
                                     idMoneda As Integer, tipoConversion As Entidades.Moneda_TipoConversion, cotizDolar As Decimal,
                                     nivelAutorizacion As Short, utilizaCentroCostos As Boolean) As DataTable
      If idMoneda = Entidades.Moneda.Peso Then
         cotizDolar = 1
         tipoConversion = Entidades.Moneda_TipoConversion.Actual
      End If

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT S.IdEmpresa")
         .AppendLine("      ,C.IdSucursal")
         .AppendLine("      ,C.PeriodoFiscal")
         .AppendLine("      ,C.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev AS NombreTipoComprobante")
         .AppendLine("      ,C.Letra")
         .AppendLine("      ,C.CentroEmisor")
         .AppendLine("      ,C.NumeroComprobante")
         .AppendLine("      ,C.Fecha")
         .AppendLine("      ,CONVERT(DATE, C.Fecha) AS Fecha_FECHA")
         .AppendLine("      ,CONVERT(TIME, C.Fecha) AS Fecha_HORA")
         .AppendLine("      ,C.IdComprador")
         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,CASE WHEN P.EsProveedorGenerico = 'True' THEN C.NombreProveedor ELSE P.NombreProveedor END AS NombreProveedor")
         '   .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,C.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago AS FormaDePago")
         .AppendLine("      ,C.DescuentoRecargo")

         .AppendLine("      ,C.IVAModificadoManual")

         .AppendFormatLine("      ,(C.ImporteTotal / {0}) ImporteTotal", If(tipoConversion = Entidades.Moneda_TipoConversion.Actual, cotizDolar.ToString(), "C.CotizacionDolar"))
         .AppendLine("      ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         .AppendLine("      ,P.CuitProveedor AS Cuit")
         .AppendLine("      ,C.Observacion")
         .AppendLine("      ,C.IdRubro")
         .AppendLine("      ,RC.NombreRubro")
         .AppendLine("      ,C.CantidadInvocados")
         .AppendLine("      ,C.FechaActualizacion")
         .AppendLine("      ,C.Usuario")
         .AppendLine("      ,C.IdEjercicio")
         .AppendLine("      ,C.IdPlanCuenta")
         .AppendLine("      ,C.IdAsiento")
         .AppendLine("      ,C.ImportePesos")
         .AppendLine("      ,C.ImporteTarjetas")
         .AppendLine("      ,C.ImporteCheques")
         .AppendLine("      ,C.ImporteTransfBancaria")
         .AppendLine("      ,C.IdCuentaBancaria")
         .AppendLine("      ,CB.NombreCuenta")
         .AppendLine("      ,BCO.NombreBanco")
         .AppendLine("      ,C.DerechoAduanero")

         .AppendFormatLine("      ,(C.TotalBruto / {0}) TotalBruto", If(tipoConversion = Entidades.Moneda_TipoConversion.Actual, cotizDolar.ToString(), "C.CotizacionDolar"))
         .AppendFormatLine("      ,(C.TotalNeto / {0}) TotalNeto", If(tipoConversion = Entidades.Moneda_TipoConversion.Actual, cotizDolar.ToString(), "C.CotizacionDolar"))
         .AppendFormatLine("      ,(C.TotalIVA / {0}) TotalIVA", If(tipoConversion = Entidades.Moneda_TipoConversion.Actual, cotizDolar.ToString(), "C.CotizacionDolar"))
         .AppendFormatLine("      ,(C.TotalPercepciones / {0}) TotalPercepciones", If(tipoConversion = Entidades.Moneda_TipoConversion.Actual, cotizDolar.ToString(), "C.CotizacionDolar"))

         .AppendLine("      ,C.MetodoGrabacion")
         .AppendLine("      ,C.IdFuncion")
         .AppendLine("      ,C.CotizacionDolar")

         If utilizaCentroCostos Then
            .AppendLine("      ,(SELECT DISTINCT CC.NombreCentroCosto + ' / '")
            .AppendLine("          FROM ComprasProductos CP")
            .AppendLine("         INNER JOIN ContabilidadCentrosCostos CC ON CC.IdCentroCosto = CP.IdCentroCosto")
            .AppendLine("            WHERE CP.IdSucursal = C.IdSucursal And CP.IdTipoComprobante = C.IdTipoComprobante And CP.Letra = C.Letra")
            .AppendLine("           AND CP.CentroEmisor = C.CentroEmisor AND CP.NumeroComprobante = C.NumeroComprobante AND CP.IdProveedor = C.IdProveedor")
            .AppendLine("           FOR XML PATH('')) NombresCentrosCosto")
         Else
            .AppendLine("      , '' NombresCentrosCosto")
         End If

         .AppendLine("      ,CN.NombreCaja")
         .AppendLine("      ,C.NumeroPlanilla")
         .AppendLine("      ,C.NumeroMovimiento")

         .AppendFormatLine("     , C.IdConceptoCM05 ")
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")

         .AppendLine("   FROM Compras C")

         .AppendLine("   INNER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor")
         .AppendLine("   INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal")
         .AppendLine("   INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine("   INNER JOIN VentasFormasPago VFP ON VFP.IdFormasPago = C.IdFormasPago")
         .AppendLine("   INNER JOIN Sucursales S ON S.IdSucursal = C.IdSucursal")
         .AppendLine("    LEFT JOIN CuentasBancarias CB ON CB.IdCuentaBancaria = C.IdCuentaBancaria")
         .AppendLine("    LEFT JOIN Bancos BCO ON BCO.IdBanco = CB.IdBanco")
         .AppendLine("    LEFT JOIN RubrosCompras RC ON C.IdRubro = RC.IdRubro")
         .AppendLine("    LEFT JOIN CajasNombres CN ON CN.IdCaja = C.IdCaja AND CN.IdSucursal=C.IdSucursal")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = C.IdConceptoCM05")
         .AppendLine("   WHERE 1 = 1")


         NivelAutorizacionProveedorTipoComprobante(stb, "P", "TC", nivelAutorizacion)

         GetListaSucursalesMultiples(stb, sucursales, "C")

         '-- REQ-33008 .- Consultar compras No traes comprobantes de otra sucursales.- 
         '.AppendFormatLine("	  AND S.IdEmpresa = {0}", idEmpresa)
         '----------------------------------------------------------------------------
         If periodoFiscal > 0 Then
            .AppendLine("	  AND C.PeriodoFiscal = " & periodoFiscal.ToString())
         End If

         'If Desde > Date.Parse("01/01/1990") Then
         If desde <> Nothing Then
            .AppendLine("     AND CONVERT(varchar(11), C.fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("     AND CONVERT(varchar(11), C.fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         End If

         If IdComprador > 0 Then
            .AppendLine("     AND C.IdComprador = " & IdComprador)
         End If

         If Not String.IsNullOrEmpty(tipoComprobante) Then
            .AppendLine("	AND C.IdTipoComprobante = '" & tipoComprobante & "'")
         End If

         If numeroComprobante > 0 Then
            .AppendLine("	  AND C.NumeroComprobante = " & numeroComprobante.ToString())
         End If

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         If esComercial <> "TODOS" Then
            .AppendLine("      AND TC.EsComercial = " & IIf(esComercial = "SI", "1", "0").ToString())
         End If

         If idFormasPago > 0 Then
            .AppendLine("	AND C.IdFormasPago = " & idFormasPago.ToString())
         End If

         If idRubro > 0 Then
            .AppendLine("	AND C.idRubro = " & idRubro.ToString())
         End If

         If Not String.IsNullOrEmpty(estado) Then
            If estado = "PENDIENTE" Then
               .AppendLine("	AND C.IdEstadoComprobante is NULL ")
            Else
               .AppendLine("	AND C.IdEstadoComprobante = '" & estado.ToString() & "'")
            End If
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND P.IdCategoria = " & idCategoria.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	 AND C.Usuario = '" & idUsuario & "'")
         End If

         If idCentroCosto > 0 Then
            .AppendLine("    AND EXISTS (SELECT idCentroCosto")
            .AppendLine("                  FROM ComprasProductos CP")
            .AppendFormatLine("          WHERE CP.idCentroCosto= {0}", idCentroCosto)
            .AppendLine("                      AND C.IdSucursal=CP.IdSucursal")
            .AppendLine("                      AND C.IdTipoComprobante=CP.IdTipoComprobante")
            .AppendLine("                      AND C.Letra=CP.Letra")
            .AppendLine("                      AND C.CentroEmisor=CP.CentroEmisor")
            .AppendLine("                      AND C.NumeroComprobante=CP.NumeroComprobante")
            .AppendLine("                      AND C.IdProveedor=CP.IdProveedor)")
         End If
         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         .AppendLine("	ORDER BY CONVERT(varchar(11), C.fecha, 120), ")
         .AppendLine("     C.IdTipoComprobante, ")
         .AppendLine("     C.Letra, ")
         .AppendLine("     C.CentroEmisor, ")
         .AppendLine("     C.NumeroComprobante")

      End With

      Return GetDataTable(stb.ToString())

   End Function

   Public Function GetResumenDeCompras(sucursales As Entidades.Sucursal(),
                                       idEmpresa As Integer,
                                       periodoFiscalDesde As Integer,
                                       periodoFiscalHasta As Integer,
                                       grabaLibro As String,
                                       afectaCaja As String,
                                       esComercial As String,
                                       informaLibroIva As String,
                                       agrupadoPorSucursal As Boolean,
                                       agrupadoPor As Entidades.ResumenDeVenta_AgrupadoPor,
                                       separarNetos As Boolean) As DataTable
      Dim nombreCampo As String
      nombreCampo = "'____' + CASE WHEN I.IdTipoImpuesto = 'IVA' THEN I.IdTipoImpuesto + '_' + 'IVA' + '_' + REPLACE(CONVERT(VARCHAR(MAX), I.Alicuota), '.', '#') ELSE I.IdTipoImpuesto + '_' + TI.NombreTipoImpuesto END"
      Dim nombreCampoNetoGravado As String = "'____IVA_NetoGravado_' + REPLACE(CONVERT(VARCHAR(MAX), I.Alicuota), '.', '#')"

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT DISTINCT * FROM (")
         .AppendFormatLine("SELECT TOP 100 PERCENT QUOTENAME({0}) campo", nombreCampo)
         .AppendLine("  FROM Impuestos I")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = I.IdTipoImpuesto")
         .AppendLine(" WHERE (I.IdTipoImpuesto <> 'IVA' OR I.Alicuota <> 0)")
         .AppendLine("   AND TI.Tipo IN ('IVA', 'PERCEPCION', 'INTERNO')")
         .AppendLine(" ORDER BY CASE WHEN I.IdTipoImpuesto = 'IVA' THEN 0 ELSE 1 END, I.IdTipoImpuesto, Alicuota")
         .AppendLine(") T")
      End With
      Dim dtCampos As DataTable = GetDataTable(stb.ToString())

      '# Campos de Neto Gravado separados
      stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT QUOTENAME({0}) campo", nombreCampoNetoGravado)
         .AppendLine("  FROM Impuestos I")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = I.IdTipoImpuesto")
         .AppendLine(" WHERE (I.IdTipoImpuesto <> 'IVA' OR I.Alicuota <> 0)")
         .AppendLine("   AND TI.Tipo IN ('IVA')")
         .AppendLine(" ORDER BY CASE WHEN I.IdTipoImpuesto = 'IVA' THEN 0 ELSE 1 END, I.IdTipoImpuesto, Alicuota")
      End With
      Dim dtCamposNetoGravadosSeparados As DataTable = GetDataTable(stb.ToString())

      Dim campo_pivot As StringBuilder = New StringBuilder()
      Dim campo_pivot_netoGravado As StringBuilder = New StringBuilder()
      Dim campos_sum As StringBuilder = New StringBuilder()
      Dim campos_total As StringBuilder = New StringBuilder()

      Dim camposExistentes As List(Of String) = New List(Of String)()

      For Each drCampos As DataRow In dtCampos.Rows
         If Not camposExistentes.Contains(drCampos("campo").ToString()) Then
            campo_pivot.AppendFormat("{0},", drCampos("campo"))
            '  If agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto And drCampos("campo").ToString().StartsWith("[____IMINT") Then
            'campos_sum.AppendFormatLine(", SUM(0) AS {0}", drCampos("campo"))
            'Else
            campos_sum.AppendFormatLine(", SUM(ISNULL({0}, 0)) AS {0}", drCampos("campo"))
            '    End If
            campos_total.AppendFormat(" + ISNULL({0}, 0)", drCampos("campo"))
            camposExistentes.Add(drCampos("campo").ToString())
         End If
      Next

      '# Campos de Neto Gravado
      If separarNetos Then
         For Each gravCampos As DataRow In dtCamposNetoGravadosSeparados.Rows
            If Not camposExistentes.Contains(gravCampos("campo").ToString()) Then
               campo_pivot_netoGravado.AppendFormat("{0},", gravCampos("campo"))
               campos_sum.AppendFormatLine(", SUM(ISNULL({0}, 0)) AS {0}", gravCampos("campo"))
               campos_total.AppendFormat(" + ISNULL({0}, 0)", gravCampos("campo"))
               camposExistentes.Add(gravCampos("campo").ToString())
            End If
         Next
      End If

      stb = New StringBuilder()

      With stb
         .AppendLine("SELECT VIP.NombreSucursal")
         Select Case agrupadoPor
            Case Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra
               .AppendLine("      ,VIP.Descripcion,VIP.Letra")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal
               .AppendLine("      ,VIP.NombreCategoriaFiscal")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroCompra
               .AppendLine("      ,VIP.NombreRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto
               .AppendLine("      ,VIP.NombreRubro")
            Case Else
               Throw New ArgumentOutOfRangeException(String.Format("Método de agrupado {0} no definido.", agrupadoPor))
         End Select

         .AppendLine("      ,SUM(VIP.NetoNoGravado) NetoNoGravado")
         .AppendLine("      ,SUM(VIP.NetoGravado) Neto")

         ''If agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
         ''   .AppendLine("      ,SUM(VIP.ImporteTotalNeto) Neto")
         ''Else
         ''   .AppendLine("      ,SUM(VIP.Neto) Neto")
         ''End If
         .AppendLine(campos_sum.ToString())
         If agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            If separarNetos Then
               .AppendFormatLine("      ,SUM(VIP.NetoNoGravado {0}) Total", campos_total)
            Else
               .AppendFormatLine("      ,SUM(VIP.ImporteTotalNeto {0}) Total", campos_total)
            End If
         Else
            If separarNetos Then
               .AppendFormatLine("      ,SUM(VIP.NetoNoGravado  {0}) Total", campos_total)
            Else
               .AppendFormatLine("      ,SUM(VIP.NetoNoGravado + VIP.NetoGravado {0}) Total", campos_total)
            End If

         End If

         If agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            nombreCampo = "'____' + 'IVA' + '_' + 'IVA' + '_' + REPLACE(CONVERT(VARCHAR(MAX), VI.PorcentajeIVA), '.', '#')"
            nombreCampoNetoGravado = "'____IVA_NetoGravado_' + REPLACE(CONVERT(VARCHAR(MAX), VI.PorcentajeIVA), '.', '#')"
         End If
         .AppendLine("      ,SUM(CASE WHEN VIP.DerechoAduanero IS NULL THEN 0 ELSE VIP.DerechoAduanero END) DerechoAduanero")

         .AppendFormatLine("  FROM (SELECT {0} AS Impuesto_Importe", nombreCampo)
         If separarNetos Then .AppendFormatLine("              ,{0} AS NetoGravadoSeparado", nombreCampoNetoGravado)
         .AppendLine("              ,VI.*")
         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            .AppendLine("              ,CASE WHEN VI.Alicuota =  0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.BaseImponible ELSE 0 END NetoNoGravado")
            .AppendLine("              ,CASE WHEN VI.Alicuota <> 0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.BaseImponible ELSE 0 END NetoGravado")
            If separarNetos Then .AppendLine("              ,CASE WHEN VI.Alicuota <> 0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.BaseImponible ELSE 0 END NetoGravado1")
         Else
            .AppendLine("              ,CASE WHEN VI.PorcentajeIVA =  0 THEN VI.ImporteTotalNeto ELSE 0 END NetoNoGravado")
            .AppendLine("              ,CASE WHEN VI.PorcentajeIVA <> 0 THEN VI.ImporteTotalNeto ELSE 0 END NetoGravado")
            If separarNetos Then .AppendLine("              ,CASE WHEN VI.PorcentajeIVA <> 0 THEN VI.ImporteTotalNeto ELSE 0 END NetoGravado1")
         End If
         If agrupadoPorSucursal Then
            .AppendLine("              ,S.Nombre NombreSucursal")
         Else
            .AppendLine("              ,'' NombreSucursal")
         End If

         Select Case agrupadoPor
            Case Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra
               .AppendLine("              ,TC.Descripcion")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal
               .AppendLine("              ,CF.NombreCategoriaFiscal")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroCompra
               .AppendLine("              ,CAT.NombreRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto
               .AppendLine("              ,R.NombreRubro")
            Case Else
               Throw New ArgumentOutOfRangeException(String.Format("Método de agrupado {0} no definido.", agrupadoPor))
         End Select

         .AppendLine("              ,V.DerechoAduanero")

         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            .AppendLine("          FROM ComprasImpuestos VI")
         Else
            .AppendLine("          FROM ComprasProductos VI")
         End If
         .AppendLine("         INNER JOIN Compras V ON VI.IdSucursal = V.IdSucursal")
         .AppendLine("                            AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                            AND VI.Letra = V.Letra")
         .AppendLine("                            AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("                            AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("                            AND VI.IdProveedor = V.IdProveedor")
         .AppendLine("         INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            .AppendLine("         INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
            .AppendLine("         INNER JOIN Impuestos I ON I.IdTipoImpuesto = VI.IdTipoImpuesto AND I.Alicuota = VI.Alicuota")
         End If
         .AppendLine("         INNER JOIN Sucursales S ON VI.IdSucursal = S.IdSucursal")
         Select Case agrupadoPor
            Case Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra

            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal
               .AppendLine("         INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroCompra
               '.AppendLine("         INNER JOIN Proveedores CL ON CL.IdProveedor = V.IdProveedor ")
               .AppendLine("         INNER JOIN RubrosCompras CAT ON V.IdRubro = CAT.IdRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto
               .AppendLine("         INNER JOIN Productos P ON P.IdProducto = VI.IdProducto")
               .AppendLine("         INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
            Case Else
               Throw New ArgumentOutOfRangeException(String.Format("Método de agrupado {0} no definido.", agrupadoPor))
         End Select
         .AppendLine("         WHERE 1 = 1")
         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            .AppendLine("           AND VI.EsDespacho = 0")
         End If

         If periodoFiscalDesde > 0 And periodoFiscalHasta > 0 Then
            .AppendLine("	 AND S.IdEmpresa = " & idEmpresa.ToString())
            .AppendLine("	 AND V.PeriodoFiscal >= " & periodoFiscalDesde.ToString())
            .AppendLine("	 AND V.PeriodoFiscal <= " & periodoFiscalHasta.ToString())
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         If esComercial <> "TODOS" Then
            .AppendLine("      AND TC.EsComercial = " & IIf(esComercial = "SI", "1", "0").ToString())
         End If

         If informaLibroIva <> "TODOS" Then
            .AppendLine("      AND TC.InformaLibroIva = " & IIf(informaLibroIva = "SI", "1", "0").ToString())
         End If

         ' '.AppendLine("          AND VI.IdTipoImpuesto IN ('IVA', 'PIIBB', 'IMINT')")
         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            .AppendLine("          AND TI.Tipo IN ('IVA', 'PERCEPCION', 'INTERNO')")
         End If
         .AppendLine(" ) AS VI ")

         '# Separo los Neto Gravado por alícuotas
         If separarNetos Then
            .AppendFormatLine("PIVOT (SUM(NetoGravado1) FOR NetoGravadoSeparado IN ({0}))", campo_pivot_netoGravado.ToString().Trim(","c))
            .AppendLine("AS NGS")
         End If

         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            .AppendFormatLine("PIVOT (SUM(Importe) FOR Impuesto_Importe IN ({0}))", campo_pivot.ToString().Trim(","c))
         Else
            .AppendFormatLine("PIVOT (SUM(IVA) FOR Impuesto_Importe IN ({0}))", campo_pivot.ToString().Trim(","c))
         End If
         .AppendLine("AS VIP")

         Select Case agrupadoPor
            Case Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.Descripcion, VIP.Letra")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.Descripcion, VIP.Letra")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreCategoriaFiscal")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreCategoriaFiscal")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroCompra
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreRubro")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreRubro")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreRubro")
            Case Else
               Throw New ArgumentOutOfRangeException(String.Format("Método de agrupado {0} no definido.", agrupadoPor))
         End Select


      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetResumenDeComprasDetalle(sucursales As Entidades.Sucursal(),
                                       idEmpresa As Integer,
                                       periodoFiscalDesde As Integer,
                                       periodoFiscalHasta As Integer,
                                       grabaLibro As String,
                                       afectaCaja As String,
                                       esComercial As String,
                                       informaLibroIva As String,
                                       agrupadoPorSucursal As Boolean,
                                       agrupadoPor As Entidades.ResumenDeVenta_AgrupadoPor,
                                       separarNetos As Boolean,
                                       tiposDeComprobantes As Entidades.TipoComprobante(),
                                       rubrosCompra As Entidades.RubroCompra(),
                                       categoriaFiscales As Entidades.CategoriaFiscal()) As DataTable
      Dim nombreCampo As String
      nombreCampo = "'____' + CASE WHEN I.IdTipoImpuesto = 'IVA' THEN I.IdTipoImpuesto + '_' + 'IVA' + '_' + REPLACE(CONVERT(VARCHAR(MAX), I.Alicuota), '.', '#') ELSE I.IdTipoImpuesto + '_' + TI.NombreTipoImpuesto END"
      Dim nombreCampoNetoGravado As String = "'____IVA_NetoGravado_' + REPLACE(CONVERT(VARCHAR(MAX), I.Alicuota), '.', '#')"

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT DISTINCT * FROM (")
         .AppendFormatLine("SELECT TOP 100 PERCENT QUOTENAME({0}) campo", nombreCampo)
         .AppendLine("  FROM Impuestos I")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = I.IdTipoImpuesto")
         .AppendLine(" WHERE (I.IdTipoImpuesto <> 'IVA' OR I.Alicuota <> 0)")
         .AppendLine("   AND TI.Tipo IN ('IVA', 'PERCEPCION', 'INTERNO')")
         .AppendLine(" ORDER BY CASE WHEN I.IdTipoImpuesto = 'IVA' THEN 0 ELSE 1 END, I.IdTipoImpuesto, Alicuota")
         .AppendLine(") T")
      End With
      Dim dtCampos As DataTable = GetDataTable(stb.ToString())

      '# Campos de Neto Gravado separados
      stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT QUOTENAME({0}) campo", nombreCampoNetoGravado)
         .AppendLine("  FROM Impuestos I")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = I.IdTipoImpuesto")
         .AppendLine(" WHERE (I.IdTipoImpuesto <> 'IVA' OR I.Alicuota <> 0)")
         .AppendLine("   AND TI.Tipo IN ('IVA')")
         .AppendLine(" ORDER BY CASE WHEN I.IdTipoImpuesto = 'IVA' THEN 0 ELSE 1 END, I.IdTipoImpuesto, Alicuota")
      End With
      Dim dtCamposNetoGravadosSeparados As DataTable = GetDataTable(stb.ToString())

      Dim campo_pivot As StringBuilder = New StringBuilder()
      Dim campo_pivot_netoGravado As StringBuilder = New StringBuilder()
      Dim campos_sum As StringBuilder = New StringBuilder()
      Dim campos_total As StringBuilder = New StringBuilder()

      Dim camposExistentes As List(Of String) = New List(Of String)()

      For Each drCampos As DataRow In dtCampos.Rows
         If Not camposExistentes.Contains(drCampos("campo").ToString()) Then
            campo_pivot.AppendFormat("{0},", drCampos("campo"))
            campos_sum.AppendFormatLine(", SUM(ISNULL({0}, 0)) AS {0}", drCampos("campo"))
            campos_total.AppendFormat(" + ISNULL({0}, 0)", drCampos("campo"))
            camposExistentes.Add(drCampos("campo").ToString())
         End If
      Next

      '# Campos de Neto Gravado
      If separarNetos Then
         For Each gravCampos As DataRow In dtCamposNetoGravadosSeparados.Rows
            If Not camposExistentes.Contains(gravCampos("campo").ToString()) Then
               campo_pivot_netoGravado.AppendFormat("{0},", gravCampos("campo"))
               campos_sum.AppendFormatLine(", SUM(ISNULL({0}, 0)) AS {0}", gravCampos("campo"))
               campos_total.AppendFormat(" + ISNULL({0}, 0)", gravCampos("campo"))
               camposExistentes.Add(gravCampos("campo").ToString())
            End If
         Next
      End If

      stb = New StringBuilder()

      With stb
         .AppendLine("SELECT VIP.NombreSucursal ,VIP.Descripcion,VIP.Letra ,VIP.NombreCategoriaFiscal ,VIP.NombreRubro")
         .AppendLine("      ,SUM(VIP.NetoNoGravado) NetoNoGravado")
         .AppendLine("      ,SUM(VIP.NetoGravado) Neto")
         .AppendLine(campos_sum.ToString())
         If separarNetos Then
            .AppendFormatLine("      ,SUM(VIP.NetoNoGravado  {0}) Total", campos_total)
         Else
            .AppendFormatLine("      ,SUM(VIP.NetoNoGravado + VIP.NetoGravado {0}) Total", campos_total)
         End If
         .AppendLine("      ,SUM(CASE WHEN VIP.DerechoAduanero IS NULL THEN 0 ELSE VIP.DerechoAduanero END) DerechoAduanero")

         .AppendFormatLine("  FROM (SELECT {0} AS Impuesto_Importe", nombreCampo)
         If separarNetos Then .AppendFormatLine("              ,{0} AS NetoGravadoSeparado", nombreCampoNetoGravado)
         .AppendLine("              ,VI.*")
         .AppendLine("              ,CASE WHEN VI.Alicuota =  0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.BaseImponible ELSE 0 END NetoNoGravado")
         .AppendLine("              ,CASE WHEN VI.Alicuota <> 0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.BaseImponible ELSE 0 END NetoGravado")
         If separarNetos Then .AppendLine("              ,CASE WHEN VI.Alicuota <> 0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.BaseImponible ELSE 0 END NetoGravado1")
         If agrupadoPorSucursal Then
            .AppendLine("              ,S.Nombre NombreSucursal")
         Else
            .AppendLine("              ,'' NombreSucursal")
         End If

         .AppendLine("              ,TC.Descripcion")
         .AppendLine("              ,CF.NombreCategoriaFiscal")
         .AppendLine("              ,CAT.NombreRubro")
         .AppendLine("              ,V.DerechoAduanero")
         .AppendLine("          FROM ComprasImpuestos VI")

         .AppendLine("         INNER JOIN Compras V ON VI.IdSucursal = V.IdSucursal")
         .AppendLine("                            AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                            AND VI.Letra = V.Letra")
         .AppendLine("                            AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("                            AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("                            AND VI.IdProveedor = V.IdProveedor")
         .AppendLine("         INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")

         .AppendLine("         INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
         .AppendLine("         INNER JOIN Impuestos I ON I.IdTipoImpuesto = VI.IdTipoImpuesto AND I.Alicuota = VI.Alicuota")
         .AppendLine("         INNER JOIN Sucursales S ON VI.IdSucursal = S.IdSucursal")
         .AppendLine("         INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal")
         .AppendLine("         INNER JOIN RubrosCompras CAT ON V.IdRubro = CAT.IdRubro")
         .AppendLine("         WHERE 1 = 1")
         .AppendLine("           AND VI.EsDespacho = 0")

         If periodoFiscalDesde > 0 And periodoFiscalHasta > 0 Then
            .AppendLine("	 AND S.IdEmpresa = " & idEmpresa.ToString())
            .AppendLine("	 AND V.PeriodoFiscal >= " & periodoFiscalDesde.ToString())
            .AppendLine("	 AND V.PeriodoFiscal <= " & periodoFiscalHasta.ToString())
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         If esComercial <> "TODOS" Then
            .AppendLine("      AND TC.EsComercial = " & IIf(esComercial = "SI", "1", "0").ToString())
         End If

         If informaLibroIva <> "TODOS" Then
            .AppendLine("      AND TC.InformaLibroIva = " & IIf(informaLibroIva = "SI", "1", "0").ToString())
         End If

         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
            .AppendLine("          AND TI.Tipo IN ('IVA', 'PERCEPCION', 'INTERNO')")
         End If

         GetListaTiposComprobantesMultiples(stb, tiposDeComprobantes, "TC")
         GetListaRubrosComprasMultiples(stb, rubrosCompra, "CAT")
         GetListaCategoriasFiscalesMultiples(stb, categoriaFiscales, "CF")

         .AppendLine(" ) AS VI ")

         '# Separo los Neto Gravado por alícuotas
         If separarNetos Then
            .AppendFormatLine("PIVOT (SUM(NetoGravado1) FOR NetoGravadoSeparado IN ({0}))", campo_pivot_netoGravado.ToString().Trim(","c))
            .AppendLine("AS NGS")
         End If

         .AppendFormatLine("PIVOT (SUM(Importe) FOR Impuesto_Importe IN ({0}))", campo_pivot.ToString().Trim(","c))
         .AppendLine("AS VIP")

         .AppendLine("  GROUP BY VIP.NombreSucursal, VIP.Descripcion, VIP.Letra, VIP.NombreCategoriaFiscal, VIP.NombreRubro")
         .AppendLine("  ORDER BY VIP.NombreSucursal, VIP.Descripcion, VIP.Letra, VIP.NombreCategoriaFiscal, VIP.NombreRubro")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetComprasHolistorAExportar(fechaDesde As Date,
                                               fechaHasta As Date,
                                               idProveedor As Long,
                                               sucursales As Entidades.Sucursal(),
                                               tiposDeComprobantes As Entidades.TipoComprobante()) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("SELECT  ")
         .AppendFormatLine("	C.IdSucursal,")
         .AppendFormatLine("	C.Fecha,")
         .AppendFormatLine("	ATCTC.IdAFIPTipoComprobante,")
         .AppendFormatLine("	ATD.IdAFIPTipoDocumento,")
         .AppendFormatLine("	C.IdTipoComprobante,")
         .AppendFormatLine("	TC.DescripcionAbrev,")
         .AppendFormatLine("	C.Letra,")
         .AppendFormatLine("	C.CentroEmisor,")
         .AppendFormatLine("	C.NumeroComprobante,")
         .AppendFormatLine("	C.IdProveedor,")
         .AppendFormatLine("	C.NombreProveedor,")
         .AppendFormatLine("	PR.TipoDocProveedor,")
         .AppendFormatLine("	PR.CuitProveedor,")
         .AppendFormatLine("	PR.DireccionProveedor,")
         .AppendFormatLine("	PR.IdLocalidadProveedor,")
         .AppendFormatLine("	LOC.NombreLocalidad,")
         .AppendFormatLine("	PROV.IdAFIPProvincia,")
         .AppendFormatLine("	PR.IdCategoriaFiscal,")
         .AppendFormatLine("	CF.NombreCategoriaFiscal,")
         .AppendFormatLine("	--CodNeto,") '# Comentada
         .AppendFormatLine("	CI.BaseImponible,")
         .AppendFormatLine("	CI.Importe,")
         .AppendFormatLine("	CI.Alicuota,")
         .AppendFormatLine("	--Cod NG EX,") '# Comentada
         .AppendFormatLine("	--Conceptos NG EX,	") '# Comentada
         .AppendFormatLine("	C.ImpuestosInternos,")
         .AppendFormatLine("	(C.PercepcionIVA + C.PercepcionIB + C.PercepcionGanancias + C.PercepcionVarias) TotalPercepciones,")
         .AppendFormatLine("	C.ImporteTotal Total")
         .AppendFormatLine("FROM Compras C")
         .AppendFormatLine("	LEFT JOIN Proveedores PR ON C.IdProveedor = PR.IdProveedor")
         .AppendFormatLine("	LEFT JOIN Localidades LOC ON PR.IdLocalidadProveedor = LOC.IdLocalidad")
         .AppendFormatLine("	LEFT JOIN Provincias PROV ON LOC.IdProvincia = PROV.IdProvincia")
         .AppendFormatLine("	LEFT JOIN TiposComprobantes TC ON  C.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendFormatLine("	LEFT JOIN TiposComprobantesPDA TC1 ON TC1.IdTipoComprobante = C.IdTipoComprobante AND TC1.Letra = C.Letra")
         .AppendFormatLine("	LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON C.IdTipoComprobante = ATCTC.IdTipoComprobante AND C.Letra = ATCTC.Letra")
         .AppendFormatLine("	LEFT JOIN AFIPTiposComprobantes ATC ON ATC.IdAFIPTipoComprobante = ATCTC.IdAFIPTipoComprobante")
         .AppendFormatLine("	LEFT JOIN AFIPTiposdocumentos ATD ON ATD.TipoDocumento = PR.TipoDocProveedor")
         .AppendFormatLine("	INNER JOIN Sucursales S ON C.IdSucursal = S.IdSucursal")
         .AppendFormatLine("	INNER JOIN CategoriasFiscales CF ON PR.IdCategoriaFiscal = CF.IdCategoriaFiscal")
         .AppendFormatLine("	INNER JOIN ComprasProductos CP ON C.IdTipoComprobante = CP.IdTipoComprobante")
         .AppendFormatLine("								  AND C.Letra = CP.Letra")
         .AppendFormatLine("								  AND C.CentroEmisor = CP.CentroEmisor")
         .AppendFormatLine("								  AND C.NumeroComprobante = CP.NumeroComprobante")
         .AppendFormatLine("								  AND C.IdProveedor = CP.IdProveedor")
         .AppendFormatLine("	INNER JOIN ComprasImpuestos CI ON CP.IdTipoComprobante = CI.IdTipoComprobante")
         .AppendFormatLine("								  AND CP.Letra = CI.Letra")
         .AppendFormatLine("								  AND CP.CentroEmisor = CI.CentroEmisor")
         .AppendFormatLine("								  AND CP.NumeroComprobante = CI.NumeroComprobante")
         .AppendFormatLine("								  AND CP.IdProveedor = CI.IdProveedor")
         .AppendFormatLine("								  AND CP.Orden = CI.Orden")
         .AppendFormatLine("								  AND CI.IdTipoImpuesto = 'IVA'")
         .AppendFormatLine(" WHERE 1=1 ")
         .AppendFormatLine("	AND C.Fecha >= '{0}'", ObtenerFecha(fechaDesde, True))
         .AppendFormatLine("	AND C.Fecha <= '{0}'", ObtenerFecha(fechaHasta, True))

         GetListaSucursalesMultiples(query, sucursales, "S")

         GetListaTiposComprobantesMultiples(query, tiposDeComprobantes, "TC")

         .AppendFormatLine("ORDER BY C.Fecha DESC")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetModificacionCompras(sucursal As Integer,
                                          desde As Date,
                                          hasta As Date,
                                          idProveedor As Long,
                                          tipoComprobante As String,
                                          idEmpresa As Integer,
                                          periodoFiscal As Integer,
                                          nivelAutorizacionMaximo As Short) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT S.IdEmpresa")
         .AppendLine("      ,C.PeriodoFiscal")
         .AppendLine("      ,C.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev AS NombreTipoComprobante")
         .AppendLine("      ,C.Letra")
         .AppendLine("      ,C.CentroEmisor")
         .AppendLine("      ,C.NumeroComprobante")
         .AppendLine("      ,C.Fecha")
         .AppendLine("      ,C.IdComprador")
         .AppendLine("      ,C.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,C.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago AS FormaDePago")
         .AppendLine("      ,C.DescuentoRecargo")

         .AppendLine("      ,C.IVAModificadoManual")

         .AppendLine("      ,C.PercepcionIVA")
         .AppendLine("      ,C.PercepcionIB")
         .AppendLine("      ,C.PercepcionGanancias")
         .AppendLine("      ,C.PercepcionVarias")
         .AppendLine("      ,C.ImpuestosInternos")
         .AppendLine("      ,C.ImporteTotal")
         .AppendLine("      ,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal")
         .AppendLine("      ,P.CuitProveedor AS Cuit")
         .AppendLine("      ,C.Observacion")

         .AppendLine("      ,C.TotalBruto")
         .AppendLine("      ,C.TotalNeto")
         .AppendLine("      ,C.TotalIVA")
         .AppendLine("      ,C.TotalPercepciones")

         .AppendLine("   FROM Compras C")
         .AppendLine("   INNER JOIN Proveedores P ON C.IdProveedor = P.IdProveedor ")
         .AppendLine("   INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal=CF.IdCategoriaFiscal ")
         .AppendLine("   INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante ")
         .AppendLine("   INNER JOIN VentasFormasPago VFP ON VFP.IdFormasPago = C.IdFOrmasPago ")
         .AppendLine("   WHERE C.IdSucursal = " & sucursal.ToString())

         .AppendFormatLine("    AND P.NivelAutorizacion <= {0} AND TC.NivelAutorizacion <= {0}", nivelAutorizacionMaximo)

         .AppendLine("     AND CONVERT(varchar(11), C.fecha, 120) >= '" & Strings.Format(desde, "yyyy-MM-dd") & "'")
         .AppendLine("     AND CONVERT(varchar(11), C.fecha, 120) <= '" & Strings.Format(hasta, "yyyy-MM-dd") & "'")

         If idProveedor > 0 Then
            .Append("	AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If Not String.IsNullOrEmpty(tipoComprobante) Then
            .Append("	AND C.IdTipoComprobante = '" & tipoComprobante & "'")
         End If

         If periodoFiscal > 0 Then
            .AppendLine("	  AND C.IdEmpresa = " & idEmpresa.ToString())
            .AppendLine("	  AND C.PeriodoFiscal = " & periodoFiscal.ToString())
         End If

         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         .AppendLine("	ORDER BY CONVERT(varchar(11), C.fecha, 120), ")
         .AppendLine("     C.IdTipoComprobante, ")
         .AppendLine("     C.Letra, ")
         .AppendLine("     C.CentroEmisor, ")
         .AppendLine("     C.NumeroComprobante")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function ProveedorPoseeFacturas(idProveedor As Long, grabaLibro As Boolean?) As Boolean

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS ExisteCompra")
         .AppendFormatLine("     FROM COMPRAS C")
         .AppendFormatLine("     INNER JOIN TiposComprobantes TC ON  C.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine(" WHERE C.IdProveedor = '{0}'", idProveedor)
         If grabaLibro.HasValue Then
            .AppendFormatLine("   AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro.Value))
         End If
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
         Return True
      Else
         Return False
      End If

   End Function

   Public Sub ActualizaExcluirCompraDePasaje(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Integer,
                                             numeroComprobante As Long,
                                             idProveedor As Long,
                                             valor As Boolean)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE Compras SET")
         .AppendFormatLine("     ExcluirDePasaje = {0}", GetStringFromBoolean(valor))
         .AppendFormatLine(" WHERE 1=1")
         .AppendFormatLine(" AND IdSucursal = {0}", idSucursal)
         .AppendFormatLine(" AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine(" AND Letra = '{0}'", letra)
         .AppendFormatLine(" AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine(" AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine(" AND IdProveedor = {0}", idProveedor)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function Excluido(idSucursal As Integer,
                       idTipoComprobante As String,
                       letra As String,
                       centroEmisor As Integer,
                       numeroComprobante As Long,
                       idProveedor As Long) As Boolean
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT ExcluirDePasaje FROM Compras")
         .AppendFormatLine(" WHERE 1=1")
         .AppendFormatLine(" AND IdSucursal = {0}", idSucursal)
         .AppendFormatLine(" AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine(" AND Letra = '{0}'", letra)
         .AppendFormatLine(" AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine(" AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine(" AND IdProveedor = {0}", idProveedor)
      End With

      Dim dt As DataTable = Me.GetDataTable(query.ToString())
      Return Boolean.Parse(dt.Rows(0)(Entidades.Compra.Columnas.ExcluirDePasaje.ToString()).ToString())

   End Function

   Public Function GetComprasPagosMensuales(sucursales As IEnumerable(Of Entidades.Sucursal),
                                            fechaDesde As Date, fechaHasta As Date, idProveedor As Long,
                                            idCategoria As Integer,
                                            idUsuario As String, grabaLibro As Entidades.Publicos.SiNoTodos) As DataTable
      Dim fechaCorte = fechaHasta.Date.AddMonths(-12).AddDays(1)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT AnoFecha, MesFecha")
         .AppendFormatLine("     , SUM(Contado) Contado,                 SUM(CtaCte) CtaCte,                 SUM(Cobros) Cobros")
         .AppendFormatLine("     , SUM(Cobros) / NULLIF( SUM(CtaCte) , 0) * 100 PorcCobro")
         .AppendFormatLine("     , SUM(ContadoAnterior) ContadoAnterior, SUM(CtaCteAnterior) CtaCteAnterior, SUM(CobrosAnterior) CobrosAnterior")
         .AppendFormatLine("     , SUM(CobrosAnterior) / NULLIF( SUM(CtaCteAnterior) , 0) * 100 PorcCobroAnterior")
         .AppendFormatLine("     , ((SUM(Contado) / NULLIF( SUM(ContadoAnterior), 0)) - 1) * 100 ContadoPorc")
         .AppendFormatLine("     , ((SUM(CtaCte)  / NULLIF( SUM(CtaCteAnterior),  0)) - 1) * 100 CtaCtePorc")
         .AppendFormatLine("     , ((SUM(Cobros)  / NULLIF( SUM(CobrosAnterior),  0)) - 1) * 100 CobrosPorc")
         .AppendFormatLine("    FROM (")
         .AppendFormatLine("        SELECT YEAR(V.Fecha) + CASE WHEN V.Fecha < '{0}' THEN 1 ELSE 0 END AnoFecha", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , MONTH(V.Fecha) MesFecha")
         .AppendFormatLine("                , CASE WHEN V.Fecha > '{0}' THEN CASE WHEN FP.Dias = 0 THEN V.ImporteTotal ELSE 0 END ELSE 0 END Contado", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , CASE WHEN V.Fecha > '{0}' THEN CASE WHEN FP.Dias > 0 THEN V.ImporteTotal ELSE 0 END ELSE 0 END CtaCte", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , 0 Cobros")
         .AppendFormatLine("                , CASE WHEN V.Fecha < '{0}' THEN CASE WHEN FP.Dias = 0 THEN V.ImporteTotal ELSE 0 END ELSE 0 END ContadoAnterior", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , CASE WHEN V.Fecha < '{0}' THEN CASE WHEN FP.Dias > 0 THEN V.ImporteTotal ELSE 0 END ELSE 0 END CtaCteAnterior", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , 0 CobrosAnterior")
         .AppendFormatLine("            FROM Compras V")
         .AppendFormatLine("            INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")

         .AppendFormatLine("            INNER JOIN Proveedores C ON C.IdProveedor = V.IdProveedor")
         .AppendFormatLine("            INNER JOIN CategoriasProveedores CAT ON CAT.IdCategoria = C.IdCategoria")

         .AppendFormatLine("            INNER JOIN VentasFormasPago FP ON FP.IdFormasPago = V.IdFormasPago")
         .AppendFormatLine("            WHERE V.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))

         GetListaSucursalesMultiples(stb, sucursales, "V")

         If idProveedor <> 0 Then
            .AppendFormatLine("              AND V.IdProveedor = {0}", idProveedor)
         End If
         If idCategoria <> 0 Then
            .AppendFormatLine("              AND CAT.IdCategoria = {0}", idCategoria)
         End If
         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("              AND V.Usuario = '{0}'", idUsuario)
         End If
         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("              AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendFormatLine("              AND TC.EsComercial = 'True'")
         .AppendFormatLine("            UNION ALL")
         .AppendFormatLine("        SELECT YEAR(CC.Fecha) + CASE WHEN CC.Fecha < '{0}' THEN 1 ELSE 0 END AnoFecha", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , MONTH(CC.Fecha) MesFecha")
         .AppendFormatLine("                , 0 Contado")
         .AppendFormatLine("                , 0 CtaCte")
         .AppendFormatLine("                , CASE WHEN CC.Fecha > '{0}' THEN CC.ImporteTotal * - 1 ELSE 0 END Cobros", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("                , 0 ContadoAnterior")
         .AppendFormatLine("                , 0 CtaCteAnterior")
         .AppendFormatLine("                , CASE WHEN CC.Fecha < '{0}' THEN CC.ImporteTotal * - 1 ELSE 0 END CobrosAnterior", ObtenerFecha(fechaCorte, False))
         .AppendFormatLine("            FROM CuentasCorrientesProv CC")
         .AppendFormatLine("            INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")

         .AppendFormatLine("            INNER JOIN Proveedores C ON C.IdProveedor = CC.IdProveedor")
         .AppendFormatLine("            INNER JOIN CategoriasProveedores CAT ON CAT.IdCategoria = C.IdCategoria")

         .AppendFormatLine("            WHERE CC.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))

         GetListaSucursalesMultiples(stb, sucursales, "CC")

         If idProveedor <> 0 Then
            .AppendFormatLine("              AND CC.IdProveedor = {0}", idProveedor)
         End If
         If idCategoria <> 0 Then
            .AppendFormatLine("              AND CAT.IdCategoria = {0}", idCategoria)
         End If
         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("              AND CC.IdUsuario = '{0}'", idUsuario)
         End If
         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("              AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendFormatLine("              AND TC.EsRecibo = 'True' AND TC.EsAnticipo = 'False'")
         .AppendFormatLine("              AND TC.ImporteTope <> 0 AND TC.ImporteMinimo <> 0")
         .AppendFormatLine("        ) V")
         .AppendFormatLine("    GROUP BY AnoFecha, MesFecha")
         .AppendFormatLine("    ORDER BY AnoFecha DESC, MesFecha DESC")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetFacturablesPedidos(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                                         tiposComprobantes As List(Of String), idProveedor As Long,
                                         idListaPrecios As Integer, numeroOrdenCompra As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P.IdSucursal")
         .AppendFormatLine("     , P.IdTipoComprobante")
         .AppendFormatLine("     , P.Letra")
         .AppendFormatLine("     , P.CentroEmisor")
         .AppendFormatLine("     , P.NumeroPedido")
         .AppendFormatLine("     , P.IdProveedor")
         .AppendFormatLine("     , P.FechaPedido")
         .AppendFormatLine("     , P.Observacion")
         .AppendFormatLine("     , P.IdUsuario")
         .AppendFormatLine("     , P.IdFormasPago")
         .AppendFormatLine("     , P.NumeroOrdenCompra")
         .AppendFormatLine("     , P.DescuentoRecargoPorc")
         .AppendFormatLine("     , SUM(PP.ImporteTotal) as ImporteTotal")
         .AppendFormatLine("  FROM PedidosProveedores P")
         .AppendFormatLine(" INNER JOIN PedidosProductosProveedores PP")
         .AppendFormatLine("         ON PP.IdSucursal = P.IdSucursal")
         .AppendFormatLine("        AND PP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine("        AND PP.Letra = P.Letra")
         .AppendFormatLine("        AND PP.CentroEmisor = P.CentroEmisor")
         .AppendFormatLine("        AND PP.NumeroPedido = P.NumeroPedido")
         .AppendFormatLine(" INNER JOIN PedidosEstadosProveedores PE")
         .AppendFormatLine("         ON PE.IdSucursal = PP.IdSucursal")
         .AppendFormatLine("        AND PE.IdTipoComprobante = PP.IdTipoComprobante")
         .AppendFormatLine("        AND PE.Letra = PP.Letra")
         .AppendFormatLine("        AND PE.CentroEmisor = PP.CentroEmisor")
         .AppendFormatLine("        AND PE.NumeroPedido = PP.NumeroPedido")
         .AppendFormatLine("        AND PE.IdProducto = PP.IdProducto")
         .AppendFormatLine("        AND PE.Orden = PP.Orden")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = P.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN EstadosPedidosProveedores EPP ON EPP.IdEstado = PE.IdEstado AND EPP.TipoEstadoPedido = TP.Tipo")
         .AppendFormatLine(" WHERE P.IdSucursal = {0}", idSucursal)

         GetListaMultiples(stb, tiposComprobantes.ToArray(), "P", "IdTipoComprobante")

         If idProveedor > 0 Then
            .AppendFormatLine("   AND P.IdProveedor = {0}", idProveedor)
         End If

         .AppendFormatLine("   AND EPP.IdEstadoFacturado IS NOT NULL")

         .AppendFormatLine("   AND P.FechaPedido >= '{0}'", ObtenerFecha(fechaDesde, False))
         .AppendFormatLine("   AND P.FechaPedido <= '{0}'", ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))

         If numeroOrdenCompra <> 0 Then
            .AppendFormatLine("   AND P.NumeroOrdenCompra = {0}", numeroOrdenCompra)
         End If

         .AppendFormatLine(" GROUP BY P.IdSucursal, P.IdTipoComprobante, P.Letra, P.CentroEmisor, P.NumeroPedido, P.IdProveedor, P.FechaPedido, P.Observacion, P.IdUsuario, P.IdFormasPago, P.NumeroOrdenCompra, P.DescuentoRecargoPorc")
         .AppendFormatLine(" ORDER BY P.FechaPedido")  'Tiene la hora
      End With

      Return GetDataTable(stb)
   End Function
   Public Function GetFacturablesPedidosDetalle(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                                                tiposComprobantes As List(Of String), idProveedor As Long,
                                                idListaPrecios As Integer, numeroOrdenCompra As Long,
                                                blnPreciosConIVA As Boolean, pedidos As Entidades.Compra) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT PP.IdSucursal")
         .AppendFormatLine("      ,PP.IdTipoComprobante")
         .AppendFormatLine("      ,PP.Letra")
         .AppendFormatLine("      ,PP.CentroEmisor")
         .AppendFormatLine("      ,PP.NumeroPedido")
         .AppendFormatLine("      ,PP.IdProducto")
         .AppendFormatLine("      ,PR.CodigoProductoProveedor")
         .AppendFormatLine("      ,PP.Cantidad")
         .AppendFormatLine("      ,PP.Costo")
         .AppendFormatLine("      ,PP.CostoLista")

         If blnPreciosConIVA Then
            .AppendFormatLine("      ,ROUND((PS.PrecioCosto - P.ImporteImpuestoInterno) / (1+(P.Alicuota/100)+(P.PorcImpuestoInterno/100)),2) as PrecioCosto")
         Else
            .AppendFormatLine("      ,PS.PrecioCosto")
         End If

         .AppendFormatLine("      ,PP.ImporteTotal")
         .AppendFormatLine("      ,PP.NombreProducto")
         .AppendFormatLine("      ,PP.CantPendiente")
         .AppendFormatLine("      ,PP.CantEnProceso")
         .AppendFormatLine("      ,PP.CantEntregada")
         .AppendFormatLine("      ,PP.CantAnulada")

         .AppendFormatLine("      ,PP.DescuentoRecargoProducto")
         .AppendFormatLine("      ,PP.DescuentoRecargoPorc")
         .AppendFormatLine("      ,PP.DescuentoRecargoPorc2")

         .AppendFormatLine("      ,P.Alicuota                   AS AlicuotaProducto")
         .AppendFormatLine("      ,PP.AlicuotaImpuesto          AS AlicuotaPedido")

         .AppendFormatLine("      ,PP.ImporteImpuesto")
         .AppendFormatLine("      ,P.ImporteImpuestoInterno     AS ImporteImpuestoInternoProducto")
         .AppendFormatLine("      ,P.PorcImpuestoInterno        AS PorcImpuestoInternoProducto")
         .AppendFormatLine("      ,PP.PorcImpuestoInterno       AS PorcImpuestoInternoPedido")
         .AppendFormatLine("      ,PP.ImporteImpuestoInterno    AS ImporteImpuestoInternoPedido")
         .AppendFormatLine("      ,PE.CantAfectada AS CantParaFacturar")

         .AppendFormatLine("      ,PP.CantidadUMCompra")
         .AppendFormatLine("      ,PP.FactorConversionCompra")
         .AppendFormatLine("      ,PP.PrecioPorUMCompra")
         .AppendFormatLine("      ,PP.IdUnidadDeMedida")
         .AppendFormatLine("      ,PP.IdUnidadDeMedidaCompra")
         .AppendFormatLine("      ,(PP.CantidadUMCompra / PP.Cantidad) * PE.CantAfectada AS CantidadUMCParaFacturar")

         .AppendFormatLine("      ,PE.Orden")

         .AppendFormatLine(" FROM PedidosProductosProveedores PP ")

         .AppendFormatLine("  INNER JOIN (SELECT PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden")
         .AppendFormatLine("                   , SUM(PE.CantEstado) AS CantAfectada")
         .AppendFormatLine("                FROM PedidosEstadosProveedores PE")
         .AppendFormatLine("               INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendFormatLine("               INNER JOIN EstadosPedidosProveedores EPP ON EPP.IdEstado = PE.IdEstado AND EPP.TipoEstadoPedido = TP.Tipo")
         .AppendFormatLine("            WHERE 1 = 1")
         '.AppendFormatLine("                 AND PE.IdEstado = '{0}'", "PENDIENTE") ' pedidoProveedorEstadoAFacturar)
         .AppendFormatLine("                 AND EPP.IdEstadoFacturado IS NOT NULL")
         .AppendFormatLine("                 AND PE.IdEstado <> 'ANULADO'")
         .AppendFormatLine("                 AND PE.NumeroComprobanteFact IS NULL")
         .AppendFormatLine("                 AND PE.NumeroComprobanteRemito IS NULL")
         .AppendFormatLine("                 AND PE.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("                 AND PE.IdTipoComprobante = '{0}'", pedidos.TipoComprobante.IdTipoComprobante)
         .AppendFormatLine("                 AND PE.Letra = '{0}'", pedidos.Letra)
         .AppendFormatLine("                 AND PE.CentroEmisor = {0}", pedidos.CentroEmisor)
         .AppendFormatLine("                 AND PE.NumeroPedido = {0}", pedidos.NumeroComprobante)
         .AppendFormatLine("               GROUP BY PE.IdSucursal, PE.IdTipoComprobante, PE.Letra, PE.CentroEmisor, PE.NumeroPedido, PE.IdProducto, PE.Orden) PE")
         .AppendFormatLine("          ON PE.IdSucursal = PP.IdSucursal")
         .AppendFormatLine("         AND PE.IdTipoComprobante = PP.IdTipoComprobante")
         .AppendFormatLine("         AND PE.Letra = PP.Letra")
         .AppendFormatLine("         AND PE.CentroEmisor = PP.CentroEmisor")
         .AppendFormatLine("         AND PE.NumeroPedido = PP.NumeroPedido")
         .AppendFormatLine("         AND PE.IdProducto = PP.IdProducto")
         .AppendFormatLine("         AND PE.Orden = PP.Orden")

         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = PP.IdProducto")
         .AppendFormatLine(" INNER JOIN ProductosSucursales PS ON P.IdProducto = PS.IdProducto AND PS.IdSucursal = {0}", idSucursal)
         .AppendFormatLine(" LEFT JOIN ProductosProveedores PR ON P.IdProducto = PR.IdProducto AND PR.IdProveedor = {0}", idProveedor)
         '.AppendLine("  LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal")
         .AppendFormatLine(" WHERE PP.IdSucursal = {0}", idSucursal)

         .AppendFormatLine("   AND PP.IdTipoComprobante = '{0}'", pedidos.TipoComprobante.IdTipoComprobante)
         .AppendFormatLine("   AND PP.Letra = '{0}'", pedidos.Letra)
         .AppendFormatLine("   AND PP.CentroEmisor = {0}", pedidos.CentroEmisor)
         .AppendFormatLine("   AND PP.NumeroPedido = {0}", pedidos.NumeroComprobante)

         'If idListaPrecios <> 0 Then
         '.AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecios)
         'End If

      End With
      Return GetDataTable(stb)
   End Function

End Class