<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConceptosDetalle
   Inherits Win.BaseDetalle

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConceptosDetalle))
      Me.chbActivo = New Eniac.Controles.CheckBox()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtId = New Eniac.Controles.TextBox()
      Me.bscCodigoRubro = New Eniac.Controles.Buscador()
      Me.lblRubro = New Eniac.Controles.Label()
      Me.bscRubro = New Eniac.Controles.Buscador()
      Me.chbNoGravado = New Eniac.Controles.CheckBox()
      Me.chbImprimeProveedor = New Eniac.Controles.CheckBox()
      Me.lblAlicuotaIVA2 = New Eniac.Controles.Label()
      Me.cmbGrupoGastos = New Eniac.Controles.ComboBox()
      Me.chbImprimeDetalleComprobante = New Eniac.Controles.CheckBox()
      Me.bscProducto2 = New Eniac.Controles.Buscador2()
      Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
      Me.chbProducto = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(387, 202)
      Me.btnAceptar.TabIndex = 15
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(473, 202)
      Me.btnCancelar.TabIndex = 16
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(286, 202)
      Me.btnCopiar.TabIndex = 19
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(226, 200)
      Me.btnAplicar.TabIndex = 18
      '
      'chbActivo
      '
      Me.chbActivo.AutoSize = True
      Me.chbActivo.BindearPropiedadControl = "Checked"
      Me.chbActivo.BindearPropiedadEntidad = "Activo"
      Me.chbActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbActivo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActivo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActivo.IsPK = False
      Me.chbActivo.IsRequired = False
      Me.chbActivo.Key = Nothing
      Me.chbActivo.LabelAsoc = Nothing
      Me.chbActivo.Location = New System.Drawing.Point(480, 17)
      Me.chbActivo.Name = "chbActivo"
      Me.chbActivo.Size = New System.Drawing.Size(56, 17)
      Me.chbActivo.TabIndex = 17
      Me.chbActivo.Text = "Activo"
      Me.chbActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbActivo.UseVisualStyleBackColor = True
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(20, 49)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'txtNombre
      '
      Me.txtNombre.BindearPropiedadControl = "Text"
      Me.txtNombre.BindearPropiedadEntidad = "NombreConcepto"
      Me.txtNombre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtNombre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtNombre.Formato = ""
      Me.txtNombre.IsDecimal = False
      Me.txtNombre.IsNumber = False
      Me.txtNombre.IsPK = False
      Me.txtNombre.IsRequired = True
      Me.txtNombre.Key = ""
      Me.txtNombre.LabelAsoc = Me.lblNombre
      Me.txtNombre.Location = New System.Drawing.Point(114, 46)
      Me.txtNombre.MaxLength = 70
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(422, 20)
      Me.txtNombre.TabIndex = 3
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.Location = New System.Drawing.Point(20, 20)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 0
      Me.lblId.Text = "Código"
      '
      'txtId
      '
      Me.txtId.BindearPropiedadControl = "Text"
      Me.txtId.BindearPropiedadEntidad = "IdConcepto"
      Me.txtId.ForeColorFocus = System.Drawing.Color.Red
      Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtId.Formato = ""
      Me.txtId.IsDecimal = False
      Me.txtId.IsNumber = True
      Me.txtId.IsPK = True
      Me.txtId.IsRequired = True
      Me.txtId.Key = ""
      Me.txtId.LabelAsoc = Me.lblId
      Me.txtId.Location = New System.Drawing.Point(114, 17)
      Me.txtId.MaxLength = 4
      Me.txtId.Name = "txtId"
      Me.txtId.Size = New System.Drawing.Size(92, 20)
      Me.txtId.TabIndex = 1
      '
      'bscCodigoRubro
      '
      Me.bscCodigoRubro.AyudaAncho = 608
      Me.bscCodigoRubro.BindearPropiedadControl = "Text"
      Me.bscCodigoRubro.BindearPropiedadEntidad = "IdRubroConcepto"
      Me.bscCodigoRubro.ColumnasAlineacion = Nothing
      Me.bscCodigoRubro.ColumnasAncho = Nothing
      Me.bscCodigoRubro.ColumnasFormato = Nothing
      Me.bscCodigoRubro.ColumnasOcultas = Nothing
      Me.bscCodigoRubro.ColumnasTitulos = Nothing
      Me.bscCodigoRubro.Datos = Nothing
      Me.bscCodigoRubro.FilaDevuelta = Nothing
      Me.bscCodigoRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoRubro.IsDecimal = False
      Me.bscCodigoRubro.IsNumber = False
      Me.bscCodigoRubro.IsPK = False
      Me.bscCodigoRubro.IsRequired = False
      Me.bscCodigoRubro.Key = ""
      Me.bscCodigoRubro.LabelAsoc = Me.lblRubro
      Me.bscCodigoRubro.Location = New System.Drawing.Point(114, 75)
      Me.bscCodigoRubro.MaxLengh = "32767"
      Me.bscCodigoRubro.Name = "bscCodigoRubro"
      Me.bscCodigoRubro.Permitido = True
      Me.bscCodigoRubro.Selecciono = False
      Me.bscCodigoRubro.Size = New System.Drawing.Size(91, 20)
      Me.bscCodigoRubro.TabIndex = 5
      Me.bscCodigoRubro.Titulo = Nothing
      '
      'lblRubro
      '
      Me.lblRubro.AutoSize = True
      Me.lblRubro.Location = New System.Drawing.Point(20, 77)
      Me.lblRubro.Name = "lblRubro"
      Me.lblRubro.Size = New System.Drawing.Size(36, 13)
      Me.lblRubro.TabIndex = 4
      Me.lblRubro.Text = "Rubro"
      '
      'bscRubro
      '
      Me.bscRubro.AyudaAncho = 608
      Me.bscRubro.BindearPropiedadControl = ""
      Me.bscRubro.BindearPropiedadEntidad = ""
      Me.bscRubro.ColumnasAlineacion = Nothing
      Me.bscRubro.ColumnasAncho = Nothing
      Me.bscRubro.ColumnasFormato = Nothing
      Me.bscRubro.ColumnasOcultas = Nothing
      Me.bscRubro.ColumnasTitulos = Nothing
      Me.bscRubro.Datos = Nothing
      Me.bscRubro.FilaDevuelta = Nothing
      Me.bscRubro.ForeColorFocus = System.Drawing.Color.Red
      Me.bscRubro.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscRubro.IsDecimal = False
      Me.bscRubro.IsNumber = False
      Me.bscRubro.IsPK = False
      Me.bscRubro.IsRequired = False
      Me.bscRubro.Key = ""
      Me.bscRubro.LabelAsoc = Me.lblRubro
      Me.bscRubro.Location = New System.Drawing.Point(209, 74)
      Me.bscRubro.MaxLengh = "32767"
      Me.bscRubro.Name = "bscRubro"
      Me.bscRubro.Permitido = True
      Me.bscRubro.Selecciono = False
      Me.bscRubro.Size = New System.Drawing.Size(327, 20)
      Me.bscRubro.TabIndex = 6
      Me.bscRubro.Titulo = Nothing
      '
      'chbNoGravado
      '
      Me.chbNoGravado.AutoSize = True
      Me.chbNoGravado.BindearPropiedadControl = "Checked"
      Me.chbNoGravado.BindearPropiedadEntidad = "EsNoGravado"
      Me.chbNoGravado.ForeColorFocus = System.Drawing.Color.Red
      Me.chbNoGravado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbNoGravado.IsPK = False
      Me.chbNoGravado.IsRequired = False
      Me.chbNoGravado.Key = Nothing
      Me.chbNoGravado.LabelAsoc = Nothing
      Me.chbNoGravado.Location = New System.Drawing.Point(114, 154)
      Me.chbNoGravado.Name = "chbNoGravado"
      Me.chbNoGravado.Size = New System.Drawing.Size(84, 17)
      Me.chbNoGravado.TabIndex = 12
      Me.chbNoGravado.Text = "No Gravado"
      Me.chbNoGravado.UseVisualStyleBackColor = True
      '
      'chbImprimeProveedor
      '
      Me.chbImprimeProveedor.AutoSize = True
      Me.chbImprimeProveedor.BindearPropiedadControl = "Checked"
      Me.chbImprimeProveedor.BindearPropiedadEntidad = "ImprimeProveedor"
      Me.chbImprimeProveedor.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImprimeProveedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImprimeProveedor.IsPK = False
      Me.chbImprimeProveedor.IsRequired = False
      Me.chbImprimeProveedor.Key = Nothing
      Me.chbImprimeProveedor.LabelAsoc = Nothing
      Me.chbImprimeProveedor.Location = New System.Drawing.Point(114, 177)
      Me.chbImprimeProveedor.Name = "chbImprimeProveedor"
      Me.chbImprimeProveedor.Size = New System.Drawing.Size(114, 17)
      Me.chbImprimeProveedor.TabIndex = 13
      Me.chbImprimeProveedor.Text = "Imprime Proveedor"
      Me.chbImprimeProveedor.UseVisualStyleBackColor = True
      '
      'lblAlicuotaIVA2
      '
      Me.lblAlicuotaIVA2.AutoSize = True
      Me.lblAlicuotaIVA2.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblAlicuotaIVA2.Location = New System.Drawing.Point(20, 105)
      Me.lblAlicuotaIVA2.Name = "lblAlicuotaIVA2"
      Me.lblAlicuotaIVA2.Size = New System.Drawing.Size(87, 13)
      Me.lblAlicuotaIVA2.TabIndex = 7
      Me.lblAlicuotaIVA2.Text = "Grupo de Gastos"
      '
      'cmbGrupoGastos
      '
      Me.cmbGrupoGastos.BindearPropiedadControl = "Text"
      Me.cmbGrupoGastos.BindearPropiedadEntidad = "GrupoGastos"
      Me.cmbGrupoGastos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbGrupoGastos.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbGrupoGastos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbGrupoGastos.FormattingEnabled = True
      Me.cmbGrupoGastos.IsPK = False
      Me.cmbGrupoGastos.IsRequired = False
      Me.cmbGrupoGastos.Items.AddRange(New Object() {"A", "B", "C"})
      Me.cmbGrupoGastos.Key = Nothing
      Me.cmbGrupoGastos.LabelAsoc = Me.lblAlicuotaIVA2
      Me.cmbGrupoGastos.Location = New System.Drawing.Point(114, 101)
      Me.cmbGrupoGastos.Name = "cmbGrupoGastos"
      Me.cmbGrupoGastos.Size = New System.Drawing.Size(66, 21)
      Me.cmbGrupoGastos.TabIndex = 8
      '
      'chbImprimeDetalleComprobante
      '
      Me.chbImprimeDetalleComprobante.AutoSize = True
      Me.chbImprimeDetalleComprobante.BindearPropiedadControl = "Checked"
      Me.chbImprimeDetalleComprobante.BindearPropiedadEntidad = "ImprimeDetalleComprobante"
      Me.chbImprimeDetalleComprobante.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImprimeDetalleComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImprimeDetalleComprobante.IsPK = False
      Me.chbImprimeDetalleComprobante.IsRequired = False
      Me.chbImprimeDetalleComprobante.Key = Nothing
      Me.chbImprimeDetalleComprobante.LabelAsoc = Nothing
      Me.chbImprimeDetalleComprobante.Location = New System.Drawing.Point(234, 177)
      Me.chbImprimeDetalleComprobante.Name = "chbImprimeDetalleComprobante"
      Me.chbImprimeDetalleComprobante.Size = New System.Drawing.Size(184, 17)
      Me.chbImprimeDetalleComprobante.TabIndex = 14
      Me.chbImprimeDetalleComprobante.Text = "Imprime Detalle de Comprobantes"
      Me.chbImprimeDetalleComprobante.UseVisualStyleBackColor = True
      '
      'bscProducto2
      '
      Me.bscProducto2.ActivarFiltroEnGrilla = True
      Me.bscProducto2.BindearPropiedadControl = Nothing
      Me.bscProducto2.BindearPropiedadEntidad = Nothing
      Me.bscProducto2.ConfigBuscador = Nothing
      Me.bscProducto2.Datos = Nothing
      Me.bscProducto2.Enabled = False
      Me.bscProducto2.FilaDevuelta = Nothing
      Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscProducto2.IsDecimal = False
      Me.bscProducto2.IsNumber = False
      Me.bscProducto2.IsPK = False
      Me.bscProducto2.IsRequired = False
      Me.bscProducto2.Key = ""
      Me.bscProducto2.LabelAsoc = Nothing
      Me.bscProducto2.Location = New System.Drawing.Point(264, 129)
      Me.bscProducto2.MaxLengh = "32767"
      Me.bscProducto2.Name = "bscProducto2"
      Me.bscProducto2.Permitido = True
      Me.bscProducto2.Selecciono = False
      Me.bscProducto2.Size = New System.Drawing.Size(272, 20)
      Me.bscProducto2.TabIndex = 11
      Me.bscProducto2.TextBoxBackColor = System.Drawing.Color.Empty
      Me.bscProducto2.TextBoxForeColor = System.Drawing.Color.Empty
      '
      'bscCodigoProducto2
      '
      Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
      Me.bscCodigoProducto2.BindearPropiedadControl = ""
      Me.bscCodigoProducto2.BindearPropiedadEntidad = ""
      Me.bscCodigoProducto2.ConfigBuscador = Nothing
      Me.bscCodigoProducto2.Datos = Nothing
      Me.bscCodigoProducto2.Enabled = False
      Me.bscCodigoProducto2.FilaDevuelta = Nothing
      Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoProducto2.IsDecimal = False
      Me.bscCodigoProducto2.IsNumber = False
      Me.bscCodigoProducto2.IsPK = False
      Me.bscCodigoProducto2.IsRequired = False
      Me.bscCodigoProducto2.Key = ""
      Me.bscCodigoProducto2.LabelAsoc = Nothing
      Me.bscCodigoProducto2.Location = New System.Drawing.Point(114, 128)
      Me.bscCodigoProducto2.MaxLengh = "32767"
      Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
      Me.bscCodigoProducto2.Permitido = True
      Me.bscCodigoProducto2.Selecciono = False
      Me.bscCodigoProducto2.Size = New System.Drawing.Size(146, 20)
      Me.bscCodigoProducto2.TabIndex = 10
      Me.bscCodigoProducto2.TextBoxBackColor = System.Drawing.Color.Empty
      Me.bscCodigoProducto2.TextBoxForeColor = System.Drawing.Color.Empty
      '
      'chbProducto
      '
      Me.chbProducto.AutoSize = True
      Me.chbProducto.BindearPropiedadControl = Nothing
      Me.chbProducto.BindearPropiedadEntidad = Nothing
      Me.chbProducto.ForeColorFocus = System.Drawing.Color.Red
      Me.chbProducto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbProducto.IsPK = False
      Me.chbProducto.IsRequired = False
      Me.chbProducto.Key = Nothing
      Me.chbProducto.LabelAsoc = Nothing
      Me.chbProducto.Location = New System.Drawing.Point(23, 129)
      Me.chbProducto.Name = "chbProducto"
      Me.chbProducto.Size = New System.Drawing.Size(69, 17)
      Me.chbProducto.TabIndex = 9
      Me.chbProducto.Text = "&Producto"
      '
      'ConceptosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(562, 237)
      Me.Controls.Add(Me.bscProducto2)
      Me.Controls.Add(Me.bscCodigoProducto2)
      Me.Controls.Add(Me.chbProducto)
      Me.Controls.Add(Me.lblAlicuotaIVA2)
      Me.Controls.Add(Me.cmbGrupoGastos)
      Me.Controls.Add(Me.chbImprimeDetalleComprobante)
      Me.Controls.Add(Me.chbImprimeProveedor)
      Me.Controls.Add(Me.chbNoGravado)
      Me.Controls.Add(Me.bscCodigoRubro)
      Me.Controls.Add(Me.bscRubro)
      Me.Controls.Add(Me.lblRubro)
      Me.Controls.Add(Me.chbActivo)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtId)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ConceptosDetalle"
      Me.Text = "Concepto"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtId, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.Controls.SetChildIndex(Me.chbActivo, 0)
      Me.Controls.SetChildIndex(Me.lblRubro, 0)
      Me.Controls.SetChildIndex(Me.bscRubro, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoRubro, 0)
      Me.Controls.SetChildIndex(Me.chbNoGravado, 0)
      Me.Controls.SetChildIndex(Me.chbImprimeProveedor, 0)
      Me.Controls.SetChildIndex(Me.chbImprimeDetalleComprobante, 0)
      Me.Controls.SetChildIndex(Me.cmbGrupoGastos, 0)
      Me.Controls.SetChildIndex(Me.lblAlicuotaIVA2, 0)
      Me.Controls.SetChildIndex(Me.chbProducto, 0)
      Me.Controls.SetChildIndex(Me.bscCodigoProducto2, 0)
      Me.Controls.SetChildIndex(Me.bscProducto2, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents bscCodigoRubro As Eniac.Controles.Buscador
   Friend WithEvents lblRubro As Eniac.Controles.Label
   Friend WithEvents bscRubro As Eniac.Controles.Buscador
   Friend WithEvents chbNoGravado As Eniac.Controles.CheckBox
   Friend WithEvents chbImprimeProveedor As Eniac.Controles.CheckBox
   Friend WithEvents lblAlicuotaIVA2 As Eniac.Controles.Label
   Friend WithEvents cmbGrupoGastos As Eniac.Controles.ComboBox
   Friend WithEvents chbImprimeDetalleComprobante As Eniac.Controles.CheckBox
   Friend WithEvents bscProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents bscCodigoProducto2 As Eniac.Controles.Buscador2
   Friend WithEvents chbProducto As Eniac.Controles.CheckBox
End Class
