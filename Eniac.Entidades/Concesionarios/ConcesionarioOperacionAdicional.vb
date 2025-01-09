Public Class ConcesionarioOperacionAdicional
   Inherits Entidad

   Public Const NombreTabla As String = "ConcesionarioOperacionesAdicionales"
   Public Enum Columnas
      IdMarca
      AnioOperacion
      NumeroOperacion
      SecuenciaOperacion
      IdAdicional
      DetalleAdicional
      PrecioAdicional
   End Enum


   Public Property IdMarca As Integer
   Public Property AnioOperacion As Integer
   Public Property NumeroOperacion As Integer
   Public Property SecuenciaOperacion As Integer

   Public Property IdAdicional As Integer
   Public Property NombreAdicional As String                'NO SE PERSISTE. SOLO PARA PANTALLA DE SELECCION. MOSTRAR SEGUN FK IdAdicional
   Public Property DetalleAdicional As String
   Public Property PrecioAdicional As Double

   Public Property SelecAdicional As Boolean                'NO SE PERSISTE. SOLO PARA PANTALLA DE SELECCION
   Public Property SolicitaDetalleAdicional As Boolean      'NO SE PERSISTE. SOLO PARA PANTALLA DE SELECCION. MOSTRAR SEGUN FK IdAdicional

End Class