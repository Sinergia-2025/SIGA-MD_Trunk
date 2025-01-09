Imports Eniac.Entidades

Public Class ProductosDepositos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosDepositos_I(idProducto As String, idSucursal As Integer, idDeposito As Integer,
                                   stock As Decimal, stock2 As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.ProductoDeposito.NombreTabla)
         .AppendFormatLine("  {0}", Entidades.ProductoDeposito.Columnas.IdProducto.ToString())
         .AppendFormatLine(" ,{0}", Entidades.ProductoDeposito.Columnas.IdSucursal.ToString())
         .AppendFormatLine(" ,{0}", Entidades.ProductoDeposito.Columnas.IdDeposito.ToString())
         .AppendFormatLine(" ,{0}", Entidades.ProductoDeposito.Columnas.Stock.ToString())
         .AppendFormatLine(" ,{0}", Entidades.ProductoDeposito.Columnas.Stock2.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("   '{0}' ", idProducto)
         .AppendFormatLine(" ,  {0}  ", idSucursal)
         .AppendFormatLine(" ,  {0}  ", idDeposito)
         .AppendFormatLine(" ,  {0}  ", stock)
         .AppendFormatLine(" ,  {0}  ", stock2)
         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProductosDepositos_D(idProducto As String, idSucursal As Integer, idDeposito As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.ProductoDeposito.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}' ", Entidades.ProductoDeposito.Columnas.IdProducto.ToString(), idProducto)
         '-- Verifica IdSucursal.- -------------------------------------------------------------------------------
         If idSucursal > 0 Then
            .AppendFormatLine("   AND  {0}  = {1} ", Entidades.ProductoDeposito.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         '-- Verifica IdDeposito.- ---------------------------
         If idDeposito > 0 Then
            .AppendFormatLine("   AND  {0}  = {1} ", Entidades.ProductoDeposito.Columnas.IdDeposito.ToString(), idDeposito)
         End If
         '----------------------------------------------------
      End With
      Execute(myQuery)
   End Sub

   Public Sub ProductosSucursalesDepositos_I(idDeposito As Integer, idSucursal As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO {0}", Entidades.ProductoDeposito.NombreTabla)
         .AppendFormatLine("           (IdProducto")
         .AppendFormatLine("           ,IdSucursal")
         .AppendFormatLine("           ,IdDeposito")
         .AppendFormatLine("           ,Stock")
         .AppendFormatLine("           ,Stock2)")
         .AppendFormatLine(" SELECT P.IdProducto")
         .AppendFormatLine("       ,{0} AS Sucursal", idSucursal)
         .AppendFormatLine("       ,{0} AS Deposito", idDeposito)
         .AppendFormatLine("       ,0 AS Stock")
         .AppendFormatLine("       ,0 AS Stock2")
         .AppendFormatLine("  FROM Productos P")
      End With
      Execute(stb)
   End Sub

   Public Sub ProductosSucursalesDepositos_D(IdDeposito As Integer, IdSucursal As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM {0}", Entidades.ProductoDeposito.NombreTabla)
         .AppendFormatLine("     WHERE IdSucursal = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND IdDeposito = {0}", IdDeposito)
         End If
      End With
      Execute(stb.ToString())
   End Sub

   Public Sub ProductosSucursalesDepositos_UStock(idSucursal As Integer,
                                                  idDeposito As Integer,
                                                  idProducto As String,
                                                  stock As Decimal,
                                                  stock2 As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS D", Entidades.ProductoDeposito.NombreTabla)
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.ProductoDeposito.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoDeposito.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ProductoDeposito.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoDeposito.Columnas.Stock.ToString(), stock)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoDeposito.Columnas.Stock2.ToString(), stock2)
         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1} AND O.{2} = D.{2}",
                           Entidades.ProductoDeposito.Columnas.IdSucursal.ToString(),
                           Entidades.ProductoDeposito.Columnas.IdDeposito.ToString(),
                           Entidades.ProductoDeposito.Columnas.IdProducto.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = D.{0} + O.{0}, D.{1} = D.{1} + O.{1}",
                           Entidades.ProductoDeposito.Columnas.Stock.ToString(),
                           Entidades.ProductoDeposito.Columnas.Stock2.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}, {4}) VALUES (O.{0}, O.{1}, O.{2}, O.{3}, O.{4})",
                           Entidades.ProductoDeposito.Columnas.IdSucursal.ToString(),
                           Entidades.ProductoDeposito.Columnas.IdDeposito.ToString(),
                           Entidades.ProductoDeposito.Columnas.IdProducto.ToString(),
                           Entidades.ProductoDeposito.Columnas.Stock.ToString(),
                           Entidades.ProductoDeposito.Columnas.Stock2.ToString())
         .AppendFormatLine(";")
      End With
      Execute(myQuery)
   End Sub

   Public Function GetCantidadDeInconsistenciaDepositosVsSucursales(idSucursal As Integer) As Integer
      Return GetInconsistenciaDepositosVsSucursales(idSucursal).CountSecure()
   End Function

   Public Function GetInconsistenciaDepositosVsSucursales(idSucursal As Integer) As DataTable

      Dim idSucursalAsociada = 0I
      Using dtSuc = New Sucursales(_da).Sucursales_G1(idSucursal, False)
         If dtSuc.Any() Then
            idSucursalAsociada = dtSuc.First().Field(Of Integer?)("IdSucursalAsociada").IfNull()
         End If
      End Using

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT D.IdProducto as Codigo")
         .AppendLine("      ,P.NombreProducto AS Producto")
         .AppendLine("      ,M.NombreMarca AS Marca")
         .AppendLine("      ,R.NombreRubro AS Rubro")
         .AppendLine("	    ,PS.Stock AS StockSucursal")
         .AppendLine("	    ,D.CantDepo AS StockDeposito")
         .AppendLine("  FROM ")
         .AppendLine("	(SELECT D.IdProducto, D.IdSucursal, SUM(D.Stock) AS CantDepo FROM ProductosDepositos AS D")
         .AppendLine("		INNER JOIN SucursalesDepositos SD ON SD.IdSucursal = D.IdSucursal AND SD.IdDeposito = D.IdDeposito")
         .AppendLine("	WHERE SD.TipoDeposito = 'OPERATIVO' GROUP BY D.IdProducto, D.IdSucursal) AS D")
         .AppendLine("     INNER JOIN ProductosSucursales AS PS ON PS.IdSucursal = D.IdSucursal AND PS.IdProducto = D.IdProducto ")
         .AppendLine("     LEFT JOIN Productos P ON D.IdProducto = P.IdProducto")
         .AppendLine("     LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine("     LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine("  WHERE PS.IdProducto = D.IdProducto")
         .AppendFormatLine("   AND (PS.IdSucursal = {0}", idSucursal)
         If idSucursalAsociada > 0 Then
            .AppendFormatLine("      OR PS.IdSucursal = {0}", idSucursalAsociada)
         End If
         .AppendLine("    )")
         .AppendLine("   	AND P.AfectaStock = 'True'")
         .AppendFormatLine("    AND PS.IdSucursal = {0}", idSucursal)
         .AppendLine("   	AND NOT (P.EsCompuesto = 'True' AND P.DescontarStockComponentes = 'True')")
         .AppendLine("   	AND PS.Stock <> D.CantDepo ")
         .AppendLine(" ORDER BY P.NombreProducto,P.IdProducto")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetCantidadDeInconsistenciaDepositosVsMovStock(idSucursal As Integer) As Integer
      Return GetInconsistenciaDepositosVsMovStock(idSucursal).CountSecure()
   End Function

   Public Function GetInconsistenciaDepositosVsMovStock(idSucursal As Integer) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("with SucursalesVinculadasDepositos AS ")
         .AppendLine("	(select SD.IdSucursal, SD.iddeposito,")
         .AppendLine("			CASE WHEN (SD.SucursalAsociada IS NULL AND SD.DepositoAsociado IS NULL) THEN 'No Vinculada' + CAST(SD.IdSucursal as varchar(10)) + CAST(SD.IdDeposito as varchar(10))")
         .AppendLine("			ELSE 'Vinculada' END AS grupo_vinculacion")
         .AppendLine("	 FROM SucursalesDepositos SD)")
         .AppendLine("select")
         .AppendLine("	MP.IdProducto")
         .AppendLine("   ,P.NombreProducto AS Producto")
         .AppendLine("   ,M.NombreMarca AS Marca")
         .AppendLine("   ,R.NombreRubro AS Rubro")
         .AppendLine("   ,MP.Stock AS StockDeposito")
         .AppendLine("   ,MP.Historico AS CantidadMovStock from (")
         .AppendLine("Select ")
         .AppendLine("    MCP.IdProducto")
         .AppendLine("   ,MCP.Stock")
         .AppendLine("   ,sum (MCP.Sumado) AS Historico")
         .AppendLine("	  from")
         .AppendLine("(")
         .AppendLine("select ")
         .AppendLine("MsP.IdProducto, msp.IdSucursal, msp.IdDeposito, pu.Stock, sv.grupo_vinculacion, sum(cantidad) as Sumado")
         .AppendLine("from MovimientosStockProductos msp")
         .AppendLine("inner join ProductosDepositos pu on pu.IdSucursal = msp.IdSucursal")
         .AppendLine("									and pu.IdDeposito = msp.IdDeposito")
         .AppendLine("									and pu.IdProducto = msp.IdProducto")
         .AppendLine("inner join SucursalesVinculadasDepositos Sv on sv.IdSucursal = msp.IdSucursal")
         .AppendLine("											and sv.IdDeposito = msp.IdDeposito")
         .AppendLine("group by MsP.IdProducto, msp.IdSucursal, msp.IdDeposito, pu.Stock, sv.grupo_vinculacion")
         .AppendLine(") AS MCP")
         .AppendLine(" group by MCP.IdProducto, mcp.Stock, mcp.grupo_vinculacion")
         .AppendLine(" ) AS MP")
         .AppendLine("LEFT JOIN Productos P ON MP.IdProducto = P.IdProducto")
         .AppendLine("LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" where")
         .AppendLine(" P.IdProducto = MP.IdProducto")
         .AppendLine("    	AND P.AfectaStock = 'True'")
         .AppendLine("   	AND NOT (P.EsCompuesto = 'True' AND P.DescontarStockComponentes = 'True') ")
         .AppendLine("	 	AND MP.Stock <> MP.Historico")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetCantidadDepositosConStock(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM {0} as PD", Entidades.ProductoDeposito.NombreTabla)
         .AppendFormatLine("     WHERE PD.IdSucursal = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND PD.IdDeposito = {0}", IdDeposito)
         End If
         .AppendLine("       AND PD.Stock > 0")
      End With

      Return GetDataTable(stb)
   End Function

End Class