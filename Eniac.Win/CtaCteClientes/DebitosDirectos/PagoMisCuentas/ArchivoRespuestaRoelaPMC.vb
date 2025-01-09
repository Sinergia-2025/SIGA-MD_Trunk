Public Class ArchivoRespuestaRoelaPMC

#Region "Propiedades"

   Public Property FecharArchivo() As Date

   Private _datos As List(Of ArchivoRespuestaRoelaPMCDatos)
   Public Property Datos() As List(Of ArchivoRespuestaRoelaPMCDatos)
      Get
         If _datos Is Nothing Then
            _datos = New List(Of ArchivoRespuestaRoelaPMCDatos)()
         End If
         Return _datos
      End Get
      Set(value As List(Of ArchivoRespuestaRoelaPMCDatos))
         _datos = value
      End Set
   End Property


   Public ReadOnly Property TotalImporte As Decimal
      Get
         Dim tot As Decimal = 0
         For Each ar As ArchivoRespuestaRoelaPMCDatos In Datos
            tot += ar.ImportePagado
         Next
         Return tot
      End Get
   End Property

#End Region

   Public Function GetInfo(archivoFisico As IO.StreamReader) As ArchivoRespuestaRoelaPMC

      Dim linea As String
      Dim arDa = New ArchivoRespuestaRoelaPMC()

      linea = archivoFisico.ReadLine()

      Do While linea IsNot Nothing
         Me.Datos.Add(New ArchivoRespuestaRoelaPMCDatos().GetDato(linea))
         linea = archivoFisico.ReadLine()
      Loop

      Return Me
   End Function

End Class

Public Class ArchivoRespuestaRoelaPMCDatos

#Region "Propiedades"
   Public Property Proceso As Boolean = True
   Public Property Accion As String = String.Empty
   Public Property FechaDePago As Date
   Public Property FechaDeAcreditacion As Date
   Public Property FechaDeVencimiento As Date
   Public Property ImportePagado As Decimal
   Public Property IdentificadorDelUsuario As Long
   Public Property IdentificadorDeConcepto As Long
   Public Property CodigoDeBarra As String
   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property Cuota As Integer
   Public Property SaldoCuota As Decimal
   Public Property IdentificadorDeComprobante As String
   Public Property CanalDeCobro As String
   Public Property NombreCliente As String
   Public Property Mensaje As String = String.Empty

#End Region

#Region "Metodos Publicos"

   Public Function GetDato(linea As String) As ArchivoRespuestaRoelaPMCDatos
      Dim dato = New ArchivoRespuestaRoelaPMCDatos()
      Dim oCliente As Entidades.Cliente
      '-- Variables de Accion y mensaje.- --
      Dim Accion As String = "A"
      Dim Mensaje = New StringBuilder()
      '-------------------------------------
      With dato

         'Fecha en la que el cliente efectuó el pago.
         dato.FechaDePago = New DateTime(Integer.Parse(linea.Substring(0, 4)), Integer.Parse(linea.Substring(4, 2)), Integer.Parse(linea.Substring(6, 2)))
         'Fecha de acreditación del pago en cuenta corriente de Banco Roela.
         dato.FechaDeAcreditacion = New DateTime(Integer.Parse(linea.Substring(8, 4)), Integer.Parse(linea.Substring(12, 2)), Integer.Parse(linea.Substring(14, 2)))
         'Surge del Primer Vencimiento del código de barra. 
         dato.FechaDeVencimiento = New DateTime(Integer.Parse(linea.Substring(16, 4)), Integer.Parse(linea.Substring(20, 2)), Integer.Parse(linea.Substring(22, 2)))
         'Importe pagado: Ej: Si el monto fue de $1.490,80, se informa 0149080
         dato.ImportePagado = Decimal.Parse(linea.Substring(24, 7)) / 100
         'Surge del Identificador de Usuario del código de barra. Este dato le permite identificar a quien imputar el
         'pago. En caso de las cobranzas de Link Pagos y Pago Mis Cuentas, surge de tomar las posiciones 2º a 9º del
         'Identificador de Usuario ó Nro de Referencia del archivo subido a Link Pagos y Pago Mis Cuentas. 
         dato.IdentificadorDelUsuario = Long.Parse(linea.Substring(31, 8))
         oCliente = New Reglas.Clientes().GetUnoPorCodigo(Long.Parse(dato.IdentificadorDelUsuario.ToString()))
         If oCliente IsNot Nothing Then
            dato.NombreCliente = oCliente.NombreCliente
         Else
            Accion = "X"
            Mensaje.AppendFormat("Identificador de Cliente inválido - ")
         End If

         'Surge del Identificador de Concepto
         'del código de barra. En caso de las cobranzas de Link Pagos y Pago Mis Cuentas, surge de tomar la 1º posición del Identificador
         'de Usuario ó Nro de Referencia del archivo subido a Link Pagos y Pago Mis Cuentas.
         dato.IdentificadorDeConcepto = Long.Parse(linea.Substring(39, 1))

         '-- Obtienen el Codigo de Barra.- ----------
         dato.CodigoDeBarra = linea.Substring(40, 56)
         '-- En base al Codigo de Barra busca la Ficha en CuentasCorrientesPagos.- --------------------
         Dim dtComprobante = New Reglas.CuentasCorrientesPagos().GetPorCodigoBarra(dato.CodigoDeBarra)
         If dtComprobante IsNot Nothing AndAlso dtComprobante.Rows.Count > 0 Then
            '-- Si lo localiza carga los datos.- --------------------------------
            For Each dr As DataRow In dtComprobante.Rows
               dato.IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
               dato.Letra = dr.Field(Of String)("Letra")
               dato.CentroEmisor = dr.Field(Of Integer)("CentroEmisor")
               dato.NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
               dato.Cuota = dr.Field(Of Integer)("CuotaNumero")
               dato.SaldoCuota = dr.Field(Of Decimal)("SaldoCuota")
               If dato.ImportePagado > dr.Field(Of Decimal)("SaldoCuota") Then
                  Accion = "D"
                  Mensaje.Insert(0, "(ND) Saldo Insuficiente de Cuota se ingresará una Nota de Débito - ")
                  'Mensaje.AppendFormat("Saldo Insuficiente para cancelacion de Cuota - ")
               End If
            Next
         Else
            Accion = "X"
            Mensaje.AppendFormat("Codigo de Barra Inexistente - ")
         End If
         'PF(Pago Fácil); RP (Rapipago); PP (provincia Pagos); CJ (cajeros); LK(Link Pagos); PC(Pago Mis Cuentas). 
         dato.CanalDeCobro = linea.Substring(116, 3)

         '-- Carga Mensajes.- --
         dato.Proceso = Accion = "A" Or Accion = "D"
         dato.Accion = Accion
         dato.Mensaje = Mensaje.ToString()
         '----------------------
      End With

      Return dato
   End Function

#End Region

End Class