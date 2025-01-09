
Public Class ModeloEmbarcacion
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdModeloEmbarcacion
      NombreModeloEmbarcacion
      IdMarcaEmbarcacion
      NombreMarcaEmbarcacion
   End Enum

#Region "Propiedades"

   Private _idModeloEmbarcacion As Integer

   Public Property IdModeloEmbarcacion() As Integer
      Get
         Return _idModeloEmbarcacion
      End Get
      Set(ByVal value As Integer)
         _idModeloEmbarcacion = value
      End Set
   End Property

   Private _nombreModeloEmbarcacion As String

   Public Property NombreModeloEmbarcacion() As String
      Get
         Return _nombreModeloEmbarcacion
      End Get
      Set(ByVal value As String)
         _nombreModeloEmbarcacion = value
      End Set
   End Property

   Private _marcaEmbarcacion As Entidades.MarcaEmbarcacion
   Public Property MarcaEmbarcacion() As Entidades.MarcaEmbarcacion
      Get
         If Me._marcaEmbarcacion Is Nothing Then
            Me._marcaEmbarcacion = New Entidades.MarcaEmbarcacion()
         End If
         Return _marcaEmbarcacion
      End Get
      Set(ByVal value As Entidades.MarcaEmbarcacion)
         _marcaEmbarcacion = value
      End Set
   End Property

#End Region

End Class