Namespace JSonEntidades.Soporte
   Public Class NovedadesSeguimiento
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub

      Public Property IdTipoNovedad As String
      Public Property IdNovedad As Long
      Public Property IdSeguimiento As Integer
      Public Property FechaSeguimiento As Date
      Public Property Comentario As String
      Public Property NombreAdjunto As String
      Public Property EsComentario As Boolean
      Public Property UsuarioSeguimiento As String
      Public Property Interlocutor As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property IdTipoComentarioNovedad As Nullable(Of Integer)
      Public Property Activo As Boolean
      Public Property IdEstadoNovedad As Nullable(Of Integer)
      Public Property UsuarioAsignado As String

      Public Shared Function Parse(idEmpresa As Integer, dr As DataRow) As NovedadesSeguimiento
         Dim result As NovedadesSeguimiento = New NovedadesSeguimiento(idEmpresa)
         With result
            .IdTipoNovedad = dr.Field(Of String)("IdTipoNovedad")
            .Letra = dr.Field(Of String)("Letra")
            .CentroEmisor = dr.Field(Of Short)("CentroEmisor")
            .IdNovedad = dr.Field(Of Long)("IdNovedad")
            .IdSeguimiento = dr.Field(Of Integer)("IdSeguimiento")
            .FechaSeguimiento = dr.Field(Of DateTime)("FechaSeguimiento")
            .Comentario = dr.Field(Of String)("Comentario")
            .EsComentario = dr.Field(Of Boolean)("EsComentario")
            .UsuarioSeguimiento = dr.Field(Of String)("UsuarioSeguimiento")
            .Interlocutor = dr.Field(Of String)("Interlocutor")
            .IdTipoComentarioNovedad = dr.Field(Of Integer?)("IdTipoComentarioNovedad")
            .Activo = dr.Field(Of Boolean)("Activo")
            .IdEstadoNovedad = dr.Field(Of Integer?)("IdEstadoNovedad")
            .UsuarioAsignado = dr.Field(Of String)("UsuarioAsignado")
            .NombreAdjunto = dr.Field(Of String)("NombreAdjunto")
         End With
         Return result
      End Function

   End Class
End Namespace