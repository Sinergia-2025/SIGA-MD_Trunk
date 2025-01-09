Public Class TarjetaCupon
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "TarjetasCupones"
   Public Const NombreTablaHistorial As String = "TarjetasCuponesHistorial"
   Public Enum Columnas
      IdTarjetaCupon
      IdSucursal
      IdTarjeta
      IdBanco
      Monto
      Cuotas
      NumeroLote
      NumeroCupon
      FechaEmision
      IdEstadoTarjeta
      IdEstadoTarjetaAnt
      IdCajaIngreso
      NroPlanillaIngreso
      NroMovimientoIngreso
      IdCajaEgreso
      NroPlanillaEgreso
      NroMovimientoEgreso
      IdUsuarioActualizacion
      FechaActualizacion
      IdCliente
      IdProveedor
      IdSituacionCupon
      NombreBanco
      NombreTarjeta
   End Enum
   Public Enum Estados
      ALTA
      ENCARTERA
      ACREDITADO
      'DEPOSITADO    Verificar utilización
      LIQUIDADO
      'DEPOSITADO    Verificar utilización
      EGRESOCAJA
      RECHAZADO
      NINGUNO
      ANULADO
   End Enum
   Public Enum Ordenamiento
      <Description("Fecha de Ingreso")> FECHAINGRESO
      <Description("Nombre y Fecha de Ingreso")> NOMBREYFECHAINGRESO
      <Description("Fecha de Actualización")> FECHAACTUALIZACION
      <Description("Nombre y Fecha de Actualización")> NOMBREYFECHAACTUALIZACION
   End Enum

#Region "Propiedades"

   Public Property IdTarjetaCupon As Integer
   Public Property IdTarjeta As Integer
   Public Property IdBanco As Integer
   Public Property Monto As Decimal
   Public Property Cuotas As Integer
   Public Property NumeroLote As Integer
   Public Property NumeroCupon As Integer
   Public Property FechaEmision As Date

   Public Property IdEstadoTarjeta As Estados
   Public Property IdEstadoTarjetaAnt As Estados

   Public Property IdCajaIngreso As Integer
   Public Property NroPlanillaIngreso As Integer
   Public Property NroMovimientoIngreso As Integer

   Public Property IdCajaEgreso As Integer
   Public Property NroPlanillaEgreso As Integer
   Public Property NroMovimientoEgreso As Integer

   Public Property IdUsuarioActualizacion As String
   Public Property FechaActualizacion As Date
   Public Property IdCliente As Long
   Public Property IdProveedor As Long
   Public Property IdSituacionCupon As Integer

   Public Property IdSucursal2 As Integer
   Public Property NombreBanco As String
   Public Property NombreTarjeta As String



#End Region
End Class