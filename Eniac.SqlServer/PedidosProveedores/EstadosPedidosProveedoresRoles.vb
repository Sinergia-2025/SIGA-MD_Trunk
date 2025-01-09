Public Class EstadosPedidosProveedoresRoles
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosPedidosProveedoresRoles_I(tipoEstadoPedido As String, idEstado As String, idRol As String,
                                               permitirEscritura As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO EstadosPedidosProveedoresRoles (")
         .AppendLine("     TipoEstadoPedido")
         .AppendLine("   , IdEstado")
         .AppendLine("   , IdRol")
         .AppendLine("   , PermitirEscritura")
         .AppendLine(" ) VALUES ( ")
         .AppendFormatLine("     '{0}'", tipoEstadoPedido)
         .AppendFormatLine("   , '{0}'", idEstado)
         .AppendFormatLine("   , '{0}'", idRol)
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(permitirEscritura))
         .AppendLine(")")
      End With
      Execute(stb)
   End Sub
   Public Sub EstadosPedidosProveedoresRoles_U(tipoEstadoPedido As String, idEstado As String, idRol As String,
                                               permitirEscritura As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE EstadosPedidosProveedoresRoles")
         .AppendFormatLine("   SET PermitirEscritura = {0}", permitirEscritura)
         .AppendFormatLine(" WHERE TipoEstadoPedido = '{0}'", tipoEstadoPedido)
         .AppendFormatLine("   AND IdEstado = '{0}'", idEstado)
         .AppendFormatLine("   AND IdRol = '{0}'", idRol)
      End With
      Execute(stb)
   End Sub
   Public Sub EstadosPedidosProveedoresRoles_D(tipoEstadoPedido As String, idEstado As String, idRol As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM EstadosPedidosProveedoresRoles")
         .AppendFormatLine(" WHERE TipoEstadoPedido = '{0}'", tipoEstadoPedido)
         .AppendFormatLine("   AND IdEstado = '{0}'", idEstado)
         If Not String.IsNullOrWhiteSpace(idRol) Then
            .AppendFormatLine("   AND IdRol = '{0}'", idRol)
         End If
      End With
      Execute(stb)
   End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT ER.*")
         .AppendLine("  FROM EstadosPedidosProveedoresRoles ER")
      End With
   End Sub
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "ER.")
   End Function
   Public Function EstadosPedidosProveedoresRoles_G(tipoEstadoPedido As String, idEstado As String, idRol As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(tipoEstadoPedido) Then
            .AppendFormatLine("   AND ER.TipoEstadoPedido = '{0}'", tipoEstadoPedido)
         End If
         If Not String.IsNullOrWhiteSpace(idEstado) Then
            .AppendFormatLine("   AND ER.IdEstado = '{0}'", idEstado)
         End If
         If Not String.IsNullOrWhiteSpace(idRol) Then
            .AppendFormatLine("   AND ER.IdRol = '{0}'", idRol)
         End If
         .Append("  ORDER BY ER.IdEstado, ER.IdRol")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function EstadosPedidosProveedoresRoles_G1(tipoEstadoPedido As String, idEstado As String, idRol As String) As DataTable
      Return EstadosPedidosProveedoresRoles_G(tipoEstadoPedido, idEstado, idRol)
   End Function
   Public Function EstadosPedidosProveedoresRoles_GA(tipoEstadoPedido As String, idEstado As String) As DataTable
      Return EstadosPedidosProveedoresRoles_G(tipoEstadoPedido, idEstado, idRol:=String.Empty)
   End Function
   Public Function EstadosPedidosProveedoresRoles_GA(idRol As String) As DataTable
      Return EstadosPedidosProveedoresRoles_G(tipoEstadoPedido:=String.Empty, idEstado:=String.Empty, idRol)
   End Function
   Public Function EstadosPedidosProveedoresRoles_GA() As DataTable
      Return EstadosPedidosProveedoresRoles_G(tipoEstadoPedido:=String.Empty, idEstado:=String.Empty, idRol:=String.Empty)
   End Function
End Class