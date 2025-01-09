Public Class MovimientosStockProductosLotes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT")
         .AppendFormatLine("	 MSPL.*")
         .AppendFormatLine("	,PROD.NombreProducto")
         .AppendFormatLine("	,PROL.FechaVencimiento")
         .AppendFormatLine(" FROM {0} MSPL ", Entidades.MovimientoStockProductoLotes.NombreTabla)
         .AppendFormatLine("	LEFT JOIN Productos PROD ON PROD.IdProducto = MSPL.IdProducto")
         .AppendFormatLine("	LEFT JOIN ProductosLotes PROL ON PROL.IdSucursal = MSPL.IdSucursal AND PROL.IdProducto = MSPL.IdProducto AND PROL.IdLote = MSPL.IdLote")
      End With
   End Sub

   Public Sub MovimientosStockProductosLotes_I(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                               idTipoMovimiento As String, numeroMovimiento As Long, orden As Integer,
                                               idProducto As String, idLote As String,
                                               cantidad As Decimal, cantidad2 As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.MovimientoStockProductoLotes.NombreTabla)
         .AppendFormatLine("            {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.IdSucursal.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.IdDeposito.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.IdUbicacion.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.IdTipoMovimiento.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.NumeroMovimiento.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.Orden.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.IdProducto.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.IdLote.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.Cantidad.ToString())
         .AppendFormatLine("          , {0}  ", Entidades.MovimientoStockProductoLotes.Columnas.Cantidad2.ToString())
         '------------------------------------------------------------------------------
         .AppendLine("  ) VALUES ( ")
         '------------------------------------------------------------------------------
         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          , {0} ", idDeposito)
         .AppendFormatLine("          , {0} ", idUbicacion)
         .AppendFormatLine("          ,'{0}'", idTipoMovimiento)
         .AppendFormatLine("          , {0} ", numeroMovimiento)
         .AppendFormatLine("          , {0} ", orden)
         .AppendFormatLine("          ,'{0}'", idProducto)
         .AppendFormatLine("          ,'{0}'", idLote)
         .AppendFormatLine("          , {0} ", cantidad)
         .AppendFormatLine("          , {0} ", cantidad2)
         '------------------------------------------------------------------------------
         .AppendLine("  ) ")
      End With
      Execute(myQuery)
   End Sub

   Public Sub MovimientosStockProductosLotes_U(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                               idTipoMovimiento As String, numeroMovimiento As Long, orden As Integer,
                                               idProducto As String, idLote As String,
                                               cantidad As Decimal, cantidad2 As Decimal)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0} SET ", Entidades.MovimientoStockProductoLotes.NombreTabla)
         .AppendFormatLine("	{0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdLote.ToString(), idLote)
         .AppendFormatLine(" ,{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine(" ,{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.Cantidad2.ToString(), cantidad2)
         .AppendFormatLine("WHERE    {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND    {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("	AND    {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("	AND    {0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND    {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
         .AppendFormatLine("	AND    {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("	AND    {0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdProducto.ToString(), idProducto)
      End With
      Execute(query)
   End Sub

   Public Sub MovimientosStockProductosLotes_D(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                               idTipoMovimiento As String, numeroMovimiento As Long)
      Dim myQuery = New StringBuilder
      With myQuery
         .AppendFormatLine("DELETE {0}         ", Entidades.MovimientoStockProductoLotes.NombreTabla)
         .AppendFormatLine("  WHERE {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	  AND {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("	  AND {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("	  AND {0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	  AND {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      End With
      Execute(myQuery)
   End Sub

   Public Sub MovimientosStockProductosLotes_DProd(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.MovimientoStockProductoLotes.NombreTabla)
         .AppendFormatLine("  WHERE {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	  AND {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("	  AND {0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("	  AND {0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdProducto.ToString(), idProducto)
      End With
      Execute(myQuery)
   End Sub

   Public Function MovimientosStockProductosLotes_GA() As DataTable
      Return MovimientosStockProductosLotes_GA(idSucursal:=0, idDeposito:=0, idUbicacion:=0, idTipoMovimiento:=Nothing, numeroMovimiento:=0, orden:=0, idProducto:=Nothing)
   End Function

   Public Function MovimientosStockProductosLotes_GA(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                                     idTipoMovimiento As String, numeroMovimiento As Long,
                                                     orden As Integer, idProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         '-- Filtros.- ---------------------------------------------------------------
         .AppendFormatLine(" WHERE 1=1")
         If idSucursal > 0 Then
            .AppendFormatLine(" AND MSPL.IdSucursal = {0}", idSucursal)
         End If
         If idDeposito > 0 Then
            .AppendFormatLine(" AND MSPL.IdDeposito = {0}", idDeposito)
         End If
         If idUbicacion > 0 Then
            .AppendFormatLine(" AND MSPL.IdUbicacion = {0}", idUbicacion)
         End If
         If Not String.IsNullOrEmpty(idTipoMovimiento) Then
            .AppendFormatLine(" AND MSPL.IdTipoMovimiento = '{0}'", idTipoMovimiento)
         End If
         If numeroMovimiento > 0 Then
            .AppendFormatLine(" AND MSPL.NumeroMovimiento = {0}", numeroMovimiento)
         End If
         If orden > 0 Then
            .AppendFormatLine(" AND MSPL.Orden = {0}", orden)
         End If
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine(" AND MSPL.IdProducto = '{0}'", idProducto)
         End If
         '----------------------------------------------------------------------------
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function GetPorMovimientoStock(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                         idTipoMovimiento As String, numeroMovimiento As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine("WHERE    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("	AND    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("	AND    MSPL.{0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function MovimientosStockProductosLotes_G1(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                                     idTipoMovimiento As String, numeroMovimiento As Long, orden As Long,
                                                     idProducto As String, idLote As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine("WHERE    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormatLine("	AND    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormatLine("	AND    MSPL.{0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
         .AppendFormatLine("	AND    MSPL.{0} =  {1} ", Entidades.MovimientoStockProductoLotes.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("	AND    MSPL.{0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("	AND    MSPL.{0} = '{1}'", Entidades.MovimientoStockProductoLotes.Columnas.IdLote.ToString(), idLote)
      End With
      Return GetDataTable(stb)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "MSPL.")
   End Function
End Class