<Obsolete("Se reemplaza por MovimientosStockProductosLotes", True)>
Public Class MovimientosVentasProductosLotes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosVentasProductosLotes_I(ByVal IdSucursal As Integer,
                                              ByVal IdTipoMovimiento As String,
                                              ByVal NumeroMovimiento As Long,
                                              ByVal Orden As Long,
                                              ByVal IdProducto As String,
                                              ByVal IdLote As String,
                                              ByVal Cantidad As Decimal)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO MovimientosVentasProductosLotes (")
         .Append("           IdSucursal")
         .Append("           ,IdTipoMovimiento")
         .Append("           ,NumeroMovimiento")
         .Append("           ,Orden")
         .Append("           ,IdProducto")
         .Append("           ,IdLote")
         .Append("           ,Cantidad")
         .Append(")     VALUES(")
         .AppendFormat("           {0}", IdSucursal)
         .AppendFormat("           ,'{0}'", IdTipoMovimiento)
         .AppendFormat("           ,{0}", NumeroMovimiento)
         .AppendFormat("           ,{0}", Orden)
         .AppendFormat("           ,'{0}'", IdProducto)
         .AppendFormat("           ,'{0}'", IdLote)
         .AppendFormat("           ,{0}", Cantidad)
         .Append(")")
      End With

      Me.Execute(qry.ToString())
   End Sub

   Public Sub MovimientosVentasProductosLotes_U(ByVal IdSucursal As Integer,
                                                   ByVal IdTipoMovimiento As String,
                                                   ByVal NumeroMovimiento As Long,
                                                   ByVal Orden As Long,
                                                   ByVal IdProducto As String,
                                                   ByVal IdLote As String,
                                                   ByVal Cantidad As Decimal)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE MovimientosVentasProductosLotes SET ")
         .AppendFormat("      ,IdSucursal = {0}", IdSucursal)
         .AppendFormat("      ,IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      ,NumeroMovimiento = {0}", NumeroMovimiento)
         .AppendFormat("      ,Orden = {0}", Orden)
         .AppendFormat("      ,IdProducto = '{0}'", IdProducto)
         .AppendFormat("      ,IdLote = '{0}'", IdLote)
         .AppendFormat("      ,Cantidad = {0}", Cantidad)
         .Append(" WHERE ")
         .AppendFormat("      ,IdSucursal = {0}", IdSucursal)
         .AppendFormat("      ,IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      ,NumeroMovimiento = {0}", NumeroMovimiento)
         .AppendFormat("      ,Orden = {0}", Orden)
         .AppendFormat("      ,IdProducto = '{0}'", IdProducto)
         .AppendFormat("      ,IdLote = '{0}'", IdLote)
      End With

      Me.Execute(qry.ToString())
   End Sub

   Public Sub MovimientosVentasProductosLotes_D(ByVal IdSucursal As Integer,
                                                ByVal IdTipoMovimiento As String,
                                                ByVal NumeroMovimiento As Long,
                                                ByVal Orden As Long,
                                                ByVal IdProducto As String,
                                                ByVal IdLote As String)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM MovimientosVentasProductosLotes WHERE ")
         .AppendFormat("      IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      AND NumeroMovimiento = {0}", NumeroMovimiento)
         .AppendFormat("      AND Orden = {0}", Orden)
         .AppendFormat("      AND IdProducto = '{0}'", IdProducto)
         .AppendFormat("      AND IdLote = '{0}'", IdLote)
      End With

      Me.Execute(qry.ToString())
   End Sub

   Public Sub MovimientosVentasProductosLotes_DProd(ByVal idSucursal As Integer,
                                                    ByVal idProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM MovimientosVentasProductosLotes ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT ")
         .Append("           MVPL.IdSucursal")
         .Append("           ,MVPL.IdTipoMovimiento")
         .Append("           ,MVPL.NumeroMovimiento")
         .Append("           ,MVPL.Orden")
         .Append("           ,MVPL.IdProducto")
         .Append("		     ,P.NombreProducto")
         .Append("           ,MVPL.IdLote")
         .Append("		     ,PL.FechaVencimiento")
         .Append("           ,MVPL.Cantidad")
         .Append("  FROM MovimientosVentasProductosLotes MVPL ")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = MVPL.IdProducto")
         .AppendLine(" LEFT JOIN ProductosLotes PL ON PL.IdSucursal = MVPL.IdSucursal AND PL.IdProducto = MVPL.IdProducto AND PL.IdLote = MVPL.IdLote ")
      End With
   End Sub

   Public Function MovimientosVentasProductosLotes_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorMovimientoVenta(ByVal idSucursal As Integer, ByVal idTipoMovimiento As String, ByVal numeroMovimiento As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat("       MVPL.IdSucursal = {0}", idSucursal)
         .AppendFormat("      AND MVPL.IdTipoMovimiento = '{0}'", idTipoMovimiento)
         .AppendFormat("      AND MVPL.NumeroMovimiento = {0}", numeroMovimiento)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function MovimientosVentasProductosLotes_G1(ByVal IdSucursal As Integer,
                                                ByVal IdTipoMovimiento As String,
                                                ByVal NumeroMovimiento As Long,
                                                ByVal Orden As Long,
                                                ByVal IdProducto As String,
                                                ByVal IdLote As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat("       MVPL.IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND MVPL.IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      AND MVPL.NumeroMovimiento = {0}", NumeroMovimiento)
         .AppendFormat("      AND MVPL.Orden = {0}", Orden)
         .AppendFormat("      AND MVPL.IdProducto = '{0}'", IdProducto)
         .AppendFormat("      AND VIdLote = '{0}'", IdLote)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'columna = "R." + columna
      'If columna = "R.NombreVendedor" Then columna = "V.NombreEmpleado"
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


End Class
