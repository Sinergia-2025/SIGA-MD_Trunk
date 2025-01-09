Public Class CRMNovedadProductoNrosSerie
   Inherits CRMEntidad
   Public Const NombreTabla As String = "CRMNovedadesProductosNrosSerie"

   Public Enum Columnas
      idTipoNovedad
      IdNovedad
      LetraNovedad
      CentroEmisor
      IdProducto
      OrdenProducto
      NroSerie
      IdSucursal
      IdDeposito
      IdUbicacion

   End Enum

   Public Property IdNovedad As Long
   Public Property LetraNovedad As String
   Public Property CentroEmisor As Short
   Public Property IdSucursalNovedad As Integer?
   Public Property IdProducto As String
   Public Property OrdenProducto As Integer
   Public Property NroSerie As String
   Public Property IdSucursal As Integer
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer


End Class
