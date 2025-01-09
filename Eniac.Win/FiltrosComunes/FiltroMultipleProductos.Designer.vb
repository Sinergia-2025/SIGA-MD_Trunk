<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroMultipleProductos
   Inherits System.Windows.Forms.Form

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroMultipleProductos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idproducto")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("nombreproducto")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.ugbProductos = New Infragistics.Win.Misc.UltraGroupBox()
      Me.lnkLimpiarFiltros = New Eniac.Controles.LinkLabel()
      Me.lnkGrabarFiltro = New Eniac.Controles.LinkLabel()
      Me.lnkRecuperarUltimo = New Eniac.Controles.LinkLabel()
      Me.btnCerrar = New Eniac.Controles.Button()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.bscCodigoProducto = New Eniac.Controles.Buscador()
      Me.bscProducto = New Eniac.Controles.Buscador()
      Me.dgvProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      CType(Me.ugbProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ugbProductos.SuspendLayout()
      CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ugbProductos
      '
      Me.ugbProductos.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Center
      Me.ugbProductos.Controls.Add(Me.lnkLimpiarFiltros)
      Me.ugbProductos.Controls.Add(Me.lnkGrabarFiltro)
      Me.ugbProductos.Controls.Add(Me.lnkRecuperarUltimo)
      Me.ugbProductos.Controls.Add(Me.btnCerrar)
      Me.ugbProductos.Controls.Add(Me.btnEliminar)
      Me.ugbProductos.Controls.Add(Me.btnInsertar)
      Me.ugbProductos.Controls.Add(Me.bscCodigoProducto)
      Me.ugbProductos.Controls.Add(Me.bscProducto)
      Me.ugbProductos.Controls.Add(Me.dgvProductos)
      Me.ugbProductos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugbProductos.Location = New System.Drawing.Point(0, 0)
      Me.ugbProductos.Name = "ugbProductos"
      Me.ugbProductos.Size = New System.Drawing.Size(414, 315)
      Me.ugbProductos.TabIndex = 0
      Me.ugbProductos.Text = "Seleccione los Productos"
      '
      'lnkLimpiarFiltros
      '
      Me.lnkLimpiarFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lnkLimpiarFiltros.AutoSize = True
      Me.lnkLimpiarFiltros.Location = New System.Drawing.Point(235, 299)
      Me.lnkLimpiarFiltros.Name = "lnkLimpiarFiltros"
      Me.lnkLimpiarFiltros.Size = New System.Drawing.Size(67, 13)
      Me.lnkLimpiarFiltros.TabIndex = 8
      Me.lnkLimpiarFiltros.TabStop = True
      Me.lnkLimpiarFiltros.Text = "Limpiar filtros"
      '
      'lnkGrabarFiltro
      '
      Me.lnkGrabarFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lnkGrabarFiltro.AutoSize = True
      Me.lnkGrabarFiltro.Location = New System.Drawing.Point(135, 299)
      Me.lnkGrabarFiltro.Name = "lnkGrabarFiltro"
      Me.lnkGrabarFiltro.Size = New System.Drawing.Size(61, 13)
      Me.lnkGrabarFiltro.TabIndex = 7
      Me.lnkGrabarFiltro.TabStop = True
      Me.lnkGrabarFiltro.Text = "Grabar filtro"
      '
      'lnkRecuperarUltimo
      '
      Me.lnkRecuperarUltimo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lnkRecuperarUltimo.AutoSize = True
      Me.lnkRecuperarUltimo.Location = New System.Drawing.Point(6, 299)
      Me.lnkRecuperarUltimo.Name = "lnkRecuperarUltimo"
      Me.lnkRecuperarUltimo.Size = New System.Drawing.Size(79, 13)
      Me.lnkRecuperarUltimo.TabIndex = 6
      Me.lnkRecuperarUltimo.TabStop = True
      Me.lnkRecuperarUltimo.Text = "Recuperar filtro"
      '
      'btnCerrar
      '
      Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCerrar.Location = New System.Drawing.Point(318, 289)
      Me.btnCerrar.Name = "btnCerrar"
      Me.btnCerrar.Size = New System.Drawing.Size(90, 23)
      Me.btnCerrar.TabIndex = 5
      Me.btnCerrar.Text = "&Aceptar"
      Me.btnCerrar.UseVisualStyleBackColor = True
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
      Me.btnEliminar.Location = New System.Drawing.Point(371, 12)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 3
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
      Me.btnInsertar.Location = New System.Drawing.Point(334, 12)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 2
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'bscCodigoProducto
      '
      Me.bscCodigoProducto.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto.ColumnasAlineacion = Nothing
      Me.bscCodigoProducto.ColumnasAncho = Nothing
      Me.bscCodigoProducto.ColumnasFormato = Nothing
      Me.bscCodigoProducto.ColumnasOcultas = Nothing
      Me.bscCodigoProducto.ColumnasTitulos = Nothing
      Me.bscCodigoProducto.Datos = Nothing
      Me.bscCodigoProducto.FilaDevuelta = Nothing
      Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto.IsDecimal = False
      Me.bscCodigoProducto.IsNumber = False
      Me.bscCodigoProducto.IsPK = False
      Me.bscCodigoProducto.IsRequired = False
      Me.bscCodigoProducto.Key = ""
      Me.bscCodigoProducto.LabelAsoc = Nothing
      Me.bscCodigoProducto.Location = New System.Drawing.Point(12, 29)
      Me.bscCodigoProducto.Name = "bscCodigoProducto"
      Me.bscCodigoProducto.Selecciono = False
      Me.bscCodigoProducto.Size = New System.Drawing.Size(108, 20)
      Me.bscCodigoProducto.TabIndex = 0
      Me.bscCodigoProducto.Titulo = Nothing
      '
      'bscProducto
      '
      Me.bscProducto.BindearPropiedadControl = Nothing
      Me.bscProducto.BindearPropiedadEntidad = Nothing
      Me.bscProducto.ColumnasAlineacion = Nothing
      Me.bscProducto.ColumnasAncho = Nothing
      Me.bscProducto.ColumnasFormato = Nothing
      Me.bscProducto.ColumnasOcultas = Nothing
      Me.bscProducto.ColumnasTitulos = Nothing
      Me.bscProducto.Datos = Nothing
      Me.bscProducto.FilaDevuelta = Nothing
      Me.bscProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto.IsDecimal = False
      Me.bscProducto.IsNumber = False
      Me.bscProducto.IsPK = False
      Me.bscProducto.IsRequired = False
      Me.bscProducto.Key = ""
      Me.bscProducto.LabelAsoc = Nothing
      Me.bscProducto.Location = New System.Drawing.Point(126, 29)
      Me.bscProducto.Name = "bscProducto"
      Me.bscProducto.Selecciono = False
      Me.bscProducto.Size = New System.Drawing.Size(203, 20)
      Me.bscProducto.TabIndex = 1
      Me.bscProducto.Titulo = Nothing
      '
      'dgvProductos
      '
      Me.dgvProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dgvProductos.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn1.Header.Caption = "Cod. Prod."
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 113
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn2.Header.Caption = "Producto"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 274
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
      Me.dgvProductos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.dgvProductos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvProductos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance3.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvProductos.DisplayLayout.GroupByBox.Appearance = Appearance3
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvProductos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
      Me.dgvProductos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvProductos.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance5.BackColor2 = System.Drawing.SystemColors.Control
      Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvProductos.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
      Me.dgvProductos.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvProductos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance6.BackColor = System.Drawing.SystemColors.Window
      Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dgvProductos.DisplayLayout.Override.ActiveCellAppearance = Appearance6
      Appearance7.BackColor = System.Drawing.SystemColors.Highlight
      Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvProductos.DisplayLayout.Override.ActiveRowAppearance = Appearance7
      Me.dgvProductos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.dgvProductos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvProductos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvProductos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dgvProductos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance8.BackColor = System.Drawing.SystemColors.Window
      Me.dgvProductos.DisplayLayout.Override.CardAreaAppearance = Appearance8
      Appearance9.BorderColor = System.Drawing.Color.Silver
      Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dgvProductos.DisplayLayout.Override.CellAppearance = Appearance9
      Me.dgvProductos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dgvProductos.DisplayLayout.Override.CellPadding = 0
      Appearance10.BackColor = System.Drawing.SystemColors.Control
      Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance10.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvProductos.DisplayLayout.Override.GroupByRowAppearance = Appearance10
      Appearance18.TextHAlignAsString = "Left"
      Me.dgvProductos.DisplayLayout.Override.HeaderAppearance = Appearance18
      Me.dgvProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dgvProductos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Appearance19.BorderColor = System.Drawing.Color.Silver
      Me.dgvProductos.DisplayLayout.Override.RowAppearance = Appearance19
      Me.dgvProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dgvProductos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
      Me.dgvProductos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvProductos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgvProductos.Location = New System.Drawing.Point(0, 55)
      Me.dgvProductos.Name = "dgvProductos"
      Me.dgvProductos.Size = New System.Drawing.Size(414, 232)
      Me.dgvProductos.TabIndex = 4
      '
      'FiltroMultipleProductos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCerrar
      Me.ClientSize = New System.Drawing.Size(414, 315)
      Me.ControlBox = False
      Me.Controls.Add(Me.ugbProductos)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.Name = "FiltroMultipleProductos"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Productos"
      CType(Me.ugbProductos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ugbProductos.ResumeLayout(False)
      Me.ugbProductos.PerformLayout()
      CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ugbProductos As Infragistics.Win.Misc.UltraGroupBox
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents bscCodigoProducto As Eniac.Controles.Buscador
   Friend WithEvents bscProducto As Eniac.Controles.Buscador
   Friend WithEvents dgvProductos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnCerrar As Eniac.Controles.Button
   Friend WithEvents lnkRecuperarUltimo As Eniac.Controles.LinkLabel
   Friend WithEvents lnkGrabarFiltro As Eniac.Controles.LinkLabel
   Friend WithEvents lnkLimpiarFiltros As Eniac.Controles.LinkLabel
End Class
