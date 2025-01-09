<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfPedidosWeb
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.GroupBox7 = New System.Windows.Forms.GroupBox()
      Me.lblEstadoPedidoPendienteWebPOST = New Eniac.Controles.Label()
      Me.txtEstadoPedidoPendienteWebPOST = New Eniac.Controles.TextBox()
      Me.lblEstadoPedidoEnviadoWebPOST = New Eniac.Controles.Label()
      Me.txtEstadoPedidoEnviadoWebPOST = New Eniac.Controles.TextBox()
      Me.txtPedidosURLWebPOST = New Eniac.Controles.TextBox()
      Me.lblPedidosURLWebPOST = New Eniac.Controles.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtURLGETProposal = New Eniac.Controles.TextBox()
        Me.lblURLGETProposal = New Eniac.Controles.Label()
        Me.txtTOKENTalkiu = New Eniac.Controles.TextBox()
        Me.lblTOKENTalkiu = New Eniac.Controles.Label()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lblEstadoPedidoPendienteWebPOST)
        Me.GroupBox7.Controls.Add(Me.txtEstadoPedidoPendienteWebPOST)
        Me.GroupBox7.Controls.Add(Me.lblEstadoPedidoEnviadoWebPOST)
        Me.GroupBox7.Controls.Add(Me.txtEstadoPedidoEnviadoWebPOST)
        Me.GroupBox7.Controls.Add(Me.txtPedidosURLWebPOST)
        Me.GroupBox7.Controls.Add(Me.lblPedidosURLWebPOST)
        Me.GroupBox7.Location = New System.Drawing.Point(7, 55)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(433, 101)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "POST"
        '
        'lblEstadoPedidoPendienteWebPOST
        '
        Me.lblEstadoPedidoPendienteWebPOST.AutoSize = True
        Me.lblEstadoPedidoPendienteWebPOST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadoPedidoPendienteWebPOST.LabelAsoc = Nothing
        Me.lblEstadoPedidoPendienteWebPOST.Location = New System.Drawing.Point(19, 48)
        Me.lblEstadoPedidoPendienteWebPOST.Name = "lblEstadoPedidoPendienteWebPOST"
        Me.lblEstadoPedidoPendienteWebPOST.Size = New System.Drawing.Size(133, 13)
        Me.lblEstadoPedidoPendienteWebPOST.TabIndex = 2
        Me.lblEstadoPedidoPendienteWebPOST.Text = "Estado de Pedido a Enviar"
        '
        'txtEstadoPedidoPendienteWebPOST
        '
        Me.txtEstadoPedidoPendienteWebPOST.BindearPropiedadControl = Nothing
        Me.txtEstadoPedidoPendienteWebPOST.BindearPropiedadEntidad = Nothing
        Me.txtEstadoPedidoPendienteWebPOST.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstadoPedidoPendienteWebPOST.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstadoPedidoPendienteWebPOST.Formato = ""
        Me.txtEstadoPedidoPendienteWebPOST.IsDecimal = False
        Me.txtEstadoPedidoPendienteWebPOST.IsNumber = False
        Me.txtEstadoPedidoPendienteWebPOST.IsPK = False
        Me.txtEstadoPedidoPendienteWebPOST.IsRequired = False
        Me.txtEstadoPedidoPendienteWebPOST.Key = ""
        Me.txtEstadoPedidoPendienteWebPOST.LabelAsoc = Me.lblEstadoPedidoPendienteWebPOST
        Me.txtEstadoPedidoPendienteWebPOST.Location = New System.Drawing.Point(158, 45)
        Me.txtEstadoPedidoPendienteWebPOST.MaxLength = 20
        Me.txtEstadoPedidoPendienteWebPOST.Name = "txtEstadoPedidoPendienteWebPOST"
        Me.txtEstadoPedidoPendienteWebPOST.Size = New System.Drawing.Size(122, 20)
        Me.txtEstadoPedidoPendienteWebPOST.TabIndex = 3
        '
        'lblEstadoPedidoEnviadoWebPOST
        '
        Me.lblEstadoPedidoEnviadoWebPOST.AutoSize = True
        Me.lblEstadoPedidoEnviadoWebPOST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblEstadoPedidoEnviadoWebPOST.LabelAsoc = Nothing
        Me.lblEstadoPedidoEnviadoWebPOST.Location = New System.Drawing.Point(19, 75)
        Me.lblEstadoPedidoEnviadoWebPOST.Name = "lblEstadoPedidoEnviadoWebPOST"
        Me.lblEstadoPedidoEnviadoWebPOST.Size = New System.Drawing.Size(133, 13)
        Me.lblEstadoPedidoEnviadoWebPOST.TabIndex = 4
        Me.lblEstadoPedidoEnviadoWebPOST.Text = "Estado de Pedido Enviado"
        '
        'txtEstadoPedidoEnviadoWebPOST
        '
        Me.txtEstadoPedidoEnviadoWebPOST.BindearPropiedadControl = Nothing
        Me.txtEstadoPedidoEnviadoWebPOST.BindearPropiedadEntidad = Nothing
        Me.txtEstadoPedidoEnviadoWebPOST.ForeColorFocus = System.Drawing.Color.Red
        Me.txtEstadoPedidoEnviadoWebPOST.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtEstadoPedidoEnviadoWebPOST.Formato = ""
        Me.txtEstadoPedidoEnviadoWebPOST.IsDecimal = False
        Me.txtEstadoPedidoEnviadoWebPOST.IsNumber = False
        Me.txtEstadoPedidoEnviadoWebPOST.IsPK = False
        Me.txtEstadoPedidoEnviadoWebPOST.IsRequired = False
        Me.txtEstadoPedidoEnviadoWebPOST.Key = ""
        Me.txtEstadoPedidoEnviadoWebPOST.LabelAsoc = Me.lblEstadoPedidoEnviadoWebPOST
        Me.txtEstadoPedidoEnviadoWebPOST.Location = New System.Drawing.Point(158, 72)
        Me.txtEstadoPedidoEnviadoWebPOST.MaxLength = 20
        Me.txtEstadoPedidoEnviadoWebPOST.Name = "txtEstadoPedidoEnviadoWebPOST"
        Me.txtEstadoPedidoEnviadoWebPOST.Size = New System.Drawing.Size(122, 20)
        Me.txtEstadoPedidoEnviadoWebPOST.TabIndex = 5
        '
        'txtPedidosURLWebPOST
        '
        Me.txtPedidosURLWebPOST.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPedidosURLWebPOST.BindearPropiedadControl = Nothing
        Me.txtPedidosURLWebPOST.BindearPropiedadEntidad = Nothing
        Me.txtPedidosURLWebPOST.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPedidosURLWebPOST.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPedidosURLWebPOST.Formato = ""
        Me.txtPedidosURLWebPOST.IsDecimal = False
        Me.txtPedidosURLWebPOST.IsNumber = False
        Me.txtPedidosURLWebPOST.IsPK = False
        Me.txtPedidosURLWebPOST.IsRequired = False
        Me.txtPedidosURLWebPOST.Key = ""
        Me.txtPedidosURLWebPOST.LabelAsoc = Me.lblPedidosURLWebPOST
        Me.txtPedidosURLWebPOST.Location = New System.Drawing.Point(158, 19)
        Me.txtPedidosURLWebPOST.Name = "txtPedidosURLWebPOST"
        Me.txtPedidosURLWebPOST.Size = New System.Drawing.Size(250, 20)
        Me.txtPedidosURLWebPOST.TabIndex = 1
        '
        'lblPedidosURLWebPOST
        '
        Me.lblPedidosURLWebPOST.AutoSize = True
        Me.lblPedidosURLWebPOST.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPedidosURLWebPOST.LabelAsoc = Nothing
        Me.lblPedidosURLWebPOST.Location = New System.Drawing.Point(19, 22)
        Me.lblPedidosURLWebPOST.Name = "lblPedidosURLWebPOST"
        Me.lblPedidosURLWebPOST.Size = New System.Drawing.Size(96, 13)
        Me.lblPedidosURLWebPOST.TabIndex = 0
        Me.lblPedidosURLWebPOST.Text = "URL Web Pedidos"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtURLGETProposal)
        Me.GroupBox1.Controls.Add(Me.lblURLGETProposal)
        Me.GroupBox1.Controls.Add(Me.txtTOKENTalkiu)
        Me.GroupBox1.Controls.Add(Me.lblTOKENTalkiu)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 162)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 91)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TALKIU"
        '
        'txtURLGETProposal
        '
        Me.txtURLGETProposal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtURLGETProposal.BindearPropiedadControl = Nothing
        Me.txtURLGETProposal.BindearPropiedadEntidad = Nothing
        Me.txtURLGETProposal.ForeColorFocus = System.Drawing.Color.Red
        Me.txtURLGETProposal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtURLGETProposal.Formato = ""
        Me.txtURLGETProposal.IsDecimal = False
        Me.txtURLGETProposal.IsNumber = False
        Me.txtURLGETProposal.IsPK = False
        Me.txtURLGETProposal.IsRequired = False
        Me.txtURLGETProposal.Key = ""
        Me.txtURLGETProposal.LabelAsoc = Me.lblURLGETProposal
        Me.txtURLGETProposal.Location = New System.Drawing.Point(66, 50)
        Me.txtURLGETProposal.Name = "txtURLGETProposal"
        Me.txtURLGETProposal.Size = New System.Drawing.Size(361, 20)
        Me.txtURLGETProposal.TabIndex = 9
        '
        'lblURLGETProposal
        '
        Me.lblURLGETProposal.AutoSize = True
        Me.lblURLGETProposal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblURLGETProposal.LabelAsoc = Nothing
        Me.lblURLGETProposal.Location = New System.Drawing.Point(6, 53)
        Me.lblURLGETProposal.Name = "lblURLGETProposal"
        Me.lblURLGETProposal.Size = New System.Drawing.Size(54, 13)
        Me.lblURLGETProposal.TabIndex = 8
        Me.lblURLGETProposal.Text = "URL GET"
        '
        'txtTOKENTalkiu
        '
        Me.txtTOKENTalkiu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTOKENTalkiu.BindearPropiedadControl = Nothing
        Me.txtTOKENTalkiu.BindearPropiedadEntidad = Nothing
        Me.txtTOKENTalkiu.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTOKENTalkiu.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTOKENTalkiu.Formato = ""
        Me.txtTOKENTalkiu.IsDecimal = False
        Me.txtTOKENTalkiu.IsNumber = False
        Me.txtTOKENTalkiu.IsPK = False
        Me.txtTOKENTalkiu.IsRequired = False
        Me.txtTOKENTalkiu.Key = ""
        Me.txtTOKENTalkiu.LabelAsoc = Me.lblTOKENTalkiu
        Me.txtTOKENTalkiu.Location = New System.Drawing.Point(66, 28)
        Me.txtTOKENTalkiu.Name = "txtTOKENTalkiu"
        Me.txtTOKENTalkiu.Size = New System.Drawing.Size(361, 20)
        Me.txtTOKENTalkiu.TabIndex = 7
        '
        'lblTOKENTalkiu
        '
        Me.lblTOKENTalkiu.AutoSize = True
        Me.lblTOKENTalkiu.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTOKENTalkiu.LabelAsoc = Nothing
        Me.lblTOKENTalkiu.Location = New System.Drawing.Point(6, 31)
        Me.lblTOKENTalkiu.Name = "lblTOKENTalkiu"
        Me.lblTOKENTalkiu.Size = New System.Drawing.Size(44, 13)
        Me.lblTOKENTalkiu.TabIndex = 6
        Me.lblTOKENTalkiu.Text = "TOKEN"
        '
        'ucConfPedidosWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "ucConfPedidosWeb"
        Me.Controls.SetChildIndex(Me.GroupBox7, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox7 As GroupBox
   Friend WithEvents lblEstadoPedidoPendienteWebPOST As Controles.Label
   Friend WithEvents txtEstadoPedidoPendienteWebPOST As Controles.TextBox
   Friend WithEvents lblEstadoPedidoEnviadoWebPOST As Controles.Label
   Friend WithEvents txtEstadoPedidoEnviadoWebPOST As Controles.TextBox
   Friend WithEvents txtPedidosURLWebPOST As Controles.TextBox
   Friend WithEvents lblPedidosURLWebPOST As Controles.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtTOKENTalkiu As Controles.TextBox
    Friend WithEvents lblTOKENTalkiu As Controles.Label
    Friend WithEvents txtURLGETProposal As Controles.TextBox
    Friend WithEvents lblURLGETProposal As Controles.Label
End Class
