Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class ClientesDescuentosMarcas
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

   Public Sub GrabarClientesDescuentosMarcas(ByVal IdCliente As Long, _
                                             ByVal listado As DataTable)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesDescuentosMarcas = New SqlServer.ClientesDescuentosMarcas(Me.da)

         sql.ClientesDescuentosMarcas_D(IdCliente, 0)

         Dim sql2 As SqlServer.Clientes = New SqlServer.Clientes(Me.da, Entidades.Cliente.ModoClienteProspecto.Cliente)

         Dim dtCliente As DataTable = sql2.Clientes_G1(IdCliente, incluirFoto:=False, puedeVerDetalleValoracionEstrellas:=False, porCodigo:=False)

         For Each dr As DataRow In listado.Rows
            If dr.RowState <> DataRowState.Deleted AndAlso _
                (Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()) <> 0 Or Decimal.Parse(dr("DescuentoRecargoPorc2").ToString()) <> 0) Then

               sql.ClientesDescuentosMarcas_I(Long.Parse(dtCliente.Rows(0)("IdCliente").ToString()), _
                                         Integer.Parse(dr("IdMarca").ToString()), _
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

   Public Function GetClientesDescuentosMarcas(idCliente As Long, grilla As Boolean) As DataTable
      Dim sql = New SqlServer.ClientesDescuentosMarcas(da)
      Return sql.GetClientesDescuentosMarcas(idCliente, grilla)
   End Function

   Public Function GetInfClientesDescuentosMarcas(ByVal IdCliente As Long, _
                                              ByVal Marcas As List(Of Entidades.Marca)) As DataTable

      Dim sql As SqlServer.ClientesDescuentosMarcas
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.ClientesDescuentosMarcas(Me.da)
         dt = sql.GetInfClientesDescuentosMarcas(IdCliente, Marcas)

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
                          ByVal idMarca As Integer) As Entidades.Marca


      Dim sql As SqlServer.ClientesDescuentosMarcas
      Dim dt As DataTable
      Dim blnAbreConexcion As Boolean = da.Connection.State <> ConnectionState.Open

      Try
         If blnAbreConexcion Then Me.da.OpenConection()
         'Me.da.BeginTransaction()

         sql = New SqlServer.ClientesDescuentosMarcas(Me.da)
         dt = sql.Get1(IdCliente, idMarca)

         Dim o As Entidades.Marca = New Entidades.Marca()

         If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            With o
               .IdMarca = Integer.Parse(dr("IdMarca").ToString())
               .NombreMarca = dr("NombreMarca").ToString()
               .DescuentoRecargoPorc1 = Decimal.Parse(dr("DescuentoRecargoPorc1").ToString())
               .DescuentoRecargoPorc2 = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
            End With
         Else
            With o
               .IdMarca = 0
               .NombreMarca = ""
               .DescuentoRecargoPorc1 = 0
               .DescuentoRecargoPorc2 = 0
            End With
         End If

         'Me.da.CommitTransaction()

         Return o

      Catch
         'Me.da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexcion Then Me.da.CloseConection()
      End Try

   End Function

   Private Sub CargarUno(o As Entidades.ClienteDescuentoMarca, dr As DataRow)
      With o
         .IdCliente = dr.ValorNumericoPorDefecto(Entidades.ClienteDescuentoMarca.Columnas.IdCliente.ToString(), 0L)
         .IdMarca = dr.ValorNumericoPorDefecto(Entidades.ClienteDescuentoMarca.Columnas.IdMarca.ToString(), 0I)
         .DescuentoRecargoPorc1 = dr.ValorNumericoPorDefecto(Entidades.ClienteDescuentoMarca.Columnas.DescuentoRecargoPorc1.ToString(), 0D)
         .DescuentoRecargoPorc2 = dr.ValorNumericoPorDefecto(Entidades.ClienteDescuentoMarca.Columnas.DescuentoRecargoPorc2.ToString(), 0D)
      End With
   End Sub

   Public Function GetTodos(idCliente As Long) As List(Of Entidades.ClienteDescuentoMarca)
      Return CargaLista(New SqlServer.ClientesDescuentosMarcas(Me.da).GetClientesDescuentosMarcas(idCliente, False),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ClienteDescuentoMarca())
   End Function
End Class