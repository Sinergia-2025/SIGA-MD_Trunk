Public Class VentasProductosFormulasNrosSerie
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.VentaProductoFormulaNroSerie.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.VentaProductoFormulaNroSerie)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.VentaProductoFormulaNroSerie)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.VentaProductoFormulaNroSerie)))
   End Sub

   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException("GetAll() no está implementado en VentasProductosFormulasNrosSerie")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                    idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As DataTable
      Return GetSQL().VentasProductosFormulasNrosSerie_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                          idProducto, orden, idProductoComponente, idFormula)
   End Function
#End Region

#Region "Metodos Privados"

   Private Function GetSQL() As SqlServer.VentasProductosFormulasNrosSerie
      Return New SqlServer.VentasProductosFormulasNrosSerie(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.VentaProductoFormulaNroSerie, tipo As TipoSP)
      Dim sqlC = New SqlServer.VentasProductosFormulasNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.VentasProductosFormulasNrosSerie_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                                en.IdProducto, en.Orden, en.IdProductoComponente, en.IdFormula, en.NroSerie)
         Case TipoSP._U
            Throw New NotImplementedException("UPDATE de tabla VentasProductosFormulasNrosSerie no implementado")
         Case TipoSP._D
            sqlC.VentasProductosFormulasNrosSerie_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                                en.IdProducto, en.Orden, en.IdProductoComponente, en.IdFormula, en.NroSerie)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.VentaProductoFormulaNroSerie, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.VentaProductoFormulaNroSerie.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.VentaProductoFormulaNroSerie.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.VentaProductoFormulaNroSerie.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.VentaProductoFormulaNroSerie.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.VentaProductoFormulaNroSerie.Columnas.NumeroComprobante.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.VentaProductoFormulaNroSerie.Columnas.IdProducto.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.VentaProductoFormulaNroSerie.Columnas.Orden.ToString())

         .IdProductoComponente = dr.Field(Of String)(Entidades.VentaProductoFormulaNroSerie.Columnas.IdProductoComponente.ToString())
         .IdFormula = dr.Field(Of Integer)(Entidades.VentaProductoFormulaNroSerie.Columnas.IdFormula.ToString())
         .NroSerie = dr.Field(Of String)(Entidades.VentaProductoFormulaNroSerie.Columnas.NroSerie.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.VentaProductoFormulaNroSerie)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.VentaProductoFormulaNroSerie)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.VentaProductoFormulaNroSerie)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(pp As Entidades.VentaProductoFormula)
      For Each ppf In pp.NrosSerie
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
   Public Function Convert(pp As Entidades.SeleccionMultipleUbicaciones) As List(Of Entidades.VentaProductoFormulaNroSerie)
      Return pp.NrosSerie.ConvertAll(Function(l) New Entidades.VentaProductoFormulaNroSerie() With {
                                                      .NroSerie = l.NroSerie
                                                   })
   End Function
   Public Sub _Borrar(pp As Entidades.VentaProductoFormula)
      _Borrar(New Entidades.VentaProductoFormulaNroSerie() With {
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
      _Borrar(New Entidades.VentaProductoFormulaNroSerie() With {
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
      _Borrar(New Entidades.VentaProductoFormulaNroSerie() With {
               .IdSucursal = pp.IdSucursal,
               .IdTipoComprobante = pp.TipoComprobante.IdTipoComprobante,
               .Letra = pp.LetraComprobante,
               .CentroEmisor = pp.CentroEmisor,
               .NumeroComprobante = pp.NumeroComprobante
            })
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                        idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, nroSerie As String) As DataTable
      Return GetSQL().VentasProductosFormulasNrosSerie_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                      idProducto, orden, idProductoComponente, idFormula, nroSerie)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, nroSerie As String) As Entidades.VentaProductoFormulaNroSerie
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula, nroSerie, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, nroSerie As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.VentaProductoFormulaNroSerie
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula, nroSerie),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaProductoFormulaNroSerie(),
                          accion, Function() String.Format("No existe Nro Serie {9} en el comprobante {0}/{1} {2} {3:0000}-{4:00000000} Ln: {6} - Prod: {5} - Comp: {7} - Formula: {8}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProducto, orden, idProductoComponente, idFormula, nroSerie))
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                            idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As List(Of Entidades.VentaProductoFormulaNroSerie)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                               idProducto, orden, idProductoComponente, idFormula),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaProductoFormulaNroSerie())
   End Function
#End Region
End Class