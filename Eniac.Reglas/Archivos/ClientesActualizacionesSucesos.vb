#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ClientesActualizacionesSucesos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ClienteActualizacionSuceso.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ClienteActualizacionSuceso)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ClienteActualizacionSuceso)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ClienteActualizacionSuceso)))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ClientesActualizacionesSucesos = New SqlServer.ClientesActualizacionesSucesos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable ' se aplica la regla para traer todos los registros asociados al cliente
      Return New SqlServer.ClientesActualizacionesSucesos(Me.da).ClientesActualizacionesSucesos_GA()
   End Function
   Public Function InfClientesActualizacionesSucesos(idCliente As Long, fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Return New SqlServer.ClientesActualizacionesSucesos(Me.da).GetInfClientesActualizacionesSucesos(idCliente, fechaDesde, fechaHasta)
   End Function

#End Region

#Region "Metodos Privados"

   Public Sub _Insertar(entidad As Entidades.ClienteActualizacionSuceso)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.ClienteActualizacionSuceso)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Entidades.ClienteActualizacionSuceso)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Borrar(entidad As Entidades.ClienteActualizacionSuceso)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Private Sub EjecutaSP(en As Entidades.ClienteActualizacionSuceso, tipo As TipoSP)

      Dim sqlC As SqlServer.ClientesActualizacionesSucesos = New SqlServer.ClientesActualizacionesSucesos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ClientesActualizacionesSucesos_I(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.TipoSuceso, en.Orden, en.Datos, en.Mensaje, en.NombreScript, en.Script, en.Estado)
         Case TipoSP._U
            sqlC.ClientesActualizacionesSucesos_U(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.TipoSuceso, en.Orden, en.Datos, en.Mensaje, en.NombreScript, en.Script, en.Estado)
         Case TipoSP._M
            sqlC.ClientesActualizacionesSucesos_M(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.TipoSuceso, en.Orden, en.Datos, en.Mensaje, en.NombreScript, en.Script, en.Estado)
         Case TipoSP._D
            sqlC.ClientesActualizacionesSucesos_D(en.IdCliente, en.NombreServidor, en.BaseDatos, en.FechaEjecucion, en.TipoSuceso, en.Orden)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.ClienteActualizacionSuceso, dr As DataRow)
      With o
         .IdCliente = dr.Field(Of Long)(Entidades.ClienteActualizacionSuceso.Columnas.IdCliente.ToString())
         .NombreServidor = dr.Field(Of String)(Entidades.ClienteActualizacionSuceso.Columnas.NombreServidor.ToString())
         .BaseDatos = dr.Field(Of String)(Entidades.ClienteActualizacionSuceso.Columnas.BaseDatos.ToString())
         .FechaEjecucion = dr.Field(Of DateTime)(Entidades.ClienteActualizacionSuceso.Columnas.FechaEjecucion.ToString())

         .TipoSuceso = dr(Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString()).ToString().StringToEnum(Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso.Actualizador_Generico)
         .TipoSucesoValue = dr.Field(Of String)(Entidades.ClienteActualizacionSuceso.Columnas.TipoSucesoValue.ToString())

         .Orden = dr.Field(Of Integer)(Entidades.ClienteActualizacionSuceso.Columnas.Orden.ToString())

         .Datos = dr.Field(Of String)(Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString())

         .Datos = dr.Field(Of String)(Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString())
         .Mensaje = dr.Field(Of String)(Entidades.ClienteActualizacionSuceso.Columnas.Mensaje.ToString())
         .NombreScript = dr.Field(Of String)(Entidades.ClienteActualizacionSuceso.Columnas.NombreScript.ToString())
         .Script = dr.Field(Of String)(Entidades.ClienteActualizacionSuceso.Columnas.Script.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idCliente As Long,
                          nombreServidor As String,
                          baseDatos As String,
                          fechaEjecucion As DateTime,
                          tipoSuceso As Entidades.JSonEntidades.SSSServicioWeb.TipoSuceso,
                          orden As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.ClienteActualizacionSuceso

      Return CargaEntidad(New SqlServer.ClientesActualizacionesSucesos(da).ClientesActualizacionesSucesos_G1(idCliente, nombreServidor, baseDatos, FechaEjecucion, tipoSuceso, orden),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ClienteActualizacionSuceso(),
                          accion, Function() String.Format("No se encontró el Backup del Cliente"))
   End Function



   Public Function GetTodos() As List(Of Entidades.ClienteActualizacionSuceso)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.ClienteActualizacionSuceso), dr), Function() New Entidades.ClienteActualizacionSuceso())
   End Function


   Public Function GetTodos(idCliente As Long,
                            nombreServidor As String,
                            baseDatos As String,
                            fechaEjecucion As DateTime) As List(Of Entidades.ClienteActualizacionSuceso)
      Return CargaLista(New SqlServer.ClientesActualizacionesSucesos(da).ClientesActualizacionesSucesos_GA(idCliente, nombreServidor, baseDatos, fechaEjecucion),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.ClienteActualizacionSuceso), dr), Function() New Entidades.ClienteActualizacionSuceso())
   End Function

#End Region

End Class