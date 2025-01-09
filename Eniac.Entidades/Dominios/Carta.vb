<Serializable()> _
Public Class Carta
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCarta
      NombreCarta
      Firma
      DiasDefault
      ProximaCarta
      Texto
      Texto2
      TextoRTF
      Texto2RTF
      MiraAnoEnCurso
      EsHTML
      Tipo

   End Enum

   Private _proximaCarta As Integer
   Public Property ProximaCarta() As Integer
      Get
         Return _proximaCarta
      End Get
      Set(ByVal value As Integer)
         _proximaCarta = value
      End Set
   End Property

   Private _idCarta As Integer
   Public Property IdCarta() As Integer
      Get
         Return _idCarta
      End Get
      Set(ByVal value As Integer)
         _idCarta = value
      End Set
   End Property

   Private _nombreCarta As String
   Public Property NombreCarta() As String
      Get
         Return _nombreCarta
      End Get
      Set(ByVal value As String)
         _nombreCarta = value
      End Set
   End Property

   Private _firma As String
   Public Property Firma() As String
      Get
         Return _firma
      End Get
      Set(ByVal value As String)
         _firma = value
      End Set
   End Property

   Private _diasDefault As Integer
   Public Property DiasDefault() As Integer
      Get
         Return _diasDefault
      End Get
      Set(ByVal value As Integer)
         _diasDefault = value
      End Set
   End Property

   Private _texto As String
   Public Property Texto() As String
      Get
         Return _texto
      End Get
      Set(ByVal value As String)
         _texto = value
      End Set
   End Property

   Private _texto2 As String
   Public Property Texto2() As String
      Get
         Return _texto2
      End Get
      Set(ByVal value As String)
         _texto2 = value
      End Set
   End Property

   Private _textoRTF As String
   Public Property TextoRTF() As String
      Get
         Return _textoRTF
      End Get
      Set(ByVal value As String)
         _textoRTF = value
      End Set
   End Property

   Private _texto2RTF As String
   Public Property Texto2RTF() As String
      Get
         Return _texto2RTF
      End Get
      Set(ByVal value As String)
         _texto2RTF = value
      End Set
   End Property

   Private _miraanoencurso As Boolean
   Public Property MiraAnoEnCurso() As Boolean
      Get
         Return _miraanoencurso
      End Get
      Set(ByVal value As Boolean)
         _miraanoencurso = value
      End Set
   End Property

   Private _esHTML As Boolean
   Public Property EsHTML() As Boolean
      Get
         Return _esHTML
      End Get
      Set(ByVal value As Boolean)
         _esHTML = value
      End Set
   End Property

   Private _tipo As String
   Public Property Tipo() As String
      Get
         Return _tipo
      End Get
      Set(ByVal value As String)
         _tipo = value
      End Set
   End Property
End Class
