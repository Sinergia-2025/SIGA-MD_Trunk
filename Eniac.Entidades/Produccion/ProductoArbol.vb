Imports System.Collections.ObjectModel
Imports Eniac.Entidades.AFIPCAE

Public Class ProductoArbol
   Inherits Entidad

   'Public Enum Columnas
   '   IdProducto
   '   NombreProducto
   '   UnidadMedida
   '   Moneda
   '   Precio
   '   Costo
   '   CalculoForma
   '   IdFormula
   '   Cantidad
   '   Hijo
   'End Enum

   Public Sub New()
      Me.New(Guid.NewGuid().ToString())
   End Sub
   Public Sub New(idUnico As String)
      Me.IdUnico = idUnico
      Hijo = New ObservableCollection(Of ProductoArbol)()
   End Sub
   Public ReadOnly Property IdUnico As String


   Public Property IdProducto As String
   Public Property NombreProducto As String
   Public Property UnidadMedida As String
   Public Property IdMoneda As Integer
   Public Property Moneda As String
   Public Property CalculoForma As Boolean
   Public Property IdFormula As Integer
   Public Property NombreFormula As String
   Public Property Cantidad As Decimal
   Public Property CantidadEnFormula As Decimal
   Public Property PrecioConImpuestos As Decimal
   Public Property CostoConImpuestos As Decimal
   Public Property PrecioSinImpuestos As Decimal
   Public Property CostoSinImpuestos As Decimal
   Public Property ImportePrecioConImpuestos As Decimal
   Public Property ImporteCostoConImpuestos As Decimal
   Public Property ImportePrecioSinImpuestos As Decimal
   Public Property ImporteCostoSinImpuestos As Decimal
   Public Property FormulaCalculoKilaje As String
   Public Property CantidadUMproduccion As Decimal
   Public Property FactorConversionProduccion As Decimal
   Public Property IdUnidadDeMedidaProduccion As String
   Public Property Hijo As ObservableCollection(Of ProductoArbol)

   'Private _temp_secuencia As Integer = 1
   Public Function ConvertToProduccionProductosFormula() As List(Of ProduccionProductoComp)
      Return New FormulaConverter().ConvertirFormulaOPEnProduccion(ConvertToOPProductosFormula())
   End Function
   Public Function ConvertToOPProductosFormula() As List(Of OrdenProduccionProductoFormula)
      Return New FormulaConverter().ConvertirFormulaPedidoEnOP(ConvertToPedidosProductosFormula())
   End Function
   Public Function ConvertToPedidosProductosFormula() As List(Of PedidoProductoFormula)
      Dim lst = New List(Of PedidoProductoFormula)()
      Dim secuencia = 1I
      Hijo.ToList().ForEach(Sub(h) ConvertToPedidosProductosFormula(lst, Me, h, secuencia))
      Return lst
   End Function
   Private Function ConvertToPedidosProductosFormula(lst As List(Of PedidoProductoFormula), productoPadre As ProductoArbol, productoArbol As ProductoArbol, ByRef secuencia As Integer) As List(Of PedidoProductoFormula)
      Dim nodo = New PedidoProductoFormula() With
         {
            .IdSucursal = 0,
            .IdTipoComprobante = "",
            .Letra = "",
            .CentroEmisor = 0,
            .NumeroPedido = 0,
            .IdProducto = "",
            .Orden = 0,
            .IdProductoElaborado = productoPadre.IdProducto,
            .IdUnicoNodoProductoElaborado = productoPadre.IdUnico,
            .IdProductoComponente = productoArbol.IdProducto,
            .IdUnicoNodoProductoComponente = productoArbol.IdUnico,
            .IdFormula = productoArbol.IdFormula,
            .SecuenciaFormula = secuencia,
            .NombreProductoElaborado = productoPadre.NombreProducto,
            .NombreProductoComponente = productoArbol.NombreProducto,
            .NombreFormula = productoArbol.NombreFormula,
            .PrecioCosto = productoArbol.CostoSinImpuestos,
            .PrecioVenta = productoArbol.PrecioSinImpuestos,
            .Cantidad = productoArbol.Cantidad,
            .CantidadEnFormula = productoArbol.CantidadEnFormula,
            .SegunCalculoForma = productoArbol.CalculoForma,
            .ImporteCosto = productoArbol.ImporteCostoSinImpuestos,
            .ImporteVenta = productoArbol.ImportePrecioSinImpuestos,
            .FormulaCalculoKilaje = productoArbol.FormulaCalculoKilaje,
            .IdUnidadDeMedidaProduccion = productoArbol.IdUnidadDeMedidaProduccion,
            .CantidadUMproduccion = productoArbol.CantidadUMproduccion,
            .FactorConversionProduccion = productoArbol.FactorConversionProduccion
         }
      lst.Add(nodo)
      secuencia += 1
      For Each h In productoArbol.Hijo
         '_temp_secuencia += 1
         ConvertToPedidosProductosFormula(lst, productoArbol, h, secuencia)
      Next
      'productoArbol.Hijo.ToList().ForEach(Sub(h) ConvertToPedidosProductosFormula(lst, productoArbol, h, secuencia))
      Return lst
   End Function

