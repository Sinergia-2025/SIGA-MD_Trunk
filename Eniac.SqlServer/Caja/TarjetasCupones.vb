Public Class TarjetasCupones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TarjetasCupones_I(idSucursal As Integer,
                                idTarjetaCupon As Integer,
                                idTarjeta As Integer,
                                idBanco As Integer,
                                monto As Decimal,
                                cuotas As Integer,
                                numerolote As Integer,
                                numeroCupon As Integer,
                                fechaEmision As Date,
                                idEstadoTarjeta As Entidades.TarjetaCupon.Estados,
                                idCajaIngreso As Integer,
                                nroPlanillaIngreso As Integer,
                                nroMovimientoIngreso As Integer,
                                idCajaEgreso As Integer,
                                nroPlanillaEgreso As Integer,
                                nroMovimientoEgreso As Integer,
                                idUsuarioActualizacion As String,
                                fechaActualizacion As Date,
                                idCliente As Long,
                                idProveedor As Long,
                                idSituacionCupon As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.TarjetaCupon.NombreTabla)


         .AppendFormatLine("    ({0}", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdSucursal.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdTarjeta.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdBanco.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.Monto.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.Cuotas.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.NumeroLote.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.NumeroCupon.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.FechaEmision.ToString())

         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdEstadoTarjetaAnt.ToString())

         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdCajaIngreso.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.NroPlanillaIngreso.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.NroMovimientoIngreso.ToString())

         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdCajaEgreso.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.NroPlanillaEgreso.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.NroMovimientoEgreso.ToString())

         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdUsuarioActualizacion.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.FechaActualizacion.ToString())

         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdCliente.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdProveedor.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TarjetaCupon.Columnas.IdSituacionCupon.ToString())

         .AppendFormatLine(" ) VALUES (")


         .AppendFormatLine("     {0} ", idTarjetaCupon)
         .AppendFormatLine("   , {0} ", idSucursal)
         .AppendFormatLine("   , {0} ", idTarjeta)
         .AppendFormatLine("   , {0} ", idBanco)
         .AppendFormatLine("   , {0} ", monto)
         .AppendFormatLine("   , {0} ", cuotas)
         .AppendFormatLine("   , {0} ", numerolote)
         .AppendFormatLine("   , {0} ", numeroCupon)
         .AppendFormatLine("   ,'{0}'", Me.ObtenerFecha(fechaEmision, True))

         .AppendFormatLine("   ,'{0}'", idEstadoTarjeta.ToString())
         .AppendFormatLine("   ,'{0}'", idEstadoTarjeta.ToString())

         If nroPlanillaIngreso > 0 Then
            .AppendFormat("    ,{0}", idCajaIngreso)
            .AppendFormat("    ,{0}", nroPlanillaIngreso)
            .AppendFormat("    ,{0}", nroMovimientoIngreso)
         Else
            .AppendFormat("    ,NULL")
            .AppendFormat("    ,NULL")
            .AppendFormat("    ,NULL")
         End If
         If nroPlanillaEgreso > 0 Then
            .AppendFormat("    ,{0}", idCajaEgreso)
            .AppendFormat("    ,{0}", nroPlanillaEgreso)
            .AppendFormat("    ,{0}", nroMovimientoEgreso)
         Else
            .AppendFormat("    ,NULL")
            .AppendFormat("    ,NULL")
            .AppendFormat("    ,NULL")
         End If
         .AppendFormatLine("   ,'{0}'", idUsuarioActualizacion)
         .AppendFormatLine("   ,'{0}'", Me.ObtenerFecha(fechaActualizacion, False))

         If idCliente > 0 Then
            .AppendFormat("           ,{0}", idCliente)
         Else
            .AppendFormat("           ,NULL")
         End If

         If idProveedor > 0 Then
            .AppendFormat("           ,{0}", idProveedor)
         Else
            .AppendFormat("           ,NULL")
         End If

         .AppendFormat("           ,{0}", idSituacionCupon)

         .AppendLine(" )")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TarjetasCupones_U(idTarjetaCupon As Integer, idSituacionCupon As Integer)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.TarjetaCupon.NombreTabla)

         .AppendFormatLine(" SET {0} =  {1} ", Entidades.TarjetaCupon.Columnas.IdSituacionCupon.ToString(), idSituacionCupon)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)
      End With

      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TarjetasCupones_UC(idTarjetaCupon As Integer, idCajaIngreso As Integer, nroPlanillaIngreso As Integer, nroMovimientoIngresado As Integer)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.TarjetaCupon.NombreTabla)

         .AppendFormatLine(" SET {0} =  {1} ", Entidades.TarjetaCupon.Columnas.IdCajaIngreso.ToString(), idCajaIngreso)
         .AppendFormatLine("   , {0} =  {1} ", Entidades.TarjetaCupon.Columnas.NroPlanillaIngreso.ToString(), nroPlanillaIngreso)
         .AppendFormatLine("   , {0} =  {1} ", Entidades.TarjetaCupon.Columnas.NroMovimientoIngreso.ToString(), nroMovimientoIngresado)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TarjetasCupones_D(idTarjetaCupon As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.TarjetaCupon.NombreTabla)
         .AppendFormat("   WHERE {0} = {1}", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function TarjetasCupones_GA_PorComprobanteCtaCte(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT TC.*, BNC.NombreBanco, TRJ.NombreTarjeta ")
         .AppendFormatLine("  FROM CuentasCorrientesTarjetas CCT")
         .AppendFormatLine(" INNER JOIN TarjetasCupones TC ON TC.IdTarjetaCupon = CCT.IdTarjetaCupon")
         '--REQ-44566.- ------------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine(" INNER JOIN Bancos BNC on TC.IdBanco = BNC.IdBanco")
         .AppendFormatLine(" INNER JOIN Tarjetas TRJ ON TC.IdTarjeta = TRJ.IdTarjeta")
         '--------------------------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine(" WHERE CCT.IdSucursal =         {0} ", idSucursal)
         .AppendFormatLine("   AND CCT.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CCT.Letra =             '{0}'", letra)
         .AppendFormatLine("   AND CCT.CentroEmisor =       {0} ", centroEmisor)
         .AppendFormatLine("   AND CCT.NumeroComprobante =  {0} ", numeroComprobante)
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function TarjetasCupones_GA_PorComprobanteCompra(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT TC.*")
         .AppendFormatLine("  FROM ComprasTarjetas CT")
         .AppendFormatLine(" INNER JOIN TarjetasCupones TC ON TC.IdTarjetaCupon = CT.IdTarjetaCupon")
         .AppendFormatLine(" WHERE CT.IdSucursal         =  {0} ", idSucursal)
         .AppendFormatLine("   AND CT.IdTipoComprobante  = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND CT.Letra              = '{0}'", letra)
         .AppendFormatLine("   AND CT.CentroEmisor       =  {0} ", centroEmisor)
         .AppendFormatLine("   AND CT.NumeroComprobante  =  {0} ", numeroComprobante)
         .AppendFormatLine("   AND CT.IdProveedor        =  {0} ", idProveedor)
      End With
      Return GetDataTable(myQuery)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT TC.*")
         .AppendLine("      ,B.NombreBanco")
         .AppendLine("      ,Cl.IdCliente")
         .AppendLine("      ,Cl.CodigoCliente")
         .AppendLine("      ,Cl.NombreCliente")
         .AppendLine("      ,CNI.NombreCaja NombreCajaIngreso")
         .AppendLine("      ,CNe.NombreCaja NombreCajaEgreso")
         .AppendLine("      ,T.NombreTarjeta")
         .AppendLine("      ,SC.NombreSituacionCupon")
         .AppendLine(" 	    ,T.NombreTarjeta
		                      ,B.NombreBanco")
         .AppendLine("  FROM TarjetasCupones TC")

         .AppendLine("  INNER JOIN Bancos B ON TC.IdBanco = B.IdBanco ")
         .AppendLine("  INNER JOIN Tarjetas T ON TC.IdTarjeta = T.IdTarjeta")
         .AppendLine("  LEFT OUTER JOIN Clientes Cl ON TC.IdCliente = Cl.IdCliente ")
         .AppendLine("  LEFT OUTER JOIN Proveedores P ON TC.IdProveedor = P.IdProveedor ")
         .AppendLine("  LEFT JOIN CajasDetalle CI ON TC.NroPlanillaIngreso = CI.NumeroPlanilla AND TC.NroMovimientoIngreso = CI.NumeroMovimiento  AND TC.IdCajaIngreso = CI.IdCaja AND CI.IdSucursal =TC.IdSucursal ")
         .AppendLine("  LEFT JOIN CajasDetalle CE ON TC.NroPlanillaEgreso = CE.NumeroPlanilla AND TC.NroMovimientoEgreso = CE.NumeroMovimiento AND TC.IdCajaEgreso = CE.IdCaja AND CE.IdSucursal =TC.IdSucursal  ")
         .AppendLine("  LEFT JOIN CajasNombres CNI ON TC.IdSucursal = CNI.IdSucursal AND TC.IdCajaIngreso = CNI.IdCaja")
         .AppendLine("  LEFT JOIN CajasNombres CNE ON TC.IdSucursal = CNE.IdSucursal AND TC.IdCajaEgreso = CNE.IdCaja")
         .AppendLine("  LEFT JOIN SituacionCupones SC ON TC.IdSituacionCupon = SC.IdSituacionCupon")
      End With
   End Sub

   Public Function Buscar(columna As String, valor As String) As DataTable

      columna = "TC." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString(), Entidades.TarjetaCupon.NombreTablaHistorial)) + 1
   End Function
   Public Function TarjetasCupones_G1(idTarjetasCupon As Integer) As DataTable
      Return TarjetasCupones_GA(sucursales:=Nothing, IdTarjetaCupon:=idTarjetasCupon, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing, idEstadoTarjeta:=Entidades.TarjetaCupon.Estados.NINGUNO.ToString(),
                                 fechaLiquidacionDesde:=Nothing, fechaLiquidacionHasta:=Nothing, numeroCupon:=0, numeroLote:=0, fechaEnCarteraAl:=Nothing,
                                  idCaja:=0, idBanco:=0, idCliente:=0, idTarjeta:=0, idSituacionCupon:=0)
   End Function
   Public Function TarjetasCupones_GA() As DataTable
      Return TarjetasCupones_GA(Nothing, IdTarjetaCupon:=0, fechaIngresoDesde:=Nothing, fechaIngresoHasta:=Nothing, idEstadoTarjeta:=Entidades.TarjetaCupon.Estados.NINGUNO.ToString(),
                                 fechaLiquidacionDesde:=Nothing, fechaLiquidacionHasta:=Nothing, numeroCupon:=0, numeroLote:=0, fechaEnCarteraAl:=Nothing,
                                  idCaja:=0, idBanco:=0, idCliente:=0, idTarjeta:=0, idSituacionCupon:=0)
   End Function
   Public Function TarjetasCupones_GA_Venta(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return TarjetasCupones_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, tablaRelacion:="VentasTarjetas")
   End Function
   Public Function TarjetasCupones_GA_CtaCte(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return TarjetasCupones_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, tablaRelacion:="CuentasCorrientesTarjetas")
   End Function
   Private Function TarjetasCupones_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, tablaRelacion As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" INNER JOIN {0} VT ON VT.IdTarjetaCupon = TC.IdTarjetaCupon", tablaRelacion)
         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal <> 0 Then
            .AppendFormatLine("   And VT.{0} =  {1} ", Entidades.VentaTarjeta.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   And VT.{0} = '{1}'", Entidades.VentaTarjeta.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
      End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND VT.{0} = '{1}'", Entidades.VentaTarjeta.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine("   AND VT.{0} =  {1} ", Entidades.VentaTarjeta.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroComprobante <> 0 Then
            .AppendFormatLine("   AND VT.{0} =  {1} ", Entidades.VentaTarjeta.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         End If

         .AppendFormatLine("  ORDER BY TC.{0}", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString())
      End With
      Return GetDataTable(stb)
   End Function

   Public Function TarjetasCupones_GA(sucursales As Entidades.Sucursal(), idTarjetaCupon As Integer,
                                      fechaIngresoDesde As Date?, fechaIngresoHasta As Date?,
                                      idEstadoTarjeta As String,
                                      fechaLiquidacionDesde As Date?, fechaLiquidacionHasta As Date?,
                                      numeroCupon As Integer, numeroLote As Integer,
                                      fechaEnCarteraAl As Date?,
                                      idCaja As Integer, idBanco As Integer,
                                      idCliente As Long, idTarjeta As Integer, idSituacionCupon As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(stb, sucursales, "TC") '-.PE-32098.-

         If idTarjetaCupon > 0 Then
            .AppendFormatLine("   AND TC.{0} = {1}", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)
         End If

         If fechaIngresoDesde.HasValue And fechaIngresoHasta.HasValue Then
            .AppendFormatLine("	AND TC.FechaEmision Between '{0}' AND '{1}'", ObtenerFecha(fechaIngresoDesde.Value.Date, False), ObtenerFecha(fechaIngresoHasta.Value.Date.AddDays(1).AddSeconds(-1), True))
         End If

         If idEstadoTarjeta <> Entidades.TarjetaCupon.Estados.NINGUNO.ToString() Then
            .AppendFormatLine("   AND TC.{0} = '{1}'", Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString(), idEstadoTarjeta)
         End If

         If fechaLiquidacionDesde.HasValue And fechaLiquidacionHasta.HasValue Then
            .AppendFormatLine("	AND TC.FechaActualizacion Between '{0}' AND '{1}'", ObtenerFecha(fechaLiquidacionDesde.Value.Date, False), ObtenerFecha(fechaLiquidacionHasta.Value.Date.AddDays(1).AddSeconds(-1), True))
         End If

         If numeroCupon > 0 Then
            .AppendFormatLine("   AND TC.{0} = {1}", Entidades.TarjetaCupon.Columnas.NumeroCupon.ToString(), numeroCupon)
         End If

         If numeroLote > 0 Then
            .AppendFormatLine("   AND TC.{0} = {1}", Entidades.TarjetaCupon.Columnas.NumeroLote.ToString(), numeroLote)
         End If

         If fechaEnCarteraAl.HasValue Then
            .AppendFormatLine("	AND TC.FechaEmision <= '{0}'", ObtenerFecha(fechaEnCarteraAl.Value.Date.AddDays(1).AddSeconds(-1), True))
         End If
         If idBanco > 0 Then
            .AppendFormatLine("   AND TC.{0} = {1}", Entidades.TarjetaCupon.Columnas.IdBanco.ToString(), idBanco)
         End If

         If idCaja > 0 Then
            .AppendFormatLine("   AND TC.{0} = {1}", Entidades.TarjetaCupon.Columnas.IdCajaIngreso.ToString(), idCaja)
         End If

         If idCliente > 0 Then
            .AppendFormatLine("	AND TC.IdCliente = {0}", idCliente)
         End If

         If idTarjeta > 0 Then
            .AppendFormatLine("	AND TC.IdTarjeta = {0}", idTarjeta)
         End If

         If idSituacionCupon > 0 Then
            .AppendFormatLine("	AND TC.IdSituacionCupon = {0}", idSituacionCupon)
         End If
         .AppendFormatLine("  ORDER BY TC.{0}", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString())
      End With
      Return GetDataTable(stb)
   End Function

   Public Function TarjetasCupones_GCupon(idSucursal As Integer,
                                        numeroCupon As Integer,
                                     numeroLote As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)


         .AppendFormatLine(" WHERE 1 = 1")

         If idSucursal > 0 Then
            .AppendFormatLine("   AND TC.{0} = {1}", Entidades.TarjetaCupon.Columnas.IdSucursal.ToString(), idSucursal)
         End If

         If numeroCupon > 0 Then
            .AppendFormatLine("   AND TC.{0} = {1}", Entidades.TarjetaCupon.Columnas.NumeroCupon.ToString(), numeroCupon)
         End If

         If numeroLote > 0 Then
            .AppendFormatLine("   AND TC.{0} = {1}", Entidades.TarjetaCupon.Columnas.NumeroLote.ToString(), numeroLote)
         End If

         .AppendFormatLine("  ORDER BY TC.{0}", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TarjetasCupones_GA_DeMovimientoCaja(idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE ((TC.{0} = {1} AND TC.{2} = {3} AND TC.{4} = {5} AND TC.{6} = {7}) OR",
                           Entidades.TarjetaCupon.Columnas.IdSucursal.ToString(), idSucursal,
                           Entidades.TarjetaCupon.Columnas.IdCajaIngreso.ToString(), idCaja,
                           Entidades.TarjetaCupon.Columnas.NroPlanillaIngreso.ToString(), nroPlanilla,
                           Entidades.TarjetaCupon.Columnas.NroMovimientoIngreso.ToString(), nroMovimiento)
         .AppendFormatLine("        (TC.{0} = {1} AND TC.{2} = {3} AND TC.{4} = {5} AND TC.{6} = {7}))  ",
                           Entidades.TarjetaCupon.Columnas.IdSucursal.ToString(), idSucursal,
                           Entidades.TarjetaCupon.Columnas.IdCajaEgreso.ToString(), idCaja,
                           Entidades.TarjetaCupon.Columnas.NroPlanillaEgreso.ToString(), nroPlanilla,
                           Entidades.TarjetaCupon.Columnas.NroMovimientoEgreso.ToString(), nroMovimiento)
         .AppendFormatLine("  ORDER BY T.{0}, TC.{1}, TC.{2}",
                           Entidades.Tarjeta.Columnas.NombreTarjeta.ToString(),
                           Entidades.TarjetaCupon.Columnas.NumeroLote.ToString(),
                           Entidades.TarjetaCupon.Columnas.NumeroCupon.ToString())
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub ActualizaEstado(idTarjetaCupon As Integer, volverAEstadoAnterior As Boolean, nuevoEstado As Entidades.TarjetaCupon.Estados, nuevoEstadoAnt As Entidades.TarjetaCupon.Estados?)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0}", Entidades.TarjetaCupon.NombreTabla)
         If volverAEstadoAnterior Then
            .AppendFormatLine("   SET {0} =  {1} ", Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString(), Entidades.TarjetaCupon.Columnas.IdEstadoTarjetaAnt.ToString())
            .AppendFormatLine("     , {0} = NULL ", Entidades.TarjetaCupon.Columnas.IdEstadoTarjetaAnt.ToString())
         Else
            If nuevoEstadoAnt.HasValue Then
               .AppendFormatLine("   SET {0} = '{1}'", Entidades.TarjetaCupon.Columnas.IdEstadoTarjetaAnt.ToString(), nuevoEstadoAnt.Value.ToString())
            Else
               .AppendFormatLine("   SET {0} =  {1} ", Entidades.TarjetaCupon.Columnas.IdEstadoTarjetaAnt.ToString(), Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString())
            End If
            .AppendFormatLine("     , {0} = '{1}'", Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString(), nuevoEstado.ToString())
         End If

            .AppendFormatLine("     , {0} = '{1}'", Entidades.TarjetaCupon.Columnas.FechaActualizacion, ObtenerFecha(Date.Now, True))
            .AppendFormatLine("     , {0} = '{1}'", Entidades.TarjetaCupon.Columnas.IdUsuarioActualizacion, actual.Nombre)
            .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TarjetaCupon.Columnas.IdTarjetaCupon.ToString(), idTarjetaCupon)

            'Solo ejecuto el Update si efectivamente cambia el estado. Hacemos esto para no generar Historial de Cupones innecesarios ya que los mismos se crean con un Trigger.
            .AppendFormatLine("   AND {0} <> '{1}' ", Entidades.TarjetaCupon.Columnas.IdEstadoTarjeta.ToString(), nuevoEstado.ToString())
      End With
      Execute(query)
   End Sub


   Public Sub TarjetasCupones_U_MovimientoAsociar(idTarjetaCupon As Integer,
                                                  idSucursal As Integer, idCaja As Integer, nroDePlanilla As Integer, nroDeMovimiento As Integer,
                                                  idEstadoTarjeta As Entidades.TarjetaCupon.Estados,
                                                  idUsuarioActualizacion As String, ingresoEgreso As Boolean)
      Dim strIngresoEgreso = If(ingresoEgreso, "Ingreso", "Egreso")
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.TarjetaCupon.NombreTabla)
         .AppendFormatLine("   SET IdSucursal = {0}", idSucursal)
         .AppendFormatLine("     , IdCaja{1} = {0}", idCaja, strIngresoEgreso)
         .AppendFormatLine("     , NroPlanilla{1} = {0}", nroDePlanilla, strIngresoEgreso)
         .AppendFormatLine("     , NroMovimiento{1} = {0}", nroDeMovimiento, strIngresoEgreso)
         .AppendFormatLine("     , IdEstadoTarjetaAnt = IdEstadoTarjeta")
         .AppendFormatLine("     , IdEstadoTarjeta = '{0}'", idEstadoTarjeta.ToString())
         .AppendFormatLine("     , FechaActualizacion = GETDATE()")
         .AppendFormatLine("     , IdUsuarioActualizacion = '{0}'", idUsuarioActualizacion)
         .AppendFormatLine(" WHERE IdTarjetaCupon = {0}", idTarjetaCupon)
         .AppendFormatLine("   AND IdEstadoTarjeta <> '{0}'", idEstadoTarjeta.ToString())
      End With
      Execute(myQuery)
   End Sub
   Public Sub TarjetasCupones_U_MovimientoDesasociar(idSucursal As Integer, idCaja As Integer, nroPlanilla As Integer, nroMovimiento As Integer,
                                                     idEstadoTarjeta As Entidades.TarjetaCupon.Estados?, idEstadoTarjetaAnt As Entidades.TarjetaCupon.Estados?,
                                                     fechaActualizacion As Date?, idUsuarioActualizacion As String, ingresoEgreso As Boolean)
      Dim strIngresoEgreso = If(ingresoEgreso, "Ingreso", "Egreso")
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.TarjetaCupon.NombreTabla)
         .AppendFormatLine("   SET IdCaja{0} = NULL", strIngresoEgreso)
         .AppendFormatLine("     , NroPlanilla{0} = NULL", strIngresoEgreso)
         .AppendFormatLine("     , NroMovimiento{0} = NULL", strIngresoEgreso)

         If idEstadoTarjeta.HasValue Then
            .AppendFormatLine("     , IdEstadoTarjeta = '{0}'", idEstadoTarjeta.Value)
         Else
            .AppendFormatLine("     , IdEstadoTarjeta = IdEstadoTarjetaAnt")
         End If
         If idEstadoTarjetaAnt.HasValue Then
            .AppendFormatLine("     , IdEstadoTarjetaAnt = '{0}'", idEstadoTarjetaAnt.Value)
         Else
            .AppendFormatLine("     , IdEstadoTarjetaAnt = IdEstadoTarjeta")
         End If

         If fechaActualizacion.HasValue Then
            .AppendFormatLine("     , FechaActualizacion = '{0}'", ObtenerFecha(fechaActualizacion.Value, True))
         Else
            .AppendFormatLine("     , FechaActualizacion = GETDATE()")
         End If
         .AppendFormatLine("     , IdUsuarioActualizacion = '{0}'", idUsuarioActualizacion)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdCaja{1} = {0}", idCaja, strIngresoEgreso)
         .AppendFormatLine("   AND NroPlanilla{1} = {0}", nroPlanilla, strIngresoEgreso)
         .AppendFormatLine("   AND NroMovimiento{1} = {0}", nroMovimiento, strIngresoEgreso)
      End With
      Execute(myQuery)
   End Sub

   Public Function GetCajaDetallesAyudaCuponesTarjetas(estados As Entidades.TarjetaCupon.Estados(), fechaEmisionDesde As Date?, fechaEmisionHasta As Date?,
                                                       idTarjeta As Integer, idBanco As Integer, numeroLote As Integer, numeroCupon As Integer,
                                                       idCliente As Long, idProveedor As Long, idCaja As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If estados.AnySecure() Then
            .AppendFormatLine("   AND TC.IdEstadoTarjeta in ({0})", String.Join(",", estados.ToList().ConvertAll(Function(e) String.Format("'{0}'", e.ToString()))))
         End If
         If fechaEmisionDesde.HasValue Then
            .AppendFormatLine("   AND TC.FechaEmision >= '{0}'", ObtenerFecha(fechaEmisionDesde.Value, False))
         End If
         If fechaEmisionHasta.HasValue Then
            .AppendFormatLine("   AND TC.FechaEmision <= '{0}'", ObtenerFecha(fechaEmisionHasta.Value.UltimoSegundoDelDia(), False))
         End If
         If idTarjeta <> 0 Then
            .AppendFormatLine("   AND TC.IdTarjeta = {0}", idTarjeta)
         End If
         If idBanco <> 0 Then
            .AppendFormatLine("   AND TC.IdBanco = {0}", idBanco)
         End If
         If numeroLote <> 0 Then
            .AppendFormatLine("   AND TC.NumeroLote = {0}", numeroLote)
         End If
         If numeroCupon <> 0 Then
            .AppendFormatLine("   AND TC.NumeroCupon = {0}", numeroCupon)
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND TC.IdCliente = {0}", idCliente)
         End If
         If idProveedor <> 0 Then
            .AppendFormatLine("   AND TC.IdProveedor = {0}", idProveedor)
         End If
         If idCaja <> 0 Then
            .AppendFormatLine("   AND TC.IdCajaIngreso = {0}", idCaja)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetSaldoCuponesEnCartera(IdSucursal As Integer,
                                            IdCaja As Integer) As Decimal

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT SUM(Monto) AS Saldo FROM {0}", Entidades.TarjetaCupon.NombreTabla)
         .AppendFormatLine(" WHERE IdSucursal = {0}", IdSucursal)
         .AppendFormatLine("   AND IdCajaIngreso = {0}", IdCaja)
         .AppendFormatLine("   AND IdEstadoTarjeta = 'ENCARTERA'")
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Saldo").ToString()) Then
            Return Decimal.Parse(dt.Rows(0)("Saldo").ToString())
         End If
      End If

      Return 0

   End Function

End Class
