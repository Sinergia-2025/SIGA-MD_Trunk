<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpresasDetalle
   Inherits BaseDetalle

    'Form overrides dispose to clean up the component list.
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
      Me.txtIdEmpresa = New Eniac.Controles.TextBox()
      Me.lblIdEmpresa = New Eniac.Controles.Label()
      Me.lblCuitEmpresa = New Eniac.Controles.Label()
      Me.txtCuitEmpresa = New Eniac.Controles.TextBox()
      Me.lblNombreEmpresa = New Eniac.Controles.Label()
      Me.txtNombreEmpresa = New Eniac.Controles.TextBox()
      Me.lblCategoriaFiscal = New Eniac.Controles.Label()
      Me.txtCategoriaFiscal = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(224, 131)
      Me.btnAceptar.TabIndex = 10
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(310, 131)
      Me.btnCancelar.TabIndex = 11
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(123, 131)
      Me.btnCopiar.TabIndex = 9
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(66, 131)
      Me.btnAplicar.TabIndex = 8
      '
      'txtIdEmpresa
      '
      Me.txtIdEmpresa.BindearPropiedadControl = "Text"
      Me.txtIdEmpresa.BindearPropiedadEntidad = "IdEmpresa"
      Me.txtIdEmpresa.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdEmpresa.Formato = ""
      Me.txtIdEmpresa.IsDecimal = False
      Me.txtIdEmpresa.IsNumber = True
      Me.txtIdEmpresa.IsPK = True
      Me.txtIdEmpresa.IsRequired = True
      Me.txtIdEmpresa.Key = ""
      Me.txtIdEmpresa.LabelAsoc = Me.lblIdEmpresa
      Me.txtIdEmpresa.Location = New System.Drawing.Point(104, 12)
      Me.txtIdEmpresa.MaxLength = 4
      Me.txtIdEmpresa.Name = "txtIdEmpresa"
      Me.txtIdEmpresa.Size = New System.Drawing.Size(46, 20)
      Me.txtIdEmpresa.TabIndex = 1
      Me.txtIdEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblIdEmpresa
      '
      Me.lblIdEmpresa.AutoSize = True
      Me.lblIdEmpresa.LabelAsoc = Nothing
      Me.lblIdEmpresa.Location = New System.Drawing.Point(15, 15)
      Me.lblIdEmpresa.Name = "lblIdEmpresa"
      Me.lblIdEmpresa.Size = New System.Drawing.Size(40, 13)
      Me.lblIdEmpresa.TabIndex = 0
      Me.lblIdEmpresa.Text = "Codigo"
      '
      'lblCuitEmpresa
      '
      Me.lblCuitEmpresa.AutoSize = True
      Me.lblCuitEmpresa.LabelAsoc = Nothing
      Me.lblCuitEmpresa.Location = New System.Drawing.Point(15, 72)
      Me.lblCuitEmpresa.Name = "lblCuitEmpresa"
      Me.lblCuitEmpresa.Size = New System.Drawing.Size(25, 13)
      Me.lblCuitEmpresa.TabIndex = 4
      Me.lblCuitEmpresa.Text = "Cuit"
      '
      'txtCuitEmpresa
      '
      Me.txtCuitEmpresa.BindearPropiedadControl = "Text"
      Me.txtCuitEmpresa.BindearPropiedadEntidad = "CuitEmpresa"
      Me.txtCuitEmpresa.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuitEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuitEmpresa.Formato = ""
      Me.txtCuitEmpresa.IsDecimal = False
      Me.txtCuitEmpresa.IsNumber = False
      Me.txtCuitEmpresa.IsPK = False
      Me.txtCuitEmpresa.IsRequired = True
      Me.txtCuitEmpresa.Key = ""
      Me.txtCuitEmpresa.LabelAsoc = Me.lblCuitEmpresa
      Me.txtCuitEmpresa.Location = New System.Drawing.Point(104, 69)
      Me.txtCuitEmpresa.MaxLength = 13
      Me.txtCuitEmpresa.Name = "txtCuitEmpresa"
      Me.txtCuitEmpresa.Size = New System.Drawing.Size(104, 20)
      Me.txtCuitEmpresa.TabIndex = 5
      '
      'lblNombreEmpresa
      '
      Me.lblNombreEmpresa.AutoSize = True
      Me.lblNombreEmpresa.LabelAsoc = Nothing
      Me.lblNombreEmpresa.Location = New System.Drawing.Point(15, 43)
      Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
      Me.lblNombreEmpresa.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreEmpresa.TabIndex = 2
      Me.lblNombreEmpresa.Text = "Nombre"
      '
      'txtNombreEmpresa
      '
      Me.txtNombreEmpresa.BindearPropiedadControl = "Text"
      Me.txtNombreEmpresa.BindearPropiedadEntidad = "NombreEmpresa"
      Me.txtNombreEmpresa.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreEmpresa.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreEmpresa.Formato = ""
      Me.txtNombreEmpresa.IsDecimal = False
      Me.txtNombreEmpresa.IsNumber = False
      Me.txtNombreEmpresa.IsPK = False
      Me.txtNombreEmpresa.IsRequired = True
      Me.txtNombreEmpresa.Key = ""
      Me.txtNombreEmpresa.LabelAsoc = Me.lblNombreEmpresa
      Me.txtNombreEmpresa.Location = New System.Drawing.Point(104, 40)
      Me.txtNombreEmpresa.MaxLength = 100
      Me.txtNombreEmpresa.Name = "txtNombreEmpresa"
      Me.txtNombreEmpresa.Size = New System.Drawing.Size(289, 20)
      Me.txtNombreEmpresa.TabIndex = 3
      '
      'lblCategoriaFiscal
      '
      Me.lblCategoriaFiscal.AutoSize = True
      Me.lblCategoriaFiscal.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblCategoriaFiscal.LabelAsoc = Nothing
      Me.lblCategoriaFiscal.Location = New System.Drawing.Point(12, 103)
      Me.lblCategoriaFiscal.Name = "lblCategoriaFiscal"
      Me.lblCategoriaFiscal.Size = New System.Drawing.Size(82, 13)
      Me.lblCategoriaFiscal.TabIndex = 6
      Me.lblCategoriaFiscal.Text = "Categoria Fiscal"
      '
      'txtCategoriaFiscal
      '
      Me.txtCategoriaFiscal.BackColor = System.Drawing.Color.White
      Me.txtCategoriaFiscal.BindearPropiedadControl = "Text"
      Me.txtCategoriaFiscal.BindearPropiedadEntidad = "NombreCategoriaFiscal"
      Me.txtCategoriaFiscal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCategoriaFiscal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCategoriaFiscal.Formato = ""
      Me.txtCategoriaFiscal.IsDecimal = False
      Me.txtCategoriaFiscal.IsNumber = False
      Me.txtCategoriaFiscal.IsPK = False
      Me.txtCategoriaFiscal.IsRequired = False
      Me.txtCategoriaFiscal.Key = ""
      Me.txtCategoriaFiscal.LabelAsoc = Me.lblCuitEmpresa
      Me.txtCategoriaFiscal.Location = New System.Drawing.Point(103, 100)
      Me.txtCategoriaFiscal.MaxLength = 13
      Me.txtCategoriaFiscal.Name = "txtCategoriaFiscal"
      Me.txtCategoriaFiscal.ReadOnly = True
      Me.txtCategoriaFiscal.Size = New System.Drawing.Size(226, 20)
      Me.txtCategoriaFiscal.TabIndex = 12
      '
      'EmpresasDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(399, 166)
      Me.Controls.Add(Me.txtCategoriaFiscal)
      Me.Controls.Add(Me.lblCategoriaFiscal)
      Me.Controls.Add(Me.txtIdEmpresa)
      Me.Controls.Add(Me.lblIdEmpresa)
      Me.Controls.Add(Me.lblCuitEmpresa)
      Me.Controls.Add(Me.txtCuitEmpresa)
      Me.Controls.Add(Me.lblNombreEmpresa)
      Me.Controls.Add(Me.txtNombreEmpresa)
      Me.Name = "EmpresasDetalle"
      Me.Text = "Empresa"
      Me.Controls.SetChildIndex(Me.txtNombreEmpresa, 0)
      Me.Controls.SetChildIndex(Me.lblNombreEmpresa, 0)
      Me.Controls.SetChildIndex(Me.txtCuitEmpresa, 0)
      Me.Controls.SetChildIndex(Me.lblCuitEmpresa, 0)
      Me.Controls.SetChildIndex(Me.lblIdEmpresa, 0)
      Me.Controls.SetChildIndex(Me.txtIdEmpresa, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.lblCategoriaFiscal, 0)
      Me.Controls.SetChildIndex(Me.txtCategoriaFiscal, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtIdEmpresa As Eniac.Controles.TextBox
   Friend WithEvents lblIdEmpresa As Eniac.Controles.Label
   Friend WithEvents lblCuitEmpresa As Eniac.Controles.Label
   Friend WithEvents txtCuitEmpresa As Eniac.Controles.TextBox
   Friend WithEvents lblNombreEmpresa As Eniac.Controles.Label
   Friend WithEvents txtNombreEmpresa As Eniac.Controles.TextBox
   Friend WithEvents lblCategoriaFiscal As Eniac.Controles.Label
   Friend WithEvents txtCategoriaFiscal As Eniac.Controles.TextBox
End Class
