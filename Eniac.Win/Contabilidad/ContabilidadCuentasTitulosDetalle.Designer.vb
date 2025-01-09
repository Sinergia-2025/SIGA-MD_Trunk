<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadCuentasTitulosDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.lblnivel1 = New Eniac.Controles.Label
      Me.lblnivel3 = New Eniac.Controles.Label
      Me.lblnivel2 = New Eniac.Controles.Label
      Me.cmbNivel3 = New Eniac.Controles.ComboBox
      Me.cmbNivel2 = New Eniac.Controles.ComboBox
      Me.cmbNivel1 = New Eniac.Controles.ComboBox
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.lblJerarquia = New Eniac.Controles.Label
      Me.GroupBox2 = New System.Windows.Forms.GroupBox
      Me.cmdCancelar = New System.Windows.Forms.Button
      Me.cmdGuardar = New System.Windows.Forms.Button
      Me.txtdscCuenta = New Eniac.Controles.TextBox
      Me.lbldsc = New Eniac.Controles.Label
      Me.cmdAgregar = New System.Windows.Forms.Button
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(413, 220)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(499, 220)
      Me.btnCancelar.TabIndex = 6
      '
      'lblnivel1
      '
      Me.lblnivel1.AutoSize = True
      Me.lblnivel1.Location = New System.Drawing.Point(8, 29)
      Me.lblnivel1.Name = "lblnivel1"
      Me.lblnivel1.Size = New System.Drawing.Size(40, 13)
      Me.lblnivel1.TabIndex = 1
      Me.lblnivel1.Text = "Nivel 1"
      '
      'lblnivel3
      '
      Me.lblnivel3.AutoSize = True
      Me.lblnivel3.Location = New System.Drawing.Point(6, 27)
      Me.lblnivel3.Name = "lblnivel3"
      Me.lblnivel3.Size = New System.Drawing.Size(40, 13)
      Me.lblnivel3.TabIndex = 1
      Me.lblnivel3.Text = "Nivel 3"
      '
      'lblnivel2
      '
      Me.lblnivel2.AutoSize = True
      Me.lblnivel2.Location = New System.Drawing.Point(8, 61)
      Me.lblnivel2.Name = "lblnivel2"
      Me.lblnivel2.Size = New System.Drawing.Size(40, 13)
      Me.lblnivel2.TabIndex = 3
      Me.lblnivel2.Text = "Nivel 2"
      '
      'cmbNivel3
      '
      Me.cmbNivel3.BindearPropiedadControl = ""
      Me.cmbNivel3.BindearPropiedadEntidad = ""
      Me.cmbNivel3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNivel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNivel3.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNivel3.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNivel3.FormattingEnabled = True
      Me.cmbNivel3.IsPK = False
      Me.cmbNivel3.IsRequired = True
      Me.cmbNivel3.Key = Nothing
      Me.cmbNivel3.LabelAsoc = Me.lblnivel3
      Me.cmbNivel3.Location = New System.Drawing.Point(63, 24)
      Me.cmbNivel3.Name = "cmbNivel3"
      Me.cmbNivel3.Size = New System.Drawing.Size(236, 21)
      Me.cmbNivel3.TabIndex = 0
      '
      'cmbNivel2
      '
      Me.cmbNivel2.BindearPropiedadControl = ""
      Me.cmbNivel2.BindearPropiedadEntidad = ""
      Me.cmbNivel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNivel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNivel2.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNivel2.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNivel2.FormattingEnabled = True
      Me.cmbNivel2.IsPK = False
      Me.cmbNivel2.IsRequired = True
      Me.cmbNivel2.Key = Nothing
      Me.cmbNivel2.LabelAsoc = Me.lblnivel2
      Me.cmbNivel2.Location = New System.Drawing.Point(74, 61)
      Me.cmbNivel2.Name = "cmbNivel2"
      Me.cmbNivel2.Size = New System.Drawing.Size(236, 21)
      Me.cmbNivel2.TabIndex = 2
      '
      'cmbNivel1
      '
      Me.cmbNivel1.BindearPropiedadControl = ""
      Me.cmbNivel1.BindearPropiedadEntidad = ""
      Me.cmbNivel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNivel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNivel1.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNivel1.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNivel1.FormattingEnabled = True
      Me.cmbNivel1.IsPK = False
      Me.cmbNivel1.IsRequired = True
      Me.cmbNivel1.Key = Nothing
      Me.cmbNivel1.LabelAsoc = Me.lblnivel1
      Me.cmbNivel1.Location = New System.Drawing.Point(74, 26)
      Me.cmbNivel1.Name = "cmbNivel1"
      Me.cmbNivel1.Size = New System.Drawing.Size(236, 21)
      Me.cmbNivel1.TabIndex = 0
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.lblJerarquia)
      Me.GroupBox1.Location = New System.Drawing.Point(366, 18)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(213, 64)
      Me.GroupBox1.TabIndex = 7
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Jerarquía"
      '
      'lblJerarquia
      '
      Me.lblJerarquia.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblJerarquia.Location = New System.Drawing.Point(37, 21)
      Me.lblJerarquia.Name = "lblJerarquia"
      Me.lblJerarquia.Size = New System.Drawing.Size(146, 30)
      Me.lblJerarquia.TabIndex = 0
      Me.lblJerarquia.Text = "1.02.02.000"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.cmdCancelar)
      Me.GroupBox2.Controls.Add(Me.cmdGuardar)
      Me.GroupBox2.Controls.Add(Me.txtdscCuenta)
      Me.GroupBox2.Controls.Add(Me.lbldsc)
      Me.GroupBox2.Controls.Add(Me.cmdAgregar)
      Me.GroupBox2.Controls.Add(Me.cmbNivel3)
      Me.GroupBox2.Controls.Add(Me.lblnivel3)
      Me.GroupBox2.Location = New System.Drawing.Point(11, 97)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(568, 101)
      Me.GroupBox2.TabIndex = 4
      Me.GroupBox2.TabStop = False
      '
      'cmdCancelar
      '
      Me.cmdCancelar.Enabled = False
      Me.cmdCancelar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
      Me.cmdCancelar.Location = New System.Drawing.Point(524, 60)
      Me.cmdCancelar.Name = "cmdCancelar"
      Me.cmdCancelar.Size = New System.Drawing.Size(36, 35)
      Me.cmdCancelar.TabIndex = 6
      Me.cmdCancelar.UseVisualStyleBackColor = True
      '
      'cmdGuardar
      '
      Me.cmdGuardar.Enabled = False
      Me.cmdGuardar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
      Me.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdGuardar.Location = New System.Drawing.Point(391, 60)
      Me.cmdGuardar.Name = "cmdGuardar"
      Me.cmdGuardar.Size = New System.Drawing.Size(127, 35)
      Me.cmdGuardar.TabIndex = 5
      Me.cmdGuardar.Text = "Guardar y Nueva"
      Me.cmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.cmdGuardar.UseVisualStyleBackColor = True
      '
      'txtdscCuenta
      '
      Me.txtdscCuenta.BindearPropiedadControl = "Text"
      Me.txtdscCuenta.BindearPropiedadEntidad = "NombreCuenta"
      Me.txtdscCuenta.Enabled = False
      Me.txtdscCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtdscCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtdscCuenta.Formato = ""
      Me.txtdscCuenta.IsDecimal = False
      Me.txtdscCuenta.IsNumber = False
      Me.txtdscCuenta.IsPK = False
      Me.txtdscCuenta.IsRequired = False
      Me.txtdscCuenta.Key = ""
      Me.txtdscCuenta.LabelAsoc = Me.lbldsc
      Me.txtdscCuenta.Location = New System.Drawing.Point(109, 68)
      Me.txtdscCuenta.MaxLength = 50
      Me.txtdscCuenta.Name = "txtdscCuenta"
      Me.txtdscCuenta.Size = New System.Drawing.Size(273, 20)
      Me.txtdscCuenta.TabIndex = 3
      '
      'lbldsc
      '
      Me.lbldsc.AutoSize = True
      Me.lbldsc.Enabled = False
      Me.lbldsc.Location = New System.Drawing.Point(6, 71)
      Me.lbldsc.Name = "lbldsc"
      Me.lbldsc.Size = New System.Drawing.Size(97, 13)
      Me.lbldsc.TabIndex = 4
      Me.lbldsc.Text = "Descipción Cuenta"
      '
      'cmdAgregar
      '
      Me.cmdAgregar.Image = Global.Eniac.Win.My.Resources.Resources.document_add
      Me.cmdAgregar.Location = New System.Drawing.Point(305, 14)
      Me.cmdAgregar.Name = "cmdAgregar"
      Me.cmdAgregar.Size = New System.Drawing.Size(34, 38)
      Me.cmdAgregar.TabIndex = 2
      Me.cmdAgregar.UseVisualStyleBackColor = True
      '
      'CuentasTitulosDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(588, 255)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.cmbNivel1)
      Me.Controls.Add(Me.cmbNivel2)
      Me.Controls.Add(Me.lblnivel2)
      Me.Controls.Add(Me.lblnivel1)
      Me.Name = "CuentasTitulosDetalle"
      Me.Text = "Cuenta de Título"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.lblnivel1, 0)
      Me.Controls.SetChildIndex(Me.lblnivel2, 0)
      Me.Controls.SetChildIndex(Me.cmbNivel2, 0)
      Me.Controls.SetChildIndex(Me.cmbNivel1, 0)
      Me.Controls.SetChildIndex(Me.GroupBox1, 0)
      Me.Controls.SetChildIndex(Me.GroupBox2, 0)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblnivel1 As Eniac.Controles.Label
   Friend WithEvents lblnivel3 As Eniac.Controles.Label
   Friend WithEvents lblnivel2 As Eniac.Controles.Label
   Friend WithEvents cmbNivel3 As Eniac.Controles.ComboBox
   Friend WithEvents cmbNivel2 As Eniac.Controles.ComboBox
   Friend WithEvents cmbNivel1 As Eniac.Controles.ComboBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents lblJerarquia As Eniac.Controles.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents lbldsc As Eniac.Controles.Label
   Friend WithEvents cmdAgregar As System.Windows.Forms.Button
   Friend WithEvents cmdCancelar As System.Windows.Forms.Button
   Friend WithEvents cmdGuardar As System.Windows.Forms.Button
   Friend WithEvents txtdscCuenta As Eniac.Controles.TextBox
End Class
