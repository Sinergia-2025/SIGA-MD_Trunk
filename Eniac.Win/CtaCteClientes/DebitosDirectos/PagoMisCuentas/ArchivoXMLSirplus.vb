Imports System.Text
Imports System.IO
Imports System.Globalization
Imports System.Xml
Imports System.Xml.Serialization
Imports Eniac.Entidades

Public Class ArchivoXMLSirplus


#Region "Metodos Publicos"

   Public Sub GenerarXMLSirplus(ByVal Datos As DataTable, ByVal nombreArchivo As String)
      Dim rNumerador As Reglas.Numeradores = New Reglas.Numeradores()

      Dim xmlDoc As New XmlDocument()
      Dim rootNode As XmlNode = xmlDoc.CreateElement("recepciones")
      xmlDoc.AppendChild(rootNode)

      Dim recepcionNode As XmlNode = xmlDoc.CreateElement("recepcion")
      rootNode.AppendChild(recepcionNode)
      Dim fechaSincronizacionNode As XmlNode = xmlDoc.CreateElement("fecha_sincronizacion")
      fechaSincronizacionNode.InnerText = Date.Now.ToString("yyyy-MM-dd")
      recepcionNode.AppendChild(fechaSincronizacionNode)

      Dim NumeroSincro As Entidades.Numerador = rNumerador.GetUno(Entidades.Numerador.TiposNumeradores.SIRPLUS.ToString())
      NumeroSincro.Numero += 1

      Dim idSincronizacionNode As XmlNode = xmlDoc.CreateElement("id_sincronizacion")
      idSincronizacionNode.InnerText = NumeroSincro.Numero.ToString()
      recepcionNode.AppendChild(idSincronizacionNode)

      Dim clienteNode As XmlNode = xmlDoc.CreateElement("Cliente")
      recepcionNode.AppendChild(clienteNode)
      Dim numeroNode As XmlNode = xmlDoc.CreateElement("numero")
      numeroNode.InnerText = Reglas.Publicos.TurismoSIRPLUSIdentifCuenta.ToString()
      clienteNode.AppendChild(numeroNode)
      Dim razonSocialNode As XmlNode = xmlDoc.CreateElement("razon_social")
      razonSocialNode.InnerText = Reglas.Publicos.TurismoSIRPLUSRazonSocial
      clienteNode.AppendChild(razonSocialNode)
      Dim cuitNode As XmlNode = xmlDoc.CreateElement("cuit")
      cuitNode.InnerText = Reglas.Publicos.CuitEmpresa.ToString()
      clienteNode.AppendChild(cuitNode)
      Dim passwordNode As XmlNode = xmlDoc.CreateElement("password")
      passwordNode.InnerText = Reglas.Publicos.TurismoSIRPLUSPassword
      clienteNode.AppendChild(passwordNode)

      Dim cuponesNode As XmlNode = xmlDoc.CreateElement("cupones")
      recepcionNode.AppendChild(cuponesNode)

      For Each dr As DataRow In Datos.Select("Selec = True")
         Dim cuponNode1 As XmlNode = xmlDoc.CreateElement("cupon")
         cuponesNode.AppendChild(cuponNode1)

         Dim fechaNode1 As XmlNode = xmlDoc.CreateElement("fecha")
         fechaNode1.InnerText = Date.Now.ToString("yyyy-MM-dd")
         cuponNode1.AppendChild(fechaNode1)
         Dim AnioNode1 As XmlNode = xmlDoc.CreateElement("anio")
         AnioNode1.InnerText = Date.Now.ToString("yyyy")
         cuponNode1.AppendChild(AnioNode1)
         Dim PeriodoNode1 As XmlNode = xmlDoc.CreateElement("periodo")
         PeriodoNode1.InnerText = Date.Now.ToString("MM")
         cuponNode1.AppendChild(PeriodoNode1)
         Dim numero_cuponNode1 As XmlNode = xmlDoc.CreateElement("numero_cupon")

         numero_cuponNode1.InnerText = dr("CodigoDeBarraSirplus").ToString().Substring(11, 12)

         cuponNode1.AppendChild(numero_cuponNode1)
         Dim numero_clienteNode1 As XmlNode = xmlDoc.CreateElement("numero_cliente")
         numero_clienteNode1.InnerText = dr("CodigoCliente").ToString()
         cuponNode1.AppendChild(numero_clienteNode1)
         Dim razon_social_clienteNode1 As XmlNode = xmlDoc.CreateElement("razon_social_cliente")
         razon_social_clienteNode1.InnerText = dr("NombreCliente").ToString()
         cuponNode1.AppendChild(razon_social_clienteNode1)
         Dim mailNode1 As XmlNode = xmlDoc.CreateElement("mail")
         mailNode1.InnerText = dr("CorreoElectronico").ToString()
         cuponNode1.AppendChild(mailNode1)
         Dim numero_cuentaNode1 As XmlNode = xmlDoc.CreateElement("numero_cuenta")
         cuponNode1.AppendChild(numero_cuentaNode1)
         Dim cbuNode1 As XmlNode = xmlDoc.CreateElement("cbu")
         cuponNode1.AppendChild(cbuNode1)
         Dim titular_cuentaNode1 As XmlNode = xmlDoc.CreateElement("titular_cuenta")
         cuponNode1.AppendChild(titular_cuentaNode1)
         Dim numero_cuenta_empresaNode1 As XmlNode = xmlDoc.CreateElement("numero_cuenta_empresa")
         numero_cuenta_empresaNode1.InnerText = Reglas.Publicos.TurismoSIRPLUSNroCuentaEmpresa.ToString()
         cuponNode1.AppendChild(numero_cuenta_empresaNode1)
         Dim cbu_empresaNode1 As XmlNode = xmlDoc.CreateElement("cbu_empresa")
         cbu_empresaNode1.InnerText = Reglas.Publicos.TurismoSIRPLUSCBU.ToString()
         cuponNode1.AppendChild(cbu_empresaNode1)
         Dim titular_cuenta_empresaNode1 As XmlNode = xmlDoc.CreateElement("titular_cuenta_empresa")
         titular_cuenta_empresaNode1.InnerText = Reglas.Publicos.TurismoSIRPLUSCBUEmpresa.ToString()
         cuponNode1.AppendChild(titular_cuenta_empresaNode1)
         Dim TotalNode1 As XmlNode = xmlDoc.CreateElement("total")
         TotalNode1.InnerText = dr("ImporteCuota").ToString()
         cuponNode1.AppendChild(TotalNode1)
         Dim id_moneda_sirplusNode1 As XmlNode = xmlDoc.CreateElement("id_moneda_sirplus")
         id_moneda_sirplusNode1.InnerText = "1"
         cuponNode1.AppendChild(id_moneda_sirplusNode1)
         Dim valor_pesosNode1 As XmlNode = xmlDoc.CreateElement("valor_pesos")
         valor_pesosNode1.InnerText = dr("ImporteCuota").ToString()
         cuponNode1.AppendChild(valor_pesosNode1)
         Dim codigo_barrasNode1 As XmlNode = xmlDoc.CreateElement("codigo_barras")
         codigo_barrasNode1.InnerText = dr("CodigoDeBarraSirplus").ToString()
         cuponNode1.AppendChild(codigo_barrasNode1)

         Dim vencimientos1 As XmlNode = xmlDoc.CreateElement("vencimientos")
         cuponNode1.AppendChild(vencimientos1)
         Dim fecha_vencimientovencimientos1 As XmlNode = xmlDoc.CreateElement("fecha_vencimiento")
         fecha_vencimientovencimientos1.InnerText = Date.Parse(dr("FechaVencimiento").ToString()).ToString("yyyy-MM-dd")
         vencimientos1.AppendChild(fecha_vencimientovencimientos1)
         Dim importevencimientos1 As XmlNode = xmlDoc.CreateElement("importe")
         importevencimientos1.InnerText = dr("ImporteCuota").ToString()
         vencimientos1.AppendChild(importevencimientos1)
         Dim id_moneda_vencimiento_sirplusvencimientos1 As XmlNode = xmlDoc.CreateElement("id_moneda_vencimiento_sirplus")
         id_moneda_vencimiento_sirplusvencimientos1.InnerText = "1"
         vencimientos1.AppendChild(id_moneda_vencimiento_sirplusvencimientos1)
         Dim valor_pesos_vencimientovencimientos1 As XmlNode = xmlDoc.CreateElement("valor_pesos_vencimiento")
         valor_pesos_vencimientovencimientos1.InnerText = dr("ImporteCuota").ToString()
         vencimientos1.AppendChild(valor_pesos_vencimientovencimientos1)

         Dim vencimientos2 As XmlNode = xmlDoc.CreateElement("vencimientos")
         cuponNode1.AppendChild(vencimientos2)
         Dim fecha_vencimientovencimientos2 As XmlNode = xmlDoc.CreateElement("fecha_vencimiento")
         fecha_vencimientovencimientos2.InnerText = Date.Parse(dr("FechaVencimiento2").ToString()).ToString("yyyy-MM-dd")
         vencimientos2.AppendChild(fecha_vencimientovencimientos2)
         Dim importevencimientos2 As XmlNode = xmlDoc.CreateElement("importe")
         importevencimientos2.InnerText = dr("ImporteVencimiento2").ToString()
         vencimientos2.AppendChild(importevencimientos2)
         Dim id_moneda_vencimiento_sirplusvencimientos2 As XmlNode = xmlDoc.CreateElement("id_moneda_vencimiento_sirplus")
         id_moneda_vencimiento_sirplusvencimientos2.InnerText = "1"
         vencimientos2.AppendChild(id_moneda_vencimiento_sirplusvencimientos2)
         Dim valor_pesos_vencimientovencimientos2 As XmlNode = xmlDoc.CreateElement("valor_pesos_vencimiento")
         valor_pesos_vencimientovencimientos2.InnerText = dr("ImporteVencimiento2").ToString()
         vencimientos2.AppendChild(valor_pesos_vencimientovencimientos2)

         Dim vencimientos3 As XmlNode = xmlDoc.CreateElement("vencimientos")
         cuponNode1.AppendChild(vencimientos3)
         Dim fecha_vencimientovencimientos3 As XmlNode = xmlDoc.CreateElement("fecha_vencimiento")
         fecha_vencimientovencimientos3.InnerText = Date.Parse(dr("FechaVencimiento3").ToString()).ToString("yyyy-MM-dd")
         vencimientos3.AppendChild(fecha_vencimientovencimientos3)
         Dim importevencimientos3 As XmlNode = xmlDoc.CreateElement("importe")
         importevencimientos3.InnerText = dr("ImporteVencimiento3").ToString()
         vencimientos3.AppendChild(importevencimientos3)
         Dim id_moneda_vencimiento_sirplusvencimientos3 As XmlNode = xmlDoc.CreateElement("id_moneda_vencimiento_sirplus")
         id_moneda_vencimiento_sirplusvencimientos3.InnerText = "1"
         vencimientos3.AppendChild(id_moneda_vencimiento_sirplusvencimientos3)
         Dim valor_pesos_vencimientovencimientos3 As XmlNode = xmlDoc.CreateElement("valor_pesos_vencimiento")
         valor_pesos_vencimientovencimientos3.InnerText = dr("ImporteVencimiento3").ToString()
         vencimientos3.AppendChild(valor_pesos_vencimientovencimientos3)

         Dim entidades As XmlNode = xmlDoc.CreateElement("entidades")
         cuponNode1.AppendChild(entidades)

         Dim entidad As XmlNode = xmlDoc.CreateElement("entidad")
         entidades.AppendChild(entidad)
         Dim id_entidad As XmlNode = xmlDoc.CreateElement("id_entidad")
         id_entidad.InnerText = "1"
         entidad.AppendChild(id_entidad)

         Dim entidad1 As XmlNode = xmlDoc.CreateElement("entidad")
         entidades.AppendChild(entidad1)
         Dim id_entidad1 As XmlNode = xmlDoc.CreateElement("id_entidad")
         id_entidad1.InnerText = "2"
         entidad1.AppendChild(id_entidad1)

         Dim entidad2 As XmlNode = xmlDoc.CreateElement("entidad")
         entidades.AppendChild(entidad2)
         Dim id_entidad2 As XmlNode = xmlDoc.CreateElement("id_entidad")
         id_entidad2.InnerText = "4"
         entidad2.AppendChild(id_entidad2)

         Dim entidad3 As XmlNode = xmlDoc.CreateElement("entidad")
         entidades.AppendChild(entidad3)
         Dim id_entidad3 As XmlNode = xmlDoc.CreateElement("id_entidad")
         id_entidad3.InnerText = "5"
         entidad3.AppendChild(id_entidad3)
      Next

      xmlDoc.Save(nombreArchivo)
      rNumerador.Actualizar(NumeroSincro)
   End Sub

