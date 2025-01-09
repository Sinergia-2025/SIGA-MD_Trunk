<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfPrecios2
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
      Me.lblConsultaPreciosClienteCodigoCliente = New Eniac.Controles.Label()
      Me.txtConsultaPreciosClienteCodigoCliente = New Eniac.Controles.TextBox()
      Me.chbConsultaPreciosClienteUsaPredeterminado = New Eniac.Controles.CheckBox()
      Me.lblConsultaPreciosClienteMoneda = New Eniac.Controles.Label()
      Me.cmbConsultaPreciosClienteMoneda = New Eniac.Controles.ComboBox()
      Me.grpConsultaPreciosCliente = New System.Windows.Forms.GroupBox()
      Me.grpConsultaPreciosCliente.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblConsultaPreciosClienteCodigoCliente
      '
      Me.lblConsultaPreciosClienteCodigoCliente.AutoSize = True
      Me.lblConsultaPreciosClienteCodigoCliente.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblConsultaPreciosClienteCodigoCliente.LabelAsoc = Nothing
      Me.lblConsultaPreciosClienteCodigoCliente.Location = New System.Drawing.Point(147, 23)
      Me.lblConsultaPreciosClienteCodigoCliente.Name = "lblConsultaPreciosClienteCodigoCliente"
      Me.lblConsultaPreciosClienteCodigoCliente.Size = New System.Drawing.Size(40, 13)
      Me.lblConsultaPreciosClienteCodigoCliente.TabIndex = 1
      Me.lblConsultaPreciosClienteCodigoCliente.Text = "Código"
      '
      'txtConsultaPreciosClienteCodigoCliente
      '
      Me.txtConsultaPreciosClienteCodigoCliente.BindearPropiedadControl = Nothing
      Me.txtConsultaPreciosClienteCodigoCliente.BindearPropiedadEntidad = Nothing
      Me.txtConsultaPreciosClienteCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
      Me.txtConsultaPreciosClienteCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtConsultaPreciosClienteCodigoCliente.Formato = ""
      Me.txtConsultaPreciosClienteCodigoCliente.IsDecimal = False
      Me.txtConsultaPreciosClienteCodigoCliente.IsNumber = True
      Me.txtConsultaPreciosClienteCodigoCliente.IsPK = False
      Me.txtConsultaPreciosClienteCodigoCliente.IsRequired = False
      Me.txtConsultaPreciosClienteCodigoCliente.Key = ""
      Me.txtConsultaPreciosClienteCodigoCliente.LabelAsoc = Nothing
      Me.txtConsultaPreciosClienteCodigoCliente.Location = New System.Drawing.Point(193, 19)
      Me.txtConsultaPreciosClienteCodigoCliente.MaxLength = 8
      Me.txtConsultaPreciosClienteCodigoCliente.Name = "txtConsultaPreciosClienteCodigoCliente"
      Me.txtConsultaPreciosClienteCodigoCliente.Size = New System.Drawing.Size(70, 20)
      Me.txtConsultaPreciosClienteCodigoCliente.TabIndex = 2
      Me.txtConsultaPreciosClienteCodigoCliente.Text = "1"
      Me.txtConsultaPreciosClienteCodigoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbConsultaPreciosClienteUsaPredeterminado
      '
      Me.chbConsultaPreciosClienteUsaPredeterminado.AutoSize = True
      Me.chbConsultaPreciosClienteUsaPredeterminado.BindearPropiedadControl = Nothing
      Me.chbConsultaPreciosClienteUsaPredeterminado.BindearPropiedadEntidad = Nothing
      Me.chbConsultaPreciosClienteUsaPredeterminado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbConsultaPreciosClienteUsaPredeterminado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbConsultaPreciosClienteUsaPredeterminado.IsPK = False
      Me.chbConsultaPreciosClienteUsaPredeterminado.IsRequired = False
      Me.chbConsultaPreciosClienteUsaPredeterminado.Key = Nothing
      Me.chbConsultaPreciosClienteUsaPredeterminado.LabelAsoc = Nothing
      Me.chbConsultaPreciosClienteUsaPredeterminado.Location = New System.Drawing.Point(6, 21)
      Me.chbConsultaPreciosClienteUsaPredeterminado.Name = "chbConsultaPreciosClienteUsaPredeterminado"
      Me.chbConsultaPreciosClienteUsaPredeterminado.Size = New System.Drawing.Size(135, 17)
      Me.chbConsultaPreciosClienteUsaPredeterminado.TabIndex = 0
      Me.chbConsultaPreciosClienteUsaPredeterminado.Tag = ""
      Me.chbConsultaPreciosClienteUsaPredeterminado.Text = "Cliente Predeterminado"
      Me.chbConsultaPreciosClienteUsaPredeterminado.UseVisualStyleBackColor = True
      '
      'lblConsultaPreciosClienteMoneda
      '
      Me.lblConsultaPreciosClienteMoneda.AutoSize = True
      Me.lblConsultaPreciosClienteMoneda.LabelAsoc = Nothing
      Me.lblConsultaPreciosClienteMoneda.Location = New System.Drawing.Point(3, 49)
      Me.lblConsultaPreciosClienteMoneda.Name = "lblConsultaPreciosClienteMoneda"
      Me.lblConsultaPreciosClienteMoneda.Size = New System.Drawing.Size(281, 13)
      Me.lblConsultaPreciosClienteMoneda.TabIndex = 3
      Me.lblConsultaPreciosClienteMoneda.Text = "Al Consultar Precios mostrar el precio utilizando la Moneda"
      '
      'cmbConsultaPreciosClienteMoneda
      '
      Me.cmbConsultaPreciosClienteMoneda.BindearPropiedadControl = Nothing
      Me.cmbConsultaPreciosClienteMoneda.BindearPropiedadEntidad = Nothing
      Me.cmbConsultaPreciosClienteMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbConsultaPreciosClienteMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbConsultaPreciosClienteMoneda.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbConsultaPreciosClienteMoneda.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbConsultaPreciosClienteMoneda.FormattingEnabled = True
      Me.cmbConsultaPreciosClienteMoneda.IsPK = False
      Me.cmbConsultaPreciosClienteMoneda.IsRequired = False
      Me.cmbConsultaPreciosClienteMoneda.Items.AddRange(New Object() {"del producto"})
      Me.cmbConsultaPreciosClienteMoneda.Key = Nothing
      Me.cmbConsultaPreciosClienteMoneda.LabelAsoc = Me.lblConsultaPreciosClienteMoneda
      Me.cmbConsultaPreciosClienteMoneda.Location = New System.Drawing.Point(290, 45)
      Me.cmbConsultaPreciosClienteMoneda.Name = "cmbConsultaPreciosClienteMoneda"
      Me.cmbConsultaPreciosClienteMoneda.Size = New System.Drawing.Size(127, 21)
      Me.cmbConsultaPreciosClienteMoneda.TabIndex = 4
      '
      'grpConsultaPreciosCliente
      '
      Me.grpConsultaPreciosCliente.Controls.Add(Me.chbConsultaPreciosClienteUsaPredeterminado)
      Me.grpConsultaPreciosCliente.Controls.Add(Me.lblConsultaPreciosClienteMoneda)
      Me.grpConsultaPreciosCliente.Controls.Add(Me.txtConsultaPreciosClienteCodigoCliente)
      Me.grpConsultaPreciosCliente.Controls.Add(Me.cmbConsultaPreciosClienteMoneda)
      Me.grpConsultaPreciosCliente.Controls.Add(Me.lblConsultaPreciosClienteCodigoCliente)
      Me.grpConsultaPreciosCliente.Location = New System.Drawing.Point(7, 46)
      Me.grpConsultaPreciosCliente.Name = "grpConsultaPreciosCliente"
      Me.grpConsultaPreciosCliente.Size = New System.Drawing.Size(426, 72)
      Me.grpConsultaPreciosCliente.TabIndex = 0
      Me.grpConsultaPreciosCliente.TabStop = False
      Me.grpConsultaPreciosCliente.Text = "Consulta de Precios por Cliente"
      '
      'ucConfPrecios2
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.grpConsultaPreciosCliente)
      Me.Name = "ucConfPrecios2"
      Me.Controls.SetChildIndex(Me.grpConsultaPreciosCliente, 0)
      Me.grpConsultaPreciosCliente.ResumeLayout(False)
      Me.grpConsultaPreciosCliente.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents lblConsultaPreciosClienteCodigoCliente As Controles.Label
   Friend WithEvents txtConsultaPreciosClienteCodigoCliente As Controles.TextBox
   Friend WithEvents chbConsultaPreciosClienteUsaPredeterminado As Controles.CheckBox
   Friend WithEvents lblConsultaPreciosClienteMoneda As Controles.Label
   Friend WithEvents cmbConsultaPreciosClienteMoneda As Controles.ComboBox
   Friend WithEvents grpConsultaPreciosCliente As GroupBox
End Class
