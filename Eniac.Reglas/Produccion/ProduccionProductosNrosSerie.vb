Public Class ProduccionProductosNrosSerie
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("MovimientosStockProductos", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ProduccionProductoNrosSerie)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ProduccionProductoNrosSerie)))
   End Sub
   Public Overloads Function GetAll(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String) As DataTable
      Return New SqlServer.ProduccionProductosNrosSerie(da).ProduccionProductosNrosSerie_GA(idSucursal, idProduccion, orden, idProducto)
   End Function

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.ProduccionProductoNrosSerie)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ProduccionProductoNrosSerie)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Insertar(entidad As Entidades.ProduccionProducto)
      entidad.NrosSerie.
         ForEach(Sub(ns)
                    ns.IdSucursal = entidad.IdSucursal
                    ns.IdProduccion = entidad.IdProduccion
                    ns.Orden = entidad.Orden
                    ns.IdProducto = entidad.IdProducto
                    _Insertar(ns)
                 End Sub)
   End Sub

   Public Function GetTodos(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String) As List(Of Entidades.ProduccionProductoNrosSerie)
      Return CargaLista(GetAll(idSucursal, idProduccion, orden, idProducto),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionProductoNrosSerie)
   End Function
   Public Function Get1(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                        nroSerie As String) As DataTable
      Return New SqlServer.ProduccionProductosNrosSerie(da).ProduccionProductosNrosSerie_G1(idSucursal, idProduccion, orden, idProducto, nroSerie)
   End Function
   Public Function GetUno(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                          nroSerie As String) As Entidades.ProduccionProductoNrosSerie
      Return GetUno(idSucursal, idProduccion, orden, idProducto, nroSerie, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                          nroSerie As String, accion As AccionesSiNoExisteRegistro) As Entidades.ProduccionProductoNrosSerie
      Return CargaEntidad(Get1(idSucursal, idProduccion, orden, idProducto, nroSerie),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionProductoNrosSerie(),
                          accion, Function() String.Format("No se ha encotrado el Nro de Serie {4} en la línea de Producción {0} {1:00000000} Ln: {2} / Prod: {3}",
                                                          idSucursal, idProduccion, orden, idProduccion, nroSerie))
   End Function

#End Region


#Region "Metodos Privados"
   Public Sub EjecutaSP(en As Entidades.ProduccionProductoNrosSerie, tipo As TipoSP)
      Dim sql = New SqlServer.ProduccionProductosNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            sql.ProduccionProductosNrosSerie_I(en.IdSucursal, en.IdProduccion, en.Orden, en.IdProducto, en.NroSerie)
         Case TipoSP._D
            sql.ProduccionProductosNrosSerie_D(en.IdSucursal, en.IdProduccion, en.Orden, en.IdProducto, en.NroSerie)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ProduccionProductoNrosSerie, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.ProduccionProductoNrosSerie.Columnas.IdSucursal.ToString())
         .IdProduccion = dr.Field(Of Integer)(Entidades.ProduccionProductoNrosSerie.Columnas.IdProduccion.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.ProduccionProductoNrosSerie.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.ProduccionProductoNrosSerie.Columnas.IdProducto.ToString())
         .NroSerie = dr.Field(Of String)(Entidades.ProduccionProductoNrosSerie.Columnas.NroSerie.ToString())
      End With
   End Sub

#End Region

End Class