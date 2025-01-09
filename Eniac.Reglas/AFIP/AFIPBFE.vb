Public Class AFIPBFE
   Inherits Base

#Region "Constructores"

   Public Sub New()
      da = New Datos.DataAccess()
      _urlBFE = New Parametros().GetValorPD(Entidades.Parametro.Parametros.URLWSBFE.ToString(), "")
   End Sub

   Friend Sub New(accesoDatos As Eniac.Datos.DataAccess)
      da = accesoDatos
      _urlBFE = New Parametros().GetValorPD(Entidades.Parametro.Parametros.URLWSBFE.ToString(), "")
   End Sub

#End Region

#Region "Campos"

   Private _idRequerimiento As Long = 0
   Private _urlBFE As String
   Private _autorizacion As WSBFE.ClsBFEAuthRequest

#End Region

#Region "Metodos comunes"

   Friend Sub ControlaAutorizacion()
      Dim awsaa As AFIPWSAA = New AFIPWSAA(da)
      awsaa.CrearCertificado("wsbfe")
      CreaAutorizacion()
   End Sub

   Private Function EsIgual(comp As Reglas.WSBFE.ClsBFEGetCMPR,
                            compSiGA As Reglas.WSBFE.ClsBFERequest) As Boolean
      If comp.Tipo_doc <> compSiGA.Tipo_doc Then
         Return False
      End If
      If comp.Nro_doc <> compSiGA.Nro_doc Then
         Return False
      End If
      If comp.Imp_total <> compSiGA.Imp_total Then
         Return False
      End If
      'If comp. <> compSiGA.FeDetReq(0).Concepto Then
      '   Return False
      'End If
      If comp.Impto_liq <> compSiGA.Impto_liq Then
         Return False
      End If
      If comp.Punto_vta <> compSiGA.Punto_vta Then
         Return False
      End If
      If comp.Tipo_cbte <> compSiGA.Tipo_cbte Then
         Return False
      End If
      Return True
   End Function

   Private Sub CreaAutorizacion()
      Dim m_xmld = New Xml.XmlDocument()
      Dim sql As SqlServer.ParametrosArchivos = New SqlServer.ParametrosArchivos(da)
      m_xmld.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOBFE.ToString()))

      Dim m_nodelist = m_xmld.SelectNodes("/loginTicketResponse/credentials")
      Me._autorizacion = New WSBFE.ClsBFEAuthRequest()
      For Each m_node In m_nodelist.OfType(Of Xml.XmlNode)
         _autorizacion.Token = m_node.ChildNodes.Item(0).InnerText
         _autorizacion.Sign = m_node.ChildNodes.Item(1).InnerText
         _autorizacion.Cuit = Long.Parse(Publicos.CuitEmpresa) 'New Reglas.Parametros()._GetValor("CUITEMPRESA"))
      Next
   End Sub

   Public Function GetUnidadesDeMedidas() As WSBFE.ClsBFEResponse_UMed()
      ControlaAutorizacion()

      Using ws = New WSBFE.Service()
         ws.Url = _urlBFE

         Dim argRes As WSBFE.BFEResponse_Umed
         argRes = ws.BFEGetPARAM_UMed(_autorizacion)
         If argRes IsNot Nothing AndAlso argRes.BFEErr.ErrCode > 0 Then
            Dim stb As StringBuilder = New StringBuilder("")
            stb.Append("Error. ").AppendLine()
            stb.Append(argRes.BFEErr.ErrCode.ToString() + " - " + argRes.BFEErr.ErrMsg).AppendLine()
            Throw New Exception(stb.ToString())
         End If
         Return argRes.BFEResultGet
      End Using
   End Function

   Private Function GetFEComprobanteParaAFIP(comprobanteVenta As Entidades.Venta) As WSBFE.ClsBFERequest
      Dim cpte As WSBFE.ClsBFERequest = New WSBFE.ClsBFERequest()
      Dim detalle As WSBFE.Item
      Dim detalles As List(Of WSBFE.Item) = New List(Of WSBFE.Item)()
      'Dim tributo As WSFEv1.Tributo
      'Dim tributos As List(Of WSFEv1.Tributo) = New List(Of WSFEv1.Tributo)()
      'Dim iva As WSFEv1.AlicIva
      'Dim ivas As List(Of WSFEv1.AlicIva) = New List(Of WSFEv1.AlicIva)()

      With cpte

         'Identificador del requerimiento
         .Id = Long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"))

         'Nro. de identificación del comprador
         'el webservice solo soporte el tipo de documento nro. 80 que es CUIT, por eso va fijo
         .Tipo_doc = 80
         If comprobanteVenta.Cliente.TipoDocCliente <> Entidades.TipoDocumento.TiposDocumentos.CUIT.ToString() Then
            If String.IsNullOrEmpty(comprobanteVenta.Cliente.Cuit) Then
            Else
               'Nro. de identificación del comprador
               .Nro_doc = Long.Parse(comprobanteVenta.Cliente.Cuit.Replace("-", ""))
            End If
         Else
            'Nro. de identificación del comprador
            .Nro_doc = Long.Parse(comprobanteVenta.Cliente.Cuit.Replace("-", ""))
         End If

         'Codigo de zona
         .Zona = 1

         'Tipo de comprobante (BFEGetPARAM_Tipo_Cbte)
         .Tipo_cbte = New SqlServer.AFIPTiposComprobantes(da).GetIdTipoComprobanteparaAFIP(comprobanteVenta.TipoComprobante.IdTipoComprobante, comprobanteVenta.LetraComprobante).ToShort()

         'Punto de venta
         .Punto_vta = comprobanteVenta.CentroEmisor

         'Nro. de comprobante
         .Cbte_nro = comprobanteVenta.NumeroComprobante

         'Importe total de la operación
         .Imp_total = System.Math.Abs(comprobanteVenta.ImporteTotal)

         'Importe total de conceptos que no integran el precio neto gravado
         .Imp_tot_conc = 0

         'Importe neto gravado
         .Imp_neto = System.Math.Abs(comprobanteVenta.Subtotal)

         'Importe liquidado
         .Impto_liq = System.Math.Abs(comprobanteVenta.ImporteTotal)

         'Impuesto liquidado a RNI o percepción a no categorizados
         '.Impto_liq_rni = System.Math.Abs(comprobanteVenta.)

         'Importe de operaciones exentas
         ' .imp_op_ex = 

         'Importe de percepciones
         .Imp_perc = 0
         For Each perc As Entidades.PercepcionVenta In comprobanteVenta.Percepciones
            .Imp_perc += System.Math.Abs(perc.ImporteTotal)
         Next

         'Importe de impuestos internos
         ' .Imp_internos = 

         'Codigo de moneda(BFEGetPARAM_MON)
         'TODO: Cambiar, por ahora lo dejo en PES porque solo manejmaso pesos
         .Imp_moneda_Id = "PES"

         'Cotizacion de moneda
         'TODO: Cambiar, por ahora lo dejo en uno porque solo manejamos pesos
         .Imp_moneda_ctz = 1

         'Fecha de comprobante (yyyymmdd)
         .Fecha_cbte = comprobanteVenta.Fecha.ToString("yyyyMMdd")

         'Concepto del Comprobante. Valores permitidos: 1 Productos 2 Servicios 3 Productos y Servicios
         ' detalle. = comprobanteVenta.ConceptoDelComprobante
         Dim li As List(Of WSBFE.Item) = New List(Of WSBFE.Item)()

         For Each vp As Entidades.VentaProducto In comprobanteVenta.VentasProductos
            detalle = New WSBFE.Item()

            'Código de producto (nomenclador comun del MERCOSUR)
            detalle.Pro_codigo_ncm = vp.Producto.IdProductoMercosur

            'Codigo de producto según Secretaria
            detalle.Pro_codigo_sec = vp.Producto.IdProductoSecretaria

            'Descripción del producto
            detalle.Pro_ds = vp.Producto.NombreProducto

            'Cantidad
            detalle.Pro_qty = vp.Cantidad

            'Codigo de unidad de medida (BFEGetPARAM_UMed)
            detalle.Pro_umed = vp.Producto.UnidadDeMedida.IdAFIP

            'Precio unitario
            detalle.Pro_precio_uni = vp.Precio

            'Importe bonificacion
            'detalle.Imp_bonif = 

            'Importe total
            detalle.Imp_total = System.Math.Abs(vp.ImporteTotal)

            'Codigo de IVA (ver metodo BFEGetPARAM_Tipo_IVA)
            detalle.Iva_id = New SqlServer.AFIPIVAs(da).GetIdIVAparaAFIP(Entidades.TipoImpuesto.Tipos.IVA, vp.AlicuotaImpuesto).ToShort()

            li.Add(detalle)
         Next

         .Items = li.ToArray()
      End With

      Return cpte
   End Function

