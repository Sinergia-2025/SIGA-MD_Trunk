<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosTiposServiciosDetalle
   Inherits BaseDetalle

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
      Me.lblNombreTipoCliente = New Eniac.Controles.Label()
      Me.txtNombreProductoTipoServicio = New Eniac.Controles.TextBox()
      Me.lblIdTipoCliente = New Eniac.Controles.Label()
      Me.txtIdProductoTipoServicio = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtPrefijo = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(163, 107)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(249, 107)
      Me.btnCancelar.TabIndex = 9
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(62, 107)
      Me.btnCopiar.TabIndex = 10
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(5, 107)
      Me.btnAplicar.TabIndex = 11
      '
      'lblNombreTipoCliente
      '
      Me.lblNombreTipoCliente.AutoSize = True
      Me.lblNombreTipoCliente.LabelAsoc = Nothing
      Me.lblNombreTipoCliente.Location = New System.Drawing.Point(12, 51)
      Me.lblNombreTipoCliente.Name = "lblNombreTipoCliente"
      Me.lblNombreTipoCliente.Size = New System.Drawing.Size(28, 13)
      Me.lblNombreTipoCliente.TabIndex = 0
      Me.lblNombreTipoCliente.Text = "Tipo"
      '
      'txtNombreProductoTipoServicio
      '
      Me.txtNombreProductoTipoServicio.BindearPropiedadControl = "Text"
      Me.txtNombreProductoTipoServicio.BindearPropiedadEntidad = "NombreProductoTipoServicio"
      Me.txtNombreProductoTipoServicio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreProductoTipoServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreProductoTipoServicio.Formato = ""
      Me.txtNombreProductoTipoServicio.IsDecimal = False
      Me.txtNombreProductoTipoServicio.IsNumber = False
      Me.txtNombreProductoTipoServicio.IsPK = False
      Me.txtNombreProductoTipoServicio.IsRequired = True
      Me.txtNombreProductoTipoServicio.Key = ""
      Me.txtNombreProductoTipoServicio.LabelAsoc = Me.lblNombreTipoCliente
      Me.txtNombreProductoTipoServicio.Location = New System.Drawing.Point(91, 48)
      Me.txtNombreProductoTipoServicio.MaxLength = 30
      Me.txtNombreProductoTipoServicio.Name = "txtNombreProductoTipoServicio"
      Me.txtNombreProductoTipoServicio.Size = New System.Drawing.Size(200, 20)
      Me.txtNombreProductoTipoServicio.TabIndex = 1
      '
      'lblIdTipoCliente
      '
      Me.lblIdTipoCliente.AutoSize = True
      Me.lblIdTipoCliente.LabelAsoc = Nothing
      Me.lblIdTipoCliente.Location = New System.Drawing.Point(12, 23)
      Me.lblIdTipoCliente.Name = "lblIdTipoCliente"
      Me.lblIdTipoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoCliente.TabIndex = 6
      Me.lblIdTipoCliente.Text = "Código"
      '
      'txtIdProductoTipoServicio
      '
      Me.txtIdProductoTipoServicio.BindearPropiedadControl = "Text"
      Me.txtIdProductoTipoServicio.BindearPropiedadEntidad = "IdProductoTipoServicio"
      Me.txtIdProductoTipoServicio.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProductoTipoServicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProductoTipoServicio.Formato = ""
      Me.txtIdProductoTipoServicio.IsDecimal = False
      Me.txtIdProductoTipoServicio.IsNumber = True
      Me.txtIdProductoTipoServicio.IsPK = True
      Me.txtIdProductoTipoServicio.IsRequired = True
      Me.txtIdProductoTipoServicio.Key = ""
      Me.txtIdProductoTipoServicio.LabelAsoc = Me.lblIdTipoCliente
      Me.txtIdProductoTipoServicio.Location = New System.Drawing.Point(91, 20)
      Me.txtIdProductoTipoServicio.MaxLength = 9
      Me.txtIdProductoTipoServicio.Name = "txtIdProductoTipoServicio"
      Me.txtIdProductoTipoServicio.Size = New System.Drawing.Size(51, 20)
      Me.txtIdProductoTipoServicio.TabIndex = 7
      Me.txtIdProductoTipoServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(16, 79)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(36, 13)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "Prefijo"
      '
      'txtPrefijo
      '
      Me.txtPrefijo.BindearPropiedadControl = "Text"
      Me.txtPrefijo.BindearPropiedadEntidad = "Prefijo"
      Me.txtPrefijo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPrefijo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPrefijo.Formato = ""
      Me.txtPrefijo.IsDecimal = False
      Me.txtPrefijo.IsNumber = False
      Me.txtPrefijo.IsPK = False
      Me.txtPrefijo.IsRequired = False
      Me.txtPrefijo.Key = ""
      Me.txtPrefijo.LabelAsoc = Me.Label1
      Me.txtPrefijo.Location = New System.Drawing.Point(91, 76)
      Me.txtPrefijo.MaxLength = 30
      Me.txtPrefijo.Name = "txtPrefijo"
      Me.txtPrefijo.Size = New System.Drawing.Size(51, 20)
      Me.txtPrefijo.TabIndex = 13
      '
      'ProductosTiposServiciosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(338, 142)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtPrefijo)
      Me.Controls.Add(Me.lblNombreTipoCliente)
      Me.Controls.Add(Me.txtNombreProductoTipoServicio)
      Me.Controls.Add(Me.lblIdTipoCliente)
      Me.Controls.Add(Me.txtIdProductoTipoServicio)
      Me.Name = "ProductosTiposServiciosDetalle"
      Me.Text = "Tipos de Servicios de Productos"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdProductoTipoServicio, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.txtNombreProductoTipoServicio, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.txtPrefijo, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtNombreProductoTipoServicio As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtIdProductoTipoServicio As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtPrefijo As Eniac.Controles.TextBox
End Class
