Imports System.ComponentModel

Namespace JSonEntidades.Archivos.CRM
   Public Class CRMNovedadSeguimientoJSon
      Implements IValidable

      Public Property IdTipoNovedad As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property IdNovedad As Long
      Public Property IdSeguimiento As Integer
      Public Property IdUnico As String

      Public Property FechaSeguimiento As String
      Public Property Comentario As String
      Public Property Interlocutor As String
      Public Property EsComentario As Boolean
      Public Property IdTipoComentarioNovedad As Integer?
      Public Property ComentarioPrincipal As Boolean
      Public Property Activo As Boolean
      Public Property IdUsuarioSeguimiento As String
      Public Property IdUsuarioAsignado As String
      Public Property IdEstadoNovedad As Integer

      Public Property FechaActualizacionWeb As String


      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen
   End Class

   Public Class CRMNovedadSeguimientoJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdUnico As String
      Public Property Datos As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idUnico As String, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdUnico = idUnico
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace