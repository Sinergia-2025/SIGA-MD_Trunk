<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfDatosEmpresa
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.cmbOperacionCotizacionMoneda = New Eniac.Controles.ComboBox()
      Me.lblOrigenCotizacionMoneda = New Eniac.Controles.Label()
      Me.cmbOrigenCotizacionMoneda = New Eniac.Controles.ComboBox()
      Me.txtCantidadDePadronesARBA = New Eniac.Controles.TextBox()
      Me.lblCantidadDePadronesARBA = New Eniac.Controles.Label()
      Me.chbConsultarMultipleSucursal = New Eniac.Controles.CheckBox()
      Me.chbMostrarNombreFantasiaComprobantes = New Eniac.Controles.CheckBox()
      Me.chbVisualizarComprobanteVentaAsumeImpresion = New Eniac.Controles.CheckBox()
      Me.txtDescripcionAdicional = New Eniac.Controles.TextBox()
      Me.lblDescripcionAdicional = New Eniac.Controles.Label()
      Me.txtDireccionWebEmpresa = New Eniac.Controles.TextBox()
      Me.lblDireccionWebEmpresa = New Eniac.Controles.Label()
      Me.txtIngresosBrutos = New Eniac.Controles.TextBox()
      Me.lblIngresosBrutos = New Eniac.Controles.Label()
      Me.txtSueldosDomicilioEmpresa = New Eniac.Controles.TextBox()
      Me.lblSueldosDomicilioEmpresa = New Eniac.Controles.Label()
      Me.txtTipoDocProveedor = New Eniac.Controles.TextBox()
      Me.lblTipoDocumentoProveedor = New Eniac.Controles.Label()
      Me.txtTipoDocCliente = New Eniac.Controles.TextBox()
      Me.lblTipoDocumentoCliente = New Eniac.Controles.Label()
      Me.chbRetieneIIBB = New Eniac.Controles.CheckBox()
      Me.chbRetieneGanancias = New Eniac.Controles.CheckBox()
      Me.dtpFechaInicioActividades = New Eniac.Controles.DateTimePicker()
      Me.lblFechaInicioActividades = New Eniac.Controles.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.lblTamano = New Eniac.Controles.Label()
      Me.pcbFoto = New System.Windows.Forms.PictureBox()
      Me.btnLimpiarImagen = New Eniac.Controles.Button()
      Me.btnBuscarImagen = New Eniac.Controles.Button()
      Me.grbCorreoElectronico = New System.Windows.Forms.GroupBox()
      Me.lblCantidadMailsPorHora = New Eniac.Controles.Label()
      Me.lblCantidadMailsPorMinuto = New Eniac.Controles.Label()
      Me.txtCantidadMailsPorHora = New Eniac.Controles.TextBox()
      Me.txtCantidadMailsPorMinuto = New Eniac.Controles.TextBox()
      Me.chbMailRequiereSSL = New Eniac.Controles.CheckBox()
      Me.btnProbanrEnvioMail = New Eniac.Controles.Button()
      Me.chbMailRequiereAutenticacion = New Eniac.Controles.CheckBox()
      Me.txtMailPuertoSalida = New Eniac.Controles.TextBox()
      Me.lblMailServidor = New Eniac.Controles.Label()
      Me.txtMailDireccion = New Eniac.Controles.TextBox()
      Me.lblMailDireccion = New Eniac.Controles.Label()
      Me.txtMailPassword = New Eniac.Controles.TextBox()
      Me.lblMailPassword = New Eniac.Controles.Label()
      Me.txtMailUsuario = New Eniac.Controles.TextBox()
      Me.lblMailUsuario = New Eniac.Controles.Label()
      Me.txtMailServidor = New Eniac.Controles.TextBox()
      Me.ofdArchivos = New System.Windows.Forms.OpenFileDialog()
        Me.chbCopiaASiMismo = New Eniac.Controles.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCorreoElectronico.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbOperacionCotizacionMoneda
        '
        Me.cmbOperacionCotizacionMoneda.BindearPropiedadControl = Nothing
        Me.cmbOperacionCotizacionMoneda.BindearPropiedadEntidad = Nothing
        Me.cmbOperacionCotizacionMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperacionCotizacionMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperacionCotizacionMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOperacionCotizacionMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOperacionCotizacionMoneda.FormattingEnabled = True
        Me.cmbOperacionCotizacionMoneda.IsPK = False
        Me.cmbOperacionCotizacionMoneda.IsRequired = False
        Me.cmbOperacionCotizacionMoneda.Key = Nothing
        Me.cmbOperacionCotizacionMoneda.LabelAsoc = Me.lblOrigenCotizacionMoneda
        Me.cmbOperacionCotizacionMoneda.Location = New System.Drawing.Point(381, 389)
        Me.cmbOperacionCotizacionMoneda.Name = "cmbOperacionCotizacionMoneda"
        Me.cmbOperacionCotizacionMoneda.Size = New System.Drawing.Size(100, 21)
        Me.cmbOperacionCotizacionMoneda.TabIndex = 24
        Me.cmbOperacionCotizacionMoneda.Tag = ""
        '
        'lblOrigenCotizacionMoneda
        '
        Me.lblOrigenCotizacionMoneda.AutoSize = True
        Me.lblOrigenCotizacionMoneda.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblOrigenCotizacionMoneda.LabelAsoc = Nothing
        Me.lblOrigenCotizacionMoneda.Location = New System.Drawing.Point(4, 393)
        Me.lblOrigenCotizacionMoneda.Name = "lblOrigenCotizacionMoneda"
        Me.lblOrigenCotizacionMoneda.Size = New System.Drawing.Size(135, 13)
        Me.lblOrigenCotizacionMoneda.TabIndex = 22
        Me.lblOrigenCotizacionMoneda.Text = "Origen Cotización del Dolar"
        '
        'cmbOrigenCotizacionMoneda
        '
        Me.cmbOrigenCotizacionMoneda.BindearPropiedadControl = Nothing
        Me.cmbOrigenCotizacionMoneda.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenCotizacionMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenCotizacionMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenCotizacionMoneda.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenCotizacionMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenCotizacionMoneda.FormattingEnabled = True
        Me.cmbOrigenCotizacionMoneda.IsPK = False
        Me.cmbOrigenCotizacionMoneda.IsRequired = False
        Me.cmbOrigenCotizacionMoneda.Key = Nothing
        Me.cmbOrigenCotizacionMoneda.LabelAsoc = Me.lblOrigenCotizacionMoneda
        Me.cmbOrigenCotizacionMoneda.Location = New System.Drawing.Point(145, 389)
        Me.cmbOrigenCotizacionMoneda.Name = "cmbOrigenCotizacionMoneda"
        Me.cmbOrigenCotizacionMoneda.Size = New System.Drawing.Size(233, 21)
        Me.cmbOrigenCotizacionMoneda.TabIndex = 23
        Me.cmbOrigenCotizacionMoneda.Tag = ""
        '
        'txtCantidadDePadronesARBA
        '
        Me.txtCantidadDePadronesARBA.BindearPropiedadControl = Nothing
        Me.txtCantidadDePadronesARBA.BindearPropiedadEntidad = Nothing
        Me.txtCantidadDePadronesARBA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadDePadronesARBA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadDePadronesARBA.Formato = ""
        Me.txtCantidadDePadronesARBA.IsDecimal = False
        Me.txtCantidadDePadronesARBA.IsNumber = True
        Me.txtCantidadDePadronesARBA.IsPK = False
        Me.txtCantidadDePadronesARBA.IsRequired = False
        Me.txtCantidadDePadronesARBA.Key = ""
        Me.txtCantidadDePadronesARBA.LabelAsoc = Me.lblCantidadDePadronesARBA
        Me.txtCantidadDePadronesARBA.Location = New System.Drawing.Point(651, 68)
        Me.txtCantidadDePadronesARBA.MaxLength = 2
        Me.txtCantidadDePadronesARBA.Name = "txtCantidadDePadronesARBA"
        Me.txtCantidadDePadronesARBA.Size = New System.Drawing.Size(35, 20)
        Me.txtCantidadDePadronesARBA.TabIndex = 14
        Me.txtCantidadDePadronesARBA.Tag = "CANTIDADPADRONESARBA"
        Me.txtCantidadDePadronesARBA.Text = "3"
        Me.txtCantidadDePadronesARBA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCantidadDePadronesARBA
        '
        Me.lblCantidadDePadronesARBA.AutoSize = True
        Me.lblCantidadDePadronesARBA.LabelAsoc = Nothing
        Me.lblCantidadDePadronesARBA.Location = New System.Drawing.Point(691, 72)
        Me.lblCantidadDePadronesARBA.Name = "lblCantidadDePadronesARBA"
        Me.lblCantidadDePadronesARBA.Size = New System.Drawing.Size(192, 13)
        Me.lblCantidadDePadronesARBA.TabIndex = 15
        Me.lblCantidadDePadronesARBA.Text = "Cantidad de Padrones ARBA a guardar"
        '
        'chbConsultarMultipleSucursal
        '
        Me.chbConsultarMultipleSucursal.AutoSize = True
        Me.chbConsultarMultipleSucursal.BindearPropiedadControl = Nothing
        Me.chbConsultarMultipleSucursal.BindearPropiedadEntidad = Nothing
        Me.chbConsultarMultipleSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.chbConsultarMultipleSucursal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbConsultarMultipleSucursal.IsPK = False
        Me.chbConsultarMultipleSucursal.IsRequired = False
        Me.chbConsultarMultipleSucursal.Key = Nothing
        Me.chbConsultarMultipleSucursal.LabelAsoc = Nothing
        Me.chbConsultarMultipleSucursal.Location = New System.Drawing.Point(262, 368)
        Me.chbConsultarMultipleSucursal.Name = "chbConsultarMultipleSucursal"
        Me.chbConsultarMultipleSucursal.Size = New System.Drawing.Size(153, 17)
        Me.chbConsultarMultipleSucursal.TabIndex = 21
        Me.chbConsultarMultipleSucursal.Text = "Consultar Multiple Sucursal"
        Me.chbConsultarMultipleSucursal.UseVisualStyleBackColor = True
        '
        'chbMostrarNombreFantasiaComprobantes
        '
        Me.chbMostrarNombreFantasiaComprobantes.BindearPropiedadControl = Nothing
        Me.chbMostrarNombreFantasiaComprobantes.BindearPropiedadEntidad = Nothing
        Me.chbMostrarNombreFantasiaComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMostrarNombreFantasiaComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMostrarNombreFantasiaComprobantes.IsPK = False
        Me.chbMostrarNombreFantasiaComprobantes.IsRequired = False
        Me.chbMostrarNombreFantasiaComprobantes.Key = Nothing
        Me.chbMostrarNombreFantasiaComprobantes.LabelAsoc = Nothing
        Me.chbMostrarNombreFantasiaComprobantes.Location = New System.Drawing.Point(4, 366)
        Me.chbMostrarNombreFantasiaComprobantes.Name = "chbMostrarNombreFantasiaComprobantes"
        Me.chbMostrarNombreFantasiaComprobantes.Size = New System.Drawing.Size(256, 20)
        Me.chbMostrarNombreFantasiaComprobantes.TabIndex = 20
        Me.chbMostrarNombreFantasiaComprobantes.Tag = "MOSTRARNOMBREFANTASIAENCOMPROBANTES"
        Me.chbMostrarNombreFantasiaComprobantes.Text = "Mostrar Nombre Fantasía en Comprobantes"
        Me.chbMostrarNombreFantasiaComprobantes.UseVisualStyleBackColor = True
        '
        'chbVisualizarComprobanteVentaAsumeImpresion
        '
        Me.chbVisualizarComprobanteVentaAsumeImpresion.BindearPropiedadControl = Nothing
        Me.chbVisualizarComprobanteVentaAsumeImpresion.BindearPropiedadEntidad = Nothing
        Me.chbVisualizarComprobanteVentaAsumeImpresion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVisualizarComprobanteVentaAsumeImpresion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVisualizarComprobanteVentaAsumeImpresion.IsPK = False
        Me.chbVisualizarComprobanteVentaAsumeImpresion.IsRequired = False
        Me.chbVisualizarComprobanteVentaAsumeImpresion.Key = Nothing
        Me.chbVisualizarComprobanteVentaAsumeImpresion.LabelAsoc = Nothing
        Me.chbVisualizarComprobanteVentaAsumeImpresion.Location = New System.Drawing.Point(4, 345)
        Me.chbVisualizarComprobanteVentaAsumeImpresion.Name = "chbVisualizarComprobanteVentaAsumeImpresion"
        Me.chbVisualizarComprobanteVentaAsumeImpresion.Size = New System.Drawing.Size(271, 20)
        Me.chbVisualizarComprobanteVentaAsumeImpresion.TabIndex = 19
        Me.chbVisualizarComprobanteVentaAsumeImpresion.Tag = "VENTASVISUALIZARCOMPROBANTEASUMEIMPRESION"
        Me.chbVisualizarComprobanteVentaAsumeImpresion.Text = "Visualizar Comprobante de Venta Asume Impresion"
        Me.chbVisualizarComprobanteVentaAsumeImpresion.UseVisualStyleBackColor = True
        '
        'txtDescripcionAdicional
        '
        Me.txtDescripcionAdicional.BindearPropiedadControl = Nothing
        Me.txtDescripcionAdicional.BindearPropiedadEntidad = Nothing
        Me.txtDescripcionAdicional.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcionAdicional.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcionAdicional.Formato = ""
        Me.txtDescripcionAdicional.IsDecimal = False
        Me.txtDescripcionAdicional.IsNumber = False
        Me.txtDescripcionAdicional.IsPK = False
        Me.txtDescripcionAdicional.IsRequired = False
        Me.txtDescripcionAdicional.Key = ""
        Me.txtDescripcionAdicional.LabelAsoc = Me.lblDescripcionAdicional
        Me.txtDescripcionAdicional.Location = New System.Drawing.Point(4, 107)
        Me.txtDescripcionAdicional.MaxLength = 60
        Me.txtDescripcionAdicional.Name = "txtDescripcionAdicional"
        Me.txtDescripcionAdicional.Size = New System.Drawing.Size(355, 20)
        Me.txtDescripcionAdicional.TabIndex = 5
        Me.txtDescripcionAdicional.Tag = "DESCRIPCIONADICIONALEMPRESA"
        '
        'lblDescripcionAdicional
        '
        Me.lblDescripcionAdicional.AutoSize = True
        Me.lblDescripcionAdicional.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescripcionAdicional.LabelAsoc = Nothing
        Me.lblDescripcionAdicional.Location = New System.Drawing.Point(4, 91)
        Me.lblDescripcionAdicional.Name = "lblDescripcionAdicional"
        Me.lblDescripcionAdicional.Size = New System.Drawing.Size(109, 13)
        Me.lblDescripcionAdicional.TabIndex = 4
        Me.lblDescripcionAdicional.Text = "Descripcion Adicional"
        '
        'txtDireccionWebEmpresa
        '
        Me.txtDireccionWebEmpresa.BindearPropiedadControl = Nothing
        Me.txtDireccionWebEmpresa.BindearPropiedadEntidad = Nothing
        Me.txtDireccionWebEmpresa.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDireccionWebEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDireccionWebEmpresa.Formato = ""
        Me.txtDireccionWebEmpresa.IsDecimal = False
        Me.txtDireccionWebEmpresa.IsNumber = False
        Me.txtDireccionWebEmpresa.IsPK = False
        Me.txtDireccionWebEmpresa.IsRequired = False
        Me.txtDireccionWebEmpresa.Key = ""
        Me.txtDireccionWebEmpresa.LabelAsoc = Me.lblDireccionWebEmpresa
        Me.txtDireccionWebEmpresa.Location = New System.Drawing.Point(4, 68)
        Me.txtDireccionWebEmpresa.MaxLength = 100
        Me.txtDireccionWebEmpresa.Name = "txtDireccionWebEmpresa"
        Me.txtDireccionWebEmpresa.Size = New System.Drawing.Size(271, 20)
        Me.txtDireccionWebEmpresa.TabIndex = 3
        Me.txtDireccionWebEmpresa.Tag = "DIRECCIONWEBEMPRESA"
        '
        'lblDireccionWebEmpresa
        '
        Me.lblDireccionWebEmpresa.AutoSize = True
        Me.lblDireccionWebEmpresa.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDireccionWebEmpresa.LabelAsoc = Nothing
        Me.lblDireccionWebEmpresa.Location = New System.Drawing.Point(4, 52)
        Me.lblDireccionWebEmpresa.Name = "lblDireccionWebEmpresa"
        Me.lblDireccionWebEmpresa.Size = New System.Drawing.Size(125, 13)
        Me.lblDireccionWebEmpresa.TabIndex = 2
        Me.lblDireccionWebEmpresa.Text = "Direccion Web Empresa:"
        '
        'txtIngresosBrutos
        '
        Me.txtIngresosBrutos.BindearPropiedadControl = Nothing
        Me.txtIngresosBrutos.BindearPropiedadEntidad = Nothing
        Me.txtIngresosBrutos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIngresosBrutos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIngresosBrutos.Formato = ""
        Me.txtIngresosBrutos.IsDecimal = False
        Me.txtIngresosBrutos.IsNumber = False
        Me.txtIngresosBrutos.IsPK = False
        Me.txtIngresosBrutos.IsRequired = False
        Me.txtIngresosBrutos.Key = ""
        Me.txtIngresosBrutos.LabelAsoc = Me.lblIngresosBrutos
        Me.txtIngresosBrutos.Location = New System.Drawing.Point(115, 159)
        Me.txtIngresosBrutos.Name = "txtIngresosBrutos"
        Me.txtIngresosBrutos.Size = New System.Drawing.Size(115, 20)
        Me.txtIngresosBrutos.TabIndex = 9
        Me.txtIngresosBrutos.Tag = "INGRESOSBRUTOS"
        Me.txtIngresosBrutos.Text = "33000000006"
        '
        'lblIngresosBrutos
        '
        Me.lblIngresosBrutos.AutoSize = True
        Me.lblIngresosBrutos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblIngresosBrutos.LabelAsoc = Nothing
        Me.lblIngresosBrutos.Location = New System.Drawing.Point(4, 163)
        Me.lblIngresosBrutos.Name = "lblIngresosBrutos"
        Me.lblIngresosBrutos.Size = New System.Drawing.Size(80, 13)
        Me.lblIngresosBrutos.TabIndex = 8
        Me.lblIngresosBrutos.Text = "Ingresos Brutos"
        '
        'txtSueldosDomicilioEmpresa
        '
        Me.txtSueldosDomicilioEmpresa.BindearPropiedadControl = Nothing
        Me.txtSueldosDomicilioEmpresa.BindearPropiedadEntidad = Nothing
        Me.txtSueldosDomicilioEmpresa.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSueldosDomicilioEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSueldosDomicilioEmpresa.Formato = ""
        Me.txtSueldosDomicilioEmpresa.IsDecimal = False
        Me.txtSueldosDomicilioEmpresa.IsNumber = False
        Me.txtSueldosDomicilioEmpresa.IsPK = False
        Me.txtSueldosDomicilioEmpresa.IsRequired = False
        Me.txtSueldosDomicilioEmpresa.Key = ""
        Me.txtSueldosDomicilioEmpresa.LabelAsoc = Me.lblSueldosDomicilioEmpresa
        Me.txtSueldosDomicilioEmpresa.Location = New System.Drawing.Point(4, 29)
        Me.txtSueldosDomicilioEmpresa.MaxLength = 100
        Me.txtSueldosDomicilioEmpresa.Name = "txtSueldosDomicilioEmpresa"
        Me.txtSueldosDomicilioEmpresa.Size = New System.Drawing.Size(271, 20)
        Me.txtSueldosDomicilioEmpresa.TabIndex = 1
        Me.txtSueldosDomicilioEmpresa.Tag = "SUELDOS_DOMICILIO_EMPRESA"
        '
        'lblSueldosDomicilioEmpresa
        '
        Me.lblSueldosDomicilioEmpresa.AutoSize = True
        Me.lblSueldosDomicilioEmpresa.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSueldosDomicilioEmpresa.LabelAsoc = Nothing
        Me.lblSueldosDomicilioEmpresa.Location = New System.Drawing.Point(1, 13)
        Me.lblSueldosDomicilioEmpresa.Name = "lblSueldosDomicilioEmpresa"
        Me.lblSueldosDomicilioEmpresa.Size = New System.Drawing.Size(96, 13)
        Me.lblSueldosDomicilioEmpresa.TabIndex = 0
        Me.lblSueldosDomicilioEmpresa.Text = "Domicilio Empresa:"
        '
        'txtTipoDocProveedor
        '
        Me.txtTipoDocProveedor.BindearPropiedadControl = Nothing
        Me.txtTipoDocProveedor.BindearPropiedadEntidad = Nothing
        Me.txtTipoDocProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoDocProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoDocProveedor.Formato = ""
        Me.txtTipoDocProveedor.IsDecimal = False
        Me.txtTipoDocProveedor.IsNumber = False
        Me.txtTipoDocProveedor.IsPK = False
        Me.txtTipoDocProveedor.IsRequired = False
        Me.txtTipoDocProveedor.Key = ""
        Me.txtTipoDocProveedor.LabelAsoc = Me.lblTipoDocumentoProveedor
        Me.txtTipoDocProveedor.Location = New System.Drawing.Point(579, 94)
        Me.txtTipoDocProveedor.MaxLength = 5
        Me.txtTipoDocProveedor.Name = "txtTipoDocProveedor"
        Me.txtTipoDocProveedor.Size = New System.Drawing.Size(47, 20)
        Me.txtTipoDocProveedor.TabIndex = 17
        Me.txtTipoDocProveedor.Tag = "TIPODOCUMENTOPROVEEDOR"
        Me.txtTipoDocProveedor.Text = "CUIT"
        Me.txtTipoDocProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTipoDocumentoProveedor
        '
        Me.lblTipoDocumentoProveedor.AutoSize = True
        Me.lblTipoDocumentoProveedor.LabelAsoc = Nothing
        Me.lblTipoDocumentoProveedor.Location = New System.Drawing.Point(426, 98)
        Me.lblTipoDocumentoProveedor.Name = "lblTipoDocumentoProveedor"
        Me.lblTipoDocumentoProveedor.Size = New System.Drawing.Size(138, 13)
        Me.lblTipoDocumentoProveedor.TabIndex = 16
        Me.lblTipoDocumentoProveedor.Text = "Tipo Documento Proveedor"
        '
        'txtTipoDocCliente
        '
        Me.txtTipoDocCliente.BindearPropiedadControl = Nothing
        Me.txtTipoDocCliente.BindearPropiedadEntidad = Nothing
        Me.txtTipoDocCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoDocCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoDocCliente.Formato = ""
        Me.txtTipoDocCliente.IsDecimal = False
        Me.txtTipoDocCliente.IsNumber = False
        Me.txtTipoDocCliente.IsPK = False
        Me.txtTipoDocCliente.IsRequired = False
        Me.txtTipoDocCliente.Key = ""
        Me.txtTipoDocCliente.LabelAsoc = Me.lblTipoDocumentoCliente
        Me.txtTipoDocCliente.Location = New System.Drawing.Point(579, 68)
        Me.txtTipoDocCliente.MaxLength = 5
        Me.txtTipoDocCliente.Name = "txtTipoDocCliente"
        Me.txtTipoDocCliente.Size = New System.Drawing.Size(47, 20)
        Me.txtTipoDocCliente.TabIndex = 13
        Me.txtTipoDocCliente.Tag = "TIPODOCUMENTOCLIENTE"
        Me.txtTipoDocCliente.Text = "COD"
        Me.txtTipoDocCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTipoDocumentoCliente
        '
        Me.lblTipoDocumentoCliente.AutoSize = True
        Me.lblTipoDocumentoCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipoDocumentoCliente.LabelAsoc = Nothing
        Me.lblTipoDocumentoCliente.Location = New System.Drawing.Point(426, 72)
        Me.lblTipoDocumentoCliente.Name = "lblTipoDocumentoCliente"
        Me.lblTipoDocumentoCliente.Size = New System.Drawing.Size(121, 13)
        Me.lblTipoDocumentoCliente.TabIndex = 12
        Me.lblTipoDocumentoCliente.Text = "Tipo Documento Cliente"
        '
        'chbRetieneIIBB
        '
        Me.chbRetieneIIBB.AutoSize = True
        Me.chbRetieneIIBB.BindearPropiedadControl = Nothing
        Me.chbRetieneIIBB.BindearPropiedadEntidad = Nothing
        Me.chbRetieneIIBB.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRetieneIIBB.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRetieneIIBB.IsPK = False
        Me.chbRetieneIIBB.IsRequired = False
        Me.chbRetieneIIBB.Key = Nothing
        Me.chbRetieneIIBB.LabelAsoc = Nothing
        Me.chbRetieneIIBB.Location = New System.Drawing.Point(655, 31)
        Me.chbRetieneIIBB.Name = "chbRetieneIIBB"
        Me.chbRetieneIIBB.Size = New System.Drawing.Size(236, 17)
        Me.chbRetieneIIBB.TabIndex = 11
        Me.chbRetieneIIBB.Tag = "RETIENEIIBB"
        Me.chbRetieneIIBB.Text = "Es agente de percepción de Ingresos Brutos"
        Me.chbRetieneIIBB.UseVisualStyleBackColor = True
        '
        'chbRetieneGanancias
        '
        Me.chbRetieneGanancias.AutoSize = True
        Me.chbRetieneGanancias.BindearPropiedadControl = Nothing
        Me.chbRetieneGanancias.BindearPropiedadEntidad = Nothing
        Me.chbRetieneGanancias.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRetieneGanancias.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRetieneGanancias.IsPK = False
        Me.chbRetieneGanancias.IsRequired = False
        Me.chbRetieneGanancias.Key = Nothing
        Me.chbRetieneGanancias.LabelAsoc = Nothing
        Me.chbRetieneGanancias.Location = New System.Drawing.Point(364, 31)
        Me.chbRetieneGanancias.Name = "chbRetieneGanancias"
        Me.chbRetieneGanancias.Size = New System.Drawing.Size(260, 17)
        Me.chbRetieneGanancias.TabIndex = 10
        Me.chbRetieneGanancias.Tag = "RETIENEGANANCIAS"
        Me.chbRetieneGanancias.Text = "Es agente de retención de Ganancias, IVA o IIBB"
        Me.chbRetieneGanancias.UseVisualStyleBackColor = True
        '
        'dtpFechaInicioActividades
        '
        Me.dtpFechaInicioActividades.BindearPropiedadControl = Nothing
        Me.dtpFechaInicioActividades.BindearPropiedadEntidad = Nothing
        Me.dtpFechaInicioActividades.Checked = False
        Me.dtpFechaInicioActividades.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaInicioActividades.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaInicioActividades.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaInicioActividades.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaInicioActividades.IsPK = False
        Me.dtpFechaInicioActividades.IsRequired = False
        Me.dtpFechaInicioActividades.Key = ""
        Me.dtpFechaInicioActividades.LabelAsoc = Me.lblFechaInicioActividades
        Me.dtpFechaInicioActividades.Location = New System.Drawing.Point(115, 133)
        Me.dtpFechaInicioActividades.Name = "dtpFechaInicioActividades"
        Me.dtpFechaInicioActividades.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaInicioActividades.TabIndex = 7
        Me.dtpFechaInicioActividades.Tag = "FECHAINICIOACTIVIDADES"
        '
        'lblFechaInicioActividades
        '
        Me.lblFechaInicioActividades.AutoSize = True
        Me.lblFechaInicioActividades.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFechaInicioActividades.LabelAsoc = Nothing
        Me.lblFechaInicioActividades.Location = New System.Drawing.Point(2, 137)
        Me.lblFechaInicioActividades.Name = "lblFechaInicioActividades"
        Me.lblFechaInicioActividades.Size = New System.Drawing.Size(105, 13)
        Me.lblFechaInicioActividades.TabIndex = 6
        Me.lblFechaInicioActividades.Text = "Inicio de Actividades"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTamano)
        Me.GroupBox1.Controls.Add(Me.pcbFoto)
        Me.GroupBox1.Controls.Add(Me.btnLimpiarImagen)
        Me.GroupBox1.Controls.Add(Me.btnBuscarImagen)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 185)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 154)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Logo Empresa"
        '
        'lblTamano
        '
        Me.lblTamano.AutoSize = True
        Me.lblTamano.LabelAsoc = Nothing
        Me.lblTamano.Location = New System.Drawing.Point(20, 126)
        Me.lblTamano.Name = "lblTamano"
        Me.lblTamano.Size = New System.Drawing.Size(0, 13)
        Me.lblTamano.TabIndex = 2
        '
        'pcbFoto
        '
        Me.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pcbFoto.Location = New System.Drawing.Point(179, 22)
        Me.pcbFoto.Name = "pcbFoto"
        Me.pcbFoto.Size = New System.Drawing.Size(171, 121)
        Me.pcbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbFoto.TabIndex = 9
        Me.pcbFoto.TabStop = False
        Me.pcbFoto.Tag = "LOGOEMPRESA"
        '
        'btnLimpiarImagen
        '
        Me.btnLimpiarImagen.Location = New System.Drawing.Point(30, 84)
        Me.btnLimpiarImagen.Name = "btnLimpiarImagen"
        Me.btnLimpiarImagen.Size = New System.Drawing.Size(111, 33)
        Me.btnLimpiarImagen.TabIndex = 1
        Me.btnLimpiarImagen.Text = "&Limpiar imagen"
        Me.btnLimpiarImagen.UseVisualStyleBackColor = True
        '
        'btnBuscarImagen
        '
        Me.btnBuscarImagen.Location = New System.Drawing.Point(23, 28)
        Me.btnBuscarImagen.Name = "btnBuscarImagen"
        Me.btnBuscarImagen.Size = New System.Drawing.Size(124, 33)
        Me.btnBuscarImagen.TabIndex = 0
        Me.btnBuscarImagen.Text = "&Buscar imagen"
        Me.btnBuscarImagen.UseVisualStyleBackColor = True
        '
        'grbCorreoElectronico
        '
        Me.grbCorreoElectronico.Controls.Add(Me.chbCopiaASiMismo)
        Me.grbCorreoElectronico.Controls.Add(Me.lblCantidadMailsPorHora)
        Me.grbCorreoElectronico.Controls.Add(Me.lblCantidadMailsPorMinuto)
        Me.grbCorreoElectronico.Controls.Add(Me.txtCantidadMailsPorHora)
        Me.grbCorreoElectronico.Controls.Add(Me.txtCantidadMailsPorMinuto)
        Me.grbCorreoElectronico.Controls.Add(Me.chbMailRequiereSSL)
        Me.grbCorreoElectronico.Controls.Add(Me.btnProbanrEnvioMail)
        Me.grbCorreoElectronico.Controls.Add(Me.chbMailRequiereAutenticacion)
        Me.grbCorreoElectronico.Controls.Add(Me.txtMailPuertoSalida)
        Me.grbCorreoElectronico.Controls.Add(Me.txtMailDireccion)
        Me.grbCorreoElectronico.Controls.Add(Me.lblMailDireccion)
        Me.grbCorreoElectronico.Controls.Add(Me.txtMailPassword)
        Me.grbCorreoElectronico.Controls.Add(Me.lblMailPassword)
        Me.grbCorreoElectronico.Controls.Add(Me.txtMailUsuario)
        Me.grbCorreoElectronico.Controls.Add(Me.lblMailUsuario)
        Me.grbCorreoElectronico.Controls.Add(Me.txtMailServidor)
        Me.grbCorreoElectronico.Controls.Add(Me.lblMailServidor)
        Me.grbCorreoElectronico.Location = New System.Drawing.Point(429, 126)
        Me.grbCorreoElectronico.Name = "grbCorreoElectronico"
        Me.grbCorreoElectronico.Size = New System.Drawing.Size(360, 246)
        Me.grbCorreoElectronico.TabIndex = 18
        Me.grbCorreoElectronico.TabStop = False
        Me.grbCorreoElectronico.Text = "Correo Electronico"
        '
        'lblCantidadMailsPorHora
        '
        Me.lblCantidadMailsPorHora.AutoSize = True
        Me.lblCantidadMailsPorHora.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadMailsPorHora.LabelAsoc = Nothing
        Me.lblCantidadMailsPorHora.Location = New System.Drawing.Point(14, 216)
        Me.lblCantidadMailsPorHora.Name = "lblCantidadMailsPorHora"
        Me.lblCantidadMailsPorHora.Size = New System.Drawing.Size(115, 13)
        Me.lblCantidadMailsPorHora.TabIndex = 14
        Me.lblCantidadMailsPorHora.Text = "Cant. Correos por Hora"
        '
        'lblCantidadMailsPorMinuto
        '
        Me.lblCantidadMailsPorMinuto.AutoSize = True
        Me.lblCantidadMailsPorMinuto.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCantidadMailsPorMinuto.LabelAsoc = Nothing
        Me.lblCantidadMailsPorMinuto.Location = New System.Drawing.Point(14, 190)
        Me.lblCantidadMailsPorMinuto.Name = "lblCantidadMailsPorMinuto"
        Me.lblCantidadMailsPorMinuto.Size = New System.Drawing.Size(124, 13)
        Me.lblCantidadMailsPorMinuto.TabIndex = 12
        Me.lblCantidadMailsPorMinuto.Text = "Cant. Correos por Minuto"
        '
        'txtCantidadMailsPorHora
        '
        Me.txtCantidadMailsPorHora.BindearPropiedadControl = Nothing
        Me.txtCantidadMailsPorHora.BindearPropiedadEntidad = Nothing
        Me.txtCantidadMailsPorHora.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadMailsPorHora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadMailsPorHora.Formato = ""
        Me.txtCantidadMailsPorHora.IsDecimal = False
        Me.txtCantidadMailsPorHora.IsNumber = True
        Me.txtCantidadMailsPorHora.IsPK = False
        Me.txtCantidadMailsPorHora.IsRequired = False
        Me.txtCantidadMailsPorHora.Key = ""
        Me.txtCantidadMailsPorHora.LabelAsoc = Me.lblCantidadMailsPorHora
        Me.txtCantidadMailsPorHora.Location = New System.Drawing.Point(144, 212)
        Me.txtCantidadMailsPorHora.MaxLength = 4
        Me.txtCantidadMailsPorHora.Name = "txtCantidadMailsPorHora"
        Me.txtCantidadMailsPorHora.Size = New System.Drawing.Size(62, 20)
        Me.txtCantidadMailsPorHora.TabIndex = 15
        Me.txtCantidadMailsPorHora.Tag = "CANTEMAILSPORHORA"
        Me.txtCantidadMailsPorHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantidadMailsPorMinuto
        '
        Me.txtCantidadMailsPorMinuto.BindearPropiedadControl = Nothing
        Me.txtCantidadMailsPorMinuto.BindearPropiedadEntidad = Nothing
        Me.txtCantidadMailsPorMinuto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadMailsPorMinuto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadMailsPorMinuto.Formato = ""
        Me.txtCantidadMailsPorMinuto.IsDecimal = False
        Me.txtCantidadMailsPorMinuto.IsNumber = True
        Me.txtCantidadMailsPorMinuto.IsPK = False
        Me.txtCantidadMailsPorMinuto.IsRequired = False
        Me.txtCantidadMailsPorMinuto.Key = ""
        Me.txtCantidadMailsPorMinuto.LabelAsoc = Me.lblCantidadMailsPorMinuto
        Me.txtCantidadMailsPorMinuto.Location = New System.Drawing.Point(144, 186)
        Me.txtCantidadMailsPorMinuto.MaxLength = 3
        Me.txtCantidadMailsPorMinuto.Name = "txtCantidadMailsPorMinuto"
        Me.txtCantidadMailsPorMinuto.Size = New System.Drawing.Size(62, 20)
        Me.txtCantidadMailsPorMinuto.TabIndex = 13
        Me.txtCantidadMailsPorMinuto.Tag = "CANTEMAILSPORMINUTO"
        Me.txtCantidadMailsPorMinuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbMailRequiereSSL
        '
        Me.chbMailRequiereSSL.AutoSize = True
        Me.chbMailRequiereSSL.BindearPropiedadControl = Nothing
        Me.chbMailRequiereSSL.BindearPropiedadEntidad = Nothing
        Me.chbMailRequiereSSL.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMailRequiereSSL.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMailRequiereSSL.IsPK = False
        Me.chbMailRequiereSSL.IsRequired = False
        Me.chbMailRequiereSSL.Key = Nothing
        Me.chbMailRequiereSSL.LabelAsoc = Nothing
        Me.chbMailRequiereSSL.Location = New System.Drawing.Point(118, 122)
        Me.chbMailRequiereSSL.Name = "chbMailRequiereSSL"
        Me.chbMailRequiereSSL.Size = New System.Drawing.Size(200, 17)
        Me.chbMailRequiereSSL.TabIndex = 9
        Me.chbMailRequiereSSL.Tag = "MAILREQUIERESSL"
        Me.chbMailRequiereSSL.Text = "Requiere una conexión segura (SSL)"
        Me.chbMailRequiereSSL.UseVisualStyleBackColor = True
        '
        'btnProbanrEnvioMail
        '
        Me.btnProbanrEnvioMail.Location = New System.Drawing.Point(218, 196)
        Me.btnProbanrEnvioMail.Name = "btnProbanrEnvioMail"
        Me.btnProbanrEnvioMail.Size = New System.Drawing.Size(121, 36)
        Me.btnProbanrEnvioMail.TabIndex = 16
        Me.btnProbanrEnvioMail.Text = "Guardar y Probar Configuración"
        Me.btnProbanrEnvioMail.UseVisualStyleBackColor = True
        '
        'chbMailRequiereAutenticacion
        '
        Me.chbMailRequiereAutenticacion.AutoSize = True
        Me.chbMailRequiereAutenticacion.BindearPropiedadControl = Nothing
        Me.chbMailRequiereAutenticacion.BindearPropiedadEntidad = Nothing
        Me.chbMailRequiereAutenticacion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMailRequiereAutenticacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMailRequiereAutenticacion.IsPK = False
        Me.chbMailRequiereAutenticacion.IsRequired = False
        Me.chbMailRequiereAutenticacion.Key = Nothing
        Me.chbMailRequiereAutenticacion.LabelAsoc = Nothing
        Me.chbMailRequiereAutenticacion.Location = New System.Drawing.Point(118, 145)
        Me.chbMailRequiereAutenticacion.Name = "chbMailRequiereAutenticacion"
        Me.chbMailRequiereAutenticacion.Size = New System.Drawing.Size(190, 17)
        Me.chbMailRequiereAutenticacion.TabIndex = 10
        Me.chbMailRequiereAutenticacion.Tag = "MAILREQUIEREAUTENTICACION"
        Me.chbMailRequiereAutenticacion.Text = "El Servidor Requiere autenticación"
        Me.chbMailRequiereAutenticacion.UseVisualStyleBackColor = True
        '
        'txtMailPuertoSalida
        '
        Me.txtMailPuertoSalida.BindearPropiedadControl = Nothing
        Me.txtMailPuertoSalida.BindearPropiedadEntidad = Nothing
        Me.txtMailPuertoSalida.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMailPuertoSalida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMailPuertoSalida.Formato = ""
        Me.txtMailPuertoSalida.IsDecimal = False
        Me.txtMailPuertoSalida.IsNumber = True
        Me.txtMailPuertoSalida.IsPK = False
        Me.txtMailPuertoSalida.IsRequired = False
        Me.txtMailPuertoSalida.Key = ""
        Me.txtMailPuertoSalida.LabelAsoc = Me.lblMailServidor
        Me.txtMailPuertoSalida.Location = New System.Drawing.Point(309, 19)
        Me.txtMailPuertoSalida.MaxLength = 5
        Me.txtMailPuertoSalida.Name = "txtMailPuertoSalida"
        Me.txtMailPuertoSalida.Size = New System.Drawing.Size(30, 20)
        Me.txtMailPuertoSalida.TabIndex = 2
        Me.txtMailPuertoSalida.Tag = "MAILPUERTOSALIDA"
        Me.txtMailPuertoSalida.Text = "25"
        '
        'lblMailServidor
        '
        Me.lblMailServidor.AutoSize = True
        Me.lblMailServidor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMailServidor.LabelAsoc = Nothing
        Me.lblMailServidor.Location = New System.Drawing.Point(14, 23)
        Me.lblMailServidor.Name = "lblMailServidor"
        Me.lblMailServidor.Size = New System.Drawing.Size(79, 13)
        Me.lblMailServidor.TabIndex = 0
        Me.lblMailServidor.Text = "Servidor SMTP"
        '
        'txtMailDireccion
        '
        Me.txtMailDireccion.BindearPropiedadControl = Nothing
        Me.txtMailDireccion.BindearPropiedadEntidad = Nothing
        Me.txtMailDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMailDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMailDireccion.Formato = ""
        Me.txtMailDireccion.IsDecimal = False
        Me.txtMailDireccion.IsNumber = False
        Me.txtMailDireccion.IsPK = False
        Me.txtMailDireccion.IsRequired = False
        Me.txtMailDireccion.Key = ""
        Me.txtMailDireccion.LabelAsoc = Me.lblMailDireccion
        Me.txtMailDireccion.Location = New System.Drawing.Point(118, 46)
        Me.txtMailDireccion.MaxLength = 80
        Me.txtMailDireccion.Name = "txtMailDireccion"
        Me.txtMailDireccion.Size = New System.Drawing.Size(220, 20)
        Me.txtMailDireccion.TabIndex = 4
        Me.txtMailDireccion.Tag = "MAILDIRECCION"
        '
        'lblMailDireccion
        '
        Me.lblMailDireccion.AutoSize = True
        Me.lblMailDireccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMailDireccion.LabelAsoc = Nothing
        Me.lblMailDireccion.Location = New System.Drawing.Point(14, 50)
        Me.lblMailDireccion.Name = "lblMailDireccion"
        Me.lblMailDireccion.Size = New System.Drawing.Size(52, 13)
        Me.lblMailDireccion.TabIndex = 3
        Me.lblMailDireccion.Text = "Dirección"
        '
        'txtMailPassword
        '
        Me.txtMailPassword.BindearPropiedadControl = Nothing
        Me.txtMailPassword.BindearPropiedadEntidad = Nothing
        Me.txtMailPassword.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMailPassword.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMailPassword.Formato = ""
        Me.txtMailPassword.IsDecimal = False
        Me.txtMailPassword.IsNumber = False
        Me.txtMailPassword.IsPK = False
        Me.txtMailPassword.IsRequired = False
        Me.txtMailPassword.Key = ""
        Me.txtMailPassword.LabelAsoc = Me.lblMailPassword
        Me.txtMailPassword.Location = New System.Drawing.Point(118, 96)
        Me.txtMailPassword.MaxLength = 80
        Me.txtMailPassword.Name = "txtMailPassword"
        Me.txtMailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMailPassword.Size = New System.Drawing.Size(220, 20)
        Me.txtMailPassword.TabIndex = 8
        Me.txtMailPassword.Tag = "MAILPASSWORD"
        '
        'lblMailPassword
        '
        Me.lblMailPassword.AutoSize = True
        Me.lblMailPassword.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMailPassword.LabelAsoc = Nothing
        Me.lblMailPassword.Location = New System.Drawing.Point(14, 100)
        Me.lblMailPassword.Name = "lblMailPassword"
        Me.lblMailPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblMailPassword.TabIndex = 7
        Me.lblMailPassword.Text = "Password"
        '
        'txtMailUsuario
        '
        Me.txtMailUsuario.BindearPropiedadControl = Nothing
        Me.txtMailUsuario.BindearPropiedadEntidad = Nothing
        Me.txtMailUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMailUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMailUsuario.Formato = ""
        Me.txtMailUsuario.IsDecimal = False
        Me.txtMailUsuario.IsNumber = False
        Me.txtMailUsuario.IsPK = False
        Me.txtMailUsuario.IsRequired = False
        Me.txtMailUsuario.Key = ""
        Me.txtMailUsuario.LabelAsoc = Me.lblMailUsuario
        Me.txtMailUsuario.Location = New System.Drawing.Point(118, 70)
        Me.txtMailUsuario.MaxLength = 80
        Me.txtMailUsuario.Name = "txtMailUsuario"
        Me.txtMailUsuario.Size = New System.Drawing.Size(220, 20)
        Me.txtMailUsuario.TabIndex = 6
        Me.txtMailUsuario.Tag = "MAILUSUARIO"
        '
        'lblMailUsuario
        '
        Me.lblMailUsuario.AutoSize = True
        Me.lblMailUsuario.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMailUsuario.LabelAsoc = Nothing
        Me.lblMailUsuario.Location = New System.Drawing.Point(14, 74)
        Me.lblMailUsuario.Name = "lblMailUsuario"
        Me.lblMailUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblMailUsuario.TabIndex = 5
        Me.lblMailUsuario.Text = "Usuario"
        '
        'txtMailServidor
        '
        Me.txtMailServidor.BindearPropiedadControl = Nothing
        Me.txtMailServidor.BindearPropiedadEntidad = Nothing
        Me.txtMailServidor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMailServidor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMailServidor.Formato = ""
        Me.txtMailServidor.IsDecimal = False
        Me.txtMailServidor.IsNumber = False
        Me.txtMailServidor.IsPK = False
        Me.txtMailServidor.IsRequired = False
        Me.txtMailServidor.Key = ""
        Me.txtMailServidor.LabelAsoc = Me.lblMailServidor
        Me.txtMailServidor.Location = New System.Drawing.Point(118, 19)
        Me.txtMailServidor.MaxLength = 80
        Me.txtMailServidor.Name = "txtMailServidor"
        Me.txtMailServidor.Size = New System.Drawing.Size(185, 20)
        Me.txtMailServidor.TabIndex = 1
        Me.txtMailServidor.Tag = "MAILSERVIDOR"
        '
        'ofdArchivos
        '
        Me.ofdArchivos.Filter = "jpg files|*.jpg"
        '
        'chbCopiaASiMismo
        '
        Me.chbCopiaASiMismo.AutoSize = True
        Me.chbCopiaASiMismo.BindearPropiedadControl = Nothing
        Me.chbCopiaASiMismo.BindearPropiedadEntidad = Nothing
        Me.chbCopiaASiMismo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCopiaASiMismo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCopiaASiMismo.IsPK = False
        Me.chbCopiaASiMismo.IsRequired = False
        Me.chbCopiaASiMismo.Key = Nothing
        Me.chbCopiaASiMismo.LabelAsoc = Nothing
        Me.chbCopiaASiMismo.Location = New System.Drawing.Point(118, 166)
        Me.chbCopiaASiMismo.Name = "chbCopiaASiMismo"
        Me.chbCopiaASiMismo.Size = New System.Drawing.Size(137, 17)
        Me.chbCopiaASiMismo.TabIndex = 11
        Me.chbCopiaASiMismo.Text = "Enviar Copia a si mismo"
        Me.chbCopiaASiMismo.UseVisualStyleBackColor = True
        '
        'ucConfDatosEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbOperacionCotizacionMoneda)
        Me.Controls.Add(Me.lblOrigenCotizacionMoneda)
        Me.Controls.Add(Me.cmbOrigenCotizacionMoneda)
        Me.Controls.Add(Me.txtCantidadDePadronesARBA)
        Me.Controls.Add(Me.lblCantidadDePadronesARBA)
        Me.Controls.Add(Me.chbConsultarMultipleSucursal)
        Me.Controls.Add(Me.chbMostrarNombreFantasiaComprobantes)
        Me.Controls.Add(Me.chbVisualizarComprobanteVentaAsumeImpresion)
        Me.Controls.Add(Me.txtDescripcionAdicional)
        Me.Controls.Add(Me.txtDireccionWebEmpresa)
        Me.Controls.Add(Me.txtIngresosBrutos)
        Me.Controls.Add(Me.txtSueldosDomicilioEmpresa)
        Me.Controls.Add(Me.txtTipoDocProveedor)
        Me.Controls.Add(Me.txtTipoDocCliente)
        Me.Controls.Add(Me.lblDescripcionAdicional)
        Me.Controls.Add(Me.chbRetieneIIBB)
        Me.Controls.Add(Me.chbRetieneGanancias)
        Me.Controls.Add(Me.lblDireccionWebEmpresa)
        Me.Controls.Add(Me.dtpFechaInicioActividades)
        Me.Controls.Add(Me.lblFechaInicioActividades)
        Me.Controls.Add(Me.lblIngresosBrutos)
        Me.Controls.Add(Me.lblSueldosDomicilioEmpresa)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbCorreoElectronico)
        Me.Controls.Add(Me.lblTipoDocumentoProveedor)
        Me.Controls.Add(Me.lblTipoDocumentoCliente)
        Me.Name = "ucConfDatosEmpresa"
        Me.Size = New System.Drawing.Size(900, 417)
        Me.Controls.SetChildIndex(Me.lblTipoDocumentoCliente, 0)
        Me.Controls.SetChildIndex(Me.lblTipoDocumentoProveedor, 0)
        Me.Controls.SetChildIndex(Me.grbCorreoElectronico, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblSueldosDomicilioEmpresa, 0)
        Me.Controls.SetChildIndex(Me.lblIngresosBrutos, 0)
        Me.Controls.SetChildIndex(Me.lblFechaInicioActividades, 0)
        Me.Controls.SetChildIndex(Me.dtpFechaInicioActividades, 0)
        Me.Controls.SetChildIndex(Me.lblDireccionWebEmpresa, 0)
        Me.Controls.SetChildIndex(Me.chbRetieneGanancias, 0)
        Me.Controls.SetChildIndex(Me.chbRetieneIIBB, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcionAdicional, 0)
        Me.Controls.SetChildIndex(Me.txtTipoDocCliente, 0)
        Me.Controls.SetChildIndex(Me.txtTipoDocProveedor, 0)
        Me.Controls.SetChildIndex(Me.txtSueldosDomicilioEmpresa, 0)
        Me.Controls.SetChildIndex(Me.txtIngresosBrutos, 0)
        Me.Controls.SetChildIndex(Me.txtDireccionWebEmpresa, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcionAdicional, 0)
        Me.Controls.SetChildIndex(Me.chbVisualizarComprobanteVentaAsumeImpresion, 0)
        Me.Controls.SetChildIndex(Me.chbMostrarNombreFantasiaComprobantes, 0)
        Me.Controls.SetChildIndex(Me.chbConsultarMultipleSucursal, 0)
        Me.Controls.SetChildIndex(Me.lblCantidadDePadronesARBA, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadDePadronesARBA, 0)
        Me.Controls.SetChildIndex(Me.cmbOrigenCotizacionMoneda, 0)
        Me.Controls.SetChildIndex(Me.lblOrigenCotizacionMoneda, 0)
        Me.Controls.SetChildIndex(Me.cmbOperacionCotizacionMoneda, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCorreoElectronico.ResumeLayout(False)
        Me.grbCorreoElectronico.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbOperacionCotizacionMoneda As Controles.ComboBox
   Friend WithEvents lblOrigenCotizacionMoneda As Controles.Label
   Friend WithEvents cmbOrigenCotizacionMoneda As Controles.ComboBox
   Friend WithEvents txtCantidadDePadronesARBA As Controles.TextBox
   Friend WithEvents lblCantidadDePadronesARBA As Controles.Label
   Friend WithEvents chbConsultarMultipleSucursal As Controles.CheckBox
   Friend WithEvents chbMostrarNombreFantasiaComprobantes As Controles.CheckBox
   Friend WithEvents chbVisualizarComprobanteVentaAsumeImpresion As Controles.CheckBox
   Friend WithEvents txtDescripcionAdicional As Controles.TextBox
   Friend WithEvents lblDescripcionAdicional As Controles.Label
   Friend WithEvents txtDireccionWebEmpresa As Controles.TextBox
   Friend WithEvents lblDireccionWebEmpresa As Controles.Label
   Friend WithEvents txtIngresosBrutos As Controles.TextBox
   Friend WithEvents lblIngresosBrutos As Controles.Label
   Friend WithEvents txtSueldosDomicilioEmpresa As Controles.TextBox
   Friend WithEvents lblSueldosDomicilioEmpresa As Controles.Label
   Friend WithEvents txtTipoDocProveedor As Controles.TextBox
   Friend WithEvents lblTipoDocumentoProveedor As Controles.Label
   Friend WithEvents txtTipoDocCliente As Controles.TextBox
   Friend WithEvents lblTipoDocumentoCliente As Controles.Label
   Friend WithEvents chbRetieneIIBB As Controles.CheckBox
   Friend WithEvents chbRetieneGanancias As Controles.CheckBox
   Friend WithEvents dtpFechaInicioActividades As Controles.DateTimePicker
   Friend WithEvents lblFechaInicioActividades As Controles.Label
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents lblTamano As Controles.Label
   Friend WithEvents pcbFoto As PictureBox
   Friend WithEvents btnLimpiarImagen As Controles.Button
   Friend WithEvents btnBuscarImagen As Controles.Button
   Friend WithEvents grbCorreoElectronico As GroupBox
   Friend WithEvents lblCantidadMailsPorHora As Controles.Label
   Friend WithEvents lblCantidadMailsPorMinuto As Controles.Label
   Friend WithEvents txtCantidadMailsPorHora As Controles.TextBox
   Friend WithEvents txtCantidadMailsPorMinuto As Controles.TextBox
   Friend WithEvents chbMailRequiereSSL As Controles.CheckBox
   Friend WithEvents btnProbanrEnvioMail As Controles.Button
   Friend WithEvents chbMailRequiereAutenticacion As Controles.CheckBox
   Friend WithEvents txtMailPuertoSalida As Controles.TextBox
   Friend WithEvents lblMailServidor As Controles.Label
   Friend WithEvents txtMailDireccion As Controles.TextBox
   Friend WithEvents lblMailDireccion As Controles.Label
   Friend WithEvents txtMailPassword As Controles.TextBox
   Friend WithEvents lblMailPassword As Controles.Label
   Friend WithEvents txtMailUsuario As Controles.TextBox
   Friend WithEvents lblMailUsuario As Controles.Label
   Friend WithEvents txtMailServidor As Controles.TextBox
   Friend WithEvents ofdArchivos As OpenFileDialog
    Friend WithEvents chbCopiaASiMismo As Controles.CheckBox
End Class
