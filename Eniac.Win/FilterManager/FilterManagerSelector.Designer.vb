Namespace FilterManager
   <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
   Partial Class FilterManagerSelector
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FilterManagerSelector))
            Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
            Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFiltro")
            Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreFiltro")
            Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorDefectoResuelto")
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
            Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.btnAceptar = New System.Windows.Forms.Button()
            Me.btnCancelar = New System.Windows.Forms.Button()
            Me.ugFiltros = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.txtTitulo = New System.Windows.Forms.ToolStripTextBox()
            Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.tstBarra = New System.Windows.Forms.ToolStrip()
            Me.mnuRefrescar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuNuevo = New System.Windows.Forms.ToolStripButton()
            Me.mnuEliminar = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
            Me.tsbCambiarDefault = New System.Windows.Forms.ToolStripDropDownButton()
            Me.mnuCambiarSoloUsuario = New System.Windows.Forms.ToolStripMenuItem()
            Me.mnuCambiarTodosLosUsuario = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
            Me.mnuEliminarFiltroDefectoUsuario = New System.Windows.Forms.ToolStripMenuItem()
            CType(Me.ugFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.ctxMenu.SuspendLayout()
            Me.tstBarra.SuspendLayout()
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
            'btnAceptar
            '
            Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAceptar.ImageIndex = 0
            Me.btnAceptar.ImageList = Me.imageList1
            Me.btnAceptar.Location = New System.Drawing.Point(355, 3)
            Me.btnAceptar.Name = "btnAceptar"
            Me.btnAceptar.Size = New System.Drawing.Size(89, 30)
            Me.btnAceptar.TabIndex = 5
            Me.btnAceptar.Text = "&Aplicar Filtro"
            Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnAceptar.UseVisualStyleBackColor = True
            '
            'btnCancelar
            '
            Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnCancelar.ImageIndex = 1
            Me.btnCancelar.ImageList = Me.imageList1
            Me.btnCancelar.Location = New System.Drawing.Point(450, 3)
            Me.btnCancelar.Name = "btnCancelar"
            Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
            Me.btnCancelar.TabIndex = 4
            Me.btnCancelar.Text = "&Cancelar"
            Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnCancelar.UseVisualStyleBackColor = True
            '
            'ugFiltros
            '
            Appearance1.BackColor = System.Drawing.SystemColors.Window
            Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
            Me.ugFiltros.DisplayLayout.Appearance = Appearance1
            Me.ugFiltros.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            Appearance2.TextHAlignAsString = "Right"
            UltraGridColumn1.CellAppearance = Appearance2
            UltraGridColumn1.Header.Caption = "Código"
            UltraGridColumn1.Header.VisiblePosition = 0
            UltraGridColumn1.MaxWidth = 60
            UltraGridColumn1.MinWidth = 60
            UltraGridColumn1.Width = 60
            UltraGridColumn2.Header.Caption = "Filtro"
            UltraGridColumn2.Header.VisiblePosition = 1
            UltraGridColumn2.Width = 368
            Appearance3.TextHAlignAsString = "Center"
            UltraGridColumn3.CellAppearance = Appearance3
            UltraGridColumn3.Header.Caption = ""
            UltraGridColumn3.Header.VisiblePosition = 2
            UltraGridColumn3.MaxWidth = 100
            UltraGridColumn3.MinWidth = 100
            UltraGridColumn3.Width = 100
            UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
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
            Me.ugFiltros.DisplayLayout.MaxBandDepth = 1
            Me.ugFiltros.DisplayLayout.MaxColScrollRegions = 1
            Me.ugFiltros.DisplayLayout.MaxRowScrollRegions = 1
            Appearance7.BackColor = System.Drawing.SystemColors.Window
            Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
            Me.ugFiltros.DisplayLayout.Override.ActiveCellAppearance = Appearance7
            Appearance8.BackColor = System.Drawing.SystemColors.Highlight
            Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
            Me.ugFiltros.DisplayLayout.Override.ActiveRowAppearance = Appearance8
            Me.ugFiltros.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
            Me.ugFiltros.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
            Me.ugFiltros.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
            Me.ugFiltros.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
            Me.ugFiltros.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
            Appearance9.BackColor = System.Drawing.SystemColors.Window
            Me.ugFiltros.DisplayLayout.Override.CardAreaAppearance = Appearance9
            Appearance10.BorderColor = System.Drawing.Color.Silver
            Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
            Me.ugFiltros.DisplayLayout.Override.CellAppearance = Appearance10
            Me.ugFiltros.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
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
            Me.ugFiltros.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ugFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ugFiltros.Location = New System.Drawing.Point(0, 29)
            Me.ugFiltros.Name = "ugFiltros"
            Me.ugFiltros.Size = New System.Drawing.Size(530, 344)
            Me.ugFiltros.TabIndex = 6
            Me.ugFiltros.Text = "UltraGrid1"
            '
            'Panel1
            '
            Me.Panel1.AutoSize = True
            Me.Panel1.Controls.Add(Me.btnCancelar)
            Me.Panel1.Controls.Add(Me.btnAceptar)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 373)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(530, 36)
            Me.Panel1.TabIndex = 7
            '
            'ctxMenu
            '
            Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtTitulo, Me.ToolStripSeparator1})
            Me.ctxMenu.Name = "ctxMenu"
            Me.ctxMenu.Size = New System.Drawing.Size(261, 35)
            '
            'txtTitulo
            '
            Me.txtTitulo.AutoSize = False
            Me.txtTitulo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.txtTitulo.Name = "txtTitulo"
            Me.txtTitulo.ReadOnly = True
            Me.txtTitulo.Size = New System.Drawing.Size(200, 23)
            Me.txtTitulo.Text = "Cambiar filtro por defecto"
            '
            'ToolStripSeparator1
            '
            Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
            Me.ToolStripSeparator1.Size = New System.Drawing.Size(257, 6)
            '
            'tstBarra
            '
            Me.tstBarra.AllowItemReorder = True
            Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
            Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRefrescar, Me.ToolStripSeparator2, Me.mnuNuevo, Me.mnuEliminar, Me.ToolStripSeparator4, Me.tsbCambiarDefault})
            Me.tstBarra.Location = New System.Drawing.Point(0, 0)
            Me.tstBarra.Name = "tstBarra"
            Me.tstBarra.Size = New System.Drawing.Size(530, 29)
            Me.tstBarra.TabIndex = 8
            Me.tstBarra.Text = "toolStrip1"
            '
            'mnuRefrescar
            '
            Me.mnuRefrescar.Image = CType(resources.GetObject("mnuRefrescar.Image"), System.Drawing.Image)
            Me.mnuRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuRefrescar.Name = "mnuRefrescar"
            Me.mnuRefrescar.Size = New System.Drawing.Size(104, 26)
            Me.mnuRefrescar.Text = "&Refrescar (F5)"
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
            '
            'mnuNuevo
            '
            Me.mnuNuevo.Image = Global.Eniac.Win.My.Resources.Resources.add_24
            Me.mnuNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuNuevo.Name = "mnuNuevo"
            Me.mnuNuevo.Size = New System.Drawing.Size(68, 26)
            Me.mnuNuevo.Text = "&Nuevo"
            '
            'mnuEliminar
            '
            Me.mnuEliminar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
            Me.mnuEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.mnuEliminar.Name = "mnuEliminar"
            Me.mnuEliminar.Size = New System.Drawing.Size(76, 26)
            Me.mnuEliminar.Text = "Eliminar"
            '
            'ToolStripSeparator4
            '
            Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
            Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
            '
            'tsbCambiarDefault
            '
            Me.tsbCambiarDefault.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCambiarSoloUsuario, Me.mnuCambiarTodosLosUsuario, Me.ToolStripSeparator3, Me.mnuEliminarFiltroDefectoUsuario})
            Me.tsbCambiarDefault.Image = Global.Eniac.Win.My.Resources.Resources.box_next
            Me.tsbCambiarDefault.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.tsbCambiarDefault.Name = "tsbCambiarDefault"
            Me.tsbCambiarDefault.Size = New System.Drawing.Size(184, 26)
            Me.tsbCambiarDefault.Text = "&Cambiar filtros por defecto"
            '
            'mnuCambiarSoloUsuario
            '
            Me.mnuCambiarSoloUsuario.Image = Global.Eniac.Win.My.Resources.Resources.user1
            Me.mnuCambiarSoloUsuario.Name = "mnuCambiarSoloUsuario"
            Me.mnuCambiarSoloUsuario.Size = New System.Drawing.Size(243, 22)
            Me.mnuCambiarSoloUsuario.Text = "&Cambiar solo para mi"
            '
            'mnuCambiarTodosLosUsuario
            '
            Me.mnuCambiarTodosLosUsuario.Image = Global.Eniac.Win.My.Resources.Resources.businessmen
            Me.mnuCambiarTodosLosUsuario.Name = "mnuCambiarTodosLosUsuario"
            Me.mnuCambiarTodosLosUsuario.Size = New System.Drawing.Size(243, 22)
            Me.mnuCambiarTodosLosUsuario.Text = "Cambiar para &todos los usuarios"
            '
            'ToolStripSeparator3
            '
            Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
            Me.ToolStripSeparator3.Size = New System.Drawing.Size(240, 6)
            '
            'mnuEliminarFiltroDefectoUsuario
            '
            Me.mnuEliminarFiltroDefectoUsuario.Image = Global.Eniac.Win.My.Resources.Resources.brush3
            Me.mnuEliminarFiltroDefectoUsuario.Name = "mnuEliminarFiltroDefectoUsuario"
            Me.mnuEliminarFiltroDefectoUsuario.Size = New System.Drawing.Size(243, 22)
            Me.mnuEliminarFiltroDefectoUsuario.Text = "&Eliminar filtro por defecto"
            '
            'FilterManagerSelector
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(530, 409)
            Me.Controls.Add(Me.ugFiltros)
            Me.Controls.Add(Me.tstBarra)
            Me.Controls.Add(Me.Panel1)
            Me.Name = "FilterManagerSelector"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Seleccione filtro a aplicar"
            CType(Me.ugFiltros, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.ctxMenu.ResumeLayout(False)
            Me.ctxMenu.PerformLayout()
            Me.tstBarra.ResumeLayout(False)
            Me.tstBarra.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Private WithEvents imageList1 As System.Windows.Forms.ImageList
      Protected WithEvents btnAceptar As System.Windows.Forms.Button
      Protected WithEvents btnCancelar As System.Windows.Forms.Button
      Friend WithEvents ugFiltros As Infragistics.Win.UltraWinGrid.UltraGrid
      Friend WithEvents Panel1 As System.Windows.Forms.Panel
      Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
      Friend WithEvents txtTitulo As System.Windows.Forms.ToolStripTextBox
      Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
      Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
      Public WithEvents mnuRefrescar As System.Windows.Forms.ToolStripButton
      Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
      Friend WithEvents tsbCambiarDefault As System.Windows.Forms.ToolStripDropDownButton
      Friend WithEvents mnuCambiarSoloUsuario As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents mnuCambiarTodosLosUsuario As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
      Friend WithEvents mnuEliminarFiltroDefectoUsuario As System.Windows.Forms.ToolStripMenuItem
      Friend WithEvents mnuNuevo As System.Windows.Forms.ToolStripButton
      Friend WithEvents mnuEliminar As System.Windows.Forms.ToolStripButton
   End Class
End Namespace