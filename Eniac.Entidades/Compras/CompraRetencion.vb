Public Class CompraRetencion
   Inherits Entidad
   Public Const NombreTabla As String = "ComprasRetenciones"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdProveedor
      IdRetencion

   End Enum

   Public Sub New()
      Retencion = New Retencion()
   End Sub

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property IdProveedor As Long
   Public Property Retencion As Retencion

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdRetencion As Integer
      Get
         Return Retencion.IdRetencion
      End Get
   End Property
#End Region

End Class