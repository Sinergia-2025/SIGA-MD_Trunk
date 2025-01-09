Public Class SICORE

#Region "Metodos Privados"


#End Region

#Region "Propiedades"

   Private _lineas As List(Of SICORELinea)
   Public ReadOnly Property Lineas() As List(Of SICORELinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of SICORELinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As SICORELinea In Me.Lineas
            If li.Procesar Then
               cant += 1
            End If
         Next
         Return cant
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Reglas.Publicos.VerificaConfiguracionRegional(",")

      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         For Each linea As SICORELinea In Lineas
            If linea.Procesar Then
               stb.Append(linea.GetLinea()).AppendLine()
            End If
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      Finally
         Reglas.Publicos.VerificaConfiguracionRegional()
      End Try
   End Sub

#End Region

End Class

Public Class SICORELinea

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb
         .Length = 0
         'Código de comprobante / Entero / Desde 1 Hasta 2 / Longitud 2
         .AppendFormat(Me.CodigoDeComprobante.ToString("00"))
         'Fecha de emisión del comprobante (DD/MM/YYYY) / Fecha / Desde 3 Hasta 12 / Longitud 10
         .AppendFormat(Me.FechaEmisionDelComprobante.ToString("dd/MM/yyyy"))
         'Número del comprobante / Texto / Desde 13 Hasta 28 / Longitud 16
         .AppendFormat(Me.NroDeComprobante)
         'Importe del comprobante / Decimal / Desde 29 Hasta 44 / Longitud 16
         .AppendFormat(Me.ImporteDelComprobante.ToString("0000000000000.00"))
         'Código de impuesto / Entero / Desde 45 Hasta 47 / Longitud 4
         .AppendFormat(Me.CodigoDeImpuesto.ToString("0000"))
         'Código de régimen / Entero / Desde 49 Hasta 51 / Longitud 3
         .AppendFormat(Me.CodigoDeRegimen.ToString("000"))
         'Código de operación / Entero / Desde 52 Hasta 52 / Longitud 1
         .AppendFormat(Me.CodigoDeOperacion.ToString("0"))
         'Base de cálculo / Decimal / Desde 53 Hasta 66 / Longitud 14
         If CodigoDeComprobante = 3 Then  ' PE-40031 - El monto en el campo de Base calculo es incorrecto en las notas de credito.
            .AppendFormat(Me.ImporteDeLaRetencion.ToString("00000000000.00"))
         Else
            .AppendFormat(Me.BaseDeCalculo.ToString("00000000000.00"))
         End If
         'Fecha de emisión de la retención (DD/MM/YYYY) / Fecha / Desde 67 Hasta 76 / Longitud 10
         .AppendFormat(Me.FechaEmisionRetencion.ToString("dd/MM/yyyy"))
         'Código de condición / Entero / Desde 77 Hasta 78 / Longitud 2
         .AppendFormat(Me.CodigoDeCondicion.ToString("00"))
         'Retención practicada a sujetos suspendidos según: / Entero / Desde 79 Hasta 79 / Longitud 1
         .AppendFormat(Me.RetencionPracticadaASuspendidos.ToString("0"))
         'Importe de la retención / Decimal / Desde 80 Hasta 93 / Longitud 14
         .AppendFormat(Me.ImporteDeLaRetencion.ToString("00000000000.00"))
         'Porcentaje de exclusión / Decimal / Desde 94 Hasta 99 / Longitud 6
         .AppendFormat(Me.PorcentajeDeExclusion.ToString("000.00"))
         'Fecha de emisión del boletín / Fecha / Desde 100 Hasta 109 / Longitud 10
         If FechaEmisionDelBoletin.HasValue Then
            .AppendFormat(FechaEmisionDelBoletin.Value.ToString("dd/MM/yyyy"))
         Else
            .AppendFormat("          ")
         End If
         'Tipo de documento del retenido / Entero / Desde 110 Hasta 111 / Longitud 2
         .AppendFormat(Me.TipoDocumentoDelRetenido.ToString("00"))
         'Número de documento del retenido / Texto / Desde 112 Hasta 131 / Longitud 20
         .AppendFormat(Me.NumeroDocumentoDelRetenido)
         'Número certificado original / Entero / Desde 132 Hasta 145 / Longitud 14
         .AppendFormat(Me.NumeroCertificadoOriginal.ToString(New String("0"c, 14)))
         'Denominación del ordenante / Texto / Desde 146 Hasta 175 / Longitud 30
         '.AppendFormat(Me.DenominacionDelOrdenante)
         ''Acrecentamiento / Entero / Desde 176 Hasta 176 / Longitud 1
         'If Acrecentamiento > 0 Then
         '   .AppendFormat(Acrecentamiento.ToString("0"))
         'Else
         '   .AppendFormat(" ")
         'End If
         ''Cuit del país del retenido / Texto / Desde 177 Hasta 187 / Longitud 11
         '.AppendFormat(Me.CuitDelPaisDelRetenido)
         ''Cuit del ordenante / Texto / Desde 188 Hasta 198 / Longitud 11
         '.AppendFormat(Me.CuitDelOrdenante)

         ''estos son datos para el certificado del exterior -----------------------------------------
         If EsCertificadoDelExterior Then
         
         End If

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Private _procesar As Boolean = False
   Public Property Procesar() As Boolean
      Get
         Return _procesar
      End Get
      Set(ByVal value As Boolean)
         _procesar = value
      End Set
   End Property

   Private _linea As Integer = 0
   Public Property Linea() As Integer
      Get
         Return _linea
      End Get
      Set(ByVal value As Integer)
         _linea = value
      End Set
   End Property

   Private _codigoDeComprobante As Integer
   ''' <summary>
   ''' Código de comprobante
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks>00</remarks>
   Public Property CodigoDeComprobante() As Integer
      Get
         Return _codigoDeComprobante
      End Get
      Set(ByVal value As Integer)
         _codigoDeComprobante = value
      End Set
   End Property

   Private _fechaEmisionDelComprobante As DateTime
   ''' <summary>
   ''' Fecha de emisión del comprobante (DD/MM/YYYY)
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaEmisionDelComprobante() As DateTime
      Private Get
         Return _fechaEmisionDelComprobante
      End Get
      Set(ByVal value As DateTime)
         _fechaEmisionDelComprobante = value
      End Set
   End Property

   Private _nroDeComprobante As String
   ''' <summary>
   ''' Número del comprobante
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroDeComprobante() As String
      Private Get
         Return _nroDeComprobante.PadRight(16)
      End Get
      Set(ByVal value As String)
         If value.Length > 16 Then
            value = value.Substring(0, 16)
         End If
         _nroDeComprobante = value
      End Set
   End Property

   Private _tipoDeComprobante As Integer
   Public Property TipoDeComprobante() As Integer
      Private Get
         Return _tipoDeComprobante
      End Get
      Set(ByVal value As Integer)
         _tipoDeComprobante = value
      End Set
   End Property

   Private _importeDelComprobante As Decimal
   Public Property ImporteDelComprobante() As Decimal
      Get
         Return System.Math.Abs(_importeDelComprobante)
      End Get
      Set(ByVal value As Decimal)
         _importeDelComprobante = value
      End Set
   End Property

   Private _codigoDeImpuesto As Integer
   Public Property CodigoDeImpuesto() As Integer
      Get
         Return _codigoDeImpuesto
      End Get
      Set(ByVal value As Integer)
         _codigoDeImpuesto = value
      End Set
   End Property

   Private _codigoDeRegimen As Integer
   Public Property CodigoDeRegimen() As Integer
      Get
         Return _codigoDeRegimen
      End Get
      Set(ByVal value As Integer)
         _codigoDeRegimen = value
      End Set
   End Property

   Private _codigoDeOperacion As Integer
   Public Property CodigoDeOperacion() As Integer
      Private Get
         Return _codigoDeOperacion
      End Get
      Set(ByVal value As Integer)
         _codigoDeOperacion = value
      End Set
   End Property

   Private _baseDeCalculo As Decimal
   Public Property BaseDeCalculo() As Decimal
      Get
         Return System.Math.Abs(_baseDeCalculo)
      End Get
      Set(ByVal value As Decimal)
         _baseDeCalculo = value
      End Set
   End Property

   Private _fechaEmisionRetencion As DateTime
   Public Property FechaEmisionRetencion() As DateTime
      Get
         Return _fechaEmisionRetencion
      End Get
      Set(ByVal value As DateTime)
         _fechaEmisionRetencion = value
      End Set
   End Property

   Private _codigoDeCondicion As Integer
   Public Property CodigoDeCondicion() As Integer
      Get
         Return _codigoDeCondicion
      End Get
      Set(ByVal value As Integer)
         _codigoDeCondicion = value
      End Set
   End Property

   Private _retencionPracticadaASuspendidos As Integer
   Public Property RetencionPracticadaASuspendidos() As Integer
      Get
         Return _retencionPracticadaASuspendidos
      End Get
      Set(ByVal value As Integer)
         _retencionPracticadaASuspendidos = value
      End Set
   End Property

   Private _importeDeLaRetencion As Decimal
   Public Property ImporteDeLaRetencion() As Decimal
      Get
         Return System.Math.Abs(_importeDeLaRetencion)
      End Get
      Set(ByVal value As Decimal)
         _importeDeLaRetencion = value
      End Set
   End Property

   Private _porcentajeDeExclusion As Decimal
   Public Property PorcentajeDeExclusion() As Decimal
      Get
         Return System.Math.Abs(_porcentajeDeExclusion)
      End Get
      Set(ByVal value As Decimal)
         _porcentajeDeExclusion = value
      End Set
   End Property

   Private _fechaEmisionDelBoletin As DateTime?
   Public Property FechaEmisionDelBoletin() As DateTime?
      Get
         Return _fechaEmisionDelBoletin
      End Get
      Set(ByVal value As DateTime?)
         _fechaEmisionDelBoletin = value
      End Set
   End Property

   Private _tipoDocumentoDelRetenido As Integer
   Public Property TipoDocumentoDelRetenido() As Integer
      Get
         Return _tipoDocumentoDelRetenido
      End Get
      Set(ByVal value As Integer)
         _tipoDocumentoDelRetenido = value
      End Set
   End Property

   Private _numeroDocumentoDelRetenido As String
   Public Property NumeroDocumentoDelRetenido() As String
      Get
         Return _numeroDocumentoDelRetenido.PadRight(20)
      End Get
      Set(ByVal value As String)
         If value.Length > 20 Then
            value = value.Substring(0, 20)
         End If
         _numeroDocumentoDelRetenido = value
      End Set
   End Property

   Private _esCertificadoDelExterior As Boolean = False
   Public Property EsCertificadoDelExterior() As Boolean
      Get
         Return _esCertificadoDelExterior
      End Get
      Set(ByVal value As Boolean)
         _esCertificadoDelExterior = value
      End Set
   End Property


   Private _numeroCertificadoOriginal As Long
   Public Property NumeroCertificadoOriginal() As Long
      Get
         Return _numeroCertificadoOriginal
      End Get
      Set(ByVal value As Long)
         _numeroCertificadoOriginal = value
      End Set
   End Property

   Private _denominacionDelOrdenante As String = String.Empty
   Public Property DenominacionDelOrdenante() As String
      Get
         Return _denominacionDelOrdenante.PadRight(30)
      End Get
      Set(ByVal value As String)
         If value.Length > 30 Then
            _denominacionDelOrdenante = value.Substring(0, 30)
         Else
            _denominacionDelOrdenante = value
         End If
      End Set
   End Property

   Private _acrecentamiento As Integer
   Public Property Acrecentamiento() As Integer
      Get
         Return _acrecentamiento
      End Get
      Set(ByVal value As Integer)
         _acrecentamiento = value
      End Set
   End Property

   Private _cuitDelPaisDelRetenido As String = String.Empty
   Public Property CuitDelPaisDelRetenido() As String
      Get
         Return _cuitDelPaisDelRetenido.PadRight(11)
      End Get
      Set(ByVal value As String)
         _cuitDelPaisDelRetenido = value
      End Set
   End Property

   Private _cuitDelOrdenante As String = String.Empty
   Public Property CuitDelOrdenante() As String
      Get
         Return _cuitDelOrdenante.PadRight(11)
      End Get
      Set(ByVal value As String)
         _cuitDelOrdenante = value
      End Set
   End Property

   Private _tieneError As Boolean = False
   Public ReadOnly Property TieneError() As Boolean
      Get
         Me.SeteaErrores()
         Return _tieneError
      End Get
   End Property

   Private _tipoError As String = String.Empty
   Public ReadOnly Property TipoError() As String
      Get
         SeteaErrores()
         Return _tipoError
      End Get
   End Property

#End Region

#Region "Metodos Privados"

   Private Sub SeteaErrores()
      Dim errores As String = String.Empty
      'If Not Me.EstaBienElCodigoDeDocumento(_codigoDeDocumentoIdentificatorioDelComprador) Then
      '   errores += "Para este Tipo de Comprobante el Código de Documento del comprador no puede ser distinto a CUIT (80). "
      'End If
      'If Me._alicuotaDeIVA <> 0 And Me._impuestoLiquidado = 0 Then
      '   errores += "El campo ImpuestoLiquidado no puede ser cero si la alicuota es distinta de cero. "
      'End If

      _tieneError = (Not String.IsNullOrEmpty(errores))
      _tipoError = errores
   End Sub

   'Private Function EstaBienElCodigoDeComprobante(ByVal codigoDeComprobante As Integer) As Boolean
   '   If codigoDeDocumento = 80 Then
   '      Return True
   '   Else 'si el codigo del documento es distinto a 80 (CUIT) entonces tengo que verificar el tipo de comprobante
   '      If Me._tipoDeComprobante = 6 Or _
   '            Me._tipoDeComprobante = 7 Or _
   '            Me._tipoDeComprobante = 8 Or _
   '            Me._tipoDeComprobante = 9 Or _
   '            Me._tipoDeComprobante = 10 Or _
   '            Me._tipoDeComprobante = 35 Or _
   '            Me._tipoDeComprobante = 40 Or _
   '            Me._tipoDeComprobante = 61 Or _
   '            Me._tipoDeComprobante = 62 Or _
   '            Me._tipoDeComprobante = 82 Then
   '         Return True
   '      Else
   '         Return False
   '      End If
   '   End If
   'End Function

   Private Function EsUnTipoDeComprobanteM() As Boolean
      If _tipoDeComprobante = 51 Or
         _tipoDeComprobante = 52 Or
         _tipoDeComprobante = 53 Or
         _tipoDeComprobante = 54 Or
         _tipoDeComprobante = 55 Or
         _tipoDeComprobante = 58 Or
         _tipoDeComprobante = 59 Then
         Return True
      Else
         Return False
      End If
   End Function

#End Region

End Class

