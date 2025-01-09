Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class Textos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Textos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Textos"
      da = accesoDatos
   End Sub

#End Region

   Public Sub GrabarTextos(ByVal Id As String, ByVal Asunto As String, ByVal Cuerpo As String, ByVal Modalidad As String)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.Textos = New SqlServer.Textos(Me.da)

         sql.Textos_U(Id, Asunto, Cuerpo, Modalidad)

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub InsertaTextos(ByVal IdTexto As Integer, ByVal Id As String, ByVal Asunto As String, ByVal Cuerpo As String,
                            ByVal Modalidad As String)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.Textos = New SqlServer.Textos(Me.da)

         sql.Textos_I(IdTexto, Id, Asunto, Cuerpo, Modalidad)

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Function GetTextos(ByVal Id As String, ByVal Modalidad As String) As DataTable

      Dim sql As SqlServer.Textos
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.Textos(Me.da)
         dt = sql.Textos_G1(Id, Modalidad)

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

 Public Function GetIdMaximo() As Integer
      Dim sql As SqlServer.Textos = New SqlServer.Textos(Me.da)
      Dim dt As DataTable = sql.Textos_GetIdMaximo()
      Dim val As Integer = 0
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If
      Return val
   End Function

End Class
