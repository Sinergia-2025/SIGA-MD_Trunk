Option Strict Off
Public Class TiposMatriculas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposMatriculas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposMatriculas"
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
      Dim sql As SqlServer.TiposMatriculas = New SqlServer.TiposMatriculas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposMatriculas(Me.da).TiposMatriculas_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdTipoMatricula) AS Maximo")
         .Append(" FROM TiposMatriculas")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Eniac.Entidades.TipoMatricula = DirectCast(entidad, Eniac.Entidades.TipoMatricula)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.TiposMatriculas = New SqlServer.TiposMatriculas(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.TiposMatriculas_I(en.IdTipoMatricula, en.NombreTipoMatricula, en.TieneNumeros)
            Case TipoSP._U
               sqlC.TiposMatriculas_U(en.IdTipoMatricula, en.NombreTipoMatricula, en.TieneNumeros)
            Case TipoSP._D
               sqlC.TiposMatriculas_D(en.IdTipoMatricula)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Eniac.Entidades.TipoMatricula, ByVal dr As DataRow)
      With o
         .IdTipoMatricula = Integer.Parse(dr(Entidades.TipoMatricula.Columnas.IdTipoMatricula.ToString()))
         .NombreTipoMatricula = dr(Entidades.TipoMatricula.Columnas.NombreTipoMatricula.ToString()).ToString()
         .TieneNumeros = Boolean.Parse(dr(Entidades.TipoMatricula.Columnas.TieneNumeros.ToString()))
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idTipoMatricula As Integer) As Entidades.TipoMatricula
      Dim dt As DataTable = New SqlServer.TiposMatriculas(Me.da).TiposMatriculas_G1(idTipoMatricula)
      Dim o As Entidades.TipoMatricula = New Entidades.TipoMatricula()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Eniac.Entidades.TipoMatricula)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Eniac.Entidades.TipoMatricula
      Dim oLis As List(Of Eniac.Entidades.TipoMatricula) = New List(Of Eniac.Entidades.TipoMatricula)
      For Each dr As DataRow In dt.Rows
         o = New Eniac.Entidades.TipoMatricula()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   'Public Function GetTieneNumeros(ByVal idTipoMatricula As Integer) As Boolean
   '   Return New SqlServer.TiposMatriculas(Me.da).GetTieneNumeros(idTipoMatricula)
   'End Function

#End Region

   Public Function GetPorNombreExacto(TipoMatricula As String) As DataTable
      Try
         da.OpenConection()
         Return New SqlServer.TiposMatriculas(da).GetPorNombreExacto(TipoMatricula)
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function ExistePorNombreExacto(TipoMatricula As String) As Boolean
      Return GetPorNombreExacto(TipoMatricula).Rows.Count > 0
   End Function

End Class
