#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class TurnosCalendariosProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TurnosCalendariosProductos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TurnosCalendariosProductos"
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"
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
      Dim sql As SqlServer.TurnosCalendariosProductos = NewSql(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Protected Overridable Function NewSql(da As Datos.DataAccess) As SqlServer.TurnosCalendariosProductos
      Return New SqlServer.TurnosCalendariosProductos(da)
   End Function

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.TurnosCalendariosProductos = DirectCast(entidad, Entidades.TurnosCalendariosProductos)
         da.OpenConection()
         da.BeginTransaction()
         Dim sqlC As SqlServer.TurnosCalendariosProductos = NewSql(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.TurnosCalendariosProductos_I(en.IdTurno, en.IdProducto, en.Orden, en.NumeroSesion, en.ValorFluencia)
            Case TipoSP._U
               sqlC.TurnosCalendariosProductos_U(en.IdTurno, en.IdProducto, en.Orden, en.NumeroSesion, en.ValorFluencia)
            Case TipoSP._D
               sqlC.TurnosCalendariosProductos_D(en.IdTurno, en.IdProducto, en.Orden)
         End Select
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Protected Overridable Sub CargarUno(ByVal o As Entidades.TurnosCalendariosProductos, ByVal dr As DataRow)
      With o
         .IdTurno = Integer.Parse(dr(Entidades.TurnosCalendariosProductos.Columnas.IdTurno.ToString()).ToString())
         .IdProducto = dr(Entidades.TurnosCalendariosProductos.Columnas.IdProducto.ToString()).ToString()
         .Orden = Integer.Parse(dr(Entidades.TurnosCalendariosProductos.Columnas.Orden.ToString()).ToString())
         .NombreProducto = dr(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
         If IsNumeric(dr(Entidades.TurnosCalendariosProductos.Columnas.NumeroSesion.ToString()).ToString()) Then
            .NumeroSesion = Integer.Parse(dr(Entidades.TurnosCalendariosProductos.Columnas.NumeroSesion.ToString()).ToString())
         End If
         If IsNumeric(dr(Entidades.TurnosCalendariosProductos.Columnas.ValorFluencia.ToString()).ToString()) Then
            .ValorFluencia = Integer.Parse(dr(Entidades.TurnosCalendariosProductos.Columnas.ValorFluencia.ToString()).ToString())
         End If
      End With
   End Sub
#End Region
#Region "Metodos publicos"
   Public Overridable Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overridable Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Overloads Sub Actualizar(turnos As List(Of Entidades.TurnosCalendariosProductos), turnosBorrados As List(Of Entidades.TurnosCalendariosProductos))
      Try
         da.OpenConection()
         da.BeginTransaction()
         If turnos IsNot Nothing AndAlso turnos.Count > 0 Then
            For Each turno As Entidades.TurnosCalendariosProductos In turnos
               If turno.IdTurno = 0 Then
                  Inserta(turno)
               Else
                  Actualiza(turno)
               End If
            Next
         End If
         If turnosBorrados IsNot Nothing AndAlso turnosBorrados.Count > 0 Then
            For Each turno As Entidades.TurnosCalendariosProductos In turnosBorrados
               If turno.IdTurno <> 0 Then
                  Borra(turno)
               End If
            Next
         End If
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Function GetZonaCliente(idCliente As Long, idProducto As String, FechaDesde As Date) As Integer
      Dim Valor As Integer = 0
      Dim dt As DataTable = New SqlServer.TurnosCalendariosProductos(Me.da).TurnosCalendariosCliente_G_GetAll(idCliente, idProducto, FechaDesde)
      Dim o As Entidades.TurnosCalendariosProductos
      For Each dr As DataRow In dt.Rows
         If Not String.IsNullOrWhiteSpace(dr(0).ToString()) Then
            Valor = Integer.Parse(dr(0).ToString())
         End If

      Next
      Return Valor
   End Function
   Public Function GetTodos(idTurno As Integer) As List(Of Entidades.TurnosCalendariosProductos)
      Dim dt As DataTable = New SqlServer.TurnosCalendariosProductos(Me.da).TurnosCalendariosProductos_G_GetAll(idTurno)
      Dim o As Entidades.TurnosCalendariosProductos
      Dim oLis As List(Of Entidades.TurnosCalendariosProductos) = New List(Of Entidades.TurnosCalendariosProductos)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TurnosCalendariosProductos()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Function GetUno(idTurno As Integer) As Entidades.TurnosCalendariosProductos
      Dim dt As DataTable = NewSql(da).TurnosCalendariosProductos_G_GetAll(idTurno)
      Dim o As Entidades.TurnosCalendariosProductos = NewEntidad()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function
   Protected Overridable Function NewEntidad() As Entidades.TurnosCalendariosProductos
      Return New Entidades.TurnosCalendariosProductos()
   End Function
#End Region
End Class
