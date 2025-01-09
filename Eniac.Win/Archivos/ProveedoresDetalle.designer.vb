<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProveedoresDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProveedoresDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.grbDatos = New System.Windows.Forms.GroupBox()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.txtCodigoProveedor = New Eniac.Controles.TextBox()
      Me.tbpImpuestos = New System.Windows.Forms.TabPage()
      Me.grbImpositivo = New System.Windows.Forms.GroupBox()
        Me.cmbRegimenesIIBBComplem = New Eniac.Controles.ComboBox()
        Me.lblNroRegimenIIBBComplem = New Eniac.Controles.Label()
        Me.chbRetencionIIBBComplem = New Eniac.Controles.CheckBox()
        Me.cmbAFIPConceptoCM05 = New Eniac.Controles.ComboBox()
        Me.chbAFIPConceptoCM05 = New Eniac.Controles.CheckBox()
        Me.cmbRegimenesIIBB = New Eniac.Controles.ComboBox()
        Me.lblNroRegimenIIBB = New Eniac.Controles.Label()
        Me.cmbRegimenesIVA = New Eniac.Controles.ComboBox()
        Me.lblNroRegimenIVA = New Eniac.Controles.Label()
        Me.cmbRegimenesGan = New Eniac.Controles.ComboBox()
        Me.cmbRegimenes = New Eniac.Controles.ComboBox()
        Me.lblRegimen = New Eniac.Controles.Label()
        Me.lblNroRegimenGan = New Eniac.Controles.Label()
        Me.chbPasibleRetencionIIBB = New Eniac.Controles.CheckBox()
        Me.lblNroRegimen = New Eniac.Controles.Label()
        Me.chbPasibleRetencionIVA = New Eniac.Controles.CheckBox()
        Me.chbPasibleRetencion2 = New Eniac.Controles.CheckBox()
        Me.chbPasibleRetencion = New Eniac.Controles.CheckBox()
        Me.txtIngresosBrutos = New Eniac.Controles.TextBox()
        Me.lblIngresosBrutos = New Eniac.Controles.Label()
        Me.txtNivelAutorizacion = New Eniac.Controles.TextBox()
        Me.lblNivelAutorizacion = New Eniac.Controles.Label()
        Me.bscNombreCuentaBanco = New Eniac.Controles.Buscador2()
        Me.Label4 = New Eniac.Controles.Label()
        Me.txtNombreDeFantasia = New Eniac.Controles.TextBox()
        Me.lblNombreDeFantasia = New Eniac.Controles.Label()
        Me.lblTipoDoc = New Eniac.Controles.Label()
        Me.cmbTipoDoc = New Eniac.Controles.ComboBox()
        Me.txtNroDoc = New Eniac.Controles.TextBox()
        Me.chbPorCtaOrden = New Eniac.Controles.CheckBox()
        Me.chbFormaPago = New Eniac.Controles.CheckBox()
        Me.lblDescuentoRecargoPorc = New Eniac.Controles.Label()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.txtDescuentoRecargoPorc = New Eniac.Controles.TextBox()
        Me.bscNombreCuentaCaja = New Eniac.Controles.Buscador()
        Me.lblCuentaCaja = New Eniac.Controles.Label()
        Me.txtCuit = New Eniac.Controles.TextBox()
        Me.lblCuit = New Eniac.Controles.Label()
        Me.lblCategoriaFiscal = New Eniac.Controles.Label()
        Me.cmbCategoriaFiscal = New Eniac.Controles.ComboBox()
        Me.chbComprobanteDeCompras = New Eniac.Controles.CheckBox()
        Me.cmbTiposComprobantes = New Eniac.Controles.ComboBox()
        Me.lblCategoria = New Eniac.Controles.Label()
        Me.cmbCategorias = New Eniac.Controles.ComboBox()
        Me.lblRubro = New Eniac.Controles.Label()
        Me.cboRubro = New Eniac.Controles.ComboBox()
        Me.bscCuentaCaja = New Eniac.Controles.Buscador()
        Me.tbpDatos = New System.Windows.Forms.TabPage()
        Me.grbUbicacion = New System.Windows.Forms.GroupBox()
        Me.lblCorreoAdm = New Eniac.Controles.Label()
        Me.txtCorreoAdm = New Eniac.Controles.TextBox()
        Me.txtDireccion = New Eniac.Controles.TextBox()
        Me.lblDireccion = New Eniac.Controles.Label()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
        Me.lnkLocalidad = New Eniac.Controles.LinkLabel()
        Me.txtFax = New Eniac.Controles.TextBox()
        Me.lblFax = New Eniac.Controles.Label()
        Me.txtTelefono = New Eniac.Controles.TextBox()
        Me.lblTelefono = New Eniac.Controles.Label()
        Me.txtCorreoElectronico = New Eniac.Controles.TextBox()
        Me.lblCorreoElectronico = New Eniac.Controles.Label()
        Me.tbcProveedor = New System.Windows.Forms.TabControl()
        Me.tbpOtros = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bscCodigoClienteVinculado = New Eniac.Controles.Buscador2()
        Me.chbClienteVinculado = New Eniac.Controles.CheckBox()
        Me.bscNombreClienteVinculado = New Eniac.Controles.Buscador2()
        Me.chbTransportista = New Eniac.Controles.CheckBox()
        Me.bscNombreTransportista = New Eniac.Controles.Buscador()
        Me.txtNroCuenta = New Eniac.Controles.TextBox()
        Me.lblNroCuenta = New Eniac.Controles.Label()
        Me.gbCuentaBancaria = New System.Windows.Forms.GroupBox()
        Me.txtCBUCuit = New Eniac.Controles.TextBox()
        Me.lblCBUCuit = New Eniac.Controles.Label()
        Me.txtCBUAlias = New Eniac.Controles.TextBox()
        Me.Label6 = New Eniac.Controles.Label()
        Me.txtCBU = New Eniac.Controles.TextBox()
        Me.Label7 = New Eniac.Controles.Label()
        Me.lblObservacion = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.tbpLogo = New System.Windows.Forms.TabPage()
        Me.pcbFoto = New System.Windows.Forms.PictureBox()
        Me.btnLimpiarImagen = New Eniac.Controles.Button()
        Me.btnBuscarImagen = New Eniac.Controles.Button()
        Me.tbpContratistas = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New Eniac.Controles.Label()
        Me.dtpFechaIndemnidad = New Eniac.Controles.DateTimePicker()
        Me.Label3 = New Eniac.Controles.Label()
        Me.dtpFechaIndiceInc = New Eniac.Controles.DateTimePicker()
        Me.Label2 = New Eniac.Controles.Label()
        Me.dtpFechaRes559 = New Eniac.Controles.DateTimePicker()
        Me.Label1 = New Eniac.Controles.Label()
        Me.dtpFechaHigSeg = New Eniac.Controles.DateTimePicker()
        Me.tbpContabilidad = New System.Windows.Forms.TabPage()
        Me.UcCuentas1 = New Eniac.Win.ucCuentas()
        Me.bscCodigoTransportista = New Eniac.Controles.Buscador()
        Me.ofdArchivos = New System.Windows.Forms.OpenFileDialog()
        Me.bscCuentaBanco = New Eniac.Controles.Buscador2()
        Me.chbEsProveedorGenerico = New Eniac.Controles.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grbDatos.SuspendLayout()
        Me.tbpImpuestos.SuspendLayout()
        Me.grbImpositivo.SuspendLayout()
        Me.tbpDatos.SuspendLayout()
        Me.grbUbicacion.SuspendLayout()
        Me.tbcProveedor.SuspendLayout()
        Me.tbpOtros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbCuentaBancaria.SuspendLayout()
        Me.tbpLogo.SuspendLayout()
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpContratistas.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbpContabilidad.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(611, 0)
        Me.btnAceptar.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(697, 0)
        '
        'btnCopiar
        '
        Me.btnCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopiar.Location = New System.Drawing.Point(510, 0)
        Me.btnCopiar.TabIndex = 4
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.Location = New System.Drawing.Point(453, 0)
        Me.btnAplicar.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(167, 12)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreProveedor"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(170, 29)
        Me.txtNombre.MaxLength = 100
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(540, 20)
        Me.txtNombre.TabIndex = 3
        '
        'chbActivo
        '
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(654, 10)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 4
        Me.chbActivo.Text = "Activo"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'grbDatos
        '
        Me.grbDatos.Controls.Add(Me.lblCodigoProveedor)
        Me.grbDatos.Controls.Add(Me.txtCodigoProveedor)
        Me.grbDatos.Controls.Add(Me.txtNombre)
        Me.grbDatos.Controls.Add(Me.lblNombre)
        Me.grbDatos.Controls.Add(Me.chbActivo)
        Me.grbDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbDatos.Location = New System.Drawing.Point(0, 0)
        Me.grbDatos.Name = "grbDatos"
        Me.grbDatos.Size = New System.Drawing.Size(780, 58)
        Me.grbDatos.TabIndex = 0
        Me.grbDatos.TabStop = False
        '
        'lblCodigoProveedor
        '
        Me.lblCodigoProveedor.AutoSize = True
        Me.lblCodigoProveedor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Location = New System.Drawing.Point(71, 12)
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        Me.lblCodigoProveedor.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoProveedor.TabIndex = 0
        Me.lblCodigoProveedor.Text = "Código"
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.BindearPropiedadControl = "Text"
        Me.txtCodigoProveedor.BindearPropiedadEntidad = "CodigoProveedor"
        Me.txtCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoProveedor.Formato = ""
        Me.txtCodigoProveedor.IsDecimal = False
        Me.txtCodigoProveedor.IsNumber = True
        Me.txtCodigoProveedor.IsPK = False
        Me.txtCodigoProveedor.IsRequired = True
        Me.txtCodigoProveedor.Key = ""
        Me.txtCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
        Me.txtCodigoProveedor.Location = New System.Drawing.Point(74, 29)
        Me.txtCodigoProveedor.MaxLength = 12
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.Size = New System.Drawing.Size(90, 20)
        Me.txtCodigoProveedor.TabIndex = 1
        Me.txtCodigoProveedor.Text = "0"
        Me.txtCodigoProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbpImpuestos
        '
        Me.tbpImpuestos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpImpuestos.Controls.Add(Me.grbImpositivo)
        Me.tbpImpuestos.Location = New System.Drawing.Point(4, 22)
        Me.tbpImpuestos.Name = "tbpImpuestos"
        Me.tbpImpuestos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpImpuestos.Size = New System.Drawing.Size(772, 324)
        Me.tbpImpuestos.TabIndex = 6
        Me.tbpImpuestos.Text = "Impuestos"
        '
        'grbImpositivo
        '
        Me.grbImpositivo.Controls.Add(Me.cmbRegimenesIIBBComplem)
        Me.grbImpositivo.Controls.Add(Me.lblNroRegimenIIBBComplem)
        Me.grbImpositivo.Controls.Add(Me.chbRetencionIIBBComplem)
        Me.grbImpositivo.Controls.Add(Me.cmbAFIPConceptoCM05)
        Me.grbImpositivo.Controls.Add(Me.chbAFIPConceptoCM05)
        Me.grbImpositivo.Controls.Add(Me.cmbRegimenesIIBB)
        Me.grbImpositivo.Controls.Add(Me.lblNroRegimenIIBB)
        Me.grbImpositivo.Controls.Add(Me.cmbRegimenesIVA)
        Me.grbImpositivo.Controls.Add(Me.lblNroRegimenIVA)
        Me.grbImpositivo.Controls.Add(Me.cmbRegimenesGan)
        Me.grbImpositivo.Controls.Add(Me.cmbRegimenes)
        Me.grbImpositivo.Controls.Add(Me.lblNroRegimenGan)
        Me.grbImpositivo.Controls.Add(Me.chbPasibleRetencionIIBB)
        Me.grbImpositivo.Controls.Add(Me.lblNroRegimen)
        Me.grbImpositivo.Controls.Add(Me.chbPasibleRetencionIVA)
        Me.grbImpositivo.Controls.Add(Me.lblRegimen)
        Me.grbImpositivo.Controls.Add(Me.chbPasibleRetencion2)
        Me.grbImpositivo.Controls.Add(Me.chbPasibleRetencion)
        Me.grbImpositivo.Controls.Add(Me.txtIngresosBrutos)
        Me.grbImpositivo.Controls.Add(Me.lblIngresosBrutos)
        Me.grbImpositivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbImpositivo.Location = New System.Drawing.Point(3, 3)
        Me.grbImpositivo.Name = "grbImpositivo"
        Me.grbImpositivo.Size = New System.Drawing.Size(766, 318)
        Me.grbImpositivo.TabIndex = 0
        Me.grbImpositivo.TabStop = False
        '
        'cmbRegimenesIIBBComplem
        '
        Me.cmbRegimenesIIBBComplem.BindearPropiedadControl = "SelectedValue"
        Me.cmbRegimenesIIBBComplem.BindearPropiedadEntidad = "RegimenIIBBComplem.IdRegimen"
        Me.cmbRegimenesIIBBComplem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegimenesIIBBComplem.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRegimenesIIBBComplem.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRegimenesIIBBComplem.FormattingEnabled = True
        Me.cmbRegimenesIIBBComplem.IsPK = False
        Me.cmbRegimenesIIBBComplem.IsRequired = False
        Me.cmbRegimenesIIBBComplem.Key = Nothing
        Me.cmbRegimenesIIBBComplem.LabelAsoc = Nothing
        Me.cmbRegimenesIIBBComplem.Location = New System.Drawing.Point(278, 180)
        Me.cmbRegimenesIIBBComplem.Name = "cmbRegimenesIIBBComplem"
        Me.cmbRegimenesIIBBComplem.Size = New System.Drawing.Size(304, 21)
        Me.cmbRegimenesIIBBComplem.TabIndex = 18
        '
        'lblNroRegimenIIBBComplem
        '
        Me.lblNroRegimenIIBBComplem.AutoSize = True
        Me.lblNroRegimenIIBBComplem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblNroRegimenIIBBComplem.LabelAsoc = Nothing
        Me.lblNroRegimenIIBBComplem.Location = New System.Drawing.Point(588, 185)
        Me.lblNroRegimenIIBBComplem.Name = "lblNroRegimenIIBBComplem"
        Me.lblNroRegimenIIBBComplem.Size = New System.Drawing.Size(27, 13)
        Me.lblNroRegimenIIBBComplem.TabIndex = 19
        Me.lblNroRegimenIIBBComplem.Text = "Nro."
        '
        'chbRetencionIIBBComplem
        '
        Me.chbRetencionIIBBComplem.AutoSize = True
        Me.chbRetencionIIBBComplem.BindearPropiedadControl = Nothing
        Me.chbRetencionIIBBComplem.BindearPropiedadEntidad = Nothing
        Me.chbRetencionIIBBComplem.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRetencionIIBBComplem.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRetencionIIBBComplem.IsPK = False
        Me.chbRetencionIIBBComplem.IsRequired = False
        Me.chbRetencionIIBBComplem.Key = Nothing
        Me.chbRetencionIIBBComplem.LabelAsoc = Nothing
        Me.chbRetencionIIBBComplem.Location = New System.Drawing.Point(94, 182)
        Me.chbRetencionIIBBComplem.Name = "chbRetencionIIBBComplem"
        Me.chbRetencionIIBBComplem.Size = New System.Drawing.Size(147, 17)
        Me.chbRetencionIIBBComplem.TabIndex = 17
        Me.chbRetencionIIBBComplem.Text = "Retención IIBB Complem."
        Me.chbRetencionIIBBComplem.UseVisualStyleBackColor = True
        '
        'cmbAFIPConceptoCM05
        '
        Me.cmbAFIPConceptoCM05.BindearPropiedadControl = "SelectedValue"
        Me.cmbAFIPConceptoCM05.BindearPropiedadEntidad = "IdConceptoCM05"
        Me.cmbAFIPConceptoCM05.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAFIPConceptoCM05.Enabled = False
        Me.cmbAFIPConceptoCM05.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAFIPConceptoCM05.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAFIPConceptoCM05.FormattingEnabled = True
        Me.cmbAFIPConceptoCM05.IsPK = False
        Me.cmbAFIPConceptoCM05.IsRequired = False
        Me.cmbAFIPConceptoCM05.Key = Nothing
        Me.cmbAFIPConceptoCM05.LabelAsoc = Me.chbAFIPConceptoCM05
        Me.cmbAFIPConceptoCM05.Location = New System.Drawing.Point(278, 209)
        Me.cmbAFIPConceptoCM05.Name = "cmbAFIPConceptoCM05"
        Me.cmbAFIPConceptoCM05.Size = New System.Drawing.Size(204, 21)
        Me.cmbAFIPConceptoCM05.TabIndex = 16
        '
        'chbAFIPConceptoCM05
        '
        Me.chbAFIPConceptoCM05.AutoSize = True
        Me.chbAFIPConceptoCM05.BindearPropiedadControl = ""
        Me.chbAFIPConceptoCM05.BindearPropiedadEntidad = ""
        Me.chbAFIPConceptoCM05.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAFIPConceptoCM05.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAFIPConceptoCM05.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbAFIPConceptoCM05.IsPK = False
        Me.chbAFIPConceptoCM05.IsRequired = False
        Me.chbAFIPConceptoCM05.Key = Nothing
        Me.chbAFIPConceptoCM05.LabelAsoc = Nothing
        Me.chbAFIPConceptoCM05.Location = New System.Drawing.Point(94, 211)
        Me.chbAFIPConceptoCM05.Name = "chbAFIPConceptoCM05"
        Me.chbAFIPConceptoCM05.Size = New System.Drawing.Size(103, 17)
        Me.chbAFIPConceptoCM05.TabIndex = 15
        Me.chbAFIPConceptoCM05.Text = "Concepto CM05"
        Me.chbAFIPConceptoCM05.UseVisualStyleBackColor = True
        '
        'cmbRegimenesIIBB
        '
        Me.cmbRegimenesIIBB.BindearPropiedadControl = "SelectedValue"
        Me.cmbRegimenesIIBB.BindearPropiedadEntidad = "RegimenIIBB.IdRegimen"
        Me.cmbRegimenesIIBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegimenesIIBB.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRegimenesIIBB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRegimenesIIBB.FormattingEnabled = True
        Me.cmbRegimenesIIBB.IsPK = False
        Me.cmbRegimenesIIBB.IsRequired = False
        Me.cmbRegimenesIIBB.Key = Nothing
        Me.cmbRegimenesIIBB.LabelAsoc = Nothing
        Me.cmbRegimenesIIBB.Location = New System.Drawing.Point(278, 152)
        Me.cmbRegimenesIIBB.Name = "cmbRegimenesIIBB"
        Me.cmbRegimenesIIBB.Size = New System.Drawing.Size(304, 21)
        Me.cmbRegimenesIIBB.TabIndex = 13
        '
        'lblNroRegimenIIBB
        '
        Me.lblNroRegimenIIBB.AutoSize = True
        Me.lblNroRegimenIIBB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblNroRegimenIIBB.LabelAsoc = Nothing
        Me.lblNroRegimenIIBB.Location = New System.Drawing.Point(588, 157)
        Me.lblNroRegimenIIBB.Name = "lblNroRegimenIIBB"
        Me.lblNroRegimenIIBB.Size = New System.Drawing.Size(27, 13)
        Me.lblNroRegimenIIBB.TabIndex = 14
        Me.lblNroRegimenIIBB.Text = "Nro."
        '
        'cmbRegimenesIVA
        '
        Me.cmbRegimenesIVA.BindearPropiedadControl = "SelectedValue"
        Me.cmbRegimenesIVA.BindearPropiedadEntidad = "RegimenIVA.IdRegimen"
        Me.cmbRegimenesIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegimenesIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRegimenesIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRegimenesIVA.FormattingEnabled = True
        Me.cmbRegimenesIVA.IsPK = False
        Me.cmbRegimenesIVA.IsRequired = False
        Me.cmbRegimenesIVA.Key = Nothing
        Me.cmbRegimenesIVA.LabelAsoc = Nothing
        Me.cmbRegimenesIVA.Location = New System.Drawing.Point(278, 125)
        Me.cmbRegimenesIVA.Name = "cmbRegimenesIVA"
        Me.cmbRegimenesIVA.Size = New System.Drawing.Size(304, 21)
        Me.cmbRegimenesIVA.TabIndex = 10
        '
        'lblNroRegimenIVA
        '
        Me.lblNroRegimenIVA.AutoSize = True
        Me.lblNroRegimenIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblNroRegimenIVA.LabelAsoc = Nothing
        Me.lblNroRegimenIVA.Location = New System.Drawing.Point(588, 130)
        Me.lblNroRegimenIVA.Name = "lblNroRegimenIVA"
        Me.lblNroRegimenIVA.Size = New System.Drawing.Size(27, 13)
        Me.lblNroRegimenIVA.TabIndex = 11
        Me.lblNroRegimenIVA.Text = "Nro."
        '
        'cmbRegimenesGan
        '
        Me.cmbRegimenesGan.BindearPropiedadControl = "SelectedValue"
        Me.cmbRegimenesGan.BindearPropiedadEntidad = "RegimenGAN.IdRegimen"
        Me.cmbRegimenesGan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegimenesGan.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRegimenesGan.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRegimenesGan.FormattingEnabled = True
        Me.cmbRegimenesGan.IsPK = False
        Me.cmbRegimenesGan.IsRequired = False
        Me.cmbRegimenesGan.Key = Nothing
        Me.cmbRegimenesGan.LabelAsoc = Nothing
        Me.cmbRegimenesGan.Location = New System.Drawing.Point(278, 98)
        Me.cmbRegimenesGan.Name = "cmbRegimenesGan"
        Me.cmbRegimenesGan.Size = New System.Drawing.Size(304, 21)
        Me.cmbRegimenesGan.TabIndex = 7
        '
        'cmbRegimenes
        '
        Me.cmbRegimenes.BindearPropiedadControl = "SelectedValue"
        Me.cmbRegimenes.BindearPropiedadEntidad = "Regimen.IdRegimen"
        Me.cmbRegimenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRegimenes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRegimenes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRegimenes.FormattingEnabled = True
        Me.cmbRegimenes.IsPK = False
        Me.cmbRegimenes.IsRequired = False
        Me.cmbRegimenes.Key = Nothing
        Me.cmbRegimenes.LabelAsoc = Me.lblRegimen
        Me.cmbRegimenes.Location = New System.Drawing.Point(278, 71)
        Me.cmbRegimenes.Name = "cmbRegimenes"
        Me.cmbRegimenes.Size = New System.Drawing.Size(304, 21)
        Me.cmbRegimenes.TabIndex = 4
        '
        'lblRegimen
        '
        Me.lblRegimen.AutoSize = True
        Me.lblRegimen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblRegimen.LabelAsoc = Nothing
        Me.lblRegimen.Location = New System.Drawing.Point(278, 55)
        Me.lblRegimen.Name = "lblRegimen"
        Me.lblRegimen.Size = New System.Drawing.Size(49, 13)
        Me.lblRegimen.TabIndex = 3
        Me.lblRegimen.Text = "Régimen"
        '
        'lblNroRegimenGan
        '
        Me.lblNroRegimenGan.AutoSize = True
        Me.lblNroRegimenGan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblNroRegimenGan.LabelAsoc = Nothing
        Me.lblNroRegimenGan.Location = New System.Drawing.Point(588, 103)
        Me.lblNroRegimenGan.Name = "lblNroRegimenGan"
        Me.lblNroRegimenGan.Size = New System.Drawing.Size(27, 13)
        Me.lblNroRegimenGan.TabIndex = 8
        Me.lblNroRegimenGan.Text = "Nro."
        '
        'chbPasibleRetencionIIBB
        '
        Me.chbPasibleRetencionIIBB.AutoSize = True
        Me.chbPasibleRetencionIIBB.BindearPropiedadControl = Nothing
        Me.chbPasibleRetencionIIBB.BindearPropiedadEntidad = Nothing
        Me.chbPasibleRetencionIIBB.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPasibleRetencionIIBB.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPasibleRetencionIIBB.IsPK = False
        Me.chbPasibleRetencionIIBB.IsRequired = False
        Me.chbPasibleRetencionIIBB.Key = Nothing
        Me.chbPasibleRetencionIIBB.LabelAsoc = Nothing
        Me.chbPasibleRetencionIIBB.Location = New System.Drawing.Point(94, 154)
        Me.chbPasibleRetencionIIBB.Name = "chbPasibleRetencionIIBB"
        Me.chbPasibleRetencionIIBB.Size = New System.Drawing.Size(150, 17)
        Me.chbPasibleRetencionIIBB.TabIndex = 12
        Me.chbPasibleRetencionIIBB.Text = "Pasible de Retención IIBB"
        Me.chbPasibleRetencionIIBB.UseVisualStyleBackColor = True
        '
        'lblNroRegimen
        '
        Me.lblNroRegimen.AutoSize = True
        Me.lblNroRegimen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic)
        Me.lblNroRegimen.LabelAsoc = Nothing
        Me.lblNroRegimen.Location = New System.Drawing.Point(588, 76)
        Me.lblNroRegimen.Name = "lblNroRegimen"
        Me.lblNroRegimen.Size = New System.Drawing.Size(27, 13)
        Me.lblNroRegimen.TabIndex = 5
        Me.lblNroRegimen.Text = "Nro."
        '
        'chbPasibleRetencionIVA
        '
        Me.chbPasibleRetencionIVA.AutoSize = True
        Me.chbPasibleRetencionIVA.BindearPropiedadControl = Nothing
        Me.chbPasibleRetencionIVA.BindearPropiedadEntidad = Nothing
        Me.chbPasibleRetencionIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPasibleRetencionIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPasibleRetencionIVA.IsPK = False
        Me.chbPasibleRetencionIVA.IsRequired = False
        Me.chbPasibleRetencionIVA.Key = Nothing
        Me.chbPasibleRetencionIVA.LabelAsoc = Nothing
        Me.chbPasibleRetencionIVA.Location = New System.Drawing.Point(94, 127)
        Me.chbPasibleRetencionIVA.Name = "chbPasibleRetencionIVA"
        Me.chbPasibleRetencionIVA.Size = New System.Drawing.Size(147, 17)
        Me.chbPasibleRetencionIVA.TabIndex = 9
        Me.chbPasibleRetencionIVA.Text = "Pasible de Retención IVA"
        Me.chbPasibleRetencionIVA.UseVisualStyleBackColor = True
        '
        'chbPasibleRetencion2
        '
        Me.chbPasibleRetencion2.AutoSize = True
        Me.chbPasibleRetencion2.BindearPropiedadControl = Nothing
        Me.chbPasibleRetencion2.BindearPropiedadEntidad = Nothing
        Me.chbPasibleRetencion2.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPasibleRetencion2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPasibleRetencion2.IsPK = False
        Me.chbPasibleRetencion2.IsRequired = False
        Me.chbPasibleRetencion2.Key = Nothing
        Me.chbPasibleRetencion2.LabelAsoc = Nothing
        Me.chbPasibleRetencion2.Location = New System.Drawing.Point(94, 100)
        Me.chbPasibleRetencion2.Name = "chbPasibleRetencion2"
        Me.chbPasibleRetencion2.Size = New System.Drawing.Size(182, 17)
        Me.chbPasibleRetencion2.TabIndex = 6
        Me.chbPasibleRetencion2.Text = "Retención Ganancias Alternativa"
        Me.chbPasibleRetencion2.UseVisualStyleBackColor = True
        '
        'chbPasibleRetencion
        '
        Me.chbPasibleRetencion.AutoSize = True
        Me.chbPasibleRetencion.BindearPropiedadControl = Nothing
        Me.chbPasibleRetencion.BindearPropiedadEntidad = Nothing
        Me.chbPasibleRetencion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPasibleRetencion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPasibleRetencion.IsPK = False
        Me.chbPasibleRetencion.IsRequired = False
        Me.chbPasibleRetencion.Key = Nothing
        Me.chbPasibleRetencion.LabelAsoc = Nothing
        Me.chbPasibleRetencion.Location = New System.Drawing.Point(94, 73)
        Me.chbPasibleRetencion.Name = "chbPasibleRetencion"
        Me.chbPasibleRetencion.Size = New System.Drawing.Size(181, 17)
        Me.chbPasibleRetencion.TabIndex = 2
        Me.chbPasibleRetencion.Text = "Pasible de Retención Ganancias"
        Me.chbPasibleRetencion.UseVisualStyleBackColor = True
        '
        'txtIngresosBrutos
        '
        Me.txtIngresosBrutos.BindearPropiedadControl = "Text"
        Me.txtIngresosBrutos.BindearPropiedadEntidad = "IngresosBrutos"
        Me.txtIngresosBrutos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIngresosBrutos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIngresosBrutos.Formato = ""
        Me.txtIngresosBrutos.IsDecimal = False
        Me.txtIngresosBrutos.IsNumber = False
        Me.txtIngresosBrutos.IsPK = False
        Me.txtIngresosBrutos.IsRequired = False
        Me.txtIngresosBrutos.Key = ""
        Me.txtIngresosBrutos.LabelAsoc = Me.lblIngresosBrutos
        Me.txtIngresosBrutos.Location = New System.Drawing.Point(163, 30)
        Me.txtIngresosBrutos.MaxLength = 20
        Me.txtIngresosBrutos.Name = "txtIngresosBrutos"
        Me.txtIngresosBrutos.Size = New System.Drawing.Size(135, 20)
        Me.txtIngresosBrutos.TabIndex = 1
        '
        'lblIngresosBrutos
        '
        Me.lblIngresosBrutos.AutoSize = True
        Me.lblIngresosBrutos.LabelAsoc = Nothing
        Me.lblIngresosBrutos.Location = New System.Drawing.Point(98, 34)
        Me.lblIngresosBrutos.Name = "lblIngresosBrutos"
        Me.lblIngresosBrutos.Size = New System.Drawing.Size(58, 13)
        Me.lblIngresosBrutos.TabIndex = 0
        Me.lblIngresosBrutos.Text = "Ing. Brutos"
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
        Me.txtNivelAutorizacion.Location = New System.Drawing.Point(551, 179)
        Me.txtNivelAutorizacion.MaxLength = 12
        Me.txtNivelAutorizacion.Name = "txtNivelAutorizacion"
        Me.txtNivelAutorizacion.Size = New System.Drawing.Size(42, 20)
        Me.txtNivelAutorizacion.TabIndex = 29
        Me.txtNivelAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNivelAutorizacion
        '
        Me.lblNivelAutorizacion.AutoSize = True
        Me.lblNivelAutorizacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelAutorizacion.LabelAsoc = Nothing
        Me.lblNivelAutorizacion.Location = New System.Drawing.Point(453, 183)
        Me.lblNivelAutorizacion.Name = "lblNivelAutorizacion"
        Me.lblNivelAutorizacion.Size = New System.Drawing.Size(92, 13)
        Me.lblNivelAutorizacion.TabIndex = 28
        Me.lblNivelAutorizacion.Text = "Nivel Autorización"
        '
        'bscNombreCuentaBanco
        '
        Me.bscNombreCuentaBanco.ActivarFiltroEnGrilla = True
        Me.bscNombreCuentaBanco.AutoSize = True
        Me.bscNombreCuentaBanco.BindearPropiedadControl = ""
        Me.bscNombreCuentaBanco.BindearPropiedadEntidad = ""
        Me.bscNombreCuentaBanco.ConfigBuscador = Nothing
        Me.bscNombreCuentaBanco.Datos = Nothing
        Me.bscNombreCuentaBanco.FilaDevuelta = Nothing
        Me.bscNombreCuentaBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreCuentaBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCuentaBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCuentaBanco.IsDecimal = False
        Me.bscNombreCuentaBanco.IsNumber = False
        Me.bscNombreCuentaBanco.IsPK = False
        Me.bscNombreCuentaBanco.IsRequired = True
        Me.bscNombreCuentaBanco.Key = ""
        Me.bscNombreCuentaBanco.LabelAsoc = Me.Label4
        Me.bscNombreCuentaBanco.Location = New System.Drawing.Point(174, 99)
        Me.bscNombreCuentaBanco.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCuentaBanco.MaxLengh = "30"
        Me.bscNombreCuentaBanco.Name = "bscNombreCuentaBanco"
        Me.bscNombreCuentaBanco.Permitido = True
        Me.bscNombreCuentaBanco.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCuentaBanco.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCuentaBanco.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCuentaBanco.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCuentaBanco.Selecciono = False
        Me.bscNombreCuentaBanco.Size = New System.Drawing.Size(235, 23)
        Me.bscNombreCuentaBanco.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(39, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cuenta Banco"
        '
        'txtNombreDeFantasia
        '
        Me.txtNombreDeFantasia.BindearPropiedadControl = "Text"
        Me.txtNombreDeFantasia.BindearPropiedadEntidad = "NombreDeFantasia"
        Me.txtNombreDeFantasia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreDeFantasia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreDeFantasia.Formato = ""
        Me.txtNombreDeFantasia.IsDecimal = False
        Me.txtNombreDeFantasia.IsNumber = False
        Me.txtNombreDeFantasia.IsPK = False
        Me.txtNombreDeFantasia.IsRequired = False
        Me.txtNombreDeFantasia.Key = ""
        Me.txtNombreDeFantasia.LabelAsoc = Me.lblNombreDeFantasia
        Me.txtNombreDeFantasia.Location = New System.Drawing.Point(89, 73)
        Me.txtNombreDeFantasia.MaxLength = 50
        Me.txtNombreDeFantasia.Name = "txtNombreDeFantasia"
        Me.txtNombreDeFantasia.Size = New System.Drawing.Size(337, 20)
        Me.txtNombreDeFantasia.TabIndex = 6
        '
        'lblNombreDeFantasia
        '
        Me.lblNombreDeFantasia.AutoSize = True
        Me.lblNombreDeFantasia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombreDeFantasia.LabelAsoc = Nothing
        Me.lblNombreDeFantasia.Location = New System.Drawing.Point(22, 77)
        Me.lblNombreDeFantasia.Name = "lblNombreDeFantasia"
        Me.lblNombreDeFantasia.Size = New System.Drawing.Size(61, 13)
        Me.lblNombreDeFantasia.TabIndex = 5
        Me.lblNombreDeFantasia.Text = "N. Fantasia"
        '
        'lblTipoDoc
        '
        Me.lblTipoDoc.AutoSize = True
        Me.lblTipoDoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipoDoc.LabelAsoc = Nothing
        Me.lblTipoDoc.Location = New System.Drawing.Point(453, 130)
        Me.lblTipoDoc.Name = "lblTipoDoc"
        Me.lblTipoDoc.Size = New System.Drawing.Size(85, 13)
        Me.lblTipoDoc.TabIndex = 23
        Me.lblTipoDoc.Text = "Tipo y Nro. Doc."
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoDoc.BindearPropiedadEntidad = "TipoDocProveedor"
        Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDoc.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.IsPK = False
        Me.cmbTipoDoc.IsRequired = False
        Me.cmbTipoDoc.Key = Nothing
        Me.cmbTipoDoc.LabelAsoc = Me.lblTipoDoc
        Me.cmbTipoDoc.Location = New System.Drawing.Point(551, 126)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(62, 21)
        Me.cmbTipoDoc.TabIndex = 24
        '
        'txtNroDoc
        '
        Me.txtNroDoc.BindearPropiedadControl = "Text"
        Me.txtNroDoc.BindearPropiedadEntidad = "NroDocProveedor"
        Me.txtNroDoc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDoc.Formato = ""
        Me.txtNroDoc.IsDecimal = False
        Me.txtNroDoc.IsNumber = True
        Me.txtNroDoc.IsPK = False
        Me.txtNroDoc.IsRequired = False
        Me.txtNroDoc.Key = ""
        Me.txtNroDoc.LabelAsoc = Nothing
        Me.txtNroDoc.Location = New System.Drawing.Point(619, 126)
        Me.txtNroDoc.MaxLength = 12
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.Size = New System.Drawing.Size(90, 20)
        Me.txtNroDoc.TabIndex = 25
        Me.txtNroDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbPorCtaOrden
        '
        Me.chbPorCtaOrden.AutoSize = True
        Me.chbPorCtaOrden.BindearPropiedadControl = "Checked"
        Me.chbPorCtaOrden.BindearPropiedadEntidad = "PorCtaOrden"
        Me.chbPorCtaOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorCtaOrden.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorCtaOrden.IsPK = False
        Me.chbPorCtaOrden.IsRequired = False
        Me.chbPorCtaOrden.Key = Nothing
        Me.chbPorCtaOrden.LabelAsoc = Nothing
        Me.chbPorCtaOrden.Location = New System.Drawing.Point(615, 181)
        Me.chbPorCtaOrden.Name = "chbPorCtaOrden"
        Me.chbPorCtaOrden.Size = New System.Drawing.Size(119, 17)
        Me.chbPorCtaOrden.TabIndex = 30
        Me.chbPorCtaOrden.Text = "Por Cuenta y Orden"
        Me.chbPorCtaOrden.UseVisualStyleBackColor = True
        '
        'chbFormaPago
        '
        Me.chbFormaPago.AutoSize = True
        Me.chbFormaPago.BindearPropiedadControl = Nothing
        Me.chbFormaPago.BindearPropiedadEntidad = Nothing
        Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormaPago.IsPK = False
        Me.chbFormaPago.IsRequired = False
        Me.chbFormaPago.Key = Nothing
        Me.chbFormaPago.LabelAsoc = Nothing
        Me.chbFormaPago.Location = New System.Drawing.Point(20, 46)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFormaPago.TabIndex = 2
        Me.chbFormaPago.Text = "Forma de Pago"
        Me.chbFormaPago.UseVisualStyleBackColor = True
        '
        'lblDescuentoRecargoPorc
        '
        Me.lblDescuentoRecargoPorc.AutoSize = True
        Me.lblDescuentoRecargoPorc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoRecargoPorc.LabelAsoc = Nothing
        Me.lblDescuentoRecargoPorc.Location = New System.Drawing.Point(453, 157)
        Me.lblDescuentoRecargoPorc.Name = "lblDescuentoRecargoPorc"
        Me.lblDescuentoRecargoPorc.Size = New System.Drawing.Size(87, 13)
        Me.lblDescuentoRecargoPorc.TabIndex = 26
        Me.lblDescuentoRecargoPorc.Text = "Desc. / Recargo"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = "SelectedValue"
        Me.cmbFormaPago.BindearPropiedadEntidad = "IdFormasPago"
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Nothing
        Me.cmbFormaPago.Location = New System.Drawing.Point(174, 44)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(235, 21)
        Me.cmbFormaPago.TabIndex = 3
        '
        'txtDescuentoRecargoPorc
        '
        Me.txtDescuentoRecargoPorc.BindearPropiedadControl = "Text"
        Me.txtDescuentoRecargoPorc.BindearPropiedadEntidad = "DescuentoRecargoPorc"
        Me.txtDescuentoRecargoPorc.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescuentoRecargoPorc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescuentoRecargoPorc.Formato = "##0.00"
        Me.txtDescuentoRecargoPorc.IsDecimal = True
        Me.txtDescuentoRecargoPorc.IsNumber = True
        Me.txtDescuentoRecargoPorc.IsPK = False
        Me.txtDescuentoRecargoPorc.IsRequired = False
        Me.txtDescuentoRecargoPorc.Key = ""
        Me.txtDescuentoRecargoPorc.LabelAsoc = Me.lblDescuentoRecargoPorc
        Me.txtDescuentoRecargoPorc.Location = New System.Drawing.Point(551, 153)
        Me.txtDescuentoRecargoPorc.MaxLength = 6
        Me.txtDescuentoRecargoPorc.Name = "txtDescuentoRecargoPorc"
        Me.txtDescuentoRecargoPorc.Size = New System.Drawing.Size(56, 20)
        Me.txtDescuentoRecargoPorc.TabIndex = 27
        Me.txtDescuentoRecargoPorc.Text = "0.00"
        Me.txtDescuentoRecargoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscNombreCuentaCaja
        '
        Me.bscNombreCuentaCaja.AutoSize = True
        Me.bscNombreCuentaCaja.AyudaAncho = 608
        Me.bscNombreCuentaCaja.BindearPropiedadControl = ""
        Me.bscNombreCuentaCaja.BindearPropiedadEntidad = ""
        Me.bscNombreCuentaCaja.ColumnasAlineacion = Nothing
        Me.bscNombreCuentaCaja.ColumnasAncho = Nothing
        Me.bscNombreCuentaCaja.ColumnasFormato = Nothing
        Me.bscNombreCuentaCaja.ColumnasOcultas = Nothing
        Me.bscNombreCuentaCaja.ColumnasTitulos = Nothing
        Me.bscNombreCuentaCaja.Datos = Nothing
        Me.bscNombreCuentaCaja.FilaDevuelta = Nothing
        Me.bscNombreCuentaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCuentaCaja.IsDecimal = False
        Me.bscNombreCuentaCaja.IsNumber = False
        Me.bscNombreCuentaCaja.IsPK = False
        Me.bscNombreCuentaCaja.IsRequired = True
        Me.bscNombreCuentaCaja.Key = ""
        Me.bscNombreCuentaCaja.LabelAsoc = Me.lblCuentaCaja
        Me.bscNombreCuentaCaja.Location = New System.Drawing.Point(174, 72)
        Me.bscNombreCuentaCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCuentaCaja.MaxLengh = "30"
        Me.bscNombreCuentaCaja.Name = "bscNombreCuentaCaja"
        Me.bscNombreCuentaCaja.Permitido = True
        Me.bscNombreCuentaCaja.Selecciono = False
        Me.bscNombreCuentaCaja.Size = New System.Drawing.Size(235, 23)
        Me.bscNombreCuentaCaja.TabIndex = 5
        Me.bscNombreCuentaCaja.Titulo = Nothing
        '
        'lblCuentaCaja
        '
        Me.lblCuentaCaja.AutoSize = True
        Me.lblCuentaCaja.LabelAsoc = Nothing
        Me.lblCuentaCaja.Location = New System.Drawing.Point(39, 77)
        Me.lblCuentaCaja.Name = "lblCuentaCaja"
        Me.lblCuentaCaja.Size = New System.Drawing.Size(65, 13)
        Me.lblCuentaCaja.TabIndex = 4
        Me.lblCuentaCaja.Text = "Cuenta Caja"
        '
        'txtCuit
        '
        Me.txtCuit.BindearPropiedadControl = "Text"
        Me.txtCuit.BindearPropiedadEntidad = "CuitProveedor"
        Me.txtCuit.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCuit.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCuit.Formato = ""
        Me.txtCuit.IsDecimal = False
        Me.txtCuit.IsNumber = False
        Me.txtCuit.IsPK = False
        Me.txtCuit.IsRequired = False
        Me.txtCuit.Key = ""
        Me.txtCuit.LabelAsoc = Me.lblCuit
        Me.txtCuit.Location = New System.Drawing.Point(551, 100)
        Me.txtCuit.MaxLength = 11
        Me.txtCuit.Name = "txtCuit"
        Me.txtCuit.Size = New System.Drawing.Size(98, 20)
        Me.txtCuit.TabIndex = 22
        '
        'lblCuit
        '
        Me.lblCuit.AutoSize = True
        Me.lblCuit.LabelAsoc = Nothing
        Me.lblCuit.Location = New System.Drawing.Point(453, 104)
        Me.lblCuit.Name = "lblCuit"
        Me.lblCuit.Size = New System.Drawing.Size(32, 13)
        Me.lblCuit.TabIndex = 21
        Me.lblCuit.Text = "CUIT"
        '
        'lblCategoriaFiscal
        '
        Me.lblCategoriaFiscal.AutoSize = True
        Me.lblCategoriaFiscal.LabelAsoc = Nothing
        Me.lblCategoriaFiscal.Location = New System.Drawing.Point(453, 23)
        Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
        Me.lblCategoriaFiscal.Size = New System.Drawing.Size(56, 13)
        Me.lblCategoriaFiscal.TabIndex = 15
        Me.lblCategoriaFiscal.Text = "Cat. Fiscal"
        '
        'cmbCategoriaFiscal
        '
        Me.cmbCategoriaFiscal.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoriaFiscal.BindearPropiedadEntidad = "CategoriaFiscal.idCategoriaFiscal"
        Me.cmbCategoriaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriaFiscal.FormattingEnabled = True
        Me.cmbCategoriaFiscal.IsPK = False
        Me.cmbCategoriaFiscal.IsRequired = True
        Me.cmbCategoriaFiscal.Key = Nothing
        Me.cmbCategoriaFiscal.LabelAsoc = Me.lblCategoriaFiscal
        Me.cmbCategoriaFiscal.Location = New System.Drawing.Point(551, 19)
        Me.cmbCategoriaFiscal.Name = "cmbCategoriaFiscal"
        Me.cmbCategoriaFiscal.Size = New System.Drawing.Size(183, 21)
        Me.cmbCategoriaFiscal.TabIndex = 16
        '
        'chbComprobanteDeCompras
        '
        Me.chbComprobanteDeCompras.AutoSize = True
        Me.chbComprobanteDeCompras.BindearPropiedadControl = Nothing
        Me.chbComprobanteDeCompras.BindearPropiedadEntidad = Nothing
        Me.chbComprobanteDeCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.chbComprobanteDeCompras.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbComprobanteDeCompras.IsPK = False
        Me.chbComprobanteDeCompras.IsRequired = False
        Me.chbComprobanteDeCompras.Key = Nothing
        Me.chbComprobanteDeCompras.LabelAsoc = Nothing
        Me.chbComprobanteDeCompras.Location = New System.Drawing.Point(20, 19)
        Me.chbComprobanteDeCompras.Name = "chbComprobanteDeCompras"
        Me.chbComprobanteDeCompras.Size = New System.Drawing.Size(148, 17)
        Me.chbComprobanteDeCompras.TabIndex = 0
        Me.chbComprobanteDeCompras.Text = "Comprobante de Compras"
        Me.chbComprobanteDeCompras.UseVisualStyleBackColor = True
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = "IdTipoComprobante"
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Enabled = False
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Nothing
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(174, 17)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(235, 21)
        Me.cmbTiposComprobantes.TabIndex = 1
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCategoria.LabelAsoc = Nothing
        Me.lblCategoria.Location = New System.Drawing.Point(453, 50)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(52, 13)
        Me.lblCategoria.TabIndex = 17
        Me.lblCategoria.Text = "Categoria"
        '
        'cmbCategorias
        '
        Me.cmbCategorias.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategorias.BindearPropiedadEntidad = "Categoria.IdCategoria"
        Me.cmbCategorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategorias.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategorias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategorias.FormattingEnabled = True
        Me.cmbCategorias.IsPK = False
        Me.cmbCategorias.IsRequired = True
        Me.cmbCategorias.Key = Nothing
        Me.cmbCategorias.LabelAsoc = Me.lblCategoria
        Me.cmbCategorias.Location = New System.Drawing.Point(551, 46)
        Me.cmbCategorias.Name = "cmbCategorias"
        Me.cmbCategorias.Size = New System.Drawing.Size(183, 21)
        Me.cmbCategorias.TabIndex = 18
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(453, 77)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 19
        Me.lblRubro.Text = "Rubro"
        '
        'cboRubro
        '
        Me.cboRubro.BindearPropiedadControl = "SelectedValue"
        Me.cboRubro.BindearPropiedadEntidad = "RubroCompra.IdRubro"
        Me.cboRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.cboRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboRubro.FormattingEnabled = True
        Me.cboRubro.IsPK = False
        Me.cboRubro.IsRequired = True
        Me.cboRubro.Key = Nothing
        Me.cboRubro.LabelAsoc = Me.lblRubro
        Me.cboRubro.Location = New System.Drawing.Point(551, 73)
        Me.cboRubro.Name = "cboRubro"
        Me.cboRubro.Size = New System.Drawing.Size(183, 21)
        Me.cboRubro.TabIndex = 20
        '
        'bscCuentaCaja
        '
        Me.bscCuentaCaja.AyudaAncho = 608
        Me.bscCuentaCaja.BindearPropiedadControl = "Text"
        Me.bscCuentaCaja.BindearPropiedadEntidad = "CuentaDeCaja.IdCuentaCaja"
        Me.bscCuentaCaja.ColumnasAlineacion = Nothing
        Me.bscCuentaCaja.ColumnasAncho = Nothing
        Me.bscCuentaCaja.ColumnasFormato = Nothing
        Me.bscCuentaCaja.ColumnasOcultas = Nothing
        Me.bscCuentaCaja.ColumnasTitulos = Nothing
        Me.bscCuentaCaja.Datos = Nothing
        Me.bscCuentaCaja.FilaDevuelta = Nothing
        Me.bscCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaCaja.IsDecimal = False
        Me.bscCuentaCaja.IsNumber = True
        Me.bscCuentaCaja.IsPK = False
        Me.bscCuentaCaja.IsRequired = False
        Me.bscCuentaCaja.Key = ""
        Me.bscCuentaCaja.LabelAsoc = Me.lblCuentaCaja
        Me.bscCuentaCaja.Location = New System.Drawing.Point(280, 4)
        Me.bscCuentaCaja.MaxLengh = "32767"
        Me.bscCuentaCaja.Name = "bscCuentaCaja"
        Me.bscCuentaCaja.Permitido = True
        Me.bscCuentaCaja.Selecciono = False
        Me.bscCuentaCaja.Size = New System.Drawing.Size(28, 23)
        Me.bscCuentaCaja.TabIndex = 5
        Me.bscCuentaCaja.TabStop = False
        Me.bscCuentaCaja.Titulo = Nothing
        '
        'tbpDatos
        '
        Me.tbpDatos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDatos.Controls.Add(Me.grbUbicacion)
        Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatos.Name = "tbpDatos"
        Me.tbpDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDatos.Size = New System.Drawing.Size(772, 324)
        Me.tbpDatos.TabIndex = 1
        Me.tbpDatos.Text = "Datos"
        '
        'grbUbicacion
        '
        Me.grbUbicacion.Controls.Add(Me.chbPorCtaOrden)
        Me.grbUbicacion.Controls.Add(Me.lblCorreoAdm)
        Me.grbUbicacion.Controls.Add(Me.txtNombreDeFantasia)
        Me.grbUbicacion.Controls.Add(Me.txtCorreoAdm)
        Me.grbUbicacion.Controls.Add(Me.lblNombreDeFantasia)
        Me.grbUbicacion.Controls.Add(Me.txtDireccion)
        Me.grbUbicacion.Controls.Add(Me.txtNivelAutorizacion)
        Me.grbUbicacion.Controls.Add(Me.lblDireccion)
        Me.grbUbicacion.Controls.Add(Me.bscNombreLocalidad)
        Me.grbUbicacion.Controls.Add(Me.lblNivelAutorizacion)
        Me.grbUbicacion.Controls.Add(Me.bscCodigoLocalidad)
        Me.grbUbicacion.Controls.Add(Me.lnkLocalidad)
        Me.grbUbicacion.Controls.Add(Me.txtFax)
        Me.grbUbicacion.Controls.Add(Me.txtTelefono)
        Me.grbUbicacion.Controls.Add(Me.lblTelefono)
        Me.grbUbicacion.Controls.Add(Me.lblFax)
        Me.grbUbicacion.Controls.Add(Me.txtCorreoElectronico)
        Me.grbUbicacion.Controls.Add(Me.lblCorreoElectronico)
        Me.grbUbicacion.Controls.Add(Me.lblTipoDoc)
        Me.grbUbicacion.Controls.Add(Me.cmbCategorias)
        Me.grbUbicacion.Controls.Add(Me.txtCuit)
        Me.grbUbicacion.Controls.Add(Me.cmbTipoDoc)
        Me.grbUbicacion.Controls.Add(Me.lblCuit)
        Me.grbUbicacion.Controls.Add(Me.lblCategoriaFiscal)
        Me.grbUbicacion.Controls.Add(Me.txtNroDoc)
        Me.grbUbicacion.Controls.Add(Me.txtDescuentoRecargoPorc)
        Me.grbUbicacion.Controls.Add(Me.cmbCategoriaFiscal)
        Me.grbUbicacion.Controls.Add(Me.cboRubro)
        Me.grbUbicacion.Controls.Add(Me.lblCategoria)
        Me.grbUbicacion.Controls.Add(Me.lblRubro)
        Me.grbUbicacion.Controls.Add(Me.lblDescuentoRecargoPorc)
        Me.grbUbicacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbUbicacion.Location = New System.Drawing.Point(3, 3)
        Me.grbUbicacion.Name = "grbUbicacion"
        Me.grbUbicacion.Size = New System.Drawing.Size(766, 318)
        Me.grbUbicacion.TabIndex = 0
        Me.grbUbicacion.TabStop = False
        '
        'lblCorreoAdm
        '
        Me.lblCorreoAdm.AutoSize = True
        Me.lblCorreoAdm.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCorreoAdm.LabelAsoc = Nothing
        Me.lblCorreoAdm.Location = New System.Drawing.Point(22, 210)
        Me.lblCorreoAdm.Name = "lblCorreoAdm"
        Me.lblCorreoAdm.Size = New System.Drawing.Size(62, 13)
        Me.lblCorreoAdm.TabIndex = 13
        Me.lblCorreoAdm.Text = "E-mail Adm."
        '
        'txtCorreoAdm
        '
        Me.txtCorreoAdm.BindearPropiedadControl = "Text"
        Me.txtCorreoAdm.BindearPropiedadEntidad = "CorreoAdministrativo"
        Me.txtCorreoAdm.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCorreoAdm.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCorreoAdm.Formato = ""
        Me.txtCorreoAdm.IsDecimal = False
        Me.txtCorreoAdm.IsNumber = False
        Me.txtCorreoAdm.IsPK = False
        Me.txtCorreoAdm.IsRequired = False
        Me.txtCorreoAdm.Key = Nothing
        Me.txtCorreoAdm.LabelAsoc = Me.lblCorreoAdm
        Me.txtCorreoAdm.Location = New System.Drawing.Point(89, 206)
        Me.txtCorreoAdm.MaxLength = 250
        Me.txtCorreoAdm.Multiline = True
        Me.txtCorreoAdm.Name = "txtCorreoAdm"
        Me.txtCorreoAdm.Size = New System.Drawing.Size(337, 47)
        Me.txtCorreoAdm.TabIndex = 14
        '
        'txtDireccion
        '
        Me.txtDireccion.BindearPropiedadControl = "Text"
        Me.txtDireccion.BindearPropiedadEntidad = "DireccionProveedor"
        Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDireccion.Formato = ""
        Me.txtDireccion.IsDecimal = False
        Me.txtDireccion.IsNumber = False
        Me.txtDireccion.IsPK = False
        Me.txtDireccion.IsRequired = True
        Me.txtDireccion.Key = ""
        Me.txtDireccion.LabelAsoc = Me.lblDireccion
        Me.txtDireccion.Location = New System.Drawing.Point(89, 19)
        Me.txtDireccion.MaxLength = 100
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(337, 20)
        Me.txtDireccion.TabIndex = 1
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.LabelAsoc = Nothing
        Me.lblDireccion.Location = New System.Drawing.Point(22, 23)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
        Me.lblDireccion.TabIndex = 0
        Me.lblDireccion.Text = "Dirección"
        '
        'bscNombreLocalidad
        '
        Me.bscNombreLocalidad.AyudaAncho = 608
        Me.bscNombreLocalidad.BindearPropiedadControl = Nothing
        Me.bscNombreLocalidad.BindearPropiedadEntidad = Nothing
        Me.bscNombreLocalidad.ColumnasAlineacion = Nothing
        Me.bscNombreLocalidad.ColumnasAncho = Nothing
        Me.bscNombreLocalidad.ColumnasFormato = Nothing
        Me.bscNombreLocalidad.ColumnasOcultas = Nothing
        Me.bscNombreLocalidad.ColumnasTitulos = Nothing
        Me.bscNombreLocalidad.Datos = Nothing
        Me.bscNombreLocalidad.FilaDevuelta = Nothing
        Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreLocalidad.IsDecimal = False
        Me.bscNombreLocalidad.IsNumber = False
        Me.bscNombreLocalidad.IsPK = False
        Me.bscNombreLocalidad.IsRequired = False
        Me.bscNombreLocalidad.Key = ""
        Me.bscNombreLocalidad.LabelAsoc = Nothing
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(176, 46)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = True
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(250, 20)
        Me.bscNombreLocalidad.TabIndex = 4
        Me.bscNombreLocalidad.Titulo = Nothing
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.AyudaAncho = 608
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidadProveedor"
        Me.bscCodigoLocalidad.ColumnasAlineacion = Nothing
        Me.bscCodigoLocalidad.ColumnasAncho = Nothing
        Me.bscCodigoLocalidad.ColumnasFormato = Nothing
        Me.bscCodigoLocalidad.ColumnasOcultas = Nothing
        Me.bscCodigoLocalidad.ColumnasTitulos = Nothing
        Me.bscCodigoLocalidad.Datos = Nothing
        Me.bscCodigoLocalidad.FilaDevuelta = Nothing
        Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoLocalidad.IsDecimal = False
        Me.bscCodigoLocalidad.IsNumber = False
        Me.bscCodigoLocalidad.IsPK = False
        Me.bscCodigoLocalidad.IsRequired = True
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Nothing
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(89, 46)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = True
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(82, 20)
        Me.bscCodigoLocalidad.TabIndex = 3
        Me.bscCodigoLocalidad.Titulo = Nothing
        '
        'lnkLocalidad
        '
        Me.lnkLocalidad.AutoSize = True
        Me.lnkLocalidad.LabelAsoc = Nothing
        Me.lnkLocalidad.Location = New System.Drawing.Point(22, 50)
        Me.lnkLocalidad.Name = "lnkLocalidad"
        Me.lnkLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lnkLocalidad.TabIndex = 2
        Me.lnkLocalidad.TabStop = True
        Me.lnkLocalidad.Text = "Localidad"
        '
        'txtFax
        '
        Me.txtFax.BindearPropiedadControl = "Text"
        Me.txtFax.BindearPropiedadEntidad = "FaxProveedor"
        Me.txtFax.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFax.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFax.Formato = ""
        Me.txtFax.IsDecimal = False
        Me.txtFax.IsNumber = False
        Me.txtFax.IsPK = False
        Me.txtFax.IsRequired = False
        Me.txtFax.Key = ""
        Me.txtFax.LabelAsoc = Me.lblFax
        Me.txtFax.Location = New System.Drawing.Point(89, 126)
        Me.txtFax.MaxLength = 50
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(337, 20)
        Me.txtFax.TabIndex = 10
        '
        'lblFax
        '
        Me.lblFax.AutoSize = True
        Me.lblFax.LabelAsoc = Nothing
        Me.lblFax.Location = New System.Drawing.Point(22, 130)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(24, 13)
        Me.lblFax.TabIndex = 9
        Me.lblFax.Text = "Fax"
        '
        'txtTelefono
        '
        Me.txtTelefono.BindearPropiedadControl = "Text"
        Me.txtTelefono.BindearPropiedadEntidad = "TelefonoProveedor"
        Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTelefono.Formato = ""
        Me.txtTelefono.IsDecimal = False
        Me.txtTelefono.IsNumber = False
        Me.txtTelefono.IsPK = False
        Me.txtTelefono.IsRequired = False
        Me.txtTelefono.Key = ""
        Me.txtTelefono.LabelAsoc = Me.lblTelefono
        Me.txtTelefono.Location = New System.Drawing.Point(89, 100)
        Me.txtTelefono.MaxLength = 100
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(337, 20)
        Me.txtTelefono.TabIndex = 8
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.LabelAsoc = Nothing
        Me.lblTelefono.Location = New System.Drawing.Point(22, 104)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
        Me.lblTelefono.TabIndex = 7
        Me.lblTelefono.Text = "Teléfono"
        '
        'txtCorreoElectronico
        '
        Me.txtCorreoElectronico.BindearPropiedadControl = "Text"
        Me.txtCorreoElectronico.BindearPropiedadEntidad = "CorreoElectronico"
        Me.txtCorreoElectronico.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCorreoElectronico.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCorreoElectronico.Formato = ""
        Me.txtCorreoElectronico.IsDecimal = False
        Me.txtCorreoElectronico.IsNumber = False
        Me.txtCorreoElectronico.IsPK = False
        Me.txtCorreoElectronico.IsRequired = False
        Me.txtCorreoElectronico.Key = Nothing
        Me.txtCorreoElectronico.LabelAsoc = Me.lblCorreoElectronico
        Me.txtCorreoElectronico.Location = New System.Drawing.Point(89, 152)
        Me.txtCorreoElectronico.MaxLength = 250
        Me.txtCorreoElectronico.Multiline = True
        Me.txtCorreoElectronico.Name = "txtCorreoElectronico"
        Me.txtCorreoElectronico.Size = New System.Drawing.Size(337, 47)
        Me.txtCorreoElectronico.TabIndex = 12
        '
        'lblCorreoElectronico
        '
        Me.lblCorreoElectronico.AutoSize = True
        Me.lblCorreoElectronico.LabelAsoc = Nothing
        Me.lblCorreoElectronico.Location = New System.Drawing.Point(22, 157)
        Me.lblCorreoElectronico.Name = "lblCorreoElectronico"
        Me.lblCorreoElectronico.Size = New System.Drawing.Size(35, 13)
        Me.lblCorreoElectronico.TabIndex = 11
        Me.lblCorreoElectronico.Text = "E-mail"
        '
        'tbcProveedor
        '
        Me.tbcProveedor.Controls.Add(Me.tbpDatos)
        Me.tbcProveedor.Controls.Add(Me.tbpOtros)
        Me.tbcProveedor.Controls.Add(Me.tbpImpuestos)
        Me.tbcProveedor.Controls.Add(Me.tbpLogo)
        Me.tbcProveedor.Controls.Add(Me.tbpContratistas)
        Me.tbcProveedor.Controls.Add(Me.tbpContabilidad)
        Me.tbcProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbcProveedor.ItemSize = New System.Drawing.Size(80, 18)
        Me.tbcProveedor.Location = New System.Drawing.Point(0, 58)
        Me.tbcProveedor.Name = "tbcProveedor"
        Me.tbcProveedor.SelectedIndex = 0
        Me.tbcProveedor.Size = New System.Drawing.Size(780, 350)
        Me.tbcProveedor.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tbcProveedor.TabIndex = 1
        Me.tbcProveedor.TabStop = False
        '
        'tbpOtros
        '
        Me.tbpOtros.BackColor = System.Drawing.SystemColors.Control
        Me.tbpOtros.Controls.Add(Me.GroupBox1)
        Me.tbpOtros.Location = New System.Drawing.Point(4, 22)
        Me.tbpOtros.Name = "tbpOtros"
        Me.tbpOtros.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOtros.Size = New System.Drawing.Size(772, 324)
        Me.tbpOtros.TabIndex = 2
        Me.tbpOtros.Text = "Otros"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bscCodigoClienteVinculado)
        Me.GroupBox1.Controls.Add(Me.chbClienteVinculado)
        Me.GroupBox1.Controls.Add(Me.bscNombreClienteVinculado)
        Me.GroupBox1.Controls.Add(Me.chbTransportista)
        Me.GroupBox1.Controls.Add(Me.bscNombreTransportista)
        Me.GroupBox1.Controls.Add(Me.txtNroCuenta)
        Me.GroupBox1.Controls.Add(Me.lblNroCuenta)
        Me.GroupBox1.Controls.Add(Me.chbFormaPago)
        Me.GroupBox1.Controls.Add(Me.gbCuentaBancaria)
        Me.GroupBox1.Controls.Add(Me.lblObservacion)
        Me.GroupBox1.Controls.Add(Me.cmbFormaPago)
        Me.GroupBox1.Controls.Add(Me.txtObservacion)
        Me.GroupBox1.Controls.Add(Me.cmbTiposComprobantes)
        Me.GroupBox1.Controls.Add(Me.chbComprobanteDeCompras)
        Me.GroupBox1.Controls.Add(Me.bscNombreCuentaBanco)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.bscNombreCuentaCaja)
        Me.GroupBox1.Controls.Add(Me.lblCuentaCaja)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(766, 318)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'bscCodigoClienteVinculado
        '
        Me.bscCodigoClienteVinculado.ActivarFiltroEnGrilla = True
        Me.bscCodigoClienteVinculado.BindearPropiedadControl = Nothing
        Me.bscCodigoClienteVinculado.BindearPropiedadEntidad = Nothing
        Me.bscCodigoClienteVinculado.ConfigBuscador = Nothing
        Me.bscCodigoClienteVinculado.Datos = Nothing
        Me.bscCodigoClienteVinculado.FilaDevuelta = Nothing
        Me.bscCodigoClienteVinculado.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoClienteVinculado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoClienteVinculado.IsDecimal = False
        Me.bscCodigoClienteVinculado.IsNumber = True
        Me.bscCodigoClienteVinculado.IsPK = False
        Me.bscCodigoClienteVinculado.IsRequired = False
        Me.bscCodigoClienteVinculado.Key = ""
        Me.bscCodigoClienteVinculado.LabelAsoc = Nothing
        Me.bscCodigoClienteVinculado.Location = New System.Drawing.Point(174, 151)
        Me.bscCodigoClienteVinculado.MaxLengh = "32767"
        Me.bscCodigoClienteVinculado.Name = "bscCodigoClienteVinculado"
        Me.bscCodigoClienteVinculado.Permitido = False
        Me.bscCodigoClienteVinculado.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoClienteVinculado.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoClienteVinculado.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoClienteVinculado.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoClienteVinculado.Selecciono = False
        Me.bscCodigoClienteVinculado.Size = New System.Drawing.Size(81, 23)
        Me.bscCodigoClienteVinculado.TabIndex = 11
        '
        'chbClienteVinculado
        '
        Me.chbClienteVinculado.AutoSize = True
        Me.chbClienteVinculado.BindearPropiedadControl = Nothing
        Me.chbClienteVinculado.BindearPropiedadEntidad = Nothing
        Me.chbClienteVinculado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbClienteVinculado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbClienteVinculado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbClienteVinculado.IsPK = False
        Me.chbClienteVinculado.IsRequired = False
        Me.chbClienteVinculado.Key = Nothing
        Me.chbClienteVinculado.LabelAsoc = Nothing
        Me.chbClienteVinculado.Location = New System.Drawing.Point(20, 154)
        Me.chbClienteVinculado.Name = "chbClienteVinculado"
        Me.chbClienteVinculado.Size = New System.Drawing.Size(108, 17)
        Me.chbClienteVinculado.TabIndex = 10
        Me.chbClienteVinculado.Text = "Cliente Vinculado"
        Me.chbClienteVinculado.UseVisualStyleBackColor = True
        '
        'bscNombreClienteVinculado
        '
        Me.bscNombreClienteVinculado.ActivarFiltroEnGrilla = True
        Me.bscNombreClienteVinculado.AutoSize = True
        Me.bscNombreClienteVinculado.BindearPropiedadControl = Nothing
        Me.bscNombreClienteVinculado.BindearPropiedadEntidad = Nothing
        Me.bscNombreClienteVinculado.ConfigBuscador = Nothing
        Me.bscNombreClienteVinculado.Datos = Nothing
        Me.bscNombreClienteVinculado.FilaDevuelta = Nothing
        Me.bscNombreClienteVinculado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreClienteVinculado.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreClienteVinculado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreClienteVinculado.IsDecimal = False
        Me.bscNombreClienteVinculado.IsNumber = False
        Me.bscNombreClienteVinculado.IsPK = False
        Me.bscNombreClienteVinculado.IsRequired = False
        Me.bscNombreClienteVinculado.Key = ""
        Me.bscNombreClienteVinculado.LabelAsoc = Me.lblNombre
        Me.bscNombreClienteVinculado.Location = New System.Drawing.Point(262, 151)
        Me.bscNombreClienteVinculado.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreClienteVinculado.MaxLengh = "32767"
        Me.bscNombreClienteVinculado.Name = "bscNombreClienteVinculado"
        Me.bscNombreClienteVinculado.Permitido = False
        Me.bscNombreClienteVinculado.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreClienteVinculado.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreClienteVinculado.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreClienteVinculado.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreClienteVinculado.Selecciono = False
        Me.bscNombreClienteVinculado.Size = New System.Drawing.Size(147, 23)
        Me.bscNombreClienteVinculado.TabIndex = 12
        '
        'chbTransportista
        '
        Me.chbTransportista.AutoSize = True
        Me.chbTransportista.BindearPropiedadControl = Nothing
        Me.chbTransportista.BindearPropiedadEntidad = Nothing
        Me.chbTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTransportista.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbTransportista.IsPK = False
        Me.chbTransportista.IsRequired = False
        Me.chbTransportista.Key = Nothing
        Me.chbTransportista.LabelAsoc = Nothing
        Me.chbTransportista.Location = New System.Drawing.Point(20, 127)
        Me.chbTransportista.Name = "chbTransportista"
        Me.chbTransportista.Size = New System.Drawing.Size(87, 17)
        Me.chbTransportista.TabIndex = 8
        Me.chbTransportista.Text = "Transportista"
        Me.chbTransportista.UseVisualStyleBackColor = True
        '
        'bscNombreTransportista
        '
        Me.bscNombreTransportista.AutoSize = True
        Me.bscNombreTransportista.AyudaAncho = 140
        Me.bscNombreTransportista.BindearPropiedadControl = Nothing
        Me.bscNombreTransportista.BindearPropiedadEntidad = Nothing
        Me.bscNombreTransportista.ColumnasAlineacion = Nothing
        Me.bscNombreTransportista.ColumnasAncho = Nothing
        Me.bscNombreTransportista.ColumnasFormato = Nothing
        Me.bscNombreTransportista.ColumnasOcultas = Nothing
        Me.bscNombreTransportista.ColumnasTitulos = Nothing
        Me.bscNombreTransportista.Datos = Nothing
        Me.bscNombreTransportista.Enabled = False
        Me.bscNombreTransportista.FilaDevuelta = Nothing
        Me.bscNombreTransportista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreTransportista.IsDecimal = False
        Me.bscNombreTransportista.IsNumber = False
        Me.bscNombreTransportista.IsPK = False
        Me.bscNombreTransportista.IsRequired = False
        Me.bscNombreTransportista.Key = ""
        Me.bscNombreTransportista.LabelAsoc = Nothing
        Me.bscNombreTransportista.Location = New System.Drawing.Point(174, 124)
        Me.bscNombreTransportista.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreTransportista.MaxLengh = "32767"
        Me.bscNombreTransportista.Name = "bscNombreTransportista"
        Me.bscNombreTransportista.Permitido = True
        Me.bscNombreTransportista.Selecciono = False
        Me.bscNombreTransportista.Size = New System.Drawing.Size(235, 23)
        Me.bscNombreTransportista.TabIndex = 9
        Me.bscNombreTransportista.Titulo = Nothing
        '
        'txtNroCuenta
        '
        Me.txtNroCuenta.BindearPropiedadControl = "Text"
        Me.txtNroCuenta.BindearPropiedadEntidad = "NroCuenta"
        Me.txtNroCuenta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroCuenta.Formato = ""
        Me.txtNroCuenta.IsDecimal = False
        Me.txtNroCuenta.IsNumber = False
        Me.txtNroCuenta.IsPK = False
        Me.txtNroCuenta.IsRequired = False
        Me.txtNroCuenta.Key = ""
        Me.txtNroCuenta.LabelAsoc = Me.lblNroCuenta
        Me.txtNroCuenta.Location = New System.Drawing.Point(524, 125)
        Me.txtNroCuenta.MaxLength = 25
        Me.txtNroCuenta.Name = "txtNroCuenta"
        Me.txtNroCuenta.Size = New System.Drawing.Size(166, 20)
        Me.txtNroCuenta.TabIndex = 15
        '
        'lblNroCuenta
        '
        Me.lblNroCuenta.AutoSize = True
        Me.lblNroCuenta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNroCuenta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNroCuenta.LabelAsoc = Nothing
        Me.lblNroCuenta.Location = New System.Drawing.Point(454, 129)
        Me.lblNroCuenta.Name = "lblNroCuenta"
        Me.lblNroCuenta.Size = New System.Drawing.Size(64, 13)
        Me.lblNroCuenta.TabIndex = 14
        Me.lblNroCuenta.Text = "Nro. Cuenta"
        '
        'gbCuentaBancaria
        '
        Me.gbCuentaBancaria.Controls.Add(Me.txtCBUCuit)
        Me.gbCuentaBancaria.Controls.Add(Me.lblCBUCuit)
        Me.gbCuentaBancaria.Controls.Add(Me.txtCBUAlias)
        Me.gbCuentaBancaria.Controls.Add(Me.Label6)
        Me.gbCuentaBancaria.Controls.Add(Me.txtCBU)
        Me.gbCuentaBancaria.Controls.Add(Me.Label7)
        Me.gbCuentaBancaria.Location = New System.Drawing.Point(470, 11)
        Me.gbCuentaBancaria.Name = "gbCuentaBancaria"
        Me.gbCuentaBancaria.Size = New System.Drawing.Size(234, 106)
        Me.gbCuentaBancaria.TabIndex = 13
        Me.gbCuentaBancaria.TabStop = False
        Me.gbCuentaBancaria.Text = "Cuenta Bancaria"
        '
        'txtCBUCuit
        '
        Me.txtCBUCuit.BindearPropiedadControl = "Text"
        Me.txtCBUCuit.BindearPropiedadEntidad = "CBUCuit"
        Me.txtCBUCuit.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCBUCuit.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCBUCuit.Formato = ""
        Me.txtCBUCuit.IsDecimal = False
        Me.txtCBUCuit.IsNumber = False
        Me.txtCBUCuit.IsPK = False
        Me.txtCBUCuit.IsRequired = False
        Me.txtCBUCuit.Key = ""
        Me.txtCBUCuit.LabelAsoc = Me.lblCBUCuit
        Me.txtCBUCuit.Location = New System.Drawing.Point(54, 75)
        Me.txtCBUCuit.MaxLength = 11
        Me.txtCBUCuit.Name = "txtCBUCuit"
        Me.txtCBUCuit.Size = New System.Drawing.Size(98, 20)
        Me.txtCBUCuit.TabIndex = 5
        '
        'lblCBUCuit
        '
        Me.lblCBUCuit.AutoSize = True
        Me.lblCBUCuit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCBUCuit.LabelAsoc = Nothing
        Me.lblCBUCuit.Location = New System.Drawing.Point(16, 79)
        Me.lblCBUCuit.Name = "lblCBUCuit"
        Me.lblCBUCuit.Size = New System.Drawing.Size(32, 13)
        Me.lblCBUCuit.TabIndex = 4
        Me.lblCBUCuit.Text = "CUIT"
        '
        'txtCBUAlias
        '
        Me.txtCBUAlias.BindearPropiedadControl = "Text"
        Me.txtCBUAlias.BindearPropiedadEntidad = "CBUAliasProveedor"
        Me.txtCBUAlias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCBUAlias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCBUAlias.Formato = ""
        Me.txtCBUAlias.IsDecimal = False
        Me.txtCBUAlias.IsNumber = False
        Me.txtCBUAlias.IsPK = False
        Me.txtCBUAlias.IsRequired = False
        Me.txtCBUAlias.Key = ""
        Me.txtCBUAlias.LabelAsoc = Me.Label6
        Me.txtCBUAlias.Location = New System.Drawing.Point(54, 49)
        Me.txtCBUAlias.MaxLength = 20
        Me.txtCBUAlias.Name = "txtCBUAlias"
        Me.txtCBUAlias.Size = New System.Drawing.Size(166, 20)
        Me.txtCBUAlias.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.LabelAsoc = Nothing
        Me.Label6.Location = New System.Drawing.Point(19, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Alias"
        '
        'txtCBU
        '
        Me.txtCBU.BindearPropiedadControl = "Text"
        Me.txtCBU.BindearPropiedadEntidad = "CBUProveedor"
        Me.txtCBU.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCBU.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCBU.Formato = ""
        Me.txtCBU.IsDecimal = False
        Me.txtCBU.IsNumber = True
        Me.txtCBU.IsPK = False
        Me.txtCBU.IsRequired = False
        Me.txtCBU.Key = ""
        Me.txtCBU.LabelAsoc = Me.Label7
        Me.txtCBU.Location = New System.Drawing.Point(54, 23)
        Me.txtCBU.MaxLength = 22
        Me.txtCBU.Name = "txtCBU"
        Me.txtCBU.Size = New System.Drawing.Size(166, 20)
        Me.txtCBU.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Location = New System.Drawing.Point(19, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "CBU"
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(39, 177)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 16
        Me.lblObservacion.Text = "Observación"
        '
        'txtObservacion
        '
        Me.txtObservacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservacion.BindearPropiedadControl = "Text"
        Me.txtObservacion.BindearPropiedadEntidad = "Observacion"
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = ""
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = ""
        Me.txtObservacion.LabelAsoc = Me.lblObservacion
        Me.txtObservacion.Location = New System.Drawing.Point(42, 193)
        Me.txtObservacion.MaxLength = 200
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(694, 122)
        Me.txtObservacion.TabIndex = 17
        '
        'tbpLogo
        '
        Me.tbpLogo.BackColor = System.Drawing.SystemColors.Control
        Me.tbpLogo.Controls.Add(Me.pcbFoto)
        Me.tbpLogo.Controls.Add(Me.btnLimpiarImagen)
        Me.tbpLogo.Controls.Add(Me.btnBuscarImagen)
        Me.tbpLogo.Location = New System.Drawing.Point(4, 22)
        Me.tbpLogo.Name = "tbpLogo"
        Me.tbpLogo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpLogo.Size = New System.Drawing.Size(772, 324)
        Me.tbpLogo.TabIndex = 7
        Me.tbpLogo.Text = "Logo"
        '
        'pcbFoto
        '
        Me.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pcbFoto.Location = New System.Drawing.Point(287, 22)
        Me.pcbFoto.Name = "pcbFoto"
        Me.pcbFoto.Size = New System.Drawing.Size(231, 176)
        Me.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbFoto.TabIndex = 19
        Me.pcbFoto.TabStop = False
        '
        'btnLimpiarImagen
        '
        Me.btnLimpiarImagen.Location = New System.Drawing.Point(170, 164)
        Me.btnLimpiarImagen.Name = "btnLimpiarImagen"
        Me.btnLimpiarImagen.Size = New System.Drawing.Size(111, 33)
        Me.btnLimpiarImagen.TabIndex = 1
        Me.btnLimpiarImagen.Text = "&Limpiar imagen"
        Me.btnLimpiarImagen.UseVisualStyleBackColor = True
        '
        'btnBuscarImagen
        '
        Me.btnBuscarImagen.Location = New System.Drawing.Point(170, 22)
        Me.btnBuscarImagen.Name = "btnBuscarImagen"
        Me.btnBuscarImagen.Size = New System.Drawing.Size(111, 33)
        Me.btnBuscarImagen.TabIndex = 0
        Me.btnBuscarImagen.Text = "&Buscar imagen"
        Me.btnBuscarImagen.UseVisualStyleBackColor = True
        '
        'tbpContratistas
        '
        Me.tbpContratistas.BackColor = System.Drawing.SystemColors.Control
        Me.tbpContratistas.Controls.Add(Me.GroupBox2)
        Me.tbpContratistas.Location = New System.Drawing.Point(4, 22)
        Me.tbpContratistas.Name = "tbpContratistas"
        Me.tbpContratistas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpContratistas.Size = New System.Drawing.Size(772, 324)
        Me.tbpContratistas.TabIndex = 8
        Me.tbpContratistas.Text = "Contratistas"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtpFechaIndemnidad)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpFechaIndiceInc)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtpFechaRes559)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpFechaHigSeg)
        Me.GroupBox2.Location = New System.Drawing.Point(123, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(545, 132)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fechas de entrega de"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(192, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Indemnidad"
        '
        'dtpFechaIndemnidad
        '
        Me.dtpFechaIndemnidad.BindearPropiedadControl = "Value"
        Me.dtpFechaIndemnidad.BindearPropiedadEntidad = "FechaIndemnidad"
        Me.dtpFechaIndemnidad.Checked = False
        Me.dtpFechaIndemnidad.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaIndemnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaIndemnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaIndemnidad.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIndemnidad.IsPK = False
        Me.dtpFechaIndemnidad.IsRequired = False
        Me.dtpFechaIndemnidad.Key = ""
        Me.dtpFechaIndemnidad.LabelAsoc = Nothing
        Me.dtpFechaIndemnidad.Location = New System.Drawing.Point(259, 97)
        Me.dtpFechaIndemnidad.Name = "dtpFechaIndemnidad"
        Me.dtpFechaIndemnidad.ShowCheckBox = True
        Me.dtpFechaIndemnidad.Size = New System.Drawing.Size(113, 20)
        Me.dtpFechaIndemnidad.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(82, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Indice de Incidencia y Siniestralidad"
        '
        'dtpFechaIndiceInc
        '
        Me.dtpFechaIndiceInc.BindearPropiedadControl = "Value"
        Me.dtpFechaIndiceInc.BindearPropiedadEntidad = "FechaIndiceInc"
        Me.dtpFechaIndiceInc.Checked = False
        Me.dtpFechaIndiceInc.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaIndiceInc.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaIndiceInc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaIndiceInc.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIndiceInc.IsPK = False
        Me.dtpFechaIndiceInc.IsRequired = False
        Me.dtpFechaIndiceInc.Key = ""
        Me.dtpFechaIndiceInc.LabelAsoc = Nothing
        Me.dtpFechaIndiceInc.Location = New System.Drawing.Point(259, 71)
        Me.dtpFechaIndiceInc.Name = "dtpFechaIndiceInc"
        Me.dtpFechaIndiceInc.ShowCheckBox = True
        Me.dtpFechaIndiceInc.Size = New System.Drawing.Size(113, 20)
        Me.dtpFechaIndiceInc.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(94, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Estado ante la resolución 559/09"
        '
        'dtpFechaRes559
        '
        Me.dtpFechaRes559.BindearPropiedadControl = "Value"
        Me.dtpFechaRes559.BindearPropiedadEntidad = "FechaRes559"
        Me.dtpFechaRes559.Checked = False
        Me.dtpFechaRes559.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaRes559.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaRes559.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaRes559.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaRes559.IsPK = False
        Me.dtpFechaRes559.IsRequired = False
        Me.dtpFechaRes559.Key = ""
        Me.dtpFechaRes559.LabelAsoc = Nothing
        Me.dtpFechaRes559.Location = New System.Drawing.Point(259, 45)
        Me.dtpFechaRes559.Name = "dtpFechaRes559"
        Me.dtpFechaRes559.ShowCheckBox = True
        Me.dtpFechaRes559.Size = New System.Drawing.Size(113, 20)
        Me.dtpFechaRes559.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(89, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Requisitos de Higiene y Seguridad"
        '
        'dtpFechaHigSeg
        '
        Me.dtpFechaHigSeg.BindearPropiedadControl = "Value"
        Me.dtpFechaHigSeg.BindearPropiedadEntidad = "FechaHigSeg"
        Me.dtpFechaHigSeg.Checked = False
        Me.dtpFechaHigSeg.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaHigSeg.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaHigSeg.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaHigSeg.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaHigSeg.IsPK = False
        Me.dtpFechaHigSeg.IsRequired = False
        Me.dtpFechaHigSeg.Key = ""
        Me.dtpFechaHigSeg.LabelAsoc = Nothing
        Me.dtpFechaHigSeg.Location = New System.Drawing.Point(259, 19)
        Me.dtpFechaHigSeg.Name = "dtpFechaHigSeg"
        Me.dtpFechaHigSeg.ShowCheckBox = True
        Me.dtpFechaHigSeg.Size = New System.Drawing.Size(113, 20)
        Me.dtpFechaHigSeg.TabIndex = 1
        '
        'tbpContabilidad
        '
        Me.tbpContabilidad.BackColor = System.Drawing.SystemColors.Control
        Me.tbpContabilidad.Controls.Add(Me.UcCuentas1)
        Me.tbpContabilidad.Location = New System.Drawing.Point(4, 22)
        Me.tbpContabilidad.Name = "tbpContabilidad"
        Me.tbpContabilidad.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpContabilidad.Size = New System.Drawing.Size(772, 324)
        Me.tbpContabilidad.TabIndex = 9
        Me.tbpContabilidad.Text = "Contabilidad"
        '
        'UcCuentas1
        '
        Me.UcCuentas1.Cuenta = Nothing
        Me.UcCuentas1.Location = New System.Drawing.Point(141, 22)
        Me.UcCuentas1.Name = "UcCuentas1"
        Me.UcCuentas1.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentas1.TabIndex = 0
        '
        'bscCodigoTransportista
        '
        Me.bscCodigoTransportista.AyudaAncho = 608
        Me.bscCodigoTransportista.BindearPropiedadControl = "Text"
        Me.bscCodigoTransportista.BindearPropiedadEntidad = "IdTransportista"
        Me.bscCodigoTransportista.ColumnasAlineacion = Nothing
        Me.bscCodigoTransportista.ColumnasAncho = Nothing
        Me.bscCodigoTransportista.ColumnasFormato = Nothing
        Me.bscCodigoTransportista.ColumnasOcultas = Nothing
        Me.bscCodigoTransportista.ColumnasTitulos = Nothing
        Me.bscCodigoTransportista.Datos = Nothing
        Me.bscCodigoTransportista.FilaDevuelta = Nothing
        Me.bscCodigoTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoTransportista.IsDecimal = False
        Me.bscCodigoTransportista.IsNumber = False
        Me.bscCodigoTransportista.IsPK = False
        Me.bscCodigoTransportista.IsRequired = False
        Me.bscCodigoTransportista.Key = ""
        Me.bscCodigoTransportista.LabelAsoc = Nothing
        Me.bscCodigoTransportista.Location = New System.Drawing.Point(348, 5)
        Me.bscCodigoTransportista.MaxLengh = "32767"
        Me.bscCodigoTransportista.Name = "bscCodigoTransportista"
        Me.bscCodigoTransportista.Permitido = True
        Me.bscCodigoTransportista.Selecciono = False
        Me.bscCodigoTransportista.Size = New System.Drawing.Size(27, 20)
        Me.bscCodigoTransportista.TabIndex = 7
        Me.bscCodigoTransportista.Titulo = Nothing
        Me.bscCodigoTransportista.Visible = False
        '
        'ofdArchivos
        '
        Me.ofdArchivos.Filter = "jpg files|*.jpg"
        '
        'bscCuentaBanco
        '
        Me.bscCuentaBanco.ActivarFiltroEnGrilla = True
        Me.bscCuentaBanco.BindearPropiedadControl = "Text"
        Me.bscCuentaBanco.BindearPropiedadEntidad = "CuentaBanco.IdCuentaBanco"
        Me.bscCuentaBanco.ConfigBuscador = Nothing
        Me.bscCuentaBanco.Datos = Nothing
        Me.bscCuentaBanco.FilaDevuelta = Nothing
        Me.bscCuentaBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBanco.IsDecimal = False
        Me.bscCuentaBanco.IsNumber = True
        Me.bscCuentaBanco.IsPK = False
        Me.bscCuentaBanco.IsRequired = False
        Me.bscCuentaBanco.Key = ""
        Me.bscCuentaBanco.LabelAsoc = Me.lblCuentaCaja
        Me.bscCuentaBanco.Location = New System.Drawing.Point(314, 4)
        Me.bscCuentaBanco.MaxLengh = "32767"
        Me.bscCuentaBanco.Name = "bscCuentaBanco"
        Me.bscCuentaBanco.Permitido = True
        Me.bscCuentaBanco.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCuentaBanco.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCuentaBanco.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCuentaBanco.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCuentaBanco.Selecciono = False
        Me.bscCuentaBanco.Size = New System.Drawing.Size(28, 23)
        Me.bscCuentaBanco.TabIndex = 6
        Me.bscCuentaBanco.TabStop = False
        '
        'chbEsProveedorGenerico
        '
        Me.chbEsProveedorGenerico.AutoSize = True
        Me.chbEsProveedorGenerico.BindearPropiedadControl = "Checked"
        Me.chbEsProveedorGenerico.BindearPropiedadEntidad = "EsProveedorGenerico"
        Me.chbEsProveedorGenerico.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbEsProveedorGenerico.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsProveedorGenerico.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsProveedorGenerico.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbEsProveedorGenerico.IsPK = False
        Me.chbEsProveedorGenerico.IsRequired = False
        Me.chbEsProveedorGenerico.Key = Nothing
        Me.chbEsProveedorGenerico.LabelAsoc = Nothing
        Me.chbEsProveedorGenerico.Location = New System.Drawing.Point(16, 7)
        Me.chbEsProveedorGenerico.Name = "chbEsProveedorGenerico"
        Me.chbEsProveedorGenerico.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbEsProveedorGenerico.Size = New System.Drawing.Size(120, 17)
        Me.chbEsProveedorGenerico.TabIndex = 0
        Me.chbEsProveedorGenerico.Text = "Proveedor Eventual"
        Me.chbEsProveedorGenerico.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.Controls.Add(Me.bscCodigoTransportista)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnCopiar)
        Me.Panel1.Controls.Add(Me.btnAplicar)
        Me.Panel1.Controls.Add(Me.chbEsProveedorGenerico)
        Me.Panel1.Controls.Add(Me.bscCuentaBanco)
        Me.Panel1.Controls.Add(Me.bscCuentaCaja)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 408)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 33)
        Me.Panel1.TabIndex = 2
        Me.Panel1.Controls.SetChildIndex(Me.bscCuentaCaja, 0)
        Me.Panel1.Controls.SetChildIndex(Me.bscCuentaBanco, 0)
        Me.Panel1.Controls.SetChildIndex(Me.chbEsProveedorGenerico, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Panel1.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Panel1.Controls.SetChildIndex(Me.bscCodigoTransportista, 0)
        '
        'ProveedoresDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(780, 441)
        Me.Controls.Add(Me.tbcProveedor)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProveedoresDetalle"
        Me.Text = "Proveedor"
        Me.grbDatos.ResumeLayout(False)
        Me.grbDatos.PerformLayout()
        Me.tbpImpuestos.ResumeLayout(False)
        Me.grbImpositivo.ResumeLayout(False)
        Me.grbImpositivo.PerformLayout()
        Me.tbpDatos.ResumeLayout(False)
        Me.grbUbicacion.ResumeLayout(False)
        Me.grbUbicacion.PerformLayout()
        Me.tbcProveedor.ResumeLayout(False)
        Me.tbpOtros.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbCuentaBancaria.ResumeLayout(False)
        Me.gbCuentaBancaria.PerformLayout()
        Me.tbpLogo.ResumeLayout(False)
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpContratistas.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbpContabilidad.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents grbDatos As System.Windows.Forms.GroupBox
   Friend WithEvents tbpImpuestos As System.Windows.Forms.TabPage
   Friend WithEvents grbImpositivo As System.Windows.Forms.GroupBox
   Friend WithEvents cmbRegimenes As Eniac.Controles.ComboBox
   Friend WithEvents lblRegimen As Eniac.Controles.Label
   Friend WithEvents lblNroRegimen As Eniac.Controles.Label
   Friend WithEvents chbPasibleRetencion As Eniac.Controles.CheckBox
   Friend WithEvents txtIngresosBrutos As Eniac.Controles.TextBox
   Friend WithEvents lblIngresosBrutos As Eniac.Controles.Label
    Friend WithEvents chbComprobanteDeCompras As Eniac.Controles.CheckBox
    Public WithEvents cmbTiposComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents lblCategoria As Eniac.Controles.Label
   Friend WithEvents cmbCategorias As Eniac.Controles.ComboBox
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents cboRubro As Eniac.Controles.ComboBox
   Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
   Friend WithEvents grbUbicacion As System.Windows.Forms.GroupBox
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents lnkLocalidad As Eniac.Controles.LinkLabel
   Friend WithEvents txtFax As Eniac.Controles.TextBox
   Friend WithEvents lblFax As Eniac.Controles.Label
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents txtCorreoElectronico As Eniac.Controles.TextBox
   Friend WithEvents lblCorreoElectronico As Eniac.Controles.Label
   Friend WithEvents tbcProveedor As System.Windows.Forms.TabControl
   Friend WithEvents tbpOtros As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents lblDescuentoRecargoPorc As Eniac.Controles.Label
   Public WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents txtDescuentoRecargoPorc As Eniac.Controles.TextBox
   Friend WithEvents bscCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents lblCuentaCaja As Eniac.Controles.Label
   Friend WithEvents bscNombreCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents txtCuit As Eniac.Controles.TextBox
   Friend WithEvents lblCuit As Eniac.Controles.Label
   Friend WithEvents lblCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents cmbCategoriaFiscal As Eniac.Controles.ComboBox
   Friend WithEvents tbpLogo As System.Windows.Forms.TabPage
   Friend WithEvents pcbFoto As System.Windows.Forms.PictureBox
   Friend WithEvents btnLimpiarImagen As Eniac.Controles.Button
   Friend WithEvents btnBuscarImagen As Eniac.Controles.Button
   Friend WithEvents ofdArchivos As System.Windows.Forms.OpenFileDialog
   Friend WithEvents chbPorCtaOrden As Eniac.Controles.CheckBox
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents txtCodigoProveedor As Eniac.Controles.TextBox
   Friend WithEvents lblTipoDoc As Eniac.Controles.Label
   Friend WithEvents cmbTipoDoc As Eniac.Controles.ComboBox
    Friend WithEvents txtNroDoc As Eniac.Controles.TextBox
    Friend WithEvents tbpContratistas As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dtpFechaHigSeg As Eniac.Controles.DateTimePicker
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents dtpFechaIndiceInc As Eniac.Controles.DateTimePicker
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents dtpFechaRes559 As Eniac.Controles.DateTimePicker
   Friend WithEvents cmbRegimenesIVA As Eniac.Controles.ComboBox
   Friend WithEvents lblNroRegimenIVA As Eniac.Controles.Label
   Friend WithEvents chbPasibleRetencionIVA As Eniac.Controles.CheckBox
   Friend WithEvents cmbRegimenesIIBB As Eniac.Controles.ComboBox
   Friend WithEvents lblNroRegimenIIBB As Eniac.Controles.Label
   Friend WithEvents chbPasibleRetencionIIBB As Eniac.Controles.CheckBox
   Friend WithEvents cmbRegimenesGan As Eniac.Controles.ComboBox
   Friend WithEvents lblNroRegimenGan As Eniac.Controles.Label
   Friend WithEvents chbPasibleRetencion2 As Eniac.Controles.CheckBox
   Friend WithEvents tbpContabilidad As System.Windows.Forms.TabPage
   Friend WithEvents UcCuentas1 As Eniac.Win.ucCuentas
   Friend WithEvents txtNombreDeFantasia As Eniac.Controles.TextBox
   Friend WithEvents lblNombreDeFantasia As Eniac.Controles.Label
   Friend WithEvents bscNombreCuentaBanco As Eniac.Controles.Buscador2
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents bscCuentaBanco As Eniac.Controles.Buscador2
   Protected WithEvents txtNivelAutorizacion As Eniac.Controles.TextBox
   Friend WithEvents lblNivelAutorizacion As Eniac.Controles.Label
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents dtpFechaIndemnidad As Eniac.Controles.DateTimePicker
   Friend WithEvents chbEsProveedorGenerico As Eniac.Controles.CheckBox
   Friend WithEvents txtCBUAlias As Eniac.Controles.TextBox
   Friend WithEvents Label6 As Eniac.Controles.Label
   Friend WithEvents gbCuentaBancaria As System.Windows.Forms.GroupBox
   Friend WithEvents txtCBU As Eniac.Controles.TextBox
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents txtCBUCuit As Eniac.Controles.TextBox
   Friend WithEvents lblCBUCuit As Eniac.Controles.Label
    Friend WithEvents lblCorreoAdm As Controles.Label
    Friend WithEvents txtCorreoAdm As Controles.TextBox
    Friend WithEvents txtNroCuenta As Controles.TextBox
    Friend WithEvents lblNroCuenta As Controles.Label
    Public WithEvents cmbAFIPConceptoCM05 As Controles.ComboBox
    Friend WithEvents chbAFIPConceptoCM05 As Controles.CheckBox
    Friend WithEvents chbTransportista As Controles.CheckBox
    Friend WithEvents bscNombreTransportista As Controles.Buscador
    Friend WithEvents bscCodigoTransportista As Controles.Buscador
    Friend WithEvents Panel1 As Panel
   Friend WithEvents bscCodigoClienteVinculado As Controles.Buscador2
   Friend WithEvents chbClienteVinculado As Controles.CheckBox
   Friend WithEvents bscNombreClienteVinculado As Controles.Buscador2
    Friend WithEvents cmbRegimenesIIBBComplem As Controles.ComboBox
    Friend WithEvents lblNroRegimenIIBBComplem As Controles.Label
    Friend WithEvents chbRetencionIIBBComplem As Controles.CheckBox
End Class
