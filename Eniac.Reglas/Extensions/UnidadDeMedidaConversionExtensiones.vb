Imports System.Runtime.CompilerServices

Public Module UnidadDeMedidaConversionExtensiones
   <Extension()>
   Public Function GetInvertida(um As Entidades.UnidadDeMedidaConversion) As Entidades.UnidadDeMedidaConversion
      Return New Entidades.UnidadDeMedidaConversion() With {
               .IdUnidadMedidaDesde = um.IdUnidadMedidaHacia,
               .IdUnidadMedidaHacia = um.IdUnidadMedidaDesde,
               .FactorConversion = 1 / um.FactorConversion,
               .Fija = um.Fija
            }
   End Function
End Module