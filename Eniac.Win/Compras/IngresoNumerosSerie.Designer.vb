<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresoNumerosSerie
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Me.dgvNrosSerie = New Eniac.Controles.DataGridView()
      Me.btnAceptar = New Eniac.Controles.Button()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.colNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.OrdenCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.OrdenVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.FechaDevolucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colIdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colVendido = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.colPassword = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.TipoComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.CentroEmisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.NumeroComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
      CType(Me.dgvNrosSerie, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'dgvNrosSerie
      '
      Me.dgvNrosSerie.AllowUserToAddRows = False
      Me.dgvNrosSerie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvNrosSerie.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.dgvNrosSerie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvNrosSerie.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumero, Me.OrdenCompra, Me.OrdenVenta, Me.FechaDevolucion, Me.colProducto, Me.colSucursal, Me.colIdSucursal, Me.colUsuario, Me.colVendido, Me.colPassword, Me.TipoComprobante, Me.Letra, Me.CentroEmisor, Me.NumeroComprobante, Me.Proveedor})
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvNrosSerie.DefaultCellStyle = DataGridViewCellStyle2
      Me.dgvNrosSerie.Location = New System.Drawing.Point(12, 25)
      Me.dgvNrosSerie.Name = "dgvNrosSerie"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.dgvNrosSerie.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
      Me.dgvNrosSerie.RowHeadersVisible = False
      Me.dgvNrosSerie.Size = New System.Drawing.Size(360, 239)
      Me.dgvNrosSerie.TabIndex = 0
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_32
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(282, 280)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(90, 35)
      Me.btnAceptar.TabIndex = 3
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'lblProducto
      '
      Me.lblProducto.AutoSize = True
      Me.lblProducto.LabelAsoc = Nothing
      Me.lblProducto.Location = New System.Drawing.Point(12, 9)
      Me.lblProducto.Name = "lblProducto"
      Me.lblProducto.Size = New System.Drawing.Size(59, 13)
      Me.lblProducto.TabIndex = 4
      Me.lblProducto.Text = "Producto..."
      '
      'colNumero
      '
      Me.colNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      Me.colNumero.DataPropertyName = "NroSerie"
      Me.colNumero.HeaderText = "Número de serie"
      Me.colNumero.MaxInputLength = 50
      Me.colNumero.Name = "colNumero"
      '
      'OrdenCompra
      '
      Me.OrdenCompra.HeaderText = "Orden Compra"
      Me.OrdenCompra.Name = "OrdenCompra"
      Me.OrdenCompra.Visible = False
      '
      'OrdenVenta
      '
      Me.OrdenVenta.HeaderText = "Orden Venta"
      Me.OrdenVenta.Name = "OrdenVenta"
      Me.OrdenVenta.Visible = False
      '
      'FechaDevolucion
      '
      Me.FechaDevolucion.HeaderText = "Fecha de Devolución"
      Me.FechaDevolucion.Name = "FechaDevolucion"
      Me.FechaDevolucion.Visible = False
      '
      'colProducto
      '
      Me.colProducto.DataPropertyName = "Producto"
      Me.colProducto.HeaderText = "Producto"
      Me.colProducto.Name = "colProducto"
      Me.colProducto.Visible = False
      '
      'colSucursal
      '
      Me.colSucursal.DataPropertyName = "Sucursal"
      Me.colSucursal.HeaderText = "Sucursal"
      Me.colSucursal.Name = "colSucursal"
      Me.colSucursal.Visible = False
      '
      'colIdSucursal
      '
      Me.colIdSucursal.DataPropertyName = "IdSucursal"
      Me.colIdSucursal.HeaderText = "IdSucursal"
      Me.colIdSucursal.Name = "colIdSucursal"
      Me.colIdSucursal.Visible = False
      '
      'colUsuario
      '
      Me.colUsuario.DataPropertyName = "Usuario"
      Me.colUsuario.HeaderText = "Usuario"
      Me.colUsuario.Name = "colUsuario"
      Me.colUsuario.Visible = False
      '
      'colVendido
      '
      Me.colVendido.DataPropertyName = "Vendido"
      Me.colVendido.HeaderText = "Vendido"
      Me.colVendido.Name = "colVendido"
      Me.colVendido.Visible = False
      '
      'colPassword
      '
      Me.colPassword.DataPropertyName = "Password"
      Me.colPassword.HeaderText = "Password"
      Me.colPassword.Name = "colPassword"
      Me.colPassword.Visible = False
      '
      'TipoComprobante
      '
      Me.TipoComprobante.DataPropertyName = "TipoComprobante"
      Me.TipoComprobante.HeaderText = "TipoComprobante"
      Me.TipoComprobante.Name = "TipoComprobante"
      Me.TipoComprobante.Visible = False
      '
      'Letra
      '
      Me.Letra.DataPropertyName = "Letra"
      Me.Letra.HeaderText = "Letra"
      Me.Letra.Name = "Letra"
      Me.Letra.Visible = False
      '
      'CentroEmisor
      '
      Me.CentroEmisor.DataPropertyName = "CentroEmisor"
      Me.CentroEmisor.HeaderText = "CentroEmisor"
      Me.CentroEmisor.Name = "CentroEmisor"
      Me.CentroEmisor.Visible = False
      '
      'NumeroComprobante
      '
      Me.NumeroComprobante.DataPropertyName = "NumeroComprobante"
      Me.NumeroComprobante.HeaderText = "NumeroComprobante"
      Me.NumeroComprobante.Name = "NumeroComprobante"
      Me.NumeroComprobante.Visible = False
      '
      'Proveedor
      '
      Me.Proveedor.DataPropertyName = "Proveedor"
      Me.Proveedor.HeaderText = "Proveedor"
      Me.Proveedor.Name = "Proveedor"
      Me.Proveedor.Visible = False
      '
      'IngresoNumerosSerie
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(384, 327)
      Me.Controls.Add(Me.lblProducto)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.dgvNrosSerie)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "IngresoNumerosSerie"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Ingrese los números de serie de..."
      CType(Me.dgvNrosSerie, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents dgvNrosSerie As Eniac.Controles.DataGridView
   Friend WithEvents btnAceptar As Eniac.Controles.Button
   Friend WithEvents lblProducto As Eniac.Controles.Label
   Friend WithEvents colNumero As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents OrdenCompra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents OrdenVenta As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaDevolucion As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colIdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colVendido As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents colPassword As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents TipoComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CentroEmisor As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
