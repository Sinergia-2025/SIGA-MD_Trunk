<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SincronizacionSubidaMovil
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
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chbSoloProductosConStock = New Eniac.Controles.CheckBox()
      Me.chbPrecioConIVA = New Eniac.Controles.CheckBox()
      Me.cmbDireccionCliente = New Eniac.Controles.ComboBox()
      Me.lblDireccionCliente = New Eniac.Controles.Label()
      Me.cmbIncluir = New Eniac.Controles.ComboBox()
      Me.lblIncluir = New Eniac.Controles.Label()
      Me.cmbNombreCliente = New Eniac.Controles.ComboBox()
      Me.lblNombreCliente = New Eniac.Controles.Label()
      Me.grpAvance = New System.Windows.Forms.GroupBox()
      Me.txtMensajeAvance = New Eniac.Controles.Label()
      Me.txtUrlAvance = New Eniac.Controles.Label()
      Me.txtMetodoAvance = New Eniac.Controles.Label()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tssVersionAPI = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbExportar = New System.Windows.Forms.ToolStripButton()
      Me.tsbContinuar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.lblFechaUltimaSincronizacion = New Eniac.Controles.Label()
      Me.pnlEstado = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSimovilCobranzaTipoDireccion = New Eniac.Controles.Label()
        Me.lblSimovilCobranzaNombreCliente = New Eniac.Controles.Label()
        Me.lblSimovilCobranzaSucursales = New Eniac.Controles.Label()
        Me.cmbSimovilCobranzaSucursales = New Eniac.Controles.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.grpAvance.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblSimovilCobranzaSucursales)
        Me.GroupBox1.Controls.Add(Me.cmbSimovilCobranzaSucursales)
        Me.GroupBox1.Controls.Add(Me.lblSimovilCobranzaNombreCliente)
        Me.GroupBox1.Controls.Add(Me.lblSimovilCobranzaTipoDireccion)
        Me.GroupBox1.Controls.Add(Me.chbSoloProductosConStock)
        Me.GroupBox1.Controls.Add(Me.chbPrecioConIVA)
        Me.GroupBox1.Controls.Add(Me.cmbDireccionCliente)
        Me.GroupBox1.Controls.Add(Me.lblDireccionCliente)
        Me.GroupBox1.Controls.Add(Me.cmbIncluir)
        Me.GroupBox1.Controls.Add(Me.lblIncluir)
        Me.GroupBox1.Controls.Add(Me.cmbNombreCliente)
        Me.GroupBox1.Controls.Add(Me.lblNombreCliente)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 149)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Exporta"
        '
        'chbSoloProductosConStock
        '
        Me.chbSoloProductosConStock.AutoSize = True
        Me.chbSoloProductosConStock.BindearPropiedadControl = Nothing
        Me.chbSoloProductosConStock.BindearPropiedadEntidad = Nothing
        Me.chbSoloProductosConStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSoloProductosConStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSoloProductosConStock.IsPK = False
        Me.chbSoloProductosConStock.IsRequired = False
        Me.chbSoloProductosConStock.Key = Nothing
        Me.chbSoloProductosConStock.LabelAsoc = Nothing
        Me.chbSoloProductosConStock.Location = New System.Drawing.Point(226, 123)
        Me.chbSoloProductosConStock.Name = "chbSoloProductosConStock"
        Me.chbSoloProductosConStock.Size = New System.Drawing.Size(150, 17)
        Me.chbSoloProductosConStock.TabIndex = 11
        Me.chbSoloProductosConStock.Text = "Solo Productos con Stock"
        '
        'chbPrecioConIVA
        '
        Me.chbPrecioConIVA.AutoSize = True
        Me.chbPrecioConIVA.BindearPropiedadControl = Nothing
        Me.chbPrecioConIVA.BindearPropiedadEntidad = Nothing
        Me.chbPrecioConIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPrecioConIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPrecioConIVA.IsPK = False
        Me.chbPrecioConIVA.IsRequired = False
        Me.chbPrecioConIVA.Key = Nothing
        Me.chbPrecioConIVA.LabelAsoc = Nothing
        Me.chbPrecioConIVA.Location = New System.Drawing.Point(97, 123)
        Me.chbPrecioConIVA.Name = "chbPrecioConIVA"
        Me.chbPrecioConIVA.Size = New System.Drawing.Size(123, 17)
        Me.chbPrecioConIVA.TabIndex = 10
        Me.chbPrecioConIVA.Text = "Precios c/Impuestos"
        '
        'cmbDireccionCliente
        '
        Me.cmbDireccionCliente.BindearPropiedadControl = Nothing
        Me.cmbDireccionCliente.BindearPropiedadEntidad = Nothing
        Me.cmbDireccionCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDireccionCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDireccionCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDireccionCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDireccionCliente.FormattingEnabled = True
        Me.cmbDireccionCliente.IsPK = False
        Me.cmbDireccionCliente.IsRequired = False
        Me.cmbDireccionCliente.Key = Nothing
        Me.cmbDireccionCliente.LabelAsoc = Me.lblDireccionCliente
        Me.cmbDireccionCliente.Location = New System.Drawing.Point(97, 69)
        Me.cmbDireccionCliente.Name = "cmbDireccionCliente"
        Me.cmbDireccionCliente.Size = New System.Drawing.Size(148, 21)
        Me.cmbDireccionCliente.TabIndex = 6
        '
        'lblDireccionCliente
        '
        Me.lblDireccionCliente.AutoSize = True
        Me.lblDireccionCliente.LabelAsoc = Me.lblSimovilCobranzaTipoDireccion
        Me.lblDireccionCliente.Location = New System.Drawing.Point(251, 73)
        Me.lblDireccionCliente.Name = "lblDireccionCliente"
        Me.lblDireccionCliente.Size = New System.Drawing.Size(55, 13)
        Me.lblDireccionCliente.TabIndex = 7
        Me.lblDireccionCliente.Text = "del cliente"
        '
        'cmbIncluir
        '
        Me.cmbIncluir.BindearPropiedadControl = Nothing
        Me.cmbIncluir.BindearPropiedadEntidad = Nothing
        Me.cmbIncluir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIncluir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIncluir.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIncluir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIncluir.FormattingEnabled = True
        Me.cmbIncluir.IsPK = False
        Me.cmbIncluir.IsRequired = False
        Me.cmbIncluir.Key = Nothing
        Me.cmbIncluir.LabelAsoc = Me.lblIncluir
        Me.cmbIncluir.Location = New System.Drawing.Point(97, 15)
        Me.cmbIncluir.Name = "cmbIncluir"
        Me.cmbIncluir.Size = New System.Drawing.Size(148, 21)
        Me.cmbIncluir.TabIndex = 1
        '
        'lblIncluir
        '
        Me.lblIncluir.AutoSize = True
        Me.lblIncluir.LabelAsoc = Nothing
        Me.lblIncluir.Location = New System.Drawing.Point(12, 19)
        Me.lblIncluir.Name = "lblIncluir"
        Me.lblIncluir.Size = New System.Drawing.Size(75, 13)
        Me.lblIncluir.TabIndex = 0
        Me.lblIncluir.Text = "Incluir Clientes"
        '
        'cmbNombreCliente
        '
        Me.cmbNombreCliente.BindearPropiedadControl = Nothing
        Me.cmbNombreCliente.BindearPropiedadEntidad = Nothing
        Me.cmbNombreCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbNombreCliente.FormattingEnabled = True
        Me.cmbNombreCliente.IsPK = False
        Me.cmbNombreCliente.IsRequired = False
        Me.cmbNombreCliente.Key = Nothing
        Me.cmbNombreCliente.LabelAsoc = Me.lblNombreCliente
        Me.cmbNombreCliente.Location = New System.Drawing.Point(97, 42)
        Me.cmbNombreCliente.Name = "cmbNombreCliente"
        Me.cmbNombreCliente.Size = New System.Drawing.Size(148, 21)
        Me.cmbNombreCliente.TabIndex = 3
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.LabelAsoc = Me.lblSimovilCobranzaNombreCliente
        Me.lblNombreCliente.Location = New System.Drawing.Point(251, 46)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(55, 13)
        Me.lblNombreCliente.TabIndex = 4
        Me.lblNombreCliente.Text = "del cliente"
        '
        'grpAvance
        '
        Me.grpAvance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpAvance.Controls.Add(Me.txtMensajeAvance)
        Me.grpAvance.Controls.Add(Me.txtUrlAvance)
        Me.grpAvance.Controls.Add(Me.txtMetodoAvance)
        Me.grpAvance.Location = New System.Drawing.Point(12, 180)
        Me.grpAvance.Name = "grpAvance"
        Me.grpAvance.Size = New System.Drawing.Size(415, 72)
        Me.grpAvance.TabIndex = 1
        Me.grpAvance.TabStop = False
        Me.grpAvance.Text = "Avance"
        Me.grpAvance.Visible = False
        '
        'txtMensajeAvance
        '
        Me.txtMensajeAvance.AutoSize = True
        Me.txtMensajeAvance.LabelAsoc = Nothing
        Me.txtMensajeAvance.Location = New System.Drawing.Point(6, 16)
        Me.txtMensajeAvance.Name = "txtMensajeAvance"
        Me.txtMensajeAvance.Size = New System.Drawing.Size(47, 13)
        Me.txtMensajeAvance.TabIndex = 0
        Me.txtMensajeAvance.Text = "Mensaje"
        '
        'txtUrlAvance
        '
        Me.txtUrlAvance.AutoSize = True
        Me.txtUrlAvance.LabelAsoc = Nothing
        Me.txtUrlAvance.Location = New System.Drawing.Point(6, 52)
        Me.txtUrlAvance.Name = "txtUrlAvance"
        Me.txtUrlAvance.Size = New System.Drawing.Size(20, 13)
        Me.txtUrlAvance.TabIndex = 2
        Me.txtUrlAvance.Text = "Url"
        '
        'txtMetodoAvance
        '
        Me.txtMetodoAvance.AutoSize = True
        Me.txtMetodoAvance.LabelAsoc = Nothing
        Me.txtMetodoAvance.Location = New System.Drawing.Point(6, 34)
        Me.txtMetodoAvance.Name = "txtMetodoAvance"
        Me.txtMetodoAvance.Size = New System.Drawing.Size(43, 13)
        Me.txtMetodoAvance.TabIndex = 1
        Me.txtMetodoAvance.Text = "Metodo"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tssVersionAPI, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 261)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(827, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(748, 17)
        Me.tssInfo.Spring = True
        Me.tssInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tssVersionAPI
        '
        Me.tssVersionAPI.Name = "tssVersionAPI"
        Me.tssVersionAPI.Size = New System.Drawing.Size(0, 17)
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
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.toolStripSeparator3, Me.tsbExportar, Me.tsbContinuar, Me.ToolStripSeparator1, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(827, 29)
        Me.tstBarra.TabIndex = 3
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
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbExportar
        '
        Me.tsbExportar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
        Me.tsbExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportar.Name = "tsbExportar"
        Me.tsbExportar.Size = New System.Drawing.Size(93, 26)
        Me.tsbExportar.Text = "&Subir Datos"
        Me.tsbExportar.ToolTipText = "Subir Datos"
        '
        'tsbContinuar
        '
        Me.tsbContinuar.Enabled = False
        Me.tsbContinuar.Image = Global.Eniac.Win.My.Resources.Resources.export_database_save_32
        Me.tsbContinuar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbContinuar.Name = "tsbContinuar"
        Me.tsbContinuar.Size = New System.Drawing.Size(86, 26)
        Me.tsbContinuar.Text = "&Continuar"
        Me.tsbContinuar.ToolTipText = "Continuar Subida de Datos"
        Me.tsbContinuar.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
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
        'lblFechaUltimaSincronizacion
        '
        Me.lblFechaUltimaSincronizacion.AutoSize = True
        Me.lblFechaUltimaSincronizacion.LabelAsoc = Nothing
        Me.lblFechaUltimaSincronizacion.Location = New System.Drawing.Point(433, 32)
        Me.lblFechaUltimaSincronizacion.Name = "lblFechaUltimaSincronizacion"
        Me.lblFechaUltimaSincronizacion.Size = New System.Drawing.Size(140, 13)
        Me.lblFechaUltimaSincronizacion.TabIndex = 4
        Me.lblFechaUltimaSincronizacion.Text = "Fecha última sincronización:"
        '
        'pnlEstado
        '
        Me.pnlEstado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEstado.AutoScroll = True
        Me.pnlEstado.Location = New System.Drawing.Point(436, 46)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(379, 206)
        Me.pnlEstado.TabIndex = 5
        '
        'lblSimovilCobranzaTipoDireccion
        '
        Me.lblSimovilCobranzaTipoDireccion.AutoSize = True
        Me.lblSimovilCobranzaTipoDireccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSimovilCobranzaTipoDireccion.LabelAsoc = Nothing
        Me.lblSimovilCobranzaTipoDireccion.Location = New System.Drawing.Point(12, 73)
        Me.lblSimovilCobranzaTipoDireccion.Name = "lblSimovilCobranzaTipoDireccion"
        Me.lblSimovilCobranzaTipoDireccion.Size = New System.Drawing.Size(52, 13)
        Me.lblSimovilCobranzaTipoDireccion.TabIndex = 5
        Me.lblSimovilCobranzaTipoDireccion.Text = "Dirección"
        '
        'lblSimovilCobranzaNombreCliente
        '
        Me.lblSimovilCobranzaNombreCliente.AutoSize = True
        Me.lblSimovilCobranzaNombreCliente.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSimovilCobranzaNombreCliente.LabelAsoc = Nothing
        Me.lblSimovilCobranzaNombreCliente.Location = New System.Drawing.Point(12, 46)
        Me.lblSimovilCobranzaNombreCliente.Name = "lblSimovilCobranzaNombreCliente"
        Me.lblSimovilCobranzaNombreCliente.Size = New System.Drawing.Size(79, 13)
        Me.lblSimovilCobranzaNombreCliente.TabIndex = 2
        Me.lblSimovilCobranzaNombreCliente.Text = "Nombre Cliente"
        '
        'lblSimovilCobranzaSucursales
        '
        Me.lblSimovilCobranzaSucursales.AutoSize = True
        Me.lblSimovilCobranzaSucursales.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSimovilCobranzaSucursales.LabelAsoc = Nothing
        Me.lblSimovilCobranzaSucursales.Location = New System.Drawing.Point(12, 100)
        Me.lblSimovilCobranzaSucursales.Name = "lblSimovilCobranzaSucursales"
        Me.lblSimovilCobranzaSucursales.Size = New System.Drawing.Size(59, 13)
        Me.lblSimovilCobranzaSucursales.TabIndex = 8
        Me.lblSimovilCobranzaSucursales.Text = "Sucursales"
        '
        'cmbSimovilCobranzaSucursales
        '
        Me.cmbSimovilCobranzaSucursales.BindearPropiedadControl = Nothing
        Me.cmbSimovilCobranzaSucursales.BindearPropiedadEntidad = Nothing
        Me.cmbSimovilCobranzaSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSimovilCobranzaSucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSimovilCobranzaSucursales.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSimovilCobranzaSucursales.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSimovilCobranzaSucursales.FormattingEnabled = True
        Me.cmbSimovilCobranzaSucursales.IsPK = False
        Me.cmbSimovilCobranzaSucursales.IsRequired = False
        Me.cmbSimovilCobranzaSucursales.Items.AddRange(New Object() {"Derecha a Izquierda", "Izquierda a Derecha"})
        Me.cmbSimovilCobranzaSucursales.Key = Nothing
        Me.cmbSimovilCobranzaSucursales.LabelAsoc = Me.lblSimovilCobranzaSucursales
        Me.cmbSimovilCobranzaSucursales.Location = New System.Drawing.Point(97, 96)
        Me.cmbSimovilCobranzaSucursales.Name = "cmbSimovilCobranzaSucursales"
        Me.cmbSimovilCobranzaSucursales.Size = New System.Drawing.Size(148, 21)
        Me.cmbSimovilCobranzaSucursales.TabIndex = 9
        '
        'SincronizacionSubidaMovil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 283)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.lblFechaUltimaSincronizacion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpAvance)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "SincronizacionSubidaMovil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sincronización - Subir a la Web para Móvil"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpAvance.ResumeLayout(False)
        Me.grpAvance.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbExportar As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsbContinuar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtMensajeAvance As Eniac.Controles.Label
   Friend WithEvents txtMetodoAvance As Eniac.Controles.Label
   Friend WithEvents txtUrlAvance As Eniac.Controles.Label
   Friend WithEvents grpAvance As System.Windows.Forms.GroupBox
   Friend WithEvents cmbNombreCliente As Eniac.Controles.ComboBox
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents cmbDireccionCliente As Eniac.Controles.ComboBox
   Friend WithEvents lblDireccionCliente As Eniac.Controles.Label
   Protected WithEvents tssVersionAPI As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents cmbIncluir As Eniac.Controles.ComboBox
   Friend WithEvents lblIncluir As Eniac.Controles.Label
   Friend WithEvents chbPrecioConIVA As Eniac.Controles.CheckBox
   Friend WithEvents lblFechaUltimaSincronizacion As Eniac.Controles.Label
   Friend WithEvents pnlEstado As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents chbSoloProductosConStock As Eniac.Controles.CheckBox
    Friend WithEvents lblSimovilCobranzaTipoDireccion As Controles.Label
    Friend WithEvents lblSimovilCobranzaNombreCliente As Controles.Label
    Friend WithEvents lblSimovilCobranzaSucursales As Controles.Label
    Friend WithEvents cmbSimovilCobranzaSucursales As Controles.ComboBox
End Class
