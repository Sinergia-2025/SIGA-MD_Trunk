<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormulasDetalleComponente
   Inherits BaseForm

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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormulasDetalleComponente))
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.lblProducto = New Eniac.Controles.Label()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.lblCodProducto = New Eniac.Controles.Label()
      Me.lblNombreProducto = New Eniac.Controles.Label()
      Me.cmbFormulas = New Eniac.Controles.ComboBox()
      Me.lblFormula = New Eniac.Controles.Label()
      Me.chbSegunCalculoForma = New Eniac.Controles.CheckBox()
      Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.btnAceptar = New System.Windows.Forms.Button()
      Me.btnCancelar = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ConfigBuscador = Nothing
      Me.bscProducto2.Datos = Nothing
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto2.IsDecimal = False
      Me.bscProducto2.IsNumber = False
      Me.bscProducto2.IsPK = False
      Me.bscProducto2.IsRequired = False
      Me.bscProducto2.Key = ""
      Me.bscProducto2.LabelAsoc = Me.lblProducto
      Me.bscProducto2.Location = New System.Drawing.Point(222, 37)
      Me.bscProducto2.MaxLengh = "60"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(235, 20)
      Me.bscProducto2.TabIndex = 4
      '
      'lblProducto
      '
      Me.lblProducto.AutoSize = True
      Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblProducto.LabelAsoc = Nothing
      Me.lblProducto.Location = New System.Drawing.Point(35, 41)
      Me.lblProducto.Name = "lblProducto"
      Me.lblProducto.Size = New System.Drawing.Size(50, 13)
      Me.lblProducto.TabIndex = 0
      Me.lblProducto.Text = "Producto"
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.BindearPropiedadControl = Nothing
      Me.bscCodigoProducto2.BindearPropiedadEntidad = Nothing
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCodigoProducto2.Datos = Nothing
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2.IsDecimal = False
      Me.bscCodigoProducto2.IsNumber = False
      Me.bscCodigoProducto2.IsPK = False
      Me.bscCodigoProducto2.IsRequired = False
      Me.bscCodigoProducto2.Key = ""
      Me.bscCodigoProducto2.LabelAsoc = Me.lblCodProducto
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(91, 37)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(125, 20)
      Me.bscCodigoProducto2.TabIndex = 2
      '
      'lblCodProducto
      '
      Me.lblCodProducto.AutoSize = True
      Me.lblCodProducto.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblCodProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblCodProducto.LabelAsoc = Me.lblProducto
      Me.lblCodProducto.Location = New System.Drawing.Point(88, 22)
      Me.lblCodProducto.Name = "lblCodProducto"
      Me.lblCodProducto.Size = New System.Drawing.Size(40, 13)
      Me.lblCodProducto.TabIndex = 1
      Me.lblCodProducto.Text = "Código"
      '
      'lblNombreProducto
      '
      Me.lblNombreProducto.AutoSize = True
      Me.lblNombreProducto.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblNombreProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me.lblNombreProducto.LabelAsoc = Me.lblProducto
      Me.lblNombreProducto.Location = New System.Drawing.Point(219, 21)
      Me.lblNombreProducto.Name = "lblNombreProducto"
      Me.lblNombreProducto.Size = New System.Drawing.Size(50, 13)
      Me.lblNombreProducto.TabIndex = 3
      Me.lblNombreProducto.Text = "Producto"
      Me.lblNombreProducto.Visible = False
      '
      'cmbFormulas
      '
      Me.cmbFormulas.BindearPropiedadControl = Nothing
      Me.cmbFormulas.BindearPropiedadEntidad = Nothing
      Me.cmbFormulas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormulas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbFormulas.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbFormulas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbFormulas.FormattingEnabled = True
      Me.cmbFormulas.IsPK = False
      Me.cmbFormulas.IsRequired = False
      Me.cmbFormulas.Key = Nothing
      Me.cmbFormulas.LabelAsoc = Me.lblFormula
      Me.cmbFormulas.Location = New System.Drawing.Point(91, 63)
      Me.cmbFormulas.Name = "cmbFormulas"
      Me.cmbFormulas.Size = New System.Drawing.Size(233, 21)
      Me.cmbFormulas.TabIndex = 6
      Me.cmbFormulas.TabStop = False
      '
      'lblFormula
      '
      Me.lblFormula.AutoSize = True
      Me.lblFormula.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblFormula.LabelAsoc = Nothing
      Me.lblFormula.Location = New System.Drawing.Point(35, 67)
      Me.lblFormula.Name = "lblFormula"
      Me.lblFormula.Size = New System.Drawing.Size(44, 13)
      Me.lblFormula.TabIndex = 5
      Me.lblFormula.Text = "Fórmula"
      '
      'chbSegunCalculoForma
      '
      Me.chbSegunCalculoForma.AutoSize = True
      Me.chbSegunCalculoForma.BindearPropiedadControl = ""
      Me.chbSegunCalculoForma.BindearPropiedadEntidad = ""
      Me.chbSegunCalculoForma.ForeColorFocus = System.Drawing.Color.Red
      Me.chbSegunCalculoForma.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbSegunCalculoForma.IsPK = False
      Me.chbSegunCalculoForma.IsRequired = False
      Me.chbSegunCalculoForma.Key = Nothing
      Me.chbSegunCalculoForma.LabelAsoc = Nothing
      Me.chbSegunCalculoForma.Location = New System.Drawing.Point(35, 90)
      Me.chbSegunCalculoForma.Name = "chbSegunCalculoForma"
      Me.chbSegunCalculoForma.Size = New System.Drawing.Size(141, 17)
      Me.chbSegunCalculoForma.TabIndex = 7
      Me.chbSegunCalculoForma.Text = "Según cálculo por forma"
      Me.chbSegunCalculoForma.UseVisualStyleBackColor = True
      '
      'imageList1
      '
      Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.imageList1.Images.SetKeyName(0, "check2.ico")
      Me.imageList1.Images.SetKeyName(1, "delete2.ico")
      '
      'btnAceptar
      '
      Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnAceptar.ImageIndex = 0
      Me.btnAceptar.ImageList = Me.imageList1
      Me.btnAceptar.Location = New System.Drawing.Point(308, 112)
      Me.btnAceptar.Name = "btnAceptar"
      Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
      Me.btnAceptar.TabIndex = 8
      Me.btnAceptar.Text = "&Aceptar"
      Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnAceptar.UseVisualStyleBackColor = True
      '
      'btnCancelar
      '
      Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.btnCancelar.ImageIndex = 1
      Me.btnCancelar.ImageList = Me.imageList1
      Me.btnCancelar.Location = New System.Drawing.Point(394, 112)
      Me.btnCancelar.Name = "btnCancelar"
      Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
      Me.btnCancelar.TabIndex = 9
      Me.btnCancelar.Text = "&Cancelar"
      Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.btnCancelar.UseVisualStyleBackColor = True
      '
      'FormulasDetalleComponente
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(486, 154)
      Me.Controls.Add(Me.btnAceptar)
      Me.Controls.Add(Me.btnCancelar)
      Me.Controls.Add(Me.chbSegunCalculoForma)
      Me.Controls.Add(Me.cmbFormulas)
      Me.Controls.Add(Me.lblFormula)
      Me.Controls.Add(Me.bscProducto2)
      Me.Controls.Add(Me.lblProducto)
      Me.Controls.Add(Me.bscCodigoProducto2)
      Me.Controls.Add(Me.lblCodProducto)
      Me.Controls.Add(Me.lblNombreProducto)
      Me.Name = "FormulasDetalleComponente"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Cambiar Fórmula"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents bscProducto2 As Controles.Buscador2
   Friend WithEvents lblProducto As Controles.Label
   Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
   Friend WithEvents lblCodProducto As Controles.Label
   Friend WithEvents lblNombreProducto As Controles.Label
   Friend WithEvents cmbFormulas As Controles.ComboBox
   Friend WithEvents lblFormula As Controles.Label
   Friend WithEvents chbSegunCalculoForma As Controles.CheckBox
   Private WithEvents imageList1 As ImageList
   Protected WithEvents btnAceptar As Button
   Protected WithEvents btnCancelar As Button
End Class
