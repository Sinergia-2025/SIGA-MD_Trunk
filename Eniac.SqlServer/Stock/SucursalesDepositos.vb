Public Class SucursalesDepositos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SucursalesDepositos_I(idDeposito As Integer,
                                    idSucursal As Integer,
                                    nombreDeposito As String,
                                    codigoDeposito As String,
                                    sucursalAsociada As Integer,
                                    depositoAsociado As Integer,
                                    disponibleVenta As Boolean,
                                    activo As Boolean, tipoDeposito As Entidades.SucursalDeposito.TiposDepositos)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.SucursalDeposito.NombreTabla)
         .AppendFormatLine("  {0}", Entidades.SucursalDeposito.Columnas.IdSucursal.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalDeposito.Columnas.IdDeposito.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalDeposito.Columnas.NombreDeposito.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalDeposito.Columnas.CodigoDeposito.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalDeposito.Columnas.SucursalAsociada.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalDeposito.Columnas.DepositoAsociado.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalDeposito.Columnas.DisponibleVenta.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalDeposito.Columnas.Activo.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalDeposito.Columnas.TipoDeposito.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("   {0} ", idSucursal)
         .AppendFormatLine(" , {0} ", idDeposito)
         .AppendFormatLine(" ,'{0}'", nombreDeposito)
         .AppendFormatLine(" ,'{0}'", codigoDeposito)

         If sucursalAsociada = 0 Then
            .AppendFormatLine(" ,NULL")
         Else
            .AppendFormatLine(" ,{0}", sucursalAsociada)
         End If
         If depositoAsociado = 0 Then
            .AppendFormatLine(" ,NULL")
         Else
            .AppendFormatLine(" ,{0}", depositoAsociado)
         End If
         .AppendFormatLine(" , {0} ", GetStringFromBoolean(disponibleVenta))
         .AppendFormatLine(" , {0} ", GetStringFromBoolean(activo))
         .AppendFormatLine(" ,'{0}' ", tipoDeposito.ToString())
         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub SucursalesDepositos_U(idDeposito As Integer,
                                    idSucursal As Integer,
                                    nombreDeposito As String,
                                    codigoDeposito As String,
                                    disponibleVenta As Boolean,
                                    activo As Boolean, tipoDeposito As Entidades.SucursalDeposito.TiposDepositos)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.SucursalDeposito.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}',", Entidades.SucursalDeposito.Columnas.NombreDeposito.ToString(), nombreDeposito)
         .AppendFormatLine("       {0} = '{1}',", Entidades.SucursalDeposito.Columnas.CodigoDeposito.ToString(), codigoDeposito)
         .AppendFormatLine("       {0} =  {1} ,", Entidades.SucursalDeposito.Columnas.DisponibleVenta.ToString(), GetStringFromBoolean(disponibleVenta))
         .AppendFormatLine("       {0} =  {1} ,", Entidades.SucursalDeposito.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         .AppendFormatLine("       {0} = '{1}' ", Entidades.SucursalDeposito.Columnas.TipoDeposito.ToString(), tipoDeposito.ToString())

         .AppendFormatLine(" WHERE {0} =  {1}  ", Entidades.SucursalDeposito.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("   AND {0} =  {1}  ", Entidades.SucursalDeposito.Columnas.IdSucursal.ToString(), idSucursal)
      End With
      Execute(myQuery)
   End Sub

   Public Sub SucursalesDepositos_U_SucAsoc(idDeposito As Integer, idSucursal As Integer,
                                            depositoAsociado As Integer, sucursalAsociada As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.SucursalDeposito.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.SucursalDeposito.Columnas.SucursalAsociada.ToString(), GetStringFromNumber(sucursalAsociada))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.SucursalDeposito.Columnas.DepositoAsociado.ToString(), GetStringFromNumber(depositoAsociado))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.SucursalDeposito.Columnas.IdSucursal.ToString(), idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.SucursalDeposito.Columnas.IdDeposito.ToString(), idDeposito)
         End If
      End With
      Execute(myQuery)
   End Sub

   Public Sub SucursalesDepositos_D(idDeposito As Integer, idSucursal As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.SucursalDeposito.NombreTabla)
         .AppendFormatLine("      WHERE {0} = {1}", Entidades.SucursalDeposito.Columnas.IdSucursal.ToString(), idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("        AND {0} = {1}", Entidades.SucursalDeposito.Columnas.IdDeposito.ToString(), idDeposito)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT SD.*, SU.Nombre as NombreSucursal FROM {0} AS SD ", Entidades.SucursalDeposito.NombreTabla)
         .AppendFormatLine(" INNER JOIN Sucursales SU ON SU.IdSucursal = SD.IdSucursal")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "SD.",
                    New Dictionary(Of String, String) From {{"NombreSucursal", "SU.Nombre"}})
   End Function

   Public Function SucursalesDepositos_GA() As DataTable
      Return SucursalesDepositos_G(idDeposito:=0, idSucursal:=0)
   End Function

   Public Function SucursalesDepositos_GA(sucursal As Integer, sucursales As Entidades.Sucursal(),
                                          permiteEscritura As Entidades.Publicos.SiNoTodos) As DataTable
      Return SucursalesDepositos_G(idSucursal:=sucursal, sucursales:=sucursales, tipoDeposito:=Nothing, permiteEscritura)
   End Function
   Public Function SucursalesDepositos_GA(sucursal As Integer, tipoDeposito As Entidades.SucursalDeposito.TiposDepositos?,
                                          permiteEscritura As Entidades.Publicos.SiNoTodos) As DataTable
      Return SucursalesDepositos_G(idSucursal:=sucursal, sucursales:=Nothing, tipoDeposito, permiteEscritura)
   End Function

   Private Function SucursalesDepositos_G(idSucursal As Integer, sucursales As Entidades.Sucursal(), tipoDeposito As Entidades.SucursalDeposito.TiposDepositos?,
                                          permiteEscritura As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)

         .AppendFormatLine("    LEFT JOIN SucursalesDepositosUsuarios SDE ON SDE.IdSucursal = SD.IdSucursal AND SDE.IdDeposito = SD.IdDeposito")
         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal > 0 Then
            .AppendFormatLine("   AND SD.IdSucursal = {0}", idSucursal)
         End If
         GetListaSucursalesMultiples(myQuery, sucursales, "SD")
         If permiteEscritura <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("     AND SDE.PermitirEscritura =  {0} ", GetStringFromBoolean(permiteEscritura = Entidades.Publicos.SiNoTodos.SI))
            .AppendFormatLine("     AND SDE.IdUsuario = '{0}'", actual.Nombre)
         End If

         If tipoDeposito.HasValue Then
            .AppendFormatLine("     AND SD.TipoDeposito = '{0}'", tipoDeposito.ToString())
         End If
         .AppendFormatLine("    ORDER BY SD.IdSucursal, SD.IdDeposito")
      End With
      Return GetDataTable(myQuery)
   End Function

   Private Function SucursalesDepositos_G(idDeposito As Integer, idSucursal As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idDeposito > 0 Then
            .AppendFormatLine("   AND SD.IdDeposito = {0}", idDeposito)
         End If
         If idSucursal > 0 Then
            .AppendFormatLine("   AND SD.IdSucursal = {0}", idSucursal)
         End If
         .AppendFormatLine("    ORDER BY IdSucursal, IdDeposito")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function SucursalesDepositos_G1(idDeposito As Integer, idSucursal As Integer) As DataTable
      Return SucursalesDepositos_G(idDeposito:=idDeposito, idSucursal:=idSucursal)
   End Function

   Public Overloads Function GetProximoId(idSucursal As Integer) As Integer
      Dim result = Convert.ToInt32(GetCodigoMaximo(Entidades.SucursalDeposito.Columnas.IdDeposito.ToString(), Entidades.SucursalDeposito.NombreTabla,
                                                   String.Format("IdSucursal = {0} AND NOT IdDeposito BETWEEN 90 AND 99", idSucursal)))
      result += 1
      If result >= 90 And result <= 99 Then result = 100
      Return result
   End Function

   Public Function GetDeposito(idSucursal As Integer) As DataTable
      Return SucursalesDepositos_G(idDeposito:=0, idSucursal:=idSucursal)
   End Function

   Public Function GetSucursalesDepositos(idSucursal As Integer, usuario As String, permiteEscritura As Boolean, disponibleVenta As Boolean, activos As Entidades.Publicos.SiNoTodos,
                                          tipos As IEnumerable(Of Entidades.SucursalDeposito.TiposDepositos)) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT SD.*, SU.Nombre as NombreSucursal FROM {0} AS SD ", Entidades.SucursalDeposito.NombreTabla)
         .AppendFormatLine("    INNER JOIN Sucursales SU ON SU.IdSucursal = SD.IdSucursal")

         If Not String.IsNullOrEmpty(usuario) Then
            .AppendFormatLine("    LEFT JOIN SucursalesDepositosUsuarios SDE ON SDE.IdSucursal = SD.IdSucursal AND SDE.IdDeposito = SD.IdDeposito")
         End If

         .AppendFormatLine("  WHERE 1 = 1")

         If Not String.IsNullOrEmpty(usuario) Then
            .AppendFormatLine("   And SDE.IdUsuario = '{0}'", usuario)
            If permiteEscritura Then
               .AppendFormatLine("     AND SDE.PermitirEscritura = '{0}'", True)
            End If
         End If
         If disponibleVenta Then
            .AppendFormatLine("     AND SD.DisponibleVenta = '{0}'", True)
         End If
         If idSucursal > 0 Then
            .AppendFormatLine("   AND SD.IdSucursal = {0}", idSucursal)
         End If
         If activos <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("     AND SD.Activo =  {0} ", GetStringFromBoolean(activos = Entidades.Publicos.SiNoTodos.SI))
         End If
         If tipos.AnySecure() Then
            .AppendFormatLine("   AND SD.TipoDeposito IN ({0})", String.Join(",", tipos.ToList().ConvertAll(Function(t) String.Format("'{0}'", t.ToString()))))
         End If
         .AppendFormatLine("    ORDER BY IdSucursal, IdDeposito")
      End With

      Return GetDataTable(myQuery)
   End Function

   Public Function GetDepositoNombre(idSucursal As Integer, nombreDeposito As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT SD.*, SU.Nombre as NombreSucursal FROM {0} AS SD ", Entidades.SucursalDeposito.NombreTabla)
         .AppendFormatLine("    INNER JOIN Sucursales SU ON SU.IdSucursal = SD.IdSucursal")

         .AppendFormatLine("  WHERE 1 = 1")

         If idSucursal <> 0 Then
            .AppendFormatLine("   AND SD.IdSucursal = {0}", idSucursal)
         End If

         If Not String.IsNullOrEmpty(nombreDeposito) Then
            .AppendFormatLine("   AND SD.NombreDeposito = '{0}'", nombreDeposito.Trim())
         End If
         .AppendFormatLine("    ORDER BY IdSucursal, IdDeposito")
      End With

      Return GetDataTable(myQuery)
   End Function

   Public Function GetCantidadPorTipo(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ISNULL(SUM(CASE WHEN TipoDeposito = '{0}' THEN 1 ELSE 0 END), 0) {0}", Entidades.SucursalDeposito.TiposDepositos.OPERATIVO.ToString())
         .AppendFormatLine("     , ISNULL(SUM(CASE WHEN TipoDeposito = '{0}' THEN 1 ELSE 0 END), 0) {0}", Entidades.SucursalDeposito.TiposDepositos.RESERVADO.ToString())
         .AppendFormatLine("     , ISNULL(SUM(CASE WHEN TipoDeposito = '{0}' THEN 1 ELSE 0 END), 0) {0}", Entidades.SucursalDeposito.TiposDepositos.ENTRANSITO.ToString())
         .AppendFormatLine("     , ISNULL(SUM(CASE WHEN TipoDeposito = '{0}' THEN 1 ELSE 0 END), 0) {0}", Entidades.SucursalDeposito.TiposDepositos.DEFECTUOSO.ToString())
         .AppendFormatLine("  FROM SucursalesDepositos")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetSucursalesPorDepositoAsociado(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT * FROM SucursalesDepositos as SD")
         .AppendFormatLine("     WHERE SD.SucursalAsociada = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND SD.DepositoAsociado = {0}", IdDeposito)
         End If
      End With

      Return GetDataTable(stb)
   End Function

End Class