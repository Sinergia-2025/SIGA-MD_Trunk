Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class TiposMotores
    Inherits Eniac.Reglas.Base

#Region "Constructores"

    Public Sub New()
        Me.NombreEntidad = "TiposMotores"
        da = New Datos.DataAccess()
    End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposMotores"
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
        Dim sql As SqlServer.TiposMotores = New SqlServer.TiposMotores(Me.da)
        Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
    End Function

    Public Overrides Function GetAll() As System.Data.DataTable
        Return New SqlServer.TiposMotores(Me.da).TiposMotores_GA()
    End Function

    Public Function GetCodigoMaximo() As Short
        Return Convert.ToInt16(GetCodigoMaximo(Entidades.TipoMotor.Columnas.IdTipoMotor.ToString()))
    End Function
    Public Function GetCodigoMaximo(ByVal campo As String) As Long
        Return New SqlServer.TiposMotores(Me.da).GetCodigoMaximo(campo)
    End Function

#End Region

#Region "Metodos Privados"

    Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
        Try
            Dim en As Entidades.TipoMotor = DirectCast(entidad, Entidades.TipoMotor)

            da.OpenConection()
            da.BeginTransaction()

            Dim sqlC As SqlServer.TiposMotores = New SqlServer.TiposMotores(da)
            Select Case tipo
                Case TipoSP._I
                    sqlC.TiposMotores_I(en)
                Case TipoSP._U
                    sqlC.TiposMotores_U(en)
                Case TipoSP._D
                    sqlC.TiposMotores_D(en.IdTipoMotor)
            End Select

            da.CommitTransaction()
        Catch
            da.RollbakTransaction()
            Throw
        Finally
            da.CloseConection()
        End Try
    End Sub

    Private Sub CargarUno(ByVal o As Entidades.TipoMotor, ByVal dr As DataRow)
        With o
            .IdTipoMotor = Short.Parse(dr(TipoMotor.Columnas.IdTipoMotor.ToString()).ToString())
            .NombreTipoMotor = dr(TipoMotor.Columnas.NombreTipoMotor.ToString()).ToString()
        End With
    End Sub

#End Region

#Region "Metodos publicos"

    Public Function GetUno(ByVal idMotor As Integer) As Entidades.TipoMotor
        Dim dt As DataTable = New SqlServer.TiposMotores(Me.da).TiposMotores_G1(idMotor)
        Dim o As Entidades.TipoMotor = New Entidades.TipoMotor()
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            Me.CargarUno(o, dt.Rows(0))
        End If
        Return o
    End Function

    Public Function GetTodas() As List(Of Entidades.TipoMotor)
        Dim dt As DataTable = Me.GetAll()
        Dim o As Entidades.TipoMotor
        Dim oLis As List(Of Entidades.TipoMotor) = New List(Of Entidades.TipoMotor)
        For Each dr As DataRow In dt.Rows
            o = New Entidades.TipoMotor()
            Me.CargarUno(o, dr)
            oLis.Add(o)
        Next
        Return oLis
    End Function
#End Region
End Class
