Public Class MRPCentroProductorCategoriaEmpleado
   Inherits Entidad

   Public Const NombreTabla As String = "MRPCentrosProductoresCategoriasEmpleados"
   Public Enum Columnas
      IdCentroProductor
      IdCategoriaEmpleado
      CantidadCategoria
      ValorHoraCategoria
   End Enum

   Public Property IdCentroProductor As Integer
   Public Property IdCategoriaEmpleado As Integer
   Public Property CantidadCategoria As Decimal
   Public Property ValorHoraCategoria As Decimal

#Region "Propiedades no pertenecientes a la Entidad"
   Public Property NombreCategoriaEmpleado As String
#End Region

End Class
