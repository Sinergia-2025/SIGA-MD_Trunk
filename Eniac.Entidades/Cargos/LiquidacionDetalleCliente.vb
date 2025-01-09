Public Class LiquidacionDetalleCliente
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      PeriodoLiquidacion
      IdLiquidacionDetalleCliente
      IdCliente
      IdCargo
      CodigoCliente
      NombreCliente
      IdCategoria
      NombreCategoria
      NombreCargo
      Importe
      ImporteAlquiler
      CantidadAdicional
      PrecioLista
      PrecioListaSinIVA
      DescuentoRecargoPorc1
      'DescuentoRecargoPorc2 -- Para el Futuro
      DescuentoRecargoPorcGral
      PrecioAdicional
      IdSucursal
      IdLiquidacionCargo
      Observacion
      IdTipoLiquidacion
   End Enum
End Class