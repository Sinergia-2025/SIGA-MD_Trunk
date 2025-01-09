Public Class Cobrador
   Inherits Eniac.Entidades.Entidad

   Public Sub New()
      CobradorSucursal = New CobradorSucursal()
   End Sub

   Public Enum Columnas
      IdCobrador
      NombreCobrador
      DebitoDirecto
      IdBanco
      NombreBanco
      IdDispositivo
   End Enum

   Public Property IdCobrador() As Integer

   Public Property NombreCobrador() As String
   Public Property DebitoDirecto() As Boolean
   Public Property IdBanco() As Integer
   Public Property NombreBanco() As String
   Public Property IdDispositivo As String
   Public Property CobradorSucursal As CobradorSucursal

#Region "Propiedades CobradorSucursal"
   Public Property IdCaja() As Integer?
      Get
         Return CobradorSucursal.IdCaja
      End Get
      Set(ByVal value As Integer?)
         CobradorSucursal.IdCaja = value
      End Set
   End Property

   Public Property Observacion() As String
      Get
         Return CobradorSucursal.Observacion
      End Get
      Set(ByVal value As String)
         CobradorSucursal.Observacion = value
      End Set
   End Property
#End Region

End Class