Imports System.ComponentModel

Namespace JSonEntidades.Archivos

   Public Class RubroCompraJson
      Implements IValidable

      Public Property CuitEmpresa As String
      Public Property IdRubro As Integer
      Public Property NombreRubro As String

      Public Property FechaActualizacion As String

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError
      Public Property drOrigen As DataRow Implements IValidable.drOrigen

      Public Sub New()
         ConErrores = False
         ___Estado = ""
         ___MensajeError = ""
      End Sub


   End Class

   Public Class RubroCompraJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdRubro As Integer
      Public Property DatosRubro As String

      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, IdRubro As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdRubro = IdRubro
         Me.FechaActualizacion = fechaActualizacion
      End Sub
   End Class

End Namespace
