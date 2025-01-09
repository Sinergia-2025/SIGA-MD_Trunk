<Serializable()> _
Public Class Concepto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdConcepto
      NombreConcepto
      IdRubroConcepto
      NombreRubroConcepto
      GrupoGastos
      EsNoGravado
      ImprimeProveedor
      ImprimeDetalleComprobante
      Activo
      IdProducto
   End Enum

   Public Property IdConcepto() As Integer
   Public Property NombreConcepto() As String
   Public Property IdRubroConcepto() As Integer
   Public Property GrupoGastos() As String
   Public Property EsNoGravado() As Boolean
   Public Property ImprimeProveedor() As Boolean
   Public Property ImprimeDetalleComprobante As Boolean
   Public Property Activo() As Boolean
   Public Property IdProducto As String
End Class