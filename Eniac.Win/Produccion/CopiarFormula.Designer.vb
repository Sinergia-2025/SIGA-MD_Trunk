<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CopiarFormula
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
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProductoComponente")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCosto")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMoneda")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCosto1")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVenta")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaSinIVA")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioVentaConIVA")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoSinIVA")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCostoConIVA")
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
        Me.txtNombreProducto = New Eniac.Controles.TextBox()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.btnCancelar = New Eniac.Controles.Button()
        Me.btnAgregar = New Eniac.Controles.Button()
        Me.txtIdProducto = New Eniac.Controles.TextBox()
        Me.lblFormula = New Eniac.Controles.Label()
        Me.cmbFormulas = New Eniac.Controles.ComboBox()
        Me.ugComponentes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.ugComponentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.BindearPropiedadControl = ""
        Me.txtNombreProducto.BindearPropiedadEntidad = ""
        Me.txtNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreProducto.Formato = ""
        Me.txtNombreProducto.IsDecimal = False
        Me.txtNombreProducto.IsNumber = False
        Me.txtNombreProducto.IsPK = False
        Me.txtNombreProducto.IsRequired = True
        Me.txtNombreProducto.Key = ""
        Me.txtNombreProducto.LabelAsoc = Me.lblProducto
        Me.txtNombreProducto.Location = New System.Drawing.Point(194, 17)
        Me.txtNombreProducto.MaxLength = 100
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.ReadOnly = True
        Me.txtNombreProducto.Size = New System.Drawing.Size(353, 20)
        Me.txtNombreProducto.TabIndex = 2
        Me.txtNombreProducto.TabStop = False
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(16, 21)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Producto"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_a_16
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(471, 333)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(385, 333)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 30)
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Copiar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtIdProducto
        '
        Me.txtIdProducto.BindearPropiedadControl = ""
        Me.txtIdProducto.BindearPropiedadEntidad = ""
        Me.txtIdProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdProducto.Formato = ""
        Me.txtIdProducto.IsDecimal = False
        Me.txtIdProducto.IsNumber = False
        Me.txtIdProducto.IsPK = False
        Me.txtIdProducto.IsRequired = True
        Me.txtIdProducto.Key = ""
        Me.txtIdProducto.LabelAsoc = Me.lblProducto
        Me.txtIdProducto.Location = New System.Drawing.Point(68, 17)
        Me.txtIdProducto.MaxLength = 100
        Me.txtIdProducto.Name = "txtIdProducto"
        Me.txtIdProducto.ReadOnly = True
        Me.txtIdProducto.Size = New System.Drawing.Size(120, 20)
        Me.txtIdProducto.TabIndex = 1
        Me.txtIdProducto.TabStop = False
        '
        'lblFormula
        '
        Me.lblFormula.AutoSize = True
        Me.lblFormula.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFormula.LabelAsoc = Nothing
        Me.lblFormula.Location = New System.Drawing.Point(16, 46)
        Me.lblFormula.Name = "lblFormula"
        Me.lblFormula.Size = New System.Drawing.Size(44, 13)
        Me.lblFormula.TabIndex = 3
        Me.lblFormula.Text = "Fórmula"
        '
        'cmbFormulas
        '
        Me.cmbFormulas.BindearPropiedadControl = Nothing
        Me.cmbFormulas.BindearPropiedadEntidad = Nothing
        Me.cmbFormulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormulas.Enabled = False
        Me.cmbFormulas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormulas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormulas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormulas.FormattingEnabled = True
        Me.cmbFormulas.IsPK = False
        Me.cmbFormulas.IsRequired = False
        Me.cmbFormulas.Key = Nothing
        Me.cmbFormulas.LabelAsoc = Me.lblFormula
        Me.cmbFormulas.Location = New System.Drawing.Point(67, 43)
        Me.cmbFormulas.Name = "cmbFormulas"
        Me.cmbFormulas.Size = New System.Drawing.Size(250, 21)
        Me.cmbFormulas.TabIndex = 4
        Me.cmbFormulas.TabStop = False
        '
        'ugComponentes
        '
        Me.ugComponentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugComponentes.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Cod. Componente"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 80
        UltraGridColumn2.Header.Caption = "Componente"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 264
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance3
        UltraGridColumn4.Format = "N4"
        UltraGridColumn4.Header.Caption = "Precio Costo"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 90
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance4
        UltraGridColumn5.Format = "N4"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 80
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Hidden = True
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
        Me.ugComponentes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugComponentes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComponentes.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComponentes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.ugComponentes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComponentes.DisplayLayout.GroupByBox.Hidden = True
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComponentes.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.ugComponentes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugComponentes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugComponentes.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugComponentes.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.ugComponentes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugComponentes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.ugComponentes.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugComponentes.DisplayLayout.Override.CellAppearance = Appearance11
        Me.ugComponentes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugComponentes.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComponentes.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.ugComponentes.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.ugComponentes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugComponentes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.ugComponentes.DisplayLayout.Override.RowAppearance = Appearance14
        Me.ugComponentes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugComponentes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.ugComponentes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugComponentes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugComponentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugComponentes.Location = New System.Drawing.Point(12, 70)
        Me.ugComponentes.Name = "ugComponentes"
        Me.ugComponentes.Size = New System.Drawing.Size(539, 257)
        Me.ugComponentes.TabIndex = 5
        Me.ugComponentes.Text = "Componentes del Producto"
        '
        'CopiarFormula
        '
        Me.AcceptButton = Me.btnAgregar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 375)
        Me.Controls.Add(Me.ugComponentes)
        Me.Controls.Add(Me.lblFormula)
        Me.Controls.Add(Me.cmbFormulas)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.txtIdProducto)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtNombreProducto)
        Me.Name = "CopiarFormula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar Fórmula"
        CType(Me.ugComponentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreProducto As Eniac.Controles.TextBox
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents btnAgregar As Eniac.Controles.Button
   Friend WithEvents txtIdProducto As Eniac.Controles.TextBox
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents lblFormula As Eniac.Controles.Label
   Friend WithEvents cmbFormulas As Eniac.Controles.ComboBox
    Friend WithEvents ugComponentes As UltraGrid
End Class
