Public Class ProductosSucursalesAtributos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
      Me._stb = New StringBuilder()
   End Sub

   Private _stb As StringBuilder

   Public Sub ProductosSucursalesAtributos_M_UStock(idProducto As String,
                                                    idSucursal As Integer,
                                                    idProdSucAtributo As Integer,
                                                    idaAtributo01 As Integer,
                                                    idaAtributo02 As Integer,
                                                    idaAtributo03 As Integer,
                                                    idaAtributo04 As Integer,
                                                    idDeposito As Integer,
                                                    idUbicacion As Integer,
                                                    Stock As Decimal)

      Dim myQuery = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("	DECLARE @idProdSucAtr AS Integer = (SELECT ISNULL( MAX(IdProdSucAtributo) , 0) ")
         .AppendLine("							    + 1  AS Cantidad FROM ProductosSucursalesAtributos")
         .AppendFormat("  									WHERE IdProducto = '{0}'", idProducto)
         .AppendFormat("  									  AND IdSucursal =  {0} ", idSucursal)
         '--------------------------------------------------------------------------------------
         .AppendLine(")")
         '--------------------------------------------------------------------------------------
         .AppendLine("		MERGE INTO ProductosSucursalesAtributos AS DEST")
         .AppendLine(" 				USING (SELECT IdProducto,")
         .AppendLine("								  IdSucursal,")
         '-- Atributo 01.- ---------------------------------------------------------------------
         If idaAtributo01 > 0 Then
            .AppendFormat("						  {0} AS IdaAtributo01,", idaAtributo01)
         Else
            .AppendLine("				   		  NULL AS IdaAtributo01,")
         End If
         '-- Atributo 02.- ---------------------------------------------------------------------
         If idaAtributo02 > 0 Then
            .AppendFormat("						  {0} AS IdaAtributo02,", idaAtributo02)
         Else
            .AppendLine("				   		  NULL AS IdaAtributo02,")
         End If
         '-- Atributo 03.- ---------------------------------------------------------------------
         If idaAtributo03 > 0 Then
            .AppendFormat("						  {0} AS IdaAtributo03,", idaAtributo03)
         Else
            .AppendLine("				   		  NULL AS IdaAtributo03,")
         End If
         '-- Atributo 04.- ---------------------------------------------------------------------
         If idaAtributo04 > 0 Then
            .AppendFormat("						  {0} AS IdaAtributo04,", idaAtributo04)
         Else
            .AppendLine("				   		  NULL AS IdaAtributo04,")
         End If
         '--------------------------------------------------------------------------------------
         .AppendFormat("						  {0} AS Stock, ", Stock)

         .AppendFormat("						  {0} AS IdDeposito, ", idDeposito)
         .AppendFormat("						  {0} AS IdUbicacion ", idUbicacion)
         '--------------------------------------------------------------------------------------
         .AppendLine("  		  FROM ProductosSucursales")
         .AppendFormat("			  WHERE IdProducto = '{0}' AND idSucursal = {1}) AS ORIG", idProducto, idSucursal)
         '--------------------------------------------------------------------------------------
         .AppendLine("				ON DEST.IdProducto = ORIG.IdProducto")
         .AppendLine("					AND DEST.IdSucursal = ORIG.IdSucursal")
         '-- Atributo 01.- ---------------------------------------------------------------------
         If idaAtributo01 > 0 Then
            .AppendLine("			   AND DEST.IdaAtributo01 = ORIG.IdaAtributo01")
         Else
            .AppendLine("				AND DEST.IdaAtributo01 IS NULL")
         End If
         '-- Atributo 02.- ---------------------------------------------------------------------
         If idaAtributo02 > 0 Then
            .AppendLine("			   AND DEST.IdaAtributo02 = ORIG.IdaAtributo02")
         Else
            .AppendLine("				AND DEST.IdaAtributo02 IS NULL")
         End If
         '-- Atributo 03.- ---------------------------------------------------------------------
         If idaAtributo03 > 0 Then
            .AppendLine("			   AND DEST.IdaAtributo03 = ORIG.IdaAtributo03")
         Else
            .AppendLine("				AND DEST.IdaAtributo03 IS NULL")
         End If
         '-- Atributo 04.- ---------------------------------------------------------------------
         If idaAtributo04 > 0 Then
            .AppendLine("			   AND DEST.IdaAtributo04 = ORIG.IdaAtributo04")
         Else
            .AppendLine("				AND DEST.IdaAtributo04 IS NULL")
         End If
         '--------------------------------------------------------------------------------------
         .AppendLine("		WHEN MATCHED THEN")
         .AppendLine("	        UPDATE SET DEST.Stock = DEST.Stock + ORIG.Stock")
         .AppendLine("		WHEN NOT MATCHED THEN")
         .AppendLine("			INSERT (IdProducto, IdSucursal, IdProdSucAtributo, IdaAtributo01, IdaAtributo02, IdaAtributo03, IdaAtributo04, Stock, IdDeposito, IdUbicacion)")
         .AppendLine("				VALUES (ORIG.IdProducto, ORIG.IdSucursal, @idProdSucAtr, ORIG.IdaAtributo01, ORIG.IdaAtributo02, ORIG.IdaAtributo03, ORIG.IdaAtributo04, ORIG.Stock, ORIG.IdDeposito, ORIG.IdUbicacion);")
         '--------------------------------------------------------------------------------------
      End With

      Execute(myQuery)
      Me.Sincroniza_I(myQuery.ToString(), "ProductosSucursalesAtributos")

   End Sub

   Public Sub ProductosSucursalesAtributos_D(idProducto As String,
                                             idSucursal As Integer,
                                             idProdSucAtributo As Integer)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("DELETE FROM ProductosSucursalesAtributos ")
         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
         If idSucursal > 0 Then
            .AppendFormat(" AND IdSucursal = {0}", idSucursal)
         End If
         If idProdSucAtributo > 0 Then
            .AppendFormat(" AND IdProdSucAtributo = {0}", idProdSucAtributo)
         End If
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosSucursalesAtributos")
   End Sub

   Public Function GetStockProductoAtributo(idProducto As String,
                                            idSucursal As Integer,
                                            idaAtributo01 As Integer,
                                            idaAtributo02 As Integer,
                                            idaAtributo03 As Integer,
                                            idaAtributo04 As Integer) As Decimal

      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT * FROM ProductosSucursalesAtributos AS PSA")
         .AppendFormatLine("  WHERE PSA.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("    AND PSA.IdSucursal = {0}", idSucursal)
         '-- Atributo 01.- ---------------------------------------------------------------------
         If idaAtributo01 > 0 Then
            .AppendFormatLine("    AND PSA.idaAtributo01 = {0}", idaAtributo01)
         End If
         '-- Atributo 02.- ---------------------------------------------------------------------
         If idaAtributo02 > 0 Then
            .AppendFormatLine("    AND PSA.idaAtributo02 = {0}", idaAtributo02)
         End If
         '-- Atributo 03.- ---------------------------------------------------------------------
         If idaAtributo03 > 0 Then
            .AppendFormatLine("    AND PSA.idaAtributo03 = {0}", idaAtributo03)
         End If
         '-- Atributo 04.- ---------------------------------------------------------------------
         If idaAtributo04 > 0 Then
            .AppendFormatLine("    AND PSA.idaAtributo04 = {0}", idaAtributo04)
         End If
         '--------------------------------------------------------------------------------------
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return Decimal.Parse(dt.Rows(0)("Stock").ToString())
      Else
         Return 0
      End If

   End Function
End Class
