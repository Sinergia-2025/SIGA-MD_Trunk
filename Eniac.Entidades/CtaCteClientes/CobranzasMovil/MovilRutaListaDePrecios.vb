Public Class MovilRutaListaDePrecios
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "MovilRutasListasDePrecios"
   Public Enum Columnas
      IdRuta
      IdListaPrecios
      PorDefecto
      AplicaPreciosOferta
   End Enum

   Public Property ListaDePrecios As Eniac.Entidades.ListaDePrecios
   Public Property IdRuta As Integer
   Public Property NombreRuta As String      'Solo para mostrar en grillas
   Public Property PorDefecto As Boolean
   Public Property AplicaPreciosOferta As Boolean

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdListaPrecios As Integer
      Get
         If ListaDePrecios Is Nothing Then Return -1
         Return ListaDePrecios.IdListaPrecios
      End Get
   End Property
   Public ReadOnly Property NombreListaPrecios As String
      Get
         If ListaDePrecios Is Nothing Then Return String.Empty
         Return ListaDePrecios.NombreListaPrecios
      End Get
   End Property
#End Region

End Class