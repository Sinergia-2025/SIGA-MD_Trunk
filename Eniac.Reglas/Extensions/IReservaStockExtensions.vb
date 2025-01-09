Imports System.Runtime.CompilerServices
Namespace Extensions
   Public Module IReservaStockExtensions
      <Extension()>
      Public Function EvaluaReserva(estadoOrigen As Entidades.IReservaStock, estadoDestino As Entidades.IReservaStock) As Entidades.TipoReservaStock
         If Not estadoOrigen.Reserva AndAlso estadoDestino.Reserva Then
            Return Entidades.TipoReservaStock.Reserva
         ElseIf estadoOrigen.Reserva AndAlso Not estadoDestino.Reserva Then
            Return Entidades.TipoReservaStock.DesReserva
         Else
            Return Entidades.TipoReservaStock.NoMueveReserva
         End If
      End Function
   End Module
End Namespace