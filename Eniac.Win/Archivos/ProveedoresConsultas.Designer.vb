<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProveedoresConsultas
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProveedoresConsultas))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.dgvProveedores = New Eniac.Controles.DataGridView()
      Me.NombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.DireccionProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdLocalidadProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreLocalidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CuitProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TelefonoProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoDocProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NroDocProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FaxProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CorreoElectronico = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.LetraFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreCategoriaFiscal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IngresosBrutos = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Observacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.grbConsultar = New System.Windows.Forms.GroupBox()
      Me.lblDireccion = New Eniac.Controles.Label()
      Me.txtDireccion = New Eniac.Controles.TextBox()
      Me.btnBuscar = New Eniac.Controles.Button()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.tstBarra.SuspendLayout()
      CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.stsStado.SuspendLayout()
      Me.grbConsultar.SuspendLayout()
      Me.SuspendLayout()
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator3, Me.tsbRefrescar, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(990, 29)
      Me.tstBarra.TabIndex = 3
      Me.tstBarra.Text = "toolStrip1"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
      '
      'tsbRefrescar
      '
      Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh
      Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbRefrescar.Name = "tsbRefrescar"
      Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
      Me.tsbRefrescar.Text = "&Refrescar (F5)"
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
      'dgvProveedores
      '
      Me.dgvProveedores.AllowUserToAddRows = False
      Me.dgvProveedores.AllowUserToDeleteRows = False
      Me.dgvProveedores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvProveedores.ColumnHeadersHeight = 25
      Me.dgvProveedores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NombreProveedor, Me.DireccionProveedor, Me.IdLocalidadProveedor, Me.NombreLocalidad, Me.CuitProveedor, Me.TelefonoProveedor, Me.TipoDocProveedor, Me.NroDocProveedor, Me.FaxProveedor, Me.CorreoElectronico, Me.IdCategoriaFiscal, Me.LetraFiscal, Me.NombreCategoriaFiscal, Me.IngresosBrutos, Me.Observacion})
      Me.dgvProveedores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvProveedores.Location = New System.Drawing.Point(12, 108)
      Me.dgvProveedores.Name = "dgvProveedores"
      Me.dgvProveedores.RowHeadersWidth = 10
      Me.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvProveedores.Size = New System.Drawing.Size(966, 314)
      Me.dgvProveedores.TabIndex = 1
      '
      'NombreProveedor
      '
      Me.NombreProveedor.DataPropertyName = "NombreProveedor"
      Me.NombreProveedor.HeaderText = "Nombre"
      Me.NombreProveedor.Name = "NombreProveedor"
      Me.NombreProveedor.Width = 180
      '
      'DireccionProveedor
      '
      Me.DireccionProveedor.DataPropertyName = "DireccionProveedor"
      Me.DireccionProveedor.HeaderText = "Direcci�n"
      Me.DireccionProveedor.Name = "DireccionProveedor"
      Me.DireccionProveedor.Width = 180
      '
      'IdLocalidadProveedor
      '
      Me.IdLocalidadProveedor.DataPropertyName = "IdLocalidadProveedor"
      Me.IdLocalidadProveedor.HeaderText = "CP"
      Me.IdLocalidadProveedor.Name = "IdLocalidadProveedor"
      Me.IdLocalidadProveedor.Visible = False
      Me.IdLocalidadProveedor.Width = 45
      '
      'NombreLocalidad
      '
      Me.NombreLocalidad.DataPropertyName = "NombreLocalidad"
      Me.NombreLocalidad.HeaderText = "Localidad"
      Me.NombreLocalidad.Name = "NombreLocalidad"
      Me.NombreLocalidad.Width = 70
      '
      'CuitProveedor
      '
      Me.CuitProveedor.DataPropertyName = "CuitProveedor"
      Me.CuitProveedor.HeaderText = "CuitProveedor"
      Me.CuitProveedor.Name = "CuitProveedor"
      Me.CuitProveedor.Visible = False
      '
      'TelefonoProveedor
      '
      Me.TelefonoProveedor.DataPropertyName = "TelefonoProveedor"
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray
      DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
      Me.TelefonoProveedor.DefaultCellStyle = DataGridViewCellStyle1
      Me.TelefonoProveedor.HeaderText = "Telefono"
      Me.TelefonoProveedor.Name = "TelefonoProveedor"
      Me.TelefonoProveedor.Width = 150
      '
      'TipoDocProveedor
      '
      Me.TipoDocProveedor.DataPropertyName = "TipoDocProveedor"
      Me.TipoDocProveedor.HeaderText = "TipoDocProveedor"
      Me.TipoDocProveedor.Name = "TipoDocProveedor"
      Me.TipoDocProveedor.Visible = False
      '
      'NroDocProveedor
      '
      Me.NroDocProveedor.DataPropertyName = "NroDocProveedor"
      Me.NroDocProveedor.HeaderText = "NroDocProveedor"
      Me.NroDocProveedor.Name = "NroDocProveedor"
      Me.NroDocProveedor.Visible = False
      '
      'FaxProveedor
      '
      Me.FaxProveedor.DataPropertyName = "FaxProveedor"
      Me.FaxProveedor.HeaderText = "FaxProveedor"
      Me.FaxProveedor.Name = "FaxProveedor"
      '
      'CorreoElectronico
      '
      Me.CorreoElectronico.DataPropertyName = "CorreoElectronico"
      Me.CorreoElectronico.HeaderText = "E-Mail"
      Me.CorreoElectronico.Name = "CorreoElectronico"
      Me.CorreoElectronico.Width = 150
      '
      'IdCategoriaFiscal
      '
      Me.IdCategoriaFiscal.DataPropertyName = "IdCategoriaFiscal"
      Me.IdCategoriaFiscal.HeaderText = "IdCategoriaFiscal"
      Me.IdCategoriaFiscal.Name = "IdCategoriaFiscal"
      Me.IdCategoriaFiscal.Visible = False
      '
      'LetraFiscal
      '
      Me.LetraFiscal.DataPropertyName = "LetraFiscal"
      Me.LetraFiscal.HeaderText = "LetraFiscal"
      Me.LetraFiscal.Name = "LetraFiscal"
      Me.LetraFiscal.Visible = False
      '
      'NombreCategoriaFiscal
      '
      Me.NombreCategoriaFiscal.DataPropertyName = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.HeaderText = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.Name = "NombreCategoriaFiscal"
      Me.NombreCategoriaFiscal.Visible = False
      '
      'IngresosBrutos
      '
      Me.IngresosBrutos.DataPropertyName = "IngresosBrutos"
      Me.IngresosBrutos.HeaderText = "IngresosBrutos"
      Me.IngresosBrutos.Name = "IngresosBrutos"
      Me.IngresosBrutos.Visible = False
      '
      'Observacion
      '
      Me.Observacion.DataPropertyName = "Observacion"
      Me.Observacion.HeaderText = "Observacion"
      Me.Observacion.Name = "Observacion"
      Me.Observacion.Width = 105
      '
      'stsStado
      '
      Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
      Me.stsStado.Location = New System.Drawing.Point(0, 425)
      Me.stsStado.Name = "stsStado"
      Me.stsStado.Size = New System.Drawing.Size(990, 22)
      Me.stsStado.TabIndex = 2
      Me.stsStado.Text = "statusStrip1"
      '
      'tssInfo
      '
      Me.tssInfo.Name = "tssInfo"
      Me.tssInfo.Size = New System.Drawing.Size(911, 17)
      Me.tssInfo.Spring = True
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
      'grbConsultar
      '
      Me.grbConsultar.Controls.Add(Me.lblDireccion)
      Me.grbConsultar.Controls.Add(Me.txtDireccion)
      Me.grbConsultar.Controls.Add(Me.btnBuscar)
      Me.grbConsultar.Controls.Add(Me.lblNombre)
      Me.grbConsultar.Controls.Add(Me.txtNombre)
      Me.grbConsultar.Location = New System.Drawing.Point(12, 32)
      Me.grbConsultar.Name = "grbConsultar"
      Me.grbConsultar.Size = New System.Drawing.Size(966, 70)
      Me.grbConsultar.TabIndex = 0
      Me.grbConsultar.TabStop = False
      Me.grbConsultar.Text = "Consultar"
      '
      'lblDireccion
      '
      Me.lblDireccion.AutoSize = True
      Me.lblDireccion.Location = New System.Drawing.Point(285, 24)
      Me.lblDireccion.Name = "lblDireccion"
      Me.lblDireccion.Size = New System.Drawing.Size(52, 13)
      Me.lblDireccion.TabIndex = 4
      Me.lblDireccion.Text = "Direcci�n"
      '
      'txtDireccion
      '
      Me.txtDireccion.BindearPropiedadControl = Nothing
      Me.txtDireccion.BindearPropiedadEntidad = Nothing
      Me.txtDireccion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDireccion.Formato = ""
      Me.txtDireccion.IsDecimal = False
      Me.txtDireccion.IsNumber = False
      Me.txtDireccion.IsPK = False
      Me.txtDireccion.IsRequired = False
      Me.txtDireccion.Key = ""
      Me.txtDireccion.LabelAsoc = Me.lblDireccion
      Me.txtDireccion.Location = New System.Drawing.Point(288, 40)
      Me.txtDireccion.Name = "txtDireccion"
      Me.txtDireccion.Size = New System.Drawing.Size(267, 20)
      Me.txtDireccion.TabIndex = 1
      '
      'btnBuscar
      '
      Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnBuscar.Location = New System.Drawing.Point(849, 19)
      Me.btnBuscar.Name = "btnBuscar"
      Me.btnBuscar.Size = New System.Drawing.Size(111, 45)
      Me.btnBuscar.TabIndex = 2
      Me.btnBuscar.Text = "Buscar"
      Me.btnBuscar.UseVisualStyleBackColor = True
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(12, 24)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 3
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = Nothing
      Me.txtNombre.BindearPropiedadEntidad = Nothing
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = False
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(15, 40)
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(267, 20)
      Me.txtNombre.TabIndex = 0
      '
      'ProveedoresConsultas
      '
      Me.AcceptButton = Me.btnBuscar
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(990, 447)
      Me.Controls.Add(Me.grbConsultar)
      Me.Controls.Add(Me.stsStado)
      Me.Controls.Add(Me.dgvProveedores)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "ProveedoresConsultas"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Consultas de Proveedores"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
      Me.stsStado.ResumeLayout(False)
      Me.stsStado.PerformLayout()
      Me.grbConsultar.ResumeLayout(False)
      Me.grbConsultar.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents dgvProveedores As Eniac.Controles.DataGridView
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents grbConsultar As System.Windows.Forms.GroupBox
   Friend WithEvents btnBuscar As Eniac.Controles.Button
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblDireccion As Eniac.Controles.Label
   Friend WithEvents txtDireccion As Eniac.Controles.TextBox
   Friend WithEvents NombreProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DireccionProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdLocalidadProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreLocalidad As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CuitProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TelefonoProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoDocProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FaxProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CorreoElectronico As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents LetraFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaFiscal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IngresosBrutos As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Observacion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class