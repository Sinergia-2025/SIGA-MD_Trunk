<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProduccionModelosFormasDetalle
    Inherits BaseDetalle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoVariable")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorDecimalVariable")
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
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.ugVariables = New Eniac.Win.UltraGridEditable()
      Me.lblInterlocutor = New Eniac.Controles.Label()
      Me.cmbCodigoVariable = New Eniac.Controles.ComboBox()
      Me.txtValorDecimalVariable = New Eniac.Controles.TextBox()
      Me.btnInsertarComentario = New Eniac.Controles.Button()
      Me.btnEliminarComentario = New Eniac.Controles.Button()
      Me.grpVariables = New System.Windows.Forms.GroupBox()
      CType(Me.ugVariables, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpVariables.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(255, 325)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(341, 325)
      Me.btnCancelar.TabIndex = 6
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(154, 325)
      Me.btnCopiar.TabIndex = 8
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(97, 325)
      Me.btnAplicar.TabIndex = 7
      '
      'txtCodigo
      '
      Me.txtCodigo.BindearPropiedadControl = "Text"
      Me.txtCodigo.BindearPropiedadEntidad = "IdProduccionModeloForma"
      Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigo.Formato = ""
      Me.txtCodigo.IsDecimal = False
      Me.txtCodigo.IsNumber = True
      Me.txtCodigo.IsPK = True
      Me.txtCodigo.IsRequired = True
      Me.txtCodigo.Key = ""
      Me.txtCodigo.LabelAsoc = Me.lblCodigo
      Me.txtCodigo.Location = New System.Drawing.Point(107, 25)
      Me.txtCodigo.MaxLength = 12
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
      Me.txtCodigo.TabIndex = 1
      Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(20, 28)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Codigo"
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(20, 54)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreProduccionModeloForma"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(107, 51)
      Me.txtNombre.MaxLength = 100
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(289, 20)
      Me.txtNombre.TabIndex = 3
      '
      'ugVariables
      '
      Me.ugVariables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugVariables.DisplayLayout.Appearance = Appearance1
      Me.ugVariables.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn1.Header.Caption = "Código"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 119
      Appearance2.BackColor = System.Drawing.Color.Cyan
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance2
      UltraGridColumn2.Format = "N2"
      UltraGridColumn2.Header.Caption = "Valor"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 119
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
      Me.ugVariables.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugVariables.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugVariables.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance3.BorderColor = System.Drawing.SystemColors.Window
      Me.ugVariables.DisplayLayout.GroupByBox.Appearance = Appearance3
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugVariables.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
      Me.ugVariables.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance5.BackColor2 = System.Drawing.SystemColors.Control
      Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugVariables.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
      Me.ugVariables.DisplayLayout.MaxColScrollRegions = 1
      Me.ugVariables.DisplayLayout.MaxRowScrollRegions = 1
      Appearance6.BackColor = System.Drawing.SystemColors.Window
      Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugVariables.DisplayLayout.Override.ActiveCellAppearance = Appearance6
      Appearance7.BackColor = System.Drawing.SystemColors.Highlight
      Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugVariables.DisplayLayout.Override.ActiveRowAppearance = Appearance7
      Me.ugVariables.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugVariables.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance8.BackColor = System.Drawing.SystemColors.Window
      Me.ugVariables.DisplayLayout.Override.CardAreaAppearance = Appearance8
      Appearance9.BorderColor = System.Drawing.Color.Silver
      Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugVariables.DisplayLayout.Override.CellAppearance = Appearance9
      Me.ugVariables.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugVariables.DisplayLayout.Override.CellPadding = 0
      Appearance10.BackColor = System.Drawing.SystemColors.Control
      Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance10.BorderColor = System.Drawing.SystemColors.Window
      Me.ugVariables.DisplayLayout.Override.GroupByRowAppearance = Appearance10
      Appearance11.TextHAlignAsString = "Left"
      Me.ugVariables.DisplayLayout.Override.HeaderAppearance = Appearance11
      Me.ugVariables.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugVariables.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Me.ugVariables.DisplayLayout.Override.RowAppearance = Appearance12
      Me.ugVariables.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugVariables.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
      Me.ugVariables.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugVariables.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugVariables.EnterMueveACeldaDeAbajo = True
      Me.ugVariables.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugVariables.Location = New System.Drawing.Point(84, 46)
      Me.ugVariables.Name = "ugVariables"
      Me.ugVariables.Size = New System.Drawing.Size(240, 178)
      Me.ugVariables.TabIndex = 5
      Me.ugVariables.Text = "UltraGrid1"
      '
      'lblInterlocutor
      '
      Me.lblInterlocutor.AutoSize = True
      Me.lblInterlocutor.LabelAsoc = Nothing
      Me.lblInterlocutor.Location = New System.Drawing.Point(18, 22)
      Me.lblInterlocutor.Name = "lblInterlocutor"
      Me.lblInterlocutor.Size = New System.Drawing.Size(45, 13)
      Me.lblInterlocutor.TabIndex = 0
      Me.lblInterlocutor.Text = "Variable"
      '
      'cmbCodigoVariable
      '
      Me.cmbCodigoVariable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.cmbCodigoVariable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.cmbCodigoVariable.BindearPropiedadControl = ""
      Me.cmbCodigoVariable.BindearPropiedadEntidad = ""
      Me.cmbCodigoVariable.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCodigoVariable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCodigoVariable.FormattingEnabled = True
      Me.cmbCodigoVariable.IsPK = False
      Me.cmbCodigoVariable.IsRequired = False
      Me.cmbCodigoVariable.Key = Nothing
      Me.cmbCodigoVariable.LabelAsoc = Me.lblInterlocutor
      Me.cmbCodigoVariable.Location = New System.Drawing.Point(84, 19)
      Me.cmbCodigoVariable.MaxLength = 30
      Me.cmbCodigoVariable.Name = "cmbCodigoVariable"
      Me.cmbCodigoVariable.Size = New System.Drawing.Size(121, 21)
      Me.cmbCodigoVariable.Sorted = True
      Me.cmbCodigoVariable.TabIndex = 1
      '
      'txtValorDecimalVariable
      '
      Me.txtValorDecimalVariable.BindearPropiedadControl = ""
      Me.txtValorDecimalVariable.BindearPropiedadEntidad = ""
      Me.txtValorDecimalVariable.ForeColorFocus = System.Drawing.Color.Red
      Me.txtValorDecimalVariable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtValorDecimalVariable.Formato = "N2"
      Me.txtValorDecimalVariable.IsDecimal = True
      Me.txtValorDecimalVariable.IsNumber = True
      Me.txtValorDecimalVariable.IsPK = False
      Me.txtValorDecimalVariable.IsRequired = True
      Me.txtValorDecimalVariable.Key = ""
      Me.txtValorDecimalVariable.LabelAsoc = Nothing
      Me.txtValorDecimalVariable.Location = New System.Drawing.Point(211, 20)
      Me.txtValorDecimalVariable.MaxLength = 6
      Me.txtValorDecimalVariable.Name = "txtValorDecimalVariable"
      Me.txtValorDecimalVariable.Size = New System.Drawing.Size(73, 20)
      Me.txtValorDecimalVariable.TabIndex = 2
      Me.txtValorDecimalVariable.Text = "0.00"
      Me.txtValorDecimalVariable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnInsertarComentario
      '
      Me.btnInsertarComentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnInsertarComentario.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnInsertarComentario.Location = New System.Drawing.Point(329, 11)
      Me.btnInsertarComentario.Name = "btnInsertarComentario"
      Me.btnInsertarComentario.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertarComentario.TabIndex = 3
      Me.btnInsertarComentario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertarComentario.UseVisualStyleBackColor = True
      '
      'btnEliminarComentario
      '
      Me.btnEliminarComentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnEliminarComentario.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.btnEliminarComentario.Location = New System.Drawing.Point(329, 49)
      Me.btnEliminarComentario.Name = "btnEliminarComentario"
      Me.btnEliminarComentario.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminarComentario.TabIndex = 4
      Me.btnEliminarComentario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminarComentario.UseVisualStyleBackColor = True
      '
      'grpVariables
      '
      Me.grpVariables.Controls.Add(Me.cmbCodigoVariable)
      Me.grpVariables.Controls.Add(Me.btnInsertarComentario)
      Me.grpVariables.Controls.Add(Me.ugVariables)
      Me.grpVariables.Controls.Add(Me.btnEliminarComentario)
      Me.grpVariables.Controls.Add(Me.lblInterlocutor)
      Me.grpVariables.Controls.Add(Me.txtValorDecimalVariable)
      Me.grpVariables.Location = New System.Drawing.Point(23, 84)
      Me.grpVariables.Name = "grpVariables"
      Me.grpVariables.Size = New System.Drawing.Size(373, 230)
      Me.grpVariables.TabIndex = 4
      Me.grpVariables.TabStop = False
      Me.grpVariables.Text = "Variables"
      '
      'ProduccionModelosFormasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(430, 360)
      Me.Controls.Add(Me.grpVariables)
      Me.Controls.Add(Me.txtCodigo)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Name = "ProduccionModelosFormasDetalle"
      Me.Text = "Modelo de Forma"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtCodigo, 0)
      Me.Controls.SetChildIndex(Me.grpVariables, 0)
      CType(Me.ugVariables, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpVariables.ResumeLayout(False)
      Me.grpVariables.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents txtCodigo As Controles.TextBox
   Friend WithEvents lblCodigo As Controles.Label
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents ugVariables As UltraGridEditable
   Friend WithEvents lblInterlocutor As Controles.Label
   Friend WithEvents cmbCodigoVariable As Controles.ComboBox
   Friend WithEvents txtValorDecimalVariable As Controles.TextBox
   Friend WithEvents btnInsertarComentario As Controles.Button
   Friend WithEvents btnEliminarComentario As Controles.Button
   Friend WithEvents grpVariables As GroupBox
End Class
