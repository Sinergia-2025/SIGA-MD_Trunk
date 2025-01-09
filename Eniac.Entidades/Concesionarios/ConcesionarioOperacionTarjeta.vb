Public Class ConcesionarioOperacionTarjeta
   Inherits Entidad
   Implements ITarjetas

   Public Const NombreTabla As String = "ConcesionarioOperacionesTarjetas"
   Public Enum Columnas
      IdMarca
      AnioOperacion
      NumeroOperacion
      SecuenciaOperacion
      Orden
      IdTarjeta
      IdBanco
      Monto
      Cuotas
      NumeroLote
      NumeroCupon

   End Enum

   Public Sub New()
      Tarjeta = New Tarjeta()
      Banco = New Banco()
   End Sub

   Public Property IdMarca As Integer
   Public Property AnioOperacion As Integer
   Public Property NumeroOperacion As Integer
   Public Property SecuenciaOperacion As Integer

   Public Property Orden As Integer Implements ITarjetas.Orden

   Public Property Tarjeta As Tarjeta Implements ITarjetas.Tarjeta

   Public Property Banco As Banco Implements ITarjetas.Banco

   Public Property Cuotas As Integer Implements ITarjetas.Cuotas

   Public Property NumeroLote As Integer Implements ITarjetas.NumeroLote

   Public Property NumeroCupon As Integer Implements ITarjetas.NumeroCupon

   Public Property Monto As Decimal Implements ITarjetas.Monto

   Public ReadOnly Property NombreTarjeta As String Implements ITarjetas.NombreTarjeta
      Get
         Return Tarjeta.NombreTarjeta
      End Get
   End Property

   Public ReadOnly Property NombreBanco As String Implements ITarjetas.NombreBanco
      Get
         Return Banco.NombreBanco
      End Get
   End Property
End Class