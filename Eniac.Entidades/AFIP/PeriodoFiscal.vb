<Serializable()>
Public Class PeriodoFiscal
   Inherits Entidad

   Public Const NombreTabla As String = "PeriodosFiscales"

   Public Enum Columnas
      IdEmpresa
      PeriodoFiscal
      TotalNetoVentas
      TotalImpuestosVentas
      TotalVentas
      TotalNetoCompras
      TotalImpuestosCompras
      TotalCompras
      Posicion
      TotalRetenciones
      TotalPercepciones
      PosicionFinal
      FechaCierre
      UsuarioCierre
      VentasHabilitadas
   End Enum

   Public Sub New()
      IdEmpresa = actual.Sucursal.IdEmpresa
   End Sub
   Public Sub New(ventasHabilitadas As Boolean)
      Me.New()
      Me.VentasHabilitadas = ventasHabilitadas
   End Sub

#Region "Propiedades"
   Public Property IdEmpresa As Integer
   Public Property PeriodoFiscal As Integer
   Public Property TotalNetoVentas As Decimal
   Public Property TotalImpuestosVentas As Decimal
   Public Property TotalVentas As Decimal
   Public Property TotalNetoCompras As Decimal
   Public Property TotalImpuestosCompras As Decimal
   Public Property TotalCompras As Decimal
   Public Property Posicion As Decimal
   Public Property TotalRetenciones As Decimal
   Public Property TotalPercepciones As Decimal
   Public Property PosicionFinal As Decimal
   Public Property FechaCierre As Date
   Public Property UsuarioCierre As String
   Public Property VentasHabilitadas As Boolean
#End Region

End Class