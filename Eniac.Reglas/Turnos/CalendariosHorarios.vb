Option Strict On
Option Explicit On
Public Class CalendariosHorarios
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CalendariosHorarios"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CalendariosHorarios"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Inserta(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Actualiza(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Borra(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CalendariosHorarios = New SqlServer.CalendariosHorarios(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CalendariosHorarios(Me.da).CalendariosHorarios_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.CalendarioHorario = DirectCast(entidad, Entidades.CalendarioHorario)

      Dim sqlC As SqlServer.CalendariosHorarios = New SqlServer.CalendariosHorarios(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CalendariosHorarios_I(en.IdCalendario, en.IdDiaSemana, en.IdHorario, en.HoraDesde, en.HoraHasta)
         Case TipoSP._U
            sqlC.CalendariosHorarios_U(en.IdCalendario, en.IdDiaSemana, en.IdHorario, en.HoraDesde, en.HoraHasta)
         Case TipoSP._D
            sqlC.CalendariosHorarios_D(en.IdCalendario, en.IdDiaSemana, en.IdHorario)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CalendarioHorario, ByVal dr As DataRow)
      With o
         .IdCalendario = Integer.Parse(dr(Entidades.CalendarioHorario.Columnas.IdCalendario.ToString()).ToString())
         .IdDiaSemana = DirectCast(Integer.Parse(dr(Entidades.CalendarioHorario.Columnas.IdDiaSemana.ToString()).ToString()), System.DayOfWeek)
         .IdHorario = Integer.Parse(dr(Entidades.CalendarioHorario.Columnas.IdHorario.ToString()).ToString())
         .NombreDiaSemana = dr("NombreDiaSemana").ToString()
         .HoraDesde = dr(Entidades.CalendarioHorario.Columnas.HoraDesde.ToString()).ToString()
         .HoraHasta = dr(Entidades.CalendarioHorario.Columnas.HoraHasta.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub InsertaDesdeCalendario(calendario As Entidades.Calendario)
      Dim orden As Integer = 0
      For Each horario As Entidades.CalendarioHorario In calendario.Horarios
         horario.IdCalendario = calendario.IdCalendario
         orden += 1
         horario.IdHorario = orden
         Inserta(horario)
      Next
   End Sub

   Public Sub BorrarDesdeCalendario(calendario As Entidades.Calendario)
      Dim sqlH As SqlServer.CalendariosHorarios = New SqlServer.CalendariosHorarios(da)
      sqlH.CalendariosHorarios_D(calendario.IdCalendario, idDiaSemana:=-1, idHorario:=0)
   End Sub

   Public Function GetUno(idCalendario As Integer, idDiaSemana As Integer, idHorario As Integer) As Entidades.CalendarioHorario
      Dim dt As DataTable = New SqlServer.CalendariosHorarios(Me.da).CalendariosHorarios_G1(idCalendario, idDiaSemana, idHorario)
      Dim o As Entidades.CalendarioHorario = New Entidades.CalendarioHorario()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idCalendario As Integer) As List(Of Entidades.CalendarioHorario)
      Return GetTodos(idCalendario:=idCalendario, idDiaSemana:=-1)
   End Function
   Public Function GetTodos(idCalendario As Integer, idDiaSemana As Integer) As List(Of Entidades.CalendarioHorario)
      Dim dt As DataTable = New SqlServer.CalendariosHorarios(Me.da).CalendariosHorarios_GA(idCalendario, idDiaSemana)
      Dim o As Entidades.CalendarioHorario
      Dim oLis As List(Of Entidades.CalendarioHorario) = New List(Of Entidades.CalendarioHorario)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CalendarioHorario()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetCodigoMaximo(idCalendario As Integer, idDiaSemana As Integer) As Integer
      Return New SqlServer.CalendariosHorarios(Me.da).GetCodigoMaximo(idCalendario, idDiaSemana)
   End Function

#End Region
End Class