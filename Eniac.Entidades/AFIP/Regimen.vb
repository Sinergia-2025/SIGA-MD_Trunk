Public Class Regimen
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdRegimen
      ConceptoRegimen
      ARetenerInscripto
      ARetenerNoInscripto
      MontoAExceder
      ImporteMinimoInscripto
      ImporteMinimoNoInscripto
      IdTipoImpuesto
      RetienePorEscala
      MinimoNoImponible
      OrigenBaseImponible
      CodigoAfip
   End Enum

   Public Enum OrigenBaseImponibleEnum As Integer
      NETO = 0
      TOTAL = 1
   End Enum

#Region "Propiedades"

   Private _idRegimen As Integer
   Public Property IdRegimen() As Integer
      Get
         Return _idRegimen
      End Get
      Set(ByVal value As Integer)
         _idRegimen = value
      End Set
   End Property

   Private _conceptoRegimen As String
   Public Property ConceptoRegimen() As String
      Get
         Return _conceptoRegimen
      End Get
      Set(ByVal value As String)
         _conceptoRegimen = value
      End Set
   End Property

   Private _aRetenerInscripto As Decimal
   Public Property ARetenerInscripto() As Decimal
      Get
         Return _aRetenerInscripto
      End Get
      Set(ByVal value As Decimal)
         _aRetenerInscripto = value
      End Set
   End Property

   Private _aRetenerNoInscripto As Decimal
   Public Property ARetenerNoInscripto() As Decimal
      Get
         Return _aRetenerNoInscripto
      End Get
      Set(ByVal value As Decimal)
         _aRetenerNoInscripto = value
      End Set
   End Property

   Private _montoAExceder As Decimal
   Public Property MontoAExceder() As Decimal
      Get
         Return _montoAExceder
      End Get
      Set(ByVal value As Decimal)
         _montoAExceder = value
      End Set
   End Property

   Private _importeMinimoInscripto As Decimal
   Public Property ImporteMinimoInscripto() As Decimal
      Get
         Return _importeMinimoInscripto
      End Get
      Set(ByVal value As Decimal)
         _importeMinimoInscripto = value
      End Set
   End Property

   Private _importeMinimoNoInscripto As Decimal
   Public Property ImporteMinimoNoInscripto() As Decimal
      Get
         Return _importeMinimoNoInscripto
      End Get
      Set(ByVal value As Decimal)
         _importeMinimoNoInscripto = value
      End Set
   End Property

   Private _tipoImpuesto As Entidades.TipoImpuesto
   Public Property TipoImpuesto() As Entidades.TipoImpuesto
      Get
         If Me._tipoImpuesto Is Nothing Then
            Me._tipoImpuesto = New Entidades.TipoImpuesto()
         End If
         Return _tipoImpuesto
      End Get
      Set(ByVal value As Entidades.TipoImpuesto)
         _tipoImpuesto = value
      End Set
   End Property

   Private _retienePorEscala As Boolean
   Public Property RetienePorEscala() As Boolean
      Get
         Return _retienePorEscala
      End Get
      Set(ByVal value As Boolean)
         _retienePorEscala = value
      End Set
   End Property

   Private _minimoNoImponible As Decimal
   Public Property MinimoNoImponible() As Decimal
      Get
         Return _minimoNoImponible
      End Get
      Set(ByVal value As Decimal)
         _minimoNoImponible = value
      End Set
   End Property

   Private _origenBaseImponible As OrigenBaseImponibleEnum
   Public Property OrigenBaseImponible() As OrigenBaseImponibleEnum
      Get
         Return _origenBaseImponible
      End Get
      Set(ByVal value As OrigenBaseImponibleEnum)
         _origenBaseImponible = value
      End Set
   End Property
   Private _CodigoAfip As Integer
   Public Property CodigoAfip() As Integer
      Get
         Return _CodigoAfip
      End Get
      Set(ByVal value As Integer)
         _CodigoAfip = value
      End Set
   End Property
#End Region

   Public Function GetCopia() As Entidades.Regimen
      Dim copia As Entidades.Regimen = New Entidades.Regimen()
      With copia
         .ARetenerInscripto = Me._aRetenerInscripto
         .ARetenerNoInscripto = Me._aRetenerNoInscripto
         .ConceptoRegimen = Me._conceptoRegimen
         .IdRegimen = Me._idRegimen
         .IdSucursal = Me.IdSucursal
         .ImporteMinimoInscripto = Me._importeMinimoInscripto
         .ImporteMinimoNoInscripto = Me._importeMinimoNoInscripto
         .MontoAExceder = Me._montoAExceder
         .MinimoNoImponible = Me._minimoNoImponible
         .Password = Me.Password
         .TipoImpuesto = Me._tipoImpuesto.GetCopia()
         .Usuario = Me.Usuario
      End With
      Return copia
   End Function

End Class
