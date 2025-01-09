Public Class VentaClienteContacto
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdCliente
      IdContacto
   End Enum

   Public Sub New()
   End Sub
   Public Sub New(contacto As Entidades.ClienteContacto)
      Me.New()
      Me.Contacto = contacto
   End Sub

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroComprobante As Long

   Public Property Contacto As Entidades.ClienteContacto

#Region "Propiedades Readonly"
   Public ReadOnly Property IdCliente As Long
      Get
         If Contacto Is Nothing Then Return 0
         Return Contacto.IdCliente
      End Get
   End Property
   Public ReadOnly Property IdContacto As Integer
      Get
         If Contacto Is Nothing Then Return 0
         Return Contacto.IdContacto
      End Get
   End Property
#End Region

End Class