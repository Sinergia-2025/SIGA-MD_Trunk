<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConcesionarioDistribucionEjesDetalle
   Inherits Win.BaseDetalle

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
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtDescripcionSubUnidad = New Eniac.Controles.TextBox()
      Me.lblUnidad = New Eniac.Controles.Label()
      Me.bscCodigoUnidad = New Eniac.Controles.Buscador2()
      Me.bscUnidad = New Eniac.Controles.Buscador2()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombreSubUnidad = New Eniac.Controles.TextBox()
      Me.lblIdEje = New Eniac.Controles.Label()
      Me.txtIdEje = New Eniac.Controles.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(328, 174)
        Me.btnAceptar.TabIndex = 9
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(414, 174)
        Me.btnCancelar.TabIndex = 10
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(227, 174)
        Me.btnCopiar.TabIndex = 11
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(170, 174)
        Me.btnAplicar.TabIndex = 12
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(16, 108)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 7
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcionSubUnidad
        '
        Me.txtDescripcionSubUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtDescripcionSubUnidad.BindearPropiedadControl = "Text"
        Me.txtDescripcionSubUnidad.BindearPropiedadEntidad = "DescripcionEje"
        Me.txtDescripcionSubUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcionSubUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcionSubUnidad.Formato = ""
        Me.txtDescripcionSubUnidad.IsDecimal = False
        Me.txtDescripcionSubUnidad.IsNumber = False
        Me.txtDescripcionSubUnidad.IsPK = False
        Me.txtDescripcionSubUnidad.IsRequired = False
        Me.txtDescripcionSubUnidad.Key = ""
        Me.txtDescripcionSubUnidad.LabelAsoc = Me.lblDescripcion
        Me.txtDescripcionSubUnidad.Location = New System.Drawing.Point(85, 105)
        Me.txtDescripcionSubUnidad.MaxLength = 50
        Me.txtDescripcionSubUnidad.Name = "txtDescripcionSubUnidad"
        Me.txtDescripcionSubUnidad.Size = New System.Drawing.Size(409, 20)
        Me.txtDescripcionSubUnidad.TabIndex = 8
        '
        'lblUnidad
        '
        Me.lblUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUnidad.AutoSize = True
        Me.lblUnidad.LabelAsoc = Nothing
        Me.lblUnidad.Location = New System.Drawing.Point(16, 22)
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(41, 13)
        Me.lblUnidad.TabIndex = 0
        Me.lblUnidad.Text = "Unidad"
        '
        'bscCodigoUnidad
        '
        Me.bscCodigoUnidad.ActivarFiltroEnGrilla = True
        Me.bscCodigoUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscCodigoUnidad.BindearPropiedadControl = "Text"
        Me.bscCodigoUnidad.BindearPropiedadEntidad = "IdTipoUnidad"
        Me.bscCodigoUnidad.ConfigBuscador = Nothing
        Me.bscCodigoUnidad.Datos = Nothing
        Me.bscCodigoUnidad.FilaDevuelta = Nothing
        Me.bscCodigoUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoUnidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoUnidad.IsDecimal = False
        Me.bscCodigoUnidad.IsNumber = True
        Me.bscCodigoUnidad.IsPK = False
        Me.bscCodigoUnidad.IsRequired = True
        Me.bscCodigoUnidad.Key = ""
        Me.bscCodigoUnidad.LabelAsoc = Me.lblUnidad
        Me.bscCodigoUnidad.Location = New System.Drawing.Point(85, 22)
        Me.bscCodigoUnidad.MaxLengh = "32767"
        Me.bscCodigoUnidad.Name = "bscCodigoUnidad"
        Me.bscCodigoUnidad.Permitido = True
        Me.bscCodigoUnidad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoUnidad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoUnidad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoUnidad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoUnidad.Selecciono = False
        Me.bscCodigoUnidad.Size = New System.Drawing.Size(91, 20)
        Me.bscCodigoUnidad.TabIndex = 1
        '
        'bscUnidad
        '
        Me.bscUnidad.ActivarFiltroEnGrilla = True
        Me.bscUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.bscUnidad.BindearPropiedadControl = Nothing
        Me.bscUnidad.BindearPropiedadEntidad = ""
        Me.bscUnidad.ConfigBuscador = Nothing
        Me.bscUnidad.Datos = Nothing
        Me.bscUnidad.FilaDevuelta = Nothing
        Me.bscUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscUnidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscUnidad.IsDecimal = False
        Me.bscUnidad.IsNumber = False
        Me.bscUnidad.IsPK = False
        Me.bscUnidad.IsRequired = True
        Me.bscUnidad.Key = ""
        Me.bscUnidad.LabelAsoc = Me.lblUnidad
        Me.bscUnidad.Location = New System.Drawing.Point(182, 22)
        Me.bscUnidad.MaxLengh = "32767"
        Me.bscUnidad.Name = "bscUnidad"
        Me.bscUnidad.Permitido = True
        Me.bscUnidad.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscUnidad.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscUnidad.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscUnidad.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscUnidad.Selecciono = False
        Me.bscUnidad.Size = New System.Drawing.Size(312, 20)
        Me.bscUnidad.TabIndex = 2
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(16, 82)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombreSubUnidad
        '
        Me.txtNombreSubUnidad.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNombreSubUnidad.BindearPropiedadControl = "Text"
        Me.txtNombreSubUnidad.BindearPropiedadEntidad = "NombreEje"
        Me.txtNombreSubUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreSubUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreSubUnidad.Formato = ""
        Me.txtNombreSubUnidad.IsDecimal = False
        Me.txtNombreSubUnidad.IsNumber = False
        Me.txtNombreSubUnidad.IsPK = False
        Me.txtNombreSubUnidad.IsRequired = True
        Me.txtNombreSubUnidad.Key = ""
        Me.txtNombreSubUnidad.LabelAsoc = Me.lblNombre
        Me.txtNombreSubUnidad.Location = New System.Drawing.Point(85, 79)
        Me.txtNombreSubUnidad.MaxLength = 50
        Me.txtNombreSubUnidad.Name = "txtNombreSubUnidad"
        Me.txtNombreSubUnidad.Size = New System.Drawing.Size(409, 20)
        Me.txtNombreSubUnidad.TabIndex = 6
        '
        'lblIdEje
        '
        Me.lblIdEje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblIdEje.AutoSize = True
        Me.lblIdEje.LabelAsoc = Nothing
        Me.lblIdEje.Location = New System.Drawing.Point(16, 54)
        Me.lblIdEje.Name = "lblIdEje"
        Me.lblIdEje.Size = New System.Drawing.Size(40, 13)
        Me.lblIdEje.TabIndex = 3
        Me.lblIdEje.Text = "Código"
        '
        'txtIdEje
        '
        Me.txtIdEje.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtIdEje.BindearPropiedadControl = "Text"
        Me.txtIdEje.BindearPropiedadEntidad = "IdEje"
        Me.txtIdEje.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdEje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdEje.Formato = ""
        Me.txtIdEje.IsDecimal = False
        Me.txtIdEje.IsNumber = True
        Me.txtIdEje.IsPK = True
        Me.txtIdEje.IsRequired = True
        Me.txtIdEje.Key = ""
        Me.txtIdEje.LabelAsoc = Me.lblIdEje
        Me.txtIdEje.Location = New System.Drawing.Point(85, 51)
        Me.txtIdEje.MaxLength = 4
        Me.txtIdEje.Name = "txtIdEje"
        Me.txtIdEje.Size = New System.Drawing.Size(77, 20)
        Me.txtIdEje.TabIndex = 4
        Me.txtIdEje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ConcesionarioDistribucionEjesDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 209)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtDescripcionSubUnidad)
        Me.Controls.Add(Me.lblUnidad)
        Me.Controls.Add(Me.bscCodigoUnidad)
        Me.Controls.Add(Me.bscUnidad)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombreSubUnidad)
        Me.Controls.Add(Me.lblIdEje)
        Me.Controls.Add(Me.txtIdEje)
        Me.Name = "ConcesionarioDistribucionEjesDetalle"
        Me.Text = "Eje"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtIdEje, 0)
        Me.Controls.SetChildIndex(Me.lblIdEje, 0)
        Me.Controls.SetChildIndex(Me.txtNombreSubUnidad, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.bscUnidad, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoUnidad, 0)
        Me.Controls.SetChildIndex(Me.lblUnidad, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcionSubUnidad, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDescripcion As Controles.Label
   Friend WithEvents txtDescripcionSubUnidad As Controles.TextBox
   Friend WithEvents lblUnidad As Controles.Label
   Friend WithEvents bscCodigoUnidad As Controles.Buscador2
   Friend WithEvents bscUnidad As Controles.Buscador2
   Friend WithEvents lblNombre As Controles.Label
   Friend WithEvents txtNombreSubUnidad As Controles.TextBox
   Friend WithEvents lblIdEje As Controles.Label
   Friend WithEvents txtIdEje As Controles.TextBox
End Class
