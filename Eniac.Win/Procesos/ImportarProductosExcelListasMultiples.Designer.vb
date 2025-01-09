<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportarProductosExcelListasMultiples
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportarProductosExcelListasMultiples))
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.grbPendientes = New System.Windows.Forms.GroupBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtPrefijo = New Eniac.Controles.TextBox()
      Me.cmbDescripcionCorte = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cboAccion = New Eniac.Controles.ComboBox()
      Me.lblAccion = New Eniac.Controles.Label()
      Me.cboEstado = New Eniac.Controles.ComboBox()
      Me.lblEstado = New Eniac.Controles.Label()
      Me.cboDescripcion = New Eniac.Controles.ComboBox()
      Me.lblDescripcionProducto = New Eniac.Controles.Label()
      Me.txtRangoCeldas = New System.Windows.Forms.TextBox()
      Me.lblEjemplos = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.txtArchivoOrigen = New Eniac.Controles.TextBox()
      Me.lblArchivo = New Eniac.Controles.Label()
      Me.btnExaminar = New Eniac.Controles.Button()
      Me.btnMostrar = New Eniac.Controles.Button()
      Me.dgvDetalle = New Eniac.Controles.DataGridView()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImportar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tslTiempoActual = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tslRegistroActual = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tslTotalRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.prbImportando = New System.Windows.Forms.ProgressBar()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.tpLectura = New System.Windows.Forms.TabPage()
      Me.tpPrecios = New System.Windows.Forms.TabPage()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.dgvListasPrecios = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.lblRedondeoPrecioVenta = New Eniac.Controles.Label()
      Me.txtRedondeoPrecioVenta = New Eniac.Controles.TextBox()
      Me.txtAjusteA = New Eniac.Controles.TextBox()
      Me.chbAjusteA = New Eniac.Controles.CheckBox()
      Me.Importa = New System.Windows.Forms.DataGridViewCheckBoxColumn()
      Me.Accion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdProductoNumerico = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreProducto2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreMarca = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreRubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PrecioCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.PrecioVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Moneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CodigoDeBarras = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Mensaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.grbPendientes.SuspendLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.tpLectura.SuspendLayout()
      Me.tpPrecios.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      CType(Me.dgvListasPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'grbPendientes
      '
      Me.grbPendientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbPendientes.Controls.Add(Me.Label2)
      Me.grbPendientes.Controls.Add(Me.txtPrefijo)
      Me.grbPendientes.Controls.Add(Me.cmbDescripcionCorte)
      Me.grbPendientes.Controls.Add(Me.Label1)
      Me.grbPendientes.Controls.Add(Me.cboAccion)
      Me.grbPendientes.Controls.Add(Me.lblAccion)
      Me.grbPendientes.Controls.Add(Me.cboEstado)
      Me.grbPendientes.Controls.Add(Me.lblEstado)
      Me.grbPendientes.Controls.Add(Me.cboDescripcion)
      Me.grbPendientes.Controls.Add(Me.txtRangoCeldas)
      Me.grbPendientes.Controls.Add(Me.lblEjemplos)
      Me.grbPendientes.Controls.Add(Me.Label3)
      Me.grbPendientes.Controls.Add(Me.lblDescripcionProducto)
      Me.grbPendientes.Controls.Add(Me.txtArchivoOrigen)
      Me.grbPendientes.Controls.Add(Me.lblArchivo)
      Me.grbPendientes.Controls.Add(Me.btnExaminar)
      Me.grbPendientes.Controls.Add(Me.btnMostrar)
      Me.grbPendientes.Location = New System.Drawing.Point(3, 6)
      Me.grbPendientes.Name = "grbPendientes"
      Me.grbPendientes.Size = New System.Drawing.Size(961, 133)
      Me.grbPendientes.TabIndex = 0
      Me.grbPendientes.TabStop = False
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(415, 70)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(39, 13)
      Me.Label2.TabIndex = 14
      Me.Label2.Text = "Prefijo:"
      '
      'txtPrefijo
      '
      Me.txtPrefijo.BindearPropiedadControl = Nothing
      Me.txtPrefijo.BindearPropiedadEntidad = Nothing
      Me.txtPrefijo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrefijo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrefijo.Formato = ""
      Me.txtPrefijo.IsDecimal = False
      Me.txtPrefijo.IsNumber = False
      Me.txtPrefijo.IsPK = False
      Me.txtPrefijo.IsRequired = False
      Me.txtPrefijo.Key = ""
      Me.txtPrefijo.LabelAsoc = Nothing
      Me.txtPrefijo.Location = New System.Drawing.Point(455, 66)
      Me.txtPrefijo.MaxLength = 5
      Me.txtPrefijo.Name = "txtPrefijo"
      Me.txtPrefijo.Size = New System.Drawing.Size(52, 20)
      Me.txtPrefijo.TabIndex = 15
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
      Me.cmbDescripcionCorte.Location = New System.Drawing.Point(289, 94)
      Me.cmbDescripcionCorte.Name = "cmbDescripcionCorte"
      Me.cmbDescripcionCorte.Size = New System.Drawing.Size(96, 21)
      Me.cmbDescripcionCorte.TabIndex = 13
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(195, 98)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(91, 13)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "Descripción Corte"
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
      Me.cboAccion.Location = New System.Drawing.Point(72, 93)
      Me.cboAccion.Name = "cboAccion"
      Me.cboAccion.Size = New System.Drawing.Size(96, 21)
      Me.cboAccion.TabIndex = 9
      '
      'lblAccion
      '
      Me.lblAccion.AutoSize = True
      Me.lblAccion.LabelAsoc = Nothing
      Me.lblAccion.Location = New System.Drawing.Point(6, 96)
      Me.lblAccion.Name = "lblAccion"
      Me.lblAccion.Size = New System.Drawing.Size(40, 13)
      Me.lblAccion.TabIndex = 8
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
      Me.cboEstado.Location = New System.Drawing.Point(289, 66)
      Me.cboEstado.Name = "cboEstado"
      Me.cboEstado.Size = New System.Drawing.Size(96, 21)
      Me.cboEstado.TabIndex = 11
      '
      'lblEstado
      '
      Me.lblEstado.AutoSize = True
      Me.lblEstado.LabelAsoc = Nothing
      Me.lblEstado.Location = New System.Drawing.Point(198, 71)
      Me.lblEstado.Name = "lblEstado"
      Me.lblEstado.Size = New System.Drawing.Size(40, 13)
      Me.lblEstado.TabIndex = 10
      Me.lblEstado.Text = "Estado"
      '
      'cboDescripcion
      '
      Me.cboDescripcion.BindearPropiedadControl = Nothing
      Me.cboDescripcion.BindearPropiedadEntidad = Nothing
      Me.cboDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cboDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.cboDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cboDescripcion.FormattingEnabled = True
      Me.cboDescripcion.IsPK = False
      Me.cboDescripcion.IsRequired = False
      Me.cboDescripcion.Key = Nothing
      Me.cboDescripcion.LabelAsoc = Me.lblDescripcionProducto
      Me.cboDescripcion.Location = New System.Drawing.Point(72, 66)
      Me.cboDescripcion.Name = "cboDescripcion"
      Me.cboDescripcion.Size = New System.Drawing.Size(96, 21)
      Me.cboDescripcion.TabIndex = 7
      '
      'lblDescripcionProducto
      '
      Me.lblDescripcionProducto.AutoSize = True
      Me.lblDescripcionProducto.LabelAsoc = Nothing
      Me.lblDescripcionProducto.Location = New System.Drawing.Point(6, 70)
      Me.lblDescripcionProducto.Name = "lblDescripcionProducto"
      Me.lblDescripcionProducto.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcionProducto.TabIndex = 6
      Me.lblDescripcionProducto.Text = "Descripcion"
      '
      'txtRangoCeldas
      '
      Me.txtRangoCeldas.Location = New System.Drawing.Point(766, 22)
      Me.txtRangoCeldas.Name = "txtRangoCeldas"
      Me.txtRangoCeldas.Size = New System.Drawing.Size(89, 20)
      Me.txtRangoCeldas.TabIndex = 4
      Me.txtRangoCeldas.Text = "An : In"
      Me.txtRangoCeldas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'lblEjemplos
      '
      Me.lblEjemplos.AutoSize = True
      Me.lblEjemplos.LabelAsoc = Nothing
      Me.lblEjemplos.Location = New System.Drawing.Point(744, 49)
      Me.lblEjemplos.Name = "lblEjemplos"
      Me.lblEjemplos.Size = New System.Drawing.Size(96, 13)
      Me.lblEjemplos.TabIndex = 5
      Me.lblEjemplos.Text = "Ejemplo:  A1 : I200"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(674, 22)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(88, 13)
      Me.Label3.TabIndex = 3
      Me.Label3.Text = "Rango de celdas"
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
      Me.txtArchivoOrigen.Location = New System.Drawing.Point(55, 26)
      Me.txtArchivoOrigen.Name = "txtArchivoOrigen"
      Me.txtArchivoOrigen.Size = New System.Drawing.Size(499, 20)
      Me.txtArchivoOrigen.TabIndex = 1
      '
      'lblArchivo
      '
      Me.lblArchivo.AutoSize = True
      Me.lblArchivo.LabelAsoc = Nothing
      Me.lblArchivo.Location = New System.Drawing.Point(6, 30)
      Me.lblArchivo.Name = "lblArchivo"
      Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
      Me.lblArchivo.TabIndex = 0
      Me.lblArchivo.Text = "Archivo"
      '
      'btnExaminar
      '
      Me.btnExaminar.Image = Global.Eniac.Win.My.Resources.Resources.folder_32
      Me.btnExaminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnExaminar.Location = New System.Drawing.Point(559, 16)
      Me.btnExaminar.Name = "btnExaminar"
      Me.btnExaminar.Size = New System.Drawing.Size(104, 40)
      Me.btnExaminar.TabIndex = 2
      Me.btnExaminar.Text = "&Examinar..."
      Me.btnExaminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnExaminar.UseVisualStyleBackColor = True
      '
      'btnMostrar
      '
      Me.btnMostrar.Image = Global.Eniac.Win.My.Resources.Resources.zoom_32
      Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnMostrar.Location = New System.Drawing.Point(851, 69)
      Me.btnMostrar.Name = "btnMostrar"
      Me.btnMostrar.Size = New System.Drawing.Size(100, 45)
      Me.btnMostrar.TabIndex = 16
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
      Me.dgvDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Importa, Me.Accion, Me.CodigoProducto, Me.IdProductoNumerico, Me.NombreProducto, Me.NombreProducto2, Me.NombreMarca, Me.NombreRubro, Me.IVA, Me.PrecioCosto, Me.PrecioVenta, Me.Moneda, Me.CodigoDeBarras, Me.Mensaje})
      Me.dgvDetalle.Location = New System.Drawing.Point(3, 145)
      Me.dgvDetalle.Name = "dgvDetalle"
      Me.dgvDetalle.ReadOnly = True
      Me.dgvDetalle.RowHeadersWidth = 15
      Me.dgvDetalle.Size = New System.Drawing.Size(960, 302)
      Me.dgvDetalle.TabIndex = 1
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImportar, Me.toolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(984, 29)
      Me.tstBarra.TabIndex = 0
      Me.tstBarra.Text = "toolStrip1"
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
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
      Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
      Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbSalir.Name = "tsbSalir"
      Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
      Me.tsbSalir.Text = "&Cerrar"
      Me.tsbSalir.ToolTipText = "Cerrar el formulario"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros, Me.tslTiempoActual, Me.tslRegistroActual, Me.tslTotalRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(984, 22)
      Me.StatusStrip1.TabIndex = 5
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(821, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'tslTotalRegistros
      '
      Me.tslTotalRegistros.Name = "tslTotalRegistros"
      Me.tslTotalRegistros.Size = New System.Drawing.Size(64, 17)
      Me.tslTotalRegistros.Text = "0 Registros"
      '
      'prbImportando
      '
      Me.prbImportando.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.prbImportando.Location = New System.Drawing.Point(12, 514)
      Me.prbImportando.Name = "prbImportando"
      Me.prbImportando.Size = New System.Drawing.Size(960, 23)
      Me.prbImportando.Style = System.Windows.Forms.ProgressBarStyle.Continuous
      Me.prbImportando.TabIndex = 3
      '
      'TabControl1
      '
      Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl1.Controls.Add(Me.tpLectura)
      Me.TabControl1.Controls.Add(Me.tpPrecios)
      Me.TabControl1.Location = New System.Drawing.Point(1, 32)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(983, 476)
      Me.TabControl1.TabIndex = 6
      '
      'tpLectura
      '
      Me.tpLectura.BackColor = System.Drawing.SystemColors.Control
      Me.tpLectura.Controls.Add(Me.dgvDetalle)
      Me.tpLectura.Controls.Add(Me.grbPendientes)
      Me.tpLectura.Location = New System.Drawing.Point(4, 22)
      Me.tpLectura.Name = "tpLectura"
      Me.tpLectura.Padding = New System.Windows.Forms.Padding(3)
      Me.tpLectura.Size = New System.Drawing.Size(975, 450)
      Me.tpLectura.TabIndex = 0
      Me.tpLectura.Text = "Lectura"
      '
      'tpPrecios
      '
      Me.tpPrecios.BackColor = System.Drawing.SystemColors.Control
      Me.tpPrecios.Controls.Add(Me.GroupBox2)
      Me.tpPrecios.Location = New System.Drawing.Point(4, 22)
      Me.tpPrecios.Name = "tpPrecios"
      Me.tpPrecios.Padding = New System.Windows.Forms.Padding(3)
      Me.tpPrecios.Size = New System.Drawing.Size(975, 450)
      Me.tpPrecios.TabIndex = 1
      Me.tpPrecios.Text = "Precios"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.dgvListasPrecios)
      Me.GroupBox2.Controls.Add(Me.lblRedondeoPrecioVenta)
      Me.GroupBox2.Controls.Add(Me.txtRedondeoPrecioVenta)
      Me.GroupBox2.Controls.Add(Me.txtAjusteA)
      Me.GroupBox2.Controls.Add(Me.chbAjusteA)
      Me.GroupBox2.Location = New System.Drawing.Point(7, 6)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(640, 305)
      Me.GroupBox2.TabIndex = 2
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Precios de venta"
      '
      'dgvListasPrecios
      '
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dgvListasPrecios.DisplayLayout.Appearance = Appearance1
      Me.dgvListasPrecios.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvListasPrecios.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvListasPrecios.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvListasPrecios.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.dgvListasPrecios.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvListasPrecios.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.dgvListasPrecios.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvListasPrecios.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dgvListasPrecios.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvListasPrecios.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.dgvListasPrecios.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dgvListasPrecios.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.dgvListasPrecios.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dgvListasPrecios.DisplayLayout.Override.CellAppearance = Appearance8
      Me.dgvListasPrecios.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dgvListasPrecios.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvListasPrecios.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.dgvListasPrecios.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.dgvListasPrecios.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dgvListasPrecios.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.dgvListasPrecios.DisplayLayout.Override.RowAppearance = Appearance11
      Me.dgvListasPrecios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dgvListasPrecios.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.dgvListasPrecios.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvListasPrecios.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvListasPrecios.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dgvListasPrecios.Location = New System.Drawing.Point(6, 58)
      Me.dgvListasPrecios.Name = "dgvListasPrecios"
      Me.dgvListasPrecios.Size = New System.Drawing.Size(628, 242)
      Me.dgvListasPrecios.TabIndex = 19
      Me.dgvListasPrecios.Text = "UltraGrid1"
      '
      'lblRedondeoPrecioVenta
      '
      Me.lblRedondeoPrecioVenta.AutoSize = True
      Me.lblRedondeoPrecioVenta.LabelAsoc = Nothing
      Me.lblRedondeoPrecioVenta.Location = New System.Drawing.Point(152, 32)
      Me.lblRedondeoPrecioVenta.Name = "lblRedondeoPrecioVenta"
      Me.lblRedondeoPrecioVenta.Size = New System.Drawing.Size(57, 13)
      Me.lblRedondeoPrecioVenta.TabIndex = 18
      Me.lblRedondeoPrecioVenta.Text = "Redondeo"
      '
      'txtRedondeoPrecioVenta
      '
      Me.txtRedondeoPrecioVenta.BindearPropiedadControl = Nothing
      Me.txtRedondeoPrecioVenta.BindearPropiedadEntidad = Nothing
      Me.txtRedondeoPrecioVenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRedondeoPrecioVenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRedondeoPrecioVenta.Formato = "0"
      Me.txtRedondeoPrecioVenta.IsDecimal = False
      Me.txtRedondeoPrecioVenta.IsNumber = True
      Me.txtRedondeoPrecioVenta.IsPK = False
      Me.txtRedondeoPrecioVenta.IsRequired = False
      Me.txtRedondeoPrecioVenta.Key = ""
      Me.txtRedondeoPrecioVenta.LabelAsoc = Me.lblRedondeoPrecioVenta
      Me.txtRedondeoPrecioVenta.Location = New System.Drawing.Point(214, 28)
      Me.txtRedondeoPrecioVenta.MaxLength = 5
      Me.txtRedondeoPrecioVenta.Name = "txtRedondeoPrecioVenta"
      Me.txtRedondeoPrecioVenta.Size = New System.Drawing.Size(31, 20)
      Me.txtRedondeoPrecioVenta.TabIndex = 17
      Me.txtRedondeoPrecioVenta.Text = "2"
      Me.txtRedondeoPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'txtAjusteA
      '
      Me.txtAjusteA.BindearPropiedadControl = Nothing
      Me.txtAjusteA.BindearPropiedadEntidad = Nothing
      Me.txtAjusteA.ForeColorFocus = System.Drawing.Color.Red
      Me.txtAjusteA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtAjusteA.Formato = "0"
      Me.txtAjusteA.IsDecimal = False
      Me.txtAjusteA.IsNumber = True
      Me.txtAjusteA.IsPK = False
      Me.txtAjusteA.IsRequired = False
      Me.txtAjusteA.Key = ""
      Me.txtAjusteA.LabelAsoc = Nothing
      Me.txtAjusteA.Location = New System.Drawing.Point(360, 28)
      Me.txtAjusteA.MaxLength = 5
      Me.txtAjusteA.Name = "txtAjusteA"
      Me.txtAjusteA.Size = New System.Drawing.Size(31, 20)
      Me.txtAjusteA.TabIndex = 16
      Me.txtAjusteA.Text = "9"
      Me.txtAjusteA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'chbAjusteA
      '
      Me.chbAjusteA.AutoSize = True
      Me.chbAjusteA.BindearPropiedadControl = Nothing
      Me.chbAjusteA.BindearPropiedadEntidad = Nothing
      Me.chbAjusteA.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAjusteA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAjusteA.IsPK = False
      Me.chbAjusteA.IsRequired = False
      Me.chbAjusteA.Key = Nothing
      Me.chbAjusteA.LabelAsoc = Nothing
      Me.chbAjusteA.Location = New System.Drawing.Point(290, 31)
      Me.chbAjusteA.Name = "chbAjusteA"
      Me.chbAjusteA.Size = New System.Drawing.Size(64, 17)
      Me.chbAjusteA.TabIndex = 15
      Me.chbAjusteA.Text = "Ajuste a"
      Me.chbAjusteA.UseVisualStyleBackColor = True
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
      'CodigoProducto
      '
      Me.CodigoProducto.DataPropertyName = "CodigoProducto"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.CodigoProducto.DefaultCellStyle = DataGridViewCellStyle2
      Me.CodigoProducto.HeaderText = "Codigo Prod."
      Me.CodigoProducto.Name = "CodigoProducto"
      Me.CodigoProducto.ReadOnly = True
      '
      'IdProductoNumerico
      '
      Me.IdProductoNumerico.DataPropertyName = "IdProductoNumerico"
      Me.IdProductoNumerico.HeaderText = "Cód. Producto Numérico"
      Me.IdProductoNumerico.Name = "IdProductoNumerico"
      Me.IdProductoNumerico.ReadOnly = True
      '
      'NombreProducto
      '
      Me.NombreProducto.DataPropertyName = "NombreProducto"
      Me.NombreProducto.HeaderText = "Nombre Producto"
      Me.NombreProducto.Name = "NombreProducto"
      Me.NombreProducto.ReadOnly = True
      Me.NombreProducto.Width = 300
      '
      'NombreProducto2
      '
      Me.NombreProducto2.DataPropertyName = "NombreProducto2"
      Me.NombreProducto2.HeaderText = "Nombre Producto Ext."
      Me.NombreProducto2.Name = "NombreProducto2"
      Me.NombreProducto2.ReadOnly = True
      Me.NombreProducto2.Visible = False
      '
      'NombreMarca
      '
      Me.NombreMarca.DataPropertyName = "NombreMarca"
      Me.NombreMarca.HeaderText = "Nombre Marca"
      Me.NombreMarca.Name = "NombreMarca"
      Me.NombreMarca.ReadOnly = True
      Me.NombreMarca.Width = 120
      '
      'NombreRubro
      '
      Me.NombreRubro.DataPropertyName = "NombreRubro"
      Me.NombreRubro.HeaderText = "Nombre Rubro"
      Me.NombreRubro.Name = "NombreRubro"
      Me.NombreRubro.ReadOnly = True
      Me.NombreRubro.Width = 120
      '
      'IVA
      '
      Me.IVA.DataPropertyName = "IVA"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle3.Format = "N2"
      Me.IVA.DefaultCellStyle = DataGridViewCellStyle3
      Me.IVA.HeaderText = "IVA"
      Me.IVA.Name = "IVA"
      Me.IVA.ReadOnly = True
      Me.IVA.Width = 50
      '
      'PrecioCosto
      '
      Me.PrecioCosto.DataPropertyName = "PrecioCosto"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle4.Format = "N2"
      Me.PrecioCosto.DefaultCellStyle = DataGridViewCellStyle4
      Me.PrecioCosto.HeaderText = "Precio Costo"
      Me.PrecioCosto.Name = "PrecioCosto"
      Me.PrecioCosto.ReadOnly = True
      Me.PrecioCosto.Width = 70
      '
      'PrecioVenta
      '
      Me.PrecioVenta.DataPropertyName = "PrecioVenta"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle5.Format = "N2"
      DataGridViewCellStyle5.NullValue = Nothing
      Me.PrecioVenta.DefaultCellStyle = DataGridViewCellStyle5
      Me.PrecioVenta.HeaderText = "Precio Venta"
      Me.PrecioVenta.Name = "PrecioVenta"
      Me.PrecioVenta.ReadOnly = True
      Me.PrecioVenta.Visible = False
      Me.PrecioVenta.Width = 70
      '
      'Moneda
      '
      Me.Moneda.DataPropertyName = "Moneda"
      Me.Moneda.HeaderText = "Moneda"
      Me.Moneda.Name = "Moneda"
      Me.Moneda.ReadOnly = True
      Me.Moneda.Width = 60
      '
      'CodigoDeBarras
      '
      Me.CodigoDeBarras.DataPropertyName = "CodigoDeBarras"
      Me.CodigoDeBarras.HeaderText = "Codigo de Barras"
      Me.CodigoDeBarras.Name = "CodigoDeBarras"
      Me.CodigoDeBarras.ReadOnly = True
      '
      'Mensaje
      '
      Me.Mensaje.DataPropertyName = "Mensaje"
      Me.Mensaje.HeaderText = "Mensaje"
      Me.Mensaje.Name = "Mensaje"
      Me.Mensaje.ReadOnly = True
      Me.Mensaje.Width = 400
      '
      'ImportarProductosExcelListasMultiples
      '
      Me.AcceptButton = Me.btnMostrar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(984, 562)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.prbImportando)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ImportarProductosExcelListasMultiples"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Importar Productos desde Excel para Listas Multiples"
      Me.grbPendientes.ResumeLayout(False)
      Me.grbPendientes.PerformLayout()
      CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.tpLectura.ResumeLayout(False)
      Me.tpPrecios.ResumeLayout(False)
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      CType(Me.dgvListasPrecios, System.ComponentModel.ISupportInitialize).EndInit()
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
   Friend WithEvents lblDescripcionProducto As Eniac.Controles.Label
   Friend WithEvents txtRangoCeldas As System.Windows.Forms.TextBox
   Friend WithEvents lblEjemplos As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cboDescripcion As Eniac.Controles.ComboBox
   Friend WithEvents cboEstado As Eniac.Controles.ComboBox
   Friend WithEvents lblEstado As Eniac.Controles.Label
   Friend WithEvents cboAccion As Eniac.Controles.ComboBox
   Friend WithEvents lblAccion As Eniac.Controles.Label
   Friend WithEvents cmbDescripcionCorte As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtPrefijo As Eniac.Controles.TextBox
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents tpLectura As System.Windows.Forms.TabPage
   Friend WithEvents tpPrecios As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents dgvListasPrecios As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents lblRedondeoPrecioVenta As Eniac.Controles.Label
   Friend WithEvents txtRedondeoPrecioVenta As Eniac.Controles.TextBox
   Friend WithEvents txtAjusteA As Eniac.Controles.TextBox
   Friend WithEvents chbAjusteA As Eniac.Controles.CheckBox
   Friend WithEvents tslTotalRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslTiempoActual As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tslRegistroActual As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents Importa As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents Accion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProductoNumerico As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto2 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreMarca As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreRubro As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IVA As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PrecioCosto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PrecioVenta As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Moneda As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CodigoDeBarras As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Mensaje As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
