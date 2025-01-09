
Option Explicit On
Option Strict On

Imports System.Text
Public Class ContabilidadTiposCuentas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContabilidadTiposCuentas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ContabilidadTiposCuentas"
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
      Dim sql As SqlServer.ContabilidadTiposCuentas = New SqlServer.ContabilidadTiposCuentas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ContabilidadTiposCuentas(Me.da).TipoCuenta_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.ContabilidadTipoCuenta = DirectCast(entidad, Entidades.ContabilidadTipoCuenta)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadTiposCuentas = New SqlServer.ContabilidadTiposCuentas(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.TiposCuentas_I(en.IdTipoCuenta, en.NombreTipoCuenta)

            Case TipoSP._U
               sql.TiposCuentas_U(en.IdTipoCuenta, en.NombreTipoCuenta)

            Case TipoSP._D
               sql.TiposCuentas_D(en.IdTipoCuenta)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUna(ByVal o As Entidades.ContabilidadTipoCuenta, ByVal dr As DataRow)
      With o
         .IdTipoCuenta = Integer.Parse(dr(Entidades.ContabilidadTipoCuenta.Columnas.IdTipoCuenta.ToString()).ToString())
         .NombreTipoCuenta = dr(Entidades.ContabilidadTipoCuenta.Columnas.NombreTipoCuenta.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ContabilidadTipoCuenta)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ContabilidadTipoCuenta
      Dim oLis As List(Of Entidades.ContabilidadTipoCuenta) = New List(Of Entidades.ContabilidadTipoCuenta)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ContabilidadTipoCuenta()
         Me.CargarUna(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal codtipoCuenta As Integer) As Entidades.ContabilidadTipoCuenta
      Dim sql As SqlServer.ContabilidadTiposCuentas = New SqlServer.ContabilidadTiposCuentas(Me.da)
      Dim dt As DataTable = sql.TipoCuenta_G1(codtipoCuenta)
      Dim o As Entidades.ContabilidadTipoCuenta = New Entidades.ContabilidadTipoCuenta()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el tipo de cuenta")
      End If
      Return o
   End Function

   Public Function Get1(ByVal codtipoCuenta As Integer) As DataTable
      Dim sql As SqlServer.ContabilidadTiposCuentas = New SqlServer.ContabilidadTiposCuentas(Me.da)
      Return sql.TipoCuenta_G1(codtipoCuenta)
   End Function

   Public Function GetPorNombre(ByVal dsctipoCuenta As String) As DataTable
      Dim sql As SqlServer.ContabilidadTiposCuentas = New SqlServer.ContabilidadTiposCuentas(Me.da)
      Return sql.GetPorNombre(dsctipoCuenta)
   End Function

   Public Function GetIdMaximo() As Integer

      Dim sql As SqlServer.ContabilidadTiposCuentas = New SqlServer.ContabilidadTiposCuentas(Me.da)
      Dim dt As DataTable = sql.TipoCuenta_GetIdMaximo()
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region

End Class
