﻿Imports System.Text
Imports System.IO

Public Class CitiCompras

#Region "Propiedades"

   Private _lineas As List(Of CitiComprasLinea)
   Public ReadOnly Property Lineas() As List(Of CitiComprasLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of CitiComprasLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As CitiComprasLinea In Me.Lineas
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
      Dim Cont As Integer = 0

      Try
         stb = New StringBuilder()

         For Each linea As CitiComprasLinea In Lineas
            Cont += 1
            If linea.Procesar Then
               stb.Append(linea.GetLinea()).AppendLine()
            End If
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw New Exception("Problema en Linea: " & Cont.ToString() & " - " & ex.Message)
      End Try
   End Sub

#End Region

End Class

Public Class CitiComprasLinea

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
         '05 - desde 037 hasta 052 / AlfaNúmerico / Tam = 16 / Observaciones = 
         .AppendFormat(Me.NroDespachoDeImportacion)
         '06 - desde 053 hasta 054 / Númerico / Tam = 2 / Observaciones = Según tabla de documentos
         .AppendFormat(Me.CodigoDeDocumentoIdentificatorioDelComprador.ToString(New String("0"c, 2)))
         '07 - desde 055 hasta 074 / AlfaNúmerico / Tam = 20 / Observaciones = 
         .AppendFormat(Me.NroDeIdentificacionDelComprador.ToString(New String("0"c, 20)))
         '08 - desde 075 hasta 104 / AlfaNúmerico / Tam = 30 / Observaciones = 
         .AppendFormat(Me.ApellidoYNombreODenominacionDelComprador)
         '09 - desde 105 hasta 119 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteTotalDeLaOperacion.ToString(New String("0"c, 15)))
         '10 - desde 120 hasta 134 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.TotalDeConceptosQueNoIntegranElPrecioNeto.ToString(New String("0"c, 15)))
         '11 - desde 135 hasta 149 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDeOperacionesExentas.ToString(New String("0"c, 15)))
         '12 - desde 150 hasta 164 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDePercepcionesOPagosACtaDelIVA.ToString(New String("0"c, 15)))
         '13 - desde 165 hasta 179 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDePercepOPagosACtaDeImpuestoNac.ToString(New String("0"c, 15)))
         '14 - desde 180 hasta 194 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDePercepcionesDeIngresosBrutos.ToString(New String("0"c, 15)))
         '15 - desde 195 hasta 209 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDePercepcionesDeImpuestosMunicipales.ToString(New String("0"c, 15)))
         '16 - desde 210 hasta 224 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteDeImpuestosInternos.ToString(New String("0"c, 15)))
         '17 - desde 225 hasta 227 / Alfabetico / Tam = 3 / Observaciones =  Según tabla Monedas
         .AppendFormat(Me.CodigoDeMoneda)
         '18 - desde 228 hasta 237 / Númerico / Tam = 10 / Observaciones =  4 enteros 6 decimales sin punto decimal
         .AppendFormat(Me.TipoDeCambio.ToString(New String("0"c, 10)))
         '19 - desde 238 hasta 238 / Númerico / Tam = 1 / Observaciones = 
         .AppendFormat(Me.CantidadDeAlicuotasDeIVA.ToString(New String("0"c, 1)))
         '20 - desde 239 hasta 239 / Alfabetico / Tam = 1 / Observaciones =   Según tabla Codigo_Operación, de No Corresponder v
         .AppendFormat(Me.CodigoDeOperacion)
         '21 - desde 240 hasta 254 / Númerico / Tam = 15 / Observaciones = 
         .AppendFormat(Me.CreditoFiscalComputable.ToString(New String("0"c, 15)))
         '22 - desde 255 hasta 269 / Númerico / Tam = 15 / Observaciones = 
         .AppendFormat(Me.OtrosTributos.ToString(New String("0"c, 15)))
         '23 - desde 270 hasta 280 / Númerico / Tam = 11 / Observaciones =  
         .AppendFormat(Me.CuitEmisor.ToString(New String("0"c, 11)))
         '24 - desde 281 hasta 310 / AlfaNúmerico / Tam = 30 / Observaciones =  
         .AppendFormat(Me.DenominacionDelEmisorCorredor)
         '25 - desde 311 hasta 325 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.IvaComision.ToString(New String("0"c, 15)))

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

   Private _fechaDelComprobante As DateTime
   Public Property FechaDelComprobante() As DateTime
      Private Get
         Return _fechaDelComprobante
      End Get
      Set(ByVal value As DateTime)
         _fechaDelComprobante = value
      End Set
   End Property

   Private _tipoDeComprobante As Integer
   Public Property TipoDeComprobante() As Integer
      Get
         Return _tipoDeComprobante
      End Get
      Set(ByVal value As Integer)
         _tipoDeComprobante = value
      End Set
   End Property

   Private _puntoDeVenta As Integer
   Public Property PuntoDeVenta() As Integer
      Private Get
         Return _puntoDeVenta
      End Get
      Set(ByVal value As Integer)
         _puntoDeVenta = value
      End Set
   End Property

   Private _nroDeComprobante As Decimal
   Public Property NroDeComprobante() As Decimal
      Private Get
         Return _nroDeComprobante
      End Get
      Set(ByVal value As Decimal)
         _nroDeComprobante = value
      End Set
   End Property

   Private _nroDespachoDeImportacion As String
   Public Property NroDespachoDeImportacion() As String
      Private Get
         If Me._nroDespachoDeImportacion.Length < 16 Then
            Me._nroDespachoDeImportacion = Me._nroDespachoDeImportacion.PadRight(16) 'agrego vacios
         End If
         Return _nroDespachoDeImportacion
      End Get
      Set(ByVal value As String)
         If value.Length > 16 Then
            _nroDespachoDeImportacion = value.Substring(0, 16)
         Else
            _nroDespachoDeImportacion = value
         End If
      End Set
   End Property

   ''' <summary>
   ''' por defecto es el número 80 ya que en las tablas del AFIP es el CUIT.
   ''' </summary>
   ''' <remarks></remarks>
   Private _codigoDeDocumentoIdentificatorioDelComprador As Integer = 80
   Public Property CodigoDeDocumentoIdentificatorioDelComprador() As Integer
      Private Get
         Return _codigoDeDocumentoIdentificatorioDelComprador
      End Get
      Set(ByVal value As Integer)
         _codigoDeDocumentoIdentificatorioDelComprador = value
      End Set
   End Property

   Private _nroDeIdentificacionDelComprador As Long
   Public Property NroDeIdentificacionDelComprador() As Long
      Private Get
         Return _nroDeIdentificacionDelComprador
      End Get
      Set(ByVal value As Long)
         _nroDeIdentificacionDelComprador = value
      End Set
   End Property

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

   Private _totalDeConceptosQueNoIntegranElPrecioNeto As Long
   Public Property TotalDeConceptosQueNoIntegranElPrecioNeto() As Long
      Private Get
         Return _totalDeConceptosQueNoIntegranElPrecioNeto
      End Get
      Set(ByVal value As Long)
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

   Private _importeDeOperacionesExentas As Decimal
   Public Property ImporteDeOperacionesExentas() As Decimal
      Get
         Return System.Math.Abs(_importeDeOperacionesExentas * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeDeOperacionesExentas = value
      End Set
   End Property

   Private _importeDePercepcionesOPagosACtaDelIVA As Decimal
   Public Property ImporteDePercepcionesOPagosACtaDelIVA() As Decimal
      Private Get
         Return System.Math.Abs(_importeDePercepcionesOPagosACtaDelIVA * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeDePercepcionesOPagosACtaDelIVA = value
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

   Private _cantidadDeAlicuotasDeIVA As Integer
   Public Property CantidadDeAlicuotasDeIVA() As Integer
      Private Get
         Return _cantidadDeAlicuotasDeIVA
      End Get
      Set(ByVal value As Integer)
         _cantidadDeAlicuotasDeIVA = value
      End Set
   End Property

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

   Private _creditoFiscalComputable As Decimal
   Public Property CreditoFiscalComputable() As Decimal
      Private Get
         Return System.Math.Abs(_creditoFiscalComputable * 100)
      End Get
      Set(ByVal value As Decimal)
         _creditoFiscalComputable = value
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

   Private _CUITEmisor As Long
   Public Property CuitEmisor() As Long
      Private Get
         Return _CUITEmisor
      End Get
      Set(ByVal value As Long)
         _CUITEmisor = value
      End Set
   End Property

   Private _denominacionDelEmisorCorredor As String
   Public Property DenominacionDelEmisorCorredor() As String
      Private Get
         If Me._denominacionDelEmisorCorredor.Length < 30 Then
            Me._denominacionDelEmisorCorredor = Me._denominacionDelEmisorCorredor.PadRight(30) 'agrego vacios
         End If
         Return _denominacionDelEmisorCorredor
      End Get
      Set(ByVal value As String)
         If value.Length > 30 Then
            _denominacionDelEmisorCorredor = value.Substring(0, 30)
         Else
            _denominacionDelEmisorCorredor = value
         End If
      End Set
   End Property

   Private _ivaComision As Decimal
   Public Property IvaComision() As Decimal
      Private Get
         Return System.Math.Abs(_ivaComision * 100)
      End Get
      Set(ByVal value As Decimal)
         _ivaComision = value
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
         Me.SeteaErrores()
         Return _tipoError
      End Get
   End Property



#End Region

#Region "Metodos Privados"

   Private Sub SeteaErrores()
      Dim errores As String = String.Empty

      If Not Me.EstaBienElCodigoDeDocumento(_codigoDeDocumentoIdentificatorioDelComprador) Then
         errores += "Para este Tipo de Comprobante el Código de Documento del comprador no puede ser distinto a CUIT (80). "
      End If

      Me._tieneError = (Not String.IsNullOrEmpty(errores))
      Me._tipoError = errores
   End Sub

   Private Function EstaBienElCodigoDeDocumento(ByVal codigoDeDocumento As Integer) As Boolean
      If codigoDeDocumento = 80 Then
         Return True
      Else
         If codigoDeDocumento = 0 Then
            Return False
         Else
            'si el codigo del documento es distinto a 80 (CUIT) entonces tengo que verificar el tipo de comprobante
            If Me._tipoDeComprobante = 6 Or _
                  Me._tipoDeComprobante = 7 Or _
                  Me._tipoDeComprobante = 8 Or _
                  Me._tipoDeComprobante = 9 Or _
                  Me._tipoDeComprobante = 10 Or _
                  Me._tipoDeComprobante = 35 Or _
                  Me._tipoDeComprobante = 40 Or _
                  Me._tipoDeComprobante = 61 Or _
                  Me._tipoDeComprobante = 62 Or _
                  Me._tipoDeComprobante = 82 Then
               Return True
            Else
               Return False
            End If
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
