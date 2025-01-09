<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuentasCorrientesAntiguedadesSaldosConfigDetalle
   Inherits BaseDetalle

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
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAntiguedadSaldoConfig")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasDesde")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DiasHasta")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EtiquetaColumna")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
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
      Me.cmbTipoAntiguedadSaldoConfig = New Eniac.Controles.ComboBox()
      Me.lblTipoConceptoCM05 = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.chbPorDefecto = New Eniac.Controles.CheckBox()
      Me.ugRangos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.txtDiasDesde = New Eniac.Controles.TextBox()
      Me.lblDiasDesde = New Eniac.Controles.Label()
      Me.lblDiasHasta = New Eniac.Controles.Label()
      Me.txtOrden = New Eniac.Controles.TextBox()
      Me.lblOrden = New Eniac.Controles.Label()
      Me.txtDiasHasta = New Eniac.Controles.TextBox()
      Me.txtEtiqueta = New Eniac.Controles.TextBox()
      Me.lblEtiqueta = New Eniac.Controles.Label()
      Me.grpRangos = New System.Windows.Forms.GroupBox()
      Me.btnBajarRango = New Eniac.Controles.Button()
      Me.btnSubirRango = New Eniac.Controles.Button()
      CType(Me.ugRangos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpRangos.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(291, 472)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(377, 472)
      Me.btnCancelar.TabIndex = 9
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(190, 472)
      Me.btnCopiar.TabIndex = 11
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(133, 472)
      Me.btnAplicar.TabIndex = 10
      '
      'cmbTipoAntiguedadSaldoConfig
      '
      Me.cmbTipoAntiguedadSaldoConfig.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoAntiguedadSaldoConfig.BindearPropiedadEntidad = "TipoAntiguedadSaldoConfig"
      Me.cmbTipoAntiguedadSaldoConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoAntiguedadSaldoConfig.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoAntiguedadSaldoConfig.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoAntiguedadSaldoConfig.FormattingEnabled = True
      Me.cmbTipoAntiguedadSaldoConfig.IsPK = False
      Me.cmbTipoAntiguedadSaldoConfig.IsRequired = True
      Me.cmbTipoAntiguedadSaldoConfig.Key = Nothing
      Me.cmbTipoAntiguedadSaldoConfig.LabelAsoc = Me.lblTipoConceptoCM05
      Me.cmbTipoAntiguedadSaldoConfig.Location = New System.Drawing.Point(100, 64)
      Me.cmbTipoAntiguedadSaldoConfig.Name = "cmbTipoAntiguedadSaldoConfig"
      Me.cmbTipoAntiguedadSaldoConfig.Size = New System.Drawing.Size(142, 21)
      Me.cmbTipoAntiguedadSaldoConfig.TabIndex = 5
      '
      'lblTipoConceptoCM05
      '
      Me.lblTipoConceptoCM05.AutoSize = True
      Me.lblTipoConceptoCM05.LabelAsoc = Nothing
      Me.lblTipoConceptoCM05.Location = New System.Drawing.Point(30, 68)
      Me.lblTipoConceptoCM05.Name = "lblTipoConceptoCM05"
      Me.lblTipoConceptoCM05.Size = New System.Drawing.Size(28, 13)
      Me.lblTipoConceptoCM05.TabIndex = 4
      Me.lblTipoConceptoCM05.Text = "Tipo"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreAntiguedadSaldoConfig"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(100, 38)
      Me.txtNombre.MaxLength = 30
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(250, 20)
      Me.txtNombre.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(30, 42)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtCodigo
      '
      Me.txtCodigo.BindearPropiedadControl = "Text"
      Me.txtCodigo.BindearPropiedadEntidad = "IdAntiguedadSaldoConfig"
      Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigo.Formato = ""
      Me.txtCodigo.IsDecimal = False
      Me.txtCodigo.IsNumber = True
      Me.txtCodigo.IsPK = True
      Me.txtCodigo.IsRequired = True
      Me.txtCodigo.Key = ""
      Me.txtCodigo.LabelAsoc = Me.lblCodigo
      Me.txtCodigo.Location = New System.Drawing.Point(100, 12)
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(61, 20)
      Me.txtCodigo.TabIndex = 1
      Me.txtCodigo.Text = "0"
      Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(30, 16)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Código"
      '
      'chbPorDefecto
      '
      Me.chbPorDefecto.AutoSize = True
      Me.chbPorDefecto.BindearPropiedadControl = "Checked"
      Me.chbPorDefecto.BindearPropiedadEntidad = "PorDefecto"
      Me.chbPorDefecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPorDefecto.IsPK = False
      Me.chbPorDefecto.IsRequired = False
      Me.chbPorDefecto.Key = Nothing
      Me.chbPorDefecto.LabelAsoc = Nothing
      Me.chbPorDefecto.Location = New System.Drawing.Point(100, 91)
      Me.chbPorDefecto.Name = "chbPorDefecto"
      Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
      Me.chbPorDefecto.TabIndex = 6
      Me.chbPorDefecto.Text = "Por Defecto"
      Me.chbPorDefecto.UseVisualStyleBackColor = True
      '
      'ugRangos
      '
      Me.ugRangos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugRangos.DisplayLayout.Appearance = Appearance1
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance2
      UltraGridColumn1.Format = "N0"
      UltraGridColumn1.Header.Caption = "Código"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn1.Width = 100
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance3
      UltraGridColumn2.Format = "N0"
      UltraGridColumn2.Header.Caption = "Desde"
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Width = 70
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn3.CellAppearance = Appearance4
      UltraGridColumn3.Format = "N0"
      UltraGridColumn3.Header.Caption = "Hasta"
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Width = 70
      UltraGridColumn4.Header.Caption = "Etiqueta"
      UltraGridColumn4.Header.VisiblePosition = 1
      UltraGridColumn4.Width = 150
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance5
      UltraGridColumn5.Format = "N0"
      UltraGridColumn5.Header.VisiblePosition = 4
      UltraGridColumn5.Width = 70
      UltraGridColumn6.Header.VisiblePosition = 5
      UltraGridColumn6.Hidden = True
      UltraGridColumn7.Header.VisiblePosition = 6
      UltraGridColumn7.Hidden = True
      UltraGridColumn8.Header.VisiblePosition = 7
      UltraGridColumn8.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8})
      Me.ugRangos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugRangos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugRangos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance6.BorderColor = System.Drawing.SystemColors.Window
      Me.ugRangos.DisplayLayout.GroupByBox.Appearance = Appearance6
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugRangos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
      Me.ugRangos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance8.BackColor2 = System.Drawing.SystemColors.Control
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugRangos.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
      Me.ugRangos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugRangos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugRangos.DisplayLayout.Override.ActiveCellAppearance = Appearance9
      Appearance10.BackColor = System.Drawing.SystemColors.Highlight
      Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugRangos.DisplayLayout.Override.ActiveRowAppearance = Appearance10
      Me.ugRangos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugRangos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Me.ugRangos.DisplayLayout.Override.CardAreaAppearance = Appearance11
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugRangos.DisplayLayout.Override.CellAppearance = Appearance12
      Me.ugRangos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugRangos.DisplayLayout.Override.CellPadding = 0
      Appearance13.BackColor = System.Drawing.SystemColors.Control
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugRangos.DisplayLayout.Override.GroupByRowAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Left"
      Me.ugRangos.DisplayLayout.Override.HeaderAppearance = Appearance14
      Me.ugRangos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugRangos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Me.ugRangos.DisplayLayout.Override.RowAppearance = Appearance15
      Me.ugRangos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugRangos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
      Me.ugRangos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugRangos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugRangos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugRangos.Location = New System.Drawing.Point(9, 65)
      Me.ugRangos.Name = "ugRangos"
      Me.ugRangos.Size = New System.Drawing.Size(386, 281)
      Me.ugRangos.TabIndex = 10
      Me.ugRangos.Text = "UltraGrid1"
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.btnEliminar.Location = New System.Drawing.Point(371, 24)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 9
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnInsertar.Location = New System.Drawing.Point(334, 24)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 8
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'txtDiasDesde
      '
      Me.txtDiasDesde.BindearPropiedadControl = ""
      Me.txtDiasDesde.BindearPropiedadEntidad = ""
      Me.txtDiasDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDiasDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDiasDesde.Formato = "N0"
      Me.txtDiasDesde.IsDecimal = True
      Me.txtDiasDesde.IsNumber = True
      Me.txtDiasDesde.IsPK = False
      Me.txtDiasDesde.IsRequired = False
      Me.txtDiasDesde.Key = ""
      Me.txtDiasDesde.LabelAsoc = Me.lblDiasDesde
      Me.txtDiasDesde.Location = New System.Drawing.Point(131, 32)
      Me.txtDiasDesde.Name = "txtDiasDesde"
      Me.txtDiasDesde.Size = New System.Drawing.Size(61, 20)
      Me.txtDiasDesde.TabIndex = 3
      Me.txtDiasDesde.Text = "0"
      Me.txtDiasDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiasDesde
      '
      Me.lblDiasDesde.AutoSize = True
      Me.lblDiasDesde.LabelAsoc = Nothing
      Me.lblDiasDesde.Location = New System.Drawing.Point(137, 16)
      Me.lblDiasDesde.Name = "lblDiasDesde"
      Me.lblDiasDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblDiasDesde.TabIndex = 2
      Me.lblDiasDesde.Text = "Desde"
      '
      'lblDiasHasta
      '
      Me.lblDiasHasta.AutoSize = True
      Me.lblDiasHasta.LabelAsoc = Nothing
      Me.lblDiasHasta.Location = New System.Drawing.Point(195, 16)
      Me.lblDiasHasta.Name = "lblDiasHasta"
      Me.lblDiasHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblDiasHasta.TabIndex = 4
      Me.lblDiasHasta.Text = "Hasta"
      '
      'txtOrden
      '
      Me.txtOrden.BindearPropiedadControl = ""
      Me.txtOrden.BindearPropiedadEntidad = ""
      Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
      Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtOrden.Formato = "N0"
      Me.txtOrden.IsDecimal = True
      Me.txtOrden.IsNumber = True
      Me.txtOrden.IsPK = False
      Me.txtOrden.IsRequired = False
      Me.txtOrden.Key = ""
      Me.txtOrden.LabelAsoc = Me.lblOrden
      Me.txtOrden.Location = New System.Drawing.Point(265, 32)
      Me.txtOrden.Name = "txtOrden"
      Me.txtOrden.Size = New System.Drawing.Size(61, 20)
      Me.txtOrden.TabIndex = 7
      Me.txtOrden.Text = "1"
      Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblOrden
      '
      Me.lblOrden.AutoSize = True
      Me.lblOrden.LabelAsoc = Nothing
      Me.lblOrden.Location = New System.Drawing.Point(262, 16)
      Me.lblOrden.Name = "lblOrden"
      Me.lblOrden.Size = New System.Drawing.Size(36, 13)
      Me.lblOrden.TabIndex = 6
      Me.lblOrden.Text = "Orden"
      '
      'txtDiasHasta
      '
      Me.txtDiasHasta.BindearPropiedadControl = ""
      Me.txtDiasHasta.BindearPropiedadEntidad = ""
      Me.txtDiasHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDiasHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDiasHasta.Formato = "N0"
      Me.txtDiasHasta.IsDecimal = True
      Me.txtDiasHasta.IsNumber = True
      Me.txtDiasHasta.IsPK = False
      Me.txtDiasHasta.IsRequired = False
      Me.txtDiasHasta.Key = ""
      Me.txtDiasHasta.LabelAsoc = Me.lblDiasHasta
      Me.txtDiasHasta.Location = New System.Drawing.Point(198, 32)
      Me.txtDiasHasta.Name = "txtDiasHasta"
      Me.txtDiasHasta.Size = New System.Drawing.Size(61, 20)
      Me.txtDiasHasta.TabIndex = 5
      Me.txtDiasHasta.Text = "0"
      Me.txtDiasHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtEtiqueta
      '
      Me.txtEtiqueta.BindearPropiedadControl = ""
      Me.txtEtiqueta.BindearPropiedadEntidad = ""
      Me.txtEtiqueta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEtiqueta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEtiqueta.Formato = ""
      Me.txtEtiqueta.IsDecimal = False
      Me.txtEtiqueta.IsNumber = False
      Me.txtEtiqueta.IsPK = False
      Me.txtEtiqueta.IsRequired = False
      Me.txtEtiqueta.Key = ""
      Me.txtEtiqueta.LabelAsoc = Me.lblEtiqueta
      Me.txtEtiqueta.Location = New System.Drawing.Point(9, 32)
      Me.txtEtiqueta.MaxLength = 30
      Me.txtEtiqueta.Name = "txtEtiqueta"
      Me.txtEtiqueta.Size = New System.Drawing.Size(119, 20)
      Me.txtEtiqueta.TabIndex = 1
      '
      'lblEtiqueta
      '
      Me.lblEtiqueta.AutoSize = True
      Me.lblEtiqueta.LabelAsoc = Nothing
      Me.lblEtiqueta.Location = New System.Drawing.Point(6, 16)
      Me.lblEtiqueta.Name = "lblEtiqueta"
      Me.lblEtiqueta.Size = New System.Drawing.Size(46, 13)
      Me.lblEtiqueta.TabIndex = 0
      Me.lblEtiqueta.Text = "Etiqueta"
      '
      'grpRangos
      '
      Me.grpRangos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpRangos.Controls.Add(Me.btnBajarRango)
      Me.grpRangos.Controls.Add(Me.btnSubirRango)
      Me.grpRangos.Controls.Add(Me.lblEtiqueta)
      Me.grpRangos.Controls.Add(Me.txtEtiqueta)
      Me.grpRangos.Controls.Add(Me.ugRangos)
      Me.grpRangos.Controls.Add(Me.txtDiasHasta)
      Me.grpRangos.Controls.Add(Me.btnEliminar)
      Me.grpRangos.Controls.Add(Me.lblOrden)
      Me.grpRangos.Controls.Add(Me.btnInsertar)
      Me.grpRangos.Controls.Add(Me.txtOrden)
      Me.grpRangos.Controls.Add(Me.txtDiasDesde)
      Me.grpRangos.Controls.Add(Me.lblDiasHasta)
      Me.grpRangos.Controls.Add(Me.lblDiasDesde)
      Me.grpRangos.Location = New System.Drawing.Point(12, 114)
      Me.grpRangos.Name = "grpRangos"
      Me.grpRangos.Size = New System.Drawing.Size(445, 352)
      Me.grpRangos.TabIndex = 7
      Me.grpRangos.TabStop = False
      Me.grpRangos.Text = "Rangos"
      '
      'btnBajarRango
      '
      Me.btnBajarRango.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBajarRango.Image = Global.Eniac.Win.My.Resources.Resources.navigate_down
      Me.btnBajarRango.Location = New System.Drawing.Point(401, 185)
      Me.btnBajarRango.Name = "btnBajarRango"
      Me.btnBajarRango.Size = New System.Drawing.Size(37, 37)
      Me.btnBajarRango.TabIndex = 12
      Me.btnBajarRango.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnBajarRango.UseVisualStyleBackColor = True
      '
      'btnSubirRango
      '
      Me.btnSubirRango.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSubirRango.Image = Global.Eniac.Win.My.Resources.Resources.navigate_up
      Me.btnSubirRango.Location = New System.Drawing.Point(401, 142)
      Me.btnSubirRango.Name = "btnSubirRango"
      Me.btnSubirRango.Size = New System.Drawing.Size(37, 37)
      Me.btnSubirRango.TabIndex = 11
      Me.btnSubirRango.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnSubirRango.UseVisualStyleBackColor = True
      '
      'CuentasCorrientesAntiguedadesSaldosConfigDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(466, 507)
      Me.Controls.Add(Me.grpRangos)
      Me.Controls.Add(Me.chbPorDefecto)
      Me.Controls.Add(Me.cmbTipoAntiguedadSaldoConfig)
      Me.Controls.Add(Me.lblTipoConceptoCM05)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.txtCodigo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.lblCodigo)
      Me.Name = "CuentasCorrientesAntiguedadesSaldosConfigDetalle"
      Me.Text = "Rangos Antigüedad de Saldo"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblTipoConceptoCM05, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoAntiguedadSaldoConfig, 0)
      Me.Controls.SetChildIndex(Me.chbPorDefecto, 0)
      Me.Controls.SetChildIndex(Me.grpRangos, 0)
      CType(Me.ugRangos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpRangos.ResumeLayout(False)
      Me.grpRangos.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents cmbTipoAntiguedadSaldoConfig As Controles.ComboBox
   Friend WithEvents lblTipoConceptoCM05 As Controles.Label
   Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtCodigo As Controles.TextBox
   Friend WithEvents lblCodigo As Controles.Label
   Friend WithEvents chbPorDefecto As Controles.CheckBox
   Friend WithEvents ugRangos As UltraGrid
   Friend WithEvents btnEliminar As Controles.Button
   Friend WithEvents btnInsertar As Controles.Button
   Friend WithEvents txtDiasDesde As Controles.TextBox
   Friend WithEvents lblDiasDesde As Controles.Label
   Friend WithEvents lblDiasHasta As Controles.Label
   Friend WithEvents txtOrden As Controles.TextBox
   Friend WithEvents lblOrden As Controles.Label
   Friend WithEvents txtDiasHasta As Controles.TextBox
   Friend WithEvents txtEtiqueta As Controles.TextBox
   Friend WithEvents lblEtiqueta As Controles.Label
   Friend WithEvents grpRangos As GroupBox
   Friend WithEvents btnBajarRango As Controles.Button
   Friend WithEvents btnSubirRango As Controles.Button
End Class
