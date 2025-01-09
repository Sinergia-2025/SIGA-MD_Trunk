Public Class CuentasCorrientesPagos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesPagos_I(idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Short,
                                       numeroComprobante As Long,
                                       cuotaNumero As Integer,
                                       fecha As Date,
                                       fechaVencimiento As Date,
                                       importeCuota As Double,
                                       saldoCuota As Double,
                                       idFormasPago As Integer,
                                       observacion As String,
                                       idTipoComprobante2 As String,
                                       numeroComprobante2 As Long,
                                       centroEmisor2 As Integer,
                                       cuotaNumero2 As Integer,
                                       letra2 As String,
                                       descuentoRecargoPorc As Decimal,
                                       descuentoRecargo As Decimal,
                                       importeCapital As Decimal,
                                       importeInteres As Decimal,
                                       fechaVencimiento2 As Date?,
                                       importeVencimiento2 As Decimal?,
                                       fechaVencimiento3 As Date?,
                                       importeVencimiento3 As Decimal?,
                                       fechaVencimiento4 As Date?,
                                       importeVencimiento4 As Decimal?,
                                       fechaVencimiento5 As Date?,
                                       importeVencimiento5 As Decimal?,
                                       codigoDeBarra As String,
                                       referenciaCuota As Long,
                                       idEmbarcacion As Long,
                                       idCama As Long,
                                       CodigoDeBarraSirplus As String,
                                       fechaPromedioCobro As Date?,
                                       promedioDiasCobro As Decimal?,
                                       cantidadDiasCobro As Decimal?)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO CuentasCorrientesPagos")
         .AppendFormatLine("           (IdSucursal")
         .AppendFormatLine("           ,IdTipoComprobante")
         .AppendFormatLine("           ,Letra")
         .AppendFormatLine("           ,CentroEmisor")
         .AppendFormatLine("           ,NumeroComprobante")
         .AppendFormatLine("           ,CuotaNumero")
         .AppendFormatLine("           ,Fecha")
         .AppendFormatLine("           ,FechaVencimiento")
         .AppendFormatLine("           ,ImporteCuota")
         .AppendFormatLine("           ,SaldoCuota")
         .AppendFormatLine("           ,IdFormasPago")
         .AppendFormatLine("           ,Observacion")
         .AppendFormatLine("           ,IdTipoComprobante2")
         .AppendFormatLine("           ,NumeroComprobante2")
         .AppendFormatLine("           ,CentroEmisor2")
         .AppendFormatLine("           ,CuotaNumero2")
         .AppendFormatLine("           ,Letra2")
         .AppendFormatLine("           ,DescuentoRecargoPorc")
         .AppendFormatLine("           ,DescuentoRecargo")
         .AppendFormatLine("           ,ImporteCapital")
         .AppendFormatLine("           ,ImporteInteres")
         .AppendFormatLine("           ,FechaVencimiento2")
         .AppendFormatLine("           ,ImporteVencimiento2")
         .AppendFormatLine("           ,FechaVencimiento3")
         .AppendFormatLine("           ,ImporteVencimiento3")
         '-- REQ-34469.- -----------------------------------------
         .AppendFormatLine("           ,FechaVencimiento4")
         .AppendFormatLine("           ,ImporteVencimiento4")
         .AppendFormatLine("           ,FechaVencimiento5")
         .AppendFormatLine("           ,ImporteVencimiento5")
         '--------------------------------------------------------
         .AppendFormatLine("           ,CodigoDeBarra")
         .AppendFormatLine("           ,ReferenciaCuota")
         .AppendFormatLine("           ,IdEmbarcacion")
         '-- REQ-36331.- -----------------------------------------
         .AppendFormatLine("           ,IdCama")
         '--------------------------------------------------------
         .AppendFormatLine("           ,CodigoDeBarraSirplus")

         .AppendFormatLine("           ,FechaPromedioCobro")
         .AppendFormatLine("           ,PromedioDiasCobro")
         .AppendFormatLine("           ,CantidadDiasCobro")

         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           ,'{0}'", idTipoComprobante)
         .AppendFormatLine("           ,'{0}'", letra)
         .AppendFormatLine("           , {0} ", centroEmisor)
         .AppendFormatLine("           , {0} ", numeroComprobante)
         .AppendFormatLine("           , {0} ", cuotaNumero)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fecha, True))
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaVencimiento, True))
         .AppendFormatLine("           , {0} ", importeCuota)
         .AppendFormatLine("           , {0} ", saldoCuota)
         .AppendFormatLine("           , {0} ", idFormasPago)
         .AppendFormatLine("           ,'{0}'", observacion)
         If String.IsNullOrEmpty(idTipoComprobante2) Then
            .AppendFormatLine("           ,NULL")
         Else
            .AppendFormatLine("           ,'{0}'", idTipoComprobante2)
         End If
         If numeroComprobante2 = 0 Then
            .AppendFormatLine("           ,NULL")
         Else
            .AppendFormatLine("           ,{0}", numeroComprobante2)
         End If
         If centroEmisor2 = 0 Then
            .AppendFormatLine("           ,NULL")
         Else
            .AppendFormatLine("           ,{0}", centroEmisor2)
         End If
         .AppendFormatLine("           ,{0}", cuotaNumero2)
         If String.IsNullOrEmpty(idTipoComprobante2) Then
            .AppendFormatLine("           ,NULL")
         Else
            .AppendFormatLine("           ,'{0}'", letra2)
         End If
         .AppendFormatLine("           ,{0}", descuentoRecargoPorc)
         .AppendFormatLine("           ,{0}", descuentoRecargo)
         .AppendFormatLine("           ,{0}", importeCapital)
         .AppendFormatLine("           ,{0}", importeInteres)
         If fechaVencimiento2.HasValue Then
            .AppendFormatLine("           ,'{0}'", Me.ObtenerFecha(fechaVencimiento2.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If
         If Not importeVencimiento2.HasValue Then
            .AppendFormatLine("           ,NULL")
         Else
            .AppendFormatLine("           ,{0}", importeVencimiento2.Value)
         End If
         If fechaVencimiento3.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaVencimiento3.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If
         If Not importeVencimiento3.HasValue Then
            .AppendFormatLine("           ,NULL")
         Else
            .AppendFormatLine("           ,{0}", importeVencimiento3.Value)
         End If
         '-- REQ-34469.- --------------------------------------------------------------------------
         If fechaVencimiento4.HasValue Then
            .AppendFormatLine("           ,'{0}'", Me.ObtenerFecha(fechaVencimiento4.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If
         If Not importeVencimiento4.HasValue Then
            .AppendFormatLine("           ,NULL")
         Else
            .AppendFormatLine("           ,{0}", importeVencimiento4.Value)
         End If
         If fechaVencimiento5.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaVencimiento5.Value, True))
         Else
            .AppendFormatLine("           ,NULL")
         End If
         If Not importeVencimiento5.HasValue Then
            .AppendFormatLine("           ,NULL")
         Else
            .AppendFormatLine("           ,{0}", importeVencimiento5.Value)
         End If
         '-----------------------------------------------------------------------------------------
         .AppendFormatLine("           ,'{0}'", codigoDeBarra)
         .AppendFormatLine("           , {0} ", referenciaCuota)

         '-- REQ-33207.- -------------------------------------------
         If idEmbarcacion <> 0 Then
            .AppendFormat("   , {0}", idEmbarcacion).AppendLine()
         Else
            .AppendFormat("   , NULL").AppendLine()
         End If
         '-- REQ-36331.- -------------------------------------------
         If idCama <> 0 Then
            .AppendFormat("   , {0}", idCama).AppendLine()
         Else
            .AppendFormat("   , NULL").AppendLine()
         End If
         '----------------------------------------------------------
         .AppendFormatLine("           ,'{0}'", CodigoDeBarraSirplus)

         '-- REQ-42455.- -------------------------------------------
         If fechaPromedioCobro.HasValue Then
            .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaPromedioCobro.Value, False))
         Else
            .AppendLine("           ,NULL")
         End If
         If promedioDiasCobro.HasValue Then
            .AppendFormat("           ,{0}", promedioDiasCobro.Value)
         Else
            .AppendLine("        ,NULL")
         End If
         If cantidadDiasCobro.HasValue Then
            .AppendFormat("           ,{0}", cantidadDiasCobro.Value)
         Else
            .AppendLine("        ,NULL")
         End If

         '----------------------------------------------------------
         .AppendFormatLine(")")
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")

   End Sub

   Public Sub CuentasCorrientesPagos_USaldo(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Integer,
                                            numeroComprobante As Long,
                                            cuotaNumero As Integer,
                                            saldoNuevo As Double)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesPagos")
         .AppendFormatLine("   SET SaldoCuota = SaldoCuota + {0}", saldoNuevo)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND CuotaNumero = {0}", cuotaNumero)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")
   End Sub

   Public Sub CuentasCorrientesPagos_UVencimiento(idSucursal As Integer,
                                                  idTipoComprobante As String,
                                                  letra As String,
                                                  centroEmisor As Integer,
                                                  numeroComprobante As Long,
                                                  cuotaNumero As Integer,
                                                  fechaVencimiento As Date,
                                                  referenciaCuota As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesPagos")
         .AppendFormatLine("   SET FechaVencimiento = '{0}'", ObtenerFecha(fechaVencimiento, True))
         .AppendFormatLine("     , ReferenciaCuota = {0}", referenciaCuota)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND CuotaNumero = {0}", cuotaNumero)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")
   End Sub

   Public Sub ActualizaFechas(idSucursal As Integer,
                              idTipoComprobante As String,
                              letra As String,
                              centroEmisor As Short,
                              numeroComprobante As Long,
                              fechaComprobante As Date,
                              fechaVencimiento As Date,
                              actualizarVencimiento As Boolean)
      Dim query = New StringBuilder
      With query
         .AppendFormatLine("UPDATE CCP SET ")
         .AppendFormatLine("           CCP.Fecha = '{0}'", fechaComprobante)
         If actualizarVencimiento Then
            .AppendFormatLine("			   ,CCP.FechaVencimiento = '{0}'", fechaVencimiento)
         End If
         .AppendFormatLine("        FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine("		   WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("		     AND CCP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("		     AND CCP.Letra = '{0}'", letra)
         .AppendFormatLine("		     AND CCP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("		     AND CCP.NumeroComprobante = {0}", numeroComprobante)
      End With
      Execute(query.ToString())
   End Sub

   Public Sub CuentasCorrientesPagos_UFechaEmision(idSucursal As Integer,
                                                   idTipoComprobante As String,
                                                   letra As String,
                                                   centroEmisor As Integer,
                                                   numeroComprobante As Long,
                                                   fechaEmision As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesPagos")
         .AppendFormatLine("   SET Fecha = '{0}'", ObtenerFecha(fechaEmision, True)).AppendLine()
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")

   End Sub

   Public Sub CuentasCorrientesPagos_UObservacion(idSucursal As Integer,
                                                   idTipoComprobante As String,
                                                   letra As String,
                                                   centroEmisor As Integer,
                                                   numeroComprobante As Long,
                                                   Observacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesPagos")
         .AppendFormatLine("   SET Observacion = '{0}'", Observacion)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")

   End Sub

   Public Sub CuentasCorrientesPagos_UComprobante(idSucursal As Integer,
                                                  idTipoComprobante As String,
                                                  letra As String,
                                                  centroEmisor As Short,
                                                  numeroComprobante As Long,
                                                  cuotaNumero As Integer,
                                                  idTipoComprobante2 As String,
                                                  numeroComprobante2 As Long,
                                                  centroEmisor2 As Integer,
                                                  cuotaNumero2 As Integer,
                                                  letra2 As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesPagos")
         .AppendFormatLine("   SET")
         .AppendFormatLine("			IdTipoComprobante2 = '{0}'", idTipoComprobante2)
         .AppendFormatLine("		,	NumeroComprobante2 = {0}", numeroComprobante2)
         .AppendFormatLine("		,	CentroEmisor2 = {0}", centroEmisor2)
         .AppendFormatLine("		,	CuotaNumero2 = {0}", cuotaNumero2)
         .AppendFormatLine("		,	Letra2 = '{0}'", letra2)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND CuotaNumero = {0}", cuotaNumero)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")
   End Sub


   Public Sub CuentasCorrientesPagos_D(idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Integer,
                                       numeroComprobante As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE CuentasCorrientesPagos")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(myQuery.ToString())
      Sincroniza_I(myQuery.ToString(), "CuentasCorrientesPagos")
   End Sub

   Public Function GetPorCuentaCorriente(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CCP.*")
         .AppendFormatLine("      ,(SELECT NombreProducto + ' / '  FROM VentasProductos")
         .AppendFormatLine("         WHERE idSucursal = CCP.IdSucursal And idTipoComprobante = CCP.IdTipoComprobante2 And letra = CCP.Letra2")
         .AppendFormatLine("           AND CentroEmisor = CCP.CentroEmisor2 AND NumeroComprobante = CCP.NumeroComprobante2")
         .AppendFormatLine("           FOR XML PATH('')) NombreProductos")
         .AppendFormatLine("  FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine(" WHERE CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CCP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCP.Letra = '{0}'", letra)
         .AppendFormatLine("   AND CCP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND CCP.NumeroComprobante = {0}", numeroComprobante)
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetImporteCuota(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Integer,
                                   numeroComprobante As Long,
                                   cuotaNumero As Integer) As Decimal
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ImporteCuota")
         .AppendFormatLine(" FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine(" WHERE IdSucursal = {0}   ", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'   ", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'   ", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}   ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND CuotaNumero = {0}", cuotaNumero)
      End With

      Dim dt = GetDataTable(stb)
      If dt.Rows.Count > 0 Then
         Return dt.Rows(0).Field(Of Decimal?)("ImporteCuota").IfNull()
      End If
      Return 0
   End Function

   Public Function GetSaldoCuota(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long,
                                 cuotaNumero As Integer,
                                 fechaSaldo As Date) As Decimal
      Dim stb = New StringBuilder()
      With stb
         '.Append("SELECT SaldoCuota")
         '.Append(" FROM CuentasCorrientesPagos CCP")
         '.AppendFormat(" WHERE IdSucursal = {0}   ", idSucursal)
         '.AppendFormat(" AND IdTipoComprobante = '{0}'   ", idTipoComprobante)
         '.AppendFormat(" AND Letra = '{0}'   ", letra)
         '.AppendFormat(" AND CentroEmisor = {0}   ", centroEmisor)
         '.AppendFormat(" AND NumeroComprobante = {0}", numeroComprobante)
         '.AppendFormat(" AND CuotaNumero = {0}", cuotaNumero)
         .AppendLine("SELECT SUM(ImporteCuota) as SaldoCuota")
         .AppendLine("  FROM CuentasCorrientesPagos CCP")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante2 = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra2 = '" & letra & "'")
         .AppendLine("   AND CentroEmisor2 = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante2 = " & numeroComprobante.ToString())
         .AppendLine("   AND CuotaNumero2 = " & cuotaNumero.ToString())
         .AppendLine("   AND Fecha <= '" & fechaSaldo.ToString("yyyyMMdd HH:mm:ss") & "'")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("SaldoCuota").ToString()) Then
            Return Decimal.Parse(dt.Rows(0)("SaldoCuota").ToString())
         End If
      End If

      Return 0

   End Function

   Public Function GetFechaVencimiento(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Integer,
                                        numeroComprobante As Long,
                                        cuotaNumero As Integer) As Date

      Dim stb = New StringBuilder()

      With stb
         .Append("SELECT FechaVencimiento")
         .Append(" FROM CuentasCorrientesPagos CCP")
         .AppendFormat(" WHERE IdSucursal = {0}   ", idSucursal)
         .AppendFormat(" AND IdTipoComprobante = '{0}'   ", idTipoComprobante)
         .AppendFormat(" AND Letra = '{0}'   ", letra)
         .AppendFormat(" AND CentroEmisor = {0}   ", centroEmisor)
         .AppendFormat(" AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat(" AND CuotaNumero = {0}", cuotaNumero)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      'If dt.Rows.Count > 0 Then
      '   If Not String.IsNullOrEmpty(dt.Rows(0)("FechaVencimiento").ToString()) Then
      Return Date.Parse(dt.Rows(0)("FechaVencimiento").ToString())
      '   End If
      'End If

      'Return Date.Now

   End Function

   Public Function GetFechaEmision(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Integer,
                                        numeroComprobante As Long,
                                        cuotaNumero As Integer) As Date

      Dim stb = New StringBuilder()

      With stb
         .Append("SELECT Fecha")
         .Append(" FROM CuentasCorrientesPagos CCP")
         .AppendFormat(" WHERE IdSucursal = {0}   ", idSucursal)
         .AppendFormat(" AND IdTipoComprobante = '{0}'   ", idTipoComprobante)
         .AppendFormat(" AND Letra = '{0}'   ", letra)
         .AppendFormat(" AND CentroEmisor = {0}   ", centroEmisor)
         .AppendFormat(" AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat(" AND CuotaNumero = {0}", cuotaNumero)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      Return Date.Parse(dt.Rows(0)("Fecha").ToString())

   End Function

   Public Function GetDetalleDeCobranzas(Sucursal As Integer,
                                        Desde As Date,
                                        Hasta As Date,
                                        IdVendedor As Integer) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT E.NombreEmpleado, ")
         .AppendLine("  CCP.FechaVencimiento, ")
         .AppendLine("  C.NombreCliente, ")
         .AppendLine("  C.Direccion, ")
         .AppendLine("  C.Telefono, ")
         .AppendLine("  P.NombreProducto, ")
         .AppendLine("  round((VP.PrecioNeto * 1.21), 0) Importe  ")
         .AppendLine("	FROM CuentasCorrientesPagos CCP ")
         .AppendLine(" INNER JOIN Ventas V ON V.idSucursal = CCP.IdSucursal ")
         .AppendLine(" AND V.IdTipoComprobante = CCP.IdTipoComprobante ")
         .AppendLine(" AND V.Letra = CCP.Letra ")
         .AppendLine(" AND   V.CentroEmisor = CCP.CentroEmisor ")
         .AppendLine(" AND V.NumeroComprobante = CCP.NumeroComprobante ")
         .AppendLine(" INNER JOIN Clientes C ON V.IdCliente = C.IdCliente ")
         .AppendLine(" INNER JOIN VentasProductos VP ON V.idSucursal = VP.IdSucursal ")
         .AppendLine(" AND V.IdTipoComprobante = VP.IdTipoComprobante ")
         .AppendLine(" AND V.Letra = VP.Letra ")
         .AppendLine(" AND   V.CentroEmisor = VP.CentroEmisor ")
         .AppendLine(" AND V.NumeroComprobante = VP.NumeroComprobante ")
         .AppendLine(" INNER JOIN Productos P ON VP.IdProducto = P.IdProducto ")
         .AppendLine(" INNER JOIN Empleados E ON V.NroDocVendedor = E.NroDocEmpleado ")
         .AppendLine(" WHERE CCP.SaldoCuota <> 0 ")
         If Desde <> Nothing Then
            .AppendFormat("	 AND CCP.FechaVencimiento >= '{0} 00:00:00'", Desde.ToString("yyyyMMdd"))
            .AppendFormat("	 AND CCP.FechaVencimiento <= '{0} 23:59:59'", Hasta.ToString("yyyyMMdd"))
         End If
         If IdVendedor > 0 Then
            .AppendLine("	AND C.IdVendedor = " & IdVendedor)
         End If
         .AppendLine(" ORDER BY V.Fecha ")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetSaldoClientes(Desde As Date,
                                     Hasta As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT S.Nombre, ")
         .AppendLine("SUM(SaldoCuota) Saldo ")
         .AppendLine("FROM CuentasCorrientesPagos CC ")
         .AppendLine("INNER JOIN Sucursales S on CC.IdSucursal = S.IdSucursal ")
         If Desde <> Nothing Then
            .AppendFormat("	 AND CC.FechaVencimiento >= '{0} 00:00:00'", Desde.ToString("yyyyMMdd"))
            .AppendFormat("	 AND CC.FechaVencimiento <= '{0} 23:59:59'", Hasta.ToString("yyyyMMdd"))
         End If
         .AppendLine("GROUP BY S.Nombre ")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetSaldosCtaCte(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                   idVendedor As Integer, idCliente As Long, idZonaGeografica As String,
                                   excluirSaldosNegativos As String, idCategoria As Integer,
                                   grabaLibro As String, grupo As String,
                                   excluirAnticipos As String, calcularPromedios As Boolean, excluirPreComprobantes As String,
                                   idProvincia As String, categoria As String, vendedor As String,
                                   usaClienteCtaCte As Boolean, idEstadoCliente As Integer,
                                   idCobrador As Integer, cobrador As Entidades.OrigenFK, nivelAutorizacion As Short, grupoCategoria As String,
                                   idFormaDePago As Integer, cliente As Entidades.Cliente.ClienteVinculado, idEmbarcacion As Long,
                                   activo As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT E.IdEmpleado AS IdVendedor")
         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,COB.IdEmpleado AS IdCobrador")
         .AppendLine("      ,COB.NombreEmpleado AS NombreCobrador")
         .AppendLine("      ,EC.NombreEstadoCliente")
         .AppendLine("      ,C.Cuit")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,LTRIM(RTRIM(C.Telefono + ' ' + C.Celular)) AS Telefonos")
         .AppendLine("      ,SUM(CCP.ImporteCuota) AS Total")
         .AppendLine("      ,SUM(CCP.SaldoCuota) AS Saldo")
         .AppendLine("      ,CH.IMPORTE2  ")
         If fechaHasta.Year > 1 Then
            .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < '" & fechaHasta.ToString("yyyy-MM-dd") & "' THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")
            If calcularPromedios Then
               .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') ELSE NULL END) AS CantDiasPromedio")
               .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') ELSE NULL END) AS CantDiasPromedioVencido")
            Else
               .AppendLine("      ,NULL AS CantDiasPromedio")
               .AppendLine("      ,NULL AS CantDiasPromedioVencido")
            End If
         Else
            .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), GETDATE(), 120) THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")
            If calcularPromedios Then
               .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedio")
               .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedioVencido")
            Else
               .AppendLine("      ,NULL AS CantDiasPromedio")
               .AppendLine("      ,NULL AS CantDiasPromedioVencido")
            End If
         End If
         If sucursales IsNot Nothing Then
            .AppendLine("  ,CCP.IdSucursal")
         End If
         '.AppendLine("      ,(SELECT CONVERT(VARCHAR(10), MIN(CASE WHEN CCP.SaldoCuota<>0 THEN CC.Fecha ELSE GETDATE() END), 3)) FechaInicioSaldo")
         .AppendLine("      ,MIN(CASE WHEN CCP.SaldoCuota <> 0 THEN CC.Fecha ELSE GETDATE() END) FechaInicioSaldo")

         '-- REQ-31250.- -JUAN-
         .AppendLine("      ,C.Direccion  ")

         '-.PE-32019.-
         .AppendLine("      ,C.IdClienteCtaCte")
         .AppendLine("      ,C1.CodigoCliente AS CodVin")
         .AppendLine("      ,C1.NombreCliente AS NombreVin")

         .AppendLine("  FROM CuentasCorrientesPagos CCP")
         .AppendLine("  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
         .AppendLine("                                 AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("                                 AND CC.Letra = CCP.Letra")
         .AppendLine("                                 AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("                                 AND CC.NumeroComprobante = CCP.NumeroComprobante")
         If usaClienteCtaCte Then
            .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdClienteCtaCte")
            .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdCliente") '-.PE-32019.-
         Else
            .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
            .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdClienteCtaCte")
         End If

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  LEFT JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador")
         End If

         .AppendLine("  INNER JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("   LEFT JOIN (select  Idcliente, sum(Importe) importe2 ")
         .AppendLine(" from cheques where IdEstadoCheque = 'ENCARTERA' group by  IdCliente) CH ON CC.iDCLIENTE = C.IDCLIENTE ")
         .AppendLine(" AND CH.IDCLIENTE = C.IDCLIENTE")

         '.AppendLine(" LEFT JOIN Ventas V ON V.IdSucursal = CC.IdSucursal")
         '.AppendLine(" AND V.IdTipoComprobante = CC.IdTipoComprobante")
         '.AppendLine(" AND V.Letra = CC.Letra")
         '.AppendLine(" AND V.CentroEmisor = CC.CentroEmisor")
         '.AppendLine(" AND V.NumeroComprobante = CC.NumeroComprobante ")

         .AppendLine("WHERE 1=1")
         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat("   AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If fechaHasta.Year > 1 Then
            .AppendLine("    AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            If cliente = Entidades.Cliente.ClienteVinculado.Vinculado Then '-.PE-32019.-
               .AppendLine("      AND CC.IdClienteCtaCte = " & idCliente.ToString())
            Else
               .AppendLine("    AND CC.IdCliente = " & idCliente.ToString())
            End If
         End If

         If idEmbarcacion > 0 Then
            .AppendLine("      AND CC.IdEmbarcacion = " & idEmbarcacion.ToString())
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         If idCobrador <> 0 Then
            .AppendFormatLine("   AND COB.IdEmpleado = {0}", idCobrador)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         If Not String.IsNullOrEmpty(grupoCategoria) Then
            .AppendLine("	AND CAT.IdGrupoCategoria = '" & grupoCategoria & "'")
         End If

         If idEstadoCliente > 0 Then
            .AppendLine("   AND C.IdEstado = " & idEstadoCliente.ToString())
         End If

         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.Activo = {0}", GetStringFromBoolean(activo = Entidades.Publicos.SiNoTodos.SI))
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If idFormaDePago > 0 Then
            .AppendLine("	AND CCP.IdFormasPago = " & idFormaDePago.ToString())
         End If

         .AppendLine("  GROUP BY E.IdEmpleado")

         .AppendLine(", E.NombreEmpleado, C.IdCliente, C.NombreCliente ,C.NombreDeFantasia, C.Direccion, C.IdCliente, C.CodigoCliente, CAT.NombreCategoria, COB.IdEmpleado, COB.NombreEmpleado, EC.NombreEstadoCliente, C.Cuit , CH.Importe2,L.NombreLocalidad,  ZG.NombreZonaGeografica, (C.Telefono + ' ' + C.Celular), CCP.IdSucursal, C.IdClienteCtaCte, C1.CodigoCliente, C1.NombreCliente")

         Dim CampoASumar As String = IIf(fechaHasta.Year > 1, "CCP.ImporteCuota", "CCP.SaldoCuota").ToString()

         If excluirSaldosNegativos = "SI" Then
            .AppendLine("    HAVING SUM(" & CampoASumar & ") > 0 ")
         Else
            .AppendLine("    HAVING SUM(" & CampoASumar & ") <> 0 ")
         End If
         'If Vendedor <> "MOVIMIENTO" Then
         '   .AppendLine("  ORDER BY NombreEmpleado, C.TipoDocVendedor, RIGHT(REPLICATE(' ',12) + C.NroDocVendedor,12), ")
         'Else
         .AppendLine("  ORDER BY E.NombreEmpleado, E.IdEmpleado, ")
         'End If

         .AppendLine(" C.NombreCliente, C.CodigoCliente")

      End With

      Return GetDataTable(stb)

   End Function
   Public Function GetInformeSituacionCrediticia(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                   idVendedor As Integer, idCliente As Long,
                                   excluirSaldosNegativos As String, idCategoria As Integer,
                                   grabaLibro As String,
                                   excluirAnticipos As String, calcularPromedios As Boolean, excluirPreComprobantes As String,
                                   categoria As String, vendedor As String,
                                   idCobrador As Integer, cobrador As Entidades.OrigenFK, nivelAutorizacion As Short,
                                   cliente As Entidades.Cliente.ClienteVinculado,
                                   activo As Entidades.Publicos.SiNoTodos, fechaCobro As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT E.IdEmpleado AS IdVendedor")
         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         ' .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,COB.IdEmpleado ")
         .AppendLine("      ,COB.NombreEmpleado AS NombreCobrador")
         '  .AppendLine("      ,C.Cuit")
         '  .AppendLine("      ,L.NombreLocalidad")
         ' .AppendLine("      ,SUM(CCP.ImporteCuota) AS Total")
         .AppendLine("      ,SUM(CCP.SaldoCuota) AS Saldo")
         .AppendLine("      ,CH.IMPORTE2  ")
         .AppendLine("      ,0 as SitCrediticia ")
         '  .AppendLine("      ,isnull(CH.IMPORTE2,0) + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) AS SitCrediticia")
         If sucursales IsNot Nothing Then
            .AppendLine("  ,CC.IdSucursal")
         End If
         .AppendLine("        ,C.LimiteDeCredito
	                           ,C.SaldoLimiteDeCredito")
         .AppendLine("  FROM CuentasCorrientesPagos CCP")
         .AppendLine("  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
         .AppendLine("                                 AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("                                 AND CC.Letra = CCP.Letra")
         .AppendLine("                                 AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("                                 AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         '      .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdClienteCtaCte")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  LEFT JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador")
         End If

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("   LEFT JOIN (select  Idcliente, sum(Importe) importe2 ")
         .AppendLine(" from cheques where (IdEstadoCheque = 'ENCARTERA' OR IdEstadoCheque = 'EGRESOCAJA' OR IdEstadoCheque = 'DEPOSITADO' OR IdEstadoCheque = 'PROVEEDOR') ")
         .AppendLine(" AND CONVERT(varchar(11), FechaCobro, 120) >= '" & Date.Today.ToString("yyyy-MM-dd") & "'")
         .AppendLine(" group by  IdCliente) CH ON CC.iDCLIENTE = C.IDCLIENTE ")

         .AppendLine(" AND CH.IDCLIENTE = C.IDCLIENTE")

         .AppendLine("WHERE 1=1")
         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If fechaHasta.Year > 1 Then
            .AppendLine("    AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            If cliente = Entidades.Cliente.ClienteVinculado.Vinculado Then '-.PE-32019.-
               .AppendLine("      AND CC.IdClienteCtaCte = " & idCliente.ToString())
            Else
               .AppendLine("    AND CC.IdCliente = " & idCliente.ToString())
            End If
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         If idCobrador <> 0 Then
            .AppendFormatLine("   AND COB.IdEmpleado = {0}", idCobrador)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.Activo = {0}", GetStringFromBoolean(activo = Entidades.Publicos.SiNoTodos.SI))
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         .AppendLine("  GROUP BY E.IdEmpleado")

         .AppendLine(", E.NombreEmpleado, C.IdCliente, C.NombreCliente , C.IdCliente, C.CodigoCliente,
                     CAT.NombreCategoria, COB.IdEmpleado, COB.NombreEmpleado
                     , CH.Importe2,
                     ZG.NombreZonaGeografica, CC.IdSucursal, C.LimiteDeCredito ,C.SaldoLimiteDeCredito")

         Dim CampoASumar As String = IIf(fechaHasta.Year > 1, "CCP.ImporteCuota", "CCP.SaldoCuota").ToString()

         If excluirSaldosNegativos = "SI" Then
            .AppendLine("    HAVING SUM(" & CampoASumar & ") > 0 ")
         Else
            .AppendLine("    HAVING SUM(" & CampoASumar & ") <> 0 ")
         End If
         'If Vendedor <> "MOVIMIENTO" Then
         '   .AppendLine("  ORDER BY NombreEmpleado, C.TipoDocVendedor, RIGHT(REPLICATE(' ',12) + C.NroDocVendedor,12), ")
         'Else
         '  .AppendLine("  ORDER BY E.NombreEmpleado, E.IdEmpleado, ")
         'End If

         '  .AppendLine(" C.NombreCliente, C.CodigoCliente")
         ' .AppendLine("   ORDER BY CH.IMPORTE2 + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) DESC  ")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetInformeSituacionCrediticiaPIVOT(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                   idVendedor As Integer, idCliente As Long,
                                   excluirSaldosNegativos As String, idCategoria As Integer,
                                   grabaLibro As String,
                                   excluirAnticipos As String, calcularPromedios As Boolean, excluirPreComprobantes As String,
                                   categoria As String, vendedor As String,
                                   idCobrador As Integer, cobrador As Entidades.OrigenFK, nivelAutorizacion As Short,
                                   cliente As Entidades.Cliente.ClienteVinculado,
                                   activo As Entidades.Publicos.SiNoTodos, fechaCobro As Date,
                                   pivotcolName As String, sumPivot As String) As DataTable
      Dim stb = New StringBuilder()
      With stb

         .AppendFormatLine("SELECT P1.IdSucursal, P1.IdVendedor
                          , P1.NombreVendedor
                          , P1.IdCliente
                          , P1.CodigoCliente
                          , P1.NombreCliente
                          , P1.NombreCategoria
	                      , P1.IdEmpleado
	                      , P1.NombreCobrador
	                      , P1.Saldo
	                      , P1.SitCrediticia
                         , P1.LimiteDeCredito
					          , P1.SaldoLimiteDeCredito")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         .AppendFormatLine("  FROM ( ")

         .AppendLine("SELECT E.IdEmpleado AS IdVendedor")
         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         '    .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,COB.IdEmpleado ")
         .AppendLine("      ,COB.NombreEmpleado AS NombreCobrador")
         '  .AppendLine("      ,C.Cuit")
         '  .AppendLine("      ,L.NombreLocalidad")
         ' .AppendLine("      ,SUM(CCP.ImporteCuota) AS Total")
         .AppendLine("      ,SUM(CCP.SaldoCuota) AS Saldo")
         .AppendLine("      ,CH.IMPORTE2  ")
         .AppendLine("      ,0 as SitCrediticia")
         '   .AppendLine("      ,isnull(CH.IMPORTE2,0) + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) AS SitCrediticia")
         If sucursales IsNot Nothing Then
            .AppendLine("  ,CC.IdSucursal")
         End If
         .AppendLine("        ,C.LimiteDeCredito
	                           ,C.SaldoLimiteDeCredito")
         .AppendFormatLine("             , 'CHQ__' + DATENAME(MONTH, CH.FechaCobro) MesCobro")
         .AppendLine("  FROM CuentasCorrientesPagos CCP")
         .AppendLine("  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
         .AppendLine("                                 AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("                                 AND CC.Letra = CCP.Letra")
         .AppendLine("                                 AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("                                 AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         '      .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdClienteCtaCte")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  LEFT JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador")
         End If

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("   LEFT JOIN (select  Idcliente, sum(Importe) importe2, FechaCobro ")
         .AppendLine(" from cheques where (IdEstadoCheque = 'ENCARTERA' OR IdEstadoCheque = 'EGRESOCAJA' OR IdEstadoCheque = 'DEPOSITADO' OR IdEstadoCheque = 'PROVEEDOR') ")
         .AppendLine(" AND CONVERT(varchar(11), FechaCobro, 120) >= '" & Date.Today.ToString("yyyy-MM-dd") & "'")
         .AppendLine(" group by  IdCliente, FechaCobro) CH ON CC.iDCLIENTE = C.IDCLIENTE ")

         .AppendLine(" AND CH.IDCLIENTE = C.IDCLIENTE")

         .AppendLine("WHERE 1=1")

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If fechaHasta.Year > 1 Then
            .AppendLine("    AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            If cliente = Entidades.Cliente.ClienteVinculado.Vinculado Then '-.PE-32019.-
               .AppendLine("      AND CC.IdClienteCtaCte = " & idCliente.ToString())
            Else
               .AppendLine("    AND CC.IdCliente = " & idCliente.ToString())
            End If
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         If idCobrador <> 0 Then
            .AppendFormatLine("   AND COB.IdEmpleado = {0}", idCobrador)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.Activo = {0}", GetStringFromBoolean(activo = Entidades.Publicos.SiNoTodos.SI))
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         .AppendLine("  GROUP BY E.IdEmpleado")

         .AppendLine(", E.NombreEmpleado, C.IdCliente, C.NombreCliente , C.IdCliente, C.CodigoCliente,
                     CAT.NombreCategoria, COB.IdEmpleado, COB.NombreEmpleado
                     , CH.Importe2,
                     CC.IdSucursal, C.LimiteDeCredito ,C.SaldoLimiteDeCredito,  'CHQ__' + DATENAME(MONTH, CH.FechaCobro)")

         Dim CampoASumar As String = IIf(fechaHasta.Year > 1, "CCP.ImporteCuota", "CCP.SaldoCuota").ToString()

         If excluirSaldosNegativos = "SI" Then
            .AppendLine("    HAVING SUM(" & CampoASumar & ") > 0 ")
         Else
            .AppendLine("    HAVING SUM(" & CampoASumar & ") <> 0 ")
         End If
         'If Vendedor <> "MOVIMIENTO" Then
         '   .AppendLine("  ORDER BY NombreEmpleado, C.TipoDocVendedor, RIGHT(REPLICATE(' ',12) + C.NroDocVendedor,12), ")
         'Else
         '  .AppendLine("  ORDER BY E.NombreEmpleado, E.IdEmpleado, ")
         'End If

         '  .AppendLine(" C.NombreCliente, C.CodigoCliente")

         .AppendFormatLine("        ) P")
         .AppendFormatLine(" PIVOT(SUM(importe2) FOR P.MesCobro in ({0})) AS P1", pivotcolName)
         .AppendFormatLine(" GROUP BY P1.IdSucursal, P1.IdVendedor
                          , P1.NombreVendedor
                          , P1.IdCliente
                          , P1.CodigoCliente
                          , P1.NombreCliente
                          , P1.NombreCategoria
	                      , P1.IdEmpleado
	                      , P1.NombreCobrador
	                      , P1.Saldo
	                      , P1.SitCrediticia
                         , P1.LimiteDeCredito
					          , P1.SaldoLimiteDeCredito")
         .AppendFormatLine(" ORDER BY P1.SitCrediticia DESC  ")

         '  .AppendLine("   ORDER BY CH.IMPORTE2 + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) DESC  ")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetControlInconsistenciasCtaCtevsCtaCtePagos(idSucursal As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.CodigoCliente, C.NombreCliente, CC.IdTipoComprobante")
         .AppendFormatLine("     , CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, CC.fecha")
         .AppendFormatLine("     , CC.Saldo, CCP.SaldoCuota")
         .AppendFormatLine("  FROM CuentasCorrientes CC")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN (SELECT CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante, SUM(CCP.SaldoCuota) as SaldoCuota ")
         .AppendFormatLine("               FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine("              GROUP BY CCP.IdSucursal, CCP.IdTipoComprobante, CCP.Letra, CCP.CentroEmisor, CCP.NumeroComprobante) CCP")
         .AppendFormatLine("         ON CCP.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("        AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("        AND CCP.Letra = CC.Letra ")
         .AppendFormatLine("        AND CCP.CentroEmisor = CC.CentroEmisor ")
         .AppendFormatLine("        AND CCP.NumeroComprobante = CC.NumeroComprobante ")
         .AppendFormatLine(" WHERE CC.Saldo <> ISNULL(CCP.SaldoCuota, 0)")
         .AppendFormatLine("   AND CC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND TC.EsRecibo = 'False' ")
         ' .AppendLine(" --   AND ROUND(CC.ImporteTotal,1) <> ROUND(CCP.ImporteCuota,1) ")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetEstadoCuentasCorrientes(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                              idVendedor As Integer, idCliente As Long, idZonaGeografica As String,
                                              excluirSaldosNegativos As String, idCategoria As Integer, grabaLibro As String, grupo As String, excluirAnticipos As String, calcularPromedios As Boolean, excluirPreComprobantes As String,
                                              idProvincia As String, categoria As String, agregarSinSaldo As String, vendedor As String, idEstadoCliente As Integer, idCobrador As Integer, cobrador As Entidades.OrigenFK,
                                              nivelAutorizacion As Short, grupoCategoria As String, cliente As Entidades.Cliente.ClienteVinculado,
                                              activo As Entidades.Publicos.SiNoTodos) As DataTable
      Dim stb = New StringBuilder()
      With stb
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("SELECT C.IdVendedor")
         Else
            .AppendLine("SELECT CC.IdVendedor")
         End If

         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,CC.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,COB.IdEmpleado")
         .AppendLine("      ,COB.NombreEmpleado as NombreCobrador")
         .AppendLine("      ,EC.NombreEstadoCliente")
         .AppendLine("      ,C.Cuit")
         .AppendLine("      ,L.NombreLocalidad")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,LTRIM(RTRIM(C.Telefono + ' ' + C.Celular)) AS Telefonos")
         .AppendLine("      ,SUM(CCP.ImporteCuota) AS Total")
         .AppendLine("      ,SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) AS Saldo")
         .AppendLine("      ,CH.IMPORTE2  ")
         '.AppendLine("      ,(SELECT CONVERT(VARCHAR(10), MIN(CASE WHEN CCP.SaldoCuota<>0 THEN CC.Fecha ELSE GETDATE() END), 3)) FechaInicioSaldo")
         .AppendLine("      ,MIN(CASE WHEN CCP.SaldoCuota <> 0 THEN CC.Fecha ELSE GETDATE() END) FechaInicioSaldo")

         If fechaHasta.Year > 1 Then
            .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < '" & fechaHasta.ToString("yyyy-MM-dd") & "' THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")

            If calcularPromedios Then
               .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') ELSE NULL END) AS CantDiasPromedio")
               .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') ELSE NULL END) AS CantDiasPromedioVencido")
            Else
               .AppendLine("      ,NULL AS CantDiasPromedio")
               .AppendLine("      ,NULL AS CantDiasPromedioVencido")
            End If

         Else
            .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), GETDATE(), 120) THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")

            If calcularPromedios Then
               .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedio")
               .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedioVencido")
            Else
               .AppendLine("      ,NULL AS CantDiasPromedio")
               .AppendLine("      ,NULL AS CantDiasPromedioVencido")
            End If
         End If

         .AppendLine("  ,CC.IdSucursal")
         '-- REQ-31250.- -JUAN-
         .AppendLine("  ,C.Direccion")

         '-.PE-32019.-
         .AppendLine("      ,C.IdClienteCtaCte")
         .AppendLine("      ,C1.CodigoCliente AS CodVin")
         .AppendLine("      ,C1.NombreCliente AS NombreVin")

         .AppendLine("  FROM Clientes C")

         '.AppendLine("   LEFT JOIN (SELECT * FROM CuentasCorrientes WHERE IdSucursal = " & IdSucursal.ToString() & ") CC ON CC.IdCliente = C.IdCliente")
         .AppendLine("   LEFT JOIN (SELECT * FROM CuentasCorrientes WHERE 1=1")
         GetListaSucursalesMultiples(stb, sucursales, "CuentasCorrientes")
         .AppendLine(") CC ON CC.IdCliente = C.IdCliente")


         '.AppendLine("  LEFT JOIN (select * from CuentasCorrientesPagos WHERE IdSucursal = " & IdSucursal.ToString() & ") CCP  ON CC.IdSucursal = CCP.IdSucursal ")
         .AppendLine("  LEFT JOIN (SELECT * FROM CuentasCorrientesPagos WHERE 1=1")

         GetListaSucursalesMultiples(stb, sucursales, "CuentasCorrientesPagos")
         .AppendLine(") CCP  ON CC.IdSucursal = CCP.IdSucursal")


         .AppendLine(" AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine(" AND CC.Letra = CCP.Letra")
         .AppendLine(" AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine(" AND CC.NumeroComprobante = CCP.NumeroComprobante")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  LEFT JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  LEFT JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  LEFT JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         .AppendLine("  INNER JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("   LEFT JOIN (select  Idcliente, sum(Importe) importe2 ")
         .AppendLine(" from cheques where IdEstadoCheque = 'ENCARTERA' group by  IdCliente) CH ON CC.iDCLIENTE = C.IDCLIENTE ")
         .AppendLine(" AND CH.IDCLIENTE = C.IDCLIENTE")

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador")
         End If

         '-.PE-32019.-
         .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdClienteCtaCte")

         .AppendLine(" WHERE 1 = 1")
         '.AppendLine(" WHERE C.Activo <> 0 ")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat("   AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If fechaHasta.Year > 1 Then
            .AppendLine("    AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            If cliente = Entidades.Cliente.ClienteVinculado.Vinculado Then  '-.PE-32019.-
               .AppendLine("      AND CC.IdClienteCtaCte = " & idCliente.ToString())
            Else
               .AppendLine("    AND CC.IdCliente = " & idCliente.ToString())
            End If
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         If idCobrador <> 0 Then
            .AppendFormatLine("   AND COB.IdEmpleado = {0}", idCobrador)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         If Not String.IsNullOrEmpty(grupoCategoria) Then
            .AppendLine("	AND CAT.IdGrupoCategoria = '" & grupoCategoria & "'")
         End If

         If idEstadoCliente > 0 Then
            .AppendLine("   AND C.IdEstado = " & idEstadoCliente.ToString())
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.Activo = {0}", GetStringFromBoolean(activo = Entidades.Publicos.SiNoTodos.SI))
         End If

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  GROUP BY C.IdVendedor, ")
         Else
            .AppendLine("  GROUP BY CC.IdVendedor,  ")
         End If

         .AppendLine(" E.NombreEmpleado, CC.IdCliente, C.NombreCliente, C.IdCliente, C.CodigoCliente, C.Direccion, CAT.NombreCategoria, COB.IdEmpleado, COB.NombreEmpleado, EC.NombreEstadoCliente, C.Cuit , CH.Importe2,L.NombreLocalidad,  ZG.NombreZonaGeografica, (C.Telefono + ' ' + C.Celular), CC.IdSucursal, C.IdClienteCtaCte, C1.CodigoCliente, C1.NombreCliente")
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  ORDER BY E.NombreEmpleado, C.IdVendedor, ")
         Else
            .AppendLine("  ORDER BY E.NombreEmpleado, CC.IdVendedor, ")
         End If

         .AppendLine(" C.NombreCliente, C.CodigoCliente")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetInformeSituacionCrediticiaSinSaldoPIVOT(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                              idVendedor As Integer, idCliente As Long,
                                              excluirSaldosNegativos As String, idCategoria As Integer,
                                              grabaLibro As String, excluirAnticipos As String,
                                              calcularPromedios As Boolean, excluirPreComprobantes As String,
                                              categoria As String, agregarSinSaldo As String,
                                              vendedor As String, idCobrador As Integer,
                                              cobrador As Entidades.OrigenFK,
                                              nivelAutorizacion As Short, cliente As Entidades.Cliente.ClienteVinculado,
                                              activo As Entidades.Publicos.SiNoTodos, FechaCobro As Date, pivotcolName As String,
                                              sumPivot As String) As DataTable
      Dim stb = New StringBuilder()
      With stb

         .AppendFormatLine("SELECT P1.IdSucursal, P1.IdVendedor
                          , P1.NombreVendedor
                          , P1.IdCliente
                          , P1.CodigoCliente
                          , P1.NombreCliente
                          , P1.NombreCategoria
	                      , P1.IdEmpleado
	                      , P1.NombreCobrador
	                      , P1.Saldo
	                      , P1.SitCrediticia
                         , P1.LimiteDeCredito
					          , P1.SaldoLimiteDeCredito")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         .AppendFormatLine("  FROM ( ")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("SELECT C.IdVendedor")
         Else
            .AppendLine("SELECT CC.IdVendedor")
         End If

         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,CC.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,COB.IdEmpleado")
         .AppendLine("      ,COB.NombreEmpleado as NombreCobrador")
         '  .AppendLine("      ,C.Cuit")
         '  .AppendLine("      ,L.NombreLocalidad")
         '.AppendLine("      ,SUM(CCP.ImporteCuota) AS Total")
         .AppendLine("      ,SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) AS Saldo")
         .AppendLine("      ,CH.IMPORTE2  ")
         '  .AppendLine("      ,isnull(CH.IMPORTE2, 0) + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) AS SitCrediticia")
         .AppendLine("      ,0 AS SitCrediticia")

         '.AppendLine("      ,(SELECT CONVERT(VARCHAR(10), MIN(CASE WHEN CCP.SaldoCuota<>0 THEN CC.Fecha ELSE GETDATE() END), 3)) FechaInicioSaldo")
         '  .AppendLine("      ,MIN(CASE WHEN CCP.SaldoCuota <> 0 THEN CC.Fecha ELSE GETDATE() END) FechaInicioSaldo")

         'If fechaHasta.Year > 1 Then
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < '" & fechaHasta.ToString("yyyy-MM-dd") & "' THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")

         '   If calcularPromedios Then
         '      .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') ELSE NULL END) AS CantDiasPromedio")
         '      .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') ELSE NULL END) AS CantDiasPromedioVencido")
         '   Else
         '      .AppendLine("      ,NULL AS CantDiasPromedio")
         '      .AppendLine("      ,NULL AS CantDiasPromedioVencido")
         '   End If

         'Else
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), GETDATE(), 120) THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")

         '   If calcularPromedios Then
         '      .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedio")
         '      .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedioVencido")
         '   Else
         '      .AppendLine("      ,NULL AS CantDiasPromedio")
         '      .AppendLine("      ,NULL AS CantDiasPromedioVencido")
         '   End If
         'End If

         .AppendLine("  ,CC.IdSucursal")

         '-.PE-32019.-
         '.AppendLine("      ,C.IdClienteCtaCte")
         '.AppendLine("      ,C1.CodigoCliente AS CodVin")
         '.AppendLine("      ,C1.NombreCliente AS NombreVin")
         .AppendLine("        ,C.LimiteDeCredito
	                           ,C.SaldoLimiteDeCredito")
         .AppendFormatLine("             , 'CHQ__' + DATENAME(MONTH, CH.FechaCobro) MesCobro")

         .AppendLine("  FROM Clientes C")

         '.AppendLine("   LEFT JOIN (SELECT * FROM CuentasCorrientes WHERE IdSucursal = " & IdSucursal.ToString() & ") CC ON CC.IdCliente = C.IdCliente")
         .AppendLine("   LEFT JOIN (SELECT * FROM CuentasCorrientes WHERE 1=1")
         GetListaSucursalesMultiples(stb, sucursales, "CuentasCorrientes")
         .AppendLine(") CC ON CC.IdCliente = C.IdCliente")


         '.AppendLine("  LEFT JOIN (select * from CuentasCorrientesPagos WHERE IdSucursal = " & IdSucursal.ToString() & ") CCP  ON CC.IdSucursal = CCP.IdSucursal ")
         .AppendLine("  LEFT JOIN (SELECT * FROM CuentasCorrientesPagos WHERE 1=1")

         GetListaSucursalesMultiples(stb, sucursales, "CuentasCorrientesPagos")
         .AppendLine(") CCP  ON CC.IdSucursal = CCP.IdSucursal")


         .AppendLine(" AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine(" AND CC.Letra = CCP.Letra")
         .AppendLine(" AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine(" AND CC.NumeroComprobante = CCP.NumeroComprobante")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  LEFT JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  LEFT JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  LEFT JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         .AppendLine("  INNER JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("   LEFT JOIN (select  Idcliente, sum(Importe) importe2, FechaCobro ")
         .AppendLine(" from cheques where (IdEstadoCheque = 'ENCARTERA' OR IdEstadoCheque = 'EGRESOCAJA' OR IdEstadoCheque = 'DEPOSITADO' OR IdEstadoCheque = 'PROVEEDOR') ")
         .AppendLine(" AND CONVERT(varchar(11), FechaCobro, 120) >= '" & Date.Today.ToString("yyyy-MM-dd") & "'")
         .AppendLine("group by  IdCliente, FechaCobro) CH ON CC.iDCLIENTE = C.IDCLIENTE ")
         .AppendLine(" AND CH.IDCLIENTE = C.IDCLIENTE")

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador")
         End If

         '-.PE-32019.-
         ' .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdClienteCtaCte")

         .AppendLine(" WHERE 1 = 1")
         '.AppendLine(" WHERE C.Activo <> 0 ")
         '  GetListaSucursalesMultiples(stb, sucursales, "CCP")
         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If fechaHasta.Year > 1 Then
            .AppendLine("    AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            If cliente = Entidades.Cliente.ClienteVinculado.Vinculado Then  '-.PE-32019.-
               .AppendLine("      AND CC.IdClienteCtaCte = " & idCliente.ToString())
            Else
               .AppendLine("    AND CC.IdCliente = " & idCliente.ToString())
            End If
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         If idCobrador <> 0 Then
            .AppendFormatLine("   AND COB.IdEmpleado = {0}", idCobrador)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.Activo = {0}", GetStringFromBoolean(activo = Entidades.Publicos.SiNoTodos.SI))
         End If
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  GROUP BY C.IdVendedor, ")
         Else
            .AppendLine("  GROUP BY CC.IdVendedor,  ")
         End If

         .AppendLine(" E.NombreEmpleado, CC.IdCliente, C.NombreCliente, C.IdCliente, C.CodigoCliente
                     , C.Direccion, CAT.NombreCategoria, COB.IdEmpleado, COB.NombreEmpleado
                     , CH.Importe2 
                    , CC.IdSucursal
                     ,  C.LimiteDeCredito ,C.SaldoLimiteDeCredito,  'CHQ__' + DATENAME(MONTH, CH.FechaCobro)")



         .AppendFormatLine("        ) P")
         .AppendFormatLine(" PIVOT(SUM(importe2) FOR P.MesCobro in ({0})) AS P1", pivotcolName)
         .AppendFormatLine(" GROUP BY P1.IdSucursal, P1.IdVendedor
                          , P1.NombreVendedor
                          , P1.IdCliente
                          , P1.CodigoCliente
                          , P1.NombreCliente
                          , P1.NombreCategoria
	                      , P1.IdEmpleado
	                      , P1.NombreCobrador
	                      , P1.Saldo
	                      , P1.SitCrediticia
                         , P1.LimiteDeCredito
					          , P1.SaldoLimiteDeCredito")
         .AppendFormatLine(" ORDER BY P1.SitCrediticia DESC  ")

         '.AppendLine("   ORDER BY CH.IMPORTE2 + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) DESC  ")


      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetInformeSituacionCrediticiaSinSaldo(sucursales As Entidades.Sucursal(), fechaHasta As Date,
                                              idVendedor As Integer, idCliente As Long,
                                              excluirSaldosNegativos As String, idCategoria As Integer,
                                              grabaLibro As String, excluirAnticipos As String,
                                              calcularPromedios As Boolean, excluirPreComprobantes As String,
                                              categoria As String, agregarSinSaldo As String,
                                              vendedor As String, idCobrador As Integer,
                                              cobrador As Entidades.OrigenFK,
                                              nivelAutorizacion As Short, cliente As Entidades.Cliente.ClienteVinculado,
                                              activo As Entidades.Publicos.SiNoTodos, FechaCobro As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("SELECT C.IdVendedor")
         Else
            .AppendLine("SELECT CC.IdVendedor")
         End If

         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,CC.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,COB.IdEmpleado")
         .AppendLine("      ,COB.NombreEmpleado as NombreCobrador")
         ' .AppendLine("      ,C.Cuit")
         ' .AppendLine("      ,L.NombreLocalidad")
         '.AppendLine("      ,SUM(CCP.ImporteCuota) AS Total")
         .AppendLine("      ,SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) AS Saldo")
         .AppendLine("      ,CH.IMPORTE2  ")
         .AppendLine("       ,0 as SitCrediticia")
         '.AppendLine("      ,isnull(CH.IMPORTE2, 0) + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) AS SitCrediticia")

         '.AppendLine("      ,(SELECT CONVERT(VARCHAR(10), MIN(CASE WHEN CCP.SaldoCuota<>0 THEN CC.Fecha ELSE GETDATE() END), 3)) FechaInicioSaldo")
         '  .AppendLine("      ,MIN(CASE WHEN CCP.SaldoCuota <> 0 THEN CC.Fecha ELSE GETDATE() END) FechaInicioSaldo")

         'If fechaHasta.Year > 1 Then
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < '" & fechaHasta.ToString("yyyy-MM-dd") & "' THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")

         '   If calcularPromedios Then
         '      .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') ELSE NULL END) AS CantDiasPromedio")
         '      .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), '" & fechaHasta.ToString("yyyy-MM-dd") & "') ELSE NULL END) AS CantDiasPromedioVencido")
         '   Else
         '      .AppendLine("      ,NULL AS CantDiasPromedio")
         '      .AppendLine("      ,NULL AS CantDiasPromedioVencido")
         '   End If

         'Else
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), GETDATE(), 120) THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")

         '   If calcularPromedios Then
         '      .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedio")
         '      .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedioVencido")
         '   Else
         '      .AppendLine("      ,NULL AS CantDiasPromedio")
         '      .AppendLine("      ,NULL AS CantDiasPromedioVencido")
         '   End If
         'End If

         .AppendLine("  ,CC.IdSucursal")

         '-.PE-32019.-
         '.AppendLine("      ,C.IdClienteCtaCte")
         '.AppendLine("      ,C1.CodigoCliente AS CodVin")
         '.AppendLine("      ,C1.NombreCliente AS NombreVin")
         .AppendLine("        ,C.LimiteDeCredito
	                           ,C.SaldoLimiteDeCredito")
         .AppendLine("  FROM Clientes C")

         '.AppendLine("   LEFT JOIN (SELECT * FROM CuentasCorrientes WHERE IdSucursal = " & IdSucursal.ToString() & ") CC ON CC.IdCliente = C.IdCliente")
         .AppendLine("   LEFT JOIN (SELECT * FROM CuentasCorrientes WHERE 1=1")
         GetListaSucursalesMultiples(stb, sucursales, "CuentasCorrientes")
         .AppendLine(") CC ON CC.IdCliente = C.IdCliente")


         '.AppendLine("  LEFT JOIN (select * from CuentasCorrientesPagos WHERE IdSucursal = " & IdSucursal.ToString() & ") CCP  ON CC.IdSucursal = CCP.IdSucursal ")
         .AppendLine("  LEFT JOIN (SELECT * FROM CuentasCorrientesPagos WHERE 1=1")

         GetListaSucursalesMultiples(stb, sucursales, "CuentasCorrientesPagos")
         .AppendLine(") CCP  ON CC.IdSucursal = CCP.IdSucursal")


         .AppendLine(" AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine(" AND CC.Letra = CCP.Letra")
         .AppendLine(" AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine(" AND CC.NumeroComprobante = CCP.NumeroComprobante")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  LEFT JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  LEFT JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  LEFT JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
         .AppendLine("  LEFT JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         .AppendLine("  INNER JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine("   LEFT JOIN (select  Idcliente, sum(Importe) importe2 ")
         .AppendLine(" from cheques where (IdEstadoCheque = 'ENCARTERA' OR IdEstadoCheque = 'EGRESOCAJA' OR IdEstadoCheque = 'DEPOSITADO' OR IdEstadoCheque = 'PROVEEDOR') ")
         .AppendLine(" AND CONVERT(varchar(11), FechaCobro, 120) >= '" & Date.Today.ToString("yyyy-MM-dd") & "'")
         .AppendLine(" group by  IdCliente) CH ON CC.iDCLIENTE = C.IDCLIENTE ")
         .AppendLine(" AND CH.IDCLIENTE = C.IDCLIENTE")

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador")
         End If

         '-.PE-32019.-
         ' .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdClienteCtaCte")

         .AppendLine(" WHERE 1 = 1")
         '.AppendLine(" WHERE C.Activo <> 0 ")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If fechaHasta.Year > 1 Then
            .AppendLine("    AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & idVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & idVendedor)
            End If
         End If

         If idCliente > 0 Then
            If cliente = Entidades.Cliente.ClienteVinculado.Vinculado Then  '-.PE-32019.-
               .AppendLine("      AND CC.IdClienteCtaCte = " & idCliente.ToString())
            Else
               .AppendLine("    AND CC.IdCliente = " & idCliente.ToString())
            End If
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         If idCobrador <> 0 Then
            .AppendFormatLine("   AND COB.IdEmpleado = {0}", idCobrador)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND C.Activo = {0}", GetStringFromBoolean(activo = Entidades.Publicos.SiNoTodos.SI))
         End If

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  GROUP BY C.IdVendedor, ")
         Else
            .AppendLine("  GROUP BY CC.IdVendedor,  ")
         End If

         .AppendLine(" E.NombreEmpleado, CC.IdCliente, C.NombreCliente, C.IdCliente, C.CodigoCliente
                     , C.Direccion, CAT.NombreCategoria, COB.IdEmpleado, COB.NombreEmpleado
                     , C.Cuit , CH.Importe2,L.NombreLocalidad  
                     ,  ZG.NombreZonaGeografica, CC.IdSucursal
                     ,  C.LimiteDeCredito ,C.SaldoLimiteDeCredito")

         ' If vendedor <> "MOVIMIENTO" Then
         ' .AppendLine("   ORDER BY CH.IMPORTE2 + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) DESC  ")
         '.AppendLine("  ORDER BY E.NombreEmpleado, C.IdVendedor, ")
         '   Else
         ' .AppendLine("  ORDER BY CH.IMPORTE2 + SUM(CASE WHEN CCP.SaldoCuota is NULL THEN 0 ELSE  CCP.SaldoCuota END) ")
         '.AppendLine("  ORDER BY E.NombreEmpleado, CC.IdVendedor, ")
         '   End If

         '  .AppendLine(" C.NombreCliente, C.CodigoCliente")

      End With

      Return GetDataTable(stb)

   End Function

   'Public Function GetSaldosPorVencimientos(sucursales As Entidades.Sucursal(),
   '                                         fechaHasta As String,
   '                                         IdVendedor As Integer,
   '                                         idCliente As Long,
   '                                         idZonaGeografica As String,
   '                                         excluirSaldosNegativos As String,
   '                                         idCategoria As Integer,
   '                                         grabaLibro As String,
   '                                         grupo As String,
   '                                         excluirAnticipos As String,
   '                                         calcularPromedios As Boolean,
   '                                         excluirPreComprobantes As String,
   '                                         idProvincia As String,
   '                                         categoria As String,
   '                                         usaClienteCtaCte As Boolean,
   '                                         idEstadoCliente As Integer,
   '                                         idCobrador As Integer,
   '                                         cobrador As Entidades.OrigenFK,
   '                                         nivelAutorizacion As Short,
   '                                         grupoCategoria As String) As DataTable
   '   Dim stb = New StringBuilder()
   '   With stb
   '      .AppendLine("SELECT C.IdVendedor")
   '      .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
   '      .AppendLine("      ,C.IdCliente")
   '      .AppendLine("      ,C.CodigoCliente")
   '      .AppendLine("      ,C.NombreCliente")
   '      .AppendLine("   	 ,C.NombreDeFantasia")
   '      .AppendLine("      ,CAT.NombreCategoria")
   '      .AppendLine("      ,COB.IdEmpleado AS IdCobrador")
   '      .AppendLine("      ,COB.NombreEmpleado as NombreCobrador")
   '      .AppendLine("      ,C.Cuit")
   '      .AppendLine("      ,ZG.NombreZonaGeografica")
   '      .AppendLine("      ,EC.NombreEstadoCliente")
   '      '  .AppendLine("      ,LTRIM(RTRIM(C.Telefono + ' ' + Celular)) AS Telefonos")
   '      .AppendLine("      ,SUM(CCP.ImporteCuota) AS Total")
   '      .AppendLine("      ,SUM(CCP.SaldoCuota) AS Saldo")
   '      '' ''.AppendLine("      ,CH.IMPORTE2  ")
   '      If fechaHasta = "EMISION" Then
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) < DATEADD(day, -120, CAST(GETDATE() AS DATE) ) THEN CCP.SaldoCuota ELSE 0 END) AS MOROSO ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) < DATEADD(day, -90,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.Fecha, 120) >= DATEADD(day, -120, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS ME120 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) <  DATEADD(day, -60, CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.Fecha, 120) >= DATEADD(day, -90, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS ME90 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) < DATEADD(day, -30,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.Fecha, 120) >= DATEADD(day, -60, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS ME60 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) < Convert(varchar(11), CAST(GETDATE() AS DATE), 120) AND  Convert(varchar(11), CCP.Fecha, 120) >= DATEADD(day, -30,CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS ME30 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) = CAST(GETDATE() AS DATE) THEN CCP.SaldoCuota ELSE 0 END) AS ALDIA ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) > CAST(GETDATE() AS DATE) AND  Convert(varchar(11), CCP.Fecha, 120) <= DATEADD(day, 30, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS MA30 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) > DATEADD(day, 30, CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.Fecha, 120) <= DATEADD(day, 60, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS MA60 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) > DATEADD(day, 60,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.Fecha, 120) <= DATEADD(day, 90,CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS MA90 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.Fecha, 120) > DATEADD(day, 90,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.Fecha, 120) <= DATEADD(day, 120, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS MA120 ")
   '      Else
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < DATEADD(day, -120, CAST(GETDATE() AS DATE) ) THEN CCP.SaldoCuota ELSE 0 END) AS MOROSO ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < DATEADD(day, -90,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.FechaVencimiento, 120) >= DATEADD(day, -120, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS ME120 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) <  DATEADD(day, -60, CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.FechaVencimiento, 120) >= DATEADD(day, -90, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS ME90 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < DATEADD(day, -30,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.FechaVencimiento, 120) >= DATEADD(day, -60, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS ME60 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), CAST(GETDATE() AS DATE), 120) AND  Convert(varchar(11), CCP.FechaVencimiento, 120) >= convert(varchar(11),DATEADD(dd, DATEPART(dd, getdate())* -1, getdate()),120) THEN CCP.SaldoCuota ELSE 0 END) AS ME30 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) = Convert(varchar(11),cast(DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0) as Date) , 120) THEN CCP.SaldoCuota ELSE 0 END) AS ALDIA ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) > CAST(GETDATE() AS DATE) AND  Convert(varchar(11), CCP.FechaVencimiento, 120) <= DATEADD(day, 30, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS MA30 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) > DATEADD(day, 30, CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.FechaVencimiento, 120) <= DATEADD(day, 60, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS MA60 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) > DATEADD(day, 60,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.FechaVencimiento, 120) <= DATEADD(day, 90,CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS MA90 ")
   '         .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) > DATEADD(day, 90,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCP.FechaVencimiento, 120) <= DATEADD(day, 120, CAST(GETDATE() AS DATE)) THEN CCP.SaldoCuota ELSE 0 END) AS MA120 ")
   '      End If

   '      If calcularPromedios Then
   '         .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedio")
   '         .AppendLine("      ,AVG(CASE WHEN CCP.SaldoCuota<>0 AND DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) > 0 THEN DATEDIFF(day, CONVERT(varchar(11), CCP.FechaVencimiento, 120), CONVERT(varchar(11), GETDATE(), 120)) ELSE NULL END) AS CantDiasPromedioVencido")
   '      Else
   '         .AppendLine("      ,NULL AS CantDiasPromedio")
   '         .AppendLine("      ,NULL AS CantDiasPromedioVencido")
   '      End If

   '      .AppendLine("  ,CCP.IdSucursal")

   '      .AppendLine("  FROM CuentasCorrientesPagos CCP")
   '      .AppendLine("  INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
   '      .AppendLine("                                 AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
   '      .AppendLine("                                 AND CC.Letra = CCP.Letra")
   '      .AppendLine("                                 AND CC.CentroEmisor = CCP.CentroEmisor")
   '      .AppendLine("                                 AND CC.NumeroComprobante = CCP.NumeroComprobante")
   '      If usaClienteCtaCte Then
   '         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdClienteCtaCte")
   '      Else
   '         .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
   '      End If
   '      .AppendLine("  INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
   '      .AppendLine("  INNER JOIN ZonasGeograficas ZG ON C.IdZonaGeografica = ZG.IdZonaGeografica")
   '      .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")

   '      If categoria <> "MOVIMIENTO" Then
   '         .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
   '      Else
   '         .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
   '      End If

   '      .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
   '      .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")

   '      .AppendLine("  INNER JOIN EstadosClientes EC ON EC.IdEstadoCliente = C.IdEstado")

   '      If cobrador = Entidades.OrigenFK.Actual Then
   '         .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador")
   '      Else
   '         .AppendLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador")
   '      End If

   '      GetListaSucursalesMultiples(stb, sucursales, "CCP")

   '      NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

   '      'If idSucursal >= 0 Then
   '      '   .AppendLine(" WHERE CCP.IdSucursal = " & idSucursal.ToString())
   '      'Else
   '      '   .AppendLine(" WHERE CCP.IdSucursal >= 0")
   '      'End If

   '      'GAR: 26/09/2017. Si tiene Deuda y esta de baja, que la ajuste pero la deje en cero.
   '      '.AppendLine(" AND C.Activo = 'True' ")

   '      If Not String.IsNullOrEmpty(idZonaGeografica) Then
   '         .AppendFormat("   AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
   '      End If

   '      If IdVendedor > 0 Then
   '         .AppendLine("	AND C.IdVendedor = " & IdVendedor)
   '      End If

   '      If idCliente > 0 Then
   '         .AppendLine("    AND C.IdCliente = " & idCliente.ToString())
   '      End If

   '      If idCategoria > 0 Then
   '         If categoria <> "MOVIMIENTO" Then
   '            .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
   '         Else
   '            .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
   '         End If
   '      End If

   '      If idCobrador <> 0 Then
   '         .AppendFormatLine("   AND COB.IdEmpleado = {0}", idCobrador)
   '      End If

   '      If grabaLibro <> "TODOS" Then
   '         .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
   '      End If

   '      If Not String.IsNullOrEmpty(grupo) Then
   '         .AppendLine("	AND TC.Grupo = '" & grupo & "'")
   '      End If

   '      If Not String.IsNullOrEmpty(grupoCategoria) Then
   '         .AppendLine("	AND CAT.IdGrupocategoria = '" & grupoCategoria & "'")
   '      End If

   '      If excluirAnticipos = "SI" Then
   '         .AppendLine("      AND TC.EsAnticipo = 'False'")
   '      End If

   '      If excluirPreComprobantes = "SI" Then
   '         '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
   '         .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
   '      End If

   '      If Not String.IsNullOrEmpty(idProvincia) Then
   '         .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
   '      End If

   '      If idEstadoCliente > 0 Then
   '         .AppendLine("    AND C.IdEstado = " & idEstadoCliente.ToString())
   '      End If

   '      '.AppendLine("  GROUP BY C.TipoDocVendedor, C.NroDocVendedor, E.NombreEmpleado, C.IdCliente, C.NombreCliente, C.IdCliente, C.CodigoCliente, CAT.NombreCategoria, C.Cuit, ZG.NombreZonaGeografica, (C.Telefono + ' ' + Celular), CCP.IdSucursal")
   '      .AppendLine("  GROUP BY C.IdVendedor, E.NombreEmpleado, C.IdCliente, C.NombreCliente,C.NombreDeFantasia, C.IdCliente, C.CodigoCliente, CAT.NombreCategoria, COB.IdEmpleado, COB.NombreEmpleado, C.Cuit, ZG.NombreZonaGeografica, EC.NombreEstadoCliente, CCP.IdSucursal")

   '      Dim CampoASumar As String = IIf(Date.Today().Year > 1, "CCP.ImporteCuota", "CCP.SaldoCuota").ToString()

   '      If excluirSaldosNegativos = "SI" Then
   '         .AppendLine("    HAVING SUM(" & CampoASumar & ") > 0 ")
   '      Else
   '         .AppendLine("    HAVING SUM(" & CampoASumar & ") <> 0 ")
   '      End If

   '      .AppendLine("  ORDER BY E.NombreEmpleado, C.IdVendedor, C.NombreCliente, C.CodigoCliente")

   '   End With

   '   Return GetDataTable(stb)

   'End Function
   Public Function GetSaldosPorVencimientos(sucursales As Entidades.Sucursal(), fechaCalculo As Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme,
                                            idCliente As Long, usaClienteCtaCte As Boolean, idVendedor As Integer,
                                            idCategoria As Integer, origenCategoria As Entidades.OrigenFK, grupoCategoria As String,
                                            idCobrador As Integer, origenCobrador As Entidades.OrigenFK,
                                            idZonaGeografica As String, grabaLibro As Entidades.Publicos.SiNoTodos, grupo As String,
                                            idProvincia As String, idEstadoCliente As Integer,
                                            rangosDias As Entidades.CuentaCorrienteAntiguedadSaldoConfig, sinRegistros As Boolean,
                                            excluirAnticipos As Entidades.Publicos.SiNo, excluirPreComprobantes As Entidades.Publicos.SiNo, excluirSaldosNegativos As Entidades.Publicos.SiNo,
                                            calcularPromedios As Boolean, nivelAutorizacion As Short) As DataTable
      'Dim fechaCalculo = If(fechaHasta = "EMISION", "Fecha", "FechaVencimiento")

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT C.IdVendedor")
         .AppendFormatLine("     , E.NombreEmpleado as NombreVendedor")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.NombreDeFantasia")
         .AppendFormatLine("     , CAT.NombreCategoria")
         '.AppendFormatLine("     , COB.IdEmpleado AS IdCobrador")
         .AppendFormatLine("     , COB.NombreEmpleado as NombreCobrador")
         .AppendFormatLine("     , C.Cuit")
         .AppendFormatLine("     , ZG.NombreZonaGeografica")
         .AppendFormatLine("     , EC.NombreEstadoCliente")
         .AppendFormatLine("     , CCP.*")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("        SELECT CCP.IdSucursal")
         .AppendFormatLine("             , CC.IdCliente")
         .AppendFormatLine("             , CAT.IdCategoria")
         .AppendFormatLine("             , COB.IdEmpleado AS IdCobrador")
         .AppendFormatLine("             , SUM(CCP.ImporteCuota) AS Total")
         .AppendFormatLine("             , SUM(CCP.SaldoCuota) AS Saldo")

         For Each r In rangosDias.Rangos
            .AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN {1} AND {2} THEN CCP.SaldoCuota ELSE 0 END) AS [{3}]",
                              fechaCalculo.ToString(), r.DiasDesde, r.DiasHasta, r.EtiquetaColumna)
         Next

         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN  121   AND  50000 THEN CCP.SaldoCuota ELSE 0 END) AS MOROSO", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN  91    AND  120   THEN CCP.SaldoCuota ELSE 0 END) AS ME120", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN  61    AND  90    THEN CCP.SaldoCuota ELSE 0 END) AS ME90", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN  31    AND  60    THEN CCP.SaldoCuota ELSE 0 END) AS ME60", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN  1     AND  30    THEN CCP.SaldoCuota ELSE 0 END) AS ME30", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN  0     AND  0     THEN CCP.SaldoCuota ELSE 0 END) AS ALDIA", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN -30    AND -1     THEN CCP.SaldoCuota ELSE 0 END) AS MA30", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN -60    AND -31    THEN CCP.SaldoCuota ELSE 0 END) AS MA60", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN -90    AND -61    THEN CCP.SaldoCuota ELSE 0 END) AS MA90", fechaCalculo)
         '.AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN -50000 AND -91    THEN CCP.SaldoCuota ELSE 0 END) AS MA120", fechaCalculo)

         If calcularPromedios Then
            .AppendFormatLine("             , AVG(DATEDIFF(DAY, CONVERT(DATE, CCP.Fecha),            CONVERT(DATE, GETDATE()))) AS CantDiasEmisionPromedio")
            .AppendFormatLine("             , AVG(DATEDIFF(DAY, CONVERT(DATE, CCP.FechaVencimiento), CONVERT(DATE, GETDATE()))) AS CantDiasPromedio")
            .AppendFormatLine("             , AVG(CASE WHEN CCP.FechaVencimiento >= CONVERT(DATE, GETDATE()) THEN DATEDIFF(DAY, CONVERT(DATE, CCP.FechaVencimiento), CONVERT(DATE, GETDATE())) ELSE NULL END) AS CantDiasPromedioVencido")
         Else
            .AppendFormatLine("             , NULL AS CantDiasEmisionPromedio")
            .AppendFormatLine("             , NULL AS CantDiasPromedio")
            .AppendFormatLine("             , NULL AS CantDiasPromedioVencido")
         End If

         .AppendFormatLine("          FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine("         INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = CCP.IdSucursal")
         .AppendFormatLine("                                        AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine("                                        AND CC.Letra = CCP.Letra")
         .AppendFormatLine("                                        AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendFormatLine("                                        AND CC.NumeroComprobante = CCP.NumeroComprobante")
         If usaClienteCtaCte Then
            .AppendFormatLine("         INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         Else
            .AppendFormatLine("         INNER JOIN Clientes C ON C.IdCliente = CC.IdClienteCtaCte")
         End If
         If origenCategoria = Entidades.OrigenFK.Movimiento Then
            .AppendFormatLine("         INNER JOIN Categorias CAT ON CAT.IdCategoria = CC.IdCategoria")
         Else
            .AppendFormatLine("         INNER JOIN Categorias CAT ON CAT.IdCategoria = C.IdCategoria")
         End If
         If origenCobrador = Entidades.OrigenFK.Movimiento Then
            .AppendFormatLine("         INNER JOIN Empleados COB ON COB.IdEmpleado = CC.IdCobrador")
         Else
            .AppendFormatLine("         INNER JOIN Empleados COB ON COB.IdEmpleado = C.IdCobrador")
         End If

         .AppendFormatLine("            INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendFormatLine("         INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante")
         If sinRegistros Then
            .AppendFormatLine("         WHERE 1 = 2")
         Else
            .AppendFormatLine("         WHERE 1 = 1")
         End If
         .AppendFormatLine("           AND CCP.SaldoCuota <> 0")
         GetListaSucursalesMultiples(stb, sucursales, "CCP")
         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If idCliente > 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", idCliente)
         End If
         If idVendedor > 0 Then
            .AppendFormatLine("           AND C.IdVendedor = {0}", idVendedor)
         End If
         If idCategoria > 0 Then
            .AppendFormatLine("           AND CAT.IdCategoria = {0}", idCategoria)
         End If
         If Not String.IsNullOrEmpty(grupoCategoria) Then
            .AppendFormatLine("           AND CAT.IdGrupocategoria = '{0}'", grupoCategoria)
         End If
         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormatLine("           AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If
         If Not String.IsNullOrEmpty(grupo) Then
            .AppendFormatLine("           AND TC.Grupo = '{0}'", grupo)
         End If
         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendFormatLine("           AND L.IdProvincia = '{0}'", idProvincia)
         End If
         If idEstadoCliente > 0 Then
            .AppendFormatLine("           AND C.IdEstado = {0}", idEstadoCliente)
         End If
         If idCobrador <> 0 Then
            .AppendFormatLine("           AND COB.IdEmpleado = {0}", idCobrador)
         End If

         If excluirAnticipos = Entidades.Publicos.SiNo.SI Then
            .AppendFormatLine("           AND TC.EsAnticipo = 'False'")
         End If
         If excluirPreComprobantes = Entidades.Publicos.SiNo.SI Then
            .AppendFormatLine("           AND TC.EsPreElectronico = 'False'")
         End If

         .AppendFormatLine("         GROUP BY CCP.IdSucursal, CC.IdCliente, CAT.IdCategoria, COB.IdEmpleado")
         .AppendFormatLine("        ) CCP")

         .AppendFormatLine("  INNER JOIN Clientes C ON C.IdCliente = CCP.IdCliente")
         .AppendFormatLine("  INNER JOIN Categorias CAT ON CAT.IdCategoria = CCP.IdCategoria")
         .AppendFormatLine("  INNER JOIN Empleados E ON E.IdEmpleado = C.IdVendedor")
         .AppendFormatLine("  INNER JOIN Empleados COB ON COB.IdEmpleado = CCP.IdCobrador")
         .AppendFormatLine("  INNER JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica")
         .AppendFormatLine("  INNER JOIN EstadosClientes EC ON C.IdEstado = EC.IdEstadoCliente")

         .AppendFormatLine(" WHERE 1 = 1")
         If excluirSaldosNegativos = Entidades.Publicos.SiNo.SI Then
            .AppendFormatLine("   AND CCP.Total  > 0")
         Else
            .AppendFormatLine("   AND CCP.Total <> 0")
         End If
         .AppendFormatLine(" ORDER BY E.NombreEmpleado, C.IdVendedor, C.NombreCliente, C.CodigoCliente")

      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          cuotaNumero As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.*")
         .AppendLine("      ,(SELECT NombreProducto + ' / '  FROM VentasProductos")
         .AppendLine("         WHERE idSucursal = CCP.IdSucursal And idTipoComprobante = CCP.IdTipoComprobante2 And letra = CCP.Letra2")
         .AppendLine("           AND CentroEmisor = CCP.CentroEmisor2 AND NumeroComprobante = CCP.NumeroComprobante2")
         .AppendLine("           FOR XML PATH('')) NombreProductos")
         .AppendLine("  FROM CuentasCorrientesPagos CCP")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", letra)
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat("   AND CuotaNumero = {0}", cuotaNumero)
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetDetalle(sucursales As Entidades.Sucursal(),
                              desde As Date,
                              hasta As Date,
                              IdVendedor As Integer,
                              idCliente As Long,
                              listaComprobantes As List(Of Entidades.TipoComprobante),
                              TipoSaldo As String,
                              vencimiento As String,
                              idZonaGeografica As String,
                              IdCategoria As Integer,
                              grabaLibro As String,
                              grupos As Entidades.Grupo(),
                              excluirSaldosNegativos As String,
                              excluirAnticipos As String,
                              excluirPreComprobantes As String,
                              idProvincia As String,
                              categoria As Entidades.OrigenFK,
                              vendedor As Entidades.OrigenFK,
                              cliente As Entidades.Cliente.ClienteVinculado,
                              excluirMinutas As String,
                              agrupaClienteCuentaCorriente As Boolean,
                              idCobrador As Integer,
                              cobrador As Entidades.OrigenFK,
                              fechaInteres As Date,
                              idMoneda As Integer,
                              tipoConversion As Entidades.Moneda_TipoConversion,
                              cotizDolar As Decimal,
                              nivelAutorizacion As Short,
                              grupoCategoria As String,
                              idFormaDePago As Integer,
                              IdEmbarcacion As Long,
                              CtaCteEmbarcacion As Boolean,
                              idLocalidad As Integer,
                              muestraDetalle As Boolean,
                              idCama As Long) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal")
         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("      ,C.IdVendedor")
         Else
            .AppendLine("      ,CC.IdVendedor")
         End If
         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.IdClienteCtaCte") '-.PE-32017.-

         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C1.CodigoCliente AS CodVin") '-.PE-32017.-
         .AppendLine("      ,C1.NombreCliente AS NombreVin")

         .AppendLine("      ,C.NombreCliente +  ' ( ' + CONVERT(varchar(20), C.CodigoCliente)  + ' ) ' +  C.Direccion + ' - ' + L.NombreLocalidad + ' - ' + P.NombreProvincia + (CASE WHEN C.Cuit IS NULL THEN '' ELSE ' - ' + C.Cuit END) + ' - Tel: ' +(CASE WHEN C.Telefono IS NULL THEN '' ELSE ' - ' + C.Telefono END)  + ' ' + (CASE WHEN C.Celular IS NULL THEN '' ELSE ' - ' + C.Celular END) + (CASE WHEN C.CorreoElectronico IS NULL THEN '' ELSE ' - ' + C.CorreoElectronico END)  + (CASE WHEN T.NombreTransportista IS NULL THEN '' ELSE ' - ' + T.NombreTransportista  END) AS NombreCliente2")
         .AppendLine("      ,C.NombreDeFantasia")
         .AppendLine("      ,ZG.NombreZonaGeografica")
         .AppendLine("      ,CCP.IdTipoComprobante")
         .AppendLine("      ,CCP.Letra")
         .AppendLine("      ,CCP.CentroEmisor")
         .AppendLine("      ,CCP.NumeroComprobante")
         .AppendLine("      ,CCP.CuotaNumero")
         .AppendLine("      ,CCP.Fecha")
         .AppendLine("      ,CCP.FechaVencimiento")
         If idMoneda = Entidades.Moneda.Peso Then
            .AppendLine("      ,CCP.ImporteCuota")
            .AppendLine("      ,CCP.SaldoCuota")
         Else
            .AppendFormatLine("      ,ROUND(CCP.ImporteCuota / {0}, 2) AS ImporteCuota", If(tipoConversion = Entidades.Moneda_TipoConversion.Comprobante, "CC.CotizacionDolar", cotizDolar.ToString()))
            .AppendFormatLine("      ,ROUND(CCP.SaldoCuota / {0}, 2) AS SaldoCuota", If(tipoConversion = Entidades.Moneda_TipoConversion.Comprobante, "CC.CotizacionDolar", cotizDolar.ToString()))
         End If

         .AppendLine("      ,CCP.Observacion ")
         .AppendLine("      ,I.TipoImpresora")
         .AppendLine("      ,CAT.NombreCategoria")

         If idMoneda = Entidades.Moneda.Peso Then
            .AppendFormatLine("      ,CONVERT(decimal(12,2), CCP.SaldoCuota * dbo.CtaCtePorcDescRecSaldo(CC.IdCategoria, CCP.Fecha, CCP.FechaVencimiento, '{0}', CCP.ImporteCuota, CCP.SaldoCuota) / 100) AS Interes", ObtenerFecha(fechaInteres, True))
         Else
            .AppendFormatLine("      ,CONVERT(decimal(12,2), ROUND(CCP.SaldoCuota * (dbo.CtaCtePorcDescRecSaldo(CC.IdCategoria, CCP.Fecha, CCP.FechaVencimiento, '{0}', CCP.ImporteCuota, CCP.SaldoCuota)) / 100 / {1}, 2)) AS Interes",
            ObtenerFecha(fechaInteres, True), If(tipoConversion = Entidades.Moneda_TipoConversion.Comprobante, "CC.CotizacionDolar", cotizDolar.ToString()))
         End If
         .AppendLine("      ,Est.NombreEstadoCliente")
         .AppendLine("      ,CC.IdFormasPago")
         .AppendLine("      ,FP.DescripcionFormasPago")
         .AppendLine("      ,CC.NumeroOrdenCompra")
         .AppendLine("      ,OC.IdProveedor")
         .AppendLine("      ,PRV.CodigoProveedor")
         .AppendLine("      ,PRV.NombreProveedor")
         .AppendLine("      ,CO.IdEmpleado AS IdCobrador")
         .AppendLine("      ,CO.NombreEmpleado AS NombreCobrador")
         .AppendLine("      ,CC.CotizacionDolar")
         .AppendLine("      ,CC.Direccion")
         .AppendLine("      ,CCP.IdEmbarcacion")
         '--REQ-36324.- -------------------------------------------
         .AppendLine("      ,CCP.IdCama")
         '---------------------------------------------------------
         If CtaCteEmbarcacion = True Then
            .AppendLine("      ,EM.NombreEmbarcacion")
         End If

         .AppendLine("      ,CC.Saldo")
         '--REQ-36217.- --------------------------------------------------------------------------------------
         .AppendFormatLine("     , C.IdLocalidad ")
         .AppendFormatLine("     , L.NombreLocalidad ")

         If muestraDetalle Then
            .AppendFormatLine("     , ISNULL((SELECT '(' + VP.IdProducto + ') - ' + VP.NombreProducto + ' // '")
            .AppendFormatLine("                 FROM VentasProductos VP")
            .AppendFormatLine("         WHERE VP.IdSucursal = CC.IdSucursal")
            .AppendFormatLine("                  AND VP.IdTipoComprobante = CC.IdTipoComprobante")
            .AppendFormatLine("                  AND VP.Letra = CC.Letra")
            .AppendFormatLine("                  AND VP.CentroEmisor = CC.CentroEmisor")
            .AppendFormatLine("                  AND VP.NumeroComprobante= CC.NumeroComprobante")
            .AppendFormatLine("                  FOR XML PATH('')), '') DetalleProducto")
         Else
            .AppendFormatLine("      , '' AS DetalleProducto")
         End If
         '----------------------------------------------------------------------------------------------------
         .AppendLine("	FROM CuentasCorrientesPagos CCP ")
         .AppendLine("  INNER JOIN CuentasCorrientes CC ON CCP.IdSucursal = CC.IdSucursal ")
         .AppendLine("                                 AND CCP.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendLine("                                 AND CCP.Letra = CC.Letra ")
         .AppendLine("                                 AND CCP.CentroEmisor = CC.CentroEmisor ")
         .AppendLine("                                 AND CCP.NumeroComprobante = CC.NumeroComprobante ")
         If agrupaClienteCuentaCorriente Then
            .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdClienteCtaCte")
            .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdCliente")
         Else
            .AppendLine("  INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
            .AppendLine("  LEFT JOIN Clientes C1 ON C1.IdCliente = CC.IdClienteCtaCte")
         End If


         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica ")
         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  LEFT OUTER JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND I.IdSucursal =  CCP.IdSucursal")

         If categoria = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         If cobrador = Entidades.OrigenFK.Actual Then
            .AppendLine("  INNER JOIN Empleados CO ON CO.IdEmpleado = C.IdCobrador")
         Else
            .AppendLine("  INNER JOIN Empleados CO ON CO.IdEmpleado = CC.IdCobrador")
         End If

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")

         If CtaCteEmbarcacion = True Then
            .AppendLine("  LEFT JOIN Embarcaciones EM ON EM.IdEmbarcacion = CC.IdEmbarcacion")
         End If

         .AppendLine("  LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")
         .AppendLine("  LEFT JOIN EstadosClientes Est ON Est.IdEstadoCliente = C.IdEstado ")
         .AppendLine("  LEFT JOIN VentasFormasPago FP ON FP.IdFormasPago = CC.IdFormasPago")
         .AppendLine("  LEFT JOIN OrdenesCompra OC ON OC.IdSucursal = CC.IdSucursal AND OC.NumeroOrdenCompra = CC.NumeroOrdenCompra")
         .AppendLine("  LEFT JOIN Proveedores PRV ON PRV.IdProveedor = OC.IdProveedor")
         .AppendLine("  WHERE 1=1")


         SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "CCP")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If desde.Year > 1 Then
            .AppendLine("	 AND CONVERT(varchar(11), CCP.FechaVencimiento, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), CCP.FechaVencimiento, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         End If

         If IdVendedor > 0 Then
            If vendedor = Entidades.OrigenFK.Actual Then
               .AppendLine("	AND C.IdVendedor = " & IdVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & IdVendedor)
            End If
         End If

         If idCliente > 0 Then
            If cliente = Entidades.Cliente.ClienteVinculado.Vinculado Then '-.PE-32017.-
               .AppendLine("  AND CC.IdClienteCtaCte = " & idCliente.ToString())
            Else
               .AppendLine("	AND CC.IdCliente = " & idCliente.ToString())
            End If
         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If listaComprobantes IsNot Nothing AndAlso listaComprobantes.Count > 0 Then
            .Append(" AND CCP.IdTipoComprobante IN (")
            For Each tc As Entidades.TipoComprobante In listaComprobantes
               .AppendFormat(" '{0}',", tc.IdTipoComprobante)
            Next
            .Remove(.Length - 1, 1)
            .Append(")")
         End If

         If TipoSaldo <> "TODOS" Then
            .AppendLine("   AND CCP.SaldoCuota <> 0 ")
         End If

         If vencimiento <> "TODOS" Then
            If desde.Year > 1 Then
               .AppendLine("   AND Convert(varchar(11), CCP.FechaVencimiento, 120) < '" & hasta.ToString("yyyy-MM-dd") & "'")
            Else
               'El dia de HOY no lo considero vencido.
               .AppendLine("   AND Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), getdate(), 120) ")
            End If
         End If

         If IdCategoria > 0 Then
            If categoria = Entidades.OrigenFK.Actual Then
               .AppendLine("   AND C.IdCategoria = " & IdCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & IdCategoria.ToString())
            End If
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         GetListaMultiples(stb, grupos, "TC")

         If Not String.IsNullOrEmpty(grupoCategoria) Then
            .AppendLine("	AND CAT.IdGrupocategoria = '" & grupoCategoria & "'")
         End If

         If excluirSaldosNegativos = "SI" Then
            .AppendLine("   AND CC.Saldo > 0 ")
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If excluirMinutas = "SI" Then
            .AppendLine("  AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
         End If

         If idCobrador > 0 Then
            .AppendLine("   AND CO.IdEmpleado = " & idCobrador.ToString())
         End If

         If idFormaDePago > 0 Then
            .AppendLine("	AND CCP.IdFormasPago = " & idFormaDePago.ToString())
         End If

         If IdEmbarcacion > 0 Then
            .AppendLine("   AND CCP.IdEmbarcacion = " & IdEmbarcacion.ToString())
         End If
         '-- REQ-36324.- ----------------------------------------------------
         If idCama > 0 Then
            .AppendLine("   AND CCP.IdCama = " & idCama.ToString())
         End If
         '-- REQ-36217.- ----------------------------------------------------
         If idLocalidad > 0 Then
            .AppendLine("   AND C.IdLocalidad = " & idLocalidad.ToString())
         End If
         '-------------------------------------------------------------------
         .AppendLine(" ORDER BY E.NombreEmpleado ")
         If vendedor = Entidades.OrigenFK.Actual Then
            .AppendLine("   ,C.IdVendedor ")
         Else
            .AppendLine("   ,CC.IdVendedor ")
         End If

         .AppendLine("   ,C.NombreCliente ")
         .AppendLine("   ,C.CodigoCliente ")
         .AppendLine("   ,CCP.Fecha")

      End With

      Return GetDataTable(stb.ToString())

   End Function

   '-- REQ-35667.- -----------------------------------------------------------------
   Public Function GetPorCodigoBarra(codigoBarra As String, codigoBarraSirplus As String, idCliente As Long?, fechaVencimiento As Date?, importe As Decimal?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CCP.*,C.NombreCliente, CC.IdCliente")
         .AppendFormatLine("  FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine(" INNER JOIN CuentasCorrientes CC")
         .AppendFormatLine("    ON CCP.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("   AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("   AND CCP.Letra = CC.Letra")
         .AppendFormatLine("   AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendFormatLine("   AND CCP.NumeroComprobante = CC.NumeroComprobante")
         .AppendFormatLine("   INNER JOIN CLientes C ON C.IdCliente = CC.IdCliente")
         .AppendFormatLine(" WHERE 1 = 1")
         If codigoBarra IsNot Nothing Then
            .AppendFormatLine("   AND CCP.CodigoDeBarra = '{0}' ", codigoBarra)
         End If
         If codigoBarraSirplus IsNot Nothing Then
            .AppendFormatLine("   AND CCP.CodigoDeBarraSirplus = '{0}' ", codigoBarraSirplus)
         End If
         If idCliente.HasValue Then
            .AppendFormatLine("   AND CC.IdCliente = {0} ", idCliente.Value)
         End If
         If fechaVencimiento.HasValue And importe.HasValue Then
            .AppendFormatLine("   AND ((CCP.FechaVencimiento  = '{0}' AND CCP.ImporteCuota        = {1}) OR", ObtenerFecha(fechaVencimiento.Value, False), importe)
            .AppendFormatLine("        (CCP.FechaVencimiento2 = '{0}' AND CCP.ImporteVencimiento2 = {1}) OR", ObtenerFecha(fechaVencimiento.Value, False), importe)
            .AppendFormatLine("        (CCP.FechaVencimiento3 = '{0}' AND CCP.ImporteVencimiento3 = {1}))  ", ObtenerFecha(fechaVencimiento.Value, False), importe)
         End If
      End With

      Return GetDataTable(stb)
   End Function
   '--------------------------------------------------------------------------------

   Public Function GetRecibosDeUnComprobante(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Short,
                                             numeroComprobante As Long,
                                             cuotaNumero As Integer?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CC.IdSucursal")
         .AppendLine("     , CC.IdTipoComprobante")
         .AppendLine("     , CC.Letra")
         .AppendLine("     , CC.CentroEmisor")
         .AppendLine("     , CC.NumeroComprobante")
         .AppendLine("     , CC.CuotaNumero")
         .AppendLine("     , CC.Fecha")
         .AppendLine("     , CC.FechaVencimiento")
         .AppendLine("     , CC.ImporteCuota")
         .AppendLine("     , CC.Observacion ")
         .AppendLine("     , CC.CuotaNumero2 ")
         .AppendLine("     , (SELECT COUNT(1)")
         .AppendLine("          FROM CuentasCorrientesPagos CC2")
         .AppendLine("         WHERE CC2.IdSucursal = CC.IdSucursal")
         .AppendLine("           AND CC2.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("           AND CC2.Letra = CC.Letra")
         .AppendLine("           AND CC2.CentroEmisor = CC.CentroEmisor")
         .AppendLine("           AND CC2.NumeroComprobante = CC.NumeroComprobante) ComprobantesAplicador")
         .AppendLine("  FROM CuentasCorrientesPagos CC")
         .AppendFormat(" WHERE (CC.IdSucursal = {0} AND CC.IdTipoComprobante2 = '{1}' AND CC.Letra2 = '{2}' AND CC.CentroEmisor2 = {3} AND CC.NumeroComprobante2 = {4}",
                       idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         If cuotaNumero.HasValue Then
            .AppendFormat(" AND CC.CuotaNumero2 = {0}", cuotaNumero.Value)
         End If
         .AppendLine(")")
         .AppendFormat("   AND (CC.IdSucursal <> {0} OR CC.IdTipoComprobante <> '{1}'  OR CC.Letra <> '{2}'  OR CC.CentroEmisor <> {3}  OR CC.NumeroComprobante <> {4}",
                       idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
         If cuotaNumero.HasValue Then
            .AppendFormat("  OR CC.CuotaNumero <> {0}", cuotaNumero.Value)
         End If
         .AppendLine(")")
         .AppendLine(" ORDER BY CC.Fecha,CC.IdTipoComprobante,CC.Letra,CC.CentroEmisor,CC.NumeroComprobante,CC.CuotaNumero")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPorCliente(sucursales As Entidades.Sucursal(),
                                 idCliente As Long,
                                 fechaUtilizada As String,
                                 desde As Date,
                                 hasta As Date,
                                 grabaLibro As String,
                                 grupo As String,
                                 excluirMinutas As String,
                                 soloConSaldo As Boolean,
                                 fechaInteres As Date,
                                 idMoneda As Integer,
                                 tipoConversion As Entidades.Moneda_TipoConversion,
                                 cotizDolar As Decimal,
                                 nivelAutorizacion As Short,
                                 excluirPreComprobantes As Boolean,
                                 IdEmbarcacion As Long,
                                 CtaCteEmbarcacion As Boolean, idCama As Long) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal")
         .AppendLine("      ,C.IdVendedor")
         .AppendLine("      ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("      ,CC.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("	    ,CCP.IdTipoComprobante")
         .AppendLine("	    ,CCP.Letra")
         .AppendLine("	    ,CCP.CentroEmisor")
         .AppendLine("	    ,CCP.NumeroComprobante")
         .AppendLine("	    ,CCP.CuotaNumero")
         .AppendLine("	    ,CONVERT(DATE, CCP.Fecha) AS Fecha")
         .AppendLine("      ,CONVERT(VARCHAR(5), CCP.Fecha, 108) AS Fecha_Hora")
         .AppendLine("	    ,CONVERT(DATE, CCP.Fecha) AS Fecha_Fecha")
         .AppendLine("      ,CONVERT(VARCHAR(5), CCP.Fecha, 108) AS Fecha_Hora")
         .AppendLine("	    ,CCP.FechaVencimiento")
         .AppendLine("      ,CC.IdEmbarcacion")
         .AppendLine("      ,CC.IdCama")

         If CtaCteEmbarcacion = True Then
            .AppendLine("      ,EM.NombreEmbarcacion")
         End If

         If idMoneda = Entidades.Moneda.Peso Then
            .AppendLine("	    ,CCP.ImporteCuota")
            .AppendLine("	    ,CCP.SaldoCuota")
         Else
            .AppendFormatLine("      ,ROUND(CCP.ImporteCuota / {0}, 2) AS ImporteCuota", If(tipoConversion = Entidades.Moneda_TipoConversion.Comprobante, "CC.CotizacionDolar", cotizDolar.ToString()))
            .AppendFormatLine("      ,ROUND(CCP.SaldoCuota / {0}, 2) AS SaldoCuota", If(tipoConversion = Entidades.Moneda_TipoConversion.Comprobante, "CC.CotizacionDolar", cotizDolar.ToString()))
         End If


         .AppendLine("	    ,CCP.Observacion AS ObservacionDetalle")
         .AppendLine("	    ,CC.Observacion ")
         If idMoneda = Entidades.Moneda.Peso Then
            .AppendFormatLine("      ,CONVERT(decimal(12,2), CCP.SaldoCuota * dbo.CtaCtePorcDescRecSaldo(CC.IdCategoria, CCP.Fecha, CCP.FechaVencimiento, '{0}', CCP.ImporteCuota, CCP.SaldoCuota) / 100) AS Interes", ObtenerFecha(fechaInteres, True))
         Else
            .AppendFormatLine("      ,CONVERT(decimal(12,2), ROUND(CCP.SaldoCuota * (dbo.CtaCtePorcDescRecSaldo(CC.IdCategoria, CCP.Fecha, CCP.FechaVencimiento, '{0}', CCP.ImporteCuota, CCP.SaldoCuota)) / 100 / {1}, 2)) AS Interes",
                       ObtenerFecha(fechaInteres, True), If(tipoConversion = Entidades.Moneda_TipoConversion.Comprobante, "CC.CotizacionDolar", cotizDolar.ToString()))

         End If

         .AppendLine("	    ,CCP.IdTipoComprobante2")
         .AppendLine("	    ,CCP.Letra2")
         .AppendLine("	    ,CCP.CentroEmisor2")
         .AppendLine("	    ,CCP.NumeroComprobante2")
         .AppendLine("	    ,CCP.CuotaNumero2")
         .AppendLine("      ,CONVERT(Bit, CASE WHEN EXISTS(SELECT * FROM CuentasCorrientes CCE WHERE CCE.IdSucursal = CCP.IdSucursal AND CCE.IdTipoComprobante=CCP.IdTipoComprobante2  AND CCE.LETRA=CCP.LETRA2 AND CCE.CentroEmisor=CCP.CentroEmisor2 AND CCE.NumeroComprobante=CCP.NumeroComprobante2) THEN 1 ELSE 0 END)  AS ExisteCtaCte")
         .AppendLine("      ,TC.EsRecibo")
         .AppendLine("  FROM CuentasCorrientesPagos CCP")
         .AppendLine(" INNER JOIN CuentasCorrientes CC ON CCP.IdSucursal = CC.IdSucursal")
         .AppendLine("                                AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("                                AND CCP.Letra = CC.Letra")
         .AppendLine("                                AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendLine("                                AND CCP.NumeroComprobante = CC.NumeroComprobante")
         If CtaCteEmbarcacion = True Then
            .AppendLine(" LEFT JOIN Embarcaciones EM ON EM.IdEmbarcacion = CC.IdEmbarcacion")
         End If
         .AppendLine(" INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendLine(" INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine(" INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")

         .AppendLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         NivelAutorizacionClienteTipoComprobante(stb, "C", "CAT", "TC", nivelAutorizacion)

         If soloConSaldo Then
            .AppendLine("   AND CCP.SaldoCuota <> 0 ")
         End If

         If grabaLibro <> "TODOS" Then
            .AppendFormatLine("   AND TC.GrabaLibro = {0}", If(grabaLibro = "SI", "1", "0"))
         End If

         If desde.Year > 1 Then
            If fechaUtilizada = "EMISION" Then
               .AppendFormatLine("   AND CCP.Fecha >= '{0}'", ObtenerFecha(desde.Date, True))
               .AppendFormatLine("   AND CCP.Fecha <= '{0}'", ObtenerFecha(hasta.Date.AddDays(1).AddSeconds(-1), True))
            Else
               .AppendFormatLine("   AND CCP.FechaVencimiento >= '{0}'", ObtenerFecha(desde.Date, True))
               .AppendFormatLine("   AND CCP.FechaVencimiento <= '{0}'", ObtenerFecha(hasta.Date.AddDays(1).AddSeconds(-1), True))
            End If
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendFormatLine("   AND TC.Grupo = '{0}'", grupo)
         End If

         If excluirMinutas = "SI" Then
            .AppendLine("   AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
         End If

         If excluirPreComprobantes Then
            .AppendLine("   AND TC.EsPreElectronico = 'False'")
         End If

         If IdEmbarcacion > 0 Then
            .AppendLine("   AND CC.IdeMBARCACION = " & IdEmbarcacion.ToString())
         End If

         If idCama > 0 Then
            .AppendLine("   AND CC.IdCama = " & idCama.ToString())
         End If

         .AppendLine(" ORDER BY ")
         If fechaUtilizada = "EMISION" Then
            .AppendLine("	CONVERT(DATE, CCP.Fecha)")
         Else
            .AppendLine("	CONVERT(DATE, CCP.FechaVencimiento)")
         End If
         .AppendLine("	,CCP.IdTipoComprobante")
         .AppendLine("	,CCP.Letra")
         .AppendLine("	,CCP.CentroEmisor")
         .AppendLine("	,CCP.NumeroComprobante")
         .AppendLine("	,CCP.CuotaNumero")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetDetalleProximoPago(sucursales As Entidades.Sucursal(),
                                         desde As Date,
                                         hasta As Date?,
                                         IdVendedor As Integer,
                                         idCliente As Long,
                                         idTipoComprobante As String,
                                         saldo As String,
                                         vencimiento As String,
                                         idZonaGeografica As String,
                                         idCategoria As Integer,
                                         grabaLibro As String,
                                         grupo As String,
                                         excluirSaldosNegativos As String,
                                         excluirAnticipos As String,
                                         excluirPreComprobantes As String,
                                         idProvincia As String,
                                         categoria As String,
                                         vendedor As String,
                                         excluirMinutas As String,
                                         muestraDeudaAnterior As Boolean,
                                         agrupadoPorClienteCtaCte As Boolean,
                                         grupoCategoria As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("   With records ")
         .AppendLine(" AS ( ")
         .AppendLine(" Select CCP.IdSucursal ")
         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("      ,C.IdVendedor")
         Else
            .AppendLine("      ,CC.IdVendedor")
         End If
         .AppendLine("   ,E.NombreEmpleado as NombreVendedor ")

         If agrupadoPorClienteCtaCte Then
            .AppendLine("      ,CC.IdClienteCtaCte as IdCliente")
         Else
            .AppendLine("   ,CC.IdCliente ")
         End If

         .AppendLine("   ,C.CodigoCliente ")
         .AppendLine("   ,C.NombreCliente ")
         .AppendLine("   ,C.NombreCliente +  ' ( ' + CONVERT(varchar(20), C.CodigoCliente)  + ' ) ' +  C.Direccion + ' - ' + L.NombreLocalidad + ' - ' + P.NombreProvincia + (CASE WHEN C.Cuit IS NULL THEN '' ELSE ' - ' + C.Cuit END) + ' - Tel: ' +(CASE WHEN C.Telefono IS NULL THEN '' ELSE ' - ' + C.Telefono END)  + ' ' + (CASE WHEN C.Celular IS NULL THEN '' ELSE ' - ' + C.Celular END) + (CASE WHEN C.CorreoElectronico IS NULL THEN '' ELSE ' - ' + C.CorreoElectronico END)  + (CASE WHEN T.NombreTransportista IS NULL THEN '' ELSE ' - ' + T.NombreTransportista  END) AS NombreCliente2 ")

         If agrupadoPorClienteCtaCte Then
            .AppendLine("      ,CC.IdCliente AS IdClienteHijo")
            .AppendLine("      ,C2.CodigoCliente AS CodigoClienteHijo")
            .AppendLine("      ,C2.NombreCliente AS NombreClienteHijo")
         Else
            .AppendLine("      ,NULL AS IdClienteHijo")
            .AppendLine("      ,NULL AS CodigoClienteHijo")
            .AppendLine("      ,NULL AS NombreClienteHijo")
         End If

         .AppendLine("   ,ZG.NombreZonaGeografica ")
         .AppendLine("      ,CCP.IdTipoComprobante")
         .AppendLine("      ,CCP.Letra")
         .AppendLine("      ,CCP.CentroEmisor")
         .AppendLine("      ,CCP.NumeroComprobante")
         .AppendLine("      ,CCP.CuotaNumero")
         .AppendLine("      ,CCP.Fecha")
         .AppendLine("      ,CCP.FechaVencimiento")
         .AppendLine("      ,CCP.ImporteCuota")
         .AppendLine("      ,CCP.SaldoCuota")
         .AppendLine("      ,CCP.Observacion ")
         .AppendLine("      ,I.TipoImpresora")
         .AppendLine("      ,CAT.NombreCategoria")
         '  .AppendLine("          ,(select Top 1 V.NombreProducto FROM  VentasProductos V WHERE CCP.IdSucursal = V.IdSucursal AND CCP.IdTipoComprobante = V.IdTipoComprobante AND CCP.Letra = V.Letra AND CCP.CentroEmisor = V.CentroEmisor AND CCP.NumeroComprobante = V.NumeroComprobante) AS NombreProducto")
         .AppendLine("      ,CONVERT(decimal(12,2), CCP.SaldoCuota * dbo.CtaCtePorcDescRecSaldo(CC.IdCategoria, CCP.Fecha, CCP.FechaVencimiento, GETDATE(), CCP.ImporteCuota, CCP.SaldoCuota) / 100) AS Interes")
         .AppendLine(" 	,ROW_NUMBER() OVER (PARTITION BY CC.IdCliente , CCP.IdSucursal , CCP.IdTipoComprobante ,CCP.Letra ,CCP.CentroEmisor ,CCP.NumeroComprobante")
         .AppendLine("                       ORDER BY E.NombreEmpleado ,C.NombreCliente  ")
         .AppendLine("                        ,C.CodigoCliente ")
         .AppendLine("                         ,CCP.Fecha) rn ")

         .AppendLine("    ,(SELECT NombreProducto + ' / '  FROM VentasProductos VP")
         .AppendLine("         WHERE VP.IdSucursal = CCP.IdSucursal And VP.IdTipoComprobante = CCP.IdTipoComprobante And VP.Letra = CCP.Letra")
         .AppendLine("         AND VP.CentroEmisor = CCP.CentroEmisor AND VP.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine("         FOR XML PATH('')) NombreProductos")

         .AppendLine("	FROM CuentasCorrientesPagos CCP ")
         .AppendLine("  INNER JOIN CuentasCorrientes CC ON CCP.IdSucursal = CC.IdSucursal ")
         .AppendLine("  AND CCP.IdTipoComprobante = CC.IdTipoComprobante ")
         .AppendLine("  AND CCP.Letra = CC.Letra ")
         .AppendLine("  AND CCP.CentroEmisor = CC.CentroEmisor ")
         .AppendLine("  AND CCP.NumeroComprobante = CC.NumeroComprobante ")

         If agrupadoPorClienteCtaCte Then
            .AppendLine("  INNER JOIN Clientes C ON CC.IdClienteCtaCte = C.IdCliente ")
            .AppendLine("  INNER JOIN Clientes C2 ON CC.IdCliente = C2.IdCliente ")
         Else
            .AppendLine("  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente ")
         End If

         .AppendLine("  INNER JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica ")

         If vendedor <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
         Else
            .AppendLine("  INNER JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
         End If

         .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  LEFT OUTER JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND I.IdSucursal =  CCP.IdSucursal") ' & Sucursal.ToString())

         If categoria <> "MOVIMIENTO" Then
            .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
         Else
            .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
         End If

         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
         .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine(" LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")
         '.AppendLine("  WHERE CCP.IdSucursal = " & Sucursal.ToString())
         .AppendLine("  WHERE 1 = 1")
         SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "CCP")

         .AppendFormatLine("	 AND CCP.FechaVencimiento >= '{0}'", ObtenerFecha(desde, False))
         If hasta.HasValue Then
            .AppendFormatLine("	 AND CCP.FechaVencimiento <= '{0}'", ObtenerFecha(hasta.Value.Date.AddDays(1).AddSeconds(-1), True))
         End If

         If IdVendedor > 0 Then
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("	AND C.IdVendedor = " & IdVendedor)
            Else
               .AppendLine("	AND CC.IdVendedor = " & IdVendedor)
            End If
         End If

         If idCliente > 0 Then
            If agrupadoPorClienteCtaCte Then
               .AppendLine("	AND CC.IdClienteCtaCte = " & idCliente.ToString())
            Else
               .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
            End If

         End If

         If Not String.IsNullOrEmpty(idZonaGeografica) Then
            .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND CCP.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If saldo <> "TODOS" Then
            .AppendLine("   AND CCP.SaldoCuota <> 0 ")
         End If

         If vencimiento <> "TODOS" Then
            If desde.Year > 1 Then
               ' .AppendLine("   AND Convert(varchar(11), CCP.FechaVencimiento, 120) < '" & Hasta.ToString("yyyy-MM-dd") & "'")
            Else
               'El dia de HOY no lo considero vencido.
               .AppendLine("   AND Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), getdate(), 120) ")
            End If
         End If

         If idCategoria > 0 Then
            If categoria <> "MOVIMIENTO" Then
               .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
            Else
               .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
            End If
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         If Not String.IsNullOrEmpty(grupoCategoria) Then
            .AppendLine("	AND CAT.IdGrupocategoria = '" & grupoCategoria & "'")
         End If


         If excluirSaldosNegativos = "SI" Then
            .AppendLine("   AND CC.Saldo > 0 ")
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         If excluirMinutas = "SI" Then
            .AppendLine("  AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
         End If
         .AppendLine("  ) ")
         .AppendLine(" SELECT * ")
         .AppendLine(" FROM records ")
         .AppendLine(" WHERE RN = 1 ")

         If muestraDeudaAnterior Then
            .AppendLine("UNION ALL ")

            .AppendLine("SELECT CCP.IdSucursal")
            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("      ,C.IdVendedor")
            Else
               .AppendLine("      ,CC.IdVendedor")
            End If

            .AppendLine("      ,E.NombreEmpleado as NombreVendedor")

            If agrupadoPorClienteCtaCte Then
               .AppendLine("      ,CC.IdClienteCtaCte as IdCliente")
            Else
               .AppendLine("      ,CC.IdCliente ")
            End If

            .AppendLine("      ,C.CodigoCliente")
            .AppendLine("      ,C.NombreCliente")
            '.AppendLine("      ,C.NombreCliente +  C.Direccion + ' - ' + L.NombreLocalidad + ' - ' + P.NombreProvincia + (CASE WHEN C.Cuit IS NULL THEN '' ELSE ', ' + C.Cuit END)  + ', Tel: ' + C.Telefono + ' ' + C.Celular + (CASE WHEN C.CorreoElectronico = '' THEN '' ELSE ', ' + C.CorreoElectronico END)  + (CASE WHEN T.NombreTransportista IS NULL THEN '' ELSE ', ' + T.NombreTransportista  END) AS NombreCliente2")
            .AppendLine("      ,C.NombreCliente +  ' ( ' + CONVERT(varchar(20), C.CodigoCliente)  + ' ) ' +  C.Direccion + ' - ' + L.NombreLocalidad + ' - ' + P.NombreProvincia + (CASE WHEN C.Cuit IS NULL THEN '' ELSE ' - ' + C.Cuit END) + ' - Tel: ' +(CASE WHEN C.Telefono IS NULL THEN '' ELSE ' - ' + C.Telefono END)  + ' ' + (CASE WHEN C.Celular IS NULL THEN '' ELSE ' - ' + C.Celular END) + (CASE WHEN C.CorreoElectronico IS NULL THEN '' ELSE ' - ' + C.CorreoElectronico END)  + (CASE WHEN T.NombreTransportista IS NULL THEN '' ELSE ' - ' + T.NombreTransportista  END) AS NombreCliente2")

            If agrupadoPorClienteCtaCte Then
               .AppendLine("      ,CC.IdCliente AS IdClienteHijo")
               .AppendLine("      ,C2.CodigoCliente AS CodigoClienteHijo")
               .AppendLine("      ,C2.NombreCliente AS NombreClienteHijo")
            Else
               .AppendLine("      ,NULL AS IdClienteHijo")
               .AppendLine("      ,NULL AS CodigoClienteHijo")
               .AppendLine("      ,NULL AS NombreClienteHijo")
            End If

            .AppendLine("      ,ZG.NombreZonaGeografica")
            .AppendLine("      ,CCP.IdTipoComprobante")
            .AppendLine("      ,CCP.Letra")
            .AppendLine("      ,CCP.CentroEmisor")
            .AppendLine("      ,CCP.NumeroComprobante")
            .AppendLine("      ,CCP.CuotaNumero")
            .AppendLine("      ,CCP.Fecha")
            .AppendLine("      ,CCP.FechaVencimiento")
            .AppendLine("      ,CCP.ImporteCuota")
            .AppendLine("      ,CCP.SaldoCuota")
            .AppendLine("      ,CCP.Observacion ")
            .AppendLine("      ,I.TipoImpresora")
            .AppendLine("      ,CAT.NombreCategoria")
            '  .AppendLine("         ,(select Top 1 V.NombreProducto FROM  VentasProductos V WHERE CCP.IdSucursal = V.IdSucursal AND CCP.IdTipoComprobante = V.IdTipoComprobante AND CCP.Letra = V.Letra AND CCP.CentroEmisor = V.CentroEmisor AND CCP.NumeroComprobante = V.NumeroComprobante) AS NombreProducto")
            .AppendLine("      ,CONVERT(decimal(12,2), CCP.SaldoCuota * dbo.CtaCtePorcDescRecSaldo(CC.IdCategoria, CCP.Fecha, CCP.FechaVencimiento, GETDATE(), CCP.ImporteCuota, CCP.SaldoCuota) / 100) AS Interes")
            .AppendLine("      ,0")

            .AppendLine("    ,(SELECT NombreProducto + ' / '  FROM VentasProductos VP")
            .AppendLine("         WHERE VP.IdSucursal = CCP.IdSucursal And VP.IdTipoComprobante = CCP.IdTipoComprobante And VP.Letra = CCP.Letra")
            .AppendLine("         AND VP.CentroEmisor = CCP.CentroEmisor AND VP.NumeroComprobante = CCP.NumeroComprobante")
            .AppendLine("         FOR XML PATH('')) NombreProductos")

            .AppendLine("	FROM CuentasCorrientesPagos CCP ")
            .AppendLine("  INNER JOIN CuentasCorrientes CC ON CCP.IdSucursal = CC.IdSucursal ")
            .AppendLine("  AND CCP.IdTipoComprobante = CC.IdTipoComprobante ")
            .AppendLine("  AND CCP.Letra = CC.Letra ")
            .AppendLine("  AND CCP.CentroEmisor = CC.CentroEmisor ")
            .AppendLine("  AND CCP.NumeroComprobante = CC.NumeroComprobante ")
            If agrupadoPorClienteCtaCte Then
               .AppendLine("  INNER JOIN Clientes C ON CC.IdClienteCtaCte = C.IdCliente ")
               .AppendLine("  INNER JOIN Clientes C2 ON CC.IdCliente = C2.IdCliente ")
            Else
               .AppendLine("  INNER JOIN Clientes C ON CC.IdCliente = C.IdCliente ")
            End If
            .AppendLine("  INNER JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica ")

            If vendedor <> "MOVIMIENTO" Then
               .AppendLine("  INNER JOIN Empleados E ON C.IdVendedor = E.IdEmpleado ")
            Else
               .AppendLine("  INNER JOIN Empleados E ON CC.IdVendedor = E.IdEmpleado ")
            End If

            .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
            .AppendLine("  LEFT OUTER JOIN Impresoras I ON CC.CentroEmisor = I.CentroEmisor AND I.IdSucursal =  CCP.IdSucursal") ' & Sucursal.ToString())

            If categoria <> "MOVIMIENTO" Then
               .AppendLine("  INNER JOIN Categorias CAT ON C.IdCategoria = CAT.IdCategoria")
            Else
               .AppendLine("  INNER JOIN Categorias CAT ON CC.IdCategoria = CAT.IdCategoria")
            End If

            .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad")
            .AppendLine("  INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
            .AppendLine(" LEFT OUTER JOIN Transportistas T ON T.IdTransportista = C.IdTransportista")
            '.AppendLine(" LEFT JOIN Ventas V ON V.IdSucursal = CCP.IdSucursal")
            '.AppendLine(" AND V.IdTipoComprobante = CCP.IdTipoComprobante")
            '.AppendLine(" AND V.Letra = CCP.Letra")
            '.AppendLine(" AND V.CentroEmisor = CCP.CentroEmisor")
            '.AppendLine(" AND V.NumeroComprobante = CCP.NumeroComprobante ")

            ''.AppendLine("  WHERE CCP.IdSucursal = " & sucursal.ToString())
            .AppendLine("  WHERE 1 = 1")
            SqlServer.Comunes.GetListaSucursalesMultiples(stb, sucursales, "CCP")

            If desde.Year > 1 Then
               .AppendLine("	 AND CONVERT(varchar(11), CCP.FechaVencimiento, 120) < '" & desde.ToString("yyyy-MM-dd") & "'")
               '.AppendLine("	 AND CONVERT(varchar(11), CCP.FechaVencimiento, 120) <= '" & Hasta.ToString("yyyy-MM-dd") & "'")
            End If

            If IdVendedor > 0 Then
               If vendedor <> "MOVIMIENTO" Then
                  .AppendLine("	AND C.IdVendedor = " & IdVendedor)
               Else
                  .AppendLine("	AND CC.IdVendedor = " & IdVendedor)
               End If
            End If

            If idCliente > 0 Then
               If agrupadoPorClienteCtaCte Then
                  .AppendLine("	AND CC.IdClienteCtaCte = " & idCliente.ToString())
               Else
                  .AppendLine("	AND C.IdCliente = " & idCliente.ToString())
               End If
            End If

            If Not String.IsNullOrEmpty(idZonaGeografica) Then
               .AppendFormat(" AND ZG.IdZonaGeografica = '{0}'", idZonaGeografica)
            End If

            If Not String.IsNullOrEmpty(idTipoComprobante) Then
               .AppendLine("	AND CCP.IdTipoComprobante = '" & idTipoComprobante & "'")
            End If

            If saldo <> "TODOS" Then
               .AppendLine("   AND CCP.SaldoCuota <> 0 ")
            End If

            If vencimiento <> "TODOS" Then
               If desde.Year > 1 Then
                  ' .AppendLine("   AND Convert(varchar(11), CCP.FechaVencimiento, 120) < '" & Hasta.ToString("yyyy-MM-dd") & "'")
               Else
                  'El dia de HOY no lo considero vencido.
                  .AppendLine("   AND Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), getdate(), 120) ")
               End If
            End If

            If idCategoria > 0 Then
               If categoria <> "MOVIMIENTO" Then
                  .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
               Else
                  .AppendLine("   AND CC.IdCategoria = " & idCategoria.ToString())
               End If
            End If

            If grabaLibro <> "TODOS" Then
               .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
            End If

            If Not String.IsNullOrEmpty(grupo) Then
               .AppendLine("	AND TC.Grupo = '" & grupo & "'")
            End If

            If Not String.IsNullOrEmpty(grupoCategoria) Then
               .AppendLine("	AND CAT.IdGrupocategoria = '" & grupoCategoria & "'")
            End If

            If excluirSaldosNegativos = "SI" Then
               .AppendLine("   AND CC.Saldo > 0 ")
            End If

            If excluirAnticipos = "SI" Then
               .AppendLine("      AND TC.EsAnticipo = 'False'")
            End If

            If excluirPreComprobantes = "SI" Then
               '.AppendLine("       AND NOT (TC.EsElectronico = 'True' AND TC.EsComercial = 'False')")
               .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
            End If

            If Not String.IsNullOrEmpty(idProvincia) Then
               .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
            End If

            If excluirMinutas = "SI" Then
               .AppendLine("  AND NOT (TC.EsRecibo = 'True' AND TC.ImporteTope = 0)")
            End If

            '.AppendLine(" ORDER BY E.NombreEmpleado ")
            'If Vendedor <> "MOVIMIENTO" Then
            '   .AppendLine("   ,C.TipoDocVendedor ")
            '   .AppendLine("   ,RIGHT(REPLICATE(' ',12) + C.NroDocVendedor,12) ")
            'Else
            '   .AppendLine("   ,CC.TipoDocVendedor ")
            '   .AppendLine("   ,RIGHT(REPLICATE(' ',12) + CC.NroDocVendedor,12) ")
            'End If
            '.AppendLine("   ,C.NombreCliente ")
            '.AppendLine("   ,C.CodigoCliente ")
            '.AppendLine("   ,CCP.FechaVencimiento")

            'GAR: 12/05/2017 --- Hacerlo mejor!!



         End If
         .AppendLine(" ORDER BY 4 ")
         'If Vendedor <> "MOVIMIENTO" Then
         '   .AppendLine("   ,C.TipoDocVendedor ")
         '   .AppendLine("   ,RIGHT(REPLICATE(' ',12) + C.NroDocVendedor,12) ")
         'Else
         '   .AppendLine("   ,CC.TipoDocVendedor ")
         '   .AppendLine("   ,RIGHT(REPLICATE(' ',12) + CC.NroDocVendedor,12) ")
         'End If
         .AppendLine("   ,7 ")
         .AppendLine("   ,6 ")
         .AppendLine("   ,16")
      End With

      Return GetDataTable(stb.ToString())
   End Function


   Public Function GetKardexComprobante(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        emisor As Integer,
                                        numero As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT '...' Ver")
         .AppendLine("     , CC.IdSucursal")
         .AppendLine("	   , CC.IdTipoComprobante")
         .AppendLine("	   , CC.Letra")
         .AppendLine("	   , CC.CentroEmisor")
         .AppendLine("	   , CC.NumeroComprobante")
         .AppendLine("	   , CC.CuotaNumero")
         .AppendLine("	   , CC.Fecha")
         .AppendLine("	   , CC.FechaVencimiento")
         .AppendLine("	   , CC.ImporteCuota")
         .AppendLine("	   , CC.Observacion")
         .AppendLine("  FROM CuentasCorrientesPagos CC")

         .AppendFormatLine(" WHERE 1 = 1")

         .AppendFormatLine("	 AND ((CC.IdSucursal = {0} AND CC.IdTipoComprobante  = '{1}' AND CC.Letra  = '{2}' AND CC.CentroEmisor  = {3} AND CC.NumeroComprobante  = {4}) OR",
                           idSucursal, idTipoComprobante, letra, emisor, numero)
         .AppendFormatLine("	      (CC.IdSucursal = {0} AND CC.IdTipoComprobante2 = '{1}' AND CC.Letra2 = '{2}' AND CC.CentroEmisor2 = {3} AND CC.NumeroComprobante2 = {4}))",
                           idSucursal, idTipoComprobante, letra, emisor, numero)

         .AppendFormatLine(" ORDER BY CC.Fecha")
         .AppendFormatLine("         ,CC.IdTipoComprobante")
         .AppendFormatLine("         ,CC.Letra")
         .AppendFormatLine("         ,CC.CentroEmisor")
         .AppendFormatLine("         ,CC.NumeroComprobante")
         .AppendFormatLine("         ,CC.CuotaNumero")

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPagos(idSucursal As Integer, periodo As Integer, tipo As Entidades.Liquidacion.TipoLiquidacion?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN LiquidacionesCargos C ON (C.IdSucursal = CCP.IdSucursal")
         .AppendFormatLine("                     AND C.IdTipoComprobante = CCP.IdTipoComprobante2")
         .AppendFormatLine("                     AND C.Letra = CCP.Letra2")
         .AppendFormatLine("                     AND C.CentroEmisor = CCP.CentroEmisor2")
         .AppendFormatLine("                     AND C.NumeroComprobante = CCP.NumeroComprobante2)")
         ''.AppendFormatLine(" WHERE (CCP.IdTipoComprobante = 'RECIBO' OR CCP.IdTipoComprobante = 'RECIBOPROV' OR CCP.IdTipoComprobante = 'RECIBOCYO')")
         .AppendFormatLine(" WHERE TP.EsRecibo = 'True' AND TP.ImporteTope <> 0")
         .AppendFormatLine("   AND C.PeriodoLiquidacion = {0}", periodo)
         .AppendFormatLine("   AND C.IdSucursal = {0}", idSucursal)
      End With

      Return GetDataTable(myQuery.ToString())
   End Function


   Public Sub ActualizarPagosComprobantes(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                          idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Short, numeroComprobanteNuevo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CCP")
         .AppendFormatLine("   SET CCP.IdSucursal = {0}", idSucursalNuevo)
         .AppendFormatLine("     , CCP.IdTipoComprobante2 = '{0}'", idTipoComprobanteNuevo)
         .AppendFormatLine("     , CCP.Letra2 = '{0}'", letraNuevo)
         .AppendFormatLine("     , CCP.CentroEmisor2 = {0}", centroEmisorNuevo)
         .AppendFormatLine("     , CCP.NumeroComprobante2 = {0}", numeroComprobanteNuevo)

         .AppendFormatLine("  FROM CuentasCorrientesPagos CCP")
         .AppendFormatLine(" INNER Join TiposComprobantes TCr ON TCr.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine(" INNER Join TiposComprobantes TCp ON TCp.IdTipoComprobante = CCP.IdTipoComprobante2")
         .AppendFormatLine(" WHERE TCr.EsRecibo = 'True'")
         .AppendFormatLine("   AND TCp.EsPreElectronico = 'True'")

         .AppendFormatLine("   AND CCP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND CCP.IdTipoComprobante2 = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCP.Letra2 = '{0}'", letra)
         .AppendFormatLine("   AND CCP.CentroEmisor2 = {0}", centroEmisor)
         .AppendFormatLine("   AND CCP.NumeroComprobante2 = {0}", numeroComprobante)

      End With

      Me.Execute(myQuery.ToString())

   End Sub


   '-.PE-31570.-
   Public Sub ActualizoVendedorClienteCtaCtePagos(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Integer,
                                             numeroComprobante As Long,
                                             Observacion As String)
      Dim stb = New StringBuilder()
      With stb
         .Append("UPDATE CuentasCorrientesPagos")

         .AppendFormat("     SET Observacion = '{0}'", Observacion) 'PE-31570

         .AppendFormat("	WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("	AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	AND Letra = '{0}'", letra)
         .AppendFormat("	AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "CuentasCorrientesPagos")
   End Sub

   Public Sub ActualizaCodigoDeBarraSirplus(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                            cuotaNumero As Integer,
                                            codigoDeBarraSirplus As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE CuentasCorrientesPagos")
         .AppendFormatLine("   SET CodigoDeBarraSirplus = '{0}'", codigoDeBarraSirplus) 'PE-31570
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND CuotaNumero = {0}", cuotaNumero)
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "CuentasCorrientesPagos")
   End Sub

End Class