<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClientesABM
    Inherits BaseABM2

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesABM))
        Me.grpFiltros = New System.Windows.Forms.GroupBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.chbFechaNacimientoIncluirAnio = New Eniac.Controles.CheckBox()
        Me.chbFechaNacimiento = New Eniac.Controles.CheckBox()
        Me.chkMesCompletoFechaNacimiento = New Eniac.Controles.CheckBox()
        Me.dtpFechaNacimientoHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaNacimientoHasta = New Eniac.Controles.Label()
        Me.dtpFechaNacimientoDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaNacimientoDesde = New Eniac.Controles.Label()
        Me.chbFechaAlta = New Eniac.Controles.CheckBox()
        Me.chkMesCompletoFechaAlta = New Eniac.Controles.CheckBox()
        Me.dtpFechaAltaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblFechaAltaHasta = New Eniac.Controles.Label()
        Me.dtpFechaAltaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblFechaAltaDesde = New Eniac.Controles.Label()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltros.SuspendLayout()
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
        Me.dgvDatos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
        Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvDatos.Location = New System.Drawing.Point(0, 107)
        Me.dgvDatos.Size = New System.Drawing.Size(960, 432)
        Me.dgvDatos.TabIndex = 1
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.chbVendedor)
        Me.grpFiltros.Controls.Add(Me.cmbVendedor)
        Me.grpFiltros.Controls.Add(Me.btnConsultar)
        Me.grpFiltros.Controls.Add(Me.chbFechaNacimientoIncluirAnio)
        Me.grpFiltros.Controls.Add(Me.chbFechaNacimiento)
        Me.grpFiltros.Controls.Add(Me.chkMesCompletoFechaNacimiento)
        Me.grpFiltros.Controls.Add(Me.dtpFechaNacimientoHasta)
        Me.grpFiltros.Controls.Add(Me.dtpFechaNacimientoDesde)
        Me.grpFiltros.Controls.Add(Me.lblFechaNacimientoHasta)
        Me.grpFiltros.Controls.Add(Me.lblFechaNacimientoDesde)
        Me.grpFiltros.Controls.Add(Me.chbFechaAlta)
        Me.grpFiltros.Controls.Add(Me.chkMesCompletoFechaAlta)
        Me.grpFiltros.Controls.Add(Me.dtpFechaAltaHasta)
        Me.grpFiltros.Controls.Add(Me.dtpFechaAltaDesde)
        Me.grpFiltros.Controls.Add(Me.lblFechaAltaHasta)
        Me.grpFiltros.Controls.Add(Me.lblFechaAltaDesde)
        Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(960, 78)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        Me.grpFiltros.Text = "Filtros"
        Me.grpFiltros.Visible = False
        '
        'chbVendedor
        '
        Me.chbVendedor.AutoSize = True
        Me.chbVendedor.BindearPropiedadControl = Nothing
        Me.chbVendedor.BindearPropiedadEntidad = Nothing
        Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVendedor.IsPK = False
        Me.chbVendedor.IsRequired = False
        Me.chbVendedor.Key = Nothing
        Me.chbVendedor.LabelAsoc = Nothing
        Me.chbVendedor.Location = New System.Drawing.Point(603, 21)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 6
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Enabled = False
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Location = New System.Drawing.Point(677, 19)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(134, 21)
        Me.cmbVendedor.TabIndex = 7
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(828, 17)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 15
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbFechaNacimientoIncluirAnio
        '
        Me.chbFechaNacimientoIncluirAnio.AutoSize = True
        Me.chbFechaNacimientoIncluirAnio.BindearPropiedadControl = Nothing
        Me.chbFechaNacimientoIncluirAnio.BindearPropiedadEntidad = Nothing
        Me.chbFechaNacimientoIncluirAnio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaNacimientoIncluirAnio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaNacimientoIncluirAnio.IsPK = False
        Me.chbFechaNacimientoIncluirAnio.IsRequired = False
        Me.chbFechaNacimientoIncluirAnio.Key = Nothing
        Me.chbFechaNacimientoIncluirAnio.LabelAsoc = Nothing
        Me.chbFechaNacimientoIncluirAnio.Location = New System.Drawing.Point(603, 47)
        Me.chbFechaNacimientoIncluirAnio.Name = "chbFechaNacimientoIncluirAnio"
        Me.chbFechaNacimientoIncluirAnio.Size = New System.Drawing.Size(75, 17)
        Me.chbFechaNacimientoIncluirAnio.TabIndex = 14
        Me.chbFechaNacimientoIncluirAnio.Text = "Incluir año"
        Me.chbFechaNacimientoIncluirAnio.UseVisualStyleBackColor = True
        '
        'chbFechaNacimiento
        '
        Me.chbFechaNacimiento.AutoSize = True
        Me.chbFechaNacimiento.BindearPropiedadControl = Nothing
        Me.chbFechaNacimiento.BindearPropiedadEntidad = Nothing
        Me.chbFechaNacimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaNacimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaNacimiento.IsPK = False
        Me.chbFechaNacimiento.IsRequired = False
        Me.chbFechaNacimiento.Key = Nothing
        Me.chbFechaNacimiento.LabelAsoc = Nothing
        Me.chbFechaNacimiento.Location = New System.Drawing.Point(10, 47)
        Me.chbFechaNacimiento.Name = "chbFechaNacimiento"
        Me.chbFechaNacimiento.Size = New System.Drawing.Size(159, 17)
        Me.chbFechaNacimiento.TabIndex = 8
        Me.chbFechaNacimiento.Text = "Fecha Nac./Inicio Actividad"
        Me.chbFechaNacimiento.UseVisualStyleBackColor = True
        '
        'chkMesCompletoFechaNacimiento
        '
        Me.chkMesCompletoFechaNacimiento.AutoSize = True
        Me.chkMesCompletoFechaNacimiento.BindearPropiedadControl = Nothing
        Me.chkMesCompletoFechaNacimiento.BindearPropiedadEntidad = Nothing
        Me.chkMesCompletoFechaNacimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompletoFechaNacimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompletoFechaNacimiento.IsPK = False
        Me.chkMesCompletoFechaNacimiento.IsRequired = False
        Me.chkMesCompletoFechaNacimiento.Key = Nothing
        Me.chkMesCompletoFechaNacimiento.LabelAsoc = Nothing
        Me.chkMesCompletoFechaNacimiento.Location = New System.Drawing.Point(175, 47)
        Me.chkMesCompletoFechaNacimiento.Name = "chkMesCompletoFechaNacimiento"
        Me.chkMesCompletoFechaNacimiento.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompletoFechaNacimiento.TabIndex = 9
        Me.chkMesCompletoFechaNacimiento.Text = "Mes Completo"
        Me.chkMesCompletoFechaNacimiento.UseVisualStyleBackColor = True
        '
        'dtpFechaNacimientoHasta
        '
        Me.dtpFechaNacimientoHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaNacimientoHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaNacimientoHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaNacimientoHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaNacimientoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaNacimientoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaNacimientoHasta.IsPK = False
        Me.dtpFechaNacimientoHasta.IsRequired = False
        Me.dtpFechaNacimientoHasta.Key = ""
        Me.dtpFechaNacimientoHasta.LabelAsoc = Me.lblFechaNacimientoHasta
        Me.dtpFechaNacimientoHasta.Location = New System.Drawing.Point(471, 45)
        Me.dtpFechaNacimientoHasta.Name = "dtpFechaNacimientoHasta"
        Me.dtpFechaNacimientoHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaNacimientoHasta.TabIndex = 13
        '
        'lblFechaNacimientoHasta
        '
        Me.lblFechaNacimientoHasta.AutoSize = True
        Me.lblFechaNacimientoHasta.LabelAsoc = Nothing
        Me.lblFechaNacimientoHasta.Location = New System.Drawing.Point(435, 49)
        Me.lblFechaNacimientoHasta.Name = "lblFechaNacimientoHasta"
        Me.lblFechaNacimientoHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaNacimientoHasta.TabIndex = 12
        Me.lblFechaNacimientoHasta.Text = "Hasta"
        '
        'dtpFechaNacimientoDesde
        '
        Me.dtpFechaNacimientoDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaNacimientoDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaNacimientoDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaNacimientoDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaNacimientoDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaNacimientoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaNacimientoDesde.IsPK = False
        Me.dtpFechaNacimientoDesde.IsRequired = False
        Me.dtpFechaNacimientoDesde.Key = ""
        Me.dtpFechaNacimientoDesde.LabelAsoc = Me.lblFechaNacimientoDesde
        Me.dtpFechaNacimientoDesde.Location = New System.Drawing.Point(307, 45)
        Me.dtpFechaNacimientoDesde.Name = "dtpFechaNacimientoDesde"
        Me.dtpFechaNacimientoDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaNacimientoDesde.TabIndex = 11
        '
        'lblFechaNacimientoDesde
        '
        Me.lblFechaNacimientoDesde.AutoSize = True
        Me.lblFechaNacimientoDesde.LabelAsoc = Nothing
        Me.lblFechaNacimientoDesde.Location = New System.Drawing.Point(267, 49)
        Me.lblFechaNacimientoDesde.Name = "lblFechaNacimientoDesde"
        Me.lblFechaNacimientoDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaNacimientoDesde.TabIndex = 10
        Me.lblFechaNacimientoDesde.Text = "Desde"
        '
        'chbFechaAlta
        '
        Me.chbFechaAlta.AutoSize = True
        Me.chbFechaAlta.BindearPropiedadControl = Nothing
        Me.chbFechaAlta.BindearPropiedadEntidad = Nothing
        Me.chbFechaAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaAlta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaAlta.IsPK = False
        Me.chbFechaAlta.IsRequired = False
        Me.chbFechaAlta.Key = Nothing
        Me.chbFechaAlta.LabelAsoc = Nothing
        Me.chbFechaAlta.Location = New System.Drawing.Point(10, 21)
        Me.chbFechaAlta.Name = "chbFechaAlta"
        Me.chbFechaAlta.Size = New System.Drawing.Size(77, 17)
        Me.chbFechaAlta.TabIndex = 0
        Me.chbFechaAlta.Text = "Fecha Alta"
        Me.chbFechaAlta.UseVisualStyleBackColor = True
        '
        'chkMesCompletoFechaAlta
        '
        Me.chkMesCompletoFechaAlta.AutoSize = True
        Me.chkMesCompletoFechaAlta.BindearPropiedadControl = Nothing
        Me.chkMesCompletoFechaAlta.BindearPropiedadEntidad = Nothing
        Me.chkMesCompletoFechaAlta.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompletoFechaAlta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompletoFechaAlta.IsPK = False
        Me.chkMesCompletoFechaAlta.IsRequired = False
        Me.chkMesCompletoFechaAlta.Key = Nothing
        Me.chkMesCompletoFechaAlta.LabelAsoc = Nothing
        Me.chkMesCompletoFechaAlta.Location = New System.Drawing.Point(175, 21)
        Me.chkMesCompletoFechaAlta.Name = "chkMesCompletoFechaAlta"
        Me.chkMesCompletoFechaAlta.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompletoFechaAlta.TabIndex = 1
        Me.chkMesCompletoFechaAlta.Text = "Mes Completo"
        Me.chkMesCompletoFechaAlta.UseVisualStyleBackColor = True
        '
        'dtpFechaAltaHasta
        '
        Me.dtpFechaAltaHasta.BindearPropiedadControl = Nothing
        Me.dtpFechaAltaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAltaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaAltaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAltaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAltaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaAltaHasta.IsPK = False
        Me.dtpFechaAltaHasta.IsRequired = False
        Me.dtpFechaAltaHasta.Key = ""
        Me.dtpFechaAltaHasta.LabelAsoc = Me.lblFechaAltaHasta
        Me.dtpFechaAltaHasta.Location = New System.Drawing.Point(471, 19)
        Me.dtpFechaAltaHasta.Name = "dtpFechaAltaHasta"
        Me.dtpFechaAltaHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaAltaHasta.TabIndex = 5
        '
        'lblFechaAltaHasta
        '
        Me.lblFechaAltaHasta.AutoSize = True
        Me.lblFechaAltaHasta.LabelAsoc = Nothing
        Me.lblFechaAltaHasta.Location = New System.Drawing.Point(435, 23)
        Me.lblFechaAltaHasta.Name = "lblFechaAltaHasta"
        Me.lblFechaAltaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblFechaAltaHasta.TabIndex = 4
        Me.lblFechaAltaHasta.Text = "Hasta"
        '
        'dtpFechaAltaDesde
        '
        Me.dtpFechaAltaDesde.BindearPropiedadControl = Nothing
        Me.dtpFechaAltaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAltaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpFechaAltaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAltaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAltaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaAltaDesde.IsPK = False
        Me.dtpFechaAltaDesde.IsRequired = False
        Me.dtpFechaAltaDesde.Key = ""
        Me.dtpFechaAltaDesde.LabelAsoc = Me.lblFechaAltaDesde
        Me.dtpFechaAltaDesde.Location = New System.Drawing.Point(307, 19)
        Me.dtpFechaAltaDesde.Name = "dtpFechaAltaDesde"
        Me.dtpFechaAltaDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpFechaAltaDesde.TabIndex = 3
        '
        'lblFechaAltaDesde
        '
        Me.lblFechaAltaDesde.AutoSize = True
        Me.lblFechaAltaDesde.LabelAsoc = Nothing
        Me.lblFechaAltaDesde.Location = New System.Drawing.Point(267, 23)
        Me.lblFechaAltaDesde.Name = "lblFechaAltaDesde"
        Me.lblFechaAltaDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaAltaDesde.TabIndex = 2
        Me.lblFechaAltaDesde.Text = "Desde"
        '
        'ClientesABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 561)
        Me.Controls.Add(Me.grpFiltros)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ClientesABM"
        Me.Text = "Clientes"
        Me.Controls.SetChildIndex(Me.grpFiltros, 0)
        Me.Controls.SetChildIndex(Me.dgvDatos, 0)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents chbFechaNacimientoIncluirAnio As Eniac.Controles.CheckBox
    Friend WithEvents chbFechaNacimiento As Eniac.Controles.CheckBox
    Friend WithEvents chkMesCompletoFechaNacimiento As Eniac.Controles.CheckBox
    Friend WithEvents dtpFechaNacimientoHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaNacimientoHasta As Eniac.Controles.Label
    Friend WithEvents dtpFechaNacimientoDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaNacimientoDesde As Eniac.Controles.Label
    Friend WithEvents chbFechaAlta As Eniac.Controles.CheckBox
    Friend WithEvents chkMesCompletoFechaAlta As Eniac.Controles.CheckBox
    Friend WithEvents dtpFechaAltaHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaAltaHasta As Eniac.Controles.Label
    Friend WithEvents dtpFechaAltaDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblFechaAltaDesde As Eniac.Controles.Label
    Friend WithEvents btnConsultar As Eniac.Controles.Button
    Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
    Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
End Class
