<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RubrosDetalle
    Inherits Eniac.Win.BaseDetalle

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRubro")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescuentoRecargoHasta", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Comision")
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RubrosDetalle))
        Me.lblNombreRubro = New Eniac.Controles.Label()
        Me.txtNombreRubro = New Eniac.Controles.TextBox()
        Me.lblIdRubro = New Eniac.Controles.Label()
        Me.txtIdRubro = New Eniac.Controles.TextBox()
        Me.tbpComisionPorDesCuento = New System.Windows.Forms.TabPage()
        Me.btnRefrescarDescRec = New System.Windows.Forms.Button()
        Me.lblComisionDescRec = New Eniac.Controles.Label()
        Me.lblDesRecHasta = New Eniac.Controles.Label()
        Me.txtComisionDescRec = New Eniac.Controles.TextBox()
        Me.txtDesRecHasta = New Eniac.Controles.TextBox()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnEliminarRubroComsion = New Eniac.Controles.Button()
        Me.btnInsertarRubroComsion = New Eniac.Controles.Button()
        Me.tbpDescuentos = New System.Windows.Forms.TabPage()
        Me.grbUbicacion = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUHPorc5 = New Eniac.Controles.TextBox()
        Me.lblUHPorc5 = New Eniac.Controles.Label()
        Me.txtUHPorc4 = New Eniac.Controles.TextBox()
        Me.lblUHPorc4 = New Eniac.Controles.Label()
        Me.txtUHPorc3 = New Eniac.Controles.TextBox()
        Me.lblUHPorc3 = New Eniac.Controles.Label()
        Me.txtUHPorc2 = New Eniac.Controles.TextBox()
        Me.lblUHPorc2 = New Eniac.Controles.Label()
        Me.txtUHPorc1 = New Eniac.Controles.TextBox()
        Me.lblUHPorc1 = New Eniac.Controles.Label()
        Me.txtUnidHasta5 = New Eniac.Controles.TextBox()
        Me.lblUnidHasta5 = New Eniac.Controles.Label()
        Me.txtUnidHasta4 = New Eniac.Controles.TextBox()
        Me.lblUnidHasta4 = New Eniac.Controles.Label()
        Me.txtUnidHasta3 = New Eniac.Controles.TextBox()
        Me.lblUnidHasta3 = New Eniac.Controles.Label()
        Me.txtUnidHasta2 = New Eniac.Controles.TextBox()
        Me.lblUnidHasta2 = New Eniac.Controles.Label()
        Me.Label16 = New Eniac.Controles.Label()
        Me.txtUnidHasta1 = New Eniac.Controles.TextBox()
        Me.lblUnidHasta1 = New Eniac.Controles.Label()
        Me.Label13 = New Eniac.Controles.Label()
        Me.Label10 = New Eniac.Controles.Label()
        Me.Label9 = New Eniac.Controles.Label()
        Me.Label8 = New Eniac.Controles.Label()
        Me.tbpDatos = New System.Windows.Forms.TabPage()
        Me.grbDatosPersonales = New System.Windows.Forms.GroupBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.txtDescuentoRecargo2 = New Eniac.Controles.TextBox()
        Me.lblDescuentoRecargo2 = New Eniac.Controles.Label()
        Me.Label4 = New Eniac.Controles.Label()
        Me.txtDescuentoRecargo1 = New Eniac.Controles.TextBox()
        Me.lblDescuentoRecargo = New Eniac.Controles.Label()
        Me.lblOrden = New Eniac.Controles.Label()
        Me.txtOrden = New Eniac.Controles.TextBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.txtComisionPorVenta = New Eniac.Controles.TextBox()
        Me.lblComisionPorVenta = New Eniac.Controles.Label()
        Me.lblActividad = New Eniac.Controles.Label()
        Me.chbAsociaActividad = New Eniac.Controles.CheckBox()
        Me.cmbActividad = New Eniac.Controles.ComboBox()
        Me.lblProvincia = New Eniac.Controles.Label()
        Me.cmbProvincia = New Eniac.Controles.ComboBox()
        Me.tbcDetalle = New System.Windows.Forms.TabControl()
        Me.tpTiendaWeb = New System.Windows.Forms.TabPage()
        Me.LblRubroML = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.TxtCodRubML = New Eniac.Controles.TextBox()
        Me.TxtCodRubArborea = New Eniac.Controles.TextBox()
        Me.chbCategoriasMercadoLibre = New Eniac.Controles.CheckBox()
        Me.cmbCategoriasMercadoLibre = New Eniac.Controles.ComboBox()
        Me.lblIdRubroTiendaNube = New Eniac.Controles.Label()
        Me.txtIdRubroTiendaNube = New Eniac.Controles.TextBox()
        Me.tpExportación = New System.Windows.Forms.TabPage()
        Me.lblCodigoExportacion = New Eniac.Controles.Label()
        Me.txtCodigoExportacion = New Eniac.Controles.TextBox()
        Me.tbpComisionPorDesCuento.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpDescuentos.SuspendLayout()
        Me.grbUbicacion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbpDatos.SuspendLayout()
        Me.grbDatosPersonales.SuspendLayout()
        Me.tbcDetalle.SuspendLayout()
        Me.tpTiendaWeb.SuspendLayout()
        Me.tpExportación.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(285, 302)
        Me.btnAceptar.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(371, 302)
        Me.btnCancelar.TabIndex = 6
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(184, 302)
        Me.btnCopiar.TabIndex = 8
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(125, 302)
        Me.btnAplicar.TabIndex = 7
        '
        'lblNombreRubro
        '
        Me.lblNombreRubro.AutoSize = True
        Me.lblNombreRubro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombreRubro.LabelAsoc = Nothing
        Me.lblNombreRubro.Location = New System.Drawing.Point(19, 46)
        Me.lblNombreRubro.Name = "lblNombreRubro"
        Me.lblNombreRubro.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreRubro.TabIndex = 2
        Me.lblNombreRubro.Text = "Nombre"
        '
        'txtNombreRubro
        '
        Me.txtNombreRubro.BindearPropiedadControl = "Text"
        Me.txtNombreRubro.BindearPropiedadEntidad = "NombreRubro"
        Me.txtNombreRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreRubro.Formato = ""
        Me.txtNombreRubro.IsDecimal = False
        Me.txtNombreRubro.IsNumber = False
        Me.txtNombreRubro.IsPK = False
        Me.txtNombreRubro.IsRequired = True
        Me.txtNombreRubro.Key = ""
        Me.txtNombreRubro.LabelAsoc = Me.lblNombreRubro
        Me.txtNombreRubro.Location = New System.Drawing.Point(64, 42)
        Me.txtNombreRubro.MaxLength = 50
        Me.txtNombreRubro.Name = "txtNombreRubro"
        Me.txtNombreRubro.Size = New System.Drawing.Size(373, 20)
        Me.txtNombreRubro.TabIndex = 3
        '
        'lblIdRubro
        '
        Me.lblIdRubro.AutoSize = True
        Me.lblIdRubro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdRubro.LabelAsoc = Nothing
        Me.lblIdRubro.Location = New System.Drawing.Point(19, 18)
        Me.lblIdRubro.Name = "lblIdRubro"
        Me.lblIdRubro.Size = New System.Drawing.Size(40, 13)
        Me.lblIdRubro.TabIndex = 0
        Me.lblIdRubro.Text = "Código"
        '
        'txtIdRubro
        '
        Me.txtIdRubro.BindearPropiedadControl = "Text"
        Me.txtIdRubro.BindearPropiedadEntidad = "IdRubro"
        Me.txtIdRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdRubro.Formato = ""
        Me.txtIdRubro.IsDecimal = False
        Me.txtIdRubro.IsNumber = True
        Me.txtIdRubro.IsPK = True
        Me.txtIdRubro.IsRequired = True
        Me.txtIdRubro.Key = ""
        Me.txtIdRubro.LabelAsoc = Me.lblIdRubro
        Me.txtIdRubro.Location = New System.Drawing.Point(64, 14)
        Me.txtIdRubro.MaxLength = 9
        Me.txtIdRubro.Name = "txtIdRubro"
        Me.txtIdRubro.Size = New System.Drawing.Size(50, 20)
        Me.txtIdRubro.TabIndex = 1
        Me.txtIdRubro.Text = "0"
        Me.txtIdRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbpComisionPorDesCuento
        '
        Me.tbpComisionPorDesCuento.BackColor = System.Drawing.SystemColors.Control
        Me.tbpComisionPorDesCuento.Controls.Add(Me.btnRefrescarDescRec)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.lblComisionDescRec)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.lblDesRecHasta)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.txtComisionDescRec)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.txtDesRecHasta)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.ugDetalle)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.btnEliminarRubroComsion)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.btnInsertarRubroComsion)
        Me.tbpComisionPorDesCuento.Location = New System.Drawing.Point(4, 22)
        Me.tbpComisionPorDesCuento.Name = "tbpComisionPorDesCuento"
        Me.tbpComisionPorDesCuento.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpComisionPorDesCuento.Size = New System.Drawing.Size(432, 193)
        Me.tbpComisionPorDesCuento.TabIndex = 2
        Me.tbpComisionPorDesCuento.Text = "Comisiones por Descuento Aplicado"
        '
        'btnRefrescarDescRec
        '
        Me.btnRefrescarDescRec.Image = Global.Eniac.Win.My.Resources.Resources.refresh_16
        Me.btnRefrescarDescRec.Location = New System.Drawing.Point(21, 4)
        Me.btnRefrescarDescRec.Name = "btnRefrescarDescRec"
        Me.btnRefrescarDescRec.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarDescRec.TabIndex = 0
        Me.btnRefrescarDescRec.UseVisualStyleBackColor = True
        '
        'lblComisionDescRec
        '
        Me.lblComisionDescRec.AutoSize = True
        Me.lblComisionDescRec.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComisionDescRec.LabelAsoc = Nothing
        Me.lblComisionDescRec.Location = New System.Drawing.Point(224, 9)
        Me.lblComisionDescRec.Name = "lblComisionDescRec"
        Me.lblComisionDescRec.Size = New System.Drawing.Size(60, 13)
        Me.lblComisionDescRec.TabIndex = 3
        Me.lblComisionDescRec.Text = "% Comisión"
        '
        'lblDesRecHasta
        '
        Me.lblDesRecHasta.AutoSize = True
        Me.lblDesRecHasta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDesRecHasta.LabelAsoc = Nothing
        Me.lblDesRecHasta.Location = New System.Drawing.Point(49, 9)
        Me.lblDesRecHasta.Name = "lblDesRecHasta"
        Me.lblDesRecHasta.Size = New System.Drawing.Size(101, 13)
        Me.lblDesRecHasta.TabIndex = 1
        Me.lblDesRecHasta.Text = "% Descuento Hasta"
        '
        'txtComisionDescRec
        '
        Me.txtComisionDescRec.BindearPropiedadControl = ""
        Me.txtComisionDescRec.BindearPropiedadEntidad = ""
        Me.txtComisionDescRec.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComisionDescRec.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComisionDescRec.Formato = "N2"
        Me.txtComisionDescRec.IsDecimal = True
        Me.txtComisionDescRec.IsNumber = True
        Me.txtComisionDescRec.IsPK = False
        Me.txtComisionDescRec.IsRequired = False
        Me.txtComisionDescRec.Key = ""
        Me.txtComisionDescRec.LabelAsoc = Nothing
        Me.txtComisionDescRec.Location = New System.Drawing.Point(290, 6)
        Me.txtComisionDescRec.MaxLength = 15
        Me.txtComisionDescRec.Name = "txtComisionDescRec"
        Me.txtComisionDescRec.Size = New System.Drawing.Size(59, 20)
        Me.txtComisionDescRec.TabIndex = 4
        Me.txtComisionDescRec.Text = "0,00"
        Me.txtComisionDescRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesRecHasta
        '
        Me.txtDesRecHasta.BindearPropiedadControl = ""
        Me.txtDesRecHasta.BindearPropiedadEntidad = ""
        Me.txtDesRecHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDesRecHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDesRecHasta.Formato = "N2"
        Me.txtDesRecHasta.IsDecimal = True
        Me.txtDesRecHasta.IsNumber = True
        Me.txtDesRecHasta.IsPK = False
        Me.txtDesRecHasta.IsRequired = False
        Me.txtDesRecHasta.Key = ""
        Me.txtDesRecHasta.LabelAsoc = Me.lblDesRecHasta
        Me.txtDesRecHasta.Location = New System.Drawing.Point(156, 6)
        Me.txtDesRecHasta.MaxLength = 15
        Me.txtDesRecHasta.Name = "txtDesRecHasta"
        Me.txtDesRecHasta.Size = New System.Drawing.Size(59, 20)
        Me.txtDesRecHasta.TabIndex = 2
        Me.txtDesRecHasta.Text = "0,00"
        Me.txtDesRecHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn4.Header.VisiblePosition = 0
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 50
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance2
        UltraGridColumn5.Format = "N2"
        UltraGridColumn5.Header.Caption = "Hasta"
        UltraGridColumn5.Header.VisiblePosition = 1
        UltraGridColumn5.Width = 70
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn6.CellAppearance = Appearance3
        UltraGridColumn6.Format = "N2"
        UltraGridColumn6.Header.VisiblePosition = 2
        UltraGridColumn6.Width = 76
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn4, UltraGridColumn5, UltraGridColumn6})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance4.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance4
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance5
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BackColor2 = System.Drawing.SystemColors.Control
        Appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance6
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Appearance7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance7
        Appearance8.BackColor = System.Drawing.SystemColors.Highlight
        Appearance8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance8
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance9.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance9
        Appearance10.BorderColor = System.Drawing.Color.Silver
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance10
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance11.BackColor = System.Drawing.SystemColors.Control
        Appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance11.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance11
        Appearance12.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance12
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance13
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance14
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Location = New System.Drawing.Point(21, 32)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(347, 155)
        Me.ugDetalle.TabIndex = 7
        Me.ugDetalle.Text = "Listas de precios a exportar"
        '
        'btnEliminarRubroComsion
        '
        Me.btnEliminarRubroComsion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarRubroComsion.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminarRubroComsion.Location = New System.Drawing.Point(383, 76)
        Me.btnEliminarRubroComsion.Name = "btnEliminarRubroComsion"
        Me.btnEliminarRubroComsion.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarRubroComsion.TabIndex = 6
        Me.btnEliminarRubroComsion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarRubroComsion.UseVisualStyleBackColor = True
        '
        'btnInsertarRubroComsion
        '
        Me.btnInsertarRubroComsion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarRubroComsion.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertarRubroComsion.Location = New System.Drawing.Point(383, 32)
        Me.btnInsertarRubroComsion.Name = "btnInsertarRubroComsion"
        Me.btnInsertarRubroComsion.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarRubroComsion.TabIndex = 5
        Me.btnInsertarRubroComsion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarRubroComsion.UseVisualStyleBackColor = True
        '
        'tbpDescuentos
        '
        Me.tbpDescuentos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDescuentos.Controls.Add(Me.grbUbicacion)
        Me.tbpDescuentos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDescuentos.Name = "tbpDescuentos"
        Me.tbpDescuentos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDescuentos.Size = New System.Drawing.Size(432, 193)
        Me.tbpDescuentos.TabIndex = 1
        Me.tbpDescuentos.Text = "Descuentos"
        '
        'grbUbicacion
        '
        Me.grbUbicacion.Controls.Add(Me.GroupBox1)
        Me.grbUbicacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbUbicacion.Location = New System.Drawing.Point(3, 3)
        Me.grbUbicacion.Name = "grbUbicacion"
        Me.grbUbicacion.Size = New System.Drawing.Size(426, 187)
        Me.grbUbicacion.TabIndex = 0
        Me.grbUbicacion.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUHPorc5)
        Me.GroupBox1.Controls.Add(Me.txtUHPorc4)
        Me.GroupBox1.Controls.Add(Me.txtUHPorc3)
        Me.GroupBox1.Controls.Add(Me.txtUHPorc2)
        Me.GroupBox1.Controls.Add(Me.txtUHPorc1)
        Me.GroupBox1.Controls.Add(Me.txtUnidHasta5)
        Me.GroupBox1.Controls.Add(Me.txtUnidHasta4)
        Me.GroupBox1.Controls.Add(Me.txtUnidHasta3)
        Me.GroupBox1.Controls.Add(Me.txtUnidHasta2)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtUnidHasta1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.lblUHPorc5)
        Me.GroupBox1.Controls.Add(Me.lblUHPorc1)
        Me.GroupBox1.Controls.Add(Me.lblUHPorc4)
        Me.GroupBox1.Controls.Add(Me.lblUnidHasta5)
        Me.GroupBox1.Controls.Add(Me.lblUHPorc2)
        Me.GroupBox1.Controls.Add(Me.lblUnidHasta4)
        Me.GroupBox1.Controls.Add(Me.lblUHPorc3)
        Me.GroupBox1.Controls.Add(Me.lblUnidHasta3)
        Me.GroupBox1.Controls.Add(Me.lblUnidHasta2)
        Me.GroupBox1.Controls.Add(Me.lblUnidHasta1)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 160)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bonificación por Volúmen"
        '
        'txtUHPorc5
        '
        Me.txtUHPorc5.BindearPropiedadControl = "Text"
        Me.txtUHPorc5.BindearPropiedadEntidad = "UHPorc5"
        Me.txtUHPorc5.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUHPorc5.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUHPorc5.Formato = "N2"
        Me.txtUHPorc5.IsDecimal = True
        Me.txtUHPorc5.IsNumber = True
        Me.txtUHPorc5.IsPK = False
        Me.txtUHPorc5.IsRequired = False
        Me.txtUHPorc5.Key = ""
        Me.txtUHPorc5.LabelAsoc = Me.lblUHPorc5
        Me.txtUHPorc5.Location = New System.Drawing.Point(252, 128)
        Me.txtUHPorc5.Name = "txtUHPorc5"
        Me.txtUHPorc5.Size = New System.Drawing.Size(60, 20)
        Me.txtUHPorc5.TabIndex = 23
        Me.txtUHPorc5.Text = "0.00"
        Me.txtUHPorc5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUHPorc5
        '
        Me.lblUHPorc5.AutoSize = True
        Me.lblUHPorc5.LabelAsoc = Nothing
        Me.lblUHPorc5.Location = New System.Drawing.Point(191, 131)
        Me.lblUHPorc5.Name = "lblUHPorc5"
        Me.lblUHPorc5.Size = New System.Drawing.Size(52, 13)
        Me.lblUHPorc5.TabIndex = 22
        Me.lblUHPorc5.Text = "Unidades"
        '
        'txtUHPorc4
        '
        Me.txtUHPorc4.BindearPropiedadControl = "Text"
        Me.txtUHPorc4.BindearPropiedadEntidad = "UHPorc4"
        Me.txtUHPorc4.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUHPorc4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUHPorc4.Formato = "N2"
        Me.txtUHPorc4.IsDecimal = True
        Me.txtUHPorc4.IsNumber = True
        Me.txtUHPorc4.IsPK = False
        Me.txtUHPorc4.IsRequired = False
        Me.txtUHPorc4.Key = ""
        Me.txtUHPorc4.LabelAsoc = Me.lblUHPorc4
        Me.txtUHPorc4.Location = New System.Drawing.Point(252, 102)
        Me.txtUHPorc4.Name = "txtUHPorc4"
        Me.txtUHPorc4.Size = New System.Drawing.Size(60, 20)
        Me.txtUHPorc4.TabIndex = 18
        Me.txtUHPorc4.Text = "0.00"
        Me.txtUHPorc4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUHPorc4
        '
        Me.lblUHPorc4.AutoSize = True
        Me.lblUHPorc4.LabelAsoc = Nothing
        Me.lblUHPorc4.Location = New System.Drawing.Point(191, 105)
        Me.lblUHPorc4.Name = "lblUHPorc4"
        Me.lblUHPorc4.Size = New System.Drawing.Size(52, 13)
        Me.lblUHPorc4.TabIndex = 17
        Me.lblUHPorc4.Text = "Unidades"
        '
        'txtUHPorc3
        '
        Me.txtUHPorc3.BindearPropiedadControl = "Text"
        Me.txtUHPorc3.BindearPropiedadEntidad = "UHPorc3"
        Me.txtUHPorc3.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUHPorc3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUHPorc3.Formato = "N2"
        Me.txtUHPorc3.IsDecimal = True
        Me.txtUHPorc3.IsNumber = True
        Me.txtUHPorc3.IsPK = False
        Me.txtUHPorc3.IsRequired = False
        Me.txtUHPorc3.Key = ""
        Me.txtUHPorc3.LabelAsoc = Me.lblUHPorc3
        Me.txtUHPorc3.Location = New System.Drawing.Point(252, 76)
        Me.txtUHPorc3.Name = "txtUHPorc3"
        Me.txtUHPorc3.Size = New System.Drawing.Size(60, 20)
        Me.txtUHPorc3.TabIndex = 13
        Me.txtUHPorc3.Text = "0.00"
        Me.txtUHPorc3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUHPorc3
        '
        Me.lblUHPorc3.AutoSize = True
        Me.lblUHPorc3.LabelAsoc = Nothing
        Me.lblUHPorc3.Location = New System.Drawing.Point(191, 79)
        Me.lblUHPorc3.Name = "lblUHPorc3"
        Me.lblUHPorc3.Size = New System.Drawing.Size(52, 13)
        Me.lblUHPorc3.TabIndex = 12
        Me.lblUHPorc3.Text = "Unidades"
        '
        'txtUHPorc2
        '
        Me.txtUHPorc2.BindearPropiedadControl = "Text"
        Me.txtUHPorc2.BindearPropiedadEntidad = "UHPorc2"
        Me.txtUHPorc2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUHPorc2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUHPorc2.Formato = "N2"
        Me.txtUHPorc2.IsDecimal = True
        Me.txtUHPorc2.IsNumber = True
        Me.txtUHPorc2.IsPK = False
        Me.txtUHPorc2.IsRequired = False
        Me.txtUHPorc2.Key = ""
        Me.txtUHPorc2.LabelAsoc = Me.lblUHPorc2
        Me.txtUHPorc2.Location = New System.Drawing.Point(252, 50)
        Me.txtUHPorc2.Name = "txtUHPorc2"
        Me.txtUHPorc2.Size = New System.Drawing.Size(60, 20)
        Me.txtUHPorc2.TabIndex = 8
        Me.txtUHPorc2.Text = "0.00"
        Me.txtUHPorc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUHPorc2
        '
        Me.lblUHPorc2.AutoSize = True
        Me.lblUHPorc2.LabelAsoc = Nothing
        Me.lblUHPorc2.Location = New System.Drawing.Point(191, 53)
        Me.lblUHPorc2.Name = "lblUHPorc2"
        Me.lblUHPorc2.Size = New System.Drawing.Size(52, 13)
        Me.lblUHPorc2.TabIndex = 7
        Me.lblUHPorc2.Text = "Unidades"
        '
        'txtUHPorc1
        '
        Me.txtUHPorc1.BindearPropiedadControl = "Text"
        Me.txtUHPorc1.BindearPropiedadEntidad = "UHPorc1"
        Me.txtUHPorc1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUHPorc1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUHPorc1.Formato = "N2"
        Me.txtUHPorc1.IsDecimal = True
        Me.txtUHPorc1.IsNumber = True
        Me.txtUHPorc1.IsPK = False
        Me.txtUHPorc1.IsRequired = False
        Me.txtUHPorc1.Key = ""
        Me.txtUHPorc1.LabelAsoc = Me.lblUHPorc1
        Me.txtUHPorc1.Location = New System.Drawing.Point(252, 24)
        Me.txtUHPorc1.Name = "txtUHPorc1"
        Me.txtUHPorc1.Size = New System.Drawing.Size(60, 20)
        Me.txtUHPorc1.TabIndex = 3
        Me.txtUHPorc1.Text = "0.00"
        Me.txtUHPorc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUHPorc1
        '
        Me.lblUHPorc1.AutoSize = True
        Me.lblUHPorc1.LabelAsoc = Nothing
        Me.lblUHPorc1.Location = New System.Drawing.Point(191, 27)
        Me.lblUHPorc1.Name = "lblUHPorc1"
        Me.lblUHPorc1.Size = New System.Drawing.Size(52, 13)
        Me.lblUHPorc1.TabIndex = 2
        Me.lblUHPorc1.Text = "Unidades"
        '
        'txtUnidHasta5
        '
        Me.txtUnidHasta5.BindearPropiedadControl = "Text"
        Me.txtUnidHasta5.BindearPropiedadEntidad = "UnidHasta5"
        Me.txtUnidHasta5.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUnidHasta5.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUnidHasta5.Formato = "N2"
        Me.txtUnidHasta5.IsDecimal = True
        Me.txtUnidHasta5.IsNumber = True
        Me.txtUnidHasta5.IsPK = False
        Me.txtUnidHasta5.IsRequired = False
        Me.txtUnidHasta5.Key = ""
        Me.txtUnidHasta5.LabelAsoc = Me.lblUnidHasta5
        Me.txtUnidHasta5.Location = New System.Drawing.Point(93, 128)
        Me.txtUnidHasta5.MaxLength = 14
        Me.txtUnidHasta5.Name = "txtUnidHasta5"
        Me.txtUnidHasta5.Size = New System.Drawing.Size(60, 20)
        Me.txtUnidHasta5.TabIndex = 21
        Me.txtUnidHasta5.Text = "0"
        Me.txtUnidHasta5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnidHasta5
        '
        Me.lblUnidHasta5.AutoSize = True
        Me.lblUnidHasta5.LabelAsoc = Nothing
        Me.lblUnidHasta5.Location = New System.Drawing.Point(38, 131)
        Me.lblUnidHasta5.Name = "lblUnidHasta5"
        Me.lblUnidHasta5.Size = New System.Drawing.Size(58, 13)
        Me.lblUnidHasta5.TabIndex = 20
        Me.lblUnidHasta5.Text = "A partir de "
        '
        'txtUnidHasta4
        '
        Me.txtUnidHasta4.BindearPropiedadControl = "Text"
        Me.txtUnidHasta4.BindearPropiedadEntidad = "UnidHasta4"
        Me.txtUnidHasta4.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUnidHasta4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUnidHasta4.Formato = "N2"
        Me.txtUnidHasta4.IsDecimal = True
        Me.txtUnidHasta4.IsNumber = True
        Me.txtUnidHasta4.IsPK = False
        Me.txtUnidHasta4.IsRequired = False
        Me.txtUnidHasta4.Key = ""
        Me.txtUnidHasta4.LabelAsoc = Me.lblUnidHasta4
        Me.txtUnidHasta4.Location = New System.Drawing.Point(93, 102)
        Me.txtUnidHasta4.MaxLength = 14
        Me.txtUnidHasta4.Name = "txtUnidHasta4"
        Me.txtUnidHasta4.Size = New System.Drawing.Size(60, 20)
        Me.txtUnidHasta4.TabIndex = 16
        Me.txtUnidHasta4.Text = "0"
        Me.txtUnidHasta4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnidHasta4
        '
        Me.lblUnidHasta4.AutoSize = True
        Me.lblUnidHasta4.LabelAsoc = Nothing
        Me.lblUnidHasta4.Location = New System.Drawing.Point(38, 105)
        Me.lblUnidHasta4.Name = "lblUnidHasta4"
        Me.lblUnidHasta4.Size = New System.Drawing.Size(58, 13)
        Me.lblUnidHasta4.TabIndex = 15
        Me.lblUnidHasta4.Text = "A partir de "
        '
        'txtUnidHasta3
        '
        Me.txtUnidHasta3.BindearPropiedadControl = "Text"
        Me.txtUnidHasta3.BindearPropiedadEntidad = "UnidHasta3"
        Me.txtUnidHasta3.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUnidHasta3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUnidHasta3.Formato = "N2"
        Me.txtUnidHasta3.IsDecimal = True
        Me.txtUnidHasta3.IsNumber = True
        Me.txtUnidHasta3.IsPK = False
        Me.txtUnidHasta3.IsRequired = False
        Me.txtUnidHasta3.Key = ""
        Me.txtUnidHasta3.LabelAsoc = Me.lblUnidHasta3
        Me.txtUnidHasta3.Location = New System.Drawing.Point(93, 76)
        Me.txtUnidHasta3.MaxLength = 14
        Me.txtUnidHasta3.Name = "txtUnidHasta3"
        Me.txtUnidHasta3.Size = New System.Drawing.Size(60, 20)
        Me.txtUnidHasta3.TabIndex = 11
        Me.txtUnidHasta3.Text = "0"
        Me.txtUnidHasta3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnidHasta3
        '
        Me.lblUnidHasta3.AutoSize = True
        Me.lblUnidHasta3.LabelAsoc = Nothing
        Me.lblUnidHasta3.Location = New System.Drawing.Point(38, 79)
        Me.lblUnidHasta3.Name = "lblUnidHasta3"
        Me.lblUnidHasta3.Size = New System.Drawing.Size(58, 13)
        Me.lblUnidHasta3.TabIndex = 10
        Me.lblUnidHasta3.Text = "A partir de "
        '
        'txtUnidHasta2
        '
        Me.txtUnidHasta2.BindearPropiedadControl = "Text"
        Me.txtUnidHasta2.BindearPropiedadEntidad = "UnidHasta2"
        Me.txtUnidHasta2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUnidHasta2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUnidHasta2.Formato = "N2"
        Me.txtUnidHasta2.IsDecimal = True
        Me.txtUnidHasta2.IsNumber = True
        Me.txtUnidHasta2.IsPK = False
        Me.txtUnidHasta2.IsRequired = False
        Me.txtUnidHasta2.Key = ""
        Me.txtUnidHasta2.LabelAsoc = Me.lblUnidHasta2
        Me.txtUnidHasta2.Location = New System.Drawing.Point(93, 50)
        Me.txtUnidHasta2.MaxLength = 14
        Me.txtUnidHasta2.Name = "txtUnidHasta2"
        Me.txtUnidHasta2.Size = New System.Drawing.Size(60, 20)
        Me.txtUnidHasta2.TabIndex = 6
        Me.txtUnidHasta2.Text = "0"
        Me.txtUnidHasta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnidHasta2
        '
        Me.lblUnidHasta2.AutoSize = True
        Me.lblUnidHasta2.LabelAsoc = Nothing
        Me.lblUnidHasta2.Location = New System.Drawing.Point(38, 53)
        Me.lblUnidHasta2.Name = "lblUnidHasta2"
        Me.lblUnidHasta2.Size = New System.Drawing.Size(58, 13)
        Me.lblUnidHasta2.TabIndex = 5
        Me.lblUnidHasta2.Text = "A partir de "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.LabelAsoc = Nothing
        Me.Label16.Location = New System.Drawing.Point(318, 131)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(15, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "%"
        '
        'txtUnidHasta1
        '
        Me.txtUnidHasta1.BindearPropiedadControl = "Text"
        Me.txtUnidHasta1.BindearPropiedadEntidad = "UnidHasta1"
        Me.txtUnidHasta1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtUnidHasta1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtUnidHasta1.Formato = "N2"
        Me.txtUnidHasta1.IsDecimal = True
        Me.txtUnidHasta1.IsNumber = True
        Me.txtUnidHasta1.IsPK = False
        Me.txtUnidHasta1.IsRequired = False
        Me.txtUnidHasta1.Key = ""
        Me.txtUnidHasta1.LabelAsoc = Me.lblUnidHasta1
        Me.txtUnidHasta1.Location = New System.Drawing.Point(93, 24)
        Me.txtUnidHasta1.MaxLength = 14
        Me.txtUnidHasta1.Name = "txtUnidHasta1"
        Me.txtUnidHasta1.Size = New System.Drawing.Size(60, 20)
        Me.txtUnidHasta1.TabIndex = 1
        Me.txtUnidHasta1.Text = "0"
        Me.txtUnidHasta1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnidHasta1
        '
        Me.lblUnidHasta1.AutoSize = True
        Me.lblUnidHasta1.LabelAsoc = Nothing
        Me.lblUnidHasta1.Location = New System.Drawing.Point(38, 27)
        Me.lblUnidHasta1.Name = "lblUnidHasta1"
        Me.lblUnidHasta1.Size = New System.Drawing.Size(58, 13)
        Me.lblUnidHasta1.TabIndex = 0
        Me.lblUnidHasta1.Text = "A partir de "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.LabelAsoc = Nothing
        Me.Label13.Location = New System.Drawing.Point(318, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.LabelAsoc = Nothing
        Me.Label10.Location = New System.Drawing.Point(318, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.LabelAsoc = Nothing
        Me.Label9.Location = New System.Drawing.Point(318, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.LabelAsoc = Nothing
        Me.Label8.Location = New System.Drawing.Point(318, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "%"
        '
        'tbpDatos
        '
        Me.tbpDatos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDatos.Controls.Add(Me.grbDatosPersonales)
        Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatos.Name = "tbpDatos"
        Me.tbpDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDatos.Size = New System.Drawing.Size(432, 193)
        Me.tbpDatos.TabIndex = 0
        Me.tbpDatos.Text = "Datos"
        '
        'grbDatosPersonales
        '
        Me.grbDatosPersonales.Controls.Add(Me.Label3)
        Me.grbDatosPersonales.Controls.Add(Me.txtDescuentoRecargo2)
        Me.grbDatosPersonales.Controls.Add(Me.lblDescuentoRecargo2)
        Me.grbDatosPersonales.Controls.Add(Me.Label4)
        Me.grbDatosPersonales.Controls.Add(Me.txtDescuentoRecargo1)
        Me.grbDatosPersonales.Controls.Add(Me.lblDescuentoRecargo)
        Me.grbDatosPersonales.Controls.Add(Me.lblOrden)
        Me.grbDatosPersonales.Controls.Add(Me.txtOrden)
        Me.grbDatosPersonales.Controls.Add(Me.Label1)
        Me.grbDatosPersonales.Controls.Add(Me.txtComisionPorVenta)
        Me.grbDatosPersonales.Controls.Add(Me.lblComisionPorVenta)
        Me.grbDatosPersonales.Controls.Add(Me.lblActividad)
        Me.grbDatosPersonales.Controls.Add(Me.cmbActividad)
        Me.grbDatosPersonales.Controls.Add(Me.lblProvincia)
        Me.grbDatosPersonales.Controls.Add(Me.cmbProvincia)
        Me.grbDatosPersonales.Controls.Add(Me.chbAsociaActividad)
        Me.grbDatosPersonales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbDatosPersonales.Location = New System.Drawing.Point(3, 3)
        Me.grbDatosPersonales.Name = "grbDatosPersonales"
        Me.grbDatosPersonales.Size = New System.Drawing.Size(426, 187)
        Me.grbDatosPersonales.TabIndex = 0
        Me.grbDatosPersonales.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(352, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "%"
        '
        'txtDescuentoRecargo2
        '
        Me.txtDescuentoRecargo2.BindearPropiedadControl = "Text"
        Me.txtDescuentoRecargo2.BindearPropiedadEntidad = "DescuentoRecargoPorc2"
        Me.txtDescuentoRecargo2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargo2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargo2.Formato = "##0.00"
        Me.txtDescuentoRecargo2.IsDecimal = True
        Me.txtDescuentoRecargo2.IsNumber = True
        Me.txtDescuentoRecargo2.IsPK = False
        Me.txtDescuentoRecargo2.IsRequired = False
        Me.txtDescuentoRecargo2.Key = ""
        Me.txtDescuentoRecargo2.LabelAsoc = Me.lblDescuentoRecargo2
        Me.txtDescuentoRecargo2.Location = New System.Drawing.Point(292, 45)
        Me.txtDescuentoRecargo2.MaxLength = 5
        Me.txtDescuentoRecargo2.Name = "txtDescuentoRecargo2"
        Me.txtDescuentoRecargo2.Size = New System.Drawing.Size(54, 20)
        Me.txtDescuentoRecargo2.TabIndex = 7
        Me.txtDescuentoRecargo2.Text = "0,00"
        Me.txtDescuentoRecargo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargo2
        '
        Me.lblDescuentoRecargo2.AutoSize = True
        Me.lblDescuentoRecargo2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargo2.LabelAsoc = Nothing
        Me.lblDescuentoRecargo2.Location = New System.Drawing.Point(180, 48)
        Me.lblDescuentoRecargo2.Name = "lblDescuentoRecargo2"
        Me.lblDescuentoRecargo2.Size = New System.Drawing.Size(105, 13)
        Me.lblDescuentoRecargo2.TabIndex = 6
        Me.lblDescuentoRecargo2.Text = "Descto. / Recargo 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(352, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "%"
        '
        'txtDescuentoRecargo1
        '
        Me.txtDescuentoRecargo1.BindearPropiedadControl = "Text"
        Me.txtDescuentoRecargo1.BindearPropiedadEntidad = "DescuentoRecargoPorc1"
        Me.txtDescuentoRecargo1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargo1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargo1.Formato = "##0.00"
        Me.txtDescuentoRecargo1.IsDecimal = True
        Me.txtDescuentoRecargo1.IsNumber = True
        Me.txtDescuentoRecargo1.IsPK = False
        Me.txtDescuentoRecargo1.IsRequired = False
        Me.txtDescuentoRecargo1.Key = ""
        Me.txtDescuentoRecargo1.LabelAsoc = Me.lblDescuentoRecargo
        Me.txtDescuentoRecargo1.Location = New System.Drawing.Point(292, 19)
        Me.txtDescuentoRecargo1.MaxLength = 5
        Me.txtDescuentoRecargo1.Name = "txtDescuentoRecargo1"
        Me.txtDescuentoRecargo1.Size = New System.Drawing.Size(54, 20)
        Me.txtDescuentoRecargo1.TabIndex = 4
        Me.txtDescuentoRecargo1.Text = "0,00"
        Me.txtDescuentoRecargo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargo
        '
        Me.lblDescuentoRecargo.AutoSize = True
        Me.lblDescuentoRecargo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargo.LabelAsoc = Nothing
        Me.lblDescuentoRecargo.Location = New System.Drawing.Point(180, 22)
        Me.lblDescuentoRecargo.Name = "lblDescuentoRecargo"
        Me.lblDescuentoRecargo.Size = New System.Drawing.Size(105, 13)
        Me.lblDescuentoRecargo.TabIndex = 3
        Me.lblDescuentoRecargo.Text = "Descto. / Recargo 1"
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOrden.LabelAsoc = Nothing
        Me.lblOrden.Location = New System.Drawing.Point(9, 153)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 14
        Me.lblOrden.Text = "Orden"
        '
        'txtOrden
        '
        Me.txtOrden.BindearPropiedadControl = "Text"
        Me.txtOrden.BindearPropiedadEntidad = "Orden"
        Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrden.Formato = ""
        Me.txtOrden.IsDecimal = False
        Me.txtOrden.IsNumber = True
        Me.txtOrden.IsPK = False
        Me.txtOrden.IsRequired = True
        Me.txtOrden.Key = ""
        Me.txtOrden.LabelAsoc = Me.lblOrden
        Me.txtOrden.Location = New System.Drawing.Point(87, 149)
        Me.txtOrden.MaxLength = 9
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(54, 20)
        Me.txtOrden.TabIndex = 15
        Me.txtOrden.Text = "0"
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(145, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "%"
        '
        'txtComisionPorVenta
        '
        Me.txtComisionPorVenta.BindearPropiedadControl = "Text"
        Me.txtComisionPorVenta.BindearPropiedadEntidad = "ComisionPorVenta"
        Me.txtComisionPorVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComisionPorVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComisionPorVenta.Formato = "##0.00"
        Me.txtComisionPorVenta.IsDecimal = True
        Me.txtComisionPorVenta.IsNumber = True
        Me.txtComisionPorVenta.IsPK = False
        Me.txtComisionPorVenta.IsRequired = False
        Me.txtComisionPorVenta.Key = ""
        Me.txtComisionPorVenta.LabelAsoc = Me.lblComisionPorVenta
        Me.txtComisionPorVenta.Location = New System.Drawing.Point(87, 28)
        Me.txtComisionPorVenta.MaxLength = 5
        Me.txtComisionPorVenta.Name = "txtComisionPorVenta"
        Me.txtComisionPorVenta.Size = New System.Drawing.Size(54, 20)
        Me.txtComisionPorVenta.TabIndex = 1
        Me.txtComisionPorVenta.Text = "0.00"
        Me.txtComisionPorVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComisionPorVenta
        '
        Me.lblComisionPorVenta.AutoSize = True
        Me.lblComisionPorVenta.LabelAsoc = Nothing
        Me.lblComisionPorVenta.Location = New System.Drawing.Point(9, 31)
        Me.lblComisionPorVenta.Name = "lblComisionPorVenta"
        Me.lblComisionPorVenta.Size = New System.Drawing.Size(71, 13)
        Me.lblComisionPorVenta.TabIndex = 0
        Me.lblComisionPorVenta.Text = "Comisión Vta."
        '
        'lblActividad
        '
        Me.lblActividad.AutoSize = True
        Me.lblActividad.LabelAsoc = Me.chbAsociaActividad
        Me.lblActividad.Location = New System.Drawing.Point(120, 113)
        Me.lblActividad.Name = "lblActividad"
        Me.lblActividad.Size = New System.Drawing.Size(51, 13)
        Me.lblActividad.TabIndex = 12
        Me.lblActividad.Text = "Actividad"
        '
        'chbAsociaActividad
        '
        Me.chbAsociaActividad.AutoSize = True
        Me.chbAsociaActividad.BindearPropiedadControl = ""
        Me.chbAsociaActividad.BindearPropiedadEntidad = ""
        Me.chbAsociaActividad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAsociaActividad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAsociaActividad.IsPK = False
        Me.chbAsociaActividad.IsRequired = False
        Me.chbAsociaActividad.Key = Nothing
        Me.chbAsociaActividad.LabelAsoc = Nothing
        Me.chbAsociaActividad.Location = New System.Drawing.Point(9, 98)
        Me.chbAsociaActividad.Name = "chbAsociaActividad"
        Me.chbAsociaActividad.Size = New System.Drawing.Size(105, 17)
        Me.chbAsociaActividad.TabIndex = 9
        Me.chbAsociaActividad.Text = "Asocia Actividad"
        Me.chbAsociaActividad.UseVisualStyleBackColor = True
        '
        'cmbActividad
        '
        Me.cmbActividad.BindearPropiedadControl = "SelectedValue"
        Me.cmbActividad.BindearPropiedadEntidad = "Actividad.IdActividad"
        Me.cmbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbActividad.Enabled = False
        Me.cmbActividad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbActividad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbActividad.FormattingEnabled = True
        Me.cmbActividad.IsPK = False
        Me.cmbActividad.IsRequired = False
        Me.cmbActividad.Key = Nothing
        Me.cmbActividad.LabelAsoc = Me.lblActividad
        Me.cmbActividad.Location = New System.Drawing.Point(177, 108)
        Me.cmbActividad.Name = "cmbActividad"
        Me.cmbActividad.Size = New System.Drawing.Size(240, 21)
        Me.cmbActividad.TabIndex = 13
        '
        'lblProvincia
        '
        Me.lblProvincia.AutoSize = True
        Me.lblProvincia.LabelAsoc = Me.chbAsociaActividad
        Me.lblProvincia.Location = New System.Drawing.Point(120, 86)
        Me.lblProvincia.Name = "lblProvincia"
        Me.lblProvincia.Size = New System.Drawing.Size(51, 13)
        Me.lblProvincia.TabIndex = 10
        Me.lblProvincia.Text = "Provincia"
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
        Me.cmbProvincia.BindearPropiedadEntidad = "Actividad.IdProvincia"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Enabled = False
        Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.IsPK = False
        Me.cmbProvincia.IsRequired = False
        Me.cmbProvincia.Key = Nothing
        Me.cmbProvincia.LabelAsoc = Me.lblProvincia
        Me.cmbProvincia.Location = New System.Drawing.Point(177, 80)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(152, 21)
        Me.cmbProvincia.TabIndex = 11
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDetalle.Controls.Add(Me.tbpDatos)
        Me.tbcDetalle.Controls.Add(Me.tbpDescuentos)
        Me.tbcDetalle.Controls.Add(Me.tbpComisionPorDesCuento)
        Me.tbcDetalle.Controls.Add(Me.tpTiendaWeb)
        Me.tbcDetalle.Controls.Add(Me.tpExportación)
        Me.tbcDetalle.ItemSize = New System.Drawing.Size(89, 18)
        Me.tbcDetalle.Location = New System.Drawing.Point(12, 77)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(440, 219)
        Me.tbcDetalle.TabIndex = 4
        Me.tbcDetalle.TabStop = False
        '
        'tpTiendaWeb
        '
        Me.tpTiendaWeb.BackColor = System.Drawing.SystemColors.Control
        Me.tpTiendaWeb.Controls.Add(Me.LblRubroML)
        Me.tpTiendaWeb.Controls.Add(Me.Label2)
        Me.tpTiendaWeb.Controls.Add(Me.TxtCodRubML)
        Me.tpTiendaWeb.Controls.Add(Me.TxtCodRubArborea)
        Me.tpTiendaWeb.Controls.Add(Me.chbCategoriasMercadoLibre)
        Me.tpTiendaWeb.Controls.Add(Me.cmbCategoriasMercadoLibre)
        Me.tpTiendaWeb.Controls.Add(Me.lblIdRubroTiendaNube)
        Me.tpTiendaWeb.Controls.Add(Me.txtIdRubroTiendaNube)
        Me.tpTiendaWeb.Location = New System.Drawing.Point(4, 22)
        Me.tpTiendaWeb.Name = "tpTiendaWeb"
        Me.tpTiendaWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTiendaWeb.Size = New System.Drawing.Size(432, 193)
        Me.tpTiendaWeb.TabIndex = 3
        Me.tpTiendaWeb.Text = "Tienda Web"
        '
        'LblRubroML
        '
        Me.LblRubroML.AutoSize = True
        Me.LblRubroML.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LblRubroML.LabelAsoc = Nothing
        Me.LblRubroML.Location = New System.Drawing.Point(7, 43)
        Me.LblRubroML.Name = "LblRubroML"
        Me.LblRubroML.Size = New System.Drawing.Size(132, 13)
        Me.LblRubroML.TabIndex = 32
        Me.LblRubroML.Text = "Cód. Rubro Mercado Libre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(7, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Cód. Rubro Arborea"
        '
        'TxtCodRubML
        '
        Me.TxtCodRubML.BindearPropiedadControl = "Text"
        Me.TxtCodRubML.BindearPropiedadEntidad = "IdRubroMercadoLibre"
        Me.TxtCodRubML.ForeColorFocus = System.Drawing.Color.Red
        Me.TxtCodRubML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.TxtCodRubML.Formato = ""
        Me.TxtCodRubML.IsDecimal = False
        Me.TxtCodRubML.IsNumber = False
        Me.TxtCodRubML.IsPK = False
        Me.TxtCodRubML.IsRequired = False
        Me.TxtCodRubML.Key = ""
        Me.TxtCodRubML.LabelAsoc = Nothing
        Me.TxtCodRubML.Location = New System.Drawing.Point(158, 40)
        Me.TxtCodRubML.MaxLength = 30
        Me.TxtCodRubML.Name = "TxtCodRubML"
        Me.TxtCodRubML.ReadOnly = True
        Me.TxtCodRubML.Size = New System.Drawing.Size(98, 20)
        Me.TxtCodRubML.TabIndex = 30
        Me.TxtCodRubML.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCodRubArborea
        '
        Me.TxtCodRubArborea.BindearPropiedadControl = "Text"
        Me.TxtCodRubArborea.BindearPropiedadEntidad = "IdRubroArborea"
        Me.TxtCodRubArborea.ForeColorFocus = System.Drawing.Color.Red
        Me.TxtCodRubArborea.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.TxtCodRubArborea.Formato = ""
        Me.TxtCodRubArborea.IsDecimal = False
        Me.TxtCodRubArborea.IsNumber = False
        Me.TxtCodRubArborea.IsPK = False
        Me.TxtCodRubArborea.IsRequired = False
        Me.TxtCodRubArborea.Key = ""
        Me.TxtCodRubArborea.LabelAsoc = Nothing
        Me.TxtCodRubArborea.Location = New System.Drawing.Point(158, 66)
        Me.TxtCodRubArborea.MaxLength = 30
        Me.TxtCodRubArborea.Name = "TxtCodRubArborea"
        Me.TxtCodRubArborea.ReadOnly = True
        Me.TxtCodRubArborea.Size = New System.Drawing.Size(98, 20)
        Me.TxtCodRubArborea.TabIndex = 29
        Me.TxtCodRubArborea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbCategoriasMercadoLibre
        '
        Me.chbCategoriasMercadoLibre.AutoSize = True
        Me.chbCategoriasMercadoLibre.BindearPropiedadControl = ""
        Me.chbCategoriasMercadoLibre.BindearPropiedadEntidad = ""
        Me.chbCategoriasMercadoLibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chbCategoriasMercadoLibre.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoriasMercadoLibre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoriasMercadoLibre.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbCategoriasMercadoLibre.IsPK = False
        Me.chbCategoriasMercadoLibre.IsRequired = False
        Me.chbCategoriasMercadoLibre.Key = Nothing
        Me.chbCategoriasMercadoLibre.LabelAsoc = Nothing
        Me.chbCategoriasMercadoLibre.Location = New System.Drawing.Point(10, 100)
        Me.chbCategoriasMercadoLibre.Name = "chbCategoriasMercadoLibre"
        Me.chbCategoriasMercadoLibre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chbCategoriasMercadoLibre.Size = New System.Drawing.Size(142, 17)
        Me.chbCategoriasMercadoLibre.TabIndex = 28
        Me.chbCategoriasMercadoLibre.Text = "Categoria Mercado Libre"
        Me.chbCategoriasMercadoLibre.UseVisualStyleBackColor = True
        Me.chbCategoriasMercadoLibre.Visible = False
        '
        'cmbCategoriasMercadoLibre
        '
        Me.cmbCategoriasMercadoLibre.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoriasMercadoLibre.BindearPropiedadEntidad = "IdRubroMercadoLibre"
        Me.cmbCategoriasMercadoLibre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriasMercadoLibre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbCategoriasMercadoLibre.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriasMercadoLibre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriasMercadoLibre.FormattingEnabled = True
        Me.cmbCategoriasMercadoLibre.IsPK = False
        Me.cmbCategoriasMercadoLibre.IsRequired = False
        Me.cmbCategoriasMercadoLibre.Key = Nothing
        Me.cmbCategoriasMercadoLibre.LabelAsoc = Nothing
        Me.cmbCategoriasMercadoLibre.Location = New System.Drawing.Point(158, 97)
        Me.cmbCategoriasMercadoLibre.Name = "cmbCategoriasMercadoLibre"
        Me.cmbCategoriasMercadoLibre.Size = New System.Drawing.Size(259, 21)
        Me.cmbCategoriasMercadoLibre.TabIndex = 27
        Me.cmbCategoriasMercadoLibre.Visible = False
        '
        'lblIdRubroTiendaNube
        '
        Me.lblIdRubroTiendaNube.AutoSize = True
        Me.lblIdRubroTiendaNube.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdRubroTiendaNube.LabelAsoc = Nothing
        Me.lblIdRubroTiendaNube.Location = New System.Drawing.Point(6, 17)
        Me.lblIdRubroTiendaNube.Name = "lblIdRubroTiendaNube"
        Me.lblIdRubroTiendaNube.Size = New System.Drawing.Size(126, 13)
        Me.lblIdRubroTiendaNube.TabIndex = 4
        Me.lblIdRubroTiendaNube.Text = "Cód. Rubro Tienda Nube"
        '
        'txtIdRubroTiendaNube
        '
        Me.txtIdRubroTiendaNube.BindearPropiedadControl = "Text"
        Me.txtIdRubroTiendaNube.BindearPropiedadEntidad = "IdRubroTiendaNube"
        Me.txtIdRubroTiendaNube.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdRubroTiendaNube.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdRubroTiendaNube.Formato = ""
        Me.txtIdRubroTiendaNube.IsDecimal = False
        Me.txtIdRubroTiendaNube.IsNumber = False
        Me.txtIdRubroTiendaNube.IsPK = False
        Me.txtIdRubroTiendaNube.IsRequired = False
        Me.txtIdRubroTiendaNube.Key = ""
        Me.txtIdRubroTiendaNube.LabelAsoc = Nothing
        Me.txtIdRubroTiendaNube.Location = New System.Drawing.Point(158, 14)
        Me.txtIdRubroTiendaNube.MaxLength = 30
        Me.txtIdRubroTiendaNube.Name = "txtIdRubroTiendaNube"
        Me.txtIdRubroTiendaNube.ReadOnly = True
        Me.txtIdRubroTiendaNube.Size = New System.Drawing.Size(98, 20)
        Me.txtIdRubroTiendaNube.TabIndex = 3
        Me.txtIdRubroTiendaNube.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tpExportación
        '
        Me.tpExportación.BackColor = System.Drawing.SystemColors.Control
        Me.tpExportación.Controls.Add(Me.lblCodigoExportacion)
        Me.tpExportación.Controls.Add(Me.txtCodigoExportacion)
        Me.tpExportación.Location = New System.Drawing.Point(4, 22)
        Me.tpExportación.Name = "tpExportación"
        Me.tpExportación.Padding = New System.Windows.Forms.Padding(3)
        Me.tpExportación.Size = New System.Drawing.Size(432, 193)
        Me.tpExportación.TabIndex = 3
        Me.tpExportación.Text = "Exportación"
        '
        'lblCodigoExportacion
        '
        Me.lblCodigoExportacion.AutoSize = True
        Me.lblCodigoExportacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoExportacion.LabelAsoc = Nothing
        Me.lblCodigoExportacion.Location = New System.Drawing.Point(10, 17)
        Me.lblCodigoExportacion.Name = "lblCodigoExportacion"
        Me.lblCodigoExportacion.Size = New System.Drawing.Size(88, 13)
        Me.lblCodigoExportacion.TabIndex = 2
        Me.lblCodigoExportacion.Text = "Cód. Exportación"
        '
        'txtCodigoExportacion
        '
        Me.txtCodigoExportacion.BindearPropiedadControl = "Text"
        Me.txtCodigoExportacion.BindearPropiedadEntidad = "CodigoExportacion"
        Me.txtCodigoExportacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoExportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoExportacion.Formato = "##0.00"
        Me.txtCodigoExportacion.IsDecimal = False
        Me.txtCodigoExportacion.IsNumber = False
        Me.txtCodigoExportacion.IsPK = False
        Me.txtCodigoExportacion.IsRequired = False
        Me.txtCodigoExportacion.Key = ""
        Me.txtCodigoExportacion.LabelAsoc = Nothing
        Me.txtCodigoExportacion.Location = New System.Drawing.Point(109, 14)
        Me.txtCodigoExportacion.MaxLength = 5
        Me.txtCodigoExportacion.Name = "txtCodigoExportacion"
        Me.txtCodigoExportacion.Size = New System.Drawing.Size(91, 20)
        Me.txtCodigoExportacion.TabIndex = 1
        '
        'RubrosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(460, 337)
        Me.Controls.Add(Me.lblNombreRubro)
        Me.Controls.Add(Me.txtNombreRubro)
        Me.Controls.Add(Me.lblIdRubro)
        Me.Controls.Add(Me.txtIdRubro)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RubrosDetalle"
        Me.Text = "Rubro"
        Me.Controls.SetChildIndex(Me.tbcDetalle, 0)
        Me.Controls.SetChildIndex(Me.txtIdRubro, 0)
        Me.Controls.SetChildIndex(Me.lblIdRubro, 0)
        Me.Controls.SetChildIndex(Me.txtNombreRubro, 0)
        Me.Controls.SetChildIndex(Me.lblNombreRubro, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.tbpComisionPorDesCuento.ResumeLayout(False)
        Me.tbpComisionPorDesCuento.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpDescuentos.ResumeLayout(False)
        Me.grbUbicacion.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbpDatos.ResumeLayout(False)
        Me.grbDatosPersonales.ResumeLayout(False)
        Me.grbDatosPersonales.PerformLayout()
        Me.tbcDetalle.ResumeLayout(False)
        Me.tpTiendaWeb.ResumeLayout(False)
        Me.tpTiendaWeb.PerformLayout()
        Me.tpExportación.ResumeLayout(False)
        Me.tpExportación.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreRubro As Eniac.Controles.Label
    Friend WithEvents txtNombreRubro As Eniac.Controles.TextBox
    Friend WithEvents lblIdRubro As Eniac.Controles.Label
    Friend WithEvents txtIdRubro As Eniac.Controles.TextBox
    Friend WithEvents tbpComisionPorDesCuento As System.Windows.Forms.TabPage
    Friend WithEvents tbpDescuentos As System.Windows.Forms.TabPage
    Friend WithEvents grbUbicacion As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUHPorc5 As Eniac.Controles.TextBox
    Friend WithEvents lblUHPorc5 As Eniac.Controles.Label
    Friend WithEvents txtUHPorc4 As Eniac.Controles.TextBox
    Friend WithEvents lblUHPorc4 As Eniac.Controles.Label
    Friend WithEvents txtUHPorc3 As Eniac.Controles.TextBox
    Friend WithEvents lblUHPorc3 As Eniac.Controles.Label
    Friend WithEvents txtUHPorc2 As Eniac.Controles.TextBox
    Friend WithEvents lblUHPorc2 As Eniac.Controles.Label
    Friend WithEvents txtUHPorc1 As Eniac.Controles.TextBox
    Friend WithEvents lblUHPorc1 As Eniac.Controles.Label
    Friend WithEvents txtUnidHasta5 As Eniac.Controles.TextBox
    Friend WithEvents lblUnidHasta5 As Eniac.Controles.Label
    Friend WithEvents txtUnidHasta4 As Eniac.Controles.TextBox
    Friend WithEvents lblUnidHasta4 As Eniac.Controles.Label
    Friend WithEvents txtUnidHasta3 As Eniac.Controles.TextBox
    Friend WithEvents lblUnidHasta3 As Eniac.Controles.Label
    Friend WithEvents txtUnidHasta2 As Eniac.Controles.TextBox
    Friend WithEvents lblUnidHasta2 As Eniac.Controles.Label
    Friend WithEvents Label16 As Eniac.Controles.Label
    Friend WithEvents txtUnidHasta1 As Eniac.Controles.TextBox
    Friend WithEvents lblUnidHasta1 As Eniac.Controles.Label
    Friend WithEvents Label13 As Eniac.Controles.Label
    Friend WithEvents Label10 As Eniac.Controles.Label
    Friend WithEvents Label9 As Eniac.Controles.Label
    Friend WithEvents Label8 As Eniac.Controles.Label
    Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
    Friend WithEvents grbDatosPersonales As System.Windows.Forms.GroupBox
    Friend WithEvents lblOrden As Eniac.Controles.Label
    Friend WithEvents txtOrden As Eniac.Controles.TextBox
    Friend WithEvents Label1 As Eniac.Controles.Label
    Friend WithEvents txtComisionPorVenta As Eniac.Controles.TextBox
    Friend WithEvents lblComisionPorVenta As Eniac.Controles.Label
    Friend WithEvents lblActividad As Eniac.Controles.Label
    Friend WithEvents chbAsociaActividad As Eniac.Controles.CheckBox
    Friend WithEvents cmbActividad As Eniac.Controles.ComboBox
    Friend WithEvents lblProvincia As Eniac.Controles.Label
    Friend WithEvents cmbProvincia As Eniac.Controles.ComboBox
    Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnEliminarRubroComsion As Eniac.Controles.Button
    Friend WithEvents btnInsertarRubroComsion As Eniac.Controles.Button
    Friend WithEvents txtComisionDescRec As Eniac.Controles.TextBox
    Friend WithEvents txtDesRecHasta As Eniac.Controles.TextBox
    Friend WithEvents lblComisionDescRec As Eniac.Controles.Label
    Friend WithEvents lblDesRecHasta As Eniac.Controles.Label
    Friend WithEvents btnRefrescarDescRec As System.Windows.Forms.Button
    Friend WithEvents Label3 As Eniac.Controles.Label
    Friend WithEvents txtDescuentoRecargo2 As Eniac.Controles.TextBox
    Friend WithEvents lblDescuentoRecargo2 As Eniac.Controles.Label
    Friend WithEvents Label4 As Eniac.Controles.Label
    Friend WithEvents txtDescuentoRecargo1 As Eniac.Controles.TextBox
    Friend WithEvents lblDescuentoRecargo As Eniac.Controles.Label
    Friend WithEvents tpTiendaWeb As System.Windows.Forms.TabPage
    Friend WithEvents txtIdRubroTiendaNube As Eniac.Controles.TextBox
    Friend WithEvents tpExportación As System.Windows.Forms.TabPage
    Friend WithEvents txtCodigoExportacion As Eniac.Controles.TextBox
    Friend WithEvents lblIdRubroTiendaNube As Controles.Label
    Friend WithEvents lblCodigoExportacion As Controles.Label
    Friend WithEvents chbCategoriasMercadoLibre As Controles.CheckBox
    Friend WithEvents cmbCategoriasMercadoLibre As Controles.ComboBox
    Friend WithEvents LblRubroML As Controles.Label
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents TxtCodRubML As Controles.TextBox
    Friend WithEvents TxtCodRubArborea As Controles.TextBox
End Class
