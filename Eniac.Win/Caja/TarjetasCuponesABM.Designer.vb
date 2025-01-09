<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarjetasCuponesABM
   Inherits BaseABM2

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grpFiltros = New Eniac.Controles.GroupBox()
      Me.chbSituacion = New Eniac.Controles.CheckBox()
      Me.cmbSituacionTarjetaCupones = New Eniac.Win.ComboBoxSucursales()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.chbFechaEnCarteraAl = New Eniac.Controles.CheckBox()
      Me.dtpFechaEnCarteraAl = New Eniac.Controles.DateTimePicker()
      Me.chbFechaIngreso = New Eniac.Controles.CheckBox()
      Me.dtpIngresoHasta = New Eniac.Controles.DateTimePicker()
      Me.Label1 = New Eniac.Controles.Label()
      Me.dtpIngresoDesde = New Eniac.Controles.DateTimePicker()
      Me.Label2 = New Eniac.Controles.Label()
      Me.chbEstado = New Eniac.Controles.CheckBox()
      Me.cmbEstado = New Eniac.Controles.ComboBox()
      Me.chbNumeroLote = New Eniac.Controles.CheckBox()
      Me.txtNumeroLote = New Eniac.Controles.TextBox()
      Me.chbCaja = New Eniac.Controles.CheckBox()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.chbNumeroCupon = New Eniac.Controles.CheckBox()
        Me.txtNumeroCupon = New Eniac.Controles.TextBox()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.cmbBanco = New Eniac.Controles.ComboBox()
        Me.chbBanco = New Eniac.Controles.CheckBox()
        Me.gridContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GridContextMenuManager1 = New Eniac.Win.GridContextMenuManager()
        Me.FiltersManager1 = New Eniac.Win.FilterManager.FilterManager(Me.components)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltros.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDatos
        '
        Me.dgvDatos.ContextMenuStrip = Me.gridContextMenuStrip
        UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvDatos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
        Me.dgvDatos.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvDatos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance1.BackColor = System.Drawing.SystemColors.Highlight
        Appearance1.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvDatos.DisplayLayout.Override.ActiveRowAppearance = Appearance1
        Me.dgvDatos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Appearance2.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.CellAppearance = Appearance2
        Me.dgvDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Appearance3.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.FixedHeaderAppearance = Appearance3
        Appearance4.ForeColor = System.Drawing.Color.ForestGreen
        Me.dgvDatos.DisplayLayout.Override.HeaderAppearance = Appearance4
        Me.dgvDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance5.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance5
        Appearance6.BorderColor = System.Drawing.Color.Silver
        Me.dgvDatos.DisplayLayout.Override.RowAppearance = Appearance6
        Appearance7.ForeColor = System.Drawing.Color.Gray
        Me.dgvDatos.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance7
        Me.dgvDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.dgvDatos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvDatos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
        Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.dgvDatos.Location = New System.Drawing.Point(0, 159)
        Me.dgvDatos.Size = New System.Drawing.Size(955, 285)
        Me.dgvDatos.TabIndex = 1
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.chbSituacion)
        Me.grpFiltros.Controls.Add(Me.cmbSituacionTarjetaCupones)
        Me.grpFiltros.Controls.Add(Me.cmbSucursal)
        Me.grpFiltros.Controls.Add(Me.lblSucursal)
        Me.grpFiltros.Controls.Add(Me.chbFechaEnCarteraAl)
        Me.grpFiltros.Controls.Add(Me.dtpFechaEnCarteraAl)
        Me.grpFiltros.Controls.Add(Me.chbFechaIngreso)
        Me.grpFiltros.Controls.Add(Me.dtpIngresoHasta)
        Me.grpFiltros.Controls.Add(Me.dtpIngresoDesde)
        Me.grpFiltros.Controls.Add(Me.Label1)
        Me.grpFiltros.Controls.Add(Me.Label2)
        Me.grpFiltros.Controls.Add(Me.chbEstado)
        Me.grpFiltros.Controls.Add(Me.cmbEstado)
        Me.grpFiltros.Controls.Add(Me.chbNumeroLote)
        Me.grpFiltros.Controls.Add(Me.txtNumeroLote)
        Me.grpFiltros.Controls.Add(Me.chbCaja)
        Me.grpFiltros.Controls.Add(Me.cmbCajas)
        Me.grpFiltros.Controls.Add(Me.chbNumeroCupon)
        Me.grpFiltros.Controls.Add(Me.txtNumeroCupon)
        Me.grpFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grpFiltros.Controls.Add(Me.bscCliente)
        Me.grpFiltros.Controls.Add(Me.chbCliente)
        Me.grpFiltros.Controls.Add(Me.btnConsultar)
        Me.grpFiltros.Controls.Add(Me.cmbBanco)
        Me.grpFiltros.Controls.Add(Me.chbBanco)
        Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(955, 130)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        Me.grpFiltros.Text = "Filtros"
        '
        'chbSituacion
        '
        Me.chbSituacion.AutoSize = True
        Me.chbSituacion.BindearPropiedadControl = Nothing
        Me.chbSituacion.BindearPropiedadEntidad = Nothing
        Me.chbSituacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSituacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSituacion.IsPK = False
        Me.chbSituacion.IsRequired = False
        Me.chbSituacion.Key = Nothing
        Me.chbSituacion.LabelAsoc = Nothing
        Me.chbSituacion.Location = New System.Drawing.Point(480, 98)
        Me.chbSituacion.Name = "chbSituacion"
        Me.chbSituacion.Size = New System.Drawing.Size(70, 17)
        Me.chbSituacion.TabIndex = 64
        Me.chbSituacion.Text = "Situación"
        Me.chbSituacion.UseVisualStyleBackColor = True
        '
        'cmbSituacionTarjetaCupones
        '
        Me.cmbSituacionTarjetaCupones.BindearPropiedadControl = Nothing
        Me.cmbSituacionTarjetaCupones.BindearPropiedadEntidad = Nothing
        Me.cmbSituacionTarjetaCupones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSituacionTarjetaCupones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSituacionTarjetaCupones.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSituacionTarjetaCupones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSituacionTarjetaCupones.FormattingEnabled = True
        Me.cmbSituacionTarjetaCupones.IsPK = False
        Me.cmbSituacionTarjetaCupones.IsRequired = False
        Me.cmbSituacionTarjetaCupones.ItemHeight = 13
        Me.cmbSituacionTarjetaCupones.Key = Nothing
        Me.cmbSituacionTarjetaCupones.LabelAsoc = Nothing
        Me.cmbSituacionTarjetaCupones.Location = New System.Drawing.Point(556, 95)
        Me.cmbSituacionTarjetaCupones.Name = "cmbSituacionTarjetaCupones"
        Me.cmbSituacionTarjetaCupones.Size = New System.Drawing.Size(163, 21)
        Me.cmbSituacionTarjetaCupones.TabIndex = 63
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(680, 54)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(143, 21)
        Me.cmbSucursal.TabIndex = 61
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(626, 57)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 60
        Me.lblSucursal.Text = "Sucursal"
        '
        'chbFechaEnCarteraAl
        '
        Me.chbFechaEnCarteraAl.AutoSize = True
        Me.chbFechaEnCarteraAl.BindearPropiedadControl = Nothing
        Me.chbFechaEnCarteraAl.BindearPropiedadEntidad = Nothing
        Me.chbFechaEnCarteraAl.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaEnCarteraAl.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaEnCarteraAl.IsPK = False
        Me.chbFechaEnCarteraAl.IsRequired = False
        Me.chbFechaEnCarteraAl.Key = Nothing
        Me.chbFechaEnCarteraAl.LabelAsoc = Nothing
        Me.chbFechaEnCarteraAl.Location = New System.Drawing.Point(12, 54)
        Me.chbFechaEnCarteraAl.Name = "chbFechaEnCarteraAl"
        Me.chbFechaEnCarteraAl.Size = New System.Drawing.Size(88, 17)
        Me.chbFechaEnCarteraAl.TabIndex = 47
        Me.chbFechaEnCarteraAl.Text = "En Cartera Al"
        Me.chbFechaEnCarteraAl.UseVisualStyleBackColor = True
        '
        'dtpFechaEnCarteraAl
        '
        Me.dtpFechaEnCarteraAl.BindearPropiedadControl = Nothing
        Me.dtpFechaEnCarteraAl.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEnCarteraAl.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEnCarteraAl.Enabled = False
        Me.dtpFechaEnCarteraAl.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEnCarteraAl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEnCarteraAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEnCarteraAl.IsPK = False
        Me.dtpFechaEnCarteraAl.IsRequired = False
        Me.dtpFechaEnCarteraAl.Key = ""
        Me.dtpFechaEnCarteraAl.LabelAsoc = Nothing
        Me.dtpFechaEnCarteraAl.Location = New System.Drawing.Point(106, 51)
        Me.dtpFechaEnCarteraAl.Name = "dtpFechaEnCarteraAl"
        Me.dtpFechaEnCarteraAl.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEnCarteraAl.TabIndex = 48
        '
        'chbFechaIngreso
        '
        Me.chbFechaIngreso.AutoSize = True
        Me.chbFechaIngreso.BindearPropiedadControl = Nothing
        Me.chbFechaIngreso.BindearPropiedadEntidad = Nothing
        Me.chbFechaIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaIngreso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaIngreso.IsPK = False
        Me.chbFechaIngreso.IsRequired = False
        Me.chbFechaIngreso.Key = Nothing
        Me.chbFechaIngreso.LabelAsoc = Nothing
        Me.chbFechaIngreso.Location = New System.Drawing.Point(12, 19)
        Me.chbFechaIngreso.Name = "chbFechaIngreso"
        Me.chbFechaIngreso.Size = New System.Drawing.Size(61, 17)
        Me.chbFechaIngreso.TabIndex = 31
        Me.chbFechaIngreso.Text = "Ingreso"
        Me.chbFechaIngreso.UseVisualStyleBackColor = True
        '
        'dtpIngresoHasta
        '
        Me.dtpIngresoHasta.BindearPropiedadControl = Nothing
        Me.dtpIngresoHasta.BindearPropiedadEntidad = Nothing
        Me.dtpIngresoHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpIngresoHasta.Enabled = False
        Me.dtpIngresoHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpIngresoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpIngresoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIngresoHasta.IsPK = False
        Me.dtpIngresoHasta.IsRequired = False
        Me.dtpIngresoHasta.Key = ""
        Me.dtpIngresoHasta.LabelAsoc = Me.Label1
        Me.dtpIngresoHasta.Location = New System.Drawing.Point(264, 17)
        Me.dtpIngresoHasta.Name = "dtpIngresoHasta"
        Me.dtpIngresoHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpIngresoHasta.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(224, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Hasta"
        '
        'dtpIngresoDesde
        '
        Me.dtpIngresoDesde.BindearPropiedadControl = Nothing
        Me.dtpIngresoDesde.BindearPropiedadEntidad = Nothing
        Me.dtpIngresoDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpIngresoDesde.Enabled = False
        Me.dtpIngresoDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpIngresoDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpIngresoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpIngresoDesde.IsPK = False
        Me.dtpIngresoDesde.IsRequired = False
        Me.dtpIngresoDesde.Key = ""
        Me.dtpIngresoDesde.LabelAsoc = Me.Label2
        Me.dtpIngresoDesde.Location = New System.Drawing.Point(121, 17)
        Me.dtpIngresoDesde.Name = "dtpIngresoDesde"
        Me.dtpIngresoDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpIngresoDesde.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(83, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Desde"
        '
        'chbEstado
        '
        Me.chbEstado.AutoSize = True
        Me.chbEstado.BindearPropiedadControl = Nothing
        Me.chbEstado.BindearPropiedadEntidad = Nothing
        Me.chbEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstado.IsPK = False
        Me.chbEstado.IsRequired = False
        Me.chbEstado.Key = Nothing
        Me.chbEstado.LabelAsoc = Nothing
        Me.chbEstado.Location = New System.Drawing.Point(371, 19)
        Me.chbEstado.Name = "chbEstado"
        Me.chbEstado.Size = New System.Drawing.Size(59, 17)
        Me.chbEstado.TabIndex = 36
        Me.chbEstado.Text = "Estado"
        Me.chbEstado.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.BindearPropiedadControl = Nothing
        Me.cmbEstado.BindearPropiedadEntidad = Nothing
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Enabled = False
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.IsPK = False
        Me.cmbEstado.IsRequired = False
        Me.cmbEstado.Key = Nothing
        Me.cmbEstado.LabelAsoc = Nothing
        Me.cmbEstado.Location = New System.Drawing.Point(434, 17)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(125, 21)
        Me.cmbEstado.TabIndex = 37
        '
        'chbNumeroLote
        '
        Me.chbNumeroLote.AutoSize = True
        Me.chbNumeroLote.BindearPropiedadControl = Nothing
        Me.chbNumeroLote.BindearPropiedadEntidad = Nothing
        Me.chbNumeroLote.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroLote.IsPK = False
        Me.chbNumeroLote.IsRequired = False
        Me.chbNumeroLote.Key = Nothing
        Me.chbNumeroLote.LabelAsoc = Nothing
        Me.chbNumeroLote.Location = New System.Drawing.Point(705, 18)
        Me.chbNumeroLote.Name = "chbNumeroLote"
        Me.chbNumeroLote.Size = New System.Drawing.Size(47, 17)
        Me.chbNumeroLote.TabIndex = 45
        Me.chbNumeroLote.Text = "Lote"
        Me.chbNumeroLote.UseVisualStyleBackColor = True
        '
        'txtNumeroLote
        '
        Me.txtNumeroLote.BindearPropiedadControl = Nothing
        Me.txtNumeroLote.BindearPropiedadEntidad = Nothing
        Me.txtNumeroLote.Enabled = False
        Me.txtNumeroLote.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroLote.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroLote.Formato = "##0"
        Me.txtNumeroLote.IsDecimal = False
        Me.txtNumeroLote.IsNumber = True
        Me.txtNumeroLote.IsPK = False
        Me.txtNumeroLote.IsRequired = False
        Me.txtNumeroLote.Key = ""
        Me.txtNumeroLote.LabelAsoc = Nothing
        Me.txtNumeroLote.Location = New System.Drawing.Point(754, 16)
        Me.txtNumeroLote.MaxLength = 8
        Me.txtNumeroLote.Name = "txtNumeroLote"
        Me.txtNumeroLote.Size = New System.Drawing.Size(69, 20)
        Me.txtNumeroLote.TabIndex = 46
        Me.txtNumeroLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbCaja
        '
        Me.chbCaja.AutoSize = True
        Me.chbCaja.BindearPropiedadControl = Nothing
        Me.chbCaja.BindearPropiedadEntidad = Nothing
        Me.chbCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCaja.IsPK = False
        Me.chbCaja.IsRequired = False
        Me.chbCaja.Key = Nothing
        Me.chbCaja.LabelAsoc = Nothing
        Me.chbCaja.Location = New System.Drawing.Point(212, 54)
        Me.chbCaja.Name = "chbCaja"
        Me.chbCaja.Size = New System.Drawing.Size(47, 17)
        Me.chbCaja.TabIndex = 49
        Me.chbCaja.Text = "Caja"
        Me.chbCaja.UseVisualStyleBackColor = True
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = ""
        Me.cmbCajas.BindearPropiedadEntidad = ""
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Enabled = False
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Nothing
        Me.cmbCajas.Location = New System.Drawing.Point(264, 52)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(130, 21)
        Me.cmbCajas.TabIndex = 50
        '
        'chbNumeroCupon
        '
        Me.chbNumeroCupon.AutoSize = True
        Me.chbNumeroCupon.BindearPropiedadControl = Nothing
        Me.chbNumeroCupon.BindearPropiedadEntidad = Nothing
        Me.chbNumeroCupon.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroCupon.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroCupon.IsPK = False
        Me.chbNumeroCupon.IsRequired = False
        Me.chbNumeroCupon.Key = Nothing
        Me.chbNumeroCupon.LabelAsoc = Nothing
        Me.chbNumeroCupon.Location = New System.Drawing.Point(566, 19)
        Me.chbNumeroCupon.Name = "chbNumeroCupon"
        Me.chbNumeroCupon.Size = New System.Drawing.Size(57, 17)
        Me.chbNumeroCupon.TabIndex = 43
        Me.chbNumeroCupon.Text = "Cupón"
        Me.chbNumeroCupon.UseVisualStyleBackColor = True
        '
        'txtNumeroCupon
        '
        Me.txtNumeroCupon.BindearPropiedadControl = Nothing
        Me.txtNumeroCupon.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCupon.Enabled = False
        Me.txtNumeroCupon.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCupon.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCupon.Formato = "##0"
        Me.txtNumeroCupon.IsDecimal = False
        Me.txtNumeroCupon.IsNumber = True
        Me.txtNumeroCupon.IsPK = False
        Me.txtNumeroCupon.IsRequired = False
        Me.txtNumeroCupon.Key = ""
        Me.txtNumeroCupon.LabelAsoc = Nothing
        Me.txtNumeroCupon.Location = New System.Drawing.Point(625, 17)
        Me.txtNumeroCupon.MaxLength = 8
        Me.txtNumeroCupon.Name = "txtNumeroCupon"
        Me.txtNumeroCupon.Size = New System.Drawing.Size(69, 20)
        Me.txtNumeroCupon.TabIndex = 44
        Me.txtNumeroCupon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(76, 95)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 55
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.Enabled = False
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Nothing
        Me.bscCliente.Location = New System.Drawing.Point(173, 95)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = True
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(300, 23)
        Me.bscCliente.TabIndex = 57
        '
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(12, 98)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 53
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(843, 53)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 58
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'cmbBanco
        '
        Me.cmbBanco.BindearPropiedadControl = ""
        Me.cmbBanco.BindearPropiedadEntidad = ""
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.Enabled = False
        Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.IsPK = True
        Me.cmbBanco.IsRequired = True
        Me.cmbBanco.Key = Nothing
        Me.cmbBanco.LabelAsoc = Nothing
        Me.cmbBanco.Location = New System.Drawing.Point(460, 53)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(160, 21)
        Me.cmbBanco.TabIndex = 52
        '
        'chbBanco
        '
        Me.chbBanco.AutoSize = True
        Me.chbBanco.BindearPropiedadControl = Nothing
        Me.chbBanco.BindearPropiedadEntidad = Nothing
        Me.chbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBanco.IsPK = False
        Me.chbBanco.IsRequired = False
        Me.chbBanco.Key = Nothing
        Me.chbBanco.LabelAsoc = Nothing
        Me.chbBanco.Location = New System.Drawing.Point(400, 55)
        Me.chbBanco.Name = "chbBanco"
        Me.chbBanco.Size = New System.Drawing.Size(57, 17)
        Me.chbBanco.TabIndex = 51
        Me.chbBanco.Text = "Banco"
        Me.chbBanco.UseVisualStyleBackColor = True
        '
        'gridContextMenuStrip
        '
        Me.gridContextMenuStrip.Name = "gridContextMenuStrip"
        Me.gridContextMenuStrip.Size = New System.Drawing.Size(61, 4)
        '
        'GridContextMenuManager1
        '
        Me.GridContextMenuManager1.Grilla = Me.dgvDatos
        Me.GridContextMenuManager1.Menu = Me.gridContextMenuStrip
        '
        'FiltersManager1
        '
        Me.FiltersManager1.BotonRefrescar = Me.tsbRefrescar
        Me.FiltersManager1.PanelFiltro = Me.grpFiltros
        '
        'TarjetasCuponesABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 466)
        Me.Controls.Add(Me.grpFiltros)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "TarjetasCuponesABM"
        Me.Text = "Cupones de Tarjetas"
        Me.Controls.SetChildIndex(Me.grpFiltros, 0)
        Me.Controls.SetChildIndex(Me.dgvDatos, 0)
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFiltros As Eniac.Controles.GroupBox
   Friend WithEvents gridContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Private WithEvents GridContextMenuManager1 As Eniac.Win.GridContextMenuManager
   Friend WithEvents FiltersManager1 As Eniac.Win.FilterManager.FilterManager
   Friend WithEvents cmbSucursal As ComboBoxSucursales
   Friend WithEvents lblSucursal As Controles.Label
   Friend WithEvents chbFechaEnCarteraAl As Controles.CheckBox
   Friend WithEvents dtpFechaEnCarteraAl As Controles.DateTimePicker
   Friend WithEvents chbFechaIngreso As Controles.CheckBox
   Friend WithEvents dtpIngresoHasta As Controles.DateTimePicker
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents dtpIngresoDesde As Controles.DateTimePicker
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents chbEstado As Controles.CheckBox
   Friend WithEvents cmbEstado As Controles.ComboBox
   Friend WithEvents chbNumeroLote As Controles.CheckBox
   Friend WithEvents txtNumeroLote As Controles.TextBox
   Friend WithEvents chbCaja As Controles.CheckBox
   Friend WithEvents cmbCajas As Controles.ComboBox
    Friend WithEvents chbNumeroCupon As Controles.CheckBox
    Friend WithEvents txtNumeroCupon As Controles.TextBox
   Friend WithEvents bscCodigoCliente As Controles.Buscador2
   Friend WithEvents bscCliente As Controles.Buscador2
   Friend WithEvents chbCliente As Controles.CheckBox
   Friend WithEvents btnConsultar As Controles.Button
   Friend WithEvents cmbBanco As Controles.ComboBox
   Friend WithEvents chbBanco As Controles.CheckBox
   Friend WithEvents cmbSituacionTarjetaCupones As ComboBoxSucursales
   Friend WithEvents chbSituacion As Controles.CheckBox
End Class

