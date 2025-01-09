Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class EmpresaActividades
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesDescuentosMarcas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

   Public Sub GrabarEmpresaActividades(ByVal listado As DataTable)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.EmpresaActividades = New SqlServer.EmpresaActividades(Me.da)

         sql.EmpresaActividades_D()

         For Each dr As DataRow In listado.Rows
            If dr.RowState <> DataRowState.Deleted Then

               sql.EmpresaActividades_I(dr("IdProvincia").ToString(), _
                                              Integer.Parse(dr("IdActividad").ToString()), _
                                              Boolean.Parse(dr("Principal").ToString()))
            End If
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Function GetEmpresaActividades(idProvincia As String) As DataTable

      Dim sql As SqlServer.EmpresaActividades
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.EmpresaActividades(Me.da)
         dt = sql.GetEmpresaActividades(idProvincia)

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

End Class
