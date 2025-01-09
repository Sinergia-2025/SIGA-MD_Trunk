Namespace JSonEntidades.Archivos
   Public Class LocalidadJSon
      Implements IValidable

      Public Property CuitEmpresa As String
      Public Property IdLocalidad As Integer
      Public Property NombreLocalidad As String
      Public Property IdProvincia As String
      Public Property FechaActualizacionWeb As String

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError
      Public Property drOrigen As DataRow Implements IValidable.drOrigen
   End Class

   Public Class LocalidadJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdLocalidad As Integer
      Public Property DatosLocalidad As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, IdLocalidad As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdLocalidad = IdLocalidad
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace