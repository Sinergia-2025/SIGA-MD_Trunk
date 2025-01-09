
Public Class TipoMatricula
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdTipoMatricula
      NombreTipoMatricula
      TieneNumeros
   End Enum

#Region "Propiedades"

   Private _idTipoMatricula As Integer

   Public Property IdTipoMatricula() As Integer
      Get
         Return _idTipoMatricula
      End Get
      Set(ByVal value As Integer)
         _idTipoMatricula = value
      End Set
   End Property

   Private _nombreTipoMatricula As String

   Public Property NombreTipoMatricula() As String
      Get
         Return _nombreTipoMatricula
      End Get
      Set(ByVal value As String)
         _nombreTipoMatricula = value
      End Set
   End Property

   Private _tieneNumeros As Boolean

   Public Property TieneNumeros() As Boolean
      Get
         Return _tieneNumeros
      End Get
      Set(ByVal value As Boolean)
         _tieneNumeros = value
      End Set
   End Property

#End Region

End Class