Imports System.Text
Imports System.IO

Public Class LibroIvaDigitalVentasComprobantesAnulados

#Region "Propiedades"

   Private _lineas As List(Of LibroIvaDigitalVentasComprobantesAnuladosLinea)
   Public ReadOnly Property Lineas() As List(Of LibroIvaDigitalVentasComprobantesAnuladosLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of LibroIvaDigitalVentasComprobantesAnuladosLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As LibroIvaDigitalVentasComprobantesAnuladosLinea In Me.Lineas
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

         For Each linea As LibroIvaDigitalVentasComprobantesAnuladosLinea In Lineas
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

Public Class LibroIvaDigitalVentasComprobantesAnuladosLinea

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
         '05 - desde 037 hasta 044 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         .AppendFormat(Me.FechaDeAnulacion.ToString("yyyyMMdd"))
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

   Public Property FechaDeAnulacion As DateTime

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


