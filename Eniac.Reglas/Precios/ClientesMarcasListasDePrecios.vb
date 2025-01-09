Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region


Public Class ClientesMarcasListasDePrecios
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesMarcasListasDePrecios"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

   Public Sub GrabarClientesListaPreciosMarcas(ByVal listado As DataTable)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesMarcasListasDePrecios = New SqlServer.ClientesMarcasListasDePrecios(Me.da)

         If listado.GetChanges(DataRowState.Deleted) IsNot Nothing Then
            For Each dr As DataRow In listado.GetChanges(DataRowState.Deleted).Rows
               If dr.RowState = DataRowState.Deleted Then
                        sql.ClientesMarcasListasDePrecios_D(Long.Parse(dr("IdCliente", DataRowVersion.Original).ToString()), Int32.Parse(dr("IdMarca", DataRowVersion.Original).ToString()))
               End If
            Next
         End If

         For Each dr As DataRow In listado.Rows
            If dr.RowState = DataRowState.Added Then
                    sql.ClientesMarcasListasDePrecios_I(Long.Parse(dr("IdCliente").ToString()), Int32.Parse(dr("IdMarca").ToString()), Decimal.Parse(dr("IdListaPrecios").ToString()))
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

   Public Function ClientesMarcasListasDePrecios(ByVal IdCliente As Long, _
                                                 ByVal IdMarca As Integer, _
                                                 ByVal IdListaDePrecios As Integer) As DataTable

      Dim sql As SqlServer.ClientesMarcasListasDePrecios
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.ClientesMarcasListasDePrecios(Me.da)
         dt = sql.ClientesMarcasListasDePrecios(IdCliente, IdMarca, IdListaDePrecios)

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function ConsultaClientesMarcasListasDePrecios(ByVal IdCliente As Long) As DataTable

      Dim sql As SqlServer.ClientesMarcasListasDePrecios
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.ClientesMarcasListasDePrecios(Me.da)
         dt = sql.ConsultaClientesMarcasListasDePrecios(IdCliente)

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(ByVal IdCliente As Long, _
                          ByVal idMarca As Integer) As DataTable


      Dim sql As SqlServer.ClientesMarcasListasDePrecios
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.ClientesMarcasListasDePrecios(Me.da)
         dt = sql.Get1(IdCliente, idMarca)

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
