Public Class Repartos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub Repartos_I(idSucursal As Integer,
                        idReparto As Integer,
                        fechaReparto As Date?,
                        idTransportista As Integer?,
                        idEstado As String,
                        idUsuario As String,
                        fechaActualizacion As Date,
                        idSucursalSalida As Integer?,
                        idTipoComprobanteSalida As String,
                        letraSalida As String,
                        centroEmisorSalida As Short?,
                        numeroComprobanteSalida As Long?,
                        idSucursalEntrada As Integer?,
                        idTipoComprobanteEntrada As String,
                        letraEntrada As String,
                        centroEmisorEntrada As Short?,
                        numeroComprobanteEntrada As Long?,
                        totalGastos As Decimal,
                        totalGastosCompras As Decimal,
                        totalGastosCaja As Decimal,
                        totalResumenComprobante As Decimal,
                        totalResumenEfectivo As Decimal,
                        totalResumenTransferencia As Decimal,
                        totalResumenCtaCte As Decimal,
                        totalResumenCheques As Decimal,
                        totalResumenNCred As Decimal,
                        totalResumenReenvio As Decimal,
                        totalResumenSaldoGeneral As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.Reparto.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.Reparto.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.IdReparto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.FechaReparto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.IdTransportista.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.IdEstado.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.IdUsuario.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.FechaActualizacion.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.IdSucursalSalida.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.IdTipoComprobanteSalida.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.LetraSalida.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.CentroEmisorSalida.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.NumeroComprobanteSalida.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.IdSucursalEntrada.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.IdTipoComprobanteEntrada.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.LetraEntrada.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.CentroEmisorEntrada.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.NumeroComprobanteEntrada.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalGastos.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalGastosCompras.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalGastosCaja.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalResumenComprobante.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalResumenEfectivo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalResumenTransferencia.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalResumenCtaCte.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalResumenCheques.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalResumenNCred.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalResumenReenvio.ToString())
         .AppendFormatLine("           , {0} ", Entidades.Reparto.Columnas.TotalResumenSaldoGeneral.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           , {0} ", idReparto)
         If fechaReparto.HasValue Then
            .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaReparto.Value, True))
         Else
            .AppendFormatLine("           ,NULL ")
         End If
         .AppendFormatLine("           , {0} ", GetStringFromNumber(idTransportista))
         .AppendFormatLine("           ,'{0}'", idEstado)
         .AppendFormatLine("           ,'{0}'", idUsuario)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaActualizacion, True))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(idSucursalSalida))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(idTipoComprobanteSalida))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(letraSalida))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(centroEmisorSalida))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(numeroComprobanteSalida))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(idSucursalEntrada))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(idTipoComprobanteEntrada))
         .AppendFormatLine("           , {0} ", GetStringParaQueryConComillas(letraEntrada))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(centroEmisorEntrada))
         .AppendFormatLine("           , {0} ", GetStringFromNumber(numeroComprobanteEntrada))
         .AppendFormatLine("           , {0} ", totalGastos)
         .AppendFormatLine("           , {0} ", totalGastosCompras)
         .AppendFormatLine("           , {0} ", totalGastosCaja)
         .AppendFormatLine("           , {0} ", totalResumenComprobante)
         .AppendFormatLine("           , {0} ", totalResumenEfectivo)
         .AppendFormatLine("           , {0} ", totalResumenTransferencia)
         .AppendFormatLine("           , {0} ", totalResumenCtaCte)
         .AppendFormatLine("           , {0} ", totalResumenCheques)
         .AppendFormatLine("           , {0} ", totalResumenNCred)
         .AppendFormatLine("           , {0} ", totalResumenReenvio)
         .AppendFormatLine("           , {0} ", totalResumenSaldoGeneral)
         .AppendFormatLine("           )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Repartos_U(idSucursal As Integer,
                        idReparto As Integer,
                        totalResumenComprobante As Decimal,
                        totalResumenEfectivo As Decimal,
                        totalResumenTransferencia As Decimal,
                        totalResumenCtaCte As Decimal,
                        totalResumenCheques As Decimal,
                        totalResumenNCred As Decimal,
                        totalResumenReenvio As Decimal,
                        totalResumenSaldoGeneral As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Reparto.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.Reparto.Columnas.TotalResumenComprobante.ToString(), totalResumenComprobante)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Reparto.Columnas.TotalResumenEfectivo.ToString(), totalResumenEfectivo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Reparto.Columnas.TotalResumenTransferencia.ToString(), totalResumenTransferencia)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Reparto.Columnas.TotalResumenCtaCte.ToString(), totalResumenCtaCte)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Reparto.Columnas.TotalResumenCheques.ToString(), totalResumenCheques)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Reparto.Columnas.TotalResumenNCred.ToString(), totalResumenNCred)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Reparto.Columnas.TotalResumenReenvio.ToString(), totalResumenReenvio)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Reparto.Columnas.TotalResumenSaldoGeneral.ToString(), totalResumenSaldoGeneral)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Reparto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.Reparto.Columnas.IdReparto.ToString(), idReparto)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Repartos_D(idSucursal As Integer, idReparto As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.Reparto.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Reparto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.Reparto.Columnas.IdReparto.ToString(), idReparto)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ActualizaTotalesResumenes(idSucursal As Integer,
                        idReparto As Integer,
                        totalResumenComprobante As Decimal,
                        totalResumenEfectivo As Decimal,
                        totalResumenTransferencia As Decimal,
                        totalResumenCtaCte As Decimal,
                        totalResumenCheques As Decimal,
                        totalResumenNCred As Decimal,
                        totalResumenReenvio As Decimal,
                        totalResumenSaldoGeneral As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Reparto.NombreTabla)
         .AppendFormatLine("   SET {0} = {1} ", Entidades.Reparto.Columnas.TotalResumenComprobante.ToString(), totalResumenComprobante)
         .AppendFormatLine("     , {0} += {1} ", Entidades.Reparto.Columnas.TotalResumenEfectivo.ToString(), totalResumenEfectivo)
         .AppendFormatLine("     , {0} += {1} ", Entidades.Reparto.Columnas.TotalResumenTransferencia.ToString(), totalResumenTransferencia)
         .AppendFormatLine("     , {0} += {1} ", Entidades.Reparto.Columnas.TotalResumenCtaCte.ToString(), totalResumenCtaCte)
         .AppendFormatLine("     , {0} += {1} ", Entidades.Reparto.Columnas.TotalResumenCheques.ToString(), totalResumenCheques)
         .AppendFormatLine("     , {0} += {1} ", Entidades.Reparto.Columnas.TotalResumenNCred.ToString(), totalResumenNCred)
         .AppendFormatLine("     , {0} += {1} ", Entidades.Reparto.Columnas.TotalResumenReenvio.ToString(), totalResumenReenvio)
         .AppendFormatLine("     , {0} = {1} ", Entidades.Reparto.Columnas.TotalResumenSaldoGeneral.ToString(), totalResumenSaldoGeneral)

         .AppendFormatLine(" WHERE {0} = {1} ", Entidades.Reparto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = {1} ", Entidades.Reparto.Columnas.IdReparto.ToString(), idReparto)
      End With
      Execute(myQuery)
   End Sub
#End Region

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT R.*")
         .AppendFormatLine("  FROM {0} AS R", Entidades.Reparto.NombreTabla)
      End With
   End Sub

#Region "GetAll"
   Public Function Repartos_GA(idSucursal As Integer) As DataTable
      Return Repartos_G(idSucursal, idReparto:=0)
   End Function
   Private Function Repartos_G(idSucursal As Integer, idReparto As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND R.{0} =  {1} ", Entidades.Reparto.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND  R.{0} =  {1} ", Entidades.Reparto.Columnas.IdReparto.ToString(), idReparto)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function Repartos_G1(idSucursal As Integer, idReparto As Integer) As DataTable
      Return Repartos_G(idSucursal, idReparto)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "CategoriaParametro" Or columna = "DescripcionParametro" Then
      '   columna = "P." + columna
      'ElseIf columna = "ValorParametroOriginal" Then
      '   columna = "P.ValorParametro"
      'Else
      columna = "R." + columna
      'End If
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return GetDataTable(stb)
   End Function
#End Region

   Public Overloads Function GetCodigoMaximo(idSucursal As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.Reparto.Columnas.IdReparto.ToString(),
                                             Entidades.Reparto.NombreTabla,
                                             String.Format("{0} = {1}", Entidades.Reparto.Columnas.IdSucursal.ToString(), idSucursal)))
   End Function

   Public Function GetConsolidadPorModelo(dtProductos As DataTable, idSucursal As Integer, idReparto As Integer, mostrarPrecioConIva As Boolean) As DataTable
      'Dim idRuta As Integer = rutas(0).IdRuta
      Dim stb = New StringBuilder()

      Dim campo_pivot_precio As StringBuilder = New StringBuilder()
      Dim campo_pivot_cantidad As StringBuilder = New StringBuilder()
      Dim campo_pivot_cantidadCambio As StringBuilder = New StringBuilder()
      Dim campo_sum As StringBuilder = New StringBuilder()
      For Each drCampos As DataRow In dtProductos.Rows
         campo_pivot_precio.AppendFormat("[{0}___precio],", drCampos("IdProducto"))
         campo_pivot_cantidad.AppendFormat("[{0}___cantidad],", drCampos("IdProducto"))
         campo_pivot_cantidadCambio.AppendFormat("[{0}___cantidadCambio],", drCampos("IdProducto"))

         campo_sum.AppendFormat(", SUM([{0}___precio]) [{0}___precio], SUM([{0}___cantidad]) [{0}___cantidad], SUM([{0}___cantidadCambio]) [{0}___cantidadCambio]", drCampos("IdProducto")).AppendLine()
      Next



      With stb
         .AppendFormatLine("SELECT IdCliente, CodigoCliente, NombreCliente, Direccion")
         .AppendFormatLine(campo_sum.ToString())
         .AppendFormatLine("     , CONVERT(decimal(12,2), ImporteTotal) ImporteTotal")
         .AppendFormatLine("     , CONVERT(decimal(12,2), ImportePagado) ImportePagado")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("  SELECT *")
         .AppendFormatLine("  FROM (SELECT ISNULL(C.IdCliente, CCC.IdCliente) IdCliente , ISNULL(C.CodigoCliente, CCC.CodigoCliente) CodigoCliente")
         .AppendFormatLine("             , ISNULL(C.NombreCliente, CCC.NombreCliente) NombreCliente, ISNULL(C.Direccion, CCC.Direccion) Direccion")
         .AppendFormatLine("             , P.IdProducto, P.NombreProducto")
         If mostrarPrecioConIva Then
            .AppendFormatLine("             , CONVERT(DECIMAL(14,2), RCP.PrecioConImp) PrecioVenta")
         Else
            .AppendFormatLine("             , CONVERT(DECIMAL(14,2), RCP.Precio) PrecioVenta")
         End If
         .AppendFormatLine("             , CONVERT(DECIMAL(14,2), RCP.Cantidad) AS Cantidad")
         .AppendFormatLine("             , CONVERT(DECIMAL(14,2), RCP.CantidadCambio) AS CantidadCambio")
         .AppendFormatLine("             , P.IdProducto + '___precio'   producto_precio")
         .AppendFormatLine("             , P.IdProducto + '___cantidad' producto_cantidad")
         .AppendFormatLine("             , P.IdProducto + '___cantidadCambio' producto_cantidadCambio")
         .AppendFormatLine("             , RC.ImporteTotalFact ImporteTotal")
         .AppendFormatLine("             , RC.ImporteTotalRecibo ImportePagado")
         '.AppendFormatLine("          FROM Clientes C")
         .AppendFormatLine("          FROM RepartosComprobantes RC")
         .AppendFormatLine("          LEFT JOIN Ventas V ON V.IdSucursal = RC.IdSucursal")
         .AppendFormatLine("                            AND V.IdTipoComprobante = RC.IdTipoComprobanteFact")
         .AppendFormatLine("                            AND V.Letra = RC.LetraFact")
         .AppendFormatLine("                            AND V.CentroEmisor = RC.CentroEmisorFact")
         .AppendFormatLine("                            AND V.NumeroComprobante = RC.NumeroComprobante")

         .AppendFormatLine("          LEFT JOIN CuentasCorrientes CC ON CC.IdSucursal = RC.IdSucursalRecibo")
         .AppendFormatLine("                                        AND CC.IdTipoComprobante = RC.IdTipoComprobanteRecibo")
         .AppendFormatLine("                                        AND CC.Letra = RC.LetraRecibo")
         .AppendFormatLine("                                        AND CC.CentroEmisor = RC.CentroEmisorRecibo")
         .AppendFormatLine("                                        AND CC.NumeroComprobante = RC.NumeroComprobanteRecibo")

         .AppendFormatLine("         LEFT JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine("         LEFT JOIN Clientes CCC ON CCC.IdCliente = CC.IdCliente")
         .AppendFormatLine("         CROSS JOIN ({0}) P", Ventas.GetQueryProductosParaRegistrarReparto())
         .AppendFormatLine("          LEFT JOIN RepartosComprobantesProductos RCP ON RCP.IdSucursal = RC.IdSucursal")
         .AppendFormatLine("                                                     AND RCP.IdReparto = RC.IdReparto")
         .AppendFormatLine("                                                     AND RCP.Orden = RC.Orden")
         .AppendFormatLine("                                                     AND RCP.IdProducto = P.IdProducto")

         .AppendFormatLine("         WHERE 1 = 1")
         .AppendFormatLine("           AND RC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("           AND RC.IdReparto = {0}", idReparto)

         .AppendFormatLine("       ) C_P")
         .AppendFormatLine(" PIVOT (MAX(C_P.PrecioVenta) FOR producto_precio IN ({0})) PV1", campo_pivot_precio.ToString().Trim(","c))
         .AppendFormatLine(" PIVOT (MAX(PV1.Cantidad) FOR producto_cantidad IN ({0})) PV2", campo_pivot_cantidad.ToString().Trim(","c))
         .AppendFormatLine(" PIVOT (MAX(PV2.CantidadCambio) FOR producto_cantidadCambio IN ({0})) PV3", campo_pivot_cantidadCambio.ToString().Trim(","c))
         .AppendFormatLine("")
         .AppendFormatLine(") T")
         .AppendFormatLine("  GROUP BY IdCliente, CodigoCliente, NombreCliente, Direccion, ImporteTotal, ImportePagado")

      End With

      Return GetDataTable(stb)
   End Function


   Public Function GetInfConsolidadPorModelo(dtProductos As DataTable,
                                             idSucursal As Integer,
                                             desde As Date,
                                             hasta As Date,
                                             IdVendedor As Integer,
                                             idCliente As Long,
                                             tipoComprobante As String,
                                             numeroReparto As Long,
                                             idFormasPago As Integer,
                                             idUsuario As String,
                                             idTransportista As Integer,
                                             idCategoria As Integer) As DataTable

      'Dim idRuta As Integer = rutas(0).IdRuta
      Dim stb = New StringBuilder()

      Dim campo_pivot_precio As StringBuilder = New StringBuilder()
      Dim campo_pivot_cantidad As StringBuilder = New StringBuilder()
      Dim campo_pivot_cantidadCambio As StringBuilder = New StringBuilder()
      Dim campo_sum As StringBuilder = New StringBuilder()
      For Each drCampos As DataRow In dtProductos.Rows
         campo_pivot_precio.AppendFormat("[{0}___precio],", drCampos("IdProducto"))
         campo_pivot_cantidad.AppendFormat("[{0}___cantidad],", drCampos("IdProducto"))
         campo_pivot_cantidadCambio.AppendFormat("[{0}___cantidadCambio],", drCampos("IdProducto"))

         campo_sum.AppendFormat(", SUM([{0}___precio]) [{0}___precio], SUM([{0}___cantidad]) [{0}___cantidad], SUM([{0}___cantidadCambio]) [{0}___cantidadCambio]", drCampos("IdProducto")).AppendLine()
      Next



      With stb
         .AppendFormatLine("SELECT IdCliente, CodigoCliente, NombreCliente, Direccion")
         .AppendFormatLine(campo_sum.ToString())
         .AppendFormatLine("     , CONVERT(decimal(12,2), ImporteTotal) ImporteTotal")
         .AppendFormatLine("     , CONVERT(decimal(12,2), ImportePagado) ImportePagado")
         .AppendFormatLine("     , NombreCategoria")
         .AppendFormatLine("  FROM (")
         .AppendFormatLine("  SELECT *")
         .AppendFormatLine("  FROM (SELECT ISNULL(C.IdCliente, CCC.IdCliente) IdCliente , ISNULL(C.CodigoCliente, CCC.CodigoCliente) CodigoCliente")
         .AppendFormatLine("             , ISNULL(C.NombreCliente, CCC.NombreCliente) NombreCliente, ISNULL(C.Direccion, CCC.Direccion) Direccion")
         .AppendFormatLine("             , P.IdProducto, P.NombreProducto")
         .AppendFormatLine("             , CONVERT(DECIMAL(14,2), RCP.PrecioConImp) PrecioVenta")
         .AppendFormatLine("             , CONVERT(DECIMAL(14,2), RCP.Cantidad) AS Cantidad")
         .AppendFormatLine("             , CONVERT(DECIMAL(14,2), RCP.CantidadCambio) AS CantidadCambio")
         .AppendFormatLine("             , P.IdProducto + '___precio'   producto_precio")
         .AppendFormatLine("             , P.IdProducto + '___cantidad' producto_cantidad")
         .AppendFormatLine("             , P.IdProducto + '___cantidadCambio' producto_cantidadCambio")
         .AppendFormatLine("             , V.ImporteTotal")
         .AppendFormatLine("             , CC.ImporteTotal * -1 ImportePagado")
         .AppendFormatLine("             , CG.NombreCategoria")
         '.AppendFormatLine("          FROM Clientes C")
         .AppendFormatLine("          FROM RepartosComprobantes RC")
         .AppendFormatLine("          LEFT JOIN Ventas V ON V.IdSucursal = RC.IdSucursal")
         .AppendFormatLine("                            AND V.IdTipoComprobante = RC.IdTipoComprobanteFact")
         .AppendFormatLine("                            AND V.Letra = RC.LetraFact")
         .AppendFormatLine("                            AND V.CentroEmisor = RC.CentroEmisorFact")
         .AppendFormatLine("                            AND V.NumeroComprobante = RC.NumeroComprobante")

         .AppendFormatLine("          LEFT JOIN CuentasCorrientes CC ON CC.IdSucursal = RC.IdSucursalRecibo")
         .AppendFormatLine("                                        AND CC.IdTipoComprobante = RC.IdTipoComprobanteRecibo")
         .AppendFormatLine("                                        AND CC.Letra = RC.LetraRecibo")
         .AppendFormatLine("                                        AND CC.CentroEmisor = RC.CentroEmisorRecibo")
         .AppendFormatLine("                                        AND CC.NumeroComprobante = RC.NumeroComprobanteRecibo")

         .AppendFormatLine("         LEFT JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendFormatLine("         LEFT JOIN Clientes CCC ON CCC.IdCliente = CC.IdCliente")
         .AppendFormatLine("      LEFT JOIN CategoriaS CG ON CG.IdCategoria = C.IdCategoria")
         .AppendFormatLine("         CROSS JOIN ({0}) P", Ventas.GetQueryProductosParaRegistrarReparto())
         .AppendFormatLine("          LEFT JOIN RepartosComprobantesProductos RCP ON RCP.IdSucursal = RC.IdSucursal")
         .AppendFormatLine("                                                     AND RCP.IdReparto = RC.IdReparto")
         .AppendFormatLine("                                                     AND RCP.Orden = RC.Orden")
         .AppendFormatLine("                                                     AND RCP.IdProducto = P.IdProducto")

         .AppendFormatLine("         WHERE 1 = 1")
         .AppendFormatLine("           AND RC.IdSucursal = {0}", idSucursal)

         If numeroReparto > 0 Then
            .AppendFormatLine("           AND RC.IdReparto = {0}", numeroReparto)
         End If
         .AppendLine("	  AND V.FechaEnvio >= '" & desde.ToString("yyyyMMdd HH:mm:ss") & "'")
         .AppendLine("	  AND V.FechaEnvio <= '" & hasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         If idCliente <> 0 Then
            .AppendLine("	 AND C.IdCliente = " & idCliente)
         End If

         If Not String.IsNullOrEmpty(tipoComprobante) Then
            .AppendLine("	 AND RC.IdTipoComprobanteFact= '" & tipoComprobante & "'")
         End If

         If idFormasPago > 0 Then
            .AppendLine("	 AND V.IdFormasPago = " & idFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendLine("	 AND V.Usuario = '" & idUsuario & "'")
         End If


         If idTransportista > 0 Then
            .AppendLine("	 AND V.IdTransportista = " & idTransportista)
         End If

         If IdVendedor > 0 Then
            .AppendFormat(" 		 AND V.IdVendedor = {0} ", IdVendedor)
         End If

         If idCategoria > 0 Then
            .AppendLine("   AND C.IdCategoria = " & idCategoria.ToString())
         End If


         .AppendFormatLine("       ) C_P")
         .AppendFormatLine(" PIVOT (MAX(C_P.PrecioVenta) FOR producto_precio IN ({0})) PV1", campo_pivot_precio.ToString().Trim(","c))
         .AppendFormatLine(" PIVOT (MAX(PV1.Cantidad) FOR producto_cantidad IN ({0})) PV2", campo_pivot_cantidad.ToString().Trim(","c))
         .AppendFormatLine(" PIVOT (MAX(PV2.CantidadCambio) FOR producto_cantidadCambio IN ({0})) PV3", campo_pivot_cantidadCambio.ToString().Trim(","c))
         .AppendFormatLine("")
         .AppendFormatLine(") T")
         .AppendFormatLine("  GROUP BY IdCliente, CodigoCliente, NombreCliente,NombreCategoria, Direccion, ImporteTotal, ImportePagado")

      End With

      Return GetDataTable(stb)
   End Function
   Public Sub Repartos_U_Estado(idSucursal As Integer, idReparto As Integer, idEstado As String, fechaActualizacion As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE Repartos")
         .AppendFormat("   SET {0} = '{1}'", Entidades.Reparto.Columnas.IdEstado.ToString(), idEstado)
         .AppendFormat("     , {0} = '{1}'", Entidades.Reparto.Columnas.FechaActualizacion.ToString(), fechaActualizacion)
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.Reparto.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormat("   AND {0} =  {1} ", Entidades.Reparto.Columnas.IdSucursal.ToString(), idSucursal)
      End With
      Execute(myQuery)
   End Sub
End Class