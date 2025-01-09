<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichasPendientes1
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FichasPendientes1))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.dgvOperacionesPendientes = New Eniac.Controles.DataGridView()
      Me.btnOk = New Eniac.Controles.Button()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.btnCancelar = New Eniac.Controles.Button()
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NombreSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Emisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Saldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdTipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.IdCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
      CType(Me.dgvOperacionesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dgvOperacionesPendientes
      '
      Me.dgvOperacionesPendientes.AllowUserToAddRows = False
      Me.dgvOperacionesPendientes.AllowUserToDeleteRows = False
      Me.dgvOperacionesPendientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvOperacionesPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvOperacionesPendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSucursal, Me.NombreSucursal, Me.FechaVencimiento, Me.Fecha, Me.Tipo, Me.Letra, Me.Emisor, Me.Numero, Me.Importe, Me.Saldo, Me.IdTipoComprobante, Me.Producto, Me.IdCliente})
      Me.dgvOperacionesPendientes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.dgvOperacionesPendientes.Location = New System.Drawing.Point(0, 0)
      Me.dgvOperacionesPendientes.MultiSelect = False
      Me.dgvOperacionesPendientes.Name = "dgvOperacionesPendientes"
      Me.dgvOperacionesPendientes.RowHeadersVisible = False
      Me.dgvOperacionesPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvOperacionesPendientes.Size = New System.Drawing.Size(614, 292)
      Me.dgvOperacionesPendientes.TabIndex = 0
      '
      'btnOk
      '
      Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnOk.ImageKey = "check2.ico"
      Me.btnOk.ImageList = Me.imgIconos
      Me.btnOk.Location = New System.Drawing.Point(426, 298)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.Size = New System.Drawing.Size(85, 30)
      Me.btnOk.TabIndex = 2
      Me.btnOk.Text = "&Seleccionar"
      Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnOk.UseVisualStyleBackColor = True
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "check2.ico")
      Me.imgIconos.Images.SetKeyName(1, "delete2.ico")
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageKey = "delete2.ico"
      Me.btnCancelar.ImageList = Me.imgIconos
      Me.btnCancelar.Location = New System.Drawing.Point(517, 298)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
      Me.btnCancelar.TabIndex = 1
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "Sucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.Visible = False
      '
      'NombreSucursal
      '
      Me.NombreSucursal.DataPropertyName = "NombreSucursal"
      Me.NombreSucursal.HeaderText = "Sucursal"
      Me.NombreSucursal.Name = "NombreSucursal"
      Me.NombreSucursal.Visible = False
      Me.NombreSucursal.Width = 80
      '
      'FechaVencimiento
      '
      Me.FechaVencimiento.DataPropertyName = "FechaVencimiento"
      DataGridViewCellStyle1.Format = "d"
      DataGridViewCellStyle1.NullValue = Nothing
      Me.FechaVencimiento.DefaultCellStyle = DataGridViewCellStyle1
      Me.FechaVencimiento.HeaderText = "Vto"
      Me.FechaVencimiento.Name = "FechaVencimiento"
      Me.FechaVencimiento.Visible = False
      Me.FechaVencimiento.Width = 70
      '
      'Fecha
      '
      Me.Fecha.DataPropertyName = "Fecha"
      Me.Fecha.HeaderText = "Fecha"
      Me.Fecha.Name = "Fecha"
      Me.Fecha.Width = 70
      '
      'Tipo
      '
      Me.Tipo.DataPropertyName = "Tipo"
      Me.Tipo.HeaderText = "Tipo"
      Me.Tipo.Name = "Tipo"
      Me.Tipo.Visible = False
      Me.Tipo.Width = 70
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
      Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
      Me.Letra.HeaderText = "Letra"
      Me.Letra.Name = "Letra"
      Me.Letra.Visible = False
      Me.Letra.Width = 40
      '
      'Emisor
      '
      Me.Emisor.DataPropertyName = "Emisor"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Emisor.DefaultCellStyle = DataGridViewCellStyle3
      Me.Emisor.HeaderText = "Emisor"
      Me.Emisor.Name = "Emisor"
      Me.Emisor.Visible = False
      Me.Emisor.Width = 40
      '
      'Numero
      '
      Me.Numero.DataPropertyName = "Numero"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.Numero.DefaultCellStyle = DataGridViewCellStyle4
      Me.Numero.HeaderText = "Numero"
      Me.Numero.Name = "Numero"
      Me.Numero.Width = 70
      '
      'Importe
      '
      Me.Importe.DataPropertyName = "Importe"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle5.Format = "N2"
      DataGridViewCellStyle5.NullValue = Nothing
      Me.Importe.DefaultCellStyle = DataGridViewCellStyle5
      Me.Importe.HeaderText = "Importe"
      Me.Importe.Name = "Importe"
      Me.Importe.Width = 80
      '
      'Saldo
      '
      Me.Saldo.DataPropertyName = "Saldo"
      DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle6.Format = "N2"
      DataGridViewCellStyle6.NullValue = Nothing
      Me.Saldo.DefaultCellStyle = DataGridViewCellStyle6
      Me.Saldo.HeaderText = "Saldo"
      Me.Saldo.Name = "Saldo"
      Me.Saldo.Width = 80
      '
      'IdTipoComprobante
      '
      Me.IdTipoComprobante.DataPropertyName = "IdTipoComprobante"
      Me.IdTipoComprobante.HeaderText = "IdTipoComprobante"
      Me.IdTipoComprobante.Name = "IdTipoComprobante"
      Me.IdTipoComprobante.Visible = False
      '
      'Producto
      '
      Me.Producto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.Producto.DataPropertyName = "Producto"
      Me.Producto.HeaderText = "Producto"
      Me.Producto.Name = "Producto"
      '
      'IdCliente
      '
      Me.IdCliente.DataPropertyName = "IdCliente"
      Me.IdCliente.HeaderText = "IdCliente"
      Me.IdCliente.Name = "IdCliente"
      Me.IdCliente.Visible = False
      '
      'FichasPendientes1
      '
      Me.AcceptButton = Me.btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.btnCancelar
      Me.ClientSize = New System.Drawing.Size(614, 338)
      Me.Controls.Add(Me.btnOk)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.dgvOperacionesPendientes)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FichasPendientes1"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Operaciones"
      CType(Me.dgvOperacionesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents dgvOperacionesPendientes As Eniac.Controles.DataGridView
   Friend WithEvents btnOk As Eniac.Controles.Button
   Friend WithEvents btnCancelar As Eniac.Controles.Button
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Emisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Importe As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Saldo As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdCliente As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
