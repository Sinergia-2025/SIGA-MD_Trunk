Public Class CuentasCorrientesProv
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesProv_I(idSucursal As Integer,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Short,
                                      numeroComprobante As Long,
                                      fecha As Date,
                                      fechaVencimiento As Date,
                                      importeTotal As Double,
                                      idProveedor As Long,
                                      idFormasPago As Integer,
                                      observacion As String,
                                      saldo As Double,
                                      cantidadCuotas As Integer,
                                      importePesos As Decimal,
                                      importeDolares As Decimal,
                                      importeTickets As Decimal,
                                      importeCheques As Decimal,
                                      importeTransfBancaria As Decimal,
                                      idCuentaBancaria As Integer,
                                      importeRetenciones As Decimal,
                                      importeTarjetas As Decimal,
                                      idEstadoComprobante As String,
                                      idUsuario As String,
                                      fechaActualizacion As Date,
                                      metodoGrabacion As Entidades.Entidad.MetodoGrabacion,
                                      idFuncion As String,
                                      imprimeSaldos As Boolean?,
                                      cotizacionDolar As Decimal,
                                      refProveedor As String,
                                      fechaTransferencia As Date?,
                                      promedioDiasPago As Decimal,
                                      saldoCtaCte As Decimal?,
                                      numeroOrdenCompra As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO CuentasCorrientesProv")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdTipoComprobante")
         .AppendLine("           ,Letra")
         .AppendLine("           ,CentroEmisor")
         .AppendLine("           ,NumeroComprobante")
         .AppendLine("           ,Fecha")
         .AppendLine("           ,FechaVencimiento")
         .AppendLine("           ,ImporteTotal")
         .AppendLine("           ,IdProveedor")
         .AppendLine("           ,IdFormasPago")
         .AppendLine("           ,Observacion")
         .AppendLine("           ,RefProveedor")
         .AppendLine("           ,Saldo")
         .AppendLine("           ,CantidadCuotas")
         .AppendLine("           ,importePesos")
         .AppendLine("           ,importeDolares")
         .AppendLine("           ,ImporteTickets")
         .AppendLine("           ,importeTransfBancaria")
         .AppendLine("           ,importeCheques")
         .AppendLine("           ,importeEuros")
         .AppendLine("           ,idCuentaBancaria")
         .AppendLine("           ,importeRetenciones")
         .AppendLine("           ,ImporteTarjetas")
         .AppendLine("           ,IdEstadoComprobante")
         .AppendLine("           ,IdUsuario")
         .AppendLine("           ,FechaActualizacion")
         .AppendLine("           ,MetodoGrabacion")
         .AppendLine("           ,IdFuncion")
         .AppendLine("           ,ImprimeSaldos")
         .AppendLine("           ,CotizacionDolar")
         .AppendLine("           ,FechaTransferencia")
         .AppendLine("           ,PromedioDiasPago")
         .AppendLine("           ,SaldoCtaCte")
         .AppendLine("           ,NumeroOrdenCompra")
         .AppendLine(")     VALUES")
         .AppendFormatLine("           ({0}", idSucursal)
         .AppendFormatLine("           ,'{0}'", idTipoComprobante)
         .AppendFormatLine("           ,'{0}'", letra)
         .AppendFormatLine("           ,{0}", centroEmisor)
         .AppendFormatLine("           ,{0}", numeroComprobante)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fecha, True))
         If String.IsNullOrEmpty(fechaVencimiento.ToString()) Then
            .AppendFormatLine("           ,null")
         Else
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaVencimiento, True))
         End If
         .AppendFormatLine("           ,{0}", importeTotal.ToString())
         .AppendFormatLine("           ,{0}", idProveedor)
         .AppendFormatLine("           ,{0}", idFormasPago)
         .AppendFormatLine("           ,'{0}'", observacion)
         .AppendFormatLine("           ,'{0}'", refProveedor)
         .AppendFormatLine("           ,{0}", saldo)
         .AppendFormatLine("           ,{0}", cantidadCuotas)
         .AppendFormatLine("           ,{0}", importePesos)
         .AppendFormatLine("           ,{0}", importeDolares)
         .AppendFormatLine("           ,{0}", importeTickets)
         .AppendFormatLine("           ,{0}", importeTransfBancaria)
         .AppendFormatLine("           ,{0}", importeCheques)
         .AppendFormatLine("           ,0")
         If idCuentaBancaria > 0 Then
            .AppendFormatLine("           ,{0}", idCuentaBancaria)
         Else
            .AppendLine("           ,NULL")
         End If
         .AppendFormatLine("           ,{0}", importeRetenciones)
         .AppendFormatLine("           ,{0}", importeTarjetas)
         .AppendFormatLine("           ,'{0}'", idEstadoComprobante)
         .AppendFormatLine("           ,'{0}'", idUsuario)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaActualizacion, True))
         .AppendFormatLine("           ,'{0}'", metodoGrabacion.ToString().Substring(0, 1))
         .AppendFormatLine("           ,'{0}'", idFuncion)
         If imprimeSaldos.HasValue Then
            .AppendFormatLine("           ,{0}", GetStringFromBoolean(imprimeSaldos.Value))
         Else
            .AppendLine("           ,NULL")
         End If
         .AppendFormatLine("           , {0} ", cotizacionDolar)
         If fechaTransferencia.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaTransferencia.Value, False))
         Else
            .AppendLine("           ,NULL")
         End If
         .AppendFormatLine("           ,{0}", promedioDiasPago)
         If saldoCtaCte.HasValue Then
            .AppendFormat("           ,{0}", saldoCtaCte)
         Else
            .AppendLine("           ,NULL")
         End If

         If numeroOrdenCompra > 0 Then
            .AppendFormat("           ,{0}", numeroOrdenCompra)
         Else
            .AppendLine("           ,NULL")
         End If

         .AppendLine(")")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProv")
   End Sub

   Public Sub CuentasCorrientesProv_UImprimeSaldos(idProveedor As Long, grupo As String, grabaLibro As Boolean?, fecha As Date, imprimeSaldos As Boolean?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesProv")
         If imprimeSaldos.HasValue Then
            .AppendFormatLine("   SET ImprimeSaldos = {0}", GetStringFromBoolean(imprimeSaldos.Value))
         Else
            .AppendFormatLine("   SET ImprimeSaldos = NULL")
         End If
         .AppendFormatLine("  FROM CuentasCorrientesProv CC")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine(" WHERE TC.EsRecibo = {0}", GetStringFromBoolean(True))
         .AppendFormatLine("   AND CC.IdProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND TC.Grupo = '{0}'", grupo)
         If grabaLibro.HasValue Then
            .AppendFormatLine("   AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro.Value))
         End If
         .AppendFormatLine("   AND CC.Fecha > '{0}'", ObtenerFecha(fecha, True))

      End With
      Execute(myQuery)
   End Sub

   Public Sub CuentasCorrientesProv_AplicaAlSaldo(idSucursal As Integer, IdProveedor As Long,
                                                  idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                                  saldoNuevo As Double)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CuentasCorrientesProv")
         .AppendLine("   SET")
         .AppendFormatLine("			Saldo = Saldo + {0}", saldoNuevo)
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("	and IdProveedor = {0}", IdProveedor)
         .AppendFormatLine("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and Letra = '{0}'", letra)
         .AppendFormatLine("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProv")
   End Sub

   Public Sub CuentasCorrientesProv_UPago(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                          idEstadoComprobante As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CuentasCorrientesProv ")
         .AppendLine("   SET ImporteTotal = 0 ")
         .AppendLine("      ,Observacion = '***ANULADO***'")
         .AppendLine("      ,Saldo = 0 ")
         .AppendLine("      ,importePesos = 0 ")
         .AppendLine("      ,importeDolares = 0 ")
         .AppendLine("      ,ImporteTickets = 0 ")
         .AppendLine("      ,importeTransfBancaria = 0 ")
         .AppendLine("      ,IdCuentaBancaria = NULL ")
         .AppendLine("      ,importeCheques = 0 ")
         .AppendLine("      ,importeEuros = 0 ")
         .AppendLine("      ,importeRetenciones = 0 ")
         .AppendLine("      ,ImporteTarjetas = 0 ")
         .AppendLine("      ,IdEstadoComprobante = '" & idEstadoComprobante & "'")
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and Letra = '{0}'", letra)
         .AppendFormatLine("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProv")
   End Sub

   Public Sub CuentasCorrientesProv_UFecha(idSucursal As Integer, idProveedor As Long,
                                           idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                           ajusteDias As Integer, observacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CuentasCorrientesProv")
         .AppendFormatLine(" SET Fecha = Fecha + {0}", ajusteDias)
         .AppendFormatLine("    ,FechaVencimiento = FechaVencimiento + {0}", ajusteDias)
         .AppendFormatLine("    ,Observacion = '{0}'", observacion)
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("	and IdProveedor = {0}", idProveedor)
         .AppendFormatLine("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and Letra = '{0}'", letra)
         .AppendFormatLine("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProv")
   End Sub

   Public Sub CuentasCorrientesProv_D(idSucursal As Integer, IdProveedor As Long,
                                      idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE CuentasCorrientesProv ")
         .AppendFormatLine(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormatLine("	and IdProveedor = {0}", IdProveedor)
         .AppendFormatLine("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	and Letra = '{0}'", letra)
         .AppendFormatLine("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProv")
   End Sub

   Public Sub ActualizoDatosCaja(idSucursal As Integer, IdProveedor As Long,
                                 idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                 idCaja As Integer, numeroPlanilla As Integer, numeroMovimiento As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("UPDATE CuentasCorrientesProv")
         .AppendFormatLine("	SET IdCaja = {0}, NumeroPlanilla = {1}, NumeroMovimiento = {2}", idCaja, numeroPlanilla, numeroMovimiento)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdProveedor = {0}", IdProveedor)
         .AppendFormatLine("	AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("	AND Letra = '{0}'", letra)
         .AppendFormatLine("	AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("	AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "CuentasCorrientesProv")
   End Sub

   Public Function Existe(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Boolean
      Dim idEmpresa = If(idSucursal = 0, actual.Sucursal.IdEmpresa, 0I)
      Return Existe(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante, idEmpresa)
   End Function

   Public Function Existe(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idEmpresa As Integer) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal FROM CuentasCorrientesProv CCP")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = CCP.IdSucursal")

         If idSucursal > 0 Then
            .AppendFormatLine(" WHERE CCP.IdSucursal = {0}", idSucursal)
         Else
            .AppendFormatLine(" WHERE CCP.IdSucursal > 0")
         End If
         .AppendFormatLine("   AND CCP.IdProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND CCP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCP.Letra = '{0}'", letra)
         .AppendFormatLine("   AND CCP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND CCP.NumeroComprobante = {0}", numeroComprobante)
         If idEmpresa > 0 Then
            .AppendFormatLine("   AND (TC.InformaLibroIva = 'True' OR S.IdEmpresa = {0})", idEmpresa)
         End If
      End With

      Using dt = GetDataTable(stb)
         Return dt.Any()
      End Using
   End Function

   Public Function GetSaldoProveedores(suc As List(Of Integer)) As DataTable

      Dim sucur As String = String.Empty
      Dim entro As Boolean = False

      For Each s As Integer In suc
         sucur += s.ToString() + ","
         entro = True
      Next

      If entro Then
         sucur = sucur.Substring(0, sucur.Length - 1)
      End If

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT S.Nombre")
         .AppendLine("      ,SUM(CC.Saldo) AS Saldo ")
         .AppendLine("  FROM CuentasCorrientesProv CC ")
         .AppendLine("  INNER JOIN Sucursales S on S.IdSucursal = CC.IdSucursal ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  WHERE CC.Saldo <> 0")
         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         .AppendLine("   AND TC.EsAnticipo = 'False'")
         If String.IsNullOrEmpty(sucur) Then
            .AppendLine("   AND CC.IdSucursal = 0")
         Else
            .AppendFormat(" AND CC.IdSucursal IN ({0})", sucur).AppendLine()
         End If
         .AppendLine("GROUP BY S.Nombre ")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetPorRetencion(idSucursal As Integer,
                                   IdProveedor As Long,
                                   idTipoImpuesto As String,
                                   emisorRetencion As Integer,
                                   numeroRetencion As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendLine(" LEFT JOIN CuentasCorrientesProvRetenciones CCPR ON CCPR.IdSucursal = CCP.IdSucursal ")
         .AppendLine("	AND CCPR.IdProveedor = CCP.IdProveedor")
         .AppendLine("	AND CCPR.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("	AND CCPR.Letra = CCP.Letra")
         .AppendLine("	AND CCPR.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("	AND CCPR.NumeroComprobante = CCP.NumeroComprobante")
         .AppendFormat(" WHERE CCPR.IdSucursal = {0}", idSucursal)
         .AppendFormat("	AND CCPR.IdProveedor = {0}", IdProveedor)
         .AppendFormat("	AND CCPR.IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormat("	AND CCPR.EmisorRetencion = {0}", emisorRetencion)
         .AppendFormat("	AND CCPR.NumeroRetencion = {0}", numeroRetencion)
      End With
      Return GetDataTable(stb)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT CCP.*")
         .AppendLine("      ,P.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("  FROM CuentasCorrientesProv CCP ")
         .AppendLine(" INNER JOIN Proveedores P ON CCP.IdProveedor = P.IdProveedor")
      End With
   End Sub
   Public Function CuentasCorrientesProv_G1(idSucursal As Integer, idProveedor As Long,
                                            idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE CCP.IdSucursal = {0}", idSucursal)
         If idProveedor <> 0 Then
            .AppendFormatLine("   AND CCP.IdProveedor = {0}", idProveedor)
         End If
         .AppendFormatLine("   AND CCP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCP.Letra = '{0}'", letra)
         .AppendFormatLine("   AND CCP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND CCP.NumeroComprobante = {0}", numeroComprobante)
      End With
      Return GetDataTable(stb)
   End Function
   Public Function CuentasCorrientesProv_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetMovEliminarProv(idSucursal As Integer,
                                      desde As Date, hasta As Date,
                                      idProveedor As Long, idTipoComprobante As String,
                                      idCategoria As Integer,
                                      grabaLibro As String, nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal ")
         .AppendLine("      ,CCP.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,CCP.IdTipoComprobante")
         .AppendLine("      ,LTRIM(TC.Descripcion) AS DescripcionTipoComprobante")
         .AppendLine("      ,CCP.Letra")
         .AppendLine("      ,CCP.CentroEmisor")
         .AppendLine("      ,CCP.NumeroComprobante")
         .AppendLine("      ,CCP.Fecha")
         .AppendLine("      ,CCP.FechaVencimiento")
         .AppendLine("      ,CCP.ImporteTotal")
         .AppendLine("      ,CCP.Saldo")
         .AppendLine("      ,CCP.IdFormasPago")
         .AppendLine("      ,VFP.DescripcionFormasPago")
         .AppendLine("      ,CCP.Observacion")
         .AppendLine("      ,I.TipoImpresora")
         .AppendLine("  FROM CuentasCorrientesProv CCP")
         .AppendLine(" INNER JOIN Proveedores P ON CCP.IdProveedor = P.IdProveedor")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine(" INNER JOIN VentasFormasPago VFP ON CCP.IdFormasPago = VFP.IdFormasPago")
         .AppendLine(" LEFT OUTER JOIN Impresoras I ON CCP.CentroEmisor = I.CentroEmisor AND I.IdSucursal = " & idSucursal)

         .AppendLine("  WHERE CCP.IdSucursal = " & idSucursal.ToString())

         NivelAutorizacionProveedorTipoComprobante(stb, "P", "TC", nivelAutorizacion)

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor)
         End If

         If desde.Year > 1 Then
            .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND P.IdCategoria = " & idCategoria.ToString())
         End If

         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'ANTICIPO'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'ANTICIPOPROV'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'PAGO'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'PAGOPROV'")
         .AppendLine("   AND TC.EsAnticipo = 'False'")
         .AppendLine("   AND TC.EsRecibo = 'False'")

         .AppendLine(" AND CCP.ImporteTotal = CCP.Saldo")
         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND CCP.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         'Es Mar Performante y no hace falta repetir los filtros.
         .AppendLine("	AND NOT EXISTS")
         .AppendLine("	     ( SELECT IdSucursal FROM Compras C")
         .AppendLine("	        WHERE C.IdSucursal = CCP.IdSucursal")
         .AppendLine("	         AND C.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("	         AND C.Letra = CCP.Letra")
         .AppendLine("	         AND C.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("	         AND C.NumeroComprobante = CCP.NumeroComprobante)")
         .AppendLine(" ORDER BY CCP.Fecha")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetDetalle(sucursal As Integer,
                              desde As Date, hasta As Date,
                              idProveedor As Long, idTipoComprobante As String,
                              saldo As String,
                              idCategoria As Integer,
                              grabaLibro As String, nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal, ")
         .AppendLine("  P.IdProveedor, ")
         .AppendLine("  P.CodigoProveedor, ")
         .AppendLine("  P.NombreProveedor, ")
         .AppendLine("  P.TelefonoProveedor, ")
         .AppendLine("	CCP.IdTipoComprobante, ")
         .AppendLine("	CCP.Letra, ")
         .AppendLine("	CCP.CentroEmisor, ")
         .AppendLine("	CCP.NumeroComprobante, ")
         .AppendLine("	CCP.Fecha, ")
         .AppendLine("	CCP.FechaVencimiento, ")
         .AppendLine("	CCP.ImporteTotal, ")
         .AppendLine("	CCP.Saldo, ")
         .AppendLine("	CCP.Observacion ")

         .AppendLine("  ,CCP.IdEjercicio")
         .AppendLine("	,CCP.IdPlanCuenta ")
         .AppendLine("	,CCP.IdAsiento ")

         .AppendLine("	,CCP.MetodoGrabacion ")
         .AppendLine("	,CCP.IdFuncion ")

         .AppendLine("	,CCP.RefProveedor ")

         .AppendLine("	FROM CuentasCorrientesProv CCP")
         .AppendLine("  INNER JOIN Proveedores P ON CCP.IdProveedor = P.IdProveedor ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante ")

         .AppendLine("  WHERE CCP.IdSucursal = " & sucursal.ToString())

         NivelAutorizacionProveedorTipoComprobante(stb, "P", "TC", nivelAutorizacion)

         If desde.Year > 1 Then
            .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idProveedor <> 0 Then
            .AppendLine("   AND P.IdProveedor =" & idProveedor)
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND P.IdCategoria = " & idCategoria.ToString())
         End If

         'No debe informar los Anticipos porque el PAGO tiene el saldo.
         .AppendLine("   AND TC.EsAnticipo = 'False'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'ANTICIPO'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'ANTICIPOPROV'")

         .AppendLine("   AND (CCP.IdEstadoComprobante IS NULL OR CCP.IdEstadoComprobante <> 'ANULADO') ")

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND CCP.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If saldo <> "TODOS" Then
            .AppendLine("   AND CCP.Saldo <> 0 ")
         End If

         .AppendLine(" ORDER BY P.NombreProveedor ")
         .AppendLine("   ,CCP.IdProveedor ")
         .AppendLine("	,CCP.Fecha")
         .AppendLine("	,CCP.IdTipoComprobante")
         .AppendLine("	,CCP.Letra")
         .AppendLine("	,CCP.CentroEmisor")
         .AppendLine("	,CCP.NumeroComprobante")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetPagosPorRangoFechas(sucursales As Entidades.Sucursal(),
                                          desde As Date, hasta As Date,
                                          idProveedor As Long, idCategoria As Integer, idUsuario As String, estado As String,
                                          idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroComprobante As Long,
                                          idCaja As Integer,
                                          nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal ")
         .AppendLine("     , P.IdProveedor ")
         .AppendLine("     , P.CodigoProveedor ")
         .AppendLine("     , P.NombreProveedor ")
         .AppendLine("     , CCP.IdTipoComprobante ")
         .AppendLine("     , CCP.Letra ")
         .AppendLine("     , CCP.CentroEmisor ")
         .AppendLine("     , CCP.NumeroComprobante ")
         .AppendLine("     , CCP.Fecha ")
         .AppendLine("     , CCP.FechaVencimiento ")
         .AppendLine("     , CCP.IdFormasPago ")
         .AppendLine("     , CCP.ImporteTotal * (-1) as ImporteTotal ")
         .AppendLine("     , CCP.Saldo ")
         .AppendLine("     , CCP.CantidadCuotas ")
         .AppendLine("     , CCP.Observacion ")
         .AppendLine("     , CCP.ImportePesos ")
         .AppendLine("     , CCP.ImporteTickets ")
         .AppendLine("     , CCP.ImporteDolares ")
         .AppendLine("     , CCP.ImporteEuros ")
         .AppendLine("     , CCP.ImporteCheques ")
         .AppendLine("     , CCP.ImporteTransfBancaria ")
         .AppendLine("     , CB.NombreCuenta AS NombreCuentaBancaria ")
         .AppendLine("     , CCP.ImporteTarjetas")
         .AppendLine("     , CCP.IdCuentaBancaria ")
         .AppendLine("     , CCP.ImporteRetenciones ")
         .AppendLine("     , CCP.IdEstadoComprobante")
         .AppendLine("     , CCP.IdUsuario")
         .AppendLine("     , CCP.FechaActualizacion")
         .AppendLine("     , CCP.IdEjercicio")
         .AppendLine("     , CCP.IdPlanCuenta")
         .AppendLine("     , CCP.IdAsiento")
         .AppendLine("     , CN.NombreCaja")
         .AppendLine("     , CCP.MetodoGrabacion")
         .AppendLine("     , CCP.IdFuncion")
         .AppendLine("     , CCP.CotizacionDolar")
         .AppendLine("      ,CCP.PromedioDiasPago")
         .AppendLine("      ,CP.NombreCategoria")
         .AppendLine("      ,CP.NombreCategoria")
         .AppendLine("		FROM CuentasCorrientesProv CCP
	                        INNER JOIN Proveedores P ON P.IdProveedor = CCP.IdProveedor")
         .AppendLine("     INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("     LEFT JOIN CuentasBancarias CB ON CCP.IdCuentaBancaria = CB.IdCuentaBancaria ")
         .AppendLine("     LEFT JOIN CajasNombres CN ON CCP.IdCaja = CN.IdCaja and CCP.IdSucursal = CN.IDSucursal")
         .AppendLine("     LEFT JOIN CategoriasProveedores CP ON CP.IdCategoria = P.IdCategoria")
         .AppendLine("  WHERE CCP.IdProveedor = P.IdProveedor ")

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         NivelAutorizacionProveedorTipoComprobante(stb, "P", "TC", nivelAutorizacion)

         .AppendFormatLine("   AND TC.EsRecibo = 'True'")

         .AppendFormatLine("   AND CCP.Fecha BETWEEN '{0}' AND '{1}'", ObtenerFecha(desde, False), ObtenerFecha(hasta.UltimoSegundoDelDia(), True))

         If idProveedor <> 0 Then
            .AppendFormatLine("   AND P.IdProveedor = {0}", idProveedor)
         End If

         If idCategoria > 0 Then
            .AppendFormatLine("   AND P.IdCategoria = {0}", idCategoria)
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("	AND CCP.IdUsuario = '{0}'", idUsuario)
         End If

         If Not String.IsNullOrEmpty(estado) Then
            .AppendFormatLine("	AND CCP.IdEstadoComprobante = '{0}'", estado)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendFormatLine("	 AND CCP.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If

         If letraFiscal <> "" Then
            .AppendFormatLine("	 AND CCP.Letra = '{0}'", letraFiscal)
         End If

         If centroEmisor > 0 Then
            .AppendFormatLine("	 AND CCP.CentroEmisor = {0}", centroEmisor)
         End If

         If numeroComprobante > 0 Then
            .AppendFormatLine("	 AND CCP.NumeroComprobante = {0}", numeroComprobante)
         End If

         If idCaja <> 0 Then
            .AppendFormatLine("   AND CCP.IdCaja = {0}", idCaja)
         End If

         .AppendLine("	ORDER BY")
         .AppendLine("	  CCP.Fecha")
         .AppendLine("	, CCP.IdTipoComprobante")
         .AppendLine("	, CCP.Letra")
         .AppendLine("	, CCP.CentroEmisor")
         .AppendLine("	, CCP.NumeroComprobante")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetComprobantesCtaCteFecha(idSucursal As Integer,
                                              hasta As Date,
                                              idProveedor As Long,
                                              idTipoComprobante As String,
                                              idCategoria As Integer,
                                              idRubroCompra As Integer,
                                              grabaLibro As String,
                                              nivelAutorizacion As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT B.CodigoProveedor ")
         .AppendLine("      ,B.NombreProveedor ")
         .AppendLine("      ,B.NombreCategoria ")
         .AppendLine("      ,A.IdSucursal ")
         .AppendLine("      ,A.IdTipoComprobante2 ")
         .AppendLine("      ,A.Letra2 ")
         .AppendLine("      ,A.CentroEmisor2 ")
         .AppendLine("      ,A.NumeroComprobante2 ")
         .AppendLine("      ,B.FechaEmision ")
         .AppendLine("      ,A.ImporteTotal ")
         .AppendLine("      ,B.IdProveedor")
         .AppendLine("      ,B.NombreRubro")
         .AppendLine("      ,CASE WHEN B.GrabaLibro = 0 THEN 'NO' ELSE 'SI' END AS GrabaLibro")
         .AppendLine(" FROM ")
         .AppendLine(" ( SELECT CCP.IdSucursal ")
         .AppendLine("         ,CCP.IdProveedor ")
         .AppendLine("         ,CCP.IdTipoComprobante2 ")
         .AppendLine("         ,CCP.Letra2 ")
         .AppendLine("         ,CCP.CentroEmisor2 ")
         .AppendLine("         ,CCP.NumeroComprobante2 ")
         .AppendLine("         ,SUM(CCP.ImporteCuota) AS ImporteTotal ")
         .AppendLine("     FROM CuentasCorrientesProvPagos CCP ")
         .AppendLine("    WHERE Convert(varchar(11), CCP.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         .AppendLine("    GROUP BY CCP.IdSucursal ")
         .AppendLine("            ,CCP.IdProveedor ")
         .AppendLine("            ,CCP.IdTipoComprobante2 ")
         .AppendLine("            ,CCP.Letra2 ")
         .AppendLine("            ,CCP.CentroEmisor2 ")
         .AppendLine("            ,CCP.NumeroComprobante2 ")
         .AppendLine("    HAVING SUM(CCP.ImporteCuota) <> 0 ")
         .AppendLine(" ) A, ")
         .AppendLine(" ( SELECT P.CodigoProveedor ")
         .AppendLine("         ,P.NombreProveedor ")
         .AppendLine("         ,P.IdRubroCompra")
         .AppendLine("         ,RC.NombreRubro")
         .AppendLine("         ,Cat.NombreCategoria ")
         .AppendLine("         ,CC.IdSucursal ")
         .AppendLine("         ,CC.IdProveedor")
         .AppendLine("         ,CC.IdTipoComprobante ")
         .AppendLine("         ,CC.Letra ")
         .AppendLine("         ,CC.CentroEmisor ")
         .AppendLine("         ,CC.NumeroComprobante ")
         .AppendLine("         ,CONVERT(varchar(11), CC.Fecha, 103) AS FechaEmision ")
         .AppendLine("     	 ,TC.GrabaLibro")
         .AppendLine("   FROM CuentasCorrientesProv CC ")
         .AppendLine("   INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendLine("   INNER JOIN Proveedores P ON P.IdProveedor = CC.IdProveedor  ")
         .AppendLine("   INNER JOIN CategoriasProveedores Cat ON P.IdCategoria = Cat.IdCategoria  ")
         .AppendFormatLine("   LEFT JOIN RubrosCompras RC ON P.IdRubroCompra = RC.IdRubro")

         .AppendLine("  WHERE CC.IdSucursal = " & idSucursal.ToString())

         NivelAutorizacionProveedorTipoComprobante(stb, "P", "TC", nivelAutorizacion)

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND P.IdCategoria = " & idCategoria.ToString())
         End If

         If idRubroCompra <> 0 Then
            .AppendFormatLine("	AND P.IdRubroCompra = {0}", idRubroCompra)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND CC.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         .AppendLine(") B ")
         .AppendLine(" WHERE A.IdSucursal = B.IdSucursal ")
         .AppendLine("   AND A.IdProveedor = B.IdProveedor ")
         .AppendLine("   AND A.IdTipoComprobante2 = B.IdTipoComprobante ")
         .AppendLine("   AND A.Letra2 = B.Letra ")
         .AppendLine("   AND A.CentroEmisor2 = B.CentroEmisor ")
         .AppendLine("   AND A.NumeroComprobante2 = B.NumeroComprobante ")

         .AppendLine("  ORDER BY B.NombreProveedor ")
         .AppendLine("      ,B.FechaEmision ")
         .AppendLine("      ,A.IdSucursal ")
         .AppendLine("      ,A.IdTipoComprobante2 ")
         .AppendLine("      ,A.Letra2 ")
         .AppendLine("      ,A.CentroEmisor2 ")
         .AppendLine("      ,A.NumeroComprobante2 ")
      End With

      Return GetDataTable(stb)
   End Function

   Function GetPorProveedor(sucursales As Entidades.Sucursal(), proveedor As Entidades.Proveedor,
                            desde As Date, hasta As Date,
                            grabaLibro As String, nivelAutorizacionMaximo As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal, ")
         .AppendLine("  CCP.IdProveedor, ")
         .AppendLine("  P.CodigoProveedor, ")
         .AppendLine("  P.NombreProveedor, ")
         .AppendLine("	CCP.IdTipoComprobante, ")
         .AppendLine("	CCP.Letra, ")
         .AppendLine("	CCP.CentroEmisor, ")
         .AppendLine("	CCP.NumeroComprobante, ")
         .AppendLine("	CCP.Fecha, ")
         .AppendLine("	CCP.FechaVencimiento, ")
         .AppendLine("	CCP.ImporteTotal, ")
         .AppendLine("	CCP.Saldo, ")
         .AppendLine("	CCP.Observacion, ")
         '-- REQ-35958.- ---------------------------
         .AppendLine("	CMP.PeriodoFiscal ")
         '------------------------------------------
         .AppendLine("	FROM CuentasCorrientesProv CCP ")

         '-- REQ-35958.- ------------------------------------------------------------------------------------
         .AppendLine("	   INNER JOIN Proveedores P ON CCP.IdProveedor = P.IdProveedor")
         .AppendLine("	   INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("	   LEFT JOIN Compras CMP ")
         .AppendLine("          ON CCP.IdSucursal        = CMP.IdSucursal")
         .AppendLine("         AND CCP.IdTipoComprobante = CMP.IdTipoComprobante")
         .AppendLine("         AND CCP.Letra             = CMP.Letra")
         .AppendLine("         AND CCP.CentroEmisor      = CMP.CentroEmisor")
         .AppendLine("         AND CCP.NumeroComprobante = CMP.NumeroComprobante")
         .AppendLine("         AND CCP.IdProveedor       = CMP.IdProveedor")
         '---------------------------------------------------------------------------------------------------
         .AppendLine("	WHERE CCP.IdProveedor = " & proveedor.IdProveedor.ToString())

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         '.AppendLine("    And CCP.IdSucursal = " & idSucursal.ToString())

         If grabaLibro <> "TODOS" Then
            .AppendLine("      And TC.GrabaLibro = " & If(grabaLibro = "SI", "1", "0"))
         End If

         If desde.Year > 1 Then
            .AppendLine("	 And CONVERT(varchar(11), CCP.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         End If

         'No debe informar los Anticipos porque el PAGO tiene el saldo.
         .AppendLine("   AND TC.EsAnticipo = 'False'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'ANTICIPO'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'ANTICIPOPROV'")

         .AppendLine("   AND (CCP.IdEstadoComprobante IS NULL OR CCP.IdEstadoComprobante <> 'ANULADO') ")

         .AppendFormatLine("    AND P.NivelAutorizacion <= {0} AND TC.NivelAutorizacion <= {0}", nivelAutorizacionMaximo)

         .AppendLine(" ORDER BY P.NombreProveedor ")
         .AppendLine("   ,P.CodigoProveedor ")
         .AppendLine("	,CCP.Fecha")
         .AppendLine("	,CCP.IdTipoComprobante")
         .AppendLine("	,CCP.Letra")
         .AppendLine("	,CCP.CentroEmisor")
         .AppendLine("	,CCP.NumeroComprobante")
      End With

      Return GetDataTable(stb)
   End Function

   Public Sub CuentasCorrientesProvPagos(idSucursal As Integer, idProveedor As Long,
                                         idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                         fechaEmision As Date?, observacion As String, idCuentaBancaria As Integer?)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE CuentasCorrientesProv")
         .AppendFormatLine("   SET Observacion = '{0}'", observacion)
         If idCuentaBancaria.HasValue Then
            If idCuentaBancaria.Value = 0 Then
               'Si es 0 significa que le tiene que poner NULL
               .AppendFormatLine("      ,IdCuentaBancaria = NULL")
            Else
               'Si es diferente a 0 grabo el valor
               .AppendFormatLine("      ,IdCuentaBancaria = {0}", idCuentaBancaria.Value)
            End If
         End If
         If fechaEmision.HasValue Then
            .AppendFormatLine("      ,Fecha = '{0}'", ObtenerFecha(fechaEmision.Value, True))
         End If
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND idProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(query)
   End Sub

   Public Function GetSaldoProveedor(sucursales As Entidades.Sucursal(), proveedor As Entidades.Proveedor,
                                     fechaSaldo As Date, contemplaHora As Boolean,
                                     grabaLibro As Boolean?, comprobantesAsociados As String,
                                     ctaCteProveedoresSeparar As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         'Se llama de destintas pantallas, necesita tomar uno u otro campo para cubrir todas las combinaciones.
         If fechaSaldo.Year > 1 Then
            .AppendFormatLine("SELECT SUM(cc.ImporteTotal) as Saldo FROM CuentasCorrientesProv cc")
         Else
            .AppendFormatLine("SELECT SUM(cc.Saldo) as Saldo FROM CuentasCorrientesProv cc")
         End If
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendFormatLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(stbQuery, sucursales, "CC")

         .AppendFormatLine("   AND cc.IdProveedor = {0}", proveedor.IdProveedor)

         If fechaSaldo.Year > 1 Then
            .AppendFormatLine("   AND TC.EsAnticipo = 'False'")
            .AppendFormatLine("   AND CC.Fecha <= '{0}'", ObtenerFecha(fechaSaldo, contemplaHora))
         Else
            .AppendFormatLine("    AND TC.EsRecibo = 'False'")
         End If

         If comprobantesAsociados <> "TODOS" Then
            .AppendFormatLine("     AND CC.IdTipoComprobante IN ({0})", comprobantesAsociados)
         End If

         If ctaCteProveedoresSeparar And grabaLibro.HasValue Then
            .AppendFormatLine(" AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro.Value))
         End If
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetPagosAnulados(sucursal As Integer, desde As Date, hasta As Date, idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal
                     ,CCP.IdProveedor
                     ,P.CodigoProveedor
                     ,P.NombreProveedor
                     ,CCP.IdTipoComprobante
                     ,CCP.Letra
                     ,CCP.CentroEmisor
                     ,CCP.NumeroComprobante
                     ,CCP.Fecha
                     FROM CuentasCorrientesProv CCP
                     LEFT JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante
                     LEFT JOIN Proveedores P ON CCP.IdProveedor = P.IdProveedor ")
         .AppendLine("  WHERE  CCP.IdSucursal = " & sucursal.ToString())
         .AppendLine("        AND TC.EsRecibo = 'True'")
         .AppendLine("        AND CCP.IdEstadoComprobante = 'ANULADO'")
         .AppendLine("	      AND CONVERT(varchar(11), CCP.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
         .AppendLine("	      AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")

         If idProveedor > 0 Then
            .AppendLine("	AND P.IdProveedor = " & idProveedor)
         End If

         .AppendLine("	ORDER BY CCP.Fecha")
         .AppendLine("	,CCP.IdTipoComprobante")
         .AppendLine("	,CCP.Letra")
         .AppendLine("	,CCP.CentroEmisor")
         .AppendLine("	,CCP.NumeroComprobante")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetNumeroMaximoComprasNumeros(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Integer) As Integer
      Return GetCodigoMaximo("Numero", "ComprasNumeros",
                             String.Format("IdTipoComprobante = '{0}' AND LetraFiscal = '{1}' AND CentroEmisor = {2} AND IdSucursal = {3}",
                                           idTipoComprobante, letraFiscal, emisor, idSucursal)).ToInteger()
   End Function
   Public Function GetNumeroMaximo(idSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Integer) As Long
      Return GetCodigoMaximo("NumeroComprobante", "CuentasCorrientesProv",
                             String.Format("IdTipoComprobante = '{0}' AND Letra = '{1}' AND CentroEmisor = {2} AND IdSucursal = {3}",
                                           idTipoComprobante, letraFiscal, emisor, idSucursal))
   End Function

   Public Function BuscarPendientes(idSucursal As Integer, proveedor As Entidades.Proveedor, tiposComprobantes As String, numeroComprobante As Long,
                                    ctaCteProveedoresSeparar As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT ccp.IdSucursal AS Sucursal")
         .AppendFormatLine("     , ccp.FechaVencimiento")
         .AppendFormatLine("     , tp.Descripcion as Tipo")
         .AppendFormatLine("     , ccp.Letra")
         .AppendFormatLine("     , ccp.CentroEmisor AS Emisor")
         .AppendFormatLine("     , ccp.NumeroComprobante AS Numero")
         .AppendFormatLine("     , ccp.CuotaNumero AS Cuota")
         .AppendFormatLine("     , ccp.Fecha")
         .AppendFormatLine("     , ccp.ImporteCuota AS Importe")
         .AppendFormatLine("     , ccp.SaldoCuota AS Saldo")
         .AppendFormatLine("     , ccp.IdFormasPago")
         .AppendFormatLine("     , ccp.Observacion")
         .AppendFormatLine("     , ccp.IdTipoComprobante")
         .AppendFormatLine("     , ccp.IdProveedor")
         .AppendFormatLine("     , CONVERT(BIT, ISNULL(C.MercEnviada, 0)) AS MercEnviada")
         .AppendFormatLine("     , FP.Porcentaje")

         .AppendFormatLine("  FROM CuentasCorrientesProv aa ")
         .AppendFormatLine(" INNER JOIN CuentasCorrientesProvPagos ccp ON ccp.idsucursal=aa.idsucursal and ccp.IdSucursal = aa.IdSucursal ")
         .AppendFormatLine(" AND ccp.IdProveedor = aa.IdProveedor ")
         .AppendFormatLine(" AND ccp.idtipocomprobante = aa.idtipocomprobante ")
         .AppendFormatLine(" AND ccp.letra = aa.letra ")
         .AppendFormatLine(" AND ccp.centroemisor = aa.centroemisor ")
         .AppendFormatLine(" AND ccp.numerocomprobante = aa.numerocomprobante")
         .AppendFormatLine(" INNER JOIN TiposComprobantes tp ON aa.IdTipoComprobante = tp.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN VentasFormasPago FP ON FP.IdFormasPago = CCP.IdFormasPago")

         '-.PE-31850.-  and c.NumeroComprobante = aa.NumeroComprobante
         .AppendFormatLine(" LEFT JOIN Compras C ON aa.IdSucursal = C.IdSucursal")
         .AppendFormatLine("  AND aa.IdProveedor = C.IdProveedor")
         .AppendFormatLine("  AND aa.IdTipoComprobante = C.IdTipoComprobante")
         .AppendFormatLine("  AND aa.Letra = C.Letra")
         .AppendFormatLine("  AND aa.CentroEmisor = C.CentroEmisor")
         .AppendFormatLine("  AND aa.NumeroComprobante = C.NumeroComprobante")

         .AppendFormatLine(" WHERE aa.IdSucursal = {0} ", idSucursal.ToString())
         .AppendFormatLine(" AND aa.IdProveedor = {0} ", proveedor.IdProveedor)
         'Si el comprobante esta en la Cuenta Corriente, no debe mirar si es facturable.
         '.Append(" AND tp.EsFacturable = 'False'")
         .AppendFormatLine(" and ccp.SaldoCuota <> 0")     'Positivos: Factura y Nota Debito, Negativo: Nota Credito.

         .AppendLine("   AND tp.EsRecibo = 'False'")
         '.Append(" AND aa.IdTipoComprobante <> 'PAGO'")
         '.Append(" AND aa.IdTipoComprobante <> 'PAGOPROV'")

         If ctaCteProveedoresSeparar Then
            '  .AppendLine("   AND tp.GrabaLibro = '" & grabaLibro & "'")
            .AppendLine("   AND tp.IdTipoComprobante IN (" & tiposComprobantes & ")")
         End If

         If numeroComprobante <> 0 Then
            .AppendLine("AND aa.NumeroComprobante LIKE '%" & numeroComprobante & "%'")
         End If

         .AppendFormatLine(" ORDER BY CONVERT(varchar(11), ccp.FechaVencimiento, 120)")
         .AppendFormatLine("          ,tp.Descripcion")
         .AppendFormatLine("          ,ccp.Letra")
         .AppendFormatLine("          ,ccp.CentroEmisor")
         .AppendFormatLine("          ,ccp.NumeroComprobante")
         .AppendFormatLine("          ,ccp.CuotaNumero")
      End With

      Return GetDataTable(stbQuery)

   End Function
   Public Function GetSaldosCtaCte(idSucursal As Integer, desde As Date, hasta As Date, idProveedor As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdProveedor, ")
         .AppendLine("  P.CodigoProveedor, ")
         .AppendLine("  P.NombreProveedor, ")
         .AppendLine("  SUM(CCP.ImporteTotal) AS Total, ")
         .AppendLine("  SUM(CCP.Saldo) as Saldo ")

         .AppendLine("  FROM CuentasCorrientesProv CCP, Proveedores P ")

         .AppendLine("  WHERE CCP.IdProveedor = P.IdProveedor")
         .AppendLine("    AND CCP.IdSucursal = " & idSucursal.ToString())
         .AppendLine("    AND CCP.Saldo <> 0 ") 'Solo aparecerian aquellos que tienen Fact=NCred, deben aplicarlos.

         'No debe informar los Anticipos porque el RECIBO tiene el saldo.
         .AppendLine("   AND TC.EsAnticipo = 'False'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'ANTICIPO'")
         '.AppendLine("	AND CCP.IdTipoComprobante <> 'ANTICIPOPROV'")

         If desde.Year > 1 Then
            .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idProveedor > 0 Then
            .AppendLine("	AND CCP.IdProveedor = " & idProveedor.ToString())
         End If

         .AppendLine("   GROUP BY CCP.IdProveedor, P.CodigoProveedor, P.NombreProveedor ")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetComprobantesCtaCte() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .Append("SELECT DISTINCT IdTipoComprobante ")
         .Append("  FROM CuentasCorrientesProv ")
      End With
      Return GetDataTable(stb)
   End Function
   Public Function GetSaldosParaMinutas(idSucursal As Integer, comprobantesAsociados As String, grupo As String,
                                       fechaDesde As Date?, fechaHasta As Date?,
                                       numeroOrdenCompra As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P.IdProveedor, P.CodigoProveedor, P.NombreProveedor")
         .AppendFormatLine("     , CCP.Positivo, CCP.Negativo, (CASE WHEN CCP.Positivo <= ABS(CCP.Negativo) THEN CCP.Positivo ELSE ABS(CCP.Negativo) END) AS Aplicado")
         .AppendFormatLine("  FROM Proveedores P")
         .AppendFormatLine(" INNER JOIN (SELECT CC.IdProveedor")
         .AppendFormatLine("                  , SUM(CASE WHEN ccp.SaldoCuota > 0 THEN ccp.SaldoCuota ELSE 0 END) as Positivo")
         .AppendFormatLine("                  , SUM(CASE WHEN ccp.SaldoCuota < 0 THEN ccp.SaldoCuota ELSE 0 END) as Negativo")
         .AppendFormatLine("               FROM CuentasCorrientesProvPagos CCP")
         .AppendFormatLine("               INNER JOIN CuentasCorrientesProv CC ON CC.IdSucursal = CCP.IdSucursal AND CC.IdTipoComprobante = CCP.IdTipoComprobante AND CC.Letra = CCP.Letra")
         .AppendFormatLine("                                              AND CC.CentroEmisor = CCP.CentroEmisor AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendFormatLine("                                              AND CC.IdProveedor = CCP.IdProveedor")
         .AppendFormatLine("               INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine("              WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("                AND CCP.IdTipoComprobante IN ({0})", comprobantesAsociados)
         .AppendFormatLine("                AND CCP.SaldoCuota <> 0")
         .AppendFormatLine("                AND TC.EsPreElectronico = 'False'")

         If fechaDesde.HasValue Then
            .AppendFormatLine("                AND CCP.Fecha > '{0}'", ObtenerFecha(fechaDesde.Value.Date, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("                AND CCP.Fecha < '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If
         If Not String.IsNullOrEmpty(grupo) Then
            .AppendFormatLine("                AND TC.Grupo = '{0}'", grupo)
         End If
         If numeroOrdenCompra <> 0 Then
            .AppendFormatLine("                AND CC.NumeroOrdenCompra = {0}", numeroOrdenCompra)
         End If

         .AppendFormatLine("              GROUP BY CC.IdProveedor) AS CCP ON CCP.IdProveedor = P.IdProveedor")
         .AppendFormatLine(" WHERE CCP.Positivo <> 0 AND CCP.Negativo <> 0")
         .AppendFormatLine(" ORDER BY P.NombreProveedor")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetAlgunosComprobantesPorProveedor(idSucursal As Integer, idProveedor As Long, algunosComprobantes As String, grupo As String,
                                                   fechaDesde As Date?, fechaHasta As Date?,
                                                   numeroOrdenCompra As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT * FROM CuentasCorrientesProvPagos CCP")
         .AppendLine("    INNER JOIN CuentasCorrientesProv CC ON CC.IdSucursal = CCP.IdSucursal AND CC.IdTipoComprobante = CCP.IdTipoComprobante AND CC.Letra = CCP.Letra AND CC.CentroEmisor = CCP.CentroEmisor AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine("    AND CC.IdProveedor = CCP.IdProveedor")
         .AppendLine("    INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine(" WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CCP.SaldoCuota <> 0")
         .AppendFormatLine("   AND CC.IdProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND CCP.IdTipoComprobante IN ({0})", algunosComprobantes)
         .AppendFormatLine("   AND TC.EsPreElectronico = 'False'")
         If Not String.IsNullOrEmpty(grupo) Then
            .AppendFormatLine("   AND TC.Grupo = '{0}'", grupo)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("     AND CCP.Fecha > '{0}'", ObtenerFecha(fechaDesde.Value.Date, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("     AND CCP.Fecha < '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If
         If numeroOrdenCompra <> 0 Then
            .AppendFormatLine("   AND CC.numeroOrdenCompra = {0}", numeroOrdenCompra)
         End If

         .AppendLine(" ORDER BY CC.FechaVencimiento")
      End With

      Return GetDataTable(stb)
   End Function

End Class