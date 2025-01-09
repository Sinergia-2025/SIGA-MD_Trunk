Public Class UsuariosAccesos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub UsuariosAccesos_I(idSucursal As Integer,
                                fechaAcceso As Date,
                                idUsuario As String,
                                nombrePC As String,
                                exitoso As Boolean,
                                observacion As String,
                                usuarioWindows As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO UsuariosAccesos (")
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , FechaAcceso")
         .AppendFormatLine("   , IdUsuario")
         .AppendFormatLine("   , NombrePC")
         .AppendFormatLine("   , Exitoso")
         .AppendFormatLine("   , Observacion")
         .AppendFormatLine("   , UsuarioWindows")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", ObtenerFecha(fechaAcceso, True))
         .AppendFormatLine("   , '{0}'", idUsuario)
         .AppendFormatLine("   , '{0}'", nombrePC)
         .AppendFormatLine("   , '{0}'", exitoso)
         .AppendFormatLine("   , '{0}'", observacion)
         .AppendFormatLine("   , '{0}'", usuarioWindows)
         .AppendFormatLine(" )")
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT UA.IdSucursal")
         .AppendFormatLine("     , S.Nombre AS NombreSucursal")
         .AppendFormatLine("     , UA.FechaAcceso")
         .AppendFormatLine("     , UA.IdUsuario")
         .AppendFormatLine("     , U.Nombre AS NombreUsuario")
         .AppendFormatLine("     , UA.NombrePC")
         .AppendFormatLine("     , UA.Exitoso")
         .AppendFormatLine("     , UA.Observacion")
         .AppendFormatLine("  FROM UsuariosAccesos UA ")
         .AppendFormatLine(" INNER JOIN Sucursales S on S.IdSucursal = UA.IdSucursal")
         .AppendFormatLine(" INNER JOIN Usuarios U on U.Id = UA.IdUsuario")
      End With
   End Sub
   Public Function UsuariosAccesos_GA(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         If idSucursal > 0 Then
            .AppendFormatLine(" WHERE UA.IdSucursal = {0}", idSucursal)
         End If
         .AppendFormatLine(" ORDER BY S.Nombre, UA.FechaAcceso")
      End With
      Return GetDataTable(stb)
   End Function
   '-.PE-31629.-
   Public Function UsuariosAccesos_NombresPC(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT DISTINCT(UA.NombrePC)")
         .AppendFormatLine("  FROM UsuariosAccesos UA")

         If idSucursal > 0 Then
            .AppendFormatLine(" WHERE UA.IdSucursal = {0}", idSucursal)
         End If
         .Append(" ORDER BY UA.NombrePC")
      End With
      Return GetDataTable(stb)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "UA.")
   End Function
   Public Function GetPorRangoFechas(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date, idUsuario As String, IdPC As String) As DataTable
      Dim stbQuery = New StringBuilder()
      SelectTexto(stbQuery)
      With stbQuery
         .AppendFormatLine(" WHERE UA.Idsucursal = {0}", idSucursal)
         .AppendFormatLine("   AND UA.FechaAcceso BETWEEN '{0}' AND '{1}'", ObtenerFecha(fechaDesde, True), ObtenerFecha(fechaHasta, True))
         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("	 AND UA.IdUsuario = '{0}'", idUsuario)
         End If
         If Not String.IsNullOrEmpty(IdPC) Then
            .AppendFormatLine("  AND UA.NombrePC = '{0}'", IdPC)
         End If
         .AppendLine("  ORDER BY S.Nombre, UA.FechaAcceso")
      End With
      Return GetDataTable(stbQuery)
   End Function
End Class