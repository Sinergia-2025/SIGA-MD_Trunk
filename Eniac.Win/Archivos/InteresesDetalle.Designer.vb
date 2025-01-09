<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InteresesDetalle
   Inherits Win.BaseDetalle

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasDesde")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasHasta")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Interes")
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
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InteresesDetalle))
        Me.lblDiasDesde = New Eniac.Controles.Label()
        Me.lblDiasHasta = New Eniac.Controles.Label()
        Me.lblInteres = New Eniac.Controles.Label()
        Me.txtDiasDesde = New Eniac.Controles.TextBox()
        Me.txtDiasHasta = New Eniac.Controles.TextBox()
        Me.txtInteres = New Eniac.Controles.TextBox()
        Me.lblIdInteres = New Eniac.Controles.Label()
        Me.txtIdInteres = New Eniac.Controles.TextBox()
        Me.lblNombreInteres = New Eniac.Controles.Label()
        Me.txtNombreInteres = New Eniac.Controles.TextBox()
        Me.lbl = New Eniac.Controles.Label()
        Me.txtInteresAdicional = New Eniac.Controles.TextBox()
        Me.ugDias = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.lblInteresesMetodoParaDeterminarRango = New Eniac.Controles.Label()
        Me.gpbVigencia = New System.Windows.Forms.GroupBox()
        Me.dtpFechaVigenciaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblVigenciaHasta = New Eniac.Controles.Label()
        Me.dtpFechaVigenciaDesde = New Eniac.Controles.DateTimePicker()
        Me.dtpVigenciaDesde = New Eniac.Controles.Label()
        Me.chbUtilizaVigencia = New Eniac.Controles.CheckBox()
        Me.cmbInteresesMetodoParaDeterminarRango = New Eniac.Controles.ComboBox()
        Me.lblExcluyeVencimiento = New Eniac.Controles.Label()
        Me.chbVencimientoExcluyeSabado = New Eniac.Controles.CheckBox()
        Me.chbVencimientoExcluyeDomingo = New Eniac.Controles.CheckBox()
        Me.chbVencimientoExcluyeFeriados = New Eniac.Controles.CheckBox()
        CType(Me.ugDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gpbVigencia.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(246, 437)
        Me.btnAceptar.Size = New System.Drawing.Size(90, 30)
        Me.btnAceptar.TabIndex = 14
        Me.btnAceptar.Text = "&Aceptar (F4)"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(342, 437)
        Me.btnCancelar.Size = New System.Drawing.Size(90, 30)
        Me.btnCancelar.TabIndex = 15
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(145, 437)
        Me.btnCopiar.TabIndex = 17
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(85, 437)
        Me.btnAplicar.TabIndex = 16
        '
        'lblDiasDesde
        '
        Me.lblDiasDesde.AutoSize = True
        Me.lblDiasDesde.LabelAsoc = Nothing
        Me.lblDiasDesde.Location = New System.Drawing.Point(7, 23)
        Me.lblDiasDesde.Name = "lblDiasDesde"
        Me.lblDiasDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDiasDesde.TabIndex = 0
        Me.lblDiasDesde.Text = "Desde"
        '
        'lblDiasHasta
        '
        Me.lblDiasHasta.AutoSize = True
        Me.lblDiasHasta.LabelAsoc = Nothing
        Me.lblDiasHasta.Location = New System.Drawing.Point(117, 23)
        Me.lblDiasHasta.Name = "lblDiasHasta"
        Me.lblDiasHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblDiasHasta.TabIndex = 2
        Me.lblDiasHasta.Text = "Hasta"
        '
        'lblInteres
        '
        Me.lblInteres.AutoSize = True
        Me.lblInteres.LabelAsoc = Nothing
        Me.lblInteres.Location = New System.Drawing.Point(225, 23)
        Me.lblInteres.Name = "lblInteres"
        Me.lblInteres.Size = New System.Drawing.Size(39, 13)
        Me.lblInteres.TabIndex = 4
        Me.lblInteres.Text = "Interés"
        '
        'txtDiasDesde
        '
        Me.txtDiasDesde.BindearPropiedadControl = ""
        Me.txtDiasDesde.BindearPropiedadEntidad = ""
        Me.txtDiasDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasDesde.Formato = ""
        Me.txtDiasDesde.IsDecimal = False
        Me.txtDiasDesde.IsNumber = True
        Me.txtDiasDesde.IsPK = False
        Me.txtDiasDesde.IsRequired = False
        Me.txtDiasDesde.Key = ""
        Me.txtDiasDesde.LabelAsoc = Me.lblDiasDesde
        Me.txtDiasDesde.Location = New System.Drawing.Point(44, 19)
        Me.txtDiasDesde.Name = "txtDiasDesde"
        Me.txtDiasDesde.Size = New System.Drawing.Size(61, 20)
        Me.txtDiasDesde.TabIndex = 1
        Me.txtDiasDesde.Text = "0"
        Me.txtDiasDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiasHasta
        '
        Me.txtDiasHasta.BindearPropiedadControl = ""
        Me.txtDiasHasta.BindearPropiedadEntidad = ""
        Me.txtDiasHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasHasta.Formato = ""
        Me.txtDiasHasta.IsDecimal = False
        Me.txtDiasHasta.IsNumber = True
        Me.txtDiasHasta.IsPK = False
        Me.txtDiasHasta.IsRequired = False
        Me.txtDiasHasta.Key = ""
        Me.txtDiasHasta.LabelAsoc = Me.lblDiasHasta
        Me.txtDiasHasta.Location = New System.Drawing.Point(152, 19)
        Me.txtDiasHasta.Name = "txtDiasHasta"
        Me.txtDiasHasta.Size = New System.Drawing.Size(61, 20)
        Me.txtDiasHasta.TabIndex = 3
        Me.txtDiasHasta.Text = "0"
        Me.txtDiasHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInteres
        '
        Me.txtInteres.BindearPropiedadControl = ""
        Me.txtInteres.BindearPropiedadEntidad = ""
        Me.txtInteres.ForeColorFocus = System.Drawing.Color.Red
        Me.txtInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtInteres.Formato = "##0.00"
        Me.txtInteres.IsDecimal = True
        Me.txtInteres.IsNumber = True
        Me.txtInteres.IsPK = False
        Me.txtInteres.IsRequired = False
        Me.txtInteres.Key = ""
        Me.txtInteres.LabelAsoc = Me.lblInteres
        Me.txtInteres.Location = New System.Drawing.Point(263, 19)
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.Size = New System.Drawing.Size(61, 20)
        Me.txtInteres.TabIndex = 5
        Me.txtInteres.Text = "0.00"
        Me.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdInteres
        '
        Me.lblIdInteres.AutoSize = True
        Me.lblIdInteres.LabelAsoc = Nothing
        Me.lblIdInteres.Location = New System.Drawing.Point(21, 12)
        Me.lblIdInteres.Name = "lblIdInteres"
        Me.lblIdInteres.Size = New System.Drawing.Size(40, 13)
        Me.lblIdInteres.TabIndex = 0
        Me.lblIdInteres.Text = "Código"
        '
        'txtIdInteres
        '
        Me.txtIdInteres.BindearPropiedadControl = "Text"
        Me.txtIdInteres.BindearPropiedadEntidad = "IdInteres"
        Me.txtIdInteres.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdInteres.Formato = ""
        Me.txtIdInteres.IsDecimal = False
        Me.txtIdInteres.IsNumber = True
        Me.txtIdInteres.IsPK = True
        Me.txtIdInteres.IsRequired = True
        Me.txtIdInteres.Key = ""
        Me.txtIdInteres.LabelAsoc = Me.lblIdInteres
        Me.txtIdInteres.Location = New System.Drawing.Point(91, 8)
        Me.txtIdInteres.Name = "txtIdInteres"
        Me.txtIdInteres.Size = New System.Drawing.Size(61, 20)
        Me.txtIdInteres.TabIndex = 1
        Me.txtIdInteres.Text = "0"
        Me.txtIdInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreInteres
        '
        Me.lblNombreInteres.AutoSize = True
        Me.lblNombreInteres.LabelAsoc = Nothing
        Me.lblNombreInteres.Location = New System.Drawing.Point(21, 38)
        Me.lblNombreInteres.Name = "lblNombreInteres"
        Me.lblNombreInteres.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreInteres.TabIndex = 2
        Me.lblNombreInteres.Text = "Nombre"
        '
        'txtNombreInteres
        '
        Me.txtNombreInteres.BindearPropiedadControl = "Text"
        Me.txtNombreInteres.BindearPropiedadEntidad = "NombreInteres"
        Me.txtNombreInteres.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreInteres.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreInteres.Formato = ""
        Me.txtNombreInteres.IsDecimal = False
        Me.txtNombreInteres.IsNumber = False
        Me.txtNombreInteres.IsPK = False
        Me.txtNombreInteres.IsRequired = True
        Me.txtNombreInteres.Key = ""
        Me.txtNombreInteres.LabelAsoc = Me.lblNombreInteres
        Me.txtNombreInteres.Location = New System.Drawing.Point(91, 34)
        Me.txtNombreInteres.MaxLength = 30
        Me.txtNombreInteres.Name = "txtNombreInteres"
        Me.txtNombreInteres.Size = New System.Drawing.Size(250, 20)
        Me.txtNombreInteres.TabIndex = 3
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.LabelAsoc = Nothing
        Me.lbl.Location = New System.Drawing.Point(21, 64)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(301, 13)
        Me.lbl.TabIndex = 4
        Me.lbl.Text = "Interés adicional proporcional diario acumulado a último interés"
        '
        'txtInteresAdicional
        '
        Me.txtInteresAdicional.BindearPropiedadControl = "Text"
        Me.txtInteresAdicional.BindearPropiedadEntidad = "AdicionalProporcinalDias"
        Me.txtInteresAdicional.ForeColorFocus = System.Drawing.Color.Red
        Me.txtInteresAdicional.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtInteresAdicional.Formato = "##0.00"
        Me.txtInteresAdicional.IsDecimal = True
        Me.txtInteresAdicional.IsNumber = True
        Me.txtInteresAdicional.IsPK = False
        Me.txtInteresAdicional.IsRequired = False
        Me.txtInteresAdicional.Key = ""
        Me.txtInteresAdicional.LabelAsoc = Me.lbl
        Me.txtInteresAdicional.Location = New System.Drawing.Point(342, 61)
        Me.txtInteresAdicional.Name = "txtInteresAdicional"
        Me.txtInteresAdicional.Size = New System.Drawing.Size(76, 20)
        Me.txtInteresAdicional.TabIndex = 5
        Me.txtInteresAdicional.Text = "0.00"
        Me.txtInteresAdicional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ugDias
        '
        Me.ugDias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDias.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Format = "N0"
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn4.Header.Appearance = Appearance3
        UltraGridColumn4.Header.Caption = "Desde"
        UltraGridColumn4.Header.VisiblePosition = 0
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn5.CellAppearance = Appearance4
        UltraGridColumn5.Format = "N0"
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn5.Header.Appearance = Appearance5
        UltraGridColumn5.Header.Caption = "Hasta"
        UltraGridColumn5.Header.VisiblePosition = 1
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance6
        UltraGridColumn6.Format = "N2"
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn6.Header.Appearance = Appearance7
        UltraGridColumn6.Header.Caption = "Interés"
        UltraGridColumn6.Header.VisiblePosition = 2
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        Me.ugDias.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDias.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDias.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance8.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance8.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance8.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDias.DisplayLayout.GroupByBox.Appearance = Appearance8
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDias.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance9
        Me.ugDias.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance10.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance10.BackColor2 = System.Drawing.SystemColors.Control
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDias.DisplayLayout.GroupByBox.PromptAppearance = Appearance10
        Me.ugDias.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDias.DisplayLayout.MaxRowScrollRegions = 1
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDias.DisplayLayout.Override.ActiveCellAppearance = Appearance11
        Appearance12.BackColor = System.Drawing.SystemColors.Highlight
        Appearance12.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDias.DisplayLayout.Override.ActiveRowAppearance = Appearance12
        Me.ugDias.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDias.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDias.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDias.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDias.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Me.ugDias.DisplayLayout.Override.CardAreaAppearance = Appearance13
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Appearance14.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDias.DisplayLayout.Override.CellAppearance = Appearance14
        Me.ugDias.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDias.DisplayLayout.Override.CellPadding = 0
        Appearance15.BackColor = System.Drawing.SystemColors.Control
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDias.DisplayLayout.Override.GroupByRowAppearance = Appearance15
        Appearance16.TextHAlignAsString = "Left"
        Me.ugDias.DisplayLayout.Override.HeaderAppearance = Appearance16
        Me.ugDias.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDias.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.BorderColor = System.Drawing.Color.Silver
        Me.ugDias.DisplayLayout.Override.RowAppearance = Appearance17
        Me.ugDias.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance18.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDias.DisplayLayout.Override.TemplateAddRowAppearance = Appearance18
        Me.ugDias.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDias.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDias.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDias.Location = New System.Drawing.Point(5, 52)
        Me.ugDias.Name = "ugDias"
        Me.ugDias.Size = New System.Drawing.Size(401, 182)
        Me.ugDias.TabIndex = 8
        Me.ugDias.Text = "UltraGrid1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnEliminar)
        Me.GroupBox1.Controls.Add(Me.btnInsertar)
        Me.GroupBox1.Controls.Add(Me.txtDiasDesde)
        Me.GroupBox1.Controls.Add(Me.ugDias)
        Me.GroupBox1.Controls.Add(Me.lblDiasDesde)
        Me.GroupBox1.Controls.Add(Me.lblDiasHasta)
        Me.GroupBox1.Controls.Add(Me.txtInteres)
        Me.GroupBox1.Controls.Add(Me.lblInteres)
        Me.GroupBox1.Controls.Add(Me.txtDiasHasta)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 195)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 239)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Días"
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminar.Location = New System.Drawing.Point(369, 11)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertar.Location = New System.Drawing.Point(332, 11)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 6
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'lblInteresesMetodoParaDeterminarRango
        '
        Me.lblInteresesMetodoParaDeterminarRango.AutoSize = True
        Me.lblInteresesMetodoParaDeterminarRango.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInteresesMetodoParaDeterminarRango.LabelAsoc = Nothing
        Me.lblInteresesMetodoParaDeterminarRango.Location = New System.Drawing.Point(21, 91)
        Me.lblInteresesMetodoParaDeterminarRango.Name = "lblInteresesMetodoParaDeterminarRango"
        Me.lblInteresesMetodoParaDeterminarRango.Size = New System.Drawing.Size(171, 13)
        Me.lblInteresesMetodoParaDeterminarRango.TabIndex = 6
        Me.lblInteresesMetodoParaDeterminarRango.Text = "Intereses toma desde/hasta como:"
        '
        'gpbVigencia
        '
        Me.gpbVigencia.Controls.Add(Me.dtpFechaVigenciaHasta)
        Me.gpbVigencia.Controls.Add(Me.dtpFechaVigenciaDesde)
        Me.gpbVigencia.Controls.Add(Me.chbUtilizaVigencia)
        Me.gpbVigencia.Controls.Add(Me.lblVigenciaHasta)
        Me.gpbVigencia.Controls.Add(Me.dtpVigenciaDesde)
        Me.gpbVigencia.Location = New System.Drawing.Point(12, 137)
        Me.gpbVigencia.Name = "gpbVigencia"
        Me.gpbVigencia.Size = New System.Drawing.Size(420, 58)
        Me.gpbVigencia.TabIndex = 12
        Me.gpbVigencia.TabStop = False
        Me.gpbVigencia.Text = "Vigencia"
        '
        'dtpFechaVigenciaHasta
        '
        Me.dtpFechaVigenciaHasta.BindearPropiedadControl = "Value"
        Me.dtpFechaVigenciaHasta.BindearPropiedadEntidad = "FechaVigenciaHasta"
        Me.dtpFechaVigenciaHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaVigenciaHasta.Enabled = False
        Me.dtpFechaVigenciaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaVigenciaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaVigenciaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaVigenciaHasta.IsPK = False
        Me.dtpFechaVigenciaHasta.IsRequired = False
        Me.dtpFechaVigenciaHasta.Key = ""
        Me.dtpFechaVigenciaHasta.LabelAsoc = Me.lblVigenciaHasta
        Me.dtpFechaVigenciaHasta.Location = New System.Drawing.Point(239, 32)
        Me.dtpFechaVigenciaHasta.Name = "dtpFechaVigenciaHasta"
        Me.dtpFechaVigenciaHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaVigenciaHasta.TabIndex = 4
        '
        'lblVigenciaHasta
        '
        Me.lblVigenciaHasta.AutoSize = True
        Me.lblVigenciaHasta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVigenciaHasta.LabelAsoc = Nothing
        Me.lblVigenciaHasta.Location = New System.Drawing.Point(236, 18)
        Me.lblVigenciaHasta.Name = "lblVigenciaHasta"
        Me.lblVigenciaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblVigenciaHasta.TabIndex = 3
        Me.lblVigenciaHasta.Text = "Hasta"
        '
        'dtpFechaVigenciaDesde
        '
        Me.dtpFechaVigenciaDesde.BindearPropiedadControl = "Value"
        Me.dtpFechaVigenciaDesde.BindearPropiedadEntidad = "FechaVigenciaDesde"
        Me.dtpFechaVigenciaDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaVigenciaDesde.Enabled = False
        Me.dtpFechaVigenciaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaVigenciaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaVigenciaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaVigenciaDesde.IsPK = False
        Me.dtpFechaVigenciaDesde.IsRequired = False
        Me.dtpFechaVigenciaDesde.Key = ""
        Me.dtpFechaVigenciaDesde.LabelAsoc = Me.dtpVigenciaDesde
        Me.dtpFechaVigenciaDesde.Location = New System.Drawing.Point(121, 32)
        Me.dtpFechaVigenciaDesde.Name = "dtpFechaVigenciaDesde"
        Me.dtpFechaVigenciaDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaVigenciaDesde.TabIndex = 2
        '
        'dtpVigenciaDesde
        '
        Me.dtpVigenciaDesde.AutoSize = True
        Me.dtpVigenciaDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dtpVigenciaDesde.LabelAsoc = Nothing
        Me.dtpVigenciaDesde.Location = New System.Drawing.Point(118, 18)
        Me.dtpVigenciaDesde.Name = "dtpVigenciaDesde"
        Me.dtpVigenciaDesde.Size = New System.Drawing.Size(38, 13)
        Me.dtpVigenciaDesde.TabIndex = 1
        Me.dtpVigenciaDesde.Text = "Desde"
        '
        'chbUtilizaVigencia
        '
        Me.chbUtilizaVigencia.AutoSize = True
        Me.chbUtilizaVigencia.BindearPropiedadControl = "Checked"
        Me.chbUtilizaVigencia.BindearPropiedadEntidad = "UtilizaVigencia"
        Me.chbUtilizaVigencia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUtilizaVigencia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUtilizaVigencia.IsPK = False
        Me.chbUtilizaVigencia.IsRequired = False
        Me.chbUtilizaVigencia.Key = Nothing
        Me.chbUtilizaVigencia.LabelAsoc = Nothing
        Me.chbUtilizaVigencia.Location = New System.Drawing.Point(10, 32)
        Me.chbUtilizaVigencia.Name = "chbUtilizaVigencia"
        Me.chbUtilizaVigencia.Size = New System.Drawing.Size(98, 17)
        Me.chbUtilizaVigencia.TabIndex = 0
        Me.chbUtilizaVigencia.Text = "Utiliza Vigencia"
        Me.chbUtilizaVigencia.UseVisualStyleBackColor = True
        '
        'cmbInteresesMetodoParaDeterminarRango
        '
        Me.cmbInteresesMetodoParaDeterminarRango.BindearPropiedadControl = "SelectedValue"
        Me.cmbInteresesMetodoParaDeterminarRango.BindearPropiedadEntidad = "MetodoParaDeterminarRango"
        Me.cmbInteresesMetodoParaDeterminarRango.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInteresesMetodoParaDeterminarRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInteresesMetodoParaDeterminarRango.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbInteresesMetodoParaDeterminarRango.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbInteresesMetodoParaDeterminarRango.FormattingEnabled = True
        Me.cmbInteresesMetodoParaDeterminarRango.IsPK = False
        Me.cmbInteresesMetodoParaDeterminarRango.IsRequired = True
        Me.cmbInteresesMetodoParaDeterminarRango.Key = Nothing
        Me.cmbInteresesMetodoParaDeterminarRango.LabelAsoc = Me.lblInteresesMetodoParaDeterminarRango
        Me.cmbInteresesMetodoParaDeterminarRango.Location = New System.Drawing.Point(199, 87)
        Me.cmbInteresesMetodoParaDeterminarRango.Name = "cmbInteresesMetodoParaDeterminarRango"
        Me.cmbInteresesMetodoParaDeterminarRango.Size = New System.Drawing.Size(219, 21)
        Me.cmbInteresesMetodoParaDeterminarRango.TabIndex = 7
        '
        'lblExcluyeVencimiento
        '
        Me.lblExcluyeVencimiento.AutoSize = True
        Me.lblExcluyeVencimiento.LabelAsoc = Nothing
        Me.lblExcluyeVencimiento.Location = New System.Drawing.Point(21, 116)
        Me.lblExcluyeVencimiento.Name = "lblExcluyeVencimiento"
        Me.lblExcluyeVencimiento.Size = New System.Drawing.Size(105, 13)
        Me.lblExcluyeVencimiento.TabIndex = 8
        Me.lblExcluyeVencimiento.Text = "Excluye Vencimiento"
        '
        'chbVencimientoExcluyeSabado
        '
        Me.chbVencimientoExcluyeSabado.AutoSize = True
        Me.chbVencimientoExcluyeSabado.BindearPropiedadControl = "Checked"
        Me.chbVencimientoExcluyeSabado.BindearPropiedadEntidad = "VencimientoExcluyeSabado"
        Me.chbVencimientoExcluyeSabado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVencimientoExcluyeSabado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVencimientoExcluyeSabado.IsPK = False
        Me.chbVencimientoExcluyeSabado.IsRequired = False
        Me.chbVencimientoExcluyeSabado.Key = Nothing
        Me.chbVencimientoExcluyeSabado.LabelAsoc = Nothing
        Me.chbVencimientoExcluyeSabado.Location = New System.Drawing.Point(129, 114)
        Me.chbVencimientoExcluyeSabado.Name = "chbVencimientoExcluyeSabado"
        Me.chbVencimientoExcluyeSabado.Size = New System.Drawing.Size(63, 17)
        Me.chbVencimientoExcluyeSabado.TabIndex = 9
        Me.chbVencimientoExcluyeSabado.Text = "Sábado"
        Me.chbVencimientoExcluyeSabado.UseVisualStyleBackColor = True
        '
        'chbVencimientoExcluyeDomingo
        '
        Me.chbVencimientoExcluyeDomingo.AutoSize = True
        Me.chbVencimientoExcluyeDomingo.BindearPropiedadControl = "Checked"
        Me.chbVencimientoExcluyeDomingo.BindearPropiedadEntidad = "VencimientoExcluyeDomingo"
        Me.chbVencimientoExcluyeDomingo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVencimientoExcluyeDomingo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVencimientoExcluyeDomingo.IsPK = False
        Me.chbVencimientoExcluyeDomingo.IsRequired = False
        Me.chbVencimientoExcluyeDomingo.Key = Nothing
        Me.chbVencimientoExcluyeDomingo.LabelAsoc = Nothing
        Me.chbVencimientoExcluyeDomingo.Location = New System.Drawing.Point(198, 114)
        Me.chbVencimientoExcluyeDomingo.Name = "chbVencimientoExcluyeDomingo"
        Me.chbVencimientoExcluyeDomingo.Size = New System.Drawing.Size(68, 17)
        Me.chbVencimientoExcluyeDomingo.TabIndex = 10
        Me.chbVencimientoExcluyeDomingo.Text = "Domingo"
        Me.chbVencimientoExcluyeDomingo.UseVisualStyleBackColor = True
        '
        'chbVencimientoExcluyeFeriados
        '
        Me.chbVencimientoExcluyeFeriados.AutoSize = True
        Me.chbVencimientoExcluyeFeriados.BindearPropiedadControl = "Checked"
        Me.chbVencimientoExcluyeFeriados.BindearPropiedadEntidad = "VencimientoExcluyeFeriados"
        Me.chbVencimientoExcluyeFeriados.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVencimientoExcluyeFeriados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVencimientoExcluyeFeriados.IsPK = False
        Me.chbVencimientoExcluyeFeriados.IsRequired = False
        Me.chbVencimientoExcluyeFeriados.Key = Nothing
        Me.chbVencimientoExcluyeFeriados.LabelAsoc = Nothing
        Me.chbVencimientoExcluyeFeriados.Location = New System.Drawing.Point(272, 114)
        Me.chbVencimientoExcluyeFeriados.Name = "chbVencimientoExcluyeFeriados"
        Me.chbVencimientoExcluyeFeriados.Size = New System.Drawing.Size(61, 17)
        Me.chbVencimientoExcluyeFeriados.TabIndex = 11
        Me.chbVencimientoExcluyeFeriados.Text = "Feriado"
        Me.chbVencimientoExcluyeFeriados.UseVisualStyleBackColor = True
        '
        'InteresesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(441, 472)
        Me.Controls.Add(Me.gpbVigencia)
        Me.Controls.Add(Me.chbVencimientoExcluyeFeriados)
        Me.Controls.Add(Me.chbVencimientoExcluyeDomingo)
        Me.Controls.Add(Me.chbVencimientoExcluyeSabado)
        Me.Controls.Add(Me.lblInteresesMetodoParaDeterminarRango)
        Me.Controls.Add(Me.cmbInteresesMetodoParaDeterminarRango)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtInteresAdicional)
        Me.Controls.Add(Me.txtNombreInteres)
        Me.Controls.Add(Me.txtIdInteres)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.lblNombreInteres)
        Me.Controls.Add(Me.lblExcluyeVencimiento)
        Me.Controls.Add(Me.lblIdInteres)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InteresesDetalle"
        Me.Text = "Intereses"
        Me.Controls.SetChildIndex(Me.lblIdInteres, 0)
        Me.Controls.SetChildIndex(Me.lblExcluyeVencimiento, 0)
        Me.Controls.SetChildIndex(Me.lblNombreInteres, 0)
        Me.Controls.SetChildIndex(Me.lbl, 0)
        Me.Controls.SetChildIndex(Me.txtIdInteres, 0)
        Me.Controls.SetChildIndex(Me.txtNombreInteres, 0)
        Me.Controls.SetChildIndex(Me.txtInteresAdicional, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cmbInteresesMetodoParaDeterminarRango, 0)
        Me.Controls.SetChildIndex(Me.lblInteresesMetodoParaDeterminarRango, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.chbVencimientoExcluyeSabado, 0)
        Me.Controls.SetChildIndex(Me.chbVencimientoExcluyeDomingo, 0)
        Me.Controls.SetChildIndex(Me.chbVencimientoExcluyeFeriados, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.gpbVigencia, 0)
        CType(Me.ugDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpbVigencia.ResumeLayout(False)
        Me.gpbVigencia.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDiasDesde As Eniac.Controles.Label
   Friend WithEvents lblDiasHasta As Eniac.Controles.Label
   Friend WithEvents lblInteres As Eniac.Controles.Label
   Friend WithEvents txtDiasDesde As Eniac.Controles.TextBox
   Friend WithEvents txtDiasHasta As Eniac.Controles.TextBox
   Friend WithEvents txtInteres As Eniac.Controles.TextBox
   Friend WithEvents lblIdInteres As Eniac.Controles.Label
   Friend WithEvents txtIdInteres As Eniac.Controles.TextBox
   Friend WithEvents lblNombreInteres As Eniac.Controles.Label
   Friend WithEvents txtNombreInteres As Eniac.Controles.TextBox
   Friend WithEvents lbl As Eniac.Controles.Label
   Friend WithEvents txtInteresAdicional As Eniac.Controles.TextBox
   Friend WithEvents ugDias As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents lblInteresesMetodoParaDeterminarRango As Eniac.Controles.Label
   Friend WithEvents cmbInteresesMetodoParaDeterminarRango As Eniac.Controles.ComboBox
    Friend WithEvents gpbVigencia As GroupBox
    Friend WithEvents lblVigenciaHasta As Controles.Label
    Friend WithEvents dtpVigenciaDesde As Controles.Label
    Friend WithEvents chbUtilizaVigencia As Controles.CheckBox
    Friend WithEvents dtpFechaVigenciaHasta As Controles.DateTimePicker
    Friend WithEvents dtpFechaVigenciaDesde As Controles.DateTimePicker
    Friend WithEvents lblExcluyeVencimiento As Controles.Label
    Friend WithEvents chbVencimientoExcluyeSabado As Controles.CheckBox
    Friend WithEvents chbVencimientoExcluyeDomingo As Controles.CheckBox
    Friend WithEvents chbVencimientoExcluyeFeriados As Controles.CheckBox
End Class
