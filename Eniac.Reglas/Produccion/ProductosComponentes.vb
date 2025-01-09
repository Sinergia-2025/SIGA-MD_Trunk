Imports System.Web.UI.WebControls
Imports Infragistics.Win
Public Class ProductosComponentes
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("ProductosComponentes", accesoDatos)
   End Sub

#End Region

   Public Sub _Insertar(entidad As Entidades.ProductoComponente)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Borrar(entidad As Entidades.ProductoComponente)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.ProductoComponente, tipo As TipoSP)
      Dim sql As SqlServer.ProductosComponentes = New SqlServer.ProductosComponentes(da)
      Select Case tipo
         Case TipoSP._I
            sql.ProductosComponentes_I(en.IdProducto, en.IdFormula, en.IdProductoComponente, en.IdFormulaComponente, en.Cantidad, en.SegunCalculoForma, en.IdUnidadDeMedidaProduccion, en.CantidadUMProduccion, en.FactorConversionProduccion)
         Case TipoSP._D
            sql.ProductosComponentes_D(en.IdProducto, en.IdFormula)
      End Select
   End Sub

#Region "Metodos Publicos"

   Public Sub ImportarFormulas(IdSucursal As Integer, datos As DataTable, usuario As String, ByRef BarraProg As Windows.Forms.ProgressBar)

      Try

         Dim FacturacionDescontarStockComp As Boolean = Publicos.ProduccionDescStockComponentesFormulasFacturacion

         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = datos

         Dim i As Integer = 0

         BarraProg.Maximum = dt.Rows.Count
         BarraProg.Minimum = 0
         BarraProg.Value = 0

         'oProductos.InactivarProductos(idMarca)

         Dim sql As SqlServer.ProductosComponentes = New SqlServer.ProductosComponentes(da)
         Dim rProductos As Reglas.Productos = New Reglas.Productos(da)
         Dim sql2 As SqlServer.Productos = New SqlServer.Productos(da)
         Dim sql3 As SqlServer.ProductosFormulas = New SqlServer.ProductosFormulas(da)


         Dim IdProducto As String = ""
         Dim IdFormula As Integer = 0
         Dim NombreFormula As String = ""

         Dim dtFormulas As DataTable = New DataTable
         Dim oFormulas As Eniac.Reglas.ProductosFormulas = New Eniac.Reglas.ProductosFormulas(da)

         For Each dr As DataRow In dt.Rows

            i += 1
            BarraProg.Value = i

            'If i = 150 Then
            '   Stop
            'End If

            'Threading.Thread.Sleep(10)

            'System.Windows.Forms.Application.DoEvents()

            If Boolean.Parse(dr("Importa").ToString()) Then

               If dr("IdProducto").ToString.Trim() <> IdProducto Then

                  IdProducto = dr("IdProducto").ToString.Trim()

                  sql2.Productos_U_EsCompuesto(IdProducto, True, FacturacionDescontarStockComp)

                  NombreFormula = ""

               End If

               If dr("NombreFormula").ToString.Trim() <> NombreFormula Then

                  NombreFormula = dr("NombreFormula").ToString.Trim()

                  'Si la fórmula que estoy leyendo no existe, la doy de alta.
                  dtFormulas = oFormulas.GetPorNombreExacto(IdProducto, dr("NombreFormula").ToString())

                  If dtFormulas.Rows.Count = 0 Then

                     IdFormula = oFormulas.GetIdFormulaMaximo(IdProducto)

                     'oFormulas.GrabarFormula(IdProducto, IdFormula, NombreFormula)
                     sql3.ProductosFormulas_I(IdProducto, IdFormula, NombreFormula, PorcentajeGanancia:=0)

                  Else
                     IdFormula = Integer.Parse(dtFormulas.Rows(0)("IdFormula").ToString())
                  End If

                  sql.ProductosComponentes_D(IdProducto, IdFormula)

                  '# Si la fórmula se está importando como principal, piso cualquier otra fórmula que esté marcada como predeterminada/principal (Campo IdFormula en Productos)
                  If dr.Field(Of String)("Principal") = "S" Then
                     rProductos._ActualizarFormulaDefecto(IdProducto, IdFormula)
                  ElseIf String.IsNullOrEmpty(dr("Principal").ToString()) Then

                     '# En caso de que esté vacio, verifico si el producto NO tiene fórmula por defecto. De ser asi, la agrego como fórmula por defecto. Caso contrario, no hago nada.
                     If Not IsNumeric(rProductos.GetProductoFormulaPorDefecto(IdProducto)) Then
                        rProductos._ActualizarFormulaDefecto(IdProducto, IdFormula)
                     End If
                  End If

                  '#########################################################################################
                  '# En caso que el valor de la columna Principal sea "N", no realizo ninguna acción extra #
                  '#########################################################################################
                  '-------------------------------------------------------------------------------
               End If

               dtFormulas = oFormulas.GetPorNombreExacto(dr("IdProductoComponente").ToString(), dr("NombreFormulaComponente").ToString())
               Dim IdFormulaComponente As Integer = 0
               If dtFormulas.Rows.Count <> 0 Then
                  IdFormulaComponente = Integer.Parse(dtFormulas.Rows(0)("IdFormula").ToString())
               End If
               Dim producto = rProductos._GetUnoParaM(dr.Field(Of String)("IdProductoComponente"), AccionesSiNoExisteRegistro.Vacio)
               Dim idUnidadDeMedidaProduccion = producto.IdUnidadDeMedidaProduccion
               Dim factorConversionProduccion = producto.FactorConversionProduccion
               Dim cantidadUMProduccion = Decimal.Parse(dr("Cantidad").ToString())
               Dim cantidad = cantidadUMProduccion * factorConversionProduccion

               sql.ProductosComponentes_I(IdProducto,
                                          IdFormula,
                                          dr("IdProductoComponente").ToString(),
                                          IdFormulaComponente,
                                          cantidad,
                                          segunCalculoForma:=False,
                                          idUnidadDeMedidaProduccion, cantidadUMProduccion, factorConversionProduccion)
            End If
         Next

         da.CommitTransaction()

      Catch ex As Exception
         BarraProg.Value = 0
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub GrabarComponentesProductos(idProducto As String, idFormula As Integer, componentes As DataTable, facturacionDescontarStockComp As Boolean)
      EjecutaConTransaccion(Sub() _GrabarComponentesProductos(idProducto, idFormula, componentes, facturacionDescontarStockComp))
   End Sub
   Public Sub _GrabarComponentesProductos(idProducto As String, idFormula As Integer, componentes As DataTable, facturacionDescontarStockComp As Boolean)
      Dim sql = New SqlServer.ProductosComponentes(da)
      sql.ProductosComponentes_D(idProducto, idFormula)

      For Each dr As DataRow In componentes.Rows
         sql.ProductosComponentes_I(idProducto, idFormula,
                                    dr.Field(Of String)("IdProductoComponente"), dr.Field(Of Integer?)("IdFormulaComponente").IfNull(),
                                    dr.Field(Of Decimal)("Cantidad"),
                                    dr.Field(Of Boolean)("SegunCalculoForma"),
                                    dr.Field(Of String)("IdUnidadDeMedidaProduccion"), dr.Field(Of Decimal)("CantidadUMProduccion"), dr.Field(Of Decimal)("FactorConversionProduccion"))
      Next

      'Actualizo la Propiedad "EsCompuesto" que se utiliza para filtrar en el modulo.
      Dim sql2Prod = New SqlServer.Productos(da)
      sql2Prod.Productos_U_EsCompuesto(idProducto, (componentes.Rows.Count > 0), facturacionDescontarStockComp)
   End Sub

   Public Sub GrabarComponentesCopiados(idProducto As String, idFormula As Integer, componentes As DataTable)
      EjecutaConTransaccion(Sub() _GrabarComponentesCopiados(idProducto, idFormula, componentes))
   End Sub

   Public Sub _GrabarComponentesCopiados(idProducto As String, idFormula As Integer, componentes As DataTable)
      Dim sql = New SqlServer.ProductosComponentes(da)
      sql.ProductosComponentes_D(idProducto, idFormula)
      For Each dr As DataRow In componentes.Rows
         sql.ProductosComponentes_I(idProducto, idFormula,
                                    dr.Field(Of String)("IdProductoComponente"), dr.Field(Of Integer?)("IdFormulaComponente").IfNull(),
                                    dr.Field(Of Decimal)("Cantidad"),
                                    dr.Field(Of Boolean)("SegunCalculoForma"),
                                    dr.Field(Of String)("IdUnidadDeMedidaProduccion"), dr.Field(Of Decimal)("CantidadUMProduccion"), dr.Field(Of Decimal)("FactorConversionProduccion"))
      Next
   End Sub

   Public Function GetComponentes(IdSucursal As Integer, IdProducto As String, IdFormula As Integer, idListaDePrecios As Integer) As DataTable
      Return New SqlServer.ProductosComponentes(da).GetComponentes(IdSucursal, IdProducto, IdFormula, idListaDePrecios, Publicos.PreciosConIVA)
   End Function

   Public Function GetPorProductoComponente(idSucursal As Integer, idProducto As String, idListaDePrecios As Integer) As DataTable
      Return New SqlServer.ProductosComponentes(da).GetPorProductoComponente(idSucursal, idProducto, idListaDePrecios)
   End Function

   Public Function GetProductosComponente2(idProducto As String, IdRubroPrograma As Integer, IdRubroVisita As Integer) As DataTable
      Return New SqlServer.ProductosComponentes(da).GetProductosComponente2(idProducto, IdRubroPrograma, IdRubroVisita)
   End Function

   Public Function GetProductosComponenteGastronomico(idProducto As String, IdRubroGastronomico As Integer) As DataTable
      Return New SqlServer.ProductosComponentes(da).GetProductosComponenteGastronomico(idProducto, IdRubroGastronomico)
   End Function
   'Public Function GetProdComponentes(idSucursal As Integer, idProducto As String, idListaDePrecios As Integer) As DataTable

   '   Dim sql As SqlServer.ProductosComponentes
   '   Dim dt As DataTable

   '   Try
   '      Me.da.OpenConection()
   '      Me.da.BeginTransaction()

   '      sql = New SqlServer.ProductosComponentes(da)
   '      dt = sql.GetComponentes(idSucursal, idProducto, idListaDePrecios)

   '      Me.da.CommitTransaction()

   '      Return dt
   '   Catch ex As Exception
   '      Me.da.RollbakTransaction()
   '      Throw
   '   Finally
   '      Me.da.CloseConection()
   '   End Try
   'End Function

   Public Function GetComponentesProduccion(productos As DataTable, sucursal As Integer) As DataTable
      Return EjecutaConConexion(Function() _GetComponentesProduccion(productos, sucursal))
   End Function
   Friend Function _GetComponentesProduccion(productos As DataTable, sucursal As Integer) As DataTable


      Dim sql As SqlServer.ProductosComponentes = New SqlServer.ProductosComponentes(da)
      Dim dt As DataTable = sql.GetComponentesProduccion(productos, sucursal)
      dt.Columns.Add("CantidadNec", GetType(Decimal))
      dt.Columns.Add("CantidadComp", GetType(Decimal))


      Dim segunCalculoForma As Boolean
      Dim calculadora As UltraWinCalcManager.UltraCalcManager = New UltraWinCalcManager.UltraCalcManager()
      Dim valorResultadoFormula As Decimal
      Dim formulaCalculo As String
      Dim rProdFormas As ProduccionFormas = New ProduccionFormas(da)
      Dim espmm As String
      Dim largoExtAlto As String
      Dim anchoIntBase As String


      For Each dr1 As DataRow In productos.Rows
         For Each dr As DataRow In dt.Rows
            If dr("IdProducto").ToString() = dr1("IdProducto").ToString() Then

               segunCalculoForma = Boolean.Parse(dr("SegunCalculoForma").ToString())
               formulaCalculo = dr("FormulaCalculoKilaje").ToString()

               valorResultadoFormula = 1
               If segunCalculoForma Then
                  espmm = ""
                  largoExtAlto = ""
                  anchoIntBase = ""
                  If dr1.Table.Columns.Contains("Espmm") Then
                     espmm = dr1("Espmm").ToString()
                  End If
                  If dr1.Table.Columns.Contains("LargoExtAlto") Then
                     largoExtAlto = dr1("LargoExtAlto").ToString()
                  End If
                  If dr1.Table.Columns.Contains("AnchoIntBase") Then
                     anchoIntBase = dr1("AnchoIntBase").ToString()
                  End If

                  'MD-PROD: Tomar valores nuevos de formulas
                  formulaCalculo = rProdFormas.PreparaFormulaParaEvaluar(formulaCalculo,
                                                                         espmm.ValorNumericoPorDefecto(0D),
                                                                         largoExtAlto.ValorNumericoPorDefecto(0D),
                                                                         anchoIntBase.ValorNumericoPorDefecto(0D),
                                                                         0, Nothing)
                  valorResultadoFormula = calculadora.Calculate(formulaCalculo).ToDecimal()
               End If

               dr("CantidadNec") = Decimal.Parse(dr1("Cantidad").ToString()) * Decimal.Parse(dr("NECESITOX1").ToString()) * valorResultadoFormula

               If Decimal.Parse(dr("Stock").ToString()) > Decimal.Parse(dr("CantidadNec").ToString()) Then
                  dr("CantidadComp") = 0
               Else
                  dr("CantidadComp") = Decimal.Parse(dr("CantidadNec").ToString()) - Decimal.Parse(dr("Stock").ToString())
               End If

            End If
         Next
      Next


      Dim dt1 As DataTable = dt.Clone()
      Dim idPro As String = String.Empty
      Dim dr2 As DataRow
      Dim noexiste As Boolean



      For Each dr1 As DataRow In dt.Rows
         idPro = dr1("IDPRODUCTOCOMPONENTE").ToString()
         If dt1.Rows.Count = 0 Then
            dr2 = dt1.NewRow()
            dr2.ItemArray = dr1.ItemArray
            dt1.Rows.Add(dr2)
            dt1.AcceptChanges()
         Else
            For Each dr As DataRow In dt1.Rows
               If dr("IDPRODUCTOCOMPONENTE").ToString() <> idPro Then
                  noexiste = True
               Else
                  dr("CantidadNec") = Decimal.Parse(dr("CantidadNec").ToString()) + Decimal.Parse(dr1("CantidadNec").ToString())
                  If Decimal.Parse(dr("Stock").ToString()) > Decimal.Parse(dr("CantidadNec").ToString()) Then
                     dr("CantidadComp") = 0
                  Else
                     dr("CantidadComp") = Decimal.Parse(dr("CantidadNec").ToString()) - Decimal.Parse(dr("Stock").ToString())

                  End If
                  noexiste = False
                  Exit For
               End If
            Next
            If noexiste Then
               dr2 = dt1.NewRow()
               dr2.ItemArray = dr1.ItemArray
               dt1.Rows.Add(dr2)
               dt1.AcceptChanges()
            End If
         End If
      Next

      Return dt1

   End Function

   Public Function GetPrecioCosto(idSucursal As Integer, idProducto As String, IdFormula As Integer) As Decimal

      Try
         Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA()
         Me.da.OpenConection()

         Dim sql As SqlServer.ProductosComponentes
         Dim dt As DataTable

         Dim idListaDePrecios As Integer = 0  'Lista base --- No aplica

         Dim produ As Entidades.Producto = New Reglas.Productos(da).GetUno(idProducto, False, False)

         sql = New SqlServer.ProductosComponentes(da)
         dt = sql.GetComponentes(idSucursal, idProducto, IdFormula, idListaDePrecios, blnPreciosConIVA)

         Dim PrecioCosto As Decimal = 0

         'For Each dr As DataRow In dt.Rows
         '   PrecioCosto += (Decimal.Parse(dr("PrecioCosto").ToString()) * Decimal.Parse(dr("Cantidad").ToString()))
         'Next

         Dim calcu As Reglas.PreciosCalculos = New PreciosCalculos()
         PrecioCosto = calcu.GetPrecioCosto(dt, Publicos.ProduccionDivideTamano, produ.Moneda.FactorConversion)

         Return PrecioCosto

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetPrecioVenta(idSucursal As Integer, idProducto As String, idFormula As Integer, idListaDePrecios As Integer) As Decimal

      Try
         Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA()
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ProductosComponentes
         Dim dt As DataTable

         sql = New SqlServer.ProductosComponentes(da)
         dt = sql.GetComponentes(idSucursal, idProducto, idFormula, idListaDePrecios, blnPreciosConIVA)

         Dim PrecioVenta As Decimal = 0

         For Each dr As DataRow In dt.Rows
            PrecioVenta += (Decimal.Parse(dr("PrecioVenta").ToString()) * Decimal.Parse(dr("Cantidad").ToString()))
         Next

         Me.da.CommitTransaction()

         Return PrecioVenta

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetInforme(IdSucursal As Integer, IdProducto As String, idFormula As Integer, idListaDePrecios As Integer,
                              IdProductoComponente As String, EsProducto As Boolean, marcas As Entidades.Marca(), rubros As Entidades.Rubro()) As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ProductosComponentes = New SqlServer.ProductosComponentes(da)

         Dim dt As DataTable = sql.GetInforme(IdSucursal, IdProducto, idFormula, idListaDePrecios, IdProductoComponente, EsProducto, marcas, rubros)

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Sub CopiarComponentesFormula(idProducto As String, idFormulaOrigen As Integer, idFormulaDestino As Integer)
      Dim sql = New SqlServer.ProductosComponentes(da)
      sql.CopiarComponentesFormula(idProducto, idFormulaOrigen, idFormulaDestino)
   End Sub

