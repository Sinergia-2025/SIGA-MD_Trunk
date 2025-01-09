
Option Explicit On
Option Strict On

Imports System.Text
Imports Eniac.Datos

Public Class UsuariosClaves
   Inherits Eniac.Reglas.Base

#Region "Constructores"

    Public Sub New()
        Me.NombreEntidad = "UsuariosClaves"
        da = New Datos.DataAccess(CadenaSegura)
    End Sub
    Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "UsuariosClaves"
        da = accesoDatos
    End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT U.Id ")
         .Append("       ,U.Nombre ")
         .Append("       ,U.Clave ")
         .Append("       ,U.Correo ")
         .Append("       ,U.FechaUltimaModContraseña ")
         .Append("   FROM UsuariosClaves U ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

    Public Overrides Function GetAll() As System.Data.DataTable
        Return New SqlServer.UsuariosClaves(Me.da).UsuariosClaves_GA()
    End Function

#End Region

#Region "Metodos Publicos"

    Public Function GetTodos() As List(Of Entidades.Usuario)
        Dim dt As DataTable = Me.GetAll()
        Dim o As Entidades.Usuario
        Dim oLis As List(Of Entidades.Usuario) = New List(Of Entidades.Usuario)
        For Each dr As DataRow In dt.Rows
            o = New Entidades.Usuario()
            Me.CargarUno(o, dr)
            oLis.Add(o)
        Next
        Return oLis
    End Function

    Public Function GetUno(ByVal idUsuario As String, ByVal FechaModContraseña As DateTime) As Entidades.Usuario
        Dim sql As SqlServer.UsuariosClaves = New SqlServer.UsuariosClaves(Me.da)

        Dim dt As DataTable = sql.UsuariosClaves_G1(idUsuario, FechaModContraseña)

        Dim o As Entidades.Usuario = New Entidades.Usuario()
        If dt.Rows.Count > 0 Then
            Me.CargarUno(o, dt.Rows(0))
        Else
            Throw New Exception("No existe el Usuario.")
        End If
        Return o
    End Function

    Public Function GetUsuariosClaves(ByVal idUsuario As String) As DataTable

        Dim sql As SqlServer.UsuariosClaves = New SqlServer.UsuariosClaves(Me.da)

      Dim dt As DataTable = sql.GetUsuariosClaves(idUsuario)

        Return dt

    End Function

#End Region

#Region "Metodos"

   
   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim usuario As Entidades.UsuarioClave = DirectCast(entidad, Entidades.UsuarioClave)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.UsuariosClaves = New SqlServer.UsuariosClaves(Me.da)
         Select Case tipo
            Case TipoSP._I
               sql.UsuariosClaves_I(usuario.Id, usuario.FechaModContraseña, usuario.Clave)
            Case TipoSP._U
               sql.UsuariosClaves_U(usuario.Id, usuario.FechaModContraseña, usuario.Clave)
            Case TipoSP._D
               sql.UsuariosClaves_D(usuario.Id)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub


    Private Sub CargarUno(ByVal o As Entidades.Usuario, ByVal dr As DataRow)
        With o
         .Usuario = dr(Eniac.Entidades.UsuarioClave.Columnas.Id.ToString()).ToString()
         .FechaUltimaModContraseña = Date.Parse(dr(Eniac.Entidades.UsuarioClave.Columnas.FechaModContraseña.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Eniac.Entidades.UsuarioClave.Columnas.Clave.ToString()).ToString()) Then
            .Clave = dr(Eniac.Entidades.UsuarioClave.Columnas.Clave.ToString()).ToString()
         End If

        End With
    End Sub

#End Region
End Class
