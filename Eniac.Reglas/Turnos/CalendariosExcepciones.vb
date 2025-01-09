Option Strict On
Option Explicit On
Public Class CalendariosExcepciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CalendariosExcepciones"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CalendariosExcepciones"
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
      Dim sql As SqlServer.CalendariosExcepciones = New SqlServer.CalendariosExcepciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CalendariosExcepciones(Me.da).CalendariosExcepciones_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.CalendarioExcepcion = DirectCast(entidad, Entidades.CalendarioExcepcion)

      Dim sqlC As SqlServer.CalendariosExcepciones = New SqlServer.CalendariosExcepciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CalendariosExcepciones_I(en.IdCalendario, en.IdDiaSemana, en.IdExcepcion, en.FechaExcepcion)
         Case TipoSP._U
            sqlC.CalendariosExcepciones_U(en.IdCalendario, en.IdDiaSemana, en.IdExcepcion, en.FechaExcepcion)
         Case TipoSP._D
            sqlC.CalendariosExcepciones_D(en.IdCalendario)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CalendarioExcepcion, ByVal dr As DataRow)
      With o
         .IdCalendario = Integer.Parse(dr(Entidades.CalendarioExcepcion.Columnas.IdCalendario.ToString()).ToString())
         .IdDiaSemana = DirectCast(Integer.Parse(dr(Entidades.CalendarioExcepcion.Columnas.IdDiaSemana.ToString()).ToString()), System.DayOfWeek)
         .IdExcepcion = Integer.Parse(dr(Entidades.CalendarioExcepcion.Columnas.IdExcepcion.ToString()).ToString())
         .NombreDiaSemana = dr("NombreDiaSemana").ToString()
         .FechaExcepcion = Date.Parse(dr(Entidades.CalendarioExcepcion.Columnas.FechaExcepcion.ToString()).ToString())
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

   'Public Sub InsertaDesdeCalendario(calendario As Entidades.Calendario)
   '   Dim orden As Integer = 0
   '   For Each horario As Entidades.CalendarioExcepcion In calendario.Horarios
   '      horario.IdCalendario = calendario.IdCalendario
   '      orden += 1
   '      horario.IdHorario = orden
   '      Inserta(horario)
   '   Next
   'End Sub

   'Public Sub BorrarDesdeCalendario(calendario As Entidades.Calendario)
   '   Dim sqlH As SqlServer.CalendariosExcepciones = New SqlServer.CalendariosExcepciones(da)
   '   sqlH.CalendariosExcepciones_D(calendario.IdCalendario, idDiaSemana:=-1, idHorario:=0)
   'End Sub

   Public Function GetUno(idCalendario As Integer, idExcepcion As Integer) As Entidades.CalendarioExcepcion
      Dim dt As DataTable = New SqlServer.CalendariosExcepciones(Me.da).CalendariosExcepciones_G1(idCalendario, idExcepcion)
      Dim o As Entidades.CalendarioExcepcion = New Entidades.CalendarioExcepcion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function _GetTodos(idCalendario As Integer) As DataTable
      Return New SqlServer.CalendariosExcepciones(Me.da).CalendariosExcepciones_GA(idCalendario)
   End Function
   Public Function GetTodos(idCalendario As Integer, idDiaSemana As Integer) As List(Of Entidades.CalendarioExcepcion)
      Dim dt As DataTable = New SqlServer.CalendariosExcepciones(Me.da).CalendariosExcepciones_GA(idCalendario, idDiaSemana)
      Dim o As Entidades.CalendarioExcepcion
      Dim oLis As List(Of Entidades.CalendarioExcepcion) = New List(Of Entidades.CalendarioExcepcion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CalendarioExcepcion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetCodigoMaximo(idCalendario As Integer) As Integer
      Return New SqlServer.CalendariosExcepciones(Me.da).GetCodigoMaximo(idCalendario)
   End Function

   Public Sub GrabarCalendariosExcepciones(ByVal IdCalendario As Integer, _
                                          ByVal listado As DataTable)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.CalendariosExcepciones = New SqlServer.CalendariosExcepciones(Me.da)

         Dim IdExcepcion As Integer = 0

         sql.CalendariosExcepciones_D(IdCalendario)

         '  Dim sql2 As SqlServer.Clientes = New SqlServer.Clientes(Me.da, Entidades.Cliente.ModoClienteProspecto.Cliente)

         For Each dr As DataRow In listado.Rows
            If dr.RowState <> DataRowState.Deleted  Then

               IdExcepcion = sql.GetCodigoMaximo(IdCalendario) + 1

               sql.CalendariosExcepciones_I(IdCalendario, Integer.Parse(dr("IdDiaSemana").ToString()), _
                                           IdExcepcion, Date.Parse(dr("FechaExcepcion").ToString()))
            End If
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

#End Region
End Class