<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UnidadesDeMedidasConversionesDetalle
   Inherits Eniac.Win.BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnidadesDeMedidasConversionesDetalle))
      Me.txtFactorConversion = New Eniac.Controles.TextBox()
      Me.lblFactorConversion = New Eniac.Controles.Label()
      Me.bscUMDesde = New Eniac.Controles.Buscador2()
      Me.lblUMDesde = New Eniac.Controles.Label()
      Me.bscCodigoUMDesde = New Eniac.Controles.Buscador2()
      Me.bscUMHacia = New Eniac.Controles.Buscador2()
      Me.Label1 = New Eniac.Controles.Label()
      Me.bscCodigoUMHacia = New Eniac.Controles.Buscador2()
      Me.chbFija = New Eniac.Controles.CheckBox()
        Me.lblAyudaFactorConversion = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(314, 112)
        Me.btnAceptar.TabIndex = 9
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(400, 112)
        Me.btnCancelar.TabIndex = 10
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(213, 112)
        Me.btnCopiar.TabIndex = 12
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(156, 112)
        Me.btnAplicar.TabIndex = 11
        '
        'txtFactorConversion
        '
        Me.txtFactorConversion.BindearPropiedadControl = "Text"
        Me.txtFactorConversion.BindearPropiedadEntidad = "FactorConversion"
        Me.txtFactorConversion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFactorConversion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFactorConversion.Formato = "N10"
        Me.txtFactorConversion.IsDecimal = True
        Me.txtFactorConversion.IsNumber = True
        Me.txtFactorConversion.IsPK = False
        Me.txtFactorConversion.IsRequired = True
        Me.txtFactorConversion.Key = ""
        Me.txtFactorConversion.LabelAsoc = Me.lblFactorConversion
        Me.txtFactorConversion.Location = New System.Drawing.Point(117, 64)
        Me.txtFactorConversion.MaxLength = 25
        Me.txtFactorConversion.Name = "txtFactorConversion"
        Me.txtFactorConversion.Size = New System.Drawing.Size(100, 20)
        Me.txtFactorConversion.TabIndex = 7
        Me.txtFactorConversion.Text = "0.0000000000"
        Me.txtFactorConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFactorConversion
        '
        Me.lblFactorConversion.AutoSize = True
        Me.lblFactorConversion.LabelAsoc = Nothing
        Me.lblFactorConversion.Location = New System.Drawing.Point(18, 67)
        Me.lblFactorConversion.Name = "lblFactorConversion"
        Me.lblFactorConversion.Size = New System.Drawing.Size(93, 13)
        Me.lblFactorConversion.TabIndex = 6
        Me.lblFactorConversion.Text = "Factor Conversión"
        '
        'bscUMDesde
        '
        Me.bscUMDesde.ActivarFiltroEnGrilla = True
        Me.bscUMDesde.BindearPropiedadControl = Nothing
        Me.bscUMDesde.BindearPropiedadEntidad = Nothing
        Me.bscUMDesde.ConfigBuscador = Nothing
        Me.bscUMDesde.Datos = Nothing
        Me.bscUMDesde.FilaDevuelta = Nothing
        Me.bscUMDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.bscUMDesde.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscUMDesde.IsDecimal = False
        Me.bscUMDesde.IsNumber = False
        Me.bscUMDesde.IsPK = False
        Me.bscUMDesde.IsRequired = True
        Me.bscUMDesde.Key = ""
        Me.bscUMDesde.LabelAsoc = Me.lblUMDesde
        Me.bscUMDesde.Location = New System.Drawing.Point(223, 12)
        Me.bscUMDesde.MaxLengh = "60"
        Me.bscUMDesde.Name = "bscUMDesde"
        Me.bscUMDesde.Permitido = True
        Me.bscUMDesde.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscUMDesde.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscUMDesde.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscUMDesde.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscUMDesde.Selecciono = False
        Me.bscUMDesde.Size = New System.Drawing.Size(240, 20)
        Me.bscUMDesde.TabIndex = 2
        '
        'lblUMDesde
        '
        Me.lblUMDesde.AutoSize = True
        Me.lblUMDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblUMDesde.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUMDesde.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblUMDesde.LabelAsoc = Nothing
        Me.lblUMDesde.Location = New System.Drawing.Point(18, 16)
        Me.lblUMDesde.Name = "lblUMDesde"
        Me.lblUMDesde.Size = New System.Drawing.Size(64, 13)
        Me.lblUMDesde.TabIndex = 0
        Me.lblUMDesde.Text = "U.M. Desde"
        '
        'bscCodigoUMDesde
        '
        Me.bscCodigoUMDesde.ActivarFiltroEnGrilla = True
        Me.bscCodigoUMDesde.BindearPropiedadControl = ""
        Me.bscCodigoUMDesde.BindearPropiedadEntidad = ""
        Me.bscCodigoUMDesde.ConfigBuscador = Nothing
        Me.bscCodigoUMDesde.Datos = Nothing
        Me.bscCodigoUMDesde.FilaDevuelta = Nothing
        Me.bscCodigoUMDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoUMDesde.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoUMDesde.IsDecimal = False
        Me.bscCodigoUMDesde.IsNumber = False
        Me.bscCodigoUMDesde.IsPK = False
        Me.bscCodigoUMDesde.IsRequired = True
        Me.bscCodigoUMDesde.Key = ""
        Me.bscCodigoUMDesde.LabelAsoc = Nothing
        Me.bscCodigoUMDesde.Location = New System.Drawing.Point(117, 12)
        Me.bscCodigoUMDesde.MaxLengh = "32767"
        Me.bscCodigoUMDesde.Name = "bscCodigoUMDesde"
        Me.bscCodigoUMDesde.Permitido = True
        Me.bscCodigoUMDesde.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoUMDesde.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoUMDesde.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoUMDesde.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoUMDesde.Selecciono = False
        Me.bscCodigoUMDesde.Size = New System.Drawing.Size(100, 20)
        Me.bscCodigoUMDesde.TabIndex = 1
        '
        'bscUMHacia
        '
        Me.bscUMHacia.ActivarFiltroEnGrilla = True
        Me.bscUMHacia.BindearPropiedadControl = Nothing
        Me.bscUMHacia.BindearPropiedadEntidad = Nothing
        Me.bscUMHacia.ConfigBuscador = Nothing
        Me.bscUMHacia.Datos = Nothing
        Me.bscUMHacia.FilaDevuelta = Nothing
        Me.bscUMHacia.ForeColorFocus = System.Drawing.Color.Red
        Me.bscUMHacia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscUMHacia.IsDecimal = False
        Me.bscUMHacia.IsNumber = False
        Me.bscUMHacia.IsPK = False
        Me.bscUMHacia.IsRequired = True
        Me.bscUMHacia.Key = ""
        Me.bscUMHacia.LabelAsoc = Me.Label1
        Me.bscUMHacia.Location = New System.Drawing.Point(223, 38)
        Me.bscUMHacia.MaxLengh = "60"
        Me.bscUMHacia.Name = "bscUMHacia"
        Me.bscUMHacia.Permitido = True
        Me.bscUMHacia.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscUMHacia.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscUMHacia.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscUMHacia.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscUMHacia.Selecciono = False
        Me.bscUMHacia.Size = New System.Drawing.Size(240, 20)
        Me.bscUMHacia.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = "lblUMHacia"
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(18, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "U.M. Hacia"
        '
        'bscCodigoUMHacia
        '
        Me.bscCodigoUMHacia.ActivarFiltroEnGrilla = True
        Me.bscCodigoUMHacia.BindearPropiedadControl = ""
        Me.bscCodigoUMHacia.BindearPropiedadEntidad = ""
        Me.bscCodigoUMHacia.ConfigBuscador = Nothing
        Me.bscCodigoUMHacia.Datos = Nothing
        Me.bscCodigoUMHacia.FilaDevuelta = Nothing
        Me.bscCodigoUMHacia.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoUMHacia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoUMHacia.IsDecimal = False
        Me.bscCodigoUMHacia.IsNumber = False
        Me.bscCodigoUMHacia.IsPK = False
        Me.bscCodigoUMHacia.IsRequired = True
        Me.bscCodigoUMHacia.Key = ""
        Me.bscCodigoUMHacia.LabelAsoc = Nothing
        Me.bscCodigoUMHacia.Location = New System.Drawing.Point(117, 38)
        Me.bscCodigoUMHacia.MaxLengh = "32767"
        Me.bscCodigoUMHacia.Name = "bscCodigoUMHacia"
        Me.bscCodigoUMHacia.Permitido = True
        Me.bscCodigoUMHacia.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoUMHacia.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoUMHacia.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoUMHacia.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoUMHacia.Selecciono = False
        Me.bscCodigoUMHacia.Size = New System.Drawing.Size(100, 20)
        Me.bscCodigoUMHacia.TabIndex = 4
        '
        'chbFija
        '
        Me.chbFija.AutoSize = True
        Me.chbFija.BindearPropiedadControl = "Checked"
        Me.chbFija.BindearPropiedadEntidad = "Fija"
        Me.chbFija.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFija.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFija.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbFija.IsPK = False
        Me.chbFija.IsRequired = False
        Me.chbFija.Key = Nothing
        Me.chbFija.LabelAsoc = Nothing
        Me.chbFija.Location = New System.Drawing.Point(223, 67)
        Me.chbFija.Name = "chbFija"
        Me.chbFija.Size = New System.Drawing.Size(42, 17)
        Me.chbFija.TabIndex = 8
        Me.chbFija.Text = "Fija"
        Me.chbFija.UseVisualStyleBackColor = True
        '
        'lblAyudaFactorConversion
        '
        Me.lblAyudaFactorConversion.AutoSize = True
        Me.lblAyudaFactorConversion.LabelAsoc = Nothing
        Me.lblAyudaFactorConversion.Location = New System.Drawing.Point(114, 87)
        Me.lblAyudaFactorConversion.Name = "lblAyudaFactorConversion"
        Me.lblAyudaFactorConversion.Size = New System.Drawing.Size(73, 13)
        Me.lblAyudaFactorConversion.TabIndex = 6
        Me.lblAyudaFactorConversion.Text = "1 {0} = {1} {2}"
        '
        'UnidadesDeMedidasConversionesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(489, 147)
        Me.Controls.Add(Me.chbFija)
        Me.Controls.Add(Me.bscUMHacia)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bscCodigoUMHacia)
        Me.Controls.Add(Me.bscUMDesde)
        Me.Controls.Add(Me.lblUMDesde)
        Me.Controls.Add(Me.bscCodigoUMDesde)
        Me.Controls.Add(Me.txtFactorConversion)
        Me.Controls.Add(Me.lblAyudaFactorConversion)
        Me.Controls.Add(Me.lblFactorConversion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UnidadesDeMedidasConversionesDetalle"
        Me.Text = "Conversión de Unidad de Medida"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.lblFactorConversion, 0)
        Me.Controls.SetChildIndex(Me.lblAyudaFactorConversion, 0)
        Me.Controls.SetChildIndex(Me.txtFactorConversion, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoUMDesde, 0)
        Me.Controls.SetChildIndex(Me.lblUMDesde, 0)
        Me.Controls.SetChildIndex(Me.bscUMDesde, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoUMHacia, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.bscUMHacia, 0)
        Me.Controls.SetChildIndex(Me.chbFija, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFactorConversion As Eniac.Controles.TextBox
   Friend WithEvents lblFactorConversion As Eniac.Controles.Label
   Friend WithEvents bscUMDesde As Controles.Buscador2
   Friend WithEvents lblUMDesde As Controles.Label
   Friend WithEvents bscCodigoUMDesde As Controles.Buscador2
   Friend WithEvents bscUMHacia As Controles.Buscador2
   Friend WithEvents Label1 As Controles.Label
   Friend WithEvents bscCodigoUMHacia As Controles.Buscador2
   Friend WithEvents chbFija As Controles.CheckBox
    Friend WithEvents lblAyudaFactorConversion As Controles.Label
End Class