#End Region

#Region "WS"

   Friend Function SolicitarCAE(comprobanteVenta As Entidades.Venta) As Entidades.AFIPCAE
      Dim wsService As WSBFE.Service = New WSBFE.Service()
      wsService.Url = Me._urlBFE

      Dim respuesta As WSBFE.BFEResponseAuthorize

      Me.ControlaAutorizacion()

      Dim cbteAFIP As WSBFE.ClsBFERequest = Me.GetFEComprobanteParaAFIP(comprobanteVenta)

      'Dim rtd As WSBFE.BFEResponse_Umed = wsService.BFEGetPARAM_UMed(Me._autorizacion)

      respuesta = wsService.BFEAuthorize(Me._autorizacion, cbteAFIP)

      Dim cae As Entidades.AFIPCAE = New Entidades.AFIPCAE()

      'A=APROBADO, R=RECHAZADO, P=PARCIAL --> respuesta.FeCabResp.Resultado

      If respuesta.BFEErr IsNot Nothing AndAlso respuesta.BFEErr.ErrCode > 0 Then
         Dim mensajeError As System.Text.StringBuilder = New System.Text.StringBuilder()
         mensajeError.Append("Error en la obtención del CAE. ").AppendLine()
         If respuesta.BFEErr.ErrCode = 500 Or respuesta.BFEErr.ErrCode = 501 Then
            mensajeError.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
            mensajeError.AppendLine("-------- DETALLE TÉCNICO --------")
         End If
         mensajeError.Append(respuesta.BFEErr.ErrCode.ToString() + " - " + respuesta.BFEErr.ErrMsg).AppendLine()
         Throw New Exception(mensajeError.ToString())
      End If

      Dim pasoObserv As Boolean = True

      If respuesta.BFEEvents IsNot Nothing AndAlso respuesta.BFEEvents.EventCode > 0 Then
         Dim obs As System.Text.StringBuilder = New System.Text.StringBuilder()
         obs.Append("Error en la obtención del CAE. ").AppendLine()
         If respuesta.BFEErr.ErrCode = 500 Or respuesta.BFEErr.ErrCode = 501 Then
            obs.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
            obs.AppendLine("-------- DETALLE TÉCNICO --------")
         End If
         obs.Append(respuesta.BFEEvents.EventCode.ToString() + " - " + respuesta.BFEEvents.EventMsg).AppendLine()
         If Not pasoObserv Then
            Throw New Exception(obs.ToString())
         End If
      End If

      If respuesta.BFEResultAuth.Resultado = "R" Then
         Dim stbRechazo = New StringBuilder("Error en la obtención del CAE:")
         AgregarObsAlMensaje(stbRechazo, respuesta.BFEResultAuth.Obs)

         Throw New Exception(stbRechazo.ToString())
      End If

      If respuesta.BFEResultAuth IsNot Nothing Then
         cae.CAE = respuesta.BFEResultAuth.Cae
         If Not String.IsNullOrEmpty(respuesta.BFEResultAuth.Fch_venc_Cae) AndAlso respuesta.BFEResultAuth.Fch_venc_Cae <> "NULL" Then
            Dim fecha(2) As Integer
            fecha(0) = Integer.Parse(respuesta.BFEResultAuth.Fch_venc_Cae.Substring(0, 4))
            fecha(1) = Integer.Parse(respuesta.BFEResultAuth.Fch_venc_Cae.Substring(4, 2))
            fecha(2) = Integer.Parse(respuesta.BFEResultAuth.Fch_venc_Cae.Substring(6, 2))

            cae.CAEVencimiento = New DateTime(fecha(0), fecha(1), fecha(2))
         End If
      End If

      Return cae

   End Function

   Private Function AgregarObsAlMensaje(stbRechazo As StringBuilder, obs As String) As StringBuilder
      'Según documentado en:
      '     https://www.afip.gob.ar/ws/WSBFE/WSBFE-GuiaAdicionalParaElProgramador.pdf 
      '     https://www.afip.gob.ar/fe/ayuda/documentos/WSBFEV1-Manual-Para-El-Desarrollador.pdf

      stbRechazo.AppendLine()
      Select Case obs
         Case "01"
            stbRechazo.Append("  01 - LA CUIT INFORMADA NO CORRESPONDE A UN RESPONSABLE INSCRIPTO EN EL IVA ACTIVO")
         Case "02"
            stbRechazo.Append("  02 - LA CUIT INFORMADA NO SE ENCUENTRA AUTORIZADA A EMITIR COMPROBANTES ELECTRONICOS ORIGINALES O EL PERIODO DE INICIO AUTORIZADO ES POSTERIOR AL DE LA GENERACION DE LA SOLICITUD")
         Case "03"
            stbRechazo.Append("  03 - LA CUIT INFORMADA REGISTRA INCONVENIENTES CON EL DOMICILIO FISCAL")
         Case "04"
            stbRechazo.Append("  04 - EL PUNTO DE VENTA INFORMADO NO SE ENCUENTRA DECLARADO PARA SER UTILIZADO EN EL PRESENTE REGIMEN")
         Case "05"
            stbRechazo.Append("  05 - LA FECHA DEL COMPROBANTE INDICADA NO PUEDE SER ANTERIOR EN MAS DE CINCO DIAS, SI SE TRATA DE UNA VENTA, O ANTERIOR O POSTERIOR EN MAS DE DIEZ DIAS, SI SE TRATA DE UNA PRESTACION DE SERVICIOS, CONSECUTIVOS DE LA FECHA DE REMISION DEL ARCHIVO Art. 22 de la RG Nro 2177-")
         Case "06"
            stbRechazo.Append("  06 - LA CUIT INFORMADA NO SE ENCUENTRA AUTORIZADA A EMITIR COMPROBANTES CLASE A")
         Case "07"
            stbRechazo.Append("  07 - PARA LA CLASE DE COMPROBANTE SOLICITADO -COMPROBANTE CLASE A- DEBERA CONSIGNAR EN EL CAMPO CODIGO DE DOCUMENTO IDENTIFICATORIO DEL COMPRADOR EL CODIGO 80")
         Case "08"
            stbRechazo.Append("  08 - LA CUIT INDICADA EN EL CAMPO Nro DE IDENTIFICACION DEL COMPRADOR ES INVALIDA")
         Case "09"
            stbRechazo.Append("  09 - LA CUIT INDICADA EN EL CAMPO Nro DE IDENTIFICACION DEL COMPRADOR NO EXISTE EN EL PADRON UNICO DE CONTRIBUYENTES")
         Case "10"
            stbRechazo.Append("  10 - LA CUIT INDICADA EN EL CAMPO Nro DE IDENTIFICACION DEL COMPRADOR NO CORRESPONDE A UN RESPONSABLE INSCRIPTO EN EL IVA ACTIVO")
         Case "11"
            stbRechazo.Append("  11 - EL Nro DE COMPROBANTE DESDE INFORMADO NO ES CORRELATIVO AL ULTIMO Nro DE COMPROBANTE REGISTRADO/HASTA SOLICITADO PARA ESE TIPO DE COMPROBANTE Y PUNTO DE VENTA")
         Case "12"
            stbRechazo.Append("  12 - EL RANGO INFORMADO SE ENCUENTRA AUTORIZADO CON ANTERIORIDAD PARA LA MISMA CUIT, TIPO DE COMPROBANTE Y PUNTO DE VENTA")
         Case "13"
            stbRechazo.Append("  13 - LA CUIT INDICADA SE ENCUENTRA COMPRENDIDA EN EL REGIMEN ESTABLECIDO POR LA RESOLUCION GENERAL Nro 2177 Y/O EN EL TITULO I DE LA RESOLUCION GENERAL Nro 1361 ART. 24 DE LA RG Nro 2177")
         Case "15"
            stbRechazo.Append("  15 - LA CUIT INFORMADA DEL EMISOR NO CUMPLE LAS CONDICIONES SEGÚN EL RÉGIMEN FCE")
         Case "16"
            stbRechazo.Append("  16 - LA CUIT INFORMADA DEL EMISOR NO TIENE ACTIVO EL DOMICILIO FISCAL ELECTRONICO")
         Case "17"
            stbRechazo.Append("  17 - SI EL TIPO DE COMPROBANTE QUE ESTÁ AUTORIZANDO ES MIPYMES (FCE), EL RECEPTOR DEL COMPROBANTE INFORMADO EN DOCTIPO Y DOCNRO DEBE CORRESPONDER A UN CONTRIBUYENTE CARACTERIZADO COMO GRANDE O PYME QUE OPTÓ.")
         Case "18"
            stbRechazo.Append("  18 - SI EL TIPO DE COMPROBANTE QUE ESTÁ AUTORIZANDO ES MIPYMES (FCE), EL RECEPTOR DEL COMPROBANTE DEBE TENER HABILITADO EL DOMICILIO FISCAL ELECTRÓNICO")
         Case "22"
            stbRechazo.Append("  22 - SI EL TIPO DE COMPROBANTE QUE ESTÁ AUTORIZANDO ES MIPYMES (FCE) CLASE 'B', EL RECEPTOR DEL COMPROBANTE INFORMADO EN DOCTIPO Y DOCNRO DEBE ENCONTRARSE REGISTRADOS DE FORMA ACTIVA EN EL Impuesto IVA, MONOTIBUTO o EXENTO.")
         Case "21"
            stbRechazo.Append("  21 - LA CUIT RECEPTORA SE ENCUENTRA INACTIVA POR HABER SIDO INCLUÍDA EN LA CONSULTA DE FACTURAS APÓCRIFAS.NO PODRÁ COMPUTARSE EL CRÉDITO FISCAL")
         Case Else
            stbRechazo.AppendFormat("  Obs: {0} (no controlado, consultar documentación)", obs)
      End Select
      Return stbRechazo
   End Function

   Friend Function RecuperarCAEv1(comprobanteVenta As Entidades.Venta) As Entidades.AFIPCAE
      Dim comp As WSBFE.ClsBFEGetCMPR = Me.GetComprobanteEmitido(comprobanteVenta.TipoComprobante.IdTipoComprobante, comprobanteVenta.LetraComprobante, comprobanteVenta.NumeroComprobante, comprobanteVenta.CentroEmisor)
      'realiza validaciones para comprobar que el comprobante que recuperamos el CAE es 
      'el mismo que ya enviamos antes
      Dim compAComparar As WSBFE.ClsBFERequest = Me.GetFEComprobanteParaAFIP(comprobanteVenta)

      If Not EsIgual(comp, compAComparar) Then
         Throw New Exception("El comprobante que esta en AFIP no es igual al que intenta consultar.")
      End If

      Dim en As Entidades.AFIPCAE = New Entidades.AFIPCAE()
      en.CAE = comp.Cae
      en.CAEVencimiento = New DateTime(Int32.Parse(comp.Fch_venc_Cae.Substring(0, 4)), Int32.Parse(comp.Fch_venc_Cae.Substring(4, 2)), Int32.Parse(comp.Fch_venc_Cae.Substring(6, 2)))
      Return en
   End Function

   Public Function GetUltimoComprobanteAutorizado(idTipoComprobante As String, letra As String, emisor As Integer) As Long
      Try
         da.OpenConection()

         ControlaAutorizacion()

         Dim ws As WSBFE.Service = New WSBFE.Service()
         ws.Url = Me._urlBFE
         Dim tipoCbte As Integer = New SqlServer.AFIPTiposComprobantes(da).GetIdTipoComprobanteparaAFIP(idTipoComprobante, letra)
         Dim ptoVenta As Integer = emisor
         Dim argRes As WSBFE.BFEResponseLast_CMP
         Dim comp As WSBFE.ClsBFE_LastCMP = New WSBFE.ClsBFE_LastCMP()
         comp.Cuit = Me._autorizacion.Cuit
         comp.Pto_venta = emisor.ToShort()
         comp.Sign = Me._autorizacion.Sign
         comp.Tipo_cbte = New SqlServer.AFIPTiposComprobantes(da).GetIdTipoComprobanteparaAFIP(idTipoComprobante, letra).ToShort()
         comp.Token = Me._autorizacion.Token
         argRes = ws.BFEGetLast_CMP(comp)
         If argRes.BFEErr IsNot Nothing AndAlso argRes.BFEErr.ErrCode > 0 Then
            Dim err As StringBuilder = New StringBuilder("")
            err.Append("Error en la obtención del último comprobante autorizado. ").AppendLine()
            If argRes.BFEErr.ErrCode = 500 Or argRes.BFEErr.ErrCode = 501 Then
               err.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
               err.AppendLine("-------- DETALLE TÉCNICO --------")
            End If
            err.AppendFormat("{0} - {1}", argRes.BFEErr.ToString(), argRes.BFEErr.ErrMsg).AppendLine()
            Throw New Exception(err.ToString())
         End If
         Return argRes.BFEResult_LastCMP.Cbte_nro

      Catch ex As Exception
         Throw
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function TestearServidoresV1() As String
      Return EjecutaConConexion(
      Function()
         ControlaAutorizacion()

         Dim ws = New WSBFE.Service()
         ws.Url = _urlBFE

         Dim argRes = ws.BFEDummy()
         Return argRes.AuthServer + "/" + argRes.AppServer + "/" + argRes.DbServer
      End Function)
   End Function

   Public Function GetComprobanteEmitido(idTipoComprobante As String,
                                                   letra As String,
                                                   nroComprobante As Long,
                                                   puntoVenta As Integer) As WSBFE.ClsBFEGetCMPR
      ControlaAutorizacion()

      Dim ws As WSBFE.Service = New WSBFE.Service()
      ws.Url = Me._urlBFE

      Dim argRes As WSBFE.BFEGetCMPResponse
      Dim argReq As WSBFE.ClsBFEGetCMP = New WSBFE.ClsBFEGetCMP()
      argReq.Tipo_cbte = New SqlServer.AFIPTiposComprobantes(da).GetIdTipoComprobanteparaAFIP(idTipoComprobante, letra).ToShort()
      argReq.Cbte_nro = nroComprobante
      argReq.Punto_vta = puntoVenta
      argRes = ws.BFEGetCMP(Me._autorizacion, argReq)
      If argRes.BFEErr IsNot Nothing AndAlso argRes.BFEErr.ErrCode > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error en la consulta del comprobante. ").AppendLine()
         If argRes.BFEErr.ErrCode = 500 Or argRes.BFEErr.ErrCode = 501 Then
            stb.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
            stb.AppendLine("-------- DETALLE TÉCNICO --------")
         End If
         stb.Append(argRes.BFEErr.ErrCode.ToString() + " - " + argRes.BFEErr.ErrMsg).AppendLine()
         Throw New Exception(stb.ToString())
      End If

      Return argRes.BFEResultGet
   End Function

   'Public Function GetPuntosDeVentaV1() As WSFEv1.PtoVenta()
   '   Me.ControlaAutorizacion()

   '   Dim ws As WSFEv1.Service = New WSFEv1.Service()
   '   ws.Url = Me._urlBFE

   '   Dim argRes As WSFEv1.FEPtoVentaResponse
   '   'argRes = ws.FEParamGetPtosVenta(Me._autorizacionV1)
   '   If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
   '      Dim stb As StringBuilder = New StringBuilder("")
   '      stb.Append("Error en la consulta del punto de venta. ").AppendLine()
   '      For Each er As WSFEv1.Err In argRes.Errors
   '         stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
   '      Next
   '      Throw New Exception(stb.ToString())
   '   End If

   '   Return argRes.ResultGet
   'End Function

   'Public Function GetCantMaxRegistroDetalleV1() As Integer
   '   Me.ControlaAutorizacion()

   '   Dim ws As WSFEv1.Service = New WSFEv1.Service()
   '   ws.Url = Me._urlBFE

   '   Dim argRes As WSFEv1.FERegXReqResponse
   '   'argRes = ws.FECompTotXRequest(Me._autorizacion)
   '   If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
   '      Dim stb As StringBuilder = New StringBuilder("")
   '      stb.Append("Error en la consulta de Cant. Maxima Registros. ").AppendLine()
   '      For Each er As WSFEv1.Err In argRes.Errors
   '         stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
   '      Next
   '      Throw New Exception(stb.ToString())
   '   End If
   '   Return argRes.RegXReq
   'End Function

   'Public Function GetTiposTributosV1() As WSFEv1.TributoTipo()
   '   Me.ControlaAutorizacion()

   '   Dim ws As WSFEv1.Service = New WSFEv1.Service()
   '   ws.Url = Me._urlBFE

   '   Dim argRes As WSFEv1.FETributoResponse
   '   'argRes = ws.FEParamGetTiposTributos(Me._autorizacion)
   '   If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
   '      Dim stb As StringBuilder = New StringBuilder("")
   '      stb.Append("Error. ").AppendLine()
   '      For Each er As WSFEv1.Err In argRes.Errors
   '         stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
   '      Next
   '      Throw New Exception(stb.ToString())
   '   End If
   '   Return argRes.ResultGet
   'End Function

   'Public Function GetTiposOpcionalesV1() As WSFEv1.OpcionalTipo()
   '   Me.ControlaAutorizacion()

   '   Dim ws As WSFEv1.Service = New WSFEv1.Service()
   '   ws.Url = Me._urlBFE

   '   Dim argRes As WSFEv1.OpcionalTipoResponse
   '   'argRes = ws.FEParamGetTiposOpcional(Me._autorizacionV1)
   '   If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
   '      Dim stb As StringBuilder = New StringBuilder("")
   '      stb.Append("Error. ").AppendLine()
   '      For Each er As WSFEv1.Err In argRes.Errors
   '         stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
   '      Next
   '      Throw New Exception(stb.ToString())
   '   End If
   '   Return argRes.ResultGet
   'End Function

   Public Function GetTiposMonedas() As WSBFE.ClsBFEResponse_Mon()
      Me.ControlaAutorizacion()

      Dim ws As WSBFE.Service = New WSBFE.Service()
      ws.Url = Me._urlBFE

      Dim argRes As WSBFE.BFEResponse_Mon
      argRes = ws.BFEGetPARAM_MON(Me._autorizacion)
      If argRes.BFEErr IsNot Nothing AndAlso argRes.BFEErr.ErrCode > 0 Then
         Dim stb As StringBuilder = New StringBuilder("")
         stb.Append("Error. ").AppendLine()
         stb.Append(argRes.BFEErr.ErrCode.ToString() + " - " + argRes.BFEErr.ErrMsg).AppendLine()
         Throw New Exception(stb.ToString())
      End If
      Return argRes.BFEResultGet
   End Function

   'Public Function GetTiposAlicuotasV1() As WSFEv1.IvaTipo()
   '   Me.ControlaAutorizacion()

   '   Dim ws As WSFEv1.Service = New WSFEv1.Service()
   '   ws.Url = Me._urlBFE

   '   Dim argRes As WSFEv1.IvaTipoResponse
   '   '  argRes = ws.FEParamGetTiposIva(Me._autorizacion)
   '   If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
   '      Dim stb As StringBuilder = New StringBuilder("")
   '      stb.Append("Error. ").AppendLine()
   '      For Each er As WSFEv1.Err In argRes.Errors
   '         stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
   '      Next
   '      Throw New Exception(stb.ToString())
   '   End If
   '   Return argRes.ResultGet
   'End Function

   'Public Function GetTiposDocumentosV1() As WSFEv1.DocTipo()
   '   Me.ControlaAutorizacion()

   '   Dim ws As WSFEv1.Service = New WSFEv1.Service()
   '   ws.Url = Me._urlBFE

   '   Dim argRes As WSFEv1.DocTipoResponse
   '   'argRes = ws.FEParamGetTiposDoc(Me._autorizacionV1)
   '   If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
   '      Dim stb As StringBuilder = New StringBuilder("")
   '      stb.Append("Error. ").AppendLine()
   '      For Each er As WSFEv1.Err In argRes.Errors
   '         stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
   '      Next
   '      Throw New Exception(stb.ToString())
   '   End If
   '   Return argRes.ResultGet
   'End Function

   'Public Function GetTiposConceptosV1() As WSFEv1.ConceptoTipo()
   '   Me.ControlaAutorizacion()

   '   Dim ws As WSFEv1.Service = New WSFEv1.Service()
   '   ws.Url = Me._urlBFE

   '   Dim argRes As WSFEv1.ConceptoTipoResponse
   '   'argRes = ws.FEParamGetTiposConcepto(Me._autorizacionV1)
   '   If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
   '      Dim stb As StringBuilder = New StringBuilder("")
   '      stb.Append("Error. ").AppendLine()
   '      For Each er As WSFEv1.Err In argRes.Errors
   '         stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
   '      Next
   '      Throw New Exception(stb.ToString())
   '   End If
   '   Return argRes.ResultGet
   'End Function

   'Public Function GetTiposComprobantesV1() As WSFEv1.CbteTipo()
   '   Me.ControlaAutorizacion()

   '   Dim ws As WSFEv1.Service = New WSFEv1.Service()
   '   ws.Url = Me._urlBFE

   '   Dim argRes As WSFEv1.CbteTipoResponse
   '   'argRes = ws.FEParamGetTiposCbte(Me._autorizacionV1)
   '   If argRes.Errors IsNot Nothing AndAlso argRes.Errors.Count > 0 Then
   '      Dim stb As StringBuilder = New StringBuilder("")
   '      stb.Append("Error. ").AppendLine()
   '      For Each er As WSFEv1.Err In argRes.Errors
   '         stb.Append(er.Code.ToString() + " - " + er.Msg).AppendLine()
   '      Next
   '      Throw New Exception(stb.ToString())
   '   End If
   '   Return argRes.ResultGet
   'End Function

#End Region

End Class
