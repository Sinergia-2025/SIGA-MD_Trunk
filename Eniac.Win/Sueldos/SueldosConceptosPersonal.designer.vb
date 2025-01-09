<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosConceptosPersonal
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosConceptosPersonal))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.cmbTipoRecibo = New Eniac.Controles.ComboBox()
      Me.lblTipoRecibo = New Eniac.Controles.Label()
      Me.lblPeriodoActual = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.lblEstadoCivil = New Eniac.Controles.Label()
      Me.Label5 = New Eniac.Controles.Label()
      Me.lblNroDocumento = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lblCobrador = New Eniac.Controles.Label()
      Me.Label11 = New Eniac.Controles.Label()
      Me.lblCategoriaSocio = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.bscNroLegajo = New Eniac.Controles.Buscador()
      Me.bscNombrePersonal = New Eniac.Controles.Buscador()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.Label7 = New Eniac.Controles.Label()
      Me.btnBorrarConceptoAguinaldo = New Eniac.Controles.Button()
      Me.btnAsignarConcepto = New Eniac.Controles.Button()
      Me.txtValorConcepto = New Eniac.Controles.TextBox()
      Me.btnBorrarConceptoSueldo = New Eniac.Controles.Button()
      Me.Label9 = New Eniac.Controles.Label()
      Me.lblCodigoConcepto = New Eniac.Controles.Label()
      Me.lblNombreConcepto = New Eniac.Controles.Label()
      Me.bscCodigoConcepto = New Eniac.Controles.Buscador()
      Me.bscNombreConcepto = New Eniac.Controles.Buscador()
      Me.lblTipoConcepto = New Eniac.Controles.Label()
      Me.Label10 = New Eniac.Controles.Label()
      Me.Label12 = New Eniac.Controles.Label()
      Me.lblModalidad = New Eniac.Controles.Label()
      Me.grpConceptos = New System.Windows.Forms.GroupBox()
      Me.btnLimpiar = New Eniac.Controles.Button()
      Me.txtPeriodosLiquidar = New Eniac.Controles.TextBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.grpModalidad = New System.Windows.Forms.GroupBox()
      Me.RadioModoAguinaldo = New System.Windows.Forms.RadioButton()
      Me.RadioModoNormal = New System.Windows.Forms.RadioButton()
      Me.Label14 = New Eniac.Controles.Label()
      Me.lblNormal_o_Aguianaldo = New Eniac.Controles.Label()
      Me.lblValorConcepto = New Eniac.Controles.Label()
      Me.dgvConceptosSueldo = New Eniac.Controles.DataGridView()
      Me.CodigoConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsIdConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsNombreConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsNombreTipoConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsNombreQuePide = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsNombreTipoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsidLegajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsIdTipoConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsIdQuePide = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsIdTipoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsPeriodos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grsEsAguinaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.dgvConceptosAguinaldo = New Eniac.Controles.DataGridView()
      Me.graIdConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoConcepto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graNombreConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graNombreTipoCOncepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graNombreQuePide = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graNombreTipoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graIdLegajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graIdTipoConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graIdQuePide = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graPeriodos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graIdTipoRecibo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.graEsAguinaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.GrillaPagosRecibosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DataSetSueldos = New Eniac.Win.DataSetSueldos()
      Me.GeneraCuotasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.grbPendientes.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.grpConceptos.SuspendLayout()
      Me.grpModalidad.SuspendLayout()
      CType(Me.dgvConceptosSueldo, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvConceptosAguinaldo, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.GrillaPagosRecibosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.GeneraCuotasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.cmbTipoRecibo)
      Me.grbPendientes.Controls.Add(Me.lblPeriodoActual)
      Me.grbPendientes.Controls.Add(Me.Label2)
      Me.grbPendientes.Controls.Add(Me.lblTipoRecibo)
      Me.grbPendientes.Controls.Add(Me.lblEstadoCivil)
      Me.grbPendientes.Controls.Add(Me.Label5)
      Me.grbPendientes.Controls.Add(Me.lblNroDocumento)
      Me.grbPendientes.Controls.Add(Me.Label1)
      Me.grbPendientes.Controls.Add(Me.lblCobrador)
      Me.grbPendientes.Controls.Add(Me.Label11)
      Me.grbPendientes.Controls.Add(Me.lblCategoriaSocio)
      Me.grbPendientes.Controls.Add(Me.Label3)
      Me.grbPendientes.Controls.Add(Me.bscNroLegajo)
      Me.grbPendientes.Controls.Add(Me.bscNombrePersonal)
      Me.grbPendientes.Location = New System.Drawing.Point(12, 24)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(889, 86)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'cmbTipoRecibo
      '
      Me.cmbTipoRecibo.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoRecibo.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.cmbTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoRecibo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoRecibo.FormattingEnabled = True
      Me.cmbTipoRecibo.IsPK = False
      Me.cmbTipoRecibo.IsRequired = True
      Me.cmbTipoRecibo.Key = Nothing
      Me.cmbTipoRecibo.LabelAsoc = Me.lblTipoRecibo
      Me.cmbTipoRecibo.Location = New System.Drawing.Point(672, 22)
      Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
      Me.cmbTipoRecibo.Size = New System.Drawing.Size(126, 21)
      Me.cmbTipoRecibo.TabIndex = 18
      '
      'lblTipoRecibo
      '
      Me.lblTipoRecibo.AutoSize = True
      Me.lblTipoRecibo.Location = New System.Drawing.Point(586, 30)
      Me.lblTipoRecibo.Name = "lblTipoRecibo"
      Me.lblTipoRecibo.Size = New System.Drawing.Size(80, 13)
      Me.lblTipoRecibo.TabIndex = 19
      Me.lblTipoRecibo.Text = "Tipo de Recibo"
      '
      'lblPeriodoActual
      '
      Me.lblPeriodoActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblPeriodoActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblPeriodoActual.Location = New System.Drawing.Point(737, 56)
      Me.lblPeriodoActual.Name = "lblPeriodoActual"
      Me.lblPeriodoActual.Size = New System.Drawing.Size(57, 19)
      Me.lblPeriodoActual.TabIndex = 11
      Me.lblPeriodoActual.Text = "-"
      Me.lblPeriodoActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(631, 59)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(100, 13)
      Me.Label2.TabIndex = 10
      Me.Label2.Text = "Periodo Liquidacion"
      '
      'lblEstadoCivil
      '
      Me.lblEstadoCivil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblEstadoCivil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblEstadoCivil.Location = New System.Drawing.Point(318, 56)
      Me.lblEstadoCivil.Name = "lblEstadoCivil"
      Me.lblEstadoCivil.Size = New System.Drawing.Size(149, 19)
      Me.lblEstadoCivil.TabIndex = 7
      Me.lblEstadoCivil.Text = "-"
      Me.lblEstadoCivil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(250, 59)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(62, 13)
      Me.Label5.TabIndex = 6
      Me.Label5.Text = "Estado Civil"
      '
      'lblNroDocumento
      '
      Me.lblNroDocumento.AutoSize = True
      Me.lblNroDocumento.Location = New System.Drawing.Point(20, 30)
      Me.lblNroDocumento.Name = "lblNroDocumento"
      Me.lblNroDocumento.Size = New System.Drawing.Size(39, 13)
      Me.lblNroDocumento.TabIndex = 0
      Me.lblNroDocumento.Text = "Legajo"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(227, 30)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(44, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Nombre"
      '
      'lblCobrador
      '
      Me.lblCobrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblCobrador.Location = New System.Drawing.Point(563, 55)
      Me.lblCobrador.Name = "lblCobrador"
      Me.lblCobrador.Size = New System.Drawing.Size(35, 20)
      Me.lblCobrador.TabIndex = 9
      Me.lblCobrador.Text = "-"
      Me.lblCobrador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(525, 59)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(32, 13)
      Me.Label11.TabIndex = 8
      Me.Label11.Text = "Edad"
      '
      'lblCategoriaSocio
      '
      Me.lblCategoriaSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblCategoriaSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblCategoriaSocio.Location = New System.Drawing.Point(76, 56)
      Me.lblCategoriaSocio.Name = "lblCategoriaSocio"
      Me.lblCategoriaSocio.Size = New System.Drawing.Size(168, 19)
      Me.lblCategoriaSocio.TabIndex = 5
      Me.lblCategoriaSocio.Text = "-"
      Me.lblCategoriaSocio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(20, 59)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(52, 13)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Categoria"
      '
      'bscNroLegajo
      '
      Me.bscNroLegajo.AyudaAncho = 608
      Me.bscNroLegajo.BindearPropiedadControl = Nothing
      Me.bscNroLegajo.BindearPropiedadEntidad = Nothing
      Me.bscNroLegajo.ColumnasAlineacion = Nothing
      Me.bscNroLegajo.ColumnasAncho = Nothing
      Me.bscNroLegajo.ColumnasFormato = Nothing
      Me.bscNroLegajo.ColumnasOcultas = Nothing
      Me.bscNroLegajo.ColumnasTitulos = Nothing
      Me.bscNroLegajo.Datos = Nothing
      Me.bscNroLegajo.FilaDevuelta = Nothing
      Me.bscNroLegajo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNroLegajo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNroLegajo.IsDecimal = False
      Me.bscNroLegajo.IsNumber = True
      Me.bscNroLegajo.IsPK = False
      Me.bscNroLegajo.IsRequired = False
      Me.bscNroLegajo.Key = ""
      Me.bscNroLegajo.LabelAsoc = Nothing
      Me.bscNroLegajo.Location = New System.Drawing.Point(79, 25)
      Me.bscNroLegajo.MaxLengh = "32767"
      Me.bscNroLegajo.Name = "bscNroLegajo"
      Me.bscNroLegajo.Permitido = True
      Me.bscNroLegajo.Selecciono = False
      Me.bscNroLegajo.Size = New System.Drawing.Size(131, 23)
      Me.bscNroLegajo.TabIndex = 1
      Me.bscNroLegajo.Titulo = Nothing
      '
      'bscNombrePersonal
      '
      Me.bscNombrePersonal.AutoSize = True
      Me.bscNombrePersonal.AyudaAncho = 608
      Me.bscNombrePersonal.BindearPropiedadControl = Nothing
      Me.bscNombrePersonal.BindearPropiedadEntidad = Nothing
      Me.bscNombrePersonal.ColumnasAlineacion = Nothing
      Me.bscNombrePersonal.ColumnasAncho = Nothing
      Me.bscNombrePersonal.ColumnasFormato = Nothing
      Me.bscNombrePersonal.ColumnasOcultas = Nothing
      Me.bscNombrePersonal.ColumnasTitulos = Nothing
      Me.bscNombrePersonal.Datos = Nothing
      Me.bscNombrePersonal.FilaDevuelta = Nothing
      Me.bscNombrePersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombrePersonal.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombrePersonal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombrePersonal.IsDecimal = False
      Me.bscNombrePersonal.IsNumber = False
      Me.bscNombrePersonal.IsPK = False
      Me.bscNombrePersonal.IsRequired = False
      Me.bscNombrePersonal.Key = ""
      Me.bscNombrePersonal.LabelAsoc = Nothing
      Me.bscNombrePersonal.Location = New System.Drawing.Point(278, 25)
      Me.bscNombrePersonal.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombrePersonal.MaxLengh = "32767"
      Me.bscNombrePersonal.Name = "bscNombrePersonal"
      Me.bscNombrePersonal.Permitido = True
      Me.bscNombrePersonal.Selecciono = False
      Me.bscNombrePersonal.Size = New System.Drawing.Size(307, 23)
      Me.bscNombrePersonal.TabIndex = 3
      Me.bscNombrePersonal.Titulo = Nothing
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "document_find.ico")
      Me.imgIconos.Images.SetKeyName(1, "folder.ico")
      Me.imgIconos.Images.SetKeyName(2, "row_add.ico")
      Me.imgIconos.Images.SetKeyName(3, "refresh.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsbGrabar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(912, 29)
      Me.tstBarra.TabIndex = 9
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
      'tsbImprimir
      '
      Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
      Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImprimir.Name = "tsbImprimir"
      Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
      Me.tsbImprimir.Text = "&Imprimir"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
      '
      'tsbGrabar
      '
      Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "&Grabar"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 519)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(912, 22)
      Me.StatusStrip1.TabIndex = 8
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(897, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(9, 366)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(123, 13)
      Me.Label7.TabIndex = 4
      Me.Label7.Text = "Conceptos de Aguinaldo"
      '
      'btnBorrarConceptoAguinaldo
      '
      Me.btnBorrarConceptoAguinaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBorrarConceptoAguinaldo.Enabled = False
      Me.btnBorrarConceptoAguinaldo.Image = CType(resources.GetObject("btnBorrarConceptoAguinaldo.Image"), System.Drawing.Image)
      Me.btnBorrarConceptoAguinaldo.Location = New System.Drawing.Point(864, 415)
      Me.btnBorrarConceptoAguinaldo.Name = "btnBorrarConceptoAguinaldo"
      Me.btnBorrarConceptoAguinaldo.Size = New System.Drawing.Size(37, 37)
      Me.btnBorrarConceptoAguinaldo.TabIndex = 6
      Me.btnBorrarConceptoAguinaldo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnBorrarConceptoAguinaldo.UseVisualStyleBackColor = True
      '
      'btnAsignarConcepto
      '
      Me.btnAsignarConcepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAsignarConcepto.Image = CType(resources.GetObject("btnAsignarConcepto.Image"), System.Drawing.Image)
      Me.btnAsignarConcepto.Location = New System.Drawing.Point(808, 61)
      Me.btnAsignarConcepto.Name = "btnAsignarConcepto"
      Me.btnAsignarConcepto.Size = New System.Drawing.Size(37, 37)
      Me.btnAsignarConcepto.TabIndex = 6
      Me.btnAsignarConcepto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnAsignarConcepto.UseVisualStyleBackColor = True
      '
      'txtValorConcepto
      '
      Me.txtValorConcepto.BindearPropiedadControl = ""
      Me.txtValorConcepto.BindearPropiedadEntidad = ""
      Me.txtValorConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtValorConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtValorConcepto.Formato = "#,##0.00"
      Me.txtValorConcepto.IsDecimal = True
      Me.txtValorConcepto.IsNumber = True
      Me.txtValorConcepto.IsPK = False
      Me.txtValorConcepto.IsRequired = True
      Me.txtValorConcepto.Key = ""
      Me.txtValorConcepto.LabelAsoc = Nothing
      Me.txtValorConcepto.Location = New System.Drawing.Point(629, 38)
      Me.txtValorConcepto.MaxLength = 25
      Me.txtValorConcepto.Name = "txtValorConcepto"
      Me.txtValorConcepto.Size = New System.Drawing.Size(76, 20)
      Me.txtValorConcepto.TabIndex = 5
      Me.txtValorConcepto.Text = "0.00"
      Me.txtValorConcepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnBorrarConceptoSueldo
      '
      Me.btnBorrarConceptoSueldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBorrarConceptoSueldo.Image = CType(resources.GetObject("btnBorrarConceptoSueldo.Image"), System.Drawing.Image)
      Me.btnBorrarConceptoSueldo.Location = New System.Drawing.Point(864, 285)
      Me.btnBorrarConceptoSueldo.Name = "btnBorrarConceptoSueldo"
      Me.btnBorrarConceptoSueldo.Size = New System.Drawing.Size(37, 37)
      Me.btnBorrarConceptoSueldo.TabIndex = 3
      Me.btnBorrarConceptoSueldo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnBorrarConceptoSueldo.UseVisualStyleBackColor = True
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(10, 235)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(109, 13)
      Me.Label9.TabIndex = 1
      Me.Label9.Text = "Conceptos de Sueldo"
      '
      'lblCodigoConcepto
      '
      Me.lblCodigoConcepto.AutoSize = True
      Me.lblCodigoConcepto.Location = New System.Drawing.Point(162, 17)
      Me.lblCodigoConcepto.Name = "lblCodigoConcepto"
      Me.lblCodigoConcepto.Size = New System.Drawing.Size(53, 13)
      Me.lblCodigoConcepto.TabIndex = 0
      Me.lblCodigoConcepto.Text = "Concepto"
      '
      'lblNombreConcepto
      '
      Me.lblNombreConcepto.AutoSize = True
      Me.lblNombreConcepto.Location = New System.Drawing.Point(305, 17)
      Me.lblNombreConcepto.Name = "lblNombreConcepto"
      Me.lblNombreConcepto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreConcepto.TabIndex = 2
      Me.lblNombreConcepto.Text = "Nombre"
      '
      'bscCodigoConcepto
      '
      Me.bscCodigoConcepto.AyudaAncho = 608
      Me.bscCodigoConcepto.BindearPropiedadControl = Nothing
      Me.bscCodigoConcepto.BindearPropiedadEntidad = Nothing
      Me.bscCodigoConcepto.ColumnasAlineacion = Nothing
      Me.bscCodigoConcepto.ColumnasAncho = Nothing
      Me.bscCodigoConcepto.ColumnasFormato = Nothing
      Me.bscCodigoConcepto.ColumnasOcultas = Nothing
      Me.bscCodigoConcepto.ColumnasTitulos = Nothing
      Me.bscCodigoConcepto.Datos = Nothing
      Me.bscCodigoConcepto.FilaDevuelta = Nothing
      Me.bscCodigoConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoConcepto.IsDecimal = False
      Me.bscCodigoConcepto.IsNumber = True
      Me.bscCodigoConcepto.IsPK = False
      Me.bscCodigoConcepto.IsRequired = False
      Me.bscCodigoConcepto.Key = ""
      Me.bscCodigoConcepto.LabelAsoc = Me.lblCodigoConcepto
      Me.bscCodigoConcepto.Location = New System.Drawing.Point(168, 38)
      Me.bscCodigoConcepto.MaxLengh = "32767"
      Me.bscCodigoConcepto.Name = "bscCodigoConcepto"
      Me.bscCodigoConcepto.Permitido = True
      Me.bscCodigoConcepto.Selecciono = False
      Me.bscCodigoConcepto.Size = New System.Drawing.Size(131, 23)
      Me.bscCodigoConcepto.TabIndex = 1
      Me.bscCodigoConcepto.Titulo = Nothing
      '
      'bscNombreConcepto
      '
      Me.bscNombreConcepto.AutoSize = True
      Me.bscNombreConcepto.AyudaAncho = 608
      Me.bscNombreConcepto.BindearPropiedadControl = Nothing
      Me.bscNombreConcepto.BindearPropiedadEntidad = Nothing
      Me.bscNombreConcepto.ColumnasAlineacion = Nothing
      Me.bscNombreConcepto.ColumnasAncho = Nothing
      Me.bscNombreConcepto.ColumnasFormato = Nothing
      Me.bscNombreConcepto.ColumnasOcultas = Nothing
      Me.bscNombreConcepto.ColumnasTitulos = Nothing
      Me.bscNombreConcepto.Datos = Nothing
      Me.bscNombreConcepto.FilaDevuelta = Nothing
      Me.bscNombreConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreConcepto.IsDecimal = False
      Me.bscNombreConcepto.IsNumber = False
      Me.bscNombreConcepto.IsPK = False
      Me.bscNombreConcepto.IsRequired = False
      Me.bscNombreConcepto.Key = ""
      Me.bscNombreConcepto.LabelAsoc = Me.lblNombreConcepto
      Me.bscNombreConcepto.Location = New System.Drawing.Point(306, 38)
      Me.bscNombreConcepto.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreConcepto.MaxLengh = "32767"
      Me.bscNombreConcepto.Name = "bscNombreConcepto"
      Me.bscNombreConcepto.Permitido = True
      Me.bscNombreConcepto.Selecciono = False
      Me.bscNombreConcepto.Size = New System.Drawing.Size(307, 23)
      Me.bscNombreConcepto.TabIndex = 3
      Me.bscNombreConcepto.Titulo = Nothing
      '
      'lblTipoConcepto
      '
      Me.lblTipoConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblTipoConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblTipoConcepto.Location = New System.Drawing.Point(169, 77)
      Me.lblTipoConcepto.Name = "lblTipoConcepto"
      Me.lblTipoConcepto.Size = New System.Drawing.Size(149, 19)
      Me.lblTipoConcepto.TabIndex = 10
      Me.lblTipoConcepto.Text = "-"
      Me.lblTipoConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(166, 61)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(92, 13)
      Me.Label10.TabIndex = 9
      Me.Label10.Text = "Tipo de Concepto"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(476, 58)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(56, 13)
      Me.Label12.TabIndex = 13
      Me.Label12.Text = "Modalidad"
      '
      'lblModalidad
      '
      Me.lblModalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblModalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblModalidad.Location = New System.Drawing.Point(479, 77)
      Me.lblModalidad.Name = "lblModalidad"
      Me.lblModalidad.Size = New System.Drawing.Size(149, 19)
      Me.lblModalidad.TabIndex = 14
      Me.lblModalidad.Text = "-"
      Me.lblModalidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grpConceptos
      '
      Me.grpConceptos.Controls.Add(Me.btnLimpiar)
      Me.grpConceptos.Controls.Add(Me.txtPeriodosLiquidar)
      Me.grpConceptos.Controls.Add(Me.Label4)
      Me.grpConceptos.Controls.Add(Me.grpModalidad)
      Me.grpConceptos.Controls.Add(Me.Label14)
      Me.grpConceptos.Controls.Add(Me.lblNormal_o_Aguianaldo)
      Me.grpConceptos.Controls.Add(Me.lblValorConcepto)
      Me.grpConceptos.Controls.Add(Me.lblModalidad)
      Me.grpConceptos.Controls.Add(Me.Label12)
      Me.grpConceptos.Controls.Add(Me.btnAsignarConcepto)
      Me.grpConceptos.Controls.Add(Me.bscNombreConcepto)
      Me.grpConceptos.Controls.Add(Me.txtValorConcepto)
      Me.grpConceptos.Controls.Add(Me.bscCodigoConcepto)
      Me.grpConceptos.Controls.Add(Me.Label10)
      Me.grpConceptos.Controls.Add(Me.lblNombreConcepto)
      Me.grpConceptos.Controls.Add(Me.lblTipoConcepto)
      Me.grpConceptos.Controls.Add(Me.lblCodigoConcepto)
      Me.grpConceptos.Location = New System.Drawing.Point(12, 130)
      Me.grpConceptos.Name = "grpConceptos"
      Me.grpConceptos.Size = New System.Drawing.Size(889, 101)
      Me.grpConceptos.TabIndex = 7
      Me.grpConceptos.TabStop = False
      Me.grpConceptos.Text = "Seleccion de conceptos"
      '
      'btnLimpiar
      '
      Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
      Me.btnLimpiar.Location = New System.Drawing.Point(124, 24)
      Me.btnLimpiar.Name = "btnLimpiar"
      Me.btnLimpiar.Size = New System.Drawing.Size(37, 37)
      Me.btnLimpiar.TabIndex = 17
      Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnLimpiar.UseVisualStyleBackColor = True
      '
      'txtPeriodosLiquidar
      '
      Me.txtPeriodosLiquidar.BindearPropiedadControl = ""
      Me.txtPeriodosLiquidar.BindearPropiedadEntidad = ""
      Me.txtPeriodosLiquidar.Enabled = False
      Me.txtPeriodosLiquidar.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPeriodosLiquidar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPeriodosLiquidar.Formato = ""
      Me.txtPeriodosLiquidar.IsDecimal = False
      Me.txtPeriodosLiquidar.IsNumber = True
      Me.txtPeriodosLiquidar.IsPK = False
      Me.txtPeriodosLiquidar.IsRequired = False
      Me.txtPeriodosLiquidar.Key = ""
      Me.txtPeriodosLiquidar.LabelAsoc = Nothing
      Me.txtPeriodosLiquidar.Location = New System.Drawing.Point(753, 39)
      Me.txtPeriodosLiquidar.MaxLength = 2
      Me.txtPeriodosLiquidar.Name = "txtPeriodosLiquidar"
      Me.txtPeriodosLiquidar.Size = New System.Drawing.Size(45, 20)
      Me.txtPeriodosLiquidar.TabIndex = 16
      Me.txtPeriodosLiquidar.Text = "0"
      Me.txtPeriodosLiquidar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(730, 22)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(99, 13)
      Me.Label4.TabIndex = 15
      Me.Label4.Text = "Períodos a Liquidar"
      '
      'grpModalidad
      '
      Me.grpModalidad.Controls.Add(Me.RadioModoAguinaldo)
      Me.grpModalidad.Controls.Add(Me.RadioModoNormal)
      Me.grpModalidad.Location = New System.Drawing.Point(18, 35)
      Me.grpModalidad.Name = "grpModalidad"
      Me.grpModalidad.Size = New System.Drawing.Size(103, 52)
      Me.grpModalidad.TabIndex = 8
      Me.grpModalidad.TabStop = False
      '
      'RadioModoAguinaldo
      '
      Me.RadioModoAguinaldo.AutoSize = True
      Me.RadioModoAguinaldo.Location = New System.Drawing.Point(6, 29)
      Me.RadioModoAguinaldo.Name = "RadioModoAguinaldo"
      Me.RadioModoAguinaldo.Size = New System.Drawing.Size(72, 17)
      Me.RadioModoAguinaldo.TabIndex = 1
      Me.RadioModoAguinaldo.Text = "Aguinaldo"
      Me.RadioModoAguinaldo.UseVisualStyleBackColor = True
      '
      'RadioModoNormal
      '
      Me.RadioModoNormal.AutoSize = True
      Me.RadioModoNormal.Checked = True
      Me.RadioModoNormal.Location = New System.Drawing.Point(7, 10)
      Me.RadioModoNormal.Name = "RadioModoNormal"
      Me.RadioModoNormal.Size = New System.Drawing.Size(58, 17)
      Me.RadioModoNormal.TabIndex = 0
      Me.RadioModoNormal.TabStop = True
      Me.RadioModoNormal.Text = "Normal"
      Me.RadioModoNormal.UseVisualStyleBackColor = True
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(321, 61)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(100, 13)
      Me.Label14.TabIndex = 11
      Me.Label14.Text = "Tipo de Liquidacion"
      '
      'lblNormal_o_Aguianaldo
      '
      Me.lblNormal_o_Aguianaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblNormal_o_Aguianaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblNormal_o_Aguianaldo.Location = New System.Drawing.Point(324, 77)
      Me.lblNormal_o_Aguianaldo.Name = "lblNormal_o_Aguianaldo"
      Me.lblNormal_o_Aguianaldo.Size = New System.Drawing.Size(149, 19)
      Me.lblNormal_o_Aguianaldo.TabIndex = 12
      Me.lblNormal_o_Aguianaldo.Text = "-"
      Me.lblNormal_o_Aguianaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblValorConcepto
      '
      Me.lblValorConcepto.AutoSize = True
      Me.lblValorConcepto.Location = New System.Drawing.Point(670, 22)
      Me.lblValorConcepto.Name = "lblValorConcepto"
      Me.lblValorConcepto.Size = New System.Drawing.Size(31, 13)
      Me.lblValorConcepto.TabIndex = 4
      Me.lblValorConcepto.Text = "Valor"
      '
      'dgvConceptosSueldo
      '
      Me.dgvConceptosSueldo.AllowUserToAddRows = False
      Me.dgvConceptosSueldo.AllowUserToDeleteRows = False
      Me.dgvConceptosSueldo.AllowUserToResizeRows = False
      Me.dgvConceptosSueldo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvConceptosSueldo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvConceptosSueldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvConceptosSueldo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoConcepto, Me.grsIdConcepto, Me.grsNombreConcepto, Me.grsNombreTipoConcepto, Me.grsNombreQuePide, Me.grsValor, Me.grsNombreTipoRecibo, Me.grsidLegajo, Me.grsIdTipoConcepto, Me.grsIdQuePide, Me.grsIdTipoRecibo, Me.grsPeriodos, Me.grsEsAguinaldo})
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvConceptosSueldo.DefaultCellStyle = DataGridViewCellStyle3
      Me.dgvConceptosSueldo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvConceptosSueldo.Location = New System.Drawing.Point(136, 235)
      Me.dgvConceptosSueldo.MultiSelect = False
      Me.dgvConceptosSueldo.Name = "dgvConceptosSueldo"
      Me.dgvConceptosSueldo.ReadOnly = True
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvConceptosSueldo.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
      Me.dgvConceptosSueldo.RowHeadersVisible = False
      Me.dgvConceptosSueldo.RowHeadersWidth = 20
      Me.dgvConceptosSueldo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvConceptosSueldo.Size = New System.Drawing.Size(721, 130)
      Me.dgvConceptosSueldo.TabIndex = 2
      '
      'CodigoConcepto
      '
      Me.CodigoConcepto.DataPropertyName = "CodigoConcepto"
      Me.CodigoConcepto.HeaderText = "Codigo"
      Me.CodigoConcepto.Name = "CodigoConcepto"
      Me.CodigoConcepto.ReadOnly = True
      Me.CodigoConcepto.Width = 50
      '
      'grsIdConcepto
      '
      Me.grsIdConcepto.DataPropertyName = "IdConcepto"
      Me.grsIdConcepto.HeaderText = "Codigo"
      Me.grsIdConcepto.Name = "grsIdConcepto"
      Me.grsIdConcepto.ReadOnly = True
      Me.grsIdConcepto.Visible = False
      Me.grsIdConcepto.Width = 50
      '
      'grsNombreConcepto
      '
      Me.grsNombreConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.grsNombreConcepto.DataPropertyName = "NombreConcepto"
      Me.grsNombreConcepto.HeaderText = "Concepto"
      Me.grsNombreConcepto.Name = "grsNombreConcepto"
      Me.grsNombreConcepto.ReadOnly = True
      '
      'grsNombreTipoConcepto
      '
      Me.grsNombreTipoConcepto.DataPropertyName = "NombreTipoConcepto"
      Me.grsNombreTipoConcepto.HeaderText = "Tipo"
      Me.grsNombreTipoConcepto.Name = "grsNombreTipoConcepto"
      Me.grsNombreTipoConcepto.ReadOnly = True
      Me.grsNombreTipoConcepto.Width = 110
      '
      'grsNombreQuePide
      '
      Me.grsNombreQuePide.DataPropertyName = "NombreQuePide"
      Me.grsNombreQuePide.HeaderText = "Modalidad"
      Me.grsNombreQuePide.Name = "grsNombreQuePide"
      Me.grsNombreQuePide.ReadOnly = True
      Me.grsNombreQuePide.Width = 90
      '
      'grsValor
      '
      Me.grsValor.DataPropertyName = "Valor"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle2.Format = "N2"
      Me.grsValor.DefaultCellStyle = DataGridViewCellStyle2
      Me.grsValor.HeaderText = "Valor"
      Me.grsValor.Name = "grsValor"
      Me.grsValor.ReadOnly = True
      Me.grsValor.Width = 60
      '
      'grsNombreTipoRecibo
      '
      Me.grsNombreTipoRecibo.DataPropertyName = "NombreTipoRecibo"
      Me.grsNombreTipoRecibo.HeaderText = "Tipo Recibo"
      Me.grsNombreTipoRecibo.Name = "grsNombreTipoRecibo"
      Me.grsNombreTipoRecibo.ReadOnly = True
      Me.grsNombreTipoRecibo.Visible = False
      Me.grsNombreTipoRecibo.Width = 60
      '
      'grsidLegajo
      '
      Me.grsidLegajo.DataPropertyName = "IdLegajo"
      Me.grsidLegajo.HeaderText = "idLegajo"
      Me.grsidLegajo.Name = "grsidLegajo"
      Me.grsidLegajo.ReadOnly = True
      Me.grsidLegajo.Visible = False
      '
      'grsIdTipoConcepto
      '
      Me.grsIdTipoConcepto.DataPropertyName = "idTipoConcepto"
      Me.grsIdTipoConcepto.HeaderText = "idTipoConcepto"
      Me.grsIdTipoConcepto.Name = "grsIdTipoConcepto"
      Me.grsIdTipoConcepto.ReadOnly = True
      Me.grsIdTipoConcepto.Visible = False
      '
      'grsIdQuePide
      '
      Me.grsIdQuePide.DataPropertyName = "idQuePide"
      Me.grsIdQuePide.HeaderText = "idQuePide"
      Me.grsIdQuePide.Name = "grsIdQuePide"
      Me.grsIdQuePide.ReadOnly = True
      Me.grsIdQuePide.Visible = False
      '
      'grsIdTipoRecibo
      '
      Me.grsIdTipoRecibo.DataPropertyName = "IdTipoRecibo"
      Me.grsIdTipoRecibo.HeaderText = "IdTipoRecibo"
      Me.grsIdTipoRecibo.Name = "grsIdTipoRecibo"
      Me.grsIdTipoRecibo.ReadOnly = True
      Me.grsIdTipoRecibo.Visible = False
      '
      'grsPeriodos
      '
      Me.grsPeriodos.DataPropertyName = "Periodos"
      Me.grsPeriodos.HeaderText = "Periodos"
      Me.grsPeriodos.Name = "grsPeriodos"
      Me.grsPeriodos.ReadOnly = True
      Me.grsPeriodos.Width = 50
      '
      'grsEsAguinaldo
      '
      Me.grsEsAguinaldo.DataPropertyName = "EsAguinaldo"
      Me.grsEsAguinaldo.HeaderText = "EsAguinaldo"
      Me.grsEsAguinaldo.Name = "grsEsAguinaldo"
      Me.grsEsAguinaldo.ReadOnly = True
      Me.grsEsAguinaldo.Visible = False
      '
      'dgvConceptosAguinaldo
      '
      Me.dgvConceptosAguinaldo.AllowUserToAddRows = False
      Me.dgvConceptosAguinaldo.AllowUserToDeleteRows = False
      Me.dgvConceptosAguinaldo.AllowUserToResizeRows = False
      Me.dgvConceptosAguinaldo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvConceptosAguinaldo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
      Me.dgvConceptosAguinaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvConceptosAguinaldo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.graIdConcepto, Me.CodigoConcepto1, Me.graNombreConcepto, Me.graNombreTipoCOncepto, Me.graNombreQuePide, Me.graValor, Me.graNombreTipoRecibo, Me.graIdLegajo, Me.graIdTipoConcepto, Me.graIdQuePide, Me.graPeriodos, Me.graIdTipoRecibo, Me.graEsAguinaldo})
      DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvConceptosAguinaldo.DefaultCellStyle = DataGridViewCellStyle7
      Me.dgvConceptosAguinaldo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvConceptosAguinaldo.Location = New System.Drawing.Point(136, 366)
      Me.dgvConceptosAguinaldo.MultiSelect = False
      Me.dgvConceptosAguinaldo.Name = "dgvConceptosAguinaldo"
      Me.dgvConceptosAguinaldo.ReadOnly = True
      DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvConceptosAguinaldo.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
      Me.dgvConceptosAguinaldo.RowHeadersVisible = False
      Me.dgvConceptosAguinaldo.RowHeadersWidth = 20
      Me.dgvConceptosAguinaldo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvConceptosAguinaldo.Size = New System.Drawing.Size(721, 150)
      Me.dgvConceptosAguinaldo.TabIndex = 10
      '
      'graIdConcepto
      '
      Me.graIdConcepto.DataPropertyName = "idConcepto"
      Me.graIdConcepto.HeaderText = "Codigo"
      Me.graIdConcepto.Name = "graIdConcepto"
      Me.graIdConcepto.ReadOnly = True
      Me.graIdConcepto.Visible = False
      Me.graIdConcepto.Width = 50
      '
      'CodigoConcepto1
      '
      Me.CodigoConcepto1.DataPropertyName = "CodigoConcepto"
      Me.CodigoConcepto1.HeaderText = "Codigo"
      Me.CodigoConcepto1.Name = "CodigoConcepto1"
      Me.CodigoConcepto1.ReadOnly = True
      Me.CodigoConcepto1.Width = 50
      '
      'graNombreConcepto
      '
      Me.graNombreConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.graNombreConcepto.DataPropertyName = "NombreConcepto"
      Me.graNombreConcepto.HeaderText = "Concepto"
      Me.graNombreConcepto.Name = "graNombreConcepto"
      Me.graNombreConcepto.ReadOnly = True
      '
      'graNombreTipoCOncepto
      '
      Me.graNombreTipoCOncepto.DataPropertyName = "NombreTipoConcepto"
      Me.graNombreTipoCOncepto.HeaderText = "Tipo"
      Me.graNombreTipoCOncepto.Name = "graNombreTipoCOncepto"
      Me.graNombreTipoCOncepto.ReadOnly = True
      Me.graNombreTipoCOncepto.Width = 110
      '
      'graNombreQuePide
      '
      Me.graNombreQuePide.DataPropertyName = "NombreQuePide"
      Me.graNombreQuePide.HeaderText = "Modalidad"
      Me.graNombreQuePide.Name = "graNombreQuePide"
      Me.graNombreQuePide.ReadOnly = True
      Me.graNombreQuePide.Width = 90
      '
      'graValor
      '
      Me.graValor.DataPropertyName = "Valor"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "N2"
      Me.graValor.DefaultCellStyle = DataGridViewCellStyle6
      Me.graValor.HeaderText = "Valor"
      Me.graValor.Name = "graValor"
      Me.graValor.ReadOnly = True
      Me.graValor.Width = 60
      '
      'graNombreTipoRecibo
      '
      Me.graNombreTipoRecibo.DataPropertyName = "NombreTipoRecibo"
      Me.graNombreTipoRecibo.HeaderText = "Tipo Recibo"
      Me.graNombreTipoRecibo.Name = "graNombreTipoRecibo"
      Me.graNombreTipoRecibo.ReadOnly = True
      Me.graNombreTipoRecibo.Visible = False
      Me.graNombreTipoRecibo.Width = 60
      '
      'graIdLegajo
      '
      Me.graIdLegajo.DataPropertyName = "IdLegajo"
      Me.graIdLegajo.HeaderText = "idLegajo"
      Me.graIdLegajo.Name = "graIdLegajo"
      Me.graIdLegajo.ReadOnly = True
      Me.graIdLegajo.Visible = False
      '
      'graIdTipoConcepto
      '
      Me.graIdTipoConcepto.DataPropertyName = "IdTipoConcepto"
      Me.graIdTipoConcepto.HeaderText = "idTipoConcepto"
      Me.graIdTipoConcepto.Name = "graIdTipoConcepto"
      Me.graIdTipoConcepto.ReadOnly = True
      Me.graIdTipoConcepto.Visible = False
      '
      'graIdQuePide
      '
      Me.graIdQuePide.DataPropertyName = "IdQuePide"
      Me.graIdQuePide.HeaderText = "idQuePide"
      Me.graIdQuePide.Name = "graIdQuePide"
      Me.graIdQuePide.ReadOnly = True
      Me.graIdQuePide.Visible = False
      '
      'graPeriodos
      '
      Me.graPeriodos.DataPropertyName = "Periodos"
      Me.graPeriodos.HeaderText = "Periodos"
      Me.graPeriodos.Name = "graPeriodos"
      Me.graPeriodos.ReadOnly = True
      Me.graPeriodos.Width = 50
      '
      'graIdTipoRecibo
      '
      Me.graIdTipoRecibo.DataPropertyName = "IdTipoRecibo"
      Me.graIdTipoRecibo.HeaderText = "Recibo"
      Me.graIdTipoRecibo.Name = "graIdTipoRecibo"
      Me.graIdTipoRecibo.ReadOnly = True
      Me.graIdTipoRecibo.Visible = False
      '
      'graEsAguinaldo
      '
      Me.graEsAguinaldo.DataPropertyName = "EsAguinaldo"
      Me.graEsAguinaldo.HeaderText = "EsAguinaldo"
      Me.graEsAguinaldo.Name = "graEsAguinaldo"
      Me.graEsAguinaldo.ReadOnly = True
      Me.graEsAguinaldo.Visible = False
      '
      'GrillaPagosRecibosBindingSource
      '
      Me.GrillaPagosRecibosBindingSource.DataMember = "ConceptosPersonal"
      Me.GrillaPagosRecibosBindingSource.DataSource = Me.DataSetSueldos
      '
      'DataSetSueldos
      '
      Me.DataSetSueldos.DataSetName = "DataSetSueldos"
      Me.DataSetSueldos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'GeneraCuotasBindingSource
      '
      Me.GeneraCuotasBindingSource.DataMember = "ConceptosPersonal"
      Me.GeneraCuotasBindingSource.DataSource = Me.DataSetSueldos
      '
      'SueldosConceptosPersonal
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(912, 541)
      Me.Controls.Add(Me.dgvConceptosAguinaldo)
      Me.Controls.Add(Me.grpConceptos)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.btnBorrarConceptoAguinaldo)
      Me.Controls.Add(Me.btnBorrarConceptoSueldo)
      Me.Controls.Add(Me.dgvConceptosSueldo)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.grbPendientes)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "SueldosConceptosPersonal"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Asignacion de Conceptos a Personal"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.grpConceptos.ResumeLayout(False)
      Me.grpConceptos.PerformLayout()
      Me.grpModalidad.ResumeLayout(False)
      Me.grpModalidad.PerformLayout()
      CType(Me.dgvConceptosSueldo, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvConceptosAguinaldo, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.GrillaPagosRecibosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.GeneraCuotasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents GeneraCuotasBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataSetSueldos As Eniac.Win.DataSetSueldos
   Friend WithEvents bscNroLegajo As Eniac.Controles.Buscador
   Friend WithEvents bscNombrePersonal As Eniac.Controles.Buscador
   Friend WithEvents lblCategoriaSocio As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents GrillaPagosRecibosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents lblCobrador As Eniac.Controles.Label
   Friend WithEvents Label11 As Eniac.Controles.Label
   Friend WithEvents lblNroDocumento As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents btnBorrarConceptoAguinaldo As Eniac.Controles.Button
   Friend WithEvents btnAsignarConcepto As Eniac.Controles.Button
   Friend WithEvents txtValorConcepto As Eniac.Controles.TextBox
   Friend WithEvents btnBorrarConceptoSueldo As Eniac.Controles.Button
   Friend WithEvents TipoDocSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PeriodoDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobanteDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobanteDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Periodo2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaSocioDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SaldoDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ObservacionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblEstadoCivil As Eniac.Controles.Label
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents lblPeriodoActual As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents Label9 As Eniac.Controles.Label
   Friend WithEvents lblCodigoConcepto As Eniac.Controles.Label
   Friend WithEvents lblNombreConcepto As Eniac.Controles.Label
   Friend WithEvents bscCodigoConcepto As Eniac.Controles.Buscador
   Friend WithEvents bscNombreConcepto As Eniac.Controles.Buscador
   Friend WithEvents lblTipoConcepto As Eniac.Controles.Label
   Friend WithEvents Label10 As Eniac.Controles.Label
   Friend WithEvents Label12 As Eniac.Controles.Label
   Friend WithEvents lblModalidad As Eniac.Controles.Label
   Friend WithEvents grpConceptos As System.Windows.Forms.GroupBox
   Friend WithEvents lblValorConcepto As Eniac.Controles.Label
   Friend WithEvents Label14 As Eniac.Controles.Label
   Friend WithEvents lblNormal_o_Aguianaldo As Eniac.Controles.Label
   Friend WithEvents grpModalidad As System.Windows.Forms.GroupBox
   Friend WithEvents RadioModoAguinaldo As System.Windows.Forms.RadioButton
   Friend WithEvents RadioModoNormal As System.Windows.Forms.RadioButton
   Friend WithEvents txtPeriodosLiquidar As Eniac.Controles.TextBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents dgvConceptosSueldo As Eniac.Controles.DataGridView
   Friend WithEvents dgvConceptosAguinaldo As Eniac.Controles.DataGridView
   Friend WithEvents cmbTipoRecibo As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoRecibo As Eniac.Controles.Label
   Friend WithEvents btnLimpiar As Eniac.Controles.Button
   Friend WithEvents CodigoConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsIdConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsNombreConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsNombreTipoConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsNombreQuePide As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsValor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsNombreTipoRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsidLegajo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsIdTipoConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsIdQuePide As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsIdTipoRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsPeriodos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents grsEsAguinaldo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graIdConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoConcepto1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graNombreConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graNombreTipoCOncepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graNombreQuePide As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graValor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graNombreTipoRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graIdLegajo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graIdTipoConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graIdQuePide As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graPeriodos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graIdTipoRecibo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents graEsAguinaldo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
