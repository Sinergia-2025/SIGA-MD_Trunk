<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionNrosLotes
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
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLote")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaIngreso")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadActual")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadInicial")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadSeleccionada")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Habilitado")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioCosto")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
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
      Me.ugNrosLotes = New Eniac.Win.UltraGridEditable()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.btnAceptar = New Eniac.Controles.Button()
      CType(Me.ugNrosLotes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ugNrosLotes
      '
      Me.ugNrosLotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugNrosLotes.DisplayLayout.Appearance = Appearance1
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance2
      UltraGridColumn4.Header.Caption = "Sucursal"
      UltraGridColumn4.Header.VisiblePosition = 0
      UltraGridColumn4.Hidden = True
      UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn5.Header.Caption = "Cód. Producto"
      UltraGridColumn5.Header.VisiblePosition = 1
      UltraGridColumn5.Hidden = True
      UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn6.Header.Caption = "Lote"
      UltraGridColumn6.Header.VisiblePosition = 2
      UltraGridColumn6.Width = 130
      UltraGridColumn2.Header.VisiblePosition = 3
      UltraGridColumn2.Hidden = True
      UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance3.TextHAlignAsString = "Center"
      UltraGridColumn7.CellAppearance = Appearance3
      UltraGridColumn7.Format = "dd/MM/yyyy"
      UltraGridColumn7.Header.Caption = "Vencimiento"
      UltraGridColumn7.Header.VisiblePosition = 4
      UltraGridColumn7.Width = 89
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance4
      UltraGridColumn8.Format = "N2"
      UltraGridColumn8.Header.Caption = "Stock"
      UltraGridColumn8.Header.VisiblePosition = 5
      UltraGridColumn8.Width = 73
      UltraGridColumn9.Format = "N2"
      UltraGridColumn9.Header.VisiblePosition = 7
      UltraGridColumn9.Hidden = True
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn1.CellAppearance = Appearance5
      UltraGridColumn1.Header.Caption = "Cantidad"
      UltraGridColumn1.Header.VisiblePosition = 6
      UltraGridColumn1.Width = 57
      UltraGridColumn10.Header.VisiblePosition = 8
      UltraGridColumn10.Hidden = True
      UltraGridColumn11.Format = "N2"
      UltraGridColumn11.Header.VisiblePosition = 9
      UltraGridColumn11.Hidden = True
      UltraGridColumn3.Header.VisiblePosition = 10
      UltraGridColumn3.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn2, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn1, UltraGridColumn10, UltraGridColumn11, UltraGridColumn3})
      Me.ugNrosLotes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugNrosLotes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugNrosLotes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance6.BorderColor = System.Drawing.SystemColors.Window
      Me.ugNrosLotes.DisplayLayout.GroupByBox.Appearance = Appearance6
      Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugNrosLotes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance7
      Me.ugNrosLotes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance8.BackColor2 = System.Drawing.SystemColors.Control
      Appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugNrosLotes.DisplayLayout.GroupByBox.PromptAppearance = Appearance8
      Me.ugNrosLotes.DisplayLayout.MaxColScrollRegions = 1
      Me.ugNrosLotes.DisplayLayout.MaxRowScrollRegions = 1
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Appearance9.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugNrosLotes.DisplayLayout.Override.ActiveCellAppearance = Appearance9
      Appearance10.BackColor = System.Drawing.SystemColors.Highlight
      Appearance10.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugNrosLotes.DisplayLayout.Override.ActiveRowAppearance = Appearance10
      Me.ugNrosLotes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugNrosLotes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Me.ugNrosLotes.DisplayLayout.Override.CardAreaAppearance = Appearance11
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugNrosLotes.DisplayLayout.Override.CellAppearance = Appearance12
      Me.ugNrosLotes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugNrosLotes.DisplayLayout.Override.CellPadding = 0
      Appearance13.BackColor = System.Drawing.SystemColors.Control
      Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance13.BorderColor = System.Drawing.SystemColors.Window
      Me.ugNrosLotes.DisplayLayout.Override.GroupByRowAppearance = Appearance13
      Appearance14.TextHAlignAsString = "Left"
      Me.ugNrosLotes.DisplayLayout.Override.HeaderAppearance = Appearance14
      Me.ugNrosLotes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugNrosLotes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.BorderColor = System.Drawing.Color.Silver
      Me.ugNrosLotes.DisplayLayout.Override.RowAppearance = Appearance15
      Me.ugNrosLotes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugNrosLotes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance16
      Me.ugNrosLotes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugNrosLotes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugNrosLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugNrosLotes.Location = New System.Drawing.Point(15, 25)
      Me.ugNrosLotes.Name = "ugNrosLotes"
      Me.ugNrosLotes.Size = New System.Drawing.Size(440, 213)
      Me.ugNrosLotes.TabIndex = 0
      Me.ugNrosLotes.Text = "Nros Lotes"
      '
      'lblProducto
      '
      Me.lblProducto.AutoSize = True
      Me.lblProducto.LabelAsoc = Nothing
      Me.lblProducto.Location = New System.Drawing.Point(12, 9)
      Me.lblProducto.Name = "lblProducto"
      Me.lblProducto.Size = New System.Drawing.Size(59, 13)
      Me.lblProducto.TabIndex = 2
      Me.lblProducto.Text = "Producto..."
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_32
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(365, 244)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(90, 35)
      Me.btnAceptar.TabIndex = 1
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'SeleccionNrosLotes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(464, 294)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.lblProducto)
      Me.Controls.Add(Me.ugNrosLotes)
      Me.Name = "SeleccionNrosLotes"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Selección de Nros. Lotes"
      CType(Me.ugNrosLotes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ugNrosLotes As Eniac.Win.UltraGridEditable
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents btnAceptar As Eniac.Controles.Button
End Class
