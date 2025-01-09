Public Class CuentasCorrientes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientes_I(idSucursal As Integer,
                                  idTipoComprobante As String,
                                  letra As String,
                                  centroEmisor As Integer,
                                  numeroComprobante As Long,
                                  fecha As Date,
                                  fechaVencimiento As Date,
                                  importeTotal As Double,
                                  idCliente As Long,
                                  IdVendedor As Integer,
                                  idFormasPago As Integer,
                                  observacion As String,
                                  saldo As Double,
                                  cantidadCuotas As Integer,
                                  importePesos As Decimal,
                                  importeDolares As Decimal,
                                  importeTickets As Decimal,
                                  importeTarjetas As Decimal,
                                  importeCheques As Decimal,
                                  importeTransfBancaria As Decimal,
                                  idCuentaBancaria As Integer,
                                  importeRetenciones As Decimal,
                                  idUsuario As String,
                                  idEstadoComprobante As String,
                                  fechaActualizacion As Date,
                                  idClienteCtaCte As Long,
                                  idCategoria As Integer,
                                  saldoCtaCte As Nullable(Of Decimal),
                                  metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                  idFuncion As String,
                                  imprimeSaldos As Boolean?,
                                  IdCobrador As Integer,
                                  idEstadoCliente As Integer,
                                  numeroOrdenCompra As Long,
                                  referencia As String,
                                  idSucursalVinculado As Integer,
                                  idTipoComprobanteVinculado As String,
                                  letraVinculado As String,
                                  centroEmisorVinculado As Short,
                                  numeroComprobanteVinculado As Long,
                                  cotizacionDolar As Decimal,
                                  fechaTransferencia As Date?,
                                  fechaExportacion As Date?,
                                  direccion As String,
                                  idlocalidad As Integer,
                                  numeroReparto As Integer?,
                                  idtipoNovedad As String,
                                  letraNovedad As String,
                                  centroEmisorNovedad As Short?,
                                  numeroNovedad As Long?,
                                  IdEmbarcacion As Long,
                                  fechaCalculoInteresModif As Boolean,
                                  fechaCalculoInteres As Date?,
                                  IdCama As Long,
                                  fechaPromedioCobro As Date?,
                                  promedioDiasCobro As Decimal?,
                                  cantidadDiasCobro As Decimal?)

      Dim myQuery = New StringBuilder()
      With myQuery
         .Append("INSERT INTO CuentasCorrientes")
         .Append("           (IdSucursal")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,Fecha")
         .Append("           ,FechaVencimiento")
         .Append("           ,ImporteTotal")
         .Append("           ,IdCliente")
         .Append("           ,IdVendedor")
         .Append("           ,IdFormasPago")
         .Append("           ,Observacion")
         .Append("           ,Saldo")
         .Append("           ,CantidadCuotas")
         .Append("           ,importePesos")
         .Append("           ,importeDolares")
         .Append("           ,ImporteTickets")
         .Append("           ,importeTarjetas")
         .Append("           ,importeCheques")
         .Append("           ,importeEuros")
         .Append("           ,importeTransfBancaria")
         .Append("           ,idCuentaBancaria")
         .Append("           ,importeRetenciones")
         .Append("           ,IdUsuario")
         .Append("           ,IdEstadoComprobante")
         .Append("           ,FechaActualizacion")
         .Append("           ,IdClienteCtaCte")
         .Append("           ,IdCategoria")
         .Append("           ,SaldoCtaCte")
         .Append("           ,MetodoGrabacion")
         .Append("           ,IdFuncion")
         .Append("           ,ImprimeSaldos")
         .Append("           ,IdCobrador")
         .Append("           ,IdEstadoCliente")
         .Append("           ,NumeroOrdenCompra")
         .Append("           ,Referencia")
         .Append("           ,IdSucursalVinculado")
         .Append("           ,IdTipoComprobanteVinculado")
         .Append("           ,LetraVinculado")
         .Append("           ,CentroEmisorVinculado")
         .Append("           ,NumeroComprobanteVinculado")
         .Append("           ,CotizacionDolar")
         .Append("           ,FechaTransferencia")
         .Append("           ,FechaExportacion")
         .Append("           ,Direccion")
         .Append("           ,Idlocalidad")
         .Append("           ,NumeroReparto")

         '-- REQ31710.- --------------------------------------------
         If numeroNovedad.HasValue Then
            .Append("           ,IdTipoNovedad")
            .Append("           ,LetraNovedad")
            .Append("           ,CentroEmisorNovedad")
            .Append("           ,NumeroNovedad")
         End If
         '-- REQ-33373.- -------------------------------------------
         .AppendFormatLine("    ,IdEmbarcacion")
         '-- REQ-31.- -------------------------------------------
         .AppendFormatLine("    ,FechaCalculoInteresModif")
         .AppendFormatLine("    ,FechaCalculoInteres")
         '-- REQ-36331.- -------------------------------------------
         .AppendFormatLine("    ,IdCama")
         '----------------------------------------------------------
         .Append("           ,FechaPromedioCobro")
         .Append("           ,PromedioDiasCobro")
         .Append("           ,CantidadDiasCobro")

         .Append(")     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,{0}", centroEmisor)
         .AppendFormat("           ,{0}", numeroComprobante)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fecha, True))
         If String.IsNullOrEmpty(fechaVencimiento.ToString()) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaVencimiento, True))
         End If
         .AppendFormat("           ,{0}", importeTotal.ToString())
         .AppendFormat("           ,{0}", idCliente)
         .AppendFormat("           ,{0}", IdVendedor)
         .AppendFormat("           ,{0}", idFormasPago)
         .AppendFormat("           ,'{0}'", observacion)
         .AppendFormat("           ,{0}", saldo)
         .AppendFormat("           ,{0}", cantidadCuotas)
         .AppendFormat("           ,{0}", importePesos)
         .AppendFormat("           ,{0}", importeDolares)
         .AppendFormat("           ,{0}", importeTickets)
         .AppendFormat("           ,{0}", importeTarjetas)
         .AppendFormat("           ,{0}", importeCheques)
         .AppendFormat("           ,0")
         .AppendFormat("           ,{0}", importeTransfBancaria)
         If idCuentaBancaria > 0 Then
            .AppendFormat("           ,{0}", idCuentaBancaria)
         Else
            .AppendLine("           ,NULL")
         End If
         .AppendFormat("           ,{0}", importeRetenciones)
         .AppendFormat("           ,'{0}'", idUsuario)
         .AppendFormat("           ,'{0}'", idEstadoComprobante)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaActualizacion, True))
         .AppendFormat("           ,{0}", idClienteCtaCte)
         .AppendFormat("           ,{0}", idCategoria)
         If saldoCtaCte.HasValue() Then
            .AppendFormat("           ,{0}", saldoCtaCte)
         Else
            .AppendLine("           ,NULL")
         End If
         .AppendFormat("           ,'{0}'", metodoGrabacion.ToString().Substring(0, 1))
         .AppendFormat("           ,'{0}'", idFuncion)
         If imprimeSaldos.HasValue Then
            .AppendFormat("           ,{0}", GetStringFromBoolean(imprimeSaldos.Value))
         Else
            .AppendLine("           ,NULL")
         End If
         If IdCobrador <> 0 Then
            .AppendFormat("           ,{0}", IdCobrador)
         Else
            .AppendLine("           ,NULL")
         End If
         If idEstadoCliente <> 0 Then
            .AppendFormat("           ,{0}", idEstadoCliente)
         Else
            .AppendLine("           ,NULL")
         End If
         If numeroOrdenCompra > 0 Then
            .AppendFormat("           ,{0}", numeroOrdenCompra)
         Else
            .AppendLine("           ,NULL")
         End If
         .AppendFormatLine("           ,'{0}'", referencia)

         .AppendFormatLine("           , {0} ", GetStringFromNumber(idSucursalVinculado))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(idTipoComprobanteVinculado))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(letraVinculado))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(centroEmisorVinculado))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(numeroComprobanteVinculado))
         .AppendFormatLine("           , {0} ", cotizacionDolar)

         If fechaTransferencia.HasValue Then
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaTransferencia.Value, False))
         Else
            .AppendLine("           ,NULL")
         End If
         If fechaExportacion.HasValue Then
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaExportacion.Value, False))
         Else
            .AppendLine("           ,NULL")
         End If
         .AppendFormat("           ,'{0}'", direccion)
         .AppendFormat("           , {0} ", idlocalidad)

         '# Número de Reparto
         If numeroReparto.HasValue AndAlso numeroReparto.Value <> 0 Then
            .AppendFormat("           ,{0}", numeroReparto.Value)
         Else
            .AppendLine("        ,NULL")
         End If
         '-- REQ31710.- --------------------------------------------
         If numeroNovedad.HasValue Then
            .AppendFormat("           ,'{0}'", idtipoNovedad)
            .AppendFormat("           ,'{0}'", letraNovedad)
            .AppendFormat("           , {0} ", centroEmisorNovedad)
            .AppendFormat("           , {0} ", numeroNovedad)
         End If
         '-- REQ-33373.- -------------------------------------------
         If IdEmbarcacion <> 0 Then
            .AppendFormat("   ,  {0} ", IdEmbarcacion).AppendLine()
         Else
            .AppendFormat("   , NULL").AppendLine()
         End If

         .AppendFormat("           , {0} ", GetStringFromBoolean(fechaCalculoInteresModif))
         If fechaCalculoInteres.HasValue Then
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaCalculoInteres.Value, False))
         Else
            .AppendLine("           ,NULL")
         End If
         '-- REQ-33373.- -------------------------------------------
         If IdCama <> 0 Then
            .AppendFormat("   ,  {0} ", IdCama).AppendLine()
         Else
            .AppendFormat("   , NULL").AppendLine()
         End If
         '-- REQ-42455.- -------------------------------------------
         If fechaPromedioCobro.HasValue Then
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaPromedioCobro.Value, False))
         Else
            .AppendLine("           ,NULL")
         End If
         If promedioDiasCobro.HasValue Then
            .AppendFormat("           ,{0}", promedioDiasCobro.Value)
         Else
            .AppendLine("        ,NULL")
         End If
         If cantidadDiasCobro.HasValue Then
            .AppendFormat("           ,{0}", cantidadDiasCobro.Value)
         Else
            .AppendLine("        ,NULL")
         End If
         '----------------------------------------------------------

         .Append(")")
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientes")

   End Sub

   Public Sub CuentasCorrientes_UImprimeSaldos(idCliente As Long,
                                               grupo As String,
                                               grabaLibro As Boolean?,
                                               fecha As Date,
                                               imprimeSaldos As Boolean?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE CuentasCorrientes")
         If imprimeSaldos.HasValue Then
            .AppendFormat("   SET ImprimeSaldos = {0}", GetStringFromBoolean(imprimeSaldos.Value))
         Else
            .AppendFormat("   SET ImprimeSaldos = NULL")
         End If
         .AppendFormat("  FROM CuentasCorrientes CC")
         .AppendFormat(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormat(" WHERE TC.EsRecibo = {0}", GetStringFromBoolean(True))
         .AppendFormat("   AND CC.IdCliente = {0}", idCliente)
         .AppendFormat("   AND TC.Grupo = '{0}'", grupo)
         If grabaLibro.HasValue Then
            .AppendFormat("   AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro.Value))
         End If
         .AppendFormat("   AND CC.Fecha > '{0}'", ObtenerFecha(fecha, True))

      End With
      Execute(myQuery)
   End Sub

   Public Sub CuentasCorrientes_AplicaAlSaldo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                              saldoNuevo As Double)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("UPDATE CuentasCorrientes")
         .AppendFormat("   SET Saldo = Saldo + {0}", saldoNuevo)
         .AppendFormat(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormat("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	and Letra = '{0}'", letra)
         .AppendFormat("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientes")

   End Sub

   Public Sub CuentasCorrientes_AnulaRecibo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                            idEstadoComprobante As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CuentasCorrientes ")
         .AppendLine("   SET ImporteTotal = 0 ")
         .AppendLine("      ,Saldo = 0 ")
         .AppendLine("      ,importePesos = 0 ")
         .AppendLine("      ,importeDolares = 0 ")
         .AppendLine("      ,ImporteTickets = 0 ")
         .AppendLine("      ,importeTarjetas = 0 ")
         .AppendLine("      ,importeCheques = 0 ")
         .AppendLine("      ,importeEuros = 0 ")
         .AppendLine("      ,importeRetenciones = 0 ")
         .AppendLine("      ,ImporteTransfBancaria = 0 ")
         .AppendLine("      ,IdCuentaBancaria = NULL ")
         .AppendLine("      ,Observacion = '***ANULADO***'")
         .AppendLine("    ,IdEstadoComprobante = '" & idEstadoComprobante & "'")

         .AppendFormat(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormat("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	and Letra = '{0}'", letra)
         .AppendFormat("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientes")
   End Sub
   Public Sub CuentasCorrientes_LimpiaFechaExportacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      CuentasCorrientes_U_FechaExportacion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, fechaActualizacion:=Nothing)
   End Sub

   Public Sub CuentasCorrientes_U_FechaExportacion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                                   fechaActualizacion As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientes ")
         If fechaActualizacion.HasValue Then
            .AppendFormatLine("   SET FechaExportacion = '{0}'", ObtenerFecha(fechaActualizacion.Value, True))
         Else
            .AppendFormatLine("   SET FechaExportacion = NULL")
         End If

         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and Letra = '{0}'", letra)
         .AppendFormatLine("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery.ToString())
   End Sub

   Public Sub CuentasCorrientes_ModificaRecibo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                               observacion As String,
                                               idCuentaBancaria As Integer?,
                                               fechaEmision As Date?,
                                               fechaTransferencia As Date?,
                                               idVendedor As Integer?,
                                               numeroOrdenCompra As Long?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientes ")
         .AppendFormatLine("   SET Observacion = '{0}'", observacion)
         'Si no tiene valor significa que no lo debo cambiar
         If idCuentaBancaria.HasValue Then
            If idCuentaBancaria.Value = 0 Then
               'Si es 0 significa que le tiene que poner NULL
               .AppendFormatLine("      ,IdCuentaBancaria = NULL")
            Else
               'Si es diferente a 0 grabo el valor
               .AppendFormatLine("      ,IdCuentaBancaria = {0}", idCuentaBancaria.Value)
            End If
         End If
         If fechaEmision.HasValue Then
            .AppendFormatLine("      ,Fecha = '{0}'", ObtenerFecha(fechaEmision.Value, True))
         End If
         If fechaTransferencia.HasValue Then
            .AppendFormatLine("      ,FechaTransferencia = '{0}'", ObtenerFecha(fechaTransferencia.Value, True))
         End If

         '-.PE-31462.-
         If idVendedor.HasValue Then
            .AppendFormatLine("        ,IdVendedor = {0}", idVendedor)
         End If

         If numeroOrdenCompra.HasValue Then
            .AppendFormatLine("        ,NumeroOrdenCompra = {0}", GetStringFromNumber(numeroOrdenCompra.Value))
         End If

         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("	 AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	 AND Letra = '{0}'", letra)
         .AppendFormatLine("	 AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	 AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientes")
   End Sub

   Public Sub CuentasCorrientes_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE CuentasCorrientes ")
         .AppendFormat(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormat("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	and Letra = '{0}'", letra)
         .AppendFormat("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientes")
   End Sub

   Public Function Existe(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT IdSucursal FROM CuentasCorrientes ")
         If idSucursal > 0 Then
            .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         Else
            .AppendLine(" WHERE IdSucursal > 0")
         End If
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Dim dt As DataTable = GetDataTable(stb)
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Function GetSaldoCliente(sucursales As Entidades.Sucursal(),
                                   idCliente As Long,
                                   fechaSaldo As Date,
                                   contemplaHora As Boolean,
                                   comprobantesAsociados As String,
                                   grabaLibro As Boolean?,
                                   comprobantesExcluidos As List(Of String),
                                   numeroComprobanteFinalizaCon As String,
                                   ctaCteClientesSeparar As Boolean,
                                   excluirPreComprobantes As Boolean,
                                   Idcama As Long,
                                   IdEmbarcacion As Long) As Decimal
      Dim stbQuery = New StringBuilder()
      With stbQuery
         'Se llama de destintas pantallas, necesita tomar uno u otro campo para cubrir todas las combinaciones.
         'Si esta vacio viene solo la hora y toma año 1.
         If fechaSaldo.Year > 1 Then      '
            .AppendLine("SELECT SUM(CC.ImporteTotal) AS Saldo FROM CuentasCorrientes CC")
         Else
            .AppendLine("SELECT SUM(CC.Saldo) AS Saldo FROM CuentasCorrientes CC")
         End If
         .AppendLine("  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" WHERE 1 = 1")

         SqlServer.Comunes.GetListaSucursalesMultiples(stbQuery, sucursales, "CC")

         .AppendLine("   AND CC.IdCliente = " & idCliente.ToString())
         .AppendLine("  AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO') ")
         '.AppendLine("   AND TC.EsRecibo = 'False'")
         '.AppendLine("   AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")

         If excluirPreComprobantes Then
            .AppendLine("   AND TC.EsPreElectronico = 'False'")
         End If

         If fechaSaldo.Year > 1 Then
            .AppendLine("    AND TC.EsAnticipo = 'False'")
            If contemplaHora Then
               .AppendLine("   AND CC.Fecha <= '" & fechaSaldo.ToString("yyyyMMdd HH:mm:ss") & "'")
            Else

               .AppendFormatLine(" AND CC.Fecha <= '{0}'", ObtenerFecha(fechaSaldo.UltimoSegundoDelDia(), True))

            End If
         Else
            .AppendLine("    AND TC.EsRecibo = 'False'")
         End If

         If Idcama <> 0 Then
            .AppendFormatLine(" AND CC.Idcama = {0}", Idcama)
         End If

         If IdEmbarcacion <> 0 Then
            .AppendFormatLine(" AND CC.IdEmbarcacion = {0}", IdEmbarcacion)
         End If

         'If GrabaLibro <> "TODOS" Then
         '   .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         'End If
         If comprobantesAsociados <> "TODOS" Then
            .AppendLine("     AND CC.IdTipoComprobante IN (" & comprobantesAsociados & ")")
         End If

         SqlServer.Comunes.GetListaMultiples(stbQuery, comprobantesExcluidos, "CC", "IdTipoComprobante", False)

         If Not String.IsNullOrWhiteSpace(numeroComprobanteFinalizaCon) Then
            .AppendFormatLine("     AND CC.NumeroComprobante LIKE '%{0}'", numeroComprobanteFinalizaCon)
         End If

         If ctaCteClientesSeparar And grabaLibro.HasValue Then
            If grabaLibro.Value Then
               .AppendLine(" AND TC.GrabaLibro = 'True'")
            Else
               .AppendLine(" AND TC.GrabaLibro = 'False'")
            End If
         End If

      End With

      Dim dt As DataTable = GetDataTable(stbQuery.ToString())
      Dim decSaldo As Decimal = 0
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Saldo").ToString()) Then
            decSaldo = Decimal.Parse(dt.Rows(0)("Saldo").ToString())
         End If
      End If

      Return decSaldo
   End Function

   Public Function GetSaldoClientes(suc As List(Of Integer)) As DataTable
      Dim sucur = String.Empty
      Dim entro = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT S.Nombre")
         .AppendLine("      ,SUM(CC.Saldo) as Saldo")
         .AppendLine("  FROM CuentasCorrientes CC")
         .AppendLine(" INNER JOIN Sucursales S on S.IdSucursal = CC.IdSucursal")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" WHERE CC.Saldo <> 0")
         '.AppendLine("   AND CC.IdTipoComprobante <> 'ANTICIPO' ")
         .AppendLine("   AND TC.EsAnticipo = 'False'")
         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat("   AND CC.IdSucursal = 0")
         Else
            .AppendFormat("   AND CC.IdSucursal IN ({0})", sucur)
         End If
         .AppendLine(" GROUP BY S.Nombre")

      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPagos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" Select CC.IdSucursal")
         .AppendLine(" ,CC.IdTipoComprobante")
         .AppendLine(" ,CC.Letra")
         .AppendLine(" ,CC.CentroEmisor")
         .AppendLine(" ,CC.NumeroComprobante")
         .AppendLine(" ,CC.Fecha")
         .AppendLine(" ,CC.FechaVencimiento")
         .AppendLine(" ,CCP.ImporteCuota AS ImporteTotal")
         .AppendLine(" ,CC.IdCliente")
         .AppendLine(" ,CC.IdFormasPago")
         .AppendLine(" ,CC.Observacion")
         .AppendLine(" ,CC.Saldo")
         .AppendLine(" ,CC.CantidadCuotas")
         .AppendLine(" ,CC.ImportePesos")
         .AppendLine(" ,CC.ImporteDolares")
         .AppendLine(" ,CC.ImporteTickets")
         .AppendLine(" ,CC.ImporteTarjetas")
         .AppendLine(" ,CC.ImporteCheques")
         .AppendLine(" ,CC.ImporteTransfbancaria")
         .AppendLine(" ,CC.ImporteRetenciones")
         .AppendLine(" ,CC.IdCuentaBancaria")
         .AppendLine(" ,CC.IdVendedor")
         .AppendLine(" ,CB.NombreEmpleado AS NombreVendedor")
         .AppendLine(" ,CC.IdCaja")
         .AppendLine(" ,CC.NumeroPlanilla")
         .AppendLine(" ,CC.NumeroMovimiento")
         .AppendLine("  ,CCP.CuotaNumero2 AS CuotaNumero")
         .AppendLine(" ,CC.IdCobrador")
         .AppendLine(" ,CO.NombreEmpleado as NombreCobrador")
         .AppendLine(" FROM CuentasCorrientes CC")
         .AppendLine(" INNER JOIN Empleados CB ON CB.IdEmpleado = CC.IdVendedor ")
         .AppendLine("  LEFT JOIN Empleados CO ON CO.IdEmpleado = CC.IdCobrador")
         .AppendLine(" INNER JOIN CuentasCorrientesPagos CCP on CC.IdSucursal = CCP.IdSucursal ")
         .AppendLine(" AND CC.IdTipoComprobante = CCP.IdTipoComprobante	")
         .AppendLine(" AND CC.Letra = CCP.Letra ")
         .AppendLine(" AND CC.CentroEmisor = CCP.CentroEmisor ")
         .AppendLine(" AND CC.NumeroComprobante = CCP.NumeroComprobante ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" where CCP.IdTipoComprobante2 = '" & idTipoComprobante & "'")
         .AppendLine(" AND CCP.Letra2 = '" & letra & "' ")
         .AppendLine(" AND CCP.CentroEmisor2 = " & centroEmisor)
         .AppendLine(" AND CCP.NumeroComprobante2 = " & numeroComprobante)
         .AppendLine("  AND TC.EsRecibo = 'True'")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetComprobantesCtaCteFecha(idSucursal As Integer,
                                              hasta As Date,
                                              idVendedor As Integer,
                                              idCliente As Long,
                                              idTipoComprobante As String,
                                              idZonaGeografica As String,
                                              idCategoria As Integer,
                                              grabaLibro As String,
                                              grupo As String,
                                              excluirAnticipos As String,
                                              excluirPreComprobantes As String,
                                              idProvincia As String,
                                              categoria As String,
                                              listaFormaDePago As Entidades.VentaFormaPago()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT '...' AS Ver")
         .AppendLine("      ,B.NombreVendedor ")
         .AppendLine("      ,B.CodigoCliente")
         .AppendLine("      ,B.NombreCliente ")
         .AppendLine("      ,B.NombreCategoria ")
         .AppendLine("      ,A.IdSucursal ")
         .AppendLine("      ,A.IdTipoComprobante2 ")
         .AppendLine("      ,A.Letra2 ")
         .AppendLine("      ,A.CentroEmisor2 ")
         .AppendLine("      ,A.NumeroComprobante2 ")
         .AppendLine("      ,B.FechaEmision ")
         .AppendLine("      ,A.ImporteTotal ")
         .AppendLine("      ,CASE WHEN B.GrabaLibro = 0 THEN 'NO' ELSE 'SI' END AS GrabaLibro")
         .AppendLine("      ,B.FormaDePago")
         .AppendLine("      ,B.Direccion") '-.PE-32329.-
         .AppendLine("      ,B.NombreLocalidad")
         .AppendLine("  FROM ")
         .AppendLine(" (SELECT CCP.IdSucursal ")
         .AppendLine("        ,CCP.IdTipoComprobante2 ")
         .AppendLine("        ,CCP.Letra2 ")
         .AppendLine("        ,CCP.CentroEmisor2 ")
         .AppendLine("        ,CCP.NumeroComprobante2 ")
         .AppendLine("        ,SUM(CCP.ImporteCuota) AS ImporteTotal ")
         .AppendLine("   FROM CuentasCorrientesPagos CCP ")
         '.AppendLine("  WHERE Convert(varchar(11), CCP.Fecha, 120)  <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         .AppendFormatLine("  WHERE CCP.Fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))
         .AppendLine("  GROUP BY CCP.IdSucursal ")
         .AppendLine("          ,CCP.IdTipoComprobante2 ")
         .AppendLine("          ,CCP.Letra2 ")
         .AppendLine("          ,CCP.CentroEmisor2 ")
         .AppendLine("          ,CCP.NumeroComprobante2 ")
         .AppendLine("  HAVING SUM(CCP.ImporteCuota) <> 0 ")
         .AppendLine(" ) A, ")
         .AppendLine(" (SELECT C.CodigoCliente ")
         .AppendLine("        ,C.NombreCliente ")
         .AppendLine("        ,Cat.NombreCategoria ")
         .AppendLine("        ,E.NombreEmpleado AS NombreVendedor")
         .AppendLine("        ,CC.IdSucursal ")
         .AppendLine("        ,CC.IdTipoComprobante ")
         .AppendLine("        ,CC.Letra ")
         .AppendLine("        ,CC.CentroEmisor ")
         .AppendLine("        ,CC.NumeroComprobante ")
         .AppendLine("        ,CONVERT(varchar(11), CC.Fecha, 103) AS FechaEmision ")
         .AppendLine("     	,TC.GrabaLibro")
         .AppendLine("        ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("        ,C.Direccion") '-.PE-32329.-
         .AppendLine("        ,L.NombreLocalidad")
         .AppendLine("  FROM CuentasCorrientes CC ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente ")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias Cat ON C.IdCategoria = Cat.IdCategoria ")
         Else
            .AppendLine("  INNER JOIN Categorias Cat ON CC.IdCategoria = Cat.IdCategoria ")
         End If

         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")

         .AppendLine(" INNER JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago ")

         .AppendLine("  WHERE CC.IdSucursal = " & idSucursal.ToString())

         If idVendedor > 0 Then
            .AppendLine("	AND C.IdVendedor = " & idVendedor)
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND CC.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         'El RECIBO tiene el saldo.
         If excluirAnticipos = "SI" Then
            .AppendLine("	AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         SqlServer.Comunes.GetListaMultiples(stb, listaFormaDePago, "CC")

         .AppendLine(") B ")
         .AppendLine(" WHERE A.IdSucursal = B.IdSucursal ")
         .AppendLine("   AND A.IdTipoComprobante2 = B.IdTipoComprobante ")
         .AppendLine("   AND A.Letra2 = B.Letra ")
         .AppendLine("   AND A.CentroEmisor2 = B.CentroEmisor ")
         .AppendLine("   AND A.NumeroComprobante2 = B.NumeroComprobante ")

         .AppendLine("ORDER BY B.NombreVendedor ")
         .AppendLine("        ,B.NombreCliente ")
         .AppendLine("        ,B.FechaEmision ")
         .AppendLine("        ,A.IdSucursal ")
         .AppendLine("        ,A.IdTipoComprobante2 ")
         .AppendLine("        ,A.Letra2 ")
         .AppendLine("        ,A.CentroEmisor2 ")
         .AppendLine("        ,A.NumeroComprobante2 ")
         .AppendLine("        ,B.FormaDePago")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetCtaCte(idSucursal As Integer,
                             desde As Date, hasta As Date,
                             idVendedor As Integer,
                             idCliente As Long,
                             listaComprobantes As List(Of Entidades.TipoComprobante),
                             saldo As String,
                             idZonaGeografica As String,
                             idCategoria As Integer,
                             grabaLibro As String,
                             grupos As Entidades.Grupo(),
                             excluirSaldosNegativos As String, excluirAnticipos As String, excluirPreComprobantes As String,
                             idProvincia As String,
                             categoria As String,
                             vendedor As String,
                             excluirMinutas As String,
                             sucursales As Entidades.Sucursal(),
                             agruparIdClienteCtaCte As Boolean,
                             nivelAutorizacion As Short,
                             ruta As Integer,
                             dia As Entidades.Publicos.Dias?,
                             idReserva As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal")
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("      ,C.IdVendedor")
         Else
            .AppendLine("      ,CC.IdVendedor")
         End If

         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreCliente +  ' ( ' + CONVERT(varchar(20), C.CodigoCliente)  + ' ) ' +  C.Direccion + ' - ' + L.NombreLocalidad + ' - ' + P.NombreProvincia + (CASE WHEN C.Cuit IS NULL THEN '' ELSE ' - ' + C.Cuit END) + ' - Tel: ' +(CASE WHEN C.Telefono IS NULL THEN '' ELSE ' - ' + C.Telefono END)  + ' ' + (CASE WHEN C.Celular IS NULL THEN '' ELSE ' - ' + C.Celular END) + (CASE WHEN C.CorreoElectronico IS NULL THEN '' ELSE ' - ' + C.CorreoElectronico END)  + (CASE WHEN T.NombreTransportista IS NULL THEN '' ELSE ' - ' + T.NombreTransportista  END) AS NombreCliente2")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,CC.IdTipoComprobante")
         .AppendLine("      ,LTRIM(TC.Descripcion) AS DescripcionTipoComprobante")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor")
         .AppendLine("      ,CC.NumeroComprobante")
         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,CC.FechaVencimiento")
         .AppendLine("      ,CC.ImporteTotal")
         .AppendLine("      ,CC.Saldo")
         .AppendLine("      ,CC.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")
         .AppendLine("      ,CC.Observacion")
         .AppendLine("      ,I.TipoImpresora")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,CC.IdEjercicio")
         .AppendLine("      ,CC.IdPlanCuenta")
         .AppendLine("      ,CC.IdAsiento")

         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.IdClienteCtaCte END IdClienteCtaCte")
         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.CodigoCliente END CodigoClienteCtaCte")
         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.NombreCliente END NombreClienteCtaCte")
         .AppendLine("      ,C.Telefono")
         .AppendLine("      ,TC.Grupo")
         If ruta > 0 OrElse dia.HasValue Then .AppendLine("      ,R.NombreRuta")

         .AppendLine("  FROM CuentasCorrientes CC")

         If Not agruparIdClienteCtaCte Then
            .AppendLine("  INNER JOIN Clientes C   ON C.IdCliente   = CC.IdCliente")
            .AppendLine("   LEFT JOIN Clientes CCC ON CCC.IdCliente = CC.IdClienteCtaCte")
         Else
            .AppendLine("  INNER JOIN Clientes C   ON C.IdCliente   = CC.IdClienteCtaCte")
            .AppendLine("   LEFT JOIN Clientes CCC ON CCC.IdCliente = CC.IdCliente")
         End If
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("  INNER JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         'Los Comprobantes Fictision pueden tener cualquier Emisor.
         .AppendLine(" LEFT OUTER JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND I.IdSucursal = " & idSucursal.ToString())
         '------------------
         .AppendLine(" LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")

         If ruta > 0 OrElse dia.HasValue Then
            .AppendFormatLine(" LEFT JOIN RutasClientes RC ON CC.IdCliente = RC.IdCliente")
            .AppendFormatLine(" INNER JOIN Rutas R ON RC.IdRuta = R.IdRuta")
         End If

         '-.PE-32388.-
         If idReserva > 0 Then
            .AppendFormatLine(" INNER JOIN ReservasTurismo RT ON CC.IdSucursal = RT.IdSucursal AND CC.Letra = RT.Letra AND CC.CentroEmisor = RT.CentroEmisor")
            .AppendFormatLine(" INNER JOIN ReservasTurismoPasajeros RTP ON RT.IdSucursal = RTP.IdSucursal AND RT.IdTipoReserva = RTP.IdTipoReserva AND RT.Letra = RTP.Letra AND RT.CentroEmisor = RTP.CentroEmisor AND RT.NumeroReserva = RTP.NumeroReserva ")
            .AppendFormatLine(" INNER JOIN ReservasTurismoPasajeros RTP2 ON CC.IdSucursal = RTP2.IdSucursal AND CC.IdTipoComprobante = RTP2.IdTipoComprobante AND CC.Letra = RTP2.Letra AND CC.CentroEmisor = RTP2.CentroEmisor AND CC.NumeroComprobante = RTP2.NumeroComprobante")
            .AppendFormatLine(" LEFT JOIN Clientes CRT ON RTP2.IdClientePasajero = CRT.IdCliente")
         End If

         .AppendLine("  WHERE 1=1")

         'TODO:
         If sucursales Is Nothing Then
            .AppendLine(" AND CC.IdSucursal = " & idSucursal.ToString())
         Else
            GetListaSucursalesMultiples(stb, sucursales, "CC")
         End If

         NivelAutorizacionCliente(stb, "C", "CAT", nivelAutorizacion)

         If desde.Year > 1 Then
            '.AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendFormatLine("  AND CC.Fecha >= '{0}'", ObtenerFecha(desde, False))
            '.AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
            .AppendFormatLine("  AND CC.Fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         .AppendLine("	AND TC.EsAnticipo = 'False'")

         .AppendLine("  AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO') ")

         If listaComprobantes IsNot Nothing AndAlso listaComprobantes.Count > 0 Then
            .Append(" AND CC.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               .AppendFormat(" '{0}',", tc.IdTipoComprobante)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If


         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If saldo <> "TODOS" Then
            .AppendLine("   AND CC.Saldo <> 0 ")
         End If

         GetListaMultiples(stb, grupos, "TC")

         If excluirSaldosNegativos = "SI" Then
            .AppendLine("   AND CC.Saldo > 0 ")
         End If

         'El RECIBO tiene el saldo.
         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsRecibo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If excluirMinutas = "SI" Then
            .AppendLine("  AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
         End If

         '# Filtros por Ruta y Dia
         If ruta > 0 OrElse dia.HasValue Then

            If ruta > 0 Then
               .AppendFormatLine("	AND RC.IdRuta = {0}", ruta)
            End If
            If dia.HasValue Then
               .AppendFormatLine("	AND RC.Dia = {0}", CInt(dia.Value))
            End If
         End If

         '-.PE-32388.-
         If idReserva > 0 Then
            .AppendLine(" AND RTP2.NumeroReserva ='" & idReserva & "'")
         End If

         If idReserva > 0 Then
            .AppendLine(" GROUP BY CC.IdSucursal")
            .AppendLine(" ,C.IdVendedor")
            .AppendLine(" ,E.NombreEmpleado")
            .AppendLine(" ,C.IdCliente")
            .AppendLine(" ,CRT.IdCliente")
            .AppendLine(" ,RTP2.NumeroReserva")
            .AppendLine(" ,C.CodigoCliente")
            .AppendLine(" ,C.NombreCliente")
            .AppendLine(" ,C.Direccion")
            .AppendLine(" ,C.Cuit")
            .AppendLine(" ,L.NombreLocalidad")
            .AppendLine(" ,P.NombreProvincia")
            .AppendLine(" ,C.Telefono")
            .AppendLine(" ,C.Celular")
            .AppendLine(" ,C.CorreoElectronico")
            .AppendLine(" ,T.NombreTransportista")
            .AppendLine(" ,C.NombreDeFantasia ")
            .AppendLine(" ,ZG.NombreZonaGeografica")
            .AppendLine(" ,CC.IdTipoComprobante")
            .AppendLine(" ,LTRIM(TC.Descripcion)")
            .AppendLine(" ,CC.Letra")
            .AppendLine(" ,CC.CentroEmisor")
            .AppendLine(" ,CC.NumeroComprobante")
            .AppendLine(" ,CC.Fecha")
            .AppendLine(" ,CC.FechaVencimiento")
            .AppendLine(" ,CC.ImporteTotal")
            .AppendLine(" ,CC.Saldo")
            .AppendLine(" ,CC.IdFormasPago")
            .AppendLine(" ,VFP.DescripcionFormasPago")
            .AppendLine(" ,CC.Observacion")
            .AppendLine(" ,I.TipoImpresora")
            .AppendLine(" ,CAT.NombreCategoria")
            .AppendLine(" ,CC.IdEjercicio")
            .AppendLine(" ,CC.IdPlanCuenta")
            .AppendLine(" ,CC.IdAsiento")
            .AppendLine(" ,CC.IdCategoria")
            .AppendLine(" ,CC.IdCliente")
            .AppendLine(" ,CC.IdClienteCtaCte")
            .AppendLine(" ,CCC.IdClienteCtaCte")
            .AppendLine(" ,CCC.CodigoCliente")
            .AppendLine(" ,CCC.NombreCliente")
            .AppendLine(" ,TC.Grupo")
         End If

         .AppendLine(" ORDER BY E.NombreEmpleado ")
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("   ,C.IdVendedor ")
         Else
            .AppendLine("   ,CC.IdVendedor ")
         End If
         .AppendLine("   ,C.NombreCliente ")
         .AppendLine("   ,C.IdCliente ")
         .AppendLine("   ,ZG.NombreZonaGeografica")
         .AppendLine("   ,CC.Fecha")
         '.AppendLine("   ,CC.IdTipoComprobante")   'La Fecha tiene hora, Minutos y segundos.
         '.AppendLine("   ,CC.Letra")
         '.AppendLine("   ,CC.CentroEmisor")
         '.AppendLine("   ,CC.NumeroComprobante")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetCtaCtePendientesPorProducto(
                        idSucursal As Integer,
                        desde As Date, hasta As Date,
                        idVendedor As Integer, idCliente As Long,
                        listaComprobantes As List(Of Entidades.TipoComprobante), saldo As String,
                        idZonaGeografica As String, idCategoria As Integer,
                        grabaLibro As String, grupos As Entidades.Grupo(),
                        excluirSaldosNegativos As String, excluirAnticipos As String, excluirPreComprobantes As String,
                        idProvincia As String, categoria As String, vendedor As String, excluirMinutas As String,
                        sucursales As Entidades.Sucursal(),
                        nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdVendedor ")
         .AppendLine("     , E.NombreEmpleado as NombreVendedor")
         '.AppendLine("--      COB.IdEmpleado,")
         '.AppendLine("--      COB.NombreCobrador,")
         '.AppendLine("      --Recibo")
         .AppendLine("     , CC.IdSucursal")
         .AppendLine("     , CC.IdTipoComprobante")
         .AppendLine("     , TC.Descripcion AS TipoComprobante")
         .AppendLine("     , CC.Letra")
         .AppendLine("     , CC.CentroEmisor")
         .AppendLine("     , CC.NumeroComprobante")
         .AppendLine("     , CC.Fecha")
         .AppendLine("     , CC.IdCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , CC.IdUsuario")
         '.AppendLine("       --Productos")
         .AppendLine("     , VP.IdProducto")
         .AppendLine("     , VP.NombreProducto	--Pudo cambiar la descripcion")
         .AppendLine("     , VP.Cantidad")
         .AppendLine("     , VP.PrecioNeto")
         .AppendLine("     , VP.ImporteTotalNeto")
         .AppendLine("     , VP.ComisionVendedorPorc")
         .AppendLine("     , VP.ComisionVendedor")
         .AppendLine("     , CC2.Saldo")
         .AppendLine("     , M.NombreMarca")
         .AppendLine("     , R.NombreRubro")
         .AppendLine("     , ROUND((VP.ImporteTotalNeto / V.SubTotal) * CC2.Saldo, 2) AS Saldo2")
         .AppendLine("     , SUM((ROUND(VP.ImporteTotalNeto,2) / V.SubTotal) * ((CCP.ImporteCuota * -1))  / (1 + (VP.AlicuotaImpuesto /100))) as ImporteTotalParcial")
         .AppendLine("     , V.NumeroOrdenCompra")

         .AppendLine("  FROM CuentasCorrientes CC ")
         .AppendLine(" INNER JOIN TiposComprobantes TC		--Mira los comprobantes tipo recibo.")
         .AppendLine("         ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("        AND TC.EsRecibo <> 'True'")
         .AppendLine(" INNER JOIN CuentasCorrientesPagos CCP	--Obtiene los comprobantes que se pagaron")
         .AppendLine("         ON ccp.IdSucursal = CC.IdSucursal ")
         .AppendLine("        AND ccp.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("        AND ccp.Letra = CC.Letra")
         .AppendLine("        AND ccp.CentroEmisor = CC.CentroEmisor")
         .AppendLine("        AND ccp.NumeroComprobante = CC.NumeroComprobante")
         .AppendLine(" INNER JOIN CuentasCorrientes CC2		--Controla el saldo de dichos comprobantes")
         .AppendLine("         ON CC2.IdSucursal = ccp.IdSucursal")
         .AppendLine("        AND CC2.IdTipoComprobante = ccp.IdTipoComprobante2")
         .AppendLine("        AND CC2.Letra = ccp.Letra2")
         .AppendLine("        AND CC2.CentroEmisor = ccp.CentroEmisor2")
         .AppendLine("        AND CC2.NumeroComprobante = ccp.NumeroComprobante2")
         .AppendLine("        AND CC2.Saldo <> CC2.ImporteTotal")
         .AppendLine(" INNER JOIN VentasProductos  VP")
         .AppendLine("         ON VP.IdSucursal = CC2.IdSucursal")
         .AppendLine("        AND VP.IdTipoComprobante = CC2.IdTipoComprobante")
         .AppendLine("        AND VP.Letra = CC2.Letra")
         .AppendLine("        AND VP.CentroEmisor = CC2.CentroEmisor")
         .AppendLine("        AND VP.NumeroComprobante = CC2.NumeroComprobante")
         .AppendLine(" INNER JOIN Ventas  V")
         .AppendLine("         ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("         AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("         AND VP.Letra = V.Letra")
         .AppendLine("         AND VP.CentroEmisor = V.CentroEmisor")
         .AppendLine("         AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendLine(" INNER JOIN Clientes C2 ON C2.IdCliente = cc2.IdCliente")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN TiposComprobantes TC2 ON TC2.IdTipoComprobante = CC2.IdTipoComprobante AND TC2.EsComercial = 'True'")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias PR ON PR.IdProvincia = L.IdProvincia")
         .AppendLine(" INNER JOIN Empleados E				--VendedorRecibo")
         .AppendLine("	       ON E.IdEmpleado = CC.IdVendedor")

         .AppendLine("  WHERE 1=1")

         'TODO:
         If sucursales Is Nothing Then
            .AppendLine(" AND CC.IdSucursal = " & idSucursal.ToString())
         Else
            SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "CC")
         End If

         '   NivelAutorizacionCliente(stb, "C", "CAT", nivelAutorizacion)

         If desde.Year > 1 Then
            '.AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            '.AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
            .AppendFormatLine("  AND CC.Fecha >= '{0}'", ObtenerFecha(desde, False))
            .AppendFormatLine("  AND CC.Fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         'If Categoria <> "MOVIMIENTO" Then
         '   .AppendLine(" AND C.IdCategoria = CC.IdCategoria")
         'End If

         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         .AppendLine("	AND TC.EsAnticipo = 'False'")

         .AppendLine("  AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO') ")

         If listaComprobantes IsNot Nothing AndAlso listaComprobantes.Count > 0 Then
            .Append(" AND CC.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               .AppendFormat(" '{0}',", tc.IdTipoComprobante)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If



         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If saldo <> "TODOS" Then
            .AppendLine("   AND CC.Saldo <> 0 ")
         End If

         GetListaMultiples(stb, grupos, "TC")

         'If excluirSaldosNegativos = "SI" Then
         '   .AppendLine("   AND CC.Saldo > 0 ")
         'End If

         ''El RECIBO tiene el saldo.
         'If excluirAnticipos = "SI" Then
         '   .AppendLine("      AND TC.EsRecibo = 'False'")
         'End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If excluirMinutas = "SI" Then
            .AppendLine("  AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
         End If

         .AppendLine(" GROUP BY CC.IdVendedor")
         .AppendLine("        , E.NombreEmpleado")
         .AppendLine("        , CC.IdSucursal")
         .AppendLine("        , CC.IdTipoComprobante")
         .AppendLine("        , TC.Descripcion")
         .AppendLine("        , CC.Letra")
         .AppendLine("        , CC.CentroEmisor")
         .AppendLine("        , CC.NumeroComprobante")
         .AppendLine("        , CC.Fecha")
         .AppendLine("        , CC.IdCliente")
         .AppendLine("        , C.NombreCliente")
         .AppendLine("        , CC.IdUsuario")
         .AppendLine("        , VP.IdProducto")
         .AppendLine("        , VP.NombreProducto")
         .AppendLine("        , VP.Cantidad")
         .AppendLine("        , VP.PrecioNeto")
         .AppendLine("        , VP.ImporteTotalNeto")
         .AppendLine("        , VP.ComisionVendedorPorc")
         .AppendLine("        , VP.ComisionVendedor")
         .AppendLine("        , CC2.Saldo")
         .AppendLine("        , M.NombreMarca")
         .AppendLine("        , R.NombreRubro")
         .AppendLine("        , V.NumeroOrdenCompra")
         .AppendLine("        , (VP.ImporteTotalNeto / V.SubTotal) * CC2.Saldo")
         .AppendLine(" ORDER BY CC.Fecha")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetRecibosAnulacion(sucursal As Integer,
                                       desde As Date,
                                       hasta As Date,
                                       idCliente As Long,
                                       idCategoria As Integer,
                                       idVendedor As Integer,
                                       idTipoComprobante As String,
                                       idUsuario As String,
                                       idCaja As Integer,
                                       letraFiscal As String,
                                       centroEmisor As Integer,
                                       numeroComprobante As Long,
                                       idZonaGeografica As String,
                                       nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT ")
         .AppendLine("	CC.IdSucursal, ")
         .AppendLine("	CC.IdCliente, ")
         .AppendLine("	C.CodigoCliente, ")
         .AppendLine("	C.NombreCliente, ")
         .AppendLine("  CN.NombreCaja, ")
         .AppendLine("	CC.IdTipoComprobante, ")
         .AppendLine("	CC.Letra, ")
         .AppendLine("	CC.CentroEmisor, ")
         .AppendLine("	CC.NumeroComprobante, ")
         .AppendLine("	CC.Fecha, ")
         .AppendLine("	CC.FechaVencimiento, ")
         .AppendLine("	CC.IdFormasPago, ")
         .AppendLine("	CC.ImporteTotal * (-1) as ImporteTotal, ")
         .AppendLine("	CC.Saldo, ")
         .AppendLine("	CC.CantidadCuotas, ")
         .AppendLine("	CC.ImportePesos, ")
         .AppendLine("	CC.ImporteTickets, ")
         .AppendLine("	CC.ImporteDolares, ")
         .AppendLine("	CC.ImporteEuros, ")
         .AppendLine("	CC.ImporteCheques, ")
         .AppendLine("	CC.ImporteTarjetas, ")
         .AppendLine("	CC.ImporteTransfBancaria, ")
         .AppendLine("	CB.NombreCuenta AS NombreCuentaBancaria, ")
         .AppendLine("	CB.IdMoneda AS IdMonedaCuentaBancaria, ")
         .AppendLine("	CC.ImporteRetenciones, ")
         .AppendLine("  CC.IdUsuario,")
         .AppendLine("  CC.IdEstadoComprobante,")
         .AppendLine("	CC.Observacion,")
         .AppendLine("  CC.FechaActualizacion,")
         .AppendLine("  ZG.NombreZonaGeografica,")
         .AppendLine("  CC.CotizacionDolar")

         .AppendLine("	FROM  CuentasCorrientes CC")

         .AppendLine(" LEFT JOIN CuentasBancarias CB ON CC.IdCuentaBancaria = CB.IdCuentaBancaria ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN CajasNombres CN ON CN.IdSucursal = CC.IdSucursal AND CN.IdCaja = CC.IdCaja")
         .AppendLine("  INNER JOIN Clientes C ON  CC.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  INNER JOIN Categorias CA ON CC.IdCategoria = CA.IdCategoria ")

         .AppendLine("  WHERE CC.IdSucursal = " & sucursal.ToString())

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         .AppendLine("    AND  TC.EsRecibo = 'True'")
         .AppendLine("   AND CC.IdEstadoComprobante <> 'ANULADO'")

         '.AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) >= '" & Desde.ToString("yyyy-MM-dd") & "'")
         '.AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")

         '.AppendLine("	  AND CC.Fecha >= '" & Desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         '.AppendLine("	  AND CC.Fecha <= '" & Hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         .AppendFormatLine("  AND CC.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("  AND CC.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If idVendedor > 0 Then
            .AppendLine("	 AND CC.IdVendedor = " & idVendedor)
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	 AND CC.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("   AND CC.IdUsuario = '" & idUsuario & "'")
         End If

         If idCaja > 0 Then
            .AppendLine("   AND CC.IdCaja = " & idCaja.ToString())
         End If

         If letraFiscal <> "" Then
            .AppendLine("	 AND CC.Letra = '" & letraFiscal.ToString() & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("	 AND CC.CentroEmisor = " & centroEmisor.ToString())
         End If

         If numeroComprobante > 0 Then
            .AppendLine("	 AND CC.NumeroComprobante = " & numeroComprobante.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         .AppendLine("	ORDER BY CC.Fecha")

      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetRecibosAnulados(sucursal As Integer, desde As Date, hasta As Date, idCliente As Long,
                                      nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal")
         .AppendLine("      ,CC.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,CC.IdTipoComprobante")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor")
         .AppendLine("      ,CC.NumeroComprobante")
         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,CC.FechaVencimiento")
         .AppendLine("	FROM CuentasCorrientes CC")
         .AppendLine("      LEFT JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("      LEFT JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("      INNER JOIN Categorias CA ON CC.IdCategoria = CA.IdCategoria ")
         .AppendLine("  WHERE  CC.IdSucursal = " & sucursal.ToString())

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         .AppendLine("        AND TC.EsRecibo = 'True'")
         .AppendLine("        AND CC.IdEstadoComprobante = 'ANULADO'")
         .AppendLine("	      AND CONVERT(varchar(11), CC.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	      AND CONVERT(varchar(11), CC.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If

         .AppendLine("	ORDER BY CC.Fecha")
         .AppendLine("	,CC.IdTipoComprobante")
         .AppendLine("	,CC.Letra")
         .AppendLine("	,CC.CentroEmisor")
         .AppendLine("	,CC.NumeroComprobante")

      End With
      Return GetDataTable(stb)
   End Function
   Public Sub ActualizoDatosCaja(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                 idCaja As Integer,
                                 numeroPlanilla As Integer,
                                 numeroMovimiento As Integer)
      Dim stb = New StringBuilder()
      With stb
         .Append("UPDATE CuentasCorrientes")
         .AppendFormat("	SET IdCaja = {0}, NumeroPlanilla = {1}, NumeroMovimiento = {2}", idCaja, numeroPlanilla, numeroMovimiento)
         .AppendFormat("	WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("	AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	AND Letra = '{0}'", letra)
         .AppendFormat("	AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "CuentasCorrientes")
   End Sub

   Public Sub ActualizoVendedorClienteCtaCte(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                             idVendedor As Integer,
                                             idCobrador As Integer,
                                             idClienteCtaCte As Long,
                                             referencia As String,
                                             idCategoria As Integer,
                                             fecha As Date?,
                                             observacion As String)
      Dim stb = New StringBuilder()
      With stb
         .Append("UPDATE CuentasCorrientes")
         .AppendFormat("	SET IdVendedor = {0}", idVendedor)
         If idCobrador > 0 Then
            .AppendFormat("      ,IdCobrador = {0}", idCobrador)
         Else
            .AppendFormat("      ,IdCobrador = {0}", "NULL")
         End If
         If idClienteCtaCte > 0 Then
            .AppendFormat("      ,IdClienteCtaCte = {0}", idClienteCtaCte)
         Else
            .AppendFormat("      ,IdClienteCtaCte = {0}", "NULL")
         End If
         If Not String.IsNullOrEmpty(referencia) Then
            .AppendFormat("      ,Referencia = '{0}'", referencia)
         Else
            .AppendFormat("      ,Referencia = {0}", "NULL")
         End If

         If idCategoria <> 0 Then
            .AppendFormat("     ,IdCategoria = {0}", idCategoria)
         End If

         If fecha.HasValue Then
            .AppendFormatLine("    ,Fecha = '{0}'", ObtenerFecha(fecha.Value, True))
         End If

         .AppendFormat("     ,Observacion = '{0}'", observacion) 'PE-31570

         .AppendFormat("	WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("	AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	AND Letra = '{0}'", letra)
         .AppendFormat("	AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "CuentasCorrientes")

   End Sub

   Private Sub SelectFiltrado(ByRef stb As StringBuilder)
      With stb
         .AppendLine("SELECT CC.*")
         .AppendLine("  FROM CuentasCorrientes CC")
      End With
   End Sub

   Public Function GetMovEliminar(idSucursal As Integer,
                                  desde As Date, hasta As Date,
                                  idVendedor As Integer, idCliente As Long,
                                  idTipoComprobante As String, idZonaGeografica As String,
                                  idCategoria As Integer, grabaLibro As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CONVERT(BIT, 0) Selec")
         .AppendLine("     , CC.IdSucursal ")
         .AppendLine("     , C.IdVendedor ")
         .AppendLine("     , E.NombreEmpleado as NombreVendedor ")
         .AppendLine("     , CC.IdCliente ")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , ZG.NombreZonaGeografica")
         .AppendLine("     , CC.IdTipoComprobante")
         .AppendLine("     , LTRIM(TC.Descripcion) AS DescripcionTipoComprobante")
         .AppendLine("     , CC.Letra")
         .AppendLine("     , CC.CentroEmisor")
         .AppendLine("     , CC.NumeroComprobante")
         .AppendLine("     , CC.Fecha")
         .AppendLine("     , CC.FechaVencimiento")
         .AppendLine("     , CC.ImporteTotal")
         .AppendLine("     , CC.Saldo")
         .AppendLine("     , CC.IdFormasPago")
         .AppendLine("     , VFP.DescripcionFormasPago")
         .AppendLine("     , CC.Observacion")
         .AppendLine("     , I.TipoImpresora")
         .AppendLine("  FROM CuentasCorrientes CC")
         .AppendLine("  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago")
         .AppendLine(" LEFT OUTER JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND I.IdSucursal = 1")
         .AppendLine(" LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")
         .AppendFormatLine(" WHERE CC.IdSucursal = {0}", idSucursal)

         If desde.Year > 1 Then
            .AppendFormatLine("   AND CC.Fecha >= '{0}'", ObtenerFecha(desde, False))
            .AppendFormatLine("   AND CC.Fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))
         End If

         If idVendedor > 0 Then
            .AppendFormatLine("   AND C.IdVendedor = {0}", idVendedor)
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("   AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCategoria > 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If

         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         .AppendFormatLine("   AND TC.EsRecibo = 'False' AND TC.EsAnticipo = 'False'")

         .AppendLine("  AND CC.ImporteTotal = CC.Saldo")
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND CC.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         'Es Mar Performante y no hace falta repetir los filtros.
         .AppendFormatLine("   AND NOT EXISTS")
         .AppendFormatLine("	     (SELECT IdSucursal")
         .AppendFormatLine("	        FROM Ventas V")
         .AppendFormatLine("	       WHERE V.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("	         AND V.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("	         AND V.Letra = CC.Letra")
         .AppendFormatLine("	         AND V.CentroEmisor = CC.CentroEmisor")
         .AppendFormatLine("	         AND V.NumeroComprobante = CC.NumeroComprobante")
         .AppendFormatLine("	         AND V.CentroEmisor = V.CentroEmisor)")
         .AppendFormatLine(" ORDER BY CC.Fecha")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetSaldosParaMinutas(idSucursal As Integer, comprobantesAsociados As String, grupo As String,
                                        fechaDesde As Date?, fechaHasta As Date?,
                                        numeroOrdenCompra As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendFormatLine("     , CCP.Positivo, CCP.Negativo, (CASE WHEN CCP.Positivo <= ABS(CCP.Negativo) THEN CCP.Positivo ELSE ABS(CCP.Negativo) END) AS Aplicado")
         .AppendFormatLine("  FROM Clientes C")
         .AppendFormatLine(" INNER JOIN (SELECT CC.IdCliente")
         .AppendFormatLine("                  , SUM(CASE WHEN ccp.SaldoCuota > 0 THEN ccp.SaldoCuota ELSE 0 END) as Positivo")
         .AppendFormatLine("                  , SUM(CASE WHEN ccp.SaldoCuota < 0 THEN ccp.SaldoCuota ELSE 0 END) as Negativo")
         .AppendFormatLine("               FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine("               INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal AND CC.IdTipoComprobante = CCP.IdTipoComprobante AND CC.Letra = CCP.Letra")
         .AppendFormatLine("                                              AND CC.CentroEmisor = CCP.CentroEmisor AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendFormatLine("               INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine("              WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("                AND CCP.IdTipoComprobante IN ({0})", comprobantesAsociados)
         .AppendFormatLine("                AND CCP.SaldoCuota <> 0")
         .AppendFormatLine("                AND TC.EsPreElectronico = 'False'")

         If fechaDesde.HasValue Then
            .AppendFormatLine("                AND CCP.Fecha > '{0}'", ObtenerFecha(fechaDesde.Value.Date, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("                AND CCP.Fecha < '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If
         If Not String.IsNullOrEmpty(grupo) Then
            .AppendFormatLine("                AND TC.Grupo = '{0}'", grupo)
         End If
         If numeroOrdenCompra <> 0 Then
            .AppendFormatLine("                AND CC.NumeroOrdenCompra = {0}", numeroOrdenCompra)
         End If

         .AppendFormatLine("              GROUP BY CC.IdCliente) AS CCP ON CCP.IdCliente = C.IdCliente")
         .AppendFormatLine(" WHERE CCP.Positivo <> 0 AND CCP.Negativo <> 0")
         .AppendFormatLine(" ORDER BY C.NombreCliente")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetAcuerdosRealizados(sucursales As Entidades.Sucursal(), fechaDesde As Date?, fechaHasta As Date?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("    With records  AS ( ")
         .AppendLine("  Select  GETDATE() as FechaEnvio, ")
         .AppendLine("          CCP.Fecha, C.CodigoCliente,")
         .AppendLine("          C.NombreCliente, CC.Referencia,")
         .AppendLine("          CC.Observacion, CCP.ImporteCuota, CC.CantidadCuotas, CC.IdUsuario , CCP.FechaVencimiento")
         .AppendLine("      ,ROW_NUMBER() OVER (PARTITION BY CC.IdCliente , CCP.IdSucursal , CCP.IdTipoComprobante ,CCP.Letra ,CCP.CentroEmisor ,CCP.NumeroComprobante ORDER BY C.NombreCliente  ")
         .AppendLine("                         ,C.CodigoCliente ")
         .AppendLine("                          ,CCP.Fecha) rn ")
         .AppendLine(" 	FROM CuentasCorrientesPagos CCP ")
         .AppendLine("   INNER JOIN CuentasCorrientes CC ON CCP.IdSucursal = CC.IdSucursal ")
         .AppendLine("   AND CCP.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendLine("   AND CCP.Letra = CC.Letra ")
         .AppendLine("   AND CCP.CentroEmisor = CC.CentroEmisor ")
         .AppendLine("   AND CCP.NumeroComprobante = CC.NumeroComprobante ")
         .AppendLine("   INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente ")
         .AppendLine("          WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "CC")
         If fechaDesde.HasValue Then
            .AppendFormat("     AND cc.Fecha > '{0}'", ObtenerFecha(fechaDesde.Value.Date, False)).AppendLine()
         End If
         If fechaHasta.HasValue Then
            .AppendFormat("     AND cc.Fecha < '{0}'", ObtenerFecha(fechaHasta.Value.Date.AddDays(1).AddSeconds(-1), True)).AppendLine()
         End If
         .AppendLine("  ) ")
         .AppendLine("  SELECT * ")
         .AppendLine("  FROM records ")
         .AppendLine("    WHERE RN = 1 ")
         .AppendLine("  ORDER BY  2 ")
      End With

      Return GetDataTable(stb)
   End Function


   Public Function GetAlgunosComprobantesPorCliente(idSucursal As Integer, idCliente As Long, algunosComprobantes As String, grupo As String,
                                                    fechaDesde As Date?, fechaHasta As Date?,
                                                    numeroOrdenCompra As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT * FROM CuentasCorrientesPagos CCP")
         .AppendLine("    INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal AND CC.IdTipoComprobante = CCP.IdTipoComprobante AND CC.Letra = CCP.Letra AND CC.CentroEmisor = CCP.CentroEmisor AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine("    INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine(" WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CCP.SaldoCuota <> 0")
         .AppendFormatLine("   AND CC.IdCliente = {0}", idCliente)
         .AppendFormatLine("   AND CCP.IdTipoComprobante IN ({0})", algunosComprobantes)
         .AppendFormatLine("   AND TC.EsPreElectronico = 'False'")
         If Not String.IsNullOrEmpty(grupo) Then
            .AppendFormatLine("   AND TC.Grupo = '{0}'", grupo)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("     AND CCP.Fecha > '{0}'", ObtenerFecha(fechaDesde.Value.Date, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("     AND CCP.Fecha < '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If
         If numeroOrdenCompra <> 0 Then
            .AppendFormatLine("   AND CC.numeroOrdenCompra = {0}", numeroOrdenCompra)
         End If

         .AppendLine(" ORDER BY CC.FechaVencimiento")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetParaImpresionMasiva(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                                          orden As String,
                                          idCliente As Long,
                                          idTipoComprobante As String, letra As String, centroEmisor As Short, nroDesde As Long, nroHasta As Long,
                                          idEstadoComprobante As String,
                                          grabaLibro As Entidades.Publicos.SiNoTodos, afectaCaja As Entidades.Publicos.SiNoTodos,
                                          idFormasPago As Integer, idUsuario As String, exportado As String,
                                          discIVA As Boolean, nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT '...' Ver")
         .AppendLine(" 	   , CONVERT(BIT, 0) Imprime")
         .AppendLine(" 	   , CC.IdSucursal")
         .AppendLine(" 	   , CC.IdCliente")
         .AppendLine(" 	   , C.CodigoCliente")
         .AppendLine(" 	   , C.NombreCliente")
         .AppendLine("     , CN.NombreCaja")
         .AppendLine(" 	   , CC.IdTipoComprobante")
         .AppendLine(" 	   , CC.Letra")
         .AppendLine(" 	   , CC.CentroEmisor")
         .AppendLine(" 	   , CC.NumeroComprobante")
         .AppendLine(" 	   , CC.Fecha")
         .AppendLine("	   , CONVERT(Date, CC.Fecha) AS Fecha_Fecha")
         .AppendLine("	   , CONVERT(Time, CC.Fecha) AS Fecha_Hora")
         .AppendLine(" 	   , CC.FechaVencimiento")
         .AppendLine(" 	   , CC.IdFormasPago")
         .AppendLine(" 	   , CC.ImporteTotal * (-1) as ImporteTotal")
         .AppendLine(" 	   , CC.Saldo")
         .AppendLine(" 	   , CC.CantidadCuotas")
         .AppendLine(" 	   , CC.ImportePesos")
         .AppendLine(" 	   , CC.ImporteTickets")
         .AppendLine(" 	   , CC.ImporteDolares")
         .AppendLine(" 	   , CC.ImporteEuros")
         .AppendLine(" 	   , CC.ImporteCheques")
         .AppendLine(" 	   , CC.ImporteTarjetas")
         .AppendLine(" 	   , CC.ImporteTransfBancaria")
         .AppendLine(" 	   , CB.NombreCuenta AS NombreCuentaBancaria")
         .AppendLine("     , CC.ImporteRetenciones")
         .AppendLine("     , CC.IdUsuario")
         .AppendLine("     , CC.IdEstadoComprobante")
         .AppendLine("     , CC.Observacion")
         .AppendLine("     , CC.FechaActualizacion")
         .AppendLine(" 	FROM CuentasCorrientes CC")
         .AppendLine("  LEFT JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND CC.IdSucursal = I.IdSucursal")
         .AppendLine("  LEFT JOIN TiposComprobantes TC ON  CC.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("  LEFT JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("  LEFT JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN CajasNombres CN ON CN.IdSucursal = CC.IdSucursal AND CN.IdCaja = CC.IdCaja")
         .AppendLine("  LEFT JOIN CuentasBancarias CB ON CC.IdCuentaBancaria = CB.IdCuentaBancaria ")
         .AppendLine(" INNER JOIN Categorias CA ON CC.IdCategoria = CA.IdCategoria ")

         .AppendFormatLine(" WHERE CC.IdSucursal = {0}", idSucursal)

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         .AppendFormatLine("   AND  TC.EsRecibo = 'True'")
         .AppendFormatLine("   AND CC.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))

         If idCliente > 0 Then
            .AppendFormatLine("	 AND C.IdCliente = {0}", idCliente)
         End If

         If Not String.IsNullOrEmpty(idEstadoComprobante) Then
            'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
            If idEstadoComprobante = "PENDIENTE" Then
               .AppendFormatLine("   AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante = 'INVOCO')")
            ElseIf idEstadoComprobante = "NO ANULADO" Then
               .AppendFormatLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")
            Else
               .AppendFormatLine("   AND CC.IdEstadoComprobante = '{0}'", idEstadoComprobante)
            End If
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND CC.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If Not String.IsNullOrEmpty(letra) Then
            .AppendFormatLine("   AND CC.Letra = '{0}'", letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND CC.CentroEmisor = {0}", centroEmisor)
         End If
         If nroDesde > 0 Then
            .AppendFormatLine("   AND CC.NumeroComprobante >= {0}", nroDesde)
         End If
         If nroHasta > 0 Then
            .AppendFormatLine("   AND CC.NumeroComprobante <= {0}", nroHasta)
         End If

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         If afectaCaja <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND TC.AfectaCaja = {0}", GetStringFromBoolean(afectaCaja = Entidades.Publicos.SiNoTodos.SI))
         End If

         If idFormasPago > 0 Then
            .AppendFormatLine("   AND CC.IdFormasPago = {0}", idFormasPago)
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("   AND CC.IdUsuario = '{0}'", idUsuario)
         End If
         If exportado = "SI" Then
            .AppendFormatLine("   AND CC.FechaExportacion IS NOT NULL")
         ElseIf exportado = "NO" Then
            .AppendFormatLine("   AND CC.FechaExportacion IS NULL")
         End If

         'Si Filtro por algun tipo de comprobantes.
         If Not String.IsNullOrEmpty(idTipoComprobante) Or Not String.IsNullOrEmpty(letra) Or centroEmisor > 0 Or nroDesde > 0 Or nroHasta > 0 Then
            .AppendFormatLine(" ORDER BY CC.CentroEmisor, CC.Letra, CC.NumeroComprobante")
         Else
            .AppendFormatLine(" ORDER BY CC.fecha")
         End If
         .AppendLine(orden)   'Asc o Desc
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetImpresionCuotasMasiva(idSucursal As Integer,
                                            fechaDesde As Date,
                                            fechaHasta As Date,
                                            orden As String,
                                            idCliente As Long,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Short,
                                            nroDesde As Long,
                                            nroHasta As Long,
                                            idEstadoComprobante As String,
                                            discIVA As Boolean,
                                            grabaLibro As String,
                                            afectaCaja As String,
                                            idFormasPago As Integer,
                                            idUsuario As String,
                                            nivelAutorizacion As Short,
                                            exportado As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT 	CC.IdSucursal, ")
         .AppendLine(" 	CC.IdCliente, ")
         .AppendLine(" 	C.CodigoCliente, ")
         .AppendLine(" 	C.NombreCliente, ")
         .AppendLine(" 	CC.IdTipoComprobante, ")
         .AppendLine(" 	CC.Letra, ")
         .AppendLine(" 	CC.CentroEmisor, ")
         .AppendLine(" 	CC.NumeroComprobante, ")
         .AppendLine(" 	CC.Fecha, ")
         .AppendLine(" 	CC.FechaVencimiento, ")
         .AppendLine(" 	CC.IdFormasPago, ")
         .AppendLine(" 	CC.ImporteTotal * (-1) as ImporteTotal, ")
         .AppendLine(" 	CC.Saldo, ")
         .AppendLine(" 	CC.CantidadCuotas, ")
         .AppendLine(" 	CC.ImportePesos, ")
         .AppendLine(" 	CC.ImporteTickets, ")
         .AppendLine(" 	CC.ImporteDolares, ")
         .AppendLine(" 	CC.ImporteEuros, ")
         .AppendLine(" 	CC.ImporteCheques, ")
         .AppendLine(" 	CC.ImporteTarjetas, ")
         .AppendLine(" 	CC.ImporteTransfBancaria, ")
         .AppendLine(" 	CB.NombreCuenta AS NombreCuentaBancaria, ")
         .AppendLine("  CC.ImporteRetenciones,")
         .AppendLine("  CC.IdUsuario,")
         .AppendLine("  CC.IdEstadoComprobante,")
         .AppendLine("  CC.Observacion,")
         .AppendLine("  CC.FechaActualizacion")
         .AppendLine(" 	FROM CuentasCorrientes CC")
         .AppendLine("  LEFT JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND CC.IdSucursal = I.IdSucursal")
         .AppendLine("  LEFT JOIN TiposComprobantes TC ON  CC.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("  LEFT JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("  LEFT JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("  LEFT JOIN CuentasBancarias CB ON CC.IdCuentaBancaria = CB.IdCuentaBancaria ")
         .AppendLine("  INNER JOIN Categorias CA ON CC.IdCategoria = CA.IdCategoria ")

         .AppendLine("  WHERE CC.IdSucursal= " & idSucursal.ToString())

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         .AppendLine("AND TC.EsRecibo = 'False'")
         .AppendLine("AND TC.EsAnticipo = 'False'")

         .AppendLine(" AND CC.Fecha BETWEEN '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "' AND '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If idCliente > 0 Then
            .AppendLine("	 AND C.IdCliente = " & idCliente.ToString())
         End If

         If Not String.IsNullOrEmpty(idEstadoComprobante) Then
            'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
            If idEstadoComprobante = "PENDIENTE" Then
               .AppendLine("   AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante = 'INVOCO')")
            ElseIf idEstadoComprobante = "NO ANULADO" Then
               .AppendLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")
            Else
               .AppendLine("   AND CC.IdEstadoComprobante = '" & idEstadoComprobante & "'")
            End If

         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND CC.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If Not String.IsNullOrEmpty(letra) Then
            .AppendLine("  AND CC.Letra = '" & letra & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("  AND CC.CentroEmisor = " & centroEmisor.ToString())
         End If

         If nroDesde > 0 Then
            .AppendLine("	  AND CC.NumeroComprobante >= " & nroDesde.ToString())
         End If

         If nroHasta > 0 Then
            .AppendLine("	  AND CC.NumeroComprobante <= " & nroHasta.ToString())
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         If idFormasPago > 0 Then
            .AppendLine("	 AND CC.IdFormasPago = " & idFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	 AND CC.IdUsuario = '" & idUsuario & "'")
         End If
         If exportado = "SI" Then
            .AppendLine("      AND CC.FechaExportacion IS NOT NULL")
         ElseIf exportado = "NO" Then
            .AppendLine("      AND CC.FechaExportacion IS NULL")
         End If

         'Si Filtro por algun tipo de comprobantes.
         If Not String.IsNullOrEmpty(idTipoComprobante) Or Not String.IsNullOrEmpty(letra) Or centroEmisor > 0 Or nroDesde > 0 Or nroHasta > 0 Then
            .Append("	ORDER BY CC.CentroEmisor, CC.Letra, CC.NumeroComprobante ")
         Else
            .Append("	ORDER BY CC.fecha ")
         End If
         .AppendLine(orden)   'Asc o Desc
      End With

      Return GetDataTable(stb)
   End Function

   Public Function ClienteDeComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine("  FROM CuentasCorrientes AS V")
         .AppendLine("  LEFT JOIN Clientes AS C ON C.IdCliente = V.IdCliente")
         .AppendFormat(" WHERE V.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND V.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND V.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND V.NumeroComprobante = {0}", numeroComprobante).AppendLine()
      End With
      Return GetDataTable(stb)
   End Function

   Public Function ServicioTecnicoAsociados(idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdCliente")
         .AppendLine("  FROM CuentasCorrientes AS V")
         .AppendFormat(" WHERE V.IdTipoNovedad = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND V.LetraNovedad = '{0}'", letra).AppendLine()
         .AppendFormat("   AND V.CentroEmisorNovedad = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND V.NumeroNovedad = {0}", numeroComprobante).AppendLine()
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetCtaCteDebeHaber(sucursales As Entidades.Sucursal(),
                                      desde As Date?,
                                      hasta As Date?,
                                      idVendedor As Integer,
                                      vendedor As Entidades.OrigenFK,
                                      idCliente As Long,
                                      listaComprobantes As List(Of Entidades.TipoComprobante),
                                      idZonaGeografica As String,
                                      idCategoria As Integer,
                                      categoria As Entidades.OrigenFK,
                                      grabaLibro As String,
                                      grupo As String,
                                      excluirPreComprobantes As Boolean,
                                      idProvincia As String,
                                      excluirMinutas As String,
                                      agruparIdClienteCtaCte As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal")
         .AppendLine("      ,E.IdEmpleado AS IdVendedor")
         .AppendLine("      ,E.NombreEmpleado  AS NombreVendedor")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         '.AppendLine("      ,C.NombreCliente +  ' ( ' + CONVERT(varchar(20), C.CodigoCliente)  + ' ) ' +  C.Direccion + ' - ' + L.NombreLocalidad + ' - ' + P.NombreProvincia + (CASE WHEN C.Cuit IS NULL THEN '' ELSE ' - ' + C.Cuit END) + ' - Tel: ' +(CASE WHEN C.Telefono IS NULL THEN '' ELSE ' - ' + C.Telefono END)  + ' ' + (CASE WHEN C.Celular IS NULL THEN '' ELSE ' - ' + C.Celular END) + (CASE WHEN C.CorreoElectronico IS NULL THEN '' ELSE ' - ' + C.CorreoElectronico END)  + (CASE WHEN T.NombreTransportista IS NULL THEN '' ELSE ' - ' + T.NombreTransportista  END) AS NombreCliente2")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,CC.IdTipoComprobante")
         .AppendLine("      ,LTRIM(TC.Descripcion) AS DescripcionTipoComprobante")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor")
         .AppendLine("      ,CC.NumeroComprobante")
         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,DATEDIFF(DAY, CC.Fecha, GETDATE()) CantDias")
         .AppendLine("      ,CASE WHEN CC.ImporteTotal >= 0 THEN CC.ImporteTotal      ELSE NULL END AS ImporteTotalDebe")
         .AppendLine("      ,CASE WHEN CC.ImporteTotal <  0 THEN CC.ImporteTotal * -1 ELSE NULL END AS ImporteTotalHaber")
         .AppendLine("      ,CONVERT(DECIMAL(9,2), NULL) AS Saldo")
         .AppendLine("      ,CC.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")
         .AppendLine("      ,CC.Observacion")
         '.AppendLine("      ,I.TipoImpresora")
         .AppendLine("      ,CAT.IdCategoria")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,CC.IdEjercicio")
         .AppendLine("      ,CC.IdPlanCuenta")
         .AppendLine("      ,CC.IdAsiento")
         '.AppendLine("      ,CONVERT(decimal(12,2), CC.Saldo * dbo.CtaCtePorcDescRecSaldo(CC.IdCategoria, CC.Fecha, CC.FechaVencimiento, GETDATE(), CC.ImporteTotal, CC.Saldo) / 100) AS Interes")

         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CC.IdClienteCtaCte END IdClienteCtaCte")
         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.CodigoCliente END CodigoClienteCtaCte")
         .AppendLine("      ,CASE WHEN CC.IdCliente = CC.IdClienteCtaCte THEN NULL ELSE CCC.NombreCliente END NombreClienteCtaCte")
         .AppendLine("      ,TC.EsRecibo")
         .AppendLine("  FROM CuentasCorrientes CC")

         If agruparIdClienteCtaCte Then
            .AppendLine("  INNER JOIN Clientes C   ON C.IdCliente   = CC.IdClienteCtaCte")
            .AppendLine("   LEFT JOIN Clientes CCC ON CCC.IdCliente = CC.IdCliente")
         Else
            .AppendLine("  INNER JOIN Clientes C   ON C.IdCliente   = CC.IdCliente")
            .AppendLine("   LEFT JOIN Clientes CCC ON CCC.IdCliente = CC.IdClienteCtaCte")
         End If
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor  ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = CC.IdVendedor ")
         End If

         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         '.AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("  INNER JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago")

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If


         ''Los Comprobantes Fictision pueden tener cualquier Emisor.
         '.AppendLine(" LEFT OUTER JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND I.IdSucursal = " & IdSucursal.ToString())
         ''------------------

         '.AppendLine(" LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")

         .AppendLine("  WHERE 1=1")
         GetListaSucursalesMultiples(stb, sucursales, "CC")
         If listaComprobantes IsNot Nothing AndAlso listaComprobantes.Count > 0 Then
            GetListaTiposComprobantesMultiples(stb, listaComprobantes.ToArray(), "CC")
         End If

         If desde.HasValue Then
            .AppendFormat("	 AND CC.Fecha >= '{0}'", ObtenerFecha(desde.Value, False)).AppendLine()
         End If
         If hasta.HasValue Then
            .AppendFormat("	 AND CC.Fecha <= '{0}'", ObtenerFecha(hasta.Value.Date.AddDays(1).AddSeconds(-1), True)).AppendLine()
         End If

         If idVendedor > 0 Then
            .AppendFormat("	AND E.IdEmpleado = {0}", idVendedor).AppendLine()

         End If

         If idCliente > 0 Then
            .AppendFormat("	AND C.IdCliente = {0}", idCliente).AppendLine()
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND CAT.IdCategoria = " & idCategoria.ToString())
         End If

         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         .AppendLine("	AND TC.EsAnticipo = 'False'")

         .AppendLine("  AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO') ")


         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         If excluirPreComprobantes Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If excluirMinutas = "SI" Then
            .AppendLine("  AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
         End If

         .AppendLine(" ORDER BY C.NombreCliente ")
         .AppendLine("         ,C.IdCliente ")
         .AppendLine("         ,CC.Fecha")
         .AppendLine("         ,E.NombreEmpleado ")
         .AppendLine("         ,E.IdEmpleado")
         .AppendLine("         ,ZG.NombreZonaGeografica")

         '.AppendLine(" ORDER BY E.NombreEmpleado ")
         '.AppendLine("         ,E.TipoDocEmpleado")
         '.AppendLine("         ,RIGHT(REPLICATE(' ',12) + E.NroDocEmpleado,12) ")
         '.AppendLine("         ,C.NombreCliente ")
         '.AppendLine("         ,CC.IdCliente ")
         '.AppendLine("         ,ZG.NombreZonaGeografica")
         '.AppendLine("         ,CC.Fecha")
         '.AppendLine("   ,CC.IdTipoComprobante")   'La Fecha tiene hora, Minutos y segundos.
         '.AppendLine("   ,CC.Letra")
         '.AppendLine("   ,CC.CentroEmisor")
         '.AppendLine("   ,CC.NumeroComprobante")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function BuscarFichasPendientes(idSucursal As Integer, idCliente As Long, todas As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT CC.IdSucursal as Sucursal")
         .AppendLine("      ,S.Nombre as NombreSucursal")
         .AppendLine("      ,CC.FechaVencimiento")
         .AppendLine("      ,TC.Descripcion as Tipo")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor as Emisor")
         .AppendLine("      ,CC.NumeroComprobante as Numero")
         ''.AppendLine("      ,CC.CuotaNumero as Cuota")
         .AppendLine("      ,CC.IdCliente")
         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,CC.ImporteTotal as Importe")
         .AppendLine("      ,CC.Saldo as Saldo")
         .AppendLine("      ,CC.IdTipoComprobante")
         .AppendLine("      ,CC.IdEstadoComprobante")
         .AppendLine("      ,(SELECT TOP 1 MAX(P.NombreProducto)")
         .AppendLine("          FROM VentasProductos VP ")
         .AppendLine("          LEFT JOIN Productos P ON P.IdProducto = VP.IdProducto ")
         .AppendLine("         WHERE VP.idsucursal = CC.idsucursal AND VP.idtipocomprobante = CC.idtipocomprobante AND VP.letra = CC.letra ")
         .AppendLine("           AND VP.centroemisor = CC.centroemisor AND VP.numerocomprobante = CC.numerocomprobante ) AS Producto ")
         .AppendLine("  FROM CuentasCorrientes CC")
         ''.AppendLine(" INNER JOIN CuentasCorrientesPagos cc ON cc.idsucursal=aa.idsucursal and cc.idtipocomprobante = aa.idtipocomprobante ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN Sucursales S ON S.Id = CC.IdSucursal")
         .AppendFormat(" WHERE CC.IdCliente = {0} ", idCliente).AppendLine()
         If idSucursal > 0 Then
            .AppendFormat("   AND CC.IdSucursal = {0} ", idSucursal).AppendLine()
         End If
         'Si el comprobante esta en la Cuenta Corriente, no debe mirar si es facturable.

         If Not todas Then
            .AppendFormat("   AND CC.Saldo <> 0").AppendLine()    'Positivos: Factura y Nota Debito, Negativo: Nota Credito.
         End If
         .AppendFormat("   AND TC.EsRecibo = 'False'").AppendLine()
         .AppendFormat("   AND NOT TC.EsPreElectronico = 'True'").AppendLine()
         .AppendFormat("   AND CC.IdTipoComprobante = 'FICHAS'").AppendLine()
         .AppendLine(" ORDER BY CC.FechaVencimiento")
         .AppendLine("         ,TC.Descripcion")
         .AppendLine("         ,CC.Letra")
         .AppendLine("         ,CC.CentroEmisor")
         .AppendLine("         ,CC.NumeroComprobante")
         ''.AppendLine("         ,CC.CuotaNumero")
      End With

      Return GetDataTable(stbQuery)
   End Function


   Public Function GetCtasCtesParaBanco(idCobrador As Integer, periodo As Date?, idTipoLiquidacion As Integer?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT(CASE")
         .AppendLine("           WHEN CF.SolicitaCUIT = 'False'")
         .AppendLine("           THEN C.TipoDocCliente")
         .AppendLine("           ELSE 'CUIT'")
         .AppendLine("       END) AS TipoDocCliente,")
         .AppendLine("      (CASE")
         .AppendLine("           WHEN CF.SolicitaCUIT = 'False'")
         .AppendLine("           THEN C.NroDocCliente")
         .AppendLine("           ELSE C.CUIT")
         .AppendLine("       END) AS NroDocCliente,")
         .AppendLine("      C.IdCliente")
         .AppendLine("     ,C.CodigoCliente")
         .AppendLine("     ,C.NombreCliente")
         .AppendLine("     ,CAT.NombreCategoria")
         .AppendLine("     ,C.CBU")
         .AppendLine("     ,C.IdBanco")
         .AppendLine("     ,C.IdCuentaBancariaClase")
         .AppendLine("     ,C.NumeroCuentaBancaria")
         .AppendLine("     ,CC.Saldo SaldoCtaCte")
         .AppendLine("     ,CC.IdSucursal")
         .AppendLine("     ,CC.IdTipoComprobante")
         .AppendLine("     ,CC.Letra")
         .AppendLine("     ,CC.CentroEmisor")
         .AppendLine("     ,CC.NumeroComprobante")
         .AppendLine("     ,(SELECT COUNT(IdCliente) as Cantidad FROM CuentasCorrientes WHERE IdCliente = C.IdCliente AND IdSucursal = CC.IdSucursal AND  Saldo < 0 ) as NC")
         .AppendLine("     ,LC.PeriodoLiquidacion")
         .AppendLine("     ,LC.IdTipoLiquidacion")
         .AppendLine("     ,TL.NombreTipoLiquidacion")
         .AppendLine("     ,LC.PeriodoLiquidacion")
         .AppendLine("     ,LC.IdTipoLiquidacion")
         .AppendLine("     ,TL.NombreTipoLiquidacion")

         .AppendLine(" FROM CuentasCorrientes CC")
         .AppendLine("     INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("     INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("     INNER JOIN Categorias CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("     INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
         .AppendLine("	 LEFT JOIN LiquidacionesCargos LC ON LC.IdSucursal = CC.IdSucursal AND LC.IdTipoComprobante = CC.IdTipoComprobante AND LC.Letra = CC.Letra ")
         .AppendLine("							 AND LC.CentroEmisor = CC.CentroEmisor AND  LC.NumeroComprobante = CC.NumeroComprobante")
         .AppendLine("	 LEFT JOIN TiposLiquidaciones TL ON TL.IdTipoLiquidacion = LC.IdTipoLiquidacion ")

         .AppendLine(" WHERE CC.Saldo > 0")
         .AppendLine("   AND CC.IdSucursal = " & Entidades.Usuario.Actual.Sucursal.Id.ToString())
         .AppendLine("   AND TC.EsRecibo = 'False'")
         .AppendLine("   AND TC.GrabaLibro = 'True'")

         .AppendLine("	 AND C.IdCobrador = " & idCobrador.ToString())

         If idTipoLiquidacion.HasValue Then
            .AppendLine("	 AND LC.IdTipoLiquidacion = " & idTipoLiquidacion.Value.ToString())
         End If
         If periodo.HasValue Then
            .AppendLine("	 AND LC.PeriodoLiquidacion = " & periodo.Value.ToString("yyyyMM"))
         End If
         .AppendLine(" ORDER BY C.NombreCliente, LC.PeriodoLiquidacion, TL.NombreTipoLiquidacion")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function AlgunRegistrosCuentaCorrientePorEmisor(emisor As Short) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT TOP 1 CentroEmisor")
         .AppendLine("  FROM CuentasCorrientes")
         .AppendFormat(" WHERE CentroEmisor = {0}", emisor)
      End With

      Return GetDataTable(stb).Rows.Count > 0
   End Function

   Public Function GetParaSincronizacionMovil(mesesEnviarCuentasCorrientes As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT * FROM (")

         .AppendLine("SELECT CCP.IdSucursal")
         .AppendLine("     , CCP.IdTipoComprobante")
         .AppendLine("     , CCP.Letra")
         .AppendLine("     , CCP.CentroEmisor")
         .AppendLine("     , CCP.NumeroComprobante")
         .AppendLine("     , CCP.CuotaNumero")
         .AppendLine("     , CC.DescripcionAbrev")
         .AppendLine("     , CC.DescripcionTipoComprobante")
         .AppendLine("     , CCP.Fecha")
         .AppendLine("     , CCP.FechaVencimiento")
         .AppendLine("     , CCP.ImporteCuota")
         .AppendLine("     , CCP.SaldoCuota")
         .AppendLine("     , (SELECT TOP 1 VP.NombreProducto")
         .AppendLine("          FROM VentasProductos VP")
         .AppendLine("         WHERE VP.IdSucursal = CC.IdSucursal")
         .AppendLine("           AND VP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("           AND VP.Letra = CC.Letra ")
         .AppendLine("           AND VP.CentroEmisor = CC.CentroEmisor")
         .AppendLine("           AND VP.NumeroComprobante = CC.NumeroComprobante) AS NombreProducto")
         .AppendLine("     , CC.IdCliente")

         .AppendLine("  FROM (SELECT CC.IdSucursal")
         .AppendLine("             , CC.IdTipoComprobante")
         .AppendLine("             , CC.Letra")
         .AppendLine("             , CC.CentroEmisor")
         .AppendLine("             , CC.NumeroComprobante")
         .AppendLine("             , CC.IdCliente")
         .AppendLine("             , TC.DescripcionAbrev")
         .AppendLine("             , TC.Descripcion DescripcionTipoComprobante")
         .AppendLine("             , MIN(CCP.CuotaNumero) CuotaNumeroMin")

         .AppendLine("          FROM MovilRutas AS MR")
         .AppendLine("         INNER JOIN MovilRutasClientes MRC ON MRC.IdRuta = MR.IdRuta")
         .AppendLine("         INNER JOIN Clientes C ON C.IdCliente = MRC.IdCliente")
         .AppendLine("         INNER JOIN CuentasCorrientes CC ON CC.IdCliente = C.IdCliente")
         .AppendLine("         INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("         INNER JOIN CuentasCorrientesPagos CCP ON CCP.IdSucursal = CC.IdSucursal")
         .AppendLine("                                              AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("                                              AND CCP.Letra = CC.Letra")
         .AppendLine("                                              AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendLine("                                              AND CCP.NumeroComprobante = CC.NumeroComprobante")
         .AppendLine("         WHERE MR.Activa = 1")
         .AppendLine("           AND C.Activo = 1")
         .AppendLine("           AND TC.EsPreElectronico = 0")
         .AppendLine("           AND CCP.SaldoCuota <> 0")
         .AppendLine("         GROUP BY CC.IdSucursal")
         .AppendLine("                , CC.IdTipoComprobante")
         .AppendLine("                , CC.Letra")
         .AppendLine("                , CC.CentroEmisor")
         .AppendLine("                , CC.NumeroComprobante")
         .AppendLine("                , CC.IdCliente")
         .AppendLine("                , TC.DescripcionAbrev")
         .AppendLine("                , TC.Descripcion")
         .AppendLine("                , TC.Descripcion")
         .AppendLine("           ) CC")

         .AppendLine(" INNER JOIN CuentasCorrientesPagos CCP ON CCP.IdSucursal = CC.IdSucursal")
         .AppendLine("                                      AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("                                      AND CCP.Letra = CC.Letra")
         .AppendLine("                                      AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendLine("                                      AND CCP.NumeroComprobante = CC.NumeroComprobante")
         .AppendFormatLine("                                      AND CCP.CuotaNumero BETWEEN CC.CuotaNumeroMin AND CC.CuotaNumeroMin + {0}", mesesEnviarCuentasCorrientes - 1)
         .AppendLine("         WHERE CCP.SaldoCuota <> 0")

         .AppendLine("     ) CC")
         .AppendLine(" GROUP BY CC.IdSucursal")
         .AppendLine("        , CC.IdTipoComprobante")
         .AppendLine("        , CC.Letra")
         .AppendLine("        , CC.CentroEmisor")
         .AppendLine("        , CC.NumeroComprobante")
         .AppendLine("        , CC.CuotaNumero")
         .AppendLine("        , CC.DescripcionAbrev")
         .AppendLine("        , CC.DescripcionTipoComprobante")
         .AppendLine("        , CC.Fecha")
         .AppendLine("        , CC.FechaVencimiento")
         .AppendLine("        , CC.ImporteCuota")
         .AppendLine("        , CC.SaldoCuota")
         .AppendLine("        , CC.NombreProducto")
         .AppendLine("        , CC.IdCliente")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetCoeficienteCobranzas(sucursales As Entidades.Sucursal(),
                                           fechaDesde As Date, fechaHasta As Date,
                                           idCliente As Long,
                                           idCategoria As Integer, categoria As Entidades.OrigenFK,
                                           IdVendedor As Integer, vendedor As Entidades.OrigenFK,
                                           idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroComprobante As Long,
                                           idUsuario As String,
                                           idCaja As Integer,
                                           idZonaGeografica As String,
                                           idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                           idEstadoCliente As Integer, estdoCliente As Entidades.OrigenFK,
                                           modalidad As Entidades.EnumSql.GetCoeficienteCobranzasModalidad) As DataTable
      Dim stb = New StringBuilder()
      With stb

         .AppendLine("SELECT CC.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine("      ,CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante, CC.CantidadCuotas")
         .AppendLine("      ,CCP.PrimerCuota, CCP.UltimaCuota, CCP.ImporteCobrar")
         .AppendLine("      ,CCP2.PrimerCuotaCobrada, CCP2.UltimaCuotaCobrada, ISNULL(CCP2.ImporteCobrado, 0) ImporteCobrado")
         .AppendLine("      ,ISNULL(CASE WHEN CCP.ImporteCobrar=0  AND ImporteCobrado<>0 THEN 100 ELSE (CASE WHEN CCP.ImporteCobrar<>0 THEN CASE WHEN ISNULL(CCP2.ImporteCobrado, 0)<>0 THEN CCP2.ImporteCobrado END END *100)/CCP.ImporteCobrar END,0) AS Margen")
         .AppendLine("  FROM (")
         If modalidad = Entidades.EnumSql.GetCoeficienteCobranzasModalidad.SoloVencidos Then
            .AppendLine("        SELECT CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante")
            .AppendLine("              ,MIN(CCP.CuotaNumero) PrimerCuota,MAX(CCP.CuotaNumero) UltimaCuota,SUM(CCP.ImporteCuota) ImporteCobrar")
            .AppendLine("          FROM CuentasCorrientesPagos CCP")
            .AppendLine("         INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
            .AppendFormatLine("         WHERE CCP.FechaVencimiento >= '{0}'", ObtenerFecha(fechaDesde, True))
            .AppendFormatLine("           AND CCP.FechaVencimiento <= '{0}'", ObtenerFecha(fechaHasta, True))
            .AppendLine("           AND TC.EsRecibo = 'False'")
            .AppendLine("         GROUP BY CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante")
         Else
            .AppendLine("        SELECT CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante")
            .AppendLine("              ,MIN(CCP.CuotaNumero) PrimerCuota,MAX(CCP.CuotaNumero) UltimaCuota,SUM(CCP.ImporteCuota) ImporteCobrar")
            .AppendLine("          FROM (")
            .AppendLine("        SELECT CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante, CCP.CuotaNumero, CCP.ImporteCuota")
            .AppendLine("          FROM CuentasCorrientesPagos CCP")
            .AppendLine("         INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
            .AppendFormatLine("         WHERE CCP.FechaVencimiento >= '{0}'", ObtenerFecha(fechaDesde, True))
            .AppendFormatLine("           AND CCP.FechaVencimiento <= '{0}'", ObtenerFecha(fechaHasta, True))
            .AppendLine("           AND TC.EsRecibo = 'False'")
            .AppendLine("        UNION ALL")
            .AppendLine("        SELECT CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante, CCP.CuotaNumero, 0 ImporteCuota")
            .AppendLine("          FROM CuentasCorrientesPagos CCP")
            .AppendLine("         INNER JOIN CuentasCorrientesPagos CCP2 ON CCP2.IdSucursal = CCP.IdSucursal")
            .AppendLine("                                               AND CCP2.IdTipoComprobante2 = CCP.IdTipoComprobante")
            .AppendLine("                                               AND CCP2.Letra2 = CCP.Letra")
            .AppendLine("                                               AND CCP2.CentroEmisor2 = CCP.CentroEmisor")
            .AppendLine("                                               AND CCP2.NumeroComprobante2 = CCP.NumeroComprobante")
            .AppendLine("                                               AND CCP2.CuotaNumero2 = CCP.CuotaNumero")
            .AppendLine("         INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
            .AppendLine("         INNER JOIN TiposComprobantes TC2 ON TC2.IdTipoComprobante = CCP2.IdTipoComprobante")
            .AppendLine("         WHERE 1 = 1")
            .AppendFormatLine("           AND CCP2.FechaVencimiento >= '{0}'", ObtenerFecha(fechaDesde, True))
            .AppendFormatLine("           AND CCP2.FechaVencimiento <= '{0}'", ObtenerFecha(fechaHasta, True))
            .AppendFormatLine("           AND (CCP.FechaVencimiento < '{0}' OR CCP.FechaVencimiento > '{1}')", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
            .AppendLine("           AND TC.EsRecibo = 'False'")
            .AppendLine("           AND TC2.EsRecibo = 'True'")
            .AppendLine("        ) CCP")
            .AppendLine("         GROUP BY CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante")

         End If
         .AppendLine("         ) CCP")
         .AppendLine(" INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
         .AppendLine("                                AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("                                AND CC.Letra = CCP.Letra")
         .AppendLine("                                AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("                                AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendLine("  LEFT JOIN (SELECT CCP.IdSucursal, CCP.IdTipoComprobante2, CCP.Letra2, CCP.CentroEmisor2, CCP.NumeroComprobante2")
         .AppendLine("                   ,MIN(CCP.CuotaNumero) PrimerCuotaCobrada,MAX(CCP.CuotaNumero) UltimaCuotaCobrada,SUM(CCP.ImporteCuota) * -1 ImporteCobrado")
         .AppendLine("               FROM CuentasCorrientesPagos CCP")
         .AppendLine("              INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine("         WHERE CCP.FechaVencimiento >= '{0}'", ObtenerFecha(fechaDesde, True))
         .AppendFormatLine("           AND CCP.FechaVencimiento <= '{0}'", ObtenerFecha(fechaHasta, True))
         .AppendLine("                AND TC.EsRecibo = 'True'")
         .AppendLine("               GROUP BY CCP.IdSucursal, CCP.IdTipoComprobante2, CCP.Letra2, CCP.CentroEmisor2, CCP.NumeroComprobante2) CCP2")
         .AppendLine("            ON CCP2.IdSucursal = CCP.IdSucursal")
         .AppendLine("           AND CCP2.IdTipoComprobante2 = CCP.IdTipoComprobante")
         .AppendLine("           AND CCP2.Letra2 = CCP.Letra")
         .AppendLine("           AND CCP2.CentroEmisor2 = CCP.CentroEmisor")
         .AppendLine("           AND CCP2.NumeroComprobante2 = CCP.NumeroComprobante")


         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = CC.IdVendedor ")
         End If

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  LEFT JOIN Empleados Co ON Co.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("  LEFT JOIN Empleados Co ON Co.IdEmpleado = CC.IdCobrador")
         End If

         If estdoCliente = Entidades.OrigenFK.Actual Then
            .AppendLine("  LEFT JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")
         Else
            .AppendLine("  LEFT JOIN EstadosClientes EC ON EC.IdEstadoCliente = CC.IdEstadoCliente")
         End If

         .AppendLine("  WHERE 1 = 1")
         GetListaSucursalesMultiples(stb, sucursales, "CC").AppendLine()

         .AppendLine("    AND CC.Saldo <> 0")

         If IdVendedor > 0 Then
            .AppendFormatLine("   AND E.IdEmpleado = {0}", IdVendedor)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If idCategoria > 0 Then
            .AppendFormatLine("   AND CAT.IdCategoria = {0}", idCategoria)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("	 AND CC.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If Not String.IsNullOrWhiteSpace(letraFiscal) Then
            .AppendFormatLine("	 AND CC.Letra = '{0}'", letraFiscal)
         End If

         If centroEmisor > 0 Then
            .AppendFormatLine("	 AND CC.CentroEmisor = {0}", centroEmisor)
         End If

         If numeroComprobante > 0 Then
            .AppendFormatLine("	 AND CC.NumeroComprobante = {0}", numeroComprobante)
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("   AND CC.IdUsuario = '{0}'", idUsuario)
         End If

         If idCaja > 0 Then
            .AppendFormatLine("   AND CC.IdCaja = {0}", idCaja)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCobrador > 0 Then
            .AppendFormatLine("   AND CO.IdEmpleado = {0}", idCobrador)
         End If

         If idEstadoCliente > 0 Then
            .AppendFormatLine("   AND EC.IdEstadoCliente = {0}", idEstadoCliente)
         End If

         .AppendLine("	ORDER BY CC.Fecha")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetInfNoCobranzas(idCliente As Long,
                                     fechaDesde As Date,
                                     fechaHasta As Date,
                                     idLocalidad As Integer,
                                     idProvincia As String,
                                     idCategoria As Integer,
                                     idZonaGeografica As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendLine("SELECT C.IdCliente, C.CodigoCliente, C.NombreCliente, C.Direccion, C.Telefono, L.NombreLocalidad, PR.NombreProvincia, C.CorreoElectronico, R.Fecha AS FechaUltimoRecibo, S.Saldo")
         .AppendLine("        ,CA.NombreCategoria, ZG.NombreZonaGeografica")
         .AppendLine("	FROM Clientes C")
         .AppendLine("INNER JOIN CuentasCorrientes CC on c.IdCliente = CC.IdCliente")
         .AppendLine("INNER JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad")
         .AppendLine("         LEFT JOIN Categorias CA ON C.IdCategoria = CA.IdCategoria")
         .AppendLine("LEFT JOIN ZonasGeograficas ZG ON C.IdZonaGeografica= ZG.IdZonaGeografica")
         .AppendLine("LEFT JOIN Provincias PR ON L.IdProvincia= PR.IdProvincia")
         .AppendLine("LEFT JOIN (SELECT CC.IdCliente, MAX(CC.Fecha) Fecha FROM CuentasCorrientes CC")
         .AppendLine("			 INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("			 WHERE TC.EsRecibo = 1")
         .AppendLine("			 GROUP BY CC.IdCliente) R ON R.IdCliente = C.IdCliente")
         .AppendLine("LEFT JOIN (SELECT C.IdCliente, SUM(CC.Saldo) AS Saldo FROM CuentasCorrientes CC")
         .AppendLine("			  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("			  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("			 WHERE 1 = 1")
         .AppendLine("			  AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO') ")
         .AppendLine("			  AND TC.EsRecibo = 'False'")
         .AppendLine("			 GROUP BY C.IdCliente) S ON S.IdCliente = C.IdCliente")
         .AppendLine("WHERE	1=1 ")
         .AppendLine("AND S.Saldo > 0 ")
         .AppendLine("AND NOT EXISTS(SELECT CC1.idCliente,  CC1.IdTipoComprobante,C.NombreCliente ")
         .AppendLine("				FROM cuentasCorrientes CC1")
         .AppendLine("			INNER JOIN Clientes C ON CC1.IdCliente = C.IdCliente")
         .AppendLine("			INNER JOIN TiposComprobantes TC ON CC1.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("				WHERE 1=1 ")
         .AppendLine("			AND TC.EsRecibo = 1")
         .AppendLine("			      AND (CC1.IdEstadoComprobante IS NULL OR CC1.IdEstadoComprobante <> 'ANULADO')")
         .AppendFormatLine("			AND CC1.Fecha >= '{0}' and CC1.Fecha <= '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta.UltimoSegundoDelDia, True))
         .AppendLine("			      AND CC1.IdCliente = CC.IdCliente")
         .AppendLine("				)")

         ' # Filtro por IdCliente
         If idCliente <> 0 Then
            .AppendFormatLine("AND C.IdCliente = {0} ", idCliente)
         End If

         ' # Filtro por Categoria del Cliente
         If idCategoria <> 0 Then
            .AppendFormatLine("AND C.IdCategoria = {0} ", idCategoria)
         End If

         ' # Filtro por Localidad
         If idLocalidad <> 0 Then
            .AppendFormatLine("AND L.IdLocalidad = {0} ", idLocalidad)
         End If

         ' # Filtro por Provincia
         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendFormatLine("AND L.IdProvincia = '{0}' ", idProvincia)
         End If

         ' # Filtro por Zona Geográfica
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("AND C.IdZonaGeografica = '{0}' ", idZonaGeografica)
         End If

         .AppendLine("GROUP BY C.IdCliente, C.CodigoCliente, C.NombreCliente, C.Direccion, L.NombreLocalidad, C.Telefono, C.CorreoElectronico, R.Fecha, S.Saldo")
         .AppendLine(", CA.NombreCategoria")
         .AppendLine(", PR.NombreProvincia")
         .AppendLine(", ZG.NombreZonaGeografica")

         .AppendLine("ORDER BY C.nombreCliente")
      End With

      Return GetDataTable(query)
   End Function

   Public Function GetInfVentasCobranzas(fechaDesde As Date,
                                         fechaHasta As Date,
                                         idCliente As Long,
                                         IdVendedor As Integer,
                                         vendedor As Entidades.OrigenFK,
                                         idCobrador As Integer,
                                         cobrador As Entidades.OrigenFK,
                                         sucursales As Entidades.Sucursal()) As DataTable

      Dim stb = New StringBuilder()
      With stb

         .AppendLine("SELECT V.*")
         .AppendLine("      ,CONVERT(DECIMAL(14,2), CASE WHEN V.ImporteTotal = 0 THEN 0 ELSE (V.ImporteTotalContado + V.ImporteCobradoSinVencer) / V.ImporteTotal * 100 END) CoeficienteCobranza")
         .AppendLine("      ,ROUND(V.ImporteTotalContado + V.ImporteCobradoSinVencer,2) AS ImporteCalculado")
         .AppendLine("  FROM (")
         .AppendLine("        SELECT V.IdCliente,V.CodigoCliente,V.NombreCliente")
         .AppendLine("               , SUM(V.ImporteTotal) AS ImporteTotal")
         .AppendLine("               , SUM(V.ImporteTotalContado) AS ImporteTotalContado")
         .AppendLine("               , SUM(V.ImporteTotalCuentaCorriente) AS ImporteTotalCuentaCorriente")
         .AppendLine("               , SUM(V.ImporteCobrado) AS ImporteCobrado")
         .AppendLine("               , SUM(V.ImporteCobradoSinVencer) AS ImporteCobradoSinVencer")
         .AppendLine("               , SUM(V.ImporteCobradoVencido) AS ImporteCobradoVencido")
         .AppendLine("  FROM (")

         .AppendLine("       SELECT V.IdCliente,C.CodigoCliente,C.NombreCliente")
         .AppendLine("              , SUM(V.ImporteTotal) AS ImporteTotal")
         .AppendLine("              , SUM(CASE WHEN FP.Dias =  0 THEN V.ImporteTotal ELSE 0 END) AS ImporteTotalContado")
         .AppendLine("              , SUM(CASE WHEN FP.Dias <> 0 THEN V.ImporteTotal ELSE 0 END) AS ImporteTotalCuentaCorriente")
         .AppendLine("              , 0 AS ImporteCobrado")
         .AppendLine("              , 0 AS ImporteCobradoSinVencer")
         .AppendLine("              , 0 AS ImporteCobradoVencido")
         .AppendLine("       FROM Ventas V")
         .AppendLine("             INNER JOIN TiposComprobantes TCV ON TCV.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("             INNER JOIN VentasFormasPago FP ON FP.IdFormasPago = V.IdFormasPago")
         .AppendLine("             INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("          INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         Else
            .AppendLine("          INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor ")
         End If
         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("          LEFT JOIN Empleados Co ON Co.IdEmpleado = V.IdCobrador")
         Else
            .AppendLine("          LEFT JOIN Empleados Co ON Co.IdEmpleado = C.IdCobrador")
         End If
         .AppendLine("     WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "V").AppendLine()

         .AppendLine("           AND TCV.EsRecibo = 'False'")
         .AppendLine("           AND TCV.AfectaCaja = 'True'")
         .AppendFormatLine("     AND V.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))

         If idCliente > 0 Then
            .AppendFormatLine("  AND V.IdCliente = {0}", idCliente)
         End If

         If IdVendedor > 0 Then
            .AppendFormatLine("  AND E.IdEmpleado = {0}", IdVendedor)
         End If
         If idCobrador > 0 Then
            .AppendFormatLine("  AND CO.IdEmpleado = {0}", idCobrador)
         End If
         .AppendLine("         GROUP BY V.IdCliente,C.CodigoCliente,C.NombreCliente")

         .AppendLine(" UNION ALL")

         .AppendLine("       SELECT V.IdCliente,C.CodigoCliente,C.NombreCliente")
         .AppendLine("              , 0 AS ImporteTotal")
         .AppendLine("              , 0 AS ImporteTotalContado")
         .AppendLine("              , 0 AS ImporteTotalCuentaCorriente")
         .AppendLine("              , SUM(ISNULL(CCP.ImporteCuota, 0) * -1) AS ImporteCobrado")
         .AppendLine("              , SUM(CASE WHEN CCP.Fecha <= CCPV.FechaVencimiento THEN ISNULL(CCP.ImporteCuota, 0) * -1 ELSE 0 END) AS ImporteCobradoSinVencer")
         .AppendLine("              , SUM(CASE WHEN CCP.Fecha  > CCPV.FechaVencimiento THEN ISNULL(CCP.ImporteCuota, 0) * -1 ELSE 0 END) AS ImporteCobradoVencido")
         .AppendLine("       FROM Ventas V")
         .AppendLine("             INNER JOIN TiposComprobantes TCV ON TCV.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("             INNER JOIN VentasFormasPago FP ON FP.IdFormasPago = V.IdFormasPago")
         .AppendLine("             INNER JOIN CuentasCorrientesPagos CCP  ON CCP.IdSucursal = V.IdSucursal")
         .AppendLine("                                 AND CCP.IdTipoComprobante2 = V.IdTipoComprobante")
         .AppendLine("                                 AND CCP.Letra2 = V.Letra")
         .AppendLine("                                 AND CCP.CentroEmisor2 = V.CentroEmisor")
         .AppendLine("                                 AND CCP.NumeroComprobante2 = V.NumeroComprobante")
         .AppendLine("             INNER JOIN CuentasCorrientesPagos CCPV ON CCPV.IdSucursal = CCP.IdSucursal")
         .AppendLine("                                 AND CCPV.IdTipoComprobante = CCP.IdTipoComprobante2")
         .AppendLine("                                 AND CCPV.Letra = CCP.Letra2")
         .AppendLine("                                 AND CCPV.CentroEmisor = CCP.CentroEmisor2")
         .AppendLine("                                 AND CCPV.NumeroComprobante = CCP.NumeroComprobante2")
         .AppendLine("                                 AND CCPV.CuotaNumero = CCP.CuotaNumero2")
         .AppendLine("             INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("             INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("          INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         Else
            .AppendLine("          INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor ")
         End If
         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("          LEFT JOIN Empleados Co ON Co.IdEmpleado = V.IdCobrador")
         Else
            .AppendLine("          LEFT JOIN Empleados Co ON Co.IdEmpleado = C.IdCobrador")
         End If

         .AppendLine("     WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "V").AppendLine()

         .AppendLine("            AND TCV.EsRecibo = 'False'")
         .AppendLine("            AND TCV.AfectaCaja = 'True'")
         .AppendFormatLine("      AND V.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, False), ObtenerFecha(fechaHasta, True))

         If idCliente > 0 Then
            .AppendFormatLine("   AND V.IdCliente = {0}", idCliente)
         End If
         If IdVendedor > 0 Then
            .AppendFormatLine("   AND E.IdEmpleado = {0}", IdVendedor)
         End If
         If idCobrador > 0 Then
            .AppendFormatLine("   AND CO.IdEmpleado = {0}", idCobrador)
         End If

         .AppendLine("            AND (TC.EsRecibo IS NULL OR TC.EsRecibo = 'True')")

         .AppendLine("  GROUP BY V.IdCliente,C.CodigoCliente,C.NombreCliente")
         .AppendLine("    ) V GROUP BY V.IdCliente,V.CodigoCliente,V.NombreCliente) V")
         .AppendLine("  ORDER BY CoeficienteCobranza")



      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPorCliente(sucursales As Entidades.Sucursal(),
                                 idCliente As Long,
                                 fechaUtilizada As String,
                                 desde As Date?,
                                 hasta As Date?,
                                 grabaLibro As String,
                                 grupo As String,
                                 excluirMinutas As String,
                                 idMoneda As Integer,
                                 tipoConversion As Entidades.Moneda_TipoConversion,
                                 cotizDolar As Decimal,
                                 excluirPreComprobantes As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal,")
         .AppendLine("       C.IdVendedor,")
         .AppendLine("       E.NombreEmpleado AS NombreVendedor,")
         .AppendLine("       CC.IdCliente,")
         .AppendLine("       C.CodigoCliente,")
         .AppendLine("       C.NombreCliente,")
         .AppendLine("       CC.IdTipoComprobante,")
         .AppendLine("       CC.Letra,")
         .AppendLine("       CC.CentroEmisor,")
         .AppendLine("       CC.NumeroComprobante,")
         .AppendLine("       CC.Fecha,")
         .AppendLine("       CC.FechaVencimiento,")

         If idMoneda = Entidades.Moneda.Peso Then
            .AppendLine("       CC.ImporteTotal,")
            .AppendLine("       CC.Saldo,")
         Else
            .AppendFormatLine("     ROUND(CC.ImporteTotal / {0}, 2) AS ImporteTotal,", If(tipoConversion = Entidades.Moneda_TipoConversion.Comprobante, "CC.CotizacionDolar", cotizDolar.ToString()))
            .AppendFormatLine("     ROUND(CC.Saldo / {0}, 2) AS Saldo,", If(tipoConversion = Entidades.Moneda_TipoConversion.Comprobante, "CC.CotizacionDolar", cotizDolar.ToString()))
         End If

         .AppendLine("       CC.Observacion,")
         .AppendLine("       I.TipoImpresora")
         .AppendLine("      ,TC.EsRecibo")

         .AppendFormatLine("     ,NULLIF(CONVERT(VARCHAR(MAX), ({0})) + ' / ' +", VentasInvocados.GetCantidadInvocadosParaInforme_SubQuery("CC"))
         .AppendLine("             CONVERT(VARCHAR(MAX), ISNULL((SELECT COUNT(1)")
         .AppendLine("                                             FROM VentasInvocados VV WHERE VV.IdSucursalInvocado = CC.IdSucursal")
         .AppendLine("                                                        AND VV.IdTipoComprobanteInvocado = CC.IdTipoComprobante")
         .AppendLine("                                                        AND VV.CentroEmisorInvocado = CC.CentroEmisor")
         .AppendLine("                                                        AND VV.LetraInvocado = CC.Letra")
         .AppendLine("                                                        AND VV.NumeroComprobanteInvocado = CC.NumeroComprobante), 0)), '0 / 0')  CantidadInvocadosInvocadores")


         .AppendLine("  FROM Clientes C, Empleados E, CuentasCorrientes CC")

         .AppendLine(" LEFT JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND I.IdSucursal=CC.IdSucursal")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

         .AppendLine("  WHERE CC.IdCliente = C.IdCliente")
         .AppendLine("    AND C.IdVendedor = E.IdEmpleado")

         GetListaSucursalesMultiples(stb, sucursales, "CC")
         '.AppendLine("	  AND CC.IdSucursal = " & idSucursal.ToString())

         If desde.HasValue Then
            If fechaUtilizada = "EMISION" Then
               .AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) >= '" & desde.Value.ToString("yyyy-MM-dd") & "'")
               .AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) <= '" & hasta.Value.ToString("yyyy-MM-dd") & "'")
            Else
               .AppendLine("	 AND CONVERT(varchar(11), CC.FechaVencimiento, 120) >= '" & desde.Value.ToString("yyyy-MM-dd") & "'")
               .AppendLine("	 AND CONVERT(varchar(11), CC.FechaVencimiento, 120) <= '" & hasta.Value.ToString("yyyy-MM-dd") & "'")
            End If
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente.ToString)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If


         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         .AppendLine("	AND TC.EsAnticipo = 'False'")

         .AppendLine("   AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO') ")

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         If excluirMinutas = "SI" Then
            .AppendLine("  AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
         End If

         If excluirPreComprobantes Then
            .AppendLine("   AND TC.EsPreElectronico = 'False'")
         End If

         .AppendLine(" ORDER BY ")

         If fechaUtilizada = "EMISION" Then
            .AppendLine("	CC.Fecha")
         Else
            .AppendLine("	CC.FechaVencimiento")
         End If
         .AppendLine("   ,CC.IdTipoComprobante")
         .AppendLine("   ,CC.Letra")
         .AppendLine("   ,CC.CentroEmisor")
         .AppendLine("   ,CC.NumeroComprobante")
      End With

      Return GetDataTable(stb)
   End Function
   Public Function GetTotaldeCobranzaPorDia(sucursales As Entidades.Sucursal(),
                                      desde As Date,
                                      hasta As Date,
                                      idCliente As Long,
                                      idCategoria As Integer,
                                      categoria As Entidades.OrigenFK,
                                      idVendedor As Integer,
                                      vendedor As Entidades.OrigenFK,
                                      idTipoComprobante As String,
                                      idCaja As Integer,
                                      idZonaGeografica As String,
                                      idCobrador As Integer,
                                      cobrador As Entidades.OrigenFK,
                                      nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb

         .AppendLine("SELECT  Fecha ")
         .AppendLine("       ,SUM(ImporteTotal) AS ImporteTotal")
         .AppendLine("       ,SUM(SUM(ImporteTotal)) OVER (ORDER BY Fecha ASC) AS Acumulado")
         .AppendLine("       ,SUM(ImportePesos) AS ImportePesos")
         .AppendLine("       ,SUM(ImporteTickets) AS ImporteTickets")
         .AppendLine("       ,SUM(ImporteDolares) AS ImporteDolares")
         .AppendLine("       ,SUM(ImporteEuros) AS ImporteEuros")
         .AppendLine("       ,SUM(ImporteCheques) AS ImporteCheques")
         .AppendLine("       ,SUM(ImporteTarjetas) AS ImporteTarjetas")
         .AppendLine("       ,SUM(ImporteTransfBancaria) AS ImporteTransfBancaria")
         .AppendLine("       ,SUM(ImporteRetenciones) AS ImporteRetenciones")

         .AppendLine("  FROM  (")
         .AppendLine("         SELECT CONVERT(date, CC.Fecha, 120) as Fecha")
         .AppendLine("                ,CC.ImporteTotal * (-1) as ImporteTotal")
         .AppendLine("                ,CC.ImportePesos")
         .AppendLine("                ,CC.ImporteTickets")
         .AppendLine("                ,CC.ImporteDolares")
         .AppendLine("                ,CC.ImporteEuros")
         .AppendLine("                ,CC.ImporteCheques")
         .AppendLine("                ,CC.ImporteTarjetas")
         .AppendLine("                ,CC.ImporteTransfBancaria")
         .AppendLine("                ,CC.ImporteRetenciones")
         .AppendLine("	        FROM  CuentasCorrientes CC")
         .AppendLine("	                 LEFT JOIN CuentasBancarias CB ON CC.IdCuentaBancaria = CB.IdCuentaBancaria ")
         .AppendLine("	                 INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("	                 INNER JOIN CajasNombres CN ON CN.IdSucursal = CC.IdSucursal AND CN.IdCaja = CC.IdCaja")
         .AppendLine("	                 INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("	                 INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("	              INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor ")
         Else
            .AppendLine("	              INNER JOIN Empleados E ON E.IdEmpleado = CC.IdVendedor ")
         End If

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("	              INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("	              INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("	              LEFT JOIN Empleados Co ON Co.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("	              LEFT JOIN Empleados Co ON Co.IdEmpleado = CC.IdCobrador")
         End If


         .AppendLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "CC")
         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         .AppendLine("   AND  TC.EsRecibo = 'True'")
         .AppendFormatLine("   AND CC.Fecha >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("   AND CC.Fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))

         If idVendedor > 0 Then
            .AppendFormatLine("   AND E.IdEmpleado = {0}", idVendedor)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If idCategoria > 0 Then
            .AppendFormatLine("   AND CAT.IdCategoria = {0}", idCategoria)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("   AND CC.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If idCaja > 0 Then
            .AppendFormatLine("   AND CC.IdCaja = {0}", idCaja)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("   AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCobrador > 0 Then
            .AppendFormatLine("   AND Co.IdEmpleado = {0}", idCobrador)
         End If

         .AppendLine(") AS Tbl")
         .AppendLine("	GROUP BY Fecha")
         .AppendLine("	Order by Fecha Asc")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPorClienteImporte(idSucursal As Integer,
                                desde As Date?,
                                hasta As Date?,
                                idTipoComprobante As String,
                                importeTotal As Decimal,
                                idCliente As Long,
                                conSaldo As Boolean,
                                numeroComprobanteDesde As Long,
                                numeroComprobanteHasta As Long,
                                letraFiscal As String,
                                centroEmisor As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdTipoComprobante")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor")
         .AppendLine("      ,CC.NumeroComprobante")
         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,CCP.CuotaNumero")
         .AppendLine("      ,CCP.ImporteCuota")
         .AppendLine("      ,CCP.SaldoCuota")
         .AppendLine("      ,CC.Observacion")
         .AppendLine("  FROM CuentasCorrientes CC")
         .AppendLine("        INNER JOIN CuentasCorrientesPagos CCP ON CC.IdSucursal = CCP.IdSucursal")
         .AppendLine("                                               AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("                                               AND CC.Letra = CCP.Letra")
         .AppendLine("                                               AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("                                               AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine("        INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

         .AppendLine("  WHERE CC.IdSucursal = " & idSucursal.ToString())

         If idCliente > 0 Then
            .AppendLine("	AND CC.idCliente = " & idCliente.ToString())
         End If

         If desde.HasValue Then
            .AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) >= '" & desde.Value.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), CC.Fecha, 120) <= '" & hasta.Value.ToString("yyyy-MM-dd") & "'")
         End If

         If importeTotal <> 0 Then
            .AppendLine("	AND CCP.ImporteCuota = " & importeTotal.ToString())
         End If

         If conSaldo Then
            .AppendLine("	AND CCP.SaldoCuota <> 0")
         End If

         'No debe informar los Recibos porque el Anticipos tiene el saldo.
         .AppendLine("	AND TC.EsRecibo = 'False'")

         .AppendLine("   AND (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO') ")

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("	 AND CC.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If letraFiscal <> "" Then
            .AppendLine("	 AND CC.Letra = '" & letraFiscal.ToString() & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("	 AND CC.CentroEmisor = " & centroEmisor.ToString())
         End If

         If numeroComprobanteDesde > 0 Then
            .AppendLine("	 AND CC.NumeroComprobante >= " & numeroComprobanteDesde.ToString())
         End If
         If numeroComprobanteHasta > 0 Then
            .AppendLine("	 AND CC.NumeroComprobante <= " & numeroComprobanteHasta.ToString())
         End If

         .AppendLine(" ORDER BY ")
         .AppendLine("	CC.Fecha")
         .AppendLine("   ,CC.IdTipoComprobante")
         .AppendLine("   ,CC.Letra")
         .AppendLine("   ,CC.CentroEmisor")
         .AppendLine("   ,CC.NumeroComprobante")
      End With

      Return GetDataTable(stb)
   End Function
   Public Function GetRecibosPorRangoFechas(sucursales As Entidades.Sucursal(),
                                            desde As Date, hasta As Date,
                                         idCliente As Long,
                                            idCategoria As Integer, categoria As Entidades.OrigenFK,
                                            idVendedor As Integer, vendedor As Entidades.OrigenFK,
                                         idTipoComprobante As String,
                                         idUsuario As String,
                                         idCaja As Integer,
                                            letraFiscal As String, centroEmisor As Integer,
                                            numeroComprobanteDesde As Long, numeroComprobanteHasta As Long,
                                         idZonaGeografica As String,
                                            idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                            idEstadoCliente As Integer, estdoCliente As Entidades.OrigenFK,
                                         nivelAutorizacion As Short,
                                         numeroReparto As Integer?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal")
         .AppendLine("      ,CC.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,CN.NombreCaja")
         .AppendLine("      ,CC.IdTipoComprobante")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor")
         .AppendLine("      ,CC.NumeroComprobante")

         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,CONVERT(Date, CC.Fecha) AS Fecha_Fecha")
         .AppendLine("      ,CONVERT(Time, CC.Fecha) AS Fecha_Hora")

         .AppendLine("      ,CC.FechaVencimiento")
         .AppendLine("      ,CONVERT(Date, CC.FechaVencimiento) AS FechaVencimiento_Fecha")
         .AppendLine("      ,CONVERT(Time, CC.FechaVencimiento) AS FechaVencimiento_Hora")

         .AppendLine("      ,CC.IdFormasPago")
         .AppendLine("      ,CC.ImporteTotal * (-1) as ImporteTotal")
         .AppendLine("      ,CC.Saldo")
         .AppendLine("      ,CC.CantidadCuotas")
         .AppendLine("      ,CC.ImportePesos")
         .AppendLine("      ,CC.ImporteTickets")
         .AppendLine("      ,CC.ImporteDolares")
         .AppendLine("      ,CC.ImporteEuros")
         .AppendLine("      ,CC.ImporteCheques")
         .AppendLine("      ,CC.ImporteTarjetas")
         .AppendLine("      ,CC.ImporteTransfBancaria")
         .AppendLine("      ,CB.NombreCuenta AS NombreCuentaBancaria")
         .AppendLine("      ,CC.ImporteRetenciones")
         .AppendLine("      ,CC.IdUsuario")
         .AppendLine("      ,CC.IdEstadoComprobante")
         .AppendLine("      ,CC.Observacion")
         .AppendLine("      ,CC.FechaActualizacion")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,CC.IdEjercicio")
         .AppendLine("      ,CC.IdPlanCuenta")
         .AppendLine("      ,CC.IdAsiento")
         .AppendLine("      ,E.NombreEmpleado")
         .AppendLine("      ,CC.MetodoGrabacion")
         .AppendLine("      ,CC.IdFuncion")

         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,Co.NombreEmpleado AS NombreCobrador")
         .AppendLine("      ,EC.NombreEstadoCliente")
         .AppendLine("      ,CC.ImporteDolares")
         .AppendLine("      ,CC.CotizacionDolar")
         .AppendLine("      ,CC.FechaTransferencia")
         .AppendLine("      ,CC.NumeroReparto")
         .AppendLine("      ,CC.NumeroOrdenCompra")

         .AppendLine("	FROM  CuentasCorrientes CC")

         .AppendLine("  LEFT JOIN CuentasBancarias CB ON CC.IdCuentaBancaria = CB.IdCuentaBancaria ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN CajasNombres CN ON CN.IdSucursal = CC.IdSucursal AND CN.IdCaja = CC.IdCaja")
         .AppendLine("  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")

         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor  ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = CC.IdVendedor ")
         End If

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If


         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  LEFT JOIN Empleados Co ON Co.IdEmpleado = C.IdCobrador  ")
         Else
            .AppendLine("  LEFT JOIN Empleados Co ON Co.IdEmpleado = CC.IdCobrador ")
         End If

         'If cobrador = Entidades.OrigenFK.Actual Then
         '   .AppendLine("  LEFT JOIN Cobradores Co ON Co.IdCobrador = C.IdCobrador")
         'Else
         '   .AppendLine("  LEFT JOIN Cobradores Co ON Co.IdCobrador = CC.IdCobrador")
         'End If

         If estdoCliente = Entidades.OrigenFK.Actual Then
            .AppendLine("  LEFT JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")
         Else
            .AppendLine("  LEFT JOIN EstadosClientes EC ON EC.IdEstadoCliente = CC.IdEstadoCliente")
         End If

         .AppendLine("  WHERE 1 = 1")
         GetListaSucursalesMultiples(stb, sucursales, "CC")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         .AppendLine("    AND  TC.EsRecibo = 'True'")
         .AppendFormatLine("	  AND CC.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("	  AND CC.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If idVendedor > 0 Then
            .AppendLine("	 AND E.IdEmpleado = " & idVendedor)
         End If

         If idCliente > 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND CAT.IdCategoria = " & idCategoria.ToString())
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	 AND CC.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("   AND CC.IdUsuario = '" & idUsuario & "'")
         End If

         If idCaja > 0 Then
            .AppendLine("   AND CC.IdCaja = " & idCaja.ToString())
         End If

         If letraFiscal <> "" Then
            .AppendLine("	 AND CC.Letra = '" & letraFiscal.ToString() & "'")
         End If

         If centroEmisor > 0 Then
            .AppendLine("	 AND CC.CentroEmisor = " & centroEmisor.ToString())
         End If

         If numeroComprobanteDesde > 0 Then
            .AppendLine("	 AND CC.NumeroComprobante >= " & numeroComprobanteDesde.ToString())
         End If
         If numeroComprobanteHasta > 0 Then
            .AppendLine("	 AND CC.NumeroComprobante <= " & numeroComprobanteHasta.ToString())
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idCobrador > 0 Then
            .AppendLine("   AND Co.IdEmpleado = " & idCobrador.ToString())
         End If

         If idEstadoCliente > 0 Then
            .AppendLine("   AND EC.IdEstadoCliente = " & idEstadoCliente.ToString())
         End If

         If numeroReparto.HasValue AndAlso numeroReparto.Value <> 0 Then
            .AppendFormatLine("   AND CC.NumeroReparto = {0}", numeroReparto.Value)
         End If

         .AppendLine("	ORDER BY CC.Fecha")
      End With

      Return GetDataTable(stb)
   End Function


   Public Function GetCobrSemana(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date, idCliente As Long,
                                 idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                 idCategoria As Integer, origenCategoria As Entidades.OrigenFK,
                                 idCobrador As Integer, origenCobrador As Entidades.OrigenFK,
                                 pivotcolName As String, sumPivoT As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT IdSucursal")
         .AppendFormatLine("      ,IdTipoComprobante2")
         .AppendFormatLine("      ,Letra2")
         .AppendFormatLine("      ,CentroEmisor2")
         .AppendFormatLine("      ,NumeroComprobante2")
         .AppendFormatLine("      ,CodigoCliente")
         .AppendFormatLine("      ,NombreCliente")
         .AppendFormatLine("      ,Direccion")
         .AppendFormatLine("      ,NombreVendedor")
         .AppendFormatLine("      ,NombreCobrador")
         .AppendFormatLine("      ,Fecha")
         .AppendFormatLine("      ,Saldo")
         .AppendFormatLine("      ,(SELECT NombreProducto + ' / '  FROM VentasProductos VP")
         .AppendFormatLine("         WHERE VP.IdSucursal = pvt.IdSucursal And VP.IdTipoComprobante = pvt.IdTipoComprobante2 And VP.Letra = pvt.Letra2")
         .AppendFormatLine("           AND VP.CentroEmisor = pvt.CentroEmisor2 AND VP.NumeroComprobante = pvt.NumeroComprobante2")
         .AppendFormatLine("           FOR XML PATH('')) NombreProductos")
         .AppendFormatLine("      ,{0}", sumPivoT)
         .AppendFormatLine("  FROM (SELECT CCP.IdSucursal")
         .AppendFormatLine("              ,CC.Fecha")
         .AppendFormatLine("              ,CC.Saldo")
         .AppendFormatLine("              ,CCP.IdTipoComprobante2")
         .AppendFormatLine("              ,CCP.Letra2")
         .AppendFormatLine("              ,CCP.CentroEmisor2")
         .AppendFormatLine("              ,CCP.NumeroComprobante2")
         .AppendFormatLine("              ,CONVERT(varchar(11), Datepart(year,  CCP.Fecha), 120) + '-' + CONVERT(varchar(11), Datepart(week,  CCP.Fecha), 120) AS AñoSem")
         .AppendFormatLine("              ,CCP.ImporteCuota * -1 AS ImporteCobrado")
         .AppendFormatLine("              ,C.CodigoCliente")
         .AppendFormatLine("              ,C.NombreCliente")
         .AppendFormatLine("              ,CCP.CuotaNumero2 AS Cuota")
         .AppendFormatLine("              ,E1.NombreEmpleado AS NombreVendedor")
         .AppendFormatLine("              ,CO.NombreEmpleado AS NombreCobrador")
         .AppendFormatLine("              ,C.Direccion")
         .AppendFormatLine("          FROM CuentasCorrientesPagos AS CCP")
         .AppendFormatLine("         INNER JOIN CuentasCorrientes AS CC ON CCP.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("                                           AND CCP.IdTipoComprobante2 = CC.IdTipoComprobante")
         .AppendFormatLine("                                           AND CCP.Letra2 = CC.Letra")
         .AppendFormatLine("                                           AND CCP.CentroEmisor2 = CC.CentroEmisor")
         .AppendFormatLine("                                           AND CCP.NumeroComprobante2 = CC.NumeroComprobante")
         '.AppendFormatLine("                                           AND CC.Saldo <> 0")
         .AppendFormatLine("         INNER JOIN Clientes AS C ON CC.IdCliente = C.IdCliente")
         If origenVendedor = Entidades.OrigenFK.Movimiento Then
            .AppendFormatLine("         INNER JOIN Empleados AS E1 ON CC.IdVendedor = E1.IdEmpleado ")
         Else
            .AppendFormatLine("         INNER JOIN Empleados AS E1 ON C.IdVendedor = E1.IdEmpleado ")
         End If
         If origenCobrador = Entidades.OrigenFK.Movimiento Then
            .AppendFormatLine("         INNER JOIN Empleados AS CO ON CO.IdEmpleado = CC.IdCobrador")
         Else
            .AppendFormatLine("         INNER JOIN Empleados AS CO ON CO.IdEmpleado = C.IdCobrador")
         End If
         If origenCobrador = Entidades.OrigenFK.Movimiento Then
            .AppendFormatLine("         INNER JOIN Categorias AS CAT ON CAT.IdCategoria = CC.IdCategoria")
         Else
            .AppendFormatLine("         INNER JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         End If
         .AppendFormatLine("         INNER JOIN Tiposcomprobantes AS TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine("         INNER JOIN Tiposcomprobantes AS TC2 ON CCP.IdTipoComprobante2 = TC2.IdTipoComprobante")
         .AppendFormatLine("         WHERE (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')")

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         ' .AppendFormatLine("           AND ( CCP.fecha >= '{0}') AND ( CCP.fecha <= '{1}')", ObtenerFecha(desde, False), ObtenerFecha(hasta.Date.AddDays(1).AddSeconds(-1), True))

         If idCliente <> 0 Then
            .AppendFormatLine("           AND CC.IdCliente = {0}", idCliente)
         End If

         If idCobrador <> 0 Then
            .AppendFormatLine("           AND CO.IdEmpleado = {0}", idCobrador)
         End If

         If idCategoria <> 0 Then
            .AppendFormatLine("           AND CAT.IdCategoria = {0}", idCategoria)
         End If

         If idVendedor > 0 Then
            .AppendFormatLine("           AND E1.IdEmpleado = {0}", idVendedor)
         End If

         .AppendFormatLine("         ) AS tbl")
         .AppendFormatLine("      PIVOT (SUM(ImporteCobrado) FOR [AñoSem] IN ({0})) AS pvt", pivotcolName)
         .AppendFormatLine(" GROUP BY IdSucursal")
         .AppendFormatLine("         ,IdTipoComprobante2")
         .AppendFormatLine("         ,Letra2")
         .AppendFormatLine("         ,CentroEmisor2")
         .AppendFormatLine("         ,NumeroComprobante2")
         .AppendFormatLine("         ,CodigoCliente")
         .AppendFormatLine("         ,NombreCliente")
         .AppendFormatLine("         ,NombreVendedor")
         .AppendFormatLine("         ,NombreCobrador")
         .AppendFormatLine("         ,Saldo")
         .AppendFormatLine("         ,Fecha")
         .AppendFormatLine("         ,Direccion")
         .AppendFormatLine(" ORDER BY Fecha")
      End With

      Return GetDataTable(stb)
   End Function

   Public Sub CuentasCorrientes_ModificaCtaCte(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                               referencia As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientes ")
         .AppendFormatLine("   SET Referencia = '{0}'", referencia)
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and Letra = '{0}'", letra)
         .AppendFormatLine("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientes")

   End Sub

   Public Function GetCtasCtesParaPMC(idSucursal As Integer, periodo? As Date,
                                      categorias As Entidades.Categoria(), tipoLiquidacion? As Integer,
                                      numeroDesde As Long, numeroHasta As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal")
         .AppendLine(" ,CC.IdVendedor")
         .AppendLine(" ,E.NombreEmpleado as NombreVendedor")
         .AppendLine(" ,CC.IdCliente")
         .AppendLine(" ,C.CodigoCliente")
         .AppendLine(" ,C.NombreCliente")
         .AppendLine(" ,Ca.NombreCategoria")
         .AppendLine(" ,'' AS NombreZonaGeografica")
         .AppendLine(" ,CC.IdTipoComprobante")
         .AppendLine(" ,LTRIM(TC.Descripcion) AS DescripcionTipoComprobante")
         .AppendLine(" ,CC.Letra")
         .AppendLine(" ,CC.CentroEmisor")
         .AppendLine(" ,CC.NumeroComprobante")
         .AppendLine(" ,CC.Fecha")
         .AppendLine(" ,CC.FechaVencimiento")
         .AppendLine(" ,CC.ImporteTotal")
         .AppendLine(" ,CC.Saldo")
         .AppendLine(" ,CC.IdFormasPago")
         .AppendLine(" ,VFP.DescripcionFormasPago")
         .AppendLine(" ,CC.Observacion")
         .AppendLine(" ,I.TipoImpresora")
         .AppendLine(" ,CASE WHEN (CF.SolicitaCUIT = 0) THEN C.NroDocCliente ELSE C.CUIT END AS ReferenciaPMC")
         .AppendLine(" ,0 as CuotaNumero")
         .AppendLine(" FROM CuentasCorrientes CC")

         'If ultimoPeriodo > 0 Then
         '   .AppendFormat(" INNER JOIN (SELECT * FROM LiquidacionesCargos C WHERE C.PeriodoLiquidacion = {0} AND (C.TipoLiquidacion = 'U' OR C.TipoLiquidacion = 'E')) AS C ON CC.IdCliente = C.IdCliente ", ultimoPeriodo.ToString()).AppendLine()
         'Else
         .AppendLine(" INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         '  End If
         .AppendLine("	 LEFT JOIN LiquidacionesCargos LC ON LC.IdSucursal = CC.IdSucursal AND LC.IdTipoComprobante = CC.IdTipoComprobante AND LC.Letra = CC.Letra ")
         .AppendLine("							 AND LC.CentroEmisor = CC.CentroEmisor AND  LC.NumeroComprobante = CC.NumeroComprobante")
         .AppendLine("	 LEFT JOIN TiposLiquidaciones TL ON TL.IdTipoLiquidacion = LC.IdTipoLiquidacion ")
         .AppendLine(" INNER JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago")
         .AppendLine(" INNER JOIN Categorias Ca ON C.IdCategoria = Ca.IdCategoria")
         .AppendLine(" INNER JOIN Impresoras I ON I.CentroEmisor = CC.CentroEmisor AND I.IdSucursal = CC.IdSucursal")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")

         .AppendLine(" WHERE CC.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND TC.EsAnticipo = 'False'")

         If numeroDesde > 0 Then
            .AppendFormatLine("   AND CC.NumeroComprobante >= {0}", numeroDesde)
         End If
         If numeroHasta > 0 Then
            .AppendFormatLine("   AND CC.NumeroComprobante <= {0}", numeroHasta)
         End If

         GetListaCategoriasMultiples(stb, categorias, "C")

         'Los CYO son en Negro (por ahora) y deben incluirlos
         .AppendLine("   AND (TC.GrabaLibro = 'True' OR (TC.GrabaLibro = 'False' AND I.PorCtaOrden = 'True'))")

         .AppendLine("   AND CC.Saldo > 0 ")
         .AppendLine("   AND C.Activo = 1")

         If tipoLiquidacion.HasValue Then
            .AppendLine("	 AND LC.IdTipoLiquidacion = " & tipoLiquidacion.Value.ToString())
         End If
         If periodo.HasValue Then
            .AppendLine("	 AND LC.PeriodoLiquidacion = " & periodo.Value.ToString("yyyyMM"))
         End If
         .AppendLine(" ORDER BY E.NombreEmpleado ")
         .AppendLine(" ,CC.IdVendedor ")
         .AppendLine(" ,C.NombreCliente ")
         .AppendLine(" ,C.CodigoCliente ")
         .AppendLine(" ,CC.Fecha")
         '.AppendLine(" ,CC.IdTipoComprobante")
         '.AppendLine(" ,CC.Letra")
         '.AppendLine(" ,CC.CentroEmisor")
         '.AppendLine(" ,CC.NumeroComprobante")

      End With

      Return GetDataTable(stb)
   End Function
   Public Function GetCtasCtesParaPMCRoela(idSucursal As Integer, periodo? As Date,
                                           categorias As Eniac.Entidades.Categoria(), tipoLiquidacion? As Integer,
                                           numeroDesde As Long, numeroHasta As Long, tipo As Entidades.CuentaCorriente.FormatoPMC) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal")
         .AppendLine(" ,CC.IdCliente")
         .AppendLine(" ,C.CodigoCliente")
         .AppendLine(" ,C.NombreCliente")
         .AppendLine(" ,Ca.NombreCategoria")
         .AppendLine(" ,C.CorreoElectronico")
         .AppendLine(" ,CC.IdTipoComprobante")
         .AppendLine(" ,LTRIM(TC.Descripcion) AS DescripcionTipoComprobante")
         .AppendLine(" ,CC.Letra")
         .AppendLine(" ,CC.CentroEmisor")
         .AppendLine(" ,CC.NumeroComprobante")
         .AppendLine(" ,CCP.CuotaNumero")
         .AppendLine(" ,CCP.FechaVencimiento")
         .AppendLine(" ,CCP.SaldoCuota as Saldo")
         .AppendLine(" ,CCP.ImporteCuota")
         .AppendLine(" ,CCP.FechaVencimiento2")
         .AppendLine(" ,CCP.ImporteVencimiento2")
         .AppendLine(" ,CCP.FechaVencimiento3")
         .AppendLine(" ,CCP.ImporteVencimiento3")
         .AppendLine(" ,CCP.CodigoDeBarra")
         .AppendLine("  ,I.TipoImpresora")
         .AppendLine(" ,C.CodigoCliente AS ReferenciaPMC")
         .AppendLine(" ,CC.Observacion")
         .AppendLine(" ,TC.CodigoRoela")
         .AppendLine(" ,CCP.CodigoDeBarraSirplus")
         .AppendLine(" FROM CuentasCorrientes CC")
         .AppendLine(" INNER JOIN CuentasCorrientesPagos CCP ON CCP.IdSucursal = CC.IdSucursal")
         .AppendLine(" AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine(" AND CCP.Letra = CC.Letra")
         .AppendLine(" AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendLine(" AND CCP.NumeroComprobante = CC.NumeroComprobante")
         'If ultimoPeriodo > 0 Then
         '   .AppendFormat(" INNER JOIN (SELECT * FROM LiquidacionesCargos C WHERE C.PeriodoLiquidacion = {0} AND (C.TipoLiquidacion = 'U' OR C.TipoLiquidacion = 'E')) AS C ON CC.IdCliente = C.IdCliente ", ultimoPeriodo.ToString()).AppendLine()
         'Else
         .AppendLine(" INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         '  End If
         .AppendLine("	 LEFT JOIN LiquidacionesCargos LC ON LC.IdSucursal = CC.IdSucursal AND LC.IdTipoComprobante = CC.IdTipoComprobante AND LC.Letra = CC.Letra ")
         .AppendLine("							 AND LC.CentroEmisor = CC.CentroEmisor AND  LC.NumeroComprobante = CC.NumeroComprobante")
         '   .AppendLine("	 LEFT JOIN TiposLiquidaciones TL ON TL.IdTipoLiquidacion = LC.IdTipoLiquidacion ")
         '  .AppendLine(" INNER JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         ' .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         '  .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         '  .AppendLine(" INNER JOIN VentasFormasPago VFP ON CC.IdFormasPago = VFP.IdFormasPago")
         .AppendLine(" INNER JOIN Categorias Ca ON C.IdCategoria = Ca.IdCategoria")
         .AppendLine(" INNER JOIN Impresoras I ON I.CentroEmisor = CC.CentroEmisor AND I.IdSucursal = CC.IdSucursal")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")

         .AppendLine(" WHERE CC.IdSucursal = " & idSucursal.ToString())

         If tipo = Entidades.CuentaCorriente.FormatoPMC.SIRPLUS Then
            .AppendLine("   AND CCP.CodigoDeBarraSirplus <> ''")
         Else
            .AppendLine("   AND CCP.CodigoDeBarra <> ''")
         End If
         .AppendLine("   AND TC.EsAnticipo = 'False'")


         If numeroDesde > 0 Then
            .AppendFormatLine("   AND CC.NumeroComprobante >= {0}", numeroDesde)
         End If
         If numeroHasta > 0 Then
            .AppendFormatLine("   AND CC.NumeroComprobante <= {0}", numeroHasta)
         End If

         GetListaCategoriasMultiples(stb, categorias, "C")

         'Los CYO son en Negro (por ahora) y deben incluirlos
         .AppendLine("   AND (TC.GrabaLibro = 'True' OR (TC.GrabaLibro = 'False' AND I.PorCtaOrden = 'True'))")

         .AppendLine("   AND CCP.SaldoCuota > 0 ")
         .AppendLine("   AND C.Activo = 1")

         'If TipoLiquidacion.HasValue Then
         '   .AppendLine("	 AND LC.IdTipoLiquidacion = " & TipoLiquidacion.Value.ToString())
         'End If
         If periodo.HasValue Then
            .AppendLine("	 AND LC.PeriodoLiquidacion = " & periodo.Value.ToString("yyyyMM"))
         End If
         .AppendLine(" ORDER BY C.NombreCliente ")
         .AppendLine(" ,C.CodigoCliente ")
         .AppendLine(" ,CC.Fecha")
         '.AppendLine(" ,CC.IdTipoComprobante")
         '.AppendLine(" ,CC.Letra")
         '.AppendLine(" ,CC.CentroEmisor")
         '.AppendLine(" ,CC.NumeroComprobante")

      End With

      Return GetDataTable(stb)
   End Function
   Public Sub CuentasCorrientes_U_DatosReserva(idSucursal As Integer,
                                               idTipoComprobante As String,
                                               letra As String,
                                               centroEmisor As Short,
                                               numeroComprobante As Long,
                                               fechaViaje As Date,
                                               establecimiento As String,
                                               programa As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientes ")
         If fechaViaje <> Nothing Then
            .AppendFormatLine("   SET FechaViaje = '{0}'", ObtenerFecha(fechaViaje, True))
         Else
            .AppendFormatLine("   SET FechaViaje = NULL")
         End If
         If Not String.IsNullOrEmpty(establecimiento) Then
            .AppendFormatLine("   ,NombreEstablecimiento = '{0}'", establecimiento)
         Else
            .AppendFormatLine("   ,NombreEstablecimiento = NULL")
         End If
         If Not String.IsNullOrEmpty(establecimiento) Then
            .AppendFormatLine("   ,NombrePrograma = '{0}'", programa)
         Else
            .AppendFormatLine("   ,NombrePrograma = NULL")
         End If
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery)
   End Sub

   Public Sub ActualizaFechaEnvioCorreo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                        fechaEnvioCorreo As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CuentasCorrientes SET ")
         If fechaEnvioCorreo.HasValue Then
            .AppendFormatLine("  FechaEnvioCorreo = '{0}'", ObtenerFecha(fechaEnvioCorreo.Value, True))
         Else
            .AppendFormatLine("  FechaEnvioCorreo = NULL")
         End If

         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND letra = '{0}'", letra)
         .AppendFormatLine("   AND centroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND numeroComprobante = {0}", numeroComprobante)

      End With

      Execute(myQuery)
   End Sub

   Public Function BuscarPendientes(idSucursal As Integer,
                                    idCliente As Long, categoria As Integer, buscaPorClienteVinculado As Boolean,
                                    tiposComprobantes As String, idTipoComprobante As String, letra As String, emisor As Short, numeroComprobante As Long, numeroComprobanteFinalizaCon As String,
                                    idTipoLiquidacion As Integer?, incluirPreElectronicos As Boolean,
                                    idEmbarcacion As Long, idCama As Long, crmNovedad As Entidades.CRMNovedad,
                                    seleccionMultiple As Boolean,
                                    ctaCteClientesPriorizarNCsyAnticipos As Boolean, ctaCteClientesSeparar As Boolean, soySisen As Boolean) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         If seleccionMultiple Then
            .AppendLine("SELECT CONVERT(bit, 0) SELEC, cc.IdSucursal AS Sucursal")
         Else
            .AppendLine("SELECT cc.IdSucursal AS Sucursal")
         End If
         .AppendLine("      ,cc.FechaVencimiento")
         .AppendLine("      ,TC.Descripcion AS Tipo")
         .AppendLine("      ,cc.Letra")
         .AppendLine("      ,cc.CentroEmisor AS Emisor")
         .AppendLine("      ,cc.NumeroComprobante AS Numero")
         .AppendLine("      ,cc.CuotaNumero AS Cuota")
         .AppendLine("      ,cc.Fecha")
         .AppendLine("      ,cc.ImporteCuota AS Importe")
         .AppendLine("      ,cc.SaldoCuota AS Saldo")
         .AppendLine("      ,cc.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")
         .AppendLine("      ,cc.Observacion")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,aa.Direccion")
         .AppendLine("      ,cc.IdTipoComprobante")
         .AppendLine("      ,aa.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,ISNULL(Mo.NombreMoneda, MoDef.NombreMoneda) NombreMoneda")
         '-- REQ-42455.- -----------------------------------------------------------------------------------
         .AppendLine("      ,aa.FechaPromedioCobro")
         .AppendLine("      ,aa.PromedioDiasCobro")
         .AppendLine("      ,aa.CantidadDiasCobro")
         '--------------------------------------------------------------------------------------------------
         If ctaCteClientesPriorizarNCsyAnticipos Then
            .AppendLine("       ,(CASE WHEN cc.ImporteCuota<0 THEN 1 ELSE 2 END) AS Prioridad")
         Else
            .AppendLine("       ,1 AS Prioridad")
         End If

         .AppendLine("      ,aa.IdCategoria")

         '-- REQ-32805.- --
         .AppendLine("      ,CONVERT(decimal(12,2), CC.SaldoCuota * dbo.CtaCtePorcDescRecSaldo(aa.IdCategoria, CC.Fecha, CC.FechaVencimiento, CC.Fecha, CC.ImporteCuota, CC.SaldoCuota) / 100) AS Interes")
         .AppendLine("      ,aa.NumeroOrdenCompra")

         .AppendLine("      ,cc.idEmbarcacion")
         .AppendLine("      ,cc.IdCama")

         If soySisen Then
            .AppendLine("      ,Emb.CodigoEmbarcacion")
            .AppendLine("      ,Emb.NombreEmbarcacion")
            .AppendLine("      ,Cam.CodigoCama")
            .AppendLine("      ,EmbC.IdEmbarcacion     IdEmbarcacionCama")
            .AppendLine("      ,EmbC.CodigoEmbarcacion CodigoEmbarcacionCama")
            .AppendLine("      ,EmbC.NombreEmbarcacion NombreEmbarcacionCama")
         Else
            .AppendLine("      ,NULL CodigoEmbarcacion")
            .AppendLine("      ,NULL NombreEmbarcacion")
            .AppendLine("      ,NULL CodigoCama")
            .AppendLine("      ,NULL IdEmbarcacionCama")
            .AppendLine("      ,NULL CodigoEmbarcacionCama")
            .AppendLine("      ,NULL NombreEmbarcacionCama")
         End If

         '--------------------------------------------------
         .AppendLine(" FROM CuentasCorrientes aa ")
         .AppendLine(" INNER JOIN CuentasCorrientesPagos cc ON cc.idsucursal=aa.idsucursal and cc.idtipocomprobante = aa.idtipocomprobante")
         .AppendLine("       AND cc.letra = aa.letra AND cc.centroemisor = aa.centroemisor AND cc.numerocomprobante = aa.numerocomprobante")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON aa.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON aa.IdFormasPago = VFP.IdFormasPago")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = aa.IdCliente")

         '##################

         .AppendLine("  LEFT JOIN Ventas V ON V.IdSucursal = AA.IdSucursal")
         .AppendLine("  AND V.IdTipoComprobante = AA.IdTipoComprobante")
         .AppendLine("  AND V.Letra = AA.Letra")
         .AppendLine("  AND V.CentroEmisor = AA.CentroEmisor")
         .AppendLine("  AND V.NumeroComprobante = AA.NumeroComprobante")
         .AppendLine("  LEFT JOIN Monedas Mo ON Mo.IdMoneda = V.IdMoneda")
         .AppendLine("  CROSS JOIN (SELECT NombreMoneda FROM Monedas WHERE IdMoneda = 1) MoDef")

         '##################

         If idTipoLiquidacion.HasValue Then
            .Append(" INNER JOIN LiquidacionesCargos LC ON LC.IdSucursal = CC.IdSucursal AND LC.IdTipoComprobante = CC.IdTipoComprobante AND LC.Letra = CC.Letra ")
            .Append("        AND LC.CentroEmisor = CC.CentroEmisor AND  LC.NumeroComprobante = CC.NumeroComprobante")
         End If

         If soySisen Then
            .AppendLine("LEFT JOIN Embarcaciones Emb ON Emb.IdEmbarcacion = aa.IdEmbarcacion")
            .AppendLine("LEFT JOIN Camas Cam ON Cam.IdCama = aa.IdCama")
            .AppendLine("LEFT JOIN Embarcaciones EmbC ON EmbC.IdCama = Cam.IdCama")
         End If

         .AppendLine(" WHERE aa.IdSucursal = " & idSucursal.ToString())

         If buscaPorClienteVinculado Then
            .AppendFormatLine("   AND aa.IdClienteCtaCte = {0}", idCliente)
         Else
            .AppendFormatLine("   AND aa.IdCliente = {0}", idCliente)
         End If

         If idTipoLiquidacion.HasValue Then
            .AppendFormat("	 AND LC.IdTipoLiquidacion = {0}", idTipoLiquidacion.Value)
         End If

         '-- REQ-33207.- --
         If idEmbarcacion <> 0 Then
            .AppendFormat("	 AND aa.IdEmbarcacion = {0}", idEmbarcacion)
         End If

         'Si el comprobante esta en la Cuenta Corriente, no debe mirar si es facturable.
         '.Append(" and tp.EsFacturable = 'False'")
         .AppendLine("   and cc.SaldoCuota <> 0")     'Positivos: Factura y Nota Debito, Negativo: Nota Credito.
         .AppendLine("   and TC.EsRecibo = 'False'")

         If Not String.IsNullOrWhiteSpace(numeroComprobanteFinalizaCon) Then
            .AppendFormatLine("     AND CC.NumeroComprobante LIKE '%{0}'", numeroComprobanteFinalizaCon)
         End If

         If ctaCteClientesSeparar And Not String.IsNullOrWhiteSpace(tiposComprobantes) Then
            '.AppendLine("   AND tp.GrabaLibro = '" & grabaLibro & "'")
            .AppendLine("   AND TC.IdTipoComprobante IN (" & tiposComprobantes & ")")
         End If

         '.AppendLine("   AND NOT (tp.EsElectronico = 'True' AND tp.CoeficienteStock = 0)") 'Los Pre-Electronicos no deben ser imputados.
         If Not incluirPreElectronicos Then
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If idCama <> 0 Then
            .AppendFormatLine(" AND aa.IdCama = {0} ", idCama)
         End If

         If categoria <> 0 Then
            .AppendLine("AND aa.IdCategoria = " & categoria)
         End If

         If numeroComprobante <> 0 Then
            If idTipoComprobante <> "" Then
               .AppendLine("AND aa.NumeroComprobante = " & numeroComprobante)
            Else
               .AppendLine("AND aa.NumeroComprobante LIKE '%" & numeroComprobante & "%'")
            End If

         End If

         If idTipoComprobante <> "" Then
            .AppendLine("AND aa.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If letra <> "" Then
            .AppendLine("AND aa.Letra = '" & letra & "'")
         End If

         If emisor <> 0 Then
            .AppendLine("AND aa.CentroEmisor = " & emisor)
         End If

         If crmNovedad IsNot Nothing Then
            .AppendFormatLine("   AND (aa.IdTipoNovedad = '{0}' AND aa.Letra = '{1}' AND aa.CentroEmisor = {2} AND aa.NumeroNovedad = {3})",
                              crmNovedad.IdTipoNovedad, crmNovedad.Letra, crmNovedad.CentroEmisor, crmNovedad.IdNovedad)
         End If

         .AppendLine(" ORDER BY Prioridad")
         .AppendLine("          ,CONVERT(varchar(11), cc.FechaVencimiento, 120)")
         .AppendLine("          ,TC.Descripcion")
         .AppendLine("          ,cc.Letra")
         .AppendLine("          ,cc.CentroEmisor")
         .AppendLine("          ,cc.NumeroComprobante")
         .AppendLine("          ,cc.CuotaNumero")
      End With

      Return GetDataTable(stbQuery)

   End Function

   Public Function GetRecibosDelComprobante(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine(" WHERE CCP.IdSucursal           =  {0} ", idSucursal)
         .AppendFormatLine("   AND CCP.IdTipoComprobante2   = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCP.Letra2               = '{0}'", letra)
         .AppendFormatLine("   AND CCP.CentroEmisor2        =  {0} ", centroEmisor)
         .AppendFormatLine("   AND CCP.NumeroComprobante2   =  {0} ", numeroComprobante)
         .AppendFormatLine("   AND TC.EsRecibo              = 'True'")
      End With
      Return GetDataTable(stb)
   End Function


   Public Function GetNumeroMaximo(idEmpresa As Integer,
                                   idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letraFiscal As String,
                                   emisor As Short,
                                   comparteNumeracion As Boolean) As Long
      Dim stbCondicion = New StringBuilder()
      With stbCondicion
         .AppendFormat("     CC.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat(" AND CC.Letra = '{0}'", letraFiscal)
         .AppendFormat(" AND CC.CentroEmisor = {0}", emisor)
         .AppendFormat(" AND EXISTS (SELECT * FROM Sucursales S WHERE S.IdSucursal = CC.IdSucursal AND S.IdEmpresa = {0})", idEmpresa)
         .AppendFormat(" AND (CC.IdSucursal = {0}", idSucursal)
         If comparteNumeracion Then
            .AppendFormat("    OR CC.IdSucursal = 0")
         End If
         .AppendLine(")")
      End With

      Return GetCodigoMaximo("NumeroComprobante", "CuentasCorrientes CC", stbCondicion.ToString())
   End Function

   Public Sub AjustaSaldoLuegoSegunPagos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE CC")
         .AppendFormatLine("   SET Saldo = (SELECT SUM(SaldoCuota)")
         .AppendFormatLine("                  FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine("                 WHERE CCP.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("                   AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("                   AND CCP.Letra = CC.Letra")
         .AppendFormatLine("                   AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendFormatLine("                   AND CCP.NumeroComprobante = CC.NumeroComprobante)")
         .AppendFormatLine("  FROM CuentasCorrientes CC")
         .AppendFormatLine(" WHERE CC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CC.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CC.Letra = '{0}'", letra)
         .AppendFormatLine("   AND CC.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND CC.NumeroComprobante = {0}", numeroComprobante)
      End With
      Execute(stb)

   End Sub

End Class