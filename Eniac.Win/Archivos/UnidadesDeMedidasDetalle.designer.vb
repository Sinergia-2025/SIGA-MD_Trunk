<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UnidadesDeMedidasDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UnidadesDeMedidasDetalle))
      Me.lblNombreUnidadDeMedida = New Eniac.Controles.Label()
      Me.txtNombreUnidadDeMedida = New Eniac.Controles.TextBox()
      Me.lblIdUnidadDeMedida = New Eniac.Controles.Label()
      Me.txtIdUnidadDeMedida = New Eniac.Controles.TextBox()
      Me.txtConversionAKilos = New Eniac.Controles.TextBox()
      Me.lblConversionAKilos = New Eniac.Controles.Label()
      Me.txtIdAFIP = New Eniac.Controles.TextBox()
      Me.lblIdAFIP = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(113, 133)
        Me.btnAceptar.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(199, 133)
        Me.btnCancelar.TabIndex = 5
        '
        'lblNombreUnidadDeMedida
        '
        Me.lblNombreUnidadDeMedida.AutoSize = True
        Me.lblNombreUnidadDeMedida.LabelAsoc = Nothing
        Me.lblNombreUnidadDeMedida.Location = New System.Drawing.Point(11, 50)
        Me.lblNombreUnidadDeMedida.Name = "lblNombreUnidadDeMedida"
        Me.lblNombreUnidadDeMedida.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreUnidadDeMedida.TabIndex = 7
        Me.lblNombreUnidadDeMedida.Text = "Nombre"
        '
        'txtNombreUnidadDeMedida
        '
        Me.txtNombreUnidadDeMedida.BindearPropiedadControl = "Text"
        Me.txtNombreUnidadDeMedida.BindearPropiedadEntidad = "NombreUnidadDeMedida"
        Me.txtNombreUnidadDeMedida.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreUnidadDeMedida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreUnidadDeMedida.Formato = ""
        Me.txtNombreUnidadDeMedida.IsDecimal = False
        Me.txtNombreUnidadDeMedida.IsNumber = False
        Me.txtNombreUnidadDeMedida.IsPK = False
        Me.txtNombreUnidadDeMedida.IsRequired = True
        Me.txtNombreUnidadDeMedida.Key = ""
        Me.txtNombreUnidadDeMedida.LabelAsoc = Me.lblNombreUnidadDeMedida
        Me.txtNombreUnidadDeMedida.Location = New System.Drawing.Point(89, 46)
        Me.txtNombreUnidadDeMedida.MaxLength = 15
        Me.txtNombreUnidadDeMedida.Name = "txtNombreUnidadDeMedida"
        Me.txtNombreUnidadDeMedida.Size = New System.Drawing.Size(188, 20)
        Me.txtNombreUnidadDeMedida.TabIndex = 1
        '
        'lblIdUnidadDeMedida
        '
        Me.lblIdUnidadDeMedida.AutoSize = True
        Me.lblIdUnidadDeMedida.LabelAsoc = Nothing
        Me.lblIdUnidadDeMedida.Location = New System.Drawing.Point(11, 22)
        Me.lblIdUnidadDeMedida.Name = "lblIdUnidadDeMedida"
        Me.lblIdUnidadDeMedida.Size = New System.Drawing.Size(40, 13)
        Me.lblIdUnidadDeMedida.TabIndex = 6
        Me.lblIdUnidadDeMedida.Text = "Código"
        '
        'txtIdUnidadDeMedida
        '
        Me.txtIdUnidadDeMedida.BindearPropiedadControl = "Text"
        Me.txtIdUnidadDeMedida.BindearPropiedadEntidad = "IdUnidadDeMedida"
        Me.txtIdUnidadDeMedida.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdUnidadDeMedida.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdUnidadDeMedida.Formato = ""
        Me.txtIdUnidadDeMedida.IsDecimal = False
        Me.txtIdUnidadDeMedida.IsNumber = False
        Me.txtIdUnidadDeMedida.IsPK = True
        Me.txtIdUnidadDeMedida.IsRequired = True
        Me.txtIdUnidadDeMedida.Key = ""
        Me.txtIdUnidadDeMedida.LabelAsoc = Me.lblIdUnidadDeMedida
        Me.txtIdUnidadDeMedida.Location = New System.Drawing.Point(89, 18)
        Me.txtIdUnidadDeMedida.MaxLength = 10
        Me.txtIdUnidadDeMedida.Name = "txtIdUnidadDeMedida"
        Me.txtIdUnidadDeMedida.Size = New System.Drawing.Size(83, 20)
        Me.txtIdUnidadDeMedida.TabIndex = 0
        Me.txtIdUnidadDeMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtConversionAKilos
        '
        Me.txtConversionAKilos.BindearPropiedadControl = "Text"
        Me.txtConversionAKilos.BindearPropiedadEntidad = "ConversionAKilos"
        Me.txtConversionAKilos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtConversionAKilos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtConversionAKilos.Formato = "##0.000"
        Me.txtConversionAKilos.IsDecimal = True
        Me.txtConversionAKilos.IsNumber = True
        Me.txtConversionAKilos.IsPK = False
        Me.txtConversionAKilos.IsRequired = True
        Me.txtConversionAKilos.Key = ""
        Me.txtConversionAKilos.LabelAsoc = Me.lblConversionAKilos
        Me.txtConversionAKilos.Location = New System.Drawing.Point(89, 72)
        Me.txtConversionAKilos.MaxLength = 7
        Me.txtConversionAKilos.Name = "txtConversionAKilos"
        Me.txtConversionAKilos.Size = New System.Drawing.Size(66, 20)
        Me.txtConversionAKilos.TabIndex = 2
        Me.txtConversionAKilos.Text = "0.000"
        Me.txtConversionAKilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblConversionAKilos
        '
        Me.lblConversionAKilos.AutoSize = True
        Me.lblConversionAKilos.LabelAsoc = Nothing
        Me.lblConversionAKilos.Location = New System.Drawing.Point(11, 75)
        Me.lblConversionAKilos.Name = "lblConversionAKilos"
        Me.lblConversionAKilos.Size = New System.Drawing.Size(69, 13)
        Me.lblConversionAKilos.TabIndex = 8
        Me.lblConversionAKilos.Text = "Conv. a Kilos"
        '
        'txtIdAFIP
        '
        Me.txtIdAFIP.BindearPropiedadControl = "Text"
        Me.txtIdAFIP.BindearPropiedadEntidad = "IdAFIP"
        Me.txtIdAFIP.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdAFIP.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdAFIP.Formato = "##0"
        Me.txtIdAFIP.IsDecimal = False
        Me.txtIdAFIP.IsNumber = True
        Me.txtIdAFIP.IsPK = False
        Me.txtIdAFIP.IsRequired = True
        Me.txtIdAFIP.Key = ""
        Me.txtIdAFIP.LabelAsoc = Me.lblIdAFIP
        Me.txtIdAFIP.Location = New System.Drawing.Point(89, 98)
        Me.txtIdAFIP.MaxLength = 7
        Me.txtIdAFIP.Name = "txtIdAFIP"
        Me.txtIdAFIP.Size = New System.Drawing.Size(66, 20)
        Me.txtIdAFIP.TabIndex = 3
        Me.txtIdAFIP.Text = "0"
        Me.txtIdAFIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdAFIP
        '
        Me.lblIdAFIP.AutoSize = True
        Me.lblIdAFIP.LabelAsoc = Nothing
        Me.lblIdAFIP.Location = New System.Drawing.Point(11, 101)
        Me.lblIdAFIP.Name = "lblIdAFIP"
        Me.lblIdAFIP.Size = New System.Drawing.Size(55, 13)
        Me.lblIdAFIP.TabIndex = 9
        Me.lblIdAFIP.Text = "Cod. AFIP"
        '
        'UnidadesDeMedidasDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(288, 168)
        Me.Controls.Add(Me.txtIdAFIP)
        Me.Controls.Add(Me.lblIdAFIP)
        Me.Controls.Add(Me.txtConversionAKilos)
        Me.Controls.Add(Me.lblConversionAKilos)
        Me.Controls.Add(Me.lblNombreUnidadDeMedida)
        Me.Controls.Add(Me.txtNombreUnidadDeMedida)
        Me.Controls.Add(Me.lblIdUnidadDeMedida)
        Me.Controls.Add(Me.txtIdUnidadDeMedida)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UnidadesDeMedidasDetalle"
        Me.Text = "Unidad de Medida"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtIdUnidadDeMedida, 0)
        Me.Controls.SetChildIndex(Me.lblIdUnidadDeMedida, 0)
        Me.Controls.SetChildIndex(Me.txtNombreUnidadDeMedida, 0)
        Me.Controls.SetChildIndex(Me.lblNombreUnidadDeMedida, 0)
        Me.Controls.SetChildIndex(Me.lblConversionAKilos, 0)
        Me.Controls.SetChildIndex(Me.txtConversionAKilos, 0)
        Me.Controls.SetChildIndex(Me.lblIdAFIP, 0)
        Me.Controls.SetChildIndex(Me.txtIdAFIP, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombreUnidadDeMedida As Eniac.Controles.Label
   Friend WithEvents txtNombreUnidadDeMedida As Eniac.Controles.TextBox
   Friend WithEvents lblIdUnidadDeMedida As Eniac.Controles.Label
   Friend WithEvents txtIdUnidadDeMedida As Eniac.Controles.TextBox
   Friend WithEvents txtConversionAKilos As Eniac.Controles.TextBox
   Friend WithEvents lblConversionAKilos As Eniac.Controles.Label
   Friend WithEvents txtIdAFIP As Eniac.Controles.TextBox
   Friend WithEvents lblIdAFIP As Eniac.Controles.Label

End Class
