<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConcesionarioOperacionesCaracteristicas
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConcesionarioOperacionesCaracteristicas))
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblTipoUnidad = New Eniac.Controles.Label()
        Me.lblSubTipoUnidad = New Eniac.Controles.Label()
        Me.txtCampoAdicional = New Eniac.Controles.TextBox()
        Me.lblCampoAdicional = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chbHerraje = New Eniac.Controles.CheckBox()
        Me.txtOtrasObservaciones = New Eniac.Controles.TextBox()
        Me.lblOtrasObservaciones = New Eniac.Controles.Label()
        Me.chbPiso = New Eniac.Controles.CheckBox()
        Me.chbMarco = New Eniac.Controles.CheckBox()
        Me.lblAltoPuertasLaterales = New Eniac.Controles.Label()
        Me.chbParante = New Eniac.Controles.CheckBox()
        Me.txtColorBase = New Eniac.Controles.TextBox()
        Me.lblColorBase = New Eniac.Controles.Label()
        Me.chbPuertaTrasera = New Eniac.Controles.CheckBox()
        Me.txtColorZocalo = New Eniac.Controles.TextBox()
        Me.lblColorZocalo = New Eniac.Controles.Label()
        Me.txtColorCarroceria = New Eniac.Controles.TextBox()
        Me.lblColorCarroceria = New Eniac.Controles.Label()
        Me.txtAltoPuertasLaterales = New Eniac.Controles.TextBox()
        Me.txtAltoCarga = New Eniac.Controles.TextBox()
        Me.lblAltoCarga = New Eniac.Controles.Label()
        Me.txtLargo = New Eniac.Controles.TextBox()
        Me.lblLargo = New Eniac.Controles.Label()
        Me.lblDistribucionEjes = New Eniac.Controles.Label()
        Me.cmbHerraje = New Eniac.Controles.ComboBox()
        Me.cmbPiso = New Eniac.Controles.ComboBox()
        Me.cmbMarco = New Eniac.Controles.ComboBox()
        Me.cmbPuertaTrasera = New Eniac.Controles.ComboBox()
        Me.cmbParante = New Eniac.Controles.ComboBox()
        Me.cmbDistribucionEjes = New Eniac.Controles.ComboBox()
        Me.cmbTipoUnidad = New Eniac.Controles.ComboBox()
        Me.cmbSubTipoUnidad = New Eniac.Controles.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(409, 351)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 30)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar (F4)"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(505, 351)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblTipoUnidad
        '
        Me.lblTipoUnidad.AutoSize = True
        Me.lblTipoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblTipoUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoUnidad.LabelAsoc = Nothing
        Me.lblTipoUnidad.Location = New System.Drawing.Point(6, 23)
        Me.lblTipoUnidad.Name = "lblTipoUnidad"
        Me.lblTipoUnidad.Size = New System.Drawing.Size(65, 13)
        Me.lblTipoUnidad.TabIndex = 0
        Me.lblTipoUnidad.Text = "Tipo Unidad"
        '
        'lblSubTipoUnidad
        '
        Me.lblSubTipoUnidad.AutoSize = True
        Me.lblSubTipoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblSubTipoUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSubTipoUnidad.LabelAsoc = Nothing
        Me.lblSubTipoUnidad.Location = New System.Drawing.Point(293, 23)
        Me.lblSubTipoUnidad.Name = "lblSubTipoUnidad"
        Me.lblSubTipoUnidad.Size = New System.Drawing.Size(84, 13)
        Me.lblSubTipoUnidad.TabIndex = 2
        Me.lblSubTipoUnidad.Text = "SubTipo Unidad"
        '
        'txtCampoAdicional
        '
        Me.txtCampoAdicional.BindearPropiedadControl = Nothing
        Me.txtCampoAdicional.BindearPropiedadEntidad = Nothing
        Me.txtCampoAdicional.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCampoAdicional.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCampoAdicional.Formato = ""
        Me.txtCampoAdicional.IsDecimal = False
        Me.txtCampoAdicional.IsNumber = False
        Me.txtCampoAdicional.IsPK = False
        Me.txtCampoAdicional.IsRequired = False
        Me.txtCampoAdicional.Key = ""
        Me.txtCampoAdicional.LabelAsoc = Me.lblCampoAdicional
        Me.txtCampoAdicional.Location = New System.Drawing.Point(408, 46)
        Me.txtCampoAdicional.Name = "txtCampoAdicional"
        Me.txtCampoAdicional.Size = New System.Drawing.Size(157, 20)
        Me.txtCampoAdicional.TabIndex = 7
        '
        'lblCampoAdicional
        '
        Me.lblCampoAdicional.AutoSize = True
        Me.lblCampoAdicional.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCampoAdicional.LabelAsoc = Nothing
        Me.lblCampoAdicional.Location = New System.Drawing.Point(293, 50)
        Me.lblCampoAdicional.Name = "lblCampoAdicional"
        Me.lblCampoAdicional.Size = New System.Drawing.Size(72, 13)
        Me.lblCampoAdicional.TabIndex = 6
        Me.lblCampoAdicional.Text = "(campo movil)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbDistribucionEjes)
        Me.GroupBox1.Controls.Add(Me.lblDistribucionEjes)
        Me.GroupBox1.Controls.Add(Me.cmbTipoUnidad)
        Me.GroupBox1.Controls.Add(Me.txtCampoAdicional)
        Me.GroupBox1.Controls.Add(Me.lblTipoUnidad)
        Me.GroupBox1.Controls.Add(Me.lblCampoAdicional)
        Me.GroupBox1.Controls.Add(Me.lblSubTipoUnidad)
        Me.GroupBox1.Controls.Add(Me.cmbSubTipoUnidad)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 74)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbHerraje)
        Me.GroupBox2.Controls.Add(Me.txtOtrasObservaciones)
        Me.GroupBox2.Controls.Add(Me.cmbPiso)
        Me.GroupBox2.Controls.Add(Me.lblOtrasObservaciones)
        Me.GroupBox2.Controls.Add(Me.chbHerraje)
        Me.GroupBox2.Controls.Add(Me.cmbMarco)
        Me.GroupBox2.Controls.Add(Me.chbPiso)
        Me.GroupBox2.Controls.Add(Me.cmbPuertaTrasera)
        Me.GroupBox2.Controls.Add(Me.cmbParante)
        Me.GroupBox2.Controls.Add(Me.chbMarco)
        Me.GroupBox2.Controls.Add(Me.chbParante)
        Me.GroupBox2.Controls.Add(Me.txtColorBase)
        Me.GroupBox2.Controls.Add(Me.chbPuertaTrasera)
        Me.GroupBox2.Controls.Add(Me.txtColorZocalo)
        Me.GroupBox2.Controls.Add(Me.lblColorBase)
        Me.GroupBox2.Controls.Add(Me.txtColorCarroceria)
        Me.GroupBox2.Controls.Add(Me.lblColorZocalo)
        Me.GroupBox2.Controls.Add(Me.lblColorCarroceria)
        Me.GroupBox2.Controls.Add(Me.txtAltoPuertasLaterales)
        Me.GroupBox2.Controls.Add(Me.lblAltoPuertasLaterales)
        Me.GroupBox2.Controls.Add(Me.txtAltoCarga)
        Me.GroupBox2.Controls.Add(Me.lblAltoCarga)
        Me.GroupBox2.Controls.Add(Me.txtLargo)
        Me.GroupBox2.Controls.Add(Me.lblLargo)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(573, 255)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'chbHerraje
        '
        Me.chbHerraje.AutoSize = True
        Me.chbHerraje.BindearPropiedadControl = Nothing
        Me.chbHerraje.BindearPropiedadEntidad = Nothing
        Me.chbHerraje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chbHerraje.ForeColorFocus = System.Drawing.Color.Red
        Me.chbHerraje.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbHerraje.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbHerraje.IsPK = False
        Me.chbHerraje.IsRequired = False
        Me.chbHerraje.Key = Nothing
        Me.chbHerraje.LabelAsoc = Nothing
        Me.chbHerraje.Location = New System.Drawing.Point(296, 155)
        Me.chbHerraje.Name = "chbHerraje"
        Me.chbHerraje.Size = New System.Drawing.Size(60, 17)
        Me.chbHerraje.TabIndex = 20
        Me.chbHerraje.Text = "Herraje"
        '
        'txtOtrasObservaciones
        '
        Me.txtOtrasObservaciones.BindearPropiedadControl = Nothing
        Me.txtOtrasObservaciones.BindearPropiedadEntidad = Nothing
        Me.txtOtrasObservaciones.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOtrasObservaciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOtrasObservaciones.Formato = ""
        Me.txtOtrasObservaciones.IsDecimal = False
        Me.txtOtrasObservaciones.IsNumber = False
        Me.txtOtrasObservaciones.IsPK = False
        Me.txtOtrasObservaciones.IsRequired = False
        Me.txtOtrasObservaciones.Key = ""
        Me.txtOtrasObservaciones.LabelAsoc = Me.lblOtrasObservaciones
        Me.txtOtrasObservaciones.Location = New System.Drawing.Point(127, 178)
        Me.txtOtrasObservaciones.Multiline = True
        Me.txtOtrasObservaciones.Name = "txtOtrasObservaciones"
        Me.txtOtrasObservaciones.Size = New System.Drawing.Size(438, 68)
        Me.txtOtrasObservaciones.TabIndex = 23
        '
        'lblOtrasObservaciones
        '
        Me.lblOtrasObservaciones.AutoSize = True
        Me.lblOtrasObservaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOtrasObservaciones.LabelAsoc = Nothing
        Me.lblOtrasObservaciones.Location = New System.Drawing.Point(6, 181)
        Me.lblOtrasObservaciones.Name = "lblOtrasObservaciones"
        Me.lblOtrasObservaciones.Size = New System.Drawing.Size(106, 13)
        Me.lblOtrasObservaciones.TabIndex = 22
        Me.lblOtrasObservaciones.Text = "Otras Observaciones"
        '
        'chbPiso
        '
        Me.chbPiso.AutoSize = True
        Me.chbPiso.BindearPropiedadControl = Nothing
        Me.chbPiso.BindearPropiedadEntidad = Nothing
        Me.chbPiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chbPiso.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPiso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPiso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbPiso.IsPK = False
        Me.chbPiso.IsRequired = False
        Me.chbPiso.Key = Nothing
        Me.chbPiso.LabelAsoc = Nothing
        Me.chbPiso.Location = New System.Drawing.Point(296, 128)
        Me.chbPiso.Name = "chbPiso"
        Me.chbPiso.Size = New System.Drawing.Size(46, 17)
        Me.chbPiso.TabIndex = 16
        Me.chbPiso.Text = "Piso"
        '
        'chbMarco
        '
        Me.chbMarco.AutoSize = True
        Me.chbMarco.BindearPropiedadControl = Nothing
        Me.chbMarco.BindearPropiedadEntidad = Nothing
        Me.chbMarco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chbMarco.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMarco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMarco.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbMarco.IsPK = False
        Me.chbMarco.IsRequired = False
        Me.chbMarco.Key = Nothing
        Me.chbMarco.LabelAsoc = Nothing
        Me.chbMarco.Location = New System.Drawing.Point(6, 155)
        Me.chbMarco.Name = "chbMarco"
        Me.chbMarco.Size = New System.Drawing.Size(56, 17)
        Me.chbMarco.TabIndex = 18
        Me.chbMarco.Text = "Marco"
        '
        'lblAltoPuertasLaterales
        '
        Me.lblAltoPuertasLaterales.AutoSize = True
        Me.lblAltoPuertasLaterales.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAltoPuertasLaterales.LabelAsoc = Nothing
        Me.lblAltoPuertasLaterales.Location = New System.Drawing.Point(6, 74)
        Me.lblAltoPuertasLaterales.Name = "lblAltoPuertasLaterales"
        Me.lblAltoPuertasLaterales.Size = New System.Drawing.Size(110, 13)
        Me.lblAltoPuertasLaterales.TabIndex = 4
        Me.lblAltoPuertasLaterales.Text = "Alto Puertas Laterales"
        '
        'chbParante
        '
        Me.chbParante.AutoSize = True
        Me.chbParante.BindearPropiedadControl = Nothing
        Me.chbParante.BindearPropiedadEntidad = Nothing
        Me.chbParante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chbParante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbParante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbParante.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbParante.IsPK = False
        Me.chbParante.IsRequired = False
        Me.chbParante.Key = Nothing
        Me.chbParante.LabelAsoc = Nothing
        Me.chbParante.Location = New System.Drawing.Point(6, 127)
        Me.chbParante.Name = "chbParante"
        Me.chbParante.Size = New System.Drawing.Size(63, 17)
        Me.chbParante.TabIndex = 14
        Me.chbParante.Text = "Parante"
        '
        'txtColorBase
        '
        Me.txtColorBase.BindearPropiedadControl = Nothing
        Me.txtColorBase.BindearPropiedadEntidad = Nothing
        Me.txtColorBase.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColorBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColorBase.Formato = ""
        Me.txtColorBase.IsDecimal = False
        Me.txtColorBase.IsNumber = False
        Me.txtColorBase.IsPK = False
        Me.txtColorBase.IsRequired = False
        Me.txtColorBase.Key = ""
        Me.txtColorBase.LabelAsoc = Me.lblColorBase
        Me.txtColorBase.Location = New System.Drawing.Point(408, 73)
        Me.txtColorBase.Name = "txtColorBase"
        Me.txtColorBase.Size = New System.Drawing.Size(157, 20)
        Me.txtColorBase.TabIndex = 11
        '
        'lblColorBase
        '
        Me.lblColorBase.AutoSize = True
        Me.lblColorBase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblColorBase.LabelAsoc = Nothing
        Me.lblColorBase.Location = New System.Drawing.Point(296, 76)
        Me.lblColorBase.Name = "lblColorBase"
        Me.lblColorBase.Size = New System.Drawing.Size(58, 13)
        Me.lblColorBase.TabIndex = 10
        Me.lblColorBase.Text = "Color Base"
        '
        'chbPuertaTrasera
        '
        Me.chbPuertaTrasera.AutoSize = True
        Me.chbPuertaTrasera.BindearPropiedadControl = Nothing
        Me.chbPuertaTrasera.BindearPropiedadEntidad = Nothing
        Me.chbPuertaTrasera.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPuertaTrasera.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPuertaTrasera.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbPuertaTrasera.IsPK = False
        Me.chbPuertaTrasera.IsRequired = False
        Me.chbPuertaTrasera.Key = Nothing
        Me.chbPuertaTrasera.LabelAsoc = Nothing
        Me.chbPuertaTrasera.Location = New System.Drawing.Point(6, 100)
        Me.chbPuertaTrasera.Name = "chbPuertaTrasera"
        Me.chbPuertaTrasera.Size = New System.Drawing.Size(96, 17)
        Me.chbPuertaTrasera.TabIndex = 12
        Me.chbPuertaTrasera.Text = "Puerta Trasera"
        '
        'txtColorZocalo
        '
        Me.txtColorZocalo.BindearPropiedadControl = Nothing
        Me.txtColorZocalo.BindearPropiedadEntidad = Nothing
        Me.txtColorZocalo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColorZocalo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColorZocalo.Formato = ""
        Me.txtColorZocalo.IsDecimal = False
        Me.txtColorZocalo.IsNumber = False
        Me.txtColorZocalo.IsPK = False
        Me.txtColorZocalo.IsRequired = False
        Me.txtColorZocalo.Key = ""
        Me.txtColorZocalo.LabelAsoc = Me.lblColorZocalo
        Me.txtColorZocalo.Location = New System.Drawing.Point(408, 47)
        Me.txtColorZocalo.Name = "txtColorZocalo"
        Me.txtColorZocalo.Size = New System.Drawing.Size(157, 20)
        Me.txtColorZocalo.TabIndex = 9
        '
        'lblColorZocalo
        '
        Me.lblColorZocalo.AutoSize = True
        Me.lblColorZocalo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblColorZocalo.LabelAsoc = Nothing
        Me.lblColorZocalo.Location = New System.Drawing.Point(296, 50)
        Me.lblColorZocalo.Name = "lblColorZocalo"
        Me.lblColorZocalo.Size = New System.Drawing.Size(67, 13)
        Me.lblColorZocalo.TabIndex = 8
        Me.lblColorZocalo.Text = "Color Zocalo"
        '
        'txtColorCarroceria
        '
        Me.txtColorCarroceria.BindearPropiedadControl = Nothing
        Me.txtColorCarroceria.BindearPropiedadEntidad = Nothing
        Me.txtColorCarroceria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColorCarroceria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColorCarroceria.Formato = ""
        Me.txtColorCarroceria.IsDecimal = False
        Me.txtColorCarroceria.IsNumber = False
        Me.txtColorCarroceria.IsPK = False
        Me.txtColorCarroceria.IsRequired = False
        Me.txtColorCarroceria.Key = ""
        Me.txtColorCarroceria.LabelAsoc = Me.lblColorCarroceria
        Me.txtColorCarroceria.Location = New System.Drawing.Point(408, 19)
        Me.txtColorCarroceria.Name = "txtColorCarroceria"
        Me.txtColorCarroceria.Size = New System.Drawing.Size(157, 20)
        Me.txtColorCarroceria.TabIndex = 7
        '
        'lblColorCarroceria
        '
        Me.lblColorCarroceria.AutoSize = True
        Me.lblColorCarroceria.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblColorCarroceria.LabelAsoc = Nothing
        Me.lblColorCarroceria.Location = New System.Drawing.Point(296, 22)
        Me.lblColorCarroceria.Name = "lblColorCarroceria"
        Me.lblColorCarroceria.Size = New System.Drawing.Size(84, 13)
        Me.lblColorCarroceria.TabIndex = 6
        Me.lblColorCarroceria.Text = "Color Carrocería"
        '
        'txtAltoPuertasLaterales
        '
        Me.txtAltoPuertasLaterales.BindearPropiedadControl = Nothing
        Me.txtAltoPuertasLaterales.BindearPropiedadEntidad = Nothing
        Me.txtAltoPuertasLaterales.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAltoPuertasLaterales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAltoPuertasLaterales.Formato = ""
        Me.txtAltoPuertasLaterales.IsDecimal = False
        Me.txtAltoPuertasLaterales.IsNumber = False
        Me.txtAltoPuertasLaterales.IsPK = False
        Me.txtAltoPuertasLaterales.IsRequired = False
        Me.txtAltoPuertasLaterales.Key = ""
        Me.txtAltoPuertasLaterales.LabelAsoc = Me.lblAltoPuertasLaterales
        Me.txtAltoPuertasLaterales.Location = New System.Drawing.Point(127, 71)
        Me.txtAltoPuertasLaterales.Name = "txtAltoPuertasLaterales"
        Me.txtAltoPuertasLaterales.Size = New System.Drawing.Size(157, 20)
        Me.txtAltoPuertasLaterales.TabIndex = 5
        '
        'txtAltoCarga
        '
        Me.txtAltoCarga.BindearPropiedadControl = Nothing
        Me.txtAltoCarga.BindearPropiedadEntidad = Nothing
        Me.txtAltoCarga.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAltoCarga.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAltoCarga.Formato = ""
        Me.txtAltoCarga.IsDecimal = False
        Me.txtAltoCarga.IsNumber = False
        Me.txtAltoCarga.IsPK = False
        Me.txtAltoCarga.IsRequired = False
        Me.txtAltoCarga.Key = ""
        Me.txtAltoCarga.LabelAsoc = Me.lblAltoCarga
        Me.txtAltoCarga.Location = New System.Drawing.Point(127, 45)
        Me.txtAltoCarga.Name = "txtAltoCarga"
        Me.txtAltoCarga.Size = New System.Drawing.Size(157, 20)
        Me.txtAltoCarga.TabIndex = 3
        '
        'lblAltoCarga
        '
        Me.lblAltoCarga.AutoSize = True
        Me.lblAltoCarga.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAltoCarga.LabelAsoc = Nothing
        Me.lblAltoCarga.Location = New System.Drawing.Point(6, 48)
        Me.lblAltoCarga.Name = "lblAltoCarga"
        Me.lblAltoCarga.Size = New System.Drawing.Size(71, 13)
        Me.lblAltoCarga.TabIndex = 2
        Me.lblAltoCarga.Text = "Alto de Carga"
        '
        'txtLargo
        '
        Me.txtLargo.BindearPropiedadControl = Nothing
        Me.txtLargo.BindearPropiedadEntidad = Nothing
        Me.txtLargo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLargo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLargo.Formato = ""
        Me.txtLargo.IsDecimal = False
        Me.txtLargo.IsNumber = False
        Me.txtLargo.IsPK = False
        Me.txtLargo.IsRequired = False
        Me.txtLargo.Key = ""
        Me.txtLargo.LabelAsoc = Me.lblLargo
        Me.txtLargo.Location = New System.Drawing.Point(127, 19)
        Me.txtLargo.Name = "txtLargo"
        Me.txtLargo.Size = New System.Drawing.Size(157, 20)
        Me.txtLargo.TabIndex = 1
        '
        'lblLargo
        '
        Me.lblLargo.AutoSize = True
        Me.lblLargo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLargo.LabelAsoc = Nothing
        Me.lblLargo.Location = New System.Drawing.Point(6, 22)
        Me.lblLargo.Name = "lblLargo"
        Me.lblLargo.Size = New System.Drawing.Size(34, 13)
        Me.lblLargo.TabIndex = 0
        Me.lblLargo.Text = "Largo"
        '
        'lblDistribucionEjes
        '
        Me.lblDistribucionEjes.AutoSize = True
        Me.lblDistribucionEjes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDistribucionEjes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDistribucionEjes.LabelAsoc = Nothing
        Me.lblDistribucionEjes.Location = New System.Drawing.Point(6, 50)
        Me.lblDistribucionEjes.Name = "lblDistribucionEjes"
        Me.lblDistribucionEjes.Size = New System.Drawing.Size(100, 13)
        Me.lblDistribucionEjes.TabIndex = 4
        Me.lblDistribucionEjes.Text = "Distribución de Ejes"
        '
        'cmbHerraje
        '
        Me.cmbHerraje.BindearPropiedadControl = Nothing
        Me.cmbHerraje.BindearPropiedadEntidad = Nothing
        Me.cmbHerraje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHerraje.Enabled = False
        Me.cmbHerraje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbHerraje.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbHerraje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbHerraje.FormattingEnabled = True
        Me.cmbHerraje.IsPK = False
        Me.cmbHerraje.IsRequired = False
        Me.cmbHerraje.Key = Nothing
        Me.cmbHerraje.LabelAsoc = Me.chbHerraje
        Me.cmbHerraje.Location = New System.Drawing.Point(408, 151)
        Me.cmbHerraje.Name = "cmbHerraje"
        Me.cmbHerraje.Size = New System.Drawing.Size(157, 21)
        Me.cmbHerraje.TabIndex = 21
        '
        'cmbPiso
        '
        Me.cmbPiso.BindearPropiedadControl = Nothing
        Me.cmbPiso.BindearPropiedadEntidad = Nothing
        Me.cmbPiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPiso.Enabled = False
        Me.cmbPiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbPiso.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPiso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPiso.FormattingEnabled = True
        Me.cmbPiso.IsPK = False
        Me.cmbPiso.IsRequired = False
        Me.cmbPiso.Key = Nothing
        Me.cmbPiso.LabelAsoc = Me.chbPiso
        Me.cmbPiso.Location = New System.Drawing.Point(408, 124)
        Me.cmbPiso.Name = "cmbPiso"
        Me.cmbPiso.Size = New System.Drawing.Size(157, 21)
        Me.cmbPiso.TabIndex = 17
        '
        'cmbMarco
        '
        Me.cmbMarco.BindearPropiedadControl = Nothing
        Me.cmbMarco.BindearPropiedadEntidad = Nothing
        Me.cmbMarco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarco.Enabled = False
        Me.cmbMarco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbMarco.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarco.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarco.FormattingEnabled = True
        Me.cmbMarco.IsPK = False
        Me.cmbMarco.IsRequired = False
        Me.cmbMarco.Key = Nothing
        Me.cmbMarco.LabelAsoc = Me.chbMarco
        Me.cmbMarco.Location = New System.Drawing.Point(127, 151)
        Me.cmbMarco.Name = "cmbMarco"
        Me.cmbMarco.Size = New System.Drawing.Size(157, 21)
        Me.cmbMarco.TabIndex = 19
        '
        'cmbPuertaTrasera
        '
        Me.cmbPuertaTrasera.BindearPropiedadControl = Nothing
        Me.cmbPuertaTrasera.BindearPropiedadEntidad = Nothing
        Me.cmbPuertaTrasera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuertaTrasera.Enabled = False
        Me.cmbPuertaTrasera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbPuertaTrasera.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPuertaTrasera.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPuertaTrasera.FormattingEnabled = True
        Me.cmbPuertaTrasera.IsPK = False
        Me.cmbPuertaTrasera.IsRequired = False
        Me.cmbPuertaTrasera.Key = Nothing
        Me.cmbPuertaTrasera.LabelAsoc = Me.lblAltoPuertasLaterales
        Me.cmbPuertaTrasera.Location = New System.Drawing.Point(127, 97)
        Me.cmbPuertaTrasera.Name = "cmbPuertaTrasera"
        Me.cmbPuertaTrasera.Size = New System.Drawing.Size(157, 21)
        Me.cmbPuertaTrasera.TabIndex = 13
        '
        'cmbParante
        '
        Me.cmbParante.BindearPropiedadControl = Nothing
        Me.cmbParante.BindearPropiedadEntidad = Nothing
        Me.cmbParante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbParante.Enabled = False
        Me.cmbParante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbParante.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbParante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbParante.FormattingEnabled = True
        Me.cmbParante.IsPK = False
        Me.cmbParante.IsRequired = False
        Me.cmbParante.Key = Nothing
        Me.cmbParante.LabelAsoc = Me.chbParante
        Me.cmbParante.Location = New System.Drawing.Point(127, 124)
        Me.cmbParante.Name = "cmbParante"
        Me.cmbParante.Size = New System.Drawing.Size(157, 21)
        Me.cmbParante.TabIndex = 15
        '
        'cmbDistribucionEjes
        '
        Me.cmbDistribucionEjes.BindearPropiedadControl = Nothing
        Me.cmbDistribucionEjes.BindearPropiedadEntidad = Nothing
        Me.cmbDistribucionEjes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDistribucionEjes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbDistribucionEjes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDistribucionEjes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDistribucionEjes.FormattingEnabled = True
        Me.cmbDistribucionEjes.IsPK = False
        Me.cmbDistribucionEjes.IsRequired = False
        Me.cmbDistribucionEjes.Key = Nothing
        Me.cmbDistribucionEjes.LabelAsoc = Me.lblDistribucionEjes
        Me.cmbDistribucionEjes.Location = New System.Drawing.Point(127, 46)
        Me.cmbDistribucionEjes.Name = "cmbDistribucionEjes"
        Me.cmbDistribucionEjes.Size = New System.Drawing.Size(157, 21)
        Me.cmbDistribucionEjes.TabIndex = 5
        '
        'cmbTipoUnidad
        '
        Me.cmbTipoUnidad.BindearPropiedadControl = Nothing
        Me.cmbTipoUnidad.BindearPropiedadEntidad = Nothing
        Me.cmbTipoUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoUnidad.FormattingEnabled = True
        Me.cmbTipoUnidad.IsPK = False
        Me.cmbTipoUnidad.IsRequired = False
        Me.cmbTipoUnidad.Key = Nothing
        Me.cmbTipoUnidad.LabelAsoc = Me.lblTipoUnidad
        Me.cmbTipoUnidad.Location = New System.Drawing.Point(127, 19)
        Me.cmbTipoUnidad.Name = "cmbTipoUnidad"
        Me.cmbTipoUnidad.Size = New System.Drawing.Size(157, 21)
        Me.cmbTipoUnidad.TabIndex = 1
        '
        'cmbSubTipoUnidad
        '
        Me.cmbSubTipoUnidad.BindearPropiedadControl = Nothing
        Me.cmbSubTipoUnidad.BindearPropiedadEntidad = Nothing
        Me.cmbSubTipoUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubTipoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSubTipoUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSubTipoUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSubTipoUnidad.FormattingEnabled = True
        Me.cmbSubTipoUnidad.IsPK = False
        Me.cmbSubTipoUnidad.IsRequired = False
        Me.cmbSubTipoUnidad.Key = Nothing
        Me.cmbSubTipoUnidad.LabelAsoc = Me.lblSubTipoUnidad
        Me.cmbSubTipoUnidad.Location = New System.Drawing.Point(408, 19)
        Me.cmbSubTipoUnidad.Name = "cmbSubTipoUnidad"
        Me.cmbSubTipoUnidad.Size = New System.Drawing.Size(157, 21)
        Me.cmbSubTipoUnidad.TabIndex = 3
        '
        'ConcesionarioOperacionesCaracteristicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 393)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Name = "ConcesionarioOperacionesCaracteristicas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Características"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
   Friend WithEvents cmbTipoUnidad As Controles.ComboBox
   Friend WithEvents lblTipoUnidad As Controles.Label
   Friend WithEvents cmbSubTipoUnidad As Controles.ComboBox
   Friend WithEvents lblSubTipoUnidad As Controles.Label
   Friend WithEvents txtCampoAdicional As Controles.TextBox
   Friend WithEvents lblCampoAdicional As Controles.Label
   Friend WithEvents GroupBox1 As GroupBox
   Friend WithEvents GroupBox2 As GroupBox
   Friend WithEvents cmbHerraje As Controles.ComboBox
   Friend WithEvents chbHerraje As Controles.CheckBox
   Friend WithEvents txtOtrasObservaciones As Controles.TextBox
   Friend WithEvents lblOtrasObservaciones As Controles.Label
   Friend WithEvents cmbPiso As Controles.ComboBox
   Friend WithEvents chbPiso As Controles.CheckBox
   Friend WithEvents cmbMarco As Controles.ComboBox
   Friend WithEvents chbMarco As Controles.CheckBox
   Friend WithEvents cmbParante As Controles.ComboBox
   Friend WithEvents chbParante As Controles.CheckBox
   Friend WithEvents chbPuertaTrasera As Controles.CheckBox
   Friend WithEvents txtColorBase As Controles.TextBox
   Friend WithEvents lblColorBase As Controles.Label
   Friend WithEvents txtColorZocalo As Controles.TextBox
   Friend WithEvents lblColorZocalo As Controles.Label
   Friend WithEvents txtColorCarroceria As Controles.TextBox
   Friend WithEvents lblColorCarroceria As Controles.Label
   Friend WithEvents txtAltoPuertasLaterales As Controles.TextBox
   Friend WithEvents lblAltoPuertasLaterales As Controles.Label
   Friend WithEvents txtAltoCarga As Controles.TextBox
   Friend WithEvents lblAltoCarga As Controles.Label
   Friend WithEvents txtLargo As Controles.TextBox
   Friend WithEvents lblLargo As Controles.Label
   Friend WithEvents cmbPuertaTrasera As Controles.ComboBox
    Friend WithEvents cmbDistribucionEjes As Controles.ComboBox
    Friend WithEvents lblDistribucionEjes As Controles.Label
End Class
