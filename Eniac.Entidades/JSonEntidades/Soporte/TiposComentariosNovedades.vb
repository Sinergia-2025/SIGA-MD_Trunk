Namespace JSonEntidades.Soporte
   Public Class TiposComentariosNovedades
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub
      Public Sub New(idEmpresa As Integer,
                     estado As CRMTipoComentarioNovedad)
         Me.New(idEmpresa)
         Me.IdTipoNovedad = estado.IdTipoNovedad
         Me.IdTipoComentarioNovedad = estado.IdTipoComentarioNovedad
         Me.NombreTipoComentarioNovedad = estado.NombreTipoComentarioNovedad
         Me.Posicion = estado.Posicion
         Me.PorDefecto = estado.PorDefecto
         Me.Color = estado.Color
         Me.VisibleParaCliente = estado.VisibleParaCliente
         Me.VisibleParaRepresentante = estado.VisibleParaRepresentante

      End Sub

      Public Property IdTipoNovedad As String
      Public Property IdTipoComentarioNovedad As Integer
      Public Property NombreTipoComentarioNovedad As String
      Public Property Posicion As Integer
      Public Property PorDefecto As Boolean
      Public Property Color As Integer?
      Public Property VisibleParaCliente As Boolean
      Public Property VisibleParaRepresentante As Boolean

   End Class
End Namespace