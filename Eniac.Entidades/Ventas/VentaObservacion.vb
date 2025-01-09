<Serializable()>
Public Class VentaObservacion
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Short
   Private _numeroComprobante As Long
   Private _linea As Integer
   Private _observacion As String

#End Region

   Public Sub New()
   End Sub
   Public Sub New(observacion As String)
      Me.New()
      _observacion = observacion
   End Sub

   Public Sub New(observacion As String, tipoObserv As Short, descripcionTipoObserv As String)
      Me.New()
      _observacion = observacion
      IdTipoObservacion = tipoObserv
      DescripcionTipoObservacion = descripcionTipoObserv
   End Sub

#Region "Propiedades"

   Public Property IdTipoComprobante() As String
      Get
         Return _idTipoComprobante
      End Get
      Set(ByVal value As String)
         _idTipoComprobante = value
      End Set
   End Property
   Public Property Letra() As String
      Get
         Return _letra
      End Get
      Set(ByVal value As String)
         Me._letra = value
      End Set
   End Property
   Public Property CentroEmisor() As Short
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Short)
         _centroEmisor = value
      End Set
   End Property
   Public Property NumeroComprobante() As Long
      Get
         Return Me._numeroComprobante
      End Get
      Set(ByVal value As Long)
         Me._numeroComprobante = value
      End Set
   End Property
   Public Property Linea() As Integer
      Get
         Return Me._linea
      End Get
      Set(ByVal value As Integer)
         Me._linea = value
      End Set
   End Property
   Private Const MaxLengthObservacion As Integer = 100
   Public Property Observacion() As String
      Get
         Return Me._observacion.Truncar(MaxLengthObservacion)
      End Get
      Set(ByVal value As String)
         Me._observacion = value
      End Set
   End Property
   Public Property IdTipoObservacion As Short
   Public Property DescripcionTipoObservacion As String
#End Region

End Class