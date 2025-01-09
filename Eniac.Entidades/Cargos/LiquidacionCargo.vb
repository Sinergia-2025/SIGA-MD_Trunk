<Serializable()> _
Public Class LiquidacionCargo
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdLiquidacionCargo
      PeriodoLiquidacion
      IdEmbarcacion
      IdCliente
      CantAcciones
      FechaFirmaMandato
      ImporteExpensas
      ImporteServicios
      ImporteExpensaAdicionalEslora
      ImporteExpensaAdicionalAlturaTotal
      ImporteGastosAdmin
      ImporteVarios
      ImporteAlquiler
      ImporteGastosIntermAlq
      ImporteTotal
      PrimerVto
      ImportePrimerVto
      SegundoVto
      ImporteSegundoVto
      SaldoAnterior
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      ImporteAlquilerExpensas
      IdGrupoCama
      TipoLiquidacion
      Selecciono
   End Enum

#Region "Propiedades"


   Public Property IdLiquidacionCargo() As Integer
   Public Property PeriodoLiquidacion() As String

   Private _cliente As Entidades.Cliente

   Public Property Cliente() As Entidades.Cliente
      Get
         If Me._cliente Is Nothing Then
            Me._cliente = New Entidades.Cliente()
         End If
         Return _cliente
      End Get
      Set(ByVal value As Entidades.Cliente)
         _cliente = value
      End Set
   End Property


   Public Property CantAcciones() As Integer
   Public Property FechaFirmaMandato() As Date
   Public Property ImporteExpensas() As Decimal
   Public Property ImporteServicios() As Decimal
   Public Property ImporteGastosAdmin() As Decimal
   Public Property ImporteAlquiler() As Decimal
   Public Property ImporteGastosIntermAlq() As Decimal
   Public Property ImporteTotal() As Decimal
   Public Property PrimerVto() As Date
   Public Property ImportePrimerVto() As Decimal
   Public Property SegundoVto() As Date
   Public Property ImporteSegundoVto() As Decimal
   Public Property saldoAnterior() As Decimal
   Public Property ImporteAlquilerExpensas() As Decimal
   Public Property IdGrupoCama() As Integer
   Public Property TipoLiquidacion() As String
   Public Property Selecciono As String

#End Region

#Region "Propiedades ReadOnly"


   Public ReadOnly Property ImporteVarios() As Decimal
      Get
         Return Me._importeTotal - Me._importeAlquiler
      End Get
      'Set(ByVal value As Decimal)
      '   _importeTotal = value
      'End Set
   End Property

#End Region

End Class