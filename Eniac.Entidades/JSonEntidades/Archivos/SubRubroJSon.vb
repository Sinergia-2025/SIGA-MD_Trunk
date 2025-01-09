Namespace JSonEntidades.Archivos
   Public Class SubRubroJSon
      Implements IValidable

      Public Property CuitEmpresa As String
      Public Property IdSubRubro As Integer
      Public Property NombreSubRubro As String
      Public Property DescuentoRecargoPorc1 As Decimal
      Public Property IdRubro As Integer
      Public Property UnidHasta1 As Decimal
      Public Property UnidHasta2 As Decimal
      Public Property UnidHasta3 As Decimal
      Public Property UnidHasta4 As Decimal
      Public Property UnidHasta5 As Decimal
      Public Property UHPorc1 As Decimal
      Public Property UHPorc2 As Decimal
      Public Property UHPorc3 As Decimal
      Public Property UHPorc4 As Decimal
      Public Property UHPorc5 As Decimal
      Public Property IdSubRubroTiendaNube As String
      Public Property IdSubRubroMercadoLibre As String
      Public Property IdSubRubroArborea As String

      Public Property FechaActualizacionWeb As String
      Public Property DescuentoRecargoPorc2 As Decimal
      Public Property CodigoExportacion As String

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError
      Public Property drOrigen As DataRow Implements IValidable.drOrigen

   End Class

   Public Class SubRubroJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdSubRubro As Integer
      Public Property DatosSubRubro As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, IdSubRubro As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdSubRubro = IdSubRubro
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace