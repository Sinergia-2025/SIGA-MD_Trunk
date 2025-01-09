Option Explicit On
Option Strict On

#Region "Imports"
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region

Public Class ClientesActividades
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesDescuentosMarcas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ClientesDescuentosMarcas"
      da = accesoDatos
   End Sub

#End Region

   Public Sub GrabarClientesActividades(ByVal IdCliente As Long, _
                                           ByVal listado As DataTable)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesActividades = New SqlServer.ClientesActividades(Me.da)

         sql.ClientesActividades_D(IdCliente, "", 0)

         For Each dr As DataRow In listado.Rows
            If dr.RowState <> DataRowState.Deleted AndAlso _
                (Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()) <> 0 Or Decimal.Parse(dr("DescuentoRecargoPorc2").ToString()) <> 0) Then

               sql.ClientesActividades_I(Long.Parse(dr("IdCliente").ToString()), _
                                              dr("IdProvincia").ToString(), _
                                              Integer.Parse(dr("IdActividad").ToString()))
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

   Public Function GetClientesActividades(ByVal IdCliente As Long) As DataTable
      Return GetClientesActividades(IdCliente, String.Empty, String.Empty, 0)
   End Function
   Public Function GetClientesActividades(ByVal IdCliente As Long, idProvinciaCliente As String, idCategoriaFiscalCliente As Integer) As DataTable
      Return GetClientesActividades(IdCliente, idProvinciaCliente, String.Empty, idCategoriaFiscalCliente)
   End Function
   Public Function GetClientesActividades(ByVal IdCliente As Long, idProvinciaCliente As String, idProvinciaEmpresa As String, idCategoriaFiscalCliente As Integer) As DataTable

      Dim sql As SqlServer.ClientesActividades
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         If String.IsNullOrWhiteSpace(idProvinciaCliente) Or idCategoriaFiscalCliente = 0 Then
            If IdCliente > 0 Then
               Dim cliente As Entidades.Cliente = New Reglas.Clientes(da)._GetUno(IdCliente, False)
               If String.IsNullOrWhiteSpace(idProvinciaCliente) Then
                  idProvinciaCliente = cliente.Localidad.IdProvincia
               End If
               If idCategoriaFiscalCliente = 0 Then
                  idCategoriaFiscalCliente = cliente.CategoriaFiscal.IdCategoriaFiscal
               End If
            End If
         End If

         If String.IsNullOrWhiteSpace(idProvinciaEmpresa) Then
            idProvinciaEmpresa = actual.Sucursal.LocalidadComercial.IdProvincia
         End If

         sql = New SqlServer.ClientesActividades(Me.da)
         dt = sql.GetClientesActividades(IdCliente, idProvinciaCliente, idProvinciaEmpresa, idCategoriaFiscalCliente)

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
