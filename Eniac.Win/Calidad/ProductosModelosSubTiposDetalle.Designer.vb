<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductosModelosSubTiposDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.lblNombreTipoCliente = New Eniac.Controles.Label()
      Me.txtNombreProductoModelo = New Eniac.Controles.TextBox()
      Me.lblIdTipoCliente = New Eniac.Controles.Label()
      Me.txtIdProductoModelo = New Eniac.Controles.TextBox()
      Me.Label3 = New Eniac.Controles.Label()
      Me.cmbTipoModelo = New Eniac.Controles.ComboBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(290, 114)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(376, 114)
      Me.btnCancelar.TabIndex = 4
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(189, 114)
      Me.btnCopiar.TabIndex = 9
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(132, 114)
      Me.btnAplicar.TabIndex = 8
      '
      'lblNombreTipoCliente
      '
      Me.lblNombreTipoCliente.AutoSize = True
      Me.lblNombreTipoCliente.LabelAsoc = Nothing
      Me.lblNombreTipoCliente.Location = New System.Drawing.Point(12, 51)
      Me.lblNombreTipoCliente.Name = "lblNombreTipoCliente"
      Me.lblNombreTipoCliente.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreTipoCliente.TabIndex = 6
      Me.lblNombreTipoCliente.Text = "Descripción"
      '
      'txtNombreProductoModelo
      '
      Me.txtNombreProductoModelo.BindearPropiedadControl = "Text"
      Me.txtNombreProductoModelo.BindearPropiedadEntidad = "NombreProductoModeloSubTipo"
      Me.txtNombreProductoModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreProductoModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreProductoModelo.Formato = ""
      Me.txtNombreProductoModelo.IsDecimal = False
      Me.txtNombreProductoModelo.IsNumber = False
      Me.txtNombreProductoModelo.IsPK = False
      Me.txtNombreProductoModelo.IsRequired = True
      Me.txtNombreProductoModelo.Key = ""
      Me.txtNombreProductoModelo.LabelAsoc = Me.lblNombreTipoCliente
      Me.txtNombreProductoModelo.Location = New System.Drawing.Point(91, 48)
      Me.txtNombreProductoModelo.MaxLength = 30
      Me.txtNombreProductoModelo.Name = "txtNombreProductoModelo"
      Me.txtNombreProductoModelo.Size = New System.Drawing.Size(362, 20)
      Me.txtNombreProductoModelo.TabIndex = 1
      '
      'lblIdTipoCliente
      '
      Me.lblIdTipoCliente.AutoSize = True
      Me.lblIdTipoCliente.LabelAsoc = Nothing
      Me.lblIdTipoCliente.Location = New System.Drawing.Point(12, 23)
      Me.lblIdTipoCliente.Name = "lblIdTipoCliente"
      Me.lblIdTipoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoCliente.TabIndex = 5
      Me.lblIdTipoCliente.Text = "Código"
      '
      'txtIdProductoModelo
      '
      Me.txtIdProductoModelo.BindearPropiedadControl = "Text"
      Me.txtIdProductoModelo.BindearPropiedadEntidad = "IdProductoModeloSubTipo"
      Me.txtIdProductoModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdProductoModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdProductoModelo.Formato = ""
      Me.txtIdProductoModelo.IsDecimal = False
      Me.txtIdProductoModelo.IsNumber = True
      Me.txtIdProductoModelo.IsPK = True
      Me.txtIdProductoModelo.IsRequired = True
      Me.txtIdProductoModelo.Key = ""
      Me.txtIdProductoModelo.LabelAsoc = Me.lblIdTipoCliente
      Me.txtIdProductoModelo.Location = New System.Drawing.Point(91, 20)
      Me.txtIdProductoModelo.MaxLength = 9
      Me.txtIdProductoModelo.Name = "txtIdProductoModelo"
      Me.txtIdProductoModelo.Size = New System.Drawing.Size(51, 20)
      Me.txtIdProductoModelo.TabIndex = 0
      Me.txtIdProductoModelo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.ForeColor = System.Drawing.SystemColors.WindowText
      Me.Label3.LabelAsoc = Nothing
      Me.Label3.Location = New System.Drawing.Point(12, 77)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(28, 13)
      Me.Label3.TabIndex = 12
      Me.Label3.Text = "Tipo"
      '
      'cmbTipoModelo
      '
      Me.cmbTipoModelo.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoModelo.BindearPropiedadEntidad = "IdProductoModeloTipo"
      Me.cmbTipoModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoModelo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoModelo.FormattingEnabled = True
      Me.cmbTipoModelo.IsPK = False
      Me.cmbTipoModelo.IsRequired = False
      Me.cmbTipoModelo.Key = Nothing
      Me.cmbTipoModelo.LabelAsoc = Nothing
      Me.cmbTipoModelo.Location = New System.Drawing.Point(91, 74)
      Me.cmbTipoModelo.Name = "cmbTipoModelo"
      Me.cmbTipoModelo.Size = New System.Drawing.Size(182, 21)
      Me.cmbTipoModelo.TabIndex = 13
      '
      'ProductosModelosSubTiposDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(465, 149)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cmbTipoModelo)
      Me.Controls.Add(Me.lblNombreTipoCliente)
      Me.Controls.Add(Me.txtNombreProductoModelo)
      Me.Controls.Add(Me.lblIdTipoCliente)
      Me.Controls.Add(Me.txtIdProductoModelo)
      Me.Name = "ProductosModelosSubTiposDetalle"
      Me.Text = "SubTipos de Modelos de Productos"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdProductoModelo, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.txtNombreProductoModelo, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoModelo, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtNombreProductoModelo As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtIdProductoModelo As Eniac.Controles.TextBox
   Friend WithEvents Label3 As Controles.Label
   Friend WithEvents cmbTipoModelo As Controles.ComboBox
End Class
