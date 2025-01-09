Imports System.ComponentModel

Namespace JSonEntidades.Archivos.CRM
   Public Class CRMTipoComentarioNovedadJSon
      Inherits Entidades.CRMTipoComentarioNovedad
      Implements IValidable

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen
   End Class

   Public Class CRMTipoComentarioNovedadJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdTipoComentarioNovedad As Integer
      Public Property Datos As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idTipoComentarioNovedad As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdTipoComentarioNovedad = idTipoComentarioNovedad
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace