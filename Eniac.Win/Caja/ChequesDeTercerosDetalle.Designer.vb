<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChequesDeTercerosDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChequesDeTercerosDetalle))
      Me.dtpFechaCobro = New Eniac.Controles.DateTimePicker()
      Me.lblFechaCobro = New Eniac.Controles.Label()
      Me.txtNroPlanillaIngreso = New Eniac.Controles.TextBox()
      Me.lblPlanillaIngreso = New Eniac.Controles.Label()
      Me.lblTitular = New Eniac.Controles.Label()
      Me.txtTitular = New Eniac.Controles.TextBox()
      Me.dtpFechaEmision = New Eniac.Controles.DateTimePicker()
      Me.lblFechaEmision = New Eniac.Controles.Label()
      Me.grbMovimientosDeCaja = New System.Windows.Forms.GroupBox()
      Me.lblIngreso = New Eniac.Controles.Label()
      Me.txtCajaIngreso = New Eniac.Controles.TextBox()
      Me.txtNombreCajaIngreso = New Eniac.Controles.TextBox()
      Me.lblCajaIngreso = New Eniac.Controles.Label()
      Me.lblCliente = New Eniac.Controles.Label()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.txtCodigoCliente = New Eniac.Controles.TextBox()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNroMovimientoIngreso = New Eniac.Controles.TextBox()
      Me.lblMovimientoIngreso = New Eniac.Controles.Label()
      Me.lblEgreso = New Eniac.Controles.Label()
      Me.IdCajaEgreso = New Eniac.Controles.TextBox()
      Me.lblPlanillaEgreso = New Eniac.Controles.Label()
      Me.txtNombreCajaEgreso = New Eniac.Controles.TextBox()
      Me.lblCajaEgreso = New Eniac.Controles.Label()
      Me.lblProveedor = New Eniac.Controles.Label()
      Me.txtCodigoProveedor = New Eniac.Controles.TextBox()
      Me.lblCodigoProveedor = New Eniac.Controles.Label()
      Me.lblNombreProv = New Eniac.Controles.Label()
      Me.TextBox2 = New Eniac.Controles.TextBox()
      Me.txtNroMovimientoEgreso = New Eniac.Controles.TextBox()
      Me.lblMovimientoEgreso = New Eniac.Controles.Label()
      Me.txtNroPlanillaEgreso = New Eniac.Controles.TextBox()
      Me.grbDetalle = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New Eniac.Controles.TextBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.lblSituacion = New Eniac.Controles.Label()
        Me.cmbSituacionCheque = New Eniac.Controles.ComboBox()
        Me.txtNroOperacion = New Eniac.Controles.TextBox()
        Me.lblNroOperacion = New System.Windows.Forms.Label()
        Me.lblTipoCheque = New Eniac.Controles.Label()
        Me.cmbTipoCheque = New Eniac.Controles.ComboBox()
        Me.txtCUIT = New Eniac.Controles.TextBox()
        Me.lblCUIT = New Eniac.Controles.Label()
        Me.lnkLocalidad = New Eniac.Controles.LinkLabel()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
        Me.txtBancoSucursal = New Eniac.Controles.TextBox()
        Me.lblSucursalBanco = New Eniac.Controles.Label()
        Me.txtImporte = New Eniac.Controles.TextBox()
        Me.lblImporte = New Eniac.Controles.Label()
        Me.txtNumeroCheque = New Eniac.Controles.TextBox()
        Me.lblNumeroCheque = New Eniac.Controles.Label()
        Me.cmbBanco = New Eniac.Controles.ComboBox()
        Me.lblBanco = New Eniac.Controles.Label()
        Me.grbEstado = New System.Windows.Forms.GroupBox()
        Me.txtEstadoActualAnt = New Eniac.Controles.TextBox()
        Me.lblEstadoAnterior = New Eniac.Controles.Label()
        Me.txtEstadoActual = New Eniac.Controles.TextBox()
        Me.lblEstadoActual = New Eniac.Controles.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbpDetalle = New System.Windows.Forms.TabPage()
        Me.tbpCaja = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chbProveedor = New Eniac.Controles.CheckBox()
        Me.bscCodigoProveedor = New Eniac.Controles.Buscador()
        Me.Label1 = New Eniac.Controles.Label()
        Me.bscProveedor = New Eniac.Controles.Buscador()
        Me.Label2 = New Eniac.Controles.Label()
        Me.Label7 = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbpImagenes = New System.Windows.Forms.TabPage()
        Me.rbtDorso = New System.Windows.Forms.RadioButton()
        Me.rbtFrente = New System.Windows.Forms.RadioButton()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbGuardar = New System.Windows.Forms.ToolStripButton()
        Me.PcbChequeDorso = New System.Windows.Forms.PictureBox()
        Me.pcbChequeFrente = New System.Windows.Forms.PictureBox()
        Me.tbpIngresoCaja = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiarIngresoEnCaja = New Eniac.Controles.Button()
        Me.txtObservaciones = New Eniac.Controles.TextBox()
        Me.lblObsdervaciones = New Eniac.Controles.Label()
        Me.lblTipoMovimiento = New Eniac.Controles.Label()
        Me.txtTipoMovimiento = New Eniac.Controles.MaskedTextBox()
        Me.lblPlanillaActual = New Eniac.Controles.Label()
        Me.txtNMovimiento = New Eniac.Controles.MaskedTextBox()
        Me.lblNMovimientoActual = New Eniac.Controles.Label()
        Me.txtPlanillaActual = New Eniac.Controles.MaskedTextBox()
        Me.cmbCentroCosto = New Eniac.Controles.ComboBox()
        Me.lblCentroCosto = New Eniac.Controles.Label()
        Me.bscNombreCuentaCaja = New Eniac.Controles.Buscador()
        Me.lblNombreCuenta = New Eniac.Controles.Label()
        Me.bscCuentaCaja = New Eniac.Controles.Buscador()
        Me.lblCuenta = New Eniac.Controles.Label()
        Me.dtpFechaIngresoCaja = New Eniac.Controles.DateTimePicker()
        Me.lblFechaIngresoCaja = New Eniac.Controles.Label()
        Me.cmbCaja = New Eniac.Controles.ComboBox()
        Me.lblCaja = New Eniac.Controles.Label()
        Me.ofdArchivos = New System.Windows.Forms.OpenFileDialog()
        Me.btnIngresoPorCaja = New Eniac.Controles.Button()
        Me.grbMovimientosDeCaja.SuspendLayout()
        Me.grbDetalle.SuspendLayout()
        Me.grbEstado.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbpDetalle.SuspendLayout()
        Me.tbpCaja.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbpImagenes.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.PcbChequeDorso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pcbChequeFrente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpIngresoCaja.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        resources.ApplyResources(Me.btnAceptar, "btnAceptar")
        '
        'btnCancelar
        '
        resources.ApplyResources(Me.btnCancelar, "btnCancelar")
        '
        'btnCopiar
        '
        resources.ApplyResources(Me.btnCopiar, "btnCopiar")
        '
        'btnAplicar
        '
        resources.ApplyResources(Me.btnAplicar, "btnAplicar")
        '
        'dtpFechaCobro
        '
        Me.dtpFechaCobro.BindearPropiedadControl = "Value"
        Me.dtpFechaCobro.BindearPropiedadEntidad = "FechaCobro"
        resources.ApplyResources(Me.dtpFechaCobro, "dtpFechaCobro")
        Me.dtpFechaCobro.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCobro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCobro.IsPK = False
        Me.dtpFechaCobro.IsRequired = True
        Me.dtpFechaCobro.Key = ""
        Me.dtpFechaCobro.LabelAsoc = Me.lblFechaCobro
        Me.dtpFechaCobro.Name = "dtpFechaCobro"
        '
        'lblFechaCobro
        '
        resources.ApplyResources(Me.lblFechaCobro, "lblFechaCobro")
        Me.lblFechaCobro.LabelAsoc = Nothing
        Me.lblFechaCobro.Name = "lblFechaCobro"
        '
        'txtNroPlanillaIngreso
        '
        Me.txtNroPlanillaIngreso.BindearPropiedadControl = "Text"
        Me.txtNroPlanillaIngreso.BindearPropiedadEntidad = "NroPlanillaIngreso"
        Me.txtNroPlanillaIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPlanillaIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPlanillaIngreso.Formato = ""
        Me.txtNroPlanillaIngreso.IsDecimal = False
        Me.txtNroPlanillaIngreso.IsNumber = True
        Me.txtNroPlanillaIngreso.IsPK = False
        Me.txtNroPlanillaIngreso.IsRequired = False
        Me.txtNroPlanillaIngreso.Key = ""
        Me.txtNroPlanillaIngreso.LabelAsoc = Me.lblPlanillaIngreso
        resources.ApplyResources(Me.txtNroPlanillaIngreso, "txtNroPlanillaIngreso")
        Me.txtNroPlanillaIngreso.Name = "txtNroPlanillaIngreso"
        Me.txtNroPlanillaIngreso.ReadOnly = True
        '
        'lblPlanillaIngreso
        '
        resources.ApplyResources(Me.lblPlanillaIngreso, "lblPlanillaIngreso")
        Me.lblPlanillaIngreso.LabelAsoc = Nothing
        Me.lblPlanillaIngreso.Name = "lblPlanillaIngreso"
        '
        'lblTitular
        '
        resources.ApplyResources(Me.lblTitular, "lblTitular")
        Me.lblTitular.LabelAsoc = Nothing
        Me.lblTitular.Name = "lblTitular"
        '
        'txtTitular
        '
        Me.txtTitular.BindearPropiedadControl = "Text"
        Me.txtTitular.BindearPropiedadEntidad = "Titular"
        Me.txtTitular.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTitular.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTitular.Formato = ""
        Me.txtTitular.IsDecimal = False
        Me.txtTitular.IsNumber = False
        Me.txtTitular.IsPK = False
        Me.txtTitular.IsRequired = True
        Me.txtTitular.Key = "Titular"
        Me.txtTitular.LabelAsoc = Me.lblTitular
        resources.ApplyResources(Me.txtTitular, "txtTitular")
        Me.txtTitular.Name = "txtTitular"
        '
        'dtpFechaEmision
        '
        Me.dtpFechaEmision.BindearPropiedadControl = "Value"
        Me.dtpFechaEmision.BindearPropiedadEntidad = "FechaEmision"
        resources.ApplyResources(Me.dtpFechaEmision, "dtpFechaEmision")
        Me.dtpFechaEmision.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEmision.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEmision.IsPK = False
        Me.dtpFechaEmision.IsRequired = True
        Me.dtpFechaEmision.Key = ""
        Me.dtpFechaEmision.LabelAsoc = Nothing
        Me.dtpFechaEmision.Name = "dtpFechaEmision"
        Me.dtpFechaEmision.Value = New Date(2008, 10, 28, 0, 29, 13, 0)
        '
        'lblFechaEmision
        '
        resources.ApplyResources(Me.lblFechaEmision, "lblFechaEmision")
        Me.lblFechaEmision.LabelAsoc = Nothing
        Me.lblFechaEmision.Name = "lblFechaEmision"
        '
        'grbMovimientosDeCaja
        '
        Me.grbMovimientosDeCaja.Controls.Add(Me.lblIngreso)
        Me.grbMovimientosDeCaja.Controls.Add(Me.txtCajaIngreso)
        Me.grbMovimientosDeCaja.Controls.Add(Me.txtNombreCajaIngreso)
        Me.grbMovimientosDeCaja.Controls.Add(Me.lblCajaIngreso)
        Me.grbMovimientosDeCaja.Controls.Add(Me.lblCliente)
        Me.grbMovimientosDeCaja.Controls.Add(Me.lblCodigoCliente)
        Me.grbMovimientosDeCaja.Controls.Add(Me.txtCodigoCliente)
        Me.grbMovimientosDeCaja.Controls.Add(Me.txtNombre)
        Me.grbMovimientosDeCaja.Controls.Add(Me.lblNombre)
        Me.grbMovimientosDeCaja.Controls.Add(Me.txtNroMovimientoIngreso)
        Me.grbMovimientosDeCaja.Controls.Add(Me.lblMovimientoIngreso)
        Me.grbMovimientosDeCaja.Controls.Add(Me.txtNroPlanillaIngreso)
        Me.grbMovimientosDeCaja.Controls.Add(Me.lblPlanillaIngreso)
        resources.ApplyResources(Me.grbMovimientosDeCaja, "grbMovimientosDeCaja")
        Me.grbMovimientosDeCaja.Name = "grbMovimientosDeCaja"
        Me.grbMovimientosDeCaja.TabStop = False
        '
        'lblIngreso
        '
        resources.ApplyResources(Me.lblIngreso, "lblIngreso")
        Me.lblIngreso.LabelAsoc = Nothing
        Me.lblIngreso.Name = "lblIngreso"
        '
        'txtCajaIngreso
        '
        Me.txtCajaIngreso.BindearPropiedadControl = "Text"
        Me.txtCajaIngreso.BindearPropiedadEntidad = "IdCajaIngreso"
        Me.txtCajaIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCajaIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCajaIngreso.Formato = ""
        Me.txtCajaIngreso.IsDecimal = False
        Me.txtCajaIngreso.IsNumber = True
        Me.txtCajaIngreso.IsPK = False
        Me.txtCajaIngreso.IsRequired = False
        Me.txtCajaIngreso.Key = ""
        Me.txtCajaIngreso.LabelAsoc = Me.lblPlanillaIngreso
        resources.ApplyResources(Me.txtCajaIngreso, "txtCajaIngreso")
        Me.txtCajaIngreso.Name = "txtCajaIngreso"
        Me.txtCajaIngreso.ReadOnly = True
        '
        'txtNombreCajaIngreso
        '
        Me.txtNombreCajaIngreso.BindearPropiedadControl = ""
        Me.txtNombreCajaIngreso.BindearPropiedadEntidad = ""
        Me.txtNombreCajaIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCajaIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCajaIngreso.Formato = ""
        Me.txtNombreCajaIngreso.IsDecimal = False
        Me.txtNombreCajaIngreso.IsNumber = True
        Me.txtNombreCajaIngreso.IsPK = False
        Me.txtNombreCajaIngreso.IsRequired = False
        Me.txtNombreCajaIngreso.Key = Nothing
        Me.txtNombreCajaIngreso.LabelAsoc = Me.lblCajaIngreso
        resources.ApplyResources(Me.txtNombreCajaIngreso, "txtNombreCajaIngreso")
        Me.txtNombreCajaIngreso.Name = "txtNombreCajaIngreso"
        Me.txtNombreCajaIngreso.ReadOnly = True
        '
        'lblCajaIngreso
        '
        resources.ApplyResources(Me.lblCajaIngreso, "lblCajaIngreso")
        Me.lblCajaIngreso.LabelAsoc = Nothing
        Me.lblCajaIngreso.Name = "lblCajaIngreso"
        '
        'lblCliente
        '
        resources.ApplyResources(Me.lblCliente, "lblCliente")
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Name = "lblCliente"
        '
        'lblCodigoCliente
        '
        resources.ApplyResources(Me.lblCodigoCliente, "lblCodigoCliente")
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.BindearPropiedadControl = "Text"
        Me.txtCodigoCliente.BindearPropiedadEntidad = "Cliente.CodigoCliente"
        Me.txtCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoCliente.Formato = ""
        Me.txtCodigoCliente.IsDecimal = False
        Me.txtCodigoCliente.IsNumber = False
        Me.txtCodigoCliente.IsPK = False
        Me.txtCodigoCliente.IsRequired = False
        Me.txtCodigoCliente.Key = ""
        Me.txtCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        resources.ApplyResources(Me.txtCodigoCliente, "txtCodigoCliente")
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.ReadOnly = True
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "Cliente.NombreCliente"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = False
        Me.txtNombre.Key = "NombreCliente"
        Me.txtNombre.LabelAsoc = Me.lblNombre
        resources.ApplyResources(Me.txtNombre, "txtNombre")
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        '
        'lblNombre
        '
        resources.ApplyResources(Me.lblNombre, "lblNombre")
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Name = "lblNombre"
        '
        'txtNroMovimientoIngreso
        '
        Me.txtNroMovimientoIngreso.BindearPropiedadControl = "Text"
        Me.txtNroMovimientoIngreso.BindearPropiedadEntidad = "NroMovimientoIngreso"
        Me.txtNroMovimientoIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroMovimientoIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroMovimientoIngreso.Formato = ""
        Me.txtNroMovimientoIngreso.IsDecimal = False
        Me.txtNroMovimientoIngreso.IsNumber = True
        Me.txtNroMovimientoIngreso.IsPK = False
        Me.txtNroMovimientoIngreso.IsRequired = False
        Me.txtNroMovimientoIngreso.Key = Nothing
        Me.txtNroMovimientoIngreso.LabelAsoc = Me.lblMovimientoIngreso
        resources.ApplyResources(Me.txtNroMovimientoIngreso, "txtNroMovimientoIngreso")
        Me.txtNroMovimientoIngreso.Name = "txtNroMovimientoIngreso"
        Me.txtNroMovimientoIngreso.ReadOnly = True
        '
        'lblMovimientoIngreso
        '
        resources.ApplyResources(Me.lblMovimientoIngreso, "lblMovimientoIngreso")
        Me.lblMovimientoIngreso.LabelAsoc = Nothing
        Me.lblMovimientoIngreso.Name = "lblMovimientoIngreso"
        '
        'lblEgreso
        '
        resources.ApplyResources(Me.lblEgreso, "lblEgreso")
        Me.lblEgreso.LabelAsoc = Nothing
        Me.lblEgreso.Name = "lblEgreso"
        '
        'IdCajaEgreso
        '
        Me.IdCajaEgreso.BindearPropiedadControl = "Text"
        Me.IdCajaEgreso.BindearPropiedadEntidad = "NroPlanillaEgreso"
        Me.IdCajaEgreso.ForeColorFocus = System.Drawing.Color.Red
        Me.IdCajaEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.IdCajaEgreso.Formato = ""
        Me.IdCajaEgreso.IsDecimal = False
        Me.IdCajaEgreso.IsNumber = True
        Me.IdCajaEgreso.IsPK = False
        Me.IdCajaEgreso.IsRequired = False
        Me.IdCajaEgreso.Key = Nothing
        Me.IdCajaEgreso.LabelAsoc = Me.lblPlanillaEgreso
        resources.ApplyResources(Me.IdCajaEgreso, "IdCajaEgreso")
        Me.IdCajaEgreso.Name = "IdCajaEgreso"
        Me.IdCajaEgreso.ReadOnly = True
        '
        'lblPlanillaEgreso
        '
        resources.ApplyResources(Me.lblPlanillaEgreso, "lblPlanillaEgreso")
        Me.lblPlanillaEgreso.LabelAsoc = Nothing
        Me.lblPlanillaEgreso.Name = "lblPlanillaEgreso"
        '
        'txtNombreCajaEgreso
        '
        Me.txtNombreCajaEgreso.BindearPropiedadControl = ""
        Me.txtNombreCajaEgreso.BindearPropiedadEntidad = ""
        Me.txtNombreCajaEgreso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreCajaEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreCajaEgreso.Formato = ""
        Me.txtNombreCajaEgreso.IsDecimal = False
        Me.txtNombreCajaEgreso.IsNumber = True
        Me.txtNombreCajaEgreso.IsPK = False
        Me.txtNombreCajaEgreso.IsRequired = False
        Me.txtNombreCajaEgreso.Key = Nothing
        Me.txtNombreCajaEgreso.LabelAsoc = Me.lblCajaEgreso
        resources.ApplyResources(Me.txtNombreCajaEgreso, "txtNombreCajaEgreso")
        Me.txtNombreCajaEgreso.Name = "txtNombreCajaEgreso"
        Me.txtNombreCajaEgreso.ReadOnly = True
        '
        'lblCajaEgreso
        '
        resources.ApplyResources(Me.lblCajaEgreso, "lblCajaEgreso")
        Me.lblCajaEgreso.LabelAsoc = Nothing
        Me.lblCajaEgreso.Name = "lblCajaEgreso"
        '
        'lblProveedor
        '
        resources.ApplyResources(Me.lblProveedor, "lblProveedor")
        Me.lblProveedor.LabelAsoc = Nothing
        Me.lblProveedor.Name = "lblProveedor"
        '
        'txtCodigoProveedor
        '
        Me.txtCodigoProveedor.BindearPropiedadControl = "Text"
        Me.txtCodigoProveedor.BindearPropiedadEntidad = "Proveedor.CodigoProveedor"
        Me.txtCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoProveedor.Formato = ""
        Me.txtCodigoProveedor.IsDecimal = False
        Me.txtCodigoProveedor.IsNumber = False
        Me.txtCodigoProveedor.IsPK = False
        Me.txtCodigoProveedor.IsRequired = False
        Me.txtCodigoProveedor.Key = ""
        Me.txtCodigoProveedor.LabelAsoc = Me.lblCodigoProveedor
        resources.ApplyResources(Me.txtCodigoProveedor, "txtCodigoProveedor")
        Me.txtCodigoProveedor.Name = "txtCodigoProveedor"
        Me.txtCodigoProveedor.ReadOnly = True
        '
        'lblCodigoProveedor
        '
        resources.ApplyResources(Me.lblCodigoProveedor, "lblCodigoProveedor")
        Me.lblCodigoProveedor.LabelAsoc = Nothing
        Me.lblCodigoProveedor.Name = "lblCodigoProveedor"
        '
        'lblNombreProv
        '
        resources.ApplyResources(Me.lblNombreProv, "lblNombreProv")
        Me.lblNombreProv.LabelAsoc = Nothing
        Me.lblNombreProv.Name = "lblNombreProv"
        '
        'TextBox2
        '
        Me.TextBox2.BindearPropiedadControl = "Text"
        Me.TextBox2.BindearPropiedadEntidad = "Proveedor.NombreProveedor"
        Me.TextBox2.ForeColorFocus = System.Drawing.Color.Red
        Me.TextBox2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.TextBox2.Formato = ""
        Me.TextBox2.IsDecimal = False
        Me.TextBox2.IsNumber = False
        Me.TextBox2.IsPK = False
        Me.TextBox2.IsRequired = False
        Me.TextBox2.Key = ""
        Me.TextBox2.LabelAsoc = Me.lblNombreProv
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        '
        'txtNroMovimientoEgreso
        '
        Me.txtNroMovimientoEgreso.BindearPropiedadControl = "Text"
        Me.txtNroMovimientoEgreso.BindearPropiedadEntidad = "NroMovimientoEgreso"
        Me.txtNroMovimientoEgreso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroMovimientoEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroMovimientoEgreso.Formato = ""
        Me.txtNroMovimientoEgreso.IsDecimal = False
        Me.txtNroMovimientoEgreso.IsNumber = True
        Me.txtNroMovimientoEgreso.IsPK = False
        Me.txtNroMovimientoEgreso.IsRequired = False
        Me.txtNroMovimientoEgreso.Key = Nothing
        Me.txtNroMovimientoEgreso.LabelAsoc = Me.lblMovimientoEgreso
        resources.ApplyResources(Me.txtNroMovimientoEgreso, "txtNroMovimientoEgreso")
        Me.txtNroMovimientoEgreso.Name = "txtNroMovimientoEgreso"
        Me.txtNroMovimientoEgreso.ReadOnly = True
        '
        'lblMovimientoEgreso
        '
        resources.ApplyResources(Me.lblMovimientoEgreso, "lblMovimientoEgreso")
        Me.lblMovimientoEgreso.LabelAsoc = Nothing
        Me.lblMovimientoEgreso.Name = "lblMovimientoEgreso"
        '
        'txtNroPlanillaEgreso
        '
        Me.txtNroPlanillaEgreso.BindearPropiedadControl = "Text"
        Me.txtNroPlanillaEgreso.BindearPropiedadEntidad = "NroPlanillaEgreso"
        Me.txtNroPlanillaEgreso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPlanillaEgreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPlanillaEgreso.Formato = ""
        Me.txtNroPlanillaEgreso.IsDecimal = False
        Me.txtNroPlanillaEgreso.IsNumber = True
        Me.txtNroPlanillaEgreso.IsPK = False
        Me.txtNroPlanillaEgreso.IsRequired = False
        Me.txtNroPlanillaEgreso.Key = Nothing
        Me.txtNroPlanillaEgreso.LabelAsoc = Me.lblPlanillaEgreso
        resources.ApplyResources(Me.txtNroPlanillaEgreso, "txtNroPlanillaEgreso")
        Me.txtNroPlanillaEgreso.Name = "txtNroPlanillaEgreso"
        Me.txtNroPlanillaEgreso.ReadOnly = True
        '
        'grbDetalle
        '
        Me.grbDetalle.Controls.Add(Me.TextBox1)
        Me.grbDetalle.Controls.Add(Me.Label3)
        Me.grbDetalle.Controls.Add(Me.lblSituacion)
        Me.grbDetalle.Controls.Add(Me.cmbSituacionCheque)
        Me.grbDetalle.Controls.Add(Me.txtNroOperacion)
        Me.grbDetalle.Controls.Add(Me.lblNroOperacion)
        Me.grbDetalle.Controls.Add(Me.lblTipoCheque)
        Me.grbDetalle.Controls.Add(Me.cmbTipoCheque)
        Me.grbDetalle.Controls.Add(Me.txtCUIT)
        Me.grbDetalle.Controls.Add(Me.lblCUIT)
        Me.grbDetalle.Controls.Add(Me.lnkLocalidad)
        Me.grbDetalle.Controls.Add(Me.bscCodigoLocalidad)
        Me.grbDetalle.Controls.Add(Me.bscNombreLocalidad)
        Me.grbDetalle.Controls.Add(Me.txtBancoSucursal)
        Me.grbDetalle.Controls.Add(Me.lblSucursalBanco)
        Me.grbDetalle.Controls.Add(Me.txtImporte)
        Me.grbDetalle.Controls.Add(Me.lblImporte)
        Me.grbDetalle.Controls.Add(Me.txtNumeroCheque)
        Me.grbDetalle.Controls.Add(Me.lblNumeroCheque)
        Me.grbDetalle.Controls.Add(Me.cmbBanco)
        Me.grbDetalle.Controls.Add(Me.lblBanco)
        Me.grbDetalle.Controls.Add(Me.dtpFechaCobro)
        Me.grbDetalle.Controls.Add(Me.lblFechaCobro)
        Me.grbDetalle.Controls.Add(Me.dtpFechaEmision)
        Me.grbDetalle.Controls.Add(Me.lblFechaEmision)
        Me.grbDetalle.Controls.Add(Me.txtTitular)
        Me.grbDetalle.Controls.Add(Me.lblTitular)
        resources.ApplyResources(Me.grbDetalle, "grbDetalle")
        Me.grbDetalle.Name = "grbDetalle"
        Me.grbDetalle.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.BindearPropiedadControl = "Text"
        Me.TextBox1.BindearPropiedadEntidad = "Observacion"
        Me.TextBox1.ForeColorFocus = System.Drawing.Color.Red
        Me.TextBox1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.TextBox1.Formato = ""
        Me.TextBox1.IsDecimal = False
        Me.TextBox1.IsNumber = False
        Me.TextBox1.IsPK = False
        Me.TextBox1.IsRequired = False
        Me.TextBox1.Key = "Titular"
        Me.TextBox1.LabelAsoc = Me.Label3
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Name = "Label3"
        '
        'lblSituacion
        '
        resources.ApplyResources(Me.lblSituacion, "lblSituacion")
        Me.lblSituacion.LabelAsoc = Nothing
        Me.lblSituacion.Name = "lblSituacion"
        '
        'cmbSituacionCheque
        '
        Me.cmbSituacionCheque.BindearPropiedadControl = "SelectedValue"
        Me.cmbSituacionCheque.BindearPropiedadEntidad = "IdSituacionCheque"
        Me.cmbSituacionCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSituacionCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSituacionCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSituacionCheque.FormattingEnabled = True
        Me.cmbSituacionCheque.IsPK = False
        Me.cmbSituacionCheque.IsRequired = False
        Me.cmbSituacionCheque.Key = Nothing
        Me.cmbSituacionCheque.LabelAsoc = Nothing
        resources.ApplyResources(Me.cmbSituacionCheque, "cmbSituacionCheque")
        Me.cmbSituacionCheque.Name = "cmbSituacionCheque"
        '
        'txtNroOperacion
        '
        Me.txtNroOperacion.BindearPropiedadControl = "Text"
        Me.txtNroOperacion.BindearPropiedadEntidad = "NroOperacion"
        resources.ApplyResources(Me.txtNroOperacion, "txtNroOperacion")
        Me.txtNroOperacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroOperacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroOperacion.Formato = ""
        Me.txtNroOperacion.IsDecimal = False
        Me.txtNroOperacion.IsNumber = False
        Me.txtNroOperacion.IsPK = False
        Me.txtNroOperacion.IsRequired = False
        Me.txtNroOperacion.Key = ""
        Me.txtNroOperacion.LabelAsoc = Nothing
        Me.txtNroOperacion.Name = "txtNroOperacion"
        '
        'lblNroOperacion
        '
        resources.ApplyResources(Me.lblNroOperacion, "lblNroOperacion")
        Me.lblNroOperacion.Name = "lblNroOperacion"
        '
        'lblTipoCheque
        '
        resources.ApplyResources(Me.lblTipoCheque, "lblTipoCheque")
        Me.lblTipoCheque.LabelAsoc = Nothing
        Me.lblTipoCheque.Name = "lblTipoCheque"
        '
        'cmbTipoCheque
        '
        Me.cmbTipoCheque.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoCheque.BindearPropiedadEntidad = "IdTipoCheque"
        Me.cmbTipoCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoCheque.FormattingEnabled = True
        Me.cmbTipoCheque.IsPK = False
        Me.cmbTipoCheque.IsRequired = False
        Me.cmbTipoCheque.Key = Nothing
        Me.cmbTipoCheque.LabelAsoc = Nothing
        resources.ApplyResources(Me.cmbTipoCheque, "cmbTipoCheque")
        Me.cmbTipoCheque.Name = "cmbTipoCheque"
        '
        'txtCUIT
        '
        Me.txtCUIT.BindearPropiedadControl = "Text"
        Me.txtCUIT.BindearPropiedadEntidad = "Cuit"
        Me.txtCUIT.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCUIT.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCUIT.Formato = ""
        Me.txtCUIT.IsDecimal = False
        Me.txtCUIT.IsNumber = True
        Me.txtCUIT.IsPK = False
        Me.txtCUIT.IsRequired = True
        Me.txtCUIT.Key = ""
        Me.txtCUIT.LabelAsoc = Me.lblCUIT
        resources.ApplyResources(Me.txtCUIT, "txtCUIT")
        Me.txtCUIT.Name = "txtCUIT"
        '
        'lblCUIT
        '
        resources.ApplyResources(Me.lblCUIT, "lblCUIT")
        Me.lblCUIT.LabelAsoc = Nothing
        Me.lblCUIT.Name = "lblCUIT"
        '
        'lnkLocalidad
        '
        resources.ApplyResources(Me.lnkLocalidad, "lnkLocalidad")
        Me.lnkLocalidad.LabelAsoc = Nothing
        Me.lnkLocalidad.Name = "lnkLocalidad"
        Me.lnkLocalidad.TabStop = True
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.AyudaAncho = 608
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "Localidad.IdLocalidad"
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
        resources.ApplyResources(Me.bscCodigoLocalidad, "bscCodigoLocalidad")
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = True
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Titulo = Nothing
        '
        'bscNombreLocalidad
        '
        resources.ApplyResources(Me.bscNombreLocalidad, "bscNombreLocalidad")
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
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = True
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Titulo = Nothing
        '
        'txtBancoSucursal
        '
        Me.txtBancoSucursal.BindearPropiedadControl = "Text"
        Me.txtBancoSucursal.BindearPropiedadEntidad = "IdBancoSucursal"
        Me.txtBancoSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancoSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancoSucursal.Formato = ""
        Me.txtBancoSucursal.IsDecimal = False
        Me.txtBancoSucursal.IsNumber = True
        Me.txtBancoSucursal.IsPK = False
        Me.txtBancoSucursal.IsRequired = True
        Me.txtBancoSucursal.Key = ""
        Me.txtBancoSucursal.LabelAsoc = Me.lblSucursalBanco
        resources.ApplyResources(Me.txtBancoSucursal, "txtBancoSucursal")
        Me.txtBancoSucursal.Name = "txtBancoSucursal"
        '
        'lblSucursalBanco
        '
        resources.ApplyResources(Me.lblSucursalBanco, "lblSucursalBanco")
        Me.lblSucursalBanco.LabelAsoc = Nothing
        Me.lblSucursalBanco.Name = "lblSucursalBanco"
        '
        'txtImporte
        '
        Me.txtImporte.BindearPropiedadControl = "Text"
        Me.txtImporte.BindearPropiedadEntidad = "Importe"
        Me.txtImporte.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporte.Formato = "#,##0.00"
        Me.txtImporte.IsDecimal = True
        Me.txtImporte.IsNumber = True
        Me.txtImporte.IsPK = True
        Me.txtImporte.IsRequired = True
        Me.txtImporte.Key = ""
        Me.txtImporte.LabelAsoc = Me.lblImporte
        resources.ApplyResources(Me.txtImporte, "txtImporte")
        Me.txtImporte.Name = "txtImporte"
        '
        'lblImporte
        '
        resources.ApplyResources(Me.lblImporte, "lblImporte")
        Me.lblImporte.LabelAsoc = Nothing
        Me.lblImporte.Name = "lblImporte"
        '
        'txtNumeroCheque
        '
        Me.txtNumeroCheque.BindearPropiedadControl = "Text"
        Me.txtNumeroCheque.BindearPropiedadEntidad = "NumeroCheque"
        Me.txtNumeroCheque.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCheque.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCheque.Formato = ""
        Me.txtNumeroCheque.IsDecimal = False
        Me.txtNumeroCheque.IsNumber = True
        Me.txtNumeroCheque.IsPK = True
        Me.txtNumeroCheque.IsRequired = True
        Me.txtNumeroCheque.Key = ""
        Me.txtNumeroCheque.LabelAsoc = Me.lblNumeroCheque
        resources.ApplyResources(Me.txtNumeroCheque, "txtNumeroCheque")
        Me.txtNumeroCheque.Name = "txtNumeroCheque"
        '
        'lblNumeroCheque
        '
        resources.ApplyResources(Me.lblNumeroCheque, "lblNumeroCheque")
        Me.lblNumeroCheque.LabelAsoc = Nothing
        Me.lblNumeroCheque.Name = "lblNumeroCheque"
        '
        'cmbBanco
        '
        Me.cmbBanco.BindearPropiedadControl = "SelectedValue"
        Me.cmbBanco.BindearPropiedadEntidad = "Banco.idBanco"
        Me.cmbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBanco.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbBanco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.IsPK = False
        Me.cmbBanco.IsRequired = True
        Me.cmbBanco.Key = Nothing
        Me.cmbBanco.LabelAsoc = Me.lblBanco
        resources.ApplyResources(Me.cmbBanco, "cmbBanco")
        Me.cmbBanco.Name = "cmbBanco"
        '
        'lblBanco
        '
        resources.ApplyResources(Me.lblBanco, "lblBanco")
        Me.lblBanco.LabelAsoc = Nothing
        Me.lblBanco.Name = "lblBanco"
        '
        'grbEstado
        '
        Me.grbEstado.Controls.Add(Me.txtEstadoActualAnt)
        Me.grbEstado.Controls.Add(Me.lblEstadoAnterior)
        Me.grbEstado.Controls.Add(Me.txtEstadoActual)
        Me.grbEstado.Controls.Add(Me.lblEstadoActual)
        resources.ApplyResources(Me.grbEstado, "grbEstado")
        Me.grbEstado.Name = "grbEstado"
        Me.grbEstado.TabStop = False
        '
        'txtEstadoActualAnt
        '
        Me.txtEstadoActualAnt.BindearPropiedadControl = "Text"
        Me.txtEstadoActualAnt.BindearPropiedadEntidad = "IdEstadoChequeAnt"
        Me.txtEstadoActualAnt.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstadoActualAnt.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstadoActualAnt.Formato = ""
        Me.txtEstadoActualAnt.IsDecimal = False
        Me.txtEstadoActualAnt.IsNumber = False
        Me.txtEstadoActualAnt.IsPK = False
        Me.txtEstadoActualAnt.IsRequired = False
        Me.txtEstadoActualAnt.Key = Nothing
        Me.txtEstadoActualAnt.LabelAsoc = Me.lblEstadoAnterior
        resources.ApplyResources(Me.txtEstadoActualAnt, "txtEstadoActualAnt")
        Me.txtEstadoActualAnt.Name = "txtEstadoActualAnt"
        Me.txtEstadoActualAnt.ReadOnly = True
        '
        'lblEstadoAnterior
        '
        resources.ApplyResources(Me.lblEstadoAnterior, "lblEstadoAnterior")
        Me.lblEstadoAnterior.LabelAsoc = Nothing
        Me.lblEstadoAnterior.Name = "lblEstadoAnterior"
        '
        'txtEstadoActual
        '
        Me.txtEstadoActual.BindearPropiedadControl = "Text"
        Me.txtEstadoActual.BindearPropiedadEntidad = "IdEstadoCheque"
        Me.txtEstadoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstadoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstadoActual.Formato = ""
        Me.txtEstadoActual.IsDecimal = False
        Me.txtEstadoActual.IsNumber = False
        Me.txtEstadoActual.IsPK = False
        Me.txtEstadoActual.IsRequired = False
        Me.txtEstadoActual.Key = ""
        Me.txtEstadoActual.LabelAsoc = Me.lblEstadoActual
        resources.ApplyResources(Me.txtEstadoActual, "txtEstadoActual")
        Me.txtEstadoActual.Name = "txtEstadoActual"
        Me.txtEstadoActual.ReadOnly = True
        '
        'lblEstadoActual
        '
        resources.ApplyResources(Me.lblEstadoActual, "lblEstadoActual")
        Me.lblEstadoActual.LabelAsoc = Nothing
        Me.lblEstadoActual.Name = "lblEstadoActual"
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.tbpDetalle)
        Me.TabControl1.Controls.Add(Me.tbpCaja)
        Me.TabControl1.Controls.Add(Me.tbpImagenes)
        Me.TabControl1.Controls.Add(Me.tbpIngresoCaja)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'tbpDetalle
        '
        Me.tbpDetalle.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDetalle.Controls.Add(Me.grbDetalle)
        Me.tbpDetalle.Controls.Add(Me.grbEstado)
        resources.ApplyResources(Me.tbpDetalle, "tbpDetalle")
        Me.tbpDetalle.Name = "tbpDetalle"
        '
        'tbpCaja
        '
        Me.tbpCaja.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCaja.Controls.Add(Me.GroupBox3)
        Me.tbpCaja.Controls.Add(Me.GroupBox1)
        Me.tbpCaja.Controls.Add(Me.grbMovimientosDeCaja)
        resources.ApplyResources(Me.tbpCaja, "tbpCaja")
        Me.tbpCaja.Name = "tbpCaja"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chbProveedor)
        Me.GroupBox3.Controls.Add(Me.bscCodigoProveedor)
        Me.GroupBox3.Controls.Add(Me.bscProveedor)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label7)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'chbProveedor
        '
        resources.ApplyResources(Me.chbProveedor, "chbProveedor")
        Me.chbProveedor.BindearPropiedadControl = Nothing
        Me.chbProveedor.BindearPropiedadEntidad = Nothing
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.AyudaAncho = 608
        Me.bscCodigoProveedor.BindearPropiedadControl = ""
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ColumnasAlineacion = Nothing
        Me.bscCodigoProveedor.ColumnasAncho = Nothing
        Me.bscCodigoProveedor.ColumnasFormato = Nothing
        Me.bscCodigoProveedor.ColumnasOcultas = Nothing
        Me.bscCodigoProveedor.ColumnasTitulos = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        resources.ApplyResources(Me.bscCodigoProveedor, "bscCodigoProveedor")
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = True
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Me.Label1
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = True
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Titulo = Nothing
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Name = "Label1"
        '
        'bscProveedor
        '
        resources.ApplyResources(Me.bscProveedor, "bscProveedor")
        Me.bscProveedor.AyudaAncho = 608
        Me.bscProveedor.BindearPropiedadControl = Nothing
        Me.bscProveedor.BindearPropiedadEntidad = Nothing
        Me.bscProveedor.ColumnasAlineacion = Nothing
        Me.bscProveedor.ColumnasAncho = Nothing
        Me.bscProveedor.ColumnasFormato = Nothing
        Me.bscProveedor.ColumnasOcultas = Nothing
        Me.bscProveedor.ColumnasTitulos = Nothing
        Me.bscProveedor.Datos = Nothing
        Me.bscProveedor.FilaDevuelta = Nothing
        Me.bscProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProveedor.IsDecimal = False
        Me.bscProveedor.IsNumber = False
        Me.bscProveedor.IsPK = False
        Me.bscProveedor.IsRequired = False
        Me.bscProveedor.Key = ""
        Me.bscProveedor.LabelAsoc = Me.Label2
        Me.bscProveedor.MaxLengh = "32767"
        Me.bscProveedor.Name = "bscProveedor"
        Me.bscProveedor.Permitido = True
        Me.bscProveedor.Selecciono = False
        Me.bscProveedor.Titulo = Nothing
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Name = "Label2"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.LabelAsoc = Nothing
        Me.Label7.Name = "Label7"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNroPlanillaEgreso)
        Me.GroupBox1.Controls.Add(Me.lblEgreso)
        Me.GroupBox1.Controls.Add(Me.lblPlanillaEgreso)
        Me.GroupBox1.Controls.Add(Me.IdCajaEgreso)
        Me.GroupBox1.Controls.Add(Me.lblMovimientoEgreso)
        Me.GroupBox1.Controls.Add(Me.txtNroMovimientoEgreso)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.lblNombreProv)
        Me.GroupBox1.Controls.Add(Me.txtNombreCajaEgreso)
        Me.GroupBox1.Controls.Add(Me.lblCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.lblCajaEgreso)
        Me.GroupBox1.Controls.Add(Me.txtCodigoProveedor)
        Me.GroupBox1.Controls.Add(Me.lblProveedor)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'tbpImagenes
        '
        Me.tbpImagenes.BackColor = System.Drawing.SystemColors.Control
        Me.tbpImagenes.Controls.Add(Me.rbtDorso)
        Me.tbpImagenes.Controls.Add(Me.rbtFrente)
        Me.tbpImagenes.Controls.Add(Me.tstBarra)
        Me.tbpImagenes.Controls.Add(Me.PcbChequeDorso)
        Me.tbpImagenes.Controls.Add(Me.pcbChequeFrente)
        resources.ApplyResources(Me.tbpImagenes, "tbpImagenes")
        Me.tbpImagenes.Name = "tbpImagenes"
        '
        'rbtDorso
        '
        resources.ApplyResources(Me.rbtDorso, "rbtDorso")
        Me.rbtDorso.Name = "rbtDorso"
        Me.rbtDorso.UseVisualStyleBackColor = True
        '
        'rbtFrente
        '
        resources.ApplyResources(Me.rbtFrente, "rbtFrente")
        Me.rbtFrente.Checked = True
        Me.rbtFrente.Name = "rbtFrente"
        Me.rbtFrente.TabStop = True
        Me.rbtFrente.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbBuscar, Me.ToolStripSeparator2, Me.tsbLimpiar, Me.ToolStripSeparator1, Me.tsbGuardar})
        resources.ApplyResources(Me.tstBarra, "tstBarra")
        Me.tstBarra.Name = "tstBarra"
        '
        'tsbBuscar
        '
        Me.tsbBuscar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
        resources.ApplyResources(Me.tsbBuscar, "tsbBuscar")
        Me.tsbBuscar.Name = "tsbBuscar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'tsbLimpiar
        '
        Me.tsbLimpiar.Image = Global.Eniac.Win.My.Resources.Resources.brush3
        resources.ApplyResources(Me.tsbLimpiar, "tsbLimpiar")
        Me.tsbLimpiar.Name = "tsbLimpiar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'tsbGuardar
        '
        Me.tsbGuardar.Image = Global.Eniac.Win.My.Resources.Resources.harddisk_add
        resources.ApplyResources(Me.tsbGuardar, "tsbGuardar")
        Me.tsbGuardar.Name = "tsbGuardar"
        '
        'PcbChequeDorso
        '
        Me.PcbChequeDorso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.PcbChequeDorso, "PcbChequeDorso")
        Me.PcbChequeDorso.Name = "PcbChequeDorso"
        Me.PcbChequeDorso.TabStop = False
        '
        'pcbChequeFrente
        '
        Me.pcbChequeFrente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        resources.ApplyResources(Me.pcbChequeFrente, "pcbChequeFrente")
        Me.pcbChequeFrente.Name = "pcbChequeFrente"
        Me.pcbChequeFrente.TabStop = False
        '
        'tbpIngresoCaja
        '
        Me.tbpIngresoCaja.BackColor = System.Drawing.SystemColors.Control
        Me.tbpIngresoCaja.Controls.Add(Me.GroupBox2)
        resources.ApplyResources(Me.tbpIngresoCaja, "tbpIngresoCaja")
        Me.tbpIngresoCaja.Name = "tbpIngresoCaja"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLimpiarIngresoEnCaja)
        Me.GroupBox2.Controls.Add(Me.txtObservaciones)
        Me.GroupBox2.Controls.Add(Me.lblObsdervaciones)
        Me.GroupBox2.Controls.Add(Me.lblTipoMovimiento)
        Me.GroupBox2.Controls.Add(Me.txtTipoMovimiento)
        Me.GroupBox2.Controls.Add(Me.lblPlanillaActual)
        Me.GroupBox2.Controls.Add(Me.txtNMovimiento)
        Me.GroupBox2.Controls.Add(Me.lblNMovimientoActual)
        Me.GroupBox2.Controls.Add(Me.txtPlanillaActual)
        Me.GroupBox2.Controls.Add(Me.cmbCentroCosto)
        Me.GroupBox2.Controls.Add(Me.lblCentroCosto)
        Me.GroupBox2.Controls.Add(Me.bscNombreCuentaCaja)
        Me.GroupBox2.Controls.Add(Me.bscCuentaCaja)
        Me.GroupBox2.Controls.Add(Me.lblNombreCuenta)
        Me.GroupBox2.Controls.Add(Me.lblCuenta)
        Me.GroupBox2.Controls.Add(Me.dtpFechaIngresoCaja)
        Me.GroupBox2.Controls.Add(Me.lblFechaIngresoCaja)
        Me.GroupBox2.Controls.Add(Me.cmbCaja)
        Me.GroupBox2.Controls.Add(Me.lblCaja)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'btnLimpiarIngresoEnCaja
        '
        Me.btnLimpiarIngresoEnCaja.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        resources.ApplyResources(Me.btnLimpiarIngresoEnCaja, "btnLimpiarIngresoEnCaja")
        Me.btnLimpiarIngresoEnCaja.Name = "btnLimpiarIngresoEnCaja"
        Me.btnLimpiarIngresoEnCaja.TabStop = False
        Me.btnLimpiarIngresoEnCaja.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BindearPropiedadControl = ""
        Me.txtObservaciones.BindearPropiedadEntidad = ""
        Me.txtObservaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservaciones.Formato = ""
        Me.txtObservaciones.IsDecimal = False
        Me.txtObservaciones.IsNumber = False
        Me.txtObservaciones.IsPK = False
        Me.txtObservaciones.IsRequired = False
        Me.txtObservaciones.Key = "Titular"
        Me.txtObservaciones.LabelAsoc = Me.lblObsdervaciones
        resources.ApplyResources(Me.txtObservaciones, "txtObservaciones")
        Me.txtObservaciones.Name = "txtObservaciones"
        '
        'lblObsdervaciones
        '
        resources.ApplyResources(Me.lblObsdervaciones, "lblObsdervaciones")
        Me.lblObsdervaciones.LabelAsoc = Nothing
        Me.lblObsdervaciones.Name = "lblObsdervaciones"
        '
        'lblTipoMovimiento
        '
        resources.ApplyResources(Me.lblTipoMovimiento, "lblTipoMovimiento")
        Me.lblTipoMovimiento.LabelAsoc = Nothing
        Me.lblTipoMovimiento.Name = "lblTipoMovimiento"
        '
        'txtTipoMovimiento
        '
        resources.ApplyResources(Me.txtTipoMovimiento, "txtTipoMovimiento")
        Me.txtTipoMovimiento.BindearPropiedadControl = ""
        Me.txtTipoMovimiento.BindearPropiedadEntidad = ""
        Me.txtTipoMovimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoMovimiento.IsDecimal = False
        Me.txtTipoMovimiento.IsNumber = True
        Me.txtTipoMovimiento.IsPK = False
        Me.txtTipoMovimiento.IsRequired = False
        Me.txtTipoMovimiento.Key = ""
        Me.txtTipoMovimiento.LabelAsoc = Me.lblPlanillaActual
        Me.txtTipoMovimiento.Name = "txtTipoMovimiento"
        Me.txtTipoMovimiento.ReadOnly = True
        Me.txtTipoMovimiento.TabStop = False
        '
        'lblPlanillaActual
        '
        resources.ApplyResources(Me.lblPlanillaActual, "lblPlanillaActual")
        Me.lblPlanillaActual.LabelAsoc = Nothing
        Me.lblPlanillaActual.Name = "lblPlanillaActual"
        '
        'txtNMovimiento
        '
        resources.ApplyResources(Me.txtNMovimiento, "txtNMovimiento")
        Me.txtNMovimiento.BindearPropiedadControl = ""
        Me.txtNMovimiento.BindearPropiedadEntidad = ""
        Me.txtNMovimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNMovimiento.IsDecimal = False
        Me.txtNMovimiento.IsNumber = True
        Me.txtNMovimiento.IsPK = False
        Me.txtNMovimiento.IsRequired = False
        Me.txtNMovimiento.Key = ""
        Me.txtNMovimiento.LabelAsoc = Me.lblNMovimientoActual
        Me.txtNMovimiento.Name = "txtNMovimiento"
        Me.txtNMovimiento.ReadOnly = True
        Me.txtNMovimiento.TabStop = False
        '
        'lblNMovimientoActual
        '
        resources.ApplyResources(Me.lblNMovimientoActual, "lblNMovimientoActual")
        Me.lblNMovimientoActual.LabelAsoc = Nothing
        Me.lblNMovimientoActual.Name = "lblNMovimientoActual"
        '
        'txtPlanillaActual
        '
        resources.ApplyResources(Me.txtPlanillaActual, "txtPlanillaActual")
        Me.txtPlanillaActual.BindearPropiedadControl = ""
        Me.txtPlanillaActual.BindearPropiedadEntidad = ""
        Me.txtPlanillaActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPlanillaActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPlanillaActual.IsDecimal = False
        Me.txtPlanillaActual.IsNumber = True
        Me.txtPlanillaActual.IsPK = False
        Me.txtPlanillaActual.IsRequired = False
        Me.txtPlanillaActual.Key = ""
        Me.txtPlanillaActual.LabelAsoc = Me.lblPlanillaActual
        Me.txtPlanillaActual.Name = "txtPlanillaActual"
        Me.txtPlanillaActual.ReadOnly = True
        Me.txtPlanillaActual.TabStop = False
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.BindearPropiedadControl = ""
        Me.cmbCentroCosto.BindearPropiedadEntidad = ""
        Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbCentroCosto, "cmbCentroCosto")
        Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.IsPK = False
        Me.cmbCentroCosto.IsRequired = False
        Me.cmbCentroCosto.Key = Nothing
        Me.cmbCentroCosto.LabelAsoc = Me.lblCentroCosto
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        '
        'lblCentroCosto
        '
        resources.ApplyResources(Me.lblCentroCosto, "lblCentroCosto")
        Me.lblCentroCosto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCentroCosto.LabelAsoc = Nothing
        Me.lblCentroCosto.Name = "lblCentroCosto"
        '
        'bscNombreCuentaCaja
        '
        resources.ApplyResources(Me.bscNombreCuentaCaja, "bscNombreCuentaCaja")
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
        Me.bscNombreCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCuentaCaja.IsDecimal = False
        Me.bscNombreCuentaCaja.IsNumber = False
        Me.bscNombreCuentaCaja.IsPK = False
        Me.bscNombreCuentaCaja.IsRequired = False
        Me.bscNombreCuentaCaja.Key = ""
        Me.bscNombreCuentaCaja.LabelAsoc = Me.lblNombreCuenta
        Me.bscNombreCuentaCaja.MaxLengh = "32767"
        Me.bscNombreCuentaCaja.Name = "bscNombreCuentaCaja"
        Me.bscNombreCuentaCaja.Permitido = True
        Me.bscNombreCuentaCaja.Selecciono = False
        Me.bscNombreCuentaCaja.Titulo = Nothing
        '
        'lblNombreCuenta
        '
        resources.ApplyResources(Me.lblNombreCuenta, "lblNombreCuenta")
        Me.lblNombreCuenta.LabelAsoc = Nothing
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        '
        'bscCuentaCaja
        '
        Me.bscCuentaCaja.AyudaAncho = 608
        Me.bscCuentaCaja.BindearPropiedadControl = ""
        Me.bscCuentaCaja.BindearPropiedadEntidad = ""
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
        Me.bscCuentaCaja.IsNumber = False
        Me.bscCuentaCaja.IsPK = False
        Me.bscCuentaCaja.IsRequired = False
        Me.bscCuentaCaja.Key = ""
        Me.bscCuentaCaja.LabelAsoc = Nothing
        resources.ApplyResources(Me.bscCuentaCaja, "bscCuentaCaja")
        Me.bscCuentaCaja.MaxLengh = "32767"
        Me.bscCuentaCaja.Name = "bscCuentaCaja"
        Me.bscCuentaCaja.Permitido = True
        Me.bscCuentaCaja.Selecciono = False
        Me.bscCuentaCaja.Titulo = Nothing
        '
        'lblCuenta
        '
        resources.ApplyResources(Me.lblCuenta, "lblCuenta")
        Me.lblCuenta.LabelAsoc = Nothing
        Me.lblCuenta.Name = "lblCuenta"
        '
        'dtpFechaIngresoCaja
        '
        Me.dtpFechaIngresoCaja.BindearPropiedadControl = ""
        Me.dtpFechaIngresoCaja.BindearPropiedadEntidad = ""
        resources.ApplyResources(Me.dtpFechaIngresoCaja, "dtpFechaIngresoCaja")
        Me.dtpFechaIngresoCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaIngresoCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaIngresoCaja.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaIngresoCaja.IsPK = False
        Me.dtpFechaIngresoCaja.IsRequired = False
        Me.dtpFechaIngresoCaja.Key = ""
        Me.dtpFechaIngresoCaja.LabelAsoc = Me.lblFechaIngresoCaja
        Me.dtpFechaIngresoCaja.Name = "dtpFechaIngresoCaja"
        Me.dtpFechaIngresoCaja.Value = New Date(2008, 10, 28, 0, 29, 13, 0)
        '
        'lblFechaIngresoCaja
        '
        resources.ApplyResources(Me.lblFechaIngresoCaja, "lblFechaIngresoCaja")
        Me.lblFechaIngresoCaja.LabelAsoc = Nothing
        Me.lblFechaIngresoCaja.Name = "lblFechaIngresoCaja"
        '
        'cmbCaja
        '
        Me.cmbCaja.BindearPropiedadControl = ""
        Me.cmbCaja.BindearPropiedadEntidad = ""
        Me.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.IsPK = True
        Me.cmbCaja.IsRequired = False
        Me.cmbCaja.Key = Nothing
        Me.cmbCaja.LabelAsoc = Me.lblCaja
        resources.ApplyResources(Me.cmbCaja, "cmbCaja")
        Me.cmbCaja.Name = "cmbCaja"
        '
        'lblCaja
        '
        resources.ApplyResources(Me.lblCaja, "lblCaja")
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Name = "lblCaja"
        '
        'ofdArchivos
        '
        resources.ApplyResources(Me.ofdArchivos, "ofdArchivos")
        '
        'btnIngresoPorCaja
        '
        resources.ApplyResources(Me.btnIngresoPorCaja, "btnIngresoPorCaja")
        Me.btnIngresoPorCaja.Image = Global.Eniac.Win.My.Resources.Resources.cashier
        Me.btnIngresoPorCaja.Name = "btnIngresoPorCaja"
        Me.btnIngresoPorCaja.UseVisualStyleBackColor = True
        '
        'ChequesDeTercerosDetalle
        '
        Me.AcceptButton = Nothing
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnIngresoPorCaja)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.Name = "ChequesDeTercerosDetalle"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnIngresoPorCaja, 0)
        Me.grbMovimientosDeCaja.ResumeLayout(False)
        Me.grbMovimientosDeCaja.PerformLayout()
        Me.grbDetalle.ResumeLayout(False)
        Me.grbDetalle.PerformLayout()
        Me.grbEstado.ResumeLayout(False)
        Me.grbEstado.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tbpDetalle.ResumeLayout(False)
        Me.tbpCaja.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbpImagenes.ResumeLayout(False)
        Me.tbpImagenes.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.PcbChequeDorso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbChequeFrente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpIngresoCaja.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitular As Eniac.Controles.Label
   Friend WithEvents txtTitular As Eniac.Controles.TextBox
   Friend WithEvents lblPlanillaIngreso As Eniac.Controles.Label
   Friend WithEvents txtNroPlanillaIngreso As Eniac.Controles.TextBox
   Friend WithEvents lblFechaCobro As Eniac.Controles.Label
   Friend WithEvents dtpFechaCobro As Eniac.Controles.DateTimePicker
   Friend WithEvents dtpFechaEmision As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaEmision As Eniac.Controles.Label
   Friend WithEvents grbMovimientosDeCaja As System.Windows.Forms.GroupBox
   Friend WithEvents grbDetalle As System.Windows.Forms.GroupBox
   Friend WithEvents txtNroMovimientoIngreso As Eniac.Controles.TextBox
   Friend WithEvents lblMovimientoIngreso As Eniac.Controles.Label
   Friend WithEvents txtNroMovimientoEgreso As Eniac.Controles.TextBox
   Friend WithEvents lblMovimientoEgreso As Eniac.Controles.Label
   Friend WithEvents txtNroPlanillaEgreso As Eniac.Controles.TextBox
   Friend WithEvents lblPlanillaEgreso As Eniac.Controles.Label
   Friend WithEvents cmbBanco As Eniac.Controles.ComboBox
   Friend WithEvents lblBanco As Eniac.Controles.Label
   Friend WithEvents txtNumeroCheque As Eniac.Controles.TextBox
   Friend WithEvents lblNumeroCheque As Eniac.Controles.Label
   Friend WithEvents txtImporte As Eniac.Controles.TextBox
   Friend WithEvents lblImporte As Eniac.Controles.Label
   Friend WithEvents txtBancoSucursal As Eniac.Controles.TextBox
   Friend WithEvents lblSucursalBanco As Eniac.Controles.Label
   Friend WithEvents grbEstado As System.Windows.Forms.GroupBox
   Friend WithEvents txtEstadoActualAnt As Eniac.Controles.TextBox
   Friend WithEvents lblEstadoAnterior As Eniac.Controles.Label
   Friend WithEvents txtEstadoActual As Eniac.Controles.TextBox
   Friend WithEvents lblEstadoActual As Eniac.Controles.Label
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents txtCodigoCliente As Eniac.Controles.TextBox
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents lblCliente As Eniac.Controles.Label
   Friend WithEvents txtCodigoProveedor As Eniac.Controles.TextBox
   Friend WithEvents lblCodigoProveedor As Eniac.Controles.Label
   Friend WithEvents lblNombreProv As Eniac.Controles.Label
   Friend WithEvents TextBox2 As Eniac.Controles.TextBox
   Friend WithEvents lblProveedor As Eniac.Controles.Label
   Friend WithEvents lnkLocalidad As Eniac.Controles.LinkLabel
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Friend WithEvents txtCUIT As Eniac.Controles.TextBox
   Friend WithEvents lblCUIT As Eniac.Controles.Label
   Friend WithEvents lblIngreso As Eniac.Controles.Label
   Friend WithEvents lblEgreso As Eniac.Controles.Label
   Friend WithEvents IdCajaEgreso As Eniac.Controles.TextBox
   Friend WithEvents txtCajaIngreso As Eniac.Controles.TextBox
   Friend WithEvents txtNombreCajaIngreso As Eniac.Controles.TextBox
   Friend WithEvents lblCajaIngreso As Eniac.Controles.Label
   Friend WithEvents txtNombreCajaEgreso As Eniac.Controles.TextBox
   Friend WithEvents lblCajaEgreso As Eniac.Controles.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents tbpDetalle As System.Windows.Forms.TabPage
   Friend WithEvents tbpCaja As System.Windows.Forms.TabPage
   Friend WithEvents tbpImagenes As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents PcbChequeDorso As System.Windows.Forms.PictureBox
   Friend WithEvents pcbChequeFrente As System.Windows.Forms.PictureBox
   Friend WithEvents ofdArchivos As System.Windows.Forms.OpenFileDialog
   Friend WithEvents rbtDorso As System.Windows.Forms.RadioButton
   Friend WithEvents rbtFrente As System.Windows.Forms.RadioButton
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbBuscar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbGuardar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbLimpiar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tbpIngresoCaja As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents bscNombreCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents lblNombreCuenta As Eniac.Controles.Label
   Friend WithEvents bscCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents lblCuenta As Eniac.Controles.Label
   Friend WithEvents dtpFechaIngresoCaja As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaIngresoCaja As Eniac.Controles.Label
   Friend WithEvents cmbCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents btnIngresoPorCaja As Eniac.Controles.Button
   Friend WithEvents cmbCentroCosto As Eniac.Controles.ComboBox
   Friend WithEvents lblCentroCosto As Eniac.Controles.Label
   Friend WithEvents lblPlanillaActual As Eniac.Controles.Label
   Friend WithEvents txtNMovimiento As Eniac.Controles.MaskedTextBox
   Friend WithEvents lblNMovimientoActual As Eniac.Controles.Label
   Friend WithEvents txtPlanillaActual As Eniac.Controles.MaskedTextBox
   Friend WithEvents lblTipoMovimiento As Eniac.Controles.Label
   Friend WithEvents txtTipoMovimiento As Eniac.Controles.MaskedTextBox
   Friend WithEvents txtObservaciones As Eniac.Controles.TextBox
   Friend WithEvents lblObsdervaciones As Eniac.Controles.Label
   Friend WithEvents btnLimpiarIngresoEnCaja As Eniac.Controles.Button
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents chbProveedor As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoProveedor As Eniac.Controles.Buscador
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents bscProveedor As Eniac.Controles.Buscador
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents lblTipoCheque As Eniac.Controles.Label
   Friend WithEvents txtNroOperacion As Eniac.Controles.TextBox
   Friend WithEvents lblNroOperacion As System.Windows.Forms.Label
   Friend WithEvents cmbTipoCheque As Eniac.Controles.ComboBox
    Friend WithEvents lblSituacion As Controles.Label
    Friend WithEvents cmbSituacionCheque As Controles.ComboBox
    Friend WithEvents TextBox1 As Controles.TextBox
    Friend WithEvents Label3 As Controles.Label
End Class
