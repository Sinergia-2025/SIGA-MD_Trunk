#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class TurismoCursos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TurismoCursos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TurismoCurso), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TurismoCurso), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TurismoCurso), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TurismoCursos = New SqlServer.TurismoCursos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TurismoCursos(Me.da).TurismoCursos_GA()
   End Function


#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TurismoCurso, tipo As TipoSP)

      Dim sqlC As SqlServer.TurismoCursos = New SqlServer.TurismoCursos(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.TurismoCursos_I(en.IdCurso, en.NombreCurso)
         Case TipoSP._U
            sqlC.TurismoCursos_U(en.IdCurso, en.NombreCurso)
         Case TipoSP._D
            sqlC.TurismoCursos_D(en.IdCurso)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TurismoCurso, ByVal dr As DataRow)
      With o
         .IdCurso = dr.Field(Of Integer)(Entidades.TurismoCurso.Columnas.IdCurso.ToString())
         .NombreCurso = dr.Field(Of String)(Entidades.TurismoCurso.Columnas.NombreCurso.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTurismoCurso As Integer) As Entidades.TurismoCurso
      Return GetUno(idTurismoCurso, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTurismoCurso As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TurismoCurso
      Return CargaEntidad(New SqlServer.TurismoCursos(Me.da).TurismoCursos_G1(idTurismoCurso),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TurismoCurso(),
                          accion, Function() String.Format("No existe Tipo de Vehículo con Id: {0}", idTurismoCurso))
   End Function

   Public Function GetTodos() As List(Of Entidades.TurismoCurso)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.TurismoCurso), dr),
                        Function() New Entidades.TurismoCurso())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TurismoCursos(Me.da).GetCodigoMaximo()
   End Function

#End Region
End Class
