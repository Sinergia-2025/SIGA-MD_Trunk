<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RequerimientosComprasABM
   Inherits BaseABM2

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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlFIltrosEstandares = New System.Windows.Forms.Panel()
        Me.lblFechaDesde = New Eniac.Controles.Label()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.lblFechaHasta = New Eniac.Controles.Label()
        Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
        Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.chbUsuarioAlta = New Eniac.Controles.CheckBox()
        Me.cmbUsuarioAlta = New Eniac.Controles.ComboBox()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.txtNumero = New Eniac.Controles.TextBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Win.ButtonConsultar()
        Me.chbFechaEntrega = New Eniac.Controles.CheckBox()
        Me.chkMesCompletoEntrega = New Eniac.Controles.CheckBox()
        Me.dtpFechaEntregaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaEntregaHasta = New Eniac.Controles.Label()
        Me.dtpFechaEntregaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaEntregaDesde = New Eniac.Controles.Label()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFIltrosEstandares.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDatos
        '
        UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
        Me.dgvDatos.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvDatos.DisplayLayout.MaxRowScrollRegions = 1
        Me.dgvDatos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Appearance1.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.CellAppearance = Appearance1
        Me.dgvDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Appearance2.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.FixedHeaderAppearance = Appearance2
        Appearance3.ForeColor = System.Drawing.Color.ForestGreen
        Me.dgvDatos.DisplayLayout.Override.HeaderAppearance = Appearance3
        Me.dgvDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance4
        Appearance5.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.RowAppearance = Appearance5
        Appearance6.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance6
        Me.dgvDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvDatos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
        Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvDatos.Location = New System.Drawing.Point(0, 93)
        Me.dgvDatos.Size = New System.Drawing.Size(964, 446)
        Me.dgvDatos.TabIndex = 2
        '
        'pnlFIltrosEstandares
        '
        Me.pnlFIltrosEstandares.Controls.Add(Me.lblFechaEntregaDesde)
        Me.pnlFIltrosEstandares.Controls.Add(Me.lblFechaDesde)
        Me.pnlFIltrosEstandares.Controls.Add(Me.lblFechaEntregaHasta)
        Me.pnlFIltrosEstandares.Controls.Add(Me.lblFechaHasta)
        Me.pnlFIltrosEstandares.Controls.Add(Me.dtpFechaEntregaDesde)
        Me.pnlFIltrosEstandares.Controls.Add(Me.dtpFechaDesde)
        Me.pnlFIltrosEstandares.Controls.Add(Me.dtpFechaEntregaHasta)
        Me.pnlFIltrosEstandares.Controls.Add(Me.chkMesCompletoEntrega)
        Me.pnlFIltrosEstandares.Controls.Add(Me.dtpFechaHasta)
        Me.pnlFIltrosEstandares.Controls.Add(Me.chkMesCompleto)
        Me.pnlFIltrosEstandares.Controls.Add(Me.chbUsuarioAlta)
        Me.pnlFIltrosEstandares.Controls.Add(Me.cmbUsuarioAlta)
        Me.pnlFIltrosEstandares.Controls.Add(Me.cmbTiposComprobantes)
        Me.pnlFIltrosEstandares.Controls.Add(Me.chbTipoComprobante)
        Me.pnlFIltrosEstandares.Controls.Add(Me.txtNumero)
        Me.pnlFIltrosEstandares.Controls.Add(Me.chbFechaEntrega)
        Me.pnlFIltrosEstandares.Controls.Add(Me.chbNumero)
        Me.pnlFIltrosEstandares.Controls.Add(Me.chbFecha)
        Me.pnlFIltrosEstandares.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFIltrosEstandares.Location = New System.Drawing.Point(0, 29)
        Me.pnlFIltrosEstandares.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlFIltrosEstandares.Name = "pnlFIltrosEstandares"
        Me.pnlFIltrosEstandares.Size = New System.Drawing.Size(964, 64)
        Me.pnlFIltrosEstandares.TabIndex = 0
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.LabelAsoc = Me.chbFecha
        Me.lblFechaDesde.Location = New System.Drawing.Point(611, 11)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaDesde.TabIndex = 8
        Me.lblFechaDesde.Text = "Desde"
        '
        'chbFecha
        '
        Me.chbFecha.AutoSize = True
        Me.chbFecha.BindearPropiedadControl = Nothing
        Me.chbFecha.BindearPropiedadEntidad = Nothing
        Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFecha.IsPK = False
        Me.chbFecha.IsRequired = False
        Me.chbFecha.Key = Nothing
        Me.chbFecha.LabelAsoc = Nothing
        Me.chbFecha.Location = New System.Drawing.Point(412, 9)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 6
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.Enabled = False
        Me.lblFechaHasta.LabelAsoc = Me.chbFecha
        Me.lblFechaHasta.Location = New System.Drawing.Point(786, 11)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaHasta.TabIndex = 10
        Me.lblFechaHasta.Text = "Hasta"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaDesde.Enabled = False
        Me.dtpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaDesde.IsPK = False
        Me.dtpFechaDesde.IsRequired = False
        Me.dtpFechaDesde.Key = ""
        Me.dtpFechaDesde.LabelAsoc = Me.lblFechaDesde
        Me.dtpFechaDesde.Location = New System.Drawing.Point(655, 7)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaDesde.TabIndex = 9
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaHasta.Enabled = False
        Me.dtpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHasta.IsPK = False
        Me.dtpFechaHasta.IsRequired = False
        Me.dtpFechaHasta.Key = ""
        Me.dtpFechaHasta.LabelAsoc = Me.lblFechaHasta
        Me.dtpFechaHasta.Location = New System.Drawing.Point(827, 7)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaHasta.TabIndex = 11
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Me.chbFecha
        Me.chkMesCompleto.Location = New System.Drawing.Point(514, 9)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 7
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'chbUsuarioAlta
        '
        Me.chbUsuarioAlta.AutoSize = True
        Me.chbUsuarioAlta.BindearPropiedadControl = Nothing
        Me.chbUsuarioAlta.BindearPropiedadEntidad = Nothing
        Me.chbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuarioAlta.IsPK = False
        Me.chbUsuarioAlta.IsRequired = False
        Me.chbUsuarioAlta.Key = Nothing
        Me.chbUsuarioAlta.LabelAsoc = Nothing
        Me.chbUsuarioAlta.Location = New System.Drawing.Point(8, 9)
        Me.chbUsuarioAlta.Name = "chbUsuarioAlta"
        Me.chbUsuarioAlta.Size = New System.Drawing.Size(83, 17)
        Me.chbUsuarioAlta.TabIndex = 0
        Me.chbUsuarioAlta.Text = "Usuario Alta"
        Me.chbUsuarioAlta.UseVisualStyleBackColor = True
        '
        'cmbUsuarioAlta
        '
        Me.cmbUsuarioAlta.BindearPropiedadControl = Nothing
        Me.cmbUsuarioAlta.BindearPropiedadEntidad = Nothing
        Me.cmbUsuarioAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarioAlta.Enabled = False
        Me.cmbUsuarioAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuarioAlta.FormattingEnabled = True
        Me.cmbUsuarioAlta.IsPK = False
        Me.cmbUsuarioAlta.IsRequired = False
        Me.cmbUsuarioAlta.Key = Nothing
        Me.cmbUsuarioAlta.LabelAsoc = Me.chbUsuarioAlta
        Me.cmbUsuarioAlta.Location = New System.Drawing.Point(127, 7)
        Me.cmbUsuarioAlta.Name = "cmbUsuarioAlta"
        Me.cmbUsuarioAlta.Size = New System.Drawing.Size(146, 21)
        Me.cmbUsuarioAlta.TabIndex = 1
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = "CategoriaNovedad.IdCategoriaNovedad"
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Enabled = False
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.chbTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(127, 34)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(146, 21)
        Me.cmbTiposComprobantes.TabIndex = 3
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.BindearPropiedadControl = Nothing
        Me.chbTipoComprobante.BindearPropiedadEntidad = Nothing
        Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobante.IsPK = False
        Me.chbTipoComprobante.IsRequired = False
        Me.chbTipoComprobante.Key = Nothing
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(8, 36)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(113, 17)
        Me.chbTipoComprobante.TabIndex = 2
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'txtNumero
        '
        Me.txtNumero.BindearPropiedadControl = Nothing
        Me.txtNumero.BindearPropiedadEntidad = Nothing
        Me.txtNumero.Enabled = False
        Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumero.Formato = "##0"
        Me.txtNumero.IsDecimal = False
        Me.txtNumero.IsNumber = True
        Me.txtNumero.IsPK = False
        Me.txtNumero.IsRequired = False
        Me.txtNumero.Key = ""
        Me.txtNumero.LabelAsoc = Me.chbNumero
        Me.txtNumero.Location = New System.Drawing.Point(347, 34)
        Me.txtNumero.MaxLength = 8
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(59, 20)
        Me.txtNumero.TabIndex = 5
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.chbNumero.Location = New System.Drawing.Point(280, 36)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 4
        Me.chbNumero.Text = "Numero"
        Me.chbNumero.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.AnchoredControl = Me.dgvDatos
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(859, 95)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 30)
        Me.btnConsultar.TabIndex = 1
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbFechaEntrega
        '
        Me.chbFechaEntrega.AutoSize = True
        Me.chbFechaEntrega.BindearPropiedadControl = Nothing
        Me.chbFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.chbFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEntrega.IsPK = False
        Me.chbFechaEntrega.IsRequired = False
        Me.chbFechaEntrega.Key = Nothing
        Me.chbFechaEntrega.LabelAsoc = Nothing
        Me.chbFechaEntrega.Location = New System.Drawing.Point(412, 36)
        Me.chbFechaEntrega.Name = "chbFechaEntrega"
        Me.chbFechaEntrega.Size = New System.Drawing.Size(96, 17)
        Me.chbFechaEntrega.TabIndex = 12
        Me.chbFechaEntrega.Text = "Fecha Entrega"
        Me.chbFechaEntrega.UseVisualStyleBackColor = True
        '
        'chkMesCompletoEntrega
        '
        Me.chkMesCompletoEntrega.AutoSize = True
        Me.chkMesCompletoEntrega.BindearPropiedadControl = Nothing
        Me.chkMesCompletoEntrega.BindearPropiedadEntidad = Nothing
        Me.chkMesCompletoEntrega.Enabled = False
        Me.chkMesCompletoEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompletoEntrega.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompletoEntrega.IsPK = False
        Me.chkMesCompletoEntrega.IsRequired = False
        Me.chkMesCompletoEntrega.Key = Nothing
        Me.chkMesCompletoEntrega.LabelAsoc = Me.chbFechaEntrega
        Me.chkMesCompletoEntrega.Location = New System.Drawing.Point(514, 36)
        Me.chkMesCompletoEntrega.Name = "chkMesCompletoEntrega"
        Me.chkMesCompletoEntrega.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompletoEntrega.TabIndex = 13
        Me.chkMesCompletoEntrega.Text = "Mes Completo"
        Me.chkMesCompletoEntrega.UseVisualStyleBackColor = True
        '
        'dtpFechaEntregaHasta
        '
        Me.dtpFechaEntregaHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaEntregaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntregaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaEntregaHasta.Enabled = False
        Me.dtpFechaEntregaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntregaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntregaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntregaHasta.IsPK = False
        Me.dtpFechaEntregaHasta.IsRequired = False
        Me.dtpFechaEntregaHasta.Key = ""
        Me.dtpFechaEntregaHasta.LabelAsoc = Me.lblFechaEntregaHasta
        Me.dtpFechaEntregaHasta.Location = New System.Drawing.Point(827, 34)
        Me.dtpFechaEntregaHasta.Name = "dtpFechaEntregaHasta"
        Me.dtpFechaEntregaHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaEntregaHasta.TabIndex = 17
        '
        'lblFechaEntregaHasta
        '
        Me.lblFechaEntregaHasta.AutoSize = True
        Me.lblFechaEntregaHasta.Enabled = False
        Me.lblFechaEntregaHasta.LabelAsoc = Me.chbFechaEntrega
        Me.lblFechaEntregaHasta.Location = New System.Drawing.Point(786, 38)
        Me.lblFechaEntregaHasta.Name = "lblFechaEntregaHasta"
        Me.lblFechaEntregaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaEntregaHasta.TabIndex = 16
        Me.lblFechaEntregaHasta.Text = "Hasta"
        '
        'dtpFechaEntregaDesde
        '
        Me.dtpFechaEntregaDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaEntregaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntregaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaEntregaDesde.Enabled = False
        Me.dtpFechaEntregaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntregaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntregaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntregaDesde.IsPK = False
        Me.dtpFechaEntregaDesde.IsRequired = False
        Me.dtpFechaEntregaDesde.Key = ""
        Me.dtpFechaEntregaDesde.LabelAsoc = Me.lblFechaEntregaDesde
        Me.dtpFechaEntregaDesde.Location = New System.Drawing.Point(655, 34)
        Me.dtpFechaEntregaDesde.Name = "dtpFechaEntregaDesde"
        Me.dtpFechaEntregaDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaEntregaDesde.TabIndex = 15
        '
        'lblFechaEntregaDesde
        '
        Me.lblFechaEntregaDesde.AutoSize = True
        Me.lblFechaEntregaDesde.LabelAsoc = Me.chbFechaEntrega
        Me.lblFechaEntregaDesde.Location = New System.Drawing.Point(611, 38)
        Me.lblFechaEntregaDesde.Name = "lblFechaEntregaDesde"
        Me.lblFechaEntregaDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaEntregaDesde.TabIndex = 14
        Me.lblFechaEntregaDesde.Text = "Desde"
        '
        'RequerimientosComprasABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 561)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.pnlFIltrosEstandares)
        Me.Name = "RequerimientosComprasABM"
        Me.Text = "Requerimientos de Compra"
        Me.Controls.SetChildIndex(Me.pnlFIltrosEstandares, 0)
        Me.Controls.SetChildIndex(Me.dgvDatos, 0)
        Me.Controls.SetChildIndex(Me.btnConsultar, 0)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFIltrosEstandares.ResumeLayout(False)
        Me.pnlFIltrosEstandares.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlFIltrosEstandares As Panel
    Friend WithEvents lblFechaDesde As Controles.Label
    Friend WithEvents chbFecha As Controles.CheckBox
    Friend WithEvents lblFechaHasta As Controles.Label
    Friend WithEvents dtpFechaDesde As Controles.DateTimePicker
    Friend WithEvents dtpFechaHasta As Controles.DateTimePicker
    Friend WithEvents chkMesCompleto As Controles.CheckBox
    Friend WithEvents chbUsuarioAlta As Controles.CheckBox
    Friend WithEvents cmbUsuarioAlta As Controles.ComboBox
    Friend WithEvents cmbTiposComprobantes As Controles.ComboBox
    Friend WithEvents chbTipoComprobante As Controles.CheckBox
    Friend WithEvents txtNumero As Controles.TextBox
    Friend WithEvents chbNumero As Controles.CheckBox
    Friend WithEvents btnConsultar As ButtonConsultar
    Friend WithEvents lblFechaEntregaDesde As Controles.Label
    Friend WithEvents chbFechaEntrega As Controles.CheckBox
    Friend WithEvents lblFechaEntregaHasta As Controles.Label
    Friend WithEvents dtpFechaEntregaDesde As Controles.DateTimePicker
    Friend WithEvents dtpFechaEntregaHasta As Controles.DateTimePicker
    Friend WithEvents chkMesCompletoEntrega As Controles.CheckBox
End Class
