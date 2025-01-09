Public Class RepartosCobranzasComprobantes
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RepartosCobranzasComprobantes_I(idSucursal As Integer,
                                              idReparto As Integer,
                                              idCobranza As Integer,
                                              idSucursalComp As Integer,
                                              idTipoComprobanteComp As String,
                                              letraComp As String,
                                              centroEmisorComp As Short,
                                              numeroComprobanteComp As Long,
                                              medioPagoSeleccionado As String,
                                              saldoComprobante As Decimal,
                                              totalEfectivo As Decimal,
                                              totalCuentaCorriente As Decimal,
                                              totalCheques As Decimal,
                                              totalNC As Decimal,
                                              totalAplicado As Decimal,
                                              totalReenvio As Decimal,
                                              totalTransferencia As Decimal,
                                              idCuentaBancaria As Integer?,
                                              fechaTransferencia As Date?,
                                              idSucursalRecibo As Integer,
                                              idTipoComprobanteRecibo As String,
                                              letraRecibo As String,
                                              centroEmisorRecibo As Short,
                                              numeroComprobanteRecibo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.RepartoCobranzaComprobante.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursal.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.IdReparto.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.IdCobranza.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursalComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.IdTipoComprobanteComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.LetraComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.CentroEmisorComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.NumeroComprobanteComp.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.MedioPagoSeleccionado.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.SaldoComprobante.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.TotalEfectivo.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.TotalCuentaCorriente.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.TotalCheques.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.TotalNC.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.TotalAplicado.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.TotalReenvio.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.TotalTransferencia.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.IdCuentaBancaria.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.FechaTransferencia.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursalRecibo.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.IdTipoComprobanteRecibo.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.LetraRecibo.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.CentroEmisorRecibo.ToString())
         .AppendFormatLine("          , {0}", Entidades.RepartoCobranzaComprobante.Columnas.NumeroComprobanteRecibo.ToString())

         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("            {0} ", idSucursal)
         .AppendFormatLine("          , {0} ", idReparto)
         .AppendFormatLine("          , {0} ", idCobranza)
         .AppendFormatLine("          , {0} ", idSucursalComp)
         .AppendFormatLine("          ,'{0}'", idTipoComprobanteComp)
         .AppendFormatLine("          ,'{0}'", letraComp)
         .AppendFormatLine("          , {0} ", centroEmisorComp)
         .AppendFormatLine("          , {0} ", numeroComprobanteComp)
         .AppendFormatLine("          ,'{0}'", medioPagoSeleccionado)
         .AppendFormatLine("          , {0} ", saldoComprobante)
         .AppendFormatLine("          , {0} ", totalEfectivo)
         .AppendFormatLine("          , {0} ", totalCuentaCorriente)
         .AppendFormatLine("          , {0} ", totalCheques)
         .AppendFormatLine("          , {0} ", totalNC)
         .AppendFormatLine("          , {0} ", totalAplicado)
         .AppendFormatLine("          , {0} ", totalReenvio)
         .AppendFormatLine("          , {0} ", totalTransferencia)
         .AppendFormatLine("          , {0} ", GetStringFromNumber(idCuentaBancaria))
         .AppendFormatLine("          , {0} ", ObtenerFecha(fechaTransferencia, False))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(idSucursalRecibo))
         .AppendFormatLine("          , {0} ", GetStringParaQueryConComillas(idTipoComprobanteRecibo))
         .AppendFormatLine("          , {0} ", GetStringParaQueryConComillas(letraRecibo))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(centroEmisorRecibo))
         .AppendFormatLine("          , {0} ", GetStringFromNumber(numeroComprobanteRecibo))

         .AppendLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub RepartosCobranzasComprobantes_U(idSucursal As Integer,
                                              idReparto As Integer,
                                              idCobranza As Integer,
                                              idSucursalComp As Integer,
                                              idTipoComprobanteComp As String,
                                              letraComp As String,
                                              centroEmisorComp As Short,
                                              numeroComprobanteComp As Long,
                                              medioPagoSeleccionado As String,
                                              saldoComprobante As Decimal,
                                              totalEfectivo As Decimal,
                                              totalCuentaCorriente As Decimal,
                                              totalCheques As Decimal,
                                              totalNC As Decimal,
                                              totalAplicado As Decimal,
                                              totalReenvio As Decimal,
                                              totalTransferencia As Decimal,
                                              idCuentaBancaria As Integer?,
                                              fechaTransferencia As Date?,
                                              idSucursalRecibo As Integer,
                                              idTipoComprobanteRecibo As String,
                                              letraRecibo As String,
                                              centroEmisorRecibo As Short,
                                              numeroComprobanteRecibo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.RepartoCobranzaComprobante.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.RepartoCobranzaComprobante.Columnas.MedioPagoSeleccionado.ToString(), medioPagoSeleccionado)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.SaldoComprobante.ToString(), saldoComprobante)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.TotalEfectivo.ToString(), totalEfectivo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.TotalCuentaCorriente.ToString(), totalCuentaCorriente)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.TotalCheques.ToString(), totalCheques)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.TotalNC.ToString(), totalNC)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.TotalAplicado.ToString(), totalAplicado)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.TotalReenvio.ToString(), totalReenvio)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.TotalTransferencia.ToString(), totalTransferencia)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdCuentaBancaria.ToString(), GetStringFromNumber(idCuentaBancaria))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.FechaTransferencia.ToString(), ObtenerFecha(fechaTransferencia, False))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursalRecibo.ToString(), GetStringFromNumber(idSucursalRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdTipoComprobanteRecibo.ToString(), GetStringParaQueryConComillas(idTipoComprobanteRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.LetraRecibo.ToString(), GetStringParaQueryConComillas(letraRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.CentroEmisorRecibo.ToString(), GetStringFromNumber(centroEmisorRecibo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.NumeroComprobanteRecibo.ToString(), GetStringFromNumber(numeroComprobanteRecibo))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdCobranza.ToString(), idCobranza)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaComprobante.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaComprobante.Columnas.LetraComp.ToString(), letraComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
      End With
      Execute(myQuery)
   End Sub

   Public Sub RepartosCobranzasComprobantes_D(idSucursal As Integer,
                                              idReparto As Integer,
                                              idCobranza As Integer,
                                              idSucursalComp As Integer,
                                              idTipoComprobanteComp As String,
                                              letraComp As String,
                                              centroEmisorComp As Short,
                                              numeroComprobanteComp As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.RepartoCobranzaComprobante.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdCobranza.ToString(), idCobranza)

         If idSucursalComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteComp) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaComprobante.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(letraComp) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoCobranzaComprobante.Columnas.LetraComp.ToString(), letraComp)
         End If
         If centroEmisorComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         End If
         If numeroComprobanteComp <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RBC.*")
         .AppendFormatLine("  FROM {0} AS RBC", Entidades.RepartoCobranzaComprobante.NombreTabla)
      End With
   End Sub

   Public Function RepartosCobranzasComprobantes_GA() As DataTable
      Return RepartosCobranzasComprobantes_G(idSucursal:=0, idReparto:=0, idCobranza:=0, idSucursalComp:=0, idTipoComprobanteComp:=String.Empty, letraComp:=String.Empty, centroEmisorComp:=0, numeroComprobanteComp:=0)
   End Function
   Public Function RepartosCobranzasComprobantes_GA(idSucursal As Integer, idReparto As Integer, idCobranza As Integer) As DataTable
      Return RepartosCobranzasComprobantes_G(idSucursal, idReparto, idCobranza, idSucursalComp:=0, idTipoComprobanteComp:=String.Empty, letraComp:=String.Empty, centroEmisorComp:=0, numeroComprobanteComp:=0)
   End Function
   Private Function RepartosCobranzasComprobantes_G(idSucursal As Integer,
                                                    idReparto As Integer,
                                                    idCobranza As Integer,
                                                    idSucursalComp As Integer,
                                                    idTipoComprobanteComp As String,
                                                    letraComp As String,
                                                    centroEmisorComp As Short,
                                                    numeroComprobanteComp As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal <> 0 Then
            .AppendFormatLine("   AND RBC.{0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND RBC.{0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdReparto.ToString(), idReparto)
         End If
         If idCobranza <> 0 Then
            .AppendFormatLine("   AND RBC.{0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdCobranza.ToString(), idCobranza)
         End If

         If idSucursalComp <> 0 Then
            .AppendFormatLine("   AND RBC.{0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.IdSucursalComp.ToString(), idSucursalComp)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobanteComp) Then
            .AppendFormatLine("   AND RBC.{0} = '{1}'", Entidades.RepartoCobranzaComprobante.Columnas.IdTipoComprobanteComp.ToString(), idTipoComprobanteComp)
         End If
         If Not String.IsNullOrWhiteSpace(letraComp) Then
            .AppendFormatLine("   AND RBC.{0} = '{1}'", Entidades.RepartoCobranzaComprobante.Columnas.LetraComp.ToString(), letraComp)
         End If
         If centroEmisorComp <> 0 Then
            .AppendFormatLine("   AND RBC.{0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.CentroEmisorComp.ToString(), centroEmisorComp)
         End If
         If numeroComprobanteComp <> 0 Then
            .AppendFormatLine("   AND RBC.{0} =  {1} ", Entidades.RepartoCobranzaComprobante.Columnas.NumeroComprobanteComp.ToString(), numeroComprobanteComp)
         End If

      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function RepartosCobranzasComprobantes_G1(idSucursal As Integer,
                                                    idReparto As Integer,
                                                    idCobranza As Integer,
                                                    idSucursalComp As Integer,
                                                    idTipoComprobanteComp As String,
                                                    letraComp As String,
                                                    centroEmisorComp As Short,
                                                    numeroComprobanteComp As Long) As DataTable
      Return RepartosCobranzasComprobantes_G(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp)
   End Function

   '# Se un UNION a la tabla anterior para obtener los registros grabados en la tabla correspondiente a Registración de Pagos v1
   Public Function ObtenerRecibosDetallado(nroReparto As Integer) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT RC.IdSucursal,RC.IdReparto,RC.Orden,RC.IdSucursalRecibo,RC.IdTipoComprobanteRecibo")
         .AppendFormatLine("	  ,RC.LetraRecibo,RC.CentroEmisorRecibo,RC.NumeroComprobanteRecibo,RC.ImporteTotalFact")
         .AppendFormatLine("	  ,RC.ImporteTotalRecibo, CC.Observacion, CC.IdCliente,C.NombreCliente FROM RepartosComprobantes RC ")
         .AppendFormatLine("LEFT JOIN CuentasCorrientes CC ON CC.IdSucursal = RC.IdSucursalRecibo")
         .AppendFormatLine("							  AND CC.IdTipoComprobante = RC.IdTipoComprobanteRecibo")
         .AppendFormatLine("							  AND CC.Letra = RC.LetraRecibo")
         .AppendFormatLine("							  AND CC.CentroEmisor = RC.CentroEmisorRecibo")
         .AppendFormatLine("							  AND CC.NumeroComprobante = RC.NumeroComprobanteRecibo")
         .AppendFormatLine("LEFT JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendFormatLine("INNER JOIN TiposComprobantes TC ON RC.IdTipoComprobanteRecibo = TC.IdTipoComprobante")
         .AppendFormatLine("WHERE RC.IdTipoComprobanteRecibo IS NOT NULL AND RC.IdReparto = {0}", nroReparto)
         .AppendFormatLine("UNION")
         .AppendFormatLine("SELECT RCC.IdSucursal, RCC.IdReparto, RCC.IdCobranza,RCC.IdSucursalRecibo,RCC.IdTipoComprobanteRecibo, RCC.LetraRecibo,")
         .AppendFormatLine("	   RCC.CentroEmisorRecibo, RCC.NumeroComprobanteRecibo, RCC.SaldoComprobante,")
         .AppendFormatLine("	   (RCC.TotalEfectivo + RCC.TotalCheques + RCC.TotalNC + RCC.TotalTransferencia) ImporteTotalRecibo, CC.Observacion,")
         .AppendFormatLine("	   CC.IdCliente,C.NombreCliente FROM RepartosCobranzasComprobantes RCC ")
         .AppendFormatLine("LEFT JOIN CuentasCorrientes CC ON CC.IdSucursal = RCC.IdSucursalRecibo")
         .AppendFormatLine("							  AND CC.IdTipoComprobante = RCC.IdTipoComprobanteRecibo")
         .AppendFormatLine("							  AND CC.Letra = RCC.LetraRecibo")
         .AppendFormatLine("							  AND CC.CentroEmisor = RCC.CentroEmisorRecibo")
         .AppendFormatLine("							  AND CC.NumeroComprobante = RCC.NumeroComprobanteRecibo")
         .AppendFormatLine("LEFT JOIN Clientes C ON CC.IdCliente = C.IdCliente")
         .AppendFormatLine("INNER JOIN TiposComprobantes TC ON RCC.IdTipoComprobanteRecibo = TC.IdTipoComprobante")
         .AppendFormatLine("WHERE RCC.IdTipoComprobanteRecibo IS NOT NULL AND RCC.IdReparto = {0}", nroReparto)
         .AppendFormatLine("	AND TC.ImporteMinimo <> 0 AND TC.ImporteTope <> 0") '# No se contemplan las MINUTAS

         .AppendFormatLine("ORDER BY C.NombreCliente")

      End With
      Return GetDataTable(query)
   End Function

   Public Sub ActualizarComprobantePorComprobante(idSucursal As Integer,
                                                  idTipoComprobanteActual As String,
                                                  letraActual As String,
                                                  centroEmisorActual As Integer,
                                                  numeroComprobanteActual As Long,
                                                  idTipoComprobanteNuevo As String,
                                                  letraNuevo As String,
                                                  centroEmisorNuevo As Integer,
                                                  numeroComprobanteNuevo As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE RepartosCobranzasComprobantes")
         .AppendFormatLine("   SET IdTipoComprobanteComp = '{0}'", idTipoComprobanteNuevo)
         .AppendFormatLine("      ,LetraComp = '{0}'", letraNuevo)
         .AppendFormatLine("      ,CentroEmisorComp = {0}", centroEmisorNuevo)
         .AppendFormatLine("      ,NumeroComprobanteComp = {0}", numeroComprobanteNuevo)
         .AppendFormatLine("   WHERE IdSucursalComp = {0}", idSucursal)
         .AppendFormatLine("     AND IdTipoComprobanteComp = '{0}'", idTipoComprobanteActual)
         .AppendFormatLine("     AND LetraComp = '{0}'", letraActual)
         .AppendFormatLine("     AND CentroEmisorComp = {0}", centroEmisorActual)
         .AppendFormatLine("     AND NumeroComprobanteComp = {0}", numeroComprobanteActual)
      End With
      Me.Execute(myQuery.ToString())
   End Sub


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "RBC." + columna
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return GetDataTable(stb)
   End Function

End Class