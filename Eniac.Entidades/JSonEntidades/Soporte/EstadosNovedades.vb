Namespace JSonEntidades.Soporte
   Public Class EstadosNovedades
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub
      Public Sub New(idEmpresa As Integer,
                     estado As CRMEstadoNovedad)
         Me.New(idEmpresa)
         Me.IdEstadoNovedad = estado.IdEstadoNovedad
         Me.IdTipoNovedad = estado.IdTipoNovedad
         Me.NombreEstadoNovedad = estado.NombreEstadoNovedad
         Me.Posicion = estado.Posicion
         Me.SolicitaUsuario = estado.SolicitaUsuario
         Me.Finalizado = estado.Finalizado
         Me.IdTipoNovedad = estado.IdTipoNovedad
         Me.PorDefecto = estado.PorDefecto
         Me.Color = estado.Color
         Me.DiasProximoContacto = estado.DiasProximoContacto
         Me.ActualizaUsuarioResponsable = estado.ActualizaUsuarioResponsable

      End Sub

      Public Property IdTipoNovedad As String
      Public Property IdEstadoNovedad As Integer
      Public Property NombreEstadoNovedad As String
      Public Property Posicion As Integer
      Public Property SolicitaUsuario As Boolean
      Public Property Finalizado As Boolean
      Public Property PorDefecto As Boolean
      Public Property Color As Integer?
      Public Property DiasProximoContacto As Integer?
      Public Property ActualizaUsuarioResponsable As Boolean

   End Class
End Namespace