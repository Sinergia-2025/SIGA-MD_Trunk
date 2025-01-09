Public Class VentasProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasProductos_I(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroComprobante As Long,
                                orden As Integer,
                                idProducto As String,
                                nombreProducto As String,
                                cantidad As Double,
                                precio As Double,
                                costo As Double,
                                descRecGeneral As Double,
                                descRecGeneralProducto As Double,
                                descuentoRecargo As Double,
                                descuentoRecargoProducto As Double,
                                descuentoRecargoPorc1 As Double,
                                descuentoRecargoPorc2 As Double,
                                precioLista As Double,
                                precioNeto As Double,
                                utilidad As Double,
                                importeTotal As Double,
                                importeTotalNeto As Double,
                                kilos As Decimal,
                                idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                alicuotaImpuesto As Decimal,
                                importeImpuesto As Decimal,
                                comisionVendedorPorc As Decimal,
                                comisionVendedor As Decimal,
                                idListaPrecios As Integer,
                                nombreListaPrecios As String,
                                importeImpuestoInterno As Decimal,
                                idCentroCosto As Integer?,
                                precioConImpuestos As Decimal,
                                precioNetoConImpuestos As Decimal,
                                importeTotalConImpuestos As Decimal,
                                importeTotalNetoConImpuestos As Decimal,
                                precioVentaPorTamano As Decimal,
                                tamano As Decimal,
                                idUnidadDeMedida As String,
                                idMoneda As Integer,
                                garantia As Integer,
                                fechaEntrega As DateTime?,
                                porcImpuestoInterno As Decimal,
                                origenPorcImpInt As Entidades.OrigenesPorcImpInt,
                                tipoOperacion As String,
                                nota As String,
                                nombreCortoListaPrecios As String,
                                idFormula As Integer,
                                automatico As Boolean,
                                idEstadoVenta As Integer?,
                                idOferta As Integer?,
                                fechaDevolucion As Date?,
                                modificoPrecioManualmente As Boolean,
                                conversion As Decimal,
                                cantidadManual As Decimal,
                                idaAtributo01 As Integer?,
                                idaAtributo02 As Integer?,
                                idaAtributo03 As Integer?,
                                idaAtributo04 As Integer?,
                                idDeposito As Integer, idUbicacion As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO VentasProductos ")
         .AppendFormatLine("           (IdSucursal")
         .AppendFormatLine("           ,IdTipoComprobante")
         .AppendFormatLine("           ,Letra")
         .AppendFormatLine("           ,CentroEmisor")
         .AppendFormatLine("           ,NumeroComprobante")
         .AppendFormatLine("           ,Orden")
         .AppendFormatLine("           ,IdProducto")
         .AppendFormatLine("           ,NombreProducto")
         .AppendFormatLine("           ,Cantidad")
         .AppendFormatLine("           ,Precio")
         .AppendFormatLine("           ,Costo")
         .AppendFormatLine("           ,DescRecGeneral")
         .AppendFormatLine("           ,DescRecGeneralProducto")
         .AppendFormatLine("           ,DescuentoRecargo")
         .AppendFormatLine("           ,DescuentoRecargoProducto")
         .AppendFormatLine("           ,DescuentoRecargoPorc")
         .AppendFormatLine("           ,DescuentoRecargoPorc2")
         .AppendFormatLine("           ,PrecioLista")
         .AppendFormatLine("           ,PrecioNeto")
         .AppendFormatLine("           ,Utilidad")
         .AppendFormatLine("           ,ImporteTotal")
         .AppendFormatLine("           ,ImporteTotalNeto")
         .AppendFormatLine("           ,Kilos")
         .AppendFormatLine("           ,IdTipoImpuesto")
         .AppendFormatLine("           ,AlicuotaImpuesto")
         .AppendFormatLine("           ,ImporteImpuesto")
         .AppendFormatLine("           ,ComisionVendedorPorc")
         .AppendFormatLine("           ,ComisionVendedor")
         .AppendFormatLine("           ,IdListaPrecios")
         .AppendFormatLine("           ,NombreListaPrecios")
         .AppendFormatLine("           ,ImporteImpuestoInterno")
         .AppendFormatLine("           ,PorcImpuestoInterno")
         .AppendFormatLine("           ,OrigenPorcImpInt")
         .AppendFormatLine("           ,IdCentroCosto")

         .AppendFormatLine("           ,PrecioConImpuestos")
         .AppendFormatLine("           ,PrecioNetoConImpuestos")
         .AppendFormatLine("           ,ImporteTotalConImpuestos")
         .AppendFormatLine("           ,ImporteTotalNetoConImpuestos")

         .AppendFormatLine("           ,PrecioVentaPorTamano")
         .AppendFormatLine("           ,Tamano")
         .AppendFormatLine("           ,IdUnidadDeMedida")
         .AppendFormatLine("           ,IdMoneda")

         .AppendFormatLine("           ,Garantia")
         .AppendFormatLine("           ,FechaEntrega")
         .AppendFormatLine("           ,TipoOperacion")
         .AppendFormatLine("           ,Nota")

         .AppendFormatLine("           ,NombreCortoListaPrecios")

         .AppendFormatLine("           ,IdFormula")
         .AppendFormatLine("           ,Automatico")
         .AppendFormatLine("           ,IdEstadoVenta")
         .AppendFormatLine("           ,IdOferta")
         .AppendFormatLine("           ,{0}", Entidades.VentaProducto.Columnas.FechaDevolucion.ToString())
         .AppendFormatLine("           ,ModificoPrecioManualmente")
         .AppendFormatLine("           ,Conversion")
         .AppendFormatLine("           ,CantidadManual")

         '-- REQ-34669.- -----------------------------------
         .Append("           ,IdaAtributoProducto01")
         .Append("           ,IdaAtributoProducto02")
         .Append("           ,IdaAtributoProducto03")
         .Append("           ,IdaAtributoProducto04")
         '--------------------------------------------------
         .Append("           ,IdDeposito")
         .Append("           ,IdUbicacion")

         '--------------------------------------------------
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine(idSucursal.ToString())
         .AppendFormatLine(" ,'" & idTipoComprobante & "'")
         .AppendFormatLine(" ,'" & letra & "'")
         .AppendFormatLine(" ," & centroEmisor.ToString())
         .AppendFormatLine(" ," & numeroComprobante.ToString())
         .AppendFormatLine(" , {0}", orden)
         .AppendFormatLine(" ,'" & idProducto & "'")
         .AppendFormatLine(" ,'" & nombreProducto & "'")
         .AppendFormatLine(" ," & cantidad.ToString())
         .AppendFormatLine(" ," & precio.ToString())
         .AppendFormatLine(" ," & costo.ToString())
         .AppendFormatLine(" ," & descRecGeneral.ToString())
         .AppendFormatLine(" ," & descRecGeneralProducto.ToString())
         .AppendFormatLine(" ," & descuentoRecargo.ToString())
         .AppendFormatLine(" ," & descuentoRecargoProducto.ToString())
         .AppendFormatLine(" ," & descuentoRecargoPorc1.ToString())
         .AppendFormatLine(" ," & descuentoRecargoPorc2.ToString())
         .AppendFormatLine(" ," & precioLista.ToString())
         .AppendFormatLine(" ," & precioNeto.ToString())
         .AppendFormatLine(" ," & utilidad.ToString())
         .AppendFormatLine(" ," & importeTotal.ToString())
         .AppendFormatLine(" ," & importeTotalNeto.ToString())
         .AppendFormatLine(" ," & kilos.ToString())
         .AppendFormatLine(" ,'{0}'", idTipoImpuesto.ToString())
         .AppendFormatLine(" ,{0}", alicuotaImpuesto)
         .AppendFormatLine(" ,{0}", importeImpuesto)
         .AppendFormatLine(" ,{0}", comisionVendedorPorc)
         .AppendFormatLine(" ,{0}", comisionVendedor)
         .AppendFormatLine(" ,{0}", idListaPrecios)
         .AppendFormatLine(" ,'{0}'", nombreListaPrecios.ToString())
         .AppendFormatLine(" ,{0}", importeImpuestoInterno)
         .AppendFormatLine(" ,{0}", porcImpuestoInterno)
         .AppendFormatLine(" ,'{0}'", origenPorcImpInt.ToString())
         If idCentroCosto.HasValue AndAlso idCentroCosto.Value > 0 Then
            .AppendFormatLine(" ,{0}", idCentroCosto.Value)
         Else
            .AppendFormatLine(" ,NULL")
         End If

         .AppendFormatLine("          , {0} ", precioConImpuestos)
         .AppendFormatLine("          , {0} ", precioNetoConImpuestos)
         .AppendFormatLine("          , {0} ", importeTotalConImpuestos)
         .AppendFormatLine("          , {0} ", importeTotalNetoConImpuestos)

         .AppendFormatLine("          , {0} ", precioVentaPorTamano)
         .AppendFormatLine("          , {0} ", tamano)
         If Not String.IsNullOrWhiteSpace(idUnidadDeMedida) Then
            .AppendFormatLine("          ,'{0}'", idUnidadDeMedida)
         Else
            .AppendFormatLine("          ,NULL")
         End If

         If idMoneda > 0 Then
            .AppendFormatLine("          , {0} ", idMoneda)
         Else
            .AppendFormatLine("          ,NULL")
         End If

         .AppendFormatLine("          , {0}", garantia)
         If fechaEntrega.HasValue Then
            .AppendFormatLine("          ,'{0}'", ObtenerFecha(fechaEntrega.Value, False))
         Else
            .AppendFormatLine("          ,NULL")
         End If

         .AppendFormatLine(" ,'{0}'", tipoOperacion)
         .AppendFormatLine(" ,'{0}'", nota)
         .AppendFormatLine(" ,'{0}'", nombreCortoListaPrecios)

         If idFormula <> 0 Then
            .AppendFormatLine("          ,{0}", idFormula)
         Else
            .AppendFormatLine("          ,NULL")
         End If
         .AppendFormatLine("          ,{0} ", GetStringFromBoolean(automatico))

         .AppendFormatLine("          ,{0}", GetStringFromNumber(idEstadoVenta))

         If idOferta.HasValue AndAlso idOferta.Value > 0 Then
            .AppendFormatLine(" ,{0}", idOferta.Value)
         Else
            .AppendFormatLine(" ,NULL")
         End If

         If fechaDevolucion.HasValue Then
            .AppendFormatLine(" ,'{0}'", ObtenerFecha(fechaDevolucion.Value, True))
         Else
            .AppendFormatLine(" ,NULL")
         End If

         .AppendFormatLine(" ,{0}", GetStringFromBoolean(modificoPrecioManualmente))
         .AppendFormatLine(" ,{0}", conversion)
         .AppendFormatLine(" ,{0}", cantidadManual)
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
         .AppendFormatLine("           ,{0}", idDeposito)
         .AppendFormatLine("           ,{0}", idUbicacion)
         '--------------------------------------------------
         .Append(" )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasProductos")

   End Sub

   <Obsolete("No se estaría usando más", True)>
   Public Sub VentasProductosU(IdSucursal As Integer,
                                IdTipoComprobante As String,
                                Letra As String,
                                CentroEmisor As Integer,
                                NumeroComprobante As Long,
                                orden As Integer,
                                IdProducto As String,
                                Cantidad As Double,
                                Precio As Double,
                                Costo As Double,
                                DescRecGeneral As Double,
                                DescRecGeneralProducto As Double,
                                DescuentoRecargo As Double,
                                DescuentoRecargoProducto As Double,
                                DescuentoRecargoPorc As Double,
                                PrecioLista As Double,
                                PrecioNeto As Double,
                                Utilidad As Double,
                                ImporteTotal As Double,
                                ImporteTotalNeto As Double,
                                Kilos As Decimal,
                                PorcentajeIVA As Decimal,
                                ImporteImpuestoInterno As Decimal,
                                IdCentroCosto As Integer?,
                                tipoOperacion As String,
                                nota As String,
                                fechaDevolucion As Date?)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE VentasProductos SET ")
         .AppendLine("  Cantidad = " & Cantidad.ToString())
         .AppendLine("  ,Precio = " & Precio.ToString())
         .AppendLine("  ,Costo = " & Costo.ToString())
         .AppendLine("  ,DescRecGeneral = " & DescRecGeneral.ToString())
         .AppendLine("  ,DescRecGeneralProducto = " & DescRecGeneralProducto.ToString())
         .AppendLine("  ,DescuentoRecargo = " & DescuentoRecargo.ToString())
         .AppendLine("  ,DescuentoRecargoProducto = " & DescuentoRecargoProducto.ToString())
         .AppendLine("  ,DescuentoRecargoPorc = " & DescuentoRecargoPorc.ToString())
         .AppendLine("  ,PrecioLista = " & PrecioLista.ToString())
         .AppendLine("  ,PrecioNeto = " & PrecioNeto.ToString())
         .AppendLine("  ,Utilidad = " & Utilidad.ToString())
         .AppendLine("  ,ImporteTotal = " & ImporteTotal.ToString())
         .AppendLine("  ,ImporteTotalNeto = " & ImporteTotalNeto.ToString())
         .AppendLine("  ,Kilos = " & Kilos.ToString())
         .AppendLine("  ,PorcentajeIVA = " & PorcentajeIVA.ToString())
         .AppendLine("  ,ImporteImpuestoInterno = " & ImporteImpuestoInterno.ToString())
         If IdCentroCosto.HasValue AndAlso IdCentroCosto.Value > 0 Then
            .AppendLine("  ,IdCentroCosto = " & IdCentroCosto.Value.ToString())
         Else
            .AppendLine("  ,IdCentroCosto = NULL")
         End If

         .AppendFormat("  ,TipoOperacion = '{0}'", tipoOperacion).AppendLine()
         .AppendFormat("  ,Nota = '{0}'", nota).AppendLine()

         .AppendLine(" WHERE IdSucursal = " & IdSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & IdTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & Letra & "'")
         .AppendLine("   AND CentroEmisor = " & CentroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & NumeroComprobante.ToString())
         .AppendLine("   AND Orden = " & orden.ToString())
         .AppendLine("   AND IdProducto = '" & IdProducto & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasProductos")

   End Sub

   Public Sub VentasProductos_D(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroComprobante As Long,
                                orden As Integer,
                                idProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM VentasProductos ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
         'Pensado para borrar toda la tabla de una vez.
         If orden > 0 Then
            .AppendLine("   AND Orden = " & orden.ToString())
            .AppendLine("   AND IdProducto = '" & idProducto & "'")
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasProductos")

   End Sub

   Public Sub VentasProductos_D2(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM VentasProductos ")
         .Append("WHERE IdSucursal = " & idSucursal.ToString())
         .Append("  AND idTipoComprobante = '" & idTipoComprobante & "'")
         .Append("  AND CentroEmisor = " & centroEmisor.ToString())
         .Append("  AND Letra = '" & letra & "'")
         .Append("  AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasProductos")

   End Sub

   Public Function GetEstadVentasProductos(suc As List(Of Integer),
                                           cantidad As Integer,
                                           Desde As DateTime,
                                           Hasta As DateTime,
                                           idRubro As Entidades.Rubro(),
                                           idSubRubro As Entidades.SubRubro(),
                                           idMarca As Entidades.Marca(),
                                           idModelo As Int32,
                                           idCliente As Long,
                                           discIVA As Boolean,
                                           IdVendedor As Entidades.Empleado()) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      With stb
         .Length = 0
         .AppendLine("SELECT TOP " & cantidad.ToString())
         .AppendLine("	vp.IdProducto,")
         .AppendLine("	VP.NombreProducto,")
         .AppendLine("  SUM(vp.Cantidad) AS Cantidad,")

         If discIVA Then
            .AppendLine("  SUM(VP.ImporteTotalNeto) AS Importe")
         Else
            .AppendLine("  SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS Importe")
         End If

         .AppendLine(" FROM VentasProductos vp")
         .AppendLine(" INNER JOIN Ventas v ON v.IdSucursal = vp.IdSucursal ")
         .AppendLine("			AND v.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine("			AND v.Letra = vp.Letra ")
         .AppendLine("			AND v.CentroEmisor = vp.CentroEmisor")
         .AppendLine("			AND v.NumeroComprobante = vp.NumeroComprobante ")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto") ' AND P.AfectaStock = 'True'")
         .AppendLine("  WHERE TC.AfectaCaja = 'True' ")
         .AppendLine("    AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
         .AppendLine("    AND v.Fecha >= '" & Desde.ToString("yyyyMMdd") & " 00:00:00'")
         .AppendLine("    AND v.Fecha <= '" & Hasta.ToString("yyyyMMdd") & " 23:59:59'")

         GetListaMarcasMultiples(stb, idMarca, "P")
         GetListaRubrosMultiples(stb, idRubro, "P")
         GetListaSubRubrosMultiples(stb, idSubRubro, "P")
         GetListaEmpleadosMultiples(stb, IdVendedor, "V")

         If idModelo <> 0 Then
            .AppendFormat("	AND P.IdModelo = '{0}'", idModelo)
         End If

         If String.IsNullOrEmpty(sucur) Then
            .AppendFormat(" AND V.IdSucursal = 0")
         Else
            .AppendFormat(" AND V.IdSucursal IN ({0})", sucur)
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If

         '.AppendLine(" GROUP BY vp.IdProducto, P.NombreProducto")
         .AppendLine(" GROUP BY vp.IdProducto, VP.NombreProducto")
         .AppendLine(" ORDER BY Importe desc")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetTotalesPorProductosClientes(idSucursal As Integer,
                                                  desde As Date,
                                                  hasta As Date,
                                                  idMarca As Integer,
                                                  idModelo As Integer,
                                                  idRubro As Integer,
                                                  idSubRubro As Integer,
                                                  idZonaGeografica As String,
                                                  idTipoComprobante As String,
                                                  discIVA As Boolean,
                                                  tipoOperacion As Entidades.Producto.TiposOperaciones?,
                                                  nota As String,
                                                  nivelAutorizacion As Short) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT ")
         .AppendLine("	vp.IdProducto,")
         .AppendLine("	VP.NombreProducto,")
         .AppendLine("	P.Tamano,")
         .AppendLine("	P.IdUnidadDeMedida,")
         .AppendLine("	V.IdCliente,")
         .AppendLine("	C.CodigoCliente,")
         .AppendLine("	C.NombreCliente,")
         .AppendLine("  SUM(vp.Cantidad) AS Cantidad,")

         'RI
         If discIVA Then
            .AppendLine("  SUM(VP.ImporteTotalNeto) AS ImporteNeto,")
            .AppendLine(" SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteTotal,")
            'Monotributo
         Else
            .AppendLine("   SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) as ImporteNeto, ")
            .AppendLine("   SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) as ImporteTotal, ")
         End If

         .AppendLine("  SUM(VP.Kilos) AS Kilos")
         .AppendLine(" FROM VentasProductos vp")
         .AppendLine(" INNER JOIN Ventas v ON v.IdSucursal = vp.IdSucursal ")
         .AppendLine("			AND v.IdTipoComprobante = vp.IdTipoComprobante ")
         .AppendLine("			AND v.Letra = vp.Letra ")
         .AppendLine("			AND v.CentroEmisor = vp.CentroEmisor")
         .AppendLine("			AND v.NumeroComprobante = vp.NumeroComprobante ")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto") 'AND P.AfectaStock = 'True'")

         '.AppendLine("  WHERE v.Fecha >= '" & Desde.ToString("yyyyMMdd") & " 00:00:00'")
         '.AppendLine("    AND v.Fecha <= '" & Hasta.ToString("yyyyMMdd") & " 23:59:59'")
         .AppendLine(" WHERE V.Fecha >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("   AND V.Fecha <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         If idMarca <> 0 Then
            .AppendFormat("	AND P.IdMarca = '{0}'", idMarca)
         End If
         If idModelo <> 0 Then
            .AppendFormat("	AND P.IdModelo = '{0}'", idModelo)
         End If
         If idRubro <> 0 Then
            .AppendFormat("	AND P.IdRubro = '{0}'", idRubro)
         End If
         If idSubRubro <> 0 Then
            .AppendFormat("	AND P.IdSubRubro = '{0}'", idSubRubro)
         End If
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         'Si Eligio el comprobante no debe mirar los otros 2 puntos.
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormat(" AND V.IdTipoComprobante = '{0}'", idTipoComprobante)
         Else
            .AppendLine("  AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
            .AppendLine("  AND TC.AfectaCaja =  'True' ")

            'If afectaCaja <> "TODOS" Then
            '   .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
            'End If
         End If

         If tipoOperacion.HasValue Then
            .AppendFormat("  AND VP.TipoOperacion =  '{0}'", tipoOperacion.Value).AppendLine()
         End If

         If Not String.IsNullOrWhiteSpace(nota) Then
            .AppendFormat("  AND VP.Nota LIKE '%{0}%'", nota).AppendLine()
         End If

         'If String.IsNullOrEmpty(sucur) Then
         '   .AppendFormat(" AND V.IdSucursal = 0")
         'Else
         '   .AppendFormat(" AND V.IdSucursal IN ({0})", sucur)
         'End If

         'If IdCliente > 0 Then
         '   .AppendLine("	AND V.IdCliente = " & IdCliente.tostring() )
         'End If

         .AppendLine(" GROUP BY vp.IdProducto, VP.NombreProducto, P.Tamano, P.IdUnidadDeMedida, V.IdCliente, C.CodigoCliente, C.NombreCliente")
         .AppendLine(" ORDER BY VP.NombreProducto, vp.idproducto, C.NombreCliente, C.CodigoCliente")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetTotalesPorSubRubrosProductos(idSucursal As Integer, desde As Date, hasta As Date,
                                                   marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                                   rubros As Entidades.Rubro(), subRubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro(),
                                                   discIVA As Boolean) As DataTable
      'idMarca As Integer, idModelo As Integer, idRubro As Integer, idSubRubro As Integer,
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P.IdSubRubro")
         .AppendFormatLine("     , SR.NombreSubRubro")
         .AppendFormatLine("     , vp.IdProducto")
         .AppendFormatLine("     , VP.NombreProducto")
         .AppendFormatLine("     , SUM(vp.Cantidad) AS Cantidad")

         If discIVA Then
            .AppendFormatLine("     , SUM(VP.ImporteTotalNeto) AS ImporteNeto")
         Else
            .AppendFormatLine("     , SUM(VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno) AS ImporteNeto")
         End If

         .AppendFormatLine("     , SUM(VP.Kilos) AS Kilos")
         .AppendFormatLine("  FROM VentasProductos vp")
         .AppendFormatLine(" INNER JOIN Ventas v")
         .AppendFormatLine("         ON v.IdSucursal = vp.IdSucursal")
         .AppendFormatLine("        AND v.IdTipoComprobante = vp.IdTipoComprobante")
         .AppendFormatLine("        AND v.Letra = vp.Letra")
         .AppendFormatLine("        AND v.CentroEmisor = vp.CentroEmisor")
         .AppendFormatLine("        AND v.NumeroComprobante = vp.NumeroComprobante ")
         .AppendFormatLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendFormatLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto") ' AND P.AfectaStock = 'True'")
         .AppendFormatLine(" INNER JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendFormatLine(" WHERE TC.AfectaCaja = 'True' ")
         .AppendFormatLine("   AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
         .AppendFormatLine("   AND v.Fecha >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("   AND v.Fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))

         If marcas.AnySecure() Then GetListaMarcasMultiples(stb, marcas, "P")
         If modelos.AnySecure() Then GetListaModelosMultiples(stb, modelos, "P")
         If rubros.AnySecure() Then GetListaRubrosMultiples(stb, rubros, "P")
         If subRubros.AnySecure() Then GetListaSubRubrosMultiples(stb, subRubros, "P")
         If subSubRubros.AnySecure() Then GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

         'If idMarca <> 0 Then
         '   .AppendFormatLine("   AND P.IdMarca = '{0}'", idMarca)
         'End If
         'If idModelo <> 0 Then
         '   .AppendFormatLine("   AND P.IdModelo = '{0}'", idModelo)
         'End If
         'If idRubro <> 0 Then
         '   .AppendFormatLine("   AND P.IdRubro = '{0}'", idRubro)
         'End If
         'If idSubRubro <> 0 Then
         '   .AppendFormatLine("   AND P.IdSubRubro = '{0}'", idSubRubro)
         'End If

         'If String.IsNullOrEmpty(sucur) Then
         '   .AppendFormat(" AND V.IdSucursal = 0")
         'Else
         '   .AppendFormat(" AND V.IdSucursal IN ({0})", sucur)
         'End If

         '.AppendLine(" GROUP BY P.IdSubRubro, SR.NombreSubRubro, vp.idproducto, P.NombreProducto")
         '.AppendLine(" ORDER BY SR.NombreSubRubro, P.IdSubRubro, P.NombreProducto, vp.idproducto")

         .AppendFormatLine(" GROUP BY P.IdSubRubro, SR.NombreSubRubro, vp.idproducto, VP.NombreProducto")
         .AppendFormatLine(" ORDER BY SR.NombreSubRubro, P.IdSubRubro, VP.NombreProducto, vp.idproducto")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetListasPreciosVentasProductos() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT DISTINCT IdListaPrecios, NombreListaPrecios FROM VentasProductos ORDER BY NombreListaPrecios ASC")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetListasPreciosVentasProductosDescripcion() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT DISTINCT NombreListaPrecios FROM VentasProductos ORDER BY NombreListaPrecios ASC")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Protected Overridable Sub GetDetallePorProductos_CamposAdicionales(stb As StringBuilder)
   End Sub

   Public Overridable Function GetProductosNoVendidos(sucursales As IEnumerable(Of Entidades.Sucursal),
                                                      desde As Date?, hasta As Date?,
                                                      idProveedor As Long, idCliente As Long, idProducto As String, activoProducto As Entidades.Publicos.SiNoTodos,
                                                      marcas As IEnumerable(Of Entidades.Marca), rubros As IEnumerable(Of Entidades.Rubro),
                                                      subRubros As IEnumerable(Of Entidades.SubRubro), subSubRubros As IEnumerable(Of Entidades.SubSubRubro),
                                                      idListaPrecio As Integer, stockSN As Boolean, idVendedor As Integer, idZonaGeografica As String,
                                                      idCategoria As Integer, idLocalidad As Integer, idProvincia As String, idRuta As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT ")
         .AppendLine("     PRS.IdSucursal,")
         .AppendLine("     PRD.IdProducto,")
         .AppendLine("     PRD.NombreProducto,")
         .AppendLine("     PRS.Stock,")
         .AppendLine("     PRD.IdMoneda,  MND.NombreMoneda,")
         .AppendLine("     PSP.PrecioVenta,")
         .AppendLine("     PRS.PrecioCosto,")
         .AppendLine("     MRC.IdMarca, MRC.NombreMarca,")
         .AppendLine("     RBS.IdRubro, RBS.NombreRubro,")
         .AppendLine("     SRB.IdSubRubro, SRB.NombreSubRubro,")
         .AppendLine("     SSR.IdSubSubRubro, SSR.NombreSubSubRubro,")
         .AppendLine("     PVV.CodigoProveedor, PVV.NombreProveedor")
         .AppendLine("  FROM productos AS PRD")
         .AppendLine("  	INNER JOIN Monedas AS MND")
         .AppendLine("  		ON PRD.IdMoneda = MND.IdMoneda")
         .AppendLine("  	INNER JOIN Marcas AS MRC")
         .AppendLine("  		ON PRD.IdMarca = MRC.IdMarca")
         .AppendLine("  	INNER JOIN Rubros AS RBS")
         .AppendLine("  		ON PRD.IdRubro = RBS.IdRubro")
         .AppendLine("  	LEFT JOIN SubRubros AS SRB")
         .AppendLine("  		ON PRD.IdRubro = SRB.IdRubro  AND PRD.IdSubRubro = SRB.IdSubRubro")
         .AppendLine("  	LEFT JOIN SubSubRubros AS SSR")
         .AppendLine("  		ON PRD.IdSubRubro = SSR.IdSubRubro  AND PRD.IdSubSubRubro = SSR.IdSubSubRubro")
         .AppendLine("  	INNER JOIN ProductosSucursales AS PRS")
         .AppendLine("  		ON PRD.IdProducto = PRS.IdProducto")
         .AppendLine("  	INNER JOIN ProductosSucursalesPrecios AS PSP")
         .AppendLine("  		ON PRS.IdProducto = PSP.IdProducto AND PRS.IdSucursal = PSP.IdSucursal")
         .AppendLine("  	LEFT JOIN Proveedores AS PVV")
         .AppendLine("  		ON PRD.IdProveedor = PVV.IdProveedor")
         .AppendLine("  WHERE NOT EXISTS")
         .AppendLine("  		(SELECT")
         .AppendLine("  			VTP.IdProducto,")
         .AppendLine("  			VTA.Fecha")
         .AppendLine("  			FROM Ventas AS VTA")
         .AppendLine("           INNER JOIN Clientes C ON C.IdCliente = VTA.IdCliente
			                        INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad
			                        INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("  			INNER JOIN VentasProductos VTP")
         .AppendLine("  				ON VTP.IdSucursal = VTA.IdSucursal")
         .AppendLine("  				AND VTP.IdTipoComprobante = VTA.IdTipoComprobante")
         .AppendLine("  				AND VTP.Letra = VTA.Letra")
         .AppendLine("  				AND VTP.CentroEmisor = VTA.CentroEmisor")
         .AppendLine("  				AND VTP.NumeroComprobante = VTA.NumeroComprobante")
         .AppendLine("  			WHERE  ")
         '-------------------------------------------------------------------------------
         .AppendLine("  				       VTA.IdSucursal = PRS.IdSucursal")
         If idCliente > 0 Then
            .AppendFormatLine("	           AND VTA.IdCliente = {0}", idCliente)
         End If
         '-- Carga Valor de Fechas.- ----------------------------------------------------
         If desde.HasValue Then
            .AppendFormatLine("        AND VTA.Fecha >= '{0}'", ObtenerFecha(desde.Value, False))
         End If
         If hasta.HasValue Then
            .AppendFormatLine("        AND VTA.Fecha <= '{0}'", ObtenerFecha(hasta.Value.UltimoSegundoDelDia(), True))
         End If
         .AppendLine("  	  			   AND PRD.IdProducto = VTP.IdProducto")

         If idRuta > 0 Then
            .AppendFormatLine("  AND EXISTS (SELECT MRC.IdCliente")
            .AppendFormatLine("                FROM MovilRutasClientes MRC")
            .AppendFormatLine("               WHERE MRC.IdRuta = {0}", idRuta)
            .AppendFormatLine("                 AND MRC.IdCliente = VTA.IdCliente)")
         End If
         If idVendedor > 0 Then
            .AppendFormatLine("   AND VTA.IdVendedor = {0}", idVendedor)
         End If
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("   AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If idCategoria > 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If
         If idLocalidad > 0 Then
            .AppendFormatLine("   AND C.IdLocalidad = {0}", idLocalidad)
         End If
         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendFormatLine("   AND L.IdProvincia = '{0}'", idProvincia)
         End If
         .AppendFormatLine(")")

         '-------------------------------------------------------------------------------
         .AppendFormat("	AND PSP.IdListaPrecios = {0}", idListaPrecio)
         '-------------------------------------------------------------------------------
         .AppendLine("	   AND PRD.EsDeVentas = 1")
         If activoProducto <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND PRD.Activo = {0}", GetStringFromBoolean(activoProducto = Entidades.Publicos.SiNoTodos.SI))
         End If
         '-------------------------------------------------------------------------------
         If stockSN Then
            .AppendLine("	AND PRS.Stock > 0")
         End If
         '-------------------------------------------------------------------------------
         GetListaSucursalesMultiples(stb, sucursales, "PRS")
         GetListaMarcasMultiples(stb, marcas, "PRD")
         GetListaRubrosMultiples(stb, rubros, "PRD")
         GetListaSubRubrosMultiples(stb, subRubros, "PRD")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "PRD")
         '-------------------------------------------------------------------------------
         If idProveedor > 0 Then
            .AppendFormat("	AND PVV.IdProveedor = {0}", idProveedor)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("	AND PRD.IdProducto = '{0}'", idProducto)
         End If

         '-------------------------------------------------------------------------------
         .AppendLine("  ORDER BY PRD.NombreProducto, PRS.IdSucursal")
      End With
      Return GetDataTable(stb)
   End Function
   Public Overridable Function GetDetallePorProductos(
                      sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                      idProducto As String, idMarca As Integer, idModelo As Integer, idRubro As Integer, idSubRubro As Integer, idSubSubRubro As Integer,
                      idZonaGeografica As String,
                      idTipoComprobante As String,
                      idVendedor As Integer, vendedor As Entidades.OrigenFK, idCliente As Long,
                      grabaLibro As String, afectaCaja As String, idFormaDePago As Integer, idUsuario As String,
                      porcUtilidadDesde As Decimal, porcUtilidadHasta As Decimal,
                      cantidad As String, ingresosBrutos As String, prodDescRec As String,
                      idProveedor As Long, idLocalidad As Integer, idProvincia As String,
                      idCategoria As Integer, listaPrecios As String, categoria As Entidades.OrigenFK,
                      listaComp As List(Of Entidades.TipoComprobante),
                      esComercial As Boolean?, idTransportista As Integer,
                      tipoOperacion As Entidades.Producto.TiposOperaciones?,
                      nota As String,
                      letra As String, centroEmisor As Short, numeroComprobante As Long,
                      cajas As Entidades.CajaNombre(),
                      idListaPrecios As Integer,
                      nivelAutorizacion As Short,
                      grupo As String,
                      idPaciente As Long?, idDoctor As Long?, fechaCirugia As Date?,
                      cliente As Entidades.Cliente.ClienteVinculado,
                      productoEsComercial As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT V.Fecha")
         .AppendLine("      ,V.IdSucursal")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,TC.DescripcionAbrev ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,V.IdVendedor ")
         .AppendLine("      ,E.NombreEmpleado")
         .AppendLine("      ,V.IdTransportista")
         .AppendLine("      ,TR.NombreTransportista")
         .AppendLine("      ,V.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,C.NombreCliente ")
         '-- REQ-34155.- -----------------------
         .AppendLine("      ,C.Telefono as TelefonoCliente ")
         '--------------------------------------
         .AppendLine("      ,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .AppendLine("      ,V.IdEstadoComprobante")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("      ,VP.IdProducto")
         .AppendLine("      ,VP.Orden")
         .AppendLine("      ,P.Tamano")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,P.CodigoDeBarras")
         .AppendLine("      ,VP.NombreProducto")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,SR.NombreSubRubro")
         .AppendLine("      ,SSR.NombreSubSubRubro")
         .AppendLine("      ,VP.Cantidad")

         .AppendLine("      ,VP.Precio")


         .AppendFormat(" ,{0} as PrecioConIva", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Precio", "VP.AlicuotaImpuesto",
                                                                        "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                        "VP.OrigenPorcImpInt"))

         .AppendLine("      ,VP.PrecioLista")
         .AppendFormat(" ,{0} as PrecioListaConIva", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.PrecioLista", "VP.AlicuotaImpuesto",
                                                                                "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                                "VP.OrigenPorcImpInt"))

         .AppendLine("      ,VP.PrecioNeto")
         .AppendFormat(" ,{0} as PrecioNetoConIva", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.PrecioNeto", "VP.AlicuotaImpuesto",
                                                                              "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                              "VP.OrigenPorcImpInt"))


         .AppendLine("      ,VP.DescRecGeneral")
         .AppendLine("      ,VP.DescuentoRecargo")

         .AppendLine("      ,VP.DescuentoRecargoPorc")
         .AppendLine("      ,VP.DescuentoRecargoPorc2")
         .AppendLine("      ,VP.DescuentoRecargoProducto")
         .AppendLine("      ,V.DescuentoRecargoPorc AS DescuentoRecargoPorcGral")

         'If discIVA Then
         .AppendLine("      ,CONVERT(DECIMAL(10,2),((VP.Precio * VP.DescuentoRecargoPorc) / 100)) as ImporteDR1") '-.PE-32144.-
         .AppendLine("      ,CONVERT(DECIMAL(10,2),(((VP.Precio + (VP.Precio * VP.DescuentoRecargoPorc) /100) * VP.DescuentoRecargoPorc2) / 100)) as ImporteDR2") '-.PE-32144.-
         .AppendLine("      ,CONVERT(DECIMAL(10,2),(( ( VP.Precio + (VP.Precio * VP.DescuentoRecargoPorc) / 100) + ((VP.Precio + (VP.Precio * VP.DescuentoRecargoPorc) /100) * VP.DescuentoRecargoPorc2) / 100) * V.DescuentoRecargoPorc) / 100) as ImporteDRGral") '-.PE-32144.-
         'Else
         .AppendFormatLine("      ,CONVERT(DECIMAL(10,2),{0}) as ImporteDR1ConIva",
                          CalculosImpositivos.ObtenerPrecioConImpuestos("((VP.Precio * VP.DescuentoRecargoPorc) / 100)",
                                                                        "VP.AlicuotaImpuesto", "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt"))
         .AppendFormatLine("      ,CONVERT(DECIMAL(10,2),{0}) as ImporteDR2ConIva",
                           CalculosImpositivos.ObtenerPrecioConImpuestos("(((VP.Precio + (VP.Precio * VP.DescuentoRecargoPorc) /100) * VP.DescuentoRecargoPorc2) / 100)",
                                                                         "VP.AlicuotaImpuesto", "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt"))

         .AppendFormatLine("      ,CONVERT(DECIMAL(10,2),{0}) as ImporteDRGralConIva",
                           CalculosImpositivos.ObtenerPrecioConImpuestos("((( VP.Precio + (VP.Precio * VP.DescuentoRecargoPorc) / 100) + ((VP.Precio + (VP.Precio * VP.DescuentoRecargoPorc) /100) * VP.DescuentoRecargoPorc2) / 100) * V.DescuentoRecargoPorc) / 100",
                                                                         "VP.AlicuotaImpuesto", "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt"))
         'End If

         .AppendLine("      ,VP.ImporteTotal")

         '# Cálculos correspondientes de si la empresa correspondiente que realizo la venta discrimina o no IVA
         .AppendFormatLine("      , CASE WHEN CFE.IvaDiscriminado = 1 THEN VP.Costo ELSE {0} END AS Costo",
                                          CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Costo", "VP.AlicuotaImpuesto",
                                                                                        "VP.PorcImpuestoInterno",
                                                                                        "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt"))
         .AppendFormatLine("      , CASE WHEN CFE.IvaDiscriminado = 1 THEN VP.Utilidad ELSE {0} END AS Utilidad",
                                          CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Utilidad", "VP.AlicuotaImpuesto",
                                                                                        "VP.PorcImpuestoInterno",
                                                                                        "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt"))
         .AppendFormatLine("      , CASE WHEN CFE.IvaDiscriminado = 1 THEN VP.ImporteTotalNeto ELSE VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno END AS ImporteTotalNeto")
         .AppendFormatLine("      , CASE WHEN CFE.IvaDiscriminado = 1 THEN VP.ImporteImpuesto ELSE 0 END AS ImporteImpuesto")
         .AppendFormatLine("      , CASE WHEN CFE.IvaDiscriminado = 1 THEN VP.ImporteImpuestoInterno ELSE 0 END AS ImporteImpuestoInterno")
         .AppendFormatLine("      , CASE WHEN CFE.IvaDiscriminado = 1 THEN {0} ELSE VP.Costo END AS CostoConImpuestos",
                                       CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Costo", "VP.AlicuotaImpuesto",
                                                                                     "VP.PorcImpuestoInterno",
                                                                                     "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt"))
         .AppendFormatLine("      , CASE WHEN CFE.IvaDiscriminado = 1 THEN {0} ELSE VP.Utilidad END AS UtilidadConImpuestos",
                                       CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Utilidad", "VP.AlicuotaImpuesto",
                                                                                     "VP.PorcImpuestoInterno",
                                                                                     "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt"))
         .AppendFormatLine("      ,VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno as ImporteTotalNetoConImpuestos")

         'If discIVA Then
         '   'CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Costo", "VP.AlicuotaImpuesto",
         '   '                                              "VP.PorcImpuestoInterno",
         '   '                                              "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt")).AppendLine()
         '   '.AppendFormat("      ,{0} AS UtilidadConImpuestos",
         '   '     CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Utilidad", "VP.AlicuotaImpuesto",
         '   '                                                   "VP.PorcImpuestoInterno",
         '   '                                                   "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt")).AppendLine()

         'Else
         '   .AppendFormat("      ,{0}  AS Costo",
         'CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Costo", "VP.AlicuotaImpuesto",
         '                                              "VP.PorcImpuestoInterno",
         '                                              "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt")).AppendLine()
         '   .AppendFormat("      ,{0} AS Utilidad",
         '        CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Utilidad", "VP.AlicuotaImpuesto",
         '                                                      "VP.PorcImpuestoInterno",
         '                                                      "P.ImporteImpuestoInterno", "VP.OrigenPorcImpInt")).AppendLine()
         '   ' .AppendLine("      ,VP.Utilidad+VP.ImporteImpuesto+VP.ImporteImpuestoInterno as Utilidad")
         '   .AppendLine("      ,VP.ImporteTotalNeto+VP.ImporteImpuesto+VP.ImporteImpuestoInterno as ImporteTotalNeto")
         '   .AppendLine("      ,0 as ImporteImpuesto")
         '   .AppendLine("      ,0 AS ImporteImpuestoInterno")

         'End If

         '.AppendLine("      ,VP.ImporteTotal")

         .AppendLine("      ,VP.IdTipoImpuesto")
         .AppendLine("      ,VP.AlicuotaImpuesto")
         .AppendLine("      ,VP.Kilos")
         .AppendLine("      ,V.Usuario")
         .AppendLine("      ,E.NombreEmpleado")
         .AppendLine("      ,ZG.NombreZonaGeografica")

         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,PV.NombreProvincia")
         .AppendLine("      ,VP.NombreListaPrecios")
         .AppendLine("      ,CA.NombreCategoria")

         .AppendLine("      ,VP.IdCentroCosto")
         .AppendLine("      ,CCC.NombreCentroCosto")
         .AppendLine("      ,V.Observacion")
         .AppendLine("      ,P.Observacion as DetalleProducto")

         .AppendLine("      ,VP.TipoOperacion")
         .AppendLine("      ,VP.Nota")
         .AppendLine("      ,VP.NombreCortoListaPrecios")

         .AppendLine("      ,VP.IdFormula")
         .AppendLine("      ,PF.NombreFormula")
         .AppendLine("      ,CN.NombreCaja")

         .AppendLine("      ,VP.Automatico")
         .AppendLine("      ,VP.IdEstadoVenta")
         .AppendLine("      ,EV.NombreEstadoVenta")
         .AppendLine("      ,P.NombreProducto As NombreActualProducto")
         .AppendLine("      ,V.Direccion")

         .AppendLine("      ,(SELECT COUNT(1) FROM VentasProductosFormulas VPF")
         .AppendLine("         WHERE VPF.IdSucursal = V.IdSucursal")
         .AppendLine("           AND VPF.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("           AND VPF.Letra = V.Letra")
         .AppendLine("           AND VPF.CentroEmisor = V.CentroEmisor")
         .AppendLine("           AND VPF.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("           AND VPF.IdProducto = VP.IdProducto")
         .AppendLine("           AND VPF.Orden = VP.Orden")
         .AppendLine("           AND VPF.Cantidad <> 0) CantComponentes")

         .AppendFormatLine("      ,V.IdPaciente")
         .AppendFormatLine("      ,PAC.NombreCliente NombrePaciente")
         .AppendFormatLine("      ,V.IdDoctor")
         .AppendFormatLine("      ,DOC.NombreCliente NombreDoctor")
         .AppendFormatLine("      ,V.FechaCirugia")
         .AppendFormatLine("      ,VP.Conversion")
         .AppendFormatLine("      ,VP.CantidadManual")
         .AppendFormatLine("      ,VP.ModificoPrecioManualmente")
         '-- REQ-35221.- ----------------------------------------------------------
         .AppendFormatLine(" , (CASE WHEN VP.IdaAtributoProducto01 IS NULL THEN 0  ELSE AP01.IdaAtributoProducto END) AS IdaAtributoProducto01")
         .AppendFormatLine(" , (CASE WHEN VP.IdaAtributoProducto01 IS NULL THEN '' ELSE AP01.Descripcion END) AS DescripcionAtributo01")
         '--                              
         .AppendFormatLine(" , (CASE WHEN VP.IdaAtributoProducto02 IS NULL THEN 0  ELSE AP02.IdaAtributoProducto END) AS IdaAtributoProducto02")
         .AppendFormatLine(" , (CASE WHEN VP.IdaAtributoProducto02 IS NULL THEN '' ELSE AP02.Descripcion END) AS DescripcionAtributo02")
         '--                              
         .AppendFormatLine(" , (CASE WHEN VP.IdaAtributoProducto03 IS NULL THEN 0  ELSE AP03.IdaAtributoProducto END) AS IdaAtributoProducto03")
         .AppendFormatLine(" , (CASE WHEN VP.IdaAtributoProducto03 IS NULL THEN '' ELSE AP03.Descripcion END) AS DescripcionAtributo03")
         '---                             
         .AppendFormatLine(" , (CASE WHEN VP.IdaAtributoProducto04 IS NULL THEN 0  ELSE AP04.IdaAtributoProducto END) AS IdaAtributoProducto04")
         .AppendFormatLine(" , (CASE WHEN VP.IdaAtributoProducto04 IS NULL THEN '' ELSE AP04.Descripcion END) AS DescripcionAtributo04")
         '-------------------------------------------------------------------------
         GetDetallePorProductos_CamposAdicionales(stb)

         .AppendFormatLine("      , Prov.NombreProveedor AS ProveedorHabitual")
         .AppendFormatLine("      , PPR.CodigoProductoProveedor AS CodigoProductoProveedor")
         .AppendFormatLine("      , ProvOC.NombreProveedor AS ProveedorOC")
         .AppendFormatLine("      , V.NumeroOrdenCompra")
         .AppendFormatLine("      , VIN.NombreCliente NombreClienteVinculado")

         .AppendLine(" FROM VentasProductos VP")
         .AppendLine(" INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal ")
         .AppendLine("			AND V.IdTipoComprobante = VP.IdTipoComprobante ")
         .AppendLine("			AND V.Letra = VP.Letra ")
         .AppendLine("			AND V.CentroEmisor = VP.CentroEmisor")
         .AppendLine("			AND V.NumeroComprobante = VP.NumeroComprobante ")

         '# Obtengo la categoría fiscal de la empresa que realizó la venta
         .AppendFormatLine(" INNER JOIN (SELECT P.IdEmpresa, S.Id IdSucursal, CFC.IdCategoriaFiscalCliente, CFC.IvaDiscriminado FROM Parametros P ")
         .AppendFormatLine("			   LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON P.ValorParametro = CFC.IdCategoriaFiscalEmpresa AND P.ValorParametro = CFC.IdCategoriaFiscalCliente")
         .AppendFormatLine("			   LEFT JOIN Sucursales S ON S.IdEmpresa = P.IdEmpresa")
         .AppendFormatLine("			   WHERE P.IdParametro = 'CATEGORIAFISCALEMPRESA' ) CFE ON CFE.IdSucursal = V.IdSucursal")

         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" LEFT JOIN Clientes PAC ON V.IdPaciente = PAC.IdCliente ")
         .AppendLine(" LEFT JOIN Clientes DOC ON V.IdDoctor = DOC.IdCliente ")
         .AppendLine(" LEFT JOIN Clientes VIN ON V.IdClienteVinculado = VIN.IdCliente ")

         .AppendLine("  LEFT JOIN Transportistas TR ON TR.IdTransportista = V.IdTransportista")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto") 'AND P.AfectaStock = 'True'")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine("  LEFT JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
         .AppendLine("  LEFT JOIN SubSubRubros SSR ON SSR.IdSubSubRubro = P.IdSubSubRubro")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         ' .AppendLine(" INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = V.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias PV ON PV.IdProvincia = L.IdProvincia")

         If idProveedor > 0 Then
            .AppendLine("	INNER JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto")
            .AppendLine("	INNER JOIN Proveedores PR ON PR.IdProveedor = PP.IdProveedor ")
         End If

         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor  ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         End If

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         Else
            .AppendLine("   INNER JOIN Categorias CA ON CA.IdCategoria = V.IdCategoria")
         End If

         .AppendLine("  LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = VP.IdCentroCosto ")
         .AppendLine("  LEFT JOIN ProductosFormulas PF ON PF.IdFormula = VP.IdFormula  AND PF.IdProducto = VP.IdProducto")
         .AppendLine("  LEFT JOIN CajasNombres CN ON CN.IdCaja = V.IdCaja AND CN.IdSucursal = V.IdSucursal")

         .AppendLine("  LEFT JOIN EstadosVenta EV ON EV.IdEstadoVenta = VP.IdEstadoVenta")
         '-- REQ-35222.- ----------------------------------------------------------
         .AppendLine("  LEFT JOIN AtributosProductos AP01 ON AP01.IdaAtributoProducto = VP.IdaAtributoProducto01")
         .AppendLine("  LEFT JOIN AtributosProductos AP02 ON AP02.IdaAtributoProducto = VP.IdaAtributoProducto02")
         .AppendLine("  LEFT JOIN AtributosProductos AP03 ON AP03.IdaAtributoProducto = VP.IdaAtributoProducto03")
         .AppendLine("  LEFT JOIN AtributosProductos AP04 ON AP04.IdaAtributoProducto = VP.IdaAtributoProducto04")
         '-------------------------------------------------------------------------

         .AppendLine("  LEFT JOIN Proveedores Prov ON Prov.IdProveedor = P.IdProveedor")
         .AppendLine("  LEFT JOIN ProductosProveedores PPR ON PPR.IdProveedor = Prov.IdProveedor And PPR.IdProducto = P.IdProducto")
         .AppendLine("  LEFT JOIN OrdenesCompra OC ON OC.NumeroOrdenCompra = V.NumeroOrdenCompra")
         .AppendLine("  LEFT JOIN Proveedores ProvOC ON ProvOC.IdProveedor = OC.IdProveedor")


         .AppendLine("  WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "V")
         GetListaMultiples(stb, cajas, "V")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CA", "TC", nivelAutorizacion)

         .AppendLine("    AND V.Fecha >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("    AND V.Fecha <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If idListaPrecios > -1 Then
            .AppendFormat("   AND VP.IdListaPrecios = {0}", idListaPrecios).AppendLine()
         End If

         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("	AND V.Letra = '{0}'", letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("	AND V.CentroEmisor = {0}", centroEmisor)
         End If
         If numeroComprobante > 0 Then
            .AppendFormatLine("	AND V.NumeroComprobante = {0}", numeroComprobante)
         End If

         If esComercial.HasValue Then
            .AppendLine(" AND TC.EsComercial = " & IIf(esComercial.Value, "1", "0").ToString())
         End If
         If productoEsComercial <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND P.EsComercial = {0}", GetStringFromBoolean(productoEsComercial = Entidades.Publicos.SiNoTodos.SI))
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat("	AND P.idproducto = '{0}'", idProducto)
         End If

         If idMarca <> 0 Then
            .AppendFormat("	AND P.IdMarca = {0}", idMarca)
         End If

         If idModelo <> 0 Then
            .AppendFormat("	AND P.IdModelo = {0}", idModelo)
         End If

         If idRubro <> 0 Then
            .AppendFormat("	AND P.IdRubro = {0}", idRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormat("	AND P.IdSubRubro = {0}", idSubRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormat("	AND P.IdSubSubRubro = {0}", idSubSubRubro)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idVendedor > 0 Then
            .AppendLine("	AND E.IdEmpleado = " & idVendedor)
         End If

         'If idCliente <> 0 Then
         '   .AppendLine("	AND C.IdCliente= " & idCliente)
         'End If

         If idCliente > 0 Then
            If cliente = Entidades.Cliente.ClienteVinculado.Vinculado Then
               .AppendLine("  AND V.IdClienteVinculado = " & idCliente.ToString())
            Else
               .AppendLine("	AND V.IdCliente = " & idCliente.ToString())
            End If
         End If


         If idTransportista > 0 Then
            .AppendLine("	AND V.IdTransportista = " & idTransportista.ToString())
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If afectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(afectaCaja = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) And listaComp Is Nothing Then
            .AppendLine("	AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If listaComp IsNot Nothing AndAlso listaComp.Count > 0 Then
            .Append(" AND V.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComp
               .AppendFormat(" '{0}',", tc.IdTipoComprobante)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If idFormaDePago > 0 Then
            .AppendLine("	AND V.IdFormasPago = " & idFormaDePago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	AND V.Usuario = '" & idUsuario & "'")
         End If

         If porcUtilidadDesde >= 0 Then
            .AppendLine("	AND ROUND(VP.Utilidad/VP.ImporteTotalNeto*100,2) BETWEEN " & porcUtilidadDesde.ToString() & " AND " & porcUtilidadHasta.ToString())
         End If

         If Not String.IsNullOrEmpty(cantidad) Then
            .AppendLine("   AND VP.Cantidad " & cantidad)
         End If

         If ingresosBrutos <> "TODOS" Then
            .AppendLine("      AND P.PagaIngresosBrutos = " & IIf(ingresosBrutos = "SI", "1", "0").ToString())
         End If

         If prodDescRec <> "TODOS" Then
            .AppendLine("     AND (ABS(VP.PrecioLista-VP.Precio) " & IIf(prodDescRec = "SI", "> 0.02 OR", "<= 0.02 AND").ToString()) 'No puedo poner 0 porque por redondeo del IVA hay diferencias
            .AppendLine("      VP.DescuentoRecargoPorc " & IIf(prodDescRec = "SI", "<> 0 OR", "= 0 AND").ToString())
            .AppendLine("      VP.DescRecGeneral " & IIf(prodDescRec = "SI", "<> 0 OR", "= 0 AND").ToString())
            .AppendLine("      VP.DescuentoRecargoPorc2 " & IIf(prodDescRec = "SI", "<> 0)", "= 0)").ToString())
         End If

         If idProveedor > 0 Then
            .AppendFormatLine("	AND PR.IdProveedor = {0}", idProveedor)
         End If

         If idLocalidad > 0 Then
            .AppendFormatLine("	AND V.IdLocalidad = {0}", idLocalidad)
         End If

         '# Filtros de Historia Clínica
         If idPaciente.HasValue Then
            .AppendFormatLine("  AND V.IdPaciente = {0}", idPaciente.Value)
         End If
         If idDoctor.HasValue Then
            .AppendFormatLine("  AND V.IdDoctor = {0}", idDoctor.Value)
         End If
         If fechaCirugia.HasValue Then
            Dim fechaDesde = ObtenerFecha(UltimoSegundoDelDia(fechaCirugia.Value).AddDays(-1).AddSeconds(1), True)
            Dim fechaHasta = ObtenerFecha(UltimoSegundoDelDia(fechaCirugia.Value), True)
            .AppendFormatLine("  AND V.FechaCirugia >= '{0}'", fechaDesde)
            .AppendFormatLine("  AND V.FechaCirugia <= '{0}'", fechaHasta)
         End If
         '------------------------------

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendFormatLine("	AND L.IdProvincia = '{0}'", idProvincia)
         End If

         'If idCategoria > 0 Then
         '    If categoria <> "MOVIMIENTO" Then
         '        .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
         '    Else
         '        .AppendLine("   AND V.IdCategoria = " & idCategoria.ToString())
         '    End If
         'End If

         If idCategoria > 0 Then
            .AppendFormatLine("   AND CA.IdCategoria = {0}", idCategoria)
         End If

         If Not String.IsNullOrEmpty(listaPrecios) Then
            .AppendFormatLine("	AND VP.NombreListaPrecios = '{0}'", listaPrecios)
         End If

         If tipoOperacion.HasValue Then
            .AppendFormatLine("  AND VP.TipoOperacion =  '{0}'", tipoOperacion.Value)
         End If

         If Not String.IsNullOrWhiteSpace(nota) Then
            .AppendFormatLine("  AND VP.Nota LIKE '%{0}%'", nota)
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendFormatLine("	AND TC.Grupo = '{0}'", grupo)
         End If

         'Se creo el IX_Ventas_Fecha para mejorar (notablemente) el tiempo de la consulta
         ''Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.AppendLine("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         '.AppendLine("	,V.IdTipoComprobante")
         '.AppendLine("	,V.Letra")
         '.AppendLine("	,V.CentroEmisor")
         '.AppendLine("	,V.NumeroComprobante")

         .AppendLine("	ORDER BY V.Fecha desc")
         .AppendLine("	,VP.NombreProducto")
         .AppendLine("	,VP.IdProducto")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetUltimoDeProducto(IdSucursal As Integer,
                                      IdTipoComprobante As String,
                                      idProducto As String,
                                       IdCliente As Long) As Decimal

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT TOP (1) V.Fecha")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,VP.IdProducto")
         .AppendLine("      ,VP.PrecioNeto")

         .AppendLine(" FROM VentasProductos VP")
         .AppendLine(" INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal ")
         .AppendLine("			AND V.IdTipoComprobante = VP.IdTipoComprobante ")
         .AppendLine("			AND V.Letra = VP.Letra ")
         .AppendLine("			AND V.CentroEmisor = VP.CentroEmisor")
         .AppendLine("			AND V.NumeroComprobante = VP.NumeroComprobante ")

         .AppendLine("  WHERE VP.IdSucursal = " & IdSucursal.ToString())

         If Not String.IsNullOrEmpty(IdTipoComprobante) Then
            .AppendLine("	AND VP.IdTipoComprobante = '" & IdTipoComprobante & "'")
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendLine("	AND VP.idproducto = '" & idProducto & "'")
         End If

         If IdCliente > 0 Then
            .AppendLine("	AND V.IdCliente = " & IdCliente.ToString())
         End If

         .AppendLine("	ORDER BY V.Fecha DESC")
      End With

      'End If

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return Decimal.Round(Decimal.Parse(dt.Rows(0)("PrecioNeto").ToString()), 2)
      Else
         Return 0
      End If

   End Function

   Public Function UltimaVentaDelProducto(idCliente As Long, idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("SELECT TOP 1 VP.*")
         .AppendFormatLine("     , VP.Precio PrecioVentaSinIVA")
         .AppendFormatLine("     , {0} PrecioVentaConIVA", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Precio", "VP.AlicuotaImpuesto", "VP.PorcImpuestoInterno", "PR.ImporteImpuestoInterno", "VP.OrigenPorcImpInt"))
         .AppendFormatLine("  FROM VentasProductos VP")
         .AppendFormatLine(" INNER JOIN Ventas V ON V.IdSucursal = VP.IdSucursal")
         .AppendFormatLine("                    AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendFormatLine("                    AND V.Letra = VP.Letra")
         .AppendFormatLine("                    AND V.CentroEmisor = VP.CentroEmisor")
         .AppendFormatLine("                    AND V.NumeroComprobante = VP.NumeroComprobante")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine(" INNER JOIN Productos PR ON PR.IdProducto = VP.IdProducto")
         .AppendFormatLine(" CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'FACTURACIONTIPOCOMPROBANTEENVIADOCAJERO') P")
         .AppendFormatLine(" WHERE TC.CoeficienteValores > 0")
         .AppendFormatLine("   AND VP.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         .AppendFormatLine("   AND NOT P.ValorParametro LIKE '%' + TC.IdTipoComprobante + '%'")
         .AppendFormatLine(" ORDER BY V.Fecha DESC")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetDetallePorComprobante(drComps As List(Of DataRow)) As DataTable
      Dim condiciones = drComps.ConvertAll(
                              Function(dr) String.Format("(IdSucursal = {0} AND IdTipoComprobante = '{1}' AND Letra = '{2}' AND CentroEmisor = {3} AND NumeroComprobante = {4})",
                                                         dr.Field(Of Integer)("IdSucursal"),
                                                         dr.Field(Of String)("IdTipoComprobante"),
                                                         dr.Field(Of String)("Letra"),
                                                         dr.Field(Of Integer)("CentroEmisor"),
                                                         dr.Field(Of Long)("NumeroComprobante")))
      Dim condicionOR = String.Join(" OR ", condiciones)

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT VP.IdProducto, VP.NombreProducto, VP.Cantidad")
         .AppendFormatLine("  FROM VentasProductos VP")
         If Not String.IsNullOrWhiteSpace(condicionOR) Then
            .AppendFormatLine(" WHERE ({0})", condicionOR)
         Else
            .AppendFormatLine(" WHERE 1 = 2")
         End If
         .AppendFormatLine(" ORDER BY VP.NombreProducto")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetDetallePorComprobante(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Short,
                                            numerosComprobantes() As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      Dim numerosCompr As String = String.Empty
      For Each num As Long In numerosComprobantes
         numerosCompr += num.ToString() + ","
      Next
      numerosCompr = numerosCompr.Remove(numerosCompr.Length - 1, 1)
      With stb
         .Append("SELECT VP.NombreProducto, VP.Cantidad")
         .Append(" FROM VentasProductos VP")
         .AppendFormat(" WHERE VP.IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND VP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat(" AND VP.Letra = '{0}'", letra)
         .AppendFormat(" AND VP.CentroEmisor = {0}", centroEmisor)
         .AppendFormat(" AND VP.NumeroComprobante IN ({0})", numerosCompr)
         .AppendLine(" ORDER BY VP.NombreProducto")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetNombresProductos(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Short,
                                             numerosComprobante As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Append("SELECT VP.NombreProducto")
         .Append(" FROM VentasProductos VP")
         .AppendFormat(" WHERE VP.IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND VP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat(" AND VP.Letra = '{0}'", letra)
         .AppendFormat(" AND VP.CentroEmisor = {0}", centroEmisor)
         .AppendFormat(" AND VP.NumeroComprobante = {0}", numerosComprobante)
         .AppendLine(" ORDER BY VP.NombreProducto")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetDetalleCompletoPorComprobante(idSucursal As Integer,
                                                    idTipoComprobante As String,
                                                    letra As String,
                                                    centroEmisor As Short,
                                                    numeroComprobante As Long,
                                                    miraOrdenProductos As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Length = 0
         .AppendLine("SELECT VP.IdSucursal")
         .AppendLine("      ,VP.IdTipoComprobante")
         .AppendLine("      ,VP.Letra")
         .AppendLine("      ,VP.CentroEmisor")
         .AppendLine("      ,VP.NumeroComprobante")
         .AppendLine("      ,VP.Orden")
         .AppendLine("      ,VP.IdProducto")
         .AppendLine("	    ,VP.NombreProducto")
         .AppendLine("      ,VP.Cantidad")
         .AppendLine("	    ,PS.Stock")
         .AppendLine("      ,VP.Costo")
         .AppendLine("      ,VP.PrecioLista")
         .AppendLine("      ,VP.Precio")
         .AppendLine("      ,VP.DescRecGeneral")
         .AppendLine("      ,VP.DescuentoRecargo")
         .AppendLine("      ,VP.DescuentoRecargoProducto")
         .AppendLine("      ,VP.DescuentoRecargoPorc ")
         .AppendLine("      ,VP.DescuentoRecargoPorc2 ")
         .AppendLine("      ,VP.DescRecGeneralProducto ")
         .AppendLine("      ,VP.PrecioNeto")
         .AppendLine("      ,VP.Utilidad")
         .AppendLine("      ,VP.ImporteTotal")
         .AppendLine("      ,VP.ImporteTotalNeto")
         .AppendLine("      ,VP.Kilos")
         .AppendLine("      ,VP.IdTipoImpuesto")
         .AppendLine("      ,VP.AlicuotaImpuesto")
         .AppendLine("      ,P.Alicuota")
         .AppendLine("      ,VP.ImporteImpuesto")
         .AppendLine("      ,VP.ComisionVendedor")
         .AppendLine("      ,VP.ComisionVendedorPorc")
         .AppendLine("      ,VP.IdListaPrecios")
         .AppendLine("      ,VP.NombreListaPrecios")
         .AppendLine("      ,VP.ImporteImpuestoInterno")
         .AppendLine("      ,VP.IdCentroCosto")
         .AppendLine("      ,CCC.NombreCentroCosto")
         .AppendLine("      ,VP.NombreCortoListaPrecios")
         .AppendLine("      ,MA.NombreMarca")
         .AppendLine("      ,MO.NombreModelo")
         .AppendLine("      ,M.NombreMoneda")
         .AppendLine("      ,VP.Conversion")
         .AppendLine("      ,VP.CantidadManual")
         .AppendLine("      ,VP.ModificoPrecioManualmente")
         .AppendLine("  FROM VentasProductos VP")
         .AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = VP.IdProducto AND PS.IdSucursal = " & idSucursal.ToString())
         .AppendFormatLine("  INNER JOIN Productos P ON PS.IdProducto = P.IdProducto")
         .AppendLine("  LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = VP.IdCentroCosto ")
         .AppendFormatLine(" LEFT JOIN Monedas M ON P.IdMoneda = M.IdMoneda")
         .AppendFormatLine(" LEFT JOIN Marcas MA ON P.IdMarca = MA.IdMarca")
         .AppendFormatLine(" LEFT JOIN Modelos MO ON P.IdModelo = MO.IdModelo")
         .AppendLine(" WHERE VP.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND VP.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND VP.Letra = '" & letra & "'")
         .AppendLine("   AND VP.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND VP.NumeroComprobante = " & numeroComprobante.ToString())
         If miraOrdenProductos Then
            .AppendLine(" ORDER BY P.Orden, VP.Orden")
         Else
            .AppendLine(" ORDER BY VP.Orden")
         End If
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Sub VentasProductos_UDescripcion(IdProducto As String, NombreProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE VentasProductos SET ")
         .AppendLine("  NombreProducto = '" & NombreProducto.ToString() & "'")
         .AppendLine("  FROM VentasProductos VP ")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine(" WHERE IdProducto = '" & IdProducto & "'")
         .AppendLine(" AND (TC.EsElectronico = 'False' OR TC.EsPREElectronico = 'True' ) ")
         .AppendLine(" AND TC.EsFiscal = 'False'")

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "VentasProductos")

   End Sub

   Public Function GetComisionesPorProducto(sucursales As Entidades.Sucursal(),
                                           Desde As Date,
                                           Hasta As Date,
                                           idProducto As String,
                                           idMarca As Integer,
                                           idModelo As Integer,
                                           idRubro As Integer,
                                           idSubRubro As Integer,
                                           idZonaGeografica As String,
                                           idTipoComprobante As String,
                                           IdVendedor As Integer,
                                           IdCliente As Long,
                                           GrabaLibro As String,
                                           AfectaCaja As String,
                                           IdFormaDePago As Integer,
                                           IdUsuario As String,
                                           PorcUtilidadDesde As Decimal,
                                           PorcUtilidadHasta As Decimal,
                                           Cantidad As String,
                                           DiscIVA As Boolean,
                                           IngresosBrutos As String,
                                           ProdDescRec As String,
                                           IdProveedor As Long,
                                           IdLocalidad As Integer,
                                           IdProvincia As String,
                                           IdCategoria As Integer,
                                           esParcial As Boolean,
                                           TipoVendedor As String,
                                           IdCobrador As Integer,
                                           tipoCobrador As String,
                                           conIva As Boolean,
                                           PorVendedor As Boolean,
                                           embarcacion As Boolean,
                                           IdCategoriaEmbarcacion As Integer,
                                           comisionVendedor As String,
                                           strCalculoComisionVendedor As String) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT E.IdEmpleado IdVendedor, ")
         .AppendLine("       E.NombreEmpleado as NombreVendedor, ")
         .AppendLine("       COB.IdEmpleado as IdCobrador,")
         .AppendLine("       COB.NombreEmpleado AS NombreCobrador,")

         .AppendLine("       --Recibo")
         .AppendLine("       CC.IdSucursal,")
         .AppendLine("       CC.IdTipoComprobante,")
         .AppendLine("       TC.Descripcion AS TipoComprobante,")
         .AppendLine("       CC.Letra,")
         .AppendLine("       CC.CentroEmisor,")
         .AppendLine("       CC.NumeroComprobante,")
         .AppendLine("       CC.Fecha,")
         .AppendLine("       CC.IdCliente,")
         .AppendLine("       C.NombreCliente,")
         .AppendLine("       CC.IdUsuario,")
         .AppendLine("       --Comprobante Aplicado")
         .AppendLine("       CC2.IdSucursal AS IdSucursalAplicado,")
         .AppendLine("       CC2.IdTipoComprobante AS IdTipoComprobanteAplicado,")
         .AppendLine("       TC2.Descripcion AS TipoComprobanteAplicado,")
         .AppendLine("       CC2.Letra AS LetraAplicado,")
         .AppendLine("       CC2.CentroEmisor AS CentroEmisorAplicado,")
         .AppendLine("       CC2.NumeroComprobante AS NumeroComprobanteAplicado,")
         .AppendLine("       CC2.Fecha AS FechaAplicado,")
         .AppendLine("       --Productos")
         .AppendLine("       VP.IdProducto,")
         .AppendLine("       VP.NombreProducto,	--Pudo cambiar la descripcion")
         .AppendLine("       VP.Cantidad,")
         '.AppendLine("       VP.PrecioNeto")

         If conIva Then
            .AppendFormat(" {0} PrecioNeto,", CalculosImpositivos.ObtenerPrecioConImpuestos("VP.PrecioNeto", "VP.AlicuotaImpuesto",
                                                                                 "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                                 "VP.OrigenPorcImpInt"))
            .AppendLine("      (VP.ImporteTotalNeto+VP.ImporteImpuesto) AS ImporteTotalNeto, ")
         Else
            .AppendLine("      VP.PrecioNeto ,")
            .AppendLine("      VP.ImporteTotalNeto, ")
         End If

         .AppendLine("       VP.ComisionVendedorPorc, ")
         .AppendLine("       VP.ComisionVendedor, ")
         If esParcial Then
            .AppendLine("       CC2.Saldo, ")
            If conIva Then
               .AppendLine("      (round((VP.ImporteTotalNeto+VP.ImporteImpuesto),2) / V.SubTotal) * ((CCP.ImporteCuota * -1))  / (1 + (VP.AlicuotaImpuesto /100)) as ImporteTotalParcial,")
            Else
               .AppendLine("      (round(VP.ImporteTotalNeto,2) / V.SubTotal) * ((CCP.ImporteCuota * -1))  / (1 + (VP.AlicuotaImpuesto /100)) as ImporteTotalParcial,")
            End If

         End If
         .AppendLine("       M.NombreMarca,")
         .AppendLine("       R.NombreRubro,")
         .AppendLine("	  --Comisiones")

         If strCalculoComisionVendedor = "FACTURACION" Then
            .AppendLine("       VP.ComisionVendedorPorc PorcComision,")
            .AppendLine("       VP.ComisionVendedor ")
         Else
            Ayudante.Comisiones.Calculo("100", "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine(" PorcComision")
         End If

         ''''.AppendLine("	     E.ComisionPorVenta AS ComisionPorVentaEmpleado,")

         ''''.AppendLine("       M.ComisionPorVenta AS ComisionPorVentaMarca,")
         ''''.AppendLine("       R.ComisionPorVenta AS ComisionPorVentaRubro,")
         ''''.AppendLine("       ECM.Comision AS ComisionPorVentaEmpleadoMarca,")
         ''''.AppendLine("       ECR.Comision AS ComisionPorVentaEmpleadoRubro,")
         ''''.AppendLine("       ECP.Comision AS ComisionPorVentaEmpleadoProducto")
         If embarcacion Then
            If esParcial Then
               .AppendLine("      ,V.IdEmbarcacion ")
            Else
               .AppendLine("      ,CC.IdEmbarcacion ")
            End If
            .AppendLine("      ,EM.NombreEmbarcacion
	                            ,EM.IdCategoriaEmbarcacion
	                            ,CATE.NombreCategoriaEmbarcacion")
         End If
         .AppendLine("  FROM CuentasCorrientes CC ")
         .AppendLine(" INNER JOIN TiposComprobantes TC		--Mira los comprobantes tipo recibo.")
         .AppendLine("         ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("        AND TC.EsRecibo = 'True'")

         .AppendLine(" INNER JOIN CuentasCorrientesPagos CCP	--Obtiene los comprobantes que se pagaron")
         .AppendLine("         ON ccp.IdSucursal = CC.IdSucursal ")
         .AppendLine("        AND ccp.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("        AND ccp.Letra = CC.Letra")
         .AppendLine("        AND ccp.CentroEmisor = CC.CentroEmisor")
         .AppendLine("        AND ccp.NumeroComprobante = CC.NumeroComprobante")
         .AppendLine(" INNER JOIN CuentasCorrientes CC2		--Controla el saldo de dichos comprobantes")
         .AppendLine("         ON CC2.IdSucursal = ccp.IdSucursal")
         .AppendLine("        AND CC2.IdTipoComprobante = ccp.IdTipoComprobante2")
         .AppendLine("        AND CC2.Letra = ccp.Letra2")
         .AppendLine("        AND CC2.CentroEmisor = ccp.CentroEmisor2")
         .AppendLine("        AND CC2.NumeroComprobante = ccp.NumeroComprobante2")
         If esParcial Then
            .AppendLine("        AND CC2.Saldo <> CC2.ImporteTotal")
         Else
            .AppendLine("        AND CC2.Saldo = 0")
         End If
         .AppendLine(" INNER JOIN VentasProductos  VP")
         .AppendLine("         ON VP.IdSucursal = CC2.IdSucursal")
         .AppendLine("        AND VP.IdTipoComprobante = CC2.IdTipoComprobante")
         .AppendLine("        AND VP.Letra = CC2.Letra")
         .AppendLine("        AND VP.CentroEmisor = CC2.CentroEmisor")
         .AppendLine("        AND VP.NumeroComprobante = CC2.NumeroComprobante")
         If esParcial Then
            .AppendLine(" INNER JOIN Ventas  V")
            .AppendLine("         ON VP.IdSucursal = V.IdSucursal ")
            .AppendLine("         AND VP.IdTipoComprobante = V.IdTipoComprobante ")
            .AppendLine("         AND VP.Letra = V.Letra ")
            .AppendLine("         AND VP.CentroEmisor = V.CentroEmisor ")
            .AppendLine("         AND VP.NumeroComprobante = V.NumeroComprobante")
         End If
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendLine("  INNER JOIN Clientes C2 ON C2.IdCliente = cc2.IdCliente")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN TiposComprobantes TC2 ON TC2.IdTipoComprobante = CC2.IdTipoComprobante AND TC2.EsComercial = 'True'") 'Excluye las NDCheqRecha
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias PR ON PR.IdProvincia = L.IdProvincia")

         If TipoVendedor = "RECIBO" Then
            If PorVendedor Then
               .AppendLine(" INNER JOIN Empleados E				--VendedorRecibo")
               .AppendLine("	    ON E.IdEmpleado = CC.IdVendedor")
            Else
               .AppendLine(" INNER JOIN Empleados E				--CobradorRecibo")
               .AppendLine("	    ON E.IdEmpleado = CC.IdCobrador")
            End If

         ElseIf TipoVendedor = "FACTURA" Then

            If PorVendedor Then
               .AppendLine("  INNER JOIN Empleados E 				--VendedorFactura")
               .AppendLine(" ON E.IdEmpleado = cc2.IdVendedor ")
            Else
               .AppendLine("  INNER JOIN Empleados E 				--CobradorFactura")
               .AppendLine(" ON E.IdEmpleado = cc2.IdCobrador ")
            End If

         ElseIf TipoVendedor = "CLIENTE" Then
            If PorVendedor Then
               .AppendLine(" INNER JOIN Empleados E				--VendedorCliente ")
               .AppendLine(" ON E.IdEmpleado = C2.IdVendedor ")
            Else
               .AppendLine(" INNER JOIN Empleados E				--CobradorCliente ")
               .AppendLine(" ON E.IdEmpleado = C2.IdCobrador ")
            End If

         End If
         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcas ECM ON ECM.IdMarca = M.IdMarca AND ECM.IdEmpleado = E.IdEmpleado")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubros ECR ON ECR.IdRubro = R.IdRubro AND ECR.IdEmpleado = E.IdEmpleado")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubRubros ECSR ON ECSR.IdSubRubro = P.IdSubRubro AND ECSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubSubRubros ECSSR ON ECSSR.IdSubSubRubro = P.IdSubSubRubro AND ECSSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductos ECP ON ECP.IdProducto = P.IdProducto AND ECP.IdEmpleado = E.IdEmpleado")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductosPrecios ECPP ON ECPP.IdProducto = P.IdProducto AND ECPP.IdEmpleado = E.IdEmpleado AND ECPP.IdListaPrecios = VP.IdListaPrecios")
         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcasPrecios ECMP ON ECMP.IdMarca = M.IdMarca AND ECMP.IdEmpleado = E.IdEmpleado AND ECMP.IdListaPrecios = VP.IdListaPrecios")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubrosPrecios ECRP ON ECRP.IdRubro = R.IdRubro AND ECRP.IdEmpleado = E.IdEmpleado AND ECRP.IdListaPrecios = VP.IdListaPrecios")

         If tipoCobrador = "RECIBO" Then
            .AppendLine("  LEFT JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador ")
         ElseIf tipoCobrador = "FACTURA" Then
            .AppendLine("  LEFT JOIN Empleados COB ON COB.IdEmpleado = CC2.IdCobrador ")
         ElseIf tipoCobrador = "CLIENTE" Then
            .AppendLine("  LEFT JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador ")
         End If

         If IdProveedor > 0 Then
            .AppendLine("	INNER JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto")
            .AppendLine("	INNER JOIN Proveedores PV ON PV.IdProveedor = PP.IdProveedor ")
         End If

         If embarcacion Then
            If esParcial Then
               .AppendLine("   LEFT JOIN Embarcaciones EM ON EM.IdEmbarcacion = V.IdEmbarcacion
                         LEFT JOIN CategoriasEmbarcaciones CATE ON CATE.IdCategoriaEmbarcacion = EM.IdCategoriaEmbarcacion")
            Else
               .AppendLine("   LEFT JOIN Embarcaciones EM ON EM.IdEmbarcacion = CC.IdEmbarcacion
                         LEFT JOIN CategoriasEmbarcaciones CATE ON CATE.IdCategoriaEmbarcacion = EM.IdCategoriaEmbarcacion")
            End If
         End If

         .AppendLine("  WHERE 1=1")  'CC.IdSucursal = " & IdSucursal.ToString()

         GetListaSucursalesMultiples(stb, sucursales, "CC2")

         .AppendLine("    AND CC.Fecha >= '" & Desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("    AND CC.Fecha <= '" & Hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat("	AND P.idproducto = '{0}'", idProducto)
         End If

         If idMarca <> 0 Then
            .AppendFormat("	AND P.IdMarca = {0}", idMarca)
         End If

         If idModelo <> 0 Then
            .AppendFormat("	AND P.IdModelo = {0}", idModelo)
         End If

         If idRubro <> 0 Then
            .AppendFormat("	AND P.IdRubro = {0}", idRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormat("	AND P.IdSubRubro = {0}", idSubRubro)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If IdVendedor > 0 Then
            If TipoVendedor = "RECIBO" Then
               .AppendLine("	AND CC.IdVendedor = " & IdVendedor)
            ElseIf TipoVendedor = "FACTURA" Then
               .AppendLine("	AND cc2.IdVendedor = " & IdVendedor)
            ElseIf TipoVendedor = "CLIENTE" Then
               .AppendLine("	AND C2.IdVendedor = " & IdVendedor)
            End If
         End If

         If IdCobrador > 0 Then
            If tipoCobrador = "RECIBO" Then
               .AppendLine("	AND CC.IdCobrador = " & IdCobrador)
            ElseIf TipoVendedor = "FACTURA" Then
               .AppendLine("	AND cc2.IdCobrador = " & IdCobrador)
            ElseIf TipoVendedor = "CLIENTE" Then
               .AppendLine("	AND C2.IdCobrador = " & IdCobrador)
            End If
            '  .AppendLine("	AND COB.IdEmpleado = " & IdCobrador.ToString())
         End If

         If IdCliente <> 0 Then
            .AppendLine("	AND CC.IdCliente= " & IdCliente)
         End If

         If GrabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         End If

         If AfectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(AfectaCaja = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND CC.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If IdFormaDePago > 0 Then
            .AppendLine("	AND CC.IdFormasPago = " & IdFormaDePago.ToString())
         End If

         If Not String.IsNullOrEmpty(IdUsuario) Then
            .AppendLine("	AND CC.Usuario = '" & IdUsuario & "'")
         End If

         If PorcUtilidadDesde >= 0 Then
            .AppendLine("	AND ROUND(VP.Utilidad/VP.ImporteTotalNeto*100,2) BETWEEN " & PorcUtilidadDesde.ToString() & " AND " & PorcUtilidadHasta.ToString())
         End If

         If Not String.IsNullOrEmpty(Cantidad) Then
            .AppendLine("   AND VP.Cantidad " & Cantidad)
         End If

         If IngresosBrutos <> "TODOS" Then
            .AppendLine("      AND P.PagaIngresosBrutos = " & IIf(IngresosBrutos = "SI", "1", "0").ToString())
         End If

         If ProdDescRec <> "TODOS" Then
            .AppendLine("     AND (ABS(VP.PrecioLista-VP.Precio) " & IIf(ProdDescRec = "SI", "> 0.02 OR", "<= 0.02 AND").ToString()) 'No puedo poner 0 porque por redondeo del IVA hay diferencias
            .AppendLine("      VP.DescuentoRecargoPorc " & IIf(ProdDescRec = "SI", "<> 0 OR", "= 0 AND").ToString())
            .AppendLine("      VP.DescRecGeneral " & IIf(ProdDescRec = "SI", "<> 0 OR", "= 0 AND").ToString())
            .AppendLine("      VP.DescuentoRecargoPorc2 " & IIf(ProdDescRec = "SI", "<> 0)", "= 0)").ToString())
         End If

         If IdProveedor > 0 Then
            .AppendLine("	AND PV.IdProveedor = " & IdProveedor.ToString())
         End If

         If IdLocalidad > 0 Then
            .AppendLine("	AND C.IdLocalidad = " & IdLocalidad.ToString())
         End If

         If Not String.IsNullOrEmpty(IdProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & IdProvincia & "'")
         End If

         If IdCategoria > 0 Then
            .AppendLine("	 AND C.IdCategoria = " & IdCategoria.ToString())
         End If

         If IdCategoriaEmbarcacion > 0 Then
            .AppendLine("   AND CATE.IdCategoriaEmbarcacion = " & IdCategoriaEmbarcacion.ToString())
         End If

         Return Me.GetDataTable(stb.ToString())
      End With
   End Function

   Public Function GetComisionesSobreVentas(idSucursal As Integer, desde As Date, hasta As Date,
                                            idProducto As String, idMarca As Integer, idModelo As Integer, idRubro As Integer, idSubRubro As Integer,
                                            idTipoComprobante As String, grabaLibro As Entidades.Publicos.SiNoTodos, afectaCaja As Entidades.Publicos.SiNoTodos,
                                            idCategoria As Integer, idCliente As Long, idProveedor As Long,
                                            idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                            idFormaDePago As Integer, idUsuario As String,
                                            porcUtilidadDesde As Decimal, porcUtilidadHasta As Decimal,
                                            cantidad As String, discIVA As Boolean, ingresosBrutos As Entidades.Publicos.SiNoTodos, prodDescRec As Entidades.Publicos.SiNoTodos,
                                            idLocalidad As Integer, idProvincia As String, idZonaGeografica As String,
                                            conIva As Boolean, comisionVendedor As String, calculoComisionVendedor As String) As DataTable
      Dim Importe As String
      If discIVA Then
         If conIva Then
            Importe = CalculosImpositivos.ObtenerPrecioConImpuestos("VP.ImporteTotalNeto", "VP.AlicuotaImpuesto", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt")
         Else
            Importe = "VP.ImporteTotalNeto"
         End If
      Else
         Importe = CalculosImpositivos.ObtenerPrecioConImpuestos("VP.ImporteTotalNeto", "VP.AlicuotaImpuesto", "P.PorcImpuestoInterno", "P.ImporteImpuestoInterno", "P.OrigenPorcImpInt")
      End If

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT  V.Fecha ")
         .AppendLine(" ,V.IdTipoComprobante ")
         .AppendLine(" ,TC.DescripcionAbrev ")
         .AppendLine(" ,V.Letra ")
         .AppendLine(" ,V.CentroEmisor ")
         .AppendLine(" ,V.NumeroComprobante ")
         .AppendLine(" ,V.IdVendedor ")
         .AppendLine(" ,E.NombreEmpleado ")
         .AppendLine(" ,V.IdCliente ")
         .AppendLine(" ,C.CodigoCliente ")
         .AppendLine(" ,C.NombreCliente ")
         .AppendLine(" ,CF.NombreCategoriaFiscalAbrev NombreCategoriaFiscal ")
         .AppendLine(" ,V.IdEstadoComprobante ")
         .AppendLine(" ,V.IdFormasPago ")
         .AppendLine(" ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine(" ,V.SubTotal ")
         .AppendLine(" ,V.TotalImpuestos ")
         .AppendLine(" ,V.ImporteTotal ")
         .AppendLine(" ,V.Utilidad ")
         .AppendLine(" ,V.Usuario ")
         .AppendLine(" ,V.Usuario IdUsuario")
         .AppendLine(" ,V.Observacion ")
         .AppendLine(" ,E.NombreEmpleado ")
         .AppendLine(" ,ZG.NombreZonaGeografica ")
         .AppendLine(" ,V.FechaActualizacion ")
         .AppendLine(" ,V.ImportePesos ")
         .AppendLine(" ,V.ImporteTickets ")
         .AppendLine(" ,V.ImporteTarjetas ")
         .AppendLine(" ,V.ImporteCheques ")
         .AppendLine(" ,V.IdCuentaBancaria ")
         .AppendLine(" ,V.ImporteTransfBancaria")
         .AppendLine(" --Productos")
         .AppendLine(" , VP.IdProducto,")
         .AppendLine(" VP.NombreProducto,	--Pudo cambiar la descripcion ")
         .AppendLine(" VP.Cantidad, ")
         .AppendLine(" VP.PrecioNeto, ")
         .AppendLine(" " & Importe & " As ImporteTotalNeto, ")

         ' GAR: Inf. Comisiones por ventas, para calcular comsion con iva Incluido
         .AppendLine(" M.NombreMarca,")
         .AppendLine(" R.NombreRubro, ")

         If calculoComisionVendedor = "LISTADO" Then
            Ayudante.Comisiones.Calculo("100", "E", "ECP", "ECPP", "R", "ECR", "ECRP", "ECSR", "ECSSR", "M", "ECM", "ECMP", "P", comisionVendedor, stb)
            .AppendFormatLine(" PorcComision")
         Else
            .AppendFormatLine(" VP.ComisionVendedorPorc AS PorcComision,")
            .AppendFormatLine(" VP.ComisionVendedor AS Comision ")
         End If

         .AppendLine("   FROM Ventas V ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante  --Mira los comprobantes tipo recibo.")
         .AppendFormatLine(" INNER JOIN Empleados E ON E.IdEmpleado = {0}.IdVendedor  --Vendedor", If(origenVendedor = Entidades.OrigenFK.Movimiento, "V", "C"))
         .AppendLine(" INNER JOIN VentasProductos  VP")
         .AppendLine("         ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("        AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("        AND VP.Letra = V.Letra")
         .AppendLine("        AND VP.CentroEmisor = V.CentroEmisor")
         .AppendLine("        AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
         .AppendLine(" INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine(" INNER JOIN TiposComprobantes TC2 ON TC2.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias PR ON PR.IdProvincia = L.IdProvincia")
         .AppendLine(" INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")

         If idProveedor > 0 Then
            .AppendLine("	INNER JOIN ProductosProveedores PP ON P.IdProducto = PP.IdProducto")
            .AppendLine("	INNER JOIN Proveedores PV ON PV.IdProveedor = PP.IdProveedor ")
         End If

         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcas ECM ON ECM.IdMarca = M.IdMarca AND ECM.IdEmpleado = E.IdEmpleado")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubros ECR ON ECR.IdRubro = R.IdRubro AND ECR.IdEmpleado = E.IdEmpleado")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubRubros ECSR ON ECSR.IdSubRubro = P.IdSubRubro AND ECSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesSubSubRubros ECSSR ON ECSSR.IdSubSubRubro = P.IdSubSubRubro AND ECSSR.IdEmpleado = E.IdEmpleado ")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductos ECP ON ECP.IdProducto = P.IdProducto AND ECP.IdEmpleado = E.IdEmpleado")
         .AppendLine("  LEFT JOIN EmpleadosComisionesProductosPrecios ECPP ON ECPP.IdProducto = P.IdProducto AND ECPP.IdEmpleado = E.IdEmpleado AND ECPP.IdListaPrecios = VP.IdListaPrecios")
         .AppendLine("  LEFT JOIN EmpleadosComisionesMarcasPrecios ECMP ON ECMP.IdMarca = M.IdMarca AND ECMP.IdEmpleado = E.IdEmpleado AND ECMP.IdListaPrecios = VP.IdListaPrecios")
         .AppendLine("  LEFT JOIN EmpleadosComisionesRubrosPrecios ECRP ON ECRP.IdRubro = R.IdRubro AND ECRP.IdEmpleado = E.IdEmpleado AND ECRP.IdListaPrecios = VP.IdListaPrecios")

         .AppendLine("  WHERE V.IdSucursal = " & idSucursal.ToString())
         .AppendFormatLine("    AND V.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("    AND V.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormat("	AND P.idproducto = '{0}'", idProducto)
         End If

         If idMarca <> 0 Then
            .AppendFormat("	AND P.IdMarca = {0}", idMarca)
         End If

         If idModelo <> 0 Then
            .AppendFormat("	AND P.IdModelo = {0}", idModelo)
         End If

         If idRubro <> 0 Then
            .AppendFormat("	AND P.IdRubro = {0}", idRubro)
         End If

         If idSubRubro > 0 Then
            .AppendFormat("	AND P.IdSubRubro = {0}", idSubRubro)
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If idVendedor > 0 Then
            .AppendFormatLine("	AND E.IdEmpleado = {0}", idVendedor)
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND V.IdCliente= " & idCliente)
         End If

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         If afectaCaja <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND TC.AfectaCaja= {0}", GetStringFromBoolean(afectaCaja = Entidades.Publicos.SiNoTodos.SI))
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If idFormaDePago > 0 Then
            .AppendLine("	AND V.IdFormasPago = " & idFormaDePago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	AND V.Usuario = '" & idUsuario & "'")
         End If

         If porcUtilidadDesde >= 0 Then
            .AppendLine("	AND ROUND(VP.Utilidad/VP.ImporteTotalNeto*100,2) BETWEEN " & porcUtilidadDesde.ToString() & " AND " & porcUtilidadHasta.ToString())
         End If

         If Not String.IsNullOrEmpty(cantidad) Then
            .AppendLine("   AND VP.Cantidad " & cantidad)
         End If

         If ingresosBrutos <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND TC.PagaIngresosBrutos = {0}", GetStringFromBoolean(ingresosBrutos = Entidades.Publicos.SiNoTodos.SI))
         End If

         If prodDescRec <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendLine("     AND (ABS(VP.PrecioLista-VP.Precio) " & If(prodDescRec = Entidades.Publicos.SiNoTodos.SI, "> 0.02 OR", "<= 0.02 AND")) 'No puedo poner 0 porque por redondeo del IVA hay diferencias
            .AppendLine("      VP.DescuentoRecargoPorc " & If(prodDescRec = Entidades.Publicos.SiNoTodos.SI, "<> 0 OR", "= 0 AND"))
            .AppendLine("      VP.DescRecGeneral " & If(prodDescRec = Entidades.Publicos.SiNoTodos.SI, "<> 0 OR", "= 0 AND"))
            .AppendLine("      VP.DescuentoRecargoPorc2 " & If(prodDescRec = Entidades.Publicos.SiNoTodos.SI, "<> 0)", "= 0)"))
         End If

         If idProveedor > 0 Then
            .AppendLine("	AND PV.IdProveedor = " & idProveedor.ToString())
         End If

         If idLocalidad > 0 Then
            .AppendLine("	AND C.IdLocalidad = " & idLocalidad.ToString())
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If idCategoria > 0 Then
            .AppendLine("	 AND C.IdCategoria = " & idCategoria.ToString())
         End If

         Return GetDataTable(stb)
      End With
   End Function

   Public Sub ActualizaComisionProducto(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroComprobante As Long,
                                          IdProducto As String,
                                          Orden As Integer,
                                          ComisionVendedor As Decimal,
                                          ComisionVendedorPorc As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder("")
      Dim gen As Generales = New Generales(Me._da)

      With myQuery
         .Append("UPDATE VentasProductos SET ")
         .AppendFormat("  ComisionVendedor = '{0}'", ComisionVendedor)
         .AppendFormat("  ,ComisionVendedorPorc = '{0}'", ComisionVendedorPorc)

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND letra = '{0}'", letra)
         .AppendFormat("   AND centroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND numeroComprobante = {0}", numeroComprobante)
         .AppendFormat("   AND IdProducto = '{0}'", IdProducto)
         .AppendFormat("   AND Orden = {0}", Orden)


      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Function GetDetalleParaOrganizarRepartos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numerosComprobantes As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT VP.IdSucursal")
         .AppendLine("      ,VP.IdTipoComprobante")
         .AppendLine("      ,VP.Letra")
         .AppendLine("      ,VP.CentroEmisor")
         .AppendLine("      ,VP.NumeroComprobante")

         .AppendLine("	    ,C.NombreCliente")
         .AppendLine("	    ,V.Direccion + ', ' + L.NombreLocalidad + ' (' + CONVERT(VARCHAR(MAX), V.IdLocalidad) + '), ' + PV.NombreProvincia AS DireccionCompleta")
         .AppendLine("	    ,V.Direccion")
         .AppendLine("	    ,V.IdLocalidad")
         .AppendLine("	    ,L.NombreLocalidad")
         .AppendLine("	    ,L.IdProvincia")
         .AppendLine("	    ,PV.NombreProvincia")

         .AppendLine("      ,VP.Orden")
         .AppendLine("      ,VP.IdProducto")
         .AppendLine("	    ,VP.NombreProducto")
         .AppendLine("      ,VP.Cantidad")
         .AppendLine("      ,VP.Kilos")
         .AppendLine("      ,P.EsRetornable")
         .AppendLine("      ,P.IdMarca")
         .AppendLine("      ,M.NombreMarca")
         .AppendLine("      ,P.IdRubro")
         .AppendLine("      ,R.NombreRubro")
         .AppendLine("      ,C.Telefono")
         .AppendLine("      ,C.TipoDocCliente")
         .AppendLine("      ,C.NroDocCliente")

         .AppendLine("  FROM VentasProductos VP")

         .AppendLine(" INNER JOIN Ventas V ON V.IdSucursal  = VP.IdSucursal")
         .AppendLine("                    AND V.IdTipoComprobante = VP.IdTipoComprobante")
         .AppendLine("					AND V.Letra = VP.Letra")
         .AppendLine("					AND V.CentroEmisor = VP.CentroEmisor")
         .AppendLine("					AND V.NumeroComprobante = VP.NumeroComprobante")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = V.IdLocalidad")
         .AppendLine(" INNER JOIN Provincias PV ON PV.IdProvincia = L.IdProvincia")

         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
         .AppendLine(" INNER JOIN Marcas M ON M.IdMarca = P.IdMarca")
         .AppendLine(" INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")

         .AppendLine(" WHERE VP.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND VP.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND VP.Letra = '" & letra & "'")
         .AppendLine("   AND VP.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND VP.NumeroComprobante = " & numerosComprobantes.ToString())
      End With

      Return GetDataTable(stb.ToString())
   End Function


   Public Function GetProductosParaProduccion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numerosComprobantes As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT VP.IdSucursal, VP.IdTipoComprobante, VP.Letra, VP.CentroEmisor, VP.NumeroComprobante")
         .AppendFormatLine("     , VP.IdProducto")
         .AppendFormatLine("     , SUM(VP.Cantidad) Cantidad")
         .AppendFormatLine("     , ISNULL(VP.IdFormula, 1) IdFormula")
         .AppendFormatLine("  FROM VentasProductos VP")
         .AppendFormatLine(" WHERE VP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND VP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VP.Letra = '{0}'", letra)
         .AppendFormatLine("   AND VP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND VP.NumeroComprobante = {0}", numerosComprobantes)
         .AppendFormatLine(" GROUP BY VP.IdSucursal, VP.IdTipoComprobante, VP.Letra, VP.CentroEmisor, VP.NumeroComprobante")
         .AppendFormatLine("        , VP.IdProducto, VP.IdFormula")
      End With
      Return GetDataTable(stb)
   End Function

End Class