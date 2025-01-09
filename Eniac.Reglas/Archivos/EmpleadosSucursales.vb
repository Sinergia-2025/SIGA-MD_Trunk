Option Strict On
Option Explicit On
Public Class EmpleadosSucursales
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.EmpleadoSucursal.NombreTabla
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
      Dim sql As SqlServer.EmpleadosSucursales = New SqlServer.EmpleadosSucursales(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EmpleadosSucursales(Me.da).EmpleadosSucursales_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.EmpleadoSucursal = DirectCast(entidad, Entidades.EmpleadoSucursal)
      Dim sqlC As SqlServer.EmpleadosSucursales = New SqlServer.EmpleadosSucursales(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.EmpleadosSucursales_I(en.IdSucursal, en.IdEmpleado, en.IdCaja, en.Observacion)
         Case TipoSP._U
            sqlC.EmpleadosSucursales_U(en.IdSucursal, en.IdEmpleado, en.IdCaja, en.Observacion)
         Case TipoSP._D
            sqlC.EmpleadosSucursales_D(en.IdSucursal, en.IdEmpleado)
         Case TipoSP._M
            sqlC.EmpleadosSucursales_M(en.IdSucursal, en.IdEmpleado, en.IdCaja, en.Observacion)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EmpleadoSucursal, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.EmpleadoSucursal.Columnas.IdSucursal.ToString()).ToString())
         .IdEmpleado = Integer.Parse(dr(Entidades.EmpleadoSucursal.Columnas.IdEmpleado.ToString()).ToString())
         If IsNumeric(dr(Entidades.EmpleadoSucursal.Columnas.IdCaja.ToString())) Then
            .IdCaja = Integer.Parse(dr(Entidades.EmpleadoSucursal.Columnas.IdCaja.ToString()).ToString())
         End If
         .Observacion = dr(Entidades.EmpleadoSucursal.Columnas.Observacion.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Overloads Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overloads Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overloads Sub InsertaOActualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._M)
   End Sub


   Public Overloads Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Sub Borrar(IdEmpleado As Integer)
      Dim sqlC As SqlServer.EmpleadosSucursales = New SqlServer.EmpleadosSucursales(da)
      sqlC.EmpleadosSucursales_D(0, IdEmpleado)
   End Sub

   Public Function GetUno(idSucursal As Integer, idEmpleado As Integer) As Entidades.EmpleadoSucursal
      Dim dt As DataTable = New SqlServer.EmpleadosSucursales(Me.da).EmpleadosSucursales_G1(idSucursal, idEmpleado)
      Dim o As Entidades.EmpleadoSucursal = New Entidades.EmpleadoSucursal()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.EmpleadoSucursal)
      Return CargaLista(New SqlServer.EmpleadosSucursales(Me.da).EmpleadosSucursales_GA())
   End Function

   Public Function GetTodos(idSucursal As Integer) As List(Of Entidades.EmpleadoSucursal)
      Return CargaLista(New SqlServer.EmpleadosSucursales(Me.da).EmpleadosSucursales_GA(idSucursal))
   End Function

   Private Function CargaLista(dt As DataTable) As List(Of Entidades.EmpleadoSucursal)
      Dim o As Entidades.EmpleadoSucursal
      Dim oLis As List(Of Entidades.EmpleadoSucursal) = New List(Of Entidades.EmpleadoSucursal)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.EmpleadoSucursal()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class