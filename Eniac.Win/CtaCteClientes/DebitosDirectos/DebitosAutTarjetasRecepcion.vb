Imports System.IO
Public Class DebitosAutTarjetasRecepcion

   Private _arReB As ArchivoRendicionVisa
   Private _arPMC As ArchivoRendicionMaster
   Private _publicos As Publicos
   Private _publicosEniac As Eniac.Win.Publicos
   Private _nombreArchivo As String

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try
         'TODO: DB
         ''Dim existeAlgunaFoto As Boolean = New Reglas.Liquidaciones().ExisteFoto(0, Nothing)
         ''chbTomaFoto.Visible = existeAlgunaFoto
         ''chbTomaFoto.Checked = existeAlgunaFoto

         Me._publicos = New Eniac.Win.Publicos()
         Me._publicosEniac = New Eniac.Win.Publicos()

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja, blnCajasModificables As Boolean = True
         Me._publicosEniac.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)

         Me.bscCuentaBancariaTransfBanc.Text = ""
         Me.cmbCajas.SelectedIndex = -1
         Me.dtpFecha.Value = Date.Now()

         Me.tssRegistros.Text = ""

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      Try
         Dim daa As OpenFileDialog = New OpenFileDialog()

         If Me.cmbTipo.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un tipo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTipo.Focus()
            Exit Sub
         End If

         'daa.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
         daa.Filter = "Todos los Archivos (*.*)|*.*"
         daa.FilterIndex = 1
         daa.RestoreDirectory = True

         If daa.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Try
               Select Case Me.cmbTipo.Text
                  Case "VISA"
                     Dim arch As ArchivoRendicionVisa = New ArchivoRendicionVisa()
                     Using rea As StreamReader = New StreamReader(daa.FileName)

                        Me._arReB = arch.GetInfo(rea, chbTomaFoto.Checked)

                        Me.txtFechaRespuesta.Text = Me._arReB.FechaArchivo.ToString("dd/MM/yyyy")
                        Me.txtImporte.Text = Me._arReB.TotalImporte.ToString("#,##0.00")

                        Me.tssRegistros.Text = Me._arReB.Datos.Count.ToString() + " Registros"

                        Me.ugDatos.DataSource = Me._arReB.Datos.ToArray()
                     End Using
                  Case "MASTER"
                     Dim arch As ArchivoRendicionMaster = New ArchivoRendicionMaster()
                     Using rea As StreamReader = New StreamReader(daa.FileName)

                        Me._arPMC = arch.GetInfo(rea)

                        Me.txtFechaRespuesta.Text = Me._arPMC.FechaArchivo.ToString("dd/MM/yyyy")
                        Me.txtImporte.Text = Me._arPMC.TotalImporte.ToString("#,##0.00")

                        Me.tssRegistros.Text = Me._arPMC.Datos.Count.ToString() + " Registros"

                        Me.ugDatos.DataSource = Me._arPMC.Datos.ToArray()
                     End Using
               End Select
               Me.tsbGenerarPagos.Enabled = True
               Me.SeteaGrilla()

            Catch Ex As Exception
               MessageBox.Show("ATENCION: No se puede leer el archivo. Error: " & Ex.Message)
            End Try
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorClick() Handles bscCuentaBancariaTransfBanc.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaTransfBanc)
         Dim oCBancarias As Eniac.Reglas.CuentasBancarias = New Eniac.Reglas.CuentasBancarias()
         Me.bscCuentaBancariaTransfBanc.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaTransfBanc.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaTransfBanc_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaTransfBanc.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            'Me.CargarDatosCuentasBancarias(e.FilaDevuelta)
            Me.bscCuentaBancariaTransfBanc.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancariaTransfBanc.Tag = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
            Me.cmbCajas.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub



   Private Sub SeteaGrilla()


      With Me.ugDatos.DisplayLayout.Bands(0)

         'oculto todas las columnas por si en algún momento agrego mas al query de la consulta
         For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDatos.DisplayLayout.Bands(0).Columns
            col.Hidden = True
            col.CellActivation = UltraWinGrid.Activation.NoEdit
         Next

         Select Case Me.cmbTipo.Text
            Case "VISA"

               .Columns("Alerta").Hidden = False
               .Columns("Alerta").CellAppearance.TextHAlign = HAlign.Center
               .Columns("Alerta").Width = 40
               .Columns("Alerta").Header.Caption = "Alerta"
               .Columns("Alerta").Header.VisiblePosition = 0

               .Columns("Identificador").Hidden = False
               .Columns("Identificador").CellAppearance.TextHAlign = HAlign.Right
               .Columns("Identificador").Width = 70
               .Columns("Identificador").Header.Caption = "Nro.Doc"
               .Columns("Identificador").Header.VisiblePosition = 1

               .Columns("CodigoCliente").Hidden = False
               .Columns("CodigoCliente").CellAppearance.TextHAlign = HAlign.Right
               .Columns("CodigoCliente").Width = 60
               .Columns("CodigoCliente").Header.Caption = "Codigo"
               .Columns("CodigoCliente").Header.VisiblePosition = 2

               .Columns("NombreCliente").Hidden = False
               .Columns("NombreCliente").CellAppearance.TextHAlign = HAlign.Left
               .Columns("NombreCliente").Width = 180
               .Columns("NombreCliente").Header.Caption = "Cliente"
               .Columns("NombreCliente").Header.VisiblePosition = 3

               .Columns("NombreCategoria").Hidden = False
               .Columns("NombreCategoria").CellAppearance.TextHAlign = HAlign.Left
               .Columns("NombreCategoria").Width = 110
               .Columns("NombreCategoria").Header.Caption = "Categoria"
               .Columns("NombreCategoria").Header.VisiblePosition = 4

               .Columns("NroTarjeta").Hidden = False
               .Columns("NroTarjeta").CellAppearance.TextHAlign = HAlign.Left
               .Columns("NroTarjeta").Width = 110
               .Columns("NroTarjeta").Header.Caption = "Nro. Tajeta"
               .Columns("NroTarjeta").Header.VisiblePosition = 5

               .Columns("NroCupon").Hidden = False
               .Columns("NroCupon").CellAppearance.TextHAlign = HAlign.Right
               .Columns("NroCupon").Width = 60
               .Columns("NroCupon").Header.Caption = "Nro. Cupón"
               .Columns("NroCupon").Header.VisiblePosition = 6

               .Columns("Fecha").Hidden = False
               .Columns("Fecha").CellAppearance.TextHAlign = HAlign.Center
               .Columns("Fecha").Width = 70
               .Columns("Fecha").Header.Caption = "Fecha"
               .Columns("Fecha").Header.VisiblePosition = 7

               .Columns("Importe").Hidden = False
               .Columns("Importe").CellAppearance.TextHAlign = HAlign.Right
               .Columns("Importe").Width = 80
               .Columns("Importe").Format = "N2"
               .Columns("Importe").Header.Caption = "Importe"
               .Columns("Importe").Header.VisiblePosition = 8

               .Columns("NombreCaja").Hidden = False
               .Columns("NombreCaja").CellAppearance.TextHAlign = HAlign.Left
               .Columns("NombreCaja").Width = 110
               .Columns("NombreCaja").Header.Caption = "Caja"
               .Columns("NombreCaja").Header.VisiblePosition = 9

               .Columns("Cuotas").Hidden = False
               .Columns("Cuotas").CellAppearance.TextHAlign = HAlign.Center
               .Columns("Cuotas").Width = 40
               .Columns("Cuotas").Header.Caption = "Cuotas"
               .Columns("Cuotas").Header.VisiblePosition = 10

               .Columns("CodigoRechazo1").Hidden = False
               .Columns("CodigoRechazo1").CellAppearance.TextHAlign = HAlign.Center
               .Columns("CodigoRechazo1").Width = 40
               .Columns("CodigoRechazo1").Header.Caption = "R1"
               .Columns("CodigoRechazo1").Header.VisiblePosition = 11

               .Columns("DescripcionRechazo1").Hidden = False
               .Columns("DescripcionRechazo1").CellAppearance.TextHAlign = HAlign.Left
               .Columns("DescripcionRechazo1").Width = 250
               .Columns("DescripcionRechazo1").Header.Caption = "Motivo Rechazo 1"
               .Columns("DescripcionRechazo1").Header.VisiblePosition = 12

               .Columns("CodigoRechazo2").Hidden = False
               .Columns("CodigoRechazo2").CellAppearance.TextHAlign = HAlign.Center
               .Columns("CodigoRechazo2").Width = 40
               .Columns("CodigoRechazo2").Header.Caption = "R2"
               .Columns("CodigoRechazo2").Header.VisiblePosition = 13

               .Columns("DescripcionRechazo2").Hidden = False
               .Columns("DescripcionRechazo2").CellAppearance.TextHAlign = HAlign.Left
               .Columns("DescripcionRechazo2").Width = 250
               .Columns("DescripcionRechazo2").Header.Caption = "Motivo Rechazo 2"
               .Columns("DescripcionRechazo2").Header.VisiblePosition = 14

               .Columns("NroTarjetaNueva").Hidden = False
               .Columns("NroTarjetaNueva").CellAppearance.TextHAlign = HAlign.Left
               .Columns("NroTarjetaNueva").Width = 110
               .Columns("NroTarjetaNueva").Header.Caption = "Nro. Tajeta Nueva"
               .Columns("NroTarjetaNueva").Header.VisiblePosition = 15

            Case "Pago Mis Cuentas"
               .Columns("NroReferencia").Hidden = False
               .Columns("NroReferencia").CellAppearance.TextHAlign = HAlign.Right
               .Columns("NroReferencia").Width = 100
               .Columns("NroReferencia").Header.Caption = "Nro. Referencia"

               .Columns("IdFactura").Hidden = False
               .Columns("IdFactura").CellAppearance.TextHAlign = HAlign.Right
               .Columns("IdFactura").Width = 100
               .Columns("IdFactura").Header.Caption = "Factura"

               .Columns("NombreCliente").Hidden = False
               .Columns("NombreCliente").Width = 200
               .Columns("NombreCliente").Header.Caption = "Cliente"

               .Columns("Importe").Hidden = False
               .Columns("Importe").CellAppearance.TextHAlign = HAlign.Right
               .Columns("Importe").Width = 80
               .Columns("Importe").Format = "N2"
               .Columns("Importe").Header.Caption = "Importe"

               .Columns("NroControl").Hidden = False
               .Columns("NroControl").CellAppearance.TextHAlign = HAlign.Right
               .Columns("NroControl").Width = 80
               .Columns("NroControl").Header.Caption = "Nro. Control"

               .Columns("FechaDeVencimiento").Hidden = False
               .Columns("FechaDeVencimiento").CellAppearance.TextHAlign = HAlign.Center
               .Columns("FechaDeVencimiento").Width = 80
               .Columns("FechaDeVencimiento").Header.Caption = "Vencimiento"
         End Select

      End With
   End Sub


   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDatos, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDatos, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraGridPrintDocument1.Header.TextCenter = Environment.NewLine +
            "Rendición " +
            Environment.NewLine +
            Me.txtFechaRespuesta.Text + " --- "
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 5
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 5
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 14
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 8
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Fecha: " + DateTime.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGenerarPagos_Click(sender As Object, e As EventArgs) Handles tsbGenerarPagos.Click

      Try

         If Not Me.bscCuentaBancariaTransfBanc.Selecciono() Then
            MessageBox.Show("Falta cargar la Cuenta Bancaria.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.bscCuentaBancariaTransfBanc.Focus()
            Exit Sub
         End If

         If Me.cmbCajas.SelectedIndex = -1 Then
            MessageBox.Show("Falta cargar la Caja.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.cmbCajas.Focus()
            Exit Sub
         End If

         If Me.dtpFecha.Value.Date > Date.Now.Date Then
            MessageBox.Show("La Fecha del Recibo NO puede ser Mayor al dia de Hoy.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.dtpFecha.Focus()
            Exit Sub
         End If

         If MessageBox.Show("Realmente desea realizar todos los pagos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Me.tssRegistros.Text = "Generando pagos...."

            'TODO: DB
            ' ''Dim ctacte As CtaCteClienteRecibo = New CtaCteClienteRecibo()
            Dim reg As Eniac.Reglas.CuentasCorrientes = New Eniac.Reglas.CuentasCorrientes()
            Dim oCuentaCorriente As Eniac.Entidades.CuentaCorriente
            Dim regCli As Reglas.Clientes = New Reglas.Clientes()
            Dim ven As Eniac.Entidades.Empleado
            Dim idFormaPago As Integer = 1 'Contado
            Dim listadosCtasCtes As List(Of Eniac.Entidades.CuentaCorriente) = New List(Of Eniac.Entidades.CuentaCorriente)()
            Dim IdCuentaBancaria As Integer = Integer.Parse(Me.bscCuentaBancariaTransfBanc.Tag.ToString())

            Dim i As Integer = 0
            Dim o As Integer = 0
            Select Case Me.cmbTipo.Text
               Case "VISA"
                  For Each arc As ArchivoRendicionVisaDatos In Me._arReB.Datos
                     i += 1

                     'si el codigo de motivo de rechazo es distinto de vacio o cero, no se va a aplicar el pago a ese cliente
                     If Not arc.PuedeProcesar Then
                        Continue For
                     End If

                     o += 1

                     Dim cli As Entidades.Cliente
                     Try
                        cli = regCli.GetUno(arc.IdCliente)
                     Catch ex As Exception
                        Throw New Exception("El cliente identificado en la linea " + i.ToString() + " NO existe en los registros, controle esta información.")
                     End Try

                     'TODO: DB
                     ' ''Dim IdTipoComprobante As String = Eniac.Entidades.TipoComprobante.Tipos.RECIBO.ToString()
                     ' ''If Not String.IsNullOrEmpty(cli.Categoria.IdTipoComprobante) Then
                     ' ''   IdTipoComprobante = cli.Categoria.IdTipoComprobante
                     ' ''End If

                     ' ''Dim Letra As String = New Eniac.Reglas.TiposComprobantes().GetUno(IdTipoComprobante).LetrasHabilitadas
                     'Si tiene configurado mas de una Letra (A,B,C) significa que la toma de la categoria fiscal en lugar de fija (R o X)
                     ' ''If Letra.Trim.Length > 1 Then
                     ' ''   Letra = cli.CategoriaFiscal.LetraFiscal
                     ' ''End If

                     ven = cli.Vendedor

                     'TODO: DB
                     ' ''Dim IdCaja As Integer = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
                     ' ''If cli.Categoria.IdCaja > 0 Then
                     ' ''   IdCaja = cli.Categoria.IdCaja
                     ' ''End If

                     ''''armar el ctactepagos......

                     '' ''Reemplazado Observacion por arc.DatosDelRetorno
                     ' ''oCuentaCorriente = ctacte.GetCtaCteCliente(IdTipoComprobante,
                     ' ''                             Letra,
                     ' ''                             0,
                     ' ''                             Me.dtpFecha.Value,
                     ' ''                             idFormaPago,
                     ' ''                             cli,
                     ' ''                             ven,
                     ' ''                             "DEBITO AUTOMATICO",
                     ' ''                             arc.Importe,
                     ' ''                             0,
                     ' ''                             0,
                     ' ''                             arc.Importe,
                     ' ''                             IdCuentaBancaria,
                     ' ''                             IdCaja,
                     ' ''                             Nothing,
                     ' ''                             Nothing,
                     ' ''                             Nothing,
                     ' ''                             Nothing)
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                     listadosCtasCtes.Add(oCuentaCorriente)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                  Next
               Case "MASTER"
                  'CHEQUEAR
                  For Each arc As ArchivoRendicionMasterDatos In Me._arPMC.Datos
                     i += 1
                     o += 1
                     Dim cli As Entidades.Cliente = regCli.GetUnoPorCodigo(Long.Parse(arc.NroReferencia.Trim()))
                     If String.IsNullOrEmpty(cli.NombreCliente) Then
                        Throw New Exception("El cliente identificado en la linea " + i.ToString() + " NO existe en los registros, controle esta información.")
                     End If

                     ven = New Eniac.Reglas.Empleados().GetUno(1)

                     'TODO: DB
                     ' ''oCuentaCorriente = ctacte.GetCtaCteCliente(Eniac.Entidades.TipoComprobante.Tipos.RECIBO.ToString(),
                     ' ''                              "R",
                     ' ''                              0,
                     ' ''                              DateTime.Now,
                     ' ''                              idFormaPago,
                     ' ''                              cli,
                     ' ''                              ven,
                     ' ''                              arc.CanalPago,
                     ' ''                              arc.Importe,
                     ' ''                              0,
                     ' ''                              0,
                     ' ''                              0,
                     ' ''                              2,
                     ' ''                              1,
                     ' ''                              Nothing,
                     ' ''                              Nothing,
                     ' ''                              Nothing,
                     ' ''                              Nothing)

                     listadosCtasCtes.Add(oCuentaCorriente)
                  Next

            End Select

            'voy a grabar en la base de datos todas las cuentas corrientes del archivo
            reg.GrabarPagosAutomaticos(listadosCtasCtes, Entidades.Entidad.MetodoGrabacion.Automatico, Me.IdFuncion, Nothing, Me.cmbTipo.Text, _nombreArchivo, True)

            MessageBox.Show("Se grabaron exitosamente los " + o.ToString() + " registros.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.tssRegistros.Text = ""
      End Try

   End Sub

   Private Sub ugDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDatos.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is ArchivoRendicionVisaDatos Then
            Dim dato As ArchivoRendicionVisaDatos = DirectCast(e.Row.ListObject, ArchivoRendicionVisaDatos)
            If dato.Alerta = "S" Then
               e.Row.Cells("Alerta").Appearance.BackColor = Color.Yellow
               e.Row.Cells("Alerta").Appearance.ForeColor = Color.Black
               e.Row.Cells("Alerta").ActiveAppearance.BackColor = Color.Yellow
               e.Row.Cells("Alerta").ActiveAppearance.ForeColor = Color.Black
            ElseIf dato.Alerta = "R" Then
               e.Row.Cells("Alerta").Appearance.BackColor = Color.Red
               e.Row.Cells("Alerta").Appearance.ForeColor = Color.White
               e.Row.Cells("Alerta").ActiveAppearance.BackColor = Color.Red
               e.Row.Cells("Alerta").ActiveAppearance.ForeColor = Color.White
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class