<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlantillasCalidadDetalle
   Inherits BaseDetalle

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
      Me.components = New System.ComponentModel.Container()
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlantillasCalidadDetalle))
      Me.txtIdPlanilla = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.spcDatos = New System.Windows.Forms.SplitContainer()
      Me.ugListasControl = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.bdsListasControl = New System.Windows.Forms.BindingSource(Me.components)
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssListasControlAsignar = New System.Windows.Forms.ToolStripStatusLabel()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.btnAgregar = New Eniac.Controles.Button()
      Me.ugProductoListasControl = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.bdsProductosListasControl = New System.Windows.Forms.BindingSource(Me.components)
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ToolStripProgressBar2 = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssProductosListaControl = New System.Windows.Forms.ToolStripStatusLabel()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.btnSacar = New Eniac.Controles.Button()
      CType(Me.spcDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spcDatos.Panel1.SuspendLayout()
      Me.spcDatos.Panel2.SuspendLayout()
      Me.spcDatos.SuspendLayout()
      CType(Me.ugListasControl, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bdsListasControl, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.StatusStrip1.SuspendLayout()
      Me.Panel1.SuspendLayout()
      CType(Me.ugProductoListasControl, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.bdsProductosListasControl, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(649, 472)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(735, 472)
      Me.btnCancelar.TabIndex = 5
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(512, 472)
      Me.btnCopiar.TabIndex = 10
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(313, 233)
      '
      'txtIdPlanilla
      '
      Me.txtIdPlanilla.BindearPropiedadControl = "Text"
      Me.txtIdPlanilla.BindearPropiedadEntidad = "IdPlantillaCalidad"
      Me.txtIdPlanilla.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdPlanilla.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdPlanilla.Formato = ""
      Me.txtIdPlanilla.IsDecimal = False
      Me.txtIdPlanilla.IsNumber = True
      Me.txtIdPlanilla.IsPK = True
      Me.txtIdPlanilla.IsRequired = True
      Me.txtIdPlanilla.Key = ""
      Me.txtIdPlanilla.LabelAsoc = Me.lblId
      Me.txtIdPlanilla.Location = New System.Drawing.Point(63, 26)
      Me.txtIdPlanilla.MaxLength = 4
      Me.txtIdPlanilla.Name = "txtIdPlanilla"
      Me.txtIdPlanilla.Size = New System.Drawing.Size(62, 20)
      Me.txtIdPlanilla.TabIndex = 0
      Me.txtIdPlanilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.LabelAsoc = Nothing
      Me.lblId.Location = New System.Drawing.Point(14, 29)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(43, 13)
      Me.lblId.TabIndex = 6
      Me.lblId.Text = "Plantilla"
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(141, 29)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 7
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombrePlantillaCalidad"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(197, 26)
      Me.txtNombre.MaxLength = 50
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(600, 20)
      Me.txtNombre.TabIndex = 1
      '
      'spcDatos
      '
      Me.spcDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.spcDatos.Enabled = False
      Me.spcDatos.Location = New System.Drawing.Point(12, 69)
      Me.spcDatos.Name = "spcDatos"
      '
      'spcDatos.Panel1
      '
      Me.spcDatos.Panel1.Controls.Add(Me.ugListasControl)
      Me.spcDatos.Panel1.Controls.Add(Me.StatusStrip1)
      Me.spcDatos.Panel1.Controls.Add(Me.Panel1)
      '
      'spcDatos.Panel2
      '
      Me.spcDatos.Panel2.Controls.Add(Me.ugProductoListasControl)
      Me.spcDatos.Panel2.Controls.Add(Me.stsStado)
      Me.spcDatos.Panel2.Controls.Add(Me.Panel2)
      Me.spcDatos.Size = New System.Drawing.Size(803, 373)
      Me.spcDatos.SplitterDistance = 368
      Me.spcDatos.TabIndex = 11
      '
      'ugListasControl
      '
      Me.ugListasControl.DataSource = Me.bdsListasControl
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugListasControl.DisplayLayout.Appearance = Appearance1
      Me.ugListasControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      Me.ugListasControl.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugListasControl.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugListasControl.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugListasControl.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugListasControl.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugListasControl.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aqui para agrupar."
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugListasControl.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugListasControl.DisplayLayout.MaxColScrollRegions = 1
      Me.ugListasControl.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugListasControl.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugListasControl.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugListasControl.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugListasControl.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugListasControl.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugListasControl.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugListasControl.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.ugListasControl.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugListasControl.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugListasControl.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugListasControl.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugListasControl.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugListasControl.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugListasControl.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugListasControl.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugListasControl.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugListasControl.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugListasControl.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugListasControl.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugListasControl.Location = New System.Drawing.Point(0, 0)
      Me.ugListasControl.Name = "ugListasControl"
      Me.ugListasControl.Size = New System.Drawing.Size(325, 351)
      Me.ugListasControl.TabIndex = 0
      Me.ugListasControl.Text = "Listas de Control para Asignar"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1, Me.tssListasControlAsignar})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 351)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(325, 22)
      Me.StatusStrip1.TabIndex = 2
      Me.StatusStrip1.Text = "statusStrip1"
      '
      'ToolStripStatusLabel1
      '
      Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
      Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(246, 17)
      Me.ToolStripStatusLabel1.Spring = True
      '
      'ToolStripProgressBar1
      '
      Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
      Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
      Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.ToolStripProgressBar1.Visible = False
      '
      'tssListasControlAsignar
      '
      Me.tssListasControlAsignar.Name = "tssListasControlAsignar"
      Me.tssListasControlAsignar.Size = New System.Drawing.Size(64, 17)
      Me.tssListasControlAsignar.Text = "0 Registros"
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.btnAgregar)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
      Me.Panel1.Location = New System.Drawing.Point(325, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(43, 373)
      Me.Panel1.TabIndex = 1
      '
      'btnAgregar
      '
      Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.add_24
      Me.btnAgregar.Location = New System.Drawing.Point(3, 135)
      Me.btnAgregar.Name = "btnAgregar"
      Me.btnAgregar.Size = New System.Drawing.Size(36, 36)
      Me.btnAgregar.TabIndex = 0
      Me.btnAgregar.UseVisualStyleBackColor = True
      '
      'ugProductoListasControl
      '
      Me.ugProductoListasControl.DataSource = Me.bdsProductosListasControl
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugProductoListasControl.DisplayLayout.Appearance = Appearance13
      Me.ugProductoListasControl.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      Me.ugProductoListasControl.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugProductoListasControl.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
      Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.ugProductoListasControl.DisplayLayout.GroupByBox.Appearance = Appearance14
      Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugProductoListasControl.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
      Me.ugProductoListasControl.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugProductoListasControl.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aqui para agrupar."
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance16.BackColor2 = System.Drawing.SystemColors.Control
      Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugProductoListasControl.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
      Me.ugProductoListasControl.DisplayLayout.MaxColScrollRegions = 1
      Me.ugProductoListasControl.DisplayLayout.MaxRowScrollRegions = 1
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugProductoListasControl.DisplayLayout.Override.ActiveCellAppearance = Appearance17
      Appearance18.BackColor = System.Drawing.SystemColors.Highlight
      Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugProductoListasControl.DisplayLayout.Override.ActiveRowAppearance = Appearance18
      Me.ugProductoListasControl.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugProductoListasControl.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Me.ugProductoListasControl.DisplayLayout.Override.CardAreaAppearance = Appearance19
      Appearance20.BorderColor = System.Drawing.Color.Silver
      Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugProductoListasControl.DisplayLayout.Override.CellAppearance = Appearance20
      Me.ugProductoListasControl.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.ugProductoListasControl.DisplayLayout.Override.CellPadding = 0
      Appearance21.BackColor = System.Drawing.SystemColors.Control
      Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance21.BorderColor = System.Drawing.SystemColors.Window
      Me.ugProductoListasControl.DisplayLayout.Override.GroupByRowAppearance = Appearance21
      Appearance22.TextHAlignAsString = "Left"
      Me.ugProductoListasControl.DisplayLayout.Override.HeaderAppearance = Appearance22
      Me.ugProductoListasControl.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugProductoListasControl.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance23.BackColor = System.Drawing.SystemColors.Window
      Appearance23.BorderColor = System.Drawing.Color.Silver
      Me.ugProductoListasControl.DisplayLayout.Override.RowAppearance = Appearance23
      Me.ugProductoListasControl.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugProductoListasControl.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
      Me.ugProductoListasControl.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugProductoListasControl.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugProductoListasControl.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugProductoListasControl.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugProductoListasControl.Location = New System.Drawing.Point(0, 0)
      Me.ugProductoListasControl.Name = "ugProductoListasControl"
      Me.ugProductoListasControl.Size = New System.Drawing.Size(388, 351)
      Me.ugProductoListasControl.TabIndex = 0
      Me.ugProductoListasControl.Text = "Listas de Control de la Plantilla"
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.ToolStripProgressBar2, Me.tssProductosListaControl})
      Me.stsStado.Location = New System.Drawing.Point(0, 351)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(388, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(309, 17)
      Me.tssInfo.Spring = True
      '
      'ToolStripProgressBar2
      '
      Me.ToolStripProgressBar2.Name = "ToolStripProgressBar2"
      Me.ToolStripProgressBar2.Size = New System.Drawing.Size(100, 16)
      Me.ToolStripProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.ToolStripProgressBar2.Visible = False
      '
      'tssProductosListaControl
      '
      Me.tssProductosListaControl.Name = "tssProductosListaControl"
      Me.tssProductosListaControl.Size = New System.Drawing.Size(64, 17)
      Me.tssProductosListaControl.Text = "0 Registros"
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.btnSacar)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
      Me.Panel2.Location = New System.Drawing.Point(388, 0)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(43, 373)
      Me.Panel2.TabIndex = 1
      '
      'btnSacar
      '
      Me.btnSacar.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.btnSacar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
      Me.btnSacar.Location = New System.Drawing.Point(3, 135)
      Me.btnSacar.Name = "btnSacar"
      Me.btnSacar.Size = New System.Drawing.Size(36, 36)
      Me.btnSacar.TabIndex = 0
      Me.btnSacar.UseVisualStyleBackColor = True
      '
      'PlantillasCalidadDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(824, 507)
      Me.Controls.Add(Me.spcDatos)
      Me.Controls.Add(Me.txtIdPlanilla)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "PlantillasCalidadDetalle"
      Me.Text = "Plantillas Listas de Control"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtIdPlanilla, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.spcDatos, 0)
      Me.spcDatos.Panel1.ResumeLayout(False)
      Me.spcDatos.Panel1.PerformLayout()
      Me.spcDatos.Panel2.ResumeLayout(False)
      Me.spcDatos.Panel2.PerformLayout()
      CType(Me.spcDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spcDatos.ResumeLayout(False)
      CType(Me.ugListasControl, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bdsListasControl, System.ComponentModel.ISupportInitialize).EndInit()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      CType(Me.ugProductoListasControl, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.bdsProductosListasControl, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtIdPlanilla As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents spcDatos As System.Windows.Forms.SplitContainer
   Friend WithEvents ugListasControl As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssListasControlAsignar As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents btnAgregar As Eniac.Controles.Button
   Friend WithEvents ugProductoListasControl As Infragistics.Win.UltraWinGrid.UltraGrid
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents ToolStripProgressBar2 As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssProductosListaControl As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents btnSacar As Eniac.Controles.Button
   Friend WithEvents bdsListasControl As System.Windows.Forms.BindingSource
   Friend WithEvents bdsProductosListasControl As System.Windows.Forms.BindingSource
End Class
