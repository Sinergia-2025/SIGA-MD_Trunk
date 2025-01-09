<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActividadesDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActividadesDetalle))
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombreActividad = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtActividad = New Eniac.Controles.TextBox()
      Me.txtPorcentaje = New Eniac.Controles.TextBox()
      Me.lblPorcentaje = New Eniac.Controles.Label()
      Me.lblProvincia = New Eniac.Controles.Label()
      Me.cmbProvincia = New Eniac.Controles.ComboBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtBaseImponible = New Eniac.Controles.TextBox()
      Me.lblBaseImponible = New Eniac.Controles.Label()
      Me.txtCodigoAfip = New Eniac.Controles.TextBox()
      Me.lblCodigoAfip = New Eniac.Controles.Label()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(248, 171)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(331, 171)
      Me.btnCancelar.TabIndex = 6
      '
      'btnCopiar
      '
      Me.btnCopiar.TabIndex = 14
      '
      'btnAplicar
      '
      Me.btnAplicar.TabIndex = 13
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.LabelAsoc = Nothing
      Me.lblNombre.Location = New System.Drawing.Point(8, 85)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(91, 13)
      Me.lblNombre.TabIndex = 10
      Me.lblNombre.Text = "Nombre Actividad"
      '
      'txtNombreActividad
      '
      Me.txtNombreActividad.BindearPropiedadControl = "Text"
      Me.txtNombreActividad.BindearPropiedadEntidad = "NombreActividad"
      Me.txtNombreActividad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreActividad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreActividad.Formato = ""
      Me.txtNombreActividad.IsDecimal = False
      Me.txtNombreActividad.IsNumber = False
      Me.txtNombreActividad.IsPK = False
      Me.txtNombreActividad.IsRequired = True
      Me.txtNombreActividad.Key = ""
      Me.txtNombreActividad.LabelAsoc = Me.lblNombre
      Me.txtNombreActividad.Location = New System.Drawing.Point(108, 82)
      Me.txtNombreActividad.MaxLength = 50
      Me.txtNombreActividad.Name = "txtNombreActividad"
      Me.txtNombreActividad.Size = New System.Drawing.Size(303, 20)
      Me.txtNombreActividad.TabIndex = 1
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.LabelAsoc = Nothing
      Me.lblId.Location = New System.Drawing.Point(8, 57)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(87, 13)
      Me.lblId.TabIndex = 9
      Me.lblId.Text = "Código Actividad"
      '
      'txtActividad
      '
      Me.txtActividad.BindearPropiedadControl = "Text"
      Me.txtActividad.BindearPropiedadEntidad = "IdActividad"
      Me.txtActividad.ForeColorFocus = System.Drawing.Color.Red
      Me.txtActividad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtActividad.Formato = ""
      Me.txtActividad.IsDecimal = False
      Me.txtActividad.IsNumber = True
      Me.txtActividad.IsPK = True
      Me.txtActividad.IsRequired = True
      Me.txtActividad.Key = ""
      Me.txtActividad.LabelAsoc = Me.lblId
      Me.txtActividad.Location = New System.Drawing.Point(108, 54)
      Me.txtActividad.MaxLength = 7
      Me.txtActividad.Name = "txtActividad"
      Me.txtActividad.Size = New System.Drawing.Size(73, 20)
      Me.txtActividad.TabIndex = 0
      Me.txtActividad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtPorcentaje
      '
      Me.txtPorcentaje.BindearPropiedadControl = "Text"
      Me.txtPorcentaje.BindearPropiedadEntidad = "Porcentaje"
      Me.txtPorcentaje.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPorcentaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPorcentaje.Formato = "##0.00"
      Me.txtPorcentaje.IsDecimal = True
      Me.txtPorcentaje.IsNumber = True
      Me.txtPorcentaje.IsPK = False
      Me.txtPorcentaje.IsRequired = True
      Me.txtPorcentaje.Key = ""
      Me.txtPorcentaje.LabelAsoc = Me.lblPorcentaje
      Me.txtPorcentaje.Location = New System.Drawing.Point(108, 111)
      Me.txtPorcentaje.MaxLength = 5
      Me.txtPorcentaje.Name = "txtPorcentaje"
      Me.txtPorcentaje.Size = New System.Drawing.Size(54, 20)
      Me.txtPorcentaje.TabIndex = 2
      Me.txtPorcentaje.Text = "0.00"
      Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPorcentaje
      '
      Me.lblPorcentaje.AutoSize = True
      Me.lblPorcentaje.LabelAsoc = Nothing
      Me.lblPorcentaje.Location = New System.Drawing.Point(8, 114)
      Me.lblPorcentaje.Name = "lblPorcentaje"
      Me.lblPorcentaje.Size = New System.Drawing.Size(58, 13)
      Me.lblPorcentaje.TabIndex = 11
      Me.lblPorcentaje.Text = "Porcentaje"
      '
      'lblProvincia
      '
      Me.lblProvincia.AutoSize = True
      Me.lblProvincia.LabelAsoc = Nothing
      Me.lblProvincia.Location = New System.Drawing.Point(9, 30)
      Me.lblProvincia.Name = "lblProvincia"
      Me.lblProvincia.Size = New System.Drawing.Size(51, 13)
      Me.lblProvincia.TabIndex = 8
      Me.lblProvincia.Text = "Provincia"
      '
      'cmbProvincia
      '
      Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
      Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
      Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbProvincia.FormattingEnabled = True
      Me.cmbProvincia.IsPK = True
      Me.cmbProvincia.IsRequired = True
      Me.cmbProvincia.Key = Nothing
      Me.cmbProvincia.LabelAsoc = Me.lblProvincia
      Me.cmbProvincia.Location = New System.Drawing.Point(108, 25)
      Me.cmbProvincia.Name = "cmbProvincia"
      Me.cmbProvincia.Size = New System.Drawing.Size(190, 21)
      Me.cmbProvincia.TabIndex = 7
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(166, 115)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(15, 13)
      Me.Label1.TabIndex = 15
      Me.Label1.Text = "%"
      '
      'txtBaseImponible
      '
      Me.txtBaseImponible.BindearPropiedadControl = "Text"
      Me.txtBaseImponible.BindearPropiedadEntidad = "BaseImponible"
      Me.txtBaseImponible.ForeColorFocus = System.Drawing.Color.Red
      Me.txtBaseImponible.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtBaseImponible.Formato = "##,##0.00"
      Me.txtBaseImponible.IsDecimal = True
      Me.txtBaseImponible.IsNumber = True
      Me.txtBaseImponible.IsPK = False
      Me.txtBaseImponible.IsRequired = False
      Me.txtBaseImponible.Key = ""
      Me.txtBaseImponible.LabelAsoc = Me.lblBaseImponible
      Me.txtBaseImponible.Location = New System.Drawing.Point(108, 142)
      Me.txtBaseImponible.MaxLength = 8
      Me.txtBaseImponible.Name = "txtBaseImponible"
      Me.txtBaseImponible.Size = New System.Drawing.Size(72, 20)
      Me.txtBaseImponible.TabIndex = 3
      Me.txtBaseImponible.Text = "0.00"
      Me.txtBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBaseImponible
      '
      Me.lblBaseImponible.AutoSize = True
      Me.lblBaseImponible.LabelAsoc = Nothing
      Me.lblBaseImponible.Location = New System.Drawing.Point(9, 145)
      Me.lblBaseImponible.Name = "lblBaseImponible"
      Me.lblBaseImponible.Size = New System.Drawing.Size(79, 13)
      Me.lblBaseImponible.TabIndex = 12
      Me.lblBaseImponible.Text = "Base Imponible"
      '
      'txtCodigoAfip
      '
      Me.txtCodigoAfip.BindearPropiedadControl = "Text"
      Me.txtCodigoAfip.BindearPropiedadEntidad = "CodigoAfip"
      Me.txtCodigoAfip.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigoAfip.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigoAfip.Formato = ""
      Me.txtCodigoAfip.IsDecimal = False
      Me.txtCodigoAfip.IsNumber = True
      Me.txtCodigoAfip.IsPK = False
      Me.txtCodigoAfip.IsRequired = False
      Me.txtCodigoAfip.Key = ""
      Me.txtCodigoAfip.LabelAsoc = Me.lblCodigoAfip
      Me.txtCodigoAfip.Location = New System.Drawing.Point(268, 145)
      Me.txtCodigoAfip.MaxLength = 10
      Me.txtCodigoAfip.Name = "txtCodigoAfip"
      Me.txtCodigoAfip.Size = New System.Drawing.Size(84, 20)
      Me.txtCodigoAfip.TabIndex = 4
      Me.txtCodigoAfip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCodigoAfip
      '
      Me.lblCodigoAfip.AutoSize = True
      Me.lblCodigoAfip.LabelAsoc = Nothing
      Me.lblCodigoAfip.Location = New System.Drawing.Point(196, 148)
      Me.lblCodigoAfip.Name = "lblCodigoAfip"
      Me.lblCodigoAfip.Size = New System.Drawing.Size(66, 13)
      Me.lblCodigoAfip.TabIndex = 16
      Me.lblCodigoAfip.Text = "Código AFIP"
      '
      'ActividadesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(423, 206)
      Me.Controls.Add(Me.txtCodigoAfip)
      Me.Controls.Add(Me.lblCodigoAfip)
      Me.Controls.Add(Me.txtBaseImponible)
      Me.Controls.Add(Me.lblBaseImponible)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblProvincia)
      Me.Controls.Add(Me.cmbProvincia)
      Me.Controls.Add(Me.txtPorcentaje)
      Me.Controls.Add(Me.lblPorcentaje)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombreActividad)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtActividad)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ActividadesDetalle"
      Me.Text = "Actividad"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtActividad, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombreActividad, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.lblPorcentaje, 0)
      Me.Controls.SetChildIndex(Me.txtPorcentaje, 0)
      Me.Controls.SetChildIndex(Me.cmbProvincia, 0)
      Me.Controls.SetChildIndex(Me.lblProvincia, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.lblBaseImponible, 0)
      Me.Controls.SetChildIndex(Me.txtBaseImponible, 0)
      Me.Controls.SetChildIndex(Me.lblCodigoAfip, 0)
      Me.Controls.SetChildIndex(Me.txtCodigoAfip, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombreActividad As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtActividad As Eniac.Controles.TextBox
   Friend WithEvents txtPorcentaje As Eniac.Controles.TextBox
   Friend WithEvents lblPorcentaje As Eniac.Controles.Label
   Friend WithEvents lblProvincia As Eniac.Controles.Label
   Friend WithEvents cmbProvincia As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtBaseImponible As Eniac.Controles.TextBox
   Friend WithEvents lblBaseImponible As Eniac.Controles.Label
   Friend WithEvents txtCodigoAfip As Eniac.Controles.TextBox
   Friend WithEvents lblCodigoAfip As Eniac.Controles.Label

End Class
