Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class CategoriasMercadoLibre
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = "CategoriasMercadoLibre"
      da = New Datos.DataAccess()
   End Sub
   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasMercadoLibre"
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
   Public Sub EstadoCategoria(EstadoActivo As Entidades.Publicos.SiNoTodos)
      EjecutaConConexion(Sub()
                            _EstadoCategoria(EstadoActivo)
                         End Sub)
   End Sub
   Public Sub _EstadoCategoria(EstadoActivo As Entidades.Publicos.SiNoTodos)
      Dim sqlC As SqlServer.CategoriasMercadoLibre = New SqlServer.CategoriasMercadoLibre(da)
      sqlC.CategoriasMercadoLibre_A(EstadoActivo)
   End Sub


   Public Overrides Function GetAll() As DataTable
      Return GetAll(Entidades.Publicos.SiNoTodos.TODOS)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP, Optional EstadoActivo As Entidades.Publicos.SiNoTodos = Entidades.Publicos.SiNoTodos.SI)

      Dim cate As Entidades.CategoriasMercadoLibre = DirectCast(entidad, Entidades.CategoriasMercadoLibre)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CategoriasMercadoLibre = New SqlServer.CategoriasMercadoLibre(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.CategoriasMercadoLibre_I(cate.IdCategoria, cate.NombreCategoria, cate.ActivoCategoria)
            Case TipoSP._U
               sqlC.CategoriasMercadoLibre_U(cate.IdCategoria, cate.NombreCategoria, cate.ActivoCategoria)
            Case TipoSP._D
               sqlC.CategoriasMercadoLibre_D(cate.IdCategoria)
         End Select
         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function ExisteCategoria(id As String) As Boolean
      EjecutaConConexion(Sub()
                            ExisteCategoria = _ExisteCategoria(id)
                         End Sub)
   End Function
   Public Function _ExisteCategoria(id As String) As Boolean
      Return New SqlServer.CategoriasMercadoLibre(da).ExisteCategoria(id)
   End Function



   Private Function GetPorId(ByVal idCategoria As Integer) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT CML.idCategoria")
         .Append("      ,CML.NombreCategoria")
         .AppendLine("  ,CML.ActivoCategoria")
         .Append(" FROM CategoriasMercadoLibre CML")
         .Append(" WHERE idCategoria =" & idCategoria.ToString())
      End With
      Return da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overloads Function GetAll(EstadoActivo As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.CategoriasMercadoLibre(Me.da).CategoriasMercadoLibre_GA(EstadoActivo)
   End Function

   Private Sub CargarUno(o As Entidades.CategoriasMercadoLibre, dr As DataRow)
      With o
         .IdCategoria = dr.Field(Of String)(Entidades.CategoriasMercadoLibre.Columnas.IdCategoria.ToString())
         .NombreCategoria = dr.Field(Of String)(Entidades.CategoriasMercadoLibre.Columnas.NombreCategoria.ToString())
         .ActivoCategoria = dr.Field(Of Integer)(Entidades.CategoriasMercadoLibre.Columnas.ActivoCategoria.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(ByVal idCategoria As Integer) As Entidades.CategoriasMercadoLibre
      Dim dt As DataTable = Me.GetPorId(idCategoria)
      Dim o As Entidades.CategoriasMercadoLibre = New Entidades.CategoriasMercadoLibre()
      If dt.Rows.Count > 0 Then
         CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function
#End Region

End Class
