Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class ContactosDirecciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContactosDirecciones"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ContactosDirecciones"
      da = accesoDatos
   End Sub

#End Region


   Public Function GetContactosDirecciones(ByVal IdContacto As Long) As DataTable

      Dim sql As SqlServer.ContactosDirecciones
      Dim dt As DataTable

      Try

         sql = New SqlServer.ContactosDirecciones(Me.da)
         dt = sql.GetContactosDirecciones(IdContacto)

         Return dt
      Catch ex As Exception
         Throw
      End Try

   End Function

   Public Function GetDireccionContacto(ByVal IdContacto As Long, ByVal IdDireccion As Integer) As DataTable

      Dim sql As SqlServer.ContactosDirecciones
      Dim dt As DataTable

      Try

         sql = New SqlServer.ContactosDirecciones(Me.da)
         dt = sql.GetDireccionContacto(IdContacto, IdDireccion)

         Return dt
      Catch ex As Exception
         Throw
      End Try

   End Function

   Public Function GetDirecciones(ByVal IdContacto As Long) As DataTable

      Dim sql As SqlServer.ContactosDirecciones
      Dim dt As DataTable

      Try

         sql = New SqlServer.ContactosDirecciones(Me.da)
         dt = sql.GetDirecciones(IdContacto)

         Return dt
      Catch ex As Exception
         Throw
      End Try

   End Function

End Class
