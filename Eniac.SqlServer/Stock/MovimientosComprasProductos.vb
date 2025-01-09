<Obsolete("Se reemplaza por MovimientosStockProductos", True)>
Public Class MovimientosComprasProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosComprasProductos_I(idSucursal As Integer,
                                            idTipoMovimiento As String,
                                            numeroMovimiento As Long,
                                            orden As Integer,
                                            idProducto As String,
                                            cantidad As Decimal,
                                            precio As Decimal,
                                            idLote As String,
                                            cantidadReservado As Decimal,
                                            cantidadDefectuoso As Decimal,
                                            cantidadFuturo As Decimal,
                                            cantidadFuturoReservado As Decimal,
                                            idaAtributo01 As Integer?,
                                            idaAtributo02 As Integer?,
                                            idaAtributo03 As Integer?,
                                            idaAtributo04 As Integer?)

      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO MovimientosComprasProductos (")
         .Append("           IdSucursal")
         .Append("           ,IdTipoMovimiento")
         .Append("           ,NumeroMovimiento")
         .Append("           ,Orden")
         .Append("           ,IdProducto")
         .Append("           ,Cantidad")
         .Append("           ,Precio")
         .Append("           ,IdLote")
         .Append("           ,CantidadReservado")
         .Append("           ,CantidadDefectuoso")
         .Append("           ,CantidadFuturo")
         .Append("           ,CantidadFuturoReservado")
         '-- REQ-34747.- -----------------------------------
         .Append("           ,IdaAtributoProducto01")
         .Append("           ,IdaAtributoProducto02")
         .Append("           ,IdaAtributoProducto03")
         .Append("           ,IdaAtributoProducto04")
         '--------------------------------------------------
         .Append(")     VALUES(")
         .AppendFormat("           {0}", idSucursal)
         .AppendFormat("           ,'{0}'", idTipoMovimiento)
         .AppendFormat("           ,{0}", numeroMovimiento)
         .AppendFormat("           ,{0}", orden)
         .AppendFormat("           ,'{0}'", idProducto)
         .AppendFormat("           ,{0}", cantidad)
         .AppendFormat("           ,{0}", precio)
         If String.IsNullOrEmpty(idLote) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", idLote)
         End If
         .AppendFormat("           ,{0}", cantidadReservado)
         .AppendFormat("           ,{0}", cantidadDefectuoso)
         .AppendFormat("           ,{0}", cantidadFuturo)
         .AppendFormat("           ,{0}", cantidadFuturoReservado)
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

         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "MovimientosComprasProductos")

   End Sub

   Public Sub MovimientosComprasProductos_U(idSucursal As Integer,
                                            idTipoMovimiento As String,
                                            numeroMovimiento As Long,
                                            idProducto As String,
                                            cantidad As Decimal,
                                            precio As Decimal,
                                            idLote As String,
                                            cantidadReservado As Decimal,
                                            cantidadDefectuoso As Decimal,
                                            cantidadFuturo As Decimal,
                                            cantidadFuturoReservado As Decimal)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE MovimientosComprasProductos SET ")
         .AppendFormat("      IdSucursal = {0}", idSucursal)
         .AppendFormat("      ,IdTipoMovimiento = '{0}'", idTipoMovimiento)
         .AppendFormat("      ,NumeroMovimiento = {0}", numeroMovimiento)
         .AppendFormat("      ,IdProducto = '{0}'", idProducto)
         .AppendFormat("      ,Cantidad = {0}", cantidad)
         .AppendFormat("      ,Precio = {0}", precio)
         If String.IsNullOrEmpty(idLote) Then
            .AppendFormat("      ,IdLote = null")
         Else
            .AppendFormat("      ,IdLote = '{0}'", idLote)
         End If
         .AppendFormat("      ,CantidadReservado = {0}", cantidadReservado)
         .AppendFormat("      ,CantidadDefectuoso = {0}", cantidadDefectuoso)
         .AppendFormat("      ,CantidadFuturo = {0}", cantidadFuturo)
         .AppendFormat("      ,CantidadFuturoReservado = {0}", cantidadFuturoReservado)
         .Append(" WHERE ")
         .AppendFormat("      IdSucursal = {0}", idSucursal)
         .AppendFormat("      ,IdTipoMovimiento = '{0}'", idTipoMovimiento)
         .AppendFormat("      ,NumeroMovimiento = {0}", numeroMovimiento)
         .AppendFormat("      ,IdProducto = '{0}'", idProducto)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "MovimientosComprasProductos")
   End Sub

   Public Sub EliminarPorComprobante(idSucursal As Integer,
                                     idTipoMovimiento As String,
                                     numeroMovimiento As Long)
      Dim qry As StringBuilder = New StringBuilder()
      With qry
         .Append("DELETE FROM MovimientosComprasProductos WHERE ")
         .AppendFormat("      IdSucursal = {0}", idSucursal)
         .AppendFormat("      AND IdTipoMovimiento = '{0}'", idTipoMovimiento)
         .AppendFormat("      AND NumeroMovimiento = {0}", numeroMovimiento)
      End With
      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "MovimientosComprasProductos")
   End Sub

   Public Sub EliminarPorProduccion(ByVal IdSucursal As Integer,
                                            ByVal IdTipoMovimiento As String,
                                            ByVal NumeroMovimiento As Long)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM MovimientosComprasProductos WHERE ")
         .AppendFormat("      IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      AND NumeroMovimiento = {0}", NumeroMovimiento)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "MovimientosComprasProductos")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT MCP.*")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("  FROM MovimientosComprasProductos MCP")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = MCP.IdProducto")
      End With
   End Sub

   Public Sub MovimientosComprasProductos_DProd(ByVal idSucursal As Integer,
                                                ByVal idProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM MovimientosComprasProductos ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "MovimientosComprasProductos")

   End Sub

   Public Function MovimientosComprasProductos_GA(idSucursal As Integer, idTipoMovimiento As String, numeroMovimiento As Long) As DataTable
      Return MovimientosComprasProductos_G(idSucursal, idTipoMovimiento, numeroMovimiento)
   End Function

   Private Function MovimientosComprasProductos_G(idSucursal As Integer, idTipoMovimiento As String, numeroMovimiento As Long) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormat("   AND MCP.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoMovimiento) Then
            .AppendFormat("   AND MCP.IdTipoMovimiento = '{0}'", idTipoMovimiento).AppendLine()
         End If
         If numeroMovimiento <> 0 Then
            .AppendFormat("   AND MCP.NumeroMovimiento = {0}", numeroMovimiento).AppendLine()
         End If
         .AppendLine(" ORDER BY MCP.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class