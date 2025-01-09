Public Class Cajas
   Inherits Comunes

#Region "Contructores"
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
#End Region

   Public Sub Cajas_I(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer, fechaPlanilla As Date,
                      pesosSaldoInicial As Decimal, pesosSaldoFinal As Decimal,
                      dolaresSaldoInicial As Decimal, dolaresSaldoFinal As Decimal,
                      eurosSaldoInicial As Decimal, eurosSaldoFinal As Decimal,
                      chequesSaldoInicial As Decimal, chequesSaldoFinal As Decimal,
                      tarjetasSaldoInicial As Decimal, tarjetasSaldoFinal As Decimal,
                      ticketsSaldoInicial As Decimal, ticketsSaldoFinal As Decimal,
                      retencionesSaldoInicial As Decimal, retencionesSaldoFinal As Decimal,
                      bancosSaldoInicial As Decimal, bancosSaldoFinal As Decimal,
                      bancosDolaresSaldoInicial As Decimal, bancosDolaresSaldoFinal As Decimal,
                      pesosSaldoFinalDigit As Decimal, dolaresSaldoFinalDigit As Decimal,
                      ticketsSaldoFinalDigit As Decimal, chequesSaldoFinalDigit As Decimal,
                      tarjetasSaldoFinalDigit As Decimal, retencionesSaldoFinalDigit As Decimal,
                      bancosSaldoFinalDigit As Decimal, bancosDolaresSaldoFinalDigit As Decimal,
                      fechaCierrePlanilla As Date?)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO Cajas ( ")
         .AppendFormatLine("       IdSucursal")
         .AppendFormatLine("     , IdCaja")
         .AppendFormatLine("     , NumeroPlanilla")
         .AppendFormatLine("     , FechaPlanilla")

         .AppendFormatLine("     , PesosSaldoInicial")
         .AppendFormatLine("     , PesosSaldoFinal")
         .AppendFormatLine("     , DolaresSaldoInicial")
         .AppendFormatLine("     , DolaresSaldoFinal")
         .AppendFormatLine("     , EurosSaldoInicial")
         .AppendFormatLine("     , EurosSaldoFinal")

         .AppendFormatLine("     , ChequesSaldoInicial")
         .AppendFormatLine("     , ChequesSaldoFinal")
         .AppendFormatLine("     , TarjetasSaldoInicial")
         .AppendFormatLine("     , TarjetasSaldoFinal")

         .AppendFormatLine("     , TicketsSaldoInicial")
         .AppendFormatLine("     , TicketsSaldoFinal")
         .AppendFormatLine("     , RetencionesSaldoInicial")
         .AppendFormatLine("     , RetencionesSaldoFinal")

         .AppendFormatLine("     , BancosSaldoInicial")
         .AppendFormatLine("     , BancosSaldoFinal")
         .AppendFormatLine("     , BancosDolaresSaldoInicial")
         .AppendFormatLine("     , BancosDolaresSaldoFinal")


         .AppendFormatLine("     , PesosSaldoFinalDigit")
         .AppendFormatLine("     , DolaresSaldoFinalDigit")
         .AppendFormatLine("     , TicketsSaldoFinalDigit")
         .AppendFormatLine("     , ChequesSaldoFinalDigit")
         .AppendFormatLine("     , TarjetasSaldoFinalDigit")
         .AppendFormatLine("     , RetencionesSaldoFinalDigit")
         .AppendFormatLine("     , BancosSaldoFinalDigit")
         .AppendFormatLine("     , BancosDolaresSaldoFinalDigit")

         .AppendFormatLine("     , FechaCierrePlanilla")

         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("        {0} ", idSucursal)
         .AppendFormatLine("     ,  {0} ", idCaja)
         .AppendFormatLine("     ,  {0} ", numeroPlanilla)
         .AppendFormatLine("     , '{0}'", ObtenerFecha(fechaPlanilla, True))

         .AppendFormatLine("     ,  {0} ", pesosSaldoInicial)
         .AppendFormatLine("     ,  {0} ", pesosSaldoFinal)
         .AppendFormatLine("     ,  {0} ", dolaresSaldoInicial)
         .AppendFormatLine("     ,  {0} ", dolaresSaldoFinal)
         .AppendFormatLine("     ,   0  ")      '' EurosSaldoInicial
         .AppendFormatLine("     ,   0  ")      '' EurosSaldoFinal

         .AppendFormatLine("     ,  {0} ", chequesSaldoInicial)
         .AppendFormatLine("     ,  {0} ", chequesSaldoFinal)
         .AppendFormatLine("     ,  {0} ", tarjetasSaldoInicial)
         .AppendFormatLine("     ,  {0} ", tarjetasSaldoFinal)

         .AppendFormatLine("     ,  {0} ", ticketsSaldoInicial)
         .AppendFormatLine("     ,  {0} ", ticketsSaldoFinal)
         .AppendFormatLine("     ,  {0} ", retencionesSaldoInicial)
         .AppendFormatLine("     ,  {0} ", retencionesSaldoFinal)

         .AppendFormatLine("     ,  {0} ", bancosSaldoInicial)
         .AppendFormatLine("     ,  {0} ", bancosSaldoFinal)
         .AppendFormatLine("     ,  {0} ", bancosDolaresSaldoInicial)
         .AppendFormatLine("     ,  {0} ", bancosDolaresSaldoFinal)

         .AppendFormatLine("     ,  {0} ", pesosSaldoFinalDigit)
         .AppendFormatLine("     ,  {0} ", dolaresSaldoFinalDigit)
         .AppendFormatLine("     ,  {0} ", ticketsSaldoFinalDigit)
         .AppendFormatLine("     ,  {0} ", chequesSaldoFinalDigit)
         .AppendFormatLine("     ,  {0} ", tarjetasSaldoFinalDigit)
         .AppendFormatLine("     ,  {0} ", retencionesSaldoFinalDigit)
         .AppendFormatLine("     ,  {0} ", bancosSaldoFinalDigit)
         .AppendFormatLine("     ,  {0} ", bancosDolaresSaldoFinalDigit)

         .AppendFormatLine("     ,  {0} ", ObtenerFecha(fechaCierrePlanilla, True))

         .AppendFormatLine(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Cajas")

   End Sub

   Public Sub Cajas_U(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer,
                      pesosSaldoFinal As Decimal, dolaresSaldoFinal As Decimal,
                      ticketsSaldoFinal As Decimal, chequesSaldoFinal As Decimal,
                      tarjetasSaldoFinal As Decimal, retencionesSaldoFinal As Decimal,
                      bancosSaldoFinal As Decimal, bancosDolaresSaldoFinal As Decimal,
                      pesosSaldoFinalDigit As Decimal, dolaresSaldoFinalDigit As Decimal,
                      ticketsSaldoFinalDigit As Decimal, chequesSaldoFinalDigit As Decimal,
                      tarjetasSaldoFinalDigit As Decimal, retencionesSaldoFinalDigit As Decimal,
                      bancosSaldoFinalDigit As Decimal, bancosDolaresSaldoFinalDigit As Decimal,
                      fechaCierrePlanilla As Date?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Cajas ")
         .AppendFormatLine("   SET PesosSaldoFinal                = {0}", pesosSaldoFinal)
         .AppendFormatLine("      ,DolaresSaldoFinal              = {0}", dolaresSaldoFinal)
         .AppendFormatLine("      ,TicketsSaldoFinal              = {0}", ticketsSaldoFinal)
         .AppendFormatLine("      ,ChequesSaldoFinal              = {0}", chequesSaldoFinal)
         .AppendFormatLine("      ,TarjetasSaldoFinal             = {0}", tarjetasSaldoFinal)
         .AppendFormatLine("      ,RetencionesSaldoFinal          = {0}", retencionesSaldoFinal)
         .AppendFormatLine("      ,BancosSaldoFinal               = {0}", bancosSaldoFinal)
         .AppendFormatLine("      ,BancosDolaresSaldoFinal        = {0}", bancosDolaresSaldoFinal)
         .AppendFormatLine("      ,EurosSaldoFinal                = 0")
         .AppendFormatLine("      ,PesosSaldoFinalDigit           = {0}", pesosSaldoFinalDigit)
         .AppendFormatLine("      ,DolaresSaldoFinalDigit         = {0}", dolaresSaldoFinalDigit)
         .AppendFormatLine("      ,TicketsSaldoFinalDigit         = {0}", ticketsSaldoFinalDigit)
         .AppendFormatLine("      ,ChequesSaldoFinalDigit         = {0}", chequesSaldoFinalDigit)
         .AppendFormatLine("      ,TarjetasSaldoFinalDigit        = {0}", tarjetasSaldoFinalDigit)
         .AppendFormatLine("      ,RetencionesSaldoFinalDigit     = {0}", retencionesSaldoFinalDigit)
         .AppendFormatLine("      ,BancosSaldoFinalDigit          = {0}", bancosSaldoFinalDigit)
         .AppendFormatLine("      ,BancosDolaresSaldoFinalDigit   = {0}", bancosDolaresSaldoFinalDigit)
         .AppendFormatLine("      ,FechaCierrePlanilla            = {0}", ObtenerFecha(fechaCierrePlanilla, True))
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdCaja = {0}", idCaja)
         .AppendFormatLine("   AND NumeroPlanilla = {0}", numeroPlanilla)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Cajas")

   End Sub

   Public Sub Cajas_UFecha(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer, fechaPlanilla As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Cajas SET FechaPlanilla = '{0}'", ObtenerFecha(fechaPlanilla, True))
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdCaja = {0}", idCaja)
         .AppendFormatLine("   AND NumeroPlanilla = {0}", numeroPlanilla)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Cajas")
   End Sub

   Public Sub Cajas_D(idSucursal As Integer, idCaja As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE Cajas ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         If idCaja > 0 Then
            .AppendFormatLine("   AND IdCaja = {0}", idCaja)
         End If
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Cajas")
   End Sub

   Public Function GetCobranzasDetalladas(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                                          idCliente As Long, idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                          tipoComprobanteAplicador As Entidades.TipoComprobante(),
                                          tipoComprobanteAplicados As Entidades.TipoComprobante(),
                                          idFormaPago As Integer, comercial As String, grabalibro As Entidades.Publicos.SiNoTodos, grupos As Entidades.Grupo(),
                                          ordenarPor As Entidades.FiltrosReportes.InfCobranzasRealizadas.OrdenadoPor) As DataTable
      Dim stb = New StringBuilder()
      With stb
         'Ventas al CONTADO
         .AppendLine("SELECT V.IdSucursal ")
         .AppendLine("      ,V.Fecha ")
         .AppendLine("      ,V.IdTipoComprobante ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,'VENTA' AS TipoCobro")
         .AppendLine("      ,V.SubTotal AS ImporteNeto")
         .AppendLine("      ,V.ImporteTotal ")
         .AppendLine("      ,V.IdCliente ")
         .AppendLine("      ,C.NombreCliente ")
         .AppendLine("      ,C.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,V.IdVendedor ")
         .AppendLine("      ,E1.NombreEmpleado AS NombreVendedor ")
         .AppendLine("      ,C.IdVendedor AS IdVendedorClie ")
         .AppendLine("      ,E2.NombreEmpleado as NombreVendedorClie ")
         .AppendLine("      ,NULL AS IdTipoComprobante2 ")
         .AppendLine("      ,NULL AS Letra2 ")
         .AppendLine("      ,NULL AS CentroEmisor2 ")
         .AppendLine("      ,NULL AS NumeroComprobante2 ")
         .AppendLine("      ,NULL AS CuotaNumero2 ")
         .AppendLine("      ,NULL AS Fecha2 ")
         .AppendLine("      ,0 AS DiasCobranza")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")

         .AppendLine(" FROM VentasFormasPago VFP, TiposComprobantes TC, Ventas V ")
         .AppendLine("  INNER JOIN Empleados E1 ON V.IdVendedor = E1.IdEmpleado ")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("  INNER JOIN Empleados E2 ON C.IdVendedor = E2.IdEmpleado ")
         .AppendLine("  WHERE V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("   AND V.IdTipoComprobante = TC.IdTipoComprobante ")

         .AppendLine("   AND (V.IdEstadoComprobante<>'ANULADO' OR V.IdEstadoComprobante IS NULL)")
         .AppendLine("   AND VFP.Dias=0 ")   'Contado
         .AppendLine("   AND TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero


         GetListaSucursalesMultiples(stb, sucursales, "V")

         '   .AppendLine("   AND V.IdSucursal = " & IdSucursal.ToString())

         .AppendFormatLine("   AND V.fecha >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("   AND V.fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))

         If comercial <> "TODOS" Then
            .AppendFormatLine("   AND TC.EsComercial = '{0}'", comercial = "SI")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)
         End If

         If idVendedor > 0 Then
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("	AND V.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND C.IdVendedor = " & idVendedor)

            End If
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If



         GetListaTiposComprobantesMultiples(stb, tipoComprobanteAplicador, "V", "IdTipoComprobante")

         'If Not String.IsNullOrEmpty(IdTipoComprobante) Then
         '   .AppendLine("	AND V.IdTipoComprobante = '" & IdTipoComprobante & "'")
         'End If

         GetListaMultiples(stb, grupos, "TC")

         If idFormaPago > 0 Then
            .AppendLine(" AND V.IdFormasPago = " & idFormaPago)
         End If
         'If Not String.IsNullOrEmpty(TipoComprobanteAplic) Then
         '   .AppendLine("	AND V.IdTipoComprobante2 = '" & TipoComprobanteAplic & "'")
         'End If

         .AppendLine("UNION ALL")

         'Cobranza de RECIBOS

         .AppendLine("SELECT CCP.IdSucursal ")
         .AppendLine("      ,CCP.Fecha ")
         .AppendLine("      ,CCP.IdTipoComprobante ")
         .AppendLine("      ,CCP.Letra ")
         .AppendLine("      ,CCP.CentroEmisor ")
         .AppendLine("      ,CCP.NumeroComprobante ")
         .AppendLine("      ,'CTACTE' AS TipoCobro")

         'Hago el calculo por regla de 3 simple, para calcular un proporcional del monto, sin impuestos. 
         'Puede haber productos sin 
         .AppendLine("      ,CCP.ImporteCuota * (-1) * V.Subtotal / V.ImporteTotal AS ImporteNeto ")
         .AppendLine("      ,CCP.ImporteCuota * (-1) AS ImporteTotal ")
         .AppendLine("      ,CC.IdCliente ")
         .AppendLine("      ,C.NombreCliente ")
         .AppendLine("      ,C.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,CC.IdVendedor ")
         .AppendLine("      ,E1.NombreEmpleado AS NombreVendedor ")
         .AppendLine("      ,C.IdVendedor AS IdVendedorClie ")
         .AppendLine("      ,E2.NombreEmpleado as NombreVendedorClie ")
         .AppendLine("      ,CCP.IdTipoComprobante2 ")
         .AppendLine("      ,CCP.Letra2 ")
         .AppendLine("      ,CCP.CentroEmisor2 ")
         .AppendLine("      ,CCP.NumeroComprobante2 ")
         .AppendLine("      ,CCP.CuotaNumero2 ")
         .AppendLine("      ,V.Fecha AS Fecha2")
         .AppendLine("      ,DATEDIFF(""d"", V.Fecha, CCP.Fecha) AS DiasCobranza")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")

         .AppendLine("   FROM CuentasCorrientesPagos CCP ")
         .AppendLine("  LEFT OUTER JOIN Ventas V ON CCP.IdSucursal = V.IdSucursal  ")
         .AppendLine("                              AND CCP.IdTipoComprobante2 = V.IdTipoComprobante ")
         .AppendLine("                              AND CCP.Letra2 = V.Letra ")
         .AppendLine("                              AND CCP.CentroEmisor2 = V.CentroEmisor ")
         .AppendLine("                              AND CCP.NumeroComprobante2 = V.NumeroComprobante ")
         .AppendLine("  INNER JOIN CuentasCorrientes CC ON CCP.IdSucursal = CC.IdSucursal ")
         .AppendLine("                                 AND CCP.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendLine("                                 AND CCP.Letra = CC.Letra  ")
         .AppendLine("                                 AND CCP.CentroEmisor = CC.CentroEmisor ")
         .AppendLine("                                 AND CCP.NumeroComprobante = CC.NumeroComprobante ")
         .AppendLine("  INNER JOIN Empleados E1 ON CC.IdVendedor = E1.IdEmpleado ")
         .AppendLine("  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente ")
         .AppendLine("  INNER JOIN Empleados E2 ON C.IdVendedor = E2.IdEmpleado ")
         .AppendLine("  INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN TiposComprobantes TC2 ON CCP.IdTipoComprobante2 = TC2.IdTipoComprobante ")
         .AppendLine("  INNER JOIN VentasFormasPago VFP ON CCP.IdFormasPago = VFP.IdFormasPago ")

         .AppendLine("  WHERE (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')")

         If comercial <> "TODOS" Then
            .AppendFormatLine("   AND TC2.EsComercial = '{0}'", comercial = "SI")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)
         End If

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         '  .AppendLine("   AND CCP.IdSucursal = " & IdSucursal.ToString())

         .AppendFormatLine("	 AND CCP.fecha >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("	 AND CCP.fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))

         If idVendedor > 0 Then
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND C.IdVendedor = '" & idVendedor & "'")
            End If
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If



         'If Not String.IsNullOrEmpty(IdTipoComprobante) Then
         '   .AppendLine("	AND CCP.IdTipoComprobante = '" & IdTipoComprobante & "'")
         'End If
         GetListaTiposComprobantesMultiples(stb, tipoComprobanteAplicador, "CCP", "IdTipoComprobante")

         'If Not String.IsNullOrEmpty(IdTipoComprobanteAplic) Then
         '   .AppendLine("	AND CCP.IdTipoComprobante2 = '" & IdTipoComprobanteAplic & "'")
         'End If

         GetListaTiposComprobantesMultiples(stb, tipoComprobanteAplicados, "CCP", "IdTipoComprobante2")

         If idFormaPago > 0 Then
            .AppendLine(" AND V.IdFormasPago = " & idFormaPago)
         End If
         'IdSucursal

         GetListaMultiples(stb, grupos, "TC2")

         If grabalibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabalibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendLine(" ORDER BY IdSucursal")

         If ordenarPor = Entidades.FiltrosReportes.InfCobranzasRealizadas.OrdenadoPor.Vendedor Then
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("         ,E1.NombreEmpleado")
               .AppendLine("         ,V.IdVendedor")
            Else
               .AppendLine("         ,E2.NombreEmpleado")
               .AppendLine("         ,C.IdVendedor")
            End If
         End If

         .AppendLine("         ,V.Fecha")
         .AppendLine("         ,V.IdTipoComprobante")
         .AppendLine("         ,V.Letra")
         .AppendLine("         ,V.CentroEmisor")
         .AppendLine("         ,V.NumeroComprobante")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetComisionesCobranzasDetalladas(sucursales As Entidades.Sucursal(), desde As Date, hasta As Date,
                                          idCliente As Long, idVendedor As Integer, origenVendedor As Entidades.OrigenFK,
                                          tipoComprobanteAplicador As Entidades.TipoComprobante(),
                                          tipoComprobanteAplicados As Entidades.TipoComprobante(),
                                          idFormaPago As Integer, comercial As String, grabalibro As Entidades.Publicos.SiNoTodos, grupos As Entidades.Grupo(),
                                          ordenarPor As Entidades.FiltrosReportes.InfCobranzasRealizadas.OrdenadoPor,
                                          ComisionPor As Entidades.Empleado.Tipo,
                                          idCobrador As Integer, origenCobrador As Entidades.OrigenFK) As DataTable
      Dim stb = New StringBuilder()
      With stb
         'Ventas al CONTADO
         .AppendLine("SELECT V.IdSucursal ")
         .AppendLine("      ,V.Fecha ")
         .AppendLine("      ,V.IdTipoComprobante ")
         .AppendLine("      ,V.Letra ")
         .AppendLine("      ,V.CentroEmisor ")
         .AppendLine("      ,V.NumeroComprobante ")
         .AppendLine("      ,'VENTA' AS TipoCobro")
         .AppendLine("      ,V.SubTotal AS ImporteNeto")
         .AppendLine("      ,V.ImporteTotal ")
         .AppendLine("      ,V.IdCliente ")
         .AppendLine("      ,C.NombreCliente ")
         .AppendLine("      ,C.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,V.IdVendedor ")
         .AppendLine("      ,E1.NombreEmpleado AS NombreVendedor ")
         .AppendLine("      ,C.IdVendedor AS IdVendedorClie ")
         .AppendLine("      ,E2.NombreEmpleado as NombreVendedorClie ")
         .AppendLine("      ,V.IdCobrador")
         .AppendLine("      ,E3.NombreEmpleado AS NombreCobrador")
         .AppendLine("      ,C.IdCobrador AS IdCobradorClie")
         .AppendLine("      ,E4.NombreEmpleado as NombreCobradorClie ")
         If ComisionPor = Entidades.Empleado.Tipo.Vendedor Then
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("   ,E1.ComisionPorVenta")
               .AppendLine("   ,(V.SubTotal * E1.ComisionPorVenta)/ 100 AS Comision ")
            Else
               .AppendLine("   ,E2.ComisionPorVenta")
               .AppendLine("   ,(V.SubTotal * E2.ComisionPorVenta)/ 100 AS Comision ")
            End If
         Else
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("   ,E3.ComisionPorVenta")
               .AppendLine("   ,(V.SubTotal * E3.ComisionPorVenta)/ 100 AS Comision ")
            Else
               .AppendLine("   ,E4.ComisionPorVenta")
               .AppendLine("   ,(V.SubTotal * E4.ComisionPorVenta)/ 100 AS Comision ")
            End If
         End If
         .AppendLine("      ,NULL AS IdTipoComprobante2 ")
         .AppendLine("      ,NULL AS Letra2 ")
         .AppendLine("      ,NULL AS CentroEmisor2 ")
         .AppendLine("      ,NULL AS NumeroComprobante2 ")
         .AppendLine("      ,NULL AS CuotaNumero2 ")
         .AppendLine("      ,NULL AS Fecha2 ")
         .AppendLine("      ,0 AS DiasCobranza")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")

         .AppendLine(" FROM VentasFormasPago VFP, TiposComprobantes TC, Ventas V ")
         .AppendLine("  INNER JOIN Empleados E1 ON V.IdVendedor = E1.IdEmpleado ")
         .AppendLine("  INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine("  INNER JOIN Empleados E2 ON C.IdVendedor = E2.IdEmpleado ")
         .AppendLine("  INNER JOIN Empleados E3 ON V.IdCobrador = E3.IdEmpleado ")
         .AppendLine("  INNER JOIN Empleados E4 ON C.IdCobrador = E4.IdEmpleado ")
         .AppendLine("  WHERE V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("   AND V.IdTipoComprobante = TC.IdTipoComprobante ")

         .AppendLine("   AND (V.IdEstadoComprobante<>'ANULADO' OR V.IdEstadoComprobante IS NULL)")
         .AppendLine("   AND VFP.Dias=0 ")   'Contado
         .AppendLine("   AND TC.AfectaCaja = 'True' ")    'Contemplo solo aquellos comprobantes que manejan dinero


         GetListaSucursalesMultiples(stb, sucursales, "V")

         '   .AppendLine("   AND V.IdSucursal = " & IdSucursal.ToString())

         .AppendFormatLine("   AND V.fecha >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("   AND V.fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))

         If comercial <> "TODOS" Then
            .AppendFormatLine("   AND TC.EsComercial = '{0}'", comercial = "SI")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)
         End If

         If idVendedor > 0 Then
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("	AND V.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND C.IdVendedor = " & idVendedor)

            End If
         End If

         If idCobrador > 0 Then
            If origenCobrador = Entidades.OrigenFK.Movimiento Then
               .AppendLine("	AND V.IdCobrador = " & idCobrador)
            Else
               .AppendLine("	AND C.IdCobrador = '" & idCobrador & "'")
            End If
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If



         GetListaTiposComprobantesMultiples(stb, tipoComprobanteAplicador, "V", "IdTipoComprobante")

         'If Not String.IsNullOrEmpty(IdTipoComprobante) Then
         '   .AppendLine("	AND V.IdTipoComprobante = '" & IdTipoComprobante & "'")
         'End If

         GetListaMultiples(stb, grupos, "TC")

         If idFormaPago > 0 Then
            .AppendLine(" AND V.IdFormasPago = " & idFormaPago)
         End If
         'If Not String.IsNullOrEmpty(TipoComprobanteAplic) Then
         '   .AppendLine("	AND V.IdTipoComprobante2 = '" & TipoComprobanteAplic & "'")
         'End If

         .AppendLine("UNION ALL")

         'Cobranza de RECIBOS

         .AppendLine("SELECT CCP.IdSucursal ")
         .AppendLine("      ,CCP.Fecha ")
         .AppendLine("      ,CCP.IdTipoComprobante ")
         .AppendLine("      ,CCP.Letra ")
         .AppendLine("      ,CCP.CentroEmisor ")
         .AppendLine("      ,CCP.NumeroComprobante ")
         .AppendLine("      ,'CTACTE' AS TipoCobro")

         'Hago el calculo por regla de 3 simple, para calcular un proporcional del monto, sin impuestos. 
         'Puede haber productos sin 
         .AppendLine("      ,CCP.ImporteCuota * (-1) * V.Subtotal / V.ImporteTotal AS ImporteNeto ")
         .AppendLine("      ,CCP.ImporteCuota * (-1) AS ImporteTotal ")
         .AppendLine("      ,CC.IdCliente ")
         .AppendLine("      ,C.NombreCliente ")
         .AppendLine("      ,C.IdCliente ")
         .AppendLine("      ,C.CodigoCliente ")
         .AppendLine("      ,CC.IdVendedor ")
         .AppendLine("      ,E1.NombreEmpleado AS NombreVendedor ")
         .AppendLine("      ,C.IdVendedor AS IdVendedorClie ")
         .AppendLine("      ,E2.NombreEmpleado as NombreVendedorClie ")
         .AppendLine("      ,CC.IdCobrador")
         .AppendLine("      ,E3.NombreEmpleado AS NombreCobrador")
         .AppendLine("      ,C.IdCobrador AS IdCobradorClie")
         .AppendLine("      ,E4.NombreEmpleado as NombreCobradorClie ")

         If ComisionPor = Entidades.Empleado.Tipo.Vendedor Then
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("   ,E1.ComisionPorVenta")
               .AppendLine("   ,((CCP.ImporteCuota * (-1) * V.Subtotal / V.ImporteTotal) * E1.ComisionPorVenta)/ 100 AS Comision")
            Else
               .AppendLine("   ,E2.ComisionPorVenta")
               .AppendLine("   ,((CCP.ImporteCuota * (-1) * V.Subtotal / V.ImporteTotal) * E2.ComisionPorVenta)/ 100 AS Comision")
            End If
         Else
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("   ,E3.ComisionPorVenta")
               .AppendLine("   ,((CCP.ImporteCuota * (-1) * V.Subtotal / V.ImporteTotal) * E3.ComisionPorVenta)/ 100 AS Comision")
            Else
               .AppendLine("   ,E4.ComisionPorVenta")
               .AppendLine("   ,((CCP.ImporteCuota * (-1) * V.Subtotal / V.ImporteTotal) * E4.ComisionPorVenta)/ 100 AS Comision")
            End If
         End If
         .AppendLine("      ,CCP.IdTipoComprobante2 ")
         .AppendLine("      ,CCP.Letra2 ")
         .AppendLine("      ,CCP.CentroEmisor2 ")
         .AppendLine("      ,CCP.NumeroComprobante2 ")
         .AppendLine("      ,CCP.CuotaNumero2 ")
         .AppendLine("      ,V.Fecha AS Fecha2")
         .AppendLine("      ,DATEDIFF(""d"", V.Fecha, CCP.Fecha) AS DiasCobranza")
         .AppendLine("      ,V.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")

         .AppendLine("   FROM CuentasCorrientesPagos CCP ")
         .AppendLine("  LEFT OUTER JOIN Ventas V ON CCP.IdSucursal = V.IdSucursal  ")
         .AppendLine("                              AND CCP.IdTipoComprobante2 = V.IdTipoComprobante ")
         .AppendLine("                              AND CCP.Letra2 = V.Letra ")
         .AppendLine("                              AND CCP.CentroEmisor2 = V.CentroEmisor ")
         .AppendLine("                              AND CCP.NumeroComprobante2 = V.NumeroComprobante ")
         .AppendLine("  INNER JOIN CuentasCorrientes CC ON CCP.IdSucursal = CC.IdSucursal ")
         .AppendLine("                                 AND CCP.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendLine("                                 AND CCP.Letra = CC.Letra  ")
         .AppendLine("                                 AND CCP.CentroEmisor = CC.CentroEmisor ")
         .AppendLine("                                 AND CCP.NumeroComprobante = CC.NumeroComprobante ")
         .AppendLine("  INNER JOIN Empleados E1 ON CC.IdVendedor = E1.IdEmpleado ")
         .AppendLine("  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente ")
         .AppendLine("  INNER JOIN Empleados E2 ON C.IdVendedor = E2.IdEmpleado ")
         .AppendLine("  INNER JOIN Empleados E3 ON CC.IdCobrador = E3.IdEmpleado ")
         .AppendLine("  INNER JOIN Empleados E4 ON C.IdCobrador = E4.IdEmpleado ")
         .AppendLine("  INNER JOIN CategoriasFiscales CF ON C.IdCategoriaFiscal = CF.IdCategoriaFiscal ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN TiposComprobantes TC2 ON CCP.IdTipoComprobante2 = TC2.IdTipoComprobante ")
         .AppendLine("  INNER JOIN VentasFormasPago VFP ON CCP.IdFormasPago = VFP.IdFormasPago ")

         .AppendLine("  WHERE (TC.EsRecibo = 'True' OR TC.EsAnticipo = 'True')")

         If comercial <> "TODOS" Then
            .AppendFormatLine("   AND TC2.EsComercial = '{0}'", comercial = "SI")   'Contemplo solo aquellos comprobantes que reales (excluyo la ND por Cheq. Rechazado)
         End If

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         '  .AppendLine("   AND CCP.IdSucursal = " & IdSucursal.ToString())

         .AppendFormatLine("	 AND CCP.fecha >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("	 AND CCP.fecha <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))

         If idVendedor > 0 Then
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND C.IdVendedor = '" & idVendedor & "'")
            End If
         End If

         If idCobrador > 0 Then
            If origenCobrador = Entidades.OrigenFK.Movimiento Then
               .AppendLine("	AND CC.IdCobrador = " & idCobrador)
            Else
               .AppendLine("	AND C.IdCobrador = '" & idCobrador & "'")
            End If
         End If


         If idCliente <> 0 Then
            .AppendLine("	AND C.IdCliente = " & idCliente)
         End If



         'If Not String.IsNullOrEmpty(IdTipoComprobante) Then
         '   .AppendLine("	AND CCP.IdTipoComprobante = '" & IdTipoComprobante & "'")
         'End If
         GetListaTiposComprobantesMultiples(stb, tipoComprobanteAplicador, "CCP", "IdTipoComprobante")

         'If Not String.IsNullOrEmpty(IdTipoComprobanteAplic) Then
         '   .AppendLine("	AND CCP.IdTipoComprobante2 = '" & IdTipoComprobanteAplic & "'")
         'End If

         GetListaTiposComprobantesMultiples(stb, tipoComprobanteAplicados, "CCP", "IdTipoComprobante2")

         If idFormaPago > 0 Then
            .AppendLine(" AND V.IdFormasPago = " & idFormaPago)
         End If
         'IdSucursal

         GetListaMultiples(stb, grupos, "TC2")

         If grabalibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabalibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         .AppendLine(" ORDER BY IdSucursal")

         If ordenarPor = Entidades.FiltrosReportes.InfCobranzasRealizadas.OrdenadoPor.Vendedor Then
            If origenVendedor = Entidades.OrigenFK.Movimiento Then
               .AppendLine("         ,E1.NombreEmpleado")
               .AppendLine("         ,V.IdVendedor")
            Else
               .AppendLine("         ,E2.NombreEmpleado")
               .AppendLine("         ,C.IdVendedor")
            End If
         End If

         .AppendLine("         ,V.Fecha")
         .AppendLine("         ,V.IdTipoComprobante")
         .AppendLine("         ,V.Letra")
         .AppendLine("         ,V.CentroEmisor")
         .AppendLine("         ,V.NumeroComprobante")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function Cajas_G_UltimaPlanilla(idSucursal As Integer, idCaja As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT C.*")
         .AppendFormatLine("  FROM Cajas C ")
         .AppendFormatLine(" WHERE C.NumeroPlanilla = (SELECT MAX(NumeroPlanilla) - 1 FROM Cajas WHERE IdSucursal = {0} AND IdCaja = {1})", idSucursal, idCaja)
         .AppendFormatLine("   AND C.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND C.IdCaja = {0}", idCaja)
      End With
      Return GetDataTable(stbQuery)
   End Function
   Public Function Cajas_G_GetPlanillaActual(idSucursal As Integer, idCaja As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT C.*")
         .AppendFormatLine("  FROM Cajas C ")
         .AppendFormatLine(" WHERE C.NumeroPlanilla = (SELECT MAX(NumeroPlanilla)     FROM Cajas WHERE IdSucursal = {0} AND IdCaja = {1})", idSucursal, idCaja)
         .AppendFormatLine("   AND C.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND C.IdCaja = {0}", idCaja)
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function Cajas_G_GetPorRangoFechas(idSucursal As Integer, idCaja As Integer, desde As Date, hasta As Date, nroPlanilla As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT '...' Ver")
         .AppendFormatLine("     , C.IdSucursal")
         .AppendFormatLine("     , C.IdCaja")
         .AppendFormatLine("     , CN.NombreCaja")
         .AppendFormatLine("     , C.NumeroPlanilla")
         .AppendFormatLine("     , C.FechaPlanilla")
         .AppendFormatLine("     , C.PesosSaldoFinal")
         .AppendFormatLine("     , C.PesosSaldoFinalDigit")
         .AppendFormatLine("     , C.PesosSaldoFinal - C.PesosSaldoFinalDigit AS PesosSaldoFinalDif")
         .AppendFormatLine("     , C.ChequesSaldoFinal")
         .AppendFormatLine("     , C.ChequesSaldoFinalDigit")
         .AppendFormatLine("     , C.ChequesSaldoFinal - C.ChequesSaldoFinalDigit AS ChequesSaldoFinalDif")
         .AppendFormatLine("     , C.TarjetasSaldoFinal")
         .AppendFormatLine("     , C.TarjetasSaldoFinalDigit")
         .AppendFormatLine("     , C.TarjetasSaldoFinal - C.TarjetasSaldoFinalDigit AS TarjetasSaldoFinalDif")
         .AppendFormatLine("     , C.TicketsSaldoFinal")
         .AppendFormatLine("     , C.TicketsSaldoFinalDigit")
         .AppendFormatLine("     , C.TicketsSaldoFinal - C.TicketsSaldoFinalDigit AS TicketsSaldoFinalDif")
         .AppendFormatLine("     , C.DolaresSaldoFinal")
         .AppendFormatLine("     , C.DolaresSaldoFinalDigit")
         .AppendFormatLine("     , C.DolaresSaldoFinal - C.DolaresSaldoFinalDigit AS DolaresSaldoFinalDif")
         .AppendFormatLine("     , C.BancosSaldoFinal")
         .AppendFormatLine("     , C.BancosSaldoFinalDigit")
         .AppendFormatLine("     , C.BancosSaldoFinal - C.BancosSaldoFinalDigit AS BancosSaldoFinalDif")
         .AppendFormatLine("     , C.BancosDolaresSaldoFinal")
         .AppendFormatLine("     , C.BancosDolaresSaldoFinalDigit")
         .AppendFormatLine("     , C.BancosDolaresSaldoFinal - C.BancosDolaresSaldoFinalDigit AS BancosDolaresSaldoFinalDif")
         .AppendFormatLine("     , C.FechaCierrePlanilla")

         .AppendFormatLine("     , C.PesosSaldoInicial")
         .AppendFormatLine("     , C.ChequesSaldoInicial")
         .AppendFormatLine("     , C.TarjetasSaldoInicial")
         .AppendFormatLine("     , C.TicketsSaldoInicial")
         .AppendFormatLine("     , C.DolaresSaldoInicial")
         .AppendFormatLine("     , C.BancosSaldoInicial")
         .AppendFormatLine("     , C.BancosDolaresSaldoInicial")

         .AppendFormatLine("  FROM Cajas C")
         .AppendFormatLine(" INNER JOIN CajasNombres CN ON CN.IdSucursal = C.IdSucursal AND CN.IdCaja = C.IdCaja")
         .AppendFormatLine(" WHERE C.IdCaja = CN.IdCaja")
         .AppendFormatLine("   AND C.IdSucursal = CN.IdSucursal")
         .AppendFormatLine("   AND C.IdSucursal = {0}", idSucursal)

         If idCaja > 0 Then
            .AppendFormatLine("   AND C.IdCaja = {0}", idCaja)
         End If

         .AppendFormatLine("   AND C.FechaPlanilla >= '{0}'", ObtenerFecha(desde, False))
         .AppendFormatLine("   AND C.FechaPlanilla <= '{0}'", ObtenerFecha(hasta.UltimoSegundoDelDia(), True))

         'Decidimos mostrar también las abiertas.
         'La ultima esta abierta, esa no debe verse ahi.
         ''.AppendFormatLine("   AND C.NumeroPlanilla <= (SELECT MAX(NumeroPlanilla) - 1 FROM Cajas WHERE IdSucursal = C.IdSucursal AND IdCaja = C.IdCaja)")

         If nroPlanilla > 0 Then
            .AppendFormatLine("   AND C.NumeroPlanilla = {0}", nroPlanilla)
         End If
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetConsultaSaldosDeCaja(sucursales As Entidades.Sucursal(), cajas As Entidades.CajaNombre(), soloConSaldos As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.IdSucursal, C.IdCaja, C.NumeroPlanilla, S.Nombre NombreSucursal, CN.NombreCaja")
         .AppendFormatLine("     , SUM(C.ImportePesos) ImportePesos, SUM(C.ImporteDolares) ImporteDolares, SUM(ImporteEuros) ImporteEuros")
         .AppendFormatLine("     , SUM(C.ImporteCheques) ImporteCheques, SUM(C.ImporteTarjetas) ImporteTarjetas, SUM(C.ImporteTickets) ImporteTickets")
         .AppendFormatLine("     , SUM(C.ImporteBancos) ImporteBancos, SUM(C.ImporteRetenciones) ImporteRetenciones, SUM(C.ImporteBancosDolares) ImporteBancosDolares")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT C.IdSucursal, C.IdCaja, C.NumeroPlanilla")
         .AppendFormatLine("             , C.PesosSaldoInicial ImportePesos, C.DolaresSaldoInicial ImporteDolares, C.EurosSaldoInicial ImporteEuros")
         .AppendFormatLine("             , C.ChequesSaldoInicial ImporteCheques, C.TarjetasSaldoInicial ImporteTarjetas, C.TicketsSaldoInicial ImporteTickets")
         .AppendFormatLine("             , C.BancosSaldoInicial ImporteBancos, C.RetencionesSaldoInicial ImporteRetenciones, C.BancosDolaresSaldoInicial ImporteBancosDolares")
         .AppendFormatLine("          FROM Cajas C")
         .AppendFormatLine("         WHERE C.FechaCierrePlanilla IS NULL")
         .AppendFormatLine("        UNION ALL")
         .AppendFormatLine("        SELECT CD.IdSucursal, CD.IdCaja, CD.NumeroPlanilla")
         .AppendFormatLine("             , SUM(CD.ImportePesos) ImportePesos, SUM(CD.ImporteDolares) ImporteDolares, SUM(CD.ImporteEuros) ImporteEuros")
         .AppendFormatLine("             , SUM(CD.ImporteCheques) ImporteCheques, SUM(CD.ImporteTarjetas) ImporteTarjetas, SUM(CD.ImporteTickets) ImporteTickets")
         .AppendFormatLine("             , SUM(CASE WHEN CD.IdMonedaImporteBancos = 1 THEN CD.ImporteBancos ELSE 0 END) ImporteBancos")
         .AppendFormatLine("             , SUM(CD.ImporteRetenciones) ImporteRetenciones")
         .AppendFormatLine("             , SUM(CASE WHEN CD.IdMonedaImporteBancos = 2 THEN CD.ImporteBancos ELSE 0 END) ImporteBancosDolares")
         .AppendFormatLine("          FROM Cajas C")
         .AppendFormatLine("         INNER JOIN CajasDetalle CD ON CD.IdSucursal = C.IdSucursal AND CD.IdCaja = C.IdCaja AND CD.NumeroPlanilla = C.NumeroPlanilla")
         .AppendFormatLine("         WHERE C.FechaCierrePlanilla IS NULL")
         .AppendFormatLine("         GROUP BY CD.IdSucursal, CD.IdCaja, CD.NumeroPlanilla")
         .AppendFormatLine("       ) C")
         .AppendFormatLine(" INNER JOIN CajasNombres CN ON CN.IdSucursal = C.IdSucursal AND CN.IdCaja = C.IdCaja")
         .AppendFormatLine(" INNER JOIN Sucursales S ON S.Id = C.IdSucursal")
         .AppendFormatLine(" WHERE 1 = 1")
         GetListaSucursalesMultiples(stb, sucursales, "C")
         GetListaMultiples(stb, cajas, "C")
         .AppendFormatLine(" GROUP BY C.IdSucursal, C.IdCaja, C.NumeroPlanilla, CN.NombreCaja, S.Nombre")
         If soloConSaldos Then
            .AppendFormatLine("     HAVING SUM(C.ImportePesos) <> 0 OR SUM(C.ImporteDolares) <> 0 OR SUM(ImporteEuros)  <> 0 OR")
            .AppendFormatLine("            SUM(C.ImporteCheques) <> 0 OR SUM(C.ImporteTarjetas) <> 0 OR SUM(C.ImporteTickets) <> 0 OR")
            .AppendFormatLine("            SUM(C.ImporteBancos) <> 0 OR SUM(C.ImporteRetenciones) <> 0 OR SUM(C.ImporteBancosDolares) <> 0")
         End If
      End With
      Return GetDataTable(stb)
   End Function
End Class