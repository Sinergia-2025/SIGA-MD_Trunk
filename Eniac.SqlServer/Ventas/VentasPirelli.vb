Public Class VentasPirelli
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ")
         .AppendFormatLine(" (SELECT ValorParametro FROM Parametros WHERE idParametro = 'VENTASPIRELLIIDSUCURSAL') as Sucursal, ")
         .AppendFormatLine("     CONVERT(DATE, VTAS.Fecha) AS FechaVenta, ")
         .AppendFormatLine("     PROD.IdProducto AS ProductoID, ")
         '-- REQ-32666.- -------------------------------------------
         .AppendFormatLine("     SUM(VTAP.Cantidad) AS Cantidad")
         '----------------------------------------------------------
         .AppendFormatLine("  FROM Ventas as VTAS")
         .AppendFormatLine("      INNER JOIN VentasProductos as VTAP")
         .AppendFormatLine("        ON  VTAS.IdSucursal = VTAP.IdSucursal")
         .AppendFormatLine("        AND VTAS.IdTipoComprobante = VTAP.IdTipoComprobante")
         .AppendFormatLine("        AND VTAS.Letra = VTAP.Letra")
         .AppendFormatLine("        AND VTAS.CentroEmisor = VTAP.CentroEmisor")
         .AppendFormatLine("        AND VTAS.NumeroComprobante = VTAP.NumeroComprobante")
         .AppendFormatLine("  INNER JOIN Productos AS PROD ON VTAP.IDPRODUCTO = PROD.IdProducto")
         .AppendFormatLine("  INNER JOIN TiposComprobantes AS TCOM ON VTAS.IdTipoComprobante = TCOM.IdTipoComprobante")
      End With
   End Sub
   Public Function GetVentasPirelli(sFechaDesde As Date, sFechaHasta As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)

         .AppendFormatLine(" WHERE TCOM.EsComercial =  1 ")
         .AppendFormatLine("   AND PROD.IdMarca = (SELECT ValorParametro FROM Parametros WHERE idParametro = 'VENTASPIRELLIIDMARCA')")
         .AppendFormatLine("   AND VTAS.Fecha BETWEEN '{0}' AND '{1}' ", ObtenerFecha(sFechaDesde, True), ObtenerFecha(sFechaHasta, True))
         .AppendLine(" GROUP BY CONVERT(DATE, VTAS.Fecha), PROD.IdProducto")
         .AppendLine(" ORDER BY CONVERT(DATE, VTAS.Fecha)")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
