Public Class ImprimirConcesionarioOperaciones

   Public Sub Ver(operacion As Entidades.ConcesionarioOperacion)
      Using val = GenararReporte(operacion)
         Using frmImprime As New VisorReportes(val.ReporteNombre,
                                            "dtsImpresionesConcesionarios_Producto", val.DtProductos,
                                            "dtsImpresionesConcesionarios_Adicionales", val.DtAdicionales,
                                            "dtsImpresionesConcesionarios_Caracteristicas", val.DtCaracteristicas,
                                            "dtsImpresionesConcesionarios_ResumenMediosPago", val.DtMedioPago,
                                            val.Parametros, val.ReporteEmbebido, cantidadCopias:=1)
            frmImprime.Text = "Operacion"
            frmImprime.ShowDialog()
         End Using
      End Using
   End Sub
   ''''Public Sub Imprimir(operacion As Entidades.ConcesionarioOperacion)
   ''''   Dim val = GenararReporte(operacion)

   ''''   Dim imp = New Imprimir(New ConfiguracionImprimir(0, 0))
   ''''   'imp.Run(val.ReporteNombre, "CuotasDataTable", val.DtCuotas, val.parm, val.ReporteEmbebido, nombreImpresora:=String.Empty, cantidadCopias:=1)

   ''''End Sub
   ''''Public Sub Exportar(operacion As Entidades.ConcesionarioOperacion, pathDestino As String)
   ''''   Dim archivoDestino As String = IO.Path.Combine(pathDestino,
   ''''                                                  String.Format("{0}_{1}_{2}_{3:0000}_{4:00000000}.pdf",
   ''''                                                                Reglas.Publicos.CuitEmpresa,
   ''''                                                                "Operacion", operacion.CodigoOperacion))
   ''''   Dim val = GenararReporte(operacion)
   ''''   Using pdf = New ExportarPDF()
   ''''      'pdf.Run(val.ReporteNombre, "CuotasDataTable", val.DtCuotas, val.parm, val.ReporteEmbebido, archivoDestino)
   ''''   End Using
   ''''End Sub

   Private Function GenararReporte(operacion As Entidades.ConcesionarioOperacion) As ValoresReporte

      Dim valoresReporte = New ValoresReporte()

      AgregarProductoCeroKilometro(operacion, valoresReporte)
      AgregarAdicionalesCeroKilometro(operacion, valoresReporte)
      AgregarCaracteristicasCeroKilometro(operacion, valoresReporte)
      AgregarMediosPago(operacion, valoresReporte)

      AgregarParametros(operacion, valoresReporte)

      valoresReporte.ReporteEmbebido = True
      valoresReporte.ReporteNombre = "Eniac.Win.ConcecionarioOperaciones.rdlc"

      'If tipoLetra.ArchivoAImprimir <> String.Empty And Not tipoLetra.ArchivoAImprimir.Contains(";") Then
      '   ReporteNombre = tipoLetra.ArchivoAImprimir
      '   ReporteEmbebido = tipoLetra.ArchivoAImprimirEmbebido
      '   If Not ReporteEmbebido Then
      '      ReporteNombre = "Reportes\" & tipoLetra.ArchivoAImprimir
      '   End If
      'End If

      Return valoresReporte

   End Function

   Private Shared Sub AgregarProductoCeroKilometro(operacion As Entidades.ConcesionarioOperacion, valoresReporte As ValoresReporte)
      If Not String.IsNullOrWhiteSpace(operacion.IdProductoCeroKilometro) Then
         Dim prod = New Reglas.Productos().GetUno(operacion.IdProductoCeroKilometro, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
         valoresReporte.DtProductos.
            AddConcesionarioOperacionProductoRow(prod.IdProducto,
                                                 prod.NombreProducto,
                                                 operacion.CantidadCeroKilometro.IfNull(),
                                                 operacion.ImporteCeroKilometro.IfNull())
      Else
         valoresReporte.DtProductos.AddConcesionarioOperacionProductoRow(valoresReporte.DtProductos.NewConcesionarioOperacionProductoRow())
      End If
   End Sub
   Private Shared Sub AgregarAdicionalesCeroKilometro(operacion As Entidades.ConcesionarioOperacion, valoresReporte As ValoresReporte)
      operacion.Adicionales.ForEach(
         Sub(adic)
            valoresReporte.DtAdicionales.
               AddConcesionarioOperacionAdicionalRow(adic.IdAdicional,
                                                     adic.NombreAdicional,
                                                     adic.DetalleAdicional,
                                                     adic.PrecioAdicional.ToDecimal())
         End Sub)
      If valoresReporte.DtAdicionales.Count = 0 Then
         valoresReporte.DtAdicionales.AddConcesionarioOperacionAdicionalRow(valoresReporte.DtAdicionales.NewConcesionarioOperacionAdicionalRow())
      End If
   End Sub
   Private Shared Sub AgregarCaracteristicasCeroKilometro(operacion As Entidades.ConcesionarioOperacion, valoresReporte As ValoresReporte)
      Dim agregarCaracteristica = Sub(nombre As String, detalle As String) valoresReporte.DtCaracteristicas.AddConcesionarioOperacionCaracteristicasRow(nombre, detalle)

      Dim tipoUnidad = New Reglas.ConcesionarioTiposUnidades().GetUno(operacion.IdTipoUnidadCeroKilometro, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
      Dim subTipoUnidad = New Reglas.ConcesionarioSubTiposUnidades().GetUno(operacion.IdSubTipoUnidadCeroKilometro, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
      Dim distribEjes = New Reglas.ConcesionarioDistribucionEjes().GetUno(operacion.IdEjeCeroKilometro, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
      Dim campoAdicional = If(subTipoUnidad.SolicitaCantPuertasLaterales, "Cant. Puertas Laterales",
                              If(subTipoUnidad.SolicitaCantPisos, "Cant. Pisos",
                                 If(subTipoUnidad.SolicitaVolumen, "Volumen", String.Empty)))

      agregarCaracteristica("Tipo Unidad", tipoUnidad.NombreTipoUnidad)
      agregarCaracteristica("Sub Tipo Unidad", subTipoUnidad.NombreSubTipoUnidad)
      agregarCaracteristica("Distribución de Ejes", distribEjes.NombreEje)
      agregarCaracteristica(campoAdicional, operacion.CaracteristicaAdicionalCeroKilometro)

      agregarCaracteristica("Largo", operacion.LargoCeroKilometro)
      agregarCaracteristica("Alto de Carga", operacion.AltoCargaCeroKilometro)
      agregarCaracteristica("Alto Puertas Laterales", operacion.AltoPuertgaLateralCeroKilometro)
      agregarCaracteristica("Color Carroceria", operacion.ColorCarroceriaCeroKilometro)
      agregarCaracteristica("Color Zocalo", operacion.ColorZocaloCeroKilometro)
      agregarCaracteristica("Color Base", operacion.ColorBaseCeroKilometro)

      If operacion.PuertaTraseraCeroKilometro.HasValue Then agregarCaracteristica("Puerta Trasera", operacion.PuertaTraseraCeroKilometro.Value.GetDescription())
      If operacion.ParanteCeroKilometro.HasValue Then agregarCaracteristica("Parante", operacion.ParanteCeroKilometro.Value.GetDescription())
      If operacion.MarcoCeroKilometro.HasValue Then agregarCaracteristica("Marco", operacion.MarcoCeroKilometro.Value.GetDescription())
      If operacion.PisoCeroKilometro.HasValue Then agregarCaracteristica("Piso", operacion.PisoCeroKilometro.Value.GetDescription())
      If operacion.HerrajeCeroKilometro.HasValue Then agregarCaracteristica("Herraje", operacion.HerrajeCeroKilometro.Value.GetDescription())

      agregarCaracteristica("Observaciones", operacion.OtrasObservacionesCeroKilometro)
   End Sub
   Private Shared Sub AgregarMediosPago(operacion As Entidades.ConcesionarioOperacion, valoresReporte As ValoresReporte)
      Dim agregarMedioPago = Sub(nombre As String, importe As Decimal?) valoresReporte.DtMedioPago.AddConcesionarioOperacionResumenMediosPagoRow(nombre, importe.IfNull())

      Dim ctaBcaria = New Reglas.CuentasBancarias().GetUna(operacion.IdCuentaBancaria, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)

      agregarMedioPago("Pesos", operacion.ImportePesos)
      agregarMedioPago(String.Format("Transferencia {0}", ctaBcaria.NombreCuenta), operacion.ImporteTransferencia)
      agregarMedioPago("Tarjeta", operacion.ImporteTarjetas)
      agregarMedioPago("Cheques", operacion.ImporteCheques)
      agregarMedioPago("Usados", operacion.ImporteUsado)
   End Sub
   Private Shared Sub AgregarParametros(operacion As Entidades.ConcesionarioOperacion, valoresReporte As ValoresReporte)
      Dim parm = valoresReporte.Parametros

      'Logo
      parm.Add("Logo", "LogoMime", actual.Logo)

      'Datos de la empresa
      parm.Add("DescripcionAdicionalEmpresa", Reglas.Publicos.DescripcionAdicionalEmpresa)
      parm.Add("NombreEmpresa", Reglas.Publicos.NombreEmpresa)
      parm.Add("DireccionEmpresa", String.Format("{0} - {1}", actual.Sucursal.DireccionComercial, actual.Sucursal.LocalidadComercial.NombreLocalidad))
      parm.Add("TelefonoEmpresa", actual.Sucursal.Telefono)

      parm.Add("EmpresaCUIT", Reglas.Publicos.CuitEmpresa)
      parm.Add("FechaInicioActividades", Reglas.Publicos.FechaInicioActividades)
      parm.Add("IngresosBrutos", Reglas.Publicos.IngresosBrutos)
      parm.Add("CategoriaFiscalEmpresaNombre", Reglas.Publicos.CategoriaFiscalEmpresaNombre)

      parm.Add("eMail", actual.Sucursal.Correo.ToString())
      parm.Add("web", Reglas.Publicos.DireccionWebEmpresa)

      'Identificación del comprobante
      parm.Add("TipoComprobante", "Operación")
      parm.Add("CodigoOperacion", operacion.CodigoOperacion)
      parm.Add("Fecha", operacion.FechaOperacion)
      parm.Add("MuestraHoraVenta", Reglas.Publicos.Facturacion.Impresion.VentasImpresionMuestraHoraVenta)

      'Datos Cliente
      parm.Add("NombreYApellido", operacion.Cliente.NombreCliente)
      parm.Add("CodigoCliente", operacion.Cliente.CodigoCliente)

      Dim catFiscal = New Reglas.CategoriasFiscales().GetUno(operacion.Cliente.IdCategoriaFiscal)
      If catFiscal.SolicitaCUIT Then
         parm.Add("TipoIdentificacionFiscal", My.Resources.RTextos.Cuit.ToUpper() + ":")
         parm.Add("NroIdentificaionFiscal", operacion.Cliente.Cuit)
      Else
         parm.Add("TipoIdentificacionFiscal", operacion.Cliente.TipoDocCliente.ToUpper() + ":")
         parm.Add("NroIdentificacionFiscal", operacion.Cliente.NroDocCliente)
      End If

      Dim clte = New Reglas.Clientes().GetUno(operacion.Cliente.IdCliente)

      parm.Add("DireccionCliente", clte.Direccion)
      parm.Add("TelefonoCliente", String.Format("{0} {1}", operacion.Cliente.Telefono, operacion.Cliente.Celular))
      parm.Add("LocalidadCliente", String.Format("{0} ({1}) - {2}", clte.Localidad.NombreLocalidad, clte.Localidad.IdLocalidad.ToString().Truncar(4), clte.Localidad.NombreProvincia))

      parm.Add("CategoriaIVA", catFiscal.NombreCategoriaFiscal)

   End Sub

   Private Class ValoresReporte
      Implements IDisposable
      Public ReporteEmbebido As Boolean
      Public ReporteNombre As String
      Public DtProductos As New dtsImpresionesConcesionarios.ConcesionarioOperacionProductoDataTable()
      Public DtAdicionales As New dtsImpresionesConcesionarios.ConcesionarioOperacionAdicionalDataTable()
      Public DtCaracteristicas As New dtsImpresionesConcesionarios.ConcesionarioOperacionCaracteristicasDataTable()
      Public DtMedioPago As New dtsImpresionesConcesionarios.ConcesionarioOperacionResumenMediosPagoDataTable()
      Public Parametros As New ReportParameterCollection()

#Region "IDisposable Methods"
      Private disposedValue As Boolean
      Protected Overridable Sub Dispose(disposing As Boolean)
         If Not disposedValue Then
            If disposing Then
               ' TODO: dispose managed state (managed objects)
            End If

            DtProductos.Dispose()
            DtAdicionales.Dispose()
            DtCaracteristicas.Dispose()
            DtMedioPago.Dispose()
            Parametros.Clear()

            disposedValue = True
         End If
      End Sub
      Public Sub Dispose() Implements IDisposable.Dispose
         ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
         Dispose(disposing:=True)
         GC.SuppressFinalize(Me)
      End Sub
#End Region
   End Class

End Class