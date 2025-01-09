Option Strict On
Option Explicit On
Public Class CategoriasAcciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = "CategoriasAcciones"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasAcciones"
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
      Return New SqlServer.CategoriasAcciones(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasAcciones(Me.da).CategoriasAcciones_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CategoriasAcciones(da).GetCodigoMaximo()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.CategoriaAccion = DirectCast(entidad, Entidades.CategoriaAccion)
         da.OpenConection()
         da.BeginTransaction()
         Dim sqlC As SqlServer.CategoriasAcciones = New SqlServer.CategoriasAcciones(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.CategoriasAcciones_I(en.IdCategoriaAccion, en.NombreCategoriaAccion, en.Pies, en.CoeficienteDistribucionExpensas)
            Case TipoSP._U
               sqlC.CategoriasAcciones_U(en.IdCategoriaAccion, en.NombreCategoriaAccion, en.Pies, en.CoeficienteDistribucionExpensas)
            Case TipoSP._D
               sqlC.CategoriasAcciones_D(en.IdCategoriaAccion)
         End Select
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CategoriaAccion, ByVal dr As DataRow)
      With o
         .IdCategoriaAccion = Integer.Parse(dr(Entidades.CategoriaAccion.Columnas.IdCategoriaAccion.ToString()).ToString())
         .NombreCategoriaAccion = dr(Entidades.CategoriaAccion.Columnas.NombreCategoriaAccion.ToString()).ToString()
         .Pies = Integer.Parse(dr(Entidades.CategoriaAccion.Columnas.Pies.ToString()).ToString())
         .CoeficienteDistribucionExpensas = Decimal.Parse(dr(Entidades.CategoriaAccion.Columnas.CoeficienteDistribucionExpensas.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Function GetUno(ByVal IdCategoriaAccion As Integer) As Entidades.CategoriaAccion
      Dim dt As DataTable = New SqlServer.CategoriasAcciones(Me.da).CategoriasAcciones_G1(IdCategoriaAccion)
      Dim o As Entidades.CategoriaAccion = New Entidades.CategoriaAccion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Entidades.CategoriaAccion)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.CategoriaAccion
      Dim oLis As List(Of Entidades.CategoriaAccion) = New List(Of Entidades.CategoriaAccion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CategoriaAccion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorNombreExacto(nombreCategoriaAccion As String) As DataTable
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Return New SqlServer.CategoriasAcciones(da).GetPorNombreExacto(nombreCategoriaAccion)
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Function

   Public Function ExistePorNombreExacto(nombreCategoriaAccion As String) As Boolean
      Return GetPorNombreExacto(nombreCategoriaAccion).Rows.Count > 0
   End Function
#End Region

End Class