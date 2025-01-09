<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscadoresDetalle
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
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBuscador")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdBuscadorNombreCampo")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Titulo")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Alineacion")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ancho")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Formato")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Condicion")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Valor")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ColorFila")
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuscadoresDetalle))
      Me.lblTitulo = New Eniac.Controles.Label()
      Me.txtTitulo = New Eniac.Controles.TextBox()
      Me.lblIdBuscador = New Eniac.Controles.Label()
      Me.txtIdBuscador = New Eniac.Controles.TextBox()
      Me.lblAnchoAyuda = New Eniac.Controles.Label()
      Me.txtAnchoAyuda = New Eniac.Controles.TextBox()
      Me.cmbIniciaConFocoEn = New Eniac.Controles.ComboBox()
      Me.lblIniciaConFocoEn = New Eniac.Controles.Label()
      Me.lblColumaBusquedaInicial = New Eniac.Controles.Label()
      Me.txtColumaBusquedaInicial = New Eniac.Controles.TextBox()
      Me.pnlBuscador = New System.Windows.Forms.Panel()
      Me.grpColumnas = New System.Windows.Forms.GroupBox()
      Me.ugBuscadoresColumnas = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.pnlColumnas = New System.Windows.Forms.Panel()
        Me.lblColumnaOrden = New Eniac.Controles.Label()
        Me.lblColumnaAncho = New Eniac.Controles.Label()
        Me.cmbColumnaAlineacion = New Eniac.Controles.ComboBox()
        Me.lblColumnaAlineacion = New Eniac.Controles.Label()
        Me.cmbColumnaCondicion = New Eniac.Controles.ComboBox()
        Me.txtColumnaOrden = New Eniac.Controles.TextBox()
        Me.txtColumnaAncho = New Eniac.Controles.TextBox()
        Me.lblColumnaColorFila = New Eniac.Controles.Label()
        Me.lblColumnaValor = New Eniac.Controles.Label()
        Me.lblColumnaCondicion = New Eniac.Controles.Label()
        Me.lblColumnaFormato = New Eniac.Controles.Label()
        Me.lblColumnaTitulo = New Eniac.Controles.Label()
        Me.lblIdBuscadorNombreCampo = New Eniac.Controles.Label()
        Me.txtColumnaColorFila = New Eniac.Controles.TextBox()
        Me.txtColumnaValor = New Eniac.Controles.TextBox()
        Me.txtColumnaFormato = New Eniac.Controles.TextBox()
        Me.txtColumnaTitulo = New Eniac.Controles.TextBox()
        Me.txtIdBuscadorNombreCampo = New Eniac.Controles.TextBox()
        Me.btnInsertarCondicion = New Eniac.Controles.Button()
        Me.btnEliminarCondicion = New Eniac.Controles.Button()
        Me.btnRefrescarCondicion = New Eniac.Controles.Button()
        Me.pnlBuscador.SuspendLayout()
        Me.grpColumnas.SuspendLayout()
        CType(Me.ugBuscadoresColumnas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlColumnas.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(505, 522)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(591, 522)
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(404, 522)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(347, 522)
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.LabelAsoc = Nothing
        Me.lblTitulo.Location = New System.Drawing.Point(27, 37)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(35, 13)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Título"
        '
        'txtTitulo
        '
        Me.txtTitulo.BindearPropiedadControl = "Text"
        Me.txtTitulo.BindearPropiedadEntidad = "Titulo"
        Me.txtTitulo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTitulo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTitulo.Formato = ""
        Me.txtTitulo.IsDecimal = False
        Me.txtTitulo.IsNumber = False
        Me.txtTitulo.IsPK = False
        Me.txtTitulo.IsRequired = True
        Me.txtTitulo.Key = ""
        Me.txtTitulo.LabelAsoc = Me.lblTitulo
        Me.txtTitulo.Location = New System.Drawing.Point(125, 33)
        Me.txtTitulo.MaxLength = 50
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(300, 20)
        Me.txtTitulo.TabIndex = 3
        '
        'lblIdBuscador
        '
        Me.lblIdBuscador.AutoSize = True
        Me.lblIdBuscador.LabelAsoc = Nothing
        Me.lblIdBuscador.Location = New System.Drawing.Point(27, 11)
        Me.lblIdBuscador.Name = "lblIdBuscador"
        Me.lblIdBuscador.Size = New System.Drawing.Size(40, 13)
        Me.lblIdBuscador.TabIndex = 0
        Me.lblIdBuscador.Text = "Código"
        '
        'txtIdBuscador
        '
        Me.txtIdBuscador.BindearPropiedadControl = "Text"
        Me.txtIdBuscador.BindearPropiedadEntidad = "IdBuscador"
        Me.txtIdBuscador.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdBuscador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdBuscador.Formato = ""
        Me.txtIdBuscador.IsDecimal = True
        Me.txtIdBuscador.IsNumber = True
        Me.txtIdBuscador.IsPK = True
        Me.txtIdBuscador.IsRequired = True
        Me.txtIdBuscador.Key = ""
        Me.txtIdBuscador.LabelAsoc = Me.lblIdBuscador
        Me.txtIdBuscador.Location = New System.Drawing.Point(125, 7)
        Me.txtIdBuscador.MaxLength = 6
        Me.txtIdBuscador.Name = "txtIdBuscador"
        Me.txtIdBuscador.Size = New System.Drawing.Size(48, 20)
        Me.txtIdBuscador.TabIndex = 1
        Me.txtIdBuscador.Text = "0"
        Me.txtIdBuscador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAnchoAyuda
        '
        Me.lblAnchoAyuda.AutoSize = True
        Me.lblAnchoAyuda.LabelAsoc = Nothing
        Me.lblAnchoAyuda.Location = New System.Drawing.Point(458, 37)
        Me.lblAnchoAyuda.Name = "lblAnchoAyuda"
        Me.lblAnchoAyuda.Size = New System.Drawing.Size(38, 13)
        Me.lblAnchoAyuda.TabIndex = 4
        Me.lblAnchoAyuda.Text = "Ancho"
        '
        'txtAnchoAyuda
        '
        Me.txtAnchoAyuda.BindearPropiedadControl = "Text"
        Me.txtAnchoAyuda.BindearPropiedadEntidad = "AnchoAyuda"
        Me.txtAnchoAyuda.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAnchoAyuda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAnchoAyuda.Formato = ""
        Me.txtAnchoAyuda.IsDecimal = False
        Me.txtAnchoAyuda.IsNumber = True
        Me.txtAnchoAyuda.IsPK = False
        Me.txtAnchoAyuda.IsRequired = False
        Me.txtAnchoAyuda.Key = ""
        Me.txtAnchoAyuda.LabelAsoc = Me.lblAnchoAyuda
        Me.txtAnchoAyuda.Location = New System.Drawing.Point(502, 33)
        Me.txtAnchoAyuda.MaxLength = 20
        Me.txtAnchoAyuda.Name = "txtAnchoAyuda"
        Me.txtAnchoAyuda.Size = New System.Drawing.Size(48, 20)
        Me.txtAnchoAyuda.TabIndex = 5
        Me.txtAnchoAyuda.Text = "0"
        Me.txtAnchoAyuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbIniciaConFocoEn
        '
        Me.cmbIniciaConFocoEn.BindearPropiedadControl = "SelectedValue"
        Me.cmbIniciaConFocoEn.BindearPropiedadEntidad = "IniciaConFocoEn"
        Me.cmbIniciaConFocoEn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIniciaConFocoEn.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIniciaConFocoEn.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIniciaConFocoEn.FormattingEnabled = True
        Me.cmbIniciaConFocoEn.IsPK = False
        Me.cmbIniciaConFocoEn.IsRequired = False
        Me.cmbIniciaConFocoEn.Key = Nothing
        Me.cmbIniciaConFocoEn.LabelAsoc = Me.lblIniciaConFocoEn
        Me.cmbIniciaConFocoEn.Location = New System.Drawing.Point(125, 59)
        Me.cmbIniciaConFocoEn.Name = "cmbIniciaConFocoEn"
        Me.cmbIniciaConFocoEn.Size = New System.Drawing.Size(128, 21)
        Me.cmbIniciaConFocoEn.TabIndex = 7
        '
        'lblIniciaConFocoEn
        '
        Me.lblIniciaConFocoEn.AutoSize = True
        Me.lblIniciaConFocoEn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIniciaConFocoEn.LabelAsoc = Nothing
        Me.lblIniciaConFocoEn.Location = New System.Drawing.Point(27, 63)
        Me.lblIniciaConFocoEn.Name = "lblIniciaConFocoEn"
        Me.lblIniciaConFocoEn.Size = New System.Drawing.Size(92, 13)
        Me.lblIniciaConFocoEn.TabIndex = 6
        Me.lblIniciaConFocoEn.Text = "Inicia con foco en"
        '
        'lblColumaBusquedaInicial
        '
        Me.lblColumaBusquedaInicial.AutoSize = True
        Me.lblColumaBusquedaInicial.LabelAsoc = Nothing
        Me.lblColumaBusquedaInicial.Location = New System.Drawing.Point(264, 63)
        Me.lblColumaBusquedaInicial.Name = "lblColumaBusquedaInicial"
        Me.lblColumaBusquedaInicial.Size = New System.Drawing.Size(71, 13)
        Me.lblColumaBusquedaInicial.TabIndex = 8
        Me.lblColumaBusquedaInicial.Text = "Columa inicial"
        '
        'txtColumaBusquedaInicial
        '
        Me.txtColumaBusquedaInicial.BindearPropiedadControl = "Text"
        Me.txtColumaBusquedaInicial.BindearPropiedadEntidad = "ColumnaBusquedaInicial"
        Me.txtColumaBusquedaInicial.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColumaBusquedaInicial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColumaBusquedaInicial.Formato = ""
        Me.txtColumaBusquedaInicial.IsDecimal = False
        Me.txtColumaBusquedaInicial.IsNumber = False
        Me.txtColumaBusquedaInicial.IsPK = False
        Me.txtColumaBusquedaInicial.IsRequired = False
        Me.txtColumaBusquedaInicial.Key = ""
        Me.txtColumaBusquedaInicial.LabelAsoc = Me.lblColumaBusquedaInicial
        Me.txtColumaBusquedaInicial.Location = New System.Drawing.Point(341, 59)
        Me.txtColumaBusquedaInicial.MaxLength = 50
        Me.txtColumaBusquedaInicial.Name = "txtColumaBusquedaInicial"
        Me.txtColumaBusquedaInicial.Size = New System.Drawing.Size(300, 20)
        Me.txtColumaBusquedaInicial.TabIndex = 9
        '
        'pnlBuscador
        '
        Me.pnlBuscador.Controls.Add(Me.lblColumaBusquedaInicial)
        Me.pnlBuscador.Controls.Add(Me.txtColumaBusquedaInicial)
        Me.pnlBuscador.Controls.Add(Me.cmbIniciaConFocoEn)
        Me.pnlBuscador.Controls.Add(Me.lblIniciaConFocoEn)
        Me.pnlBuscador.Controls.Add(Me.lblAnchoAyuda)
        Me.pnlBuscador.Controls.Add(Me.txtAnchoAyuda)
        Me.pnlBuscador.Controls.Add(Me.lblTitulo)
        Me.pnlBuscador.Controls.Add(Me.txtTitulo)
        Me.pnlBuscador.Controls.Add(Me.lblIdBuscador)
        Me.pnlBuscador.Controls.Add(Me.txtIdBuscador)
        Me.pnlBuscador.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBuscador.Location = New System.Drawing.Point(0, 0)
        Me.pnlBuscador.Name = "pnlBuscador"
        Me.pnlBuscador.Size = New System.Drawing.Size(680, 84)
        Me.pnlBuscador.TabIndex = 10
        '
        'grpColumnas
        '
        Me.grpColumnas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpColumnas.Controls.Add(Me.ugBuscadoresColumnas)
        Me.grpColumnas.Controls.Add(Me.pnlColumnas)
        Me.grpColumnas.Location = New System.Drawing.Point(0, 86)
        Me.grpColumnas.Name = "grpColumnas"
        Me.grpColumnas.Size = New System.Drawing.Size(680, 430)
        Me.grpColumnas.TabIndex = 11
        Me.grpColumnas.TabStop = False
        Me.grpColumnas.Text = "Columnas"
        '
        'ugBuscadoresColumnas
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugBuscadoresColumnas.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.Caption = "Campo"
        UltraGridColumn2.Header.VisiblePosition = 1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance2
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 44
        UltraGridColumn4.Header.Caption = "Título"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 195
        UltraGridColumn5.Header.VisiblePosition = 4
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance3
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 45
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 55
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Width = 53
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10})
        Me.ugBuscadoresColumnas.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugBuscadoresColumnas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugBuscadoresColumnas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.ugBuscadoresColumnas.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugBuscadoresColumnas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.ugBuscadoresColumnas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugBuscadoresColumnas.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.ugBuscadoresColumnas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugBuscadoresColumnas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugBuscadoresColumnas.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugBuscadoresColumnas.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.ugBuscadoresColumnas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugBuscadoresColumnas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.ugBuscadoresColumnas.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugBuscadoresColumnas.DisplayLayout.Override.CellAppearance = Appearance10
        Me.ugBuscadoresColumnas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugBuscadoresColumnas.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugBuscadoresColumnas.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.ugBuscadoresColumnas.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.ugBuscadoresColumnas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugBuscadoresColumnas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.ugBuscadoresColumnas.DisplayLayout.Override.RowAppearance = Appearance13
        Me.ugBuscadoresColumnas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugBuscadoresColumnas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.ugBuscadoresColumnas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugBuscadoresColumnas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugBuscadoresColumnas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugBuscadoresColumnas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugBuscadoresColumnas.Location = New System.Drawing.Point(3, 100)
        Me.ugBuscadoresColumnas.Name = "ugBuscadoresColumnas"
        Me.ugBuscadoresColumnas.Size = New System.Drawing.Size(674, 327)
        Me.ugBuscadoresColumnas.TabIndex = 0
        Me.ugBuscadoresColumnas.Text = "UltraGrid1"
        '
        'pnlColumnas
        '
        Me.pnlColumnas.Controls.Add(Me.lblColumnaOrden)
        Me.pnlColumnas.Controls.Add(Me.lblColumnaAncho)
        Me.pnlColumnas.Controls.Add(Me.cmbColumnaAlineacion)
        Me.pnlColumnas.Controls.Add(Me.cmbColumnaCondicion)
        Me.pnlColumnas.Controls.Add(Me.lblColumnaAlineacion)
        Me.pnlColumnas.Controls.Add(Me.txtColumnaOrden)
        Me.pnlColumnas.Controls.Add(Me.txtColumnaAncho)
        Me.pnlColumnas.Controls.Add(Me.lblColumnaColorFila)
        Me.pnlColumnas.Controls.Add(Me.lblColumnaValor)
        Me.pnlColumnas.Controls.Add(Me.lblColumnaCondicion)
        Me.pnlColumnas.Controls.Add(Me.lblColumnaFormato)
        Me.pnlColumnas.Controls.Add(Me.lblColumnaTitulo)
        Me.pnlColumnas.Controls.Add(Me.lblIdBuscadorNombreCampo)
        Me.pnlColumnas.Controls.Add(Me.txtColumnaColorFila)
        Me.pnlColumnas.Controls.Add(Me.txtColumnaValor)
        Me.pnlColumnas.Controls.Add(Me.txtColumnaFormato)
        Me.pnlColumnas.Controls.Add(Me.txtColumnaTitulo)
        Me.pnlColumnas.Controls.Add(Me.txtIdBuscadorNombreCampo)
        Me.pnlColumnas.Controls.Add(Me.btnInsertarCondicion)
        Me.pnlColumnas.Controls.Add(Me.btnEliminarCondicion)
        Me.pnlColumnas.Controls.Add(Me.btnRefrescarCondicion)
        Me.pnlColumnas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlColumnas.Location = New System.Drawing.Point(3, 16)
        Me.pnlColumnas.Name = "pnlColumnas"
        Me.pnlColumnas.Size = New System.Drawing.Size(674, 84)
        Me.pnlColumnas.TabIndex = 1
        '
        'lblColumnaOrden
        '
        Me.lblColumnaOrden.AutoSize = True
        Me.lblColumnaOrden.LabelAsoc = Nothing
        Me.lblColumnaOrden.Location = New System.Drawing.Point(55, 36)
        Me.lblColumnaOrden.Name = "lblColumnaOrden"
        Me.lblColumnaOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblColumnaOrden.TabIndex = 24
        Me.lblColumnaOrden.Text = "Orden"
        '
        'lblColumnaAncho
        '
        Me.lblColumnaAncho.AutoSize = True
        Me.lblColumnaAncho.LabelAsoc = Nothing
        Me.lblColumnaAncho.Location = New System.Drawing.Point(169, 36)
        Me.lblColumnaAncho.Name = "lblColumnaAncho"
        Me.lblColumnaAncho.Size = New System.Drawing.Size(38, 13)
        Me.lblColumnaAncho.TabIndex = 24
        Me.lblColumnaAncho.Text = "Ancho"
        '
        'cmbColumnaAlineacion
        '
        Me.cmbColumnaAlineacion.BindearPropiedadControl = ""
        Me.cmbColumnaAlineacion.BindearPropiedadEntidad = ""
        Me.cmbColumnaAlineacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumnaAlineacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbColumnaAlineacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbColumnaAlineacion.FormattingEnabled = True
        Me.cmbColumnaAlineacion.IsPK = False
        Me.cmbColumnaAlineacion.IsRequired = False
        Me.cmbColumnaAlineacion.Key = Nothing
        Me.cmbColumnaAlineacion.LabelAsoc = Me.lblColumnaAlineacion
        Me.cmbColumnaAlineacion.Location = New System.Drawing.Point(330, 32)
        Me.cmbColumnaAlineacion.Name = "cmbColumnaAlineacion"
        Me.cmbColumnaAlineacion.Size = New System.Drawing.Size(128, 21)
        Me.cmbColumnaAlineacion.TabIndex = 7
        '
        'lblColumnaAlineacion
        '
        Me.lblColumnaAlineacion.AutoSize = True
        Me.lblColumnaAlineacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblColumnaAlineacion.LabelAsoc = Nothing
        Me.lblColumnaAlineacion.Location = New System.Drawing.Point(268, 36)
        Me.lblColumnaAlineacion.Name = "lblColumnaAlineacion"
        Me.lblColumnaAlineacion.Size = New System.Drawing.Size(56, 13)
        Me.lblColumnaAlineacion.TabIndex = 6
        Me.lblColumnaAlineacion.Text = "Alineación"
        '
        'cmbColumnaCondicion
        '
        Me.cmbColumnaCondicion.BindearPropiedadControl = ""
        Me.cmbColumnaCondicion.BindearPropiedadEntidad = ""
        Me.cmbColumnaCondicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColumnaCondicion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbColumnaCondicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbColumnaCondicion.FormattingEnabled = True
        Me.cmbColumnaCondicion.IsPK = False
        Me.cmbColumnaCondicion.IsRequired = False
        Me.cmbColumnaCondicion.Key = Nothing
        Me.cmbColumnaCondicion.LabelAsoc = Me.lblColumnaAlineacion
        Me.cmbColumnaCondicion.Location = New System.Drawing.Point(115, 59)
        Me.cmbColumnaCondicion.Name = "cmbColumnaCondicion"
        Me.cmbColumnaCondicion.Size = New System.Drawing.Size(128, 21)
        Me.cmbColumnaCondicion.TabIndex = 7
        '
        'txtColumnaOrden
        '
        Me.txtColumnaOrden.BindearPropiedadControl = ""
        Me.txtColumnaOrden.BindearPropiedadEntidad = ""
        Me.txtColumnaOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColumnaOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColumnaOrden.Formato = ""
        Me.txtColumnaOrden.IsDecimal = False
        Me.txtColumnaOrden.IsNumber = True
        Me.txtColumnaOrden.IsPK = False
        Me.txtColumnaOrden.IsRequired = False
        Me.txtColumnaOrden.Key = ""
        Me.txtColumnaOrden.LabelAsoc = Me.lblColumnaOrden
        Me.txtColumnaOrden.Location = New System.Drawing.Point(115, 32)
        Me.txtColumnaOrden.MaxLength = 20
        Me.txtColumnaOrden.Name = "txtColumnaOrden"
        Me.txtColumnaOrden.Size = New System.Drawing.Size(48, 20)
        Me.txtColumnaOrden.TabIndex = 25
        Me.txtColumnaOrden.Text = "0"
        Me.txtColumnaOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtColumnaAncho
        '
        Me.txtColumnaAncho.BindearPropiedadControl = ""
        Me.txtColumnaAncho.BindearPropiedadEntidad = ""
        Me.txtColumnaAncho.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColumnaAncho.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColumnaAncho.Formato = ""
        Me.txtColumnaAncho.IsDecimal = False
        Me.txtColumnaAncho.IsNumber = True
        Me.txtColumnaAncho.IsPK = False
        Me.txtColumnaAncho.IsRequired = False
        Me.txtColumnaAncho.Key = ""
        Me.txtColumnaAncho.LabelAsoc = Me.lblColumnaAncho
        Me.txtColumnaAncho.Location = New System.Drawing.Point(213, 32)
        Me.txtColumnaAncho.MaxLength = 20
        Me.txtColumnaAncho.Name = "txtColumnaAncho"
        Me.txtColumnaAncho.Size = New System.Drawing.Size(48, 20)
        Me.txtColumnaAncho.TabIndex = 25
        Me.txtColumnaAncho.Text = "0"
        Me.txtColumnaAncho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblColumnaColorFila
        '
        Me.lblColumnaColorFila.AutoSize = True
        Me.lblColumnaColorFila.LabelAsoc = Nothing
        Me.lblColumnaColorFila.Location = New System.Drawing.Point(421, 63)
        Me.lblColumnaColorFila.Name = "lblColumnaColorFila"
        Me.lblColumnaColorFila.Size = New System.Drawing.Size(50, 13)
        Me.lblColumnaColorFila.TabIndex = 22
        Me.lblColumnaColorFila.Text = "Color Fila"
        '
        'lblColumnaValor
        '
        Me.lblColumnaValor.AutoSize = True
        Me.lblColumnaValor.LabelAsoc = Nothing
        Me.lblColumnaValor.Location = New System.Drawing.Point(250, 63)
        Me.lblColumnaValor.Name = "lblColumnaValor"
        Me.lblColumnaValor.Size = New System.Drawing.Size(31, 13)
        Me.lblColumnaValor.TabIndex = 22
        Me.lblColumnaValor.Text = "Valor"
        '
        'lblColumnaCondicion
        '
        Me.lblColumnaCondicion.AutoSize = True
        Me.lblColumnaCondicion.LabelAsoc = Nothing
        Me.lblColumnaCondicion.Location = New System.Drawing.Point(55, 63)
        Me.lblColumnaCondicion.Name = "lblColumnaCondicion"
        Me.lblColumnaCondicion.Size = New System.Drawing.Size(54, 13)
        Me.lblColumnaCondicion.TabIndex = 22
        Me.lblColumnaCondicion.Text = "Condicion"
        '
        'lblColumnaFormato
        '
        Me.lblColumnaFormato.AutoSize = True
        Me.lblColumnaFormato.LabelAsoc = Nothing
        Me.lblColumnaFormato.Location = New System.Drawing.Point(479, 36)
        Me.lblColumnaFormato.Name = "lblColumnaFormato"
        Me.lblColumnaFormato.Size = New System.Drawing.Size(45, 13)
        Me.lblColumnaFormato.TabIndex = 22
        Me.lblColumnaFormato.Text = "Formato"
        '
        'lblColumnaTitulo
        '
        Me.lblColumnaTitulo.AutoSize = True
        Me.lblColumnaTitulo.LabelAsoc = Nothing
        Me.lblColumnaTitulo.Location = New System.Drawing.Point(289, 11)
        Me.lblColumnaTitulo.Name = "lblColumnaTitulo"
        Me.lblColumnaTitulo.Size = New System.Drawing.Size(35, 13)
        Me.lblColumnaTitulo.TabIndex = 22
        Me.lblColumnaTitulo.Text = "Título"
        '
        'lblIdBuscadorNombreCampo
        '
        Me.lblIdBuscadorNombreCampo.AutoSize = True
        Me.lblIdBuscadorNombreCampo.LabelAsoc = Nothing
        Me.lblIdBuscadorNombreCampo.Location = New System.Drawing.Point(55, 11)
        Me.lblIdBuscadorNombreCampo.Name = "lblIdBuscadorNombreCampo"
        Me.lblIdBuscadorNombreCampo.Size = New System.Drawing.Size(48, 13)
        Me.lblIdBuscadorNombreCampo.TabIndex = 22
        Me.lblIdBuscadorNombreCampo.Text = "Columna"
        '
        'txtColumnaColorFila
        '
        Me.txtColumnaColorFila.BindearPropiedadControl = ""
        Me.txtColumnaColorFila.BindearPropiedadEntidad = ""
        Me.txtColumnaColorFila.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColumnaColorFila.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColumnaColorFila.Formato = ""
        Me.txtColumnaColorFila.IsDecimal = False
        Me.txtColumnaColorFila.IsNumber = False
        Me.txtColumnaColorFila.IsPK = False
        Me.txtColumnaColorFila.IsRequired = True
        Me.txtColumnaColorFila.Key = ""
        Me.txtColumnaColorFila.LabelAsoc = Me.lblColumnaColorFila
        Me.txtColumnaColorFila.Location = New System.Drawing.Point(477, 59)
        Me.txtColumnaColorFila.MaxLength = 50
        Me.txtColumnaColorFila.Name = "txtColumnaColorFila"
        Me.txtColumnaColorFila.Size = New System.Drawing.Size(126, 20)
        Me.txtColumnaColorFila.TabIndex = 23
        '
        'txtColumnaValor
        '
        Me.txtColumnaValor.BindearPropiedadControl = ""
        Me.txtColumnaValor.BindearPropiedadEntidad = ""
        Me.txtColumnaValor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColumnaValor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColumnaValor.Formato = ""
        Me.txtColumnaValor.IsDecimal = False
        Me.txtColumnaValor.IsNumber = False
        Me.txtColumnaValor.IsPK = False
        Me.txtColumnaValor.IsRequired = False
        Me.txtColumnaValor.Key = ""
        Me.txtColumnaValor.LabelAsoc = Me.lblColumnaValor
        Me.txtColumnaValor.Location = New System.Drawing.Point(287, 59)
        Me.txtColumnaValor.MaxLength = 50
        Me.txtColumnaValor.Name = "txtColumnaValor"
        Me.txtColumnaValor.Size = New System.Drawing.Size(128, 20)
        Me.txtColumnaValor.TabIndex = 23
        '
        'txtColumnaFormato
        '
        Me.txtColumnaFormato.BindearPropiedadControl = ""
        Me.txtColumnaFormato.BindearPropiedadEntidad = ""
        Me.txtColumnaFormato.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColumnaFormato.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColumnaFormato.Formato = ""
        Me.txtColumnaFormato.IsDecimal = False
        Me.txtColumnaFormato.IsNumber = False
        Me.txtColumnaFormato.IsPK = False
        Me.txtColumnaFormato.IsRequired = True
        Me.txtColumnaFormato.Key = ""
        Me.txtColumnaFormato.LabelAsoc = Me.lblColumnaFormato
        Me.txtColumnaFormato.Location = New System.Drawing.Point(539, 32)
        Me.txtColumnaFormato.MaxLength = 50
        Me.txtColumnaFormato.Name = "txtColumnaFormato"
        Me.txtColumnaFormato.Size = New System.Drawing.Size(64, 20)
        Me.txtColumnaFormato.TabIndex = 23
        '
        'txtColumnaTitulo
        '
        Me.txtColumnaTitulo.BindearPropiedadControl = ""
        Me.txtColumnaTitulo.BindearPropiedadEntidad = ""
        Me.txtColumnaTitulo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColumnaTitulo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColumnaTitulo.Formato = ""
        Me.txtColumnaTitulo.IsDecimal = False
        Me.txtColumnaTitulo.IsNumber = False
        Me.txtColumnaTitulo.IsPK = False
        Me.txtColumnaTitulo.IsRequired = False
        Me.txtColumnaTitulo.Key = ""
        Me.txtColumnaTitulo.LabelAsoc = Me.lblColumnaTitulo
        Me.txtColumnaTitulo.Location = New System.Drawing.Point(330, 7)
        Me.txtColumnaTitulo.MaxLength = 50
        Me.txtColumnaTitulo.Name = "txtColumnaTitulo"
        Me.txtColumnaTitulo.Size = New System.Drawing.Size(235, 20)
        Me.txtColumnaTitulo.TabIndex = 23
        '
        'txtIdBuscadorNombreCampo
        '
        Me.txtIdBuscadorNombreCampo.BindearPropiedadControl = ""
        Me.txtIdBuscadorNombreCampo.BindearPropiedadEntidad = ""
        Me.txtIdBuscadorNombreCampo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdBuscadorNombreCampo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdBuscadorNombreCampo.Formato = ""
        Me.txtIdBuscadorNombreCampo.IsDecimal = False
        Me.txtIdBuscadorNombreCampo.IsNumber = False
        Me.txtIdBuscadorNombreCampo.IsPK = False
        Me.txtIdBuscadorNombreCampo.IsRequired = False
        Me.txtIdBuscadorNombreCampo.Key = ""
        Me.txtIdBuscadorNombreCampo.LabelAsoc = Me.lblIdBuscadorNombreCampo
        Me.txtIdBuscadorNombreCampo.Location = New System.Drawing.Point(115, 7)
        Me.txtIdBuscadorNombreCampo.MaxLength = 50
        Me.txtIdBuscadorNombreCampo.Name = "txtIdBuscadorNombreCampo"
        Me.txtIdBuscadorNombreCampo.Size = New System.Drawing.Size(128, 20)
        Me.txtIdBuscadorNombreCampo.TabIndex = 23
        '
        'btnInsertarCondicion
        '
        Me.btnInsertarCondicion.Image = CType(resources.GetObject("btnInsertarCondicion.Image"), System.Drawing.Image)
        Me.btnInsertarCondicion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertarCondicion.Location = New System.Drawing.Point(628, 2)
        Me.btnInsertarCondicion.Name = "btnInsertarCondicion"
        Me.btnInsertarCondicion.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertarCondicion.TabIndex = 20
        Me.btnInsertarCondicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarCondicion.UseVisualStyleBackColor = True
        '
        'btnEliminarCondicion
        '
        Me.btnEliminarCondicion.Image = CType(resources.GetObject("btnEliminarCondicion.Image"), System.Drawing.Image)
        Me.btnEliminarCondicion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminarCondicion.Location = New System.Drawing.Point(628, 45)
        Me.btnEliminarCondicion.Name = "btnEliminarCondicion"
        Me.btnEliminarCondicion.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminarCondicion.TabIndex = 21
        Me.btnEliminarCondicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarCondicion.UseVisualStyleBackColor = True
        '
        'btnRefrescarCondicion
        '
        Me.btnRefrescarCondicion.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.btnRefrescarCondicion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefrescarCondicion.Location = New System.Drawing.Point(6, 4)
        Me.btnRefrescarCondicion.Name = "btnRefrescarCondicion"
        Me.btnRefrescarCondicion.Size = New System.Drawing.Size(37, 37)
        Me.btnRefrescarCondicion.TabIndex = 17
        Me.btnRefrescarCondicion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefrescarCondicion.UseVisualStyleBackColor = True
        '
        'BuscadoresDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 557)
        Me.Controls.Add(Me.grpColumnas)
        Me.Controls.Add(Me.pnlBuscador)
        Me.Name = "BuscadoresDetalle"
        Me.Text = "Buscador"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.pnlBuscador, 0)
        Me.Controls.SetChildIndex(Me.grpColumnas, 0)
        Me.pnlBuscador.ResumeLayout(False)
        Me.pnlBuscador.PerformLayout()
        Me.grpColumnas.ResumeLayout(False)
        CType(Me.ugBuscadoresColumnas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlColumnas.ResumeLayout(False)
        Me.pnlColumnas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitulo As Controles.Label
   Friend WithEvents txtTitulo As Controles.TextBox
   Friend WithEvents lblIdBuscador As Controles.Label
   Friend WithEvents txtIdBuscador As Controles.TextBox
   Friend WithEvents lblAnchoAyuda As Controles.Label
   Friend WithEvents txtAnchoAyuda As Controles.TextBox
   Friend WithEvents cmbIniciaConFocoEn As Controles.ComboBox
   Friend WithEvents lblIniciaConFocoEn As Controles.Label
   Friend WithEvents lblColumaBusquedaInicial As Controles.Label
   Friend WithEvents txtColumaBusquedaInicial As Controles.TextBox
   Friend WithEvents pnlBuscador As Panel
   Friend WithEvents grpColumnas As GroupBox
   Friend WithEvents ugBuscadoresColumnas As UltraGrid
   Friend WithEvents pnlColumnas As Panel
   Friend WithEvents btnInsertarCondicion As Controles.Button
   Friend WithEvents btnEliminarCondicion As Controles.Button
   Friend WithEvents btnRefrescarCondicion As Controles.Button
   Friend WithEvents lblColumnaOrden As Controles.Label
   Friend WithEvents lblColumnaAncho As Controles.Label
   Friend WithEvents txtColumnaOrden As Controles.TextBox
   Friend WithEvents txtColumnaAncho As Controles.TextBox
   Friend WithEvents lblColumnaColorFila As Controles.Label
   Friend WithEvents lblColumnaValor As Controles.Label
   Friend WithEvents lblColumnaCondicion As Controles.Label
   Friend WithEvents lblColumnaFormato As Controles.Label
   Friend WithEvents lblColumnaTitulo As Controles.Label
   Friend WithEvents lblIdBuscadorNombreCampo As Controles.Label
   Friend WithEvents txtColumnaColorFila As Controles.TextBox
   Friend WithEvents txtColumnaValor As Controles.TextBox
   Friend WithEvents txtColumnaFormato As Controles.TextBox
   Friend WithEvents txtColumnaTitulo As Controles.TextBox
   Friend WithEvents txtIdBuscadorNombreCampo As Controles.TextBox
   Friend WithEvents cmbColumnaCondicion As Controles.ComboBox
   Friend WithEvents lblColumnaAlineacion As Controles.Label
   Friend WithEvents cmbColumnaAlineacion As Controles.ComboBox
End Class
