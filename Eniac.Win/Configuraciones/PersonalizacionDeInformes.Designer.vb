<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PersonalizacionDeInformes
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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdInforme")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreInforme")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreArchivo")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Embebido")
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
      Me.grbAgregar = New System.Windows.Forms.GroupBox()
      Me.txtArchivoAImprimir = New Eniac.Controles.TextBox()
      Me.lblArchivoAImprimir = New Eniac.Controles.Label()
      Me.chbArchivoEmbebido = New Eniac.Controles.CheckBox()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.cmbInforme = New Eniac.Controles.ComboBox()
      Me.lblInforme = New Eniac.Controles.Label()
      Me.tspFacturacion = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ugPersonalizacionInformes = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.grbAgregar.SuspendLayout()
      Me.tspFacturacion.SuspendLayout()
      CType(Me.ugPersonalizacionInformes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbAgregar
      '
      Me.grbAgregar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbAgregar.Controls.Add(Me.txtArchivoAImprimir)
      Me.grbAgregar.Controls.Add(Me.lblArchivoAImprimir)
      Me.grbAgregar.Controls.Add(Me.chbArchivoEmbebido)
      Me.grbAgregar.Controls.Add(Me.btnEliminar)
      Me.grbAgregar.Controls.Add(Me.btnInsertar)
      Me.grbAgregar.Controls.Add(Me.cmbInforme)
      Me.grbAgregar.Controls.Add(Me.lblInforme)
      Me.grbAgregar.Location = New System.Drawing.Point(12, 28)
      Me.grbAgregar.Name = "grbAgregar"
      Me.grbAgregar.Size = New System.Drawing.Size(746, 63)
      Me.grbAgregar.TabIndex = 0
      Me.grbAgregar.TabStop = False
      '
      'txtArchivoAImprimir
      '
      Me.txtArchivoAImprimir.BindearPropiedadControl = Nothing
      Me.txtArchivoAImprimir.BindearPropiedadEntidad = Nothing
      Me.txtArchivoAImprimir.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoAImprimir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoAImprimir.Formato = ""
      Me.txtArchivoAImprimir.IsDecimal = False
      Me.txtArchivoAImprimir.IsNumber = False
      Me.txtArchivoAImprimir.IsPK = False
      Me.txtArchivoAImprimir.IsRequired = False
      Me.txtArchivoAImprimir.Key = ""
      Me.txtArchivoAImprimir.LabelAsoc = Me.lblArchivoAImprimir
      Me.txtArchivoAImprimir.Location = New System.Drawing.Point(266, 28)
      Me.txtArchivoAImprimir.MaxLength = 100
      Me.txtArchivoAImprimir.Name = "txtArchivoAImprimir"
      Me.txtArchivoAImprimir.Size = New System.Drawing.Size(307, 20)
      Me.txtArchivoAImprimir.TabIndex = 4
      '
      'lblArchivoAImprimir
      '
      Me.lblArchivoAImprimir.AutoSize = True
      Me.lblArchivoAImprimir.LabelAsoc = Nothing
      Me.lblArchivoAImprimir.Location = New System.Drawing.Point(263, 14)
      Me.lblArchivoAImprimir.Name = "lblArchivoAImprimir"
      Me.lblArchivoAImprimir.Size = New System.Drawing.Size(90, 13)
      Me.lblArchivoAImprimir.TabIndex = 5
      Me.lblArchivoAImprimir.Text = "Archivo a Imprimir"
      '
      'chbArchivoEmbebido
      '
      Me.chbArchivoEmbebido.AutoSize = True
      Me.chbArchivoEmbebido.BindearPropiedadControl = Nothing
      Me.chbArchivoEmbebido.BindearPropiedadEntidad = Nothing
      Me.chbArchivoEmbebido.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbArchivoEmbebido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbArchivoEmbebido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbArchivoEmbebido.IsPK = False
      Me.chbArchivoEmbebido.IsRequired = False
      Me.chbArchivoEmbebido.Key = Nothing
      Me.chbArchivoEmbebido.LabelAsoc = Nothing
      Me.chbArchivoEmbebido.Location = New System.Drawing.Point(579, 29)
      Me.chbArchivoEmbebido.Name = "chbArchivoEmbebido"
      Me.chbArchivoEmbebido.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.chbArchivoEmbebido.Size = New System.Drawing.Size(73, 17)
      Me.chbArchivoEmbebido.TabIndex = 6
      Me.chbArchivoEmbebido.Text = "Embebido"
      Me.chbArchivoEmbebido.UseVisualStyleBackColor = True
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.btnEliminar.Location = New System.Drawing.Point(697, 19)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 19
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnInsertar.Location = New System.Drawing.Point(654, 19)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 18
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'cmbInforme
      '
      Me.cmbInforme.BindearPropiedadControl = Nothing
      Me.cmbInforme.BindearPropiedadEntidad = Nothing
      Me.cmbInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbInforme.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbInforme.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbInforme.FormattingEnabled = True
      Me.cmbInforme.IsPK = False
      Me.cmbInforme.IsRequired = False
      Me.cmbInforme.Key = Nothing
      Me.cmbInforme.LabelAsoc = Me.lblInforme
      Me.cmbInforme.Location = New System.Drawing.Point(14, 27)
      Me.cmbInforme.Name = "cmbInforme"
      Me.cmbInforme.Size = New System.Drawing.Size(246, 21)
      Me.cmbInforme.TabIndex = 0
      '
      'lblInforme
      '
      Me.lblInforme.AutoSize = True
      Me.lblInforme.LabelAsoc = Nothing
      Me.lblInforme.Location = New System.Drawing.Point(11, 14)
      Me.lblInforme.Name = "lblInforme"
      Me.lblInforme.Size = New System.Drawing.Size(42, 13)
      Me.lblInforme.TabIndex = 1
      Me.lblInforme.Text = "Informe"
      '
      'tspFacturacion
      '
      Me.tspFacturacion.AllowItemReorder = True
      Me.tspFacturacion.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tspFacturacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tspFacturacion.Location = New System.Drawing.Point(0, 0)
      Me.tspFacturacion.Name = "tspFacturacion"
      Me.tspFacturacion.Size = New System.Drawing.Size(763, 29)
      Me.tspFacturacion.TabIndex = 2
      Me.tspFacturacion.Text = "ToolStrip1"
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      '
      'ugPersonalizacionInformes
      '
      Me.ugPersonalizacionInformes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugPersonalizacionInformes.DisplayLayout.Appearance = Appearance1
      Me.ugPersonalizacionInformes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Informe"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 238
      UltraGridColumn3.Header.Caption = "Archivo a Imprimir"
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 441
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn4.Width = 62
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
      Me.ugPersonalizacionInformes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugPersonalizacionInformes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugPersonalizacionInformes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugPersonalizacionInformes.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugPersonalizacionInformes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugPersonalizacionInformes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugPersonalizacionInformes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugPersonalizacionInformes.DisplayLayout.MaxColScrollRegions = 1
      Me.ugPersonalizacionInformes.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugPersonalizacionInformes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugPersonalizacionInformes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugPersonalizacionInformes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugPersonalizacionInformes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugPersonalizacionInformes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugPersonalizacionInformes.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugPersonalizacionInformes.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugPersonalizacionInformes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugPersonalizacionInformes.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugPersonalizacionInformes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugPersonalizacionInformes.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugPersonalizacionInformes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugPersonalizacionInformes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugPersonalizacionInformes.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugPersonalizacionInformes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugPersonalizacionInformes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugPersonalizacionInformes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugPersonalizacionInformes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugPersonalizacionInformes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugPersonalizacionInformes.Location = New System.Drawing.Point(12, 97)
      Me.ugPersonalizacionInformes.Name = "ugPersonalizacionInformes"
      Me.ugPersonalizacionInformes.Size = New System.Drawing.Size(746, 265)
      Me.ugPersonalizacionInformes.TabIndex = 3
      Me.ugPersonalizacionInformes.Text = "UltraGrid1"
      '
      'PersonalizacionDeInformes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(763, 366)
      Me.Controls.Add(Me.ugPersonalizacionInformes)
      Me.Controls.Add(Me.tspFacturacion)
      Me.Controls.Add(Me.grbAgregar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PersonalizacionDeInformes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Personalización de Informes"
      Me.grbAgregar.ResumeLayout(False)
      Me.grbAgregar.PerformLayout()
      Me.tspFacturacion.ResumeLayout(False)
      Me.tspFacturacion.PerformLayout()
      CType(Me.ugPersonalizacionInformes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbAgregar As System.Windows.Forms.GroupBox
   Friend WithEvents tspFacturacion As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbInforme As Eniac.Controles.ComboBox
   Friend WithEvents lblInforme As Eniac.Controles.Label
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents chbArchivoEmbebido As Eniac.Controles.CheckBox
   Friend WithEvents txtArchivoAImprimir As Eniac.Controles.TextBox
   Friend WithEvents lblArchivoAImprimir As Eniac.Controles.Label
   Friend WithEvents ugPersonalizacionInformes As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
