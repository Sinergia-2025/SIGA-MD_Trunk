
Public Class TipoTimonel
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoTimonel
      NombreTipoTimonel
      Prefijo
   End Enum

#Region "Propiedades"

   Private _idTipoTimonel As Integer

   Public Property IdTipoTimonel() As Integer
      Get
         Return _idTipoTimonel
      End Get
      Set(ByVal value As Integer)
         _idTipoTimonel = value
      End Set
   End Property

   Private _nombreTipoTimonel As String

   Public Property NombreTipoTimonel() As String
      Get
         Return _nombreTipoTimonel
      End Get
      Set(ByVal value As String)
         _nombreTipoTimonel = value
      End Set
   End Property

   Private _Prefijo As String

   Public Property Prefijo() As String
      Get
         Return _Prefijo
      End Get
      Set(ByVal value As String)
         _Prefijo = value
      End Set
   End Property

#End Region

End Class