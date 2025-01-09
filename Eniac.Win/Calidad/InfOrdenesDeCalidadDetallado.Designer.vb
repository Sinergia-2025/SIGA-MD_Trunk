<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfOrdenesDeCalidadDetallado
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfOrdenesDeCalidadDetallado))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionComprobante")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaControl")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaControl")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdListaControlItem")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreListaControlItem")
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NivelInspeccion")
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ValorAQL")
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoNivel")
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TamanoMuestreo")
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadAceptacion")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadRechazo")
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProveedor")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoProveedor")
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdProducto")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadControlar")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLote")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDeposito")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoDeposito")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeposito")
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUbicacion")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoUbicacion")
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreUbicacion")
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstadoCalidad")
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMRPAQLA")
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.cmbEstadosOrdenes = New Eniac.Win.ComboBoxEstadosOrdenesCalidad()
      Me.cmbUsuario = New Eniac.Controles.ComboBox()
      Me.chbUsuario = New Eniac.Controles.CheckBox()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.chbListasControlItems = New Eniac.Controles.CheckBox()
      Me.cmbListasControlItems = New Eniac.Controles.ComboBox()
      Me.chbListasControl = New Eniac.Controles.CheckBox()
      Me.cmbListasControl = New Eniac.Controles.ComboBox()
      Me.bscNombreProducto = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto = New Eniac.Controles.Buscador2()
      Me.bscCodigoProveedor = New Eniac.Controles.Buscador2()
      Me.bscNombreProveedor = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
      Me.lblTipoComprobante = New Eniac.Controles.Label()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.chbNumeroComprobante = New Eniac.Controles.CheckBox()
      Me.txtNumeroComprobante = New Eniac.Controles.TextBox()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chbProveedor = New Eniac.Controles.CheckBox()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.stsStado.SuspendLayout()
        Me.grbConsultar.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 539)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1088, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1009, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'grbConsultar
        '
        Me.grbConsultar.Controls.Add(Me.cmbEstadosOrdenes)
        Me.grbConsultar.Controls.Add(Me.cmbUsuario)
        Me.grbConsultar.Controls.Add(Me.chbUsuario)
        Me.grbConsultar.Controls.Add(Me.lblSucursal)
        Me.grbConsultar.Controls.Add(Me.cmbSucursal)
        Me.grbConsultar.Controls.Add(Me.chbListasControlItems)
        Me.grbConsultar.Controls.Add(Me.cmbListasControlItems)
        Me.grbConsultar.Controls.Add(Me.chbListasControl)
        Me.grbConsultar.Controls.Add(Me.cmbListasControl)
        Me.grbConsultar.Controls.Add(Me.bscNombreProducto)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProducto)
        Me.grbConsultar.Controls.Add(Me.bscCodigoProveedor)
        Me.grbConsultar.Controls.Add(Me.bscNombreProveedor)
        Me.grbConsultar.Controls.Add(Me.chbProducto)
        Me.grbConsultar.Controls.Add(Me.cmbTiposComprobantes)
        Me.grbConsultar.Controls.Add(Me.lblTipoComprobante)
        Me.grbConsultar.Controls.Add(Me.chbFecha)
        Me.grbConsultar.Controls.Add(Me.lblEstado)
        Me.grbConsultar.Controls.Add(Me.chbNumeroComprobante)
        Me.grbConsultar.Controls.Add(Me.txtNumeroComprobante)
        Me.grbConsultar.Controls.Add(Me.btnConsultar)
        Me.grbConsultar.Controls.Add(Me.chbProveedor)
        Me.grbConsultar.Controls.Add(Me.chkMesCompleto)
        Me.grbConsultar.Controls.Add(Me.dtpHasta)
        Me.grbConsultar.Controls.Add(Me.dtpDesde)
        Me.grbConsultar.Controls.Add(Me.lblHasta)
        Me.grbConsultar.Controls.Add(Me.lblDesde)
        Me.grbConsultar.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbConsultar.Location = New System.Drawing.Point(0, 29)
        Me.grbConsultar.Name = "grbConsultar"
        Me.grbConsultar.Size = New System.Drawing.Size(1088, 106)
        Me.grbConsultar.TabIndex = 0
        Me.grbConsultar.TabStop = False
        Me.grbConsultar.Text = "Consultar"
        '
        'cmbEstadosOrdenes
        '
        Me.cmbEstadosOrdenes.BindearPropiedadControl = Nothing
        Me.cmbEstadosOrdenes.BindearPropiedadEntidad = Nothing
        Me.cmbEstadosOrdenes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadosOrdenes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadosOrdenes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadosOrdenes.FormattingEnabled = True
        Me.cmbEstadosOrdenes.IsPK = False
        Me.cmbEstadosOrdenes.IsRequired = False
        Me.cmbEstadosOrdenes.Key = Nothing
        Me.cmbEstadosOrdenes.LabelAsoc = Nothing
        Me.cmbEstadosOrdenes.Location = New System.Drawing.Point(58, 18)
        Me.cmbEstadosOrdenes.Name = "cmbEstadosOrdenes"
        Me.cmbEstadosOrdenes.Size = New System.Drawing.Size(138, 21)
        Me.cmbEstadosOrdenes.TabIndex = 1
        '
        'cmbUsuario
        '
        Me.cmbUsuario.BindearPropiedadControl = Nothing
        Me.cmbUsuario.BindearPropiedadEntidad = Nothing
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.Enabled = False
        Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.IsPK = False
        Me.cmbUsuario.IsRequired = False
        Me.cmbUsuario.Key = Nothing
        Me.cmbUsuario.LabelAsoc = Nothing
        Me.cmbUsuario.Location = New System.Drawing.Point(951, 18)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(130, 21)
        Me.cmbUsuario.TabIndex = 11
        '
        'chbUsuario
        '
        Me.chbUsuario.AutoSize = True
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Location = New System.Drawing.Point(883, 20)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 10
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(202, 22)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 2
        Me.lblSucursal.Text = "Sucursal"
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
        Me.cmbSucursal.Location = New System.Drawing.Point(256, 18)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(143, 21)
        Me.cmbSucursal.TabIndex = 3
        '
        'chbListasControlItems
        '
        Me.chbListasControlItems.AutoSize = True
        Me.chbListasControlItems.BindearPropiedadControl = Nothing
        Me.chbListasControlItems.BindearPropiedadEntidad = Nothing
        Me.chbListasControlItems.Enabled = False
        Me.chbListasControlItems.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListasControlItems.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListasControlItems.IsPK = False
        Me.chbListasControlItems.IsRequired = False
        Me.chbListasControlItems.Key = Nothing
        Me.chbListasControlItems.LabelAsoc = Nothing
        Me.chbListasControlItems.Location = New System.Drawing.Point(711, 80)
        Me.chbListasControlItems.Name = "chbListasControlItems"
        Me.chbListasControlItems.Size = New System.Drawing.Size(102, 17)
        Me.chbListasControlItems.TabIndex = 24
        Me.chbListasControlItems.Text = "Items de Control"
        Me.chbListasControlItems.UseVisualStyleBackColor = True
        '
        'cmbListasControlItems
        '
        Me.cmbListasControlItems.BindearPropiedadControl = Nothing
        Me.cmbListasControlItems.BindearPropiedadEntidad = Nothing
        Me.cmbListasControlItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListasControlItems.Enabled = False
        Me.cmbListasControlItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListasControlItems.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListasControlItems.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListasControlItems.FormattingEnabled = True
        Me.cmbListasControlItems.IsPK = False
        Me.cmbListasControlItems.IsRequired = False
        Me.cmbListasControlItems.Key = Nothing
        Me.cmbListasControlItems.LabelAsoc = Nothing
        Me.cmbListasControlItems.Location = New System.Drawing.Point(813, 77)
        Me.cmbListasControlItems.Name = "cmbListasControlItems"
        Me.cmbListasControlItems.Size = New System.Drawing.Size(130, 21)
        Me.cmbListasControlItems.TabIndex = 25
        '
        'chbListasControl
        '
        Me.chbListasControl.AutoSize = True
        Me.chbListasControl.BindearPropiedadControl = Nothing
        Me.chbListasControl.BindearPropiedadEntidad = Nothing
        Me.chbListasControl.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListasControl.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListasControl.IsPK = False
        Me.chbListasControl.IsRequired = False
        Me.chbListasControl.Key = Nothing
        Me.chbListasControl.LabelAsoc = Nothing
        Me.chbListasControl.Location = New System.Drawing.Point(468, 79)
        Me.chbListasControl.Name = "chbListasControl"
        Me.chbListasControl.Size = New System.Drawing.Size(99, 17)
        Me.chbListasControl.TabIndex = 22
        Me.chbListasControl.Text = "Lista de Control"
        Me.chbListasControl.UseVisualStyleBackColor = True
        '
        'cmbListasControl
        '
        Me.cmbListasControl.BindearPropiedadControl = Nothing
        Me.cmbListasControl.BindearPropiedadEntidad = Nothing
        Me.cmbListasControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListasControl.Enabled = False
        Me.cmbListasControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListasControl.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListasControl.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListasControl.FormattingEnabled = True
        Me.cmbListasControl.IsPK = False
        Me.cmbListasControl.IsRequired = False
        Me.cmbListasControl.Key = Nothing
        Me.cmbListasControl.LabelAsoc = Nothing
        Me.cmbListasControl.Location = New System.Drawing.Point(572, 77)
        Me.cmbListasControl.Name = "cmbListasControl"
        Me.cmbListasControl.Size = New System.Drawing.Size(128, 21)
        Me.cmbListasControl.TabIndex = 23
        '
        'bscNombreProducto
        '
        Me.bscNombreProducto.ActivarFiltroEnGrilla = True
        Me.bscNombreProducto.BindearPropiedadControl = Nothing
        Me.bscNombreProducto.BindearPropiedadEntidad = Nothing
        Me.bscNombreProducto.ConfigBuscador = Nothing
        Me.bscNombreProducto.Datos = Nothing
        Me.bscNombreProducto.FilaDevuelta = Nothing
        Me.bscNombreProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProducto.IsDecimal = False
        Me.bscNombreProducto.IsNumber = False
        Me.bscNombreProducto.IsPK = False
        Me.bscNombreProducto.IsRequired = False
        Me.bscNombreProducto.Key = ""
        Me.bscNombreProducto.LabelAsoc = Nothing
        Me.bscNombreProducto.Location = New System.Drawing.Point(187, 77)
        Me.bscNombreProducto.MaxLengh = "32767"
        Me.bscNombreProducto.Name = "bscNombreProducto"
        Me.bscNombreProducto.Permitido = False
        Me.bscNombreProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProducto.Selecciono = False
        Me.bscNombreProducto.Size = New System.Drawing.Size(274, 20)
        Me.bscNombreProducto.TabIndex = 21
        '
        'bscCodigoProducto
        '
        Me.bscCodigoProducto.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto.ConfigBuscador = Nothing
        Me.bscCodigoProducto.Datos = Nothing
        Me.bscCodigoProducto.FilaDevuelta = Nothing
        Me.bscCodigoProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto.IsDecimal = False
        Me.bscCodigoProducto.IsNumber = False
        Me.bscCodigoProducto.IsPK = False
        Me.bscCodigoProducto.IsRequired = False
        Me.bscCodigoProducto.Key = ""
        Me.bscCodigoProducto.LabelAsoc = Nothing
        Me.bscCodigoProducto.Location = New System.Drawing.Point(90, 77)
        Me.bscCodigoProducto.MaxLengh = "32767"
        Me.bscCodigoProducto.Name = "bscCodigoProducto"
        Me.bscCodigoProducto.Permitido = False
        Me.bscCodigoProducto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto.Selecciono = False
        Me.bscCodigoProducto.Size = New System.Drawing.Size(90, 20)
        Me.bscCodigoProducto.TabIndex = 20
        '
        'bscCodigoProveedor
        '
        Me.bscCodigoProveedor.ActivarFiltroEnGrilla = True
        Me.bscCodigoProveedor.BindearPropiedadControl = Nothing
        Me.bscCodigoProveedor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProveedor.ConfigBuscador = Nothing
        Me.bscCodigoProveedor.Datos = Nothing
        Me.bscCodigoProveedor.FilaDevuelta = Nothing
        Me.bscCodigoProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProveedor.IsDecimal = False
        Me.bscCodigoProveedor.IsNumber = False
        Me.bscCodigoProveedor.IsPK = False
        Me.bscCodigoProveedor.IsRequired = False
        Me.bscCodigoProveedor.Key = ""
        Me.bscCodigoProveedor.LabelAsoc = Nothing
        Me.bscCodigoProveedor.Location = New System.Drawing.Point(90, 46)
        Me.bscCodigoProveedor.MaxLengh = "32767"
        Me.bscCodigoProveedor.Name = "bscCodigoProveedor"
        Me.bscCodigoProveedor.Permitido = False
        Me.bscCodigoProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProveedor.Selecciono = False
        Me.bscCodigoProveedor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoProveedor.TabIndex = 13
        '
        'bscNombreProveedor
        '
        Me.bscNombreProveedor.ActivarFiltroEnGrilla = True
        Me.bscNombreProveedor.AutoSize = True
        Me.bscNombreProveedor.BindearPropiedadControl = Nothing
        Me.bscNombreProveedor.BindearPropiedadEntidad = Nothing
        Me.bscNombreProveedor.ConfigBuscador = Nothing
        Me.bscNombreProveedor.Datos = Nothing
        Me.bscNombreProveedor.FilaDevuelta = Nothing
        Me.bscNombreProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreProveedor.IsDecimal = False
        Me.bscNombreProveedor.IsNumber = False
        Me.bscNombreProveedor.IsPK = False
        Me.bscNombreProveedor.IsRequired = False
        Me.bscNombreProveedor.Key = ""
        Me.bscNombreProveedor.LabelAsoc = Nothing
        Me.bscNombreProveedor.Location = New System.Drawing.Point(187, 46)
        Me.bscNombreProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreProveedor.MaxLengh = "32767"
        Me.bscNombreProveedor.Name = "bscNombreProveedor"
        Me.bscNombreProveedor.Permitido = False
        Me.bscNombreProveedor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreProveedor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreProveedor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreProveedor.Selecciono = False
        Me.bscNombreProveedor.Size = New System.Drawing.Size(274, 23)
        Me.bscNombreProveedor.TabIndex = 14
        '
        'chbProducto
        '
        Me.chbProducto.AutoSize = True
        Me.chbProducto.BindearPropiedadControl = Nothing
        Me.chbProducto.BindearPropiedadEntidad = Nothing
        Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProducto.IsPK = False
        Me.chbProducto.IsRequired = False
        Me.chbProducto.Key = Nothing
        Me.chbProducto.LabelAsoc = Nothing
        Me.chbProducto.Location = New System.Drawing.Point(15, 77)
        Me.chbProducto.Name = "chbProducto"
        Me.chbProducto.Size = New System.Drawing.Size(69, 17)
        Me.chbProducto.TabIndex = 19
        Me.chbProducto.Text = "Producto"
        Me.chbProducto.UseVisualStyleBackColor = True
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
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(550, 46)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
        Me.cmbTiposComprobantes.TabIndex = 16
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.LabelAsoc = Nothing
        Me.lblTipoComprobante.Location = New System.Drawing.Point(468, 49)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(76, 13)
        Me.lblTipoComprobante.TabIndex = 15
        Me.lblTipoComprobante.Text = "Tipo Comprob."
        '
        'chbFecha
        '
        Me.chbFecha.AutoSize = True
        Me.chbFecha.BindearPropiedadControl = Nothing
        Me.chbFecha.BindearPropiedadEntidad = Nothing
        Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFecha.IsPK = False
        Me.chbFecha.IsRequired = False
        Me.chbFecha.Key = Nothing
        Me.chbFecha.LabelAsoc = Nothing
        Me.chbFecha.Location = New System.Drawing.Point(405, 20)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(56, 17)
        Me.chbFecha.TabIndex = 4
        Me.chbFecha.Text = "Fecha"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(12, 22)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Estado"
        '
        'chbNumeroComprobante
        '
        Me.chbNumeroComprobante.AutoSize = True
        Me.chbNumeroComprobante.BindearPropiedadControl = Nothing
        Me.chbNumeroComprobante.BindearPropiedadEntidad = Nothing
        Me.chbNumeroComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumeroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumeroComprobante.IsPK = False
        Me.chbNumeroComprobante.IsRequired = False
        Me.chbNumeroComprobante.Key = Nothing
        Me.chbNumeroComprobante.LabelAsoc = Nothing
        Me.chbNumeroComprobante.Location = New System.Drawing.Point(690, 49)
        Me.chbNumeroComprobante.Name = "chbNumeroComprobante"
        Me.chbNumeroComprobante.Size = New System.Drawing.Size(63, 17)
        Me.chbNumeroComprobante.TabIndex = 17
        Me.chbNumeroComprobante.Text = "Número"
        Me.chbNumeroComprobante.UseVisualStyleBackColor = True
        '
        'txtNumeroComprobante
        '
        Me.txtNumeroComprobante.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumeroComprobante.BindearPropiedadControl = Nothing
        Me.txtNumeroComprobante.BindearPropiedadEntidad = Nothing
        Me.txtNumeroComprobante.Enabled = False
        Me.txtNumeroComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroComprobante.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroComprobante.Formato = ""
        Me.txtNumeroComprobante.IsDecimal = False
        Me.txtNumeroComprobante.IsNumber = True
        Me.txtNumeroComprobante.IsPK = False
        Me.txtNumeroComprobante.IsRequired = False
        Me.txtNumeroComprobante.Key = ""
        Me.txtNumeroComprobante.LabelAsoc = Nothing
        Me.txtNumeroComprobante.Location = New System.Drawing.Point(759, 47)
        Me.txtNumeroComprobante.MaxLength = 8
        Me.txtNumeroComprobante.Name = "txtNumeroComprobante"
        Me.txtNumeroComprobante.Size = New System.Drawing.Size(65, 20)
        Me.txtNumeroComprobante.TabIndex = 18
        Me.txtNumeroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(971, 71)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 32)
        Me.btnConsultar.TabIndex = 26
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chbProveedor
        '
        Me.chbProveedor.AutoSize = True
        Me.chbProveedor.BindearPropiedadControl = Nothing
        Me.chbProveedor.BindearPropiedadEntidad = Nothing
        Me.chbProveedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProveedor.IsPK = False
        Me.chbProveedor.IsRequired = False
        Me.chbProveedor.Key = Nothing
        Me.chbProveedor.LabelAsoc = Nothing
        Me.chbProveedor.Location = New System.Drawing.Point(15, 49)
        Me.chbProveedor.Name = "chbProveedor"
        Me.chbProveedor.Size = New System.Drawing.Size(75, 17)
        Me.chbProveedor.TabIndex = 12
        Me.chbProveedor.Text = "Proveedor"
        Me.chbProveedor.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.Enabled = False
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(467, 20)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(59, 17)
        Me.chkMesCompleto.TabIndex = 5
        Me.chkMesCompleto.Text = "Mes C."
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.Enabled = False
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(749, 18)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(128, 20)
        Me.dtpHasta.TabIndex = 9
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(708, 21)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 8
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.Enabled = False
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(573, 18)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(129, 20)
        Me.dtpDesde.TabIndex = 7
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(529, 21)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 6
        Me.lblDesde.Text = "Desde"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.toolStripSeparator3, Me.tsddExportar, Me.ToolStripSeparator2, Me.tsbPreferencias, Me.tsbSalir, Me.ToolStripSeparator4})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1088, 29)
        Me.tstBarra.TabIndex = 3
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
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Suc"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 30
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Hidden = True
        UltraGridColumn2.Width = 149
        Appearance3.TextHAlignAsString = "Left"
        Appearance3.TextVAlignAsString = "Middle"
        UltraGridColumn3.CellAppearance = Appearance3
        UltraGridColumn3.Header.Caption = "Tipo Comprobante"
        UltraGridColumn3.Header.VisiblePosition = 2
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        UltraGridColumn4.CellAppearance = Appearance4
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 40
        Appearance5.TextHAlignAsString = "Right"
        Appearance5.TextVAlignAsString = "Middle"
        UltraGridColumn7.CellAppearance = Appearance5
        UltraGridColumn7.Header.Caption = "Emisor"
        UltraGridColumn7.Header.VisiblePosition = 4
        UltraGridColumn7.Width = 50
        Appearance6.TextHAlignAsString = "Right"
        Appearance6.TextVAlignAsString = "Middle"
        UltraGridColumn8.CellAppearance = Appearance6
        UltraGridColumn8.Header.Caption = "Numero Comprobante"
        UltraGridColumn8.Header.VisiblePosition = 5
        Appearance7.TextHAlignAsString = "Center"
        Appearance7.TextVAlignAsString = "Middle"
        UltraGridColumn9.CellAppearance = Appearance7
        UltraGridColumn9.Header.VisiblePosition = 6
        UltraGridColumn22.Header.VisiblePosition = 8
        UltraGridColumn22.Hidden = True
        Appearance8.TextHAlignAsString = "Left"
        Appearance8.TextVAlignAsString = "Middle"
        UltraGridColumn23.CellAppearance = Appearance8
        UltraGridColumn23.Header.Caption = "Nombre Lista Control"
        UltraGridColumn23.Header.VisiblePosition = 9
        UltraGridColumn24.Header.VisiblePosition = 10
        UltraGridColumn24.Hidden = True
        Appearance9.TextHAlignAsString = "Left"
        Appearance9.TextVAlignAsString = "Middle"
        UltraGridColumn25.CellAppearance = Appearance9
        UltraGridColumn25.Header.Caption = "Nombre Lista Control Item"
        UltraGridColumn25.Header.VisiblePosition = 11
        Appearance10.TextHAlignAsString = "Left"
        Appearance10.TextVAlignAsString = "Middle"
        UltraGridColumn26.CellAppearance = Appearance10
        UltraGridColumn26.Header.Caption = "Nivel Inspeccion"
        UltraGridColumn26.Header.VisiblePosition = 12
        Appearance11.TextHAlignAsString = "Right"
        Appearance11.TextVAlignAsString = "Middle"
        UltraGridColumn27.CellAppearance = Appearance11
        UltraGridColumn27.Header.Caption = "Valor AQL"
        UltraGridColumn27.Header.VisiblePosition = 13
        UltraGridColumn27.Width = 71
        Appearance12.TextHAlignAsString = "Left"
        Appearance12.TextVAlignAsString = "Middle"
        UltraGridColumn28.CellAppearance = Appearance12
        UltraGridColumn28.Header.Caption = "Codigo Nivel"
        UltraGridColumn28.Header.VisiblePosition = 14
        Appearance13.TextHAlignAsString = "Right"
        Appearance13.TextVAlignAsString = "Middle"
        UltraGridColumn29.CellAppearance = Appearance13
        UltraGridColumn29.Header.Caption = "Tamano Muestreo"
        UltraGridColumn29.Header.VisiblePosition = 15
        Appearance14.TextHAlignAsString = "Right"
        Appearance14.TextVAlignAsString = "Middle"
        UltraGridColumn30.CellAppearance = Appearance14
        UltraGridColumn30.Header.Caption = "Cantidad Aceptacion"
        UltraGridColumn30.Header.VisiblePosition = 16
        Appearance15.TextHAlignAsString = "Right"
        Appearance15.TextVAlignAsString = "Middle"
        UltraGridColumn31.CellAppearance = Appearance15
        UltraGridColumn31.Header.Caption = "Cantidad Rechazo"
        UltraGridColumn31.Header.VisiblePosition = 17
        UltraGridColumn10.Header.VisiblePosition = 18
        UltraGridColumn10.Hidden = True
        Appearance16.TextHAlignAsString = "Right"
        Appearance16.TextVAlignAsString = "Middle"
        UltraGridColumn5.CellAppearance = Appearance16
        UltraGridColumn5.Header.Caption = "Codigo Proveedor"
        UltraGridColumn5.Header.VisiblePosition = 20
        Appearance17.TextHAlignAsString = "Left"
        Appearance17.TextVAlignAsString = "Middle"
        UltraGridColumn11.CellAppearance = Appearance17
        UltraGridColumn11.Header.Caption = "Proveedor"
        UltraGridColumn11.Header.VisiblePosition = 21
        UltraGridColumn11.Width = 183
        UltraGridColumn12.Header.Caption = "Código Producto"
        UltraGridColumn12.Header.VisiblePosition = 22
        UltraGridColumn12.Hidden = True
        UltraGridColumn12.Width = 100
        Appearance18.TextHAlignAsString = "Left"
        Appearance18.TextVAlignAsString = "Middle"
        UltraGridColumn13.CellAppearance = Appearance18
        UltraGridColumn13.Header.Caption = "Producto"
        UltraGridColumn13.Header.VisiblePosition = 23
        UltraGridColumn13.Width = 200
        Appearance19.TextHAlignAsString = "Right"
        Appearance19.TextVAlignAsString = "Middle"
        UltraGridColumn14.CellAppearance = Appearance19
        UltraGridColumn14.Header.Caption = "Cantidad"
        UltraGridColumn14.Header.VisiblePosition = 7
        Appearance20.TextHAlignAsString = "Right"
        Appearance20.TextVAlignAsString = "Middle"
        UltraGridColumn16.CellAppearance = Appearance20
        UltraGridColumn16.Header.Caption = "Lote"
        UltraGridColumn16.Header.VisiblePosition = 24
        UltraGridColumn16.Width = 94
        UltraGridColumn17.Header.VisiblePosition = 25
        UltraGridColumn17.Hidden = True
        Appearance21.TextHAlignAsString = "Left"
        Appearance21.TextVAlignAsString = "Middle"
        UltraGridColumn6.CellAppearance = Appearance21
        UltraGridColumn6.Header.Caption = "Codigo Deposito"
        UltraGridColumn6.Header.VisiblePosition = 26
        UltraGridColumn6.Width = 96
        Appearance22.TextHAlignAsString = "Left"
        Appearance22.TextVAlignAsString = "Middle"
        UltraGridColumn18.CellAppearance = Appearance22
        UltraGridColumn18.Header.Caption = "Depósito"
        UltraGridColumn18.Header.VisiblePosition = 27
        UltraGridColumn18.Width = 137
        UltraGridColumn19.Header.VisiblePosition = 28
        UltraGridColumn19.Hidden = True
        Appearance23.TextHAlignAsString = "Left"
        Appearance23.TextVAlignAsString = "Middle"
        UltraGridColumn15.CellAppearance = Appearance23
        UltraGridColumn15.Header.Caption = "Codigo Ubicacion"
        UltraGridColumn15.Header.VisiblePosition = 29
        UltraGridColumn15.Width = 100
        Appearance24.TextHAlignAsString = "Left"
        Appearance24.TextVAlignAsString = "Middle"
        UltraGridColumn20.CellAppearance = Appearance24
        UltraGridColumn20.Header.Caption = "Ubicación"
        UltraGridColumn20.Header.VisiblePosition = 30
        UltraGridColumn20.Width = 112
        Appearance25.TextHAlignAsString = "Left"
        Appearance25.TextVAlignAsString = "Middle"
        UltraGridColumn21.CellAppearance = Appearance25
        UltraGridColumn21.Header.Caption = "Estado Calidad"
        UltraGridColumn21.Header.VisiblePosition = 19
        UltraGridColumn21.Width = 112
        UltraGridColumn32.Header.VisiblePosition = 31
        UltraGridColumn32.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn10, UltraGridColumn5, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn16, UltraGridColumn17, UltraGridColumn6, UltraGridColumn18, UltraGridColumn19, UltraGridColumn15, UltraGridColumn20, UltraGridColumn21, UltraGridColumn32})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance26
        Appearance27.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance28.BackColor2 = System.Drawing.SystemColors.Control
        Appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance28.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance28
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance29.BackColor = System.Drawing.SystemColors.Window
        Appearance29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance29
        Appearance30.BackColor = System.Drawing.SystemColors.Highlight
        Appearance30.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance30
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance31.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance31
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Appearance32.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance33.BackColor = System.Drawing.SystemColors.Control
        Appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance33.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance33.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance33
        Appearance34.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance34
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance35.BackColor = System.Drawing.SystemColors.Window
        Appearance35.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance35
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance36.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance36
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 135)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1088, 404)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'InfOrdenesDeCalidadDetallado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 561)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.grbConsultar)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "InfOrdenesDeCalidadDetallado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe Detallado de Ordenes de Calidad"
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grbConsultar.ResumeLayout(False)
        Me.grbConsultar.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents tssRegistros As ToolStripStatusLabel
    Protected Friend WithEvents stsStado As StatusStrip
   Protected Friend WithEvents tssInfo As ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As ToolStripProgressBar
   Friend WithEvents grbConsultar As GroupBox
   Friend WithEvents bscNombreProducto As Controles.Buscador2
   Friend WithEvents bscCodigoProducto As Controles.Buscador2
   Friend WithEvents bscCodigoProveedor As Controles.Buscador2
   Friend WithEvents bscNombreProveedor As Controles.Buscador2
   Friend WithEvents chbProducto As Controles.CheckBox
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
   Friend WithEvents lblTipoComprobante As Controles.Label
   Friend WithEvents chbFecha As Controles.CheckBox
   Friend WithEvents lblEstado As Controles.Label
   Friend WithEvents chbNumeroComprobante As Controles.CheckBox
   Friend WithEvents txtNumeroComprobante As Controles.TextBox
    Friend WithEvents chbUsuario As Controles.CheckBox
    Friend WithEvents cmbUsuario As Controles.ComboBox
   Friend WithEvents btnConsultar As Controles.Button
   Friend WithEvents chbProveedor As Controles.CheckBox
   Friend WithEvents chkMesCompleto As Controles.CheckBox
   Friend WithEvents dtpHasta As Controles.DateTimePicker
   Friend WithEvents lblHasta As Controles.Label
   Friend WithEvents dtpDesde As Controles.DateTimePicker
   Friend WithEvents lblDesde As Controles.Label
   Public WithEvents tstBarra As ToolStrip
   Public WithEvents tsbRefrescar As ToolStripButton
   Private WithEvents ToolStripSeparator1 As ToolStripSeparator
   Friend WithEvents tsbImprimir As ToolStripButton
   Private WithEvents toolStripSeparator3 As ToolStripSeparator
   Friend WithEvents tsddExportar As ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As ToolStripMenuItem
   Friend WithEvents tsmiAPDF As ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
   Public WithEvents tsbPreferencias As ToolStripButton
   Public WithEvents tsbSalir As ToolStripButton
   Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
   Friend WithEvents UltraGridDocumentExporter1 As DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraGridExcelExporter1 As ExcelExport.UltraGridExcelExporter
   Friend WithEvents chbListasControl As Controles.CheckBox
   Friend WithEvents cmbListasControl As Controles.ComboBox
   Friend WithEvents chbListasControlItems As Controles.CheckBox
   Friend WithEvents cmbListasControlItems As Controles.ComboBox
    Friend WithEvents lblSucursal As Controles.Label
    Friend WithEvents cmbSucursal As ComboBoxSucursales
    Friend WithEvents ugDetalle As UltraGridSiga
    Friend WithEvents cmbEstadosOrdenes As ComboBoxEstadosOrdenesCalidad
End Class
