Namespace JSonEntidades.CobranzasMovil
   Public Class CuentasCorrientes
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property NumeroComprobante As Long
      Public Property CuotaNumero As Integer
      Public Property DescripcionAbrevTipoComp As String
      Public Property Fecha As DateTime
      Public Property FechaVencimiento As DateTime
      Public Property ImporteCuota As Decimal
      Public Property SaldoCuota As Decimal
      Public Property NombrePrimerProducto As String
      Public Property IdCliente As Long
   End Class
End Namespace