Partial Class Venta
   Implements IVentaInvocada

#Region "IVentaInvocada"
   Private ReadOnly Property IVentaInvocada_Letra As String Implements IVentaInvocada.Letra
      Get
         Return LetraComprobante
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_IdSucursal As Integer Implements IVentaInvocada.IdSucursal
      Get
         Return IdSucursal
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_IdTipoComprobante As String Implements IVentaInvocada.IdTipoComprobante
      Get
         Return IdTipoComprobante
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_CentroEmisor As Integer Implements IVentaInvocada.CentroEmisor
      Get
         Return CentroEmisor
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_NumeroComprobante As Long Implements IVentaInvocada.NumeroComprobante
      Get
         Return NumeroComprobante
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_Cuit As String Implements IVentaInvocada.Cuit
      Get
         Return Cuit
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_Fecha As Date Implements IVentaInvocada.Fecha
      Get
         Return Fecha
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_TipoTipoComprobante As String Implements IVentaInvocada.TipoTipoComprobante
      Get
         Return TipoComprobante.Tipo
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_CoeficienteStock As Integer Implements IVentaInvocada.CoeficienteStock
      Get
         Return TipoComprobante.CoeficienteStock
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_DescripcionTipoComprobante As String Implements IVentaInvocada.DescripcionTipoComprobante
      Get
         Return TipoComprobante.Descripcion
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_IdProveedor As Long? Implements IVentaInvocada.IdProveedor
      Get
         Return If(Proveedor IsNot Nothing, Proveedor.IdProveedor, 0L)
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_IdTipoComprobanteContraMovInvocar As String Implements IVentaInvocada.IdTipoComprobanteContraMovInvocar
      Get
         Return TipoComprobante.IdTipoComprobanteContraMovInvocar
      End Get
   End Property

   Private ReadOnly Property IVentaInvocada_IdCliente As Long Implements IVentaInvocada.IdCliente
      Get
         Return IdCliente
      End Get
   End Property

#End Region

End Class