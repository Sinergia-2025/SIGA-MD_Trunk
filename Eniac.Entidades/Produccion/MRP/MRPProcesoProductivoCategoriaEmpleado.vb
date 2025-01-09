Public Class MRPProcesoProductivoCategoriaEmpleado
   Inherits Entidad

   Public Const NombreTabla As String = "MRPProcesosProductivosCategoriasEmpleados"
   Public Enum Columnas
      IdOperacion
      IdProcesoProductivo
      IdCategoriaEmpleado
      CantidadCategoria
      ValorHoraCategoria
   End Enum

   Public Property IdOperacion As Integer
   Public Property IdProcesoProductivo As Long
   Public Property IdCategoriaEmpleado As Integer
   Public Property CantidadCategoria As Decimal
   Public Property ValorHoraCategoria As Decimal

#Region "Propiedades no pertenecientes a la Entidad"
   Public Property CodigoProcProdOperacion As String
   Public Property NombreCategoriaEmpleado As String
   Public Property NewValorHoraCategoria As Decimal
#End Region

End Class
