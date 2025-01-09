Public Interface IAdjunto
   Property IdAdjunto As Long
   Property IdTipoAdjunto As Integer
   Property NombreTipoAdjunto As String      'Solo para pantalla, no se persiste.
   Property NombreAdjunto As String
   Property NombreAdjuntoCompleto As String  'Solo para guardar el path completo de los archivos nuevos, no se persiste.
   Property Adjunto As Byte()
   Property Observaciones As String
   Property NivelAutorizacion As Short
   ReadOnly Property OrigenAdjunto As String
End Interface
Public Enum ModoCargaAdjunto
   Cargar
   NoCargar
   SinDatos
End Enum