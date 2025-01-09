<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRMTiposNovedadesDetalle
   Inherits BaseDetalle

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
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoNovedad")
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdNombreDinamico")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsRequerido")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
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
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtNombrePlanCuenta = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.txtIdPlanCuenta = New Eniac.Controles.TextBox()
      Me.ugDinamicos = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.cmbDinamicos = New Eniac.Controles.ComboBox()
      Me.btnEliminar = New Eniac.Controles.Button()
      Me.btnInsertar = New Eniac.Controles.Button()
      Me.chbRequerido = New Eniac.Controles.CheckBox()
      Me.lblUnidadDeMedida = New Eniac.Controles.Label()
      Me.txtUnidadDeMedida = New Eniac.Controles.TextBox()
      Me.grbDinamicos = New System.Windows.Forms.GroupBox()
      Me.lblOrden = New Eniac.Controles.Label()
      Me.txtOrden = New Eniac.Controles.TextBox()
      Me.chbUsuarioPorDefecto = New Eniac.Controles.CheckBox()
      Me.chbUsuarioRequerido = New Eniac.Controles.CheckBox()
      Me.chbProximoContactoRequerido = New Eniac.Controles.CheckBox()
      Me.cmbPrimerOrdenGrilla = New Eniac.Controles.ComboBox()
      Me.lblPrimerOrdenGrilla = New Eniac.Controles.Label()
      Me.grbOrdenGrilla = New System.Windows.Forms.GroupBox()
      Me.cmbVisualizaSucursal = New Eniac.Controles.ComboBox()
      Me.lblSegundoOrdenGrilla = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.cmbSolapaPorDefecto = New Eniac.Controles.ComboBox()
      Me.lblSolapaPorDefecto = New Eniac.Controles.Label()
      Me.chbVisualizaRevisionAdministrativa = New Eniac.Controles.CheckBox()
      Me.chbVisualizaOtrasNovedades = New Eniac.Controles.CheckBox()
      Me.chbUsaSegundoOrden = New Eniac.Controles.CheckBox()
      Me.chbSegundoOrdenDesc = New Eniac.Controles.CheckBox()
      Me.cmbSegundoOrdenGrilla = New Eniac.Controles.ComboBox()
      Me.chbPrimerOrdenDesc = New Eniac.Controles.CheckBox()
      Me.chbPermiteBorrarComentarios = New Eniac.Controles.CheckBox()
      Me.txtDiasProximoContacto = New Eniac.Controles.TextBox()
      Me.lblDiasProximoContacto = New Eniac.Controles.Label()
      Me.chbPermiteIngresarNumero = New Eniac.Controles.CheckBox()
      Me.chbReportaAvance = New Eniac.Controles.CheckBox()
      Me.chbReportaCantidad = New Eniac.Controles.CheckBox()
      Me.chbVercambios = New Eniac.Controles.CheckBox()
      Me.chbRequierePadre = New Eniac.Controles.CheckBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtReporte = New Eniac.Controles.TextBox()
      Me.chbEmbebido = New Eniac.Controles.CheckBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtCantidadCopias = New Eniac.Controles.TextBox()
      CType(Me.ugDinamicos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDinamicos.SuspendLayout()
      Me.grbOrdenGrilla.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(614, 384)
      Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.btnAceptar.TabIndex = 24
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(700, 384)
      Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.btnCancelar.TabIndex = 25
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(513, 384)
      Me.btnCopiar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.btnCopiar.TabIndex = 26
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(452, 384)
      Me.btnAplicar.TabIndex = 27
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.LabelAsoc = Nothing
      Me.lblDescripcion.Location = New System.Drawing.Point(14, 44)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtNombrePlanCuenta
      '
      Me.txtNombrePlanCuenta.BindearPropiedadControl = "Text"
      Me.txtNombrePlanCuenta.BindearPropiedadEntidad = "NombreTipoNovedad"
      Me.txtNombrePlanCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombrePlanCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombrePlanCuenta.Formato = ""
      Me.txtNombrePlanCuenta.IsDecimal = False
      Me.txtNombrePlanCuenta.IsNumber = False
      Me.txtNombrePlanCuenta.IsPK = False
      Me.txtNombrePlanCuenta.IsRequired = True
      Me.txtNombrePlanCuenta.Key = ""
      Me.txtNombrePlanCuenta.LabelAsoc = Me.lblDescripcion
      Me.txtNombrePlanCuenta.Location = New System.Drawing.Point(97, 41)
      Me.txtNombrePlanCuenta.MaxLength = 30
      Me.txtNombrePlanCuenta.Name = "txtNombrePlanCuenta"
      Me.txtNombrePlanCuenta.Size = New System.Drawing.Size(264, 20)
      Me.txtNombrePlanCuenta.TabIndex = 3
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(14, 18)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Codigo"
      '
      'txtIdPlanCuenta
      '
      Me.txtIdPlanCuenta.BindearPropiedadControl = "Text"
      Me.txtIdPlanCuenta.BindearPropiedadEntidad = "IdTipoNovedad"
      Me.txtIdPlanCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdPlanCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdPlanCuenta.Formato = ""
      Me.txtIdPlanCuenta.IsDecimal = False
      Me.txtIdPlanCuenta.IsNumber = False
      Me.txtIdPlanCuenta.IsPK = True
      Me.txtIdPlanCuenta.IsRequired = True
      Me.txtIdPlanCuenta.Key = ""
      Me.txtIdPlanCuenta.LabelAsoc = Me.lblCodigo
      Me.txtIdPlanCuenta.Location = New System.Drawing.Point(97, 15)
      Me.txtIdPlanCuenta.MaxLength = 10
      Me.txtIdPlanCuenta.Name = "txtIdPlanCuenta"
      Me.txtIdPlanCuenta.Size = New System.Drawing.Size(154, 20)
      Me.txtIdPlanCuenta.TabIndex = 1
      '
      'ugDinamicos
      '
      Me.ugDinamicos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDinamicos.DisplayLayout.Appearance = Appearance1
      Me.ugDinamicos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
      UltraGridColumn1.Header.Caption = "Tipo Novedad"
      UltraGridColumn1.Header.VisiblePosition = 0
      UltraGridColumn1.Hidden = True
      UltraGridColumn2.Header.Caption = "Dinámico"
      UltraGridColumn2.Header.VisiblePosition = 1
      UltraGridColumn2.Width = 250
      Appearance2.TextHAlignAsString = "Center"
      UltraGridColumn3.CellAppearance = Appearance2
      UltraGridColumn3.Header.Caption = "Requerido"
      UltraGridColumn3.Header.VisiblePosition = 3
      UltraGridColumn3.MaxWidth = 70
      UltraGridColumn3.MinWidth = 70
      UltraGridColumn3.Width = 70
      UltraGridColumn4.Header.VisiblePosition = 4
      UltraGridColumn4.Hidden = True
      UltraGridColumn4.Width = 53
      UltraGridColumn5.Header.VisiblePosition = 5
      UltraGridColumn5.Hidden = True
      UltraGridColumn5.Width = 70
      UltraGridColumn6.Header.VisiblePosition = 6
      UltraGridColumn6.Hidden = True
      UltraGridColumn6.Width = 69
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn7.CellAppearance = Appearance3
      UltraGridColumn7.Header.VisiblePosition = 2
      UltraGridColumn7.MaxWidth = 43
      UltraGridColumn7.MinWidth = 43
      UltraGridColumn7.Width = 43
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7})
      Me.ugDinamicos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDinamicos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDinamicos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance4.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDinamicos.DisplayLayout.GroupByBox.Appearance = Appearance4
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDinamicos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
      Me.ugDinamicos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDinamicos.DisplayLayout.GroupByBox.Hidden = True
      Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance6.BackColor2 = System.Drawing.SystemColors.Control
      Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDinamicos.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
      Me.ugDinamicos.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDinamicos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDinamicos.DisplayLayout.Override.ActiveCellAppearance = Appearance7
      Appearance8.BackColor = System.Drawing.SystemColors.Highlight
      Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDinamicos.DisplayLayout.Override.ActiveRowAppearance = Appearance8
      Me.ugDinamicos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDinamicos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDinamicos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDinamicos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDinamicos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance9.BackColor = System.Drawing.SystemColors.Window
      Me.ugDinamicos.DisplayLayout.Override.CardAreaAppearance = Appearance9
      Appearance10.BorderColor = System.Drawing.Color.Silver
      Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDinamicos.DisplayLayout.Override.CellAppearance = Appearance10
      Me.ugDinamicos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.ugDinamicos.DisplayLayout.Override.CellPadding = 0
      Appearance11.BackColor = System.Drawing.SystemColors.Control
      Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance11.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDinamicos.DisplayLayout.Override.GroupByRowAppearance = Appearance11
      Appearance12.TextHAlignAsString = "Left"
      Me.ugDinamicos.DisplayLayout.Override.HeaderAppearance = Appearance12
      Me.ugDinamicos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDinamicos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.Color.Silver
      Me.ugDinamicos.DisplayLayout.Override.RowAppearance = Appearance13
      Me.ugDinamicos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDinamicos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
      Me.ugDinamicos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDinamicos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDinamicos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDinamicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDinamicos.Location = New System.Drawing.Point(5, 61)
      Me.ugDinamicos.Name = "ugDinamicos"
      Me.ugDinamicos.Size = New System.Drawing.Size(365, 296)
      Me.ugDinamicos.TabIndex = 6
      Me.ugDinamicos.Text = "UltraGrid1"
      '
      'cmbDinamicos
      '
      Me.cmbDinamicos.BindearPropiedadControl = Nothing
      Me.cmbDinamicos.BindearPropiedadEntidad = Nothing
      Me.cmbDinamicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDinamicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbDinamicos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbDinamicos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbDinamicos.FormattingEnabled = True
      Me.cmbDinamicos.IsPK = False
      Me.cmbDinamicos.IsRequired = False
      Me.cmbDinamicos.Key = Nothing
      Me.cmbDinamicos.LabelAsoc = Nothing
      Me.cmbDinamicos.Location = New System.Drawing.Point(9, 27)
      Me.cmbDinamicos.Name = "cmbDinamicos"
      Me.cmbDinamicos.Size = New System.Drawing.Size(157, 21)
      Me.cmbDinamicos.TabIndex = 0
      '
      'btnEliminar
      '
      Me.btnEliminar.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
      Me.btnEliminar.Location = New System.Drawing.Point(332, 18)
      Me.btnEliminar.Name = "btnEliminar"
      Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminar.TabIndex = 5
      Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminar.UseVisualStyleBackColor = True
      '
      'btnInsertar
      '
      Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
      Me.btnInsertar.Location = New System.Drawing.Point(291, 18)
      Me.btnInsertar.Name = "btnInsertar"
      Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertar.TabIndex = 4
      Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertar.UseVisualStyleBackColor = True
      '
      'chbRequerido
      '
      Me.chbRequerido.AutoSize = True
      Me.chbRequerido.BindearPropiedadControl = Nothing
      Me.chbRequerido.BindearPropiedadEntidad = Nothing
      Me.chbRequerido.Checked = True
      Me.chbRequerido.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbRequerido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRequerido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRequerido.IsPK = False
      Me.chbRequerido.IsRequired = False
      Me.chbRequerido.Key = Nothing
      Me.chbRequerido.LabelAsoc = Nothing
      Me.chbRequerido.Location = New System.Drawing.Point(211, 28)
      Me.chbRequerido.Name = "chbRequerido"
      Me.chbRequerido.Size = New System.Drawing.Size(75, 17)
      Me.chbRequerido.TabIndex = 3
      Me.chbRequerido.Text = "Requerido"
      Me.chbRequerido.UseVisualStyleBackColor = True
      '
      'lblUnidadDeMedida
      '
      Me.lblUnidadDeMedida.AutoSize = True
      Me.lblUnidadDeMedida.LabelAsoc = Nothing
      Me.lblUnidadDeMedida.Location = New System.Drawing.Point(284, 140)
      Me.lblUnidadDeMedida.Name = "lblUnidadDeMedida"
      Me.lblUnidadDeMedida.Size = New System.Drawing.Size(30, 13)
      Me.lblUnidadDeMedida.TabIndex = 13
      Me.lblUnidadDeMedida.Text = "U.M."
      '
      'txtUnidadDeMedida
      '
      Me.txtUnidadDeMedida.BindearPropiedadControl = "Text"
      Me.txtUnidadDeMedida.BindearPropiedadEntidad = "UnidadDeMedida"
      Me.txtUnidadDeMedida.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUnidadDeMedida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUnidadDeMedida.Formato = ""
      Me.txtUnidadDeMedida.IsDecimal = False
      Me.txtUnidadDeMedida.IsNumber = False
      Me.txtUnidadDeMedida.IsPK = False
      Me.txtUnidadDeMedida.IsRequired = True
      Me.txtUnidadDeMedida.Key = ""
      Me.txtUnidadDeMedida.LabelAsoc = Me.lblUnidadDeMedida
      Me.txtUnidadDeMedida.Location = New System.Drawing.Point(321, 136)
      Me.txtUnidadDeMedida.MaxLength = 5
      Me.txtUnidadDeMedida.Name = "txtUnidadDeMedida"
      Me.txtUnidadDeMedida.Size = New System.Drawing.Size(40, 20)
      Me.txtUnidadDeMedida.TabIndex = 14
      Me.txtUnidadDeMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'grbDinamicos
      '
      Me.grbDinamicos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.grbDinamicos.Controls.Add(Me.cmbDinamicos)
      Me.grbDinamicos.Controls.Add(Me.chbRequerido)
      Me.grbDinamicos.Controls.Add(Me.btnInsertar)
      Me.grbDinamicos.Controls.Add(Me.ugDinamicos)
      Me.grbDinamicos.Controls.Add(Me.btnEliminar)
      Me.grbDinamicos.Controls.Add(Me.lblOrden)
      Me.grbDinamicos.Controls.Add(Me.txtOrden)
      Me.grbDinamicos.Location = New System.Drawing.Point(371, 15)
      Me.grbDinamicos.Name = "grbDinamicos"
      Me.grbDinamicos.Size = New System.Drawing.Size(379, 365)
      Me.grbDinamicos.TabIndex = 23
      Me.grbDinamicos.TabStop = False
      Me.grbDinamicos.Text = "Dinámicos"
      '
      'lblOrden
      '
      Me.lblOrden.AutoSize = True
      Me.lblOrden.LabelAsoc = Nothing
      Me.lblOrden.Location = New System.Drawing.Point(169, 11)
      Me.lblOrden.Name = "lblOrden"
      Me.lblOrden.Size = New System.Drawing.Size(36, 13)
      Me.lblOrden.TabIndex = 1
      Me.lblOrden.Text = "Orden"
      '
      'txtOrden
      '
      Me.txtOrden.BindearPropiedadControl = ""
      Me.txtOrden.BindearPropiedadEntidad = ""
      Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
      Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtOrden.Formato = ""
      Me.txtOrden.IsDecimal = False
      Me.txtOrden.IsNumber = True
      Me.txtOrden.IsPK = False
      Me.txtOrden.IsRequired = True
      Me.txtOrden.Key = ""
      Me.txtOrden.LabelAsoc = Me.lblOrden
      Me.txtOrden.Location = New System.Drawing.Point(172, 27)
      Me.txtOrden.MaxLength = 5
      Me.txtOrden.Name = "txtOrden"
      Me.txtOrden.Size = New System.Drawing.Size(33, 20)
      Me.txtOrden.TabIndex = 2
      Me.txtOrden.Text = "1"
      Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbUsuarioPorDefecto
      '
      Me.chbUsuarioPorDefecto.AutoSize = True
      Me.chbUsuarioPorDefecto.BindearPropiedadControl = "Checked"
      Me.chbUsuarioPorDefecto.BindearPropiedadEntidad = "UsuarioPorDefecto"
      Me.chbUsuarioPorDefecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuarioPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuarioPorDefecto.IsPK = False
      Me.chbUsuarioPorDefecto.IsRequired = False
      Me.chbUsuarioPorDefecto.Key = Nothing
      Me.chbUsuarioPorDefecto.LabelAsoc = Nothing
      Me.chbUsuarioPorDefecto.Location = New System.Drawing.Point(17, 69)
      Me.chbUsuarioPorDefecto.Name = "chbUsuarioPorDefecto"
      Me.chbUsuarioPorDefecto.Size = New System.Drawing.Size(151, 17)
      Me.chbUsuarioPorDefecto.TabIndex = 4
      Me.chbUsuarioPorDefecto.Text = "Usuario actual por defecto"
      Me.chbUsuarioPorDefecto.UseVisualStyleBackColor = True
      '
      'chbUsuarioRequerido
      '
      Me.chbUsuarioRequerido.AutoSize = True
      Me.chbUsuarioRequerido.BindearPropiedadControl = "Checked"
      Me.chbUsuarioRequerido.BindearPropiedadEntidad = "UsuarioRequerido"
      Me.chbUsuarioRequerido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuarioRequerido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuarioRequerido.IsPK = False
      Me.chbUsuarioRequerido.IsRequired = False
      Me.chbUsuarioRequerido.Key = Nothing
      Me.chbUsuarioRequerido.LabelAsoc = Nothing
      Me.chbUsuarioRequerido.Location = New System.Drawing.Point(173, 69)
      Me.chbUsuarioRequerido.Name = "chbUsuarioRequerido"
      Me.chbUsuarioRequerido.Size = New System.Drawing.Size(114, 17)
      Me.chbUsuarioRequerido.TabIndex = 5
      Me.chbUsuarioRequerido.Text = "Usuario Requerido"
      Me.chbUsuarioRequerido.UseVisualStyleBackColor = True
      '
      'chbProximoContactoRequerido
      '
      Me.chbProximoContactoRequerido.AutoSize = True
      Me.chbProximoContactoRequerido.BindearPropiedadControl = "Checked"
      Me.chbProximoContactoRequerido.BindearPropiedadEntidad = "ProximoContactoRequerido"
      Me.chbProximoContactoRequerido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProximoContactoRequerido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProximoContactoRequerido.IsPK = False
      Me.chbProximoContactoRequerido.IsRequired = False
      Me.chbProximoContactoRequerido.Key = Nothing
      Me.chbProximoContactoRequerido.LabelAsoc = Nothing
      Me.chbProximoContactoRequerido.Location = New System.Drawing.Point(17, 115)
      Me.chbProximoContactoRequerido.Name = "chbProximoContactoRequerido"
      Me.chbProximoContactoRequerido.Size = New System.Drawing.Size(209, 17)
      Me.chbProximoContactoRequerido.TabIndex = 8
      Me.chbProximoContactoRequerido.Text = "Fecha de Próximo Contacto Requerida"
      Me.chbProximoContactoRequerido.UseVisualStyleBackColor = True
      '
      'cmbPrimerOrdenGrilla
      '
      Me.cmbPrimerOrdenGrilla.BindearPropiedadControl = "SelectedValue"
      Me.cmbPrimerOrdenGrilla.BindearPropiedadEntidad = "PrimerOrdenGrilla"
      Me.cmbPrimerOrdenGrilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPrimerOrdenGrilla.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPrimerOrdenGrilla.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPrimerOrdenGrilla.FormattingEnabled = True
      Me.cmbPrimerOrdenGrilla.IsPK = False
      Me.cmbPrimerOrdenGrilla.IsRequired = True
      Me.cmbPrimerOrdenGrilla.Key = Nothing
      Me.cmbPrimerOrdenGrilla.LabelAsoc = Me.lblPrimerOrdenGrilla
      Me.cmbPrimerOrdenGrilla.Location = New System.Drawing.Point(10, 30)
      Me.cmbPrimerOrdenGrilla.Name = "cmbPrimerOrdenGrilla"
      Me.cmbPrimerOrdenGrilla.Size = New System.Drawing.Size(176, 21)
      Me.cmbPrimerOrdenGrilla.TabIndex = 1
      '
      'lblPrimerOrdenGrilla
      '
      Me.lblPrimerOrdenGrilla.AutoSize = True
      Me.lblPrimerOrdenGrilla.LabelAsoc = Nothing
      Me.lblPrimerOrdenGrilla.Location = New System.Drawing.Point(10, 15)
      Me.lblPrimerOrdenGrilla.Name = "lblPrimerOrdenGrilla"
      Me.lblPrimerOrdenGrilla.Size = New System.Drawing.Size(71, 13)
      Me.lblPrimerOrdenGrilla.TabIndex = 0
      Me.lblPrimerOrdenGrilla.Text = "Primer Orden:"
      '
      'grbOrdenGrilla
      '
      Me.grbOrdenGrilla.Controls.Add(Me.chbUsaSegundoOrden)
      Me.grbOrdenGrilla.Controls.Add(Me.chbSegundoOrdenDesc)
      Me.grbOrdenGrilla.Controls.Add(Me.cmbSegundoOrdenGrilla)
      Me.grbOrdenGrilla.Controls.Add(Me.lblSegundoOrdenGrilla)
      Me.grbOrdenGrilla.Controls.Add(Me.chbPrimerOrdenDesc)
      Me.grbOrdenGrilla.Controls.Add(Me.cmbPrimerOrdenGrilla)
      Me.grbOrdenGrilla.Controls.Add(Me.lblPrimerOrdenGrilla)
      Me.grbOrdenGrilla.Location = New System.Drawing.Point(17, 210)
      Me.grbOrdenGrilla.Name = "grbOrdenGrilla"
      Me.grbOrdenGrilla.Size = New System.Drawing.Size(344, 99)
      Me.grbOrdenGrilla.TabIndex = 22
      Me.grbOrdenGrilla.TabStop = False
      Me.grbOrdenGrilla.Text = "Orden de Grilla"
      '
      'cmbVisualizaSucursal
      '
      Me.cmbVisualizaSucursal.BindearPropiedadControl = "SelectedValue"
      Me.cmbVisualizaSucursal.BindearPropiedadEntidad = "VisualizaSucursal"
      Me.cmbVisualizaSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVisualizaSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVisualizaSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVisualizaSucursal.FormattingEnabled = True
      Me.cmbVisualizaSucursal.IsPK = False
      Me.cmbVisualizaSucursal.IsRequired = False
      Me.cmbVisualizaSucursal.Key = Nothing
      Me.cmbVisualizaSucursal.LabelAsoc = Me.lblSegundoOrdenGrilla
      Me.cmbVisualizaSucursal.Location = New System.Drawing.Point(182, 357)
      Me.cmbVisualizaSucursal.Name = "cmbVisualizaSucursal"
      Me.cmbVisualizaSucursal.Size = New System.Drawing.Size(179, 21)
      Me.cmbVisualizaSucursal.TabIndex = 30
      '
      'lblSegundoOrdenGrilla
      '
      Me.lblSegundoOrdenGrilla.AutoSize = True
      Me.lblSegundoOrdenGrilla.LabelAsoc = Nothing
      Me.lblSegundoOrdenGrilla.Location = New System.Drawing.Point(32, 53)
      Me.lblSegundoOrdenGrilla.Name = "lblSegundoOrdenGrilla"
      Me.lblSegundoOrdenGrilla.Size = New System.Drawing.Size(85, 13)
      Me.lblSegundoOrdenGrilla.TabIndex = 3
      Me.lblSegundoOrdenGrilla.Text = "Segundo Orden:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(179, 338)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(95, 13)
      Me.Label3.TabIndex = 29
      Me.Label3.Text = "Visualiza Sucursal:"
      '
      'cmbSolapaPorDefecto
      '
      Me.cmbSolapaPorDefecto.BindearPropiedadControl = "SelectedValue"
      Me.cmbSolapaPorDefecto.BindearPropiedadEntidad = "SolapaPorDefecto"
      Me.cmbSolapaPorDefecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSolapaPorDefecto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSolapaPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSolapaPorDefecto.FormattingEnabled = True
      Me.cmbSolapaPorDefecto.IsPK = False
      Me.cmbSolapaPorDefecto.IsRequired = False
      Me.cmbSolapaPorDefecto.Key = Nothing
      Me.cmbSolapaPorDefecto.LabelAsoc = Me.lblSegundoOrdenGrilla
      Me.cmbSolapaPorDefecto.Location = New System.Drawing.Point(17, 357)
      Me.cmbSolapaPorDefecto.Name = "cmbSolapaPorDefecto"
      Me.cmbSolapaPorDefecto.Size = New System.Drawing.Size(151, 21)
      Me.cmbSolapaPorDefecto.TabIndex = 28
      '
      'lblSolapaPorDefecto
      '
      Me.lblSolapaPorDefecto.AutoSize = True
      Me.lblSolapaPorDefecto.LabelAsoc = Nothing
      Me.lblSolapaPorDefecto.Location = New System.Drawing.Point(14, 338)
      Me.lblSolapaPorDefecto.Name = "lblSolapaPorDefecto"
      Me.lblSolapaPorDefecto.Size = New System.Drawing.Size(100, 13)
      Me.lblSolapaPorDefecto.TabIndex = 9
      Me.lblSolapaPorDefecto.Text = "Solapa por defecto:"
      '
      'chbVisualizaRevisionAdministrativa
      '
      Me.chbVisualizaRevisionAdministrativa.AutoSize = True
      Me.chbVisualizaRevisionAdministrativa.BindearPropiedadControl = "Checked"
      Me.chbVisualizaRevisionAdministrativa.BindearPropiedadEntidad = "VisualizaRevisionAdministrativa"
      Me.chbVisualizaRevisionAdministrativa.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVisualizaRevisionAdministrativa.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVisualizaRevisionAdministrativa.IsPK = False
      Me.chbVisualizaRevisionAdministrativa.IsRequired = False
      Me.chbVisualizaRevisionAdministrativa.Key = Nothing
      Me.chbVisualizaRevisionAdministrativa.LabelAsoc = Nothing
      Me.chbVisualizaRevisionAdministrativa.Location = New System.Drawing.Point(182, 316)
      Me.chbVisualizaRevisionAdministrativa.Name = "chbVisualizaRevisionAdministrativa"
      Me.chbVisualizaRevisionAdministrativa.Size = New System.Drawing.Size(179, 17)
      Me.chbVisualizaRevisionAdministrativa.TabIndex = 8
      Me.chbVisualizaRevisionAdministrativa.Text = "Visualiza Revisión Administrativa"
      Me.chbVisualizaRevisionAdministrativa.UseVisualStyleBackColor = True
      '
      'chbVisualizaOtrasNovedades
      '
      Me.chbVisualizaOtrasNovedades.AutoSize = True
      Me.chbVisualizaOtrasNovedades.BindearPropiedadControl = "Checked"
      Me.chbVisualizaOtrasNovedades.BindearPropiedadEntidad = "VisualizaOtrasNovedades"
      Me.chbVisualizaOtrasNovedades.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVisualizaOtrasNovedades.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVisualizaOtrasNovedades.IsPK = False
      Me.chbVisualizaOtrasNovedades.IsRequired = False
      Me.chbVisualizaOtrasNovedades.Key = Nothing
      Me.chbVisualizaOtrasNovedades.LabelAsoc = Nothing
      Me.chbVisualizaOtrasNovedades.Location = New System.Drawing.Point(17, 316)
      Me.chbVisualizaOtrasNovedades.Name = "chbVisualizaOtrasNovedades"
      Me.chbVisualizaOtrasNovedades.Size = New System.Drawing.Size(149, 17)
      Me.chbVisualizaOtrasNovedades.TabIndex = 7
      Me.chbVisualizaOtrasNovedades.Text = "Visualiza otras novedades"
      Me.chbVisualizaOtrasNovedades.UseVisualStyleBackColor = True
      '
      'chbUsaSegundoOrden
      '
      Me.chbUsaSegundoOrden.AutoSize = True
      Me.chbUsaSegundoOrden.BindearPropiedadControl = ""
      Me.chbUsaSegundoOrden.BindearPropiedadEntidad = ""
      Me.chbUsaSegundoOrden.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsaSegundoOrden.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsaSegundoOrden.IsPK = False
      Me.chbUsaSegundoOrden.IsRequired = False
      Me.chbUsaSegundoOrden.Key = Nothing
      Me.chbUsaSegundoOrden.LabelAsoc = Nothing
      Me.chbUsaSegundoOrden.Location = New System.Drawing.Point(10, 71)
      Me.chbUsaSegundoOrden.Name = "chbUsaSegundoOrden"
      Me.chbUsaSegundoOrden.Size = New System.Drawing.Size(15, 14)
      Me.chbUsaSegundoOrden.TabIndex = 4
      Me.chbUsaSegundoOrden.UseVisualStyleBackColor = True
      '
      'chbSegundoOrdenDesc
      '
      Me.chbSegundoOrdenDesc.AutoSize = True
      Me.chbSegundoOrdenDesc.BindearPropiedadControl = "Checked"
      Me.chbSegundoOrdenDesc.BindearPropiedadEntidad = "SegundoOrdenDesc"
      Me.chbSegundoOrdenDesc.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSegundoOrdenDesc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSegundoOrdenDesc.IsPK = False
      Me.chbSegundoOrdenDesc.IsRequired = False
      Me.chbSegundoOrdenDesc.Key = Nothing
      Me.chbSegundoOrdenDesc.LabelAsoc = Nothing
      Me.chbSegundoOrdenDesc.Location = New System.Drawing.Point(202, 70)
      Me.chbSegundoOrdenDesc.Name = "chbSegundoOrdenDesc"
      Me.chbSegundoOrdenDesc.Size = New System.Drawing.Size(90, 17)
      Me.chbSegundoOrdenDesc.TabIndex = 6
      Me.chbSegundoOrdenDesc.Text = "Descendente"
      Me.chbSegundoOrdenDesc.UseVisualStyleBackColor = True
      '
      'cmbSegundoOrdenGrilla
      '
      Me.cmbSegundoOrdenGrilla.BindearPropiedadControl = "SelectedValue"
      Me.cmbSegundoOrdenGrilla.BindearPropiedadEntidad = "SegundoOrdenGrilla"
      Me.cmbSegundoOrdenGrilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSegundoOrdenGrilla.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSegundoOrdenGrilla.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSegundoOrdenGrilla.FormattingEnabled = True
      Me.cmbSegundoOrdenGrilla.IsPK = False
      Me.cmbSegundoOrdenGrilla.IsRequired = False
      Me.cmbSegundoOrdenGrilla.Key = Nothing
      Me.cmbSegundoOrdenGrilla.LabelAsoc = Me.lblSegundoOrdenGrilla
      Me.cmbSegundoOrdenGrilla.Location = New System.Drawing.Point(35, 68)
      Me.cmbSegundoOrdenGrilla.Name = "cmbSegundoOrdenGrilla"
      Me.cmbSegundoOrdenGrilla.Size = New System.Drawing.Size(151, 21)
      Me.cmbSegundoOrdenGrilla.TabIndex = 5
      '
      'chbPrimerOrdenDesc
      '
      Me.chbPrimerOrdenDesc.AutoSize = True
      Me.chbPrimerOrdenDesc.BindearPropiedadControl = "Checked"
      Me.chbPrimerOrdenDesc.BindearPropiedadEntidad = "PrimerOrdenDesc"
      Me.chbPrimerOrdenDesc.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrimerOrdenDesc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrimerOrdenDesc.IsPK = False
      Me.chbPrimerOrdenDesc.IsRequired = False
      Me.chbPrimerOrdenDesc.Key = Nothing
      Me.chbPrimerOrdenDesc.LabelAsoc = Nothing
      Me.chbPrimerOrdenDesc.Location = New System.Drawing.Point(202, 32)
      Me.chbPrimerOrdenDesc.Name = "chbPrimerOrdenDesc"
      Me.chbPrimerOrdenDesc.Size = New System.Drawing.Size(90, 17)
      Me.chbPrimerOrdenDesc.TabIndex = 2
      Me.chbPrimerOrdenDesc.Text = "Descendente"
      Me.chbPrimerOrdenDesc.UseVisualStyleBackColor = True
      '
      'chbPermiteBorrarComentarios
      '
      Me.chbPermiteBorrarComentarios.AutoSize = True
      Me.chbPermiteBorrarComentarios.BindearPropiedadControl = "Checked"
      Me.chbPermiteBorrarComentarios.BindearPropiedadEntidad = "PermiteBorrarComentarios"
      Me.chbPermiteBorrarComentarios.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPermiteBorrarComentarios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPermiteBorrarComentarios.IsPK = False
      Me.chbPermiteBorrarComentarios.IsRequired = False
      Me.chbPermiteBorrarComentarios.Key = Nothing
      Me.chbPermiteBorrarComentarios.LabelAsoc = Nothing
      Me.chbPermiteBorrarComentarios.Location = New System.Drawing.Point(17, 92)
      Me.chbPermiteBorrarComentarios.Name = "chbPermiteBorrarComentarios"
      Me.chbPermiteBorrarComentarios.Size = New System.Drawing.Size(151, 17)
      Me.chbPermiteBorrarComentarios.TabIndex = 6
      Me.chbPermiteBorrarComentarios.Text = "Permite borrar comentarios"
      Me.chbPermiteBorrarComentarios.UseVisualStyleBackColor = True
      '
      'txtDiasProximoContacto
      '
      Me.txtDiasProximoContacto.BindearPropiedadControl = "Text"
      Me.txtDiasProximoContacto.BindearPropiedadEntidad = "DiasProximoContacto"
      Me.txtDiasProximoContacto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDiasProximoContacto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDiasProximoContacto.Formato = ""
      Me.txtDiasProximoContacto.IsDecimal = False
      Me.txtDiasProximoContacto.IsNumber = True
      Me.txtDiasProximoContacto.IsPK = False
      Me.txtDiasProximoContacto.IsRequired = True
      Me.txtDiasProximoContacto.Key = ""
      Me.txtDiasProximoContacto.LabelAsoc = Me.lblDiasProximoContacto
      Me.txtDiasProximoContacto.Location = New System.Drawing.Point(284, 113)
      Me.txtDiasProximoContacto.MaxLength = 5
      Me.txtDiasProximoContacto.Name = "txtDiasProximoContacto"
      Me.txtDiasProximoContacto.Size = New System.Drawing.Size(65, 20)
      Me.txtDiasProximoContacto.TabIndex = 10
      Me.txtDiasProximoContacto.Text = "0"
      Me.txtDiasProximoContacto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiasProximoContacto
      '
      Me.lblDiasProximoContacto.AutoSize = True
      Me.lblDiasProximoContacto.LabelAsoc = Nothing
      Me.lblDiasProximoContacto.Location = New System.Drawing.Point(245, 116)
      Me.lblDiasProximoContacto.Name = "lblDiasProximoContacto"
      Me.lblDiasProximoContacto.Size = New System.Drawing.Size(30, 13)
      Me.lblDiasProximoContacto.TabIndex = 9
      Me.lblDiasProximoContacto.Text = "Días"
      '
      'chbPermiteIngresarNumero
      '
      Me.chbPermiteIngresarNumero.AutoSize = True
      Me.chbPermiteIngresarNumero.BindearPropiedadControl = "Checked"
      Me.chbPermiteIngresarNumero.BindearPropiedadEntidad = "PermiteIngresarNumero"
      Me.chbPermiteIngresarNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPermiteIngresarNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPermiteIngresarNumero.IsPK = False
      Me.chbPermiteIngresarNumero.IsRequired = False
      Me.chbPermiteIngresarNumero.Key = Nothing
      Me.chbPermiteIngresarNumero.LabelAsoc = Nothing
      Me.chbPermiteIngresarNumero.Location = New System.Drawing.Point(173, 92)
      Me.chbPermiteIngresarNumero.Name = "chbPermiteIngresarNumero"
      Me.chbPermiteIngresarNumero.Size = New System.Drawing.Size(142, 17)
      Me.chbPermiteIngresarNumero.TabIndex = 7
      Me.chbPermiteIngresarNumero.Text = "Permite Ingresar Número"
      Me.chbPermiteIngresarNumero.UseVisualStyleBackColor = True
      '
      'chbReportaAvance
      '
      Me.chbReportaAvance.AutoSize = True
      Me.chbReportaAvance.BindearPropiedadControl = "Checked"
      Me.chbReportaAvance.BindearPropiedadEntidad = "ReportaAvance"
      Me.chbReportaAvance.ForeColorFocus = System.Drawing.Color.Red
      Me.chbReportaAvance.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbReportaAvance.IsPK = False
      Me.chbReportaAvance.IsRequired = False
      Me.chbReportaAvance.Key = Nothing
      Me.chbReportaAvance.LabelAsoc = Nothing
      Me.chbReportaAvance.Location = New System.Drawing.Point(17, 138)
      Me.chbReportaAvance.Name = "chbReportaAvance"
      Me.chbReportaAvance.Size = New System.Drawing.Size(104, 17)
      Me.chbReportaAvance.TabIndex = 11
      Me.chbReportaAvance.Text = "Reporta Avance"
      Me.chbReportaAvance.UseVisualStyleBackColor = True
      '
      'chbReportaCantidad
      '
      Me.chbReportaCantidad.AutoSize = True
      Me.chbReportaCantidad.BindearPropiedadControl = "Checked"
      Me.chbReportaCantidad.BindearPropiedadEntidad = "ReportaCantidad"
      Me.chbReportaCantidad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbReportaCantidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbReportaCantidad.IsPK = False
      Me.chbReportaCantidad.IsRequired = False
      Me.chbReportaCantidad.Key = Nothing
      Me.chbReportaCantidad.LabelAsoc = Nothing
      Me.chbReportaCantidad.Location = New System.Drawing.Point(173, 138)
      Me.chbReportaCantidad.Name = "chbReportaCantidad"
      Me.chbReportaCantidad.Size = New System.Drawing.Size(109, 17)
      Me.chbReportaCantidad.TabIndex = 12
      Me.chbReportaCantidad.Text = "Reporta Cantidad"
      Me.chbReportaCantidad.UseVisualStyleBackColor = True
      '
      'chbVercambios
      '
      Me.chbVercambios.AutoSize = True
      Me.chbVercambios.BindearPropiedadControl = "Checked"
      Me.chbVercambios.BindearPropiedadEntidad = "VerCambios"
      Me.chbVercambios.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVercambios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVercambios.IsPK = False
      Me.chbVercambios.IsRequired = False
      Me.chbVercambios.Key = Nothing
      Me.chbVercambios.LabelAsoc = Nothing
      Me.chbVercambios.Location = New System.Drawing.Point(17, 161)
      Me.chbVercambios.Name = "chbVercambios"
      Me.chbVercambios.Size = New System.Drawing.Size(85, 17)
      Me.chbVercambios.TabIndex = 15
      Me.chbVercambios.Text = "Ver Cambios"
      Me.chbVercambios.UseVisualStyleBackColor = True
      '
      'chbRequierePadre
      '
      Me.chbRequierePadre.AutoSize = True
      Me.chbRequierePadre.BindearPropiedadControl = "Checked"
      Me.chbRequierePadre.BindearPropiedadEntidad = "RequierePadre"
      Me.chbRequierePadre.ForeColorFocus = System.Drawing.Color.Red
      Me.chbRequierePadre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbRequierePadre.IsPK = False
      Me.chbRequierePadre.IsRequired = False
      Me.chbRequierePadre.Key = Nothing
      Me.chbRequierePadre.LabelAsoc = Nothing
      Me.chbRequierePadre.Location = New System.Drawing.Point(173, 161)
      Me.chbRequierePadre.Name = "chbRequierePadre"
      Me.chbRequierePadre.Size = New System.Drawing.Size(100, 17)
      Me.chbRequierePadre.TabIndex = 16
      Me.chbRequierePadre.Text = "Requiere Padre"
      Me.chbRequierePadre.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(14, 187)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(45, 13)
      Me.Label1.TabIndex = 17
      Me.Label1.Text = "Reporte"
      '
      'txtReporte
      '
      Me.txtReporte.BindearPropiedadControl = "Text"
      Me.txtReporte.BindearPropiedadEntidad = "Reporte"
      Me.txtReporte.ForeColorFocus = System.Drawing.Color.Red
      Me.txtReporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtReporte.Formato = ""
      Me.txtReporte.IsDecimal = False
      Me.txtReporte.IsNumber = False
      Me.txtReporte.IsPK = False
      Me.txtReporte.IsRequired = False
      Me.txtReporte.Key = ""
      Me.txtReporte.LabelAsoc = Me.Label1
      Me.txtReporte.Location = New System.Drawing.Point(65, 184)
      Me.txtReporte.MaxLength = 150
      Me.txtReporte.Name = "txtReporte"
      Me.txtReporte.Size = New System.Drawing.Size(186, 20)
      Me.txtReporte.TabIndex = 18
      '
      'chbEmbebido
      '
      Me.chbEmbebido.AutoSize = True
      Me.chbEmbebido.BindearPropiedadControl = "Checked"
      Me.chbEmbebido.BindearPropiedadEntidad = "Embebido"
      Me.chbEmbebido.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEmbebido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEmbebido.IsPK = False
      Me.chbEmbebido.IsRequired = False
      Me.chbEmbebido.Key = Nothing
      Me.chbEmbebido.LabelAsoc = Nothing
      Me.chbEmbebido.Location = New System.Drawing.Point(257, 186)
      Me.chbEmbebido.Name = "chbEmbebido"
      Me.chbEmbebido.Size = New System.Drawing.Size(73, 17)
      Me.chbEmbebido.TabIndex = 19
      Me.chbEmbebido.Text = "Embebido"
      Me.chbEmbebido.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(325, 168)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(39, 13)
      Me.Label2.TabIndex = 20
      Me.Label2.Text = "Copias"
      '
      'txtCantidadCopias
      '
      Me.txtCantidadCopias.BindearPropiedadControl = "Text"
      Me.txtCantidadCopias.BindearPropiedadEntidad = "CantidadCopias"
      Me.txtCantidadCopias.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadCopias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadCopias.Formato = ""
      Me.txtCantidadCopias.IsDecimal = False
      Me.txtCantidadCopias.IsNumber = True
      Me.txtCantidadCopias.IsPK = False
      Me.txtCantidadCopias.IsRequired = True
      Me.txtCantidadCopias.Key = ""
      Me.txtCantidadCopias.LabelAsoc = Me.Label2
      Me.txtCantidadCopias.Location = New System.Drawing.Point(328, 184)
      Me.txtCantidadCopias.MaxLength = 5
      Me.txtCantidadCopias.Name = "txtCantidadCopias"
      Me.txtCantidadCopias.Size = New System.Drawing.Size(33, 20)
      Me.txtCantidadCopias.TabIndex = 21
      Me.txtCantidadCopias.Text = "1"
      Me.txtCantidadCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'CRMTiposNovedadesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(789, 419)
      Me.Controls.Add(Me.cmbVisualizaSucursal)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtCantidadCopias)
      Me.Controls.Add(Me.cmbSolapaPorDefecto)
      Me.Controls.Add(Me.chbEmbebido)
      Me.Controls.Add(Me.lblSolapaPorDefecto)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.chbVisualizaRevisionAdministrativa)
      Me.Controls.Add(Me.txtReporte)
      Me.Controls.Add(Me.chbVisualizaOtrasNovedades)
      Me.Controls.Add(Me.chbRequierePadre)
      Me.Controls.Add(Me.chbVercambios)
      Me.Controls.Add(Me.chbReportaCantidad)
      Me.Controls.Add(Me.chbReportaAvance)
      Me.Controls.Add(Me.grbOrdenGrilla)
      Me.Controls.Add(Me.chbProximoContactoRequerido)
      Me.Controls.Add(Me.chbPermiteIngresarNumero)
      Me.Controls.Add(Me.chbPermiteBorrarComentarios)
      Me.Controls.Add(Me.chbUsuarioPorDefecto)
      Me.Controls.Add(Me.grbDinamicos)
      Me.Controls.Add(Me.chbUsuarioRequerido)
      Me.Controls.Add(Me.lblDiasProximoContacto)
      Me.Controls.Add(Me.lblUnidadDeMedida)
      Me.Controls.Add(Me.txtDiasProximoContacto)
      Me.Controls.Add(Me.txtUnidadDeMedida)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtNombrePlanCuenta)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.txtIdPlanCuenta)
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.Name = "CRMTiposNovedadesDetalle"
      Me.Text = "Tipo Novedad"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdPlanCuenta, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtNombrePlanCuenta, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.txtUnidadDeMedida, 0)
      Me.Controls.SetChildIndex(Me.txtDiasProximoContacto, 0)
      Me.Controls.SetChildIndex(Me.lblUnidadDeMedida, 0)
      Me.Controls.SetChildIndex(Me.lblDiasProximoContacto, 0)
      Me.Controls.SetChildIndex(Me.chbUsuarioRequerido, 0)
      Me.Controls.SetChildIndex(Me.grbDinamicos, 0)
      Me.Controls.SetChildIndex(Me.chbUsuarioPorDefecto, 0)
      Me.Controls.SetChildIndex(Me.chbPermiteBorrarComentarios, 0)
      Me.Controls.SetChildIndex(Me.chbPermiteIngresarNumero, 0)
      Me.Controls.SetChildIndex(Me.chbProximoContactoRequerido, 0)
      Me.Controls.SetChildIndex(Me.grbOrdenGrilla, 0)
      Me.Controls.SetChildIndex(Me.chbReportaAvance, 0)
      Me.Controls.SetChildIndex(Me.chbReportaCantidad, 0)
      Me.Controls.SetChildIndex(Me.chbVercambios, 0)
      Me.Controls.SetChildIndex(Me.chbRequierePadre, 0)
      Me.Controls.SetChildIndex(Me.chbVisualizaOtrasNovedades, 0)
      Me.Controls.SetChildIndex(Me.txtReporte, 0)
      Me.Controls.SetChildIndex(Me.chbVisualizaRevisionAdministrativa, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.lblSolapaPorDefecto, 0)
      Me.Controls.SetChildIndex(Me.chbEmbebido, 0)
      Me.Controls.SetChildIndex(Me.cmbSolapaPorDefecto, 0)
      Me.Controls.SetChildIndex(Me.txtCantidadCopias, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.cmbVisualizaSucursal, 0)
      CType(Me.ugDinamicos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDinamicos.ResumeLayout(False)
      Me.grbDinamicos.PerformLayout()
      Me.grbOrdenGrilla.ResumeLayout(False)
      Me.grbOrdenGrilla.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtNombrePlanCuenta As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtIdPlanCuenta As Eniac.Controles.TextBox
   Friend WithEvents ugDinamicos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents cmbDinamicos As Eniac.Controles.ComboBox
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents chbRequerido As Eniac.Controles.CheckBox
   Friend WithEvents lblUnidadDeMedida As Eniac.Controles.Label
   Friend WithEvents txtUnidadDeMedida As Eniac.Controles.TextBox
   Friend WithEvents grbDinamicos As System.Windows.Forms.GroupBox
   Friend WithEvents chbUsuarioPorDefecto As Eniac.Controles.CheckBox
   Friend WithEvents chbUsuarioRequerido As Eniac.Controles.CheckBox
   Friend WithEvents chbProximoContactoRequerido As Eniac.Controles.CheckBox
   Friend WithEvents cmbPrimerOrdenGrilla As Eniac.Controles.ComboBox
   Friend WithEvents lblPrimerOrdenGrilla As Eniac.Controles.Label
   Friend WithEvents grbOrdenGrilla As System.Windows.Forms.GroupBox
   Friend WithEvents chbSegundoOrdenDesc As Eniac.Controles.CheckBox
   Friend WithEvents cmbSegundoOrdenGrilla As Eniac.Controles.ComboBox
   Friend WithEvents lblSegundoOrdenGrilla As Eniac.Controles.Label
   Friend WithEvents chbPrimerOrdenDesc As Eniac.Controles.CheckBox
   Friend WithEvents chbUsaSegundoOrden As Eniac.Controles.CheckBox
   Friend WithEvents txtOrden As Eniac.Controles.TextBox
   Friend WithEvents lblOrden As Eniac.Controles.Label
   Friend WithEvents chbVisualizaOtrasNovedades As Eniac.Controles.CheckBox
   Friend WithEvents chbVisualizaRevisionAdministrativa As Eniac.Controles.CheckBox
   Friend WithEvents chbPermiteBorrarComentarios As Eniac.Controles.CheckBox
   Friend WithEvents txtDiasProximoContacto As Eniac.Controles.TextBox
   Friend WithEvents lblDiasProximoContacto As Eniac.Controles.Label
   Friend WithEvents chbPermiteIngresarNumero As Eniac.Controles.CheckBox
   Friend WithEvents chbReportaAvance As Eniac.Controles.CheckBox
   Friend WithEvents chbReportaCantidad As Eniac.Controles.CheckBox
   Friend WithEvents chbVercambios As Eniac.Controles.CheckBox
   Friend WithEvents chbRequierePadre As Eniac.Controles.CheckBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtReporte As Eniac.Controles.TextBox
   Friend WithEvents chbEmbebido As Eniac.Controles.CheckBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtCantidadCopias As Eniac.Controles.TextBox
    Friend WithEvents lblSolapaPorDefecto As Controles.Label
    Friend WithEvents cmbSolapaPorDefecto As Controles.ComboBox
    Friend WithEvents cmbVisualizaSucursal As Controles.ComboBox
    Friend WithEvents Label3 As Controles.Label
End Class
