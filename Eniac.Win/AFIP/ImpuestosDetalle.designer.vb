<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpuestosDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpuestosDetalle))
      Me.lblIdTipoImpuesto = New Eniac.Controles.Label()
      Me.lblAlicuota = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.chbEstado = New Eniac.Controles.CheckBox()
      Me.lblAutoincremental = New Eniac.Controles.Label()
      Me.cmbTipoImpuesto = New Eniac.Controles.ComboBox()
      Me.GroupBox6 = New System.Windows.Forms.GroupBox()
      Me.UcCuentasVentas = New Eniac.Win.ucCuentas()
      Me.GroupBox5 = New System.Windows.Forms.GroupBox()
      Me.UcCuentasCompras = New Eniac.Win.ucCuentas()
        Me.cmbTipoImpuestoPIVA = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.txtDescripcionPIVA = New Eniac.Controles.TextBox()
        Me.grpPIVA = New System.Windows.Forms.GroupBox()
        Me.chbPIVA = New Eniac.Controles.CheckBox()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.grpPIVA.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(308, 273)
        Me.btnAceptar.TabIndex = 8
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(394, 273)
        Me.btnCancelar.TabIndex = 9
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(207, 273)
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(150, 273)
        '
        'lblIdTipoImpuesto
        '
        Me.lblIdTipoImpuesto.AutoSize = True
        Me.lblIdTipoImpuesto.LabelAsoc = Nothing
        Me.lblIdTipoImpuesto.Location = New System.Drawing.Point(16, 27)
        Me.lblIdTipoImpuesto.Name = "lblIdTipoImpuesto"
        Me.lblIdTipoImpuesto.Size = New System.Drawing.Size(89, 13)
        Me.lblIdTipoImpuesto.TabIndex = 0
        Me.lblIdTipoImpuesto.Text = "Tipo de Impuesto"
        '
        'lblAlicuota
        '
        Me.lblAlicuota.AutoSize = True
        Me.lblAlicuota.LabelAsoc = Nothing
        Me.lblAlicuota.Location = New System.Drawing.Point(16, 55)
        Me.lblAlicuota.Name = "lblAlicuota"
        Me.lblAlicuota.Size = New System.Drawing.Size(71, 13)
        Me.lblAlicuota.TabIndex = 4
        Me.lblAlicuota.Text = "% de Alicuota"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "Alicuota"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = "##0.00"
        Me.txtDescripcion.IsDecimal = True
        Me.txtDescripcion.IsNumber = True
        Me.txtDescripcion.IsPK = True
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = ""
        Me.txtDescripcion.LabelAsoc = Me.lblAlicuota
        Me.txtDescripcion.Location = New System.Drawing.Point(111, 51)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(59, 20)
        Me.txtDescripcion.TabIndex = 5
        Me.txtDescripcion.Text = "0.00"
        Me.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbEstado
        '
        Me.chbEstado.AutoSize = True
        Me.chbEstado.BindearPropiedadControl = "Checked"
        Me.chbEstado.BindearPropiedadEntidad = "Activo"
        Me.chbEstado.Checked = True
        Me.chbEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEstado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEstado.IsPK = False
        Me.chbEstado.IsRequired = True
        Me.chbEstado.Key = Nothing
        Me.chbEstado.LabelAsoc = Me.lblAutoincremental
        Me.chbEstado.Location = New System.Drawing.Point(416, 27)
        Me.chbEstado.Name = "chbEstado"
        Me.chbEstado.Size = New System.Drawing.Size(15, 14)
        Me.chbEstado.TabIndex = 2
        Me.chbEstado.UseVisualStyleBackColor = True
        '
        'lblAutoincremental
        '
        Me.lblAutoincremental.AutoSize = True
        Me.lblAutoincremental.LabelAsoc = Nothing
        Me.lblAutoincremental.Location = New System.Drawing.Point(437, 27)
        Me.lblAutoincremental.Name = "lblAutoincremental"
        Me.lblAutoincremental.Size = New System.Drawing.Size(37, 13)
        Me.lblAutoincremental.TabIndex = 3
        Me.lblAutoincremental.Text = "Activo"
        '
        'cmbTipoImpuesto
        '
        Me.cmbTipoImpuesto.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoImpuesto.BindearPropiedadEntidad = "IdTipoImpuesto"
        Me.cmbTipoImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoImpuesto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoImpuesto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoImpuesto.FormattingEnabled = True
        Me.cmbTipoImpuesto.IsPK = True
        Me.cmbTipoImpuesto.IsRequired = True
        Me.cmbTipoImpuesto.Key = Nothing
        Me.cmbTipoImpuesto.LabelAsoc = Nothing
        Me.cmbTipoImpuesto.Location = New System.Drawing.Point(111, 24)
        Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
        Me.cmbTipoImpuesto.Size = New System.Drawing.Size(213, 21)
        Me.cmbTipoImpuesto.TabIndex = 1
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.UcCuentasVentas)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 213)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(467, 55)
        Me.GroupBox6.TabIndex = 7
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Ventas"
        '
        'UcCuentasVentas
        '
        Me.UcCuentasVentas.Cuenta = Nothing
        Me.UcCuentasVentas.Location = New System.Drawing.Point(6, 19)
        Me.UcCuentasVentas.Name = "UcCuentasVentas"
        Me.UcCuentasVentas.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentasVentas.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.UcCuentasCompras)
        Me.GroupBox5.Location = New System.Drawing.Point(7, 152)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(467, 55)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Compras"
        '
        'UcCuentasCompras
        '
        Me.UcCuentasCompras.Cuenta = Nothing
        Me.UcCuentasCompras.Location = New System.Drawing.Point(6, 19)
        Me.UcCuentasCompras.Name = "UcCuentasCompras"
        Me.UcCuentasCompras.Size = New System.Drawing.Size(444, 20)
        Me.UcCuentasCompras.TabIndex = 0
        '
        'cmbTipoImpuestoPIVA
        '
        Me.cmbTipoImpuestoPIVA.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoImpuestoPIVA.BindearPropiedadEntidad = "IdTipoImpuestoPIVA"
        Me.cmbTipoImpuestoPIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoImpuestoPIVA.Enabled = False
        Me.cmbTipoImpuestoPIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoImpuestoPIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoImpuestoPIVA.FormattingEnabled = True
        Me.cmbTipoImpuestoPIVA.IsPK = False
        Me.cmbTipoImpuestoPIVA.IsRequired = False
        Me.cmbTipoImpuestoPIVA.Key = Nothing
        Me.cmbTipoImpuestoPIVA.LabelAsoc = Nothing
        Me.cmbTipoImpuestoPIVA.Location = New System.Drawing.Point(104, 42)
        Me.cmbTipoImpuestoPIVA.Name = "cmbTipoImpuestoPIVA"
        Me.cmbTipoImpuestoPIVA.Size = New System.Drawing.Size(213, 21)
        Me.cmbTipoImpuestoPIVA.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(9, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tipo de Impuesto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(323, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "% de Alicuota"
        '
        'txtDescripcionPIVA
        '
        Me.txtDescripcionPIVA.BindearPropiedadControl = "Text"
        Me.txtDescripcionPIVA.BindearPropiedadEntidad = "AlicuotaPIVA"
        Me.txtDescripcionPIVA.Enabled = False
        Me.txtDescripcionPIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcionPIVA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcionPIVA.Formato = "##0.00"
        Me.txtDescripcionPIVA.IsDecimal = True
        Me.txtDescripcionPIVA.IsNumber = True
        Me.txtDescripcionPIVA.IsPK = False
        Me.txtDescripcionPIVA.IsRequired = False
        Me.txtDescripcionPIVA.Key = ""
        Me.txtDescripcionPIVA.LabelAsoc = Me.Label2
        Me.txtDescripcionPIVA.Location = New System.Drawing.Point(400, 42)
        Me.txtDescripcionPIVA.MaxLength = 50
        Me.txtDescripcionPIVA.Name = "txtDescripcionPIVA"
        Me.txtDescripcionPIVA.Size = New System.Drawing.Size(59, 20)
        Me.txtDescripcionPIVA.TabIndex = 13
        Me.txtDescripcionPIVA.Text = "0.00"
        Me.txtDescripcionPIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpPIVA
        '
        Me.grpPIVA.Controls.Add(Me.chbPIVA)
        Me.grpPIVA.Controls.Add(Me.Label2)
        Me.grpPIVA.Controls.Add(Me.txtDescripcionPIVA)
        Me.grpPIVA.Controls.Add(Me.cmbTipoImpuestoPIVA)
        Me.grpPIVA.Controls.Add(Me.Label1)
        Me.grpPIVA.Location = New System.Drawing.Point(7, 75)
        Me.grpPIVA.Name = "grpPIVA"
        Me.grpPIVA.Size = New System.Drawing.Size(467, 71)
        Me.grpPIVA.TabIndex = 14
        Me.grpPIVA.TabStop = False
        Me.grpPIVA.Text = "Percepción de IVA"
        '
        'chbPIVA
        '
        Me.chbPIVA.AutoSize = True
        Me.chbPIVA.BindearPropiedadControl = ""
        Me.chbPIVA.BindearPropiedadEntidad = ""
        Me.chbPIVA.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPIVA.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPIVA.IsPK = False
        Me.chbPIVA.IsRequired = True
        Me.chbPIVA.Key = Nothing
        Me.chbPIVA.LabelAsoc = Me.lblAutoincremental
        Me.chbPIVA.Location = New System.Drawing.Point(12, 19)
        Me.chbPIVA.Name = "chbPIVA"
        Me.chbPIVA.Size = New System.Drawing.Size(147, 17)
        Me.chbPIVA.TabIndex = 15
        Me.chbPIVA.Text = "Aplica Percepción de IVA"
        Me.chbPIVA.UseVisualStyleBackColor = True
        '
        'ImpuestosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(483, 308)
        Me.Controls.Add(Me.grpPIVA)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cmbTipoImpuesto)
        Me.Controls.Add(Me.lblAutoincremental)
        Me.Controls.Add(Me.chbEstado)
        Me.Controls.Add(Me.lblAlicuota)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblIdTipoImpuesto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImpuestosDetalle"
        Me.Text = "Impuesto"
        Me.Controls.SetChildIndex(Me.lblIdTipoImpuesto, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lblAlicuota, 0)
        Me.Controls.SetChildIndex(Me.chbEstado, 0)
        Me.Controls.SetChildIndex(Me.lblAutoincremental, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoImpuesto, 0)
        Me.Controls.SetChildIndex(Me.GroupBox5, 0)
        Me.Controls.SetChildIndex(Me.GroupBox6, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.grpPIVA, 0)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.grpPIVA.ResumeLayout(False)
        Me.grpPIVA.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblIdTipoImpuesto As Eniac.Controles.Label
   Friend WithEvents lblAlicuota As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents chbEstado As Eniac.Controles.CheckBox
   Friend WithEvents lblAutoincremental As Eniac.Controles.Label
   Friend WithEvents cmbTipoImpuesto As Eniac.Controles.ComboBox
   Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
   Friend WithEvents UcCuentasVentas As Eniac.Win.ucCuentas
   Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
   Friend WithEvents UcCuentasCompras As Eniac.Win.ucCuentas
    Friend WithEvents cmbTipoImpuestoPIVA As Controles.ComboBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents txtDescripcionPIVA As Controles.TextBox
    Friend WithEvents grpPIVA As GroupBox
    Friend WithEvents chbPIVA As Controles.CheckBox
End Class
