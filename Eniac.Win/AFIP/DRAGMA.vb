Public Class DRAGMA
#Region "Metodos Privados"


#End Region

#Region "Propiedades"

   Private _lineas As List(Of DRAGMALinea)
   Public ReadOnly Property Lineas() As List(Of DRAGMALinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of DRAGMALinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As DRAGMALinea In Me.Lineas
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

         For Each linea As DRAGMALinea In Lineas
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
Public Class DRAGMALinea
#Region "Campos"
   Private _stb As StringBuilder
#End Region

#Region "Constructores"
   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub
#End Region

#Region "Propiedades"
   Public Property Procesar() As Boolean
   Public Property Linea() As Integer

   Public Property TipoRetencionPercepcion() As String
   Public Property CuitContribuyenteRetencion() As Long
   Public Property AplicacionDeRetencion() As Integer
   Public Property NroSecuenciaComprobante() As Integer
   Public Property FechaEmisionDelComprobante() As DateTime
   Public Property CodigoImpuestoRetencion() As Integer
   Public Property TipoComprobanteRetencion() As String
   Public Property NroDeComprobanteRetencion() As String
   Public Property LetraComprobanteRetencion() As String
   Public Property AlicuotaDelComprobante() As Decimal
   Public Property MontoDelComprobante() As Decimal
   Public Property MontoRetenidoComprobante() As Decimal


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

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      Dim separador = ";"
      With _stb
         .Length = 0
         'Indica si es comprobante de Retención o Percepción / R-P
         .AppendFormat(TipoRetencionPercepcion.ToString())
         .Append(separador)
         .AppendFormat(CuitContribuyenteRetencion.ToString())
         .Append(separador)
         .AppendFormat(AplicacionDeRetencion.ToString())
         .Append(separador)
         .AppendFormat(NroSecuenciaComprobante.ToString())
         .Append(separador)
         .AppendFormat(FechaEmisionDelComprobante.ToString("dd/MM/yyyy"))
         .Append(separador)
         .AppendFormat(CodigoImpuestoRetencion.ToString())
         .Append(separador)
         .AppendFormat(TipoComprobanteRetencion.ToString())
         .Append(separador)
         .AppendFormat(NroDeComprobanteRetencion.ToString())
         .Append(separador)
         .AppendFormat(LetraComprobanteRetencion.ToString())
         .Append(separador)
         .AppendFormat(Decimal.Parse(AlicuotaDelComprobante.ToString()).ToString("0.##"))
         .Append(separador)
         .AppendFormat(Decimal.Parse(MontoDelComprobante.ToString()).ToString("0.##"))
         .Append(separador)
         .AppendFormat(Decimal.Parse(MontoRetenidoComprobante.ToString()).ToString("0.##"))
      End With
      Return Replace(Me._stb.ToString(), ",", ".")
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub SeteaErrores()
      Dim errores As String = String.Empty
      _tieneError = (Not String.IsNullOrEmpty(errores))
      _tipoError = errores
   End Sub

#End Region
End Class
