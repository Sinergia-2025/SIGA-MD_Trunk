<Serializable()> _
Public Class Provincia
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProvincia
      NombreProvincia
      EsAgentePercepcion
      IngBrutos
      AgenteIngBrutos
      IdCuentaDebe
      IdCuentaHaber
      Jurisdiccion
      IdPais
      IdAFIPProvincia
   End Enum

#Region "Campos"

   Private _idProvincia As String
   Private _nombreProvincia As String
   Private _EsAgentePercepcion As Boolean
   Private _IngBrutos As String
   Private _AgenteIngBrutos As String
#End Region

#Region "Propiedades"

   Public Property IdProvincia() As String
      Get
         Return Me._idProvincia
      End Get
      Set(ByVal value As String)
         If value.Length < 3 Then
            Me._idProvincia = value
         Else
            Throw New Exception("El codigo de provincia no puede tener mas de 4 caracteres")
         End If
      End Set
   End Property
   Public Property NombreProvincia() As String
      Get
         Return Me._nombreProvincia
      End Get
      Set(ByVal value As String)
         Me._nombreProvincia = value
      End Set
   End Property

   Public Property EsAgentePercepcion() As Boolean
      Get
         Return Me._EsAgentePercepcion
      End Get
      Set(ByVal value As Boolean)
         Me._EsAgentePercepcion = value
      End Set
   End Property

   Public Property IngBrutos() As String
      Get
         Return Me._IngBrutos
      End Get
      Set(ByVal value As String)
         Me._IngBrutos = value
      End Set
   End Property

   Public Property AgenteIngBrutos() As String
      Get
         Return Me._AgenteIngBrutos
      End Get
      Set(ByVal value As String)
         Me._AgenteIngBrutos = value
      End Set
   End Property

   Public Property CuentaCompras As ContabilidadCuenta
   Public Property CuentaVentas As ContabilidadCuenta

   Public ReadOnly Property IdCuentaDebe As Long
      Get
         If CuentaCompras Is Nothing Then Return 0
         Return CuentaCompras.IdCuenta
      End Get
   End Property

   Public ReadOnly Property IdCuentaHaber As Long
      Get
         If CuentaVentas Is Nothing Then Return 0
         Return CuentaVentas.IdCuenta
      End Get
   End Property
   Public Property Jurisdiccion As Integer
   Public Property IdPais As String
   Public Property IdAFIPProvincia As Integer

#End Region

End Class