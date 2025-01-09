<Serializable()>
Public Class ProduccionProducto
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdProduccion
      Orden
      IdProducto
      CantidadProducida
      IdLote
      FechaVencimiento
      IdFormula
      IdProduccionProceso
      IdProduccionForma
      Espmm
      EspPies
      CodigoSAE
      LargoExtAlto
      AnchoIntBase
      UrlPlano
      IdDeposito
      IdUbicacion
   End Enum

   Public Sub New()
      Produccion = New Produccion()
      IdProducto = String.Empty
      IdLote = String.Empty
      NombreProducto = String.Empty
      NombreFormula = String.Empty

      NrosSerie = New List(Of ProduccionProductoNrosSerie)()
      Componentes = New List(Of ProduccionProductoComp)()
   End Sub

   Public Property Produccion As Produccion

   Public Property IdDeposito As Integer
   Public Property NombreDeposito As String     'No persistido en BD
   Public Property IdUbicacion As Integer
   Public Property NombreUbicacion As String    'No persistido en BD

   Public Property IdProduccion As Integer
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property NombreProducto As String     'No persistido en BD
   Public Property Cantidad As Decimal
   Public Property IdLote As String
   Public Property VtoLote As Date
   Public Property IdFormula As Integer
   Public Property NombreFormula As String      'No persistido en BD
   Public Property IdProduccionProceso As Integer
   Public Property IdProduccionForma As Integer
   Public Property Espmm As Decimal
   Public Property EspPies As String
   Public Property CodigoSAE As Integer
   Public Property LargoExtAlto As Decimal
   Public Property AnchoIntBase As Decimal
   Public Property UrlPlano As String

   Public Property NrosSerie As List(Of ProduccionProductoNrosSerie)

   Public Property Componentes As List(Of ProduccionProductoComp)

End Class
Public Class ProduccionProductoNrosSerie
   Inherits Entidad
   Public Const NombreTabla As String = "ProduccionProductosNrosSerie"
   Public Enum Columnas
      IdSucursal
      IdProduccion
      Orden
      IdProducto
      NroSerie
   End Enum

   'Public Property IdSucursal As Integer
   Public Property IdProduccion As Integer
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property NroSerie As String


End Class