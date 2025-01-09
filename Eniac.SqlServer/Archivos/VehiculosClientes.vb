Public Class VehiculosClientes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VehiculosClientes_I(patenteVehiculo As String, idCliente As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2})",
                           Entidades.VehiculoCliente.NombreTabla,
                           Entidades.VehiculoCliente.Columnas.PatenteVehiculo.ToString(),
                           Entidades.VehiculoCliente.Columnas.IdCliente.ToString())
         .AppendFormatLine("  VALUES ('{0}', {1})", patenteVehiculo, idCliente)
      End With
      Execute(myQuery)
   End Sub

   Public Sub VehiculosClientes_U(patenteVehiculo As String, idCliente As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.VehiculoCliente.NombreTabla)
         '.AppendFormatLine("   SET {0} = '{1}'", Entidades.VehiculoCliente.Columnas.IdMarcaVehiculo.ToString(), IdMarcaVehiculo)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.VehiculoCliente.Columnas.PatenteVehiculo.ToString(), patenteVehiculo)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VehiculoCliente.Columnas.IdCliente.ToString(), idCliente)
      End With
      Execute(myQuery)
   End Sub

   Public Sub VehiculosClientes_D(patenteVehiculo As String, idCliente As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = '{2}'", Entidades.VehiculoCliente.NombreTabla, Entidades.VehiculoCliente.Columnas.PatenteVehiculo.ToString(), patenteVehiculo)
         If idCliente <> 0 Then
            .AppendFormat("                  AND {1} = '{2}'", Entidades.VehiculoCliente.NombreTabla, Entidades.VehiculoCliente.Columnas.IdCliente.ToString(), idCliente)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VC.*, C.CodigoCliente, C.TipoDocCliente, C.NroDocCliente, C.NombreCliente")
         .AppendFormatLine("  FROM {0} AS VC  ", Entidades.VehiculoCliente.NombreTabla)
         .AppendLine(" LEFT JOIN Clientes C ON VC.IdCliente = C.IdCliente")
      End With
   End Sub

   Public Function VehiculosClientes_GA() As DataTable
      Return VehiculosClientes_G(patenteVehiculo:="", idCliente:=0)
   End Function
   Public Function VehiculosClientes_GA(patenteVehiculo As String) As DataTable
      Return VehiculosClientes_G(patenteVehiculo, idCliente:=0)
   End Function
   Private Function VehiculosClientes_G(patenteVehiculo As String, idCliente As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(patenteVehiculo) Then
            .AppendFormatLine("   AND VC.PatenteVehiculo = '{0}'", patenteVehiculo)
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND VC.IdCliente =  {0} ", idCliente)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function VehiculosClientes_G1(patenteVehiculo As String, idCliente As Long) As DataTable
      Return VehiculosClientes_G(patenteVehiculo, idCliente)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "V.")
   End Function
End Class