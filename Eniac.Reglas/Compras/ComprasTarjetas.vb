Public Class ComprasTarjetas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CompraTarjeta.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides/Overloads"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CompraTarjeta)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CompraTarjeta)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CompraTarjeta)))
   End Sub
   <Obsolete("Usar GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)")>
   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException()
   End Function

   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As DataTable
      Return GetSQL().ComprasTarjetas_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSQL() As SqlServer.ComprasTarjetas
      Return New SqlServer.ComprasTarjetas(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CompraTarjeta, tipo As TipoSP)
      Dim sql = GetSQL()
      Select Case tipo
         Case TipoSP._I
            en.IdEstadoTarjeta = en.TarjetaCupon.IdEstadoTarjeta
            en.IdEstadoTarjetaAnt = en.TarjetaCupon.IdEstadoTarjetaAnt
            sql.ComprasTarjetas_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdProveedor, en.IdTarjetaCupon, en.IdEstadoTarjeta, en.IdEstadoTarjetaAnt)
         Case TipoSP._U
            sql.ComprasTarjetas_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdProveedor, en.IdTarjetaCupon, en.IdEstadoTarjeta, en.IdEstadoTarjetaAnt)
         Case TipoSP._D
            sql.ComprasTarjetas_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdProveedor, en.IdTarjetaCupon)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.CompraTarjeta, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.CompraTarjeta.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CompraTarjeta.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CompraTarjeta.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CompraTarjeta.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CompraTarjeta.Columnas.NumeroComprobante.ToString())
         .IdProveedor = dr.Field(Of Long)(Entidades.CompraTarjeta.Columnas.IdProveedor.ToString())
         .TarjetaCupon = New TarjetasCupones(da).GetUno(dr.Field(Of Integer)(Entidades.CompraTarjeta.Columnas.IdTarjetaCupon.ToString()))
         .IdEstadoTarjeta = dr.Field(Of String)(Entidades.CompraTarjeta.Columnas.IdEstadoTarjeta.ToString()).StringToEnum(Entidades.TarjetaCupon.Estados.NINGUNO)
         .IdEstadoTarjetaAnt = dr.Field(Of String)(Entidades.CompraTarjeta.Columnas.IdEstadoTarjetaAnt.ToString()).StringToEnum(Entidades.TarjetaCupon.Estados.NINGUNO)
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.CompraTarjeta)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CompraTarjeta)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CompraTarjeta)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(compra As Entidades.Compra)
      compra.CuponesTarjetasLiquidacion.ForEachSecure(
         Sub(t)
            t.IdSucursal = compra.IdSucursal
            t.IdTipoComprobante = compra.IdTipoComprobante
            t.Letra = compra.Letra
            t.CentroEmisor = compra.CentroEmisor
            t.NumeroComprobante = compra.NumeroComprobante
            t.IdProveedor = compra.Proveedor.IdProveedor
            _Insertar(t)
         End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Compra)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Compra)
      _Borrar(New Entidades.CompraTarjeta() With {
                  .IdSucursal = entidad.IdSucursal,
                  .IdTipoComprobante = entidad.IdTipoComprobante,
                  .Letra = entidad.Letra,
                  .CentroEmisor = entidad.CentroEmisor,
                  .NumeroComprobante = entidad.NumeroComprobante,
                  .IdProveedor = entidad.Proveedor.IdProveedor
              })
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                        idTarjetaCupon As Long) As DataTable
      Return GetSQL().ComprasTarjetas_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idTarjetaCupon)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, idTarjetaCupon As Long) As Entidades.CompraTarjeta
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idTarjetaCupon, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, idTarjetaCupon As Long,
                          accion As AccionesSiNoExisteRegistro) As Entidades.CompraTarjeta
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idTarjetaCupon),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CompraTarjeta,
                          accion, String.Format("No existe Tarjeta con Id {6} en la compra {0}/{1} {2} {3:0000}-{4:00000000} Prov: {5}",
                                                idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idTarjetaCupon))
   End Function
   Public Function GetTodos(compra As Entidades.Compra) As List(Of Entidades.CompraTarjeta)
      Return GetTodos(compra.IdSucursal, compra.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante, compra.Proveedor.IdProveedor)
   End Function
   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As List(Of Entidades.CompraTarjeta)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CompraTarjeta)
   End Function

   Public Function GetTodosPantallaSeleccion(dt As DataTable) As List(Of Entidades.CompraTarjeta)
      Return EjecutaConConexion(Function() _GetTodosPantallaSeleccion(dt))
   End Function
   Public Function _GetTodosPantallaSeleccion(dt As DataTable) As List(Of Entidades.CompraTarjeta)
      If dt Is Nothing Then
         Return New List(Of Entidades.CompraTarjeta)()
      End If
      Dim rTarjetasCupones = New TarjetasCupones()
      Return dt.AsEnumerable().ToList().ConvertAll(Function(dr) New Entidades.CompraTarjeta() With {
                                                      .TarjetaCupon = rTarjetasCupones.GetUno(dr.Field(Of Integer)(Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString()))
                                                   })
   End Function

#End Region

End Class