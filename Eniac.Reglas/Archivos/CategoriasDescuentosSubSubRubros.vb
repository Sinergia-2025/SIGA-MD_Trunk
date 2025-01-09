Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class CategoriasDescuentosSubSubRubros
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CategoriasDescuentosSubSubRubros"
      da = New Datos.DataAccess()
   End Sub
   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasDescuentosSubSubRubros"
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

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasDescuentosSubRubros(Me.da).CategoriasDescuentosSubRubros_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.CategoriasDescuentosSubSubRubros = DirectCast(entidad, Entidades.CategoriasDescuentosSubSubRubros)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CategoriasDescuentosSubSubRubros = New SqlServer.CategoriasDescuentosSubSubRubros(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.CategoriasDescuentosSubSubRubros_I(en.IdCategoria, en.IdSubSubRubro, en.IdSubRubro, en.IdRubro, en.DescuentoRecargoPorc1)
            Case TipoSP._U
               sqlC.CategoriasDescuentosSubSubRubros_U(en.IdCategoria, en.IdSubSubRubro, en.IdSubRubro, en.IdRubro, en.DescuentoRecargoPorc1)
            Case TipoSP._D
               sqlC.CategoriasDescuentosSubSubRubros_D(en.IdCategoria, en.IdSubSubRubro, en.IdSubRubro, en.IdRubro)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CategoriasDescuentosSubSubRubros, ByVal dr As DataRow)
      With o
         .IdCategoria = Integer.Parse(dr(Entidades.CategoriasDescuentosSubSubRubros.Columnas.IdCategoria.ToString()).ToString())
         .IdSubSubRubro = Integer.Parse(dr(Entidades.CategoriasDescuentosSubSubRubros.Columnas.IdSubSubRubro.ToString()).ToString())
         .IdSubRubro = Integer.Parse(dr(Entidades.CategoriasDescuentosSubSubRubros.Columnas.IdSubRubro.ToString()).ToString())
         .IdRubro = Integer.Parse(dr(Entidades.CategoriasDescuentosSubSubRubros.Columnas.IdRubro.ToString()).ToString())
         .DescuentoRecargoPorc1 = Decimal.Parse(dr(Entidades.CategoriasDescuentosSubSubRubros.Columnas.DescuentoRecargoPorc1.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetPorId(idCategoria As Integer) As DataTable
      Return New SqlServer.CategoriasDescuentosSubSubRubros(Me.da).CategoriasDescuentosSubSubRubros_GetAll(idCategoria)
   End Function

   Public Function GetPorNombreLike(nombre As String) As DataTable
      Return New SqlServer.CategoriasDescuentosSubSubRubros(da).CategoriasDescuentosSubSubRubros_G_PorRubroNombre(nombre, False)
   End Function

   Public Function GetUno(ByVal idCategoria As Integer) As Entidades.CategoriasDescuentosSubSubRubros
      Dim dt As DataTable = New SqlServer.CategoriasDescuentosSubSubRubros(Me.da).CategoriasDescuentosSubSubRubros_GetAll(idCategoria)
      Dim o As Entidades.CategoriasDescuentosSubSubRubros = New Entidades.CategoriasDescuentosSubSubRubros()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idCategoria As Integer) As List(Of Entidades.CategoriasDescuentosSubSubRubros)
      Dim lista As List(Of Entidades.CategoriasDescuentosSubSubRubros) = New List(Of Entidades.CategoriasDescuentosSubSubRubros)()
      Dim sql As SqlServer.CategoriasDescuentosSubSubRubros = New SqlServer.CategoriasDescuentosSubSubRubros(Me.da)
      Dim dt As DataTable = sql.CategoriasDescuentosSubSubRubros_GetAll(idCategoria)
      Dim o As Entidades.CategoriasDescuentosSubSubRubros
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CategoriasDescuentosSubSubRubros()
         Me.CargarUno(o, dt.Rows(0))
         lista.Add(o)
      Next
      Return lista
   End Function
   Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable
      Return New SqlServer.CategoriasDescuentosSubSubRubros(da).CategoriasDescuentosSubSubRubros_G_PorRubroNombre(nombre, True)
   End Function
#End Region

End Class