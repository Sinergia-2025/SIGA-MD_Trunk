Public Class ClienteAdjunto
   Inherits Eniac.Entidades.Entidad
   Implements IAdjunto
   Public Enum Columnas
      IdCliente
      IdClienteAdjunto
      IdTipoAdjunto
      NombreAdjunto
      Adjunto
      Observaciones
      NivelAutorizacion
   End Enum

   Public Sub New()
      NombreAdjunto = String.Empty
   End Sub

   Public Property IdCliente As Long
   Public Property IdClienteAdjunto As Long Implements IAdjunto.IdAdjunto

   Public Property IdTipoAdjunto As Integer Implements IAdjunto.IdTipoAdjunto
   Public Property NombreTipoAdjunto As String Implements IAdjunto.NombreTipoAdjunto         'Solo para pantalla, no se persiste.
   Public Property NombreAdjunto As String Implements IAdjunto.NombreAdjunto
   Public Property NombreAdjuntoCompleto As String Implements IAdjunto.NombreAdjuntoCompleto 'Solo para guardar el path completo de los archivos nuevos, no se persiste.
   Public Property Adjunto As Byte() Implements IAdjunto.Adjunto
   Public Property Observaciones As String Implements IAdjunto.Observaciones
   Public Property NivelAutorizacion As Short Implements IAdjunto.NivelAutorizacion
   Public ReadOnly Property OrigenAdjunto As String Implements IAdjunto.OrigenAdjunto
      Get
         Return "CLIENTE"
      End Get
   End Property
End Class