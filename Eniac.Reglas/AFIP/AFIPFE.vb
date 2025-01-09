Imports System.Xml
Public Class AFIPFE
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Eniac.Datos.DataAccess)
      da = accesoDatos
      Me._urlFE = New Parametros().GetValorPD(Entidades.Parametro.Parametros.URLWSFE.ToString(), String.Empty)
   End Sub

#End Region

#Region "Campos"

   Private _idRequerimiento As Long = 0
   Private _urlFE As String
   Private _autorizacionV1 As WSFEv1.FEAuthRequest
   Private _redondeo As Integer = 2

#End Region

#Region "Metodos comunes"

   Private Function GetMotivo(codigo As String) As String
      Select Case codigo
         Case "01"
            Return "La CUIT informada no corresponde a un Responsable Inscripto en el IVA activo."
         Case "02"
            Return "La CUIT informada no se encuentra autorizada a emitir comprobantes electrónicos originales o el período de inicio autorizado es posterior al de la generación de la solicitud."
         Case "03"
            Return "La CUIT informada registra inconvenientes con el domicilio fiscal."
         Case "04"
            Return "El punto de venta informado no se encuentra declarado para ser utilizado en el presente régimen."
         Case "05"
            Return "La fecha del comprobante indicada no puede ser anterior en más de cinco días, si se trata de una venta, o anterior o posterior en más de diez días, si se trata de una prestación de servicios, consecutivos de la fecha de remisión del archivo -Art. 29 de la RG N° 2485-."
         Case "06"
            Return "La CUIT informada no se encuentra autorizada a emitir comprobantes clase 'A'."
         Case "07"
            Return "Para la clase de comprobante solicitado -comprobante clase 'A'-deberá consignar en el campo código de documento identificatorio del comprador el código '80'."
         Case "08"
            Return "La CUIT indicada en el campo N° de identificación del comprador es inválida."
         Case "09"
            Return "La CUIT indicada en el campo N° de identificación del comprador no existe en el Padrón Unico de Contribuyentes."
         Case "9"
            Return "La CUIT indicada en el campo N° de identificación del comprador no existe en el Padrón Unico de Contribuyentes."
         Case "10"
            Return "La CUIT indicada en el campo N° de identificación del comprador no corresponde a un RI en el IVA activo."
         Case "11"
            Return "El número de comprobante desde informado no es correlativo al último número de comprobante registrado/hasta solicitado para ese tipo de comprobante y punto de venta."
         Case "12"
            Return "El rango informado se encuentra autorizado con anterioridad para la misma CUIT, tipo de comprobante y punto de venta."
         Case "13"
            Return "La CUIT indicada se encuentra comprendida en el Régimen establecido por la Resolución General N° 2485 y/o en el Título I de la Resolución General N° 1361 -Art. 30 de la RG N° 2485-."
         Case Else
            Return String.Empty
      End Select
   End Function

   Private Sub ControlaAutorizacionV1()

      Dim awsaa As AFIPWSAA = New AFIPWSAA(Me.da)
      awsaa.CrearCertificado("wsfe")
      Me.CreaAutorizacionv1()
   End Sub

   Private Function EsIgual(comp As Reglas.WSFEv1.FECompConsResponse, compSiGA As Reglas.WSFEv1.FECAERequest) As Boolean
      If comp.DocTipo <> compSiGA.FeDetReq(0).DocTipo Then
         Return False
      End If
      If comp.DocNro <> compSiGA.FeDetReq(0).DocNro Then
         Return False
      End If
      If comp.ImpTotal <> compSiGA.FeDetReq(0).ImpTotal Then
         Return False
      End If
      If comp.Concepto <> compSiGA.FeDetReq(0).Concepto Then
         Return False
      End If
      If comp.ImpIVA <> compSiGA.FeDetReq(0).ImpIVA Then
         Return False
      End If
      If comp.PtoVta <> compSiGA.FeCabReq.PtoVta Then
         Return False
      End If
      If comp.CbteTipo <> compSiGA.FeCabReq.CbteTipo Then
         Return False
      End If
      Return True
   End Function

   Private Sub CreaAutorizacionv1()
      Dim m_xmld As XmlDocument
      Dim m_nodelist As XmlNodeList
      Dim m_node As XmlNode
      m_xmld = New XmlDocument()
      Dim sql As SqlServer.ParametrosArchivos = New SqlServer.ParametrosArchivos(Me.da)
      m_xmld.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOFE.ToString()))
      m_nodelist = m_xmld.SelectNodes("/loginTicketResponse/credentials")
      Me._autorizacionV1 = New WSFEv1.FEAuthRequest()
      For Each m_node In m_nodelist
         Me._autorizacionV1.Token = m_node.ChildNodes.Item(0).InnerText
         Me._autorizacionV1.Sign = m_node.ChildNodes.Item(1).InnerText
         Me._autorizacionV1.Cuit = Long.Parse(Publicos.CuitEmpresa) '  Long.Parse(New Reglas.Parametros(Me.da)._GetValor(Entidades.Parametro.Parametros.CUITEMPRESA))
      Next
      'End If
   End Sub

   Private Function GetFEComprobanteParaAFIPV1(comprobanteVenta As Entidades.Venta) As WSFEv1.FECAERequest
      Dim cpte As WSFEv1.FECAERequest = New WSFEv1.FECAERequest()
      Dim detalle As WSFEv1.FECAEDetRequest
      Dim detalles As List(Of WSFEv1.FECAEDetRequest) = New List(Of WSFEv1.FECAEDetRequest)()
      'Dim tributo As WSFEv1.Tributo
      Dim tributos As List(Of WSFEv1.Tributo) = New List(Of WSFEv1.Tributo)()
      Dim tri As WSFEv1.Tributo
      Dim iva As WSFEv1.AlicIva
      Dim ivas As List(Of WSFEv1.AlicIva) = New List(Of WSFEv1.AlicIva)()

      Dim cteAfip As Entidades.AFIPTipoComprobante = New AFIPTiposComprobantes(da).GetUno(comprobanteVenta.TipoComprobante.IdTipoComprobante, comprobanteVenta.LetraComprobante)

      With cpte
         .FeCabReq = New WSFEv1.FECAECabRequest()
         'Cantidad de registros del detalle del comprobante o lote de comprobantes de ingreso
         .FeCabReq.CantReg = 1
         'Tipo de comprobante que se está informando. Si se informa más de un comprobante, todos deben ser del mismo tipo.
         .FeCabReq.CbteTipo = cteAfip.IdAFIPTipoComprobante ' New SqlServer.AFIPTiposComprobantes(Me.da).GetIdTipoComprobanteparaAFIP(comprobanteVenta.TipoComprobante.IdTipoComprobante, comprobanteVenta.LetraComprobante)
         'Punto de Venta del comprobante que se está informando. Si se informa más de un comprobante, todos deben corresponder al mismo punto de venta.
         .FeCabReq.PtoVta = comprobanteVenta.CentroEmisor

         detalle = New WSFEv1.FECAEDetRequest()
         'Concepto del Comprobante. Valores permitidos: 1 Productos 2 Servicios 3 Productos y Servicios
         detalle.Concepto = comprobanteVenta.ConceptoDelComprobante


         If comprobanteVenta.CategoriaFiscal.SolicitaCUIT Then
            If comprobanteVenta.Cuit.Replace("-", "").Trim().Length <> 0 Then
               'Código de documento identificatorio del comprador
               detalle.DocTipo = New Reglas.AFIPTiposDocumentos(Me.da).GetIdTipoDocparaAFIP(Entidades.TipoDocumento.TiposDocumentos.CUIT.ToString(), AccionesSiNoExisteRegistro.Excepcion)
               'Nro. de identificación del comprador
               detalle.DocNro = Long.Parse(comprobanteVenta.Cuit.Replace("-", ""))
            Else
               Throw New Exception("El nro. de CUIT no esta cargado")
            End If
         Else
            'If comprobanteVenta.Cliente.TipoDocCliente = Entidades.TipoDocumento.TiposDocumentos.DNI.ToString() Then
            If comprobanteVenta.NroDocCliente > 0 Then
               'Código de documento identificatorio del comprador
               detalle.DocTipo = New Reglas.AFIPTiposDocumentos(Me.da).GetIdTipoDocparaAFIP(comprobanteVenta.TipoDocCliente, AccionesSiNoExisteRegistro.Excepcion)
               'Nro. de identificación del comprador
               detalle.DocNro = comprobanteVenta.NroDocCliente
            Else
               'para los comprobantes que no tienen DNI en ultima instancia verificamos que tenga CUIT para enviarlo a AFIP ----------
               If comprobanteVenta.Cuit.Replace("-", "").Length > 0 Then
                  'Código de documento identificatorio del comprador
                  detalle.DocTipo = New Reglas.AFIPTiposDocumentos(Me.da).GetIdTipoDocparaAFIP(Entidades.TipoDocumento.TiposDocumentos.CUIT.ToString(), AccionesSiNoExisteRegistro.Excepcion)
                  'Nro. de identificación del comprador
                  detalle.DocNro = Long.Parse(comprobanteVenta.Cuit.Replace("-", ""))
                  '---------
               Else
                  'Código de documento identificatorio del comprador
                  detalle.DocTipo = 99
                  'Nro. de identificación del comprador
                  detalle.DocNro = 0
               End If
            End If
         End If

         'Código de moneda del comprobante. Consultar método FEParamGetTiposMonedas para valores posibles
         'Cotización de la moneda informada. Para PES, pesos argentinos la misma debe ser 1
         'TODO: Cambiar, por ahora lo dejo en PES porque solo manejamos pesos
         Dim cotizacoinDolar As Decimal
         If comprobanteVenta.IdMoneda = 1 Then
            detalle.MonId = "PES"
            detalle.MonCotiz = 1
            cotizacoinDolar = 1
         ElseIf comprobanteVenta.IdMoneda = 2 Then
            detalle.MonId = "DOL"
            detalle.MonCotiz = comprobanteVenta.CotizacionDolar
            cotizacoinDolar = comprobanteVenta.CotizacionDolar
         Else
            Throw New Exception(String.Format("El IdMoneda {0} no se puede informar a AFIP", comprobanteVenta.IdMoneda))
         End If

         'Nro. de comprobante desde Rango 1- 99999999
         detalle.CbteDesde = comprobanteVenta.NumeroComprobante
         'Nro. de comprobante registrado hasta Rango 1- 99999999
         detalle.CbteHasta = comprobanteVenta.NumeroComprobante
         'Fecha del comprobante (yyyymmdd). para concepto igual a 1, la fecha de emisión del comprobante puede ser hasta 5 días anteriores o posteriores respecto de la fecha de generación; si se indica Concepto igual a 2 ó 3 puede ser hasta 10 días anteriores o posteriores a la fecha de generación. Si no se envía la fecha del comprobante se asignará la fecha de proceso
         detalle.CbteFch = comprobanteVenta.Fecha.ToString("yyyyMMdd")
         'Importe total del comprobante, Debe ser igual a Importe neto no gravado + Importe exento + Importe neto gravado + todos los campos de IVA al XX% + Importe de tributos.
         detalle.ImpTotal = Decimal.Round(Math.Abs(comprobanteVenta.ImporteTotal) / cotizacoinDolar, _redondeo)
         'Importe neto no gravado. Debe ser menor o igual a Importe total y no puede ser menor a cero. 
         'No puede ser mayor al Importe total de la operación ni menor a cero (0). 
         'Para comprobantes tipo C debe ser igual a cero (0).
         'TODO: Cambiar
         If comprobanteVenta.LetraComprobante = "C" Then
            detalle.ImpTotConc = 0
         Else
            detalle.ImpTotConc = 0
         End If
         'Importe neto gravado. Debe ser menor o igual a Importe total y no puede ser menor a cero. 
         'Para comprobantes tipo C este campo corresponde al Importe del Sub Total.
         detalle.ImpNeto = Decimal.Round(Math.Abs(comprobanteVenta.Subtotal) / cotizacoinDolar, _redondeo)
         'Importe exento. Debe ser menor o igual a Importe total y no puede ser menor a cero. 
         'Para comprobantes tipo C debe ser igual a cero (0).
         'TODO: Cambiar
         If comprobanteVenta.LetraComprobante = "C" Then
            detalle.ImpOpEx = 0
         Else
            detalle.ImpOpEx = Decimal.Round(Math.Abs(comprobanteVenta.TotalImporteExento) / cotizacoinDolar, _redondeo)
         End If
         'Suma de los importes del array de IVA. Para comprobantes tipo C debe ser igual a cero (0).
         If comprobanteVenta.LetraComprobante = "C" Then
            detalle.ImpIVA = 0
         Else
            detalle.ImpIVA = Math.Abs(Decimal.Round(comprobanteVenta.TotalIVA / cotizacoinDolar, Me._redondeo))
         End If
         'Suma de los importes del array de tributos
         detalle.ImpTrib = Decimal.Round(Math.Abs(comprobanteVenta.TotalTributos + comprobanteVenta.TotalImpuestoInterno) / cotizacoinDolar, _redondeo)

         If detalle.Concepto = 2 Or detalle.Concepto = 3 Then
            'Fecha de inicio del abono para el servicio a facturar. Dato obligatorio para concepto 2 o 3 (Servicios / Productos y Servicios). Formato yyyymmdd
            detalle.FchServDesde = comprobanteVenta.Fecha.ToString("yyyyMMdd")
            'Fecha de fin del abono para el servicio a facturar. Dato obligatorio para concepto 2 o 3 (Servicios / Productos y Servicios). Formato yyyymmdd. FchServHasta no puede ser menor a FchServDesde
            detalle.FchServHasta = comprobanteVenta.Fecha.ToString("yyyyMMdd")
            'Fecha de vencimiento del pago servicio a facturar. Dato obligatorio para concepto 2 o 3 (Servicios / Productos y Servicios). Formato yyyymmdd. Debe ser igual o posterior a la fecha del comprobante.
            detalle.FchVtoPago = comprobanteVenta.Fecha.ToString("yyyyMMdd")
         End If

         Dim fchVtoPago As DateTime
         If comprobanteVenta.CuentaCorriente IsNot Nothing AndAlso
            comprobanteVenta.CuentaCorriente.Pagos IsNot Nothing AndAlso
            comprobanteVenta.CuentaCorriente.Pagos.Count > 0 Then
            fchVtoPago = comprobanteVenta.CuentaCorriente.Pagos.OrderByDescending(Function(x) x.FechaVencimiento).FirstOrDefault().FechaVencimiento
         Else
            fchVtoPago = comprobanteVenta.Fecha
         End If

         If comprobanteVenta.TipoComprobante.AFIPWSIncluyeFechaVencimiento.HasValue Then
            detalle.FchVtoPago = If(comprobanteVenta.TipoComprobante.AFIPWSIncluyeFechaVencimiento.Value, fchVtoPago.ToString("yyyyMMdd"), String.Empty)
         End If

         Dim lstCbtesAsoc As New List(Of WSFEv1.CbteAsoc)
         'Array para informar los comprobantes asociados <CbteAsoc>
         If comprobanteVenta.TipoComprobante.AFIPWSRequiereComprobanteAsociado Then
            'For Each asociado As Entidades.Venta In comprobanteVenta.Facturables
            For Each vv In comprobanteVenta.Invocados
               Dim asociado = vv.Invocado
               Dim cteAfipAsociado As Entidades.AFIPTipoComprobante = New AFIPTiposComprobantes(da).GetUno(asociado.IdTipoComprobante, asociado.Letra)
               lstCbtesAsoc.Add(New WSFEv1.CbteAsoc() With {.Tipo = cteAfipAsociado.IdAFIPTipoComprobante,
                                                            .PtoVta = asociado.CentroEmisor,
                                                            .Nro = asociado.NumeroComprobante,
                                                            .Cuit = Publicos.CuitEmpresa,
                                                            .CbteFch = asociado.Fecha.ToString("yyyyMMdd")})
            Next
         End If
         If lstCbtesAsoc.Count > 0 Then
            detalle.CbtesAsoc = lstCbtesAsoc.ToArray()
         Else
            detalle.CbtesAsoc = Nothing
         End If


         'Array para informar los tributos asociados a un comprobante <Tributo>.
         'detalle.Tributos = tributos.ToArray()
         'VentasImpuestos e ImpuestosVarios son iguales pero uno tiene el IVA y el otro los otro impuestos como por ej. IIBB
         For Each imp As Entidades.VentaImpuesto In comprobanteVenta.ImpuestosVarios
            If imp.TipoImpuesto.IdTipoImpuesto <> Entidades.TipoImpuesto.Tipos.IVA And imp.TipoImpuesto.IdTipoImpuesto <> Entidades.TipoImpuesto.Tipos.IMINT Then
               tri = New WSFEv1.Tributo()
               If imp.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIIBB Then
                  tri.Id = 2 'Impuestos provinciales es "2" (esta fijo pero hay que cambiarlo)
               ElseIf imp.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA Then
                  tri.Id = 6 'Impuestos provinciales es "6" (esta fijo pero hay que pedir confirmación)
               Else
                  Throw New Exception(String.Format("Solicitar CAE no está preparado para informar un tributo del tipo de impuesto {0}. Verifique la configuración.", imp.IdTipoImpuesto.ToString()))
               End If
               tri.Desc = imp.TipoImpuesto.NombreTipoImpuesto
               tri.Alic = imp.Alicuota
               tri.BaseImp = Math.Abs(Decimal.Round(imp.Neto / cotizacoinDolar, _redondeo))
               tri.Importe = Math.Abs(Decimal.Round(imp.Importe / cotizacoinDolar, _redondeo))
               tributos.Add(tri)
            End If
         Next

         If comprobanteVenta.TotalImpuestoInterno <> 0 Then
            tri = New WSFEv1.Tributo()
            tri.Id = 4 'Impuestos internos es "4" (esta fijo pero hay que cambiarlo)
            tri.Desc = "Impuestos Internos"
            tri.Alic = 0
            tri.BaseImp = 0
            tri.Importe = Math.Abs(Decimal.Round(comprobanteVenta.TotalImpuestoInterno / cotizacoinDolar, _redondeo))
            tributos.Add(tri)
         End If

         If tributos.Count > 0 Then
            detalle.Tributos = tributos.ToArray()
         Else
            detalle.Tributos = Nothing
         End If

         'agrego los ivas
         For Each imp As Entidades.VentaImpuesto In comprobanteVenta.VentasImpuestos
            If imp.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.IVA Then
               If comprobanteVenta.LetraComprobante = "C" Then
                  detalle.ImpNeto = Math.Round((detalle.ImpNeto + Math.Abs(imp.Importe / cotizacoinDolar)), Me._redondeo)
               Else
                  iva = New WSFEv1.AlicIva()
                  iva.Id = New SqlServer.AFIPIVAs(Me.da).GetIdIVAparaAFIP(imp.IdTipoImpuesto, imp.Alicuota)
                  iva.BaseImp = Math.Abs(Decimal.Round(imp.Neto / cotizacoinDolar, _redondeo))
                  iva.Importe = Math.Abs(Decimal.Round(imp.Importe / cotizacoinDolar, _redondeo))
                  ivas.Add(iva)
               End If
               'detalle.ImpNeto = Math.Round(detalle.ImpNeto, 2)
            End If
         Next


         'Array para informar las alícuotas y sus importes asociados a un comprobante <AlicIva>. Para comprobantes tipo C no se debe informar el array.
         If ivas.Count > 0 Then
            detalle.Iva = ivas.ToArray()
         Else
            detalle.Iva = Nothing
         End If

         Dim opcionales As List(Of WSFEv1.Opcional) = New List(Of WSFEv1.Opcional)()

         'Array de campos auxiliares. Reservado usos futuros <Opcional>. Adicionales por R.G.
         If comprobanteVenta.TipoComprobante.AFIPWSRequiereCBU Then
            'Para Factura de Crédito Electrónica MiPyMEs (FCE) los siguientes campos opcionales son obligatorios.
            '  2101: Factura de Crédito Electrónica MiPyMEs (FCE) - CBU del Emisor
            '  2102: Factura de Crédito Electrónica MiPyMEs (FCE) - Alias del Emisor
            If Not String.IsNullOrWhiteSpace(comprobanteVenta.Cbu) Then
               opcionales.Add(New WSFEv1.Opcional() With {.Id = "2101", .Valor = comprobanteVenta.Cbu})
            End If
            If Not String.IsNullOrWhiteSpace(comprobanteVenta.CbuAlias) Then
               opcionales.Add(New WSFEv1.Opcional() With {.Id = "2102", .Valor = comprobanteVenta.CbuAlias})
            End If
         End If

         If comprobanteVenta.TipoComprobante.AFIPWSRequiereReferenciaComercial AndAlso Not String.IsNullOrWhiteSpace(comprobanteVenta.ReferenciaComercial) Then
            '  23: RG 4367 Factura de Crédito Electrónica MiPyMEs (FCE) - Referencia Comercial
            opcionales.Add(New WSFEv1.Opcional() With {.Id = "23", .Valor = comprobanteVenta.ReferenciaComercial.Truncar(50)})
         End If

         If comprobanteVenta.TipoComprobante.AFIPWSCodigoAnulacion Then
            '  22: RG 4367 Factura de Crédito Electrónica MiPyMEs (FCE) - Anulación
            opcionales.Add(New WSFEv1.Opcional() With {.Id = "22", .Valor = If(comprobanteVenta.AnulacionFCE, "S", "N")})
         End If

         If comprobanteVenta.TipoComprobante.AFIPWSRequiereReferenciaTransferencia AndAlso
            Not String.IsNullOrWhiteSpace(comprobanteVenta.IdAFIPReferenciaTransferencia) Then
            '  27: Referencia de transferencia
            '        A partir del 1/4/2021 se deberá enviar éste campo con las siguiente siglas posibles:  "SCA" o "ADC" .
            '                 "SCA se usa para indicar: "TRANSFERENCIA AL SISTEMA DE CIRCULACION ABIERTA"
            '                 "ADC" para enviar "AGENTE DE DEPOSITO COLECTIVO"
            opcionales.Add(New WSFEv1.Opcional() With {.Id = "27", .Valor = comprobanteVenta.IdAFIPReferenciaTransferencia})
         End If

         If opcionales.Count > 0 Then
            detalle.Opcionales = opcionales.ToArray()
         Else
            detalle.Opcionales = Nothing
         End If

         detalles.Add(detalle)

         .FeDetReq = detalles.ToArray()
      End With

      Return cpte
   End Function

