<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteFiscalElectronico
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteFiscalElectronico))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdImpresora")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Secuencia")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ZetaDesde")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ZetaHasta")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaExtraccionDesde")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaExtraccionHasta")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaExtraccion")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuarioExtraccion")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreArchivo")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MD5Archivo")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
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
        Me.dtpAuditoriaPorFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.lblAuditoriaPorFechaHasta = New Eniac.Controles.Label()
        Me.dtpAuditoriaPorFechaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblAuditoriaPorFechaDesde = New Eniac.Controles.Label()
        Me.txtAuditoriaPorNroZetaHasta = New Eniac.Controles.TextBox()
        Me.lblAuditoriaPorNroZetaHasta = New Eniac.Controles.Label()
        Me.txtAuditoriaPorNroZetaDesde = New Eniac.Controles.TextBox()
        Me.lblAuditoriaPorNroZetaDesde = New Eniac.Controles.Label()
        Me.lblAuditoriaPorFechaNombreArchivo = New Eniac.Controles.Label()
        Me.txtAuditoriaPorFechaNombreArchivo = New Eniac.Controles.TextBox()
        Me.lblAuditoriaPorNroZetaNombreArchivo = New Eniac.Controles.Label()
        Me.txtAuditoriaPorNroZetaNombreArchivo = New Eniac.Controles.TextBox()
        Me.grpAuditoriaPorFecha = New System.Windows.Forms.GroupBox()
        Me.btnAuditoriaPorFechaNombreArchivo = New Eniac.Controles.Button()
        Me.btnExportarAuditoriaPorFecha = New System.Windows.Forms.Button()
        Me.grpAuditoriaPorNroZeta = New System.Windows.Forms.GroupBox()
        Me.btnAuditoriaPorNroZetaNombreArchivo = New Eniac.Controles.Button()
        Me.btnExportarAuditoriaPorNroZeta = New System.Windows.Forms.Button()
        Me.grpExportarInformeParaAFIPPorFecha = New System.Windows.Forms.GroupBox()
        Me.btnInformeParaAFIPPorFechaNombreDirectorio = New Eniac.Controles.Button()
        Me.btnExportarInformeParaAFIPPorFecha = New System.Windows.Forms.Button()
        Me.dtpInformeParaAFIPPorFechaDesde = New Eniac.Controles.DateTimePicker()
        Me.lblInformeParaAFIPPorFechaDesde = New Eniac.Controles.Label()
        Me.lblInformeParaAFIPPorFechaHasta = New Eniac.Controles.Label()
        Me.dtpInformeParaAFIPPorFechaHasta = New Eniac.Controles.DateTimePicker()
        Me.txtInformeParaAFIPPorFechaNombreDirectorio = New Eniac.Controles.TextBox()
        Me.lblInformeParaAFIPPorFechaNombreDirectorio = New Eniac.Controles.Label()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpImpresora = New System.Windows.Forms.GroupBox()
        Me.lblPuerto = New Eniac.Controles.Label()
        Me.txtPuerto = New Eniac.Controles.TextBox()
        Me.lblMetodo = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.txtMetodoImpresion = New Eniac.Controles.TextBox()
        Me.txtTipoImpresora = New Eniac.Controles.TextBox()
        Me.txtModelo = New Eniac.Controles.TextBox()
        Me.lblModelo = New Eniac.Controles.Label()
        Me.txtCentroEmisor = New Eniac.Controles.TextBox()
        Me.lblCentroEmisor = New Eniac.Controles.Label()
        Me.lblTipo = New Eniac.Controles.Label()
        Me.txtMarca = New Eniac.Controles.TextBox()
        Me.txtIdImpresora = New Eniac.Controles.TextBox()
        Me.lblId = New Eniac.Controles.Label()
        Me.stsEstado = New System.Windows.Forms.StatusStrip()
        Me.tssError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sfdAuditoriaPorFechaNombreArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.sfdAuditoriaPorNroZetaNombreArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.fbdInformeParaAFIPPorFechaNombreDirectorio = New System.Windows.Forms.FolderBrowserDialog()
        Me.ugExtracciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grpAuditoriaPorFecha.SuspendLayout()
        Me.grpAuditoriaPorNroZeta.SuspendLayout()
        Me.grpExportarInformeParaAFIPPorFecha.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpImpresora.SuspendLayout()
        Me.stsEstado.SuspendLayout()
        CType(Me.ugExtracciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpAuditoriaPorFechaHasta
        '
        Me.dtpAuditoriaPorFechaHasta.BindearPropiedadControl = Nothing
        Me.dtpAuditoriaPorFechaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpAuditoriaPorFechaHasta.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpAuditoriaPorFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpAuditoriaPorFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpAuditoriaPorFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAuditoriaPorFechaHasta.IsPK = False
        Me.dtpAuditoriaPorFechaHasta.IsRequired = False
        Me.dtpAuditoriaPorFechaHasta.Key = ""
        Me.dtpAuditoriaPorFechaHasta.LabelAsoc = Me.lblAuditoriaPorFechaHasta
        Me.dtpAuditoriaPorFechaHasta.Location = New System.Drawing.Point(314, 19)
        Me.dtpAuditoriaPorFechaHasta.Name = "dtpAuditoriaPorFechaHasta"
        Me.dtpAuditoriaPorFechaHasta.Size = New System.Drawing.Size(140, 20)
        Me.dtpAuditoriaPorFechaHasta.TabIndex = 3
        '
        'lblAuditoriaPorFechaHasta
        '
        Me.lblAuditoriaPorFechaHasta.AutoSize = True
        Me.lblAuditoriaPorFechaHasta.LabelAsoc = Nothing
        Me.lblAuditoriaPorFechaHasta.Location = New System.Drawing.Point(277, 23)
        Me.lblAuditoriaPorFechaHasta.Name = "lblAuditoriaPorFechaHasta"
        Me.lblAuditoriaPorFechaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblAuditoriaPorFechaHasta.TabIndex = 2
        Me.lblAuditoriaPorFechaHasta.Text = "Hasta"
        '
        'dtpAuditoriaPorFechaDesde
        '
        Me.dtpAuditoriaPorFechaDesde.BindearPropiedadControl = Nothing
        Me.dtpAuditoriaPorFechaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpAuditoriaPorFechaDesde.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpAuditoriaPorFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpAuditoriaPorFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpAuditoriaPorFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAuditoriaPorFechaDesde.IsPK = False
        Me.dtpAuditoriaPorFechaDesde.IsRequired = False
        Me.dtpAuditoriaPorFechaDesde.Key = ""
        Me.dtpAuditoriaPorFechaDesde.LabelAsoc = Me.lblAuditoriaPorFechaDesde
        Me.dtpAuditoriaPorFechaDesde.Location = New System.Drawing.Point(131, 19)
        Me.dtpAuditoriaPorFechaDesde.Name = "dtpAuditoriaPorFechaDesde"
        Me.dtpAuditoriaPorFechaDesde.Size = New System.Drawing.Size(140, 20)
        Me.dtpAuditoriaPorFechaDesde.TabIndex = 1
        '
        'lblAuditoriaPorFechaDesde
        '
        Me.lblAuditoriaPorFechaDesde.AutoSize = True
        Me.lblAuditoriaPorFechaDesde.LabelAsoc = Nothing
        Me.lblAuditoriaPorFechaDesde.Location = New System.Drawing.Point(33, 23)
        Me.lblAuditoriaPorFechaDesde.Name = "lblAuditoriaPorFechaDesde"
        Me.lblAuditoriaPorFechaDesde.Size = New System.Drawing.Size(80, 13)
        Me.lblAuditoriaPorFechaDesde.TabIndex = 0
        Me.lblAuditoriaPorFechaDesde.Text = "Exportar Desde"
        '
        'txtAuditoriaPorNroZetaHasta
        '
        Me.txtAuditoriaPorNroZetaHasta.BindearPropiedadControl = Nothing
        Me.txtAuditoriaPorNroZetaHasta.BindearPropiedadEntidad = Nothing
        Me.txtAuditoriaPorNroZetaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAuditoriaPorNroZetaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAuditoriaPorNroZetaHasta.Formato = ""
        Me.txtAuditoriaPorNroZetaHasta.IsDecimal = False
        Me.txtAuditoriaPorNroZetaHasta.IsNumber = True
        Me.txtAuditoriaPorNroZetaHasta.IsPK = False
        Me.txtAuditoriaPorNroZetaHasta.IsRequired = False
        Me.txtAuditoriaPorNroZetaHasta.Key = ""
        Me.txtAuditoriaPorNroZetaHasta.LabelAsoc = Me.lblAuditoriaPorNroZetaHasta
        Me.txtAuditoriaPorNroZetaHasta.Location = New System.Drawing.Point(243, 19)
        Me.txtAuditoriaPorNroZetaHasta.MaxLength = 12
        Me.txtAuditoriaPorNroZetaHasta.Name = "txtAuditoriaPorNroZetaHasta"
        Me.txtAuditoriaPorNroZetaHasta.Size = New System.Drawing.Size(67, 20)
        Me.txtAuditoriaPorNroZetaHasta.TabIndex = 3
        Me.txtAuditoriaPorNroZetaHasta.Text = "0"
        Me.txtAuditoriaPorNroZetaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAuditoriaPorNroZetaHasta
        '
        Me.lblAuditoriaPorNroZetaHasta.AutoSize = True
        Me.lblAuditoriaPorNroZetaHasta.LabelAsoc = Nothing
        Me.lblAuditoriaPorNroZetaHasta.Location = New System.Drawing.Point(202, 23)
        Me.lblAuditoriaPorNroZetaHasta.Name = "lblAuditoriaPorNroZetaHasta"
        Me.lblAuditoriaPorNroZetaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblAuditoriaPorNroZetaHasta.TabIndex = 2
        Me.lblAuditoriaPorNroZetaHasta.Text = "Hasta"
        '
        'txtAuditoriaPorNroZetaDesde
        '
        Me.txtAuditoriaPorNroZetaDesde.BindearPropiedadControl = Nothing
        Me.txtAuditoriaPorNroZetaDesde.BindearPropiedadEntidad = Nothing
        Me.txtAuditoriaPorNroZetaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAuditoriaPorNroZetaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAuditoriaPorNroZetaDesde.Formato = ""
        Me.txtAuditoriaPorNroZetaDesde.IsDecimal = False
        Me.txtAuditoriaPorNroZetaDesde.IsNumber = True
        Me.txtAuditoriaPorNroZetaDesde.IsPK = False
        Me.txtAuditoriaPorNroZetaDesde.IsRequired = False
        Me.txtAuditoriaPorNroZetaDesde.Key = ""
        Me.txtAuditoriaPorNroZetaDesde.LabelAsoc = Me.lblAuditoriaPorNroZetaDesde
        Me.txtAuditoriaPorNroZetaDesde.Location = New System.Drawing.Point(131, 19)
        Me.txtAuditoriaPorNroZetaDesde.MaxLength = 12
        Me.txtAuditoriaPorNroZetaDesde.Name = "txtAuditoriaPorNroZetaDesde"
        Me.txtAuditoriaPorNroZetaDesde.Size = New System.Drawing.Size(67, 20)
        Me.txtAuditoriaPorNroZetaDesde.TabIndex = 1
        Me.txtAuditoriaPorNroZetaDesde.Text = "0"
        Me.txtAuditoriaPorNroZetaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAuditoriaPorNroZetaDesde
        '
        Me.lblAuditoriaPorNroZetaDesde.AutoSize = True
        Me.lblAuditoriaPorNroZetaDesde.LabelAsoc = Nothing
        Me.lblAuditoriaPorNroZetaDesde.Location = New System.Drawing.Point(33, 23)
        Me.lblAuditoriaPorNroZetaDesde.Name = "lblAuditoriaPorNroZetaDesde"
        Me.lblAuditoriaPorNroZetaDesde.Size = New System.Drawing.Size(63, 13)
        Me.lblAuditoriaPorNroZetaDesde.TabIndex = 0
        Me.lblAuditoriaPorNroZetaDesde.Text = "Zeta Desde"
        '
        'lblAuditoriaPorFechaNombreArchivo
        '
        Me.lblAuditoriaPorFechaNombreArchivo.AutoSize = True
        Me.lblAuditoriaPorFechaNombreArchivo.LabelAsoc = Nothing
        Me.lblAuditoriaPorFechaNombreArchivo.Location = New System.Drawing.Point(33, 48)
        Me.lblAuditoriaPorFechaNombreArchivo.Name = "lblAuditoriaPorFechaNombreArchivo"
        Me.lblAuditoriaPorFechaNombreArchivo.Size = New System.Drawing.Size(83, 13)
        Me.lblAuditoriaPorFechaNombreArchivo.TabIndex = 4
        Me.lblAuditoriaPorFechaNombreArchivo.Text = "Nombre Archivo"
        '
        'txtAuditoriaPorFechaNombreArchivo
        '
        Me.txtAuditoriaPorFechaNombreArchivo.BindearPropiedadControl = Nothing
        Me.txtAuditoriaPorFechaNombreArchivo.BindearPropiedadEntidad = Nothing
        Me.txtAuditoriaPorFechaNombreArchivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAuditoriaPorFechaNombreArchivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAuditoriaPorFechaNombreArchivo.Formato = ""
        Me.txtAuditoriaPorFechaNombreArchivo.IsDecimal = False
        Me.txtAuditoriaPorFechaNombreArchivo.IsNumber = False
        Me.txtAuditoriaPorFechaNombreArchivo.IsPK = False
        Me.txtAuditoriaPorFechaNombreArchivo.IsRequired = False
        Me.txtAuditoriaPorFechaNombreArchivo.Key = ""
        Me.txtAuditoriaPorFechaNombreArchivo.LabelAsoc = Me.lblAuditoriaPorFechaNombreArchivo
        Me.txtAuditoriaPorFechaNombreArchivo.Location = New System.Drawing.Point(131, 45)
        Me.txtAuditoriaPorFechaNombreArchivo.Name = "txtAuditoriaPorFechaNombreArchivo"
        Me.txtAuditoriaPorFechaNombreArchivo.Size = New System.Drawing.Size(290, 20)
        Me.txtAuditoriaPorFechaNombreArchivo.TabIndex = 5
        '
        'lblAuditoriaPorNroZetaNombreArchivo
        '
        Me.lblAuditoriaPorNroZetaNombreArchivo.AutoSize = True
        Me.lblAuditoriaPorNroZetaNombreArchivo.LabelAsoc = Nothing
        Me.lblAuditoriaPorNroZetaNombreArchivo.Location = New System.Drawing.Point(33, 48)
        Me.lblAuditoriaPorNroZetaNombreArchivo.Name = "lblAuditoriaPorNroZetaNombreArchivo"
        Me.lblAuditoriaPorNroZetaNombreArchivo.Size = New System.Drawing.Size(83, 13)
        Me.lblAuditoriaPorNroZetaNombreArchivo.TabIndex = 4
        Me.lblAuditoriaPorNroZetaNombreArchivo.Text = "Nombre Archivo"
        '
        'txtAuditoriaPorNroZetaNombreArchivo
        '
        Me.txtAuditoriaPorNroZetaNombreArchivo.BindearPropiedadControl = Nothing
        Me.txtAuditoriaPorNroZetaNombreArchivo.BindearPropiedadEntidad = Nothing
        Me.txtAuditoriaPorNroZetaNombreArchivo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAuditoriaPorNroZetaNombreArchivo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAuditoriaPorNroZetaNombreArchivo.Formato = ""
        Me.txtAuditoriaPorNroZetaNombreArchivo.IsDecimal = False
        Me.txtAuditoriaPorNroZetaNombreArchivo.IsNumber = False
        Me.txtAuditoriaPorNroZetaNombreArchivo.IsPK = False
        Me.txtAuditoriaPorNroZetaNombreArchivo.IsRequired = False
        Me.txtAuditoriaPorNroZetaNombreArchivo.Key = ""
        Me.txtAuditoriaPorNroZetaNombreArchivo.LabelAsoc = Me.lblAuditoriaPorNroZetaNombreArchivo
        Me.txtAuditoriaPorNroZetaNombreArchivo.Location = New System.Drawing.Point(131, 45)
        Me.txtAuditoriaPorNroZetaNombreArchivo.Name = "txtAuditoriaPorNroZetaNombreArchivo"
        Me.txtAuditoriaPorNroZetaNombreArchivo.Size = New System.Drawing.Size(290, 20)
        Me.txtAuditoriaPorNroZetaNombreArchivo.TabIndex = 5
        '
        'grpAuditoriaPorFecha
        '
        Me.grpAuditoriaPorFecha.Controls.Add(Me.btnAuditoriaPorFechaNombreArchivo)
        Me.grpAuditoriaPorFecha.Controls.Add(Me.btnExportarAuditoriaPorFecha)
        Me.grpAuditoriaPorFecha.Controls.Add(Me.dtpAuditoriaPorFechaDesde)
        Me.grpAuditoriaPorFecha.Controls.Add(Me.lblAuditoriaPorFechaDesde)
        Me.grpAuditoriaPorFecha.Controls.Add(Me.lblAuditoriaPorFechaHasta)
        Me.grpAuditoriaPorFecha.Controls.Add(Me.dtpAuditoriaPorFechaHasta)
        Me.grpAuditoriaPorFecha.Controls.Add(Me.txtAuditoriaPorFechaNombreArchivo)
        Me.grpAuditoriaPorFecha.Controls.Add(Me.lblAuditoriaPorFechaNombreArchivo)
        Me.grpAuditoriaPorFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpAuditoriaPorFecha.Location = New System.Drawing.Point(15, 87)
        Me.grpAuditoriaPorFecha.Name = "grpAuditoriaPorFecha"
        Me.grpAuditoriaPorFecha.Size = New System.Drawing.Size(620, 75)
        Me.grpAuditoriaPorFecha.TabIndex = 1
        Me.grpAuditoriaPorFecha.TabStop = False
        Me.grpAuditoriaPorFecha.Text = "Archivo de auditoría por fechas... (F2)"
        '
        'btnAuditoriaPorFechaNombreArchivo
        '
        Me.btnAuditoriaPorFechaNombreArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAuditoriaPorFechaNombreArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAuditoriaPorFechaNombreArchivo.Location = New System.Drawing.Point(426, 45)
        Me.btnAuditoriaPorFechaNombreArchivo.Name = "btnAuditoriaPorFechaNombreArchivo"
        Me.btnAuditoriaPorFechaNombreArchivo.Size = New System.Drawing.Size(28, 20)
        Me.btnAuditoriaPorFechaNombreArchivo.TabIndex = 6
        Me.btnAuditoriaPorFechaNombreArchivo.Text = "..."
        Me.btnAuditoriaPorFechaNombreArchivo.UseVisualStyleBackColor = True
        '
        'btnExportarAuditoriaPorFecha
        '
        Me.btnExportarAuditoriaPorFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportarAuditoriaPorFecha.Location = New System.Drawing.Point(464, 19)
        Me.btnExportarAuditoriaPorFecha.Name = "btnExportarAuditoriaPorFecha"
        Me.btnExportarAuditoriaPorFecha.Size = New System.Drawing.Size(139, 45)
        Me.btnExportarAuditoriaPorFecha.TabIndex = 7
        Me.btnExportarAuditoriaPorFecha.Text = "Exportar (F6)"
        Me.btnExportarAuditoriaPorFecha.UseVisualStyleBackColor = True
        '
        'grpAuditoriaPorNroZeta
        '
        Me.grpAuditoriaPorNroZeta.Controls.Add(Me.btnAuditoriaPorNroZetaNombreArchivo)
        Me.grpAuditoriaPorNroZeta.Controls.Add(Me.btnExportarAuditoriaPorNroZeta)
        Me.grpAuditoriaPorNroZeta.Controls.Add(Me.txtAuditoriaPorNroZetaDesde)
        Me.grpAuditoriaPorNroZeta.Controls.Add(Me.lblAuditoriaPorNroZetaDesde)
        Me.grpAuditoriaPorNroZeta.Controls.Add(Me.lblAuditoriaPorNroZetaHasta)
        Me.grpAuditoriaPorNroZeta.Controls.Add(Me.txtAuditoriaPorNroZetaHasta)
        Me.grpAuditoriaPorNroZeta.Controls.Add(Me.lblAuditoriaPorNroZetaNombreArchivo)
        Me.grpAuditoriaPorNroZeta.Controls.Add(Me.txtAuditoriaPorNroZetaNombreArchivo)
        Me.grpAuditoriaPorNroZeta.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpAuditoriaPorNroZeta.Location = New System.Drawing.Point(15, 162)
        Me.grpAuditoriaPorNroZeta.Name = "grpAuditoriaPorNroZeta"
        Me.grpAuditoriaPorNroZeta.Size = New System.Drawing.Size(620, 75)
        Me.grpAuditoriaPorNroZeta.TabIndex = 2
        Me.grpAuditoriaPorNroZeta.TabStop = False
        Me.grpAuditoriaPorNroZeta.Text = "Archivo de auditoría por número de zetas... (F3)"
        '
        'btnAuditoriaPorNroZetaNombreArchivo
        '
        Me.btnAuditoriaPorNroZetaNombreArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAuditoriaPorNroZetaNombreArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAuditoriaPorNroZetaNombreArchivo.Location = New System.Drawing.Point(426, 45)
        Me.btnAuditoriaPorNroZetaNombreArchivo.Name = "btnAuditoriaPorNroZetaNombreArchivo"
        Me.btnAuditoriaPorNroZetaNombreArchivo.Size = New System.Drawing.Size(28, 20)
        Me.btnAuditoriaPorNroZetaNombreArchivo.TabIndex = 6
        Me.btnAuditoriaPorNroZetaNombreArchivo.Text = "..."
        Me.btnAuditoriaPorNroZetaNombreArchivo.UseVisualStyleBackColor = True
        '
        'btnExportarAuditoriaPorNroZeta
        '
        Me.btnExportarAuditoriaPorNroZeta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportarAuditoriaPorNroZeta.Location = New System.Drawing.Point(464, 20)
        Me.btnExportarAuditoriaPorNroZeta.Name = "btnExportarAuditoriaPorNroZeta"
        Me.btnExportarAuditoriaPorNroZeta.Size = New System.Drawing.Size(139, 45)
        Me.btnExportarAuditoriaPorNroZeta.TabIndex = 7
        Me.btnExportarAuditoriaPorNroZeta.Text = "Exportar (F7)"
        Me.btnExportarAuditoriaPorNroZeta.UseVisualStyleBackColor = True
        '
        'grpExportarInformeParaAFIPPorFecha
        '
        Me.grpExportarInformeParaAFIPPorFecha.Controls.Add(Me.btnInformeParaAFIPPorFechaNombreDirectorio)
        Me.grpExportarInformeParaAFIPPorFecha.Controls.Add(Me.btnExportarInformeParaAFIPPorFecha)
        Me.grpExportarInformeParaAFIPPorFecha.Controls.Add(Me.dtpInformeParaAFIPPorFechaDesde)
        Me.grpExportarInformeParaAFIPPorFecha.Controls.Add(Me.lblInformeParaAFIPPorFechaDesde)
        Me.grpExportarInformeParaAFIPPorFecha.Controls.Add(Me.lblInformeParaAFIPPorFechaHasta)
        Me.grpExportarInformeParaAFIPPorFecha.Controls.Add(Me.dtpInformeParaAFIPPorFechaHasta)
        Me.grpExportarInformeParaAFIPPorFecha.Controls.Add(Me.txtInformeParaAFIPPorFechaNombreDirectorio)
        Me.grpExportarInformeParaAFIPPorFecha.Controls.Add(Me.lblInformeParaAFIPPorFechaNombreDirectorio)
        Me.grpExportarInformeParaAFIPPorFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpExportarInformeParaAFIPPorFecha.Location = New System.Drawing.Point(15, 237)
        Me.grpExportarInformeParaAFIPPorFecha.Name = "grpExportarInformeParaAFIPPorFecha"
        Me.grpExportarInformeParaAFIPPorFecha.Size = New System.Drawing.Size(620, 75)
        Me.grpExportarInformeParaAFIPPorFecha.TabIndex = 3
        Me.grpExportarInformeParaAFIPPorFecha.TabStop = False
        Me.grpExportarInformeParaAFIPPorFecha.Text = "Informe para AFIP por fechas... (F4)"
        '
        'btnInformeParaAFIPPorFechaNombreDirectorio
        '
        Me.btnInformeParaAFIPPorFechaNombreDirectorio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInformeParaAFIPPorFechaNombreDirectorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInformeParaAFIPPorFechaNombreDirectorio.Location = New System.Drawing.Point(426, 45)
        Me.btnInformeParaAFIPPorFechaNombreDirectorio.Name = "btnInformeParaAFIPPorFechaNombreDirectorio"
        Me.btnInformeParaAFIPPorFechaNombreDirectorio.Size = New System.Drawing.Size(28, 20)
        Me.btnInformeParaAFIPPorFechaNombreDirectorio.TabIndex = 6
        Me.btnInformeParaAFIPPorFechaNombreDirectorio.Text = "..."
        Me.btnInformeParaAFIPPorFechaNombreDirectorio.UseVisualStyleBackColor = True
        '
        'btnExportarInformeParaAFIPPorFecha
        '
        Me.btnExportarInformeParaAFIPPorFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportarInformeParaAFIPPorFecha.Location = New System.Drawing.Point(464, 19)
        Me.btnExportarInformeParaAFIPPorFecha.Name = "btnExportarInformeParaAFIPPorFecha"
        Me.btnExportarInformeParaAFIPPorFecha.Size = New System.Drawing.Size(139, 45)
        Me.btnExportarInformeParaAFIPPorFecha.TabIndex = 7
        Me.btnExportarInformeParaAFIPPorFecha.Text = "Exportar (F8)"
        Me.btnExportarInformeParaAFIPPorFecha.UseVisualStyleBackColor = True
        '
        'dtpInformeParaAFIPPorFechaDesde
        '
        Me.dtpInformeParaAFIPPorFechaDesde.BindearPropiedadControl = Nothing
        Me.dtpInformeParaAFIPPorFechaDesde.BindearPropiedadEntidad = Nothing
        Me.dtpInformeParaAFIPPorFechaDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpInformeParaAFIPPorFechaDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpInformeParaAFIPPorFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpInformeParaAFIPPorFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInformeParaAFIPPorFechaDesde.IsPK = False
        Me.dtpInformeParaAFIPPorFechaDesde.IsRequired = False
        Me.dtpInformeParaAFIPPorFechaDesde.Key = ""
        Me.dtpInformeParaAFIPPorFechaDesde.LabelAsoc = Me.lblInformeParaAFIPPorFechaDesde
        Me.dtpInformeParaAFIPPorFechaDesde.Location = New System.Drawing.Point(131, 19)
        Me.dtpInformeParaAFIPPorFechaDesde.Name = "dtpInformeParaAFIPPorFechaDesde"
        Me.dtpInformeParaAFIPPorFechaDesde.Size = New System.Drawing.Size(97, 20)
        Me.dtpInformeParaAFIPPorFechaDesde.TabIndex = 1
        '
        'lblInformeParaAFIPPorFechaDesde
        '
        Me.lblInformeParaAFIPPorFechaDesde.AutoSize = True
        Me.lblInformeParaAFIPPorFechaDesde.LabelAsoc = Nothing
        Me.lblInformeParaAFIPPorFechaDesde.Location = New System.Drawing.Point(33, 23)
        Me.lblInformeParaAFIPPorFechaDesde.Name = "lblInformeParaAFIPPorFechaDesde"
        Me.lblInformeParaAFIPPorFechaDesde.Size = New System.Drawing.Size(80, 13)
        Me.lblInformeParaAFIPPorFechaDesde.TabIndex = 0
        Me.lblInformeParaAFIPPorFechaDesde.Text = "Exportar Desde"
        '
        'lblInformeParaAFIPPorFechaHasta
        '
        Me.lblInformeParaAFIPPorFechaHasta.AutoSize = True
        Me.lblInformeParaAFIPPorFechaHasta.LabelAsoc = Nothing
        Me.lblInformeParaAFIPPorFechaHasta.Location = New System.Drawing.Point(277, 23)
        Me.lblInformeParaAFIPPorFechaHasta.Name = "lblInformeParaAFIPPorFechaHasta"
        Me.lblInformeParaAFIPPorFechaHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblInformeParaAFIPPorFechaHasta.TabIndex = 2
        Me.lblInformeParaAFIPPorFechaHasta.Text = "Hasta"
        '
        'dtpInformeParaAFIPPorFechaHasta
        '
        Me.dtpInformeParaAFIPPorFechaHasta.BindearPropiedadControl = Nothing
        Me.dtpInformeParaAFIPPorFechaHasta.BindearPropiedadEntidad = Nothing
        Me.dtpInformeParaAFIPPorFechaHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpInformeParaAFIPPorFechaHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpInformeParaAFIPPorFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpInformeParaAFIPPorFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInformeParaAFIPPorFechaHasta.IsPK = False
        Me.dtpInformeParaAFIPPorFechaHasta.IsRequired = False
        Me.dtpInformeParaAFIPPorFechaHasta.Key = ""
        Me.dtpInformeParaAFIPPorFechaHasta.LabelAsoc = Me.lblInformeParaAFIPPorFechaHasta
        Me.dtpInformeParaAFIPPorFechaHasta.Location = New System.Drawing.Point(314, 19)
        Me.dtpInformeParaAFIPPorFechaHasta.Name = "dtpInformeParaAFIPPorFechaHasta"
        Me.dtpInformeParaAFIPPorFechaHasta.Size = New System.Drawing.Size(97, 20)
        Me.dtpInformeParaAFIPPorFechaHasta.TabIndex = 3
        '
        'txtInformeParaAFIPPorFechaNombreDirectorio
        '
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.BindearPropiedadControl = Nothing
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.BindearPropiedadEntidad = Nothing
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.ForeColorFocus = System.Drawing.Color.Red
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.Formato = ""
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.IsDecimal = False
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.IsNumber = False
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.IsPK = False
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.IsRequired = False
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.Key = ""
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.LabelAsoc = Me.lblInformeParaAFIPPorFechaNombreDirectorio
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.Location = New System.Drawing.Point(131, 45)
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.Name = "txtInformeParaAFIPPorFechaNombreDirectorio"
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.Size = New System.Drawing.Size(290, 20)
        Me.txtInformeParaAFIPPorFechaNombreDirectorio.TabIndex = 5
        '
        'lblInformeParaAFIPPorFechaNombreDirectorio
        '
        Me.lblInformeParaAFIPPorFechaNombreDirectorio.AutoSize = True
        Me.lblInformeParaAFIPPorFechaNombreDirectorio.LabelAsoc = Nothing
        Me.lblInformeParaAFIPPorFechaNombreDirectorio.Location = New System.Drawing.Point(33, 48)
        Me.lblInformeParaAFIPPorFechaNombreDirectorio.Name = "lblInformeParaAFIPPorFechaNombreDirectorio"
        Me.lblInformeParaAFIPPorFechaNombreDirectorio.Size = New System.Drawing.Size(92, 13)
        Me.lblInformeParaAFIPPorFechaNombreDirectorio.TabIndex = 4
        Me.lblInformeParaAFIPPorFechaNombreDirectorio.Text = "Nombre Directorio"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 2
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grpExportarInformeParaAFIPPorFecha)
        Me.Panel1.Controls.Add(Me.grpAuditoriaPorNroZeta)
        Me.Panel1.Controls.Add(Me.grpAuditoriaPorFecha)
        Me.Panel1.Controls.Add(Me.grpImpresora)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(15)
        Me.Panel1.Size = New System.Drawing.Size(650, 330)
        Me.Panel1.TabIndex = 0
        '
        'grpImpresora
        '
        Me.grpImpresora.Controls.Add(Me.lblPuerto)
        Me.grpImpresora.Controls.Add(Me.txtPuerto)
        Me.grpImpresora.Controls.Add(Me.lblMetodo)
        Me.grpImpresora.Controls.Add(Me.Label1)
        Me.grpImpresora.Controls.Add(Me.txtMetodoImpresion)
        Me.grpImpresora.Controls.Add(Me.txtTipoImpresora)
        Me.grpImpresora.Controls.Add(Me.txtModelo)
        Me.grpImpresora.Controls.Add(Me.lblModelo)
        Me.grpImpresora.Controls.Add(Me.txtCentroEmisor)
        Me.grpImpresora.Controls.Add(Me.lblCentroEmisor)
        Me.grpImpresora.Controls.Add(Me.lblTipo)
        Me.grpImpresora.Controls.Add(Me.txtMarca)
        Me.grpImpresora.Controls.Add(Me.txtIdImpresora)
        Me.grpImpresora.Controls.Add(Me.lblId)
        Me.grpImpresora.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpImpresora.Location = New System.Drawing.Point(15, 15)
        Me.grpImpresora.Name = "grpImpresora"
        Me.grpImpresora.Size = New System.Drawing.Size(620, 72)
        Me.grpImpresora.TabIndex = 0
        Me.grpImpresora.TabStop = False
        Me.grpImpresora.Text = "Impresora"
        '
        'lblPuerto
        '
        Me.lblPuerto.AutoSize = True
        Me.lblPuerto.LabelAsoc = Nothing
        Me.lblPuerto.Location = New System.Drawing.Point(332, 46)
        Me.lblPuerto.Name = "lblPuerto"
        Me.lblPuerto.Size = New System.Drawing.Size(38, 13)
        Me.lblPuerto.TabIndex = 10
        Me.lblPuerto.Text = "Puerto"
        '
        'txtPuerto
        '
        Me.txtPuerto.BindearPropiedadControl = ""
        Me.txtPuerto.BindearPropiedadEntidad = ""
        Me.txtPuerto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPuerto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPuerto.Formato = ""
        Me.txtPuerto.IsDecimal = False
        Me.txtPuerto.IsNumber = False
        Me.txtPuerto.IsPK = False
        Me.txtPuerto.IsRequired = False
        Me.txtPuerto.Key = ""
        Me.txtPuerto.LabelAsoc = Me.lblPuerto
        Me.txtPuerto.Location = New System.Drawing.Point(376, 42)
        Me.txtPuerto.MaxLength = 5
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.ReadOnly = True
        Me.txtPuerto.Size = New System.Drawing.Size(44, 20)
        Me.txtPuerto.TabIndex = 11
        '
        'lblMetodo
        '
        Me.lblMetodo.AutoSize = True
        Me.lblMetodo.LabelAsoc = Nothing
        Me.lblMetodo.Location = New System.Drawing.Point(426, 46)
        Me.lblMetodo.Name = "lblMetodo"
        Me.lblMetodo.Size = New System.Drawing.Size(91, 13)
        Me.lblMetodo.TabIndex = 12
        Me.lblMetodo.Text = "Método Impresión"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(6, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Marca"
        '
        'txtMetodoImpresion
        '
        Me.txtMetodoImpresion.BindearPropiedadControl = ""
        Me.txtMetodoImpresion.BindearPropiedadEntidad = ""
        Me.txtMetodoImpresion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMetodoImpresion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMetodoImpresion.Formato = ""
        Me.txtMetodoImpresion.IsDecimal = False
        Me.txtMetodoImpresion.IsNumber = False
        Me.txtMetodoImpresion.IsPK = False
        Me.txtMetodoImpresion.IsRequired = False
        Me.txtMetodoImpresion.Key = ""
        Me.txtMetodoImpresion.LabelAsoc = Nothing
        Me.txtMetodoImpresion.Location = New System.Drawing.Point(522, 42)
        Me.txtMetodoImpresion.MaxLength = 15
        Me.txtMetodoImpresion.Name = "txtMetodoImpresion"
        Me.txtMetodoImpresion.ReadOnly = True
        Me.txtMetodoImpresion.Size = New System.Drawing.Size(84, 20)
        Me.txtMetodoImpresion.TabIndex = 13
        '
        'txtTipoImpresora
        '
        Me.txtTipoImpresora.BindearPropiedadControl = ""
        Me.txtTipoImpresora.BindearPropiedadEntidad = ""
        Me.txtTipoImpresora.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoImpresora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoImpresora.Formato = ""
        Me.txtTipoImpresora.IsDecimal = False
        Me.txtTipoImpresora.IsNumber = False
        Me.txtTipoImpresora.IsPK = False
        Me.txtTipoImpresora.IsRequired = False
        Me.txtTipoImpresora.Key = ""
        Me.txtTipoImpresora.LabelAsoc = Nothing
        Me.txtTipoImpresora.Location = New System.Drawing.Point(226, 16)
        Me.txtTipoImpresora.MaxLength = 15
        Me.txtTipoImpresora.Name = "txtTipoImpresora"
        Me.txtTipoImpresora.ReadOnly = True
        Me.txtTipoImpresora.Size = New System.Drawing.Size(100, 20)
        Me.txtTipoImpresora.TabIndex = 3
        '
        'txtModelo
        '
        Me.txtModelo.BindearPropiedadControl = ""
        Me.txtModelo.BindearPropiedadEntidad = ""
        Me.txtModelo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtModelo.Formato = ""
        Me.txtModelo.IsDecimal = False
        Me.txtModelo.IsNumber = False
        Me.txtModelo.IsPK = False
        Me.txtModelo.IsRequired = False
        Me.txtModelo.Key = ""
        Me.txtModelo.LabelAsoc = Me.lblModelo
        Me.txtModelo.Location = New System.Drawing.Point(226, 42)
        Me.txtModelo.MaxLength = 15
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(100, 20)
        Me.txtModelo.TabIndex = 9
        '
        'lblModelo
        '
        Me.lblModelo.AutoSize = True
        Me.lblModelo.LabelAsoc = Nothing
        Me.lblModelo.Location = New System.Drawing.Point(182, 46)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(42, 13)
        Me.lblModelo.TabIndex = 8
        Me.lblModelo.Text = "Modelo"
        '
        'txtCentroEmisor
        '
        Me.txtCentroEmisor.BindearPropiedadControl = ""
        Me.txtCentroEmisor.BindearPropiedadEntidad = ""
        Me.txtCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCentroEmisor.Formato = ""
        Me.txtCentroEmisor.IsDecimal = False
        Me.txtCentroEmisor.IsNumber = True
        Me.txtCentroEmisor.IsPK = False
        Me.txtCentroEmisor.IsRequired = True
        Me.txtCentroEmisor.Key = ""
        Me.txtCentroEmisor.LabelAsoc = Me.lblCentroEmisor
        Me.txtCentroEmisor.Location = New System.Drawing.Point(376, 16)
        Me.txtCentroEmisor.MaxLength = 4
        Me.txtCentroEmisor.Name = "txtCentroEmisor"
        Me.txtCentroEmisor.ReadOnly = True
        Me.txtCentroEmisor.Size = New System.Drawing.Size(44, 20)
        Me.txtCentroEmisor.TabIndex = 5
        Me.txtCentroEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCentroEmisor
        '
        Me.lblCentroEmisor.AutoSize = True
        Me.lblCentroEmisor.LabelAsoc = Nothing
        Me.lblCentroEmisor.Location = New System.Drawing.Point(332, 20)
        Me.lblCentroEmisor.Name = "lblCentroEmisor"
        Me.lblCentroEmisor.Size = New System.Drawing.Size(38, 13)
        Me.lblCentroEmisor.TabIndex = 4
        Me.lblCentroEmisor.Text = "Emisor"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(182, 20)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 2
        Me.lblTipo.Text = "Tipo"
        '
        'txtMarca
        '
        Me.txtMarca.BindearPropiedadControl = ""
        Me.txtMarca.BindearPropiedadEntidad = ""
        Me.txtMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMarca.Formato = ""
        Me.txtMarca.IsDecimal = False
        Me.txtMarca.IsNumber = False
        Me.txtMarca.IsPK = True
        Me.txtMarca.IsRequired = True
        Me.txtMarca.Key = ""
        Me.txtMarca.LabelAsoc = Nothing
        Me.txtMarca.Location = New System.Drawing.Point(52, 42)
        Me.txtMarca.MaxLength = 15
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(124, 20)
        Me.txtMarca.TabIndex = 7
        '
        'txtIdImpresora
        '
        Me.txtIdImpresora.BindearPropiedadControl = ""
        Me.txtIdImpresora.BindearPropiedadEntidad = ""
        Me.txtIdImpresora.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdImpresora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdImpresora.Formato = ""
        Me.txtIdImpresora.IsDecimal = False
        Me.txtIdImpresora.IsNumber = False
        Me.txtIdImpresora.IsPK = True
        Me.txtIdImpresora.IsRequired = True
        Me.txtIdImpresora.Key = ""
        Me.txtIdImpresora.LabelAsoc = Me.lblId
        Me.txtIdImpresora.Location = New System.Drawing.Point(52, 16)
        Me.txtIdImpresora.MaxLength = 15
        Me.txtIdImpresora.Name = "txtIdImpresora"
        Me.txtIdImpresora.ReadOnly = True
        Me.txtIdImpresora.Size = New System.Drawing.Size(124, 20)
        Me.txtIdImpresora.TabIndex = 1
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(6, 20)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Código"
        '
        'stsEstado
        '
        Me.stsEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssError, Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsEstado.Location = New System.Drawing.Point(0, 359)
        Me.stsEstado.Name = "stsEstado"
        Me.stsEstado.Size = New System.Drawing.Size(984, 22)
        Me.stsEstado.TabIndex = 1
        Me.stsEstado.Text = "statusStrip1"
        '
        'tssError
        '
        Me.tssError.BackColor = System.Drawing.Color.Red
        Me.tssError.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.tssError.ForeColor = System.Drawing.Color.White
        Me.tssError.Name = "tssError"
        Me.tssError.Size = New System.Drawing.Size(401, 17)
        Me.tssError.Spring = True
        Me.tssError.Visible = False
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(969, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        Me.tssRegistros.Visible = False
        '
        'sfdAuditoriaPorFechaNombreArchivo
        '
        Me.sfdAuditoriaPorFechaNombreArchivo.Filter = "Archivos de Xml (*.xml)|*.xml|Todos los Archivos (*.*)|*.*"
        Me.sfdAuditoriaPorFechaNombreArchivo.Title = "Nombre de archivo a exportar..."
        '
        'sfdAuditoriaPorNroZetaNombreArchivo
        '
        Me.sfdAuditoriaPorNroZetaNombreArchivo.Filter = "Archivos de Xml (*.xml)|*.xml|Todos los Archivos (*.*)|*.*"
        Me.sfdAuditoriaPorNroZetaNombreArchivo.Title = "Nombre de archivo a exportar..."
        '
        'fbdInformeParaAFIPPorFechaNombreDirectorio
        '
        Me.fbdInformeParaAFIPPorFechaNombreDirectorio.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'ugExtracciones
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugExtracciones.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance2
        UltraGridColumn4.Header.Caption = "Z Desde"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 60
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance3
        UltraGridColumn5.Header.Caption = "Z Hasta"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 60
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance4
        UltraGridColumn6.Format = "dd/MM/yyyy"
        UltraGridColumn6.Header.Caption = "Fecha Desde"
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Width = 80
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn7.CellAppearance = Appearance5
        UltraGridColumn7.Format = "dd/MM/yyyy"
        UltraGridColumn7.Header.Caption = "Fecha Hasta"
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Width = 80
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance6
        UltraGridColumn8.Format = "dd/MM/yyyy"
        UltraGridColumn8.Header.Caption = "Fecha Extracción"
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Width = 80
        UltraGridColumn9.Header.Caption = "Usuario Extracción"
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn10.Header.Caption = "Nombre Archivo"
        UltraGridColumn10.Header.VisiblePosition = 9
        UltraGridColumn10.Width = 300
        UltraGridColumn11.Header.Caption = "MD5"
        UltraGridColumn11.Header.VisiblePosition = 10
        UltraGridColumn11.Width = 200
        UltraGridColumn12.Header.VisiblePosition = 11
        UltraGridColumn12.Hidden = True
        UltraGridColumn13.Header.VisiblePosition = 12
        UltraGridColumn13.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13})
        Me.ugExtracciones.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugExtracciones.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugExtracciones.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance7.BorderColor = System.Drawing.SystemColors.Window
        Me.ugExtracciones.DisplayLayout.GroupByBox.Appearance = Appearance7
        Appearance8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugExtracciones.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance8
        Me.ugExtracciones.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance9.BackColor2 = System.Drawing.SystemColors.Control
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugExtracciones.DisplayLayout.GroupByBox.PromptAppearance = Appearance9
        Me.ugExtracciones.DisplayLayout.MaxColScrollRegions = 1
        Me.ugExtracciones.DisplayLayout.MaxRowScrollRegions = 1
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Appearance10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugExtracciones.DisplayLayout.Override.ActiveCellAppearance = Appearance10
        Appearance11.BackColor = System.Drawing.SystemColors.Highlight
        Appearance11.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugExtracciones.DisplayLayout.Override.ActiveRowAppearance = Appearance11
        Me.ugExtracciones.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugExtracciones.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugExtracciones.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugExtracciones.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugExtracciones.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Me.ugExtracciones.DisplayLayout.Override.CardAreaAppearance = Appearance12
        Appearance13.BorderColor = System.Drawing.Color.Silver
        Appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugExtracciones.DisplayLayout.Override.CellAppearance = Appearance13
        Me.ugExtracciones.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugExtracciones.DisplayLayout.Override.CellPadding = 0
        Appearance14.BackColor = System.Drawing.SystemColors.Control
        Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance14.BorderColor = System.Drawing.SystemColors.Window
        Me.ugExtracciones.DisplayLayout.Override.GroupByRowAppearance = Appearance14
        Appearance15.TextHAlignAsString = "Left"
        Me.ugExtracciones.DisplayLayout.Override.HeaderAppearance = Appearance15
        Me.ugExtracciones.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugExtracciones.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Me.ugExtracciones.DisplayLayout.Override.RowAppearance = Appearance16
        Me.ugExtracciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugExtracciones.DisplayLayout.Override.TemplateAddRowAppearance = Appearance17
        Me.ugExtracciones.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugExtracciones.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugExtracciones.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugExtracciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugExtracciones.Location = New System.Drawing.Point(650, 29)
        Me.ugExtracciones.Name = "ugExtracciones"
        Me.ugExtracciones.Size = New System.Drawing.Size(334, 330)
        Me.ugExtracciones.TabIndex = 3
        Me.ugExtracciones.Text = "UltraGrid1"
        '
        'ReporteFiscalElectronico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 381)
        Me.Controls.Add(Me.ugExtracciones)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.stsEstado)
        Me.Controls.Add(Me.tstBarra)
        Me.MinimumSize = New System.Drawing.Size(670, 420)
        Me.Name = "ReporteFiscalElectronico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Fiscal Electrónico (Cierre Z)"
        Me.grpAuditoriaPorFecha.ResumeLayout(False)
        Me.grpAuditoriaPorFecha.PerformLayout()
        Me.grpAuditoriaPorNroZeta.ResumeLayout(False)
        Me.grpAuditoriaPorNroZeta.PerformLayout()
        Me.grpExportarInformeParaAFIPPorFecha.ResumeLayout(False)
        Me.grpExportarInformeParaAFIPPorFecha.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.grpImpresora.ResumeLayout(False)
        Me.grpImpresora.PerformLayout()
        Me.stsEstado.ResumeLayout(False)
        Me.stsEstado.PerformLayout()
        CType(Me.ugExtracciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpAuditoriaPorFechaHasta As Controles.DateTimePicker
   Friend WithEvents lblAuditoriaPorFechaHasta As Controles.Label
   Friend WithEvents dtpAuditoriaPorFechaDesde As Controles.DateTimePicker
   Friend WithEvents lblAuditoriaPorFechaDesde As Controles.Label
   Friend WithEvents txtAuditoriaPorNroZetaHasta As Controles.TextBox
   Friend WithEvents lblAuditoriaPorNroZetaHasta As Controles.Label
   Friend WithEvents txtAuditoriaPorNroZetaDesde As Controles.TextBox
   Friend WithEvents lblAuditoriaPorNroZetaDesde As Controles.Label
   Friend WithEvents lblAuditoriaPorFechaNombreArchivo As Controles.Label
   Friend WithEvents txtAuditoriaPorFechaNombreArchivo As Controles.TextBox
   Friend WithEvents lblAuditoriaPorNroZetaNombreArchivo As Controles.Label
   Friend WithEvents txtAuditoriaPorNroZetaNombreArchivo As Controles.TextBox
   Friend WithEvents grpAuditoriaPorFecha As GroupBox
   Friend WithEvents btnExportarAuditoriaPorFecha As Button
   Friend WithEvents grpAuditoriaPorNroZeta As GroupBox
   Friend WithEvents btnExportarAuditoriaPorNroZeta As Button
   Friend WithEvents grpExportarInformeParaAFIPPorFecha As GroupBox
   Friend WithEvents btnExportarInformeParaAFIPPorFecha As Button
   Friend WithEvents dtpInformeParaAFIPPorFechaDesde As Controles.DateTimePicker
   Friend WithEvents lblInformeParaAFIPPorFechaDesde As Controles.Label
   Friend WithEvents lblInformeParaAFIPPorFechaHasta As Controles.Label
   Friend WithEvents dtpInformeParaAFIPPorFechaHasta As Controles.DateTimePicker
   Friend WithEvents txtInformeParaAFIPPorFechaNombreDirectorio As Controles.TextBox
   Friend WithEvents lblInformeParaAFIPPorFechaNombreDirectorio As Controles.Label
   Friend WithEvents btnAuditoriaPorFechaNombreArchivo As Controles.Button
   Friend WithEvents btnAuditoriaPorNroZetaNombreArchivo As Controles.Button
   Friend WithEvents btnInformeParaAFIPPorFechaNombreDirectorio As Controles.Button
   Public WithEvents tstBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
   Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
   Public WithEvents tsbSalir As ToolStripButton
   Friend WithEvents Panel1 As Panel
   Protected Friend WithEvents stsEstado As StatusStrip
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As ToolStripProgressBar
   Protected WithEvents tssRegistros As ToolStripStatusLabel
   Friend WithEvents sfdAuditoriaPorFechaNombreArchivo As SaveFileDialog
   Friend WithEvents sfdAuditoriaPorNroZetaNombreArchivo As SaveFileDialog
   Friend WithEvents fbdInformeParaAFIPPorFechaNombreDirectorio As FolderBrowserDialog
   Friend WithEvents grpImpresora As GroupBox
   Friend WithEvents txtCentroEmisor As Controles.TextBox
   Friend WithEvents lblCentroEmisor As Controles.Label
   Friend WithEvents lblTipo As Controles.Label
   Friend WithEvents txtIdImpresora As Controles.TextBox
   Friend WithEvents lblId As Controles.Label
   Friend WithEvents lblMetodo As Controles.Label
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents txtModelo As Controles.TextBox
   Friend WithEvents lblModelo As Controles.Label
   Friend WithEvents lblPuerto As Controles.Label
   Friend WithEvents txtPuerto As Controles.TextBox
   Friend WithEvents txtMetodoImpresion As Controles.TextBox
   Friend WithEvents txtTipoImpresora As Controles.TextBox
   Friend WithEvents txtMarca As Controles.TextBox
    Protected Friend WithEvents tssError As ToolStripStatusLabel
    Friend WithEvents ugExtracciones As UltraGrid
End Class