#End Region

   'Public Function CalculaPreciosSegunFormula(idSucursal As Integer,
   '                                           idProducto As String,
   '                                           idFormula As Integer,
   '                                           idListaDePrecios As Integer,
   '                                           espmm As String, largoExtAlto As String, anchoIntBase As String,
   '                                           dtComponentes As DataTable,
   '                                           cotizacionDolar As String) As Entidades.PreciosProducto
   '   Dim espmmDec As Decimal = 0
   '   Dim largoExtAltoDec As Decimal = 0
   '   Dim anchoIntBaseDec As Decimal = 0
   '   Dim cotizacionDolarDec As Decimal = 0

   '   Decimal.TryParse(espmm, espmmDec)
   '   Decimal.TryParse(largoExtAlto, largoExtAltoDec)
   '   Decimal.TryParse(anchoIntBase, anchoIntBaseDec)
   '   Decimal.TryParse(cotizacionDolar, cotizacionDolarDec)
   '   Return CalculaPreciosSegunFormula(idSucursal, idProducto, idFormula, idListaDePrecios, espmmDec, largoExtAltoDec, anchoIntBaseDec, dtComponentes, cotizacionDolarDec)
   'End Function

   Public Function CalculaPreciosSegunFormula(idSucursal As Integer,
                                              idProducto As String,
                                              idFormula As Integer,
                                              idListaDePrecios As Integer,
                                              espmm As Decimal, largoExtAlto As Decimal, anchoIntBase As Decimal,
                                              architrave As Decimal, modeloForma As Entidades.ProduccionModeloForma,
                                              dtComponentes As DataTable,
                                              cotizacionDolar As Decimal) As Entidades.PreciosProducto
      Dim resultado As Entidades.PreciosProducto = New Entidades.PreciosProducto(idSucursal, idProducto, idListaDePrecios)
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA()
      If dtComponentes Is Nothing Then
         dtComponentes = New SqlServer.ProductosComponentes(da).GetComponentes(idSucursal, idProducto, idFormula, idListaDePrecios, blnPreciosConIVA)
      End If
      'Dim dtComponentes As DataTable = New SqlServer.ProductosComponentes(da).GetComponentes(idSucursal, idProducto, idFormula, idListaDePrecios, blnPreciosConIVA)

      Using calculadora = New UltraWinCalcManager.UltraCalcManager()
         Dim resultadoFormula As CalcEngine.UltraCalcValue

         Dim rProdFormas = New ProduccionFormas(da)

         For Each drComponentes As DataRow In dtComponentes.Rows
            Dim segunCalculoForma = Boolean.Parse(drComponentes("SegunCalculoForma").ToString())
            Dim precioCostoSinIVA = Decimal.Parse(drComponentes("PrecioCostoSinIVA").ToString())
            Dim precioCostoConIVA = Decimal.Parse(drComponentes("PrecioCostoConIVA").ToString())
            Dim precioVentaSinIVA = Decimal.Parse(drComponentes("PrecioVentaSinIVA").ToString())
            Dim precioVentaConIVA = Decimal.Parse(drComponentes("PrecioVentaConIVA").ToString())

            If drComponentes("IdMoneda").ToString() = "2" Then
               precioCostoSinIVA = precioCostoSinIVA * cotizacionDolar
               precioCostoConIVA = precioCostoConIVA * cotizacionDolar
               precioVentaSinIVA = precioVentaSinIVA * cotizacionDolar
               precioVentaConIVA = precioVentaConIVA * cotizacionDolar
            End If

            Dim cantidad = Decimal.Parse(drComponentes("Cantidad").ToString())

            If segunCalculoForma Then
               Dim formulaCalculo = drComponentes("FormulaCalculoKilaje").ToString()
               If String.IsNullOrWhiteSpace(formulaCalculo) Then
                  Throw New Exception(String.Format("No es posible determinar los precios del producto '{0}' porque el componente '{1}' está configurado como Según Calculo y el mismo no tiene forma definida en el ABM de productos." + Environment.NewLine + Environment.NewLine +
                                                    "Verifique la configuración del componente '{1}' y vuelva a intentar.", idProducto, drComponentes("IdProductoComponente")))
               End If

               formulaCalculo = rProdFormas.PreparaFormulaParaEvaluar(formulaCalculo, espmm, largoExtAlto, anchoIntBase, architrave, modeloForma)
               resultadoFormula = calculadora.Calculate(formulaCalculo)

               resultado.PrecioCostoSinIVA += precioCostoSinIVA * cantidad * resultadoFormula.ToDecimal()
               resultado.PrecioCostoConIVA += precioCostoConIVA * cantidad * resultadoFormula.ToDecimal()
               resultado.PrecioVentaSinIVA += precioVentaSinIVA * cantidad * resultadoFormula.ToDecimal()
               resultado.PrecioVentaConIVA += precioVentaConIVA * cantidad * resultadoFormula.ToDecimal()
            Else
               resultado.PrecioCostoSinIVA += precioCostoSinIVA * cantidad
               resultado.PrecioCostoConIVA += precioCostoConIVA * cantidad
               resultado.PrecioVentaSinIVA += precioVentaSinIVA * cantidad
               resultado.PrecioVentaConIVA += precioVentaConIVA * cantidad
            End If
         Next
      End Using

      Return resultado
   End Function

   Public Function GetParaSincronizacionMovil(idRubro As Integer, activo As Boolean?, publicarEnWeb As Boolean?) As DataTable
      Return New SqlServer.ProductosComponentes(da).GetParaSincronizacionMovil(idRubro, activo, publicarEnWeb)
   End Function

End Class