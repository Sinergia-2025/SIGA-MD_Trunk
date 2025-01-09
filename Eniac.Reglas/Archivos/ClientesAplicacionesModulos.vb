Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class ClientesAplicacionesModulos
   Inherits Eniac.Reglas.Base

   Private Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesModulos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(modo As Entidades.Cliente.ModoClienteProspecto)
      ModoClienteProspecto = modo
      Me.NombreEntidad = "ClientesModulos"
      da = New Datos.DataAccess()
   End Sub

#End Region

   Public Function GetClientesModulos(ByVal IdCliente As Long) As DataTable

      Dim sql As SqlServer.ClientesAplicacionesModulos
      Dim dt As DataTable

      Try

         sql = New SqlServer.ClientesAplicacionesModulos(Me.da, ModoClienteProspecto)
         dt = sql.GetClientesAplicacionesModulos(IdCliente)

         Return dt
      Catch ex As Exception
         Throw
      End Try

   End Function

   Public Function GetDireccionCliente(ByVal IdCliente As Long, ByVal IdModulo As Integer) As DataTable

      Dim sql As SqlServer.ClientesAplicacionesModulos
      Dim dt As DataTable

      Try

         sql = New SqlServer.ClientesAplicacionesModulos(Me.da, ModoClienteProspecto)
         dt = sql.GetModulosCliente(IdCliente, IdModulo)

         Return dt
      Catch ex As Exception
         Throw
      End Try

   End Function

   'Public Function GetDirecciones(ByVal IdCliente As Long) As DataTable

   '   Dim sql As SqlServer.ClientesModulos
   '   Dim dt As DataTable

   '   Try

   '      sql = New SqlServer.ClientesModulos(Me.da)
   '      dt = sql.GetDrecciones(IdCliente)

   '      Return dt
   '   Catch ex As Exception
   '      Throw
   '   End Try

   'End Function

End Class
