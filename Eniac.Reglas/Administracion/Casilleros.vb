Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class Casilleros
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Casilleros"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Casilleros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Casilleros = New SqlServer.Casilleros(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Casilleros(Me.da).Casilleros_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.Casillero.Columnas.IdCasillero.ToString())
   End Function
   Public Function GetCodigoMaximo(ByVal campo As String) As Integer
      Return New SqlServer.Casilleros(Me.da).GetCodigoMaximo(campo)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.Casillero = DirectCast(entidad, Entidades.Casillero)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.Casilleros = New SqlServer.Casilleros(da)
         Select Case tipo
            Case TipoSP._I
               en.IdCasillero = CInt(sqlC.GetCodigoMaximo() + 1)
               sqlC.Casilleros_I(en)
            Case TipoSP._U
               sqlC.Casilleros_U(en)
            Case TipoSP._D
               sqlC.Casilleros_D(en.IdCasillero)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Casillero, ByVal dr As DataRow)
      With o
         .IdCasillero = Short.Parse(dr(Casillero.Columnas.IdCasillero.ToString()).ToString())
         .CodigoCasillero = Integer.Parse(dr(Casillero.Columnas.CodigoCasillero.ToString()).ToString())
         .Sector = New Sectores(Me.da).GetUno(Integer.Parse(dr(Sector.Columnas.IdSector.ToString()).ToString()))
         .FilaCasillero = Short.Parse(dr(Casillero.Columnas.FilaCasillero.ToString()).ToString())
         .ColumnaCasillero = Short.Parse(dr(Casillero.Columnas.ColumnaCasillero.ToString()).ToString())
         If Not IsDBNull(dr(Cliente.Columnas.IdCliente.ToString())) Then
            .Cliente = New Clientes(Me.da)._GetUno(Long.Parse(dr(Cliente.Columnas.IdCliente.ToString()).ToString()))
         End If
         .Activo = Boolean.Parse(dr(Casillero.Columnas.Activo.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idMotor As Integer) As Entidades.Casillero
      Dim dt As DataTable = New SqlServer.Casilleros(Me.da).Casilleros_G1(idMotor)
      Dim o As Entidades.Casillero = New Entidades.Casillero()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Entidades.Casillero)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Casillero
      Dim oLis As List(Of Entidades.Casillero) = New List(Of Entidades.Casillero)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Casillero()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
#End Region
End Class

