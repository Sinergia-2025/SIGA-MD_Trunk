<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposClientesDetalle
   Inherits BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TiposClientesDetalle))
      Me.lblNombreTipoCliente = New Eniac.Controles.Label()
      Me.txtNombreTipoCliente = New Eniac.Controles.TextBox()
      Me.lblIdTipoCliente = New Eniac.Controles.Label()
      Me.txtIdTipoCliente = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(145, 77)
      Me.btnAceptar.TabIndex = 4
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(241, 77)
      Me.btnCancelar.TabIndex = 5
      '
      'lblNombreTipoCliente
      '
      Me.lblNombreTipoCliente.AutoSize = True
      Me.lblNombreTipoCliente.LabelAsoc = Nothing
      Me.lblNombreTipoCliente.Location = New System.Drawing.Point(10, 47)
      Me.lblNombreTipoCliente.Name = "lblNombreTipoCliente"
      Me.lblNombreTipoCliente.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreTipoCliente.TabIndex = 2
      Me.lblNombreTipoCliente.Text = "Nombre"
      '
      'txtNombreTipoCliente
      '
      Me.txtNombreTipoCliente.BindearPropiedadControl = "Text"
      Me.txtNombreTipoCliente.BindearPropiedadEntidad = "NombreTipoCliente"
      Me.txtNombreTipoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreTipoCliente.Formato = ""
      Me.txtNombreTipoCliente.IsDecimal = False
      Me.txtNombreTipoCliente.IsNumber = False
      Me.txtNombreTipoCliente.IsPK = False
      Me.txtNombreTipoCliente.IsRequired = True
      Me.txtNombreTipoCliente.Key = ""
      Me.txtNombreTipoCliente.LabelAsoc = Me.lblNombreTipoCliente
      Me.txtNombreTipoCliente.Location = New System.Drawing.Point(56, 43)
      Me.txtNombreTipoCliente.MaxLength = 30
      Me.txtNombreTipoCliente.Name = "txtNombreTipoCliente"
      Me.txtNombreTipoCliente.Size = New System.Drawing.Size(275, 20)
      Me.txtNombreTipoCliente.TabIndex = 3
      '
      'lblIdTipoCliente
      '
      Me.lblIdTipoCliente.AutoSize = True
      Me.lblIdTipoCliente.LabelAsoc = Nothing
      Me.lblIdTipoCliente.Location = New System.Drawing.Point(14, 19)
      Me.lblIdTipoCliente.Name = "lblIdTipoCliente"
      Me.lblIdTipoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblIdTipoCliente.TabIndex = 0
      Me.lblIdTipoCliente.Text = "Código"
      '
      'txtIdTipoCliente
      '
      Me.txtIdTipoCliente.BindearPropiedadControl = "Text"
      Me.txtIdTipoCliente.BindearPropiedadEntidad = "IdTipoCliente"
      Me.txtIdTipoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoCliente.Formato = ""
      Me.txtIdTipoCliente.IsDecimal = False
      Me.txtIdTipoCliente.IsNumber = True
      Me.txtIdTipoCliente.IsPK = True
      Me.txtIdTipoCliente.IsRequired = True
      Me.txtIdTipoCliente.Key = ""
      Me.txtIdTipoCliente.LabelAsoc = Me.lblIdTipoCliente
      Me.txtIdTipoCliente.Location = New System.Drawing.Point(56, 15)
      Me.txtIdTipoCliente.MaxLength = 9
      Me.txtIdTipoCliente.Name = "txtIdTipoCliente"
      Me.txtIdTipoCliente.Size = New System.Drawing.Size(77, 20)
      Me.txtIdTipoCliente.TabIndex = 1
      Me.txtIdTipoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'TiposClientesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(341, 119)
      Me.Controls.Add(Me.lblNombreTipoCliente)
      Me.Controls.Add(Me.txtNombreTipoCliente)
      Me.Controls.Add(Me.lblIdTipoCliente)
      Me.Controls.Add(Me.txtIdTipoCliente)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "TiposClientesDetalle"
      Me.Text = "Tipo de Cliente"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.txtNombreTipoCliente, 0)
      Me.Controls.SetChildIndex(Me.lblNombreTipoCliente, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombreTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtNombreTipoCliente As Eniac.Controles.TextBox
   Friend WithEvents lblIdTipoCliente As Eniac.Controles.Label
   Friend WithEvents txtIdTipoCliente As Eniac.Controles.TextBox
End Class
