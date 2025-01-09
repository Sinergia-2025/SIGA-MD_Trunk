<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidosAdminDividir
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PedidosAdminDividir))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPedido")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstado")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idProducto")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEntregada")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad_EstadoA")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad_EstadoB")
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.cmbSucursalB = New Eniac.Controles.ComboBox()
      Me.cmbSucursalA = New Eniac.Controles.ComboBox()
      Me.lblTipoComprobanteA = New System.Windows.Forms.Label()
      Me.lblTipoComprobanteB = New System.Windows.Forms.Label()
      Me.cmbEstadoB = New Eniac.Controles.ComboBox()
      Me.cmbEstadoA = New Eniac.Controles.ComboBox()
      Me.txtPorcB = New Eniac.Controles.TextBox()
      Me.txtPorcA = New Eniac.Controles.TextBox()
      Me.tstBarra.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(906, 29)
      Me.tstBarra.TabIndex = 2
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "&Grabar"
      Me.tsbGrabar.ToolTipText = "Cerrar el formulario"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      Me.tsbCerrar.ToolTipText = "Cerrar el formulario"
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Tipo"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn3.Header.Caption = "L."
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 23
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn4.CellAppearance = Appearance2
      UltraGridColumn4.Header.Caption = "Emisor"
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 51
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance3
      UltraGridColumn5.Header.Caption = "Número"
      UltraGridColumn5.Header.VisiblePosition = 4
      UltraGridColumn5.Width = 58
      UltraGridColumn9.Header.VisiblePosition = 5
      UltraGridColumn9.Hidden = True
      UltraGridColumn10.Header.Caption = "Fecha"
      UltraGridColumn10.Header.VisiblePosition = 8
      UltraGridColumn10.Hidden = True
      UltraGridColumn13.Header.Caption = "Estado Actual"
      UltraGridColumn13.Header.VisiblePosition = 6
      UltraGridColumn6.Header.Caption = "Código"
      UltraGridColumn6.Header.VisiblePosition = 7
      UltraGridColumn7.Header.Caption = "Producto"
      UltraGridColumn7.Header.VisiblePosition = 9
      UltraGridColumn7.Width = 190
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn8.CellAppearance = Appearance4
      UltraGridColumn8.Format = "N2"
      UltraGridColumn8.Header.VisiblePosition = 10
      UltraGridColumn8.Width = 80
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance5
      UltraGridColumn11.Format = "N2"
      UltraGridColumn11.Header.VisiblePosition = 11
      UltraGridColumn11.Width = 80
      Appearance6.TextHAlignAsString = "Right"
      UltraGridColumn12.CellAppearance = Appearance6
      UltraGridColumn12.Format = "N2"
      UltraGridColumn12.Header.VisiblePosition = 12
      UltraGridColumn12.Width = 80
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn9, UltraGridColumn10, UltraGridColumn13, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn11, UltraGridColumn12})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance7.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance7
      Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance9.BackColor2 = System.Drawing.SystemColors.Control
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance10.BackColor = System.Drawing.SystemColors.Window
      Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance10
      Appearance11.BackColor = System.Drawing.SystemColors.Highlight
      Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance12
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance14.BackColor = System.Drawing.SystemColors.Control
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance14
      Appearance15.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance15
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance16.BackColor = System.Drawing.SystemColors.Window
      Appearance16.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Location = New System.Drawing.Point(12, 106)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(882, 347)
      Me.ugDetalle.TabIndex = 1
      Me.ugDetalle.Text = "UltraGrid1"
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.cmbSucursalB)
      Me.GroupBox1.Controls.Add(Me.cmbSucursalA)
      Me.GroupBox1.Controls.Add(Me.lblTipoComprobanteA)
      Me.GroupBox1.Controls.Add(Me.lblTipoComprobanteB)
      Me.GroupBox1.Controls.Add(Me.cmbEstadoB)
      Me.GroupBox1.Controls.Add(Me.cmbEstadoA)
      Me.GroupBox1.Controls.Add(Me.txtPorcB)
      Me.GroupBox1.Controls.Add(Me.txtPorcA)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(882, 70)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "División automática"
      '
      'cmbSucursalB
      '
      Me.cmbSucursalB.BindearPropiedadControl = "SelectedValue"
      Me.cmbSucursalB.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbSucursalB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursalB.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursalB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursalB.FormattingEnabled = True
      Me.cmbSucursalB.IsPK = False
      Me.cmbSucursalB.IsRequired = True
      Me.cmbSucursalB.Key = Nothing
      Me.cmbSucursalB.LabelAsoc = Nothing
      Me.cmbSucursalB.Location = New System.Drawing.Point(369, 43)
      Me.cmbSucursalB.Name = "cmbSucursalB"
      Me.cmbSucursalB.Size = New System.Drawing.Size(181, 21)
      Me.cmbSucursalB.TabIndex = 7
      '
      'cmbSucursalA
      '
      Me.cmbSucursalA.BindearPropiedadControl = "SelectedValue"
      Me.cmbSucursalA.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbSucursalA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursalA.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursalA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursalA.FormattingEnabled = True
      Me.cmbSucursalA.IsPK = False
      Me.cmbSucursalA.IsRequired = True
      Me.cmbSucursalA.Key = Nothing
      Me.cmbSucursalA.LabelAsoc = Nothing
      Me.cmbSucursalA.Location = New System.Drawing.Point(369, 17)
      Me.cmbSucursalA.Name = "cmbSucursalA"
      Me.cmbSucursalA.Size = New System.Drawing.Size(181, 21)
      Me.cmbSucursalA.TabIndex = 3
      '
      'lblTipoComprobanteA
      '
      Me.lblTipoComprobanteA.AutoSize = True
      Me.lblTipoComprobanteA.Location = New System.Drawing.Point(236, 21)
      Me.lblTipoComprobanteA.Name = "lblTipoComprobanteA"
      Me.lblTipoComprobanteA.Size = New System.Drawing.Size(127, 13)
      Me.lblTipoComprobanteA.TabIndex = 2
      Me.lblTipoComprobanteA.Text = "Tipo Comprobante Actual"
      '
      'lblTipoComprobanteB
      '
      Me.lblTipoComprobanteB.AutoSize = True
      Me.lblTipoComprobanteB.Location = New System.Drawing.Point(236, 47)
      Me.lblTipoComprobanteB.Name = "lblTipoComprobanteB"
      Me.lblTipoComprobanteB.Size = New System.Drawing.Size(127, 13)
      Me.lblTipoComprobanteB.TabIndex = 6
      Me.lblTipoComprobanteB.Text = "Tipo Comprobante Actual"
      '
      'cmbEstadoB
      '
      Me.cmbEstadoB.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoB.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbEstadoB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoB.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoB.FormattingEnabled = True
      Me.cmbEstadoB.IsPK = False
      Me.cmbEstadoB.IsRequired = True
      Me.cmbEstadoB.Key = Nothing
      Me.cmbEstadoB.LabelAsoc = Nothing
      Me.cmbEstadoB.Location = New System.Drawing.Point(6, 43)
      Me.cmbEstadoB.Name = "cmbEstadoB"
      Me.cmbEstadoB.Size = New System.Drawing.Size(181, 21)
      Me.cmbEstadoB.TabIndex = 4
      '
      'cmbEstadoA
      '
      Me.cmbEstadoA.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoA.BindearPropiedadEntidad = "ventas.idformaspago"
      Me.cmbEstadoA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoA.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoA.FormattingEnabled = True
      Me.cmbEstadoA.IsPK = False
      Me.cmbEstadoA.IsRequired = True
      Me.cmbEstadoA.Key = Nothing
      Me.cmbEstadoA.LabelAsoc = Nothing
      Me.cmbEstadoA.Location = New System.Drawing.Point(6, 17)
      Me.cmbEstadoA.Name = "cmbEstadoA"
      Me.cmbEstadoA.Size = New System.Drawing.Size(181, 21)
      Me.cmbEstadoA.TabIndex = 0
      '
      'txtPorcB
      '
      Me.txtPorcB.BindearPropiedadControl = Nothing
      Me.txtPorcB.BindearPropiedadEntidad = Nothing
      Me.txtPorcB.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPorcB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPorcB.Formato = ""
      Me.txtPorcB.IsDecimal = True
      Me.txtPorcB.IsNumber = True
      Me.txtPorcB.IsPK = False
      Me.txtPorcB.IsRequired = False
      Me.txtPorcB.Key = ""
      Me.txtPorcB.LabelAsoc = Nothing
      Me.txtPorcB.Location = New System.Drawing.Point(193, 44)
      Me.txtPorcB.Name = "txtPorcB"
      Me.txtPorcB.Size = New System.Drawing.Size(37, 20)
      Me.txtPorcB.TabIndex = 5
      Me.txtPorcB.Text = "50"
      '
      'txtPorcA
      '
      Me.txtPorcA.BindearPropiedadControl = Nothing
      Me.txtPorcA.BindearPropiedadEntidad = Nothing
      Me.txtPorcA.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPorcA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPorcA.Formato = ""
      Me.txtPorcA.IsDecimal = True
      Me.txtPorcA.IsNumber = True
      Me.txtPorcA.IsPK = False
      Me.txtPorcA.IsRequired = False
      Me.txtPorcA.Key = ""
      Me.txtPorcA.LabelAsoc = Nothing
      Me.txtPorcA.Location = New System.Drawing.Point(193, 18)
      Me.txtPorcA.Name = "txtPorcA"
      Me.txtPorcA.Size = New System.Drawing.Size(37, 20)
      Me.txtPorcA.TabIndex = 1
      Me.txtPorcA.Text = "50"
      '
      'PedidosAdminDividir
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(906, 461)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.tstBarra)
      Me.Name = "PedidosAdminDividir"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Dividir Estados de Pedidos"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents cmbEstadoB As Eniac.Controles.ComboBox
   Friend WithEvents cmbEstadoA As Eniac.Controles.ComboBox
   Friend WithEvents txtPorcB As Eniac.Controles.TextBox
   Friend WithEvents txtPorcA As Eniac.Controles.TextBox
   Friend WithEvents lblTipoComprobanteA As System.Windows.Forms.Label
   Friend WithEvents lblTipoComprobanteB As System.Windows.Forms.Label
   Friend WithEvents cmbSucursalB As Eniac.Controles.ComboBox
   Friend WithEvents cmbSucursalA As Eniac.Controles.ComboBox
End Class
