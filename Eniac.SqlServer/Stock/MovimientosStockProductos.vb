Public Class MovimientosStockProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("       {0} ", Entidades.MovimientoStockProducto.Columnas.IdSucursal.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdDeposito.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdUbicacion.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdTipoMovimiento.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.NumeroMovimiento.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.Orden.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdLote.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.Cantidad.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.Cantidad2.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.Precio.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdaAtributoProducto01.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdaAtributoProducto02.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdaAtributoProducto03.ToString())
         .AppendFormatLine("      ,{0} ", Entidades.MovimientoStockProducto.Columnas.IdaAtributoProducto04.ToString())
         .AppendFormatLine("  FROM {0}", Entidades.MovimientoStockProducto.NombreTabla)
      End With
   End Sub

   Public Sub MovimientosStockProductos_I(idSucursal As Integer,
                                          idDeposito As Integer,
                                          idUbicacion As Integer,
                                          idTipoMovimiento As String,
                                          numeroMovimiento As Long,
                                          idProducto As String,
                                          cantidad As Decimal,
                                          cantidad2 As Decimal,
                                          precio As Decimal,
                                          idLote As String,
                                          vtoLote As Date?,
                                          orden As Integer,
                                          idaAtributo01 As Integer?,
                                          idaAtributo02 As Integer?,
                                          idaAtributo03 As Integer?,
                                          idaAtributo04 As Integer?,
                                          calidadNumero As String,
                                          linkDoc As String)

      Dim qry = New StringBuilder("")

      With qry
         .AppendFormatLine("INSERT INTO {0} (", Entidades.MovimientoStockProducto.NombreTabla.ToString())
         .AppendFormatLine("            {0}  ", Entidades.MovimientoStockProducto.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdDeposito.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdUbicacion.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdTipoMovimiento.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.NumeroMovimiento.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.Cantidad.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.Cantidad2.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.Precio.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdLote.ToString())
         .AppendFormatLine("           ,{0} ", Entidades.MovimientoStockProducto.Columnas.VtoLote.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.Orden.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdaAtributoProducto01.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdaAtributoProducto02.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdaAtributoProducto03.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.IdaAtributoProducto04.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.InformeCalidadNumero.ToString())
         .AppendFormatLine("           ,{0}  ", Entidades.MovimientoStockProducto.Columnas.InformeCalidadLink.ToString())
         '--------------------------------------------------
         .Append(")     VALUES(")
         '--------------------------------------------------
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           , {0} ", idDeposito)
         .AppendFormatLine("           , {0} ", idUbicacion)
         .AppendFormatLine("           ,'{0}'", idTipoMovimiento)
         .AppendFormatLine("           , {0} ", numeroMovimiento)
         .AppendFormatLine("           ,'{0}'", idProducto)
         .AppendFormatLine("           , {0} ", cantidad)
         .AppendFormatLine("           , {0} ", cantidad2)
         .AppendFormatLine("           , {0} ", precio)
         If String.IsNullOrEmpty(idLote) Then
            .AppendFormat("           , NULL")
            .AppendFormat("           , NULL")
         Else
            .AppendFormat("           ,'{0}'", idLote)
            .AppendFormat("           , {0} ", ObtenerFecha(vtoLote, True))
         End If
         .AppendFormatLine("           , {0} ", orden)
         '-- REQ-34747.- -----------------------------------
         If idaAtributo01 > 0 Then
            .AppendFormat("           ,{0}", idaAtributo01)
         Else
            .AppendLine("           ,NULL")
         End If
         If idaAtributo02 > 0 Then
            .AppendFormat("           ,{0}", idaAtributo02)
         Else
            .AppendLine("           ,NULL")
         End If
         If idaAtributo03 > 0 Then
            .AppendFormat("           ,{0}", idaAtributo03)
         Else
            .AppendLine("           ,NULL")
         End If
         If idaAtributo04 > 0 Then
            .AppendFormat("           ,{0}", idaAtributo04)
         Else
            .AppendLine("           ,NULL")
         End If
         '--------------------------------------------------
         If Not String.IsNullOrEmpty(calidadNumero) Then
            .AppendFormat("           ,'{0}'", calidadNumero)
         Else
            .AppendLine("           ,NULL")
         End If
         If Not String.IsNullOrEmpty(linkDoc) Then
            .AppendFormat("           ,'{0}'", linkDoc)
         Else
            .AppendLine("           ,NULL")
         End If
         '--------------------------------------------------
         .Append(")")
      End With
      Execute(qry.ToString())
   End Sub
   Public Sub MovimientosStockProductos_U(idSucursal As Integer,
                                          idDeposito As Integer,
                                          idUbicacion As Integer,
                                          idTipoMovimiento As String,
                                          numeroMovimiento As Long,
                                          idProducto As String,
                                          cantidad As Decimal,
                                          cantidad2 As Decimal,
                                          precio As Decimal,
                                          idLote As String,
                                          vtoLote As Date,
                                          orden As Integer,
                                          idaAtributo01 As Integer?,
                                          idaAtributo02 As Integer?,
                                          idaAtributo03 As Integer?,
                                          idaAtributo04 As Integer?)
      Dim qry = New StringBuilder("")
      With qry
         .AppendFormatLine("UPDATE {0} SET  ", Entidades.MovimientoStockProducto.NombreTabla.ToString())
         .AppendFormatLine("      ,{0} = {1}", Entidades.MovimientoStockProducto.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("      ,{0} = {1}", Entidades.MovimientoStockProducto.Columnas.Cantidad2.ToString(), cantidad)
         .AppendFormatLine("      ,{0} = {1}", Entidades.MovimientoStockProducto.Columnas.Precio.ToString(), precio)
         If String.IsNullOrEmpty(idLote) Then
            .AppendFormat("      ,{0} =  NULL", Entidades.MovimientoStockProducto.Columnas.IdLote.ToString())
            .AppendFormat("      ,{0} =  NULL", Entidades.MovimientoStockProducto.Columnas.VtoLote.ToString())
         Else
            .AppendFormat("      ,{0} = '{0}'", Entidades.MovimientoStockProducto.Columnas.IdLote.ToString(), idLote)
            .AppendFormat("      ,{0} = '{0}'", Entidades.MovimientoStockProducto.Columnas.VtoLote.ToString(), idLote)
         End If
         '------------------------------------------------------------------
         .Append(" WHERE ")
         '------------------------------------------------------------------
         .AppendFormat("       {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormat("   AND {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormat("   AND {0} = '{1}'", Entidades.MovimientoStockProducto.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormat("   AND {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
         .AppendFormat("   AND {0} = '{1}'", Entidades.MovimientoStockProducto.Columnas.IdProducto.ToString(), idProducto)
      End With
      Execute(qry.ToString())
   End Sub
   Public Sub MovimientosStockProductos_D(idSucursal As Integer,
                                          idDeposito As Integer,
                                          idUbicacion As Integer,
                                          idTipoMovimiento As String,
                                          numeroMovimiento As Long)
      Dim myQuery = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendFormatLine("DELETE FROM {0}  ", Entidades.MovimientoStockProducto.NombreTabla.ToString())
         '------------------------------------------------------------------
         .Append(" WHERE ")
         '------------------------------------------------------------------
         .AppendFormat("       {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdSucursal.ToString(), idSucursal)
         If idDeposito > 0 Then
            .AppendFormat("   AND {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdDeposito.ToString(), idDeposito)
         End If
         If idUbicacion > 0 Then
            .AppendFormat("   AND {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdUbicacion.ToString(), idUbicacion)
         End If
         .AppendFormat("   AND {0} = '{1}'", Entidades.MovimientoStockProducto.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormat("   AND {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      End With
      Execute(myQuery.ToString())
   End Sub
   Public Sub MovimientosStockProductos_DProd(idSucursal As Integer,
                                              idDeposito As Integer,
                                              idUbicacion As Integer,
                                              idProducto As String)
      Dim myQuery = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendFormatLine("DELETE FROM {0}  ", Entidades.MovimientoStockProducto.NombreTabla.ToString())
         '------------------------------------------------------------------
         .Append(" WHERE ")
         '------------------------------------------------------------------
         .AppendFormat("       {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormat("   AND {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdDeposito.ToString(), idDeposito)
         .AppendFormat("   AND {0} =  {1} ", Entidades.MovimientoStockProducto.Columnas.IdUbicacion.ToString(), idUbicacion)
         .AppendFormat("   AND {0} = '{1}'", Entidades.MovimientoStockProducto.Columnas.IdProducto.ToString(), idProducto)
      End With
      Execute(myQuery.ToString())
   End Sub

   Public Function GetUnoComprobanteProductos(idSucursal As Integer,
                                              idDeposito As Integer,
                                              idUbicacion As Integer,
                                              idTipoMovimiento As String,
                                              numeroMovimiento As Long) As DataTable
      Dim stb = New StringBuilder("")
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} =  {1}  ", Entidades.MovimientoStockProducto.Columnas.IdSucursal.ToString(), idSucursal)
         If idDeposito <> 0 Then
            .AppendFormatLine("  AND {0} =  {1}  ", Entidades.MovimientoStockProducto.Columnas.IdDeposito.ToString(), idDeposito)
         End If
         If idUbicacion <> 0 Then
            .AppendFormatLine("  AND {0} =  {1}  ", Entidades.MovimientoStockProducto.Columnas.IdUbicacion.ToString(), idUbicacion)
         End If
         .AppendFormatLine("   AND {0} = '{1}' ", Entidades.MovimientoStockProducto.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("   AND {0} =  {1}  ", Entidades.MovimientoStockProducto.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Function MovimientosStockProductos_GA() As DataTable
      Return MovimientosStockProductos_GA(idSucursal:=0, idDeposito:=0, idUbicacion:=0, idTipoMovimiento:=Nothing, numeroMovimiento:=0, orden:=0, idProducto:=Nothing)
   End Function
   Public Function MovimientosStockProductos_G1(IdSucursal As Integer,
                                                IdDeposito As Integer,
                                                IdUbicacion As Integer,
                                                IdTipoMovimiento As String,
                                                NumeroMovimiento As Long,
                                                orden As Integer,
                                                IdProducto As String) As DataTable
      Return MovimientosStockProductos_GA(IdSucursal, IdDeposito, IdUbicacion, IdTipoMovimiento, NumeroMovimiento, orden, IdProducto)
   End Function

   Public Function MovimientosStockProductos_GA(idSucursal As Integer,
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
      Return Me.GetDataTable(myQuery.ToString())
   End Function


End Class
