<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichasSeleccionoNrosSerie
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
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selec")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroSerie")
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
      Me.ugNrosSerie = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.lblCantidad = New Eniac.Controles.Label()
      Me.lblSeleccionados = New Eniac.Controles.Label()
      CType(Me.ugNrosSerie, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ugNrosSerie
      '
      Me.ugNrosSerie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugNrosSerie.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.Caption = ""
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn1.Width = 52
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn2.Header.Caption = "Número de Serie"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 372
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2})
      Me.ugNrosSerie.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugNrosSerie.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugNrosSerie.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugNrosSerie.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugNrosSerie.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugNrosSerie.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugNrosSerie.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugNrosSerie.DisplayLayout.MaxColScrollRegions = 1
      Me.ugNrosSerie.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugNrosSerie.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugNrosSerie.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugNrosSerie.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugNrosSerie.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugNrosSerie.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugNrosSerie.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugNrosSerie.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugNrosSerie.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugNrosSerie.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugNrosSerie.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugNrosSerie.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugNrosSerie.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugNrosSerie.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugNrosSerie.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugNrosSerie.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugNrosSerie.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugNrosSerie.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugNrosSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugNrosSerie.Location = New System.Drawing.Point(12, 35)
      Me.ugNrosSerie.Name = "ugNrosSerie"
      Me.ugNrosSerie.Size = New System.Drawing.Size(449, 268)
      Me.ugNrosSerie.TabIndex = 0
      Me.ugNrosSerie.Text = "UltraGrid1"
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.check2
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(275, 314)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(90, 35)
      Me.btnAceptar.TabIndex = 3
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.delete2
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(371, 314)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(90, 35)
      Me.btnCancelar.TabIndex = 3
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'lblProducto
      '
      Me.lblProducto.AutoSize = True
      Me.lblProducto.Location = New System.Drawing.Point(12, 19)
      Me.lblProducto.Name = "lblProducto"
      Me.lblProducto.Size = New System.Drawing.Size(59, 13)
      Me.lblProducto.TabIndex = 4
      Me.lblProducto.Text = "Producto..."
      '
      'lblCantidad
      '
      Me.lblCantidad.AutoSize = True
      Me.lblCantidad.Location = New System.Drawing.Point(12, 314)
      Me.lblCantidad.Name = "lblCantidad"
      Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
      Me.lblCantidad.TabIndex = 4
      Me.lblCantidad.Text = "Cantidad"
      '
      'lblSeleccionados
      '
      Me.lblSeleccionados.AutoSize = True
      Me.lblSeleccionados.Location = New System.Drawing.Point(12, 336)
      Me.lblSeleccionados.Name = "lblSeleccionados"
      Me.lblSeleccionados.Size = New System.Drawing.Size(77, 13)
      Me.lblSeleccionados.TabIndex = 4
      Me.lblSeleccionados.Text = "Seleccionados"
      '
      'FichasSeleccionoNrosSerie
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(473, 361)
      Me.Controls.Add(Me.lblSeleccionados)
      Me.Controls.Add(Me.lblCantidad)
      Me.Controls.Add(Me.lblProducto)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.ugNrosSerie)
      Me.Name = "FichasSeleccionoNrosSerie"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Seleccionar Números de Serie"
      CType(Me.ugNrosSerie, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ugNrosSerie As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents lblCantidad As Eniac.Controles.Label
   Friend WithEvents lblSeleccionados As Eniac.Controles.Label
End Class
