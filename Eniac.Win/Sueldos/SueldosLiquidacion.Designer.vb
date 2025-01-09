<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosLiquidacion
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosLiquidacion))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idTipoConcepto")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoConcepto")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idConcepto")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreConcepto")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Total")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoConcepto")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.dtpPeriodo = New Eniac.Controles.DateTimePicker()
      Me.txtCantidadLiqPeriodo = New System.Windows.Forms.TextBox()
      Me.lblCantLiqPeriodo = New Eniac.Controles.Label()
      Me.txtCantidadLiq = New System.Windows.Forms.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtLugarPago = New System.Windows.Forms.TextBox()
      Me.lblTiposDeRecibos = New Eniac.Controles.Label()
      Me.cmbTiposRecibos = New Eniac.Controles.ComboBox()
      Me.cmbLugarActividad = New Eniac.Controles.ComboBox()
      Me.chbPorLugarActividad = New Eniac.Controles.CheckBox()
      Me.lblSueldosFechaPago = New Eniac.Controles.Label()
      Me.dtpSueldosFechaPago = New Eniac.Controles.DateTimePicker()
      Me.txtNumeroLiquidacion = New System.Windows.Forms.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGenerar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrarLiquidacion = New System.Windows.Forms.ToolStripButton()
      Me.tsbReAbrirLiquidacion = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugdDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grbPendientes.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      CType(Me.ugdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.dtpPeriodo)
      Me.grbPendientes.Controls.Add(Me.txtCantidadLiqPeriodo)
      Me.grbPendientes.Controls.Add(Me.lblCantLiqPeriodo)
      Me.grbPendientes.Controls.Add(Me.txtCantidadLiq)
      Me.grbPendientes.Controls.Add(Me.Label2)
      Me.grbPendientes.Controls.Add(Me.Label1)
      Me.grbPendientes.Controls.Add(Me.txtLugarPago)
      Me.grbPendientes.Controls.Add(Me.lblTiposDeRecibos)
      Me.grbPendientes.Controls.Add(Me.cmbTiposRecibos)
      Me.grbPendientes.Controls.Add(Me.cmbLugarActividad)
      Me.grbPendientes.Controls.Add(Me.chbPorLugarActividad)
      Me.grbPendientes.Controls.Add(Me.lblSueldosFechaPago)
      Me.grbPendientes.Controls.Add(Me.dtpSueldosFechaPago)
      Me.grbPendientes.Controls.Add(Me.txtNumeroLiquidacion)
      Me.grbPendientes.Controls.Add(Me.Label3)
      Me.grbPendientes.Controls.Add(Me.lblArchivo)
      Me.grbPendientes.Location = New System.Drawing.Point(12, 25)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(818, 64)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.BindearPropiedadControl = "Value"
      Me.dtpPeriodo.BindearPropiedadEntidad = "FechaNacimiento"
      Me.dtpPeriodo.CustomFormat = "yyyyMM"
      Me.dtpPeriodo.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPeriodo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.IsPK = False
      Me.dtpPeriodo.IsRequired = False
      Me.dtpPeriodo.Key = ""
      Me.dtpPeriodo.LabelAsoc = Nothing
      Me.dtpPeriodo.Location = New System.Drawing.Point(177, 28)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(66, 20)
      Me.dtpPeriodo.TabIndex = 1
      Me.dtpPeriodo.Tag = ""
      '
      'txtCantidadLiqPeriodo
      '
      Me.txtCantidadLiqPeriodo.Location = New System.Drawing.Point(397, 28)
      Me.txtCantidadLiqPeriodo.MaxLength = 2
      Me.txtCantidadLiqPeriodo.Name = "txtCantidadLiqPeriodo"
      Me.txtCantidadLiqPeriodo.ReadOnly = True
      Me.txtCantidadLiqPeriodo.Size = New System.Drawing.Size(29, 20)
      Me.txtCantidadLiqPeriodo.TabIndex = 46
      Me.txtCantidadLiqPeriodo.Tag = ""
      Me.txtCantidadLiqPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.txtCantidadLiqPeriodo.Visible = False
      '
      'lblCantLiqPeriodo
      '
      Me.lblCantLiqPeriodo.AutoSize = True
      Me.lblCantLiqPeriodo.Location = New System.Drawing.Point(375, 14)
      Me.lblCantLiqPeriodo.Name = "lblCantLiqPeriodo"
      Me.lblCantLiqPeriodo.Size = New System.Drawing.Size(91, 13)
      Me.lblCantLiqPeriodo.TabIndex = 45
      Me.lblCantLiqPeriodo.Text = "Cant. Liq. Periodo"
      Me.lblCantLiqPeriodo.Visible = False
      '
      'txtCantidadLiq
      '
      Me.txtCantidadLiq.Location = New System.Drawing.Point(332, 28)
      Me.txtCantidadLiq.MaxLength = 2
      Me.txtCantidadLiq.Name = "txtCantidadLiq"
      Me.txtCantidadLiq.ReadOnly = True
      Me.txtCantidadLiq.Size = New System.Drawing.Size(29, 20)
      Me.txtCantidadLiq.TabIndex = 44
      Me.txtCantidadLiq.Tag = ""
      Me.txtCantidadLiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(321, 14)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(52, 13)
      Me.Label2.TabIndex = 43
      Me.Label2.Text = "Cant. Liq."
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(481, 13)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(77, 13)
      Me.Label1.TabIndex = 42
      Me.Label1.Text = "Lugar de Pago"
      '
      'txtLugarPago
      '
      Me.txtLugarPago.Location = New System.Drawing.Point(462, 28)
      Me.txtLugarPago.MaxLength = 50
      Me.txtLugarPago.Name = "txtLugarPago"
      Me.txtLugarPago.Size = New System.Drawing.Size(120, 20)
      Me.txtLugarPago.TabIndex = 41
      '
      'lblTiposDeRecibos
      '
      Me.lblTiposDeRecibos.AutoSize = True
      Me.lblTiposDeRecibos.Location = New System.Drawing.Point(3, 14)
      Me.lblTiposDeRecibos.Name = "lblTiposDeRecibos"
      Me.lblTiposDeRecibos.Size = New System.Drawing.Size(90, 13)
      Me.lblTiposDeRecibos.TabIndex = 40
      Me.lblTiposDeRecibos.Text = "Tipos de Recibos"
      '
      'cmbTiposRecibos
      '
      Me.cmbTiposRecibos.BindearPropiedadControl = ""
      Me.cmbTiposRecibos.BindearPropiedadEntidad = ""
      Me.cmbTiposRecibos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposRecibos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposRecibos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposRecibos.FormattingEnabled = True
      Me.cmbTiposRecibos.IsPK = False
      Me.cmbTiposRecibos.IsRequired = True
      Me.cmbTiposRecibos.Key = Nothing
      Me.cmbTiposRecibos.LabelAsoc = Nothing
      Me.cmbTiposRecibos.Location = New System.Drawing.Point(6, 28)
      Me.cmbTiposRecibos.Name = "cmbTiposRecibos"
      Me.cmbTiposRecibos.Size = New System.Drawing.Size(154, 21)
      Me.cmbTiposRecibos.TabIndex = 39
      '
      'cmbLugarActividad
      '
      Me.cmbLugarActividad.BindearPropiedadControl = ""
      Me.cmbLugarActividad.BindearPropiedadEntidad = ""
      Me.cmbLugarActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLugarActividad.Enabled = False
      Me.cmbLugarActividad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLugarActividad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLugarActividad.FormattingEnabled = True
      Me.cmbLugarActividad.IsPK = False
      Me.cmbLugarActividad.IsRequired = True
      Me.cmbLugarActividad.Key = Nothing
      Me.cmbLugarActividad.LabelAsoc = Nothing
      Me.cmbLugarActividad.Location = New System.Drawing.Point(676, 28)
      Me.cmbLugarActividad.Name = "cmbLugarActividad"
      Me.cmbLugarActividad.Size = New System.Drawing.Size(134, 21)
      Me.cmbLugarActividad.TabIndex = 37
      Me.cmbLugarActividad.Visible = False
      '
      'chbPorLugarActividad
      '
      Me.chbPorLugarActividad.AutoSize = True
      Me.chbPorLugarActividad.BindearPropiedadControl = Nothing
      Me.chbPorLugarActividad.BindearPropiedadEntidad = Nothing
      Me.chbPorLugarActividad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPorLugarActividad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPorLugarActividad.IsPK = False
      Me.chbPorLugarActividad.IsRequired = False
      Me.chbPorLugarActividad.Key = Nothing
      Me.chbPorLugarActividad.LabelAsoc = Nothing
      Me.chbPorLugarActividad.Location = New System.Drawing.Point(676, 13)
      Me.chbPorLugarActividad.Name = "chbPorLugarActividad"
      Me.chbPorLugarActividad.Size = New System.Drawing.Size(134, 17)
      Me.chbPorLugarActividad.TabIndex = 38
      Me.chbPorLugarActividad.Text = "Por Lugar de Actividad"
      Me.chbPorLugarActividad.UseVisualStyleBackColor = True
      Me.chbPorLugarActividad.Visible = False
      '
      'lblSueldosFechaPago
      '
      Me.lblSueldosFechaPago.AutoSize = True
      Me.lblSueldosFechaPago.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblSueldosFechaPago.Location = New System.Drawing.Point(582, 13)
      Me.lblSueldosFechaPago.Name = "lblSueldosFechaPago"
      Me.lblSueldosFechaPago.Size = New System.Drawing.Size(80, 13)
      Me.lblSueldosFechaPago.TabIndex = 36
      Me.lblSueldosFechaPago.Text = "Fecha de Pago"
      '
      'dtpSueldosFechaPago
      '
      Me.dtpSueldosFechaPago.BindearPropiedadControl = "Value"
      Me.dtpSueldosFechaPago.BindearPropiedadEntidad = "FechaNacimiento"
      Me.dtpSueldosFechaPago.CustomFormat = "dd/MM/yyyy"
      Me.dtpSueldosFechaPago.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpSueldosFechaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpSueldosFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpSueldosFechaPago.IsPK = False
      Me.dtpSueldosFechaPago.IsRequired = False
      Me.dtpSueldosFechaPago.Key = ""
      Me.dtpSueldosFechaPago.LabelAsoc = Nothing
      Me.dtpSueldosFechaPago.Location = New System.Drawing.Point(585, 28)
      Me.dtpSueldosFechaPago.Name = "dtpSueldosFechaPago"
      Me.dtpSueldosFechaPago.Size = New System.Drawing.Size(85, 20)
      Me.dtpSueldosFechaPago.TabIndex = 35
      Me.dtpSueldosFechaPago.Tag = "SUELDOS_FECHA_DE_PAGO"
      '
      'txtNumeroLiquidacion
      '
      Me.txtNumeroLiquidacion.Location = New System.Drawing.Point(271, 28)
      Me.txtNumeroLiquidacion.MaxLength = 2
      Me.txtNumeroLiquidacion.Name = "txtNumeroLiquidacion"
      Me.txtNumeroLiquidacion.ReadOnly = True
      Me.txtNumeroLiquidacion.Size = New System.Drawing.Size(29, 20)
      Me.txtNumeroLiquidacion.TabIndex = 3
      Me.txtNumeroLiquidacion.Tag = ""
      Me.txtNumeroLiquidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(257, 14)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(59, 13)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "Nro de Liq."
      '
      'lblArchivo
      '
      Me.lblArchivo.AutoSize = True
      Me.lblArchivo.Location = New System.Drawing.Point(162, 14)
      Me.lblArchivo.Name = "lblArchivo"
      Me.lblArchivo.Size = New System.Drawing.Size(93, 13)
      Me.lblArchivo.TabIndex = 0
      Me.lblArchivo.Text = "Período a generar"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbGenerar, Me.ToolStripSeparator2, Me.tsbCerrarLiquidacion, Me.tsbReAbrirLiquidacion, Me.ToolStripSeparator1, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(842, 29)
      Me.tstBarra.TabIndex = 0
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
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGenerar
      '
      Me.tsbGenerar.Image = CType(resources.GetObject("tsbGenerar.Image"), System.Drawing.Image)
      Me.tsbGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGenerar.Name = "tsbGenerar"
      Me.tsbGenerar.Size = New System.Drawing.Size(139, 26)
      Me.tsbGenerar.Text = "&Generar Liquidación"
      Me.tsbGenerar.ToolTipText = "Generar los Productos"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrarLiquidacion
      '
      Me.tsbCerrarLiquidacion.Image = CType(resources.GetObject("tsbCerrarLiquidacion.Image"), System.Drawing.Image)
      Me.tsbCerrarLiquidacion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrarLiquidacion.Name = "tsbCerrarLiquidacion"
      Me.tsbCerrarLiquidacion.Size = New System.Drawing.Size(130, 26)
      Me.tsbCerrarLiquidacion.Text = "Cerrar &Liquidación"
      '
      'tsbReAbrirLiquidacion
      '
      Me.tsbReAbrirLiquidacion.Image = Global.Eniac.Win.My.Resources.Resources.run_unlock_32
      Me.tsbReAbrirLiquidacion.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbReAbrirLiquidacion.Name = "tsbReAbrirLiquidacion"
      Me.tsbReAbrirLiquidacion.Size = New System.Drawing.Size(135, 26)
      Me.tsbReAbrirLiquidacion.Text = "Reabrir Liquidación"
      Me.tsbReAbrirLiquidacion.Visible = False
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 438)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(842, 22)
      Me.StatusStrip1.TabIndex = 5
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(827, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ugdDetalle
      '
      Me.ugdDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugdDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Tipo Concepto"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 198
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Hidden = True
      UltraGridColumn4.Header.Caption = "Concepto"
      UltraGridColumn4.Header.VisiblePosition = 4
      UltraGridColumn4.Width = 381
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance2
      UltraGridColumn5.Format = "N2"
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn5.Width = 125
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn6.CellAppearance = Appearance3
      UltraGridColumn6.Header.Caption = "Codigo"
      UltraGridColumn6.Header.VisiblePosition = 3
      UltraGridColumn6.Width = 70
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
      Me.ugdDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugdDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugdDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance4.BorderColor = System.Drawing.SystemColors.Window
      Me.ugdDetalle.DisplayLayout.GroupByBox.Appearance = Appearance4
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugdDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
      Me.ugdDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugdDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna para agrupar"
      Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance6.BackColor2 = System.Drawing.SystemColors.Control
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugdDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
      Me.ugdDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugdDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugdDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance7
      Appearance8.BackColor = System.Drawing.SystemColors.Highlight
      Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugdDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance8
      Me.ugdDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugdDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugdDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Me.ugdDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance9
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugdDetalle.DisplayLayout.Override.CellAppearance = Appearance10
      Me.ugdDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugdDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance11.BackColor = System.Drawing.SystemColors.Control
      Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.BorderColor = System.Drawing.SystemColors.Window
      Me.ugdDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance11
      Me.ugdDetalle.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
      Appearance12.TextHAlignAsString = "Left"
      Me.ugdDetalle.DisplayLayout.Override.HeaderAppearance = Appearance12
      Me.ugdDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugdDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Me.ugdDetalle.DisplayLayout.Override.RowAppearance = Appearance13
      Me.ugdDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugdDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.InGroupByRows
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugdDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
      Me.ugdDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugdDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugdDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugdDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugdDetalle.Location = New System.Drawing.Point(13, 95)
      Me.ugdDetalle.Name = "ugdDetalle"
      Me.ugdDetalle.Size = New System.Drawing.Size(817, 340)
      Me.ugdDetalle.TabIndex = 8
      Me.ugdDetalle.Text = "UltraGrid1"
      '
      'SueldosLiquidacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(842, 460)
      Me.Controls.Add(Me.ugdDetalle)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbPendientes)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "SueldosLiquidacion"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Generación de Recibos"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      CType(Me.ugdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents lblArchivo As Eniac.Controles.Label
   Friend WithEvents txtNumeroLiquidacion As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents tsbGenerar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblSueldosFechaPago As Eniac.Controles.Label
   Friend WithEvents dtpSueldosFechaPago As Eniac.Controles.DateTimePicker
   Friend WithEvents tsbCerrarLiquidacion As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbLugarActividad As Eniac.Controles.ComboBox
   Friend WithEvents chbPorLugarActividad As Eniac.Controles.CheckBox
   Friend WithEvents idTipoConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblTiposDeRecibos As Eniac.Controles.Label
   Friend WithEvents cmbTiposRecibos As Eniac.Controles.ComboBox
   Friend WithEvents ugdDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtLugarPago As System.Windows.Forms.TextBox
   Friend WithEvents txtCantidadLiq As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtCantidadLiqPeriodo As System.Windows.Forms.TextBox
   Friend WithEvents lblCantLiqPeriodo As Eniac.Controles.Label
   Friend WithEvents tsbReAbrirLiquidacion As System.Windows.Forms.ToolStripButton
   Friend WithEvents dtpPeriodo As Eniac.Controles.DateTimePicker
End Class
