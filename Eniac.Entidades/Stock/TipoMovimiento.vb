<Serializable()>
Public Class TipoMovimiento
   Inherits Eniac.Entidades.Entidad

   Public Enum TiposMovimientos
      AJUSTE
   End Enum

   Public Enum Columnas
      IdTipoMovimiento
      Descripcion
      AsociaSucursal
      ComprobantesAsociados
      CoeficienteStock
      MuestraCombo
      HabilitaDestinatario
      HabilitaRubro
      Imprime
      CargaPrecio
      IdContraTipoMovimiento
      HabilitaEmpleado
      ReservaMercaderia
   End Enum

   Public Enum CargaPrecios
      PrecioCosto
      PrecioVenta
      NO
   End Enum



#Region "Campos"

   Private _idTipoMovimiento As String
   Private _descripcion As String
   Private _asociaSucursal As Boolean
   Private _comprobantesAsociados As String
   Private _coeficienteStock As Integer
   Private _muestraCombo As Boolean
   Private _habilitaDestinatario As Boolean
   Private _habilitaRubro As Boolean
   Private _imprime As Boolean
   Private _cargaPrecio As String

#End Region

#Region "Propiedades"
   Public Property IdDeposito As Integer

   Public Property CargaPrecio() As String
      Get
         Return Me._cargaPrecio
      End Get
      Set(ByVal value As String)
         Me._cargaPrecio = value
      End Set
   End Property
   Public Property Imprime() As Boolean
      Get
         Return Me._imprime
      End Get
      Set(ByVal value As Boolean)
         Me._imprime = value
      End Set
   End Property
   Public Property HabilitaRubro() As Boolean
      Get
         Return Me._habilitaRubro
      End Get
      Set(ByVal value As Boolean)
         Me._habilitaRubro = value
      End Set
   End Property
   Public Property HabilitaDestinatario() As Boolean
      Get
         Return Me._habilitaDestinatario
      End Get
      Set(ByVal value As Boolean)
         Me._habilitaDestinatario = value
      End Set
   End Property
   Public Property MuestraCombo() As Boolean
      Get
         Return Me._muestraCombo
      End Get
      Set(ByVal value As Boolean)
         Me._muestraCombo = value
      End Set
   End Property
   Public Property IdTipoMovimiento() As String
      Get
         Return _idTipoMovimiento
      End Get
      Set(ByVal value As String)
         _idTipoMovimiento = value
      End Set
   End Property
   Public Property AsociaSucursal() As Boolean
      Get
         Return _asociaSucursal
      End Get
      Set(ByVal value As Boolean)
         _asociaSucursal = value
      End Set
   End Property
   Public Property ComprobantesAsociados() As String
      Get
         Return _comprobantesAsociados
      End Get
      Set(ByVal value As String)
         _comprobantesAsociados = value
      End Set
   End Property
   Public Property CoeficienteStock() As Integer
      Get
         Return _coeficienteStock
      End Get
      Set(ByVal value As Integer)
         _coeficienteStock = value
      End Set
   End Property
   Public Property Descripcion() As String
      Get
         Return _descripcion
      End Get
      Set(ByVal value As String)
         _descripcion = value
      End Set
   End Property

   'GAR: 13/09/2017 - Por ahora no se habilita porque genera un Loop en el GETUNA.
   'Private _contraTipoMovimiento As Entidades.TipoMovimiento
   'Public Property ContraTipoMovimiento() As Entidades.TipoMovimiento
   '   Get
   '      If Me._contraTipoMovimiento Is Nothing Then
   '         Me._contraTipoMovimiento = New Entidades.TipoMovimiento()
   '      End If
   '      Return _contraTipoMovimiento
   '   End Get
   '   Set(ByVal value As Entidades.TipoMovimiento)
   '      _contraTipoMovimiento = value
   '   End Set
   'End Property

   Private _idContraTipoMovimiento As String
   Public Property IdContraTipoMovimiento As String
      Get
         If Me._idContraTipoMovimiento Is Nothing Then
            Return ""
         Else
            Return Me._idContraTipoMovimiento
         End If
      End Get
      Set(value As String)
         Me._idContraTipoMovimiento = value
      End Set
   End Property

   Public Property HabilitaEmpleado As Boolean
   Public Property ReservaMercaderia As Boolean

#End Region

End Class