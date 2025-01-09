Public Class LiquidacionesDetallesClientes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub LiquidacionesDetallesClientes_I(periodoLiquidacion As Integer,
                                              idSucursal As Integer,
                                              idLiquidacionDetalleCliente As Integer,
                                              idLiquidacionCargo As Integer,
                                              idCliente As Long,
                                              idCargo As Integer?,
                                              codigoCliente As Long,
                                              nombreCliente As String,
                                              idCategoria As Integer,
                                              nombreCategoria As String,
                                              nombreCargo As String,
                                              importe As Decimal?,
                                              importeAlquiler As Decimal?,
                                              cantidadAdicional As Decimal?,
                                              precioLista As Decimal?,
                                              descuentoRecargoPorcGral As Decimal?,
                                              descuentoRecargoPorc1 As Decimal?,
                                              precioAdicional As Decimal?,
                                              observaciones As String,
                                              idTipoLiquidacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO LiquidacionesDetallesClientes ")
         .AppendFormat("({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20})",
                       Entidades.LiquidacionDetalleCliente.Columnas.PeriodoLiquidacion.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.IdLiquidacionDetalleCliente.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.IdLiquidacionCargo.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.IdCliente.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.IdCargo.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.CodigoCliente.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.NombreCliente.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.IdCategoria.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.NombreCategoria.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.NombreCargo.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.Importe.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.ImporteAlquiler.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString(),
                       "DescuentoRecargoPorc2",
                       Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.IdSucursal.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.IdTipoLiquidacion.ToString(),
                       Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()
                       ).AppendLine()
         .AppendFormat(" VALUES ({0}, {1}, {2}, {3}, {4}, {5}, '{6}', {7}, '{8}', '{9}', {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, '{18}', {19}, {20})",
                       periodoLiquidacion,
                       idLiquidacionDetalleCliente,
                       idLiquidacionCargo,
                       idCliente,
                       idCargo,
                       codigoCliente,
                       nombreCliente,
                       idCategoria,
                       nombreCategoria,
                       nombreCargo,
                       importe,
                       importeAlquiler,
                       cantidadAdicional,
                       precioLista,
                       descuentoRecargoPorc1, 0,
                       precioAdicional,
                       idSucursal,
                       observaciones,
                       idTipoLiquidacion,
                       descuentoRecargoPorcGral
                       ).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub LiquidacionesDetallesClientes_D(ByVal PeriodoLiquidacion As Integer, ByVal IdLiquidacionDetalleCliente As Integer?,
                                              ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM LiquidacionesDetallesClientes")
         .AppendFormat(" WHERE {0} =  {1}", Entidades.LiquidacionDetalleCliente.Columnas.PeriodoLiquidacion.ToString(), PeriodoLiquidacion).AppendLine()
         .AppendFormat(" AND {0} =  {1}", Entidades.LiquidacionDetalleCliente.Columnas.IdSucursal.ToString(), IdSucursal).AppendLine()
         If IdLiquidacionDetalleCliente.HasValue Then
            .AppendFormat("   AND {0} =  {1}", Entidades.LiquidacionDetalleCliente.Columnas.IdLiquidacionDetalleCliente.ToString(), IdLiquidacionDetalleCliente.Value).AppendLine()
         End If
         .AppendFormat(" AND {0} =  {1}", Entidades.LiquidacionDetalleCliente.Columnas.IdTipoLiquidacion.ToString(), IdTipoLiquidacion).AppendLine()

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub LiquidacionesDetallesClientes_D(ByVal PeriodoLiquidacion As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)
      LiquidacionesDetallesClientes_D(PeriodoLiquidacion, Nothing, IdSucursal, IdTipoLiquidacion)
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder, conIdProducto As Boolean)
      With stb
         .Length = 0
         .AppendFormatLine("SELECT L.*")
         'Entidades.LiquidacionDetalleCliente.Columnas.PeriodoLiquidacion.ToString(,
         'Entidades.LiquidacionDetalleCliente.Columnas.IdLiquidacionDetalleCliente.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.IdLiquidacionCargo.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.IdCliente.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.IdCargo.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.CodigoCliente.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.NombreCliente.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.IdCategoria.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.NombreCategoria.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.NombreCargo.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.Importe.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.ImporteAlquiler.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString(),
         'Entidades.LiquidacionDetalleCliente.Columnas.IdTipoLiquidacion.ToString())
         '              ).AppendLine()
         If conIdProducto Then
            .AppendLine("  , AL.IdProducto")
         End If
         .AppendLine("  FROM LiquidacionesDetallesClientes L")
         If conIdProducto Then
            .AppendLine("  INNER JOIN Cargos AS AL ON AL.IdCargo = L.IdCargo")
         End If
      End With
   End Sub

   Public Function LiquidacionesDetallesClientes_GA() As DataTable
      Return Me.LiquidacionesDetallesClientes_GA()
   End Function

   Public Function LiquidacionesDetallesClientes_GA(periodo As Integer?, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable
      Return Me.LiquidacionesDetallesClientes_GA(periodo, True, IdSucursal, IdTipoLiquidacion)
   End Function

   Public Function LiquidacionesDetallesClientes_GA(periodo As Integer?, conIdProducto As Boolean, ByVal IdSucursal As Integer,
                                                    IdTipoLiquidacion As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery, conIdProducto)
         If periodo.HasValue Then
            .AppendLine(" WHERE L.PeriodoLiquidacion = " & periodo.ToString())
            .AppendLine("   AND L.IdSucursal = " & IdSucursal.ToString())
            .AppendLine("   AND L.IDTipoLiquidacion = " & IdTipoLiquidacion.ToString())
         End If
         .AppendLine(" ORDER BY L.PeriodoLiquidacion, L.IdLiquidacionDetalleCliente")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class