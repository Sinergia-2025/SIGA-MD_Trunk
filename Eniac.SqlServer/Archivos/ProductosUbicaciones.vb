Imports Eniac.Entidades

Public Class ProductosUbicaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosUbicaciones_I(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                     stock As Decimal, stock2 As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.ProductoUbicacion.NombreTabla)
         .AppendFormatLine("  {0}", ProductoUbicacion.Columnas.IdProducto.ToString())
         .AppendFormatLine(" ,{0}", ProductoUbicacion.Columnas.IdSucursal.ToString())
         .AppendFormatLine(" ,{0}", ProductoUbicacion.Columnas.IdDeposito.ToString())
         .AppendFormatLine(" ,{0}", ProductoUbicacion.Columnas.IdUbicacion.ToString())
         .AppendFormatLine(" ,{0}", ProductoUbicacion.Columnas.Stock.ToString())
         .AppendFormatLine(" ,{0}", ProductoUbicacion.Columnas.Stock2.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("   '{0}' ", idProducto)
         .AppendFormatLine(" ,  {0}  ", idSucursal)
         .AppendFormatLine(" ,  {0}  ", idDeposito)
         .AppendFormatLine(" ,  {0}  ", idUbicacion)
         .AppendFormatLine(" ,  {0}  ", stock)
         .AppendFormatLine(" ,  {0}  ", stock2)
         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProductosUbicaciones_D(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.ProductoUbicacion.NombreTabla)
         .AppendFormatLine(" WHERE ")
         .AppendFormatLine("       {0} = '{1}' ", ProductoUbicacion.Columnas.IdProducto.ToString(), idProducto)
         '-- Verifica IdSucursal.- -------------------------------------------------------------------------------
         If idSucursal > 0 Then
            .AppendFormatLine("  AND  {0}  = {1} ", ProductoUbicacion.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         '-- Verifica IdDepósito.- -------------------------------------------------------------------------------
         If idDeposito > 0 Then
            .AppendFormatLine("  AND  {0}  = {1} ", ProductoUbicacion.Columnas.IdDeposito.ToString(), idDeposito)
         End If
         '-- Verifica IdUbicación.- ------------------------------------------------------------------------------
         If idUbicacion > 0 Then
            .AppendFormatLine("  AND  {0}  = {1} ", ProductoUbicacion.Columnas.IdUbicacion.ToString(), idUbicacion)
         End If
         '--------------------------------------------------------------------------------------------------------
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProductosSucursalesUbicaciones_I(IdDeposito As Integer, IdSucursal As Integer, IdUbicacion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ProductosUbicaciones")
         .AppendFormatLine("           (IdProducto")
         .AppendFormatLine("           ,IdSucursal")
         .AppendFormatLine("           ,IdDeposito")
         .AppendFormatLine("           ,IdUbicacion")
         .AppendFormatLine("           ,Stock")
         .AppendFormatLine("           ,Stock2)")
         .AppendFormatLine(" SELECT PS.IdProducto")
         .AppendFormatLine("       , {0} AS Sucursal", IdSucursal)
         .AppendFormatLine("       , {0} AS Deposito", IdDeposito)
         .AppendFormatLine("       , {0} AS Ubicacion", IdUbicacion)
         .AppendFormatLine("       ,0 AS Stock")
         .AppendFormatLine("       ,0 AS Stock2")
         .AppendFormatLine("  FROM ProductosSucursales PS, Sucursales S")
         .AppendFormatLine(" WHERE PS.IdSucursal = S.IdSucursal")
         .AppendFormatLine("   AND S.SoyLaCentral = 'True'")
      End With
      Execute(stb)
   End Sub

   Public Sub ProductosSucursalesUbicaciones_D(IdDeposito As Integer, IdSucursal As Integer, IdUbicacion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ProductosUbicaciones")
         .AppendFormatLine("     WHERE IdSucursal  = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND IdDeposito  = {0}", IdDeposito)
         End If
         If IdUbicacion <> 0 Then
            .AppendFormatLine("       AND IdUbicacion = {0}", IdUbicacion)
         End If
      End With
      Execute(stb)
   End Sub

   Public Function GetSucursalDepositoProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String,
                                               verificaStock As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT PU.*")
         .AppendFormatLine("     , SC.Nombre")
         .AppendFormatLine("     , Pr.NombreProducto")
         .AppendFormatLine("     , SD.NombreDeposito")
         .AppendFormatLine("     , SU.NombreUbicacion")
         .AppendFormatLine("  FROM ProductosUbicaciones PU")
         .AppendFormatLine(" INNER JOIN Sucursales SC ON PU.IdSucursal = SC.IdSucursal")
         .AppendFormatLine(" INNER JOIN Productos Pr ON PU.IdProducto = Pr.IdProducto")
         .AppendFormatLine(" INNER JOIN SucursalesDepositos SD ON PU.IdSucursal = SD.IdSucursal AND PU.IdDeposito = SD.IdDeposito")
         .AppendFormatLine(" INNER JOIN SucursalesUbicaciones SU ON PU.IdSucursal = SU.IdSucursal AND PU.IdDeposito = SU.IdDeposito AND PU.IdUbicacion = SU.IdUbicacion")
         .AppendFormatLine(" WHERE PU.IdSucursal   =  {0} ", idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("   AND PU.IdDeposito   =  {0} ", idDeposito)
         End If
         If idUbicacion <> 0 Then
            .AppendFormatLine("   AND PU.IdUbicacion  =  {0} ", idUbicacion)
         End If
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("    AND PU.IdProducto  = '{0}'", idProducto)
         End If
         If verificaStock Then
            .AppendLine("   AND PU.Stock <> 0 ")
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Sub ProductosSucursalesUbicacion_UStock(idSucursal As Integer,
                                                  idDeposito As Integer,
                                                  idUbicacion As Integer,
                                                  idProducto As String,
                                                  stock As Decimal,
                                                  stock2 As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS D", Entidades.ProductoUbicacion.NombreTabla)
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.ProductoUbicacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoUbicacion.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoUbicacion.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ProductoUbicacion.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoUbicacion.Columnas.Stock.ToString(), stock)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoUbicacion.Columnas.Stock2.ToString(), stock2)
         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1} AND O.{2} = D.{2} AND O.{3} = D.{3}",
                           Entidades.ProductoUbicacion.Columnas.IdSucursal.ToString(),
                           Entidades.ProductoUbicacion.Columnas.IdDeposito.ToString(),
                           Entidades.ProductoUbicacion.Columnas.IdUbicacion.ToString(),
                           Entidades.ProductoUbicacion.Columnas.IdProducto.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = D.{0} + O.{0}, D.{1} = D.{1} + O.{1}",
                           Entidades.ProductoUbicacion.Columnas.Stock.ToString(),
                           Entidades.ProductoUbicacion.Columnas.Stock2.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}, {4}, {5}) VALUES (O.{0}, O.{1}, O.{2}, O.{3}, O.{4}, O.{5})",
                           Entidades.ProductoUbicacion.Columnas.IdSucursal.ToString(),
                           Entidades.ProductoUbicacion.Columnas.IdDeposito.ToString(),
                           Entidades.ProductoUbicacion.Columnas.IdUbicacion.ToString(),
                           Entidades.ProductoUbicacion.Columnas.IdProducto.ToString(),
                           Entidades.ProductoUbicacion.Columnas.Stock.ToString(),
                           Entidades.ProductoUbicacion.Columnas.Stock2.ToString())
         .AppendFormatLine(";")
      End With
      Execute(myQuery)
   End Sub

   Public Function GetCantidadDeInconsistenciaDepositosVsUbicaciones(idSucursal As Integer) As Integer
      Return GetInconsistenciaDepositosVsUbicaciones(idSucursal).CountSecure()
   End Function

   Public Function GetInconsistenciaDepositosVsUbicaciones(idSucursal As Integer) As DataTable

      Dim idSucursalAsociada = 0I
      Using dtSuc = New Sucursales(_da).Sucursales_G1(idSucursal, False)
         If dtSuc.Any() Then
            idSucursalAsociada = dtSuc.First().Field(Of Integer?)("IdSucursalAsociada").IfNull()
         End If
      End Using

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT U.IdProducto as Codigo")
         .AppendLine("	    ,P.NombreProducto as Producto")
         .AppendLine("      ,M.NombreMarca AS Marca")
         .AppendLine("      ,R.NombreRubro AS Rubro")
         .AppendLine("	    ,SD.NombreDeposito as Deposito")
         .AppendLine("	    ,D.Stock As StockDeposito")
         .AppendLine("	    ,U.CantUbi as StockUbicaciones")
         .AppendLine("  FROM (SELECT idProducto, IdDeposito, SUM(Stock) CantUbi  FROM ProductosUbicaciones ")
         '-- REQ-39199.- ------------------------------------------------------------------------------------
         .AppendFormatLine("     WHERE (IdSucursal = {0}", idSucursal)
         If idSucursalAsociada > 0 Then
            .AppendFormatLine("      OR IdSucursal = {0}", idSucursalAsociada)
         End If
         .AppendLine("    )")
         .AppendLine("  GROUP BY IdProducto, IdSucursal, IdDeposito) AS U")
         '---------------------------------------------------------------------------------------------------
         .AppendLine("  	INNER JOIN ProductosDepositos AS D ON U.IdDeposito = D.IdDeposito AND U.IdProducto = D.IdProducto ")
         .AppendLine("  	INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = D.IdSucursal AND SD.IdDeposito = D.IdDeposito")
         .AppendLine("  	LEFT JOIN Productos P ON U.IdProducto = P.IdProducto")
         .AppendLine("  	LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine("    	LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")

         .AppendLine("  WHERE U.IdProducto = D.IdProducto ")
         '.AppendFormatLine("   AND D.IdSucursal = {0}", idSucursal)
         'If idSucursalAsociada > 0 Then
         '   .AppendFormatLine("      OR D.IdSucursal = {0}", idSucursalAsociada)
         'End If
         '.AppendLine("    )")
         .AppendLine("    	 AND P.AfectaStock = 'True'")
         .AppendFormatLine("    AND D.IdSucursal = {0}", idSucursal)
         .AppendLine("    	 AND NOT (P.EsCompuesto = 'True' AND P.DescontarStockComponentes = 'True')")
         .AppendLine("    	 AND D.Stock <> U.CantUbi ")
         .AppendLine(" ORDER BY P.NombreProducto , P.IdProducto")
      End With

      Return GetDataTable(stb)

   End Function


   Public Function GetCantidadDeInconsistenciaUbicacionesVsMovStock(idSucursal As Integer) As Integer
      Return GetInconsistenciaUbicacionesVsMovStock(idSucursal).CountSecure()
   End Function

   Public Function GetInconsistenciaUbicacionesVsMovStock(idSucursal As Integer) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("WITH SucursalesVinculadasubicacion AS ")
         .AppendLine("	(SELECT SU.IdSucursal, SU.iddeposito, idubicacion,")
         .AppendLine("			CASE WHEN (SU.SucursalAsociada IS NULL AND SU.DepositoAsociado IS NULL AND UbicacionAsociada IS NULL) THEN 'No Vinculada' + CAST(SU.IdSucursal as varchar(10)) + CAST(SU.IdDeposito as varchar(10)) + CAST(SU.IdUbicacion as varchar(10))")
         .AppendLine("			ELSE 'Vinculada' END AS grupo_vinculacion")
         .AppendLine("	 FROM SucursalesUbicaciones SU)")
         .AppendLine("SELECT")
         .AppendLine("	MP.IdProducto")
         .AppendLine("   ,P.NombreProducto AS Producto")
         .AppendLine("   ,M.NombreMarca AS Marca")
         .AppendLine("   ,R.NombreRubro AS Rubro")
         .AppendLine("   ,MP.Stock AS StockUbicacion")
         .AppendLine("   ,MP.Historico AS CantidadMovStock from (")
         .AppendLine("SELECT ")
         .AppendLine("    MCP.IdProducto")
         .AppendLine("   ,MCP.Stock")
         .AppendLine("   ,sum (MCP.Sumado) AS Historico")
         .AppendLine("	  from")
         .AppendLine("(")
         .AppendLine("SELECT ")
         .AppendLine("     MsP.IdProducto, msp.IdSucursal, msp.IdDeposito, msp.IdUbicacion, pu.Stock, sv.grupo_vinculacion, sum(cantidad) as Sumado")
         .AppendLine("FROM MovimientosStockProductos msp")
         .AppendLine("INNER JOIN ProductosUbicaciones pu on pu.IdSucursal = msp.IdSucursal")
         .AppendLine("									and pu.IdDeposito = msp.IdDeposito")
         .AppendLine("									and pu.IdUbicacion = msp.IdUbicacion")
         .AppendLine("									and pu.IdProducto = msp.IdProducto")
         .AppendLine("INNER JOIN SucursalesVinculadasubicacion Sv on sv.IdSucursal = msp.IdSucursal")
         .AppendLine("											and sv.IdDeposito = msp.IdDeposito")
         .AppendLine("											and sv.IdUbicacion = msp.IdUbicacion")
         .AppendLine("GROUP BY MsP.IdProducto, msp.IdSucursal, msp.IdDeposito, msp.IdUbicacion, pu.Stock, sv.grupo_vinculacion")
         .AppendLine(") AS MCP")
         .AppendLine(" GROUP BY MCP.IdProducto, mcp.Stock, mcp.grupo_vinculacion")
         .AppendLine(" ) AS MP")
         .AppendLine("LEFT JOIN Productos P ON MP.IdProducto = P.IdProducto")
         .AppendLine("LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" WHERE")
         .AppendLine("     P.IdProducto = MP.IdProducto")
         .AppendLine(" AND P.AfectaStock = 'True'")
         .AppendLine(" AND NOT (P.EsCompuesto = 'True' AND P.DescontarStockComponentes = 'True')")
         .AppendLine(" AND MP.Stock <> MP.Historico")
      End With

      Return GetDataTable(stb)

   End Function

End Class