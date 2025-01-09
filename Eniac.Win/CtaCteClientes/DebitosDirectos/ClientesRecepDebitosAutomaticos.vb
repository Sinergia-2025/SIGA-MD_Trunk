Imports System.IO
Imports System.Xml.Serialization
Public Class ClientesRecepDebitosAutomaticos

#Region "Variables"
   Private _arReA As ArchivoDebitoRespuestaRio
   Private _arReB As ArchivoDebitoRespuestaMacro
   Private _arPMC As ArchivoCobranzasPMC
   Private _arRoelaPMC As Entidades.ArchivoRespuestaRoelaPMC
   Private _arSIRPLUS As Entidades.ArchivoRespuestaRoelaPMC
   Private _publicos As Publicos
   Private _tieneModuloCargos As Boolean
   Private _nombreArchivo As String

   Private Const selecColumnName As String = "Proceso"

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            '--------------------------------------------------------------------------
            _publicos.CargaComboCajas(cmbCajas, actual.Sucursal.IdSucursal, miraUsuario:=True, miraPC:=Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja, cajasModificables:=True)
            _publicos.CargaComboEmpleados(cmbCobradores, Entidades.Publicos.TiposEmpleados.COBRADOR)
            _publicos.CargaComboTiposComprobantesRecibo(cmbTipoRecibo, miraPC:=True, tipo1:="CTACTECLIE", esReciboClienteVinculado:=Nothing)
            '--------------------------------------------------------------------------
            CargarParametros()

            _tieneModuloCargos = Reglas.Publicos.TieneModuloCargos

            If _tieneModuloCargos Then
               _publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
               cmbTiposLiquidacion.SelectedIndex = 0
               chbCargo.Checked = True
            Else
               chbCargo.Visible = False
               lblTipoLiquidacion.Visible = False
               cmbTiposLiquidacion.Visible = False
            End If

            tssRegistros.Text = String.Empty
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub LeerArchivo_Click(sender As Object, e As EventArgs) Handles tsbLeerArchivo.Click
      TryCatched(
         Sub()
            tsbLeerArchivo.Enabled = False
            Using daa = New OpenFileDialog()

               Informe_Status("Leyendo archivo....")

               If cmbTipo.SelectedIndex = -1 Then
                  MessageBox.Show("Debe seleccionar un tipo.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  tsbLeerArchivo.Enabled = True
                  cmbTipo.Focus()
                  Exit Sub
               End If

               Select Case cmbTipo.Text
                  Case "Pago Mis Cuentas"
                     daa.Filter = "Archivo de Pago Mis Cuentas (COB*.*)|COB*.*|Todos los Archivos (*.*)|*.*"
                  Case "Macro"
                     daa.Filter = "Todos los Archivos (*.lis)|*.lis"
                  Case "Santander Rio"
                     daa.Filter = "Todos los Archivos (*.deb)|*.deb|Todos los Archivos (*.*)|*.*"
                  Case "SIRPLUS"
                     daa.Filter = "Todos los Archivos (*.xml)|*.xml|Todos los Archivos (*.*)|*.*"

               End Select

               daa.FilterIndex = 1
               daa.RestoreDirectory = True

               If daa.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                  _nombreArchivo = daa.SafeFileName

                  Dim ArchivoImportado As Entidades.ArchivoImportado = New Reglas.ArchivosImportados().GetUno(Me.IdFuncion, Me.cmbTipo.Text.ToString(), _nombreArchivo, actual.Sucursal.IdSucursal)
                  If ArchivoImportado IsNot Nothing Then
                     MessageBox.Show("El archivo ya fue importado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     tsbLeerArchivo.Enabled = True
                     cmbTipo.Focus()
                     Exit Sub
                  End If

                  '-- Cambia tipo de cursor.- --
                  Cursor = Cursors.WaitCursor
                  Try
                     Select Case Me.cmbTipo.Text
                        Case "Macro"
                           Dim arch = New ArchivoDebitoRespuestaMacro()
                           Using rea = New IO.StreamReader(daa.FileName)
                              '-- Informa Status.- -----------------
                              Informe_Status("Cargando archivo....")
                              '-- Proceso de Carga de Archivo.- ----
                              _arReB = arch.GetInfo(rea)
                              '-- Informa Status.- -----------------
                              Informe_Status("Generando información....")
                              '-- Carga datos complementarios.- --
                              txtFechaRespuesta.Text = _arReB.FechaGeneracionDeArchivo.ToString("dd/MM/yyyy")
                              lblNroArchivo.Text = "Nro. Convenio"
                              txtNroDeArchivo.Text = _arReB.NroDeConvenio.ToString()
                              txtImporte.Text = _arReB.ImporteTotalDeMovimientos.ToString("#,##0.00")
                              '-- Carga total de registros.- --
                              tssRegistros.Text = _arReB.Datos.Count.ToString() + " Registros"
                              '-- Asigna origen de datos.- --
                              ugDetalle.DataSource = _arReB.Datos.ToArray()
                           End Using
                        Case "Pago Mis Cuentas"
                           Dim arch = New ArchivoCobranzasPMC()
                           Using reau As New IO.StreamReader(daa.FileName)
                              '-- Informa Status.- -----------------
                              Informe_Status("Cargando archivo....")
                              '-- Proceso de Carga de Archivo.- ----
                              _arPMC = arch.GetInfo(reau)
                              '-- Informa Status.- -----------------
                              Informe_Status("Generando información....")
                           End Using
                           'rea = New IO.StreamReader(daa.FileName)
                           '-- Carga datos complementarios.- --
                           txtFechaRespuesta.Text = _arPMC.FecharArchivo.ToString("dd/MM/yyyy")
                           lblNroArchivo.Text = "Codigo Empresa"
                           txtNroDeArchivo.Text = _arPMC.CodigoEmpresa.ToString()
                           txtImporte.Text = _arPMC.TotalImporte.ToString("#,##0.00")
                           '-- Carga total de registros.- --
                           tssRegistros.Text = _arPMC.Datos.Count.ToString() + " Registros"
                           '-- Asigna origen de datos.- --
                           ugDetalle.DataSource = _arPMC.Datos.ToArray()

                        Case "Santander Rio"
                           Dim arch = New ArchivoDebitoRespuestaRio()
                           Using rea = New IO.StreamReader(daa.FileName)
                              '-- Informa Status.- -----------------
                              Informe_Status("Cargando archivo....")
                              '-- Proceso de Carga de Archivo.- ----
                              _arReA = arch.GetInfo(rea)
                              '-- Informa Status.- -----------------
                              Informe_Status("Generando información....")
                              '-- Carga datos complementarios.- --
                              txtFechaRespuesta.Text = _arReA.FechaPresentacion.ToString("dd/MM/yyyy")
                              txtImporte.Text = _arReA.ImporteTotal.ToString("#,##0.00")
                              '-- Carga total de registros.- --
                              tssRegistros.Text = _arReA.Datos.Count.ToString() + " Registros"
                              '-- Asigna origen de datos.- --
                              ugDetalle.DataSource = _arReA.Datos.ToArray()
                           End Using

                        Case "Roela Pago Mis Cuentas"

                           _arRoelaPMC = New Reglas.CuentasCorrientes().LeerArchivoRoela(daa.FileName, Sub(m) Informe_Status(m))
                           '-- Carga datos complementarios.- --
                           txtFechaRespuesta.Text = _arRoelaPMC.FecharArchivo.ToString("dd/MM/yyyy")
                           lblNroArchivo.Text = "Codigo Empresa"
                           txtNroDeArchivo.Text = "0000"
                           txtImporte.Text = _arRoelaPMC.TotalImporte.ToString("#,##0.00")
                           '-- Carga total de registros.- --
                           tssRegistros.Text = _arRoelaPMC.Datos.Count.ToString() + " Registros"
                           '-- Asigna origen de datos.- --
                           ugDetalle.DataSource = _arRoelaPMC.Datos.ToArray()

                        Case "SIRPLUS"

                           Dim filePath As String = daa.FileName

                           ' Deserialización del archivo XML en la clase Liquidaciones
                           Dim liquidaciones As ArchivoXMLSirplusRecepcion.Liquidaciones = DeserializeFromXmlFile(Of ArchivoXMLSirplusRecepcion.Liquidaciones)(filePath)


                           '-- Carga datos complementarios.- --
                           txtFechaRespuesta.Text = Date.Parse(liquidaciones.Liquidacion.Fecha.ToString()).ToString("dd/MM/yyyy")
                           lblNroArchivo.Text = "Codigo Empresa"
                           txtNroDeArchivo.Text = liquidaciones.Liquidacion.IdCliente.ToString()
                           txtImporte.Text = Decimal.Parse(liquidaciones.Liquidacion.TotalCupones.ToString().Replace(",", ".")).ToString()
                           txtComisiones.Text = Decimal.Parse(liquidaciones.Liquidacion.TotalComision.ToString().Replace(",", ".")).ToString()
                           txtOtrosConceptos.Text = Decimal.Parse(liquidaciones.Liquidacion.TotalConceptos.ToString().Replace(",", ".")).ToString()
                           txtTotalAcreditar.Text = Decimal.Parse(liquidaciones.Liquidacion.TotalLiquidado.ToString().Replace(",", ".")).ToString()

                           '-- Carga total de registros.- --
                           tssRegistros.Text = liquidaciones.Liquidacion.Cupones.Cupon.Count.ToString() + " Registros"

                           _arSIRPLUS = New Entidades.ArchivoRespuestaRoelaPMC()

                           For Each cup In liquidaciones.Liquidacion.Cupones.Cupon
                              Dim dato = New Entidades.ArchivoRespuestaRoelaPMCDatos()
                              dato.FechaDePago = Date.Parse(cup.FechaCobro.ToString())
                              dato.FechaDeAcreditacion = Date.Parse(cup.FechaCobro.ToString()).AddDays(1)
                              '  dato.FechaDeVencimiento = Date.Parse(cup.FechaCobro.ToString())
                              dato.ImportePagado = Decimal.Parse(cup.ImporteCobrado.ToString().Replace(",", "."))
                              dato.IdentificadorDelUsuario = Long.Parse(cup.NumeroCupon.ToString())
                              '    dato.IdentificadorDeConcepto =
                              dato.CodigoDeBarra = cup.CodigoBarras
                              dato.CanalDeCobro = cup.IdEntidad
                              _arSIRPLUS.Datos.Add(dato)
                           Next

                           Validar(_arSIRPLUS, Sub(m) Informe_Status(m))
                           '-- Asigna origen de datos.- --
                           ugDetalle.DataSource = _arSIRPLUS.Datos.ToArray()

                     End Select
                     tsbGenerarPagos.Enabled = True
                     '-- Informa Status.- -----------------
                     Informe_Status("Seteando grillas....")
                     '-- Setea Grilla.- --
                     SeteaGrilla()
                     '-- Carga Columnas de Totales.- --
                     CargarColumnasASumar()
                  Catch Ex As Exception
                     '-- Informa Status.- -----------------
                     Informe_Status("0 Registros.")
                     MessageBox.Show("ATENCION: No se puede leer el archivo. Error: " & Ex.Message)
                  End Try
               End If
            End Using
         End Sub)
      '-- Informa Status.- -----------------
      Informe_Status(String.Empty)
   End Sub
   Public Sub Validar(arDa As Entidades.ArchivoRespuestaRoelaPMC, informeStatus As Action(Of String))
      '-- Variables de Accion y mensaje.- --
      Dim rClientes = New Eniac.Reglas.Clientes()
      Dim rCtaCtePago = New Eniac.Reglas.CuentasCorrientesPagos()

      Dim linea = 0I
      Dim total = arDa.Datos.Count
      For Each dato In arDa.Datos
         Dim accion = "A"
         Dim mensaje = New StringBuilder()
         linea += 1
         informeStatus(String.Format("Validando linea {0}/{1}....", linea, total))

         'Dim cliente = rClientes.GetUnoLivianoPorCodigo(dato.IdentificadorDelUsuario, Eniac.Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
         'If cliente IsNot Nothing Then
         '   dato.NombreCliente = cliente.NombreCliente
         'Else
         '   accion = "X"
         '   mensaje.AppendFormat("Identificador de Cliente inválido - ")
         'End If

         '-- En base al Codigo de Barra busca la Ficha en CuentasCorrientesPagos.- --------------------
         Using dtComprobante = rCtaCtePago.GetPorCodigoBarra(codigoBarra:=Nothing, codigoBarraSirplus:=dato.CodigoDeBarra)
            If dtComprobante IsNot Nothing AndAlso dtComprobante.Rows.Count > 0 Then
               '-- Si lo localiza carga los datos.- --------------------------------
               For Each dr As DataRow In dtComprobante.Rows
                  dato.NombreCliente = dr.Field(Of String)("NombreCliente")
                  dato.IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
                  dato.Letra = dr.Field(Of String)("Letra")
                  dato.CentroEmisor = dr.Field(Of Integer)("CentroEmisor")
                  dato.NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
                  dato.FechaDeVencimiento = dr.Field(Of Date)("FechaVencimiento")
                  dato.Cuota = dr.Field(Of Integer)("CuotaNumero")
                  dato.SaldoCuota = dr.Field(Of Decimal)("SaldoCuota")
                  If dr.Field(Of Decimal)("SaldoCuota") <= 0 Then
                     accion = "X"
                     mensaje.AppendFormat("Saldo Insuficiente para cancelacion de Cuota - ")
                  ElseIf dato.ImportePagado > dr.Field(Of Decimal)("SaldoCuota") Then
                     accion = "D"
                     mensaje.Insert(0, "(ND) Saldo Insuficiente de Cuota se ingresará una Nota de Débito - ")
                  End If
               Next
            Else
               'If cliente IsNot Nothing Then
               '   Using dtAlternativo = rCtaCtePago.GetPorCodigoBarraAlternativo(cliente.IdCliente, dato.FechaDeVencimiento, dato.ImportePagado)
               '      If dtAlternativo IsNot Nothing AndAlso dtAlternativo.Rows.Count > 0 Then
               '         For Each dr As DataRow In dtAlternativo.Rows
               '            dato.CodigoDeBarra = dr.Field(Of String)("CodigoDeBarra")
               '            dato.IdTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
               '            dato.Letra = dr.Field(Of String)("Letra")
               '            dato.CentroEmisor = dr.Field(Of Integer)("CentroEmisor")
               '            dato.NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
               '            dato.Cuota = dr.Field(Of Integer)("CuotaNumero")
               '            dato.SaldoCuota = dr.Field(Of Decimal)("SaldoCuota")
               '            If dr.Field(Of Decimal)("SaldoCuota") <= 0 Then
               '               accion = "X"
               '               mensaje.AppendFormat("Saldo Insuficiente para cancelacion de Cuota - ")
               '            ElseIf dato.ImportePagado > dr.Field(Of Decimal)("SaldoCuota") Then
               '               accion = "D"
               '               mensaje.Insert(0, "(ND) Saldo Insuficiente de Cuota se ingresará una Nota de Débito - ")
               '            End If
               '         Next
               '      Else
               '         accion = "X"
               '         mensaje.AppendFormat("Codigo de Barra Inexistente - ")
               '      End If
               '   End Using
               'Else
               accion = "X"
               mensaje.AppendFormat("Codigo de Barra Inexistente - ")
               '    End If
            End If
         End Using

         '-- Carga Mensajes.- --
         dato.Proceso = accion = "A" Or accion = "D"
         dato.Accion = accion
         dato.Mensaje = mensaje.ToString()
         '----------------------
      Next

   End Sub
   Public Function DeserializeFromXmlFile(Of T)(ByVal filePath As String) As T
      Dim result As T = Nothing

      Try
         Dim serializer As New XmlSerializer(GetType(T))

         Using fileStream As FileStream = New FileStream(filePath, FileMode.Open)
            result = DirectCast(serializer.Deserialize(fileStream), T)
         End Using
      Catch ex As Exception
         Console.WriteLine("Error al deserializar el archivo XML: " & ex.Message)
      End Try

      Return result
   End Function

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         UltraGridPrintDocument1.Header.TextCenter = Environment.NewLine +
               "Rendición " +
               Environment.NewLine +
               txtFechaRespuesta.Text + " --- " + lblNroArchivo.Text + " " + txtNroDeArchivo.Text
         UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 5
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 5
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 14
         UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 8
         UltraGridPrintDocument1.Footer.TextCenter = "Fecha: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, String.Empty))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, String.Empty))
   End Sub

   Private Sub tsbGenerarPagos_Click(sender As Object, e As EventArgs) Handles tsbGenerarPagos.Click

      Try
         Informe_Status("Generando pagos....")

         If Not Me.bscCuentaBancariaTransfBanc.Selecciono() And Not bscCodigoCuentaBancariaTransfBanc.Selecciono Then
            MessageBox.Show("Falta cargar la Cuenta Bancaria.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCuentaBancariaTransfBanc.Focus()
            Exit Sub
         End If

         If cmbTipoRecibo.SelectedIndex < 0 Then
            ShowMessage("Falta seleccionar un Tipo de Recibo.")
            Me.cmbTipoRecibo.Focus()
            Exit Sub
         End If

         If Me.cmbCajas.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar la Caja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbCajas.Focus()
            Exit Sub
         End If

         If cmbCobradores.SelectedIndex < 0 Then
            ShowMessage("Falta seleccionar un Cobrador.")
            Me.cmbCobradores.Focus()
            Exit Sub
         End If

         If Me.dtpFecha.Value.Date > Date.Now.Date Then
            MessageBox.Show("La Fecha del Recibo NO puede ser Mayor al dia de Hoy.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            Exit Sub
         End If

         Me.tsbGenerarPagos.Enabled = False

         If MessageBox.Show("¿Desea Realizar Todos los Pagos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Informe_Status("Armando datos....")

            Dim ctacte As Reglas.CtaCteClienteRecibo = New Reglas.CtaCteClienteRecibo()
            Dim reg As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
            Dim oCuentaCorriente As Eniac.Entidades.CuentaCorriente
            Dim cli As Entidades.Cliente
            Dim regCli As Reglas.Clientes = New Reglas.Clientes()
            Dim ven As Eniac.Entidades.Empleado
            Dim idFormaPago As Integer = 1 'Contado
            Dim listadosCtasCtes As List(Of Eniac.Entidades.CuentaCorriente) = New List(Of Eniac.Entidades.CuentaCorriente)()

            Dim IdCuentaBancaria As Integer = Integer.Parse(Me.bscCodigoCuentaBancariaTransfBanc.Text.ToString())
            Dim IdCaja As Integer = 0

            Dim tipoComprobante As Entidades.TipoComprobante = DirectCast(cmbTipoRecibo.SelectedItem, Entidades.TipoComprobante)
            Dim cobrador As Entidades.Empleado = DirectCast(cmbCobradores.SelectedItem, Entidades.Empleado)

            Dim idTipoLiquidacion As Integer? = Nothing

            If Me._tieneModuloCargos AndAlso Me.chbCargo.Checked Then
               idTipoLiquidacion = Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString())
            End If


            Dim i As Integer = 0
            Dim roelaResult As Entidades.CuentasCorrientesGenerarPagosRoelaResult = Nothing

            Select Case Me.cmbTipo.Text
               Case "Macro"
                  For Each arc As ArchivoDebitoRespuestaMacroDatos In Me._arReB.Datos

                     'si el codigo de motivo o rechazo es distinto de vacio, no se va a aplicar el pago a ese cliente
                     If Not String.IsNullOrEmpty(arc.CodigoDeMotivoORechazo.Trim()) Then
                        Continue For
                     End If

                     Informe_Status(String.Format("Generando pago {0}.", i))

                     i += 1
                     cli = regCli.GetUnoPorCodigo(arc.IdentificacionActualDelAdherente, False)
                     If String.IsNullOrEmpty(cli.NombreCliente) Then
                        Throw New Exception("El cliente identificado en la linea " + i.ToString() + " NO existe en los registros, controle esta información.")
                     End If

                     Dim letra As String = tipoComprobante.LetrasHabilitadas
                     'Si tiene configurado mas de una Letra (A,B,C) significa que la toma de la categoria fiscal en lugar de fija (R o X)
                     If letra.Trim.Length > 1 Then
                        letra = cli.CategoriaFiscal.LetraFiscal
                     End If

                     ven = cli.Vendedor

                     If cli.IdCaja > 0 Then
                        IdCaja = cli.IdCaja
                     Else
                        IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
                     End If

                     ''''armar el ctactepagos......

                     'Reemplazado Observacion por arc.DatosDelRetorno

                     oCuentaCorriente = ctacte.GetCtaCteCliente(tipoComprobante.IdTipoComprobante, letra, numeroComprobante:=0,
                                                  dtpFecha.Value,
                                                  idFormaPago,
                                                  cli, ven, cobrador,
                                                  "DEBITO AUTOMATICO",
                                                  arc.ImporteADebitar,
                                                  importeEfectivo:=0, importeDolares:=0, importeTarjetas:=0, importeTransferencia:=arc.ImporteADebitar,
                                                  IdCuentaBancaria,
                                                  IdCaja,
                                                  pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                  nroOrdenCompra:=0)
                     listadosCtasCtes.Add(oCuentaCorriente)
                  Next

               Case "Pago Mis Cuentas"
                  'CHEQUEAR
                  For Each arc As ArchivoCobranzasPMCDatos In Me._arPMC.Datos
                     i += 1
                     cli = regCli.GetUnoPorTipoYNroDocumento("DNI", Long.Parse(arc.NroReferencia.Trim()))
                     If cli Is Nothing Then
                        cli = regCli.GetUnoPorCUIT(arc.NroReferencia.Trim())
                     End If
                     If String.IsNullOrEmpty(cli.NombreCliente) Then
                        Throw New Exception("El cliente identificado en la linea " + i.ToString() + " NO existe en los registros, controle esta información.")
                     End If

                     Dim letra As String = tipoComprobante.LetrasHabilitadas
                     'Si tiene configurado mas de una Letra (A,B,C) significa que la toma de la categoria fiscal en lugar de fija (R o X)
                     If letra.Trim.Length > 1 Then
                        letra = cli.CategoriaFiscal.LetraFiscal
                     End If

                     ven = cli.Vendedor

                     'If cli.Categoria.IdCaja > 0 Then
                     '   IdCaja = cli.Categoria.IdCaja
                     'Else
                     IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
                     'End If

                     Dim observ As String = "COBRO REALIZADO VIA: "
                     Select Case arc.CanalPago
                        Case "PC"
                           observ += "PAGO MIS CUENTAS"
                        Case "HB"
                           observ += "HOME BANKING"
                        Case "S1"
                           observ += "CAGERO AUTOMATICO (ATM)"
                        Case Else
                           observ += arc.CanalPago
                     End Select

                     oCuentaCorriente = ctacte.GetCtaCteCliente(tipoComprobante.IdTipoComprobante, letra, numeroComprobante:=0,
                                                   Date.Now,
                                                   idFormaPago,
                                                   cli, ven, cobrador,
                                                   observ,
                                                   arc.Importe,
                                                   importeEfectivo:=0, importeDolares:=0, importeTarjetas:=0, importeTransferencia:=arc.Importe,
                                                   IdCuentaBancaria,
                                                   IdCaja,
                                                   pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                   nroOrdenCompra:=0)

                     listadosCtasCtes.Add(oCuentaCorriente)

                  Next
               Case "Santander Rio"
                  Dim dicPagos As Dictionary(Of String, DatosParaRecibo) = New Dictionary(Of String, DatosParaRecibo)()
                  For Each arc As ArchivoDebitoRespuestaRioDatos In Me._arReA.Datos
                     'si el codigo de motivo o rechazo es distinto de vacio, no se va a aplicar el pago a ese cliente
                     If arc.CodigoError <> "000" Then
                        Continue For
                     End If

                     Dim key As String = String.Format("{0:00000000}", arc.Partida, arc.IdentificacionDebito)

                     If Not dicPagos.ContainsKey(key) Then
                        dicPagos.Add(key, New DatosParaRecibo(arc.Partida))
                     End If
                     dicPagos(key).ImporteDebitar += arc.ImporteDebito
                  Next
                  For Each par As KeyValuePair(Of String, DatosParaRecibo) In dicPagos
                     i += 1
                     cli = regCli.GetUnoPorCodigo(par.Value.CodigoCliente)
                     If String.IsNullOrEmpty(cli.NombreCliente) Then
                        Throw New Exception("El cliente identificado en la linea " + i.ToString() + " NO existe en los registros, controle esta información.")
                     End If

                     Dim letra As String = tipoComprobante.LetrasHabilitadas
                     'Si tiene configurado mas de una Letra (A,B,C) significa que la toma de la categoria fiscal en lugar de fija (R o X)
                     If letra.Trim.Length > 1 Then
                        letra = cli.CategoriaFiscal.LetraFiscal
                     End If

                     ven = cli.Vendedor

                     IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

                     'armar el ctactepagos......

                     'Reemplazado Observacion por arc.DatosDelRetorno
                     oCuentaCorriente = ctacte.GetCtaCteCliente(tipoComprobante.IdTipoComprobante, letra, numeroComprobante:=0,
                                                                dtpFecha.Value,
                                                                idFormaPago,
                                                                cli, ven, cobrador,
                                                                "DEBITO AUTOMATICO",
                                                                par.Value.ImporteDebitar,
                                                                importeEfectivo:=0, importeDolares:=0, importeTarjetas:=0, importeTransferencia:=par.Value.ImporteDebitar,
                                                                IdCuentaBancaria,
                                                                IdCaja,
                                                                pagos:=Nothing, cheques:=Nothing, tarjetas:=Nothing, retenciones:=Nothing,
                                                                nroOrdenCompra:=0)
                     'arc.ImporteDebito
                     listadosCtasCtes.Add(oCuentaCorriente)
                  Next
               Case "Roela Pago Mis Cuentas"
                  roelaResult = reg.GenerarPagosRoela(_arRoelaPMC, tipoComprobante, cmbCajas.ValorSeleccionado(Of Integer), idFormaPago, cobrador, IdCuentaBancaria,
                                                      IdFuncion, idTipoLiquidacion, cmbTipo.Text.ToString(), _nombreArchivo,
                                                      Sub(m) Informe_Status(m))
                  i = roelaResult.CantidadRegistros

               Case "SIRPLUS"
                  roelaResult = reg.GenerarPagosSIRPLUS(_arSIRPLUS, tipoComprobante, cmbCajas.ValorSeleccionado(Of Integer), idFormaPago, cobrador, IdCuentaBancaria,
                                                      IdFuncion, idTipoLiquidacion, cmbTipo.Text.ToString(), _nombreArchivo,
                                                      Sub(m) Informe_Status(m))
                  i = roelaResult.CantidadRegistros
            End Select

            'voy a grabar en la base de datos todas las cuentas corrientes del archivo
            Informe_Status("Generando pagos....")

            If listadosCtasCtes.Count > 0 Then
               reg.GrabarPagosAutomaticos(listadosCtasCtes, Entidades.Entidad.MetodoGrabacion.Automatico, Me.IdFuncion, idTipoLiquidacion, Me.cmbTipo.Text.ToString(), _nombreArchivo, True)
            End If

            MessageBox.Show("Se grabaron exitosamente los " + i.ToString() + " registros.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            If roelaResult IsNot Nothing AndAlso roelaResult.CantidadNotasDebitoElectronicas > 0 Then
               Using frm = New SolicitarCAE()
                  frm.IdFuncion = IdFuncion
                  frm.ConsultarAutomaticamente = True
                  frm.ShowDialog(Me)
               End Using
            End If

            'ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
            ugDetalle.Rows.Refresh(RefreshRow.FireInitializeRow)
            'tsbRefrescar.PerformClick()
         Else
            tsbGenerarPagos.Enabled = True
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         tssRegistros.Text = ""
         tssInfo.Text = ""
      End Try

   End Sub


   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCuentaBancariaTransfBanc)
            bscCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorNombre(bscCuentaBancariaTransfBanc.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscCodigoCuentaBancariaTransfBanc_BuscadorClick() Handles bscCodigoCuentaBancariaTransfBanc.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaCuentasBancarias2(bscCodigoCuentaBancariaTransfBanc)
            bscCodigoCuentaBancariaTransfBanc.Datos = New Reglas.CuentasBancarias().GetFiltradoPorCodigo(bscCodigoCuentaBancariaTransfBanc.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion, bscCodigoCuentaBancariaTransfBanc.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
               bscCodigoCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
               dtpFecha.Focus()
            End If
         End Sub)
   End Sub

   Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
      TryCatched(
         Sub()
            If cmbTipo.Text = "Santander Rio" Then
               lblNroArchivo.Visible = False
               txtNroDeArchivo.Visible = False
            Else
               lblNroArchivo.Visible = True
               txtNroDeArchivo.Visible = True
            End If
         End Sub)
   End Sub

   Private Sub chbCargo_CheckedChanged(sender As Object, e As EventArgs) Handles chbCargo.CheckedChanged
      TryCatched(
         Sub()
            If chbCargo.Checked Then
               cmbTiposLiquidacion.Enabled = True
            Else
               cmbTiposLiquidacion.Enabled = False
            End If
         End Sub)
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
         Sub()
            Select Case cmbTipo.Text
               Case "Roela Pago Mis Cuentas"
                  Dim dr = ugDetalle.FilaSeleccionada(Of Entidades.ArchivoRespuestaRoelaPMCDatos)(e.Row)
                  If dr IsNot Nothing Then
                     If dr.Accion = "X" Then
                        e.Row.Cells("Proceso").Color(Color.White, Color.Red)
                        e.Row.Cells("Accion").Color(Color.White, Color.Red)
                     ElseIf dr.Accion = "E" Then
                        e.Row.Cells("Proceso").Color(Color.White, Color.Red)
                        e.Row.Cells("Accion").Color(Color.White, Color.Red)
                     ElseIf dr.Accion = "D" Then
                        e.Row.Cells("Proceso").Color(Color.Black, Color.Yellow)
                        e.Row.Cells("Accion").Color(Color.Black, Color.Yellow)
                     ElseIf dr.Accion = "I" Then
                        e.Row.Cells("Proceso").Color(Color.Black, Color.LightGreen)
                        e.Row.Cells("Accion").Color(Color.Black, Color.LightGreen)
                     Else
                        e.Row.Cells("Proceso").Color(Nothing, Nothing)
                        e.Row.Cells("Accion").Color(Nothing, Nothing)
                     End If
                  End If
            End Select
         End Sub)
   End Sub
#End Region

#Region "Metodos"
   ''' <summary>
   ''' Procedimiento de MArcado de Grilla.- 
   ''' </summary>
   Private Sub AgregarNovedadesSeleccionadas()
      ugDetalle.UpdateData()
   End Sub
   ''' <summary>
   ''' Informa status de proceso.
   ''' </summary>
   ''' <param name="sMensaje">Mensaje para mostrar</param>
   Private Sub Informe_Status(sMensaje As String)
      Me.tssInfo.Text = sMensaje
      Application.DoEvents()
   End Sub

   Private Sub CargarParametros()
      If Reglas.Publicos.CtaCte.DebitoAutomaticoCuentaBancariaTransfBanc > 0 Then
         bscCodigoCuentaBancariaTransfBanc.Text = Reglas.Publicos.CtaCte.DebitoAutomaticoCuentaBancariaTransfBanc.ToString()
         bscCodigoCuentaBancariaTransfBanc.Visible = True
         bscCodigoCuentaBancariaTransfBanc.PresionarBoton()
         bscCodigoCuentaBancariaTransfBanc.Visible = False
      End If
      If IsNumeric(Reglas.Publicos.CtaCte.DebitoAutomaticoCajaCtaBancariaTransfBanc) Then
         cmbCajas.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoCajaCtaBancariaTransfBanc
      End If
      cmbCajas.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoCajaCtaBancariaTransfBanc
      cmbTipoRecibo.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoTipoReciboCtaBancariaTransf
      cmbCobradores.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoCobradorCtaBancariaTransf
   End Sub

   Private Class DatosParaRecibo
      Public Property CodigoCliente As Long
      Public Property ImporteDebitar As Decimal
      Public Sub New(idCliente As Long)
         Me.CodigoCliente = idCliente
      End Sub
   End Class

   ''' <summary>
   ''' Refresca Datos de la Grilla.- --
   ''' </summary>
   Private Sub RefrescarDatosGrilla()
      CargarParametros()
      Me.txtFechaRespuesta.Text = ""
      Me.txtNroDeArchivo.Text = ""
      Me.txtImporte.Text = ""
      Me.bscCuentaBancariaTransfBanc.Text = ""

      Me.dtpFecha.Value = Date.Now()
      Me.tsbLeerArchivo.Enabled = True

      If TypeOf (ugDetalle.DataSource) Is IList Then
         ugDetalle.DataSource = Nothing
      End If

   End Sub

   ''' <summary>
   ''' Setea Formato de Columnas de la Grilla.-
   ''' </summary>
   Private Sub SeteaGrilla()
      With Me.ugDetalle.DisplayLayout.Bands(0)

         'oculto todas las columnas por si en algún momento agrego mas al query de la consulta
         For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
            col.Hidden = True
            col.CellActivation = UltraWinGrid.Activation.NoEdit
         Next

         Dim pos As Integer = 0
         Select Case Me.cmbTipo.Text
            Case "Macro"
               .Columns("CuentaBancariaDelAdherente").FormatearColumna("Cuenta", pos, 120, HAlign.Right)
               .Columns("IdentificacionActualDelAdherente").FormatearColumna("Código", pos, 70, HAlign.Right)
               .Columns("NombreCliente").FormatearColumna("Cliente", pos, 200)
               .Columns("NombreCategoria").FormatearColumna("Categoría", pos, 100)
               .Columns("NombreCaja").FormatearColumna("Caja", pos, 80)
               .Columns("Saldo").FormatearColumna("Saldo C.C.", pos, 80, HAlign.Right, , "N2")
               .Columns("ImporteADebitar").FormatearColumna("Importe", pos, 80, HAlign.Right, , "N2")
               .Columns("MotivoRechazo").FormatearColumna("Motivo Rechazo", pos, 190)
               .Columns("Alerta").FormatearColumna("Alerta", pos, 40, HAlign.Center)

               ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "MotivoRechazo"})

            Case "Pago Mis Cuentas"
               .Columns("NroReferencia").FormatearColumna("Nro. Referencia", pos, 105, HAlign.Right)
               .Columns("IdFactura").FormatearColumna("Factura", pos, 150, HAlign.Right)
               .Columns("NombreCliente").FormatearColumna("Cliente", pos, 200)
               .Columns("Importe").FormatearColumna("Importe", pos, 80, HAlign.Right, , "N2")
               .Columns("NroControl").FormatearColumna("Nro. Control", pos, 85, HAlign.Right)
               .Columns("FechaDeVencimiento").FormatearColumna("Vencimiento", pos, 85, HAlign.Center)

               ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})

            Case "Santander Rio"
               .Columns("Servicio").FormatearColumna("Servicio", pos, 100)
               .Columns("Partida").FormatearColumna("Código", pos, 100)
               .Columns("CBU").FormatearColumna("CBU", pos, 150)
               .Columns("NombreCliente").FormatearColumna("Cliente", pos, 200)
               .Columns("ImporteDebito").FormatearColumna("Importe", pos, 80, HAlign.Right, , "N2")
               .Columns("FechaDeVencimiento").FormatearColumna("Vencimiento", pos, 85, HAlign.Center)
               .Columns("IdentificacionDebito").FormatearColumna("Comprobante", pos, 90)
               .Columns("CodigoError").FormatearColumna("Código Error", pos, 100, HAlign.Right)
               .Columns("ReferenciaEmpresa").FormatearColumna("Referencia Empresa", pos, 200)

               ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})

            Case "Roela Pago Mis Cuentas"
               '-------------------------------------------------------------------------------------------
               .Columns("Proceso").FormatearColumna("Estado", pos, 50, HAlign.Center)
               .Columns("Accion").FormatearColumna("Accion", pos, 50, HAlign.Center)
               '-------------------------------------------------------------------------------------------
               .Columns("IdentificadorDelUsuario").FormatearColumna("Identificador del Usuario", pos, 80, HAlign.Right)
               .Columns("NombreCliente").FormatearColumna("Cliente", pos, 200)
               .Columns("FechaDePago").FormatearColumna("Fecha de Pago", pos, 80, HAlign.Center)
               .Columns("FechaDeAcreditacion").FormatearColumna("Fecha de Acreditacion", pos, 80, HAlign.Center)
               .Columns("FechaDeVencimiento").FormatearColumna("Fecha de Vencimiento", pos, 80, HAlign.Center)
               .Columns("ImportePagado").FormatearColumna("Importe Pagado", pos, 100, HAlign.Right, , "N2")
               .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 80)
               .Columns("Letra").FormatearColumna("Letra", pos, 40, HAlign.Center)
               .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 60, HAlign.Right)
               .Columns("NumeroComprobante").FormatearColumna("Numero", pos, 90, HAlign.Right)
               .Columns("Cuota").FormatearColumna("Cuota", pos, 40, HAlign.Right)
               .Columns("SaldoCuota").FormatearColumna("Saldo Cuota", pos, 90, HAlign.Right, , "N2")
               .Columns("CanalDeCobro").FormatearColumna("Canal de Cobro", pos, 85)
               .Columns("CodigoDeBarra").FormatearColumna("Codigo de Barra", pos, 350)
               '-------------------------------------------------------------------------------------------
               .Columns("Mensaje").FormatearColumna("Mensaje Error", pos, 240, HAlign.Left)
               '-------------------------------------------------------------------------------------------
               ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})
            Case "SIRPLUS"
               '-------------------------------------------------------------------------------------------
               .Columns("Proceso").FormatearColumna("Estado", pos, 50, HAlign.Center)
               .Columns("Accion").FormatearColumna("Accion", pos, 50, HAlign.Center)
               '-------------------------------------------------------------------------------------------
               .Columns("IdentificadorDelUsuario").FormatearColumna("Identificador del Usuario", pos, 80, HAlign.Right)
               .Columns("NombreCliente").FormatearColumna("Cliente", pos, 200)
               .Columns("FechaDePago").FormatearColumna("Fecha de Pago", pos, 80, HAlign.Center)
               .Columns("FechaDeAcreditacion").FormatearColumna("Fecha de Acreditacion", pos, 80, HAlign.Center)
               .Columns("FechaDeVencimiento").FormatearColumna("Fecha de Vencimiento", pos, 80, HAlign.Center)
               .Columns("ImportePagado").FormatearColumna("Importe Pagado", pos, 100, HAlign.Right, , "N2")
               .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 80)
               .Columns("Letra").FormatearColumna("Letra", pos, 40, HAlign.Center)
               .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 60, HAlign.Right)
               .Columns("NumeroComprobante").FormatearColumna("Numero", pos, 90, HAlign.Right)
               .Columns("Cuota").FormatearColumna("Cuota", pos, 40, HAlign.Right)
               .Columns("SaldoCuota").FormatearColumna("Saldo Cuota", pos, 90, HAlign.Right, , "N2")
               .Columns("CanalDeCobro").FormatearColumna("Canal de Cobro", pos, 85, HAlign.Right)
               .Columns("CodigoDeBarra").FormatearColumna("Codigo de Barra", pos, 350)
               '-------------------------------------------------------------------------------------------
               .Columns("Mensaje").FormatearColumna("Mensaje Error", pos, 240, HAlign.Left)
               '-------------------------------------------------------------------------------------------
               ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})
         End Select

      End With
   End Sub

   ''' <summary>
   ''' Carga columnas de Suma de totales.- 
   ''' </summary>
   Private Sub CargarColumnasASumar()
      Select Case Me.cmbTipo.Text
         Case "Macro"
            ugDetalle.AgregarTotalesSuma({"ImporteADebitar"})
         Case "Pago Mis Cuentas"
            ugDetalle.AgregarTotalesSuma({"Importe"})
         Case "Santander Rio"
            ugDetalle.AgregarTotalesSuma({"ImporteDebito"})
      End Select
   End Sub
   Private Sub SupervisaGrilla()
      Dim dt = DirectCast(ugDetalle.DataSource, DataTable)
      tsbGenerarPagos.Enabled = Not dt.AsEnumerable().Any(Function(dr) dr.Field(Of String)("EstadoExportacion") <> "A")  'drCol.Length = 0
   End Sub

   Private Sub cmbTipoRecibo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoRecibo.SelectedIndexChanged
      TryCatched(
         Sub()

         End Sub)
   End Sub
#End Region

End Class