#End Region
End Class

Public Class ArchivoXMLSirplusRecepcion

   <XmlRoot("liquidaciones")>
   Public Class Liquidaciones
      <XmlElement("liquidacion")> Public Property Liquidacion As Liquidacion
   End Class

   Public Class Liquidacion
      <XmlElement("id_liquidacion")> Public Property IdLiquidacion As String
      <XmlElement("numero_liquidacion")> Public Property NumeroLiquidacion As String
      <XmlElement("id_cliente")> Public Property IdCliente As String
      <XmlElement("fecha")> Public Property Fecha As String
      <XmlElement("total_cupones")> Public Property TotalCupones As String
      <XmlElement("total_comision")> Public Property TotalComision As String
      <XmlElement("total_conceptos")> Public Property TotalConceptos As String
      <XmlElement("total_liquidado")> Public Property TotalLiquidado As String
      <XmlElement("estado")> Public Property Estado As String
      <XmlElement("cupones")> Public Property Cupones As Cupones
      <XmlElement("conceptos")> Public Property Conceptos As Conceptos
   End Class

   Public Class Cupones
      <XmlElement("cupon")> Public Property Cupon As List(Of Cupon)
   End Class

   Public Class Cupon
      <XmlElement("id_cupon")> Public Property IdCupon As String
      <XmlElement("numero_cupon")> Public Property NumeroCupon As String
      <XmlElement("codigo_barras")> Public Property CodigoBarras As String
      <XmlElement("fecha_cupon")> Public Property FechaCupon As String
      <XmlElement("id_moneda")> Public Property IdMoneda As String
      <XmlElement("importe_cobrado")> Public Property ImporteCobrado As String
      <XmlElement("valor_pesos_cobrado")> Public Property ValorPesosCobrado As String
      <XmlElement("id_entidad")> Public Property IdEntidad As String
      <XmlElement("importe_comision")> Public Property ImporteComision As String
      <XmlElement("fecha_cobro")> Public Property FechaCobro As String
   End Class

   Public Class Conceptos
      <XmlElement("concepto")> Public Property Concepto As Concepto()
   End Class

   Public Class Concepto
      <XmlElement("id_concepto")> Public Property IdConcepto As String
      <XmlElement("id_moneda_concepto")> Public Property IdMonedaConcepto As String
      <XmlElement("descripcion_concepto")> Public Property DescripcionConcepto As String
      <XmlElement("importe_concepto")> Public Property ImporteConcepto As String
      <XmlElement("valor_pesos_concepto")> Public Property ValorPesosConcepto As String
   End Class



End Class
