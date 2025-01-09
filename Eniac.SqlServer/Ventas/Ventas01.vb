Partial Class Ventas

   ''GRABACION / ACTUALIZACION

   ''INVMUL:
   '<Obsolete("INVMUL: Se reemplaza por invocación multiple", False)>
   'Public Sub Ventas_Facturables_U(idSucursal As Integer,
   '                             idTipoComprobante As String,
   '                             letra As String,
   '                             centroEmisor As Integer,
   '                             numeroComprobante As Long,
   '                             idEstadoComprobante As String,
   '                             idTipoComprobanteFact As String,
   '                             letraFact As String,
   '                             centroEmisorFact As Integer,
   '                             numeroComprobanteFact As Long,
   '                             MercDespachada As Boolean)

   '   Dim myQuery As StringBuilder = New StringBuilder("")

   '   'Actualiza el registro (ej: REMITO) con los datos del comprobante que lo cancelo (ej: FACTURA)
   '   If idEstadoComprobante = "PEDIDO" Then

   '   End If
   '   With myQuery
   '      .Length = 0
   '      .AppendLine("UPDATE Ventas SET ")
   '      .AppendLine("   IdTipoComprobanteFact = '" & idTipoComprobante & "'")
   '      .AppendLine("  ,LetraFact = '" & letra & "'")
   '      .AppendLine("  ,CentroEmisorFact = " & centroEmisor.ToString())
   '      .AppendLine("  ,NumeroComprobanteFact = " & numeroComprobante.ToString())
   '      .AppendLine("  ,IdEstadoComprobante = '" & idEstadoComprobante & "'")
   '      '-- REQ-30768 --
   '      If MercDespachada Then
   '         .AppendLine("  ,MercDespachada = " & GetStringFromBoolean(MercDespachada))
   '      End If
   '      .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString() & Chr(13))
   '      .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobanteFact & "'" & Chr(13))
   '      .AppendLine("   AND Letra = '" & letraFact & "'" & Chr(13))
   '      .AppendLine("   AND CentroEmisor = " & centroEmisorFact.ToString() & Chr(13))
   '      .AppendLine("   AND NumeroComprobante = " & numeroComprobanteFact.ToString())
   '   End With

   '   Me.Execute(myQuery.ToString())
   '   Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   'End Sub

   'Coloco o quito la fecha, para que se pueda Anular o No.
   Public Sub U_FechaTransmisionAFIP(ByVal idSucursal As Integer, _
                                       ByVal idTipoComprobante As String, _
                                       ByVal letra As String, _
                                       ByVal centroEmisor As Integer, _
                                       ByVal numeroComprobante As Long, _
                                       ByVal fechaTransmisionAFIP As Date)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")

         If fechaTransmisionAFIP > Date.Parse("01/01/1990") Then
            .AppendLine("   FechaTransmisionAFIP = '" & Me.ObtenerFecha(fechaTransmisionAFIP, True) & "'")  'o deberia tomar la fecha del Servidor!!??
         Else
            .AppendLine("   FechaTransmisionAFIP = NULL")
         End If

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub U_DatosRoelaSirplusVentas(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Integer,
                                        numeroComprobante As Long,
                                        oPagos As Entidades.CuentaCorrientePago)

      Dim myQuery = New StringBuilder("")
      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")

         .AppendFormatLine("   FechaVencimiento = '{0}'", ObtenerFecha(oPagos.FechaVencimiento, True))
         .AppendFormatLine("  ,ImporteCuota = {0} ", oPagos.ImporteCuota)

         .AppendFormatLine("  ,FechaVencimiento2 = {0} ", ObtenerFecha(oPagos.FechaVencimiento2, True))
         .AppendFormatLine("  ,ImporteVencimiento2 = {0} ", oPagos.ImporteCuota2)
         .AppendFormatLine("  ,FechaVencimiento3 = {0} ", ObtenerFecha(oPagos.FechaVencimiento3, True))
         .AppendFormatLine("  ,ImporteVencimiento3 = {0} ", oPagos.ImporteCuota3)

         If oPagos.CodigoDeBarra IsNot Nothing Then
            .AppendFormatLine("   ,CodigoDeBarra  = '{0}' ", oPagos.CodigoDeBarra)
         End If
         If oPagos.CodigoDeBarraSirplus IsNot Nothing Then
            .AppendFormatLine("   ,CodigoDeBarraSirplus = '{0}' ", oPagos.CodigoDeBarraSirplus)
         End If

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub U_NumeroComprobanteFiscal(ByVal idSucursal As Integer, _
                                     ByVal idTipoComprobante As String, _
                                     ByVal letra As String, _
                                     ByVal centroEmisor As Integer, _
                                     ByVal numeroComprobante As Long, _
                                     ByVal NumeroComprobanteFiscal As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")

         If numeroComprobante > 0 Then
            .AppendLine("   NumeroComprobanteFiscal = " & NumeroComprobanteFiscal)
         Else
            .AppendLine("   NumeroComprobanteFiscal = NULL")
         End If

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   'Public Sub Ventas_Desaplica_Facturables_U(ByVal idSucursal As Integer, _
   '                                       ByVal idTipoComprobanteFact As String, _
   '                                       ByVal letraFact As String, _
   '                                       ByVal centroEmisorFact As Integer, _
   '                                       ByVal numeroComprobanteFact As Long)

   '   Dim myQuery As StringBuilder = New StringBuilder("")

   '   'Actualiza el registro (ej: REMITO) con los datos del comprobante que lo cancelo (ej: FACTURA)
   '   With myQuery
   '      .Length = 0
   '      .AppendLine("UPDATE Ventas SET ")
   '      .AppendLine("   IdTipoComprobanteFact = NULL")
   '      .AppendLine("  ,LetraFact = NULL")
   '      .AppendLine("  ,CentroEmisorFact = NULL")
   '      .AppendLine("  ,NumeroComprobanteFact = NULL")
   '      .AppendLine("  ,IdEstadoComprobante = NULL")
   '      .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
   '      .AppendLine("   AND IdTipoComprobanteFact = '" & idTipoComprobanteFact & "'")
   '      .AppendLine("   AND LetraFact = '" & letraFact & "'")
   '      .AppendLine("   AND CentroEmisorFact = " & centroEmisorFact.ToString())
   '      .AppendLine("   AND NumeroComprobanteFact = " & numeroComprobanteFact.ToString())
   '   End With

   '   Me.Execute(myQuery.ToString())
   '   Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   'End Sub

   'Actualiza la cantidad de Lotes que utilizo. Segun la situacion, la seleccion es Automatica.
   Public Sub Ventas_ActualizaCantidadLotes(ByVal idSucursal As Integer, _
                                             ByVal idTipoComprobante As String, _
                                             ByVal letra As String, _
                                             ByVal centroEmisor As Integer, _
                                             ByVal numeroComprobante As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")
         .AppendLine("   CantidadLotes = ")
         .AppendLine("( SELECT COUNT(*) FROM VentasProductosLotes b ")
         .AppendLine("   WHERE Ventas.IdSucursal = b.IdSucursal ")
         .AppendLine("     AND Ventas.IdTipoComprobante = b.IdTipoComprobante ")
         .AppendLine("     AND Ventas.Letra = b.Letra ")
         .AppendLine("     AND Ventas.CentroEmisor = b.CentroEmisor ")
         .AppendLine("     AND Ventas.NumeroComprobante = b.NumeroComprobante ")
         .AppendLine(") ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   'Actualiza la Comision Del Vendedor. Se calcula al momento de grabar, quitando impuestos y aplicando todos los descuentos.
   Public Sub Ventas_ActualizaComisionVendedor(ByVal idSucursal As Integer, _
                                                ByVal idTipoComprobante As String, _
                                                ByVal letra As String, _
                                                ByVal centroEmisor As Integer, _
                                                ByVal numeroComprobante As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")
         .AppendLine("   ComisionVendedor = ")
         .AppendLine("ISNULL(( SELECT SUM(ComisionVendedor) FROM VentasProductos b ")
         .AppendLine("   WHERE Ventas.IdSucursal = b.IdSucursal ")
         .AppendLine("     AND Ventas.IdTipoComprobante = b.IdTipoComprobante ")
         .AppendLine("     AND Ventas.Letra = b.Letra ")
         .AppendLine("     AND Ventas.CentroEmisor = b.CentroEmisor ")
         .AppendLine("     AND Ventas.NumeroComprobante = b.NumeroComprobante ")
         .AppendLine("), 0) ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub Ventas_MovimientoCaja_U(ByVal idSucursal As Integer, _
                                 ByVal idTipoComprobante As String, _
                                 ByVal letra As String, _
                                 ByVal centroEmisor As Integer, _
                                 ByVal numeroComprobante As Long, _
                                 ByVal idCaja As Integer, _
                                 ByVal numeroPlanilla As Integer, _
                                 ByVal numeroMovimiento As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas")
         .AppendLine("   SET idCaja = " & idCaja.ToString())
         .AppendLine("      ,numeroPlanilla = " & numeroPlanilla.ToString())
         .AppendLine("      ,numeroMovimiento = " & numeroMovimiento.ToString())
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub Ventas_PlanillaCaja_U(ByVal idSucursal As Integer, _
                                 ByVal idTipoComprobante As String, _
                                 ByVal letra As String, _
                                 ByVal centroEmisor As Integer, _
                                 ByVal numeroComprobante As Long, _
                                 ByVal idCaja As Integer, _
                                 ByVal numeroPlanilla As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas")
         .AppendLine("   SET idCaja = " & idCaja.ToString())
         .AppendLine("      ,numeroPlanilla = " & numeroPlanilla.ToString())
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub ActualizaFechaImpresion(ByVal idSucursal As Integer, _
                                    ByVal idTipoComprobante As String, _
                                    ByVal letra As String, _
                                    ByVal centroEmisor As Integer, _
                                    ByVal numeroComprobante As Long)

      Dim myQuery As StringBuilder = New StringBuilder("")
      Dim gen As Generales = New Generales(_da)

      With myQuery
         .Append("UPDATE Ventas SET ")
         .AppendFormat("  FechaImpresion = '{0}'", gen.GetServerDBFechaHora().ToString("yyyyMMdd HH:mm:ss"))

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND letra = '{0}'", letra)
         .AppendFormat("   AND centroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND numeroComprobante = {0}", numeroComprobante)

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub ActualizaFechaEnvioCorreo(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Short,
                                     numeroComprobante As Long,
                                     fechaEnvioCorreo As DateTime?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE Ventas SET ")
         If fechaEnvioCorreo.HasValue Then
            .AppendFormatLine("  FechaEnvioCorreo = '{0}'", ObtenerFecha(fechaEnvioCorreo.Value, True))
         Else
            .AppendFormatLine("  FechaEnvioCorreo = NULL")
         End If

         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND letra = '{0}'", letra)
         .AppendFormatLine("   AND centroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND numeroComprobante = {0}", numeroComprobante)

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")
   End Sub

   Public Sub ActualizaVenta(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                             idVendedor As Integer, comisionVendedor As Decimal, modificaComision As Boolean,
                             idCobrador As Integer, idClienteVinculado As Long,
                             observacion As String,
                             idCategoria As Integer,
                             fecha As Date,
                             cuit As String, tipoDocCliente As String, nroDocCliente As Long,
                             idPaciente As Long?, idDoctor As Long?, fechaCirugia As Date?)
      Dim myQuery = New StringBuilder()
      Dim gen = New Generales(_da)
      With myQuery
         .Append("UPDATE Ventas SET ")
         .AppendFormat("  IdVendedor = {0}", idVendedor)
         If modificaComision Then
            .AppendFormat("  ,ComisionVendedor = '{0}'", comisionVendedor)
         End If
         If idCobrador > 0 Then
            .AppendFormat("      ,IdCobrador = {0}", idCobrador)
         Else
            .AppendFormat("      ,IdCobrador = {0}", "NULL")
         End If
         If idClienteVinculado > 0 Then
            .AppendFormat("  ,IdClienteVinculado = {0}", idClienteVinculado)
         Else
            .AppendFormat("      ,IdClienteVinculado = {0}", "NULL")
         End If

         .AppendFormat("     ,Observacion = '{0}'", observacion)

         If idCategoria <> 0 Then
            .AppendFormat("     ,IdCategoria = {0}", idCategoria)
         End If

         .AppendFormat("     ,Fecha = '{0}'", ObtenerFecha(fecha, True))

         '# Datos Clínicos
         If idPaciente.HasValue Then
            .AppendFormatLine("	    ,IdPaciente = {0}", idPaciente.Value)
         Else
            .AppendFormatLine("	    ,IdPaciente = NULL")
         End If
         If idDoctor.HasValue Then
            .AppendFormatLine("	    ,IdDoctor = {0}", idDoctor.Value)
         Else
            .AppendFormatLine("	    ,IdDoctor = NULL")
         End If
         If fechaCirugia.HasValue Then
            .AppendFormatLine("	    ,FechaCirugia = '{0}'", fechaCirugia.Value)
         Else
            .AppendFormatLine("	    ,FechaCirugia = NULL")
         End If
         '--------------------------

         If Not String.IsNullOrWhiteSpace(cuit) Then
            .AppendFormatLine("	    ,Cuit = '{0}'", cuit)
         Else
            .AppendFormatLine("	    ,Cuit = NULL")
         End If
         If nroDocCliente <> 0 Then
            .AppendFormatLine("	    ,TipoDocCliente = '{0}'", tipoDocCliente)
            .AppendFormatLine("	    ,NroDocCliente = {0}", nroDocCliente)
         Else
            .AppendFormatLine("	    ,TipoDocCliente = NULL")
            .AppendFormatLine("	    ,NroDocCliente = NULL")
         End If

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND letra = '{0}'", letra)
         .AppendFormat("   AND centroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND numeroComprobante = {0}", numeroComprobante)

      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   Public Sub GrabaMercaderiaDespachada(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Integer,
                                        numeroComprobante As Long,
                                        despacho As Boolean,
                                        numeroReparto As Integer,
                                        fechaEnvio As Date,
                                        idTransportista As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Ventas  ")
         .AppendLine(" SET MercDespachada = '" & Me.GetStringFromBoolean(despacho).ToString() & "'")
         If numeroReparto <> 0 Then
            .AppendLine(" , NumeroReparto = " & numeroReparto)
         Else
            .AppendLine(" , NumeroReparto = Null")
         End If
         If fechaEnvio <> Nothing Then
            .AppendLine(" , FechaEnvio = '" & fechaEnvio & "'")
         Else
            .AppendLine(" , FechaEnvio = Null")
         End If

         If idTransportista <> 0 Then
            .AppendLine(" , IdTransportista = " & idTransportista)
         Else
            .AppendLine(" , IdTransportista = NULL")
         End If

         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND letra = '" & letra & "'")
         .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   ''Public Sub AnularMercaderiaDespachada(ByVal idSucursal As Integer, _
   ''                       ByVal idTipoComprobante As String, _
   ''                       ByVal letra As String, _
   ''                       ByVal centroEmisor As Integer, _
   ''                       ByVal numeroComprobante As Long)

   ''   Dim myQuery As StringBuilder = New StringBuilder("")

   ''   With myQuery
   ''      .Length = 0
   ''      .AppendLine("UPDATE Ventas  ")
   ''      .AppendLine(" SET MercDespachada = 'False'")
   ''      .AppendLine(" , NumeroReparto = 0")
   ''      .AppendLine(" , FechaEnvio = ''")
   ''      .AppendLine(" , IdTransportista = 0")
   ''      .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
   ''      .AppendLine("   AND idTipoComprobante = '" & idTipoComprobante & "'")
   ''      .AppendLine("   AND letra = '" & letra & "'")
   ''      .AppendLine("   AND centroEmisor = " & centroEmisor.ToString())
   ''      .AppendLine("   AND numeroComprobante = " & numeroComprobante.ToString())
   ''   End With

   ''   Me.Execute(myQuery.ToString())
   ''   Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   ''End Sub



   '''' METODOS LLAMADOS DIRECTAMENTE DESDE OTROS MODULOS
   ''CuentasCorrientes
   Public Sub AnulaImportesCtaCteConPagoParcial(idSucursal As Integer,
                                             idTipoComprobante As String,
                                             letra As String,
                                             centroEmisor As Integer,
                                             numeroComprobante As Long)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas")
         .AppendLine("   SET ImportePesos = 0")
         .AppendLine("     , ImporteTickets = 0")
         .AppendLine("     , ImporteTarjetas = 0")
         .AppendLine("     , ImporteCheques = 0")
         .AppendLine("     , ImporteTransfBancaria = 0")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND centroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND numeroComprobante = {0}", numeroComprobante).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   ''Alquileres
   Public Sub Ventas_ActualizaEstadoComprobante(ByVal idSucursal As Integer,
                                             ByVal idTipoComprobante As String,
                                             ByVal letra As String,
                                             ByVal centroEmisor As Integer,
                                             ByVal numeroComprobante As Long,
                                             ByVal idEstadoComprobante As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Ventas SET ")
         .AppendLine("   idEstadoComprobante = " & IIf(idEstadoComprobante = "PENDIENTE", "NULL", "'" & idEstadoComprobante & "'").ToString())
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND Letra = '" & letra & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

   ''Impresoras
   Public Function AlgunRegistrosVentaPorEmisor(emisor As Short) As Boolean
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT TOP 1 CentroEmisor")
         .AppendLine("  FROM Ventas")
         .AppendFormat(" WHERE CentroEmisor = {0}", emisor)
      End With

      Return GetDataTable(stb.ToString()).Rows.Count > 0
   End Function

   Public Sub ActualizaCantidadReintentos(ByVal idSucursal As Integer,
                                   ByVal idTipoComprobante As String,
                                   ByVal letra As String,
                                   ByVal centroEmisor As Integer,
                                   ByVal numeroComprobante As Long,
                                   ByVal cantidadReintentos As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")
      Dim gen As Generales = New Generales(_da)

      With myQuery
         .Append("UPDATE Ventas SET ")
         .AppendFormat("  CantidadReintentosImpresion = {0}", cantidadReintentos)

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND letra = '{0}'", letra)
         .AppendFormat("   AND centroEmisor = {0}", centroEmisor)
         .AppendFormat("   AND numeroComprobante = {0}", numeroComprobante)

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Ventas")

   End Sub

End Class