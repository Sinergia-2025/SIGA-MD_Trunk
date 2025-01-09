<Serializable()> _
Public Class TipoComprobanteLetra
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoComprobante
      Letra
      ArchivoAImprimir
      ArchivoAImprimirEmbebido
      NombreImpresora
      CantidadItemsProductos
      CantidadItemsObservaciones
      Imprime
      CantidadCopias
      ArchivoAImprimir2
      ArchivoAImprimirEmbebido2
      ArchivoAImprimirComplementario
      ArchivoAImprimirComplementarioEmbebido
      ArchivoAExportar
      ArchivoAExportarEmbebido
      IdTipoImpresionFiscalArchivoAImprimir
      IdTipoImpresionFiscalArchivoAImprimir2
      IdTipoImpresionFiscalArchivoAImprimirComplementario
      IdTipoImpresionFiscalArchivoAExportar
      DesplazamientoXArchivoAImprimir
      DesplazamientoYArchivoAImprimir
      DesplazamientoXArchivoAImprimir2
      DesplazamientoYArchivoAImprimir2
      DesplazamientoXArchivoAImprimirComplementario
      DesplazamientoYArchivoAImprimirComplementario
      DesplazamientoXArchivoAExportar
      DesplazamientoYArchivoAExportar
   End Enum

   Private _tipoComprobante As Entidades.TipoComprobante
   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         If Me._tipoComprobante Is Nothing Then
            Me._tipoComprobante = New Entidades.TipoComprobante()
         End If
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property

   Private _letra As String
   Public Property Letra() As String
      Get
         Return _letra
      End Get
      Set(ByVal value As String)
         _letra = value
      End Set
   End Property

   Private _archivoAImprimir As String = String.Empty
   Public Property ArchivoAImprimir() As String
      Get
         Return _archivoAImprimir
      End Get
      Set(ByVal value As String)
         _archivoAImprimir = value
      End Set
   End Property

   Private _archivoAImprimirEmbebido As Boolean = False
   Public Property ArchivoAImprimirEmbebido() As Boolean
      Get
         Return _archivoAImprimirEmbebido
      End Get
      Set(ByVal value As Boolean)
         _archivoAImprimirEmbebido = value
      End Set
   End Property

   Private _nombreImpresora As String
   Public Property NombreImpresora() As String
      Get
         Return _nombreImpresora
      End Get
      Set(ByVal value As String)
         _nombreImpresora = value
      End Set
   End Property

   Private _cantidadItemsProductos As Integer
   Public Property CantidadItemsProductos() As Integer
      Get
         Return _cantidadItemsProductos
      End Get
      Set(ByVal value As Integer)
         _cantidadItemsProductos = value
      End Set
   End Property

   Private _cantidadItemsObservaciones As Integer
   Public Property CantidadItemsObservaciones() As Integer
      Get
         Return _cantidadItemsObservaciones
      End Get
      Set(ByVal value As Integer)
         _cantidadItemsObservaciones = value
      End Set
   End Property

   Private _cantidadCopias As Integer
   Public Property CantidadCopias() As Integer
      Get
         Return _cantidadCopias
      End Get
      Set(ByVal value As Integer)
         _cantidadCopias = value
      End Set
   End Property

   Private _imprime As Boolean
   Public Property Imprime() As Boolean
      Get
         Return Me._imprime
      End Get
      Set(ByVal value As Boolean)
         Me._imprime = value
      End Set
   End Property

   Public ReadOnly Property NombreComprobante() As String
      Get
         Return Me._tipoComprobante.Descripcion
      End Get
   End Property

   Public Property ArchivoAImprimir2 As String
   Public Property ArchivoAImprimirEmbebido2 As Boolean

   Public Property ArchivoAImprimirComplementario As String
   Public Property ArchivoAImprimirComplementarioEmbebido As Boolean

   Public Property ArchivoAExportar As String
   Public Property ArchivoAExportarEmbebido As Boolean

   Public Property IdTipoImpresionFiscalArchivoAImprimir As Integer
   Public Property IdTipoImpresionFiscalArchivoAImprimir2 As Integer
   Public Property IdTipoImpresionFiscalArchivoAImprimirComplementario As Integer
   Public Property IdTipoImpresionFiscalArchivoAExportar As Integer
   Public Property NombreTipoImpresionFiscalArchivoAImprimir As String
   Public Property NombreTipoImpresionFiscalArchivoAImprimir2 As String
   Public Property NombreTipoImpresionFiscalArchivoAImprimirComplementario As String
   Public Property NombreTipoImpresionFiscalArchivoAExportar As String
   Public Property DesplazamientoXArchivoAImprimir As Integer
   Public Property DesplazamientoYArchivoAImprimir As Integer
   Public Property DesplazamientoXArchivoAImprimir2 As Integer
   Public Property DesplazamientoYArchivoAImprimir2 As Integer
   Public Property DesplazamientoXArchivoAImprimirComplementario As Integer
   Public Property DesplazamientoYArchivoAImprimirComplementario As Integer
   Public Property DesplazamientoXArchivoAExportar As Integer
   Public Property DesplazamientoYArchivoAExportar As Integer

End Class
