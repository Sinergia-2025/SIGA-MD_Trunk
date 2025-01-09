<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegimenesPercepcionesDetalle
   Inherits Eniac.Win.BaseDetalle

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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoImpuesto")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRegimenPercepcion")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AlicuotaPercepcion")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegimenesPercepcionesDetalle))
        Me.lblIdTipoImpuesto = New Eniac.Controles.Label()
        Me.lblIdRegimen = New Eniac.Controles.Label()
        Me.txtIdRegimen = New Eniac.Controles.TextBox()
        Me.lblCodigoAfip = New Eniac.Controles.Label()
        Me.txtCodigoAfip = New Eniac.Controles.TextBox()
        Me.txtNombre = New Eniac.Controles.TextBox()
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtImporteNetoMinimo = New Eniac.Controles.TextBox()
        Me.lblImporteNetoMinimo = New Eniac.Controles.Label()
        Me.ugAlicuotas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblAlicutotaPercepcion = New Eniac.Controles.Label()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.pnlAlicuotas = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbAlicutotaPercepcion = New Eniac.Controles.ComboBox()
        Me.cmbTipoImpuesto = New Eniac.Controles.ComboBox()
        Me.lblImpuestoMinimo = New Eniac.Controles.Label()
        Me.txtImpuestoMinimo = New Eniac.Controles.TextBox()
        CType(Me.ugAlicuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAlicuotas.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(308, 334)
        Me.btnAceptar.TabIndex = 13
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(394, 334)
        Me.btnCancelar.TabIndex = 14
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(207, 334)
        Me.btnCopiar.TabIndex = 16
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(150, 334)
        Me.btnAplicar.TabIndex = 15
        '
        'lblIdTipoImpuesto
        '
        Me.lblIdTipoImpuesto.AutoSize = True
        Me.lblIdTipoImpuesto.LabelAsoc = Nothing
        Me.lblIdTipoImpuesto.Location = New System.Drawing.Point(16, 27)
        Me.lblIdTipoImpuesto.Name = "lblIdTipoImpuesto"
        Me.lblIdTipoImpuesto.Size = New System.Drawing.Size(89, 13)
        Me.lblIdTipoImpuesto.TabIndex = 0
        Me.lblIdTipoImpuesto.Text = "Tipo de Impuesto"
        '
        'lblIdRegimen
        '
        Me.lblIdRegimen.AutoSize = True
        Me.lblIdRegimen.LabelAsoc = Nothing
        Me.lblIdRegimen.Location = New System.Drawing.Point(16, 55)
        Me.lblIdRegimen.Name = "lblIdRegimen"
        Me.lblIdRegimen.Size = New System.Drawing.Size(85, 13)
        Me.lblIdRegimen.TabIndex = 2
        Me.lblIdRegimen.Text = "Código Régimen"
        '
        'txtIdRegimen
        '
        Me.txtIdRegimen.BindearPropiedadControl = "Text"
        Me.txtIdRegimen.BindearPropiedadEntidad = "IdRegimenPercepcion"
        Me.txtIdRegimen.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdRegimen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdRegimen.Formato = "N0"
        Me.txtIdRegimen.IsDecimal = False
        Me.txtIdRegimen.IsNumber = True
        Me.txtIdRegimen.IsPK = True
        Me.txtIdRegimen.IsRequired = True
        Me.txtIdRegimen.Key = ""
        Me.txtIdRegimen.LabelAsoc = Me.lblIdRegimen
        Me.txtIdRegimen.Location = New System.Drawing.Point(128, 51)
        Me.txtIdRegimen.MaxLength = 50
        Me.txtIdRegimen.Name = "txtIdRegimen"
        Me.txtIdRegimen.Size = New System.Drawing.Size(59, 20)
        Me.txtIdRegimen.TabIndex = 3
        Me.txtIdRegimen.Text = "0"
        Me.txtIdRegimen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodigoAfip
        '
        Me.lblCodigoAfip.AutoSize = True
        Me.lblCodigoAfip.LabelAsoc = Nothing
        Me.lblCodigoAfip.Location = New System.Drawing.Point(230, 56)
        Me.lblCodigoAfip.Name = "lblCodigoAfip"
        Me.lblCodigoAfip.Size = New System.Drawing.Size(66, 13)
        Me.lblCodigoAfip.TabIndex = 4
        Me.lblCodigoAfip.Text = "Código AFIP"
        '
        'txtCodigoAfip
        '
        Me.txtCodigoAfip.BindearPropiedadControl = "Text"
        Me.txtCodigoAfip.BindearPropiedadEntidad = "CodigoAFIP"
        Me.txtCodigoAfip.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoAfip.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoAfip.Formato = "N0"
        Me.txtCodigoAfip.IsDecimal = False
        Me.txtCodigoAfip.IsNumber = True
        Me.txtCodigoAfip.IsPK = False
        Me.txtCodigoAfip.IsRequired = True
        Me.txtCodigoAfip.Key = ""
        Me.txtCodigoAfip.LabelAsoc = Me.lblCodigoAfip
        Me.txtCodigoAfip.Location = New System.Drawing.Point(325, 52)
        Me.txtCodigoAfip.MaxLength = 50
        Me.txtCodigoAfip.Name = "txtCodigoAfip"
        Me.txtCodigoAfip.Size = New System.Drawing.Size(59, 20)
        Me.txtCodigoAfip.TabIndex = 5
        Me.txtCodigoAfip.Text = "0"
        Me.txtCodigoAfip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreRegimenPercepcion"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(128, 77)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(256, 20)
        Me.txtNombre.TabIndex = 7
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(16, 81)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 6
        Me.lblNombre.Text = "Nombre"
        '
        'txtImporteNetoMinimo
        '
        Me.txtImporteNetoMinimo.BindearPropiedadControl = "Text"
        Me.txtImporteNetoMinimo.BindearPropiedadEntidad = "ImporteNetoMinimo"
        Me.txtImporteNetoMinimo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteNetoMinimo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteNetoMinimo.Formato = "N2"
        Me.txtImporteNetoMinimo.IsDecimal = True
        Me.txtImporteNetoMinimo.IsNumber = True
        Me.txtImporteNetoMinimo.IsPK = False
        Me.txtImporteNetoMinimo.IsRequired = True
        Me.txtImporteNetoMinimo.Key = ""
        Me.txtImporteNetoMinimo.LabelAsoc = Me.lblImporteNetoMinimo
        Me.txtImporteNetoMinimo.Location = New System.Drawing.Point(128, 103)
        Me.txtImporteNetoMinimo.MaxLength = 50
        Me.txtImporteNetoMinimo.Name = "txtImporteNetoMinimo"
        Me.txtImporteNetoMinimo.Size = New System.Drawing.Size(59, 20)
        Me.txtImporteNetoMinimo.TabIndex = 9
        Me.txtImporteNetoMinimo.Text = "0.00"
        Me.txtImporteNetoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblImporteNetoMinimo
        '
        Me.lblImporteNetoMinimo.AutoSize = True
        Me.lblImporteNetoMinimo.LabelAsoc = Nothing
        Me.lblImporteNetoMinimo.Location = New System.Drawing.Point(16, 107)
        Me.lblImporteNetoMinimo.Name = "lblImporteNetoMinimo"
        Me.lblImporteNetoMinimo.Size = New System.Drawing.Size(106, 13)
        Me.lblImporteNetoMinimo.TabIndex = 8
        Me.lblImporteNetoMinimo.Text = "Importe Neto Mínimo"
        '
        'ugAlicuotas
        '
        Me.ugAlicuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugAlicuotas.DisplayLayout.Appearance = Appearance1
        Me.ugAlicuotas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance2
        UltraGridColumn3.Format = "N2"
        UltraGridColumn3.Header.Caption = "Alicuota"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 100
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
        Me.ugAlicuotas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugAlicuotas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAlicuotas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugAlicuotas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugAlicuotas.DisplayLayout.GroupByBox.Hidden = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugAlicuotas.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugAlicuotas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugAlicuotas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugAlicuotas.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugAlicuotas.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugAlicuotas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugAlicuotas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugAlicuotas.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugAlicuotas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugAlicuotas.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugAlicuotas.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugAlicuotas.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugAlicuotas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugAlicuotas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugAlicuotas.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugAlicuotas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugAlicuotas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugAlicuotas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugAlicuotas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugAlicuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugAlicuotas.Location = New System.Drawing.Point(95, 3)
        Me.ugAlicuotas.Name = "ugAlicuotas"
        Me.pnlAlicuotas.SetRowSpan(Me.ugAlicuotas, 4)
        Me.ugAlicuotas.Size = New System.Drawing.Size(102, 186)
        Me.ugAlicuotas.TabIndex = 4
        Me.ugAlicuotas.Text = "Alicuotas"
        '
        'lblAlicutotaPercepcion
        '
        Me.lblAlicutotaPercepcion.AutoSize = True
        Me.pnlAlicuotas.SetColumnSpan(Me.lblAlicutotaPercepcion, 2)
        Me.lblAlicutotaPercepcion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAlicutotaPercepcion.LabelAsoc = Nothing
        Me.lblAlicutotaPercepcion.Location = New System.Drawing.Point(3, 0)
        Me.lblAlicutotaPercepcion.Name = "lblAlicutotaPercepcion"
        Me.lblAlicutotaPercepcion.Size = New System.Drawing.Size(45, 13)
        Me.lblAlicutotaPercepcion.TabIndex = 0
        Me.lblAlicutotaPercepcion.Text = "Alicuota"
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertar.Location = New System.Drawing.Point(3, 43)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 2
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminar.Location = New System.Drawing.Point(49, 43)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'pnlAlicuotas
        '
        Me.pnlAlicuotas.ColumnCount = 3
        Me.pnlAlicuotas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlAlicuotas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.pnlAlicuotas.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlAlicuotas.Controls.Add(Me.ugAlicuotas, 2, 0)
        Me.pnlAlicuotas.Controls.Add(Me.btnInsertar, 0, 2)
        Me.pnlAlicuotas.Controls.Add(Me.cmbAlicutotaPercepcion, 0, 1)
        Me.pnlAlicuotas.Controls.Add(Me.lblAlicutotaPercepcion, 0, 0)
        Me.pnlAlicuotas.Controls.Add(Me.btnEliminar, 1, 2)
        Me.pnlAlicuotas.Location = New System.Drawing.Point(128, 129)
        Me.pnlAlicuotas.Name = "pnlAlicuotas"
        Me.pnlAlicuotas.RowCount = 4
        Me.pnlAlicuotas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlAlicuotas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlAlicuotas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlAlicuotas.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.pnlAlicuotas.Size = New System.Drawing.Size(200, 191)
        Me.pnlAlicuotas.TabIndex = 12
        '
        'cmbAlicutotaPercepcion
        '
        Me.cmbAlicutotaPercepcion.BindearPropiedadControl = Nothing
        Me.cmbAlicutotaPercepcion.BindearPropiedadEntidad = Nothing
        Me.pnlAlicuotas.SetColumnSpan(Me.cmbAlicutotaPercepcion, 2)
        Me.cmbAlicutotaPercepcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlicutotaPercepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbAlicutotaPercepcion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAlicutotaPercepcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAlicutotaPercepcion.FormattingEnabled = True
        Me.cmbAlicutotaPercepcion.IsPK = False
        Me.cmbAlicutotaPercepcion.IsRequired = False
        Me.cmbAlicutotaPercepcion.Key = Nothing
        Me.cmbAlicutotaPercepcion.LabelAsoc = Me.lblAlicutotaPercepcion
        Me.cmbAlicutotaPercepcion.Location = New System.Drawing.Point(3, 16)
        Me.cmbAlicutotaPercepcion.Name = "cmbAlicutotaPercepcion"
        Me.cmbAlicutotaPercepcion.Size = New System.Drawing.Size(86, 21)
        Me.cmbAlicutotaPercepcion.TabIndex = 1
        '
        'cmbTipoImpuesto
        '
        Me.cmbTipoImpuesto.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoImpuesto.BindearPropiedadEntidad = "IdTipoImpuesto"
        Me.cmbTipoImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoImpuesto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoImpuesto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoImpuesto.FormattingEnabled = True
        Me.cmbTipoImpuesto.IsPK = True
        Me.cmbTipoImpuesto.IsRequired = True
        Me.cmbTipoImpuesto.Key = Nothing
        Me.cmbTipoImpuesto.LabelAsoc = Nothing
        Me.cmbTipoImpuesto.Location = New System.Drawing.Point(128, 24)
        Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
        Me.cmbTipoImpuesto.Size = New System.Drawing.Size(213, 21)
        Me.cmbTipoImpuesto.TabIndex = 1
        '
        'lblImpuestoMinimo
        '
        Me.lblImpuestoMinimo.AutoSize = True
        Me.lblImpuestoMinimo.LabelAsoc = Nothing
        Me.lblImpuestoMinimo.Location = New System.Drawing.Point(213, 107)
        Me.lblImpuestoMinimo.Name = "lblImpuestoMinimo"
        Me.lblImpuestoMinimo.Size = New System.Drawing.Size(88, 13)
        Me.lblImpuestoMinimo.TabIndex = 10
        Me.lblImpuestoMinimo.Text = "Impuesto Mínimo"
        '
        'txtImpuestoMinimo
        '
        Me.txtImpuestoMinimo.BindearPropiedadControl = "Text"
        Me.txtImpuestoMinimo.BindearPropiedadEntidad = "ImpuestoMinimo"
        Me.txtImpuestoMinimo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImpuestoMinimo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImpuestoMinimo.Formato = "N2"
        Me.txtImpuestoMinimo.IsDecimal = True
        Me.txtImpuestoMinimo.IsNumber = True
        Me.txtImpuestoMinimo.IsPK = False
        Me.txtImpuestoMinimo.IsRequired = True
        Me.txtImpuestoMinimo.Key = ""
        Me.txtImpuestoMinimo.LabelAsoc = Me.lblImpuestoMinimo
        Me.txtImpuestoMinimo.Location = New System.Drawing.Point(325, 103)
        Me.txtImpuestoMinimo.MaxLength = 50
        Me.txtImpuestoMinimo.Name = "txtImpuestoMinimo"
        Me.txtImpuestoMinimo.Size = New System.Drawing.Size(59, 20)
        Me.txtImpuestoMinimo.TabIndex = 11
        Me.txtImpuestoMinimo.Text = "0.00"
        Me.txtImpuestoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RegimenesPercepcionesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(483, 369)
        Me.Controls.Add(Me.lblImpuestoMinimo)
        Me.Controls.Add(Me.txtImpuestoMinimo)
        Me.Controls.Add(Me.pnlAlicuotas)
        Me.Controls.Add(Me.lblImporteNetoMinimo)
        Me.Controls.Add(Me.lblCodigoAfip)
        Me.Controls.Add(Me.txtImporteNetoMinimo)
        Me.Controls.Add(Me.txtCodigoAfip)
        Me.Controls.Add(Me.cmbTipoImpuesto)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblIdRegimen)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtIdRegimen)
        Me.Controls.Add(Me.lblIdTipoImpuesto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RegimenesPercepcionesDetalle"
        Me.Text = "Régimen de Percepción"
        Me.Controls.SetChildIndex(Me.lblIdTipoImpuesto, 0)
        Me.Controls.SetChildIndex(Me.txtIdRegimen, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblIdRegimen, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoImpuesto, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoAfip, 0)
        Me.Controls.SetChildIndex(Me.txtImporteNetoMinimo, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoAfip, 0)
        Me.Controls.SetChildIndex(Me.lblImporteNetoMinimo, 0)
        Me.Controls.SetChildIndex(Me.pnlAlicuotas, 0)
        Me.Controls.SetChildIndex(Me.txtImpuestoMinimo, 0)
        Me.Controls.SetChildIndex(Me.lblImpuestoMinimo, 0)
        CType(Me.ugAlicuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAlicuotas.ResumeLayout(False)
        Me.pnlAlicuotas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIdTipoImpuesto As Eniac.Controles.Label
   Friend WithEvents lblIdRegimen As Eniac.Controles.Label
   Friend WithEvents txtIdRegimen As Eniac.Controles.TextBox
    Friend WithEvents cmbTipoImpuesto As Eniac.Controles.ComboBox
    Friend WithEvents lblCodigoAfip As Controles.Label
    Friend WithEvents txtCodigoAfip As Controles.TextBox
    Friend WithEvents txtNombre As Controles.TextBox
    Friend WithEvents lblNombre As Controles.Label
    Friend WithEvents txtImporteNetoMinimo As Controles.TextBox
    Friend WithEvents lblImporteNetoMinimo As Controles.Label
    Friend WithEvents ugAlicuotas As UltraGrid
    Friend WithEvents pnlAlicuotas As TableLayoutPanel
    Friend WithEvents btnEliminar As Controles.Button
    Friend WithEvents btnInsertar As Controles.Button
    Friend WithEvents cmbAlicutotaPercepcion As Controles.ComboBox
    Friend WithEvents lblAlicutotaPercepcion As Controles.Label
    Friend WithEvents lblImpuestoMinimo As Controles.Label
    Friend WithEvents txtImpuestoMinimo As Controles.TextBox
End Class
