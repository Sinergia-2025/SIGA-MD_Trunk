<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarContribuyentesARBA
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.lblCantidadDePadronesARBA = New Eniac.Controles.Label()
      Me.txtCantidadDePadronesARBA = New Eniac.Controles.TextBox()
      Me.dtpPeriodo = New Eniac.Controles.DateTimePicker()
      Me.lblPeriodo = New Eniac.Controles.Label()
      Me.cmbDescripcionCorte = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbPadron = New Eniac.Controles.ComboBox()
      Me.lblPadron = New Eniac.Controles.Label()
      Me.cboAccion = New Eniac.Controles.ComboBox()
      Me.lblAccion = New Eniac.Controles.Label()
      Me.cboEstado = New Eniac.Controles.ComboBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.btnMostrar = New Eniac.Controles.Button()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.Importa = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.IdPadronARBA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PeriodoInformado = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoRegimen = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaPublicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaVigenciaDesde = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaVigenciaHasta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CUIT = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoContribuyente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.AccionARBA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CambioAlicuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Alicuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Mensaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.tsbImportarDirecto = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.prbImportando = New System.Windows.Forms.ProgressBar()
      Me.grbPendientes.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.lblCantidadDePadronesARBA)
      Me.grbPendientes.Controls.Add(Me.txtCantidadDePadronesARBA)
      Me.grbPendientes.Controls.Add(Me.dtpPeriodo)
      Me.grbPendientes.Controls.Add(Me.lblPeriodo)
      Me.grbPendientes.Controls.Add(Me.cmbDescripcionCorte)
      Me.grbPendientes.Controls.Add(Me.Label1)
      Me.grbPendientes.Controls.Add(Me.cmbPadron)
      Me.grbPendientes.Controls.Add(Me.lblPadron)
      Me.grbPendientes.Controls.Add(Me.cboAccion)
      Me.grbPendientes.Controls.Add(Me.lblAccion)
      Me.grbPendientes.Controls.Add(Me.cboEstado)
      Me.grbPendientes.Controls.Add(Me.lblEstado)
      Me.grbPendientes.Controls.Add(Me.txtArchivoOrigen)
      Me.grbPendientes.Controls.Add(Me.lblArchivo)
      Me.grbPendientes.Controls.Add(Me.btnExaminar)
      Me.grbPendientes.Controls.Add(Me.btnMostrar)
      Me.grbPendientes.Location = New System.Drawing.Point(12, 25)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(961, 102)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'lblCantidadDePadronesARBA
      '
      Me.lblCantidadDePadronesARBA.AutoSize = True
      Me.lblCantidadDePadronesARBA.Location = New System.Drawing.Point(631, 71)
      Me.lblCantidadDePadronesARBA.Name = "lblCantidadDePadronesARBA"
      Me.lblCantidadDePadronesARBA.Size = New System.Drawing.Size(144, 13)
      Me.lblCantidadDePadronesARBA.TabIndex = 13
      Me.lblCantidadDePadronesARBA.Text = "Cantidad de Padrones ARBA"
      '
      'txtCantidadDePadronesARBA
      '
      Me.txtCantidadDePadronesARBA.BindearPropiedadControl = Nothing
      Me.txtCantidadDePadronesARBA.BindearPropiedadEntidad = Nothing
      Me.txtCantidadDePadronesARBA.Enabled = False
      Me.txtCantidadDePadronesARBA.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCantidadDePadronesARBA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCantidadDePadronesARBA.Formato = ""
      Me.txtCantidadDePadronesARBA.IsDecimal = False
      Me.txtCantidadDePadronesARBA.IsNumber = True
      Me.txtCantidadDePadronesARBA.IsPK = False
      Me.txtCantidadDePadronesARBA.IsRequired = False
      Me.txtCantidadDePadronesARBA.Key = ""
      Me.txtCantidadDePadronesARBA.LabelAsoc = Me.lblCantidadDePadronesARBA
      Me.txtCantidadDePadronesARBA.Location = New System.Drawing.Point(784, 67)
      Me.txtCantidadDePadronesARBA.MaxLength = 2
      Me.txtCantidadDePadronesARBA.Name = "txtCantidadDePadronesARBA"
      Me.txtCantidadDePadronesARBA.Size = New System.Drawing.Size(35, 20)
      Me.txtCantidadDePadronesARBA.TabIndex = 12
      Me.txtCantidadDePadronesARBA.Tag = "CANTIDADPADRONESARBA"
      Me.txtCantidadDePadronesARBA.Text = "3"
      Me.txtCantidadDePadronesARBA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.BindearPropiedadControl = Nothing
      Me.dtpPeriodo.BindearPropiedadEntidad = Nothing
      Me.dtpPeriodo.CalendarMonthBackground = System.Drawing.Color.Tomato
      Me.dtpPeriodo.CustomFormat = "MM/yyyy"
      Me.dtpPeriodo.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPeriodo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.IsPK = False
      Me.dtpPeriodo.IsRequired = False
      Me.dtpPeriodo.Key = ""
      Me.dtpPeriodo.LabelAsoc = Me.lblPeriodo
      Me.dtpPeriodo.Location = New System.Drawing.Point(707, 35)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(65, 20)
      Me.dtpPeriodo.TabIndex = 10
      '
      'lblPeriodo
      '
      Me.lblPeriodo.AutoSize = True
      Me.lblPeriodo.Location = New System.Drawing.Point(704, 19)
      Me.lblPeriodo.Name = "lblPeriodo"
      Me.lblPeriodo.Size = New System.Drawing.Size(45, 13)
      Me.lblPeriodo.TabIndex = 9
      Me.lblPeriodo.Text = "Período"
      '
      'cmbDescripcionCorte
      '
      Me.cmbDescripcionCorte.BindearPropiedadControl = Nothing
      Me.cmbDescripcionCorte.BindearPropiedadEntidad = Nothing
      Me.cmbDescripcionCorte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbDescripcionCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbDescripcionCorte.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbDescripcionCorte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbDescripcionCorte.FormattingEnabled = True
      Me.cmbDescripcionCorte.IsPK = False
      Me.cmbDescripcionCorte.IsRequired = False
      Me.cmbDescripcionCorte.Key = Nothing
      Me.cmbDescripcionCorte.LabelAsoc = Me.Label1
      Me.cmbDescripcionCorte.Location = New System.Drawing.Point(381, 67)
      Me.cmbDescripcionCorte.Name = "cmbDescripcionCorte"
      Me.cmbDescripcionCorte.Size = New System.Drawing.Size(96, 21)
      Me.cmbDescripcionCorte.TabIndex = 8
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(290, 71)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(91, 13)
      Me.Label1.TabIndex = 7
      Me.Label1.Text = "Descripción Corte"
      '
      'cmbPadron
      '
      Me.cmbPadron.BindearPropiedadControl = Nothing
      Me.cmbPadron.BindearPropiedadEntidad = Nothing
      Me.cmbPadron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPadron.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPadron.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbPadron.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbPadron.FormattingEnabled = True
      Me.cmbPadron.IsPK = False
      Me.cmbPadron.IsRequired = False
      Me.cmbPadron.Items.AddRange(New Object() {"ARBA", "AGIP"})
      Me.cmbPadron.Key = Nothing
      Me.cmbPadron.LabelAsoc = Me.lblPadron
      Me.cmbPadron.Location = New System.Drawing.Point(534, 67)
      Me.cmbPadron.Name = "cmbPadron"
      Me.cmbPadron.Size = New System.Drawing.Size(80, 21)
      Me.cmbPadron.TabIndex = 9
      '
      'lblPadron
      '
      Me.lblPadron.AutoSize = True
      Me.lblPadron.Location = New System.Drawing.Point(491, 71)
      Me.lblPadron.Name = "lblPadron"
      Me.lblPadron.Size = New System.Drawing.Size(41, 13)
      Me.lblPadron.TabIndex = 3
      Me.lblPadron.Text = "Padrón"
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
      Me.cboAccion.Location = New System.Drawing.Point(49, 67)
      Me.cboAccion.Name = "cboAccion"
      Me.cboAccion.Size = New System.Drawing.Size(80, 21)
      Me.cboAccion.TabIndex = 4
      '
      'lblAccion
      '
      Me.lblAccion.AutoSize = True
      Me.lblAccion.Location = New System.Drawing.Point(6, 71)
      Me.lblAccion.Name = "lblAccion"
      Me.lblAccion.Size = New System.Drawing.Size(40, 13)
      Me.lblAccion.TabIndex = 3
      Me.lblAccion.Text = "Accion"
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
      Me.cboEstado.Location = New System.Drawing.Point(184, 67)
      Me.cboEstado.Name = "cboEstado"
      Me.cboEstado.Size = New System.Drawing.Size(96, 21)
      Me.cboEstado.TabIndex = 6
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.Location = New System.Drawing.Point(143, 71)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 5
      Me.lblEstado.Text = "Estado"
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
      Me.txtArchivoOrigen.LabelAsoc = Me.lblArchivo
      Me.txtArchivoOrigen.Location = New System.Drawing.Point(57, 16)
      Me.txtArchivoOrigen.Multiline = True
      Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
      Me.txtArchivoOrigen.ReadOnly = True
      Me.txtArchivoOrigen.Size = New System.Drawing.Size(499, 40)
      Me.txtArchivoOrigen.TabIndex = 1
      '
      'lblArchivo
      '
      Me.lblArchivo.AutoSize = True
      Me.lblArchivo.Location = New System.Drawing.Point(6, 30)
      Me.lblArchivo.Name = "lblArchivo"
      Me.lblArchivo.Size = New System.Drawing.Size(48, 13)
      Me.lblArchivo.TabIndex = 0
      Me.lblArchivo.Text = "Archivos"
      '
      'btnExaminar
      '
      Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.Location = New System.Drawing.Point(562, 16)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(104, 40)
      Me.btnExaminar.TabIndex = 2
      Me.btnExaminar.Text = "&Examinar..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      '
      'btnMostrar
      '
      Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.filter_data_24
      Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnMostrar.Location = New System.Drawing.Point(848, 30)
      Me.btnMostrar.Name = "btnMostrar"
      Me.btnMostrar.Size = New System.Drawing.Size(90, 45)
      Me.btnMostrar.TabIndex = 11
      Me.btnMostrar.Text = "&Mostrar"
      Me.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnMostrar.UseVisualStyleBackColor = False
      '
      'dgvDetalle
      '
      Me.dgvDetalle.AllowUserToAddRows = False
      Me.dgvDetalle.AllowUserToDeleteRows = False
      Me.dgvDetalle.AllowUserToResizeRows = False
      Me.dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Importa, Me.IdPadronARBA, Me.PeriodoInformado, Me.Accion, Me.TipoRegimen, Me.FechaPublicacion, Me.FechaVigenciaDesde, Me.FechaVigenciaHasta, Me.CUIT, Me.TipoContribuyente, Me.AccionARBA, Me.CambioAlicuota, Me.Alicuota, Me.Grupo, Me.Mensaje})
      Me.dgvDetalle.Location = New System.Drawing.Point(12, 133)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersWidth = 15
      Me.dgvDetalle.Size = New System.Drawing.Size(960, 353)
      Me.dgvDetalle.TabIndex = 1
      '
      'Importa
      '
      Me.Importa.DataPropertyName = "Importa"
      Me.Importa.HeaderText = "Pasa"
      Me.Importa.Name = "Importa"
      Me.Importa.ReadOnly = True
      Me.Importa.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.Importa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
      Me.Importa.Width = 40
      '
      'IdPadronARBA
      '
      Me.IdPadronARBA.DataPropertyName = "IdPadronARBA"
      Me.IdPadronARBA.HeaderText = "IdPadronARBA"
      Me.IdPadronARBA.Name = "IdPadronARBA"
      Me.IdPadronARBA.ReadOnly = True
      Me.IdPadronARBA.Visible = False
      '
      'PeriodoInformado
      '
      Me.PeriodoInformado.DataPropertyName = "PeriodoInformado"
      Me.PeriodoInformado.HeaderText = "PeriodoInformado"
      Me.PeriodoInformado.Name = "PeriodoInformado"
      Me.PeriodoInformado.ReadOnly = True
      Me.PeriodoInformado.Visible = False
      '
      'Accion
      '
      Me.Accion.DataPropertyName = "Accion"
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Accion.DefaultCellStyle = DataGridViewCellStyle1
      Me.Accion.HeaderText = "Accion"
      Me.Accion.Name = "Accion"
      Me.Accion.ReadOnly = True
      Me.Accion.Width = 50
      '
      'TipoRegimen
      '
      Me.TipoRegimen.DataPropertyName = "TipoRegimen"
      Me.TipoRegimen.HeaderText = "Régimen"
      Me.TipoRegimen.Name = "TipoRegimen"
      Me.TipoRegimen.ReadOnly = True
      Me.TipoRegimen.Width = 60
      '
      'FechaPublicacion
      '
      Me.FechaPublicacion.DataPropertyName = "FechaPublicacion"
      Me.FechaPublicacion.HeaderText = "Fecha Publicación"
      Me.FechaPublicacion.Name = "FechaPublicacion"
      Me.FechaPublicacion.ReadOnly = True
      Me.FechaPublicacion.Width = 80
      '
      'FechaVigenciaDesde
      '
      Me.FechaVigenciaDesde.DataPropertyName = "FechaVigenciaDesde"
      Me.FechaVigenciaDesde.HeaderText = "Vigencia Desde"
      Me.FechaVigenciaDesde.Name = "FechaVigenciaDesde"
      Me.FechaVigenciaDesde.ReadOnly = True
      Me.FechaVigenciaDesde.Width = 80
      '
      'FechaVigenciaHasta
      '
      Me.FechaVigenciaHasta.DataPropertyName = "FechaVigenciaHasta"
      Me.FechaVigenciaHasta.HeaderText = "Vigencia Hasta"
      Me.FechaVigenciaHasta.Name = "FechaVigenciaHasta"
      Me.FechaVigenciaHasta.ReadOnly = True
      Me.FechaVigenciaHasta.Width = 80
      '
      'CUIT
      '
      Me.CUIT.DataPropertyName = "CUIT"
      Me.CUIT.HeaderText = "C.U.I.T."
      Me.CUIT.Name = "CUIT"
      Me.CUIT.ReadOnly = True
      '
      'TipoContribuyente
      '
      Me.TipoContribuyente.DataPropertyName = "TipoContribuyente"
      Me.TipoContribuyente.HeaderText = "Tipo"
      Me.TipoContribuyente.Name = "TipoContribuyente"
      Me.TipoContribuyente.ReadOnly = True
      Me.TipoContribuyente.Width = 40
      '
      'AccionARBA
      '
      Me.AccionARBA.DataPropertyName = "AccionARBA"
      Me.AccionARBA.HeaderText = "Accion ARBA"
      Me.AccionARBA.Name = "AccionARBA"
      Me.AccionARBA.ReadOnly = True
      Me.AccionARBA.Width = 40
      '
      'CambioAlicuota
      '
      Me.CambioAlicuota.DataPropertyName = "CambioAlicuota"
      Me.CambioAlicuota.HeaderText = "Cambia"
      Me.CambioAlicuota.Name = "CambioAlicuota"
      Me.CambioAlicuota.ReadOnly = True
      Me.CambioAlicuota.Width = 50
      '
      'Alicuota
      '
      Me.Alicuota.DataPropertyName = "Alicuota"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle2.Format = "N2"
      Me.Alicuota.DefaultCellStyle = DataGridViewCellStyle2
      Me.Alicuota.HeaderText = "Alicuota"
      Me.Alicuota.Name = "Alicuota"
      Me.Alicuota.ReadOnly = True
      '
      'Grupo
      '
      Me.Grupo.DataPropertyName = "Grupo"
      Me.Grupo.HeaderText = "Grupo"
      Me.Grupo.Name = "Grupo"
      Me.Grupo.ReadOnly = True
      Me.Grupo.Width = 40
      '
      'Mensaje
      '
      Me.Mensaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
      Me.Mensaje.DataPropertyName = "Mensaje"
      Me.Mensaje.HeaderText = "Mensaje"
      Me.Mensaje.Name = "Mensaje"
      Me.Mensaje.ReadOnly = True
      Me.Mensaje.Width = 72
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.tsbImportarDirecto, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 4
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
      'tsbImportar
      '
      Me.tsbImportar.Image = Global.Eniac.Win.My.Resources.Resources.gear_run
      Me.tsbImportar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImportar.Name = "tsbImportar"
      Me.tsbImportar.Size = New System.Drawing.Size(79, 26)
      Me.tsbImportar.Text = "&Importar"
      '
      'tsbImportarDirecto
      '
      Me.tsbImportarDirecto.Image = Global.Eniac.Win.My.Resources.Resources.database_save_32
      Me.tsbImportarDirecto.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbImportarDirecto.Name = "tsbImportarDirecto"
      Me.tsbImportarDirecto.Size = New System.Drawing.Size(120, 26)
      Me.tsbImportarDirecto.Text = "Importar &Directo"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbSalir
      '
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 514)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
      Me.StatusStrip1.TabIndex = 3
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(969, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'prbImportando
      '
      Me.prbImportando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbImportando.Location = New System.Drawing.Point(12, 488)
      Me.prbImportando.Name = "prbImportando"
      Me.prbImportando.Size = New System.Drawing.Size(960, 23)
      Me.prbImportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbImportando.TabIndex = 2
      '
      'ImportarContribuyentesARBA
      '
      Me.AcceptButton = Me.btnMostrar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 536)
      Me.Controls.Add(Me.prbImportando)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Controls.Add(Me.dgvDetalle)
      Me.Controls.Add(Me.grbPendientes)
      Me.KeyPreview = True
      Me.Name = "ImportarContribuyentesARBA"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Importar de Padrones"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents grbPendientes As System.Windows.Forms.GroupBox
   Friend WithEvents btnMostrar As Eniac.Controles.Button
   Friend WithEvents dgvDetalle As Eniac.Controles.DataGridView
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tsbImportar As System.Windows.Forms.ToolStripButton
   Friend WithEvents btnExaminar As Eniac.Controles.Button
   Friend WithEvents lblArchivo As Eniac.Controles.Label
   Friend WithEvents txtArchivoOrigen As Eniac.Controles.TextBox
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents prbImportando As System.Windows.Forms.ProgressBar
   Friend WithEvents cboEstado As Eniac.Controles.ComboBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents cboAccion As Eniac.Controles.ComboBox
   Friend WithEvents lblAccion As Eniac.Controles.Label
   Friend WithEvents cmbDescripcionCorte As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents dtpPeriodo As Eniac.Controles.DateTimePicker
   Friend WithEvents lblPeriodo As Eniac.Controles.Label
   Friend WithEvents Importa As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents IdPadronARBA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PeriodoInformado As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Accion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoRegimen As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaPublicacion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVigenciaDesde As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVigenciaHasta As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CUIT As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoContribuyente As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents AccionARBA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CambioAlicuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Alicuota As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Mensaje As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents tsbImportarDirecto As System.Windows.Forms.ToolStripButton
   Friend WithEvents cmbPadron As Eniac.Controles.ComboBox
   Friend WithEvents lblPadron As Eniac.Controles.Label
   Friend WithEvents lblCantidadDePadronesARBA As Eniac.Controles.Label
   Friend WithEvents txtCantidadDePadronesARBA As Eniac.Controles.TextBox
End Class
