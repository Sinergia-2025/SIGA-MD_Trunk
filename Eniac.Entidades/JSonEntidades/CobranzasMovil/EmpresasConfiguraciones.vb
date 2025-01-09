Namespace JSonEntidades.CobranzasMovil
   Public Class EmpresasConfiguraciones
      Public Sub New(idEmpresa As Integer)
         Me.IdEmpresa = idEmpresa
      End Sub
      Public Property IdEmpresa As Integer
      Public Property CorreoElectrinico1 As String
      Public Property CorreoElectrinico2 As String
      Public Property CorreoElectrinico3 As String
      Public Property BusquedaCliente As String
      Public Property OrdenProducto As String
      Public Property FechaExportacion As Boolean
      Public Property SolicitaCierre As Boolean
      Public Property OcultarEnvioMail As Boolean
      Public Property PlazoEntregaPorDefecto As Integer
      Public Property PorcMaxDescuento As Decimal
      Public Property PorcMaxRecargo As Decimal
      Public Property EnviaMailCliente As Boolean
      Public Property EnviaMailEmpresa As Boolean
      Public Property OcultarResumenPromedio As Boolean
      Public Property PlazoEntregaPedido As Boolean
      Public Property PlazoEntregaLinea As Boolean
      Public Property PuedeModificarPrecio As Boolean
      Public Property SolicitaTipoComprobante As Boolean
   End Class

   Public Enum BusquedaClientes
      <Description("Por Nombre")> nombre
      <Description("Por Dirección")> direccion
   End Enum
   Public Enum OrdenarProductos
      <Description("Por Descripción")> descripcion
      <Description("Por Código")> codigo
   End Enum
   Public Enum SucursalesSincronizar
      <Description("Todas")> TODAS
      <Description("Empresa actual")> EMPRESAS
      <Description("Sucursal actual")> SUCURSAL
   End Enum

End Namespace