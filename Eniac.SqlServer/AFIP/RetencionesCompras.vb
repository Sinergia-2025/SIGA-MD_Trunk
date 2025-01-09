Public Class RetencionesCompras
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RetencionesCompras_I(ByVal IdSucursal As Integer,
                                ByVal IdTipoImpuesto As String,
                                ByVal EmisorRetencion As Integer,
                                ByVal NumeroRetencion As Long,
                                ByVal IdProveedor As Long,
                                ByVal FechaEmision As DateTime,
                                ByVal BaseImponible As Decimal,
                                ByVal Alicuota As Decimal,
                                ByVal ImporteTotal As Decimal,
                                ByVal IdCajaEgreso As Integer,
                                ByVal NroPlanillaEgreso As Integer,
                                ByVal NroMovimientoEgreso As Integer,
                                ByVal IdEstado As Entidades.Retencion.Estados,
                                ByVal IdRegimen As Integer,
                                   ajusteManual As Boolean,
                                   baseImponibleCalculada As Decimal,
                                   importeTotalCalculado As Decimal)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO RetencionesCompras (")
         .Append("           IdSucursal")
         .Append("           ,IdTipoImpuesto")
         .Append("           ,EmisorRetencion")
         .Append("           ,NumeroRetencion")
         .Append("           ,IdProveedor")
         .Append("           ,FechaEmision")
         .Append("           ,BaseImponible")
         .Append("           ,Alicuota")
         .Append("           ,ImporteTotal")
         .Append("           ,IdCajaEgreso")
         .Append("           ,NroPlanillaEgreso")
         .Append("           ,NroMovimientoEgreso")
         .Append("           ,IdEstado")
         .Append("           ,IdRegimen")
         .Append("           ,AjusteManual")
         .Append("           ,BaseImponibleCalculada")
         .Append("           ,ImporteTotalCalculado")
         .Append(")     VALUES(")
         .AppendFormat("           {0}", IdSucursal)
         .AppendFormat("           ,'{0}'", IdTipoImpuesto)
         .AppendFormat("           ,{0}", EmisorRetencion)
         .AppendFormat("           ,{0}", NumeroRetencion)
         .AppendFormat("           ,{0}", IdProveedor)
         .AppendFormat("           ,'{0}'", FechaEmision.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("           ,{0}", BaseImponible)
         .AppendFormat("           ,{0}", Alicuota)
         .AppendFormat("           ,{0}", ImporteTotal)
         If IdCajaEgreso = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdCajaEgreso)
         End If
         If NroPlanillaEgreso = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", NroPlanillaEgreso)
         End If
         If NroMovimientoEgreso = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", NroMovimientoEgreso)
         End If
         .AppendFormat("           ,'{0}'", IdEstado.ToString())
         If IdRegimen = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdRegimen)
         End If
         .AppendFormatLine("          ,{0}", GetStringFromBoolean(ajusteManual))
         .AppendFormatLine("          ,{0}", baseImponibleCalculada)
         .AppendFormatLine("          ,{0}", importeTotalCalculado)
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "RetencionesCompras")
   End Sub

   Public Sub RetencionesCompras_U(ByVal IdSucursal As Integer,
                                    ByVal IdTipoImpuesto As String,
                                    ByVal EmisorRetencion As Integer,
                                    ByVal NumeroRetencion As Long,
                                    ByVal IdProveedor As Long,
                                    ByVal FechaEmision As DateTime,
                                    ByVal BaseImponible As Decimal,
                                    ByVal Alicuota As Decimal,
                                    ByVal ImporteTotal As Decimal,
                                    ByVal IdCajaEgreso As Integer,
                                    ByVal NroPlanillaEgreso As Integer,
                                    ByVal NroMovimientoEgreso As Integer,
                                    ByVal IdEstado As Entidades.Retencion.Estados,
                                    ByVal IdRegimen As Integer,
                                    ajusteManual As Boolean,
                                    baseImponibleCalculada As Decimal,
                                    importeTotalCalculado As Decimal)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE RetencionesCompras SET ")
         .AppendFormat("      IdSucursal = {0}", IdSucursal)
         .AppendFormat("      ,IdTipoImpuesto = '{0}'", IdTipoImpuesto)
         .AppendFormat("      ,EmisorRetencion = {0}", EmisorRetencion)
         .AppendFormat("      ,NumeroRetencion = {0}", NumeroRetencion)
         .AppendFormat("      ,IdProveedor = {0}", IdProveedor)
         .AppendFormat("      ,FechaEmision = '{0}'", FechaEmision.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("      ,BaseImponible = {0}", BaseImponible)
         .AppendFormat("      ,Alicuota = {0}", Alicuota)
         .AppendFormat("      ,ImporteTotal = {0}", ImporteTotal)
         If IdCajaEgreso = 0 Then
            .AppendFormat("      ,IdCajaEgreso = null")
         Else
            .AppendFormat("      ,IdCajaEgreso = {0}", IdCajaEgreso)
         End If
         If NroPlanillaEgreso = 0 Then
            .AppendFormat("      ,NroPlanillaEgreso = null")
         Else
            .AppendFormat("      ,NroPlanillaEgreso = {0}", NroPlanillaEgreso)
         End If
         If NroMovimientoEgreso = 0 Then
            .AppendFormat("      ,NroMovimientoEgreso = null")
         Else
            .AppendFormat("      ,NroMovimientoEgreso = {0}", NroMovimientoEgreso)
         End If
         .AppendFormat("      ,IdEstado = '{0}'", IdEstado.ToString())
         If IdRegimen = 0 Then
            .AppendFormat("      ,IdRegimen = null")
         Else
            .AppendFormat("      ,IdRegimen = {0}", IdRegimen)
         End If

         .AppendFormat("      ,AjusteManual = {0}", GetStringFromBoolean(ajusteManual))
         .AppendFormat("      ,BaseImponibleCalculada = {0}", baseImponibleCalculada)
         .AppendFormat("      ,ImporteTotalCalculado = {0}", importeTotalCalculado)

         .Append(" WHERE ")
         .AppendFormat("      IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND IdTipoImpuesto = '{0}'", IdTipoImpuesto)
         .AppendFormat("      AND EmisorRetencion = {0}", EmisorRetencion)
         .AppendFormat("      AND NumeroRetencion = {0}", NumeroRetencion)
         .AppendFormat("      AND IdProveedor = {0}", IdProveedor)
      End With

      Me.Execute(qry.ToString())

   End Sub

   Public Sub RetencionesCompras_D(ByVal IdSucursal As Integer,
                                    ByVal IdTipoImpuesto As String,
                                    ByVal EmisorRetencion As Integer,
                                    ByVal NumeroRetencion As Long,
                                    ByVal IdProveedor As Long)

      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM RetencionesCompras WHERE ")
         .AppendFormat("      IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND IdTipoImpuesto = '{0}'", IdTipoImpuesto)
         .AppendFormat("      AND EmisorRetencion = {0}", EmisorRetencion)
         .AppendFormat("      AND NumeroRetencion = {0}", NumeroRetencion)
         .AppendFormat("      AND IdProveedor = {0}", IdProveedor)
      End With

      Me.Execute(qry.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT RC.IdSucursal")
         .Append("           ,RC.IdTipoImpuesto")
         .Append("           ,RC.EmisorRetencion")
         .Append("           ,RC.NumeroRetencion")
         .Append("           ,RC.IdProveedor")
         .Append("           ,RC.FechaEmision")
         .Append("           ,RC.BaseImponible")
         .Append("           ,RC.Alicuota")
         .Append("           ,RC.ImporteTotal")
         .Append("           ,RC.IdCajaEgreso")
         .Append("           ,RC.NroPlanillaEgreso")
         .Append("           ,RC.NroMovimientoEgreso")
         .Append("           ,RC.IdEstado")
         .Append("           ,RC.IdRegimen")
         .Append("           ,RC.AjusteManual")
         .Append("           ,RC.BaseImponibleCalculada")
         .Append("           ,RC.ImporteTotalCalculado")
         .Append("  FROM RetencionesCompras RC")
      End With
   End Sub

   Public Function RetencionesCompras_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function RetencionesCompras_G1(ByVal IdSucursal As Integer, _
                                    ByVal IdTipoImpuesto As String, _
                                    ByVal EmisorRetencion As Integer, _
                                    ByVal NumeroRetencion As Long, _
                                    ByVal IdProveedor As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat("      RC.IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND RC.IdTipoImpuesto = '{0}'", IdTipoImpuesto)
         .AppendFormat("      AND RC.EmisorRetencion = {0}", EmisorRetencion)
         .AppendFormat("      AND RC.NumeroRetencion = {0}", NumeroRetencion)
         .AppendFormat("      AND RC.IdProveedor = {0}", IdProveedor)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "RC." + columna
      'If columna = "R.NombreVendedor" Then columna = "V.NombreEmpleado"
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorCuentaCorrienteProv(ByVal idSucursal As Integer, _
                                             ByVal idTipoComprobante As String, _
                                             ByVal letra As String, _
                                             ByVal centroEmisor As Integer, _
                                             ByVal numeroComprobante As Long, _
                                             ByVal IdProveedor As Long) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Me.SelectFiltrado(stb, String.Empty)

      With stb
         .AppendLine(" LEFT JOIN CuentasCorrientesProvRetenciones CCR ON RC.idSucursal = CCR.idSucursal AND RC.IdTipoImpuesto = CCR.IdTipoImpuesto")
         .AppendLine("        AND RC.EmisorRetencion = CCR.EmisorRetencion AND RC.NumeroRetencion = CCR.NumeroRetencion")
         .AppendLine("        AND RC.IdProveedor = CCR.IdProveedor")
         .AppendLine(" WHERE CCR.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND CCR.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND CCR.Letra = '" & letra & "'")
         .AppendLine("   AND CCR.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND CCR.NumeroComprobante = " & numeroComprobante.ToString())
         .AppendLine("   AND CCR.IdProveedor = " & IdProveedor.ToString())
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Private Sub SelectFiltrado(ByVal stb As StringBuilder, AplicativoAfip As String)

      With stb
         .Length = 0
         .AppendLine("SELECT RC.idSucursal")
         .AppendLine("      ,RC.FechaEmision")
         .AppendLine("      ,RC.IdTipoImpuesto")
         .AppendLine("      ,TI.NombreTipoImpuesto")
         .AppendLine("      ,TI.CodigoArticuloInciso")
         .AppendLine("      ,TI.ArticuloInciso")
         .AppendLine("      ,RC.EmisorRetencion")
         .AppendLine("      ,RC.NumeroRetencion")
         .AppendLine("      ,RC.IdCajaEgreso")
         .AppendLine("      ,RC.NroPlanillaEgreso")
         .AppendLine("      ,RC.NroMovimientoEgreso")
         .AppendLine("      ,RC.BaseImponible")
         .AppendLine("      ,RC.Alicuota")
         .AppendLine("      ,RC.ImporteTotal")
         .AppendLine("      ,RC.IdEstado")
         .AppendLine("      ,RC.IdProveedor")
         .AppendLine("      ,RC.AjusteManual")
         .AppendLine("      ,RC.BaseImponibleCalculada")
         .AppendLine("      ,RC.ImporteTotalCalculado")
         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")
         .AppendLine("      ,P.IngresosBrutos")
         .AppendLine("      ,P.IdCategoriaFiscal")
         .AppendLine("      ,P.CuitProveedor")
         .AppendLine("      ,P.EsPasibleRetencionIIBB")
         .AppendLine("      ,RC.IdRegimen")
         .AppendLine("      ,CCPR.IdTipoComprobante")
         .AppendLine("      ,CCPR.Letra")
         .AppendLine("      ,CCPR.CentroEmisor")
         .AppendLine("      ,CCPR.NumeroComprobante")
         .AppendLine("      ,CCP.ImporteTotal * -1 as ImporteComprobante")
         '.AppendLine("     , P.NombreProvincia")
         '.AppendLine("     , P.Jurisdiccion")

         If AplicativoAfip = "DRAGMA" Then
            .AppendLine("      ,CCPP.IdTipoComprobante2")
            .AppendLine("      ,CCPP.Letra2")
            .AppendLine("      ,CCPP.CentroEmisor2")
            .AppendLine("      ,CCPP.NumeroComprobante2")
         End If

         .AppendLine("      ,CCPR.SecuenciaRetencion")

         .AppendLine("  FROM RetencionesCompras RC")
         .AppendLine("  LEFT JOIN TiposImpuestos TI ON RC.IdTipoImpuesto=  TI.IdTipoImpuesto")
         .AppendLine("  LEFT JOIN Proveedores P ON RC.IdProveedor = P.IdProveedor")
         '.AppendLine("  LEFT JOIN  P ON RC.IdProveedor = P.IdProveedor")

         .AppendLine("  LEFT JOIN CuentasCorrientesProvRetenciones CCPR ON CCPR.IdSucursal = RC.IdSucursal AND CCPR.IdTipoImpuesto = RC.IdTipoImpuesto ")
         .AppendLine("     AND CCPR.EmisorRetencion = RC.EmisorRetencion AND CCPR.NumeroRetencion = RC.NumeroRetencion AND CCPR.IdProveedor = RC.IdProveedor")
         .AppendLine(" LEFT JOIN  CuentasCorrientesProv CCP ON CCP.IdSucursal = RC.IdSucursal AND CCP.IdTipoComprobante = CCPR.IdTipoComprobante AND ")
         .AppendLine(" CCP.Letra = CCPR.Letra AND CCP.CentroEmisor = CCPR.CentroEmisor AND CCP.NumeroComprobante = CCPR.NumeroComprobante")
         If AplicativoAfip = "DRAGMA" Then
            .AppendLine(" LEFT JOIN  CuentasCorrientesProvPagos CCPP ON CCPP.IdSucursal = RC.IdSucursal AND CCPP.IdTipoComprobante = CCPR.IdTipoComprobante AND ")
            .AppendLine(" CCPP.Letra = CCPR.Letra AND CCPP.CentroEmisor = CCPR.CentroEmisor AND CCPP.NumeroComprobante = CCPR.NumeroComprobante")
         End If
      End With

   End Sub

   Public Function GetTodos(ByVal sucursales As Entidades.Sucursal(), _
                           ByVal FechaDesde As Date, _
                           ByVal FechaHasta As Date, _
                           ByVal IdTipoImpuesto As String, _
                           ByVal AplicativoAfip As String) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      Me.SelectFiltrado(stbQuery, AplicativoAfip)

      With stbQuery
         .AppendLine("  WHERE 1 = 1")

         GetListaSucursalesMultiples(stbQuery, sucursales, "RC")

         If FechaDesde > Date.Parse("01/01/1990") Then
            .AppendLine("   AND RC.FechaEmision  >= '" & FechaDesde.ToString("yyyyMMdd") & " 00:00:00'")
            .AppendLine("   AND RC.FechaEmision  <= '" & FechaHasta.ToString("yyyyMMdd") & " 23:59:59' ")
         End If

         If Not String.IsNullOrEmpty(IdTipoImpuesto) Then
            .AppendLine("   AND RC.IdTipoImpuesto = '" & IdTipoImpuesto & "'")
         End If

         If Not String.IsNullOrEmpty(AplicativoAfip) Then
            .AppendLine("   AND TI.AplicativoAfip = '" & AplicativoAfip & "'")
         End If
         If AplicativoAfip = "DRAGMA" Then

         End If
         .AppendLine("   ORDER BY RC.FechaEmision")
      End With

      Return Me.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetProximoNumero(ByVal idSucursal As Integer, _
                                    ByVal IdTipoImpuesto As Entidades.TipoImpuesto.Tipos, _
                                    ByVal EmisorRetencion As Integer) As Integer

      'La numeracion es unica para todos
      'ByVal IdProveedor As Long) As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT MAX(NumeroRetencion) Numero ")
         .Append(" FROM RetencionesCompras")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND IdTipoImpuesto = '{0}'", IdTipoImpuesto.ToString())
         .AppendFormat(" AND EmisorRetencion = {0}", EmisorRetencion)
         '.AppendFormat(" AND IdProveedor = {0}", IdProveedor)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Numero").ToString()) Then
            Return Integer.Parse(dt.Rows(0)("Numero").ToString()) + 1
         End If
      End If

      Return 1

   End Function

End Class
