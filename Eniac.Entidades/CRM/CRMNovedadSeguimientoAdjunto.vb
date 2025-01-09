Public Class CRMNovedadSeguimientoAdjunto
   Inherits CRMEntidad
   Public Const NombreTabla As String = "CRMNovedadesSeguimientoAdjuntos"

   Public Enum Columnas
      IdTipoNovedad
      Letra
      CentroEmisor
      IdNovedad
      IdSeguimiento
      IdUnico
      NombreAdjunto
      Adjunto
   End Enum

   Public Sub New()
      MyBase.New()
   End Sub

   Public Sub New(novedad As CRMNovedadSeguimiento, nombreAdjunto As String)
      Me.New()
      Me.TipoNovedad = If(novedad IsNot Nothing, novedad.TipoNovedad, Nothing)
      Me.Letra = If(novedad IsNot Nothing, novedad.Letra, String.Empty)
      Me.CentroEmisor = If(novedad IsNot Nothing, novedad.CentroEmisor, 0S)
      Me.IdNovedad = If(novedad IsNot Nothing, novedad.IdNovedad, 0L)
      Me.IdUnico = If(novedad IsNot Nothing, novedad.IdUnico, String.Empty)
      Me.NombreAdjunto = nombreAdjunto
   End Sub

   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property IdNovedad As Long
   Public Property IdSeguimiento As Integer
   Public Property IdUnico As String

   Public Property NombreAdjunto As String
   Public Property Adjunto As Byte()
End Class