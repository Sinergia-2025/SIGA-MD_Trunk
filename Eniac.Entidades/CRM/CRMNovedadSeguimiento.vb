Public Class CRMNovedadSeguimiento
   Inherits CRMEntidad
   Public Const NombreTabla As String = "CRMNovedadesSeguimiento"

   Public Enum Columnas
      IdTipoNovedad
      Letra
      CentroEmisor
      IdNovedad
      IdSeguimiento
      IdUnico
      FechaSeguimiento
      Comentario
      EsComentario
      UsuarioSeguimiento
      Interlocutor
      IdTipoComentarioNovedad
      ComentarioPrincipal
      Activo
      IdEstadoNovedad
      UsuarioAsignado
      FechaActualizacionWeb

   End Enum

   Public Sub New()
      MyBase.New()
      UsuarioSeguimiento = New Usuario()
      Activo = True
      ComentarioPrincipal = False
      IdUnico = Guid.NewGuid().ToString()
   End Sub

   Public Sub New(novedad As CRMNovedad,
                  fechaSeguimiento As DateTime?,
                  comentario As String,
                  estadoNovedad As Entidades.CRMEstadoNovedad)
      Me.New(novedad, fechaSeguimiento, comentario, interlocutor:=String.Empty, esComentario:=False, idTipoComentarioNovedad:=0, estadoNovedad:=estadoNovedad, adjunto:=Nothing)
   End Sub

   Public Sub New(novedad As CRMNovedad,
                  fechaSeguimiento As DateTime?,
                  comentario As String,
                  interlocutor As String,
                  esComentario As Boolean,
                  idTipoComentarioNovedad As Integer,
                  estadoNovedad As Entidades.CRMEstadoNovedad,
                  adjunto As CRMNovedadSeguimientoAdjunto)
      Me.New()
      Me.TipoNovedad = If(novedad IsNot Nothing, novedad.TipoNovedad, Nothing)
      Me.Letra = If(novedad IsNot Nothing, novedad.Letra, "")
      Me.CentroEmisor = If(novedad IsNot Nothing, novedad.CentroEmisor, 0S)
      Me.IdNovedad = If(novedad IsNot Nothing, novedad.IdNovedad, 0L)
      If fechaSeguimiento.HasValue Then
         Me.FechaSeguimiento = fechaSeguimiento.Value
      Else
         Me.FechaSeguimiento = DateTime.Now
      End If
      Me.Comentario = comentario
      Me.Interlocutor = interlocutor
      Me.EsComentario = esComentario
      Me.IdTipoComentarioNovedad = idTipoComentarioNovedad
      Me.ComentarioPrincipal = False
      Me.Activo = True
      Me.EstadoNovedad = estadoNovedad
      Me.ArchivoAdjunto = adjunto
      Me.UsuarioAsignado = If(novedad IsNot Nothing, novedad.UsuarioAsignado, Nothing)
   End Sub


   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property IdNovedad As Long
   Public Property IdSeguimiento As Integer
   Public Property IdUnico As String

   Public Property FechaSeguimiento As DateTime
   Public Property Comentario As String
   Public Property Interlocutor As String
   Public Property EsComentario As Boolean
   Public Property IdTipoComentarioNovedad As Integer?
   Public Property ComentarioPrincipal As Boolean
   Public Property Activo As Boolean
   Public Property UsuarioSeguimiento As Usuario
   Public Property UsuarioAsignado As Usuario

   Public Property FechaActualizacionWeb As DateTime


   Public Property EstadoNovedad As Entidades.CRMEstadoNovedad
   Public ReadOnly Property IdEstadoNovedad As Integer
      Get
         If EstadoNovedad Is Nothing Then Return 0
         Return EstadoNovedad.IdEstadoNovedad
      End Get
   End Property
   Public ReadOnly Property NombreEstadoNovedad As String
      Get
         If EstadoNovedad Is Nothing Then Return String.Empty
         Return EstadoNovedad.NombreEstadoNovedad
      End Get
   End Property

   'Public Property NombreTipoComentarioNovedad As String          'Solo para mostrar en grillas

   Public Property ArchivoAdjunto As CRMNovedadSeguimientoAdjunto

   Public ReadOnly Property IdUsuarioSeguimiento As String
      Get
         If UsuarioSeguimiento Is Nothing Then Return String.Empty
         Return UsuarioSeguimiento.Usuario
      End Get
   End Property
   Public ReadOnly Property IdUsuarioAsignado As String
      Get
         If UsuarioAsignado Is Nothing Then Return String.Empty
         Return UsuarioAsignado.Usuario
      End Get
   End Property

End Class