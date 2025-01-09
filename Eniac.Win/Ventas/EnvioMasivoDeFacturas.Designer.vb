<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioMasivoDeFacturas
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
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

   'Requerido por el Diseñador de Windows Forms
   Private components As System.ComponentModel.IContainer

   'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
   'Se puede modificar usando el Diseñador de Windows Forms.  
   'No lo modifique con el editor de código.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvioMasivoDeFacturas))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Estado")
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CorreoElectronico")
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoria")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoriaFiscal")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdZonaGeografica")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Envio")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
      Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCobrador")
      Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreEstadoCliente")
      Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dias")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioCorreo")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SiMovilIdUsuario")
      Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SiMovilClave")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdClienteVinculado", 0)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoClienteVinculado", 1)
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreClienteVinculado", 2)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CorreoClienteVinculado", 3)
        Dim SummarySettings1 As Infragistics.Win.UltraWinGrid.SummarySettings = New Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Nothing, "ImporteTotal", 18, True, "Band 0", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, Nothing, -1, False)
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.rtbCuerpoMail = New MSDN.Html.Editor.HtmlEditorControl()
        Me.cmbReportesCtaCte = New Eniac.Controles.ComboBox()
        Me.chbEnvioCtaCteCliente = New Eniac.Controles.CheckBox()
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.txtCopiaOculta = New Eniac.Controles.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExaminar4 = New Eniac.Controles.Button()
        Me.txtArchivo4 = New Eniac.Controles.TextBox()
        Me.lblArchivo4 = New Eniac.Controles.Label()
        Me.btnExaminar3 = New Eniac.Controles.Button()
        Me.txtArchivo3 = New Eniac.Controles.TextBox()
        Me.lblArchivo3 = New Eniac.Controles.Label()
        Me.btnExaminar2 = New Eniac.Controles.Button()
        Me.txtArchivo2 = New Eniac.Controles.TextBox()
        Me.lblArchivo2 = New Eniac.Controles.Label()
        Me.btnExpandirHtml = New Eniac.Controles.Button()
        Me.btnExaminar1 = New Eniac.Controles.Button()
        Me.txtArchivo1 = New Eniac.Controles.TextBox()
        Me.lblArchivo1 = New Eniac.Controles.Label()
        Me.txtAsuntoMail = New System.Windows.Forms.TextBox()
        Me.lblCuerpo = New Eniac.Controles.Label()
        Me.lblAsunto = New Eniac.Controles.Label()
        Me.sspPie = New System.Windows.Forms.StatusStrip()
        Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbTipoCliente = New Eniac.Controles.ComboBox()
        Me.lblCliente = New Eniac.Controles.Label()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.chbSaldo = New System.Windows.Forms.CheckBox()
        Me.cmbOperadorLogico = New Eniac.Controles.ComboBox()
        Me.txtSaldo = New Eniac.Controles.TextBox()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.chbTipoComprobante = New Eniac.Controles.Label()
        Me.cmbCorreoEnviado = New Eniac.Controles.ComboBox()
        Me.lblCorreoEnviado = New Eniac.Controles.Label()
        Me.chbCobrador = New Eniac.Controles.CheckBox()
        Me.cmbCobrador = New Eniac.Controles.ComboBox()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.lblComenzarPorNombreCliente = New Eniac.Controles.Label()
        Me.txtComenzarPorNombreCliente = New Eniac.Controles.TextBox()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.chbCategoriaCliente = New Eniac.Controles.CheckBox()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.cmbCategoriasClientes = New Eniac.Controles.ComboBox()
        Me.bscNombreCliente = New Eniac.Controles.Buscador()
        Me.lblNombreCliente = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbEnviarFacturas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbCorreoPrueba = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.chbCopiaOculta = New Eniac.Controles.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.sspPie.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'DialogoAbrirArchivo
        '
        Me.DialogoAbrirArchivo.FileName = "OpenFileDialog1"
        Me.DialogoAbrirArchivo.Filter = "Adobe Reader (*.pdf)|*.pdf|Todos los Archivos (*.*)|*.*"
        Me.DialogoAbrirArchivo.RestoreDirectory = True
        '
        'rtbCuerpoMail
        '
        Me.rtbCuerpoMail.InnerText = Nothing
        Me.rtbCuerpoMail.Location = New System.Drawing.Point(63, 45)
        Me.rtbCuerpoMail.Name = "rtbCuerpoMail"
        Me.rtbCuerpoMail.Size = New System.Drawing.Size(407, 81)
        Me.rtbCuerpoMail.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.rtbCuerpoMail, "{0} - va a ser reemplazado por la columna """"Cliente""""")
        '
        'cmbReportesCtaCte
        '
        Me.cmbReportesCtaCte.BindearPropiedadControl = ""
        Me.cmbReportesCtaCte.BindearPropiedadEntidad = ""
        Me.cmbReportesCtaCte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportesCtaCte.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbReportesCtaCte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbReportesCtaCte.FormattingEnabled = True
        Me.cmbReportesCtaCte.IsPK = False
        Me.cmbReportesCtaCte.IsRequired = True
        Me.cmbReportesCtaCte.Key = Nothing
        Me.cmbReportesCtaCte.LabelAsoc = Me.chbEnvioCtaCteCliente
        Me.cmbReportesCtaCte.Location = New System.Drawing.Point(478, 183)
        Me.cmbReportesCtaCte.Name = "cmbReportesCtaCte"
        Me.cmbReportesCtaCte.Size = New System.Drawing.Size(243, 21)
        Me.cmbReportesCtaCte.TabIndex = 26
        '
        'chbEnvioCtaCteCliente
        '
        Me.chbEnvioCtaCteCliente.AutoSize = True
        Me.chbEnvioCtaCteCliente.BindearPropiedadControl = Nothing
        Me.chbEnvioCtaCteCliente.BindearPropiedadEntidad = Nothing
        Me.chbEnvioCtaCteCliente.Checked = True
        Me.chbEnvioCtaCteCliente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEnvioCtaCteCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEnvioCtaCteCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEnvioCtaCteCliente.IsPK = False
        Me.chbEnvioCtaCteCliente.IsRequired = False
        Me.chbEnvioCtaCteCliente.Key = Nothing
        Me.chbEnvioCtaCteCliente.LabelAsoc = Nothing
        Me.chbEnvioCtaCteCliente.Location = New System.Drawing.Point(210, 185)
        Me.chbEnvioCtaCteCliente.Name = "chbEnvioCtaCteCliente"
        Me.chbEnvioCtaCteCliente.Size = New System.Drawing.Size(262, 17)
        Me.chbEnvioCtaCteCliente.TabIndex = 25
        Me.chbEnvioCtaCteCliente.Text = "Adjuntar Cta. Cte. (Si adeuda otros comprobantes)"
        Me.chbEnvioCtaCteCliente.UseVisualStyleBackColor = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(129, 182)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 2
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'cmbTodos
        '
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(13, 183)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(110, 21)
        Me.cmbTodos.TabIndex = 1
        '
        'txtCopiaOculta
        '
        Me.txtCopiaOculta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCopiaOculta.BindearPropiedadControl = ""
        Me.txtCopiaOculta.BindearPropiedadEntidad = ""
        Me.txtCopiaOculta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCopiaOculta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCopiaOculta.Formato = "N2"
        Me.txtCopiaOculta.IsDecimal = False
        Me.txtCopiaOculta.IsNumber = False
        Me.txtCopiaOculta.IsPK = False
        Me.txtCopiaOculta.IsRequired = False
        Me.txtCopiaOculta.Key = ""
        Me.txtCopiaOculta.LabelAsoc = Nothing
        Me.txtCopiaOculta.Location = New System.Drawing.Point(820, 183)
        Me.txtCopiaOculta.MaxLength = 60
        Me.txtCopiaOculta.Name = "txtCopiaOculta"
        Me.txtCopiaOculta.Size = New System.Drawing.Size(149, 20)
        Me.txtCopiaOculta.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnExaminar4)
        Me.GroupBox1.Controls.Add(Me.txtArchivo4)
        Me.GroupBox1.Controls.Add(Me.lblArchivo4)
        Me.GroupBox1.Controls.Add(Me.btnExaminar3)
        Me.GroupBox1.Controls.Add(Me.txtArchivo3)
        Me.GroupBox1.Controls.Add(Me.lblArchivo3)
        Me.GroupBox1.Controls.Add(Me.btnExaminar2)
        Me.GroupBox1.Controls.Add(Me.txtArchivo2)
        Me.GroupBox1.Controls.Add(Me.lblArchivo2)
        Me.GroupBox1.Controls.Add(Me.btnExpandirHtml)
        Me.GroupBox1.Controls.Add(Me.btnExaminar1)
        Me.GroupBox1.Controls.Add(Me.txtArchivo1)
        Me.GroupBox1.Controls.Add(Me.lblArchivo1)
        Me.GroupBox1.Controls.Add(Me.txtAsuntoMail)
        Me.GroupBox1.Controls.Add(Me.lblCuerpo)
        Me.GroupBox1.Controls.Add(Me.lblAsunto)
        Me.GroupBox1.Controls.Add(Me.rtbCuerpoMail)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 402)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(955, 133)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Envío"
        '
        'btnExaminar4
        '
        Me.btnExaminar4.Image = CType(resources.GetObject("btnExaminar4.Image"), System.Drawing.Image)
        Me.btnExaminar4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar4.Location = New System.Drawing.Point(878, 98)
        Me.btnExaminar4.Name = "btnExaminar4"
        Me.btnExaminar4.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar4.TabIndex = 15
        Me.btnExaminar4.Text = "Exam..."
        Me.btnExaminar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar4.UseVisualStyleBackColor = True
        '
        'txtArchivo4
        '
        Me.txtArchivo4.BindearPropiedadControl = "Text"
        Me.txtArchivo4.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo4.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo4.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo4.Formato = ""
        Me.txtArchivo4.IsDecimal = False
        Me.txtArchivo4.IsNumber = False
        Me.txtArchivo4.IsPK = False
        Me.txtArchivo4.IsRequired = False
        Me.txtArchivo4.Key = ""
        Me.txtArchivo4.LabelAsoc = Me.lblArchivo4
        Me.txtArchivo4.Location = New System.Drawing.Point(539, 98)
        Me.txtArchivo4.Name = "txtArchivo4"
        Me.txtArchivo4.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo4.TabIndex = 14
        '
        'lblArchivo4
        '
        Me.lblArchivo4.AutoSize = True
        Me.lblArchivo4.LabelAsoc = Nothing
        Me.lblArchivo4.Location = New System.Drawing.Point(485, 102)
        Me.lblArchivo4.Name = "lblArchivo4"
        Me.lblArchivo4.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo4.TabIndex = 13
        Me.lblArchivo4.Text = "Archivo 4"
        '
        'btnExaminar3
        '
        Me.btnExaminar3.Image = CType(resources.GetObject("btnExaminar3.Image"), System.Drawing.Image)
        Me.btnExaminar3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar3.Location = New System.Drawing.Point(878, 70)
        Me.btnExaminar3.Name = "btnExaminar3"
        Me.btnExaminar3.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar3.TabIndex = 12
        Me.btnExaminar3.Text = "Exam..."
        Me.btnExaminar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar3.UseVisualStyleBackColor = True
        '
        'txtArchivo3
        '
        Me.txtArchivo3.BindearPropiedadControl = "Text"
        Me.txtArchivo3.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo3.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo3.Formato = ""
        Me.txtArchivo3.IsDecimal = False
        Me.txtArchivo3.IsNumber = False
        Me.txtArchivo3.IsPK = False
        Me.txtArchivo3.IsRequired = False
        Me.txtArchivo3.Key = ""
        Me.txtArchivo3.LabelAsoc = Me.lblArchivo3
        Me.txtArchivo3.Location = New System.Drawing.Point(539, 70)
        Me.txtArchivo3.Name = "txtArchivo3"
        Me.txtArchivo3.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo3.TabIndex = 11
        '
        'lblArchivo3
        '
        Me.lblArchivo3.AutoSize = True
        Me.lblArchivo3.LabelAsoc = Nothing
        Me.lblArchivo3.Location = New System.Drawing.Point(485, 74)
        Me.lblArchivo3.Name = "lblArchivo3"
        Me.lblArchivo3.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo3.TabIndex = 10
        Me.lblArchivo3.Text = "Archivo 3"
        '
        'btnExaminar2
        '
        Me.btnExaminar2.Image = CType(resources.GetObject("btnExaminar2.Image"), System.Drawing.Image)
        Me.btnExaminar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar2.Location = New System.Drawing.Point(878, 45)
        Me.btnExaminar2.Name = "btnExaminar2"
        Me.btnExaminar2.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar2.TabIndex = 9
        Me.btnExaminar2.Text = "Exam..."
        Me.btnExaminar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar2.UseVisualStyleBackColor = True
        '
        'txtArchivo2
        '
        Me.txtArchivo2.BindearPropiedadControl = "Text"
        Me.txtArchivo2.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo2.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo2.Formato = ""
        Me.txtArchivo2.IsDecimal = False
        Me.txtArchivo2.IsNumber = False
        Me.txtArchivo2.IsPK = False
        Me.txtArchivo2.IsRequired = False
        Me.txtArchivo2.Key = ""
        Me.txtArchivo2.LabelAsoc = Me.lblArchivo2
        Me.txtArchivo2.Location = New System.Drawing.Point(539, 45)
        Me.txtArchivo2.Name = "txtArchivo2"
        Me.txtArchivo2.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo2.TabIndex = 8
        '
        'lblArchivo2
        '
        Me.lblArchivo2.AutoSize = True
        Me.lblArchivo2.LabelAsoc = Nothing
        Me.lblArchivo2.Location = New System.Drawing.Point(485, 49)
        Me.lblArchivo2.Name = "lblArchivo2"
        Me.lblArchivo2.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo2.TabIndex = 7
        Me.lblArchivo2.Text = "Archivo 2"
        '
        'btnExpandirHtml
        '
        Me.btnExpandirHtml.Image = Global.Eniac.Win.My.Resources.Resources.document_edit
        Me.btnExpandirHtml.Location = New System.Drawing.Point(17, 86)
        Me.btnExpandirHtml.Name = "btnExpandirHtml"
        Me.btnExpandirHtml.Size = New System.Drawing.Size(40, 40)
        Me.btnExpandirHtml.TabIndex = 6
        Me.btnExpandirHtml.Text = "..."
        Me.btnExpandirHtml.UseVisualStyleBackColor = True
        '
        'btnExaminar1
        '
        Me.btnExaminar1.Image = CType(resources.GetObject("btnExaminar1.Image"), System.Drawing.Image)
        Me.btnExaminar1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExaminar1.Location = New System.Drawing.Point(878, 20)
        Me.btnExaminar1.Name = "btnExaminar1"
        Me.btnExaminar1.Size = New System.Drawing.Size(70, 20)
        Me.btnExaminar1.TabIndex = 6
        Me.btnExaminar1.Text = "Exam..."
        Me.btnExaminar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExaminar1.UseVisualStyleBackColor = True
        '
        'txtArchivo1
        '
        Me.txtArchivo1.BindearPropiedadControl = "Text"
        Me.txtArchivo1.BindearPropiedadEntidad = "CantidadProductos"
        Me.txtArchivo1.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivo1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivo1.Formato = ""
        Me.txtArchivo1.IsDecimal = False
        Me.txtArchivo1.IsNumber = False
        Me.txtArchivo1.IsPK = False
        Me.txtArchivo1.IsRequired = False
        Me.txtArchivo1.Key = ""
        Me.txtArchivo1.LabelAsoc = Me.lblArchivo1
        Me.txtArchivo1.Location = New System.Drawing.Point(539, 20)
        Me.txtArchivo1.Name = "txtArchivo1"
        Me.txtArchivo1.Size = New System.Drawing.Size(333, 20)
        Me.txtArchivo1.TabIndex = 5
        '
        'lblArchivo1
        '
        Me.lblArchivo1.AutoSize = True
        Me.lblArchivo1.LabelAsoc = Nothing
        Me.lblArchivo1.Location = New System.Drawing.Point(485, 24)
        Me.lblArchivo1.Name = "lblArchivo1"
        Me.lblArchivo1.Size = New System.Drawing.Size(52, 13)
        Me.lblArchivo1.TabIndex = 4
        Me.lblArchivo1.Text = "Archivo 1"
        '
        'txtAsuntoMail
        '
        Me.txtAsuntoMail.Location = New System.Drawing.Point(63, 20)
        Me.txtAsuntoMail.Name = "txtAsuntoMail"
        Me.txtAsuntoMail.Size = New System.Drawing.Size(407, 20)
        Me.txtAsuntoMail.TabIndex = 1
        '
        'lblCuerpo
        '
        Me.lblCuerpo.AutoSize = True
        Me.lblCuerpo.LabelAsoc = Nothing
        Me.lblCuerpo.Location = New System.Drawing.Point(12, 46)
        Me.lblCuerpo.Name = "lblCuerpo"
        Me.lblCuerpo.Size = New System.Drawing.Size(41, 13)
        Me.lblCuerpo.TabIndex = 2
        Me.lblCuerpo.Text = "Cuerpo"
        '
        'lblAsunto
        '
        Me.lblAsunto.AutoSize = True
        Me.lblAsunto.LabelAsoc = Nothing
        Me.lblAsunto.Location = New System.Drawing.Point(12, 23)
        Me.lblAsunto.Name = "lblAsunto"
        Me.lblAsunto.Size = New System.Drawing.Size(40, 13)
        Me.lblAsunto.TabIndex = 0
        Me.lblAsunto.Text = "Asunto"
        '
        'sspPie
        '
        Me.sspPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto, Me.tspBarra})
        Me.sspPie.Location = New System.Drawing.Point(0, 540)
        Me.sspPie.Name = "sspPie"
        Me.sspPie.Size = New System.Drawing.Size(984, 22)
        Me.sspPie.TabIndex = 7
        Me.sspPie.Text = "StatusStrip1"
        '
        'tslTexto
        '
        Me.tslTexto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tslTexto.Name = "tslTexto"
        Me.tslTexto.Size = New System.Drawing.Size(867, 17)
        Me.tslTexto.Spring = True
        Me.tslTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Step = 1
        '
        'ugDetalle
        '
        Me.ugDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 80
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance2
        UltraGridColumn30.Header.VisiblePosition = 2
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance3
        UltraGridColumn31.Format = ""
        UltraGridColumn31.Header.Caption = "Código"
        UltraGridColumn31.Header.VisiblePosition = 3
        UltraGridColumn31.Width = 60
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn32.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn32.Header.Caption = "Nombre Cliente"
        UltraGridColumn32.Header.VisiblePosition = 4
        UltraGridColumn32.Width = 150
        UltraGridColumn33.Header.Caption = "Nombre Fantasia"
        UltraGridColumn33.Header.VisiblePosition = 5
        UltraGridColumn33.Width = 150
        UltraGridColumn34.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn34.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn34.Header.Caption = "Correo(s) Electronico(s)"
        UltraGridColumn34.Header.VisiblePosition = 6
        UltraGridColumn34.Width = 150
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance4
        UltraGridColumn35.Header.VisiblePosition = 12
        UltraGridColumn35.Hidden = True
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn36.Header.Caption = "Categoria"
        UltraGridColumn36.Header.VisiblePosition = 10
        UltraGridColumn36.Width = 83
        UltraGridColumn37.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn37.CellAppearance = Appearance5
        UltraGridColumn37.Header.VisiblePosition = 13
        UltraGridColumn37.Hidden = True
        UltraGridColumn38.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn38.Header.VisiblePosition = 14
        UltraGridColumn38.Hidden = True
        UltraGridColumn39.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance6
        UltraGridColumn39.Header.VisiblePosition = 15
        UltraGridColumn39.Hidden = True
        UltraGridColumn40.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn40.Header.Caption = "Zona"
        UltraGridColumn40.Header.VisiblePosition = 11
        UltraGridColumn40.Width = 77
        UltraGridColumn41.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance7.TextHAlignAsString = "Center"
        UltraGridColumn41.CellAppearance = Appearance7
        UltraGridColumn41.Format = "dd/MM/yyyy"
        UltraGridColumn41.Header.VisiblePosition = 17
        UltraGridColumn41.Width = 76
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn42.CellAppearance = Appearance8
        UltraGridColumn42.Header.VisiblePosition = 16
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn43.Header.Caption = "Comprobante"
        UltraGridColumn43.Header.VisiblePosition = 20
        UltraGridColumn43.Width = 80
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance9.TextHAlignAsString = "Center"
        UltraGridColumn44.CellAppearance = Appearance9
        UltraGridColumn44.Header.Caption = "L."
        UltraGridColumn44.Header.VisiblePosition = 21
        UltraGridColumn44.Width = 30
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance10
        UltraGridColumn45.Header.Caption = "C.E."
        UltraGridColumn45.Header.VisiblePosition = 22
        UltraGridColumn45.Width = 40
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn46.CellAppearance = Appearance11
        UltraGridColumn46.Header.Caption = "Numero"
        UltraGridColumn46.Header.VisiblePosition = 23
        UltraGridColumn46.Width = 60
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn47.CellAppearance = Appearance12
        UltraGridColumn47.Format = "N2"
        UltraGridColumn47.Header.Caption = "Importe"
        UltraGridColumn47.Header.VisiblePosition = 24
        UltraGridColumn47.MaskInput = "{double:-9.2}"
        UltraGridColumn47.Width = 70
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance13
        UltraGridColumn48.Format = "N2"
        UltraGridColumn48.Header.VisiblePosition = 25
        UltraGridColumn48.Width = 85
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn49.Header.VisiblePosition = 26
        UltraGridColumn49.Width = 320
        Appearance14.TextHAlignAsString = "Center"
        UltraGridColumn50.CellAppearance = Appearance14
        UltraGridColumn50.Header.Caption = "Envío"
        UltraGridColumn50.Header.VisiblePosition = 1
        UltraGridColumn50.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn50.Width = 33
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn51.Header.Caption = "Vendedor"
        UltraGridColumn51.Header.VisiblePosition = 27
        UltraGridColumn51.Width = 150
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn52.Header.Caption = "Cobrador"
        UltraGridColumn52.Header.VisiblePosition = 28
        UltraGridColumn52.Width = 150
        UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn53.Header.Caption = "Estado Cliente"
        UltraGridColumn53.Header.VisiblePosition = 29
        UltraGridColumn53.Width = 150
        UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance15.TextHAlignAsString = "Center"
        UltraGridColumn54.CellAppearance = Appearance15
        UltraGridColumn54.Format = "dd/MM/yyyy"
        UltraGridColumn54.Header.Caption = "Vencimiento"
        UltraGridColumn54.Header.VisiblePosition = 18
        UltraGridColumn54.Width = 76
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn55.CellAppearance = Appearance16
        UltraGridColumn55.Header.Caption = "Días"
        UltraGridColumn55.Header.VisiblePosition = 19
        UltraGridColumn55.Width = 44
        Appearance17.TextHAlignAsString = "Center"
        UltraGridColumn56.CellAppearance = Appearance17
        UltraGridColumn56.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn56.Header.Caption = "Fecha Envio de Correo"
        UltraGridColumn56.Header.VisiblePosition = 30
        UltraGridColumn57.Header.VisiblePosition = 31
        UltraGridColumn57.Hidden = True
        UltraGridColumn58.Header.VisiblePosition = 32
        UltraGridColumn58.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 33
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance18
        UltraGridColumn3.Header.Caption = "Codigo Vinculado"
        UltraGridColumn3.Header.VisiblePosition = 7
        UltraGridColumn3.Width = 105
        UltraGridColumn4.Header.Caption = "Nombre Vinculado"
        UltraGridColumn4.Header.VisiblePosition = 8
        UltraGridColumn4.Width = 150
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        UltraGridColumn5.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn5.Header.Caption = "Correo Vinculado"
        UltraGridColumn5.Header.VisiblePosition = 9
        UltraGridColumn5.Width = 146
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        UltraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Appearance19.TextHAlignAsString = "Right"
        SummarySettings1.Appearance = Appearance19
        SummarySettings1.DisplayFormat = "{0:N2}"
        SummarySettings1.GroupBySummaryValueAppearance = Appearance20
        UltraGridBand1.Summaries.AddRange(New Infragistics.Win.UltraWinGrid.SummarySettings() {SummarySettings1})
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance21.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance21.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance21
        Appearance22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance22
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance23.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance23.BackColor2 = System.Drawing.SystemColors.Control
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance23
        Me.ugDetalle.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Appearance24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance24
        Appearance25.BackColor = System.Drawing.SystemColors.Highlight
        Appearance25.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance26
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Me.ugDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugDetalle.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance28.BackColor = System.Drawing.Color.Tomato
        Appearance28.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance28.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance29.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance30.BackColor = System.Drawing.SystemColors.Window
        Appearance30.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance31.BackColor = System.Drawing.Color.LimeGreen
        Appearance31.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance31
        Appearance32.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 210)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 186)
        Me.ugDetalle.TabIndex = 6
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.cmbTipoCliente)
        Me.grbFiltros.Controls.Add(Me.lblCliente)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.chbSaldo)
        Me.grbFiltros.Controls.Add(Me.cmbOperadorLogico)
        Me.grbFiltros.Controls.Add(Me.txtSaldo)
        Me.grbFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grbFiltros.Controls.Add(Me.cmbCorreoEnviado)
        Me.grbFiltros.Controls.Add(Me.lblCorreoEnviado)
        Me.grbFiltros.Controls.Add(Me.chbCobrador)
        Me.grbFiltros.Controls.Add(Me.cmbCobrador)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.lblComenzarPorNombreCliente)
        Me.grbFiltros.Controls.Add(Me.txtComenzarPorNombreCliente)
        Me.grbFiltros.Controls.Add(Me.chbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.chbCategoriaCliente)
        Me.grbFiltros.Controls.Add(Me.cmbZonaGeografica)
        Me.grbFiltros.Controls.Add(Me.cmbCategoriasClientes)
        Me.grbFiltros.Controls.Add(Me.bscNombreCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombreCliente)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Location = New System.Drawing.Point(13, 32)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(959, 144)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        '
        'cmbTipoCliente
        '
        Me.cmbTipoCliente.BindearPropiedadControl = Nothing
        Me.cmbTipoCliente.BindearPropiedadEntidad = Nothing
        Me.cmbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoCliente.FormattingEnabled = True
        Me.cmbTipoCliente.IsPK = False
        Me.cmbTipoCliente.IsRequired = False
        Me.cmbTipoCliente.Items.AddRange(New Object() {"CLIENTE", "VINCULADO"})
        Me.cmbTipoCliente.Key = Nothing
        Me.cmbTipoCliente.LabelAsoc = Nothing
        Me.cmbTipoCliente.Location = New System.Drawing.Point(576, 63)
        Me.cmbTipoCliente.Name = "cmbTipoCliente"
        Me.cmbTipoCliente.Size = New System.Drawing.Size(147, 21)
        Me.cmbTipoCliente.TabIndex = 61
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.LabelAsoc = Nothing
        Me.lblCliente.Location = New System.Drawing.Point(504, 66)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(66, 13)
        Me.lblCliente.TabIndex = 60
        Me.lblCliente.Text = "Tipo Cliente "
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(84, 9)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(140, 21)
        Me.cmbSucursal.TabIndex = 27
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(7, 13)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 26
        Me.lblSucursal.Text = "Sucursal"
        '
        'chbSaldo
        '
        Me.chbSaldo.AutoSize = True
        Me.chbSaldo.Location = New System.Drawing.Point(9, 120)
        Me.chbSaldo.Name = "chbSaldo"
        Me.chbSaldo.Size = New System.Drawing.Size(53, 17)
        Me.chbSaldo.TabIndex = 22
        Me.chbSaldo.Text = "Saldo"
        Me.chbSaldo.UseVisualStyleBackColor = True
        '
        'cmbOperadorLogico
        '
        Me.cmbOperadorLogico.BindearPropiedadControl = Nothing
        Me.cmbOperadorLogico.BindearPropiedadEntidad = Nothing
        Me.cmbOperadorLogico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperadorLogico.Enabled = False
        Me.cmbOperadorLogico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOperadorLogico.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOperadorLogico.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOperadorLogico.FormattingEnabled = True
        Me.cmbOperadorLogico.IsPK = False
        Me.cmbOperadorLogico.IsRequired = False
        Me.cmbOperadorLogico.Key = Nothing
        Me.cmbOperadorLogico.LabelAsoc = Nothing
        Me.cmbOperadorLogico.Location = New System.Drawing.Point(68, 118)
        Me.cmbOperadorLogico.Name = "cmbOperadorLogico"
        Me.cmbOperadorLogico.Size = New System.Drawing.Size(132, 21)
        Me.cmbOperadorLogico.TabIndex = 23
        '
        'txtSaldo
        '
        Me.txtSaldo.BindearPropiedadControl = ""
        Me.txtSaldo.BindearPropiedadEntidad = ""
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldo.Formato = "N2"
        Me.txtSaldo.IsDecimal = True
        Me.txtSaldo.IsNumber = True
        Me.txtSaldo.IsPK = False
        Me.txtSaldo.IsRequired = False
        Me.txtSaldo.Key = ""
        Me.txtSaldo.LabelAsoc = Nothing
        Me.txtSaldo.Location = New System.Drawing.Point(206, 118)
        Me.txtSaldo.MaxLength = 60
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(60, 20)
        Me.txtSaldo.TabIndex = 24
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.chbTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(352, 35)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(140, 21)
        Me.cmbTiposComprobantes.TabIndex = 8
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(252, 39)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(94, 13)
        Me.chbTipoComprobante.TabIndex = 7
        Me.chbTipoComprobante.Text = "Tipo Comprobante"
        '
        'cmbCorreoEnviado
        '
        Me.cmbCorreoEnviado.BindearPropiedadControl = ""
        Me.cmbCorreoEnviado.BindearPropiedadEntidad = ""
        Me.cmbCorreoEnviado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorreoEnviado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCorreoEnviado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCorreoEnviado.FormattingEnabled = True
        Me.cmbCorreoEnviado.IsPK = False
        Me.cmbCorreoEnviado.IsRequired = True
        Me.cmbCorreoEnviado.Key = Nothing
        Me.cmbCorreoEnviado.LabelAsoc = Me.lblCorreoEnviado
        Me.cmbCorreoEnviado.Location = New System.Drawing.Point(576, 36)
        Me.cmbCorreoEnviado.Name = "cmbCorreoEnviado"
        Me.cmbCorreoEnviado.Size = New System.Drawing.Size(93, 21)
        Me.cmbCorreoEnviado.TabIndex = 10
        '
        'lblCorreoEnviado
        '
        Me.lblCorreoEnviado.AutoSize = True
        Me.lblCorreoEnviado.LabelAsoc = Nothing
        Me.lblCorreoEnviado.Location = New System.Drawing.Point(504, 40)
        Me.lblCorreoEnviado.Name = "lblCorreoEnviado"
        Me.lblCorreoEnviado.Size = New System.Drawing.Size(46, 13)
        Me.lblCorreoEnviado.TabIndex = 9
        Me.lblCorreoEnviado.Text = "Enviado"
        '
        'chbCobrador
        '
        Me.chbCobrador.AutoSize = True
        Me.chbCobrador.BindearPropiedadControl = Nothing
        Me.chbCobrador.BindearPropiedadEntidad = Nothing
        Me.chbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCobrador.IsPK = False
        Me.chbCobrador.IsRequired = False
        Me.chbCobrador.Key = Nothing
        Me.chbCobrador.LabelAsoc = Nothing
        Me.chbCobrador.Location = New System.Drawing.Point(9, 65)
        Me.chbCobrador.Name = "chbCobrador"
        Me.chbCobrador.Size = New System.Drawing.Size(69, 17)
        Me.chbCobrador.TabIndex = 11
        Me.chbCobrador.Text = "Cobrador"
        Me.chbCobrador.UseVisualStyleBackColor = True
        '
        'cmbCobrador
        '
        Me.cmbCobrador.BindearPropiedadControl = Nothing
        Me.cmbCobrador.BindearPropiedadEntidad = Nothing
        Me.cmbCobrador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCobrador.Enabled = False
        Me.cmbCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCobrador.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCobrador.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCobrador.FormattingEnabled = True
        Me.cmbCobrador.IsPK = False
        Me.cmbCobrador.IsRequired = False
        Me.cmbCobrador.Key = Nothing
        Me.cmbCobrador.LabelAsoc = Nothing
        Me.cmbCobrador.Location = New System.Drawing.Point(84, 63)
        Me.cmbCobrador.Name = "cmbCobrador"
        Me.cmbCobrador.Size = New System.Drawing.Size(140, 21)
        Me.cmbCobrador.TabIndex = 12
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(237, 11)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 0
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(544, 9)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 4
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(504, 13)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 3
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(374, 9)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 2
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(332, 13)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 1
        Me.lblDesde.Text = "Desde"
        '
        'lblComenzarPorNombreCliente
        '
        Me.lblComenzarPorNombreCliente.AutoSize = True
        Me.lblComenzarPorNombreCliente.LabelAsoc = Nothing
        Me.lblComenzarPorNombreCliente.Location = New System.Drawing.Point(478, 93)
        Me.lblComenzarPorNombreCliente.Name = "lblComenzarPorNombreCliente"
        Me.lblComenzarPorNombreCliente.Size = New System.Drawing.Size(148, 13)
        Me.lblComenzarPorNombreCliente.TabIndex = 20
        Me.lblComenzarPorNombreCliente.Text = "Comenzar Por Nombre Cliente"
        '
        'txtComenzarPorNombreCliente
        '
        Me.txtComenzarPorNombreCliente.BindearPropiedadControl = ""
        Me.txtComenzarPorNombreCliente.BindearPropiedadEntidad = ""
        Me.txtComenzarPorNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComenzarPorNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComenzarPorNombreCliente.Formato = "N2"
        Me.txtComenzarPorNombreCliente.IsDecimal = False
        Me.txtComenzarPorNombreCliente.IsNumber = False
        Me.txtComenzarPorNombreCliente.IsPK = False
        Me.txtComenzarPorNombreCliente.IsRequired = False
        Me.txtComenzarPorNombreCliente.Key = ""
        Me.txtComenzarPorNombreCliente.LabelAsoc = Me.lblComenzarPorNombreCliente
        Me.txtComenzarPorNombreCliente.Location = New System.Drawing.Point(630, 89)
        Me.txtComenzarPorNombreCliente.MaxLength = 60
        Me.txtComenzarPorNombreCliente.Name = "txtComenzarPorNombreCliente"
        Me.txtComenzarPorNombreCliente.Size = New System.Drawing.Size(171, 20)
        Me.txtComenzarPorNombreCliente.TabIndex = 21
        '
        'chbZonaGeografica
        '
        Me.chbZonaGeografica.AutoSize = True
        Me.chbZonaGeografica.BindearPropiedadControl = Nothing
        Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbZonaGeografica.IsPK = False
        Me.chbZonaGeografica.IsRequired = False
        Me.chbZonaGeografica.Key = Nothing
        Me.chbZonaGeografica.LabelAsoc = Nothing
        Me.chbZonaGeografica.Location = New System.Drawing.Point(237, 65)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(109, 17)
        Me.chbZonaGeografica.TabIndex = 13
        Me.chbZonaGeografica.Text = "Zona Greográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
        '
        'chbCategoriaCliente
        '
        Me.chbCategoriaCliente.AutoSize = True
        Me.chbCategoriaCliente.BindearPropiedadControl = Nothing
        Me.chbCategoriaCliente.BindearPropiedadEntidad = Nothing
        Me.chbCategoriaCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoriaCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoriaCliente.IsPK = False
        Me.chbCategoriaCliente.IsRequired = False
        Me.chbCategoriaCliente.Key = Nothing
        Me.chbCategoriaCliente.LabelAsoc = Nothing
        Me.chbCategoriaCliente.Location = New System.Drawing.Point(10, 38)
        Me.chbCategoriaCliente.Name = "chbCategoriaCliente"
        Me.chbCategoriaCliente.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoriaCliente.TabIndex = 5
        Me.chbCategoriaCliente.Text = "Categoria"
        Me.chbCategoriaCliente.UseVisualStyleBackColor = True
        '
        'cmbZonaGeografica
        '
        Me.cmbZonaGeografica.BindearPropiedadControl = ""
        Me.cmbZonaGeografica.BindearPropiedadEntidad = ""
        Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaGeografica.Enabled = False
        Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbZonaGeografica.FormattingEnabled = True
        Me.cmbZonaGeografica.IsPK = False
        Me.cmbZonaGeografica.IsRequired = True
        Me.cmbZonaGeografica.Key = Nothing
        Me.cmbZonaGeografica.LabelAsoc = Nothing
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(352, 63)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(140, 21)
        Me.cmbZonaGeografica.TabIndex = 14
        '
        'cmbCategoriasClientes
        '
        Me.cmbCategoriasClientes.BindearPropiedadControl = ""
        Me.cmbCategoriasClientes.BindearPropiedadEntidad = ""
        Me.cmbCategoriasClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriasClientes.Enabled = False
        Me.cmbCategoriasClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriasClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriasClientes.FormattingEnabled = True
        Me.cmbCategoriasClientes.IsPK = False
        Me.cmbCategoriasClientes.IsRequired = True
        Me.cmbCategoriasClientes.Key = Nothing
        Me.cmbCategoriasClientes.LabelAsoc = Nothing
        Me.cmbCategoriasClientes.Location = New System.Drawing.Point(84, 36)
        Me.cmbCategoriasClientes.Name = "cmbCategoriasClientes"
        Me.cmbCategoriasClientes.Size = New System.Drawing.Size(140, 21)
        Me.cmbCategoriasClientes.TabIndex = 6
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.AyudaAncho = 608
        Me.bscNombreCliente.BindearPropiedadControl = Nothing
        Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
        Me.bscNombreCliente.ColumnasAlineacion = Nothing
        Me.bscNombreCliente.ColumnasAncho = Nothing
        Me.bscNombreCliente.ColumnasFormato = Nothing
        Me.bscNombreCliente.ColumnasOcultas = Nothing
        Me.bscNombreCliente.ColumnasTitulos = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.Enabled = False
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Me.lblNombreCliente
        Me.bscNombreCliente.Location = New System.Drawing.Point(266, 89)
        Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = True
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(206, 23)
        Me.bscNombreCliente.TabIndex = 19
        Me.bscNombreCliente.Titulo = Nothing
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.LabelAsoc = Nothing
        Me.lblNombreCliente.Location = New System.Drawing.Point(218, 93)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreCliente.TabIndex = 18
        Me.lblNombreCliente.Text = "Nombre"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 608
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ColumnasAlineacion = Nothing
        Me.bscCodigoCliente.ColumnasAncho = Nothing
        Me.bscCodigoCliente.ColumnasFormato = Nothing
        Me.bscCodigoCliente.ColumnasOcultas = Nothing
        Me.bscCodigoCliente.ColumnasTitulos = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.Enabled = False
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(116, 89)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(100, 23)
        Me.bscCodigoCliente.TabIndex = 17
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(70, 93)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 16
        Me.lblCodigoCliente.Text = "Codigo"
        '
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(9, 92)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 15
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(844, 13)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(106, 45)
        Me.btnConsultar.TabIndex = 25
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbEnviarFacturas, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbCorreoPrueba, Me.ToolStripButton1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 6
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
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
        'tsbEnviarFacturas
        '
        Me.tsbEnviarFacturas.Enabled = False
        Me.tsbEnviarFacturas.ForeColor = System.Drawing.Color.ForestGreen
        Me.tsbEnviarFacturas.Image = Global.Eniac.Win.My.Resources.Resources.mail_next_32
        Me.tsbEnviarFacturas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnviarFacturas.Name = "tsbEnviarFacturas"
        Me.tsbEnviarFacturas.Size = New System.Drawing.Size(65, 26)
        Me.tsbEnviarFacturas.Text = "Enviar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCorreoPrueba
        '
        Me.tsbCorreoPrueba.Image = Global.Eniac.Win.My.Resources.Resources.mail_server
        Me.tsbCorreoPrueba.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCorreoPrueba.Name = "tsbCorreoPrueba"
        Me.tsbCorreoPrueba.Size = New System.Drawing.Size(125, 26)
        Me.tsbCorreoPrueba.Text = "C&orreo de Prueba"
        Me.tsbCorreoPrueba.ToolTipText = "Cerrar el formulario"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(65, 26)
        Me.ToolStripButton1.Text = "&Cerrar"
        Me.ToolStripButton1.ToolTipText = "Cerrar el formulario"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'chbCopiaOculta
        '
        Me.chbCopiaOculta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbCopiaOculta.AutoSize = True
        Me.chbCopiaOculta.BindearPropiedadControl = Nothing
        Me.chbCopiaOculta.BindearPropiedadEntidad = Nothing
        Me.chbCopiaOculta.Checked = True
        Me.chbCopiaOculta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbCopiaOculta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCopiaOculta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCopiaOculta.IsPK = False
        Me.chbCopiaOculta.IsRequired = False
        Me.chbCopiaOculta.Key = Nothing
        Me.chbCopiaOculta.LabelAsoc = Nothing
        Me.chbCopiaOculta.Location = New System.Drawing.Point(727, 185)
        Me.chbCopiaOculta.Name = "chbCopiaOculta"
        Me.chbCopiaOculta.Size = New System.Drawing.Size(87, 17)
        Me.chbCopiaOculta.TabIndex = 4
        Me.chbCopiaOculta.Text = "Copia Oculta"
        Me.chbCopiaOculta.UseVisualStyleBackColor = True
        '
        'EnvioMasivoDeFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.cmbReportesCtaCte)
        Me.Controls.Add(Me.chbEnvioCtaCteCliente)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.cmbTodos)
        Me.Controls.Add(Me.txtCopiaOculta)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.sspPie)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.chbCopiaOculta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EnvioMasivoDeFacturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío Masivo de Facturas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.sspPie.ResumeLayout(False)
        Me.sspPie.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbEnviarFacturas As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents sspPie As System.Windows.Forms.StatusStrip
   Friend WithEvents tslTexto As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents rtbCuerpoMail As MSDN.Html.Editor.HtmlEditorControl
   Friend WithEvents lblCuerpo As Eniac.Controles.Label
   Friend WithEvents lblAsunto As Eniac.Controles.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents txtAsuntoMail As System.Windows.Forms.TextBox
   Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoriaCliente As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoriasClientes As Eniac.Controles.ComboBox
   Friend WithEvents btnExaminar4 As Eniac.Controles.Button
   Friend WithEvents txtArchivo4 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo4 As Eniac.Controles.Label
   Friend WithEvents btnExaminar3 As Eniac.Controles.Button
   Friend WithEvents txtArchivo3 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo3 As Eniac.Controles.Label
   Friend WithEvents btnExaminar2 As Eniac.Controles.Button
   Friend WithEvents txtArchivo2 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo2 As Eniac.Controles.Label
   Friend WithEvents btnExaminar1 As Eniac.Controles.Button
   Friend WithEvents txtArchivo1 As Eniac.Controles.TextBox
   Friend WithEvents lblArchivo1 As Eniac.Controles.Label
   Friend WithEvents txtCopiaOculta As Eniac.Controles.TextBox
   Friend WithEvents chbCopiaOculta As Eniac.Controles.CheckBox
   Friend WithEvents lblComenzarPorNombreCliente As Eniac.Controles.Label
   Friend WithEvents txtComenzarPorNombreCliente As Eniac.Controles.TextBox
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents DialogoAbrirArchivo As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnExpandirHtml As Eniac.Controles.Button
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbEnvioCtaCteCliente As Controles.CheckBox
   Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbCobrador As Eniac.Controles.CheckBox
   Friend WithEvents cmbCobrador As Eniac.Controles.ComboBox
   Friend WithEvents cmbCorreoEnviado As Eniac.Controles.ComboBox
   Friend WithEvents lblCorreoEnviado As Eniac.Controles.Label
   Friend WithEvents cmbTiposComprobantes As Eniac.Win.ComboBoxTiposComprobantes
   Friend WithEvents chbTipoComprobante As Eniac.Controles.Label
   Friend WithEvents cmbReportesCtaCte As Eniac.Controles.ComboBox
   Public WithEvents tsbCorreoPrueba As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbSaldo As System.Windows.Forms.CheckBox
   Friend WithEvents cmbOperadorLogico As Eniac.Controles.ComboBox
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
    Public WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents cmbTipoCliente As Controles.ComboBox
    Friend WithEvents lblCliente As Controles.Label
End Class
