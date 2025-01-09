<Serializable()> _
<System.ComponentModel.Description("CargoCliente")> _
Public Class CargoCliente
   Inherits Entidades.Entidad

   Public Enum Columnas
      IdCliente
      IdCargo
      IdSucursal
      PrecioLista
      DescuentoRecargoPorc1
      DescuentoRecargoPorc2 '-- Para el Futuro. Ya existe en la base
      DescuentoRecargoPorcGral
      Monto
      Cantidad
      Observacion
      IdTipoLiquidacion
      MontoSinIVA
   End Enum

   Public Property IdCliente As Long
   Public Property IdCargo As Integer
   Public Property IdTipoLiquidacion As Integer
   Public Property PrecioLista As Decimal
   Public Property DescuentoRecargoPorc1 As Decimal
   Public Property DescuentoRecargoPorcGral As Decimal
   Public Property Monto() As Decimal
   Public Property Cantidad() As Decimal
   Public Property Observacion As String

   Private _cargosClientesObservaciones As System.Collections.Generic.List(Of Entidades.CargoClienteObservacion)
   Public Property CargosClientesObservaciones() As Generic.List(Of Entidades.CargoClienteObservacion)
      Get
         If Me._cargosClientesObservaciones Is Nothing Then
            Me._cargosClientesObservaciones = New Generic.List(Of Entidades.CargoClienteObservacion)
         End If
         Return Me._cargosClientesObservaciones
      End Get
      Set(ByVal value As Generic.List(Of Entidades.CargoClienteObservacion))
         Me._cargosClientesObservaciones = value
      End Set
   End Property

End Class