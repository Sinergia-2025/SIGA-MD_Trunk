<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SubRubrosDetalle
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
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSubRubro")
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SubRubrosDetalle))
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtNombreSubRubro = New Eniac.Controles.TextBox()
        Me.lblIdSubRubro = New Eniac.Controles.Label()
        Me.txtIdSubRubro = New Eniac.Controles.TextBox()
        Me.txtDescuentoRecargoPorc1 = New Eniac.Controles.TextBox()
        Me.lblDescuentoRecargo = New Eniac.Controles.Label()
        Me.bscCodigoRubro = New Eniac.Controles.Buscador()
        Me.lblRubro = New Eniac.Controles.Label()
        Me.bscRubro = New Eniac.Controles.Buscador()
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
        Me.LblPorct6 = New Eniac.Controles.Label()
        Me.txtUnidHasta1 = New Eniac.Controles.TextBox()
        Me.lblUnidHasta1 = New Eniac.Controles.Label()
        Me.LblPorct5 = New Eniac.Controles.Label()
        Me.LblPorct3 = New Eniac.Controles.Label()
        Me.LblPorct4 = New Eniac.Controles.Label()
        Me.LblPorct2 = New Eniac.Controles.Label()
        Me.tbcDetalle = New System.Windows.Forms.TabControl()
        Me.tbpDescuentos = New System.Windows.Forms.TabPage()
        Me.LblPorct = New Eniac.Controles.Label()
        Me.txtDescuentoRecargoPorc2 = New Eniac.Controles.TextBox()
        Me.lblDescuentoRecargo2 = New Eniac.Controles.Label()
        Me.tbpComisionPorDesCuento = New System.Windows.Forms.TabPage()
        Me.btnRefrescarDescRec = New System.Windows.Forms.Button()
        Me.LlblComisonPorc = New Eniac.Controles.Label()
        Me.lblDesRecHasta = New Eniac.Controles.Label()
        Me.txtComisionDescRec = New Eniac.Controles.TextBox()
        Me.txtDesRecHasta = New Eniac.Controles.TextBox()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.btnEliminarSubRubroComsion = New Eniac.Controles.Button()
        Me.btnInsertarSubRubroComsion = New Eniac.Controles.Button()
        Me.tpTiendasWeb = New System.Windows.Forms.TabPage()
        Me.txtIdSubRubroML = New Eniac.Controles.TextBox()
        Me.lblIdSubRubroML = New Eniac.Controles.Label()
        Me.txtIdSubRubroTiendaNube = New Eniac.Controles.TextBox()
        Me.lblIdSubRubroTiendaNube = New Eniac.Controles.Label()
        Me.tpExportacion = New System.Windows.Forms.TabPage()
        Me.txtCodigoExportacion = New Eniac.Controles.TextBox()
        Me.Label7 = New Eniac.Controles.Label()
        Me.tpAtributos = New System.Windows.Forms.TabPage()
        Me.lblMensajeSubRubroAtributo = New Eniac.Controles.Label()
        Me.bscDescripcionGrupoAtributo04 = New Eniac.Controles.Buscador2()
        Me.chbAtributo04 = New Eniac.Controles.CheckBox()
        Me.bscCodigoGrupoAtributo04 = New Eniac.Controles.Buscador2()
        Me.bscDescripcionGrupoAtributo03 = New Eniac.Controles.Buscador2()
        Me.chbAtributo03 = New Eniac.Controles.CheckBox()
        Me.bscCodigoGrupoAtributo03 = New Eniac.Controles.Buscador2()
        Me.bscDescripcionGrupoAtributo02 = New Eniac.Controles.Buscador2()
        Me.chbAtributo02 = New Eniac.Controles.CheckBox()
        Me.bscCodigoGrupoAtributo02 = New Eniac.Controles.Buscador2()
        Me.bscDescripcionGrupoAtributo01 = New Eniac.Controles.Buscador2()
        Me.chbAtributo01 = New Eniac.Controles.CheckBox()
        Me.bscCodigoGrupoAtributo01 = New Eniac.Controles.Buscador2()
        Me.txtIdSubRubroArborea = New Eniac.Controles.TextBox()
        Me.lblIdSubRubroArborea = New Eniac.Controles.Label()
        Me.GroupBox1.SuspendLayout()
        Me.tbcDetalle.SuspendLayout()
        Me.tbpDescuentos.SuspendLayout()
        Me.tbpComisionPorDesCuento.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpTiendasWeb.SuspendLayout()
        Me.tpExportacion.SuspendLayout()
        Me.tpAtributos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(274, 352)
        Me.btnAceptar.TabIndex = 9
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(360, 352)
        Me.btnCancelar.TabIndex = 10
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(41, 414)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(-16, 414)
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(12, 82)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombreSubRubro
        '
        Me.txtNombreSubRubro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombreSubRubro.BindearPropiedadControl = "Text"
        Me.txtNombreSubRubro.BindearPropiedadEntidad = "NombreSubRubro"
        Me.txtNombreSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreSubRubro.Formato = ""
        Me.txtNombreSubRubro.IsDecimal = False
        Me.txtNombreSubRubro.IsNumber = False
        Me.txtNombreSubRubro.IsPK = False
        Me.txtNombreSubRubro.IsRequired = True
        Me.txtNombreSubRubro.Key = ""
        Me.txtNombreSubRubro.LabelAsoc = Me.lblNombre
        Me.txtNombreSubRubro.Location = New System.Drawing.Point(61, 79)
        Me.txtNombreSubRubro.MaxLength = 50
        Me.txtNombreSubRubro.Name = "txtNombreSubRubro"
        Me.txtNombreSubRubro.Size = New System.Drawing.Size(409, 20)
        Me.txtNombreSubRubro.TabIndex = 6
        '
        'lblIdSubRubro
        '
        Me.lblIdSubRubro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdSubRubro.AutoSize = True
        Me.lblIdSubRubro.LabelAsoc = Nothing
        Me.lblIdSubRubro.Location = New System.Drawing.Point(12, 54)
        Me.lblIdSubRubro.Name = "lblIdSubRubro"
        Me.lblIdSubRubro.Size = New System.Drawing.Size(40, 13)
        Me.lblIdSubRubro.TabIndex = 3
        Me.lblIdSubRubro.Text = "Código"
        '
        'txtIdSubRubro
        '
        Me.txtIdSubRubro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIdSubRubro.BindearPropiedadControl = "Text"
        Me.txtIdSubRubro.BindearPropiedadEntidad = "IdSubRubro"
        Me.txtIdSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubRubro.Formato = ""
        Me.txtIdSubRubro.IsDecimal = False
        Me.txtIdSubRubro.IsNumber = True
        Me.txtIdSubRubro.IsPK = True
        Me.txtIdSubRubro.IsRequired = True
        Me.txtIdSubRubro.Key = ""
        Me.txtIdSubRubro.LabelAsoc = Me.lblIdSubRubro
        Me.txtIdSubRubro.Location = New System.Drawing.Point(61, 51)
        Me.txtIdSubRubro.MaxLength = 4
        Me.txtIdSubRubro.Name = "txtIdSubRubro"
        Me.txtIdSubRubro.Size = New System.Drawing.Size(77, 20)
        Me.txtIdSubRubro.TabIndex = 9
        Me.txtIdSubRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescuentoRecargoPorc1
        '
        Me.txtDescuentoRecargoPorc1.BindearPropiedadControl = "Text"
        Me.txtDescuentoRecargoPorc1.BindearPropiedadEntidad = "DescuentoRecargoPorc1"
        Me.txtDescuentoRecargoPorc1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc1.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc1.IsDecimal = True
        Me.txtDescuentoRecargoPorc1.IsNumber = True
        Me.txtDescuentoRecargoPorc1.IsPK = False
        Me.txtDescuentoRecargoPorc1.IsRequired = True
        Me.txtDescuentoRecargoPorc1.Key = ""
        Me.txtDescuentoRecargoPorc1.LabelAsoc = Me.lblDescuentoRecargo
        Me.txtDescuentoRecargoPorc1.Location = New System.Drawing.Point(151, 9)
        Me.txtDescuentoRecargoPorc1.MaxLength = 5
        Me.txtDescuentoRecargoPorc1.Name = "txtDescuentoRecargoPorc1"
        Me.txtDescuentoRecargoPorc1.Size = New System.Drawing.Size(54, 20)
        Me.txtDescuentoRecargoPorc1.TabIndex = 1
        Me.txtDescuentoRecargoPorc1.Text = "0,00"
        Me.txtDescuentoRecargoPorc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargo
        '
        Me.lblDescuentoRecargo.AutoSize = True
        Me.lblDescuentoRecargo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargo.LabelAsoc = Nothing
        Me.lblDescuentoRecargo.Location = New System.Drawing.Point(44, 12)
        Me.lblDescuentoRecargo.Name = "lblDescuentoRecargo"
        Me.lblDescuentoRecargo.Size = New System.Drawing.Size(105, 13)
        Me.lblDescuentoRecargo.TabIndex = 0
        Me.lblDescuentoRecargo.Text = "Descto. / Recargo 1"
        '
        'bscCodigoRubro
        '
        Me.bscCodigoRubro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoRubro.AyudaAncho = 608
        Me.bscCodigoRubro.BindearPropiedadControl = "Text"
        Me.bscCodigoRubro.BindearPropiedadEntidad = "IdRubro"
        Me.bscCodigoRubro.ColumnasAlineacion = Nothing
        Me.bscCodigoRubro.ColumnasAncho = Nothing
        Me.bscCodigoRubro.ColumnasFormato = Nothing
        Me.bscCodigoRubro.ColumnasOcultas = Nothing
        Me.bscCodigoRubro.ColumnasTitulos = Nothing
        Me.bscCodigoRubro.Datos = Nothing
        Me.bscCodigoRubro.FilaDevuelta = Nothing
        Me.bscCodigoRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro.IsDecimal = False
        Me.bscCodigoRubro.IsNumber = True
        Me.bscCodigoRubro.IsPK = True
        Me.bscCodigoRubro.IsRequired = True
        Me.bscCodigoRubro.Key = ""
        Me.bscCodigoRubro.LabelAsoc = Me.lblRubro
        Me.bscCodigoRubro.Location = New System.Drawing.Point(61, 22)
        Me.bscCodigoRubro.MaxLengh = "32767"
        Me.bscCodigoRubro.Name = "bscCodigoRubro"
        Me.bscCodigoRubro.Permitido = True
        Me.bscCodigoRubro.Selecciono = False
        Me.bscCodigoRubro.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoRubro.TabIndex = 1
        Me.bscCodigoRubro.Titulo = Nothing
        '
        'lblRubro
        '
        Me.lblRubro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(12, 22)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 0
        Me.lblRubro.Text = "Rubro"
        '
        'bscRubro
        '
        Me.bscRubro.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscRubro.AyudaAncho = 608
        Me.bscRubro.BindearPropiedadControl = Nothing
        Me.bscRubro.BindearPropiedadEntidad = Nothing
        Me.bscRubro.ColumnasAlineacion = Nothing
        Me.bscRubro.ColumnasAncho = Nothing
        Me.bscRubro.ColumnasFormato = Nothing
        Me.bscRubro.ColumnasOcultas = Nothing
        Me.bscRubro.ColumnasTitulos = Nothing
        Me.bscRubro.Datos = Nothing
        Me.bscRubro.FilaDevuelta = Nothing
        Me.bscRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.bscRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscRubro.IsDecimal = False
        Me.bscRubro.IsNumber = False
        Me.bscRubro.IsPK = True
        Me.bscRubro.IsRequired = True
        Me.bscRubro.Key = ""
        Me.bscRubro.LabelAsoc = Me.lblRubro
        Me.bscRubro.Location = New System.Drawing.Point(158, 22)
        Me.bscRubro.MaxLengh = "32767"
        Me.bscRubro.Name = "bscRubro"
        Me.bscRubro.Permitido = True
        Me.bscRubro.Selecciono = False
        Me.bscRubro.Size = New System.Drawing.Size(312, 20)
        Me.bscRubro.TabIndex = 2
        Me.bscRubro.Titulo = Nothing
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
        Me.GroupBox1.Controls.Add(Me.LblPorct6)
        Me.GroupBox1.Controls.Add(Me.txtUnidHasta1)
        Me.GroupBox1.Controls.Add(Me.LblPorct5)
        Me.GroupBox1.Controls.Add(Me.LblPorct3)
        Me.GroupBox1.Controls.Add(Me.LblPorct4)
        Me.GroupBox1.Controls.Add(Me.LblPorct2)
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
        Me.GroupBox1.Location = New System.Drawing.Point(47, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 160)
        Me.GroupBox1.TabIndex = 5
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
        'LblPorct6
        '
        Me.LblPorct6.AutoSize = True
        Me.LblPorct6.LabelAsoc = Nothing
        Me.LblPorct6.Location = New System.Drawing.Point(318, 131)
        Me.LblPorct6.Name = "LblPorct6"
        Me.LblPorct6.Size = New System.Drawing.Size(15, 13)
        Me.LblPorct6.TabIndex = 24
        Me.LblPorct6.Text = "%"
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
        'LblPorct5
        '
        Me.LblPorct5.AutoSize = True
        Me.LblPorct5.LabelAsoc = Nothing
        Me.LblPorct5.Location = New System.Drawing.Point(318, 105)
        Me.LblPorct5.Name = "LblPorct5"
        Me.LblPorct5.Size = New System.Drawing.Size(15, 13)
        Me.LblPorct5.TabIndex = 19
        Me.LblPorct5.Text = "%"
        '
        'LblPorct3
        '
        Me.LblPorct3.AutoSize = True
        Me.LblPorct3.LabelAsoc = Nothing
        Me.LblPorct3.Location = New System.Drawing.Point(318, 53)
        Me.LblPorct3.Name = "LblPorct3"
        Me.LblPorct3.Size = New System.Drawing.Size(15, 13)
        Me.LblPorct3.TabIndex = 9
        Me.LblPorct3.Text = "%"
        '
        'LblPorct4
        '
        Me.LblPorct4.AutoSize = True
        Me.LblPorct4.LabelAsoc = Nothing
        Me.LblPorct4.Location = New System.Drawing.Point(318, 79)
        Me.LblPorct4.Name = "LblPorct4"
        Me.LblPorct4.Size = New System.Drawing.Size(15, 13)
        Me.LblPorct4.TabIndex = 14
        Me.LblPorct4.Text = "%"
        '
        'LblPorct2
        '
        Me.LblPorct2.AutoSize = True
        Me.LblPorct2.LabelAsoc = Nothing
        Me.LblPorct2.Location = New System.Drawing.Point(318, 27)
        Me.LblPorct2.Name = "LblPorct2"
        Me.LblPorct2.Size = New System.Drawing.Size(15, 13)
        Me.LblPorct2.TabIndex = 4
        Me.LblPorct2.Text = "%"
        '
        'tbcDetalle
        '
        Me.tbcDetalle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbcDetalle.Controls.Add(Me.tbpDescuentos)
        Me.tbcDetalle.Controls.Add(Me.tbpComisionPorDesCuento)
        Me.tbcDetalle.Controls.Add(Me.tpTiendasWeb)
        Me.tbcDetalle.Controls.Add(Me.tpExportacion)
        Me.tbcDetalle.Controls.Add(Me.tpAtributos)
        Me.tbcDetalle.ItemSize = New System.Drawing.Size(89, 18)
        Me.tbcDetalle.Location = New System.Drawing.Point(11, 111)
        Me.tbcDetalle.Name = "tbcDetalle"
        Me.tbcDetalle.SelectedIndex = 0
        Me.tbcDetalle.Size = New System.Drawing.Size(463, 235)
        Me.tbcDetalle.TabIndex = 17
        Me.tbcDetalle.TabStop = False
        '
        'tbpDescuentos
        '
        Me.tbpDescuentos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDescuentos.Controls.Add(Me.LblPorct)
        Me.tbpDescuentos.Controls.Add(Me.txtDescuentoRecargoPorc2)
        Me.tbpDescuentos.Controls.Add(Me.lblDescuentoRecargo2)
        Me.tbpDescuentos.Controls.Add(Me.GroupBox1)
        Me.tbpDescuentos.Controls.Add(Me.txtDescuentoRecargoPorc1)
        Me.tbpDescuentos.Controls.Add(Me.lblDescuentoRecargo)
        Me.tbpDescuentos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDescuentos.Name = "tbpDescuentos"
        Me.tbpDescuentos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDescuentos.Size = New System.Drawing.Size(455, 209)
        Me.tbpDescuentos.TabIndex = 1
        Me.tbpDescuentos.Text = "Descuentos"
        '
        'LblPorct
        '
        Me.LblPorct.AutoSize = True
        Me.LblPorct.LabelAsoc = Nothing
        Me.LblPorct.Location = New System.Drawing.Point(394, 12)
        Me.LblPorct.Name = "LblPorct"
        Me.LblPorct.Size = New System.Drawing.Size(15, 13)
        Me.LblPorct.TabIndex = 4
        Me.LblPorct.Text = "%"
        '
        'txtDescuentoRecargoPorc2
        '
        Me.txtDescuentoRecargoPorc2.BindearPropiedadControl = "Text"
        Me.txtDescuentoRecargoPorc2.BindearPropiedadEntidad = "DescuentoRecargoPorc2"
        Me.txtDescuentoRecargoPorc2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc2.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc2.IsDecimal = True
        Me.txtDescuentoRecargoPorc2.IsNumber = True
        Me.txtDescuentoRecargoPorc2.IsPK = False
        Me.txtDescuentoRecargoPorc2.IsRequired = True
        Me.txtDescuentoRecargoPorc2.Key = ""
        Me.txtDescuentoRecargoPorc2.LabelAsoc = Me.lblDescuentoRecargo2
        Me.txtDescuentoRecargoPorc2.Location = New System.Drawing.Point(328, 9)
        Me.txtDescuentoRecargoPorc2.MaxLength = 5
        Me.txtDescuentoRecargoPorc2.Name = "txtDescuentoRecargoPorc2"
        Me.txtDescuentoRecargoPorc2.Size = New System.Drawing.Size(54, 20)
        Me.txtDescuentoRecargoPorc2.TabIndex = 3
        Me.txtDescuentoRecargoPorc2.Text = "0,00"
        Me.txtDescuentoRecargoPorc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargo2
        '
        Me.lblDescuentoRecargo2.AutoSize = True
        Me.lblDescuentoRecargo2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargo2.LabelAsoc = Nothing
        Me.lblDescuentoRecargo2.Location = New System.Drawing.Point(216, 12)
        Me.lblDescuentoRecargo2.Name = "lblDescuentoRecargo2"
        Me.lblDescuentoRecargo2.Size = New System.Drawing.Size(105, 13)
        Me.lblDescuentoRecargo2.TabIndex = 2
        Me.lblDescuentoRecargo2.Text = "Descto. / Recargo 2"
        '
        'tbpComisionPorDesCuento
        '
        Me.tbpComisionPorDesCuento.BackColor = System.Drawing.SystemColors.Control
        Me.tbpComisionPorDesCuento.Controls.Add(Me.btnRefrescarDescRec)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.LlblComisonPorc)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.lblDesRecHasta)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.txtComisionDescRec)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.txtDesRecHasta)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.ugDetalle)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.btnEliminarSubRubroComsion)
        Me.tbpComisionPorDesCuento.Controls.Add(Me.btnInsertarSubRubroComsion)
        Me.tbpComisionPorDesCuento.Location = New System.Drawing.Point(4, 22)
        Me.tbpComisionPorDesCuento.Name = "tbpComisionPorDesCuento"
        Me.tbpComisionPorDesCuento.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpComisionPorDesCuento.Size = New System.Drawing.Size(455, 209)
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
        'LlblComisonPorc
        '
        Me.LlblComisonPorc.AutoSize = True
        Me.LlblComisonPorc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LlblComisonPorc.LabelAsoc = Nothing
        Me.LlblComisonPorc.Location = New System.Drawing.Point(224, 9)
        Me.LlblComisonPorc.Name = "LlblComisonPorc"
        Me.LlblComisonPorc.Size = New System.Drawing.Size(60, 13)
        Me.LlblComisonPorc.TabIndex = 3
        Me.LlblComisonPorc.Text = "% Comisión"
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
        Me.txtComisionDescRec.LabelAsoc = Me.LlblComisonPorc
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
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
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
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn5, UltraGridColumn6})
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
        Me.ugDetalle.Size = New System.Drawing.Size(370, 171)
        Me.ugDetalle.TabIndex = 7
        Me.ugDetalle.Text = "Listas de precios a exportar"
        '
        'btnEliminarSubRubroComsion
        '
        Me.btnEliminarSubRubroComsion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarSubRubroComsion.Image = Global.Eniac.Win.My.Resources.Resources.delete_32
        Me.btnEliminarSubRubroComsion.Location = New System.Drawing.Point(406, 76)
        Me.btnEliminarSubRubroComsion.Name = "btnEliminarSubRubroComsion"
        Me.btnEliminarSubRubroComsion.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarSubRubroComsion.TabIndex = 6
        Me.btnEliminarSubRubroComsion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarSubRubroComsion.UseVisualStyleBackColor = True
        '
        'btnInsertarSubRubroComsion
        '
        Me.btnInsertarSubRubroComsion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarSubRubroComsion.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertarSubRubroComsion.Location = New System.Drawing.Point(406, 32)
        Me.btnInsertarSubRubroComsion.Name = "btnInsertarSubRubroComsion"
        Me.btnInsertarSubRubroComsion.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarSubRubroComsion.TabIndex = 5
        Me.btnInsertarSubRubroComsion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarSubRubroComsion.UseVisualStyleBackColor = True
        '
        'tpTiendasWeb
        '
        Me.tpTiendasWeb.BackColor = System.Drawing.SystemColors.Control
        Me.tpTiendasWeb.Controls.Add(Me.txtIdSubRubroArborea)
        Me.tpTiendasWeb.Controls.Add(Me.lblIdSubRubroArborea)
        Me.tpTiendasWeb.Controls.Add(Me.txtIdSubRubroML)
        Me.tpTiendasWeb.Controls.Add(Me.lblIdSubRubroML)
        Me.tpTiendasWeb.Controls.Add(Me.txtIdSubRubroTiendaNube)
        Me.tpTiendasWeb.Controls.Add(Me.lblIdSubRubroTiendaNube)
        Me.tpTiendasWeb.Location = New System.Drawing.Point(4, 22)
        Me.tpTiendasWeb.Name = "tpTiendasWeb"
        Me.tpTiendasWeb.Padding = New System.Windows.Forms.Padding(3)
        Me.tpTiendasWeb.Size = New System.Drawing.Size(455, 209)
        Me.tpTiendasWeb.TabIndex = 3
        Me.tpTiendasWeb.Text = "Tiendas Web"
        '
        'txtIdSubRubroML
        '
        Me.txtIdSubRubroML.BindearPropiedadControl = "Text"
        Me.txtIdSubRubroML.BindearPropiedadEntidad = "IdSubRubroMercadoLibre"
        Me.txtIdSubRubroML.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubRubroML.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubRubroML.Formato = "N2"
        Me.txtIdSubRubroML.IsDecimal = False
        Me.txtIdSubRubroML.IsNumber = False
        Me.txtIdSubRubroML.IsPK = False
        Me.txtIdSubRubroML.IsRequired = False
        Me.txtIdSubRubroML.Key = ""
        Me.txtIdSubRubroML.LabelAsoc = Me.lblIdSubRubroML
        Me.txtIdSubRubroML.Location = New System.Drawing.Point(187, 35)
        Me.txtIdSubRubroML.MaxLength = 30
        Me.txtIdSubRubroML.Name = "txtIdSubRubroML"
        Me.txtIdSubRubroML.Size = New System.Drawing.Size(98, 20)
        Me.txtIdSubRubroML.TabIndex = 9
        Me.txtIdSubRubroML.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdSubRubroML
        '
        Me.lblIdSubRubroML.AutoSize = True
        Me.lblIdSubRubroML.LabelAsoc = Nothing
        Me.lblIdSubRubroML.Location = New System.Drawing.Point(7, 38)
        Me.lblIdSubRubroML.Name = "lblIdSubRubroML"
        Me.lblIdSubRubroML.Size = New System.Drawing.Size(151, 13)
        Me.lblIdSubRubroML.TabIndex = 8
        Me.lblIdSubRubroML.Text = "Cód. SubRubro Mercado Libre"
        '
        'txtIdSubRubroTiendaNube
        '
        Me.txtIdSubRubroTiendaNube.BindearPropiedadControl = "Text"
        Me.txtIdSubRubroTiendaNube.BindearPropiedadEntidad = "IdSubRubroTiendaNube"
        Me.txtIdSubRubroTiendaNube.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubRubroTiendaNube.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubRubroTiendaNube.Formato = ""
        Me.txtIdSubRubroTiendaNube.IsDecimal = False
        Me.txtIdSubRubroTiendaNube.IsNumber = False
        Me.txtIdSubRubroTiendaNube.IsPK = False
        Me.txtIdSubRubroTiendaNube.IsRequired = False
        Me.txtIdSubRubroTiendaNube.Key = ""
        Me.txtIdSubRubroTiendaNube.LabelAsoc = Me.lblIdSubRubroTiendaNube
        Me.txtIdSubRubroTiendaNube.Location = New System.Drawing.Point(187, 9)
        Me.txtIdSubRubroTiendaNube.MaxLength = 30
        Me.txtIdSubRubroTiendaNube.Name = "txtIdSubRubroTiendaNube"
        Me.txtIdSubRubroTiendaNube.Size = New System.Drawing.Size(98, 20)
        Me.txtIdSubRubroTiendaNube.TabIndex = 7
        Me.txtIdSubRubroTiendaNube.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdSubRubroTiendaNube
        '
        Me.lblIdSubRubroTiendaNube.AutoSize = True
        Me.lblIdSubRubroTiendaNube.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdSubRubroTiendaNube.LabelAsoc = Nothing
        Me.lblIdSubRubroTiendaNube.Location = New System.Drawing.Point(7, 12)
        Me.lblIdSubRubroTiendaNube.Name = "lblIdSubRubroTiendaNube"
        Me.lblIdSubRubroTiendaNube.Size = New System.Drawing.Size(145, 13)
        Me.lblIdSubRubroTiendaNube.TabIndex = 6
        Me.lblIdSubRubroTiendaNube.Text = "Cód. SubRubro Tienda Nube"
        '
        'tpExportacion
        '
        Me.tpExportacion.BackColor = System.Drawing.SystemColors.Control
        Me.tpExportacion.Controls.Add(Me.txtCodigoExportacion)
        Me.tpExportacion.Controls.Add(Me.Label7)
        Me.tpExportacion.Location = New System.Drawing.Point(4, 22)
        Me.tpExportacion.Name = "tpExportacion"
        Me.tpExportacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tpExportacion.Size = New System.Drawing.Size(455, 209)
        Me.tpExportacion.TabIndex = 3
        Me.tpExportacion.Text = "Exportación"
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
        Me.txtCodigoExportacion.LabelAsoc = Me.Label7
        Me.txtCodigoExportacion.Location = New System.Drawing.Point(102, 16)
        Me.txtCodigoExportacion.MaxLength = 5
        Me.txtCodigoExportacion.Name = "txtCodigoExportacion"
        Me.txtCodigoExportacion.Size = New System.Drawing.Size(91, 20)
        Me.txtCodigoExportacion.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(8, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Cód. Exportación"
        '
        'tpAtributos
        '
        Me.tpAtributos.BackColor = System.Drawing.SystemColors.Control
        Me.tpAtributos.Controls.Add(Me.lblMensajeSubRubroAtributo)
        Me.tpAtributos.Controls.Add(Me.bscDescripcionGrupoAtributo04)
        Me.tpAtributos.Controls.Add(Me.bscCodigoGrupoAtributo04)
        Me.tpAtributos.Controls.Add(Me.bscDescripcionGrupoAtributo03)
        Me.tpAtributos.Controls.Add(Me.bscCodigoGrupoAtributo03)
        Me.tpAtributos.Controls.Add(Me.bscDescripcionGrupoAtributo02)
        Me.tpAtributos.Controls.Add(Me.bscCodigoGrupoAtributo02)
        Me.tpAtributos.Controls.Add(Me.bscDescripcionGrupoAtributo01)
        Me.tpAtributos.Controls.Add(Me.bscCodigoGrupoAtributo01)
        Me.tpAtributos.Controls.Add(Me.chbAtributo04)
        Me.tpAtributos.Controls.Add(Me.chbAtributo03)
        Me.tpAtributos.Controls.Add(Me.chbAtributo02)
        Me.tpAtributos.Controls.Add(Me.chbAtributo01)
        Me.tpAtributos.Location = New System.Drawing.Point(4, 22)
        Me.tpAtributos.Name = "tpAtributos"
        Me.tpAtributos.Size = New System.Drawing.Size(455, 209)
        Me.tpAtributos.TabIndex = 4
        Me.tpAtributos.Text = "Atributos"
        '
        'lblMensajeSubRubroAtributo
        '
        Me.lblMensajeSubRubroAtributo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblMensajeSubRubroAtributo.AutoSize = True
        Me.lblMensajeSubRubroAtributo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeSubRubroAtributo.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeSubRubroAtributo.LabelAsoc = Nothing
        Me.lblMensajeSubRubroAtributo.Location = New System.Drawing.Point(16, 181)
        Me.lblMensajeSubRubroAtributo.Name = "lblMensajeSubRubroAtributo"
        Me.lblMensajeSubRubroAtributo.Size = New System.Drawing.Size(389, 13)
        Me.lblMensajeSubRubroAtributo.TabIndex = 31
        Me.lblMensajeSubRubroAtributo.Text = "¡No es posible modificar los atributos! El SubRubro contiene productos asociados"
        Me.lblMensajeSubRubroAtributo.Visible = False
        '
        'bscDescripcionGrupoAtributo04
        '
        Me.bscDescripcionGrupoAtributo04.ActivarFiltroEnGrilla = True
        Me.bscDescripcionGrupoAtributo04.BindearPropiedadControl = Nothing
        Me.bscDescripcionGrupoAtributo04.BindearPropiedadEntidad = Nothing
        Me.bscDescripcionGrupoAtributo04.ConfigBuscador = Nothing
        Me.bscDescripcionGrupoAtributo04.Datos = Nothing
        Me.bscDescripcionGrupoAtributo04.FilaDevuelta = Nothing
        Me.bscDescripcionGrupoAtributo04.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscDescripcionGrupoAtributo04.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDescripcionGrupoAtributo04.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDescripcionGrupoAtributo04.IsDecimal = False
        Me.bscDescripcionGrupoAtributo04.IsNumber = False
        Me.bscDescripcionGrupoAtributo04.IsPK = False
        Me.bscDescripcionGrupoAtributo04.IsRequired = False
        Me.bscDescripcionGrupoAtributo04.Key = ""
        Me.bscDescripcionGrupoAtributo04.LabelAsoc = Me.chbAtributo04
        Me.bscDescripcionGrupoAtributo04.Location = New System.Drawing.Point(235, 104)
        Me.bscDescripcionGrupoAtributo04.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscDescripcionGrupoAtributo04.MaxLengh = "32767"
        Me.bscDescripcionGrupoAtributo04.Name = "bscDescripcionGrupoAtributo04"
        Me.bscDescripcionGrupoAtributo04.Permitido = True
        Me.bscDescripcionGrupoAtributo04.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscDescripcionGrupoAtributo04.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscDescripcionGrupoAtributo04.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscDescripcionGrupoAtributo04.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscDescripcionGrupoAtributo04.Selecciono = False
        Me.bscDescripcionGrupoAtributo04.Size = New System.Drawing.Size(195, 23)
        Me.bscDescripcionGrupoAtributo04.TabIndex = 30
        '
        'chbAtributo04
        '
        Me.chbAtributo04.AutoSize = True
        Me.chbAtributo04.BindearPropiedadControl = ""
        Me.chbAtributo04.BindearPropiedadEntidad = ""
        Me.chbAtributo04.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAtributo04.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAtributo04.IsPK = False
        Me.chbAtributo04.IsRequired = False
        Me.chbAtributo04.Key = Nothing
        Me.chbAtributo04.LabelAsoc = Nothing
        Me.chbAtributo04.Location = New System.Drawing.Point(19, 107)
        Me.chbAtributo04.Name = "chbAtributo04"
        Me.chbAtributo04.Size = New System.Drawing.Size(95, 17)
        Me.chbAtributo04.TabIndex = 22
        Me.chbAtributo04.Text = "Tipo Atributo 4"
        Me.chbAtributo04.UseVisualStyleBackColor = True
        '
        'bscCodigoGrupoAtributo04
        '
        Me.bscCodigoGrupoAtributo04.ActivarFiltroEnGrilla = True
        Me.bscCodigoGrupoAtributo04.BindearPropiedadControl = ""
        Me.bscCodigoGrupoAtributo04.BindearPropiedadEntidad = ""
        Me.bscCodigoGrupoAtributo04.ConfigBuscador = Nothing
        Me.bscCodigoGrupoAtributo04.Datos = Nothing
        Me.bscCodigoGrupoAtributo04.FilaDevuelta = Nothing
        Me.bscCodigoGrupoAtributo04.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoGrupoAtributo04.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoGrupoAtributo04.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoGrupoAtributo04.IsDecimal = False
        Me.bscCodigoGrupoAtributo04.IsNumber = False
        Me.bscCodigoGrupoAtributo04.IsPK = False
        Me.bscCodigoGrupoAtributo04.IsRequired = False
        Me.bscCodigoGrupoAtributo04.Key = ""
        Me.bscCodigoGrupoAtributo04.LabelAsoc = Me.chbAtributo04
        Me.bscCodigoGrupoAtributo04.Location = New System.Drawing.Point(124, 104)
        Me.bscCodigoGrupoAtributo04.MaxLengh = "32767"
        Me.bscCodigoGrupoAtributo04.Name = "bscCodigoGrupoAtributo04"
        Me.bscCodigoGrupoAtributo04.Permitido = True
        Me.bscCodigoGrupoAtributo04.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoGrupoAtributo04.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoGrupoAtributo04.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoGrupoAtributo04.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoGrupoAtributo04.Selecciono = False
        Me.bscCodigoGrupoAtributo04.Size = New System.Drawing.Size(105, 23)
        Me.bscCodigoGrupoAtributo04.TabIndex = 29
        '
        'bscDescripcionGrupoAtributo03
        '
        Me.bscDescripcionGrupoAtributo03.ActivarFiltroEnGrilla = True
        Me.bscDescripcionGrupoAtributo03.BindearPropiedadControl = Nothing
        Me.bscDescripcionGrupoAtributo03.BindearPropiedadEntidad = Nothing
        Me.bscDescripcionGrupoAtributo03.ConfigBuscador = Nothing
        Me.bscDescripcionGrupoAtributo03.Datos = Nothing
        Me.bscDescripcionGrupoAtributo03.FilaDevuelta = Nothing
        Me.bscDescripcionGrupoAtributo03.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscDescripcionGrupoAtributo03.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDescripcionGrupoAtributo03.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDescripcionGrupoAtributo03.IsDecimal = False
        Me.bscDescripcionGrupoAtributo03.IsNumber = False
        Me.bscDescripcionGrupoAtributo03.IsPK = False
        Me.bscDescripcionGrupoAtributo03.IsRequired = False
        Me.bscDescripcionGrupoAtributo03.Key = ""
        Me.bscDescripcionGrupoAtributo03.LabelAsoc = Me.chbAtributo03
        Me.bscDescripcionGrupoAtributo03.Location = New System.Drawing.Point(235, 75)
        Me.bscDescripcionGrupoAtributo03.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscDescripcionGrupoAtributo03.MaxLengh = "32767"
        Me.bscDescripcionGrupoAtributo03.Name = "bscDescripcionGrupoAtributo03"
        Me.bscDescripcionGrupoAtributo03.Permitido = True
        Me.bscDescripcionGrupoAtributo03.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscDescripcionGrupoAtributo03.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscDescripcionGrupoAtributo03.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscDescripcionGrupoAtributo03.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscDescripcionGrupoAtributo03.Selecciono = False
        Me.bscDescripcionGrupoAtributo03.Size = New System.Drawing.Size(195, 23)
        Me.bscDescripcionGrupoAtributo03.TabIndex = 28
        '
        'chbAtributo03
        '
        Me.chbAtributo03.AutoSize = True
        Me.chbAtributo03.BindearPropiedadControl = ""
        Me.chbAtributo03.BindearPropiedadEntidad = ""
        Me.chbAtributo03.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAtributo03.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAtributo03.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chbAtributo03.IsPK = False
        Me.chbAtributo03.IsRequired = False
        Me.chbAtributo03.Key = Nothing
        Me.chbAtributo03.LabelAsoc = Nothing
        Me.chbAtributo03.Location = New System.Drawing.Point(19, 77)
        Me.chbAtributo03.Name = "chbAtributo03"
        Me.chbAtributo03.Size = New System.Drawing.Size(95, 17)
        Me.chbAtributo03.TabIndex = 20
        Me.chbAtributo03.Text = "Tipo Atributo 3"
        Me.chbAtributo03.UseVisualStyleBackColor = True
        '
        'bscCodigoGrupoAtributo03
        '
        Me.bscCodigoGrupoAtributo03.ActivarFiltroEnGrilla = True
        Me.bscCodigoGrupoAtributo03.BindearPropiedadControl = ""
        Me.bscCodigoGrupoAtributo03.BindearPropiedadEntidad = ""
        Me.bscCodigoGrupoAtributo03.ConfigBuscador = Nothing
        Me.bscCodigoGrupoAtributo03.Datos = Nothing
        Me.bscCodigoGrupoAtributo03.FilaDevuelta = Nothing
        Me.bscCodigoGrupoAtributo03.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoGrupoAtributo03.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoGrupoAtributo03.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoGrupoAtributo03.IsDecimal = False
        Me.bscCodigoGrupoAtributo03.IsNumber = False
        Me.bscCodigoGrupoAtributo03.IsPK = False
        Me.bscCodigoGrupoAtributo03.IsRequired = False
        Me.bscCodigoGrupoAtributo03.Key = ""
        Me.bscCodigoGrupoAtributo03.LabelAsoc = Me.chbAtributo03
        Me.bscCodigoGrupoAtributo03.Location = New System.Drawing.Point(124, 75)
        Me.bscCodigoGrupoAtributo03.MaxLengh = "32767"
        Me.bscCodigoGrupoAtributo03.Name = "bscCodigoGrupoAtributo03"
        Me.bscCodigoGrupoAtributo03.Permitido = True
        Me.bscCodigoGrupoAtributo03.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoGrupoAtributo03.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoGrupoAtributo03.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoGrupoAtributo03.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoGrupoAtributo03.Selecciono = False
        Me.bscCodigoGrupoAtributo03.Size = New System.Drawing.Size(105, 23)
        Me.bscCodigoGrupoAtributo03.TabIndex = 27
        '
        'bscDescripcionGrupoAtributo02
        '
        Me.bscDescripcionGrupoAtributo02.ActivarFiltroEnGrilla = True
        Me.bscDescripcionGrupoAtributo02.BindearPropiedadControl = Nothing
        Me.bscDescripcionGrupoAtributo02.BindearPropiedadEntidad = Nothing
        Me.bscDescripcionGrupoAtributo02.ConfigBuscador = Nothing
        Me.bscDescripcionGrupoAtributo02.Datos = Nothing
        Me.bscDescripcionGrupoAtributo02.FilaDevuelta = Nothing
        Me.bscDescripcionGrupoAtributo02.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscDescripcionGrupoAtributo02.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDescripcionGrupoAtributo02.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDescripcionGrupoAtributo02.IsDecimal = False
        Me.bscDescripcionGrupoAtributo02.IsNumber = False
        Me.bscDescripcionGrupoAtributo02.IsPK = False
        Me.bscDescripcionGrupoAtributo02.IsRequired = False
        Me.bscDescripcionGrupoAtributo02.Key = ""
        Me.bscDescripcionGrupoAtributo02.LabelAsoc = Me.chbAtributo02
        Me.bscDescripcionGrupoAtributo02.Location = New System.Drawing.Point(235, 43)
        Me.bscDescripcionGrupoAtributo02.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscDescripcionGrupoAtributo02.MaxLengh = "32767"
        Me.bscDescripcionGrupoAtributo02.Name = "bscDescripcionGrupoAtributo02"
        Me.bscDescripcionGrupoAtributo02.Permitido = True
        Me.bscDescripcionGrupoAtributo02.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscDescripcionGrupoAtributo02.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscDescripcionGrupoAtributo02.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscDescripcionGrupoAtributo02.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscDescripcionGrupoAtributo02.Selecciono = False
        Me.bscDescripcionGrupoAtributo02.Size = New System.Drawing.Size(195, 23)
        Me.bscDescripcionGrupoAtributo02.TabIndex = 26
        '
        'chbAtributo02
        '
        Me.chbAtributo02.AutoSize = True
        Me.chbAtributo02.BindearPropiedadControl = ""
        Me.chbAtributo02.BindearPropiedadEntidad = ""
        Me.chbAtributo02.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAtributo02.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAtributo02.IsPK = False
        Me.chbAtributo02.IsRequired = False
        Me.chbAtributo02.Key = Nothing
        Me.chbAtributo02.LabelAsoc = Nothing
        Me.chbAtributo02.Location = New System.Drawing.Point(19, 47)
        Me.chbAtributo02.Name = "chbAtributo02"
        Me.chbAtributo02.Size = New System.Drawing.Size(95, 17)
        Me.chbAtributo02.TabIndex = 18
        Me.chbAtributo02.Text = "Tipo Atributo 2"
        Me.chbAtributo02.UseVisualStyleBackColor = True
        '
        'bscCodigoGrupoAtributo02
        '
        Me.bscCodigoGrupoAtributo02.ActivarFiltroEnGrilla = True
        Me.bscCodigoGrupoAtributo02.BindearPropiedadControl = ""
        Me.bscCodigoGrupoAtributo02.BindearPropiedadEntidad = ""
        Me.bscCodigoGrupoAtributo02.ConfigBuscador = Nothing
        Me.bscCodigoGrupoAtributo02.Datos = Nothing
        Me.bscCodigoGrupoAtributo02.FilaDevuelta = Nothing
        Me.bscCodigoGrupoAtributo02.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoGrupoAtributo02.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoGrupoAtributo02.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoGrupoAtributo02.IsDecimal = False
        Me.bscCodigoGrupoAtributo02.IsNumber = False
        Me.bscCodigoGrupoAtributo02.IsPK = False
        Me.bscCodigoGrupoAtributo02.IsRequired = False
        Me.bscCodigoGrupoAtributo02.Key = ""
        Me.bscCodigoGrupoAtributo02.LabelAsoc = Me.chbAtributo02
        Me.bscCodigoGrupoAtributo02.Location = New System.Drawing.Point(124, 43)
        Me.bscCodigoGrupoAtributo02.MaxLengh = "32767"
        Me.bscCodigoGrupoAtributo02.Name = "bscCodigoGrupoAtributo02"
        Me.bscCodigoGrupoAtributo02.Permitido = True
        Me.bscCodigoGrupoAtributo02.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoGrupoAtributo02.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoGrupoAtributo02.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoGrupoAtributo02.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoGrupoAtributo02.Selecciono = False
        Me.bscCodigoGrupoAtributo02.Size = New System.Drawing.Size(105, 23)
        Me.bscCodigoGrupoAtributo02.TabIndex = 25
        '
        'bscDescripcionGrupoAtributo01
        '
        Me.bscDescripcionGrupoAtributo01.ActivarFiltroEnGrilla = True
        Me.bscDescripcionGrupoAtributo01.BindearPropiedadControl = Nothing
        Me.bscDescripcionGrupoAtributo01.BindearPropiedadEntidad = Nothing
        Me.bscDescripcionGrupoAtributo01.ConfigBuscador = Nothing
        Me.bscDescripcionGrupoAtributo01.Datos = Nothing
        Me.bscDescripcionGrupoAtributo01.FilaDevuelta = Nothing
        Me.bscDescripcionGrupoAtributo01.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscDescripcionGrupoAtributo01.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDescripcionGrupoAtributo01.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDescripcionGrupoAtributo01.IsDecimal = False
        Me.bscDescripcionGrupoAtributo01.IsNumber = False
        Me.bscDescripcionGrupoAtributo01.IsPK = False
        Me.bscDescripcionGrupoAtributo01.IsRequired = False
        Me.bscDescripcionGrupoAtributo01.Key = ""
        Me.bscDescripcionGrupoAtributo01.LabelAsoc = Me.chbAtributo01
        Me.bscDescripcionGrupoAtributo01.Location = New System.Drawing.Point(235, 14)
        Me.bscDescripcionGrupoAtributo01.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscDescripcionGrupoAtributo01.MaxLengh = "32767"
        Me.bscDescripcionGrupoAtributo01.Name = "bscDescripcionGrupoAtributo01"
        Me.bscDescripcionGrupoAtributo01.Permitido = True
        Me.bscDescripcionGrupoAtributo01.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscDescripcionGrupoAtributo01.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscDescripcionGrupoAtributo01.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscDescripcionGrupoAtributo01.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscDescripcionGrupoAtributo01.Selecciono = False
        Me.bscDescripcionGrupoAtributo01.Size = New System.Drawing.Size(195, 23)
        Me.bscDescripcionGrupoAtributo01.TabIndex = 24
        '
        'chbAtributo01
        '
        Me.chbAtributo01.AutoSize = True
        Me.chbAtributo01.BindearPropiedadControl = ""
        Me.chbAtributo01.BindearPropiedadEntidad = ""
        Me.chbAtributo01.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAtributo01.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAtributo01.IsPK = False
        Me.chbAtributo01.IsRequired = False
        Me.chbAtributo01.Key = Nothing
        Me.chbAtributo01.LabelAsoc = Nothing
        Me.chbAtributo01.Location = New System.Drawing.Point(19, 18)
        Me.chbAtributo01.Name = "chbAtributo01"
        Me.chbAtributo01.Size = New System.Drawing.Size(95, 17)
        Me.chbAtributo01.TabIndex = 16
        Me.chbAtributo01.Text = "Tipo Atributo 1"
        Me.chbAtributo01.UseVisualStyleBackColor = True
        '
        'bscCodigoGrupoAtributo01
        '
        Me.bscCodigoGrupoAtributo01.ActivarFiltroEnGrilla = True
        Me.bscCodigoGrupoAtributo01.BindearPropiedadControl = ""
        Me.bscCodigoGrupoAtributo01.BindearPropiedadEntidad = ""
        Me.bscCodigoGrupoAtributo01.ConfigBuscador = Nothing
        Me.bscCodigoGrupoAtributo01.Datos = Nothing
        Me.bscCodigoGrupoAtributo01.FilaDevuelta = Nothing
        Me.bscCodigoGrupoAtributo01.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoGrupoAtributo01.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoGrupoAtributo01.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoGrupoAtributo01.IsDecimal = False
        Me.bscCodigoGrupoAtributo01.IsNumber = True
        Me.bscCodigoGrupoAtributo01.IsPK = False
        Me.bscCodigoGrupoAtributo01.IsRequired = False
        Me.bscCodigoGrupoAtributo01.Key = ""
        Me.bscCodigoGrupoAtributo01.LabelAsoc = Me.chbAtributo01
        Me.bscCodigoGrupoAtributo01.Location = New System.Drawing.Point(124, 14)
        Me.bscCodigoGrupoAtributo01.MaxLengh = "32767"
        Me.bscCodigoGrupoAtributo01.Name = "bscCodigoGrupoAtributo01"
        Me.bscCodigoGrupoAtributo01.Permitido = True
        Me.bscCodigoGrupoAtributo01.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoGrupoAtributo01.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoGrupoAtributo01.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoGrupoAtributo01.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoGrupoAtributo01.Selecciono = False
        Me.bscCodigoGrupoAtributo01.Size = New System.Drawing.Size(105, 23)
        Me.bscCodigoGrupoAtributo01.TabIndex = 23
        '
        'txtIdSubRubroArborea
        '
        Me.txtIdSubRubroArborea.BindearPropiedadControl = "Text"
        Me.txtIdSubRubroArborea.BindearPropiedadEntidad = "IdSubRubroArborea"
        Me.txtIdSubRubroArborea.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdSubRubroArborea.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdSubRubroArborea.Formato = "N2"
        Me.txtIdSubRubroArborea.IsDecimal = False
        Me.txtIdSubRubroArborea.IsNumber = False
        Me.txtIdSubRubroArborea.IsPK = False
        Me.txtIdSubRubroArborea.IsRequired = False
        Me.txtIdSubRubroArborea.Key = ""
        Me.txtIdSubRubroArborea.LabelAsoc = Me.lblIdSubRubroArborea
        Me.txtIdSubRubroArborea.Location = New System.Drawing.Point(187, 61)
        Me.txtIdSubRubroArborea.MaxLength = 30
        Me.txtIdSubRubroArborea.Name = "txtIdSubRubroArborea"
        Me.txtIdSubRubroArborea.Size = New System.Drawing.Size(98, 20)
        Me.txtIdSubRubroArborea.TabIndex = 11
        Me.txtIdSubRubroArborea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdSubRubroArborea
        '
        Me.lblIdSubRubroArborea.AutoSize = True
        Me.lblIdSubRubroArborea.LabelAsoc = Nothing
        Me.lblIdSubRubroArborea.Location = New System.Drawing.Point(7, 64)
        Me.lblIdSubRubroArborea.Name = "lblIdSubRubroArborea"
        Me.lblIdSubRubroArborea.Size = New System.Drawing.Size(120, 13)
        Me.lblIdSubRubroArborea.TabIndex = 10
        Me.lblIdSubRubroArborea.Text = "Cód. SubRubro Arborea"
        '
        'SubRubrosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(481, 394)
        Me.Controls.Add(Me.tbcDetalle)
        Me.Controls.Add(Me.lblRubro)
        Me.Controls.Add(Me.bscCodigoRubro)
        Me.Controls.Add(Me.bscRubro)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombreSubRubro)
        Me.Controls.Add(Me.lblIdSubRubro)
        Me.Controls.Add(Me.txtIdSubRubro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SubRubrosDetalle"
        Me.Text = "SubRubro"
        Me.Controls.SetChildIndex(Me.txtIdSubRubro, 0)
        Me.Controls.SetChildIndex(Me.lblIdSubRubro, 0)
        Me.Controls.SetChildIndex(Me.txtNombreSubRubro, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.bscRubro, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoRubro, 0)
        Me.Controls.SetChildIndex(Me.lblRubro, 0)
        Me.Controls.SetChildIndex(Me.tbcDetalle, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbcDetalle.ResumeLayout(False)
        Me.tbpDescuentos.ResumeLayout(False)
        Me.tbpDescuentos.PerformLayout()
        Me.tbpComisionPorDesCuento.ResumeLayout(False)
        Me.tbpComisionPorDesCuento.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpTiendasWeb.ResumeLayout(False)
        Me.tpTiendasWeb.PerformLayout()
        Me.tpExportacion.ResumeLayout(False)
        Me.tpExportacion.PerformLayout()
        Me.tpAtributos.ResumeLayout(False)
        Me.tpAtributos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
	Friend WithEvents txtNombreSubRubro As Eniac.Controles.TextBox
	Friend WithEvents lblIdSubRubro As Eniac.Controles.Label
	Friend WithEvents txtIdSubRubro As Eniac.Controles.TextBox
	Friend WithEvents txtDescuentoRecargoPorc1 As Eniac.Controles.TextBox
	Friend WithEvents lblDescuentoRecargo As Eniac.Controles.Label
	Friend WithEvents bscCodigoRubro As Eniac.Controles.Buscador
	Friend WithEvents bscRubro As Eniac.Controles.Buscador
	Friend WithEvents lblRubro As Eniac.Controles.Label
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
	Friend WithEvents LblPorct6 As Eniac.Controles.Label
	Friend WithEvents txtUnidHasta1 As Eniac.Controles.TextBox
	Friend WithEvents lblUnidHasta1 As Eniac.Controles.Label
	Friend WithEvents LblPorct5 As Eniac.Controles.Label
	Friend WithEvents LblPorct3 As Eniac.Controles.Label
	Friend WithEvents LblPorct4 As Eniac.Controles.Label
	Friend WithEvents LblPorct2 As Eniac.Controles.Label
	Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
	Friend WithEvents tbpDescuentos As System.Windows.Forms.TabPage
	Friend WithEvents tbpComisionPorDesCuento As System.Windows.Forms.TabPage
	Friend WithEvents btnRefrescarDescRec As System.Windows.Forms.Button
	Friend WithEvents LlblComisonPorc As Eniac.Controles.Label
	Friend WithEvents lblDesRecHasta As Eniac.Controles.Label
	Friend WithEvents txtComisionDescRec As Eniac.Controles.TextBox
	Friend WithEvents txtDesRecHasta As Eniac.Controles.TextBox
	Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
	Friend WithEvents btnEliminarSubRubroComsion As Eniac.Controles.Button
	Friend WithEvents btnInsertarSubRubroComsion As Eniac.Controles.Button
	Friend WithEvents LblPorct As Eniac.Controles.Label
	Friend WithEvents txtDescuentoRecargoPorc2 As Eniac.Controles.TextBox
	Friend WithEvents lblDescuentoRecargo2 As Eniac.Controles.Label
	Friend WithEvents tpTiendasWeb As System.Windows.Forms.TabPage
	Friend WithEvents txtIdSubRubroML As Eniac.Controles.TextBox
	Friend WithEvents lblIdSubRubroML As Eniac.Controles.Label
	Friend WithEvents txtIdSubRubroTiendaNube As Eniac.Controles.TextBox
	Friend WithEvents lblIdSubRubroTiendaNube As Eniac.Controles.Label
	Friend WithEvents tpExportacion As System.Windows.Forms.TabPage
	Friend WithEvents txtCodigoExportacion As Eniac.Controles.TextBox
	Friend WithEvents Label7 As Eniac.Controles.Label
	Friend WithEvents tpAtributos As TabPage
	Friend WithEvents chbAtributo04 As Controles.CheckBox
	Friend WithEvents chbAtributo03 As Controles.CheckBox
	Friend WithEvents chbAtributo02 As Controles.CheckBox
	Friend WithEvents chbAtributo01 As Controles.CheckBox
	Friend WithEvents bscDescripcionGrupoAtributo04 As Controles.Buscador2
	Friend WithEvents bscCodigoGrupoAtributo04 As Controles.Buscador2
	Friend WithEvents bscDescripcionGrupoAtributo03 As Controles.Buscador2
	Friend WithEvents bscCodigoGrupoAtributo03 As Controles.Buscador2
	Friend WithEvents bscDescripcionGrupoAtributo02 As Controles.Buscador2
	Friend WithEvents bscCodigoGrupoAtributo02 As Controles.Buscador2
	Friend WithEvents bscDescripcionGrupoAtributo01 As Controles.Buscador2
	Friend WithEvents bscCodigoGrupoAtributo01 As Controles.Buscador2
	Friend WithEvents lblMensajeSubRubroAtributo As Controles.Label
    Friend WithEvents txtIdSubRubroArborea As Controles.TextBox
    Friend WithEvents lblIdSubRubroArborea As Controles.Label
End Class
