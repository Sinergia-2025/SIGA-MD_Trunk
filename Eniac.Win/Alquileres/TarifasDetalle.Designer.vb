<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TarifasDetalle
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TarifasDetalle))
        Me.grdcostos = New Eniac.Controles.DataGridView()
        Me.IdSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantdias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioAlquiler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblcodigo = New Eniac.Controles.Label()
        Me.lblDetalle = New Eniac.Controles.Label()
        Me.lblCodProducto = New Eniac.Controles.Label()
        Me.lblNombreProducto = New Eniac.Controles.Label()
        Me.btnLimpiarProducto = New Eniac.Controles.Button()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        CType(Me.grdcostos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(228, 391)
        Me.btnAceptar.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(309, 391)
        Me.btnCancelar.TabIndex = 7
        '
        'grdcostos
        '
        Me.grdcostos.AllowUserToAddRows = False
        Me.grdcostos.AllowUserToDeleteRows = False
        Me.grdcostos.AllowUserToResizeColumns = False
        Me.grdcostos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdcostos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcostos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdSucursal, Me.IdProducto, Me.cantdias, Me.PrecioAlquiler})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdcostos.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdcostos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdcostos.Location = New System.Drawing.Point(103, 118)
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
        Me.grdcostos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdcostos.Size = New System.Drawing.Size(183, 256)
        Me.grdcostos.TabIndex = 4
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
        'lblcodigo
        '
        Me.lblcodigo.AutoSize = True
        Me.lblcodigo.Location = New System.Drawing.Point(75, 9)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(50, 13)
        Me.lblcodigo.TabIndex = 8
        Me.lblcodigo.Text = "Producto"
        '
        'lblDetalle
        '
        Me.lblDetalle.AutoSize = True
        Me.lblDetalle.Location = New System.Drawing.Point(22, 118)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(75, 13)
        Me.lblDetalle.TabIndex = 5
        Me.lblDetalle.Text = "Detalle Costos"
        '
        'lblCodProducto
        '
        Me.lblCodProducto.AutoSize = True
        Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCodProducto.Location = New System.Drawing.Point(28, 34)
        Me.lblCodProducto.Name = "lblCodProducto"
        Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
        Me.lblCodProducto.TabIndex = 1
        Me.lblCodProducto.Text = "Código"
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.AutoSize = True
        Me.lblNombreProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNombreProducto.Location = New System.Drawing.Point(28, 63)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProducto.TabIndex = 3
        Me.lblNombreProducto.Text = "Nombre"
        '
        'btnLimpiarProducto
        '
        Me.btnLimpiarProducto.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarProducto.Location = New System.Drawing.Point(360, 24)
        Me.btnLimpiarProducto.Name = "btnLimpiarProducto"
        Me.btnLimpiarProducto.Size = New System.Drawing.Size(29, 32)
        Me.btnLimpiarProducto.TabIndex = 9
        Me.btnLimpiarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarProducto.UseVisualStyleBackColor = True
        '
        'bscProducto2
        '
        Me.bscProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ColumnasVisibles = CType(resources.GetObject("bscProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Nothing
        Me.bscProducto2.Location = New System.Drawing.Point(78, 63)
        Me.bscProducto2.MaxLengh = "32767"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(311, 20)
        Me.bscProducto2.TabIndex = 48
      '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
        Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
        Me.bscCodigoProducto2.ColumnasVisibles = CType(resources.GetObject("bscCodigoProducto2.ColumnasVisibles"), System.Collections.Generic.List(Of Eniac.Controles.ColumnaBuscador))
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(78, 34)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
        Me.bscCodigoProducto2.TabIndex = 47
      '
        'TarifasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 431)
        Me.Controls.Add(Me.bscProducto2)
        Me.Controls.Add(Me.bscCodigoProducto2)
        Me.Controls.Add(Me.btnLimpiarProducto)
        Me.Controls.Add(Me.lblNombreProducto)
        Me.Controls.Add(Me.lblCodProducto)
        Me.Controls.Add(Me.lblDetalle)
        Me.Controls.Add(Me.lblcodigo)
        Me.Controls.Add(Me.grdcostos)
        Me.Name = "TarifasDetalle"
        Me.Text = "Tarifa"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.grdcostos, 0)
        Me.Controls.SetChildIndex(Me.lblcodigo, 0)
        Me.Controls.SetChildIndex(Me.lblDetalle, 0)
        Me.Controls.SetChildIndex(Me.lblCodProducto, 0)
        Me.Controls.SetChildIndex(Me.lblNombreProducto, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiarProducto, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoProducto2, 0)
        Me.Controls.SetChildIndex(Me.bscProducto2, 0)
        CType(Me.grdcostos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
   Friend WithEvents grdcostos As Eniac.Controles.DataGridView
   Friend WithEvents lblcodigo As Eniac.Controles.Label
   Friend WithEvents lblDetalle As Eniac.Controles.Label
    Friend WithEvents lblCodProducto As Eniac.Controles.Label
    Friend WithEvents lblNombreProducto As Eniac.Controles.Label
   Friend WithEvents btnLimpiarProducto As Eniac.Controles.Button
   Friend WithEvents IdSucursal As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdProducto As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents cantdias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioAlquiler As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
    Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
End Class
