<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentaCorrienteTurismo
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuota")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaAPagar")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MontoAPagar")
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
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CuentaCorrienteTurismo))
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.grbFormaPago = New System.Windows.Forms.GroupBox()
      Me.dgvCuotas = New Eniac.Win.UltraGridEditable()
      Me.dtpFechaViaje = New Eniac.Controles.DateTimePicker()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbFormaPago = New Eniac.Controles.ComboBox()
      Me.lblFormaPago = New Eniac.Controles.Label()
      Me.grbVariasCuotas = New System.Windows.Forms.GroupBox()
      Me.txtAdelanto = New Eniac.Controles.TextBox()
      Me.lblCuotas = New Eniac.Controles.Label()
      Me.lblAdelanto = New Eniac.Controles.Label()
      Me.txtCuotas = New Eniac.Controles.TextBox()
      Me.btnLimpiarProducto = New Eniac.Controles.Button()
      Me.btnInsertarVC = New Eniac.Controles.Button()
      Me.dtpPrimerVencimiento = New Eniac.Controles.DateTimePicker()
      Me.lblPrimerVencimiento = New Eniac.Controles.Label()
      Me.lblSaldo = New Eniac.Controles.Label()
      Me.txtSaldo = New Eniac.Controles.TextBox()
        Me.grbFormaPago.SuspendLayout()
        CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbVariasCuotas.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.AutoSize = True
        Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(196, 430)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(106, 38)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar (F4)"
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
        Me.btnCancelar.Location = New System.Drawing.Point(308, 430)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 38)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar (ESC)"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'grbFormaPago
        '
        Me.grbFormaPago.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFormaPago.Controls.Add(Me.dgvCuotas)
        Me.grbFormaPago.Controls.Add(Me.dtpFechaViaje)
        Me.grbFormaPago.Controls.Add(Me.Label1)
        Me.grbFormaPago.Controls.Add(Me.cmbFormaPago)
        Me.grbFormaPago.Controls.Add(Me.grbVariasCuotas)
        Me.grbFormaPago.Controls.Add(Me.lblFormaPago)
        Me.grbFormaPago.Controls.Add(Me.lblSaldo)
        Me.grbFormaPago.Controls.Add(Me.txtSaldo)
        Me.grbFormaPago.Location = New System.Drawing.Point(12, 12)
        Me.grbFormaPago.Name = "grbFormaPago"
        Me.grbFormaPago.Size = New System.Drawing.Size(402, 412)
        Me.grbFormaPago.TabIndex = 0
        Me.grbFormaPago.TabStop = False
        Me.grbFormaPago.Text = "Forma de pago"
        '
        'dgvCuotas
        '
        Me.dgvCuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvCuotas.DisplayLayout.Appearance = Appearance1
        Me.dgvCuotas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.VisiblePosition = 1
        UltraGridColumn1.Width = 64
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Format = "dd/MM/yyyy"
        UltraGridColumn2.Header.Caption = "Vencimiento"
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Width = 149
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "Monto"
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn3.Width = 149
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        Me.dgvCuotas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.dgvCuotas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.dgvCuotas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvCuotas.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvCuotas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.dgvCuotas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.dgvCuotas.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.dgvCuotas.DisplayLayout.MaxColScrollRegions = 1
        Me.dgvCuotas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvCuotas.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvCuotas.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.dgvCuotas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.dgvCuotas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.dgvCuotas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.dgvCuotas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.dgvCuotas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCuotas.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.dgvCuotas.DisplayLayout.Override.CellAppearance = Appearance11
        Me.dgvCuotas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.dgvCuotas.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.dgvCuotas.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.dgvCuotas.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.dgvCuotas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.dgvCuotas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.dgvCuotas.DisplayLayout.Override.RowAppearance = Appearance14
        Me.dgvCuotas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.dgvCuotas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.dgvCuotas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.dgvCuotas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.dgvCuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuotas.Location = New System.Drawing.Point(18, 136)
        Me.dgvCuotas.Name = "dgvCuotas"
        Me.dgvCuotas.Size = New System.Drawing.Size(364, 269)
        Me.dgvCuotas.TabIndex = 7
        Me.dgvCuotas.Text = "UltraGrid1"
        '
        'dtpFechaViaje
        '
        Me.dtpFechaViaje.BindearPropiedadControl = Nothing
        Me.dtpFechaViaje.BindearPropiedadEntidad = Nothing
        Me.dtpFechaViaje.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaViaje.Enabled = False
        Me.dtpFechaViaje.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaViaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaViaje.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaViaje.IsPK = False
        Me.dtpFechaViaje.IsRequired = False
        Me.dtpFechaViaje.Key = ""
        Me.dtpFechaViaje.LabelAsoc = Me.Label1
        Me.dtpFechaViaje.Location = New System.Drawing.Point(150, 37)
        Me.dtpFechaViaje.Name = "dtpFechaViaje"
        Me.dtpFechaViaje.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaViaje.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(147, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Viaje"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Me.lblFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(252, 37)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(130, 21)
        Me.cmbFormaPago.TabIndex = 5
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.LabelAsoc = Nothing
        Me.lblFormaPago.Location = New System.Drawing.Point(249, 20)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(79, 13)
        Me.lblFormaPago.TabIndex = 4
        Me.lblFormaPago.Text = "Forma de &Pago"
        '
        'grbVariasCuotas
        '
        Me.grbVariasCuotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbVariasCuotas.Controls.Add(Me.txtAdelanto)
        Me.grbVariasCuotas.Controls.Add(Me.lblAdelanto)
        Me.grbVariasCuotas.Controls.Add(Me.txtCuotas)
        Me.grbVariasCuotas.Controls.Add(Me.btnLimpiarProducto)
        Me.grbVariasCuotas.Controls.Add(Me.lblCuotas)
        Me.grbVariasCuotas.Controls.Add(Me.btnInsertarVC)
        Me.grbVariasCuotas.Controls.Add(Me.dtpPrimerVencimiento)
        Me.grbVariasCuotas.Controls.Add(Me.lblPrimerVencimiento)
        Me.grbVariasCuotas.Location = New System.Drawing.Point(6, 65)
        Me.grbVariasCuotas.Name = "grbVariasCuotas"
        Me.grbVariasCuotas.Size = New System.Drawing.Size(390, 65)
        Me.grbVariasCuotas.TabIndex = 6
        Me.grbVariasCuotas.TabStop = False
        Me.grbVariasCuotas.Text = "Calcular"
        '
        'txtAdelanto
        '
        Me.txtAdelanto.BindearPropiedadControl = Nothing
        Me.txtAdelanto.BindearPropiedadEntidad = Nothing
        Me.txtAdelanto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAdelanto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAdelanto.Formato = ""
        Me.txtAdelanto.IsDecimal = True
        Me.txtAdelanto.IsNumber = True
        Me.txtAdelanto.IsPK = False
        Me.txtAdelanto.IsRequired = False
        Me.txtAdelanto.Key = ""
        Me.txtAdelanto.LabelAsoc = Me.lblCuotas
        Me.txtAdelanto.Location = New System.Drawing.Point(166, 38)
        Me.txtAdelanto.MaxLength = 15
        Me.txtAdelanto.Name = "txtAdelanto"
        Me.txtAdelanto.Size = New System.Drawing.Size(87, 20)
        Me.txtAdelanto.TabIndex = 5
        Me.txtAdelanto.Text = "0.00"
        Me.txtAdelanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCuotas
        '
        Me.lblCuotas.AutoSize = True
        Me.lblCuotas.LabelAsoc = Nothing
        Me.lblCuotas.Location = New System.Drawing.Point(112, 22)
        Me.lblCuotas.Name = "lblCuotas"
        Me.lblCuotas.Size = New System.Drawing.Size(40, 13)
        Me.lblCuotas.TabIndex = 2
        Me.lblCuotas.Text = "Cuotas"
        '
        'lblAdelanto
        '
        Me.lblAdelanto.AutoSize = True
        Me.lblAdelanto.LabelAsoc = Nothing
        Me.lblAdelanto.Location = New System.Drawing.Point(175, 22)
        Me.lblAdelanto.Name = "lblAdelanto"
        Me.lblAdelanto.Size = New System.Drawing.Size(49, 13)
        Me.lblAdelanto.TabIndex = 4
        Me.lblAdelanto.Text = "Adelanto"
        '
        'txtCuotas
        '
        Me.txtCuotas.BindearPropiedadControl = Nothing
        Me.txtCuotas.BindearPropiedadEntidad = Nothing
        Me.txtCuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuotas.Formato = ""
        Me.txtCuotas.IsDecimal = False
        Me.txtCuotas.IsNumber = True
        Me.txtCuotas.IsPK = False
        Me.txtCuotas.IsRequired = False
        Me.txtCuotas.Key = ""
        Me.txtCuotas.LabelAsoc = Me.lblCuotas
        Me.txtCuotas.Location = New System.Drawing.Point(114, 38)
        Me.txtCuotas.MaxLength = 4
        Me.txtCuotas.Name = "txtCuotas"
        Me.txtCuotas.ReadOnly = True
        Me.txtCuotas.Size = New System.Drawing.Size(46, 20)
        Me.txtCuotas.TabIndex = 3
        Me.txtCuotas.Text = "1"
        Me.txtCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(339, 22)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(37, 37)
        Me.btnLimpiarProducto.TabIndex = 7
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'btnInsertarVC
        '
        Me.btnInsertarVC.Image = CType(resources.GetObject("btnInsertarVC.Image"), System.Drawing.Image)
        Me.btnInsertarVC.Location = New System.Drawing.Point(301, 22)
        Me.btnInsertarVC.Name = "btnInsertarVC"
        Me.btnInsertarVC.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertarVC.TabIndex = 6
        Me.btnInsertarVC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarVC.UseVisualStyleBackColor = True
        '
        'dtpPrimerVencimiento
        '
        Me.dtpPrimerVencimiento.BindearPropiedadControl = Nothing
        Me.dtpPrimerVencimiento.BindearPropiedadEntidad = Nothing
        Me.dtpPrimerVencimiento.CustomFormat = "dd/MM/yyyy"
        Me.dtpPrimerVencimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpPrimerVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpPrimerVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPrimerVencimiento.IsPK = False
        Me.dtpPrimerVencimiento.IsRequired = False
        Me.dtpPrimerVencimiento.Key = ""
        Me.dtpPrimerVencimiento.LabelAsoc = Me.lblPrimerVencimiento
        Me.dtpPrimerVencimiento.Location = New System.Drawing.Point(12, 38)
        Me.dtpPrimerVencimiento.Name = "dtpPrimerVencimiento"
        Me.dtpPrimerVencimiento.Size = New System.Drawing.Size(96, 20)
        Me.dtpPrimerVencimiento.TabIndex = 1
        '
        'lblPrimerVencimiento
        '
        Me.lblPrimerVencimiento.AutoSize = True
        Me.lblPrimerVencimiento.LabelAsoc = Nothing
        Me.lblPrimerVencimiento.Location = New System.Drawing.Point(9, 22)
        Me.lblPrimerVencimiento.Name = "lblPrimerVencimiento"
        Me.lblPrimerVencimiento.Size = New System.Drawing.Size(97, 13)
        Me.lblPrimerVencimiento.TabIndex = 0
        Me.lblPrimerVencimiento.Text = "Primer Vencimiento"
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.LabelAsoc = Nothing
        Me.lblSaldo.Location = New System.Drawing.Point(15, 20)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(68, 13)
        Me.lblSaldo.TabIndex = 0
        Me.lblSaldo.Text = "Importe Viaje"
        '
        'txtSaldo
        '
        Me.txtSaldo.BindearPropiedadControl = Nothing
        Me.txtSaldo.BindearPropiedadEntidad = Nothing
        Me.txtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldo.Formato = "N2"
        Me.txtSaldo.IsDecimal = True
        Me.txtSaldo.IsNumber = True
        Me.txtSaldo.IsPK = False
        Me.txtSaldo.IsRequired = False
        Me.txtSaldo.Key = ""
        Me.txtSaldo.LabelAsoc = Me.lblSaldo
        Me.txtSaldo.Location = New System.Drawing.Point(18, 36)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(126, 23)
        Me.txtSaldo.TabIndex = 1
        Me.txtSaldo.TabStop = False
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CuentaCorrienteTurismo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 472)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbFormaPago)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CuentaCorrienteTurismo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcular Cuotas"
        Me.grbFormaPago.ResumeLayout(False)
        Me.grbFormaPago.PerformLayout()
        CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbVariasCuotas.ResumeLayout(False)
        Me.grbVariasCuotas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents grbFormaPago As System.Windows.Forms.GroupBox
   Friend WithEvents lblSaldo As Eniac.Controles.Label
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents grbVariasCuotas As System.Windows.Forms.GroupBox
   Friend WithEvents btnInsertarVC As Eniac.Controles.Button
   Friend WithEvents dtpPrimerVencimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPrimerVencimiento As Eniac.Controles.Label
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents lblFormaPago As Eniac.Controles.Label
   Friend WithEvents txtCuotas As Eniac.Controles.TextBox
   Friend WithEvents lblCuotas As Eniac.Controles.Label
   Friend WithEvents txtAdelanto As Eniac.Controles.TextBox
   Friend WithEvents lblAdelanto As Eniac.Controles.Label
   Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
   Friend WithEvents dtpFechaViaje As Eniac.Controles.DateTimePicker
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dgvCuotas As UltraGridEditable
End Class
