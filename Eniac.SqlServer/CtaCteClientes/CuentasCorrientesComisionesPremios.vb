Imports Eniac.Entidades

Public Class CuentasCorrientesComisionesPremios
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetComisionesPorVentas(sucursales As Entidades.Sucursal(),
                                          idTipoComprobante As String,
                                          desde As Date,
                                          hasta As Date,
                                          grabaLibro As Entidades.Publicos.SiNoTodos,
                                          afectaCaja As Entidades.Publicos.SiNoTodos,
                                          idCliente As Long,
                                          idLocalidad As Integer,
                                          idProvincia As String,
                                          conIva As Boolean,
                                          porVendedor As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT  ")
         If porVendedor Then
            .AppendLine("	VTA.IdVendedor AS IdVendedor,  ")
         Else
            .AppendLine("	VTA.IdCobrador AS IdVendedor,  ")
         End If
         .AppendLine("	EMP.NombreEmpleado,  ")
         .AppendLine("	VTA.Fecha, ")
         .AppendLine("	VTA.IdSucursal, ")
         .AppendLine("	VTA.IdTipoComprobante, ")
         .AppendLine("	VTA.Letra, VTA.CentroEmisor,  ")
         .AppendLine("	VTA.NumeroComprobante,  ")
         .AppendLine("	VTA.IdCliente, CLI.NombreCliente, ")
         .AppendLine("	VTA.ImporteBruto,  ")
         .AppendLine("	VTA.ComisionVendedor, ")
         .AppendLine("	VTAP.AlicuotaImpuesto ")
         .AppendLine("FROM Ventas VTA ")
         If porVendedor Then
            .AppendLine("	INNER JOIN Empleados EMP ON EMP.IdEmpleado = VTA.IdVendedor ")
         Else
            .AppendLine("	INNER JOIN Empleados EMP ON EMP.IdEmpleado = VTA.IdCobrador ")
         End If
         .AppendLine("	INNER JOIN VentasFormasPago VFP On VFP.IdFormasPago = VTA.IdFormasPago ")
         .AppendLine("	INNER JOIN Clientes CLI ON CLI.IdCliente = VTA.IdCliente ")
         .AppendLine("  INNER JOIN Localidades LOC ON LOC.IdLocalidad = CLI.IdLocalidad")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VTA.IdTipoComprobante ")

         .AppendLine("  INNER JOIN VentasProductos VTAP ON	")
         .AppendLine("			VTA.IdSucursal = VTAP.IdSucursal	")
         .AppendLine("		AND VTA.IdTipoComprobante = VTAP.IdTipoComprobante	")
         .AppendLine("		AND VTA.Letra = VTAP.Letra	")
         .AppendLine("		AND VTA.CentroEmisor = VTAP.CentroEmisor	")
         .AppendLine("		AND VTA.NumeroComprobante = VTAP.NumeroComprobante	")

         .AppendLine("  WHERE 1=1")
         GetListaSucursalesMultiples(stb, sucursales, "VTA")

         .AppendFormatLine("    AND VTA.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("    AND VTA.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("      AND VTA.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         If afectaCaja <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND TC.AfectaCaja= {0}", GetStringFromBoolean(afectaCaja = Entidades.Publicos.SiNoTodos.SI))
         End If

         If idCliente <> 0 Then
            .AppendLine("	AND VTA.IdCliente= " & idCliente)
         End If
         If idLocalidad > 0 Then
            .AppendLine("	AND CLI.IdLocalidad = " & idLocalidad.ToString())
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND LOC.IdProvincia = '" & idProvincia & "'")
         End If

         .AppendLine("GROUP BY  ")
         If porVendedor Then
            .AppendLine("	VTA.IdVendedor,  ")
         Else
            .AppendLine("	VTA.IdCobrador,  ")
         End If
         .AppendLine("	EMP.NombreEmpleado,  ")
         .AppendLine("	VTA.Fecha, ")
         .AppendLine("	VTA.IdSucursal, ")
         .AppendLine("	VTA.IdTipoComprobante, ")
         .AppendLine("	VTA.Letra, VTA.CentroEmisor,  ")
         .AppendLine("	VTA.NumeroComprobante,  ")
         .AppendLine("	VTA.IdCliente, CLI.NombreCliente, ")
         .AppendLine("	VTA.ImporteBruto,  ")
         .AppendLine("	VTA.ComisionVendedor, ")
         .AppendLine("	VTAP.AlicuotaImpuesto ")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetComisionesPorCobranzas(sucursales As Entidades.Sucursal(),
                                             idTipoComprobante As String,
                                             desde As Date,
                                             hasta As Date,
                                             grabaLibro As Entidades.Publicos.SiNoTodos,
                                             afectaCaja As Entidades.Publicos.SiNoTodos,
                                             idCliente As Long,
                                             porVendedor As Boolean,
                                             idLocalidad As Integer,
                                             idProvincia As String,
                                             conIva As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT ")
         If porVendedor Then
            .AppendLine("	CTA.IdVendedor AS IdVendedor,  ")
         Else
            .AppendLine("	CTA.IdCobrador AS IdVendedor,  ")
         End If
         .AppendLine(" 	EMP.NombreEmpleado,")
         .AppendLine(" 	CTAP.IdSucursal, ")
         .AppendLine(" 	CTAP.IdTipoComprobante,")
         .AppendLine(" 	CTAP.Letra,")
         .AppendLine(" 	CTAP.CentroEmisor,")
         .AppendLine(" 	CTAP.NumeroComprobante,")
         .AppendLine(" 	CTAP.Fecha,")
         .AppendLine(" 	CTA.ImportePesos, ")
         .AppendLine(" 	CTA.ImporteDolares, ")
         .AppendLine(" 	CTA.ImporteRetenciones, ")
         .AppendLine(" 	CTA.ImporteTransfBancaria, ")
         .AppendLine(" 	CTA.ImporteCheques,")
         .AppendLine(" 	CTA.ImporteTarjetas,")
         .AppendLine(" 	VTAP.AlicuotaImpuesto, ")
         .AppendLine(" 	CTA.IdCliente, CLI.NombreCliente, ")
         .AppendLine(" 	EMP.CobraPremioCobranza, CTA.CotizacionDolar")

         .AppendLine(" FROM CuentasCorrientesPagos CTAP")
         .AppendLine(" 	INNER JOIN CuentasCorrientes CTA ON ")
         .AppendLine(" 							CTA.IdSucursal = CTAP.IdSucursal")
         .AppendLine(" 						AND CTA.IdTipoComprobante = CTAP.IdTipoComprobante")
         .AppendLine(" 						AND CTA.Letra = CTAP.Letra")
         .AppendLine(" 						AND CTA.CentroEmisor = CTAP.CentroEmisor")
         .AppendLine(" 						AND CTA.NumeroComprobante = CTAP.NumeroComprobante")
         .AppendLine(" 	INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CTA.IdTipoComprobante AND TC.Tipo = 'CTACTECLIE'")
         .AppendLine(" 	INNER JOIN TiposComprobantes TC2 ON TC2.IdTipoComprobante = CTAP.IdTipoComprobante2 AND TC2.Tipo = 'VENTAS'")
         If porVendedor Then
            .AppendLine("	INNER JOIN Empleados EMP ON EMP.IdEmpleado = CTA.IdVendedor ")
         Else
            .AppendLine("	INNER JOIN Empleados EMP ON EMP.IdEmpleado = CTA.IdCobrador ")
         End If
         .AppendLine("	INNER JOIN Clientes CLI ON CLI.IdCliente = CTA.IdCliente ")
         .AppendLine("  INNER JOIN Localidades LOC ON LOC.IdLocalidad = CLI.IdLocalidad")

         .AppendLine(" 	INNER JOIN VentasProductos VTAP ON ")
         .AppendLine(" 							 VTAP.IdSucursal = CTAP.IdSucursal")
         .AppendLine(" 						AND VTAP.IdTipoComprobante = CTAP.IdTipoComprobante2")
         .AppendLine(" 						AND VTAP.Letra = CTAP.Letra2")
         .AppendLine(" 						AND VTAP.CentroEmisor = CTAP.CentroEmisor2")
         .AppendLine(" 						AND VTAP.NumeroComprobante = CTAP.NumeroComprobante2")

         .AppendLine("  WHERE 1 = 1 ")

         GetListaSucursalesMultiples(stb, sucursales, "CTAP")

         .AppendFormatLine("    AND CTAP.Fecha >= '{0}'", ObtenerFecha(desde, True))
         .AppendFormatLine("    AND CTAP.Fecha <= '{0}'", ObtenerFecha(hasta, True))

         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("      AND CTAP.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("    AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         If afectaCaja <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("    AND TC.AfectaCaja= {0}", GetStringFromBoolean(afectaCaja = Entidades.Publicos.SiNoTodos.SI))
         End If

         If idCliente <> 0 Then
            .AppendLine("    AND CTA.IdCliente= " & idCliente)
         End If
         If idLocalidad > 0 Then
            .AppendLine("    AND CLI.IdLocalidad = " & idLocalidad.ToString())
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("    AND LOC.IdProvincia = '" & idProvincia & "'")
         End If

         .AppendLine("  	GROUP BY ")
         If porVendedor Then
            .AppendLine("	CTA.IdVendedor,  ")
         Else
            .AppendLine("	CTA.IdCobrador,  ")
         End If
         .AppendLine("   		EMP.NombreEmpleado,")
         .AppendLine("   		CTAP.IdSucursal, ")
         .AppendLine("   		CTAP.IdTipoComprobante,")
         .AppendLine("   		CTAP.Letra,")
         .AppendLine("   		CTAP.CentroEmisor,")
         .AppendLine("   		CTAP.NumeroComprobante,")
         .AppendLine("   		CTAP.Fecha,")
         .AppendLine("   		CTA.ImportePesos, ")
         .AppendLine("   		CTA.ImporteDolares, ")
         .AppendLine("   		CTA.ImporteRetenciones, ")
         .AppendLine("   		CTA.ImporteTransfBancaria, ")
         .AppendLine("   		CTA.ImporteCheques, CTA.ImporteTarjetas,")
         .AppendLine(" 	      VTAP.AlicuotaImpuesto, ")
         .AppendLine("   		CTA.IdCliente, CLI.NombreCliente, ")
         .AppendLine("   		EMP.CobraPremioCobranza, CTA.CotizacionDolar")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetComisionesPorCobranzasPagos(idSucursal As Integer,
                                                  idTipoComprobante As String,
                                                  letra As String,
                                                  centroEmisor As Integer,
                                                  numeroComprobante As Long, porVendedor As Boolean) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT ")
         .AppendLine(" 	CTAP.IdSucursal, ")
         .AppendLine(" 	CTAP.IdTipoComprobante2,")
         .AppendLine(" 	CTAP.Letra2,")
         .AppendLine(" 	CTAP.CentroEmisor2,")
         .AppendLine(" 	CTAP.NumeroComprobante2,")
         .AppendLine(" 	CTAP.CuotaNumero2,")
         .AppendLine(" 	VTAP.AlicuotaImpuesto, ")
         .AppendLine(" 	VTA.Fecha as Fecha2,")
         .AppendLine(" 	(CTAP.SaldoCuota - CTAP.ImporteCuota) as ImportePaga, ")
         .AppendLine(" 	VTA.ImporteBruto, ")
         .AppendLine(" 	VTA.ComisionVendedor ")

         .AppendLine(" FROM CuentasCorrientesPagos CTAP")

         .AppendLine(" 	INNER JOIN CuentasCorrientes CTA ON ")
         .AppendLine(" 							CTA.IdSucursal = CTAP.IdSucursal")
         .AppendLine(" 					  AND CTA.IdTipoComprobante = CTAP.IdTipoComprobante")
         .AppendLine(" 					  AND CTA.Letra = CTAP.Letra")
         .AppendLine(" 					  AND CTA.CentroEmisor = CTAP.CentroEmisor")
         .AppendLine(" 					  AND CTA.NumeroComprobante = CTAP.NumeroComprobante")

         .AppendLine(" 	INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CTA.IdTipoComprobante AND TC.Tipo = 'CTACTECLIE'")
         .AppendLine(" 	INNER JOIN TiposComprobantes TC2 ON TC2.IdTipoComprobante = CTAP.IdTipoComprobante2 AND TC2.Tipo = 'VENTAS'")

         If porVendedor Then
            .AppendLine("	INNER JOIN Empleados EMP ON EMP.IdEmpleado = CTA.IdVendedor ")
         Else
            .AppendLine("	INNER JOIN Empleados EMP ON EMP.IdEmpleado = CTA.IdCobrador ")
         End If
         .AppendLine("	INNER JOIN Clientes CLI ON CLI.IdCliente = CTA.IdCliente ")

         .AppendLine(" 	INNER JOIN Ventas VTA ON ")
         .AppendLine(" 							VTA.IdSucursal = CTAP.IdSucursal")
         .AppendLine(" 					  AND VTA.IdTipoComprobante = CTAP.IdTipoComprobante2")
         .AppendLine(" 					  AND VTA.Letra = CTAP.Letra2")
         .AppendLine(" 					  AND VTA.CentroEmisor = CTAP.CentroEmisor2")
         .AppendLine(" 					  AND VTA.NumeroComprobante = CTAP.NumeroComprobante2")
         .AppendLine(" 	INNER JOIN VentasProductos VTAP ON ")
         .AppendLine(" 							 VTAP.IdSucursal = CTAP.IdSucursal")
         .AppendLine(" 						AND VTAP.IdTipoComprobante = CTAP.IdTipoComprobante2")
         .AppendLine(" 						AND VTAP.Letra = CTAP.Letra2")
         .AppendLine(" 						AND VTAP.CentroEmisor = CTAP.CentroEmisor2")
         .AppendLine(" 						AND VTAP.NumeroComprobante = CTAP.NumeroComprobante2")
         .AppendLine("  WHERE 1 = 1 ")

         .AppendFormatLine("    AND CTAP.IdSucursal = {0}", idSucursal)

         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("      AND CTAP.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("      AND CTAP.Letra = '{0}'", letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("      AND CTAP.CentroEmisor = {0}", centroEmisor)
         End If
         If numeroComprobante > 0 Then
            .AppendFormatLine("      AND CTAP.NumeroComprobante = {0}", numeroComprobante)
         End If

         .AppendLine("  	GROUP BY ")
         .AppendLine("   		CTAP.IdSucursal, ")
         .AppendLine("   		CTAP.IdTipoComprobante2,")
         .AppendLine("   		CTAP.Letra2,")
         .AppendLine("   		CTAP.CentroEmisor2,")
         .AppendLine("   		CTAP.NumeroComprobante2,")
         .AppendLine("   		CTAP.CuotaNumero2,")
         .AppendLine("   		VTAP.AlicuotaImpuesto, ")
         .AppendLine(" 	      VTA.Fecha,")
         .AppendLine(" 	      CTAP.ImporteCuota, CTAP.SaldoCuota, ")
         .AppendLine(" 	      VTA.ImporteBruto, ")
         .AppendLine(" 	      VTA.ComisionVendedor ")

      End With
      Return GetDataTable(stb)
   End Function

End Class
