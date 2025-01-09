<Obsolete("Se reemplaza por MovimientosStockProductosNrosSerie", True)>
Public Class MovimientosComprasProductosNrosSerie
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosComprasProductosNrosSerie_I(idSucursal As Integer,
                                                    idTipoMovimiento As String,
                                                    numeroMovimiento As Long,
                                                    orden As Integer,
                                                    cantidad As Integer,
                                                    idProducto As String,
                                                    nroSerie As String)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("INSERT INTO MovimientosComprasProductosNrosSerie(")
         .AppendFormatLine("	IdSucursal,")
         .AppendFormatLine("	IdTipoMovimiento,")
         .AppendFormatLine("	NumeroMovimiento,")
         .AppendFormatLine("	Orden,")
         .AppendFormatLine("	Cantidad,")
         .AppendFormatLine("	IdProducto,")
         .AppendFormatLine("	NroSerie")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine(" {0}", idSucursal)
         .AppendFormatLine(" ,'{0}'", idTipoMovimiento)
         .AppendFormatLine(" ,{0}", numeroMovimiento)
         .AppendFormatLine(" ,{0}", orden)
         .AppendFormatLine(" ,{0}", cantidad)
         .AppendFormatLine(" ,'{0}'", idProducto)
         .AppendFormatLine(" ,'{0}'", nroSerie)
         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub MovimientosComprasProductosNrosSerie_U(idSucursal As Integer,
                                                    idTipoMovimiento As String,
                                                    numeroMovimiento As Long,
                                                    orden As Integer,
                                                    cantidad As Integer,
                                                    idProducto As String,
                                                    nroSerie As String)
      '##############################################################################################
      '# Al ser una tabla compuesta solo de PK no se podría actualizar ningún campo por el momento. #
      '##############################################################################################

      'Dim query As StringBuilder = New StringBuilder
      'With query
      '   .AppendFormatLine("UPDATE MovimientosComprasProductosNrosSerie SET")
      '   .AppendFormatLine("WHERE {0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
      '   .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoCompraProductoNroSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
      '   .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      '   .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.Orden.ToString(), orden)
      '   .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoCompraProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)
      'End With

      'Me.Execute(query.ToString())
   End Sub

   Public Sub MovimientosComprasProductosNrosSerie_D(idSucursal As Integer,
                                                    idTipoMovimiento As String,
                                                    numeroMovimiento As Long)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE MovimientosComprasProductosNrosSerie")
         .AppendFormatLine("WHERE {0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoCompraProductoNroSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function MovimientosComprasProductosNrosSerie_GA() As DataTable
      Return MovimientosComprasProductosNrosSerie_GA(idSucursal:=0, idTipoMovimiento:=Nothing, numeroMovimiento:=0, orden:=0, idProducto:=Nothing)
   End Function

   Public Function MovimientosComprasProductosNrosSerie_GA(idSucursal As Integer,
                                                           idTipoMovimiento As String,
                                                           numeroMovimiento As Long,
                                                           orden As Integer,
                                                           idProducto As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)

         '# Filtros
         .AppendFormatLine(" WHERE 1=1")
         If idSucursal > 0 Then
            .AppendFormatLine(" AND MCPNS.IdSucursal = {0}", idSucursal)
         End If
         If Not String.IsNullOrEmpty(idTipoMovimiento) Then
            .AppendFormatLine(" AND MCPNS.IdTipoMovimiento = '{0}'", idTipoMovimiento)
         End If
         If numeroMovimiento > 0 Then
            .AppendFormatLine(" AND MCPNS.NumeroMovimiento = {0}", numeroMovimiento)
         End If
         If orden > 0 Then
            .AppendFormatLine(" AND MCPNS.Orden = {0}", orden)
         End If
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine(" AND MCPNS.IdProducto = '{0}'", idProducto)
         End If
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function MovimientosComprasProductosNrosSerie_G1(idSucursal As Integer,
                                                          idTipoMovimiento As String,
                                                          numeroMovimiento As Long,
                                                          orden As Integer,
                                                          cantidad As Integer,
                                                          idProducto As String,
                                                          nroSerie As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE MCPNS.{0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND MCPNS.{0} = '{1}'", Entidades.MovimientoCompraProductoNroSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND MCPNS.{0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
         .AppendFormatLine("	AND MCPNS.{0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("	AND MCPNS.{0} = '{1}'", Entidades.MovimientoCompraProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)

         If Not String.IsNullOrEmpty(nroSerie) Then
            .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoCompraProductoNroSerie.Columnas.NroSerie.ToString(), nroSerie)
         End If
         If cantidad > 0 Then
            .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoCompraProductoNroSerie.Columnas.Cantidad.ToString(), cantidad)
         End If
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT")
         .AppendFormatLine("	 MCPNS.IdSucursal")
         .AppendFormatLine("	,MCPNS.IdTipoMovimiento")
         .AppendFormatLine("	,MCPNS.NumeroMovimiento")
         .AppendFormatLine("	,MCPNS.Orden")
         .AppendFormatLine("	,MCPNS.Cantidad")
         .AppendFormatLine("	,MCPNS.IdProducto")
         .AppendFormatLine("	,MCPNS.NroSerie")
         .AppendFormatLine("FROM MovimientosComprasProductosNrosSerie MCPNS")
      End With
   End Sub
End Class
