Public Class VentasProductosFormulas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.VentaProductoFormula.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.VentaProductoFormula)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.VentaProductoFormula)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.VentaProductoFormula)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException("GetAll() no está implementado en VentasProductosFormulas")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                    idProducto As String, orden As Integer) As DataTable
      Return GetSql().VentasProductosFormulas_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden)
   End Function
#End Region

#Region "Metodos Privados"

   Private Function GetSql() As SqlServer.VentasProductosFormulas
      Return New SqlServer.VentasProductosFormulas(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.VentaProductoFormula, tipo As TipoSP)
      Dim sqlC = GetSql()
      Dim rLotes = New VentasProductosFormulasLotes(da)
      Dim rNrosSerie = New VentasProductosFormulasNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.VentasProductosFormulas_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                           en.IdProducto, en.Orden, en.IdProductoComponente, en.IdFormula,
                                           en.NombreProductoComponente, en.NombreFormula, en.PrecioCosto, en.PrecioVenta,
                                           en.Cantidad, en.SegunCalculoForma)
            If Not en.Lotes.AnySecure() And en.SeleccionMultiple IsNot Nothing Then
               If en.SeleccionMultiple.Lotes.AnySecure() Then
                  en.Lotes = rLotes.Convert(en.SeleccionMultiple)
               End If
            End If
            If Not en.NrosSerie.AnySecure() And en.SeleccionMultiple IsNot Nothing Then
               If en.SeleccionMultiple.NrosSerie.AnySecure() Then
                  en.NrosSerie = rNrosSerie.Convert(en.SeleccionMultiple)
               End If
            End If
            rLotes._Insertar(en)
            rNrosSerie._Insertar(en)
         Case TipoSP._U
            Throw New NotImplementedException("UPDATE de tabla VentasProductosFormulas no implementado")
         Case TipoSP._D
            rLotes._Borrar(en)
            rNrosSerie._Borrar(en)
            sqlC.VentasProductosFormulas_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                           en.IdProducto, en.Orden, en.IdProductoComponente, en.IdFormula)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.VentaProductoFormula, dr As DataRow)
      With o
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.IdSucursal.ToString()) Then
            .IdSucursal = Integer.Parse(dr(Entidades.VentaProductoFormula.Columnas.IdSucursal.ToString()).ToString())
         End If
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.IdTipoComprobante.ToString()) Then
            .IdTipoComprobante = dr(Entidades.VentaProductoFormula.Columnas.IdTipoComprobante.ToString()).ToString()
         End If
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.Letra.ToString()) Then
            .Letra = dr(Entidades.VentaProductoFormula.Columnas.Letra.ToString()).ToString()
         End If
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.CentroEmisor.ToString()) Then
            .CentroEmisor = Integer.Parse(dr(Entidades.VentaProductoFormula.Columnas.CentroEmisor.ToString()).ToString())
         End If
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.NumeroComprobante.ToString()) Then
            .NumeroComprobante = Long.Parse(dr(Entidades.VentaProductoFormula.Columnas.NumeroComprobante.ToString()).ToString())
         End If
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.IdProducto.ToString()) Then
            .IdProducto = dr(Entidades.VentaProductoFormula.Columnas.IdProducto.ToString()).ToString()
         End If
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.Orden.ToString()) Then
            .Orden = Integer.Parse(dr(Entidades.VentaProductoFormula.Columnas.Orden.ToString()).ToString())
         End If
         .IdProductoComponente = dr(Entidades.VentaProductoFormula.Columnas.IdProductoComponente.ToString()).ToString()
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.IdFormula.ToString()) Then
            .IdFormula = dr.Field(Of Integer?)(Entidades.VentaProductoFormula.Columnas.IdFormula.ToString()).IfNull()
         End If
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.NombreProductoComponente.ToString()) Then
            .NombreProductoComponente = dr(Entidades.VentaProductoFormula.Columnas.NombreProductoComponente.ToString()).ToString()
         ElseIf dr.Table.Columns.Contains(Entidades.Producto.Columnas.NombreProducto.ToString()) Then
            .NombreProductoComponente = dr(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
         End If
         If dr.Table.Columns.Contains(Entidades.VentaProductoFormula.Columnas.NombreFormula.ToString()) Then
            .NombreFormula = dr(Entidades.VentaProductoFormula.Columnas.NombreFormula.ToString()).ToString()
         End If
         .PrecioCosto = Decimal.Parse(dr(Entidades.VentaProductoFormula.Columnas.PrecioCosto.ToString()).ToString())
         .PrecioVenta = Decimal.Parse(dr(Entidades.VentaProductoFormula.Columnas.PrecioVenta.ToString()).ToString())
         .Cantidad = Decimal.Parse(dr(Entidades.VentaProductoFormula.Columnas.Cantidad.ToString()).ToString())
         .SegunCalculoForma = Boolean.Parse(dr(Entidades.VentaProductoFormula.Columnas.SegunCalculoForma.ToString()).ToString())

         If dr.Table.Columns.Contains("SeleccionMultiple") Then
            .SeleccionMultiple = dr.Field(Of Entidades.SeleccionMultipleProducto)("SeleccionMultiple").Ubicaciones.FirstOrDefault()
         End If

         .Lotes = New VentasProductosFormulasLotes(da).GetTodos(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, .IdProducto, .Orden, .IdProductoComponente, .IdFormula)
         .NrosSerie = New VentasProductosFormulasNrosSerie(da).GetTodos(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante, .IdProducto, .Orden, .IdProductoComponente, .IdFormula)

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Entidades.VentaProductoFormula)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.VentaProductoFormula)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.VentaProductoFormula)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub InsertaDesdeVentaProducto(pp As Entidades.VentaProducto)
      For Each ppf As Entidades.VentaProductoFormula In pp.VentasProductosFormulas
         ppf.IdSucursal = pp.IdSucursal
         ppf.IdTipoComprobante = pp.TipoComprobante
         ppf.Letra = pp.Letra
         ppf.CentroEmisor = pp.CentroEmisor
         ppf.NumeroComprobante = pp.NumeroComprobante
         ppf.IdProducto = pp.IdProducto
         ppf.Orden = pp.Orden
         ppf.IdFormula = pp.IdFormula
         ppf.NombreFormula = pp.NombreFormula
         _Insertar(ppf)
      Next
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                        idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As DataTable
      Return GetSql().VentasProductosFormulas_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As Entidades.VentaProductoFormula
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.VentaProductoFormula
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaProductoFormula(),
                          accion, Function() String.Format("No existe {0}/{1} {2} {3:0000}-{4:00000000} Ln: {6} - Prod: {5} - Comp: {7} - Formula: {8}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula))
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                            idProducto As String, orden As Integer) As List(Of Entidades.VentaProductoFormula)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden))
   End Function
   <Obsolete("Usar GetAll")>
   Public Function GetFormulas(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProducto As String, orden As Integer) As DataTable
      Return GetSql().VentasProductosFormulas_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden)
   End Function
   Public Overloads Function CargaLista(dt As DataTable) As List(Of Entidades.VentaProductoFormula)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaProductoFormula())
   End Function

#End Region
End Class