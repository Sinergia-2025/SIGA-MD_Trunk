Public Class PedidosProductosFormulas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.PedidoProductoFormula.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(entidad))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(entidad))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(entidad))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Throw New NotImplementedException("GetAll() no está implementado en PedidosProductosFormulas")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer,
                                    idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                                    idProducto As String, orden As Integer) As System.Data.DataTable
      Return GetSql().PedidosProductosFormulas_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                  idProducto, orden)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.PedidosProductosFormulas
      Return New SqlServer.PedidosProductosFormulas(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.PedidoProductoFormula, tipo As TipoSP)
      'Dim en As Entidades.PedidoProductoFormula = DirectCast(entidad, Entidades.PedidoProductoFormula)

      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            sqlC.PedidosProductosFormulas_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroPedido,
                                            en.IdProducto, en.Orden, en.IdProductoElaborado, en.IdUnicoNodoProductoElaborado,
                                            en.IdProductoComponente, en.IdUnicoNodoProductoComponente, en.IdFormula, en.SecuenciaFormula,
                                            en.NombreProductoElaborado, en.NombreProductoComponente, en.NombreFormula,
                                            en.PrecioCosto, en.PrecioVenta,
                                            en.Cantidad, en.CantidadEnFormula, en.SegunCalculoForma,
                                            en.ImporteCosto, en.ImporteVenta, en.FormulaCalculoKilaje)
         Case TipoSP._U
            Throw New NotImplementedException("UPDATE de tabla PedidosProductosFormulas no implementado")
         Case TipoSP._D
            sqlC.PedidosProductosFormulas_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroPedido,
                                            en.IdProducto, en.Orden, en.IdProductoElaborado, en.IdUnicoNodoProductoElaborado,
                                            en.IdProductoComponente, en.IdUnicoNodoProductoComponente, en.IdFormula, en.SecuenciaFormula)
      End Select

   End Sub

   'Private Function CargarUno(dr As DataRow) As Entidades.PedidoProductoFormula
   '   Dim o As Entidades.PedidoProductoFormula = New Entidades.PedidoProductoFormula()
   '   CargarUno(o, dr)
   '   Return o
   'End Function
   Private Sub CargarUno(o As Entidades.PedidoProductoFormula, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.PedidoProductoFormula.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.PedidoProductoFormula.Columnas.CentroEmisor.ToString())
         .NumeroPedido = dr.Field(Of Integer)(Entidades.PedidoProductoFormula.Columnas.NumeroPedido.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.IdProducto.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.PedidoProductoFormula.Columnas.Orden.ToString())
         .IdProductoElaborado = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.IdProductoElaborado.ToString())
         .IdUnicoNodoProductoElaborado = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.IdUnicoNodoProductoElaborado.ToString())
         .IdProductoComponente = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.IdProductoComponente.ToString())
         .IdUnicoNodoProductoComponente = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.IdUnicoNodoProductoComponente.ToString())
         .IdFormula = dr.Field(Of Integer)(Entidades.PedidoProductoFormula.Columnas.IdFormula.ToString())
         .SecuenciaFormula = dr.Field(Of Integer)(Entidades.PedidoProductoFormula.Columnas.SecuenciaFormula.ToString())

         .NombreProductoElaborado = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.NombreProductoElaborado.ToString())
         .NombreProductoComponente = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.NombreProductoComponente.ToString())
         .NombreFormula = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.NombreFormula.ToString())

         .PrecioCosto = dr.Field(Of Decimal)(Entidades.PedidoProductoFormula.Columnas.PrecioCosto.ToString())
         .PrecioVenta = dr.Field(Of Decimal)(Entidades.PedidoProductoFormula.Columnas.PrecioVenta.ToString())
         .Cantidad = dr.Field(Of Decimal)(Entidades.PedidoProductoFormula.Columnas.Cantidad.ToString())
         .CantidadEnFormula = dr.Field(Of Decimal)(Entidades.PedidoProductoFormula.Columnas.CantidadEnFormula.ToString())
         .SegunCalculoForma = dr.Field(Of Boolean)(Entidades.PedidoProductoFormula.Columnas.SegunCalculoForma.ToString())

         .ImporteCosto = dr.Field(Of Decimal)(Entidades.PedidoProductoFormula.Columnas.ImporteCosto.ToString())
         .ImporteVenta = dr.Field(Of Decimal)(Entidades.PedidoProductoFormula.Columnas.ImporteVenta.ToString())
         .FormulaCalculoKilaje = dr.Field(Of String)(Entidades.PedidoProductoFormula.Columnas.FormulaCalculoKilaje.ToString())

         .IdDepositoDefecto = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdDepositoDefecto.ToString())
         .IdUbicacionDefecto = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdUbicacionDefecto.ToString())

         ''If dr.Table.Columns.Contains(Entidades.PedidoProductoFormula.Columnas.NombreProductoComponente.ToString()) Then
         ''ElseIf dr.Table.Columns.Contains(Entidades.Producto.Columnas.NombreProducto.ToString()) Then
         ''   .NombreProductoComponente = dr(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
         ''End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Overridable Sub Inserta(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoFormula), TipoSP._I)
   End Sub

   Public Overridable Sub Actualiza(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoFormula), TipoSP._U)
   End Sub

   Public Sub Borra(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.PedidoProductoFormula), TipoSP._D)
   End Sub

   Public Sub InsertaDesdePedidoProducto(pp As Entidades.PedidoProducto)
      For Each ppf As Entidades.PedidoProductoFormula In pp.PedidosProductosFormulas
         ppf.IdSucursal = pp.IdSucursal
         ppf.IdTipoComprobante = pp.IdTipoComprobante
         ppf.Letra = pp.Letra
         ppf.CentroEmisor = pp.CentroEmisor
         ppf.NumeroPedido = pp.NumeroPedido
         ppf.IdProducto = pp.IdProducto
         ppf.Orden = pp.Orden
         ppf.IdFormula = pp.IdFormula
         ppf.NombreFormula = pp.NombreFormula
         Inserta(ppf)
      Next
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          idProducto As String, orden As Integer,
                          idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                          idProductoComponente As String, idUnicoNodoProductoComponente As String,
                          idFormula As Integer, secuenciaFormula As Integer) As Entidades.PedidoProductoFormula
      Return GetUno(idSucursal,
                    idTipoComprobante, letra, centroEmisor, numeroPedido,
                    idProducto, orden,
                    idProductoElaborado, idUnicoNodoProductoElaborado,
                    idProductoComponente, idUnicoNodoProductoComponente,
                    idFormula, secuenciaFormula,
                    AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                          idProducto As String, orden As Integer,
                          idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                          idProductoComponente As String, idUnicoNodoProductoComponente As String,
                          idFormula As Integer, secuenciaFormula As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.PedidoProductoFormula
      Using dt = GetSql().PedidosProductosFormulas_G1(idSucursal,
                                                      idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                      idProducto, orden,
                                                      idProductoElaborado, idUnicoNodoProductoElaborado,
                                                      idProductoComponente, idUnicoNodoProductoComponente,
                                                      idFormula, secuenciaFormula)
         Return CargaEntidad(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoProductoFormula(),
                             accion, Function() String.Format("No se encuentra la formula del Pedido: {0}/{1} {2} {3:0000}-{4:00000000} {5}/{6} {7}({8}), {9}({10}) {11} {12}",
                                                              idSucursal,
                                                              idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                              idProducto, orden,
                                                              idProductoElaborado, idUnicoNodoProductoElaborado,
                                                              idProductoComponente, idUnicoNodoProductoComponente,
                                                              idFormula, secuenciaFormula))
         'Return If(dt.Rows.Count = 0, New Entidades.PedidoProductoFormula(), CargarUno(dt.Rows(0)))
      End Using
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
                            idProducto As String, orden As Integer) As List(Of Entidades.PedidoProductoFormula)
      Using dt = GetSql().PedidosProductosFormulas_GA(idSucursal,
                                                      idTipoComprobante, letra, centroEmisor, numeroPedido,
                                                      idProducto, orden)
         Return CargaLista(dt)
      End Using
   End Function

   Public Overloads Function CargaLista(dt As DataTable) As List(Of Entidades.PedidoProductoFormula)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PedidoProductoFormula())
   End Function

#End Region
End Class