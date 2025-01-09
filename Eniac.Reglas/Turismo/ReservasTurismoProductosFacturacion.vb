Public Class ReservaTurismoProductoFacturacion
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ReservaTurismoProductoFacturacion.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ReservaTurismoProductoFacturacion)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ReservaTurismoProductoFacturacion)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ReservaTurismoProductoFacturacion)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.ReservasTurismoProductosFacturacion(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ReservasTurismoProductosFacturacion(da).ReservasTurismoProductosFacturacion_GA()
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long) As DataTable
      Return New SqlServer.ReservasTurismoProductosFacturacion(da).ReservasTurismoProductosFacturacion_GA(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva)
   End Function
#End Region

#Region "Métodos Públicos"
   Public Sub _Insertar(entidad As Entidades.ReservaTurismoProductoFacturacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.ReservaTurismoProductoFacturacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ReservaTurismoProductoFacturacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Insertar(entidad As Entidades.ReservaTurismo)
      entidad.Facturacion.ForEach(
         Sub(en)
            en.IdSucursal = entidad.IdSucursal
            en.IdTipoReserva = entidad.IdTipoReserva
            en.Letra = entidad.Letra
            en.CentroEmisor = entidad.CentroEmisor
            en.NumeroReserva = entidad.NumeroReserva
            _Insertar(en)
         End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.ReservaTurismo)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.ReservaTurismo)
      _Borrar(New Entidades.ReservaTurismoProductoFacturacion() With
                  {
                     .IdSucursal = entidad.IdSucursal,
                     .IdTipoReserva = entidad.IdTipoReserva,
                     .Letra = entidad.Letra,
                     .CentroEmisor = entidad.CentroEmisor,
                     .NumeroReserva = entidad.NumeroReserva
                  })
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                        idProducto As String, orden As Integer) As DataTable
      Return New SqlServer.ReservasTurismoProductosFacturacion(da).
                        ReservasTurismoProductosFacturacion_G1(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva, idProducto, orden)
   End Function

   'GET UNO
   Public Function GetUno(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                          idProducto As String, orden As Integer) As Entidades.ReservaTurismoProductoFacturacion
      Return GetUno(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva, idProducto, orden, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                          idProducto As String, orden As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ReservaTurismoProductoFacturacion
      Return CargaEntidad(Get1(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva, idProducto, orden),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ReservaTurismoProductoFacturacion(),
                          accion, Function() String.Format("No existe el Producto para Facturar con: {0} {1} {2} {3:0000}-{4:00000000} {5} {6}",
                                                           idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva, idProducto, orden))
   End Function

   'GET TODOS
   Public Function GetTodos(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long) As List(Of Entidades.ReservaTurismoProductoFacturacion)
      Return CargaLista(GetAll(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ReservaTurismoProductoFacturacion())
   End Function

#End Region

#Region "Métodos Privados"
   Private Sub EjecutaSP(en As Entidades.ReservaTurismoProductoFacturacion, tipo As TipoSP)
      Dim sql = New SqlServer.ReservasTurismoProductosFacturacion(da)
      Select Case tipo
         Case TipoSP._I
            sql.ReservasTurismoProductosFacturacion_I(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva, en.IdProducto, en.Orden,
                                                      en.Cantidad, en.Precio, en.AlicuotaIVA, en.ImporteTotal)
         Case TipoSP._U
            sql.ReservasTurismoProductosFacturacion_U(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva, en.IdProducto, en.Orden,
                                                      en.Cantidad, en.Precio, en.AlicuotaIVA, en.ImporteTotal)
         Case TipoSP._D
            sql.ReservasTurismoProductosFacturacion_D(en.IdSucursal, en.IdTipoReserva, en.Letra, en.CentroEmisor, en.NumeroReserva, en.IdProducto, en.Orden)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.ReservaTurismoProductoFacturacion, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.ReservaTurismoProductoFacturacion.Columnas.IdSucursal.ToString())
         .IdTipoReserva = dr.Field(Of String)(Entidades.ReservaTurismoProductoFacturacion.Columnas.IdTipoReserva.ToString())
         .Letra = dr.Field(Of String)(Entidades.ReservaTurismoProductoFacturacion.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.ReservaTurismoProductoFacturacion.Columnas.CentroEmisor.ToString())
         .NumeroReserva = dr.Field(Of Long)(Entidades.ReservaTurismoProductoFacturacion.Columnas.NumeroReserva.ToString())

         .IdProducto = dr.Field(Of String)(Entidades.ReservaTurismoProductoFacturacion.Columnas.IdProducto.ToString())
         .NombreProducto = dr.Field(Of String)(Entidades.Producto.Columnas.NombreProducto.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.ReservaTurismoProductoFacturacion.Columnas.Orden.ToString())

         .Cantidad = dr.Field(Of Decimal)(Entidades.ReservaTurismoProductoFacturacion.Columnas.Cantidad.ToString())
         .Precio = dr.Field(Of Decimal)(Entidades.ReservaTurismoProductoFacturacion.Columnas.Precio.ToString())
         .AlicuotaIVA = dr.Field(Of Decimal)(Entidades.ReservaTurismoProductoFacturacion.Columnas.AlicuotaIVA.ToString())
         .ImporteTotal = dr.Field(Of Decimal)(Entidades.ReservaTurismoProductoFacturacion.Columnas.ImporteTotal.ToString())
      End With
   End Sub
#End Region
End Class
