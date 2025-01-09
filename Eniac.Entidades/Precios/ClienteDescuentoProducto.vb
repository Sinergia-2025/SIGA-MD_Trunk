Public Class ClienteDescuentoProducto
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdCliente
      IdProducto
      DescuentoRecargoPorc1
      DescuentoRecargoPorc2
   End Enum

   Private _idCliente As Long
   Public Property IdCliente() As Long
      Get
         Return _idCliente
      End Get
      Set(ByVal value As Long)
         _idCliente = value
      End Set
   End Property

   Private _idProducto As String
   Public Property IdProducto() As String
      Get
         Return _idProducto
      End Get
      Set(ByVal value As String)
         _idProducto = value
      End Set
   End Property

   Private _descuentoRecargoPorc1 As Decimal
   Public Property DescuentoRecargoPorc1() As Decimal
      Get
         Return _descuentoRecargoPorc1
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc1 = value
      End Set
   End Property

   Private _descuentoRecargoPorc2 As Decimal
   Public Property DescuentoRecargoPorc2() As Decimal
      Get
         Return _descuentoRecargoPorc2
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargoPorc2 = value
      End Set
   End Property



End Class
