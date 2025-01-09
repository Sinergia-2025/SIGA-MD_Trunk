Option Strict On
Option Explicit On

Public Class AreasComunes
    Inherits Eniac.Reglas.Base

#Region "Constructores"

    Public Sub New()
        Me.NombreEntidad = "AreasComunes"
        da = New Datos.DataAccess()
    End Sub

    Public Sub New(ByVal accesoDatos As Datos.DataAccess)
        Me.New()
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

    Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
        Return New SqlServer.AreasComunes(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
    End Function

    Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AreasComunes(Me.da).AreasComunes_GA(Nothing)
    End Function

   Public Overloads Function GetAll(esNave As Boolean?) As System.Data.DataTable
      Return New SqlServer.AreasComunes(Me.da).AreasComunes_GA(esNave)
   End Function

#End Region

#Region "Metodos Privados"

    Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
        Dim en As Entidades.AreaComun = DirectCast(entidad, Entidades.AreaComun)

        Try
            da.OpenConection()
            da.BeginTransaction()

            Dim sql As SqlServer.AreasComunes = New SqlServer.AreasComunes(Me.da)

            Select Case tipo

                Case TipoSP._I
                    sql.AreasComunes_I(en)

                Case TipoSP._U
                    sql.AreasComunes_U(en)

                Case TipoSP._D
                    sql.AreasComunes_D(en)

            End Select

            sql.ActualizaCoeficientes()

            da.CommitTransaction()

        Catch ex As Exception
            da.RollbakTransaction()
            Throw ex

        Finally
            da.CloseConection()
        End Try

    End Sub

    Private Sub CargarUno(ByVal o As Entidades.AreaComun, ByVal dr As DataRow)
        With o
            .IdAreaComun = dr(Entidades.AreaComun.Columnas.IdAreaComun.ToString()).ToString()
            .NombreAreaComun = dr(Entidades.AreaComun.Columnas.NombreAreaComun.ToString()).ToString()
            .ParticipaExpensas = CBool(dr(Entidades.AreaComun.Columnas.ParticipaExpensas.ToString()))
            If Not IsDBNull(dr(Entidades.AreaComun.Columnas.IdNave.ToString())) Then
                .Nave = New Naves(Me.da).GetUno(CInt(dr(Entidades.AreaComun.Columnas.IdNave.ToString())))
            End If
            If Not IsDBNull(dr(Entidades.AreaComun.Columnas.IdCliente.ToString())) Then
                .Cliente = New Clientes(Me.da).GetUno(CLng(dr(Entidades.AreaComun.Columnas.IdCliente.ToString())))
            End If
            .Superficie = CInt(dr(Entidades.AreaComun.Columnas.Superficie.ToString()))
            .Coeficiente = CDec(dr(Entidades.AreaComun.Columnas.Coeficiente.ToString()))
        End With
    End Sub

#End Region

#Region "Metodos Publicos"

    Public Function GetTodos() As List(Of Entidades.AreaComun)
        Dim dt As DataTable = Me.GetAll()
        Dim o As Entidades.AreaComun
        Dim oLis As List(Of Entidades.AreaComun) = New List(Of Entidades.AreaComun)
        For Each dr As DataRow In dt.Rows
            o = New Entidades.AreaComun()
            Me.CargarUno(o, dr)
            oLis.Add(o)
        Next
        Return oLis
    End Function

    Public Function GetUno(ByVal IdAreaComun As String) As Entidades.AreaComun
        Dim sql As SqlServer.AreasComunes = New SqlServer.AreasComunes(Me.da)

        Dim dt As DataTable = sql.AreasComunes_G1(IdAreaComun)

        Dim o As Entidades.AreaComun = New Entidades.AreaComun()
        If dt.Rows.Count > 0 Then
            Me.CargarUno(o, dt.Rows(0))
        Else
            Throw New Exception("No existe el Area Comun.")
        End If
        Return o
    End Function

    Public Function GetPorNombre(ByVal nombreAreaComun As String) As DataTable
        Dim sql As SqlServer.AreasComunes = New SqlServer.AreasComunes(Me.da)
        Return sql.GetPorNombre(nombreAreaComun)
    End Function

    Public Function Get1(ByVal idAreaComun As String) As DataTable
        Dim sql As SqlServer.AreasComunes = New SqlServer.AreasComunes(Me.da)
        Return sql.AreasComunes_G1(idAreaComun)
    End Function

    Public Function GetParaExpensas() As System.Data.DataTable
        Return New SqlServer.AreasComunes(Me.da).GetParaExpensas()
    End Function

#End Region

End Class
