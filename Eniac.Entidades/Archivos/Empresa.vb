Public Class Empresa
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "Empresas"
   Public Enum Columnas
      IdEmpresa
      NombreEmpresa
      CuitEmpresa
   End Enum

   Public Property IdEmpresa As Integer
   Public Property NombreEmpresa As String
   Public Property CuitEmpresa As String
   Public Property IdCategoriaFiscal As Short ' no persiste
   Public Property NombreCategoriaFiscal As String ' no persiste
End Class