Public Class CuentaCorrienteAntiguedadSaldoRangos
   Inherits Entidad

   Public Const NombreTabla As String = "CuentasCorrientesAntiguedadesSaldosRangos"
   Public Enum Columnas
      IdAntiguedadSaldoConfig
      DiasDesde
      DiasHasta
      EtiquetaColumna
      Orden

   End Enum
   Public Property IdAntiguedadSaldoConfig As Integer
   Public Property DiasDesde As Integer
   Public Property DiasHasta As Integer
   Public Property EtiquetaColumna As String
   Public Property Orden As Integer
End Class