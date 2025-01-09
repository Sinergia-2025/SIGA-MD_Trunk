Public Class MovimientosStock
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosStock_I(ByVal IdSucursal As Integer, _
                                            ByVal IdTipoMovimiento As String, _
                                            ByVal NumeroMovimiento As Long, _
                                            ByVal Orden As Integer, _
                                            ByVal IdProducto As String, _
                                            ByVal Cantidad As Decimal, _
                                            ByVal fechaMovimiento As Date)

      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO MovimientosStock (")
         .Append("           IdSucursal")
         .Append("           ,IdTipoMovimiento")
         .Append("           ,NumeroMovimiento")
         .Append("           ,Orden")
         .Append("           ,IdProducto")
         .Append("           ,Cantidad")
         .Append("           ,FechaMovimiento")
         .Append(")     VALUES(")
         .AppendFormat("           {0}", IdSucursal)
         .AppendFormat("           ,'{0}'", IdTipoMovimiento)
         .AppendFormat("           ,{0}", NumeroMovimiento)
         .AppendFormat("           ,{0}", Orden)
         .AppendFormat("           ,'{0}'", IdProducto)
         .AppendFormat("           ,{0}", Cantidad)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaMovimiento, True))
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "MovimientosStock")

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
         .Append("           ,FechaMovimiento")
         .Append("  FROM MovimientosStock")
      End With
   End Sub

   Public Sub MovimientosStock_DProd(ByVal idSucursal As Integer, _
                                                ByVal idProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM MovimientosStock ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdProducto = '" & idProducto & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "MovimientosStock")

   End Sub

End Class
