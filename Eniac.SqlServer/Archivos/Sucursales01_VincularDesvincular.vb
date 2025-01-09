Partial Class Sucursales
   Public Function GetParaDesvincular_Depositos(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT SD1.IdSucursal, S1.Nombre, SD1.IdDeposito, SD1.CodigoDeposito, SD1.NombreDeposito")
         .AppendFormatLine("     , '' AS EstadoVinculacion")
         .AppendFormatLine("     , SD2.IdSucursal IdSucursalAsociada, S2.Nombre NombreSucursalAsociada, SD2.IdDeposito IdDepositoASociado, SD2.CodigoDeposito CodigoDepositoAsociado, SD2.NombreDeposito NombreDepositoAsociado")
         .AppendFormatLine("  FROM SucursalesDepositos SD1")
         .AppendFormatLine(" INNER JOIN Sucursales S1 ON S1.IdSucursal = SD1.IdSucursal")
         .AppendFormatLine("  LEFT JOIN SucursalesDepositos SD2 ON SD1.IdSucursal = SD2.SucursalAsociada AND SD1.IdDeposito = SD2.DepositoAsociado")
         .AppendFormatLine("  LEFT JOIN Sucursales S2 ON S2.IdSucursal = SD2.IdSucursal")
         .AppendFormatLine(" WHERE SD1.IdSucursal = {0}", idSucursal)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetParaDesvincular_Ubicaciones(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT SD1.IdSucursal, S1.Nombre, SD1.IdDeposito, SD1.CodigoDeposito, SD1.NombreDeposito, SU1.IdUbicacion, SU1.CodigoUbicacion, SU1.NombreUbicacion")
         .AppendFormatLine("     , '' AS EstadoVinculacion")
         .AppendFormatLine("     , SD2.IdSucursal IdSucursalAsociada, S2.Nombre NombreSucursalAsociada, SD2.IdDeposito IdDepositoASociado, SD2.CodigoDeposito CodigoDepositoAsociado, SD2.NombreDeposito NombreDepositoAsociado, SU2.IdUbicacion IdUbicacionAsociada, SU2.CodigoUbicacion CodigoUbicacionAsociada, SU2.NombreUbicacion NombreUbicacionAsociada")
         .AppendFormatLine("  FROM SucursalesUbicaciones SU1")
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SD1 ON SD1.IdSucursal = SU1.IdSucursal AND SD1.IdDeposito = SU1.IdDeposito")
         .AppendFormatLine(" INNER JOIN Sucursales S1 ON S1.IdSucursal = SD1.IdSucursal")
         .AppendFormatLine("  LEFT JOIN SucursalesUbicaciones SU2 ON SU1.IdSucursal = SU2.SucursalAsociada AND SU1.IdDeposito = SU2.DepositoAsociado AND SU1.IdUbicacion = SU2.UbicacionAsociada")
         .AppendFormatLine("  LEFT JOIN SucursalesDepositos SD2 ON SD2.IdSucursal = SU2.SucursalAsociada AND SD2.IdDeposito = SU2.DepositoAsociado")
         .AppendFormatLine("  LEFT JOIN Sucursales S2 ON S2.IdSucursal = SD2.IdSucursal")
         .AppendFormatLine(" WHERE SU1.IdSucursal = {0}", idSucursal)
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub Sucursales_U_SucAsoc(idSucursal As Integer, sucursalAsociada As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Sucursal.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.Sucursal.Columnas.IdSucursalAsociada.ToString(), GetStringFromNumber(sucursalAsociada))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Sucursal.Columnas.IdSucursal.ToString(), idSucursal)
      End With
      Execute(myQuery)
   End Sub


   Public Sub RecualculoStockParaRepararInconsistencias_Stock0(idSucursal As IEnumerable(Of Integer))
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ProductosSucursales")
         .AppendFormatLine("   SET Stock = 0")
         .AppendFormatLine(" WHERE IdSucursal IN ({0})", String.Join(",", idSucursal))
      End With
      Execute(myQuery)
   End Sub

   Public Sub RecualculoStockParaRepararInconsistencias_SumaMovimientos(idSucursal As IEnumerable(Of Integer))
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PU")
         .AppendFormatLine("   SET Stock = ")
         .AppendFormatLine("           (SELECT ISNULL( SUM(cantidad), 0)")
         .AppendFormatLine("              FROM MovimientosStockProductos MSP")
         .AppendFormatLine("             WHERE MSP.IdProducto   = PU.IdProducto")
         .AppendFormatLine("               AND ((MSP.IdSucursal  = SU.IdSucursal       AND MSP.IdDeposito  = SU.IdDeposito       AND MSP.IdUbicacion = SU.IdUbicacion) OR")
         .AppendFormatLine("                    (MSP.IdSucursal  = SU.SucursalAsociada AND MSP.IdDeposito  = SU.DepositoAsociado AND MSP.IdUbicacion = SU.UbicacionAsociada))")
         .AppendFormatLine("            ) ")
         .AppendFormatLine("  FROM ProductosUbicaciones PU")
         .AppendFormatLine(" INNER JOIN SucursalesUbicaciones SU ON SU.IdSucursal   = PU.IdSucursal")
         .AppendFormatLine("                                    AND SU.IdDeposito   = PU.IdDeposito")
         .AppendFormatLine("                                    AND SU.IdUbicacion  = PU.IdUbicacion")
         .AppendFormatLine(" WHERE 1 = 1")
         .AppendFormatLine("   AND PU.IdSucursal IN ({0})", String.Join(",", idSucursal))
      End With
      Execute(myQuery)
   End Sub

   Public Sub RecualculoStockParaRepararInconsistencias_AcumulaDeposito(idSucursal As IEnumerable(Of Integer))
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PD")
         .AppendFormatLine("   SET Stock = PU.Stock")
         .AppendFormatLine("  FROM ProductosDepositos PD")
         .AppendFormatLine(" INNER JOIN (SELECT IdSucursal, IdDeposito, IdProducto, SUM(Stock) Stock")
         .AppendFormatLine("               FROM ProductosUbicaciones")
         .AppendFormatLine("              GROUP BY IdProducto, IdSucursal, IdDeposito) PU")
         .AppendFormatLine("         ON PU.IdProducto = PD.IdProducto")
         .AppendFormatLine("        AND PU.IdSucursal = PD.IdSucursal")
         .AppendFormatLine("        AND PU.IdDeposito = PD.IdDeposito")
         .AppendFormatLine(" WHERE 1 = 1")
         .AppendFormatLine("   AND PD.IdSucursal IN ({0})", String.Join(",", idSucursal))
      End With
      Execute(myQuery)
   End Sub
   Public Sub RecualculoStockParaRepararInconsistencias_AcumulaSucursal(idSucursal As IEnumerable(Of Integer))
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE PS")
         .AppendFormatLine("   SET Stock = PD.Stock")
         .AppendFormatLine("  FROM ProductosSucursales PS")
         .AppendFormatLine(" INNER JOIN (SELECT PD.IdSucursal, PD.IdProducto, SUM(PD.Stock) Stock")
         .AppendFormatLine("               FROM ProductosDepositos PD")
         .AppendFormatLine("              INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = PD.IdSucursal AND SD.IdDeposito = PD.IdDeposito")
         .AppendFormatLine("              WHERE SD.TipoDeposito = '{0}'", Entidades.SucursalDeposito.TiposDepositos.OPERATIVO.ToString())
         .AppendFormatLine("              GROUP BY PD.IdProducto, PD.IdSucursal) PD")
         .AppendFormatLine("         ON PS.IdProducto = PD.IdProducto")
         .AppendFormatLine("        AND PS.IdSucursal = PD.IdSucursal")
         .AppendFormatLine(" WHERE 1 = 1")
         .AppendFormatLine("   AND PS.IdSucursal IN ({0})", String.Join(",", idSucursal))
      End With
      Execute(myQuery)
   End Sub

End Class
