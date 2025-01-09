<Serializable()>
Public Class ProductoLote
   Inherits Entidad

   Public Enum Columnas
      IdLote
      IdSucursal
      IdProducto
      FechaIngreso
      FechaVencimiento
      CantidadInicial
      CantidadActual
      Habilitado
      PrecioCosto
      IdDeposito
      IdUbicacion

   End Enum

   Public Sub New()
      ProductoSucursal = New ProductoSucursal()
   End Sub

   Public Property IdLote As String
   Public Property ProductoSucursal As ProductoSucursal
   Public Property FechaIngreso As Date
   Public Property FechaVencimiento As Date?
   Public Property CantidadInicial As Decimal
   Public Property CantidadActual As Decimal
   ''' <summary>
   ''' Es la cantidad que se recupera de la base de datos y no se modificaria en el codigo.
   ''' Sirve para mantener ese valor.
   ''' </summary>
   Public Property CantidadActualOriginal As Decimal
   Public Property Habilitado As Boolean
   Public Property PrecioCosto As Decimal
   Public Property Orden As Integer?

   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer

End Class