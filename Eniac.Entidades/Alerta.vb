Public Class Alerta
   Inherits Eniac.Entidades.Entidad

   Public Enum Tipos As Integer
      AlertaCustom = -2
      NoDefinido = -1
      ProductosSinStock = 0
      ChequesADepositar = 1
      PuntoDePedidosDeProductos = 2
      StockMinimoDeProductos = 3
      InconsistenciaStockVsStockLotes = 4
      InconsistenciaStockVsMovimientosDeStock = 5
      TopesCaja = 6
      ConfiguracionImpresoras = 7
      ControlVersion = 8
      ControlInconsistenciasCtaCteClientesVsCtaCtePagos = 9
      ParámetrosDePedidos = 10
      PedidosSinFacturar = 11
      NovedadesFechasVencidas = 12
      NovedadesFechasPorVencer = 13
      ControlInconsistenciasCtaCteProveedoresVsCtaCtePagos = 14
      TurnosNoEfectivos = 15
      TurnosDelDia = 16
      ProspectoSinCRM = 17
      ChequesPropiosADebitar = 18
      RemitosSinFacturar = 19
      VencimientoCertificadoDigital = 20
      AlertaClientesCategoriaModificarVencidas = 21 'PE-30973
      AlertaPedidosSinCantidadItems = 22 '-.PE-32652.-
      AlertaPedidosConCantidadItems = 23 '-.PE-32652.-
      ControlNetFwk = 24
      AlertaClientesConDeuda = 25
      UltimaFechaSincroOCBejerman = 26
      LicenciasVsDispositivos = 27  'PE-38109
      ControlSaltoNumeracion = 28
      AlertaProvComprobantesVencidos = 29
      InconsistenciaDepositosVsUbicaciones = 30
      InconsistenciaDepositosVsMovimientoDeStock = 31
      InconsistenciaDepositosVsSucursales = 32
      InconsistenciaUbicacionesVsMovimientoDeStock = 33
   End Enum

   Public Enum Grupos
      Alertas
   End Enum

   Public Sub New()
      MostrarEnLista = True
      MostrarPopUp = False
      OrdenPrioridad = UInteger.MaxValue
   End Sub

#Region "Propiedades"

   Public Property Key() As Tipos
   Public Property MensajeDeAlerta() As String
   Public Property Grupo() As Grupos
   Public Property Color() As Drawing.Color?
   Public Property MostrarEnLista() As Boolean
   Public Property MostrarPopUp() As Boolean
   Public Property OrdenPrioridad() As UInteger
   Public Property Tag() As Object
   Public Property TituloConsultaGenerica() As String
   Public Property AlertaSistema() As SistemaE.AlertaSistema
   Public Property AlertaSistemaCondicion() As SistemaE.AlertaSistemaCondicion

#End Region

End Class
