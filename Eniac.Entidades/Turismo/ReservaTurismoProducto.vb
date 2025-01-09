Imports System.Drawing

Public Class ReservaTurismoProducto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdTipoReserva
      Letra
      CentroEmisor
      NumeroReserva
      IdProducto
      IdProductoComponente
      IdFormula
      Orden
      NombreProducto
      NombreProducto1
      NombreSubRubro
   End Enum

   Public Property IdTipoReserva As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroReserva As Long
   Public Property IdProducto As String
   Public Property IdProductoComponente As String
   Public Property IdFormula As Integer
   Public Property Orden As Integer
   Public Property NombreProducto As String
   Public Property NombreProducto1 As String
   Public Property NombreSubRubro As String

End Class