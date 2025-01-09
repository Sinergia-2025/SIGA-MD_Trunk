<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContactosDetalle
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
   '<System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContactosDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.grbCliente = New System.Windows.Forms.GroupBox()
      Me.txtCodigoContacto = New Eniac.Controles.TextBox()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.ofdArchivos = New System.Windows.Forms.OpenFileDialog()
      Me.tlpInfo = New System.Windows.Forms.ToolTip(Me.components)
      Me.txtCUIT = New Eniac.Controles.TextBox()
      Me.lblCUIT = New Eniac.Controles.Label()
      Me.tbpFoto = New System.Windows.Forms.TabPage()
      Me.pcbFoto = New System.Windows.Forms.PictureBox()
      Me.btnLimpiarImagen = New Eniac.Controles.Button()
      Me.btnBuscarImagen = New Eniac.Controles.Button()
      Me.tbpOtros = New System.Windows.Forms.TabPage()
      Me.grbOtros = New System.Windows.Forms.GroupBox()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.tbpMapa = New System.Windows.Forms.TabPage()
      Me.grbUbicacion = New System.Windows.Forms.GroupBox()
      Me.lblGeoLocalizacionLat = New Eniac.Controles.Label()
      Me.lblGeoLocalizacionLng = New Eniac.Controles.Label()
      Me.txtGeoLocalizacionLat = New Eniac.Controles.TextBox()
      Me.txtGeoLocalizacionLng = New Eniac.Controles.TextBox()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.gmcMapa = New GMap.NET.WindowsForms.GMapControl()
      Me.tcbZoom = New System.Windows.Forms.TrackBar()
      Me.cmbTipoMapa = New System.Windows.Forms.ComboBox()
      Me.btnGeolocalizar = New System.Windows.Forms.Button()
      Me.tbpDirecciones = New System.Windows.Forms.TabPage()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.Label5 = New Eniac.Controles.Label()
      Me.txtTelefonoDir = New Eniac.Controles.TextBox()
      Me.lblTelefonos = New Eniac.Controles.Label()
      Me.txtCorreoDir = New Eniac.Controles.TextBox()
      Me.lblCorreoElectronico = New Eniac.Controles.Label()
      Me.txtCelularDir = New Eniac.Controles.TextBox()
      Me.lblCelular = New Eniac.Controles.Label()
      Me.cmbTiposDirecciones = New Eniac.Controles.ComboBox()
      Me.lblZonaGeografica = New Eniac.Controles.Label()
      Me.Label6 = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.lnkLocalidadDir = New Eniac.Controles.LinkLabel()
      Me.bscCodigoLocalidadDir = New Eniac.Controles.Buscador()
      Me.bscNombreLocalidadDir = New Eniac.Controles.Buscador()
      Me.txtProvinciaLocalidadDir = New Eniac.Controles.TextBox()
      Me.txtDirecciones = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.btnRefreshDir = New Eniac.Controles.Button()
      Me.dgvDirecciones = New Eniac.Controles.DataGridView()
      Me.IdContacto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreAbrevTipoDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoDireccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Celular = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CorreoElectronico = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.btnInsertarDir = New Eniac.Controles.Button()
      Me.btnEliminarDir = New Eniac.Controles.Button()
      Me.tbpDatos = New System.Windows.Forms.TabPage()
      Me.grbDatosPersonales = New System.Windows.Forms.GroupBox()
      Me.chbPrivado = New Eniac.Controles.CheckBox()
      Me.cmbTipoContacto = New Eniac.Controles.ComboBox()
      Me.Label7 = New Eniac.Controles.Label()
      Me.lblProvinciaLocalidad = New Eniac.Controles.Label()
      Me.lnkLocalidad = New Eniac.Controles.LinkLabel()
      Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
      Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
      Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
      Me.txtProvinciaLocalidad = New Eniac.Controles.TextBox()
      Me.txtDireccion = New Eniac.Controles.TextBox()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.cmbTipoDoc = New Eniac.Controles.ComboBox()
      Me.lblTipoDocumento = New Eniac.Controles.Label()
      Me.lblID = New Eniac.Controles.Label()
      Me.txtNroDoc = New Eniac.Controles.TextBox()
      Me.txtTelefonos = New Eniac.Controles.TextBox()
      Me.txtPaginaWeb = New Eniac.Controles.TextBox()
      Me.lblPaginaWeb = New Eniac.Controles.Label()
      Me.txtCorreoElectronico = New Eniac.Controles.TextBox()
      Me.txtCelular = New Eniac.Controles.TextBox()
      Me.dtpFechaAlta = New Eniac.Controles.DateTimePicker()
      Me.lblFechaAlta = New Eniac.Controles.Label()
      Me.cmbCategoriaFiscal = New Eniac.Controles.ComboBox()
      Me.lblCategoriaFiscal = New Eniac.Controles.Label()
      Me.dtpFechaNacimiento = New Eniac.Controles.DateTimePicker()
      Me.lblFechaNac = New Eniac.Controles.Label()
      Me.tbcContacto = New System.Windows.Forms.TabControl()
      Me.grbCliente.SuspendLayout()
      Me.tbpFoto.SuspendLayout()
      CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpOtros.SuspendLayout()
      Me.grbOtros.SuspendLayout()
      Me.tbpMapa.SuspendLayout()
      Me.grbUbicacion.SuspendLayout()
      Me.Panel1.SuspendLayout()
      CType(Me.tcbZoom, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpDirecciones.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      CType(Me.dgvDirecciones, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpDatos.SuspendLayout()
      Me.grbDatosPersonales.SuspendLayout()
      Me.tbcContacto.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(508, 455)
      Me.btnAceptar.TabIndex = 2
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(589, 455)
      Me.btnCancelar.TabIndex = 3
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(90, 14)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreContacto"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = "NombreCliente"
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(93, 30)
      Me.txtNombre.MaxLength = 100
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(483, 20)
      Me.txtNombre.TabIndex = 1
      '
      'grbCliente
      '
      Me.grbCliente.Controls.Add(Me.txtCodigoContacto)
      Me.grbCliente.Controls.Add(Me.chbActivo)
      Me.grbCliente.Controls.Add(Me.txtNombre)
      Me.grbCliente.Controls.Add(Me.lblCodigoCliente)
      Me.grbCliente.Controls.Add(Me.lblNombre)
      Me.grbCliente.Location = New System.Drawing.Point(12, 12)
      Me.grbCliente.Name = "grbCliente"
      Me.grbCliente.Size = New System.Drawing.Size(655, 62)
      Me.grbCliente.TabIndex = 0
      Me.grbCliente.TabStop = False
      '
      'txtCodigoContacto
      '
      Me.txtCodigoContacto.BindearPropiedadControl = "Text"
      Me.txtCodigoContacto.BindearPropiedadEntidad = "IdContacto"
      Me.txtCodigoContacto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigoContacto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigoContacto.Formato = ""
      Me.txtCodigoContacto.IsDecimal = False
      Me.txtCodigoContacto.IsNumber = True
      Me.txtCodigoContacto.IsPK = False
      Me.txtCodigoContacto.IsRequired = True
      Me.txtCodigoContacto.Key = ""
      Me.txtCodigoContacto.LabelAsoc = Me.lblCodigoCliente
      Me.txtCodigoContacto.Location = New System.Drawing.Point(18, 30)
      Me.txtCodigoContacto.MaxLength = 8
      Me.txtCodigoContacto.Name = "txtCodigoContacto"
      Me.txtCodigoContacto.Size = New System.Drawing.Size(70, 20)
      Me.txtCodigoContacto.TabIndex = 0
      Me.txtCodigoContacto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.Location = New System.Drawing.Point(15, 14)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 2
      Me.lblCodigoCliente.Text = "Código"
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
      Me.chbActivo.Location = New System.Drawing.Point(584, 32)
      Me.chbActivo.Name = "chbActivo"
      Me.chbActivo.Size = New System.Drawing.Size(56, 17)
      Me.chbActivo.TabIndex = 4
      Me.chbActivo.Text = "Activo"
      Me.chbActivo.UseVisualStyleBackColor = True
      '
      'ofdArchivos
      '
      Me.ofdArchivos.Filter = "jpg files|*.jpg"
      '
      'txtCUIT
      '
      Me.txtCUIT.BindearPropiedadControl = "Text"
      Me.txtCUIT.BindearPropiedadEntidad = "Cuit"
      Me.txtCUIT.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCUIT.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCUIT.Formato = ""
      Me.txtCUIT.IsDecimal = False
      Me.txtCUIT.IsNumber = False
      Me.txtCUIT.IsPK = False
      Me.txtCUIT.IsRequired = False
      Me.txtCUIT.Key = ""
      Me.txtCUIT.LabelAsoc = Me.lblCUIT
      Me.txtCUIT.Location = New System.Drawing.Point(111, 137)
      Me.txtCUIT.MaxLength = 11
      Me.txtCUIT.Name = "txtCUIT"
      Me.txtCUIT.Size = New System.Drawing.Size(95, 20)
      Me.txtCUIT.TabIndex = 15
      Me.tlpInfo.SetToolTip(Me.txtCUIT, "CUIT es obligatorio cuando la categoria fiscal solicita el CUIT")
      '
      'lblCUIT
      '
      Me.lblCUIT.AutoSize = True
      Me.lblCUIT.Location = New System.Drawing.Point(15, 140)
      Me.lblCUIT.Name = "lblCUIT"
      Me.lblCUIT.Size = New System.Drawing.Size(32, 13)
      Me.lblCUIT.TabIndex = 14
      Me.lblCUIT.Text = "CUIT"
      '
      'tbpFoto
      '
      Me.tbpFoto.BackColor = System.Drawing.SystemColors.Control
      Me.tbpFoto.Controls.Add(Me.pcbFoto)
      Me.tbpFoto.Controls.Add(Me.btnLimpiarImagen)
      Me.tbpFoto.Controls.Add(Me.btnBuscarImagen)
      Me.tbpFoto.Location = New System.Drawing.Point(4, 22)
      Me.tbpFoto.Name = "tbpFoto"
      Me.tbpFoto.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpFoto.Size = New System.Drawing.Size(651, 335)
      Me.tbpFoto.TabIndex = 5
      Me.tbpFoto.Text = "Foto"
      '
      'pcbFoto
      '
      Me.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
      Me.pcbFoto.Location = New System.Drawing.Point(174, 16)
      Me.pcbFoto.Name = "pcbFoto"
      Me.pcbFoto.Size = New System.Drawing.Size(324, 241)
      Me.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.pcbFoto.TabIndex = 9
      Me.pcbFoto.TabStop = False
      '
      'btnLimpiarImagen
      '
      Me.btnLimpiarImagen.Location = New System.Drawing.Point(57, 161)
      Me.btnLimpiarImagen.Name = "btnLimpiarImagen"
      Me.btnLimpiarImagen.Size = New System.Drawing.Size(111, 33)
      Me.btnLimpiarImagen.TabIndex = 8
      Me.btnLimpiarImagen.Text = "&Limpiar imagen"
      Me.btnLimpiarImagen.UseVisualStyleBackColor = True
      '
      'btnBuscarImagen
      '
      Me.btnBuscarImagen.Location = New System.Drawing.Point(10, 19)
      Me.btnBuscarImagen.Name = "btnBuscarImagen"
      Me.btnBuscarImagen.Size = New System.Drawing.Size(158, 33)
      Me.btnBuscarImagen.TabIndex = 7
      Me.btnBuscarImagen.Text = "&Buscar imagen"
      Me.btnBuscarImagen.UseVisualStyleBackColor = True
      '
      'tbpOtros
      '
      Me.tbpOtros.BackColor = System.Drawing.SystemColors.Control
      Me.tbpOtros.Controls.Add(Me.grbOtros)
      Me.tbpOtros.Location = New System.Drawing.Point(4, 22)
      Me.tbpOtros.Name = "tbpOtros"
      Me.tbpOtros.Size = New System.Drawing.Size(651, 335)
      Me.tbpOtros.TabIndex = 3
      Me.tbpOtros.Text = "Otros"
      '
      'grbOtros
      '
      Me.grbOtros.BackColor = System.Drawing.SystemColors.Control
      Me.grbOtros.Controls.Add(Me.txtObservacion)
      Me.grbOtros.Controls.Add(Me.lblObservacion)
      Me.grbOtros.Location = New System.Drawing.Point(3, 3)
      Me.grbOtros.Name = "grbOtros"
      Me.grbOtros.Size = New System.Drawing.Size(645, 356)
      Me.grbOtros.TabIndex = 0
      Me.grbOtros.TabStop = False
      '
      'txtObservacion
      '
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
      Me.txtObservacion.Location = New System.Drawing.Point(80, 19)
      Me.txtObservacion.MaxLength = 1000
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtObservacion.Size = New System.Drawing.Size(559, 306)
      Me.txtObservacion.TabIndex = 9
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.Location = New System.Drawing.Point(8, 16)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 16
      Me.lblObservacion.Text = "Observación"
      '
      'tbpMapa
      '
      Me.tbpMapa.BackColor = System.Drawing.SystemColors.Control
      Me.tbpMapa.Controls.Add(Me.grbUbicacion)
      Me.tbpMapa.Location = New System.Drawing.Point(4, 22)
      Me.tbpMapa.Name = "tbpMapa"
      Me.tbpMapa.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpMapa.Size = New System.Drawing.Size(651, 335)
      Me.tbpMapa.TabIndex = 1
      Me.tbpMapa.Text = "Mapa"
      '
      'grbUbicacion
      '
      Me.grbUbicacion.Controls.Add(Me.lblGeoLocalizacionLat)
      Me.grbUbicacion.Controls.Add(Me.lblGeoLocalizacionLng)
      Me.grbUbicacion.Controls.Add(Me.txtGeoLocalizacionLat)
      Me.grbUbicacion.Controls.Add(Me.txtGeoLocalizacionLng)
      Me.grbUbicacion.Controls.Add(Me.Panel1)
      Me.grbUbicacion.Controls.Add(Me.tcbZoom)
      Me.grbUbicacion.Controls.Add(Me.cmbTipoMapa)
      Me.grbUbicacion.Controls.Add(Me.btnGeolocalizar)
      Me.grbUbicacion.Location = New System.Drawing.Point(6, 6)
      Me.grbUbicacion.Name = "grbUbicacion"
      Me.grbUbicacion.Size = New System.Drawing.Size(639, 323)
      Me.grbUbicacion.TabIndex = 0
      Me.grbUbicacion.TabStop = False
      '
      'lblGeoLocalizacionLat
      '
      Me.lblGeoLocalizacionLat.AutoSize = True
      Me.lblGeoLocalizacionLat.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblGeoLocalizacionLat.Location = New System.Drawing.Point(6, 46)
      Me.lblGeoLocalizacionLat.Name = "lblGeoLocalizacionLat"
      Me.lblGeoLocalizacionLat.Size = New System.Drawing.Size(25, 13)
      Me.lblGeoLocalizacionLat.TabIndex = 20
      Me.lblGeoLocalizacionLat.Text = "Lat."
      '
      'lblGeoLocalizacionLng
      '
      Me.lblGeoLocalizacionLng.AutoSize = True
      Me.lblGeoLocalizacionLng.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblGeoLocalizacionLng.Location = New System.Drawing.Point(6, 82)
      Me.lblGeoLocalizacionLng.Name = "lblGeoLocalizacionLng"
      Me.lblGeoLocalizacionLng.Size = New System.Drawing.Size(28, 13)
      Me.lblGeoLocalizacionLng.TabIndex = 19
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
      Me.txtGeoLocalizacionLat.LabelAsoc = Nothing
      Me.txtGeoLocalizacionLat.Location = New System.Drawing.Point(37, 43)
      Me.txtGeoLocalizacionLat.MaxLength = 100
      Me.txtGeoLocalizacionLat.Name = "txtGeoLocalizacionLat"
      Me.txtGeoLocalizacionLat.Size = New System.Drawing.Size(94, 20)
      Me.txtGeoLocalizacionLat.TabIndex = 18
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
      Me.txtGeoLocalizacionLng.LabelAsoc = Nothing
      Me.txtGeoLocalizacionLng.Location = New System.Drawing.Point(37, 79)
      Me.txtGeoLocalizacionLng.MaxLength = 100
      Me.txtGeoLocalizacionLng.Name = "txtGeoLocalizacionLng"
      Me.txtGeoLocalizacionLng.Size = New System.Drawing.Size(94, 20)
      Me.txtGeoLocalizacionLng.TabIndex = 17
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.gmcMapa)
      Me.Panel1.Location = New System.Drawing.Point(137, 11)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(502, 339)
      Me.Panel1.TabIndex = 16
      '
      'gmcMapa
      '
      Me.gmcMapa.AutoScroll = True
      Me.gmcMapa.Bearing = 0.0!
      Me.gmcMapa.CanDragMap = True
      Me.gmcMapa.Dock = System.Windows.Forms.DockStyle.Fill
      Me.gmcMapa.EmptyTileColor = System.Drawing.Color.Navy
      Me.gmcMapa.GrayScaleMode = False
      Me.gmcMapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
      Me.gmcMapa.LevelsKeepInMemmory = 5
      Me.gmcMapa.Location = New System.Drawing.Point(0, 0)
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
      Me.gmcMapa.Size = New System.Drawing.Size(502, 339)
      Me.gmcMapa.TabIndex = 4
      Me.gmcMapa.Zoom = 0.0R
      '
      'tcbZoom
      '
      Me.tcbZoom.AccessibleDescription = ""
      Me.tcbZoom.LargeChange = 18
      Me.tcbZoom.Location = New System.Drawing.Point(8, 278)
      Me.tcbZoom.Name = "tcbZoom"
      Me.tcbZoom.Size = New System.Drawing.Size(125, 45)
      Me.tcbZoom.TabIndex = 15
      Me.tcbZoom.TickStyle = System.Windows.Forms.TickStyle.TopLeft
      '
      'cmbTipoMapa
      '
      Me.cmbTipoMapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoMapa.FormattingEnabled = True
      Me.cmbTipoMapa.Items.AddRange(New Object() {"Google Maps", "Google Satelite Maps"})
      Me.cmbTipoMapa.Location = New System.Drawing.Point(5, 220)
      Me.cmbTipoMapa.Name = "cmbTipoMapa"
      Me.cmbTipoMapa.Size = New System.Drawing.Size(126, 21)
      Me.cmbTipoMapa.TabIndex = 14
      '
      'btnGeolocalizar
      '
      Me.btnGeolocalizar.Image = Global.Eniac.Win.My.Resources.Resources.earth_location
      Me.btnGeolocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnGeolocalizar.Location = New System.Drawing.Point(9, 132)
      Me.btnGeolocalizar.Name = "btnGeolocalizar"
      Me.btnGeolocalizar.Size = New System.Drawing.Size(115, 54)
      Me.btnGeolocalizar.TabIndex = 13
      Me.btnGeolocalizar.Text = "Geolocalizar"
      Me.btnGeolocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnGeolocalizar.UseVisualStyleBackColor = True
      '
      'tbpDirecciones
      '
      Me.tbpDirecciones.BackColor = System.Drawing.SystemColors.Control
      Me.tbpDirecciones.Controls.Add(Me.GroupBox1)
      Me.tbpDirecciones.Location = New System.Drawing.Point(4, 22)
      Me.tbpDirecciones.Name = "tbpDirecciones"
      Me.tbpDirecciones.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpDirecciones.Size = New System.Drawing.Size(651, 335)
      Me.tbpDirecciones.TabIndex = 7
      Me.tbpDirecciones.Text = "Direcciones"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.Label5)
      Me.GroupBox1.Controls.Add(Me.txtTelefonoDir)
      Me.GroupBox1.Controls.Add(Me.txtCorreoDir)
      Me.GroupBox1.Controls.Add(Me.txtCelularDir)
      Me.GroupBox1.Controls.Add(Me.cmbTiposDirecciones)
      Me.GroupBox1.Controls.Add(Me.Label6)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.lnkLocalidadDir)
      Me.GroupBox1.Controls.Add(Me.bscCodigoLocalidadDir)
      Me.GroupBox1.Controls.Add(Me.bscNombreLocalidadDir)
      Me.GroupBox1.Controls.Add(Me.txtProvinciaLocalidadDir)
      Me.GroupBox1.Controls.Add(Me.txtDirecciones)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.btnRefreshDir)
      Me.GroupBox1.Controls.Add(Me.dgvDirecciones)
      Me.GroupBox1.Controls.Add(Me.btnInsertarDir)
      Me.GroupBox1.Controls.Add(Me.btnEliminarDir)
      Me.GroupBox1.Location = New System.Drawing.Point(6, 15)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(639, 318)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Direcciones"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(34, 102)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(49, 13)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "Telefono"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(34, 130)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(94, 13)
      Me.Label4.TabIndex = 13
      Me.Label4.Text = "Correo Electrónico"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(320, 102)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(39, 13)
      Me.Label5.TabIndex = 11
      Me.Label5.Text = "Celular"
      '
      'txtTelefonoDir
      '
      Me.txtTelefonoDir.BindearPropiedadControl = ""
      Me.txtTelefonoDir.BindearPropiedadEntidad = ""
      Me.txtTelefonoDir.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefonoDir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefonoDir.Formato = ""
      Me.txtTelefonoDir.IsDecimal = False
      Me.txtTelefonoDir.IsNumber = False
      Me.txtTelefonoDir.IsPK = False
      Me.txtTelefonoDir.IsRequired = False
      Me.txtTelefonoDir.Key = Nothing
      Me.txtTelefonoDir.LabelAsoc = Me.lblTelefonos
      Me.txtTelefonoDir.Location = New System.Drawing.Point(130, 99)
      Me.txtTelefonoDir.MaxLength = 100
      Me.txtTelefonoDir.Name = "txtTelefonoDir"
      Me.txtTelefonoDir.Size = New System.Drawing.Size(184, 20)
      Me.txtTelefonoDir.TabIndex = 10
      '
      'lblTelefonos
      '
      Me.lblTelefonos.AutoSize = True
      Me.lblTelefonos.Location = New System.Drawing.Point(14, 193)
      Me.lblTelefonos.Name = "lblTelefonos"
      Me.lblTelefonos.Size = New System.Drawing.Size(54, 13)
      Me.lblTelefonos.TabIndex = 22
      Me.lblTelefonos.Text = "Telefonos"
      '
      'txtCorreoDir
      '
      Me.txtCorreoDir.BindearPropiedadControl = ""
      Me.txtCorreoDir.BindearPropiedadEntidad = ""
      Me.txtCorreoDir.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCorreoDir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCorreoDir.Formato = ""
      Me.txtCorreoDir.IsDecimal = False
      Me.txtCorreoDir.IsNumber = False
      Me.txtCorreoDir.IsPK = False
      Me.txtCorreoDir.IsRequired = False
      Me.txtCorreoDir.Key = Nothing
      Me.txtCorreoDir.LabelAsoc = Me.lblCorreoElectronico
      Me.txtCorreoDir.Location = New System.Drawing.Point(129, 125)
      Me.txtCorreoDir.MaxLength = 500
      Me.txtCorreoDir.Name = "txtCorreoDir"
      Me.txtCorreoDir.Size = New System.Drawing.Size(417, 20)
      Me.txtCorreoDir.TabIndex = 14
      '
      'lblCorreoElectronico
      '
      Me.lblCorreoElectronico.AutoSize = True
      Me.lblCorreoElectronico.Location = New System.Drawing.Point(14, 245)
      Me.lblCorreoElectronico.Name = "lblCorreoElectronico"
      Me.lblCorreoElectronico.Size = New System.Drawing.Size(94, 13)
      Me.lblCorreoElectronico.TabIndex = 26
      Me.lblCorreoElectronico.Text = "Correo Electrónico"
      '
      'txtCelularDir
      '
      Me.txtCelularDir.BindearPropiedadControl = ""
      Me.txtCelularDir.BindearPropiedadEntidad = ""
      Me.txtCelularDir.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCelularDir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCelularDir.Formato = ""
      Me.txtCelularDir.IsDecimal = False
      Me.txtCelularDir.IsNumber = False
      Me.txtCelularDir.IsPK = False
      Me.txtCelularDir.IsRequired = False
      Me.txtCelularDir.Key = Nothing
      Me.txtCelularDir.LabelAsoc = Me.lblCelular
      Me.txtCelularDir.Location = New System.Drawing.Point(362, 99)
      Me.txtCelularDir.MaxLength = 100
      Me.txtCelularDir.Name = "txtCelularDir"
      Me.txtCelularDir.Size = New System.Drawing.Size(184, 20)
      Me.txtCelularDir.TabIndex = 12
      '
      'lblCelular
      '
      Me.lblCelular.AutoSize = True
      Me.lblCelular.Location = New System.Drawing.Point(14, 219)
      Me.lblCelular.Name = "lblCelular"
      Me.lblCelular.Size = New System.Drawing.Size(39, 13)
      Me.lblCelular.TabIndex = 24
      Me.lblCelular.Text = "Celular"
      '
      'cmbTiposDirecciones
      '
      Me.cmbTiposDirecciones.BindearPropiedadControl = ""
      Me.cmbTiposDirecciones.BindearPropiedadEntidad = ""
      Me.cmbTiposDirecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTiposDirecciones.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTiposDirecciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTiposDirecciones.FormattingEnabled = True
      Me.cmbTiposDirecciones.IsPK = False
      Me.cmbTiposDirecciones.IsRequired = False
      Me.cmbTiposDirecciones.Key = Nothing
      Me.cmbTiposDirecciones.LabelAsoc = Me.lblZonaGeografica
      Me.cmbTiposDirecciones.Location = New System.Drawing.Point(130, 72)
      Me.cmbTiposDirecciones.Name = "cmbTiposDirecciones"
      Me.cmbTiposDirecciones.Size = New System.Drawing.Size(126, 21)
      Me.cmbTiposDirecciones.TabIndex = 8
      '
      'lblZonaGeografica
      '
      Me.lblZonaGeografica.AutoSize = True
      Me.lblZonaGeografica.Location = New System.Drawing.Point(14, 109)
      Me.lblZonaGeografica.Name = "lblZonaGeografica"
      Me.lblZonaGeografica.Size = New System.Drawing.Size(87, 13)
      Me.lblZonaGeografica.TabIndex = 18
      Me.lblZonaGeografica.Text = "Zona Geográfica"
      Me.lblZonaGeografica.Visible = False
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label6.Location = New System.Drawing.Point(34, 75)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(76, 13)
      Me.Label6.TabIndex = 7
      Me.Label6.Text = "Tipo Dirección"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label1.Location = New System.Drawing.Point(400, 50)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(51, 13)
      Me.Label1.TabIndex = 5
      Me.Label1.Text = "Provincia"
      '
      'lnkLocalidadDir
      '
      Me.lnkLocalidadDir.AutoSize = True
      Me.lnkLocalidadDir.Location = New System.Drawing.Point(61, 49)
      Me.lnkLocalidadDir.Name = "lnkLocalidadDir"
      Me.lnkLocalidadDir.Size = New System.Drawing.Size(53, 13)
      Me.lnkLocalidadDir.TabIndex = 2
      Me.lnkLocalidadDir.TabStop = True
      Me.lnkLocalidadDir.Text = "Localidad"
      '
      'bscCodigoLocalidadDir
      '
      Me.bscCodigoLocalidadDir.AyudaAncho = 608
      Me.bscCodigoLocalidadDir.BindearPropiedadControl = ""
      Me.bscCodigoLocalidadDir.BindearPropiedadEntidad = ""
      Me.bscCodigoLocalidadDir.ColumnasAlineacion = Nothing
      Me.bscCodigoLocalidadDir.ColumnasAncho = Nothing
      Me.bscCodigoLocalidadDir.ColumnasFormato = Nothing
      Me.bscCodigoLocalidadDir.ColumnasOcultas = Nothing
      Me.bscCodigoLocalidadDir.ColumnasTitulos = Nothing
      Me.bscCodigoLocalidadDir.Datos = Nothing
      Me.bscCodigoLocalidadDir.FilaDevuelta = Nothing
      Me.bscCodigoLocalidadDir.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoLocalidadDir.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoLocalidadDir.IsDecimal = False
      Me.bscCodigoLocalidadDir.IsNumber = False
      Me.bscCodigoLocalidadDir.IsPK = False
      Me.bscCodigoLocalidadDir.IsRequired = False
      Me.bscCodigoLocalidadDir.Key = ""
      Me.bscCodigoLocalidadDir.LabelAsoc = Nothing
      Me.bscCodigoLocalidadDir.Location = New System.Drawing.Point(129, 46)
      Me.bscCodigoLocalidadDir.MaxLengh = "32767"
      Me.bscCodigoLocalidadDir.Name = "bscCodigoLocalidadDir"
      Me.bscCodigoLocalidadDir.Permitido = True
      Me.bscCodigoLocalidadDir.Selecciono = False
      Me.bscCodigoLocalidadDir.Size = New System.Drawing.Size(79, 20)
      Me.bscCodigoLocalidadDir.TabIndex = 3
      Me.bscCodigoLocalidadDir.Titulo = Nothing
      '
      'bscNombreLocalidadDir
      '
      Me.bscNombreLocalidadDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscNombreLocalidadDir.AyudaAncho = 608
      Me.bscNombreLocalidadDir.BindearPropiedadControl = Nothing
      Me.bscNombreLocalidadDir.BindearPropiedadEntidad = Nothing
      Me.bscNombreLocalidadDir.ColumnasAlineacion = Nothing
      Me.bscNombreLocalidadDir.ColumnasAncho = Nothing
      Me.bscNombreLocalidadDir.ColumnasFormato = Nothing
      Me.bscNombreLocalidadDir.ColumnasOcultas = Nothing
      Me.bscNombreLocalidadDir.ColumnasTitulos = Nothing
      Me.bscNombreLocalidadDir.Datos = Nothing
      Me.bscNombreLocalidadDir.FilaDevuelta = Nothing
      Me.bscNombreLocalidadDir.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreLocalidadDir.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreLocalidadDir.IsDecimal = False
      Me.bscNombreLocalidadDir.IsNumber = False
      Me.bscNombreLocalidadDir.IsPK = False
      Me.bscNombreLocalidadDir.IsRequired = False
      Me.bscNombreLocalidadDir.Key = ""
      Me.bscNombreLocalidadDir.LabelAsoc = Nothing
      Me.bscNombreLocalidadDir.Location = New System.Drawing.Point(210, 46)
      Me.bscNombreLocalidadDir.MaxLengh = "32767"
      Me.bscNombreLocalidadDir.Name = "bscNombreLocalidadDir"
      Me.bscNombreLocalidadDir.Permitido = True
      Me.bscNombreLocalidadDir.Selecciono = False
      Me.bscNombreLocalidadDir.Size = New System.Drawing.Size(189, 20)
      Me.bscNombreLocalidadDir.TabIndex = 4
      Me.bscNombreLocalidadDir.Titulo = Nothing
      '
      'txtProvinciaLocalidadDir
      '
      Me.txtProvinciaLocalidadDir.BindearPropiedadControl = ""
      Me.txtProvinciaLocalidadDir.BindearPropiedadEntidad = ""
      Me.txtProvinciaLocalidadDir.ForeColorFocus = System.Drawing.Color.Red
      Me.txtProvinciaLocalidadDir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtProvinciaLocalidadDir.Formato = ""
      Me.txtProvinciaLocalidadDir.IsDecimal = False
      Me.txtProvinciaLocalidadDir.IsNumber = False
      Me.txtProvinciaLocalidadDir.IsPK = False
      Me.txtProvinciaLocalidadDir.IsRequired = False
      Me.txtProvinciaLocalidadDir.Key = ""
      Me.txtProvinciaLocalidadDir.LabelAsoc = Me.Label1
      Me.txtProvinciaLocalidadDir.Location = New System.Drawing.Point(451, 46)
      Me.txtProvinciaLocalidadDir.MaxLength = 100
      Me.txtProvinciaLocalidadDir.Name = "txtProvinciaLocalidadDir"
      Me.txtProvinciaLocalidadDir.ReadOnly = True
      Me.txtProvinciaLocalidadDir.Size = New System.Drawing.Size(96, 20)
      Me.txtProvinciaLocalidadDir.TabIndex = 6
      '
      'txtDirecciones
      '
      Me.txtDirecciones.BindearPropiedadControl = ""
      Me.txtDirecciones.BindearPropiedadEntidad = ""
      Me.txtDirecciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDirecciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDirecciones.Formato = ""
      Me.txtDirecciones.IsDecimal = False
      Me.txtDirecciones.IsNumber = False
      Me.txtDirecciones.IsPK = False
      Me.txtDirecciones.IsRequired = False
      Me.txtDirecciones.Key = ""
      Me.txtDirecciones.LabelAsoc = Me.Label2
      Me.txtDirecciones.Location = New System.Drawing.Point(129, 20)
      Me.txtDirecciones.MaxLength = 100
      Me.txtDirecciones.Name = "txtDirecciones"
      Me.txtDirecciones.Size = New System.Drawing.Size(417, 20)
      Me.txtDirecciones.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label2.Location = New System.Drawing.Point(60, 23)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(52, 13)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Direccion"
      '
      'btnRefreshDir
      '
      Me.btnRefreshDir.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
      Me.btnRefreshDir.Location = New System.Drawing.Point(8, 26)
      Me.btnRefreshDir.Name = "btnRefreshDir"
      Me.btnRefreshDir.Size = New System.Drawing.Size(37, 37)
      Me.btnRefreshDir.TabIndex = 18
      Me.btnRefreshDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnRefreshDir.UseVisualStyleBackColor = True
      '
      'dgvDirecciones
      '
      Me.dgvDirecciones.AllowUserToAddRows = False
      Me.dgvDirecciones.AllowUserToDeleteRows = False
      Me.dgvDirecciones.AllowUserToResizeColumns = False
      Me.dgvDirecciones.AllowUserToResizeRows = False
      Me.dgvDirecciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvDirecciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvDirecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDirecciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdContacto, Me.IdDireccion, Me.IdLocalidad, Me.NombreLocalidad, Me.DataGridViewTextBoxColumn3, Me.NombreAbrevTipoDireccion, Me.IdTipoDireccion, Me.Telefono, Me.Celular, Me.CorreoElectronico})
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDirecciones.DefaultCellStyle = DataGridViewCellStyle2
      Me.dgvDirecciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvDirecciones.Location = New System.Drawing.Point(6, 152)
      Me.dgvDirecciones.Name = "dgvDirecciones"
      Me.dgvDirecciones.ReadOnly = True
      Me.dgvDirecciones.RowHeadersVisible = False
      Me.dgvDirecciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDirecciones.Size = New System.Drawing.Size(627, 160)
      Me.dgvDirecciones.TabIndex = 17
      '
      'IdContacto
      '
      Me.IdContacto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.IdContacto.DataPropertyName = "IdContacto"
      Me.IdContacto.HeaderText = "IdCliente"
      Me.IdContacto.Name = "IdContacto"
      Me.IdContacto.ReadOnly = True
      Me.IdContacto.Visible = False
      '
      'IdDireccion
      '
      Me.IdDireccion.DataPropertyName = "Direccion"
      Me.IdDireccion.HeaderText = "Direccion"
      Me.IdDireccion.Name = "IdDireccion"
      Me.IdDireccion.ReadOnly = True
      Me.IdDireccion.Width = 200
      '
      'IdLocalidad
      '
      Me.IdLocalidad.DataPropertyName = "IdLocalidad"
      Me.IdLocalidad.HeaderText = "CP"
      Me.IdLocalidad.Name = "IdLocalidad"
      Me.IdLocalidad.ReadOnly = True
      Me.IdLocalidad.Width = 60
      '
      'NombreLocalidad
      '
      Me.NombreLocalidad.DataPropertyName = "NombreLocalidad"
      Me.NombreLocalidad.HeaderText = "Localidad"
      Me.NombreLocalidad.Name = "NombreLocalidad"
      Me.NombreLocalidad.ReadOnly = True
      Me.NombreLocalidad.Width = 80
      '
      'DataGridViewTextBoxColumn3
      '
      Me.DataGridViewTextBoxColumn3.DataPropertyName = "NombreProvincia"
      Me.DataGridViewTextBoxColumn3.HeaderText = "Provincia"
      Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
      Me.DataGridViewTextBoxColumn3.ReadOnly = True
      Me.DataGridViewTextBoxColumn3.Width = 80
      '
      'NombreAbrevTipoDireccion
      '
      Me.NombreAbrevTipoDireccion.DataPropertyName = "NombreAbrevTipoDireccion"
      Me.NombreAbrevTipoDireccion.HeaderText = "Tip. Direcc."
      Me.NombreAbrevTipoDireccion.Name = "NombreAbrevTipoDireccion"
      Me.NombreAbrevTipoDireccion.ReadOnly = True
      Me.NombreAbrevTipoDireccion.Width = 40
      '
      'IdTipoDireccion
      '
      Me.IdTipoDireccion.DataPropertyName = "IdTipoDireccion"
      Me.IdTipoDireccion.HeaderText = "IdTipoDireccion"
      Me.IdTipoDireccion.Name = "IdTipoDireccion"
      Me.IdTipoDireccion.ReadOnly = True
      Me.IdTipoDireccion.Visible = False
      '
      'Telefono
      '
      Me.Telefono.DataPropertyName = "Telefono"
      Me.Telefono.HeaderText = "Telefono"
      Me.Telefono.Name = "Telefono"
      Me.Telefono.ReadOnly = True
      Me.Telefono.Width = 200
      '
      'Celular
      '
      Me.Celular.DataPropertyName = "Celular"
      Me.Celular.HeaderText = "Celular"
      Me.Celular.Name = "Celular"
      Me.Celular.ReadOnly = True
      Me.Celular.Width = 200
      '
      'CorreoElectronico
      '
      Me.CorreoElectronico.DataPropertyName = "CorreoElectronico"
      Me.CorreoElectronico.HeaderText = "CorreoElectronico"
      Me.CorreoElectronico.Name = "CorreoElectronico"
      Me.CorreoElectronico.ReadOnly = True
      Me.CorreoElectronico.Width = 200
      '
      'btnInsertarDir
      '
      Me.btnInsertarDir.Image = CType(resources.GetObject("btnInsertarDir.Image"), System.Drawing.Image)
      Me.btnInsertarDir.Location = New System.Drawing.Point(552, 108)
      Me.btnInsertarDir.Name = "btnInsertarDir"
      Me.btnInsertarDir.Size = New System.Drawing.Size(37, 37)
      Me.btnInsertarDir.TabIndex = 15
      Me.btnInsertarDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnInsertarDir.UseVisualStyleBackColor = True
      '
      'btnEliminarDir
      '
      Me.btnEliminarDir.Image = CType(resources.GetObject("btnEliminarDir.Image"), System.Drawing.Image)
      Me.btnEliminarDir.Location = New System.Drawing.Point(595, 108)
      Me.btnEliminarDir.Name = "btnEliminarDir"
      Me.btnEliminarDir.Size = New System.Drawing.Size(37, 37)
      Me.btnEliminarDir.TabIndex = 16
      Me.btnEliminarDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnEliminarDir.UseVisualStyleBackColor = True
      '
      'tbpDatos
      '
      Me.tbpDatos.BackColor = System.Drawing.SystemColors.Control
      Me.tbpDatos.Controls.Add(Me.grbDatosPersonales)
      Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
      Me.tbpDatos.Name = "tbpDatos"
      Me.tbpDatos.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpDatos.Size = New System.Drawing.Size(651, 335)
      Me.tbpDatos.TabIndex = 0
      Me.tbpDatos.Text = "Datos"
      '
      'grbDatosPersonales
      '
      Me.grbDatosPersonales.Controls.Add(Me.chbPrivado)
      Me.grbDatosPersonales.Controls.Add(Me.cmbTipoContacto)
      Me.grbDatosPersonales.Controls.Add(Me.Label7)
      Me.grbDatosPersonales.Controls.Add(Me.lblProvinciaLocalidad)
      Me.grbDatosPersonales.Controls.Add(Me.lnkLocalidad)
      Me.grbDatosPersonales.Controls.Add(Me.bscCodigoLocalidad)
      Me.grbDatosPersonales.Controls.Add(Me.bscNombreLocalidad)
      Me.grbDatosPersonales.Controls.Add(Me.cmbZonaGeografica)
      Me.grbDatosPersonales.Controls.Add(Me.txtProvinciaLocalidad)
      Me.grbDatosPersonales.Controls.Add(Me.txtDireccion)
      Me.grbDatosPersonales.Controls.Add(Me.lblDireccion)
      Me.grbDatosPersonales.Controls.Add(Me.cmbTipoDoc)
      Me.grbDatosPersonales.Controls.Add(Me.lblID)
      Me.grbDatosPersonales.Controls.Add(Me.txtNroDoc)
      Me.grbDatosPersonales.Controls.Add(Me.lblTipoDocumento)
      Me.grbDatosPersonales.Controls.Add(Me.txtTelefonos)
      Me.grbDatosPersonales.Controls.Add(Me.lblTelefonos)
      Me.grbDatosPersonales.Controls.Add(Me.txtPaginaWeb)
      Me.grbDatosPersonales.Controls.Add(Me.txtCorreoElectronico)
      Me.grbDatosPersonales.Controls.Add(Me.lblPaginaWeb)
      Me.grbDatosPersonales.Controls.Add(Me.lblCorreoElectronico)
      Me.grbDatosPersonales.Controls.Add(Me.txtCelular)
      Me.grbDatosPersonales.Controls.Add(Me.lblCelular)
      Me.grbDatosPersonales.Controls.Add(Me.dtpFechaAlta)
      Me.grbDatosPersonales.Controls.Add(Me.lblFechaAlta)
      Me.grbDatosPersonales.Controls.Add(Me.txtCUIT)
      Me.grbDatosPersonales.Controls.Add(Me.lblCUIT)
      Me.grbDatosPersonales.Controls.Add(Me.cmbCategoriaFiscal)
      Me.grbDatosPersonales.Controls.Add(Me.lblCategoriaFiscal)
      Me.grbDatosPersonales.Controls.Add(Me.dtpFechaNacimiento)
      Me.grbDatosPersonales.Controls.Add(Me.lblFechaNac)
      Me.grbDatosPersonales.Controls.Add(Me.lblZonaGeografica)
      Me.grbDatosPersonales.Location = New System.Drawing.Point(6, 7)
      Me.grbDatosPersonales.Name = "grbDatosPersonales"
      Me.grbDatosPersonales.Size = New System.Drawing.Size(640, 322)
      Me.grbDatosPersonales.TabIndex = 0
      Me.grbDatosPersonales.TabStop = False
      '
      'chbPrivado
      '
      Me.chbPrivado.AutoSize = True
      Me.chbPrivado.BindearPropiedadControl = "Checked"
      Me.chbPrivado.BindearPropiedadEntidad = "Privado"
      Me.chbPrivado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrivado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrivado.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbPrivado.IsPK = False
      Me.chbPrivado.IsRequired = False
      Me.chbPrivado.Key = Nothing
      Me.chbPrivado.LabelAsoc = Nothing
      Me.chbPrivado.Location = New System.Drawing.Point(321, 14)
      Me.chbPrivado.Name = "chbPrivado"
      Me.chbPrivado.Size = New System.Drawing.Size(62, 17)
      Me.chbPrivado.TabIndex = 2
      Me.chbPrivado.Text = "Privado"
      Me.chbPrivado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbPrivado.UseVisualStyleBackColor = True
      '
      'cmbTipoContacto
      '
      Me.cmbTipoContacto.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoContacto.BindearPropiedadEntidad = "IdTipoContacto"
      Me.cmbTipoContacto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoContacto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoContacto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoContacto.FormattingEnabled = True
      Me.cmbTipoContacto.IsPK = False
      Me.cmbTipoContacto.IsRequired = False
      Me.cmbTipoContacto.Key = Nothing
      Me.cmbTipoContacto.LabelAsoc = Me.Label7
      Me.cmbTipoContacto.Location = New System.Drawing.Point(111, 12)
      Me.cmbTipoContacto.Name = "cmbTipoContacto"
      Me.cmbTipoContacto.Size = New System.Drawing.Size(180, 21)
      Me.cmbTipoContacto.TabIndex = 1
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(14, 16)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(89, 13)
      Me.Label7.TabIndex = 0
      Me.Label7.Text = "Tipo de Contacto"
      '
      'lblProvinciaLocalidad
      '
      Me.lblProvinciaLocalidad.AutoSize = True
      Me.lblProvinciaLocalidad.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblProvinciaLocalidad.Location = New System.Drawing.Point(441, 77)
      Me.lblProvinciaLocalidad.Name = "lblProvinciaLocalidad"
      Me.lblProvinciaLocalidad.Size = New System.Drawing.Size(51, 13)
      Me.lblProvinciaLocalidad.TabIndex = 8
      Me.lblProvinciaLocalidad.Text = "Provincia"
      '
      'lnkLocalidad
      '
      Me.lnkLocalidad.AutoSize = True
      Me.lnkLocalidad.Location = New System.Drawing.Point(14, 77)
      Me.lnkLocalidad.Name = "lnkLocalidad"
      Me.lnkLocalidad.Size = New System.Drawing.Size(53, 13)
      Me.lnkLocalidad.TabIndex = 5
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
      Me.bscCodigoLocalidad.Location = New System.Drawing.Point(111, 73)
      Me.bscCodigoLocalidad.MaxLengh = "32767"
      Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
      Me.bscCodigoLocalidad.Permitido = True
      Me.bscCodigoLocalidad.Selecciono = False
      Me.bscCodigoLocalidad.Size = New System.Drawing.Size(98, 20)
      Me.bscCodigoLocalidad.TabIndex = 6
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
      Me.bscNombreLocalidad.Location = New System.Drawing.Point(216, 73)
      Me.bscNombreLocalidad.MaxLengh = "32767"
      Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
      Me.bscNombreLocalidad.Permitido = True
      Me.bscNombreLocalidad.Selecciono = False
      Me.bscNombreLocalidad.Size = New System.Drawing.Size(223, 20)
      Me.bscNombreLocalidad.TabIndex = 7
      Me.bscNombreLocalidad.Titulo = Nothing
      '
      'cmbZonaGeografica
      '
      Me.cmbZonaGeografica.BindearPropiedadControl = "SelectedValue"
      Me.cmbZonaGeografica.BindearPropiedadEntidad = "ZonaGeografica.IdZonaGeografica"
      Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbZonaGeografica.FormattingEnabled = True
      Me.cmbZonaGeografica.IsPK = False
      Me.cmbZonaGeografica.IsRequired = False
      Me.cmbZonaGeografica.Key = Nothing
      Me.cmbZonaGeografica.LabelAsoc = Me.lblZonaGeografica
      Me.cmbZonaGeografica.Location = New System.Drawing.Point(111, 105)
      Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
      Me.cmbZonaGeografica.Size = New System.Drawing.Size(204, 21)
      Me.cmbZonaGeografica.TabIndex = 11
      Me.cmbZonaGeografica.Visible = False
      '
      'txtProvinciaLocalidad
      '
      Me.txtProvinciaLocalidad.BindearPropiedadControl = ""
      Me.txtProvinciaLocalidad.BindearPropiedadEntidad = ""
      Me.txtProvinciaLocalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtProvinciaLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtProvinciaLocalidad.Formato = ""
      Me.txtProvinciaLocalidad.IsDecimal = False
      Me.txtProvinciaLocalidad.IsNumber = False
      Me.txtProvinciaLocalidad.IsPK = False
      Me.txtProvinciaLocalidad.IsRequired = False
      Me.txtProvinciaLocalidad.Key = ""
      Me.txtProvinciaLocalidad.LabelAsoc = Me.lblProvinciaLocalidad
      Me.txtProvinciaLocalidad.Location = New System.Drawing.Point(495, 73)
      Me.txtProvinciaLocalidad.MaxLength = 100
      Me.txtProvinciaLocalidad.Name = "txtProvinciaLocalidad"
      Me.txtProvinciaLocalidad.ReadOnly = True
      Me.txtProvinciaLocalidad.Size = New System.Drawing.Size(135, 20)
      Me.txtProvinciaLocalidad.TabIndex = 9
      '
      'txtDireccion
      '
      Me.txtDireccion.BindearPropiedadControl = "Text"
      Me.txtDireccion.BindearPropiedadEntidad = "Direccion"
      Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDireccion.Formato = ""
      Me.txtDireccion.IsDecimal = False
      Me.txtDireccion.IsNumber = False
      Me.txtDireccion.IsPK = False
      Me.txtDireccion.IsRequired = False
      Me.txtDireccion.Key = ""
      Me.txtDireccion.LabelAsoc = Me.lblDireccion
      Me.txtDireccion.Location = New System.Drawing.Point(111, 44)
      Me.txtDireccion.MaxLength = 100
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.Size = New System.Drawing.Size(425, 20)
      Me.txtDireccion.TabIndex = 4
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDireccion.Location = New System.Drawing.Point(14, 48)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblDireccion.TabIndex = 3
      Me.lblDireccion.Text = "Direccion"
      '
      'cmbTipoDoc
      '
      Me.cmbTipoDoc.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoDoc.BindearPropiedadEntidad = "TipoDocContacto"
      Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoDoc.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoDoc.FormattingEnabled = True
      Me.cmbTipoDoc.IsPK = False
      Me.cmbTipoDoc.IsRequired = False
      Me.cmbTipoDoc.Key = Nothing
      Me.cmbTipoDoc.LabelAsoc = Me.lblTipoDocumento
      Me.cmbTipoDoc.Location = New System.Drawing.Point(111, 163)
      Me.cmbTipoDoc.Name = "cmbTipoDoc"
      Me.cmbTipoDoc.Size = New System.Drawing.Size(62, 21)
      Me.cmbTipoDoc.TabIndex = 19
      '
      'lblTipoDocumento
      '
      Me.lblTipoDocumento.AutoSize = True
      Me.lblTipoDocumento.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblTipoDocumento.Location = New System.Drawing.Point(15, 166)
      Me.lblTipoDocumento.Name = "lblTipoDocumento"
      Me.lblTipoDocumento.Size = New System.Drawing.Size(54, 13)
      Me.lblTipoDocumento.TabIndex = 18
      Me.lblTipoDocumento.Text = "Tipo Doc."
      '
      'lblID
      '
      Me.lblID.AutoSize = True
      Me.lblID.Location = New System.Drawing.Point(178, 167)
      Me.lblID.Name = "lblID"
      Me.lblID.Size = New System.Drawing.Size(85, 13)
      Me.lblID.TabIndex = 20
      Me.lblID.Text = "Nro. Documento"
      '
      'txtNroDoc
      '
      Me.txtNroDoc.BindearPropiedadControl = "Text"
      Me.txtNroDoc.BindearPropiedadEntidad = "NroDocContacto"
      Me.txtNroDoc.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNroDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNroDoc.Formato = ""
      Me.txtNroDoc.IsDecimal = False
      Me.txtNroDoc.IsNumber = True
      Me.txtNroDoc.IsPK = False
      Me.txtNroDoc.IsRequired = False
      Me.txtNroDoc.Key = ""
      Me.txtNroDoc.LabelAsoc = Me.lblID
      Me.txtNroDoc.Location = New System.Drawing.Point(275, 164)
      Me.txtNroDoc.MaxLength = 12
      Me.txtNroDoc.Name = "txtNroDoc"
      Me.txtNroDoc.Size = New System.Drawing.Size(95, 20)
      Me.txtNroDoc.TabIndex = 21
      Me.txtNroDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTelefonos
      '
      Me.txtTelefonos.BindearPropiedadControl = "Text"
      Me.txtTelefonos.BindearPropiedadEntidad = "Telefono"
      Me.txtTelefonos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefonos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefonos.Formato = ""
      Me.txtTelefonos.IsDecimal = False
      Me.txtTelefonos.IsNumber = False
      Me.txtTelefonos.IsPK = False
      Me.txtTelefonos.IsRequired = False
      Me.txtTelefonos.Key = Nothing
      Me.txtTelefonos.LabelAsoc = Me.lblTelefonos
      Me.txtTelefonos.Location = New System.Drawing.Point(111, 190)
      Me.txtTelefonos.MaxLength = 100
      Me.txtTelefonos.Name = "txtTelefonos"
      Me.txtTelefonos.Size = New System.Drawing.Size(519, 20)
      Me.txtTelefonos.TabIndex = 23
      '
      'txtPaginaWeb
      '
      Me.txtPaginaWeb.BindearPropiedadControl = "Text"
      Me.txtPaginaWeb.BindearPropiedadEntidad = "PaginaWeb"
      Me.txtPaginaWeb.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPaginaWeb.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPaginaWeb.Formato = ""
      Me.txtPaginaWeb.IsDecimal = False
      Me.txtPaginaWeb.IsNumber = False
      Me.txtPaginaWeb.IsPK = False
      Me.txtPaginaWeb.IsRequired = False
      Me.txtPaginaWeb.Key = Nothing
      Me.txtPaginaWeb.LabelAsoc = Me.lblPaginaWeb
      Me.txtPaginaWeb.Location = New System.Drawing.Point(111, 268)
      Me.txtPaginaWeb.MaxLength = 100
      Me.txtPaginaWeb.Name = "txtPaginaWeb"
      Me.txtPaginaWeb.Size = New System.Drawing.Size(519, 20)
      Me.txtPaginaWeb.TabIndex = 29
      '
      'lblPaginaWeb
      '
      Me.lblPaginaWeb.AutoSize = True
      Me.lblPaginaWeb.Location = New System.Drawing.Point(14, 271)
      Me.lblPaginaWeb.Name = "lblPaginaWeb"
      Me.lblPaginaWeb.Size = New System.Drawing.Size(66, 13)
      Me.lblPaginaWeb.TabIndex = 28
      Me.lblPaginaWeb.Text = "Página Web"
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
      Me.txtCorreoElectronico.Location = New System.Drawing.Point(111, 242)
      Me.txtCorreoElectronico.MaxLength = 500
      Me.txtCorreoElectronico.Name = "txtCorreoElectronico"
      Me.txtCorreoElectronico.Size = New System.Drawing.Size(519, 20)
      Me.txtCorreoElectronico.TabIndex = 27
      '
      'txtCelular
      '
      Me.txtCelular.BindearPropiedadControl = "Text"
      Me.txtCelular.BindearPropiedadEntidad = "Celular"
      Me.txtCelular.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCelular.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCelular.Formato = ""
      Me.txtCelular.IsDecimal = False
      Me.txtCelular.IsNumber = False
      Me.txtCelular.IsPK = False
      Me.txtCelular.IsRequired = False
      Me.txtCelular.Key = Nothing
      Me.txtCelular.LabelAsoc = Me.lblCelular
      Me.txtCelular.Location = New System.Drawing.Point(111, 216)
      Me.txtCelular.MaxLength = 100
      Me.txtCelular.Name = "txtCelular"
      Me.txtCelular.Size = New System.Drawing.Size(519, 20)
      Me.txtCelular.TabIndex = 25
      '
      'dtpFechaAlta
      '
      Me.dtpFechaAlta.BindearPropiedadControl = "Value"
      Me.dtpFechaAlta.BindearPropiedadEntidad = "FechaAlta"
      Me.dtpFechaAlta.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaAlta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaAlta.IsPK = False
      Me.dtpFechaAlta.IsRequired = False
      Me.dtpFechaAlta.Key = ""
      Me.dtpFechaAlta.LabelAsoc = Me.lblFechaAlta
      Me.dtpFechaAlta.Location = New System.Drawing.Point(535, 105)
      Me.dtpFechaAlta.Name = "dtpFechaAlta"
      Me.dtpFechaAlta.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaAlta.TabIndex = 13
      '
      'lblFechaAlta
      '
      Me.lblFechaAlta.AutoSize = True
      Me.lblFechaAlta.Location = New System.Drawing.Point(470, 109)
      Me.lblFechaAlta.Name = "lblFechaAlta"
      Me.lblFechaAlta.Size = New System.Drawing.Size(58, 13)
      Me.lblFechaAlta.TabIndex = 12
      Me.lblFechaAlta.Text = "Fecha Alta"
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
      Me.cmbCategoriaFiscal.IsRequired = False
      Me.cmbCategoriaFiscal.Key = Nothing
      Me.cmbCategoriaFiscal.LabelAsoc = Me.lblCategoriaFiscal
      Me.cmbCategoriaFiscal.Location = New System.Drawing.Point(111, 105)
      Me.cmbCategoriaFiscal.Name = "cmbCategoriaFiscal"
      Me.cmbCategoriaFiscal.Size = New System.Drawing.Size(163, 21)
      Me.cmbCategoriaFiscal.TabIndex = 6
      '
      'lblCategoriaFiscal
      '
      Me.lblCategoriaFiscal.AutoSize = True
      Me.lblCategoriaFiscal.Location = New System.Drawing.Point(15, 108)
      Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
      Me.lblCategoriaFiscal.Size = New System.Drawing.Size(68, 13)
      Me.lblCategoriaFiscal.TabIndex = 10
      Me.lblCategoriaFiscal.Text = "Categ. Fiscal"
      '
      'dtpFechaNacimiento
      '
      Me.dtpFechaNacimiento.BindearPropiedadControl = "Value"
      Me.dtpFechaNacimiento.BindearPropiedadEntidad = "FechaNacimiento"
      Me.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaNacimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaNacimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaNacimiento.IsPK = False
      Me.dtpFechaNacimiento.IsRequired = False
      Me.dtpFechaNacimiento.Key = ""
      Me.dtpFechaNacimiento.LabelAsoc = Me.lblFechaNac
      Me.dtpFechaNacimiento.Location = New System.Drawing.Point(535, 134)
      Me.dtpFechaNacimiento.Name = "dtpFechaNacimiento"
      Me.dtpFechaNacimiento.Size = New System.Drawing.Size(95, 20)
      Me.dtpFechaNacimiento.TabIndex = 17
      '
      'lblFechaNac
      '
      Me.lblFechaNac.AutoSize = True
      Me.lblFechaNac.Location = New System.Drawing.Point(391, 138)
      Me.lblFechaNac.Name = "lblFechaNac"
      Me.lblFechaNac.Size = New System.Drawing.Size(137, 13)
      Me.lblFechaNac.TabIndex = 16
      Me.lblFechaNac.Text = "Fecha Nac. / Inicio Activid."
      '
      'tbcContacto
      '
      Me.tbcContacto.Controls.Add(Me.tbpDatos)
      Me.tbcContacto.Controls.Add(Me.tbpDirecciones)
      Me.tbcContacto.Controls.Add(Me.tbpMapa)
      Me.tbcContacto.Controls.Add(Me.tbpOtros)
      Me.tbcContacto.Controls.Add(Me.tbpFoto)
      Me.tbcContacto.ItemSize = New System.Drawing.Size(80, 18)
      Me.tbcContacto.Location = New System.Drawing.Point(12, 82)
      Me.tbcContacto.Name = "tbcContacto"
      Me.tbcContacto.SelectedIndex = 0
      Me.tbcContacto.Size = New System.Drawing.Size(659, 361)
      Me.tbcContacto.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
      Me.tbcContacto.TabIndex = 1
      Me.tbcContacto.TabStop = False
      '
      'ContactosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(678, 490)
      Me.Controls.Add(Me.grbCliente)
      Me.Controls.Add(Me.tbcContacto)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ContactosDetalle"
      Me.Text = "Contacto"
      Me.Controls.SetChildIndex(Me.tbcContacto, 0)
      Me.Controls.SetChildIndex(Me.grbCliente, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.grbCliente.ResumeLayout(False)
      Me.grbCliente.PerformLayout()
      Me.tbpFoto.ResumeLayout(False)
      CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpOtros.ResumeLayout(False)
      Me.grbOtros.ResumeLayout(False)
      Me.grbOtros.PerformLayout()
      Me.tbpMapa.ResumeLayout(False)
      Me.grbUbicacion.ResumeLayout(False)
      Me.grbUbicacion.PerformLayout()
      Me.Panel1.ResumeLayout(False)
      CType(Me.tcbZoom, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpDirecciones.ResumeLayout(False)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.dgvDirecciones, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpDatos.ResumeLayout(False)
      Me.grbDatosPersonales.ResumeLayout(False)
      Me.grbDatosPersonales.PerformLayout()
      Me.tbcContacto.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents grbCliente As System.Windows.Forms.GroupBox
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents ofdArchivos As System.Windows.Forms.OpenFileDialog
   Friend WithEvents txtCodigoContacto As Eniac.Controles.TextBox
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents tlpInfo As System.Windows.Forms.ToolTip
   Friend WithEvents tbpFoto As System.Windows.Forms.TabPage
   Friend WithEvents pcbFoto As System.Windows.Forms.PictureBox
   Friend WithEvents btnLimpiarImagen As Eniac.Controles.Button
   Friend WithEvents btnBuscarImagen As Eniac.Controles.Button
   Friend WithEvents tbpOtros As System.Windows.Forms.TabPage
   Friend WithEvents grbOtros As System.Windows.Forms.GroupBox
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents tbpMapa As System.Windows.Forms.TabPage
   Friend WithEvents grbUbicacion As System.Windows.Forms.GroupBox
   Friend WithEvents lblGeoLocalizacionLat As Eniac.Controles.Label
   Friend WithEvents lblGeoLocalizacionLng As Eniac.Controles.Label
   Friend WithEvents txtGeoLocalizacionLat As Eniac.Controles.TextBox
   Friend WithEvents txtGeoLocalizacionLng As Eniac.Controles.TextBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents gmcMapa As GMap.NET.WindowsForms.GMapControl
   Friend WithEvents tcbZoom As System.Windows.Forms.TrackBar
   Friend WithEvents cmbTipoMapa As System.Windows.Forms.ComboBox
   Friend WithEvents btnGeolocalizar As System.Windows.Forms.Button
   Friend WithEvents tbpDirecciones As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents cmbTiposDirecciones As Eniac.Controles.ComboBox
   Friend WithEvents lblZonaGeografica As Eniac.Controles.Label
   Friend WithEvents Label6 As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents lnkLocalidadDir As Eniac.Controles.LinkLabel
   Friend WithEvents bscCodigoLocalidadDir As Eniac.Controles.Buscador
   Friend WithEvents bscNombreLocalidadDir As Eniac.Controles.Buscador
   Friend WithEvents txtProvinciaLocalidadDir As Eniac.Controles.TextBox
   Friend WithEvents txtDirecciones As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents btnRefreshDir As Eniac.Controles.Button
   Friend WithEvents dgvDirecciones As Eniac.Controles.DataGridView
   Friend WithEvents btnInsertarDir As Eniac.Controles.Button
   Friend WithEvents btnEliminarDir As Eniac.Controles.Button
   Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
   Friend WithEvents grbDatosPersonales As System.Windows.Forms.GroupBox
   Friend WithEvents lblProvinciaLocalidad As Eniac.Controles.Label
   Friend WithEvents lnkLocalidad As Eniac.Controles.LinkLabel
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents txtProvinciaLocalidad As Eniac.Controles.TextBox
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents cmbTipoDoc As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoDocumento As Eniac.Controles.Label
   Friend WithEvents lblID As Eniac.Controles.Label
   Friend WithEvents txtNroDoc As Eniac.Controles.TextBox
   Friend WithEvents txtTelefonos As Eniac.Controles.TextBox
   Friend WithEvents lblTelefonos As Eniac.Controles.Label
   Friend WithEvents txtPaginaWeb As Eniac.Controles.TextBox
   Friend WithEvents lblPaginaWeb As Eniac.Controles.Label
   Friend WithEvents txtCorreoElectronico As Eniac.Controles.TextBox
   Friend WithEvents lblCorreoElectronico As Eniac.Controles.Label
   Friend WithEvents txtCelular As Eniac.Controles.TextBox
   Friend WithEvents lblCelular As Eniac.Controles.Label
   Friend WithEvents dtpFechaAlta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAlta As Eniac.Controles.Label
   Friend WithEvents txtCUIT As Eniac.Controles.TextBox
   Friend WithEvents lblCUIT As Eniac.Controles.Label
   Friend WithEvents cmbCategoriaFiscal As Eniac.Controles.ComboBox
   Friend WithEvents lblCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents dtpFechaNacimiento As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaNac As Eniac.Controles.Label
   Friend WithEvents tbcContacto As System.Windows.Forms.TabControl
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents txtTelefonoDir As Eniac.Controles.TextBox
   Friend WithEvents txtCorreoDir As Eniac.Controles.TextBox
   Friend WithEvents txtCelularDir As Eniac.Controles.TextBox
   Friend WithEvents cmbTipoContacto As Eniac.Controles.ComboBox
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents chbPrivado As Eniac.Controles.CheckBox
   Friend WithEvents IdContacto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreAbrevTipoDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoDireccion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Telefono As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Celular As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CorreoElectronico As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
