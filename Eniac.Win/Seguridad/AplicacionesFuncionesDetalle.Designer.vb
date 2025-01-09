<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AplicacionesFuncionesDetalle
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
      Me.txtNombreFuncion = New Eniac.Controles.TextBox()
      Me.lblNombreFuncion = New Eniac.Controles.Label()
      Me.lblIdFuncion = New Eniac.Controles.Label()
      Me.txtIdFuncion = New Eniac.Controles.TextBox()
      Me.lblIdFuncionPadre = New Eniac.Controles.Label()
      Me.bscNombreFuncionPadre = New Eniac.Controles.Buscador2()
      Me.bscIdFuncionPadre = New Eniac.Controles.Buscador2()
      Me.lblIdAplicacion = New Eniac.Controles.Label()
      Me.bscNombreAplicacion = New Eniac.Controles.Buscador2()
      Me.bscIdAplicacion = New Eniac.Controles.Buscador2()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(365, 141)
      Me.btnAceptar.TabIndex = 10
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(451, 141)
      Me.btnCancelar.TabIndex = 11
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(264, 141)
      Me.btnCopiar.TabIndex = 13
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(207, 141)
      Me.btnAplicar.TabIndex = 12
      '
      'txtNombreFuncion
      '
      Me.txtNombreFuncion.BindearPropiedadControl = "Text"
      Me.txtNombreFuncion.BindearPropiedadEntidad = "NombreFuncion"
      Me.txtNombreFuncion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombreFuncion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombreFuncion.Formato = ""
      Me.txtNombreFuncion.IsDecimal = False
      Me.txtNombreFuncion.IsNumber = False
      Me.txtNombreFuncion.IsPK = False
      Me.txtNombreFuncion.IsRequired = True
      Me.txtNombreFuncion.Key = ""
      Me.txtNombreFuncion.LabelAsoc = Me.lblNombreFuncion
      Me.txtNombreFuncion.Location = New System.Drawing.Point(102, 64)
      Me.txtNombreFuncion.MaxLength = 60
      Me.txtNombreFuncion.Name = "txtNombreFuncion"
      Me.txtNombreFuncion.Size = New System.Drawing.Size(413, 20)
      Me.txtNombreFuncion.TabIndex = 6
      '
      'lblNombreFuncion
      '
      Me.lblNombreFuncion.AutoSize = True
      Me.lblNombreFuncion.LabelAsoc = Nothing
      Me.lblNombreFuncion.Location = New System.Drawing.Point(20, 68)
      Me.lblNombreFuncion.Name = "lblNombreFuncion"
      Me.lblNombreFuncion.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreFuncion.TabIndex = 5
      Me.lblNombreFuncion.Text = "Nombre"
      '
      'lblIdFuncion
      '
      Me.lblIdFuncion.AutoSize = True
      Me.lblIdFuncion.LabelAsoc = Nothing
      Me.lblIdFuncion.Location = New System.Drawing.Point(20, 42)
      Me.lblIdFuncion.Name = "lblIdFuncion"
      Me.lblIdFuncion.Size = New System.Drawing.Size(40, 13)
      Me.lblIdFuncion.TabIndex = 3
      Me.lblIdFuncion.Text = "Código"
      '
      'txtIdFuncion
      '
      Me.txtIdFuncion.BindearPropiedadControl = "Text"
      Me.txtIdFuncion.BindearPropiedadEntidad = "IdFuncion"
      Me.txtIdFuncion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdFuncion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdFuncion.Formato = ""
      Me.txtIdFuncion.IsDecimal = False
      Me.txtIdFuncion.IsNumber = False
      Me.txtIdFuncion.IsPK = True
      Me.txtIdFuncion.IsRequired = True
      Me.txtIdFuncion.Key = ""
      Me.txtIdFuncion.LabelAsoc = Me.lblIdFuncion
      Me.txtIdFuncion.Location = New System.Drawing.Point(102, 38)
      Me.txtIdFuncion.MaxLength = 30
      Me.txtIdFuncion.Name = "txtIdFuncion"
      Me.txtIdFuncion.Size = New System.Drawing.Size(110, 20)
      Me.txtIdFuncion.TabIndex = 4
      '
      'lblIdFuncionPadre
      '
      Me.lblIdFuncionPadre.AutoSize = True
      Me.lblIdFuncionPadre.LabelAsoc = Nothing
      Me.lblIdFuncionPadre.Location = New System.Drawing.Point(20, 94)
      Me.lblIdFuncionPadre.Name = "lblIdFuncionPadre"
      Me.lblIdFuncionPadre.Size = New System.Drawing.Size(76, 13)
      Me.lblIdFuncionPadre.TabIndex = 7
      Me.lblIdFuncionPadre.Text = "Función Padre"
      '
      'bscNombreFuncionPadre
      '
      Me.bscNombreFuncionPadre.ActivarFiltroEnGrilla = True
      Me.bscNombreFuncionPadre.BindearPropiedadControl = Nothing
      Me.bscNombreFuncionPadre.BindearPropiedadEntidad = Nothing
      Me.bscNombreFuncionPadre.ConfigBuscador = Nothing
      Me.bscNombreFuncionPadre.Datos = Nothing
      Me.bscNombreFuncionPadre.FilaDevuelta = Nothing
      Me.bscNombreFuncionPadre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreFuncionPadre.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreFuncionPadre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreFuncionPadre.IsDecimal = False
      Me.bscNombreFuncionPadre.IsNumber = False
      Me.bscNombreFuncionPadre.IsPK = False
      Me.bscNombreFuncionPadre.IsRequired = False
      Me.bscNombreFuncionPadre.Key = ""
      Me.bscNombreFuncionPadre.LabelAsoc = Me.lblIdFuncionPadre
      Me.bscNombreFuncionPadre.Location = New System.Drawing.Point(247, 89)
      Me.bscNombreFuncionPadre.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreFuncionPadre.MaxLengh = "32767"
      Me.bscNombreFuncionPadre.Name = "bscNombreFuncionPadre"
      Me.bscNombreFuncionPadre.Permitido = True
      Me.bscNombreFuncionPadre.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreFuncionPadre.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreFuncionPadre.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreFuncionPadre.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreFuncionPadre.Selecciono = False
      Me.bscNombreFuncionPadre.Size = New System.Drawing.Size(268, 23)
      Me.bscNombreFuncionPadre.TabIndex = 9
      '
      'bscIdFuncionPadre
      '
      Me.bscIdFuncionPadre.ActivarFiltroEnGrilla = True
      Me.bscIdFuncionPadre.BindearPropiedadControl = "Text"
      Me.bscIdFuncionPadre.BindearPropiedadEntidad = "IdFuncionPadre"
      Me.bscIdFuncionPadre.ConfigBuscador = Nothing
      Me.bscIdFuncionPadre.Datos = Nothing
      Me.bscIdFuncionPadre.FilaDevuelta = Nothing
      Me.bscIdFuncionPadre.ForeColorFocus = System.Drawing.Color.Red
      Me.bscIdFuncionPadre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscIdFuncionPadre.IsDecimal = False
      Me.bscIdFuncionPadre.IsNumber = False
      Me.bscIdFuncionPadre.IsPK = False
      Me.bscIdFuncionPadre.IsRequired = False
      Me.bscIdFuncionPadre.Key = ""
      Me.bscIdFuncionPadre.LabelAsoc = Me.lblIdFuncionPadre
      Me.bscIdFuncionPadre.Location = New System.Drawing.Point(102, 90)
      Me.bscIdFuncionPadre.MaxLengh = "32767"
      Me.bscIdFuncionPadre.Name = "bscIdFuncionPadre"
      Me.bscIdFuncionPadre.Permitido = True
      Me.bscIdFuncionPadre.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscIdFuncionPadre.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscIdFuncionPadre.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscIdFuncionPadre.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscIdFuncionPadre.Selecciono = False
      Me.bscIdFuncionPadre.Size = New System.Drawing.Size(138, 20)
      Me.bscIdFuncionPadre.TabIndex = 8
      '
      'lblIdAplicacion
      '
      Me.lblIdAplicacion.AutoSize = True
      Me.lblIdAplicacion.LabelAsoc = Nothing
      Me.lblIdAplicacion.Location = New System.Drawing.Point(20, 16)
      Me.lblIdAplicacion.Name = "lblIdAplicacion"
      Me.lblIdAplicacion.Size = New System.Drawing.Size(56, 13)
      Me.lblIdAplicacion.TabIndex = 0
      Me.lblIdAplicacion.Text = "Aplicación"
      '
      'bscNombreAplicacion
      '
      Me.bscNombreAplicacion.ActivarFiltroEnGrilla = True
      Me.bscNombreAplicacion.BindearPropiedadControl = Nothing
      Me.bscNombreAplicacion.BindearPropiedadEntidad = Nothing
      Me.bscNombreAplicacion.ConfigBuscador = Nothing
      Me.bscNombreAplicacion.Datos = Nothing
      Me.bscNombreAplicacion.FilaDevuelta = Nothing
      Me.bscNombreAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreAplicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreAplicacion.IsDecimal = False
      Me.bscNombreAplicacion.IsNumber = False
      Me.bscNombreAplicacion.IsPK = True
      Me.bscNombreAplicacion.IsRequired = True
      Me.bscNombreAplicacion.Key = ""
      Me.bscNombreAplicacion.LabelAsoc = Me.lblIdAplicacion
      Me.bscNombreAplicacion.Location = New System.Drawing.Point(247, 11)
      Me.bscNombreAplicacion.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreAplicacion.MaxLengh = "32767"
      Me.bscNombreAplicacion.Name = "bscNombreAplicacion"
      Me.bscNombreAplicacion.Permitido = True
      Me.bscNombreAplicacion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscNombreAplicacion.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscNombreAplicacion.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscNombreAplicacion.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscNombreAplicacion.Selecciono = False
      Me.bscNombreAplicacion.Size = New System.Drawing.Size(268, 23)
      Me.bscNombreAplicacion.TabIndex = 2
      '
      'bscIdAplicacion
      '
      Me.bscIdAplicacion.ActivarFiltroEnGrilla = True
      Me.bscIdAplicacion.BindearPropiedadControl = "Text"
      Me.bscIdAplicacion.BindearPropiedadEntidad = "IdAplicacion"
      Me.bscIdAplicacion.ConfigBuscador = Nothing
      Me.bscIdAplicacion.Datos = Nothing
      Me.bscIdAplicacion.FilaDevuelta = Nothing
      Me.bscIdAplicacion.ForeColorFocus = System.Drawing.Color.Red
      Me.bscIdAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscIdAplicacion.IsDecimal = False
      Me.bscIdAplicacion.IsNumber = False
      Me.bscIdAplicacion.IsPK = True
      Me.bscIdAplicacion.IsRequired = True
      Me.bscIdAplicacion.Key = ""
      Me.bscIdAplicacion.LabelAsoc = Me.lblIdAplicacion
      Me.bscIdAplicacion.Location = New System.Drawing.Point(102, 12)
      Me.bscIdAplicacion.MaxLengh = "32767"
      Me.bscIdAplicacion.Name = "bscIdAplicacion"
      Me.bscIdAplicacion.Permitido = True
      Me.bscIdAplicacion.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
      Me.bscIdAplicacion.PermitidoNoForeColor = System.Drawing.Color.Black
      Me.bscIdAplicacion.PermitidoSiBackColor = System.Drawing.Color.White
      Me.bscIdAplicacion.PermitidoSiForeColor = System.Drawing.Color.Black
      Me.bscIdAplicacion.Selecciono = False
      Me.bscIdAplicacion.Size = New System.Drawing.Size(138, 20)
      Me.bscIdAplicacion.TabIndex = 1
      '
      'AplicacionesFuncionesDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(540, 176)
      Me.Controls.Add(Me.lblIdAplicacion)
      Me.Controls.Add(Me.bscNombreAplicacion)
      Me.Controls.Add(Me.bscIdAplicacion)
      Me.Controls.Add(Me.lblIdFuncionPadre)
      Me.Controls.Add(Me.bscNombreFuncionPadre)
      Me.Controls.Add(Me.bscIdFuncionPadre)
      Me.Controls.Add(Me.txtNombreFuncion)
      Me.Controls.Add(Me.lblNombreFuncion)
      Me.Controls.Add(Me.lblIdFuncion)
      Me.Controls.Add(Me.txtIdFuncion)
      Me.Name = "AplicacionesFuncionesDetalle"
      Me.Text = "Función de Aplicación"
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.txtIdFuncion, 0)
      Me.Controls.SetChildIndex(Me.lblIdFuncion, 0)
      Me.Controls.SetChildIndex(Me.lblNombreFuncion, 0)
      Me.Controls.SetChildIndex(Me.txtNombreFuncion, 0)
      Me.Controls.SetChildIndex(Me.bscIdFuncionPadre, 0)
      Me.Controls.SetChildIndex(Me.bscNombreFuncionPadre, 0)
      Me.Controls.SetChildIndex(Me.lblIdFuncionPadre, 0)
      Me.Controls.SetChildIndex(Me.bscIdAplicacion, 0)
      Me.Controls.SetChildIndex(Me.bscNombreAplicacion, 0)
      Me.Controls.SetChildIndex(Me.lblIdAplicacion, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtNombreFuncion As Eniac.Controles.TextBox
   Friend WithEvents lblNombreFuncion As Eniac.Controles.Label
   Friend WithEvents lblIdFuncion As Eniac.Controles.Label
   Friend WithEvents txtIdFuncion As Eniac.Controles.TextBox
   Friend WithEvents lblIdFuncionPadre As Eniac.Controles.Label
   Friend WithEvents bscNombreFuncionPadre As Eniac.Controles.Buscador2
   Friend WithEvents bscIdFuncionPadre As Eniac.Controles.Buscador2
   Friend WithEvents lblIdAplicacion As Eniac.Controles.Label
   Friend WithEvents bscNombreAplicacion As Eniac.Controles.Buscador2
   Friend WithEvents bscIdAplicacion As Eniac.Controles.Buscador2
End Class
