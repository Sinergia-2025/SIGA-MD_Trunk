<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegimenesDetalle
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
      Me.cmbTipoImpuesto = New Eniac.Controles.ComboBox()
      Me.lblIdTipoImpuesto = New Eniac.Controles.Label()
      Me.lblNombreProducto = New Eniac.Controles.Label()
      Me.txtConcepto = New Eniac.Controles.TextBox()
      Me.lblIdRegimen = New Eniac.Controles.Label()
      Me.txtRegimen = New Eniac.Controles.TextBox()
      Me.lblAlicuota = New Eniac.Controles.Label()
      Me.txtRetenerIns = New Eniac.Controles.TextBox()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtRetenerNoIns = New Eniac.Controles.TextBox()
      Me.Label2 = New Eniac.Controles.Label()
      Me.txtMontoExceder = New Eniac.Controles.TextBox()
      Me.lblMontoMinInscripto = New Eniac.Controles.Label()
      Me.txtImporteMinimoInscripto = New Eniac.Controles.TextBox()
      Me.lblMontoMinNoInscripto = New Eniac.Controles.Label()
      Me.txtMontoMinimoNoInscripto = New Eniac.Controles.TextBox()
      Me.chbPasibleRetencion = New Eniac.Controles.CheckBox()
      Me.lblMinimoNoImponible = New Eniac.Controles.Label()
      Me.txtMinimoNoImponible = New Eniac.Controles.TextBox()
      Me.lblOrigenBaseImponible = New Eniac.Controles.Label()
      Me.cmbOrigenBaseImponible = New Eniac.Controles.ComboBox()
      Me.lblCodigoAfip = New Eniac.Controles.Label()
      Me.txtCodigoAfip = New Eniac.Controles.TextBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(312, 241)
      Me.btnAceptar.TabIndex = 23
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(398, 241)
      Me.btnCancelar.TabIndex = 24
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(211, 241)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(151, 241)
      '
      'cmbTipoImpuesto
      '
      Me.cmbTipoImpuesto.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoImpuesto.BindearPropiedadEntidad = "TipoImpuesto.IdTipoImpuesto"
      Me.cmbTipoImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoImpuesto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoImpuesto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoImpuesto.FormattingEnabled = True
      Me.cmbTipoImpuesto.IsPK = False
      Me.cmbTipoImpuesto.IsRequired = True
      Me.cmbTipoImpuesto.Key = Nothing
      Me.cmbTipoImpuesto.LabelAsoc = Me.lblIdTipoImpuesto
      Me.cmbTipoImpuesto.Location = New System.Drawing.Point(155, 201)
      Me.cmbTipoImpuesto.Name = "cmbTipoImpuesto"
      Me.cmbTipoImpuesto.Size = New System.Drawing.Size(187, 21)
      Me.cmbTipoImpuesto.TabIndex = 21
      '
      'lblIdTipoImpuesto
      '
      Me.lblIdTipoImpuesto.AutoSize = True
      Me.lblIdTipoImpuesto.LabelAsoc = Nothing
      Me.lblIdTipoImpuesto.Location = New System.Drawing.Point(28, 204)
      Me.lblIdTipoImpuesto.Name = "lblIdTipoImpuesto"
      Me.lblIdTipoImpuesto.Size = New System.Drawing.Size(89, 13)
      Me.lblIdTipoImpuesto.TabIndex = 20
      Me.lblIdTipoImpuesto.Text = "Tipo de Impuesto"
      '
      'lblNombreProducto
      '
      Me.lblNombreProducto.AutoSize = True
      Me.lblNombreProducto.LabelAsoc = Nothing
      Me.lblNombreProducto.Location = New System.Drawing.Point(28, 50)
      Me.lblNombreProducto.Name = "lblNombreProducto"
      Me.lblNombreProducto.Size = New System.Drawing.Size(53, 13)
      Me.lblNombreProducto.TabIndex = 4
      Me.lblNombreProducto.Text = "Concepto"
      '
      'txtConcepto
      '
      Me.txtConcepto.BindearPropiedadControl = "Text"
      Me.txtConcepto.BindearPropiedadEntidad = "ConceptoRegimen"
      Me.txtConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtConcepto.Formato = ""
      Me.txtConcepto.IsDecimal = False
      Me.txtConcepto.IsNumber = False
      Me.txtConcepto.IsPK = False
      Me.txtConcepto.IsRequired = True
      Me.txtConcepto.Key = ""
      Me.txtConcepto.LabelAsoc = Me.lblNombreProducto
      Me.txtConcepto.Location = New System.Drawing.Point(84, 46)
      Me.txtConcepto.MaxLength = 200
      Me.txtConcepto.Name = "txtConcepto"
      Me.txtConcepto.Size = New System.Drawing.Size(379, 20)
      Me.txtConcepto.TabIndex = 5
      '
      'lblIdRegimen
      '
      Me.lblIdRegimen.AutoSize = True
      Me.lblIdRegimen.LabelAsoc = Nothing
      Me.lblIdRegimen.Location = New System.Drawing.Point(28, 26)
      Me.lblIdRegimen.Name = "lblIdRegimen"
      Me.lblIdRegimen.Size = New System.Drawing.Size(49, 13)
      Me.lblIdRegimen.TabIndex = 0
      Me.lblIdRegimen.Text = "Régimen"
      '
      'txtRegimen
      '
      Me.txtRegimen.BindearPropiedadControl = "Text"
      Me.txtRegimen.BindearPropiedadEntidad = "IdRegimen"
      Me.txtRegimen.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRegimen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRegimen.Formato = ""
      Me.txtRegimen.IsDecimal = False
      Me.txtRegimen.IsNumber = True
      Me.txtRegimen.IsPK = True
      Me.txtRegimen.IsRequired = True
      Me.txtRegimen.Key = ""
      Me.txtRegimen.LabelAsoc = Me.lblIdRegimen
      Me.txtRegimen.Location = New System.Drawing.Point(84, 22)
      Me.txtRegimen.MaxLength = 10
      Me.txtRegimen.Name = "txtRegimen"
      Me.txtRegimen.Size = New System.Drawing.Size(84, 20)
      Me.txtRegimen.TabIndex = 1
      Me.txtRegimen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAlicuota
      '
      Me.lblAlicuota.AutoSize = True
      Me.lblAlicuota.LabelAsoc = Nothing
      Me.lblAlicuota.Location = New System.Drawing.Point(28, 103)
      Me.lblAlicuota.Name = "lblAlicuota"
      Me.lblAlicuota.Size = New System.Drawing.Size(99, 13)
      Me.lblAlicuota.TabIndex = 8
      Me.lblAlicuota.Text = "% Retener Inscripto"
      '
      'txtRetenerIns
      '
      Me.txtRetenerIns.BindearPropiedadControl = "Text"
      Me.txtRetenerIns.BindearPropiedadEntidad = "ARetenerInscripto"
      Me.txtRetenerIns.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRetenerIns.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRetenerIns.Formato = "##0.00"
      Me.txtRetenerIns.IsDecimal = True
      Me.txtRetenerIns.IsNumber = True
      Me.txtRetenerIns.IsPK = False
      Me.txtRetenerIns.IsRequired = False
      Me.txtRetenerIns.Key = ""
      Me.txtRetenerIns.LabelAsoc = Me.lblAlicuota
      Me.txtRetenerIns.Location = New System.Drawing.Point(155, 99)
      Me.txtRetenerIns.MaxLength = 10
      Me.txtRetenerIns.Name = "txtRetenerIns"
      Me.txtRetenerIns.Size = New System.Drawing.Size(59, 20)
      Me.txtRetenerIns.TabIndex = 9
      Me.txtRetenerIns.Text = "0.00"
      Me.txtRetenerIns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.LabelAsoc = Nothing
      Me.Label1.Location = New System.Drawing.Point(277, 104)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(116, 13)
      Me.Label1.TabIndex = 10
      Me.Label1.Text = "% Retener No Inscripto"
      '
      'txtRetenerNoIns
      '
      Me.txtRetenerNoIns.BindearPropiedadControl = "Text"
      Me.txtRetenerNoIns.BindearPropiedadEntidad = "ARetenerNoInscripto"
      Me.txtRetenerNoIns.ForeColorFocus = System.Drawing.Color.Red
      Me.txtRetenerNoIns.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtRetenerNoIns.Formato = "##0.00"
      Me.txtRetenerNoIns.IsDecimal = True
      Me.txtRetenerNoIns.IsNumber = True
      Me.txtRetenerNoIns.IsPK = False
      Me.txtRetenerNoIns.IsRequired = False
      Me.txtRetenerNoIns.Key = ""
      Me.txtRetenerNoIns.LabelAsoc = Me.Label1
      Me.txtRetenerNoIns.Location = New System.Drawing.Point(404, 100)
      Me.txtRetenerNoIns.MaxLength = 10
      Me.txtRetenerNoIns.Name = "txtRetenerNoIns"
      Me.txtRetenerNoIns.Size = New System.Drawing.Size(59, 20)
      Me.txtRetenerNoIns.TabIndex = 11
      Me.txtRetenerNoIns.Text = "0.00"
      Me.txtRetenerNoIns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.LabelAsoc = Nothing
      Me.Label2.Location = New System.Drawing.Point(28, 129)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(88, 13)
      Me.Label2.TabIndex = 12
      Me.Label2.Text = "Monto a Exceder"
      '
      'txtMontoExceder
      '
      Me.txtMontoExceder.BindearPropiedadControl = "Text"
      Me.txtMontoExceder.BindearPropiedadEntidad = "MontoAExceder"
      Me.txtMontoExceder.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMontoExceder.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMontoExceder.Formato = "##0.00"
      Me.txtMontoExceder.IsDecimal = True
      Me.txtMontoExceder.IsNumber = True
      Me.txtMontoExceder.IsPK = False
      Me.txtMontoExceder.IsRequired = False
      Me.txtMontoExceder.Key = ""
      Me.txtMontoExceder.LabelAsoc = Me.Label2
      Me.txtMontoExceder.Location = New System.Drawing.Point(155, 125)
      Me.txtMontoExceder.MaxLength = 20
      Me.txtMontoExceder.Name = "txtMontoExceder"
      Me.txtMontoExceder.Size = New System.Drawing.Size(59, 20)
      Me.txtMontoExceder.TabIndex = 13
      Me.txtMontoExceder.Text = "0.00"
      Me.txtMontoExceder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblMontoMinInscripto
      '
      Me.lblMontoMinInscripto.AutoSize = True
      Me.lblMontoMinInscripto.LabelAsoc = Nothing
      Me.lblMontoMinInscripto.Location = New System.Drawing.Point(28, 179)
      Me.lblMontoMinInscripto.Name = "lblMontoMinInscripto"
      Me.lblMontoMinInscripto.Size = New System.Drawing.Size(101, 13)
      Me.lblMontoMinInscripto.TabIndex = 16
      Me.lblMontoMinInscripto.Text = "Monto Mínimo Insc."
      '
      'txtImporteMinimoInscripto
      '
      Me.txtImporteMinimoInscripto.BindearPropiedadControl = "Text"
      Me.txtImporteMinimoInscripto.BindearPropiedadEntidad = "ImporteMinimoInscripto"
      Me.txtImporteMinimoInscripto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtImporteMinimoInscripto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtImporteMinimoInscripto.Formato = "##0.00"
      Me.txtImporteMinimoInscripto.IsDecimal = True
      Me.txtImporteMinimoInscripto.IsNumber = True
      Me.txtImporteMinimoInscripto.IsPK = False
      Me.txtImporteMinimoInscripto.IsRequired = False
      Me.txtImporteMinimoInscripto.Key = ""
      Me.txtImporteMinimoInscripto.LabelAsoc = Me.lblMontoMinInscripto
      Me.txtImporteMinimoInscripto.Location = New System.Drawing.Point(155, 175)
      Me.txtImporteMinimoInscripto.MaxLength = 10
      Me.txtImporteMinimoInscripto.Name = "txtImporteMinimoInscripto"
      Me.txtImporteMinimoInscripto.Size = New System.Drawing.Size(59, 20)
      Me.txtImporteMinimoInscripto.TabIndex = 17
      Me.txtImporteMinimoInscripto.Text = "0.00"
      Me.txtImporteMinimoInscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblMontoMinNoInscripto
      '
      Me.lblMontoMinNoInscripto.AutoSize = True
      Me.lblMontoMinNoInscripto.LabelAsoc = Nothing
      Me.lblMontoMinNoInscripto.Location = New System.Drawing.Point(277, 177)
      Me.lblMontoMinNoInscripto.Name = "lblMontoMinNoInscripto"
      Me.lblMontoMinNoInscripto.Size = New System.Drawing.Size(118, 13)
      Me.lblMontoMinNoInscripto.TabIndex = 18
      Me.lblMontoMinNoInscripto.Text = "Monto Mínimo No Insc."
      '
      'txtMontoMinimoNoInscripto
      '
      Me.txtMontoMinimoNoInscripto.BindearPropiedadControl = "Text"
      Me.txtMontoMinimoNoInscripto.BindearPropiedadEntidad = "ImporteMinimoNoInscripto"
      Me.txtMontoMinimoNoInscripto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMontoMinimoNoInscripto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMontoMinimoNoInscripto.Formato = "##0.00"
      Me.txtMontoMinimoNoInscripto.IsDecimal = True
      Me.txtMontoMinimoNoInscripto.IsNumber = True
      Me.txtMontoMinimoNoInscripto.IsPK = False
      Me.txtMontoMinimoNoInscripto.IsRequired = False
      Me.txtMontoMinimoNoInscripto.Key = ""
      Me.txtMontoMinimoNoInscripto.LabelAsoc = Me.lblMontoMinNoInscripto
      Me.txtMontoMinimoNoInscripto.Location = New System.Drawing.Point(404, 173)
      Me.txtMontoMinimoNoInscripto.MaxLength = 10
      Me.txtMontoMinimoNoInscripto.Name = "txtMontoMinimoNoInscripto"
      Me.txtMontoMinimoNoInscripto.Size = New System.Drawing.Size(59, 20)
      Me.txtMontoMinimoNoInscripto.TabIndex = 19
      Me.txtMontoMinimoNoInscripto.Text = "0.00"
      Me.txtMontoMinimoNoInscripto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'chbPasibleRetencion
      '
      Me.chbPasibleRetencion.BindearPropiedadControl = "Checked"
      Me.chbPasibleRetencion.BindearPropiedadEntidad = "RetienePorEscala"
      Me.chbPasibleRetencion.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPasibleRetencion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPasibleRetencion.IsPK = False
      Me.chbPasibleRetencion.IsRequired = False
      Me.chbPasibleRetencion.Key = Nothing
      Me.chbPasibleRetencion.LabelAsoc = Nothing
      Me.chbPasibleRetencion.Location = New System.Drawing.Point(29, 228)
      Me.chbPasibleRetencion.Name = "chbPasibleRetencion"
      Me.chbPasibleRetencion.Size = New System.Drawing.Size(127, 36)
      Me.chbPasibleRetencion.TabIndex = 22
      Me.chbPasibleRetencion.Text = "Retiene por Escala"
      Me.chbPasibleRetencion.UseVisualStyleBackColor = True
      '
      'lblMinimoNoImponible
      '
      Me.lblMinimoNoImponible.AutoSize = True
      Me.lblMinimoNoImponible.LabelAsoc = Nothing
      Me.lblMinimoNoImponible.Location = New System.Drawing.Point(28, 153)
      Me.lblMinimoNoImponible.Name = "lblMinimoNoImponible"
      Me.lblMinimoNoImponible.Size = New System.Drawing.Size(105, 13)
      Me.lblMinimoNoImponible.TabIndex = 14
      Me.lblMinimoNoImponible.Text = "Minimo No Imponible"
      '
      'txtMinimoNoImponible
      '
      Me.txtMinimoNoImponible.BindearPropiedadControl = "Text"
      Me.txtMinimoNoImponible.BindearPropiedadEntidad = "MinimoNoImponible"
      Me.txtMinimoNoImponible.ForeColorFocus = System.Drawing.Color.Red
      Me.txtMinimoNoImponible.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtMinimoNoImponible.Formato = "##0.00"
      Me.txtMinimoNoImponible.IsDecimal = True
      Me.txtMinimoNoImponible.IsNumber = True
      Me.txtMinimoNoImponible.IsPK = False
      Me.txtMinimoNoImponible.IsRequired = False
      Me.txtMinimoNoImponible.Key = ""
      Me.txtMinimoNoImponible.LabelAsoc = Me.lblMinimoNoImponible
      Me.txtMinimoNoImponible.Location = New System.Drawing.Point(155, 149)
      Me.txtMinimoNoImponible.MaxLength = 20
      Me.txtMinimoNoImponible.Name = "txtMinimoNoImponible"
      Me.txtMinimoNoImponible.Size = New System.Drawing.Size(59, 20)
      Me.txtMinimoNoImponible.TabIndex = 15
      Me.txtMinimoNoImponible.Text = "0.00"
      Me.txtMinimoNoImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblOrigenBaseImponible
      '
      Me.lblOrigenBaseImponible.AutoSize = True
      Me.lblOrigenBaseImponible.LabelAsoc = Nothing
      Me.lblOrigenBaseImponible.Location = New System.Drawing.Point(28, 75)
      Me.lblOrigenBaseImponible.Name = "lblOrigenBaseImponible"
      Me.lblOrigenBaseImponible.Size = New System.Drawing.Size(113, 13)
      Me.lblOrigenBaseImponible.TabIndex = 6
      Me.lblOrigenBaseImponible.Text = "Origen Base Imponible"
      '
      'cmbOrigenBaseImponible
      '
      Me.cmbOrigenBaseImponible.BindearPropiedadControl = "SelectedValue"
      Me.cmbOrigenBaseImponible.BindearPropiedadEntidad = "OrigenBaseImponible"
      Me.cmbOrigenBaseImponible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbOrigenBaseImponible.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbOrigenBaseImponible.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbOrigenBaseImponible.FormattingEnabled = True
      Me.cmbOrigenBaseImponible.IsPK = False
      Me.cmbOrigenBaseImponible.IsRequired = False
      Me.cmbOrigenBaseImponible.Key = Nothing
      Me.cmbOrigenBaseImponible.LabelAsoc = Nothing
      Me.cmbOrigenBaseImponible.Location = New System.Drawing.Point(155, 72)
      Me.cmbOrigenBaseImponible.Name = "cmbOrigenBaseImponible"
      Me.cmbOrigenBaseImponible.Size = New System.Drawing.Size(90, 21)
      Me.cmbOrigenBaseImponible.TabIndex = 7
      '
      'lblCodigoAfip
      '
      Me.lblCodigoAfip.AutoSize = True
      Me.lblCodigoAfip.LabelAsoc = Nothing
      Me.lblCodigoAfip.Location = New System.Drawing.Point(174, 25)
      Me.lblCodigoAfip.Name = "lblCodigoAfip"
      Me.lblCodigoAfip.Size = New System.Drawing.Size(66, 13)
      Me.lblCodigoAfip.TabIndex = 2
      Me.lblCodigoAfip.Text = "Código AFIP"
      '
      'txtCodigoAfip
      '
      Me.txtCodigoAfip.BindearPropiedadControl = "Text"
      Me.txtCodigoAfip.BindearPropiedadEntidad = "CodigoAfip"
      Me.txtCodigoAfip.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigoAfip.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigoAfip.Formato = ""
      Me.txtCodigoAfip.IsDecimal = False
      Me.txtCodigoAfip.IsNumber = True
      Me.txtCodigoAfip.IsPK = False
      Me.txtCodigoAfip.IsRequired = True
      Me.txtCodigoAfip.Key = ""
      Me.txtCodigoAfip.LabelAsoc = Me.lblCodigoAfip
      Me.txtCodigoAfip.Location = New System.Drawing.Point(241, 22)
      Me.txtCodigoAfip.MaxLength = 10
      Me.txtCodigoAfip.Name = "txtCodigoAfip"
      Me.txtCodigoAfip.Size = New System.Drawing.Size(84, 20)
      Me.txtCodigoAfip.TabIndex = 3
      Me.txtCodigoAfip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'RegimenesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(487, 276)
      Me.Controls.Add(Me.txtCodigoAfip)
      Me.Controls.Add(Me.lblCodigoAfip)
      Me.Controls.Add(Me.lblMinimoNoImponible)
      Me.Controls.Add(Me.txtMinimoNoImponible)
      Me.Controls.Add(Me.chbPasibleRetencion)
      Me.Controls.Add(Me.lblMontoMinNoInscripto)
      Me.Controls.Add(Me.txtMontoMinimoNoInscripto)
      Me.Controls.Add(Me.lblMontoMinInscripto)
      Me.Controls.Add(Me.txtImporteMinimoInscripto)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtMontoExceder)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtRetenerNoIns)
      Me.Controls.Add(Me.lblAlicuota)
      Me.Controls.Add(Me.txtRetenerIns)
      Me.Controls.Add(Me.lblNombreProducto)
      Me.Controls.Add(Me.txtConcepto)
      Me.Controls.Add(Me.lblIdRegimen)
      Me.Controls.Add(Me.txtRegimen)
      Me.Controls.Add(Me.cmbOrigenBaseImponible)
      Me.Controls.Add(Me.lblOrigenBaseImponible)
      Me.Controls.Add(Me.cmbTipoImpuesto)
      Me.Controls.Add(Me.lblIdTipoImpuesto)
      Me.Name = "RegimenesDetalle"
      Me.Text = "Regimen"
      Me.Controls.SetChildIndex(Me.lblIdTipoImpuesto, 0)
      Me.Controls.SetChildIndex(Me.cmbTipoImpuesto, 0)
      Me.Controls.SetChildIndex(Me.lblOrigenBaseImponible, 0)
      Me.Controls.SetChildIndex(Me.cmbOrigenBaseImponible, 0)
      Me.Controls.SetChildIndex(Me.txtRegimen, 0)
      Me.Controls.SetChildIndex(Me.lblIdRegimen, 0)
      Me.Controls.SetChildIndex(Me.txtConcepto, 0)
      Me.Controls.SetChildIndex(Me.lblNombreProducto, 0)
      Me.Controls.SetChildIndex(Me.txtRetenerIns, 0)
      Me.Controls.SetChildIndex(Me.lblAlicuota, 0)
      Me.Controls.SetChildIndex(Me.txtRetenerNoIns, 0)
      Me.Controls.SetChildIndex(Me.Label1, 0)
      Me.Controls.SetChildIndex(Me.txtMontoExceder, 0)
      Me.Controls.SetChildIndex(Me.Label2, 0)
      Me.Controls.SetChildIndex(Me.txtImporteMinimoInscripto, 0)
      Me.Controls.SetChildIndex(Me.lblMontoMinInscripto, 0)
      Me.Controls.SetChildIndex(Me.txtMontoMinimoNoInscripto, 0)
      Me.Controls.SetChildIndex(Me.lblMontoMinNoInscripto, 0)
      Me.Controls.SetChildIndex(Me.chbPasibleRetencion, 0)
      Me.Controls.SetChildIndex(Me.txtMinimoNoImponible, 0)
      Me.Controls.SetChildIndex(Me.lblMinimoNoImponible, 0)
      Me.Controls.SetChildIndex(Me.lblCodigoAfip, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtCodigoAfip, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents cmbTipoImpuesto As Eniac.Controles.ComboBox
   Friend WithEvents lblIdTipoImpuesto As Eniac.Controles.Label
   Friend WithEvents lblNombreProducto As Eniac.Controles.Label
   Friend WithEvents txtConcepto As Eniac.Controles.TextBox
   Friend WithEvents lblIdRegimen As Eniac.Controles.Label
   Friend WithEvents txtRegimen As Eniac.Controles.TextBox
   Friend WithEvents lblAlicuota As Eniac.Controles.Label
   Friend WithEvents txtRetenerIns As Eniac.Controles.TextBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents txtRetenerNoIns As Eniac.Controles.TextBox
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtMontoExceder As Eniac.Controles.TextBox
   Friend WithEvents lblMontoMinInscripto As Eniac.Controles.Label
   Friend WithEvents txtImporteMinimoInscripto As Eniac.Controles.TextBox
   Friend WithEvents lblMontoMinNoInscripto As Eniac.Controles.Label
   Friend WithEvents txtMontoMinimoNoInscripto As Eniac.Controles.TextBox
   Friend WithEvents chbPasibleRetencion As Eniac.Controles.CheckBox
   Friend WithEvents lblMinimoNoImponible As Eniac.Controles.Label
   Friend WithEvents txtMinimoNoImponible As Eniac.Controles.TextBox
   Friend WithEvents lblOrigenBaseImponible As Eniac.Controles.Label
   Friend WithEvents cmbOrigenBaseImponible As Eniac.Controles.ComboBox
   Friend WithEvents lblCodigoAfip As Eniac.Controles.Label
   Friend WithEvents txtCodigoAfip As Eniac.Controles.TextBox
End Class
