Public Class ContabilidadProcesos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub


#Region "VENTAS"

   Public Function ObtenerDatosVentas(idEmpresa As Integer, fdesde As Date, fhasta As Date, ConAsiento As Boolean, NumeroAsiento As Integer, top As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0} V.[IdSucursal]", If(top = 0, String.Empty, String.Format("TOP {0}", top)))
         .AppendLine("     , V.[IdTipoComprobante] ")
         .AppendLine("     , V.[Letra] ")
         .AppendLine("     , V.[CentroEmisor] ")
         .AppendLine("     , V.[NumeroComprobante] ")
         .AppendLine("     , V.[Fecha] ")
         .AppendLine("     , V.[SubTotal] ")
         .AppendLine("     , V.[DescuentoRecargo] ")
         .AppendLine("     , V.[ImporteTotal] ")
         .AppendLine("     , V.[ImporteBruto] ")
         .AppendLine("     , V.[DescuentoRecargoPorc] ")
         .AppendLine("     , V.[ImportePesos] ")
         .AppendLine("     , V.[ImporteTickets] ")
         .AppendLine("     , V.[ImporteTarjetas] ")
         .AppendLine("     , V.[ImporteCheques] ")
         .AppendLine("     , V.[TotalImpuestos] ")

         .AppendLine("     , TC.[Descripcion] ")
         .AppendLine("     , TC.[Tipo] ")
         .AppendLine("     , TC.[CoeficienteStock] ")
         .AppendLine("     , TC.[AfectaCaja]")

         .AppendLine("     , C.IdCliente")
         .AppendLine("     , C.CodigoCliente")
         .AppendLine("     , C.NombreCliente")

         .AppendLine("     , V.IdEjercicio ")
         .AppendLine("     , V.IdPlanCuenta ")
         .AppendLine("     , V.IdAsiento ")

         .AppendLine("     , CAT.IdEjercicioDefinitivo ")
         .AppendLine("     , CAT.IdPlanCuentaDefinitivo ")
         .AppendLine("     , CAT.IdAsientoDefinitivo ")


         .AppendLine("  FROM Ventas V")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante=V.IdTipoComprobante")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = V.IdCliente")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendLine("  LEFT JOIN ContabilidadAsientosTmp CAT ON CAT.IdEjercicio = V.IdEjercicio AND CAT.IdAsiento = V.IdAsiento AND CAT.IdPlanCuenta = V.IdPlanCuenta")
         .AppendLine(" WHERE (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')")
         '.AppendLine(" and V.Letra in ('A','B') ")
         .AppendFormatLine(" AND V.Fecha between '{0} 00:00:00' AND '{1} 23:59:59' ", fdesde.ToString("yyyyMMdd"), fhasta.ToString("yyyyMMdd"))

         ' si está en null es porque no se ha procesado, si tiene periodo ya se proceso automaticamente.
         .AppendFormatLine("  AND V.IdAsiento {0}", If(ConAsiento, "IS NOT NULL", "IS NULL"))

         If NumeroAsiento > 0 Then
            .AppendFormatLine("  AND V.IdAsiento = {0}", NumeroAsiento)
         End If

         .AppendLine(" AND TC.GeneraContabilidad = 1")

         .AppendFormatLine("  AND S.IdEmpresa = {0}", idEmpresa)

         .AppendLine(" ORDER BY V.Fecha ASC")

      End With

      Return GetDataTable(stb)
   End Function

   Public Sub MarcarRegistroProcesado(fila As Entidades.Venta,
                                      idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Ventas")
         .AppendFormatLine("   SET IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("     , IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("     , IdAsiento = {0}", idAsiento)
         .AppendFormatLine(" WHERE IdSucursal = {0}", fila.IdSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", fila.IdTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", fila.LetraComprobante)
         .AppendFormatLine("   AND CentroEmisor = {0}", fila.CentroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", fila.NumeroComprobante)
      End With
      Execute(myQuery)
   End Sub

   Public Sub MarcarCtaCteRegistroProcesado(fila As Entidades.Venta)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientes")
         .AppendFormatLine("   SET IdEjercicio = V.IdEjercicio")
         .AppendFormatLine("     , IdPlanCuenta = V.IdPlanCuenta")
         .AppendFormatLine("      ,IdAsiento = v.IdAsiento")
         .AppendFormatLine("  FROM CuentasCorrientes AS CC")
         .AppendFormatLine(" INNER JOIN Ventas AS V ON V.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("                       AND V.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("                       AND V.Letra = CC.Letra")
         .AppendFormatLine("                       AND V.CentroEmisor = CC.CentroEmisor")
         .AppendFormatLine("                       AND V.NumeroComprobante = CC.NumeroComprobante")
         .AppendFormatLine(" WHERE CC.IdSucursal = {0}", fila.IdSucursal)
         .AppendFormatLine("   AND CC.IdTipoComprobante = '{0}'", fila.IdTipoComprobante)
         .AppendFormatLine("   AND CC.Letra = '{0}'", fila.LetraComprobante)
         .AppendFormatLine("   AND CC.CentroEmisor = {0}", fila.CentroEmisor)
         .AppendFormatLine("   AND CC.NumeroComprobante = {0}", fila.NumeroComprobante)
      End With
      Execute(myQuery)
   End Sub

#End Region

#Region "CUENTA CORRIENTE CLIENTES"
   Public Function ObtenerDatosCtaCteClte(idEmpresa As Integer, fdesde As Date, fhasta As Date, ConAsiento As Boolean, NumeroAsiento As Integer, top As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0} CC.IdSucursal", If(top = 0, String.Empty, String.Format("TOP {0}", top)))
         .AppendLine("      ,CC.IdTipoComprobante")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor")
         .AppendLine("      ,CC.NumeroComprobante")
         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,CC.ImporteTotal")

         .AppendLine("      ,C.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")

         .AppendLine("      ,CC.IdEjercicio")
         .AppendLine("      ,CC.IdPlanCuenta")
         .AppendLine("      ,CC.IdAsiento")

         .AppendLine("      ,CAT.IdEjercicioDefinitivo")
         .AppendLine("      ,CAT.IdPlanCuentaDefinitivo")
         .AppendLine("      ,CAT.IdAsientoDefinitivo")

         .AppendLine("  FROM CuentasCorrientes CC")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CC.IdCliente")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = CC.IdSucursal")
         .AppendLine("  LEFT JOIN ContabilidadAsientosTmp CAT ON CAT.IdEjercicio = CC.IdEjercicio AND CAT.IdAsiento = CC.IdAsiento AND CAT.IdPlanCuenta = CC.IdPlanCuenta")
         .AppendLine(" WHERE (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO')")
         .AppendFormatLine("   AND CC.Fecha between '{0} 00:00:00' AND '{1} 23:59:59' ", fdesde.ToString("yyyyMMdd"), fhasta.ToString("yyyyMMdd"))

         ' si está en null es porque no se ha procesado, si tiene periodo ya se proceso automaticamente.
         .AppendFormatLine("  AND CC.IdAsiento {0}", If(ConAsiento, "IS NOT NULL", "IS NULL"))

         If NumeroAsiento > 0 Then
            .AppendFormatLine("  AND CC.IdAsiento = {0}", NumeroAsiento)
         End If

         .AppendLine("   AND TC.EsRecibo = 1")
         .AppendLine("   AND TC.GeneraContabilidad = 1")

         .AppendFormatLine("  AND S.IdEmpresa = {0}", idEmpresa)

         .AppendLine("   ORDER BY CC.Fecha ASC")
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub MarcarRegistroProcesado(fila As Entidades.CuentaCorriente,
                                      idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientes")
         .AppendFormatLine("   SET IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("     , IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("     , IdAsiento = {0}", idAsiento)
         .AppendFormatLine(" WHERE IdSucursal = {0}", fila.IdSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", fila.TipoComprobante.IdTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", fila.Letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", fila.CentroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", fila.NumeroComprobante)
      End With
      Execute(myQuery)
   End Sub

#End Region

#Region "COMPRAS"

   Public Function ObtenerDatosCompra(idEmpresa As Integer, fdesde As Date, fhasta As Date, ConAsiento As Boolean, NumeroAsiento As Integer, top As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0} C.IdSucursal", If(top = 0, String.Empty, String.Format("TOP {0}", top)))
         .AppendLine(" ,C.[IdTipoComprobante]")
         .AppendLine(" ,C.[Letra] ")
         .AppendLine(" ,C.[CentroEmisor]")
         .AppendLine(" ,C.[NumeroComprobante]")
         .AppendLine(" ,C.[Fecha]")
         .AppendLine(" ,C.[TotalNeto]")
         .AppendLine(" ,C.[DescuentoRecargo]")
         .AppendLine(" ,C.IdProveedor")
         .AppendLine(" ,C.[TotalIVA]")
         .AppendLine(" ,C.[ImporteTotal]")
         .AppendLine(" ,C.[PorcentajeIVA]")
         .AppendLine(" ,C.[TotalBruto] as Bruto")
         .AppendLine(" ,C.[DescuentoRecargoPorc]")
         .AppendLine(" ,C.[PercepcionIVA]")
         .AppendLine(" ,C.[PercepcionIB]")
         .AppendLine(" ,C.[PercepcionGanancias]")
         .AppendLine(" ,C.[PercepcionVarias]")
         .AppendLine(" ,C.[PeriodoFiscal]")

         .AppendLine(",TC.[Descripcion] ")
         .AppendLine(",TC.[Tipo] ")
         .AppendLine(",TC.[CoeficienteStock] ")
         .AppendLine(",TC.[AfectaCaja]")

         .AppendLine(",P.IdProveedor")
         .AppendLine(",P.CodigoProveedor")
         .AppendLine(",P.NombreProveedor")

         .AppendLine(" ,C.IdEjercicio")
         .AppendLine(" ,C.IdPlanCuenta")
         .AppendLine(" ,C.IdAsiento")

         .AppendLine(" ,CAT.IdEjercicioDefinitivo")
         .AppendLine(" ,CAT.IdPlanCuentaDefinitivo")
         .AppendLine(" ,CAT.IdAsientoDefinitivo")

         .AppendLine(" FROM Compras C")

         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         .AppendLine(" INNER JOIN Proveedores P ON P.IdProveedor = C.IdProveedor")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = C.IdSucursal")
         .AppendLine("  LEFT JOIN ContabilidadAsientosTmp CAT ON CAT.IdEjercicio = C.IdEjercicio AND CAT.IdAsiento = C.IdAsiento AND CAT.IdPlanCuenta = C.IdPlanCuenta")

         '.AppendLine(" where Letra in ('A','B', 'C') ")
         .AppendFormatLine(" where Fecha between '{0}' and '{1}'", ObtenerFecha(fdesde, False), ObtenerFecha(fhasta.Date.AddDays(1).AddSeconds(-1), True))
         ' si está en null es porque no se ha procesado, si tiene periodo ya se proceso automaticamente.

         .AppendFormatLine("  AND C.IdAsiento {0}", If(ConAsiento, "IS NOT NULL", "IS NULL"))

         If NumeroAsiento > 0 Then
            .AppendFormatLine("  AND C.IdAsiento = {0}", NumeroAsiento)
         End If

         .AppendLine(" and tc.GeneraContabilidad = 1")

         .AppendFormatLine("  AND S.IdEmpresa = {0}", idEmpresa)

         .AppendLine(" ORDER BY C.Fecha ASC")

      End With
      Return GetDataTable(stb)
   End Function

   Public Sub MarcarRegistroProcesado(fila As Entidades.Compra,
                                      idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE compras")
         .AppendFormatLine("   SET IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("     , IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("     , IdAsiento = {0}", idAsiento)
         .AppendFormatLine(" WHERE IdSucursal = {0}", fila.IdSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", fila.IdTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", fila.Letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", fila.CentroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", fila.NumeroComprobante)
         .AppendFormatLine("   AND IdProveedor = {0}", fila.Proveedor.IdProveedor)
      End With
      Execute(myQuery)
   End Sub

   Public Sub MarcarCtaCteRegistroProcesado(fila As Entidades.MovimientoStock)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesProv")
         .AppendFormatLine("   SET IdEjercicio = C.IdEjercicio")
         .AppendFormatLine("      ,IdPlanCuenta = C.IdPlanCuenta")
         .AppendFormatLine("      ,IdAsiento = C.IdAsiento")
         .AppendFormatLine("  FROM CuentasCorrientesProv AS CC")
         .AppendFormatLine(" INNER JOIN Compras AS C ON C.IdSucursal = CC.IdSucursal")
         .AppendFormatLine("                        AND C.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendFormatLine("                        AND C.Letra = CC.Letra")
         .AppendFormatLine("                        AND C.CentroEmisor = CC.CentroEmisor")
         .AppendFormatLine("                        AND C.NumeroComprobante = CC.NumeroComprobante")
         .AppendFormatLine("                        AND C.IdProveedor = CC.IdProveedor")
         .AppendFormatLine("  WHERE CC.IdSucursal = {0}", fila.Compra.IdSucursal)
         .AppendFormatLine("   AND CC.IdTipoComprobante = '{0}'", fila.Compra.TipoComprobante.IdTipoComprobante)
         .AppendFormatLine("   AND CC.Letra = '{0}'", fila.Compra.Letra)
         .AppendFormatLine("   AND CC.CentroEmisor = {0}", fila.Compra.CentroEmisor)
         .AppendFormatLine("   AND CC.NumeroComprobante = {0}", fila.Compra.NumeroComprobante)
         .AppendFormatLine("   AND CC.IdProveedor = {0}", fila.Compra.Proveedor.IdProveedor)
      End With
      Execute(myQuery)
   End Sub
#End Region

#Region "CUENTA CORRIENTE PROVEEDOR"
   Public Function ObtenerDatosCtaCteProv(idEmpresa As Integer, fdesde As Date, fhasta As Date, ConAsiento As Boolean, NumeroAsiento As Integer, top As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0} CC.IdSucursal", If(top = 0, String.Empty, String.Format("TOP {0}", top)))
         .AppendLine("      ,CC.IdTipoComprobante")
         .AppendLine("      ,CC.Letra")
         .AppendLine("      ,CC.CentroEmisor")
         .AppendLine("      ,CC.NumeroComprobante")
         .AppendLine("      ,CC.IdProveedor")
         .AppendLine("      ,CC.Fecha")
         .AppendLine("      ,CC.ImporteTotal")

         .AppendLine("      ,P.CodigoProveedor")
         .AppendLine("      ,P.NombreProveedor")

         .AppendLine("      ,CC.IdEjercicio")
         .AppendLine("      ,CC.IdPlanCuenta")
         .AppendLine("      ,CC.IdAsiento")

         .AppendLine("      ,CAT.IdEjercicioDefinitivo")
         .AppendLine("      ,CAT.IdPlanCuentaDefinitivo")
         .AppendLine("      ,CAT.IdAsientoDefinitivo")


         .AppendLine("  FROM CuentasCorrientesProv CC")
         .AppendLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = CC.IdTipoComprobante")
         .AppendLine(" INNER JOIN Proveedores P ON P.IdProveedor = CC.IdProveedor")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = CC.IdSucursal")
         .AppendLine("  LEFT JOIN ContabilidadAsientosTmp CAT ON CAT.IdEjercicio = CC.IdEjercicio AND CAT.IdAsiento = CC.IdAsiento AND CAT.IdPlanCuenta = CC.IdPlanCuenta")
         .AppendLine(" WHERE (CC.IdEstadoComprobante IS NULL OR CC.IdEstadoComprobante <> 'ANULADO')")
         .AppendFormatLine("   AND CC.Fecha between '{0} 00:00:00' AND '{1} 23:59:59' ", fdesde.ToString("yyyyMMdd"), fhasta.ToString("yyyyMMdd"))

         ' si está en null es porque no se ha procesado, si tiene periodo ya se proceso automaticamente.
         .AppendFormatLine("  AND CC.IdAsiento {0}", If(ConAsiento, "IS NOT NULL", "IS NULL"))

         If NumeroAsiento > 0 Then
            .AppendFormatLine("  AND CC.IdAsiento = {0}", NumeroAsiento)
         End If

         ' .AppendLine("   AND (CC.IdTipoComprobante = 'PAGO' OR CC.IdTipoComprobante = 'PAGOPROV') ")
         .AppendLine("   AND TC.EsRecibo = 'True'")

         .AppendLine("   AND TC.GeneraContabilidad = 1")

         .AppendFormatLine("  AND S.IdEmpresa = {0}", idEmpresa)

         .AppendLine(" ORDER BY CC.Fecha ASC")
      End With

      Return GetDataTable(stb)
   End Function

   Public Sub MarcarRegistroProcesado(fila As Entidades.CuentaCorrienteProv,
                                      idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CuentasCorrientesProv")
         .AppendFormatLine("   SET IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("     , IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("     , IdAsiento = {0}", idAsiento)
         .AppendFormatLine(" WHERE IdSucursal = {0}", fila.IdSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", fila.TipoComprobante.IdTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", fila.Letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", fila.CentroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", fila.NumeroComprobante)
         .AppendFormatLine("   AND IdProveedor = {0}", fila.Proveedor.IdProveedor)
      End With
      Execute(myQuery)
   End Sub

#End Region

#Region "COMUNES"
   Public Function GetCantRubrosVenta(oVentas As Entidades.Venta) As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      Dim cadenaIn As String = String.Empty

      For Each prod As Entidades.VentaProducto In oVentas.VentasProductos
         cadenaIn += "'" & prod.IdProducto.ToString & "',"
      Next

      With stb
         .Length = 0
         .AppendLine(" select count(distinct  cr.idRubro) as cant")
         .AppendLine(" from Rubros R,")
         .AppendLine(" ContabilidadCuentasRubros CR,")
         .AppendLine(" productos P")
         .AppendLine(" where ")
         .AppendLine(" p.IdProducto in (" & cadenaIn.Substring(0, cadenaIn.Length - 1) & ")")
         .AppendLine(" and p.IdRubro=r.IdRubro ")
         .AppendLine(" and r.IdRubro = cr.idRubro ")
         .AppendLine(" and cr.idplanCuenta = " & oVentas.TipoComprobante.IdPlanCuenta.ToString())
         .AppendLine(" and cr.tipo = 'VENTAS'")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("cant").ToString())
      End If

      Return 0

   End Function


   Public Function GetCantRubrosCompra(omov As Entidades.MovimientoStock, idplanCuenta As Integer) As Integer

      Dim stb As StringBuilder = New StringBuilder("")
      Dim cadenaIn As String = String.Empty

      For Each prod In omov.Productos
         cadenaIn += "'" & prod.ProductoSucursal.Producto.IdProducto.ToString & "',"
      Next

      With stb
         .Length = 0
         .AppendLine(" select count(distinct  cr.idRubro) as cant")
         .AppendLine(" from Rubros R,")
         .AppendLine(" ContabilidadCuentasRubros CR,")
         .AppendLine(" productos P")
         .AppendLine(" where ")
         .AppendLine(" p.IdProducto in (" & cadenaIn.Substring(0, cadenaIn.Length - 1) & ")")
         .AppendLine(" and p.IdRubro=r.IdRubro ")
         .AppendLine(" and r.IdRubro = cr.idRubro ")
         .AppendLine(" and cr.idplanCuenta = " & idplanCuenta)
         .AppendLine(" and cr.tipo = 'COMPRAS'")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("cant").ToString())
      End If

      Return 0

   End Function


   Public Function GetCantRubrosProducto(idplanCuenta As Integer,
                                         tipomov As String,
                                         idProducto As Integer) As Integer

      Dim stb = New StringBuilder()
      Dim cadenaIn As String = String.Empty

      With stb
         .AppendLine(" select count(distinct  cr.idRubro) as cant")
         .AppendLine(" from Rubros R,")
         .AppendLine(" ContabilidadCuentasRubros CR,")
         .AppendLine(" productos P")
         .AppendLine(" where ")
         .AppendLine(" p.IdProducto =" & idProducto.ToString)
         .AppendLine(" and p.IdRubro=r.IdRubro ")
         .AppendLine(" and r.IdRubro = cr.idRubro ")
         .AppendLine(" and cr.idplanCuenta = " & idplanCuenta.ToString)
         .AppendLine(" and cr.tipo = '" & tipomov & "'")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("cant").ToString())
      End If

      Return 0

   End Function



   Public Function GetRubroVenta(oVentas As Entidades.Venta) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      Dim cadenaIn As String = String.Empty

      For Each prod As Entidades.VentaProducto In oVentas.VentasProductos
         cadenaIn += "'" & prod.IdProducto.ToString & "',"
      Next

      With stb
         .Length = 0
         .Append(" select ")
         .Append("	cr.tipo,")
         .Append("	cr.IdPlanCuenta, ")
         .Append("	cr.idRubro,")
         .Append("	p.IdProducto,")
         .Append("	p.NombreProducto,")
         '.Append("	cr.debe,")
         '.Append("	cr.haber,")
         '.Append("	cr.campo,")
         .Append("	cr.IdCuenta,")
         .Append("	cc.NombreCuenta,")
         .Append("	0 as debeValor, ")
         .Append("	0 as haberValor ")
         .Append("	from ContabilidadCuentasRubros CR")
         .Append("	LEFT JOIN Productos P ON P.IdRubro=CR.IdRubro")
         .Append("	LEFT JOIN Rubros R ON CR.IdRubro = R.IdRubro ")
         .Append("	LEFT JOIN ContabilidadCuentas CC ON cr.IdCuenta=cc.IdCuenta")
         .Append(" where ")
         .AppendFormat(" p.IdProducto in ({0})", cadenaIn.Substring(0, cadenaIn.Length - 1))
         .AppendFormat(" and cr.idplanCuenta = {0}", oVentas.TipoComprobante.IdPlanCuenta)
         .Append("  and Tipo IN ('VENTAS', 'STOCK')")
      End With

      Return GetDataTable(stb)

   End Function


   Public Function GetRubroCompras(omov As Entidades.MovimientoStock, idplanCuenta As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      Dim cadenaIn As String = String.Empty

      For Each prod In omov.Compra.ComprasProductos
         cadenaIn += "'" & prod.ProductoSucursal.Producto.IdProducto.ToString & "',"
      Next


      With stb
         .Length = 0
         .AppendLine(" select cr.tipo,cr.IdPlanCuenta, cr.idRubro,p.IdProducto,p.NombreProducto")
         '.AppendLine(" ,cr.debe,cr.haber,cr.campo")
         .AppendLine(" ,cr.IdCuenta,cc.NombreCuenta")
         .AppendLine(" ,0 as debeValor, 0 as haberValor ")
         .AppendLine(" from ")
         .AppendLine(" Rubros R,")
         .AppendLine(" ContabilidadCuentasRubros CR,")
         .AppendLine(" productos P,")
         .AppendLine(" ContabilidadCuentas CC")
         .AppendLine(" where ")
         .AppendLine(" p.IdProducto in (" & cadenaIn.Substring(0, cadenaIn.Length - 1) & ")")
         .AppendLine(" and p.IdRubro=r.IdRubro ")
         .AppendLine(" and r.IdRubro = cr.idRubro ")
         .AppendLine(" and cr.idplanCuenta = " & idplanCuenta)
         .AppendLine(" and cr.IdCuenta=cc.IdCuenta ")
         .AppendLine(" and Tipo = 'COMPRAS'")

      End With

      Return GetDataTable(stb)

   End Function


   Public Function GetRubroProducto(idproducto As Integer, idplanCuenta As Integer, mismoRubro As Boolean) As DataTable

      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" select cr.tipo,cr.IdPlanCuenta, cr.idRubro,p.IdProducto,p.NombreProducto")
         '.AppendLine(" ,cr.debe,cr.haber,cr.campo")
         .AppendLine(" ,cr.IdCuenta,cc.NombreCuenta")
         .AppendLine(" ,0 as debeValor, 0 as haberValor ")
         .AppendLine(" from ")
         .AppendLine(" Rubros R,")
         .AppendLine(" ContabilidadCuentasRubros CR,")
         .AppendLine(" productos P,")
         .AppendLine(" ContabilidadCuentas CC")
         .AppendLine(" where ")
         .AppendLine(" p.IdProducto =" & idproducto)
         .AppendLine(" and p.IdRubro=r.IdRubro ")
         .AppendLine(" and r.IdRubro = cr.idRubro ")
         .AppendLine(" and cr.idplanCuenta = " & idplanCuenta)
         .AppendLine(" and cr.IdCuenta=cc.IdCuenta ")
         .AppendLine(" and Tipo = 'AJUSTE'")

      End With

      Return GetDataTable(stb)

   End Function


   Public Function GetPrecioCostoProductos(idSucursal As Integer, idProducto As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine(" SELECT  [IdProducto],[PrecioCosto]")
         .AppendLine(" FROM [ProductosSucursales] ")
         .AppendLine(" WHERE IdProducto= " & idProducto.ToString)
         .AppendLine(" and IdSucursal=" & idSucursal.ToString)
      End With

      Return GetDataTable(stb)

   End Function

   Public Function getPlanCtaxDoc(idTipoComprobante As String) As Integer
      Dim stb = New StringBuilder()
      Dim dtaux As DataTable
      With stb
         .AppendLine(" SELECT  isnull([IdPlanCuenta],1) as idplancuenta ")
         .AppendLine(" FROM [TiposComprobantes] ")
         .AppendLine(" WHERE [IdTipoComprobante]= '" & idTipoComprobante & "'")
      End With

      dtaux = Me.GetDataTable(stb.ToString())
      If dtaux.Rows.Count = 0 Then Return 1

      Return CInt(dtaux.Rows(0)("idPlanCuenta"))
   End Function

   Public Function getPlanCtaxMovimiento(idTipoMov As String) As Integer
      Dim stb = New StringBuilder()
      Dim dtaux As DataTable
      With stb
         .AppendLine("   SELECT isnull([IdPlanCuenta],1) as idplancuenta ")
         .AppendLine(" FROM [TiposMovimientos] ")
         .AppendLine(" WHERE [idtipomovimiento]= '" & idTipoMov & "'")
      End With

      dtaux = Me.GetDataTable(stb.ToString())
      If dtaux.Rows.Count = 0 Then Return 1

      Return CInt(dtaux.Rows(0)("idPlanCuenta"))
   End Function


   Public Function getIdAsientoModif(tipoproceso As String, descAsiento As String) As Integer

      Dim stb = New StringBuilder()
      Dim dtaux As DataTable
      Dim iAuxIdAsiento As Integer

      With stb
         .AppendLine(" SELECT [idAsiento] ")
         .AppendLine(" FROM [ContabilidadAsientosTmp] ")
         .AppendLine(" WHERE [SubsiAsiento] = '" & LTrim(RTrim(tipoproceso)) & "'")
         .AppendLine(" and [nombreAsiento] = '" & LTrim(RTrim(descAsiento)) & "'")
      End With


      dtaux = Me.GetDataTable(stb.ToString())
      If dtaux.Rows.Count <> 0 Then
         iAuxIdAsiento = CInt(dtaux.Rows(0)!idAsiento)
      Else
         iAuxIdAsiento = 0
      End If

      Return iAuxIdAsiento

   End Function

   Public Function GetAsientoRefundicion(idEjercicio As Int32, sucursales As List(Of Integer), idPlanCuenta As Integer) As DataTable

      Dim stb = New StringBuilder()

      With stb
         .AppendFormatLine(" select cac.IdCuenta, cac.IdCentroCosto, ccc.NombreCentroCosto, cc.NombreCuenta, sum(cac.debe) Debe, sum(cac.Haber) Haber ")
         .AppendFormatLine(" , '' as IdTipoReferencia, '' as Referencia ")
         .AppendFormatLine(" from contabilidadasientos ca")
         .AppendFormatLine(" left join contabilidadasientoscuentas cac on ca.idasiento = cac.idasiento ")
         .AppendFormatLine(" left join contabilidadcuentas cc on cac.idcuenta = cc.idcuenta")
         .AppendFormatLine(" left join ContabilidadCentrosCostos ccc on cac.IdCentroCosto = ccc.IdCentroCosto")
         .AppendFormatLine(" where cc.TipoCuenta = 'RESULTADO'")
         .AppendFormatLine(" and ca.IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine(" and ca.IdSucursal IN (")
         For Each en As Integer In sucursales
            .AppendFormat("{0},", en)
         Next
         .Remove(.Length - 1, 1)
         .Append(")")
         .AppendFormatLine(" and ca.IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine(" group by cac.IdCuenta, cac.IdCentroCosto, ccc.NombreCentroCosto, cc.NombreCuenta")
      End With


      Return Me.GetDataTable(stb.ToString())

   End Function

#End Region

#Region "CAJA"
   Public Sub MarcarRegistroProcesado(fila As Entidades.CajaDetalles,
                                      idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CajasDetalle")
         .AppendFormatLine("   SET IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("     , IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("     , IdAsiento = {0}", idAsiento)
         .AppendFormatLine(" WHERE IdSucursal = {0}", fila.IdSucursal)
         .AppendFormatLine("   AND IdCaja = {0}", fila.IdCaja)
         .AppendFormatLine("   AND NumeroPlanilla = {0}", fila.NumeroPlanilla)
         .AppendFormatLine("   AND NumeroMovimiento = {0}", fila.NumeroMovimiento)
      End With
      Execute(myQuery)
   End Sub

   Public Function GetPlanCtaXCaja(idSucursal As Integer, idCaja As Integer, numeroPlanilla As Integer, numeroMovimiento As Integer) As Integer
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ISNULL([IdPlanCuenta],1) AS idplancuenta ")
         .AppendFormatLine("  FROM CajasNombres")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdCaja = {0}", idCaja)
      End With

      Dim dtaux = GetDataTable(stb)
      If dtaux.Rows.Count = 0 Then Return 1

      Return dtaux.Rows(0).Field(Of Integer)("idPlanCuenta")
   End Function


   ''Public Function GetCuentaContableCuentadeCaja(idCuentaCaja As Integer) As DataTable
   ''   Dim stb = New StringBuilder()
   ''   Dim dtaux As DataTable
   ''   With stb
   ''      .AppendLine(" SELECT [idCuentaContable] ")
   ''      .AppendLine(" FROM [CuentasDeCajas] ")
   ''      .AppendLine(" WHERE [IdCuentaCaja]= " & idCuentaCaja.ToString)
   ''   End With

   ''   dtaux = Me.GetDataTable(stb.ToString())
   ''   Return dtaux

   ''End Function

   ''Public Function GetCuentaContableCaja(idSucursal As Integer, idCaja As Integer) As DataTable
   ''   Dim stb = New StringBuilder()
   ''   Dim dtaux As DataTable
   ''   With stb
   ''      .AppendLine(" SELECT [idCuentaContable] ")
   ''      .AppendLine(" FROM [CajasNombres] ")
   ''      .AppendLine(" WHERE [idSucursal]= " & idSucursal.ToString)
   ''      .AppendLine(" and [idCaja] = " & idCaja.ToString)
   ''   End With

   ''   dtaux = Me.GetDataTable(stb.ToString())
   ''   Return dtaux

   ''End Function

   ''Public Function GetCuentaMedioPago(IdMedioPago As Integer) As DataTable
   ''   Dim stb = New StringBuilder()
   ''   Dim dtaux As DataTable
   ''   With stb
   ''      .AppendLine(" Select IdMediodePago,c.Idcuenta ")
   ''      .AppendLine(" from mediosdepago m left join contabilidadcuentas c on m.idcuenta = c.idcuenta ")
   ''      .AppendLine(" where IdMediodePago = " & IdMedioPago)

   ''   End With

   ''   dtaux = Me.GetDataTable(stb.ToString())
   ''   If dtaux.Rows.Count = 0 OrElse String.IsNullOrEmpty(dtaux.Rows(0)("IdCuenta").ToString()) Then
   ''      Throw New Exception(String.Format("Falta cargar la cuenta contable en el medio de pago {0}.", IdMedioPago.ToString()))
   ''   End If
   ''   Return dtaux

   ''End Function

   ''Public Function ObtenerCuentaCaja(idCuentaCaja As String) As DataTable
   ''   Dim stb = New StringBuilder()

   ''   With stb
   ''      .AppendLine("SELECT cd.idCuentaDebe, cc.NombreCuenta as nombreDebe, ")
   ''      .AppendLine(" cd.idcuentaHaber,  ")
   ''      .AppendLine(" (select cc.NombreCuenta from CuentasDeCajas cd, ")
   ''      .AppendLine(" ContabilidadCuentas cc where cd.IdCuentaCaja = " & idCuentaCaja)
   ''      .AppendLine(" and cd.idCuentahaber = cc.IdCuenta) as nombreHaber ")

   ''      .AppendLine("  FROM ")
   ''      .AppendLine(" CuentasDeCajas cd, ")
   ''      .AppendLine(" ContabilidadCuentas cc ")

   ''      .AppendLine("   where cd.IdCuentaCaja= " & idCuentaCaja)
   ''      .AppendLine(" and cd.idCuentaDebe = cc.IdCuenta ")
   ''   End With

   ''   Return GetDataTable(stb)
   ''End Function

   ''Public Function ObtenerDatosDetalleCaja() As DataTable
   ''   Dim stb = New StringBuilder()
   ''   With stb
   ''      .AppendLine("SELECT * ")
   ''      .AppendLine("  FROM CajasDetalle ")
   ''      .AppendLine(" WHERE 1=2")
   ''   End With
   ''   Return GetDataTable(stb)
   ''End Function

   Public Function ObtenerDatosCaja(idEmpresa As Integer, fdesde As Date, fhasta As Date, ConAsiento As Boolean, NumeroAsiento As Integer, top As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0} CD.IdSucursal", If(top = 0, String.Empty, String.Format("TOP {0}", top)))
         .AppendLine(" ,CD.IdCaja ")
         .AppendLine(" ,CN.NombreCaja")
         .AppendLine(" ,CD.NumeroPlanilla ")
         .AppendLine(" ,CD.NumeroMovimiento ")
         .AppendLine(" ,CD.FechaMovimiento ")
         .AppendLine(" ,CD.IdTipoMovimiento ")
         .AppendLine(" ,CC.IdCuentaCaja ")
         .AppendLine(" ,CC.NombreCuentaCaja")
         .AppendLine(" ,CD.ImportePesos ")
         .AppendLine(" ,CD.ImporteDolares ")
         .AppendLine(" ,CD.ImporteEuros ")
         .AppendLine(" ,CD.ImporteCheques ")
         .AppendLine(" ,CD.ImporteTarjetas ")
         .AppendLine(" ,CD.Observacion ")
         .AppendLine(" ,CD.EsModificable ")
         .AppendLine(" ,CD.ImporteTickets ")
         .AppendLine(" ,CD.IdUsuario ")
         .AppendLine(" ,CD.IdEjercicio ")
         .AppendLine(" ,CD.IdPlanCuenta ")
         .AppendLine(" ,CD.IdAsiento ")

         .AppendLine(" ,CAT.IdEjercicioDefinitivo ")
         .AppendLine(" ,CAT.IdPlanCuentaDefinitivo ")
         .AppendLine(" ,CAT.IdAsientoDefinitivo ")


         .AppendLine(" from CajasDetalle CD")
         .AppendLine(" INNER JOIN CuentasDeCajas CC ON CC.IdCuentaCaja = CD.IdCuentaCaja")
         .AppendLine(" INNER JOIN CajasNombres CN ON CN.IdCaja = CD.IdCaja AND CN.IdSucursal = CD.IdSucursal")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = CD.IdSucursal")
         .AppendLine("  LEFT JOIN ContabilidadAsientosTmp CAT ON CAT.IdEjercicio = CD.IdEjercicio AND CAT.IdPlanCuenta = CD.IdPlanCuenta AND CAT.IdAsiento = CD.IdAsiento")
         .AppendLine(" WHERE CD.GeneraContabilidad = 1 ")
         .AppendFormatLine(" and CD.FechaMovimiento between '{0} 00:00:00' AND '{1} 23:59:59' ", fdesde.ToString("yyyyMMdd"), fhasta.ToString("yyyyMMdd"))
         .AppendFormatLine(" AND CC.GeneraContabilidad = 'True'")

         .AppendFormatLine("  AND CD.IdAsiento {0}", If(ConAsiento, "IS NOT NULL", "IS NULL"))

         If NumeroAsiento > 0 Then
            .AppendFormatLine("  AND CD.IdAsiento = {0}", NumeroAsiento)
         End If

         .AppendFormatLine("  AND S.IdEmpresa = {0}", idEmpresa)

         .AppendLine(" ORDER BY CD.FechaMovimiento ASC")
      End With

      Return GetDataTable(stb)
   End Function

#End Region

#Region "BANCOS"
   Public Sub MarcarRegistroProcesado(fila As Entidades.LibroBanco,
                                      idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE LibrosBancos")
         .AppendFormatLine("   SET IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("     , IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("     , IdAsiento = {0}", idAsiento)
         .AppendFormatLine(" WHERE IdSucursal = {0}", fila.IdSucursal)
         .AppendFormatLine("   AND IdCuentaBancaria = '{0}'", fila.IdCuentaBancaria)
         .AppendFormatLine("   AND NumeroMovimiento = '{0}'", fila.NumeroMovimiento)
      End With
      Execute(myQuery)
   End Sub

   Public Function ObtenerDatosLibroBanco(idEmpresa As Integer, fDesde As Date, fHasta As Date, ConAsiento As Boolean, NumeroAsiento As Integer, top As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0} LB.*, CB.NombreCuenta", If(top = 0, String.Empty, String.Format("TOP {0}", top)))

         .AppendLine(" ,CAT.IdEjercicioDefinitivo ")
         .AppendLine(" ,CAT.IdPlanCuentaDefinitivo ")
         .AppendLine(" ,CAT.IdAsientoDefinitivo ")

         .AppendLine("  FROM LibrosBancos AS LB")
         .AppendLine(" INNER JOIN CuentasBancarias AS CB ON CB.IdCuentaBancaria = LB.IdCuentaBancaria")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = LB.IdSucursal")
         .AppendLine("  LEFT JOIN ContabilidadAsientosTmp CAT ON CAT.IdEjercicio = LB.IdEjercicio AND CAT.IdPlanCuenta = LB.IdPlanCuenta AND CAT.IdAsiento = LB.IdAsiento")
         .AppendLine(" WHERE GeneraContabilidad = 1")
         .AppendFormatLine(" AND FechaMovimiento between '{0} 00:00:00' AND '{1} 23:59:59' ", fDesde.ToString("yyyyMMdd"), fHasta.ToString("yyyyMMdd"))

         ' si está en null es porque no se ha procesado, si tiene periodo ya se proceso automaticamente.
         .AppendFormatLine("  AND LB.IdAsiento {0}", If(ConAsiento, "IS NOT NULL", "IS NULL"))

         If NumeroAsiento > 0 Then
            .AppendFormatLine("  AND LB.IdAsiento = {0}", NumeroAsiento)
         End If

         .AppendLine(" AND Conciliado = 'True'")   'Obligatorio si usa contabilidad.

         .AppendFormatLine("  AND S.IdEmpresa = {0}", idEmpresa)

         .AppendLine(" ORDER BY FechaAplicado ASC")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPlanCtaXCtaBan(idCuentaBancaria As Integer) As Integer
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ISNULL([IdPlanCuenta],1) AS idplancuenta ")
         .AppendFormatLine("  FROM [CuentasBancarias] cb ")
         .AppendFormatLine(" WHERE Cb.IdCuentaBancaria = {0}", idCuentaBancaria)

      End With

      Dim dtaux = GetDataTable(stb)
      If dtaux.Rows.Count = 0 Then Return 1
      Return dtaux.Rows(0).Field(Of Integer)("idPlanCuenta")
   End Function

   ''Public Function GetCuentaContableCtaBan(idCuentabanco As Integer) As DataTable
   ''   Dim stb = New StringBuilder()
   ''   Dim dtaux As DataTable
   ''   With stb
   ''      .AppendLine(" SELECT [idCuentaContable] ")
   ''      .AppendLine(" FROM [CuentasBancarias] ")
   ''      .AppendLine(" where IdCuentaBancaria = " & idCuentabanco.ToString)

   ''   End With

   ''   dtaux = Me.GetDataTable(stb.ToString())
   ''   Return dtaux
   ''End Function

   ''Public Function GetCuentaContableCuentasdeBanco(idCuentabanco As Integer) As DataTable
   ''   Dim stb = New StringBuilder()
   ''   Dim dtaux As DataTable
   ''   With stb
   ''      .AppendLine(" SELECT [idCuentaContable]")
   ''      .AppendLine(" FROM [CuentasBancos] ")
   ''      .AppendLine(" where idCuentabanco = " & idCuentabanco.ToString)

   ''   End With

   ''   dtaux = Me.GetDataTable(stb.ToString())
   ''   Return dtaux
   ''End Function
#End Region

#Region "DEPOSITOS"
   Public Function ObtenerDatosDepositosBancarios(idEmpresa As Integer, fDesde As Date, fHasta As Date, ConAsiento As Boolean, NumeroAsiento As Integer, top As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT {0} D.*, CB.NombreCuenta ", If(top = 0, String.Empty, String.Format("TOP {0}", top)))

         .AppendLine(" ,CAT.IdEjercicioDefinitivo ")
         .AppendLine(" ,CAT.IdPlanCuentaDefinitivo ")
         .AppendLine(" ,CAT.IdAsientoDefinitivo ")

         .AppendFormat("  FROM Depositos AS D ").AppendLine()
         .AppendLine(" INNER JOIN CuentasBancarias AS CB ON CB.IdCuentaBancaria = D.IdCuentaBancaria")
         .AppendLine(" INNER JOIN Sucursales S ON S.IdSucursal = D.IdSucursal")
         .AppendLine("  LEFT JOIN ContabilidadAsientosTmp CAT ON CAT.IdEjercicio = D.IdEjercicio AND CAT.IdPlanCuenta = D.IdPlanCuenta AND CAT.IdAsiento = D.IdAsiento")
         .AppendFormatLine(" WHERE D.Fecha BETWEEN '{0} 00:00:00' AND '{1} 23:59:59' ", fDesde.ToString("yyyyMMdd"), fHasta.ToString("yyyyMMdd"))

         ' si está en null es porque no se ha procesado, si tiene periodo ya se proceso automaticamente.
         .AppendFormatLine("  AND D.IdAsiento {0}", If(ConAsiento, "IS NOT NULL", "IS NULL"))

         If NumeroAsiento > 0 Then
            .AppendFormatLine("  AND D.IdAsiento = {0}", NumeroAsiento)
         End If

         .AppendFormatLine("   AND (D.IdEstado IS NULL OR D.IdEstado <> 'ANULADO')")
         '.AppendLine(" ORDER BY D.Fecha ASC") 'Lautaro: ver si es la fecha del registro o la de la aplicación.

         .AppendFormatLine("  AND S.IdEmpresa = {0}", idEmpresa)

         .AppendLine(" ORDER BY D.FechaAplicado ASC") 'Lautaro: ver si es la fecha del registro o la de la aplicación.
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub MarcarRegistroProcesado(fila As Entidades.Deposito,
                                      idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE Depositos")
         .AppendFormatLine("   SET IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("     , IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("     , IdAsiento = {0}", idAsiento)
         .AppendFormatLine(" WHERE IdSucursal = {0}", fila.IdSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", fila.TipoComprobante.IdTipoComprobante)
         .AppendFormatLine("   AND NumeroDeposito = {0}", fila.NumeroDeposito)
      End With
      Execute(myQuery)
   End Sub
#End Region


   Public Function ObtenerDatosTmp(fdesde As Date, fhasta As Date, tipo As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine(" SELECT [IdPlanCuenta] ,[IdAsiento] ,[NombreAsiento]")
         .AppendLine("       ,[FechaAsiento] ,[IdTipoDoc] ,[IdEjercicio]")
         .AppendLine("       ,[IdSucursal] ,[SubsiAsiento]")
         .AppendLine("       ,[IdEjercicioDefinitivo],[IdPlanCuentaDefinitivo],[IdAsientoDefinitivo]")
         .AppendLine(" FROM [ContabilidadAsientosTmp]")
         .AppendLine(" WHERE ")
         .AppendFormatLine(" FechaAsiento between '{0} 00:00:00' and '{1} 23:59:59'", fdesde.ToString("yyyyMMdd"), fhasta.ToString("yyyyMMdd"))
         .AppendFormatLine(" AND SubsiAsiento = '{0}'  AND isnull(IdAsientoDefinitivo,0) = 0 ", tipo)
      End With

      Return GetDataTable(stb)
   End Function

   Public Function ObtenerDatosDetalleTmp(fila As DataRow) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT CA.IdPlanCuenta")
         .AppendLine("     , CA.IdAsiento")
         .AppendLine("     , CA.IdCuenta")
         .AppendLine("     , CC.NombreCuenta")
         .AppendLine("     , CA.IdRenglon")
         .AppendLine("     , CA.Debe")
         .AppendLine("     , CA.Haber")
         .AppendLine("     , CA.IdTipoReferencia")
         .AppendLine("     , CA.Referencia")
         .AppendLine("     , CA.IdCentroCosto")
         .AppendLine("  FROM ContabilidadAsientosCuentasTmp CA")
         .AppendLine(" INNER JOIN ContabilidadCuentas CC ON CA.IdCuenta = CC.IdCuenta")
         .AppendFormatLine(" WHERE CA.IdEjercicio = {0}", fila("IdEjercicio"))
         .AppendFormatLine("   AND CA.IdPlanCuenta = {0}", fila("idplanCuenta"))
         .AppendFormatLine("   AND CA.IdAsiento = {0}", fila("idAsiento"))
         .AppendLine(" ORDER BY IdRenglon")

      End With

      Return GetDataTable(stb)
   End Function

   Public Sub AnularAsiento(idEjercicio As Integer, idPlanCuenta As Integer, idCuenta As Integer, fecha As Date, ejercicio As Integer, idAsiento As Integer)
      Dim stb = New StringBuilder()

      With stb
         .AppendLine("INSERT INTO ContabilidadAsientosTmp")
         .AppendLine("           (IdPlanCuenta, IdAsiento, NombreAsiento, FechaAsiento, IdTipoDoc, IdEjercicio, IdSucursal, SubsiAsiento, IdEjercicioDefinitivo, IdPlanCuentaDefinitivo, IdAsientoDefinitivo)")
         .AppendLine("SELECT IdPlanCuenta,")
         '.AppendFormatLine("       (SELECT MAX(Maximo) + 1 FROM vw_ContabilidadAsientosIDMaximo WHERE IdEjercicio = {1} AND IdPlanCuenta = {0}) AS IdAsiento,", idPlanCuenta, idEjercicio)

         .AppendFormatLine("       {0} AS IdAsiento,", idAsiento)

         .AppendLine("       LEFT('AN-' + NombreAsiento,100) AS NombreAsiento,")
         .AppendFormatLine("     '{0}',", fecha.ToString("yyyyMMdd"))
         .AppendLine("       IdTipoDoc,")
         .AppendFormatLine("     {0},", ejercicio)
         .AppendLine("       IdSucursal,")
         .AppendLine("       SubsiAsiento,")
         .AppendLine("       NULL,")
         .AppendLine("       NULL,")
         .AppendLine("       NULL")
         .AppendLine("  FROM ContabilidadAsientosTmp")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND IdAsiento = {0}", idCuenta)
      End With

      Execute(stb)
   End Sub

   Public Sub AnularAsientoCuenta(idEjercicio As Integer, idPlanCuenta As Integer, idCuenta As Integer, ejercicio As Integer, idAsiento As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ContabilidadAsientosCuentasTmp")
         .AppendLine("           (IdEjercicio, IdPlanCuenta, IdAsiento, IdCuenta, IdRenglon, Debe, Haber, IdTipoReferencia, Referencia)")
         .AppendFormatLine("SELECT {0} AS IdEjercicio,", ejercicio)
         .AppendLine("       IdPlanCuenta,")
         '.AppendFormatLine("       (SELECT MAX(IdAsiento) FROM ContabilidadAsientosTmp WHERE IdEjercicio = {1} AND IdPlanCuenta = {0}) AS IdAsiento,", idPlanCuenta, idEjercicio)

         .AppendFormatLine("       {0} AS IdAsiento,", idAsiento)

         .AppendLine("       IdCuenta,")
         .AppendLine("       IdRenglon,")
         .AppendLine("       Debe * -1,")
         .AppendLine("       Haber * -1")
         .AppendLine("      ,IdTipoReferencia")
         .AppendLine("      ,Referencia")
         .AppendLine("  FROM ContabilidadAsientosCuentasTmp")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND IdAsiento = {0}", idCuenta)
      End With

      Execute(stb)
   End Sub

   Public Sub DesvinculaGestionAsiento(modulo As String, idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE {0}", modulo)
         .AppendFormatLine("   SET IdAsiento = NULL")
         .AppendFormatLine("     , IdEjercicio = NULL")
         .AppendFormatLine("     , IdPlanCuenta = NULL")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND IdAsiento = {0}", idAsiento)
      End With
      Execute(stb)
   End Sub

   Public Function GetAsientosAjusteInflacionPorPeriodo(idPlanCuenta As Integer,
                                                        idEjercicio As Integer,
                                                        sucursales As List(Of Integer)) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("select c.IdSucursal, c.nombreasiento")
         .AppendFormatLine("	, c.FechaAsiento, d.IdCuenta")
         .AppendFormatLine("	, cu.NombreCuenta, d.IdCentroCosto, cc.NombreCentroCosto, d.Debe, d.Haber")
         .AppendFormatLine("  from ContabilidadAsientos c")
         '---
         .AppendFormatLine("	left join ContabilidadAsientosCuentas d ON c.IdEjercicio = d.IdEjercicio")
         .AppendFormatLine("		and c.IdPlanCuenta=d.IdPlanCuenta and c.IdAsiento=d.IdAsiento")
         .AppendFormatLine("	left join ContabilidadCuentas cu ON d.idcuenta=cu.idcuenta")
         .AppendFormatLine("	left join ContabilidadCentrosCostos cc ON cc.IdCentroCosto = d.IdCentroCosto")
         '---
         .AppendFormatLine(" where c.IdEjercicio = {0} ", idEjercicio)
         .AppendFormatLine("		and d.IdPlanCuenta= {0}", idPlanCuenta)
         .AppendFormatLine("		and cu.AjustaPorInflacion=1")
         .AppendFormatLine("		and c.NombreAsiento <> 'APERTURA DEL EJERCICIO'")
         .Append("		and c.IdSucursal IN (")
         For Each en As Integer In sucursales
            .AppendFormat("{0},", en)
         Next
         .Remove(.Length - 1, 1)
         .AppendFormatLine(")")
         '---
         .AppendFormatLine(" ORDER BY c.FechaAsiento, d.IdCuenta")

      End With

      Return GetDataTable(stb)
   End Function

End Class