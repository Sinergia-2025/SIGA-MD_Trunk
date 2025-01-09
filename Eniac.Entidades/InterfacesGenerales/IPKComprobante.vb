Public Interface IPKComprobante
   ReadOnly Property IdSucursal As Integer
   ReadOnly Property IdTipoComprobante As String
   ReadOnly Property Letra As String
   ReadOnly Property CentroEmisor As Integer
   ReadOnly Property NumeroComprobante As Long

End Interface
Public Structure PKComprobante
   Implements IPKComprobante

   Public ReadOnly Property IdSucursal As Integer Implements IPKComprobante.IdSucursal
   Public ReadOnly Property IdTipoComprobante As String Implements IPKComprobante.IdTipoComprobante
   Public ReadOnly Property Letra As String Implements IPKComprobante.Letra
   Public ReadOnly Property CentroEmisor As Integer Implements IPKComprobante.CentroEmisor
   Public ReadOnly Property NumeroComprobante As Long Implements IPKComprobante.NumeroComprobante

   Public Sub New(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Me.IdSucursal = idSucursal
      Me.IdTipoComprobante = idTipoComprobante
      Me.Letra = letra
      Me.CentroEmisor = centroEmisor
      Me.NumeroComprobante = numeroComprobante
   End Sub

   Public Sub New(v As Venta)
      Me.New(v.IdSucursal, v.IdTipoComprobante, v.LetraComprobante, v.CentroEmisor, v.NumeroComprobante)
   End Sub

End Structure