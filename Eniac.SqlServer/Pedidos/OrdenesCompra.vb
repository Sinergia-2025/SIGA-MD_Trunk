Public Class OrdenesCompra
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesCompra_I(idSucursal As Integer,
                              numeroOrdenCompra As Long,
                              idProveedor As Long,
                              idFormasPago As Integer,
                              fechaPedidos As Date,
                              idUsuario As String,
                              respetaPreciosOrdenCompra As Boolean,
                              AplicaDescuentoRecargo As Boolean,
                              Anticipado As Boolean)

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO OrdenesCompra")
         .AppendLine("   (IdSucursal")
         .AppendLine("   ,NumeroOrdenCompra")
         .AppendLine("   ,IdProveedor")
         .AppendLine("   ,IdFormasPago")
         .AppendLine("   ,FechaPedidos")
         .AppendLine("   ,IdUsuario")
         .AppendLine("   ,RespetaPreciosOrdenCompra")
         .AppendLine("   ,AplicaDescuentoRecargo")
         .AppendLine("   ,Anticipado")
         .AppendLine(" ) VALUES ( ")
         .AppendLine("   " & idSucursal.ToString())
         .AppendLine("   ," & numeroOrdenCompra.ToString())
         .AppendLine("   ," & idProveedor.ToString())
         .AppendLine("  ," & idFormasPago.ToString())
         .AppendLine("  ,'" & ObtenerFecha(fechaPedidos, True) & "'")
         .AppendLine("  ,'" & idUsuario & "'")
         .AppendLine("  ,'" & GetStringFromBoolean(respetaPreciosOrdenCompra) & "'")
         .AppendLine("  ,'" & GetStringFromBoolean(AplicaDescuentoRecargo) & "'")
         .AppendLine("  ,'" & GetStringFromBoolean(Anticipado) & "'")
         .AppendLine(")")
      End With
      Execute(stb)
   End Sub

   Public Sub OrdenesCompra_U(idSucursal As Integer,
                              numeroOrdenCompra As Long,
                              idProveedor As Long,
                              idFormasPago As Integer,
                              fechaPedidos As Date,
                              idUsuario As String,
                              respetaPreciosOrdenCompra As Boolean,
                              AplicaDescuentoRecargo As Boolean,
                              Anticipado As Boolean)

      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" UPDATE OrdenesCompra")
         .AppendFormat("   SET IdProveedor = {0}", idProveedor).AppendLine()
         .AppendFormat("   ,IdFormasPago = {0}", idFormasPago).AppendLine()
         .AppendFormat("   ,FechaPedidos = '{0}'", Me.ObtenerFecha(fechaPedidos, True)).AppendLine()
         .AppendFormat("   ,IdUsuario = '{0}'", idUsuario).AppendLine()
         .AppendFormat("   ,RespetaPreciosOrdenCompra = '{0}'", Me.GetStringFromBoolean(respetaPreciosOrdenCompra)).AppendLine()
         .AppendFormat("   ,AplicaDescuentoRecargo = '{0}'", Me.GetStringFromBoolean(AplicaDescuentoRecargo)).AppendLine()
         .AppendFormat("   ,Anticipado = '{0}'", Me.GetStringFromBoolean(Anticipado)).AppendLine()
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND NumeroOrdenCompra = {0}", numeroOrdenCompra).AppendLine()
      End With
      Execute(stb)
   End Sub

   Public Sub OrdenesCompra_D(idSucursal As Integer, numeroOrdenCompra As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM OrdenesCompra")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND NumeroOrdenCompra = " & numeroOrdenCompra.ToString())
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT OC.* ")
         .AppendLine("     , P.CodigoProveedor")
         .AppendLine("     , P.NombreProveedor")
         .AppendLine("     , FP.DescripcionFormasPago")

         .AppendLine("  FROM OrdenesCompra OC")
         .AppendLine("  LEFT JOIN Proveedores P ON P.IdProveedor = OC.IdProveedor")
         .AppendLine("  LEFT JOIN VentasFormasPago FP ON FP.IdFormasPago = OC.IdFormasPago")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreProveedor" Then
         columna = "P." + columna
      ElseIf columna = "DescripcionFormasPago" Then
         columna = "FP." + columna
      Else
         columna = "OC." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function OrdenesCompra_GA(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .Append("  ORDER BY OC.NumeroOrdenCompra")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function OrdenesCompra_G1(idSucursal As Integer, numeroOrdenCompra As Long, numeroOrdenCompraCeroTodos As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         If numeroOrdenCompra <> 0 OrElse Not numeroOrdenCompraCeroTodos Then
            .AppendFormatLine("   AND OC.NumeroOrdenCompra = {0}", numeroOrdenCompra)
         End If
      End With
      Return GetDataTable(stb)
   End Function

End Class