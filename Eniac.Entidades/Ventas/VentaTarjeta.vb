Public Class VentaTarjeta
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdTarjeta
      Orden
      IdBanco
      Monto
      Cuotas
      NumeroLote
      NumeroCupon
   End Enum

#Region "Propiedades"
   Public Property Orden As Integer

   Private _tarjeta As Entidades.Tarjeta
   Public Property Tarjeta() As Entidades.Tarjeta
      Get
         If Me._tarjeta Is Nothing Then
            Me._tarjeta = New Entidades.Tarjeta()
         End If
         Return _tarjeta
      End Get
      Set(ByVal value As Entidades.Tarjeta)
         _tarjeta = value
      End Set
   End Property

   Private _banco As Entidades.Banco
   Public Property Banco() As Entidades.Banco
      Get
         If Me._banco Is Nothing Then
            Me._banco = New Entidades.Banco()
         End If
         Return _banco
      End Get
      Set(ByVal value As Entidades.Banco)
         _banco = value
      End Set
   End Property

   Private _monto As Decimal
   Public Property Monto() As Decimal
      Get
         Return _monto
      End Get
      Set(ByVal value As Decimal)
         _monto = value
      End Set
   End Property

   Private _cuotas As Integer
   Public Property Cuotas() As Integer
      Get
         Return _cuotas
      End Get
      Set(ByVal value As Integer)
         _cuotas = value
      End Set
   End Property
   Public Property NumeroLote() As Integer

   Private _numeroCupon As Integer
   Public Property NumeroCupon() As Integer
      Get
         Return _numeroCupon
      End Get
      Set(ByVal value As Integer)
         _numeroCupon = value
      End Set
   End Property
   Public ReadOnly Property NombreTarjeta() As String
      Get
         Return Me.Tarjeta.NombreTarjeta
      End Get
   End Property

   Public ReadOnly Property NombreBanco() As String
      Get
         Return Me.Banco.NombreBanco
      End Get
   End Property

   Public Property PorcentajeDelInteres() As Decimal
   Public Property MontoDelInteres() As Decimal

   Public Property IdTarjetaCupon() As Integer
#End Region

End Class
