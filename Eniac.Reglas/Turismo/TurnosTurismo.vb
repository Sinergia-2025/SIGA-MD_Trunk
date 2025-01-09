#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class TurismoTurnos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TurismoTurnos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TurismoTurno), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TurismoTurno), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TurismoTurno), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TurismoTurnos = New SqlServer.TurismoTurnos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TurismoTurnos(Me.da).TurismoTurnos_GA()
   End Function


#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TurismoTurno, tipo As TipoSP)

      Dim sqlC As SqlServer.TurismoTurnos = New SqlServer.TurismoTurnos(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.TurismoTurnos_I(en.IdTurno, en.NombreTurno)
         Case TipoSP._U
            sqlC.TurismoTurnos_U(en.IdTurno, en.NombreTurno)
         Case TipoSP._D
            sqlC.TurismoTurnos_D(en.IdTurno)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TurismoTurno, ByVal dr As DataRow)
      With o
         .IdTurno = dr.Field(Of Integer)(Entidades.TurismoTurno.Columnas.IdTurno.ToString())
         .NombreTurno = dr.Field(Of String)(Entidades.TurismoTurno.Columnas.NombreTurno.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTurnoTurismo As Integer) As Entidades.TurismoTurno
      Return GetUno(idTurnoTurismo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTurnoTurismo As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TurismoTurno
      Return CargaEntidad(New SqlServer.TurismoTurnos(Me.da).TurismoTurnos_G1(idTurnoTurismo),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TurismoTurno(),
                          accion, Function() String.Format("No existe Tipo de Vehículo con Id: {0}", idTurnoTurismo))
   End Function

   Public Function GetTodos() As List(Of Entidades.TurismoTurno)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.TurismoTurno), dr),
                        Function() New Entidades.TurismoTurno())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TurismoTurnos(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class