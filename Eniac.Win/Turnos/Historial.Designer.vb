<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Historial
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
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoAntecedente")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreAntecedente", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Valor")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Historial))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbAgregar = New System.Windows.Forms.ToolStripButton()
      Me.tsbEliminar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.lsbFechas = New System.Windows.Forms.ListBox()
      Me.grbSocio = New System.Windows.Forms.GroupBox()
      Me.txtCelular = New Eniac.Controles.TextBox()
      Me.lblCelular = New Eniac.Controles.Label()
      Me.txtTelefono = New Eniac.Controles.TextBox()
      Me.lblTelefono = New Eniac.Controles.Label()
      Me.txtDireccion = New Eniac.Controles.TextBox()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.txtNombreSocio = New Eniac.Controles.TextBox()
      Me.txtNroDocumento = New Eniac.Controles.TextBox()
      Me.picImagen = New System.Windows.Forms.PictureBox()
      Me.lblNombreSocio = New Eniac.Controles.Label()
      Me.lblNroDocSocio = New Eniac.Controles.Label()
      Me.rtbItem = New System.Windows.Forms.RichTextBox()
      Me.grbAntecedentes = New System.Windows.Forms.GroupBox()
      Me.ugdAntecedentes = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.txtUsuario = New Eniac.Controles.TextBox()
      Me.lblUsuario = New Eniac.Controles.Label()
      Me.tstBarra.SuspendLayout()
      Me.grbSocio.SuspendLayout()
      CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbAntecedentes.SuspendLayout()
      CType(Me.ugdAntecedentes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAgregar, Me.tsbEliminar, Me.ToolStripSeparator2, Me.tsbCerrar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(739, 29)
      Me.tstBarra.TabIndex = 11
      '
      'tsbAgregar
      '
      Me.tsbAgregar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.tsbAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbAgregar.Name = "tsbAgregar"
      Me.tsbAgregar.Size = New System.Drawing.Size(102, 26)
      Me.tsbAgregar.Text = "&Agregar Item"
      '
      'tsbEliminar
      '
      Me.tsbEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEliminar.Name = "tsbEliminar"
      Me.tsbEliminar.Size = New System.Drawing.Size(103, 26)
      Me.tsbEliminar.Text = "&Eliminar Item"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbCerrar
      '
      Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbCerrar.Name = "tsbCerrar"
      Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
      Me.tsbCerrar.Text = "&Cerrar"
      '
      'lsbFechas
      '
      Me.lsbFechas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lsbFechas.FormattingEnabled = True
      Me.lsbFechas.Location = New System.Drawing.Point(260, 32)
      Me.lsbFechas.Name = "lsbFechas"
      Me.lsbFechas.Size = New System.Drawing.Size(120, 238)
      Me.lsbFechas.TabIndex = 12
      '
      'grbSocio
      '
      Me.grbSocio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbSocio.Controls.Add(Me.txtCelular)
      Me.grbSocio.Controls.Add(Me.lblCelular)
      Me.grbSocio.Controls.Add(Me.txtTelefono)
      Me.grbSocio.Controls.Add(Me.lblTelefono)
      Me.grbSocio.Controls.Add(Me.txtDireccion)
      Me.grbSocio.Controls.Add(Me.lblDireccion)
      Me.grbSocio.Controls.Add(Me.txtNombreSocio)
      Me.grbSocio.Controls.Add(Me.txtNroDocumento)
      Me.grbSocio.Controls.Add(Me.picImagen)
      Me.grbSocio.Controls.Add(Me.lblNombreSocio)
      Me.grbSocio.Controls.Add(Me.lblNroDocSocio)
      Me.grbSocio.Location = New System.Drawing.Point(12, 30)
      Me.grbSocio.Name = "grbSocio"
      Me.grbSocio.Size = New System.Drawing.Size(242, 478)
      Me.grbSocio.TabIndex = 13
      Me.grbSocio.TabStop = False
      Me.grbSocio.Text = "Paciente"
      '
      'txtCelular
      '
      Me.txtCelular.BindearPropiedadControl = Nothing
      Me.txtCelular.BindearPropiedadEntidad = Nothing
      Me.txtCelular.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCelular.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCelular.Formato = ""
      Me.txtCelular.IsDecimal = False
      Me.txtCelular.IsNumber = False
      Me.txtCelular.IsPK = False
      Me.txtCelular.IsRequired = False
      Me.txtCelular.Key = ""
      Me.txtCelular.LabelAsoc = Nothing
      Me.txtCelular.Location = New System.Drawing.Point(16, 385)
      Me.txtCelular.Name = "txtCelular"
      Me.txtCelular.ReadOnly = True
      Me.txtCelular.Size = New System.Drawing.Size(220, 20)
      Me.txtCelular.TabIndex = 49
      Me.txtCelular.TabStop = False
      '
      'lblCelular
      '
      Me.lblCelular.AutoSize = True
      Me.lblCelular.Location = New System.Drawing.Point(13, 369)
      Me.lblCelular.Name = "lblCelular"
      Me.lblCelular.Size = New System.Drawing.Size(39, 13)
      Me.lblCelular.TabIndex = 48
      Me.lblCelular.Text = "Celular"
      '
      'txtTelefono
      '
      Me.txtTelefono.BindearPropiedadControl = Nothing
      Me.txtTelefono.BindearPropiedadEntidad = Nothing
      Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefono.Formato = ""
      Me.txtTelefono.IsDecimal = False
      Me.txtTelefono.IsNumber = False
      Me.txtTelefono.IsPK = False
      Me.txtTelefono.IsRequired = False
      Me.txtTelefono.Key = ""
      Me.txtTelefono.LabelAsoc = Nothing
      Me.txtTelefono.Location = New System.Drawing.Point(16, 345)
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.ReadOnly = True
      Me.txtTelefono.Size = New System.Drawing.Size(220, 20)
      Me.txtTelefono.TabIndex = 47
      Me.txtTelefono.TabStop = False
      '
      'lblTelefono
      '
      Me.lblTelefono.AutoSize = True
      Me.lblTelefono.Location = New System.Drawing.Point(13, 329)
      Me.lblTelefono.Name = "lblTelefono"
      Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
      Me.lblTelefono.TabIndex = 46
      Me.lblTelefono.Text = "Telefono"
      '
      'txtDireccion
      '
      Me.txtDireccion.BindearPropiedadControl = Nothing
      Me.txtDireccion.BindearPropiedadEntidad = Nothing
      Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDireccion.Formato = ""
      Me.txtDireccion.IsDecimal = False
      Me.txtDireccion.IsNumber = False
      Me.txtDireccion.IsPK = False
      Me.txtDireccion.IsRequired = False
      Me.txtDireccion.Key = ""
      Me.txtDireccion.LabelAsoc = Nothing
      Me.txtDireccion.Location = New System.Drawing.Point(16, 306)
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.ReadOnly = True
      Me.txtDireccion.Size = New System.Drawing.Size(220, 20)
      Me.txtDireccion.TabIndex = 45
      Me.txtDireccion.TabStop = False
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.Location = New System.Drawing.Point(13, 290)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblDireccion.TabIndex = 44
      Me.lblDireccion.Text = "Dirección"
      '
      'txtNombreSocio
      '
      Me.txtNombreSocio.BindearPropiedadControl = Nothing
      Me.txtNombreSocio.BindearPropiedadEntidad = Nothing
      Me.txtNombreSocio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreSocio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreSocio.Formato = ""
      Me.txtNombreSocio.IsDecimal = False
      Me.txtNombreSocio.IsNumber = False
      Me.txtNombreSocio.IsPK = False
      Me.txtNombreSocio.IsRequired = False
      Me.txtNombreSocio.Key = ""
      Me.txtNombreSocio.LabelAsoc = Nothing
      Me.txtNombreSocio.Location = New System.Drawing.Point(12, 69)
      Me.txtNombreSocio.Name = "txtNombreSocio"
      Me.txtNombreSocio.ReadOnly = True
      Me.txtNombreSocio.Size = New System.Drawing.Size(220, 20)
      Me.txtNombreSocio.TabIndex = 43
      Me.txtNombreSocio.TabStop = False
      '
      'txtNroDocumento
      '
      Me.txtNroDocumento.BindearPropiedadControl = Nothing
      Me.txtNroDocumento.BindearPropiedadEntidad = Nothing
      Me.txtNroDocumento.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroDocumento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroDocumento.Formato = ""
      Me.txtNroDocumento.IsDecimal = False
      Me.txtNroDocumento.IsNumber = False
      Me.txtNroDocumento.IsPK = False
      Me.txtNroDocumento.IsRequired = False
      Me.txtNroDocumento.Key = ""
      Me.txtNroDocumento.LabelAsoc = Nothing
      Me.txtNroDocumento.Location = New System.Drawing.Point(12, 30)
      Me.txtNroDocumento.Name = "txtNroDocumento"
      Me.txtNroDocumento.ReadOnly = True
      Me.txtNroDocumento.Size = New System.Drawing.Size(116, 20)
      Me.txtNroDocumento.TabIndex = 42
      Me.txtNroDocumento.TabStop = False
      '
      'picImagen
      '
      Me.picImagen.InitialImage = Nothing
      Me.picImagen.Location = New System.Drawing.Point(12, 92)
      Me.picImagen.Name = "picImagen"
      Me.picImagen.Size = New System.Drawing.Size(220, 194)
      Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
      Me.picImagen.TabIndex = 40
      Me.picImagen.TabStop = False
      '
      'lblNombreSocio
      '
      Me.lblNombreSocio.AutoSize = True
      Me.lblNombreSocio.Location = New System.Drawing.Point(9, 53)
      Me.lblNombreSocio.Name = "lblNombreSocio"
      Me.lblNombreSocio.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreSocio.TabIndex = 39
      Me.lblNombreSocio.Text = "Nombre"
      '
      'lblNroDocSocio
      '
      Me.lblNroDocSocio.AutoSize = True
      Me.lblNroDocSocio.Location = New System.Drawing.Point(8, 14)
      Me.lblNroDocSocio.Name = "lblNroDocSocio"
      Me.lblNroDocSocio.Size = New System.Drawing.Size(40, 13)
      Me.lblNroDocSocio.TabIndex = 38
      Me.lblNroDocSocio.Text = "Codigo"
      '
      'rtbItem
      '
      Me.rtbItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.rtbItem.Location = New System.Drawing.Point(386, 30)
      Me.rtbItem.Name = "rtbItem"
      Me.rtbItem.ReadOnly = True
      Me.rtbItem.Size = New System.Drawing.Size(341, 274)
      Me.rtbItem.TabIndex = 14
      Me.rtbItem.Text = ""
      '
      'grbAntecedentes
      '
      Me.grbAntecedentes.Controls.Add(Me.ugdAntecedentes)
      Me.grbAntecedentes.Location = New System.Drawing.Point(260, 310)
      Me.grbAntecedentes.Name = "grbAntecedentes"
      Me.grbAntecedentes.Size = New System.Drawing.Size(467, 198)
      Me.grbAntecedentes.TabIndex = 15
      Me.grbAntecedentes.TabStop = False
      Me.grbAntecedentes.Text = "Antecentes"
      '
      'ugdAntecedentes
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugdAntecedentes.DisplayLayout.Appearance = Appearance1
      Me.ugdAntecedentes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.Header.Caption = "Tipo"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Width = 82
      UltraGridColumn2.Header.Caption = "Antecedente"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 211
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 79
      UltraGridColumn4.Header.Caption = "Fecha Act."
      UltraGridColumn4.Header.VisiblePosition = 3
      UltraGridColumn4.Width = 81
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
      Me.ugdAntecedentes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugdAntecedentes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugdAntecedentes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugdAntecedentes.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugdAntecedentes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugdAntecedentes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugdAntecedentes.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aquí para agrupar."
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugdAntecedentes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugdAntecedentes.DisplayLayout.MaxColScrollRegions = 1
      Me.ugdAntecedentes.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugdAntecedentes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugdAntecedentes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugdAntecedentes.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugdAntecedentes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugdAntecedentes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugdAntecedentes.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugdAntecedentes.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugdAntecedentes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugdAntecedentes.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugdAntecedentes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugdAntecedentes.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugdAntecedentes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugdAntecedentes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugdAntecedentes.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugdAntecedentes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugdAntecedentes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugdAntecedentes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugdAntecedentes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugdAntecedentes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugdAntecedentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugdAntecedentes.Location = New System.Drawing.Point(6, 19)
      Me.ugdAntecedentes.Name = "ugdAntecedentes"
      Me.ugdAntecedentes.Size = New System.Drawing.Size(455, 173)
      Me.ugdAntecedentes.TabIndex = 1
      Me.ugdAntecedentes.Text = "UltraGrid1"
      '
      'txtUsuario
      '
      Me.txtUsuario.BindearPropiedadControl = Nothing
      Me.txtUsuario.BindearPropiedadEntidad = Nothing
      Me.txtUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUsuario.Formato = ""
      Me.txtUsuario.IsDecimal = False
      Me.txtUsuario.IsNumber = False
      Me.txtUsuario.IsPK = False
      Me.txtUsuario.IsRequired = False
      Me.txtUsuario.Key = ""
      Me.txtUsuario.LabelAsoc = Nothing
      Me.txtUsuario.Location = New System.Drawing.Point(263, 284)
      Me.txtUsuario.Name = "txtUsuario"
      Me.txtUsuario.ReadOnly = True
      Me.txtUsuario.Size = New System.Drawing.Size(120, 20)
      Me.txtUsuario.TabIndex = 49
      Me.txtUsuario.TabStop = False
      '
      'lblUsuario
      '
      Me.lblUsuario.AutoSize = True
      Me.lblUsuario.Location = New System.Drawing.Point(260, 271)
      Me.lblUsuario.Name = "lblUsuario"
      Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
      Me.lblUsuario.TabIndex = 48
      Me.lblUsuario.Text = "Usuario"
      '
      'Historial
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(739, 510)
      Me.Controls.Add(Me.txtUsuario)
      Me.Controls.Add(Me.lblUsuario)
      Me.Controls.Add(Me.grbAntecedentes)
      Me.Controls.Add(Me.rtbItem)
      Me.Controls.Add(Me.grbSocio)
      Me.Controls.Add(Me.lsbFechas)
      Me.Controls.Add(Me.tstBarra)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Historial"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Historial"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.grbSocio.ResumeLayout(False)
      Me.grbSocio.PerformLayout()
      CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbAntecedentes.ResumeLayout(False)
      CType(Me.ugdAntecedentes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents lsbFechas As System.Windows.Forms.ListBox
   Friend WithEvents grbSocio As System.Windows.Forms.GroupBox
   Friend WithEvents picImagen As System.Windows.Forms.PictureBox
   Friend WithEvents lblNombreSocio As Eniac.Controles.Label
   Friend WithEvents lblNroDocSocio As Eniac.Controles.Label
   Friend WithEvents txtNombreSocio As Eniac.Controles.TextBox
   Friend WithEvents txtNroDocumento As Eniac.Controles.TextBox
   Friend WithEvents rtbItem As System.Windows.Forms.RichTextBox
   Friend WithEvents tsbAgregar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbEliminar As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtCelular As Eniac.Controles.TextBox
   Friend WithEvents lblCelular As Eniac.Controles.Label
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents grbAntecedentes As System.Windows.Forms.GroupBox
   Friend WithEvents txtUsuario As Eniac.Controles.TextBox
   Friend WithEvents lblUsuario As Eniac.Controles.Label
   Friend WithEvents ugdAntecedentes As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
