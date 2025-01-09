<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovimientosDeCompraPorGrupo
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
      Me.cmdCancelar = New System.Windows.Forms.Button()
      Me.cmdAceptar = New System.Windows.Forms.Button()
      Me.grdExpensas = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.txtTotalADistribuir = New Eniac.Controles.TextBox()
      Me.txtTotalDistribuido = New Eniac.Controles.TextBox()
      Me.lblSaldoCtaCte = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      CType(Me.grdExpensas, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancelar.Location = New System.Drawing.Point(482, 292)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
      Me.cmdCancelar.TabIndex = 26
      Me.cmdCancelar.Text = "Cancelar"
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdAceptar
      '
      Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAceptar.Location = New System.Drawing.Point(401, 292)
      Me.cmdAceptar.Name = "cmdAceptar"
      Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
      Me.cmdAceptar.TabIndex = 25
      Me.cmdAceptar.Text = "Aceptar"
      Me.cmdAceptar.UseVisualStyleBackColor = True
      '
      'grdExpensas
      '
      Me.grdExpensas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.grdExpensas.DisplayLayout.Appearance = Appearance1
      Me.grdExpensas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.grdExpensas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.grdExpensas.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.grdExpensas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.grdExpensas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.grdExpensas.DisplayLayout.GroupByBox.Hidden = True
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.grdExpensas.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.grdExpensas.DisplayLayout.MaxColScrollRegions = 1
      Me.grdExpensas.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.grdExpensas.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.grdExpensas.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.grdExpensas.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
      Me.grdExpensas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.grdExpensas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.grdExpensas.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.grdExpensas.DisplayLayout.Override.CellAppearance = Appearance8
      Me.grdExpensas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.grdExpensas.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.grdExpensas.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.grdExpensas.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.grdExpensas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.grdExpensas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.grdExpensas.DisplayLayout.Override.RowAppearance = Appearance11
      Me.grdExpensas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.grdExpensas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.grdExpensas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.grdExpensas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.grdExpensas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.grdExpensas.Location = New System.Drawing.Point(12, 12)
      Me.grdExpensas.Name = "grdExpensas"
      Me.grdExpensas.Size = New System.Drawing.Size(545, 274)
      Me.grdExpensas.TabIndex = 27
      Me.grdExpensas.Text = "Asientos"
      '
      'txtTotalADistribuir
      '
      Me.txtTotalADistribuir.BindearPropiedadControl = Nothing
      Me.txtTotalADistribuir.BindearPropiedadEntidad = Nothing
      Me.txtTotalADistribuir.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalADistribuir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalADistribuir.Formato = "#0.00"
      Me.txtTotalADistribuir.IsDecimal = True
      Me.txtTotalADistribuir.IsNumber = True
      Me.txtTotalADistribuir.IsPK = False
      Me.txtTotalADistribuir.IsRequired = False
      Me.txtTotalADistribuir.Key = ""
      Me.txtTotalADistribuir.LabelAsoc = Nothing
      Me.txtTotalADistribuir.Location = New System.Drawing.Point(113, 294)
      Me.txtTotalADistribuir.MaxLength = 8
      Me.txtTotalADistribuir.Name = "txtTotalADistribuir"
      Me.txtTotalADistribuir.ReadOnly = True
      Me.txtTotalADistribuir.Size = New System.Drawing.Size(90, 20)
      Me.txtTotalADistribuir.TabIndex = 28
      Me.txtTotalADistribuir.Text = "0.00"
      Me.txtTotalADistribuir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalDistribuido
      '
      Me.txtTotalDistribuido.BindearPropiedadControl = Nothing
      Me.txtTotalDistribuido.BindearPropiedadEntidad = Nothing
      Me.txtTotalDistribuido.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalDistribuido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalDistribuido.Formato = "#0.00"
      Me.txtTotalDistribuido.IsDecimal = True
      Me.txtTotalDistribuido.IsNumber = True
      Me.txtTotalDistribuido.IsPK = False
      Me.txtTotalDistribuido.IsRequired = False
      Me.txtTotalDistribuido.Key = ""
      Me.txtTotalDistribuido.LabelAsoc = Nothing
      Me.txtTotalDistribuido.Location = New System.Drawing.Point(300, 294)
      Me.txtTotalDistribuido.MaxLength = 8
      Me.txtTotalDistribuido.Name = "txtTotalDistribuido"
      Me.txtTotalDistribuido.ReadOnly = True
      Me.txtTotalDistribuido.Size = New System.Drawing.Size(90, 20)
      Me.txtTotalDistribuido.TabIndex = 29
      Me.txtTotalDistribuido.Text = "0.00"
      Me.txtTotalDistribuido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblSaldoCtaCte
      '
      Me.lblSaldoCtaCte.AutoSize = True
      Me.lblSaldoCtaCte.Location = New System.Drawing.Point(26, 297)
      Me.lblSaldoCtaCte.Name = "lblSaldoCtaCte"
      Me.lblSaldoCtaCte.Size = New System.Drawing.Size(81, 13)
      Me.lblSaldoCtaCte.TabIndex = 30
      Me.lblSaldoCtaCte.Text = "Total a distribuir"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(213, 297)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(81, 13)
      Me.Label1.TabIndex = 31
      Me.Label1.Text = "Total distribuido"
      '
      'MovimientosDeCompraPorGrupo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(569, 327)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblSaldoCtaCte)
      Me.Controls.Add(Me.txtTotalDistribuido)
      Me.Controls.Add(Me.txtTotalADistribuir)
      Me.Controls.Add(Me.grdExpensas)
      Me.Controls.Add(Me.cmdCancelar)
      Me.Controls.Add(Me.cmdAceptar)
      Me.Name = "MovimientosDeCompraPorGrupo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Distribusión de gasto para expensas por grupo de camas"
      CType(Me.grdExpensas, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdAceptar As System.Windows.Forms.Button
   Friend WithEvents grdExpensas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents txtTotalADistribuir As Eniac.Controles.TextBox
   Friend WithEvents txtTotalDistribuido As Eniac.Controles.TextBox
   Friend WithEvents lblSaldoCtaCte As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
End Class
