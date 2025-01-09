<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProduccionFormasDetalle
   Inherits BaseDetalle

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
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Key")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Value")
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
        Me.txtNombreProduccionForma = New Eniac.Controles.TextBox()
        Me.lblNombreProduccionForma = New Eniac.Controles.Label()
        Me.txtIdProduccionForma = New Eniac.Controles.TextBox()
        Me.lblIdProduccionForma = New Eniac.Controles.Label()
        Me.lblFormulaCalculoKilaje = New Eniac.Controles.Label()
        Me.txtFormulaCalculoKilaje = New Eniac.Controles.TextBox()
        Me.lblFormulaOperadores = New Eniac.Controles.Label()
        Me.lblFormulaConstanteNumerica = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.ugVariables = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugVariables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(505, 372)
        Me.btnAceptar.TabIndex = 7
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(591, 372)
        Me.btnCancelar.TabIndex = 8
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(404, 372)
        Me.btnCopiar.TabIndex = 6
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(344, 372)
        '
        'txtNombreProduccionForma
        '
        Me.txtNombreProduccionForma.BindearPropiedadControl = "Text"
        Me.txtNombreProduccionForma.BindearPropiedadEntidad = "NombreProduccionForma"
        Me.txtNombreProduccionForma.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreProduccionForma.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreProduccionForma.Formato = ""
        Me.txtNombreProduccionForma.IsDecimal = False
        Me.txtNombreProduccionForma.IsNumber = False
        Me.txtNombreProduccionForma.IsPK = False
        Me.txtNombreProduccionForma.IsRequired = True
        Me.txtNombreProduccionForma.Key = ""
        Me.txtNombreProduccionForma.LabelAsoc = Me.lblNombreProduccionForma
        Me.txtNombreProduccionForma.Location = New System.Drawing.Point(98, 38)
        Me.txtNombreProduccionForma.MaxLength = 30
        Me.txtNombreProduccionForma.Name = "txtNombreProduccionForma"
        Me.txtNombreProduccionForma.Size = New System.Drawing.Size(250, 20)
        Me.txtNombreProduccionForma.TabIndex = 3
        '
        'lblNombreProduccionForma
        '
        Me.lblNombreProduccionForma.AutoSize = True
        Me.lblNombreProduccionForma.LabelAsoc = Nothing
        Me.lblNombreProduccionForma.Location = New System.Drawing.Point(28, 42)
        Me.lblNombreProduccionForma.Name = "lblNombreProduccionForma"
        Me.lblNombreProduccionForma.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProduccionForma.TabIndex = 2
        Me.lblNombreProduccionForma.Text = "Nombre"
        '
        'txtIdProduccionForma
        '
        Me.txtIdProduccionForma.BindearPropiedadControl = "Text"
        Me.txtIdProduccionForma.BindearPropiedadEntidad = "IdProduccionForma"
        Me.txtIdProduccionForma.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdProduccionForma.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdProduccionForma.Formato = ""
        Me.txtIdProduccionForma.IsDecimal = False
        Me.txtIdProduccionForma.IsNumber = True
        Me.txtIdProduccionForma.IsPK = True
        Me.txtIdProduccionForma.IsRequired = True
        Me.txtIdProduccionForma.Key = ""
        Me.txtIdProduccionForma.LabelAsoc = Me.lblIdProduccionForma
        Me.txtIdProduccionForma.Location = New System.Drawing.Point(98, 12)
        Me.txtIdProduccionForma.Name = "txtIdProduccionForma"
        Me.txtIdProduccionForma.Size = New System.Drawing.Size(61, 20)
        Me.txtIdProduccionForma.TabIndex = 1
        Me.txtIdProduccionForma.Text = "0"
        Me.txtIdProduccionForma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdProduccionForma
        '
        Me.lblIdProduccionForma.AutoSize = True
        Me.lblIdProduccionForma.LabelAsoc = Nothing
        Me.lblIdProduccionForma.Location = New System.Drawing.Point(28, 16)
        Me.lblIdProduccionForma.Name = "lblIdProduccionForma"
        Me.lblIdProduccionForma.Size = New System.Drawing.Size(40, 13)
        Me.lblIdProduccionForma.TabIndex = 0
        Me.lblIdProduccionForma.Text = "Código"
        '
        'lblFormulaCalculoKilaje
        '
        Me.lblFormulaCalculoKilaje.AutoSize = True
        Me.lblFormulaCalculoKilaje.LabelAsoc = Nothing
        Me.lblFormulaCalculoKilaje.Location = New System.Drawing.Point(28, 67)
        Me.lblFormulaCalculoKilaje.Name = "lblFormulaCalculoKilaje"
        Me.lblFormulaCalculoKilaje.Size = New System.Drawing.Size(44, 13)
        Me.lblFormulaCalculoKilaje.TabIndex = 4
        Me.lblFormulaCalculoKilaje.Text = "Fórmula"
        '
        'txtFormulaCalculoKilaje
        '
        Me.txtFormulaCalculoKilaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFormulaCalculoKilaje.BindearPropiedadControl = "Text"
        Me.txtFormulaCalculoKilaje.BindearPropiedadEntidad = "FormulaCalculoKilaje"
        Me.txtFormulaCalculoKilaje.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFormulaCalculoKilaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFormulaCalculoKilaje.Formato = ""
        Me.txtFormulaCalculoKilaje.IsDecimal = False
        Me.txtFormulaCalculoKilaje.IsNumber = False
        Me.txtFormulaCalculoKilaje.IsPK = False
        Me.txtFormulaCalculoKilaje.IsRequired = False
        Me.txtFormulaCalculoKilaje.Key = ""
        Me.txtFormulaCalculoKilaje.LabelAsoc = Me.lblFormulaCalculoKilaje
        Me.txtFormulaCalculoKilaje.Location = New System.Drawing.Point(98, 64)
        Me.txtFormulaCalculoKilaje.Name = "txtFormulaCalculoKilaje"
        Me.txtFormulaCalculoKilaje.Size = New System.Drawing.Size(573, 20)
        Me.txtFormulaCalculoKilaje.TabIndex = 5
        '
        'lblFormulaOperadores
        '
        Me.lblFormulaOperadores.AutoSize = True
        Me.lblFormulaOperadores.LabelAsoc = Nothing
        Me.lblFormulaOperadores.Location = New System.Drawing.Point(28, 142)
        Me.lblFormulaOperadores.Name = "lblFormulaOperadores"
        Me.lblFormulaOperadores.Size = New System.Drawing.Size(153, 13)
        Me.lblFormulaOperadores.TabIndex = 58
        Me.lblFormulaOperadores.Text = "Operadores de cálculo () + - / *"
        '
        'lblFormulaConstanteNumerica
        '
        Me.lblFormulaConstanteNumerica.AutoSize = True
        Me.lblFormulaConstanteNumerica.LabelAsoc = Nothing
        Me.lblFormulaConstanteNumerica.Location = New System.Drawing.Point(28, 126)
        Me.lblFormulaConstanteNumerica.Name = "lblFormulaConstanteNumerica"
        Me.lblFormulaConstanteNumerica.Size = New System.Drawing.Size(91, 13)
        Me.lblFormulaConstanteNumerica.TabIndex = 57
        Me.lblFormulaConstanteNumerica.Text = "Números (999.99)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(28, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Valores permitidos para escribir la fórmula de cálculo:"
        '
        'ugVariables
        '
        Me.ugVariables.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugVariables.DisplayLayout.Appearance = Appearance1
        Me.ugVariables.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        UltraGridColumn1.Header.Caption = "Variable"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 207
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
        Me.ugVariables.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugVariables.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugVariables.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVariables.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVariables.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugVariables.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugVariables.DisplayLayout.GroupByBox.Hidden = True
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugVariables.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugVariables.DisplayLayout.MaxColScrollRegions = 1
        Me.ugVariables.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugVariables.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugVariables.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugVariables.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugVariables.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugVariables.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugVariables.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugVariables.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugVariables.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugVariables.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugVariables.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugVariables.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugVariables.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugVariables.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugVariables.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugVariables.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugVariables.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugVariables.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugVariables.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugVariables.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugVariables.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugVariables.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugVariables.Location = New System.Drawing.Point(301, 90)
        Me.ugVariables.Name = "ugVariables"
        Me.ugVariables.Size = New System.Drawing.Size(209, 266)
        Me.ugVariables.TabIndex = 67
        Me.ugVariables.Text = "UltraGrid1"
        '
        'ProduccionFormasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 407)
        Me.Controls.Add(Me.ugVariables)
        Me.Controls.Add(Me.lblFormulaOperadores)
        Me.Controls.Add(Me.lblFormulaConstanteNumerica)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFormulaCalculoKilaje)
        Me.Controls.Add(Me.txtNombreProduccionForma)
        Me.Controls.Add(Me.lblFormulaCalculoKilaje)
        Me.Controls.Add(Me.txtIdProduccionForma)
        Me.Controls.Add(Me.lblNombreProduccionForma)
        Me.Controls.Add(Me.lblIdProduccionForma)
        Me.Name = "ProduccionFormasDetalle"
        Me.Text = "Forma"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.lblIdProduccionForma, 0)
        Me.Controls.SetChildIndex(Me.lblNombreProduccionForma, 0)
        Me.Controls.SetChildIndex(Me.txtIdProduccionForma, 0)
        Me.Controls.SetChildIndex(Me.lblFormulaCalculoKilaje, 0)
        Me.Controls.SetChildIndex(Me.txtNombreProduccionForma, 0)
        Me.Controls.SetChildIndex(Me.txtFormulaCalculoKilaje, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblFormulaConstanteNumerica, 0)
        Me.Controls.SetChildIndex(Me.lblFormulaOperadores, 0)
        Me.Controls.SetChildIndex(Me.ugVariables, 0)
        CType(Me.ugVariables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreProduccionForma As Eniac.Controles.TextBox
   Friend WithEvents lblNombreProduccionForma As Eniac.Controles.Label
   Friend WithEvents txtIdProduccionForma As Eniac.Controles.TextBox
   Friend WithEvents lblIdProduccionForma As Eniac.Controles.Label
   Friend WithEvents lblFormulaCalculoKilaje As Eniac.Controles.Label
   Friend WithEvents txtFormulaCalculoKilaje As Eniac.Controles.TextBox
    Friend WithEvents lblFormulaOperadores As Eniac.Controles.Label
    Friend WithEvents lblFormulaConstanteNumerica As Eniac.Controles.Label
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents ugVariables As UltraGrid
End Class
