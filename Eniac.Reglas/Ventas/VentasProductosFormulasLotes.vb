Public Class VentasProductosFormulasLotes
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.VentaProductoFormulaLote.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.VentaProductoFormulaLote)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.VentaProductoFormulaLote)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.VentaProductoFormulaLote)))
   End Sub

   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException("GetAll() no está implementado en VentasProductosFormulasLotes")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                    idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As DataTable
      Return GetSQL().VentasProductosFormulasLotes_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                      idProducto, orden, idProductoComponente, idFormula)
   End Function
#End Region

#Region "Metodos Privados"

   Private Function GetSQL() As SqlServer.VentasProductosFormulasLotes
      Return New SqlServer.VentasProductosFormulasLotes(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.VentaProductoFormulaLote, tipo As TipoSP)
      Dim sqlC = New SqlServer.VentasProductosFormulasLotes(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.VentasProductosFormulasLotes_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                                en.IdProducto, en.Orden, en.IdProductoComponente, en.IdFormula, en.IdLote,
                                                en.FechaVencimiento, en.Cantidad, en.IdDeposito, en.IdUbicacion)
         Case TipoSP._U
            Throw New NotImplementedException("UPDATE de tabla VentasProductosFormulasLotes no implementado")
         Case TipoSP._D
            sqlC.VentasProductosFormulasLotes_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                                en.IdProducto, en.Orden, en.IdProductoComponente, en.IdFormula, en.IdLote)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.VentaProductoFormulaLote, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.VentaProductoFormulaLote.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.VentaProductoFormulaLote.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.VentaProductoFormulaLote.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.VentaProductoFormulaLote.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.VentaProductoFormulaLote.Columnas.NumeroComprobante.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.VentaProductoFormulaLote.Columnas.IdProducto.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.VentaProductoFormulaLote.Columnas.Orden.ToString())

         .IdProductoComponente = dr.Field(Of String)(Entidades.VentaProductoFormulaLote.Columnas.IdProductoComponente.ToString())
         .IdFormula = dr.Field(Of Integer)(Entidades.VentaProductoFormulaLote.Columnas.IdFormula.ToString())
         .IdLote = dr.Field(Of String)(Entidades.VentaProductoFormulaLote.Columnas.IdLote.ToString())

         .FechaVencimiento = dr.Field(Of Date?)(Entidades.VentaProductoFormulaLote.Columnas.FechaVencimiento.ToString())

         .Cantidad = dr.Field(Of Decimal)(Entidades.VentaProductoFormulaLote.Columnas.Cantidad.ToString())

         .IdDeposito = dr.Field(Of Integer)(Entidades.VentaProductoFormulaLote.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.VentaProductoFormulaLote.Columnas.IdUbicacion.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.VentaProductoFormulaLote)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.VentaProductoFormulaLote)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.VentaProductoFormulaLote)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(pp As Entidades.VentaProductoFormula)
      For Each ppf In pp.Lotes
         ppf.IdSucursal = pp.IdSucursal
         ppf.IdTipoComprobante = pp.IdTipoComprobante
         ppf.Letra = pp.Letra
         ppf.CentroEmisor = pp.CentroEmisor
         ppf.NumeroComprobante = pp.NumeroComprobante
         ppf.IdProducto = pp.IdProducto
         ppf.Orden = pp.Orden
         ppf.IdFormula = pp.IdFormula
         ppf.IdProductoComponente = pp.IdProductoComponente
         _Insertar(ppf)
      Next
   End Sub
   Public Function Convert(pp As Entidades.SeleccionMultipleUbicaciones) As List(Of Entidades.VentaProductoFormulaLote)
      Return pp.Lotes.ConvertAll(Function(l) New Entidades.VentaProductoFormulaLote() With {
                                                      .IdLote = l.IdLote,
                                                      .FechaVencimiento = l.FechaVencimiento,
                                                      .Cantidad = l.Cantidad,
                                                      .IdDeposito = l.IdDeposito,
                                                      .IdUbicacion = l.IdUbicacion
                                                   })
   End Function
   Public Sub _Borrar(pp As Entidades.VentaProductoFormula)
      _Borrar(New Entidades.VentaProductoFormulaLote() With {
               .IdSucursal = pp.IdSucursal,
               .IdTipoComprobante = pp.IdTipoComprobante,
               .Letra = pp.Letra,
               .CentroEmisor = pp.CentroEmisor,
               .NumeroComprobante = pp.NumeroComprobante,
               .IdProducto = pp.IdProducto,
               .Orden = pp.Orden,
               .IdProductoComponente = pp.IdProductoComponente,
               .IdFormula = pp.IdFormula
            })
   End Sub
   Public Sub _Borrar(pp As Entidades.VentaProducto)
      _Borrar(New Entidades.VentaProductoFormulaLote() With {
               .IdSucursal = pp.IdSucursal,
               .IdTipoComprobante = pp.TipoComprobante,
               .Letra = pp.Letra,
               .CentroEmisor = pp.CentroEmisor,
               .NumeroComprobante = pp.NumeroComprobante,
               .IdProducto = pp.IdProducto,
               .Orden = pp.Orden
            })
   End Sub
   Public Sub _Borrar(pp As Entidades.Venta)
      _Borrar(New Entidades.VentaProductoFormulaLote() With {
               .IdSucursal = pp.IdSucursal,
               .IdTipoComprobante = pp.TipoComprobante.IdTipoComprobante,
               .Letra = pp.LetraComprobante,
               .CentroEmisor = pp.CentroEmisor,
               .NumeroComprobante = pp.NumeroComprobante
            })
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                        idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, idLote As String) As DataTable
      Return GetSQL().VentasProductosFormulasLotes_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                      idProducto, orden, idProductoComponente, idFormula, idLote)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, idLote As String) As Entidades.VentaProductoFormulaLote
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula, idLote, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, idLote As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.VentaProductoFormulaLote
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula, idLote),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaProductoFormulaLote(),
                          accion, Function() String.Format("No existe Lote {9} en el comprobante {0}/{1} {2} {3:0000}-{4:00000000} Ln: {6} - Prod: {5} - Comp: {7} - Formula: {8}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula, idLote))
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                            idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As List(Of Entidades.VentaProductoFormulaLote)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                               idProducto, orden, idProductoComponente, idFormula),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaProductoFormulaLote())
   End Function
#End Region
End Class