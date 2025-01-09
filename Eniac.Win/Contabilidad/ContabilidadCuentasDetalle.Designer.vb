<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContabilidadCuentasDetalle
   Inherits Eniac.Win.BaseDetalle

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
      Me.chbActiva = New Eniac.Controles.CheckBox()
      Me.grbCuenta = New System.Windows.Forms.GroupBox()
      Me.cmbTipoCuenta = New Eniac.Controles.ComboBox()
      Me.lblTipoCuenta = New Eniac.Controles.Label()
      Me.chbAjustaPorInflacion = New Eniac.Controles.CheckBox()
      Me.txtCodigo = New Eniac.Controles.TextBox()
      Me.lblCodigo = New Eniac.Controles.Label()
      Me.chbImputable = New Eniac.Controles.CheckBox()
      Me.txtdscCuenta = New Eniac.Controles.TextBox()
      Me.lbldesc = New Eniac.Controles.Label()
      Me.grbJerarquia = New System.Windows.Forms.GroupBox()
      Me.lblJerarquia = New Eniac.Controles.Label()
      Me.cmdPlan = New System.Windows.Forms.Button()
      Me.cmbNivel = New Eniac.Controles.ComboBox()
      Me.lblNivel = New Eniac.Controles.Label()
      Me.grbPadre = New System.Windows.Forms.GroupBox()
      Me.txtCuentaPadre = New Eniac.Controles.TextBox()
      Me.lblDescPadre = New Eniac.Controles.Label()
      Me.bscDescripcionPadre = New Eniac.Controles.Buscador()
      Me.lblCtaPadre = New Eniac.Controles.Label()
      Me.grbCuenta.SuspendLayout()
      Me.grbJerarquia.SuspendLayout()
      Me.grbPadre.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(355, 404)
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(441, 404)
      Me.btnCancelar.TabIndex = 4
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(254, 404)
      Me.btnCopiar.TabIndex = 6
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(197, 404)
      Me.btnAplicar.TabIndex = 5
      '
      'chbActiva
      '
      Me.chbActiva.BindearPropiedadControl = "Checked"
      Me.chbActiva.BindearPropiedadEntidad = "Activa"
      Me.chbActiva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbActiva.Checked = True
      Me.chbActiva.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbActiva.ForeColorFocus = System.Drawing.Color.Red
      Me.chbActiva.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbActiva.IsPK = False
      Me.chbActiva.IsRequired = False
      Me.chbActiva.Key = Nothing
      Me.chbActiva.LabelAsoc = Nothing
      Me.chbActiva.Location = New System.Drawing.Point(407, 17)
      Me.chbActiva.Name = "chbActiva"
      Me.chbActiva.Size = New System.Drawing.Size(58, 17)
      Me.chbActiva.TabIndex = 8
      Me.chbActiva.Text = "Activa"
      Me.chbActiva.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      Me.chbActiva.UseVisualStyleBackColor = True
      '
      'grbCuenta
      '
      Me.grbCuenta.Controls.Add(Me.cmbTipoCuenta)
      Me.grbCuenta.Controls.Add(Me.lblTipoCuenta)
      Me.grbCuenta.Controls.Add(Me.chbAjustaPorInflacion)
      Me.grbCuenta.Controls.Add(Me.txtCodigo)
      Me.grbCuenta.Controls.Add(Me.chbImputable)
      Me.grbCuenta.Controls.Add(Me.lblCodigo)
      Me.grbCuenta.Controls.Add(Me.txtdscCuenta)
      Me.grbCuenta.Controls.Add(Me.chbActiva)
      Me.grbCuenta.Controls.Add(Me.lbldesc)
      Me.grbCuenta.Location = New System.Drawing.Point(10, 111)
      Me.grbCuenta.Name = "grbCuenta"
      Me.grbCuenta.Size = New System.Drawing.Size(515, 142)
      Me.grbCuenta.TabIndex = 1
      Me.grbCuenta.TabStop = False
      Me.grbCuenta.Text = "Cuenta"
      '
      'cmbTipoCuenta
      '
      Me.cmbTipoCuenta.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoCuenta.BindearPropiedadEntidad = "TipoCuenta"
      Me.cmbTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoCuenta.FormattingEnabled = True
      Me.cmbTipoCuenta.IsPK = False
      Me.cmbTipoCuenta.IsRequired = False
      Me.cmbTipoCuenta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
      Me.cmbTipoCuenta.Key = Nothing
      Me.cmbTipoCuenta.LabelAsoc = Me.lblTipoCuenta
      Me.cmbTipoCuenta.Location = New System.Drawing.Point(113, 67)
      Me.cmbTipoCuenta.Name = "cmbTipoCuenta"
      Me.cmbTipoCuenta.Size = New System.Drawing.Size(162, 21)
      Me.cmbTipoCuenta.TabIndex = 5
      '
      'lblTipoCuenta
      '
      Me.lblTipoCuenta.AutoSize = True
      Me.lblTipoCuenta.LabelAsoc = Nothing
      Me.lblTipoCuenta.Location = New System.Drawing.Point(42, 70)
      Me.lblTipoCuenta.Name = "lblTipoCuenta"
      Me.lblTipoCuenta.Size = New System.Drawing.Size(65, 13)
      Me.lblTipoCuenta.TabIndex = 4
      Me.lblTipoCuenta.Text = "Tipo Cuenta"
      '
      'chbAjustaPorInflacion
      '
      Me.chbAjustaPorInflacion.AutoSize = True
      Me.chbAjustaPorInflacion.BindearPropiedadControl = "Checked"
      Me.chbAjustaPorInflacion.BindearPropiedadEntidad = "AjustaPorInflacion"
      Me.chbAjustaPorInflacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbAjustaPorInflacion.Checked = True
      Me.chbAjustaPorInflacion.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbAjustaPorInflacion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbAjustaPorInflacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbAjustaPorInflacion.IsPK = False
      Me.chbAjustaPorInflacion.IsRequired = False
      Me.chbAjustaPorInflacion.Key = Nothing
      Me.chbAjustaPorInflacion.LabelAsoc = Nothing
      Me.chbAjustaPorInflacion.Location = New System.Drawing.Point(113, 117)
      Me.chbAjustaPorInflacion.Name = "chbAjustaPorInflacion"
      Me.chbAjustaPorInflacion.Size = New System.Drawing.Size(117, 17)
      Me.chbAjustaPorInflacion.TabIndex = 7
      Me.chbAjustaPorInflacion.Text = "Ajusta Por Inflación"
      Me.chbAjustaPorInflacion.UseVisualStyleBackColor = True
      '
      'txtCodigo
      '
      Me.txtCodigo.BindearPropiedadControl = "Text"
      Me.txtCodigo.BindearPropiedadEntidad = "IdCuenta"
      Me.txtCodigo.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigo.Formato = ""
      Me.txtCodigo.IsDecimal = False
      Me.txtCodigo.IsNumber = True
      Me.txtCodigo.IsPK = True
      Me.txtCodigo.IsRequired = True
      Me.txtCodigo.Key = ""
      Me.txtCodigo.LabelAsoc = Me.lblCodigo
      Me.txtCodigo.Location = New System.Drawing.Point(113, 15)
      Me.txtCodigo.MaxLength = 16
      Me.txtCodigo.Name = "txtCodigo"
      Me.txtCodigo.Size = New System.Drawing.Size(162, 20)
      Me.txtCodigo.TabIndex = 1
      '
      'lblCodigo
      '
      Me.lblCodigo.AutoSize = True
      Me.lblCodigo.LabelAsoc = Nothing
      Me.lblCodigo.Location = New System.Drawing.Point(42, 18)
      Me.lblCodigo.Name = "lblCodigo"
      Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
      Me.lblCodigo.TabIndex = 0
      Me.lblCodigo.Text = "Código"
      '
      'chbImputable
      '
      Me.chbImputable.AutoSize = True
      Me.chbImputable.BindearPropiedadControl = "Checked"
      Me.chbImputable.BindearPropiedadEntidad = "EsImputable"
      Me.chbImputable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.chbImputable.Checked = True
      Me.chbImputable.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbImputable.ForeColorFocus = System.Drawing.Color.Red
      Me.chbImputable.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbImputable.IsPK = False
      Me.chbImputable.IsRequired = False
      Me.chbImputable.Key = Nothing
      Me.chbImputable.LabelAsoc = Nothing
      Me.chbImputable.Location = New System.Drawing.Point(113, 94)
      Me.chbImputable.Name = "chbImputable"
      Me.chbImputable.Size = New System.Drawing.Size(72, 17)
      Me.chbImputable.TabIndex = 6
      Me.chbImputable.Text = "Imputable"
      Me.chbImputable.UseVisualStyleBackColor = True
      '
      'txtdscCuenta
      '
      Me.txtdscCuenta.BindearPropiedadControl = "Text"
      Me.txtdscCuenta.BindearPropiedadEntidad = "NombreCuenta"
      Me.txtdscCuenta.ForeColorFocus = System.Drawing.Color.Red
      Me.txtdscCuenta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtdscCuenta.Formato = ""
      Me.txtdscCuenta.IsDecimal = False
      Me.txtdscCuenta.IsNumber = False
      Me.txtdscCuenta.IsPK = False
      Me.txtdscCuenta.IsRequired = False
      Me.txtdscCuenta.Key = ""
      Me.txtdscCuenta.LabelAsoc = Me.lbldesc
      Me.txtdscCuenta.Location = New System.Drawing.Point(113, 41)
      Me.txtdscCuenta.MaxLength = 50
      Me.txtdscCuenta.Name = "txtdscCuenta"
      Me.txtdscCuenta.Size = New System.Drawing.Size(356, 20)
      Me.txtdscCuenta.TabIndex = 3
      '
      'lbldesc
      '
      Me.lbldesc.AutoSize = True
      Me.lbldesc.LabelAsoc = Nothing
      Me.lbldesc.Location = New System.Drawing.Point(42, 44)
      Me.lbldesc.Name = "lbldesc"
      Me.lbldesc.Size = New System.Drawing.Size(60, 13)
      Me.lbldesc.TabIndex = 2
      Me.lbldesc.Text = "Descipción"
      '
      'grbJerarquia
      '
      Me.grbJerarquia.Controls.Add(Me.lblJerarquia)
      Me.grbJerarquia.Location = New System.Drawing.Point(10, 259)
      Me.grbJerarquia.Name = "grbJerarquia"
      Me.grbJerarquia.Size = New System.Drawing.Size(515, 137)
      Me.grbJerarquia.TabIndex = 2
      Me.grbJerarquia.TabStop = False
      Me.grbJerarquia.Text = "Jerarquía"
      '
      'lblJerarquia
      '
      Me.lblJerarquia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblJerarquia.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold)
      Me.lblJerarquia.LabelAsoc = Nothing
      Me.lblJerarquia.Location = New System.Drawing.Point(6, 16)
      Me.lblJerarquia.Name = "lblJerarquia"
      Me.lblJerarquia.Size = New System.Drawing.Size(436, 117)
      Me.lblJerarquia.TabIndex = 0
      '
      'cmdPlan
      '
      Me.cmdPlan.Location = New System.Drawing.Point(272, 12)
      Me.cmdPlan.Name = "cmdPlan"
      Me.cmdPlan.Size = New System.Drawing.Size(110, 23)
      Me.cmdPlan.TabIndex = 6
      Me.cmdPlan.TabStop = False
      Me.cmdPlan.Text = "Ver Plan Cta."
      Me.cmdPlan.UseVisualStyleBackColor = True
      '
      'cmbNivel
      '
      Me.cmbNivel.BindearPropiedadControl = ""
      Me.cmbNivel.BindearPropiedadEntidad = ""
      Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNivel.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbNivel.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbNivel.FormattingEnabled = True
      Me.cmbNivel.IsPK = False
      Me.cmbNivel.IsRequired = False
      Me.cmbNivel.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
      Me.cmbNivel.Key = Nothing
      Me.cmbNivel.LabelAsoc = Me.lblNivel
      Me.cmbNivel.Location = New System.Drawing.Point(113, 13)
      Me.cmbNivel.Name = "cmbNivel"
      Me.cmbNivel.Size = New System.Drawing.Size(49, 21)
      Me.cmbNivel.TabIndex = 1
      '
      'lblNivel
      '
      Me.lblNivel.AutoSize = True
      Me.lblNivel.LabelAsoc = Nothing
      Me.lblNivel.Location = New System.Drawing.Point(42, 17)
      Me.lblNivel.Name = "lblNivel"
      Me.lblNivel.Size = New System.Drawing.Size(31, 13)
      Me.lblNivel.TabIndex = 0
      Me.lblNivel.Text = "Nivel"
      '
      'grbPadre
      '
      Me.grbPadre.Controls.Add(Me.txtCuentaPadre)
      Me.grbPadre.Controls.Add(Me.lblDescPadre)
      Me.grbPadre.Controls.Add(Me.bscDescripcionPadre)
      Me.grbPadre.Controls.Add(Me.lblCtaPadre)
      Me.grbPadre.Controls.Add(Me.cmbNivel)
      Me.grbPadre.Controls.Add(Me.cmdPlan)
      Me.grbPadre.Controls.Add(Me.lblNivel)
      Me.grbPadre.Location = New System.Drawing.Point(10, 13)
      Me.grbPadre.Name = "grbPadre"
      Me.grbPadre.Size = New System.Drawing.Size(515, 92)
      Me.grbPadre.TabIndex = 0
      Me.grbPadre.TabStop = False
      Me.grbPadre.Text = "Madre"
      '
      'txtCuentaPadre
      '
      Me.txtCuentaPadre.BindearPropiedadControl = "Text"
      Me.txtCuentaPadre.BindearPropiedadEntidad = "IdCuentaPadre"
      Me.txtCuentaPadre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCuentaPadre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCuentaPadre.Formato = ""
      Me.txtCuentaPadre.IsDecimal = False
      Me.txtCuentaPadre.IsNumber = True
      Me.txtCuentaPadre.IsPK = True
      Me.txtCuentaPadre.IsRequired = True
      Me.txtCuentaPadre.Key = ""
      Me.txtCuentaPadre.LabelAsoc = Me.lblCodigo
      Me.txtCuentaPadre.Location = New System.Drawing.Point(113, 40)
      Me.txtCuentaPadre.MaxLength = 16
      Me.txtCuentaPadre.Name = "txtCuentaPadre"
      Me.txtCuentaPadre.ReadOnly = True
      Me.txtCuentaPadre.Size = New System.Drawing.Size(162, 20)
      Me.txtCuentaPadre.TabIndex = 3
      Me.txtCuentaPadre.TabStop = False
      '
      'lblDescPadre
      '
      Me.lblDescPadre.AutoSize = True
      Me.lblDescPadre.LabelAsoc = Nothing
      Me.lblDescPadre.Location = New System.Drawing.Point(42, 70)
      Me.lblDescPadre.Name = "lblDescPadre"
      Me.lblDescPadre.Size = New System.Drawing.Size(63, 13)
      Me.lblDescPadre.TabIndex = 4
      Me.lblDescPadre.Text = "Descripción"
      '
      'bscDescripcionPadre
      '
      Me.bscDescripcionPadre.AyudaAncho = 608
      Me.bscDescripcionPadre.BindearPropiedadControl = ""
      Me.bscDescripcionPadre.BindearPropiedadEntidad = ""
      Me.bscDescripcionPadre.ColumnasAlineacion = Nothing
      Me.bscDescripcionPadre.ColumnasAncho = Nothing
      Me.bscDescripcionPadre.ColumnasFormato = Nothing
      Me.bscDescripcionPadre.ColumnasOcultas = Nothing
      Me.bscDescripcionPadre.ColumnasTitulos = Nothing
      Me.bscDescripcionPadre.Datos = Nothing
      Me.bscDescripcionPadre.FilaDevuelta = Nothing
      Me.bscDescripcionPadre.ForeColorFocus = System.Drawing.Color.Red
      Me.bscDescripcionPadre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscDescripcionPadre.IsDecimal = False
      Me.bscDescripcionPadre.IsNumber = False
      Me.bscDescripcionPadre.IsPK = True
      Me.bscDescripcionPadre.IsRequired = True
      Me.bscDescripcionPadre.Key = ""
      Me.bscDescripcionPadre.LabelAsoc = Me.lblDescPadre
      Me.bscDescripcionPadre.Location = New System.Drawing.Point(113, 66)
      Me.bscDescripcionPadre.MaxLengh = "32767"
      Me.bscDescripcionPadre.Name = "bscDescripcionPadre"
      Me.bscDescripcionPadre.Permitido = True
      Me.bscDescripcionPadre.Selecciono = False
      Me.bscDescripcionPadre.Size = New System.Drawing.Size(275, 20)
      Me.bscDescripcionPadre.TabIndex = 5
      Me.bscDescripcionPadre.Titulo = Nothing
      '
      'lblCtaPadre
      '
      Me.lblCtaPadre.AutoSize = True
      Me.lblCtaPadre.LabelAsoc = Nothing
      Me.lblCtaPadre.Location = New System.Drawing.Point(42, 43)
      Me.lblCtaPadre.Name = "lblCtaPadre"
      Me.lblCtaPadre.Size = New System.Drawing.Size(40, 13)
      Me.lblCtaPadre.TabIndex = 2
      Me.lblCtaPadre.Text = "Código"
      '
      'ContabilidadCuentasDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(530, 439)
      Me.Controls.Add(Me.grbPadre)
      Me.Controls.Add(Me.grbJerarquia)
      Me.Controls.Add(Me.grbCuenta)
      Me.Name = "ContabilidadCuentasDetalle"
      Me.Text = "Cuenta Contable"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.grbCuenta, 0)
      Me.Controls.SetChildIndex(Me.grbJerarquia, 0)
      Me.Controls.SetChildIndex(Me.grbPadre, 0)
      Me.grbCuenta.ResumeLayout(False)
      Me.grbCuenta.PerformLayout()
      Me.grbJerarquia.ResumeLayout(False)
      Me.grbPadre.ResumeLayout(False)
      Me.grbPadre.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents chbActiva As Eniac.Controles.CheckBox
   Friend WithEvents grbCuenta As System.Windows.Forms.GroupBox
   Friend WithEvents txtdscCuenta As Eniac.Controles.TextBox
   Friend WithEvents lbldesc As Eniac.Controles.Label
   Friend WithEvents grbJerarquia As System.Windows.Forms.GroupBox
   Friend WithEvents lblJerarquia As Eniac.Controles.Label
   Friend WithEvents cmdPlan As System.Windows.Forms.Button
   Friend WithEvents cmbNivel As Eniac.Controles.ComboBox
   Friend WithEvents lblNivel As Eniac.Controles.Label
   Friend WithEvents chbImputable As Eniac.Controles.CheckBox
   Friend WithEvents lblCodigo As Eniac.Controles.Label
   Friend WithEvents txtCodigo As Eniac.Controles.TextBox
   Friend WithEvents grbPadre As System.Windows.Forms.GroupBox
   Friend WithEvents lblDescPadre As Eniac.Controles.Label
   Friend WithEvents bscDescripcionPadre As Eniac.Controles.Buscador
   Friend WithEvents lblCtaPadre As Eniac.Controles.Label
   Friend WithEvents txtCuentaPadre As Eniac.Controles.TextBox
   Friend WithEvents chbAjustaPorInflacion As Eniac.Controles.CheckBox
   Friend WithEvents cmbTipoCuenta As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoCuenta As Eniac.Controles.Label
End Class