#End Region

#Region "WS 1"

   Friend Function SolicitarCAEv1(comprobanteVenta As Entidades.Venta) As Entidades.AFIPCAE
      Try
         Dim wsService As WSFEv1.Service = New WSFEv1.Service()
         wsService.Url = Me._urlFE

         Dim codigoNoExcluyentes As List(Of Integer) = New List(Of Integer)()
         codigoNoExcluyentes.Add(10063) 'Para comprobantes Clase A el receptor del comprobante informado en DocTipo y  DocNro 
         'debe corresponder a un contribuyente activo en el Impuesto al Valor Agregado.

         codigoNoExcluyentes.Add(10041) 'Si el punto de venta del comprobante asociado (campo PtoVta de CbtesAsoc) 
         'es electrónico, el número de comprobante debe obrar en las bases del organismo para el punto de venta y 
         'tipo de comprobante informado.

         Dim respuesta As WSFEv1.FECAEResponse

         Me.ControlaAutorizacionV1()

         Dim cbteAFIP As WSFEv1.FECAERequest = Me.GetFEComprobanteParaAFIPV1(comprobanteVenta)

         If Publicos.FacturaElectronica.FactElecGuardarLog Then
            WriteXML(comprobanteVenta.NombreArchivoExportar("Solicitud"), cbteAFIP)
         End If
         respuesta = wsService.FECAESolicitar(Me._autorizacionV1, cbteAFIP)
         If Publicos.FacturaElectronica.FactElecGuardarLog Then
            WriteXML(comprobanteVenta.NombreArchivoExportar("Respuesta"), respuesta)
         End If

         Dim cae As Entidades.AFIPCAE = New Entidades.AFIPCAE()

         'A=APROBADO, R=RECHAZADO, P=PARCIAL --> respuesta.FeCabResp.Resultado

         If respuesta.Errors IsNot Nothing AndAlso respuesta.Errors.Count > 0 Then
            Dim mensajeError As System.Text.StringBuilder = New System.Text.StringBuilder()
            mensajeError.Append("Error en la obtención del CAE. ").AppendLine()
            For Each er As WSFEv1.Err In respuesta.Errors
               If er.Code = 500 Or er.Code = 501 Then
                  mensajeError.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
                  mensajeError.AppendLine("-------- DETALLE TÉCNICO --------")
               End If
               mensajeError.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
            Next
            Throw New Exception(mensajeError.ToString())
         End If

         Dim pasoObserv As Boolean = True

         If String.IsNullOrEmpty(respuesta.FeDetResp(0).CAE) Then
            pasoObserv = False
         End If

         If respuesta.FeDetResp(0).Observaciones IsNot Nothing AndAlso respuesta.FeDetResp(0).Observaciones.Count > 0 Then
            Dim obs As System.Text.StringBuilder = New System.Text.StringBuilder()
            obs.Append("Error en la obtención del CAE. ").AppendLine()
            For Each er As WSFEv1.Obs In respuesta.FeDetResp(0).Observaciones
               If er.Code = 500 Or er.Code = 501 Then
                  obs.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
                  obs.AppendLine("-------- DETALLE TÉCNICO --------")
               End If
               obs.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
               'controlo que la observación sea No Excluyente
               If codigoNoExcluyentes.Contains(er.Code) Then
                  pasoObserv = False
               End If
            Next
            If Not pasoObserv Then
               Throw New Exception(obs.ToString())
            End If
         End If

         'Throw New Exception("CORTE PARA PRUEBAS")

         If respuesta.FeDetResp IsNot Nothing Then
            cae.CAE = respuesta.FeDetResp(0).CAE
            If Not String.IsNullOrEmpty(respuesta.FeDetResp(0).CAEFchVto) AndAlso respuesta.FeDetResp(0).CAEFchVto <> "NULL" Then
               Dim fecha(2) As Integer
               fecha(0) = Int32.Parse(respuesta.FeDetResp(0).CAEFchVto.Substring(0, 4))
               fecha(1) = Int32.Parse(respuesta.FeDetResp(0).CAEFchVto.Substring(4, 2))
               fecha(2) = Int32.Parse(respuesta.FeDetResp(0).CAEFchVto.Substring(6, 2))

               cae.CAEVencimiento = New DateTime(fecha(0), fecha(1), fecha(2))
            End If
         End If

         Return cae

      Catch ex As Exception
         WriteError(comprobanteVenta.NombreArchivoExportar(), ex)
         Throw
      End Try

   End Function

   Friend Function RecuperarCAEv1(comprobanteVenta As Entidades.Venta) As Entidades.AFIPCAE
      Dim comp As Reglas.WSFEv1.FECompConsResponse = Me.GetComprobanteEmitidoV1(comprobanteVenta.TipoComprobante.IdTipoComprobante, comprobanteVenta.LetraComprobante, comprobanteVenta.NumeroComprobante, comprobanteVenta.CentroEmisor)
      'realiza validaciones para comprobar que el comprobante que recuperamos el CAE es 
      'el mismo que ya enviamos antes
      Dim compAComparar As Reglas.WSFEv1.FECAERequest = Me.GetFEComprobanteParaAFIPV1(comprobanteVenta)

      If Not EsIgual(comp, compAComparar) Then
         Throw New Exception("El comprobante que esta en AFIP no es igual al que intenta consultar.")
      End If

      Dim en As Entidades.AFIPCAE = New Entidades.AFIPCAE()
      en.CAE = comp.CodAutorizacion
      en.CAEVencimiento = New DateTime(Int32.Parse(comp.FchVto.Substring(0, 4)), Int32.Parse(comp.FchVto.Substring(4, 2)), Int32.Parse(comp.FchVto.Substring(6, 2)))
      Return en
   End Function

   Friend Function RecuperarCAEv1_PreSolicitar(comprobanteVenta As Entidades.Venta) As Entidades.AFIPCAE
      'busco el documento en AFIP que quiero comparar con el que tengo grabado
      Dim en As Entidades.AFIPCAE = New Entidades.AFIPCAE()
      Dim comp As Reglas.WSFEv1.FECompConsResponse
      Try
         comp = Me.GetComprobanteEmitidoV1(comprobanteVenta.TipoComprobante.IdTipoComprobante, comprobanteVenta.LetraComprobante, comprobanteVenta.NumeroComprobante, comprobanteVenta.CentroEmisor)
      Catch ex As Exception
         'si da un error desde AFIP de cualquier tipo retorno la entidad vacia al metodo que la llamó
         Return en
      End Try
      'realiza validaciones para comprobar que el comprobante que recuperamos el CAE es el mismo que ya enviamos antes
      'convierto el comprobante que tengo en un comprobante de AFIP para compararlo
      Dim compAComparar As Reglas.WSFEv1.FECAERequest = Me.GetFEComprobanteParaAFIPV1(comprobanteVenta)

      'comparo los 2 comprobantes
      If Not EsIgual(comp, compAComparar) Then
         'El comprobante que esta en AFIP no es igual al que intenta consultar.
         'Como es un metodo interno no hago nada
      Else
         'en este caso el comprobante es igual, asi que reviso si se puede consultar
         en.CAE = comp.CodAutorizacion
         en.CAEVencimiento = New DateTime(Int32.Parse(comp.FchVto.Substring(0, 4)), Int32.Parse(comp.FchVto.Substring(4, 2)), Int32.Parse(comp.FchVto.Substring(6, 2)))
      End If

      Return en
   End Function

   Public Function GetUltimoComprobanteAutorizadoV1(idTipoComprobante As String,
                                                 letra As String,
                                                 emisor As Integer) As Integer
      Try
         Me.da.OpenConection()

         Me.ControlaAutorizacionV1()

         Dim ws As WSFEv1.Service = New WSFEv1.Service()
         ws.Url = Me._urlFE
         Dim tipoCbte As Integer = New SqlServer.AFIPTiposComprobantes(Me.da).GetIdTipoComprobanteparaAFIP(idTipoComprobante, letra)
         Dim ptoVenta As Integer = emisor
         Dim argRes As WSFEv1.FERecuperaLastCbteResponse
         argRes = ws.FECompUltimoAutorizado(Me._autorizacionV1, ptoVenta, tipoCbte)
         If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
            Dim err As StringBuilder = New StringBuilder("")
            err.Append("Error en la obtención del último comprobante autorizado. ").AppendLine()
            For Each er As WSFEv1.Err In argRes.Errors
               If er.Code = 500 Or er.Code = 501 Then
                  err.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
                  err.AppendLine("-------- DETALLE TÉCNICO --------")
               End If
               err.AppendFormat("{0} - {1}", er.Code, er.Msg).AppendLine()
            Next
            Throw New Exception(err.ToString())
         End If
         Return argRes.CbteNro

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function TestearServidoresV1() As String
      Try
         da.OpenConection()

         ControlaAutorizacionV1()

         'Prueba de WSPN3. Descomentar para seguir probando.
         'Using ws1 As New WSPN3.ContribuyenteNivel3SelectServiceImplService()
         '   ws1.Url = "http://awshomo.afip.gov.ar/padron-puc-ws/services/select.ContribuyenteNivel3SelectServiceImpl"
         '   ws1.Url = "http://awshomo.afip.gov.ar/padron-puc-ws/services/select.ContribuyenteNivel10SelectServiceImpl"
         '   Dim token As String = String.Format("-----BEGIN SSOTOKENBASE64-----{1}{0}{1}-----END SSOTOKENBASE64-----", _autorizacionV1.Token, Environment.NewLine)
         '   Dim sign As String = String.Format("-----BEGIN SSOSIGNBASE64-----{1}{0}{1}-----END SSOSIGNBASE64-----", _autorizacionV1.Sign, Environment.NewLine)
         '   Dim a As String = ws1.get("24259000056", token, sign)
         'End Using

         Dim ws = New WSFEv1.Service()
         ws.Url = _urlFE

         Dim argRes = ws.FEDummy()
         Return argRes.AuthServer + "/" + argRes.AppServer + "/" + argRes.DbServer
      Catch ex As Exception
         Throw
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function GetComprobanteEmitidoV1(idTipoComprobante As String,
                                                    letra As String,
                                                    nroComprobante As Long,
                                                    puntoVenta As Integer) As WSFEv1.FECompConsResponse
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.FECompConsultaResponse
      Dim argReq As WSFEv1.FECompConsultaReq = New WSFEv1.FECompConsultaReq()
      argReq.CbteTipo = New SqlServer.AFIPTiposComprobantes(Me.da).GetIdTipoComprobanteparaAFIP(idTipoComprobante, letra)
      argReq.CbteNro = nroComprobante
      argReq.PtoVta = puntoVenta
      argRes = ws.FECompConsultar(Me._autorizacionV1, argReq)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error en la consulta del comprobante. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            If er.Code = 500 Or er.Code = 501 Then
               stb.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
               stb.AppendLine("-------- DETALLE TÉCNICO --------")
            End If
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If

      Return argRes.ResultGet
   End Function

   Public Function GetPuntosDeVentaV1() As WSFEv1.PtoVenta()
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.FEPtoVentaResponse
      argRes = ws.FEParamGetPtosVenta(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error en la consulta del punto de venta. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If

      Return argRes.ResultGet
   End Function

   Public Function GetCantMaxRegistroDetalleV1() As Integer
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.FERegXReqResponse
      argRes = ws.FECompTotXRequest(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error en la consulta de Cant. Maxima Registros. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If
      Return argRes.RegXReq
   End Function

   Public Function GetTiposTributosV1() As WSFEv1.TributoTipo()
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.FETributoResponse
      argRes = ws.FEParamGetTiposTributos(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If
      Return argRes.ResultGet
   End Function

   Public Function GetTiposOpcionalesV1() As WSFEv1.OpcionalTipo()
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.OpcionalTipoResponse
      argRes = ws.FEParamGetTiposOpcional(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If
      Return argRes.ResultGet
   End Function

   Public Function GetTiposMonedasV1() As WSFEv1.Moneda()
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.MonedaResponse
      argRes = ws.FEParamGetTiposMonedas(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If
      Return argRes.ResultGet
   End Function

   Public Function GetTiposAlicuotasV1() As WSFEv1.IvaTipo()
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.IvaTipoResponse
      argRes = ws.FEParamGetTiposIva(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If
      Return argRes.ResultGet
   End Function

   Public Function GetTiposDocumentosV1() As WSFEv1.DocTipo()
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.DocTipoResponse
      argRes = ws.FEParamGetTiposDoc(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If
      Return argRes.ResultGet
   End Function

   Public Function GetTiposConceptosV1() As WSFEv1.ConceptoTipo()
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.ConceptoTipoResponse
      argRes = ws.FEParamGetTiposConcepto(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If
      Return argRes.ResultGet
   End Function

   Public Function GetTiposComprobantesV1() As WSFEv1.CbteTipo()
      Me.ControlaAutorizacionV1()

      Dim ws As WSFEv1.Service = New WSFEv1.Service()
      ws.Url = Me._urlFE

      Dim argRes As WSFEv1.CbteTipoResponse
      argRes = ws.FEParamGetTiposCbte(Me._autorizacionV1)
      If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error. ").AppendLine()
         For Each er As WSFEv1.Err In argRes.Errors
            stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
         Next
         Throw New Exception(stb.ToString())
      End If
      Return argRes.ResultGet
   End Function

#End Region

End Class