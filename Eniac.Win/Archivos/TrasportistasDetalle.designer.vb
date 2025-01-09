<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransportistasDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransportistasDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.txtDireccion = New Eniac.Controles.TextBox()
      Me.lblCuit = New Eniac.Controles.Label()
      Me.txtCuit = New Eniac.Controles.TextBox()
      Me.lblTelefono = New Eniac.Controles.Label()
      Me.txtTelefono = New Eniac.Controles.TextBox()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.lblCategoriaFiscal = New Eniac.Controles.Label()
      Me.cmbCategoriaFiscal = New Eniac.Controles.ComboBox()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
      Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
      Me.lnkLocalidad = New Eniac.Controles.LinkLabel()
      Me.txtCantidadKilos = New Eniac.Controles.TextBox()
      Me.lblCantidadKilos = New Eniac.Controles.Label()
      Me.txtCantidadPalets = New Eniac.Controles.TextBox()
      Me.lblCantidadPalets = New Eniac.Controles.Label()
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(217, 321)
      Me.btnAceptar.TabIndex = 22
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(303, 321)
      Me.btnCancelar.TabIndex = 23
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(85, 321)
      Me.btnCopiar.TabIndex = 25
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(28, 321)
      Me.btnAplicar.TabIndex = 24
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(19, 44)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreTransportista"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(99, 41)
      Me.txtNombre.MaxLength = 100
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(289, 20)
      Me.txtNombre.TabIndex = 4
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.LabelAsoc = Nothing
      Me.lblDireccion.Location = New System.Drawing.Point(19, 67)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblDireccion.TabIndex = 5
      Me.lblDireccion.Text = "Dirección"
      '
      'txtDireccion
      '
      Me.txtDireccion.BindearPropiedadControl = "Text"
      Me.txtDireccion.BindearPropiedadEntidad = "DireccionTransportista"
      Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDireccion.Formato = ""
      Me.txtDireccion.IsDecimal = False
      Me.txtDireccion.IsNumber = False
      Me.txtDireccion.IsPK = False
      Me.txtDireccion.IsRequired = True
      Me.txtDireccion.Key = ""
      Me.txtDireccion.LabelAsoc = Me.lblDireccion
      Me.txtDireccion.Location = New System.Drawing.Point(99, 67)
      Me.txtDireccion.MaxLength = 100
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.Size = New System.Drawing.Size(289, 20)
      Me.txtDireccion.TabIndex = 6
      '
      'lblCuit
      '
      Me.lblCuit.AutoSize = True
      Me.lblCuit.LabelAsoc = Nothing
      Me.lblCuit.Location = New System.Drawing.Point(19, 123)
      Me.lblCuit.Name = "lblCuit"
      Me.lblCuit.Size = New System.Drawing.Size(32, 13)
      Me.lblCuit.TabIndex = 10
      Me.lblCuit.Text = "CUIT"
      '
      'txtCuit
      '
      Me.txtCuit.BindearPropiedadControl = "Text"
      Me.txtCuit.BindearPropiedadEntidad = "CuitTransportista"
      Me.txtCuit.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuit.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuit.Formato = ""
      Me.txtCuit.IsDecimal = False
      Me.txtCuit.IsNumber = False
      Me.txtCuit.IsPK = False
      Me.txtCuit.IsRequired = False
      Me.txtCuit.Key = ""
      Me.txtCuit.LabelAsoc = Me.lblCuit
      Me.txtCuit.Location = New System.Drawing.Point(99, 119)
      Me.txtCuit.MaxLength = 11
      Me.txtCuit.Name = "txtCuit"
      Me.txtCuit.Size = New System.Drawing.Size(98, 20)
      Me.txtCuit.TabIndex = 11
      '
      'lblTelefono
      '
      Me.lblTelefono.AutoSize = True
      Me.lblTelefono.LabelAsoc = Nothing
      Me.lblTelefono.Location = New System.Drawing.Point(19, 176)
      Me.lblTelefono.Name = "lblTelefono"
      Me.lblTelefono.Size = New System.Drawing.Size(49, 13)
      Me.lblTelefono.TabIndex = 14
      Me.lblTelefono.Text = "Teléfono"
      '
      'txtTelefono
      '
      Me.txtTelefono.BindearPropiedadControl = "Text"
      Me.txtTelefono.BindearPropiedadEntidad = "TelefonoTransportista"
      Me.txtTelefono.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTelefono.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTelefono.Formato = ""
      Me.txtTelefono.IsDecimal = False
      Me.txtTelefono.IsNumber = False
      Me.txtTelefono.IsPK = False
      Me.txtTelefono.IsRequired = False
      Me.txtTelefono.Key = ""
      Me.txtTelefono.LabelAsoc = Me.lblTelefono
      Me.txtTelefono.Location = New System.Drawing.Point(99, 172)
      Me.txtTelefono.MaxLength = 100
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.Size = New System.Drawing.Size(289, 20)
      Me.txtTelefono.TabIndex = 15
      '
      'txtCodigo
      '
      Me.txtCodigo.BindearPropiedadControl = "Text"
      Me.txtCodigo.BindearPropiedadEntidad = "idTransportista"
      Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigo.Formato = ""
      Me.txtCodigo.IsDecimal = False
      Me.txtCodigo.IsNumber = True
      Me.txtCodigo.IsPK = True
      Me.txtCodigo.IsRequired = True
      Me.txtCodigo.Key = ""
      Me.txtCodigo.LabelAsoc = Me.lblCodigo
      Me.txtCodigo.Location = New System.Drawing.Point(99, 15)
      Me.txtCodigo.MaxLength = 12
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
      Me.txtCodigo.TabIndex = 1
      Me.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(19, 18)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Codigo"
      '
      'lblCategoriaFiscal
      '
      Me.lblCategoriaFiscal.AutoSize = True
      Me.lblCategoriaFiscal.LabelAsoc = Nothing
      Me.lblCategoriaFiscal.Location = New System.Drawing.Point(19, 149)
      Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
      Me.lblCategoriaFiscal.Size = New System.Drawing.Size(68, 13)
      Me.lblCategoriaFiscal.TabIndex = 12
      Me.lblCategoriaFiscal.Text = "Categ. Fiscal"
      '
      'cmbCategoriaFiscal
      '
      Me.cmbCategoriaFiscal.BindearPropiedadControl = "SelectedValue"
      Me.cmbCategoriaFiscal.BindearPropiedadEntidad = "CategoriaFiscal.IdCategoriaFiscal"
      Me.cmbCategoriaFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoriaFiscal.FormattingEnabled = True
      Me.cmbCategoriaFiscal.IsPK = False
      Me.cmbCategoriaFiscal.IsRequired = True
      Me.cmbCategoriaFiscal.Key = Nothing
      Me.cmbCategoriaFiscal.LabelAsoc = Me.lblCategoriaFiscal
      Me.cmbCategoriaFiscal.Location = New System.Drawing.Point(99, 145)
      Me.cmbCategoriaFiscal.Name = "cmbCategoriaFiscal"
      Me.cmbCategoriaFiscal.Size = New System.Drawing.Size(153, 21)
      Me.cmbCategoriaFiscal.TabIndex = 13
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
      Me.txtObservacion.Location = New System.Drawing.Point(19, 241)
      Me.txtObservacion.MaxLength = 200
      Me.txtObservacion.Multiline = True
      Me.txtObservacion.Name = "txtObservacion"
      Me.txtObservacion.Size = New System.Drawing.Size(364, 67)
      Me.txtObservacion.TabIndex = 21
      '
      'lblObservacion
      '
      Me.lblObservacion.AutoSize = True
      Me.lblObservacion.LabelAsoc = Nothing
      Me.lblObservacion.Location = New System.Drawing.Point(19, 225)
      Me.lblObservacion.Name = "lblObservacion"
      Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
      Me.lblObservacion.TabIndex = 20
      Me.lblObservacion.Text = "Observación"
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
      Me.bscNombreLocalidad.Location = New System.Drawing.Point(186, 93)
      Me.bscNombreLocalidad.MaxLengh = "32767"
      Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
      Me.bscNombreLocalidad.Permitido = True
      Me.bscNombreLocalidad.Selecciono = False
      Me.bscNombreLocalidad.Size = New System.Drawing.Size(202, 20)
      Me.bscNombreLocalidad.TabIndex = 9
      Me.bscNombreLocalidad.Titulo = Nothing
      '
      'bscCodigoLocalidad
      '
      Me.bscCodigoLocalidad.AyudaAncho = 608
      Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
      Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidadTransportista"
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
      Me.bscCodigoLocalidad.Location = New System.Drawing.Point(99, 93)
      Me.bscCodigoLocalidad.MaxLengh = "32767"
      Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
      Me.bscCodigoLocalidad.Permitido = True
      Me.bscCodigoLocalidad.Selecciono = False
      Me.bscCodigoLocalidad.Size = New System.Drawing.Size(81, 20)
      Me.bscCodigoLocalidad.TabIndex = 8
      Me.bscCodigoLocalidad.Titulo = Nothing
      '
      'lnkLocalidad
      '
      Me.lnkLocalidad.AutoSize = True
      Me.lnkLocalidad.Location = New System.Drawing.Point(19, 95)
      Me.lnkLocalidad.Name = "lnkLocalidad"
      Me.lnkLocalidad.Size = New System.Drawing.Size(53, 13)
      Me.lnkLocalidad.TabIndex = 7
      Me.lnkLocalidad.TabStop = True
      Me.lnkLocalidad.Text = "Localidad"
      '
      'txtCantidadKilos
      '
      Me.txtCantidadKilos.BindearPropiedadControl = "Text"
      Me.txtCantidadKilos.BindearPropiedadEntidad = "KilosMaximo"
      Me.txtCantidadKilos.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadKilos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadKilos.Formato = ""
      Me.txtCantidadKilos.IsDecimal = False
      Me.txtCantidadKilos.IsNumber = True
      Me.txtCantidadKilos.IsPK = False
      Me.txtCantidadKilos.IsRequired = False
      Me.txtCantidadKilos.Key = ""
      Me.txtCantidadKilos.LabelAsoc = Me.lblCantidadKilos
      Me.txtCantidadKilos.Location = New System.Drawing.Point(99, 200)
      Me.txtCantidadKilos.MaxLength = 7
      Me.txtCantidadKilos.Name = "txtCantidadKilos"
      Me.txtCantidadKilos.Size = New System.Drawing.Size(74, 20)
      Me.txtCantidadKilos.TabIndex = 17
      Me.txtCantidadKilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCantidadKilos
      '
      Me.lblCantidadKilos.AutoSize = True
      Me.lblCantidadKilos.LabelAsoc = Nothing
      Me.lblCantidadKilos.Location = New System.Drawing.Point(19, 203)
      Me.lblCantidadKilos.Name = "lblCantidadKilos"
      Me.lblCantidadKilos.Size = New System.Drawing.Size(74, 13)
      Me.lblCantidadKilos.TabIndex = 16
      Me.lblCantidadKilos.Text = "Cantidad Kilos"
      '
      'txtCantidadPalets
      '
      Me.txtCantidadPalets.BindearPropiedadControl = "Text"
      Me.txtCantidadPalets.BindearPropiedadEntidad = "PaletsMaximo"
      Me.txtCantidadPalets.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadPalets.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadPalets.Formato = ""
      Me.txtCantidadPalets.IsDecimal = False
      Me.txtCantidadPalets.IsNumber = True
      Me.txtCantidadPalets.IsPK = False
      Me.txtCantidadPalets.IsRequired = False
      Me.txtCantidadPalets.Key = ""
      Me.txtCantidadPalets.LabelAsoc = Me.lblCodigo
      Me.txtCantidadPalets.Location = New System.Drawing.Point(262, 200)
      Me.txtCantidadPalets.MaxLength = 4
      Me.txtCantidadPalets.Name = "txtCantidadPalets"
      Me.txtCantidadPalets.Size = New System.Drawing.Size(74, 20)
      Me.txtCantidadPalets.TabIndex = 19
      Me.txtCantidadPalets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCantidadPalets
      '
      Me.lblCantidadPalets.AutoSize = True
      Me.lblCantidadPalets.LabelAsoc = Nothing
      Me.lblCantidadPalets.Location = New System.Drawing.Point(175, 203)
      Me.lblCantidadPalets.Name = "lblCantidadPalets"
      Me.lblCantidadPalets.Size = New System.Drawing.Size(81, 13)
      Me.lblCantidadPalets.TabIndex = 18
      Me.lblCantidadPalets.Text = "Cantidad Palets"
      '
      'chbActivo
      '
      Me.chbActivo.AutoSize = True
      Me.chbActivo.BindearPropiedadControl = "Checked"
      Me.chbActivo.BindearPropiedadEntidad = "Activo"
      Me.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.chbActivo.IsPK = False
      Me.chbActivo.IsRequired = False
      Me.chbActivo.Key = Nothing
      Me.chbActivo.LabelAsoc = Nothing
      Me.chbActivo.Location = New System.Drawing.Point(332, 12)
      Me.chbActivo.Name = "chbActivo"
      Me.chbActivo.Size = New System.Drawing.Size(56, 17)
      Me.chbActivo.TabIndex = 2
      Me.chbActivo.Text = "Activo"
      Me.chbActivo.UseVisualStyleBackColor = True
      '
      'TransportistasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(400, 356)
      Me.Controls.Add(Me.chbActivo)
      Me.Controls.Add(Me.lblCantidadPalets)
      Me.Controls.Add(Me.lblCantidadKilos)
      Me.Controls.Add(Me.txtCantidadPalets)
      Me.Controls.Add(Me.txtCantidadKilos)
      Me.Controls.Add(Me.bscNombreLocalidad)
      Me.Controls.Add(Me.bscCodigoLocalidad)
      Me.Controls.Add(Me.lnkLocalidad)
      Me.Controls.Add(Me.txtObservacion)
      Me.Controls.Add(Me.lblObservacion)
      Me.Controls.Add(Me.cmbCategoriaFiscal)
      Me.Controls.Add(Me.lblCategoriaFiscal)
      Me.Controls.Add(Me.txtCodigo)
      Me.Controls.Add(Me.lblCodigo)
      Me.Controls.Add(Me.lblTelefono)
      Me.Controls.Add(Me.txtTelefono)
      Me.Controls.Add(Me.lblCuit)
      Me.Controls.Add(Me.txtCuit)
      Me.Controls.Add(Me.lblDireccion)
      Me.Controls.Add(Me.txtDireccion)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "TransportistasDetalle"
      Me.Text = "Transportistas"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.txtDireccion, 0)
      Me.Controls.SetChildIndex(Me.lblDireccion, 0)
      Me.Controls.SetChildIndex(Me.txtCuit, 0)
      Me.Controls.SetChildIndex(Me.lblCuit, 0)
      Me.Controls.SetChildIndex(Me.txtTelefono, 0)
      Me.Controls.SetChildIndex(Me.lblTelefono, 0)
      Me.Controls.SetChildIndex(Me.lblCodigo, 0)
      Me.Controls.SetChildIndex(Me.txtCodigo, 0)
      Me.Controls.SetChildIndex(Me.lblCategoriaFiscal, 0)
      Me.Controls.SetChildIndex(Me.cmbCategoriaFiscal, 0)
      Me.Controls.SetChildIndex(Me.lblObservacion, 0)
      Me.Controls.SetChildIndex(Me.txtObservacion, 0)
      Me.Controls.SetChildIndex(Me.lnkLocalidad, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoLocalidad, 0)
      Me.Controls.SetChildIndex(Me.bscNombreLocalidad, 0)
      Me.Controls.SetChildIndex(Me.txtCantidadKilos, 0)
      Me.Controls.SetChildIndex(Me.txtCantidadPalets, 0)
      Me.Controls.SetChildIndex(Me.lblCantidadKilos, 0)
      Me.Controls.SetChildIndex(Me.lblCantidadPalets, 0)
      Me.Controls.SetChildIndex(Me.chbActivo, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents lblCuit As Eniac.Controles.Label
   Friend WithEvents txtCuit As Eniac.Controles.TextBox
   Friend WithEvents lblTelefono As Eniac.Controles.Label
   Friend WithEvents txtTelefono As Eniac.Controles.TextBox
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents lblCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents cmbCategoriaFiscal As Eniac.Controles.ComboBox
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents lnkLocalidad As Eniac.Controles.LinkLabel
   Friend WithEvents txtCantidadKilos As Eniac.Controles.TextBox
   Friend WithEvents txtCantidadPalets As Eniac.Controles.TextBox
   Friend WithEvents lblCantidadKilos As Eniac.Controles.Label
   Friend WithEvents lblCantidadPalets As Eniac.Controles.Label
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox

End Class
