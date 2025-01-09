Public Class SeleccionMultipleLotes
   Inherits SeleccionMultipleBase
   Public Property IdLote As String
   Public Property FechaVencimiento As Date?
   Public Property InformeCalidadNumero As String
   Public Property InformeCalidadLink As String
   Public Property Stock As Decimal
   Public Sub New()
      MyBase.New()
   End Sub
   Public Sub New(ubicacionAdmin As SeleccionMultipleUbicaciones, idLote As String, fechaVencimiento As Date?, cantidad As Decimal, stock As Decimal,
                  informeCalidadNumero As String, informeCalidadLink As String)
      MyBase.New(ubicacionAdmin)
      Me.IdLote = idLote
      Me.FechaVencimiento = fechaVencimiento
      Me.InformeCalidadNumero = informeCalidadNumero
      Me.InformeCalidadLink = informeCalidadLink
      Me.Cantidad = cantidad
      Me.Stock = stock
   End Sub
End Class