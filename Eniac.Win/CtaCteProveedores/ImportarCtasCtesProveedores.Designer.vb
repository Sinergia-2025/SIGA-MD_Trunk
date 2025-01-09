<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarCtasCtesProveedores
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarCtasCtesProveedores))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaVencimiento")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Accion", 0)
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Importa", 1)
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Mensaje", 2)
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EstadoImporta", 3)
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
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.txtRangoCeldasColumnaHasta = New Eniac.Controles.TextBox()
      Me.lblRangoCeldas = New Eniac.Controles.Label()
      Me.txtRangoCeldasFilaDesde = New Eniac.Controles.TextBox()
      Me.txtRangoCeldasFilaHasta = New Eniac.Controles.TextBox()
      Me.txtRangoCeldasColumnaDesde = New Eniac.Controles.TextBox()
      Me.cboAccion = New Eniac.Controles.ComboBox()
      Me.lblAccion = New Eniac.Controles.Label()
      Me.cboEstado = New Eniac.Controles.ComboBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.lblSeparadosCeldas = New Eniac.Controles.Label()
      Me.lblEjemplos = New Eniac.Controles.Label()
      Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.btnMostrar = New Eniac.Controles.Button()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspImportando = New System.Windows.Forms.ToolStripProgressBar()
      Me.tslTiempoActual = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tslRegistroActual = New System.Windows.Forms.ToolStripStatusLabel()
      Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.tbpImportar = New System.Windows.Forms.TabPage()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.tbpConfigurar = New System.Windows.Forms.TabPage()
      Me.txtFormatoFechas = New Eniac.Controles.TextBox()
      Me.lblFormatoFecha = New Eniac.Controles.Label()
      Me.grbPendientes.SuspendLayout()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.tbpImportar.SuspendLayout()
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tbpConfigurar.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Controls.Add(Me.txtRangoCeldasColumnaHasta)
      Me.grbPendientes.Controls.Add(Me.txtRangoCeldasFilaDesde)
      Me.grbPendientes.Controls.Add(Me.txtRangoCeldasFilaHasta)
      Me.grbPendientes.Controls.Add(Me.txtRangoCeldasColumnaDesde)
      Me.grbPendientes.Controls.Add(Me.lblRangoCeldas)
      Me.grbPendientes.Controls.Add(Me.cboAccion)
      Me.grbPendientes.Controls.Add(Me.lblAccion)
      Me.grbPendientes.Controls.Add(Me.cboEstado)
      Me.grbPendientes.Controls.Add(Me.lblEstado)
      Me.grbPendientes.Controls.Add(Me.lblSeparadosCeldas)
      Me.grbPendientes.Controls.Add(Me.lblEjemplos)
      Me.grbPendientes.Controls.Add(Me.txtArchivoOrigen)
      Me.grbPendientes.Controls.Add(Me.lblArchivo)
      Me.grbPendientes.Controls.Add(Me.btnExaminar)
      Me.grbPendientes.Controls.Add(Me.btnMostrar)
      Me.grbPendientes.Dock = System.Windows.Forms.DockStyle.Top
      Me.grbPendientes.Location = New System.Drawing.Point(3, 3)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(970, 100)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'txtRangoCeldasColumnaHasta
      '
      Me.txtRangoCeldasColumnaHasta.BindearPropiedadControl = Nothing
      Me.txtRangoCeldasColumnaHasta.BindearPropiedadEntidad = Nothing
      Me.txtRangoCeldasColumnaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRangoCeldasColumnaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRangoCeldasColumnaHasta.Formato = ""
      Me.txtRangoCeldasColumnaHasta.IsDecimal = False
      Me.txtRangoCeldasColumnaHasta.IsNumber = False
      Me.txtRangoCeldasColumnaHasta.IsPK = False
      Me.txtRangoCeldasColumnaHasta.IsRequired = False
      Me.txtRangoCeldasColumnaHasta.Key = ""
      Me.txtRangoCeldasColumnaHasta.LabelAsoc = Me.lblRangoCeldas
      Me.txtRangoCeldasColumnaHasta.Location = New System.Drawing.Point(424, 62)
      Me.txtRangoCeldasColumnaHasta.Name = "txtRangoCeldasColumnaHasta"
      Me.txtRangoCeldasColumnaHasta.Size = New System.Drawing.Size(20, 20)
      Me.txtRangoCeldasColumnaHasta.TabIndex = 11
      Me.txtRangoCeldasColumnaHasta.Text = "K"
      Me.txtRangoCeldasColumnaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblRangoCeldas
      '
      Me.lblRangoCeldas.AutoSize = True
      Me.lblRangoCeldas.LabelAsoc = Nothing
      Me.lblRangoCeldas.Location = New System.Drawing.Point(370, 47)
      Me.lblRangoCeldas.Name = "lblRangoCeldas"
      Me.lblRangoCeldas.Size = New System.Drawing.Size(88, 13)
      Me.lblRangoCeldas.TabIndex = 7
      Me.lblRangoCeldas.Text = "Rango de celdas"
      '
      'txtRangoCeldasFilaDesde
      '
      Me.txtRangoCeldasFilaDesde.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.txtRangoCeldasFilaDesde.BindearPropiedadControl = Nothing
      Me.txtRangoCeldasFilaDesde.BindearPropiedadEntidad = Nothing
      Me.txtRangoCeldasFilaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRangoCeldasFilaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRangoCeldasFilaDesde.Formato = ""
      Me.txtRangoCeldasFilaDesde.IsDecimal = False
      Me.txtRangoCeldasFilaDesde.IsNumber = False
      Me.txtRangoCeldasFilaDesde.IsPK = False
      Me.txtRangoCeldasFilaDesde.IsRequired = False
      Me.txtRangoCeldasFilaDesde.Key = ""
      Me.txtRangoCeldasFilaDesde.LabelAsoc = Me.lblRangoCeldas
      Me.txtRangoCeldasFilaDesde.Location = New System.Drawing.Point(386, 62)
      Me.txtRangoCeldasFilaDesde.Name = "txtRangoCeldasFilaDesde"
      Me.txtRangoCeldasFilaDesde.Size = New System.Drawing.Size(30, 20)
      Me.txtRangoCeldasFilaDesde.TabIndex = 9
      Me.txtRangoCeldasFilaDesde.Text = "1"
      Me.txtRangoCeldasFilaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRangoCeldasFilaHasta
      '
      Me.txtRangoCeldasFilaHasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.txtRangoCeldasFilaHasta.BindearPropiedadControl = Nothing
      Me.txtRangoCeldasFilaHasta.BindearPropiedadEntidad = Nothing
      Me.txtRangoCeldasFilaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRangoCeldasFilaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRangoCeldasFilaHasta.Formato = ""
      Me.txtRangoCeldasFilaHasta.IsDecimal = False
      Me.txtRangoCeldasFilaHasta.IsNumber = False
      Me.txtRangoCeldasFilaHasta.IsPK = False
      Me.txtRangoCeldasFilaHasta.IsRequired = False
      Me.txtRangoCeldasFilaHasta.Key = ""
      Me.txtRangoCeldasFilaHasta.LabelAsoc = Me.lblRangoCeldas
      Me.txtRangoCeldasFilaHasta.Location = New System.Drawing.Point(443, 62)
      Me.txtRangoCeldasFilaHasta.Name = "txtRangoCeldasFilaHasta"
      Me.txtRangoCeldasFilaHasta.Size = New System.Drawing.Size(46, 20)
      Me.txtRangoCeldasFilaHasta.TabIndex = 12
      Me.txtRangoCeldasFilaHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRangoCeldasColumnaDesde
      '
      Me.txtRangoCeldasColumnaDesde.BindearPropiedadControl = Nothing
      Me.txtRangoCeldasColumnaDesde.BindearPropiedadEntidad = Nothing
      Me.txtRangoCeldasColumnaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRangoCeldasColumnaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRangoCeldasColumnaDesde.Formato = ""
      Me.txtRangoCeldasColumnaDesde.IsDecimal = False
      Me.txtRangoCeldasColumnaDesde.IsNumber = False
      Me.txtRangoCeldasColumnaDesde.IsPK = False
      Me.txtRangoCeldasColumnaDesde.IsRequired = False
      Me.txtRangoCeldasColumnaDesde.Key = ""
      Me.txtRangoCeldasColumnaDesde.LabelAsoc = Me.lblRangoCeldas
      Me.txtRangoCeldasColumnaDesde.Location = New System.Drawing.Point(367, 62)
      Me.txtRangoCeldasColumnaDesde.Name = "txtRangoCeldasColumnaDesde"
      Me.txtRangoCeldasColumnaDesde.Size = New System.Drawing.Size(20, 20)
      Me.txtRangoCeldasColumnaDesde.TabIndex = 8
      Me.txtRangoCeldasColumnaDesde.Text = "A"
      Me.txtRangoCeldasColumnaDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'cboAccion
      '
      Me.cboAccion.BindearPropiedadControl = Nothing
      Me.cboAccion.BindearPropiedadEntidad = Nothing
      Me.cboAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboAccion.ForeColorFocus = System.Drawing.Color.Red
      Me.cboAccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboAccion.FormattingEnabled = True
      Me.cboAccion.IsPK = False
      Me.cboAccion.IsRequired = False
      Me.cboAccion.Key = Nothing
      Me.cboAccion.LabelAsoc = Me.lblAccion
      Me.cboAccion.Location = New System.Drawing.Point(251, 62)
      Me.cboAccion.Name = "cboAccion"
      Me.cboAccion.Size = New System.Drawing.Size(96, 21)
      Me.cboAccion.TabIndex = 6
      Me.cboAccion.Visible = False
      '
      'lblAccion
      '
      Me.lblAccion.AutoSize = True
      Me.lblAccion.LabelAsoc = Nothing
      Me.lblAccion.Location = New System.Drawing.Point(205, 66)
      Me.lblAccion.Name = "lblAccion"
      Me.lblAccion.Size = New System.Drawing.Size(40, 13)
      Me.lblAccion.TabIndex = 5
      Me.lblAccion.Text = "Accion"
      Me.lblAccion.Visible = False
      '
      'cboEstado
      '
      Me.cboEstado.BindearPropiedadControl = Nothing
      Me.cboEstado.BindearPropiedadEntidad = Nothing
      Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.cboEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboEstado.FormattingEnabled = True
      Me.cboEstado.IsPK = False
      Me.cboEstado.IsRequired = False
      Me.cboEstado.Key = Nothing
      Me.cboEstado.LabelAsoc = Me.lblEstado
      Me.cboEstado.Location = New System.Drawing.Point(87, 62)
      Me.cboEstado.Name = "cboEstado"
      Me.cboEstado.Size = New System.Drawing.Size(96, 21)
      Me.cboEstado.TabIndex = 4
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(33, 66)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 3
      Me.lblEstado.Text = "Estado"
      '
      'lblSeparadosCeldas
      '
      Me.lblSeparadosCeldas.AutoSize = True
      Me.lblSeparadosCeldas.LabelAsoc = Nothing
      Me.lblSeparadosCeldas.Location = New System.Drawing.Point(415, 66)
      Me.lblSeparadosCeldas.Name = "lblSeparadosCeldas"
      Me.lblSeparadosCeldas.Size = New System.Drawing.Size(10, 13)
      Me.lblSeparadosCeldas.TabIndex = 10
      Me.lblSeparadosCeldas.Text = ":"
      Me.lblSeparadosCeldas.Visible = False
      '
      'lblEjemplos
      '
      Me.lblEjemplos.AutoSize = True
      Me.lblEjemplos.LabelAsoc = Nothing
      Me.lblEjemplos.Location = New System.Drawing.Point(503, 66)
      Me.lblEjemplos.Name = "lblEjemplos"
      Me.lblEjemplos.Size = New System.Drawing.Size(100, 13)
      Me.lblEjemplos.TabIndex = 13
      Me.lblEjemplos.Text = "Ejemplo:  A1 : T200"
      Me.lblEjemplos.Visible = False
      '
      'txtArchivoOrigen
      '
      Me.txtArchivoOrigen.BindearPropiedadControl = "Text"
      Me.txtArchivoOrigen.BindearPropiedadEntidad = "CantidadProductos"
      Me.txtArchivoOrigen.ForeColorFocus = System.Drawing.Color.Red
      Me.txtArchivoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtArchivoOrigen.Formato = ""
      Me.txtArchivoOrigen.IsDecimal = False
      Me.txtArchivoOrigen.IsNumber = False
      Me.txtArchivoOrigen.IsPK = False
      Me.txtArchivoOrigen.IsRequired = False
      Me.txtArchivoOrigen.Key = ""
      Me.txtArchivoOrigen.LabelAsoc = Nothing
      Me.txtArchivoOrigen.Location = New System.Drawing.Point(87, 26)
      Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
      Me.txtArchivoOrigen.Size = New System.Drawing.Size(499, 20)
      Me.txtArchivoOrigen.TabIndex = 1
      '
      'lblArchivo
      '
      Me.lblArchivo.AutoSize = True
      Me.lblArchivo.LabelAsoc = Nothing
      Me.lblArchivo.Location = New System.Drawing.Point(33, 30)
      Me.lblArchivo.Name = "lblArchivo"
      Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
      Me.lblArchivo.TabIndex = 0
      Me.lblArchivo.Text = "Archivo"
      '
      'btnExaminar
      '
      Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.Location = New System.Drawing.Point(591, 16)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(104, 40)
      Me.btnExaminar.TabIndex = 2
      Me.btnExaminar.Text = "&Examinar..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      '
      'btnMostrar
      '
      Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.view
      Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnMostrar.Location = New System.Drawing.Point(836, 26)
      Me.btnMostrar.Name = "btnMostrar"
      Me.btnMostrar.Size = New System.Drawing.Size(100, 45)
      Me.btnMostrar.TabIndex = 16
      Me.btnMostrar.Text = "&Mostrar"
      Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnMostrar.UseVisualStyleBackColor = False
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 1
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
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
      'tsbImportar
      '
      Me.tsbImportar.Enabled = False
      Me.tsbImportar.Image = CType(resources.GetObject("tsbImportar.Image"), System.Drawing.Image)
      Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImportar.Name = "tsbImportar"
      Me.tsbImportar.Size = New System.Drawing.Size(79, 26)
      Me.tsbImportar.Text = "&Importar"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros, Me.tspImportando, Me.tslTiempoActual, Me.tslRegistroActual})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
      Me.StatusStrip1.TabIndex = 3
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(885, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'tspImportando
      '
      Me.tspImportando.Name = "tspImportando"
      Me.tspImportando.Size = New System.Drawing.Size(100, 16)
      Me.tspImportando.Visible = False
      '
      'tslTiempoActual
      '
      Me.tslTiempoActual.Name = "tslTiempoActual"
      Me.tslTiempoActual.Size = New System.Drawing.Size(45, 17)
      Me.tslTiempoActual.Text = "tiempo"
      '
      'tslRegistroActual
      '
      Me.tslRegistroActual.Name = "tslRegistroActual"
      Me.tslRegistroActual.Size = New System.Drawing.Size(39, 17)
      Me.tslRegistroActual.Text = "actual"
      '
      'DialogoAbrirArchivo
      '
      Me.DialogoAbrirArchivo.Filter = """Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|To" & _
    "dos los Archivos (*.*)|*.*"""
      Me.DialogoAbrirArchivo.RestoreDirectory = True
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.tbpImportar)
      Me.TabControl1.Controls.Add(Me.tbpConfigurar)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 29)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(984, 511)
      Me.TabControl1.TabIndex = 0
      '
      'tbpImportar
      '
      Me.tbpImportar.BackColor = System.Drawing.SystemColors.Control
      Me.tbpImportar.Controls.Add(Me.ugDetalle)
      Me.tbpImportar.Controls.Add(Me.grbPendientes)
      Me.tbpImportar.Location = New System.Drawing.Point(4, 22)
      Me.tbpImportar.Name = "tbpImportar"
      Me.tbpImportar.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpImportar.Size = New System.Drawing.Size(976, 485)
      Me.tbpImportar.TabIndex = 0
      Me.tbpImportar.Text = "Importar"
      '
      'ugDetalle
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugDetalle.DisplayLayout.Appearance = Appearance1
      Appearance2.TextHAlignAsString = "Right"
      UltraGridColumn5.CellAppearance = Appearance2
      UltraGridColumn5.Header.Caption = "Sucursal"
      UltraGridColumn5.Header.VisiblePosition = 6
      UltraGridColumn5.Width = 54
      UltraGridColumn17.Header.VisiblePosition = 1
      UltraGridColumn17.Hidden = True
      Appearance3.TextHAlignAsString = "Right"
      UltraGridColumn18.CellAppearance = Appearance3
      UltraGridColumn18.Header.Caption = "Codigo"
      UltraGridColumn18.Header.VisiblePosition = 3
      UltraGridColumn18.Width = 70
      UltraGridColumn19.Header.Caption = "Nombre Proveedor"
      UltraGridColumn19.Header.VisiblePosition = 5
      UltraGridColumn19.Width = 215
      UltraGridColumn20.Header.Caption = "Comprobante"
      UltraGridColumn20.Header.VisiblePosition = 7
      UltraGridColumn10.Header.VisiblePosition = 8
      UltraGridColumn10.Width = 38
      Appearance4.TextHAlignAsString = "Right"
      UltraGridColumn11.CellAppearance = Appearance4
      UltraGridColumn11.Header.Caption = "Emisor"
      UltraGridColumn11.Header.VisiblePosition = 9
      UltraGridColumn11.Width = 45
      Appearance5.TextHAlignAsString = "Right"
      UltraGridColumn12.CellAppearance = Appearance5
      UltraGridColumn12.Header.Caption = "Numero"
      UltraGridColumn12.Header.VisiblePosition = 10
      UltraGridColumn12.Width = 70
      Appearance6.TextHAlignAsString = "Center"
      UltraGridColumn13.CellAppearance = Appearance6
      UltraGridColumn13.Header.Caption = "Emision"
      UltraGridColumn13.Header.VisiblePosition = 11
      UltraGridColumn13.Width = 80
      Appearance7.TextHAlignAsString = "Center"
      UltraGridColumn14.CellAppearance = Appearance7
      UltraGridColumn14.Header.Caption = "Vencimiento"
      UltraGridColumn14.Header.VisiblePosition = 12
      UltraGridColumn14.Width = 80
      Appearance8.TextHAlignAsString = "Right"
      UltraGridColumn15.CellAppearance = Appearance8
      UltraGridColumn15.Format = "N2"
      UltraGridColumn15.Header.Caption = "Importe "
      UltraGridColumn15.Header.VisiblePosition = 13
      UltraGridColumn15.Width = 80
      UltraGridColumn16.Header.VisiblePosition = 14
      UltraGridColumn16.Width = 229
      Appearance9.TextHAlignAsString = "Center"
      UltraGridColumn3.CellAppearance = Appearance9
      UltraGridColumn3.Header.VisiblePosition = 2
      UltraGridColumn3.Width = 51
      Appearance10.TextHAlignAsString = "Center"
      UltraGridColumn4.CellAppearance = Appearance10
      UltraGridColumn4.Header.VisiblePosition = 0
      UltraGridColumn4.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
      UltraGridColumn4.Width = 53
      UltraGridColumn1.Header.VisiblePosition = 15
      UltraGridColumn1.Width = 440
      Appearance11.TextHAlignAsString = "Center"
      UltraGridColumn2.CellAppearance = Appearance11
      UltraGridColumn2.Header.Caption = "Importó"
      UltraGridColumn2.Header.VisiblePosition = 4
      UltraGridColumn2.Hidden = True
      UltraGridColumn2.Width = 60
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn5, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn3, UltraGridColumn4, UltraGridColumn1, UltraGridColumn2})
      Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance12.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance12
      Appearance13.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance13
      Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
      Appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance14.BackColor2 = System.Drawing.SystemColors.Control
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance14
      Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
      Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
      Appearance15.BackColor = System.Drawing.SystemColors.Window
      Appearance15.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance15
      Appearance16.BackColor = System.Drawing.SystemColors.Highlight
      Appearance16.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance16
      Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
      Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance17
      Appearance18.BorderColor = System.Drawing.Color.Silver
      Appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance18
      Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
      Appearance19.BackColor = System.Drawing.SystemColors.Control
      Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance19.BorderColor = System.Drawing.SystemColors.Window
      Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance19
      Appearance20.TextHAlignAsString = "Left"
      Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance20
      Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance21.BackColor = System.Drawing.SystemColors.Window
      Appearance21.BorderColor = System.Drawing.Color.Silver
      Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance21
      Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = CType((Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.InGroupByRows), Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)
      Appearance22.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance22
      Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugDetalle.Location = New System.Drawing.Point(3, 103)
      Me.ugDetalle.Name = "ugDetalle"
      Me.ugDetalle.Size = New System.Drawing.Size(970, 379)
      Me.ugDetalle.TabIndex = 1
      '
      'tbpConfigurar
      '
      Me.tbpConfigurar.BackColor = System.Drawing.SystemColors.Control
      Me.tbpConfigurar.Controls.Add(Me.txtFormatoFechas)
      Me.tbpConfigurar.Controls.Add(Me.lblFormatoFecha)
      Me.tbpConfigurar.Location = New System.Drawing.Point(4, 22)
      Me.tbpConfigurar.Name = "tbpConfigurar"
      Me.tbpConfigurar.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpConfigurar.Size = New System.Drawing.Size(976, 485)
      Me.tbpConfigurar.TabIndex = 1
      Me.tbpConfigurar.Text = "Configurar"
      '
      'txtFormatoFechas
      '
      Me.txtFormatoFechas.BindearPropiedadControl = ""
      Me.txtFormatoFechas.BindearPropiedadEntidad = ""
      Me.txtFormatoFechas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFormatoFechas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFormatoFechas.Formato = ""
      Me.txtFormatoFechas.IsDecimal = False
      Me.txtFormatoFechas.IsNumber = False
      Me.txtFormatoFechas.IsPK = False
      Me.txtFormatoFechas.IsRequired = False
      Me.txtFormatoFechas.Key = ""
      Me.txtFormatoFechas.LabelAsoc = Nothing
      Me.txtFormatoFechas.Location = New System.Drawing.Point(132, 29)
      Me.txtFormatoFechas.Name = "txtFormatoFechas"
      Me.txtFormatoFechas.Size = New System.Drawing.Size(127, 20)
      Me.txtFormatoFechas.TabIndex = 3
      Me.txtFormatoFechas.Text = "dd/MM/yyyy HH:mm:ss"
      '
      'lblFormatoFecha
      '
      Me.lblFormatoFecha.AutoSize = True
      Me.lblFormatoFecha.LabelAsoc = Nothing
      Me.lblFormatoFecha.Location = New System.Drawing.Point(28, 32)
      Me.lblFormatoFecha.Name = "lblFormatoFecha"
      Me.lblFormatoFecha.Size = New System.Drawing.Size(98, 13)
      Me.lblFormatoFecha.TabIndex = 2
      Me.lblFormatoFecha.Text = "Formato de Fechas"
      '
      'ImportarCtasCtesProveedores
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 562)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ImportarCtasCtesProveedores"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Importar Comprobantes con Saldos de Proveedores desde Excel"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.tbpImportar.ResumeLayout(False)
      CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tbpConfigurar.ResumeLayout(False)
      Me.tbpConfigurar.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents btnMostrar As Eniac.Controles.Button
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Friend WithEvents lblArchivo As Eniac.Controles.Label
   Friend WithEvents txtArchivoOrigen As Eniac.Controles.TextBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents lblEjemplos As Eniac.Controles.Label
   Friend WithEvents cboEstado As Eniac.Controles.ComboBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents cboAccion As Eniac.Controles.ComboBox
   Friend WithEvents lblAccion As Eniac.Controles.Label
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslTiempoActual As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslRegistroActual As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents DialogoAbrirArchivo As System.Windows.Forms.OpenFileDialog
   Friend WithEvents txtRangoCeldasColumnaHasta As Eniac.Controles.TextBox
   Friend WithEvents txtRangoCeldasFilaHasta As Eniac.Controles.TextBox
   Friend WithEvents txtRangoCeldasColumnaDesde As Eniac.Controles.TextBox
   Friend WithEvents lblRangoCeldas As Eniac.Controles.Label
   Friend WithEvents txtRangoCeldasFilaDesde As Eniac.Controles.TextBox
   Friend WithEvents lblSeparadosCeldas As Eniac.Controles.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents tbpImportar As System.Windows.Forms.TabPage
   Friend WithEvents tbpConfigurar As System.Windows.Forms.TabPage
   Friend WithEvents txtFormatoFechas As Eniac.Controles.TextBox
   Friend WithEvents lblFormatoFecha As Eniac.Controles.Label
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents tspImportando As System.Windows.Forms.ToolStripProgressBar
End Class
