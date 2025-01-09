<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovimientosDeCompraExpensas
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
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.grdExpensas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtTotalADistribuir = New Eniac.Controles.TextBox()
        Me.txtTotalDistribuido = New Eniac.Controles.TextBox()
        Me.lblSaldoCtaCte = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.grdFinal = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.grdExpensas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelar.Location = New System.Drawing.Point(693, 292)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 26
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAceptar.Location = New System.Drawing.Point(612, 292)
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
        Me.grdExpensas.Size = New System.Drawing.Size(394, 274)
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
        'grdFinal
        '
        Me.grdFinal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdFinal.DisplayLayout.Appearance = Appearance13
        Me.grdFinal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdFinal.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.grdFinal.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdFinal.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.grdFinal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.grdFinal.DisplayLayout.GroupByBox.Hidden = True
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.grdFinal.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.grdFinal.DisplayLayout.MaxColScrollRegions = 1
        Me.grdFinal.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdFinal.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.grdFinal.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.grdFinal.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
        Me.grdFinal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.grdFinal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.grdFinal.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.grdFinal.DisplayLayout.Override.CellAppearance = Appearance20
        Me.grdFinal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.grdFinal.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.grdFinal.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.grdFinal.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.grdFinal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdFinal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.grdFinal.DisplayLayout.Override.RowAppearance = Appearance23
        Me.grdFinal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grdFinal.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.grdFinal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.grdFinal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.grdFinal.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdFinal.Location = New System.Drawing.Point(412, 12)
        Me.grdFinal.Name = "grdFinal"
        Me.grdFinal.Size = New System.Drawing.Size(362, 274)
        Me.grdFinal.TabIndex = 32
        Me.grdFinal.Text = "Asientos"
        '
        'MovimientosDeCompraExpensas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 327)
        Me.Controls.Add(Me.grdFinal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSaldoCtaCte)
        Me.Controls.Add(Me.txtTotalDistribuido)
        Me.Controls.Add(Me.txtTotalADistribuir)
        Me.Controls.Add(Me.grdExpensas)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Name = "MovimientosDeCompraExpensas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Distribusión de gasto para expensas"
        CType(Me.grdExpensas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFinal, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents grdFinal As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
