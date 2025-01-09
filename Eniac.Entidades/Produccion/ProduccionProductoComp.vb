<Serializable()>
Public Class ProduccionProductoComp
   Inherits Entidad

   Public Enum Columnas
      IdSucursal
      IdProduccion
      Orden
      IdProducto

      IdProductoElaborado              ''''
      IdUnicoNodoProductoElaborado     ''''

      IdProductoComponente
      IdUnicoNodoProductoComponente    ''''

      SecuenciaFormula                 '''' ¿Sec?

      NombreProductoElaborado          ''''
      NombreProductoComponente         ''''
      NombreFormula                    ''''

      PrecioCosto
      PrecioVenta
      Cantidad
      CantidadEnFormula                ''''
      SegunCalculoForma                ''''
      ImporteCosto                     ''''
      ImporteVenta                     ''''
      FormulaCalculoKilaje             ''''

      IdMoneda
      <Obsolete("No existe más el campo. Se reemplaza por la colección de Lotes. Se mantiene propiedad para compatibilidad.")>
      IdLote

      IdDeposito
      IdUbicacion

   End Enum

   Public Sub New()
      Cantidad = 0
      PrecioCosto = 0
      PrecioVenta = 0
      Produccion = New Produccion()
      Lotes = New List(Of ProduccionProductoCompLote)()
      NrosSerie = New List(Of ProduccionProductoCompNroSerie)()
   End Sub

#Region "Propiedades"
   Public Property Produccion As Produccion

   Public Property IdProduccion As Integer
   Public Property Orden As Integer
   Public Property IdProducto As String
   Public Property IdDeposito As Integer
   Public Property IdUbicacion As Integer

   Public Property IdProductoElaborado As String                  ''''
   Public Property IdUnicoNodoProductoElaborado As String         ''''
   Public Property IdProductoComponente As String
   Public Property IdUnicoNodoProductoComponente As String        ''''

   Public Property SecuenciaFormula As Integer                    '''' ¿Sec?

   Public Property IdFormula As Integer                           ''''

   Public Property NombreProductoElaborado As String              ''''
   Public Property NombreProductoComponente As String             ''''
   Public Property NombreFormula As String                        ''''

   Public Property PrecioCosto As Decimal
   Public Property PrecioVenta As Decimal
   Public Property Cantidad As Decimal

   Public Property CantidadEnFormula As Decimal                   ''''
   Public Property SegunCalculoForma As Boolean                   ''''
   Public Property ImporteCosto As Decimal                        ''''
   Public Property ImporteVenta As Decimal                        ''''
   Public Property FormulaCalculoKilaje As String                 ''''

   Public Property IdMoneda As Integer
   <Obsolete("No existe más el campo. Se reemplaza por la colección de Lotes. Se mantiene propiedad para compatibilidad.")>
   Public Property IdLote As String
   Public Property Lotes As List(Of ProduccionProductoCompLote)
   Public Property NrosSerie As List(Of ProduccionProductoCompNroSerie)

   Public Property SeleccionMultiple As SeleccionMultipleProducto    'Se usa solo en la captura de información desde pantalla y se transforma en información de las propiedades Lotes y NroSerie en la regla

   Public Property NombreProducto As String                       'Solo para mostrar en pantalla. No se persiste.
   Public Property IdDepositoDefecto As Integer                ' Datos del Producto. No se persiste. Solo para procesos. Puede no estar disponible.
   Public Property IdUbicacionDefecto As Integer               ' Datos del Producto. No se persiste. Solo para procesos. Puede no estar disponible.

#End Region

End Class