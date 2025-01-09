<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultarTablasAFIP
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
      Dim UltraTab6 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim UltraTab4 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim UltraTab5 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim UltraTab7 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim UltraTab8 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim UltraTab9 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.utsTablas = New Infragistics.Win.UltraWinTabControl.UltraTabStripControl()
      Me.utsDatos = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
      Me.ugdDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tstBarra.SuspendLayout()
      CType(Me.utsTablas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.utsTablas.SuspendLayout()
      Me.utsDatos.SuspendLayout()
      CType(Me.ugdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(962, 29)
      Me.tstBarra.TabIndex = 4
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
      'utsTablas
      '
      Me.utsTablas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.utsTablas.Controls.Add(Me.utsDatos)
      Me.utsTablas.Location = New System.Drawing.Point(12, 32)
      Me.utsTablas.Name = "utsTablas"
      Me.utsTablas.SharedControls.AddRange(New System.Windows.Forms.Control() {Me.ugdDatos})
      Me.utsTablas.SharedControlsPage = Me.utsDatos
      Me.utsTablas.Size = New System.Drawing.Size(938, 395)
      Me.utsTablas.TabIndex = 5
      Me.utsTablas.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.MultiRowAutoSize
      Me.utsTablas.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopLeft
      UltraTab6.Key = "TiposTributos"
      UltraTab6.Text = "Tipos Tributos"
      UltraTab1.Key = "TiposOpcionales"
      UltraTab1.Text = "Tipos Datos Opcionales"
      UltraTab2.Key = "TiposMonedas"
      UltraTab2.Text = "Tipos Monedas"
      UltraTab3.Key = "TiposAlicuotas"
      UltraTab3.Text = "Tipos Alicuotas"
      UltraTab4.Key = "TiposDocumentos"
      UltraTab4.Text = "Tipos Documentos"
      UltraTab5.Key = "TiposConceptos"
      UltraTab5.Text = "Tipos Conceptos"
      UltraTab7.Key = "TiposComprobantes"
      UltraTab7.Text = "Tipos Comprobantes"
      UltraTab8.Key = "PuntosVentas"
      UltraTab8.Text = "Puntos de Venta"
      UltraTab9.Key = "UnidadesDeMedidas"
      UltraTab9.Text = "UnidadesDeMedidas"
      Me.utsTablas.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab6, UltraTab1, UltraTab2, UltraTab3, UltraTab4, UltraTab5, UltraTab7, UltraTab8, UltraTab9})
      '
      'utsDatos
      '
      Me.utsDatos.Controls.Add(Me.ugdDatos)
      Me.utsDatos.Location = New System.Drawing.Point(1, 23)
      Me.utsDatos.Name = "utsDatos"
      Me.utsDatos.Size = New System.Drawing.Size(934, 369)
      '
      'ugdDatos
      '
      Appearance28.BackColor = System.Drawing.SystemColors.Window
      Appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugdDatos.DisplayLayout.Appearance = Appearance28
      Me.ugdDatos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugdDatos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance25.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance25.BorderColor = System.Drawing.SystemColors.Window
      Me.ugdDatos.DisplayLayout.GroupByBox.Appearance = Appearance25
      Appearance26.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugdDatos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance26
      Me.ugdDatos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance27.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance27.BackColor2 = System.Drawing.SystemColors.Control
      Appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugdDatos.DisplayLayout.GroupByBox.PromptAppearance = Appearance27
      Me.ugdDatos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugdDatos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance36.BackColor = System.Drawing.SystemColors.Window
      Appearance36.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugdDatos.DisplayLayout.Override.ActiveCellAppearance = Appearance36
      Appearance31.BackColor = System.Drawing.SystemColors.Highlight
      Appearance31.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugdDatos.DisplayLayout.Override.ActiveRowAppearance = Appearance31
      Me.ugdDatos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugdDatos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance30.BackColor = System.Drawing.SystemColors.Window
      Me.ugdDatos.DisplayLayout.Override.CardAreaAppearance = Appearance30
      Appearance29.BorderColor = System.Drawing.Color.Silver
      Appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugdDatos.DisplayLayout.Override.CellAppearance = Appearance29
      Me.ugdDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugdDatos.DisplayLayout.Override.CellPadding = 0
      Appearance33.BackColor = System.Drawing.SystemColors.Control
      Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance33.BorderColor = System.Drawing.SystemColors.Window
      Me.ugdDatos.DisplayLayout.Override.GroupByRowAppearance = Appearance33
      Appearance35.TextHAlignAsString = "Left"
      Me.ugdDatos.DisplayLayout.Override.HeaderAppearance = Appearance35
      Me.ugdDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugdDatos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance34.BackColor = System.Drawing.SystemColors.Window
      Appearance34.BorderColor = System.Drawing.Color.Silver
      Me.ugdDatos.DisplayLayout.Override.RowAppearance = Appearance34
      Me.ugdDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance32.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugdDatos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance32
      Me.ugdDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugdDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugdDatos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugdDatos.Location = New System.Drawing.Point(0, 0)
      Me.ugdDatos.Name = "ugdDatos"
      Me.ugdDatos.Size = New System.Drawing.Size(934, 369)
      Me.ugdDatos.TabIndex = 0
      '
      'ConsultarTablasAFIP
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(962, 444)
      Me.Controls.Add(Me.utsTablas)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "ConsultarTablasAFIP"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultar Tablas de AFIP"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.utsTablas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.utsTablas.ResumeLayout(False)
      Me.utsDatos.ResumeLayout(False)
      CType(Me.ugdDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents utsTablas As Infragistics.Win.UltraWinTabControl.UltraTabStripControl
   Friend WithEvents utsDatos As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
   Friend WithEvents ugdDatos As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
