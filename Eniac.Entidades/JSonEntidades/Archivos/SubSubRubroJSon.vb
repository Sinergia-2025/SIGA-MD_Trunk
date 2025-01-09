Namespace JSonEntidades.Archivos
   Public Class SubSubRubroJSon
      Implements IValidable

      Public Property CuitEmpresa As String
      Public Property IdSubSubRubro As Integer
      Public Property NombreSubSubRubro As String
      Public Property IdSubRubro As Integer
      Public Property FechaActualizacionWeb As String
      Public Property IdSubSubRubroTiendaNube As String
      Public Property IdSubSubRubroMercadoLibre As String
      Public Property IdSubSubRubroArborea As String

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError
      Public Property drOrigen As DataRow Implements IValidable.drOrigen

   End Class

   Public Class SubSubRubroJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdSubSubRubro As Integer
      Public Property DatosSubSubRubro As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, IdSubSubRubro As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdSubSubRubro = IdSubSubRubro
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class
End Namespace