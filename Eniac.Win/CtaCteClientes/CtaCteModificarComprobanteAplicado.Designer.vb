<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CtaCteModificarComprobanteAplicado
   Inherits BaseForm

   'Form overrides dispose to clean up the component list.
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CtaCteModificarComprobanteAplicado))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CuotaNumero")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCuota")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCuota")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.grbDetalle = New System.Windows.Forms.GroupBox()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.cmbEmisor = New Eniac.Controles.ComboBox()
      Me.chbEmisor = New Eniac.Controles.CheckBox()
      Me.cboLetra = New Eniac.Controles.ComboBox()
      Me.chbLetra = New Eniac.Controles.CheckBox()
      Me.txtNumeroCompDesde = New Eniac.Controles.TextBox()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.lblNumeroDesde = New Eniac.Controles.Label()
      Me.lblNumeroHasta = New Eniac.Controles.Label()
      Me.txtNumeroCompHasta = New Eniac.Controles.TextBox()
      Me.grbSaldo = New System.Windows.Forms.GroupBox()
      Me.optTodos = New Eniac.Controles.RadioButton()
      Me.optConSaldo = New Eniac.Controles.RadioButton()
      Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
      Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
      Me.lblCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chbFechas = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.txtImporteCuota = New Eniac.Controles.TextBox()
      Me.chkImporteCuota = New Eniac.Controles.CheckBox()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.grbFormaPago = New System.Windows.Forms.GroupBox()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.tstBarra.SuspendLayout()
      Me.grbDetalle.SuspendLayout()
      Me.grbSaldo.SuspendLayout()
      Me.grbFormaPago.SuspendLayout()
      Me.stsStado.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(860, 29)
      Me.tstBarra.TabIndex = 4
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'grbDetalle
      '
      Me.grbDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetalle.Controls.Add(Me.chkExpandAll)
      Me.grbDetalle.Controls.Add(Me.cmbEmisor)
      Me.grbDetalle.Controls.Add(Me.cboLetra)
      Me.grbDetalle.Controls.Add(Me.txtNumeroCompDesde)
      Me.grbDetalle.Controls.Add(Me.lblNumeroDesde)
      Me.grbDetalle.Controls.Add(Me.lblNumeroHasta)
      Me.grbDetalle.Controls.Add(Me.txtNumeroCompHasta)
      Me.grbDetalle.Controls.Add(Me.chbLetra)
      Me.grbDetalle.Controls.Add(Me.chbEmisor)
      Me.grbDetalle.Controls.Add(Me.chbNumero)
      Me.grbDetalle.Controls.Add(Me.grbSaldo)
      Me.grbDetalle.Controls.Add(Me.cmbTiposComprobantes)
      Me.grbDetalle.Controls.Add(Me.chbTipoComprobante)
      Me.grbDetalle.Controls.Add(Me.lblCliente)
      Me.grbDetalle.Controls.Add(Me.bscCodigoCliente)
      Me.grbDetalle.Controls.Add(Me.bscCliente)
      Me.grbDetalle.Controls.Add(Me.lblCodigoCliente)
      Me.grbDetalle.Controls.Add(Me.lblNombre)
      Me.grbDetalle.Controls.Add(Me.dtpDesde)
      Me.grbDetalle.Controls.Add(Me.lblDesde)
      Me.grbDetalle.Controls.Add(Me.chbFechas)
      Me.grbDetalle.Controls.Add(Me.dtpHasta)
      Me.grbDetalle.Controls.Add(Me.lblHasta)
      Me.grbDetalle.Controls.Add(Me.txtImporteCuota)
      Me.grbDetalle.Controls.Add(Me.chkImporteCuota)
      Me.grbDetalle.Controls.Add(Me.btnBuscar)
      Me.grbDetalle.Location = New System.Drawing.Point(12, 27)
      Me.grbDetalle.Name = "grbDetalle"
      Me.grbDetalle.Size = New System.Drawing.Size(836, 156)
      Me.grbDetalle.TabIndex = 0
      Me.grbDetalle.TabStop = False
      Me.grbDetalle.Text = "Detalle"
      '
      'chkExpandAll
      '
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Location = New System.Drawing.Point(717, 89)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(104, 17)
      Me.chkExpandAll.TabIndex = 25
      Me.chkExpandAll.Text = "Expandir Grupos"
      '
      'cmbEmisor
      '
      Me.cmbEmisor.BindearPropiedadControl = Nothing
      Me.cmbEmisor.BindearPropiedadEntidad = Nothing
      Me.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEmisor.Enabled = False
      Me.cmbEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEmisor.FormattingEnabled = True
      Me.cmbEmisor.IsPK = False
      Me.cmbEmisor.IsRequired = False
      Me.cmbEmisor.Key = Nothing
      Me.cmbEmisor.LabelAsoc = Me.chbEmisor
      Me.cmbEmisor.Location = New System.Drawing.Point(449, 121)
      Me.cmbEmisor.Name = "cmbEmisor"
      Me.cmbEmisor.Size = New System.Drawing.Size(40, 21)
      Me.cmbEmisor.TabIndex = 18
      '
      'chbEmisor
      '
      Me.chbEmisor.AutoSize = True
      Me.chbEmisor.BindearPropiedadControl = Nothing
      Me.chbEmisor.BindearPropiedadEntidad = Nothing
      Me.chbEmisor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEmisor.IsPK = False
      Me.chbEmisor.IsRequired = False
      Me.chbEmisor.Key = Nothing
      Me.chbEmisor.LabelAsoc = Nothing
      Me.chbEmisor.Location = New System.Drawing.Point(393, 123)
      Me.chbEmisor.Name = "chbEmisor"
      Me.chbEmisor.Size = New System.Drawing.Size(57, 17)
      Me.chbEmisor.TabIndex = 17
      Me.chbEmisor.Text = "Emisor"
      Me.chbEmisor.UseVisualStyleBackColor = True
      '
      'cboLetra
      '
      Me.cboLetra.BindearPropiedadControl = Nothing
      Me.cboLetra.BindearPropiedadEntidad = Nothing
      Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboLetra.Enabled = False
      Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboLetra.FormattingEnabled = True
      Me.cboLetra.IsPK = False
      Me.cboLetra.IsRequired = False
      Me.cboLetra.Key = Nothing
      Me.cboLetra.LabelAsoc = Me.chbLetra
      Me.cboLetra.Location = New System.Drawing.Point(350, 121)
      Me.cboLetra.Name = "cboLetra"
      Me.cboLetra.Size = New System.Drawing.Size(38, 21)
      Me.cboLetra.TabIndex = 16
      '
      'chbLetra
      '
      Me.chbLetra.AutoSize = True
      Me.chbLetra.BindearPropiedadControl = Nothing
      Me.chbLetra.BindearPropiedadEntidad = Nothing
      Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLetra.IsPK = False
      Me.chbLetra.IsRequired = False
      Me.chbLetra.Key = Nothing
      Me.chbLetra.LabelAsoc = Nothing
      Me.chbLetra.Location = New System.Drawing.Point(302, 123)
      Me.chbLetra.Name = "chbLetra"
      Me.chbLetra.Size = New System.Drawing.Size(50, 17)
      Me.chbLetra.TabIndex = 15
      Me.chbLetra.Text = "Letra"
      Me.chbLetra.UseVisualStyleBackColor = True
      '
      'txtNumeroCompDesde
      '
      Me.txtNumeroCompDesde.BindearPropiedadControl = Nothing
      Me.txtNumeroCompDesde.BindearPropiedadEntidad = Nothing
      Me.txtNumeroCompDesde.Enabled = False
      Me.txtNumeroCompDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroCompDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroCompDesde.Formato = "##0"
      Me.txtNumeroCompDesde.IsDecimal = False
      Me.txtNumeroCompDesde.IsNumber = True
      Me.txtNumeroCompDesde.IsPK = False
      Me.txtNumeroCompDesde.IsRequired = False
      Me.txtNumeroCompDesde.Key = ""
      Me.txtNumeroCompDesde.LabelAsoc = Me.chbNumero
      Me.txtNumeroCompDesde.Location = New System.Drawing.Point(572, 121)
      Me.txtNumeroCompDesde.MaxLength = 8
      Me.txtNumeroCompDesde.Name = "txtNumeroCompDesde"
      Me.txtNumeroCompDesde.Size = New System.Drawing.Size(55, 20)
      Me.txtNumeroCompDesde.TabIndex = 21
      Me.txtNumeroCompDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbNumero
      '
      Me.chbNumero.AutoSize = True
      Me.chbNumero.BindearPropiedadControl = Nothing
      Me.chbNumero.BindearPropiedadEntidad = Nothing
      Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumero.IsPK = False
      Me.chbNumero.IsRequired = False
      Me.chbNumero.Key = Nothing
      Me.chbNumero.LabelAsoc = Nothing
      Me.chbNumero.Location = New System.Drawing.Point(503, 123)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(63, 17)
      Me.chbNumero.TabIndex = 19
      Me.chbNumero.Text = "Numero"
      Me.chbNumero.UseVisualStyleBackColor = True
      '
      'lblNumeroDesde
      '
      Me.lblNumeroDesde.AutoSize = True
      Me.lblNumeroDesde.LabelAsoc = Nothing
      Me.lblNumeroDesde.Location = New System.Drawing.Point(569, 108)
      Me.lblNumeroDesde.Name = "lblNumeroDesde"
      Me.lblNumeroDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblNumeroDesde.TabIndex = 20
      Me.lblNumeroDesde.Text = "Desde"
      '
      'lblNumeroHasta
      '
      Me.lblNumeroHasta.AutoSize = True
      Me.lblNumeroHasta.LabelAsoc = Nothing
      Me.lblNumeroHasta.Location = New System.Drawing.Point(629, 108)
      Me.lblNumeroHasta.Name = "lblNumeroHasta"
      Me.lblNumeroHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblNumeroHasta.TabIndex = 22
      Me.lblNumeroHasta.Text = "Hasta"
      '
      'txtNumeroCompHasta
      '
      Me.txtNumeroCompHasta.BindearPropiedadControl = Nothing
      Me.txtNumeroCompHasta.BindearPropiedadEntidad = Nothing
      Me.txtNumeroCompHasta.Enabled = False
      Me.txtNumeroCompHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroCompHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroCompHasta.Formato = "##0"
      Me.txtNumeroCompHasta.IsDecimal = False
      Me.txtNumeroCompHasta.IsNumber = True
      Me.txtNumeroCompHasta.IsPK = False
      Me.txtNumeroCompHasta.IsRequired = False
      Me.txtNumeroCompHasta.Key = ""
      Me.txtNumeroCompHasta.LabelAsoc = Me.lblNumeroHasta
      Me.txtNumeroCompHasta.Location = New System.Drawing.Point(632, 121)
      Me.txtNumeroCompHasta.MaxLength = 8
      Me.txtNumeroCompHasta.Name = "txtNumeroCompHasta"
      Me.txtNumeroCompHasta.Size = New System.Drawing.Size(55, 20)
      Me.txtNumeroCompHasta.TabIndex = 23
      Me.txtNumeroCompHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'grbSaldo
      '
      Me.grbSaldo.Controls.Add(Me.optTodos)
      Me.grbSaldo.Controls.Add(Me.optConSaldo)
      Me.grbSaldo.Location = New System.Drawing.Point(383, 63)
      Me.grbSaldo.Name = "grbSaldo"
      Me.grbSaldo.Size = New System.Drawing.Size(173, 41)
      Me.grbSaldo.TabIndex = 12
      Me.grbSaldo.TabStop = False
      Me.grbSaldo.Text = "Saldo"
      '
      'optTodos
      '
      Me.optTodos.AutoSize = True
      Me.optTodos.BindearPropiedadControl = Nothing
      Me.optTodos.BindearPropiedadEntidad = Nothing
      Me.optTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.optTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optTodos.IsPK = False
      Me.optTodos.IsRequired = False
      Me.optTodos.Key = Nothing
      Me.optTodos.LabelAsoc = Nothing
      Me.optTodos.Location = New System.Drawing.Point(111, 17)
      Me.optTodos.Name = "optTodos"
      Me.optTodos.Size = New System.Drawing.Size(55, 17)
      Me.optTodos.TabIndex = 1
      Me.optTodos.Text = "Todos"
      Me.optTodos.UseVisualStyleBackColor = True
      '
      'optConSaldo
      '
      Me.optConSaldo.AutoSize = True
      Me.optConSaldo.BindearPropiedadControl = Nothing
      Me.optConSaldo.BindearPropiedadEntidad = Nothing
      Me.optConSaldo.Checked = True
      Me.optConSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.optConSaldo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.optConSaldo.IsPK = False
      Me.optConSaldo.IsRequired = False
      Me.optConSaldo.Key = Nothing
      Me.optConSaldo.LabelAsoc = Nothing
      Me.optConSaldo.Location = New System.Drawing.Point(11, 17)
      Me.optConSaldo.Name = "optConSaldo"
      Me.optConSaldo.Size = New System.Drawing.Size(97, 17)
      Me.optConSaldo.TabIndex = 0
      Me.optConSaldo.TabStop = True
      Me.optConSaldo.Text = "Solo con Saldo"
      Me.optConSaldo.UseVisualStyleBackColor = True
      '
      'cmbTiposComprobantes
      '
      Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
      Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
      Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposComprobantes.Enabled = False
      Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposComprobantes.FormattingEnabled = True
      Me.cmbTiposComprobantes.IsPK = False
      Me.cmbTiposComprobantes.IsRequired = False
      Me.cmbTiposComprobantes.ItemHeight = 13
      Me.cmbTiposComprobantes.Key = Nothing
      Me.cmbTiposComprobantes.LabelAsoc = Nothing
      Me.cmbTiposComprobantes.Location = New System.Drawing.Point(128, 121)
      Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
      Me.cmbTiposComprobantes.Size = New System.Drawing.Size(158, 21)
      Me.cmbTiposComprobantes.TabIndex = 14
      '
      'chbTipoComprobante
      '
      Me.chbTipoComprobante.AutoSize = True
      Me.chbTipoComprobante.BindearPropiedadControl = Nothing
      Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
      Me.chbTipoComprobante.Checked = True
      Me.chbTipoComprobante.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoComprobante.IsPK = False
      Me.chbTipoComprobante.IsRequired = False
      Me.chbTipoComprobante.Key = Nothing
      Me.chbTipoComprobante.LabelAsoc = Nothing
      Me.chbTipoComprobante.Location = New System.Drawing.Point(13, 123)
      Me.chbTipoComprobante.Name = "chbTipoComprobante"
      Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
      Me.chbTipoComprobante.TabIndex = 13
      Me.chbTipoComprobante.Text = "Tipo Comprobante"
      Me.chbTipoComprobante.UseVisualStyleBackColor = True
      '
      'lblCliente
      '
      Me.lblCliente.AutoSize = True
      Me.lblCliente.LabelAsoc = Nothing
      Me.lblCliente.Location = New System.Drawing.Point(13, 38)
      Me.lblCliente.Name = "lblCliente"
      Me.lblCliente.Size = New System.Drawing.Size(39, 13)
      Me.lblCliente.TabIndex = 0
      Me.lblCliente.Text = "Cliente"
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ConfigBuscador = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = True
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(59, 35)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 2
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Nothing
      Me.lblCodigoCliente.Location = New System.Drawing.Point(60, 21)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 1
      Me.lblCodigoCliente.Text = "Código"
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ConfigBuscador = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.lblNombre
      Me.bscCliente.Location = New System.Drawing.Point(156, 35)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(266, 23)
      Me.bscCliente.TabIndex = 4
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(155, 21)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'dtpDesde
      '
      Me.dtpDesde.BindearPropiedadControl = Nothing
      Me.dtpDesde.BindearPropiedadEntidad = Nothing
      Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
      Me.dtpDesde.Enabled = False
      Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDesde.IsPK = False
      Me.dtpDesde.IsRequired = False
      Me.dtpDesde.Key = ""
      Me.dtpDesde.LabelAsoc = Me.lblDesde
      Me.dtpDesde.Location = New System.Drawing.Point(126, 78)
      Me.dtpDesde.Name = "dtpDesde"
      Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
      Me.dtpDesde.TabIndex = 9
      '
      'lblDesde
      '
      Me.lblDesde.AutoSize = True
      Me.lblDesde.LabelAsoc = Nothing
      Me.lblDesde.Location = New System.Drawing.Point(76, 82)
      Me.lblDesde.Name = "lblDesde"
      Me.lblDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDesde.TabIndex = 8
      Me.lblDesde.Text = "Desde"
      '
      'chbFechas
      '
      Me.chbFechas.AutoSize = True
      Me.chbFechas.BindearPropiedadControl = Nothing
      Me.chbFechas.BindearPropiedadEntidad = Nothing
      Me.chbFechas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechas.IsPK = False
      Me.chbFechas.IsRequired = False
      Me.chbFechas.Key = Nothing
      Me.chbFechas.LabelAsoc = Nothing
      Me.chbFechas.Location = New System.Drawing.Point(13, 80)
      Me.chbFechas.Name = "chbFechas"
      Me.chbFechas.Size = New System.Drawing.Size(56, 17)
      Me.chbFechas.TabIndex = 7
      Me.chbFechas.Text = "Fecha"
      Me.chbFechas.UseVisualStyleBackColor = True
      '
      'dtpHasta
      '
      Me.dtpHasta.BindearPropiedadControl = Nothing
      Me.dtpHasta.BindearPropiedadEntidad = Nothing
      Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
      Me.dtpHasta.Enabled = False
      Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpHasta.IsPK = False
      Me.dtpHasta.IsRequired = False
      Me.dtpHasta.Key = ""
      Me.dtpHasta.LabelAsoc = Me.lblHasta
      Me.dtpHasta.Location = New System.Drawing.Point(266, 78)
      Me.dtpHasta.Name = "dtpHasta"
      Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
      Me.dtpHasta.TabIndex = 11
      '
      'lblHasta
      '
      Me.lblHasta.AutoSize = True
      Me.lblHasta.LabelAsoc = Nothing
      Me.lblHasta.Location = New System.Drawing.Point(230, 82)
      Me.lblHasta.Name = "lblHasta"
      Me.lblHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblHasta.TabIndex = 10
      Me.lblHasta.Text = "Hasta"
      '
      'txtImporteCuota
      '
      Me.txtImporteCuota.BackColor = System.Drawing.SystemColors.Window
      Me.txtImporteCuota.BindearPropiedadControl = Nothing
      Me.txtImporteCuota.BindearPropiedadEntidad = Nothing
      Me.txtImporteCuota.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporteCuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporteCuota.Formato = "##0.00"
      Me.txtImporteCuota.IsDecimal = True
      Me.txtImporteCuota.IsNumber = True
      Me.txtImporteCuota.IsPK = False
      Me.txtImporteCuota.IsRequired = False
      Me.txtImporteCuota.Key = ""
      Me.txtImporteCuota.LabelAsoc = Me.chkImporteCuota
      Me.txtImporteCuota.Location = New System.Drawing.Point(520, 35)
      Me.txtImporteCuota.MaxLength = 5
      Me.txtImporteCuota.Name = "txtImporteCuota"
      Me.txtImporteCuota.Size = New System.Drawing.Size(73, 20)
      Me.txtImporteCuota.TabIndex = 6
      Me.txtImporteCuota.Text = "0.00"
      Me.txtImporteCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chkImporteCuota
      '
      Me.chkImporteCuota.AutoSize = True
      Me.chkImporteCuota.BindearPropiedadControl = Nothing
      Me.chkImporteCuota.BindearPropiedadEntidad = Nothing
      Me.chkImporteCuota.Checked = True
      Me.chkImporteCuota.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkImporteCuota.ForeColorFocus = System.Drawing.Color.Red
      Me.chkImporteCuota.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chkImporteCuota.IsPK = False
      Me.chkImporteCuota.IsRequired = False
      Me.chkImporteCuota.Key = Nothing
      Me.chkImporteCuota.LabelAsoc = Nothing
      Me.chkImporteCuota.Location = New System.Drawing.Point(429, 37)
      Me.chkImporteCuota.Name = "chkImporteCuota"
      Me.chkImporteCuota.Size = New System.Drawing.Size(92, 17)
      Me.chkImporteCuota.TabIndex = 5
      Me.chkImporteCuota.Text = "Importe Cuota"
      Me.chkImporteCuota.UseVisualStyleBackColor = True
      '
      'btnBuscar
      '
      Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBuscar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscar.Location = New System.Drawing.Point(717, 38)
      Me.btnBuscar.Name = "btnBuscar"
      Me.btnBuscar.Size = New System.Drawing.Size(100, 45)
      Me.btnBuscar.TabIndex = 24
      Me.btnBuscar.Text = "&Buscar"
      Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnBuscar.UseVisualStyleBackColor = True
      '
      'grbFormaPago
      '
      Me.grbFormaPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbFormaPago.Controls.Add(Me.stsStado)
      Me.grbFormaPago.Controls.Add(Me.ugDetalle)
      Me.grbFormaPago.Location = New System.Drawing.Point(12, 189)
      Me.grbFormaPago.Name = "grbFormaPago"
      Me.grbFormaPago.Size = New System.Drawing.Size(836, 320)
      Me.grbFormaPago.TabIndex = 0
      Me.grbFormaPago.TabStop = False
      Me.grbFormaPago.Text = "Comprobantes"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(3, 295)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(830, 22)
      Me.stsStado.TabIndex = 31
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(751, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridBand1.ColHeaderLines = 2
      UltraGridColumn1.Header.Caption = "Comprobante"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 80
      UltraGridColumn2.Header.Caption = "L"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 20
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn3.CellAppearance = Appearance2
      UltraGridColumn3.Header.Caption = "Emisor"
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 45
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance3
      UltraGridColumn4.Header.Caption = "Numero"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 50
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance4
      UltraGridColumn7.Header.Caption = "Cuota"
      UltraGridColumn7.Header.VisiblePosition = 4
      UltraGridColumn7.Width = 60
      Appearance5.TextHAlignAsString = "Center"
      UltraGridColumn5.CellAppearance = Appearance5
      UltraGridColumn5.Format = "dd/MM/yyyy"
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn5.Width = 70
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance6
      UltraGridColumn6.Format = "N2"
      UltraGridColumn6.Header.Caption = "Importe"
      UltraGridColumn6.Header.VisiblePosition = 6
      UltraGridColumn6.Width = 70
      Appearance7.TextHAlignAsString = "Right"
      UltraGridColumn9.CellAppearance = Appearance7
      UltraGridColumn9.Format = "N2"
      UltraGridColumn9.Header.Caption = "Saldo"
      UltraGridColumn9.Header.VisiblePosition = 7
      UltraGridColumn9.Width = 70
      UltraGridColumn8.Header.VisiblePosition = 8
      UltraGridColumn8.Width = 340
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn7, UltraGridColumn5, UltraGridColumn6, UltraGridColumn9, UltraGridColumn8})
      UltraGridBand1.Expandable = False
      UltraGridBand1.GroupHeaderLines = 2
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance8.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance8
      Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance10.BackColor2 = System.Drawing.SystemColors.Control
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance11
      Appearance12.BackColor = System.Drawing.SystemColors.Highlight
      Appearance12.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance13
      Appearance14.BorderColor = System.Drawing.Color.Silver
      Appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance15.BackColor = System.Drawing.SystemColors.Control
      Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance15.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance15
      Appearance16.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Appearance17.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
      Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(6, 19)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(824, 266)
      Me.ugDetalle.TabIndex = 30
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.AutoSize = True
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(672, 515)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(85, 38)
      Me.btnAceptar.TabIndex = 1
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.AutoSize = True
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_a_16
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(763, 515)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 38)
      Me.btnCancelar.TabIndex = 2
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'CtaCteModificarComprobanteAplicado
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(860, 557)
      Me.ControlBox = False
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbDetalle)
      Me.Controls.Add(Me.grbFormaPago)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CtaCteModificarComprobanteAplicado"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleccionar Comprobante"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbDetalle.ResumeLayout(False)
      Me.grbDetalle.PerformLayout()
      Me.grbSaldo.ResumeLayout(False)
      Me.grbSaldo.PerformLayout()
      Me.grbFormaPago.ResumeLayout(False)
      Me.grbFormaPago.PerformLayout()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents grbFormaPago As System.Windows.Forms.GroupBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents grbDetalle As System.Windows.Forms.GroupBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents txtImporteCuota As Eniac.Controles.TextBox
   Friend WithEvents chkImporteCuota As Eniac.Controles.CheckBox
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents chbFechas As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents lblCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
    Friend WithEvents chbTipoComprobante As Eniac.Controles.CheckBox
    Friend WithEvents grbSaldo As System.Windows.Forms.GroupBox
    Friend WithEvents optTodos As Eniac.Controles.RadioButton
   Friend WithEvents optConSaldo As Eniac.Controles.RadioButton
   Friend WithEvents cmbEmisor As Eniac.Controles.ComboBox
   Friend WithEvents chbEmisor As Eniac.Controles.CheckBox
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents txtNumeroCompDesde As Eniac.Controles.TextBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents lblNumeroDesde As Eniac.Controles.Label
   Friend WithEvents lblNumeroHasta As Eniac.Controles.Label
   Friend WithEvents txtNumeroCompHasta As Eniac.Controles.TextBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
End Class
