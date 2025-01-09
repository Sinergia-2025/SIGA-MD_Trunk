Namespace JSonEntidades.Archivos
   Public Class RubroJSon
      Implements IValidable

      Public Property CuitEmpresa As String
      Public Property IdRubro As Integer
      Public Property NombreRubro As String
      Public Property IdProvincia As String
      Public Property IdActividad As Integer?
      Public Property ComisionPorVenta As Decimal
      Public Property UnidHasta1 As Decimal
      Public Property UnidHasta2 As Decimal
      Public Property UnidHasta3 As Decimal
      Public Property UnidHasta4 As Decimal
      Public Property UnidHasta5 As Decimal
      Public Property UHPorc1 As Decimal?
      Public Property UHPorc2 As Decimal?
      Public Property UHPorc3 As Decimal?
      Public Property UHPorc4 As Decimal?
      Public Property UHPorc5 As Decimal?
      Public Property Orden As Decimal
      Public Property FechaActualizacionWeb As String
      Public Property DescuentoRecargoPorc1 As Decimal
      Public Property DescuentoRecargoPorc2 As Decimal
      Public Property IdRubroTiendaNube As String
      Public Property IdRubroMercadoLibre As String
      Public Property CodigoExportacion As String

      Public Property IdRubroArborea As String

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen

   End Class

   Public Class RubroJSonTransporte
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