Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class ClientesDescuentosRubros
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesDescuentosRubros"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

   Public Sub GrabarClientesDescuentosRubros(ByVal IdCliente As Long, _
                                             ByVal listado As DataTable)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ClientesDescuentosRubros = New SqlServer.ClientesDescuentosRubros(Me.da)

         sql.ClientesDescuentosRubros_D(IdCliente, 0)

         Dim sql2 As SqlServer.Clientes = New SqlServer.Clientes(Me.da, Entidades.Cliente.ModoClienteProspecto.Cliente)

         Dim dtCliente As DataTable = sql2.Clientes_G1(IdCliente, incluirFoto:=False, puedeVerDetalleValoracionEstrellas:=False, porCodigo:=False)

         For Each dr As DataRow In listado.Rows
            If dr.RowState <> DataRowState.Deleted AndAlso _
                (Decimal.Parse(dr("DescuentoRecargoPorc1").ToString()) <> 0 Or Decimal.Parse(dr("DescuentoRecargoPorc2").ToString()) <> 0) Then

               sql.ClientesDescuentosRubros_I(Long.Parse(dtCliente.Rows(0)("IdCliente").ToString()), _
                                         Integer.Parse(dr("IdRubro").ToString()), _
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

   Public Function GetClientesDescuentosRubros(idCliente As Long, grilla As Boolean) As DataTable
      Dim sql = New SqlServer.ClientesDescuentosRubros(da)
      Return sql.GetClientesDescuentosRubros(idCliente, grilla)
   End Function

   Public Function GetInfClientesDescuentosRubros(ByVal IdCliente As Long, _
                                              ByVal Rubros As List(Of Entidades.Rubro)) As DataTable

      Dim sql As SqlServer.ClientesDescuentosRubros
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.ClientesDescuentosRubros(Me.da)
         dt = sql.GetInfClientesDescuentosRubros(IdCliente, Rubros)

         Me.da.CommitTransaction()

         Return dt
      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Private Sub CargarUno(ByVal o As Entidades.ClienteDescuentoRubro, ByVal dr As DataRow)
      With o
         .IdRubro = Integer.Parse(dr(Entidades.ClienteDescuentoRubro.Columnas.IdRubro.ToString()).ToString())
         .IdCliente = Long.Parse(dr(Entidades.ClienteDescuentoRubro.Columnas.IdCliente.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ClienteDescuentoRubro.Columnas.DescuentoRecargoPorc1.ToString()).ToString()) Then
            .DescuentoRecargoPorc1 = Decimal.Parse(dr(Entidades.ClienteDescuentoRubro.Columnas.DescuentoRecargoPorc1.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ClienteDescuentoRubro.Columnas.DescuentoRecargoPorc2.ToString()).ToString()) Then
            .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.ClienteDescuentoRubro.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
         End If
      End With
   End Sub

   Public Function GetUno(IdCliente As Long,
                          IdRubro As Integer,
                          Optional throwExceptionWhenNoExist As Boolean = True) As Entidades.ClienteDescuentoRubro

      Dim sql As SqlServer.ClientesDescuentosRubros = New SqlServer.ClientesDescuentosRubros(Me.da)
      Dim dt As DataTable = sql.Get1(IdCliente, IdRubro)
      Dim o As Entidades.ClienteDescuentoRubro = New Entidades.ClienteDescuentoRubro()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         If throwExceptionWhenNoExist Then
            Throw New Exception("No existe el Descuento para el Cliente/Rubro.")
         Else
            Return Nothing
         End If
      End If
      Return o

   End Function

   Public Function GetTodos(idCliente As Long) As List(Of Entidades.ClienteDescuentoRubro)
      Dim lista As List(Of Entidades.ClienteDescuentoRubro) = New List(Of Entidades.ClienteDescuentoRubro)()
      Dim sql As SqlServer.ClientesDescuentosRubros = New SqlServer.ClientesDescuentosRubros(Me.da)
      Dim dt As DataTable = sql.GetClientesDescuentosRubros(idCliente, False)
      Dim o As Entidades.ClienteDescuentoRubro
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ClienteDescuentoRubro()
         Me.CargarUno(o, dt.Rows(0))
         lista.Add(o)
      Next
      Return lista
   End Function
End Class