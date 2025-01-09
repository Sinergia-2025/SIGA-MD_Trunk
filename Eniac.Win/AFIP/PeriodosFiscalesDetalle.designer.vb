<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PeriodosFiscalesDetalle
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PeriodosFiscalesDetalle))
      Me.lblPeriodoFiscal = New Eniac.Controles.Label()
      Me.dtpPeriodo = New Eniac.Controles.DateTimePicker()
      Me.txtTotalNetoVentas = New Eniac.Controles.TextBox()
      Me.lblTotalNetoVentas = New Eniac.Controles.Label()
      Me.lblVentas = New Eniac.Controles.Label()
      Me.lblTotalImpuestosVentas = New Eniac.Controles.Label()
      Me.txtTotalImpuestosVentas = New Eniac.Controles.TextBox()
      Me.lblTotalVentas = New Eniac.Controles.Label()
      Me.txtTotalVentas = New Eniac.Controles.TextBox()
      Me.txtTotalCompras = New Eniac.Controles.TextBox()
      Me.txtTotalImpuestosCompras = New Eniac.Controles.TextBox()
      Me.txtTotalNetoCompras = New Eniac.Controles.TextBox()
      Me.lblCompras = New Eniac.Controles.Label()
      Me.txtPosicion = New Eniac.Controles.TextBox()
      Me.lblPosicion = New Eniac.Controles.Label()
      Me.dtpFechaCierre = New Eniac.Controles.DateTimePicker()
      Me.chbCierre = New Eniac.Controles.CheckBox()
      Me.txtUsuarioCierre = New Eniac.Controles.TextBox()
      Me.txtPosicionFinal = New Eniac.Controles.TextBox()
      Me.lblPosicionFinal = New Eniac.Controles.Label()
      Me.txtTotalRetenciones = New Eniac.Controles.TextBox()
      Me.lblRetenciones = New Eniac.Controles.Label()
      Me.txtTotalPercepciones = New Eniac.Controles.TextBox()
      Me.lblPercepciones = New Eniac.Controles.Label()
      Me.chbVentasHabilitadas = New Eniac.Controles.CheckBox()
      Me.SuspendLayout()
      '
      'btnAceptar
      '
      Me.btnAceptar.Location = New System.Drawing.Point(166, 277)
      Me.btnAceptar.TabIndex = 25
      '
      'btnCancelar
      '
      Me.btnCancelar.Location = New System.Drawing.Point(250, 277)
      Me.btnCancelar.TabIndex = 26
      '
      'btnCopiar
      '
      Me.btnCopiar.Location = New System.Drawing.Point(60, 277)
      '
      'btnAplicar
      '
      Me.btnAplicar.Location = New System.Drawing.Point(1, 277)
      '
      'lblPeriodoFiscal
      '
      Me.lblPeriodoFiscal.AutoSize = True
      Me.lblPeriodoFiscal.LabelAsoc = Nothing
      Me.lblPeriodoFiscal.Location = New System.Drawing.Point(12, 15)
      Me.lblPeriodoFiscal.Name = "lblPeriodoFiscal"
      Me.lblPeriodoFiscal.Size = New System.Drawing.Size(43, 13)
      Me.lblPeriodoFiscal.TabIndex = 0
      Me.lblPeriodoFiscal.Text = "Periodo"
      '
      'dtpPeriodo
      '
      Me.dtpPeriodo.BindearPropiedadControl = ""
      Me.dtpPeriodo.BindearPropiedadEntidad = ""
      Me.dtpPeriodo.CustomFormat = "yyyy/MM"
      Me.dtpPeriodo.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpPeriodo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpPeriodo.IsPK = True
      Me.dtpPeriodo.IsRequired = False
      Me.dtpPeriodo.Key = ""
      Me.dtpPeriodo.LabelAsoc = Me.lblPeriodoFiscal
      Me.dtpPeriodo.Location = New System.Drawing.Point(80, 11)
      Me.dtpPeriodo.Name = "dtpPeriodo"
      Me.dtpPeriodo.Size = New System.Drawing.Size(73, 20)
      Me.dtpPeriodo.TabIndex = 1
      '
      'txtTotalNetoVentas
      '
      Me.txtTotalNetoVentas.BindearPropiedadControl = "Text"
      Me.txtTotalNetoVentas.BindearPropiedadEntidad = "TotalNetoVentas"
      Me.txtTotalNetoVentas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalNetoVentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalNetoVentas.Formato = "##,##0.00"
      Me.txtTotalNetoVentas.IsDecimal = True
      Me.txtTotalNetoVentas.IsNumber = True
      Me.txtTotalNetoVentas.IsPK = False
      Me.txtTotalNetoVentas.IsRequired = False
      Me.txtTotalNetoVentas.Key = ""
      Me.txtTotalNetoVentas.LabelAsoc = Me.lblTotalNetoVentas
      Me.txtTotalNetoVentas.Location = New System.Drawing.Point(80, 59)
      Me.txtTotalNetoVentas.MaxLength = 8
      Me.txtTotalNetoVentas.Name = "txtTotalNetoVentas"
      Me.txtTotalNetoVentas.ReadOnly = True
      Me.txtTotalNetoVentas.Size = New System.Drawing.Size(72, 20)
      Me.txtTotalNetoVentas.TabIndex = 6
      Me.txtTotalNetoVentas.Text = "0.00"
      Me.txtTotalNetoVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalNetoVentas
      '
      Me.lblTotalNetoVentas.AutoSize = True
      Me.lblTotalNetoVentas.LabelAsoc = Nothing
      Me.lblTotalNetoVentas.Location = New System.Drawing.Point(122, 42)
      Me.lblTotalNetoVentas.Name = "lblTotalNetoVentas"
      Me.lblTotalNetoVentas.Size = New System.Drawing.Size(30, 13)
      Me.lblTotalNetoVentas.TabIndex = 2
      Me.lblTotalNetoVentas.Text = "Neto"
      '
      'lblVentas
      '
      Me.lblVentas.AutoSize = True
      Me.lblVentas.LabelAsoc = Nothing
      Me.lblVentas.Location = New System.Drawing.Point(12, 63)
      Me.lblVentas.Name = "lblVentas"
      Me.lblVentas.Size = New System.Drawing.Size(40, 13)
      Me.lblVentas.TabIndex = 5
      Me.lblVentas.Text = "Ventas"
      '
      'lblTotalImpuestosVentas
      '
      Me.lblTotalImpuestosVentas.AutoSize = True
      Me.lblTotalImpuestosVentas.LabelAsoc = Nothing
      Me.lblTotalImpuestosVentas.Location = New System.Drawing.Point(200, 42)
      Me.lblTotalImpuestosVentas.Name = "lblTotalImpuestosVentas"
      Me.lblTotalImpuestosVentas.Size = New System.Drawing.Size(24, 13)
      Me.lblTotalImpuestosVentas.TabIndex = 3
      Me.lblTotalImpuestosVentas.Text = "IVA"
      '
      'txtTotalImpuestosVentas
      '
      Me.txtTotalImpuestosVentas.BindearPropiedadControl = "Text"
      Me.txtTotalImpuestosVentas.BindearPropiedadEntidad = "TotalImpuestosVentas"
      Me.txtTotalImpuestosVentas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalImpuestosVentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalImpuestosVentas.Formato = "##,##0.00"
      Me.txtTotalImpuestosVentas.IsDecimal = True
      Me.txtTotalImpuestosVentas.IsNumber = True
      Me.txtTotalImpuestosVentas.IsPK = False
      Me.txtTotalImpuestosVentas.IsRequired = False
      Me.txtTotalImpuestosVentas.Key = ""
      Me.txtTotalImpuestosVentas.LabelAsoc = Me.lblTotalImpuestosVentas
      Me.txtTotalImpuestosVentas.Location = New System.Drawing.Point(158, 59)
      Me.txtTotalImpuestosVentas.MaxLength = 8
      Me.txtTotalImpuestosVentas.Name = "txtTotalImpuestosVentas"
      Me.txtTotalImpuestosVentas.ReadOnly = True
      Me.txtTotalImpuestosVentas.Size = New System.Drawing.Size(72, 20)
      Me.txtTotalImpuestosVentas.TabIndex = 7
      Me.txtTotalImpuestosVentas.Text = "0.00"
      Me.txtTotalImpuestosVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalVentas
      '
      Me.lblTotalVentas.AutoSize = True
      Me.lblTotalVentas.LabelAsoc = Nothing
      Me.lblTotalVentas.Location = New System.Drawing.Point(277, 42)
      Me.lblTotalVentas.Name = "lblTotalVentas"
      Me.lblTotalVentas.Size = New System.Drawing.Size(31, 13)
      Me.lblTotalVentas.TabIndex = 4
      Me.lblTotalVentas.Text = "Total"
      '
      'txtTotalVentas
      '
      Me.txtTotalVentas.BindearPropiedadControl = "Text"
      Me.txtTotalVentas.BindearPropiedadEntidad = "TotalVentas"
      Me.txtTotalVentas.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalVentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalVentas.Formato = "##,##0.00"
      Me.txtTotalVentas.IsDecimal = True
      Me.txtTotalVentas.IsNumber = True
      Me.txtTotalVentas.IsPK = False
      Me.txtTotalVentas.IsRequired = False
      Me.txtTotalVentas.Key = ""
      Me.txtTotalVentas.LabelAsoc = Me.lblTotalVentas
      Me.txtTotalVentas.Location = New System.Drawing.Point(235, 59)
      Me.txtTotalVentas.MaxLength = 8
      Me.txtTotalVentas.Name = "txtTotalVentas"
      Me.txtTotalVentas.ReadOnly = True
      Me.txtTotalVentas.Size = New System.Drawing.Size(72, 20)
      Me.txtTotalVentas.TabIndex = 8
      Me.txtTotalVentas.Text = "0.00"
      Me.txtTotalVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalCompras
      '
      Me.txtTotalCompras.BindearPropiedadControl = "Text"
      Me.txtTotalCompras.BindearPropiedadEntidad = "TotalCompras"
      Me.txtTotalCompras.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalCompras.Formato = "##,##0.00"
      Me.txtTotalCompras.IsDecimal = True
      Me.txtTotalCompras.IsNumber = True
      Me.txtTotalCompras.IsPK = False
      Me.txtTotalCompras.IsRequired = False
      Me.txtTotalCompras.Key = ""
      Me.txtTotalCompras.LabelAsoc = Me.lblTotalVentas
      Me.txtTotalCompras.Location = New System.Drawing.Point(235, 85)
      Me.txtTotalCompras.MaxLength = 8
      Me.txtTotalCompras.Name = "txtTotalCompras"
      Me.txtTotalCompras.ReadOnly = True
      Me.txtTotalCompras.Size = New System.Drawing.Size(72, 20)
      Me.txtTotalCompras.TabIndex = 12
      Me.txtTotalCompras.Text = "0.00"
      Me.txtTotalCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalImpuestosCompras
      '
      Me.txtTotalImpuestosCompras.BindearPropiedadControl = "Text"
      Me.txtTotalImpuestosCompras.BindearPropiedadEntidad = "TotalImpuestosCompras"
      Me.txtTotalImpuestosCompras.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalImpuestosCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalImpuestosCompras.Formato = "##,##0.00"
      Me.txtTotalImpuestosCompras.IsDecimal = True
      Me.txtTotalImpuestosCompras.IsNumber = True
      Me.txtTotalImpuestosCompras.IsPK = False
      Me.txtTotalImpuestosCompras.IsRequired = False
      Me.txtTotalImpuestosCompras.Key = ""
      Me.txtTotalImpuestosCompras.LabelAsoc = Me.lblTotalImpuestosVentas
      Me.txtTotalImpuestosCompras.Location = New System.Drawing.Point(158, 85)
      Me.txtTotalImpuestosCompras.MaxLength = 8
      Me.txtTotalImpuestosCompras.Name = "txtTotalImpuestosCompras"
      Me.txtTotalImpuestosCompras.ReadOnly = True
      Me.txtTotalImpuestosCompras.Size = New System.Drawing.Size(72, 20)
      Me.txtTotalImpuestosCompras.TabIndex = 11
      Me.txtTotalImpuestosCompras.Text = "0.00"
      Me.txtTotalImpuestosCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotalNetoCompras
      '
      Me.txtTotalNetoCompras.BindearPropiedadControl = "Text"
      Me.txtTotalNetoCompras.BindearPropiedadEntidad = "TotalNetoCompras"
      Me.txtTotalNetoCompras.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalNetoCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalNetoCompras.Formato = "##,##0.00"
      Me.txtTotalNetoCompras.IsDecimal = True
      Me.txtTotalNetoCompras.IsNumber = True
      Me.txtTotalNetoCompras.IsPK = False
      Me.txtTotalNetoCompras.IsRequired = False
      Me.txtTotalNetoCompras.Key = ""
      Me.txtTotalNetoCompras.LabelAsoc = Me.lblTotalNetoVentas
      Me.txtTotalNetoCompras.Location = New System.Drawing.Point(80, 85)
      Me.txtTotalNetoCompras.MaxLength = 8
      Me.txtTotalNetoCompras.Name = "txtTotalNetoCompras"
      Me.txtTotalNetoCompras.ReadOnly = True
      Me.txtTotalNetoCompras.Size = New System.Drawing.Size(72, 20)
      Me.txtTotalNetoCompras.TabIndex = 10
      Me.txtTotalNetoCompras.Text = "0.00"
      Me.txtTotalNetoCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblCompras
      '
      Me.lblCompras.AutoSize = True
      Me.lblCompras.LabelAsoc = Nothing
      Me.lblCompras.Location = New System.Drawing.Point(12, 89)
      Me.lblCompras.Name = "lblCompras"
      Me.lblCompras.Size = New System.Drawing.Size(48, 13)
      Me.lblCompras.TabIndex = 9
      Me.lblCompras.Text = "Compras"
      '
      'txtPosicion
      '
      Me.txtPosicion.BindearPropiedadControl = "Text"
      Me.txtPosicion.BindearPropiedadEntidad = "Posicion"
      Me.txtPosicion.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPosicion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPosicion.Formato = "##,##0.00"
      Me.txtPosicion.IsDecimal = True
      Me.txtPosicion.IsNumber = True
      Me.txtPosicion.IsPK = False
      Me.txtPosicion.IsRequired = False
      Me.txtPosicion.Key = ""
      Me.txtPosicion.LabelAsoc = Me.lblPosicion
      Me.txtPosicion.Location = New System.Drawing.Point(158, 111)
      Me.txtPosicion.MaxLength = 8
      Me.txtPosicion.Name = "txtPosicion"
      Me.txtPosicion.ReadOnly = True
      Me.txtPosicion.Size = New System.Drawing.Size(72, 20)
      Me.txtPosicion.TabIndex = 14
      Me.txtPosicion.Text = "0.00"
      Me.txtPosicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPosicion
      '
      Me.lblPosicion.AutoSize = True
      Me.lblPosicion.LabelAsoc = Nothing
      Me.lblPosicion.Location = New System.Drawing.Point(12, 115)
      Me.lblPosicion.Name = "lblPosicion"
      Me.lblPosicion.Size = New System.Drawing.Size(47, 13)
      Me.lblPosicion.TabIndex = 13
      Me.lblPosicion.Text = "Posición"
      '
      'dtpFechaCierre
      '
      Me.dtpFechaCierre.BindearPropiedadControl = "Value"
      Me.dtpFechaCierre.BindearPropiedadEntidad = "FechaCierre"
      Me.dtpFechaCierre.CustomFormat = "dd/MM/yyyy"
      Me.dtpFechaCierre.Enabled = False
      Me.dtpFechaCierre.ForeColorFocus = System.Drawing.Color.Red
      Me.dtpFechaCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpFechaCierre.IsPK = False
      Me.dtpFechaCierre.IsRequired = False
      Me.dtpFechaCierre.Key = ""
      Me.dtpFechaCierre.LabelAsoc = Nothing
      Me.dtpFechaCierre.Location = New System.Drawing.Point(98, 216)
      Me.dtpFechaCierre.Name = "dtpFechaCierre"
      Me.dtpFechaCierre.Size = New System.Drawing.Size(86, 20)
      Me.dtpFechaCierre.TabIndex = 23
      '
      'chbCierre
      '
      Me.chbCierre.AutoSize = True
      Me.chbCierre.BindearPropiedadControl = ""
      Me.chbCierre.BindearPropiedadEntidad = ""
      Me.chbCierre.ForeColorFocus = System.Drawing.Color.Red
      Me.chbCierre.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbCierre.IsPK = False
      Me.chbCierre.IsRequired = False
      Me.chbCierre.Key = Nothing
      Me.chbCierre.LabelAsoc = Nothing
      Me.chbCierre.Location = New System.Drawing.Point(37, 218)
      Me.chbCierre.Name = "chbCierre"
      Me.chbCierre.Size = New System.Drawing.Size(53, 17)
      Me.chbCierre.TabIndex = 22
      Me.chbCierre.Text = "Cierre"
      Me.chbCierre.UseVisualStyleBackColor = True
      '
      'txtUsuarioCierre
      '
      Me.txtUsuarioCierre.BindearPropiedadControl = "Text"
      Me.txtUsuarioCierre.BindearPropiedadEntidad = "UsuarioCierre"
      Me.txtUsuarioCierre.Enabled = False
      Me.txtUsuarioCierre.ForeColorFocus = System.Drawing.Color.Red
      Me.txtUsuarioCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtUsuarioCierre.Formato = ""
      Me.txtUsuarioCierre.IsDecimal = False
      Me.txtUsuarioCierre.IsNumber = False
      Me.txtUsuarioCierre.IsPK = False
      Me.txtUsuarioCierre.IsRequired = False
      Me.txtUsuarioCierre.Key = ""
      Me.txtUsuarioCierre.LabelAsoc = Nothing
      Me.txtUsuarioCierre.Location = New System.Drawing.Point(189, 216)
      Me.txtUsuarioCierre.MaxLength = 15
      Me.txtUsuarioCierre.Name = "txtUsuarioCierre"
      Me.txtUsuarioCierre.ReadOnly = True
      Me.txtUsuarioCierre.Size = New System.Drawing.Size(96, 20)
      Me.txtUsuarioCierre.TabIndex = 24
      '
      'txtPosicionFinal
      '
      Me.txtPosicionFinal.BindearPropiedadControl = "Text"
      Me.txtPosicionFinal.BindearPropiedadEntidad = "PosicionFinal"
      Me.txtPosicionFinal.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPosicionFinal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPosicionFinal.Formato = "##,##0.00"
      Me.txtPosicionFinal.IsDecimal = True
      Me.txtPosicionFinal.IsNumber = True
      Me.txtPosicionFinal.IsPK = False
      Me.txtPosicionFinal.IsRequired = False
      Me.txtPosicionFinal.Key = ""
      Me.txtPosicionFinal.LabelAsoc = Me.lblPosicionFinal
      Me.txtPosicionFinal.Location = New System.Drawing.Point(158, 189)
      Me.txtPosicionFinal.MaxLength = 8
      Me.txtPosicionFinal.Name = "txtPosicionFinal"
      Me.txtPosicionFinal.ReadOnly = True
      Me.txtPosicionFinal.Size = New System.Drawing.Size(72, 20)
      Me.txtPosicionFinal.TabIndex = 20
      Me.txtPosicionFinal.Text = "0.00"
      Me.txtPosicionFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPosicionFinal
      '
      Me.lblPosicionFinal.AutoSize = True
      Me.lblPosicionFinal.LabelAsoc = Nothing
      Me.lblPosicionFinal.Location = New System.Drawing.Point(12, 193)
      Me.lblPosicionFinal.Name = "lblPosicionFinal"
      Me.lblPosicionFinal.Size = New System.Drawing.Size(70, 13)
      Me.lblPosicionFinal.TabIndex = 19
      Me.lblPosicionFinal.Text = "Neto a Pagar"
      '
      'txtTotalRetenciones
      '
      Me.txtTotalRetenciones.BindearPropiedadControl = "Text"
      Me.txtTotalRetenciones.BindearPropiedadEntidad = "TotalRetenciones"
      Me.txtTotalRetenciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalRetenciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalRetenciones.Formato = "##,##0.00"
      Me.txtTotalRetenciones.IsDecimal = True
      Me.txtTotalRetenciones.IsNumber = True
      Me.txtTotalRetenciones.IsPK = False
      Me.txtTotalRetenciones.IsRequired = False
      Me.txtTotalRetenciones.Key = ""
      Me.txtTotalRetenciones.LabelAsoc = Me.lblRetenciones
      Me.txtTotalRetenciones.Location = New System.Drawing.Point(158, 137)
      Me.txtTotalRetenciones.MaxLength = 8
      Me.txtTotalRetenciones.Name = "txtTotalRetenciones"
      Me.txtTotalRetenciones.ReadOnly = True
      Me.txtTotalRetenciones.Size = New System.Drawing.Size(72, 20)
      Me.txtTotalRetenciones.TabIndex = 16
      Me.txtTotalRetenciones.Text = "0.00"
      Me.txtTotalRetenciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblRetenciones
      '
      Me.lblRetenciones.AutoSize = True
      Me.lblRetenciones.LabelAsoc = Nothing
      Me.lblRetenciones.Location = New System.Drawing.Point(12, 141)
      Me.lblRetenciones.Name = "lblRetenciones"
      Me.lblRetenciones.Size = New System.Drawing.Size(67, 13)
      Me.lblRetenciones.TabIndex = 15
      Me.lblRetenciones.Text = "Retenciones"
      '
      'txtTotalPercepciones
      '
      Me.txtTotalPercepciones.BindearPropiedadControl = "Text"
      Me.txtTotalPercepciones.BindearPropiedadEntidad = "TotalPercepciones"
      Me.txtTotalPercepciones.ForeColorFocus = System.Drawing.Color.Red
      Me.txtTotalPercepciones.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtTotalPercepciones.Formato = "##,##0.00"
      Me.txtTotalPercepciones.IsDecimal = True
      Me.txtTotalPercepciones.IsNumber = True
      Me.txtTotalPercepciones.IsPK = False
      Me.txtTotalPercepciones.IsRequired = False
      Me.txtTotalPercepciones.Key = ""
      Me.txtTotalPercepciones.LabelAsoc = Me.lblPercepciones
      Me.txtTotalPercepciones.Location = New System.Drawing.Point(158, 163)
      Me.txtTotalPercepciones.MaxLength = 8
      Me.txtTotalPercepciones.Name = "txtTotalPercepciones"
      Me.txtTotalPercepciones.ReadOnly = True
      Me.txtTotalPercepciones.Size = New System.Drawing.Size(72, 20)
      Me.txtTotalPercepciones.TabIndex = 18
      Me.txtTotalPercepciones.Text = "0.00"
      Me.txtTotalPercepciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblPercepciones
      '
      Me.lblPercepciones.AutoSize = True
      Me.lblPercepciones.LabelAsoc = Nothing
      Me.lblPercepciones.Location = New System.Drawing.Point(12, 167)
      Me.lblPercepciones.Name = "lblPercepciones"
      Me.lblPercepciones.Size = New System.Drawing.Size(72, 13)
      Me.lblPercepciones.TabIndex = 17
      Me.lblPercepciones.Text = "Percepciones"
      '
      'chbVentasHabilitadas
      '
      Me.chbVentasHabilitadas.AutoSize = True
      Me.chbVentasHabilitadas.BindearPropiedadControl = "Checked"
      Me.chbVentasHabilitadas.BindearPropiedadEntidad = "VentasHabilitadas"
      Me.chbVentasHabilitadas.ForeColorFocus = System.Drawing.Color.Red
      Me.chbVentasHabilitadas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbVentasHabilitadas.IsPK = False
      Me.chbVentasHabilitadas.IsRequired = False
      Me.chbVentasHabilitadas.Key = Nothing
      Me.chbVentasHabilitadas.LabelAsoc = Nothing
      Me.chbVentasHabilitadas.Location = New System.Drawing.Point(37, 243)
      Me.chbVentasHabilitadas.Name = "chbVentasHabilitadas"
      Me.chbVentasHabilitadas.Size = New System.Drawing.Size(112, 17)
      Me.chbVentasHabilitadas.TabIndex = 22
      Me.chbVentasHabilitadas.Text = "Ventas habilitadas"
      Me.chbVentasHabilitadas.UseVisualStyleBackColor = True
      '
      'PeriodosFiscalesDetalle
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(345, 312)
      Me.Controls.Add(Me.txtTotalPercepciones)
      Me.Controls.Add(Me.lblPercepciones)
      Me.Controls.Add(Me.txtTotalRetenciones)
      Me.Controls.Add(Me.lblRetenciones)
      Me.Controls.Add(Me.txtPosicionFinal)
      Me.Controls.Add(Me.lblPosicionFinal)
      Me.Controls.Add(Me.txtUsuarioCierre)
      Me.Controls.Add(Me.chbVentasHabilitadas)
      Me.Controls.Add(Me.chbCierre)
      Me.Controls.Add(Me.dtpFechaCierre)
      Me.Controls.Add(Me.txtPosicion)
      Me.Controls.Add(Me.lblPosicion)
      Me.Controls.Add(Me.txtTotalCompras)
      Me.Controls.Add(Me.txtTotalImpuestosCompras)
      Me.Controls.Add(Me.txtTotalNetoCompras)
      Me.Controls.Add(Me.lblCompras)
      Me.Controls.Add(Me.lblTotalVentas)
      Me.Controls.Add(Me.txtTotalVentas)
      Me.Controls.Add(Me.lblTotalImpuestosVentas)
      Me.Controls.Add(Me.txtTotalImpuestosVentas)
      Me.Controls.Add(Me.lblTotalNetoVentas)
      Me.Controls.Add(Me.txtTotalNetoVentas)
      Me.Controls.Add(Me.lblVentas)
      Me.Controls.Add(Me.dtpPeriodo)
      Me.Controls.Add(Me.lblPeriodoFiscal)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "PeriodosFiscalesDetalle"
      Me.Text = "Periodo Fiscal"
      Me.Controls.SetChildIndex(Me.btnAplicar, 0)
      Me.Controls.SetChildIndex(Me.btnCopiar, 0)
      Me.Controls.SetChildIndex(Me.lblPeriodoFiscal, 0)
      Me.Controls.SetChildIndex(Me.btnCancelar, 0)
      Me.Controls.SetChildIndex(Me.btnAceptar, 0)
      Me.Controls.SetChildIndex(Me.dtpPeriodo, 0)
      Me.Controls.SetChildIndex(Me.lblVentas, 0)
      Me.Controls.SetChildIndex(Me.txtTotalNetoVentas, 0)
      Me.Controls.SetChildIndex(Me.lblTotalNetoVentas, 0)
      Me.Controls.SetChildIndex(Me.txtTotalImpuestosVentas, 0)
      Me.Controls.SetChildIndex(Me.lblTotalImpuestosVentas, 0)
      Me.Controls.SetChildIndex(Me.txtTotalVentas, 0)
      Me.Controls.SetChildIndex(Me.lblTotalVentas, 0)
      Me.Controls.SetChildIndex(Me.lblCompras, 0)
      Me.Controls.SetChildIndex(Me.txtTotalNetoCompras, 0)
      Me.Controls.SetChildIndex(Me.txtTotalImpuestosCompras, 0)
      Me.Controls.SetChildIndex(Me.txtTotalCompras, 0)
      Me.Controls.SetChildIndex(Me.lblPosicion, 0)
      Me.Controls.SetChildIndex(Me.txtPosicion, 0)
      Me.Controls.SetChildIndex(Me.dtpFechaCierre, 0)
      Me.Controls.SetChildIndex(Me.chbCierre, 0)
      Me.Controls.SetChildIndex(Me.chbVentasHabilitadas, 0)
      Me.Controls.SetChildIndex(Me.txtUsuarioCierre, 0)
      Me.Controls.SetChildIndex(Me.lblPosicionFinal, 0)
      Me.Controls.SetChildIndex(Me.txtPosicionFinal, 0)
      Me.Controls.SetChildIndex(Me.lblRetenciones, 0)
      Me.Controls.SetChildIndex(Me.txtTotalRetenciones, 0)
      Me.Controls.SetChildIndex(Me.lblPercepciones, 0)
      Me.Controls.SetChildIndex(Me.txtTotalPercepciones, 0)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents lblPeriodoFiscal As Eniac.Controles.Label
   Friend WithEvents dtpPeriodo As Eniac.Controles.DateTimePicker
   Friend WithEvents txtTotalNetoVentas As Eniac.Controles.TextBox
   Friend WithEvents lblVentas As Eniac.Controles.Label
   Friend WithEvents lblTotalNetoVentas As Eniac.Controles.Label
   Friend WithEvents lblTotalImpuestosVentas As Eniac.Controles.Label
   Friend WithEvents txtTotalImpuestosVentas As Eniac.Controles.TextBox
   Friend WithEvents lblTotalVentas As Eniac.Controles.Label
   Friend WithEvents txtTotalVentas As Eniac.Controles.TextBox
   Friend WithEvents txtTotalCompras As Eniac.Controles.TextBox
   Friend WithEvents txtTotalImpuestosCompras As Eniac.Controles.TextBox
   Friend WithEvents txtTotalNetoCompras As Eniac.Controles.TextBox
   Friend WithEvents lblCompras As Eniac.Controles.Label
   Friend WithEvents txtPosicion As Eniac.Controles.TextBox
   Friend WithEvents lblPosicion As Eniac.Controles.Label
   Friend WithEvents dtpFechaCierre As Eniac.Controles.DateTimePicker
   Friend WithEvents chbCierre As Eniac.Controles.CheckBox
   Friend WithEvents txtUsuarioCierre As Eniac.Controles.TextBox
   Friend WithEvents txtPosicionFinal As Eniac.Controles.TextBox
   Friend WithEvents lblPosicionFinal As Eniac.Controles.Label
   Friend WithEvents txtTotalRetenciones As Eniac.Controles.TextBox
   Friend WithEvents lblRetenciones As Eniac.Controles.Label
   Friend WithEvents txtTotalPercepciones As Eniac.Controles.TextBox
   Friend WithEvents lblPercepciones As Eniac.Controles.Label
   Friend WithEvents chbVentasHabilitadas As Eniac.Controles.CheckBox

End Class
