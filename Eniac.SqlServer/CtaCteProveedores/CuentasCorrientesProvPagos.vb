Public Class CuentasCorrientesProvPagos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesProvPagos_I(idSucursal As Integer,
                              idTipoComprobante As String,
                              letra As String,
                              centroEmisor As Short,
                              numeroComprobante As Long,
                              cuotaNumero As Integer,
                              IdProveedor As Long,
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
                              DescuentoRecargoPorc As Decimal,
                              DescuentoRecargo As Decimal)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("INSERT INTO CuentasCorrientesProvPagos")
         .Append("           (IdSucursal")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,CuotaNumero")
         .Append("           ,IdProveedor")
         .Append("           ,Fecha")
         .Append("           ,FechaVencimiento")
         .Append("           ,ImporteCuota")
         .Append("           ,SaldoCuota")
         .Append("           ,IdFormasPago")
         .Append("           ,Observacion")
         .Append("           ,IdTipoComprobante2")
         .Append("           ,NumeroComprobante2")
         .Append("           ,CentroEmisor2")
         .Append("           ,CuotaNumero2")
         .Append("           ,Letra2")
         .Append("           ,DescuentoRecargoPorc")
         .Append("           ,DescuentoRecargo")
         .Append(")     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,{0}", centroEmisor)
         .AppendFormat("           ,{0}", numeroComprobante)
         .AppendFormat("           ,{0}", cuotaNumero)
         .AppendFormat("           ,{0}", IdProveedor)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fecha, True))
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaVencimiento, True))
         .AppendFormat("           ,{0}", importeCuota.ToString())
         .AppendFormat("           ,{0}", saldoCuota.ToString())
         .AppendFormat("           ,{0}", idFormasPago)
         .AppendFormat("           ,'{0}'", observacion)
         If String.IsNullOrEmpty(idTipoComprobante2) Then
            .Append("           ,null")
         Else
            .AppendFormat("           ,'{0}'", idTipoComprobante2)
         End If
         If numeroComprobante2 = 0 Then
            .Append("           ,null")
         Else
            .AppendFormat("           ,{0}", numeroComprobante2)
         End If
         If centroEmisor2 = 0 Then
            .Append("           ,null")
         Else
            .AppendFormat("           ,{0}", centroEmisor2)
         End If
         If cuotaNumero2 = 0 Then
            .Append("           ,null")
         Else
            .AppendFormat("           ,{0}", cuotaNumero2)
         End If
         If String.IsNullOrEmpty(idTipoComprobante2) Then
            .Append("           ,null")
         Else
            .AppendFormat("           ,'{0}'", letra2)
         End If
         .AppendFormat("           ,{0}", DescuentoRecargoPorc)
         .AppendFormat("           ,{0}", DescuentoRecargo)
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProvPagos")

   End Sub

   Public Sub CuentasCorrientesProvPagos_USaldo(idSucursal As Integer,
                                                 IdProveedor As Long,
                                                 idTipoComprobante As String,
                                                 letra As String,
                                                 centroEmisor As Integer,
                                                 numeroComprobante As Long,
                                                 cuotaNumero As Integer,
                                                 saldoNuevo As Double)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("UPDATE CuentasCorrientesProvPagos")
         .Append("   SET")
         .AppendFormat("			SaldoCuota = SaldoCuota + {0}", saldoNuevo)
         .AppendFormat(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormat("	and IdProveedor = {0}", IdProveedor)
         .AppendFormat("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	and Letra = '{0}'", letra)
         .AppendFormat("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	and NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat("	and CuotaNumero = {0}", cuotaNumero)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProvPagos")

   End Sub

   Public Sub CuentasCorrientesProvPagos_UComprobante(idSucursal As Integer,
                                                       IdProveedor As Long,
                                                       idTipoComprobante As String,
                                                       letra As String,
                                                       centroEmisor As Integer,
                                                       numeroComprobante As Long,
                                                       cuotaNumero As Integer,
                                                       idTipoComprobante2 As String,
                                                       numeroComprobante2 As Long,
                                                       centroEmisor2 As Integer,
                                                       cuotaNumero2 As Integer,
                                                       letra2 As String)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("UPDATE CuentasCorrientesProvPagos")
         .Append("   SET")
         .AppendFormat("			IdTipoComprobante2 = '{0}'", idTipoComprobante2)
         .AppendFormat("		,	NumeroComprobante2 = {0}", numeroComprobante2)
         .AppendFormat("		,	CentroEmisor2 = {0}", centroEmisor2)
         .AppendFormat("		,	CuotaNumero2 = {0}", cuotaNumero2)
         .AppendFormat("		,	Letra2 = '{0}'", letra2)
         .AppendFormat(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormat("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	and IdProveedor = {0}", IdProveedor)
         .AppendFormat("	and Letra = '{0}'", letra)
         .AppendFormat("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	and NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat("	and CuotaNumero = {0}", cuotaNumero)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProvPagos")

   End Sub

   Public Sub CuentasCorrientesProvPagos_UFecha(idSucursal As Integer,
                                                idProveedor As Long,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroComprobante As Long,
                                                ajusteDias As Integer,
                                                observacion As String)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("UPDATE CuentasCorrientesProvPagos")
         .AppendFormat(" SET Fecha = Fecha + {0}", ajusteDias)
         .AppendFormat("    ,FechaVencimiento = FechaVencimiento + {0}", ajusteDias)
         .AppendFormat("    ,Observacion = '{0}'", observacion)
         .AppendFormat(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormat("	and IdProveedor = {0}", idProveedor)
         .AppendFormat("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	and Letra = '{0}'", letra)
         .AppendFormat("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProvPagos")

   End Sub

   Public Sub CuentasCorrientesProvPagos_D(idSucursal As Integer,
                                            IdProveedor As Long,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Int32,
                                            numeroComprobante As Long)

      Dim myQuery = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("DELETE CuentasCorrientesProvPagos")
         .AppendFormat(" WHERE idSucursal = {0}", idSucursal)
         .AppendFormat("	and IdProveedor = {0}", IdProveedor)
         .AppendFormat("	and idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("	and Letra = '{0}'", letra)
         .AppendFormat("	and CentroEmisor = {0}", centroEmisor)
         .AppendFormat("	and NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CuentasCorrientesProvPagos")

   End Sub

   Public Function GetPorCuentaCorriente(idSucursal As Integer, IdProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM CuentasCorrientesProvPagos CCP")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdProveedor = {0}", IdProveedor)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}   ", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetImporteCuota(idSucursal As Integer,
                                    IdProveedor As Long,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Integer,
                                    numeroComprobante As Long,
                                    cuotaNumero As Integer) As Decimal

      Dim stb = New StringBuilder()

      With stb
         .Append("SELECT ImporteCuota")
         .Append(" FROM CuentasCorrientesProvPagos CCP")
         .AppendFormat(" WHERE IdSucursal = {0}   ", idSucursal)
         .AppendFormat(" AND IdProveedor = {0}", IdProveedor)
         .AppendFormat(" AND IdTipoComprobante = '{0}'   ", idTipoComprobante)
         .AppendFormat(" AND Letra = '{0}'   ", letra)
         .AppendFormat(" AND CentroEmisor = {0}   ", centroEmisor)
         .AppendFormat(" AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat(" AND CuotaNumero = {0}", cuotaNumero)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("ImporteCuota").ToString()) Then
            Return Decimal.Parse(dt.Rows(0)("ImporteCuota").ToString())
         End If
      End If

      Return 0

   End Function

   Public Function GetSaldoCuota(idSucursal As Integer,
                                 idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                 cuotaNumero As Integer,
                                 fechaSaldo As Date) As Decimal
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT SUM(ImporteCuota) SaldoCuota")
         .AppendFormatLine("  FROM CuentasCorrientesProvPagos CCP")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdProveedor = {0}", idProveedor)
         .AppendFormatLine("   AND IdTipoComprobante2 = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra2 = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor2 = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante2 = {0}", numeroComprobante)
         .AppendFormatLine("   AND CuotaNumero2 = {0}", cuotaNumero)

         .AppendFormatLine("   AND Fecha <= '{0}'", ObtenerFecha(fechaSaldo, True))
      End With

      Using dt = GetDataTable(stb)
         Return If(dt.Any(), dt.First().Field(Of Decimal?)("SaldoCuota").IfNull(), 0D)
      End Using
   End Function

   Public Function GetFecha(idSucursal As Integer,
                             IdProveedor As Long,
                             idTipoComprobante As String,
                             letra As String,
                             centroEmisor As Integer,
                             numeroComprobante As Long,
                             cuotaNumero As Integer) As Date

      Dim stb = New StringBuilder()

      With stb
         .Append("SELECT Fecha")
         .Append(" FROM CuentasCorrientesProvPagos CCP")
         .AppendFormat(" WHERE IdSucursal = {0}   ", idSucursal)
         .AppendFormat(" AND IdProveedor = {0}", IdProveedor)
         .AppendFormat(" AND IdTipoComprobante = '{0}'   ", idTipoComprobante)
         .AppendFormat(" AND Letra = '{0}'   ", letra)
         .AppendFormat(" AND CentroEmisor = {0}   ", centroEmisor)
         .AppendFormat(" AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat(" AND CuotaNumero = {0}", cuotaNumero)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      'If dt.Rows.Count > 0 Then
      '   If Not String.IsNullOrEmpty(dt.Rows(0)("Fecha").ToString()) Then
      Return Date.Parse(dt.Rows(0)("Fecha").ToString())
      '   End If
      'End If

      'Return Date.Now

   End Function

   Public Function GetFechaVencimiento(idSucursal As Integer,
                                           IdProveedor As Long,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Integer,
                                           numeroComprobante As Long,
                                           cuotaNumero As Integer) As Date

      Dim stb = New StringBuilder()

      With stb
         .Append("SELECT FechaVencimiento")
         .Append(" FROM CuentasCorrientesProvPagos CCP")
         .AppendFormat(" WHERE IdSucursal = {0}   ", idSucursal)
         .AppendFormat(" AND IdProveedor = {0}", IdProveedor)
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

   Public Function GetSaldoProveedores(Desde As Date,
                               Hasta As Date) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT S.Nombre, ")
         .AppendLine("SUM(SaldoCuota) Saldo ")
         .AppendLine("FROM CuentasCorrientesProvPagos CC ")
         .AppendLine("INNER JOIN Sucursales S on CC.IdSucursal = S.IdSucursal ")
         If Desde <> Nothing Then
            .AppendFormat("	 AND CC.FechaVencimiento >= '{0} 00:00:00'", Desde.ToString("yyyyMMdd"))
            .AppendFormat("	 AND CC.FechaVencimiento <= '{0} 23:59:59'", Hasta.ToString("yyyyMMdd"))
         End If
         .AppendLine("GROUP BY S.Nombre ")
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetSaldosCtaCte(idSucursal As Integer,
                                   fechaHasta As Date,
                                   idProveedor As Long,
                                   tipoSaldo As String,
                                   idCategoria As Integer,
                                   grabaLibro As String,
                                   nivelAutorizacion As Short,
                                   idRubroCompra As Integer) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT CC.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,P.TelefonoProveedor")
         .AppendLine("      ,P.CuitProveedor as CUIT")
         .AppendLine("      ,P.IdRubroCompra")
         .AppendLine("      ,RC.NombreRubro")
         .AppendLine("      ,SUM(CCP.ImporteCuota) AS Total")
         .AppendLine("      ,SUM(CCP.SaldoCuota) AS Saldo")

         If fechaHasta.Year > 1 Then
            .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < '" & fechaHasta.ToString("yyyy-MM-dd") & "' THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")
         Else
            .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCP.FechaVencimiento, 120) < Convert(varchar(11), GETDATE(), 120) THEN CCP.SaldoCuota ELSE 0 END) AS SaldoVencido")
         End If

         .AppendLine("  FROM CuentasCorrientesProvPagos CCP")
         .AppendLine("  INNER JOIN CuentasCorrientesProv CC ON CC.IdSucursal = CCP.IdSucursal")
         .AppendLine("                                 AND CC.IdProveedor = CCP.IdProveedor")
         .AppendLine("                                 AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("                                 AND CC.Letra = CCP.Letra")
         .AppendLine("                                 AND CC.CentroEmisor = CCP.CentroEmisor")
         .AppendLine("                                 AND CC.NumeroComprobante = CCP.NumeroComprobante")
         .AppendLine("  INNER JOIN Proveedores P ON CC.IdProveedor = P.IdProveedor ")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CC.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN RubrosCompras RC ON P.IdRubroCompra = RC.IdRubro")

         If idSucursal >= 0 Then
            .AppendLine(" WHERE CCP.IdSucursal = " & idSucursal.ToString())
         Else
            .AppendLine(" WHERE 1 = 1")
         End If

         NivelAutorizacionProveedorTipoComprobante(stb, "P", "TC", nivelAutorizacion)

         If fechaHasta.Year > 1 Then
            .AppendLine("    AND CONVERT(varchar(11), CCP.Fecha, 120) <= '" & fechaHasta.ToString("yyyy-MM-dd") & "'")
         End If

         If idProveedor > 0 Then
            .AppendLine("  AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND P.IdCategoria = " & idCategoria.ToString())
         End If

         If idRubroCompra > 0 Then
            .AppendFormatLine("   AND P.IdRubroCompra = {0}", idRubroCompra)
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         .AppendLine("   GROUP BY CC.IdProveedor, P.CodigoProveedor, P.NombreProveedor, P.CuitProveedor, P.TelefonoProveedor, P.IdRubroCompra, RC.NombreRubro")

         Dim CampoASumar As String = IIf(fechaHasta.Year > 1, "CCP.ImporteCuota", "CCP.SaldoCuota").ToString()

         If tipoSaldo = "POSITIVOS" Then
            .AppendLine("    HAVING SUM(" & CampoASumar & ") > 0 ")
         Else
            .AppendLine("    HAVING SUM(" & CampoASumar & ") <> 0 ")
         End If

         .AppendLine("   ORDER BY P.NombreProveedor, P.CuitProveedor, CC.IdProveedor")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetPagos(idProveedor As Long,
                            fechaDesde As Date,
                            fechaHasta As Date) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT * FROM")
         .AppendFormatLine(" (SELECT CCP.*")
         .AppendFormatLine("    FROM CuentasCorrientesProvPagos CCP")
         .AppendFormatLine("   INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CCP.IdTipoComprobante2")
         .AppendFormatLine("   INNER JOIN TiposComprobantes TC1 ON TC1.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendFormatLine("   WHERE TC.GrabaLibro = 'True'")
         .AppendFormatLine("     AND CCP.IdProveedor = {0}", idProveedor)

         .AppendFormatLine("     AND (TC1.EsRecibo = 'True' OR TC1.EsAnticipo = 'True')")
         '.AppendFormatLine("     AND CCP.IdTipoComprobante IN ('{0}')", Entidades.TipoComprobante.Tipos.PAGO.ToString()) 'los anticipos no los voy a cargar por ahora

         .AppendFormatLine("   AND CCP.Fecha BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"))
         .AppendFormatLine("  ) as CC")
         .AppendFormatLine("	LEFT JOIN Compras C ON CC.IdSucursal = C.IdSucursal")
         .AppendFormatLine("		  AND CC.IdTipoComprobante2 = C.IdTipoComprobante")
         .AppendFormatLine("		  AND CC.Letra2 = C.Letra")
         .AppendFormatLine("		  AND CC.CentroEmisor2 = C.CentroEmisor")
         .AppendFormatLine("		  AND CC.NumeroComprobante2 = C.NumeroComprobante")
         .AppendFormatLine("		  AND CC.IdProveedor = C.IdProveedor")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetControlInconsistenciasCtaCtevsCtaCtePagos(idSucursal As Integer) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT P.CodigoProveedor, P.NombreProveedor, CC.IdTipoComprobante, ")
         .AppendLine(" CC.Letra, CC.CentroEmisor, CC.NumeroComprobante, CC.Fecha, ")
         .AppendLine(" CC.Saldo, CCP.SaldoCuota")
         .AppendLine(" FROM CuentasCorrientesProv CC, Proveedores P, TiposComprobantes TC, ")
         .AppendLine("   (SELECT IdSucursal, IdProveedor, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante")
         .AppendLine("          ,SUM(SaldoCuota) AS SaldoCuota")
         .AppendLine("     FROM CuentasCorrientesProvPagos ")
         .AppendLine("    GROUP BY IdSucursal, IdProveedor, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante")
         .AppendLine("   ) CCP ")
         .AppendLine(" WHERE CC.IdSucursal = CCP.IdSucursal")
         .AppendLine("   AND CC.IdProveedor = CCP.IdProveedor")
         .AppendLine("   AND CC.IdTipoComprobante = CCP.IdTipoComprobante")
         .AppendLine("   AND CC.Letra = CCP.Letra ")
         .AppendLine("   AND CC.CentroEmisor = CCP.CentroEmisor ")
         .AppendLine("   AND CC.NumeroComprobante = CCP.NumeroComprobante ")
         .AppendLine("   AND CC.IdProveedor = P.IdProveedor ")
         .AppendLine("   AND CC.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendLine("   AND CC.Saldo <> CCP.SaldoCuota ")
         .AppendLine("   AND CC.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND TC.EsRecibo = 'False' ")
         ' .AppendLine(" --   AND ROUND(CC.ImporteTotal,1) <> ROUND(CCP.ImporteCuota,1) ")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetDetalle(sucursales() As Eniac.Entidades.Sucursal,
                              desde As Date,
                              hasta As Date,
                              idProveedor As Long,
                              idTipoComprobante As String,
                              saldo As String,
                              vencimiento As String,
                              idCategoria As Integer,
                              grabaLibro As String,
                              nivelAutorizacion As Short) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.IdSucursal, ")
         .AppendLine("	CCP.IdProveedor, ")
         .AppendLine("	P.CodigoProveedor, ")
         .AppendLine("	P.NombreProveedor, ")
         .AppendLine("  P.CuitProveedor,")
         .AppendLine("	CCP.IdTipoComprobante, ")
         .AppendLine("	CCP.Letra, ")
         .AppendLine("	CCP.CentroEmisor, ")
         .AppendLine("	CCP.NumeroComprobante, ")
         .AppendLine("	CCP.CuotaNumero, ")
         .AppendLine("	CCP.Fecha, ")
         .AppendLine("	CCP.FechaVencimiento, ")
         .AppendLine("	CCP.ImporteCuota, ")
         .AppendLine("	CCP.SaldoCuota, ")
         .AppendLine("	CCP.Observacion ")
         .AppendLine("	FROM CuentasCorrientesProvPagos CCP, CuentasCorrientesProv CC, Proveedores P, TiposComprobantes TC")
         .AppendLine("  WHERE CCP.IdSucursal = CC.IdSucursal")
         .AppendLine("    AND CCP.IdProveedor = CC.IdProveedor")
         .AppendLine("    AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine("    AND CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("    AND CCP.Letra = CC.Letra")
         .AppendLine("    AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendLine("    AND CCP.NumeroComprobante = CC.NumeroComprobante")
         .AppendLine("    AND CCP.IdProveedor = P.IdProveedor")

         '.AppendLine("    AND CCP.IdSucursal = " & sucursal.ToString())
         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         If idProveedor > 0 Then
            .AppendLine("    AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         NivelAutorizacionProveedorTipoComprobante(stb, "P", "TC", nivelAutorizacion)

         If desde.Year > 1 Then
            .AppendLine("	 AND CONVERT(varchar(11), CCP.FechaVencimiento, 120) >= '" & desde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), CCP.FechaVencimiento, 120) <= '" & hasta.ToString("yyyy-MM-dd") & "'")
         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND CCP.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If saldo <> "TODOS" Then
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

         If idCategoria > 0 Then
            .AppendLine("   AND P.IdCategoria = " & idCategoria.ToString())
         End If

         .AppendLine("  ORDER BY P.NombreProveedor ")
         .AppendLine("  ,P.CodigoProveedor ")
         '.AppendLine("  ,CCP.FechaVencimiento")
         .AppendLine("	,CCP.IdTipoComprobante2")
         .AppendLine("	,CCP.Letra2")
         .AppendLine("	,CCP.CentroEmisor2")
         .AppendLine("	,CCP.NumeroComprobante2")
         .AppendLine("	,CCP.CuotaNumero2")
         .AppendLine("	,CCP.IdTipoComprobante")
         .AppendLine("	,CCP.Letra")
         .AppendLine("	,CCP.CentroEmisor")
         .AppendLine("	,CCP.NumeroComprobante")
         .AppendLine("	,CCP.CuotaNumero")
      End With

      Return GetDataTable(stb.ToString())

   End Function

   Function GetPorProveedor(sucursales As Entidades.Sucursal(), proveedor As Entidades.Proveedor,
                            fechaUtilizada As String, desde As Date?, hasta As Date?,
                            grabaLibro As Entidades.Publicos.SiNoTodos, nivelAutorizacionMaximo As Short) As DataTable
      Dim campoFecha = If(fechaUtilizada = "EMISION", "CCP.Fecha", "CCP.FechaVencimiento")
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CCP.IdSucursal")
         .AppendFormatLine("     , CCP.IdTipoComprobante")
         .AppendFormatLine("     , CCP.Letra")
         .AppendFormatLine("     , CCP.CentroEmisor")
         .AppendFormatLine("     , CCP.NumeroComprobante")
         .AppendFormatLine("     , CCP.CuotaNumero")
         .AppendFormatLine("     , CCP.Fecha")
         .AppendFormatLine("     , CCP.FechaVencimiento")
         .AppendFormatLine("     , CCP.ImporteCuota")
         .AppendFormatLine("     , CCP.SaldoCuota")
         .AppendFormatLine("     , CCP.Observacion")

         .AppendFormatLine("  FROM CuentasCorrientesProvPagos CCP")
         .AppendFormatLine(" INNER JOIN CuentasCorrientesProv CC")
         .AppendFormatLine("         ON CCP.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("        AND CCP.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("        AND CCP.Letra = CC.Letra")
         .AppendFormatLine("        AND CCP.CentroEmisor = CC.CentroEmisor")
         .AppendFormatLine("        AND CCP.NumeroComprobante = CC.NumeroComprobante")
         .AppendFormatLine("        AND CCP.IdProveedor = CC.IdProveedor")
         .AppendFormatLine(" INNER JOIN Proveedores P ON CC.IdProveedor = P.IdProveedor")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")

         .AppendFormatLine("  WHERE P.NivelAutorizacion <= {0} AND TC.NivelAutorizacion <= {0}", nivelAutorizacionMaximo)

         GetListaSucursalesMultiples(stb, sucursales, "CCP")

         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND TC.GrabaLibro = {0}", GetStringFromBoolean(grabaLibro = Entidades.Publicos.SiNoTodos.SI))
         End If

         If desde.HasValue Then
            .AppendFormatLine("   AND {1} >= '{0}'", ObtenerFecha(desde.Value, False), campoFecha)
         End If
         If hasta.HasValue Then
            .AppendFormatLine("   AND {1} <= '{0}'", ObtenerFecha(hasta.Value.UltimoSegundoDelDia, True), campoFecha)
         End If
         .AppendFormatLine("	AND CC.IdProveedor = {0}", proveedor.IdProveedor)

         .AppendFormatLine(" ORDER BY {0}", campoFecha)
         .AppendFormatLine("        , CCP.IdTipoComprobante")
         .AppendFormatLine("        , CCP.Letra")
         .AppendFormatLine("        , CCP.CentroEmisor")
         .AppendFormatLine("        , CCP.NumeroComprobante")
         .AppendFormatLine("        , CCP.CuotaNumero")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetSaldosPorVencimientos(sucursales As Entidades.Sucursal(),
                                         fechaCalculo As Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme,
                                         idProveedor As Long,
                                         excluirSaldosNegativos As String,
                                         idCategoria As Integer,
                                         grabaLibro As String,
                                         grupo As String,
                                         excluirAnticipos As String,
                                         excluirPreComprobantes As String,
                                         rangosDias As Entidades.CuentaCorrienteAntiguedadSaldoConfig,
                                         idProvincia As String,
                                         nivelAutorizacion As Short) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT ")
         .AppendLine("       P.IdProveedor")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("   	 ,P.NombreDeFantasia")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,P.CuitProveedor")
         .AppendLine("      ,SUM(CCPP.ImporteCuota) AS Total")
         .AppendLine("      ,SUM(CCPP.SaldoCuota) AS Saldo")


         For Each r In rangosDias.Rangos
            .AppendFormatLine("             , SUM(CASE WHEN DATEDIFF(DAY, CONVERT(DATE, CCP.{0}), CONVERT(DATE, GETDATE())) BETWEEN {1} AND {2} THEN CCPP.SaldoCuota ELSE 0 END) AS [{3}]",
                              fechaCalculo.ToString(), r.DiasDesde, r.DiasHasta, r.EtiquetaColumna)
         Next


         'If fechaHasta = "EMISION" Then
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) < DATEADD(day, -120, CAST(GETDATE() AS DATE) ) THEN CCPP.SaldoCuota ELSE 0 END) AS MOROSO ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) < DATEADD(day, -90,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.Fecha, 120) >= DATEADD(day, -120, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS ME120 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) <  DATEADD(day, -60, CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.Fecha, 120) >= DATEADD(day, -90, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS ME90 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) < DATEADD(day, -30,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.Fecha, 120) >= DATEADD(day, -60, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS ME60 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) < Convert(varchar(11), CAST(GETDATE() AS DATE), 120) AND  Convert(varchar(11), CCPP.Fecha, 120) >= DATEADD(day, -30,CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS ME30 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) = CAST(GETDATE() AS DATE) THEN CCPP.SaldoCuota ELSE 0 END) AS ALDIA ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) > CAST(GETDATE() AS DATE) AND  Convert(varchar(11), CCPP.Fecha, 120) <= DATEADD(day, 30, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS MA30 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) > DATEADD(day, 30, CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.Fecha, 120) <= DATEADD(day, 60, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS MA60 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) > DATEADD(day, 60,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.Fecha, 120) <= DATEADD(day, 90,CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS MA90 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.Fecha, 120) > DATEADD(day, 90,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.Fecha, 120) <= DATEADD(day, 120, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS MA120 ")
         'Else
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) < DATEADD(day, -120, CAST(GETDATE() AS DATE) ) THEN CCPP.SaldoCuota ELSE 0 END) AS MOROSO ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) < DATEADD(day, -90,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.FechaVencimiento, 120) >= DATEADD(day, -120, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS ME120 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) <  DATEADD(day, -60, CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.FechaVencimiento, 120) >= DATEADD(day, -90, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS ME90 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) < DATEADD(day, -30,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.FechaVencimiento, 120) >= DATEADD(day, -60, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS ME60 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) < Convert(varchar(11), CAST(GETDATE() AS DATE), 120) AND  Convert(varchar(11), CCPP.FechaVencimiento, 120) >= convert(varchar(11),DATEADD(dd, DATEPART(dd, getdate())* -1, getdate()),120) THEN CCPP.SaldoCuota ELSE 0 END) AS ME30 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) = Convert(varchar(11),cast(DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0) as Date) , 120) THEN CCPP.SaldoCuota ELSE 0 END) AS ALDIA ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) > CAST(GETDATE() AS DATE) AND  Convert(varchar(11), CCPP.FechaVencimiento, 120) <= DATEADD(day, 30, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS MA30 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) > DATEADD(day, 30, CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.FechaVencimiento, 120) <= DATEADD(day, 60, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS MA60 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) > DATEADD(day, 60,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.FechaVencimiento, 120) <= DATEADD(day, 90,CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS MA90 ")
         '   .AppendLine("      ,SUM(CASE WHEN Convert(varchar(11), CCPP.FechaVencimiento, 120) > DATEADD(day, 90,CAST(GETDATE() AS DATE)) AND  Convert(varchar(11), CCPP.FechaVencimiento, 120) <= DATEADD(day, 120, CAST(GETDATE() AS DATE)) THEN CCPP.SaldoCuota ELSE 0 END) AS MA120 ")
         'End If

         .AppendLine("  ,CCPP.IdSucursal")

         .AppendLine("  FROM CuentasCorrientesProvPagos CCPP")
         .AppendLine("  INNER JOIN CuentasCorrientesProv CCP ON CCP.IdSucursal = CCPP.IdSucursal")
         .AppendLine("                                 AND CCP.IdTipoComprobante = CCPP.IdTipoComprobante")
         .AppendLine("                                 AND CCP.Letra = CCPP.Letra")
         .AppendLine("                                 AND CCP.CentroEmisor = CCPP.CentroEmisor")
         .AppendLine("                                 AND CCP.NumeroComprobante = CCPP.NumeroComprobante")
         .AppendLine("  INNER JOIN Proveedores P ON CCPP.IdProveedor= P.IdProveedor")
         .AppendLine("  INNER JOIN TiposComprobantes TC ON CCP.IdTipoComprobante = TC.IdTipoComprobante")
         .AppendLine("  INNER JOIN CategoriasProveedores CAT ON P.IdCategoria = CAT.IdCategoria")
         .AppendLine("  INNER JOIN Localidades L ON L.IdLocalidad = P.IdLocalidadProveedor")
         .AppendLine("  INNER JOIN Provincias PR ON PR.IdProvincia = L.IdProvincia")

         GetListaSucursalesMultiples(stb, sucursales, "CCPP")
         NivelAutorizacionProveedorTipoComprobante(stb, "P", "TC", nivelAutorizacion)

         If idProveedor > 0 Then
            .AppendLine("    AND P.IdProveedor = " & idProveedor.ToString())
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND P.IdCategoria = " & idCategoria.ToString())
         End If

         If grabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(grabaLibro = "SI", "1", "0").ToString())
         End If

         If Not String.IsNullOrEmpty(grupo) Then
            .AppendLine("	AND TC.Grupo = '" & grupo & "'")
         End If

         If excluirAnticipos = "SI" Then
            .AppendLine("      AND TC.EsAnticipo = 'False'")
         End If

         If excluirPreComprobantes = "SI" Then
            .AppendLine("       AND NOT TC.EsPreElectronico = 'True'")
         End If

         If Not String.IsNullOrEmpty(idProvincia) Then
            .AppendLine("	AND L.IdProvincia = '" & idProvincia & "'")
         End If

         .AppendFormatLine("  GROUP BY P.IdProveedor, P.NombreProveedor, P.NombreDeFantasia, P.IdProveedor, P.CodigoProveedor, CAT.NombreCategoria, P.CuitProveedor,CCPP.IdSucursal")

         Dim CampoASumar As String = IIf(Date.Today().Year > 1, "CCPP.ImporteCuota", "CCPP.SaldoCuota").ToString()

         If excluirSaldosNegativos = "SI" Then
            .AppendLine("    HAVING SUM(" & CampoASumar & ") > 0 ")
         Else
            .AppendLine("    HAVING SUM(" & CampoASumar & ") <> 0 ")
         End If

         .AppendLine("  ORDER BY P.NombreProveedor, P.CodigoProveedor")

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function GetParaAlerta(sucursales As Entidades.Sucursal(),
                                 fechaVancimientoHasta As Date?,
                                 saldoMinimoAlerta As Decimal,
                                 cantidadComprobanteAdeudados As Integer) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .Length = 0
         .AppendFormatLine("SELECT C.IdProveedor
                                    ,CodigoProveedor
                                    ,C.NombreProveedor
                                    ,Ca.NombreCategoria
                                    ,C.TelefonoProveedor
                                    ,CC.Total
                                    ,CC.Saldo
                                    ,CC.Cantidad")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("          SELECT CC.IdProveedor
		                                 , SUM(CCP.ImporteCuota) AS Total
                                       , SUM(CCP.SaldoCuota) as Saldo
             , COUNT(1) AS Cantidad
          FROM CuentasCorrientesProv CC
          INNER JOIN CuentasCorrientesProvPagos CCP 
                  ON CC.IdSucursal = CCP.IdSucursal
                 AND CC.IdTipoComprobante = CCP.IdTipoComprobante
                 AND CC.Letra = CCP.Letra
                 AND CC.CentroEmisor = CCP.CentroEmisor
                 AND CC.NumeroComprobante = CCP.NumeroComprobante
				 AND CC.IdProveedor = CCP.IdProveedor")
         .AppendFormatLine("          WHERE CC.IdTipoComprobante <> 'ANTICIPO'")

         GetListaSucursalesMultiples(stb, sucursales, "CC")

         If fechaVancimientoHasta.HasValue Then
            .AppendFormatLine("            AND CCP.FechaVencimiento <= '{0}'", ObtenerFecha(fechaVancimientoHasta.Value.UltimoSegundoDelDia(), True))
         End If
         .AppendFormatLine("           GROUP BY CC.IdProveedor")
         .AppendFormatLine("          HAVING SUM(CCP.ImporteCuota) > 0 ")
         .AppendFormatLine("             AND SUM(CCP.SaldoCuota) >= {0}", saldoMinimoAlerta)
         .AppendFormatLine("             AND COUNT(1) >= {0}", cantidadComprobanteAdeudados)
         .AppendFormatLine("        ) CC")
         .AppendFormatLine(" INNER JOIN Proveedores C ON C.IdProveedor = CC.IdProveedor
                             INNER JOIN CategoriasProveedores Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendFormatLine(" ORDER BY CC.Saldo DESC")
      End With

      Return GetDataTable(stb)

   End Function

   Public Function GetUna(idSucursal As Integer,
                        idTipoComprobante As String,
                        letra As String,
                        centroEmisor As Integer,
                        numeroComprobante As Long,
                        idProveedor As Long,
                        cuotaNumero As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CCP.*")
         .AppendLine("      ,(SELECT NombreProducto + ' / '  FROM ComprasProductos")
         .AppendLine("         WHERE idSucursal = CCP.IdSucursal And idTipoComprobante = CCP.IdTipoComprobante2 And letra = CCP.Letra2")
         .AppendLine("           AND CentroEmisor = CCP.CentroEmisor2 AND NumeroComprobante = CCP.NumeroComprobante2")
         .AppendLine("            AND IdProveedor = CCP.IdProveedor")
         .AppendLine("           FOR XML PATH('')) NombreProductos")
         .AppendLine("  FROM CuentasCorrientesProvPagos CCP")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", letra)
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormat("   AND IdProveedor = {0}", idProveedor)
         .AppendFormat("   AND CuotaNumero = {0}", cuotaNumero)

      End With

      Return GetDataTable(stb)

   End Function

End Class