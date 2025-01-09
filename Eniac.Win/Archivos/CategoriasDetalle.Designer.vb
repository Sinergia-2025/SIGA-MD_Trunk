<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CategoriasDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
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
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CategoriasDetalle))
        Me.lblNombre = New Eniac.Controles.Label()
        Me.txtNombreCategoria = New Eniac.Controles.TextBox()
        Me.lblId = New Eniac.Controles.Label()
        Me.txtCategoria = New Eniac.Controles.TextBox()
        Me.txtDescuentoRecargo = New Eniac.Controles.TextBox()
        Me.lblDescuentoRecargo = New Eniac.Controles.Label()
        Me.cmbCajas = New Eniac.Controles.ComboBox()
        Me.chbCaja = New Eniac.Controles.CheckBox()
        Me.chbTipoDeComprobante = New Eniac.Controles.CheckBox()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.UcCuentas1 = New Eniac.Win.ucCuentas()
        Me.chbIntereses = New Eniac.Controles.CheckBox()
        Me.cmbIntereses = New Eniac.Controles.ComboBox()
        Me.UcCuentas2 = New Eniac.Win.ucCuentas()
        Me.lblCuentaSecundaria = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.lblConcepto = New Eniac.Controles.Label()
        Me.chbInteresesCuotas = New Eniac.Controles.CheckBox()
        Me.cmbInteresesCuotas = New Eniac.Controles.ComboBox()
        Me.chbRequiereRevisionAdministrativa = New Eniac.Controles.CheckBox()
        Me.txtGrupo = New Eniac.Controles.TextBox()
        Me.lblGrupo = New Eniac.Controles.Label()
        Me.tbcCategoria = New System.Windows.Forms.TabControl()
        Me.tbpDetalle = New System.Windows.Forms.TabPage()
        Me.chbForeColor = New Eniac.Controles.CheckBox()
        Me.chbBackColor = New Eniac.Controles.CheckBox()
        Me.btnForeColor = New System.Windows.Forms.Button()
        Me.txtColor = New Eniac.Controles.TextBox()
        Me.lblColor = New Eniac.Controles.Label()
        Me.btnBackColor = New System.Windows.Forms.Button()
        Me.txtComisiones = New Eniac.Controles.TextBox()
        Me.lblComisiones = New Eniac.Controles.Label()
        Me.txtNivelAutorizacion = New Eniac.Controles.TextBox()
        Me.lblNivelAutorizacion = New Eniac.Controles.Label()
        Me.tbpDescuentos = New System.Windows.Forms.TabPage()
        Me.tbcDescuentosDetalle = New System.Windows.Forms.TabControl()
        Me.tbpRubro = New System.Windows.Forms.TabPage()
        Me.Label4 = New Eniac.Controles.Label()
      Me.bscNombreRubro0 = New Eniac.Controles.Buscador2()
      Me.bscCodigoRubro0 = New Eniac.Controles.Buscador2()
      Me.dgvComisionesRubros = New Eniac.Controles.DataGridView()
        Me.IdCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargoPorc1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnRefrescarRubros = New System.Windows.Forms.Button()
        Me.lblDescuentoRubros = New Eniac.Controles.Label()
        Me.btnEliminarRubros = New Eniac.Controles.Button()
        Me.txtDescuentoRubros = New Eniac.Controles.TextBox()
        Me.btnInsertarRubros = New Eniac.Controles.Button()
        Me.tbpSubRubro = New System.Windows.Forms.TabPage()
        Me.lblSubRubro = New Eniac.Controles.Label()
        Me.lblRubro = New Eniac.Controles.Label()
      Me.bscCodigoSubRubro1 = New Eniac.Controles.Buscador2()
      Me.bscNombreSubRubro1 = New Eniac.Controles.Buscador2()
      Me.bscNombreRubro1 = New Eniac.Controles.Buscador2()
      Me.bscCodigoRubro1 = New Eniac.Controles.Buscador2()
      Me.btnRefrescarSubRubros = New System.Windows.Forms.Button()
        Me.btnEliminarSubRubros = New Eniac.Controles.Button()
        Me.btnInsertarSubRubros = New Eniac.Controles.Button()
        Me.txtDescuentoSubRubros = New Eniac.Controles.TextBox()
        Me.lblDescuentoSubRubros = New Eniac.Controles.Label()
        Me.dgvComisionesSubRubros = New Eniac.Controles.DataGridView()
        Me.IdCategoriaTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargoPorc2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpSubSubRubro = New System.Windows.Forms.TabPage()
      Me.bscCodigoSubSubRubro2 = New Eniac.Controles.Buscador2()
      Me.bscNombreSubSubRubro2 = New Eniac.Controles.Buscador2()
      Me.Label1 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
      Me.bscCodigoSubRubro2 = New Eniac.Controles.Buscador2()
      Me.bscNombreSubRubro2 = New Eniac.Controles.Buscador2()
      Me.bscNombreRubro2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoRubro2 = New Eniac.Controles.Buscador2()
      Me.btnRefrescarSubSubRubro = New System.Windows.Forms.Button()
        Me.btnEliminarSubSubRubro = New Eniac.Controles.Button()
        Me.btnInsertarSubSubRubro = New Eniac.Controles.Button()
        Me.lblDescuentoSubSubRubro = New Eniac.Controles.Label()
        Me.txtDescuentoSubSubRubro = New Eniac.Controles.TextBox()
        Me.dgvComisionesSubSubRubros = New Eniac.Controles.DataGridView()
        Me.IdCategoriaTres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdRubroTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreRubroTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSubRubroTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSubRubroTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSubSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSubSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescuentoRecargoPorc3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New Eniac.Controles.Label()
        Me.tbpLicencias = New System.Windows.Forms.TabPage()
        Me.chbActualizarAplicacion = New Eniac.Controles.CheckBox()
        Me.chbActualizarVersion = New Eniac.Controles.CheckBox()
        Me.chbControlarBackup = New Eniac.Controles.CheckBox()
        Me.tbpMarina = New System.Windows.Forms.TabPage()
        Me.cmbAdquiereAcciones = New Eniac.Controles.ComboBox()
        Me.lblAdquiereAcciones = New Eniac.Controles.Label()
        Me.chbLimiteMesesDeudaBotado = New Eniac.Controles.CheckBox()
        Me.cmbCategoriaInversionista = New Eniac.Controles.ComboBox()
        Me.cmbAdquiereCamas = New Eniac.Controles.ComboBox()
        Me.lblAdquiereCamas = New Eniac.Controles.Label()
        Me.chbCategoriaInversionista = New Eniac.Controles.CheckBox()
        Me.txtLimiteMesesDeudaBotado = New Eniac.Controles.TextBox()
        Me.cmbPideEmbarcacion = New Eniac.Controles.ComboBox()
        Me.lblPideEmbarcacion = New Eniac.Controles.Label()
        Me.chbPerteneceAlComplejo = New Eniac.Controles.CheckBox()
        Me.chbTPFisicaDatosAdicionales = New Eniac.Controles.CheckBox()
        Me.chbPideConyuge = New Eniac.Controles.CheckBox()
        Me.chbFirmaMandato = New Eniac.Controles.CheckBox()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.lblImporteGtosAdm = New Eniac.Controles.Label()
        Me.txtImporteGtosAdm = New Eniac.Controles.TextBox()
        Me.chbPagaExpensas = New Eniac.Controles.CheckBox()
        Me.chbPagaAlquiler = New Eniac.Controles.CheckBox()
        Me.tbcCategoria.SuspendLayout()
        Me.tbpDetalle.SuspendLayout()
        Me.tbpDescuentos.SuspendLayout()
        Me.tbcDescuentosDetalle.SuspendLayout()
        Me.tbpRubro.SuspendLayout()
        CType(Me.dgvComisionesRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpSubRubro.SuspendLayout()
        CType(Me.dgvComisionesSubRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpSubSubRubro.SuspendLayout()
        CType(Me.dgvComisionesSubSubRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpLicencias.SuspendLayout()
        Me.tbpMarina.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(483, 352)
        Me.btnAceptar.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(569, 352)
        Me.btnCancelar.TabIndex = 4
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(382, 352)
        Me.btnCopiar.TabIndex = 7
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(322, 352)
        Me.btnAplicar.TabIndex = 6
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(12, 36)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombreCategoria
        '
        Me.txtNombreCategoria.BindearPropiedadControl = "Text"
        Me.txtNombreCategoria.BindearPropiedadEntidad = "NombreCategoria"
        Me.txtNombreCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCategoria.Formato = ""
        Me.txtNombreCategoria.IsDecimal = False
        Me.txtNombreCategoria.IsNumber = False
        Me.txtNombreCategoria.IsPK = False
        Me.txtNombreCategoria.IsRequired = True
        Me.txtNombreCategoria.Key = ""
        Me.txtNombreCategoria.LabelAsoc = Me.lblNombre
        Me.txtNombreCategoria.Location = New System.Drawing.Point(61, 32)
        Me.txtNombreCategoria.MaxLength = 30
        Me.txtNombreCategoria.Name = "txtNombreCategoria"
        Me.txtNombreCategoria.Size = New System.Drawing.Size(394, 20)
        Me.txtNombreCategoria.TabIndex = 1
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(12, 11)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 4
        Me.lblId.Text = "Código"
        '
        'txtCategoria
        '
        Me.txtCategoria.BindearPropiedadControl = "Text"
        Me.txtCategoria.BindearPropiedadEntidad = "IdCategoria"
        Me.txtCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCategoria.Formato = ""
        Me.txtCategoria.IsDecimal = False
        Me.txtCategoria.IsNumber = True
        Me.txtCategoria.IsPK = True
        Me.txtCategoria.IsRequired = True
        Me.txtCategoria.Key = ""
        Me.txtCategoria.LabelAsoc = Me.lblId
        Me.txtCategoria.Location = New System.Drawing.Point(61, 8)
        Me.txtCategoria.MaxLength = 3
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(42, 20)
        Me.txtCategoria.TabIndex = 0
        Me.txtCategoria.Text = "0"
        Me.txtCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescuentoRecargo
        '
        Me.txtDescuentoRecargo.BindearPropiedadControl = "Text"
        Me.txtDescuentoRecargo.BindearPropiedadEntidad = "DescuentoRecargo"
        Me.txtDescuentoRecargo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargo.Formato = "##0.00"
        Me.txtDescuentoRecargo.IsDecimal = True
        Me.txtDescuentoRecargo.IsNumber = True
        Me.txtDescuentoRecargo.IsPK = False
        Me.txtDescuentoRecargo.IsRequired = True
        Me.txtDescuentoRecargo.Key = ""
        Me.txtDescuentoRecargo.LabelAsoc = Me.lblDescuentoRecargo
        Me.txtDescuentoRecargo.Location = New System.Drawing.Point(574, 16)
        Me.txtDescuentoRecargo.MaxLength = 5
        Me.txtDescuentoRecargo.Name = "txtDescuentoRecargo"
        Me.txtDescuentoRecargo.Size = New System.Drawing.Size(54, 20)
        Me.txtDescuentoRecargo.TabIndex = 23
        Me.txtDescuentoRecargo.Text = "0,00"
        Me.txtDescuentoRecargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoRecargo
        '
        Me.lblDescuentoRecargo.AutoSize = True
        Me.lblDescuentoRecargo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargo.LabelAsoc = Nothing
        Me.lblDescuentoRecargo.Location = New System.Drawing.Point(474, 20)
        Me.lblDescuentoRecargo.Name = "lblDescuentoRecargo"
        Me.lblDescuentoRecargo.Size = New System.Drawing.Size(96, 13)
        Me.lblDescuentoRecargo.TabIndex = 22
        Me.lblDescuentoRecargo.Text = "Descto. / Recargo"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = "SelectedValue"
        Me.cmbCajas.BindearPropiedadEntidad = "IdCaja"
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Enabled = False
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Nothing
        Me.cmbCajas.Location = New System.Drawing.Point(72, 42)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
        Me.cmbCajas.TabIndex = 5
        '
        'chbCaja
        '
        Me.chbCaja.AutoSize = True
        Me.chbCaja.BindearPropiedadControl = Nothing
        Me.chbCaja.BindearPropiedadEntidad = Nothing
        Me.chbCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCaja.IsPK = False
        Me.chbCaja.IsRequired = False
        Me.chbCaja.Key = Nothing
        Me.chbCaja.LabelAsoc = Nothing
        Me.chbCaja.Location = New System.Drawing.Point(15, 44)
        Me.chbCaja.Name = "chbCaja"
        Me.chbCaja.Size = New System.Drawing.Size(47, 17)
        Me.chbCaja.TabIndex = 4
        Me.chbCaja.Text = "Caja"
        Me.chbCaja.UseVisualStyleBackColor = True
        '
        'chbTipoDeComprobante
        '
        Me.chbTipoDeComprobante.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbTipoDeComprobante.AutoSize = True
        Me.chbTipoDeComprobante.BindearPropiedadControl = Nothing
        Me.chbTipoDeComprobante.BindearPropiedadEntidad = Nothing
        Me.chbTipoDeComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoDeComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoDeComprobante.IsPK = False
        Me.chbTipoDeComprobante.IsRequired = False
        Me.chbTipoDeComprobante.Key = Nothing
        Me.chbTipoDeComprobante.LabelAsoc = Nothing
        Me.chbTipoDeComprobante.Location = New System.Drawing.Point(447, 44)
        Me.chbTipoDeComprobante.Name = "chbTipoDeComprobante"
        Me.chbTipoDeComprobante.Size = New System.Drawing.Size(60, 17)
        Me.chbTipoDeComprobante.TabIndex = 24
        Me.chbTipoDeComprobante.Text = "Recibo"
        Me.chbTipoDeComprobante.UseVisualStyleBackColor = True
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTiposComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = "IdTipoComprobante"
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Enabled = False
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(504, 42)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(125, 21)
        Me.cmbTiposComprobantes.TabIndex = 25
        '
        'UcCuentas1
        '
        Me.UcCuentas1.Cuenta = Nothing
        Me.UcCuentas1.Location = New System.Drawing.Point(20, 183)
        Me.UcCuentas1.Name = "UcCuentas1"
        Me.UcCuentas1.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentas1.TabIndex = 19
        '
        'chbIntereses
        '
        Me.chbIntereses.AutoSize = True
        Me.chbIntereses.BindearPropiedadControl = Nothing
        Me.chbIntereses.BindearPropiedadEntidad = Nothing
        Me.chbIntereses.ForeColorFocus = System.Drawing.Color.Red
        Me.chbIntereses.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbIntereses.IsPK = False
        Me.chbIntereses.IsRequired = False
        Me.chbIntereses.Key = Nothing
        Me.chbIntereses.LabelAsoc = Nothing
        Me.chbIntereses.Location = New System.Drawing.Point(15, 71)
        Me.chbIntereses.Name = "chbIntereses"
        Me.chbIntereses.Size = New System.Drawing.Size(141, 17)
        Me.chbIntereses.TabIndex = 6
        Me.chbIntereses.Text = "Intereses para Cobranza"
        Me.chbIntereses.UseVisualStyleBackColor = True
        '
        'cmbIntereses
        '
        Me.cmbIntereses.BindearPropiedadControl = ""
        Me.cmbIntereses.BindearPropiedadEntidad = ""
        Me.cmbIntereses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIntereses.Enabled = False
        Me.cmbIntereses.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIntereses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIntereses.FormattingEnabled = True
        Me.cmbIntereses.IsPK = False
        Me.cmbIntereses.IsRequired = False
        Me.cmbIntereses.Key = Nothing
        Me.cmbIntereses.LabelAsoc = Nothing
        Me.cmbIntereses.Location = New System.Drawing.Point(168, 69)
        Me.cmbIntereses.Name = "cmbIntereses"
        Me.cmbIntereses.Size = New System.Drawing.Size(184, 21)
        Me.cmbIntereses.TabIndex = 7
        '
        'UcCuentas2
        '
        Me.UcCuentas2.Cuenta = Nothing
        Me.UcCuentas2.Location = New System.Drawing.Point(20, 213)
        Me.UcCuentas2.Name = "UcCuentas2"
        Me.UcCuentas2.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentas2.TabIndex = 20
        '
        'lblCuentaSecundaria
        '
        Me.lblCuentaSecundaria.AutoSize = True
        Me.lblCuentaSecundaria.LabelAsoc = Nothing
        Me.lblCuentaSecundaria.Location = New System.Drawing.Point(470, 216)
        Me.lblCuentaSecundaria.Name = "lblCuentaSecundaria"
        Me.lblCuentaSecundaria.Size = New System.Drawing.Size(65, 13)
        Me.lblCuentaSecundaria.TabIndex = 21
        Me.lblCuentaSecundaria.Text = "(secundaria)"
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = True
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(190, 154)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(274, 20)
        Me.bscProducto2.TabIndex = 18
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = True
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(64, 154)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(123, 20)
        Me.bscCodigoProducto2.TabIndex = 17
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.LabelAsoc = Nothing
        Me.lblConcepto.Location = New System.Drawing.Point(15, 157)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(50, 13)
        Me.lblConcepto.TabIndex = 16
        Me.lblConcepto.Text = "Producto"
        '
        'chbInteresesCuotas
        '
        Me.chbInteresesCuotas.AutoSize = True
        Me.chbInteresesCuotas.BindearPropiedadControl = Nothing
        Me.chbInteresesCuotas.BindearPropiedadEntidad = Nothing
        Me.chbInteresesCuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbInteresesCuotas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbInteresesCuotas.IsPK = False
        Me.chbInteresesCuotas.IsRequired = False
        Me.chbInteresesCuotas.Key = Nothing
        Me.chbInteresesCuotas.LabelAsoc = Nothing
        Me.chbInteresesCuotas.Location = New System.Drawing.Point(15, 98)
        Me.chbInteresesCuotas.Name = "chbInteresesCuotas"
        Me.chbInteresesCuotas.Size = New System.Drawing.Size(129, 17)
        Me.chbInteresesCuotas.TabIndex = 8
        Me.chbInteresesCuotas.Text = "Intereses para Cuotas"
        Me.chbInteresesCuotas.UseVisualStyleBackColor = True
        '
        'cmbInteresesCuotas
        '
        Me.cmbInteresesCuotas.BindearPropiedadControl = ""
        Me.cmbInteresesCuotas.BindearPropiedadEntidad = ""
        Me.cmbInteresesCuotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbInteresesCuotas.Enabled = False
        Me.cmbInteresesCuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbInteresesCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbInteresesCuotas.FormattingEnabled = True
        Me.cmbInteresesCuotas.IsPK = False
        Me.cmbInteresesCuotas.IsRequired = False
        Me.cmbInteresesCuotas.Key = Nothing
        Me.cmbInteresesCuotas.LabelAsoc = Nothing
        Me.cmbInteresesCuotas.Location = New System.Drawing.Point(168, 96)
        Me.cmbInteresesCuotas.Name = "cmbInteresesCuotas"
        Me.cmbInteresesCuotas.Size = New System.Drawing.Size(184, 21)
        Me.cmbInteresesCuotas.TabIndex = 9
        '
        'chbRequiereRevisionAdministrativa
        '
        Me.chbRequiereRevisionAdministrativa.AutoSize = True
        Me.chbRequiereRevisionAdministrativa.BindearPropiedadControl = "Checked"
        Me.chbRequiereRevisionAdministrativa.BindearPropiedadEntidad = "RequiereRevisionAdministrativa"
        Me.chbRequiereRevisionAdministrativa.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereRevisionAdministrativa.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereRevisionAdministrativa.IsPK = False
        Me.chbRequiereRevisionAdministrativa.IsRequired = False
        Me.chbRequiereRevisionAdministrativa.Key = Nothing
        Me.chbRequiereRevisionAdministrativa.LabelAsoc = Nothing
        Me.chbRequiereRevisionAdministrativa.Location = New System.Drawing.Point(447, 98)
        Me.chbRequiereRevisionAdministrativa.Name = "chbRequiereRevisionAdministrativa"
        Me.chbRequiereRevisionAdministrativa.Size = New System.Drawing.Size(181, 17)
        Me.chbRequiereRevisionAdministrativa.TabIndex = 28
        Me.chbRequiereRevisionAdministrativa.Text = "Requiere Revisión Administrativa"
        Me.chbRequiereRevisionAdministrativa.UseVisualStyleBackColor = True
        '
        'txtGrupo
        '
        Me.txtGrupo.BindearPropiedadControl = "Text"
        Me.txtGrupo.BindearPropiedadEntidad = "IdGrupoCategoria"
        Me.txtGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtGrupo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtGrupo.Formato = ""
        Me.txtGrupo.IsDecimal = False
        Me.txtGrupo.IsNumber = False
        Me.txtGrupo.IsPK = False
        Me.txtGrupo.IsRequired = True
        Me.txtGrupo.Key = ""
        Me.txtGrupo.LabelAsoc = Me.lblGrupo
        Me.txtGrupo.Location = New System.Drawing.Point(72, 16)
        Me.txtGrupo.MaxLength = 15
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Size = New System.Drawing.Size(125, 20)
        Me.txtGrupo.TabIndex = 1
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGrupo.LabelAsoc = Nothing
        Me.lblGrupo.Location = New System.Drawing.Point(15, 20)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(36, 13)
        Me.lblGrupo.TabIndex = 0
        Me.lblGrupo.Text = "Grupo"
        '
        'tbcCategoria
        '
        Me.tbcCategoria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcCategoria.Controls.Add(Me.tbpDetalle)
        Me.tbcCategoria.Controls.Add(Me.tbpDescuentos)
        Me.tbcCategoria.Controls.Add(Me.tbpLicencias)
        Me.tbcCategoria.Controls.Add(Me.tbpMarina)
        Me.tbcCategoria.Location = New System.Drawing.Point(8, 56)
        Me.tbcCategoria.Name = "tbcCategoria"
        Me.tbcCategoria.SelectedIndex = 0
        Me.tbcCategoria.Size = New System.Drawing.Size(642, 288)
        Me.tbcCategoria.TabIndex = 3
        '
        'tbpDetalle
        '
        Me.tbpDetalle.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDetalle.Controls.Add(Me.chbForeColor)
        Me.tbpDetalle.Controls.Add(Me.chbBackColor)
        Me.tbpDetalle.Controls.Add(Me.btnForeColor)
        Me.tbpDetalle.Controls.Add(Me.txtColor)
        Me.tbpDetalle.Controls.Add(Me.lblColor)
        Me.tbpDetalle.Controls.Add(Me.btnBackColor)
        Me.tbpDetalle.Controls.Add(Me.txtComisiones)
        Me.tbpDetalle.Controls.Add(Me.lblComisiones)
        Me.tbpDetalle.Controls.Add(Me.txtNivelAutorizacion)
        Me.tbpDetalle.Controls.Add(Me.lblNivelAutorizacion)
        Me.tbpDetalle.Controls.Add(Me.txtDescuentoRecargo)
        Me.tbpDetalle.Controls.Add(Me.cmbTiposComprobantes)
        Me.tbpDetalle.Controls.Add(Me.UcCuentas2)
        Me.tbpDetalle.Controls.Add(Me.bscProducto2)
        Me.tbpDetalle.Controls.Add(Me.UcCuentas1)
        Me.tbpDetalle.Controls.Add(Me.lblCuentaSecundaria)
        Me.tbpDetalle.Controls.Add(Me.bscCodigoProducto2)
        Me.tbpDetalle.Controls.Add(Me.chbRequiereRevisionAdministrativa)
        Me.tbpDetalle.Controls.Add(Me.lblConcepto)
        Me.tbpDetalle.Controls.Add(Me.txtGrupo)
        Me.tbpDetalle.Controls.Add(Me.lblDescuentoRecargo)
        Me.tbpDetalle.Controls.Add(Me.lblGrupo)
        Me.tbpDetalle.Controls.Add(Me.chbCaja)
        Me.tbpDetalle.Controls.Add(Me.cmbCajas)
        Me.tbpDetalle.Controls.Add(Me.cmbInteresesCuotas)
        Me.tbpDetalle.Controls.Add(Me.chbTipoDeComprobante)
        Me.tbpDetalle.Controls.Add(Me.chbInteresesCuotas)
        Me.tbpDetalle.Controls.Add(Me.cmbIntereses)
        Me.tbpDetalle.Controls.Add(Me.chbIntereses)
        Me.tbpDetalle.Location = New System.Drawing.Point(4, 22)
        Me.tbpDetalle.Name = "tbpDetalle"
        Me.tbpDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDetalle.Size = New System.Drawing.Size(634, 262)
        Me.tbpDetalle.TabIndex = 0
        Me.tbpDetalle.Text = "Detalle"
        '
        'chbForeColor
        '
        Me.chbForeColor.AutoSize = True
        Me.chbForeColor.BindearPropiedadControl = ""
        Me.chbForeColor.BindearPropiedadEntidad = ""
        Me.chbForeColor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbForeColor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbForeColor.IsPK = False
        Me.chbForeColor.IsRequired = False
        Me.chbForeColor.Key = Nothing
        Me.chbForeColor.LabelAsoc = Nothing
        Me.chbForeColor.Location = New System.Drawing.Point(293, 127)
        Me.chbForeColor.Name = "chbForeColor"
        Me.chbForeColor.Size = New System.Drawing.Size(15, 14)
        Me.chbForeColor.TabIndex = 14
        Me.chbForeColor.UseVisualStyleBackColor = True
        '
        'chbBackColor
        '
        Me.chbBackColor.AutoSize = True
        Me.chbBackColor.BindearPropiedadControl = ""
        Me.chbBackColor.BindearPropiedadEntidad = ""
        Me.chbBackColor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbBackColor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbBackColor.IsPK = False
        Me.chbBackColor.IsRequired = False
        Me.chbBackColor.Key = Nothing
        Me.chbBackColor.LabelAsoc = Nothing
        Me.chbBackColor.Location = New System.Drawing.Point(204, 127)
        Me.chbBackColor.Name = "chbBackColor"
        Me.chbBackColor.Size = New System.Drawing.Size(15, 14)
        Me.chbBackColor.TabIndex = 12
        Me.chbBackColor.UseVisualStyleBackColor = True
        '
        'btnForeColor
        '
        Me.btnForeColor.Enabled = False
        Me.btnForeColor.Location = New System.Drawing.Point(314, 123)
        Me.btnForeColor.Name = "btnForeColor"
        Me.btnForeColor.Size = New System.Drawing.Size(62, 23)
        Me.btnForeColor.TabIndex = 15
        Me.btnForeColor.Text = "Letra"
        Me.btnForeColor.UseVisualStyleBackColor = True
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = ""
        Me.txtColor.BindearPropiedadEntidad = ""
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Me.lblColor
        Me.txtColor.Location = New System.Drawing.Point(79, 124)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(119, 20)
        Me.txtColor.TabIndex = 11
        Me.txtColor.TabStop = False
        Me.txtColor.Text = "Texto Ejemplo"
        Me.txtColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.LabelAsoc = Nothing
        Me.lblColor.Location = New System.Drawing.Point(12, 128)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(31, 13)
        Me.lblColor.TabIndex = 10
        Me.lblColor.Text = "Color"
        '
        'btnBackColor
        '
        Me.btnBackColor.Enabled = False
        Me.btnBackColor.Location = New System.Drawing.Point(225, 123)
        Me.btnBackColor.Name = "btnBackColor"
        Me.btnBackColor.Size = New System.Drawing.Size(62, 23)
        Me.btnBackColor.TabIndex = 13
        Me.btnBackColor.Text = "Fondo"
        Me.btnBackColor.UseVisualStyleBackColor = True
        '
        'txtComisiones
        '
        Me.txtComisiones.BindearPropiedadControl = "Text"
        Me.txtComisiones.BindearPropiedadEntidad = "Comisiones"
        Me.txtComisiones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComisiones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComisiones.Formato = "N4"
        Me.txtComisiones.IsDecimal = True
        Me.txtComisiones.IsNumber = True
        Me.txtComisiones.IsPK = False
        Me.txtComisiones.IsRequired = False
        Me.txtComisiones.Key = ""
        Me.txtComisiones.LabelAsoc = Me.lblComisiones
        Me.txtComisiones.Location = New System.Drawing.Point(574, 69)
        Me.txtComisiones.MaxLength = 7
        Me.txtComisiones.Name = "txtComisiones"
        Me.txtComisiones.Size = New System.Drawing.Size(54, 20)
        Me.txtComisiones.TabIndex = 27
        Me.txtComisiones.Text = "0,0000"
        Me.txtComisiones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComisiones
        '
        Me.lblComisiones.AutoSize = True
        Me.lblComisiones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComisiones.LabelAsoc = Nothing
        Me.lblComisiones.Location = New System.Drawing.Point(510, 73)
        Me.lblComisiones.Name = "lblComisiones"
        Me.lblComisiones.Size = New System.Drawing.Size(60, 13)
        Me.lblComisiones.TabIndex = 26
        Me.lblComisiones.Text = "% Comisión"
        '
        'txtNivelAutorizacion
        '
        Me.txtNivelAutorizacion.BindearPropiedadControl = "Text"
        Me.txtNivelAutorizacion.BindearPropiedadEntidad = "NivelAutorizacion"
        Me.txtNivelAutorizacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNivelAutorizacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNivelAutorizacion.Formato = ""
        Me.txtNivelAutorizacion.IsDecimal = False
        Me.txtNivelAutorizacion.IsNumber = True
        Me.txtNivelAutorizacion.IsPK = False
        Me.txtNivelAutorizacion.IsRequired = True
        Me.txtNivelAutorizacion.Key = ""
        Me.txtNivelAutorizacion.LabelAsoc = Me.lblNivelAutorizacion
        Me.txtNivelAutorizacion.Location = New System.Drawing.Point(324, 16)
        Me.txtNivelAutorizacion.MaxLength = 12
        Me.txtNivelAutorizacion.Name = "txtNivelAutorizacion"
        Me.txtNivelAutorizacion.Size = New System.Drawing.Size(42, 20)
        Me.txtNivelAutorizacion.TabIndex = 3
        Me.txtNivelAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNivelAutorizacion
        '
        Me.lblNivelAutorizacion.AutoSize = True
        Me.lblNivelAutorizacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelAutorizacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNivelAutorizacion.LabelAsoc = Nothing
        Me.lblNivelAutorizacion.Location = New System.Drawing.Point(211, 20)
        Me.lblNivelAutorizacion.Name = "lblNivelAutorizacion"
        Me.lblNivelAutorizacion.Size = New System.Drawing.Size(107, 13)
        Me.lblNivelAutorizacion.TabIndex = 2
        Me.lblNivelAutorizacion.Text = "Nivel de Autorización"
        '
        'tbpDescuentos
        '
        Me.tbpDescuentos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDescuentos.Controls.Add(Me.tbcDescuentosDetalle)
        Me.tbpDescuentos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDescuentos.Name = "tbpDescuentos"
        Me.tbpDescuentos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDescuentos.Size = New System.Drawing.Size(634, 262)
        Me.tbpDescuentos.TabIndex = 1
        Me.tbpDescuentos.Text = "Descuentos"
        '
        'tbcDescuentosDetalle
        '
        Me.tbcDescuentosDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDescuentosDetalle.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tbcDescuentosDetalle.Controls.Add(Me.tbpRubro)
        Me.tbcDescuentosDetalle.Controls.Add(Me.tbpSubRubro)
        Me.tbcDescuentosDetalle.Controls.Add(Me.tbpSubSubRubro)
        Me.tbcDescuentosDetalle.Location = New System.Drawing.Point(5, 6)
        Me.tbcDescuentosDetalle.Name = "tbcDescuentosDetalle"
        Me.tbcDescuentosDetalle.SelectedIndex = 0
        Me.tbcDescuentosDetalle.Size = New System.Drawing.Size(623, 250)
        Me.tbcDescuentosDetalle.TabIndex = 0
        '
        'tbpRubro
        '
        Me.tbpRubro.Controls.Add(Me.Label4)
        Me.tbpRubro.Controls.Add(Me.bscNombreRubro0)
        Me.tbpRubro.Controls.Add(Me.bscCodigoRubro0)
        Me.tbpRubro.Controls.Add(Me.dgvComisionesRubros)
        Me.tbpRubro.Controls.Add(Me.btnRefrescarRubros)
        Me.tbpRubro.Controls.Add(Me.lblDescuentoRubros)
        Me.tbpRubro.Controls.Add(Me.btnEliminarRubros)
        Me.tbpRubro.Controls.Add(Me.txtDescuentoRubros)
        Me.tbpRubro.Controls.Add(Me.btnInsertarRubros)
        Me.tbpRubro.Location = New System.Drawing.Point(4, 25)
        Me.tbpRubro.Name = "tbpRubro"
        Me.tbpRubro.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpRubro.Size = New System.Drawing.Size(615, 221)
        Me.tbpRubro.TabIndex = 0
        Me.tbpRubro.Text = "Rubro"
        Me.tbpRubro.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(34, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Rubro"
      '
      'bscNombreRubro0
      '
      Me.bscNombreRubro0.BindearPropiedadControl = Nothing
      Me.bscNombreRubro0.BindearPropiedadEntidad = Nothing
      Me.bscNombreRubro0.Datos = Nothing
      Me.bscNombreRubro0.FilaDevuelta = Nothing
        Me.bscNombreRubro0.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreRubro0.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreRubro0.IsDecimal = False
        Me.bscNombreRubro0.IsNumber = False
        Me.bscNombreRubro0.IsPK = True
        Me.bscNombreRubro0.IsRequired = True
        Me.bscNombreRubro0.Key = ""
        Me.bscNombreRubro0.LabelAsoc = Nothing
        Me.bscNombreRubro0.Location = New System.Drawing.Point(168, 21)
        Me.bscNombreRubro0.MaxLengh = "32767"
        Me.bscNombreRubro0.Name = "bscNombreRubro0"
        Me.bscNombreRubro0.Permitido = True
        Me.bscNombreRubro0.Selecciono = False
        Me.bscNombreRubro0.Size = New System.Drawing.Size(263, 20)
        Me.bscNombreRubro0.TabIndex = 2
      '
      'bscCodigoRubro0
      '
      Me.bscCodigoRubro0.BindearPropiedadControl = "Text"
      Me.bscCodigoRubro0.BindearPropiedadEntidad = "IdRubro"
      Me.bscCodigoRubro0.Datos = Nothing
      Me.bscCodigoRubro0.FilaDevuelta = Nothing
        Me.bscCodigoRubro0.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro0.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro0.IsDecimal = False
        Me.bscCodigoRubro0.IsNumber = True
        Me.bscCodigoRubro0.IsPK = True
        Me.bscCodigoRubro0.IsRequired = True
        Me.bscCodigoRubro0.Key = ""
        Me.bscCodigoRubro0.LabelAsoc = Me.Label4
        Me.bscCodigoRubro0.Location = New System.Drawing.Point(71, 21)
        Me.bscCodigoRubro0.MaxLengh = "32767"
        Me.bscCodigoRubro0.Name = "bscCodigoRubro0"
        Me.bscCodigoRubro0.Permitido = True
        Me.bscCodigoRubro0.Selecciono = False
        Me.bscCodigoRubro0.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoRubro0.TabIndex = 1
      '
      'dgvComisionesRubros
      '
      Me.dgvComisionesRubros.AllowUserToAddRows = False
        Me.dgvComisionesRubros.AllowUserToDeleteRows = False
        Me.dgvComisionesRubros.AllowUserToResizeColumns = False
        Me.dgvComisionesRubros.AllowUserToResizeRows = False
        Me.dgvComisionesRubros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvComisionesRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComisionesRubros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCategoria, Me.Codigo, Me.Nombre, Me.DescuentoRecargoPorc1})
        Me.dgvComisionesRubros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComisionesRubros.Location = New System.Drawing.Point(10, 54)
        Me.dgvComisionesRubros.Name = "dgvComisionesRubros"
        Me.dgvComisionesRubros.RowHeadersVisible = False
        Me.dgvComisionesRubros.RowHeadersWidth = 10
        Me.dgvComisionesRubros.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvComisionesRubros.RowTemplate.Height = 18
        Me.dgvComisionesRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComisionesRubros.Size = New System.Drawing.Size(551, 145)
        Me.dgvComisionesRubros.TabIndex = 7
        '
        'IdCategoria
        '
        Me.IdCategoria.DataPropertyName = "IdCategoria"
        Me.IdCategoria.HeaderText = "IdCategoria"
        Me.IdCategoria.Name = "IdCategoria"
        Me.IdCategoria.Visible = False
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "IdRubro"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Codigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 80
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Nombre.DataPropertyName = "NombreRubro"
        Me.Nombre.HeaderText = "Rubro"
        Me.Nombre.Name = "Nombre"
        '
        'DescuentoRecargoPorc1
        '
        Me.DescuentoRecargoPorc1.DataPropertyName = "DescuentoRecargoPorc1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DescuentoRecargoPorc1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DescuentoRecargoPorc1.HeaderText = "Desc./Rec."
        Me.DescuentoRecargoPorc1.Name = "DescuentoRecargoPorc1"
        '
        'btnRefrescarRubros
        '
        Me.btnRefrescarRubros.Image = CType(resources.GetObject("btnRefrescarRubros.Image"), System.Drawing.Image)
        Me.btnRefrescarRubros.Location = New System.Drawing.Point(12, 20)
        Me.btnRefrescarRubros.Name = "btnRefrescarRubros"
        Me.btnRefrescarRubros.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarRubros.TabIndex = 0
        Me.btnRefrescarRubros.UseVisualStyleBackColor = True
        '
        'lblDescuentoRubros
        '
        Me.lblDescuentoRubros.AutoSize = True
        Me.lblDescuentoRubros.LabelAsoc = Nothing
        Me.lblDescuentoRubros.Location = New System.Drawing.Point(433, 24)
        Me.lblDescuentoRubros.Name = "lblDescuentoRubros"
        Me.lblDescuentoRubros.Size = New System.Drawing.Size(71, 13)
        Me.lblDescuentoRubros.TabIndex = 3
        Me.lblDescuentoRubros.Text = "% Desc./Rec"
        '
        'btnEliminarRubros
        '
        Me.btnEliminarRubros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarRubros.Image = CType(resources.GetObject("btnEliminarRubros.Image"), System.Drawing.Image)
        Me.btnEliminarRubros.Location = New System.Drawing.Point(571, 97)
        Me.btnEliminarRubros.Name = "btnEliminarRubros"
        Me.btnEliminarRubros.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarRubros.TabIndex = 6
        Me.btnEliminarRubros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarRubros.UseVisualStyleBackColor = True
        '
        'txtDescuentoRubros
        '
        Me.txtDescuentoRubros.BindearPropiedadControl = ""
        Me.txtDescuentoRubros.BindearPropiedadEntidad = ""
        Me.txtDescuentoRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRubros.Formato = "#,##0.00"
        Me.txtDescuentoRubros.IsDecimal = True
        Me.txtDescuentoRubros.IsNumber = True
        Me.txtDescuentoRubros.IsPK = False
        Me.txtDescuentoRubros.IsRequired = False
        Me.txtDescuentoRubros.Key = ""
        Me.txtDescuentoRubros.LabelAsoc = Me.lblDescuentoRubros
        Me.txtDescuentoRubros.Location = New System.Drawing.Point(504, 22)
        Me.txtDescuentoRubros.MaxLength = 7
        Me.txtDescuentoRubros.Name = "txtDescuentoRubros"
        Me.txtDescuentoRubros.Size = New System.Drawing.Size(57, 20)
        Me.txtDescuentoRubros.TabIndex = 4
        Me.txtDescuentoRubros.Text = "0.00"
        Me.txtDescuentoRubros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnInsertarRubros
        '
        Me.btnInsertarRubros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarRubros.Image = CType(resources.GetObject("btnInsertarRubros.Image"), System.Drawing.Image)
        Me.btnInsertarRubros.Location = New System.Drawing.Point(571, 53)
        Me.btnInsertarRubros.Name = "btnInsertarRubros"
        Me.btnInsertarRubros.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarRubros.TabIndex = 5
        Me.btnInsertarRubros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarRubros.UseVisualStyleBackColor = True
        '
        'tbpSubRubro
        '
        Me.tbpSubRubro.Controls.Add(Me.lblSubRubro)
        Me.tbpSubRubro.Controls.Add(Me.lblRubro)
        Me.tbpSubRubro.Controls.Add(Me.bscCodigoSubRubro1)
        Me.tbpSubRubro.Controls.Add(Me.bscNombreSubRubro1)
        Me.tbpSubRubro.Controls.Add(Me.bscNombreRubro1)
        Me.tbpSubRubro.Controls.Add(Me.bscCodigoRubro1)
        Me.tbpSubRubro.Controls.Add(Me.btnRefrescarSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.btnEliminarSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.btnInsertarSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.txtDescuentoSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.dgvComisionesSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.lblDescuentoSubRubros)
        Me.tbpSubRubro.Location = New System.Drawing.Point(4, 25)
        Me.tbpSubRubro.Name = "tbpSubRubro"
        Me.tbpSubRubro.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSubRubro.Size = New System.Drawing.Size(615, 221)
        Me.tbpSubRubro.TabIndex = 1
        Me.tbpSubRubro.Text = "SubRubro"
        Me.tbpSubRubro.UseVisualStyleBackColor = True
        '
        'lblSubRubro
        '
        Me.lblSubRubro.AutoSize = True
        Me.lblSubRubro.LabelAsoc = Nothing
        Me.lblSubRubro.Location = New System.Drawing.Point(27, 38)
        Me.lblSubRubro.Name = "lblSubRubro"
        Me.lblSubRubro.Size = New System.Drawing.Size(55, 13)
        Me.lblSubRubro.TabIndex = 4
        Me.lblSubRubro.Text = "SubRubro"
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(46, 10)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 1
        Me.lblRubro.Text = "Rubro"
      '
      'bscCodigoSubRubro1
      '
      Me.bscCodigoSubRubro1.BindearPropiedadControl = "Text"
      Me.bscCodigoSubRubro1.BindearPropiedadEntidad = "IdSubRubro"
      Me.bscCodigoSubRubro1.Datos = Nothing
      Me.bscCodigoSubRubro1.FilaDevuelta = Nothing
        Me.bscCodigoSubRubro1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoSubRubro1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoSubRubro1.IsDecimal = False
        Me.bscCodigoSubRubro1.IsNumber = True
        Me.bscCodigoSubRubro1.IsPK = True
        Me.bscCodigoSubRubro1.IsRequired = True
        Me.bscCodigoSubRubro1.Key = ""
        Me.bscCodigoSubRubro1.LabelAsoc = Nothing
        Me.bscCodigoSubRubro1.Location = New System.Drawing.Point(83, 35)
        Me.bscCodigoSubRubro1.MaxLengh = "32767"
        Me.bscCodigoSubRubro1.Name = "bscCodigoSubRubro1"
        Me.bscCodigoSubRubro1.Permitido = True
        Me.bscCodigoSubRubro1.Selecciono = False
        Me.bscCodigoSubRubro1.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoSubRubro1.TabIndex = 5
      '
      'bscNombreSubRubro1
      '
      Me.bscNombreSubRubro1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscNombreSubRubro1.BindearPropiedadControl = Nothing
      Me.bscNombreSubRubro1.BindearPropiedadEntidad = Nothing
      Me.bscNombreSubRubro1.Datos = Nothing
      Me.bscNombreSubRubro1.FilaDevuelta = Nothing
        Me.bscNombreSubRubro1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreSubRubro1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreSubRubro1.IsDecimal = False
        Me.bscNombreSubRubro1.IsNumber = False
        Me.bscNombreSubRubro1.IsPK = True
        Me.bscNombreSubRubro1.IsRequired = True
        Me.bscNombreSubRubro1.Key = ""
        Me.bscNombreSubRubro1.LabelAsoc = Nothing
        Me.bscNombreSubRubro1.Location = New System.Drawing.Point(181, 35)
        Me.bscNombreSubRubro1.MaxLengh = "32767"
        Me.bscNombreSubRubro1.Name = "bscNombreSubRubro1"
        Me.bscNombreSubRubro1.Permitido = True
        Me.bscNombreSubRubro1.Selecciono = False
        Me.bscNombreSubRubro1.Size = New System.Drawing.Size(302, 20)
        Me.bscNombreSubRubro1.TabIndex = 6
      '
      'bscNombreRubro1
      '
      Me.bscNombreRubro1.BindearPropiedadControl = Nothing
      Me.bscNombreRubro1.BindearPropiedadEntidad = Nothing
      Me.bscNombreRubro1.Datos = Nothing
      Me.bscNombreRubro1.FilaDevuelta = Nothing
        Me.bscNombreRubro1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreRubro1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreRubro1.IsDecimal = False
        Me.bscNombreRubro1.IsNumber = False
        Me.bscNombreRubro1.IsPK = True
        Me.bscNombreRubro1.IsRequired = True
        Me.bscNombreRubro1.Key = ""
        Me.bscNombreRubro1.LabelAsoc = Nothing
        Me.bscNombreRubro1.Location = New System.Drawing.Point(181, 6)
        Me.bscNombreRubro1.MaxLengh = "32767"
        Me.bscNombreRubro1.Name = "bscNombreRubro1"
        Me.bscNombreRubro1.Permitido = True
        Me.bscNombreRubro1.Selecciono = False
        Me.bscNombreRubro1.Size = New System.Drawing.Size(302, 20)
        Me.bscNombreRubro1.TabIndex = 3
      '
      'bscCodigoRubro1
      '
      Me.bscCodigoRubro1.BindearPropiedadControl = "Text"
      Me.bscCodigoRubro1.BindearPropiedadEntidad = "IdRubro"
      Me.bscCodigoRubro1.Datos = Nothing
      Me.bscCodigoRubro1.FilaDevuelta = Nothing
        Me.bscCodigoRubro1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro1.IsDecimal = False
        Me.bscCodigoRubro1.IsNumber = True
        Me.bscCodigoRubro1.IsPK = True
        Me.bscCodigoRubro1.IsRequired = True
        Me.bscCodigoRubro1.Key = ""
        Me.bscCodigoRubro1.LabelAsoc = Nothing
        Me.bscCodigoRubro1.Location = New System.Drawing.Point(83, 6)
        Me.bscCodigoRubro1.MaxLengh = "32767"
        Me.bscCodigoRubro1.Name = "bscCodigoRubro1"
        Me.bscCodigoRubro1.Permitido = True
        Me.bscCodigoRubro1.Selecciono = False
        Me.bscCodigoRubro1.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoRubro1.TabIndex = 2
      '
      'btnRefrescarSubRubros
      '
      Me.btnRefrescarSubRubros.Image = CType(resources.GetObject("btnRefrescarSubRubros.Image"), System.Drawing.Image)
        Me.btnRefrescarSubRubros.Location = New System.Drawing.Point(14, 6)
        Me.btnRefrescarSubRubros.Name = "btnRefrescarSubRubros"
        Me.btnRefrescarSubRubros.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarSubRubros.TabIndex = 0
        Me.btnRefrescarSubRubros.UseVisualStyleBackColor = True
        '
        'btnEliminarSubRubros
        '
        Me.btnEliminarSubRubros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarSubRubros.Image = CType(resources.GetObject("btnEliminarSubRubros.Image"), System.Drawing.Image)
        Me.btnEliminarSubRubros.Location = New System.Drawing.Point(571, 105)
        Me.btnEliminarSubRubros.Name = "btnEliminarSubRubros"
        Me.btnEliminarSubRubros.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarSubRubros.TabIndex = 8
        Me.btnEliminarSubRubros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarSubRubros.UseVisualStyleBackColor = True
        '
        'btnInsertarSubRubros
        '
        Me.btnInsertarSubRubros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarSubRubros.Image = CType(resources.GetObject("btnInsertarSubRubros.Image"), System.Drawing.Image)
        Me.btnInsertarSubRubros.Location = New System.Drawing.Point(571, 61)
        Me.btnInsertarSubRubros.Name = "btnInsertarSubRubros"
        Me.btnInsertarSubRubros.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarSubRubros.TabIndex = 7
        Me.btnInsertarSubRubros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarSubRubros.UseVisualStyleBackColor = True
        '
        'txtDescuentoSubRubros
        '
        Me.txtDescuentoSubRubros.BindearPropiedadControl = ""
        Me.txtDescuentoSubRubros.BindearPropiedadEntidad = ""
        Me.txtDescuentoSubRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoSubRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoSubRubros.Formato = "#,##0.00"
        Me.txtDescuentoSubRubros.IsDecimal = True
        Me.txtDescuentoSubRubros.IsNumber = True
        Me.txtDescuentoSubRubros.IsPK = False
        Me.txtDescuentoSubRubros.IsRequired = False
        Me.txtDescuentoSubRubros.Key = ""
        Me.txtDescuentoSubRubros.LabelAsoc = Me.lblDescuentoSubRubros
        Me.txtDescuentoSubRubros.Location = New System.Drawing.Point(554, 7)
        Me.txtDescuentoSubRubros.MaxLength = 7
        Me.txtDescuentoSubRubros.Name = "txtDescuentoSubRubros"
        Me.txtDescuentoSubRubros.Size = New System.Drawing.Size(57, 20)
        Me.txtDescuentoSubRubros.TabIndex = 6
        Me.txtDescuentoSubRubros.Text = "0,00"
        Me.txtDescuentoSubRubros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoSubRubros
        '
        Me.lblDescuentoSubRubros.AutoSize = True
        Me.lblDescuentoSubRubros.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoSubRubros.LabelAsoc = Nothing
        Me.lblDescuentoSubRubros.Location = New System.Drawing.Point(485, 11)
        Me.lblDescuentoSubRubros.Name = "lblDescuentoSubRubros"
        Me.lblDescuentoSubRubros.Size = New System.Drawing.Size(71, 13)
        Me.lblDescuentoSubRubros.TabIndex = 5
        Me.lblDescuentoSubRubros.Text = "% Desc./Rec"
        '
        'dgvComisionesSubRubros
        '
        Me.dgvComisionesSubRubros.AllowUserToAddRows = False
        Me.dgvComisionesSubRubros.AllowUserToDeleteRows = False
        Me.dgvComisionesSubRubros.AllowUserToResizeColumns = False
        Me.dgvComisionesSubRubros.AllowUserToResizeRows = False
        Me.dgvComisionesSubRubros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvComisionesSubRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComisionesSubRubros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCategoriaTwo, Me.IdRubro, Me.NombreRubro, Me.IdSubRubro, Me.NombreSubRubro, Me.DescuentoRecargoPorc2})
        Me.dgvComisionesSubRubros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComisionesSubRubros.Location = New System.Drawing.Point(14, 61)
        Me.dgvComisionesSubRubros.Name = "dgvComisionesSubRubros"
        Me.dgvComisionesSubRubros.RowHeadersVisible = False
        Me.dgvComisionesSubRubros.RowHeadersWidth = 10
        Me.dgvComisionesSubRubros.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvComisionesSubRubros.RowTemplate.Height = 18
        Me.dgvComisionesSubRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComisionesSubRubros.Size = New System.Drawing.Size(551, 145)
        Me.dgvComisionesSubRubros.TabIndex = 9
        '
        'IdCategoriaTwo
        '
        Me.IdCategoriaTwo.DataPropertyName = "IdCategoria"
        Me.IdCategoriaTwo.HeaderText = "IdCategoria"
        Me.IdCategoriaTwo.Name = "IdCategoriaTwo"
        Me.IdCategoriaTwo.Visible = False
        '
        'IdRubro
        '
        Me.IdRubro.DataPropertyName = "IdRubro"
        Me.IdRubro.HeaderText = "IdRubro"
        Me.IdRubro.Name = "IdRubro"
        Me.IdRubro.Visible = False
        '
        'NombreRubro
        '
        Me.NombreRubro.DataPropertyName = "NombreRubro"
        Me.NombreRubro.HeaderText = "Rubro"
        Me.NombreRubro.Name = "NombreRubro"
        Me.NombreRubro.Width = 195
        '
        'IdSubRubro
        '
        Me.IdSubRubro.DataPropertyName = "IdSubRubro"
        Me.IdSubRubro.HeaderText = "Código"
        Me.IdSubRubro.Name = "IdSubRubro"
        Me.IdSubRubro.Visible = False
        '
        'NombreSubRubro
        '
        Me.NombreSubRubro.DataPropertyName = "NombreSubRubro"
        Me.NombreSubRubro.HeaderText = "SubRubro"
        Me.NombreSubRubro.Name = "NombreSubRubro"
        Me.NombreSubRubro.Width = 253
        '
        'DescuentoRecargoPorc2
        '
        Me.DescuentoRecargoPorc2.DataPropertyName = "DescuentoRecargoPorc1"
        Me.DescuentoRecargoPorc2.HeaderText = "Desc./Rec."
        Me.DescuentoRecargoPorc2.Name = "DescuentoRecargoPorc2"
        '
        'tbpSubSubRubro
        '
        Me.tbpSubSubRubro.Controls.Add(Me.bscCodigoSubSubRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscNombreSubSubRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.Label1)
        Me.tbpSubSubRubro.Controls.Add(Me.Label2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscCodigoSubRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscNombreSubRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscNombreRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscCodigoRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.btnRefrescarSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.btnEliminarSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.btnInsertarSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.lblDescuentoSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.txtDescuentoSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.dgvComisionesSubSubRubros)
        Me.tbpSubSubRubro.Controls.Add(Me.Label3)
        Me.tbpSubSubRubro.Location = New System.Drawing.Point(4, 25)
        Me.tbpSubSubRubro.Name = "tbpSubSubRubro"
        Me.tbpSubSubRubro.Size = New System.Drawing.Size(615, 221)
        Me.tbpSubSubRubro.TabIndex = 2
        Me.tbpSubSubRubro.Text = "SubSubRubro"
        Me.tbpSubSubRubro.UseVisualStyleBackColor = True
      '
      'bscCodigoSubSubRubro2
      '
      Me.bscCodigoSubSubRubro2.BindearPropiedadControl = "Text"
      Me.bscCodigoSubSubRubro2.BindearPropiedadEntidad = "IdSubRubro"
      Me.bscCodigoSubSubRubro2.Datos = Nothing
      Me.bscCodigoSubSubRubro2.FilaDevuelta = Nothing
        Me.bscCodigoSubSubRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoSubSubRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoSubSubRubro2.IsDecimal = False
        Me.bscCodigoSubSubRubro2.IsNumber = True
        Me.bscCodigoSubSubRubro2.IsPK = True
        Me.bscCodigoSubSubRubro2.IsRequired = True
        Me.bscCodigoSubSubRubro2.Key = ""
        Me.bscCodigoSubSubRubro2.LabelAsoc = Nothing
        Me.bscCodigoSubSubRubro2.Location = New System.Drawing.Point(83, 65)
        Me.bscCodigoSubSubRubro2.MaxLengh = "32767"
        Me.bscCodigoSubSubRubro2.Name = "bscCodigoSubSubRubro2"
        Me.bscCodigoSubSubRubro2.Permitido = True
        Me.bscCodigoSubSubRubro2.Selecciono = False
        Me.bscCodigoSubSubRubro2.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoSubSubRubro2.TabIndex = 8
      '
      'bscNombreSubSubRubro2
      '
      Me.bscNombreSubSubRubro2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscNombreSubSubRubro2.BindearPropiedadControl = Nothing
      Me.bscNombreSubSubRubro2.BindearPropiedadEntidad = Nothing
      Me.bscNombreSubSubRubro2.Datos = Nothing
      Me.bscNombreSubSubRubro2.FilaDevuelta = Nothing
        Me.bscNombreSubSubRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreSubSubRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreSubSubRubro2.IsDecimal = False
        Me.bscNombreSubSubRubro2.IsNumber = False
        Me.bscNombreSubSubRubro2.IsPK = True
        Me.bscNombreSubSubRubro2.IsRequired = True
        Me.bscNombreSubSubRubro2.Key = ""
        Me.bscNombreSubSubRubro2.LabelAsoc = Nothing
        Me.bscNombreSubSubRubro2.Location = New System.Drawing.Point(182, 65)
        Me.bscNombreSubSubRubro2.MaxLengh = "32767"
        Me.bscNombreSubSubRubro2.Name = "bscNombreSubSubRubro2"
        Me.bscNombreSubSubRubro2.Permitido = True
        Me.bscNombreSubSubRubro2.Selecciono = False
        Me.bscNombreSubSubRubro2.Size = New System.Drawing.Size(302, 20)
        Me.bscNombreSubSubRubro2.TabIndex = 9
      '
      'Label1
      '
      Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(26, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SubRubro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(45, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Rubro"
      '
      'bscCodigoSubRubro2
      '
      Me.bscCodigoSubRubro2.BindearPropiedadControl = "Text"
      Me.bscCodigoSubRubro2.BindearPropiedadEntidad = "IdSubRubro"
      Me.bscCodigoSubRubro2.Datos = Nothing
      Me.bscCodigoSubRubro2.FilaDevuelta = Nothing
        Me.bscCodigoSubRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoSubRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoSubRubro2.IsDecimal = False
        Me.bscCodigoSubRubro2.IsNumber = True
        Me.bscCodigoSubRubro2.IsPK = True
        Me.bscCodigoSubRubro2.IsRequired = True
        Me.bscCodigoSubRubro2.Key = ""
        Me.bscCodigoSubRubro2.LabelAsoc = Nothing
        Me.bscCodigoSubRubro2.Location = New System.Drawing.Point(83, 37)
        Me.bscCodigoSubRubro2.MaxLengh = "32767"
        Me.bscCodigoSubRubro2.Name = "bscCodigoSubRubro2"
        Me.bscCodigoSubRubro2.Permitido = True
        Me.bscCodigoSubRubro2.Selecciono = False
        Me.bscCodigoSubRubro2.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoSubRubro2.TabIndex = 5
      '
      'bscNombreSubRubro2
      '
      Me.bscNombreSubRubro2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscNombreSubRubro2.BindearPropiedadControl = Nothing
      Me.bscNombreSubRubro2.BindearPropiedadEntidad = Nothing
      Me.bscNombreSubRubro2.Datos = Nothing
      Me.bscNombreSubRubro2.FilaDevuelta = Nothing
        Me.bscNombreSubRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreSubRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreSubRubro2.IsDecimal = False
        Me.bscNombreSubRubro2.IsNumber = False
        Me.bscNombreSubRubro2.IsPK = True
        Me.bscNombreSubRubro2.IsRequired = True
        Me.bscNombreSubRubro2.Key = ""
        Me.bscNombreSubRubro2.LabelAsoc = Nothing
        Me.bscNombreSubRubro2.Location = New System.Drawing.Point(182, 37)
        Me.bscNombreSubRubro2.MaxLengh = "32767"
        Me.bscNombreSubRubro2.Name = "bscNombreSubRubro2"
        Me.bscNombreSubRubro2.Permitido = True
        Me.bscNombreSubRubro2.Selecciono = False
        Me.bscNombreSubRubro2.Size = New System.Drawing.Size(302, 20)
        Me.bscNombreSubRubro2.TabIndex = 6
      '
      'bscNombreRubro2
      '
      Me.bscNombreRubro2.BindearPropiedadControl = Nothing
      Me.bscNombreRubro2.BindearPropiedadEntidad = Nothing
      Me.bscNombreRubro2.Datos = Nothing
      Me.bscNombreRubro2.FilaDevuelta = Nothing
        Me.bscNombreRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreRubro2.IsDecimal = False
        Me.bscNombreRubro2.IsNumber = False
        Me.bscNombreRubro2.IsPK = True
        Me.bscNombreRubro2.IsRequired = True
        Me.bscNombreRubro2.Key = ""
        Me.bscNombreRubro2.LabelAsoc = Nothing
        Me.bscNombreRubro2.Location = New System.Drawing.Point(182, 8)
        Me.bscNombreRubro2.MaxLengh = "32767"
        Me.bscNombreRubro2.Name = "bscNombreRubro2"
        Me.bscNombreRubro2.Permitido = True
        Me.bscNombreRubro2.Selecciono = False
        Me.bscNombreRubro2.Size = New System.Drawing.Size(302, 20)
        Me.bscNombreRubro2.TabIndex = 3
      '
      'bscCodigoRubro2
      '
      Me.bscCodigoRubro2.BindearPropiedadControl = "Text"
      Me.bscCodigoRubro2.BindearPropiedadEntidad = "IdRubro"
      Me.bscCodigoRubro2.Datos = Nothing
      Me.bscCodigoRubro2.FilaDevuelta = Nothing
        Me.bscCodigoRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro2.IsDecimal = False
        Me.bscCodigoRubro2.IsNumber = True
        Me.bscCodigoRubro2.IsPK = True
        Me.bscCodigoRubro2.IsRequired = True
        Me.bscCodigoRubro2.Key = ""
        Me.bscCodigoRubro2.LabelAsoc = Nothing
        Me.bscCodigoRubro2.Location = New System.Drawing.Point(83, 8)
        Me.bscCodigoRubro2.MaxLengh = "32767"
        Me.bscCodigoRubro2.Name = "bscCodigoRubro2"
        Me.bscCodigoRubro2.Permitido = True
        Me.bscCodigoRubro2.Selecciono = False
        Me.bscCodigoRubro2.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoRubro2.TabIndex = 2
      '
      'btnRefrescarSubSubRubro
      '
      Me.btnRefrescarSubSubRubro.Image = CType(resources.GetObject("btnRefrescarSubSubRubro.Image"), System.Drawing.Image)
        Me.btnRefrescarSubSubRubro.Location = New System.Drawing.Point(14, 10)
        Me.btnRefrescarSubSubRubro.Name = "btnRefrescarSubSubRubro"
        Me.btnRefrescarSubSubRubro.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarSubSubRubro.TabIndex = 0
        Me.btnRefrescarSubSubRubro.UseVisualStyleBackColor = True
        '
        'btnEliminarSubSubRubro
        '
        Me.btnEliminarSubSubRubro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarSubSubRubro.Image = CType(resources.GetObject("btnEliminarSubSubRubro.Image"), System.Drawing.Image)
        Me.btnEliminarSubSubRubro.Location = New System.Drawing.Point(571, 135)
        Me.btnEliminarSubSubRubro.Name = "btnEliminarSubSubRubro"
        Me.btnEliminarSubSubRubro.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarSubSubRubro.TabIndex = 13
        Me.btnEliminarSubSubRubro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarSubSubRubro.UseVisualStyleBackColor = True
        '
        'btnInsertarSubSubRubro
        '
        Me.btnInsertarSubSubRubro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarSubSubRubro.Image = CType(resources.GetObject("btnInsertarSubSubRubro.Image"), System.Drawing.Image)
        Me.btnInsertarSubSubRubro.Location = New System.Drawing.Point(571, 90)
        Me.btnInsertarSubSubRubro.Name = "btnInsertarSubSubRubro"
        Me.btnInsertarSubSubRubro.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarSubSubRubro.TabIndex = 12
        Me.btnInsertarSubSubRubro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarSubSubRubro.UseVisualStyleBackColor = True
        '
        'lblDescuentoSubSubRubro
        '
        Me.lblDescuentoSubSubRubro.AutoSize = True
        Me.lblDescuentoSubSubRubro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoSubSubRubro.LabelAsoc = Nothing
        Me.lblDescuentoSubSubRubro.Location = New System.Drawing.Point(483, 11)
        Me.lblDescuentoSubSubRubro.Name = "lblDescuentoSubSubRubro"
        Me.lblDescuentoSubSubRubro.Size = New System.Drawing.Size(71, 13)
        Me.lblDescuentoSubSubRubro.TabIndex = 10
        Me.lblDescuentoSubSubRubro.Text = "% Desc./Rec"
        '
        'txtDescuentoSubSubRubro
        '
        Me.txtDescuentoSubSubRubro.BindearPropiedadControl = ""
        Me.txtDescuentoSubSubRubro.BindearPropiedadEntidad = ""
        Me.txtDescuentoSubSubRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoSubSubRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoSubSubRubro.Formato = "#,##0.00"
        Me.txtDescuentoSubSubRubro.IsDecimal = True
        Me.txtDescuentoSubSubRubro.IsNumber = True
        Me.txtDescuentoSubSubRubro.IsPK = False
        Me.txtDescuentoSubSubRubro.IsRequired = False
        Me.txtDescuentoSubSubRubro.Key = ""
        Me.txtDescuentoSubSubRubro.LabelAsoc = Me.lblDescuentoSubSubRubro
        Me.txtDescuentoSubSubRubro.Location = New System.Drawing.Point(554, 8)
        Me.txtDescuentoSubSubRubro.MaxLength = 7
        Me.txtDescuentoSubSubRubro.Name = "txtDescuentoSubSubRubro"
        Me.txtDescuentoSubSubRubro.Size = New System.Drawing.Size(57, 20)
        Me.txtDescuentoSubSubRubro.TabIndex = 11
        Me.txtDescuentoSubSubRubro.Text = "0,00"
        Me.txtDescuentoSubSubRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvComisionesSubSubRubros
        '
        Me.dgvComisionesSubSubRubros.AllowUserToAddRows = False
        Me.dgvComisionesSubSubRubros.AllowUserToDeleteRows = False
        Me.dgvComisionesSubSubRubros.AllowUserToResizeColumns = False
        Me.dgvComisionesSubSubRubros.AllowUserToResizeRows = False
        Me.dgvComisionesSubSubRubros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvComisionesSubSubRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComisionesSubSubRubros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCategoriaTres, Me.IdRubroTwo, Me.NombreRubroTwo, Me.IdSubRubroTwo, Me.NombreSubRubroTwo, Me.IdSubSubRubro, Me.NombreSubSubRubro, Me.DescuentoRecargoPorc3})
        Me.dgvComisionesSubSubRubros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComisionesSubSubRubros.Location = New System.Drawing.Point(14, 91)
        Me.dgvComisionesSubSubRubros.Name = "dgvComisionesSubSubRubros"
        Me.dgvComisionesSubSubRubros.RowHeadersVisible = False
        Me.dgvComisionesSubSubRubros.RowHeadersWidth = 10
        Me.dgvComisionesSubSubRubros.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvComisionesSubSubRubros.RowTemplate.Height = 18
        Me.dgvComisionesSubSubRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComisionesSubSubRubros.Size = New System.Drawing.Size(551, 116)
        Me.dgvComisionesSubSubRubros.TabIndex = 14
        '
        'IdCategoriaTres
        '
        Me.IdCategoriaTres.DataPropertyName = "IdCategoria"
        Me.IdCategoriaTres.HeaderText = "IdCategoria"
        Me.IdCategoriaTres.Name = "IdCategoriaTres"
        Me.IdCategoriaTres.Visible = False
        '
        'IdRubroTwo
        '
        Me.IdRubroTwo.DataPropertyName = "IdRubro"
        Me.IdRubroTwo.HeaderText = "IdRubro"
        Me.IdRubroTwo.Name = "IdRubroTwo"
        Me.IdRubroTwo.Visible = False
        '
        'NombreRubroTwo
        '
        Me.NombreRubroTwo.DataPropertyName = "NombreRubro"
        Me.NombreRubroTwo.HeaderText = "Rubro"
        Me.NombreRubroTwo.Name = "NombreRubroTwo"
        Me.NombreRubroTwo.Width = 120
        '
        'IdSubRubroTwo
        '
        Me.IdSubRubroTwo.DataPropertyName = "IdSubRubro"
        Me.IdSubRubroTwo.HeaderText = "IdSubRubro"
        Me.IdSubRubroTwo.Name = "IdSubRubroTwo"
        Me.IdSubRubroTwo.Visible = False
        '
        'NombreSubRubroTwo
        '
        Me.NombreSubRubroTwo.DataPropertyName = "NombreSubRubro"
        Me.NombreSubRubroTwo.HeaderText = "SubRubro"
        Me.NombreSubRubroTwo.Name = "NombreSubRubroTwo"
        Me.NombreSubRubroTwo.Width = 120
        '
        'IdSubSubRubro
        '
        Me.IdSubSubRubro.DataPropertyName = "IdSubSubRubro"
        Me.IdSubSubRubro.HeaderText = "IdSubSubRubro"
        Me.IdSubSubRubro.Name = "IdSubSubRubro"
        Me.IdSubSubRubro.Visible = False
        '
        'NombreSubSubRubro
        '
        Me.NombreSubSubRubro.DataPropertyName = "NombreSubSubRubro"
        Me.NombreSubSubRubro.HeaderText = "SubSubRubro"
        Me.NombreSubSubRubro.Name = "NombreSubSubRubro"
        Me.NombreSubSubRubro.Width = 208
        '
        'DescuentoRecargoPorc3
        '
        Me.DescuentoRecargoPorc3.DataPropertyName = "DescuentoRecargoPorc1"
        Me.DescuentoRecargoPorc3.HeaderText = "Desc./Rec."
        Me.DescuentoRecargoPorc3.Name = "DescuentoRecargoPorc3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(7, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "SubSubRubro"
        '
        'tbpLicencias
        '
        Me.tbpLicencias.BackColor = System.Drawing.SystemColors.Control
        Me.tbpLicencias.Controls.Add(Me.chbActualizarAplicacion)
        Me.tbpLicencias.Controls.Add(Me.chbActualizarVersion)
        Me.tbpLicencias.Controls.Add(Me.chbControlarBackup)
        Me.tbpLicencias.Location = New System.Drawing.Point(4, 22)
        Me.tbpLicencias.Name = "tbpLicencias"
        Me.tbpLicencias.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpLicencias.Size = New System.Drawing.Size(634, 262)
        Me.tbpLicencias.TabIndex = 1
        Me.tbpLicencias.Text = "Licencias"
        '
        'chbActualizarAplicacion
        '
        Me.chbActualizarAplicacion.AutoSize = True
        Me.chbActualizarAplicacion.BindearPropiedadControl = "Checked"
        Me.chbActualizarAplicacion.BindearPropiedadEntidad = "ActualizarAplicacion"
        Me.chbActualizarAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizarAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizarAplicacion.IsPK = False
        Me.chbActualizarAplicacion.IsRequired = False
        Me.chbActualizarAplicacion.Key = Nothing
        Me.chbActualizarAplicacion.LabelAsoc = Nothing
        Me.chbActualizarAplicacion.Location = New System.Drawing.Point(123, 38)
        Me.chbActualizarAplicacion.Name = "chbActualizarAplicacion"
        Me.chbActualizarAplicacion.Size = New System.Drawing.Size(124, 17)
        Me.chbActualizarAplicacion.TabIndex = 0
        Me.chbActualizarAplicacion.Text = "Actualizar Aplicación"
        Me.chbActualizarAplicacion.UseVisualStyleBackColor = True
        '
        'chbActualizarVersion
        '
        Me.chbActualizarVersion.AutoSize = True
        Me.chbActualizarVersion.BindearPropiedadControl = "Checked"
        Me.chbActualizarVersion.BindearPropiedadEntidad = "ActualizarVersion"
        Me.chbActualizarVersion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActualizarVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActualizarVersion.IsPK = False
        Me.chbActualizarVersion.IsRequired = False
        Me.chbActualizarVersion.Key = Nothing
        Me.chbActualizarVersion.LabelAsoc = Nothing
        Me.chbActualizarVersion.Location = New System.Drawing.Point(123, 70)
        Me.chbActualizarVersion.Name = "chbActualizarVersion"
        Me.chbActualizarVersion.Size = New System.Drawing.Size(110, 17)
        Me.chbActualizarVersion.TabIndex = 2
        Me.chbActualizarVersion.Text = "Actualizar Versión"
        Me.chbActualizarVersion.UseVisualStyleBackColor = True
        Me.chbActualizarVersion.Visible = False
        '
        'chbControlarBackup
        '
        Me.chbControlarBackup.AutoSize = True
        Me.chbControlarBackup.BindearPropiedadControl = "Checked"
        Me.chbControlarBackup.BindearPropiedadEntidad = "ControlaBackup"
        Me.chbControlarBackup.ForeColorFocus = System.Drawing.Color.Red
        Me.chbControlarBackup.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbControlarBackup.IsPK = False
        Me.chbControlarBackup.IsRequired = False
        Me.chbControlarBackup.Key = Nothing
        Me.chbControlarBackup.LabelAsoc = Nothing
        Me.chbControlarBackup.Location = New System.Drawing.Point(259, 38)
        Me.chbControlarBackup.Name = "chbControlarBackup"
        Me.chbControlarBackup.Size = New System.Drawing.Size(105, 17)
        Me.chbControlarBackup.TabIndex = 1
        Me.chbControlarBackup.Text = "Controla Backup"
        Me.chbControlarBackup.UseVisualStyleBackColor = True
        '
        'tbpMarina
        '
        Me.tbpMarina.BackColor = System.Drawing.SystemColors.Control
        Me.tbpMarina.Controls.Add(Me.lblImporteGtosAdm)
        Me.tbpMarina.Controls.Add(Me.txtImporteGtosAdm)
        Me.tbpMarina.Controls.Add(Me.chbPagaExpensas)
        Me.tbpMarina.Controls.Add(Me.chbPagaAlquiler)
        Me.tbpMarina.Controls.Add(Me.cmbAdquiereAcciones)
        Me.tbpMarina.Controls.Add(Me.chbLimiteMesesDeudaBotado)
        Me.tbpMarina.Controls.Add(Me.cmbCategoriaInversionista)
        Me.tbpMarina.Controls.Add(Me.cmbAdquiereCamas)
        Me.tbpMarina.Controls.Add(Me.lblAdquiereCamas)
        Me.tbpMarina.Controls.Add(Me.chbCategoriaInversionista)
        Me.tbpMarina.Controls.Add(Me.txtLimiteMesesDeudaBotado)
        Me.tbpMarina.Controls.Add(Me.cmbPideEmbarcacion)
        Me.tbpMarina.Controls.Add(Me.lblPideEmbarcacion)
        Me.tbpMarina.Controls.Add(Me.lblAdquiereAcciones)
        Me.tbpMarina.Controls.Add(Me.chbPerteneceAlComplejo)
        Me.tbpMarina.Controls.Add(Me.chbTPFisicaDatosAdicionales)
        Me.tbpMarina.Controls.Add(Me.chbPideConyuge)
        Me.tbpMarina.Controls.Add(Me.chbFirmaMandato)
        Me.tbpMarina.Location = New System.Drawing.Point(4, 22)
        Me.tbpMarina.Name = "tbpMarina"
        Me.tbpMarina.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpMarina.Size = New System.Drawing.Size(634, 262)
        Me.tbpMarina.TabIndex = 2
        Me.tbpMarina.Text = "Marina"
        '
        'cmbAdquiereAcciones
        '
        Me.cmbAdquiereAcciones.BindearPropiedadControl = "SelectedValue"
        Me.cmbAdquiereAcciones.BindearPropiedadEntidad = "AdquiereAcciones"
        Me.cmbAdquiereAcciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAdquiereAcciones.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAdquiereAcciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAdquiereAcciones.FormattingEnabled = True
        Me.cmbAdquiereAcciones.IsPK = False
        Me.cmbAdquiereAcciones.IsRequired = True
        Me.cmbAdquiereAcciones.Key = Nothing
        Me.cmbAdquiereAcciones.LabelAsoc = Me.lblAdquiereAcciones
        Me.cmbAdquiereAcciones.Location = New System.Drawing.Point(112, 62)
        Me.cmbAdquiereAcciones.Name = "cmbAdquiereAcciones"
        Me.cmbAdquiereAcciones.Size = New System.Drawing.Size(70, 21)
        Me.cmbAdquiereAcciones.TabIndex = 43
        '
        'lblAdquiereAcciones
        '
        Me.lblAdquiereAcciones.AutoSize = True
        Me.lblAdquiereAcciones.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAdquiereAcciones.LabelAsoc = Nothing
        Me.lblAdquiereAcciones.Location = New System.Drawing.Point(6, 65)
        Me.lblAdquiereAcciones.Name = "lblAdquiereAcciones"
        Me.lblAdquiereAcciones.Size = New System.Drawing.Size(96, 13)
        Me.lblAdquiereAcciones.TabIndex = 29
        Me.lblAdquiereAcciones.Text = "Adquiere Acciones"
        '
        'chbLimiteMesesDeudaBotado
        '
        Me.chbLimiteMesesDeudaBotado.AutoSize = True
        Me.chbLimiteMesesDeudaBotado.BindearPropiedadControl = Nothing
        Me.chbLimiteMesesDeudaBotado.BindearPropiedadEntidad = Nothing
        Me.chbLimiteMesesDeudaBotado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLimiteMesesDeudaBotado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLimiteMesesDeudaBotado.IsPK = False
        Me.chbLimiteMesesDeudaBotado.IsRequired = False
        Me.chbLimiteMesesDeudaBotado.Key = Nothing
        Me.chbLimiteMesesDeudaBotado.LabelAsoc = Nothing
        Me.chbLimiteMesesDeudaBotado.Location = New System.Drawing.Point(12, 175)
        Me.chbLimiteMesesDeudaBotado.Name = "chbLimiteMesesDeudaBotado"
        Me.chbLimiteMesesDeudaBotado.Size = New System.Drawing.Size(214, 17)
        Me.chbLimiteMesesDeudaBotado.TabIndex = 41
        Me.chbLimiteMesesDeudaBotado.Text = "Límite de meses por deuda para botado"
        Me.chbLimiteMesesDeudaBotado.UseVisualStyleBackColor = True
        '
        'cmbCategoriaInversionista
        '
        Me.cmbCategoriaInversionista.BindearPropiedadControl = ""
        Me.cmbCategoriaInversionista.BindearPropiedadEntidad = ""
        Me.cmbCategoriaInversionista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriaInversionista.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriaInversionista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriaInversionista.FormattingEnabled = True
        Me.cmbCategoriaInversionista.IsPK = False
        Me.cmbCategoriaInversionista.IsRequired = False
        Me.cmbCategoriaInversionista.Key = Nothing
        Me.cmbCategoriaInversionista.LabelAsoc = Nothing
        Me.cmbCategoriaInversionista.Location = New System.Drawing.Point(153, 133)
        Me.cmbCategoriaInversionista.Name = "cmbCategoriaInversionista"
        Me.cmbCategoriaInversionista.Size = New System.Drawing.Size(150, 21)
        Me.cmbCategoriaInversionista.TabIndex = 38
        '
        'cmbAdquiereCamas
        '
        Me.cmbAdquiereCamas.BindearPropiedadControl = "SelectedValue"
        Me.cmbAdquiereCamas.BindearPropiedadEntidad = "AdquiereCamas"
        Me.cmbAdquiereCamas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAdquiereCamas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAdquiereCamas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAdquiereCamas.FormattingEnabled = True
        Me.cmbAdquiereCamas.IsPK = False
        Me.cmbAdquiereCamas.IsRequired = True
        Me.cmbAdquiereCamas.Key = Nothing
        Me.cmbAdquiereCamas.LabelAsoc = Me.lblAdquiereCamas
        Me.cmbAdquiereCamas.Location = New System.Drawing.Point(112, 62)
        Me.cmbAdquiereCamas.Name = "cmbAdquiereCamas"
        Me.cmbAdquiereCamas.Size = New System.Drawing.Size(70, 21)
        Me.cmbAdquiereCamas.TabIndex = 34
        '
        'lblAdquiereCamas
        '
        Me.lblAdquiereCamas.AutoSize = True
        Me.lblAdquiereCamas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblAdquiereCamas.LabelAsoc = Nothing
        Me.lblAdquiereCamas.Location = New System.Drawing.Point(6, 65)
        Me.lblAdquiereCamas.Name = "lblAdquiereCamas"
        Me.lblAdquiereCamas.Size = New System.Drawing.Size(84, 13)
        Me.lblAdquiereCamas.TabIndex = 33
        Me.lblAdquiereCamas.Text = "Adquiere Camas"
        '
        'chbCategoriaInversionista
        '
        Me.chbCategoriaInversionista.AutoSize = True
        Me.chbCategoriaInversionista.BindearPropiedadControl = Nothing
        Me.chbCategoriaInversionista.BindearPropiedadEntidad = Nothing
        Me.chbCategoriaInversionista.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoriaInversionista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoriaInversionista.IsPK = False
        Me.chbCategoriaInversionista.IsRequired = False
        Me.chbCategoriaInversionista.Key = Nothing
        Me.chbCategoriaInversionista.LabelAsoc = Nothing
        Me.chbCategoriaInversionista.Location = New System.Drawing.Point(12, 135)
        Me.chbCategoriaInversionista.Name = "chbCategoriaInversionista"
        Me.chbCategoriaInversionista.Size = New System.Drawing.Size(135, 17)
        Me.chbCategoriaInversionista.TabIndex = 37
        Me.chbCategoriaInversionista.Text = "Categoría Inversionista"
        Me.chbCategoriaInversionista.UseVisualStyleBackColor = True
        '
        'txtLimiteMesesDeudaBotado
        '
        Me.txtLimiteMesesDeudaBotado.BindearPropiedadControl = ""
        Me.txtLimiteMesesDeudaBotado.BindearPropiedadEntidad = ""
        Me.txtLimiteMesesDeudaBotado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLimiteMesesDeudaBotado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLimiteMesesDeudaBotado.Formato = ""
        Me.txtLimiteMesesDeudaBotado.IsDecimal = False
        Me.txtLimiteMesesDeudaBotado.IsNumber = True
        Me.txtLimiteMesesDeudaBotado.IsPK = False
        Me.txtLimiteMesesDeudaBotado.IsRequired = False
        Me.txtLimiteMesesDeudaBotado.Key = ""
        Me.txtLimiteMesesDeudaBotado.LabelAsoc = Nothing
        Me.txtLimiteMesesDeudaBotado.Location = New System.Drawing.Point(232, 173)
        Me.txtLimiteMesesDeudaBotado.MaxLength = 30
        Me.txtLimiteMesesDeudaBotado.Name = "txtLimiteMesesDeudaBotado"
        Me.txtLimiteMesesDeudaBotado.Size = New System.Drawing.Size(70, 20)
        Me.txtLimiteMesesDeudaBotado.TabIndex = 42
        Me.txtLimiteMesesDeudaBotado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbPideEmbarcacion
        '
        Me.cmbPideEmbarcacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbPideEmbarcacion.BindearPropiedadEntidad = "PideEmbarcacion"
        Me.cmbPideEmbarcacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPideEmbarcacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPideEmbarcacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPideEmbarcacion.FormattingEnabled = True
        Me.cmbPideEmbarcacion.IsPK = False
        Me.cmbPideEmbarcacion.IsRequired = True
        Me.cmbPideEmbarcacion.Key = Nothing
        Me.cmbPideEmbarcacion.LabelAsoc = Me.lblPideEmbarcacion
        Me.cmbPideEmbarcacion.Location = New System.Drawing.Point(289, 62)
        Me.cmbPideEmbarcacion.Name = "cmbPideEmbarcacion"
        Me.cmbPideEmbarcacion.Size = New System.Drawing.Size(70, 21)
        Me.cmbPideEmbarcacion.TabIndex = 36
        '
        'lblPideEmbarcacion
        '
        Me.lblPideEmbarcacion.AutoSize = True
        Me.lblPideEmbarcacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPideEmbarcacion.LabelAsoc = Nothing
        Me.lblPideEmbarcacion.Location = New System.Drawing.Point(188, 66)
        Me.lblPideEmbarcacion.Name = "lblPideEmbarcacion"
        Me.lblPideEmbarcacion.Size = New System.Drawing.Size(93, 13)
        Me.lblPideEmbarcacion.TabIndex = 35
        Me.lblPideEmbarcacion.Text = "Pide Embarcacion"
        '
        'chbPerteneceAlComplejo
        '
        Me.chbPerteneceAlComplejo.AutoSize = True
        Me.chbPerteneceAlComplejo.BindearPropiedadControl = "Checked"
        Me.chbPerteneceAlComplejo.BindearPropiedadEntidad = "PerteneceAlComplejo"
        Me.chbPerteneceAlComplejo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPerteneceAlComplejo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPerteneceAlComplejo.IsPK = False
        Me.chbPerteneceAlComplejo.IsRequired = False
        Me.chbPerteneceAlComplejo.Key = Nothing
        Me.chbPerteneceAlComplejo.LabelAsoc = Nothing
        Me.chbPerteneceAlComplejo.Location = New System.Drawing.Point(374, 20)
        Me.chbPerteneceAlComplejo.Name = "chbPerteneceAlComplejo"
        Me.chbPerteneceAlComplejo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbPerteneceAlComplejo.Size = New System.Drawing.Size(131, 17)
        Me.chbPerteneceAlComplejo.TabIndex = 32
        Me.chbPerteneceAlComplejo.Text = "Pertenece al complejo"
        Me.chbPerteneceAlComplejo.UseVisualStyleBackColor = True
        '
        'chbTPFisicaDatosAdicionales
        '
        Me.chbTPFisicaDatosAdicionales.AutoSize = True
        Me.chbTPFisicaDatosAdicionales.BindearPropiedadControl = "Checked"
        Me.chbTPFisicaDatosAdicionales.BindearPropiedadEntidad = "TPFisicaDatosAdicionales"
        Me.chbTPFisicaDatosAdicionales.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTPFisicaDatosAdicionales.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTPFisicaDatosAdicionales.IsPK = False
        Me.chbTPFisicaDatosAdicionales.IsRequired = False
        Me.chbTPFisicaDatosAdicionales.Key = Nothing
        Me.chbTPFisicaDatosAdicionales.LabelAsoc = Nothing
        Me.chbTPFisicaDatosAdicionales.Location = New System.Drawing.Point(210, 20)
        Me.chbTPFisicaDatosAdicionales.Name = "chbTPFisicaDatosAdicionales"
        Me.chbTPFisicaDatosAdicionales.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbTPFisicaDatosAdicionales.Size = New System.Drawing.Size(158, 17)
        Me.chbTPFisicaDatosAdicionales.TabIndex = 31
        Me.chbTPFisicaDatosAdicionales.Text = "TP Fisica Datos Adicionales"
        Me.chbTPFisicaDatosAdicionales.UseVisualStyleBackColor = True
        '
        'chbPideConyuge
        '
        Me.chbPideConyuge.AutoSize = True
        Me.chbPideConyuge.BindearPropiedadControl = "Checked"
        Me.chbPideConyuge.BindearPropiedadEntidad = "PideConyuge"
        Me.chbPideConyuge.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPideConyuge.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPideConyuge.IsPK = False
        Me.chbPideConyuge.IsRequired = False
        Me.chbPideConyuge.Key = Nothing
        Me.chbPideConyuge.LabelAsoc = Nothing
        Me.chbPideConyuge.Location = New System.Drawing.Point(112, 20)
        Me.chbPideConyuge.Name = "chbPideConyuge"
        Me.chbPideConyuge.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbPideConyuge.Size = New System.Drawing.Size(92, 17)
        Me.chbPideConyuge.TabIndex = 30
        Me.chbPideConyuge.Text = "Pide Conyuge"
        Me.chbPideConyuge.UseVisualStyleBackColor = True
        '
        'chbFirmaMandato
        '
        Me.chbFirmaMandato.AutoSize = True
        Me.chbFirmaMandato.BindearPropiedadControl = "Checked"
        Me.chbFirmaMandato.BindearPropiedadEntidad = "FirmaMandato"
        Me.chbFirmaMandato.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFirmaMandato.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFirmaMandato.IsPK = False
        Me.chbFirmaMandato.IsRequired = False
        Me.chbFirmaMandato.Key = Nothing
        Me.chbFirmaMandato.LabelAsoc = Nothing
        Me.chbFirmaMandato.Location = New System.Drawing.Point(10, 20)
        Me.chbFirmaMandato.Name = "chbFirmaMandato"
        Me.chbFirmaMandato.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbFirmaMandato.Size = New System.Drawing.Size(96, 17)
        Me.chbFirmaMandato.TabIndex = 28
        Me.chbFirmaMandato.Text = "Firma Mandato"
        Me.chbFirmaMandato.UseVisualStyleBackColor = True
        '
        'lblImporteGtosAdm
        '
        Me.lblImporteGtosAdm.AutoSize = True
        Me.lblImporteGtosAdm.LabelAsoc = Nothing
        Me.lblImporteGtosAdm.Location = New System.Drawing.Point(248, 102)
        Me.lblImporteGtosAdm.Name = "lblImporteGtosAdm"
        Me.lblImporteGtosAdm.Size = New System.Drawing.Size(162, 13)
        Me.lblImporteGtosAdm.TabIndex = 46
        Me.lblImporteGtosAdm.Text = "Monto por Gastos Administracion"
        '
        'txtImporteGtosAdm
        '
        Me.txtImporteGtosAdm.BindearPropiedadControl = "Text"
        Me.txtImporteGtosAdm.BindearPropiedadEntidad = "ImporteGastosAdmin"
        Me.txtImporteGtosAdm.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteGtosAdm.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteGtosAdm.Formato = "N2"
        Me.txtImporteGtosAdm.IsDecimal = True
        Me.txtImporteGtosAdm.IsNumber = True
        Me.txtImporteGtosAdm.IsPK = False
        Me.txtImporteGtosAdm.IsRequired = True
        Me.txtImporteGtosAdm.Key = ""
        Me.txtImporteGtosAdm.LabelAsoc = Me.lblImporteGtosAdm
        Me.txtImporteGtosAdm.Location = New System.Drawing.Point(416, 99)
        Me.txtImporteGtosAdm.MaxLength = 30
        Me.txtImporteGtosAdm.Name = "txtImporteGtosAdm"
        Me.txtImporteGtosAdm.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtImporteGtosAdm.Size = New System.Drawing.Size(70, 20)
        Me.txtImporteGtosAdm.TabIndex = 47
        '
        'chbPagaExpensas
        '
        Me.chbPagaExpensas.AutoSize = True
        Me.chbPagaExpensas.BindearPropiedadControl = "Checked"
        Me.chbPagaExpensas.BindearPropiedadEntidad = "PagaExpensas"
        Me.chbPagaExpensas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPagaExpensas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPagaExpensas.IsPK = False
        Me.chbPagaExpensas.IsRequired = False
        Me.chbPagaExpensas.Key = Nothing
        Me.chbPagaExpensas.LabelAsoc = Nothing
        Me.chbPagaExpensas.Location = New System.Drawing.Point(6, 101)
        Me.chbPagaExpensas.Name = "chbPagaExpensas"
        Me.chbPagaExpensas.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbPagaExpensas.Size = New System.Drawing.Size(100, 17)
        Me.chbPagaExpensas.TabIndex = 44
        Me.chbPagaExpensas.Text = "Paga Expensas"
        Me.chbPagaExpensas.UseVisualStyleBackColor = True
        '
        'chbPagaAlquiler
        '
        Me.chbPagaAlquiler.AutoSize = True
        Me.chbPagaAlquiler.BindearPropiedadControl = "Checked"
        Me.chbPagaAlquiler.BindearPropiedadEntidad = "PagaAlquiler"
        Me.chbPagaAlquiler.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPagaAlquiler.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPagaAlquiler.IsPK = False
        Me.chbPagaAlquiler.IsRequired = False
        Me.chbPagaAlquiler.Key = Nothing
        Me.chbPagaAlquiler.LabelAsoc = Nothing
        Me.chbPagaAlquiler.Location = New System.Drawing.Point(138, 101)
        Me.chbPagaAlquiler.Name = "chbPagaAlquiler"
        Me.chbPagaAlquiler.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbPagaAlquiler.Size = New System.Drawing.Size(88, 17)
        Me.chbPagaAlquiler.TabIndex = 45
        Me.chbPagaAlquiler.Text = "Paga Alquiler"
        Me.chbPagaAlquiler.UseVisualStyleBackColor = True
        '
        'CategoriasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(656, 387)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtNombreCategoria)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.tbcCategoria)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CategoriasDetalle"
        Me.Text = "Categoria"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.tbcCategoria, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.txtNombreCategoria, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtCategoria, 0)
        Me.tbcCategoria.ResumeLayout(False)
        Me.tbpDetalle.ResumeLayout(False)
        Me.tbpDetalle.PerformLayout()
        Me.tbpDescuentos.ResumeLayout(False)
        Me.tbcDescuentosDetalle.ResumeLayout(False)
        Me.tbpRubro.ResumeLayout(False)
        Me.tbpRubro.PerformLayout()
        CType(Me.dgvComisionesRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpSubRubro.ResumeLayout(False)
        Me.tbpSubRubro.PerformLayout()
        CType(Me.dgvComisionesSubRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpSubSubRubro.ResumeLayout(False)
        Me.tbpSubSubRubro.PerformLayout()
        CType(Me.dgvComisionesSubSubRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpLicencias.ResumeLayout(False)
        Me.tbpLicencias.PerformLayout()
        Me.tbpMarina.ResumeLayout(False)
        Me.tbpMarina.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreCategoria As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtCategoria As Eniac.Controles.TextBox
   Friend WithEvents txtDescuentoRecargo As Eniac.Controles.TextBox
   Friend WithEvents lblDescuentoRecargo As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents chbTipoDeComprobante As Eniac.Controles.CheckBox
   Public WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents UcCuentas1 As Eniac.Win.ucCuentas
   Friend WithEvents chbIntereses As Eniac.Controles.CheckBox
   Friend WithEvents cmbIntereses As Eniac.Controles.ComboBox
   Friend WithEvents UcCuentas2 As Eniac.Win.ucCuentas
   Friend WithEvents lblCuentaSecundaria As Eniac.Controles.Label
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents lblConcepto As Eniac.Controles.Label
   Friend WithEvents chbInteresesCuotas As Eniac.Controles.CheckBox
   Friend WithEvents cmbInteresesCuotas As Eniac.Controles.ComboBox
   Friend WithEvents chbRequiereRevisionAdministrativa As Eniac.Controles.CheckBox
   Friend WithEvents txtGrupo As Eniac.Controles.TextBox
   Friend WithEvents lblGrupo As Eniac.Controles.Label
   Friend WithEvents tbcCategoria As System.Windows.Forms.TabControl
   Friend WithEvents tbpDetalle As System.Windows.Forms.TabPage
   Friend WithEvents tbpDescuentos As System.Windows.Forms.TabPage
   Friend WithEvents tbcDescuentosDetalle As System.Windows.Forms.TabControl
   Friend WithEvents tbpRubro As System.Windows.Forms.TabPage
   Friend WithEvents btnRefrescarRubros As System.Windows.Forms.Button
   Friend WithEvents lblDescuentoRubros As Eniac.Controles.Label
   Friend WithEvents btnEliminarRubros As Eniac.Controles.Button
   Friend WithEvents txtDescuentoRubros As Eniac.Controles.TextBox
   Friend WithEvents dgvComisionesRubros As Eniac.Controles.DataGridView
   Friend WithEvents btnInsertarRubros As Eniac.Controles.Button
   Friend WithEvents tbpSubSubRubro As System.Windows.Forms.TabPage
   Friend WithEvents btnRefrescarSubSubRubro As System.Windows.Forms.Button
   Friend WithEvents btnEliminarSubSubRubro As Eniac.Controles.Button
   Friend WithEvents btnInsertarSubSubRubro As Eniac.Controles.Button
   Friend WithEvents lblDescuentoSubSubRubro As Eniac.Controles.Label
   Friend WithEvents txtDescuentoSubSubRubro As Eniac.Controles.TextBox
   Friend WithEvents dgvComisionesSubSubRubros As Eniac.Controles.DataGridView
   Friend WithEvents tbpSubRubro As System.Windows.Forms.TabPage
   Friend WithEvents bscCodigoRubro1 As Eniac.Controles.Buscador2
   Friend WithEvents btnRefrescarSubRubros As System.Windows.Forms.Button
   Friend WithEvents btnEliminarSubRubros As Eniac.Controles.Button
   Friend WithEvents btnInsertarSubRubros As Eniac.Controles.Button
   Friend WithEvents lblDescuentoSubRubros As Eniac.Controles.Label
   Friend WithEvents txtDescuentoSubRubros As Eniac.Controles.TextBox
   Friend WithEvents dgvComisionesSubRubros As Eniac.Controles.DataGridView
   Friend WithEvents bscNombreRubro1 As Eniac.Controles.Buscador2
   Friend WithEvents bscNombreSubRubro1 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoSubRubro1 As Eniac.Controles.Buscador2
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents lblSubRubro As Eniac.Controles.Label
   Friend WithEvents bscNombreRubro0 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoRubro0 As Eniac.Controles.Buscador2
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents bscCodigoSubRubro2 As Eniac.Controles.Buscador2
   Friend WithEvents bscNombreSubRubro2 As Eniac.Controles.Buscador2
   Friend WithEvents bscNombreRubro2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoRubro2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoSubSubRubro2 As Eniac.Controles.Buscador2
   Friend WithEvents bscNombreSubSubRubro2 As Eniac.Controles.Buscador2
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents IdCategoria As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargoPorc1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCategoriaTwo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSubRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSubRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargoPorc2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCategoriaTres As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdRubroTwo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreRubroTwo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSubRubroTwo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSubRubroTwo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdSubSubRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSubSubRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DescuentoRecargoPorc3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents tbpLicencias As System.Windows.Forms.TabPage
   Friend WithEvents chbControlarBackup As Eniac.Controles.CheckBox
   Protected WithEvents txtNivelAutorizacion As Eniac.Controles.TextBox
   Friend WithEvents lblNivelAutorizacion As Eniac.Controles.Label
   Friend WithEvents chbActualizarAplicacion As Eniac.Controles.CheckBox
   Friend WithEvents chbActualizarVersion As Eniac.Controles.CheckBox
   Friend WithEvents txtComisiones As Eniac.Controles.TextBox
   Friend WithEvents lblComisiones As Eniac.Controles.Label
    Friend WithEvents tbpMarina As TabPage
    Friend WithEvents chbLimiteMesesDeudaBotado As Controles.CheckBox
    Friend WithEvents cmbCategoriaInversionista As Controles.ComboBox
    Friend WithEvents cmbAdquiereCamas As Controles.ComboBox
    Friend WithEvents lblAdquiereCamas As Controles.Label
    Friend WithEvents chbCategoriaInversionista As Controles.CheckBox
    Friend WithEvents txtLimiteMesesDeudaBotado As Controles.TextBox
    Friend WithEvents cmbPideEmbarcacion As Controles.ComboBox
    Friend WithEvents lblPideEmbarcacion As Controles.Label
    Friend WithEvents lblAdquiereAcciones As Controles.Label
    Friend WithEvents chbPerteneceAlComplejo As Controles.CheckBox
    Friend WithEvents chbTPFisicaDatosAdicionales As Controles.CheckBox
    Friend WithEvents chbPideConyuge As Controles.CheckBox
    Friend WithEvents chbFirmaMandato As Controles.CheckBox
    Friend WithEvents cmbAdquiereAcciones As Controles.ComboBox
    Friend WithEvents chbForeColor As Controles.CheckBox
    Friend WithEvents chbBackColor As Controles.CheckBox
    Friend WithEvents btnForeColor As Button
    Friend WithEvents txtColor As Controles.TextBox
    Friend WithEvents lblColor As Controles.Label
    Friend WithEvents btnBackColor As Button
    Friend WithEvents cdColor As ColorDialog
    Friend WithEvents lblImporteGtosAdm As Controles.Label
    Friend WithEvents txtImporteGtosAdm As Controles.TextBox
    Friend WithEvents chbPagaExpensas As Controles.CheckBox
    Friend WithEvents chbPagaAlquiler As Controles.CheckBox
End Class
