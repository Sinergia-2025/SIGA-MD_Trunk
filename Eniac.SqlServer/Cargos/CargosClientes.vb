Imports Eniac.Entidades
Public Class CargosClientes
   Inherits Eniac.SqlServer.Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CargosClientes_I(idCargo As Integer, idSucursal As Integer, idCliente As Long, precioLista As Decimal,
                               descuentoRecargoPorc1 As Decimal, descuentoRecargoPorcGral As Decimal,
                               monto As Decimal, cantidad As Decimal, observacion As String, idTipoLiquidacion As Integer)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("INSERT INTO CargosClientes")
         .AppendFormat("        ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}) ",
                              CargoCliente.Columnas.IdCargo.ToString(),
                              CargoCliente.Columnas.IdSucursal.ToString(),
                              CargoCliente.Columnas.IdCliente.ToString(),
                              CargoCliente.Columnas.PrecioLista.ToString(),
                              CargoCliente.Columnas.DescuentoRecargoPorc1.ToString(),
                              CargoCliente.Columnas.DescuentoRecargoPorc2.ToString(),
                              CargoCliente.Columnas.DescuentoRecargoPorcGral.ToString(),
                              CargoCliente.Columnas.Monto.ToString(),
                              CargoCliente.Columnas.Cantidad.ToString(),
                              CargoCliente.Columnas.Observacion.ToString(),
                              CargoCliente.Columnas.IdTipoLiquidacion.ToString()
                              ).AppendLine()
         .AppendFormat(" VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, '{9}', {10} ) ",
                       idCargo, idSucursal, idCliente, precioLista, descuentoRecargoPorc1, 0, descuentoRecargoPorcGral,
                       monto, cantidad, observacion, idTipoLiquidacion).AppendLine()
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub CargosClientes_U(idCargo As Integer?, idSucursal As Integer?, idCliente As Long?, precioLista As Decimal,
                               descuentoRecargoPorc1 As Decimal, descuentoRecargoPorcGral As Decimal,
                               monto As Decimal, cantidad As Decimal?, observacion As String, IdTipoNotificacion As Integer)

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("UPDATE CargosClientes")
         .AppendFormat("   SET {0} = {1}", CargoCliente.Columnas.PrecioLista.ToString(), precioLista).AppendLine()
         .AppendFormat("     , {0} = {1}", CargoCliente.Columnas.DescuentoRecargoPorc1.ToString(), descuentoRecargoPorc1).AppendLine()
         .AppendFormat("     , {0} = {1}", CargoCliente.Columnas.DescuentoRecargoPorcGral.ToString(), descuentoRecargoPorcGral).AppendLine()
         .AppendFormat("     , {0} = {1}", CargoCliente.Columnas.Monto.ToString(), monto).AppendLine()
         If cantidad.HasValue Then
            .AppendFormat("     , {0} = {1}", CargoCliente.Columnas.Cantidad.ToString(), cantidad.Value).AppendLine()
         End If
         .AppendFormat(" WHERE  1  =  1 ").AppendLine()
         If idCargo.HasValue Then
            .AppendFormat("   AND {0} = {1}", CargoCliente.Columnas.IdCargo.ToString(), idCargo).AppendLine()
         End If
         If idSucursal.HasValue Then
            .AppendFormat("   AND {0} = {1}", CargoCliente.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If idCliente.HasValue Then
            .AppendFormat("   AND {0} = {1}", CargoCliente.Columnas.IdCliente.ToString(), idCliente).AppendLine()
         End If

         If Not String.IsNullOrEmpty(observacion) Then
            If Not String.IsNullOrWhiteSpace(observacion) Then
               .AppendFormat("   AND {0} = '{1}'", CargoCliente.Columnas.Observacion.ToString(), observacion).AppendLine()
            Else
               .AppendFormat("   AND {0} = NULL", CargoCliente.Columnas.Observacion.ToString()).AppendLine()
            End If
         End If
         .AppendFormat("    AND {0} = {1}", CargoCliente.Columnas.IdTipoLiquidacion.ToString(), IdTipoNotificacion).AppendLine()
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub CargosClientes_U(idCargo As Integer, idSucursal As Integer, precioLista As Decimal,
                               descuentoRecargoPorc1 As Decimal, descuentoRecargoPorcGral As Decimal, monto As Decimal)
      CargosClientes_U(idCargo, idSucursal, Nothing, precioLista, descuentoRecargoPorc1, descuentoRecargoPorcGral, monto, Nothing, Nothing, Nothing)
   End Sub

   Public Sub CargosClientes_D(idSucursal As Integer, idTipoLiquidacion As Integer,
                               idcliente As Long, idCategoria As Integer, idZonaGeografica As String, idCobrador As Integer, FiltroPcs As String, CantidadPcs As Integer)
      CargosClientes_D(idCargo:=Nothing, idSucursal:=idSucursal, idCliente:=idcliente, idTipoLiquidacion:=idTipoLiquidacion,
                       idCategoria:=idCategoria, idZonaGeografica:=idZonaGeografica, idCobrador:=idCobrador, filtroPcs:=FiltroPcs, cantidadPcs:=CantidadPcs)
   End Sub

   Public Sub CargosClientes_D(idCargo As Integer?, idSucursal As Integer?, idCliente As Long?, idTipoLiquidacion As Integer?)
      CargosClientes_D(idCargo, idSucursal, idCliente, idTipoLiquidacion, idCategoria:=0, idZonaGeografica:=String.Empty, idCobrador:=0, filtroPcs:=String.Empty, cantidadPcs:=0)
   End Sub

   Public Sub CargosClientes_D(idCargo As Integer?, idSucursal As Integer?, idCliente As Long?, idTipoLiquidacion As Integer?,
                               idCategoria As Integer, idZonaGeografica As String, idCobrador As Integer, filtroPcs As String, cantidadPcs As Integer)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("DELETE CargosClientes")
         .AppendLine("  FROM CargosClientes CC")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendLine(" WHERE 1 = 1")
         If idCargo.HasValue Then
            .AppendFormat(" AND CC.IdCargo = " & idCargo.ToString())
         End If
         If idSucursal.HasValue Then
            .AppendFormat(" AND CC.IdSucursal = " & idSucursal.ToString())
         End If
         If idCliente.HasValue And idCliente.Value > 0 Then
            .AppendFormat(" AND CC.IdCliente = " & idCliente.Value.ToString())
         End If
         If idTipoLiquidacion.HasValue Then
            .AppendFormat(" AND CC.IdTipoLiquidacion = " & idTipoLiquidacion.ToString())
         End If


         'Filtros de pantalla de asignación de cargos
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("   AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If idCategoria > 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If
         If idCobrador > 0 Then
            .AppendFormatLine("   AND C.IdCobrador = {0} ", idCobrador)
         End If
         If cantidadPcs > 0 Then
            .AppendFormatLine("   AND C.CantidadDePCs {0} {1}", filtroPcs, cantidadPcs)
         End If


      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      SelectTexto(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, datosRelacionados As Boolean, crossJoin As Boolean)
      With stb
         .Length = 0

         .AppendFormatLine("SELECT {0}.IdCliente", If(crossJoin, "X", "AC"))
         .AppendFormatLine("     , {0}.IdCargo", If(crossJoin, "X", "AC"))
         .AppendFormatLine("     , {0}.IdTipoLiquidacion", If(crossJoin, "X", "AC"))
         .AppendFormatLine("     , {0}.IdSucursal", If(crossJoin, "X", "AC"))
         .AppendLine("     , ISNULL(AC.PrecioLista, 0) PrecioLista")
         .AppendFormatLine("     , ISNULL({0}, 0) PrecioListaSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AC.PrecioLista", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
         .AppendLine("     , ISNULL(AC.DescuentoRecargoPorc1, 0) DescuentoRecargoPorc1")
         .AppendLine("     , ISNULL(AC.DescuentoRecargoPorcGral, 0) DescuentoRecargoPorcGral")
         .AppendLine("     , C.DescuentoRecargoPorc AS ClienteDescuentoRecargoPorc")
         .AppendLine("     , ISNULL(AC.Monto, 0) Monto")
         .AppendFormatLine("     , ISNULL({0}, 0) MontoSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AC.Monto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
         .AppendLine("     , ISNULL(AC.Cantidad, 1) Cantidad")
         .AppendLine("     , ISNULL(AC.Monto, 0) MontoOriginal")
         .AppendLine("     , ISNULL((AC.Cantidad * AC.Monto), 0)  AS Importe")
         .AppendFormatLine("     , ISNULL({0}, 0)  AS ImporteSinIva", CalculosImpositivos.ObtenerPrecioSinImpuestos("(AC.Cantidad *AC.Monto)", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
         .AppendLine("     , ISNULL(AC.Observacion, '') Observacion")
         If datosRelacionados Then
            .AppendLine("     , C.CodigoCliente")
            .AppendLine("     , C.NombreCliente")
            .AppendLine("     , C.NombreDeFantasia")
            .AppendLine("     , C.TipoDocCliente")
            .AppendLine("     , C.NroDocCliente")
            .AppendLine("     , C.Activo")
            .AppendLine("     , CC.NombreCategoria")
            .AppendLine("     , ZG.NombreZonaGeografica")
            .AppendLine("     , Cob.NombreEmpleado")
            .AppendLine("     , C.CantidadDePCs")
            .AppendLine("     , AL.NombreCargo")
            .AppendLine("     , AL.ModificaImporte")
            .AppendLine("     , AL.ModificaCantidad")
            .AppendLine("     , TL.NombreTipoLiquidacion")
         End If

         If crossJoin Then
            .AppendLine("     , CONVERT(BIT, CASE WHEN AC.Cantidad IS NULL THEN 0 ELSE 1 END) Selec")
            .AppendFormatLine(" FROM (SELECT IdCliente, IdCargo, IdSucursal, IdTipoLiquidacion FROM Cargos CROSS JOIN Clientes CROSS JOIN Sucursales) X")
            .AppendFormatLine(" LEFT JOIN CargosClientes AC ON AC.IdCliente = X.IdCliente AND AC.IdCargo = X.IdCargo AND AC.IdSucursal = X.IdSucursal AND AC.IdTipoLiquidacion = X.IdTipoLiquidacion")
         Else
            .AppendFormatLine(" FROM CargosClientes AC ")
         End If

         If datosRelacionados Then
            .AppendFormatLine(" LEFT JOIN Clientes C ON C.IdCliente = {0}.IdCliente", If(crossJoin, "X", "AC"))
            .AppendFormatLine(" LEFT JOIN Cargos AL ON AL.IdCargo = {0}.IdCargo", If(crossJoin, "X", "AC"))
            .AppendFormatLine(" LEFT JOIN Categorias CC ON CC.IdCategoria = C.IdCategoria ")
            .AppendFormatLine(" LEFT JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica ")
            .AppendFormatLine(" LEFT JOIN TiposLiquidaciones TL ON TL.IdTipoLiquidacion = {0}.IdTipoLiquidacion", If(crossJoin, "X", "AC"))
            .AppendFormatLine(" LEFT JOIN Empleados Cob ON Cob.IdEmpleado = C.IdCobrador")
            .AppendFormatLine(" LEFT JOIN Productos P ON P.IdProducto = AL.IdProducto")
         End If

      End With

   End Sub

   Public Function CargosClientes_GA(datosRelacionados As Boolean, idSucursal As Integer, idTipoLiquidacion As Integer, crossJoin As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb, datosRelacionados, crossJoin)
         .AppendFormatLine(" WHERE {0}.IdSucursal = " & idSucursal.ToString(), If(crossJoin, "X", "AC"))
         .AppendFormatLine("   AND {0}.IdTipoLiquidacion = " & idTipoLiquidacion.ToString(), If(crossJoin, "X", "AC"))
         .AppendFormatLine("   AND AL.Activo = 'True'")
         If datosRelacionados Then
            .AppendFormatLine("  ORDER BY C.NombreCliente, AL.NombreCargo")
         Else
            .AppendFormatLine("  ORDER BY {0}.IdCliente, {0}.IdCargo", If(crossJoin, "X", "AC"))
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CargosClientes_GetAsignacion(idSucursal As Integer, idTipoLiquidacion As Integer, idCategoria As Integer?, idZonaGeografica As String,
                                                IdCobrador As Integer, FiltroPcs As String,
                                                CantidadPcs As Integer, crossJoin As Boolean, idCliente As Long, idTipoCliente As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendFormatLine("SELECT Cast(1 as bit) as Sel, Cast(0 as bit) as Sel2, {0}.IdCliente", If(crossJoin, "X", "AC"))
         .AppendFormatLine("     , {0}.IdCargo", If(crossJoin, "X", "AC"))
         .AppendFormatLine("     , {0}.IdTipoLiquidacion", If(crossJoin, "X", "AC"))
         .AppendFormatLine("     , {0}.IdSucursal", If(crossJoin, "X", "AC"))
         .AppendFormatLine("     , ISNULL(AC.PrecioLista, 0) PrecioLista")
         .AppendFormatLine("     , ISNULL({0}, 0) PrecioListaSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AC.PrecioLista", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
         .AppendFormatLine("     , ISNULL(AC.DescuentoRecargoPorc1, 0) DescuentoRecargoPorc1")
         .AppendFormatLine("     , ISNULL(AC.DescuentoRecargoPorcGral, 0) DescuentoRecargoPorcGral")
         .AppendFormatLine("     , C.DescuentoRecargoPorc AS ClienteDescuentoRecargoPorc")
         .AppendFormatLine("     , ISNULL(AC.Monto, 0) Monto")
         .AppendFormatLine("     , ISNULL({0}, 0) MontoSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AC.Monto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
         .AppendFormatLine("     , ISNULL(AC.Cantidad, 1) Cantidad")
         .AppendFormatLine("     , ISNULL(AC.Monto, 0) MontoOriginal")
         .AppendFormatLine("     , ISNULL((AC.Cantidad * AC.Monto), 0)  AS Importe")
         .AppendFormatLine("     , ISNULL({0}, 0) ImporteSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AC.Cantidad * AC.Monto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))


         'Campos Nuevos para Calcular
         .AppendFormatLine("     , ISNULL(AC.PrecioLista, 0) AS PrecioListaNuevo")
         .AppendFormatLine("     , ISNULL({0}, 0) AS PrecioListaNuevoSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AC.PrecioLista", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
         .AppendFormatLine("     , ISNULL(AC.DescuentoRecargoPorc1, 0) AS DescuentoRecargoPorc1Nuevo")
         .AppendFormatLine("     , ISNULL(AC.Monto, 0) AS MontoNuevo")
         .AppendFormatLine(" 	   , ISNULL({0}, 0) AS MontoNuevoSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AC.Monto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))
         .AppendFormatLine("     , ISNULL((AC.Cantidad * AC.Monto), 0) AS ImporteNuevo")
         .AppendFormatLine("     , ISNULL({0}, 0) AS ImporteNuevoSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AC.Cantidad * AC.Monto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))


         .AppendFormatLine("     , ISNULL(AC.Observacion, '') Observacion")

         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.NombreDeFantasia")
         .AppendFormatLine("     , C.TipoDocCliente")
         .AppendFormatLine("     , C.NroDocCliente")
         .AppendFormatLine("     , C.Activo")
         .AppendFormatLine("     , CC.NombreCategoria")
         .AppendFormatLine("     , ZG.NombreZonaGeografica")

         .AppendFormatLine("     , C.CantidadDePCs")
         .AppendFormatLine("     , AL.NombreCargo")
         .AppendFormatLine("     , AL.ModificaImporte")
         .AppendFormatLine("     , AL.ModificaCantidad")

         .AppendFormatLine("     , ISNULL(AL.Monto, 0) MontoCargo")
         .AppendFormatLine("     , ISNULL({0}, 0) MontoCargoSinIVA", CalculosImpositivos.ObtenerPrecioSinImpuestos("AL.Monto", "P.Alicuota", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt"))

         .AppendFormatLine("     , TL.NombreTipoLiquidacion")

         .AppendFormatLine("     , Cob.NombreEmpleado AS NombreCobrador")


         .AppendFormatLine("     , (SELECT TOP 1 MIN(L.FechaLiquidacion)")
         .AppendFormatLine("          FROM LiquidacionesDetallesClientes LDC")
         .AppendFormatLine("         INNER JOIN Liquidaciones L ON L.IdSucursal = LDC.IdSucursal")
         .AppendFormatLine("                                   AND L.IdtipoLiquidacion = LDC.IdtipoLiquidacion")
         .AppendFormatLine("                                   AND L.PeriodoLiquidacion = LDC.PeriodoLiquidacion")
         .AppendFormatLine("         WHERE LDC.IdCliente = AC.IdCliente")
         .AppendFormatLine("           AND LDC.IdCargo = AC.IdCargo")
         .AppendFormatLine("           AND LDC.IdSucursal = AC.IdSucursal")
         .AppendFormatLine("           AND LDC.IdTipoLiquidacion = AC.IdTipoLiquidacion")
         .AppendFormatLine("         GROUP BY LDC.IdCliente, LDC.IdCargo, LDC.Importe")
         .AppendFormatLine("         ORDER BY LDC.IdCliente, MIN(L.FechaLiquidacion) DESC) AS FechaUltimoCambioPrecio")
         .AppendFormatLine("     , CONVERT(INT, 0) Meses")

         .AppendFormatLine("     ,P.Alicuota")
         .AppendFormatLine("     ,P.PorcImpuestoInterno")
         .AppendFormatLine("     ,P.ImporteImpuestoInterno")
         .AppendFormatLine("     ,P.OrigenPorcImpInt")

         If crossJoin Then
            .AppendLine("     , CONVERT(BIT, CASE WHEN AC.Cantidad IS NULL THEN 0 ELSE 1 END) Selec")
            .AppendFormatLine(" FROM (SELECT IdCliente, IdCargo, IdSucursal, IdTipoLiquidacion FROM Cargos CROSS JOIN Clientes CROSS JOIN Sucursales) X")
            .AppendFormatLine(" LEFT JOIN CargosClientes AC ON AC.IdCliente = X.IdCliente AND AC.IdCargo = X.IdCargo AND AC.IdSucursal = X.IdSucursal AND AC.IdTipoLiquidacion = X.IdTipoLiquidacion")
         Else
            .AppendFormatLine(" FROM CargosClientes AC ")
         End If

         .AppendFormatLine(" LEFT JOIN Clientes C ON C.IdCliente = {0}.IdCliente", If(crossJoin, "X", "AC"))
         .AppendFormatLine(" LEFT JOIN Cargos AL ON AL.IdCargo = {0}.IdCargo", If(crossJoin, "X", "AC"))
         .AppendFormatLine(" LEFT JOIN Productos P ON P.IdProducto = AL.IdProducto")
         .AppendFormatLine(" LEFT JOIN Categorias CC ON CC.IdCategoria = C.IdCategoria ")
         .AppendFormatLine(" LEFT JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica ")
         .AppendFormatLine(" LEFT JOIN TiposLiquidaciones TL ON TL.IdTipoLiquidacion = {0}.IdTipoLiquidacion", If(crossJoin, "X", "AC"))
         .AppendFormatLine(" LEFT JOIN Empleados Cob ON Cob.IdEmpleado = C.IdCobrador")

         .AppendFormatLine(" WHERE {0}.IdSucursal = " & idSucursal.ToString(), If(crossJoin, "X", "AC"))
         .AppendFormatLine("   AND {0}.IdTipoLiquidacion = " & idTipoLiquidacion.ToString(), If(crossJoin, "X", "AC"))
         .AppendFormatLine("   AND AL.Activo = 'True'")

         If idCliente > 0 Then
            .AppendFormatLine("   AND  c.IdCliente = {0} ", idCliente)
         End If
         If idCategoria <> 0 Then
            .AppendFormat("  AND C.IdCategoria = {0} ", idCategoria)
         End If
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat("  AND C.idZonaGeografica = '{0}' ", idZonaGeografica)
         End If
         If IdCobrador > 0 Then
            .AppendFormat("      AND C.IdCobrador = {0}", IdCobrador)
         End If
         If CantidadPcs > 0 Then
            .AppendFormat("   AND C.CantidadDePCs {0} {1}", FiltroPcs, CantidadPcs)
         End If

         If idTipoCliente > 0 Then
            .AppendFormat("   AND C.IdTipoCliente = {0}", idTipoCliente)
         End If


         .AppendFormatLine("  ORDER BY C.NombreCliente, AL.NombreCargo")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CargosClientes_GA(ByVal IdSucursal As Integer, IdTipoLiquidacion As Integer) As DataTable
      Return CargosClientes_GA(False, IdSucursal, IdTipoLiquidacion, False)
   End Function

   Public Function CargosClientes_G1(ByVal idCliente As Integer, ByVal IdCargo As Integer,
                                     ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer, ByVal IdCobrador As Integer) As DataTable
      Return CargosClientes_G(idCliente, IdCargo, Nothing, Nothing, False, IdSucursal, IdTipoLiquidacion, IdCobrador)
   End Function

   Public Function CargosClientes_G(idCliente As Long?, idCargo As Integer?,
                                    idCategoria As Integer?, idZonaGeografica As String,
                                    datosRelacionados As Boolean, idSucursal As Integer,
                                    IdTipoLiquidacion As Integer, idCobrador As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb, datosRelacionados, False)
         .AppendLine("  WHERE AC.IdSucursal = " & idSucursal.ToString())
         .AppendLine(" AND AC.IdTipoLiquidacion =" & IdTipoLiquidacion.ToString())
         If idCliente.HasValue Then
            .AppendFormat("   AND AC.{0} = {1}", CargoCliente.Columnas.IdCliente.ToString(), idCliente.Value).AppendLine()
         End If
         If idCargo.HasValue Then
            .AppendFormat("   AND AC.{0} = {1}", CargoCliente.Columnas.IdCargo.ToString(), idCargo.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idZonaGeografica) Then
            .AppendFormat("   AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If idCobrador > 0 Then
            .AppendFormat("   AND C.IdCobrador = {0}", idCobrador)
         End If

         If datosRelacionados Then
            If idCategoria.HasValue Then
               .AppendFormat("   AND CC.{0} = {1}", Cliente.Columnas.IdCategoria.ToString(), idCategoria.Value).AppendLine()
            End If
         End If
         If datosRelacionados Then
            .Append("  ORDER BY C.NombreCliente, AL.NombreCargo")
         Else
            .Append("  ORDER BY AC.IdCliente, AC.IdCargo")
         End If
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
End Class