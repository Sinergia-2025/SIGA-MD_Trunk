<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolicitarSoporte
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolicitarSoporte))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FileName")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FullFileName")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FileInfo")
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
      Me.lblCategoriaNovedad = New Eniac.Controles.Label()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.cmbCategoriaNovedad = New Eniac.Controles.ComboBox()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.txtComentarios = New Eniac.Controles.TextBox()
      Me.lblComentarios = New Eniac.Controles.Label()
      Me.lblCuentaCaracteres = New Eniac.Controles.Label()
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.pnlAcciones = New System.Windows.Forms.Panel()
      Me.txtInterlocutor = New Eniac.Controles.TextBox()
      Me.lblInterlocutor = New Eniac.Controles.Label()
      Me.pnlGeneral = New System.Windows.Forms.Panel()
      Me.pnlAdjuntos = New System.Windows.Forms.Panel()
      Me.ugAdjuntos = New UltraGridSiga()
      Me.pnlAccionesAdjuntos = New System.Windows.Forms.FlowLayoutPanel()
      Me.btnAgregarAdjunto = New System.Windows.Forms.Button()
      Me.btnQuitarAdjunto = New System.Windows.Forms.Button()
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.pnlAcciones.SuspendLayout()
      Me.pnlGeneral.SuspendLayout()
      Me.pnlAdjuntos.SuspendLayout()
      CType(Me.ugAdjuntos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlAccionesAdjuntos.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblCategoriaNovedad
      '
      Me.lblCategoriaNovedad.AutoSize = True
      Me.lblCategoriaNovedad.LabelAsoc = Nothing
      Me.lblCategoriaNovedad.Location = New System.Drawing.Point(12, 59)
      Me.lblCategoriaNovedad.Name = "lblCategoriaNovedad"
      Me.lblCategoriaNovedad.Size = New System.Drawing.Size(52, 13)
      Me.lblCategoriaNovedad.TabIndex = 4
      Me.lblCategoriaNovedad.Text = "Categoria"
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(12, 33)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'cmbCategoriaNovedad
      '
      Me.cmbCategoriaNovedad.BindearPropiedadControl = ""
      Me.cmbCategoriaNovedad.BindearPropiedadEntidad = ""
      Me.cmbCategoriaNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoriaNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoriaNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoriaNovedad.FormattingEnabled = True
      Me.cmbCategoriaNovedad.IsPK = False
      Me.cmbCategoriaNovedad.IsRequired = True
      Me.cmbCategoriaNovedad.Key = Nothing
      Me.cmbCategoriaNovedad.LabelAsoc = Me.lblCategoriaNovedad
      Me.cmbCategoriaNovedad.Location = New System.Drawing.Point(98, 56)
      Me.cmbCategoriaNovedad.Name = "cmbCategoriaNovedad"
      Me.cmbCategoriaNovedad.Size = New System.Drawing.Size(203, 21)
      Me.cmbCategoriaNovedad.TabIndex = 5
      '
      'txtDescripcion
      '
      Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDescripcion.BindearPropiedadControl = ""
      Me.txtDescripcion.BindearPropiedadEntidad = ""
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
      Me.txtDescripcion.Location = New System.Drawing.Point(98, 30)
      Me.txtDescripcion.MaxLength = 200
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(459, 20)
      Me.txtDescripcion.TabIndex = 3
      '
      'txtComentarios
      '
      Me.txtComentarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtComentarios.BindearPropiedadControl = ""
      Me.txtComentarios.BindearPropiedadEntidad = ""
      Me.txtComentarios.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComentarios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComentarios.Formato = ""
      Me.txtComentarios.IsDecimal = False
      Me.txtComentarios.IsNumber = False
      Me.txtComentarios.IsPK = False
      Me.txtComentarios.IsRequired = False
      Me.txtComentarios.Key = ""
      Me.txtComentarios.LabelAsoc = Me.lblComentarios
      Me.txtComentarios.Location = New System.Drawing.Point(98, 83)
      Me.txtComentarios.MaxLength = 500
      Me.txtComentarios.Multiline = True
      Me.txtComentarios.Name = "txtComentarios"
      Me.txtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtComentarios.Size = New System.Drawing.Size(474, 83)
      Me.txtComentarios.TabIndex = 7
      '
      'lblComentarios
      '
      Me.lblComentarios.AutoSize = True
      Me.lblComentarios.LabelAsoc = Nothing
      Me.lblComentarios.Location = New System.Drawing.Point(12, 86)
      Me.lblComentarios.Name = "lblComentarios"
      Me.lblComentarios.Size = New System.Drawing.Size(65, 13)
      Me.lblComentarios.TabIndex = 6
      Me.lblComentarios.Text = "Comentarios"
      '
      'lblCuentaCaracteres
      '
      Me.lblCuentaCaracteres.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCuentaCaracteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCuentaCaracteres.LabelAsoc = Nothing
      Me.lblCuentaCaracteres.Location = New System.Drawing.Point(472, 169)
      Me.lblCuentaCaracteres.Name = "lblCuentaCaracteres"
      Me.lblCuentaCaracteres.Size = New System.Drawing.Size(100, 13)
      Me.lblCuentaCaracteres.TabIndex = 8
      Me.lblCuentaCaracteres.Text = "{0} / 500"
      Me.lblCuentaCaracteres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(576, 0)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(100, 30)
      Me.btnAceptar.TabIndex = 0
      Me.btnAceptar.Text = "&Aceptar (F4)"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(682, 0)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(100, 30)
      Me.btnCancelar.TabIndex = 1
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'pnlAcciones
      '
      Me.pnlAcciones.AutoSize = True
      Me.pnlAcciones.Controls.Add(Me.btnAceptar)
      Me.pnlAcciones.Controls.Add(Me.btnCancelar)
      Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.pnlAcciones.Location = New System.Drawing.Point(0, 192)
      Me.pnlAcciones.Name = "pnlAcciones"
      Me.pnlAcciones.Size = New System.Drawing.Size(784, 33)
      Me.pnlAcciones.TabIndex = 9
      '
      'txtInterlocutor
      '
      Me.txtInterlocutor.BindearPropiedadControl = ""
      Me.txtInterlocutor.BindearPropiedadEntidad = ""
      Me.txtInterlocutor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtInterlocutor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtInterlocutor.Formato = ""
      Me.txtInterlocutor.IsDecimal = False
      Me.txtInterlocutor.IsNumber = False
      Me.txtInterlocutor.IsPK = False
      Me.txtInterlocutor.IsRequired = True
      Me.txtInterlocutor.Key = ""
      Me.txtInterlocutor.LabelAsoc = Me.lblInterlocutor
      Me.txtInterlocutor.Location = New System.Drawing.Point(98, 4)
      Me.txtInterlocutor.MaxLength = 30
      Me.txtInterlocutor.Name = "txtInterlocutor"
      Me.txtInterlocutor.Size = New System.Drawing.Size(203, 20)
      Me.txtInterlocutor.TabIndex = 1
      '
      'lblInterlocutor
      '
      Me.lblInterlocutor.AutoSize = True
      Me.lblInterlocutor.LabelAsoc = Nothing
      Me.lblInterlocutor.Location = New System.Drawing.Point(12, 7)
      Me.lblInterlocutor.Name = "lblInterlocutor"
      Me.lblInterlocutor.Size = New System.Drawing.Size(60, 13)
      Me.lblInterlocutor.TabIndex = 0
      Me.lblInterlocutor.Text = "Interlocutor"
      '
      'pnlGeneral
      '
      Me.pnlGeneral.Controls.Add(Me.lblCuentaCaracteres)
      Me.pnlGeneral.Controls.Add(Me.lblComentarios)
      Me.pnlGeneral.Controls.Add(Me.lblCategoriaNovedad)
      Me.pnlGeneral.Controls.Add(Me.lblInterlocutor)
      Me.pnlGeneral.Controls.Add(Me.lblDescripcion)
      Me.pnlGeneral.Controls.Add(Me.cmbCategoriaNovedad)
      Me.pnlGeneral.Controls.Add(Me.txtInterlocutor)
      Me.pnlGeneral.Controls.Add(Me.txtDescripcion)
      Me.pnlGeneral.Controls.Add(Me.txtComentarios)
      Me.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlGeneral.Location = New System.Drawing.Point(0, 0)
      Me.pnlGeneral.Name = "pnlGeneral"
      Me.pnlGeneral.Size = New System.Drawing.Size(584, 192)
      Me.pnlGeneral.TabIndex = 10
      '
      'pnlAdjuntos
      '
      Me.pnlAdjuntos.Controls.Add(Me.ugAdjuntos)
      Me.pnlAdjuntos.Controls.Add(Me.pnlAccionesAdjuntos)
      Me.pnlAdjuntos.Dock = System.Windows.Forms.DockStyle.Right
      Me.pnlAdjuntos.Location = New System.Drawing.Point(584, 0)
      Me.pnlAdjuntos.Name = "pnlAdjuntos"
      Me.pnlAdjuntos.Size = New System.Drawing.Size(200, 192)
      Me.pnlAdjuntos.TabIndex = 11
      '
      'ugAdjuntos
      '
      Me.ugAdjuntos.AllowDrop = True
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugAdjuntos.DisplayLayout.Appearance = Appearance1
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn1.Header.Caption = "Archivo"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.MinWidth = 175
      UltraGridColumn1.Width = 175
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Hidden = True
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Hidden = True
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3})
      Me.ugAdjuntos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugAdjuntos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugAdjuntos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugAdjuntos.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugAdjuntos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugAdjuntos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugAdjuntos.DisplayLayout.GroupByBox.Hidden = True
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugAdjuntos.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugAdjuntos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugAdjuntos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugAdjuntos.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugAdjuntos.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugAdjuntos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugAdjuntos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugAdjuntos.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugAdjuntos.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugAdjuntos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugAdjuntos.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugAdjuntos.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugAdjuntos.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugAdjuntos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugAdjuntos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugAdjuntos.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugAdjuntos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugAdjuntos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugAdjuntos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugAdjuntos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugAdjuntos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugAdjuntos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugAdjuntos.Location = New System.Drawing.Point(0, 29)
      Me.ugAdjuntos.Name = "ugAdjuntos"
      Me.ugAdjuntos.Size = New System.Drawing.Size(200, 163)
      Me.ugAdjuntos.TabIndex = 3
      Me.ugAdjuntos.Text = "UltraGrid1"
      '
      'pnlAccionesAdjuntos
      '
      Me.pnlAccionesAdjuntos.AutoSize = True
      Me.pnlAccionesAdjuntos.Controls.Add(Me.btnAgregarAdjunto)
      Me.pnlAccionesAdjuntos.Controls.Add(Me.btnQuitarAdjunto)
      Me.pnlAccionesAdjuntos.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlAccionesAdjuntos.Location = New System.Drawing.Point(0, 0)
      Me.pnlAccionesAdjuntos.Name = "pnlAccionesAdjuntos"
      Me.pnlAccionesAdjuntos.Size = New System.Drawing.Size(200, 29)
      Me.pnlAccionesAdjuntos.TabIndex = 2
      '
      'btnAgregarAdjunto
      '
      Me.btnAgregarAdjunto.Image = Global.Eniac.Win.My.Resources.Resources.add_16
      Me.btnAgregarAdjunto.Location = New System.Drawing.Point(3, 3)
      Me.btnAgregarAdjunto.Name = "btnAgregarAdjunto"
      Me.btnAgregarAdjunto.Size = New System.Drawing.Size(23, 23)
      Me.btnAgregarAdjunto.TabIndex = 0
      Me.btnAgregarAdjunto.UseVisualStyleBackColor = True
      '
      'btnQuitarAdjunto
      '
      Me.btnQuitarAdjunto.Image = Global.Eniac.Win.My.Resources.Resources.delete_16
      Me.btnQuitarAdjunto.Location = New System.Drawing.Point(32, 3)
      Me.btnQuitarAdjunto.Name = "btnQuitarAdjunto"
      Me.btnQuitarAdjunto.Size = New System.Drawing.Size(23, 23)
      Me.btnQuitarAdjunto.TabIndex = 1
      Me.btnQuitarAdjunto.UseVisualStyleBackColor = True
      '
      'OpenFileDialog1
      '
      Me.OpenFileDialog1.Multiselect = True
      Me.OpenFileDialog1.Title = "Seleccione archivos a adjuntar"
      '
      'SolicitarSoporte
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(784, 225)
      Me.Controls.Add(Me.pnlGeneral)
      Me.Controls.Add(Me.pnlAdjuntos)
      Me.Controls.Add(Me.pnlAcciones)
      Me.Name = "SolicitarSoporte"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Solictar Soporte"
      Me.pnlAcciones.ResumeLayout(False)
      Me.pnlGeneral.ResumeLayout(False)
      Me.pnlGeneral.PerformLayout()
      Me.pnlAdjuntos.ResumeLayout(False)
      Me.pnlAdjuntos.PerformLayout()
      CType(Me.ugAdjuntos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlAccionesAdjuntos.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblCategoriaNovedad As Eniac.Controles.Label
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents cmbCategoriaNovedad As Eniac.Controles.ComboBox
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents txtComentarios As Eniac.Controles.TextBox
   Friend WithEvents lblComentarios As Eniac.Controles.Label
   Friend WithEvents lblCuentaCaracteres As Eniac.Controles.Label
   Private WithEvents imageList1 As System.Windows.Forms.ImageList
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents txtInterlocutor As Controles.TextBox
    Friend WithEvents lblInterlocutor As Controles.Label
    Friend WithEvents pnlGeneral As Panel
    Friend WithEvents pnlAdjuntos As Panel
    Friend WithEvents pnlAccionesAdjuntos As FlowLayoutPanel
    Friend WithEvents btnAgregarAdjunto As Button
    Friend WithEvents btnQuitarAdjunto As Button
   Friend WithEvents ugAdjuntos As UltraGridSiga
   Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
