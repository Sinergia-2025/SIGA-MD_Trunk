<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReservasABM
   Inherits BaseABM2

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
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReservasABM))
      Me.grpFiltros = New System.Windows.Forms.GroupBox()
      Me.txtNumero = New Eniac.Controles.TextBox()
      Me.chbNumero = New Eniac.Controles.CheckBox()
      Me.chbFecha = New Eniac.Controles.CheckBox()
      Me.chbEstado = New Eniac.Controles.CheckBox()
      Me.cmbEstadoNovedad = New Eniac.Controles.ComboBox()
      Me.chbUsuarioAsignado = New Eniac.Controles.CheckBox()
      Me.cmbUsuarioAsignado = New Eniac.Controles.ComboBox()
      Me.bscCliente = New Eniac.Controles.Buscador2()
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.chbCliente = New Eniac.Controles.CheckBox()
      Me.lblCodigoCliente = New Eniac.Controles.Label()
      Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpFechaHasta = New Eniac.Controles.DateTimePicker()
      Me.lblFechaAltaHasta = New Eniac.Controles.Label()
      Me.dtpFechaDesde = New Eniac.Controles.DateTimePicker()
      Me.lblFechaAltaDesde = New Eniac.Controles.Label()
      Me.cmbFinalizado = New Eniac.Controles.ComboBox()
      Me.lblGrabanLibro = New Eniac.Controles.Label()
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpFiltros.SuspendLayout()
      Me.SuspendLayout()
      '
      'dgvDatos
      '
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
      Me.dgvDatos.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
      Me.dgvDatos.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dotted
      Me.dgvDatos.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvDatos.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvDatos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dgvDatos.Location = New System.Drawing.Point(0, 150)
      Me.dgvDatos.Size = New System.Drawing.Size(1084, 389)
      Me.dgvDatos.TabIndex = 1
      '
      'grpFiltros
      '
      Me.grpFiltros.Controls.Add(Me.cmbFinalizado)
      Me.grpFiltros.Controls.Add(Me.lblGrabanLibro)
      Me.grpFiltros.Controls.Add(Me.txtNumero)
      Me.grpFiltros.Controls.Add(Me.chbNumero)
      Me.grpFiltros.Controls.Add(Me.chbFecha)
      Me.grpFiltros.Controls.Add(Me.chbEstado)
      Me.grpFiltros.Controls.Add(Me.cmbEstadoNovedad)
      Me.grpFiltros.Controls.Add(Me.chbUsuarioAsignado)
      Me.grpFiltros.Controls.Add(Me.cmbUsuarioAsignado)
      Me.grpFiltros.Controls.Add(Me.bscCliente)
      Me.grpFiltros.Controls.Add(Me.lblCodigoCliente)
      Me.grpFiltros.Controls.Add(Me.bscCodigoCliente)
      Me.grpFiltros.Controls.Add(Me.lblNombreCliente)
      Me.grpFiltros.Controls.Add(Me.chbCliente)
      Me.grpFiltros.Controls.Add(Me.btnConsultar)
      Me.grpFiltros.Controls.Add(Me.chkMesCompleto)
      Me.grpFiltros.Controls.Add(Me.dtpFechaHasta)
      Me.grpFiltros.Controls.Add(Me.dtpFechaDesde)
      Me.grpFiltros.Controls.Add(Me.lblFechaAltaHasta)
      Me.grpFiltros.Controls.Add(Me.lblFechaAltaDesde)
      Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
      Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
      Me.grpFiltros.Name = "grpFiltros"
      Me.grpFiltros.Size = New System.Drawing.Size(1084, 121)
      Me.grpFiltros.TabIndex = 0
      Me.grpFiltros.TabStop = False
      Me.grpFiltros.Text = "Filtros"
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
      Me.txtNumero.LabelAsoc = Nothing
      Me.txtNumero.Location = New System.Drawing.Point(531, 90)
      Me.txtNumero.MaxLength = 8
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.Size = New System.Drawing.Size(59, 20)
      Me.txtNumero.TabIndex = 26
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
      Me.chbNumero.Location = New System.Drawing.Point(467, 92)
      Me.chbNumero.Name = "chbNumero"
      Me.chbNumero.Size = New System.Drawing.Size(63, 17)
      Me.chbNumero.TabIndex = 25
      Me.chbNumero.Text = "Numero"
      Me.chbNumero.UseVisualStyleBackColor = True
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
      Me.chbFecha.Location = New System.Drawing.Point(18, 22)
      Me.chbFecha.Name = "chbFecha"
      Me.chbFecha.Size = New System.Drawing.Size(56, 17)
      Me.chbFecha.TabIndex = 4
      Me.chbFecha.Text = "Fecha"
      Me.chbFecha.UseVisualStyleBackColor = True
      '
      'chbEstado
      '
      Me.chbEstado.AutoSize = True
      Me.chbEstado.BindearPropiedadControl = Nothing
      Me.chbEstado.BindearPropiedadEntidad = Nothing
      Me.chbEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEstado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEstado.IsPK = False
      Me.chbEstado.IsRequired = False
      Me.chbEstado.Key = Nothing
      Me.chbEstado.LabelAsoc = Nothing
      Me.chbEstado.Location = New System.Drawing.Point(250, 92)
      Me.chbEstado.Name = "chbEstado"
      Me.chbEstado.Size = New System.Drawing.Size(59, 17)
      Me.chbEstado.TabIndex = 17
      Me.chbEstado.Text = "Estado"
      Me.chbEstado.UseVisualStyleBackColor = True
      '
      'cmbEstadoNovedad
      '
      Me.cmbEstadoNovedad.BindearPropiedadControl = "SelectedValue"
      Me.cmbEstadoNovedad.BindearPropiedadEntidad = "EstadoNovedad.IdEstadoNovedad"
      Me.cmbEstadoNovedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoNovedad.Enabled = False
      Me.cmbEstadoNovedad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoNovedad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoNovedad.FormattingEnabled = True
      Me.cmbEstadoNovedad.IsPK = False
      Me.cmbEstadoNovedad.IsRequired = False
      Me.cmbEstadoNovedad.Key = Nothing
      Me.cmbEstadoNovedad.LabelAsoc = Nothing
      Me.cmbEstadoNovedad.Location = New System.Drawing.Point(314, 90)
      Me.cmbEstadoNovedad.Name = "cmbEstadoNovedad"
      Me.cmbEstadoNovedad.Size = New System.Drawing.Size(140, 21)
      Me.cmbEstadoNovedad.TabIndex = 18
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
      Me.chbUsuarioAsignado.Location = New System.Drawing.Point(17, 92)
      Me.chbUsuarioAsignado.Name = "chbUsuarioAsignado"
      Me.chbUsuarioAsignado.Size = New System.Drawing.Size(65, 17)
      Me.chbUsuarioAsignado.TabIndex = 0
      Me.chbUsuarioAsignado.Text = "Usuario "
      Me.chbUsuarioAsignado.UseVisualStyleBackColor = True
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
      Me.cmbUsuarioAsignado.LabelAsoc = Nothing
      Me.cmbUsuarioAsignado.Location = New System.Drawing.Point(95, 90)
      Me.cmbUsuarioAsignado.Name = "cmbUsuarioAsignado"
      Me.cmbUsuarioAsignado.Size = New System.Drawing.Size(140, 21)
      Me.cmbUsuarioAsignado.TabIndex = 1
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
      Me.bscCliente.LabelAsoc = Me.lblNombreCliente
      Me.bscCliente.Location = New System.Drawing.Point(189, 60)
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
      Me.bscCliente.TabIndex = 14
      '
      'lblNombreCliente
      '
      Me.lblNombreCliente.AutoSize = True
      Me.lblNombreCliente.LabelAsoc = Me.chbCliente
      Me.lblNombreCliente.Location = New System.Drawing.Point(186, 45)
      Me.lblNombreCliente.Name = "lblNombreCliente"
      Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreCliente.TabIndex = 13
      Me.lblNombreCliente.Text = "&Nombre"
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
      Me.chbCliente.Location = New System.Drawing.Point(17, 63)
      Me.chbCliente.Name = "chbCliente"
      Me.chbCliente.Size = New System.Drawing.Size(58, 17)
      Me.chbCliente.TabIndex = 10
      Me.chbCliente.Text = "Cliente"
      Me.chbCliente.UseVisualStyleBackColor = True
      '
      'lblCodigoCliente
      '
      Me.lblCodigoCliente.AutoSize = True
      Me.lblCodigoCliente.LabelAsoc = Me.chbCliente
      Me.lblCodigoCliente.Location = New System.Drawing.Point(95, 45)
      Me.lblCodigoCliente.Name = "lblCodigoCliente"
      Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigoCliente.TabIndex = 11
      Me.lblCodigoCliente.Text = "Código"
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
      Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
      Me.bscCodigoCliente.Location = New System.Drawing.Point(95, 60)
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
      'btnConsultar
      '
      Me.btnConsultar.Image = CType(resources.GetObject("btnConsultar.Image"), System.Drawing.Image)
      Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnConsultar.Location = New System.Drawing.Point(637, 48)
      Me.btnConsultar.Name = "btnConsultar"
      Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
      Me.btnConsultar.TabIndex = 30
      Me.btnConsultar.Text = "&Consultar"
      Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnConsultar.UseVisualStyleBackColor = True
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
      Me.chkMesCompleto.Location = New System.Drawing.Point(92, 22)
      Me.chkMesCompleto.Name = "chkMesCompleto"
      Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
      Me.chkMesCompleto.TabIndex = 5
      Me.chkMesCompleto.Text = "Mes Completo"
      Me.chkMesCompleto.UseVisualStyleBackColor = True
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
      Me.dtpFechaHasta.Location = New System.Drawing.Point(398, 20)
      Me.dtpFechaHasta.Name = "dtpFechaHasta"
      Me.dtpFechaHasta.Size = New System.Drawing.Size(125, 20)
      Me.dtpFechaHasta.TabIndex = 9
      '
      'lblFechaAltaHasta
      '
      Me.lblFechaAltaHasta.AutoSize = True
      Me.lblFechaAltaHasta.Enabled = False
      Me.lblFechaAltaHasta.LabelAsoc = Me.chkMesCompleto
      Me.lblFechaAltaHasta.Location = New System.Drawing.Point(357, 24)
      Me.lblFechaAltaHasta.Name = "lblFechaAltaHasta"
      Me.lblFechaAltaHasta.Size = New System.Drawing.Size(35, 13)
      Me.lblFechaAltaHasta.TabIndex = 8
      Me.lblFechaAltaHasta.Text = "Hasta"
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
      Me.dtpFechaDesde.Location = New System.Drawing.Point(230, 20)
      Me.dtpFechaDesde.Name = "dtpFechaDesde"
      Me.dtpFechaDesde.Size = New System.Drawing.Size(125, 20)
      Me.dtpFechaDesde.TabIndex = 7
      '
      'lblFechaAltaDesde
      '
      Me.lblFechaAltaDesde.AutoSize = True
      Me.lblFechaAltaDesde.LabelAsoc = Me.chkMesCompleto
      Me.lblFechaAltaDesde.Location = New System.Drawing.Point(186, 24)
      Me.lblFechaAltaDesde.Name = "lblFechaAltaDesde"
      Me.lblFechaAltaDesde.Size = New System.Drawing.Size(38, 13)
      Me.lblFechaAltaDesde.TabIndex = 6
      Me.lblFechaAltaDesde.Text = "Desde"
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
      Me.cmbFinalizado.LabelAsoc = Me.lblGrabanLibro
      Me.cmbFinalizado.Location = New System.Drawing.Point(507, 62)
      Me.cmbFinalizado.Name = "cmbFinalizado"
      Me.cmbFinalizado.Size = New System.Drawing.Size(83, 21)
      Me.cmbFinalizado.TabIndex = 32
      '
      'lblGrabanLibro
      '
      Me.lblGrabanLibro.AutoSize = True
      Me.lblGrabanLibro.LabelAsoc = Nothing
      Me.lblGrabanLibro.Location = New System.Drawing.Point(436, 66)
      Me.lblGrabanLibro.Name = "lblGrabanLibro"
      Me.lblGrabanLibro.Size = New System.Drawing.Size(54, 13)
      Me.lblGrabanLibro.TabIndex = 31
      Me.lblGrabanLibro.Text = "Finalizado"
      '
      'ReservasABM
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1084, 561)
      Me.Controls.Add(Me.grpFiltros)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.Name = "ReservasABM"
      Me.Text = "Reservas"
      Me.Controls.SetChildIndex(Me.grpFiltros, 0)
      Me.Controls.SetChildIndex(Me.dgvDatos, 0)
      CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpFiltros.ResumeLayout(False)
      Me.grpFiltros.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grpFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpFechaHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAltaHasta As Eniac.Controles.Label
   Friend WithEvents dtpFechaDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaAltaDesde As Eniac.Controles.Label
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbEstado As Eniac.Controles.CheckBox
   Friend WithEvents cmbEstadoNovedad As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuarioAsignado As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuarioAsignado As Eniac.Controles.ComboBox
   Friend WithEvents chbFecha As Eniac.Controles.CheckBox
   Friend WithEvents txtNumero As Eniac.Controles.TextBox
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents cmbFinalizado As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
End Class
