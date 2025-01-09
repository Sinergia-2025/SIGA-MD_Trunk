Public Class ConcesionarioOperacion
   Inherits Entidad

   Public Const NombreTabla As String = "ConcesionarioOperaciones"
   Public Enum Columnas
      IdMarca
      AnioOperacion
      NumeroOperacion
      SecuenciaOperacion
      CodigoOperacion
      FechaOperacion
      CotizacionDolar
      IdCliente
      TipoOperacion
      IdProductoCeroKilometro
      CantidadCeroKilometro
      PrecioCeroKilometro
      ImporteCeroKilometro

      IdTipoUnidadCeroKilometro
      IdSubTipoUnidadCeroKilometro
      IdEjeCeroKilometro
      CaracteristicaAdicionalCeroKilometro

      LargoCeroKilometro
      AltoCargaCeroKilometro
      AltoPuertaLateralCeroKilometro
      ColorCarroceriaCeroKilometro
      ColorZocaloCeroKilometro
      ColorBaseCeroKilometro

      PuertaTraseraCeroKilometro
      ParanteCeroKilometro
      PisoCeroKilometro
      MarcoCeroKilometro
      HerrajeCeroKilometro

      OtrasObservacionesCeroKilometro

      PatenteVehiculoUsado
      PrecioListaUsado
      ImporteUsado

      ImporteTotalAdicionales
      ImporteTotalCaracteristicas
      ImporteTotal

      ImportePesos
      ImporteTarjetas
      ImporteCheques
      ImporteTransferencia
      FechaTransferencia
      IdCuentaBancaria

   End Enum

   Public Sub New()
      Cliente = New ClienteLiviano()
      Adicionales = New List(Of ConcesionarioOperacionAdicional)()
      Tarjetas = New List(Of ConcesionarioOperacionTarjeta)()
      Cheques = New List(Of Cheque)()
      VehiculosPago = New ListConBorrados(Of Vehiculo)()
   End Sub

   Public Property IdMarca As Integer
   Public Property AnioOperacion As Integer
   Public Property NumeroOperacion As Integer
   Public Property SecuenciaOperacion As Integer
   Public Property CodigoOperacion As String

   Public Property FechaOperacion As Date
   Public Property CotizacionDolar As Decimal
   Public Property Cliente As ClienteLiviano

   Public Property TipoOperacion As ConcesionarioTipoOperacion

   Public Property IdProductoCeroKilometro As String
   Public Property CantidadCeroKilometro As Decimal?
   Public Property PrecioCeroKilometro As Decimal?
   Public Property ImporteCeroKilometro As Decimal?

   Public Property PatenteVehiculoUsado As String
   Public Property PrecioListaUsado As Decimal?
   Public Property ImporteUsado As Decimal?


   Public Property Adicionales As List(Of ConcesionarioOperacionAdicional)
   Public Property Tarjetas As List(Of ConcesionarioOperacionTarjeta)
   Public Property Cheques As List(Of Cheque)
   Public Property VehiculosPago As ListConBorrados(Of Vehiculo)

#Region "Caracteristicas"
   Public Property IdTipoUnidadCeroKilometro As Integer
   Public Property IdSubTipoUnidadCeroKilometro As Integer
   Public Property IdEjeCeroKilometro As Integer
   Public Property CaracteristicaAdicionalCeroKilometro As String

   Public Property LargoCeroKilometro As String
   Public Property AltoCargaCeroKilometro As String
   Public Property AltoPuertgaLateralCeroKilometro As String
   Public Property ColorCarroceriaCeroKilometro As String
   Public Property ColorZocaloCeroKilometro As String
   Public Property ColorBaseCeroKilometro As String

   Public Property PuertaTraseraCeroKilometro As ConcesionarioPuertaTrasera?
   Public Property ParanteCeroKilometro As ConcesionarioParante?
   Public Property PisoCeroKilometro As ConcesionarioPiso?
   Public Property MarcoCeroKilometro As Publicos.SiNo?
   Public Property HerrajeCeroKilometro As ConcesionarioHerraje?

   Public Property OtrasObservacionesCeroKilometro As String

#End Region

   Public Property ImporteTotalAdicionales As Decimal
   Public Property ImporteTotalCaracteristicas As Decimal

   Public Property ImporteTotal As Decimal


   Public Property ImportePesos As Decimal
   Public Property ImporteTarjetas As Decimal
   Public Property ImporteCheques As Decimal
   Public Property ImporteTransferencia As Decimal
   Public Property FechaTransferencia As Date?
   Public Property IdCuentaBancaria As Integer


End Class
Public Enum ConcesionarioTipoOperacion
   CeroKilometro
   Usado
End Enum