<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovilRutasClientes
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
   ' <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovilRutasClientes))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbRuta = New System.Windows.Forms.GroupBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.lblInfoRuta = New Eniac.Controles.Label()
        Me.grbDias = New System.Windows.Forms.GroupBox()
        Me.lblDomingo = New Eniac.Controles.Label()
        Me.rdbDomingo = New Eniac.Controles.RadioButton()
        Me.lblOtro = New Eniac.Controles.Label()
        Me.rdbOtro = New Eniac.Controles.RadioButton()
        Me.lblSabado = New Eniac.Controles.Label()
        Me.lblViernes = New Eniac.Controles.Label()
        Me.lblJueves = New Eniac.Controles.Label()
        Me.lblMiercoles = New Eniac.Controles.Label()
        Me.lblMartes = New Eniac.Controles.Label()
        Me.lblLunes = New Eniac.Controles.Label()
        Me.rdbSabado = New Eniac.Controles.RadioButton()
        Me.rdbViernes = New Eniac.Controles.RadioButton()
        Me.rdbJueves = New Eniac.Controles.RadioButton()
        Me.rdbMiercoles = New Eniac.Controles.RadioButton()
        Me.rdbMartes = New Eniac.Controles.RadioButton()
        Me.rdbLunes = New Eniac.Controles.RadioButton()
        Me.tspRutas = New System.Windows.Forms.ToolStrip()
        Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
        Me.spcDatos = New System.Windows.Forms.SplitContainer()
        Me.ugClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.bdsClientes = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAgregar = New Eniac.Controles.Button()
        Me.pnlClientesTodosEncabezado = New System.Windows.Forms.Panel()
        Me.txtInfoClientes = New Eniac.Controles.TextBox()
        Me.ugRutas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.bdsRutas = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSacar = New Eniac.Controles.Button()
        Me.btnBajar = New Eniac.Controles.Button()
        Me.btnSubir = New Eniac.Controles.Button()
        Me.pnlClientesAsignadosEncabezado = New System.Windows.Forms.Panel()
        Me.txtInfoClienteAVisitar = New Eniac.Controles.TextBox()
        Me.stsPie = New System.Windows.Forms.StatusStrip()
        Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslContadorGrillaClientes = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslClientesAVisitar = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslVisitas = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tltAyuda = New System.Windows.Forms.ToolTip(Me.components)
        Me.chbAlineacionPaneles = New Eniac.Controles.CheckBox()
        Me.cmbRutas = New Eniac.Controles.ComboBox()
        Me.grbRuta.SuspendLayout()
        Me.grbDias.SuspendLayout()
        Me.tspRutas.SuspendLayout()
        CType(Me.spcDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcDatos.Panel1.SuspendLayout()
        Me.spcDatos.Panel2.SuspendLayout()
        Me.spcDatos.SuspendLayout()
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bdsClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlClientesTodosEncabezado.SuspendLayout()
        CType(Me.ugRutas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bdsRutas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlClientesAsignadosEncabezado.SuspendLayout()
        Me.stsPie.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbRuta
        '
        Me.grbRuta.Controls.Add(Me.btnConsultar)
        Me.grbRuta.Controls.Add(Me.lblInfoRuta)
        Me.grbRuta.Controls.Add(Me.cmbRutas)
        Me.grbRuta.Location = New System.Drawing.Point(12, 28)
        Me.grbRuta.Name = "grbRuta"
        Me.grbRuta.Size = New System.Drawing.Size(399, 50)
        Me.grbRuta.TabIndex = 3
        Me.grbRuta.TabStop = False
        Me.grbRuta.Text = "Ruta"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(297, 5)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 18
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'lblInfoRuta
        '
        Me.lblInfoRuta.AutoSize = True
        Me.lblInfoRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoRuta.LabelAsoc = Nothing
        Me.lblInfoRuta.Location = New System.Drawing.Point(6, 43)
        Me.lblInfoRuta.Name = "lblInfoRuta"
        Me.lblInfoRuta.Size = New System.Drawing.Size(0, 13)
        Me.lblInfoRuta.TabIndex = 17
        Me.tltAyuda.SetToolTip(Me.lblInfoRuta, "Vendedor")
        '
        'grbDias
        '
        Me.grbDias.Controls.Add(Me.lblDomingo)
        Me.grbDias.Controls.Add(Me.rdbDomingo)
        Me.grbDias.Controls.Add(Me.lblOtro)
        Me.grbDias.Controls.Add(Me.rdbOtro)
        Me.grbDias.Controls.Add(Me.lblSabado)
        Me.grbDias.Controls.Add(Me.lblViernes)
        Me.grbDias.Controls.Add(Me.lblJueves)
        Me.grbDias.Controls.Add(Me.lblMiercoles)
        Me.grbDias.Controls.Add(Me.lblMartes)
        Me.grbDias.Controls.Add(Me.lblLunes)
        Me.grbDias.Controls.Add(Me.rdbSabado)
        Me.grbDias.Controls.Add(Me.rdbViernes)
        Me.grbDias.Controls.Add(Me.rdbJueves)
        Me.grbDias.Controls.Add(Me.rdbMiercoles)
        Me.grbDias.Controls.Add(Me.rdbMartes)
        Me.grbDias.Controls.Add(Me.rdbLunes)
        Me.grbDias.Enabled = False
        Me.grbDias.Location = New System.Drawing.Point(414, 28)
        Me.grbDias.Name = "grbDias"
        Me.grbDias.Size = New System.Drawing.Size(558, 50)
        Me.grbDias.TabIndex = 2
        Me.grbDias.TabStop = False
        Me.grbDias.Text = "Dias"
        '
        'lblDomingo
        '
        Me.lblDomingo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDomingo.LabelAsoc = Nothing
        Me.lblDomingo.Location = New System.Drawing.Point(429, 31)
        Me.lblDomingo.Name = "lblDomingo"
        Me.lblDomingo.Size = New System.Drawing.Size(50, 15)
        Me.lblDomingo.TabIndex = 13
        Me.lblDomingo.Text = "0"
        Me.lblDomingo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'rdbDomingo
        '
        Me.rdbDomingo.AutoSize = True
        Me.rdbDomingo.BindearPropiedadControl = Nothing
        Me.rdbDomingo.BindearPropiedadEntidad = Nothing
        Me.rdbDomingo.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbDomingo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbDomingo.IsPK = False
        Me.rdbDomingo.IsRequired = False
        Me.rdbDomingo.Key = Nothing
        Me.rdbDomingo.LabelAsoc = Me.lblDomingo
        Me.rdbDomingo.Location = New System.Drawing.Point(429, 13)
        Me.rdbDomingo.Name = "rdbDomingo"
        Me.rdbDomingo.Size = New System.Drawing.Size(67, 17)
        Me.rdbDomingo.TabIndex = 12
        Me.rdbDomingo.Text = "Domingo"
        Me.rdbDomingo.UseVisualStyleBackColor = True
        '
        'lblOtro
        '
        Me.lblOtro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOtro.LabelAsoc = Nothing
        Me.lblOtro.Location = New System.Drawing.Point(501, 31)
        Me.lblOtro.Name = "lblOtro"
        Me.lblOtro.Size = New System.Drawing.Size(50, 15)
        Me.lblOtro.TabIndex = 13
        Me.lblOtro.Text = "0"
        Me.lblOtro.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'rdbOtro
        '
        Me.rdbOtro.AutoSize = True
        Me.rdbOtro.BindearPropiedadControl = Nothing
        Me.rdbOtro.BindearPropiedadEntidad = Nothing
        Me.rdbOtro.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbOtro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbOtro.IsPK = False
        Me.rdbOtro.IsRequired = False
        Me.rdbOtro.Key = Nothing
        Me.rdbOtro.LabelAsoc = Me.lblOtro
        Me.rdbOtro.Location = New System.Drawing.Point(501, 13)
        Me.rdbOtro.Name = "rdbOtro"
        Me.rdbOtro.Size = New System.Drawing.Size(45, 17)
        Me.rdbOtro.TabIndex = 12
        Me.rdbOtro.Text = "Otro"
        Me.rdbOtro.UseVisualStyleBackColor = True
        '
        'lblSabado
        '
        Me.lblSabado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSabado.LabelAsoc = Nothing
        Me.lblSabado.Location = New System.Drawing.Point(361, 31)
        Me.lblSabado.Name = "lblSabado"
        Me.lblSabado.Size = New System.Drawing.Size(50, 15)
        Me.lblSabado.TabIndex = 11
        Me.lblSabado.Text = "0"
        Me.lblSabado.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblViernes
        '
        Me.lblViernes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblViernes.LabelAsoc = Nothing
        Me.lblViernes.Location = New System.Drawing.Point(291, 31)
        Me.lblViernes.Name = "lblViernes"
        Me.lblViernes.Size = New System.Drawing.Size(50, 15)
        Me.lblViernes.TabIndex = 10
        Me.lblViernes.Text = "0"
        Me.lblViernes.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblJueves
        '
        Me.lblJueves.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblJueves.LabelAsoc = Nothing
        Me.lblJueves.Location = New System.Drawing.Point(221, 31)
        Me.lblJueves.Name = "lblJueves"
        Me.lblJueves.Size = New System.Drawing.Size(50, 15)
        Me.lblJueves.TabIndex = 9
        Me.lblJueves.Text = "0"
        Me.lblJueves.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMiercoles
        '
        Me.lblMiercoles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMiercoles.LabelAsoc = Nothing
        Me.lblMiercoles.Location = New System.Drawing.Point(151, 31)
        Me.lblMiercoles.Name = "lblMiercoles"
        Me.lblMiercoles.Size = New System.Drawing.Size(50, 15)
        Me.lblMiercoles.TabIndex = 8
        Me.lblMiercoles.Text = "0"
        Me.lblMiercoles.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMartes
        '
        Me.lblMartes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMartes.LabelAsoc = Nothing
        Me.lblMartes.Location = New System.Drawing.Point(81, 31)
        Me.lblMartes.Name = "lblMartes"
        Me.lblMartes.Size = New System.Drawing.Size(50, 15)
        Me.lblMartes.TabIndex = 7
        Me.lblMartes.Text = "0"
        Me.lblMartes.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblLunes
        '
        Me.lblLunes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLunes.LabelAsoc = Nothing
        Me.lblLunes.Location = New System.Drawing.Point(11, 31)
        Me.lblLunes.Name = "lblLunes"
        Me.lblLunes.Size = New System.Drawing.Size(50, 15)
        Me.lblLunes.TabIndex = 6
        Me.lblLunes.Text = "0"
        Me.lblLunes.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'rdbSabado
        '
        Me.rdbSabado.AutoSize = True
        Me.rdbSabado.BindearPropiedadControl = Nothing
        Me.rdbSabado.BindearPropiedadEntidad = Nothing
        Me.rdbSabado.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbSabado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbSabado.IsPK = False
        Me.rdbSabado.IsRequired = False
        Me.rdbSabado.Key = Nothing
        Me.rdbSabado.LabelAsoc = Me.lblSabado
        Me.rdbSabado.Location = New System.Drawing.Point(361, 13)
        Me.rdbSabado.Name = "rdbSabado"
        Me.rdbSabado.Size = New System.Drawing.Size(62, 17)
        Me.rdbSabado.TabIndex = 5
        Me.rdbSabado.Text = "Sabado"
        Me.rdbSabado.UseVisualStyleBackColor = True
        '
        'rdbViernes
        '
        Me.rdbViernes.AutoSize = True
        Me.rdbViernes.BindearPropiedadControl = Nothing
        Me.rdbViernes.BindearPropiedadEntidad = Nothing
        Me.rdbViernes.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbViernes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbViernes.IsPK = False
        Me.rdbViernes.IsRequired = False
        Me.rdbViernes.Key = Nothing
        Me.rdbViernes.LabelAsoc = Me.lblViernes
        Me.rdbViernes.Location = New System.Drawing.Point(291, 13)
        Me.rdbViernes.Name = "rdbViernes"
        Me.rdbViernes.Size = New System.Drawing.Size(60, 17)
        Me.rdbViernes.TabIndex = 4
        Me.rdbViernes.Text = "Viernes"
        Me.rdbViernes.UseVisualStyleBackColor = True
        '
        'rdbJueves
        '
        Me.rdbJueves.AutoSize = True
        Me.rdbJueves.BindearPropiedadControl = Nothing
        Me.rdbJueves.BindearPropiedadEntidad = Nothing
        Me.rdbJueves.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbJueves.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbJueves.IsPK = False
        Me.rdbJueves.IsRequired = False
        Me.rdbJueves.Key = Nothing
        Me.rdbJueves.LabelAsoc = Me.lblJueves
        Me.rdbJueves.Location = New System.Drawing.Point(221, 13)
        Me.rdbJueves.Name = "rdbJueves"
        Me.rdbJueves.Size = New System.Drawing.Size(59, 17)
        Me.rdbJueves.TabIndex = 3
        Me.rdbJueves.Text = "Jueves"
        Me.rdbJueves.UseVisualStyleBackColor = True
        '
        'rdbMiercoles
        '
        Me.rdbMiercoles.AutoSize = True
        Me.rdbMiercoles.BindearPropiedadControl = Nothing
        Me.rdbMiercoles.BindearPropiedadEntidad = Nothing
        Me.rdbMiercoles.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbMiercoles.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbMiercoles.IsPK = False
        Me.rdbMiercoles.IsRequired = False
        Me.rdbMiercoles.Key = Nothing
        Me.rdbMiercoles.LabelAsoc = Me.lblMiercoles
        Me.rdbMiercoles.Location = New System.Drawing.Point(151, 13)
        Me.rdbMiercoles.Name = "rdbMiercoles"
        Me.rdbMiercoles.Size = New System.Drawing.Size(70, 17)
        Me.rdbMiercoles.TabIndex = 2
        Me.rdbMiercoles.Text = "Miercoles"
        Me.rdbMiercoles.UseVisualStyleBackColor = True
        '
        'rdbMartes
        '
        Me.rdbMartes.AutoSize = True
        Me.rdbMartes.BindearPropiedadControl = Nothing
        Me.rdbMartes.BindearPropiedadEntidad = Nothing
        Me.rdbMartes.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbMartes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbMartes.IsPK = False
        Me.rdbMartes.IsRequired = False
        Me.rdbMartes.Key = Nothing
        Me.rdbMartes.LabelAsoc = Me.lblMartes
        Me.rdbMartes.Location = New System.Drawing.Point(81, 13)
        Me.rdbMartes.Name = "rdbMartes"
        Me.rdbMartes.Size = New System.Drawing.Size(57, 17)
        Me.rdbMartes.TabIndex = 1
        Me.rdbMartes.Text = "Martes"
        Me.rdbMartes.UseVisualStyleBackColor = True
        '
        'rdbLunes
        '
        Me.rdbLunes.AutoSize = True
        Me.rdbLunes.BindearPropiedadControl = Nothing
        Me.rdbLunes.BindearPropiedadEntidad = Nothing
        Me.rdbLunes.Checked = True
        Me.rdbLunes.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbLunes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbLunes.IsPK = False
        Me.rdbLunes.IsRequired = False
        Me.rdbLunes.Key = Nothing
        Me.rdbLunes.LabelAsoc = Me.lblLunes
        Me.rdbLunes.Location = New System.Drawing.Point(11, 13)
        Me.rdbLunes.Name = "rdbLunes"
        Me.rdbLunes.Size = New System.Drawing.Size(54, 17)
        Me.rdbLunes.TabIndex = 0
        Me.rdbLunes.TabStop = True
        Me.rdbLunes.Text = "Lunes"
        Me.rdbLunes.UseVisualStyleBackColor = True
        '
        'tspRutas
        '
        Me.tspRutas.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tspRutas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbGrabar, Me.ToolStripSeparator2, Me.tsbImprimir, Me.ToolStripSeparator1, Me.tsbPreferencias, Me.ToolStripSeparator3, Me.tsbCerrar})
        Me.tspRutas.Location = New System.Drawing.Point(0, 0)
        Me.tspRutas.Name = "tspRutas"
        Me.tspRutas.Size = New System.Drawing.Size(984, 29)
        Me.tspRutas.TabIndex = 4
        Me.tspRutas.Text = "ToolStrip1"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.diskette_32
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
        Me.tsbGrabar.Text = "&Grabar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        Me.ToolStripSeparator2.Visible = False
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Enabled = False
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCerrar
        '
        Me.tsbCerrar.Image = CType(resources.GetObject("tsbCerrar.Image"), System.Drawing.Image)
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
        Me.tsbCerrar.Text = "&Cerrar"
        '
        'spcDatos
        '
        Me.spcDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spcDatos.Enabled = False
        Me.spcDatos.Location = New System.Drawing.Point(12, 95)
        Me.spcDatos.Name = "spcDatos"
        Me.spcDatos.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcDatos.Panel1
        '
        Me.spcDatos.Panel1.Controls.Add(Me.ugClientes)
        Me.spcDatos.Panel1.Controls.Add(Me.Panel1)
        Me.spcDatos.Panel1.Controls.Add(Me.pnlClientesTodosEncabezado)
        '
        'spcDatos.Panel2
        '
        Me.spcDatos.Panel2.Controls.Add(Me.ugRutas)
        Me.spcDatos.Panel2.Controls.Add(Me.Panel2)
        Me.spcDatos.Panel2.Controls.Add(Me.pnlClientesAsignadosEncabezado)
        Me.spcDatos.Size = New System.Drawing.Size(960, 441)
        Me.spcDatos.SplitterDistance = 225
        Me.spcDatos.TabIndex = 6
        '
        'ugClientes
        '
        Me.ugClientes.DataSource = Me.bdsClientes
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugClientes.DisplayLayout.Appearance = Appearance1
        Me.ugClientes.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugClientes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugClientes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientes.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aqui para agrupar."
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugClientes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugClientes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugClientes.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugClientes.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugClientes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugClientes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugClientes.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugClientes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugClientes.DisplayLayout.Override.CellPadding = 0
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.ugClientes.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.ugClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugClientes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.ugClientes.DisplayLayout.Override.RowAppearance = Appearance11
        Me.ugClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugClientes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.ugClientes.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugClientes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugClientes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugClientes.Location = New System.Drawing.Point(0, 25)
        Me.ugClientes.Name = "ugClientes"
        Me.ugClientes.Size = New System.Drawing.Size(928, 200)
        Me.ugClientes.TabIndex = 6
        Me.ugClientes.Text = "UltraGrid1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAgregar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(928, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(32, 200)
        Me.Panel1.TabIndex = 5
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.add_24
        Me.btnAgregar.Location = New System.Drawing.Point(2, 35)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(27, 40)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'pnlClientesTodosEncabezado
        '
        Me.pnlClientesTodosEncabezado.Controls.Add(Me.txtInfoClientes)
        Me.pnlClientesTodosEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlClientesTodosEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlClientesTodosEncabezado.Name = "pnlClientesTodosEncabezado"
        Me.pnlClientesTodosEncabezado.Size = New System.Drawing.Size(960, 25)
        Me.pnlClientesTodosEncabezado.TabIndex = 3
        '
        'txtInfoClientes
        '
        Me.txtInfoClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInfoClientes.BindearPropiedadControl = Nothing
        Me.txtInfoClientes.BindearPropiedadEntidad = Nothing
        Me.txtInfoClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.txtInfoClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtInfoClientes.Formato = ""
        Me.txtInfoClientes.IsDecimal = False
        Me.txtInfoClientes.IsNumber = False
        Me.txtInfoClientes.IsPK = False
        Me.txtInfoClientes.IsRequired = False
        Me.txtInfoClientes.Key = ""
        Me.txtInfoClientes.LabelAsoc = Nothing
        Me.txtInfoClientes.Location = New System.Drawing.Point(5, 3)
        Me.txtInfoClientes.Name = "txtInfoClientes"
        Me.txtInfoClientes.ReadOnly = True
        Me.txtInfoClientes.Size = New System.Drawing.Size(952, 20)
        Me.txtInfoClientes.TabIndex = 0
        '
        'ugRutas
        '
        Me.ugRutas.DataSource = Me.bdsRutas
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugRutas.DisplayLayout.Appearance = Appearance13
        Me.ugRutas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.ugRutas.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugRutas.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRutas.DisplayLayout.GroupByBox.Appearance = Appearance14
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRutas.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
        Me.ugRutas.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugRutas.DisplayLayout.GroupByBox.Prompt = "Arrastre la columna aqui para agrupar."
        Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance16.BackColor2 = System.Drawing.SystemColors.Control
        Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRutas.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
        Me.ugRutas.DisplayLayout.MaxColScrollRegions = 1
        Me.ugRutas.DisplayLayout.MaxRowScrollRegions = 1
        Appearance17.BackColor = System.Drawing.SystemColors.Window
        Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugRutas.DisplayLayout.Override.ActiveCellAppearance = Appearance17
        Appearance18.BackColor = System.Drawing.SystemColors.Highlight
        Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugRutas.DisplayLayout.Override.ActiveRowAppearance = Appearance18
        Me.ugRutas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugRutas.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugRutas.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Me.ugRutas.DisplayLayout.Override.CardAreaAppearance = Appearance19
        Appearance20.BorderColor = System.Drawing.Color.Silver
        Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugRutas.DisplayLayout.Override.CellAppearance = Appearance20
        Me.ugRutas.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugRutas.DisplayLayout.Override.CellPadding = 0
        Appearance21.BackColor = System.Drawing.SystemColors.Control
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRutas.DisplayLayout.Override.GroupByRowAppearance = Appearance21
        Appearance22.TextHAlignAsString = "Left"
        Me.ugRutas.DisplayLayout.Override.HeaderAppearance = Appearance22
        Me.ugRutas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugRutas.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Appearance23.BorderColor = System.Drawing.Color.Silver
        Me.ugRutas.DisplayLayout.Override.RowAppearance = Appearance23
        Me.ugRutas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugRutas.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.ugRutas.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugRutas.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugRutas.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugRutas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugRutas.Location = New System.Drawing.Point(0, 25)
        Me.ugRutas.Name = "ugRutas"
        Me.ugRutas.Size = New System.Drawing.Size(928, 187)
        Me.ugRutas.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSacar)
        Me.Panel2.Controls.Add(Me.btnBajar)
        Me.Panel2.Controls.Add(Me.btnSubir)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(928, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(32, 187)
        Me.Panel2.TabIndex = 7
        '
        'btnSacar
        '
        Me.btnSacar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSacar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnSacar.Location = New System.Drawing.Point(2, 119)
        Me.btnSacar.Name = "btnSacar"
        Me.btnSacar.Size = New System.Drawing.Size(27, 40)
        Me.btnSacar.TabIndex = 1
        Me.btnSacar.UseVisualStyleBackColor = True
        '
        'btnBajar
        '
        Me.btnBajar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnBajar.Image = Global.Eniac.Win.My.Resources.Resources.navigate_down
        Me.btnBajar.Location = New System.Drawing.Point(2, 73)
        Me.btnBajar.Name = "btnBajar"
        Me.btnBajar.Size = New System.Drawing.Size(27, 40)
        Me.btnBajar.TabIndex = 3
        Me.btnBajar.UseVisualStyleBackColor = True
        '
        'btnSubir
        '
        Me.btnSubir.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSubir.Image = Global.Eniac.Win.My.Resources.Resources.navigate_up
        Me.btnSubir.Location = New System.Drawing.Point(2, 27)
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(27, 40)
        Me.btnSubir.TabIndex = 2
        Me.btnSubir.UseVisualStyleBackColor = True
        '
        'pnlClientesAsignadosEncabezado
        '
        Me.pnlClientesAsignadosEncabezado.Controls.Add(Me.txtInfoClienteAVisitar)
        Me.pnlClientesAsignadosEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlClientesAsignadosEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlClientesAsignadosEncabezado.Name = "pnlClientesAsignadosEncabezado"
        Me.pnlClientesAsignadosEncabezado.Size = New System.Drawing.Size(960, 25)
        Me.pnlClientesAsignadosEncabezado.TabIndex = 4
        '
        'txtInfoClienteAVisitar
        '
        Me.txtInfoClienteAVisitar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInfoClienteAVisitar.BindearPropiedadControl = Nothing
        Me.txtInfoClienteAVisitar.BindearPropiedadEntidad = Nothing
        Me.txtInfoClienteAVisitar.ForeColorFocus = System.Drawing.Color.Red
        Me.txtInfoClienteAVisitar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtInfoClienteAVisitar.Formato = ""
        Me.txtInfoClienteAVisitar.IsDecimal = False
        Me.txtInfoClienteAVisitar.IsNumber = False
        Me.txtInfoClienteAVisitar.IsPK = False
        Me.txtInfoClienteAVisitar.IsRequired = False
        Me.txtInfoClienteAVisitar.Key = ""
        Me.txtInfoClienteAVisitar.LabelAsoc = Nothing
        Me.txtInfoClienteAVisitar.Location = New System.Drawing.Point(2, 3)
        Me.txtInfoClienteAVisitar.Name = "txtInfoClienteAVisitar"
        Me.txtInfoClienteAVisitar.ReadOnly = True
        Me.txtInfoClienteAVisitar.Size = New System.Drawing.Size(951, 20)
        Me.txtInfoClienteAVisitar.TabIndex = 1
        '
        'stsPie
        '
        Me.stsPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto, Me.tslContadorGrillaClientes, Me.tslClientesAVisitar, Me.tslVisitas, Me.tspBarra})
        Me.stsPie.Location = New System.Drawing.Point(0, 539)
        Me.stsPie.Name = "stsPie"
        Me.stsPie.Size = New System.Drawing.Size(984, 22)
        Me.stsPie.TabIndex = 7
        Me.stsPie.Text = "StatusStrip1"
        '
        'tslTexto
        '
        Me.tslTexto.Name = "tslTexto"
        Me.tslTexto.Size = New System.Drawing.Size(654, 17)
        Me.tslTexto.Spring = True
        '
        'tslContadorGrillaClientes
        '
        Me.tslContadorGrillaClientes.Image = CType(resources.GetObject("tslContadorGrillaClientes.Image"), System.Drawing.Image)
        Me.tslContadorGrillaClientes.Name = "tslContadorGrillaClientes"
        Me.tslContadorGrillaClientes.Size = New System.Drawing.Size(133, 17)
        Me.tslContadorGrillaClientes.Text = "0 Clientes sin asignar"
        Me.tslContadorGrillaClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tslClientesAVisitar
        '
        Me.tslClientesAVisitar.Image = CType(resources.GetObject("tslClientesAVisitar.Image"), System.Drawing.Image)
        Me.tslClientesAVisitar.Name = "tslClientesAVisitar"
        Me.tslClientesAVisitar.Size = New System.Drawing.Size(117, 17)
        Me.tslClientesAVisitar.Text = "0 Clientes a visitar"
        '
        'tslVisitas
        '
        Me.tslVisitas.Image = CType(resources.GetObject("tslVisitas.Image"), System.Drawing.Image)
        Me.tslVisitas.Name = "tslVisitas"
        Me.tslVisitas.Size = New System.Drawing.Size(65, 17)
        Me.tslVisitas.Text = "0 Visitas"
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Visible = False
        '
        'tltAyuda
        '
        Me.tltAyuda.IsBalloon = True
        '
        'chbAlineacionPaneles
        '
        Me.chbAlineacionPaneles.AutoSize = True
        Me.chbAlineacionPaneles.BindearPropiedadControl = Nothing
        Me.chbAlineacionPaneles.BindearPropiedadEntidad = Nothing
        Me.chbAlineacionPaneles.Checked = True
        Me.chbAlineacionPaneles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbAlineacionPaneles.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAlineacionPaneles.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAlineacionPaneles.IsPK = False
        Me.chbAlineacionPaneles.IsRequired = False
        Me.chbAlineacionPaneles.Key = Nothing
        Me.chbAlineacionPaneles.LabelAsoc = Nothing
        Me.chbAlineacionPaneles.Location = New System.Drawing.Point(785, 77)
        Me.chbAlineacionPaneles.Name = "chbAlineacionPaneles"
        Me.chbAlineacionPaneles.Size = New System.Drawing.Size(187, 17)
        Me.chbAlineacionPaneles.TabIndex = 18
        Me.chbAlineacionPaneles.Text = "Alineacion Horinzontal de Paneles"
        Me.chbAlineacionPaneles.UseVisualStyleBackColor = True
        '
        'cmbRutas
        '
        Me.cmbRutas.BindearPropiedadControl = "SelectedValue"
        Me.cmbRutas.BindearPropiedadEntidad = "idRuta"
        Me.cmbRutas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRutas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbRutas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbRutas.FormattingEnabled = True
        Me.cmbRutas.IsPK = False
        Me.cmbRutas.IsRequired = False
        Me.cmbRutas.Key = Nothing
        Me.cmbRutas.LabelAsoc = Nothing
        Me.cmbRutas.Location = New System.Drawing.Point(6, 19)
        Me.cmbRutas.Name = "cmbRutas"
        Me.cmbRutas.Size = New System.Drawing.Size(163, 21)
        Me.cmbRutas.TabIndex = 1
        '
        'MovilRutasClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.grbDias)
        Me.Controls.Add(Me.chbAlineacionPaneles)
        Me.Controls.Add(Me.stsPie)
        Me.Controls.Add(Me.spcDatos)
        Me.Controls.Add(Me.tspRutas)
        Me.Controls.Add(Me.grbRuta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MovilRutasClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Clientes a Rutas"
        Me.grbRuta.ResumeLayout(False)
        Me.grbRuta.PerformLayout()
        Me.grbDias.ResumeLayout(False)
        Me.grbDias.PerformLayout()
        Me.tspRutas.ResumeLayout(False)
        Me.tspRutas.PerformLayout()
        Me.spcDatos.Panel1.ResumeLayout(False)
        Me.spcDatos.Panel2.ResumeLayout(False)
        CType(Me.spcDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcDatos.ResumeLayout(False)
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bdsClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlClientesTodosEncabezado.ResumeLayout(False)
        Me.pnlClientesTodosEncabezado.PerformLayout()
        CType(Me.ugRutas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bdsRutas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlClientesAsignadosEncabezado.ResumeLayout(False)
        Me.pnlClientesAsignadosEncabezado.PerformLayout()
        Me.stsPie.ResumeLayout(False)
        Me.stsPie.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbRuta As System.Windows.Forms.GroupBox
   Friend WithEvents cmbRutas As Eniac.Controles.ComboBox
   Friend WithEvents tspRutas As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbDias As System.Windows.Forms.GroupBox
   Friend WithEvents rdbMartes As Eniac.Controles.RadioButton
   Friend WithEvents rdbLunes As Eniac.Controles.RadioButton
   Friend WithEvents rdbSabado As Eniac.Controles.RadioButton
   Friend WithEvents rdbViernes As Eniac.Controles.RadioButton
   Friend WithEvents rdbJueves As Eniac.Controles.RadioButton
   Friend WithEvents rdbMiercoles As Eniac.Controles.RadioButton
   Friend WithEvents lblLunes As Eniac.Controles.Label
   Friend WithEvents lblSabado As Eniac.Controles.Label
   Friend WithEvents lblViernes As Eniac.Controles.Label
   Friend WithEvents lblJueves As Eniac.Controles.Label
   Friend WithEvents lblMiercoles As Eniac.Controles.Label
   Friend WithEvents lblMartes As Eniac.Controles.Label
   Friend WithEvents spcDatos As System.Windows.Forms.SplitContainer
   Friend WithEvents pnlClientesTodosEncabezado As System.Windows.Forms.Panel
   Friend WithEvents pnlClientesAsignadosEncabezado As System.Windows.Forms.Panel
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents btnAgregar As Eniac.Controles.Button
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents btnSacar As Eniac.Controles.Button
   Friend WithEvents btnBajar As Eniac.Controles.Button
   Friend WithEvents btnSubir As Eniac.Controles.Button
   Friend WithEvents stsPie As System.Windows.Forms.StatusStrip
   Friend WithEvents tslTexto As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents lblOtro As Eniac.Controles.Label
   Friend WithEvents rdbOtro As Eniac.Controles.RadioButton
   Friend WithEvents tslContadorGrillaClientes As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslVisitas As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslClientesAVisitar As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tltAyuda As System.Windows.Forms.ToolTip
   Friend WithEvents lblInfoRuta As Eniac.Controles.Label
   Friend WithEvents txtInfoClientes As Eniac.Controles.TextBox
   Friend WithEvents txtInfoClienteAVisitar As Eniac.Controles.TextBox
   Friend WithEvents ugClientes As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents ugRutas As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents chbAlineacionPaneles As Eniac.Controles.CheckBox
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents bdsClientes As System.Windows.Forms.BindingSource
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents bdsRutas As System.Windows.Forms.BindingSource
   Friend WithEvents lblDomingo As Eniac.Controles.Label
   Friend WithEvents rdbDomingo As Eniac.Controles.RadioButton
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
End Class
