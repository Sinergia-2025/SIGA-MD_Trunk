<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AplicacionesDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AplicacionesDetalle))
      Me.txtNombreZonaGeografica = New Eniac.Controles.TextBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtIdZonaGeografica = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.cmbAplicacionBase = New Eniac.Controles.ComboBox()
      Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.cmbPropietarioAplicacion = New Eniac.Controles.ComboBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(193, 123)
        Me.btnAceptar.TabIndex = 9
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(279, 123)
        Me.btnCancelar.TabIndex = 10
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(92, 123)
        Me.btnCopiar.TabIndex = 12
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(35, 123)
        Me.btnAplicar.TabIndex = 11
        '
        'txtNombreZonaGeografica
        '
        Me.txtNombreZonaGeografica.BindearPropiedadControl = "Text"
        Me.txtNombreZonaGeografica.BindearPropiedadEntidad = "NombreAplicacion"
        Me.txtNombreZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombreZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombreZonaGeografica.Formato = ""
        Me.txtNombreZonaGeografica.IsDecimal = False
        Me.txtNombreZonaGeografica.IsNumber = False
        Me.txtNombreZonaGeografica.IsPK = False
        Me.txtNombreZonaGeografica.IsRequired = True
        Me.txtNombreZonaGeografica.Key = ""
        Me.txtNombreZonaGeografica.LabelAsoc = Me.lblNombre
        Me.txtNombreZonaGeografica.Location = New System.Drawing.Point(74, 38)
        Me.txtNombreZonaGeografica.MaxLength = 40
        Me.txtNombreZonaGeografica.Name = "txtNombreZonaGeografica"
        Me.txtNombreZonaGeografica.Size = New System.Drawing.Size(285, 20)
        Me.txtNombreZonaGeografica.TabIndex = 3
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(11, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtIdZonaGeografica
        '
        Me.txtIdZonaGeografica.BindearPropiedadControl = "Text"
        Me.txtIdZonaGeografica.BindearPropiedadEntidad = "IdAplicacion"
        Me.txtIdZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdZonaGeografica.Formato = ""
        Me.txtIdZonaGeografica.IsDecimal = False
        Me.txtIdZonaGeografica.IsNumber = False
        Me.txtIdZonaGeografica.IsPK = True
        Me.txtIdZonaGeografica.IsRequired = True
        Me.txtIdZonaGeografica.Key = ""
        Me.txtIdZonaGeografica.LabelAsoc = Me.lblCodigo
        Me.txtIdZonaGeografica.Location = New System.Drawing.Point(74, 12)
        Me.txtIdZonaGeografica.MaxLength = 10
        Me.txtIdZonaGeografica.Name = "txtIdZonaGeografica"
        Me.txtIdZonaGeografica.Size = New System.Drawing.Size(120, 20)
        Me.txtIdZonaGeografica.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.LabelAsoc = Nothing
        Me.lblCodigo.Location = New System.Drawing.Point(11, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(11, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ap. Base"
        '
        'cmbAplicacionBase
        '
        Me.cmbAplicacionBase.BindearPropiedadControl = "SelectedValue"
        Me.cmbAplicacionBase.BindearPropiedadEntidad = "IdAplicacionBase"
        Me.cmbAplicacionBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAplicacionBase.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAplicacionBase.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAplicacionBase.FormattingEnabled = True
        Me.cmbAplicacionBase.IsPK = False
        Me.cmbAplicacionBase.IsRequired = False
        Me.cmbAplicacionBase.Key = Nothing
        Me.cmbAplicacionBase.LabelAsoc = Nothing
        Me.cmbAplicacionBase.Location = New System.Drawing.Point(74, 64)
        Me.cmbAplicacionBase.Name = "cmbAplicacionBase"
        Me.cmbAplicacionBase.Size = New System.Drawing.Size(120, 21)
        Me.cmbAplicacionBase.TabIndex = 5
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiar.Location = New System.Drawing.Point(200, 61)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(26, 26)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'cmbPropietarioAplicacion
        '
        Me.cmbPropietarioAplicacion.BindearPropiedadControl = "SelectedValue"
        Me.cmbPropietarioAplicacion.BindearPropiedadEntidad = "PropietarioAplicacion"
        Me.cmbPropietarioAplicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPropietarioAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbPropietarioAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbPropietarioAplicacion.FormattingEnabled = True
        Me.cmbPropietarioAplicacion.IsPK = False
        Me.cmbPropietarioAplicacion.IsRequired = False
        Me.cmbPropietarioAplicacion.Key = Nothing
        Me.cmbPropietarioAplicacion.LabelAsoc = Nothing
        Me.cmbPropietarioAplicacion.Location = New System.Drawing.Point(74, 91)
        Me.cmbPropietarioAplicacion.Name = "cmbPropietarioAplicacion"
        Me.cmbPropietarioAplicacion.Size = New System.Drawing.Size(120, 21)
        Me.cmbPropietarioAplicacion.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(11, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Propietario"
        '
        'AplicacionesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 165)
        Me.Controls.Add(Me.cmbPropietarioAplicacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.cmbAplicacionBase)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombreZonaGeografica)
        Me.Controls.Add(Me.txtIdZonaGeografica)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.lblCodigo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AplicacionesDetalle"
        Me.Text = "Aplicación"
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.lblCodigo, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.txtIdZonaGeografica, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.txtNombreZonaGeografica, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cmbAplicacionBase, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiar, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cmbPropietarioAplicacion, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNombreZonaGeografica As Eniac.Controles.TextBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtIdZonaGeografica As Eniac.Controles.TextBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cmbAplicacionBase As Eniac.Controles.ComboBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents cmbPropietarioAplicacion As Controles.ComboBox
    Friend WithEvents Label2 As Controles.Label
End Class
