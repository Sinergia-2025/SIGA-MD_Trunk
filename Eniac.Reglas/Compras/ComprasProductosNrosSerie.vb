Public Class ComprasProductosNrosSerie
      Inherits Eniac.Reglas.Base

#Region "Constructores"

      Public Sub New()
      Me.NombreEntidad = Entidades.CompraProductoNroSerie.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CompraProductoNroSerie.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.CompraProductoNroSerie)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualiza(DirectCast(entidad, Entidades.CompraProductoNroSerie)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borra(DirectCast(entidad, Entidades.CompraProductoNroSerie)))
   End Sub

   Public Sub _Inserta(entidad As Entidades.CompraProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.CompraProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.CompraProductoNroSerie)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

#End Region

#Region "Metodos"

   Friend Sub EjecutaSP(ByVal ent As Entidades.CompraProductoNroSerie, ByVal tipo As TipoSP)

      Dim sComprasProductosNrosSerie As SqlServer.ComprasProductosNrosSerie = New SqlServer.ComprasProductosNrosSerie(Me.da)
      Select Case tipo

         Case TipoSP._I

            sComprasProductosNrosSerie.ComprasProductosNrosSerie_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor,
                         ent.NumeroComprobante, ent.Orden, ent.IdProveedor, ent.IdProducto, ent.NroSerie)

         Case TipoSP._U
            sComprasProductosNrosSerie.ComprasProductosNrosSerie_U(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                                                 ent.Orden, ent.IdProveedor, ent.IdProducto, ent.NroSerie)

         Case TipoSP._D
            sComprasProductosNrosSerie.ComprasProductosNrosSerie_D(ent.IdSucursal,
                                                                 ent.IdTipoComprobante,
                                                                 ent.Letra,
                                                                 ent.CentroEmisor,
                                                                 ent.NumeroComprobante,
                                                                 ent.Orden,
                                                                 ent.IdProveedor,
                                                                 ent.IdProducto)
      End Select
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          orden As Integer,
                          idProveedor As Long,
                          idProducto As String,
                          nroSerie As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.CompraProductoNroSerie
      Return CargaEntidad(New SqlServer.ComprasProductosNrosSerie(Me.da).ComprasProductosNrosSerie_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                                                                    orden, idProveedor, idProducto, nroSerie),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.CompraProductoNroSerie(),
                          accion, Function() String.Format("No existe el Producto con Nro Serie: {0}", nroSerie))
   End Function

   Public Function GetTodosPorComprobante(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          orden As Integer?,
                          idProveedor As Long,
                          idProducto As String) As List(Of Entidades.CompraProductoNroSerie)
      Dim sCPNS As SqlServer.ComprasProductosNrosSerie = New SqlServer.ComprasProductosNrosSerie(da)
      Return CargaLista(sCPNS.GetTodosPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden, idProveedor, idProducto),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.CompraProductoNroSerie), dr),
                        Function() New Entidades.CompraProductoNroSerie())
   End Function

   Public Overrides Function GetAll() As DataTable
      Dim sComprasProductosNrosSerie As SqlServer.ComprasProductosNrosSerie = New SqlServer.ComprasProductosNrosSerie(da)
      Return sComprasProductosNrosSerie.ComprasProductosNrosSerie_GA()
   End Function

   Private Sub CargarUno(eCompraProductoNroSerie As Entidades.CompraProductoNroSerie, dr As DataRow)
      With eCompraProductoNroSerie
         .IdSucursal = dr.Field(Of Integer)(Entidades.CompraProductoNroSerie.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CompraProductoNroSerie.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CompraProductoNroSerie.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CompraProductoNroSerie.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CompraProductoNroSerie.Columnas.NumeroComprobante.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CompraProductoNroSerie.Columnas.Orden.ToString())
         .IdProveedor = dr.Field(Of Long)(Entidades.CompraProductoNroSerie.Columnas.IdProveedor.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.CompraProductoNroSerie.Columnas.IdProducto.ToString())
         .NroSerie = dr.Field(Of String)(Entidades.CompraProductoNroSerie.Columnas.NroSerie.ToString())
      End With
   End Sub

   Public Function GetProductosNrosSerieADevolver(idProducto As String, idProveedor As Long) As DataTable
      Return If(New SqlServer.ComprasProductosNrosSerie(da).GetProductosNrosSerieADevolver(idProducto, idProveedor).Rows.Count > 0,
                New SqlServer.ComprasProductosNrosSerie(da).GetProductosNrosSerieADevolver(idProducto, idProveedor),
                Nothing)
   End Function
#End Region

   End Class
