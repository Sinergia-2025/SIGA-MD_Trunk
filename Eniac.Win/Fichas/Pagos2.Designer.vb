<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pagos2
   Inherits Eniac.Win.BaseForm

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pagos2))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cuota")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoCuota")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargo")
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
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.cmbCobrador = New Eniac.Controles.ComboBox()
      Me.lblCobrador = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.lblFecha = New Eniac.Controles.Label()
      Me.lblImporte = New Eniac.Controles.Label()
      Me.txtImporte = New Eniac.Controles.TextBox()
      Me.btnGrabar = New Eniac.Controles.Button()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.lblInteres = New Eniac.Controles.Label()
      Me.txtInteres = New Eniac.Controles.TextBox()
      Me.lblConcepto = New Eniac.Controles.Label()
      Me.txtConcepto = New Eniac.Controles.TextBox()
      Me.grbCajas = New System.Windows.Forms.GroupBox()
      Me.txtCaja = New Eniac.Controles.MaskedTextBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.ugInteresesCuotas = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.txtTotal = New Eniac.Controles.TextBox()
      Me.lblTotal = New Eniac.Controles.Label()
      Me.grbCajas.SuspendLayout()
      CType(Me.ugInteresesCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "check2.ico")
      Me.imgGrabar.Images.SetKeyName(1, "delete2.ico")
      '
      'cmbCobrador
      '
      Me.cmbCobrador.BindearPropiedadControl = Nothing
      Me.cmbCobrador.BindearPropiedadEntidad = Nothing
      Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCobrador.FormattingEnabled = True
      Me.cmbCobrador.IsPK = False
      Me.cmbCobrador.IsRequired = False
      Me.cmbCobrador.Key = Nothing
      Me.cmbCobrador.LabelAsoc = Me.lblCobrador
      Me.cmbCobrador.Location = New System.Drawing.Point(78, 207)
      Me.cmbCobrador.Name = "cmbCobrador"
      Me.cmbCobrador.Size = New System.Drawing.Size(181, 21)
      Me.cmbCobrador.TabIndex = 10
      '
      'lblCobrador
      '
      Me.lblCobrador.AutoSize = True
      Me.lblCobrador.Location = New System.Drawing.Point(22, 210)
      Me.lblCobrador.Name = "lblCobrador"
      Me.lblCobrador.Size = New System.Drawing.Size(50, 13)
      Me.lblCobrador.TabIndex = 9
      Me.lblCobrador.Text = "Cobrador"
      '
      'dtpFecha
      '
      Me.dtpFecha.BindearPropiedadControl = Nothing
      Me.dtpFecha.BindearPropiedadEntidad = Nothing
      Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
      Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFecha.IsPK = False
      Me.dtpFecha.IsRequired = False
      Me.dtpFecha.Key = ""
      Me.dtpFecha.LabelAsoc = Me.lblFecha
      Me.dtpFecha.Location = New System.Drawing.Point(16, 90)
      Me.dtpFecha.Name = "dtpFecha"
      Me.dtpFecha.Size = New System.Drawing.Size(96, 20)
      Me.dtpFecha.TabIndex = 2
      '
      'lblFecha
      '
      Me.lblFecha.AutoSize = True
      Me.lblFecha.Location = New System.Drawing.Point(13, 74)
      Me.lblFecha.Name = "lblFecha"
      Me.lblFecha.Size = New System.Drawing.Size(37, 13)
      Me.lblFecha.TabIndex = 1
      Me.lblFecha.Text = "Fecha"
      '
      'lblImporte
      '
      Me.lblImporte.AutoSize = True
      Me.lblImporte.Location = New System.Drawing.Point(115, 74)
      Me.lblImporte.Name = "lblImporte"
      Me.lblImporte.Size = New System.Drawing.Size(42, 13)
      Me.lblImporte.TabIndex = 3
      Me.lblImporte.Text = "Importe"
      '
      'txtImporte
      '
      Me.txtImporte.BindearPropiedadControl = Nothing
      Me.txtImporte.BindearPropiedadEntidad = Nothing
      Me.txtImporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporte.Formato = "N2"
      Me.txtImporte.IsDecimal = True
      Me.txtImporte.IsNumber = True
      Me.txtImporte.IsPK = False
      Me.txtImporte.IsRequired = False
      Me.txtImporte.Key = ""
      Me.txtImporte.LabelAsoc = Me.lblImporte
      Me.txtImporte.Location = New System.Drawing.Point(118, 90)
      Me.txtImporte.Name = "txtImporte"
      Me.txtImporte.Size = New System.Drawing.Size(67, 20)
      Me.txtImporte.TabIndex = 4
      Me.txtImporte.Text = "0.00"
      Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnGrabar
      '
      Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGrabar.ImageKey = "check2.ico"
      Me.btnGrabar.ImageList = Me.imgGrabar
      Me.btnGrabar.Location = New System.Drawing.Point(430, 244)
      Me.btnGrabar.Name = "btnGrabar"
      Me.btnGrabar.Size = New System.Drawing.Size(85, 30)
      Me.btnGrabar.TabIndex = 14
      Me.btnGrabar.Text = "Grabar"
      Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGrabar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgGrabar
      Me.btnCancelar.Location = New System.Drawing.Point(521, 244)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 15
      Me.btnCancelar.Text = "Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'lblInteres
      '
      Me.lblInteres.AutoSize = True
      Me.lblInteres.Location = New System.Drawing.Point(189, 74)
      Me.lblInteres.Name = "lblInteres"
      Me.lblInteres.Size = New System.Drawing.Size(39, 13)
      Me.lblInteres.TabIndex = 5
      Me.lblInteres.Text = "Interes"
      '
      'txtInteres
      '
      Me.txtInteres.BindearPropiedadControl = Nothing
      Me.txtInteres.BindearPropiedadEntidad = Nothing
      Me.txtInteres.ForeColorFocus = System.Drawing.Color.Red
      Me.txtInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtInteres.Formato = "N2"
      Me.txtInteres.IsDecimal = True
      Me.txtInteres.IsNumber = True
      Me.txtInteres.IsPK = False
      Me.txtInteres.IsRequired = False
      Me.txtInteres.Key = ""
      Me.txtInteres.LabelAsoc = Me.lblInteres
      Me.txtInteres.Location = New System.Drawing.Point(192, 90)
      Me.txtInteres.Name = "txtInteres"
      Me.txtInteres.Size = New System.Drawing.Size(67, 20)
      Me.txtInteres.TabIndex = 6
      Me.txtInteres.Text = "0.00"
      Me.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblConcepto
      '
      Me.lblConcepto.AutoSize = True
      Me.lblConcepto.Location = New System.Drawing.Point(13, 113)
      Me.lblConcepto.Name = "lblConcepto"
      Me.lblConcepto.Size = New System.Drawing.Size(53, 13)
      Me.lblConcepto.TabIndex = 7
      Me.lblConcepto.Text = "Concepto"
      '
      'txtConcepto
      '
      Me.txtConcepto.BindearPropiedadControl = Nothing
      Me.txtConcepto.BindearPropiedadEntidad = Nothing
      Me.txtConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtConcepto.Formato = ""
      Me.txtConcepto.IsDecimal = False
      Me.txtConcepto.IsNumber = False
      Me.txtConcepto.IsPK = False
      Me.txtConcepto.IsRequired = False
      Me.txtConcepto.Key = ""
      Me.txtConcepto.LabelAsoc = Me.lblConcepto
      Me.txtConcepto.Location = New System.Drawing.Point(16, 129)
      Me.txtConcepto.Multiline = True
      Me.txtConcepto.Name = "txtConcepto"
      Me.txtConcepto.ReadOnly = True
      Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtConcepto.Size = New System.Drawing.Size(243, 72)
      Me.txtConcepto.TabIndex = 8
      '
      'grbCajas
      '
      Me.grbCajas.Controls.Add(Me.txtCaja)
      Me.grbCajas.Controls.Add(Me.lblCaja)
      Me.grbCajas.Location = New System.Drawing.Point(15, 19)
      Me.grbCajas.Name = "grbCajas"
      Me.grbCajas.Size = New System.Drawing.Size(244, 45)
      Me.grbCajas.TabIndex = 0
      Me.grbCajas.TabStop = False
      '
      'txtCaja
      '
      Me.txtCaja.BindearPropiedadControl = Nothing
      Me.txtCaja.BindearPropiedadEntidad = Nothing
      Me.txtCaja.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCaja.IsDecimal = False
      Me.txtCaja.IsNumber = True
      Me.txtCaja.IsPK = False
      Me.txtCaja.IsRequired = False
      Me.txtCaja.Key = ""
      Me.txtCaja.LabelAsoc = Me.lblCaja
      Me.txtCaja.Location = New System.Drawing.Point(50, 16)
      Me.txtCaja.Name = "txtCaja"
      Me.txtCaja.ReadOnly = True
      Me.txtCaja.Size = New System.Drawing.Size(155, 20)
      Me.txtCaja.TabIndex = 1
      '
      'lblCaja
      '
      Me.lblCaja.AutoSize = True
      Me.lblCaja.Location = New System.Drawing.Point(11, 20)
      Me.lblCaja.Name = "lblCaja"
      Me.lblCaja.Size = New System.Drawing.Size(28, 13)
      Me.lblCaja.TabIndex = 0
      Me.lblCaja.Text = "Caja"
      '
      'ugInteresesCuotas
      '
      Me.ugInteresesCuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugInteresesCuotas.DisplayLayout.Appearance = Appearance1
      Me.ugInteresesCuotas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Header.Caption = "Nro."
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 38
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn2.CellAppearance = Appearance3
      UltraGridColumn2.Format = "dd/MM/yyyy"
      UltraGridColumn2.Header.Caption = "Vencimiento"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 81
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn3.CellAppearance = Appearance4
      UltraGridColumn3.Format = "N2"
      UltraGridColumn3.Header.Caption = "Saldo"
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 105
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance5
      UltraGridColumn4.Format = "N2"
      UltraGridColumn4.Header.Caption = "Interés"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 100
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
      Me.ugInteresesCuotas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugInteresesCuotas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugInteresesCuotas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
      Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance6.BorderColor = System.Drawing.SystemColors.Window
      Me.ugInteresesCuotas.DisplayLayout.GroupByBox.Appearance = Appearance6
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugInteresesCuotas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
      Me.ugInteresesCuotas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance8.BackColor2 = System.Drawing.SystemColors.Control
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugInteresesCuotas.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
      Me.ugInteresesCuotas.DisplayLayout.MaxColScrollRegions = 1
      Me.ugInteresesCuotas.DisplayLayout.MaxRowScrollRegions = 1
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugInteresesCuotas.DisplayLayout.Override.ActiveCellAppearance = Appearance9
      Appearance10.BackColor = System.Drawing.SystemColors.Highlight
      Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugInteresesCuotas.DisplayLayout.Override.ActiveRowAppearance = Appearance10
      Me.ugInteresesCuotas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugInteresesCuotas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugInteresesCuotas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugInteresesCuotas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugInteresesCuotas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Me.ugInteresesCuotas.DisplayLayout.Override.CardAreaAppearance = Appearance11
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugInteresesCuotas.DisplayLayout.Override.CellAppearance = Appearance12
      Me.ugInteresesCuotas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugInteresesCuotas.DisplayLayout.Override.CellPadding = 0
      Appearance13.BackColor = System.Drawing.SystemColors.Control
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugInteresesCuotas.DisplayLayout.Override.GroupByRowAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Left"
      Me.ugInteresesCuotas.DisplayLayout.Override.HeaderAppearance = Appearance14
      Me.ugInteresesCuotas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugInteresesCuotas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Me.ugInteresesCuotas.DisplayLayout.Override.RowAppearance = Appearance15
      Me.ugInteresesCuotas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugInteresesCuotas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
      Me.ugInteresesCuotas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugInteresesCuotas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugInteresesCuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugInteresesCuotas.Location = New System.Drawing.Point(280, 19)
      Me.ugInteresesCuotas.Name = "ugInteresesCuotas"
      Me.ugInteresesCuotas.Size = New System.Drawing.Size(326, 209)
      Me.ugInteresesCuotas.TabIndex = 11
      Me.ugInteresesCuotas.Text = "Intereses de Cuotas"
      '
      'txtTotal
      '
      Me.txtTotal.BindearPropiedadControl = Nothing
      Me.txtTotal.BindearPropiedadEntidad = Nothing
      Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotal.Formato = ""
      Me.txtTotal.IsDecimal = True
      Me.txtTotal.IsNumber = True
      Me.txtTotal.IsPK = False
      Me.txtTotal.IsRequired = False
      Me.txtTotal.Key = ""
      Me.txtTotal.LabelAsoc = Me.lblTotal
      Me.txtTotal.Location = New System.Drawing.Point(162, 234)
      Me.txtTotal.Name = "txtTotal"
      Me.txtTotal.ReadOnly = True
      Me.txtTotal.Size = New System.Drawing.Size(97, 23)
      Me.txtTotal.TabIndex = 13
      Me.txtTotal.TabStop = False
      Me.txtTotal.Text = "0.00"
      Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotal
      '
      Me.lblTotal.AutoSize = True
      Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotal.Location = New System.Drawing.Point(117, 237)
      Me.lblTotal.Name = "lblTotal"
      Me.lblTotal.Size = New System.Drawing.Size(40, 17)
      Me.lblTotal.TabIndex = 12
      Me.lblTotal.Text = "Total"
      '
      'Pagos2
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(618, 286)
      Me.Controls.Add(Me.ugInteresesCuotas)
      Me.Controls.Add(Me.grbCajas)
      Me.Controls.Add(Me.txtConcepto)
      Me.Controls.Add(Me.lblConcepto)
      Me.Controls.Add(Me.lblTotal)
      Me.Controls.Add(Me.lblInteres)
      Me.Controls.Add(Me.txtTotal)
      Me.Controls.Add(Me.txtInteres)
      Me.Controls.Add(Me.cmbCobrador)
      Me.Controls.Add(Me.dtpFecha)
      Me.Controls.Add(Me.lblFecha)
      Me.Controls.Add(Me.lblImporte)
      Me.Controls.Add(Me.txtImporte)
      Me.Controls.Add(Me.lblCobrador)
      Me.Controls.Add(Me.btnGrabar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Pagos2"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Pagos"
      Me.grbCajas.ResumeLayout(False)
      Me.grbCajas.PerformLayout()
      CType(Me.ugInteresesCuotas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnGrabar As Eniac.Controles.Button
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents lblImporte As Eniac.Controles.Label
   Friend WithEvents txtImporte As Eniac.Controles.TextBox
   Friend WithEvents lblCobrador As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFecha As Eniac.Controles.Label
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
   Friend WithEvents lblInteres As Eniac.Controles.Label
   Friend WithEvents txtInteres As Eniac.Controles.TextBox
   Friend WithEvents lblConcepto As Eniac.Controles.Label
   Friend WithEvents txtConcepto As Eniac.Controles.TextBox
   Friend WithEvents grbCajas As System.Windows.Forms.GroupBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents txtCaja As Eniac.Controles.MaskedTextBox
   Friend WithEvents ugInteresesCuotas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents txtTotal As Eniac.Controles.TextBox
   Friend WithEvents lblTotal As Eniac.Controles.Label
End Class
