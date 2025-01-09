<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfFacturacionElectronica
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.txtMailCOCompElectronico = New Eniac.Controles.TextBox()
      Me.lblUbicacionPDFsFE = New Eniac.Controles.Label()
      Me.chbEnviaCOMailCompElectronico = New Eniac.Controles.CheckBox()
      Me.txtFechaVencimientoCertificadoP12 = New Eniac.Controles.TextBox()
      Me.lblFechaVencimientoCertificadoP12 = New Eniac.Controles.Label()
      Me.txtAFIPURLControlarComprobante = New Eniac.Controles.TextBox()
      Me.lblAFIPURLControlarComprobante = New Eniac.Controles.Label()
      Me.txtSolicitarCAECantidadDiasFiltroFecha = New Eniac.Controles.TextBox()
      Me.lblSolicitarCAECantidadDiasFiltroFecha = New Eniac.Controles.Label()
      Me.lblTipoImpresionFiscal = New Eniac.Controles.Label()
      Me.chbImprimirLuegoSolicitarCae = New Eniac.Controles.CheckBox()
      Me.grbLoginTicketRequest = New System.Windows.Forms.GroupBox()
      Me.txtFactElectDestination = New Eniac.Controles.TextBox()
      Me.lblFactElectDestination = New Eniac.Controles.Label()
      Me.cmbFactElectService = New Eniac.Controles.ComboBox()
      Me.lblFactElectSource = New Eniac.Controles.Label()
      Me.cmbFactElectUniqueID = New Eniac.Controles.ComboBox()
      Me.txtFactElectSource = New Eniac.Controles.TextBox()
      Me.lblFactElectUniqueID = New Eniac.Controles.Label()
      Me.lblFactElectService = New Eniac.Controles.Label()
      Me.lblFactElectGenerationTime = New Eniac.Controles.Label()
      Me.dtpFactElectExpirationTime = New Eniac.Controles.DateTimePicker()
      Me.dtpFactElectGenerationTime = New Eniac.Controles.DateTimePicker()
      Me.lblFactElectExpirationTime = New Eniac.Controles.Label()
      Me.txtUbicacionPDFsFE = New Eniac.Controles.TextBox()
      Me.btnCargarCertificado = New System.Windows.Forms.Button()
      Me.chbEnviaMailCompElectronico = New Eniac.Controles.CheckBox()
      Me.chbSolicitarCAESeleccionarTodos = New Eniac.Controles.CheckBox()
      Me.chbFacElecEsSincronico = New Eniac.Controles.CheckBox()
      Me.cmbTipoImpresionFiscal = New Eniac.Controles.ComboBox()
      Me.txtGuardarLog = New Eniac.Controles.TextBox()
      Me.chbGuardarLog = New Eniac.Controles.CheckBox()
      Me.grbLoginTicketRequest.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtMailCOCompElectronico
      '
      Me.txtMailCOCompElectronico.BindearPropiedadControl = Nothing
      Me.txtMailCOCompElectronico.BindearPropiedadEntidad = Nothing
      Me.txtMailCOCompElectronico.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMailCOCompElectronico.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMailCOCompElectronico.Formato = ""
      Me.txtMailCOCompElectronico.IsDecimal = False
      Me.txtMailCOCompElectronico.IsNumber = False
      Me.txtMailCOCompElectronico.IsPK = False
      Me.txtMailCOCompElectronico.IsRequired = False
      Me.txtMailCOCompElectronico.Key = ""
      Me.txtMailCOCompElectronico.LabelAsoc = Me.lblUbicacionPDFsFE
      Me.txtMailCOCompElectronico.Location = New System.Drawing.Point(224, 38)
      Me.txtMailCOCompElectronico.Name = "txtMailCOCompElectronico"
      Me.txtMailCOCompElectronico.Size = New System.Drawing.Size(192, 20)
      Me.txtMailCOCompElectronico.TabIndex = 2
      Me.txtMailCOCompElectronico.Tag = "MAILCOPIAOCULTACOMPELECTRONICO"
      '
      'lblUbicacionPDFsFE
      '
      Me.lblUbicacionPDFsFE.AutoSize = True
      Me.lblUbicacionPDFsFE.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblUbicacionPDFsFE.LabelAsoc = Nothing
      Me.lblUbicacionPDFsFE.Location = New System.Drawing.Point(10, 198)
      Me.lblUbicacionPDFsFE.Name = "lblUbicacionPDFsFE"
      Me.lblUbicacionPDFsFE.Size = New System.Drawing.Size(84, 13)
      Me.lblUbicacionPDFsFE.TabIndex = 8
      Me.lblUbicacionPDFsFE.Text = "Ubicación PDFs"
      '
      'chbEnviaCOMailCompElectronico
      '
      Me.chbEnviaCOMailCompElectronico.AutoSize = True
      Me.chbEnviaCOMailCompElectronico.BindearPropiedadControl = Nothing
      Me.chbEnviaCOMailCompElectronico.BindearPropiedadEntidad = Nothing
      Me.chbEnviaCOMailCompElectronico.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEnviaCOMailCompElectronico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEnviaCOMailCompElectronico.IsPK = False
      Me.chbEnviaCOMailCompElectronico.IsRequired = False
      Me.chbEnviaCOMailCompElectronico.Key = Nothing
      Me.chbEnviaCOMailCompElectronico.LabelAsoc = Nothing
      Me.chbEnviaCOMailCompElectronico.Location = New System.Drawing.Point(13, 41)
      Me.chbEnviaCOMailCompElectronico.Name = "chbEnviaCOMailCompElectronico"
      Me.chbEnviaCOMailCompElectronico.Size = New System.Drawing.Size(214, 17)
      Me.chbEnviaCOMailCompElectronico.TabIndex = 1
      Me.chbEnviaCOMailCompElectronico.Tag = "ENVIACOMAILCOMPELECTRONICO"
      Me.chbEnviaCOMailCompElectronico.Text = "Enviar copia oculta con el comprobante"
      Me.chbEnviaCOMailCompElectronico.UseVisualStyleBackColor = True
      '
      'txtFechaVencimientoCertificadoP12
      '
      Me.txtFechaVencimientoCertificadoP12.BindearPropiedadControl = Nothing
      Me.txtFechaVencimientoCertificadoP12.BindearPropiedadEntidad = Nothing
      Me.txtFechaVencimientoCertificadoP12.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFechaVencimientoCertificadoP12.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFechaVencimientoCertificadoP12.Formato = ""
      Me.txtFechaVencimientoCertificadoP12.IsDecimal = False
      Me.txtFechaVencimientoCertificadoP12.IsNumber = False
      Me.txtFechaVencimientoCertificadoP12.IsPK = False
      Me.txtFechaVencimientoCertificadoP12.IsRequired = False
      Me.txtFechaVencimientoCertificadoP12.Key = ""
      Me.txtFechaVencimientoCertificadoP12.LabelAsoc = Me.lblFechaVencimientoCertificadoP12
      Me.txtFechaVencimientoCertificadoP12.Location = New System.Drawing.Point(166, 323)
      Me.txtFechaVencimientoCertificadoP12.Name = "txtFechaVencimientoCertificadoP12"
      Me.txtFechaVencimientoCertificadoP12.ReadOnly = True
      Me.txtFechaVencimientoCertificadoP12.Size = New System.Drawing.Size(94, 20)
      Me.txtFechaVencimientoCertificadoP12.TabIndex = 14
      Me.txtFechaVencimientoCertificadoP12.Tag = ""
      '
      'lblFechaVencimientoCertificadoP12
      '
      Me.lblFechaVencimientoCertificadoP12.AutoSize = True
      Me.lblFechaVencimientoCertificadoP12.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFechaVencimientoCertificadoP12.LabelAsoc = Nothing
      Me.lblFechaVencimientoCertificadoP12.Location = New System.Drawing.Point(12, 327)
      Me.lblFechaVencimientoCertificadoP12.Name = "lblFechaVencimientoCertificadoP12"
      Me.lblFechaVencimientoCertificadoP12.Size = New System.Drawing.Size(148, 13)
      Me.lblFechaVencimientoCertificadoP12.TabIndex = 13
      Me.lblFechaVencimientoCertificadoP12.Text = "Vencimiento Certificado (p 12)"
      '
      'txtAFIPURLControlarComprobante
      '
      Me.txtAFIPURLControlarComprobante.BindearPropiedadControl = Nothing
      Me.txtAFIPURLControlarComprobante.BindearPropiedadEntidad = Nothing
      Me.txtAFIPURLControlarComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtAFIPURLControlarComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtAFIPURLControlarComprobante.Formato = ""
      Me.txtAFIPURLControlarComprobante.IsDecimal = False
      Me.txtAFIPURLControlarComprobante.IsNumber = False
      Me.txtAFIPURLControlarComprobante.IsPK = False
      Me.txtAFIPURLControlarComprobante.IsRequired = False
      Me.txtAFIPURLControlarComprobante.Key = ""
      Me.txtAFIPURLControlarComprobante.LabelAsoc = Me.lblAFIPURLControlarComprobante
      Me.txtAFIPURLControlarComprobante.Location = New System.Drawing.Point(422, 227)
      Me.txtAFIPURLControlarComprobante.Name = "txtAFIPURLControlarComprobante"
      Me.txtAFIPURLControlarComprobante.Size = New System.Drawing.Size(364, 20)
      Me.txtAFIPURLControlarComprobante.TabIndex = 17
      Me.txtAFIPURLControlarComprobante.Text = "https://serviciosweb.afip.gob.ar/genericos/comprobantes/cae.aspx"
      '
      'lblAFIPURLControlarComprobante
      '
      Me.lblAFIPURLControlarComprobante.AutoSize = True
      Me.lblAFIPURLControlarComprobante.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblAFIPURLControlarComprobante.LabelAsoc = Nothing
      Me.lblAFIPURLControlarComprobante.Location = New System.Drawing.Point(419, 211)
      Me.lblAFIPURLControlarComprobante.Name = "lblAFIPURLControlarComprobante"
      Me.lblAFIPURLControlarComprobante.Size = New System.Drawing.Size(188, 13)
      Me.lblAFIPURLControlarComprobante.TabIndex = 16
      Me.lblAFIPURLControlarComprobante.Text = "URL Consultar Comprobantes en AFIP"
      '
      'txtSolicitarCAECantidadDiasFiltroFecha
      '
      Me.txtSolicitarCAECantidadDiasFiltroFecha.BindearPropiedadControl = Nothing
      Me.txtSolicitarCAECantidadDiasFiltroFecha.BindearPropiedadEntidad = Nothing
      Me.txtSolicitarCAECantidadDiasFiltroFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSolicitarCAECantidadDiasFiltroFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSolicitarCAECantidadDiasFiltroFecha.Formato = "N0"
      Me.txtSolicitarCAECantidadDiasFiltroFecha.IsDecimal = True
      Me.txtSolicitarCAECantidadDiasFiltroFecha.IsNumber = True
      Me.txtSolicitarCAECantidadDiasFiltroFecha.IsPK = False
      Me.txtSolicitarCAECantidadDiasFiltroFecha.IsRequired = False
      Me.txtSolicitarCAECantidadDiasFiltroFecha.Key = ""
      Me.txtSolicitarCAECantidadDiasFiltroFecha.LabelAsoc = Me.lblSolicitarCAECantidadDiasFiltroFecha
      Me.txtSolicitarCAECantidadDiasFiltroFecha.Location = New System.Drawing.Point(13, 136)
      Me.txtSolicitarCAECantidadDiasFiltroFecha.MaxLength = 3
      Me.txtSolicitarCAECantidadDiasFiltroFecha.Name = "txtSolicitarCAECantidadDiasFiltroFecha"
      Me.txtSolicitarCAECantidadDiasFiltroFecha.Size = New System.Drawing.Size(35, 20)
      Me.txtSolicitarCAECantidadDiasFiltroFecha.TabIndex = 6
      Me.txtSolicitarCAECantidadDiasFiltroFecha.Tag = ""
      Me.txtSolicitarCAECantidadDiasFiltroFecha.Text = "-1"
      Me.txtSolicitarCAECantidadDiasFiltroFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSolicitarCAECantidadDiasFiltroFecha
      '
      Me.lblSolicitarCAECantidadDiasFiltroFecha.AutoSize = True
      Me.lblSolicitarCAECantidadDiasFiltroFecha.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSolicitarCAECantidadDiasFiltroFecha.LabelAsoc = Nothing
      Me.lblSolicitarCAECantidadDiasFiltroFecha.Location = New System.Drawing.Point(54, 139)
      Me.lblSolicitarCAECantidadDiasFiltroFecha.Name = "lblSolicitarCAECantidadDiasFiltroFecha"
      Me.lblSolicitarCAECantidadDiasFiltroFecha.Size = New System.Drawing.Size(326, 13)
      Me.lblSolicitarCAECantidadDiasFiltroFecha.TabIndex = 7
      Me.lblSolicitarCAECantidadDiasFiltroFecha.Text = "Cantidad de días para Solicitar CAE (-1 sin filtrar; 0 hoy; 1 ayer; etc.)"
      '
      'lblTipoImpresionFiscal
      '
      Me.lblTipoImpresionFiscal.AutoSize = True
      Me.lblTipoImpresionFiscal.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTipoImpresionFiscal.LabelAsoc = Nothing
      Me.lblTipoImpresionFiscal.Location = New System.Drawing.Point(10, 242)
      Me.lblTipoImpresionFiscal.Name = "lblTipoImpresionFiscal"
      Me.lblTipoImpresionFiscal.Size = New System.Drawing.Size(121, 13)
      Me.lblTipoImpresionFiscal.TabIndex = 10
      Me.lblTipoImpresionFiscal.Text = "Tipo de Impresión Fiscal"
      '
      'chbImprimirLuegoSolicitarCae
      '
      Me.chbImprimirLuegoSolicitarCae.AutoSize = True
      Me.chbImprimirLuegoSolicitarCae.BindearPropiedadControl = Nothing
      Me.chbImprimirLuegoSolicitarCae.BindearPropiedadEntidad = Nothing
      Me.chbImprimirLuegoSolicitarCae.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImprimirLuegoSolicitarCae.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImprimirLuegoSolicitarCae.IsPK = False
      Me.chbImprimirLuegoSolicitarCae.IsRequired = False
      Me.chbImprimirLuegoSolicitarCae.Key = Nothing
      Me.chbImprimirLuegoSolicitarCae.LabelAsoc = Nothing
      Me.chbImprimirLuegoSolicitarCae.Location = New System.Drawing.Point(13, 67)
      Me.chbImprimirLuegoSolicitarCae.Name = "chbImprimirLuegoSolicitarCae"
      Me.chbImprimirLuegoSolicitarCae.Size = New System.Drawing.Size(234, 17)
      Me.chbImprimirLuegoSolicitarCae.TabIndex = 3
      Me.chbImprimirLuegoSolicitarCae.Tag = "IMPRIMIRLUEGODESOLICITARCAE"
      Me.chbImprimirLuegoSolicitarCae.Text = "Imprimir comprobante luego de Solicitar CAE"
      Me.chbImprimirLuegoSolicitarCae.UseVisualStyleBackColor = True
      '
      'grbLoginTicketRequest
      '
      Me.grbLoginTicketRequest.Controls.Add(Me.txtFactElectDestination)
      Me.grbLoginTicketRequest.Controls.Add(Me.cmbFactElectService)
      Me.grbLoginTicketRequest.Controls.Add(Me.lblFactElectSource)
      Me.grbLoginTicketRequest.Controls.Add(Me.cmbFactElectUniqueID)
      Me.grbLoginTicketRequest.Controls.Add(Me.txtFactElectSource)
      Me.grbLoginTicketRequest.Controls.Add(Me.lblFactElectUniqueID)
      Me.grbLoginTicketRequest.Controls.Add(Me.lblFactElectDestination)
      Me.grbLoginTicketRequest.Controls.Add(Me.lblFactElectService)
      Me.grbLoginTicketRequest.Controls.Add(Me.lblFactElectGenerationTime)
      Me.grbLoginTicketRequest.Controls.Add(Me.dtpFactElectExpirationTime)
      Me.grbLoginTicketRequest.Controls.Add(Me.dtpFactElectGenerationTime)
      Me.grbLoginTicketRequest.Controls.Add(Me.lblFactElectExpirationTime)
      Me.grbLoginTicketRequest.Location = New System.Drawing.Point(422, 17)
      Me.grbLoginTicketRequest.Name = "grbLoginTicketRequest"
      Me.grbLoginTicketRequest.Size = New System.Drawing.Size(457, 179)
      Me.grbLoginTicketRequest.TabIndex = 15
      Me.grbLoginTicketRequest.TabStop = False
      Me.grbLoginTicketRequest.Text = "Login Ticket Request"
      '
      'txtFactElectDestination
      '
      Me.txtFactElectDestination.BindearPropiedadControl = Nothing
      Me.txtFactElectDestination.BindearPropiedadEntidad = Nothing
      Me.txtFactElectDestination.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFactElectDestination.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFactElectDestination.Formato = ""
      Me.txtFactElectDestination.IsDecimal = False
      Me.txtFactElectDestination.IsNumber = False
      Me.txtFactElectDestination.IsPK = False
      Me.txtFactElectDestination.IsRequired = False
      Me.txtFactElectDestination.Key = ""
      Me.txtFactElectDestination.LabelAsoc = Me.lblFactElectDestination
      Me.txtFactElectDestination.Location = New System.Drawing.Point(17, 90)
      Me.txtFactElectDestination.Name = "txtFactElectDestination"
      Me.txtFactElectDestination.Size = New System.Drawing.Size(347, 20)
      Me.txtFactElectDestination.TabIndex = 3
      Me.txtFactElectDestination.Tag = "FACTELECTDESTINATION"
      Me.txtFactElectDestination.Text = "cn=wsaahomo,o=afip,c=ar,serialNumber=CUIT 33693450239"
      '
      'lblFactElectDestination
      '
      Me.lblFactElectDestination.AutoSize = True
      Me.lblFactElectDestination.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFactElectDestination.LabelAsoc = Nothing
      Me.lblFactElectDestination.Location = New System.Drawing.Point(14, 74)
      Me.lblFactElectDestination.Name = "lblFactElectDestination"
      Me.lblFactElectDestination.Size = New System.Drawing.Size(43, 13)
      Me.lblFactElectDestination.TabIndex = 2
      Me.lblFactElectDestination.Text = "Destino"
      '
      'cmbFactElectService
      '
      Me.cmbFactElectService.BindearPropiedadControl = Nothing
      Me.cmbFactElectService.BindearPropiedadEntidad = Nothing
      Me.cmbFactElectService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFactElectService.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFactElectService.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFactElectService.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFactElectService.FormattingEnabled = True
      Me.cmbFactElectService.IsPK = False
      Me.cmbFactElectService.IsRequired = False
      Me.cmbFactElectService.Items.AddRange(New Object() {"wsfe", "wsbfe"})
      Me.cmbFactElectService.Key = Nothing
      Me.cmbFactElectService.LabelAsoc = Nothing
      Me.cmbFactElectService.Location = New System.Drawing.Point(370, 138)
      Me.cmbFactElectService.Name = "cmbFactElectService"
      Me.cmbFactElectService.Size = New System.Drawing.Size(76, 21)
      Me.cmbFactElectService.TabIndex = 11
      Me.cmbFactElectService.Tag = "FACTELECSERVICE"
      '
      'lblFactElectSource
      '
      Me.lblFactElectSource.AutoSize = True
      Me.lblFactElectSource.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFactElectSource.LabelAsoc = Nothing
      Me.lblFactElectSource.Location = New System.Drawing.Point(14, 26)
      Me.lblFactElectSource.Name = "lblFactElectSource"
      Me.lblFactElectSource.Size = New System.Drawing.Size(38, 13)
      Me.lblFactElectSource.TabIndex = 0
      Me.lblFactElectSource.Text = "Origen"
      '
      'cmbFactElectUniqueID
      '
      Me.cmbFactElectUniqueID.BindearPropiedadControl = Nothing
      Me.cmbFactElectUniqueID.BindearPropiedadEntidad = Nothing
      Me.cmbFactElectUniqueID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFactElectUniqueID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFactElectUniqueID.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFactElectUniqueID.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFactElectUniqueID.FormattingEnabled = True
      Me.cmbFactElectUniqueID.IsPK = False
      Me.cmbFactElectUniqueID.IsRequired = False
      Me.cmbFactElectUniqueID.Items.AddRange(New Object() {"1"})
      Me.cmbFactElectUniqueID.Key = Nothing
      Me.cmbFactElectUniqueID.LabelAsoc = Nothing
      Me.cmbFactElectUniqueID.Location = New System.Drawing.Point(370, 89)
      Me.cmbFactElectUniqueID.Name = "cmbFactElectUniqueID"
      Me.cmbFactElectUniqueID.Size = New System.Drawing.Size(63, 21)
      Me.cmbFactElectUniqueID.TabIndex = 5
      Me.cmbFactElectUniqueID.Tag = "FACTELECUNIQUEID"
      '
      'txtFactElectSource
      '
      Me.txtFactElectSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtFactElectSource.BindearPropiedadControl = Nothing
      Me.txtFactElectSource.BindearPropiedadEntidad = Nothing
      Me.txtFactElectSource.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFactElectSource.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFactElectSource.Formato = ""
      Me.txtFactElectSource.IsDecimal = False
      Me.txtFactElectSource.IsNumber = False
      Me.txtFactElectSource.IsPK = False
      Me.txtFactElectSource.IsRequired = False
      Me.txtFactElectSource.Key = ""
      Me.txtFactElectSource.LabelAsoc = Me.lblFactElectSource
      Me.txtFactElectSource.Location = New System.Drawing.Point(17, 42)
      Me.txtFactElectSource.Name = "txtFactElectSource"
      Me.txtFactElectSource.Size = New System.Drawing.Size(434, 20)
      Me.txtFactElectSource.TabIndex = 1
      Me.txtFactElectSource.Tag = "FACTELECTSOURCE"
      Me.txtFactElectSource.Text = "C=AR, O=HAR GROUP SA, SERIALNUMBER=CUIT 33711345499, CN=AUGUSTO"
      '
      'lblFactElectUniqueID
      '
      Me.lblFactElectUniqueID.AutoSize = True
      Me.lblFactElectUniqueID.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFactElectUniqueID.LabelAsoc = Nothing
      Me.lblFactElectUniqueID.Location = New System.Drawing.Point(367, 74)
      Me.lblFactElectUniqueID.Name = "lblFactElectUniqueID"
      Me.lblFactElectUniqueID.Size = New System.Drawing.Size(70, 13)
      Me.lblFactElectUniqueID.TabIndex = 4
      Me.lblFactElectUniqueID.Text = "Identificacion"
      '
      'lblFactElectService
      '
      Me.lblFactElectService.AutoSize = True
      Me.lblFactElectService.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFactElectService.LabelAsoc = Nothing
      Me.lblFactElectService.Location = New System.Drawing.Point(367, 123)
      Me.lblFactElectService.Name = "lblFactElectService"
      Me.lblFactElectService.Size = New System.Drawing.Size(45, 13)
      Me.lblFactElectService.TabIndex = 10
      Me.lblFactElectService.Text = "Servicio"
      '
      'lblFactElectGenerationTime
      '
      Me.lblFactElectGenerationTime.AutoSize = True
      Me.lblFactElectGenerationTime.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFactElectGenerationTime.LabelAsoc = Nothing
      Me.lblFactElectGenerationTime.Location = New System.Drawing.Point(14, 125)
      Me.lblFactElectGenerationTime.Name = "lblFactElectGenerationTime"
      Me.lblFactElectGenerationTime.Size = New System.Drawing.Size(95, 13)
      Me.lblFactElectGenerationTime.TabIndex = 6
      Me.lblFactElectGenerationTime.Text = "Fecha Generacion"
      '
      'dtpFactElectExpirationTime
      '
      Me.dtpFactElectExpirationTime.BindearPropiedadControl = Nothing
      Me.dtpFactElectExpirationTime.BindearPropiedadEntidad = Nothing
      Me.dtpFactElectExpirationTime.Checked = False
      Me.dtpFactElectExpirationTime.CustomFormat = "dd/MM/yyyy HH:mm:ss"
      Me.dtpFactElectExpirationTime.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFactElectExpirationTime.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFactElectExpirationTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFactElectExpirationTime.IsPK = False
      Me.dtpFactElectExpirationTime.IsRequired = False
      Me.dtpFactElectExpirationTime.Key = ""
      Me.dtpFactElectExpirationTime.LabelAsoc = Nothing
      Me.dtpFactElectExpirationTime.Location = New System.Drawing.Point(167, 141)
      Me.dtpFactElectExpirationTime.Name = "dtpFactElectExpirationTime"
      Me.dtpFactElectExpirationTime.Size = New System.Drawing.Size(144, 20)
      Me.dtpFactElectExpirationTime.TabIndex = 9
      Me.dtpFactElectExpirationTime.Tag = "FACTELECTEXPIRATIONTIME"
      '
      'dtpFactElectGenerationTime
      '
      Me.dtpFactElectGenerationTime.BindearPropiedadControl = Nothing
      Me.dtpFactElectGenerationTime.BindearPropiedadEntidad = Nothing
      Me.dtpFactElectGenerationTime.Checked = False
      Me.dtpFactElectGenerationTime.CustomFormat = "dd/MM/yyyy HH:mm:ss"
      Me.dtpFactElectGenerationTime.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFactElectGenerationTime.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFactElectGenerationTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFactElectGenerationTime.IsPK = False
      Me.dtpFactElectGenerationTime.IsRequired = False
      Me.dtpFactElectGenerationTime.Key = ""
      Me.dtpFactElectGenerationTime.LabelAsoc = Nothing
      Me.dtpFactElectGenerationTime.Location = New System.Drawing.Point(17, 141)
      Me.dtpFactElectGenerationTime.Name = "dtpFactElectGenerationTime"
      Me.dtpFactElectGenerationTime.Size = New System.Drawing.Size(144, 20)
      Me.dtpFactElectGenerationTime.TabIndex = 7
      Me.dtpFactElectGenerationTime.Tag = "FACTELECTGENERATIONTIME"
      '
      'lblFactElectExpirationTime
      '
      Me.lblFactElectExpirationTime.AutoSize = True
      Me.lblFactElectExpirationTime.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFactElectExpirationTime.LabelAsoc = Nothing
      Me.lblFactElectExpirationTime.Location = New System.Drawing.Point(164, 125)
      Me.lblFactElectExpirationTime.Name = "lblFactElectExpirationTime"
      Me.lblFactElectExpirationTime.Size = New System.Drawing.Size(89, 13)
      Me.lblFactElectExpirationTime.TabIndex = 8
      Me.lblFactElectExpirationTime.Text = "Fecha Expiracion"
      '
      'txtUbicacionPDFsFE
      '
      Me.txtUbicacionPDFsFE.BindearPropiedadControl = Nothing
      Me.txtUbicacionPDFsFE.BindearPropiedadEntidad = Nothing
      Me.txtUbicacionPDFsFE.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUbicacionPDFsFE.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUbicacionPDFsFE.Formato = ""
      Me.txtUbicacionPDFsFE.IsDecimal = False
      Me.txtUbicacionPDFsFE.IsNumber = False
      Me.txtUbicacionPDFsFE.IsPK = False
      Me.txtUbicacionPDFsFE.IsRequired = False
      Me.txtUbicacionPDFsFE.Key = ""
      Me.txtUbicacionPDFsFE.LabelAsoc = Me.lblUbicacionPDFsFE
      Me.txtUbicacionPDFsFE.Location = New System.Drawing.Point(13, 214)
      Me.txtUbicacionPDFsFE.Name = "txtUbicacionPDFsFE"
      Me.txtUbicacionPDFsFE.Size = New System.Drawing.Size(308, 20)
      Me.txtUbicacionPDFsFE.TabIndex = 9
      Me.txtUbicacionPDFsFE.Tag = "UBICACIONPDFSFE"
      Me.txtUbicacionPDFsFE.Text = "C:\ENIAC\AFIP\COMPROBANTES"
      '
      'btnCargarCertificado
      '
      Me.btnCargarCertificado.Location = New System.Drawing.Point(11, 294)
      Me.btnCargarCertificado.Name = "btnCargarCertificado"
      Me.btnCargarCertificado.Size = New System.Drawing.Size(183, 23)
      Me.btnCargarCertificado.TabIndex = 12
      Me.btnCargarCertificado.Text = "Cargar Certificado (p12)"
      Me.btnCargarCertificado.UseVisualStyleBackColor = True
      '
      'chbEnviaMailCompElectronico
      '
      Me.chbEnviaMailCompElectronico.AutoSize = True
      Me.chbEnviaMailCompElectronico.BindearPropiedadControl = Nothing
      Me.chbEnviaMailCompElectronico.BindearPropiedadEntidad = Nothing
      Me.chbEnviaMailCompElectronico.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEnviaMailCompElectronico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEnviaMailCompElectronico.IsPK = False
      Me.chbEnviaMailCompElectronico.IsRequired = False
      Me.chbEnviaMailCompElectronico.Key = Nothing
      Me.chbEnviaMailCompElectronico.LabelAsoc = Nothing
      Me.chbEnviaMailCompElectronico.Location = New System.Drawing.Point(13, 17)
      Me.chbEnviaMailCompElectronico.Name = "chbEnviaMailCompElectronico"
      Me.chbEnviaMailCompElectronico.Size = New System.Drawing.Size(276, 17)
      Me.chbEnviaMailCompElectronico.TabIndex = 0
      Me.chbEnviaMailCompElectronico.Tag = "ENVIAMAILCLIENTECOMPELECTRONICO"
      Me.chbEnviaMailCompElectronico.Text = "Envia Correo al Cliente con Comprobante Electrónico"
      Me.chbEnviaMailCompElectronico.UseVisualStyleBackColor = True
      '
      'chbSolicitarCAESeleccionarTodos
      '
      Me.chbSolicitarCAESeleccionarTodos.AutoSize = True
      Me.chbSolicitarCAESeleccionarTodos.BindearPropiedadControl = Nothing
      Me.chbSolicitarCAESeleccionarTodos.BindearPropiedadEntidad = Nothing
      Me.chbSolicitarCAESeleccionarTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSolicitarCAESeleccionarTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSolicitarCAESeleccionarTodos.IsPK = False
      Me.chbSolicitarCAESeleccionarTodos.IsRequired = False
      Me.chbSolicitarCAESeleccionarTodos.Key = Nothing
      Me.chbSolicitarCAESeleccionarTodos.LabelAsoc = Nothing
      Me.chbSolicitarCAESeleccionarTodos.Location = New System.Drawing.Point(13, 113)
      Me.chbSolicitarCAESeleccionarTodos.Name = "chbSolicitarCAESeleccionarTodos"
      Me.chbSolicitarCAESeleccionarTodos.Size = New System.Drawing.Size(225, 17)
      Me.chbSolicitarCAESeleccionarTodos.TabIndex = 5
      Me.chbSolicitarCAESeleccionarTodos.Text = "Solicitar CAE inicia con todo seleccionado"
      Me.chbSolicitarCAESeleccionarTodos.UseVisualStyleBackColor = True
      '
      'chbFacElecEsSincronico
      '
      Me.chbFacElecEsSincronico.AutoSize = True
      Me.chbFacElecEsSincronico.BindearPropiedadControl = Nothing
      Me.chbFacElecEsSincronico.BindearPropiedadEntidad = Nothing
      Me.chbFacElecEsSincronico.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFacElecEsSincronico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFacElecEsSincronico.IsPK = False
      Me.chbFacElecEsSincronico.IsRequired = False
      Me.chbFacElecEsSincronico.Key = Nothing
      Me.chbFacElecEsSincronico.LabelAsoc = Nothing
      Me.chbFacElecEsSincronico.Location = New System.Drawing.Point(13, 90)
      Me.chbFacElecEsSincronico.Name = "chbFacElecEsSincronico"
      Me.chbFacElecEsSincronico.Size = New System.Drawing.Size(187, 17)
      Me.chbFacElecEsSincronico.TabIndex = 4
      Me.chbFacElecEsSincronico.Tag = "FACTELECTSINCRONICA"
      Me.chbFacElecEsSincronico.Text = "Transmisión en Línea (Sincrónica)"
      Me.chbFacElecEsSincronico.UseVisualStyleBackColor = True
      '
      'cmbTipoImpresionFiscal
      '
      Me.cmbTipoImpresionFiscal.BindearPropiedadControl = Nothing
      Me.cmbTipoImpresionFiscal.BindearPropiedadEntidad = Nothing
      Me.cmbTipoImpresionFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoImpresionFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoImpresionFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoImpresionFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoImpresionFiscal.FormattingEnabled = True
      Me.cmbTipoImpresionFiscal.IsPK = False
      Me.cmbTipoImpresionFiscal.IsRequired = False
      Me.cmbTipoImpresionFiscal.Items.AddRange(New Object() {"1"})
      Me.cmbTipoImpresionFiscal.Key = Nothing
      Me.cmbTipoImpresionFiscal.LabelAsoc = Nothing
      Me.cmbTipoImpresionFiscal.Location = New System.Drawing.Point(13, 258)
      Me.cmbTipoImpresionFiscal.Name = "cmbTipoImpresionFiscal"
      Me.cmbTipoImpresionFiscal.Size = New System.Drawing.Size(247, 21)
      Me.cmbTipoImpresionFiscal.TabIndex = 11
      Me.cmbTipoImpresionFiscal.Tag = "TIPOIMPRESIONFISCAL"
      '
      'txtGuardarLog
      '
      Me.txtGuardarLog.BindearPropiedadControl = Nothing
      Me.txtGuardarLog.BindearPropiedadEntidad = Nothing
      Me.txtGuardarLog.ForeColorFocus = System.Drawing.Color.Red
      Me.txtGuardarLog.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtGuardarLog.Formato = ""
      Me.txtGuardarLog.IsDecimal = False
      Me.txtGuardarLog.IsNumber = False
      Me.txtGuardarLog.IsPK = False
      Me.txtGuardarLog.IsRequired = False
      Me.txtGuardarLog.Key = ""
      Me.txtGuardarLog.LabelAsoc = Me.lblUbicacionPDFsFE
      Me.txtGuardarLog.Location = New System.Drawing.Point(509, 268)
      Me.txtGuardarLog.Name = "txtGuardarLog"
      Me.txtGuardarLog.Size = New System.Drawing.Size(277, 20)
      Me.txtGuardarLog.TabIndex = 19
      Me.txtGuardarLog.Tag = "MAILCOPIAOCULTACOMPELECTRONICO"
      '
      'chbGuardarLog
      '
      Me.chbGuardarLog.AutoSize = True
      Me.chbGuardarLog.BindearPropiedadControl = Nothing
      Me.chbGuardarLog.BindearPropiedadEntidad = Nothing
      Me.chbGuardarLog.ForeColorFocus = System.Drawing.Color.Red
      Me.chbGuardarLog.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbGuardarLog.IsPK = False
      Me.chbGuardarLog.IsRequired = False
      Me.chbGuardarLog.Key = Nothing
      Me.chbGuardarLog.LabelAsoc = Nothing
      Me.chbGuardarLog.Location = New System.Drawing.Point(422, 271)
      Me.chbGuardarLog.Name = "chbGuardarLog"
      Me.chbGuardarLog.Size = New System.Drawing.Size(81, 17)
      Me.chbGuardarLog.TabIndex = 18
      Me.chbGuardarLog.Tag = ""
      Me.chbGuardarLog.Text = "Guardar log"
      Me.chbGuardarLog.UseVisualStyleBackColor = True
      '
      'ucConfFacturacionElectronica
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.txtGuardarLog)
      Me.Controls.Add(Me.chbGuardarLog)
      Me.Controls.Add(Me.txtMailCOCompElectronico)
      Me.Controls.Add(Me.chbEnviaCOMailCompElectronico)
      Me.Controls.Add(Me.txtFechaVencimientoCertificadoP12)
      Me.Controls.Add(Me.lblFechaVencimientoCertificadoP12)
      Me.Controls.Add(Me.txtAFIPURLControlarComprobante)
      Me.Controls.Add(Me.txtSolicitarCAECantidadDiasFiltroFecha)
      Me.Controls.Add(Me.lblTipoImpresionFiscal)
      Me.Controls.Add(Me.lblSolicitarCAECantidadDiasFiltroFecha)
      Me.Controls.Add(Me.chbImprimirLuegoSolicitarCae)
      Me.Controls.Add(Me.lblAFIPURLControlarComprobante)
      Me.Controls.Add(Me.grbLoginTicketRequest)
      Me.Controls.Add(Me.txtUbicacionPDFsFE)
      Me.Controls.Add(Me.btnCargarCertificado)
      Me.Controls.Add(Me.chbEnviaMailCompElectronico)
      Me.Controls.Add(Me.chbSolicitarCAESeleccionarTodos)
      Me.Controls.Add(Me.chbFacElecEsSincronico)
      Me.Controls.Add(Me.lblUbicacionPDFsFE)
      Me.Controls.Add(Me.cmbTipoImpresionFiscal)
      Me.Name = "ucConfFacturacionElectronica"
      Me.Controls.SetChildIndex(Me.cmbTipoImpresionFiscal, 0)
      Me.Controls.SetChildIndex(Me.lblUbicacionPDFsFE, 0)
      Me.Controls.SetChildIndex(Me.chbFacElecEsSincronico, 0)
      Me.Controls.SetChildIndex(Me.chbSolicitarCAESeleccionarTodos, 0)
      Me.Controls.SetChildIndex(Me.chbEnviaMailCompElectronico, 0)
      Me.Controls.SetChildIndex(Me.btnCargarCertificado, 0)
      Me.Controls.SetChildIndex(Me.txtUbicacionPDFsFE, 0)
      Me.Controls.SetChildIndex(Me.grbLoginTicketRequest, 0)
      Me.Controls.SetChildIndex(Me.lblAFIPURLControlarComprobante, 0)
      Me.Controls.SetChildIndex(Me.chbImprimirLuegoSolicitarCae, 0)
      Me.Controls.SetChildIndex(Me.lblSolicitarCAECantidadDiasFiltroFecha, 0)
      Me.Controls.SetChildIndex(Me.lblTipoImpresionFiscal, 0)
      Me.Controls.SetChildIndex(Me.txtSolicitarCAECantidadDiasFiltroFecha, 0)
      Me.Controls.SetChildIndex(Me.txtAFIPURLControlarComprobante, 0)
      Me.Controls.SetChildIndex(Me.lblFechaVencimientoCertificadoP12, 0)
      Me.Controls.SetChildIndex(Me.txtFechaVencimientoCertificadoP12, 0)
      Me.Controls.SetChildIndex(Me.chbEnviaCOMailCompElectronico, 0)
      Me.Controls.SetChildIndex(Me.txtMailCOCompElectronico, 0)
      Me.Controls.SetChildIndex(Me.chbGuardarLog, 0)
      Me.Controls.SetChildIndex(Me.txtGuardarLog, 0)
      Me.grbLoginTicketRequest.ResumeLayout(False)
      Me.grbLoginTicketRequest.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents txtMailCOCompElectronico As Controles.TextBox
   Friend WithEvents lblUbicacionPDFsFE As Controles.Label
   Friend WithEvents chbEnviaCOMailCompElectronico As Controles.CheckBox
   Friend WithEvents txtFechaVencimientoCertificadoP12 As Controles.TextBox
   Friend WithEvents lblFechaVencimientoCertificadoP12 As Controles.Label
   Friend WithEvents txtAFIPURLControlarComprobante As Controles.TextBox
   Friend WithEvents lblAFIPURLControlarComprobante As Controles.Label
   Friend WithEvents txtSolicitarCAECantidadDiasFiltroFecha As Controles.TextBox
   Friend WithEvents lblSolicitarCAECantidadDiasFiltroFecha As Controles.Label
   Friend WithEvents lblTipoImpresionFiscal As Controles.Label
   Friend WithEvents chbImprimirLuegoSolicitarCae As Controles.CheckBox
   Friend WithEvents grbLoginTicketRequest As GroupBox
   Friend WithEvents txtFactElectDestination As Controles.TextBox
   Friend WithEvents lblFactElectDestination As Controles.Label
   Friend WithEvents cmbFactElectService As Controles.ComboBox
   Friend WithEvents lblFactElectSource As Controles.Label
   Friend WithEvents cmbFactElectUniqueID As Controles.ComboBox
   Friend WithEvents txtFactElectSource As Controles.TextBox
   Friend WithEvents lblFactElectUniqueID As Controles.Label
   Friend WithEvents lblFactElectService As Controles.Label
   Friend WithEvents lblFactElectGenerationTime As Controles.Label
   Friend WithEvents dtpFactElectExpirationTime As Controles.DateTimePicker
   Friend WithEvents dtpFactElectGenerationTime As Controles.DateTimePicker
   Friend WithEvents lblFactElectExpirationTime As Controles.Label
   Friend WithEvents txtUbicacionPDFsFE As Controles.TextBox
   Friend WithEvents btnCargarCertificado As Button
   Friend WithEvents chbEnviaMailCompElectronico As Controles.CheckBox
   Friend WithEvents chbSolicitarCAESeleccionarTodos As Controles.CheckBox
   Friend WithEvents chbFacElecEsSincronico As Controles.CheckBox
   Friend WithEvents cmbTipoImpresionFiscal As Controles.ComboBox
   Friend WithEvents txtGuardarLog As Controles.TextBox
   Friend WithEvents chbGuardarLog As Controles.CheckBox
End Class
