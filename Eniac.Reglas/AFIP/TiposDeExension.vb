Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class TiposDeExension
    Inherits Eniac.Reglas.Base

#Region "Constructores"

    Public Sub New()
        Me.NombreEntidad = "TiposDeExension"
        da = New Datos.DataAccess()
    End Sub

    Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
        Me.NombreEntidad = "TiposDeExension"
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
      Dim sql As SqlServer.TiposDeExension = New SqlServer.TiposDeExension(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

    Public Overrides Function GetAll() As System.Data.DataTable
        Return New SqlServer.TiposDeExension(Me.da).TiposDeExension_GA()
    End Function

    Private Function GetAll2(ByVal SoloActivos As Boolean) As System.Data.DataTable
        Return New SqlServer.TiposDeExension(Me.da).TiposDeExension_GA(SoloActivos)
    End Function

    Public Function GetCodigoMaximo() As Integer

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .Append("SELECT MAX(IdTipoDeExension) AS Maximo")
            .Append(" FROM TiposDeExension")
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
        Dim en As Entidades.TipoDeExension = DirectCast(entidad, Entidades.TipoDeExension)
        Try
            da.OpenConection()
            da.BeginTransaction()

            Dim sqlCG As SqlServer.TiposDeExension = New SqlServer.TiposDeExension(da)

            Select Case tipo
                Case TipoSP._I
                    sqlCG.TiposDeExension_I(en.IdTipoDeExension, en.NombreTipoDeExension, en.NombreTipoDeExensionAbrev, en.Activo)
                Case TipoSP._U
                    sqlCG.TiposDeExension_U(en.IdTipoDeExension, en.NombreTipoDeExension, en.NombreTipoDeExensionAbrev, en.Activo)
                Case TipoSP._D
                    sqlCG.TiposDeExension_D(en.IdTipoDeExension)
            End Select

            da.CommitTransaction()

        Catch ex As Exception
            da.RollbakTransaction()
            Throw ex
        Finally
            da.CloseConection()
        End Try
    End Sub

    Private Function GetPorId(ByVal IdTipoDeExension As Short) As DataTable

        Dim stbQuery As StringBuilder = New StringBuilder("")
        Me.SelectFiltrado(stbQuery)
        With stbQuery
            .AppendLine("  WHERE IdTipoDeExension = " & IdTipoDeExension.ToString())
        End With

        Return Me.da.GetDataTable(stbQuery.ToString())

    End Function

    Private Sub SelectFiltrado(ByRef stb As StringBuilder)

        With stb
            .Length = 0
            .AppendLine("SELECT TE.IdTipoDeExension")
            .AppendLine("      ,TE.NombreIdTipoDeExension")
            .AppendLine("      ,TE.NombreIdTipoDeExensionAbrev")
            .AppendLine("      ,TE.Activo")
            .AppendLine("  FROM TiposDeExension TE")
        End With

    End Sub

    Private Sub CargarUno(ByVal o As Entidades.TipoDeExension, ByVal dr As DataRow)
        With o
            .IdTipoDeExension = Short.Parse(dr("IdTipoDeExension").ToString())
            .NombreTipoDeExension = dr("NombreTipoDeExension").ToString()
            .NombreTipoDeExensionAbrev = dr("NombreTipoDeExensionAbrev").ToString()
            .Activo = Boolean.Parse(dr("Activo").ToString())
        End With
    End Sub

#End Region

#Region "Metodos publicos"

    Public Function GetTodos() As List(Of Entidades.TipoDeExension)
        Dim dt As DataTable = Me.GetAll()
        Dim o As Entidades.TipoDeExension
        Dim oLis As List(Of Entidades.TipoDeExension) = New List(Of Entidades.TipoDeExension)
        For Each dr As DataRow In dt.Rows
            o = New Entidades.TipoDeExension()
            Me.CargarUno(o, dr)
            oLis.Add(o)
        Next
        Return oLis
    End Function

    Public Function GetUno(ByVal IdCondicionGanancias As Short) As Entidades.TipoDeExension
        Try
            Me.da.OpenConection()
            Return Me._GetUno(IdCondicionGanancias)
        Catch ex As Exception
            Throw
        Finally
            Me.da.CloseConection()
        End Try
    End Function

    Public Function _GetUno(ByVal IdCondicionGanancias As Short) As Entidades.TipoDeExension
        Dim dt As DataTable = Me.GetPorId(IdCondicionGanancias)
        Dim o As Entidades.TipoDeExension = New Entidades.TipoDeExension()
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            Me.CargarUno(o, dr)
        End If
        Return o
    End Function

#End Region

End Class

