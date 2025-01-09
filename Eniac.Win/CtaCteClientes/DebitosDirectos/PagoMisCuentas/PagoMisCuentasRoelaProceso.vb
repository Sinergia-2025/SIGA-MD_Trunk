Public Class PagoMisCuentasRoelaProceso
   Implements IDebitosDirectosProceso

   Private _add As ArchivoRoelaPMC

   Public Sub CrearDD(dt As System.Data.DataTable,
                     banco As Eniac.Entidades.Banco,
                     nombreArchivo As String,
                     fechaVencimiento As Date,
                      nroRefinanciacion As Integer) Implements IDebitosDirectosProceso.CrearDD
      Dim i As Integer = 0

      Try
         Me._add = New ArchivoRoelaPMC()

         Dim linea As ArchivoRoelaPMCDatos
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         'en la primera linea tengo que cargar los datos de la cabecera****************************************************
         With Me._add

            'Nro. de empresa asignado por Banelco. 
            'TODO: DB
            '.CodigoEmpresa = Publicos.NumeroEmpresaBanelco

            ' Fecha de generación del archivo.Formato: AAAAMMDD
            .FechaArchivo = DateTime.Now()

            'desde la segunda linea en adelante tengo que cargar todos los registros.****************************************
            For Each dr As DataRow In dt.Select("Selec = True")

               linea = New ArchivoRoelaPMCDatos()

               With linea

                  ' Identificación del cliente en la empresa. 
                  .NroReferencia = dr("ReferenciaPMC").ToString().ValorNumericoPorDefecto(0L)

                  Dim fecha As Date
                  ' fecha = fechaVencimiento.AddDays(-30)
                  fecha = fechaVencimiento
                  .FechaPeriodo = Date.Parse(dr("FechaVencimiento").ToString())  '' fechaVencimiento
                  ' Identificación de la factura.       6 pos tipo comprobante, 1 pos letra, 3 pos emisor, 7 pos nro comprobante , 3 cuota
                  .IdFactura = dr("CodigoRoela").ToString() & dr("Letra").ToString() & Integer.Parse(dr("CentroEmisor").ToString()).ToString("00") &
                                 Long.Parse(dr("NumeroComprobante").ToString()).ToString("000000000") & Integer.Parse(dr("CuotaNumero").ToString()).ToString("00")

                  ' Fecha del 1er vencimiento de la factura
                  .Fecha1erVencimiento = Date.Parse(dr("FechaVencimiento").ToString())

                  ' Importe de la factura para el 1er vencimiento.
                  .Importe1erVencimiento = Decimal.Parse(dr("Saldo").ToString())

                  If Not String.IsNullOrEmpty(dr("FechaVencimiento2").ToString()) Then
                     ' Fecha del 2do vencimiento de la factura
                     .Fecha2doVencimiento = Date.Parse(dr("FechaVencimiento2").ToString())
                     ' Importe de la factura para el 2do vencimiento.
                     .Importe2doVencimiento = Decimal.Parse(dr("ImporteVencimiento2").ToString())

                  Else
                     .Fecha2doVencimiento = .Fecha1erVencimiento
                     .Importe2doVencimiento = .Importe1erVencimiento
                  End If

                  If Not String.IsNullOrEmpty(dr("FechaVencimiento2").ToString()) And Not String.IsNullOrEmpty(dr("FechaVencimiento3").ToString()) Then
                     ' Fecha del 3er vencimiento de la factura
                     .Fecha3erVencimiento = Date.Parse(dr("FechaVencimiento3").ToString())

                     ' Importe de la factura para el 3er vencimiento.
                     .Importe3erVencimiento = Decimal.Parse(dr("ImporteVencimiento3").ToString())
                  Else
                     .Fecha3erVencimiento = .Fecha2doVencimiento
                     .Importe3erVencimiento = .Importe2doVencimiento
                  End If


                  ' Datos a informar en el ticket de pago. 
                  'TODO: DB
                  ' ''If Publicos.CargosCalcularPor = "CAMA" And dr("Observacion").ToString().StartsWith("Periodo") Then
                  ' ''   .MensajeTicket = dr("Observacion").ToString().Substring(0, Math.Min(30, dr("Observacion").ToString().Length))
                  ' ''Else
                  ' ''   .MensajeTicket = "Periodo: " & CDate(dr("Fecha")).ToString("yyyy/MM")
                  ' ''End If

                  ' Código de barras.
                  .CodigoBarras = dr("CodigoDeBarra").ToString()

                  .NroRefinanciacion = nroRefinanciacion

               End With

               Me._add.Datos.Add(linea)

            Next

            .GrabarArchivo(nombreArchivo)
         End With

         If stb.Length > 0 Then
            MessageBox.Show(stb.ToString(), "Debitos Directos", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      End Try
   End Sub

   Public ReadOnly Property NumeroDeRegistros As Integer Implements IDebitosDirectosProceso.NumeroDeRegistros
      Get
         Return Me._add.Datos.Count
      End Get
   End Property


End Class
