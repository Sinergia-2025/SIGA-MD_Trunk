<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarEstadoPedidoTiendaWeb
    Inherits System.Windows.Forms.Form

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
      Me.cmbNuevoEstado = New Eniac.Controles.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmbEstadoAnterior = New Eniac.Controles.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtPedido = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtTienda = New System.Windows.Forms.TextBox()
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'cmbNuevoEstado
      '
      Me.cmbNuevoEstado.BindearPropiedadControl = ""
      Me.cmbNuevoEstado.BindearPropiedadEntidad = ""
      Me.cmbNuevoEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNuevoEstado.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNuevoEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNuevoEstado.FormattingEnabled = True
      Me.cmbNuevoEstado.IsPK = False
      Me.cmbNuevoEstado.IsRequired = True
      Me.cmbNuevoEstado.Key = Nothing
      Me.cmbNuevoEstado.LabelAsoc = Nothing
      Me.cmbNuevoEstado.Location = New System.Drawing.Point(134, 73)
      Me.cmbNuevoEstado.Name = "cmbNuevoEstado"
      Me.cmbNuevoEstado.Size = New System.Drawing.Size(204, 21)
      Me.cmbNuevoEstado.TabIndex = 77
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 76)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(78, 13)
      Me.Label3.TabIndex = 76
      Me.Label3.Text = "Nuevo Estado:"
      '
      'cmbEstadoAnterior
      '
      Me.cmbEstadoAnterior.BindearPropiedadControl = ""
      Me.cmbEstadoAnterior.BindearPropiedadEntidad = ""
      Me.cmbEstadoAnterior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoAnterior.Enabled = False
      Me.cmbEstadoAnterior.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoAnterior.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoAnterior.FormattingEnabled = True
      Me.cmbEstadoAnterior.IsPK = False
      Me.cmbEstadoAnterior.IsRequired = True
      Me.cmbEstadoAnterior.Key = Nothing
      Me.cmbEstadoAnterior.LabelAsoc = Nothing
      Me.cmbEstadoAnterior.Location = New System.Drawing.Point(134, 46)
      Me.cmbEstadoAnterior.Name = "cmbEstadoAnterior"
      Me.cmbEstadoAnterior.Size = New System.Drawing.Size(204, 21)
      Me.cmbEstadoAnterior.TabIndex = 75
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 49)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(82, 13)
      Me.Label2.TabIndex = 74
      Me.Label2.Text = "Estado Anterior:"
      '
      'txtPedido
      '
      Me.txtPedido.Enabled = False
      Me.txtPedido.Location = New System.Drawing.Point(283, 12)
      Me.txtPedido.Name = "txtPedido"
      Me.txtPedido.Size = New System.Drawing.Size(55, 20)
      Me.txtPedido.TabIndex = 71
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(211, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(66, 13)
      Me.Label1.TabIndex = 70
      Me.Label1.Text = "Nro. Pedido:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 15)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 13)
      Me.Label4.TabIndex = 78
      Me.Label4.Text = "Tienda"
      '
      'txtTienda
      '
      Me.txtTienda.Enabled = False
      Me.txtTienda.Location = New System.Drawing.Point(58, 12)
      Me.txtTienda.Name = "txtTienda"
      Me.txtTienda.Size = New System.Drawing.Size(132, 20)
      Me.txtTienda.TabIndex = 79
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.Location = New System.Drawing.Point(176, 112)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(78, 30)
      Me.btnAceptar.TabIndex = 81
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_24
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.Location = New System.Drawing.Point(260, 112)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 80
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'CambiarEstadoPedidoTiendaWeb
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(352, 154)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.txtTienda)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.cmbNuevoEstado)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cmbEstadoAnterior)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtPedido)
      Me.Controls.Add(Me.Label1)
      Me.Name = "CambiarEstadoPedidoTiendaWeb"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Estado Pedido Tienda Web"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbNuevoEstado As Eniac.Controles.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmbEstadoAnterior As Eniac.Controles.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents txtPedido As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents txtTienda As System.Windows.Forms.TextBox
   Protected WithEvents btnAceptar As System.Windows.Forms.Button
   Protected WithEvents btnCancelar As System.Windows.Forms.Button
End Class
