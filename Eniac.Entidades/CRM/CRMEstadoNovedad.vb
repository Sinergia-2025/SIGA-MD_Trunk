Public Class CRMEstadoNovedad
   Inherits CRMEntidad

   Public Enum Columnas
      IdEstadoNovedad
      NombreEstadoNovedad
      Posicion
      SolicitaUsuario
      Finalizado
      IdTipoNovedad
      PorDefecto
      Color
      DiasProximoContacto
      ActualizaUsuarioResponsable
      SolicitaProveedorService
      Imprime
      Reporte
      Embebido
      AcumulaContador1
      AcumulaContador2
      EsFacturable
      CantidadCopias
      IdTipoEstadoNovedad
      Entregado
      IdEstadoFacturado
      AvanceEstadoFacturado
      ControlaStockConsumido
      RequiereComentarios

   End Enum

   Public Enum EntregadoValores
      <Description("No Afecta")> NoAfecta
      <Description("Graba")> Graba
      <Description("Limpia")> Limpia

   End Enum

   Public Property IdEstadoNovedad As Integer
   Public Property NombreEstadoNovedad As String
   Public Property Posicion As Integer
   Public Property SolicitaUsuario As Boolean
   Public Property Finalizado As Boolean
   Public Property PorDefecto As Boolean
   Public Property Color As Integer?
   Public Property DiasProximoContacto As Integer?
   Public Property ActualizaUsuarioResponsable As Boolean
   Public Property SolicitaProveedorService As Boolean
   Public Property Imprime As Boolean
   Public Property Reporte As String
   Public Property Embebido As Boolean
   Public Property AcumulaContador1 As Boolean
   Public Property AcumulaContador2 As Boolean
   Public Property EsFacturable As Boolean
   Public Property CantidadCopias As Integer
   Public Property IdTipoEstadoNovedad As Integer
   Public Property Entregado As EntregadoValores
   Public Property IdEstadoFacturado As Integer?
   Public Property AvanceEstadoFacturado As Decimal?

   Public Property ControlaStockConsumido As Boolean
   Public Property RequiereComentarios As Boolean

   Public Property NombreTipoEstadoNovedad As String '# NO se persiste en DB. Simplemente se agrega para visualizarlo
   Public Property NombreEstadoNovedadFacturado As String '# NO se persiste en DB. Simplemente se agrega para visualizarlo
End Class