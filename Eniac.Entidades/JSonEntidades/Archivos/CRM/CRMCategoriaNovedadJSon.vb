Imports System.ComponentModel

Namespace JSonEntidades.Archivos.CRM
   Public Class CRMCategoriaNovedadJSon
      Inherits Entidades.CRMCategoriaNovedad
      Implements IValidable

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen
   End Class

   Public Class CRMCategoriaNovedadJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdCategoriaNovedad As Integer
      Public Property Datos As String
      Public Property FechaActualizacion As String
      Public Property IdTipoCategoriaNovedad As Integer

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idCategoriaNovedad As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdCategoriaNovedad = idCategoriaNovedad
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace