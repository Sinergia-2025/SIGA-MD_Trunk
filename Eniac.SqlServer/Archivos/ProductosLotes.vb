Public Class ProductosLotes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function ProductosLotes_G1(idProducto As String, idLote As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE PL.IdProducto  = '{0}'", idProducto)
         .AppendFormat("   AND PL.IdLote      = '{0}'", idLote)
         .AppendFormat("   AND PL.IdSucursal  =  {0} ", idSucursal)
         .AppendFormat("   AND PL.IdDeposito  =  {0} ", idDeposito)
         .AppendFormat("   AND PL.IdUbicacion =  {0} ", idUbicacion)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetFiltradoPorId(idLote As String, idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat("WHERE PL.IdLote LIKE '%{0}%'", idLote)
         .AppendFormat("  AND PL.IdSucursal = {0}", idSucursal)
         .AppendFormat("  AND PL.Habilitado = 1")
         .AppendFormat(" ORDER BY PL.IdLote, PL.IdProducto, PL.FechaVencimiento")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetLoteMasViejoADescontar(idProducto As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT TOP(1) *")
         .AppendFormatLine("  FROM ProductosLotes ")
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdDeposito = {0}", idDeposito)
         .AppendFormatLine("   AND IdUbicacion = {0}", idUbicacion)
         .AppendFormatLine("   AND CantidadActual > 0")
         .AppendFormatLine("   AND Habilitado = 'True'")
         .AppendFormatLine(" ORDER BY FechaVencimiento ASC, FechaIngreso ASC")
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PL.")
   End Function

   Public Sub ProductosLotes_I(idLote As String, idProducto As String,
                               idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                               fechaIngreso As Date, fechaVencimiento As Date?,
                               cantidadInicial As Decimal, cantidadActual As Decimal,
                               habilitado As Boolean,
                               precioCosto As Decimal)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("INSERT INTO ProductosLotes (")
         .AppendFormatLine("     IdLote")
         .AppendFormatLine("   , IdProducto")
         .AppendFormatLine("   , IdSucursal")
         .AppendFormatLine("   , IdDeposito")
         .AppendFormatLine("   , IdUbicacion")
         .AppendFormatLine("   , FechaIngreso")
         .AppendFormatLine("   , FechaVencimiento")
         .AppendFormatLine("   , CantidadInicial")
         .AppendFormatLine("   , CantidadActual")
         .AppendFormatLine("   , Habilitado")
         .AppendFormatLine("   , PrecioCosto")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("     '{0}'", idLote)
         .AppendFormatLine("   , '{0}'", idProducto)
         .AppendFormatLine("   ,  {0} ", idSucursal)
         .AppendFormatLine("   ,  {0} ", idDeposito)
         .AppendFormatLine("   ,  {0} ", idUbicacion)
         .AppendFormatLine("   , '{0}'", fechaIngreso.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormatLine("   ,  {0} ", ObtenerFecha(fechaVencimiento, True))   'Es Nullable, las comillas se las pone ObtenerFecha
         .AppendFormatLine("   ,  {0} ", cantidadInicial)
         .AppendFormatLine("   ,  {0} ", cantidadActual)
         .AppendFormatLine("   ,  {0} ", GetStringFromBoolean(habilitado))
         .AppendFormatLine("   ,  {0} ", precioCosto)
         .AppendFormatLine(" )")
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosLotes")
   End Sub

   Public Sub ProductosLotes_U(idLote As String, idProducto As String,
                               idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                               fechaIngreso As Date, fechaVencimiento As Date?,
                               cantidadInicial As Decimal, cantidadActual As Decimal,
                               habilitado As Boolean,
                               precioCosto As Decimal)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosLotes")
         .AppendFormatLine("   SET FechaIngreso = '{0}'", ObtenerFecha(fechaIngreso, True))
         .AppendFormatLine("     , FechaVencimiento = {0}", ObtenerFecha(fechaVencimiento, True))  'Es Nullable, las comillas se las pone ObtenerFecha
         .AppendFormatLine("     , CantidadInicial = {0}", cantidadInicial)
         .AppendFormatLine("     , CantidadActual = {0}", cantidadActual)
         .AppendFormatLine("     , Habilitado = {0}", GetStringFromBoolean(habilitado))
         .AppendFormatLine("     , PrecioCosto = {0}", precioCosto)
         .AppendFormatLine(" WHERE IdLote = '{0}'", idLote)
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdDeposito = {0}", idDeposito)
         .AppendFormatLine("   AND IdUbicacion = {0}", idUbicacion)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosLotes")
   End Sub

   Public Sub ProductosLotes_UCantidadActual(idLote As String, idProducto As String,
                                             idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer,
                                             cantidadActual As Decimal)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosLotes")
         .AppendFormatLine("   SET CantidadActual = {0}", cantidadActual)
         .AppendFormatLine(" WHERE IdLote       = '{0}'", idLote)
         .AppendFormatLine("   AND IdProducto   = '{0}'", idProducto)
         .AppendFormatLine("   AND IdSucursal   = {0}", idSucursal)
         .AppendFormatLine("   AND IdDeposito   = {0}", idDeposito)
         .AppendFormatLine("   AND IdUbicacion  = {0}", idUbicacion)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosLotes")
   End Sub

   Public Sub ProductosLotes_UCantidadActual_Delta(idLote As String, idSucursal As Integer, idProducto As String, cantidad As Decimal)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosLotes")
         .AppendFormatLine("   SET CantidadActual = CantidadActual + {0}", cantidad)
         .AppendFormatLine(" WHERE IdLote = '{0}'", idLote)
         .AppendFormatLine("   AND IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosLotes")
   End Sub

   Public Sub ProductosLotes_D(idProducto As String, idLote As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer)
      Dim qry = New StringBuilder()
      With qry
         .Append("DELETE FROM ProductosLotes ")
         .AppendFormat(" WHERE IdLote      = '{0}'", idLote)
         .AppendFormat("   AND IdProducto  = '{0}'", idProducto)
         .AppendFormat("   AND IdSucursal  = {0}", idSucursal)
         .AppendFormat("   AND IdDeposito  = {0}", idDeposito)
         .AppendFormat("   AND IdUbicacion = {0}", idUbicacion)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosLotes")
   End Sub

   Public Sub ProductosLotes_DProd(IdSucursal As Integer, IdProducto As String)
      Dim qry = New StringBuilder()
      With qry
         .Append("DELETE FROM ProductosLotes ")
         .AppendFormat(" WHERE IdSucursal = {0}", IdSucursal)
         .AppendFormat("   AND IdProducto = '{0}'", IdProducto)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosLotes")
   End Sub

   Public Sub ProductosLotes_IFaltante(idProducto As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ProductosLotes (")
         .AppendLine("            IdLote")
         .AppendLine("           ,IdSucursal")
         .AppendLine("           ,IdProducto")
         .AppendLine("           ,FechaIngreso")
         .AppendLine("           ,FechaVencimiento")
         .AppendLine("           ,CantidadInicial")
         .AppendLine("           ,CantidadActual")
         .AppendLine("           ,Habilitado")
         .AppendLine("           ,PrecioCosto)")
         .AppendLine("SELECT 'AUTOMATICO' AS IdLote")
         .AppendLine("      ,PS.IdSucursal")
         .AppendLine("      ,PS.IdProducto")
         .AppendLine("      ,GETDATE() AS FecAlta")
         .AppendLine("      ,GETDATE() AS FecVencimiento")
         .AppendLine("      ,PS.Stock - (CASE WHEN Lotes.StockLote IS NULL THEN 0 ELSE Lotes.StockLote END) AS CantInicial")
         .AppendLine("      ,PS.Stock - (CASE WHEN Lotes.StockLote IS NULL THEN 0 ELSE Lotes.StockLote END) AS CantActual")
         .AppendLine("      ,'True' AS Habilitado")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("  FROM ProductosSucursales PS")
         .AppendLine("  LEFT JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendLine("  LEFT JOIN (SELECT PL.IdSucursal, PL.IdProducto, SUM(PL.CantidadActual) AS StockLote")
         .AppendLine("               FROM ProductosLotes AS PL")
         .AppendLine("           GROUP BY PL.IdSucursal, PL.IdProducto")
         .AppendLine("             ) Lotes ON Lotes.IdProducto = PS.IdProducto AND Lotes.IdSucursal = PS.IdSucursal")

         .AppendLine("  WHERE PS.IdSucursal IN (SELECT ID FROM Sucursales WHERE SoyLaCentral = 'True' OR IdSucursalAsociada IS NULL)")
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine(" AND PS.IdProducto = '" & idProducto & "'")
         End If
         '.AppendLine("AND P.Activo = 'True'
         '.AppendLine("AND P.AfectaStock = 'True'

         .AppendLine("    AND PS.Stock - (CASE WHEN Lotes.StockLote IS NULL THEN 0 ELSE Lotes.StockLote END) >0")
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "ProductosLotes")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT PL.*")
         .AppendLine("     , P.NombreProducto")
         .AppendLine("  FROM ProductosLotes PL")
         .AppendLine("  LEFT JOIN Productos P ON P.IdProducto = PL.IdProducto")
      End With
   End Sub

   Public Function ProductosLotes_GA() As DataTable
      Dim qry = New StringBuilder()
      With qry
         SelectTexto(qry)
      End With
      Return GetDataTable(qry)
   End Function

   Public Function GetPorProducto(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, parteIdLote As String, validarStock As Boolean) As DataTable
      Dim qry = New StringBuilder()
      With qry
         SelectTexto(qry)
         .AppendFormatLine(" WHERE PL.IdSucursal = {0}", idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("   AND PL.IdDeposito = {0}", idDeposito)
         End If
         If idUbicacion <> 0 Then
            .AppendFormatLine("   AND PL.IdUbicacion = {0}", idUbicacion)
         End If
         .AppendFormatLine("   AND PL.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND PL.Habilitado = 'True'")
         If validarStock Then
            .AppendFormatLine("   AND PL.CantidadActual > 0")
         End If
         If Not String.IsNullOrEmpty(parteIdLote) Then
            .AppendFormatLine("   AND PL.IdLote LIKE '%{0}%'", parteIdLote)
         End If
      End With
      Return GetDataTable(qry)
   End Function

   Public Sub LimpiarLote(idProducto As String, idLote As String, idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("UPDATE ProductosLotes")
         .AppendFormatLine("   SET CantidadActual = 0")
         .AppendFormatLine("     , CantidadInicial = 0")
         .AppendFormatLine(" WHERE IdLote       = '{0}'", idLote)
         .AppendFormatLine("   AND IdSucursal   =  {0} ", idSucursal)
         .AppendFormatLine("   AND IdProducto   = '{0}'", idProducto)
         .AppendFormatLine("   AND IdDeposito   =  {0} ", idDeposito)
         .AppendFormatLine("   AND IdUbicacion  =  {0} ", idUbicacion)
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProductosLotes")
   End Sub

   Public Function GetStockLote(idSucursal As Integer, idDeposito As Integer, idUbicacion As Integer, idProducto As String, idLote As String) As Decimal
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT PL.CantidadActual FROM ProductosLotes PL")
         .AppendFormatLine("  WHERE PL.IdSucursal = {0} AND PL.IdProducto = '{1}' AND PL.IdLote = '{2}'", idSucursal, idProducto, idLote)
         .AppendFormatLine("    AND PL.IdDeposito = {0} AND PL.IdUbicacion = {1}", idDeposito, idUbicacion)
      End With
      Return GetDataTable(query).Rows(0).Field(Of Decimal?)("CantidadActual").IfNull()
   End Function

End Class