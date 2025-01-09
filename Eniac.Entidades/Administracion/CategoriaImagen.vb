
Public Class CategoriaImagen
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoriaImagen
      IdCategoria
      IdTipoNave
      Foto
      FotoReverso
      ColorFuente
      ColorFuenteVto
   End Enum

#Region "Propiedades"

   Private _idCategoriaImagen As Integer

   Public Property IdCategoriaImagen() As Integer
      Get
         Return _idCategoriaImagen
      End Get
      Set(ByVal value As Integer)
         _idCategoriaImagen = value
      End Set
   End Property


   Private _categoria As Entidades.Categoria

   Public Property Categoria() As Entidades.Categoria
      Get
         If Me._categoria Is Nothing Then
            Me._categoria = New Entidades.Categoria()
         End If
         Return _categoria
      End Get
      Set(ByVal value As Entidades.Categoria)
         _categoria = value
      End Set
   End Property


   Private _idTipoNave As Short

   Public Property IdTipoNave() As Short
      Get
         Return _idTipoNave
      End Get
      Set(ByVal value As Short)
         _idTipoNave = value
      End Set
   End Property

   Private _foto() As System.Byte

   Public Property Foto() As System.Byte()
      Get
         Return _foto
      End Get
      Set(ByVal value As System.Byte())
         _foto = value
      End Set
   End Property

   Private _colorFuente As String

   Public Property ColorFuente() As String
      Get
         Return _colorFuente
      End Get
      Set(ByVal value As String)
         _colorFuente = value
      End Set
   End Property

   Private _fotoReverso() As System.Byte

   Public Property FotoReverso() As System.Byte()
      Get
         Return _fotoReverso
      End Get
      Set(ByVal value As System.Byte())
         _fotoReverso = value
      End Set
   End Property

   Public Property ColorFuenteVto As String

#End Region

End Class