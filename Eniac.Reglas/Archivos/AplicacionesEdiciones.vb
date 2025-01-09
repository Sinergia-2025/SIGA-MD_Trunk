Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports System.Text
Public Class AplicacionesEdiciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "AplicacionesEdiciones"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "AplicacionesEdiciones"
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
      Dim sql As SqlServer.AplicacionesEdiciones = New SqlServer.AplicacionesEdiciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AplicacionesEdiciones(Me.da).AplicacionesEdiciones_GA()
   End Function

   'Public Function GetCodigoMaximo(IdAplicacion As String) As Integer
   '   Return New SqlServer.AplicacionesEdiciones(Me.da).GetCodigoMaximo(IdAplicacion)
   'End Function

   Public Function GetEdiciones(IdAplicacion As String) As DataTable
      Return New SqlServer.AplicacionesEdiciones(Me.da).AplicacionesEdiciones_G("", IdAplicacion)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.AplicacionEdicion = DirectCast(entidad, Entidades.AplicacionEdicion)
       
         da.OpenConection()
         da.BeginTransaction()

         Dim rModulos As AplicacionesEdicionesModulos = New AplicacionesEdicionesModulos(da)
         Dim sqlC As SqlServer.AplicacionesEdiciones = New SqlServer.AplicacionesEdiciones(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AplicacionesEdiciones_I(en.IdEdicion, en.IdAplicacion, en.NombreEdicion)
               rModulos.Insertar(en.Modulos)
            Case TipoSP._U
               sqlC.AplicacionesEdiciones_U(en.IdEdicion, en.IdAplicacion, en.NombreEdicion)
               rModulos.Borrar(en.IdEdicion, en.IdAplicacion)
               rModulos.Insertar(en.Modulos)
            Case TipoSP._D
               rModulos.Borrar(en.IdEdicion, en.IdAplicacion)
               sqlC.AplicacionesEdiciones_D(en.IdEdicion, en.IdAplicacion)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.AplicacionEdicion, ByVal dr As DataRow)
      With o
         .IdEdicion = dr(AplicacionEdicion.Columnas.IdEdicion.ToString()).ToString()
         .IdAplicacion = dr(AplicacionEdicion.Columnas.IdAplicacion.ToString()).ToString()
         .NombreEdicion = dr(AplicacionEdicion.Columnas.NombreEdicion.ToString()).ToString()
     
         Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
         If blnAbreConexion Then da.OpenConection()
         Try
            .Modulos = New AplicacionesEdicionesModulos(da).GetTodas(.IdEdicion, .IdAplicacion)
         Finally
            If blnAbreConexion Then da.CloseConection()
         End Try
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idEdicion As String, idAplicacion As String) As Entidades.AplicacionEdicion
      Dim dt As DataTable = New SqlServer.AplicacionesEdiciones(Me.da).AplicacionesEdiciones_G1(idEdicion, idAplicacion)
      Dim o As Entidades.AplicacionEdicion = New Entidades.AplicacionEdicion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.AplicacionEdicion)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.AplicacionEdicion
      Dim oLis As List(Of Entidades.AplicacionEdicion) = New List(Of Entidades.AplicacionEdicion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.AplicacionEdicion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class