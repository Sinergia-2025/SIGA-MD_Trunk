Imports Microsoft.Reporting.WinForms
Class ReporteCtaCteClientes

   Public Sub ArmarReporteCtaCteClientes(recibo As Entidades.CuentaCorriente, verEstandar As Boolean)

      Dim oImpresoras = New Reglas.Impresoras()
      Dim blnPorCtaOrden = oImpresoras.GetPorSucursalTipoComprobante(recibo.IdSucursal, recibo.TipoComprobante.IdTipoComprobante).PorCtaOrden

      Parametros = New List(Of ReportParameter)

      If recibo.TipoComprobante.GrabaLibro Or blnPorCtaOrden Then
         Parametros.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaOficial))


         Parametros.Add(New ReportParameter("DireccionEmpresa", String.Format("{0}, {1} ({2}), {3}",
                                                                        actual.Sucursal.Direccion,
                                                                        actual.Sucursal.Localidad.NombreLocalidad,
                                                                        actual.Sucursal.Localidad.IdLocalidad,
                                                                        actual.Sucursal.Localidad.IdProvincia)))
      Else
         Parametros.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))


         Parametros.Add(New ReportParameter("DireccionEmpresa", String.Format("{0}, {1} ({2}), {3}",
                                                                        actual.Sucursal.DireccionComercial,
                                                                        actual.Sucursal.Localidad.NombreLocalidad,
                                                                        actual.Sucursal.Localidad.IdLocalidad,
                                                                        actual.Sucursal.Localidad.IdProvincia)))
      End If

      Parametros.Add(New ReportParameter("CorreoEmpresa", actual.Sucursal.Correo))
      Parametros.Add(New ReportParameter("EmpresaCUIT", Reglas.Publicos.CuitEmpresa))
      Parametros.Add(New ReportParameter("IIBBEmpresa", Reglas.Publicos.IngresosBrutos))
      Parametros.Add(New ReportParameter("WEB", Reglas.Publicos.DireccionWebEmpresa))
      Parametros.Add(New ReportParameter("Redes", actual.Sucursal.RedesSociales))


      '-- REQ-33289.- ---------------------------------------------------------------------
      Parametros.Add(New ReportParameter("CodigoEmbarcacion", recibo.IdEmbarcacion.ToString()))
      If recibo.NombreEmbarcacion IsNot Nothing Then
         Parametros.Add(New ReportParameter("NombreEmbarcacion", recibo.NombreEmbarcacion))
         Parametros.Add(New ReportParameter("NombreCategoriaEmbarcacion", recibo.NombreCategoriaEmbarcacion))
      Else
         Parametros.Add(New ReportParameter("NombreEmbarcacion", "."))
         Parametros.Add(New ReportParameter("NombreCategoriaEmbarcacion", "."))
      End If
      '------------------------------------------------------------------------------------

      Try
         Parametros.Add(New ReportParameter("InicioActividadEmpresa", Reglas.Publicos.FechaInicioActividades.ToString()))
      Catch ex As Exception
         Throw New Exception("Falta configurar la fecha de inicio de actividades a la empresa", ex)
      End Try

      Parametros.Add(New ReportParameter("CategoriaFiscalEmpresaNombre", Reglas.Publicos.CategoriaFiscalEmpresaNombre))

      Parametros.Add(New ReportParameter("TelefonoEmpresa", Eniac.Entidades.Usuario.Actual.Sucursal.Telefono))
      Parametros.Add(New ReportParameter("Fecha", recibo.Fecha.ToString()))


      Parametros.Add(New ReportParameter("TipoYNroDocumento", recibo.Cliente.CodigoCliente.ToString()))

      Parametros.Add(New ReportParameter("NombreYApellido", recibo.Cliente.NombreCliente))
      Parametros.Add(New ReportParameter("TipoComprobante", recibo.TipoComprobante.Descripcion))
      Parametros.Add(New ReportParameter("Letra", recibo.Letra))
      Parametros.Add(New ReportParameter("CentroEmisor", recibo.CentroEmisor.ToString()))
      Parametros.Add(New ReportParameter("Numero", recibo.NumeroComprobante.ToString()))
      Parametros.Add(New ReportParameter("Direccion", recibo.Direccion))
      Parametros.Add(New ReportParameter("LocalidadProvincia", recibo.Cliente.Localidad.NombreLocalidad & " ( " & recibo.Cliente.Localidad.IdLocalidad.ToString().Truncar(4) & " ) - " & recibo.Cliente.Localidad.NombreProvincia))
      Parametros.Add(New ReportParameter("Localidad", New Reglas.Localidades().GetUna(recibo.IdLocalidad).NombreLocalidad))
      Parametros.Add(New ReportParameter("Cuit", "0" & recibo.Cliente.Cuit.Replace("-", "")))
      Parametros.Add(New ReportParameter("CategoriaIVA", recibo.Cliente.CategoriaFiscal.NombreCategoriaFiscal))
      Parametros.Add(New ReportParameter("Observacion", recibo.Observacion))
      Parametros.Add(New ReportParameter("Total", recibo.ImporteTotal.ToString()))
      Parametros.Add(New ReportParameter("Total_EnLetras", Numeros_A_Letras.EnLetras(recibo.ImporteTotal.ToString())))
      Parametros.Add(New ReportParameter("Efectivo", recibo.ImportePesos.ToString()))
      Parametros.Add(New ReportParameter("CuentaBancaria", recibo.CuentaBancariaTransfBanc.NombreCuenta))
      Parametros.Add(New ReportParameter("TransfBancaria", recibo.ImporteTransfBancaria.ToString()))
      Parametros.Add(New ReportParameter("FechaTransferencia", If(recibo.FechaTransferencia.HasValue, recibo.FechaTransferencia.Value.ToString(), Nothing)))
      Parametros.Add(New ReportParameter("Tickets", recibo.ImporteTickets.ToString()))
      Parametros.Add(New ReportParameter("Tarjetas", recibo.ImporteTarjetas.ToString()))
      Parametros.Add(New ReportParameter("Dolares", recibo.ImporteDolares.ToString()))
      Parametros.Add(New ReportParameter("Vendedor", recibo.Vendedor.NombreEmpleado))
      Parametros.Add(New ReportParameter("Retenciones", recibo.ImporteRetenciones.ToString()))
      Parametros.Add(New ReportParameter("Saldo", recibo.SaldoCtaCte.ToString()))
      Parametros.Add(New ReportParameter("FormaDePago", recibo.FormaPago.DescripcionFormasPago.ToString()))


      '-.PE-31610.-
      Parametros.Add(New ReportParameter("NombreFantasia", Reglas.Publicos.NombreFantasia))

      Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
      Dim LogoImagen = actual.Logo

      Parametros.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
      Parametros.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

      Dim caja = New Reglas.CajasNombres().GetUna(recibo.IdSucursal, recibo.CajaDetalle.IdCaja)
      Parametros.Add(New ReportParameter("Caja", caja.NombreCaja.ToString()))

      Dim strEtiquetaCuota As String = "Cta"
      Dim traduccion As Entidades.Traduccion = New Reglas.Traducciones().GetUno("RecibosNuevos", "Recibos", "gcoCuota", Entidades.Traduccion.Idiomas.es_AR.ToString(), Reglas.Traducciones.AccionesSiNoExisteRegistro.Nulo)
      If traduccion IsNot Nothing Then
         strEtiquetaCuota = traduccion.Texto
      End If
      Parametros.Add(New ReportParameter("Etiqueta_Cuota", strEtiquetaCuota))

      Parametros.Add(New ReportParameter("ImprimeSaldos", recibo.ImprimeSaldos.ToString()))


      CtaCtePagosDT = New SistemaDataSet.CuentasCorrientesPagosDataTable()

      Dim drCtaCte As SistemaDataSet.CuentasCorrientesPagosRow
      Dim TotalAplicado As Decimal = 0

      For Each ven In recibo.Pagos
         drCtaCte = CtaCtePagosDT.NewCuentasCorrientesPagosRow()
         drCtaCte.IdTipoComprobante = ven.TipoComprobante.DescripcionAbrev
         drCtaCte.Letra = ven.Letra
         drCtaCte.CentroEmisor = ven.CentroEmisor
         drCtaCte.NumeroComprobante = ven.NumeroComprobante
         drCtaCte.CuotaNumero = ven.Cuota
         drCtaCte.Fecha = ven.FechaEmision
         drCtaCte.FechaVencimiento = ven.FechaVencimiento
         drCtaCte.ImporteCuota = ven.ImporteCuota
         drCtaCte.SaldoCuota = ven.SaldoCuota
         drCtaCte.DescripcionFormasPago = ven.FormasPagoDescripcion
         drCtaCte.Paga = ven.Paga
         drCtaCte.DescuentoRecargoPorc = ven.DescuentoRecargoPorc
         drCtaCte.DescuentoRecargo = ven.DescuentoRecargo
         drCtaCte.NombreProductos = ven.NombreProductos

         '-- REQ-43063.- -------------------------------------------------------------------------------
         drCtaCte.PromedioDiasCobro = ven.PromedioDiasCobro.IfNull()
         Dim Fecha = DateAdd(DateInterval.Day, ven.PromedioDiasCobro.IfNull(), ven.FechaEmision.Date)
         drCtaCte.DiferenciaVencimiento = DateDiff(DateInterval.Day, ven.FechaVencimiento.Date, Fecha)
         drCtaCte.CantidadDiasCobro = ven.CantidadDiasCobro.IfNull()
         '----------------------------------------------------------------------------------------------

         CtaCtePagosDT.AddCuentasCorrientesPagosRow(drCtaCte)

         TotalAplicado += ven.Paga

      Next

      Dim comprobantesPagados = New StringBuilder()
      Dim qry = From v In recibo.Pagos
                Order By v.IdSucursal, v.IdTipoComprobante, v.Letra, v.CentroEmisor, v.NumeroComprobante, v.Cuota
                Group By v.IdSucursal, v.IdTipoComprobante, v.Letra, v.CentroEmisor, v.NumeroComprobante
                Into Cuotas = Group

      Dim saldoComprobantesPagados As Decimal = 0
      For Each ven In qry

         Dim ctaCteComprobante = New Reglas.CuentasCorrientes().GetUna(ven.IdSucursal, ven.IdTipoComprobante, ven.Letra, ven.CentroEmisor, ven.NumeroComprobante)

         Dim cantidadCuotas As Integer = 0
         If ctaCteComprobante IsNot Nothing Then
            If IsNumeric(ctaCteComprobante.CantidadCuotas) Then
               cantidadCuotas = ctaCteComprobante.CantidadCuotas
               If ((ctaCteComprobante.IdFuncion = "FichasABM2" Or ctaCteComprobante.IdFuncion = "SolicitarCAE") And ctaCteComprobante.TipoComprobante.IdTipoComprobante <> "FICHAS") Then
                  If ctaCteComprobante.Pagos(0).Cuota = 0 Then
                     cantidadCuotas -= 1
                  End If
               End If
            End If
            If IsNumeric(ctaCteComprobante.Saldo) Then
               saldoComprobantesPagados += ctaCteComprobante.Saldo
            End If
         End If

         Dim separador As String = ""
         For Each cuota In ven.Cuotas
            comprobantesPagados.AppendFormat("{2}{0}/{1}", cuota.Cuota, cantidadCuotas, separador)
            separador = ", "
         Next

         Dim productos As System.Text.StringBuilder = New System.Text.StringBuilder()
         separador = ""
         For Each dr As DataRow In New Reglas.VentasProductos().GetNombresProductos(ven.IdSucursal, ven.IdTipoComprobante, ven.Letra, ven.CentroEmisor.ToShort(), ven.NumeroComprobante).Rows
            productos.AppendFormat("{1}{0}", dr("NombreProducto"), separador)
            separador = ", "
         Next

         comprobantesPagados.AppendFormat(" ({0} {3} {4})",
                                          ven.IdTipoComprobante, ven.Letra, ven.CentroEmisor, ven.NumeroComprobante, productos.ToString())
      Next

      Parametros.Add(New ReportParameter("ComprobantesPagados", comprobantesPagados.ToString()))
      Parametros.Add(New ReportParameter("SaldoComprobantesPagados", saldoComprobantesPagados.ToString()))


      Parametros.Add(New ReportParameter("TotalAplicado", TotalAplicado.ToString()))

      ChequesDT = New SistemaDataSet.ChequesDataTable()

      For Each ch In recibo.Cheques
         Dim drCheque = ChequesDT.NewChequesRow()
         drCheque.NumeroCheque = ch.NumeroCheque
         drCheque.IdBanco = ch.Banco.IdBanco
         drCheque.NombreBanco = ch.Banco.NombreBanco
         drCheque.IdBancoSucursal = ch.IdBancoSucursal
         drCheque.IdLocalidad = ch.Localidad.IdLocalidad
         drCheque.FechaCobro = ch.FechaCobro
         drCheque.FechaEmision = ch.FechaEmision
         drCheque.Titular = ch.Titular
         drCheque.Cuit = ch.Cuit
         drCheque.Importe = ch.Importe
         drCheque.IdTipoCheque = ch.IdTipoCheque
         drCheque.NombreTipoCheque = ch.NombreTipoCheque
         ChequesDT.AddChequesRow(drCheque)
      Next

      '# Transferencias
      TransferenciasDT = New SistemaDataSet.CuentasCorrientesTransferenciasDataTable
      For Each t In recibo.CCTransferencias
         Dim row = TransferenciasDT.NewCuentasCorrientesTransferenciasRow
         With row
            .IdSucursal = t.IdSucursal
            .IdTipoComprobante = t.IdTipoComprobante
            .Letra = t.Letra
            .CentroEmisor = t.CentroEmisor
            .NumeroComprobante = t.NumeroComprobante
            .Orden = t.Orden
            .Importe = t.Importe
            .IdCuentaBancaria = t.IdCuentaBancaria
            .NombreCuenta = t.NombreCuenta

            '# Info del registro de Libro Banco
            If t.IdSucursalLibroBanco.HasValue Then
               .IdSucursalLibroBanco = t.IdSucursalLibroBanco.Value
            End If
            If t.IdCuentaBancariaLibroBanco.HasValue Then
               .IdCuentaBancariaLibroBanco = t.IdCuentaBancariaLibroBanco.Value
            End If
            If t.NumeroMovimientoLibroBanco.HasValue Then
               .NumeroMovimientoLibroBanco = t.NumeroMovimientoLibroBanco.Value
            End If
         End With
         TransferenciasDT.AddCuentasCorrientesTransferenciasRow(row)
      Next

      RetencionesDT = New SistemaDataSet.RetencionesDataTable()

      For Each ret In recibo.Retenciones
         Dim drRet = RetencionesDT.NewRetencionesRow()

         Dim formatoNombreTipoImpuesto As String = "{0}"
         If ret.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.RIIBB AndAlso Not String.IsNullOrWhiteSpace(ret.IdProvincia) Then
            formatoNombreTipoImpuesto = "{0} ({1})"
         ElseIf ret.TipoImpuesto.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.RDREI AndAlso Not String.IsNullOrWhiteSpace(ret.NombreLocalidad) Then
            formatoNombreTipoImpuesto = "{0} ({2})"
         End If

         drRet.NombreTipoImpuesto = String.Format(formatoNombreTipoImpuesto, ret.TipoImpuesto.NombreTipoImpuesto, ret.IdProvincia, ret.NombreLocalidad)
         drRet.EmisorRetencion = ret.EmisorRetencion.ToString()
         drRet.NumeroRetencion = ret.NumeroRetencion.ToString()
         drRet.FechaEmision = ret.FechaEmision
         drRet.BaseImponible = ret.BaseImponible
         drRet.Alicuota = ret.Alicuota
         drRet.ImporteTotal = ret.ImporteTotal
         RetencionesDT.AddRetencionesRow(drRet)
      Next

      TarjetasDT = New DataSetCtaCteClientes.VentasTarjetasDataTable()

      For Each ta In recibo.Tarjetas
         Dim drTarjeta = TarjetasDT.NewVentasTarjetasRow()
         drTarjeta.NombreTarjeta = ta.NombreTarjeta
         drTarjeta.NombreBanco = ta.Banco.NombreBanco
         drTarjeta.IdTarjeta = ta.Tarjeta.IdTarjeta
         drTarjeta.IdBanco = ta.Banco.IdBanco
         drTarjeta.NumeroCupon = ta.NumeroCupon
         drTarjeta.NumeroLote = ta.NumeroLote
         drTarjeta.Cuotas = ta.Cuotas
         drTarjeta.Monto = ta.Monto
         TarjetasDT.AddVentasTarjetasRow(drTarjeta)
      Next

      Dim SaldoActual As Decimal = 0
      Dim blnContemplaHora As Boolean = True

      Dim reciboMuestraSaldoImpresion = Reglas.Publicos.CtaCte.ReciboMuestraSaldoImpresion

      If recibo.SaldoCtaCte.HasValue Then
         SaldoActual = recibo.SaldoCtaCte.Value
      Else
         reciboMuestraSaldoImpresion = False
      End If

      If reciboMuestraSaldoImpresion And Not recibo.ImprimeSaldos Then
         reciboMuestraSaldoImpresion = False
      End If

      Parametros.Add(New ReportParameter("SaldoActual", SaldoActual.ToString()))
      Parametros.Add(New ReportParameter("MuestraSaldo", reciboMuestraSaldoImpresion.ToString()))

      ReporteDataSource = String.Empty
      ReporteDataSource2 = String.Empty
      ReporteDataSource3 = String.Empty
      ReporteDataSource4 = String.Empty
      ReporteDataSource5 = String.Empty

      ReporteEmbebido = True
      ReporteDataSource = "SistemaDataSet_CuentasCorrientesPagos"
      ReporteDataSource2 = "SistemaDataSet_Cheques"
      ReporteDataSource3 = "SistemaDataSet_Retenciones"
      ReporteDataSource4 = "SistemaDataSet_CuentasCorrientesTransferencias"
      ReporteDataSource5 = "DataSetCtaCteClientes_VentasTarjetas"

      If recibo.TipoComprobante.GrabaLibro Or blnPorCtaOrden Then
         ReporteNombre = "Eniac.Win.Recibo.rdlc"
      Else
         ReporteNombre = "Eniac.Win.ReciboProvisorio.rdlc"
      End If

      If Not verEstandar Then
         Dim tipoLetra = New Reglas.TiposComprobantesLetras().GetUno(recibo.TipoComprobante.IdTipoComprobante, recibo.Letra)
         If tipoLetra.ArchivoAImprimir <> String.Empty Then
            ReporteNombre = tipoLetra.ArchivoAImprimir
            ReporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
            ConfigImprimir = New ConfiguracionImprimir(tipoLetra.DesplazamientoXArchivoAImprimir, tipoLetra.DesplazamientoYArchivoAImprimir)
            CantidadCopias = tipoLetra.CantidadCopias
            If Not ReporteEmbebido Then
               ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
            End If
         End If
      End If

   End Sub
   Public Shared Sub SeteaParametrosAReporte(reporte As LocalReport, parametros As IEnumerable(Of ReportParameter))
      Dim reporteParametros As ReportParameterInfoCollection = reporte.GetParameters()
      For Each pi In reporteParametros
         For Each pr In parametros
            If pi.Name = pr.Name Then
               reporte.SetParameters(pr)
               Exit For
            End If
         Next
      Next
   End Sub
   Private Property _ConfigImprimir As ConfiguracionImprimir
   Public Property ConfigImprimir As ConfiguracionImprimir
      Get
         If _ConfigImprimir Is Nothing Then
            _ConfigImprimir = New ConfiguracionImprimir(0, 0)
         End If
         Return _ConfigImprimir
      End Get
      Set(value As ConfiguracionImprimir)
         _ConfigImprimir = value
      End Set
   End Property
   Private _cantidadCopias As Integer
   Public Property CantidadCopias() As Integer
      Get
         If _cantidadCopias = 0 Then
            Return 1
         Else
            Return _cantidadCopias
         End If
      End Get
      Set(value As Integer)
         _cantidadCopias = value
      End Set
   End Property

   Public Property ReporteNombreComplementario As String
   Public Property ReporteEmbebidoComplementario As Boolean
   Public Property ReporteNombre() As String
   Public Property ReporteEmbebido As Boolean
   Public Property Titulo() As String
   Public Property Parametros() As List(Of ReportParameter)
   Public Property ReporteDataSource() As String
   Public Property ReporteDataSource2() As String
   Public Property ReporteDataSource3() As String
   Public Property ReporteDataSource4() As String
   Public Property ReporteDataSource5() As String
   Public Property CtaCtePagosDT() As SistemaDataSet.CuentasCorrientesPagosDataTable
   Public Property RetencionesDT() As SistemaDataSet.RetencionesDataTable
   Public Property ChequesDT() As SistemaDataSet.ChequesDataTable
   Public Property TransferenciasDT() As SistemaDataSet.CuentasCorrientesTransferenciasDataTable
   Public Property TarjetasDT() As DataSetCtaCteClientes.VentasTarjetasDataTable

End Class