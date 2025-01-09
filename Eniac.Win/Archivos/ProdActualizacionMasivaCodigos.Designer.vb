<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProdActualizacionMasivaCodigos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProdActualizacionMasivaCodigos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
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
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.btnTodos = New System.Windows.Forms.Button()
      Me.cmbTodos = New Eniac.Controles.ComboBox()
      Me.tabFiltroOpciones = New System.Windows.Forms.TabControl()
      Me.tbpFiltros = New System.Windows.Forms.TabPage()
      Me.pSubRubro = New System.Windows.Forms.Panel()
      Me.cmbSubRubro = New Eniac.Win.ComboBoxSubRubro()
      Me.Label1 = New Eniac.Controles.Label()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.cmbMarca = New Eniac.Win.ComboBoxMarcas()
      Me.lblMarca = New Eniac.Controles.Label()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.cmbRubro = New Eniac.Win.ComboBoxRubro()
      Me.tbpOpciones = New System.Windows.Forms.TabPage()
      Me.txtReemplazarCaracter2 = New Eniac.Controles.TextBox()
      Me.btnAplicarCambios = New System.Windows.Forms.Button()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtReemplazarCaracter1 = New Eniac.Controles.TextBox()
      Me.txtSufijo = New Eniac.Controles.TextBox()
      Me.txtPrefijo = New Eniac.Controles.TextBox()
      Me.chbReemplazarCaracter = New System.Windows.Forms.CheckBox()
      Me.chbSufijo = New System.Windows.Forms.CheckBox()
      Me.chbPrefijo = New System.Windows.Forms.CheckBox()
      Me.ugDetalle = New Eniac.Win.UltraGridEditable()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra.SuspendLayout()
      Me.tabFiltroOpciones.SuspendLayout()
      Me.tbpFiltros.SuspendLayout()
      Me.pSubRubro.SuspendLayout()
      Me.tbpOpciones.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbGrabar, Me.toolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator4, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(960, 29)
      Me.tstBarra.TabIndex = 23
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
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(91, 26)
      Me.tsbGrabar.Text = "&Grabar (F4)"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbPreferencias
      '
      Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
      Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbPreferencias.Name = "tsbPreferencias"
      Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
      Me.tsbPreferencias.Text = "&Preferencias"
      Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'btnTodos
      '
      Me.btnTodos.Image = CType(resources.GetObject("btnTodos.Image"), System.Drawing.Image)
      Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnTodos.Location = New System.Drawing.Point(134, 153)
      Me.btnTodos.Name = "btnTodos"
      Me.btnTodos.Size = New System.Drawing.Size(75, 23)
      Me.btnTodos.TabIndex = 1
      Me.btnTodos.Text = "Marcar"
      Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnTodos.UseVisualStyleBackColor = True
      '
      'cmbTodos
      '
      Me.cmbTodos.BindearPropiedadControl = Nothing
      Me.cmbTodos.BindearPropiedadEntidad = Nothing
      Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTodos.FormattingEnabled = True
      Me.cmbTodos.IsPK = False
      Me.cmbTodos.IsRequired = False
      Me.cmbTodos.Key = Nothing
      Me.cmbTodos.LabelAsoc = Nothing
      Me.cmbTodos.Location = New System.Drawing.Point(12, 154)
      Me.cmbTodos.Name = "cmbTodos"
      Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
      Me.cmbTodos.TabIndex = 0
      '
      'tabFiltroOpciones
      '
      Me.tabFiltroOpciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tabFiltroOpciones.Controls.Add(Me.tbpFiltros)
      Me.tabFiltroOpciones.Controls.Add(Me.tbpOpciones)
      Me.tabFiltroOpciones.Location = New System.Drawing.Point(12, 32)
      Me.tabFiltroOpciones.Name = "tabFiltroOpciones"
      Me.tabFiltroOpciones.SelectedIndex = 0
      Me.tabFiltroOpciones.Size = New System.Drawing.Size(936, 120)
      Me.tabFiltroOpciones.TabIndex = 33
      '
      'tbpFiltros
      '
      Me.tbpFiltros.BackColor = System.Drawing.SystemColors.Control
      Me.tbpFiltros.Controls.Add(Me.pSubRubro)
      Me.tbpFiltros.Controls.Add(Me.btnConsultar)
      Me.tbpFiltros.Controls.Add(Me.bscProducto2)
      Me.tbpFiltros.Controls.Add(Me.bscCodigoProducto2)
      Me.tbpFiltros.Controls.Add(Me.chbProducto)
      Me.tbpFiltros.Controls.Add(Me.cmbMarca)
      Me.tbpFiltros.Controls.Add(Me.lblMarca)
      Me.tbpFiltros.Controls.Add(Me.lblRubro)
      Me.tbpFiltros.Controls.Add(Me.cmbRubro)
      Me.tbpFiltros.Location = New System.Drawing.Point(4, 22)
      Me.tbpFiltros.Name = "tbpFiltros"
      Me.tbpFiltros.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpFiltros.Size = New System.Drawing.Size(928, 94)
      Me.tbpFiltros.TabIndex = 0
      Me.tbpFiltros.Text = "Filtros"
      '
      'pSubRubro
      '
      Me.pSubRubro.Controls.Add(Me.cmbSubRubro)
      Me.pSubRubro.Controls.Add(Me.Label1)
      Me.pSubRubro.Location = New System.Drawing.Point(275, 57)
      Me.pSubRubro.Name = "pSubRubro"
      Me.pSubRubro.Size = New System.Drawing.Size(266, 24)
      Me.pSubRubro.TabIndex = 34
      Me.pSubRubro.Visible = False
      '
      'cmbSubRubro
      '
      Me.cmbSubRubro.BindearPropiedadControl = Nothing
      Me.cmbSubRubro.BindearPropiedadEntidad = Nothing
      Me.cmbSubRubro.ConcatenarNombreRubro = False
      Me.cmbSubRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSubRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbSubRubro.FormattingEnabled = True
      Me.cmbSubRubro.IsPK = False
      Me.cmbSubRubro.IsRequired = False
      Me.cmbSubRubro.Key = Nothing
      Me.cmbSubRubro.LabelAsoc = Nothing
      Me.cmbSubRubro.Location = New System.Drawing.Point(64, 3)
      Me.cmbSubRubro.Name = "cmbSubRubro"
      Me.cmbSubRubro.Size = New System.Drawing.Size(173, 21)
      Me.cmbSubRubro.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(3, 6)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(55, 13)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "SubRubro"
      '
      'btnConsultar
      '
      Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(806, 29)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(116, 51)
      Me.btnConsultar.TabIndex = 7
      Me.btnConsultar.Text = "Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ConfigBuscador = Nothing
      Me.bscProducto2.Datos = Nothing
      Me.bscProducto2.Enabled = False
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto2.IsDecimal = False
      Me.bscProducto2.IsNumber = False
      Me.bscProducto2.IsPK = False
      Me.bscProducto2.IsRequired = False
      Me.bscProducto2.Key = ""
      Me.bscProducto2.LabelAsoc = Nothing
      Me.bscProducto2.Location = New System.Drawing.Point(243, 7)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(275, 20)
      Me.bscProducto2.TabIndex = 2
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCodigoProducto2.Datos = Nothing
      Me.bscCodigoProducto2.Enabled = False
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2.IsDecimal = False
      Me.bscCodigoProducto2.IsNumber = False
      Me.bscCodigoProducto2.IsPK = False
      Me.bscCodigoProducto2.IsRequired = False
      Me.bscCodigoProducto2.Key = ""
      Me.bscCodigoProducto2.LabelAsoc = Nothing
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(82, 6)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
      Me.bscCodigoProducto2.TabIndex = 1
      '
      'chbProducto
      '
      Me.chbProducto.AutoSize = True
      Me.chbProducto.BindearPropiedadControl = Nothing
      Me.chbProducto.BindearPropiedadEntidad = Nothing
      Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProducto.IsPK = False
      Me.chbProducto.IsRequired = False
      Me.chbProducto.Key = Nothing
      Me.chbProducto.LabelAsoc = Nothing
      Me.chbProducto.Location = New System.Drawing.Point(9, 7)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 0
      Me.chbProducto.Text = "&Producto"
      Me.chbProducto.UseVisualStyleBackColor = True
      '
      'cmbMarca
      '
      Me.cmbMarca.BindearPropiedadControl = Nothing
      Me.cmbMarca.BindearPropiedadEntidad = Nothing
      Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbMarca.FormattingEnabled = True
      Me.cmbMarca.IsPK = False
      Me.cmbMarca.IsRequired = False
      Me.cmbMarca.Key = Nothing
      Me.cmbMarca.LabelAsoc = Me.lblMarca
      Me.cmbMarca.Location = New System.Drawing.Point(82, 33)
      Me.cmbMarca.Name = "cmbMarca"
      Me.cmbMarca.Size = New System.Drawing.Size(188, 21)
      Me.cmbMarca.TabIndex = 4
      '
      'lblMarca
      '
      Me.lblMarca.AutoSize = True
      Me.lblMarca.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMarca.LabelAsoc = Nothing
      Me.lblMarca.Location = New System.Drawing.Point(6, 36)
      Me.lblMarca.Name = "lblMarca"
      Me.lblMarca.Size = New System.Drawing.Size(37, 13)
      Me.lblMarca.TabIndex = 3
      Me.lblMarca.Text = "Marca"
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.LabelAsoc = Nothing
      Me.lblRubro.Location = New System.Drawing.Point(6, 63)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(36, 13)
      Me.lblRubro.TabIndex = 5
      Me.lblRubro.Text = "Rubro"
      '
      'cmbRubro
      '
      Me.cmbRubro.BindearPropiedadControl = Nothing
      Me.cmbRubro.BindearPropiedadEntidad = Nothing
      Me.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRubro.FormattingEnabled = True
      Me.cmbRubro.IsPK = False
      Me.cmbRubro.IsRequired = False
      Me.cmbRubro.Key = Nothing
      Me.cmbRubro.LabelAsoc = Me.lblRubro
      Me.cmbRubro.Location = New System.Drawing.Point(81, 60)
      Me.cmbRubro.Name = "cmbRubro"
      Me.cmbRubro.Size = New System.Drawing.Size(188, 21)
      Me.cmbRubro.TabIndex = 6
      '
      'tbpOpciones
      '
      Me.tbpOpciones.BackColor = System.Drawing.SystemColors.Control
      Me.tbpOpciones.Controls.Add(Me.txtReemplazarCaracter2)
      Me.tbpOpciones.Controls.Add(Me.btnAplicarCambios)
      Me.tbpOpciones.Controls.Add(Me.Label2)
      Me.tbpOpciones.Controls.Add(Me.txtReemplazarCaracter1)
      Me.tbpOpciones.Controls.Add(Me.txtSufijo)
      Me.tbpOpciones.Controls.Add(Me.txtPrefijo)
      Me.tbpOpciones.Controls.Add(Me.chbReemplazarCaracter)
      Me.tbpOpciones.Controls.Add(Me.chbSufijo)
      Me.tbpOpciones.Controls.Add(Me.chbPrefijo)
      Me.tbpOpciones.Location = New System.Drawing.Point(4, 22)
      Me.tbpOpciones.Name = "tbpOpciones"
      Me.tbpOpciones.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpOpciones.Size = New System.Drawing.Size(928, 94)
      Me.tbpOpciones.TabIndex = 1
      Me.tbpOpciones.Text = "Opciones"
      '
      'txtReemplazarCaracter2
      '
      Me.txtReemplazarCaracter2.BindearPropiedadControl = Nothing
      Me.txtReemplazarCaracter2.BindearPropiedadEntidad = Nothing
      Me.txtReemplazarCaracter2.Enabled = False
      Me.txtReemplazarCaracter2.ForeColorFocus = System.Drawing.Color.Red
      Me.txtReemplazarCaracter2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtReemplazarCaracter2.Formato = ""
      Me.txtReemplazarCaracter2.IsDecimal = False
      Me.txtReemplazarCaracter2.IsNumber = False
      Me.txtReemplazarCaracter2.IsPK = False
      Me.txtReemplazarCaracter2.IsRequired = False
      Me.txtReemplazarCaracter2.Key = ""
      Me.txtReemplazarCaracter2.LabelAsoc = Nothing
      Me.txtReemplazarCaracter2.Location = New System.Drawing.Point(217, 51)
      Me.txtReemplazarCaracter2.Name = "txtReemplazarCaracter2"
      Me.txtReemplazarCaracter2.Size = New System.Drawing.Size(47, 20)
      Me.txtReemplazarCaracter2.TabIndex = 7
      '
      'btnAplicarCambios
      '
      Me.btnAplicarCambios.Image = CType(resources.GetObject("btnAplicarCambios.Image"), System.Drawing.Image)
      Me.btnAplicarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAplicarCambios.Location = New System.Drawing.Point(806, 29)
      Me.btnAplicarCambios.Name = "btnAplicarCambios"
      Me.btnAplicarCambios.Size = New System.Drawing.Size(116, 51)
      Me.btnAplicarCambios.TabIndex = 8
      Me.btnAplicarCambios.Text = "Aplicar"
      Me.btnAplicarCambios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAplicarCambios.UseVisualStyleBackColor = True
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(189, 54)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(22, 13)
      Me.Label2.TabIndex = 6
      Me.Label2.Text = "por"
      '
      'txtReemplazarCaracter1
      '
      Me.txtReemplazarCaracter1.BindearPropiedadControl = Nothing
      Me.txtReemplazarCaracter1.BindearPropiedadEntidad = Nothing
      Me.txtReemplazarCaracter1.Enabled = False
      Me.txtReemplazarCaracter1.ForeColorFocus = System.Drawing.Color.Red
      Me.txtReemplazarCaracter1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtReemplazarCaracter1.Formato = ""
      Me.txtReemplazarCaracter1.IsDecimal = False
      Me.txtReemplazarCaracter1.IsNumber = False
      Me.txtReemplazarCaracter1.IsPK = False
      Me.txtReemplazarCaracter1.IsRequired = False
      Me.txtReemplazarCaracter1.Key = ""
      Me.txtReemplazarCaracter1.LabelAsoc = Nothing
      Me.txtReemplazarCaracter1.Location = New System.Drawing.Point(136, 51)
      Me.txtReemplazarCaracter1.Name = "txtReemplazarCaracter1"
      Me.txtReemplazarCaracter1.Size = New System.Drawing.Size(47, 20)
      Me.txtReemplazarCaracter1.TabIndex = 5
      '
      'txtSufijo
      '
      Me.txtSufijo.BindearPropiedadControl = Nothing
      Me.txtSufijo.BindearPropiedadEntidad = Nothing
      Me.txtSufijo.Enabled = False
      Me.txtSufijo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSufijo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSufijo.Formato = ""
      Me.txtSufijo.IsDecimal = False
      Me.txtSufijo.IsNumber = False
      Me.txtSufijo.IsPK = False
      Me.txtSufijo.IsRequired = False
      Me.txtSufijo.Key = ""
      Me.txtSufijo.LabelAsoc = Nothing
      Me.txtSufijo.Location = New System.Drawing.Point(136, 28)
      Me.txtSufijo.Name = "txtSufijo"
      Me.txtSufijo.Size = New System.Drawing.Size(47, 20)
      Me.txtSufijo.TabIndex = 3
      '
      'txtPrefijo
      '
      Me.txtPrefijo.BindearPropiedadControl = Nothing
      Me.txtPrefijo.BindearPropiedadEntidad = Nothing
      Me.txtPrefijo.Enabled = False
      Me.txtPrefijo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrefijo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrefijo.Formato = ""
      Me.txtPrefijo.IsDecimal = False
      Me.txtPrefijo.IsNumber = False
      Me.txtPrefijo.IsPK = False
      Me.txtPrefijo.IsRequired = False
      Me.txtPrefijo.Key = ""
      Me.txtPrefijo.LabelAsoc = Nothing
      Me.txtPrefijo.Location = New System.Drawing.Point(136, 5)
      Me.txtPrefijo.Name = "txtPrefijo"
      Me.txtPrefijo.Size = New System.Drawing.Size(47, 20)
      Me.txtPrefijo.TabIndex = 1
      '
      'chbReemplazarCaracter
      '
      Me.chbReemplazarCaracter.AutoSize = True
      Me.chbReemplazarCaracter.Location = New System.Drawing.Point(6, 53)
      Me.chbReemplazarCaracter.Name = "chbReemplazarCaracter"
      Me.chbReemplazarCaracter.Size = New System.Drawing.Size(124, 17)
      Me.chbReemplazarCaracter.TabIndex = 4
      Me.chbReemplazarCaracter.Text = "Reemplazar caracter"
      Me.chbReemplazarCaracter.UseVisualStyleBackColor = True
      '
      'chbSufijo
      '
      Me.chbSufijo.AutoSize = True
      Me.chbSufijo.Location = New System.Drawing.Point(6, 30)
      Me.chbSufijo.Name = "chbSufijo"
      Me.chbSufijo.Size = New System.Drawing.Size(92, 17)
      Me.chbSufijo.TabIndex = 2
      Me.chbSufijo.Text = "Agregar Sufijo"
      Me.chbSufijo.UseVisualStyleBackColor = True
      '
      'chbPrefijo
      '
      Me.chbPrefijo.AutoSize = True
      Me.chbPrefijo.Location = New System.Drawing.Point(6, 7)
      Me.chbPrefijo.Name = "chbPrefijo"
      Me.chbPrefijo.Size = New System.Drawing.Size(95, 17)
      Me.chbPrefijo.TabIndex = 0
      Me.chbPrefijo.Text = "Agregar Prefijo"
      Me.chbPrefijo.UseVisualStyleBackColor = True
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridBand1.SummaryFooterCaption = "Totales:"
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = " Arrastrar la Columna que desea agrupar"
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.EnterMueveACeldaDeAbajo = True
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(12, 182)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(936, 349)
      Me.ugDetalle.TabIndex = 34
      Me.ugDetalle.Text = "UltraGrid1"
      Me.ugDetalle.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 539)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(960, 22)
      Me.stsStado.TabIndex = 35
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(881, 17)
      Me.tssInfo.Spring = True
      Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
      'ProdActualizacionMasivaCodigos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(960, 561)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.tabFiltroOpciones)
      Me.Controls.Add(Me.btnTodos)
      Me.Controls.Add(Me.cmbTodos)
      Me.Controls.Add(Me.tstBarra)
      Me.KeyPreview = True
      Me.Name = "ProdActualizacionMasivaCodigos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Productos - Cambio Masivo de Códigos"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.tabFiltroOpciones.ResumeLayout(False)
      Me.tbpFiltros.ResumeLayout(False)
      Me.tbpFiltros.PerformLayout()
      Me.pSubRubro.ResumeLayout(False)
      Me.pSubRubro.PerformLayout()
      Me.tbpOpciones.ResumeLayout(False)
      Me.tbpOpciones.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Friend WithEvents tabFiltroOpciones As System.Windows.Forms.TabControl
   Friend WithEvents tbpFiltros As System.Windows.Forms.TabPage
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbMarca As Eniac.Win.ComboBoxMarcas
   Friend WithEvents lblMarca As Eniac.Controles.Label
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents cmbRubro As Eniac.Win.ComboBoxRubro
   Friend WithEvents tbpOpciones As System.Windows.Forms.TabPage
   Friend WithEvents pSubRubro As System.Windows.Forms.Panel
   Friend WithEvents chbReemplazarCaracter As System.Windows.Forms.CheckBox
   Friend WithEvents chbSufijo As System.Windows.Forms.CheckBox
   Friend WithEvents chbPrefijo As System.Windows.Forms.CheckBox
   Friend WithEvents txtReemplazarCaracter1 As Eniac.Controles.TextBox
   Friend WithEvents txtSufijo As Eniac.Controles.TextBox
   Friend WithEvents txtPrefijo As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents btnAplicarCambios As System.Windows.Forms.Button
   Friend WithEvents txtReemplazarCaracter2 As Eniac.Controles.TextBox
   Friend WithEvents ugDetalle As Eniac.Win.UltraGridEditable
   Friend WithEvents cmbSubRubro As Eniac.Win.ComboBoxSubRubro
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
End Class
