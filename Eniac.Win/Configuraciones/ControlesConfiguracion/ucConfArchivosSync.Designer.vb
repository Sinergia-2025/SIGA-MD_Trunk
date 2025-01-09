<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfArchivosSync
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.ugArchivosSync = New Eniac.Win.UltraGridEditable()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.chbHabilitarTLS1_2 = New Eniac.Controles.CheckBox()
      Me.chbHabilitarTLS1_1 = New Eniac.Controles.CheckBox()
      Me.lblWebArchivosSyncExportPathObs = New Eniac.Controles.Label()
      Me.txtWebArchivosSyncBaseURL = New Eniac.Controles.TextBox()
      Me.lblWebArchivosSyncBaseURL = New Eniac.Controles.Label()
      Me.txtWebArchivosSyncExportPath = New Eniac.Controles.TextBox()
      Me.lblWebArchivosSyncExportPath = New Eniac.Controles.Label()
        CType(Me.ugArchivosSync, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ugArchivosSync
        '
        Me.ugArchivosSync.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugArchivosSync.DisplayLayout.Appearance = Appearance1
        Me.ugArchivosSync.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugArchivosSync.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugArchivosSync.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugArchivosSync.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugArchivosSync.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugArchivosSync.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugArchivosSync.DisplayLayout.MaxColScrollRegions = 1
        Me.ugArchivosSync.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugArchivosSync.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugArchivosSync.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugArchivosSync.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugArchivosSync.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugArchivosSync.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugArchivosSync.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugArchivosSync.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugArchivosSync.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugArchivosSync.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugArchivosSync.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugArchivosSync.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugArchivosSync.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugArchivosSync.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugArchivosSync.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugArchivosSync.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugArchivosSync.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugArchivosSync.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugArchivosSync.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugArchivosSync.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugArchivosSync.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugArchivosSync.Location = New System.Drawing.Point(134, 89)
        Me.ugArchivosSync.Name = "ugArchivosSync"
        Me.ugArchivosSync.Size = New System.Drawing.Size(628, 291)
        Me.ugArchivosSync.TabIndex = 60
        Me.ugArchivosSync.Text = "UltraGrid1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chbHabilitarTLS1_2)
        Me.Panel1.Controls.Add(Me.chbHabilitarTLS1_1)
        Me.Panel1.Controls.Add(Me.lblWebArchivosSyncExportPathObs)
        Me.Panel1.Controls.Add(Me.txtWebArchivosSyncBaseURL)
        Me.Panel1.Controls.Add(Me.lblWebArchivosSyncBaseURL)
        Me.Panel1.Controls.Add(Me.txtWebArchivosSyncExportPath)
        Me.Panel1.Controls.Add(Me.lblWebArchivosSyncExportPath)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(900, 62)
        Me.Panel1.TabIndex = 59
        '
        'chbHabilitarTLS1_2
        '
        Me.chbHabilitarTLS1_2.AutoSize = True
        Me.chbHabilitarTLS1_2.BindearPropiedadControl = Nothing
        Me.chbHabilitarTLS1_2.BindearPropiedadEntidad = Nothing
        Me.chbHabilitarTLS1_2.ForeColorFocus = System.Drawing.Color.Red
        Me.chbHabilitarTLS1_2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbHabilitarTLS1_2.IsPK = False
        Me.chbHabilitarTLS1_2.IsRequired = False
        Me.chbHabilitarTLS1_2.Key = Nothing
        Me.chbHabilitarTLS1_2.LabelAsoc = Nothing
        Me.chbHabilitarTLS1_2.Location = New System.Drawing.Point(749, 32)
        Me.chbHabilitarTLS1_2.Name = "chbHabilitarTLS1_2"
        Me.chbHabilitarTLS1_2.Size = New System.Drawing.Size(102, 17)
        Me.chbHabilitarTLS1_2.TabIndex = 21
        Me.chbHabilitarTLS1_2.Tag = ""
        Me.chbHabilitarTLS1_2.Text = "Habilitar TLS1.2"
        Me.chbHabilitarTLS1_2.UseVisualStyleBackColor = True
        '
        'chbHabilitarTLS1_1
        '
        Me.chbHabilitarTLS1_1.AutoSize = True
        Me.chbHabilitarTLS1_1.BindearPropiedadControl = Nothing
        Me.chbHabilitarTLS1_1.BindearPropiedadEntidad = Nothing
        Me.chbHabilitarTLS1_1.ForeColorFocus = System.Drawing.Color.Red
        Me.chbHabilitarTLS1_1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbHabilitarTLS1_1.IsPK = False
        Me.chbHabilitarTLS1_1.IsRequired = False
        Me.chbHabilitarTLS1_1.Key = Nothing
        Me.chbHabilitarTLS1_1.LabelAsoc = Nothing
        Me.chbHabilitarTLS1_1.Location = New System.Drawing.Point(641, 32)
        Me.chbHabilitarTLS1_1.Name = "chbHabilitarTLS1_1"
        Me.chbHabilitarTLS1_1.Size = New System.Drawing.Size(102, 17)
        Me.chbHabilitarTLS1_1.TabIndex = 20
        Me.chbHabilitarTLS1_1.Tag = ""
        Me.chbHabilitarTLS1_1.Text = "Habilitar TLS1.1"
        Me.chbHabilitarTLS1_1.UseVisualStyleBackColor = True
        '
        'lblWebArchivosSyncExportPathObs
        '
        Me.lblWebArchivosSyncExportPathObs.AutoSize = True
        Me.lblWebArchivosSyncExportPathObs.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWebArchivosSyncExportPathObs.LabelAsoc = Nothing
        Me.lblWebArchivosSyncExportPathObs.Location = New System.Drawing.Point(638, 7)
        Me.lblWebArchivosSyncExportPathObs.Name = "lblWebArchivosSyncExportPathObs"
        Me.lblWebArchivosSyncExportPathObs.Size = New System.Drawing.Size(232, 13)
        Me.lblWebArchivosSyncExportPathObs.TabIndex = 16
        Me.lblWebArchivosSyncExportPathObs.Text = "(para hacer respaldo de lo enviado en archivos)"
        '
        'txtWebArchivosSyncBaseURL
        '
        Me.txtWebArchivosSyncBaseURL.BindearPropiedadControl = Nothing
        Me.txtWebArchivosSyncBaseURL.BindearPropiedadEntidad = Nothing
        Me.txtWebArchivosSyncBaseURL.ForeColorFocus = System.Drawing.Color.Red
        Me.txtWebArchivosSyncBaseURL.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtWebArchivosSyncBaseURL.Formato = ""
        Me.txtWebArchivosSyncBaseURL.IsDecimal = False
        Me.txtWebArchivosSyncBaseURL.IsNumber = False
        Me.txtWebArchivosSyncBaseURL.IsPK = False
        Me.txtWebArchivosSyncBaseURL.IsRequired = False
        Me.txtWebArchivosSyncBaseURL.Key = ""
        Me.txtWebArchivosSyncBaseURL.LabelAsoc = Me.lblWebArchivosSyncBaseURL
        Me.txtWebArchivosSyncBaseURL.Location = New System.Drawing.Point(168, 30)
        Me.txtWebArchivosSyncBaseURL.Name = "txtWebArchivosSyncBaseURL"
        Me.txtWebArchivosSyncBaseURL.Size = New System.Drawing.Size(453, 20)
        Me.txtWebArchivosSyncBaseURL.TabIndex = 17
        '
        'lblWebArchivosSyncBaseURL
        '
        Me.lblWebArchivosSyncBaseURL.AutoSize = True
        Me.lblWebArchivosSyncBaseURL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWebArchivosSyncBaseURL.LabelAsoc = Nothing
        Me.lblWebArchivosSyncBaseURL.Location = New System.Drawing.Point(10, 33)
        Me.lblWebArchivosSyncBaseURL.Name = "lblWebArchivosSyncBaseURL"
        Me.lblWebArchivosSyncBaseURL.Size = New System.Drawing.Size(152, 13)
        Me.lblWebArchivosSyncBaseURL.TabIndex = 16
        Me.lblWebArchivosSyncBaseURL.Text = "Base URL para Sincronización"
        '
        'txtWebArchivosSyncExportPath
        '
        Me.txtWebArchivosSyncExportPath.BindearPropiedadControl = Nothing
        Me.txtWebArchivosSyncExportPath.BindearPropiedadEntidad = Nothing
        Me.txtWebArchivosSyncExportPath.ForeColorFocus = System.Drawing.Color.Red
        Me.txtWebArchivosSyncExportPath.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtWebArchivosSyncExportPath.Formato = ""
        Me.txtWebArchivosSyncExportPath.IsDecimal = False
        Me.txtWebArchivosSyncExportPath.IsNumber = False
        Me.txtWebArchivosSyncExportPath.IsPK = False
        Me.txtWebArchivosSyncExportPath.IsRequired = False
        Me.txtWebArchivosSyncExportPath.Key = ""
        Me.txtWebArchivosSyncExportPath.LabelAsoc = Me.lblWebArchivosSyncExportPath
        Me.txtWebArchivosSyncExportPath.Location = New System.Drawing.Point(168, 4)
        Me.txtWebArchivosSyncExportPath.Name = "txtWebArchivosSyncExportPath"
        Me.txtWebArchivosSyncExportPath.Size = New System.Drawing.Size(453, 20)
        Me.txtWebArchivosSyncExportPath.TabIndex = 17
        '
        'lblWebArchivosSyncExportPath
        '
        Me.lblWebArchivosSyncExportPath.AutoSize = True
        Me.lblWebArchivosSyncExportPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblWebArchivosSyncExportPath.LabelAsoc = Nothing
        Me.lblWebArchivosSyncExportPath.Location = New System.Drawing.Point(10, 7)
        Me.lblWebArchivosSyncExportPath.Name = "lblWebArchivosSyncExportPath"
        Me.lblWebArchivosSyncExportPath.Size = New System.Drawing.Size(145, 13)
        Me.lblWebArchivosSyncExportPath.TabIndex = 16
        Me.lblWebArchivosSyncExportPath.Text = "Carpeta donde exportar JSon"
        '
        'ucConfArchivosSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ugArchivosSync)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucConfArchivosSync"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.ugArchivosSync, 0)
        CType(Me.ugArchivosSync, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ugArchivosSync As UltraGridEditable
   Friend WithEvents Panel1 As Panel
   Friend WithEvents chbHabilitarTLS1_2 As Controles.CheckBox
   Friend WithEvents chbHabilitarTLS1_1 As Controles.CheckBox
   Friend WithEvents lblWebArchivosSyncExportPathObs As Controles.Label
   Friend WithEvents txtWebArchivosSyncBaseURL As Controles.TextBox
   Friend WithEvents lblWebArchivosSyncBaseURL As Controles.Label
   Friend WithEvents txtWebArchivosSyncExportPath As Controles.TextBox
   Friend WithEvents lblWebArchivosSyncExportPath As Controles.Label
End Class
