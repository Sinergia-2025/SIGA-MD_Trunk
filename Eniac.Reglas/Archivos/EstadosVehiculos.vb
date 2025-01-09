Public Class EstadosVehiculos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.EstadoVehiculo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoVehiculo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoVehiculo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.EstadoVehiculo), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.EstadosVehiculos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosVehiculos(da).EstadosVehiculos_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.EstadoVehiculo, tipo As TipoSP)
      Dim sqlC = New SqlServer.EstadosVehiculos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.EstadosVehiculos_I(en.IdEstadoVehiculo, en.NombreEstadoVehiculo, en.EnStock, en.SolicitaFecha, en.IdEstadoVehiculoLuegoVencer, en.Predeterminado)
         Case TipoSP._U
            sqlC.EstadosVehiculos_U(en.IdEstadoVehiculo, en.NombreEstadoVehiculo, en.EnStock, en.SolicitaFecha, en.IdEstadoVehiculoLuegoVencer, en.Predeterminado)
         Case TipoSP._D
            sqlC.EstadosVehiculos_D(en.IdEstadoVehiculo)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.EstadoVehiculo, dr As DataRow)
      With o
         .IdEstadoVehiculo = dr.Field(Of Integer)(Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString())
         .NombreEstadoVehiculo = dr.Field(Of String)(Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString())
         .EnStock = dr.Field(Of Boolean)(Entidades.EstadoVehiculo.Columnas.EnStock.ToString())
         .SolicitaFecha = dr.Field(Of Boolean)(Entidades.EstadoVehiculo.Columnas.SolicitaFecha.ToString())
         .IdEstadoVehiculoLuegoVencer = dr.Field(Of Integer?)(Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculoLuegoVencer.ToString())
         .Predeterminado = dr.Field(Of Boolean)(Entidades.EstadoVehiculo.Columnas.Predeterminado.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idEstadoVehiculo As Integer) As Entidades.EstadoVehiculo
      Return GetUno(idEstadoVehiculo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstadoVehiculo As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoVehiculo
      Return CargaEntidad(New SqlServer.EstadosVehiculos(da).EstadosVehiculos_G1(idEstadoVehiculo),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EstadoVehiculo(),
                          accion, Function() String.Format("No existe Estado de Vehículo con Id: {0}", idEstadoVehiculo))
   End Function

   Public Function GetTodos() As List(Of Entidades.EstadoVehiculo)
      Return CargaLista(New SqlServer.EstadosVehiculos(da).EstadosVehiculos_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EstadoVehiculo())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.EstadosVehiculos(da).GetCodigoMaximo()
   End Function

#End Region
End Class