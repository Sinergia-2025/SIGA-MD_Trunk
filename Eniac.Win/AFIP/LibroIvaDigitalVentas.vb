Imports System.Text
Imports System.IO

Public Class LibroIvaDigitalVentas

#Region "Propiedades"

   Private _lineas As List(Of LibroIvaDigitalVentasLinea)
   Public ReadOnly Property Lineas() As List(Of LibroIvaDigitalVentasLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of LibroIvaDigitalVentasLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As LibroIvaDigitalVentasLinea In Me.Lineas
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
      Dim stb As StringBuilder
      Try

         stb = New StringBuilder()

         For Each linea As LibroIvaDigitalVentasLinea In Lineas
            If linea.Procesar Then
               stb.Append(linea.GetLinea()).AppendLine()
            End If
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class LibroIvaDigitalVentasLinea

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
         '01 - desde 001 hasta 008 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         .AppendFormat(Me.FechaDelComprobante.ToString("yyyyMMdd"))
         '02 - desde 009 hasta 011 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         .AppendFormat(Me.TipoDeComprobante.ToString("000"))
         '03 - desde 012 hasta 016 / Númerico / Tam = 5 / Observaciones = 
         .AppendFormat(Me.PuntoDeVenta.ToString("00000"))
         '04 - desde 017 hasta 036 / Númerico / Tam = 20 / Observaciones = 
         .AppendFormat(Me.NroDeComprobante.ToString(New String("0"c, 20)))
         '05 - desde 037 hasta 056 / Númerico / Tam = 20 / Observaciones = 
         .AppendFormat(Me.NroDeComprobanteHasta.ToString(New String("0"c, 20)))
         '06 - desde 057 hasta 058 / Númerico / Tam = 2 / Observaciones = Según tabla de documentos
         .AppendFormat(Me.CodigoDeDocumentoIdentificatorioDelComprador.ToString(New String("0"c, 2)))
         '07 - desde 059 hasta 078 / AlfaNúmerico / Tam = 20 / Observaciones = 
         .AppendFormat(Me.NroDeIdentificacionDelComprador.ToString(New String("0"c, 20)))
         '08 - desde 079 hasta 108 / AlfaNúmerico / Tam = 30 / Observaciones = 
         .AppendFormat(Me.ApellidoYNombreODenominacionDelComprador)
         '09 - desde 109 hasta 123 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteTotalDeLaOperacion.ToString(New String("0"c, 15)))
         '10 - desde 124 hasta 138 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.TotalDeConceptosQueNoIntegranElPrecioNeto.ToString(New String("0"c, 15)))
         '11 - desde 139 hasta 153 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImpuestoLiquidadoARNIOPercANoCategoriz.ToString(New String("0"c, 15)))
         '12 - desde 154 hasta 168 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDeOperacionesExentas.ToString(New String("0"c, 15)))
         '13 - desde 169 hasta 183 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDePercepOPagosACtaDeImpuestoNac.ToString(New String("0"c, 15)))
         '14 - desde 184 hasta 198 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDePercepcionesDeIngresosBrutos.ToString(New String("0"c, 15)))
         '15 - desde 199 hasta 213 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDePercepcionesDeImpuestosMunicipales.ToString(New String("0"c, 15)))
         '16 - desde 214 hasta 228 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDeImpuestosInternos.ToString(New String("0"c, 15)))
         '17 - desde 229 hasta 231 / Alfabetico / Tam = 3 / Observaciones =  Según tabla Monedas
         .AppendFormat(Me.CodigoDeMoneda)
         '18 - desde 232 hasta 241 / Númerico / Tam = 10 / Observaciones =  4 enteros 6 decimales sin punto decimal
         .AppendFormat(Me.TipoDeCambio.ToString(New String("0"c, 10)))
         '19 - desde 242 hasta 242 / Númerico / Tam = 1 / Observaciones = 
         .AppendFormat(Me.CantidadDeAlicuotasDeIVA.ToString(New String("0"c, 1)))
         '20 - desde 243 hasta 243 / Alfabetico / Tam = 1 / Observaciones =   Según tabla Codigo_Operación, de No Corresponder v
         .AppendFormat(Me.CodigoDeOperacion)
         '21 - desde 244 hasta 258 / Númerico / Tam = 15 / Observaciones = 
         .AppendFormat(Me.OtrosTributos.ToString(New String("0"c, 15)))
         '22 - desde 259 hasta 266 / Númerico / Tam = 8 / Observaciones =  Fto: AAAAMMDD
         '# Estos comprobantes que obvian la fecha de vencimiento, pertenecen a COMPROBANTES DEL APARTADO A INCISO F)  R.G. N°  1415
         If Me.FechaDeVencimiento = Nothing OrElse (TipoDeComprobante >= 34 AndAlso TipoDeComprobante <= 41) OrElse (TipoDeComprobante > 55 AndAlso TipoDeComprobante < 58) Then
            .AppendFormat("00000000")
         Else
            .AppendFormat(Me.FechaDeVencimiento.ToString("yyyyMMdd"))
         End If

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Public Property Procesar As Boolean
   Public Property Linea As Integer
   Public Property FechaDelComprobante As DateTime
   Public Property TipoDeComprobante As Integer
   Public Property PuntoDeVenta As Integer
   Public Property NroDeComprobante As Decimal
   Public Property NroDeComprobanteHasta As Decimal
   
   ''' <summary>
   ''' por defecto es el número 80 ya que en las tablas del AFIP es el CUIT.
   ''' </summary>
   ''' <remarks></remarks>
   Public Property CodigoDeDocumentoIdentificatorioDelComprador As Integer = 80

   Public Property NroDeIdentificacionDelComprador() As Long

   Private _apellidoYNombreODenominacionDelComprador As String
   Public Property ApellidoYNombreODenominacionDelComprador() As String
      Private Get
         If Me._apellidoYNombreODenominacionDelComprador.Length < 30 Then
            Me._apellidoYNombreODenominacionDelComprador = Me._apellidoYNombreODenominacionDelComprador.PadRight(30) 'agrego vacios
         End If
         Return _apellidoYNombreODenominacionDelComprador
      End Get
      Set(ByVal value As String)
         If value.Length > 30 Then
            _apellidoYNombreODenominacionDelComprador = value.Substring(0, 30)
         Else
            _apellidoYNombreODenominacionDelComprador = value
         End If
      End Set
   End Property

   Private _importeTotalDeLaOperacion As Decimal
   Public Property ImporteTotalDeLaOperacion() As Decimal
      Private Get
         Return System.Math.Abs(_importeTotalDeLaOperacion * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeTotalDeLaOperacion = value
      End Set
   End Property

   Private _totalDeConceptosQueNoIntegranElPrecioNeto As Decimal
   Public Property TotalDeConceptosQueNoIntegranElPrecioNeto() As Decimal
      Private Get
         Return System.Math.Abs(_totalDeConceptosQueNoIntegranElPrecioNeto * 100)
      End Get
      Set(ByVal value As Decimal)
         _totalDeConceptosQueNoIntegranElPrecioNeto = value
      End Set
   End Property

   Private _impuestoLiquidadoARNIOPercANoCategoriz As Decimal
   Public Property ImpuestoLiquidadoARNIOPercANoCategoriz() As Decimal
      Private Get
         Return System.Math.Abs(_impuestoLiquidadoARNIOPercANoCategoriz * 100)
      End Get
      Set(ByVal value As Decimal)
         _impuestoLiquidadoARNIOPercANoCategoriz = value
      End Set
   End Property

   Private _importeDeOperacionesExentas As Decimal = 0
   Public Property ImporteDeOperacionesExentas() As Decimal
      Get
         Return System.Math.Abs(_importeDeOperacionesExentas * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeDeOperacionesExentas = value
      End Set
   End Property

   Private _importeDePercepOPagosACtaDeImpuestoNac As Decimal
   Public Property ImporteDePercepOPagosACtaDeImpuestoNac() As Decimal
      Private Get
         Return System.Math.Abs(_importeDePercepOPagosACtaDeImpuestoNac * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeDePercepOPagosACtaDeImpuestoNac = value
      End Set
   End Property

   Private _importeDePercepcionesDeIngresosBrutos As Decimal
   Public Property ImporteDePercepcionesDeIngresosBrutos() As Decimal
      Private Get
         Return System.Math.Abs(_importeDePercepcionesDeIngresosBrutos * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeDePercepcionesDeIngresosBrutos = value
      End Set
   End Property

   Private _importeDePercepcionesDeImpuestosMunicipales As Decimal
   Public Property ImporteDePercepcionesDeImpuestosMunicipales() As Decimal
      Private Get
         Return System.Math.Abs(_importeDePercepcionesDeImpuestosMunicipales * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeDePercepcionesDeImpuestosMunicipales = value
      End Set
   End Property

   Private _importeDeImpuestosInternos As Decimal
   Public Property ImporteDeImpuestosInternos() As Decimal
      Private Get
         Return System.Math.Abs(_importeDeImpuestosInternos * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeDeImpuestosInternos = value
      End Set
   End Property

   Private _codigoDeMoneda As String
   Public Property CodigoDeMoneda() As String
      Private Get
         If Me._codigoDeMoneda.Length < 30 Then
            Me._codigoDeMoneda = Me._codigoDeMoneda.PadRight(3) 'agrego vacios
         End If
         Return _codigoDeMoneda
      End Get
      Set(ByVal value As String)
         If value.Length > 3 Then
            Throw New Exception("El campo CodigoDeMoneda no puede ser mayor a 3 caracteres.")
         End If
         _codigoDeMoneda = value
      End Set
   End Property

   Private _tipoDeCambio As Decimal
   Public Property TipoDeCambio() As Decimal
      Private Get
         Return System.Math.Abs(_tipoDeCambio * 1000000)
      End Get
      Set(ByVal value As Decimal)
         _tipoDeCambio = value
      End Set
   End Property
   Public Property CantidadDeAlicuotasDeIVA() As Integer

   Private _codigoDeOperacion As String
   Public Property CodigoDeOperacion() As String
      Private Get
         If Me._codigoDeOperacion.Length < 1 Then
            Me._codigoDeOperacion = Me._codigoDeOperacion.PadRight(1) 'agrego vacios
         End If
         Return _codigoDeOperacion
      End Get
      Set(ByVal value As String)
         If value.Length > 1 Then
            Throw New Exception("El campo CodigoDeOperacion no puede ser mayor a 1 caracteres.")
         End If
         _codigoDeOperacion = value
      End Set
   End Property

   Private _otrosTributos As Decimal
   Public Property OtrosTributos() As Decimal
      Private Get
         Return System.Math.Abs(_otrosTributos * 100)
      End Get
      Set(ByVal value As Decimal)
         _otrosTributos = value
      End Set
   End Property

   Public Property FechaDeVencimiento() As DateTime

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
         Me.SeteaErrores()
         Return _tipoError
      End Get
   End Property

#End Region

#Region "Metodos Privados"

   Private Function AgregaError(stb As StringBuilder, mensaje As String) As StringBuilder
      stb.AppendLine(mensaje)
      _tieneError = True
      Return stb
   End Function

   Private Sub SeteaErrores()
      Dim errores As StringBuilder = New StringBuilder()
      _tieneError = False

      If _tipoDeComprobante = 0 Then
         AgregaError(errores, "Falta configurar el tipo de comprobante en tablas de AFIP")
      End If

      If Not Me.EstaBienElCodigoDeDocumento(_codigoDeDocumentoIdentificatorioDelComprador) Then
         AgregaError(errores, "Para este Tipo de Comprobante el Código de Documento del comprador no puede ser distinto a CUIT (80). ")
      End If

      Me._tipoError = errores.ToString()
   End Sub

   Private _tiposComprobantesPermitenDiferente80 As Integer() = {6, 7, 8, 9, 10, 35, 40, 61, 62, 82, 83, 113, 116, 206, 207, 208}

   Private Function EstaBienElCodigoDeDocumento(ByVal codigoDeDocumento As Integer) As Boolean
      If codigoDeDocumento = 80 Then
         Return True
      Else
         If codigoDeDocumento = 0 Then
            Return False
         Else
            'si el codigo del documento es distinto a 80 (CUIT) entonces tengo que verificar el tipo de comprobante
            Return _tiposComprobantesPermitenDiferente80.Contains(Me._tipoDeComprobante)
            'If Me._tipoDeComprobante = 6 Or
            '   Me._tipoDeComprobante = 7 Or
            '   Me._tipoDeComprobante = 8 Or
            '   Me._tipoDeComprobante = 9 Or
            '   Me._tipoDeComprobante = 10 Or
            '   Me._tipoDeComprobante = 35 Or
            '   Me._tipoDeComprobante = 40 Or
            '   Me._tipoDeComprobante = 61 Or
            '   Me._tipoDeComprobante = 62 Or
            '   Me._tipoDeComprobante = 82 Or
            '   Me._tipoDeComprobante = 83 Then
            '   Return True
            'Else
            '   Return False
            'End If
         End If
      End If
   End Function

   Private Function EsUnTipoDeComprobanteM() As Boolean
      If Me._tipoDeComprobante = 51 Or _
            Me._tipoDeComprobante = 52 Or _
            Me._tipoDeComprobante = 53 Or _
            Me._tipoDeComprobante = 54 Or _
            Me._tipoDeComprobante = 55 Or _
            Me._tipoDeComprobante = 58 Or _
            Me._tipoDeComprobante = 59 Then
         Return True
      Else
         Return False
      End If
   End Function

#End Region

End Class
