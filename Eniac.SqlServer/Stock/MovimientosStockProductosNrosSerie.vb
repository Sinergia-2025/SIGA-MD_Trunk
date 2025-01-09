Public Class MovimientosStockProductosNrosSerie
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT")
         .AppendFormatLine("	 MSPNS.IdSucursal")
         .AppendFormatLine("	,MSPNS.IdDeposito")
         .AppendFormatLine("	,MSPNS.IdUbicacion")
         .AppendFormatLine("	,MSPNS.IdTipoMovimiento")
         .AppendFormatLine("	,MSPNS.NumeroMovimiento")
         .AppendFormatLine("	,MSPNS.Orden")
         .AppendFormatLine("	,MSPNS.IdProducto")
         .AppendFormatLine("	,MSPNS.NroSerie")
         .AppendFormatLine("	,MSPNS.Cantidad")
         .AppendFormatLine("	,MSPNS.Cantidad2")
         .AppendFormatLine(" FROM {0} MSPNS", Entidades.MovimientoStockProductoNrosSerie.NombreTabla)
      End With
   End Sub

   Public Sub MovimientosStockProductosNrosSerie_I(idSucursal As Integer,
                                                   idDeposito As Integer,
                                                   idUbicacion As Integer,
                                                   idTipoMovimiento As String,
                                                   numeroMovimiento As Long,
                                                   orden As Integer,
                                                   idProducto As String,
                                                   nroSerie As String,
                                                   cantidad As Decimal,
                                                   cantidad2 As Decimal)
      Dim myQuery = New StringBuilder
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.MovimientoStockProductoNrosSerie.NombreTabla)
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdSucursal.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdDeposito.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdUbicacion.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdTipoMovimiento.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.NumeroMovimiento.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.Orden.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdProducto.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.NroSerie.ToString())
         .AppendFormatLine("            {0}, ", Entidades.MovimientoStockProductoNrosSerie.Columnas.Cantidad.ToString())
         .AppendFormatLine("            {0}  ", Entidades.MovimientoStockProductoNrosSerie.Columnas.Cantidad2.ToString())
         '------------------------------------------------------------------------------
         .AppendLine("  ) VALUES ( ")
         '------------------------------------------------------------------------------
         .AppendFormatLine("            {0} ,", idSucursal)
         .AppendFormatLine("            {0} ,", idDeposito)
         .AppendFormatLine("            {0} ,", idUbicacion)
         .AppendFormatLine("           '{0}',", idTipoMovimiento)
         .AppendFormatLine("            {0} ,", numeroMovimiento)
         .AppendFormatLine("            {0} ,", orden)
         .AppendFormatLine("           '{0}',", idProducto)
         .AppendFormatLine("           '{0}',", nroSerie)
         .AppendFormatLine("            {0} ,", cantidad)
         .AppendFormatLine("            {0}  ", cantidad2)
         '------------------------------------------------------------------------------
         .AppendLine("  ) ")
      End With
      Execute(myQuery.ToString())
   End Sub

   Public Sub MovimientosStockProductosNrosSerie_U(idSucursal As Integer,
                                                   idDeposito As Integer,
                                                   idUbicacion As Integer,
                                                   idTipoMovimiento As String,
                                                   numeroMovimiento As Long,
                                                   orden As Integer,
                                                   idProducto As String,
                                                   nroSerie As String,
                                                   cantidad As Decimal,
                                                   cantidad2 As Decimal)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE {0} SET ", Entidades.MovimientoStockProductoNrosSerie.NombreTabla)
         .AppendFormatLine("	{0} = '{1}'", Entidades.MovimientoStockProductoNrosSerie.Columnas.NroSerie.ToString(), nroSerie)
         .AppendFormatLine(" ,{0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine(" ,{0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.Cantidad2.ToString(), cantidad2)
         .AppendFormatLine("WHERE    {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND    {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("	AND    {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("	AND    {0} = '{1}'", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND    {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
         .AppendFormatLine("	AND    {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("	AND    {0} = '{1}'", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdProducto.ToString(), idProducto)
      End With
      Execute(query.ToString())
   End Sub

   Public Sub MovimientosStockProductosNrosSerie_D(idSucursal As Integer,
                                                   idDeposito As Integer,
                                                   idUbicacion As Integer,
                                                   idTipoMovimiento As String,
                                                   numeroMovimiento As Long)

      Dim myQuery = New StringBuilder
      With myQuery
         .AppendFormatLine("DELETE {0}         ", Entidades.MovimientoStockProductoNrosSerie.NombreTabla)
         .AppendFormatLine("  WHERE {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdSucursal.ToString(), idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("	  AND {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdDeposito.ToString(), idDeposito)
         End If
         If idUbicacion <> 0 Then
            .AppendFormatLine("	  AND {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdUbicacion.ToString(), idUbicacion)
         End If
         .AppendFormatLine("	  AND {0} = '{1}'", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	  AND {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      End With

      Execute(myQuery.ToString())
   End Sub

   Public Function MovimientosStockProductosNrosSerie_GA() As DataTable
      Return MovimientosStockProductosNrosSerie_GA(idSucursal:=0, idDeposito:=0, idUbicacion:=0, idTipoMovimiento:=Nothing, numeroMovimiento:=0, orden:=0, idProducto:=Nothing)
   End Function

   Public Function MovimientosStockProductosNrosSerie_GA(idSucursal As Integer,
                                                         idDeposito As Integer,
                                                         idUbicacion As Integer,
                                                         idTipoMovimiento As String,
                                                         numeroMovimiento As Long,
                                                         orden As Integer,
                                                         idProducto As String) As DataTable
      Dim myQuery = New StringBuilder
      With myQuery
         SelectTexto(myQuery)
         '-- Filtros.- ---------------------------------------------------------------
         .AppendFormatLine(" WHERE 1=1")
         If idSucursal > 0 Then
            .AppendFormatLine(" AND MSPNS.IdSucursal = {0}", idSucursal)
         End If
         If idDeposito > 0 Then
            .AppendFormatLine(" AND MSPNS.IdDeposito = {0}", idDeposito)
         End If
         If idUbicacion > 0 Then
            .AppendFormatLine(" AND MSPNS.IdUbicacion = {0}", idUbicacion)
         End If
         If Not String.IsNullOrEmpty(idTipoMovimiento) Then
            .AppendFormatLine(" AND MSPNS.IdTipoMovimiento = '{0}'", idTipoMovimiento)
         End If
         If numeroMovimiento > 0 Then
            .AppendFormatLine(" AND MSPNS.NumeroMovimiento = {0}", numeroMovimiento)
         End If
         If orden > 0 Then
            .AppendFormatLine(" AND MSPNS.Orden = {0}", orden)
         End If
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine(" AND MSPNS.IdProducto = '{0}'", idProducto)
         End If
         '----------------------------------------------------------------------------
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function MovimientosStockProductosNrosSerie_G1(idSucursal As Integer,
                                                         idDeposito As Integer,
                                                         idUbicacion As Integer,
                                                         idTipoMovimiento As String,
                                                         numeroMovimiento As Long,
                                                         orden As Integer,
                                                         idProducto As String,
                                                         nroSerie As String) As DataTable
      Dim myQuery = New StringBuilder
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine("WHERE MCPNS.{0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND MCPNS.{0} = '{1}'", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND MCPNS.{0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
         .AppendFormatLine("	AND MCPNS.{0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("	AND MCPNS.{0} = '{1}'", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdProducto.ToString(), idProducto)

         If Not String.IsNullOrEmpty(nroSerie) Then
            .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoStockProductoNrosSerie.Columnas.NroSerie.ToString(), nroSerie)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetUltimoNumeroDeMovimiento(idSucursal As Integer,
                                               idDeposito As Integer,
                                               idUbicacion As Integer,
                                               idTipoMovimiento As String) As Integer
      Dim myQuery = New StringBuilder
      With myQuery
         .AppendFormatLine("SELECT MAX({0}) AS Numero FROM {1}", Entidades.MovimientoStockProductoNrosSerie.Columnas.NumeroMovimiento.ToString(),
                                                                 Entidades.MovimientoStockProductoNrosSerie.NombreTabla)
         .AppendFormatLine("	    WHERE {0} = '{1}'", Entidades.MovimientoStockProductoNrosSerie.Columnas.NumeroMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	      AND {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	      AND {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("	      AND {0} =  {1} ", Entidades.MovimientoStockProductoNrosSerie.Columnas.IdUbicacion.ToString(), idUbicacion)
      End With

      Dim dt = GetDataTable(myQuery.ToString())

      If (dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0)("Numero"))) Then
         Return Int32.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 0
      End If
      Me.GetDataTable(myQuery.ToString())
   End Function

End Class
