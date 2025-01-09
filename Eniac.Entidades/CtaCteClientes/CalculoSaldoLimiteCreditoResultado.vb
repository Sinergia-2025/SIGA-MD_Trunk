Public Class CalculoSaldoLimiteCreditoResultado

   Private Property Cliente As ClienteLiviano
   Public Property SaldoLimiteCreditoContemplaPedidos As Boolean
   Public Property SaldoLimiteCreditoContemplaAnticipos As Boolean
   Public Property SituacionCrediticia As Decimal
   Public Property LimiteDeCreditoNuevo As Decimal

   Public ReadOnly Property IdCliente As Long?
      Get
         If Cliente Is Nothing Then Return Nothing
         Return Cliente.IdCliente
      End Get
   End Property
   Public ReadOnly Property CodigoCliente As Long?
      Get
         If Cliente Is Nothing Then Return Nothing
         Return Cliente.CodigoCliente
      End Get
   End Property
   Public ReadOnly Property NombreCliente As String
      Get
         If Cliente Is Nothing Then Return String.Empty
         Return Cliente.NombreCliente
      End Get
   End Property
   Public ReadOnly Property LimiteDeCredito As Decimal
      Get
         If Cliente Is Nothing Then Return 0D
         Return Cliente.LimiteDeCredito
      End Get
   End Property
   Public ReadOnly Property SaldoLimiteDeCreditoActual As Decimal
      Get
         If Cliente Is Nothing Then Return 0D
         Return Cliente.SaldoLimiteDeCredito
      End Get
   End Property

   Public ReadOnly Property SaldoLimiteDeCreditoNuevo As Decimal
      Get
         Return LimiteDeCreditoNuevo - SituacionCrediticia
      End Get
   End Property

   Public Sub New(cliente As ClienteLiviano, saldoLimiteCreditoContemplaPedidos As Boolean, saldoLimiteCreditoContemplaAnticipos As Boolean)
      If cliente Is Nothing Then
         Throw New ArgumentNullException(NameOf(cliente))
      End If
      Me.Cliente = cliente
      Me.SaldoLimiteCreditoContemplaPedidos = saldoLimiteCreditoContemplaPedidos
      Me.SaldoLimiteCreditoContemplaAnticipos = saldoLimiteCreditoContemplaAnticipos
      SituacionCrediticia = 0D
      LimiteDeCreditoNuevo = 0D
   End Sub

End Class