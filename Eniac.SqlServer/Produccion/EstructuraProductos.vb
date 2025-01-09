Public Class EstructuraProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, precioConIVA As Boolean, nodoPadre As Boolean)
      With stb
         .AppendFormatLine("SELECT P.IdProducto AS IdProducto")
         .AppendFormatLine("     , P.NombreProducto AS NombreProducto")
         .AppendFormatLine("     , P.IdUnidadDeMedida AS UnidadMedida")
         .AppendFormatLine("     , P.IdMoneda AS IdMoneda")
         .AppendFormatLine("     , MD.NombreMoneda AS Moneda")
         If nodoPadre Then
            .AppendFormatLine("     , CONVERT(BIT, 'False') AS CalculoForma")
         Else
            .AppendFormatLine("     , PC.SegunCalculoForma  AS CalculoForma")
         End If
         .AppendFormatLine("     , PF.IdFormula")
         .AppendFormatLine("     , PF.NombreFormula")
         If nodoPadre Then
            .AppendFormatLine("     , 1.0 AS Cantidad")
         Else
            .AppendFormatLine("     , PC.Cantidad")
         End If
         If precioConIVA Then
            .AppendFormatLine("     , {0} AS PrecioConImpuestos", "PSP.PrecioVenta")
            .AppendFormatLine("     , {0} AS CostoConImpuestos ", "PS.PrecioCosto")
            .AppendFormatLine("     , {0} AS PrecioSinImpuestos", CalculosImpositivos.ObtenerPrecioSinImpuestos("PSP.PrecioVenta", "P"))
            .AppendFormatLine("     , {0} AS CostoSinImpuestos ", CalculosImpositivos.ObtenerPrecioSinImpuestos("PS.PrecioCosto", "P"))

         Else
            .AppendFormatLine("     , {0} AS PrecioconImpuestos", CalculosImpositivos.ObtenerPrecioConImpuestos("PSP.PrecioVenta", "P"))
            .AppendFormatLine("     , {0} AS CostoConImpuestos ", CalculosImpositivos.ObtenerPrecioConImpuestos("PS.PrecioCosto", "P"))
            .AppendFormatLine("     , {0} AS PrecioSinImpuestos", "PSP.PrecioVenta")
            .AppendFormatLine("     , {0} AS CostoSinImpuestos ", "PS.PrecioCosto")

         End If

         .AppendFormatLine("        , PrF.FormulaCalculoKilaje")
         'PE 44579
         If nodoPadre Then
            .AppendFormatLine("     , P.IdUnidadDeMedidaProduccion")
            .AppendFormatLine("      , CASE when P.IdUnidadDeMedida = P.IdUnidadDeMedidaProduccion then 1 else 1 * FactorConversionProduccion end As CantidadUMProduccion")
            .AppendFormatLine("     , P.FactorConversionProduccion")
         End If
         If Not nodoPadre Then
            .AppendFormatLine("     , PC.IdUnidadDeMedidaProduccion 
	                                 , PC.CantidadUMProduccion 
	                                 , PC.FactorConversionProduccion")
         End If

         .AppendFormatLine("  FROM Productos AS P")
         If Not nodoPadre Then
            .AppendFormatLine(" INNER JOIN ProductosComponentes PC ON PC.IdProductoComponente = P.IdProducto")
         End If
         .AppendFormatLine(" INNER JOIN Monedas MD ON P.IdMoneda = MD.IdMoneda")
         .AppendFormatLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         .AppendFormatLine(" INNER JOIN ProductosSucursalesPrecios PSP ON PSP.IdSucursal = PS.IdSucursal AND PSP.IdProducto = PS.IdProducto")
         .AppendFormatLine("  LEFT JOIN ProductosFormulas PF ON PF.IdProducto = P.IdProducto")
         If Not nodoPadre Then
            .AppendFormatLine("                                AND PF.IdFormula = PC.IdFormulaComponente")
         End If
         .AppendFormatLine("  LEFT JOIN ProduccionFormas PrF ON PrF.IdProduccionForma = P.IdProduccionForma")

      End With
   End Sub


   'Private Sub SelectTextoPadre(stb As StringBuilder, precioConIVA As Boolean)
   '   With stb
   '      .AppendLine("SELECT PC.IdProducto AS IdProducto,")
   '      .AppendLine("	     PC.NombreProducto AS NombreProducto,")
   '      .AppendLine("	     PC.IdUnidadDeMedida AS UnidadMedida,")
   '      .AppendLine("	     PS.PrecioCosto AS Precio,")
   '      .AppendLine("	     MD.Simbolo AS Moneda,")
   '      .AppendLine("	     'False' AS CalculoForma")
   '      .AppendLine(" FROM Productos AS PC")
   '      .AppendLine(" INNER JOIN Monedas MD ON PC.IdMoneda = MD.IdMoneda")
   '      .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PC.IdProducto")
   '   End With
   'End Sub
   'Private Sub SelectTextoHijos(stb As StringBuilder, precioConIVA As Boolean)
   '   With stb
   '      .AppendLine("SELECT PC.IdProductoComponente AS IdProducto, ")
   '      .AppendLine("	     PD.NombreProducto AS NombreProducto, ")
   '      .AppendLine("	     PD.IdUnidadDeMedida AS UnidadMedida, ")
   '      .AppendLine("	     PS.PrecioCosto AS Precio, ")
   '      .AppendLine("	     MD.Simbolo AS Moneda,  ")
   '      .AppendLine("	     PC.Cantidad AS Cantidad, ")
   '      .AppendLine("	     PC.SegunCalculoForma AS CalculoForma ")
   '      .AppendLine(" FROM ProductosComponentes AS PC")
   '      .AppendLine(" INNER JOIN Productos PD ON PC.IdProductoComponente = PD.IdProducto ")
   '      .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = PC.IdProductoComponente")
   '      .AppendLine(" INNER JOIN Monedas MD ON PD.IdMoneda = MD.IdMoneda ")
   '   End With
   'End Sub

   Public Function RecuperaDatos(idProducto As String, idFormula As Integer, idListaPrecios As Integer, idSucursal As Integer, precioConIVA As Boolean, nodoPadre As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, precioConIVA, nodoPadre)
         'If nodoPadre Then
         '   SelectTextoPadre(stb, precioConIVA)
         'Else
         '   SelectTextoHijos(stb, precioConIVA)
         'End If
         .AppendFormatLine(" WHERE {1}.IdProducto = '{0}'", idProducto, If(nodoPadre, "P", "PC"))
         If nodoPadre Then
            .AppendFormatLine("   AND PF.IdFormula  =  {0} ", idFormula)
         Else
            .AppendFormatLine("   AND PC.IdFormula  =  {0} ", idFormula)
         End If
         .AppendFormatLine("   AND PS.IdSucursal =  {0} ", idSucursal)
         .AppendFormatLine("   AND PSP.IdListaPrecios =  {0} ", idListaPrecios)
         .AppendFormatLine(" ORDER BY P.NombreProducto")
      End With
      Return GetDataTable(stb)
   End Function

End Class