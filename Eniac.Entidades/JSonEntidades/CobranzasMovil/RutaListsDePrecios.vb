Namespace JSonEntidades.CobranzasMovil
   Public Class RutasListasDePrecios
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdRuta As Integer
      Public Property IdListaPrecios As Integer
      Public Property PorDefecto As Boolean
   End Class
End Namespace