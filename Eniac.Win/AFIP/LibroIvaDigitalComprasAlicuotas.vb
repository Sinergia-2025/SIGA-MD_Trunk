Imports System.Text
Imports System.IO

Public Class LibroIvaDigitalComprasAlicuotas

#Region "Propiedades"

   Private _lineas As List(Of LibroIvaDigitalComprasAlicuotasLinea)
   Public ReadOnly Property Lineas() As List(Of LibroIvaDigitalComprasAlicuotasLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of LibroIvaDigitalComprasAlicuotasLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As LibroIvaDigitalComprasAlicuotasLinea In Me.Lineas
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

         For Each linea As LibroIvaDigitalComprasAlicuotasLinea In Lineas
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

Public Class LibroIvaDigitalComprasAlicuotasLinea

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
         '01 - desde 001 hasta 003 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         .AppendFormat(Me.TipoDeComprobante.ToString("000"))
         '02 - desde 004 hasta 008 / Númerico / Tam = 5 / Observaciones = 
         .AppendFormat(Me.PuntoDeVenta.ToString("00000"))
         '03 - desde 009 hasta 028 / Númerico / Tam = 20 / Observaciones = 
         .AppendFormat(Me.NroDeComprobante.ToString(New String("0"c, 20)))

         '04 - desde 029 hasta 030 / Númerico / Tam = 2 / Observaciones =  Segun tabla Documentos
         .AppendFormat(Me.CodigoDeDocumentoIdentificatorioDelVendedor.ToString(New String("0"c, 2)))
         '05 - desde 031 hasta 050 / AlfaNúmerico / Tam = 20 / Observaciones =  
         .AppendFormat(Me.NroDeIdentificacionDelVendedor.ToString(New String("0"c, 20)))

         '06 - desde 051 hasta 065 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteNetoGravado.ToStringAFIP(15, 0))
         '07 - desde 066 hasta 069 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         .AppendFormat(Me.AlicuotaDeIVA.ToString(New String("0"c, 4)))
         '08 - desde 070 hasta 084 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImpuestoLiquidado.ToStringAFIP(15, 0))

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"
   Public Property Procesar As Boolean
   Public Property Linea As Integer
   Public Property TipoDeComprobante As Integer
   Public Property PuntoDeVenta As Integer
   Public Property NroDeComprobante As Decimal
   ''' <summary>
   ''' por defecto es el número 80 ya que en las tablas del AFIP es el CUIT.
   ''' </summary>
   ''' <remarks></remarks>
   Public Property CodigoDeDocumentoIdentificatorioDelVendedor As Integer = 80
   Public Property NroDeIdentificacionDelVendedor As Long

   Private _importeNetoGravado As Decimal
   Public Property ImporteNetoGravado() As Decimal
      Private Get
         Return _importeNetoGravado * 100 'System.Math.Abs(_importeNetoGravado * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeNetoGravado = value
      End Set
   End Property
   Public Property AlicuotaDeIVA As Integer

   Private _impuestoLiquidado As Decimal
   Public Property ImpuestoLiquidado() As Decimal
      Private Get
         Return _impuestoLiquidado * 100 'System.Math.Abs(_impuestoLiquidado * 100)
      End Get
      Set(ByVal value As Decimal)
         _impuestoLiquidado = value
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

      If Not Me.EstaBienElCodigoDeDocumento(_codigoDeDocumentoIdentificatorioDelVendedor) Then
         errores += "Para este Tipo de Comprobante el Código de Documento del comprador no puede ser distinto a CUIT (80). "
      End If
      If AlicuotaDeIVA < 0 Then
         errores += "La alicuota del comprobante no es válida"
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

