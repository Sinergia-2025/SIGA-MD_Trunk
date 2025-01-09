Public Class MovilRutaCliente
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "MovilRutasClientes"
   Public Enum Columnas
      IdRuta
      Dia
      Orden
      IdCliente
   End Enum

   Public Property IdRuta As Integer
   Public Property Dia As Integer
   Public Property Orden As Integer
   Public Property IdCliente As Long
End Class