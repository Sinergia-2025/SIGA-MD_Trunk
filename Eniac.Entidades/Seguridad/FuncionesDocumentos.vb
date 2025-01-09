Public Class FuncionesDocumentos
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "FuncionesDocumentos"

   ' Columnas
   Public Enum Columnas
      IdFuncion
      IdTipoLink
      Orden
      Link
      Descripcion
   End Enum

   ' Propiedades
   Public Property IdFuncion() As String
   Public Property TipoDocumentoFuncion As Entidades.TipoDocumentoFuncion
   Public Property Orden() As Integer
   Public Property Link() As String
   Public Property Descripcion() As String

   Public ReadOnly Property IdTipoLink() As String
      Get
         If TipoDocumentoFuncion Is Nothing Then Return String.Empty
         Return TipoDocumentoFuncion.IdTipoLink
      End Get
   End Property
   Public ReadOnly Property DescripcionTipoLink() As String
      Get
         If TipoDocumentoFuncion Is Nothing Then Return String.Empty
         Return TipoDocumentoFuncion.Descripcion
      End Get
   End Property
   Public ReadOnly Property DescripcionAbreviadaTipoLink() As String
      Get
         If TipoDocumentoFuncion Is Nothing Then Return String.Empty
         Return TipoDocumentoFuncion.DescripcionAbreviada
      End Get
   End Property

End Class