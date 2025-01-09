<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MRPTareasDetalle
   Inherits BaseDetalle

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
        Me.chbActivo = New Eniac.Controles.CheckBox()
        Me.txtCodigoTarea = New Eniac.Controles.TextBox()
        Me.lblCodigoTarea = New Eniac.Controles.Label()
        Me.lblDescripcion = New Eniac.Controles.Label()
        Me.txtDescripcion = New Eniac.Controles.TextBox()
        Me.bscNombreCentrosProductores = New Eniac.Controles.Buscador2()
        Me.lblCentrosProductores = New Eniac.Controles.Label()
        Me.bscCodigoCentroProductor = New Eniac.Controles.Buscador2()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(311, 103)
        Me.btnAceptar.TabIndex = 8
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(397, 103)
        Me.btnCancelar.TabIndex = 9
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(210, 103)
        Me.btnCopiar.TabIndex = 10
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(153, 103)
        Me.btnAplicar.TabIndex = 11
        '
        'chbActivo
        '
        Me.chbActivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbActivo.AutoSize = True
        Me.chbActivo.BindearPropiedadControl = "Checked"
        Me.chbActivo.BindearPropiedadEntidad = "Activo"
        Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbActivo.IsPK = False
        Me.chbActivo.IsRequired = False
        Me.chbActivo.Key = Nothing
        Me.chbActivo.LabelAsoc = Nothing
        Me.chbActivo.Location = New System.Drawing.Point(421, 13)
        Me.chbActivo.Name = "chbActivo"
        Me.chbActivo.Size = New System.Drawing.Size(56, 17)
        Me.chbActivo.TabIndex = 2
        Me.chbActivo.Text = "Activa"
        Me.chbActivo.UseVisualStyleBackColor = True
        '
        'txtCodigoTarea
        '
        Me.txtCodigoTarea.BindearPropiedadControl = "Text"
        Me.txtCodigoTarea.BindearPropiedadEntidad = "CodigoTarea"
        Me.txtCodigoTarea.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoTarea.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoTarea.Formato = ""
        Me.txtCodigoTarea.IsDecimal = False
        Me.txtCodigoTarea.IsNumber = False
        Me.txtCodigoTarea.IsPK = True
        Me.txtCodigoTarea.IsRequired = True
        Me.txtCodigoTarea.Key = ""
        Me.txtCodigoTarea.LabelAsoc = Me.lblCodigoTarea
        Me.txtCodigoTarea.Location = New System.Drawing.Point(101, 11)
        Me.txtCodigoTarea.MaxLength = 12
        Me.txtCodigoTarea.Name = "txtCodigoTarea"
        Me.txtCodigoTarea.Size = New System.Drawing.Size(102, 20)
        Me.txtCodigoTarea.TabIndex = 1
        '
        'lblCodigoTarea
        '
        Me.lblCodigoTarea.AutoSize = True
        Me.lblCodigoTarea.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCodigoTarea.LabelAsoc = Nothing
        Me.lblCodigoTarea.Location = New System.Drawing.Point(14, 14)
        Me.lblCodigoTarea.Name = "lblCodigoTarea"
        Me.lblCodigoTarea.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoTarea.TabIndex = 0
        Me.lblCodigoTarea.Text = "Código"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescripcion.LabelAsoc = Nothing
        Me.lblDescripcion.Location = New System.Drawing.Point(14, 40)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 3
        Me.lblDescripcion.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.BindearPropiedadControl = "Text"
        Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
        Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcion.Formato = ""
        Me.txtDescripcion.IsDecimal = False
        Me.txtDescripcion.IsNumber = False
        Me.txtDescripcion.IsPK = False
        Me.txtDescripcion.IsRequired = True
        Me.txtDescripcion.Key = "NombreEmpleado"
        Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
        Me.txtDescripcion.Location = New System.Drawing.Point(101, 37)
        Me.txtDescripcion.MaxLength = 100
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(376, 20)
        Me.txtDescripcion.TabIndex = 4
        '
        'bscNombreCentrosProductores
        '
        Me.bscNombreCentrosProductores.ActivarFiltroEnGrilla = True
        Me.bscNombreCentrosProductores.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscNombreCentrosProductores.BindearPropiedadControl = Nothing
        Me.bscNombreCentrosProductores.BindearPropiedadEntidad = Nothing
        Me.bscNombreCentrosProductores.ConfigBuscador = Nothing
        Me.bscNombreCentrosProductores.Datos = Nothing
        Me.bscNombreCentrosProductores.FilaDevuelta = Nothing
        Me.bscNombreCentrosProductores.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCentrosProductores.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCentrosProductores.IsDecimal = False
        Me.bscNombreCentrosProductores.IsNumber = False
        Me.bscNombreCentrosProductores.IsPK = False
        Me.bscNombreCentrosProductores.IsRequired = False
        Me.bscNombreCentrosProductores.Key = ""
        Me.bscNombreCentrosProductores.LabelAsoc = Me.lblCentrosProductores
        Me.bscNombreCentrosProductores.Location = New System.Drawing.Point(209, 69)
        Me.bscNombreCentrosProductores.MaxLengh = "32767"
        Me.bscNombreCentrosProductores.Name = "bscNombreCentrosProductores"
        Me.bscNombreCentrosProductores.Permitido = True
        Me.bscNombreCentrosProductores.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCentrosProductores.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCentrosProductores.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCentrosProductores.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCentrosProductores.Selecciono = False
        Me.bscNombreCentrosProductores.Size = New System.Drawing.Size(264, 20)
        Me.bscNombreCentrosProductores.TabIndex = 7
        '
        'lblCentrosProductores
        '
        Me.lblCentrosProductores.AutoSize = True
        Me.lblCentrosProductores.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCentrosProductores.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCentrosProductores.LabelAsoc = Nothing
        Me.lblCentrosProductores.Location = New System.Drawing.Point(14, 73)
        Me.lblCentrosProductores.Name = "lblCentrosProductores"
        Me.lblCentrosProductores.Size = New System.Drawing.Size(87, 13)
        Me.lblCentrosProductores.TabIndex = 5
        Me.lblCentrosProductores.Text = "Centro Productor"
        '
        'bscCodigoCentroProductor
        '
        Me.bscCodigoCentroProductor.ActivarFiltroEnGrilla = True
        Me.bscCodigoCentroProductor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bscCodigoCentroProductor.BindearPropiedadControl = Nothing
        Me.bscCodigoCentroProductor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCentroProductor.ConfigBuscador = Nothing
        Me.bscCodigoCentroProductor.Datos = Nothing
        Me.bscCodigoCentroProductor.FilaDevuelta = Nothing
        Me.bscCodigoCentroProductor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCentroProductor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCentroProductor.IsDecimal = False
        Me.bscCodigoCentroProductor.IsNumber = False
        Me.bscCodigoCentroProductor.IsPK = False
        Me.bscCodigoCentroProductor.IsRequired = False
        Me.bscCodigoCentroProductor.Key = ""
        Me.bscCodigoCentroProductor.LabelAsoc = Nothing
        Me.bscCodigoCentroProductor.Location = New System.Drawing.Point(101, 69)
        Me.bscCodigoCentroProductor.MaxLengh = "32767"
        Me.bscCodigoCentroProductor.Name = "bscCodigoCentroProductor"
        Me.bscCodigoCentroProductor.Permitido = True
        Me.bscCodigoCentroProductor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCentroProductor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCentroProductor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCentroProductor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCentroProductor.Selecciono = False
        Me.bscCodigoCentroProductor.Size = New System.Drawing.Size(102, 20)
        Me.bscCodigoCentroProductor.TabIndex = 6
        '
        'MRPTareasDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(486, 138)
        Me.Controls.Add(Me.bscCodigoCentroProductor)
        Me.Controls.Add(Me.bscNombreCentrosProductores)
        Me.Controls.Add(Me.lblCentrosProductores)
        Me.Controls.Add(Me.chbActivo)
        Me.Controls.Add(Me.txtCodigoTarea)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblCodigoTarea)
        Me.Name = "MRPTareasDetalle"
        Me.Text = "Tareas"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigoTarea, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
        Me.Controls.SetChildIndex(Me.txtCodigoTarea, 0)
        Me.Controls.SetChildIndex(Me.chbActivo, 0)
        Me.Controls.SetChildIndex(Me.lblCentrosProductores, 0)
        Me.Controls.SetChildIndex(Me.bscNombreCentrosProductores, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoCentroProductor, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chbActivo As Controles.CheckBox
    Friend WithEvents txtCodigoTarea As Controles.TextBox
    Friend WithEvents lblCodigoTarea As Controles.Label
    Friend WithEvents lblDescripcion As Controles.Label
    Friend WithEvents txtDescripcion As Controles.TextBox
    Friend WithEvents bscNombreCentrosProductores As Controles.Buscador2
    Friend WithEvents lblCentrosProductores As Controles.Label
    Friend WithEvents bscCodigoCentroProductor As Controles.Buscador2
End Class
