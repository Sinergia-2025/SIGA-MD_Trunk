<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PasajerosAyuda
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
   '<System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Sel")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoCliente")
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasajerosAyuda))
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.chbTodos = New Eniac.Controles.CheckBox()
      Me.pnlPrincipal = New System.Windows.Forms.Panel()
      Me.ugPasajeros = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
      Me.bscNombreZonaGeografica2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoZonaGeografica2 = New Eniac.Controles.Buscador2()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.txtNombrePasajero = New Eniac.Controles.TextBox()
      Me.lblNombrePasajero = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.stsStado.SuspendLayout()
      Me.pnlPrincipal.SuspendLayout()
      CType(Me.ugPasajeros, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(805, 380)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 3
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(700, 380)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(99, 30)
      Me.btnAceptar.TabIndex = 2
      Me.btnAceptar.Text = "&Aceptar (F4)"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 535)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(902, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(823, 17)
      Me.tssInfo.Spring = True
      '
      'tspBarra
      '
      Me.tspBarra.Name = "tspBarra"
      Me.tspBarra.Size = New System.Drawing.Size(100, 16)
      Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.tspBarra.Visible = False
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tssRegistros.Text = "0 Registros"
      '
      'chbTodos
      '
      Me.chbTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.chbTodos.BindearPropiedadControl = Nothing
      Me.chbTodos.BindearPropiedadEntidad = Nothing
      Me.chbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbTodos.ImageIndex = 1
      Me.chbTodos.IsPK = False
      Me.chbTodos.IsRequired = False
      Me.chbTodos.Key = Nothing
      Me.chbTodos.LabelAsoc = Nothing
      Me.chbTodos.Location = New System.Drawing.Point(12, 380)
      Me.chbTodos.Name = "chbTodos"
      Me.chbTodos.Size = New System.Drawing.Size(126, 24)
      Me.chbTodos.TabIndex = 1
      Me.chbTodos.Text = "Chequear Todos"
      Me.chbTodos.UseVisualStyleBackColor = True
      '
      'pnlPrincipal
      '
      Me.pnlPrincipal.Controls.Add(Me.ugPasajeros)
      Me.pnlPrincipal.Controls.Add(Me.btnAceptar)
      Me.pnlPrincipal.Controls.Add(Me.chbTodos)
      Me.pnlPrincipal.Controls.Add(Me.btnCancelar)
      Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlPrincipal.Location = New System.Drawing.Point(0, 113)
      Me.pnlPrincipal.Name = "pnlPrincipal"
      Me.pnlPrincipal.Size = New System.Drawing.Size(902, 422)
      Me.pnlPrincipal.TabIndex = 1
      '
      'ugPasajeros
      '
      Me.ugPasajeros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugPasajeros.DisplayLayout.Appearance = Appearance1
      Me.ugPasajeros.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn1.Header.Caption = "Codigo"
      UltraGridColumn1.Header.VisiblePosition = 1
      UltraGridColumn1.Width = 80
      UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn2.Header.Caption = "Cliente"
      UltraGridColumn2.Header.VisiblePosition = 2
      UltraGridColumn2.Width = 247
      UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn3.Header.Caption = "Categoria"
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.Width = 111
      UltraGridColumn7.Header.Caption = "Zona Geográfica"
      UltraGridColumn7.Header.VisiblePosition = 4
      UltraGridColumn7.Width = 110
      UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn4.Header.VisiblePosition = 5
      UltraGridColumn4.Hidden = True
      UltraGridColumn4.Width = 187
      UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn5.Header.Caption = "Localidad"
      UltraGridColumn5.Header.VisiblePosition = 6
      UltraGridColumn5.Width = 94
      UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn6.Header.Caption = "Provincia"
      UltraGridColumn6.Header.VisiblePosition = 7
      UltraGridColumn6.Width = 97
      UltraGridColumn8.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
      UltraGridColumn8.Header.VisiblePosition = 0
      UltraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn8.Width = 30
      UltraGridColumn9.Header.Caption = "Tipo de Cliente"
      UltraGridColumn9.Header.VisiblePosition = 8
      UltraGridColumn9.Width = 107
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn7, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn8, UltraGridColumn9})
      Me.ugPasajeros.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugPasajeros.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugPasajeros.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugPasajeros.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugPasajeros.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugPasajeros.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugPasajeros.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugPasajeros.DisplayLayout.MaxColScrollRegions = 1
      Me.ugPasajeros.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugPasajeros.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugPasajeros.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugPasajeros.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugPasajeros.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugPasajeros.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugPasajeros.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugPasajeros.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugPasajeros.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugPasajeros.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugPasajeros.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugPasajeros.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugPasajeros.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugPasajeros.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugPasajeros.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugPasajeros.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugPasajeros.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugPasajeros.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugPasajeros.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugPasajeros.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugPasajeros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugPasajeros.Location = New System.Drawing.Point(12, 12)
      Me.ugPasajeros.Name = "ugPasajeros"
      Me.ugPasajeros.Size = New System.Drawing.Size(878, 362)
      Me.ugPasajeros.TabIndex = 0
      Me.ugPasajeros.Text = "UltraGrid1"
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.txtNombrePasajero)
      Me.Panel1.Controls.Add(Me.lblNombrePasajero)
      Me.Panel1.Controls.Add(Me.chkExpandAll)
      Me.Panel1.Controls.Add(Me.btnConsultar)
      Me.Panel1.Controls.Add(Me.chbZonaGeografica)
      Me.Panel1.Controls.Add(Me.bscNombreZonaGeografica2)
      Me.Panel1.Controls.Add(Me.bscCodigoZonaGeografica2)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 29)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(902, 84)
      Me.Panel1.TabIndex = 0
      '
      'chbZonaGeografica
      '
      Me.chbZonaGeografica.AutoSize = True
      Me.chbZonaGeografica.BindearPropiedadControl = Nothing
      Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
      Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbZonaGeografica.IsPK = False
      Me.chbZonaGeografica.IsRequired = False
      Me.chbZonaGeografica.Key = Nothing
      Me.chbZonaGeografica.LabelAsoc = Nothing
      Me.chbZonaGeografica.Location = New System.Drawing.Point(12, 14)
      Me.chbZonaGeografica.Name = "chbZonaGeografica"
      Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
      Me.chbZonaGeografica.TabIndex = 0
      Me.chbZonaGeografica.Text = "Zona Geográfica"
      '
      'bscNombreZonaGeografica2
      '
      Me.bscNombreZonaGeografica2.ActivarFiltroEnGrilla = True
      Me.bscNombreZonaGeografica2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscNombreZonaGeografica2.BindearPropiedadControl = Nothing
      Me.bscNombreZonaGeografica2.BindearPropiedadEntidad = Nothing
      Me.bscNombreZonaGeografica2.ConfigBuscador = Nothing
      Me.bscNombreZonaGeografica2.Datos = Nothing
      Me.bscNombreZonaGeografica2.FilaDevuelta = Nothing
      Me.bscNombreZonaGeografica2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreZonaGeografica2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreZonaGeografica2.IsDecimal = False
      Me.bscNombreZonaGeografica2.IsNumber = False
      Me.bscNombreZonaGeografica2.IsPK = False
      Me.bscNombreZonaGeografica2.IsRequired = True
      Me.bscNombreZonaGeografica2.Key = ""
      Me.bscNombreZonaGeografica2.LabelAsoc = Me.chbZonaGeografica
      Me.bscNombreZonaGeografica2.Location = New System.Drawing.Point(229, 12)
      Me.bscNombreZonaGeografica2.MaxLengh = "32767"
      Me.bscNombreZonaGeografica2.Name = "bscNombreZonaGeografica2"
      Me.bscNombreZonaGeografica2.Permitido = False
      Me.bscNombreZonaGeografica2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreZonaGeografica2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreZonaGeografica2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreZonaGeografica2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreZonaGeografica2.Selecciono = False
      Me.bscNombreZonaGeografica2.Size = New System.Drawing.Size(276, 20)
      Me.bscNombreZonaGeografica2.TabIndex = 2
      '
      'bscCodigoZonaGeografica2
      '
      Me.bscCodigoZonaGeografica2.ActivarFiltroEnGrilla = True
      Me.bscCodigoZonaGeografica2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCodigoZonaGeografica2.BindearPropiedadControl = Nothing
      Me.bscCodigoZonaGeografica2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoZonaGeografica2.ConfigBuscador = Nothing
      Me.bscCodigoZonaGeografica2.Datos = Nothing
      Me.bscCodigoZonaGeografica2.FilaDevuelta = Nothing
      Me.bscCodigoZonaGeografica2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoZonaGeografica2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoZonaGeografica2.IsDecimal = False
      Me.bscCodigoZonaGeografica2.IsNumber = False
      Me.bscCodigoZonaGeografica2.IsPK = False
      Me.bscCodigoZonaGeografica2.IsRequired = True
      Me.bscCodigoZonaGeografica2.Key = ""
      Me.bscCodigoZonaGeografica2.LabelAsoc = Me.chbZonaGeografica
      Me.bscCodigoZonaGeografica2.Location = New System.Drawing.Point(124, 12)
      Me.bscCodigoZonaGeografica2.MaxLengh = "32767"
      Me.bscCodigoZonaGeografica2.Name = "bscCodigoZonaGeografica2"
      Me.bscCodigoZonaGeografica2.Permitido = False
      Me.bscCodigoZonaGeografica2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoZonaGeografica2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoZonaGeografica2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoZonaGeografica2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoZonaGeografica2.Selecciono = False
      Me.bscCodigoZonaGeografica2.Size = New System.Drawing.Size(99, 20)
      Me.bscCodigoZonaGeografica2.TabIndex = 1
      '
      'chkExpandAll
      '
      Me.chkExpandAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkExpandAll.AutoSize = True
      Me.chkExpandAll.Location = New System.Drawing.Point(790, 61)
      Me.chkExpandAll.Name = "chkExpandAll"
      Me.chkExpandAll.Size = New System.Drawing.Size(91, 17)
      Me.chkExpandAll.TabIndex = 6
      Me.chkExpandAll.Text = "Expandir todo"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(790, 10)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 5
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'txtNombrePasajero
      '
      Me.txtNombrePasajero.BindearPropiedadControl = ""
      Me.txtNombrePasajero.BindearPropiedadEntidad = ""
      Me.txtNombrePasajero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombrePasajero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombrePasajero.Formato = ""
      Me.txtNombrePasajero.IsDecimal = False
      Me.txtNombrePasajero.IsNumber = False
      Me.txtNombrePasajero.IsPK = False
      Me.txtNombrePasajero.IsRequired = False
      Me.txtNombrePasajero.Key = ""
      Me.txtNombrePasajero.LabelAsoc = Me.lblNombrePasajero
      Me.txtNombrePasajero.Location = New System.Drawing.Point(124, 38)
      Me.txtNombrePasajero.MaxLength = 200
      Me.txtNombrePasajero.Name = "txtNombrePasajero"
      Me.txtNombrePasajero.Size = New System.Drawing.Size(381, 20)
      Me.txtNombrePasajero.TabIndex = 4
      '
      'lblNombrePasajero
      '
      Me.lblNombrePasajero.AutoSize = True
      Me.lblNombrePasajero.LabelAsoc = Nothing
      Me.lblNombrePasajero.Location = New System.Drawing.Point(12, 41)
      Me.lblNombrePasajero.Name = "lblNombrePasajero"
      Me.lblNombrePasajero.Size = New System.Drawing.Size(94, 13)
      Me.lblNombrePasajero.TabIndex = 3
      Me.lblNombrePasajero.Text = "Nombre (contiene)"
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(902, 29)
      Me.tstBarra.TabIndex = 3
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
      '
      'PasajerosAyuda
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(902, 557)
      Me.Controls.Add(Me.pnlPrincipal)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.stsStado)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PasajerosAyuda"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Carga de Pasajeros Masiva"
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.pnlPrincipal.ResumeLayout(False)
      CType(Me.ugPasajeros, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbTodos As Eniac.Controles.CheckBox
   Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
   Friend WithEvents ugPasajeros As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents Panel1 As Panel
   Friend WithEvents chbZonaGeografica As Controles.CheckBox
   Friend WithEvents bscNombreZonaGeografica2 As Controles.Buscador2
   Friend WithEvents bscCodigoZonaGeografica2 As Controles.Buscador2
   Protected WithEvents chkExpandAll As CheckBox
   Protected WithEvents btnConsultar As Controles.Button
   Friend WithEvents txtNombrePasajero As Controles.TextBox
   Friend WithEvents lblNombrePasajero As Controles.Label
   Public WithEvents tstBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
End Class
