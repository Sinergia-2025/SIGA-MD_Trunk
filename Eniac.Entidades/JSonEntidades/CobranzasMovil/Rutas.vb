Namespace JSonEntidades.CobranzasMovil
   Public Class Rutas
      Public Sub New()
      End Sub
      Public Sub New(idEmpresa As Integer)
         Me.New()
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdRuta As Integer
      Public Property NombreRuta As String
      Public Property IdDispositivoPorDefecto As String
      Public Property PuedeModificarPrecios As Boolean
      Public Property PermiteIngresarPorcentajeDescuentos As Boolean
      Public Property PermiteCobroParcial As Boolean

      Public Property EsDeCobranza As Boolean
      Public Property EsDePedidos As Boolean
      Public Property EsDeGestion As Boolean

      Public Property IdUsuario As String

      Public Overrides Function ToString() As String
         Return String.Format("{0,6} - {1}", IdRuta, NombreRuta)
      End Function
   End Class
End Namespace