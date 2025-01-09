<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposMovimientosDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TiposMovimientosDetalle))
      Me.lblIdTipoMovimiento = New Eniac.Controles.Label()
      Me.txtIdTipoMovimiento = New Eniac.Controles.TextBox()
      Me.lblDescripcion = New Eniac.Controles.Label()
      Me.txtDescripcion = New Eniac.Controles.TextBox()
      Me.lblCoeficienteStock = New Eniac.Controles.Label()
      Me.cmbCargaPrecio = New Eniac.Controles.ComboBox()
      Me.lblCargaPrecio = New Eniac.Controles.Label()
      Me.lblMovimientosAsociados = New Eniac.Controles.Label()
      Me.chbImprime = New Eniac.Controles.CheckBox()
      Me.chbMuestraCombo = New Eniac.Controles.CheckBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.chbHabilitaRubro = New Eniac.Controles.CheckBox()
      Me.chbHabilitaEmpleado = New Eniac.Controles.CheckBox()
      Me.chbHabilitaDestinatario = New Eniac.Controles.CheckBox()
      Me.chbAsociaSucursal = New Eniac.Controles.CheckBox()
      Me.lblContraTipoMovimiento = New Eniac.Controles.Label()
      Me.clbComprobantesAsociados = New Eniac.Controles.CheckedListBox()
      Me.cmbContraTipoMovimiento = New Eniac.Controles.ComboBox()
      Me.cmbCoeficienteStock = New Eniac.Controles.ComboBox()
      Me.chbReservaMercaderia = New Eniac.Controles.CheckBox()
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(396, 410)
      Me.btnAceptar.TabIndex = 13
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(482, 410)
      Me.btnCancelar.TabIndex = 14
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(295, 410)
      Me.btnCopiar.TabIndex = 15
      '
      'lblIdTipoMovimiento
      '
      Me.lblIdTipoMovimiento.AutoSize = True
      Me.lblIdTipoMovimiento.Location = New System.Drawing.Point(23, 20)
      Me.lblIdTipoMovimiento.Name = "lblIdTipoMovimiento"
      Me.lblIdTipoMovimiento.Size = New System.Drawing.Size(85, 13)
      Me.lblIdTipoMovimiento.TabIndex = 0
      Me.lblIdTipoMovimiento.Text = "Tipo Movimiento"
      '
      'txtIdTipoMovimiento
      '
      Me.txtIdTipoMovimiento.BindearPropiedadControl = "Text"
      Me.txtIdTipoMovimiento.BindearPropiedadEntidad = "IdTipoMovimiento"
      Me.txtIdTipoMovimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.txtIdTipoMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtIdTipoMovimiento.Formato = ""
      Me.txtIdTipoMovimiento.IsDecimal = False
      Me.txtIdTipoMovimiento.IsNumber = False
      Me.txtIdTipoMovimiento.IsPK = True
      Me.txtIdTipoMovimiento.IsRequired = True
      Me.txtIdTipoMovimiento.Key = ""
      Me.txtIdTipoMovimiento.LabelAsoc = Me.lblIdTipoMovimiento
      Me.txtIdTipoMovimiento.Location = New System.Drawing.Point(120, 16)
      Me.txtIdTipoMovimiento.MaxLength = 15
      Me.txtIdTipoMovimiento.Name = "txtIdTipoMovimiento"
      Me.txtIdTipoMovimiento.Size = New System.Drawing.Size(147, 20)
      Me.txtIdTipoMovimiento.TabIndex = 1
      '
      'lblDescripcion
      '
      Me.lblDescripcion.AutoSize = True
      Me.lblDescripcion.Location = New System.Drawing.Point(23, 46)
      Me.lblDescripcion.Name = "lblDescripcion"
      Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
      Me.lblDescripcion.TabIndex = 2
      Me.lblDescripcion.Text = "Descripción"
      '
      'txtDescripcion
      '
      Me.txtDescripcion.BindearPropiedadControl = "Text"
      Me.txtDescripcion.BindearPropiedadEntidad = "Descripcion"
      Me.txtDescripcion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtDescripcion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtDescripcion.Formato = ""
      Me.txtDescripcion.IsDecimal = False
      Me.txtDescripcion.IsNumber = False
      Me.txtDescripcion.IsPK = False
      Me.txtDescripcion.IsRequired = True
      Me.txtDescripcion.Key = ""
      Me.txtDescripcion.LabelAsoc = Me.lblDescripcion
      Me.txtDescripcion.Location = New System.Drawing.Point(120, 42)
      Me.txtDescripcion.MaxLength = 25
      Me.txtDescripcion.Name = "txtDescripcion"
      Me.txtDescripcion.Size = New System.Drawing.Size(439, 20)
      Me.txtDescripcion.TabIndex = 3
      '
      'lblCoeficienteStock
      '
      Me.lblCoeficienteStock.AutoSize = True
      Me.lblCoeficienteStock.Location = New System.Drawing.Point(23, 155)
      Me.lblCoeficienteStock.Name = "lblCoeficienteStock"
      Me.lblCoeficienteStock.Size = New System.Drawing.Size(91, 13)
      Me.lblCoeficienteStock.TabIndex = 5
      Me.lblCoeficienteStock.Text = "Coeficiente Stock"
      '
      'cmbCargaPrecio
      '
      Me.cmbCargaPrecio.BindearPropiedadControl = "SelectedValue"
      Me.cmbCargaPrecio.BindearPropiedadEntidad = "CargaPrecio"
      Me.cmbCargaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCargaPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCargaPrecio.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCargaPrecio.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCargaPrecio.FormattingEnabled = True
      Me.cmbCargaPrecio.IsPK = False
      Me.cmbCargaPrecio.IsRequired = True
      Me.cmbCargaPrecio.Key = Nothing
      Me.cmbCargaPrecio.LabelAsoc = Me.lblCargaPrecio
      Me.cmbCargaPrecio.Location = New System.Drawing.Point(120, 181)
      Me.cmbCargaPrecio.Name = "cmbCargaPrecio"
      Me.cmbCargaPrecio.Size = New System.Drawing.Size(101, 21)
      Me.cmbCargaPrecio.TabIndex = 10
      '
      'lblCargaPrecio
      '
      Me.lblCargaPrecio.AutoSize = True
      Me.lblCargaPrecio.Location = New System.Drawing.Point(23, 185)
      Me.lblCargaPrecio.Name = "lblCargaPrecio"
      Me.lblCargaPrecio.Size = New System.Drawing.Size(68, 13)
      Me.lblCargaPrecio.TabIndex = 9
      Me.lblCargaPrecio.Text = "Carga Precio"
      '
      'lblMovimientosAsociados
      '
      Me.lblMovimientosAsociados.AutoSize = True
      Me.lblMovimientosAsociados.Location = New System.Drawing.Point(23, 220)
      Me.lblMovimientosAsociados.Name = "lblMovimientosAsociados"
      Me.lblMovimientosAsociados.Size = New System.Drawing.Size(118, 13)
      Me.lblMovimientosAsociados.TabIndex = 11
      Me.lblMovimientosAsociados.Text = "Movimientos Asociados"
      '
      'chbImprime
      '
      Me.chbImprime.AutoSize = True
      Me.chbImprime.BindearPropiedadControl = "Checked"
      Me.chbImprime.BindearPropiedadEntidad = "Imprime"
      Me.chbImprime.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImprime.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImprime.IsPK = False
      Me.chbImprime.IsRequired = False
      Me.chbImprime.Key = Nothing
      Me.chbImprime.LabelAsoc = Nothing
      Me.chbImprime.Location = New System.Drawing.Point(278, 18)
      Me.chbImprime.Name = "chbImprime"
      Me.chbImprime.Size = New System.Drawing.Size(62, 17)
      Me.chbImprime.TabIndex = 2
      Me.chbImprime.Text = "Imprime"
      Me.chbImprime.UseVisualStyleBackColor = True
      '
      'chbMuestraCombo
      '
      Me.chbMuestraCombo.AutoSize = True
      Me.chbMuestraCombo.BindearPropiedadControl = "Checked"
      Me.chbMuestraCombo.BindearPropiedadEntidad = "MuestraCombo"
      Me.chbMuestraCombo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMuestraCombo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMuestraCombo.IsPK = False
      Me.chbMuestraCombo.IsRequired = False
      Me.chbMuestraCombo.Key = Nothing
      Me.chbMuestraCombo.LabelAsoc = Nothing
      Me.chbMuestraCombo.Location = New System.Drawing.Point(141, 19)
      Me.chbMuestraCombo.Name = "chbMuestraCombo"
      Me.chbMuestraCombo.Size = New System.Drawing.Size(100, 17)
      Me.chbMuestraCombo.TabIndex = 1
      Me.chbMuestraCombo.Text = "Muestra Combo"
      Me.chbMuestraCombo.UseVisualStyleBackColor = True
      '
      'GroupBox1
      '
      Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.GroupBox1.Controls.Add(Me.chbHabilitaRubro)
      Me.GroupBox1.Controls.Add(Me.chbHabilitaEmpleado)
      Me.GroupBox1.Controls.Add(Me.chbHabilitaDestinatario)
      Me.GroupBox1.Controls.Add(Me.chbImprime)
      Me.GroupBox1.Controls.Add(Me.chbAsociaSucursal)
      Me.GroupBox1.Controls.Add(Me.chbReservaMercaderia)
      Me.GroupBox1.Controls.Add(Me.chbMuestraCombo)
      Me.GroupBox1.Location = New System.Drawing.Point(23, 70)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(536, 66)
      Me.GroupBox1.TabIndex = 4
      Me.GroupBox1.TabStop = False
      '
      'chbHabilitaRubro
      '
      Me.chbHabilitaRubro.AutoSize = True
      Me.chbHabilitaRubro.BindearPropiedadControl = "Checked"
      Me.chbHabilitaRubro.BindearPropiedadEntidad = "HabilitaRubro"
      Me.chbHabilitaRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.chbHabilitaRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbHabilitaRubro.IsPK = False
      Me.chbHabilitaRubro.IsRequired = False
      Me.chbHabilitaRubro.Key = Nothing
      Me.chbHabilitaRubro.LabelAsoc = Nothing
      Me.chbHabilitaRubro.Location = New System.Drawing.Point(11, 42)
      Me.chbHabilitaRubro.Name = "chbHabilitaRubro"
      Me.chbHabilitaRubro.Size = New System.Drawing.Size(93, 17)
      Me.chbHabilitaRubro.TabIndex = 4
      Me.chbHabilitaRubro.Text = "Habilita Rubro"
      Me.chbHabilitaRubro.UseVisualStyleBackColor = True
      '
      'chbHabilitaEmpleado
      '
      Me.chbHabilitaEmpleado.AutoSize = True
      Me.chbHabilitaEmpleado.BindearPropiedadControl = "Checked"
      Me.chbHabilitaEmpleado.BindearPropiedadEntidad = "HabilitaEmpleado"
      Me.chbHabilitaEmpleado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbHabilitaEmpleado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbHabilitaEmpleado.IsPK = False
      Me.chbHabilitaEmpleado.IsRequired = False
      Me.chbHabilitaEmpleado.Key = Nothing
      Me.chbHabilitaEmpleado.LabelAsoc = Nothing
      Me.chbHabilitaEmpleado.Location = New System.Drawing.Point(278, 42)
      Me.chbHabilitaEmpleado.Name = "chbHabilitaEmpleado"
      Me.chbHabilitaEmpleado.Size = New System.Drawing.Size(111, 17)
      Me.chbHabilitaEmpleado.TabIndex = 6
      Me.chbHabilitaEmpleado.Text = "Habilita Empleado"
      Me.chbHabilitaEmpleado.UseVisualStyleBackColor = True
      '
      'chbHabilitaDestinatario
      '
      Me.chbHabilitaDestinatario.AutoSize = True
      Me.chbHabilitaDestinatario.BindearPropiedadControl = "Checked"
      Me.chbHabilitaDestinatario.BindearPropiedadEntidad = "HabilitaDestinatario"
      Me.chbHabilitaDestinatario.ForeColorFocus = System.Drawing.Color.Red
      Me.chbHabilitaDestinatario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbHabilitaDestinatario.IsPK = False
      Me.chbHabilitaDestinatario.IsRequired = False
      Me.chbHabilitaDestinatario.Key = Nothing
      Me.chbHabilitaDestinatario.LabelAsoc = Nothing
      Me.chbHabilitaDestinatario.Location = New System.Drawing.Point(141, 42)
      Me.chbHabilitaDestinatario.Name = "chbHabilitaDestinatario"
      Me.chbHabilitaDestinatario.Size = New System.Drawing.Size(120, 17)
      Me.chbHabilitaDestinatario.TabIndex = 5
      Me.chbHabilitaDestinatario.Text = "Habilita Destinatario"
      Me.chbHabilitaDestinatario.UseVisualStyleBackColor = True
      '
      'chbAsociaSucursal
      '
      Me.chbAsociaSucursal.AutoSize = True
      Me.chbAsociaSucursal.BindearPropiedadControl = "Checked"
      Me.chbAsociaSucursal.BindearPropiedadEntidad = "AsociaSucursal"
      Me.chbAsociaSucursal.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAsociaSucursal.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAsociaSucursal.IsPK = False
      Me.chbAsociaSucursal.IsRequired = False
      Me.chbAsociaSucursal.Key = Nothing
      Me.chbAsociaSucursal.LabelAsoc = Nothing
      Me.chbAsociaSucursal.Location = New System.Drawing.Point(11, 18)
      Me.chbAsociaSucursal.Name = "chbAsociaSucursal"
      Me.chbAsociaSucursal.Size = New System.Drawing.Size(102, 17)
      Me.chbAsociaSucursal.TabIndex = 0
      Me.chbAsociaSucursal.Text = "Asocia Sucursal"
      Me.chbAsociaSucursal.UseVisualStyleBackColor = True
      '
      'lblContraTipoMovimiento
      '
      Me.lblContraTipoMovimiento.AutoSize = True
      Me.lblContraTipoMovimiento.Location = New System.Drawing.Point(234, 155)
      Me.lblContraTipoMovimiento.Name = "lblContraTipoMovimiento"
      Me.lblContraTipoMovimiento.Size = New System.Drawing.Size(119, 13)
      Me.lblContraTipoMovimiento.TabIndex = 7
      Me.lblContraTipoMovimiento.Text = "Contra Tipo Movimiento"
      '
      'clbComprobantesAsociados
      '
      Me.clbComprobantesAsociados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.clbComprobantesAsociados.CheckOnClick = True
      Me.clbComprobantesAsociados.ColumnWidth = 150
      Me.clbComprobantesAsociados.FormattingEnabled = True
      Me.clbComprobantesAsociados.Location = New System.Drawing.Point(23, 236)
      Me.clbComprobantesAsociados.MultiColumn = True
      Me.clbComprobantesAsociados.Name = "clbComprobantesAsociados"
      Me.clbComprobantesAsociados.Size = New System.Drawing.Size(536, 169)
      Me.clbComprobantesAsociados.TabIndex = 12
      '
      'cmbContraTipoMovimiento
      '
      Me.cmbContraTipoMovimiento.BindearPropiedadControl = "SelectedValue"
      Me.cmbContraTipoMovimiento.BindearPropiedadEntidad = "IdContraTipoMovimiento"
      Me.cmbContraTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbContraTipoMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbContraTipoMovimiento.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbContraTipoMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbContraTipoMovimiento.FormattingEnabled = True
      Me.cmbContraTipoMovimiento.IsPK = False
      Me.cmbContraTipoMovimiento.IsRequired = False
      Me.cmbContraTipoMovimiento.Items.AddRange(New Object() {"0", "1", "-1"})
      Me.cmbContraTipoMovimiento.Key = Nothing
      Me.cmbContraTipoMovimiento.LabelAsoc = Me.lblContraTipoMovimiento
      Me.cmbContraTipoMovimiento.Location = New System.Drawing.Point(357, 151)
      Me.cmbContraTipoMovimiento.Name = "cmbContraTipoMovimiento"
      Me.cmbContraTipoMovimiento.Size = New System.Drawing.Size(147, 21)
      Me.cmbContraTipoMovimiento.TabIndex = 8
      '
      'cmbCoeficienteStock
      '
      Me.cmbCoeficienteStock.BindearPropiedadControl = "SelectedItem"
      Me.cmbCoeficienteStock.BindearPropiedadEntidad = "CoeficienteStock"
      Me.cmbCoeficienteStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCoeficienteStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCoeficienteStock.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbCoeficienteStock.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbCoeficienteStock.FormattingEnabled = True
      Me.cmbCoeficienteStock.IsPK = False
      Me.cmbCoeficienteStock.IsRequired = True
      Me.cmbCoeficienteStock.Key = Nothing
      Me.cmbCoeficienteStock.LabelAsoc = Me.lblCoeficienteStock
      Me.cmbCoeficienteStock.Location = New System.Drawing.Point(120, 151)
      Me.cmbCoeficienteStock.Name = "cmbCoeficienteStock"
      Me.cmbCoeficienteStock.Size = New System.Drawing.Size(44, 21)
      Me.cmbCoeficienteStock.TabIndex = 6
      '
      'chbReservaMercaderia
      '
      Me.chbReservaMercaderia.AutoSize = True
      Me.chbReservaMercaderia.BindearPropiedadControl = "Checked"
      Me.chbReservaMercaderia.BindearPropiedadEntidad = "ReservaMercaderia"
      Me.chbReservaMercaderia.ForeColorFocus = System.Drawing.Color.Red
      Me.chbReservaMercaderia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbReservaMercaderia.IsPK = False
      Me.chbReservaMercaderia.IsRequired = False
      Me.chbReservaMercaderia.Key = Nothing
      Me.chbReservaMercaderia.LabelAsoc = Nothing
      Me.chbReservaMercaderia.Location = New System.Drawing.Point(395, 18)
      Me.chbReservaMercaderia.Name = "chbReservaMercaderia"
      Me.chbReservaMercaderia.Size = New System.Drawing.Size(122, 17)
      Me.chbReservaMercaderia.TabIndex = 3
      Me.chbReservaMercaderia.Text = "Reserva Mercaderia"
      Me.chbReservaMercaderia.UseVisualStyleBackColor = True
      '
      'TiposMovimientosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(571, 445)
      Me.Controls.Add(Me.cmbCoeficienteStock)
      Me.Controls.Add(Me.cmbContraTipoMovimiento)
      Me.Controls.Add(Me.clbComprobantesAsociados)
      Me.Controls.Add(Me.lblContraTipoMovimiento)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.lblMovimientosAsociados)
      Me.Controls.Add(Me.cmbCargaPrecio)
      Me.Controls.Add(Me.lblCargaPrecio)
      Me.Controls.Add(Me.lblCoeficienteStock)
      Me.Controls.Add(Me.lblDescripcion)
      Me.Controls.Add(Me.txtDescripcion)
      Me.Controls.Add(Me.lblIdTipoMovimiento)
      Me.Controls.Add(Me.txtIdTipoMovimiento)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "TiposMovimientosDetalle"
      Me.Text = "Tipo Movimiento"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.txtIdTipoMovimiento, 0)
      Me.Controls.SetChildIndex(Me.lblIdTipoMovimiento, 0)
      Me.Controls.SetChildIndex(Me.txtDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblDescripcion, 0)
      Me.Controls.SetChildIndex(Me.lblCoeficienteStock, 0)
      Me.Controls.SetChildIndex(Me.lblCargaPrecio, 0)
      Me.Controls.SetChildIndex(Me.cmbCargaPrecio, 0)
      Me.Controls.SetChildIndex(Me.lblMovimientosAsociados, 0)
      Me.Controls.SetChildIndex(Me.GroupBox1, 0)
      Me.Controls.SetChildIndex(Me.lblContraTipoMovimiento, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.clbComprobantesAsociados, 0)
      Me.Controls.SetChildIndex(Me.cmbContraTipoMovimiento, 0)
      Me.Controls.SetChildIndex(Me.cmbCoeficienteStock, 0)
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblIdTipoMovimiento As Eniac.Controles.Label
   Friend WithEvents txtIdTipoMovimiento As Eniac.Controles.TextBox
   Friend WithEvents lblDescripcion As Eniac.Controles.Label
   Friend WithEvents txtDescripcion As Eniac.Controles.TextBox
   Friend WithEvents lblCoeficienteStock As Eniac.Controles.Label
   Public WithEvents cmbCargaPrecio As Eniac.Controles.ComboBox
   Friend WithEvents lblCargaPrecio As Eniac.Controles.Label
   Friend WithEvents lblMovimientosAsociados As Eniac.Controles.Label
   Friend WithEvents chbImprime As Eniac.Controles.CheckBox
   Friend WithEvents chbMuestraCombo As Eniac.Controles.CheckBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents chbHabilitaDestinatario As Eniac.Controles.CheckBox
   Friend WithEvents lblContraTipoMovimiento As Eniac.Controles.Label
   Friend WithEvents chbHabilitaRubro As Eniac.Controles.CheckBox
   Friend WithEvents clbComprobantesAsociados As Eniac.Controles.CheckedListBox
   Friend WithEvents chbAsociaSucursal As Eniac.Controles.CheckBox
   Public WithEvents cmbContraTipoMovimiento As Eniac.Controles.ComboBox
   Public WithEvents cmbCoeficienteStock As Eniac.Controles.ComboBox
   Friend WithEvents chbHabilitaEmpleado As Eniac.Controles.CheckBox
   Friend WithEvents chbReservaMercaderia As Eniac.Controles.CheckBox

End Class
