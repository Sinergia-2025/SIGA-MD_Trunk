Public Class CuentasCorrientesProvCheques
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesProvCheques_I(idSucursal As Integer,
                                             idProveedor As Long,
                                             idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                                             idCheque As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .Append("INSERT INTO CuentasCorrientesProvCheques")
         .Append("           (IdSucursal")
         .Append("           ,IdProveedor")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,IdCheque)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,{0}", idProveedor)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,{0}", centroEmisor)
         .AppendFormat("           ,{0}", numeroComprobante)
         .AppendFormat("           ,{0}", idCheque)
         .Append(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CuentasCorrientesProvCheques_D(idSucursal As Integer,
                                             idProveedor As Long,
                                             idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE CuentasCorrientesProvCheques")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdProveedor = " & idProveedor.ToString())
         .AppendFormat(" AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat(" AND Letra = '{0}'", letra)
         .AppendFormat(" AND CentroEmisor = {0}", centroEmisor)
         .AppendFormat(" AND NumeroComprobante = {0}", numeroComprobante)
      End With
      Execute(myQuery)
   End Sub

   Public Function GetCuentasCorrientesProvCheques(nroOrdenPago As Long, desdeFecha As Date?, hastaFecha As Date?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT PV.CuitProveedor AS CUITCOMPANIA")
         .AppendFormatLine("     , EMP.CuitEmpresa AS CUITEMPRESA")
         .AppendFormatLine("     , CHQE.NumeroCheque AS NROCHEQUE")
         .AppendFormatLine("     , CHQE.IdBanco AS BANCOEMISOR")
         .AppendFormatLine("     , CHQE.IdBancoSucursal AS SUCURSAL")
         .AppendFormatLine("     , PV.NroCuenta AS CUENTA")
         .AppendFormatLine("     , '' AS CMC7")
         .AppendFormatLine("     , CONVERT(DATE, CHQE.FechaEmision) AS FECHAEMISION")
         .AppendFormatLine("     , CONVERT(DATE, CHQE.FechaCobro)   AS FECHAVTO")
         .AppendFormatLine("     , CHQE.Importe AS IMPORTE")
         .AppendFormatLine("     , CASE WHEN TPCH.SolicitaNroOperacion = 'True' THEN 'ED' ELSE 'DI' END AS TipoIPS")
         .AppendFormatLine("     , CASE WHEN CHQE.EsPropio = 'False' THEN 'TERCERO' ELSE 'PROPIO' END AS CARACTER")
         .AppendFormatLine("  FROM CuentasCorrientesProvCheques AS CCPC")
         .AppendFormatLine(" INNER JOIN Cheques AS CHQE ON CCPC.IdCheque = CHQE.IdCheque ")
         .AppendFormatLine(" INNER JOIN Sucursales AS SUC ON CHQE.IdSucursal = SUC.Id")
         .AppendFormatLine(" INNER JOIN Empresas AS EMP ON SUC.IdEmpresa = EMP.IdEmpresa")
         .AppendFormatLine(" INNER JOIN Proveedores AS PV ON CHQE.IdProveedor = PV.IdProveedor")
         .AppendFormatLine(" INNER JOIN TiposCheques AS TPCH ON TPCH.IdTipoCheque = CHQE.IdTipoCheque")
         .AppendFormatLine(" WHERE CHQE.IdEstadoCheque    = '{0}'", Entidades.Cheque.Estados.PROVEEDOR.ToString())
         If nroOrdenPago > 0 Then
            .AppendFormatLine(" AND CCPC.NumeroComprobante = {0}", nroOrdenPago)
         End If
         If desdeFecha.HasValue Then
            .AppendFormatLine("   AND CHQE.FechaEmision >= '{0}'", ObtenerFecha(desdeFecha.Value, False))
         End If
         If hastaFecha.HasValue Then
            .AppendFormatLine("   AND CHQE.FechaEmision <= '{0}'", ObtenerFecha(hastaFecha.Value.UltimoSegundoDelDia(), True))
         End If

         .AppendFormatLine(" UNION ALL ")

         .AppendFormatLine("SELECT PV.CuitProveedor AS CUITCOMPANIA")
         .AppendFormatLine("     , EMP.CuitEmpresa AS CUITEMPRESA")
         .AppendFormatLine("     , CONVERT(INT, NULL) AS NROCHEQUE")
         .AppendFormatLine("     , CONVERT(INT, NULL) AS BANCOEMISOR")
         .AppendFormatLine("     , CONVERT(INT, NULL) AS SUCURSAL")
         .AppendFormatLine("     , PV.NroCuenta AS CUENTA")
         .AppendFormatLine("     , '' AS CMC7")
         .AppendFormatLine("     , CONVERT(DATE, CCPC.Fecha) AS FECHAEMISION")
         .AppendFormatLine("     , CONVERT(DATE, NULL) AS FECHAVTO")
         .AppendFormatLine("     , CCPC.ImporteTransfBancaria AS IMPORTE")
         .AppendFormatLine("     , 'DI' AS TipoIPS")
         .AppendFormatLine("     , 'TRANSFERENCIA' AS CARACTER")
         .AppendFormatLine("  FROM CuentasCorrientesProv AS CCPC")
         .AppendFormatLine(" INNER JOIN Sucursales AS SUC ON CCPC.IdSucursal = SUC.Id")
         .AppendFormatLine(" INNER JOIN Empresas AS EMP ON SUC.IdEmpresa = EMP.IdEmpresa")
         .AppendFormatLine(" INNER JOIN Proveedores AS PV ON CCPC.IdProveedor = PV.IdProveedor")
         .AppendFormatLine(" WHERE CCPC.ImporteTransfBancaria <> 0")

         If nroOrdenPago > 0 Then
            .AppendFormatLine(" AND CCPC.NumeroComprobante = {0}", nroOrdenPago)
         End If
         If desdeFecha.HasValue Then
            .AppendFormatLine("   AND CCPC.Fecha >= '{0}'", ObtenerFecha(desdeFecha.Value, False))
         End If
         If hastaFecha.HasValue Then
            .AppendFormatLine("   AND CCPC.Fecha <= '{0}'", ObtenerFecha(hastaFecha.Value.UltimoSegundoDelDia(), True))
         End If

      End With
      Return GetDataTable(myQuery)
   End Function

End Class