Imports System.ComponentModel

Namespace JSonEntidades.Archivos
   Public Interface IValidable
      Property ConErrores As Boolean
      Property ___Estado As String
      Property ___MensajeError As String
      <Web.Script.Serialization.ScriptIgnore>
      Property drOrigen As DataRow

   End Interface
   Public Class MarcaJSon
      Implements IValidable

      Public Property CuitEmpresa As String
      Public Property IdMarca As Integer
      Public Property NombreMarca As String
      Public Property ComisionPorVenta As Decimal
      Public Property DescuentoRecargoPorc1 As Decimal
      Public Property DescuentoRecargoPorc2 As Decimal
      Public Property FechaActualizacionWeb As String

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

   Public Class MarcaJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdMarca As Integer
      Public Property DatosMarca As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idMarca As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdMarca = idMarca
         Me.FechaActualizacion = fechaActualizacion
      End Sub
   End Class

End Namespace