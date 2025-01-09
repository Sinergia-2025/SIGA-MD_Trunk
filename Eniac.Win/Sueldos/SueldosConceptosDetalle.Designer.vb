<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosConceptosDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosConceptosDetalle))
      Me.tbpFormula = New System.Windows.Forms.TabPage()
      Me.grbDatosPersonales = New System.Windows.Forms.GroupBox()
      Me.Label14 = New Eniac.Controles.Label()
      Me.Label13 = New Eniac.Controles.Label()
      Me.Label12 = New Eniac.Controles.Label()
      Me.Label11 = New Eniac.Controles.Label()
      Me.Label10 = New Eniac.Controles.Label()
      Me.Label9 = New Eniac.Controles.Label()
      Me.Label8 = New Eniac.Controles.Label()
      Me.Label7 = New Eniac.Controles.Label()
      Me.Label6 = New Eniac.Controles.Label()
      Me.Label5 = New Eniac.Controles.Label()
      Me.Label4 = New Eniac.Controles.Label()
      Me.Label3 = New Eniac.Controles.Label()
      Me.Label2 = New Eniac.Controles.Label()
      Me.Label1 = New Eniac.Controles.Label()
      Me.txtFormula = New Eniac.Controles.TextBox()
      Me.lblFormula = New Eniac.Controles.Label()
      Me.lblNombre = New Eniac.Controles.Label()
      Me.tbpDatos = New System.Windows.Forms.TabPage()
      Me.grbUbicacion = New System.Windows.Forms.GroupBox()
      Me.chbMostrarEnRecibo = New Eniac.Controles.CheckBox()
      Me.lblLiquidacionAnual = New Eniac.Controles.Label()
      Me.Label15 = New Eniac.Controles.Label()
      Me.clbLiquidacionMeses = New System.Windows.Forms.CheckedListBox()
      Me.txtLiquidacionMeses = New Eniac.Controles.TextBox()
      Me.cmbQuePide = New Eniac.Controles.ComboBox()
      Me.lblQuePide = New Eniac.Controles.Label()
      Me.chbLiquidacionAnual = New Eniac.Controles.CheckBox()
      Me.cmbTipoConcepto = New Eniac.Controles.ComboBox()
      Me.lblTipoConcepto = New Eniac.Controles.Label()
      Me.txtValor = New Eniac.Controles.TextBox()
      Me.lblValor = New Eniac.Controles.Label()
      Me.lblLiquidacion = New Eniac.Controles.Label()
      Me.grpModalidad = New System.Windows.Forms.GroupBox()
      Me.RadioModoAguinaldo = New System.Windows.Forms.RadioButton()
      Me.RadioModoNormal = New System.Windows.Forms.RadioButton()
      Me.lblTipoLiquidacion = New Eniac.Controles.Label()
      Me.grpTipoLiquidacion = New System.Windows.Forms.GroupBox()
      Me.RadioTipoPermanente = New System.Windows.Forms.RadioButton()
      Me.radioTipoUnitaria = New System.Windows.Forms.RadioButton()
      Me.tbcDetalle = New System.Windows.Forms.TabControl()
      Me.txtNombre = New Eniac.Controles.TextBox()
      Me.lblId = New Eniac.Controles.Label()
      Me.txtCodigoConcepto = New Eniac.Controles.TextBox()
      Me.ofdArchivos = New System.Windows.Forms.OpenFileDialog()
      Me.chbEsContempladoAguinaldo = New Eniac.Controles.CheckBox()
      Me.tbpFormula.SuspendLayout()
      Me.grbDatosPersonales.SuspendLayout()
      Me.tbpDatos.SuspendLayout()
      Me.grbUbicacion.SuspendLayout()
      Me.grpModalidad.SuspendLayout()
      Me.grpTipoLiquidacion.SuspendLayout()
      Me.tbcDetalle.SuspendLayout()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(358, 440)
      Me.btnAceptar.TabIndex = 5
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(444, 440)
      Me.btnCancelar.TabIndex = 6
      '
      'tbpFormula
      '
      Me.tbpFormula.BackColor = System.Drawing.SystemColors.Control
      Me.tbpFormula.Controls.Add(Me.grbDatosPersonales)
      Me.tbpFormula.Location = New System.Drawing.Point(4, 22)
      Me.tbpFormula.Name = "tbpFormula"
      Me.tbpFormula.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpFormula.Size = New System.Drawing.Size(509, 332)
      Me.tbpFormula.TabIndex = 0
      Me.tbpFormula.Text = "Formula"
      '
      'grbDatosPersonales
      '
      Me.grbDatosPersonales.Controls.Add(Me.Label14)
      Me.grbDatosPersonales.Controls.Add(Me.Label13)
      Me.grbDatosPersonales.Controls.Add(Me.Label12)
      Me.grbDatosPersonales.Controls.Add(Me.Label11)
      Me.grbDatosPersonales.Controls.Add(Me.Label10)
      Me.grbDatosPersonales.Controls.Add(Me.Label9)
      Me.grbDatosPersonales.Controls.Add(Me.Label8)
      Me.grbDatosPersonales.Controls.Add(Me.Label7)
      Me.grbDatosPersonales.Controls.Add(Me.Label6)
      Me.grbDatosPersonales.Controls.Add(Me.Label5)
      Me.grbDatosPersonales.Controls.Add(Me.Label4)
      Me.grbDatosPersonales.Controls.Add(Me.Label3)
      Me.grbDatosPersonales.Controls.Add(Me.Label2)
      Me.grbDatosPersonales.Controls.Add(Me.Label1)
      Me.grbDatosPersonales.Controls.Add(Me.txtFormula)
      Me.grbDatosPersonales.Controls.Add(Me.lblFormula)
      Me.grbDatosPersonales.Location = New System.Drawing.Point(6, 7)
      Me.grbDatosPersonales.Name = "grbDatosPersonales"
      Me.grbDatosPersonales.Size = New System.Drawing.Size(496, 268)
      Me.grbDatosPersonales.TabIndex = 0
      Me.grbDatosPersonales.TabStop = False
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(237, 230)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(207, 13)
      Me.Label14.TabIndex = 55
      Me.Label14.Text = "RETEAGUIN, total retencion de aguinaldo"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Location = New System.Drawing.Point(237, 211)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(172, 13)
      Me.Label13.TabIndex = 54
      Me.Label13.Text = "SFAMILIAR, total de salario familiar"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(237, 192)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(143, 13)
      Me.Label12.TabIndex = 53
      Me.Label12.Text = "ANTICIPO, total de anticipos"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(237, 173)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(169, 13)
      Me.Label11.TabIndex = 52
      Me.Label11.Text = "RETENCION, total de retenciones"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(237, 154)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(140, 13)
      Me.Label10.TabIndex = 51
      Me.Label10.Text = "HABERES, total de haberes"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(6, 249)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(204, 13)
      Me.Label9.TabIndex = 50
      Me.Label9.Text = "ANTIGUEDAD, antiguedad del empreado"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(6, 230)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(201, 13)
      Me.Label8.TabIndex = 49
      Me.Label8.Text = "HABEAGUIN, total haberes de aguinaldo"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(6, 211)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(131, 13)
      Me.Label7.TabIndex = 48
      Me.Label7.Text = "MEJORSUE, mejor sueldo"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(6, 192)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(138, 13)
      Me.Label6.TabIndex = 47
      Me.Label6.Text = "LIQVALOR, valor por legajo"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(6, 173)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(133, 13)
      Me.Label5.TabIndex = 46
      Me.Label5.Text = "CODVALOR, valor general"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(6, 154)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(117, 13)
      Me.Label4.TabIndex = 45
      Me.Label4.Text = "BASICO, sueldo básico"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(237, 135)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(153, 13)
      Me.Label3.TabIndex = 44
      Me.Label3.Text = "Operadores de cálculo () + - / *"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 135)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(91, 13)
      Me.Label2.TabIndex = 43
      Me.Label2.Text = "Números (999.99)"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(6, 109)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(255, 13)
      Me.Label1.TabIndex = 42
      Me.Label1.Text = "Valores permitidos para escribir la fórmula de cálculo:"
      '
      'txtFormula
      '
      Me.txtFormula.BindearPropiedadControl = "Text"
      Me.txtFormula.BindearPropiedadEntidad = "Formula"
      Me.txtFormula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtFormula.ForeColorFocus = System.Drawing.Color.Red
      Me.txtFormula.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtFormula.Formato = ""
      Me.txtFormula.IsDecimal = False
      Me.txtFormula.IsNumber = False
      Me.txtFormula.IsPK = False
      Me.txtFormula.IsRequired = True
      Me.txtFormula.Key = ""
      Me.txtFormula.LabelAsoc = Me.lblFormula
      Me.txtFormula.Location = New System.Drawing.Point(9, 38)
      Me.txtFormula.MaxLength = 60
      Me.txtFormula.Multiline = True
      Me.txtFormula.Name = "txtFormula"
      Me.txtFormula.Size = New System.Drawing.Size(473, 58)
      Me.txtFormula.TabIndex = 41
      '
      'lblFormula
      '
      Me.lblFormula.AutoSize = True
      Me.lblFormula.Location = New System.Drawing.Point(6, 17)
      Me.lblFormula.Name = "lblFormula"
      Me.lblFormula.Size = New System.Drawing.Size(97, 13)
      Me.lblFormula.TabIndex = 40
      Me.lblFormula.Text = "Formula de Cálculo"
      '
      'lblNombre
      '
      Me.lblNombre.AutoSize = True
      Me.lblNombre.Location = New System.Drawing.Point(29, 44)
      Me.lblNombre.Name = "lblNombre"
      Me.lblNombre.Size = New System.Drawing.Size(44, 13)
      Me.lblNombre.TabIndex = 2
      Me.lblNombre.Text = "Nombre"
      '
      'tbpDatos
      '
      Me.tbpDatos.BackColor = System.Drawing.SystemColors.Control
      Me.tbpDatos.Controls.Add(Me.grbUbicacion)
      Me.tbpDatos.Location = New System.Drawing.Point(4, 22)
      Me.tbpDatos.Name = "tbpDatos"
      Me.tbpDatos.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpDatos.Size = New System.Drawing.Size(509, 332)
      Me.tbpDatos.TabIndex = 1
      Me.tbpDatos.Text = "Detalle"
      '
      'grbUbicacion
      '
      Me.grbUbicacion.Controls.Add(Me.chbEsContempladoAguinaldo)
      Me.grbUbicacion.Controls.Add(Me.chbMostrarEnRecibo)
      Me.grbUbicacion.Controls.Add(Me.Label15)
      Me.grbUbicacion.Controls.Add(Me.clbLiquidacionMeses)
      Me.grbUbicacion.Controls.Add(Me.lblLiquidacionAnual)
      Me.grbUbicacion.Controls.Add(Me.txtLiquidacionMeses)
      Me.grbUbicacion.Controls.Add(Me.cmbQuePide)
      Me.grbUbicacion.Controls.Add(Me.chbLiquidacionAnual)
      Me.grbUbicacion.Controls.Add(Me.cmbTipoConcepto)
      Me.grbUbicacion.Controls.Add(Me.txtValor)
      Me.grbUbicacion.Controls.Add(Me.lblValor)
      Me.grbUbicacion.Controls.Add(Me.lblLiquidacion)
      Me.grbUbicacion.Controls.Add(Me.grpModalidad)
      Me.grbUbicacion.Controls.Add(Me.lblTipoLiquidacion)
      Me.grbUbicacion.Controls.Add(Me.grpTipoLiquidacion)
      Me.grbUbicacion.Controls.Add(Me.lblQuePide)
      Me.grbUbicacion.Controls.Add(Me.lblTipoConcepto)
      Me.grbUbicacion.Location = New System.Drawing.Point(6, 5)
      Me.grbUbicacion.Name = "grbUbicacion"
      Me.grbUbicacion.Size = New System.Drawing.Size(496, 324)
      Me.grbUbicacion.TabIndex = 0
      Me.grbUbicacion.TabStop = False
      '
      'chbMostrarEnRecibo
      '
      Me.chbMostrarEnRecibo.AutoSize = True
      Me.chbMostrarEnRecibo.BindearPropiedadControl = "Checked"
      Me.chbMostrarEnRecibo.BindearPropiedadEntidad = "MostrarEnRecibo"
      Me.chbMostrarEnRecibo.Checked = True
      Me.chbMostrarEnRecibo.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbMostrarEnRecibo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbMostrarEnRecibo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbMostrarEnRecibo.IsPK = False
      Me.chbMostrarEnRecibo.IsRequired = False
      Me.chbMostrarEnRecibo.Key = Nothing
      Me.chbMostrarEnRecibo.LabelAsoc = Me.lblLiquidacionAnual
      Me.chbMostrarEnRecibo.Location = New System.Drawing.Point(304, 143)
      Me.chbMostrarEnRecibo.Name = "chbMostrarEnRecibo"
      Me.chbMostrarEnRecibo.Size = New System.Drawing.Size(113, 17)
      Me.chbMostrarEnRecibo.TabIndex = 15
      Me.chbMostrarEnRecibo.Text = "Mostrar en Recibo"
      Me.chbMostrarEnRecibo.UseVisualStyleBackColor = True
      '
      'lblLiquidacionAnual
      '
      Me.lblLiquidacionAnual.AutoSize = True
      Me.lblLiquidacionAnual.Location = New System.Drawing.Point(11, 185)
      Me.lblLiquidacionAnual.Name = "lblLiquidacionAnual"
      Me.lblLiquidacionAnual.Size = New System.Drawing.Size(91, 13)
      Me.lblLiquidacionAnual.TabIndex = 10
      Me.lblLiquidacionAnual.Text = "Liquidación Anual"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Location = New System.Drawing.Point(337, 185)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(38, 13)
      Me.Label15.TabIndex = 14
      Me.Label15.Text = "Meses"
      '
      'clbLiquidacionMeses
      '
      Me.clbLiquidacionMeses.CheckOnClick = True
      Me.clbLiquidacionMeses.FormattingEnabled = True
      Me.clbLiquidacionMeses.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre"})
      Me.clbLiquidacionMeses.Location = New System.Drawing.Point(239, 204)
      Me.clbLiquidacionMeses.MultiColumn = True
      Me.clbLiquidacionMeses.Name = "clbLiquidacionMeses"
      Me.clbLiquidacionMeses.Size = New System.Drawing.Size(251, 94)
      Me.clbLiquidacionMeses.TabIndex = 13
      Me.clbLiquidacionMeses.Visible = False
      '
      'txtLiquidacionMeses
      '
      Me.txtLiquidacionMeses.BindearPropiedadControl = "Text"
      Me.txtLiquidacionMeses.BindearPropiedadEntidad = "LiquidacionMeses"
      Me.txtLiquidacionMeses.Enabled = False
      Me.txtLiquidacionMeses.ForeColorFocus = System.Drawing.Color.Red
      Me.txtLiquidacionMeses.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtLiquidacionMeses.Formato = ""
      Me.txtLiquidacionMeses.IsDecimal = False
      Me.txtLiquidacionMeses.IsNumber = False
      Me.txtLiquidacionMeses.IsPK = False
      Me.txtLiquidacionMeses.IsRequired = False
      Me.txtLiquidacionMeses.Key = ""
      Me.txtLiquidacionMeses.LabelAsoc = Me.lblLiquidacionAnual
      Me.txtLiquidacionMeses.Location = New System.Drawing.Point(15, 204)
      Me.txtLiquidacionMeses.MaxLength = 12
      Me.txtLiquidacionMeses.Name = "txtLiquidacionMeses"
      Me.txtLiquidacionMeses.Size = New System.Drawing.Size(150, 20)
      Me.txtLiquidacionMeses.TabIndex = 12
      Me.txtLiquidacionMeses.Visible = False
      '
      'cmbQuePide
      '
      Me.cmbQuePide.BindearPropiedadControl = "SelectedValue"
      Me.cmbQuePide.BindearPropiedadEntidad = "IdQuePide"
      Me.cmbQuePide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbQuePide.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbQuePide.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbQuePide.FormattingEnabled = True
      Me.cmbQuePide.IsPK = False
      Me.cmbQuePide.IsRequired = True
      Me.cmbQuePide.Key = Nothing
      Me.cmbQuePide.LabelAsoc = Me.lblQuePide
      Me.cmbQuePide.Location = New System.Drawing.Point(114, 52)
      Me.cmbQuePide.Name = "cmbQuePide"
      Me.cmbQuePide.Size = New System.Drawing.Size(133, 21)
      Me.cmbQuePide.TabIndex = 3
      '
      'lblQuePide
      '
      Me.lblQuePide.AutoSize = True
      Me.lblQuePide.Location = New System.Drawing.Point(11, 60)
      Me.lblQuePide.Name = "lblQuePide"
      Me.lblQuePide.Size = New System.Drawing.Size(51, 13)
      Me.lblQuePide.TabIndex = 2
      Me.lblQuePide.Text = "Que Pide"
      '
      'chbLiquidacionAnual
      '
      Me.chbLiquidacionAnual.AutoSize = True
      Me.chbLiquidacionAnual.BindearPropiedadControl = "Checked"
      Me.chbLiquidacionAnual.BindearPropiedadEntidad = "LiquidacionAnual"
      Me.chbLiquidacionAnual.Checked = True
      Me.chbLiquidacionAnual.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbLiquidacionAnual.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLiquidacionAnual.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLiquidacionAnual.IsPK = False
      Me.chbLiquidacionAnual.IsRequired = False
      Me.chbLiquidacionAnual.Key = Nothing
      Me.chbLiquidacionAnual.LabelAsoc = Me.lblLiquidacionAnual
      Me.chbLiquidacionAnual.Location = New System.Drawing.Point(114, 184)
      Me.chbLiquidacionAnual.Name = "chbLiquidacionAnual"
      Me.chbLiquidacionAnual.Size = New System.Drawing.Size(15, 14)
      Me.chbLiquidacionAnual.TabIndex = 11
      Me.chbLiquidacionAnual.UseVisualStyleBackColor = True
      '
      'cmbTipoConcepto
      '
      Me.cmbTipoConcepto.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoConcepto.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.cmbTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoConcepto.FormattingEnabled = True
      Me.cmbTipoConcepto.IsPK = False
      Me.cmbTipoConcepto.IsRequired = True
      Me.cmbTipoConcepto.Key = Nothing
      Me.cmbTipoConcepto.LabelAsoc = Me.lblTipoConcepto
      Me.cmbTipoConcepto.Location = New System.Drawing.Point(114, 18)
      Me.cmbTipoConcepto.Name = "cmbTipoConcepto"
      Me.cmbTipoConcepto.Size = New System.Drawing.Size(194, 21)
      Me.cmbTipoConcepto.TabIndex = 1
      '
      'lblTipoConcepto
      '
      Me.lblTipoConcepto.AutoSize = True
      Me.lblTipoConcepto.Location = New System.Drawing.Point(11, 26)
      Me.lblTipoConcepto.Name = "lblTipoConcepto"
      Me.lblTipoConcepto.Size = New System.Drawing.Size(77, 13)
      Me.lblTipoConcepto.TabIndex = 0
      Me.lblTipoConcepto.Text = "Tipo Concepto"
      '
      'txtValor
      '
      Me.txtValor.BindearPropiedadControl = "Text"
      Me.txtValor.BindearPropiedadEntidad = "Valor"
      Me.txtValor.ForeColorFocus = System.Drawing.Color.Red
      Me.txtValor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtValor.Formato = "#0.000"
      Me.txtValor.IsDecimal = True
      Me.txtValor.IsNumber = True
      Me.txtValor.IsPK = False
      Me.txtValor.IsRequired = False
      Me.txtValor.Key = ""
      Me.txtValor.LabelAsoc = Me.lblValor
      Me.txtValor.Location = New System.Drawing.Point(299, 52)
      Me.txtValor.MaxLength = 7
      Me.txtValor.Name = "txtValor"
      Me.txtValor.Size = New System.Drawing.Size(92, 20)
      Me.txtValor.TabIndex = 5
      Me.txtValor.Text = "0.00"
      Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblValor
      '
      Me.lblValor.AutoSize = True
      Me.lblValor.Location = New System.Drawing.Point(262, 56)
      Me.lblValor.Name = "lblValor"
      Me.lblValor.Size = New System.Drawing.Size(31, 13)
      Me.lblValor.TabIndex = 4
      Me.lblValor.Text = "Valor"
      '
      'lblLiquidacion
      '
      Me.lblLiquidacion.AutoSize = True
      Me.lblLiquidacion.Location = New System.Drawing.Point(12, 148)
      Me.lblLiquidacion.Name = "lblLiquidacion"
      Me.lblLiquidacion.Size = New System.Drawing.Size(34, 13)
      Me.lblLiquidacion.TabIndex = 8
      Me.lblLiquidacion.Text = "Modo"
      '
      'grpModalidad
      '
      Me.grpModalidad.Controls.Add(Me.RadioModoAguinaldo)
      Me.grpModalidad.Controls.Add(Me.RadioModoNormal)
      Me.grpModalidad.Location = New System.Drawing.Point(115, 134)
      Me.grpModalidad.Name = "grpModalidad"
      Me.grpModalidad.Size = New System.Drawing.Size(175, 31)
      Me.grpModalidad.TabIndex = 9
      Me.grpModalidad.TabStop = False
      '
      'RadioModoAguinaldo
      '
      Me.RadioModoAguinaldo.AutoSize = True
      Me.RadioModoAguinaldo.Location = New System.Drawing.Point(96, 9)
      Me.RadioModoAguinaldo.Name = "RadioModoAguinaldo"
      Me.RadioModoAguinaldo.Size = New System.Drawing.Size(72, 17)
      Me.RadioModoAguinaldo.TabIndex = 1
      Me.RadioModoAguinaldo.Text = "Aguinaldo"
      Me.RadioModoAguinaldo.UseVisualStyleBackColor = True
      '
      'RadioModoNormal
      '
      Me.RadioModoNormal.AutoSize = True
      Me.RadioModoNormal.Checked = True
      Me.RadioModoNormal.Location = New System.Drawing.Point(8, 10)
      Me.RadioModoNormal.Name = "RadioModoNormal"
      Me.RadioModoNormal.Size = New System.Drawing.Size(58, 17)
      Me.RadioModoNormal.TabIndex = 0
      Me.RadioModoNormal.TabStop = True
      Me.RadioModoNormal.Text = "Normal"
      Me.RadioModoNormal.UseVisualStyleBackColor = True
      '
      'lblTipoLiquidacion
      '
      Me.lblTipoLiquidacion.AutoSize = True
      Me.lblTipoLiquidacion.Location = New System.Drawing.Point(11, 105)
      Me.lblTipoLiquidacion.Name = "lblTipoLiquidacion"
      Me.lblTipoLiquidacion.Size = New System.Drawing.Size(100, 13)
      Me.lblTipoLiquidacion.TabIndex = 6
      Me.lblTipoLiquidacion.Text = "Tipo de Liquidacion"
      '
      'grpTipoLiquidacion
      '
      Me.grpTipoLiquidacion.Controls.Add(Me.RadioTipoPermanente)
      Me.grpTipoLiquidacion.Controls.Add(Me.radioTipoUnitaria)
      Me.grpTipoLiquidacion.Location = New System.Drawing.Point(114, 94)
      Me.grpTipoLiquidacion.Name = "grpTipoLiquidacion"
      Me.grpTipoLiquidacion.Size = New System.Drawing.Size(177, 31)
      Me.grpTipoLiquidacion.TabIndex = 7
      Me.grpTipoLiquidacion.TabStop = False
      '
      'RadioTipoPermanente
      '
      Me.RadioTipoPermanente.AutoSize = True
      Me.RadioTipoPermanente.Checked = True
      Me.RadioTipoPermanente.Location = New System.Drawing.Point(7, 9)
      Me.RadioTipoPermanente.Name = "RadioTipoPermanente"
      Me.RadioTipoPermanente.Size = New System.Drawing.Size(82, 17)
      Me.RadioTipoPermanente.TabIndex = 1
      Me.RadioTipoPermanente.TabStop = True
      Me.RadioTipoPermanente.Text = "Permanente"
      Me.RadioTipoPermanente.UseVisualStyleBackColor = True
      '
      'radioTipoUnitaria
      '
      Me.radioTipoUnitaria.AutoSize = True
      Me.radioTipoUnitaria.Location = New System.Drawing.Point(95, 9)
      Me.radioTipoUnitaria.Name = "radioTipoUnitaria"
      Me.radioTipoUnitaria.Size = New System.Drawing.Size(61, 17)
      Me.radioTipoUnitaria.TabIndex = 0
      Me.radioTipoUnitaria.Text = "Unitaria"
      Me.radioTipoUnitaria.UseVisualStyleBackColor = True
      '
      'tbcDetalle
      '
      Me.tbcDetalle.Controls.Add(Me.tbpDatos)
      Me.tbcDetalle.Controls.Add(Me.tbpFormula)
      Me.tbcDetalle.Location = New System.Drawing.Point(8, 75)
      Me.tbcDetalle.Name = "tbcDetalle"
      Me.tbcDetalle.SelectedIndex = 0
      Me.tbcDetalle.Size = New System.Drawing.Size(517, 358)
      Me.tbcDetalle.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
      Me.tbcDetalle.TabIndex = 4
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
      Me.txtNombre.Location = New System.Drawing.Point(79, 37)
      Me.txtNombre.MaxLength = 30
      Me.txtNombre.Name = "txtNombre"
      Me.txtNombre.Size = New System.Drawing.Size(435, 20)
      Me.txtNombre.TabIndex = 3
      '
      'lblId
      '
      Me.lblId.AutoSize = True
      Me.lblId.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblId.Location = New System.Drawing.Point(31, 14)
      Me.lblId.Name = "lblId"
      Me.lblId.Size = New System.Drawing.Size(40, 13)
      Me.lblId.TabIndex = 0
      Me.lblId.Text = "Código"
      '
      'txtCodigoConcepto
      '
      Me.txtCodigoConcepto.BindearPropiedadControl = "Text"
      Me.txtCodigoConcepto.BindearPropiedadEntidad = "CodigoConcepto"
      Me.txtCodigoConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtCodigoConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtCodigoConcepto.Formato = ""
      Me.txtCodigoConcepto.IsDecimal = False
      Me.txtCodigoConcepto.IsNumber = True
      Me.txtCodigoConcepto.IsPK = False
      Me.txtCodigoConcepto.IsRequired = True
      Me.txtCodigoConcepto.Key = ""
      Me.txtCodigoConcepto.LabelAsoc = Me.lblId
      Me.txtCodigoConcepto.Location = New System.Drawing.Point(79, 11)
      Me.txtCodigoConcepto.MaxLength = 5
      Me.txtCodigoConcepto.Name = "txtCodigoConcepto"
      Me.txtCodigoConcepto.Size = New System.Drawing.Size(88, 20)
      Me.txtCodigoConcepto.TabIndex = 1
      '
      'ofdArchivos
      '
      Me.ofdArchivos.Filter = "jpg files|*.jpg"
      '
      'chbEsContempladoAguinaldo
      '
      Me.chbEsContempladoAguinaldo.AutoSize = True
      Me.chbEsContempladoAguinaldo.BindearPropiedadControl = "Checked"
      Me.chbEsContempladoAguinaldo.BindearPropiedadEntidad = "EsContempladoAguinaldo"
      Me.chbEsContempladoAguinaldo.Checked = True
      Me.chbEsContempladoAguinaldo.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chbEsContempladoAguinaldo.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEsContempladoAguinaldo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEsContempladoAguinaldo.IsPK = False
      Me.chbEsContempladoAguinaldo.IsRequired = False
      Me.chbEsContempladoAguinaldo.Key = Nothing
      Me.chbEsContempladoAguinaldo.LabelAsoc = Me.lblLiquidacionAnual
      Me.chbEsContempladoAguinaldo.Location = New System.Drawing.Point(304, 103)
      Me.chbEsContempladoAguinaldo.Name = "chbEsContempladoAguinaldo"
      Me.chbEsContempladoAguinaldo.Size = New System.Drawing.Size(177, 17)
      Me.chbEsContempladoAguinaldo.TabIndex = 16
      Me.chbEsContempladoAguinaldo.Text = "Es Contemplado para Aguinaldo"
      Me.chbEsContempladoAguinaldo.UseVisualStyleBackColor = True
      '
      'SueldosConceptosDetalle
      '
      Me.AcceptButton = Nothing
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(533, 479)
      Me.Controls.Add(Me.lblNombre)
      Me.Controls.Add(Me.txtNombre)
      Me.Controls.Add(Me.lblId)
      Me.Controls.Add(Me.txtCodigoConcepto)
      Me.Controls.Add(Me.tbcDetalle)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "SueldosConceptosDetalle"
      Me.Text = "Concepto"
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.tbcDetalle, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.txtCodigoConcepto, 0)
      Me.Controls.SetChildIndex(Me.lblId, 0)
      Me.Controls.SetChildIndex(Me.txtNombre, 0)
      Me.Controls.SetChildIndex(Me.lblNombre, 0)
      Me.tbpFormula.ResumeLayout(False)
      Me.grbDatosPersonales.ResumeLayout(False)
      Me.grbDatosPersonales.PerformLayout()
      Me.tbpDatos.ResumeLayout(False)
      Me.grbUbicacion.ResumeLayout(False)
      Me.grbUbicacion.PerformLayout()
      Me.grpModalidad.ResumeLayout(False)
      Me.grpModalidad.PerformLayout()
      Me.grpTipoLiquidacion.ResumeLayout(False)
      Me.grpTipoLiquidacion.PerformLayout()
      Me.tbcDetalle.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents tbpFormula As System.Windows.Forms.TabPage
   Friend WithEvents grbDatosPersonales As System.Windows.Forms.GroupBox
   Friend WithEvents lblFormula As Eniac.Controles.Label
   Friend WithEvents tbpDatos As System.Windows.Forms.TabPage
   Friend WithEvents grbUbicacion As System.Windows.Forms.GroupBox
   Friend WithEvents lblTipoConcepto As Eniac.Controles.Label
   Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
   Friend WithEvents lblNombre As Eniac.Controles.Label
   Friend WithEvents txtNombre As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents txtCodigoConcepto As Eniac.Controles.TextBox
   Friend WithEvents ofdArchivos As System.Windows.Forms.OpenFileDialog
   Friend WithEvents lblQuePide As Eniac.Controles.Label
   Friend WithEvents grpTipoLiquidacion As System.Windows.Forms.GroupBox
   Friend WithEvents RadioTipoPermanente As System.Windows.Forms.RadioButton
   Friend WithEvents radioTipoUnitaria As System.Windows.Forms.RadioButton
   Friend WithEvents lblLiquidacion As Eniac.Controles.Label
   Friend WithEvents grpModalidad As System.Windows.Forms.GroupBox
   Friend WithEvents RadioModoAguinaldo As System.Windows.Forms.RadioButton
   Friend WithEvents RadioModoNormal As System.Windows.Forms.RadioButton
   Friend WithEvents lblTipoLiquidacion As Eniac.Controles.Label
   Friend WithEvents lblValor As Eniac.Controles.Label
   Friend WithEvents txtValor As Eniac.Controles.TextBox
   Friend WithEvents txtFormula As Eniac.Controles.TextBox
   Friend WithEvents cmbTipoConcepto As Eniac.Controles.ComboBox
   Friend WithEvents chbLiquidacionAnual As Eniac.Controles.CheckBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents Label14 As Eniac.Controles.Label
   Friend WithEvents Label13 As Eniac.Controles.Label
   Friend WithEvents Label12 As Eniac.Controles.Label
   Friend WithEvents Label11 As Eniac.Controles.Label
   Friend WithEvents Label10 As Eniac.Controles.Label
   Friend WithEvents Label9 As Eniac.Controles.Label
   Friend WithEvents Label8 As Eniac.Controles.Label
   Friend WithEvents Label7 As Eniac.Controles.Label
   Friend WithEvents Label6 As Eniac.Controles.Label
   Friend WithEvents Label5 As Eniac.Controles.Label
   Friend WithEvents cmbQuePide As Eniac.Controles.ComboBox
   Friend WithEvents lblLiquidacionAnual As Eniac.Controles.Label
   Friend WithEvents txtLiquidacionMeses As Eniac.Controles.TextBox
   Friend WithEvents Label15 As Eniac.Controles.Label
   Friend WithEvents clbLiquidacionMeses As System.Windows.Forms.CheckedListBox
   Friend WithEvents chbMostrarEnRecibo As Eniac.Controles.CheckBox
   Friend WithEvents chbEsContempladoAguinaldo As Eniac.Controles.CheckBox

End Class
