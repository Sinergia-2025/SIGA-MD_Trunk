Option Explicit On
Option Strict On
Public Class OrdenesCompraPedidos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesCompraPedidos_I(ByVal IdSucursal As Integer, _
                                     ByVal NumeroOrdenCompra As Long, _
                                     ByVal IdCliente As Long, _
                                     ByVal idTipoComprobante As String,
                                     ByVal letra As String,
                                     ByVal centroEmisor As Integer,
                                     ByVal numeroPedido As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("INSERT INTO OrdenesCompraPedidos")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,NumeroOrdenCompra")
         .AppendLine("           ,IdCliente")
         .AppendFormat("           ,{0}", Entidades.OrdenCompraPedido.Columnas.IdTipoComprobante.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenCompraPedido.Columnas.Letra.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenCompraPedido.Columnas.CentroEmisor.ToString()).AppendLine()
         .AppendFormat("           ,{0}", Entidades.OrdenCompraPedido.Columnas.NumeroPedido.ToString()).AppendLine()
         .AppendLine(" ) VALUES ( ")
         .AppendFormat("           {0}", IdSucursal)
         .AppendFormat("           ,{0} ", NumeroOrdenCompra)
         .AppendFormat("           ,{0}", IdCliente)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,{0}", centroEmisor)
         .AppendFormat("           ,{0}", numeroPedido)
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())

   End Sub

   'Public Sub OrdenesCompra_U(ByVal NumeroOrdenCompra As Long, _
   '                           idSucursal As Integer,
   '                            idTipoComprobante As String,
   '                            letra As String,
   '                            centroEmisor As Integer,
   '                            numeroPedido As Long)

   '   Dim stb As StringBuilder = New StringBuilder("")
   '   Dim afecta As Int16 = New Short()

   '   With stb
   '      .Length = 0
   '      .AppendLine(" UPDATE OrdenesCompra SET ")
   '      .AppendLine("   ,IdProveedor = " & IdProveedor)
   '      .AppendLine("   ,IdFormasPago = " & IdFormasPago)
   '      .AppendLine("   ,FechaPedidos = " & Me.ObtenerFecha(FechaPedidos, True) & "'")
   '      .AppendLine("   ,Usuario = " & Usuario)
   '      .AppendLine(" WHERE NumeroOrdenCompra = " & NumeroOrdenCompra)
   '   End With

   '   Me.Execute(stb.ToString())

   'End Sub

   Public Sub OrdenesCompraPedidos_D(ByVal IdSucursal As Integer, ByVal NumeroOrdenCompra As Long, IdCliente As Long)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM OrdenesCompraPedidos")
         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND NumeroOrdenCompra = " & NumeroOrdenCompra.ToString())
         .AppendFormat(" AND IdCliente = {0}", IdCliente)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT OCP.* ")
         .AppendLine(" FROM OrdenesCompraPedidos OCP")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal IdSucursal As Integer, ByVal columna As String, ByVal valor As String) As DataTable
      columna = "OC." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE OC.IdSucursal = " & IdSucursal.ToString())
         .AppendLine(" AND " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function OrdenesCompraPedidos_GA(ByVal IdSucursal As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE OC.IdSucursal = " & IdSucursal.ToString())
         .Append("  ORDER BY OC.NumeroOrdenCompra")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function OrdenesCompraPedidos_G1(ByVal IdSucursal As Integer, ByVal NumeroOrdenCompra As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE OC.IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND OC.NumeroOrdenCompra = " & NumeroOrdenCompra.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPedido(IdSucursal As Integer, ordenCompra As Long?, idCliente As Long?) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT * FROM OrdenesCompraPedidos AS OCP")
         .AppendLine(" INNER JOIN Pedidos P ON P.IdSucursal = OCP.IdSucursal")
         .AppendLine(" AND P.IdTipoComprobante = OCP.IdTipoComprobante ")
         .AppendLine(" AND P.Letra = OCP.Letra ")
         .AppendLine(" AND P.CentroEmisor = OCP.CentroEmisor ")
         .AppendLine(" AND P.NumeroPedido = OCP.NumeroPedido ")
         .AppendLine(" WHERE OCP.IdSucursal = " & IdSucursal.ToString())

         If idCliente.HasValue AndAlso idCliente.Value <> 0 Then
            .AppendFormat("   AND OCP.IdCliente = {0}", idCliente.Value).AppendLine()
         End If

         If ordenCompra.HasValue AndAlso ordenCompra.Value <> 0 Then
            .AppendFormat("   AND OCP.NumeroOrdenCompra = {0}", ordenCompra.Value).AppendLine()
         End If

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function ExistePedido(IdSucursal As Integer, ordenCompra As Long, idCliente As Long) As Boolean
      Return GetPedido(IdSucursal, ordenCompra, idCliente).Rows.Count > 0
   End Function

End Class
