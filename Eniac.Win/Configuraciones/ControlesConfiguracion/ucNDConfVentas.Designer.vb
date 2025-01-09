<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucNDConfVentas
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
      Me.txtIdentifTicketFiscal = New Eniac.Controles.TextBox()
      Me.lblIdentifTicketFiscal = New Eniac.Controles.Label()
      Me.txtIdentifFacturaFiscal = New Eniac.Controles.TextBox()
      Me.lblIdentifFacturaFiscal = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'txtIdentifTicketFiscal
      '
      Me.txtIdentifTicketFiscal.BindearPropiedadControl = Nothing
      Me.txtIdentifTicketFiscal.BindearPropiedadEntidad = Nothing
      Me.txtIdentifTicketFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdentifTicketFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdentifTicketFiscal.Formato = ""
      Me.txtIdentifTicketFiscal.IsDecimal = False
      Me.txtIdentifTicketFiscal.IsNumber = False
      Me.txtIdentifTicketFiscal.IsPK = False
      Me.txtIdentifTicketFiscal.IsRequired = False
      Me.txtIdentifTicketFiscal.Key = ""
      Me.txtIdentifTicketFiscal.LabelAsoc = Me.lblIdentifTicketFiscal
      Me.txtIdentifTicketFiscal.Location = New System.Drawing.Point(25, 98)
      Me.txtIdentifTicketFiscal.MaxLength = 20
      Me.txtIdentifTicketFiscal.Name = "txtIdentifTicketFiscal"
      Me.txtIdentifTicketFiscal.Size = New System.Drawing.Size(92, 20)
      Me.txtIdentifTicketFiscal.TabIndex = 61
      Me.txtIdentifTicketFiscal.Tag = "IDTICKETFISCAL"
      Me.txtIdentifTicketFiscal.Text = "TICKET-F"
      '
      'lblIdentifTicketFiscal
      '
      Me.lblIdentifTicketFiscal.AutoSize = True
      Me.lblIdentifTicketFiscal.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblIdentifTicketFiscal.LabelAsoc = Nothing
      Me.lblIdentifTicketFiscal.Location = New System.Drawing.Point(123, 105)
      Me.lblIdentifTicketFiscal.Name = "lblIdentifTicketFiscal"
      Me.lblIdentifTicketFiscal.Size = New System.Drawing.Size(143, 13)
      Me.lblIdentifTicketFiscal.TabIndex = 64
      Me.lblIdentifTicketFiscal.Text = "Identificador de Ticket Fiscal"
      '
      'txtIdentifFacturaFiscal
      '
      Me.txtIdentifFacturaFiscal.BindearPropiedadControl = Nothing
      Me.txtIdentifFacturaFiscal.BindearPropiedadEntidad = Nothing
      Me.txtIdentifFacturaFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdentifFacturaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdentifFacturaFiscal.Formato = ""
      Me.txtIdentifFacturaFiscal.IsDecimal = False
      Me.txtIdentifFacturaFiscal.IsNumber = False
      Me.txtIdentifFacturaFiscal.IsPK = False
      Me.txtIdentifFacturaFiscal.IsRequired = False
      Me.txtIdentifFacturaFiscal.Key = ""
      Me.txtIdentifFacturaFiscal.LabelAsoc = Me.lblIdentifFacturaFiscal
      Me.txtIdentifFacturaFiscal.Location = New System.Drawing.Point(25, 72)
      Me.txtIdentifFacturaFiscal.MaxLength = 20
      Me.txtIdentifFacturaFiscal.Name = "txtIdentifFacturaFiscal"
      Me.txtIdentifFacturaFiscal.Size = New System.Drawing.Size(92, 20)
      Me.txtIdentifFacturaFiscal.TabIndex = 60
      Me.txtIdentifFacturaFiscal.Tag = "IDTICKETFACTURAFISCAL"
      Me.txtIdentifFacturaFiscal.Text = "TCK-FACT-F"
      '
      'lblIdentifFacturaFiscal
      '
      Me.lblIdentifFacturaFiscal.AutoSize = True
      Me.lblIdentifFacturaFiscal.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblIdentifFacturaFiscal.LabelAsoc = Nothing
      Me.lblIdentifFacturaFiscal.Location = New System.Drawing.Point(123, 79)
      Me.lblIdentifFacturaFiscal.Name = "lblIdentifFacturaFiscal"
      Me.lblIdentifFacturaFiscal.Size = New System.Drawing.Size(179, 13)
      Me.lblIdentifFacturaFiscal.TabIndex = 63
      Me.lblIdentifFacturaFiscal.Text = "Identificador de TicketFactura Fiscal"
      '
      'ucNDConfVentas
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.txtIdentifTicketFiscal)
      Me.Controls.Add(Me.txtIdentifFacturaFiscal)
      Me.Controls.Add(Me.lblIdentifTicketFiscal)
      Me.Controls.Add(Me.lblIdentifFacturaFiscal)
      Me.Name = "ucNDConfVentas"
      Me.Controls.SetChildIndex(Me.lblIdentifFacturaFiscal, 0)
      Me.Controls.SetChildIndex(Me.lblIdentifTicketFiscal, 0)
      Me.Controls.SetChildIndex(Me.txtIdentifFacturaFiscal, 0)
      Me.Controls.SetChildIndex(Me.txtIdentifTicketFiscal, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents txtIdentifTicketFiscal As Controles.TextBox
   Friend WithEvents lblIdentifTicketFiscal As Controles.Label
   Friend WithEvents txtIdentifFacturaFiscal As Controles.TextBox
   Friend WithEvents lblIdentifFacturaFiscal As Controles.Label
End Class
