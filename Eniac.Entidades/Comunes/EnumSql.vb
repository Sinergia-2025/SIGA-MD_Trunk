Imports System.ComponentModel

Public Class EnumSql
   Public Enum GetCoeficienteCobranzasModalidad
      <Description("Solo vencidos en el periodo")> SoloVencidos
      <Description("Cobrados en el periodo")> VencidosCobrados
   End Enum
   Public Enum InformeStock_OrdenadoPor
      <Description("Código")> Codigo
      <Description("Alfabético")> Alfabetico
      <Description("Por Marca")> Marca
      <Description("Por Rubro")> Rubro
      <Description("Por SubRubro"), Browsable(False)> SubRubro
   End Enum
   Public Enum InformeStock_MostrarPrecio
      <Description("Ninguno")> Ninguno
      <Description("Precio de Venta")> PrecioVenta
      <Description("Precio de Costo"), Browsable(False)> PrecioCosto
   End Enum
   Public Enum InformeStock_UnificadoPor
      <Description("Global")> [Global] = 0
      <Description("Empresa")> Empresa = 1
      <Description("Sucursal")> Sucursal = 2
      <Description("Depósito/Ubicación")> Ubicacion = 4
   End Enum
   Public Enum InformeStock_SucursalVinculada
      NoAplica = 0
      Principales = 1
      Secundarias = 2
   End Enum

   Public Enum Stock_TipoReporte
      <Description("General")> General
      <Description("Mayor ó Igual a Cero ( >= 0 )")> MayorIgualCero
      <Description("Mayor a Cero ( > 0 )")> MayorCero
      <Description("Igual a Cero ( = 0 )")> IgualCero
      <Description("Negativo ( < 0 )")> Negativo
   End Enum

End Class