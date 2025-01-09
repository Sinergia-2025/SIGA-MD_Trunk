Public Interface IComprobanteModificable
   Property IdSucursalNuevo As Integer
   Property IdTipoComprobanteNuevo As String
   Property LetraNuevo As String
   Property CentroEmisorNuevo As Short
   Property NumeroComprobanteNuevo As Long

   ReadOnly Property DebeRenumerar As Boolean
   Sub LimpiaModificable()
End Interface
Public Interface IComprobanteComprasModificable
   Inherits IComprobanteModificable
   Property IdProveedorNuevo As Long
End Interface