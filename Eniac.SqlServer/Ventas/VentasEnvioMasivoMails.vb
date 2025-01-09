Imports Eniac.Entidades
Public Class VentasEnvioMasivoMails
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetEnvioMasivoMail(sucursales As Entidades.Sucursal(),
                                      fechaDesde As DateTime?, fechaHasta As DateTime?, modoFechas As String,
                                      idCategoria As Integer?, idZonaGeografica As String,
                                      idCliente As Long?, desdeNombreCliente As String,
                                      configMail As String, idcobrador As Integer,
                                      correoEnviado As Entidades.Publicos.SiNoTodos,
                                      listaComprobantes As Entidades.TipoComprobante(),
                                      operador As Entidades.Publicos.OperadoresRelacionales?,
                                      saldo As Decimal?, vinculado As Entidades.Cliente.ClienteVinculado) As DataTable

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT V.IdCliente")
         .AppendLine("      ,C.CodigoCliente")
         .AppendLine("      ,C.NombreCliente")
         .AppendLine("      ,C.NombreDeFantasia")

         If configMail = Cliente.ConfiguracionMail.Principal.ToString() Then
            .AppendLine("     ,C.CorreoElectronico")
         ElseIf configMail = Cliente.ConfiguracionMail.Administrativo.ToString() Then
            .AppendLine("     ,C.CorreoAdministrativo AS CorreoElectronico")
         ElseIf configMail = Cliente.ConfiguracionMail.AdminyPrincipal.ToString() Then
            .AppendLine("       ,CASE WHEN ISNULL(C.CorreoAdministrativo, '') = '' THEN C.CorreoElectronico ELSE CASE WHEN ISNULL(C.CorreoElectronico, '') = '' THEN C.CorreoAdministrativo ELSE C.CorreoAdministrativo + ';' + C.CorreoElectronico  END  END AS CorreoElectronico")
         ElseIf configMail = Cliente.ConfiguracionMail.AdminoPrincipal.ToString() Then
            .AppendLine("     ,CASE WHEN ISNULL(C.CorreoAdministrativo, '') = '' THEN C.CorreoElectronico ELSE C.CorreoAdministrativo END AS CorreoElectronico")
         End If

         .AppendLine("      ,CV.IdCliente As IdClienteVinculado")
         .AppendLine("      ,CV.CodigoCliente As CodigoClienteVinculado")
         .AppendLine("      ,CV.NombreCliente As NombreClienteVinculado")
         If configMail = Cliente.ConfiguracionMail.Principal.ToString() Then
            .AppendLine("     ,CV.CorreoElectronico As CorreoClienteVinculado")
         ElseIf configMail = Cliente.ConfiguracionMail.Administrativo.ToString() Then
            .AppendLine("     ,CV.CorreoAdministrativo As CorreoClienteVinculado")
         ElseIf configMail = Cliente.ConfiguracionMail.AdminyPrincipal.ToString() Then
            .AppendLine("       ,CASE WHEN ISNULL(CV.CorreoAdministrativo, '') = '' THEN CV.CorreoElectronico ELSE CASE WHEN ISNULL(CV.CorreoElectronico, '') = '' THEN CV.CorreoAdministrativo ELSE CV.CorreoAdministrativo + ';' + CV.CorreoElectronico  END  END As CorreoClienteVinculado")
         ElseIf configMail = Cliente.ConfiguracionMail.AdminoPrincipal.ToString() Then
            .AppendLine("     ,CASE WHEN ISNULL(CV.CorreoAdministrativo, '') = '' THEN CV.CorreoElectronico ELSE CV.CorreoAdministrativo END As CorreoClienteVinculado")
         End If

         .AppendLine("      ,C.IdCategoria")
         .AppendLine("      ,CAT.NombreCategoria")
         .AppendLine("      ,C.IdCategoriaFiscal")
         .AppendLine("      ,CF.NombreCategoriaFiscal")
         .AppendLine("      ,C.IdZonaGeografica")
         .AppendLine("      ,Z.NombreZonaGeografica")
         .AppendLine("      ,V.Fecha")
         .AppendLine("      ,V.IdSucursal")
         .AppendLine("      ,V.IdTipoComprobante")
         .AppendLine("      ,V.Letra")
         .AppendLine("      ,V.CentroEmisor")
         .AppendLine("      ,V.NumeroComprobante")
         .AppendLine("      ,V.ImporteTotal")
         .AppendLine("      ,CC.Saldo")
         .AppendLine("      ,V.Observacion")
         .AppendLine("      ,E.NombreEmpleado AS NombreVendedor")
         .AppendLine("      ,Cob.NombreEmpleado AS NombreCobrador")
         .AppendLine("      ,EC.NombreEstadoCliente")

         If modoFechas = "VENCIMIENTO" Then
            .AppendLine("      ,DATEDIFF(day, CCP.FechaVencimiento,GETDATE() ) as Dias")
            .AppendLine("      ,CCP.FechaVencimiento")
         End If

         .AppendLine("      ,CONVERT(bit, 0) AS Envio")
         .AppendLine("      ,V.FechaEnvioCorreo")
         .AppendLine("      ,C.SiMovilIdUsuario")
         .AppendLine("      ,C.SiMovilClave")

         .AppendLine("  FROM Ventas AS V")

         '# JOIN para Saldo del Comprobate
         .AppendLine("   LEFT JOIN CuentasCorrientes CC")
         .AppendLine("           ON CC.IdSucursal = V.IdSucursal")
         .AppendLine("          AND CC.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("          AND CC.Letra = V.Letra")
         .AppendLine("          AND CC.CentroEmisor = V.CentroEmisor")
         .AppendLine("          AND CC.NumeroComprobante = V.NumeroComprobante")

         If modoFechas = "VENCIMIENTO" Then
            .AppendLine("   INNER JOIN CuentasCorrientesPagos CCP")
            .AppendLine("           ON CCP.IdSucursal = V.IdSucursal")
            .AppendLine("          AND CCP.IdTipoComprobante = V.IdTipoComprobante")
            .AppendLine("          AND CCP.Letra = V.Letra")
            .AppendLine("          AND CCP.CentroEmisor = V.CentroEmisor")
            .AppendLine("          AND CCP.NumeroComprobante = V.NumeroComprobante")
         End If

         .AppendLine("  INNER JOIN Sucursales S ON V.IdSucursal = S.IdSucursal")
         .AppendLine("  LEFT JOIN Clientes AS C ON C.IdCliente = V.IdCliente")
         .AppendLine("  LEFT JOIN Clientes AS CV ON C.IdClienteCtaCte = CV.IdCliente")

         .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
         .AppendLine("  LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
         .AppendLine("  LEFT JOIN ZonasGeograficas AS Z ON Z.IdZonaGeografica = c.IdZonaGeografica")
         .AppendLine("  LEFT JOIN Empleados AS E ON E.IdEmpleado = C.IdVendedor ")
         .AppendLine("  LEFT JOIN Empleados AS Cob ON Cob.IdEmpleado = C.IdCobrador")
         .AppendLine("  LEFT JOIN EstadosClientes AS EC ON EC.IdEstadoCliente = C.IdEstado")

         .AppendLine(" WHERE 1=1")

         GetListaSucursalesMultiples(stb, sucursales, "S")

         .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')")

         Dim campoFechaParaRango As String = "V.Fecha"
         If modoFechas = "VENCIMIENTO" Then
            .AppendLine("    AND CCP.SaldoCuota <> 0")
            campoFechaParaRango = "CCP.FechaVencimiento"
         End If

         If fechaDesde.HasValue AndAlso Not fechaDesde.Value.Equals(New Date()) Then
            .AppendFormatLine("   AND {1} >= '{0}'", ObtenerFecha(fechaDesde.Value, True), campoFechaParaRango)
         End If
         If fechaHasta.HasValue AndAlso Not fechaDesde.Value.Equals(New Date()) Then
            .AppendFormatLine("   AND {1} <= '{0}'", ObtenerFecha(fechaHasta.Value, True), campoFechaParaRango)
         End If
         If idCategoria.HasValue AndAlso idCategoria.Value > 0 Then
            .AppendFormatLine("   AND V.IdCategoria = {0}", idCategoria.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idZonaGeografica) Then
            .AppendFormatLine("   AND C.IdZonaGeografica = '{0}'", idZonaGeografica)
         End If
         If idCliente.HasValue AndAlso idCliente.Value > 0 Then
            If vinculado = Entidades.Cliente.ClienteVinculado.Cliente Then
               .AppendFormatLine("   AND V.idCliente = {0}", idCliente.Value)
            Else
               .AppendFormatLine("   AND CV.IdCliente = {0}", idCliente.Value)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(desdeNombreCliente) Then
            .AppendFormatLine("   AND C.NombreCliente >= '{0}'", desdeNombreCliente)
         End If

         If idcobrador > 0 Then
            .AppendFormatLine("   AND C.IdCobrador = {0}", idcobrador)
         End If

         If correoEnviado <> Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("	AND V.FechaEnvioCorreo IS {0} NULL", If(correoEnviado = Publicos.SiNoTodos.SI, "NOT", ""))
         End If

         If operador.HasValue Then
            .AppendFormatLine("  AND CC.Saldo {0} {1}", ObtenerOperadorRelacional(operador.Value), saldo)
         End If

         GetListaTiposComprobantesMultiples(stb, listaComprobantes, "V")

         .AppendLine(" ORDER BY C.NombreCliente, V.Fecha")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   'Function GetEnvioMasivoMailCtaCte(idSucursal As Integer,
   '                              idCategoria As Integer?, idZonaGeografica As String,
   '                              idCliente As Long?, desdeNombreCliente As String,
   '                              configMail As String, idcobrador As Integer, cantDias As Integer) As DataTable

   '   Dim stb As StringBuilder = New StringBuilder()


   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT V.IdCliente")
   '      .AppendLine("      ,C.CodigoCliente")
   '      .AppendLine("      ,C.NombreCliente")

   '      If configMail = Cliente.ConfiguracionMail.Principal.ToString() Then
   '         .AppendLine("     ,C.CorreoElectronico")
   '      ElseIf configMail = Cliente.ConfiguracionMail.Administrativo.ToString() Then
   '         .AppendLine("     ,C.CorreoAdministrativo AS CorreoElectronico")
   '      ElseIf configMail = Cliente.ConfiguracionMail.AdminyPrincipal.ToString() Then
   '         .AppendLine("     ,C.CorreoElectronico + ';' + C.CorreoAdministrativo AS CorreoElectronico")
   '      ElseIf configMail = Cliente.ConfiguracionMail.AdminoPrincipal.ToString() Then
   '         .AppendLine("     ,CASE WHEN ISNULL(C.CorreoAdministrativo, '') = '' THEN C.CorreoElectronico ELSE C.CorreoAdministrativo END AS CorreoElectronico")
   '      End If

   '      .AppendLine("      ,C.IdCategoria")
   '      .AppendLine("      ,CAT.NombreCategoria")
   '      .AppendLine("      ,C.IdCategoriaFiscal")
   '      .AppendLine("      ,CF.NombreCategoriaFiscal")
   '      .AppendLine("      ,C.IdZonaGeografica")
   '      .AppendLine("      ,Z.NombreZonaGeografica")
   '      .AppendLine("      ,V.Fecha")
   '      .AppendLine("      ,V.IdSucursal")
   '      .AppendLine("      ,V.IdTipoComprobante")
   '      .AppendLine("      ,V.Letra")
   '      .AppendLine("      ,V.CentroEmisor")
   '      .AppendLine("      ,V.NumeroComprobante")
   '      .AppendLine("      ,V.ImporteTotal")
   '      .AppendLine("      ,V.Observacion")
   '      .AppendLine("      ,E.NombreEmpleado AS NombreVendedor")
   '      .AppendLine("      ,Cob.NombreCobrador")
   '      .AppendLine("      ,EC.NombreEstadocliente")
   '      .AppendLine("      ,DATEDIFF(day, CC.FechaVencimiento,GETDATE() ) as Dias")
   '      .AppendLine("      ,CC.FechaVencimiento")
   '      .AppendLine("      ,CONVERT(bit, 0) AS Envio")
   '      .AppendLine("  FROM Ventas AS V")
   '      .AppendLine("   INNER JOIN CuentasCorrientes CC ON CC.IdSucursal = V.IdSucursal")
   '      .AppendLine("   AND CC.IdTipoComprobante = V.IdTipoComprobante")
   '      .AppendLine("   AND CC.Letra = V.Letra")
   '      .AppendLine("   AND CC.CentroEmisor = V.CentroEmisor")
   '      .AppendLine("   AND CC.NumeroComprobante = V.NumeroComprobante")
   '      .AppendLine("  LEFT JOIN Clientes AS C ON C.IdCliente = V.IdCliente")
   '      .AppendLine("  LEFT JOIN Categorias AS CAT ON CAT.IdCategoria = C.IdCategoria")
   '      .AppendLine("  LEFT JOIN CategoriasFiscales AS CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")
   '      .AppendLine("  LEFT JOIN ZonasGeograficas AS Z ON Z.IdZonaGeografica = c.IdZonaGeografica")
   '      .AppendLine("  LEFT JOIN Empleados AS E ON E.TipoDocEmpleado = C.TipoDocVendedor AND E.NroDocEmpleado = C.NroDocVendedor")
   '      .AppendLine("  LEFT JOIN Cobradores AS Cob ON Cob.IdCobrador = C.IdCobrador")
   '      .AppendLine("  LEFT JOIN EstadosClientes AS EC ON EC.IdEstadoCliente = C.IdEstado")

   '      .AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())
   '      .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante <> 'ANULADO')")
   '      .AppendLine("    AND CC.Saldo <> 0")
   '      .AppendLine("   AND DATEDIFF(day, CC.FechaVencimiento,GETDATE() ) >= " & cantDias)
   '      If idCategoria.HasValue AndAlso idCategoria.Value > 0 Then
   '         .AppendFormat("   AND V.IdCategoria = {0}", idCategoria.Value).AppendLine()
   '      End If
   '      If Not String.IsNullOrWhiteSpace(idZonaGeografica) Then
   '         .AppendFormat("   AND C.IdZonaGeografica = '{0}'", idZonaGeografica).AppendLine()
   '      End If
   '      If idCliente.HasValue AndAlso idCliente.Value > 0 Then
   '         .AppendFormat("   AND V.idCliente = {0}", idCliente.Value).AppendLine()
   '      End If
   '      If Not String.IsNullOrWhiteSpace(desdeNombreCliente) Then
   '         .AppendFormat("   AND C.NombreCliente >= '{0}'", desdeNombreCliente).AppendLine()
   '      End If

   '      If idcobrador > 0 Then
   '         .AppendFormat("   AND C.IdCobrador = {0}", idcobrador).AppendLine()
   '      End If

   '      .AppendLine(" ORDER BY C.NombreCliente, V.Fecha")
   '   End With

   '   Return Me.GetDataTable(stb.ToString())

   'End Function

End Class
