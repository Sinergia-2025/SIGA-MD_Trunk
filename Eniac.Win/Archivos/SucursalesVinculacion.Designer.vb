<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SucursalesVinculacion
   Inherits BaseForm

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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SucursalesVinculacion))
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
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.lblEmpresa = New Eniac.Controles.Label()
      Me.txtIdSucursal = New Eniac.Controles.TextBox()
      Me.lblIdSucursal = New Eniac.Controles.Label()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.txtNombreEmpresa = New Eniac.Controles.TextBox()
      Me.lblAsociaSucursal = New Eniac.Controles.Label()
      Me.ugVincularDepositos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.cmbSucursales = New Eniac.Controles.ComboBox()
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
      Me.lblSucursalesVinculadas = New System.Windows.Forms.Label()
      Me.lblSucursalesNoVinculadas = New System.Windows.Forms.Label()
      Me.lblMensajeValidacion = New System.Windows.Forms.Label()
      Me.btnAsociarDepositos = New System.Windows.Forms.Button()
      Me.btnCopiarDeposito = New System.Windows.Forms.Button()
      CType(Me.ugVincularDepositos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.FlowLayoutPanel1.SuspendLayout()
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
      Me.btnAceptar.Location = New System.Drawing.Point(806, 519)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 5
      Me.btnAceptar.Text = "&Aceptar"
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
      Me.btnCancelar.Location = New System.Drawing.Point(892, 519)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 4
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'lblEmpresa
      '
      Me.lblEmpresa.AutoSize = True
      Me.lblEmpresa.LabelAsoc = Nothing
      Me.lblEmpresa.Location = New System.Drawing.Point(118, 15)
      Me.lblEmpresa.Name = "lblEmpresa"
      Me.lblEmpresa.Size = New System.Drawing.Size(48, 13)
      Me.lblEmpresa.TabIndex = 48
      Me.lblEmpresa.Text = "Empresa"
      '
      'txtIdSucursal
      '
      Me.txtIdSucursal.BindearPropiedadControl = "Text"
      Me.txtIdSucursal.BindearPropiedadEntidad = "IdSucursal"
      Me.txtIdSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdSucursal.Formato = ""
      Me.txtIdSucursal.IsDecimal = False
      Me.txtIdSucursal.IsNumber = True
      Me.txtIdSucursal.IsPK = True
      Me.txtIdSucursal.IsRequired = True
      Me.txtIdSucursal.Key = ""
      Me.txtIdSucursal.LabelAsoc = Me.lblIdSucursal
      Me.txtIdSucursal.Location = New System.Drawing.Point(66, 12)
      Me.txtIdSucursal.MaxLength = 4
      Me.txtIdSucursal.Name = "txtIdSucursal"
      Me.txtIdSucursal.Size = New System.Drawing.Size(46, 20)
      Me.txtIdSucursal.TabIndex = 47
      Me.txtIdSucursal.Text = "0"
      Me.txtIdSucursal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdSucursal
      '
      Me.lblIdSucursal.AutoSize = True
      Me.lblIdSucursal.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblIdSucursal.LabelAsoc = Nothing
      Me.lblIdSucursal.Location = New System.Drawing.Point(16, 15)
      Me.lblIdSucursal.Name = "lblIdSucursal"
      Me.lblIdSucursal.Size = New System.Drawing.Size(40, 13)
      Me.lblIdSucursal.TabIndex = 46
      Me.lblIdSucursal.Text = "Codigo"
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(16, 41)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 50
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "Nombre"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(66, 38)
      Me.txtNombre.MaxLength = 50
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(289, 20)
      Me.txtNombre.TabIndex = 51
      '
      'txtNombreEmpresa
      '
      Me.txtNombreEmpresa.BindearPropiedadControl = "Text"
      Me.txtNombreEmpresa.BindearPropiedadEntidad = "Nombre"
      Me.txtNombreEmpresa.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEmpresa.Formato = ""
      Me.txtNombreEmpresa.IsDecimal = False
      Me.txtNombreEmpresa.IsNumber = False
      Me.txtNombreEmpresa.IsPK = False
      Me.txtNombreEmpresa.IsRequired = True
      Me.txtNombreEmpresa.Key = ""
      Me.txtNombreEmpresa.LabelAsoc = Me.lblNombre
      Me.txtNombreEmpresa.Location = New System.Drawing.Point(172, 12)
      Me.txtNombreEmpresa.MaxLength = 50
      Me.txtNombreEmpresa.Name = "txtNombreEmpresa"
      Me.txtNombreEmpresa.Size = New System.Drawing.Size(183, 20)
      Me.txtNombreEmpresa.TabIndex = 52
      '
      'lblAsociaSucursal
      '
      Me.lblAsociaSucursal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAsociaSucursal.AutoSize = True
      Me.lblAsociaSucursal.LabelAsoc = Nothing
      Me.lblAsociaSucursal.Location = New System.Drawing.Point(582, 18)
      Me.lblAsociaSucursal.Name = "lblAsociaSucursal"
      Me.lblAsociaSucursal.Size = New System.Drawing.Size(95, 13)
      Me.lblAsociaSucursal.TabIndex = 65
      Me.lblAsociaSucursal.Text = "Sucursal Asociada"
      '
      'ugVincularDepositos
      '
      Me.ugVincularDepositos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugVincularDepositos.DisplayLayout.Appearance = Appearance1
      Me.ugVincularDepositos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugVincularDepositos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugVincularDepositos.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugVincularDepositos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugVincularDepositos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugVincularDepositos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugVincularDepositos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugVincularDepositos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugVincularDepositos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugVincularDepositos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugVincularDepositos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugVincularDepositos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugVincularDepositos.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugVincularDepositos.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugVincularDepositos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugVincularDepositos.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugVincularDepositos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugVincularDepositos.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugVincularDepositos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugVincularDepositos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugVincularDepositos.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugVincularDepositos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugVincularDepositos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugVincularDepositos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugVincularDepositos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugVincularDepositos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugVincularDepositos.Location = New System.Drawing.Point(12, 100)
      Me.ugVincularDepositos.Name = "ugVincularDepositos"
      Me.ugVincularDepositos.Size = New System.Drawing.Size(804, 413)
      Me.ugVincularDepositos.TabIndex = 67
      Me.ugVincularDepositos.Text = "UltraGrid1"
      '
      'cmbSucursales
      '
      Me.cmbSucursales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbSucursales.BindearPropiedadControl = "SelectedValue"
      Me.cmbSucursales.BindearPropiedadEntidad = "IdSucursalAsociada"
      Me.cmbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSucursales.Enabled = False
      Me.cmbSucursales.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSucursales.FormattingEnabled = True
      Me.cmbSucursales.IsPK = False
      Me.cmbSucursales.IsRequired = False
      Me.cmbSucursales.Key = Nothing
      Me.cmbSucursales.LabelAsoc = Nothing
      Me.cmbSucursales.Location = New System.Drawing.Point(683, 15)
      Me.cmbSucursales.Name = "cmbSucursales"
      Me.cmbSucursales.Size = New System.Drawing.Size(179, 21)
      Me.cmbSucursales.TabIndex = 66
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.Controls.Add(Me.lblSucursalesVinculadas)
      Me.FlowLayoutPanel1.Controls.Add(Me.lblSucursalesNoVinculadas)
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(361, 12)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(215, 51)
      Me.FlowLayoutPanel1.TabIndex = 68
      '
      'lblSucursalesVinculadas
      '
      Me.lblSucursalesVinculadas.AutoSize = True
      Me.lblSucursalesVinculadas.Location = New System.Drawing.Point(3, 0)
      Me.lblSucursalesVinculadas.Name = "lblSucursalesVinculadas"
      Me.lblSucursalesVinculadas.Size = New System.Drawing.Size(174, 13)
      Me.lblSucursalesVinculadas.TabIndex = 0
      Me.lblSucursalesVinculadas.Text = "Sucursales actualmente vinculadas"
      '
      'lblSucursalesNoVinculadas
      '
      Me.lblSucursalesNoVinculadas.AutoSize = True
      Me.lblSucursalesNoVinculadas.Location = New System.Drawing.Point(3, 13)
      Me.lblSucursalesNoVinculadas.Name = "lblSucursalesNoVinculadas"
      Me.lblSucursalesNoVinculadas.Size = New System.Drawing.Size(128, 13)
      Me.lblSucursalesNoVinculadas.TabIndex = 1
      Me.lblSucursalesNoVinculadas.Text = "Sucursales no vinculadas"
      Me.lblSucursalesNoVinculadas.Visible = False
      '
      'lblMensajeValidacion
      '
      Me.lblMensajeValidacion.Location = New System.Drawing.Point(9, 66)
      Me.lblMensajeValidacion.Name = "lblMensajeValidacion"
      Me.lblMensajeValidacion.Size = New System.Drawing.Size(963, 31)
      Me.lblMensajeValidacion.TabIndex = 69
      Me.lblMensajeValidacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.lblMensajeValidacion.Visible = False
      '
      'btnAsociarDepositos
      '
      Me.btnAsociarDepositos.Location = New System.Drawing.Point(822, 100)
      Me.btnAsociarDepositos.Name = "btnAsociarDepositos"
      Me.btnAsociarDepositos.Size = New System.Drawing.Size(150, 23)
      Me.btnAsociarDepositos.TabIndex = 70
      Me.btnAsociarDepositos.Text = "Asociar Depositos"
      Me.btnAsociarDepositos.UseVisualStyleBackColor = True
      '
      'btnCopiarDeposito
      '
      Me.btnCopiarDeposito.Location = New System.Drawing.Point(822, 129)
      Me.btnCopiarDeposito.Name = "btnCopiarDeposito"
      Me.btnCopiarDeposito.Size = New System.Drawing.Size(150, 23)
      Me.btnCopiarDeposito.TabIndex = 70
      Me.btnCopiarDeposito.Text = "Copiar Deposito"
      Me.btnCopiarDeposito.UseVisualStyleBackColor = True
      '
      'SucursalesVinculacion
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 561)
      Me.Controls.Add(Me.btnCopiarDeposito)
      Me.Controls.Add(Me.btnAsociarDepositos)
      Me.Controls.Add(Me.lblMensajeValidacion)
      Me.Controls.Add(Me.FlowLayoutPanel1)
      Me.Controls.Add(Me.ugVincularDepositos)
      Me.Controls.Add(Me.lblAsociaSucursal)
      Me.Controls.Add(Me.cmbSucursales)
      Me.Controls.Add(Me.txtNombreEmpresa)
      Me.Controls.Add(Me.lblEmpresa)
      Me.Controls.Add(Me.txtIdSucursal)
      Me.Controls.Add(Me.lblIdSucursal)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Name = "SucursalesVinculacion"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "SucursalesVinculacion"
      CType(Me.ugVincularDepositos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.FlowLayoutPanel1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents lblEmpresa As Controles.Label
   Friend WithEvents txtIdSucursal As Controles.TextBox
   Friend WithEvents lblIdSucursal As Controles.Label
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents txtNombreEmpresa As Controles.TextBox
   Friend WithEvents lblAsociaSucursal As Controles.Label
   Public WithEvents cmbSucursales As Controles.ComboBox
    Friend WithEvents ugVincularDepositos As UltraGrid
   Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
   Friend WithEvents lblSucursalesVinculadas As Label
   Friend WithEvents lblSucursalesNoVinculadas As Label
   Friend WithEvents lblMensajeValidacion As Label
    Friend WithEvents btnAsociarDepositos As Button
    Friend WithEvents btnCopiarDeposito As Button
End Class
