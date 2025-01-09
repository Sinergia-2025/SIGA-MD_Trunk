#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports System.Text
#End Region
Public Class AplicacionesEdicionesModulos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "AplicacionesEdicionesModulos"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "AplicacionesEdicionesModulos"
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
      Dim sql As SqlServer.AplicacionesEdicionesModulos = New SqlServer.AplicacionesEdicionesModulos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   'Public Overrides Function GetAll(idEdicion As Integer, idAplicacion As Integer) As System.Data.DataTable
   '   Return New SqlServer.AplicacionesEdicionesModulos(Me.da).AplicacionesEdicionesModulos_GA()
   'End Function

   Public Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.AplicacionEdicionModulo.Columnas.IdModulo.ToString()))
   End Function
   Public Function GetCodigoMaximo(ByVal campo As String) As Long
      Return New SqlServer.AplicacionesEdicionesModulos(Me.da).GetCodigoMaximo(campo)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.AplicacionEdicionModulo = DirectCast(entidad, Entidades.AplicacionEdicionModulo)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.AplicacionesEdicionesModulos = New SqlServer.AplicacionesEdicionesModulos(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AplicacionesEdicionesModulos_I(en.IdEdicion, en.IdAplicacion, en.IdModulo)
            Case TipoSP._U
               sqlC.AplicacionesEdicionesModulos_U(en.IdEdicion, en.IdAplicacion, en.IdModulo)
            Case TipoSP._D
               sqlC.AplicacionesEdicionesModulos_D(en.IdEdicion, en.IdAplicacion)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.AplicacionEdicionModulo, ByVal dr As DataRow)
      With o
         .IdEdicion = dr(AplicacionEdicionModulo.Columnas.IdEdicion.ToString()).ToString()
         .IdAplicacion = dr(AplicacionEdicionModulo.Columnas.IdAplicacion.ToString()).ToString()
         .IdModulo = Integer.Parse(dr(AplicacionEdicionModulo.Columnas.IdModulo.ToString()).ToString())
         .NombreModulo = dr(AplicacionEdicionModulo.Columnas.NombreModulo.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Overloads Sub Borrar(IdEdicion As String, idAplicacion As String)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.AplicacionesEdicionesModulos = New SqlServer.AplicacionesEdicionesModulos(da)
         sqlC.AplicacionesEdicionesModulos_D(IdEdicion, idAplicacion)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(AplicacionesEdicionesModulos As List(Of AplicacionEdicionModulo))
      For Each enDias As AplicacionEdicionModulo In AplicacionesEdicionesModulos
         Me.EjecutaSP(enDias, TipoSP._I)
      Next
   End Sub

   Public Function GetUno(idEdicion As String, IdAplicacion As String, idModulo As Integer) As Entidades.AplicacionEdicionModulo
      Dim dt As DataTable = New SqlServer.AplicacionesEdicionesModulos(Me.da).AplicacionesEdicionesModulos_G1(idEdicion, IdAplicacion, idModulo)
      Dim o As Entidades.AplicacionEdicionModulo = New Entidades.AplicacionEdicionModulo()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   'Public Function GetTodas() As List(Of Entidades.AplicacionEdicionModulo)
   '   Return GetTodas(Nothing)
   'End Function

   Public Function GetTodas(idEdicion As String, idAplicacion As String) As List(Of Entidades.AplicacionEdicionModulo)
      Dim dt As DataTable = New SqlServer.AplicacionesEdicionesModulos(da).AplicacionesEdicionesModulos_GA(idEdicion, idAplicacion)
      Dim o As Entidades.AplicacionEdicionModulo
      Dim oLis As List(Of Entidades.AplicacionEdicionModulo) = New List(Of Entidades.AplicacionEdicionModulo)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.AplicacionEdicionModulo()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   'Public Function GetInteres(ByVal formaPago As Integer, ByVal cuotas As Integer, ByVal IdInteres As Integer) As Decimal
   '   Try
   '      da.OpenConection()

   '      Dim sqlC As SqlServer.AplicacionesEdicionesModulos = New SqlServer.AplicacionesEdicionesModulos(da)

   '      Return sqlC.GetInteres(formaPago, cuotas, IdInteres)

   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Function

   'Public Function GetInteresVentas(ByVal formaPago As Integer, ByVal cuotas As Integer, ByVal IdInteres As Integer) As Decimal
   '   Try
   '      da.OpenConection()

   '      Dim sqlC As SqlServer.AplicacionesEdicionesModulos = New SqlServer.AplicacionesEdicionesModulos(da)

   '      Return sqlC.GetInteresVentas(formaPago, cuotas, IdInteres)

   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Function

   'Public Function GetPorcInteresVentas(dias As Integer, idInteres As Integer) As Decimal
   '   Try
   '      da.OpenConection()
   '      Return New SqlServer.AplicacionesEdicionesModulos(da).GetInteresVentasSegunDias(dias, idInteres)
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Function

#End Region
End Class