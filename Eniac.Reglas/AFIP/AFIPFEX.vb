Imports System.Transactions
Imports System.Xml
Public Class AFIPFEX
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Eniac.Datos.DataAccess)
      da = accesoDatos
      Me._urlFEX = New Parametros().GetValorPD(Entidades.Parametro.Parametros.URLWSFEX.ToString(), String.Empty)
   End Sub

#End Region

#Region "Campos"

   Private _urlFEX As String
   Private _autorizacionV1 As WSFEXv1.ClsFEXAuthRequest

   Private _redondeo As Integer = 2
   Private _redondeoPrecios As Integer = 4

#End Region

#Region "Metodos comunes"

   '-- Controla Autorizacion.- --
   Private Sub ControlaAutorizacionV1()
      Dim awsaa As AFIPWSAA = New AFIPWSAA(da)
      '-- Crear Certificado.- --
      awsaa.CrearCertificado("wsfex")
      '-- Crear Autorizacion.- --
      CreaAutorizacionv1()
   End Sub
   '-- Crea Autorizacion.- --
   Private Sub CreaAutorizacionv1()
      Dim m_xmld As XmlDocument
      Dim m_nodelist As XmlNodeList
      Dim m_node As XmlNode
      Dim sql As SqlServer.ParametrosArchivos = New SqlServer.ParametrosArchivos(da)

      m_xmld = New XmlDocument()
      m_xmld.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOFEX.ToString()))
      m_nodelist = m_xmld.SelectNodes("/loginTicketResponse/credentials")
      _autorizacionV1 = New WSFEXv1.ClsFEXAuthRequest
      For Each m_node In m_nodelist
         _autorizacionV1.Token = m_node.ChildNodes.Item(0).InnerText
         _autorizacionV1.Sign = m_node.ChildNodes.Item(1).InnerText
         _autorizacionV1.Cuit = Long.Parse(Publicos.CuitEmpresa)
      Next
   End Sub
   '-- Recupera Codigo de Pais AFIP.- --
   Private Function Get_PaisAfip(oIdPais As String) As Short
      Dim ePais = New Reglas.Paises(da).GetUno(oIdPais)
      Return Convert.ToInt16(ePais.IdAfipPais)
   End Function

   Private Function Get_UnidadMedidaAfip(oUnidMed As String) As Integer
      Return New Reglas.UnidadesDeMedidas(da).GetUno(oUnidMed).IdAFIP
   End Function

#End Region

