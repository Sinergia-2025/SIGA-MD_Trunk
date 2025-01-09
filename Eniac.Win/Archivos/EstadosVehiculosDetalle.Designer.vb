<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EstadosVehiculosDetalle
   Inherits BaseDetalle

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.chbEnStock = New Eniac.Controles.CheckBox()
      Me.chbSolicitaFecha = New Eniac.Controles.CheckBox()
      Me.cmbIdEstadoVehiculoLuegoVencer = New Eniac.Controles.ComboBox()
      Me.lblIdEstadoVehiculoLuegoVencer = New Eniac.Controles.Label()
        Me.chbPredeterminado = New Eniac.Controles.CheckBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(213, 168)
        Me.btnAceptar.TabIndex = 9
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(299, 168)
        Me.btnCancelar.TabIndex = 10
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(112, 168)
        Me.btnCopiar.TabIndex = 12
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(55, 168)
        Me.btnAplicar.TabIndex = 11
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.LabelAsoc = Nothing
        Me.lblNombre.Location = New System.Drawing.Point(12, 46)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BindearPropiedadControl = "Text"
        Me.txtNombre.BindearPropiedadEntidad = "NombreEstadoVehiculo"
        Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNombre.Formato = ""
        Me.txtNombre.IsDecimal = False
        Me.txtNombre.IsNumber = False
        Me.txtNombre.IsPK = False
        Me.txtNombre.IsRequired = True
        Me.txtNombre.Key = ""
        Me.txtNombre.LabelAsoc = Me.lblNombre
        Me.txtNombre.Location = New System.Drawing.Point(106, 42)
        Me.txtNombre.MaxLength = 100
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(264, 20)
        Me.txtNombre.TabIndex = 3
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(12, 20)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(40, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Código"
        '
        'txtId
        '
        Me.txtId.BindearPropiedadControl = "Text"
        Me.txtId.BindearPropiedadEntidad = "IdEstadoVehiculo"
        Me.txtId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtId.Formato = ""
        Me.txtId.IsDecimal = False
        Me.txtId.IsNumber = True
        Me.txtId.IsPK = True
        Me.txtId.IsRequired = True
        Me.txtId.Key = ""
        Me.txtId.LabelAsoc = Me.lblId
        Me.txtId.Location = New System.Drawing.Point(106, 16)
        Me.txtId.MaxLength = 3
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(48, 20)
        Me.txtId.TabIndex = 1
        '
        'chbEnStock
        '
        Me.chbEnStock.AutoSize = True
        Me.chbEnStock.BindearPropiedadControl = "Checked"
        Me.chbEnStock.BindearPropiedadEntidad = "EnStock"
        Me.chbEnStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEnStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEnStock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbEnStock.IsPK = False
        Me.chbEnStock.IsRequired = False
        Me.chbEnStock.Key = Nothing
        Me.chbEnStock.LabelAsoc = Nothing
        Me.chbEnStock.Location = New System.Drawing.Point(106, 91)
        Me.chbEnStock.Name = "chbEnStock"
        Me.chbEnStock.Size = New System.Drawing.Size(70, 17)
        Me.chbEnStock.TabIndex = 5
        Me.chbEnStock.Text = "En Stock"
        Me.chbEnStock.UseVisualStyleBackColor = True
        '
        'chbSolicitaFecha
        '
        Me.chbSolicitaFecha.AutoSize = True
        Me.chbSolicitaFecha.BindearPropiedadControl = "Checked"
        Me.chbSolicitaFecha.BindearPropiedadEntidad = "SolicitaFecha"
        Me.chbSolicitaFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbSolicitaFecha.IsPK = False
        Me.chbSolicitaFecha.IsRequired = False
        Me.chbSolicitaFecha.Key = Nothing
        Me.chbSolicitaFecha.LabelAsoc = Nothing
        Me.chbSolicitaFecha.Location = New System.Drawing.Point(106, 114)
        Me.chbSolicitaFecha.Name = "chbSolicitaFecha"
        Me.chbSolicitaFecha.Size = New System.Drawing.Size(93, 17)
        Me.chbSolicitaFecha.TabIndex = 6
        Me.chbSolicitaFecha.Text = "Solicita Fecha"
        Me.chbSolicitaFecha.UseVisualStyleBackColor = True
        '
        'cmbIdEstadoVehiculoLuegoVencer
        '
        Me.cmbIdEstadoVehiculoLuegoVencer.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdEstadoVehiculoLuegoVencer.BindearPropiedadEntidad = "IdEstadoVehiculoLuegoVencer"
        Me.cmbIdEstadoVehiculoLuegoVencer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdEstadoVehiculoLuegoVencer.Enabled = False
        Me.cmbIdEstadoVehiculoLuegoVencer.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdEstadoVehiculoLuegoVencer.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdEstadoVehiculoLuegoVencer.FormattingEnabled = True
        Me.cmbIdEstadoVehiculoLuegoVencer.IsPK = False
        Me.cmbIdEstadoVehiculoLuegoVencer.IsRequired = False
        Me.cmbIdEstadoVehiculoLuegoVencer.Key = Nothing
        Me.cmbIdEstadoVehiculoLuegoVencer.LabelAsoc = Me.lblIdEstadoVehiculoLuegoVencer
        Me.cmbIdEstadoVehiculoLuegoVencer.Location = New System.Drawing.Point(106, 137)
        Me.cmbIdEstadoVehiculoLuegoVencer.Name = "cmbIdEstadoVehiculoLuegoVencer"
        Me.cmbIdEstadoVehiculoLuegoVencer.Size = New System.Drawing.Size(264, 21)
        Me.cmbIdEstadoVehiculoLuegoVencer.TabIndex = 8
        '
        'lblIdEstadoVehiculoLuegoVencer
        '
        Me.lblIdEstadoVehiculoLuegoVencer.AutoSize = True
        Me.lblIdEstadoVehiculoLuegoVencer.LabelAsoc = Nothing
        Me.lblIdEstadoVehiculoLuegoVencer.Location = New System.Drawing.Point(12, 141)
        Me.lblIdEstadoVehiculoLuegoVencer.Name = "lblIdEstadoVehiculoLuegoVencer"
        Me.lblIdEstadoVehiculoLuegoVencer.Size = New System.Drawing.Size(88, 13)
        Me.lblIdEstadoVehiculoLuegoVencer.TabIndex = 7
        Me.lblIdEstadoVehiculoLuegoVencer.Text = "Luego de vencer"
        '
        'chbPredeterminado
        '
        Me.chbPredeterminado.AutoSize = True
        Me.chbPredeterminado.BindearPropiedadControl = "Checked"
        Me.chbPredeterminado.BindearPropiedadEntidad = "Predeterminado"
        Me.chbPredeterminado.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPredeterminado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPredeterminado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbPredeterminado.IsPK = False
        Me.chbPredeterminado.IsRequired = False
        Me.chbPredeterminado.Key = Nothing
        Me.chbPredeterminado.LabelAsoc = Nothing
        Me.chbPredeterminado.Location = New System.Drawing.Point(106, 68)
        Me.chbPredeterminado.Name = "chbPredeterminado"
        Me.chbPredeterminado.Size = New System.Drawing.Size(100, 17)
        Me.chbPredeterminado.TabIndex = 4
        Me.chbPredeterminado.Text = "Predeterminado"
        Me.chbPredeterminado.UseVisualStyleBackColor = True
        '
        'EstadosVehiculosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 203)
        Me.Controls.Add(Me.chbPredeterminado)
        Me.Controls.Add(Me.lblIdEstadoVehiculoLuegoVencer)
        Me.Controls.Add(Me.cmbIdEstadoVehiculoLuegoVencer)
        Me.Controls.Add(Me.chbSolicitaFecha)
        Me.Controls.Add(Me.chbEnStock)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtId)
        Me.Name = "EstadosVehiculosDetalle"
        Me.Text = "Estado de Vehículo"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.txtId, 0)
        Me.Controls.SetChildIndex(Me.lblId, 0)
        Me.Controls.SetChildIndex(Me.txtNombre, 0)
        Me.Controls.SetChildIndex(Me.lblNombre, 0)
        Me.Controls.SetChildIndex(Me.chbEnStock, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitaFecha, 0)
        Me.Controls.SetChildIndex(Me.cmbIdEstadoVehiculoLuegoVencer, 0)
        Me.Controls.SetChildIndex(Me.lblIdEstadoVehiculoLuegoVencer, 0)
        Me.Controls.SetChildIndex(Me.chbPredeterminado, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents chbEnStock As Controles.CheckBox
   Friend WithEvents chbSolicitaFecha As Controles.CheckBox
   Friend WithEvents cmbIdEstadoVehiculoLuegoVencer As Controles.ComboBox
   Friend WithEvents lblIdEstadoVehiculoLuegoVencer As Controles.Label
    Friend WithEvents chbPredeterminado As Controles.CheckBox
End Class
