<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmpleadosDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmpleadosDetalle))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocEmpleado")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocEmpleado")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PeriodoFiscal")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteObjetivo")
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
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.cmbTipoDocEmpleado = New Eniac.Controles.ComboBox()
        Me.lblTipoDocEmpleado = New Eniac.Controles.Label()
        Me.txtNroDocEmpleado = New Eniac.Controles.TextBox()
        Me.lblNroDocEmpleado = New Eniac.Controles.Label()
        Me.txtNombreEmpleado = New Eniac.Controles.TextBox()
        Me.lblNombreEmpleado = New Eniac.Controles.Label()
        Me.txtTelefonoEmpleado = New Eniac.Controles.TextBox()
        Me.lblTelefonoEmpleado = New Eniac.Controles.Label()
        Me.txtCelularEmpleado = New Eniac.Controles.TextBox()
        Me.lblCelularEmpleado = New Eniac.Controles.Label()
        Me.chbEsVendedor = New Eniac.Controles.CheckBox()
        Me.chbEsComprador = New Eniac.Controles.CheckBox()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.txtComisionPorVenta = New Eniac.Controles.TextBox()
        Me.lblComisionPorVenta = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.lnkLocalidad = New Eniac.Controles.LinkLabel()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
        Me.txtDireccion = New Eniac.Controles.TextBox()
        Me.lblDireccion = New Eniac.Controles.Label()
        Me.gmcMapa = New GMap.NET.WindowsForms.GMapControl()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblGeoLocalizacionLat = New Eniac.Controles.Label()
        Me.lblGeoLocalizacionLng = New Eniac.Controles.Label()
        Me.txtGeoLocalizacionLat = New Eniac.Controles.TextBox()
        Me.txtGeoLocalizacionLng = New Eniac.Controles.TextBox()
        Me.tcbZoom = New System.Windows.Forms.TrackBar()
        Me.cmbTipoMapa = New System.Windows.Forms.ComboBox()
        Me.btnGeolocalizar = New System.Windows.Forms.Button()
        Me.tbcEmpleado = New System.Windows.Forms.TabControl()
        Me.tbpDatos = New System.Windows.Forms.TabPage()
        Me.CheckBox1 = New Eniac.Controles.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chbEsTransportista = New Eniac.Controles.CheckBox()
        Me.chbEsCobrador = New Eniac.Controles.CheckBox()
        Me.chbResponsableProd = New Eniac.Controles.CheckBox()
        Me.txtValorHoraCatego = New Eniac.Controles.TextBox()
        Me.lblValorHoraCatego = New Eniac.Controles.Label()
        Me.cmbCategoriaEmpleado = New Eniac.Controles.ComboBox()
        Me.lblCategoriaEmpleado = New Eniac.Controles.Label()
        Me.cmbUsuarioMovil = New Eniac.Controles.ComboBox()
        Me.txtClave = New Eniac.Controles.TextBox()
        Me.lblClave = New Eniac.Controles.Label()
        Me.chbColor = New Eniac.Controles.CheckBox()
        Me.txtNivelAutorizacion = New Eniac.Controles.TextBox()
        Me.lblNivelAutorizacion = New Eniac.Controles.Label()
        Me.txtColor = New Eniac.Controles.TextBox()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.chbUsuarioMovil = New Eniac.Controles.CheckBox()
        Me.tbpMapa = New System.Windows.Forms.TabPage()
        Me.tbpComisiones = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tbProducto = New System.Windows.Forms.TabPage()
        Me.bscProducto = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
        Me.btnRefrescarProductos = New System.Windows.Forms.Button()
        Me.btnEliminarProductos = New Eniac.Controles.Button()
        Me.btnInsertarProductos = New Eniac.Controles.Button()
        Me.lblComisionProducto = New Eniac.Controles.Label()
        Me.txtComisionProducto = New Eniac.Controles.TextBox()
        Me.dgvComisionesProductos = New Eniac.Controles.DataGridView()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEmpleado2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Productos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpMarca = New System.Windows.Forms.TabPage()
        Me.btnRefrescarMarcas = New System.Windows.Forms.Button()
        Me.lblComisionMarcas = New Eniac.Controles.Label()
        Me.btnEliminarMarca = New Eniac.Controles.Button()
        Me.txtComisionMarcas = New Eniac.Controles.TextBox()
        Me.dgvComisionesMarcas = New Eniac.Controles.DataGridView()
        Me.IdMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEmpleado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marca = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnInsertarMarca = New Eniac.Controles.Button()
        Me.cmbMarcas = New Eniac.Controles.ComboBox()
        Me.tpRubro = New System.Windows.Forms.TabPage()
        Me.btnRefrescarRubros = New System.Windows.Forms.Button()
        Me.btnEliminarRubros = New Eniac.Controles.Button()
        Me.btnInsertarRubros = New Eniac.Controles.Button()
        Me.lblComisionRubro = New Eniac.Controles.Label()
        Me.txtComisionRubro = New Eniac.Controles.TextBox()
        Me.dgvComisionesRubros = New Eniac.Controles.DataGridView()
        Me.IdEmpleado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rubros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbRubros = New Eniac.Controles.ComboBox()
        Me.tbpSubRubro = New System.Windows.Forms.TabPage()
        Me.btnEliminarSubRubros = New Eniac.Controles.Button()
        Me.btnInsertarSubRubros = New Eniac.Controles.Button()
        Me.txtDescuentoSubRubros = New Eniac.Controles.TextBox()
        Me.lblDescuentoSubRubros = New Eniac.Controles.Label()
        Me.lblSubRubro = New Eniac.Controles.Label()
        Me.lblRubro = New Eniac.Controles.Label()
        Me.bscCodigoSubRubro1 = New Eniac.Controles.Buscador2()
        Me.bscNombreSubRubro1 = New Eniac.Controles.Buscador2()
        Me.bscNombreRubro1 = New Eniac.Controles.Buscador2()
        Me.bscCodigoRubro1 = New Eniac.Controles.Buscador2()
        Me.btnRefrescarSubRubros = New System.Windows.Forms.Button()
        Me.dgvComisionesSubRubros = New Eniac.Controles.DataGridView()
        Me.IdEmpleadoTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpSubSubRubro = New System.Windows.Forms.TabPage()
        Me.btnEliminarSubSubRubro = New Eniac.Controles.Button()
        Me.btnInsertarSubSubRubro = New Eniac.Controles.Button()
        Me.dgvComisionesSubSubRubros = New Eniac.Controles.DataGridView()
        Me.IdCategoriaTres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdRubroTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreRubroTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSubRubroTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSubRubroTwo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSubSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSubSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComisionSubSubRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDescuentoSubSubRubro = New Eniac.Controles.Label()
        Me.txtDescuentoSubSubRubro = New Eniac.Controles.TextBox()
        Me.bscCodigoSubSubRubro2 = New Eniac.Controles.Buscador2()
        Me.bscNombreSubSubRubro2 = New Eniac.Controles.Buscador2()
        Me.Label3 = New Eniac.Controles.Label()
        Me.Label4 = New Eniac.Controles.Label()
        Me.bscCodigoSubRubro2 = New Eniac.Controles.Buscador2()
        Me.bscNombreSubRubro2 = New Eniac.Controles.Buscador2()
        Me.bscNombreRubro2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoRubro2 = New Eniac.Controles.Buscador2()
        Me.btnRefrescarSubSubRubro = New System.Windows.Forms.Button()
        Me.Label5 = New Eniac.Controles.Label()
        Me.tbpObjetivos = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ugObjetivos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label2 = New Eniac.Controles.Label()
        Me.txtImporteObjetivos = New Eniac.Controles.TextBox()
        Me.dtpPeriodoFiscal = New Eniac.Controles.DateTimePicker()
        Me.lblPeriodoFiscal = New Eniac.Controles.Label()
        Me.btnRefrescarObj = New System.Windows.Forms.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.tbpCobrador = New System.Windows.Forms.TabPage()
        Me.cmbEntidadCobranza = New Eniac.Controles.ComboBox()
        Me.lblEntidadCobranza = New Eniac.Controles.Label()
        Me.cmbTarTarjeta = New Eniac.Controles.ComboBox()
        Me.chbDebitoTarjeta = New Eniac.Controles.CheckBox()
        Me.lblObservacion = New Eniac.Controles.Label()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.lblBanco = New Eniac.Controles.Label()
        Me.cmbCaja = New Eniac.Controles.ComboBox()
        Me.chbCaja = New Eniac.Controles.CheckBox()
        Me.cmbBanco = New Eniac.Controles.ComboBox()
        Me.chbDebitoDirecto = New Eniac.Controles.CheckBox()
        Me.lblIdDispositivo = New Eniac.Controles.Label()
        Me.txtIdDispositivo = New Eniac.Controles.TextBox()
        Me.tbpChofer = New System.Windows.Forms.TabPage()
        Me.bscCodigoTransportista = New Eniac.Controles.Buscador()
        Me.bscTransportista = New Eniac.Controles.Buscador()
        Me.lblTransportista = New Eniac.Controles.Label()
        Me.tbpProduccion = New System.Windows.Forms.TabPage()
        Me.pnlValorHora = New System.Windows.Forms.Panel()
        Me.chbValorHoraProd = New Eniac.Controles.CheckBox()
        Me.txtValorHora = New Eniac.Controles.TextBox()
        Me.grbDatos = New System.Windows.Forms.GroupBox()
        Me.txtIdEmpleado = New Eniac.Controles.TextBox()
        Me.lblIdEmpleado = New Eniac.Controles.Label()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tcbZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcEmpleado.SuspendLayout()
        Me.tbpDatos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.tbpMapa.SuspendLayout()
        Me.tbpComisiones.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tbProducto.SuspendLayout()
        CType(Me.dgvComisionesProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMarca.SuspendLayout()
        CType(Me.dgvComisionesMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpRubro.SuspendLayout()
        CType(Me.dgvComisionesRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpSubRubro.SuspendLayout()
        CType(Me.dgvComisionesSubRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpSubSubRubro.SuspendLayout()
        CType(Me.dgvComisionesSubSubRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpObjetivos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ugObjetivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpCobrador.SuspendLayout()
        Me.tbpChofer.SuspendLayout()
        Me.tbpProduccion.SuspendLayout()
        Me.pnlValorHora.SuspendLayout()
        Me.grbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(419, 424)
        Me.btnAceptar.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(505, 424)
        Me.btnCancelar.TabIndex = 3
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(318, 424)
        Me.btnCopiar.TabIndex = 5
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(261, 424)
        '
        'cmbTipoDocEmpleado
        '
        Me.cmbTipoDocEmpleado.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoDocEmpleado.BindearPropiedadEntidad = "TipoDocEmpleado"
        Me.cmbTipoDocEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDocEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDocEmpleado.FormattingEnabled = True
        Me.cmbTipoDocEmpleado.IsPK = False
        Me.cmbTipoDocEmpleado.IsRequired = False
        Me.cmbTipoDocEmpleado.Key = Nothing
        Me.cmbTipoDocEmpleado.LabelAsoc = Me.lblTipoDocEmpleado
        Me.cmbTipoDocEmpleado.Location = New System.Drawing.Point(86, 116)
        Me.cmbTipoDocEmpleado.Name = "cmbTipoDocEmpleado"
        Me.cmbTipoDocEmpleado.Size = New System.Drawing.Size(62, 21)
        Me.cmbTipoDocEmpleado.TabIndex = 10
        '
        'lblTipoDocEmpleado
        '
        Me.lblTipoDocEmpleado.AutoSize = True
        Me.lblTipoDocEmpleado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipoDocEmpleado.LabelAsoc = Nothing
        Me.lblTipoDocEmpleado.Location = New System.Drawing.Point(16, 119)
        Me.lblTipoDocEmpleado.Name = "lblTipoDocEmpleado"
        Me.lblTipoDocEmpleado.Size = New System.Drawing.Size(54, 13)
        Me.lblTipoDocEmpleado.TabIndex = 9
        Me.lblTipoDocEmpleado.Text = "Tipo Doc."
        '
        'txtNroDocEmpleado
        '
        Me.txtNroDocEmpleado.BindearPropiedadControl = "Text"
        Me.txtNroDocEmpleado.BindearPropiedadEntidad = "NroDocEmpleado"
        Me.txtNroDocEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroDocEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroDocEmpleado.Formato = ""
        Me.txtNroDocEmpleado.IsDecimal = False
        Me.txtNroDocEmpleado.IsNumber = True
        Me.txtNroDocEmpleado.IsPK = False
        Me.txtNroDocEmpleado.IsRequired = False
        Me.txtNroDocEmpleado.Key = ""
        Me.txtNroDocEmpleado.LabelAsoc = Me.lblNroDocEmpleado
        Me.txtNroDocEmpleado.Location = New System.Drawing.Point(245, 116)
        Me.txtNroDocEmpleado.MaxLength = 12
        Me.txtNroDocEmpleado.Name = "txtNroDocEmpleado"
        Me.txtNroDocEmpleado.Size = New System.Drawing.Size(107, 20)
        Me.txtNroDocEmpleado.TabIndex = 12
        Me.txtNroDocEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroDocEmpleado
        '
        Me.lblNroDocEmpleado.AutoSize = True
        Me.lblNroDocEmpleado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNroDocEmpleado.LabelAsoc = Nothing
        Me.lblNroDocEmpleado.Location = New System.Drawing.Point(156, 120)
        Me.lblNroDocEmpleado.Name = "lblNroDocEmpleado"
        Me.lblNroDocEmpleado.Size = New System.Drawing.Size(85, 13)
        Me.lblNroDocEmpleado.TabIndex = 11
        Me.lblNroDocEmpleado.Text = "Nro. Documento"
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreEmpleado.BindearPropiedadControl = "Text"
        Me.txtNombreEmpleado.BindearPropiedadEntidad = "NombreEmpleado"
        Me.txtNombreEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreEmpleado.Formato = ""
        Me.txtNombreEmpleado.IsDecimal = False
        Me.txtNombreEmpleado.IsNumber = False
        Me.txtNombreEmpleado.IsPK = False
        Me.txtNombreEmpleado.IsRequired = True
        Me.txtNombreEmpleado.Key = "NombreEmpleado"
        Me.txtNombreEmpleado.LabelAsoc = Me.lblNombreEmpleado
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(66, 45)
        Me.txtNombreEmpleado.MaxLength = 100
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(350, 20)
        Me.txtNombreEmpleado.TabIndex = 3
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.AutoSize = True
        Me.lblNombreEmpleado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombreEmpleado.LabelAsoc = Nothing
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(16, 48)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreEmpleado.TabIndex = 2
        Me.lblNombreEmpleado.Text = "Nombre"
        '
        'txtTelefonoEmpleado
        '
        Me.txtTelefonoEmpleado.BindearPropiedadControl = "Text"
        Me.txtTelefonoEmpleado.BindearPropiedadEntidad = "TelefonoEmpleado"
        Me.txtTelefonoEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTelefonoEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTelefonoEmpleado.Formato = ""
        Me.txtTelefonoEmpleado.IsDecimal = False
        Me.txtTelefonoEmpleado.IsNumber = False
        Me.txtTelefonoEmpleado.IsPK = False
        Me.txtTelefonoEmpleado.IsRequired = False
        Me.txtTelefonoEmpleado.Key = ""
        Me.txtTelefonoEmpleado.LabelAsoc = Me.lblTelefonoEmpleado
        Me.txtTelefonoEmpleado.Location = New System.Drawing.Point(86, 61)
        Me.txtTelefonoEmpleado.MaxLength = 100
        Me.txtTelefonoEmpleado.Name = "txtTelefonoEmpleado"
        Me.txtTelefonoEmpleado.Size = New System.Drawing.Size(211, 20)
        Me.txtTelefonoEmpleado.TabIndex = 6
        '
        'lblTelefonoEmpleado
        '
        Me.lblTelefonoEmpleado.AutoSize = True
        Me.lblTelefonoEmpleado.LabelAsoc = Nothing
        Me.lblTelefonoEmpleado.Location = New System.Drawing.Point(16, 64)
        Me.lblTelefonoEmpleado.Name = "lblTelefonoEmpleado"
        Me.lblTelefonoEmpleado.Size = New System.Drawing.Size(49, 13)
        Me.lblTelefonoEmpleado.TabIndex = 5
        Me.lblTelefonoEmpleado.Text = "Telefono"
        '
        'txtCelularEmpleado
        '
        Me.txtCelularEmpleado.BindearPropiedadControl = "Text"
        Me.txtCelularEmpleado.BindearPropiedadEntidad = "CelularEmpleado"
        Me.txtCelularEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCelularEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCelularEmpleado.Formato = ""
        Me.txtCelularEmpleado.IsDecimal = False
        Me.txtCelularEmpleado.IsNumber = False
        Me.txtCelularEmpleado.IsPK = False
        Me.txtCelularEmpleado.IsRequired = False
        Me.txtCelularEmpleado.Key = ""
        Me.txtCelularEmpleado.LabelAsoc = Me.lblCelularEmpleado
        Me.txtCelularEmpleado.Location = New System.Drawing.Point(87, 91)
        Me.txtCelularEmpleado.MaxLength = 100
        Me.txtCelularEmpleado.Name = "txtCelularEmpleado"
        Me.txtCelularEmpleado.Size = New System.Drawing.Size(210, 20)
        Me.txtCelularEmpleado.TabIndex = 8
        '
        'lblCelularEmpleado
        '
        Me.lblCelularEmpleado.AutoSize = True
        Me.lblCelularEmpleado.LabelAsoc = Nothing
        Me.lblCelularEmpleado.Location = New System.Drawing.Point(16, 94)
        Me.lblCelularEmpleado.Name = "lblCelularEmpleado"
        Me.lblCelularEmpleado.Size = New System.Drawing.Size(39, 13)
        Me.lblCelularEmpleado.TabIndex = 7
        Me.lblCelularEmpleado.Text = "Celular"
        '
        'chbEsVendedor
        '
        Me.chbEsVendedor.AutoSize = True
        Me.chbEsVendedor.BindearPropiedadControl = "Checked"
        Me.chbEsVendedor.BindearPropiedadEntidad = "EsVendedor"
        Me.chbEsVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsVendedor.IsPK = False
        Me.chbEsVendedor.IsRequired = False
        Me.chbEsVendedor.Key = Nothing
        Me.chbEsVendedor.LabelAsoc = Nothing
        Me.chbEsVendedor.Location = New System.Drawing.Point(31, 27)
        Me.chbEsVendedor.Name = "chbEsVendedor"
        Me.chbEsVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbEsVendedor.TabIndex = 13
        Me.chbEsVendedor.Text = "Vendedor"
        Me.chbEsVendedor.UseVisualStyleBackColor = True
        '
        'chbEsComprador
        '
        Me.chbEsComprador.AutoSize = True
        Me.chbEsComprador.BindearPropiedadControl = "Checked"
        Me.chbEsComprador.BindearPropiedadEntidad = "EsComprador"
        Me.chbEsComprador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsComprador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsComprador.IsPK = False
        Me.chbEsComprador.IsRequired = False
        Me.chbEsComprador.Key = Nothing
        Me.chbEsComprador.LabelAsoc = Nothing
        Me.chbEsComprador.Location = New System.Drawing.Point(31, 51)
        Me.chbEsComprador.Name = "chbEsComprador"
        Me.chbEsComprador.Size = New System.Drawing.Size(77, 17)
        Me.chbEsComprador.TabIndex = 14
        Me.chbEsComprador.Text = "Comprador"
        Me.chbEsComprador.UseVisualStyleBackColor = True
        '
        'chbUsuario
        '
        Me.chbUsuario.AutoSize = True
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Location = New System.Drawing.Point(16, 173)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 16
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'cmbUsuario
        '
        Me.cmbUsuario.BindearPropiedadControl = "SelectedValue"
        Me.cmbUsuario.BindearPropiedadEntidad = "IdUsuario"
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.Enabled = False
        Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.IsPK = False
        Me.cmbUsuario.IsRequired = False
        Me.cmbUsuario.Key = Nothing
        Me.cmbUsuario.LabelAsoc = Nothing
        Me.cmbUsuario.Location = New System.Drawing.Point(109, 171)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(148, 21)
        Me.cmbUsuario.TabIndex = 17
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
        Me.txtComisionPorVenta.Location = New System.Drawing.Point(54, 6)
        Me.txtComisionPorVenta.MaxLength = 5
        Me.txtComisionPorVenta.Name = "txtComisionPorVenta"
        Me.txtComisionPorVenta.Size = New System.Drawing.Size(54, 20)
        Me.txtComisionPorVenta.TabIndex = 1
        Me.txtComisionPorVenta.Text = "0,00"
        Me.txtComisionPorVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComisionPorVenta
        '
        Me.lblComisionPorVenta.AutoSize = True
        Me.lblComisionPorVenta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComisionPorVenta.LabelAsoc = Nothing
        Me.lblComisionPorVenta.Location = New System.Drawing.Point(4, 9)
        Me.lblComisionPorVenta.Name = "lblComisionPorVenta"
        Me.lblComisionPorVenta.Size = New System.Drawing.Size(44, 13)
        Me.lblComisionPorVenta.TabIndex = 0
        Me.lblComisionPorVenta.Text = "General"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(111, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "%"
        '
        'lnkLocalidad
        '
        Me.lnkLocalidad.AutoSize = True
        Me.lnkLocalidad.LabelAsoc = Nothing
        Me.lnkLocalidad.Location = New System.Drawing.Point(16, 39)
        Me.lnkLocalidad.Name = "lnkLocalidad"
        Me.lnkLocalidad.Size = New System.Drawing.Size(53, 13)
        Me.lnkLocalidad.TabIndex = 2
        Me.lnkLocalidad.TabStop = True
        Me.lnkLocalidad.Text = "Localidad"
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.AyudaAncho = 608
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidad"
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
        Me.bscCodigoLocalidad.IsRequired = False
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Nothing
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(86, 35)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = True
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(82, 20)
        Me.bscCodigoLocalidad.TabIndex = 3
        Me.bscCodigoLocalidad.Titulo = Nothing
        '
        'bscNombreLocalidad
        '
        Me.bscNombreLocalidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(174, 35)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = True
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(326, 20)
        Me.bscNombreLocalidad.TabIndex = 4
        Me.bscNombreLocalidad.Titulo = Nothing
        '
        'txtDireccion
        '
        Me.txtDireccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDireccion.BindearPropiedadControl = "Text"
        Me.txtDireccion.BindearPropiedadEntidad = "Direccion"
        Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDireccion.Formato = ""
        Me.txtDireccion.IsDecimal = False
        Me.txtDireccion.IsNumber = False
        Me.txtDireccion.IsPK = False
        Me.txtDireccion.IsRequired = True
        Me.txtDireccion.Key = ""
        Me.txtDireccion.LabelAsoc = Me.lblDireccion
        Me.txtDireccion.Location = New System.Drawing.Point(86, 6)
        Me.txtDireccion.MaxLength = 100
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(414, 20)
        Me.txtDireccion.TabIndex = 1
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDireccion.LabelAsoc = Nothing
        Me.lblDireccion.Location = New System.Drawing.Point(16, 9)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
        Me.lblDireccion.TabIndex = 0
        Me.lblDireccion.Text = "Direccion"
        '
        'gmcMapa
        '
        Me.gmcMapa.AutoScroll = True
        Me.gmcMapa.Bearing = 0!
        Me.gmcMapa.CanDragMap = True
        Me.gmcMapa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gmcMapa.EmptyTileColor = System.Drawing.Color.Navy
        Me.gmcMapa.GrayScaleMode = False
        Me.gmcMapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.gmcMapa.LevelsKeepInMemmory = 5
        Me.gmcMapa.Location = New System.Drawing.Point(3, 16)
        Me.gmcMapa.MarkersEnabled = True
        Me.gmcMapa.MaxZoom = 18
        Me.gmcMapa.MinZoom = 2
        Me.gmcMapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.gmcMapa.Name = "gmcMapa"
        Me.gmcMapa.NegativeMode = False
        Me.gmcMapa.PolygonsEnabled = True
        Me.gmcMapa.RetryLoadTile = 0
        Me.gmcMapa.RoutesEnabled = True
        Me.gmcMapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.gmcMapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.gmcMapa.ShowTileGridLines = False
        Me.gmcMapa.Size = New System.Drawing.Size(295, 208)
        Me.gmcMapa.TabIndex = 0
        Me.gmcMapa.Zoom = 0R
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gmcMapa)
        Me.GroupBox1.Location = New System.Drawing.Point(194, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 227)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'lblGeoLocalizacionLat
        '
        Me.lblGeoLocalizacionLat.AutoSize = True
        Me.lblGeoLocalizacionLat.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGeoLocalizacionLat.LabelAsoc = Nothing
        Me.lblGeoLocalizacionLat.Location = New System.Drawing.Point(54, 32)
        Me.lblGeoLocalizacionLat.Name = "lblGeoLocalizacionLat"
        Me.lblGeoLocalizacionLat.Size = New System.Drawing.Size(25, 13)
        Me.lblGeoLocalizacionLat.TabIndex = 0
        Me.lblGeoLocalizacionLat.Text = "Lat."
        '
        'lblGeoLocalizacionLng
        '
        Me.lblGeoLocalizacionLng.AutoSize = True
        Me.lblGeoLocalizacionLng.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblGeoLocalizacionLng.LabelAsoc = Nothing
        Me.lblGeoLocalizacionLng.Location = New System.Drawing.Point(54, 68)
        Me.lblGeoLocalizacionLng.Name = "lblGeoLocalizacionLng"
        Me.lblGeoLocalizacionLng.Size = New System.Drawing.Size(28, 13)
        Me.lblGeoLocalizacionLng.TabIndex = 2
        Me.lblGeoLocalizacionLng.Text = "Lng."
        '
        'txtGeoLocalizacionLat
        '
        Me.txtGeoLocalizacionLat.BindearPropiedadControl = "Text"
        Me.txtGeoLocalizacionLat.BindearPropiedadEntidad = "GeoLocalizacionLat"
        Me.txtGeoLocalizacionLat.ForeColorFocus = System.Drawing.Color.Red
        Me.txtGeoLocalizacionLat.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtGeoLocalizacionLat.Formato = ""
        Me.txtGeoLocalizacionLat.IsDecimal = False
        Me.txtGeoLocalizacionLat.IsNumber = False
        Me.txtGeoLocalizacionLat.IsPK = False
        Me.txtGeoLocalizacionLat.IsRequired = False
        Me.txtGeoLocalizacionLat.Key = ""
        Me.txtGeoLocalizacionLat.LabelAsoc = Me.lblDireccion
        Me.txtGeoLocalizacionLat.Location = New System.Drawing.Point(85, 29)
        Me.txtGeoLocalizacionLat.MaxLength = 100
        Me.txtGeoLocalizacionLat.Name = "txtGeoLocalizacionLat"
        Me.txtGeoLocalizacionLat.Size = New System.Drawing.Size(94, 20)
        Me.txtGeoLocalizacionLat.TabIndex = 1
        '
        'txtGeoLocalizacionLng
        '
        Me.txtGeoLocalizacionLng.BindearPropiedadControl = "Text"
        Me.txtGeoLocalizacionLng.BindearPropiedadEntidad = "GeoLocalizacionLng"
        Me.txtGeoLocalizacionLng.ForeColorFocus = System.Drawing.Color.Red
        Me.txtGeoLocalizacionLng.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtGeoLocalizacionLng.Formato = ""
        Me.txtGeoLocalizacionLng.IsDecimal = False
        Me.txtGeoLocalizacionLng.IsNumber = False
        Me.txtGeoLocalizacionLng.IsPK = False
        Me.txtGeoLocalizacionLng.IsRequired = False
        Me.txtGeoLocalizacionLng.Key = ""
        Me.txtGeoLocalizacionLng.LabelAsoc = Me.lblDireccion
        Me.txtGeoLocalizacionLng.Location = New System.Drawing.Point(85, 65)
        Me.txtGeoLocalizacionLng.MaxLength = 100
        Me.txtGeoLocalizacionLng.Name = "txtGeoLocalizacionLng"
        Me.txtGeoLocalizacionLng.Size = New System.Drawing.Size(94, 20)
        Me.txtGeoLocalizacionLng.TabIndex = 3
        '
        'tcbZoom
        '
        Me.tcbZoom.AccessibleDescription = ""
        Me.tcbZoom.LargeChange = 18
        Me.tcbZoom.Location = New System.Drawing.Point(54, 184)
        Me.tcbZoom.Name = "tcbZoom"
        Me.tcbZoom.Size = New System.Drawing.Size(125, 45)
        Me.tcbZoom.TabIndex = 6
        Me.tcbZoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'cmbTipoMapa
        '
        Me.cmbTipoMapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMapa.FormattingEnabled = True
        Me.cmbTipoMapa.Items.AddRange(New Object() {"Google Maps", "Google Satelite Maps"})
        Me.cmbTipoMapa.Location = New System.Drawing.Point(53, 157)
        Me.cmbTipoMapa.Name = "cmbTipoMapa"
        Me.cmbTipoMapa.Size = New System.Drawing.Size(126, 21)
        Me.cmbTipoMapa.TabIndex = 5
        '
        'btnGeolocalizar
        '
        Me.btnGeolocalizar.Image = Global.Eniac.Win.My.Resources.Resources.earth_location
        Me.btnGeolocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGeolocalizar.Location = New System.Drawing.Point(63, 101)
        Me.btnGeolocalizar.Name = "btnGeolocalizar"
        Me.btnGeolocalizar.Size = New System.Drawing.Size(103, 39)
        Me.btnGeolocalizar.TabIndex = 4
        Me.btnGeolocalizar.Text = "Geolocalizar"
        Me.btnGeolocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGeolocalizar.UseVisualStyleBackColor = True
        '
        'tbcEmpleado
        '
        Me.tbcEmpleado.Controls.Add(Me.tbpDatos)
        Me.tbcEmpleado.Controls.Add(Me.tbpMapa)
        Me.tbcEmpleado.Controls.Add(Me.tbpComisiones)
        Me.tbcEmpleado.Controls.Add(Me.tbpObjetivos)
        Me.tbcEmpleado.Controls.Add(Me.tbpCobrador)
        Me.tbcEmpleado.Controls.Add(Me.tbpChofer)
        Me.tbcEmpleado.Controls.Add(Me.tbpProduccion)
        Me.tbcEmpleado.Location = New System.Drawing.Point(12, 86)
        Me.tbcEmpleado.Name = "tbcEmpleado"
        Me.tbcEmpleado.SelectedIndex = 0
        Me.tbcEmpleado.Size = New System.Drawing.Size(567, 319)
        Me.tbcEmpleado.TabIndex = 1
        '
        'tbpDatos
        '
        Me.tbpDatos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDatos.Controls.Add(Me.CheckBox1)
        Me.tbpDatos.Controls.Add(Me.GroupBox3)
        Me.tbpDatos.Controls.Add(Me.txtValorHoraCatego)
        Me.tbpDatos.Controls.Add(Me.lblValorHoraCatego)
        Me.tbpDatos.Controls.Add(Me.cmbCategoriaEmpleado)
        Me.tbpDatos.Controls.Add(Me.lblCategoriaEmpleado)
        Me.tbpDatos.Controls.Add(Me.cmbUsuarioMovil)
        Me.tbpDatos.Controls.Add(Me.txtNroDocEmpleado)
        Me.tbpDatos.Controls.Add(Me.txtClave)
        Me.tbpDatos.Controls.Add(Me.lblClave)
        Me.tbpDatos.Controls.Add(Me.chbColor)
        Me.tbpDatos.Controls.Add(Me.lblNroDocEmpleado)
        Me.tbpDatos.Controls.Add(Me.txtNivelAutorizacion)
        Me.tbpDatos.Controls.Add(Me.txtColor)
        Me.tbpDatos.Controls.Add(Me.lblTipoDocEmpleado)
        Me.tbpDatos.Controls.Add(Me.btnColor)
        Me.tbpDatos.Controls.Add(Me.cmbTipoDocEmpleado)
        Me.tbpDatos.Controls.Add(Me.txtCelularEmpleado)
        Me.tbpDatos.Controls.Add(Me.lblNivelAutorizacion)
        Me.tbpDatos.Controls.Add(Me.lblTelefonoEmpleado)
        Me.tbpDatos.Controls.Add(Me.chbUsuario)
        Me.tbpDatos.Controls.Add(Me.lnkLocalidad)
        Me.tbpDatos.Controls.Add(Me.txtTelefonoEmpleado)
        Me.tbpDatos.Controls.Add(Me.cmbUsuario)
        Me.tbpDatos.Controls.Add(Me.bscCodigoLocalidad)
        Me.tbpDatos.Controls.Add(Me.lblCelularEmpleado)
        Me.tbpDatos.Controls.Add(Me.bscNombreLocalidad)
        Me.tbpDatos.Controls.Add(Me.lblDireccion)
        Me.tbpDatos.Controls.Add(Me.txtDireccion)
        Me.tbpDatos.Controls.Add(Me.chbUsuarioMovil)
        Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbpDatos.Name = "tbpDatos"
        Me.tbpDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDatos.Size = New System.Drawing.Size(559, 293)
        Me.tbpDatos.TabIndex = 2
        Me.tbpDatos.Text = "Datos"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BindearPropiedadControl = "Checked"
        Me.CheckBox1.BindearPropiedadEntidad = "CobraPremioCobranza"
        Me.CheckBox1.ForeColorFocus = System.Drawing.Color.Red
        Me.CheckBox1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.CheckBox1.IsPK = False
        Me.CheckBox1.IsRequired = False
        Me.CheckBox1.Key = Nothing
        Me.CheckBox1.LabelAsoc = Nothing
        Me.CheckBox1.Location = New System.Drawing.Point(365, 229)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(155, 17)
        Me.CheckBox1.TabIndex = 34
        Me.CheckBox1.Text = "Cobra Premio por Cobranza"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chbEsVendedor)
        Me.GroupBox3.Controls.Add(Me.chbEsComprador)
        Me.GroupBox3.Controls.Add(Me.chbEsTransportista)
        Me.GroupBox3.Controls.Add(Me.chbEsCobrador)
        Me.GroupBox3.Controls.Add(Me.chbResponsableProd)
        Me.GroupBox3.Location = New System.Drawing.Point(365, 64)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(137, 153)
        Me.GroupBox3.TabIndex = 33
        Me.GroupBox3.TabStop = False
        '
        'chbEsTransportista
        '
        Me.chbEsTransportista.AutoSize = True
        Me.chbEsTransportista.BindearPropiedadControl = "Checked"
        Me.chbEsTransportista.BindearPropiedadEntidad = "EsChofer"
        Me.chbEsTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsTransportista.IsPK = False
        Me.chbEsTransportista.IsRequired = False
        Me.chbEsTransportista.Key = Nothing
        Me.chbEsTransportista.LabelAsoc = Nothing
        Me.chbEsTransportista.Location = New System.Drawing.Point(31, 97)
        Me.chbEsTransportista.Name = "chbEsTransportista"
        Me.chbEsTransportista.Size = New System.Drawing.Size(57, 17)
        Me.chbEsTransportista.TabIndex = 27
        Me.chbEsTransportista.Text = "Chofer"
        Me.chbEsTransportista.UseVisualStyleBackColor = True
        '
        'chbEsCobrador
        '
        Me.chbEsCobrador.AutoSize = True
        Me.chbEsCobrador.BindearPropiedadControl = "Checked"
        Me.chbEsCobrador.BindearPropiedadEntidad = "EsCobrador"
        Me.chbEsCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsCobrador.IsPK = False
        Me.chbEsCobrador.IsRequired = False
        Me.chbEsCobrador.Key = Nothing
        Me.chbEsCobrador.LabelAsoc = Nothing
        Me.chbEsCobrador.Location = New System.Drawing.Point(31, 74)
        Me.chbEsCobrador.Name = "chbEsCobrador"
        Me.chbEsCobrador.Size = New System.Drawing.Size(69, 17)
        Me.chbEsCobrador.TabIndex = 15
        Me.chbEsCobrador.Text = "Cobrador"
        Me.chbEsCobrador.UseVisualStyleBackColor = True
        '
        'chbResponsableProd
        '
        Me.chbResponsableProd.AutoSize = True
        Me.chbResponsableProd.BindearPropiedadControl = "Checked"
        Me.chbResponsableProd.BindearPropiedadEntidad = "EsRespProd"
        Me.chbResponsableProd.ForeColorFocus = System.Drawing.Color.Red
        Me.chbResponsableProd.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbResponsableProd.IsPK = False
        Me.chbResponsableProd.IsRequired = False
        Me.chbResponsableProd.Key = Nothing
        Me.chbResponsableProd.LabelAsoc = Nothing
        Me.chbResponsableProd.Location = New System.Drawing.Point(31, 120)
        Me.chbResponsableProd.Name = "chbResponsableProd"
        Me.chbResponsableProd.Size = New System.Drawing.Size(94, 17)
        Me.chbResponsableProd.TabIndex = 19
        Me.chbResponsableProd.Text = "Operario Prod."
        Me.chbResponsableProd.UseVisualStyleBackColor = True
        '
        'txtValorHoraCatego
        '
        Me.txtValorHoraCatego.BindearPropiedadControl = ""
        Me.txtValorHoraCatego.BindearPropiedadEntidad = ""
        Me.txtValorHoraCatego.Enabled = False
        Me.txtValorHoraCatego.ForeColorFocus = System.Drawing.Color.Red
        Me.txtValorHoraCatego.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtValorHoraCatego.Formato = ""
        Me.txtValorHoraCatego.IsDecimal = False
        Me.txtValorHoraCatego.IsNumber = True
        Me.txtValorHoraCatego.IsPK = False
        Me.txtValorHoraCatego.IsRequired = False
        Me.txtValorHoraCatego.Key = ""
        Me.txtValorHoraCatego.LabelAsoc = Me.lblValorHoraCatego
        Me.txtValorHoraCatego.Location = New System.Drawing.Point(423, 258)
        Me.txtValorHoraCatego.MaxLength = 12
        Me.txtValorHoraCatego.Name = "txtValorHoraCatego"
        Me.txtValorHoraCatego.Size = New System.Drawing.Size(123, 20)
        Me.txtValorHoraCatego.TabIndex = 32
        Me.txtValorHoraCatego.TabStop = False
        Me.txtValorHoraCatego.Text = "0.00"
        Me.txtValorHoraCatego.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblValorHoraCatego
        '
        Me.lblValorHoraCatego.AutoSize = True
        Me.lblValorHoraCatego.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblValorHoraCatego.LabelAsoc = Nothing
        Me.lblValorHoraCatego.Location = New System.Drawing.Point(357, 261)
        Me.lblValorHoraCatego.Name = "lblValorHoraCatego"
        Me.lblValorHoraCatego.Size = New System.Drawing.Size(60, 13)
        Me.lblValorHoraCatego.TabIndex = 31
        Me.lblValorHoraCatego.Text = "Valor Hora "
        '
        'cmbCategoriaEmpleado
        '
        Me.cmbCategoriaEmpleado.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoriaEmpleado.BindearPropiedadEntidad = "IdCategoriaEmpleado"
        Me.cmbCategoriaEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriaEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoriaEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriaEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriaEmpleado.FormattingEnabled = True
        Me.cmbCategoriaEmpleado.IsPK = False
        Me.cmbCategoriaEmpleado.IsRequired = False
        Me.cmbCategoriaEmpleado.Key = Nothing
        Me.cmbCategoriaEmpleado.LabelAsoc = Nothing
        Me.cmbCategoriaEmpleado.Location = New System.Drawing.Point(87, 144)
        Me.cmbCategoriaEmpleado.Name = "cmbCategoriaEmpleado"
        Me.cmbCategoriaEmpleado.Size = New System.Drawing.Size(210, 21)
        Me.cmbCategoriaEmpleado.TabIndex = 14
        '
        'lblCategoriaEmpleado
        '
        Me.lblCategoriaEmpleado.AutoSize = True
        Me.lblCategoriaEmpleado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCategoriaEmpleado.LabelAsoc = Nothing
        Me.lblCategoriaEmpleado.Location = New System.Drawing.Point(16, 147)
        Me.lblCategoriaEmpleado.Name = "lblCategoriaEmpleado"
        Me.lblCategoriaEmpleado.Size = New System.Drawing.Size(54, 13)
        Me.lblCategoriaEmpleado.TabIndex = 13
        Me.lblCategoriaEmpleado.Text = "Categoría"
        '
        'cmbUsuarioMovil
        '
        Me.cmbUsuarioMovil.BindearPropiedadControl = "SelectedValue"
        Me.cmbUsuarioMovil.BindearPropiedadEntidad = "IdUsuarioMovil"
        Me.cmbUsuarioMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuarioMovil.Enabled = False
        Me.cmbUsuarioMovil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuarioMovil.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuarioMovil.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuarioMovil.FormattingEnabled = True
        Me.cmbUsuarioMovil.IsPK = False
        Me.cmbUsuarioMovil.IsRequired = False
        Me.cmbUsuarioMovil.Key = Nothing
        Me.cmbUsuarioMovil.LabelAsoc = Nothing
        Me.cmbUsuarioMovil.Location = New System.Drawing.Point(109, 198)
        Me.cmbUsuarioMovil.Name = "cmbUsuarioMovil"
        Me.cmbUsuarioMovil.Size = New System.Drawing.Size(148, 21)
        Me.cmbUsuarioMovil.TabIndex = 19
        '
        'txtClave
        '
        Me.txtClave.BindearPropiedadControl = "Text"
        Me.txtClave.BindearPropiedadEntidad = "Clave"
        Me.txtClave.ForeColorFocus = System.Drawing.Color.Red
        Me.txtClave.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtClave.Formato = ""
        Me.txtClave.IsDecimal = False
        Me.txtClave.IsNumber = False
        Me.txtClave.IsPK = False
        Me.txtClave.IsRequired = False
        Me.txtClave.Key = ""
        Me.txtClave.LabelAsoc = Me.lblClave
        Me.txtClave.Location = New System.Drawing.Point(216, 258)
        Me.txtClave.MaxLength = 15
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(133, 20)
        Me.txtClave.TabIndex = 26
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblClave.LabelAsoc = Nothing
        Me.lblClave.Location = New System.Drawing.Point(176, 261)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(34, 13)
        Me.lblClave.TabIndex = 25
        Me.lblClave.Text = "Clave"
        '
        'chbColor
        '
        Me.chbColor.AutoSize = True
        Me.chbColor.BindearPropiedadControl = Nothing
        Me.chbColor.BindearPropiedadEntidad = Nothing
        Me.chbColor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbColor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbColor.IsPK = False
        Me.chbColor.IsRequired = False
        Me.chbColor.Key = Nothing
        Me.chbColor.LabelAsoc = Nothing
        Me.chbColor.Location = New System.Drawing.Point(16, 228)
        Me.chbColor.Name = "chbColor"
        Me.chbColor.Size = New System.Drawing.Size(50, 17)
        Me.chbColor.TabIndex = 20
        Me.chbColor.Text = "Color"
        Me.chbColor.UseVisualStyleBackColor = True
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
        Me.txtNivelAutorizacion.Location = New System.Drawing.Point(125, 257)
        Me.txtNivelAutorizacion.MaxLength = 12
        Me.txtNivelAutorizacion.Name = "txtNivelAutorizacion"
        Me.txtNivelAutorizacion.Size = New System.Drawing.Size(42, 20)
        Me.txtNivelAutorizacion.TabIndex = 24
        Me.txtNivelAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNivelAutorizacion
        '
        Me.lblNivelAutorizacion.AutoSize = True
        Me.lblNivelAutorizacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNivelAutorizacion.LabelAsoc = Nothing
        Me.lblNivelAutorizacion.Location = New System.Drawing.Point(12, 260)
        Me.lblNivelAutorizacion.Name = "lblNivelAutorizacion"
        Me.lblNivelAutorizacion.Size = New System.Drawing.Size(107, 13)
        Me.lblNivelAutorizacion.TabIndex = 23
        Me.lblNivelAutorizacion.Text = "Nivel de Autorización"
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = "Key"
        Me.txtColor.BindearPropiedadEntidad = "Color"
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Nothing
        Me.txtColor.Location = New System.Drawing.Point(86, 226)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(82, 20)
        Me.txtColor.TabIndex = 21
        Me.txtColor.TabStop = False
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(175, 225)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(57, 23)
        Me.btnColor.TabIndex = 22
        Me.btnColor.Text = "Paleta"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'chbUsuarioMovil
        '
        Me.chbUsuarioMovil.AutoSize = True
        Me.chbUsuarioMovil.BindearPropiedadControl = Nothing
        Me.chbUsuarioMovil.BindearPropiedadEntidad = Nothing
        Me.chbUsuarioMovil.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuarioMovil.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuarioMovil.IsPK = False
        Me.chbUsuarioMovil.IsRequired = False
        Me.chbUsuarioMovil.Key = Nothing
        Me.chbUsuarioMovil.LabelAsoc = Nothing
        Me.chbUsuarioMovil.Location = New System.Drawing.Point(16, 200)
        Me.chbUsuarioMovil.Name = "chbUsuarioMovil"
        Me.chbUsuarioMovil.Size = New System.Drawing.Size(90, 17)
        Me.chbUsuarioMovil.TabIndex = 18
        Me.chbUsuarioMovil.Text = "Usuario Movil"
        Me.chbUsuarioMovil.UseVisualStyleBackColor = True
        '
        'tbpMapa
        '
        Me.tbpMapa.BackColor = System.Drawing.SystemColors.Control
        Me.tbpMapa.Controls.Add(Me.GroupBox1)
        Me.tbpMapa.Controls.Add(Me.lblGeoLocalizacionLat)
        Me.tbpMapa.Controls.Add(Me.btnGeolocalizar)
        Me.tbpMapa.Controls.Add(Me.lblGeoLocalizacionLng)
        Me.tbpMapa.Controls.Add(Me.cmbTipoMapa)
        Me.tbpMapa.Controls.Add(Me.txtGeoLocalizacionLat)
        Me.tbpMapa.Controls.Add(Me.tcbZoom)
        Me.tbpMapa.Controls.Add(Me.txtGeoLocalizacionLng)
        Me.tbpMapa.Location = New System.Drawing.Point(4, 22)
        Me.tbpMapa.Name = "tbpMapa"
        Me.tbpMapa.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpMapa.Size = New System.Drawing.Size(559, 293)
        Me.tbpMapa.TabIndex = 0
        Me.tbpMapa.Text = "Geolocalización"
        '
        'tbpComisiones
        '
        Me.tbpComisiones.BackColor = System.Drawing.SystemColors.Control
        Me.tbpComisiones.Controls.Add(Me.TabControl2)
        Me.tbpComisiones.Controls.Add(Me.txtComisionPorVenta)
        Me.tbpComisiones.Controls.Add(Me.lblComisionPorVenta)
        Me.tbpComisiones.Controls.Add(Me.Label1)
        Me.tbpComisiones.Location = New System.Drawing.Point(4, 22)
        Me.tbpComisiones.Name = "tbpComisiones"
        Me.tbpComisiones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpComisiones.Size = New System.Drawing.Size(559, 293)
        Me.tbpComisiones.TabIndex = 1
        Me.tbpComisiones.Text = "Comisiones"
        '
        'TabControl2
        '
        Me.TabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl2.Controls.Add(Me.tbProducto)
        Me.TabControl2.Controls.Add(Me.tpMarca)
        Me.TabControl2.Controls.Add(Me.tpRubro)
        Me.TabControl2.Controls.Add(Me.tbpSubRubro)
        Me.TabControl2.Controls.Add(Me.tbpSubSubRubro)
        Me.TabControl2.Location = New System.Drawing.Point(3, 32)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(550, 255)
        Me.TabControl2.TabIndex = 3
        '
        'tbProducto
        '
        Me.tbProducto.Controls.Add(Me.bscProducto)
        Me.tbProducto.Controls.Add(Me.bscCodigoProducto)
        Me.tbProducto.Controls.Add(Me.btnRefrescarProductos)
        Me.tbProducto.Controls.Add(Me.btnEliminarProductos)
        Me.tbProducto.Controls.Add(Me.btnInsertarProductos)
        Me.tbProducto.Controls.Add(Me.lblComisionProducto)
        Me.tbProducto.Controls.Add(Me.txtComisionProducto)
        Me.tbProducto.Controls.Add(Me.dgvComisionesProductos)
        Me.tbProducto.Location = New System.Drawing.Point(4, 25)
        Me.tbProducto.Name = "tbProducto"
        Me.tbProducto.Size = New System.Drawing.Size(542, 226)
        Me.tbProducto.TabIndex = 2
        Me.tbProducto.Text = "Producto"
        Me.tbProducto.UseVisualStyleBackColor = True
        '
        'bscProducto
        '
        Me.bscProducto.ActivarFiltroEnGrilla = True
        Me.bscProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscProducto.BindearPropiedadControl = Nothing
        Me.bscProducto.BindearPropiedadEntidad = Nothing
        Me.bscProducto.ConfigBuscador = Nothing
        Me.bscProducto.Datos = Nothing
        Me.bscProducto.FilaDevuelta = Nothing
        Me.bscProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto.IsDecimal = False
        Me.bscProducto.IsNumber = False
        Me.bscProducto.IsPK = False
        Me.bscProducto.IsRequired = False
        Me.bscProducto.Key = ""
        Me.bscProducto.LabelAsoc = Nothing
        Me.bscProducto.Location = New System.Drawing.Point(143, 7)
        Me.bscProducto.MaxLengh = "60"
        Me.bscProducto.Name = "bscProducto"
        Me.bscProducto.Permitido = True
        Me.bscProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto.Selecciono = False
        Me.bscProducto.Size = New System.Drawing.Size(219, 20)
        Me.bscProducto.TabIndex = 15
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Nothing
        Me.bscCodigoProducto.Location = New System.Drawing.Point(41, 7)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = True
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(96, 20)
        Me.bscCodigoProducto.TabIndex = 14
        '
        'btnRefrescarProductos
        '
        Me.btnRefrescarProductos.Image = CType(resources.GetObject("btnRefrescarProductos.Image"), System.Drawing.Image)
        Me.btnRefrescarProductos.Location = New System.Drawing.Point(14, 6)
        Me.btnRefrescarProductos.Name = "btnRefrescarProductos"
        Me.btnRefrescarProductos.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarProductos.TabIndex = 12
        Me.btnRefrescarProductos.UseVisualStyleBackColor = True
        '
        'btnEliminarProductos
        '
        Me.btnEliminarProductos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarProductos.Image = CType(resources.GetObject("btnEliminarProductos.Image"), System.Drawing.Image)
        Me.btnEliminarProductos.Location = New System.Drawing.Point(498, 50)
        Me.btnEliminarProductos.Name = "btnEliminarProductos"
        Me.btnEliminarProductos.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarProductos.TabIndex = 10
        Me.btnEliminarProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarProductos.UseVisualStyleBackColor = True
        '
        'btnInsertarProductos
        '
        Me.btnInsertarProductos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarProductos.Image = CType(resources.GetObject("btnInsertarProductos.Image"), System.Drawing.Image)
        Me.btnInsertarProductos.Location = New System.Drawing.Point(498, 6)
        Me.btnInsertarProductos.Name = "btnInsertarProductos"
        Me.btnInsertarProductos.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarProductos.TabIndex = 9
        Me.btnInsertarProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarProductos.UseVisualStyleBackColor = True
        '
        'lblComisionProducto
        '
        Me.lblComisionProducto.AutoSize = True
        Me.lblComisionProducto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblComisionProducto.LabelAsoc = Nothing
        Me.lblComisionProducto.Location = New System.Drawing.Point(368, 11)
        Me.lblComisionProducto.Name = "lblComisionProducto"
        Me.lblComisionProducto.Size = New System.Drawing.Size(60, 13)
        Me.lblComisionProducto.TabIndex = 13
        Me.lblComisionProducto.Text = "% Comisión"
        '
        'txtComisionProducto
        '
        Me.txtComisionProducto.BindearPropiedadControl = ""
        Me.txtComisionProducto.BindearPropiedadEntidad = ""
        Me.txtComisionProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComisionProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComisionProducto.Formato = "#,##0.00"
        Me.txtComisionProducto.IsDecimal = True
        Me.txtComisionProducto.IsNumber = True
        Me.txtComisionProducto.IsPK = False
        Me.txtComisionProducto.IsRequired = False
        Me.txtComisionProducto.Key = ""
        Me.txtComisionProducto.LabelAsoc = Me.lblComisionProducto
        Me.txtComisionProducto.Location = New System.Drawing.Point(435, 7)
        Me.txtComisionProducto.MaxLength = 7
        Me.txtComisionProducto.Name = "txtComisionProducto"
        Me.txtComisionProducto.Size = New System.Drawing.Size(57, 20)
        Me.txtComisionProducto.TabIndex = 8
        Me.txtComisionProducto.Text = "0,00"
        Me.txtComisionProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvComisionesProductos
        '
        Me.dgvComisionesProductos.AllowUserToAddRows = False
        Me.dgvComisionesProductos.AllowUserToDeleteRows = False
        Me.dgvComisionesProductos.AllowUserToResizeColumns = False
        Me.dgvComisionesProductos.AllowUserToResizeRows = False
        Me.dgvComisionesProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComisionesProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdProducto, Me.IdEmpleado2, Me.Productos, Me.ComisionP})
        Me.dgvComisionesProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComisionesProductos.Location = New System.Drawing.Point(14, 30)
        Me.dgvComisionesProductos.Name = "dgvComisionesProductos"
        Me.dgvComisionesProductos.RowHeadersVisible = False
        Me.dgvComisionesProductos.RowHeadersWidth = 10
        Me.dgvComisionesProductos.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvComisionesProductos.RowTemplate.Height = 18
        Me.dgvComisionesProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComisionesProductos.Size = New System.Drawing.Size(478, 180)
        Me.dgvComisionesProductos.TabIndex = 11
        '
        'IdProducto
        '
        Me.IdProducto.DataPropertyName = "IdProducto"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdProducto.DefaultCellStyle = DataGridViewCellStyle9
        Me.IdProducto.HeaderText = "Código"
        Me.IdProducto.Name = "IdProducto"
        Me.IdProducto.Width = 80
        '
        'IdEmpleado2
        '
        Me.IdEmpleado2.DataPropertyName = "IdEmpleado"
        Me.IdEmpleado2.HeaderText = "IdEmpleado2"
        Me.IdEmpleado2.Name = "IdEmpleado2"
        Me.IdEmpleado2.Visible = False
        '
        'Productos
        '
        Me.Productos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Productos.DataPropertyName = "NombreProducto"
        Me.Productos.HeaderText = "Producto"
        Me.Productos.Name = "Productos"
        '
        'ComisionP
        '
        Me.ComisionP.DataPropertyName = "Comision"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.ComisionP.DefaultCellStyle = DataGridViewCellStyle10
        Me.ComisionP.HeaderText = "Comisión"
        Me.ComisionP.Name = "ComisionP"
        Me.ComisionP.Width = 60
        '
        'tpMarca
        '
        Me.tpMarca.Controls.Add(Me.btnRefrescarMarcas)
        Me.tpMarca.Controls.Add(Me.lblComisionMarcas)
        Me.tpMarca.Controls.Add(Me.btnEliminarMarca)
        Me.tpMarca.Controls.Add(Me.txtComisionMarcas)
        Me.tpMarca.Controls.Add(Me.dgvComisionesMarcas)
        Me.tpMarca.Controls.Add(Me.btnInsertarMarca)
        Me.tpMarca.Controls.Add(Me.cmbMarcas)
        Me.tpMarca.Location = New System.Drawing.Point(4, 25)
        Me.tpMarca.Name = "tpMarca"
        Me.tpMarca.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMarca.Size = New System.Drawing.Size(542, 226)
        Me.tpMarca.TabIndex = 0
        Me.tpMarca.Text = "Marca"
        Me.tpMarca.UseVisualStyleBackColor = True
        '
        'btnRefrescarMarcas
        '
        Me.btnRefrescarMarcas.Image = CType(resources.GetObject("btnRefrescarMarcas.Image"), System.Drawing.Image)
        Me.btnRefrescarMarcas.Location = New System.Drawing.Point(14, 6)
        Me.btnRefrescarMarcas.Name = "btnRefrescarMarcas"
        Me.btnRefrescarMarcas.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarMarcas.TabIndex = 0
        Me.btnRefrescarMarcas.UseVisualStyleBackColor = True
        '
        'lblComisionMarcas
        '
        Me.lblComisionMarcas.AutoSize = True
        Me.lblComisionMarcas.LabelAsoc = Nothing
        Me.lblComisionMarcas.Location = New System.Drawing.Point(368, 11)
        Me.lblComisionMarcas.Name = "lblComisionMarcas"
        Me.lblComisionMarcas.Size = New System.Drawing.Size(60, 13)
        Me.lblComisionMarcas.TabIndex = 2
        Me.lblComisionMarcas.Text = "% Comisión"
        '
        'btnEliminarMarca
        '
        Me.btnEliminarMarca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarMarca.Image = CType(resources.GetObject("btnEliminarMarca.Image"), System.Drawing.Image)
        Me.btnEliminarMarca.Location = New System.Drawing.Point(498, 50)
        Me.btnEliminarMarca.Name = "btnEliminarMarca"
        Me.btnEliminarMarca.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarMarca.TabIndex = 5
        Me.btnEliminarMarca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarMarca.UseVisualStyleBackColor = True
        '
        'txtComisionMarcas
        '
        Me.txtComisionMarcas.BindearPropiedadControl = ""
        Me.txtComisionMarcas.BindearPropiedadEntidad = ""
        Me.txtComisionMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComisionMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComisionMarcas.Formato = "#,##0.00"
        Me.txtComisionMarcas.IsDecimal = True
        Me.txtComisionMarcas.IsNumber = True
        Me.txtComisionMarcas.IsPK = False
        Me.txtComisionMarcas.IsRequired = False
        Me.txtComisionMarcas.Key = ""
        Me.txtComisionMarcas.LabelAsoc = Me.lblComisionMarcas
        Me.txtComisionMarcas.Location = New System.Drawing.Point(435, 7)
        Me.txtComisionMarcas.MaxLength = 7
        Me.txtComisionMarcas.Name = "txtComisionMarcas"
        Me.txtComisionMarcas.Size = New System.Drawing.Size(57, 20)
        Me.txtComisionMarcas.TabIndex = 3
        Me.txtComisionMarcas.Text = "0.00"
        Me.txtComisionMarcas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvComisionesMarcas
        '
        Me.dgvComisionesMarcas.AllowUserToAddRows = False
        Me.dgvComisionesMarcas.AllowUserToDeleteRows = False
        Me.dgvComisionesMarcas.AllowUserToResizeColumns = False
        Me.dgvComisionesMarcas.AllowUserToResizeRows = False
        Me.dgvComisionesMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComisionesMarcas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdMarca, Me.IdEmpleado, Me.Marca, Me.Comision})
        Me.dgvComisionesMarcas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComisionesMarcas.Location = New System.Drawing.Point(14, 30)
        Me.dgvComisionesMarcas.Name = "dgvComisionesMarcas"
        Me.dgvComisionesMarcas.RowHeadersVisible = False
        Me.dgvComisionesMarcas.RowHeadersWidth = 10
        Me.dgvComisionesMarcas.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvComisionesMarcas.RowTemplate.Height = 18
        Me.dgvComisionesMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComisionesMarcas.Size = New System.Drawing.Size(478, 180)
        Me.dgvComisionesMarcas.TabIndex = 6
        '
        'IdMarca
        '
        Me.IdMarca.DataPropertyName = "IdMarca"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdMarca.DefaultCellStyle = DataGridViewCellStyle11
        Me.IdMarca.HeaderText = "Código"
        Me.IdMarca.Name = "IdMarca"
        Me.IdMarca.Width = 80
        '
        'IdEmpleado
        '
        Me.IdEmpleado.DataPropertyName = "IdEmpleado"
        Me.IdEmpleado.HeaderText = "IdEmpleado"
        Me.IdEmpleado.Name = "IdEmpleado"
        Me.IdEmpleado.Visible = False
        '
        'Marca
        '
        Me.Marca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Marca.DataPropertyName = "NombreMarca"
        Me.Marca.HeaderText = "Marca"
        Me.Marca.Name = "Marca"
        '
        'Comision
        '
        Me.Comision.DataPropertyName = "Comision"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.Comision.DefaultCellStyle = DataGridViewCellStyle12
        Me.Comision.HeaderText = "Comisión"
        Me.Comision.Name = "Comision"
        Me.Comision.Width = 60
        '
        'btnInsertarMarca
        '
        Me.btnInsertarMarca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarMarca.Image = CType(resources.GetObject("btnInsertarMarca.Image"), System.Drawing.Image)
        Me.btnInsertarMarca.Location = New System.Drawing.Point(498, 6)
        Me.btnInsertarMarca.Name = "btnInsertarMarca"
        Me.btnInsertarMarca.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarMarca.TabIndex = 4
        Me.btnInsertarMarca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarMarca.UseVisualStyleBackColor = True
        '
        'cmbMarcas
        '
        Me.cmbMarcas.BindearPropiedadControl = ""
        Me.cmbMarcas.BindearPropiedadEntidad = ""
        Me.cmbMarcas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarcas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarcas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarcas.FormattingEnabled = True
        Me.cmbMarcas.IsPK = False
        Me.cmbMarcas.IsRequired = False
        Me.cmbMarcas.Key = Nothing
        Me.cmbMarcas.LabelAsoc = Nothing
        Me.cmbMarcas.Location = New System.Drawing.Point(41, 7)
        Me.cmbMarcas.Name = "cmbMarcas"
        Me.cmbMarcas.Size = New System.Drawing.Size(321, 21)
        Me.cmbMarcas.TabIndex = 1
        '
        'tpRubro
        '
        Me.tpRubro.Controls.Add(Me.btnRefrescarRubros)
        Me.tpRubro.Controls.Add(Me.btnEliminarRubros)
        Me.tpRubro.Controls.Add(Me.btnInsertarRubros)
        Me.tpRubro.Controls.Add(Me.lblComisionRubro)
        Me.tpRubro.Controls.Add(Me.txtComisionRubro)
        Me.tpRubro.Controls.Add(Me.dgvComisionesRubros)
        Me.tpRubro.Controls.Add(Me.cmbRubros)
        Me.tpRubro.Location = New System.Drawing.Point(4, 25)
        Me.tpRubro.Name = "tpRubro"
        Me.tpRubro.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRubro.Size = New System.Drawing.Size(542, 226)
        Me.tpRubro.TabIndex = 1
        Me.tpRubro.Text = "Rubro"
        Me.tpRubro.UseVisualStyleBackColor = True
        '
        'btnRefrescarRubros
        '
        Me.btnRefrescarRubros.Image = CType(resources.GetObject("btnRefrescarRubros.Image"), System.Drawing.Image)
        Me.btnRefrescarRubros.Location = New System.Drawing.Point(14, 6)
        Me.btnRefrescarRubros.Name = "btnRefrescarRubros"
        Me.btnRefrescarRubros.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarRubros.TabIndex = 12
        Me.btnRefrescarRubros.UseVisualStyleBackColor = True
        '
        'btnEliminarRubros
        '
        Me.btnEliminarRubros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarRubros.Image = CType(resources.GetObject("btnEliminarRubros.Image"), System.Drawing.Image)
        Me.btnEliminarRubros.Location = New System.Drawing.Point(498, 50)
        Me.btnEliminarRubros.Name = "btnEliminarRubros"
        Me.btnEliminarRubros.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarRubros.TabIndex = 10
        Me.btnEliminarRubros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarRubros.UseVisualStyleBackColor = True
        '
        'btnInsertarRubros
        '
        Me.btnInsertarRubros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarRubros.Image = CType(resources.GetObject("btnInsertarRubros.Image"), System.Drawing.Image)
        Me.btnInsertarRubros.Location = New System.Drawing.Point(498, 6)
        Me.btnInsertarRubros.Name = "btnInsertarRubros"
        Me.btnInsertarRubros.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarRubros.TabIndex = 9
        Me.btnInsertarRubros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarRubros.UseVisualStyleBackColor = True
        '
        'lblComisionRubro
        '
        Me.lblComisionRubro.AutoSize = True
        Me.lblComisionRubro.LabelAsoc = Nothing
        Me.lblComisionRubro.Location = New System.Drawing.Point(368, 11)
        Me.lblComisionRubro.Name = "lblComisionRubro"
        Me.lblComisionRubro.Size = New System.Drawing.Size(60, 13)
        Me.lblComisionRubro.TabIndex = 13
        Me.lblComisionRubro.Text = "% Comisión"
        '
        'txtComisionRubro
        '
        Me.txtComisionRubro.BindearPropiedadControl = ""
        Me.txtComisionRubro.BindearPropiedadEntidad = ""
        Me.txtComisionRubro.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComisionRubro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComisionRubro.Formato = "#,##0.00"
        Me.txtComisionRubro.IsDecimal = True
        Me.txtComisionRubro.IsNumber = True
        Me.txtComisionRubro.IsPK = False
        Me.txtComisionRubro.IsRequired = False
        Me.txtComisionRubro.Key = ""
        Me.txtComisionRubro.LabelAsoc = Me.lblComisionRubro
        Me.txtComisionRubro.Location = New System.Drawing.Point(435, 7)
        Me.txtComisionRubro.MaxLength = 7
        Me.txtComisionRubro.Name = "txtComisionRubro"
        Me.txtComisionRubro.Size = New System.Drawing.Size(57, 20)
        Me.txtComisionRubro.TabIndex = 8
        Me.txtComisionRubro.Text = "0.00"
        Me.txtComisionRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvComisionesRubros
        '
        Me.dgvComisionesRubros.AllowUserToAddRows = False
        Me.dgvComisionesRubros.AllowUserToDeleteRows = False
        Me.dgvComisionesRubros.AllowUserToResizeColumns = False
        Me.dgvComisionesRubros.AllowUserToResizeRows = False
        Me.dgvComisionesRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComisionesRubros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdEmpleado1, Me.IdRubro, Me.Rubros, Me.ComisionR})
        Me.dgvComisionesRubros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComisionesRubros.Location = New System.Drawing.Point(14, 30)
        Me.dgvComisionesRubros.Name = "dgvComisionesRubros"
        Me.dgvComisionesRubros.RowHeadersVisible = False
        Me.dgvComisionesRubros.RowHeadersWidth = 10
        Me.dgvComisionesRubros.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvComisionesRubros.RowTemplate.Height = 18
        Me.dgvComisionesRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComisionesRubros.Size = New System.Drawing.Size(478, 178)
        Me.dgvComisionesRubros.TabIndex = 11
        '
        'IdEmpleado1
        '
        Me.IdEmpleado1.DataPropertyName = "IdEmpleado"
        Me.IdEmpleado1.HeaderText = "IdEmpleado1"
        Me.IdEmpleado1.Name = "IdEmpleado1"
        Me.IdEmpleado1.Visible = False
        '
        'IdRubro
        '
        Me.IdRubro.DataPropertyName = "IdRubro"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IdRubro.DefaultCellStyle = DataGridViewCellStyle13
        Me.IdRubro.HeaderText = "Código"
        Me.IdRubro.Name = "IdRubro"
        Me.IdRubro.Width = 80
        '
        'Rubros
        '
        Me.Rubros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Rubros.DataPropertyName = "NombreRubro"
        Me.Rubros.HeaderText = "Rubro"
        Me.Rubros.Name = "Rubros"
        '
        'ComisionR
        '
        Me.ComisionR.DataPropertyName = "Comision"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.ComisionR.DefaultCellStyle = DataGridViewCellStyle14
        Me.ComisionR.HeaderText = "Comisión"
        Me.ComisionR.Name = "ComisionR"
        Me.ComisionR.Width = 60
        '
        'cmbRubros
        '
        Me.cmbRubros.BindearPropiedadControl = ""
        Me.cmbRubros.BindearPropiedadEntidad = ""
        Me.cmbRubros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRubros.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRubros.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRubros.FormattingEnabled = True
        Me.cmbRubros.IsPK = False
        Me.cmbRubros.IsRequired = False
        Me.cmbRubros.Key = Nothing
        Me.cmbRubros.LabelAsoc = Nothing
        Me.cmbRubros.Location = New System.Drawing.Point(41, 7)
        Me.cmbRubros.Name = "cmbRubros"
        Me.cmbRubros.Size = New System.Drawing.Size(321, 21)
        Me.cmbRubros.TabIndex = 7
        '
        'tbpSubRubro
        '
        Me.tbpSubRubro.Controls.Add(Me.btnEliminarSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.btnInsertarSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.txtDescuentoSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.lblDescuentoSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.lblSubRubro)
        Me.tbpSubRubro.Controls.Add(Me.lblRubro)
        Me.tbpSubRubro.Controls.Add(Me.bscCodigoSubRubro1)
        Me.tbpSubRubro.Controls.Add(Me.bscNombreSubRubro1)
        Me.tbpSubRubro.Controls.Add(Me.bscNombreRubro1)
        Me.tbpSubRubro.Controls.Add(Me.bscCodigoRubro1)
        Me.tbpSubRubro.Controls.Add(Me.btnRefrescarSubRubros)
        Me.tbpSubRubro.Controls.Add(Me.dgvComisionesSubRubros)
        Me.tbpSubRubro.Location = New System.Drawing.Point(4, 25)
        Me.tbpSubRubro.Name = "tbpSubRubro"
        Me.tbpSubRubro.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSubRubro.Size = New System.Drawing.Size(542, 226)
        Me.tbpSubRubro.TabIndex = 3
        Me.tbpSubRubro.Text = "Sub Rubro"
        Me.tbpSubRubro.UseVisualStyleBackColor = True
        '
        'btnEliminarSubRubros
        '
        Me.btnEliminarSubRubros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarSubRubros.Image = CType(resources.GetObject("btnEliminarSubRubros.Image"), System.Drawing.Image)
        Me.btnEliminarSubRubros.Location = New System.Drawing.Point(496, 106)
        Me.btnEliminarSubRubros.Name = "btnEliminarSubRubros"
        Me.btnEliminarSubRubros.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarSubRubros.TabIndex = 21
        Me.btnEliminarSubRubros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarSubRubros.UseVisualStyleBackColor = True
        '
        'btnInsertarSubRubros
        '
        Me.btnInsertarSubRubros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarSubRubros.Image = CType(resources.GetObject("btnInsertarSubRubros.Image"), System.Drawing.Image)
        Me.btnInsertarSubRubros.Location = New System.Drawing.Point(496, 62)
        Me.btnInsertarSubRubros.Name = "btnInsertarSubRubros"
        Me.btnInsertarSubRubros.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarSubRubros.TabIndex = 20
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
        Me.txtDescuentoSubRubros.Location = New System.Drawing.Point(476, 8)
        Me.txtDescuentoSubRubros.MaxLength = 7
        Me.txtDescuentoSubRubros.Name = "txtDescuentoSubRubros"
        Me.txtDescuentoSubRubros.Size = New System.Drawing.Size(58, 20)
        Me.txtDescuentoSubRubros.TabIndex = 19
        Me.txtDescuentoSubRubros.Text = "0,00"
        Me.txtDescuentoSubRubros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuentoSubRubros
        '
        Me.lblDescuentoSubRubros.AutoSize = True
        Me.lblDescuentoSubRubros.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoSubRubros.LabelAsoc = Nothing
        Me.lblDescuentoSubRubros.Location = New System.Drawing.Point(410, 12)
        Me.lblDescuentoSubRubros.Name = "lblDescuentoSubRubros"
        Me.lblDescuentoSubRubros.Size = New System.Drawing.Size(60, 13)
        Me.lblDescuentoSubRubros.TabIndex = 18
        Me.lblDescuentoSubRubros.Text = "% Comisión"
        '
        'lblSubRubro
        '
        Me.lblSubRubro.AutoSize = True
        Me.lblSubRubro.LabelAsoc = Nothing
        Me.lblSubRubro.Location = New System.Drawing.Point(15, 40)
        Me.lblSubRubro.Name = "lblSubRubro"
        Me.lblSubRubro.Size = New System.Drawing.Size(55, 13)
        Me.lblSubRubro.TabIndex = 14
        Me.lblSubRubro.Text = "SubRubro"
        '
        'lblRubro
        '
        Me.lblRubro.AutoSize = True
        Me.lblRubro.LabelAsoc = Nothing
        Me.lblRubro.Location = New System.Drawing.Point(34, 12)
        Me.lblRubro.Name = "lblRubro"
        Me.lblRubro.Size = New System.Drawing.Size(36, 13)
        Me.lblRubro.TabIndex = 11
        Me.lblRubro.Text = "Rubro"
        '
        'bscCodigoSubRubro1
        '
        Me.bscCodigoSubRubro1.ActivarFiltroEnGrilla = True
        Me.bscCodigoSubRubro1.BindearPropiedadControl = "Text"
        Me.bscCodigoSubRubro1.BindearPropiedadEntidad = "IdSubRubro"
        Me.bscCodigoSubRubro1.ConfigBuscador = Nothing
        Me.bscCodigoSubRubro1.Datos = Nothing
        Me.bscCodigoSubRubro1.FilaDevuelta = Nothing
        Me.bscCodigoSubRubro1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoSubRubro1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoSubRubro1.IsDecimal = False
        Me.bscCodigoSubRubro1.IsNumber = True
        Me.bscCodigoSubRubro1.IsPK = False
        Me.bscCodigoSubRubro1.IsRequired = False
        Me.bscCodigoSubRubro1.Key = ""
        Me.bscCodigoSubRubro1.LabelAsoc = Nothing
        Me.bscCodigoSubRubro1.Location = New System.Drawing.Point(71, 37)
        Me.bscCodigoSubRubro1.MaxLengh = "32767"
        Me.bscCodigoSubRubro1.Name = "bscCodigoSubRubro1"
        Me.bscCodigoSubRubro1.Permitido = True
        Me.bscCodigoSubRubro1.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoSubRubro1.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoSubRubro1.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoSubRubro1.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoSubRubro1.Selecciono = False
        Me.bscCodigoSubRubro1.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoSubRubro1.TabIndex = 15
        '
        'bscNombreSubRubro1
        '
        Me.bscNombreSubRubro1.ActivarFiltroEnGrilla = True
        Me.bscNombreSubRubro1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscNombreSubRubro1.BindearPropiedadControl = Nothing
        Me.bscNombreSubRubro1.BindearPropiedadEntidad = Nothing
        Me.bscNombreSubRubro1.ConfigBuscador = Nothing
        Me.bscNombreSubRubro1.Datos = Nothing
        Me.bscNombreSubRubro1.FilaDevuelta = Nothing
        Me.bscNombreSubRubro1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreSubRubro1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreSubRubro1.IsDecimal = False
        Me.bscNombreSubRubro1.IsNumber = False
        Me.bscNombreSubRubro1.IsPK = False
        Me.bscNombreSubRubro1.IsRequired = False
        Me.bscNombreSubRubro1.Key = ""
        Me.bscNombreSubRubro1.LabelAsoc = Nothing
        Me.bscNombreSubRubro1.Location = New System.Drawing.Point(169, 37)
        Me.bscNombreSubRubro1.MaxLengh = "32767"
        Me.bscNombreSubRubro1.Name = "bscNombreSubRubro1"
        Me.bscNombreSubRubro1.Permitido = True
        Me.bscNombreSubRubro1.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreSubRubro1.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreSubRubro1.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreSubRubro1.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreSubRubro1.Selecciono = False
        Me.bscNombreSubRubro1.Size = New System.Drawing.Size(239, 20)
        Me.bscNombreSubRubro1.TabIndex = 16
        '
        'bscNombreRubro1
        '
        Me.bscNombreRubro1.ActivarFiltroEnGrilla = True
        Me.bscNombreRubro1.BindearPropiedadControl = Nothing
        Me.bscNombreRubro1.BindearPropiedadEntidad = Nothing
        Me.bscNombreRubro1.ConfigBuscador = Nothing
        Me.bscNombreRubro1.Datos = Nothing
        Me.bscNombreRubro1.FilaDevuelta = Nothing
        Me.bscNombreRubro1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreRubro1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreRubro1.IsDecimal = False
        Me.bscNombreRubro1.IsNumber = False
        Me.bscNombreRubro1.IsPK = False
        Me.bscNombreRubro1.IsRequired = False
        Me.bscNombreRubro1.Key = ""
        Me.bscNombreRubro1.LabelAsoc = Nothing
        Me.bscNombreRubro1.Location = New System.Drawing.Point(169, 8)
        Me.bscNombreRubro1.MaxLengh = "32767"
        Me.bscNombreRubro1.Name = "bscNombreRubro1"
        Me.bscNombreRubro1.Permitido = True
        Me.bscNombreRubro1.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreRubro1.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreRubro1.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreRubro1.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreRubro1.Selecciono = False
        Me.bscNombreRubro1.Size = New System.Drawing.Size(239, 20)
        Me.bscNombreRubro1.TabIndex = 13
        '
        'bscCodigoRubro1
        '
        Me.bscCodigoRubro1.ActivarFiltroEnGrilla = True
        Me.bscCodigoRubro1.BindearPropiedadControl = "Text"
        Me.bscCodigoRubro1.BindearPropiedadEntidad = "IdRubro"
        Me.bscCodigoRubro1.ConfigBuscador = Nothing
        Me.bscCodigoRubro1.Datos = Nothing
        Me.bscCodigoRubro1.FilaDevuelta = Nothing
        Me.bscCodigoRubro1.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro1.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro1.IsDecimal = False
        Me.bscCodigoRubro1.IsNumber = True
        Me.bscCodigoRubro1.IsPK = False
        Me.bscCodigoRubro1.IsRequired = False
        Me.bscCodigoRubro1.Key = ""
        Me.bscCodigoRubro1.LabelAsoc = Nothing
        Me.bscCodigoRubro1.Location = New System.Drawing.Point(71, 8)
        Me.bscCodigoRubro1.MaxLengh = "32767"
        Me.bscCodigoRubro1.Name = "bscCodigoRubro1"
        Me.bscCodigoRubro1.Permitido = True
        Me.bscCodigoRubro1.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoRubro1.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoRubro1.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoRubro1.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoRubro1.Selecciono = False
        Me.bscCodigoRubro1.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoRubro1.TabIndex = 12
        '
        'btnRefrescarSubRubros
        '
        Me.btnRefrescarSubRubros.Image = CType(resources.GetObject("btnRefrescarSubRubros.Image"), System.Drawing.Image)
        Me.btnRefrescarSubRubros.Location = New System.Drawing.Point(8, 8)
        Me.btnRefrescarSubRubros.Name = "btnRefrescarSubRubros"
        Me.btnRefrescarSubRubros.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarSubRubros.TabIndex = 10
        Me.btnRefrescarSubRubros.UseVisualStyleBackColor = True
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
        Me.dgvComisionesSubRubros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdEmpleadoTwo, Me.DataGridViewTextBoxColumn1, Me.NombreRubro, Me.IdSubRubro, Me.NombreSubRubro, Me.ComisionSubRubro})
        Me.dgvComisionesSubRubros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComisionesSubRubros.Location = New System.Drawing.Point(6, 63)
        Me.dgvComisionesSubRubros.Name = "dgvComisionesSubRubros"
        Me.dgvComisionesSubRubros.RowHeadersVisible = False
        Me.dgvComisionesSubRubros.RowHeadersWidth = 10
        Me.dgvComisionesSubRubros.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvComisionesSubRubros.RowTemplate.Height = 18
        Me.dgvComisionesSubRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComisionesSubRubros.Size = New System.Drawing.Size(484, 162)
        Me.dgvComisionesSubRubros.TabIndex = 17
        '
        'IdEmpleadoTwo
        '
        Me.IdEmpleadoTwo.DataPropertyName = "IdEmpleado"
        Me.IdEmpleadoTwo.HeaderText = "IdEmpleado"
        Me.IdEmpleadoTwo.Name = "IdEmpleadoTwo"
        Me.IdEmpleadoTwo.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IdRubro"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdRubro"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'NombreRubro
        '
        Me.NombreRubro.DataPropertyName = "NombreRubro"
        Me.NombreRubro.HeaderText = "Rubro"
        Me.NombreRubro.Name = "NombreRubro"
        Me.NombreRubro.Width = 190
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
        Me.NombreSubRubro.Width = 190
        '
        'ComisionSubRubro
        '
        Me.ComisionSubRubro.DataPropertyName = "Comision"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        Me.ComisionSubRubro.DefaultCellStyle = DataGridViewCellStyle15
        Me.ComisionSubRubro.HeaderText = "Comisión"
        Me.ComisionSubRubro.Name = "ComisionSubRubro"
        '
        'tbpSubSubRubro
        '
        Me.tbpSubSubRubro.Controls.Add(Me.btnEliminarSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.btnInsertarSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.dgvComisionesSubSubRubros)
        Me.tbpSubSubRubro.Controls.Add(Me.lblDescuentoSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.txtDescuentoSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.bscCodigoSubSubRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscNombreSubSubRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.Label3)
        Me.tbpSubSubRubro.Controls.Add(Me.Label4)
        Me.tbpSubSubRubro.Controls.Add(Me.bscCodigoSubRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscNombreSubRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscNombreRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.bscCodigoRubro2)
        Me.tbpSubSubRubro.Controls.Add(Me.btnRefrescarSubSubRubro)
        Me.tbpSubSubRubro.Controls.Add(Me.Label5)
        Me.tbpSubSubRubro.Location = New System.Drawing.Point(4, 25)
        Me.tbpSubSubRubro.Name = "tbpSubSubRubro"
        Me.tbpSubSubRubro.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpSubSubRubro.Size = New System.Drawing.Size(542, 226)
        Me.tbpSubSubRubro.TabIndex = 4
        Me.tbpSubSubRubro.Text = "Sub Sub Rubro"
        Me.tbpSubSubRubro.UseVisualStyleBackColor = True
        '
        'btnEliminarSubSubRubro
        '
        Me.btnEliminarSubSubRubro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarSubSubRubro.Image = CType(resources.GetObject("btnEliminarSubSubRubro.Image"), System.Drawing.Image)
        Me.btnEliminarSubSubRubro.Location = New System.Drawing.Point(495, 134)
        Me.btnEliminarSubSubRubro.Name = "btnEliminarSubSubRubro"
        Me.btnEliminarSubSubRubro.Size = New System.Drawing.Size(38, 38)
        Me.btnEliminarSubSubRubro.TabIndex = 24
        Me.btnEliminarSubSubRubro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminarSubSubRubro.UseVisualStyleBackColor = True
        '
        'btnInsertarSubSubRubro
        '
        Me.btnInsertarSubSubRubro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarSubSubRubro.Image = CType(resources.GetObject("btnInsertarSubSubRubro.Image"), System.Drawing.Image)
        Me.btnInsertarSubSubRubro.Location = New System.Drawing.Point(495, 89)
        Me.btnInsertarSubSubRubro.Name = "btnInsertarSubSubRubro"
        Me.btnInsertarSubSubRubro.Size = New System.Drawing.Size(38, 38)
        Me.btnInsertarSubSubRubro.TabIndex = 23
        Me.btnInsertarSubSubRubro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertarSubSubRubro.UseVisualStyleBackColor = True
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
        Me.dgvComisionesSubSubRubros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdCategoriaTres, Me.IdRubroTwo, Me.NombreRubroTwo, Me.IdSubRubroTwo, Me.NombreSubRubroTwo, Me.IdSubSubRubro, Me.NombreSubSubRubro, Me.ComisionSubSubRubro})
        Me.dgvComisionesSubSubRubros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComisionesSubSubRubros.Location = New System.Drawing.Point(7, 89)
        Me.dgvComisionesSubSubRubros.Name = "dgvComisionesSubSubRubros"
        Me.dgvComisionesSubSubRubros.RowHeadersVisible = False
        Me.dgvComisionesSubSubRubros.RowHeadersWidth = 10
        Me.dgvComisionesSubSubRubros.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.dgvComisionesSubSubRubros.RowTemplate.Height = 18
        Me.dgvComisionesSubSubRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComisionesSubSubRubros.Size = New System.Drawing.Size(482, 131)
        Me.dgvComisionesSubSubRubros.TabIndex = 22
        '
        'IdCategoriaTres
        '
        Me.IdCategoriaTres.DataPropertyName = "IdEmpleado"
        Me.IdCategoriaTres.HeaderText = "IdEmpleado"
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
        Me.NombreRubroTwo.Width = 125
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
        Me.NombreSubRubroTwo.Width = 125
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
        Me.NombreSubSubRubro.Width = 125
        '
        'ComisionSubSubRubro
        '
        Me.ComisionSubSubRubro.DataPropertyName = "Comision"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        Me.ComisionSubSubRubro.DefaultCellStyle = DataGridViewCellStyle16
        Me.ComisionSubSubRubro.HeaderText = "Comisión"
        Me.ComisionSubSubRubro.Name = "ComisionSubSubRubro"
        Me.ComisionSubSubRubro.Width = 104
        '
        'lblDescuentoSubSubRubro
        '
        Me.lblDescuentoSubSubRubro.AutoSize = True
        Me.lblDescuentoSubSubRubro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescuentoSubSubRubro.LabelAsoc = Nothing
        Me.lblDescuentoSubSubRubro.Location = New System.Drawing.Point(405, 10)
        Me.lblDescuentoSubSubRubro.Name = "lblDescuentoSubSubRubro"
        Me.lblDescuentoSubSubRubro.Size = New System.Drawing.Size(60, 13)
        Me.lblDescuentoSubSubRubro.TabIndex = 20
        Me.lblDescuentoSubSubRubro.Text = "% Comisión"
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
        Me.txtDescuentoSubSubRubro.Location = New System.Drawing.Point(471, 7)
        Me.txtDescuentoSubSubRubro.MaxLength = 7
        Me.txtDescuentoSubSubRubro.Name = "txtDescuentoSubSubRubro"
        Me.txtDescuentoSubSubRubro.Size = New System.Drawing.Size(62, 20)
        Me.txtDescuentoSubSubRubro.TabIndex = 21
        Me.txtDescuentoSubSubRubro.Text = "0,00"
        Me.txtDescuentoSubSubRubro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'bscCodigoSubSubRubro2
        '
        Me.bscCodigoSubSubRubro2.ActivarFiltroEnGrilla = True
        Me.bscCodigoSubSubRubro2.BindearPropiedadControl = "Text"
        Me.bscCodigoSubSubRubro2.BindearPropiedadEntidad = "IdSubRubro"
        Me.bscCodigoSubSubRubro2.ConfigBuscador = Nothing
        Me.bscCodigoSubSubRubro2.Datos = Nothing
        Me.bscCodigoSubSubRubro2.FilaDevuelta = Nothing
        Me.bscCodigoSubSubRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoSubSubRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoSubSubRubro2.IsDecimal = False
        Me.bscCodigoSubSubRubro2.IsNumber = True
        Me.bscCodigoSubSubRubro2.IsPK = False
        Me.bscCodigoSubSubRubro2.IsRequired = False
        Me.bscCodigoSubSubRubro2.Key = ""
        Me.bscCodigoSubSubRubro2.LabelAsoc = Nothing
        Me.bscCodigoSubSubRubro2.Location = New System.Drawing.Point(80, 63)
        Me.bscCodigoSubSubRubro2.MaxLengh = "32767"
        Me.bscCodigoSubSubRubro2.Name = "bscCodigoSubSubRubro2"
        Me.bscCodigoSubSubRubro2.Permitido = True
        Me.bscCodigoSubSubRubro2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoSubSubRubro2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoSubSubRubro2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoSubSubRubro2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoSubSubRubro2.Selecciono = False
        Me.bscCodigoSubSubRubro2.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoSubSubRubro2.TabIndex = 18
        '
        'bscNombreSubSubRubro2
        '
        Me.bscNombreSubSubRubro2.ActivarFiltroEnGrilla = True
        Me.bscNombreSubSubRubro2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscNombreSubSubRubro2.BindearPropiedadControl = Nothing
        Me.bscNombreSubSubRubro2.BindearPropiedadEntidad = Nothing
        Me.bscNombreSubSubRubro2.ConfigBuscador = Nothing
        Me.bscNombreSubSubRubro2.Datos = Nothing
        Me.bscNombreSubSubRubro2.FilaDevuelta = Nothing
        Me.bscNombreSubSubRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreSubSubRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreSubSubRubro2.IsDecimal = False
        Me.bscNombreSubSubRubro2.IsNumber = False
        Me.bscNombreSubSubRubro2.IsPK = False
        Me.bscNombreSubSubRubro2.IsRequired = False
        Me.bscNombreSubSubRubro2.Key = ""
        Me.bscNombreSubSubRubro2.LabelAsoc = Nothing
        Me.bscNombreSubSubRubro2.Location = New System.Drawing.Point(179, 63)
        Me.bscNombreSubSubRubro2.MaxLengh = "32767"
        Me.bscNombreSubSubRubro2.Name = "bscNombreSubSubRubro2"
        Me.bscNombreSubSubRubro2.Permitido = True
        Me.bscNombreSubSubRubro2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreSubSubRubro2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreSubSubRubro2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreSubSubRubro2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreSubSubRubro2.Selecciono = False
        Me.bscNombreSubSubRubro2.Size = New System.Drawing.Size(237, 20)
        Me.bscNombreSubSubRubro2.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(23, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "SubRubro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(42, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Rubro"
        '
        'bscCodigoSubRubro2
        '
        Me.bscCodigoSubRubro2.ActivarFiltroEnGrilla = True
        Me.bscCodigoSubRubro2.BindearPropiedadControl = "Text"
        Me.bscCodigoSubRubro2.BindearPropiedadEntidad = "IdSubRubro"
        Me.bscCodigoSubRubro2.ConfigBuscador = Nothing
        Me.bscCodigoSubRubro2.Datos = Nothing
        Me.bscCodigoSubRubro2.FilaDevuelta = Nothing
        Me.bscCodigoSubRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoSubRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoSubRubro2.IsDecimal = False
        Me.bscCodigoSubRubro2.IsNumber = True
        Me.bscCodigoSubRubro2.IsPK = False
        Me.bscCodigoSubRubro2.IsRequired = False
        Me.bscCodigoSubRubro2.Key = ""
        Me.bscCodigoSubRubro2.LabelAsoc = Nothing
        Me.bscCodigoSubRubro2.Location = New System.Drawing.Point(80, 35)
        Me.bscCodigoSubRubro2.MaxLengh = "32767"
        Me.bscCodigoSubRubro2.Name = "bscCodigoSubRubro2"
        Me.bscCodigoSubRubro2.Permitido = True
        Me.bscCodigoSubRubro2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoSubRubro2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoSubRubro2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoSubRubro2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoSubRubro2.Selecciono = False
        Me.bscCodigoSubRubro2.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoSubRubro2.TabIndex = 15
        '
        'bscNombreSubRubro2
        '
        Me.bscNombreSubRubro2.ActivarFiltroEnGrilla = True
        Me.bscNombreSubRubro2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscNombreSubRubro2.BindearPropiedadControl = Nothing
        Me.bscNombreSubRubro2.BindearPropiedadEntidad = Nothing
        Me.bscNombreSubRubro2.ConfigBuscador = Nothing
        Me.bscNombreSubRubro2.Datos = Nothing
        Me.bscNombreSubRubro2.FilaDevuelta = Nothing
        Me.bscNombreSubRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreSubRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreSubRubro2.IsDecimal = False
        Me.bscNombreSubRubro2.IsNumber = False
        Me.bscNombreSubRubro2.IsPK = False
        Me.bscNombreSubRubro2.IsRequired = False
        Me.bscNombreSubRubro2.Key = ""
        Me.bscNombreSubRubro2.LabelAsoc = Nothing
        Me.bscNombreSubRubro2.Location = New System.Drawing.Point(179, 35)
        Me.bscNombreSubRubro2.MaxLengh = "32767"
        Me.bscNombreSubRubro2.Name = "bscNombreSubRubro2"
        Me.bscNombreSubRubro2.Permitido = True
        Me.bscNombreSubRubro2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreSubRubro2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreSubRubro2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreSubRubro2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreSubRubro2.Selecciono = False
        Me.bscNombreSubRubro2.Size = New System.Drawing.Size(237, 20)
        Me.bscNombreSubRubro2.TabIndex = 16
        '
        'bscNombreRubro2
        '
        Me.bscNombreRubro2.ActivarFiltroEnGrilla = True
        Me.bscNombreRubro2.BindearPropiedadControl = Nothing
        Me.bscNombreRubro2.BindearPropiedadEntidad = Nothing
        Me.bscNombreRubro2.ConfigBuscador = Nothing
        Me.bscNombreRubro2.Datos = Nothing
        Me.bscNombreRubro2.FilaDevuelta = Nothing
        Me.bscNombreRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreRubro2.IsDecimal = False
        Me.bscNombreRubro2.IsNumber = False
        Me.bscNombreRubro2.IsPK = False
        Me.bscNombreRubro2.IsRequired = False
        Me.bscNombreRubro2.Key = ""
        Me.bscNombreRubro2.LabelAsoc = Nothing
        Me.bscNombreRubro2.Location = New System.Drawing.Point(179, 6)
        Me.bscNombreRubro2.MaxLengh = "32767"
        Me.bscNombreRubro2.Name = "bscNombreRubro2"
        Me.bscNombreRubro2.Permitido = True
        Me.bscNombreRubro2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreRubro2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreRubro2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreRubro2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreRubro2.Selecciono = False
        Me.bscNombreRubro2.Size = New System.Drawing.Size(222, 20)
        Me.bscNombreRubro2.TabIndex = 13
        '
        'bscCodigoRubro2
        '
        Me.bscCodigoRubro2.ActivarFiltroEnGrilla = True
        Me.bscCodigoRubro2.BindearPropiedadControl = "Text"
        Me.bscCodigoRubro2.BindearPropiedadEntidad = "IdRubro"
        Me.bscCodigoRubro2.ConfigBuscador = Nothing
        Me.bscCodigoRubro2.Datos = Nothing
        Me.bscCodigoRubro2.FilaDevuelta = Nothing
        Me.bscCodigoRubro2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoRubro2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoRubro2.IsDecimal = False
        Me.bscCodigoRubro2.IsNumber = True
        Me.bscCodigoRubro2.IsPK = False
        Me.bscCodigoRubro2.IsRequired = False
        Me.bscCodigoRubro2.Key = ""
        Me.bscCodigoRubro2.LabelAsoc = Nothing
        Me.bscCodigoRubro2.Location = New System.Drawing.Point(80, 6)
        Me.bscCodigoRubro2.MaxLengh = "32767"
        Me.bscCodigoRubro2.Name = "bscCodigoRubro2"
        Me.bscCodigoRubro2.Permitido = True
        Me.bscCodigoRubro2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoRubro2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoRubro2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoRubro2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoRubro2.Selecciono = False
        Me.bscCodigoRubro2.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoRubro2.TabIndex = 12
        '
        'btnRefrescarSubSubRubro
        '
        Me.btnRefrescarSubSubRubro.Image = CType(resources.GetObject("btnRefrescarSubSubRubro.Image"), System.Drawing.Image)
        Me.btnRefrescarSubSubRubro.Location = New System.Drawing.Point(11, 8)
        Me.btnRefrescarSubSubRubro.Name = "btnRefrescarSubSubRubro"
        Me.btnRefrescarSubSubRubro.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarSubSubRubro.TabIndex = 10
        Me.btnRefrescarSubSubRubro.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.LabelAsoc = Nothing
        Me.Label5.Location = New System.Drawing.Point(4, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "SubSubRubro"
        '
        'tbpObjetivos
        '
        Me.tbpObjetivos.BackColor = System.Drawing.SystemColors.Control
        Me.tbpObjetivos.Controls.Add(Me.GroupBox2)
        Me.tbpObjetivos.Location = New System.Drawing.Point(4, 22)
        Me.tbpObjetivos.Name = "tbpObjetivos"
        Me.tbpObjetivos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpObjetivos.Size = New System.Drawing.Size(559, 293)
        Me.tbpObjetivos.TabIndex = 3
        Me.tbpObjetivos.Text = "Objetivos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ugObjetivos)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtImporteObjetivos)
        Me.GroupBox2.Controls.Add(Me.dtpPeriodoFiscal)
        Me.GroupBox2.Controls.Add(Me.lblPeriodoFiscal)
        Me.GroupBox2.Controls.Add(Me.btnRefrescarObj)
        Me.GroupBox2.Controls.Add(Me.btnInsertar)
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Location = New System.Drawing.Point(49, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(457, 232)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'ugObjetivos
        '
        Me.ugObjetivos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugObjetivos.DisplayLayout.Appearance = Appearance1
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Hidden = True
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn4.Hidden = True
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn9.Header.Appearance = Appearance2
        UltraGridColumn9.Header.Caption = "Periodo Fiscal"
        UltraGridColumn9.Header.VisiblePosition = 2
        UltraGridColumn9.Width = 88
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn10.CellAppearance = Appearance3
        UltraGridColumn10.Format = "N2"
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn10.Header.Appearance = Appearance4
        UltraGridColumn10.Header.Caption = "Importe Objetivo"
        UltraGridColumn10.Header.VisiblePosition = 3
        UltraGridColumn10.Width = 119
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn2, UltraGridColumn4, UltraGridColumn9, UltraGridColumn10})
        Me.ugObjetivos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugObjetivos.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugObjetivos.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.ugObjetivos.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugObjetivos.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.ugObjetivos.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugObjetivos.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.ugObjetivos.DisplayLayout.MaxColScrollRegions = 1
        Me.ugObjetivos.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugObjetivos.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugObjetivos.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.ugObjetivos.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugObjetivos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugObjetivos.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugObjetivos.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugObjetivos.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.ugObjetivos.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugObjetivos.DisplayLayout.Override.CellAppearance = Appearance11
        Me.ugObjetivos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugObjetivos.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.ugObjetivos.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.ugObjetivos.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.ugObjetivos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugObjetivos.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.ugObjetivos.DisplayLayout.Override.RowAppearance = Appearance14
        Me.ugObjetivos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugObjetivos.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.ugObjetivos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugObjetivos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugObjetivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugObjetivos.Location = New System.Drawing.Point(51, 45)
        Me.ugObjetivos.Name = "ugObjetivos"
        Me.ugObjetivos.Size = New System.Drawing.Size(317, 171)
        Me.ugObjetivos.TabIndex = 7
        Me.ugObjetivos.TabStop = False
        Me.ugObjetivos.Text = "Listas de precios a exportar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(244, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Importe"
        '
        'txtImporteObjetivos
        '
        Me.txtImporteObjetivos.BindearPropiedadControl = ""
        Me.txtImporteObjetivos.BindearPropiedadEntidad = ""
        Me.txtImporteObjetivos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporteObjetivos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporteObjetivos.Formato = "#,##0.00"
        Me.txtImporteObjetivos.IsDecimal = True
        Me.txtImporteObjetivos.IsNumber = True
        Me.txtImporteObjetivos.IsPK = False
        Me.txtImporteObjetivos.IsRequired = False
        Me.txtImporteObjetivos.Key = ""
        Me.txtImporteObjetivos.LabelAsoc = Me.Label2
        Me.txtImporteObjetivos.Location = New System.Drawing.Point(292, 18)
        Me.txtImporteObjetivos.MaxLength = 12
        Me.txtImporteObjetivos.Name = "txtImporteObjetivos"
        Me.txtImporteObjetivos.Size = New System.Drawing.Size(76, 20)
        Me.txtImporteObjetivos.TabIndex = 4
        Me.txtImporteObjetivos.Text = "0.00"
        Me.txtImporteObjetivos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpPeriodoFiscal
        '
        Me.dtpPeriodoFiscal.BindearPropiedadControl = Nothing
        Me.dtpPeriodoFiscal.BindearPropiedadEntidad = Nothing
        Me.dtpPeriodoFiscal.CustomFormat = "MM/yyyy"
        Me.dtpPeriodoFiscal.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpPeriodoFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpPeriodoFiscal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoFiscal.IsPK = False
        Me.dtpPeriodoFiscal.IsRequired = False
        Me.dtpPeriodoFiscal.Key = ""
        Me.dtpPeriodoFiscal.LabelAsoc = Me.lblPeriodoFiscal
        Me.dtpPeriodoFiscal.Location = New System.Drawing.Point(158, 19)
        Me.dtpPeriodoFiscal.Name = "dtpPeriodoFiscal"
        Me.dtpPeriodoFiscal.Size = New System.Drawing.Size(80, 20)
        Me.dtpPeriodoFiscal.TabIndex = 2
        '
        'lblPeriodoFiscal
        '
        Me.lblPeriodoFiscal.AutoSize = True
        Me.lblPeriodoFiscal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriodoFiscal.LabelAsoc = Nothing
        Me.lblPeriodoFiscal.Location = New System.Drawing.Point(79, 22)
        Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
        Me.lblPeriodoFiscal.Size = New System.Drawing.Size(73, 13)
        Me.lblPeriodoFiscal.TabIndex = 1
        Me.lblPeriodoFiscal.Text = "Periodo Fiscal"
        '
        'btnRefrescarObj
        '
        Me.btnRefrescarObj.Image = CType(resources.GetObject("btnRefrescarObj.Image"), System.Drawing.Image)
        Me.btnRefrescarObj.Location = New System.Drawing.Point(51, 17)
        Me.btnRefrescarObj.Name = "btnRefrescarObj"
        Me.btnRefrescarObj.Size = New System.Drawing.Size(22, 22)
        Me.btnRefrescarObj.TabIndex = 0
        Me.btnRefrescarObj.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Image = Global.Eniac.Win.My.Resources.Resources.add_32
        Me.btnInsertar.Location = New System.Drawing.Point(374, 45)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 5
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(374, 88)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 6
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'tbpCobrador
        '
        Me.tbpCobrador.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCobrador.Controls.Add(Me.cmbEntidadCobranza)
        Me.tbpCobrador.Controls.Add(Me.lblEntidadCobranza)
        Me.tbpCobrador.Controls.Add(Me.cmbTarTarjeta)
        Me.tbpCobrador.Controls.Add(Me.chbDebitoTarjeta)
        Me.tbpCobrador.Controls.Add(Me.lblObservacion)
        Me.tbpCobrador.Controls.Add(Me.txtObservacion)
        Me.tbpCobrador.Controls.Add(Me.lblCaja)
        Me.tbpCobrador.Controls.Add(Me.lblBanco)
        Me.tbpCobrador.Controls.Add(Me.cmbCaja)
        Me.tbpCobrador.Controls.Add(Me.chbCaja)
        Me.tbpCobrador.Controls.Add(Me.cmbBanco)
        Me.tbpCobrador.Controls.Add(Me.chbDebitoDirecto)
        Me.tbpCobrador.Controls.Add(Me.lblIdDispositivo)
        Me.tbpCobrador.Controls.Add(Me.txtIdDispositivo)
        Me.tbpCobrador.Location = New System.Drawing.Point(4, 22)
        Me.tbpCobrador.Name = "tbpCobrador"
        Me.tbpCobrador.Size = New System.Drawing.Size(559, 293)
        Me.tbpCobrador.TabIndex = 4
        Me.tbpCobrador.Text = "Cobrador"
        '
        'cmbEntidadCobranza
        '
        Me.cmbEntidadCobranza.BindearPropiedadControl = ""
        Me.cmbEntidadCobranza.BindearPropiedadEntidad = ""
        Me.cmbEntidadCobranza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntidadCobranza.Enabled = False
        Me.cmbEntidadCobranza.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEntidadCobranza.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEntidadCobranza.FormattingEnabled = True
        Me.cmbEntidadCobranza.IsPK = False
        Me.cmbEntidadCobranza.IsRequired = False
        Me.cmbEntidadCobranza.Key = Nothing
        Me.cmbEntidadCobranza.LabelAsoc = Me.lblEntidadCobranza
        Me.cmbEntidadCobranza.Location = New System.Drawing.Point(119, 196)
        Me.cmbEntidadCobranza.Name = "cmbEntidadCobranza"
        Me.cmbEntidadCobranza.Size = New System.Drawing.Size(149, 21)
        Me.cmbEntidadCobranza.TabIndex = 13
        '
        'lblEntidadCobranza
        '
        Me.lblEntidadCobranza.AutoSize = True
        Me.lblEntidadCobranza.LabelAsoc = Nothing
        Me.lblEntidadCobranza.Location = New System.Drawing.Point(13, 200)
        Me.lblEntidadCobranza.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEntidadCobranza.Name = "lblEntidadCobranza"
        Me.lblEntidadCobranza.Size = New System.Drawing.Size(106, 13)
        Me.lblEntidadCobranza.TabIndex = 12
        Me.lblEntidadCobranza.Text = "Entidad de Cobranza"
        '
        'cmbTarTarjeta
        '
        Me.cmbTarTarjeta.BindearPropiedadControl = "SelectedValue"
        Me.cmbTarTarjeta.BindearPropiedadEntidad = "IdTarjeta"
        Me.cmbTarTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTarTarjeta.Enabled = False
        Me.cmbTarTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTarTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTarTarjeta.FormattingEnabled = True
        Me.cmbTarTarjeta.IsPK = False
        Me.cmbTarTarjeta.IsRequired = False
        Me.cmbTarTarjeta.Key = Nothing
        Me.cmbTarTarjeta.LabelAsoc = Nothing
        Me.cmbTarTarjeta.Location = New System.Drawing.Point(215, 58)
        Me.cmbTarTarjeta.Name = "cmbTarTarjeta"
        Me.cmbTarTarjeta.Size = New System.Drawing.Size(149, 21)
        Me.cmbTarTarjeta.TabIndex = 11
        '
        'chbDebitoTarjeta
        '
        Me.chbDebitoTarjeta.AutoSize = True
        Me.chbDebitoTarjeta.BindearPropiedadControl = "Checked"
        Me.chbDebitoTarjeta.BindearPropiedadEntidad = "DebitoTarjeta"
        Me.chbDebitoTarjeta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDebitoTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDebitoTarjeta.IsPK = False
        Me.chbDebitoTarjeta.IsRequired = False
        Me.chbDebitoTarjeta.Key = Nothing
        Me.chbDebitoTarjeta.LabelAsoc = Nothing
        Me.chbDebitoTarjeta.Location = New System.Drawing.Point(13, 60)
        Me.chbDebitoTarjeta.Margin = New System.Windows.Forms.Padding(4)
        Me.chbDebitoTarjeta.Name = "chbDebitoTarjeta"
        Me.chbDebitoTarjeta.Size = New System.Drawing.Size(93, 17)
        Me.chbDebitoTarjeta.TabIndex = 10
        Me.chbDebitoTarjeta.Text = "Débito Tarjeta"
        Me.chbDebitoTarjeta.UseVisualStyleBackColor = True
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(13, 165)
        Me.lblObservacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(78, 13)
        Me.lblObservacion.TabIndex = 8
        Me.lblObservacion.Text = "Observaciones"
        '
        'txtObservacion
        '
        Me.txtObservacion.BindearPropiedadControl = "Text"
        Me.txtObservacion.BindearPropiedadEntidad = "EmpleadoSucursal.Observacion"
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = ""
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = ""
        Me.txtObservacion.LabelAsoc = Me.lblObservacion
        Me.txtObservacion.Location = New System.Drawing.Point(119, 161)
        Me.txtObservacion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(395, 20)
        Me.txtObservacion.TabIndex = 9
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(39, 133)
        Me.lblCaja.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 6
        Me.lblCaja.Text = "Caja"
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.LabelAsoc = Nothing
        Me.lblBanco.Location = New System.Drawing.Point(159, 35)
        Me.lblBanco.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(38, 13)
        Me.lblBanco.TabIndex = 1
        Me.lblBanco.Text = "Banco"
        '
        'cmbCaja
        '
        Me.cmbCaja.BindearPropiedadControl = "SelectedValue"
        Me.cmbCaja.BindearPropiedadEntidad = "EmpleadoSucursal.IdCaja"
        Me.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaja.Enabled = False
        Me.cmbCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.IsPK = False
        Me.cmbCaja.IsRequired = False
        Me.cmbCaja.Key = Nothing
        Me.cmbCaja.LabelAsoc = Me.lblCaja
        Me.cmbCaja.Location = New System.Drawing.Point(119, 129)
        Me.cmbCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(208, 21)
        Me.cmbCaja.TabIndex = 7
        '
        'chbCaja
        '
        Me.chbCaja.AutoSize = True
        Me.chbCaja.BindearPropiedadControl = ""
        Me.chbCaja.BindearPropiedadEntidad = ""
        Me.chbCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCaja.IsPK = False
        Me.chbCaja.IsRequired = False
        Me.chbCaja.Key = Nothing
        Me.chbCaja.LabelAsoc = Nothing
        Me.chbCaja.Location = New System.Drawing.Point(13, 132)
        Me.chbCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.chbCaja.Name = "chbCaja"
        Me.chbCaja.Size = New System.Drawing.Size(15, 14)
        Me.chbCaja.TabIndex = 5
        Me.chbCaja.UseVisualStyleBackColor = True
        '
        'cmbBanco
        '
        Me.cmbBanco.BindearPropiedadControl = "SelectedValue"
        Me.cmbBanco.BindearPropiedadEntidad = "idBanco"
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.Enabled = False
        Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.IsPK = False
        Me.cmbBanco.IsRequired = False
        Me.cmbBanco.Key = Nothing
        Me.cmbBanco.LabelAsoc = Me.lblBanco
        Me.cmbBanco.Location = New System.Drawing.Point(215, 31)
        Me.cmbBanco.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(299, 21)
        Me.cmbBanco.TabIndex = 2
        '
        'chbDebitoDirecto
        '
        Me.chbDebitoDirecto.AutoSize = True
        Me.chbDebitoDirecto.BindearPropiedadControl = "Checked"
        Me.chbDebitoDirecto.BindearPropiedadEntidad = "DebitoDirecto"
        Me.chbDebitoDirecto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDebitoDirecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDebitoDirecto.IsPK = False
        Me.chbDebitoDirecto.IsRequired = False
        Me.chbDebitoDirecto.Key = Nothing
        Me.chbDebitoDirecto.LabelAsoc = Nothing
        Me.chbDebitoDirecto.Location = New System.Drawing.Point(13, 33)
        Me.chbDebitoDirecto.Margin = New System.Windows.Forms.Padding(4)
        Me.chbDebitoDirecto.Name = "chbDebitoDirecto"
        Me.chbDebitoDirecto.Size = New System.Drawing.Size(94, 17)
        Me.chbDebitoDirecto.TabIndex = 0
        Me.chbDebitoDirecto.Text = "Débito Directo"
        Me.chbDebitoDirecto.UseVisualStyleBackColor = True
        '
        'lblIdDispositivo
        '
        Me.lblIdDispositivo.AutoSize = True
        Me.lblIdDispositivo.LabelAsoc = Nothing
        Me.lblIdDispositivo.Location = New System.Drawing.Point(13, 100)
        Me.lblIdDispositivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblIdDispositivo.Name = "lblIdDispositivo"
        Me.lblIdDispositivo.Size = New System.Drawing.Size(70, 13)
        Me.lblIdDispositivo.TabIndex = 3
        Me.lblIdDispositivo.Text = "Id Dispositivo"
        '
        'txtIdDispositivo
        '
        Me.txtIdDispositivo.BindearPropiedadControl = "Text"
        Me.txtIdDispositivo.BindearPropiedadEntidad = "IdDispositivo"
        Me.txtIdDispositivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdDispositivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdDispositivo.Formato = ""
        Me.txtIdDispositivo.IsDecimal = False
        Me.txtIdDispositivo.IsNumber = False
        Me.txtIdDispositivo.IsPK = False
        Me.txtIdDispositivo.IsRequired = False
        Me.txtIdDispositivo.Key = ""
        Me.txtIdDispositivo.LabelAsoc = Me.lblIdDispositivo
        Me.txtIdDispositivo.Location = New System.Drawing.Point(119, 96)
        Me.txtIdDispositivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIdDispositivo.MaxLength = 50
        Me.txtIdDispositivo.Name = "txtIdDispositivo"
        Me.txtIdDispositivo.Size = New System.Drawing.Size(395, 20)
        Me.txtIdDispositivo.TabIndex = 4
        '
        'tbpChofer
        '
        Me.tbpChofer.BackColor = System.Drawing.SystemColors.Control
        Me.tbpChofer.Controls.Add(Me.bscCodigoTransportista)
        Me.tbpChofer.Controls.Add(Me.bscTransportista)
        Me.tbpChofer.Controls.Add(Me.lblTransportista)
        Me.tbpChofer.Location = New System.Drawing.Point(4, 22)
        Me.tbpChofer.Name = "tbpChofer"
        Me.tbpChofer.Size = New System.Drawing.Size(559, 293)
        Me.tbpChofer.TabIndex = 5
        Me.tbpChofer.Text = "Chofer"
        '
        'bscCodigoTransportista
        '
        Me.bscCodigoTransportista.AyudaAncho = 608
        Me.bscCodigoTransportista.BindearPropiedadControl = ""
        Me.bscCodigoTransportista.BindearPropiedadEntidad = ""
        Me.bscCodigoTransportista.ColumnasAlineacion = Nothing
        Me.bscCodigoTransportista.ColumnasAncho = Nothing
        Me.bscCodigoTransportista.ColumnasFormato = Nothing
        Me.bscCodigoTransportista.ColumnasOcultas = Nothing
        Me.bscCodigoTransportista.ColumnasTitulos = Nothing
        Me.bscCodigoTransportista.Datos = Nothing
        Me.bscCodigoTransportista.Enabled = False
        Me.bscCodigoTransportista.FilaDevuelta = Nothing
        Me.bscCodigoTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoTransportista.IsDecimal = False
        Me.bscCodigoTransportista.IsNumber = False
        Me.bscCodigoTransportista.IsPK = False
        Me.bscCodigoTransportista.IsRequired = False
        Me.bscCodigoTransportista.Key = ""
        Me.bscCodigoTransportista.LabelAsoc = Nothing
        Me.bscCodigoTransportista.Location = New System.Drawing.Point(88, 12)
        Me.bscCodigoTransportista.MaxLengh = "32767"
        Me.bscCodigoTransportista.Name = "bscCodigoTransportista"
        Me.bscCodigoTransportista.Permitido = True
        Me.bscCodigoTransportista.Selecciono = False
        Me.bscCodigoTransportista.Size = New System.Drawing.Size(82, 20)
        Me.bscCodigoTransportista.TabIndex = 29
        Me.bscCodigoTransportista.Titulo = Nothing
        '
        'bscTransportista
        '
        Me.bscTransportista.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscTransportista.AyudaAncho = 608
        Me.bscTransportista.BindearPropiedadControl = Nothing
        Me.bscTransportista.BindearPropiedadEntidad = Nothing
        Me.bscTransportista.ColumnasAlineacion = Nothing
        Me.bscTransportista.ColumnasAncho = Nothing
        Me.bscTransportista.ColumnasFormato = Nothing
        Me.bscTransportista.ColumnasOcultas = Nothing
        Me.bscTransportista.ColumnasTitulos = Nothing
        Me.bscTransportista.Datos = Nothing
        Me.bscTransportista.Enabled = False
        Me.bscTransportista.FilaDevuelta = Nothing
        Me.bscTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.bscTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscTransportista.IsDecimal = False
        Me.bscTransportista.IsNumber = False
        Me.bscTransportista.IsPK = False
        Me.bscTransportista.IsRequired = False
        Me.bscTransportista.Key = ""
        Me.bscTransportista.LabelAsoc = Nothing
        Me.bscTransportista.Location = New System.Drawing.Point(176, 12)
        Me.bscTransportista.MaxLengh = "32767"
        Me.bscTransportista.Name = "bscTransportista"
        Me.bscTransportista.Permitido = True
        Me.bscTransportista.Selecciono = False
        Me.bscTransportista.Size = New System.Drawing.Size(326, 20)
        Me.bscTransportista.TabIndex = 30
        Me.bscTransportista.Titulo = Nothing
        '
        'lblTransportista
        '
        Me.lblTransportista.AutoSize = True
        Me.lblTransportista.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTransportista.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTransportista.LabelAsoc = Nothing
        Me.lblTransportista.Location = New System.Drawing.Point(9, 16)
        Me.lblTransportista.Name = "lblTransportista"
        Me.lblTransportista.Size = New System.Drawing.Size(68, 13)
        Me.lblTransportista.TabIndex = 28
        Me.lblTransportista.Text = "Transportista"
        '
        'tbpProduccion
        '
        Me.tbpProduccion.BackColor = System.Drawing.SystemColors.Control
        Me.tbpProduccion.Controls.Add(Me.pnlValorHora)
        Me.tbpProduccion.Location = New System.Drawing.Point(4, 22)
        Me.tbpProduccion.Name = "tbpProduccion"
        Me.tbpProduccion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpProduccion.Size = New System.Drawing.Size(559, 293)
        Me.tbpProduccion.TabIndex = 6
        Me.tbpProduccion.Text = "MRP"
        '
        'pnlValorHora
        '
        Me.pnlValorHora.Controls.Add(Me.chbValorHoraProd)
        Me.pnlValorHora.Controls.Add(Me.txtValorHora)
        Me.pnlValorHora.Enabled = False
        Me.pnlValorHora.Location = New System.Drawing.Point(6, 3)
        Me.pnlValorHora.Name = "pnlValorHora"
        Me.pnlValorHora.Size = New System.Drawing.Size(263, 46)
        Me.pnlValorHora.TabIndex = 21
        '
        'chbValorHoraProd
        '
        Me.chbValorHoraProd.AutoSize = True
        Me.chbValorHoraProd.BindearPropiedadControl = "Checked"
        Me.chbValorHoraProd.BindearPropiedadEntidad = "EsRespProd"
        Me.chbValorHoraProd.ForeColorFocus = System.Drawing.Color.Red
        Me.chbValorHoraProd.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbValorHoraProd.IsPK = False
        Me.chbValorHoraProd.IsRequired = False
        Me.chbValorHoraProd.Key = Nothing
        Me.chbValorHoraProd.LabelAsoc = Nothing
        Me.chbValorHoraProd.Location = New System.Drawing.Point(0, 14)
        Me.chbValorHoraProd.Name = "chbValorHoraProd"
        Me.chbValorHoraProd.Size = New System.Drawing.Size(133, 17)
        Me.chbValorHoraProd.TabIndex = 20
        Me.chbValorHoraProd.Text = "Valor Hora Producción"
        Me.chbValorHoraProd.UseVisualStyleBackColor = True
        '
        'txtValorHora
        '
        Me.txtValorHora.BindearPropiedadControl = "Text"
        Me.txtValorHora.BindearPropiedadEntidad = "ValorHoraProduccion"
        Me.txtValorHora.Enabled = False
        Me.txtValorHora.ForeColorFocus = System.Drawing.Color.Red
        Me.txtValorHora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtValorHora.Formato = ""
        Me.txtValorHora.IsDecimal = True
        Me.txtValorHora.IsNumber = True
        Me.txtValorHora.IsPK = False
        Me.txtValorHora.IsRequired = True
        Me.txtValorHora.Key = ""
        Me.txtValorHora.LabelAsoc = Nothing
        Me.txtValorHora.Location = New System.Drawing.Point(139, 12)
        Me.txtValorHora.MaxLength = 12
        Me.txtValorHora.Name = "txtValorHora"
        Me.txtValorHora.Size = New System.Drawing.Size(105, 20)
        Me.txtValorHora.TabIndex = 9
        Me.txtValorHora.Text = "0"
        Me.txtValorHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grbDatos
        '
        Me.grbDatos.Controls.Add(Me.txtIdEmpleado)
        Me.grbDatos.Controls.Add(Me.lblNombreEmpleado)
        Me.grbDatos.Controls.Add(Me.txtNombreEmpleado)
        Me.grbDatos.Controls.Add(Me.lblIdEmpleado)
        Me.grbDatos.Location = New System.Drawing.Point(8, 8)
        Me.grbDatos.Name = "grbDatos"
        Me.grbDatos.Size = New System.Drawing.Size(580, 73)
        Me.grbDatos.TabIndex = 0
        Me.grbDatos.TabStop = False
        '
        'txtIdEmpleado
        '
        Me.txtIdEmpleado.BindearPropiedadControl = "Text"
        Me.txtIdEmpleado.BindearPropiedadEntidad = "IdEmpleado"
        Me.txtIdEmpleado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdEmpleado.Formato = ""
        Me.txtIdEmpleado.IsDecimal = False
        Me.txtIdEmpleado.IsNumber = True
        Me.txtIdEmpleado.IsPK = True
        Me.txtIdEmpleado.IsRequired = True
        Me.txtIdEmpleado.Key = ""
        Me.txtIdEmpleado.LabelAsoc = Me.lblIdEmpleado
        Me.txtIdEmpleado.Location = New System.Drawing.Point(66, 19)
        Me.txtIdEmpleado.MaxLength = 12
        Me.txtIdEmpleado.Name = "txtIdEmpleado"
        Me.txtIdEmpleado.Size = New System.Drawing.Size(70, 20)
        Me.txtIdEmpleado.TabIndex = 1
        Me.txtIdEmpleado.TabStop = False
        Me.txtIdEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdEmpleado
        '
        Me.lblIdEmpleado.AutoSize = True
        Me.lblIdEmpleado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIdEmpleado.LabelAsoc = Nothing
        Me.lblIdEmpleado.Location = New System.Drawing.Point(16, 22)
        Me.lblIdEmpleado.Name = "lblIdEmpleado"
        Me.lblIdEmpleado.Size = New System.Drawing.Size(40, 13)
        Me.lblIdEmpleado.TabIndex = 0
        Me.lblIdEmpleado.Text = "Código"
        '
        'EmpleadosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(594, 459)
        Me.Controls.Add(Me.tbcEmpleado)
        Me.Controls.Add(Me.grbDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EmpleadosDetalle"
        Me.Text = "Empleado"
        Me.Controls.SetChildIndex(Me.grbDatos, 0)
        Me.Controls.SetChildIndex(Me.tbcEmpleado, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tcbZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcEmpleado.ResumeLayout(False)
        Me.tbpDatos.ResumeLayout(False)
        Me.tbpDatos.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.tbpMapa.ResumeLayout(False)
        Me.tbpMapa.PerformLayout()
        Me.tbpComisiones.ResumeLayout(False)
        Me.tbpComisiones.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.tbProducto.ResumeLayout(False)
        Me.tbProducto.PerformLayout()
        CType(Me.dgvComisionesProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMarca.ResumeLayout(False)
        Me.tpMarca.PerformLayout()
        CType(Me.dgvComisionesMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpRubro.ResumeLayout(False)
        Me.tpRubro.PerformLayout()
        CType(Me.dgvComisionesRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpSubRubro.ResumeLayout(False)
        Me.tbpSubRubro.PerformLayout()
        CType(Me.dgvComisionesSubRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpSubSubRubro.ResumeLayout(False)
        Me.tbpSubSubRubro.PerformLayout()
        CType(Me.dgvComisionesSubSubRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpObjetivos.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ugObjetivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpCobrador.ResumeLayout(False)
        Me.tbpCobrador.PerformLayout()
        Me.tbpChofer.ResumeLayout(False)
        Me.tbpChofer.PerformLayout()
        Me.tbpProduccion.ResumeLayout(False)
        Me.pnlValorHora.ResumeLayout(False)
        Me.pnlValorHora.PerformLayout()
        Me.grbDatos.ResumeLayout(False)
        Me.grbDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTipoDocEmpleado As Eniac.Controles.Label
   Friend WithEvents lblNroDocEmpleado As Eniac.Controles.Label
   Friend WithEvents txtNombreEmpleado As Eniac.Controles.TextBox
   Friend WithEvents lblNombreEmpleado As Eniac.Controles.Label
   Friend WithEvents txtTelefonoEmpleado As Eniac.Controles.TextBox
   Friend WithEvents lblTelefonoEmpleado As Eniac.Controles.Label
   Friend WithEvents txtCelularEmpleado As Eniac.Controles.TextBox
   Friend WithEvents lblCelularEmpleado As Eniac.Controles.Label
   Friend WithEvents chbEsComprador As Eniac.Controles.CheckBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents txtComisionPorVenta As Eniac.Controles.TextBox
   Friend WithEvents lblComisionPorVenta As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents lnkLocalidad As Eniac.Controles.LinkLabel
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents gmcMapa As GMap.NET.WindowsForms.GMapControl
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents lblGeoLocalizacionLat As Eniac.Controles.Label
   Friend WithEvents lblGeoLocalizacionLng As Eniac.Controles.Label
   Friend WithEvents txtGeoLocalizacionLat As Eniac.Controles.TextBox
   Friend WithEvents txtGeoLocalizacionLng As Eniac.Controles.TextBox
   Friend WithEvents tcbZoom As System.Windows.Forms.TrackBar
   Friend WithEvents cmbTipoMapa As System.Windows.Forms.ComboBox
   Friend WithEvents btnGeolocalizar As System.Windows.Forms.Button
   Friend WithEvents tbcEmpleado As System.Windows.Forms.TabControl
   Friend WithEvents tbpMapa As System.Windows.Forms.TabPage
   Friend WithEvents tbpComisiones As System.Windows.Forms.TabPage
   Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
   Friend WithEvents tpMarca As System.Windows.Forms.TabPage
   Friend WithEvents tpRubro As System.Windows.Forms.TabPage
   Friend WithEvents tbProducto As System.Windows.Forms.TabPage
   Friend WithEvents btnRefrescarMarcas As System.Windows.Forms.Button
   Friend WithEvents lblComisionMarcas As Eniac.Controles.Label
   Friend WithEvents btnEliminarMarca As Eniac.Controles.Button
   Friend WithEvents txtComisionMarcas As Eniac.Controles.TextBox
   Friend WithEvents dgvComisionesMarcas As Eniac.Controles.DataGridView
   Friend WithEvents btnInsertarMarca As Eniac.Controles.Button
   Friend WithEvents cmbMarcas As Eniac.Controles.ComboBox
   Friend WithEvents btnRefrescarRubros As System.Windows.Forms.Button
   Friend WithEvents btnEliminarRubros As Eniac.Controles.Button
   Friend WithEvents btnInsertarRubros As Eniac.Controles.Button
   Friend WithEvents lblComisionRubro As Eniac.Controles.Label
   Friend WithEvents txtComisionRubro As Eniac.Controles.TextBox
   Friend WithEvents dgvComisionesRubros As Eniac.Controles.DataGridView
   Friend WithEvents cmbRubros As Eniac.Controles.ComboBox
   Friend WithEvents btnRefrescarProductos As System.Windows.Forms.Button
   Friend WithEvents btnEliminarProductos As Eniac.Controles.Button
   Friend WithEvents btnInsertarProductos As Eniac.Controles.Button
   Friend WithEvents lblComisionProducto As Eniac.Controles.Label
   Friend WithEvents txtComisionProducto As Eniac.Controles.TextBox
   Friend WithEvents dgvComisionesProductos As Eniac.Controles.DataGridView
   Friend WithEvents bscCodigoProducto As Eniac.Controles.Buscador2
   Friend WithEvents bscProducto As Eniac.Controles.Buscador2
   Friend WithEvents grbDatos As System.Windows.Forms.GroupBox
   Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
   Friend WithEvents txtIdEmpleado As Eniac.Controles.TextBox
   Friend WithEvents lblIdEmpleado As Eniac.Controles.Label
   Friend WithEvents chbColor As Eniac.Controles.CheckBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Protected WithEvents cmbTipoDocEmpleado As Eniac.Controles.ComboBox
   Protected WithEvents txtNroDocEmpleado As Eniac.Controles.TextBox
   Protected WithEvents chbEsVendedor As Eniac.Controles.CheckBox
   Protected WithEvents txtNivelAutorizacion As Eniac.Controles.TextBox
   Friend WithEvents lblNivelAutorizacion As Eniac.Controles.Label
   Protected WithEvents txtClave As Eniac.Controles.TextBox
   Friend WithEvents lblClave As Eniac.Controles.Label
   Friend WithEvents tbpObjetivos As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents btnRefrescarObj As System.Windows.Forms.Button
   Friend WithEvents btnInsertar As Eniac.Controles.Button
   Friend WithEvents btnEliminar As Eniac.Controles.Button
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtImporteObjetivos As Eniac.Controles.TextBox
   Friend WithEvents dtpPeriodoFiscal As Eniac.Controles.DateTimePicker
   Friend WithEvents ugObjetivos As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbEsCobrador As Eniac.Controles.CheckBox
   Friend WithEvents tbpCobrador As System.Windows.Forms.TabPage
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents lblBanco As Eniac.Controles.Label
   Friend WithEvents cmbCaja As Eniac.Controles.ComboBox
   Friend WithEvents chbCaja As Eniac.Controles.CheckBox
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents chbDebitoDirecto As Eniac.Controles.CheckBox
   Friend WithEvents lblIdDispositivo As Eniac.Controles.Label
   Friend WithEvents txtIdDispositivo As Eniac.Controles.TextBox
   Friend WithEvents IdMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdEmpleado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Marca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Comision As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdEmpleado1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Rubros As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ComisionR As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdEmpleado2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Productos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ComisionP As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents chbUsuarioMovil As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuarioMovil As Eniac.Controles.ComboBox
   Friend WithEvents chbDebitoTarjeta As Controles.CheckBox
   Friend WithEvents cmbTarTarjeta As Controles.ComboBox
   Friend WithEvents chbEsTransportista As Controles.CheckBox
   Friend WithEvents tbpChofer As TabPage
   Friend WithEvents bscCodigoTransportista As Controles.Buscador
   Friend WithEvents bscTransportista As Controles.Buscador
   Friend WithEvents lblTransportista As Controles.Label
   Friend WithEvents chbResponsableProd As Controles.CheckBox
   Friend WithEvents tbpSubRubro As TabPage
   Friend WithEvents tbpSubSubRubro As TabPage
   Friend WithEvents lblSubRubro As Controles.Label
   Friend WithEvents lblRubro As Controles.Label
   Friend WithEvents bscCodigoSubRubro1 As Controles.Buscador2
   Friend WithEvents bscNombreSubRubro1 As Controles.Buscador2
   Friend WithEvents bscNombreRubro1 As Controles.Buscador2
   Friend WithEvents bscCodigoRubro1 As Controles.Buscador2
   Friend WithEvents btnRefrescarSubRubros As Button
   Friend WithEvents dgvComisionesSubRubros As Controles.DataGridView
   Friend WithEvents btnEliminarSubRubros As Controles.Button
   Friend WithEvents btnInsertarSubRubros As Controles.Button
   Friend WithEvents txtDescuentoSubRubros As Controles.TextBox
   Friend WithEvents lblDescuentoSubRubros As Controles.Label
   Friend WithEvents bscCodigoSubSubRubro2 As Controles.Buscador2
   Friend WithEvents bscNombreSubSubRubro2 As Controles.Buscador2
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents Label4 As Controles.Label
   Friend WithEvents bscCodigoSubRubro2 As Controles.Buscador2
   Friend WithEvents bscNombreSubRubro2 As Controles.Buscador2
   Friend WithEvents bscNombreRubro2 As Controles.Buscador2
   Friend WithEvents bscCodigoRubro2 As Controles.Buscador2
   Friend WithEvents btnRefrescarSubSubRubro As Button
   Friend WithEvents Label5 As Controles.Label
   Friend WithEvents lblDescuentoSubSubRubro As Controles.Label
   Friend WithEvents txtDescuentoSubSubRubro As Controles.TextBox
   Friend WithEvents dgvComisionesSubSubRubros As Controles.DataGridView
   Friend WithEvents btnEliminarSubSubRubro As Controles.Button
   Friend WithEvents btnInsertarSubSubRubro As Controles.Button
   Friend WithEvents IdEmpleadoTwo As DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
   Friend WithEvents NombreRubro As DataGridViewTextBoxColumn
   Friend WithEvents IdSubRubro As DataGridViewTextBoxColumn
   Friend WithEvents NombreSubRubro As DataGridViewTextBoxColumn
   Friend WithEvents ComisionSubRubro As DataGridViewTextBoxColumn
   Friend WithEvents IdCategoriaTres As DataGridViewTextBoxColumn
   Friend WithEvents IdRubroTwo As DataGridViewTextBoxColumn
   Friend WithEvents NombreRubroTwo As DataGridViewTextBoxColumn
   Friend WithEvents IdSubRubroTwo As DataGridViewTextBoxColumn
   Friend WithEvents NombreSubRubroTwo As DataGridViewTextBoxColumn
   Friend WithEvents IdSubSubRubro As DataGridViewTextBoxColumn
   Friend WithEvents NombreSubSubRubro As DataGridViewTextBoxColumn
   Friend WithEvents ComisionSubSubRubro As DataGridViewTextBoxColumn
   Friend WithEvents tbpProduccion As TabPage
   Friend WithEvents txtValorHora As Controles.TextBox
   Friend WithEvents cmbCategoriaEmpleado As Controles.ComboBox
   Friend WithEvents lblCategoriaEmpleado As Controles.Label
   Friend WithEvents chbValorHoraProd As Controles.CheckBox
   Friend WithEvents pnlValorHora As Panel
   Friend WithEvents txtValorHoraCatego As Controles.TextBox
   Friend WithEvents lblValorHoraCatego As Controles.Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckBox1 As Controles.CheckBox
    Friend WithEvents cmbEntidadCobranza As Controles.ComboBox
    Friend WithEvents lblEntidadCobranza As Controles.Label
End Class
