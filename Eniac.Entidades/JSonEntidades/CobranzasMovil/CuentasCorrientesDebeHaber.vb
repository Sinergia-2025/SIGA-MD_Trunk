Namespace JSonEntidades.CobranzasMovil
   Public Class CuentasCorrientesDebeHaber
      Public Sub New(idEmpresa As Integer, ejecucion As Entidades.JSonEntidades.CobranzasMovil.Temp_Ejecuciones)
         Me.New(idEmpresa, If(ejecucion Is Nothing, Guid.Empty, ejecucion.IdEjecucion_Temp))
      End Sub
      Private Sub New(idEmpresa As Integer, idEjecucion_Temp As Guid)
         Me.IdEmpresa = idEmpresa
         Me.IdEjecucion_Temp = idEjecucion_Temp
         Pagos = New List(Of CuentasCorrientesPagos)()
      End Sub
      Public Property IdEjecucion_Temp As Guid
      Public Property IdEmpresa As Integer
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroComprobante As Long
      Public Property CuotaNumero As Integer
      Public Property DescripcionAbrevTipoComp As String
      Public Property IdCliente As Long
      Public Property CodigoCliente As Long
      Public Property NombreCliente As String
      Public Property Fecha As String
      Public Property FechaVencimiento As String
      Public Property ImporteCuota As Decimal
      Public Property SaldoCuota As Decimal
      Public Property Debe As Decimal
      Public Property Haber As Decimal
      Public Property IdFormasPago As Integer
      Public Property DescripcionFormasPago As String
      Public Property Dias As Integer
      Public Property Observacion As String
      Public Property GrabaLibro As Boolean
      Public Property NombreProductos As String
      Public Property EsSaldoInicial As Boolean
      Public Property DescripcionTipoComp As String
      Public Property CuitEmisor As String

      Public Property Pagos As List(Of CuentasCorrientesPagos)
   End Class

   Public Class CuentasCorrientesPagos
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Integer
      Public Property NumeroComprobante As Long
      Public Property CuotaNumero As Integer
      Public Property Fecha As String
      Public Property FechaVencimiento As String
      Public Property ImporteCuota As Decimal
      Public Property SaldoCuota As Decimal

   End Class

End Namespace