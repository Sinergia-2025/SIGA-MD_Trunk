Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports System.Text
Public Class VentasColasImpresion
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "VentasColasImpresion"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "VentasColasImpresion"
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
      Dim sql As SqlServer.VentasColasImpresion = New SqlServer.VentasColasImpresion(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.VentasColasImpresion(Me.da).VentasColasImpresion_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.VentaColaImpresion = DirectCast(entidad, Entidades.VentaColaImpresion)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.VentasColasImpresion = New SqlServer.VentasColasImpresion(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.VentasColasImpresion_I(en.IdVentaColaImpresion, en.NombreColaImpresion, en.Activa)
            Case TipoSP._U
               sqlC.VentasColasImpresion_U(en.IdVentaColaImpresion, en.NombreColaImpresion, en.Activa)
            Case TipoSP._D
               sqlC.VentasColasImpresion_D(en.IdVentaColaImpresion)
         End Select

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.VentaColaImpresion, ByVal dr As DataRow)
      With o
         .IdVentaColaImpresion = Integer.Parse(dr(Entidades.VentaColaImpresion.Columnas.IdVentaColaImpresion.ToString()).ToString())
         .NombreColaImpresion = dr(Entidades.VentaColaImpresion.Columnas.NombreColaImpresion.ToString()).ToString()
         .Activa = CBool(dr(Entidades.VentaColaImpresion.Columnas.Activa.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idColaImpresion As Integer,
                          nombreColaImpresion As String,
                          activa As Boolean) As Entidades.VentaColaImpresion
      Dim dt As DataTable = New SqlServer.VentasColasImpresion(Me.da).VentasColasImpresion_G1(idColaImpresion)
      Dim o As Entidades.VentaColaImpresion = New Entidades.VentaColaImpresion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.VentaColaImpresion)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.VentaColaImpresion
      Dim oLis As List(Of Entidades.VentaColaImpresion) = New List(Of Entidades.VentaColaImpresion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.VentaColaImpresion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class
