
Public Class CategoriaEmbarcacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoriaEmbarcacion
      NombreCategoriaEmbarcacion
      IdTipoEmbarcacion
      NombreTipoEmbarcacion
      ImporteExpensas
      ImporteAlquiler
      PorcDescAlquiler
      ImporteGastosAdmin
      ImporteGastosIntermAlq
      ExpensasRelacionCategoria
      Alto
      Ancho
      Largo
      'PE-31303
      IdIntereses
   End Enum

#Region "Propiedades"

   Private _idCategoriaEmbarcacion As Integer

   Public Property IdCategoriaEmbarcacion() As Integer
      Get
         Return _idCategoriaEmbarcacion
      End Get
      Set(ByVal value As Integer)
         _idCategoriaEmbarcacion = value
      End Set
   End Property

   Private _nombreCategoriaEmbarcacion As String

   Public Property NombreCategoriaEmbarcacion() As String
      Get
         Return _nombreCategoriaEmbarcacion
      End Get
      Set(ByVal value As String)
         _nombreCategoriaEmbarcacion = value
      End Set
   End Property

   Private _idTipoEmbarcacion As Integer

   Public Property IdTipoEmbarcacion() As Integer
      Get
         Return _idTipoEmbarcacion
      End Get
      Set(ByVal value As Integer)
         _idTipoEmbarcacion = value
      End Set
   End Property

   Private _nombreTipoEmbarcacion As String

   Public Property NombreTipoEmbarcacion() As String
      Get
         Return _nombreTipoEmbarcacion
      End Get
      Set(ByVal value As String)
         _nombreTipoEmbarcacion = value
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

   Private _ImporteGastosAdmin As Decimal

   Public Property ImporteGastosAdmin() As Decimal
      Get
         Return _ImporteGastosAdmin
      End Get
      Set(ByVal value As Decimal)
         _ImporteGastosAdmin = value
      End Set
   End Property

   Private _ImporteGastosIntermAlq As Decimal

   Public Property ImporteGastosIntermAlq() As Decimal
      Get
         Return _ImporteGastosIntermAlq
      End Get
      Set(ByVal value As Decimal)
         _ImporteGastosIntermAlq = value
      End Set
   End Property

   Public Property ExpensasRelacionCategoria() As Decimal

   Public Property Alto As Decimal
   Public Property Ancho As Decimal
   Public Property Largo As Decimal

   'PE-31303
   Private _interes As Eniac.Entidades.Interes
   Public Property Interes() As Eniac.Entidades.Interes
      Get
         If Me._interes Is Nothing Then
            Me._interes = New Eniac.Entidades.Interes()
         End If
         Return Me._interes
      End Get
      Set(value As Eniac.Entidades.Interes)
         Me._interes = value
      End Set
   End Property
   Public ReadOnly Property IdInteres() As Integer
      Get
         If Interes Is Nothing Then Return 0
         Return Interes.IdInteres
      End Get
   End Property

#End Region

End Class