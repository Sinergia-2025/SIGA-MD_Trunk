<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPPlanificacionNecesidadesCalculos
   Inherits Eniac.Win.BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MRPPlanificacionNecesidadesCalculos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.tsbCalcularNecesidades = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbOrdenesProduccion = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tbcOrdenProduccionCostos = New System.Windows.Forms.TabControl()
      Me.tbpProductos = New System.Windows.Forms.TabPage()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chbInformeCompleto = New Eniac.Controles.CheckBox()
      Me.btnCalcularOrdenes = New System.Windows.Forms.Button()
      Me.chbDepositoStock = New Eniac.Controles.CheckBox()
      Me.chbDepositoDefecto = New Eniac.Controles.CheckBox()
      Me.cmbDeposito = New Eniac.Controles.ComboBox()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
      Me.tbpOrdenes = New System.Windows.Forms.TabPage()
      Me.btnConfirmar = New System.Windows.Forms.Button()
      Me.ugDetalleFinal = New Eniac.Win.UltraGridSiga()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tstBarra.SuspendLayout()
        Me.tbcOrdenProduccionCostos.SuspendLayout()
        Me.tbpProductos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpOrdenes.SuspendLayout()
        CType(Me.ugDetalleFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(989, 29)
        Me.tstBarra.TabIndex = 2
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'tsbCalcularNecesidades
        '
        Me.tsbCalcularNecesidades.Image = CType(resources.GetObject("tsbCalcularNecesidades.Image"), System.Drawing.Image)
        Me.tsbCalcularNecesidades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCalcularNecesidades.Name = "tsbCalcularNecesidades"
        Me.tsbCalcularNecesidades.Size = New System.Drawing.Size(226, 26)
        Me.tsbCalcularNecesidades.Text = "Calcular Ordenes de Producción (F4)"
        Me.tsbCalcularNecesidades.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbOrdenesProduccion
        '
        Me.tsbOrdenesProduccion.Image = CType(resources.GetObject("tsbOrdenesProduccion.Image"), System.Drawing.Image)
        Me.tsbOrdenesProduccion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOrdenesProduccion.Name = "tsbOrdenesProduccion"
        Me.tsbOrdenesProduccion.Size = New System.Drawing.Size(214, 26)
        Me.tsbOrdenesProduccion.Text = "Confirmar Ordenes de Produccion"
        Me.tsbOrdenesProduccion.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tbcOrdenProduccionCostos
        '
        Me.tbcOrdenProduccionCostos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcOrdenProduccionCostos.Controls.Add(Me.tbpProductos)
        Me.tbcOrdenProduccionCostos.Controls.Add(Me.tbpOrdenes)
        Me.tbcOrdenProduccionCostos.Location = New System.Drawing.Point(0, 32)
        Me.tbcOrdenProduccionCostos.Name = "tbcOrdenProduccionCostos"
        Me.tbcOrdenProduccionCostos.SelectedIndex = 0
        Me.tbcOrdenProduccionCostos.Size = New System.Drawing.Size(989, 505)
        Me.tbcOrdenProduccionCostos.TabIndex = 6
        '
        'tbpProductos
        '
        Me.tbpProductos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpProductos.Controls.Add(Me.GroupBox1)
        Me.tbpProductos.Controls.Add(Me.btnTodos)
        Me.tbpProductos.Controls.Add(Me.cmbTodos)
        Me.tbpProductos.Controls.Add(Me.ugDetalle)
        Me.tbpProductos.Location = New System.Drawing.Point(4, 22)
        Me.tbpProductos.Name = "tbpProductos"
        Me.tbpProductos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpProductos.Size = New System.Drawing.Size(981, 479)
        Me.tbpProductos.TabIndex = 0
        Me.tbpProductos.Text = "Productos a Planificar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chbInformeCompleto)
        Me.GroupBox1.Controls.Add(Me.btnCalcularOrdenes)
        Me.GroupBox1.Controls.Add(Me.chbDepositoStock)
        Me.GroupBox1.Controls.Add(Me.chbDepositoDefecto)
        Me.GroupBox1.Controls.Add(Me.cmbDeposito)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(975, 48)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'chbInformeCompleto
        '
        Me.chbInformeCompleto.AutoSize = True
        Me.chbInformeCompleto.BackColor = System.Drawing.SystemColors.Control
        Me.chbInformeCompleto.BindearPropiedadControl = Nothing
        Me.chbInformeCompleto.BindearPropiedadEntidad = Nothing
        Me.chbInformeCompleto.ForeColor = System.Drawing.Color.Black
        Me.chbInformeCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbInformeCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbInformeCompleto.IsPK = False
        Me.chbInformeCompleto.IsRequired = False
        Me.chbInformeCompleto.Key = Nothing
        Me.chbInformeCompleto.LabelAsoc = Nothing
        Me.chbInformeCompleto.Location = New System.Drawing.Point(566, 17)
        Me.chbInformeCompleto.Name = "chbInformeCompleto"
        Me.chbInformeCompleto.Size = New System.Drawing.Size(108, 17)
        Me.chbInformeCompleto.TabIndex = 50
        Me.chbInformeCompleto.Text = "Informe Completo"
        Me.chbInformeCompleto.UseVisualStyleBackColor = False
        '
        'btnCalcularOrdenes
        '
        Me.btnCalcularOrdenes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalcularOrdenes.Image = CType(resources.GetObject("btnCalcularOrdenes.Image"), System.Drawing.Image)
        Me.btnCalcularOrdenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCalcularOrdenes.Location = New System.Drawing.Point(836, 9)
        Me.btnCalcularOrdenes.Name = "btnCalcularOrdenes"
        Me.btnCalcularOrdenes.Size = New System.Drawing.Size(133, 36)
        Me.btnCalcularOrdenes.TabIndex = 49
        Me.btnCalcularOrdenes.Text = "Calcular Ordenes"
        Me.btnCalcularOrdenes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCalcularOrdenes.UseVisualStyleBackColor = True
        '
        'chbDepositoStock
        '
        Me.chbDepositoStock.AutoSize = True
        Me.chbDepositoStock.BindearPropiedadControl = Nothing
        Me.chbDepositoStock.BindearPropiedadEntidad = Nothing
        Me.chbDepositoStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDepositoStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDepositoStock.IsPK = False
        Me.chbDepositoStock.IsRequired = False
        Me.chbDepositoStock.Key = Nothing
        Me.chbDepositoStock.LabelAsoc = Nothing
        Me.chbDepositoStock.Location = New System.Drawing.Point(141, 17)
        Me.chbDepositoStock.Name = "chbDepositoStock"
        Me.chbDepositoStock.Size = New System.Drawing.Size(68, 17)
        Me.chbDepositoStock.TabIndex = 48
        Me.chbDepositoStock.Text = "Depósito"
        Me.chbDepositoStock.UseVisualStyleBackColor = True
        '
        'chbDepositoDefecto
        '
        Me.chbDepositoDefecto.AutoSize = True
        Me.chbDepositoDefecto.BindearPropiedadControl = Nothing
        Me.chbDepositoDefecto.BindearPropiedadEntidad = Nothing
        Me.chbDepositoDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDepositoDefecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDepositoDefecto.IsPK = False
        Me.chbDepositoDefecto.IsRequired = False
        Me.chbDepositoDefecto.Key = Nothing
        Me.chbDepositoDefecto.LabelAsoc = Nothing
        Me.chbDepositoDefecto.Location = New System.Drawing.Point(8, 17)
        Me.chbDepositoDefecto.Name = "chbDepositoDefecto"
        Me.chbDepositoDefecto.Size = New System.Drawing.Size(127, 17)
        Me.chbDepositoDefecto.TabIndex = 47
        Me.chbDepositoDefecto.Text = "Depósito por Defecto"
        Me.chbDepositoDefecto.UseVisualStyleBackColor = True
        '
        'cmbDeposito
        '
        Me.cmbDeposito.BindearPropiedadControl = Nothing
        Me.cmbDeposito.BindearPropiedadEntidad = Nothing
        Me.cmbDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeposito.Enabled = False
        Me.cmbDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDeposito.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDeposito.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDeposito.FormattingEnabled = True
        Me.cmbDeposito.IsPK = False
        Me.cmbDeposito.IsRequired = False
        Me.cmbDeposito.Key = Nothing
        Me.cmbDeposito.LabelAsoc = Nothing
        Me.cmbDeposito.Location = New System.Drawing.Point(215, 15)
        Me.cmbDeposito.Name = "cmbDeposito"
        Me.cmbDeposito.Size = New System.Drawing.Size(334, 21)
        Me.cmbDeposito.TabIndex = 46
        '
        'btnTodos
        '
        Me.btnTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTodos.Image = CType(resources.GetObject("btnTodos.Image"), System.Drawing.Image)
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(897, 64)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 15
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(770, 64)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 14
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(3, 57)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(973, 418)
        Me.ugDetalle.TabIndex = 16
        Me.ugDetalle.ToolStripLabelRegistros = Nothing
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'tbpOrdenes
        '
        Me.tbpOrdenes.BackColor = System.Drawing.SystemColors.Control
        Me.tbpOrdenes.Controls.Add(Me.btnConfirmar)
        Me.tbpOrdenes.Controls.Add(Me.ugDetalleFinal)
        Me.tbpOrdenes.Location = New System.Drawing.Point(4, 22)
        Me.tbpOrdenes.Name = "tbpOrdenes"
        Me.tbpOrdenes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOrdenes.Size = New System.Drawing.Size(981, 479)
        Me.tbpOrdenes.TabIndex = 1
        Me.tbpOrdenes.Text = "Ordenes de Producción"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfirmar.Enabled = False
        Me.btnConfirmar.Image = CType(resources.GetObject("btnConfirmar.Image"), System.Drawing.Image)
        Me.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirmar.Location = New System.Drawing.Point(828, 7)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(146, 28)
        Me.btnConfirmar.TabIndex = 18
        Me.btnConfirmar.Text = "Generar Plan Maestro"
        Me.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'ugDetalleFinal
        '
        Me.ugDetalleFinal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalleFinal.DisplayLayout.Appearance = Appearance13
        Me.ugDetalleFinal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalleFinal.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalleFinal.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalleFinal.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.ugDetalleFinal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalleFinal.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalleFinal.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.ugDetalleFinal.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalleFinal.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugDetalleFinal.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalleFinal.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalleFinal.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.ugDetalleFinal.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalleFinal.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalleFinal.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalleFinal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalleFinal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalleFinal.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalleFinal.DisplayLayout.Override.CellAppearance = Appearance20
        Me.ugDetalleFinal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalleFinal.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalleFinal.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.ugDetalleFinal.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.ugDetalleFinal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalleFinal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalleFinal.DisplayLayout.Override.RowAppearance = Appearance23
        Me.ugDetalleFinal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalleFinal.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.ugDetalleFinal.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalleFinal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalleFinal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalleFinal.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalleFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalleFinal.Location = New System.Drawing.Point(3, 3)
        Me.ugDetalleFinal.Name = "ugDetalleFinal"
        Me.ugDetalleFinal.Size = New System.Drawing.Size(973, 472)
        Me.ugDetalleFinal.TabIndex = 17
        Me.ugDetalleFinal.ToolStripLabelRegistros = Nothing
        Me.ugDetalleFinal.ToolStripMenuExpandir = Nothing
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 540)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(989, 22)
        Me.stsStado.TabIndex = 16
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(910, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'MRPPlanificacionNecesidadesCalculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 562)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tbcOrdenProduccionCostos)
        Me.Controls.Add(Me.tstBarra)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MRPPlanificacionNecesidadesCalculos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcular Necesidades de Producción"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.tbcOrdenProduccionCostos.ResumeLayout(False)
        Me.tbpProductos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpOrdenes.ResumeLayout(False)
        CType(Me.ugDetalleFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents tstBarra As ToolStrip
    Public WithEvents tsbRefrescar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbCalcularNecesidades As ToolStripButton
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Public WithEvents tsbSalir As ToolStripButton
    Friend WithEvents tbcOrdenProduccionCostos As TabControl
    Friend WithEvents tbpProductos As TabPage
    Friend WithEvents tbpOrdenes As TabPage
    Friend WithEvents btnTodos As Button
    Friend WithEvents cmbTodos As Controles.ComboBox
    Protected Friend WithEvents stsStado As StatusStrip
    Protected Friend WithEvents tssInfo As ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As ToolStripProgressBar
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents ugDetalle As UltraGridSiga
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chbDepositoStock As Controles.CheckBox
    Friend WithEvents chbDepositoDefecto As Controles.CheckBox
    Friend WithEvents cmbDeposito As Controles.ComboBox
    Friend WithEvents ugDetalleFinal As UltraGridSiga
    Friend WithEvents tsbOrdenesProduccion As ToolStripButton
    Friend WithEvents btnCalcularOrdenes As Button
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents chbInformeCompleto As Controles.CheckBox
End Class
