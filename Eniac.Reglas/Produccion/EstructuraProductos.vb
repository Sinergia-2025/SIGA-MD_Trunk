Imports System.Collections.ObjectModel

Public Class EstructuraProductos
   Inherits Base
#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "EstructuraProductos"
      da = accesoDatos
   End Sub

#End Region
   Public Function CreaEstructura(padre As String, formula As Integer, idListaPrecios As Integer, cantidad As Decimal, muestraPrecio As Boolean,
                                  variables As Entidades.ProduccionFormasVariablesList, moneda As Integer, cotizacionDolar As Decimal) As ObservableCollection(Of Entidades.ProductoArbol)
      '-- Crea Padre de la Estructura.- 
      Dim ndPadre = CreatePadre(padre, formula, idListaPrecios, muestraPrecio, moneda, cotizacionDolar)
      '--
      If ndPadre.Count <> 0 Then
         Dim parentEstruc = ndPadre.First()
         '-- Crea Hijo de la Estructura.-
         parentEstruc.Hijo = CreateHijo(padre, formula, idListaPrecios, muestraPrecio, moneda, cotizacionDolar)
      End If

      RecalculaPrecios(RecalculaCantidades(ndPadre.FirstOrDefault(), cantidad, variables))

      Return ndPadre
   End Function

   Public Function RecalculaCantidades(item As ObservableCollection(Of Entidades.ProductoArbol), variables As Entidades.ProduccionFormasVariablesList) As ObservableCollection(Of Entidades.ProductoArbol)
      Return RecalculaCantidades(item.FirstOrDefault(), variables)
   End Function
   Public Function RecalculaCantidades(item As Entidades.ProductoArbol, variables As Entidades.ProduccionFormasVariablesList) As ObservableCollection(Of Entidades.ProductoArbol)
      Return New ObservableCollection(Of Entidades.ProductoArbol)({RecalculaPrecios(RecalculaCantidades(item, If(item Is Nothing, 0, item.Cantidad), variables))})
   End Function
   Private Function RecalculaCantidades(item As Entidades.ProductoArbol, cantidad As Decimal, variables As Entidades.ProduccionFormasVariablesList) As Entidades.ProductoArbol
      If item IsNot Nothing Then
         Dim rForma = New ProduccionFormas(da)

         item.Cantidad = item.CantidadEnFormula * cantidad
         If Not String.IsNullOrWhiteSpace(item.FormulaCalculoKilaje) Then
            item.Cantidad = item.Cantidad * rForma.EvaluarFormula(item.FormulaCalculoKilaje, variables)
         End If

         item.Hijo.ForEachSecure(Sub(h) RecalculaCantidades(h, item.Cantidad, variables))
      End If
      Return item
   End Function

   Public Function RecalculaPrecios(item As Entidades.ProductoArbol) As Entidades.ProductoArbol
      If item IsNot Nothing Then
         If item.Hijo.Count > 0 Then
            item.ImportePrecioConImpuestos = 0
            item.ImportePrecioSinImpuestos = 0
            item.ImporteCostoConImpuestos = 0
            item.ImporteCostoSinImpuestos = 0
            For Each hijo In item.Hijo
               RecalculaPrecios(hijo)

               item.ImportePrecioConImpuestos += hijo.ImportePrecioConImpuestos
               item.ImportePrecioSinImpuestos += hijo.ImportePrecioSinImpuestos
               item.ImporteCostoConImpuestos += hijo.ImporteCostoConImpuestos
               item.ImporteCostoSinImpuestos += hijo.ImporteCostoSinImpuestos
            Next

            If item.Cantidad <> 0 Then
               item.PrecioConImpuestos = item.ImportePrecioConImpuestos / item.Cantidad
               item.PrecioSinImpuestos = item.ImportePrecioSinImpuestos / item.Cantidad
               item.CostoConImpuestos = item.ImporteCostoConImpuestos / item.Cantidad
               item.CostoSinImpuestos = item.ImporteCostoSinImpuestos / item.Cantidad
            End If
         Else
            item.ImportePrecioConImpuestos = item.PrecioConImpuestos * item.Cantidad
            item.ImportePrecioSinImpuestos = item.PrecioSinImpuestos * item.Cantidad
            item.ImporteCostoConImpuestos = item.CostoConImpuestos * item.Cantidad
            item.ImporteCostoSinImpuestos = item.CostoSinImpuestos * item.Cantidad
         End If
      End If
      Return item
   End Function


   Private Function CreatePadre(padre As String, formula As Integer, idListaPrecios As Integer, muestraPrecio As Boolean,
                                moneda As Integer, cotizacionDolar As Decimal) As ObservableCollection(Of Entidades.ProductoArbol)

      Dim oPadre = New ObservableCollection(Of Entidades.ProductoArbol)
      Dim sql = New SqlServer.EstructuraProductos(da).RecuperaDatos(padre, formula, idListaPrecios, actual.Sucursal.IdSucursal, Publicos.PreciosConIVA, nodoPadre:=True)

      For Each reg As DataRow In sql.Rows
         Dim Dato = CreaNodo(reg, muestraPrecio, moneda, cotizacionDolar)
         oPadre.Add(Dato)
      Next
      Return oPadre
   End Function

   Public Function CreateHijo(padre As String, formula As Integer, idListaPrecios As Integer, muestraPrecio As Boolean, moneda As Integer,
                              cotizacionDolar As Decimal) As ObservableCollection(Of Entidades.ProductoArbol)

      Dim hijos = New ObservableCollection(Of Entidades.ProductoArbol)
      Dim sql = New SqlServer.EstructuraProductos(da).RecuperaDatos(padre, formula, idListaPrecios, actual.Sucursal.IdSucursal, Publicos.PreciosConIVA, nodoPadre:=False)

      For Each reg As DataRow In sql.Rows
         'Dim nodoHijo = CreaNodo(reg, cantidad, muestraPrecio, variables, cotizacionDolar)
         Dim nodoHijo = CreaNodo(reg, muestraPrecio, moneda, cotizacionDolar)
         nodoHijo.Hijo = CreateHijo(nodoHijo.IdProducto, nodoHijo.IdFormula, idListaPrecios, muestraPrecio, moneda, cotizacionDolar)
         hijos.Add(nodoHijo)
      Next
      Return hijos
   End Function

   'Public Function CreaNodo(reg As DataRow, cantidad As Decimal, muestraPrecio As Boolean, variables As ProduccionFormasVariablesList, cotizacionDolar As Decimal) As Entidades.ProductoArbol
   Public Function CreaNodo(reg As DataRow, muestraPrecio As Boolean, moneda As Integer, cotizacionDolar As Decimal) As Entidades.ProductoArbol
      'Dim rForma = New Reglas.ProduccionFormas(da)
      Dim nodoHijo = New Entidades.ProductoArbol()
      With nodoHijo
         .IdProducto = reg.Field(Of String)("IdProducto")
         .NombreProducto = reg.Field(Of String)("NombreProducto")
         .UnidadMedida = reg.Field(Of String)("UnidadMedida")
         .IdMoneda = reg.Field(Of Integer)("IdMoneda")
         .Moneda = reg.Field(Of String)("Moneda")

         .CalculoForma = reg.Field(Of Boolean)("CalculoForma")
         .IdFormula = reg.Field(Of Integer?)("IdFormula").IfNull()
         .NombreFormula = reg.Field(Of String)("NombreFormula").IfNull()
         .CantidadEnFormula = reg.Field(Of Decimal)("Cantidad")
         '.Cantidad = .CantidadEnFormula * cantidad

         .PrecioConImpuestos = If(muestraPrecio, Decimal.Parse(reg("PrecioConImpuestos").ToString()), 0)
         .CostoConImpuestos = If(muestraPrecio, Decimal.Parse(reg("CostoConImpuestos").ToString()), 0)
         .PrecioSinImpuestos = If(muestraPrecio, Decimal.Parse(reg("PrecioSinImpuestos").ToString()), 0)
         .CostoSinImpuestos = If(muestraPrecio, Decimal.Parse(reg("CostoSinImpuestos").ToString()), 0)

         If moneda = Entidades.Moneda.Peso Then
            If .IdMoneda = Entidades.Moneda.Dolar Then
               .PrecioConImpuestos *= cotizacionDolar
               .CostoConImpuestos *= cotizacionDolar
               .PrecioSinImpuestos *= cotizacionDolar
               .CostoSinImpuestos *= cotizacionDolar
            End If
         Else
            If .IdMoneda = Entidades.Moneda.Peso Then
               .PrecioConImpuestos /= cotizacionDolar
               .CostoConImpuestos /= cotizacionDolar
               .PrecioSinImpuestos /= cotizacionDolar
               .CostoSinImpuestos /= cotizacionDolar
            End If
         End If

         .FormulaCalculoKilaje = reg.Field(Of String)("FormulaCalculoKilaje").IfNull()
         .IdUnidadDeMedidaProduccion = reg.Field(Of String)("IdUnidadDeMedidaProduccion")
         .CantidadUMproduccion = reg.Field(Of Decimal)("CantidadUMproduccion")
         .FactorConversionProduccion = reg.Field(Of Decimal)("FactorConversionProduccion")
         'If Not String.IsNullOrWhiteSpace(.FormulaCalculoKilaje) Then
         '   .Cantidad = .Cantidad * rForma.EvaluarFormula(.FormulaCalculoKilaje, variables)
         'End If

         '.ImportePrecioConImpuestos = .PrecioConImpuestos * .Cantidad
         '.ImporteCostoConImpuestos = .CostoConImpuestos * .Cantidad
         '.ImportePrecioSinImpuestos = .PrecioSinImpuestos * .Cantidad
         '.ImporteCostoSinImpuestos = .CostoSinImpuestos * .Cantidad
      End With

      Return nodoHijo
   End Function

