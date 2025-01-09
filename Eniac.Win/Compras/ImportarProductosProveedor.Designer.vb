<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarProductosProveedor
    Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarProductosProveedor))
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.imgGrabar = New System.Windows.Forms.ImageList(Me.components)
      Me.lblEjemplo = New Eniac.Controles.Label()
      Me.txtRangoCeldas = New System.Windows.Forms.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.btnLeerExel = New Eniac.Controles.Button()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.chbLeeCodigoProveedor = New System.Windows.Forms.CheckBox()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.chbLeeCompra = New System.Windows.Forms.CheckBox()
      Me.chbLeeDescuentos = New System.Windows.Forms.CheckBox()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(889, 29)
      Me.tstBarra.TabIndex = 11
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbImportar
      '
      Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
      Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImportar.Name = "tsbImportar"
      Me.tsbImportar.Size = New System.Drawing.Size(79, 26)
      Me.tsbImportar.Text = "&Importar"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'btnExaminar
      '
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.ImageKey = "folder.ico"
      Me.btnExaminar.ImageList = Me.imgGrabar
      Me.btnExaminar.Location = New System.Drawing.Point(462, 36)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(91, 45)
      Me.btnExaminar.TabIndex = 2
      Me.btnExaminar.Text = "&Examinar..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      '
      'imgGrabar
      '
      Me.imgGrabar.ImageStream = CType(resources.GetObject("imgGrabar.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgGrabar.TransparentColor = System.Drawing.Color.Transparent
      Me.imgGrabar.Images.SetKeyName(0, "document_find.ico")
      Me.imgGrabar.Images.SetKeyName(1, "folder.ico")
      Me.imgGrabar.Images.SetKeyName(2, "row_add.ico")
      '
      'lblEjemplo
      '
      Me.lblEjemplo.AutoSize = True
      Me.lblEjemplo.Location = New System.Drawing.Point(631, 68)
      Me.lblEjemplo.Name = "lblEjemplo"
      Me.lblEjemplo.Size = New System.Drawing.Size(113, 13)
      Me.lblEjemplo.TabIndex = 5
      Me.lblEjemplo.Text = "Ejemplos:  [ A2 : I200 ]"
      '
      'txtRangoCeldas
      '
      Me.txtRangoCeldas.Location = New System.Drawing.Point(657, 45)
      Me.txtRangoCeldas.Name = "txtRangoCeldas"
      Me.txtRangoCeldas.Size = New System.Drawing.Size(106, 20)
      Me.txtRangoCeldas.TabIndex = 3
      Me.txtRangoCeldas.Text = "An : In"
      Me.txtRangoCeldas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(562, 49)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(94, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Rango de celdas :"
      '
      'txtArchivoOrigen
      '
      Me.txtArchivoOrigen.BindearPropiedadControl = "Text"
      Me.txtArchivoOrigen.BindearPropiedadEntidad = "CantidadProductos"
      Me.txtArchivoOrigen.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoOrigen.Formato = ""
      Me.txtArchivoOrigen.IsDecimal = False
      Me.txtArchivoOrigen.IsNumber = False
      Me.txtArchivoOrigen.IsPK = False
      Me.txtArchivoOrigen.IsRequired = False
      Me.txtArchivoOrigen.Key = ""
      Me.txtArchivoOrigen.LabelAsoc = Nothing
      Me.txtArchivoOrigen.Location = New System.Drawing.Point(15, 54)
      Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
      Me.txtArchivoOrigen.Size = New System.Drawing.Size(437, 20)
      Me.txtArchivoOrigen.TabIndex = 0
      '
      'lblArchivo
      '
      Me.lblArchivo.AutoSize = True
      Me.lblArchivo.Location = New System.Drawing.Point(15, 38)
      Me.lblArchivo.Name = "lblArchivo"
      Me.lblArchivo.Size = New System.Drawing.Size(46, 13)
      Me.lblArchivo.TabIndex = 1
      Me.lblArchivo.Text = "Archivo:"
      '
      'btnLeerExel
      '
      Me.btnLeerExel.Image = CType(resources.GetObject("btnLeerExel.Image"), System.Drawing.Image)
      Me.btnLeerExel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnLeerExel.Location = New System.Drawing.Point(769, 38)
      Me.btnLeerExel.Name = "btnLeerExel"
      Me.btnLeerExel.Size = New System.Drawing.Size(100, 45)
      Me.btnLeerExel.TabIndex = 8
      Me.btnLeerExel.Text = "Leer Excel"
      Me.btnLeerExel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnLeerExel.UseVisualStyleBackColor = True
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 380)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(889, 22)
      Me.StatusStrip1.TabIndex = 10
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(874, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'chbLeeCodigoProveedor
      '
      Me.chbLeeCodigoProveedor.AutoSize = True
      Me.chbLeeCodigoProveedor.Checked = True
      Me.chbLeeCodigoProveedor.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbLeeCodigoProveedor.Location = New System.Drawing.Point(111, 95)
      Me.chbLeeCodigoProveedor.Name = "chbLeeCodigoProveedor"
      Me.chbLeeCodigoProveedor.Size = New System.Drawing.Size(132, 17)
      Me.chbLeeCodigoProveedor.TabIndex = 6
      Me.chbLeeCodigoProveedor.Text = "Lee Código Proveedor"
      Me.chbLeeCodigoProveedor.UseVisualStyleBackColor = True
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
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
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
      Me.ugDetalle.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Location = New System.Drawing.Point(12, 118)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(868, 259)
      Me.ugDetalle.TabIndex = 12
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'chbLeeCompra
      '
      Me.chbLeeCompra.AutoSize = True
      Me.chbLeeCompra.Checked = True
      Me.chbLeeCompra.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbLeeCompra.Location = New System.Drawing.Point(314, 95)
      Me.chbLeeCompra.Name = "chbLeeCompra"
      Me.chbLeeCompra.Size = New System.Drawing.Size(116, 17)
      Me.chbLeeCompra.TabIndex = 7
      Me.chbLeeCompra.Text = "Lee Precio Compra"
      Me.chbLeeCompra.UseVisualStyleBackColor = True
      '
      'chbLeeDescuentos
      '
      Me.chbLeeDescuentos.AutoSize = True
      Me.chbLeeDescuentos.Checked = True
      Me.chbLeeDescuentos.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbLeeDescuentos.Location = New System.Drawing.Point(502, 95)
      Me.chbLeeDescuentos.Name = "chbLeeDescuentos"
      Me.chbLeeDescuentos.Size = New System.Drawing.Size(104, 17)
      Me.chbLeeDescuentos.TabIndex = 7
      Me.chbLeeDescuentos.Text = "Lee Descuentos"
      Me.chbLeeDescuentos.UseVisualStyleBackColor = True
      '
      'ImportarProductosProveedor
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(889, 402)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.chbLeeCodigoProveedor)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.chbLeeDescuentos)
      Me.Controls.Add(Me.chbLeeCompra)
      Me.Controls.Add(Me.btnExaminar)
      Me.Controls.Add(Me.lblEjemplo)
      Me.Controls.Add(Me.txtRangoCeldas)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtArchivoOrigen)
      Me.Controls.Add(Me.lblArchivo)
      Me.Controls.Add(Me.btnLeerExel)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "ImportarProductosProveedor"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Importar Productos del Proveedor"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Friend WithEvents lblEjemplo As Eniac.Controles.Label
   Friend WithEvents txtRangoCeldas As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtArchivoOrigen As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo As Eniac.Controles.Label
   Friend WithEvents btnLeerExel As Eniac.Controles.Button
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbLeeCodigoProveedor As System.Windows.Forms.CheckBox
   Friend WithEvents imgGrabar As System.Windows.Forms.ImageList
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbLeeCompra As System.Windows.Forms.CheckBox
   Friend WithEvents chbLeeDescuentos As System.Windows.Forms.CheckBox
End Class
