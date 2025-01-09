#Region "Option"
Option Explicit On
Option Strict On
#End Region
Public Class EstadosClientes
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "EstadosClientes"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "EstadosClientes"
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
      Dim sql As SqlServer.EstadosClientes = New SqlServer.EstadosClientes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosClientes(Me.da).EstadosClientes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.EstadoCliente = DirectCast(entidad, Entidades.EstadoCliente)

      Dim sql As SqlServer.EstadosClientes = New SqlServer.EstadosClientes(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.EstadosClientes_I(en.IdEstadoCliente, en.NombreEstadoCliente, en.Color)
         Case TipoSP._U
            sql.EstadosClientes_U(en.IdEstadoCliente, en.NombreEstadoCliente, en.Color)
         Case TipoSP._D
            sql.EstadosClientes_D(en.IdEstadoCliente)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EstadoCliente, ByVal dr As DataRow)
      With o
         .IdEstadoCliente = Int32.Parse(dr(Entidades.EstadoCliente.Columnas.IdEstadoCliente.ToString()).ToString())
         .NombreEstadoCliente = dr(Entidades.EstadoCliente.Columnas.NombreEstadoCliente.ToString()).ToString()
         If IsNumeric(dr(Entidades.EstadoCliente.Columnas.Color.ToString())) Then
            .Color = Integer.Parse(dr(Entidades.EstadoCliente.Columnas.Color.ToString()).ToString())
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.EstadoCliente)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.EstadoCliente), dr), Function() New Entidades.EstadoCliente())
   End Function

   Public Function GetUno(ByVal idEstadoCliente As Integer) As Entidades.EstadoCliente
      Try
         Me.da.OpenConection()
         Return Me._GetUno(idEstadoCliente, AccionesSiNoExisteRegistro.Excepcion)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetXNombre(nombreEstadoCliente As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoCliente
      Dim sql As SqlServer.EstadosClientes = New SqlServer.EstadosClientes(Me.da)

      Dim dt As DataTable = sql.GetXNombre(nombreEstadoCliente)

      Dim o As Entidades.EstadoCliente = New Entidades.EstadoCliente()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New KeyNotFoundException(String.Format("No existe el Estado con NombreEstadoCliente ´{0}´", nombreEstadoCliente))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Public Function _GetUno(idEstadoCliente As Integer) As Entidades.EstadoCliente
      Return _GetUno(idEstadoCliente, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function _GetUno(idEstadoCliente As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoCliente
      Dim sql As SqlServer.EstadosClientes = New SqlServer.EstadosClientes(Me.da)

      Dim dt As DataTable = sql.EstadosClientes_G1(idEstadoCliente)

      Dim o As Entidades.EstadoCliente = New Entidades.EstadoCliente()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New KeyNotFoundException(String.Format("No existe el Estado con IdEstadoCliente {0}", idEstadoCliente))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Public Function GetProximoNumero() As Integer
      Return New SqlServer.EstadosClientes(Me.da).EstadosClientes_GetMaximo()
   End Function

   Public Function GetTop1() As Integer
      Dim result As Integer = 0
      Dim dt As DataTable = New SqlServer.EstadosClientes(da).GetTop1()
      If dt.Rows.Count > 0 Then result = dt.Rows(0).Field(Of Integer)(Entidades.EstadoCliente.Columnas.IdEstadoCliente.ToString())
      Return result
   End Function

#End Region
End Class