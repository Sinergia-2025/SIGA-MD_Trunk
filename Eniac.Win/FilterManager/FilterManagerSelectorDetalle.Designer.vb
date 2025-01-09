Namespace FilterManager
   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class FilterManagerSelectorDetalle
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FilterManagerSelectorDetalle))
         Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
         Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
         Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Seleccionado")
         Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FilterControlName")
         Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Etiqueta")
         Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FilterText")
         Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
         Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FilterValue")
         Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DataType")
         Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
         Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Filtro")
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
         Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
         Me.Panel1 = New System.Windows.Forms.Panel()
         Me.btnCancelar = New System.Windows.Forms.Button()
         Me.btnAceptar = New System.Windows.Forms.Button()
         Me.lblNombre = New Eniac.Controles.Label()
         Me.txtNombre = New Eniac.Controles.TextBox()
         Me.cmbSucursal = New Eniac.Controles.ComboBox()
         Me.lblSucursal = New Eniac.Controles.Label()
         Me.cmbUsuario = New Eniac.Controles.ComboBox()
         Me.lblUsuario = New Eniac.Controles.Label()
         Me.ugFiltros = New Infragistics.Win.UltraWinGrid.UltraGrid()
         Me.Panel2 = New System.Windows.Forms.Panel()
         Me.Panel1.SuspendLayout()
         CType(Me.ugFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.Panel2.SuspendLayout()
         Me.SuspendLayout()
         '
         'imageList1
         '
         Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
         Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
         Me.imageList1.Images.SetKeyName(0, "check2.ico")
         Me.imageList1.Images.SetKeyName(1, "delete2.ico")
         Me.imageList1.Images.SetKeyName(2, "navigate_down.ico")
         '
         'Panel1
         '
         Me.Panel1.AutoSize = True
         Me.Panel1.Controls.Add(Me.btnCancelar)
         Me.Panel1.Controls.Add(Me.btnAceptar)
         Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
         Me.Panel1.Location = New System.Drawing.Point(0, 416)
         Me.Panel1.Name = "Panel1"
         Me.Panel1.Size = New System.Drawing.Size(586, 36)
         Me.Panel1.TabIndex = 2
         '
         'btnCancelar
         '
         Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
         Me.btnCancelar.ImageIndex = 1
         Me.btnCancelar.ImageList = Me.imageList1
         Me.btnCancelar.Location = New System.Drawing.Point(506, 3)
         Me.btnCancelar.Name = "btnCancelar"
         Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
         Me.btnCancelar.TabIndex = 1
         Me.btnCancelar.Text = "&Cancelar"
         Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         Me.btnCancelar.UseVisualStyleBackColor = True
         '
         'btnAceptar
         '
         Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
         Me.btnAceptar.ImageIndex = 0
         Me.btnAceptar.ImageList = Me.imageList1
         Me.btnAceptar.Location = New System.Drawing.Point(420, 3)
         Me.btnAceptar.Name = "btnAceptar"
         Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
         Me.btnAceptar.TabIndex = 0
         Me.btnAceptar.Text = "&Aceptar"
         Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         Me.btnAceptar.UseVisualStyleBackColor = True
         '
         'lblNombre
         '
         Me.lblNombre.AutoSize = True
         Me.lblNombre.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me.lblNombre.LabelAsoc = Nothing
         Me.lblNombre.Location = New System.Drawing.Point(12, 6)
         Me.lblNombre.Name = "lblNombre"
         Me.lblNombre.Size = New System.Drawing.Size(69, 13)
         Me.lblNombre.TabIndex = 0
         Me.lblNombre.Text = "Nombre Filtro"
         '
         'txtNombre
         '
         Me.txtNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtNombre.BindearPropiedadControl = Nothing
         Me.txtNombre.BindearPropiedadEntidad = Nothing
         Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
         Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
         Me.txtNombre.Formato = ""
         Me.txtNombre.IsDecimal = False
         Me.txtNombre.IsNumber = False
         Me.txtNombre.IsPK = False
         Me.txtNombre.IsRequired = False
         Me.txtNombre.Key = ""
         Me.txtNombre.LabelAsoc = Me.lblNombre
         Me.txtNombre.Location = New System.Drawing.Point(84, 3)
         Me.txtNombre.MaxLength = 100
         Me.txtNombre.Name = "txtNombre"
         Me.txtNombre.Size = New System.Drawing.Size(490, 20)
         Me.txtNombre.TabIndex = 1
         '
         'cmbSucursal
         '
         Me.cmbSucursal.BindearPropiedadControl = Nothing
         Me.cmbSucursal.BindearPropiedadEntidad = Nothing
         Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
         Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
         Me.cmbSucursal.FormattingEnabled = True
         Me.cmbSucursal.IsPK = False
         Me.cmbSucursal.IsRequired = False
         Me.cmbSucursal.Key = Nothing
         Me.cmbSucursal.LabelAsoc = Me.lblSucursal
         Me.cmbSucursal.Location = New System.Drawing.Point(437, 29)
         Me.cmbSucursal.Name = "cmbSucursal"
         Me.cmbSucursal.Size = New System.Drawing.Size(137, 21)
         Me.cmbSucursal.TabIndex = 5
         '
         'lblSucursal
         '
         Me.lblSucursal.AutoSize = True
         Me.lblSucursal.LabelAsoc = Nothing
         Me.lblSucursal.Location = New System.Drawing.Point(383, 34)
         Me.lblSucursal.Name = "lblSucursal"
         Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
         Me.lblSucursal.TabIndex = 4
         Me.lblSucursal.Text = "Sucursal"
         '
         'cmbUsuario
         '
         Me.cmbUsuario.BindearPropiedadControl = Nothing
         Me.cmbUsuario.BindearPropiedadEntidad = Nothing
         Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
         Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
         Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
         Me.cmbUsuario.FormattingEnabled = True
         Me.cmbUsuario.IsPK = False
         Me.cmbUsuario.IsRequired = False
         Me.cmbUsuario.Key = Nothing
         Me.cmbUsuario.LabelAsoc = Me.lblUsuario
         Me.cmbUsuario.Location = New System.Drawing.Point(84, 29)
         Me.cmbUsuario.Name = "cmbUsuario"
         Me.cmbUsuario.Size = New System.Drawing.Size(137, 21)
         Me.cmbUsuario.TabIndex = 3
         '
         'lblUsuario
         '
         Me.lblUsuario.AutoSize = True
         Me.lblUsuario.LabelAsoc = Nothing
         Me.lblUsuario.Location = New System.Drawing.Point(12, 34)
         Me.lblUsuario.Name = "lblUsuario"
         Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
         Me.lblUsuario.TabIndex = 2
         Me.lblUsuario.Text = "Usuario"
         '
         'ugFiltros
         '
         Appearance1.BackColor = System.Drawing.SystemColors.Window
         Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
         Me.ugFiltros.DisplayLayout.Appearance = Appearance1
         UltraGridColumn6.Header.Caption = ""
         UltraGridColumn6.Header.VisiblePosition = 0
         UltraGridColumn6.MaxWidth = 50
         UltraGridColumn6.MinWidth = 50
         UltraGridColumn6.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
         UltraGridColumn6.Width = 50
         UltraGridColumn1.Header.Caption = "Nombre Control"
         UltraGridColumn1.Header.VisiblePosition = 1
         UltraGridColumn2.Header.VisiblePosition = 2
         UltraGridColumn2.Width = 163
         Appearance2.TextHAlignAsString = "Center"
         UltraGridColumn3.CellAppearance = Appearance2
         UltraGridColumn3.Header.Caption = "Valor"
         UltraGridColumn3.Header.VisiblePosition = 3
         UltraGridColumn3.Width = 177
         UltraGridColumn4.Header.VisiblePosition = 4
         UltraGridColumn4.Hidden = True
         Appearance3.TextHAlignAsString = "Center"
         UltraGridColumn5.CellAppearance = Appearance3
         UltraGridColumn5.Header.Caption = "Tipo"
         UltraGridColumn5.Header.VisiblePosition = 5
         UltraGridColumn5.Width = 85
         UltraGridColumn7.Header.VisiblePosition = 6
         UltraGridColumn7.Hidden = True
         UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn6, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn7})
         Me.ugFiltros.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
         Me.ugFiltros.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
         Me.ugFiltros.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
         Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
         Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
         Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
         Appearance4.BorderColor = System.Drawing.SystemColors.Window
         Me.ugFiltros.DisplayLayout.GroupByBox.Appearance = Appearance4
         Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
         Me.ugFiltros.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
         Me.ugFiltros.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
         Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
         Appearance6.BackColor2 = System.Drawing.SystemColors.Control
         Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
         Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
         Me.ugFiltros.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
         Me.ugFiltros.DisplayLayout.MaxColScrollRegions = 1
         Me.ugFiltros.DisplayLayout.MaxRowScrollRegions = 1
         Appearance7.BackColor = System.Drawing.SystemColors.Window
         Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
         Me.ugFiltros.DisplayLayout.Override.ActiveCellAppearance = Appearance7
         Appearance8.BackColor = System.Drawing.SystemColors.Highlight
         Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
         Me.ugFiltros.DisplayLayout.Override.ActiveRowAppearance = Appearance8
         Me.ugFiltros.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
         Me.ugFiltros.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
         Appearance9.BackColor = System.Drawing.SystemColors.Window
         Me.ugFiltros.DisplayLayout.Override.CardAreaAppearance = Appearance9
         Appearance10.BorderColor = System.Drawing.Color.Silver
         Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
         Me.ugFiltros.DisplayLayout.Override.CellAppearance = Appearance10
         Me.ugFiltros.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
         Me.ugFiltros.DisplayLayout.Override.CellPadding = 0
         Appearance11.BackColor = System.Drawing.SystemColors.Control
         Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
         Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
         Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
         Appearance11.BorderColor = System.Drawing.SystemColors.Window
         Me.ugFiltros.DisplayLayout.Override.GroupByRowAppearance = Appearance11
         Appearance12.TextHAlignAsString = "Left"
         Me.ugFiltros.DisplayLayout.Override.HeaderAppearance = Appearance12
         Me.ugFiltros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
         Me.ugFiltros.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
         Appearance13.BackColor = System.Drawing.SystemColors.Window
         Appearance13.BorderColor = System.Drawing.Color.Silver
         Me.ugFiltros.DisplayLayout.Override.RowAppearance = Appearance13
         Me.ugFiltros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
         Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
         Me.ugFiltros.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
         Me.ugFiltros.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
         Me.ugFiltros.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
         Me.ugFiltros.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
         Me.ugFiltros.Dock = System.Windows.Forms.DockStyle.Fill
         Me.ugFiltros.Location = New System.Drawing.Point(0, 56)
         Me.ugFiltros.Name = "ugFiltros"
         Me.ugFiltros.Size = New System.Drawing.Size(586, 360)
         Me.ugFiltros.TabIndex = 1
         Me.ugFiltros.Text = "UltraGrid1"
         '
         'Panel2
         '
         Me.Panel2.Controls.Add(Me.lblNombre)
         Me.Panel2.Controls.Add(Me.txtNombre)
         Me.Panel2.Controls.Add(Me.cmbUsuario)
         Me.Panel2.Controls.Add(Me.lblSucursal)
         Me.Panel2.Controls.Add(Me.lblUsuario)
         Me.Panel2.Controls.Add(Me.cmbSucursal)
         Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
         Me.Panel2.Location = New System.Drawing.Point(0, 0)
         Me.Panel2.Name = "Panel2"
         Me.Panel2.Size = New System.Drawing.Size(586, 56)
         Me.Panel2.TabIndex = 0
         '
         'FilterManagerSelectorDetalle
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(586, 452)
         Me.Controls.Add(Me.ugFiltros)
         Me.Controls.Add(Me.Panel2)
         Me.Controls.Add(Me.Panel1)
         Me.Name = "FilterManagerSelectorDetalle"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Nuevo Filtro"
         Me.Panel1.ResumeLayout(False)
         CType(Me.ugFiltros, System.ComponentModel.ISupportInitialize).EndInit()
         Me.Panel2.ResumeLayout(False)
         Me.Panel2.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
      Private WithEvents imageList1 As System.Windows.Forms.ImageList
      Friend WithEvents Panel1 As System.Windows.Forms.Panel
      Protected WithEvents btnCancelar As System.Windows.Forms.Button
      Protected WithEvents btnAceptar As System.Windows.Forms.Button
      Friend WithEvents lblNombre As Eniac.Controles.Label
      Friend WithEvents txtNombre As Eniac.Controles.TextBox
      Friend WithEvents cmbSucursal As Eniac.Controles.ComboBox
      Friend WithEvents lblSucursal As Eniac.Controles.Label
      Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
      Friend WithEvents lblUsuario As Eniac.Controles.Label
      Friend WithEvents ugFiltros As Infragistics.Win.UltraWinGrid.UltraGrid
      Friend WithEvents Panel2 As System.Windows.Forms.Panel
   End Class
End Namespace