Public Class PadronARBA
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdPadronARBA
      PeriodoInformado
      TipoRegimen
      FechaPublicacion
      FechaVigenciaDesde
      FechaVigenciaHasta
      CUIT
      TipoContribuyente
      AccionARBA
      CambioAlicuota
      Alicuota
      Grupo
   End Enum

   Public Enum TipoRegimenEnum
      Retencion
      Percepcion
   End Enum

   Private _idPadronARBA As Long
   Public Property IdPadronARBA() As Long
      Get
         Return _idPadronARBA
      End Get
      Set(ByVal value As Long)
         _idPadronARBA = value
      End Set
   End Property
   Private _periodoInformado As Integer
   Public Property PeriodoInformado() As Integer
      Get
         Return _periodoInformado
      End Get
      Set(ByVal value As Integer)
         _periodoInformado = value
      End Set
   End Property
   Private _tipoRegimen As String
   Public Property TipoRegimen() As String
      Get
         Return _tipoRegimen
      End Get
      Set(ByVal value As String)
         _tipoRegimen = value
      End Set
   End Property
   Private _fechaPublicacion As DateTime
   Public Property FechaPublicacion() As DateTime
      Get
         Return _fechaPublicacion
      End Get
      Set(ByVal value As DateTime)
         _fechaPublicacion = value
      End Set
   End Property
   Private _fechaVigenciaDesde As DateTime
   Public Property FechaVigenciaDesde() As DateTime
      Get
         Return _fechaVigenciaDesde
      End Get
      Set(ByVal value As DateTime)
         _fechaVigenciaDesde = value
      End Set
   End Property
   Private _fechaVigenciaHasta As DateTime
   Public Property FechaVigenciaHasta() As DateTime
      Get
         Return _fechaVigenciaHasta
      End Get
      Set(ByVal value As DateTime)
         _fechaVigenciaHasta = value
      End Set
   End Property
   Private _CUIT As Long
   Public Property CUIT() As Long
      Get
         Return _CUIT
      End Get
      Set(ByVal value As Long)
         _CUIT = value
      End Set
   End Property
   Private _tipoContribuyente As String
   Public Property TipoContribuyente() As String
      Get
         Return _tipoContribuyente
      End Get
      Set(ByVal value As String)
         _tipoContribuyente = value
      End Set
   End Property
   Private _accionARBA As String
   Public Property AccionARBA() As String
      Get
         Return _accionARBA
      End Get
      Set(ByVal value As String)
         _accionARBA = value
      End Set
   End Property
   Private _cambioAlicuota As Boolean
   Public Property CambioAlicuota() As Boolean
      Get
         Return _cambioAlicuota
      End Get
      Set(ByVal value As Boolean)
         _cambioAlicuota = value
      End Set
   End Property
   Private _alicuota As Decimal
   Public Property Alicuota() As Decimal
      Get
         Return _alicuota
      End Get
      Set(ByVal value As Decimal)
         _alicuota = value
      End Set
   End Property
   Private _grupo As Integer
   Public Property Grupo() As Integer
      Get
         Return _grupo
      End Get
      Set(ByVal value As Integer)
         _grupo = value
      End Set
   End Property


   Public Shared Function TipoRegimenToString(value As TipoRegimenEnum) As String
      Select Case value
         Case TipoRegimenEnum.Percepcion
            Return "P"
         Case TipoRegimenEnum.Retencion
            Return "R"
         Case Else
            Return ""
      End Select
   End Function
End Class
