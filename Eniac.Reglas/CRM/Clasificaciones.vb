Option Strict On
Option Explicit On

Public Class Clasificaciones
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.Clasificacion.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Clasificacion.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)
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

         Me.EjecutaSP(entidad, TipoSP._U)
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

         Me.EjecutaSP(entidad, TipoSP._D)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Clasificaciones = New SqlServer.Clasificaciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Clasificaciones(Me.da).Clasificaciones_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.Clasificacion = DirectCast(entidad, Entidades.Clasificacion)

      Dim sqlC As SqlServer.Clasificaciones = New SqlServer.Clasificaciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Clasificaciones_I(en.IdClasificacion, en.NombreClasificacion)
         Case TipoSP._U
            sqlC.Clasificaciones_U(en.IdClasificacion, en.NombreClasificacion)
         Case TipoSP._D
            sqlC.Clasificaciones_D(en.IdClasificacion)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Clasificacion, ByVal dr As DataRow)
      With o
         .IdClasificacion = dr.Field(Of Integer)(Entidades.Clasificacion.Columnas.IdClasificacion.ToString())
         .NombreClasificacion = dr.Field(Of String)(Entidades.Clasificacion.Columnas.NombreClasificacion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idClasificacion As Integer) As Entidades.Clasificacion
      Dim dt As DataTable = New SqlServer.Clasificaciones(Me.da).Clasificaciones_G1(idClasificacion)
      Dim o As Entidades.Clasificacion = New Entidades.Clasificacion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.Clasificacion)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Clasificacion
      Dim oLis As List(Of Entidades.Clasificacion) = New List(Of Entidades.Clasificacion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Clasificacion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Clasificaciones(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class
