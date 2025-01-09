Public Class VehiculosClientes
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.VehiculoCliente.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.VehiculoCliente)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.VehiculoCliente)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.VehiculoCliente)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.VehiculosClientes(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.VehiculosClientes(da).VehiculosClientes_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.VehiculoCliente, tipo As TipoSP)
      Dim sqlC As SqlServer.VehiculosClientes = New SqlServer.VehiculosClientes(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.VehiculosClientes_I(en.PatenteVehiculo, en.IdCliente)
         Case TipoSP._U
            sqlC.VehiculosClientes_U(en.PatenteVehiculo, en.IdCliente)
         Case TipoSP._D
            sqlC.VehiculosClientes_D(en.PatenteVehiculo, en.IdCliente)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.VehiculoCliente, dr As DataRow)
      With o
         .PatenteVehiculo = dr.Field(Of String)(Entidades.VehiculoCliente.Columnas.PatenteVehiculo.ToString())
         .IdCliente = dr.Field(Of Long)(Entidades.VehiculoCliente.Columnas.IdCliente.ToString())

         .CodigoCliente = dr.Field(Of Long)(Entidades.Cliente.Columnas.CodigoCliente.ToString())
         .TipoDocCliente = dr.Field(Of String)(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).IfNull()
         .NroDocCliente = dr.Field(Of Long?)(Entidades.Cliente.Columnas.NroDocCliente.ToString()).IfNull()
         .NombreCliente = dr.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.VehiculoCliente)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.VehiculoCliente)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.VehiculoCliente)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.Vehiculo)
      entidad.Clientes.ForEach(
         Sub(vc)
            vc.PatenteVehiculo = entidad.PatenteVehiculo
            _Insertar(vc)
         End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Vehiculo)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Vehiculo)
      _Borrar(New Entidades.VehiculoCliente() With {.PatenteVehiculo = entidad.PatenteVehiculo})
   End Sub


   Public Function GetUno(patenteVehiculo As String, idCliente As Long) As Entidades.VehiculoCliente
      Return GetUno(patenteVehiculo, idCliente, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(patenteVehiculo As String, idCliente As Long, accion As AccionesSiNoExisteRegistro) As Entidades.VehiculoCliente
      Return CargaEntidad(New SqlServer.VehiculosClientes(da).VehiculosClientes_G1(patenteVehiculo, idCliente),
                           Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VehiculoCliente(),
                           accion, Function() String.Format("No existe Vehículo Cliente con Patente: {0} y Id Cliente: {1}", patenteVehiculo, idCliente))
   End Function
   Public Function GetTodos() As List(Of Entidades.VehiculoCliente)
      Return CargaLista(New SqlServer.VehiculosClientes(da).VehiculosClientes_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VehiculoCliente())
   End Function
   Public Function GetTodos(patenteVehiculo As String) As List(Of Entidades.VehiculoCliente)
      Return CargaLista(New SqlServer.VehiculosClientes(da).VehiculosClientes_GA(patenteVehiculo),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VehiculoCliente())
   End Function
#End Region

End Class