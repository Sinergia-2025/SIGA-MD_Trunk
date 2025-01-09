
Public Class CategoriaCama
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoriaCama
      NombreCategoriaCama
      CantidadAccionesRequeridas
      Alto
      Ancho
      Largo
      TasaMunicipal
      ImporteExpensas
      ImporteAlquiler
      PorcDescAlquiler
      ImporteGastosAdmin
      ImporteGastosIntermAlq
   End Enum

#Region "Propiedades"

   Private _idCategoriaCama As Integer

   Public Property IdCategoriaCama() As Integer
      Get
         Return _idCategoriaCama
      End Get
      Set(ByVal value As Integer)
         _idCategoriaCama = value
      End Set
   End Property

   Private _nombreCategoriaCama As String

   Public Property NombreCategoriaCama() As String
      Get
         Return _nombreCategoriaCama
      End Get
      Set(ByVal value As String)
         _nombreCategoriaCama = value
      End Set
   End Property

   Private _CantidadAccionesRequeridas As Integer

   Public Property CantidadAccionesRequeridas() As Integer
      Get
         Return _CantidadAccionesRequeridas
      End Get
      Set(ByVal value As Integer)
         _CantidadAccionesRequeridas = value
      End Set
   End Property

   Private _alto As Decimal

   Public Property Alto() As Decimal
      Get
         Return _alto
      End Get
      Set(ByVal value As Decimal)
         _alto = value
      End Set
   End Property

   Private _ancho As Decimal

   Public Property Ancho() As Decimal
      Get
         Return _ancho
      End Get
      Set(ByVal value As Decimal)
         _ancho = value
      End Set
   End Property

   Private _largo As Decimal

   Public Property Largo() As Decimal
      Get
         Return _largo
      End Get
      Set(ByVal value As Decimal)
         _largo = value
      End Set
   End Property

   Private _tasaMunicipal As Decimal
   Public Property TasaMunicipal() As Decimal
      Get
         Return _tasaMunicipal
      End Get
      Set(ByVal value As Decimal)
         _tasaMunicipal = value
      End Set
   End Property

   Private _importeExpensas As Decimal
   Public Property ImporteExpensas() As Decimal
      Get
         Return _importeExpensas
      End Get
      Set(ByVal value As Decimal)
         _importeExpensas = value
      End Set
   End Property

   Private _importeAlquiler As Decimal
   Public Property ImporteAlquiler() As Decimal
      Get
         Return _importeAlquiler
      End Get
      Set(ByVal value As Decimal)
         _importeAlquiler = value
      End Set
   End Property

   Private _PorcDescAlquiler As Decimal
   Public Property PorcDescAlquiler() As Decimal
      Get
         Return _PorcDescAlquiler
      End Get
      Set(ByVal value As Decimal)
         _PorcDescAlquiler = value
      End Set
   End Property

   Private _importeGastosAdmin As Decimal
   Public Property ImporteGastosAdmin() As Decimal
      Get
         Return _importeGastosAdmin
      End Get
      Set(ByVal value As Decimal)
         _importeGastosAdmin = value
      End Set
   End Property

   Private _importeGastosIntermAlq As Decimal
   Public Property ImporteGastosIntermAlq() As Decimal
      Get
         Return _importeGastosIntermAlq
      End Get
      Set(ByVal value As Decimal)
         _importeGastosIntermAlq = value
      End Set
   End Property
#End Region

End Class