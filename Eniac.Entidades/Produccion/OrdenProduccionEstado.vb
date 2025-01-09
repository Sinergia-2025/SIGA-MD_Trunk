Public Class OrdenProduccionEstado
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      NumeroOrdenProduccion
      IdProducto
      FechaEstado
      IdEstado
      IdUsuario
      CantEstado
      Observacion
      IdTipoComprobanteFact
      LetraFact
      CentroEmisorFact
      NumeroComprobanteFact
      Orden
      IdCriticidad
      FechaEntrega
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroReparto
      IdFormula
      IdResponsable

      PlanMaestroNumero
      PlanMaestroFecha

   End Enum

   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroOrdenProduccion As Long
   Public Property IdProducto As String
   Public Property Orden As Integer
   Public Property FechaEstado As Date


   Public Property IdEstado As String
   Public Property IdUsuario As String
   Public Property CantEstado As Decimal
   Public Property Observacion As String
   Public Property IdCriticidad As String
   Public Property FechaEntrega As Date
   Public Property NumeroReparto As Integer

   Public Property IdFormula As Integer

   Public Property IdResponsable As Integer

   Public Property PlanMaestroNumero As Integer?
   Public Property PlanMaestroFecha As Date?


   Public Property IdTipoComprobanteFact As String
   Public Property LetraFact As String
   Public Property CentroEmisorFact As Integer
   Public Property NumeroComprobanteFact As Long


   Public Enum FiltroEstadosInforme
      TODOS
      NORMAL
      ANULADO
   End Enum

End Class