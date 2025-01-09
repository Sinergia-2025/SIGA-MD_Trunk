Public Class MRPTarea
   Inherits Entidad

   Public Const NombreTabla As String = "MRPTareas"

   Public Enum Columnas
      IdTarea
      CodigoTarea
      Descripcion
      IdCentroProductor
      Activo
   End Enum
   Public Sub New()
      IdTarea = 0
      CodigoTarea = String.Empty
      Descripcion = String.Empty
      IdCentroProductor = 0
      Activo = True
   End Sub

   Public Property IdTarea As Integer
   Public Property CodigoTarea As String
   Public Property Descripcion As String
   Public Property IdCentroProductor As Integer
   Public Property Activo As Boolean

#Region "Propiedades no pertenecientes a la Entidad"
   Public Property NombreCentroProductor As String
#End Region

End Class
