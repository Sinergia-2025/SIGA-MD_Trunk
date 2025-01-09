
Public Class MarcaEmbarcacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdMarcaEmbarcacion
      NombreMarcaEmbarcacion
   End Enum

#Region "Propiedades"

   Private _idMarcaEmbarcacion As Integer

   Public Property IdMarcaEmbarcacion() As Integer
      Get
         Return _idMarcaEmbarcacion
      End Get
      Set(ByVal value As Integer)
         _idMarcaEmbarcacion = value
      End Set
   End Property

   Private _nombreMarcaEmbarcacion As String

   Public Property NombreMarcaEmbarcacion() As String
      Get
         Return _nombreMarcaEmbarcacion
      End Get
      Set(ByVal value As String)
         _nombreMarcaEmbarcacion = value
      End Set
   End Property

#End Region

End Class