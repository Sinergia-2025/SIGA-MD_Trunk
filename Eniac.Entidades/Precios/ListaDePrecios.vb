<Serializable()>
Public Class ListaDePrecios
   Inherits Entidad

   Public Enum Columnas
      IdListaPrecios
      NombreListaPrecios
      FechaVigencia
      DescuentoRecargoPorc
      Orden
      Activa
      NombreCortoListaPrecios
      IdFormasPago
      PublicarEnWeb
      PermiteUtilidadEnCero
   End Enum

   Public Sub New()
      DescuentoRecargoPorc = 0
   End Sub

   Public Property IdListaPrecios As Integer
   Public Property NombreListaPrecios As String

   Public Property FechaVigencia As Date
   Public Property IdListaPreciosCopiar As Integer
   Public Property DescuentoRecargoPorc As Decimal

   Public Property Orden As Integer
   Public Property Activa As Boolean
   Public Property PublicarEnWeb As Boolean
   Public Property PermiteUtilidadEnCero As Boolean
   Public Property NombreCortoListaPrecios As String

   Public Property FormaPago As VentaFormaPago

   Public Property DivideCuota As Boolean
   Public Property DivideCuotaCantidad As Integer

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdFormasPago As Integer
      Get
         If FormaPago Is Nothing Then Return 0
         Return FormaPago.IdFormasPago
      End Get
   End Property

   Public ReadOnly Property DescripcionFormasPago As String
      Get
         If FormaPago Is Nothing Then Return String.Empty
         Return FormaPago.DescripcionFormasPago
      End Get
   End Property
#End Region

   Public Function GetCopia() As ListaDePrecios
      Dim copia = New ListaDePrecios()
      With copia
         .FechaVigencia = FechaVigencia
         .IdListaPrecios = IdListaPrecios
         .IdSucursal = IdSucursal
         .NombreListaPrecios = NombreListaPrecios
         .DescuentoRecargoPorc = DescuentoRecargoPorc
         .Orden = Orden
         .Activa = Activa
         .NombreCortoListaPrecios = NombreCortoListaPrecios
         If FormaPago IsNot Nothing Then
            .FormaPago = .Clonar(FormaPago)
         End If
         .Password = Password
         .Usuario = Usuario
      End With

      Return copia
   End Function

End Class