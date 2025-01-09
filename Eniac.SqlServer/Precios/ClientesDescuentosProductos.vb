Public Class ClientesDescuentosProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ClientesDescuentosProductos_I(idCliente As Long,
                                            idProducto As String,
                                            descuentoRecargoPorc1 As Decimal,
                                            descuentoRecargoPorc2 As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO ClientesDescuentosProductos")
         .AppendLine("   (IdCliente")
         .AppendLine("   ,IdProducto")
         .AppendLine("   ,DescuentoRecargoPorc1")
         .AppendLine("   ,DescuentoRecargoPorc2")
         .AppendLine(" ) VALUES (")
         .AppendFormatLine("     {0} ", idCliente)
         .AppendFormatLine("   ,'{0}'", idProducto)
         .AppendFormatLine("   , {0} ", descuentoRecargoPorc1)
         .AppendFormatLine("   , {0} ", descuentoRecargoPorc2)
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesDescuentosProductos")
   End Sub

   Public Sub ClientesDescuentosProductos_D(idCliente As Long,
                                            idProducto As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("DELETE CDP FROM ClientesDescuentosProductos CDP")
         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CDP.IdCliente")
         .AppendFormatLine(" WHERE C.IdCliente = {0}", idCliente)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine(" AND CDP.IdProducto = '{0}'", idProducto)
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ClientesDescuentosProductos")
   End Sub

   Public Function GetClientesDescuentosProductos(idCliente As Long, grilla As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.IdCliente")
         .AppendFormatLine("     , P.IdProducto")
         .AppendFormatLine("     , P.NombreProducto")
         If Not grilla Then
            .AppendFormatLine("     , CD.DescuentoRecargoPorc1")
            .AppendFormatLine("     , CD.DescuentoRecargoPorc2")
         Else
            .AppendFormatLine("     , ISNULL(CD.DescuentoRecargoPorc1, 0) AS DescuentoRecargoPorc1")
            .AppendFormatLine("     , ISNULL(CD.DescuentoRecargoPorc2, 0) AS DescuentoRecargoPorc2")
         End If
         .AppendFormatLine("  FROM ClientesDescuentosProductos CD ")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente ")
         If grilla Then
            .AppendFormatLine(" RIGHT JOIN Productos P ON P.IdProducto = CD.IdProducto ")
         Else
            .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = CD.IdProducto ")
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If
         .AppendFormatLine(" ORDER BY P.NombreProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetInfClientesDescuentosProductos(idCliente As Long,
                                                     productos As List(Of Entidades.Producto)) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT CD.IdCliente")
         .AppendLine("     , C.NombreCliente")
         .AppendLine("     , CD.IdProducto")
         .AppendLine("     , P.NombreProducto")
         .AppendLine("     , CD.DescuentoRecargoPorc1")
         .AppendLine("     , CD.DescuentoRecargoPorc2")
         .AppendLine("  FROM ClientesDescuentosProductos CD")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = CD.IdProducto")
         .AppendLine(" WHERE 1 = 1")
         If idCliente > 0 Then
            .AppendFormatLine("	AND C.IdCliente = {0}", idCliente)
         End If
         GetListaMultiples(stb, productos.ToArray(), "CD")
         .AppendLine(" ORDER BY C.NombreCliente, P.NombreProducto")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Function Get1(idCliente As Long,
                        idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT CD.IdCliente")
         .AppendLine("     , CD.IdProducto")
         .AppendLine("     , P.NombreProducto")
         .AppendLine("     , CD.DescuentoRecargoPorc1")
         .AppendLine("     , CD.DescuentoRecargoPorc2")
         .AppendLine("  FROM ClientesDescuentosProductos CD ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente ")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = CD.IdProducto ")
         .AppendFormatLine(" WHERE C.IdCliente = {0}", idCliente)
         .AppendFormatLine("   AND CD.IdProducto = '{0}'", idProducto)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class