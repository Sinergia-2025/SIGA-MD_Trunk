<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfCtaCteClienteInformes
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
      Me.ChbNombreFantasia = New Eniac.Controles.CheckBox()
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas = New System.Windows.Forms.GroupBox()
      Me.lblCtaCteCliente_Informes_Modalidad = New Eniac.Controles.Label()
      Me.cmbCtaCteCliente_Informes_Modalidad = New Eniac.Controles.ComboBox()
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.SuspendLayout()
      Me.SuspendLayout()
      '
      'ChbNombreFantasia
      '
      Me.ChbNombreFantasia.AutoSize = True
      Me.ChbNombreFantasia.BindearPropiedadControl = Nothing
      Me.ChbNombreFantasia.BindearPropiedadEntidad = Nothing
      Me.ChbNombreFantasia.ForeColorFocus = System.Drawing.Color.Red
      Me.ChbNombreFantasia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.ChbNombreFantasia.IsPK = False
      Me.ChbNombreFantasia.IsRequired = False
      Me.ChbNombreFantasia.Key = Nothing
      Me.ChbNombreFantasia.LabelAsoc = Nothing
      Me.ChbNombreFantasia.Location = New System.Drawing.Point(32, 98)
      Me.ChbNombreFantasia.Name = "ChbNombreFantasia"
      Me.ChbNombreFantasia.Size = New System.Drawing.Size(167, 17)
      Me.ChbNombreFantasia.TabIndex = 1
      Me.ChbNombreFantasia.Tag = "CONSCCBLUEOCULTANOMFANTASIA"
      Me.ChbNombreFantasia.Text = "Visualiza Nombre de Fantasía"
      Me.ChbNombreFantasia.UseVisualStyleBackColor = True
      '
      'grpCtaCteCliente_Informes_InfCoeficienteCobranzas
      '
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.Controls.Add(Me.lblCtaCteCliente_Informes_Modalidad)
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.Controls.Add(Me.cmbCtaCteCliente_Informes_Modalidad)
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.Location = New System.Drawing.Point(25, 27)
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.Name = "grpCtaCteCliente_Informes_InfCoeficienteCobranzas"
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.Size = New System.Drawing.Size(274, 54)
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.TabIndex = 0
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.TabStop = False
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.Text = "Informe Coeficiente de Cobranzas"
      '
      'lblCtaCteCliente_Informes_Modalidad
      '
      Me.lblCtaCteCliente_Informes_Modalidad.AutoSize = True
      Me.lblCtaCteCliente_Informes_Modalidad.LabelAsoc = Nothing
      Me.lblCtaCteCliente_Informes_Modalidad.Location = New System.Drawing.Point(15, 24)
      Me.lblCtaCteCliente_Informes_Modalidad.Name = "lblCtaCteCliente_Informes_Modalidad"
      Me.lblCtaCteCliente_Informes_Modalidad.Size = New System.Drawing.Size(56, 13)
      Me.lblCtaCteCliente_Informes_Modalidad.TabIndex = 0
      Me.lblCtaCteCliente_Informes_Modalidad.Text = "Modalidad"
      '
      'cmbCtaCteCliente_Informes_Modalidad
      '
      Me.cmbCtaCteCliente_Informes_Modalidad.BindearPropiedadControl = Nothing
      Me.cmbCtaCteCliente_Informes_Modalidad.BindearPropiedadEntidad = Nothing
      Me.cmbCtaCteCliente_Informes_Modalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCtaCteCliente_Informes_Modalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.cmbCtaCteCliente_Informes_Modalidad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCtaCteCliente_Informes_Modalidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCtaCteCliente_Informes_Modalidad.FormattingEnabled = True
      Me.cmbCtaCteCliente_Informes_Modalidad.IsPK = False
      Me.cmbCtaCteCliente_Informes_Modalidad.IsRequired = False
      Me.cmbCtaCteCliente_Informes_Modalidad.ItemHeight = 13
      Me.cmbCtaCteCliente_Informes_Modalidad.Key = Nothing
      Me.cmbCtaCteCliente_Informes_Modalidad.LabelAsoc = Me.lblCtaCteCliente_Informes_Modalidad
      Me.cmbCtaCteCliente_Informes_Modalidad.Location = New System.Drawing.Point(77, 21)
      Me.cmbCtaCteCliente_Informes_Modalidad.Name = "cmbCtaCteCliente_Informes_Modalidad"
      Me.cmbCtaCteCliente_Informes_Modalidad.Size = New System.Drawing.Size(183, 21)
      Me.cmbCtaCteCliente_Informes_Modalidad.TabIndex = 1
      '
      'ucConfCtaCteClienteInformes
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.ChbNombreFantasia)
      Me.Controls.Add(Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas)
      Me.Name = "ucConfCtaCteClienteInformes"
      Me.Controls.SetChildIndex(Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas, 0)
      Me.Controls.SetChildIndex(Me.ChbNombreFantasia, 0)
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.ResumeLayout(False)
      Me.grpCtaCteCliente_Informes_InfCoeficienteCobranzas.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents ChbNombreFantasia As Controles.CheckBox
   Friend WithEvents grpCtaCteCliente_Informes_InfCoeficienteCobranzas As GroupBox
   Friend WithEvents lblCtaCteCliente_Informes_Modalidad As Controles.Label
   Friend WithEvents cmbCtaCteCliente_Informes_Modalidad As Controles.ComboBox
End Class
