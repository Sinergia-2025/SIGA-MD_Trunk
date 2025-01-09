Public Class MRPCentroProductor
   Inherits Entidad

   Public Const NombreTabla As String = "MRPCentrosProductores"

   Public Enum Columnas
      IdCentroProductor
      CodigoCentroProductor
      Descripcion
      IdSeccion
      ClaseCentroProductor
      Dotacion
      HorasLunes
      HorasMartes
      HorasMiercoles
      HorasJueves
      HorasViernes
      HorasSabado
      HorasDomingo

      TiempoPAP
      TiempoProductivo
      TiempoNoProductivo

      HorasHombrePAP
      HorasHombreProductivo
      HorasHombreNoProductivo

      Activo
      IdProveedor
      IdNormaFabricacion

      MantenimientoAutonomo
      CantidadControles

   End Enum

   Public Property IdCentroProductor As Integer
   Public Property CodigoCentroProductor As String
   Public Property Descripcion As String
   Public Property IdSeccion As Integer
   Public Property ClaseCentroProductor As ClaseCentrosProd
   Public Property Dotacion As Integer
   Public Property HorasLunes As Decimal
   Public Property HorasMartes As Decimal
   Public Property HorasMiercoles As Decimal
   Public Property HorasJueves As Decimal
   Public Property HorasViernes As Decimal
   Public Property HorasSabado As Decimal
   Public Property HorasDomingo As Decimal

   Public Property TiempoPAP As Decimal
   Public Property TiempoProductivo As Decimal
   Public Property TiempoNoProductivo As Decimal

   Public Property HorasHombrePAP As Decimal
   Public Property HorasHombreProductivo As Decimal
   Public Property HorasHombreNoProductivo As Decimal
   Public Property CantidadLoteOptimo As Decimal
   Public Property IdProveedor As Long
   Public Property IdNormaFabricacion As Integer
   Public Property Activo As Boolean
   Public Property MantenimientoAutonomo As Boolean
   Public Property CantidadControles As Integer

   Public Property CategoriasEmpleados As ListConBorrados(Of MRPCentroProductorCategoriaEmpleado)
   Public Sub New()
      IdCentroProductor = 0
      CodigoCentroProductor = String.Empty
      Descripcion = String.Empty
      IdSeccion = 0
      ClaseCentroProductor = ClaseCentrosProd.INT
      Dotacion = 0
      CantidadControles = 0
      Activo = True

      CategoriasEmpleados = New ListConBorrados(Of MRPCentroProductorCategoriaEmpleado)()
   End Sub

   Public Enum ClaseCentrosProd
      <Description("INTERNO")> INT
      <Description("EXTERNO")> EXT
   End Enum

End Class
