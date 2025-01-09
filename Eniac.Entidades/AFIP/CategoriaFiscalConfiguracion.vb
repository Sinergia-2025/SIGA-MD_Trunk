Public Class CategoriaFiscalConfiguracion
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "CategoriasFiscalesConfiguraciones"
   Public Enum Columnas
      IdCategoriaFiscalEmpresa
      IdCategoriaFiscalCliente
      LetraFiscal
      LetraFiscalCompra
      IvaDiscriminado

   End Enum

   Public Property IdCategoriaFiscalEmpresa As Short
   Public Property IdCategoriaFiscalCliente As Short
   Public Property LetraFiscal As String
   Public Property LetraFiscalCompra As String
   Public Property IvaDiscriminado As Boolean

End Class