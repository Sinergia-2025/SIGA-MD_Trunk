<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametrosSucursalesDetalle
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
      Me.lblValorParametro = New Eniac.Controles.Label()
      Me.txtValorParametro = New Eniac.Controles.TextBox()
      Me.lblIdParametro = New Eniac.Controles.Label()
      Me.lblCategoria = New Eniac.Controles.Label()
      Me.txtCategoria = New Eniac.Controles.TextBox()
      Me.lblNombreParametro = New Eniac.Controles.Label()
      Me.txtNombreParametro = New Eniac.Controles.TextBox()
      Me.bscParametro = New Eniac.Controles.Buscador2()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(505, 125)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(591, 125)
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(404, 125)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(347, 125)
      '
      'lblValorParametro
      '
      Me.lblValorParametro.AutoSize = True
      Me.lblValorParametro.Location = New System.Drawing.Point(21, 41)
      Me.lblValorParametro.Name = "lblValorParametro"
      Me.lblValorParametro.Size = New System.Drawing.Size(31, 13)
      Me.lblValorParametro.TabIndex = 7
      Me.lblValorParametro.Text = "Valor"
      '
      'txtValorParametro
      '
      Me.txtValorParametro.BindearPropiedadControl = "Text"
      Me.txtValorParametro.BindearPropiedadEntidad = "ValorParametro"
      Me.txtValorParametro.ForeColorFocus = System.Drawing.Color.Red
      Me.txtValorParametro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtValorParametro.Formato = ""
      Me.txtValorParametro.IsDecimal = False
      Me.txtValorParametro.IsNumber = False
      Me.txtValorParametro.IsPK = False
      Me.txtValorParametro.IsRequired = True
      Me.txtValorParametro.Key = ""
      Me.txtValorParametro.LabelAsoc = Me.lblValorParametro
      Me.txtValorParametro.Location = New System.Drawing.Point(99, 38)
      Me.txtValorParametro.MaxLength = 200
      Me.txtValorParametro.Name = "txtValorParametro"
      Me.txtValorParametro.Size = New System.Drawing.Size(570, 20)
      Me.txtValorParametro.TabIndex = 8
      '
      'lblIdParametro
      '
      Me.lblIdParametro.AutoSize = True
      Me.lblIdParametro.Location = New System.Drawing.Point(21, 15)
      Me.lblIdParametro.Name = "lblIdParametro"
      Me.lblIdParametro.Size = New System.Drawing.Size(40, 13)
      Me.lblIdParametro.TabIndex = 5
      Me.lblIdParametro.Text = "Código"
      '
      'lblCategoria
      '
      Me.lblCategoria.AutoSize = True
      Me.lblCategoria.Location = New System.Drawing.Point(21, 67)
      Me.lblCategoria.Name = "lblCategoria"
      Me.lblCategoria.Size = New System.Drawing.Size(54, 13)
      Me.lblCategoria.TabIndex = 9
      Me.lblCategoria.Text = "Categoría"
      '
      'txtCategoria
      '
      Me.txtCategoria.BindearPropiedadControl = ""
      Me.txtCategoria.BindearPropiedadEntidad = ""
      Me.txtCategoria.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCategoria.Formato = ""
      Me.txtCategoria.IsDecimal = False
      Me.txtCategoria.IsNumber = False
      Me.txtCategoria.IsPK = False
      Me.txtCategoria.IsRequired = False
      Me.txtCategoria.Key = ""
      Me.txtCategoria.LabelAsoc = Me.lblCategoria
      Me.txtCategoria.Location = New System.Drawing.Point(99, 64)
      Me.txtCategoria.MaxLength = 20
      Me.txtCategoria.Name = "txtCategoria"
      Me.txtCategoria.ReadOnly = True
      Me.txtCategoria.Size = New System.Drawing.Size(211, 20)
      Me.txtCategoria.TabIndex = 10
      '
      'lblNombreParametro
      '
      Me.lblNombreParametro.AutoSize = True
      Me.lblNombreParametro.Location = New System.Drawing.Point(21, 93)
      Me.lblNombreParametro.Name = "lblNombreParametro"
      Me.lblNombreParametro.Size = New System.Drawing.Size(63, 13)
      Me.lblNombreParametro.TabIndex = 11
      Me.lblNombreParametro.Text = "Descripción"
      '
      'txtNombreParametro
      '
      Me.txtNombreParametro.BindearPropiedadControl = ""
      Me.txtNombreParametro.BindearPropiedadEntidad = ""
      Me.txtNombreParametro.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreParametro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreParametro.Formato = ""
      Me.txtNombreParametro.IsDecimal = False
      Me.txtNombreParametro.IsNumber = False
      Me.txtNombreParametro.IsPK = False
      Me.txtNombreParametro.IsRequired = False
      Me.txtNombreParametro.Key = ""
      Me.txtNombreParametro.LabelAsoc = Me.lblNombreParametro
      Me.txtNombreParametro.Location = New System.Drawing.Point(99, 90)
      Me.txtNombreParametro.MaxLength = 200
      Me.txtNombreParametro.Name = "txtNombreParametro"
      Me.txtNombreParametro.ReadOnly = True
      Me.txtNombreParametro.Size = New System.Drawing.Size(570, 20)
      Me.txtNombreParametro.TabIndex = 12
      '
      'bscParametro
      '
      Me.bscParametro.ActivarFiltroEnGrilla = True
      Me.bscParametro.BindearPropiedadControl = Nothing
      Me.bscParametro.BindearPropiedadEntidad = Nothing
      Me.bscParametro.ConfigBuscador = Nothing
      Me.bscParametro.Datos = Nothing
      Me.bscParametro.FilaDevuelta = Nothing
      Me.bscParametro.ForeColorFocus = System.Drawing.Color.Red
      Me.bscParametro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscParametro.IsDecimal = False
      Me.bscParametro.IsNumber = False
      Me.bscParametro.IsPK = True
      Me.bscParametro.IsRequired = False
      Me.bscParametro.Key = ""
      Me.bscParametro.LabelAsoc = Nothing
      Me.bscParametro.Location = New System.Drawing.Point(99, 12)
      Me.bscParametro.MaxLengh = "32767"
      Me.bscParametro.Name = "bscParametro"
      Me.bscParametro.Permitido = True
      Me.bscParametro.Selecciono = False
      Me.bscParametro.Size = New System.Drawing.Size(288, 20)
      Me.bscParametro.TabIndex = 13
      Me.bscParametro.TextBoxBackColor = System.Drawing.Color.Empty
      Me.bscParametro.TextBoxForeColor = System.Drawing.Color.Empty
      '
      'ParametrosSucursalesDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(680, 160)
      Me.Controls.Add(Me.bscParametro)
      Me.Controls.Add(Me.lblCategoria)
      Me.Controls.Add(Me.txtCategoria)
      Me.Controls.Add(Me.lblNombreParametro)
      Me.Controls.Add(Me.txtNombreParametro)
      Me.Controls.Add(Me.lblValorParametro)
      Me.Controls.Add(Me.txtValorParametro)
      Me.Controls.Add(Me.lblIdParametro)
      Me.Name = "ParametrosSucursalesDetalle"
      Me.Text = "Parametro de Sucursal"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.lblIdParametro, 0)
      Me.Controls.SetChildIndex(Me.txtValorParametro, 0)
      Me.Controls.SetChildIndex(Me.lblValorParametro, 0)
      Me.Controls.SetChildIndex(Me.txtNombreParametro, 0)
      Me.Controls.SetChildIndex(Me.lblNombreParametro, 0)
      Me.Controls.SetChildIndex(Me.txtCategoria, 0)
      Me.Controls.SetChildIndex(Me.lblCategoria, 0)
      Me.Controls.SetChildIndex(Me.bscParametro, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblValorParametro As Eniac.Controles.Label
   Friend WithEvents txtValorParametro As Eniac.Controles.TextBox
   Friend WithEvents lblIdParametro As Eniac.Controles.Label
   Friend WithEvents lblCategoria As Eniac.Controles.Label
   Friend WithEvents txtCategoria As Eniac.Controles.TextBox
   Friend WithEvents lblNombreParametro As Eniac.Controles.Label
   Friend WithEvents txtNombreParametro As Eniac.Controles.TextBox
   Friend WithEvents bscParametro As Eniac.Controles.Buscador2
End Class
