Public Class SucursalesDepositosUsuarios
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SucursalesDepositosUsuarios_I(idDeposito As Integer, idSucursal As Integer, idUsuario As String,
                                            responsable As Boolean, usuarioDefault As Boolean, permitirEscritura As Boolean)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6})",
                           Entidades.SucursalDepositoUsuario.NombreTabla,
                           Entidades.SucursalDepositoUsuario.Columnas.IdDeposito.ToString(),
                           Entidades.SucursalDepositoUsuario.Columnas.IdSucursal.ToString(),
                           Entidades.SucursalDepositoUsuario.Columnas.IdUsuario.ToString(),
                           Entidades.SucursalDepositoUsuario.Columnas.Responsable.ToString(),
                           Entidades.SucursalDepositoUsuario.Columnas.UsuarioDefault.ToString(),
                           Entidades.SucursalDepositoUsuario.Columnas.PermitirEscritura.ToString())
         .AppendFormatLine("  VALUES ({0}, {1}, '{2}', {3}, {4}, {5}",
                           idDeposito,
                           idSucursal,
                           idUsuario,
                           GetStringFromBoolean(responsable),
                           GetStringFromBoolean(usuarioDefault),
                           GetStringFromBoolean(permitirEscritura))
         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub SucursalesDepositosUsuarios_D(idDeposito As Integer, idSucursal As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM SucursalesDepositosUsuarios  ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("   AND IdDeposito = {0}", idDeposito)
         End If
      End With
      Execute(myQuery)
   End Sub

   Public Function GetUsuariosPorDepositos(idDeposito As Integer,
                                           idSucursal As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE ")
         .AppendFormatLine("   SDU.IdDeposito = {0}", idDeposito)
         If idSucursal > 0 Then
            .AppendFormatLine("   AND SDU.IdSucursal = {0}", idSucursal)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function GetSeguridadUsuariosPorDepositos(idDeposito As Integer,
                                                    usuario As String,
                                                    idSucursal As Integer,
                                                    permiteEscritura As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine("WHERE SDU.IdUsuario = '{0}'", usuario)
         .AppendFormatLine("  AND SDU.IdDeposito = {0} ", idDeposito)

         If permiteEscritura Then
            .AppendFormatLine("     AND SDE.PermitirEscritura = '{0}'", True)
         End If
         If idSucursal > 0 Then
            .AppendFormatLine("   AND SDU.IdSucursal = {0}", idSucursal)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT SDU.*, USR.Nombre")
         .AppendFormatLine("  FROM {0} AS SDU ", Entidades.SucursalDepositoUsuario.NombreTabla)
         .AppendFormatLine(" INNER JOIN Usuarios USR ON USR.Id = SDU.IdUsuario")
      End With
   End Sub

   Public Function SucursalesDepositosUsuarios_GA(idDeposito As Integer, idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal <> 0 And idDeposito <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.SucursalDepositoUsuario.Columnas.IdSucursal.ToString(), idSucursal)
            .AppendFormatLine("   AND {0} = {1}", Entidades.SucursalDepositoUsuario.Columnas.IdDeposito.ToString(), idDeposito)
         End If
      End With
      Return GetDataTable(stb)
   End Function

End Class
