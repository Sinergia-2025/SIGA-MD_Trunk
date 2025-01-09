Option Strict On
Option Explicit On
Public Class MovilRutasClientes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.MovilRutaCliente.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me._Insertar(DirectCast(entidad, Entidades.MovilRutaCliente))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      MyBase.Actualizar(entidad)
      'Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me._Borrar(DirectCast(entidad, Entidades.MovilRutaCliente))
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.MovilRutasClientes = New SqlServer.MovilRutasClientes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MovilRutasClientes(Me.da).MovilRutasClientes_GA(activas:=Nothing, soloConSaldo:=False)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.MovilRutaCliente, ByVal tipo As TipoSP)
      Dim sqlC As SqlServer.MovilRutasClientes = New SqlServer.MovilRutasClientes(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.MovilRutasClientes_I(en.IdRuta, en.Dia, en.Orden, en.IdCliente)
            'Case TipoSP._U
            '   sqlC.MovilRutasClientes_U(en.IdRuta, en.Dia, en.Orden, en.IdCliente)
         Case TipoSP._D
            sqlC.MovilRutasClientes_D(en.IdRuta, en.Dia, en.Orden, en.IdCliente)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.MovilRutaCliente, ByVal dr As DataRow)
      With o
         .IdRuta = Integer.Parse(dr(Entidades.MovilRutaCliente.Columnas.IdRuta.ToString()).ToString())
         .Dia = Integer.Parse(dr(Entidades.MovilRutaCliente.Columnas.Dia.ToString()).ToString())
         .Orden = Integer.Parse(dr(Entidades.MovilRutaCliente.Columnas.Orden.ToString()).ToString())
         .IdCliente = Integer.Parse(dr(Entidades.MovilRutaCliente.Columnas.IdCliente.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(ByVal entidad As Entidades.MovilRutaCliente)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Borrar(ByVal entidad As Entidades.MovilRutaCliente)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idMovilRutaCliente As Integer, dia As Integer, orden As Integer, idCliente As Long) As Entidades.MovilRutaCliente
      Dim dt As DataTable = New SqlServer.MovilRutasClientes(Me.da).MovilRutasClientes_G1(idMovilRutaCliente, dia, orden, idCliente)
      Dim o As Entidades.MovilRutaCliente = New Entidades.MovilRutaCliente()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.MovilRutaCliente)
      Return GetTodos(activas:=Nothing)
   End Function
   Public Function GetTodos(activas As Boolean?) As List(Of Entidades.MovilRutaCliente)
      Return GetTodos(activas:=Nothing, soloConSaldo:=False)
   End Function
   Public Function GetTodosParaSincronizar() As DataTable
      Return New SqlServer.MovilRutasClientes(Me.da).MovilRutasClientes_GA_ParaSincronizar()
   End Function
   Public Function GetTodos(activas As Boolean?, soloConSaldo As Boolean) As List(Of Entidades.MovilRutaCliente)
      Dim dt As DataTable = New SqlServer.MovilRutasClientes(Me.da).MovilRutasClientes_GA(activas, soloConSaldo)
      Dim o As Entidades.MovilRutaCliente
      Dim oLis As List(Of Entidades.MovilRutaCliente) = New List(Of Entidades.MovilRutaCliente)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.MovilRutaCliente()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorRuta(idRuta As Integer) As DataTable
      Return New SqlServer.MovilRutasClientes(Me.da).MovilRutasClientes_GA(idRuta)
   End Function
   Public Function GetOrdenRutaCliente(idRuta As Integer, dia As Integer) As Integer
      Return New SqlServer.MovilRutasClientes(Me.da).OrdenRutaCliente_G(idRuta, dia)
   End Function
   Public Function ExisteClienteEnRuta(idRuta As Integer, dia As Integer, idCliente As Long) As Boolean
      Return New SqlServer.MovilRutasClientes(Me.da).MovilRutasClientes_GA(idRuta, dia, idCliente).Rows.Count > 0
   End Function
   Public Function GetClientesParaRutas(tablaVacia As Boolean) As DataTable
      Return New SqlServer.MovilRutasClientes(da).GetClientesParaRutas(tablaVacia)
   End Function

   Public Function GetClientesAsignados(tablaVacia As Boolean) As DataTable
      Return New SqlServer.MovilRutasClientes(da).GetClientesAsignados(tablaVacia)
   End Function

   Public Sub Guardar(ruta As Entidades.MovilRuta, dtRutasClientes As DataTable)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.MovilRutasClientes = New SqlServer.MovilRutasClientes(da)
         sql.MovilRutasClientes_D(Nothing, Nothing, Nothing, Nothing)

         For Each drRutaCliente As DataRow In dtRutasClientes.Rows
            sql.MovilRutasClientes_I(Integer.Parse(drRutaCliente(Entidades.MovilRutaCliente.Columnas.IdRuta.ToString()).ToString()),
                                     Integer.Parse(drRutaCliente(Entidades.MovilRutaCliente.Columnas.Dia.ToString()).ToString()),
                                     Integer.Parse(drRutaCliente(Entidades.MovilRutaCliente.Columnas.Orden.ToString()).ToString()),
                                     Long.Parse(drRutaCliente(Entidades.MovilRutaCliente.Columnas.IdCliente.ToString()).ToString()))
         Next

         If Publicos.Logistica.NormalizaClientesEnRutas Then
            sql.NormalizaClienteSegunRuta()
         End If

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

#End Region
End Class