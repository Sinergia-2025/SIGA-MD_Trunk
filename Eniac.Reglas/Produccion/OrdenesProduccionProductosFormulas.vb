Public Class OrdenesProduccionProductosFormulas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.OrdenProduccionProductoFormula.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.OrdenProduccionProductoFormula)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.OrdenProduccionProductoFormula)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.OrdenProduccionProductoFormula)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException("GetAll() no está implementado en OrdenesProduccionProductosFormulas")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer,
                                    idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                    idProducto As String, orden As Integer, soloMateriaPrima As Boolean) As DataTable
      Return GetSql().OrdenesProduccionProductosFormulas_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                  idProducto, orden, soloMateriaPrima)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.OrdenesProduccionProductosFormulas
      Return New SqlServer.OrdenesProduccionProductosFormulas(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.OrdenProduccionProductoFormula, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            sqlC.OrdenesProduccionProductosFormulas_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroOrdenProduccion,
                                                      en.IdProducto, en.Orden, en.IdProductoElaborado, en.IdUnicoNodoProductoElaborado,
                                                      en.IdProductoComponente, en.IdUnicoNodoProductoComponente, en.IdFormula, en.SecuenciaFormula,
                                                      en.NombreProductoElaborado, en.NombreProductoComponente, en.NombreFormula,
                                                      en.PrecioCosto, en.PrecioVenta,
                                                      en.Cantidad, en.CantidadEnFormula, en.SegunCalculoForma,
                                                      en.ImporteCosto, en.ImporteVenta, en.FormulaCalculoKilaje)
         Case TipoSP._U
            Throw New NotImplementedException("UPDATE de tabla OrdenesProduccionProductosFormulas no implementado")
         Case TipoSP._D
            sqlC.OrdenesProduccionProductosFormulas_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroOrdenProduccion,
                                                      en.IdProducto, en.Orden, en.IdProductoElaborado, en.IdUnicoNodoProductoElaborado,
                                                      en.IdProductoComponente, en.IdUnicoNodoProductoComponente, en.IdFormula, en.SecuenciaFormula)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.OrdenProduccionProductoFormula, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.OrdenProduccionProductoFormula.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.OrdenProduccionProductoFormula.Columnas.CentroEmisor.ToString())
         .NumeroOrdenProduccion = dr.Field(Of Integer)(Entidades.OrdenProduccionProductoFormula.Columnas.NumeroOrdenProduccion.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.IdProducto.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.OrdenProduccionProductoFormula.Columnas.Orden.ToString())
         .IdProductoElaborado = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.IdProductoElaborado.ToString())
         .IdUnicoNodoProductoElaborado = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.IdUnicoNodoProductoElaborado.ToString())
         .IdProductoComponente = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.IdProductoComponente.ToString())
         .IdUnicoNodoProductoComponente = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.IdUnicoNodoProductoComponente.ToString())
         .IdFormula = dr.Field(Of Integer)(Entidades.OrdenProduccionProductoFormula.Columnas.IdFormula.ToString())
         .SecuenciaFormula = dr.Field(Of Integer)(Entidades.OrdenProduccionProductoFormula.Columnas.SecuenciaFormula.ToString())

         .NombreProductoElaborado = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.NombreProductoElaborado.ToString())
         .NombreProductoComponente = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.NombreProductoComponente.ToString())
         .NombreFormula = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.NombreFormula.ToString())

         .PrecioCosto = dr.Field(Of Decimal)(Entidades.OrdenProduccionProductoFormula.Columnas.PrecioCosto.ToString())
         .PrecioVenta = dr.Field(Of Decimal)(Entidades.OrdenProduccionProductoFormula.Columnas.PrecioVenta.ToString())
         .Cantidad = dr.Field(Of Decimal)(Entidades.OrdenProduccionProductoFormula.Columnas.Cantidad.ToString())
         .CantidadEnFormula = dr.Field(Of Decimal)(Entidades.OrdenProduccionProductoFormula.Columnas.CantidadEnFormula.ToString())
         .SegunCalculoForma = dr.Field(Of Boolean)(Entidades.OrdenProduccionProductoFormula.Columnas.SegunCalculoForma.ToString())

         .ImporteCosto = dr.Field(Of Decimal)(Entidades.OrdenProduccionProductoFormula.Columnas.ImporteCosto.ToString())
         .ImporteVenta = dr.Field(Of Decimal)(Entidades.OrdenProduccionProductoFormula.Columnas.ImporteVenta.ToString())
         .FormulaCalculoKilaje = dr.Field(Of String)(Entidades.OrdenProduccionProductoFormula.Columnas.FormulaCalculoKilaje.ToString())

         .IdDepositoDefecto = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdDepositoDefecto.ToString())
         .IdUbicacionDefecto = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdUbicacionDefecto.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Overridable Sub Inserta(entidad As Entidades.OrdenProduccionProductoFormula)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overridable Sub Actualiza(entidad As Entidades.OrdenProduccionProductoFormula)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Borra(entidad As Entidades.OrdenProduccionProductoFormula)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub InsertaDesdeOrdenProduccionProducto(pp As Entidades.OrdenProduccionProducto)
      For Each ppf In pp.OrdenesProduccionProductosFormulas
         ppf.IdSucursal = pp.IdSucursal
         ppf.IdTipoComprobante = pp.IdTipoComprobante
         ppf.Letra = pp.Letra
         ppf.CentroEmisor = pp.CentroEmisor
         ppf.NumeroOrdenProduccion = pp.NumeroOrdenProduccion
         ppf.IdProducto = pp.IdProducto
         ppf.Orden = pp.Orden
         ppf.IdFormula = pp.IdFormula
         ppf.NombreFormula = pp.NombreFormula
         Inserta(ppf)
      Next
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                          idProducto As String, orden As Integer,
                          idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                          idProductoComponente As String, idUnicoNodoProductoComponente As String,
                          idFormula As Integer, secuenciaFormula As Integer) As Entidades.OrdenProduccionProductoFormula
      Return GetUno(idSucursal,
                    idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                    idProducto, orden,
                    idProductoElaborado, idUnicoNodoProductoElaborado,
                    idProductoComponente, idUnicoNodoProductoComponente,
                    idFormula, secuenciaFormula,
                    AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                          idProducto As String, orden As Integer,
                          idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                          idProductoComponente As String, idUnicoNodoProductoComponente As String,
                          idFormula As Integer, secuenciaFormula As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.OrdenProduccionProductoFormula
      Using dt = GetSql().OrdenesProduccionProductosFormulas_G1(idSucursal,
                                                      idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                      idProducto, orden,
                                                      idProductoElaborado, idUnicoNodoProductoElaborado,
                                                      idProductoComponente, idUnicoNodoProductoComponente,
                                                      idFormula, secuenciaFormula)
         Return CargaEntidad(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.OrdenProduccionProductoFormula(),
                             accion, Function() String.Format("No se encuentra la formula del Orde de Producción: {0}/{1} {2} {3:0000}-{4:00000000} {5}/{6} {7}({8}), {9}({10}) {11} {12}",
                                                              idSucursal,
                                                              idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                              idProducto, orden,
                                                              idProductoElaborado, idUnicoNodoProductoElaborado,
                                                              idProductoComponente, idUnicoNodoProductoComponente,
                                                              idFormula, secuenciaFormula))
      End Using
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                            idProducto As String, orden As Integer, soloMateriaPrima As Boolean) As List(Of Entidades.OrdenProduccionProductoFormula)
      Using dt = GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, idProducto, orden, soloMateriaPrima)
         Return CargaLista(dt)
      End Using
   End Function

   Public Overloads Function CargaLista(dt As DataTable) As List(Of Entidades.OrdenProduccionProductoFormula)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.OrdenProduccionProductoFormula())
   End Function

#End Region
End Class