Namespace JSonEntidades.CobranzasMovil
   Public Class Cobranzas
      Public Sub New()
         EstadoImportacion = EstadosImportacion.Pendiente
      End Sub
      Public Property IdEmpresa As Integer
      Public Property IdDispositivo As String
      Public Property IdSucursal As Integer
      Public Property IdTipoComprobante As String
      Public Property Letra As String
      Public Property CentroEmisor As Short
      Public Property NumeroComprobante As Long
      Public Property CuotaNumero As Integer
      Public Property FechaRecepcionWeb As Date
      Public Property SaldoCuota As Decimal
      Public Property ImportePesos As Decimal
      Public Property FechaCobro As Date
      Public Property IdCliente As Long
      Public Property CodigoCliente As Long
      Public Property NombreCliente As String
      Public Property Observaciones As String
      Public Property FechaEnvioWeb As Date
      Public Property FechaDescargaSiga As Date?
      Public Property FechaProcesoSiga As Date?
      Public Property Procesado As Boolean
      Public Property IdUnicoCobranzas As Guid
      Public Property IdUsuario As String

#Region "Propiedades para pantalla y proceso de importación"
      <ScriptIgnore()> Public Property Cobrador As Entidades.Empleado
      <ScriptIgnore()> Public ReadOnly Property NombreCobrador As String
         Get
            If Cobrador Is Nothing Then Return ""
            Return Cobrador.NombreEmpleado
         End Get
      End Property

      <ScriptIgnore()> Public Property Caja As Entidades.CajaNombre
      <ScriptIgnore()> Public ReadOnly Property NombreCaja As String
         Get
            If Caja Is Nothing Then Return ""
            Return Caja.NombreCaja
         End Get
      End Property

      <ScriptIgnore()> Public Property TipoComprobanteRecibo As Entidades.TipoComprobante
      <ScriptIgnore()> Public ReadOnly Property IdTipoComprobanteRecibo As String
         Get
            If TipoComprobanteRecibo Is Nothing Then Return ""
            Return TipoComprobanteRecibo.IdTipoComprobante
         End Get
      End Property

      <ScriptIgnore()> Public Property EstadoImportacion As EstadosImportacion
      <ScriptIgnore()> Public Property MensajeError As String
      Public Enum EstadosImportacion
         Pendiente = 0
         Advertencia = 1
         [Error] = 2
         Procesado = 3
      End Enum
#End Region
   End Class
End Namespace