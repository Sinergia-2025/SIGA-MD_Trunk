<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AFIPReferenciaTransferenciaDetalle
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
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblNombreAFIPRefTransfencia = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblDescripcionAFIPRefTransferencia = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.lblIdAFIPRefTransferencia = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(258, 112)
        Me.btnAceptar.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(344, 112)
        Me.btnCancelar.TabIndex = 7
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(157, 112)
        Me.btnCopiar.TabIndex = 9
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(100, 112)
        Me.btnAplicar.TabIndex = 8
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreReferenciaTransferencia"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombreAFIPRefTransfencia
        Me.txtNombre.Location = New System.Drawing.Point(109, 43)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(315, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblNombreAFIPRefTransfencia
        '
        Me.lblNombreAFIPRefTransfencia.AutoSize = True
        Me.lblNombreAFIPRefTransfencia.LabelAsoc = Nothing
        Me.lblNombreAFIPRefTransfencia.Location = New System.Drawing.Point(41, 46)
        Me.lblNombreAFIPRefTransfencia.Name = "lblNombreAFIPRefTransfencia"
        Me.lblNombreAFIPRefTransfencia.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreAFIPRefTransfencia.TabIndex = 2
        Me.lblNombreAFIPRefTransfencia.Text = "Nombre"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "DescripcionReferenciaTransferencia"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = ""
        Me.txtDescripcion.LabelAsoc = Me.lblDescripcionAFIPRefTransferencia
        Me.txtDescripcion.Location = New System.Drawing.Point(109, 69)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(315, 20)
        Me.txtDescripcion.TabIndex = 5
        '
        'lblDescripcionAFIPRefTransferencia
        '
        Me.lblDescripcionAFIPRefTransferencia.AutoSize = True
        Me.lblDescripcionAFIPRefTransferencia.LabelAsoc = Nothing
        Me.lblDescripcionAFIPRefTransferencia.Location = New System.Drawing.Point(41, 72)
        Me.lblDescripcionAFIPRefTransferencia.Name = "lblDescripcionAFIPRefTransferencia"
        Me.lblDescripcionAFIPRefTransferencia.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcionAFIPRefTransferencia.TabIndex = 4
        Me.lblDescripcionAFIPRefTransferencia.Text = "Descripción"
        '
        'txtId
        '
        Me.txtId.BindearPropiedadControl = "Text"
        Me.txtId.BindearPropiedadEntidad = "IdAFIPReferenciaTransferencia"
        Me.txtId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtId.Formato = ""
        Me.txtId.IsDecimal = False
        Me.txtId.IsNumber = False
        Me.txtId.IsPK = True
        Me.txtId.IsRequired = True
        Me.txtId.Key = ""
        Me.txtId.LabelAsoc = Me.lblIdAFIPRefTransferencia
        Me.txtId.Location = New System.Drawing.Point(109, 19)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(45, 20)
        Me.txtId.TabIndex = 1
        '
        'lblIdAFIPRefTransferencia
        '
        Me.lblIdAFIPRefTransferencia.AutoSize = True
        Me.lblIdAFIPRefTransferencia.LabelAsoc = Nothing
        Me.lblIdAFIPRefTransferencia.Location = New System.Drawing.Point(41, 21)
        Me.lblIdAFIPRefTransferencia.Name = "lblIdAFIPRefTransferencia"
        Me.lblIdAFIPRefTransferencia.Size = New System.Drawing.Size(40, 13)
        Me.lblIdAFIPRefTransferencia.TabIndex = 0
        Me.lblIdAFIPRefTransferencia.Text = "Código"
        '
        'AFIPReferenciaTransferenciaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 147)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.lblDescripcionAFIPRefTransferencia)
        Me.Controls.Add(Me.lblNombreAFIPRefTransfencia)
        Me.Controls.Add(Me.lblIdAFIPRefTransferencia)
        Me.Name = "AFIPReferenciaTransferenciaDetalle"
        Me.Text = "AFIPReferenciaTransferenciaDetalle"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblIdAFIPRefTransferencia, 0)
        Me.Controls.SetChildIndex(Me.lblNombreAFIPRefTransfencia, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcionAFIPRefTransferencia, 0)
        Me.Controls.SetChildIndex(Me.txtId, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNombre As Controles.TextBox
   Friend WithEvents lblNombreAFIPRefTransfencia As Controles.Label
   Friend WithEvents txtDescripcion As Controles.TextBox
   Friend WithEvents lblDescripcionAFIPRefTransferencia As Controles.Label
   Friend WithEvents txtId As Controles.TextBox
   Friend WithEvents lblIdAFIPRefTransferencia As Controles.Label
End Class
