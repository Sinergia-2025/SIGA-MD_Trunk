Public Class CRMEntidad
   Inherits Eniac.Entidades.Entidad
   Public Sub New()
      TipoNovedad = New CRMTipoNovedad()
   End Sub
   Public Property TipoNovedad() As CRMTipoNovedad
   Public ReadOnly Property IdTipoNovedad() As String
      Get
         If TipoNovedad Is Nothing Then Return String.Empty
         Return TipoNovedad.IdTipoNovedad
      End Get
   End Property
End Class
