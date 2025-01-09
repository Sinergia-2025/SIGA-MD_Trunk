Public Class VentaExportacionEmbarques
   Inherits Entidad

   Public Const NombreTabla As String = "VentasExportacionEmbarque"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      LetraComprobante
      CentroEmisor
      NumeroComprobante
      IdPermisoEmbarque
      IdDestinoDespacho
   End Enum

   Public Sub New()
   End Sub

   Public Property IdTipoComprobante As String
   Public Property LetraComprobante As String
   Public Property CentroEmisor As Short
   Public Property NumeroComprobante As Long
   Public Property IdPermisoEmbarque As String
   Public Property IdDestinoDespacho As String


End Class
