<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormatoNombreArchivoExportacion
	Inherits Win.BaseForm

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
		Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
		Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
		Dim UltraTab3 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
		Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
		Me.lblInfoNumeroReparto = New Eniac.Controles.Label()
		Me.lblArrovaNroReparto = New Eniac.Controles.Label()
		Me.lblInfoNumeroComprobante = New Eniac.Controles.Label()
		Me.lblArrovaNumero = New Eniac.Controles.Label()
		Me.lblInfoCentroComprobante = New Eniac.Controles.Label()
		Me.lblArrovaCentroEmisor = New Eniac.Controles.Label()
		Me.lblInfoLetraComprobante = New Eniac.Controles.Label()
		Me.lblArrovaLetra = New Eniac.Controles.Label()
		Me.lblInfoTipoComprobante = New Eniac.Controles.Label()
		Me.lblArrovaTipo = New Eniac.Controles.Label()
		Me.lblInfoComprobante = New Eniac.Controles.Label()
		Me.lblArrovaComprobante = New Eniac.Controles.Label()
		Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
		Me.lblArrovaFantasiaEmpresa = New Eniac.Controles.Label()
		Me.lblArrovaCuitEmpresa = New Eniac.Controles.Label()
		Me.lblInfoCuitEmpresa = New Eniac.Controles.Label()
		Me.lblInfoNombreEmpresa = New Eniac.Controles.Label()
		Me.lblInfoFantasiaEmpresa = New Eniac.Controles.Label()
		Me.lblArrovaNombreEmpresa = New Eniac.Controles.Label()
		Me.UltraTabPageControl3 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
		Me.lblArrovaCuitCliente = New Eniac.Controles.Label()
		Me.lblArrovaNombreCliente = New Eniac.Controles.Label()
		Me.lblInfoCombreCliente = New Eniac.Controles.Label()
		Me.lblFantasiaCliente = New Eniac.Controles.Label()
		Me.lblInfoCuitCliente = New Eniac.Controles.Label()
		Me.lblArrovaFantasiaCliente = New Eniac.Controles.Label()
		Me.txtFormatoArchivoExportacion = New Eniac.Controles.TextBox()
		Me.gpbFormatoArchivoExportacion = New System.Windows.Forms.GroupBox()
		Me.gpbVariablesArchivoExportacion = New System.Windows.Forms.GroupBox()
		Me.tbpVariablesArchivoExportacion = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
		Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
		Me.btnAceptar = New System.Windows.Forms.Button()
		Me.btnCancelar = New System.Windows.Forms.Button()
		Me.UltraTabPageControl1.SuspendLayout()
		Me.UltraTabPageControl2.SuspendLayout()
		Me.UltraTabPageControl3.SuspendLayout()
		Me.gpbFormatoArchivoExportacion.SuspendLayout()
		Me.gpbVariablesArchivoExportacion.SuspendLayout()
		CType(Me.tbpVariablesArchivoExportacion, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.tbpVariablesArchivoExportacion.SuspendLayout()
		Me.SuspendLayout()
		'
		'UltraTabPageControl1
		'
		Me.UltraTabPageControl1.Controls.Add(Me.lblInfoNumeroReparto)
		Me.UltraTabPageControl1.Controls.Add(Me.lblArrovaNroReparto)
		Me.UltraTabPageControl1.Controls.Add(Me.lblInfoNumeroComprobante)
		Me.UltraTabPageControl1.Controls.Add(Me.lblArrovaNumero)
		Me.UltraTabPageControl1.Controls.Add(Me.lblInfoCentroComprobante)
		Me.UltraTabPageControl1.Controls.Add(Me.lblArrovaCentroEmisor)
		Me.UltraTabPageControl1.Controls.Add(Me.lblInfoLetraComprobante)
		Me.UltraTabPageControl1.Controls.Add(Me.lblArrovaLetra)
		Me.UltraTabPageControl1.Controls.Add(Me.lblInfoTipoComprobante)
		Me.UltraTabPageControl1.Controls.Add(Me.lblArrovaTipo)
		Me.UltraTabPageControl1.Controls.Add(Me.lblInfoComprobante)
		Me.UltraTabPageControl1.Controls.Add(Me.lblArrovaComprobante)
		Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
		Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
		Me.UltraTabPageControl1.Size = New System.Drawing.Size(578, 205)
		'
		'lblInfoNumeroReparto
		'
		Me.lblInfoNumeroReparto.AutoSize = True
		Me.lblInfoNumeroReparto.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoNumeroReparto.LabelAsoc = Nothing
		Me.lblInfoNumeroReparto.Location = New System.Drawing.Point(230, 144)
		Me.lblInfoNumeroReparto.Name = "lblInfoNumeroReparto"
		Me.lblInfoNumeroReparto.Size = New System.Drawing.Size(208, 13)
		Me.lblInfoNumeroReparto.TabIndex = 80
		Me.lblInfoNumeroReparto.Text = "- Numero del Reparto.- Ejemplo  00000032"
		'
		'lblArrovaNroReparto
		'
		Me.lblArrovaNroReparto.AutoSize = True
		Me.lblArrovaNroReparto.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaNroReparto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaNroReparto.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaNroReparto.LabelAsoc = Nothing
		Me.lblArrovaNroReparto.Location = New System.Drawing.Point(14, 144)
		Me.lblArrovaNroReparto.Name = "lblArrovaNroReparto"
		Me.lblArrovaNroReparto.Size = New System.Drawing.Size(151, 13)
		Me.lblArrovaNroReparto.TabIndex = 81
		Me.lblArrovaNroReparto.Text = "@@NUMEROREPARTO@@"
		'
		'lblInfoNumeroComprobante
		'
		Me.lblInfoNumeroComprobante.AutoSize = True
		Me.lblInfoNumeroComprobante.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoNumeroComprobante.LabelAsoc = Nothing
		Me.lblInfoNumeroComprobante.Location = New System.Drawing.Point(259, 113)
		Me.lblInfoNumeroComprobante.Name = "lblInfoNumeroComprobante"
		Me.lblInfoNumeroComprobante.Size = New System.Drawing.Size(233, 13)
		Me.lblInfoNumeroComprobante.TabIndex = 78
		Me.lblInfoNumeroComprobante.Text = "- Numero del Comprobante.- Ejemplo  00035932"
		'
		'lblArrovaNumero
		'
		Me.lblArrovaNumero.AutoSize = True
		Me.lblArrovaNumero.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaNumero.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaNumero.LabelAsoc = Nothing
		Me.lblArrovaNumero.Location = New System.Drawing.Point(43, 113)
		Me.lblArrovaNumero.Name = "lblArrovaNumero"
		Me.lblArrovaNumero.Size = New System.Drawing.Size(153, 13)
		Me.lblArrovaNumero.TabIndex = 79
		Me.lblArrovaNumero.Text = "@@NUMEROCOMPROB@@"
		'
		'lblInfoCentroComprobante
		'
		Me.lblInfoCentroComprobante.AutoSize = True
		Me.lblInfoCentroComprobante.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoCentroComprobante.LabelAsoc = Nothing
		Me.lblInfoCentroComprobante.Location = New System.Drawing.Point(259, 91)
		Me.lblInfoCentroComprobante.Name = "lblInfoCentroComprobante"
		Me.lblInfoCentroComprobante.Size = New System.Drawing.Size(237, 13)
		Me.lblInfoCentroComprobante.TabIndex = 76
		Me.lblInfoCentroComprobante.Text = "- Centro Emisor del Comprobante.- Ejemplo  0001"
		'
		'lblArrovaCentroEmisor
		'
		Me.lblArrovaCentroEmisor.AutoSize = True
		Me.lblArrovaCentroEmisor.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaCentroEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaCentroEmisor.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaCentroEmisor.LabelAsoc = Nothing
		Me.lblArrovaCentroEmisor.Location = New System.Drawing.Point(43, 91)
		Me.lblArrovaCentroEmisor.Name = "lblArrovaCentroEmisor"
		Me.lblArrovaCentroEmisor.Size = New System.Drawing.Size(192, 13)
		Me.lblArrovaCentroEmisor.TabIndex = 77
		Me.lblArrovaCentroEmisor.Text = "@@CENTROEMISORCOMPROB@@"
		'
		'lblInfoLetraComprobante
		'
		Me.lblInfoLetraComprobante.AutoSize = True
		Me.lblInfoLetraComprobante.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoLetraComprobante.LabelAsoc = Nothing
		Me.lblInfoLetraComprobante.Location = New System.Drawing.Point(259, 67)
		Me.lblInfoLetraComprobante.Name = "lblInfoLetraComprobante"
		Me.lblInfoLetraComprobante.Size = New System.Drawing.Size(179, 13)
		Me.lblInfoLetraComprobante.TabIndex = 74
		Me.lblInfoLetraComprobante.Text = "- Letra del Comprobante.- Ejemplo  X"
		'
		'lblArrovaLetra
		'
		Me.lblArrovaLetra.AutoSize = True
		Me.lblArrovaLetra.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaLetra.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaLetra.LabelAsoc = Nothing
		Me.lblArrovaLetra.Location = New System.Drawing.Point(43, 67)
		Me.lblArrovaLetra.Name = "lblArrovaLetra"
		Me.lblArrovaLetra.Size = New System.Drawing.Size(140, 13)
		Me.lblArrovaLetra.TabIndex = 75
		Me.lblArrovaLetra.Text = "@@LETRACOMPROB@@"
		'
		'lblInfoTipoComprobante
		'
		Me.lblInfoTipoComprobante.AutoSize = True
		Me.lblInfoTipoComprobante.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoTipoComprobante.LabelAsoc = Nothing
		Me.lblInfoTipoComprobante.Location = New System.Drawing.Point(259, 43)
		Me.lblInfoTipoComprobante.Name = "lblInfoTipoComprobante"
		Me.lblInfoTipoComprobante.Size = New System.Drawing.Size(225, 13)
		Me.lblInfoTipoComprobante.TabIndex = 72
		Me.lblInfoTipoComprobante.Text = "- Tipo de Comprobante.- Ejemplo  Rem.Transp"
		'
		'lblArrovaTipo
		'
		Me.lblArrovaTipo.AutoSize = True
		Me.lblArrovaTipo.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaTipo.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaTipo.LabelAsoc = Nothing
		Me.lblArrovaTipo.Location = New System.Drawing.Point(43, 43)
		Me.lblArrovaTipo.Name = "lblArrovaTipo"
		Me.lblArrovaTipo.Size = New System.Drawing.Size(130, 13)
		Me.lblArrovaTipo.TabIndex = 73
		Me.lblArrovaTipo.Text = "@@TIPOCOMPROB@@"
		'
		'lblInfoComprobante
		'
		Me.lblInfoComprobante.AutoSize = True
		Me.lblInfoComprobante.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoComprobante.LabelAsoc = Nothing
		Me.lblInfoComprobante.Location = New System.Drawing.Point(173, 16)
		Me.lblInfoComprobante.Name = "lblInfoComprobante"
		Me.lblInfoComprobante.Size = New System.Drawing.Size(363, 13)
		Me.lblInfoComprobante.TabIndex = 70
		Me.lblInfoComprobante.Text = "- Datos propio del Comprobante.- Ejemplo  Rem.Transp_X_0001_00035932"
		'
		'lblArrovaComprobante
		'
		Me.lblArrovaComprobante.AutoSize = True
		Me.lblArrovaComprobante.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaComprobante.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaComprobante.LabelAsoc = Nothing
		Me.lblArrovaComprobante.Location = New System.Drawing.Point(14, 16)
		Me.lblArrovaComprobante.Name = "lblArrovaComprobante"
		Me.lblArrovaComprobante.Size = New System.Drawing.Size(134, 13)
		Me.lblArrovaComprobante.TabIndex = 71
		Me.lblArrovaComprobante.Text = "@@COMPROBANTE@@"
		'
		'UltraTabPageControl2
		'
		Me.UltraTabPageControl2.Controls.Add(Me.lblArrovaFantasiaEmpresa)
		Me.UltraTabPageControl2.Controls.Add(Me.lblArrovaCuitEmpresa)
		Me.UltraTabPageControl2.Controls.Add(Me.lblInfoCuitEmpresa)
		Me.UltraTabPageControl2.Controls.Add(Me.lblInfoNombreEmpresa)
		Me.UltraTabPageControl2.Controls.Add(Me.lblInfoFantasiaEmpresa)
		Me.UltraTabPageControl2.Controls.Add(Me.lblArrovaNombreEmpresa)
		Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
		Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
		Me.UltraTabPageControl2.Size = New System.Drawing.Size(578, 205)
		'
		'lblArrovaFantasiaEmpresa
		'
		Me.lblArrovaFantasiaEmpresa.AutoSize = True
		Me.lblArrovaFantasiaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaFantasiaEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaFantasiaEmpresa.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaFantasiaEmpresa.LabelAsoc = Nothing
		Me.lblArrovaFantasiaEmpresa.Location = New System.Drawing.Point(14, 64)
		Me.lblArrovaFantasiaEmpresa.Name = "lblArrovaFantasiaEmpresa"
		Me.lblArrovaFantasiaEmpresa.Size = New System.Drawing.Size(202, 13)
		Me.lblArrovaFantasiaEmpresa.TabIndex = 77
		Me.lblArrovaFantasiaEmpresa.Text = "@@NOMBREFANTASIAEMPRESA@@"
		'
		'lblArrovaCuitEmpresa
		'
		Me.lblArrovaCuitEmpresa.AutoSize = True
		Me.lblArrovaCuitEmpresa.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaCuitEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaCuitEmpresa.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaCuitEmpresa.LabelAsoc = Nothing
		Me.lblArrovaCuitEmpresa.Location = New System.Drawing.Point(14, 16)
		Me.lblArrovaCuitEmpresa.Name = "lblArrovaCuitEmpresa"
		Me.lblArrovaCuitEmpresa.Size = New System.Drawing.Size(128, 13)
		Me.lblArrovaCuitEmpresa.TabIndex = 73
		Me.lblArrovaCuitEmpresa.Text = "@@CUITEMPRESA@@"
		'
		'lblInfoCuitEmpresa
		'
		Me.lblInfoCuitEmpresa.AutoSize = True
		Me.lblInfoCuitEmpresa.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoCuitEmpresa.LabelAsoc = Nothing
		Me.lblInfoCuitEmpresa.Location = New System.Drawing.Point(231, 16)
		Me.lblInfoCuitEmpresa.Name = "lblInfoCuitEmpresa"
		Me.lblInfoCuitEmpresa.Size = New System.Drawing.Size(176, 13)
		Me.lblInfoCuitEmpresa.TabIndex = 72
		Me.lblInfoCuitEmpresa.Text = "- CUIT perteneciente a la Empresa.-"
		'
		'lblInfoNombreEmpresa
		'
		Me.lblInfoNombreEmpresa.AutoSize = True
		Me.lblInfoNombreEmpresa.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoNombreEmpresa.LabelAsoc = Nothing
		Me.lblInfoNombreEmpresa.Location = New System.Drawing.Point(231, 39)
		Me.lblInfoNombreEmpresa.Name = "lblInfoNombreEmpresa"
		Me.lblInfoNombreEmpresa.Size = New System.Drawing.Size(152, 13)
		Me.lblInfoNombreEmpresa.TabIndex = 74
		Me.lblInfoNombreEmpresa.Text = "- Razon Social de la Empresa.-"
		'
		'lblInfoFantasiaEmpresa
		'
		Me.lblInfoFantasiaEmpresa.AutoSize = True
		Me.lblInfoFantasiaEmpresa.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoFantasiaEmpresa.LabelAsoc = Nothing
		Me.lblInfoFantasiaEmpresa.Location = New System.Drawing.Point(231, 64)
		Me.lblInfoFantasiaEmpresa.Name = "lblInfoFantasiaEmpresa"
		Me.lblInfoFantasiaEmpresa.Size = New System.Drawing.Size(184, 13)
		Me.lblInfoFantasiaEmpresa.TabIndex = 76
		Me.lblInfoFantasiaEmpresa.Text = "- Nombre de Fantasia de la Empresa.-"
		'
		'lblArrovaNombreEmpresa
		'
		Me.lblArrovaNombreEmpresa.AutoSize = True
		Me.lblArrovaNombreEmpresa.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaNombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaNombreEmpresa.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaNombreEmpresa.LabelAsoc = Nothing
		Me.lblArrovaNombreEmpresa.Location = New System.Drawing.Point(14, 39)
		Me.lblArrovaNombreEmpresa.Name = "lblArrovaNombreEmpresa"
		Me.lblArrovaNombreEmpresa.Size = New System.Drawing.Size(150, 13)
		Me.lblArrovaNombreEmpresa.TabIndex = 75
		Me.lblArrovaNombreEmpresa.Text = "@@NOMBREEMPRESA@@"
		'
		'UltraTabPageControl3
		'
		Me.UltraTabPageControl3.Controls.Add(Me.lblArrovaCuitCliente)
		Me.UltraTabPageControl3.Controls.Add(Me.lblArrovaNombreCliente)
		Me.UltraTabPageControl3.Controls.Add(Me.lblInfoCombreCliente)
		Me.UltraTabPageControl3.Controls.Add(Me.lblFantasiaCliente)
		Me.UltraTabPageControl3.Controls.Add(Me.lblInfoCuitCliente)
		Me.UltraTabPageControl3.Controls.Add(Me.lblArrovaFantasiaCliente)
		Me.UltraTabPageControl3.Location = New System.Drawing.Point(1, 22)
		Me.UltraTabPageControl3.Name = "UltraTabPageControl3"
		Me.UltraTabPageControl3.Size = New System.Drawing.Size(578, 205)
		'
		'lblArrovaCuitCliente
		'
		Me.lblArrovaCuitCliente.AutoSize = True
		Me.lblArrovaCuitCliente.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaCuitCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaCuitCliente.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaCuitCliente.LabelAsoc = Nothing
		Me.lblArrovaCuitCliente.Location = New System.Drawing.Point(14, 64)
		Me.lblArrovaCuitCliente.Name = "lblArrovaCuitCliente"
		Me.lblArrovaCuitCliente.Size = New System.Drawing.Size(121, 13)
		Me.lblArrovaCuitCliente.TabIndex = 83
		Me.lblArrovaCuitCliente.Text = "@@CUITCLIENTE@@"
		'
		'lblArrovaNombreCliente
		'
		Me.lblArrovaNombreCliente.AutoSize = True
		Me.lblArrovaNombreCliente.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaNombreCliente.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaNombreCliente.LabelAsoc = Nothing
		Me.lblArrovaNombreCliente.Location = New System.Drawing.Point(14, 16)
		Me.lblArrovaNombreCliente.Name = "lblArrovaNombreCliente"
		Me.lblArrovaNombreCliente.Size = New System.Drawing.Size(143, 13)
		Me.lblArrovaNombreCliente.TabIndex = 79
		Me.lblArrovaNombreCliente.Text = "@@NOMBRECLIENTE@@"
		'
		'lblInfoCombreCliente
		'
		Me.lblInfoCombreCliente.AutoSize = True
		Me.lblInfoCombreCliente.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoCombreCliente.LabelAsoc = Nothing
		Me.lblInfoCombreCliente.Location = New System.Drawing.Point(231, 16)
		Me.lblInfoCombreCliente.Name = "lblInfoCombreCliente"
		Me.lblInfoCombreCliente.Size = New System.Drawing.Size(108, 13)
		Me.lblInfoCombreCliente.TabIndex = 78
		Me.lblInfoCombreCliente.Text = "- Nombre del Cliente.-"
		'
		'lblFantasiaCliente
		'
		Me.lblFantasiaCliente.AutoSize = True
		Me.lblFantasiaCliente.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblFantasiaCliente.LabelAsoc = Nothing
		Me.lblFantasiaCliente.Location = New System.Drawing.Point(231, 39)
		Me.lblFantasiaCliente.Name = "lblFantasiaCliente"
		Me.lblFantasiaCliente.Size = New System.Drawing.Size(166, 13)
		Me.lblFantasiaCliente.TabIndex = 80
		Me.lblFantasiaCliente.Text = "- Nombre de Fantasia del Cliente.-"
		'
		'lblInfoCuitCliente
		'
		Me.lblInfoCuitCliente.AutoSize = True
		Me.lblInfoCuitCliente.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lblInfoCuitCliente.LabelAsoc = Nothing
		Me.lblInfoCuitCliente.Location = New System.Drawing.Point(231, 64)
		Me.lblInfoCuitCliente.Name = "lblInfoCuitCliente"
		Me.lblInfoCuitCliente.Size = New System.Drawing.Size(96, 13)
		Me.lblInfoCuitCliente.TabIndex = 82
		Me.lblInfoCuitCliente.Text = "- CUIT del Cliente.-"
		'
		'lblArrovaFantasiaCliente
		'
		Me.lblArrovaFantasiaCliente.AutoSize = True
		Me.lblArrovaFantasiaCliente.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lblArrovaFantasiaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblArrovaFantasiaCliente.ForeColor = System.Drawing.Color.Green
		Me.lblArrovaFantasiaCliente.LabelAsoc = Nothing
		Me.lblArrovaFantasiaCliente.Location = New System.Drawing.Point(14, 39)
		Me.lblArrovaFantasiaCliente.Name = "lblArrovaFantasiaCliente"
		Me.lblArrovaFantasiaCliente.Size = New System.Drawing.Size(195, 13)
		Me.lblArrovaFantasiaCliente.TabIndex = 81
		Me.lblArrovaFantasiaCliente.Text = "@@NOMBREFANTASIACLIENTE@@"
		'
		'txtFormatoArchivoExportacion
		'
		Me.txtFormatoArchivoExportacion.BindearPropiedadControl = Nothing
		Me.txtFormatoArchivoExportacion.BindearPropiedadEntidad = Nothing
		Me.txtFormatoArchivoExportacion.ForeColorFocus = System.Drawing.Color.Red
		Me.txtFormatoArchivoExportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtFormatoArchivoExportacion.Formato = ""
		Me.txtFormatoArchivoExportacion.IsDecimal = False
		Me.txtFormatoArchivoExportacion.IsNumber = False
		Me.txtFormatoArchivoExportacion.IsPK = False
		Me.txtFormatoArchivoExportacion.IsRequired = False
		Me.txtFormatoArchivoExportacion.Key = ""
		Me.txtFormatoArchivoExportacion.LabelAsoc = Nothing
		Me.txtFormatoArchivoExportacion.Location = New System.Drawing.Point(10, 19)
		Me.txtFormatoArchivoExportacion.Name = "txtFormatoArchivoExportacion"
		Me.txtFormatoArchivoExportacion.Size = New System.Drawing.Size(580, 20)
		Me.txtFormatoArchivoExportacion.TabIndex = 79
		Me.txtFormatoArchivoExportacion.Tag = "UBICACIONARCHIVOSPDA"
		'
		'gpbFormatoArchivoExportacion
		'
		Me.gpbFormatoArchivoExportacion.Controls.Add(Me.txtFormatoArchivoExportacion)
		Me.gpbFormatoArchivoExportacion.Location = New System.Drawing.Point(13, 12)
		Me.gpbFormatoArchivoExportacion.Name = "gpbFormatoArchivoExportacion"
		Me.gpbFormatoArchivoExportacion.Size = New System.Drawing.Size(610, 55)
		Me.gpbFormatoArchivoExportacion.TabIndex = 80
		Me.gpbFormatoArchivoExportacion.TabStop = False
		Me.gpbFormatoArchivoExportacion.Text = "Formato para Nombre de Archivo de Exportacion."
		'
		'gpbVariablesArchivoExportacion
		'
		Me.gpbVariablesArchivoExportacion.Controls.Add(Me.tbpVariablesArchivoExportacion)
		Me.gpbVariablesArchivoExportacion.Location = New System.Drawing.Point(13, 73)
		Me.gpbVariablesArchivoExportacion.Name = "gpbVariablesArchivoExportacion"
		Me.gpbVariablesArchivoExportacion.Size = New System.Drawing.Size(610, 266)
		Me.gpbVariablesArchivoExportacion.TabIndex = 82
		Me.gpbVariablesArchivoExportacion.TabStop = False
		Me.gpbVariablesArchivoExportacion.Text = "Variables de Selección."
		'
		'tbpVariablesArchivoExportacion
		'
		Me.tbpVariablesArchivoExportacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.tbpVariablesArchivoExportacion.Controls.Add(Me.UltraTabSharedControlsPage1)
		Me.tbpVariablesArchivoExportacion.Controls.Add(Me.UltraTabPageControl1)
		Me.tbpVariablesArchivoExportacion.Controls.Add(Me.UltraTabPageControl2)
		Me.tbpVariablesArchivoExportacion.Controls.Add(Me.UltraTabPageControl3)
		Me.tbpVariablesArchivoExportacion.Location = New System.Drawing.Point(14, 16)
		Me.tbpVariablesArchivoExportacion.Name = "tbpVariablesArchivoExportacion"
		Me.tbpVariablesArchivoExportacion.SharedControlsPage = Me.UltraTabSharedControlsPage1
		Me.tbpVariablesArchivoExportacion.Size = New System.Drawing.Size(580, 228)
		Me.tbpVariablesArchivoExportacion.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon
		Me.tbpVariablesArchivoExportacion.TabIndex = 83
		UltraTab1.Key = "utcComprobante"
		UltraTab1.TabPage = Me.UltraTabPageControl1
		UltraTab1.Text = "Comprobante"
		UltraTab2.Key = "utcEmpresa"
		UltraTab2.TabPage = Me.UltraTabPageControl2
		UltraTab2.Text = "Empresa"
		UltraTab3.Key = "utcCliente"
		UltraTab3.TabPage = Me.UltraTabPageControl3
		UltraTab3.Text = "Cliente"
		Me.tbpVariablesArchivoExportacion.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2, UltraTab3})
		'
		'UltraTabSharedControlsPage1
		'
		Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
		Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
		Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(578, 205)
		'
		'btnAceptar
		'
		Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
		Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnAceptar.Location = New System.Drawing.Point(457, 345)
		Me.btnAceptar.Name = "btnAceptar"
		Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
		Me.btnAceptar.TabIndex = 84
		Me.btnAceptar.Text = "&Aceptar"
		Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnAceptar.UseVisualStyleBackColor = True
		'
		'btnCancelar
		'
		Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_a_16
		Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnCancelar.Location = New System.Drawing.Point(543, 345)
		Me.btnCancelar.Name = "btnCancelar"
		Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
		Me.btnCancelar.TabIndex = 83
		Me.btnCancelar.Text = "&Cancelar"
		Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnCancelar.UseVisualStyleBackColor = True
		'
		'FormatoNombreArchivoExportacion
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(636, 387)
		Me.Controls.Add(Me.btnAceptar)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.gpbVariablesArchivoExportacion)
		Me.Controls.Add(Me.gpbFormatoArchivoExportacion)
		Me.Name = "FormatoNombreArchivoExportacion"
		Me.Text = "FormatoNombreArchivoExportacion"
		Me.UltraTabPageControl1.ResumeLayout(False)
		Me.UltraTabPageControl1.PerformLayout()
		Me.UltraTabPageControl2.ResumeLayout(False)
		Me.UltraTabPageControl2.PerformLayout()
		Me.UltraTabPageControl3.ResumeLayout(False)
		Me.UltraTabPageControl3.PerformLayout()
		Me.gpbFormatoArchivoExportacion.ResumeLayout(False)
		Me.gpbFormatoArchivoExportacion.PerformLayout()
		Me.gpbVariablesArchivoExportacion.ResumeLayout(False)
		CType(Me.tbpVariablesArchivoExportacion, System.ComponentModel.ISupportInitialize).EndInit()
		Me.tbpVariablesArchivoExportacion.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents lblArrovaFantasiaEmpresa As Controles.Label
	Friend WithEvents lblInfoFantasiaEmpresa As Controles.Label
	Friend WithEvents lblArrovaNombreEmpresa As Controles.Label
	Friend WithEvents lblInfoNombreEmpresa As Controles.Label
	Friend WithEvents lblArrovaCuitEmpresa As Controles.Label
	Friend WithEvents lblInfoCuitEmpresa As Controles.Label
	Friend WithEvents lblArrovaComprobante As Controles.Label
	Friend WithEvents lblInfoComprobante As Controles.Label
	Friend WithEvents txtFormatoArchivoExportacion As Controles.TextBox
	Friend WithEvents gpbFormatoArchivoExportacion As GroupBox
	Friend WithEvents gpbVariablesArchivoExportacion As GroupBox
	Friend WithEvents tbpVariablesArchivoExportacion As UltraWinTabControl.UltraTabControl
	Friend WithEvents UltraTabSharedControlsPage1 As UltraWinTabControl.UltraTabSharedControlsPage
	Friend WithEvents UltraTabPageControl1 As UltraWinTabControl.UltraTabPageControl
	Friend WithEvents lblInfoNumeroComprobante As Controles.Label
	Friend WithEvents lblArrovaNumero As Controles.Label
	Friend WithEvents lblInfoCentroComprobante As Controles.Label
	Friend WithEvents lblArrovaCentroEmisor As Controles.Label
	Friend WithEvents lblInfoLetraComprobante As Controles.Label
	Friend WithEvents lblArrovaLetra As Controles.Label
	Friend WithEvents lblInfoTipoComprobante As Controles.Label
	Friend WithEvents lblArrovaTipo As Controles.Label
	Friend WithEvents UltraTabPageControl2 As UltraWinTabControl.UltraTabPageControl
	Friend WithEvents UltraTabPageControl3 As UltraWinTabControl.UltraTabPageControl
	Friend WithEvents lblArrovaCuitCliente As Controles.Label
	Friend WithEvents lblArrovaNombreCliente As Controles.Label
	Friend WithEvents lblInfoCombreCliente As Controles.Label
	Friend WithEvents lblFantasiaCliente As Controles.Label
	Friend WithEvents lblInfoCuitCliente As Controles.Label
	Friend WithEvents lblArrovaFantasiaCliente As Controles.Label
	Protected WithEvents btnAceptar As Button
	Protected WithEvents btnCancelar As Button
	Friend WithEvents lblInfoNumeroReparto As Controles.Label
	Friend WithEvents lblArrovaNroReparto As Controles.Label
End Class