#Region "WSX 1"

   '-- Solicita CAE por Primera vez.- --
   Friend Function SolicitarCAEExp(comprobanteVenta As Entidades.Venta) As Entidades.AFIPCAE
      Dim wsService = New WSFEXv1.Service With
      {
         .Url = Me._urlFEX
      }
      '-- Define Variable de Respuesta.- --
      Dim rRespuesta = New WSFEXv1.FEXResponseAuthorize
      '-- Anexa Authorize.- --
      ControlaAutorizacionV1()
      '-- Arma el Comprobante para Autorizar.- --
      Dim cbteAFIP As WSFEXv1.ClsFEXRequest = GetComprobanteParaAFIPExp(comprobanteVenta)
      '-- Ejecuta Procedimiento de Autorizacion.- --
      rRespuesta = wsService.FEXAuthorize(_autorizacionV1, cbteAFIP)
      '-- Valida existencia de Error.- --
      If rRespuesta.FEXErr.ErrCode <> 0 Then
         Dim mensajeError As System.Text.StringBuilder = New System.Text.StringBuilder()
         mensajeError.Append("Error en la obtención del CAE. ").AppendLine()
         If rRespuesta.FEXErr.ErrCode = 500 Or rRespuesta.FEXErr.ErrCode = 501 Then
            mensajeError.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
            mensajeError.AppendLine("-------- DETALLE TÉCNICO --------")
         End If
         mensajeError.Append(rRespuesta.FEXErr.ErrCode.ToString() + " - " + rRespuesta.FEXErr.ErrMsg).AppendLine()
         Throw New Exception(mensajeError.ToString())
      End If

      '-- Define Variable de Respuesta.- --
      Dim rCae = rRespuesta.FEXResultAuth
      '-- Define Entidad CAE.- --
      Dim eCae = New Entidades.AFIPCAE()
      '-- Recupera Datos de CAE.- -------------------
      eCae.CAE = rCae.Cae
      eCae.CAEVencimiento = rCae.Fch_venc_Cae.ToDateTimeFormatoPropio("yyyyMMdd")
      '----------------------------------------------
      Return eCae

   End Function

   '-- Recupera CAE de Comprobante.- --
   Friend Function RecuperarCAEExp(comprobanteVenta As Entidades.Venta) As Entidades.AFIPCAE

      '-- Anexa Authorize.- --
      ControlaAutorizacionV1()

      '-- Recupera Comprobantes de Exportacion.- --
      Dim rCpteExport As WSFEXv1.ClsFEXGetCMPR = GetRecuperaComprobanteExp(Convert.ToInt16(comprobanteVenta.AFIPIdTipoComprobante),
                                                                           comprobanteVenta.NumeroComprobante,
                                                                           comprobanteVenta.CentroEmisor)
      '-- Comprobante del Siga.- 
      Dim sCpteExport As WSFEXv1.ClsFEXRequest = GetComprobanteParaAFIPExp(comprobanteVenta)

      If Not EsIgual(rCpteExport, sCpteExport) Then
         Throw New Exception("El comprobante que esta en AFIP no es igual al que intenta consultar.")
      End If

      Dim en = New Entidades.AFIPCAE With
      {
         .CAE = rCpteExport.Cae,
         .CAEVencimiento = rCpteExport.Fch_venc_Cae.ToDateTimeFormatoPropio("yyyyMMdd")
      }

      Return en

   End Function

   '-- Recupera CAE de Comprobante PreSolicitar.- --
   Friend Function RecuperarCAEExp_PreSolicitar(comprobanteVenta As Entidades.Venta) As Entidades.AFIPCAE

      '-- Anexa Authorize.- --
      ControlaAutorizacionV1()

      '-- Busco el documento en AFIP que quiero comparar con el que tengo grabado.- 
      Dim eCpteCAE = New Entidades.AFIPCAE()
      '-- Recupera Comprobantes de Exportacion.- --
      Dim rCpteExport = New WSFEXv1.ClsFEXGetCMPR
      Try
         '-- Recupera Comprobantes de Exportacion.- --
         rCpteExport = GetRecuperaComprobanteExp(Convert.ToInt16(comprobanteVenta.AFIPIdTipoComprobante),
                                                                              comprobanteVenta.NumeroComprobante,
                                                                              comprobanteVenta.CentroEmisor)
      Catch ex As Exception
         '-- Si da un error desde AFIP de cualquier tipo retorno la entidad vacia al metodo que la llamó.- 
         Return eCpteCAE
      End Try

      '-- Realiza validaciones para comprobar que el comprobante que recuperamos el CAE es el mismo que ya enviamos antes
      '-- convierto el comprobante que tengo en un comprobante de AFIP para compararlo.- --
      '-- Comprobante del Siga.- 
      Dim sCpteExport As WSFEXv1.ClsFEXRequest = GetComprobanteParaAFIPExp(comprobanteVenta)

      If EsIgual(rCpteExport, sCpteExport) Then
         With eCpteCAE
            .CAE = rCpteExport.Cae
            .CAEVencimiento = rCpteExport.Fch_venc_Cae.ToDateTimeFormatoPropio("yyyyMMdd")
         End With
      End If
      '-- Devuelve Entidad.- --
      Return eCpteCAE

   End Function

#End Region

