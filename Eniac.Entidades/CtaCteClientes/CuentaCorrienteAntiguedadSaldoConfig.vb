Public Class CuentaCorrienteAntiguedadSaldoConfig
   Inherits Entidad

   Public Const NombreTabla As String = "CuentasCorrientesAntiguedadesSaldosConfig"
   Public Enum Columnas
      IdAntiguedadSaldoConfig
      NombreAntiguedadSaldoConfig
      TipoAntiguedadSaldoConfig
      PorDefecto
   End Enum

   Public Sub New()
      Rangos = New List(Of CuentaCorrienteAntiguedadSaldoRangos)()
   End Sub

   Public Property IdAntiguedadSaldoConfig As Integer
   Public Property NombreAntiguedadSaldoConfig As String
   Public Property TipoAntiguedadSaldoConfig As TipoAntiguedadSaldo
   Public Property PorDefecto As Boolean
   Public Property Rangos As List(Of CuentaCorrienteAntiguedadSaldoRangos)

   Public Enum FechasInforme
      <Description("Fecha Emisión")> Fecha
      <Description("Fecha Vencimiento")> FechaVencimiento
   End Enum

   Public Enum TipoAntiguedadSaldo
      <Description("Clientes")> AntiguedadSaldosClientes
      <Description("Proveedores")> AntiguedadSaldosProveedores
   End Enum

End Class