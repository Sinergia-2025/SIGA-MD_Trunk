Option Strict On
Option Explicit On
Public Class TareasProgramadasHorarios
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TareaProgramadaHorario.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Insertar(DirectCast(entidad, Entidades.TareaProgramadaHorario)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Actualizar(DirectCast(entidad, Entidades.TareaProgramadaHorario)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Borrar(DirectCast(entidad, Entidades.TareaProgramadaHorario)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TareasProgramadasHorarios = New SqlServer.TareasProgramadasHorarios(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TareasProgramadasHorarios(Me.da).TareasProgramadasHorarios_GA()
   End Function
#End Region

#Region "Metodos Privados"


   Private Sub EjecutaSP(entidad As Entidades.TareaProgramadaHorario, tipo As TipoSP)
      Dim sql As SqlServer.TareasProgramadasHorarios = New SqlServer.TareasProgramadasHorarios(Me.da)
      Select Case tipo

         Case TipoSP._I
            sql.TareasProgramadasHorarios_I(entidad.IdTareaProgramada, entidad.DiaSemana, entidad.HoraProgramada)

         Case TipoSP._U
            sql.TareasProgramadasHorarios_U(entidad.IdTareaProgramada, entidad.DiaSemana, entidad.HoraProgramada)

         Case TipoSP._D
            sql.TareasProgramadasHorarios_D(entidad.IdTareaProgramada, entidad.DiaSemana, entidad.HoraProgramada)

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.TareaProgramadaHorario, dr As DataRow)
      With o
         .IdTareaProgramada = Integer.Parse(dr(Eniac.Entidades.TareaProgramadaHorario.Columnas.IdTareaProgramada.ToString()).ToString())
         .DiaSemana = DirectCast(Integer.Parse(dr(Eniac.Entidades.TareaProgramadaHorario.Columnas.DiaSemana.ToString()).ToString()), System.DayOfWeek)
         .HoraProgramada = dr(Eniac.Entidades.TareaProgramadaHorario.Columnas.HoraProgramada.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Insertar(entidad As Entidades.TareaProgramadaHorario)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.TareaProgramadaHorario)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.TareaProgramadaHorario)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub InsertaDesdeTareasProgramadas(tarea As Entidades.TareaProgramada)
      For Each horario As Entidades.TareaProgramadaHorario In tarea.Horarios
         horario.IdTareaProgramada = tarea.IdTareaProgramada
         _Insertar(horario)
      Next
   End Sub
   Public Sub BorrarDesdeTareasProgramadas(tarea As Entidades.TareaProgramada)
      Dim sql As SqlServer.TareasProgramadasHorarios = New SqlServer.TareasProgramadasHorarios(Me.da)
      sql.TareasProgramadasHorarios_D(tarea.IdTareaProgramada, -1, String.Empty)
   End Sub

   Public Function GetTodos() As List(Of Entidades.TareaProgramadaHorario)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TareaProgramadaHorario())
   End Function
   Public Function GetTodos(idTareaProgramada As Integer) As List(Of Entidades.TareaProgramadaHorario)
      Return CargaLista(New SqlServer.TareasProgramadasHorarios(Me.da).TareasProgramadasHorarios_GA(idTareaProgramada),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TareaProgramadaHorario())
   End Function

   Public Function GetUno(idTareaProgramada As Integer, diaSemana As Integer, horaProgramada As String) As Entidades.TareaProgramadaHorario
      Return GetUno(idTareaProgramada, diaSemana, horaProgramada, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTareaProgramada As Integer, diaSemana As Integer, horaProgramada As String, accion As AccionesSiNoExisteRegistro) As Entidades.TareaProgramadaHorario
      Return CargaEntidad(New SqlServer.TareasProgramadasHorarios(Me.da).TareasProgramadasHorarios_G1(idTareaProgramada, diaSemana, horaProgramada),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TareaProgramadaHorario(),
                          accion, Function() String.Format("La Tarea Programada {0} no existe. Por favor verifique.", idTareaProgramada))
   End Function

#End Region

End Class