#Region "Funciones-Anexas.-"

   '-- Confecciona el Comprobante de Exportacion AFIP.- --
   Friend Function GetComprobanteParaAFIPExp(comprobanteVenta As Entidades.Venta) As WSFEXv1.ClsFEXRequest
      Dim cpte = New WSFEXv1.ClsFEXRequest

      With cpte
         '-- Campos IdTrans Secuencia.- --
         Dim IdTrans As WSFEXv1.ClsFEXResponse_LastID = GetRecuperaLastRequest()
         .Id = (IdTrans.Id + 1)                                                                              '-- Identificador del Requerimiento.-              --   
         '--------------------------------

         .Cbte_Tipo = Convert.ToInt16(comprobanteVenta.AFIPIdTipoComprobante)                                '-- Codigo de Comprobante AFIP.-                   --
         .Fecha_cbte = comprobanteVenta.Fecha.ToString("yyyyMMdd")                                           '-- Fecha de Comprobante.-                         --
         .Punto_vta = comprobanteVenta.CentroEmisor                                                          '-- Punto de Venta - Centro Emisor.-               --
         .Cbte_nro = comprobanteVenta.NumeroComprobante                                                      '-- Nro de Comprobante.-                           --
         .Tipo_expo = comprobanteVenta.ConceptoDelComprobante                                                '-- Tipo de Exportacion.-                          --       

         .Permiso_existente = ""                                                                      '-- Indica si Posee Doc Aduanero.- --
         '-- Permisos.- ---------------------------------
         If .Cbte_Tipo = 20 OrElse .Cbte_Tipo = 21 OrElse (.Cbte_Tipo = 19 And (.Tipo_expo = 2 Or .Tipo_expo = 4)) Then
            'Según código de error AFIP 1550
            'Permiso_existente: "vacío” si el campo Cbte_Tipo es 20 ó 21 o si Cbte_Tipo es igual a 19 y el campo Tipo_expo es igual a 2 ó 4
            .Permiso_existente = String.Empty
         Else
            If comprobanteVenta.ExportacionEmbarques.Count = 0 Then
               Select Case comprobanteVenta.AFIPIdTipoComprobante
                  Case 19
                     .Permiso_existente = "N"                                                                           '-- Indica si Posee Doc Aduanero.- --
               End Select
            Else
               Select Case comprobanteVenta.AFIPIdTipoComprobante
                  Case 19
                     .Permiso_existente = "S"                                                                           '-- Indica si Posee Doc Aduanero.- --
               End Select
               Dim lstPermisos As New List(Of WSFEXv1.Permiso)

               For Each VentaExportEmb As Entidades.VentaExportacionEmbarques In comprobanteVenta.ExportacionEmbarques
                  lstPermisos.Add(New WSFEXv1.Permiso() With {.Id_permiso = VentaExportEmb.IdPermisoEmbarque,
                                                              .Dst_merc = New Reglas.Paises().GetUno(VentaExportEmb.IdDestinoDespacho).IdAfipPais})
               Next
               .Permisos = lstPermisos.ToArray()
            End If
         End If
         '-----------------------------------------------

         .Dst_cmp = Get_PaisAfip(comprobanteVenta.IdDestinoExportacion)                                      '-- Obtienen Codigo de Pais Afip.-                 --
         .Cliente = comprobanteVenta.Cliente.NombreCliente                                                   '-- Apellido y Nombre o Razon Social del Cliente.- --
         .Cuit_pais_cliente = Long.Parse(comprobanteVenta.Cliente.Cuit)                                      '-- Numero de CUIT del Cliente.-                   --
         .Domicilio_cliente = comprobanteVenta.Cliente.Direccion                                             '-- Domiclio comercial del Cliente.-               --
         .Id_impositivo = Nothing                                                                            '-- Clave de Identificacion Tributaria Comprador.- --    

         Dim cotizacionMoneda As Decimal
         If comprobanteVenta.IdMoneda = Entidades.Moneda.Dolar Then                                          '-- Carga Monedas y Cotizaciones.-                 --
            .Moneda_Id = "DOL"
            .Moneda_ctz = comprobanteVenta.CotizacionDolar
            cotizacionMoneda = comprobanteVenta.CotizacionDolar
         Else
            .Moneda_Id = "PES"
            .Moneda_ctz = 1
            cotizacionMoneda = 1
         End If                                                                                             '---------------------------------------------------

         .Imp_total = Decimal.Round((comprobanteVenta.ImporteTotal * comprobanteVenta.TipoComprobante.CoeficienteValores) / cotizacionMoneda, _redondeo)   '-- Importe Total del Comprobante.-               --
         .Incoterms = comprobanteVenta.IdIcotermExportacion                                                 '-- Incoterms - Clausulas de Ventas.-             --
         .Idioma_cbte = Entidades.AFIPCAE.IdiomasComprobantes.Español                                       '-- Idioma del Comprobante.-                      --  

         If comprobanteVenta.FechaPagoExportacion.HasValue AndAlso .Cbte_Tipo = 19 AndAlso (.Tipo_expo = 2 Or .Tipo_expo = 4) Then
            .Fecha_pago = comprobanteVenta.FechaPagoExportacion.Value.ToString("yyyyMMdd")
         End If

         '-- Comprobantes Asociados.- -------------------
         Dim lstCbtesAsoc As New List(Of WSFEXv1.Cmp_asoc)()
         'Array para informar los comprobantes asociados <CbteAsoc>
         If comprobanteVenta.TipoComprobante.AFIPWSRequiereComprobanteAsociado Then
            For Each vv In comprobanteVenta.Invocados
               Dim asociado = vv.Invocado
               Dim cteAfipAsociado = New AFIPTiposComprobantes(da).GetUno(asociado.IdTipoComprobante, asociado.Letra)
               lstCbtesAsoc.Add(New WSFEXv1.Cmp_asoc() With {.Cbte_tipo = cteAfipAsociado.IdAFIPTipoComprobante.ToShort(),
                                                             .Cbte_punto_vta = asociado.CentroEmisor,
                                                             .Cbte_nro = asociado.NumeroComprobante,
                                                             .Cbte_cuit = Long.Parse(Publicos.CuitEmpresa)})
            Next
         End If
         If lstCbtesAsoc.Count > 0 Then
            .Cmps_asoc = lstCbtesAsoc.ToArray()
         Else
            .Cmps_asoc = Nothing
         End If
         '-----------------------------------------------

         '-- Items.- ------------------------------------
         Dim lstItemsCbtes As New List(Of WSFEXv1.Item)
         'Array para informar los items del comprobantes.- --
         For Each ItemCbte As Entidades.VentaProducto In comprobanteVenta.VentasProductos

            lstItemsCbtes.Add(New WSFEXv1.Item() With
                         {
                              .Pro_codigo = ItemCbte.IdProducto,
                              .Pro_ds = ItemCbte.NombreProducto,
                              .Pro_qty = ItemCbte.Cantidad,
                              .Pro_umed = Get_UnidadMedidaAfip(ItemCbte.IdUnidadDeMedida),
                              .Pro_precio_uni = Decimal.Round((ItemCbte.Precio / cotizacionMoneda), (_redondeoPrecios)),
                              .Pro_bonificacion = (Decimal.Round((ItemCbte.Precio / cotizacionMoneda) * ItemCbte.Cantidad, (_redondeoPrecios)) - Decimal.Round(((ItemCbte.ImporteTotal * comprobanteVenta.TipoComprobante.CoeficienteValores) / cotizacionMoneda), _redondeo)),
                              .Pro_total_item = Decimal.Round(((ItemCbte.ImporteTotal * comprobanteVenta.TipoComprobante.CoeficienteValores) / cotizacionMoneda), _redondeo)
                         })
         Next
         .Items = lstItemsCbtes.ToArray()
         '----------------------------------------------+
         Return cpte
      End With

   End Function
   '-- Compara dos Comprobantes.- --
   Private Function EsIgual(oCpteAFIP As WSFEXv1.ClsFEXGetCMPR, oCpteSIGA As WSFEXv1.ClsFEXRequest) As Boolean
      With oCpteAFIP
         '-- Valida Fecha de Comprobante.- --
         If (.Fecha_cbte <> oCpteSIGA.Fecha_cbte) Then
            Return False
         End If
         '-- Valida Tipo de Comprobante.- --
         If (.Cbte_tipo <> oCpteSIGA.Cbte_Tipo) Then
            Return False
         End If
         '-- Valida Punto de Venta del Comprobante.- --
         If (.Punto_vta <> oCpteSIGA.Punto_vta) Then
            Return False
         End If
         '-- Valida Destino Comprobante.-  --
         If (.Dst_cmp <> oCpteSIGA.Dst_cmp) Then
            Return False
         End If
         '-- Valida Cliente Comprobante.-  --
         If (.Cuit_pais_cliente <> oCpteSIGA.Cuit_pais_cliente) Then
            Return False
         End If
         '-- Valida Cliente Comprobante.-  --
         If (.Imp_total <> oCpteSIGA.Imp_total) Then
            Return False
         End If
         '-- Valida Incoterm Comprobante.-  --
         If (.Incoterms <> oCpteSIGA.Incoterms) Then
            Return False
         End If

         Return True
      End With

   End Function

   '-- Recupera Last ID Request de Exportacion.- --
   Public Function GetRecuperaLastRequest() As WSFEXv1.ClsFEXResponse_LastID

      Dim argRes As WSFEXv1.FEXResponse_LastID
      Dim ws = New WSFEXv1.Service With
      {
         .Url = _urlFEX
      }
      '-- Obtienen Los datos del ultimo LastID.- --
      argRes = ws.FEXGetLast_ID(_autorizacionV1)
      '--------------------------------------------
      If argRes.FEXErr.ErrCode <> 0 Then
         '-- Devuelve Resultado.- --
         Dim stb = New StringBuilder("")
         stb.Append("Error en la consulta del Last ID Request de Exportacio. ").AppendLine()
         If argRes.FEXErr.ErrCode = 500 Or argRes.FEXErr.ErrCode = 501 Then
            stb.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
            stb.AppendLine("-------- DETALLE TÉCNICO --------")
         End If
         stb.Append(argRes.FEXErr.ErrCode.ToString() + " - " + argRes.FEXErr.ErrMsg).AppendLine()
         Throw New Exception(stb.ToString())
      End If
      '-- Devuelve Resultado.- --
      Return argRes.FEXResultGet

   End Function
   '-- Recupera Comprobantes de Exportacion.- --
   Public Function GetRecuperaComprobanteExp(idTipoComprobante As Short,
                                             nroComprobante As Long,
                                             puntoVenta As Integer) As WSFEXv1.ClsFEXGetCMPR

      '-- Anexa Authorize.- --
      ControlaAutorizacionV1()


      Dim argRes As WSFEXv1.FEXGetCMPResponse
      Dim ws = New WSFEXv1.Service With
      {
         .Url = _urlFEX
      }
      Dim argReq = New WSFEXv1.ClsFEXGetCMP With
      {
         .Cbte_tipo = idTipoComprobante,
         .Punto_vta = puntoVenta,
         .Cbte_nro = nroComprobante
      }
      '-- Obtienen Los datos de un Comprobante.- --
      argRes = ws.FEXGetCMP(Me._autorizacionV1, argReq)

      If argRes.FEXErr.ErrCode <> 0 Then
         '-- Devuelve Resultado.- --
         Dim stb = New StringBuilder("")
         stb.Append("Error en la consulta del comprobante. ").AppendLine()
         If argRes.FEXErr.ErrCode = 500 Or argRes.FEXErr.ErrCode = 501 Then
            stb.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
            stb.AppendLine("-------- DETALLE TÉCNICO --------")
         End If
         stb.Append(argRes.FEXErr.ErrCode.ToString() + " - " + argRes.FEXErr.ErrMsg).AppendLine()
         Throw New Exception(stb.ToString())
      End If
      '-- Devuelve Resultado.- --
      Return argRes.FEXResultGet
   End Function

   Public Function GetRecuperaUltCompExp(idTipoComprobante As Short,
                                         puntoVenta As Integer) As Long
      Try
         Me.da.OpenConection()
         '-- Anexa Authorize.- --
         ControlaAutorizacionV1()
         Dim argRes As WSFEXv1.FEXResponseLast_CMP
         Dim ws = New WSFEXv1.Service With
         {
            .Url = _urlFEX
         }
         Dim argReq = New WSFEXv1.ClsFEX_LastCMP With
         {
            .Token = _autorizacionV1.Token,
            .Sign = _autorizacionV1.Sign,
            .Cuit = _autorizacionV1.Cuit,
            .Cbte_Tipo = idTipoComprobante,
            .Pto_venta = puntoVenta
         }
         '-- Obtienen Los datos de un Comprobante.- --
         argRes = ws.FEXGetLast_CMP(argReq)
         If argRes.FEXErr.ErrCode <> 0 Then
            '-- Devuelve Resultado.- --
            Dim stb = New StringBuilder("")
            stb.Append("Error en la consulta del comprobante. ").AppendLine()
            If argRes.FEXErr.ErrCode = 500 Or argRes.FEXErr.ErrCode = 501 Then
               stb.Append("Hubo un problema en los servidores de AFIP. Por favor reintente transmitir en unos minutos.").AppendLine().AppendLine()
               stb.AppendLine("-------- DETALLE TÉCNICO --------")
            End If
            stb.Append(argRes.FEXErr.ErrCode.ToString() + " - " + argRes.FEXErr.ErrMsg).AppendLine()
            Throw New Exception(stb.ToString())
         End If
         '-- Devuelve Resultado.- --
         Return argRes.FEXResult_LastCMP.Cbte_nro

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

#End Region


   Public Function GetCotizacionDolar() As Decimal
      Try
         Using wsService = New WSFEXv1.Service() With
               {
                  .Url = Publicos.FacturaElectronica.URLWSFEX
               }
            ControlaAutorizacionV1()
            Dim result = wsService.FEXGetPARAM_Ctz(_autorizacionV1, "DOL")
            Return result.FEXResultGet.Mon_ctz
         End Using
      Catch ex As Exception
         EjecutaConTransaccion(
         Sub()
            Dim aplicacion = Publicos.IDAplicacionSinergia
            Dim sqlBitacora = New SqlServer.Bitacora(da)
            sqlBitacora.Bitacora_I(actual.Sucursal.Id, -1, Now, aplicacion, actual.Nombre, My.Computer.Name, Entidades.Bitacora.TipoBitacora.SucedioError.ToString(), ex.Message)
         End Sub)
         Return 0
      End Try
   End Function

End Class