End Class
Public Class ProduccionFormasVariablesList
   Inherits List(Of ProduccionFormasVariables)

#Region "Constructores"
   Public Sub New()
   End Sub
   Public Sub New(capacity As Integer)
      MyBase.New(capacity)
   End Sub
   Public Sub New(collection As IEnumerable(Of ProduccionFormasVariables))
      MyBase.New(collection)
   End Sub
#End Region

   Public Overloads Function Add(key As String, value As Decimal) As ProduccionFormasVariables
      Dim tpl = New ProduccionFormasVariables(key, value)
      Add(tpl)
      Return tpl
   End Function

   Public Function ToList() As ProduccionFormasVariablesList
      Return New ProduccionFormasVariablesList(Me)
   End Function

   Public Function GetValor(otherValue As ProduccionFormasVariables) As Decimal
      Return [Get](otherValue.Key).Value
   End Function
   Public Function GetValor(key As String) As Decimal
      Return [Get](key).Value
   End Function
   Public Function [Get](key As String) As ProduccionFormasVariables
      Dim item = FirstOrDefault(Function(i) i.Key = key)
      If item Is Nothing Then
         Throw New Exception(String.Format("No existe un item con la clave {0}", If(key Is Nothing, "(null)", If(String.IsNullOrWhiteSpace(key), "(blanco)", key))))
      End If
      Return item
   End Function

End Class
Public Class ProduccionFormasVariables
   Public Property Key As String
   Public Property Value As Decimal

   Public Sub New()
   End Sub

   Public Sub New(key As String, value As Decimal)
      Me.New()
      Me.Key = key
      Me.Value = value
   End Sub
End Class
Public Class FormulaConverter
   Public Overridable Function ConvertirFormulaOPEnProduccion(ppf As List(Of OrdenProduccionProductoFormula)) As List(Of ProduccionProductoComp)
      Return ppf.ConvertAll(Function(f) ConvertirFormulaOPEnProduccion(f))
   End Function
   Public Overridable Function ConvertirFormulaOPEnProduccion(ppf As OrdenProduccionProductoFormula) As ProduccionProductoComp
      Dim ser = New JavaScriptSerializer()
      Dim oppf = ser.Deserialize(Of ProduccionProductoComp)(ser.Serialize(ppf))
      oppf.IdProduccion = ppf.NumeroOrdenProduccion.ToInteger()
      oppf.IdMoneda = Entidades.Moneda.Peso
      Return oppf
   End Function

   Public Overridable Function ConvertirFormulaPedidoEnOP(ppf As List(Of PedidoProductoFormula)) As List(Of OrdenProduccionProductoFormula)
      Return ppf.ConvertAll(Function(f) ConvertirFormulaPedidoEnOP(f))
   End Function
   Public Overridable Function ConvertirFormulaPedidoEnOP(ppf As PedidoProductoFormula) As OrdenProduccionProductoFormula
      Dim ser = New JavaScriptSerializer()
      Dim oppf = ser.Deserialize(Of OrdenProduccionProductoFormula)(ser.Serialize(ppf))
      oppf.NumeroOrdenProduccion = ppf.NumeroPedido
      Return oppf
   End Function
   Public Overridable Function ConvertirFormulaOPEnPedido(ppf As List(Of OrdenProduccionProductoFormula)) As List(Of PedidoProductoFormula)
      Return ppf.ConvertAll(Function(f) ConvertirFormulaOPEnPedido(f))
   End Function
   Public Overridable Function ConvertirFormulaOPEnPedido(ppf As OrdenProduccionProductoFormula) As PedidoProductoFormula
      Dim ser = New JavaScriptSerializer()
      Dim oppf = ser.Deserialize(Of PedidoProductoFormula)(ser.Serialize(ppf))
      oppf.NumeroPedido = ppf.NumeroOrdenProduccion
      Return oppf
   End Function

End Class