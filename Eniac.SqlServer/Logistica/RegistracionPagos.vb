Public Class RegistracionPagos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetPedidos(idSucursal As Integer, distribucion As Integer, localidad As Integer,
                           numeroReparto As Integer, fechaHasta As DateTime, soloPendientesRendir As Boolean,
                           modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                           IdEmpleado As Integer, idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Return Me.GetDataTable(GetPedidosQuery(idSucursal, distribucion, localidad, numeroReparto, fechaHasta, soloPendientesRendir,
                                             modoConsultarComprobantes, IdEmpleado, orden:=True, idRuta:=idRuta, dia:=dia))
   End Function

   Private Function GetPedidosQuery(idSucursal As Integer, distribucion As Integer, localidad As Integer,
                                   numeroReparto As Integer, fechaHasta As DateTime, soloPendientesRendir As Boolean,
                                   modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes, IdEmpleado As Integer,
                                   orden As Boolean, idRuta As Integer, dia As Entidades.Publicos.Dias?) As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb

         .AppendLine("SELECT T.NombreTransportista")
         .AppendLine("      ,T.IdTransportista")
         .AppendLine("      ,E.NombreEmpleado")
         .AppendLine("      ,V.IdVendedor")
         .AppendLine("      ,V.IdSucursal")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,V.Letra")
         .AppendLine("      ,V.CentroEmisor")
         .AppendLine("      ,V.NumeroComprobante")
         .AppendLine("      ,V.Fecha")
         .AppendLine("      ,V.FechaEnvio")
         .AppendLine("      ,C.TipoDocCliente")
         .AppendLine("      ,C.NroDocCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,Ca.NombreCalle + ' ' + convert(varchar, c.Altura) AS Direccion")
         .AppendLine("      ,V.ImporteTotal")
         .AppendLine("      ,C.IdCategoriaFiscal")
         .AppendLine("      ,V.NumeroReparto")
         .AppendLine("      ,V.FechaAlta")
         .AppendLine("      ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("      ,VFP.IdFormasPago")
         .AppendLine("      ,TC.GRABALIBRO ")
         .AppendLine("      ,C.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,V.FechaRendicion")
         .AppendLine("      ,CC.Saldo")
         .AppendLine("      ,S.SaldoCliente")

         .AppendLine("  FROM Ventas V")
         .AppendLine(" INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal")
         .AppendLine("                                AND CC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                                AND CC.Letra = V.Letra")
         .AppendLine("                                AND CC.CentroEmisor = V.CentroEmisor")
         .AppendLine("                                AND CC.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine(" LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista")
         .AppendLine(" LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
         .AppendLine(" LEFT JOIN Clientes C ON C.idcliente = V.idcliente  ")
         .AppendLine(" LEFT JOIN Calles Ca ON Ca.IdCalle = C.IdCalle")
         .AppendLine(" LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")

         '# Se agrega LEFT JOIN para visualizar el Saldo del Cliente.
         .AppendLine("LEFT JOIN (SELECT C.IdCliente, C.NombreCliente, SUM(CCP.SaldoCuota) SaldoCliente")
         .AppendLine("  FROM CuentasCorrientesPagos CCP")
         .AppendLine("  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
         .AppendLine("  			 AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("   			 AND CC.Letra = CCP.Letra")
         .AppendLine("   			 AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("   			 AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine("   LEFT JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendFormatLine("WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendLine("			      GROUP BY C.IdCliente, C.NombreCliente) S on S.IdCliente = CC.IdCliente")

         .AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())
         If soloPendientesRendir Then
            If modoConsultarComprobantes = Entidades.RegistracionPagos.ModoConsultarComprobantes.SoloRepartoSeleccionado Then
               .AppendLine("   AND V.fechaRendicion IS NULL")
            End If
            .AppendLine("   AND CC.Saldo <> 0")
         End If
         .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')")
         .AppendLine("   AND TC.AfectaCaja = 1")
         .AppendLine("   AND TC.EsComercial = 1")   'Con esto solo alcanzaria, pero por ahora dejamos ambos.

         If numeroReparto > 0 Then
            If modoConsultarComprobantes = Entidades.RegistracionPagos.ModoConsultarComprobantes.SoloRepartoSeleccionado Then
               .AppendFormatLine("   AND V.NumeroReparto = {0}", numeroReparto)
            ElseIf modoConsultarComprobantes = Entidades.RegistracionPagos.ModoConsultarComprobantes.ComprobantesClientesReparto Then
               .AppendFormatLine("   AND V.IdCliente IN (SELECT DISTINCT IdCliente FROM Ventas WHERE NumeroReparto = {0})", numeroReparto)
            End If
         End If

         .AppendFormat("   AND V.Fecha < '{0} 23:59:59' ", fechaHasta.ToString("yyyyMMdd"))

         If distribucion > 0 Then
            .AppendLine("   AND V.IdTransportista = " & distribucion.ToString())
         End If

         If localidad > 0 Then
            .AppendLine("   AND C.idlocalidad = " & localidad.ToString())
         End If

         If IdEmpleado > 0 Then
            .AppendFormat("       AND V.IdVendedor = {0} ", IdEmpleado).AppendLine()
         End If

         If idRuta > 0 Or dia.HasValue Then
            .AppendLine().AppendLine().AppendLine(" UNION").AppendLine()

            .AppendLine("SELECT T.NombreTransportista")
            .AppendLine("      ,T.IdTransportista")
            .AppendLine("      ,E.NombreEmpleado")
            .AppendLine("      ,V.IdVendedor")
            .AppendLine("      ,V.IdSucursal")
            .AppendLine("      ,V.IdTipoComprobante")
            .AppendLine("      ,V.Letra")
            .AppendLine("      ,V.CentroEmisor")
            .AppendLine("      ,V.NumeroComprobante")
            .AppendLine("      ,V.Fecha")
            .AppendLine("      ,V.FechaEnvio")
            .AppendLine("      ,C.TipoDocCliente")
            .AppendLine("      ,C.NroDocCliente")
            .AppendLine("      ,C.NombreCliente")
            .AppendLine("      ,Ca.NombreCalle + ' ' + convert(varchar, c.Altura) AS Direccion")
            .AppendLine("      ,V.ImporteTotal")
            .AppendLine("      ,C.IdCategoriaFiscal")
            .AppendLine("      ,V.NumeroReparto")
            .AppendLine("      ,V.FechaAlta")
            .AppendLine("      ,VFP.DescripcionFormasPago as FormaDePago")
            .AppendLine("      ,VFP.IdFormasPago")
            .AppendLine("      ,TC.GRABALIBRO ")
            .AppendLine("      ,C.IdCliente ")
            .AppendLine("      ,C.CodigoCliente ")
            .AppendLine("      ,V.FechaRendicion")
            .AppendLine("      ,CC.Saldo")
            .AppendLine("      ,S.SaldoCliente")

            .AppendLine("  FROM Ventas V")
            .AppendLine(" INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal")
            .AppendLine("                                AND CC.IdTipoComprobante = V.IdTipoComprobante")
            .AppendLine("                                AND CC.Letra = V.Letra")
            .AppendLine("                                AND CC.CentroEmisor = V.CentroEmisor")
            .AppendLine("                                AND CC.NumeroComprobante = V.NumeroComprobante")
            .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = V.IdTipoComprobante")
            .AppendLine(" LEFT JOIN Transportistas T ON V.IdTransportista = T.IdTransportista")
            .AppendLine(" LEFT JOIN Empleados E ON E.IdEmpleado = V.IdVendedor ")
            .AppendLine(" LEFT JOIN Clientes C ON C.idcliente = V.idcliente ")
            .AppendLine(" LEFT JOIN Calles Ca ON Ca.IdCalle = C.IdCalle")
            .AppendLine("  INNER JOIN MovilRutasClientes MRC ON MRC.IdCliente = C.IdCliente ")
            .AppendLine(" LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago")

            '# Se agrega LEFT JOIN para visualizar el Saldo del Cliente.
            .AppendLine("LEFT JOIN (SELECT C.IdCliente, C.NombreCliente, SUM(CCP.SaldoCuota) SaldoCliente")
            .AppendLine("  FROM CuentasCorrientesPagos CCP")
            .AppendLine("  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
            .AppendLine("  			 AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
            .AppendLine("   			 AND CC.Letra = CCP.Letra")
            .AppendLine("   			 AND CC.CentroEmisor = CCP.CentroEmisor")
            .AppendLine("   			 AND CC.NumeroComprobante = CCP.NumeroComprobante")
            .AppendLine("   LEFT JOIN Clientes C ON CC.IdCliente = C.IdCliente")
            .AppendFormatLine("WHERE CCP.IdSucursal = {0}", idSucursal)
            .AppendLine("			      GROUP BY C.IdCliente, C.NombreCliente) S on S.IdCliente = CC.IdCliente")

            .AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())
            If soloPendientesRendir Then
               .AppendLine("   AND V.fechaRendicion IS NULL")
               .AppendLine("   AND CC.Saldo <> 0")
            End If
            .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')")
            .AppendLine("   AND TC.AfectaCaja = 1")
            .AppendLine("   AND TC.EsComercial = 1")


            .AppendFormat("   AND V.Fecha < '{0} 23:59:59' ", fechaHasta.ToString("yyyyMMdd"))

            If distribucion > 0 Then
               .AppendLine("   AND V.IdTransportista = " & distribucion.ToString())
            End If

            If localidad > 0 Then
               .AppendLine("   AND C.idlocalidad = " & localidad.ToString())
            End If

            If IdEmpleado > 0 Then
               .AppendFormat("       AND V.IdVendedor = {0} ", IdEmpleado).AppendLine()
            End If

            If idRuta > 0 Then
               .AppendFormat("       AND MRC.IdRuta = {0}", idRuta).AppendLine()
            End If

            If dia > -1 Then
               .AppendFormatLine("       AND MRC.Dia = {0}", Convert.ToInt32(dia))
            End If

         End If
         If orden Then
            .AppendLine(" ORDER BY V.FechaEnvio, V.NumeroReparto, V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante")
         End If
      End With
      Return stb.ToString()
   End Function

   Public Function GetPedidosProductos(idSucursal As Integer, distribucion As Integer, localidad As Integer,
                                       numeroReparto As Integer, fechaHasta As DateTime, soloPendientesRendir As Boolean,
                                       modoConsultarComprobantes As Entidades.RegistracionPagos.ModoConsultarComprobantes,
                                       IdEmpleado As Integer, idRuta As Integer, dia As Entidades.Publicos.Dias?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT V.IdSucursal, V.IdTipoComprobante, ")
         .AppendLine("       V.Letra, ")
         .AppendLine("       V.CentroEmisor,")
         .AppendLine("       V.NumeroComprobante,")
         .AppendLine("       V.NumeroReparto,")
         .AppendFormatLine("       VP.IdProducto, P.NombreProducto, VP.Cantidad, CONVERT(DECIMAL(14,2), {0}) AS ImporteTotal, VP.Orden, CONVERT(DECIMAL(14,2), {1}) AS Precio, VP.AlicuotaImpuesto AS AlicuotaIVA",
                           CalculosImpositivos.ObtenerPrecioConImpuestos("VP.ImporteTotal", "VP.AlicuotaImpuesto",
                                                                         "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                         "VP.OrigenPorcImpInt"),
                           CalculosImpositivos.ObtenerPrecioConImpuestos("VP.Precio", "VP.AlicuotaImpuesto",
                                                                         "VP.PorcImpuestoInterno", "P.ImporteImpuestoInterno",
                                                                         "VP.OrigenPorcImpInt"))
         .AppendLine("      ,VP.IdListaPrecios")
         .AppendLine("      ,VP.PorcImpuestoInterno")
         .AppendLine("      ,VP.OrigenPorcImpInt")
         .AppendLine("      ,VP.TipoOperacion")
         .AppendLine("      ,VP.Nota")
         .AppendFormatLine("  FROM ({0}) V", GetPedidosQuery(idSucursal, distribucion, localidad, numeroReparto, fechaHasta, soloPendientesRendir,
                                                             modoConsultarComprobantes, IdEmpleado, orden:=False, idRuta:=idRuta, dia:=dia))
         .AppendLine(" INNER JOIN VentasProductos VP ON VP.IdSucursal = V.IdSucursal")
         .AppendLine("                              AND VP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                              AND VP.CentroEmisor = V.CentroEmisor")
         .AppendLine("                              AND VP.Letra = V.Letra")
         .AppendLine("                              AND VP.NumeroComprobante = V.NumeroComprobante")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = VP.IdProducto")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetMotivos() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendLine("SELECT IdEstadoVenta, NombreEstadoVenta ")
         .AppendLine("	from EstadosVenta ")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Sub ActualizarDatosCC(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Integer,
                                numeroComprobante As Long,
                                idFormaPago As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientes ")
         .AppendFormatLine("   SET FechaVencimiento = Fecha + (SELECT MAX(Dias) AS Dias FROM VentasFormasPago WHERE IdFormasPago = {0}), IdFormasPago = {0}", idFormaPago)
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientes")

      myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesPagos ")
         .AppendFormatLine("   SET FechaVencimiento = Fecha + (SELECT MAX(Dias) AS Dias FROM VentasFormasPago WHERE IdFormasPago = {0}), IdFormasPago = {0}", idFormaPago)
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")
   End Sub

   Public Sub ActualizarDatosCC(ByVal idSucursal As Integer, _
                                ByVal idTipoComprobante As String, _
                                ByVal letra As String, _
                                ByVal centroEmisor As Integer, _
                                ByVal numeroComprobante As Long, _
                                ByVal ccFormaPago As Integer, _
                                ByVal ccfechaVencimiento As Date, _
                                ByVal ccpfechaVencimiento As Date)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CuentasCorrientes SET ")
         .AppendLine("  fechaVencimiento = '" & ccfechaVencimiento.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("  ,IdFormasPago = " & ccFormaPago & "")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'" & Chr(13))
         .AppendLine("   AND Letra = '" & letra & "'" & Chr(13))
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString() & Chr(13))
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientes")




      With myQuery
         .Length = 0
         .AppendLine("UPDATE CuentasCorrientesPagos SET ")
         .AppendLine("  fechaVencimiento = '" & ccpfechaVencimiento.ToString("yyyyMMdd HH:mm:ss") & "'")
         '.AppendLine("  ,IdFormasPago = " & ccFormaPago & "")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'" & Chr(13))
         .AppendLine("   AND Letra = '" & letra & "'" & Chr(13))
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString() & Chr(13))
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")





   End Sub

End Class
