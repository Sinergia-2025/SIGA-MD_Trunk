Public Class SucursalesUbicaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub SucursalesUbicaciones_I(idDeposito As Integer,
                                      idSucursal As Integer,
                                      idUbicacion As Integer,
                                      nombreUbicacion As String,
                                      codigoUbicacion As String,
                                      sucursalAsociada As Integer,
                                      depositoAsociado As Integer,
                                      ubicacionAsociada As Integer,
                                      estadoUbicacion As Integer,
                                      activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.SucursalUbicacion.NombreTabla)
         .AppendFormatLine(" {0}", Entidades.SucursalUbicacion.Columnas.IdSucursal.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.IdDeposito.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.IdUbicacion.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.NombreUbicacion.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.CodigoUbicacion.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.SucursalAsociada.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.DepositoAsociado.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.UbicacionAsociada.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.EstadoUbicacion.ToString())
         .AppendFormatLine(" ,{0}", Entidades.SucursalUbicacion.Columnas.Activo.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("   {0} ", idSucursal)
         .AppendFormatLine(" , {0} ", idDeposito)
         .AppendFormatLine(" , {0} ", idUbicacion)
         .AppendFormatLine(" ,'{0}'", nombreUbicacion)
         .AppendFormatLine(" ,'{0}'", codigoUbicacion)

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
         If ubicacionAsociada = 0 Then
            .AppendFormatLine(" ,NULL")
         Else
            .AppendFormatLine(" ,{0}", ubicacionAsociada)
         End If
         .AppendFormatLine(" , {0} ", estadoUbicacion)
         .AppendFormatLine(" , {0} ", GetStringFromBoolean(activo))
         .AppendLine(")")

      End With
      Execute(myQuery)
   End Sub

   Public Sub SucursalesUbicaciones_U(idDeposito As Integer,
                                      idSucursal As Integer,
                                      idUbicacion As Integer,
                                      nombreUbicacion As String,
                                      codigoUbicacion As String,
                                      estadoUbicacion As Integer,
                                      activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.SucursalUbicacion.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}',", Entidades.SucursalUbicacion.Columnas.NombreUbicacion.ToString(), nombreUbicacion)
         .AppendFormatLine("       {0} = '{1}',", Entidades.SucursalUbicacion.Columnas.CodigoUbicacion.ToString(), codigoUbicacion)
         .AppendFormatLine("       {0} =  {1} ,", Entidades.SucursalUbicacion.Columnas.EstadoUbicacion.ToString(), estadoUbicacion)
         .AppendFormatLine("       {0} =  {1}  ", Entidades.SucursalUbicacion.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         .AppendFormatLine(" WHERE {0} =  {1}  ", Entidades.SucursalUbicacion.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("   AND {0} =  {1}  ", Entidades.SucursalUbicacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1}  ", Entidades.SucursalUbicacion.Columnas.IdUbicacion.ToString(), idUbicacion)
      End With
      Execute(myQuery)
   End Sub
   Public Sub SucursalesUbicaciones_U_SucAsoc(idDeposito As Integer, idSucursal As Integer, idUbicacion As Integer,
                                              depositoAsociado As Integer, sucursalAsociada As Integer, ubicacionAsociada As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.SucursalUbicacion.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.SucursalUbicacion.Columnas.SucursalAsociada.ToString(), GetStringFromNumber(sucursalAsociada))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.SucursalUbicacion.Columnas.DepositoAsociado.ToString(), GetStringFromNumber(depositoAsociado))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.SucursalUbicacion.Columnas.UbicacionAsociada.ToString(), GetStringFromNumber(ubicacionAsociada))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.SucursalUbicacion.Columnas.IdSucursal.ToString(), idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.SucursalUbicacion.Columnas.IdDeposito.ToString(), idDeposito)
         End If
         If idUbicacion <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.SucursalUbicacion.Columnas.IdUbicacion.ToString(), idUbicacion)
         End If
      End With
      Execute(myQuery)
   End Sub

   Public Sub SucursalesUbicaciones_D(idDeposito As Integer,
                                      idSucursal As Integer,
                                      idUbicacion As Integer)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.SucursalUbicacion.NombreTabla)
         .AppendFormatLine("      WHERE {0} = {1}", Entidades.SucursalUbicacion.Columnas.IdSucursal.ToString(), idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("        AND {0} = {1}", Entidades.SucursalUbicacion.Columnas.IdDeposito.ToString(), idDeposito)
         End If
         If idUbicacion > 0 Then
            .AppendFormatLine("        AND {0} = {1}", Entidades.SucursalUbicacion.Columnas.IdUbicacion.ToString(), idUbicacion)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT SU.*, S.Nombre as NombreSucursal, SD.CodigoDeposito, SD.NombreDeposito, EU.NombreEstado ")
         .AppendFormatLine("    FROM {0} AS SU ", Entidades.SucursalUbicacion.NombreTabla)
         .AppendFormatLine("         INNER JOIN Sucursales S ON S.IdSucursal = SU.IdSucursal")
         .AppendFormatLine("         INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = SU.IdSucursal AND SD.IdDeposito = SU.IdDeposito")
         .AppendFormatLine("         INNER JOIN EstadosUbicaciones EU ON EU.IdEstado = SU.EstadoUbicacion")
      End With
   End Sub

   Private Function SucursalesUbicaciones_G(idDeposito As Integer, idSucursal As Integer, idUbicacion As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idDeposito > 0 Then
            .AppendFormatLine("   AND SU.IdDeposito = {0}", idDeposito)
         End If
         If idSucursal > 0 Then
            .AppendFormatLine("   AND SU.IdSucursal = {0}", idSucursal)
         End If
         If idUbicacion > 0 Then
            .AppendFormatLine("   AND SU.IdUbicacion = {0}", idUbicacion)
         End If
         .AppendFormatLine("    ORDER BY IdSucursal, IdDeposito, IdUbicacion")
      End With
      Return GetDataTable(myQuery)
   End Function
   Private Function SucursalesUbicaciones_GA(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito()) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         GetListaSucursalesMultiples(myQuery, sucursales, "SU")
         GetListaDepositosMultiples(myQuery, depositos, "SU")
         .AppendFormatLine("    ORDER BY IdSucursal, IdDeposito, IdUbicacion")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function SucursalesUbicaciones_GA() As DataTable
      Return SucursalesUbicaciones_G(idDeposito:=0, idSucursal:=0, idUbicacion:=0)
   End Function

   Public Function SucursalesUbicaciones_G1(idDeposito As Integer, idSucursal As Integer, idUbicaciones As Integer) As DataTable
      Return SucursalesUbicaciones_G(idDeposito:=idDeposito, idSucursal:=idSucursal, idUbicacion:=idUbicaciones)
   End Function

   Public Overloads Function GetCodigoMaximo(idDeposito As Integer, idSucursal As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.SucursalUbicacion.Columnas.IdUbicacion.ToString(),
                                             "SucursalesUbicaciones",
                                             String.Format("IdDeposito = {0} AND IdSucursal = {1}", idDeposito, idSucursal)))
   End Function

   Public Function GetSucursalDeposito(idDeposito As Integer, idSucursal As Integer) As DataTable
      Return SucursalesUbicaciones_G(idDeposito:=idDeposito, idSucursal:=idSucursal, idUbicacion:=0)
   End Function

   Public Function GetSucursalDepositoMultiples(sucursales As Entidades.Sucursal(), depositos As Entidades.SucursalDeposito()) As DataTable
      Return SucursalesUbicaciones_GA(sucursales, depositos)
   End Function

   Public Function GetUbicacionPredeterminadaParaSucursal(idSucursal As Integer, sinVinculadas As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT S.*")
         .AppendFormatLine("     , SD.NombreDeposito")
         .AppendFormatLine("     , SU.NombreUbicacion")

         .AppendFormatLine("     , SU.SucursalAsociada  IdSucursalAsociada")
         .AppendFormatLine("     , SU.DepositoAsociado  IdDepositoAsociado")
         .AppendFormatLine("     , SU.UbicacionAsociada IdUbicacionAsociada")
         .AppendFormatLine("     , SA.Nombre            NombreSucursalAsociada")
         .AppendFormatLine("     , SDA.NombreDeposito   NombreDepositoAsociada")
         .AppendFormatLine("     , SUA.NombreUbicacion  NombreUbicacionAsociada")

         .AppendFormatLine("  FROM (SELECT S.*")
         .AppendFormatLine("             , (SELECT TOP 1 SU.IdUbicacion FROM SucursalesUbicaciones SU WHERE SU.IdSucursal = S.IdSucursal AND SU.IdDeposito = S.IdDeposito ORDER BY SU.IdSucursal, SU.IdDeposito, SU.IdUbicacion) IdUbicacion")
         .AppendFormatLine("          FROM (SELECT S.IdSucursal")
         .AppendFormatLine("                     , S.Nombre AS NombreSucursal")
         .AppendFormatLine("                     , (SELECT TOP 1 SD.IdDeposito FROM SucursalesDepositos SD WHERE SD.IdSucursal = S.IdSucursal AND SD.Activo = 'True' ORDER BY SD.IdSucursal, SD.IdDeposito) IdDeposito")
         .AppendFormatLine("                  FROM Sucursales S) S")
         .AppendFormatLine("       ) S")
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = S.IdSucursal AND SD.IdDeposito = S.IdDeposito")
         .AppendFormatLine(" INNER JOIN SucursalesUbicaciones SU ON SU.IdSucursal = S.IdSucursal AND SU.IdDeposito = S.IdDeposito AND SU.IdUbicacion = S.IdUbicacion")

         .AppendFormatLine("  LEFT JOIN Sucursales SA ON SA.IdSucursal = SU.SucursalAsociada")
         .AppendFormatLine("  LEFT JOIN SucursalesDepositos SDA ON SDA.IdSucursal = SA.IdSucursal AND SDA.IdDeposito = SU.DepositoAsociado")
         .AppendFormatLine("  LEFT JOIN SucursalesUbicaciones SUA ON SUA.IdSucursal = SA.IdSucursal AND SUA.IdDeposito = SDA.IdDeposito AND SUA.IdUbicacion = SU.UbicacionAsociada")

         .AppendFormatLine(" WHERE 1 = 1")
         If sinVinculadas Then
            .AppendFormatLine("   AND (SU.SucursalAsociada IS NULL OR S.IdSucursal < SU.SucursalAsociada)")
         End If
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND S.IdSucursal = {0}", idSucursal)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "SU.",
                    New Dictionary(Of String, String) From {{"NombreSucursal", "S.Nombre"},
                                                            {"CodigoDeposito", "SD.CodigoDeposito"},
                                                            {"NombreDeposito", "SD.NombreDeposito"},
                                                            {"NombreEstado", "EU.NombreEstado"}})
   End Function

   Public Function GetUbicacionNombres(idSucursal As Integer, nombreDeposito As String, nombreUbicacion As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)

         .AppendFormatLine("  WHERE 1 = 1")

         If idSucursal <> 0 Then
            .AppendFormatLine("   AND SU.IdSucursal = {0}", idSucursal)
         End If

         If Not String.IsNullOrWhiteSpace(nombreDeposito) Then
            .AppendFormatLine("   AND SD.NombreDeposito = '{0}'", nombreDeposito.Trim())
         End If

         If Not String.IsNullOrWhiteSpace(nombreUbicacion) Then
            .AppendFormatLine("   AND SU.NombreUbicacion = '{0}'", nombreUbicacion.Trim())
         End If

         .AppendFormatLine("    ORDER BY IdSucursal, IdDeposito")
      End With
      Return GetDataTable(stb)
   End Function
End Class