End Class
Public Class ProductoArbolConverter

   Private _cache As BusquedasCacheadas
   Public Sub New()
      _cache = New BusquedasCacheadas()
   End Sub
   Public Function ConvertFromOPProductosFormula(lst As List(Of Entidades.OrdenProduccionProductoFormula)) As Entidades.ProductoArbol
      Return ConvertFromPedidosProductosFormula(New Entidades.FormulaConverter().ConvertirFormulaOPEnPedido(lst))
   End Function
   Public Function ConvertFromPedidosProductosFormula(lst As List(Of Entidades.PedidoProductoFormula)) As Entidades.ProductoArbol
      If lst.Any Then
         Dim nodo1 = lst.FirstOrDefault(Function(n1) n1.SecuenciaFormula = 1)
         If nodo1 IsNot Nothing Then
            Dim prod = _cache.BuscaProductoEntidadPorId(nodo1.IdProductoElaborado)
            Dim padre = New Entidades.ProductoArbol(nodo1.IdUnicoNodoProductoElaborado) With {
                    .IdProducto = nodo1.IdProductoElaborado,
                    .IdFormula = nodo1.IdFormula,
                    .UnidadMedida = prod.UnidadDeMedida.IdUnidadDeMedida,
                    .IdMoneda = prod.Moneda.IdMoneda,
                    .Moneda = prod.Moneda.NombreMoneda,
                    .NombreProducto = nodo1.NombreProductoElaborado,
                    .NombreFormula = nodo1.NombreFormula,
                    .Cantidad = 1, 'nodo1.Cantidad,
                    .CantidadEnFormula = 1, 'nodo1.CantidadEnFormula,
                    .CalculoForma = nodo1.SegunCalculoForma,
                    .FormulaCalculoKilaje = nodo1.FormulaCalculoKilaje
                }
            ',
            '.CostoSinImpuestos = nodo1.PrecioCosto,
            '.PrecioSinImpuestos = nodo1.PrecioVenta,
            '.ImporteCostoSinImpuestos = nodo1.ImporteCosto,
            '.ImportePrecioSinImpuestos = nodo1.ImporteVenta,
            '.CostoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(nodo1.PrecioCosto, prod),
            '.PrecioConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(nodo1.PrecioVenta, prod),
            '.ImporteCostoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(nodo1.ImporteCosto, prod),
            '.ImportePrecioConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(nodo1.ImporteVenta, prod)
            padre.Hijo = CrearHijos(lst, padre)

            'Dim rEstr = New EstructuraProductos()
            'rEstr.RecalculaCantidades(padre)

            Return padre
         End If
      End If
      Return Nothing
   End Function
   Private Function CrearHijos(lst As List(Of Entidades.PedidoProductoFormula), padre As Entidades.ProductoArbol) As ObservableCollection(Of Entidades.ProductoArbol)
      Dim hijos = New ObservableCollection(Of Entidades.ProductoArbol)()
      For Each nodo1 In lst.OrderBy(Function(n) n.SecuenciaFormula).Where(Function(n) n.IdUnicoNodoProductoElaborado = padre.IdUnico)
         Dim prod = _cache.BuscaProductoEntidadPorId(nodo1.IdProductoComponente)
         Dim hijo = New Entidades.ProductoArbol(nodo1.IdUnicoNodoProductoComponente) With {
                    .IdProducto = nodo1.IdProductoComponente,
                    .IdFormula = nodo1.IdFormula,
                    .UnidadMedida = prod.UnidadDeMedida.IdUnidadDeMedida,
                    .IdMoneda = prod.Moneda.IdMoneda,
                    .Moneda = prod.Moneda.NombreMoneda,
                    .NombreProducto = nodo1.NombreProductoComponente,
                    .NombreFormula = nodo1.NombreFormula,
                    .CostoSinImpuestos = nodo1.PrecioCosto,
                    .PrecioSinImpuestos = nodo1.PrecioVenta,
                    .Cantidad = nodo1.Cantidad,
                    .CantidadEnFormula = nodo1.CantidadEnFormula,
                    .CalculoForma = nodo1.SegunCalculoForma,
                    .ImporteCostoSinImpuestos = nodo1.ImporteCosto,
                    .ImportePrecioSinImpuestos = nodo1.ImporteVenta,
                    .FormulaCalculoKilaje = nodo1.FormulaCalculoKilaje,
                    .CostoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(nodo1.PrecioCosto, prod),
                    .PrecioConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(nodo1.PrecioVenta, prod),
                    .ImporteCostoConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(nodo1.ImporteCosto, prod),
                    .ImportePrecioConImpuestos = CalculosImpositivos.ObtenerPrecioConImpuestos(nodo1.ImporteVenta, prod)
                }
         hijos.Add(hijo)
         hijo.Hijo = CrearHijos(lst, hijo)
      Next
      Return hijos
   End Function

   '.SecuenciaFormula = Secuencia
   'productoPadre.NombreProducto = .NombreProductoElaborado
   '.IdProductoElaborado = productoPadre.IdProducto
   '.IdUnicoNodoProductoElaborado = productoPadre.IdUnico
   'Public Property UnidadMedida As String
   'Public Property IdMoneda As Integer
   'Public Property Moneda As String
   'Public Property PrecioSinImpuestos As Decimal
   'Public Property CostoSinImpuestos As Decimal
   'Public Property ImportePrecioSinImpuestos As Decimal
   'Public Property ImporteCostoSinImpuestos As Decimal

End Class