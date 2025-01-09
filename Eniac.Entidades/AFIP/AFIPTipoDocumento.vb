Public Class AFIPTipoDocumento
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "AFIPTiposDocumentos"
   Public Enum Columnas
      IdAFIPTipoDocumento
      NombreAFIPTipoDocumento
      TipoDocumento
   End Enum

   Public Property IdAFIPTipoDocumento As Integer
   Public Property NombreAFIPTipoDocumento As String
   Public Property TipoDocumento As String

   Public ReadOnly Property IdNombre As String
      Get
         Return String.Format("{0:00} - {1}", IdAFIPTipoDocumento, NombreAFIPTipoDocumento)
      End Get
   End Property
End Class