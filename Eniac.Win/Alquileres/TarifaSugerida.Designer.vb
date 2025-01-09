<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarifaSugerida
   Inherits Eniac.Win.BaseDetalle

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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.grdcostos = New Eniac.Controles.DataGridView
      Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.NombreProducto = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.cantdias = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PrecioAlquiler = New System.Windows.Forms.DataGridViewTextBoxColumn
      CType(Me.grdcostos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(37, 127)
      Me.btnAceptar.Visible = False
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(123, 127)
      Me.btnCancelar.Visible = False
      '
      'grdcostos
      '
      Me.grdcostos.AllowUserToAddRows = False
      Me.grdcostos.AllowUserToDeleteRows = False
      Me.grdcostos.AllowUserToResizeColumns = False
      Me.grdcostos.AllowUserToResizeRows = False
      Me.grdcostos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.grdcostos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.grdcostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.grdcostos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSucursal, Me.IdProducto, Me.NombreProducto, Me.cantdias, Me.PrecioAlquiler})
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.grdcostos.DefaultCellStyle = DataGridViewCellStyle4
      Me.grdcostos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
      Me.grdcostos.Location = New System.Drawing.Point(12, 12)
      Me.grdcostos.MultiSelect = False
      Me.grdcostos.Name = "grdcostos"
      DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.grdcostos.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
      Me.grdcostos.RowHeadersVisible = False
      Me.grdcostos.RowHeadersWidth = 4
      Me.grdcostos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.grdcostos.Size = New System.Drawing.Size(183, 256)
      Me.grdcostos.TabIndex = 57
      '
      'IdSucursal
      '
      Me.IdSucursal.DataPropertyName = "IdSucursal"
      Me.IdSucursal.HeaderText = "IdSucursal"
      Me.IdSucursal.Name = "IdSucursal"
      Me.IdSucursal.Visible = False
      '
      'IdProducto
      '
      Me.IdProducto.DataPropertyName = "IdProducto"
      Me.IdProducto.HeaderText = "IdProducto"
      Me.IdProducto.Name = "IdProducto"
      Me.IdProducto.Visible = False
      '
      'NombreProducto
      '
      Me.NombreProducto.DataPropertyName = "NombreProducto"
      Me.NombreProducto.HeaderText = "NombreProducto"
      Me.NombreProducto.Name = "NombreProducto"
      Me.NombreProducto.Visible = False
      '
      'cantdias
      '
      Me.cantdias.DataPropertyName = "cantdias"
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      Me.cantdias.DefaultCellStyle = DataGridViewCellStyle2
      Me.cantdias.HeaderText = "Cant. Días"
      Me.cantdias.Name = "cantdias"
      Me.cantdias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
      Me.cantdias.Width = 80
      '
      'PrecioAlquiler
      '
      Me.PrecioAlquiler.DataPropertyName = "PrecioAlquiler"
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
      DataGridViewCellStyle3.Format = "N2"
      Me.PrecioAlquiler.DefaultCellStyle = DataGridViewCellStyle3
      Me.PrecioAlquiler.HeaderText = "Precio [$]"
      Me.PrecioAlquiler.Name = "PrecioAlquiler"
      Me.PrecioAlquiler.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      '
      'TarifaSugerida
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(205, 282)
      Me.Controls.Add(Me.grdcostos)
      Me.Name = "TarifaSugerida"
      Me.Text = "Tarifa Sugerida"
      Me.Controls.SetChildIndex(Me.grdcostos, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      CType(Me.grdcostos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents grdcostos As Eniac.Controles.DataGridView
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cantdias As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PrecioAlquiler As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
