Public Interface ITarjetas

#Region "Propiedades"
   Property Orden As Integer

   Property Tarjeta As Tarjeta
   Property Banco As Banco

   Property Cuotas As Integer
   Property NumeroLote As Integer
   Property NumeroCupon As Integer
   Property Monto As Decimal

   ''Property PorcentajeDelInteres() As Decimal
   ''Property MontoDelInteres() As Decimal
   ''Property IdTarjetaCupon() As Integer

   ReadOnly Property NombreTarjeta As String
   ReadOnly Property NombreBanco As String
#End Region

End Interface