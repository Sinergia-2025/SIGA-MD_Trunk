#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class TiposVehiculos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TipoVehiculo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoVehiculo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoVehiculo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoVehiculo), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TiposVehiculos = New SqlServer.TiposVehiculos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposVehiculos(Me.da).TiposVehiculos_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TipoVehiculo, tipo As TipoSP)
      Dim sqlC As SqlServer.TiposVehiculos = New SqlServer.TiposVehiculos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TiposVehiculos_I(en.IdTipoVehiculo, en.NombreTipoVehiculo, en.CapacidadMaxima)
         Case TipoSP._U
            sqlC.TiposVehiculos_U(en.IdTipoVehiculo, en.NombreTipoVehiculo, en.CapacidadMaxima)
         Case TipoSP._D
            sqlC.TiposVehiculos_D(en.IdTipoVehiculo)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.TipoVehiculo, dr As DataRow)
      With o
         .IdTipoVehiculo = dr.Field(Of Integer)(Entidades.TipoVehiculo.Columnas.IdTipoVehiculo.ToString())
         .NombreTipoVehiculo = dr.Field(Of String)(Entidades.TipoVehiculo.Columnas.NombreTipoVehiculo.ToString())
         .CapacidadMaxima = dr.Field(Of Integer)(Entidades.TipoVehiculo.Columnas.CapacidadMaxima.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTipoVehiculo As Integer) As Entidades.TipoVehiculo
      Return GetUno(idTipoVehiculo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTipoVehiculo As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TipoVehiculo
      Return CargaEntidad(New SqlServer.TiposVehiculos(Me.da).TiposVehiculos_G1(idTipoVehiculo),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TipoVehiculo(),
                          accion, Function() String.Format("No existe Tipo de Vehículo con Id: {0}", idTipoVehiculo))
   End Function

   Public Function GetTodos() As List(Of Entidades.TipoVehiculo)
      Return CargaLista(New SqlServer.TiposVehiculos(Me.da).TiposVehiculos_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TipoVehiculo())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TiposVehiculos(Me.da).GetCodigoMaximo()
   End Function

#End Region
End Class