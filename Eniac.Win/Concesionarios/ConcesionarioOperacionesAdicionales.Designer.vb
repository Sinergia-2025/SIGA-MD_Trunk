<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConcesionarioOperacionesAdicionales
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConcesionarioOperacionesAdicionales))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SelecAdicional")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAdicional")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreAdicional")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DetalleAdicional")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PrecioAdicional")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SolicitaDetalleAdicional")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMarca")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AnioOperacion")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOperacion")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SecuenciaOperacion")
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
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.ugAdicionales = New Eniac.Win.UltraGridEditable()
      CType(Me.ugAdicionales, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(487, 349)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(91, 30)
      Me.btnAceptar.TabIndex = 7
      Me.btnAceptar.Text = "&Aceptar (F4)"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(584, 349)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 6
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'ugAdicionales
      '
      Me.ugAdicionales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugAdicionales.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.Caption = ""
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn1.Width = 28
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn2.CellAppearance = Appearance2
      UltraGridColumn2.Header.Caption = "Código Adicional"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Hidden = True
      UltraGridColumn2.Width = 100
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn3.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
      UltraGridColumn3.Header.Caption = "Adicional"
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 200
      UltraGridColumn4.CellMultiLine = Infragistics.Win.DefaultableBoolean.[True]
      UltraGridColumn4.Header.Caption = "Detalle"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 278
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance3
      UltraGridColumn5.Format = "N2"
      UltraGridColumn5.Header.Caption = "Precio"
      UltraGridColumn5.Header.VisiblePosition = 4
      UltraGridColumn5.MaskInput = "{double:9.2}"
      UltraGridColumn5.Width = 100
      UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn6.Header.Caption = "Solicita Detalle"
      UltraGridColumn6.Header.VisiblePosition = 5
      UltraGridColumn6.Hidden = True
      UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn7.Header.VisiblePosition = 6
      UltraGridColumn7.Hidden = True
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn8.Header.VisiblePosition = 7
      UltraGridColumn8.Hidden = True
      UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn9.Header.VisiblePosition = 8
      UltraGridColumn9.Hidden = True
      UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn10.Header.VisiblePosition = 9
      UltraGridColumn10.Hidden = True
      UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn11.Header.VisiblePosition = 10
      UltraGridColumn11.Hidden = True
      UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn12.Header.VisiblePosition = 11
      UltraGridColumn12.Hidden = True
      UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn13.Header.VisiblePosition = 12
      UltraGridColumn13.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
      Me.ugAdicionales.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugAdicionales.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugAdicionales.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance4.BorderColor = System.Drawing.SystemColors.Window
      Me.ugAdicionales.DisplayLayout.GroupByBox.Appearance = Appearance4
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugAdicionales.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
      Me.ugAdicionales.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance6.BackColor2 = System.Drawing.SystemColors.Control
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugAdicionales.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
      Me.ugAdicionales.DisplayLayout.MaxColScrollRegions = 1
      Me.ugAdicionales.DisplayLayout.MaxRowScrollRegions = 1
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugAdicionales.DisplayLayout.Override.ActiveCellAppearance = Appearance7
      Appearance8.BackColor = System.Drawing.SystemColors.Highlight
      Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugAdicionales.DisplayLayout.Override.ActiveRowAppearance = Appearance8
      Me.ugAdicionales.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugAdicionales.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugAdicionales.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Me.ugAdicionales.DisplayLayout.Override.CardAreaAppearance = Appearance9
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugAdicionales.DisplayLayout.Override.CellAppearance = Appearance10
      Me.ugAdicionales.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugAdicionales.DisplayLayout.Override.CellPadding = 0
      Appearance11.BackColor = System.Drawing.SystemColors.Control
      Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.BorderColor = System.Drawing.SystemColors.Window
      Me.ugAdicionales.DisplayLayout.Override.GroupByRowAppearance = Appearance11
      Appearance12.TextHAlignAsString = "Left"
      Me.ugAdicionales.DisplayLayout.Override.HeaderAppearance = Appearance12
      Me.ugAdicionales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugAdicionales.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Me.ugAdicionales.DisplayLayout.Override.RowAppearance = Appearance13
      Me.ugAdicionales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugAdicionales.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFree
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugAdicionales.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
      Me.ugAdicionales.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugAdicionales.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugAdicionales.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugAdicionales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugAdicionales.Location = New System.Drawing.Point(12, 12)
      Me.ugAdicionales.Name = "ugAdicionales"
      Me.ugAdicionales.Size = New System.Drawing.Size(652, 331)
      Me.ugAdicionales.TabIndex = 8
      Me.ugAdicionales.Text = "UltraGrid1"
      '
      'ConcesionarioOperacionesAdicionales
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(676, 391)
      Me.Controls.Add(Me.ugAdicionales)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Name = "ConcesionarioOperacionesAdicionales"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Adicionales"
      CType(Me.ugAdicionales, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

   Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents ugAdicionales As UltraGridEditable
End Class
