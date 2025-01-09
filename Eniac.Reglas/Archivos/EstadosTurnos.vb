#Region "Option"
Option Explicit On
Option Strict On
#End Region
Public Class EstadosTurnos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "EstadosTurnos"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "EstadosTurnos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.EstadosTurnos = New SqlServer.EstadosTurnos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosTurnos(Me.da).EstadosTurnos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.EstadoTurno = DirectCast(entidad, Entidades.EstadoTurno)

      Dim sql As SqlServer.EstadosTurnos = New SqlServer.EstadosTurnos(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.EstadosTurnos_I(en.IdEstadoTurno, en.NombreEstadoTurno, en.Color, en.Finalizado)
         Case TipoSP._U
            sql.EstadosTurnos_U(en.IdEstadoTurno, en.NombreEstadoTurno, en.Color, en.Finalizado)
         Case TipoSP._D
            sql.EstadosTurnos_D(en.IdEstadoTurno)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EstadoTurno, ByVal dr As DataRow)
      With o
         .IdEstadoTurno = dr(Entidades.EstadoTurno.Columnas.IdEstadoTurno.ToString()).ToString()
         .NombreEstadoTurno = dr(Entidades.EstadoTurno.Columnas.NombreEstadoTurno.ToString()).ToString()
         If IsNumeric(dr(Entidades.EstadoTurno.Columnas.Color.ToString())) Then
            .Color = Integer.Parse(dr(Entidades.EstadoTurno.Columnas.Color.ToString()).ToString())
         End If
         .Finalizado = Boolean.Parse(dr(Entidades.EstadoTurno.Columnas.Finalizado.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.EstadoTurno)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.EstadoTurno), dr), Function() New Entidades.EstadoTurno())
   End Function

   Public Function GetXNombre(nombreEstadoTurno As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoTurno
      Dim sql As SqlServer.EstadosTurnos = New SqlServer.EstadosTurnos(Me.da)

      Dim dt As DataTable = sql.GetXNombre(nombreEstadoTurno)

      Dim o As Entidades.EstadoTurno = New Entidades.EstadoTurno()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New KeyNotFoundException(String.Format("No existe el Estado con NombreEstadoTurno ´{0}´", nombreEstadoTurno))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Public Function GetUno(idEstadoTurno As String) As Entidades.EstadoTurno
      Return GetUno(idEstadoTurno, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idEstadoTurno As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoTurno
      Dim sql As SqlServer.EstadosTurnos = New SqlServer.EstadosTurnos(Me.da)

      Dim dt As DataTable = sql.EstadosTurnos_G1(idEstadoTurno)

      Dim o As Entidades.EstadoTurno = New Entidades.EstadoTurno()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New KeyNotFoundException(String.Format("No existe el Estado con IdEstadoTurno {0}", idEstadoTurno))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function
   Public Function GetCombo() As List(Of Entidades.EstadoTurno)
      Dim dt As DataTable = New SqlServer.EstadosTurnos(Me.da).TiposTurnos_GCombo()
      Dim o As Entidades.EstadoTurno
      Dim oLis As List(Of Entidades.EstadoTurno) = New List(Of Entidades.EstadoTurno)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.EstadoTurno()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   'Public Function GetProximoNumero() As Integer
   '   Return New SqlServer.EstadosTurnos(Me.da).EstadosTurnos_GetMaximo()
   'End Function
#End Region
End Class