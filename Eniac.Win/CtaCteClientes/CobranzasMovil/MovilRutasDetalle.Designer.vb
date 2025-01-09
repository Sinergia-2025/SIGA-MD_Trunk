<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MovilRutasDetalle
    Inherits BaseDetalle

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaPrecios")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaPrecios")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PorDefecto")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AplicaPreciosOferta")
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
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovilRutasDetalle))
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtRecargaMax = New Eniac.Controles.TextBox()
        Me.txtDescuentoMax = New Eniac.Controles.TextBox()
        Me.chbRecargaMax = New Eniac.Controles.CheckBox()
        Me.lblEsDe = New Eniac.Controles.Label()
        Me.chbDescuentoMax = New Eniac.Controles.CheckBox()
        Me.lblPermiteIngresarPorcentajeDescuentos = New Eniac.Controles.Label()
        Me.grpListasDePrecios = New System.Windows.Forms.GroupBox()
        Me.chbAplicaPreciosOferta = New Eniac.Controles.CheckBox()
        Me.lblActiva = New Eniac.Controles.Label()
        Me.cmbListasDePrecios = New Eniac.Controles.ComboBox()
        Me.chbPorDefecto = New Eniac.Controles.CheckBox()
        Me.btnRefrescarListasDePrecios = New System.Windows.Forms.Button()
        Me.ugListasDePrecios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnEliminarListasDePrecios = New Eniac.Controles.Button()
        Me.btnInsertarListasDePrecios = New Eniac.Controles.Button()
        Me.lblPrecioConImpuestos = New Eniac.Controles.Label()
        Me.lblPuedeModificarPrecio = New Eniac.Controles.Label()
        Me.cmbTransportista = New Eniac.Controles.ComboBox()
        Me.lblTransportista = New Eniac.Controles.Label()
        Me.chbPrecioConImpuestos = New Eniac.Controles.CheckBox()
        Me.chbPuedeModificarPrecio = New Eniac.Controles.CheckBox()
        Me.chbPermiteIngresarPorcentajeDescuentos = New Eniac.Controles.CheckBox()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.chbPermiteCobroParcial = New Eniac.Controles.CheckBox()
        Me.lblPermiteCobroParcial = New Eniac.Controles.Label()
        Me.lblIdRuta = New Eniac.Controles.Label()
        Me.lblVendedor = New Eniac.Controles.Label()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.lblNombreRuta = New Eniac.Controles.Label()
        Me.txtNombreRuta = New Eniac.Controles.TextBox()
        Me.txtRuta = New Eniac.Controles.TextBox()
        Me.chbActiva = New Eniac.Controles.CheckBox()
        Me.txtIdDispositivoPorDefecto = New Eniac.Controles.TextBox()
        Me.lblIdDispositivoPorDefecto = New Eniac.Controles.Label()
        Me.chbEsDeCobranza = New Eniac.Controles.CheckBox()
        Me.chbEsDePedidos = New Eniac.Controles.CheckBox()
        Me.chbEsDeGestion = New Eniac.Controles.CheckBox()
        Me.tbcDetalle = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.lblConfiguraClienteSegun = New Eniac.Controles.Label()
        Me.cmbConfiguraClienteSegun = New Eniac.Controles.ComboBox()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.grpListasDePrecios.SuspendLayout()
        CType(Me.ugListasDePrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        CType(Me.tbcDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(266, 515)
        Me.btnAceptar.TabIndex = 17
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(362, 515)
        Me.btnCancelar.TabIndex = 18
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(165, 515)
        Me.btnCopiar.TabIndex = 20
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(105, 515)
        Me.btnAplicar.TabIndex = 19
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.txtRecargaMax)
        Me.UltraTabPageControl1.Controls.Add(Me.txtDescuentoMax)
        Me.UltraTabPageControl1.Controls.Add(Me.chbRecargaMax)
        Me.UltraTabPageControl1.Controls.Add(Me.chbDescuentoMax)
        Me.UltraTabPageControl1.Controls.Add(Me.lblPermiteIngresarPorcentajeDescuentos)
        Me.UltraTabPageControl1.Controls.Add(Me.grpListasDePrecios)
        Me.UltraTabPageControl1.Controls.Add(Me.lblPrecioConImpuestos)
        Me.UltraTabPageControl1.Controls.Add(Me.lblPuedeModificarPrecio)
        Me.UltraTabPageControl1.Controls.Add(Me.cmbTransportista)
        Me.UltraTabPageControl1.Controls.Add(Me.chbPrecioConImpuestos)
        Me.UltraTabPageControl1.Controls.Add(Me.chbPuedeModificarPrecio)
        Me.UltraTabPageControl1.Controls.Add(Me.lblTransportista)
        Me.UltraTabPageControl1.Controls.Add(Me.chbPermiteIngresarPorcentajeDescuentos)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(1, 22)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(431, 317)
        '
        'txtRecargaMax
        '
        Me.txtRecargaMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRecargaMax.BindearPropiedadControl = "Text"
        Me.txtRecargaMax.BindearPropiedadEntidad = "RecargaMax"
        Me.txtRecargaMax.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRecargaMax.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRecargaMax.Formato = "N2"
        Me.txtRecargaMax.IsDecimal = True
        Me.txtRecargaMax.IsNumber = True
        Me.txtRecargaMax.IsPK = False
        Me.txtRecargaMax.IsRequired = False
        Me.txtRecargaMax.Key = ""
        Me.txtRecargaMax.LabelAsoc = Nothing
        Me.txtRecargaMax.Location = New System.Drawing.Point(329, 51)
        Me.txtRecargaMax.MaxLength = 10
        Me.txtRecargaMax.Name = "txtRecargaMax"
        Me.txtRecargaMax.Size = New System.Drawing.Size(50, 20)
        Me.txtRecargaMax.TabIndex = 24
        Me.txtRecargaMax.Text = "0.00"
        Me.txtRecargaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescuentoMax
        '
        Me.txtDescuentoMax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescuentoMax.BindearPropiedadControl = "Text"
        Me.txtDescuentoMax.BindearPropiedadEntidad = "DescuentoMax"
        Me.txtDescuentoMax.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoMax.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoMax.Formato = "N2"
        Me.txtDescuentoMax.IsDecimal = True
        Me.txtDescuentoMax.IsNumber = True
        Me.txtDescuentoMax.IsPK = False
        Me.txtDescuentoMax.IsRequired = False
        Me.txtDescuentoMax.Key = ""
        Me.txtDescuentoMax.LabelAsoc = Nothing
        Me.txtDescuentoMax.Location = New System.Drawing.Point(329, 29)
        Me.txtDescuentoMax.MaxLength = 10
        Me.txtDescuentoMax.Name = "txtDescuentoMax"
        Me.txtDescuentoMax.Size = New System.Drawing.Size(50, 20)
        Me.txtDescuentoMax.TabIndex = 23
        Me.txtDescuentoMax.Text = "0.00"
        Me.txtDescuentoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbRecargaMax
        '
        Me.chbRecargaMax.AutoSize = True
        Me.chbRecargaMax.BindearPropiedadControl = ""
        Me.chbRecargaMax.BindearPropiedadEntidad = ""
        Me.chbRecargaMax.Checked = True
        Me.chbRecargaMax.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbRecargaMax.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRecargaMax.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRecargaMax.IsPK = False
        Me.chbRecargaMax.IsRequired = False
        Me.chbRecargaMax.Key = Nothing
        Me.chbRecargaMax.LabelAsoc = Me.lblEsDe
        Me.chbRecargaMax.Location = New System.Drawing.Point(225, 53)
        Me.chbRecargaMax.Name = "chbRecargaMax"
        Me.chbRecargaMax.Size = New System.Drawing.Size(93, 17)
        Me.chbRecargaMax.TabIndex = 22
        Me.chbRecargaMax.TabStop = False
        Me.chbRecargaMax.Text = "Recarga Max."
        Me.chbRecargaMax.UseVisualStyleBackColor = True
        '
        'lblEsDe
        '
        Me.lblEsDe.AutoSize = True
        Me.lblEsDe.LabelAsoc = Nothing
        Me.lblEsDe.Location = New System.Drawing.Point(14, 95)
        Me.lblEsDe.Name = "lblEsDe"
        Me.lblEsDe.Size = New System.Drawing.Size(43, 13)
        Me.lblEsDe.TabIndex = 6
        Me.lblEsDe.Text = "Es de..."
        '
        'chbDescuentoMax
        '
        Me.chbDescuentoMax.AutoSize = True
        Me.chbDescuentoMax.BindearPropiedadControl = ""
        Me.chbDescuentoMax.BindearPropiedadEntidad = ""
        Me.chbDescuentoMax.Checked = True
        Me.chbDescuentoMax.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbDescuentoMax.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDescuentoMax.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDescuentoMax.IsPK = False
        Me.chbDescuentoMax.IsRequired = False
        Me.chbDescuentoMax.Key = Nothing
        Me.chbDescuentoMax.LabelAsoc = Me.lblEsDe
        Me.chbDescuentoMax.Location = New System.Drawing.Point(225, 32)
        Me.chbDescuentoMax.Name = "chbDescuentoMax"
        Me.chbDescuentoMax.Size = New System.Drawing.Size(104, 17)
        Me.chbDescuentoMax.TabIndex = 21
        Me.chbDescuentoMax.TabStop = False
        Me.chbDescuentoMax.Text = "Descuento Max."
        Me.chbDescuentoMax.UseVisualStyleBackColor = True
        '
        'lblPermiteIngresarPorcentajeDescuentos
        '
        Me.lblPermiteIngresarPorcentajeDescuentos.AutoSize = True
        Me.lblPermiteIngresarPorcentajeDescuentos.LabelAsoc = Nothing
        Me.lblPermiteIngresarPorcentajeDescuentos.Location = New System.Drawing.Point(16, 54)
        Me.lblPermiteIngresarPorcentajeDescuentos.Name = "lblPermiteIngresarPorcentajeDescuentos"
        Me.lblPermiteIngresarPorcentajeDescuentos.Size = New System.Drawing.Size(179, 13)
        Me.lblPermiteIngresarPorcentajeDescuentos.TabIndex = 4
        Me.lblPermiteIngresarPorcentajeDescuentos.Text = "Puede ingresar Descuento/Recargo"
        '
        'grpListasDePrecios
        '
        Me.grpListasDePrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpListasDePrecios.Controls.Add(Me.chbAplicaPreciosOferta)
        Me.grpListasDePrecios.Controls.Add(Me.cmbListasDePrecios)
        Me.grpListasDePrecios.Controls.Add(Me.chbPorDefecto)
        Me.grpListasDePrecios.Controls.Add(Me.btnRefrescarListasDePrecios)
        Me.grpListasDePrecios.Controls.Add(Me.ugListasDePrecios)
        Me.grpListasDePrecios.Controls.Add(Me.btnEliminarListasDePrecios)
        Me.grpListasDePrecios.Controls.Add(Me.btnInsertarListasDePrecios)
        Me.grpListasDePrecios.Location = New System.Drawing.Point(13, 94)
        Me.grpListasDePrecios.Name = "grpListasDePrecios"
        Me.grpListasDePrecios.Size = New System.Drawing.Size(403, 221)
        Me.grpListasDePrecios.TabIndex = 8
        Me.grpListasDePrecios.TabStop = False
        Me.grpListasDePrecios.Text = " Listas de precios a exportar "
        '
        'chbAplicaPreciosOferta
        '
        Me.chbAplicaPreciosOferta.AutoSize = True
        Me.chbAplicaPreciosOferta.BindearPropiedadControl = ""
        Me.chbAplicaPreciosOferta.BindearPropiedadEntidad = ""
        Me.chbAplicaPreciosOferta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbAplicaPreciosOferta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAplicaPreciosOferta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAplicaPreciosOferta.IsPK = False
        Me.chbAplicaPreciosOferta.IsRequired = False
        Me.chbAplicaPreciosOferta.Key = Nothing
        Me.chbAplicaPreciosOferta.LabelAsoc = Me.lblActiva
        Me.chbAplicaPreciosOferta.Location = New System.Drawing.Point(305, 22)
        Me.chbAplicaPreciosOferta.Name = "chbAplicaPreciosOferta"
        Me.chbAplicaPreciosOferta.Size = New System.Drawing.Size(92, 17)
        Me.chbAplicaPreciosOferta.TabIndex = 3
        Me.chbAplicaPreciosOferta.Text = "Aplica Ofertas"
        Me.chbAplicaPreciosOferta.UseVisualStyleBackColor = True
        Me.chbAplicaPreciosOferta.Visible = False
        '
        'lblActiva
        '
        Me.lblActiva.AutoSize = True
        Me.lblActiva.LabelAsoc = Nothing
        Me.lblActiva.Location = New System.Drawing.Point(373, 16)
        Me.lblActiva.Name = "lblActiva"
        Me.lblActiva.Size = New System.Drawing.Size(37, 13)
        Me.lblActiva.TabIndex = 15
        Me.lblActiva.Text = "Activa"
        '
        'cmbListasDePrecios
        '
        Me.cmbListasDePrecios.BindearPropiedadControl = ""
        Me.cmbListasDePrecios.BindearPropiedadEntidad = ""
        Me.cmbListasDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListasDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListasDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListasDePrecios.FormattingEnabled = True
        Me.cmbListasDePrecios.IsPK = False
        Me.cmbListasDePrecios.IsRequired = False
        Me.cmbListasDePrecios.Key = Nothing
        Me.cmbListasDePrecios.LabelAsoc = Nothing
        Me.cmbListasDePrecios.Location = New System.Drawing.Point(32, 20)
        Me.cmbListasDePrecios.Name = "cmbListasDePrecios"
        Me.cmbListasDePrecios.Size = New System.Drawing.Size(186, 21)
        Me.cmbListasDePrecios.TabIndex = 1
        '
        'chbPorDefecto
        '
        Me.chbPorDefecto.AutoSize = True
        Me.chbPorDefecto.BindearPropiedadControl = ""
        Me.chbPorDefecto.BindearPropiedadEntidad = ""
        Me.chbPorDefecto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbPorDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorDefecto.IsPK = False
        Me.chbPorDefecto.IsRequired = False
        Me.chbPorDefecto.Key = Nothing
        Me.chbPorDefecto.LabelAsoc = Me.lblActiva
        Me.chbPorDefecto.Location = New System.Drawing.Point(220, 22)
        Me.chbPorDefecto.Name = "chbPorDefecto"
        Me.chbPorDefecto.Size = New System.Drawing.Size(83, 17)
        Me.chbPorDefecto.TabIndex = 2
        Me.chbPorDefecto.Text = "Por Defecto"
        Me.chbPorDefecto.UseVisualStyleBackColor = True
        '
        'btnRefrescarListasDePrecios
        '
        Me.btnRefrescarListasDePrecios.Image = Global.Eniac.Win.My.Resources.Resources.refresh_16
        Me.btnRefrescarListasDePrecios.Location = New System.Drawing.Point(6, 19)
        Me.btnRefrescarListasDePrecios.Name = "btnRefrescarListasDePrecios"
        Me.btnRefrescarListasDePrecios.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarListasDePrecios.TabIndex = 0
        Me.btnRefrescarListasDePrecios.UseVisualStyleBackColor = True
        '
        'ugListasDePrecios
        '
        Me.ugListasDePrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugListasDePrecios.DisplayLayout.Appearance = Appearance1
        Me.ugListasDePrecios.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Id"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.MaxWidth = 40
        UltraGridColumn1.MinWidth = 40
        UltraGridColumn1.Width = 40
        UltraGridColumn2.Header.Caption = "Lista de Precios"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 255
        UltraGridColumn3.Header.Caption = "Por Defecto"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.MaxWidth = 50
        UltraGridColumn3.MinWidth = 50
        UltraGridColumn3.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn3.Width = 50
        UltraGridColumn4.Header.Caption = "Aplica Ofertas"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.MaxWidth = 50
        UltraGridColumn4.MinWidth = 50
        UltraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn4.Width = 50
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4})
        Me.ugListasDePrecios.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugListasDePrecios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugListasDePrecios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugListasDePrecios.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugListasDePrecios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugListasDePrecios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugListasDePrecios.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugListasDePrecios.DisplayLayout.MaxColScrollRegions = 1
        Me.ugListasDePrecios.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugListasDePrecios.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugListasDePrecios.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugListasDePrecios.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugListasDePrecios.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugListasDePrecios.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugListasDePrecios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugListasDePrecios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugListasDePrecios.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugListasDePrecios.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugListasDePrecios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugListasDePrecios.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugListasDePrecios.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugListasDePrecios.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugListasDePrecios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugListasDePrecios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugListasDePrecios.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugListasDePrecios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugListasDePrecios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugListasDePrecios.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugListasDePrecios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugListasDePrecios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugListasDePrecios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugListasDePrecios.Location = New System.Drawing.Point(6, 47)
        Me.ugListasDePrecios.Name = "ugListasDePrecios"
        Me.ugListasDePrecios.Size = New System.Drawing.Size(347, 168)
        Me.ugListasDePrecios.TabIndex = 6
        Me.ugListasDePrecios.Text = "Listas de precios a exportar"
        '
        'btnEliminarListasDePrecios
        '
        Me.btnEliminarListasDePrecios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarListasDePrecios.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminarListasDePrecios.Location = New System.Drawing.Point(359, 91)
        Me.btnEliminarListasDePrecios.Name = "btnEliminarListasDePrecios"
        Me.btnEliminarListasDePrecios.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarListasDePrecios.TabIndex = 5
        Me.btnEliminarListasDePrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarListasDePrecios.UseVisualStyleBackColor = True
        '
        'btnInsertarListasDePrecios
        '
        Me.btnInsertarListasDePrecios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarListasDePrecios.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertarListasDePrecios.Location = New System.Drawing.Point(359, 47)
        Me.btnInsertarListasDePrecios.Name = "btnInsertarListasDePrecios"
        Me.btnInsertarListasDePrecios.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarListasDePrecios.TabIndex = 4
        Me.btnInsertarListasDePrecios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarListasDePrecios.UseVisualStyleBackColor = True
        '
        'lblPrecioConImpuestos
        '
        Me.lblPrecioConImpuestos.AutoSize = True
        Me.lblPrecioConImpuestos.LabelAsoc = Nothing
        Me.lblPrecioConImpuestos.Location = New System.Drawing.Point(16, 74)
        Me.lblPrecioConImpuestos.Name = "lblPrecioConImpuestos"
        Me.lblPrecioConImpuestos.Size = New System.Drawing.Size(115, 13)
        Me.lblPrecioConImpuestos.TabIndex = 6
        Me.lblPrecioConImpuestos.Text = "Precios Con Impuestos"
        '
        'lblPuedeModificarPrecio
        '
        Me.lblPuedeModificarPrecio.AutoSize = True
        Me.lblPuedeModificarPrecio.LabelAsoc = Nothing
        Me.lblPuedeModificarPrecio.Location = New System.Drawing.Point(16, 34)
        Me.lblPuedeModificarPrecio.Name = "lblPuedeModificarPrecio"
        Me.lblPuedeModificarPrecio.Size = New System.Drawing.Size(108, 13)
        Me.lblPuedeModificarPrecio.TabIndex = 2
        Me.lblPuedeModificarPrecio.Text = "Permite Cobro Parcial"
        '
        'cmbTransportista
        '
        Me.cmbTransportista.BindearPropiedadControl = "SelectedValue"
        Me.cmbTransportista.BindearPropiedadEntidad = "idTransportista"
        Me.cmbTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTransportista.FormattingEnabled = True
        Me.cmbTransportista.IsPK = False
        Me.cmbTransportista.IsRequired = False
        Me.cmbTransportista.Key = Nothing
        Me.cmbTransportista.LabelAsoc = Me.lblTransportista
        Me.cmbTransportista.Location = New System.Drawing.Point(123, 7)
        Me.cmbTransportista.Name = "cmbTransportista"
        Me.cmbTransportista.Size = New System.Drawing.Size(242, 21)
        Me.cmbTransportista.TabIndex = 1
        '
        'lblTransportista
        '
        Me.lblTransportista.AutoSize = True
        Me.lblTransportista.LabelAsoc = Nothing
        Me.lblTransportista.Location = New System.Drawing.Point(46, 10)
        Me.lblTransportista.Name = "lblTransportista"
        Me.lblTransportista.Size = New System.Drawing.Size(68, 13)
        Me.lblTransportista.TabIndex = 0
        Me.lblTransportista.Text = "Transportista"
        '
        'chbPrecioConImpuestos
        '
        Me.chbPrecioConImpuestos.AutoSize = True
        Me.chbPrecioConImpuestos.BindearPropiedadControl = "Checked"
        Me.chbPrecioConImpuestos.BindearPropiedadEntidad = "PrecioConImpuestos"
        Me.chbPrecioConImpuestos.Checked = True
        Me.chbPrecioConImpuestos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPrecioConImpuestos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPrecioConImpuestos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPrecioConImpuestos.IsPK = False
        Me.chbPrecioConImpuestos.IsRequired = False
        Me.chbPrecioConImpuestos.Key = Nothing
        Me.chbPrecioConImpuestos.LabelAsoc = Me.lblPrecioConImpuestos
        Me.chbPrecioConImpuestos.Location = New System.Drawing.Point(199, 74)
        Me.chbPrecioConImpuestos.Name = "chbPrecioConImpuestos"
        Me.chbPrecioConImpuestos.Size = New System.Drawing.Size(15, 14)
        Me.chbPrecioConImpuestos.TabIndex = 7
        Me.chbPrecioConImpuestos.TabStop = False
        Me.chbPrecioConImpuestos.UseVisualStyleBackColor = True
        '
        'chbPuedeModificarPrecio
        '
        Me.chbPuedeModificarPrecio.AutoSize = True
        Me.chbPuedeModificarPrecio.BindearPropiedadControl = "Checked"
        Me.chbPuedeModificarPrecio.BindearPropiedadEntidad = "PuedeModificarPrecio"
        Me.chbPuedeModificarPrecio.Checked = True
        Me.chbPuedeModificarPrecio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPuedeModificarPrecio.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPuedeModificarPrecio.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPuedeModificarPrecio.IsPK = False
        Me.chbPuedeModificarPrecio.IsRequired = False
        Me.chbPuedeModificarPrecio.Key = Nothing
        Me.chbPuedeModificarPrecio.LabelAsoc = Me.lblPuedeModificarPrecio
        Me.chbPuedeModificarPrecio.Location = New System.Drawing.Point(199, 34)
        Me.chbPuedeModificarPrecio.Name = "chbPuedeModificarPrecio"
        Me.chbPuedeModificarPrecio.Size = New System.Drawing.Size(15, 14)
        Me.chbPuedeModificarPrecio.TabIndex = 3
        Me.chbPuedeModificarPrecio.TabStop = False
        Me.chbPuedeModificarPrecio.UseVisualStyleBackColor = True
        '
        'chbPermiteIngresarPorcentajeDescuentos
        '
        Me.chbPermiteIngresarPorcentajeDescuentos.AutoSize = True
        Me.chbPermiteIngresarPorcentajeDescuentos.BindearPropiedadControl = "Checked"
        Me.chbPermiteIngresarPorcentajeDescuentos.BindearPropiedadEntidad = "PermiteIngresarPorcentajeDescuentos"
        Me.chbPermiteIngresarPorcentajeDescuentos.Checked = True
        Me.chbPermiteIngresarPorcentajeDescuentos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPermiteIngresarPorcentajeDescuentos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteIngresarPorcentajeDescuentos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteIngresarPorcentajeDescuentos.IsPK = False
        Me.chbPermiteIngresarPorcentajeDescuentos.IsRequired = False
        Me.chbPermiteIngresarPorcentajeDescuentos.Key = Nothing
        Me.chbPermiteIngresarPorcentajeDescuentos.LabelAsoc = Me.lblPermiteIngresarPorcentajeDescuentos
        Me.chbPermiteIngresarPorcentajeDescuentos.Location = New System.Drawing.Point(199, 54)
        Me.chbPermiteIngresarPorcentajeDescuentos.Name = "chbPermiteIngresarPorcentajeDescuentos"
        Me.chbPermiteIngresarPorcentajeDescuentos.Size = New System.Drawing.Size(15, 14)
        Me.chbPermiteIngresarPorcentajeDescuentos.TabIndex = 5
        Me.chbPermiteIngresarPorcentajeDescuentos.TabStop = False
        Me.chbPermiteIngresarPorcentajeDescuentos.UseVisualStyleBackColor = True
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.chbPermiteCobroParcial)
        Me.UltraTabPageControl2.Controls.Add(Me.lblPermiteCobroParcial)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(431, 317)
        '
        'chbPermiteCobroParcial
        '
        Me.chbPermiteCobroParcial.AutoSize = True
        Me.chbPermiteCobroParcial.BindearPropiedadControl = "Checked"
        Me.chbPermiteCobroParcial.BindearPropiedadEntidad = "PermiteCobroParcial"
        Me.chbPermiteCobroParcial.Checked = True
        Me.chbPermiteCobroParcial.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbPermiteCobroParcial.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPermiteCobroParcial.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPermiteCobroParcial.IsPK = False
        Me.chbPermiteCobroParcial.IsRequired = False
        Me.chbPermiteCobroParcial.Key = Nothing
        Me.chbPermiteCobroParcial.LabelAsoc = Me.chbPermiteCobroParcial
        Me.chbPermiteCobroParcial.Location = New System.Drawing.Point(307, 19)
        Me.chbPermiteCobroParcial.Name = "chbPermiteCobroParcial"
        Me.chbPermiteCobroParcial.Size = New System.Drawing.Size(15, 14)
        Me.chbPermiteCobroParcial.TabIndex = 1
        Me.chbPermiteCobroParcial.TabStop = False
        Me.chbPermiteCobroParcial.UseVisualStyleBackColor = True
        '
        'lblPermiteCobroParcial
        '
        Me.lblPermiteCobroParcial.AutoSize = True
        Me.lblPermiteCobroParcial.LabelAsoc = Nothing
        Me.lblPermiteCobroParcial.Location = New System.Drawing.Point(124, 19)
        Me.lblPermiteCobroParcial.Name = "lblPermiteCobroParcial"
        Me.lblPermiteCobroParcial.Size = New System.Drawing.Size(173, 13)
        Me.lblPermiteCobroParcial.TabIndex = 0
        Me.lblPermiteCobroParcial.Text = "Puede modificar precios en el móvil"
        '
        'lblIdRuta
        '
        Me.lblIdRuta.AutoSize = True
        Me.lblIdRuta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdRuta.LabelAsoc = Nothing
        Me.lblIdRuta.Location = New System.Drawing.Point(14, 16)
        Me.lblIdRuta.Name = "lblIdRuta"
        Me.lblIdRuta.Size = New System.Drawing.Size(40, 13)
        Me.lblIdRuta.TabIndex = 0
        Me.lblIdRuta.Text = "Código"
        '
        'lblVendedor
        '
        Me.lblVendedor.AutoSize = True
        Me.lblVendedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblVendedor.LabelAsoc = Nothing
        Me.lblVendedor.Location = New System.Drawing.Point(14, 67)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lblVendedor.TabIndex = 4
        Me.lblVendedor.Text = "Vendedor"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = ""
        Me.cmbVendedor.BindearPropiedadEntidad = ""
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = True
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Me.lblVendedor
        Me.cmbVendedor.Location = New System.Drawing.Point(84, 64)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(242, 21)
        Me.cmbVendedor.TabIndex = 5
        '
        'lblNombreRuta
        '
        Me.lblNombreRuta.AutoSize = True
        Me.lblNombreRuta.LabelAsoc = Nothing
        Me.lblNombreRuta.Location = New System.Drawing.Point(14, 42)
        Me.lblNombreRuta.Name = "lblNombreRuta"
        Me.lblNombreRuta.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreRuta.TabIndex = 2
        Me.lblNombreRuta.Text = "Nombre"
        '
        'txtNombreRuta
        '
        Me.txtNombreRuta.BindearPropiedadControl = "Text"
        Me.txtNombreRuta.BindearPropiedadEntidad = "NombreRuta"
        Me.txtNombreRuta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreRuta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreRuta.Formato = ""
        Me.txtNombreRuta.IsDecimal = False
        Me.txtNombreRuta.IsNumber = False
        Me.txtNombreRuta.IsPK = False
        Me.txtNombreRuta.IsRequired = True
        Me.txtNombreRuta.Key = ""
        Me.txtNombreRuta.LabelAsoc = Me.lblNombreRuta
        Me.txtNombreRuta.Location = New System.Drawing.Point(84, 38)
        Me.txtNombreRuta.MaxLength = 70
        Me.txtNombreRuta.Name = "txtNombreRuta"
        Me.txtNombreRuta.Size = New System.Drawing.Size(347, 20)
        Me.txtNombreRuta.TabIndex = 3
        '
        'txtRuta
        '
        Me.txtRuta.BindearPropiedadControl = "Text"
        Me.txtRuta.BindearPropiedadEntidad = "IdRuta"
        Me.txtRuta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtRuta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtRuta.Formato = ""
        Me.txtRuta.IsDecimal = False
        Me.txtRuta.IsNumber = True
        Me.txtRuta.IsPK = True
        Me.txtRuta.IsRequired = True
        Me.txtRuta.Key = ""
        Me.txtRuta.LabelAsoc = Me.lblIdRuta
        Me.txtRuta.Location = New System.Drawing.Point(84, 12)
        Me.txtRuta.MaxLength = 6
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(77, 20)
        Me.txtRuta.TabIndex = 1
        Me.txtRuta.Text = "0"
        Me.txtRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbActiva
        '
        Me.chbActiva.AutoSize = True
        Me.chbActiva.BindearPropiedadControl = "Checked"
        Me.chbActiva.BindearPropiedadEntidad = "Activa"
        Me.chbActiva.Checked = True
        Me.chbActiva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbActiva.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActiva.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActiva.IsPK = False
        Me.chbActiva.IsRequired = False
        Me.chbActiva.Key = Nothing
        Me.chbActiva.LabelAsoc = Me.lblActiva
        Me.chbActiva.Location = New System.Drawing.Point(416, 15)
        Me.chbActiva.Name = "chbActiva"
        Me.chbActiva.Size = New System.Drawing.Size(15, 14)
        Me.chbActiva.TabIndex = 16
        Me.chbActiva.TabStop = False
        Me.chbActiva.UseVisualStyleBackColor = True
        '
        'txtIdDispositivoPorDefecto
        '
        Me.txtIdDispositivoPorDefecto.BindearPropiedadControl = "Text"
        Me.txtIdDispositivoPorDefecto.BindearPropiedadEntidad = "IdDispositivoPorDefecto"
        Me.txtIdDispositivoPorDefecto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdDispositivoPorDefecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdDispositivoPorDefecto.Formato = ""
        Me.txtIdDispositivoPorDefecto.IsDecimal = False
        Me.txtIdDispositivoPorDefecto.IsNumber = False
        Me.txtIdDispositivoPorDefecto.IsPK = False
        Me.txtIdDispositivoPorDefecto.IsRequired = False
        Me.txtIdDispositivoPorDefecto.Key = ""
        Me.txtIdDispositivoPorDefecto.LabelAsoc = Me.lblIdDispositivoPorDefecto
        Me.txtIdDispositivoPorDefecto.Location = New System.Drawing.Point(250, 135)
        Me.txtIdDispositivoPorDefecto.MaxLength = 50
        Me.txtIdDispositivoPorDefecto.Name = "txtIdDispositivoPorDefecto"
        Me.txtIdDispositivoPorDefecto.Size = New System.Drawing.Size(181, 20)
        Me.txtIdDispositivoPorDefecto.TabIndex = 13
        '
        'lblIdDispositivoPorDefecto
        '
        Me.lblIdDispositivoPorDefecto.AutoSize = True
        Me.lblIdDispositivoPorDefecto.LabelAsoc = Nothing
        Me.lblIdDispositivoPorDefecto.Location = New System.Drawing.Point(247, 119)
        Me.lblIdDispositivoPorDefecto.Name = "lblIdDispositivoPorDefecto"
        Me.lblIdDispositivoPorDefecto.Size = New System.Drawing.Size(115, 13)
        Me.lblIdDispositivoPorDefecto.TabIndex = 12
        Me.lblIdDispositivoPorDefecto.Text = "Dispositivo por defecto"
        '
        'chbEsDeCobranza
        '
        Me.chbEsDeCobranza.AutoSize = True
        Me.chbEsDeCobranza.BindearPropiedadControl = "Checked"
        Me.chbEsDeCobranza.BindearPropiedadEntidad = "EsDeCobranza"
        Me.chbEsDeCobranza.Checked = True
        Me.chbEsDeCobranza.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEsDeCobranza.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsDeCobranza.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsDeCobranza.IsPK = False
        Me.chbEsDeCobranza.IsRequired = False
        Me.chbEsDeCobranza.Key = Nothing
        Me.chbEsDeCobranza.LabelAsoc = Me.lblEsDe
        Me.chbEsDeCobranza.Location = New System.Drawing.Point(84, 94)
        Me.chbEsDeCobranza.Name = "chbEsDeCobranza"
        Me.chbEsDeCobranza.Size = New System.Drawing.Size(71, 17)
        Me.chbEsDeCobranza.TabIndex = 7
        Me.chbEsDeCobranza.TabStop = False
        Me.chbEsDeCobranza.Text = "Cobranza"
        Me.chbEsDeCobranza.UseVisualStyleBackColor = True
        '
        'chbEsDePedidos
        '
        Me.chbEsDePedidos.AutoSize = True
        Me.chbEsDePedidos.BindearPropiedadControl = "Checked"
        Me.chbEsDePedidos.BindearPropiedadEntidad = "EsDePedidos"
        Me.chbEsDePedidos.Checked = True
        Me.chbEsDePedidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEsDePedidos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsDePedidos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsDePedidos.IsPK = False
        Me.chbEsDePedidos.IsRequired = False
        Me.chbEsDePedidos.Key = Nothing
        Me.chbEsDePedidos.LabelAsoc = Me.lblEsDe
        Me.chbEsDePedidos.Location = New System.Drawing.Point(161, 94)
        Me.chbEsDePedidos.Name = "chbEsDePedidos"
        Me.chbEsDePedidos.Size = New System.Drawing.Size(64, 17)
        Me.chbEsDePedidos.TabIndex = 8
        Me.chbEsDePedidos.TabStop = False
        Me.chbEsDePedidos.Text = "Pedidos"
        Me.chbEsDePedidos.UseVisualStyleBackColor = True
        '
        'chbEsDeGestion
        '
        Me.chbEsDeGestion.AutoSize = True
        Me.chbEsDeGestion.BindearPropiedadControl = "Checked"
        Me.chbEsDeGestion.BindearPropiedadEntidad = "EsDeGestion"
        Me.chbEsDeGestion.Checked = True
        Me.chbEsDeGestion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEsDeGestion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsDeGestion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsDeGestion.IsPK = False
        Me.chbEsDeGestion.IsRequired = False
        Me.chbEsDeGestion.Key = Nothing
        Me.chbEsDeGestion.LabelAsoc = Me.lblEsDe
        Me.chbEsDeGestion.Location = New System.Drawing.Point(231, 94)
        Me.chbEsDeGestion.Name = "chbEsDeGestion"
        Me.chbEsDeGestion.Size = New System.Drawing.Size(62, 17)
        Me.chbEsDeGestion.TabIndex = 9
        Me.chbEsDeGestion.TabStop = False
        Me.chbEsDeGestion.Text = "Gestión"
        Me.chbEsDeGestion.UseVisualStyleBackColor = True
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.tbcDetalle.Controls.Add(Me.UltraTabPageControl1)
        Me.tbcDetalle.Controls.Add(Me.UltraTabPageControl2)
        Me.tbcDetalle.Location = New System.Drawing.Point(12, 169)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.tbcDetalle.Size = New System.Drawing.Size(433, 340)
        Me.tbcDetalle.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
        Me.tbcDetalle.TabIndex = 14
        UltraTab1.Key = "tbpPedidos"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Pedidos"
        UltraTab2.Key = "tbpCobranza"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Cobranza"
        Me.tbcDetalle.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(431, 317)
        '
        'lblConfiguraClienteSegun
        '
        Me.lblConfiguraClienteSegun.AutoSize = True
        Me.lblConfiguraClienteSegun.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblConfiguraClienteSegun.LabelAsoc = Nothing
        Me.lblConfiguraClienteSegun.Location = New System.Drawing.Point(81, 119)
        Me.lblConfiguraClienteSegun.Name = "lblConfiguraClienteSegun"
        Me.lblConfiguraClienteSegun.Size = New System.Drawing.Size(116, 13)
        Me.lblConfiguraClienteSegun.TabIndex = 10
        Me.lblConfiguraClienteSegun.Text = "Asignar Clientes Segun"
        '
        'cmbConfiguraClienteSegun
        '
        Me.cmbConfiguraClienteSegun.BindearPropiedadControl = "SelectedValue"
        Me.cmbConfiguraClienteSegun.BindearPropiedadEntidad = "ConfiguraClienteSegun"
        Me.cmbConfiguraClienteSegun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConfiguraClienteSegun.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbConfiguraClienteSegun.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbConfiguraClienteSegun.FormattingEnabled = True
        Me.cmbConfiguraClienteSegun.IsPK = False
        Me.cmbConfiguraClienteSegun.IsRequired = True
        Me.cmbConfiguraClienteSegun.Key = Nothing
        Me.cmbConfiguraClienteSegun.LabelAsoc = Me.lblConfiguraClienteSegun
        Me.cmbConfiguraClienteSegun.Location = New System.Drawing.Point(84, 135)
        Me.cmbConfiguraClienteSegun.Name = "cmbConfiguraClienteSegun"
        Me.cmbConfiguraClienteSegun.Size = New System.Drawing.Size(160, 21)
        Me.cmbConfiguraClienteSegun.TabIndex = 11
        '
        'MovilRutasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CierraAutomaticamente = True
        Me.ClientSize = New System.Drawing.Size(454, 557)
        Me.Controls.Add(Me.lblConfiguraClienteSegun)
        Me.Controls.Add(Me.cmbConfiguraClienteSegun)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Controls.Add(Me.lblVendedor)
        Me.Controls.Add(Me.cmbVendedor)
        Me.Controls.Add(Me.lblEsDe)
        Me.Controls.Add(Me.chbEsDeGestion)
        Me.Controls.Add(Me.chbEsDePedidos)
        Me.Controls.Add(Me.chbEsDeCobranza)
        Me.Controls.Add(Me.lblActiva)
        Me.Controls.Add(Me.chbActiva)
        Me.Controls.Add(Me.lblIdDispositivoPorDefecto)
        Me.Controls.Add(Me.lblNombreRuta)
        Me.Controls.Add(Me.txtIdDispositivoPorDefecto)
        Me.Controls.Add(Me.txtNombreRuta)
        Me.Controls.Add(Me.lblIdRuta)
        Me.Controls.Add(Me.txtRuta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MovilRutasDetalle"
        Me.Text = "Ruta"
        Me.Controls.SetChildIndex(Me.txtRuta, 0)
        Me.Controls.SetChildIndex(Me.lblIdRuta, 0)
        Me.Controls.SetChildIndex(Me.txtNombreRuta, 0)
        Me.Controls.SetChildIndex(Me.txtIdDispositivoPorDefecto, 0)
        Me.Controls.SetChildIndex(Me.lblNombreRuta, 0)
        Me.Controls.SetChildIndex(Me.lblIdDispositivoPorDefecto, 0)
        Me.Controls.SetChildIndex(Me.chbActiva, 0)
        Me.Controls.SetChildIndex(Me.lblActiva, 0)
        Me.Controls.SetChildIndex(Me.chbEsDeCobranza, 0)
        Me.Controls.SetChildIndex(Me.chbEsDePedidos, 0)
        Me.Controls.SetChildIndex(Me.chbEsDeGestion, 0)
        Me.Controls.SetChildIndex(Me.lblEsDe, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.cmbVendedor, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.lblVendedor, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.tbcDetalle, 0)
        Me.Controls.SetChildIndex(Me.cmbConfiguraClienteSegun, 0)
        Me.Controls.SetChildIndex(Me.lblConfiguraClienteSegun, 0)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.UltraTabPageControl1.PerformLayout()
        Me.grpListasDePrecios.ResumeLayout(False)
        Me.grpListasDePrecios.PerformLayout()
        CType(Me.ugListasDePrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        CType(Me.tbcDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcDetalle.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreRuta As Eniac.Controles.Label
    Friend WithEvents txtNombreRuta As Eniac.Controles.TextBox
    Friend WithEvents lblIdRuta As Eniac.Controles.Label
    Friend WithEvents txtRuta As Eniac.Controles.TextBox
    Friend WithEvents chbActiva As Eniac.Controles.CheckBox
    Friend WithEvents lblActiva As Eniac.Controles.Label
    Friend WithEvents txtIdDispositivoPorDefecto As Eniac.Controles.TextBox
    Friend WithEvents lblIdDispositivoPorDefecto As Eniac.Controles.Label
    Friend WithEvents cmbTransportista As Eniac.Controles.ComboBox
    Friend WithEvents lblTransportista As Eniac.Controles.Label
    Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
    Friend WithEvents lblVendedor As Eniac.Controles.Label
    Friend WithEvents lblPrecioConImpuestos As Eniac.Controles.Label
    Friend WithEvents lblPuedeModificarPrecio As Eniac.Controles.Label
    Friend WithEvents chbPrecioConImpuestos As Eniac.Controles.CheckBox
    Friend WithEvents chbPuedeModificarPrecio As Eniac.Controles.CheckBox
    Friend WithEvents grpListasDePrecios As System.Windows.Forms.GroupBox
    Friend WithEvents btnRefrescarListasDePrecios As System.Windows.Forms.Button
    Friend WithEvents ugListasDePrecios As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnEliminarListasDePrecios As Eniac.Controles.Button
    Friend WithEvents cmbListasDePrecios As Eniac.Controles.ComboBox
    Friend WithEvents btnInsertarListasDePrecios As Eniac.Controles.Button
    Friend WithEvents lblPermiteIngresarPorcentajeDescuentos As Eniac.Controles.Label
    Friend WithEvents chbPermiteIngresarPorcentajeDescuentos As Eniac.Controles.CheckBox
    Friend WithEvents chbPorDefecto As Eniac.Controles.CheckBox
    Friend WithEvents chbPermiteCobroParcial As Eniac.Controles.CheckBox
    Friend WithEvents lblPermiteCobroParcial As Eniac.Controles.Label
    Friend WithEvents chbEsDeCobranza As Eniac.Controles.CheckBox
    Friend WithEvents lblEsDe As Eniac.Controles.Label
    Friend WithEvents chbEsDePedidos As Eniac.Controles.CheckBox
    Friend WithEvents chbEsDeGestion As Eniac.Controles.CheckBox
    Friend WithEvents tbcDetalle As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents chbAplicaPreciosOferta As Eniac.Controles.CheckBox
    Friend WithEvents lblConfiguraClienteSegun As Eniac.Controles.Label
    Friend WithEvents cmbConfiguraClienteSegun As Eniac.Controles.ComboBox
    Friend WithEvents chbRecargaMax As Controles.CheckBox
    Friend WithEvents chbDescuentoMax As Controles.CheckBox
    Friend WithEvents txtRecargaMax As Controles.TextBox
    Friend WithEvents txtDescuentoMax As Controles.TextBox
End Class
