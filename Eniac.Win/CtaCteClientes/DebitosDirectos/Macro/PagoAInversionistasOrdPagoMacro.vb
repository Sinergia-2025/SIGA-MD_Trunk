Public Class PagoAInversionistasOrdPagoMacro

   Private _add As ArchivoPagoAInversionistasOrdPagoMacro

   Public Sub CrearDD(ByVal dt As System.Data.DataTable, ByVal nombreArchivo As String, ByVal FechaAcreditacionMacro As Date, ByVal FechaAcreditacionOtros As Date, ByVal Firmante As String,
                      saldoCtaCte As Boolean)

      Dim i As Integer = 0

      Try
         Me._add = New ArchivoPagoAInversionistasOrdPagoMacro()

         Dim linea As ArchivoPagoAInversionistasOrdPagoMacroDatos

         With Me._add

            For Each dr As DataRow In dt.Rows

               If Boolean.Parse(dr("Selec").ToString()) = False Then
                  Continue For
               End If
               Dim importeAPagar As Decimal = 0
               If IsNumeric(dr("ImporteAPagar")) Then
                  importeAPagar = Decimal.Parse(dr("ImporteAPagar").ToString())
               End If
               If importeAPagar = 0 Then
                  Continue For
               End If
               'If Not IsNumeric(dr("SaldoCtaCte")) Then
               '   Continue For
               'End If

               i += 1

               linea = New ArchivoPagoAInversionistasOrdPagoMacroDatos()

               With linea
                  'DATO	FORMATO	USO	OBSERVACION

                  'Tipo de documento del beneficiario	N 2	obligatorio
                  'por ahora queda Hardcodeado el Nro. 3 que es DNI, tenemos que ver como unificar este criterio.

                  If dr("TipoDocCliente").ToString() = "CUIT" Then
                     .TipoDocumento = 10
                  Else
                     'Es banco Macro
                     If Integer.Parse(dr("CBU").ToString.Trim.Substring(0, 3)) = 285 Then
                        .TipoDocumento = 3  'DNI
                     Else
                        .TipoDocumento = 13  '13 CDI - Nueva disposicion del Banco
                     End If
                  End If

                  'Número de documento del beneficiario	N 14	obligatorio
                  .NroDocumento = Long.Parse(dr("NroDocCliente").ToString())

                  ' Sucursal de Entrega N 3	obligatorio
                  ' nro. de sucursal vigente para las entregas que correspondan, 
                  ' los números de las sucursales puedo mandar un listado con el numero y nombre de la sucursal
                  'TODO: DB
                  '''.SucursalEntrega = Publicos.SucursalBancoPagoAInversionistas

                  'Clave Identificatoria de la Orden de Pago según el cliente. A 30	obligatorio
                  '.OrdenPagoCliente = dr("IdTipoComprobante").ToString() & "-" & dr("Letra").ToString() & "-" & dr("CentroEmisor").ToString() & "-" & dr("NumeroComprobante").ToString()
                  'le envio al Banco el nro. de Cargo
                  .OrdenPagoCliente = "Cargo " + dr("IdCargo").ToString()

                  ' Orden del pago / Razón social  alternativa.	A 40	no obligatorio
                  .OrdenPagoAlt = dr("NombreCliente").ToString()

                  .Importe = importeAPagar

                  'If saldoCtaCte Then
                  '   ' Importe del Pago	D (13,2)	
                  '   .Importe = Decimal.Parse(dr("SaldoCtaCte").ToString())      'Saldo
                  'Else
                  '   .Importe = Decimal.Parse(dr("Saldo").ToString())      'Saldo
                  'End If

                  ' Cuenta de débito 	N 25	obligatorio
                  'TODO: DB
                  '''.CuentaDebito = Publicos.CuentaPagoAInversionistas

                  ' Cuenta de pago	N 25	obligatorio
                  If Not String.IsNullOrEmpty(dr("CBU").ToString()) Then
                     .CuentaPago = dr("CBU").ToString.Trim.Substring(0, 8) & "000" & dr("CBU").ToString.Trim.Substring(8, 14)
                  End If

                  ' Modalidad de Pago N 2	obligatorio
                  ' Por ahora es fijo el nro. 2 - Acreditación en Cuenta para Cuentas Macro  / 4 - Acreditación en Cuenta para cualquier banco
                  If .EsDelBancoMacro Then
                     .FormaPago = 2
                  Else
                     .FormaPago = 4
                  End If

                  ' Marca de Registración de Cheque (Sólo para cheques de pago diferido) N 1	no obligatorio
                  If .FormaPago = 10 Then
                     .RegistCheque = 1
                  Else
                     .RegistCheque = 0
                  End If

                  ' Fecha de Pago date 10	 obligatorio
                  If .EsDelBancoMacro Then
                     .FechaPago = FechaAcreditacionMacro
                  Else
                     .FechaPago = FechaAcreditacionOtros
                  End If

                  'Fecha de Pago Diferido (Requerido solo para modalidad de pago "cheque de pago diferido") date 10	 no obligatorio
                  If .RegistCheque = 1 Then
                     .FechaPagoDiferido = Date.Parse(dr("FechaVencimiento").ToString())
                  Else
                     .FechaPagoDiferido = Nothing
                  End If

                  ' Identificación del Firmante/Autorizante	A 10	
                  .IdentificacionFirmante1 = Firmante

                  ' Identificación del Firmante/Autorizante	A 10	
                  .IdentificacionFirmante2 = ""

                  ' Identificación del Firmante/Autorizante	A 10	
                  .IdentificacionFirmante3 = ""

               End With

               Me._add.Datos.Add(linea)

            Next
            .GrabarArchivo(nombreArchivo)
         End With

         MessageBox.Show("Se Exportaron " + i.ToString() + " ordenes de pago EXITOSAMENTE !!!", "Ordenes de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      End Try
   End Sub

   Public ReadOnly Property NumeroDeRegistros As Integer
      Get
         Return Me._add.Datos.Count
      End Get
   End Property

End Class
