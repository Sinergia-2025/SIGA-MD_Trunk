<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadSaldosInicialesABMDetalle
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
      Me.cmbCentroCosto = New Eniac.Controles.ComboBox
      Me.Label3 = New Eniac.Controles.Label
      Me.cmbCuenta = New Eniac.Controles.ComboBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.cmbEjercicio = New Eniac.Controles.ComboBox
      Me.lblPatenteVehiculo = New Eniac.Controles.Label
      Me.txtSaldo = New Eniac.Controles.TextBox
      Me.SuspendLayout()
      '
      'cmbCentroCosto
      '
      Me.cmbCentroCosto.BindearPropiedadControl = "SelectedValue"
      Me.cmbCentroCosto.BindearPropiedadEntidad = "TipoAcceso.IdTipoAcceso"
      Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCentroCosto.FormattingEnabled = True
      Me.cmbCentroCosto.IsPK = False
      Me.cmbCentroCosto.IsRequired = True
      Me.cmbCentroCosto.Key = Nothing
      Me.cmbCentroCosto.LabelAsoc = Nothing
      Me.cmbCentroCosto.Location = New System.Drawing.Point(99, 12)
      Me.cmbCentroCosto.Name = "cmbCentroCosto"
      Me.cmbCentroCosto.Size = New System.Drawing.Size(196, 21)
      Me.cmbCentroCosto.TabIndex = 45
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(7, 20)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(68, 13)
      Me.Label3.TabIndex = 44
      Me.Label3.Text = "Centro Costo"
      '
      'cmbCuenta
      '
      Me.cmbCuenta.BindearPropiedadControl = "SelectedValue"
      Me.cmbCuenta.BindearPropiedadEntidad = "TipoAcceso.IdTipoAcceso"
      Me.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCuenta.FormattingEnabled = True
      Me.cmbCuenta.IsPK = False
      Me.cmbCuenta.IsRequired = True
      Me.cmbCuenta.Key = Nothing
      Me.cmbCuenta.LabelAsoc = Nothing
      Me.cmbCuenta.Location = New System.Drawing.Point(99, 46)
      Me.cmbCuenta.Name = "cmbCuenta"
      Me.cmbCuenta.Size = New System.Drawing.Size(196, 21)
      Me.cmbCuenta.TabIndex = 47
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(7, 54)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(41, 13)
      Me.Label2.TabIndex = 46
      Me.Label2.Text = "Cuenta"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(7, 90)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(47, 13)
      Me.Label1.TabIndex = 48
      Me.Label1.Text = "Ejercicio"
      '
      'cmbEjercicio
      '
      Me.cmbEjercicio.BindearPropiedadControl = "SelectedValue"
      Me.cmbEjercicio.BindearPropiedadEntidad = "TipoAcceso.IdTipoAcceso"
      Me.cmbEjercicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEjercicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbEjercicio.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEjercicio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEjercicio.FormattingEnabled = True
      Me.cmbEjercicio.IsPK = False
      Me.cmbEjercicio.IsRequired = True
      Me.cmbEjercicio.Key = Nothing
      Me.cmbEjercicio.LabelAsoc = Nothing
      Me.cmbEjercicio.Location = New System.Drawing.Point(99, 82)
      Me.cmbEjercicio.Name = "cmbEjercicio"
      Me.cmbEjercicio.Size = New System.Drawing.Size(196, 21)
      Me.cmbEjercicio.TabIndex = 49
      '
      'lblPatenteVehiculo
      '
      Me.lblPatenteVehiculo.AutoSize = True
      Me.lblPatenteVehiculo.Location = New System.Drawing.Point(7, 126)
      Me.lblPatenteVehiculo.Name = "lblPatenteVehiculo"
      Me.lblPatenteVehiculo.Size = New System.Drawing.Size(34, 13)
      Me.lblPatenteVehiculo.TabIndex = 51
      Me.lblPatenteVehiculo.Text = "Saldo"
      '
      'txtSaldo
      '
      Me.txtSaldo.BindearPropiedadControl = "Text"
      Me.txtSaldo.BindearPropiedadEntidad = "PatenteVehiculo"
      Me.txtSaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtSaldo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtSaldo.Formato = ""
      Me.txtSaldo.IsDecimal = False
      Me.txtSaldo.IsNumber = False
      Me.txtSaldo.IsPK = True
      Me.txtSaldo.IsRequired = True
      Me.txtSaldo.Key = ""
      Me.txtSaldo.LabelAsoc = Me.lblPatenteVehiculo
      Me.txtSaldo.Location = New System.Drawing.Point(99, 119)
      Me.txtSaldo.MaxLength = 8
      Me.txtSaldo.Name = "txtSaldo"
      Me.txtSaldo.Size = New System.Drawing.Size(79, 20)
      Me.txtSaldo.TabIndex = 50
      '
      'SaldosInicialesABMDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(321, 234)
      Me.Controls.Add(Me.lblPatenteVehiculo)
      Me.Controls.Add(Me.txtSaldo)
      Me.Controls.Add(Me.cmbEjercicio)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbCuenta)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.cmbCentroCosto)
      Me.Controls.Add(Me.Label3)
      Me.Name = "SaldosInicialesABMDetalle"
      Me.Text = "Saldo Inicial"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.Label3, 0)
      Me.Controls.SetChildIndex(Me.cmbCentroCosto, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.cmbCuenta, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.cmbEjercicio, 0)
      Me.Controls.SetChildIndex(Me.txtSaldo, 0)
      Me.Controls.SetChildIndex(Me.lblPatenteVehiculo, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbCentroCosto As Eniac.Controles.ComboBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cmbCuenta As Eniac.Controles.ComboBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbEjercicio As Eniac.Controles.ComboBox
   Friend WithEvents lblPatenteVehiculo As Eniac.Controles.Label
   Friend WithEvents txtSaldo As Eniac.Controles.TextBox
End Class
