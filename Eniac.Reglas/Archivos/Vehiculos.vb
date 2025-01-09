Public Class Vehiculos
    Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.Vehiculo.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Vehiculo)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Vehiculo)))
   End Sub
   Public Sub Merge(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.Vehiculo)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Vehiculo)))
   End Sub

   Public Sub _Insertar(entidad As Entidades.Vehiculo)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Vehiculo)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Merge(entidad As Entidades.Vehiculo)
      EjecutaSP(entidad, TipoSP._M)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Vehiculo)
      EjecutaSP(entidad, TipoSP._D)
   End Sub


   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Vehiculos = New SqlServer.Vehiculos(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Vehiculos(da).Vehiculos_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.Vehiculo, tipo As TipoSP)
      Dim sqlC = New SqlServer.Vehiculos(da)
      Dim rVC = New VehiculosClientes(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Vehiculos_I(en.PatenteVehiculo, en.IdMarcaVehiculo, en.IdModeloVehiculo, en.Color, en.VencimientoSeguro, en.Ruta, en.Vtv, en.Activo, en.EstaAdentro,      ', en.IdCliente
                             en.TipoUnidad.IdTipoUnidad, en.SubTipoUnidad, en.AnioPatentamiento, en.MedidasVehiculo,
                             en.LlantasVehiculo, en.AuxilioVehiculo, en.NeumaticosVehiculo,
                             en.OtrosVehiculo, en.IdentificacionVehiculo, en.ObservacionesVehiculo,
                             en.EstadoVehiculo.IdEstadoVehiculo,
                             en.PrecioCompra, en.PrecioReferencia, en.IdProductoReferencia, en.PrecioLista,
                             en.IdMarcaOperacionIngreso, en.AnioOperacionIngreso, en.NumeroOperacionIngreso, en.SecuenciaOperacionIngreso)
            rVC._Insertar(en)
         Case TipoSP._U
            sqlC.Vehiculos_U(en.PatenteVehiculo, en.IdMarcaVehiculo, en.IdModeloVehiculo, en.Color, en.VencimientoSeguro, en.Ruta, en.Vtv, en.Activo, en.EstaAdentro,      ', en.IdCliente
                             en.TipoUnidad.IdTipoUnidad, en.SubTipoUnidad, en.AnioPatentamiento, en.MedidasVehiculo,
                             en.LlantasVehiculo, en.AuxilioVehiculo, en.NeumaticosVehiculo,
                             en.OtrosVehiculo, en.IdentificacionVehiculo, en.ObservacionesVehiculo,
                             en.EstadoVehiculo.IdEstadoVehiculo,
                             en.PrecioCompra, en.PrecioReferencia, en.IdProductoReferencia, en.PrecioLista,
                             en.IdMarcaOperacionIngreso, en.AnioOperacionIngreso, en.NumeroOperacionIngreso, en.SecuenciaOperacionIngreso)
            rVC._Actualizar(en)
         Case TipoSP._M
            sqlC.Vehiculos_M(en.PatenteVehiculo, en.IdMarcaVehiculo, en.IdModeloVehiculo, en.Color, en.VencimientoSeguro, en.Ruta, en.Vtv, en.Activo, en.EstaAdentro,      ', en.IdCliente
                             en.TipoUnidad.IdTipoUnidad, en.SubTipoUnidad, en.AnioPatentamiento, en.MedidasVehiculo,
                             en.LlantasVehiculo, en.AuxilioVehiculo, en.NeumaticosVehiculo,
                             en.OtrosVehiculo, en.IdentificacionVehiculo, en.ObservacionesVehiculo,
                             en.EstadoVehiculo.IdEstadoVehiculo,
                             en.PrecioCompra, en.PrecioReferencia, en.IdProductoReferencia, en.PrecioLista,
                             en.IdMarcaOperacionIngreso, en.AnioOperacionIngreso, en.NumeroOperacionIngreso, en.SecuenciaOperacionIngreso)
            rVC._Actualizar(en)
         Case TipoSP._D
            rVC._Borrar(en)
            sqlC.Vehiculos_D(en.PatenteVehiculo)
      End Select
   End Sub

   Public Function CargarUno(dr As DataRow) As Entidades.Vehiculo
      Dim o = New Entidades.Vehiculo
      CargarUno(o, dr)
      Return o
   End Function

   Private Sub CargarUno(o As Entidades.Vehiculo, dr As DataRow)
      With o
         .PatenteVehiculo = dr.Field(Of String)(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString())
         .IdMarcaVehiculo = dr.Field(Of Integer)(Entidades.Vehiculo.Columnas.IdMarcaVehiculo.ToString())
         .DescripMarcaVehiculo = dr.Field(Of String)("NombreMarcaVehiculo")
         .IdModeloVehiculo = dr.Field(Of Integer)(Entidades.Vehiculo.Columnas.IdModeloVehiculo.ToString())
         .DescripModeloVehiculo = dr.Field(Of String)("NombreModeloVehiculo")
         .Color = dr.Field(Of String)(Entidades.Vehiculo.Columnas.Color.ToString())
         .VencimientoSeguro = dr.Field(Of Date)(Entidades.Vehiculo.Columnas.VencimientoSeguro.ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Vehiculo.Columnas.Ruta.ToString()).ToString()) Then
            .Ruta = dr.Field(Of Date)(Entidades.Vehiculo.Columnas.Ruta.ToString())
         Else
            .Ruta = Nothing
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Vehiculo.Columnas.Vtv.ToString()).ToString()) Then
            .Vtv = dr.Field(Of Date)(Entidades.Vehiculo.Columnas.Vtv.ToString().IfNull)
         Else
            .Vtv = Nothing
         End If
         .Activo = dr.Field(Of Boolean)(Entidades.Vehiculo.Columnas.Activo.ToString())
         '.IdCliente = dr.Field(Of Long)(Entidades.Vehiculo.Columnas.IdCliente.ToString())
         .Clientes = New VehiculosClientes(da).GetTodos(.PatenteVehiculo)
         .EstaAdentro = dr.Field(Of Boolean)(Entidades.Vehiculo.Columnas.EstaAdentro.ToString())


         .TipoUnidad = New ConcesionarioTiposUnidades(da).GetUno(dr.Field(Of Integer)(Entidades.Vehiculo.Columnas.IdTipoUnidad.ToString()))
         .SubTipoUnidad = dr.Field(Of String)(Entidades.Vehiculo.Columnas.SubTipoUnidad.ToString())
         .AnioPatentamiento = dr.Field(Of Integer)(Entidades.Vehiculo.Columnas.AnioPatentamiento.ToString())
         .MedidasVehiculo = dr.Field(Of String)(Entidades.Vehiculo.Columnas.MedidasVehiculo.ToString())
         .LlantasVehiculo = dr.Field(Of String)(Entidades.Vehiculo.Columnas.LlantasVehiculo.ToString()).StringToEnum(Entidades.ConcesionarioLlantasVehiculo.NA)
         .AuxilioVehiculo = dr.Field(Of String)(Entidades.Vehiculo.Columnas.AuxilioVehiculo.ToString()).StringToEnum(Entidades.Publicos.SiNo.NO)
         .NeumaticosVehiculo = dr.Field(Of String)(Entidades.Vehiculo.Columnas.NeumaticosVehiculo.ToString())
         .OtrosVehiculo = dr.Field(Of String)(Entidades.Vehiculo.Columnas.OtrosVehiculo.ToString())
         .IdentificacionVehiculo = dr.Field(Of String)(Entidades.Vehiculo.Columnas.IdentificacionVehiculo.ToString()).StringToEnum(Entidades.Publicos.SiNo.NO)
         .ObservacionesVehiculo = dr.Field(Of String)(Entidades.Vehiculo.Columnas.ObservacionesVehiculo.ToString())
         .EstadoVehiculo = New EstadosVehiculos(da).GetUno(dr.Field(Of Integer)(Entidades.Vehiculo.Columnas.IdEstadoVehiculo.ToString()))


         .PrecioCompra = dr.Field(Of Decimal)(Entidades.Vehiculo.Columnas.PrecioCompra.ToString())
         .PrecioReferencia = dr.Field(Of Decimal)(Entidades.Vehiculo.Columnas.PrecioReferencia.ToString())
         .IdProductoReferencia = dr.Field(Of String)(Entidades.Vehiculo.Columnas.IdProductoReferencia.ToString()).IfNull()
         .NombreProductoReferencia = dr.Field(Of String)(Entidades.Producto.Columnas.NombreProducto.ToString()).IfNull()
         .PrecioLista = dr.Field(Of Decimal)(Entidades.Vehiculo.Columnas.PrecioLista.ToString())

         .IdMarcaOperacionIngreso = dr.Field(Of Integer?)(Entidades.Vehiculo.Columnas.IdMarcaOperacionIngreso.ToString())
         .AnioOperacionIngreso = dr.Field(Of Integer?)(Entidades.Vehiculo.Columnas.AnioOperacionIngreso.ToString())
         .NumeroOperacionIngreso = dr.Field(Of Integer?)(Entidades.Vehiculo.Columnas.NumeroOperacionIngreso.ToString())
         .SecuenciaOperacionIngreso = dr.Field(Of Integer?)(Entidades.Vehiculo.Columnas.SecuenciaOperacionIngreso.ToString())
         .CodigoOperacionIngreso = dr.Field(Of String)("CodigoOperacionIngreso")

      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Function GetUno(PatenteVehiculo As String) As Entidades.Vehiculo
      Return GetUno(PatenteVehiculo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(PatenteVehiculo As String, accion As AccionesSiNoExisteRegistro) As Entidades.Vehiculo
      Return CargaEntidad(New SqlServer.Vehiculos(da).Vehiculos_G1(PatenteVehiculo),
                           Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.Vehiculo(),
                           accion, Function() String.Format("No existe Modelo de Vehículo con Id: {0}", PatenteVehiculo))
   End Function
   Public Function GetTodos() As List(Of Entidades.Vehiculo)
      Return CargaLista(New SqlServer.Vehiculos(da).Vehiculos_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.Vehiculo())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ModelosVehiculos(da).GetCodigoMaximo()
   End Function

   Public Function GetFiltradoPorPatente(codigoPatente As String, soloActivos As Boolean) As DataTable
      Return GetFiltradoPorPatente(codigoPatente, idCliente:=0, soloActivos)
   End Function
   Public Function GetFiltradoPorPatente(codigoPatente As String, idCliente As Long, soloActivos As Boolean) As DataTable
      Return GetFiltradoPorPatente(codigoPatente, idCliente, soloActivos, conOperacionIngreso:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Function GetFiltradoPorPatente(codigoPatente As String, soloActivos As Boolean, conOperacionIngreso As Entidades.Publicos.SiNoTodos) As DataTable
      Return GetFiltradoPorPatente(codigoPatente, idCliente:=0, soloActivos, conOperacionIngreso)
   End Function
   Public Function GetFiltradoPorPatente(codigoPatente As String, idCliente As Long, soloActivos As Boolean, conOperacionIngreso As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.Vehiculos(da).GetFiltradoPorPatente(codigoPatente, idCliente, soloActivos, conOperacionIngreso)
   End Function

   Public Function GetFiltradoPorCliente(idCliente As Long, soloActivos As Boolean) As DataTable
      Return New SqlServer.Vehiculos(da).GetFiltradoPorCliente(idCliente, soloActivos)
   End Function

   Public Sub ActualizaOperacionIngreso(patenteVehiculo As String,
                                        idMarcaOperacionIngreso As Integer?, anioOperacionIngreso As Integer?, numeroOperacionIngreso As Integer?, secuenciaOperacionIngreso As Integer?)
      Dim sql = New SqlServer.Vehiculos(da)
      sql.Vehiculos_U_OperacionIngreso(patenteVehiculo, idMarcaOperacionIngreso, anioOperacionIngreso, numeroOperacionIngreso, secuenciaOperacionIngreso)
   End Sub

#End Region

End Class