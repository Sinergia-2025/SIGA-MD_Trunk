Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class ClientesDescuentosProductos
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

   Public Sub GrabarClientesDescuentosProductos2(IdCliente As Long, descuentos As List(Of Entidades.ClienteDescuentoProducto))
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesDescuentosProductos = New SqlServer.ClientesDescuentosProductos(Me.da)

         For Each descu As Entidades.ClienteDescuentoProducto In descuentos
            'borro todos los descuentos de un cliente producto (tiene que estar en el bucle porque sino elimina registros que no tiene que eliminar)
            sql.ClientesDescuentosProductos_D(IdCliente, descu.IdProducto)

            'inserto todos los descuentos de un cliente producto
            If descu.DescuentoRecargoPorc1 <> 0 Or descu.DescuentoRecargoPorc2 <> 0 Then
               sql.ClientesDescuentosProductos_I(descu.IdCliente, descu.IdProducto, descu.DescuentoRecargoPorc1, descu.DescuentoRecargoPorc2)
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

   Public Sub GrabarClientesDescuentosProductos(ByVal IdCliente As Long, _
                                             ByVal listado As DataTable)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesDescuentosProductos = New SqlServer.ClientesDescuentosProductos(Me.da)

         sql.ClientesDescuentosProductos_D(IdCliente, "")

         Dim sql2 As SqlServer.Clientes = New SqlServer.Clientes(Me.da, Entidades.Cliente.ModoClienteProspecto.Cliente)

         Dim dtCliente As DataTable = sql2.Clientes_G1(IdCliente, incluirFoto:=False, puedeVerDetalleValoracionEstrellas:=False, porCodigo:=False)

         For Each dr As DataRow In listado.Rows
            If dr.RowState <> DataRowState.Deleted AndAlso _
                (Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()) <> 0 Or Decimal.Parse(dr("DescuentoRecargoPorc2").ToString()) <> 0) Then

               sql.ClientesDescuentosProductos_I(Long.Parse(dtCliente.Rows(0)("IdCliente").ToString()), _
                                        dr("IdProducto").ToString(), _
                                         Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()), _
                                         Decimal.Parse(dr("DescuentoRecargoPorc2").ToString()))
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

   Public Function GetClientesDescuentosProductos(idCliente As Long, grilla As Boolean) As DataTable
      Dim sql = New SqlServer.ClientesDescuentosProductos(da)
      Return sql.GetClientesDescuentosProductos(idCliente, grilla)
   End Function

   Public Function GetInfClientesDescuentosProductos(ByVal IdCliente As Long, _
                                              ByVal Productos As List(Of Entidades.Producto)) As DataTable

      Dim sql As SqlServer.ClientesDescuentosProductos
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.ClientesDescuentosProductos(Me.da)
         dt = sql.GetInfClientesDescuentosProductos(IdCliente, Productos)

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
                          ByVal idProducto As String) As DataTable


      Dim sql As SqlServer.ClientesDescuentosProductos
      Dim dt As DataTable

      Try

         sql = New SqlServer.ClientesDescuentosProductos(Me.da)
         dt = sql.Get1(IdCliente, idProducto)

         Return dt

      Catch ex As Exception
         Throw
      End Try

   End Function

   Public Function GetTodos(idCliente As Long) As DataTable
      Return New SqlServer.ClientesDescuentosProductos(Me.da).GetClientesDescuentosProductos(idCliente, False)
   End Function

End Class
