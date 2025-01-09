<Obsolete("Se reemplaza por MovimientosStockProductos", True)>
Public Class MovimientosVentasProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosVentasProductos_I(ByVal idSucursal As Integer,
                                           ByVal idTipoMovimiento As String,
                                           ByVal numeroMovimiento As Long,
                                           ByRef orden As Integer,
                                           ByVal idProducto As String,
                                           ByVal cantidad As Decimal,
                                           ByVal precio As Decimal,
                                           idaAtributo01 As Integer?,
                                           idaAtributo02 As Integer?,
                                           idaAtributo03 As Integer?,
                                           idaAtributo04 As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO MovimientosVentasProductos ")
         .AppendLine("    (IdSucursal")
         .AppendLine("    ,IdTipoMovimiento")
         .AppendLine("    ,NumeroMovimiento")
         .AppendLine("    ,Orden")
         .AppendLine("    ,IdProducto")
         .AppendLine("    ,Cantidad")
         .AppendLine("    ,Precio")
         '-- REQ-34669.- -----------------------------------
         .Append("           ,IdaAtributoProducto01")
         .Append("           ,IdaAtributoProducto02")
         .Append("           ,IdaAtributoProducto03")
         .Append("           ,IdaAtributoProducto04")
         '--------------------------------------------------
         .AppendLine("    )")
         .AppendLine("  VALUES ")
         .AppendLine("    (" & idSucursal.ToString())
         .AppendLine("    ,'" & idTipoMovimiento & "'")
         .AppendLine("    ," & numeroMovimiento.ToString())
         .AppendFormat("    ,{0}", orden)
         .AppendLine("    ,'" & idProducto & "'")
         .AppendLine("    ," & cantidad.ToString())
         .AppendLine("    ," & precio.ToString())
         '-- REQ-34669.- -----------------------------------
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
         .AppendLine("    )")
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub MovimientosVentasProductos_D(ByVal idSucursal As Integer,
                                           ByVal idTipoMovimiento As String,
                                           ByVal numeroMovimiento As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE MovimientosVentasProductos ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoMovimiento = '" & idTipoMovimiento & "'")
         .AppendLine("   AND NumeroMovimiento = " & numeroMovimiento)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub MovimientosVentasProductos_DProd(ByVal idSucursal As Integer,
                                               ByVal idProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM MovimientosVentasProductos ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "MovimientosVentasProductos")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT ")
         .Append("           IdSucursal")
         .Append("           ,IdTipoMovimiento")
         .Append("           ,NumeroMovimiento")
         .Append("           ,Orden")
         .Append("           ,IdProducto")
         .Append("           ,Cantidad")
         .Append("           ,Precio")
         .Append("  FROM MovimientosVentasProductos")
      End With
   End Sub

   Public Function MovimientosVentasProductos_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function MovimientosVentasProductos_G1(ByVal IdSucursal As Integer,
                                                ByVal IdTipoMovimiento As String,
                                                ByVal NumeroMovimiento As Long,
                                                ByVal Orden As Long,
                                                ByVal IdProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat("       IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      AND NumeroMovimiento = {0}", NumeroMovimiento)
         .AppendFormat("      AND Orden = {0}", Orden)
         .AppendFormat("      AND IdProducto = '{0}'", IdProducto)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
