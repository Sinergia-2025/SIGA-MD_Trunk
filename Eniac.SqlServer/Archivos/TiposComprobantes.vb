Public Class TiposComprobantes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposComprobantes_I(idTipoComprobante As String,
                                  descripcion As String,
                                  esFiscal As Boolean,
                                  tipo As String,
                                  coeficienteStock As Integer,
                                  grabaLibro As Boolean,
                                  informaLibroIVA As Boolean,
                                  esFacturable As Boolean,
                                  letrasHabilitadas As String,
                                  cantidadMaximaItems As Integer,
                                  imprime As Boolean,
                                  coeficienteValores As Integer,
                                  modificaAlFacturar As String,
                                  esFacturador As Boolean,
                                  afectaCaja As Boolean,
                                  cargaPrecioActual As Boolean,
                                  actualizaCtaCte As Boolean,
                                  descripcionAbrev As String,
                                  puedeSerBorrado As Boolean,
                                  cantidadCopias As Integer,
                                  comprobantesAsociados As String,
                                  esRemitoTransportista As Boolean,
                                  esComercial As Boolean,
                                  cantidadMaximaItemsObserv As Integer,
                                  idTipoComprobanteSecundario As String,
                                  importeTope As Decimal,
                                  idTipoComprobanteEpson As String,
                                  usaFacturacionRapida As Boolean,
                                  importeMinimo As Decimal,
                                  esElectronico As Boolean,
                                  usaFacturacion As Boolean,
                                  utilizaImpuestos As Boolean,
                                  numeracionAutomatica As Boolean,
                                  generaObservConInvocados As Boolean,
                                  importaObservDeInvocados As Boolean,
                                  importaObservGrales As Boolean,
                                  idPlanCuenta As Integer,
                                  esAnticipo As Boolean,
                                  esRecibo As Boolean,
                                  grupo As String,
                                  esPreElectronico As Boolean,
                                  generaContabilidad As Boolean,
                                  utilizaCtaSecundariaProd As Boolean,
                                  utilizaCtaSecundariaCateg As Boolean,
                                  incluirEnExpensas As Boolean,
                                  idTipoComprobanteNCred As String,
                                  idTipoComprobanteNDeb As String,
                                  idProductoNCred As String,
                                  idProductoNDeb As String,
                                  consumePedidos As Boolean,
                                  esPreFiscal As Boolean,
                                  codigoComprobanteSifere As String,
                                  esDespachoImportacion As Boolean,
                                  cargaDescRecActual As Boolean,
                                  idTipoComprobanteContraMovInvocar As String,
                                  alInvocarPedidoAfectaFactura As Boolean,
                                  alInvocarPedidoAfectaRemito As Boolean,
                                  invocarPedidosConEstadoEspecifico As Boolean,
                                  invocaCompras As Boolean,
                                  largoMaximoNumero As Short,
                                  nivelAutorizacion As Short,
                                  requiereReferenciaCtaCte As Boolean,
                                  controlaTopeConsumidorFinal As Boolean,
                                  cargaDescRecGralActual As Boolean,
                                  esReciboClienteVinculado As Boolean,
                                  afipWSIncluyeFechaVencimiento As Boolean?,
                                  afipWSEsFEC As Boolean,
                                  afipWSRequiereReferenciaComercial As Boolean,
                                  afipWSRequiereComprobanteAsociado As Boolean,
                                  afipWSRequiereCBU As Boolean,
                                  afipWSCodigoAnulacion As Boolean,
                                  afipWSRequiereReferenciaTransferencia As Boolean,
                                  orden As Integer,
                                  marcaInvocado As Boolean,
                                  permiteSeleccionarAlicuotaIVA As Boolean,
                                  descripcionImpresion As String,
                                  ActivaTildeMercDespacha As Boolean,
                                  solicitaFechaDevolucion As Boolean,
                                  color As Integer?,
                                  codigoRoela As String,
                                  claseComprobante As Entidades.TipoComprobante.ClasesComprobante,
                                  SolicitaInformeCalidad As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO TiposComprobantes")
         .AppendLine("  (IdTipoComprobante ")
         .AppendLine("  ,EsFiscal ")
         .AppendLine("  ,Descripcion ")
         .AppendLine("  ,Tipo ")
         .AppendLine("  ,CoeficienteStock ")
         .AppendLine("  ,GrabaLibro ")
         .AppendLine("  ,InformaLibroIVA ")
         .AppendLine("  ,EsFacturable ")
         .AppendLine("  ,LetrasHabilitadas ")
         .AppendLine("  ,CantidadMaximaItems ")
         .AppendLine("  ,Imprime ")
         .AppendLine("  ,CoeficienteValores ")
         .AppendLine("  ,ModificaAlFacturar ")
         .AppendLine("  ,EsFacturador ")
         .AppendLine("  ,AfectaCaja ")
         .AppendLine("  ,CargaPrecioActual ")
         .AppendLine("  ,ActualizaCtaCte ")
         .AppendLine("  ,DescripcionAbrev ")
         .AppendLine("  ,PuedeSerBorrado ")
         .AppendLine("  ,CantidadCopias ")
         .AppendLine("  ,ComprobantesAsociados ")
         .AppendLine("  ,EsRemitoTransportista ")
         .AppendLine("  ,EsComercial ")
         .AppendLine("  ,CantidadMaximaItemsObserv ")
         .AppendLine("  ,IdTipoComprobanteSecundario ")
         .AppendLine("  ,ImporteTope ")
         .AppendLine("  ,IdTipoComprobanteEpson ")
         .AppendLine("  ,UsaFacturacionRapida ")
         .AppendLine("  ,ImporteMinimo ")
         .AppendLine("  ,EsElectronico ")
         .AppendLine("  ,UsaFacturacion ")
         .AppendLine("  ,UtilizaImpuestos ")
         .AppendLine("  ,NumeracionAutomatica ")
         .AppendLine("  ,GeneraObservConInvocados ")
         .AppendLine("  ,ImportaObservDeInvocados ")
         .AppendLine("  ,ImportaObservGrales ")
         .AppendLine("  ,IdPlanCuenta ")
         .AppendLine("  ,EsAnticipo ")
         .AppendLine("  ,EsRecibo ")
         .AppendLine("  ,Grupo ")
         .AppendLine("  ,EsPreElectronico ")
         .AppendLine("  ,GeneraContabilidad ")
         .AppendLine("  ,UtilizaCtaSecundariaProd")
         .AppendLine("  ,UtilizaCtaSecundariaCateg")
         .AppendLine("  ,IncluirEnExpensas")
         .AppendLine("  ,IdTipoComprobanteNCred")
         .AppendLine("  ,IdTipoComprobanteNDeb")
         .AppendLine("  ,IdProductoNCred")
         .AppendLine("  ,IdProductoNDeb")
         .AppendLine("  ,ConsumePedidos")
         .AppendLine("  ,EsPreFiscal")
         .AppendLine("  ,CodigoComprobanteSifere")
         .AppendLine("  ,EsDespachoImportacion")
         .AppendLine("  ,CargaDescRecActual")
         .AppendLine("  ,IdTipoComprobanteContraMovInvocar")
         .AppendLine("  ,AlInvocarPedidoAfectaFactura")
         .AppendLine("  ,AlInvocarPedidoAfectaRemito")
         .AppendLine("  ,InvocarPedidosConEstadoEspecifico")
         .AppendLine("  ,InvocaCompras")
         .AppendLine("  ,LargoMaximoNumero")
         .AppendLine("  ,NivelAutorizacion")
         .AppendLine("  ,RequiereReferenciaCtaCte")
         .AppendLine("  ,ControlaTopeConsumidorFinal")
         .AppendLine("  ,CargaDescRecGralActual")
         .AppendLine("  ,EsReciboClienteVinculado")
         .AppendLine("  ,AFIPWSIncluyeFechaVencimiento")
         .AppendLine("  ,AFIPWSEsFEC")
         .AppendLine("  ,AFIPWSRequiereReferenciaComercial")
         .AppendLine("  ,AFIPWSRequiereComprobanteAsociado")
         .AppendLine("  ,AFIPWSRequiereCBU")
         .AppendLine("  ,AFIPWSCodigoAnulacion")
         .AppendLine("  ,AFIPWSRequiereReferenciaTransferencia")
         .AppendLine("  ,Orden")
         .AppendLine("  ,MarcaInvocado")
         .AppendLine("  ,PermiteSeleccionarAlicuotaIVA")
         .AppendLine("  ,DescripcionImpresion")
         .AppendLine("  ,ActivaTildeMercDespacha")
         .AppendFormatLine("  ,{0}", Entidades.TipoComprobante.Columnas.SolicitaFechaDevolucion.ToString())
         .AppendLine("  ,Color")
         '-- REQ-35059.- ----------------------------------------
         .AppendLine("  ,CodigoRoela")
         '-------------------------------------------------------
         .AppendLine("  ,ClaseComprobante")
         '-- REQ-40445.- ----------------------------------------
         .AppendLine("  ,SolicitaInformeCalidad")
         '-------------------------------------------------------
         .AppendLine(") VALUES(")
         .AppendFormatLine("   '{0}'", idTipoComprobante)
         .AppendFormatLine("  ,'{0}'", esFiscal)
         .AppendFormatLine("  ,'{0}'", descripcion)

         .AppendFormatLine("  ,'{0}'", tipo)
         .AppendFormatLine("  , {0}", coeficienteStock)
         .AppendFormatLine("  ,'{0}'", grabaLibro)
         .AppendFormatLine("  ,'{0}'", informaLibroIVA)
         .AppendFormatLine("  ,'{0}'", esFacturable)
         .AppendFormatLine("  , {0} ", GetStringParaQueryConComillas(letrasHabilitadas))

         .AppendFormatLine("  , {0} ", cantidadMaximaItems)
         .AppendFormatLine("  ,'{0}'", imprime)
         .AppendFormatLine("  , {0} ", coeficienteValores)
         .AppendFormatLine("  , {0}", GetStringParaQueryConComillas(modificaAlFacturar))
         .AppendFormatLine("  ,'{0}'", esFacturador)
         .AppendFormatLine("  ,'{0}'", afectaCaja)
         .AppendFormatLine("  ,'{0}'", cargaPrecioActual)
         .AppendFormatLine("  ,'{0}'", actualizaCtaCte)
         .AppendFormatLine("  ,'{0}'", descripcionAbrev)
         .AppendFormatLine("  ,'{0}'", puedeSerBorrado)
         .AppendFormatLine("  , {0} ", cantidadCopias)
         .AppendFormatLine("  , {0} ", GetStringParaQueryConComillas(comprobantesAsociados))
         .AppendFormatLine("  ,'{0}'", esRemitoTransportista)
         .AppendFormatLine("  ,'{0}'", esComercial)
         .AppendFormatLine("  , {0} ", cantidadMaximaItemsObserv)
         .AppendFormatLine("  , {0} ", GetStringParaQueryConComillas(idTipoComprobanteSecundario))

         .AppendFormatLine("  , {0} ", importeTope)
         .AppendFormatLine("  ,'{0}'", idTipoComprobanteEpson)

         .AppendFormatLine("  ,'{0}'", usaFacturacionRapida)
         .AppendFormatLine("  , {0} ", importeMinimo)
         .AppendFormatLine("  ,'{0}'", esElectronico)
         .AppendFormatLine("  ,'{0}'", usaFacturacion)
         .AppendFormatLine("  ,'{0}'", utilizaImpuestos)
         .AppendFormatLine("  ,'{0}'", numeracionAutomatica)
         .AppendFormatLine("  ,'{0}'", generaObservConInvocados)
         .AppendFormatLine("  ,'{0}'", importaObservDeInvocados)
         .AppendFormatLine("  ,'{0}'", importaObservGrales)
         .AppendFormatLine("  , {0} ", idPlanCuenta)
         .AppendFormatLine("  ,'{0}'", esAnticipo)
         .AppendFormatLine("  ,'{0}'", esRecibo)
         .AppendFormatLine("  ,'{0}'", grupo)
         .AppendFormatLine("  ,'{0}'", esPreElectronico)
         .AppendFormatLine("  ,'{0}'", generaContabilidad)
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(utilizaCtaSecundariaProd))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(utilizaCtaSecundariaCateg))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(incluirEnExpensas))

         .AppendFormatLine("  , {0} ", GetStringParaQueryConComillas(idTipoComprobanteNCred))
         .AppendFormatLine("  , {0} ", GetStringParaQueryConComillas(idTipoComprobanteNDeb))
         .AppendFormatLine("  , {0} ", GetStringParaQueryConComillas(idProductoNCred))
         .AppendFormatLine("  , {0} ", GetStringParaQueryConComillas(idProductoNDeb))

         .AppendFormatLine("  , {0} ", GetStringFromBoolean(consumePedidos))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(esPreFiscal))
         .AppendFormatLine("  ,'{0}'", codigoComprobanteSifere)
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(esDespachoImportacion))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(cargaDescRecActual))
         .AppendFormatLine("  , {0} ", GetStringParaQueryConComillas(idTipoComprobanteContraMovInvocar))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(alInvocarPedidoAfectaFactura))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(alInvocarPedidoAfectaRemito))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(invocarPedidosConEstadoEspecifico))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(invocaCompras))
         .AppendFormatLine("  , {0} ", GetStringFromNumber(largoMaximoNumero))
         .AppendFormatLine("  , {0} ", nivelAutorizacion)
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(requiereReferenciaCtaCte))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(controlaTopeConsumidorFinal))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(cargaDescRecGralActual))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(esReciboClienteVinculado))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(afipWSIncluyeFechaVencimiento))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(afipWSEsFEC))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(afipWSRequiereReferenciaComercial))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(afipWSRequiereComprobanteAsociado))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(afipWSRequiereCBU))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(afipWSCodigoAnulacion))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(afipWSRequiereReferenciaTransferencia))
         .AppendFormatLine("  , {0} ", orden)
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(marcaInvocado))
         .AppendFormatLine("  , {0} ", GetStringFromBoolean(permiteSeleccionarAlicuotaIVA))
         .AppendFormatLine("  ,'{0}'", descripcionImpresion)
         .AppendFormatLine("  , {0}", GetStringFromBoolean(ActivaTildeMercDespacha))
         .AppendFormatLine("  , {0}", GetStringFromBoolean(solicitaFechaDevolucion))
         .AppendFormatLine("  , {0}", GetStringFromNumber(color))
         '-- REQ-35059.- ----------------------------------------
         .AppendFormatLine("  ,'{0}'", codigoRoela.ToUpper())
         '-------------------------------------------------------
         .AppendFormatLine("  ,'{0}'", If(claseComprobante = Entidades.TipoComprobante.ClasesComprobante.SinDefinir, "", claseComprobante.ToString()))
         '-- REQ-40445.- ----------------------------------------
         .AppendFormatLine("  , {0}", GetStringFromBoolean(SolicitaInformeCalidad))
         '-------------------------------------------------------
         .AppendFormatLine(")")

      End With

      Execute(myQuery.ToString())
   End Sub

   Public Sub TiposComprobantes_U(idTipoComprobante As String,
                                  descripcion As String,
                                  esFiscal As Boolean,
                                  tipo As String,
                                  coeficienteStock As Integer,
                                  grabaLibro As Boolean,
                                  informaLibroIVA As Boolean,
                                  esFacturable As Boolean,
                                  letrasHabilitadas As String,
                                  cantidadMaximaItems As Integer,
                                  imprime As Boolean,
                                  coeficienteValores As Integer,
                                  modificaAlFacturar As String,
                                  esFacturador As Boolean,
                                  afectaCaja As Boolean,
                                  cargaPrecioActual As Boolean,
                                  actualizaCtaCte As Boolean,
                                  descripcionAbrev As String,
                                  puedeSerBorrado As Boolean,
                                  cantidadCopias As Integer,
                                  comprobantesAsociados As String,
                                  esRemitoTransportista As Boolean,
                                  esComercial As Boolean,
                                  cantidadMaximaItemsObserv As Integer,
                                  idTipoComprobanteSecundario As String,
                                  importeTope As Decimal,
                                  idTipoComprobanteEpson As String,
                                  usaFacturacionRapida As Boolean,
                                  importeMinimo As Decimal,
                                  esElectronico As Boolean,
                                  usaFacturacion As Boolean,
                                  utilizaImpuestos As Boolean,
                                  numeracionAutomatica As Boolean,
                                  generaObservConInvocados As Boolean,
                                  importaObservDeInvocados As Boolean,
                                  importaObservGrales As Boolean,
                                  idPlanCuenta As Integer,
                                  esAnticipo As Boolean,
                                  esRecibo As Boolean,
                                  grupo As String,
                                  esPreElectronico As Boolean,
                                  generaContabilidad As Boolean,
                                  utilizaCtaSecundariaProd As Boolean,
                                  utilizaCtaSecundariaCateg As Boolean,
                                  incluirEnExpensas As Boolean,
                                  idTipoComprobanteNCred As String,
                                  idTipoComprobanteNDeb As String,
                                  idProductoNCred As String,
                                  idProductoNDeb As String,
                                  consumePedidos As Boolean,
                                  esPreFiscal As Boolean,
                                  codigoComprobanteSifere As String,
                                  esDespachoImportacion As Boolean,
                                  cargaDescRecActual As Boolean,
                                  idTipoComprobanteContraMovInvocar As String,
                                  alInvocarPedidoAfectaFactura As Boolean,
                                  alInvocarPedidoAfectaRemito As Boolean,
                                  invocarPedidosConEstadoEspecifico As Boolean,
                                  invocaCompras As Boolean,
                                  largoMaximoNumero As Short,
                                  nivelAutorizacion As Short,
                                  requiereReferenciaCtaCte As Boolean,
                                  controlaTopeConsumidorFinal As Boolean,
                                  cargaDescRecGralActual As Boolean,
                                  esReciboClienteVinculado As Boolean,
                                  afipWSIncluyeFechaVencimiento As Boolean?,
                                  afipWSEsFEC As Boolean,
                                  afipWSRequiereReferenciaComercial As Boolean,
                                  afipWSRequiereComprobanteAsociado As Boolean,
                                  afipWSRequiereCBU As Boolean,
                                  afipWSCodigoAnulacion As Boolean,
                                  afipWSRequiereReferenciaTransferencia As Boolean,
                                  orden As Integer,
                                  marcaInvocado As Boolean,
                                  permiteSeleccionarAlicuotaIVA As Boolean,
                                  descripcionImpresion As String,
                                  activatildemercdespacha As Boolean,
                                  solicitaFechaDevolucion As Boolean,
                                  color As Integer?,
                                  codigoRoela As String,
                                  claseComprobante As Entidades.TipoComprobante.ClasesComprobante,
                                  SolicitaInformeCalidad As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE TiposComprobantes")
         .AppendFormatLine("   SET EsFiscal = '{0}'", esFiscal)
         .AppendFormatLine("      ,Descripcion = '{0}'", descripcion)
         .AppendFormatLine("      ,Tipo = '{0}'", tipo)
         .AppendFormatLine("      ,CoeficienteStock = {0}", coeficienteStock)
         .AppendFormatLine("      ,GrabaLibro = '{0}'", grabaLibro)
         .AppendFormatLine("      ,InformaLibroIVA = '{0}'", informaLibroIVA)
         .AppendFormatLine("      ,EsFacturable = '{0}'", esFacturable)
         .AppendFormatLine("      ,LetrasHabilitadas = {0}", GetStringParaQueryConComillas(letrasHabilitadas))

         .AppendFormatLine("      ,CantidadMaximaItems = {0}", cantidadMaximaItems)
         .AppendFormatLine("      ,Imprime = '{0}'", imprime)
         .AppendFormatLine("      ,CoeficienteValores = {0}", coeficienteValores)
         .AppendFormatLine("      ,ModificaAlFacturar = {0}", GetStringParaQueryConComillas(modificaAlFacturar))
         .AppendFormatLine("      ,EsFacturador = '{0}'", esFacturador)
         .AppendFormatLine("      ,AfectaCaja = '{0}'", afectaCaja)
         .AppendFormatLine("      ,CargaPrecioActual = '{0}'", cargaPrecioActual)
         .AppendFormatLine("      ,ActualizaCtaCte = '{0}'", actualizaCtaCte)
         .AppendFormatLine("      ,DescripcionAbrev = '{0}'", descripcionAbrev)
         .AppendFormatLine("      ,PuedeSerBorrado = '{0}'", puedeSerBorrado)
         .AppendFormatLine("      ,CantidadCopias = {0}", cantidadCopias)
         .AppendFormatLine("      ,ComprobantesAsociados = '{0}'", comprobantesAsociados)
         .AppendFormatLine("      ,EsRemitoTransportista = '{0}'", esRemitoTransportista)
         .AppendFormatLine("      ,EsComercial = '{0}'", esComercial)
         .AppendFormatLine("      ,CantidadMaximaItemsObserv = {0}", cantidadMaximaItemsObserv)
         .AppendFormatLine("      ,IdTipoComprobanteSecundario = {0}", GetStringParaQueryConComillas(idTipoComprobanteSecundario))
         .AppendFormatLine("      ,ImporteTope = {0}", importeTope)
         .AppendFormatLine("      ,IdTipoComprobanteEpson = '{0}'", idTipoComprobanteEpson)

         .AppendFormatLine("      ,UsaFacturacionRapida = '{0}'", usaFacturacionRapida)
         .AppendFormatLine("      ,ImporteMinimo = {0}", importeMinimo)
         .AppendFormatLine("      ,EsElectronico = '{0}'", esElectronico)
         .AppendFormatLine("      ,UsaFacturacion = '{0}'", usaFacturacion)
         .AppendFormatLine("      ,UtilizaImpuestos = '{0}'", utilizaImpuestos)
         .AppendFormatLine("      ,NumeracionAutomatica = '{0}'", numeracionAutomatica)
         .AppendFormatLine("      ,GeneraObservConInvocados = '{0}'", generaObservConInvocados)
         .AppendFormatLine("      ,ImportaObservDeInvocados = '{0}'", importaObservDeInvocados)
         .AppendFormatLine("      ,ImportaObservGrales = '{0}'", importaObservGrales)
         .AppendFormatLine("      ,IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("      ,EsAnticipo = '{0}'", esAnticipo)
         .AppendFormatLine("      ,EsRecibo = '{0}'", esRecibo)
         .AppendFormatLine("      ,Grupo = '{0}'", grupo)
         .AppendFormatLine("      ,EsPreElectronico = '{0}'", esPreElectronico)
         .AppendFormatLine("      ,GeneraContabilidad = '{0}'", generaContabilidad)
         .AppendFormatLine("      ,UtilizaCtaSecundariaProd = {0}", GetStringFromBoolean(utilizaCtaSecundariaProd))
         .AppendFormatLine("      ,UtilizaCtaSecundariaCateg = {0}", GetStringFromBoolean(utilizaCtaSecundariaCateg))
         .AppendFormatLine("      ,IncluirEnExpensas = {0}", GetStringFromBoolean(incluirEnExpensas))

         .AppendFormatLine("      ,IdTipoComprobanteNCred = {0}", GetStringParaQueryConComillas(idTipoComprobanteNCred))
         .AppendFormatLine("      ,IdTipoComprobanteNDeb = {0}", GetStringParaQueryConComillas(idTipoComprobanteNDeb))

         .AppendFormatLine("      ,IdProductoNCred = {0}", GetStringParaQueryConComillas(idProductoNCred))
         .AppendFormatLine("      ,IdProductoNDeb = {0}", GetStringParaQueryConComillas(idProductoNDeb))

         .AppendFormatLine("      ,ConsumePedidos = {0}", GetStringFromBoolean(consumePedidos))
         .AppendFormatLine("      ,EsPreFiscal = {0}", GetStringFromBoolean(esPreFiscal))
         .AppendFormatLine("      ,CodigoComprobanteSifere = '{0}'", codigoComprobanteSifere)
         .AppendFormatLine("      ,EsDespachoImportacion = {0}", GetStringFromBoolean(esDespachoImportacion))
         .AppendFormatLine("      ,CargaDescRecActual = {0}", GetStringFromBoolean(cargaDescRecActual))
         .AppendFormatLine("      ,IdTipoComprobanteContraMovInvocar = {0}", GetStringParaQueryConComillas(idTipoComprobanteContraMovInvocar))
         .AppendFormatLine("      ,AlInvocarPedidoAfectaFactura = {0}", GetStringFromBoolean(alInvocarPedidoAfectaFactura))
         .AppendFormatLine("      ,AlInvocarPedidoAfectaRemito = {0}", GetStringFromBoolean(alInvocarPedidoAfectaRemito))
         .AppendFormatLine("      ,InvocarPedidosConEstadoEspecifico = {0}", GetStringFromBoolean(invocarPedidosConEstadoEspecifico))
         .AppendFormatLine("      ,InvocaCompras = {0}", GetStringFromBoolean(invocaCompras))
         .AppendFormatLine("      ,LargoMaximoNumero = {0}", GetStringFromNumber(largoMaximoNumero))
         .AppendFormatLine("      ,NivelAutorizacion = {0}", nivelAutorizacion)
         .AppendFormatLine("      ,RequiereReferenciaCtaCte = {0}", GetStringFromBoolean(requiereReferenciaCtaCte))
         .AppendFormatLine("      ,ControlaTopeConsumidorFinal = {0}", GetStringFromBoolean(controlaTopeConsumidorFinal))
         .AppendFormatLine("      ,CargaDescRecGralActual = {0}", GetStringFromBoolean(cargaDescRecGralActual))
         .AppendFormatLine("      ,AFIPWSIncluyeFechaVencimiento = {0}", GetStringFromBoolean(afipWSIncluyeFechaVencimiento))
         .AppendFormatLine("      ,AFIPWSEsFEC = {0}", GetStringFromBoolean(afipWSEsFEC))
         .AppendFormatLine("      ,AFIPWSRequiereReferenciaComercial = {0}", GetStringFromBoolean(afipWSRequiereReferenciaComercial))
         .AppendFormatLine("      ,AFIPWSRequiereComprobanteAsociado = {0}", GetStringFromBoolean(afipWSRequiereComprobanteAsociado))
         .AppendFormatLine("      ,AFIPWSRequiereCBU = {0}", GetStringFromBoolean(afipWSRequiereCBU))
         .AppendFormatLine("      ,AFIPWSCodigoAnulacion = {0}", GetStringFromBoolean(afipWSCodigoAnulacion))
         .AppendFormatLine("      ,AFIPWSRequiereReferenciaTransferencia = {0}", GetStringFromBoolean(afipWSRequiereReferenciaTransferencia))
         .AppendFormatLine("      ,orden = {0}", orden)
         .AppendFormatLine("      ,MarcaInvocado = {0}", GetStringFromBoolean(marcaInvocado))
         .AppendFormatLine("      ,PermiteSeleccionarAlicuotaIVA = {0}", GetStringFromBoolean(permiteSeleccionarAlicuotaIVA))
         .AppendFormatLine("      ,DescripcionImpresion = '{0}'", descripcionImpresion)
         .AppendFormatLine("      ,{0} = {1}", Entidades.TipoComprobante.Columnas.ActivaTildeMercDespacha.ToString(), GetStringFromBoolean(activatildemercdespacha))
         .AppendFormatLine("      ,{0} = {1}", Entidades.TipoComprobante.Columnas.SolicitaFechaDevolucion.ToString(), GetStringFromBoolean(solicitaFechaDevolucion))
         .AppendFormatLine("      ,{0} = {1}", Entidades.TipoComprobante.Columnas.Color.ToString(), GetStringFromNumber(color))
         '-- REQ-35059.- -------------------------------------------------------------------------------------------------------
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.TipoComprobante.Columnas.CodigoRoela.ToString(), codigoRoela.ToUpper)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.TipoComprobante.Columnas.ClaseComprobante.ToString(), If(claseComprobante = Entidades.TipoComprobante.ClasesComprobante.SinDefinir, "", claseComprobante.ToString()))
         '-- REQ-40445.- -------------------------------------------------------------------------------------------------------
         .AppendFormatLine("      ,{0} = {1}", Entidades.TipoComprobante.Columnas.SolicitaInformeCalidad.ToString(), GetStringFromBoolean(SolicitaInformeCalidad))
         '----------------------------------------------------------------------------------------------------------------------

         .AppendFormatLine(" WHERE IdTipoComprobante = '{0}'", idTipoComprobante)
      End With

      Execute(myQuery.ToString())
   End Sub

   Public Function GetFacturables(comprobantesAsociados As String, miraPC As Boolean, tcs As List(Of Entidades.TipoComprobante)) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT IdTipoComprobante")
         .AppendFormatLine("     , Descripcion")
         .AppendFormatLine("     , AfectaCaja")
         .AppendFormatLine("     , GrabaLibro")
         .AppendFormatLine("     , CoeficienteStock")
         .AppendFormatLine("  FROM TiposComprobantes ")
         .AppendFormatLine(" WHERE EsFacturable = 'True'")
         If Not String.IsNullOrWhiteSpace(comprobantesAsociados) Then
            .AppendFormatLine("  AND IdTipoComprobante IN ({0})", comprobantesAsociados)
         End If
         'Los habilitados en esta PC.
         .AppendFormatLine("  AND IdTipoComprobante IN ({0})",
                           String.Join(",", tcs.ConvertAll(Function(tp) tp.IdTipoComprobante.RodearConComillasParaSql())))

         '.Append("  AND IdTipoComprobante IN (''")
         'For Each tc As Eniac.Entidades.TipoComprobante In tcs
         '   .Append(" , '" & tc.IdTipoComprobante & "'")
         'Next
         '.AppendLine(")")

         .AppendFormatLine(" ORDER BY Descripcion ")
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub TiposComprobantes_D(idTipoComprobante As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM TiposComprobantes  ")
         .AppendFormatLine(" WHERE IdTipoComprobante = '{0}'", idTipoComprobante)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function TiposComprobantes_GA() As DataTable
      Return TiposComprobantes_G(idTipoComprobante:=String.Empty, tipo1:=String.Empty, tipo2:=String.Empty, grupo:=String.Empty)
   End Function

   Public Function TiposComprobantes_G1(idTipoComprobante As String) As DataTable
      Return TiposComprobantes_G(idTipoComprobante, tipo1:=String.Empty, tipo2:=String.Empty, grupo:=String.Empty)
   End Function

   Public Function TiposComprobantes_G(idTipoComprobante As String, tipo1 As String, tipo2 As String, grupo As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(tipo1) Then
            .AppendFormat(" AND (TC.Tipo = '{0}' ", tipo1)
            If Not String.IsNullOrWhiteSpace(tipo2) Then
               .AppendFormat(" OR TC.Tipo = '{0}' ", tipo2)
            End If
            .AppendLine(")")
         End If
         If Not String.IsNullOrWhiteSpace(grupo) Then
            .AppendFormatLine("   AND Grupo = '{0}'", grupo)
         End If
         .AppendFormatLine("  ORDER BY TC.Tipo, TC.Descripcion")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetElectronicos(usaFacturacion As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE TC.EsElectronico = 'True' ")

         If usaFacturacion <> "TODOS" Then
            .AppendLine(" AND TC.UsaFacturacion = " & IIf(usaFacturacion = "SI", 1, 0).ToString())
         End If
         '.AppendLine(" AND TC.GrabaLibro = 1")

         .AppendLine(" ORDER BY TC.Descripcion")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorCodigoRoela(codigoRoela As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE TC.CodigoRoela = '{0}'", codigoRoela)
         .AppendLine(" ORDER BY TC.Descripcion")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT TC.*")
         .AppendFormatLine(",{0}", ConvertirBitSiNo("TC", "EsRecibo"))
         .AppendFormatLine(",{0}", ConvertirBitSiNo("TC", "GrabaLibro"))
         .AppendLine("  FROM TiposComprobantes TC ")

      End With

   End Sub

   Public Function GetPorCodigo(idTipoComprobante As String, descripcion As String, tipo1 As String, tipo2 As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND TC.IdTipoComprobante LIKE '%{0}%' ", idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat("   AND TC.Descripcion LIKE '%{0}%' ", descripcion)
         End If
         If Not String.IsNullOrWhiteSpace(tipo1) Then
            .AppendFormat(" AND (TC.Tipo = '{0}' ", tipo1)
            If Not String.IsNullOrWhiteSpace(tipo2) Then
               .AppendFormat(" OR TC.Tipo = '{0}' ", tipo2)
            End If
            .Append(")").AppendLine()
         End If
         .AppendLine(" ORDER BY TC.Descripcion")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetTipoComprobanteRecibo(importe As Decimal) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE TC.{0} = {1}", Entidades.TipoComprobante.Columnas.EsRecibo.ToString(), GetStringFromBoolean(True))
         .AppendFormatLine("   AND TC.{0} <= {2} AND TC.{1} >= {2}", Entidades.TipoComprobante.Columnas.ImporteMinimo.ToString(),
                                                                     Entidades.TipoComprobante.Columnas.ImporteTope.ToString(),
                                                                     importe)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetGrupos(idGrupo As String, nombreGrupo As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT DISTINCT Grupo As IdGrupo, Grupo As NombreGrupo")
         .Append(" FROM TiposComprobantes TC ")
         .Append(" WHERE Grupo <> 'null'")
         If Not String.IsNullOrWhiteSpace(idGrupo) Then
            .AppendFormat(" AND (TC.Grupo = '{0}' ", idGrupo)
         End If
         If Not String.IsNullOrWhiteSpace(nombreGrupo) Then
            .AppendFormat(" AND (TC.Grupo = '{0}' ", nombreGrupo)
         End If
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
End Class