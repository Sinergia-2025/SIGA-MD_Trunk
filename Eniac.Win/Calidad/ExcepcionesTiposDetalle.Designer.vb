<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ExcepcionesTiposDetalle
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
      Me.txtNombreExcepcionTipo = New Eniac.Controles.TextBox()
      Me.lblIdTipoCliente = New Eniac.Controles.Label()
      Me.txtIdExcepcionTipo = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(163, 96)
      Me.btnAceptar.TabIndex = 8
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(249, 96)
      Me.btnCancelar.TabIndex = 9
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(62, 96)
      Me.btnCopiar.TabIndex = 10
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(5, 96)
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
      'txtNombreExcepcionTipo
      '
      Me.txtNombreExcepcionTipo.BindearPropiedadControl = "Text"
      Me.txtNombreExcepcionTipo.BindearPropiedadEntidad = "NombreExcepcionTipo"
      Me.txtNombreExcepcionTipo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreExcepcionTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreExcepcionTipo.Formato = ""
      Me.txtNombreExcepcionTipo.IsDecimal = False
      Me.txtNombreExcepcionTipo.IsNumber = False
      Me.txtNombreExcepcionTipo.IsPK = False
      Me.txtNombreExcepcionTipo.IsRequired = True
      Me.txtNombreExcepcionTipo.Key = ""
      Me.txtNombreExcepcionTipo.LabelAsoc = Me.lblNombreTipoCliente
      Me.txtNombreExcepcionTipo.Location = New System.Drawing.Point(91, 48)
      Me.txtNombreExcepcionTipo.MaxLength = 30
      Me.txtNombreExcepcionTipo.Name = "txtNombreExcepcionTipo"
      Me.txtNombreExcepcionTipo.Size = New System.Drawing.Size(200, 20)
      Me.txtNombreExcepcionTipo.TabIndex = 1
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
      'txtIdExcepcionTipo
      '
      Me.txtIdExcepcionTipo.BindearPropiedadControl = "Text"
      Me.txtIdExcepcionTipo.BindearPropiedadEntidad = "IdExcepcionTipo"
      Me.txtIdExcepcionTipo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdExcepcionTipo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdExcepcionTipo.Formato = ""
      Me.txtIdExcepcionTipo.IsDecimal = False
      Me.txtIdExcepcionTipo.IsNumber = True
      Me.txtIdExcepcionTipo.IsPK = True
      Me.txtIdExcepcionTipo.IsRequired = True
      Me.txtIdExcepcionTipo.Key = ""
      Me.txtIdExcepcionTipo.LabelAsoc = Me.lblIdTipoCliente
      Me.txtIdExcepcionTipo.Location = New System.Drawing.Point(91, 20)
      Me.txtIdExcepcionTipo.MaxLength = 9
      Me.txtIdExcepcionTipo.Name = "txtIdExcepcionTipo"
      Me.txtIdExcepcionTipo.Size = New System.Drawing.Size(51, 20)
      Me.txtIdExcepcionTipo.TabIndex = 7
      Me.txtIdExcepcionTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ExcepcionesTiposDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(338, 131)
      Me.Controls.Add(Me.lblNombreTipoCliente)
      Me.Controls.Add(Me.txtNombreExcepcionTipo)
      Me.Controls.Add(Me.lblIdTipoCliente)
      Me.Controls.Add(Me.txtIdExcepcionTipo)
      Me.Name = "ExcepcionesTiposDetalle"
      Me.Text = "Tipos de Desvíos"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdExcepcionTipo, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.txtNombreExcepcionTipo, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoCliente, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtNombreExcepcionTipo As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtIdExcepcionTipo As Eniac.Controles.TextBox
End Class
