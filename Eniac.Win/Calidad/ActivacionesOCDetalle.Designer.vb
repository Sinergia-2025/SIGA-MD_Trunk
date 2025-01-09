<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ActivacionesOCDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
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

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Cabecera", -1)
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
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.lblNombreTipoCliente = New Eniac.Controles.Label()
      Me.txtContacto = New Eniac.Controles.TextBox()
      Me.lblIdTipoCliente = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.dtpActivacion = New Eniac.Controles.DateTimePicker()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtComprobante = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.lblItem = New Eniac.Controles.Label()
      Me.txtItem = New Eniac.Controles.TextBox()
      Me.grbObservaciones = New System.Windows.Forms.GroupBox()
      Me.btnRefreshObservaciones = New System.Windows.Forms.Button()
      Me.cmbObservaciones = New Eniac.Controles.ComboBox()
      Me.lblObservacionDetalle = New Eniac.Controles.Label()
      Me.txtProducto = New Eniac.Controles.TextBox()
      Me.dtpFechaReprogEntrega = New Eniac.Controles.DateTimePicker()
      Me.chbFechaReprogEntrega = New System.Windows.Forms.CheckBox()
      Me.lblCriticidad = New Eniac.Controles.Label()
      Me.txtTelefono = New Eniac.Controles.TextBox()
      Me.lblTelefono = New Eniac.Controles.Label()
      Me.txtCorreoElectronico = New Eniac.Controles.TextBox()
      Me.lblCorreoElectronico = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.txtProveedor = New Eniac.Controles.TextBox()
      Me.grpCabecera = New System.Windows.Forms.GroupBox()
      Me.chbFechaE = New Eniac.Controles.CheckBox()
      Me.chbPrecioU = New Eniac.Controles.CheckBox()
      Me.chbCantidades = New Eniac.Controles.CheckBox()
      Me.chbItems = New Eniac.Controles.CheckBox()
      Me.cmbCriticidad = New Eniac.Controles.ComboBox()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.DataSetBancos = New Eniac.Win.DataSetBancos()
      Me.DataSetBancosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.ugbArticulo = New Infragistics.Win.Misc.UltraGroupBox()
      Me.Label10 = New Eniac.Controles.Label()
      Me.txtFechaEntregado = New Eniac.Controles.TextBox()
      Me.Label9 = New Eniac.Controles.Label()
      Me.txtCantidadPendiente = New Eniac.Controles.TextBox()
      Me.Label8 = New Eniac.Controles.Label()
      Me.txtFechaEstado = New Eniac.Controles.TextBox()
      Me.Label7 = New Eniac.Controles.Label()
      Me.txtEstado = New Eniac.Controles.TextBox()
      Me.Label6 = New Eniac.Controles.Label()
      Me.txtCosto = New Eniac.Controles.TextBox()
      Me.Label5 = New Eniac.Controles.Label()
      Me.txtCantidadPedida = New Eniac.Controles.TextBox()
      Me.gpbCabecera = New System.Windows.Forms.GroupBox()
      Me.txtUsuario = New Eniac.Controles.TextBox()
      Me.Label11 = New Eniac.Controles.Label()
      Me.grbObservaciones.SuspendLayout()
      Me.grpCabecera.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataSetBancos, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataSetBancosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ugbArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ugbArticulo.SuspendLayout()
      Me.gpbCabecera.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(646, 546)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(732, 546)
      Me.btnCancelar.TabIndex = 9
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(545, 546)
      Me.btnCopiar.TabIndex = 10
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(488, 546)
      Me.btnAplicar.TabIndex = 11
      '
      'lblNombreTipoCliente
      '
      Me.lblNombreTipoCliente.AutoSize = True
      Me.lblNombreTipoCliente.LabelAsoc = Nothing
      Me.lblNombreTipoCliente.Location = New System.Drawing.Point(5, 57)
      Me.lblNombreTipoCliente.Name = "lblNombreTipoCliente"
      Me.lblNombreTipoCliente.Size = New System.Drawing.Size(50, 13)
      Me.lblNombreTipoCliente.TabIndex = 0
      Me.lblNombreTipoCliente.Text = "Contacto"
      '
      'txtContacto
      '
      Me.txtContacto.BindearPropiedadControl = "Text"
      Me.txtContacto.BindearPropiedadEntidad = "Contacto"
      Me.txtContacto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtContacto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtContacto.Formato = ""
      Me.txtContacto.IsDecimal = False
      Me.txtContacto.IsNumber = False
      Me.txtContacto.IsPK = False
      Me.txtContacto.IsRequired = False
      Me.txtContacto.Key = ""
      Me.txtContacto.LabelAsoc = Me.lblNombreTipoCliente
      Me.txtContacto.Location = New System.Drawing.Point(75, 54)
      Me.txtContacto.MaxLength = 30
      Me.txtContacto.Name = "txtContacto"
      Me.txtContacto.Size = New System.Drawing.Size(161, 20)
      Me.txtContacto.TabIndex = 1
      '
      'lblIdTipoCliente
      '
      Me.lblIdTipoCliente.LabelAsoc = Nothing
      Me.lblIdTipoCliente.Location = New System.Drawing.Point(13, 242)
      Me.lblIdTipoCliente.Name = "lblIdTipoCliente"
      Me.lblIdTipoCliente.Size = New System.Drawing.Size(51, 21)
      Me.lblIdTipoCliente.TabIndex = 6
      Me.lblIdTipoCliente.Text = "Situación"
      '
      'txtObservacion
      '
      Me.txtObservacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
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
      Me.txtObservacion.LabelAsoc = Me.lblIdTipoCliente
      Me.txtObservacion.Location = New System.Drawing.Point(69, 239)
      Me.txtObservacion.MaxLength = 500
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(732, 67)
      Me.txtObservacion.TabIndex = 7
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(290, 19)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(90, 13)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "Fecha Activación"
      '
      'dtpActivacion
      '
      Me.dtpActivacion.BindearPropiedadControl = "Value"
      Me.dtpActivacion.BindearPropiedadEntidad = "FechaActivacion"
      Me.dtpActivacion.CustomFormat = "dd/MM/yyyy  HH:mm"
      Me.dtpActivacion.Enabled = False
      Me.dtpActivacion.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpActivacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpActivacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpActivacion.IsPK = False
      Me.dtpActivacion.IsRequired = True
      Me.dtpActivacion.Key = ""
      Me.dtpActivacion.LabelAsoc = Nothing
      Me.dtpActivacion.Location = New System.Drawing.Point(384, 16)
      Me.dtpActivacion.Name = "dtpActivacion"
      Me.dtpActivacion.Size = New System.Drawing.Size(129, 20)
      Me.dtpActivacion.TabIndex = 13
      Me.dtpActivacion.Tag = "000"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(5, 19)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(70, 13)
      Me.Label2.TabIndex = 14
      Me.Label2.Text = "Comprobante"
      '
      'txtComprobante
      '
      Me.txtComprobante.BindearPropiedadControl = ""
      Me.txtComprobante.BindearPropiedadEntidad = ""
      Me.txtComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.txtComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtComprobante.Formato = ""
      Me.txtComprobante.IsDecimal = False
      Me.txtComprobante.IsNumber = False
      Me.txtComprobante.IsPK = False
      Me.txtComprobante.IsRequired = False
      Me.txtComprobante.Key = ""
      Me.txtComprobante.LabelAsoc = Me.Label2
      Me.txtComprobante.Location = New System.Drawing.Point(75, 16)
      Me.txtComprobante.MaxLength = 30
      Me.txtComprobante.Name = "txtComprobante"
      Me.txtComprobante.ReadOnly = True
      Me.txtComprobante.Size = New System.Drawing.Size(67, 20)
      Me.txtComprobante.TabIndex = 15
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(145, 19)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(44, 13)
      Me.Label3.TabIndex = 16
      Me.Label3.Text = "Número"
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = ""
      Me.txtNumero.BindearPropiedadEntidad = ""
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = ""
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = False
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Me.Label3
      Me.txtNumero.Location = New System.Drawing.Point(195, 16)
      Me.txtNumero.MaxLength = 30
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.Size = New System.Drawing.Size(87, 20)
      Me.txtNumero.TabIndex = 17
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.LabelAsoc = Nothing
      Me.lblItem.Location = New System.Drawing.Point(21, 22)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(27, 13)
      Me.lblItem.TabIndex = 18
      Me.lblItem.Text = "Item"
      '
      'txtItem
      '
      Me.txtItem.BindearPropiedadControl = ""
      Me.txtItem.BindearPropiedadEntidad = ""
      Me.txtItem.ForeColorFocus = System.Drawing.Color.Red
      Me.txtItem.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtItem.Formato = ""
      Me.txtItem.IsDecimal = False
      Me.txtItem.IsNumber = False
      Me.txtItem.IsPK = False
      Me.txtItem.IsRequired = False
      Me.txtItem.Key = ""
      Me.txtItem.LabelAsoc = Me.lblItem
      Me.txtItem.Location = New System.Drawing.Point(67, 19)
      Me.txtItem.MaxLength = 30
      Me.txtItem.Name = "txtItem"
      Me.txtItem.ReadOnly = True
      Me.txtItem.Size = New System.Drawing.Size(109, 20)
      Me.txtItem.TabIndex = 19
      '
      'grbObservaciones
      '
      Me.grbObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbObservaciones.Controls.Add(Me.btnRefreshObservaciones)
      Me.grbObservaciones.Controls.Add(Me.cmbObservaciones)
      Me.grbObservaciones.Controls.Add(Me.lblObservacionDetalle)
      Me.grbObservaciones.Location = New System.Drawing.Point(11, 185)
      Me.grbObservaciones.Name = "grbObservaciones"
      Me.grbObservaciones.Size = New System.Drawing.Size(790, 49)
      Me.grbObservaciones.TabIndex = 20
      Me.grbObservaciones.TabStop = False
      '
      'btnRefreshObservaciones
      '
      Me.btnRefreshObservaciones.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
      Me.btnRefreshObservaciones.Location = New System.Drawing.Point(470, 13)
      Me.btnRefreshObservaciones.Name = "btnRefreshObservaciones"
      Me.btnRefreshObservaciones.Size = New System.Drawing.Size(28, 28)
      Me.btnRefreshObservaciones.TabIndex = 84
      Me.btnRefreshObservaciones.UseVisualStyleBackColor = True
      '
      'cmbObservaciones
      '
      Me.cmbObservaciones.BindearPropiedadControl = ""
      Me.cmbObservaciones.BindearPropiedadEntidad = ""
      Me.cmbObservaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbObservaciones.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbObservaciones.FormattingEnabled = True
      Me.cmbObservaciones.IsPK = False
      Me.cmbObservaciones.IsRequired = False
      Me.cmbObservaciones.Items.AddRange(New Object() {"Normal", "Crítica"})
      Me.cmbObservaciones.Key = Nothing
      Me.cmbObservaciones.LabelAsoc = Nothing
      Me.cmbObservaciones.Location = New System.Drawing.Point(86, 16)
      Me.cmbObservaciones.Name = "cmbObservaciones"
      Me.cmbObservaciones.Size = New System.Drawing.Size(381, 21)
      Me.cmbObservaciones.TabIndex = 35
      '
      'lblObservacionDetalle
      '
      Me.lblObservacionDetalle.AutoSize = True
      Me.lblObservacionDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblObservacionDetalle.LabelAsoc = Nothing
      Me.lblObservacionDetalle.Location = New System.Drawing.Point(2, 21)
      Me.lblObservacionDetalle.Name = "lblObservacionDetalle"
      Me.lblObservacionDetalle.Size = New System.Drawing.Size(78, 13)
      Me.lblObservacionDetalle.TabIndex = 83
      Me.lblObservacionDetalle.Text = "Observaciones"
      '
      'txtProducto
      '
      Me.txtProducto.BindearPropiedadControl = ""
      Me.txtProducto.BindearPropiedadEntidad = ""
      Me.txtProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtProducto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtProducto.Formato = ""
      Me.txtProducto.IsDecimal = False
      Me.txtProducto.IsNumber = False
      Me.txtProducto.IsPK = False
      Me.txtProducto.IsRequired = False
      Me.txtProducto.Key = ""
      Me.txtProducto.LabelAsoc = Me.lblItem
      Me.txtProducto.Location = New System.Drawing.Point(182, 19)
      Me.txtProducto.MaxLength = 30
      Me.txtProducto.Name = "txtProducto"
      Me.txtProducto.ReadOnly = True
      Me.txtProducto.Size = New System.Drawing.Size(323, 20)
      Me.txtProducto.TabIndex = 21
      '
      'dtpFechaReprogEntrega
      '
      Me.dtpFechaReprogEntrega.BindearPropiedadControl = ""
      Me.dtpFechaReprogEntrega.BindearPropiedadEntidad = ""
      Me.dtpFechaReprogEntrega.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaReprogEntrega.Enabled = False
      Me.dtpFechaReprogEntrega.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaReprogEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaReprogEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaReprogEntrega.IsPK = False
      Me.dtpFechaReprogEntrega.IsRequired = True
      Me.dtpFechaReprogEntrega.Key = ""
      Me.dtpFechaReprogEntrega.LabelAsoc = Nothing
      Me.dtpFechaReprogEntrega.Location = New System.Drawing.Point(415, 54)
      Me.dtpFechaReprogEntrega.Name = "dtpFechaReprogEntrega"
      Me.dtpFechaReprogEntrega.Size = New System.Drawing.Size(98, 20)
      Me.dtpFechaReprogEntrega.TabIndex = 23
      Me.dtpFechaReprogEntrega.Tag = "000"
      '
      'chbFechaReprogEntrega
      '
      Me.chbFechaReprogEntrega.AutoSize = True
      Me.chbFechaReprogEntrega.Location = New System.Drawing.Point(242, 56)
      Me.chbFechaReprogEntrega.Name = "chbFechaReprogEntrega"
      Me.chbFechaReprogEntrega.Size = New System.Drawing.Size(177, 17)
      Me.chbFechaReprogEntrega.TabIndex = 24
      Me.chbFechaReprogEntrega.Text = "Fecha Reprogramación Entrega"
      Me.chbFechaReprogEntrega.UseVisualStyleBackColor = True
      '
      'lblCriticidad
      '
      Me.lblCriticidad.AutoSize = True
      Me.lblCriticidad.LabelAsoc = Nothing
      Me.lblCriticidad.Location = New System.Drawing.Point(4, 49)
      Me.lblCriticidad.Name = "lblCriticidad"
      Me.lblCriticidad.Size = New System.Drawing.Size(50, 13)
      Me.lblCriticidad.TabIndex = 29
      Me.lblCriticidad.Text = "Criticidad"
      '
      'txtTelefono
      '
      Me.txtTelefono.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTelefono.BindearPropiedadControl = ""
      Me.txtTelefono.BindearPropiedadEntidad = ""
      Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefono.Formato = ""
      Me.txtTelefono.IsDecimal = False
      Me.txtTelefono.IsNumber = False
      Me.txtTelefono.IsPK = False
      Me.txtTelefono.IsRequired = False
      Me.txtTelefono.Key = ""
      Me.txtTelefono.LabelAsoc = Me.lblTelefono
      Me.txtTelefono.Location = New System.Drawing.Point(75, 106)
      Me.txtTelefono.MaxLength = 100
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.Size = New System.Drawing.Size(709, 20)
      Me.txtTelefono.TabIndex = 32
      '
      'lblTelefono
      '
      Me.lblTelefono.AutoSize = True
      Me.lblTelefono.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblTelefono.LabelAsoc = Nothing
      Me.lblTelefono.Location = New System.Drawing.Point(5, 109)
      Me.lblTelefono.Name = "lblTelefono"
      Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
      Me.lblTelefono.TabIndex = 31
      Me.lblTelefono.Text = "Teléfono"
      '
      'txtCorreoElectronico
      '
      Me.txtCorreoElectronico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCorreoElectronico.BindearPropiedadControl = ""
      Me.txtCorreoElectronico.BindearPropiedadEntidad = ""
      Me.txtCorreoElectronico.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCorreoElectronico.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCorreoElectronico.Formato = ""
      Me.txtCorreoElectronico.IsDecimal = False
      Me.txtCorreoElectronico.IsNumber = False
      Me.txtCorreoElectronico.IsPK = False
      Me.txtCorreoElectronico.IsRequired = False
      Me.txtCorreoElectronico.Key = Nothing
      Me.txtCorreoElectronico.LabelAsoc = Me.lblCorreoElectronico
      Me.txtCorreoElectronico.Location = New System.Drawing.Point(75, 132)
      Me.txtCorreoElectronico.MaxLength = 250
      Me.txtCorreoElectronico.Multiline = True
      Me.txtCorreoElectronico.Name = "txtCorreoElectronico"
      Me.txtCorreoElectronico.Size = New System.Drawing.Size(709, 38)
      Me.txtCorreoElectronico.TabIndex = 34
      '
      'lblCorreoElectronico
      '
      Me.lblCorreoElectronico.AutoSize = True
      Me.lblCorreoElectronico.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblCorreoElectronico.LabelAsoc = Nothing
      Me.lblCorreoElectronico.Location = New System.Drawing.Point(5, 135)
      Me.lblCorreoElectronico.Name = "lblCorreoElectronico"
      Me.lblCorreoElectronico.Size = New System.Drawing.Size(35, 13)
      Me.lblCorreoElectronico.TabIndex = 33
      Me.lblCorreoElectronico.Text = "E-mail"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.LabelAsoc = Nothing
      Me.Label4.Location = New System.Drawing.Point(5, 83)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(56, 13)
      Me.Label4.TabIndex = 35
      Me.Label4.Text = "Proveedor"
      '
      'txtProveedor
      '
      Me.txtProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtProveedor.BindearPropiedadControl = ""
      Me.txtProveedor.BindearPropiedadEntidad = ""
      Me.txtProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtProveedor.Formato = ""
      Me.txtProveedor.IsDecimal = False
      Me.txtProveedor.IsNumber = False
      Me.txtProveedor.IsPK = False
      Me.txtProveedor.IsRequired = False
      Me.txtProveedor.Key = ""
      Me.txtProveedor.LabelAsoc = Me.Label4
      Me.txtProveedor.Location = New System.Drawing.Point(75, 80)
      Me.txtProveedor.MaxLength = 30
      Me.txtProveedor.Name = "txtProveedor"
      Me.txtProveedor.ReadOnly = True
      Me.txtProveedor.Size = New System.Drawing.Size(318, 20)
      Me.txtProveedor.TabIndex = 36
      '
      'grpCabecera
      '
      Me.grpCabecera.Controls.Add(Me.chbFechaE)
      Me.grpCabecera.Controls.Add(Me.chbPrecioU)
      Me.grpCabecera.Controls.Add(Me.chbCantidades)
      Me.grpCabecera.Controls.Add(Me.chbItems)
      Me.grpCabecera.Controls.Add(Me.lblCriticidad)
      Me.grpCabecera.Controls.Add(Me.cmbCriticidad)
      Me.grpCabecera.Location = New System.Drawing.Point(11, 464)
      Me.grpCabecera.Name = "grpCabecera"
      Me.grpCabecera.Size = New System.Drawing.Size(507, 76)
      Me.grpCabecera.TabIndex = 37
      Me.grpCabecera.TabStop = False
      Me.grpCabecera.Visible = False
      '
      'chbFechaE
      '
      Me.chbFechaE.AutoSize = True
      Me.chbFechaE.BindearPropiedadControl = "Checked"
      Me.chbFechaE.BindearPropiedadEntidad = "FechaE"
      Me.chbFechaE.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFechaE.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFechaE.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbFechaE.IsPK = False
      Me.chbFechaE.IsRequired = False
      Me.chbFechaE.Key = Nothing
      Me.chbFechaE.LabelAsoc = Nothing
      Me.chbFechaE.Location = New System.Drawing.Point(384, 23)
      Me.chbFechaE.Name = "chbFechaE"
      Me.chbFechaE.Size = New System.Drawing.Size(113, 17)
      Me.chbFechaE.TabIndex = 34
      Me.chbFechaE.Text = "Ok Fecha Entrega"
      Me.chbFechaE.UseVisualStyleBackColor = True
      '
      'chbPrecioU
      '
      Me.chbPrecioU.AutoSize = True
      Me.chbPrecioU.BindearPropiedadControl = "Checked"
      Me.chbPrecioU.BindearPropiedadEntidad = "Precio"
      Me.chbPrecioU.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrecioU.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrecioU.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbPrecioU.IsPK = False
      Me.chbPrecioU.IsRequired = False
      Me.chbPrecioU.Key = Nothing
      Me.chbPrecioU.LabelAsoc = Nothing
      Me.chbPrecioU.Location = New System.Drawing.Point(237, 23)
      Me.chbPrecioU.Name = "chbPrecioU"
      Me.chbPrecioU.Size = New System.Drawing.Size(112, 17)
      Me.chbPrecioU.TabIndex = 33
      Me.chbPrecioU.Text = "Ok Precio Unitario"
      Me.chbPrecioU.UseVisualStyleBackColor = True
      '
      'chbCantidades
      '
      Me.chbCantidades.AutoSize = True
      Me.chbCantidades.BindearPropiedadControl = "Checked"
      Me.chbCantidades.BindearPropiedadEntidad = "Cantidades"
      Me.chbCantidades.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCantidades.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCantidades.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbCantidades.IsPK = False
      Me.chbCantidades.IsRequired = False
      Me.chbCantidades.Key = Nothing
      Me.chbCantidades.LabelAsoc = Nothing
      Me.chbCantidades.Location = New System.Drawing.Point(111, 23)
      Me.chbCantidades.Name = "chbCantidades"
      Me.chbCantidades.Size = New System.Drawing.Size(96, 17)
      Me.chbCantidades.TabIndex = 32
      Me.chbCantidades.Text = "Ok Cantidades"
      Me.chbCantidades.UseVisualStyleBackColor = True
      '
      'chbItems
      '
      Me.chbItems.AutoSize = True
      Me.chbItems.BindearPropiedadControl = "Checked"
      Me.chbItems.BindearPropiedadEntidad = "Items"
      Me.chbItems.ForeColorFocus = System.Drawing.Color.Red
      Me.chbItems.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbItems.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbItems.IsPK = False
      Me.chbItems.IsRequired = False
      Me.chbItems.Key = Nothing
      Me.chbItems.LabelAsoc = Nothing
      Me.chbItems.Location = New System.Drawing.Point(6, 23)
      Me.chbItems.Name = "chbItems"
      Me.chbItems.Size = New System.Drawing.Size(68, 17)
      Me.chbItems.TabIndex = 31
      Me.chbItems.Text = "Ok Items"
      Me.chbItems.UseVisualStyleBackColor = True
      '
      'cmbCriticidad
      '
      Me.cmbCriticidad.BindearPropiedadControl = "SelectedItem"
      Me.cmbCriticidad.BindearPropiedadEntidad = "Criticidad"
      Me.cmbCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCriticidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCriticidad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCriticidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCriticidad.FormattingEnabled = True
      Me.cmbCriticidad.IsPK = False
      Me.cmbCriticidad.IsRequired = True
      Me.cmbCriticidad.Items.AddRange(New Object() {"Normal", "Crítica"})
      Me.cmbCriticidad.Key = Nothing
      Me.cmbCriticidad.LabelAsoc = Nothing
      Me.cmbCriticidad.Location = New System.Drawing.Point(58, 46)
      Me.cmbCriticidad.Name = "cmbCriticidad"
      Me.cmbCriticidad.Size = New System.Drawing.Size(119, 21)
      Me.cmbCriticidad.TabIndex = 30
      '
      'ugDetalle
      '
      Me.ugDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[True]
      Appearance2.BackColor = System.Drawing.Color.Gainsboro
      UltraGridBand1.Override.CellAppearance = Appearance2
      UltraGridBand1.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.Button
      UltraGridBand1.Override.FixedRowStyle = Infragistics.Win.UltraWinGrid.FixedRowStyle.Top
      UltraGridBand1.SummaryFooterCaption = "Totales:"
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance3.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance3
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance5.BackColor2 = System.Drawing.SystemColors.Control
      Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance6.BackColor = System.Drawing.SystemColors.Window
      Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance6
      Appearance7.BackColor = System.Drawing.SystemColors.Highlight
      Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance7
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance8.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance8
      Appearance9.BorderColor = System.Drawing.Color.Silver
      Appearance9.FontData.SizeInPoints = 7.0!
      Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance9
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance10.BackColor = System.Drawing.SystemColors.Control
      Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance10.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance10
      Appearance11.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance11
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance12.BackColor = System.Drawing.SystemColors.Window
      Appearance12.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance12
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(10, 308)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(791, 150)
      Me.ugDetalle.TabIndex = 38
      Me.ugDetalle.Visible = False
      '
      'DataSetBancos
      '
      Me.DataSetBancos.DataSetName = "DataSetBancos"
      Me.DataSetBancos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'DataSetBancosBindingSource
      '
      Me.DataSetBancosBindingSource.DataSource = Me.DataSetBancos
      Me.DataSetBancosBindingSource.Position = 0
      '
      'ugbArticulo
      '
      Me.ugbArticulo.Controls.Add(Me.Label10)
      Me.ugbArticulo.Controls.Add(Me.txtFechaEntregado)
      Me.ugbArticulo.Controls.Add(Me.Label9)
      Me.ugbArticulo.Controls.Add(Me.txtCantidadPendiente)
      Me.ugbArticulo.Controls.Add(Me.Label8)
      Me.ugbArticulo.Controls.Add(Me.txtFechaEstado)
      Me.ugbArticulo.Controls.Add(Me.Label7)
      Me.ugbArticulo.Controls.Add(Me.txtEstado)
      Me.ugbArticulo.Controls.Add(Me.Label6)
      Me.ugbArticulo.Controls.Add(Me.txtCosto)
      Me.ugbArticulo.Controls.Add(Me.Label5)
      Me.ugbArticulo.Controls.Add(Me.txtCantidadPedida)
      Me.ugbArticulo.Controls.Add(Me.txtProducto)
      Me.ugbArticulo.Controls.Add(Me.txtItem)
      Me.ugbArticulo.Controls.Add(Me.lblItem)
      Me.ugbArticulo.Location = New System.Drawing.Point(7, 308)
      Me.ugbArticulo.Name = "ugbArticulo"
      Me.ugbArticulo.Size = New System.Drawing.Size(511, 123)
      Me.ugbArticulo.TabIndex = 39
      Me.ugbArticulo.Text = "Artículo"
      Me.ugbArticulo.Visible = False
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.LabelAsoc = Nothing
      Me.Label10.Location = New System.Drawing.Point(5, 100)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(77, 13)
      Me.Label10.TabIndex = 50
      Me.Label10.Text = "Fecha Entrega"
      '
      'txtFechaEntregado
      '
      Me.txtFechaEntregado.BindearPropiedadControl = ""
      Me.txtFechaEntregado.BindearPropiedadEntidad = ""
      Me.txtFechaEntregado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFechaEntregado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFechaEntregado.Formato = ""
      Me.txtFechaEntregado.IsDecimal = False
      Me.txtFechaEntregado.IsNumber = False
      Me.txtFechaEntregado.IsPK = False
      Me.txtFechaEntregado.IsRequired = False
      Me.txtFechaEntregado.Key = "dd/MM/yyyy"
      Me.txtFechaEntregado.LabelAsoc = Me.Label10
      Me.txtFechaEntregado.Location = New System.Drawing.Point(84, 97)
      Me.txtFechaEntregado.MaxLength = 30
      Me.txtFechaEntregado.Name = "txtFechaEntregado"
      Me.txtFechaEntregado.ReadOnly = True
      Me.txtFechaEntregado.Size = New System.Drawing.Size(92, 20)
      Me.txtFechaEntregado.TabIndex = 51
      Me.txtFechaEntregado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.LabelAsoc = Nothing
      Me.Label9.Location = New System.Drawing.Point(193, 73)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(100, 13)
      Me.Label9.TabIndex = 48
      Me.Label9.Text = "Cantidad Pendiente"
      '
      'txtCantidadPendiente
      '
      Me.txtCantidadPendiente.BindearPropiedadControl = ""
      Me.txtCantidadPendiente.BindearPropiedadEntidad = ""
      Me.txtCantidadPendiente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadPendiente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadPendiente.Formato = "N2"
      Me.txtCantidadPendiente.IsDecimal = False
      Me.txtCantidadPendiente.IsNumber = False
      Me.txtCantidadPendiente.IsPK = False
      Me.txtCantidadPendiente.IsRequired = False
      Me.txtCantidadPendiente.Key = ""
      Me.txtCantidadPendiente.LabelAsoc = Me.Label9
      Me.txtCantidadPendiente.Location = New System.Drawing.Point(298, 70)
      Me.txtCantidadPendiente.MaxLength = 30
      Me.txtCantidadPendiente.Name = "txtCantidadPendiente"
      Me.txtCantidadPendiente.ReadOnly = True
      Me.txtCantidadPendiente.Size = New System.Drawing.Size(64, 20)
      Me.txtCantidadPendiente.TabIndex = 49
      Me.txtCantidadPendiente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.LabelAsoc = Nothing
      Me.Label8.Location = New System.Drawing.Point(5, 73)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(73, 13)
      Me.Label8.TabIndex = 46
      Me.Label8.Text = "Fecha Estado"
      '
      'txtFechaEstado
      '
      Me.txtFechaEstado.BindearPropiedadControl = ""
      Me.txtFechaEstado.BindearPropiedadEntidad = ""
      Me.txtFechaEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFechaEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFechaEstado.Formato = ""
      Me.txtFechaEstado.IsDecimal = False
      Me.txtFechaEstado.IsNumber = False
      Me.txtFechaEstado.IsPK = False
      Me.txtFechaEstado.IsRequired = False
      Me.txtFechaEstado.Key = "dd/MM/yyyy"
      Me.txtFechaEstado.LabelAsoc = Me.Label8
      Me.txtFechaEstado.Location = New System.Drawing.Point(84, 70)
      Me.txtFechaEstado.MaxLength = 30
      Me.txtFechaEstado.Name = "txtFechaEstado"
      Me.txtFechaEstado.ReadOnly = True
      Me.txtFechaEstado.Size = New System.Drawing.Size(92, 20)
      Me.txtFechaEstado.TabIndex = 47
      Me.txtFechaEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.LabelAsoc = Nothing
      Me.Label7.Location = New System.Drawing.Point(20, 47)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(40, 13)
      Me.Label7.TabIndex = 44
      Me.Label7.Text = "Estado"
      '
      'txtEstado
      '
      Me.txtEstado.BindearPropiedadControl = ""
      Me.txtEstado.BindearPropiedadEntidad = ""
      Me.txtEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.txtEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtEstado.Formato = ""
      Me.txtEstado.IsDecimal = False
      Me.txtEstado.IsNumber = False
      Me.txtEstado.IsPK = False
      Me.txtEstado.IsRequired = False
      Me.txtEstado.Key = ""
      Me.txtEstado.LabelAsoc = Me.Label7
      Me.txtEstado.Location = New System.Drawing.Point(67, 44)
      Me.txtEstado.MaxLength = 30
      Me.txtEstado.Name = "txtEstado"
      Me.txtEstado.ReadOnly = True
      Me.txtEstado.Size = New System.Drawing.Size(109, 20)
      Me.txtEstado.TabIndex = 45
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.LabelAsoc = Nothing
      Me.Label6.Location = New System.Drawing.Point(377, 47)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(34, 13)
      Me.Label6.TabIndex = 42
      Me.Label6.Text = "Costo"
      '
      'txtCosto
      '
      Me.txtCosto.BindearPropiedadControl = ""
      Me.txtCosto.BindearPropiedadEntidad = ""
      Me.txtCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCosto.Formato = "N2"
      Me.txtCosto.IsDecimal = False
      Me.txtCosto.IsNumber = False
      Me.txtCosto.IsPK = False
      Me.txtCosto.IsRequired = False
      Me.txtCosto.Key = ""
      Me.txtCosto.LabelAsoc = Me.Label6
      Me.txtCosto.Location = New System.Drawing.Point(417, 44)
      Me.txtCosto.MaxLength = 30
      Me.txtCosto.Name = "txtCosto"
      Me.txtCosto.ReadOnly = True
      Me.txtCosto.Size = New System.Drawing.Size(88, 20)
      Me.txtCosto.TabIndex = 43
      Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.LabelAsoc = Nothing
      Me.Label5.Location = New System.Drawing.Point(193, 47)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(85, 13)
      Me.Label5.TabIndex = 40
      Me.Label5.Text = "Cantidad Pedida"
      '
      'txtCantidadPedida
      '
      Me.txtCantidadPedida.BindearPropiedadControl = ""
      Me.txtCantidadPedida.BindearPropiedadEntidad = ""
      Me.txtCantidadPedida.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadPedida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadPedida.Formato = "N2"
      Me.txtCantidadPedida.IsDecimal = False
      Me.txtCantidadPedida.IsNumber = False
      Me.txtCantidadPedida.IsPK = False
      Me.txtCantidadPedida.IsRequired = False
      Me.txtCantidadPedida.Key = ""
      Me.txtCantidadPedida.LabelAsoc = Me.Label5
      Me.txtCantidadPedida.Location = New System.Drawing.Point(298, 44)
      Me.txtCantidadPedida.MaxLength = 30
      Me.txtCantidadPedida.Name = "txtCantidadPedida"
      Me.txtCantidadPedida.ReadOnly = True
      Me.txtCantidadPedida.Size = New System.Drawing.Size(64, 20)
      Me.txtCantidadPedida.TabIndex = 41
      Me.txtCantidadPedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'gpbCabecera
      '
      Me.gpbCabecera.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.gpbCabecera.Controls.Add(Me.txtUsuario)
      Me.gpbCabecera.Controls.Add(Me.txtComprobante)
      Me.gpbCabecera.Controls.Add(Me.txtContacto)
      Me.gpbCabecera.Controls.Add(Me.lblNombreTipoCliente)
      Me.gpbCabecera.Controls.Add(Me.dtpFechaReprogEntrega)
      Me.gpbCabecera.Controls.Add(Me.Label4)
      Me.gpbCabecera.Controls.Add(Me.dtpActivacion)
      Me.gpbCabecera.Controls.Add(Me.txtProveedor)
      Me.gpbCabecera.Controls.Add(Me.Label2)
      Me.gpbCabecera.Controls.Add(Me.txtTelefono)
      Me.gpbCabecera.Controls.Add(Me.txtNumero)
      Me.gpbCabecera.Controls.Add(Me.lblTelefono)
      Me.gpbCabecera.Controls.Add(Me.Label3)
      Me.gpbCabecera.Controls.Add(Me.txtCorreoElectronico)
      Me.gpbCabecera.Controls.Add(Me.lblCorreoElectronico)
      Me.gpbCabecera.Controls.Add(Me.chbFechaReprogEntrega)
      Me.gpbCabecera.Controls.Add(Me.Label1)
      Me.gpbCabecera.Controls.Add(Me.Label11)
      Me.gpbCabecera.Location = New System.Drawing.Point(11, 3)
      Me.gpbCabecera.Name = "gpbCabecera"
      Me.gpbCabecera.Size = New System.Drawing.Size(790, 176)
      Me.gpbCabecera.TabIndex = 40
      Me.gpbCabecera.TabStop = False
      '
      'txtUsuario
      '
      Me.txtUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtUsuario.BindearPropiedadControl = "Text"
      Me.txtUsuario.BindearPropiedadEntidad = "IdUsuario"
      Me.txtUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUsuario.Formato = ""
      Me.txtUsuario.IsDecimal = False
      Me.txtUsuario.IsNumber = False
      Me.txtUsuario.IsPK = False
      Me.txtUsuario.IsRequired = False
      Me.txtUsuario.Key = ""
      Me.txtUsuario.LabelAsoc = Me.Label4
      Me.txtUsuario.Location = New System.Drawing.Point(436, 80)
      Me.txtUsuario.MaxLength = 30
      Me.txtUsuario.Name = "txtUsuario"
      Me.txtUsuario.ReadOnly = True
      Me.txtUsuario.Size = New System.Drawing.Size(77, 20)
      Me.txtUsuario.TabIndex = 37
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.LabelAsoc = Nothing
      Me.Label11.Location = New System.Drawing.Point(395, 84)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(43, 13)
      Me.Label11.TabIndex = 38
      Me.Label11.Text = "Usuario"
      '
      'ActivacionesOCDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(821, 581)
      Me.Controls.Add(Me.gpbCabecera)
      Me.Controls.Add(Me.ugbArticulo)
      Me.Controls.Add(Me.ugDetalle)
      Me.Controls.Add(Me.grpCabecera)
      Me.Controls.Add(Me.grbObservaciones)
      Me.Controls.Add(Me.lblIdTipoCliente)
      Me.Controls.Add(Me.txtObservacion)
      Me.Name = "ActivacionesOCDetalle"
      Me.Text = "Activaciones de Ordenes de Compra"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtObservacion, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.grbObservaciones, 0)
      Me.Controls.SetChildIndex(Me.grpCabecera, 0)
      Me.Controls.SetChildIndex(Me.ugDetalle, 0)
      Me.Controls.SetChildIndex(Me.ugbArticulo, 0)
      Me.Controls.SetChildIndex(Me.gpbCabecera, 0)
      Me.grbObservaciones.ResumeLayout(False)
      Me.grbObservaciones.PerformLayout()
      Me.grpCabecera.ResumeLayout(False)
      Me.grpCabecera.PerformLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataSetBancos, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataSetBancosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ugbArticulo, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ugbArticulo.ResumeLayout(False)
      Me.ugbArticulo.PerformLayout()
      Me.gpbCabecera.ResumeLayout(False)
      Me.gpbCabecera.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtContacto As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dtpActivacion As Controles.DateTimePicker
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents txtComprobante As Controles.TextBox
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents txtNumero As Controles.TextBox
   Friend WithEvents lblItem As Controles.Label
   Friend WithEvents txtItem As Controles.TextBox
   Friend WithEvents grbObservaciones As GroupBox
   Friend WithEvents lblObservacionDetalle As Controles.Label
   Friend WithEvents txtProducto As Controles.TextBox
   Friend WithEvents dtpFechaReprogEntrega As Controles.DateTimePicker
   Friend WithEvents chbFechaReprogEntrega As CheckBox
   Friend WithEvents lblCriticidad As Controles.Label
   Friend WithEvents cmbCriticidad As Controles.ComboBox
   Friend WithEvents txtTelefono As Controles.TextBox
   Friend WithEvents lblTelefono As Controles.Label
   Friend WithEvents txtCorreoElectronico As Controles.TextBox
   Friend WithEvents lblCorreoElectronico As Controles.Label
   Friend WithEvents Label4 As Controles.Label
   Friend WithEvents txtProveedor As Controles.TextBox
   Friend WithEvents grpCabecera As GroupBox
   Friend WithEvents chbFechaE As Controles.CheckBox
   Friend WithEvents chbPrecioU As Controles.CheckBox
   Friend WithEvents chbCantidades As Controles.CheckBox
   Friend WithEvents chbItems As Controles.CheckBox
   Friend WithEvents cmbObservaciones As Controles.ComboBox
   Friend WithEvents ugDetalle As UltraGrid
   Friend WithEvents DataSetBancos As DataSetBancos
   Friend WithEvents DataSetBancosBindingSource As BindingSource
   Friend WithEvents ugbArticulo As Misc.UltraGroupBox
   Friend WithEvents Label10 As Controles.Label
   Friend WithEvents txtFechaEntregado As Controles.TextBox
   Friend WithEvents Label9 As Controles.Label
   Friend WithEvents txtCantidadPendiente As Controles.TextBox
   Friend WithEvents Label8 As Controles.Label
   Friend WithEvents txtFechaEstado As Controles.TextBox
   Friend WithEvents Label7 As Controles.Label
   Friend WithEvents txtEstado As Controles.TextBox
   Friend WithEvents Label6 As Controles.Label
   Friend WithEvents txtCosto As Controles.TextBox
   Friend WithEvents Label5 As Controles.Label
   Friend WithEvents txtCantidadPedida As Controles.TextBox
   Friend WithEvents btnRefreshObservaciones As Button
   Friend WithEvents gpbCabecera As GroupBox
   Friend WithEvents txtUsuario As Controles.TextBox
   Friend WithEvents Label11 As Controles.Label
End Class
