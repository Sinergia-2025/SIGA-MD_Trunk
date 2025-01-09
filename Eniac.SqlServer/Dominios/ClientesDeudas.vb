Public Class ClientesDeudas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ClientesDeudas_I(IdCliente As Long,
                               nro_prestamo As Long,
                               fecha_corte As Date,
                               tipo_cobro As String,
                               convenio As String,
                               linea As String,
                               fecha_emision As Date,
                               cantidad_cuotas As Integer,
                               cuotas_pagas As Integer,
                               cuotas_adeudadas As Integer,
                               capital_total As Decimal,
                               deuda_exigible As Decimal,
                               fecha_ult_cobranza As Date,
                               dias_mora As Integer,
                               deuda_exigible_con_quita As Decimal,
                               empresa As String,
                               vendedor As String,
                               monto_cuota As Decimal,
                               Activo As Boolean)

      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .AppendLine("INSERT INTO ClientesDeudas (")
         .AppendLine("         IdCliente ")
         .AppendLine("            ,nro_prestamo")
         .AppendLine("            ,fecha_corte")
         .AppendLine("            ,tipo_cobro")
         .AppendLine("            ,convenio")
         .AppendLine("            ,linea ")
         .AppendLine("            ,fecha_emision ")
         .AppendLine("            ,cantidad_cuotas")
         .AppendLine("            ,cuotas_pagas ")
         .AppendLine("            ,cuotas_adeudadas")
         .AppendLine("            ,capital_total")
         .AppendLine("            ,deuda_exigible ")
         .AppendLine("            ,fecha_ult_cobranza ")
         .AppendLine("            ,dias_mora")
         .AppendLine("            ,deuda_exigible_con_quita ")
         .AppendLine("            ,empresa ")
         .AppendLine("            ,vendedor ")
         .AppendLine("            ,monto_cuota")
         .AppendLine("            ,Activo")
         .AppendLine(")     VALUES(")
         .AppendFormat("           {0}", IdCliente)
         .AppendFormat("           ,{0}", nro_prestamo)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fecha_corte, True))
         .AppendFormat("           ,'{0}'", tipo_cobro)
         .AppendFormat("           ,'{0}'", convenio)
         .AppendFormat("           ,'{0}'", linea)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fecha_emision, True))
         .AppendFormat("           ,{0}", cantidad_cuotas)
         .AppendFormat("           ,{0}", cuotas_pagas)
         .AppendFormat("           ,{0}", cuotas_adeudadas)
         .AppendFormat("           ,{0}", capital_total)
         .AppendFormat("           ,{0}", deuda_exigible)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fecha_ult_cobranza, True))
         .AppendFormat("           ,{0}", dias_mora)
         .AppendFormat("           ,{0}", deuda_exigible_con_quita)
         .AppendFormat("           ,'{0}'", empresa)
         .AppendFormat("           ,'{0}'", vendedor)
         .AppendFormat("           ,{0}", monto_cuota)
         .AppendFormat("           ,'{0}'", Me.GetStringFromBoolean(Activo))
         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "ClientesDeudas")
   End Sub

   Public Sub ClientesDeudas_U(ByVal Partida As Long, _
                        ByVal IdTipoImpuesto As Integer, _
                        ByVal IdMunicipio As Integer, _
                        ByVal Periodo As String, _
                        ByVal Deuda As Decimal, _
                        ByVal FechaCobro As DateTime, _
                        ByVal FechaPago As DateTime, _
                        ByVal ImporteAproximado As Decimal, _
                        ByVal ImporteCobrado As Decimal, _
                        ByVal DarDeBaja As Boolean, _
                        ByVal FechaActualizadoAl As DateTime, _
                        ByVal FechaUltimaModificacion As DateTime, _
                        ByVal FechaCarta1 As DateTime, _
                        ByVal FechaCarta2 As DateTime, _
                        ByVal FechaCarta3 As DateTime, _
                        ByVal FechaLiquidacion As DateTime, _
                          ByVal Importa As Boolean)

      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE ClientesDeudas SET ")
         If Not Importa Then
            If FechaCobro = Nothing Then
               .Append("      FechaCobro = null")
            Else
               .AppendFormat("      FechaCobro = '{0}'", Me.ObtenerFecha(FechaCobro, True))
            End If
            If FechaPago = Nothing Then
               .Append("      ,FechaPago = null")
            Else
               .AppendFormat("      ,FechaPago = '{0}'", Me.ObtenerFecha(FechaPago, True))
            End If
            .AppendFormat("      ,ImporteAproximado = {0}", ImporteAproximado)
            .AppendFormat("      ,ImporteCobrado = {0}", ImporteCobrado)
            .AppendFormat("      ,DarDeBaja = {0}", Me.GetStringFromBoolean(DarDeBaja))
            If FechaActualizadoAl = Nothing Then
               .Append("      ,FechaActualizadoAl = null")
            Else
               .AppendFormat("      ,FechaActualizadoAl = '{0}'", Me.ObtenerFecha(FechaActualizadoAl, True))
            End If
            If FechaUltimaModificacion = Nothing Then
               .Append("      ,FechaUltimaModificacion = null")
            Else
               .AppendFormat("      ,FechaUltimaModificacion = '{0}'", Me.ObtenerFecha(FechaUltimaModificacion, True))
            End If
            If FechaCarta1 = Nothing Then
               .Append("      ,FechaCarta1 = null")
            Else
               .AppendFormat("      ,FechaCarta1 = '{0}'", Me.ObtenerFecha(FechaCarta1, True))
            End If
            If FechaCarta2 = Nothing Then
               .Append("      ,FechaCarta2 = null")
            Else
               .AppendFormat("      ,FechaCarta2 = '{0}'", Me.ObtenerFecha(FechaCarta2, True))
            End If
            If FechaCarta3 = Nothing Then
               .Append("      ,FechaCarta3 = null")
            Else
               .AppendFormat("      ,FechaCarta3 = '{0}'", Me.ObtenerFecha(FechaCarta3, True))
            End If
            If FechaLiquidacion = Nothing Then
               .Append("      ,FechaLiquidacion = null")
            Else
               .AppendFormat("      ,FechaLiquidacion = '{0}'", Me.ObtenerFecha(FechaLiquidacion, True))
            End If
         End If

         .Append(" WHERE ")
         .AppendFormat("      Partida = {0}", Partida)
         .AppendFormat("      AND IdTipoImpuesto = {0}", IdTipoImpuesto)
         .AppendFormat("      AND IdMunicipio = {0}", IdMunicipio)
         .AppendFormat("      AND Periodo = '{0}'", Periodo)


      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "ClientesDeudas")
   End Sub

   Public Sub ClientesDeudas_D(ByVal IdCliente As Long, ByVal NroPrestamo As Integer)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM ClientesDeudas WHERE ")
         .AppendFormat("      IdCliente = {0}", IdCliente)
         .AppendFormat("      AND NroPrestamo = {0}", NroPrestamo)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "ClientesDeudas")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT (SELECT TOP 1 Descripcion FROM CRMNovedades CN Where CN.IdCliente = CD.IdCliente) as G  ")
         .AppendLine("        , CD.IdCliente ")
         .AppendLine(" 		 ,C.NombreCliente")
         .AppendLine(" 		 ,C.CodigoCliente ")
         .AppendLine(" 		 ,C.Cuit ")
         .AppendLine("      ,CD.empresa")
         .AppendLine(" 		 ,C.Direccion ")
         .AppendLine(" 		 ,C.IdLocalidad ")
         .AppendLine(" 		 ,L.NombreLocalidad ")
         .AppendLine(" 		 ,P.NombreProvincia ")
         .AppendLine(" 		 ,C.CorreoElectronico")
         .AppendLine("            ,CD.nro_prestamo")
         .AppendLine("            ,CD.fecha_corte")
         .AppendLine("            ,CD.tipo_cobro")
         .AppendLine("            ,CD.convenio")
         .AppendLine("            ,CD.linea ")
         .AppendLine("            ,CD.fecha_emision ")
         .AppendLine("            ,CD.cantidad_cuotas")
         .AppendLine("            ,CD.cuotas_pagas ")
         .AppendLine("            ,CD.cuotas_adeudadas")
         .AppendLine("            ,CD.capital_total")
         .AppendLine("            ,CD.deuda_exigible ")
         .AppendLine("            ,CD.fecha_ult_cobranza ")
         .AppendLine("            ,CD.dias_mora")
         .AppendLine("            ,CD.deuda_exigible_con_quita ")
         .AppendLine("            ,CD.FechaCarta1")
         .AppendLine("            ,CD.FechaCarta2")
         .AppendLine("            ,CD.FechaLiquidacion")
         .AppendLine("            ,CD.ImporteAcordado")
         .AppendLine("            ,CD.IdSucursal")
         .AppendLine("            ,CD.IdTipoComprobante")
         .AppendLine("            ,CD.Letra")
         .AppendLine("            ,CD.CentroEmisor")
         .AppendLine("            ,CD.NumeroComprobante")
         .AppendLine(" 	          ,CC.ImporteTotal")
         .AppendLine(" 	          ,CC.Saldo")
         .AppendLine("            ,CD.Vendedor")
         .AppendLine("            ,CD.monto_cuota")
         .AppendLine("            ,CA.NombreCategoria")
         .AppendLine("            ,CD.Activo")
         .AppendLine("  FROM ClientesDeudas CD  ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendLine(" INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         .AppendLine(" LEFT JOIN CuentasCorrientes CC ON CC.IdSucursal = CD.IdSucursal")
         .AppendLine("  AND CC.IdTipoComprobante = CD.IdTipoComprobante ")
         .AppendLine("  AND CC.Letra = CD.Letra ")
         .AppendLine("  AND CC.CentroEmisor = CD.CentroEmisor ")
         .AppendLine("  AND CC.NumeroComprobante = CD.NumeroComprobante")
         .AppendLine("  AND CC.Saldo <> 0 ")

      End With
   End Sub

   Public Function ClientesDeudas_GetDeuda(ByVal Cuenta As Long, ByVal IdTipoImpuesto As Integer, ByVal IdMunicipio As Integer, ByVal Periodo As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("   WHERE Cuenta = " & Cuenta)
         .AppendLine("  AND IdTipoImpuesto = " & IdTipoImpuesto)
         .AppendLine("  AND IdMunicipio = " & IdMunicipio)
         If Not String.IsNullOrEmpty(Periodo) Then
            .AppendLine("  AND Periodo = '" & Periodo & "'")
         End If
         .AppendLine(" AND FechaPago is null")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesDeudas_GetDeudas() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         '  .AppendLine("   WHERE 1=1")
     
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesDeudas_GetDeudaExportacion(ByVal FechaDesde As Date, ByVal FechaHasta As Date, _
                              ByVal IdTipoImpuesto As Integer, ByVal IdMunicipio As Integer,
                              ByVal Titular As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("   WHERE  FechaPago is not null")
         If FechaDesde.Year > 1 Then
            .AppendLine("	 AND CONVERT(varchar(11), FechaPago, 120) >= '" & FechaDesde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), FechaPago, 120) <= '" & FechaHasta.ToString("yyyy-MM-dd") & "'")
         End If
         .AppendLine("  AND IdTipoImpuesto = " & IdTipoImpuesto)
         .AppendLine("  AND IdMunicipio = " & IdMunicipio)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesDeudas_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesDeudas(ByVal IdTipoImpuesto As Integer, ByVal IdMunicipalidad As Integer, ByVal Pagos As String,
                             ByVal FechaPagoDesde As Date, ByVal FechaPagoHasta As Date) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("   WHERE IdTipoImpuesto = " & IdTipoImpuesto)
         .AppendLine("   AND IdMunicipio = " & IdMunicipalidad)

         If FechaPagoDesde.Year > 1 Then
            .AppendLine("	 AND CONVERT(varchar(11), FechaPago, 120) >= '" & FechaPagoDesde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), FechaPago, 120) <= '" & FechaPagoHasta.ToString("yyyy-MM-dd") & "'")
         End If

         If Pagos <> "TODOS" Then
            .AppendLine("      AND ImporteCobrado  " & IIf(Pagos = "SI", "<> 0", " = 0 or ImporteCobrado is null").ToString())
         End If


      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetClientesDeudasCartas(ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal Origen As String, _
                              ByVal NroActa As Integer, ByVal Rebeldia As Integer, ByVal Dominio As String,
                              ByVal Infractor As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("    WHERE  M.Pago <> 'True'  ")
         If FechaDesde.Year > 1 Then
            .AppendLine("	 AND CONVERT(varchar(11), M.FechaEmision, 120) >= '" & FechaDesde.ToString("yyyy-MM-dd") & "'")
            .AppendLine("	 AND CONVERT(varchar(11), M.FechaEmision, 120) <= '" & FechaHasta.ToString("yyyy-MM-dd") & "'")
         End If
         If Not String.IsNullOrEmpty(Origen) Then
            .AppendFormat("  AND  M.IdOrigen = '{0}'", Origen)
         End If
         If NroActa <> 0 Then
            .AppendFormat("  AND  M.NumeroActa = {0}", NroActa)
         End If

         If Rebeldia <> 0 Then
            .AppendFormat("  AND  M.Rebeldia = {0}", Rebeldia)
         End If

         If Not String.IsNullOrEmpty(Dominio) Then
            .AppendFormat("  AND  M.Dominio = '{0}'", Dominio)
         End If

         If Not String.IsNullOrEmpty(Infractor) Then
            .AppendFormat("  AND  M.Infractor  LIKE '%{0}%'", Infractor)
         End If


      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesDeudas_G1(ByVal IdCliente As Long, ByVal NroPrestamo As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("   WHERE CD.IdCliente = " & IdCliente)
         If NroPrestamo <> 0 Then
            .AppendLine("  AND CD.nro_prestamo = " & NroPrestamo)
         End If

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesDeudas_GDesdePrestamo(ByVal IdCliente As Long, _
                  ByVal NroPrestamo As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("  WHERE    CD.IdCliente = {0}", IdCliente)
         .AppendFormat("      AND CD.nro_prestamo = {0}", NroPrestamo)

         '  .AppendLine(" and (DarDeBaja is null or DarDeBaja = 0)")

         .AppendLine("  ORDER BY fecha_emision")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesDeudas_GTotalDeuda(ByVal IdCliente As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat("  WHERE    CD.IdCliente = {0}", IdCliente)

         '.AppendLine(" and (DarDeBaja is null or DarDeBaja = 0)")
         '.AppendLine(" AND FechaPago is null")
         '.AppendLine("  ORDER BY Periodo")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ClientesDeudas_GPendientes(ByVal IdCliente As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendLine("SELECT ")
         .AppendLine("         CD.IdCliente ")
         .AppendLine(" 		 ,C.NombreCliente")
         .AppendLine(" 		 ,C.CodigoCliente ")
         .AppendLine(" 		 ,C.Cuit ")
         .AppendLine("      ,CD.empresa")
         .AppendLine(" 		 ,C.Direccion ")
         .AppendLine(" 		 ,C.IdLocalidad ")
         .AppendLine(" 		 ,L.NombreLocalidad ")
         .AppendLine(" 		 ,P.NombreProvincia ")
         .AppendLine(" 		 ,C.CorreoElectronico")
         .AppendLine("            ,CD.nro_prestamo")
         .AppendLine("            ,CD.fecha_corte")
         .AppendLine("            ,CD.tipo_cobro")
         .AppendLine("            ,CD.convenio")
         .AppendLine("            ,CD.linea ")
         .AppendLine("            ,CD.fecha_emision ")
         .AppendLine("            ,CD.cantidad_cuotas")
         .AppendLine("            ,CD.cuotas_pagas ")
         .AppendLine("            ,CD.cuotas_adeudadas")
         .AppendLine("            ,CD.capital_total")
         .AppendLine("            ,CD.deuda_exigible ")
         .AppendLine("            ,CD.fecha_ult_cobranza ")
         .AppendLine("            ,CD.dias_mora")
         .AppendLine("            ,CD.deuda_exigible_con_quita ")
         .AppendLine("            ,CD.FechaCarta1")
         .AppendLine("            ,CD.FechaCarta2")
         .AppendLine("            ,CD.FechaLiquidacion")
         .AppendLine("            ,CD.ImporteAcordado")
         .AppendLine("            ,CD.IdSucursal")
         .AppendLine("            ,CD.IdTipoComprobante")
         .AppendLine("            ,CD.Letra")
         .AppendLine("            ,CD.CentroEmisor")
         .AppendLine("            ,CD.NumeroComprobante")
         .AppendLine("            ,CD.monto_cuota")
         .AppendLine("            ,CD.Activo")
         .AppendLine("  FROM ClientesDeudas CD  ")
         .AppendLine(" INNER JOIN Clientes C ON C.IdCliente = CD.IdCliente")
         .AppendLine(" INNER JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = L.IdProvincia")
         .AppendFormat("  WHERE    CD.IdCliente = {0}", IdCliente)
         .AppendLine(" AND ImporteAcordado IS NULL")
             End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Sub ClientesDeudas_UFechasCartas(ByVal IdCliente As Long, ByVal fechaLiquidacion As DateTime,
                ByVal FechaCarta1 As DateTime, ByVal FechaCarta2 As DateTime)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("UPDATE ClientesDeudas")
         .AppendFormat("   SET ")
         If fechaLiquidacion <> Nothing Then
            .AppendFormat("      FechaLiquidacion = '{0}'", Me.ObtenerFecha(fechaLiquidacion, True))
         End If
         If FechaCarta1 <> Nothing Then
            .AppendFormat("      ,FechaCarta1 = '{0}'", Me.ObtenerFecha(FechaCarta1, True))
         End If
         If FechaCarta2 <> Nothing Then
            .AppendFormat("      ,FechaCarta2 = '{0}'", Me.ObtenerFecha(FechaCarta2, True))
         End If
         .AppendFormat("  WHERE    IdCliente = {0}", IdCliente)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ClientesDeudas_UCtaCte(ByVal CC As Entidades.CuentaCorriente, ByVal NroPrestamo As Long, ByVal ImporteAcordado As Decimal)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("UPDATE ClientesDeudas")
         .AppendFormat("   SET ")
         .AppendFormat("      ImporteAcordado = {0}", ImporteAcordado)
         .AppendFormat("      ,IdSucursal = {0}", CC.IdSucursal)
         .AppendFormat("      ,IdTipoComprobante = '{0}'", CC.TipoComprobante.IdTipoComprobante)
         .AppendFormat("      ,Letra = '{0}'", CC.Letra)
         .AppendFormat("      ,CentroEmisor = {0}", CC.CentroEmisor)
         .AppendFormat("      ,NumeroComprobante = {0}", CC.NumeroComprobante)

         .AppendFormat("  WHERE    IdCliente = {0}", CC.Cliente.IdCliente)
         .AppendFormat("  AND nro_prestamo = {0}", NroPrestamo)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub ClientesDeudas_UCtaCteEliminacion(ByVal CC As Entidades.CuentaCorriente)
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("UPDATE ClientesDeudas")
         .AppendLine("   SET ")
         .AppendLine("      ImporteAcordado = NULL")
         .AppendLine("      ,IdSucursal = NULL")
         .AppendLine("      ,IdTipoComprobante = NULL")
         .AppendLine("      ,Letra = NULL")
         .AppendLine("      ,CentroEmisor = NULL")
         .AppendLine("      ,NumeroComprobante = NULL")

         .AppendFormat("  WHERE    IdCliente = {0}", CC.Cliente.IdCliente)
         .AppendFormat("  AND IdSucursal = {0}", CC.IdSucursal)
         .AppendFormat(" AND IdTipoComprobante = '{0}'", CC.TipoComprobante.IdTipoComprobante)
         .AppendFormat(" AND Letra = '{0}'", CC.Letra)
         .AppendFormat(" AND CentroEmisor = {0}", CC.CentroEmisor)
         .AppendFormat(" AND NumeroComprobante = {0}", CC.NumeroComprobante)

      End With

      Me.Execute(stb.ToString())
   End Sub
   Public Sub ClientesDeudas_UCancelaFechaCarta(ByVal cuenta As Long, ByVal IdTipoImpuesto As Integer,
                                        ByVal IdMunicipio As Integer, ByVal numeroCarta As Integer)

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("UPDATE ClientesDeudas")
         .AppendFormat("   SET ")
         If numeroCarta = 50 Then
            .Append("      FechaCarta1 = null")
         End If
         If numeroCarta = 51 Then
            .Append("      FechaCarta2 = null")
         End If
         If numeroCarta = 52 Then
            .Append("      FechaCarta3 = null")
         End If
         .AppendFormat(" WHERE Cuenta = {0}", cuenta)
         .AppendFormat("      AND IdTipoImpuesto = {0}", IdTipoImpuesto)
         .AppendFormat("      AND IdMunicipio = {0}", IdMunicipio)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Function ClientesDeudas_Existe(ByVal cuenta As Long, ByVal IdTipoImpuesto As Integer,
                                        ByVal IdMunicipio As Integer, ByVal Periodo As String) As Long

      Dim dt As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT Cuenta")
         .AppendLine(" FROM ClientesDeudas")
         .AppendFormat(" WHERE Cuenta = {0}", cuenta)
         .AppendFormat("      AND IdTipoImpuesto = {0}", IdTipoImpuesto)
         .AppendFormat("      AND IdMunicipio = {0}", IdMunicipio)
         .AppendLine("   AND Periodo = '" & Periodo & "'")
      End With

      dt = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count = 0 Then
         Return 0
      ElseIf dt.Rows.Count = 1 Then
         Return Long.Parse(dt.Rows(0).Item("IdPago").ToString())
      Else
         Throw New Exception("Existen " & dt.Rows.Count.ToString() & " registros para la Cuenta " & cuenta.ToString() & "en el Periodo '" & Periodo & "'")
      End If

   End Function

   Public Sub ClientesDeudas_UInforme(ByVal cuenta As Long, ByVal IdTipoImpuesto As Integer,
                                        ByVal IdMunicipio As Integer, ByVal Periodo As String, ByVal Importe As Decimal,
                                        ByVal FechaPago As Date)

      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE ClientesDeudas SET ")
         .Append(" DarDeBaja = 'True'")
         .Append(" ,FechaPago = '" & Me.ObtenerFecha(FechaPago, True) & "'")
         .Append(" ,ImporteCobrado = " & Importe)
         .AppendFormat(" WHERE Cuenta = {0}", cuenta)
         .AppendFormat("      AND IdTipoImpuesto = {0}", IdTipoImpuesto)
         .AppendFormat("      AND IdMunicipio = {0}", IdMunicipio)
         If Periodo <> "CONV.  " Then
            .AppendLine("   AND Periodo = '" & Strings.Left(Periodo.ToString(), 4) & "/" & Strings.Right(Periodo.ToString(), 3) & "'")
         Else
            .Append("")
         End If

      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "ClientesDeudas")

   End Sub

   Public Function ClientesDeudas_GPeriodosPendientes(ByVal cuenta As Long, ByVal IdTipoImpuesto As Integer,
                                        ByVal IdMunicipio As Integer, ByVal Periodo As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE Cuenta = {0}", cuenta)
         .AppendFormat("      AND IdTipoImpuesto = {0}", IdTipoImpuesto)
         .AppendFormat("      AND IdMunicipio = {0}", IdMunicipio)
         .AppendLine(" and (P.DarDeBaja is null or P.DarDeBaja = 0)")
         .AppendLine("  ORDER BY P.FechaPago ASC")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub ClientesDeudas_DPagos(ByVal cuenta As Long, ByVal IdTipoImpuesto As Integer,
                                        ByVal IdMunicipio As Integer, ByVal Periodo As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM ClientesDeudas")
         .AppendFormat(" WHERE Cuenta = {0}", cuenta)
         .AppendFormat("      AND IdTipoImpuesto = {0}", IdTipoImpuesto)
         .AppendFormat("      AND IdMunicipio = {0}", IdMunicipio)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub ActualizarDatos(idCliente As Long, NroPrestamo As Long, cuotas_pagas As Integer, cuotas_adeudadas As Integer,
                              deuda_exigible As Decimal, fecha_ult_cobranza As Date, dias_mora As Integer, deuda_exigible_con_quita As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("UPDATE ClientesDeudas SET ")
         .AppendFormat(" cuotas_pagas = {0}", cuotas_pagas)
         .AppendFormat(" ,cuotas_adeudadas = {0}", cuotas_adeudadas)
         .AppendFormat(" ,deuda_exigible = {0}", deuda_exigible)
         If Not String.IsNullOrEmpty(fecha_ult_cobranza.ToString()) Then
            .AppendFormat(" ,fecha_ult_cobranza = '{0}'", Me.ObtenerFecha(fecha_ult_cobranza, True))
         Else
            .AppendLine(" ,fecha_ult_cobranza = Null")
         End If
         .AppendFormat(" ,dias_mora = {0}", dias_mora)
         .AppendFormat(" ,deuda_exigible_con_quita = {0}", deuda_exigible_con_quita)
         .AppendFormat(" WHERE idCliente = {0} and nro_prestamo = {1}", idCliente, NroPrestamo)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Clientes")

   End Sub

   Public Sub ActualizarPrestamosActivos(ByVal Fecha_corte As Date)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE ClientesDeudas SET ")
         .AppendLine(" Activo = 'false'")
         .AppendFormat(" WHERE fecha_corte < '{0}'", Me.ObtenerFecha(Fecha_corte, True))
         .AppendLine("   AND NumeroComprobante is null")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Clientes")

   End Sub

   Public Sub ActualizarMontoCuota(idCliente As Long, NroPrestamo As Long, monto_cuota As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("UPDATE ClientesDeudas SET ")
         .AppendFormat(" monto_cuota = {0}", monto_cuota)
         .AppendFormat(" WHERE idCliente = {0} and nro_prestamo = {1}", idCliente, NroPrestamo)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Clientes")

   End Sub

End Class
