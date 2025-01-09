<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CRMNovedadesABM
    Inherits BaseABM2

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
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("", -1)
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grpFiltros = New Eniac.Controles.GroupBox()
      Me.pnlFiltrosInterno = New Eniac.Controles.Panel()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.gbProyecto = New Eniac.Controles.GroupBox()
      Me.nudPrioridadHasta = New System.Windows.Forms.NumericUpDown()
      Me.nudPrioridadDesde = New System.Windows.Forms.NumericUpDown()
      Me.cmbClasificacionProyecto = New Eniac.Controles.ComboBox()
      Me.chbClasificacionProyecto = New Eniac.Controles.CheckBox()
      Me.chbEstadoProyecto = New Eniac.Controles.CheckBox()
      Me.bscCodigoProyecto = New Eniac.Controles.Buscador2()
      Me.cmbEstadoProyecto = New Eniac.Controles.ComboBox()
      Me.chbPrioridadProyecto = New Eniac.Controles.CheckBox()
      Me.bscProyecto = New Eniac.Controles.Buscador2()
      Me.chbProyecto = New Eniac.Controles.CheckBox()
      Me.pnlServicioTecnico = New Eniac.Controles.Panel()
      Me.lblEnGarantia = New Eniac.Controles.Label()
      Me.lblConPrestamo = New Eniac.Controles.Label()
      Me.lblEstadoPrestamo = New Eniac.Controles.Label()
      Me.chbSucursal = New Eniac.Controles.CheckBox()
      Me.cmbEstadoPrestamo = New Eniac.Controles.ComboBox()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.cmbConPrestamo = New Eniac.Controles.ComboBox()
      Me.cmbEnGarantia = New Eniac.Controles.ComboBox()
      Me.pnlAplicacion = New Eniac.Controles.Panel()
      Me.cmbAplicacion = New Eniac.Controles.ComboBox()
      Me.chbAplicacion = New Eniac.Controles.CheckBox()
      Me.cmbVersion = New Eniac.Controles.ComboBox()
      Me.chbVersion = New Eniac.Controles.CheckBox()
      Me.pnlVehiculo = New Eniac.Controles.Panel()
      Me.bscCodigoVehiculo = New Eniac.Controles.Buscador2()
      Me.chbVehiculo = New Eniac.Controles.CheckBox()
      Me.pnlFIltrosEstandares = New Eniac.Controles.Panel()
      Me.cmbCRMMetodos = New Eniac.Win.ComboBoxCRMMetodos()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbCRMMedios = New Eniac.Win.ComboBoxCRMMediosComunicacionNovedades()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.cmbCRMEstados = New Eniac.Win.ComboBoxCRMEstadoNovedades()
      Me.lblPriorizado = New Eniac.Controles.Label()
      Me.cmbCategoriasNovedad = New Eniac.Win.ComboBoxCRMCategorias()
      Me.cmbUsuarioAsignado = New Eniac.Controles.ComboBox()
      Me.chbUsuarioAsignado = New Eniac.Controles.CheckBox()
      Me.chbCategoriaReporta = New Eniac.Controles.CheckBox()
      Me.chbNumeroPadre = New Eniac.Controles.CheckBox()
      Me.lblFechaAltaDesde = New Eniac.Controles.Label()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.txtNumeroPadre = New Eniac.Controles.TextBox()
      Me.cmbCategoriaReporta = New Eniac.Controles.ComboBox()
      Me.lblFechaAltaHasta = New Eniac.Controles.Label()
      Me.chbTipoUsuario = New Eniac.Controles.CheckBox()
      Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
      Me.cmbTipoUsuario = New Eniac.Controles.ComboBox()
      Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.chbUsuarioAlta = New Eniac.Controles.CheckBox()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.cmbUsuarioAlta = New Eniac.Controles.ComboBox()
      Me.cmbRevisionAdministrativa = New Eniac.Controles.ComboBox()
      Me.lblRevisionAdministrativa = New Eniac.Controles.Label()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.lblFinalizado = New Eniac.Controles.Label()
      Me.cmbFinalizado = New Eniac.Controles.ComboBox()
      Me.chbFuncionNuevo = New Eniac.Controles.CheckBox()
      Me.cmbPriorizado = New Eniac.Controles.ComboBox()
      Me.lblPriodizado = New Eniac.Controles.Label()
      Me.bscFuncionNuevo = New Eniac.Controles.Buscador2()
      Me.bscCodigoFuncionNuevo = New Eniac.Controles.Buscador2()
      Me.cmbTipoFechaFiltro = New Eniac.Controles.ComboBox()
      Me.cmbPrioridad = New Eniac.Controles.ComboBox()
      Me.chbPrioridad = New Eniac.Controles.CheckBox()
      Me.btnConsultar = New Eniac.Win.ButtonConsultar()
      Me.gridContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.GridContextMenuManager1 = New Eniac.Win.GridContextMenuManager()
      Me.FiltersManager1 = New Eniac.Win.FilterManager.FilterManager(Me.components)
      Me.splitter1 = New Infragistics.Win.Misc.UltraSplitter()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.Label2 = New Eniac.Controles.Label()
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpFiltros.SuspendLayout()
      Me.pnlFiltrosInterno.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.gbProyecto.SuspendLayout()
      CType(Me.nudPrioridadHasta, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudPrioridadDesde, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlServicioTecnico.SuspendLayout()
      Me.pnlAplicacion.SuspendLayout()
      Me.pnlVehiculo.SuspendLayout()
      Me.pnlFIltrosEstandares.SuspendLayout()
      Me.SuspendLayout()
      '
      'dgvDatos
      '
      Me.dgvDatos.ContextMenuStrip = Me.gridContextMenuStrip
      UltraGridBand1.ColHeaderLines = 2
      UltraGridBand1.Header.FixOnRight = Infragistics.Win.DefaultableBoolean.[True]
      UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
      Me.dgvDatos.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.dgvDatos.DisplayLayout.GroupByBox.Prompt = "Arrastre un titulo de columna aquí para agrupar."
      Me.dgvDatos.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvDatos.DisplayLayout.MaxRowScrollRegions = 1
      Appearance1.BackColor = System.Drawing.SystemColors.Highlight
      Appearance1.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvDatos.DisplayLayout.Override.ActiveRowAppearance = Appearance1
      Me.dgvDatos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
      Me.dgvDatos.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
      Appearance2.BorderColor = System.Drawing.Color.Silver
      Me.dgvDatos.DisplayLayout.Override.CellAppearance = Appearance2
      Me.dgvDatos.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Appearance3.ForeColor = System.Drawing.Color.Gray
      Me.dgvDatos.DisplayLayout.Override.FixedHeaderAppearance = Appearance3
      Appearance4.ForeColor = System.Drawing.Color.ForestGreen
      Me.dgvDatos.DisplayLayout.Override.HeaderAppearance = Appearance4
      Me.dgvDatos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Appearance5.ForeColor = System.Drawing.Color.Gray
      Me.dgvDatos.DisplayLayout.Override.HotTrackHeaderAppearance = Appearance5
      Appearance6.BorderColor = System.Drawing.Color.Silver
      Me.dgvDatos.DisplayLayout.Override.RowAppearance = Appearance6
      Appearance7.ForeColor = System.Drawing.Color.Gray
      Me.dgvDatos.DisplayLayout.Override.RowSelectorHeaderAppearance = Appearance7
      Me.dgvDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
      Me.dgvDatos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None
      Me.dgvDatos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
      Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dgvDatos.Location = New System.Drawing.Point(0, 249)
      Me.dgvDatos.Size = New System.Drawing.Size(1084, 290)
      Me.dgvDatos.TabIndex = 1
      '
      'grpFiltros
      '
      Me.grpFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.grpFiltros.Controls.Add(Me.pnlFiltrosInterno)
      Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
      Me.grpFiltros.Name = "grpFiltros"
      Me.grpFiltros.Padding = New System.Windows.Forms.Padding(3, 3, 3, 0)
      Me.grpFiltros.Size = New System.Drawing.Size(1084, 205)
      Me.grpFiltros.TabIndex = 0
      Me.grpFiltros.TabStop = False
      Me.grpFiltros.Text = "Filtros"
      '
      'pnlFiltrosInterno
      '
      Me.pnlFiltrosInterno.AutoSize = True
      Me.pnlFiltrosInterno.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlFiltrosInterno.Controls.Add(Me.TableLayoutPanel1)
      Me.pnlFiltrosInterno.Controls.Add(Me.pnlFIltrosEstandares)
      Me.pnlFiltrosInterno.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pnlFiltrosInterno.Location = New System.Drawing.Point(3, 16)
      Me.pnlFiltrosInterno.Name = "pnlFiltrosInterno"
      Me.pnlFiltrosInterno.Size = New System.Drawing.Size(1078, 189)
      Me.pnlFiltrosInterno.TabIndex = 0
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.AutoSize = True
      Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
      Me.TableLayoutPanel1.Controls.Add(Me.gbProyecto, 0, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.pnlServicioTecnico, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.pnlAplicacion, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.pnlVehiculo, 1, 0)
      Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 100)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 3
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(1078, 89)
      Me.TableLayoutPanel1.TabIndex = 56
      '
      'gbProyecto
      '
      Me.gbProyecto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.TableLayoutPanel1.SetColumnSpan(Me.gbProyecto, 2)
      Me.gbProyecto.Controls.Add(Me.nudPrioridadHasta)
      Me.gbProyecto.Controls.Add(Me.nudPrioridadDesde)
      Me.gbProyecto.Controls.Add(Me.cmbClasificacionProyecto)
      Me.gbProyecto.Controls.Add(Me.chbClasificacionProyecto)
      Me.gbProyecto.Controls.Add(Me.chbEstadoProyecto)
      Me.gbProyecto.Controls.Add(Me.bscCodigoProyecto)
      Me.gbProyecto.Controls.Add(Me.cmbEstadoProyecto)
      Me.gbProyecto.Controls.Add(Me.chbPrioridadProyecto)
      Me.gbProyecto.Controls.Add(Me.bscProyecto)
      Me.gbProyecto.Controls.Add(Me.chbProyecto)
      Me.gbProyecto.Location = New System.Drawing.Point(0, 54)
      Me.gbProyecto.Margin = New System.Windows.Forms.Padding(0)
      Me.gbProyecto.Name = "gbProyecto"
      Me.gbProyecto.Size = New System.Drawing.Size(948, 35)
      Me.gbProyecto.TabIndex = 51
      Me.gbProyecto.TabStop = False
      Me.gbProyecto.Text = "Proyecto"
      Me.gbProyecto.Visible = False
      '
      'nudPrioridadHasta
      '
      Me.nudPrioridadHasta.Enabled = False
      Me.nudPrioridadHasta.Location = New System.Drawing.Point(560, 13)
      Me.nudPrioridadHasta.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.nudPrioridadHasta.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudPrioridadHasta.Name = "nudPrioridadHasta"
      Me.nudPrioridadHasta.ReadOnly = True
      Me.nudPrioridadHasta.Size = New System.Drawing.Size(51, 20)
      Me.nudPrioridadHasta.TabIndex = 9
      Me.nudPrioridadHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudPrioridadHasta.Value = New Decimal(New Integer() {5, 0, 0, 0})
      '
      'nudPrioridadDesde
      '
      Me.nudPrioridadDesde.Enabled = False
      Me.nudPrioridadDesde.Location = New System.Drawing.Point(504, 13)
      Me.nudPrioridadDesde.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.nudPrioridadDesde.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudPrioridadDesde.Name = "nudPrioridadDesde"
      Me.nudPrioridadDesde.ReadOnly = True
      Me.nudPrioridadDesde.Size = New System.Drawing.Size(51, 20)
      Me.nudPrioridadDesde.TabIndex = 7
      Me.nudPrioridadDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudPrioridadDesde.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'cmbClasificacionProyecto
      '
      Me.cmbClasificacionProyecto.BindearPropiedadControl = "SelectedValue"
      Me.cmbClasificacionProyecto.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
      Me.cmbClasificacionProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbClasificacionProyecto.Enabled = False
      Me.cmbClasificacionProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbClasificacionProyecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbClasificacionProyecto.FormattingEnabled = True
      Me.cmbClasificacionProyecto.IsPK = False
      Me.cmbClasificacionProyecto.IsRequired = False
      Me.cmbClasificacionProyecto.Key = Nothing
      Me.cmbClasificacionProyecto.LabelAsoc = Me.chbClasificacionProyecto
      Me.cmbClasificacionProyecto.Location = New System.Drawing.Point(855, 12)
      Me.cmbClasificacionProyecto.Name = "cmbClasificacionProyecto"
      Me.cmbClasificacionProyecto.Size = New System.Drawing.Size(88, 21)
      Me.cmbClasificacionProyecto.TabIndex = 13
      '
      'chbClasificacionProyecto
      '
      Me.chbClasificacionProyecto.AutoSize = True
      Me.chbClasificacionProyecto.BindearPropiedadControl = Nothing
      Me.chbClasificacionProyecto.BindearPropiedadEntidad = Nothing
      Me.chbClasificacionProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbClasificacionProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbClasificacionProyecto.IsPK = False
      Me.chbClasificacionProyecto.IsRequired = False
      Me.chbClasificacionProyecto.Key = Nothing
      Me.chbClasificacionProyecto.LabelAsoc = Nothing
      Me.chbClasificacionProyecto.Location = New System.Drawing.Point(765, 14)
      Me.chbClasificacionProyecto.Name = "chbClasificacionProyecto"
      Me.chbClasificacionProyecto.Size = New System.Drawing.Size(85, 17)
      Me.chbClasificacionProyecto.TabIndex = 12
      Me.chbClasificacionProyecto.Text = "Clasificación"
      Me.chbClasificacionProyecto.UseVisualStyleBackColor = True
      '
      'chbEstadoProyecto
      '
      Me.chbEstadoProyecto.AutoSize = True
      Me.chbEstadoProyecto.BindearPropiedadControl = Nothing
      Me.chbEstadoProyecto.BindearPropiedadEntidad = Nothing
      Me.chbEstadoProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEstadoProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEstadoProyecto.IsPK = False
      Me.chbEstadoProyecto.IsRequired = False
      Me.chbEstadoProyecto.Key = Nothing
      Me.chbEstadoProyecto.LabelAsoc = Nothing
      Me.chbEstadoProyecto.Location = New System.Drawing.Point(617, 14)
      Me.chbEstadoProyecto.Name = "chbEstadoProyecto"
      Me.chbEstadoProyecto.Size = New System.Drawing.Size(59, 17)
      Me.chbEstadoProyecto.TabIndex = 10
      Me.chbEstadoProyecto.Text = "Estado"
      Me.chbEstadoProyecto.UseVisualStyleBackColor = True
      '
      'bscCodigoProyecto
      '
      Me.bscCodigoProyecto.ActivarFiltroEnGrilla = True
      Me.bscCodigoProyecto.BindearPropiedadControl = Nothing
      Me.bscCodigoProyecto.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProyecto.ConfigBuscador = Nothing
      Me.bscCodigoProyecto.Datos = Nothing
      Me.bscCodigoProyecto.Enabled = False
      Me.bscCodigoProyecto.FilaDevuelta = Nothing
      Me.bscCodigoProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProyecto.IsDecimal = False
      Me.bscCodigoProyecto.IsNumber = False
      Me.bscCodigoProyecto.IsPK = False
      Me.bscCodigoProyecto.IsRequired = False
      Me.bscCodigoProyecto.Key = ""
      Me.bscCodigoProyecto.LabelAsoc = Nothing
      Me.bscCodigoProyecto.Location = New System.Drawing.Point(88, 12)
      Me.bscCodigoProyecto.MaxLengh = "32767"
      Me.bscCodigoProyecto.Name = "bscCodigoProyecto"
      Me.bscCodigoProyecto.Permitido = True
      Me.bscCodigoProyecto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProyecto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProyecto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProyecto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProyecto.Selecciono = False
      Me.bscCodigoProyecto.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoProyecto.TabIndex = 2
      '
      'cmbEstadoProyecto
      '
      Me.cmbEstadoProyecto.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoProyecto.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
      Me.cmbEstadoProyecto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoProyecto.Enabled = False
      Me.cmbEstadoProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoProyecto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoProyecto.FormattingEnabled = True
      Me.cmbEstadoProyecto.IsPK = False
      Me.cmbEstadoProyecto.IsRequired = False
      Me.cmbEstadoProyecto.Key = Nothing
      Me.cmbEstadoProyecto.LabelAsoc = Me.chbEstadoProyecto
      Me.cmbEstadoProyecto.Location = New System.Drawing.Point(682, 12)
      Me.cmbEstadoProyecto.Name = "cmbEstadoProyecto"
      Me.cmbEstadoProyecto.Size = New System.Drawing.Size(77, 21)
      Me.cmbEstadoProyecto.TabIndex = 11
      '
      'chbPrioridadProyecto
      '
      Me.chbPrioridadProyecto.AutoSize = True
      Me.chbPrioridadProyecto.BindearPropiedadControl = Nothing
      Me.chbPrioridadProyecto.BindearPropiedadEntidad = Nothing
      Me.chbPrioridadProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrioridadProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrioridadProyecto.IsPK = False
      Me.chbPrioridadProyecto.IsRequired = False
      Me.chbPrioridadProyecto.Key = Nothing
      Me.chbPrioridadProyecto.LabelAsoc = Nothing
      Me.chbPrioridadProyecto.Location = New System.Drawing.Point(431, 14)
      Me.chbPrioridadProyecto.Name = "chbPrioridadProyecto"
      Me.chbPrioridadProyecto.Size = New System.Drawing.Size(67, 17)
      Me.chbPrioridadProyecto.TabIndex = 5
      Me.chbPrioridadProyecto.Text = "Prioridad"
      Me.chbPrioridadProyecto.UseVisualStyleBackColor = True
      '
      'bscProyecto
      '
      Me.bscProyecto.ActivarFiltroEnGrilla = True
      Me.bscProyecto.AutoSize = True
      Me.bscProyecto.BindearPropiedadControl = Nothing
      Me.bscProyecto.BindearPropiedadEntidad = Nothing
      Me.bscProyecto.ConfigBuscador = Nothing
      Me.bscProyecto.Datos = Nothing
      Me.bscProyecto.Enabled = False
      Me.bscProyecto.FilaDevuelta = Nothing
      Me.bscProyecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProyecto.IsDecimal = False
      Me.bscProyecto.IsNumber = False
      Me.bscProyecto.IsPK = False
      Me.bscProyecto.IsRequired = False
      Me.bscProyecto.Key = ""
      Me.bscProyecto.LabelAsoc = Nothing
      Me.bscProyecto.Location = New System.Drawing.Point(182, 12)
      Me.bscProyecto.Margin = New System.Windows.Forms.Padding(4)
      Me.bscProyecto.MaxLengh = "32767"
      Me.bscProyecto.Name = "bscProyecto"
      Me.bscProyecto.Permitido = True
      Me.bscProyecto.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProyecto.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProyecto.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProyecto.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProyecto.Selecciono = False
      Me.bscProyecto.Size = New System.Drawing.Size(221, 23)
      Me.bscProyecto.TabIndex = 4
      '
      'chbProyecto
      '
      Me.chbProyecto.AutoSize = True
      Me.chbProyecto.BindearPropiedadControl = Nothing
      Me.chbProyecto.BindearPropiedadEntidad = Nothing
      Me.chbProyecto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProyecto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProyecto.IsPK = False
      Me.chbProyecto.IsRequired = False
      Me.chbProyecto.Key = Nothing
      Me.chbProyecto.LabelAsoc = Nothing
      Me.chbProyecto.Location = New System.Drawing.Point(14, 14)
      Me.chbProyecto.Name = "chbProyecto"
      Me.chbProyecto.Size = New System.Drawing.Size(68, 17)
      Me.chbProyecto.TabIndex = 0
      Me.chbProyecto.Text = "Proyecto"
      Me.chbProyecto.UseVisualStyleBackColor = True
      '
      'pnlServicioTecnico
      '
      Me.pnlServicioTecnico.AutoSize = True
      Me.pnlServicioTecnico.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.TableLayoutPanel1.SetColumnSpan(Me.pnlServicioTecnico, 2)
      Me.pnlServicioTecnico.Controls.Add(Me.lblEnGarantia)
      Me.pnlServicioTecnico.Controls.Add(Me.lblConPrestamo)
      Me.pnlServicioTecnico.Controls.Add(Me.lblEstadoPrestamo)
      Me.pnlServicioTecnico.Controls.Add(Me.chbSucursal)
      Me.pnlServicioTecnico.Controls.Add(Me.cmbEstadoPrestamo)
      Me.pnlServicioTecnico.Controls.Add(Me.cmbSucursal)
      Me.pnlServicioTecnico.Controls.Add(Me.cmbConPrestamo)
      Me.pnlServicioTecnico.Controls.Add(Me.cmbEnGarantia)
      Me.pnlServicioTecnico.Location = New System.Drawing.Point(0, 27)
      Me.pnlServicioTecnico.Margin = New System.Windows.Forms.Padding(0)
      Me.pnlServicioTecnico.Name = "pnlServicioTecnico"
      Me.pnlServicioTecnico.Size = New System.Drawing.Size(725, 27)
      Me.pnlServicioTecnico.TabIndex = 57
      '
      'lblEnGarantia
      '
      Me.lblEnGarantia.AutoSize = True
      Me.lblEnGarantia.LabelAsoc = Me.chbProyecto
      Me.lblEnGarantia.Location = New System.Drawing.Point(4, 6)
      Me.lblEnGarantia.Name = "lblEnGarantia"
      Me.lblEnGarantia.Size = New System.Drawing.Size(65, 13)
      Me.lblEnGarantia.TabIndex = 33
      Me.lblEnGarantia.Text = "En Garantía"
      Me.lblEnGarantia.Visible = False
      '
      'lblConPrestamo
      '
      Me.lblConPrestamo.AutoSize = True
      Me.lblConPrestamo.LabelAsoc = Me.chbProyecto
      Me.lblConPrestamo.Location = New System.Drawing.Point(154, 6)
      Me.lblConPrestamo.Name = "lblConPrestamo"
      Me.lblConPrestamo.Size = New System.Drawing.Size(73, 13)
      Me.lblConPrestamo.TabIndex = 35
      Me.lblConPrestamo.Text = "Con Préstamo"
      Me.lblConPrestamo.Visible = False
      '
      'lblEstadoPrestamo
      '
      Me.lblEstadoPrestamo.AutoSize = True
      Me.lblEstadoPrestamo.LabelAsoc = Nothing
      Me.lblEstadoPrestamo.Location = New System.Drawing.Point(309, 5)
      Me.lblEstadoPrestamo.Name = "lblEstadoPrestamo"
      Me.lblEstadoPrestamo.Size = New System.Drawing.Size(87, 13)
      Me.lblEstadoPrestamo.TabIndex = 37
      Me.lblEstadoPrestamo.Text = "Estado Préstamo"
      Me.lblEstadoPrestamo.Visible = False
      '
      'chbSucursal
      '
      Me.chbSucursal.AutoSize = True
      Me.chbSucursal.BindearPropiedadControl = Nothing
      Me.chbSucursal.BindearPropiedadEntidad = Nothing
      Me.chbSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSucursal.IsPK = False
      Me.chbSucursal.IsRequired = False
      Me.chbSucursal.Key = Nothing
      Me.chbSucursal.LabelAsoc = Nothing
      Me.chbSucursal.Location = New System.Drawing.Point(523, 4)
      Me.chbSucursal.Name = "chbSucursal"
      Me.chbSucursal.Size = New System.Drawing.Size(67, 17)
      Me.chbSucursal.TabIndex = 52
      Me.chbSucursal.Text = "Sucursal"
      Me.chbSucursal.UseVisualStyleBackColor = True
      '
      'cmbEstadoPrestamo
      '
      Me.cmbEstadoPrestamo.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoPrestamo.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
      Me.cmbEstadoPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoPrestamo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoPrestamo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoPrestamo.FormattingEnabled = True
      Me.cmbEstadoPrestamo.IsPK = False
      Me.cmbEstadoPrestamo.IsRequired = False
      Me.cmbEstadoPrestamo.Key = Nothing
      Me.cmbEstadoPrestamo.LabelAsoc = Me.chbEstadoProyecto
      Me.cmbEstadoPrestamo.Location = New System.Drawing.Point(395, 2)
      Me.cmbEstadoPrestamo.Name = "cmbEstadoPrestamo"
      Me.cmbEstadoPrestamo.Size = New System.Drawing.Size(126, 21)
      Me.cmbEstadoPrestamo.TabIndex = 38
      Me.cmbEstadoPrestamo.Visible = False
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
      Me.cmbSucursal.LabelAsoc = Nothing
      Me.cmbSucursal.Location = New System.Drawing.Point(592, 2)
      Me.cmbSucursal.Name = "cmbSucursal"
      Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
      Me.cmbSucursal.TabIndex = 53
      '
      'cmbConPrestamo
      '
      Me.cmbConPrestamo.BindearPropiedadControl = "SelectedValue"
      Me.cmbConPrestamo.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
      Me.cmbConPrestamo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbConPrestamo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbConPrestamo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbConPrestamo.FormattingEnabled = True
      Me.cmbConPrestamo.IsPK = False
      Me.cmbConPrestamo.IsRequired = False
      Me.cmbConPrestamo.Key = Nothing
      Me.cmbConPrestamo.LabelAsoc = Me.chbEstadoProyecto
      Me.cmbConPrestamo.Location = New System.Drawing.Point(227, 2)
      Me.cmbConPrestamo.Name = "cmbConPrestamo"
      Me.cmbConPrestamo.Size = New System.Drawing.Size(77, 21)
      Me.cmbConPrestamo.TabIndex = 36
      Me.cmbConPrestamo.Visible = False
      '
      'cmbEnGarantia
      '
      Me.cmbEnGarantia.BindearPropiedadControl = "SelectedValue"
      Me.cmbEnGarantia.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
      Me.cmbEnGarantia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEnGarantia.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEnGarantia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEnGarantia.FormattingEnabled = True
      Me.cmbEnGarantia.IsPK = False
      Me.cmbEnGarantia.IsRequired = False
      Me.cmbEnGarantia.Key = Nothing
      Me.cmbEnGarantia.LabelAsoc = Me.chbEstadoProyecto
      Me.cmbEnGarantia.Location = New System.Drawing.Point(75, 3)
      Me.cmbEnGarantia.Name = "cmbEnGarantia"
      Me.cmbEnGarantia.Size = New System.Drawing.Size(77, 21)
      Me.cmbEnGarantia.TabIndex = 34
      Me.cmbEnGarantia.Visible = False
      '
      'pnlAplicacion
      '
      Me.pnlAplicacion.AutoSize = True
      Me.pnlAplicacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlAplicacion.Controls.Add(Me.cmbAplicacion)
      Me.pnlAplicacion.Controls.Add(Me.chbAplicacion)
      Me.pnlAplicacion.Controls.Add(Me.cmbVersion)
      Me.pnlAplicacion.Controls.Add(Me.chbVersion)
      Me.pnlAplicacion.Location = New System.Drawing.Point(0, 0)
      Me.pnlAplicacion.Margin = New System.Windows.Forms.Padding(0)
      Me.pnlAplicacion.Name = "pnlAplicacion"
      Me.pnlAplicacion.Size = New System.Drawing.Size(380, 27)
      Me.pnlAplicacion.TabIndex = 57
      '
      'cmbAplicacion
      '
      Me.cmbAplicacion.BindearPropiedadControl = "SelectedValue"
      Me.cmbAplicacion.BindearPropiedadEntidad = "CategoriaNovedad.IdCategoriaNovedad"
      Me.cmbAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbAplicacion.Enabled = False
      Me.cmbAplicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbAplicacion.FormattingEnabled = True
      Me.cmbAplicacion.IsPK = False
      Me.cmbAplicacion.IsRequired = False
      Me.cmbAplicacion.Key = Nothing
      Me.cmbAplicacion.LabelAsoc = Me.chbAplicacion
      Me.cmbAplicacion.Location = New System.Drawing.Point(76, 3)
      Me.cmbAplicacion.Name = "cmbAplicacion"
      Me.cmbAplicacion.Size = New System.Drawing.Size(142, 21)
      Me.cmbAplicacion.TabIndex = 40
      '
      'chbAplicacion
      '
      Me.chbAplicacion.AutoSize = True
      Me.chbAplicacion.BindearPropiedadControl = Nothing
      Me.chbAplicacion.BindearPropiedadEntidad = Nothing
      Me.chbAplicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAplicacion.IsPK = False
      Me.chbAplicacion.IsRequired = False
      Me.chbAplicacion.Key = Nothing
      Me.chbAplicacion.LabelAsoc = Nothing
      Me.chbAplicacion.Location = New System.Drawing.Point(4, 5)
      Me.chbAplicacion.Name = "chbAplicacion"
      Me.chbAplicacion.Size = New System.Drawing.Size(75, 17)
      Me.chbAplicacion.TabIndex = 39
      Me.chbAplicacion.Text = "Aplicación"
      Me.chbAplicacion.UseVisualStyleBackColor = True
      '
      'cmbVersion
      '
      Me.cmbVersion.BindearPropiedadControl = "SelectedValue"
      Me.cmbVersion.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
      Me.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbVersion.Enabled = False
      Me.cmbVersion.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbVersion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbVersion.FormattingEnabled = True
      Me.cmbVersion.IsPK = False
      Me.cmbVersion.IsRequired = False
      Me.cmbVersion.Key = Nothing
      Me.cmbVersion.LabelAsoc = Me.chbVersion
      Me.cmbVersion.Location = New System.Drawing.Point(280, 3)
      Me.cmbVersion.Name = "cmbVersion"
      Me.cmbVersion.Size = New System.Drawing.Size(97, 21)
      Me.cmbVersion.TabIndex = 42
      '
      'chbVersion
      '
      Me.chbVersion.AutoSize = True
      Me.chbVersion.BindearPropiedadControl = Nothing
      Me.chbVersion.BindearPropiedadEntidad = Nothing
      Me.chbVersion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVersion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVersion.IsPK = False
      Me.chbVersion.IsRequired = False
      Me.chbVersion.Key = Nothing
      Me.chbVersion.LabelAsoc = Nothing
      Me.chbVersion.Location = New System.Drawing.Point(221, 5)
      Me.chbVersion.Name = "chbVersion"
      Me.chbVersion.Size = New System.Drawing.Size(61, 17)
      Me.chbVersion.TabIndex = 41
      Me.chbVersion.Text = "Versión"
      Me.chbVersion.UseVisualStyleBackColor = True
      '
      'pnlVehiculo
      '
      Me.pnlVehiculo.AutoSize = True
      Me.pnlVehiculo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.pnlVehiculo.Controls.Add(Me.bscCodigoVehiculo)
      Me.pnlVehiculo.Controls.Add(Me.chbVehiculo)
      Me.pnlVehiculo.Location = New System.Drawing.Point(380, 0)
      Me.pnlVehiculo.Margin = New System.Windows.Forms.Padding(0)
      Me.pnlVehiculo.Name = "pnlVehiculo"
      Me.pnlVehiculo.Size = New System.Drawing.Size(229, 26)
      Me.pnlVehiculo.TabIndex = 58
      '
      'bscCodigoVehiculo
      '
      Me.bscCodigoVehiculo.ActivarFiltroEnGrilla = True
      Me.bscCodigoVehiculo.BindearPropiedadControl = ""
      Me.bscCodigoVehiculo.BindearPropiedadEntidad = ""
      Me.bscCodigoVehiculo.ConfigBuscador = Nothing
      Me.bscCodigoVehiculo.Datos = Nothing
      Me.bscCodigoVehiculo.FilaDevuelta = Nothing
      Me.bscCodigoVehiculo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoVehiculo.IsDecimal = False
      Me.bscCodigoVehiculo.IsNumber = False
      Me.bscCodigoVehiculo.IsPK = False
      Me.bscCodigoVehiculo.IsRequired = False
      Me.bscCodigoVehiculo.Key = ""
      Me.bscCodigoVehiculo.LabelAsoc = Nothing
      Me.bscCodigoVehiculo.Location = New System.Drawing.Point(81, 3)
      Me.bscCodigoVehiculo.MaxLengh = "32767"
      Me.bscCodigoVehiculo.Name = "bscCodigoVehiculo"
      Me.bscCodigoVehiculo.Permitido = False
      Me.bscCodigoVehiculo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoVehiculo.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoVehiculo.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoVehiculo.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoVehiculo.Selecciono = False
      Me.bscCodigoVehiculo.Size = New System.Drawing.Size(145, 20)
      Me.bscCodigoVehiculo.TabIndex = 43
      '
      'chbVehiculo
      '
      Me.chbVehiculo.AutoSize = True
      Me.chbVehiculo.BindearPropiedadControl = Nothing
      Me.chbVehiculo.BindearPropiedadEntidad = Nothing
      Me.chbVehiculo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVehiculo.IsPK = False
      Me.chbVehiculo.IsRequired = False
      Me.chbVehiculo.Key = Nothing
      Me.chbVehiculo.LabelAsoc = Nothing
      Me.chbVehiculo.Location = New System.Drawing.Point(4, 5)
      Me.chbVehiculo.Name = "chbVehiculo"
      Me.chbVehiculo.Size = New System.Drawing.Size(69, 17)
      Me.chbVehiculo.TabIndex = 39
      Me.chbVehiculo.Text = "Vehículo"
      Me.chbVehiculo.UseVisualStyleBackColor = True
      '
      'pnlFIltrosEstandares
      '
      Me.pnlFIltrosEstandares.Controls.Add(Me.Label2)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbCRMMetodos)
      Me.pnlFIltrosEstandares.Controls.Add(Me.Label1)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbCRMMedios)
      Me.pnlFIltrosEstandares.Controls.Add(Me.lblEstado)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbCRMEstados)
      Me.pnlFIltrosEstandares.Controls.Add(Me.lblPriorizado)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbCategoriasNovedad)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbUsuarioAsignado)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbCategoriaReporta)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbNumeroPadre)
      Me.pnlFIltrosEstandares.Controls.Add(Me.lblFechaAltaDesde)
      Me.pnlFIltrosEstandares.Controls.Add(Me.txtNumeroPadre)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbCategoriaReporta)
      Me.pnlFIltrosEstandares.Controls.Add(Me.lblFechaAltaHasta)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbTipoUsuario)
      Me.pnlFIltrosEstandares.Controls.Add(Me.dtpFechaDesde)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbTipoUsuario)
      Me.pnlFIltrosEstandares.Controls.Add(Me.dtpFechaHasta)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chkMesCompleto)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbCliente)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbUsuarioAlta)
      Me.pnlFIltrosEstandares.Controls.Add(Me.bscCodigoCliente)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbUsuarioAlta)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbRevisionAdministrativa)
      Me.pnlFIltrosEstandares.Controls.Add(Me.bscCliente)
      Me.pnlFIltrosEstandares.Controls.Add(Me.lblRevisionAdministrativa)
      Me.pnlFIltrosEstandares.Controls.Add(Me.txtNumero)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbUsuarioAsignado)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbNumero)
      Me.pnlFIltrosEstandares.Controls.Add(Me.lblFinalizado)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbFinalizado)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbFecha)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbFuncionNuevo)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbPriorizado)
      Me.pnlFIltrosEstandares.Controls.Add(Me.lblPriodizado)
      Me.pnlFIltrosEstandares.Controls.Add(Me.bscFuncionNuevo)
      Me.pnlFIltrosEstandares.Controls.Add(Me.bscCodigoFuncionNuevo)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbTipoFechaFiltro)
      Me.pnlFIltrosEstandares.Controls.Add(Me.cmbPrioridad)
      Me.pnlFIltrosEstandares.Controls.Add(Me.chbPrioridad)
      Me.pnlFIltrosEstandares.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFIltrosEstandares.Location = New System.Drawing.Point(0, 0)
      Me.pnlFIltrosEstandares.Margin = New System.Windows.Forms.Padding(0)
      Me.pnlFIltrosEstandares.Name = "pnlFIltrosEstandares"
      Me.pnlFIltrosEstandares.Size = New System.Drawing.Size(1078, 100)
      Me.pnlFIltrosEstandares.TabIndex = 55
      '
      'cmbCRMMetodos
      '
      Me.cmbCRMMetodos.BindearPropiedadControl = Nothing
      Me.cmbCRMMetodos.BindearPropiedadEntidad = Nothing
      Me.cmbCRMMetodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCRMMetodos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCRMMetodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCRMMetodos.FormattingEnabled = True
      Me.cmbCRMMetodos.IsPK = False
      Me.cmbCRMMetodos.IsRequired = False
      Me.cmbCRMMetodos.Key = Nothing
      Me.cmbCRMMetodos.LabelAsoc = Nothing
      Me.cmbCRMMetodos.Location = New System.Drawing.Point(662, 25)
      Me.cmbCRMMetodos.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbCRMMetodos.Name = "cmbCRMMetodos"
      Me.cmbCRMMetodos.Size = New System.Drawing.Size(147, 21)
      Me.cmbCRMMetodos.TabIndex = 59
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(401, 82)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(36, 13)
      Me.Label1.TabIndex = 58
      Me.Label1.Text = "Medio"
      '
      'cmbCRMMedios
      '
      Me.cmbCRMMedios.BindearPropiedadControl = Nothing
      Me.cmbCRMMedios.BindearPropiedadEntidad = Nothing
      Me.cmbCRMMedios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCRMMedios.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCRMMedios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCRMMedios.FormattingEnabled = True
      Me.cmbCRMMedios.IsPK = False
      Me.cmbCRMMedios.IsRequired = False
      Me.cmbCRMMedios.Key = Nothing
      Me.cmbCRMMedios.LabelAsoc = Nothing
      Me.cmbCRMMedios.Location = New System.Drawing.Point(462, 77)
      Me.cmbCRMMedios.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbCRMMedios.Name = "cmbCRMMedios"
      Me.cmbCRMMedios.Size = New System.Drawing.Size(146, 21)
      Me.cmbCRMMedios.TabIndex = 57
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(401, 56)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 54
      Me.lblEstado.Text = "Estado"
      '
      'cmbCRMEstados
      '
      Me.cmbCRMEstados.BindearPropiedadControl = Nothing
      Me.cmbCRMEstados.BindearPropiedadEntidad = Nothing
      Me.cmbCRMEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCRMEstados.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCRMEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCRMEstados.FormattingEnabled = True
      Me.cmbCRMEstados.IsPK = False
      Me.cmbCRMEstados.IsRequired = False
      Me.cmbCRMEstados.Key = Nothing
      Me.cmbCRMEstados.LabelAsoc = Nothing
      Me.cmbCRMEstados.Location = New System.Drawing.Point(462, 51)
      Me.cmbCRMEstados.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbCRMEstados.Name = "cmbCRMEstados"
      Me.cmbCRMEstados.Size = New System.Drawing.Size(146, 21)
      Me.cmbCRMEstados.TabIndex = 53
      '
      'lblPriorizado
      '
      Me.lblPriorizado.AutoSize = True
      Me.lblPriorizado.LabelAsoc = Nothing
      Me.lblPriorizado.Location = New System.Drawing.Point(401, 32)
      Me.lblPriorizado.Name = "lblPriorizado"
      Me.lblPriorizado.Size = New System.Drawing.Size(54, 13)
      Me.lblPriorizado.TabIndex = 52
      Me.lblPriorizado.Text = "Categoría"
      '
      'cmbCategoriasNovedad
      '
      Me.cmbCategoriasNovedad.BindearPropiedadControl = Nothing
      Me.cmbCategoriasNovedad.BindearPropiedadEntidad = Nothing
      Me.cmbCategoriasNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoriasNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoriasNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoriasNovedad.FormattingEnabled = True
      Me.cmbCategoriasNovedad.IsPK = False
      Me.cmbCategoriasNovedad.IsRequired = False
      Me.cmbCategoriasNovedad.Key = Nothing
      Me.cmbCategoriasNovedad.LabelAsoc = Nothing
      Me.cmbCategoriasNovedad.Location = New System.Drawing.Point(462, 25)
      Me.cmbCategoriasNovedad.Margin = New System.Windows.Forms.Padding(0)
      Me.cmbCategoriasNovedad.Name = "cmbCategoriasNovedad"
      Me.cmbCategoriasNovedad.Size = New System.Drawing.Size(146, 21)
      Me.cmbCategoriasNovedad.TabIndex = 51
      '
      'cmbUsuarioAsignado
      '
      Me.cmbUsuarioAsignado.BindearPropiedadControl = Nothing
      Me.cmbUsuarioAsignado.BindearPropiedadEntidad = Nothing
      Me.cmbUsuarioAsignado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuarioAsignado.Enabled = False
      Me.cmbUsuarioAsignado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuarioAsignado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuarioAsignado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuarioAsignado.FormattingEnabled = True
      Me.cmbUsuarioAsignado.IsPK = False
      Me.cmbUsuarioAsignado.IsRequired = False
      Me.cmbUsuarioAsignado.Key = Nothing
      Me.cmbUsuarioAsignado.LabelAsoc = Me.chbUsuarioAsignado
      Me.cmbUsuarioAsignado.Location = New System.Drawing.Point(80, 3)
      Me.cmbUsuarioAsignado.Name = "cmbUsuarioAsignado"
      Me.cmbUsuarioAsignado.Size = New System.Drawing.Size(140, 21)
      Me.cmbUsuarioAsignado.TabIndex = 1
      '
      'chbUsuarioAsignado
      '
      Me.chbUsuarioAsignado.AutoSize = True
      Me.chbUsuarioAsignado.BindearPropiedadControl = Nothing
      Me.chbUsuarioAsignado.BindearPropiedadEntidad = Nothing
      Me.chbUsuarioAsignado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuarioAsignado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuarioAsignado.IsPK = False
      Me.chbUsuarioAsignado.IsRequired = False
      Me.chbUsuarioAsignado.Key = Nothing
      Me.chbUsuarioAsignado.LabelAsoc = Nothing
      Me.chbUsuarioAsignado.Location = New System.Drawing.Point(5, 5)
      Me.chbUsuarioAsignado.Name = "chbUsuarioAsignado"
      Me.chbUsuarioAsignado.Size = New System.Drawing.Size(65, 17)
      Me.chbUsuarioAsignado.TabIndex = 0
      Me.chbUsuarioAsignado.Text = "Usuario "
      Me.chbUsuarioAsignado.UseVisualStyleBackColor = True
      '
      'chbCategoriaReporta
      '
      Me.chbCategoriaReporta.AutoSize = True
      Me.chbCategoriaReporta.BindearPropiedadControl = Nothing
      Me.chbCategoriaReporta.BindearPropiedadEntidad = Nothing
      Me.chbCategoriaReporta.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCategoriaReporta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCategoriaReporta.IsPK = False
      Me.chbCategoriaReporta.IsRequired = False
      Me.chbCategoriaReporta.Key = Nothing
      Me.chbCategoriaReporta.LabelAsoc = Nothing
      Me.chbCategoriaReporta.Location = New System.Drawing.Point(633, 53)
      Me.chbCategoriaReporta.Name = "chbCategoriaReporta"
      Me.chbCategoriaReporta.Size = New System.Drawing.Size(86, 17)
      Me.chbCategoriaReporta.TabIndex = 16
      Me.chbCategoriaReporta.Text = "Cat. Reporta"
      Me.chbCategoriaReporta.UseVisualStyleBackColor = True
      '
      'chbNumeroPadre
      '
      Me.chbNumeroPadre.AutoSize = True
      Me.chbNumeroPadre.BindearPropiedadControl = Nothing
      Me.chbNumeroPadre.BindearPropiedadEntidad = Nothing
      Me.chbNumeroPadre.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumeroPadre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumeroPadre.IsPK = False
      Me.chbNumeroPadre.IsRequired = False
      Me.chbNumeroPadre.Key = Nothing
      Me.chbNumeroPadre.LabelAsoc = Nothing
      Me.chbNumeroPadre.Location = New System.Drawing.Point(773, 78)
      Me.chbNumeroPadre.Name = "chbNumeroPadre"
      Me.chbNumeroPadre.Size = New System.Drawing.Size(54, 17)
      Me.chbNumeroPadre.TabIndex = 47
      Me.chbNumeroPadre.Text = "Padre"
      Me.chbNumeroPadre.UseVisualStyleBackColor = True
      '
      'lblFechaAltaDesde
      '
      Me.lblFechaAltaDesde.AutoSize = True
      Me.lblFechaAltaDesde.LabelAsoc = Me.chbFecha
      Me.lblFechaAltaDesde.Location = New System.Drawing.Point(573, 7)
      Me.lblFechaAltaDesde.Name = "lblFechaAltaDesde"
      Me.lblFechaAltaDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblFechaAltaDesde.TabIndex = 6
      Me.lblFechaAltaDesde.Text = "Desde"
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
      Me.chbFecha.Location = New System.Drawing.Point(400, 5)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(56, 17)
      Me.chbFecha.TabIndex = 4
      Me.chbFecha.Text = "Fecha"
      Me.chbFecha.UseVisualStyleBackColor = True
      '
      'txtNumeroPadre
      '
      Me.txtNumeroPadre.BindearPropiedadControl = Nothing
      Me.txtNumeroPadre.BindearPropiedadEntidad = Nothing
      Me.txtNumeroPadre.Enabled = False
      Me.txtNumeroPadre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumeroPadre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumeroPadre.Formato = "##0"
      Me.txtNumeroPadre.IsDecimal = False
      Me.txtNumeroPadre.IsNumber = True
      Me.txtNumeroPadre.IsPK = False
      Me.txtNumeroPadre.IsRequired = False
      Me.txtNumeroPadre.Key = ""
      Me.txtNumeroPadre.LabelAsoc = Nothing
      Me.txtNumeroPadre.Location = New System.Drawing.Point(831, 76)
      Me.txtNumeroPadre.MaxLength = 8
      Me.txtNumeroPadre.Name = "txtNumeroPadre"
      Me.txtNumeroPadre.Size = New System.Drawing.Size(59, 20)
      Me.txtNumeroPadre.TabIndex = 48
      Me.txtNumeroPadre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbCategoriaReporta
      '
      Me.cmbCategoriaReporta.BindearPropiedadControl = "SelectedValue"
      Me.cmbCategoriaReporta.BindearPropiedadEntidad = "Reporta"
      Me.cmbCategoriaReporta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCategoriaReporta.Enabled = False
      Me.cmbCategoriaReporta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCategoriaReporta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCategoriaReporta.FormattingEnabled = True
      Me.cmbCategoriaReporta.IsPK = False
      Me.cmbCategoriaReporta.IsRequired = False
      Me.cmbCategoriaReporta.Key = Nothing
      Me.cmbCategoriaReporta.LabelAsoc = Nothing
      Me.cmbCategoriaReporta.Location = New System.Drawing.Point(726, 51)
      Me.cmbCategoriaReporta.Name = "cmbCategoriaReporta"
      Me.cmbCategoriaReporta.Size = New System.Drawing.Size(83, 21)
      Me.cmbCategoriaReporta.TabIndex = 17
      '
      'lblFechaAltaHasta
      '
      Me.lblFechaAltaHasta.AutoSize = True
      Me.lblFechaAltaHasta.Enabled = False
      Me.lblFechaAltaHasta.LabelAsoc = Me.chbFecha
      Me.lblFechaAltaHasta.Location = New System.Drawing.Point(755, 7)
      Me.lblFechaAltaHasta.Name = "lblFechaAltaHasta"
      Me.lblFechaAltaHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblFechaAltaHasta.TabIndex = 8
      Me.lblFechaAltaHasta.Text = "Hasta"
      '
      'chbTipoUsuario
      '
      Me.chbTipoUsuario.AutoSize = True
      Me.chbTipoUsuario.BindearPropiedadControl = Nothing
      Me.chbTipoUsuario.BindearPropiedadEntidad = Nothing
      Me.chbTipoUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbTipoUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbTipoUsuario.IsPK = False
      Me.chbTipoUsuario.IsRequired = False
      Me.chbTipoUsuario.Key = Nothing
      Me.chbTipoUsuario.LabelAsoc = Nothing
      Me.chbTipoUsuario.Location = New System.Drawing.Point(169, 77)
      Me.chbTipoUsuario.Name = "chbTipoUsuario"
      Me.chbTipoUsuario.Size = New System.Drawing.Size(86, 17)
      Me.chbTipoUsuario.TabIndex = 31
      Me.chbTipoUsuario.Text = "Tipo Usuario"
      Me.chbTipoUsuario.UseVisualStyleBackColor = True
      '
      'dtpFechaDesde
      '
      Me.dtpFechaDesde.BindearPropiedadControl = Nothing
      Me.dtpFechaDesde.BindearPropiedadEntidad = Nothing
      Me.dtpFechaDesde.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaDesde.Enabled = False
      Me.dtpFechaDesde.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaDesde.IsPK = False
      Me.dtpFechaDesde.IsRequired = False
      Me.dtpFechaDesde.Key = ""
      Me.dtpFechaDesde.LabelAsoc = Me.lblFechaAltaDesde
      Me.dtpFechaDesde.Location = New System.Drawing.Point(617, 3)
      Me.dtpFechaDesde.Name = "dtpFechaDesde"
      Me.dtpFechaDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpFechaDesde.TabIndex = 7
      '
      'cmbTipoUsuario
      '
      Me.cmbTipoUsuario.BindearPropiedadControl = Nothing
      Me.cmbTipoUsuario.BindearPropiedadEntidad = Nothing
      Me.cmbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoUsuario.Enabled = False
      Me.cmbTipoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbTipoUsuario.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoUsuario.FormattingEnabled = True
      Me.cmbTipoUsuario.IsPK = False
      Me.cmbTipoUsuario.IsRequired = False
      Me.cmbTipoUsuario.Key = Nothing
      Me.cmbTipoUsuario.LabelAsoc = Nothing
      Me.cmbTipoUsuario.Location = New System.Drawing.Point(259, 75)
      Me.cmbTipoUsuario.Name = "cmbTipoUsuario"
      Me.cmbTipoUsuario.Size = New System.Drawing.Size(136, 21)
      Me.cmbTipoUsuario.TabIndex = 32
      '
      'dtpFechaHasta
      '
      Me.dtpFechaHasta.BindearPropiedadControl = Nothing
      Me.dtpFechaHasta.BindearPropiedadEntidad = Nothing
      Me.dtpFechaHasta.CustomFormat = "dd/MM/yyyy HH:mm"
      Me.dtpFechaHasta.Enabled = False
      Me.dtpFechaHasta.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaHasta.IsPK = False
      Me.dtpFechaHasta.IsRequired = False
      Me.dtpFechaHasta.Key = ""
      Me.dtpFechaHasta.LabelAsoc = Me.lblFechaAltaHasta
      Me.dtpFechaHasta.Location = New System.Drawing.Point(796, 3)
      Me.dtpFechaHasta.Name = "dtpFechaHasta"
      Me.dtpFechaHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpFechaHasta.TabIndex = 9
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
      Me.chkMesCompleto.LabelAsoc = Me.chbFecha
      Me.chkMesCompleto.Location = New System.Drawing.Point(471, 5)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 5
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
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
      Me.chbCliente.Location = New System.Drawing.Point(5, 28)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(74, 17)
      Me.chbCliente.TabIndex = 11
      Me.chbCliente.Text = "Prospecto"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'chbUsuarioAlta
      '
      Me.chbUsuarioAlta.AutoSize = True
      Me.chbUsuarioAlta.BindearPropiedadControl = Nothing
      Me.chbUsuarioAlta.BindearPropiedadEntidad = Nothing
      Me.chbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
      Me.chbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbUsuarioAlta.IsPK = False
      Me.chbUsuarioAlta.IsRequired = False
      Me.chbUsuarioAlta.Key = Nothing
      Me.chbUsuarioAlta.LabelAsoc = Nothing
      Me.chbUsuarioAlta.Location = New System.Drawing.Point(840, 31)
      Me.chbUsuarioAlta.Name = "chbUsuarioAlta"
      Me.chbUsuarioAlta.Size = New System.Drawing.Size(83, 17)
      Me.chbUsuarioAlta.TabIndex = 43
      Me.chbUsuarioAlta.Text = "Usuario Alta"
      Me.chbUsuarioAlta.UseVisualStyleBackColor = True
      '
      'bscCodigoCliente
      '
      Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
      Me.bscCodigoCliente.BindearPropiedadControl = Nothing
      Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.bscCodigoCliente.ConfigBuscador = Nothing
      Me.bscCodigoCliente.Datos = Nothing
      Me.bscCodigoCliente.Enabled = False
      Me.bscCodigoCliente.FilaDevuelta = Nothing
      Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoCliente.IsDecimal = False
      Me.bscCodigoCliente.IsNumber = False
      Me.bscCodigoCliente.IsPK = False
      Me.bscCodigoCliente.IsRequired = False
      Me.bscCodigoCliente.Key = ""
      Me.bscCodigoCliente.LabelAsoc = Me.chbCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(80, 27)
      Me.bscCodigoCliente.MaxLengh = "32767"
      Me.bscCodigoCliente.Name = "bscCodigoCliente"
      Me.bscCodigoCliente.Permitido = True
      Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoCliente.Selecciono = False
      Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
      Me.bscCodigoCliente.TabIndex = 12
      '
      'cmbUsuarioAlta
      '
      Me.cmbUsuarioAlta.BindearPropiedadControl = Nothing
      Me.cmbUsuarioAlta.BindearPropiedadEntidad = Nothing
      Me.cmbUsuarioAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbUsuarioAlta.Enabled = False
      Me.cmbUsuarioAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbUsuarioAlta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbUsuarioAlta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbUsuarioAlta.FormattingEnabled = True
      Me.cmbUsuarioAlta.IsPK = False
      Me.cmbUsuarioAlta.IsRequired = False
      Me.cmbUsuarioAlta.Key = Nothing
      Me.cmbUsuarioAlta.LabelAsoc = Me.chbUsuarioAlta
      Me.cmbUsuarioAlta.Location = New System.Drawing.Point(929, 27)
      Me.cmbUsuarioAlta.Name = "cmbUsuarioAlta"
      Me.cmbUsuarioAlta.Size = New System.Drawing.Size(146, 21)
      Me.cmbUsuarioAlta.TabIndex = 44
      '
      'cmbRevisionAdministrativa
      '
      Me.cmbRevisionAdministrativa.BindearPropiedadControl = Nothing
      Me.cmbRevisionAdministrativa.BindearPropiedadEntidad = Nothing
      Me.cmbRevisionAdministrativa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRevisionAdministrativa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbRevisionAdministrativa.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbRevisionAdministrativa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbRevisionAdministrativa.FormattingEnabled = True
      Me.cmbRevisionAdministrativa.IsPK = False
      Me.cmbRevisionAdministrativa.IsRequired = False
      Me.cmbRevisionAdministrativa.Items.AddRange(New Object() {"TODAS", "SI", "NO"})
      Me.cmbRevisionAdministrativa.Key = Nothing
      Me.cmbRevisionAdministrativa.LabelAsoc = Me.lblRevisionAdministrativa
      Me.cmbRevisionAdministrativa.Location = New System.Drawing.Point(971, 74)
      Me.cmbRevisionAdministrativa.Name = "cmbRevisionAdministrativa"
      Me.cmbRevisionAdministrativa.Size = New System.Drawing.Size(76, 21)
      Me.cmbRevisionAdministrativa.TabIndex = 50
      '
      'lblRevisionAdministrativa
      '
      Me.lblRevisionAdministrativa.AutoSize = True
      Me.lblRevisionAdministrativa.LabelAsoc = Nothing
      Me.lblRevisionAdministrativa.Location = New System.Drawing.Point(900, 78)
      Me.lblRevisionAdministrativa.Name = "lblRevisionAdministrativa"
      Me.lblRevisionAdministrativa.Size = New System.Drawing.Size(65, 13)
      Me.lblRevisionAdministrativa.TabIndex = 49
      Me.lblRevisionAdministrativa.Text = "Rev. Admin."
      '
      'bscCliente
      '
      Me.bscCliente.ActivarFiltroEnGrilla = True
      Me.bscCliente.AutoSize = True
      Me.bscCliente.BindearPropiedadControl = Nothing
      Me.bscCliente.BindearPropiedadEntidad = Nothing
      Me.bscCliente.ConfigBuscador = Nothing
      Me.bscCliente.Datos = Nothing
      Me.bscCliente.Enabled = False
      Me.bscCliente.FilaDevuelta = Nothing
      Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCliente.IsDecimal = False
      Me.bscCliente.IsNumber = False
      Me.bscCliente.IsPK = False
      Me.bscCliente.IsRequired = False
      Me.bscCliente.Key = ""
      Me.bscCliente.LabelAsoc = Me.chbCliente
      Me.bscCliente.Location = New System.Drawing.Point(174, 27)
      Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
      Me.bscCliente.MaxLengh = "32767"
      Me.bscCliente.Name = "bscCliente"
      Me.bscCliente.Permitido = True
      Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCliente.Selecciono = False
      Me.bscCliente.Size = New System.Drawing.Size(221, 23)
      Me.bscCliente.TabIndex = 13
      '
      'txtNumero
      '
      Me.txtNumero.BindearPropiedadControl = Nothing
      Me.txtNumero.BindearPropiedadEntidad = Nothing
      Me.txtNumero.Enabled = False
      Me.txtNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNumero.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNumero.Formato = "##0"
      Me.txtNumero.IsDecimal = False
      Me.txtNumero.IsNumber = True
      Me.txtNumero.IsPK = False
      Me.txtNumero.IsRequired = False
      Me.txtNumero.Key = ""
      Me.txtNumero.LabelAsoc = Me.chbNumero
      Me.txtNumero.Location = New System.Drawing.Point(700, 76)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(59, 20)
      Me.txtNumero.TabIndex = 46
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbNumero
      '
      Me.chbNumero.AutoSize = True
      Me.chbNumero.BindearPropiedadControl = Nothing
      Me.chbNumero.BindearPropiedadEntidad = Nothing
      Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNumero.IsPK = False
      Me.chbNumero.IsRequired = False
      Me.chbNumero.Key = Nothing
      Me.chbNumero.LabelAsoc = Nothing
      Me.chbNumero.Location = New System.Drawing.Point(633, 78)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(63, 17)
      Me.chbNumero.TabIndex = 45
      Me.chbNumero.Text = "Numero"
      Me.chbNumero.UseVisualStyleBackColor = True
      '
      'lblFinalizado
      '
      Me.lblFinalizado.AutoSize = True
      Me.lblFinalizado.LabelAsoc = Nothing
      Me.lblFinalizado.Location = New System.Drawing.Point(226, 7)
      Me.lblFinalizado.Name = "lblFinalizado"
      Me.lblFinalizado.Size = New System.Drawing.Size(54, 13)
      Me.lblFinalizado.TabIndex = 2
      Me.lblFinalizado.Text = "Finalizado"
      '
      'cmbFinalizado
      '
      Me.cmbFinalizado.BindearPropiedadControl = Nothing
      Me.cmbFinalizado.BindearPropiedadEntidad = Nothing
      Me.cmbFinalizado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFinalizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFinalizado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFinalizado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFinalizado.FormattingEnabled = True
      Me.cmbFinalizado.IsPK = False
      Me.cmbFinalizado.IsRequired = False
      Me.cmbFinalizado.Key = Nothing
      Me.cmbFinalizado.LabelAsoc = Me.lblFinalizado
      Me.cmbFinalizado.Location = New System.Drawing.Point(286, 3)
      Me.cmbFinalizado.Name = "cmbFinalizado"
      Me.cmbFinalizado.Size = New System.Drawing.Size(83, 21)
      Me.cmbFinalizado.TabIndex = 3
      '
      'chbFuncionNuevo
      '
      Me.chbFuncionNuevo.AutoSize = True
      Me.chbFuncionNuevo.BindearPropiedadControl = Nothing
      Me.chbFuncionNuevo.BindearPropiedadEntidad = Nothing
      Me.chbFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbFuncionNuevo.IsPK = False
      Me.chbFuncionNuevo.IsRequired = False
      Me.chbFuncionNuevo.Key = Nothing
      Me.chbFuncionNuevo.LabelAsoc = Nothing
      Me.chbFuncionNuevo.Location = New System.Drawing.Point(5, 52)
      Me.chbFuncionNuevo.Name = "chbFuncionNuevo"
      Me.chbFuncionNuevo.Size = New System.Drawing.Size(64, 17)
      Me.chbFuncionNuevo.TabIndex = 20
      Me.chbFuncionNuevo.Text = "Función"
      Me.chbFuncionNuevo.UseVisualStyleBackColor = True
      Me.chbFuncionNuevo.Visible = False
      '
      'cmbPriorizado
      '
      Me.cmbPriorizado.BindearPropiedadControl = Nothing
      Me.cmbPriorizado.BindearPropiedadEntidad = Nothing
      Me.cmbPriorizado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPriorizado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPriorizado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPriorizado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPriorizado.FormattingEnabled = True
      Me.cmbPriorizado.IsPK = False
      Me.cmbPriorizado.IsRequired = False
      Me.cmbPriorizado.Key = Nothing
      Me.cmbPriorizado.LabelAsoc = Me.lblPriodizado
      Me.cmbPriorizado.Location = New System.Drawing.Point(80, 74)
      Me.cmbPriorizado.Name = "cmbPriorizado"
      Me.cmbPriorizado.Size = New System.Drawing.Size(83, 21)
      Me.cmbPriorizado.TabIndex = 30
      '
      'lblPriodizado
      '
      Me.lblPriodizado.AutoSize = True
      Me.lblPriodizado.LabelAsoc = Nothing
      Me.lblPriodizado.Location = New System.Drawing.Point(21, 79)
      Me.lblPriodizado.Name = "lblPriodizado"
      Me.lblPriodizado.Size = New System.Drawing.Size(53, 13)
      Me.lblPriodizado.TabIndex = 29
      Me.lblPriodizado.Text = "Priorizado"
      '
      'bscFuncionNuevo
      '
      Me.bscFuncionNuevo.ActivarFiltroEnGrilla = True
      Me.bscFuncionNuevo.BindearPropiedadControl = Nothing
      Me.bscFuncionNuevo.BindearPropiedadEntidad = Nothing
      Me.bscFuncionNuevo.ConfigBuscador = Nothing
      Me.bscFuncionNuevo.Datos = Nothing
      Me.bscFuncionNuevo.Enabled = False
      Me.bscFuncionNuevo.FilaDevuelta = Nothing
      Me.bscFuncionNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscFuncionNuevo.IsDecimal = False
      Me.bscFuncionNuevo.IsNumber = False
      Me.bscFuncionNuevo.IsPK = False
      Me.bscFuncionNuevo.IsRequired = False
      Me.bscFuncionNuevo.Key = ""
      Me.bscFuncionNuevo.LabelAsoc = Me.chbFuncionNuevo
      Me.bscFuncionNuevo.Location = New System.Drawing.Point(80, 51)
      Me.bscFuncionNuevo.Margin = New System.Windows.Forms.Padding(4)
      Me.bscFuncionNuevo.MaxLengh = "32767"
      Me.bscFuncionNuevo.Name = "bscFuncionNuevo"
      Me.bscFuncionNuevo.Permitido = True
      Me.bscFuncionNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscFuncionNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscFuncionNuevo.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscFuncionNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscFuncionNuevo.Selecciono = False
      Me.bscFuncionNuevo.Size = New System.Drawing.Size(197, 23)
      Me.bscFuncionNuevo.TabIndex = 21
      Me.bscFuncionNuevo.Visible = False
      '
      'bscCodigoFuncionNuevo
      '
      Me.bscCodigoFuncionNuevo.ActivarFiltroEnGrilla = True
      Me.bscCodigoFuncionNuevo.BindearPropiedadControl = Nothing
      Me.bscCodigoFuncionNuevo.BindearPropiedadEntidad = Nothing
      Me.bscCodigoFuncionNuevo.ConfigBuscador = Nothing
      Me.bscCodigoFuncionNuevo.Datos = Nothing
      Me.bscCodigoFuncionNuevo.Enabled = False
      Me.bscCodigoFuncionNuevo.FilaDevuelta = Nothing
      Me.bscCodigoFuncionNuevo.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoFuncionNuevo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoFuncionNuevo.IsDecimal = False
      Me.bscCodigoFuncionNuevo.IsNumber = False
      Me.bscCodigoFuncionNuevo.IsPK = False
      Me.bscCodigoFuncionNuevo.IsRequired = False
      Me.bscCodigoFuncionNuevo.Key = ""
      Me.bscCodigoFuncionNuevo.LabelAsoc = Me.chbFuncionNuevo
      Me.bscCodigoFuncionNuevo.Location = New System.Drawing.Point(286, 52)
      Me.bscCodigoFuncionNuevo.MaxLengh = "32767"
      Me.bscCodigoFuncionNuevo.Name = "bscCodigoFuncionNuevo"
      Me.bscCodigoFuncionNuevo.Permitido = True
      Me.bscCodigoFuncionNuevo.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoFuncionNuevo.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoFuncionNuevo.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoFuncionNuevo.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoFuncionNuevo.Selecciono = False
      Me.bscCodigoFuncionNuevo.Size = New System.Drawing.Size(90, 20)
      Me.bscCodigoFuncionNuevo.TabIndex = 22
      Me.bscCodigoFuncionNuevo.Visible = False
      '
      'cmbTipoFechaFiltro
      '
      Me.cmbTipoFechaFiltro.BindearPropiedadControl = ""
      Me.cmbTipoFechaFiltro.BindearPropiedadEntidad = ""
      Me.cmbTipoFechaFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoFechaFiltro.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoFechaFiltro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoFechaFiltro.FormattingEnabled = True
      Me.cmbTipoFechaFiltro.IsPK = False
      Me.cmbTipoFechaFiltro.IsRequired = False
      Me.cmbTipoFechaFiltro.Key = Nothing
      Me.cmbTipoFechaFiltro.LabelAsoc = Me.chbFecha
      Me.cmbTipoFechaFiltro.Location = New System.Drawing.Point(929, 3)
      Me.cmbTipoFechaFiltro.Name = "cmbTipoFechaFiltro"
      Me.cmbTipoFechaFiltro.Size = New System.Drawing.Size(146, 21)
      Me.cmbTipoFechaFiltro.TabIndex = 10
      '
      'cmbPrioridad
      '
      Me.cmbPrioridad.BindearPropiedadControl = "SelectedValue"
      Me.cmbPrioridad.BindearPropiedadEntidad = "MedioComunicacionNovedad.IdMedioComunicacionNovedad"
      Me.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPrioridad.Enabled = False
      Me.cmbPrioridad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPrioridad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPrioridad.FormattingEnabled = True
      Me.cmbPrioridad.IsPK = False
      Me.cmbPrioridad.IsRequired = False
      Me.cmbPrioridad.Key = Nothing
      Me.cmbPrioridad.LabelAsoc = Me.chbPrioridad
      Me.cmbPrioridad.Location = New System.Drawing.Point(929, 51)
      Me.cmbPrioridad.Name = "cmbPrioridad"
      Me.cmbPrioridad.Size = New System.Drawing.Size(146, 21)
      Me.cmbPrioridad.TabIndex = 28
      '
      'chbPrioridad
      '
      Me.chbPrioridad.AutoSize = True
      Me.chbPrioridad.BindearPropiedadControl = Nothing
      Me.chbPrioridad.BindearPropiedadEntidad = Nothing
      Me.chbPrioridad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPrioridad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPrioridad.IsPK = False
      Me.chbPrioridad.IsRequired = False
      Me.chbPrioridad.Key = Nothing
      Me.chbPrioridad.LabelAsoc = Nothing
      Me.chbPrioridad.Location = New System.Drawing.Point(840, 54)
      Me.chbPrioridad.Name = "chbPrioridad"
      Me.chbPrioridad.Size = New System.Drawing.Size(67, 17)
      Me.chbPrioridad.TabIndex = 27
      Me.chbPrioridad.Text = "Prioridad"
      Me.chbPrioridad.UseVisualStyleBackColor = True
      '
      'btnConsultar
      '
      Me.btnConsultar.AnchoredControl = Me.dgvDatos
      Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(970, 251)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
      Me.btnConsultar.TabIndex = 54
      Me.btnConsultar.Text = "&Consultar (F3)"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
      '
      'gridContextMenuStrip
      '
      Me.gridContextMenuStrip.Name = "gridContextMenuStrip"
      Me.gridContextMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'GridContextMenuManager1
      '
      Me.GridContextMenuManager1.Grilla = Me.dgvDatos
      Me.GridContextMenuManager1.Menu = Me.gridContextMenuStrip
      '
      'FiltersManager1
      '
      Me.FiltersManager1.BotonRefrescar = Me.tsbRefrescar
      Me.FiltersManager1.PanelFiltro = Me.grpFiltros
      '
      'splitter1
      '
      Me.splitter1.BackColor = System.Drawing.SystemColors.Control
      Me.splitter1.ButtonExtent = 360
      Me.splitter1.Dock = System.Windows.Forms.DockStyle.Top
      Me.splitter1.Location = New System.Drawing.Point(0, 234)
      Me.splitter1.MinSize = 40
      Me.splitter1.Name = "splitter1"
      Me.splitter1.RestoreExtent = 205
      Me.splitter1.Size = New System.Drawing.Size(1084, 15)
      Me.splitter1.TabIndex = 8
      Me.ToolTip1.SetToolTip(Me.splitter1, "Presione aquí para colapsar/expandir o cambiar el tamaño de los filtros")
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(616, 30)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(43, 13)
      Me.Label2.TabIndex = 60
      Me.Label2.Text = "Metodo"
      '
      'CRMNovedadesABM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1084, 561)
      Me.Controls.Add(Me.btnConsultar)
      Me.Controls.Add(Me.splitter1)
      Me.Controls.Add(Me.grpFiltros)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.Name = "CRMNovedadesABM"
      Me.Text = "Novedades"
      Me.Controls.SetChildIndex(Me.grpFiltros, 0)
      Me.Controls.SetChildIndex(Me.splitter1, 0)
      Me.Controls.SetChildIndex(Me.dgvDatos, 0)
      Me.Controls.SetChildIndex(Me.btnConsultar, 0)
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpFiltros.ResumeLayout(False)
      Me.grpFiltros.PerformLayout()
      Me.pnlFiltrosInterno.ResumeLayout(False)
      Me.pnlFiltrosInterno.PerformLayout()
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
      Me.gbProyecto.ResumeLayout(False)
      Me.gbProyecto.PerformLayout()
      CType(Me.nudPrioridadHasta, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudPrioridadDesde, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlServicioTecnico.ResumeLayout(False)
      Me.pnlServicioTecnico.PerformLayout()
      Me.pnlAplicacion.ResumeLayout(False)
      Me.pnlAplicacion.PerformLayout()
      Me.pnlVehiculo.ResumeLayout(False)
      Me.pnlVehiculo.PerformLayout()
      Me.pnlFIltrosEstandares.ResumeLayout(False)
      Me.pnlFIltrosEstandares.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grpFiltros As Eniac.Controles.GroupBox
   Friend WithEvents btnConsultar As ButtonConsultar
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAltaHasta As Eniac.Controles.Label
   Friend WithEvents dtpFechaDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAltaDesde As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbUsuarioAsignado As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuarioAsignado As Eniac.Controles.ComboBox
   Friend WithEvents cmbFinalizado As Eniac.Controles.ComboBox
   Friend WithEvents lblFinalizado As Eniac.Controles.Label
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents chbVersion As Eniac.Controles.CheckBox
   Friend WithEvents cmbVersion As Eniac.Controles.ComboBox
   Friend WithEvents chbAplicacion As Eniac.Controles.CheckBox
   Friend WithEvents cmbAplicacion As Eniac.Controles.ComboBox
   Friend WithEvents cmbPriorizado As Eniac.Controles.ComboBox
   Friend WithEvents lblPriodizado As Eniac.Controles.Label
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents bscCodigoFuncionNuevo As Eniac.Controles.Buscador2
   Friend WithEvents chbFuncionNuevo As Eniac.Controles.CheckBox
   Friend WithEvents bscFuncionNuevo As Eniac.Controles.Buscador2
   Friend WithEvents gridContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Private WithEvents GridContextMenuManager1 As Eniac.Win.GridContextMenuManager
   Friend WithEvents chbPrioridad As Eniac.Controles.CheckBox
   Friend WithEvents cmbPrioridad As Eniac.Controles.ComboBox
   Friend WithEvents chbPrioridadProyecto As Eniac.Controles.CheckBox
   Friend WithEvents chbProyecto As Eniac.Controles.CheckBox
   Friend WithEvents bscProyecto As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProyecto As Eniac.Controles.Buscador2
   Friend WithEvents gbProyecto As Eniac.Controles.GroupBox
   Friend WithEvents cmbClasificacionProyecto As Eniac.Controles.ComboBox
   Friend WithEvents chbClasificacionProyecto As Eniac.Controles.CheckBox
   Friend WithEvents chbEstadoProyecto As Eniac.Controles.CheckBox
   Friend WithEvents cmbEstadoProyecto As Eniac.Controles.ComboBox
   Friend WithEvents nudPrioridadHasta As System.Windows.Forms.NumericUpDown
   Friend WithEvents nudPrioridadDesde As System.Windows.Forms.NumericUpDown
   Friend WithEvents FiltersManager1 As Eniac.Win.FilterManager.FilterManager
   Friend WithEvents cmbTipoFechaFiltro As Eniac.Controles.ComboBox
   Friend WithEvents cmbRevisionAdministrativa As Eniac.Controles.ComboBox
   Friend WithEvents lblRevisionAdministrativa As Eniac.Controles.Label
   Friend WithEvents chbUsuarioAlta As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuarioAlta As Eniac.Controles.ComboBox
   Friend WithEvents cmbEnGarantia As Controles.ComboBox
   Friend WithEvents cmbConPrestamo As Controles.ComboBox
   Friend WithEvents cmbEstadoPrestamo As Controles.ComboBox
   Friend WithEvents lblEstadoPrestamo As Controles.Label
   Friend WithEvents lblConPrestamo As Controles.Label
   Friend WithEvents lblEnGarantia As Controles.Label
   Friend WithEvents cmbTipoUsuario As Controles.ComboBox
   Friend WithEvents chbTipoUsuario As Controles.CheckBox
   Friend WithEvents chbNumeroPadre As Controles.CheckBox
   Friend WithEvents txtNumeroPadre As Controles.TextBox
   Friend WithEvents chbSucursal As Controles.CheckBox
   Friend WithEvents cmbSucursal As ComboBoxSucursales
   Friend WithEvents cmbCategoriaReporta As Controles.ComboBox
   Friend WithEvents chbCategoriaReporta As Controles.CheckBox
   Friend WithEvents pnlAplicacion As Controles.Panel
   Friend WithEvents pnlServicioTecnico As Controles.Panel
   Friend WithEvents pnlFIltrosEstandares As Controles.Panel
   Friend WithEvents pnlFiltrosInterno As Controles.Panel
   Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
   Friend WithEvents splitter1 As Misc.UltraSplitter
   Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
   Friend WithEvents pnlVehiculo As Controles.Panel
   Friend WithEvents chbVehiculo As Controles.CheckBox
   Friend WithEvents bscCodigoVehiculo As Controles.Buscador2
   Friend WithEvents cmbCategoriasNovedad As ComboBoxCRMCategorias
   Friend WithEvents lblPriorizado As Controles.Label
   Friend WithEvents cmbCRMEstados As ComboBoxCRMEstadoNovedades
   Friend WithEvents lblEstado As Controles.Label
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents cmbCRMMedios As ComboBoxCRMMediosComunicacionNovedades
   Friend WithEvents cmbCRMMetodos As ComboBoxCRMMetodos
   Friend WithEvents Label2 As Controles.Label
End Class
