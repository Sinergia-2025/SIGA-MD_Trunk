Public Class Ventas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Ventas_I(idSucursal As Integer,
                       idTipoComprobante As String,
                       letra As String,
                       centroEmisor As Integer,
                       numeroComprobante As Long,
                       fecha As Date,
                       IdVendedor As Integer,
                       subTotal As Double,
                       totalImpuestos As Decimal,
                       importeTotal As Double,
                       descuentoRecargo As Double,
                       importeBruto As Double,
                       descuentoRecargoPorc As Double,
                       idCategoriaFiscal As Short,
                       idFormasPago As Integer,
                       observacion As String,
                       idEstadoComprobante As String,
                       importePesos As Decimal,
                       importeDolares As Decimal,
                       importeTickets As Decimal,
                       importeTarjetas As Decimal,
                       importeCheques As Decimal,
                       kilos As Decimal,
                       bultos As Integer,
                       valorDeclarado As Decimal,
                       idTransportista As Integer,
                       numeroLote As Long,
                       cantidadInvocados As Integer,
                       cantidadLotes As Integer,
                       usuario As String,
                       utilidad As Decimal,
                       cotizacionDolar As Decimal,
                       comisionVendedor As Decimal,
                       mercDespachada As Boolean,
                       importeTransfBancaria As Decimal,
                       idCuentaBancaria As Integer,
                       idActividad As Integer,
                       idProveedor As Long,
                       EsCtaOrden As Boolean,
                       fechaEnvio As Date,
                       numeroReparto As Integer,
                       fechaRendicion As Date,
                       idCliente As Long,
                       fechaActualizacion As Date,
                       direccionCliente As String,
                       idLocalidad As Integer,
                       idCategoria As Integer,
                       totalImpuestoInterno As Decimal,
                       metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                       idFuncion As String,
                       saldoActualCtaCte As Decimal?,
                       saldoActualCtaCteUnificado As Decimal?,
                       numeroOrdenCompra As Long,
                       idMoneda As Integer,
                       idClienteVinculado As Long,
                       nombreCliente As String,
                       cuit As String,
                       tipoDocCliente As String,
                       nroDocCliente As Long,
                       fechaTransferencia As Date?,
                       palets As Integer,
                       cbu As String,
                       cbuAlias As String,
                       referenciaComercial As String,
                       anulacionFCE As Boolean?,
                       nroVersionAplicacion As String,
                       idCobrador As Integer,
                       descuentoRecargoPorcManual As Boolean,
                       idPaciente As Long?,
                       idDoctor As Long?,
                       fechaCirugia As Date?,
                       idAFIPReferenciaTransferencia As String,
                       idIcotermExportacion As String,
                       idDestinoExportacion As String,
                       esFacturaExportacion As Boolean?,
                       fechaPagoExportacion As Date?,
                       IdEmbarcacion As Long,
                       CodigoEmbarcacion As Long,
                       NombreEmbarcacion As String,
                       IdCategoriaEmbarcacion As Integer,
                       NombreCategoriaEmbarcacion As String,
                       idTransportistaTransporte As Integer,
                       idChoferTransporte As Integer,
                       patenteVehiculoTransporte As String,
                       idConceptoCM05 As Integer?,
                       nroFacturaProveedor As String,
                       nroRemitoProveedor As String,
                       nroRepartoInvocacionMasiva As Integer,
                       IdCama As Long,
                       CodigoCama As String,
                       IdNave As Short,
                       NombreNave As String,
                       IdCategoriaCama As Integer,
                       NombreCategoriaCama As String, IdDomicilio As Integer?,
                       FechaVencimiento As DateTime?, ImporteCuota As Decimal?,
                       FechaVencimiento2 As DateTime?, ImporteCuota2 As Decimal?,
                       FechaVencimiento3 As DateTime?, ImporteCuota3 As Decimal?,
                       CodigoBarra As String, CodigoBarraSP As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO Ventas")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdTipoComprobante")
         .AppendLine("           ,Letra")
         .AppendLine("           ,CentroEmisor")
         .AppendLine("           ,NumeroComprobante")
         .AppendLine("           ,Fecha")
         .AppendLine("           ,IdVendedor")
         .AppendLine("           ,SubTotal")
         .AppendLine("           ,DescuentoRecargo")
         .AppendLine("           ,TotalImpuestos")
         .AppendLine("           ,ImporteTotal")
         .AppendLine("           ,IdCategoriaFiscal")
         .AppendLine("           ,IdFormasPago")
         .AppendLine("           ,Observacion")
         .AppendLine("           ,ImporteBruto")
         .AppendLine("           ,DescuentoRecargoPorc")
         .AppendLine("           ,IdEstadoComprobante")
         .AppendLine("           ,ImportePesos")
         .AppendLine("           ,ImporteDolares")
         .AppendLine("           ,ImporteTickets")
         .AppendLine("           ,ImporteTarjetas")
         .AppendLine("           ,ImporteCheques")
         .AppendLine("           ,Kilos")
         .AppendLine("           ,Bultos")
         .AppendLine("           ,ValorDeclarado")
         .AppendLine("           ,IdTransportista")
         .AppendLine("           ,NumeroLote")
         .AppendLine("           ,CantidadInvocados")
         .AppendLine("           ,CantidadLotes")
         .AppendLine("           ,Usuario")
         .AppendLine("           ,Utilidad")
         .AppendLine("           ,CotizacionDolar")
         .AppendLine("           ,ComisionVendedor")
         .AppendLine("           ,FechaAlta")
         .AppendLine("           ,MercDespachada")
         .AppendLine("           ,importeTransfBancaria")
         .AppendLine("           ,idCuentaBancaria")
         .AppendLine("           ,IdActividad")
         .AppendLine("           ,IdProveedor")
         .AppendLine("           ,EsCtaOrden")
         .AppendLine("           ,FechaEnvio")
         .AppendLine("           ,NumeroReparto")
         .AppendLine("           ,FechaRendicion")
         .AppendLine("           ,IdCliente")
         .AppendLine("           ,FechaActualizacion")
         .AppendLine("           ,Direccion")
         .AppendLine("           ,IdLocalidad")
         .AppendLine("           ,IdCategoria")
         .AppendLine("           ,TotalImpuestoInterno")
         .AppendLine("           ,MetodoGrabacion")
         .AppendLine("           ,IdFuncion")
         .AppendLine("           ,SaldoActualCtaCte")
         .AppendLine("           ,SaldoActualCtaCteUnificado")
         .AppendLine("           ,NumeroOrdenCompra")
         '     .AppendLine("           ,IdCobrador")
         .AppendLine("           ,IdMoneda")
         .AppendLine("           ,IdClienteVinculado")
         .AppendLine("           ,NombreCliente")
         .AppendLine("           ,Cuit")
         .AppendLine("           ,TipoDocCliente")
         .AppendLine("           ,NroDocCliente")
         .AppendLine("           ,FechaTransferencia")
         .AppendLine("           ,Palets")
         .AppendLine("           ,Cbu")
         .AppendLine("           ,CbuAlias")
         .AppendLine("           ,ReferenciaComercial")
         .AppendLine("           ,AnulacionFCE")
         .AppendLine("           ,NroVersionAplicacion")
         .AppendLine("           ,IdCobrador")
         .AppendFormatLine("     ,{0}", Entidades.Venta.Columnas.DescuentoRecargoPorcManual.ToString())
         .AppendFormatLine("     ,IdPaciente")
         .AppendFormatLine("     ,IdDoctor")
         .AppendFormatLine("     ,FechaCirugia")
         .AppendFormatLine("     ,IdAFIPReferenciaTransferencia")
         '-- REQ-31198.- -------------------------------------------
         .AppendFormatLine("     ,IdIcotermExportacion")
         .AppendFormatLine("     ,IdDestinoExportacion")
         .AppendFormatLine("     ,EsFacturaExportacion")
         '----------------------------------------------------------
         .AppendFormatLine("     ,FechaPagoExportacion")

         '-- REQ-33373.- -------------------------------------------
         .AppendFormatLine("  ,IdEmbarcacion")
         .AppendFormatLine("  ,CodigoEmbarcacion")
         .AppendFormatLine("  ,NombreEmbarcacion")
         .AppendFormatLine("  ,IdCategoriaEmbarcacion")
         .AppendFormatLine("  ,NombreCategoriaEmbarcacion")
         '-- REQ-33532.- -------------------------------------------
         .AppendFormatLine("  ,IdTransportistaTransporte")
         .AppendFormatLine("  ,IdChoferTransporte")
         .AppendFormatLine("  ,PatenteVehiculoTransporte")
         '----------------------------------------------------------
         .AppendFormatLine("  ,IdConceptoCM05")
         '-- REQ-34676.- -------------------------------------------
         .AppendFormatLine("  ,NroFacturaProveedor")
         .AppendFormatLine("  ,NroRemitoProveedor")
         '-- REQ-34676.- -------------------------------------------
         .AppendFormatLine("  ,NroRepartoInvocacionMasiva")
         '-- REQ-36331.- -------------------------------------------
         .AppendFormatLine("  ,IdCama")
         .AppendFormatLine("  ,CodigoCama")
         .AppendFormatLine("  ,IdNave")
         .AppendFormatLine("  ,NombreNave")
         .AppendFormatLine("  ,IdCategoriaCama")
         .AppendFormatLine("  ,NombreCategoriaCama")
         '----------------------------------------------------------
         .AppendFormatLine("  ,IdDomicilio")

         '----------------------------------------------------------
         .AppendFormatLine("  ,FechaVencimiento")
         .AppendFormatLine("  ,ImporteCuota")
         .AppendFormatLine("  ,FechaVencimiento2")
         .AppendFormatLine("  ,ImporteVencimiento2")
         .AppendFormatLine("  ,FechaVencimiento3")
         .AppendFormatLine("  ,ImporteVencimiento3")
         .AppendFormatLine("  ,CodigoDeBarra")
         .AppendFormatLine("  ,CodigoDeBarraSirplus")
         '----------------------------------------------------------




         .Append("           )")
         .Append("     VALUES (")

         .AppendFormat("           {0}", idSucursal)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,{0}", centroEmisor)
         .AppendFormat("           ,{0}", numeroComprobante)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fecha, True))
         .AppendFormat("           ,{0}", IdVendedor)
         .AppendFormat("           ,{0}", subTotal)
         .AppendFormat("           ,{0}", descuentoRecargo)
         .AppendFormat("           ,{0}", totalImpuestos)
         .AppendFormat("           ,{0}", importeTotal)
         .AppendFormat("           ,{0}", idCategoriaFiscal)
         .AppendFormat("           ,{0}", idFormasPago)
         .AppendFormat("           ,{0}", Me.GetStringParaQueryConComillas(observacion))
         .AppendFormat("           ,{0}", importeBruto)
         .AppendFormat("           ,{0}", descuentoRecargoPorc)
         .AppendFormat("           ,{0}", Me.GetStringParaQueryConComillas(idEstadoComprobante))
         .AppendFormat("           ,{0}", importePesos)
         .AppendFormat("           ,{0}", importeDolares)
         .AppendFormat("           ,{0}", importeTickets)
         .AppendFormat("           ,{0}", importeTarjetas)
         .AppendFormat("           ,{0}", importeCheques)
         .AppendFormat("           ,{0}", kilos)
         .AppendFormat("           ,{0}", bultos)
         .AppendFormat("           ,{0}", valorDeclarado)
         .AppendFormat("           ,{0}", Me.GetInt32ParaQuery(idTransportista))
         .AppendFormat("           ,{0}", numeroLote)
         .AppendFormat("           ,{0}", cantidadInvocados)
         .AppendFormat("           ,{0}", cantidadLotes)
         .AppendFormat("           ,'{0}'", usuario)
         .AppendFormat("           ,{0}", utilidad)
         .AppendFormat("           ,{0}", cotizacionDolar)
         .AppendFormat("           ,{0}", comisionVendedor)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(Date.Now, True))
         .AppendFormat("           ,'{0}'", Me.GetStringFromBoolean(mercDespachada))
         .AppendFormat("           ,{0}", importeTransfBancaria)
         If idCuentaBancaria > 0 Then
            .AppendFormat("           ,{0}", idCuentaBancaria)
         Else
            .AppendLine("           ,NULL")
         End If
         If idActividad > 0 Then
            .AppendFormat("           ,{0}", idActividad)
         Else
            .AppendLine("           ,NULL")
         End If
         If idProveedor > 0 Then
            .AppendFormat("           ,{0}", idProveedor)
         Else
            .AppendLine("           ,NULL")
         End If

         .AppendFormat("           ,{0}", GetStringFromBoolean(EsCtaOrden))

         If fechaEnvio > Date.Parse("1900-01-01") Then
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaEnvio, False))
         Else
            .AppendLine("           ,NULL")
         End If

         If numeroReparto > 0 Then
            .AppendFormat("           ,{0}", numeroReparto)
         Else
            .AppendLine("           ,NULL")
         End If

         If fechaRendicion > Date.Parse("1900-01-01") Then
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaRendicion, False))
         Else
            .AppendLine("           ,NULL")
         End If
         .AppendFormat("           ,{0}", idCliente)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaActualizacion, True))

         If Not String.IsNullOrEmpty(direccionCliente) Then
            .AppendFormat("           ,'{0}'", direccionCliente)
            .AppendFormat("           ,{0}", idLocalidad)
         Else
            .AppendLine("           ,NULL")
            .AppendLine("           ,NULL")
         End If
         .AppendFormat("           ,{0}", idCategoria)
         .AppendFormat("           ,{0}", totalImpuestoInterno)
         .AppendFormat("           ,'{0}'", metodoGrabacion.ToString().Substring(0, 1))
         .AppendFormat("           ,'{0}'", idFuncion)
         If saldoActualCtaCte.HasValue Then
            .AppendFormat("           ,'{0}'", saldoActualCtaCte.Value)
         Else
            .AppendFormat("           ,NULL")
         End If
         .AppendFormatLine("           , {0} ", GetStringFromDecimal(saldoActualCtaCteUnificado))
         If numeroOrdenCompra <> 0 Then
            .AppendFormat("           ,{0}", numeroOrdenCompra)
         Else
            .AppendFormat("           ,NULL")
         End If
         .AppendFormatLine("           ,{0}", idMoneda)
         .AppendFormatLine("           ,{0}", If(idClienteVinculado > 0, idClienteVinculado.ToString(), "NULL"))
         .AppendFormat("              ,'{0}'", nombreCliente)

         If Not String.IsNullOrEmpty(cuit) Then
            .AppendFormat("           ,'{0}'", cuit)
         Else
            .AppendFormat("           ,NULL")
         End If
         If Not String.IsNullOrEmpty(tipoDocCliente) Then
            .AppendFormat("           ,'{0}'", tipoDocCliente)
         Else
            .AppendFormat("           ,NULL")
         End If

         If nroDocCliente <> 0 Then
            .AppendFormat("           ,{0}", nroDocCliente)
         Else
            .AppendFormat("           ,NULL")
         End If

         If fechaTransferencia.HasValue Then
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaTransferencia.Value, False))
         Else
            .AppendLine("           ,NULL")
         End If

         .AppendFormat("           ,{0}", palets)

         .AppendFormatLine("           ,{0}", GetStringParaQueryConComillas(cbu))
         .AppendFormatLine("           ,{0}", GetStringParaQueryConComillas(cbuAlias))
         .AppendFormatLine("           ,'{0}'", referenciaComercial)
         .AppendFormatLine("           ,{0}", GetStringFromBoolean(anulacionFCE))
         .AppendFormatLine("           ,'{0}'", nroVersionAplicacion)
         .AppendFormatLine("           ,{0}", idCobrador)
         .AppendFormatLine("           ,{0}", GetStringFromBoolean(descuentoRecargoPorcManual))


         '# STAR MEDICAL HISTORIA CLINICA
         '-----------------------------------------
         If idPaciente.HasValue Then
            .AppendFormatLine("           ,{0}", idPaciente.Value)
         Else
            .AppendFormatLine("           ,NULL")
         End If
         If idDoctor.HasValue Then
            .AppendFormatLine("           ,{0}", idDoctor.Value)
         Else
            .AppendFormatLine("           ,NULL")
         End If
         If fechaCirugia.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaCirugia.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If
         '-----------------------------------------

         .AppendFormatLine("           ,{0}", GetStringParaQueryConComillas(idAFIPReferenciaTransferencia))

         '-- REQ-31198.- --------------------------
         If Not String.IsNullOrEmpty(idIcotermExportacion) Then
            .AppendFormatLine("           ,'{0}'", idIcotermExportacion)
         Else
            .AppendFormat("           ,NULL")
         End If
         If Not String.IsNullOrEmpty(idDestinoExportacion) Then
            .AppendFormatLine("           ,'{0}'", idDestinoExportacion)
         Else
            .AppendFormat("           ,NULL")
         End If

         .AppendFormatLine("           ,{0}", GetStringFromBoolean(esFacturaExportacion))
         .AppendFormatLine("           ,{0}", ObtenerFecha(fechaPagoExportacion, False))
         '-- REQ-33373.- -------------------------------------------
         If IdEmbarcacion <> 0 Then
            .AppendFormat("   , {0}", IdEmbarcacion).AppendLine()
         Else
            .AppendFormat("   , NULL").AppendLine()
         End If
         If CodigoEmbarcacion <> 0 Then
            .AppendFormat("  , {0}", CodigoEmbarcacion).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(NombreEmbarcacion) Then
            .AppendFormat("  , '{0}'", NombreEmbarcacion).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         If IdCategoriaEmbarcacion <> 0 Then
            .AppendFormat("  , {0}", IdCategoriaEmbarcacion).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(NombreCategoriaEmbarcacion) Then
            .AppendFormat("  , '{0}'", NombreCategoriaEmbarcacion).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         '----------------------------------------------------------
         '-- REQ-33532.- -------------------------------------------
         If idTransportistaTransporte <> 0 Then
            .AppendFormat("   , {0}", idTransportistaTransporte).AppendLine()
         Else
            .AppendFormat("   , NULL").AppendLine()
         End If
         If idChoferTransporte <> 0 Then
            .AppendFormat("  , {0}", idChoferTransporte).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(patenteVehiculoTransporte) Then
            .AppendFormat("  , '{0}'", patenteVehiculoTransporte).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         '-----------------------------------------
         .AppendFormatLine("  ,  {0} ", GetStringFromNumber(idConceptoCM05))
         '-- REQ-34676.- --------------------------
         If Not String.IsNullOrWhiteSpace(nroFacturaProveedor) Then
            .AppendFormat("  , '{0}'", nroFacturaProveedor).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nroRemitoProveedor) Then
            .AppendFormat("  , '{0}'", nroRemitoProveedor).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         '-- REQ-34678.- --------------------------
         If nroRepartoInvocacionMasiva > 0 Then
            .AppendFormat("  , {0}", nroRepartoInvocacionMasiva).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         '-- REQ-36331.- -------------------------------------------
         If IdCama <> 0 Then
            .AppendFormat("   , {0}", IdCama).AppendLine()
         Else
            .AppendFormat("   , NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(CodigoCama) Then
            .AppendFormat("  , '{0}'", CodigoCama).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         If IdNave <> 0 Then
            .AppendFormat("   , {0}", IdNave).AppendLine()
         Else
            .AppendFormat("   , NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(NombreNave) Then
            .AppendFormat("  , '{0}'", NombreNave).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         If IdCategoriaCama <> 0 Then
            .AppendFormat("  , {0}", IdCategoriaCama).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(NombreCategoriaCama) Then
            .AppendFormat("  , '{0}'", NombreCategoriaCama).AppendLine()
         Else
            .AppendFormat("  , NULL").AppendLine()
         End If
         '----------------------------------------------------------
         If IdDomicilio.HasValue Then
            .AppendFormatLine("          ,{0}", IdDomicilio.Value)
         Else
            .AppendFormatLine("          ,NULL")
         End If
         '----------------------------------------------------------
         If FechaVencimiento.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(FechaVencimiento.Value, True))
            .AppendFormatLine("          ,{0}", ImporteCuota.Value)
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(FechaVencimiento2.Value, True))
            .AppendFormatLine("          ,{0}", ImporteCuota2.Value)
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(FechaVencimiento3.Value, True))
            .AppendFormatLine("          ,{0}", ImporteCuota3.Value)
         Else
            .AppendFormatLine("           ,NULL")
            .AppendFormatLine("           ,NULL")
            .AppendFormatLine("           ,NULL")
            .AppendFormatLine("           ,NULL")
            .AppendFormatLine("           ,NULL")
            .AppendFormatLine("           ,NULL")
         End If
         If CodigoBarra IsNot Nothing Or Not String.IsNullOrEmpty(CodigoBarra) Then
            .AppendFormatLine("          ,'{0}'", CodigoBarra)
         Else
            .AppendLine("           ,NULL")
         End If
         If CodigoBarraSP IsNot Nothing Or Not String.IsNullOrEmpty(CodigoBarraSP) Then
            .AppendFormatLine("          ,'{0}'", CodigoBarraSP)
         Else
            .AppendLine("           ,NULL")
         End If
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Ventas_U(idSucursal As Integer,
                       idTipoComprobante As String,
                       letra As String,
                       centroEmisor As Integer,
                       numeroComprobante As Long,
                       fecha As Date,
                       IdVendedor As Integer,
                       importeBruto As Double,
                       descuentoRecargo As Double,
                       descuentoRecargoPorc As Double,
                       subTotal As Double,
                       totalImpuestos As Double,
                       importeTotal As Double,
                       idCategoriaFiscal As Short,
                       idFormasPago As Integer,
                       observacion As String,
                       idEstadoComprobante As String,
                       importePesos As Decimal,
                       importeDolares As Decimal,
                       importeTickets As Decimal,
                       importeTarjetas As Decimal,
                       importeCheques As Decimal,
                       importeTransferencia As Decimal,
                       kilos As Decimal,
                       bultos As Integer,
                       valorDeclarado As Decimal,
                       idTransportista As Integer,
                       numeroLote As Long,
                       cantidadInvocados As Integer,
                       cantidadLotes As Integer,
                       usuario As String,
                       utilidad As Decimal,
                       cotizacionDolar As Decimal,
                       idCliente As Long,
                       totalImpuestoInterno As Decimal,
                       saldoActualCtaCte As Decimal?,
                       saldoActualCtaCteUnificado As Decimal?,
                       numeroOrdenCompra As Long,
                       idMoneda As Integer,
                       idClienteVinculado As Long,
                       nombreCliente As String,
                       Cuit As String,
                       TipoDocCliente As String,
                       NroDocCliente As Long,
                       cbu As String,
                       cbuAlias As String,
                       referenciaComercial As String,
                       anulacionFCE As Boolean?,
                       IdCobrador As Integer,
                       fechaActualizacion As Date,
                       descuentoRecargoPorcManual As Boolean,
                       idPaciente As Long?,
                       idDoctor As Long?,
                       fechaCirugia As Date?,
                       idAFIPReferenciaTransferencia As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      'NO todos los datos cambian, por ahora marco lo que no me parece, despues se vera.
      With myQuery
         .Append("UPDATE Ventas SET ")
         '.AppendFormat("  Fecha = '{0}'", Me.ObtenerFecha(fecha, True))
         '.AppendFormat("  ,TipoDocVendedor = '{0}'", tipoDocVendedor)
         '.AppendFormat("  ,NroDocVendedor = '{0}'", nroDocVendedor)
         .AppendFormat("  ImporteBruto = {0}", importeBruto.ToString())
         .AppendFormat("  ,DescuentoRecargo = {0}", descuentoRecargo.ToString())
         .AppendFormat("  ,DescuentoRecargoPorc = {0}", descuentoRecargoPorc.ToString())
         .AppendFormat("  ,SubTotal = {0}", subTotal.ToString())
         .AppendFormat("  ,TotalImpuestos = {0}", totalImpuestos.ToString())
         .AppendFormat("  ,ImporteTotal = {0}", importeTotal.ToString())
         '.AppendFormat("  ,IdCliente = {0}", idCliente)
         '.AppendFormat("  ,IdCategoriaFiscal = {0}", idCategoriaFiscal)
         '.AppendFormat("  ,IdFormasPago = {0}", idFormasPago)
         .AppendFormat("  ,Observacion = '{0}'", observacion)

         If Not String.IsNullOrEmpty(idEstadoComprobante) Then
            .AppendFormat(" ,idEstadoComprobante = '{0}'", idEstadoComprobante)
         Else
            .Append(" ,idEstadoComprobante = NULL")
         End If

         .AppendFormat("  ,ImportePesos = {0}", importePesos)
         .AppendFormat("  ,ImporteDolares = {0}", importeDolares)
         .AppendFormat("  ,ImporteTickets = {0}", importeTickets)
         .AppendFormat("  ,ImporteTarjetas = {0}", importeTarjetas)
         .AppendFormat("  ,ImporteCheques = {0}", importeCheques)
         .AppendFormatLine("  , ImporteTransfBancaria = {0}", importeTransferencia)
         .AppendFormat("  ,Kilos = {0}", kilos)

         .AppendFormat("  ,bultos = {0}", bultos)
         .AppendFormat("  ,valorDeclarado = {0}", valorDeclarado)

         If idTransportista > 0 Then
            .AppendFormat(" ,idTransportista = {0}", idTransportista)
         Else
            .AppendFormat("  ,idTransportista = NULL")
         End If

         .AppendFormat("  ,numeroLote = {0}", numeroLote)
         .AppendFormat("  ,cantidadInvocados = {0}", cantidadInvocados)
         .AppendFormat("  ,cantidadLotes = {0}", cantidadLotes)

         .AppendFormat("  ,Usuario = '{0}'", usuario)

         .AppendFormat("  ,Utilidad = {0}", utilidad)
         .AppendFormat("  ,cotizacionDolar = {0}", cotizacionDolar)
         .AppendFormat("  ,TotalImpuestoInterno = {0}", totalImpuestoInterno)
         If saldoActualCtaCte.HasValue Then
            .AppendFormat("  ,SaldoActualCtaCte = {0}", saldoActualCtaCte)
         Else
            .AppendFormat("  ,SaldoActualCtaCte = NULL")
         End If
         .AppendFormatLine("  , SaldoActualCtaCteUnificado = {0} ", GetStringFromDecimal(saldoActualCtaCteUnificado))
         If numeroOrdenCompra <> 0 Then
            .AppendFormat("  ,NumeroOrdenCompra = {0}", numeroOrdenCompra)
         Else
            .AppendFormat("  ,NumeroOrdenCompra = NULL")
         End If

         .AppendFormatLine("  ,IdMoneda = {0}", idMoneda)
         .AppendFormatLine("  ,IdClienteVinculado = {0}", If(idClienteVinculado > 0, idClienteVinculado.ToString(), "NULL"))
         .AppendFormat("  ,NombreCliente = '{0}'", nombreCliente)
         .AppendFormat("  ,Cuit = '{0}'", Cuit)
         .AppendFormat("  ,TipoDocCliente = '{0}'", TipoDocCliente)
         .AppendFormat("  ,NroDocCliente = {0}", NroDocCliente)

         .AppendFormat("  ,Cbu = {0}", GetStringParaQueryConComillas(cbu))
         .AppendFormat("  ,CbuAlias = {0}", GetStringParaQueryConComillas(cbuAlias))
         .AppendFormatLine("  ,ReferenciaComercial = '{0}'", referenciaComercial)
         .AppendFormatLine("  ,AnulacionFCE = {0}", GetStringFromBoolean(anulacionFCE))
         If IdCobrador <> 0 Then
            .AppendFormat("  ,IdCobrador = {0}", IdCobrador)
         Else
            .AppendFormat("  ,IdCobrador = NULL")
         End If
         .AppendFormatLine("  ,{0} = {1}", Entidades.Venta.Columnas.DescuentoRecargoPorcManual.ToString(), GetStringFromBoolean(descuentoRecargoPorcManual))
         .AppendFormatLine("           ,{0} = '{1}'", Entidades.Venta.Columnas.FechaActualizacion.ToString(), Me.ObtenerFecha(fechaActualizacion, True))

         '# STAR MEDICAL HISTORIA CLINICA
         '-----------------------------------------
         If idPaciente.HasValue Then
            .AppendFormat("  ,IdPaciente = {0}", idPaciente.Value)
         Else
            .AppendFormat("  ,IdPaciente = NULL")
         End If
         If idDoctor.HasValue Then
            .AppendFormat("  ,IdDoctor = {0}", idDoctor.Value)
         Else
            .AppendFormat("  ,IdDoctor = NULL")
         End If
         If fechaCirugia.HasValue Then
            .AppendFormat("  ,FechaCirugia = '{0}'", ObtenerFecha(fechaCirugia.Value, True))
         Else
            .AppendFormat("  ,FechaCirugia = NULL")
         End If
         '-----------------------------------------

         .AppendFormatLine("   ,IdAFIPReferenciaTransferencia = {0}", GetStringParaQueryConComillas(idAFIPReferenciaTransferencia))

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub U_CAE(idSucursal As Integer,
                    idTipoComprobante As String,
                    letra As String,
                    centroEmisor As Integer,
                    numeroComprobante As Long,
                    cae As String,
                    caeVencimiento As Date)

      Dim myQuery As StringBuilder = New StringBuilder()

      'NO todos los datos cambian, por ahora marco lo que no me parece, despues se vera.
      With myQuery
         .Append("UPDATE Ventas SET ")
         .AppendFormat("  CAE = '{0}'", cae)
         .AppendFormat("  ,CAEVencimiento = '{0}'", caeVencimiento.ToString("yyyyMMdd HH:mm:ss"))

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub
   Public Sub Actualizar_Palets(idSucursal As Integer,
                 idTipoComprobante As String,
                 letra As String,
                 centroEmisor As Integer,
                 numeroComprobante As Long,
                 palets As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Append("UPDATE Ventas SET ")
         .AppendFormat("  Palets = {0}", palets)

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub U_CodigoErrorAfip(idSucursal As Integer,
                         idTipoComprobante As String,
                         letra As String,
                         centroEmisor As Integer,
                         numeroComprobante As Long,
                         CodigoErrorAfip As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      'NO todos los datos cambian, por ahora marco lo que no me parece, despues se vera.
      With myQuery
         .Append("UPDATE Ventas SET ")
         .AppendFormat("  CodigoErrorAfip = '{0}'", CodigoErrorAfip.Replace("'"c, "´"c))

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub Ventas_D(idSucursal As Integer,
                        idTipoComprobante As String,
                        letra As String,
                        centroEmisor As Integer,
                        numeroComprobante As Long)

      Dim myQuery = New StringBuilder()

      ''Elimino los contactos que tiene la venta si tuviera
      With myQuery
         .AppendLine("DELETE FROM VentasClientesContactos ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())

      ''Elimino los permisos de embarque que tiene la venta si tuviera.- --
      With myQuery
         .AppendLine("DELETE FROM VentasExportacionEmbarque ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letraComprobante = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())

      'elimino puramente la venta.

      myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM Ventas ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Function Existe(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Short,
                          numeroComprobante As Long) As Boolean

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdSucursal FROM Ventas ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If

   End Function

   Public Function Ventas_G1(idSucursal As Integer,
                             idTipoComprobante As String,
                             letra As String,
                             centroEmisor As Integer,
                             numeroComprobante As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT V.*")
         .AppendFormatLine("     , TC.Descripcion DescripcionTipoComprobante")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("  FROM Ventas V")
         .AppendFormatLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("  INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine(" WHERE V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND V.Letra = '{0}'", letra)
         .AppendFormatLine("   AND V.CentroEmisor = '{0}'", centroEmisor)
         .AppendFormatLine("   AND V.NumeroComprobante = '{0}'", numeroComprobante)

      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetRemitosSinFacturar(sucursales As List(Of Entidades.Sucursal)) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT V.Fecha")
         .AppendFormatLine("     , V.IdSucursal S")
         .AppendFormatLine("     , V.IdTipoComprobante Comprobante")
         .AppendFormatLine("     , V.Letra")
         .AppendFormatLine("     , V.CentroEmisor Emisor")
         .AppendFormatLine("     , V.NumeroComprobante Número")
         .AppendFormatLine("     , C.CodigoCliente Código")
         .AppendFormatLine("     , C.NombreCliente Cliente")
         .AppendFormatLine("     , V.ImporteTotal Total")
         .AppendFormatLine("  FROM Ventas V")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente")
         .AppendFormatLine(" WHERE TC.CoeficienteStock < 0")
         .AppendFormatLine("   AND TC.InformaLibroIva = 'False'")
         .AppendFormatLine("   AND TC.ActualizaCtaCte = 'False'")
         .AppendFormatLine("   AND TC.AfectaCaja = 'False'")
         .AppendFormatLine("   AND TC.EsFacturable = 'True'")
         '--REQ-35890.- 
         .AppendFormatLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')") '-.PE-33134.- Se filtra por los nulls porque la consulta solo trae Remitos con estado Anulado o null. Si se filtra " <> "Anulado" no trae ningun registro.
         If sucursales IsNot Nothing AndAlso sucursales.Any() Then
            query.AppendFormatLine("   AND {0}.idSucursal IN ({1})", "V", String.Join(",", sucursales.ToList().ConvertAll(Function(m) m.IdSucursal)))
         End If
         '-------------
         'Verifico si no fue invodo por otra Venta (Factura Invoca Remito).
         .AppendFormatLine("    AND NOT EXISTS (SELECT 1")
         .AppendFormatLine("                      FROM VentasInvocados VV")
         .AppendFormatLine("                     WHERE VV.IdSucursalInvocado = V.IdSucursal")
         .AppendFormatLine("                       AND VV.IdTipoComprobanteInvocado = V.IdTipoComprobante")
         .AppendFormatLine("                       AND VV.LetraInvocado = V.Letra")
         .AppendFormatLine("                       AND VV.CentroEmisorInvocado = V.CentroEmisor")
         .AppendFormatLine("                       AND VV.NumeroComprobanteInvocado = V.NumeroComprobante)")

         'Pero si el remito invocó una factura tampoco lo muestro (Remito Invoca Factura) porque no va a ser invocado por nadie.
         .AppendFormatLine("    AND NOT EXISTS (SELECT 1")
         .AppendFormatLine("                      FROM VentasInvocados VV")
         .AppendFormatLine("                     INNER JOIN TiposComprobantes TVV ON TVV.IdTipoComprobante = VV.IdTipoComprobanteInvocado")
         .AppendFormatLine("                     WHERE VV.IdSucursal = V.IdSucursal")
         .AppendFormatLine("                       AND VV.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine("                       AND VV.Letra = V.Letra")
         .AppendFormatLine("                       AND VV.CentroEmisor = V.CentroEmisor")
         .AppendFormatLine("                       AND VV.NumeroComprobante = V.NumeroComprobante")
         .AppendFormatLine("                       AND TVV.EsComercial = 'True')")  'Me fijo solo los invocados Comerciales porque que un remito invoque un presupuesto está bien.

      End With
      Return GetDataTable(query)
   End Function

   Public Function ClientePoseeFacturas(idCliente As Long) As Boolean
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT COUNT(*) AS ExisteFact")
         .AppendLine("  FROM Ventas V")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" WHERE (TC.GrabaLibro = 1 ")
         .AppendLine("  OR TC.EsPreElectronico = 1")
         .AppendLine("  OR TC.EsPreFiscal = 1)")
         .AppendFormat("   AND V.IdCliente = '{0}'", idCliente)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If Integer.Parse(dt.Rows(0)(0).ToString()) > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Sub ActualizaFechaExportacion(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        centroEmisor As Long,
                                        letra As String,
                                        numeroComprobante As Long,
                                        fechaExportacion As Date)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE V SET V.FechaExportacion = '{0}'", ObtenerFecha(fechaExportacion, True))
         .AppendFormatLine(" FROM Ventas V ")
         .AppendFormatLine(" WHERE V.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND V.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND V.Letra = '{0}'", letra)
         .AppendFormatLine("   AND V.NumeroComprobante = {0}", numeroComprobante)
      End With
      Me.Execute(query.ToString())
   End Sub
End Class