<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanesTarjetasDetalle
   Inherits BaseDetalle

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
		Me.txtNombrePlanTarjeta = New Eniac.Controles.TextBox()
		Me.lblNombreInteres = New Eniac.Controles.Label()
		Me.txtIdPlanTarjeta = New Eniac.Controles.TextBox()
		Me.lblIdInteres = New Eniac.Controles.Label()
		Me.txtCuotasDesde = New Eniac.Controles.TextBox()
		Me.lblDiasDesde = New Eniac.Controles.Label()
		Me.lblDiasHasta = New Eniac.Controles.Label()
		Me.txtPorcDescRec = New Eniac.Controles.TextBox()
		Me.lblInteres = New Eniac.Controles.Label()
		Me.txtCuotasHasta = New Eniac.Controles.TextBox()
		Me.chbActivo = New Eniac.Controles.CheckBox()
		Me.lblActivo = New Eniac.Controles.Label()
		Me.chbTarjeta = New Eniac.Controles.CheckBox()
		Me.lblTarjeta = New Eniac.Controles.Label()
		Me.cmbTarjeta = New Eniac.Controles.ComboBox()
		Me.bscBanco = New Eniac.Controles.Buscador()
		Me.lblBanco = New Eniac.Controles.Label()
		Me.chbBanco = New Eniac.Controles.CheckBox()
		Me.gpbPorcentajeDRDias = New System.Windows.Forms.GroupBox()
		Me.chbPDRViernes = New Eniac.Controles.CheckBox()
		Me.chbPDRSabado = New Eniac.Controles.CheckBox()
		Me.chbPDRDomingo = New Eniac.Controles.CheckBox()
		Me.chbPDRJueves = New Eniac.Controles.CheckBox()
		Me.chbPDRMiercoles = New Eniac.Controles.CheckBox()
		Me.chbPDRMartes = New Eniac.Controles.CheckBox()
		Me.chbPDRLunes = New Eniac.Controles.CheckBox()
		Me.gpbPorcentajeDRDias.SuspendLayout()
		Me.SuspendLayout()
		'
		'btnAceptar
		'
		Me.btnAceptar.Location = New System.Drawing.Point(249, 273)
		Me.btnAceptar.TabIndex = 19
		'
		'btnCancelar
		'
		Me.btnCancelar.Location = New System.Drawing.Point(335, 273)
		Me.btnCancelar.TabIndex = 20
		'
		'btnCopiar
		'
		Me.btnCopiar.Location = New System.Drawing.Point(148, 273)
		Me.btnCopiar.TabIndex = 18
		'
		'btnAplicar
		'
		Me.btnAplicar.Location = New System.Drawing.Point(91, 273)
		'
		'txtNombrePlanTarjeta
		'
		Me.txtNombrePlanTarjeta.BindearPropiedadControl = "Text"
		Me.txtNombrePlanTarjeta.BindearPropiedadEntidad = "NombrePlanTarjeta"
		Me.txtNombrePlanTarjeta.ForeColorFocus = System.Drawing.Color.Red
		Me.txtNombrePlanTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtNombrePlanTarjeta.Formato = ""
		Me.txtNombrePlanTarjeta.IsDecimal = False
		Me.txtNombrePlanTarjeta.IsNumber = False
		Me.txtNombrePlanTarjeta.IsPK = False
		Me.txtNombrePlanTarjeta.IsRequired = True
		Me.txtNombrePlanTarjeta.Key = ""
		Me.txtNombrePlanTarjeta.LabelAsoc = Me.lblNombreInteres
		Me.txtNombrePlanTarjeta.Location = New System.Drawing.Point(98, 38)
		Me.txtNombrePlanTarjeta.MaxLength = 30
		Me.txtNombrePlanTarjeta.Name = "txtNombrePlanTarjeta"
		Me.txtNombrePlanTarjeta.Size = New System.Drawing.Size(289, 20)
		Me.txtNombrePlanTarjeta.TabIndex = 3
		'
		'lblNombreInteres
		'
		Me.lblNombreInteres.AutoSize = True
		Me.lblNombreInteres.LabelAsoc = Nothing
		Me.lblNombreInteres.Location = New System.Drawing.Point(28, 42)
		Me.lblNombreInteres.Name = "lblNombreInteres"
		Me.lblNombreInteres.Size = New System.Drawing.Size(44, 13)
		Me.lblNombreInteres.TabIndex = 2
		Me.lblNombreInteres.Text = "Nombre"
		'
		'txtIdPlanTarjeta
		'
		Me.txtIdPlanTarjeta.BindearPropiedadControl = "Text"
		Me.txtIdPlanTarjeta.BindearPropiedadEntidad = "IdPlanTarjeta"
		Me.txtIdPlanTarjeta.ForeColorFocus = System.Drawing.Color.Red
		Me.txtIdPlanTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtIdPlanTarjeta.Formato = ""
		Me.txtIdPlanTarjeta.IsDecimal = False
		Me.txtIdPlanTarjeta.IsNumber = True
		Me.txtIdPlanTarjeta.IsPK = True
		Me.txtIdPlanTarjeta.IsRequired = True
		Me.txtIdPlanTarjeta.Key = ""
		Me.txtIdPlanTarjeta.LabelAsoc = Me.lblIdInteres
		Me.txtIdPlanTarjeta.Location = New System.Drawing.Point(98, 12)
		Me.txtIdPlanTarjeta.Name = "txtIdPlanTarjeta"
		Me.txtIdPlanTarjeta.Size = New System.Drawing.Size(95, 20)
		Me.txtIdPlanTarjeta.TabIndex = 1
		Me.txtIdPlanTarjeta.Text = "0"
		Me.txtIdPlanTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblIdInteres
		'
		Me.lblIdInteres.AutoSize = True
		Me.lblIdInteres.LabelAsoc = Nothing
		Me.lblIdInteres.Location = New System.Drawing.Point(28, 16)
		Me.lblIdInteres.Name = "lblIdInteres"
		Me.lblIdInteres.Size = New System.Drawing.Size(40, 13)
		Me.lblIdInteres.TabIndex = 0
		Me.lblIdInteres.Text = "Código"
		'
		'txtCuotasDesde
		'
		Me.txtCuotasDesde.BindearPropiedadControl = "Text"
		Me.txtCuotasDesde.BindearPropiedadEntidad = "CuotasDesde"
		Me.txtCuotasDesde.ForeColorFocus = System.Drawing.Color.Red
		Me.txtCuotasDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtCuotasDesde.Formato = ""
		Me.txtCuotasDesde.IsDecimal = False
		Me.txtCuotasDesde.IsNumber = True
		Me.txtCuotasDesde.IsPK = False
		Me.txtCuotasDesde.IsRequired = False
		Me.txtCuotasDesde.Key = ""
		Me.txtCuotasDesde.LabelAsoc = Me.lblDiasDesde
		Me.txtCuotasDesde.Location = New System.Drawing.Point(98, 64)
		Me.txtCuotasDesde.Name = "txtCuotasDesde"
		Me.txtCuotasDesde.Size = New System.Drawing.Size(95, 20)
		Me.txtCuotasDesde.TabIndex = 5
		Me.txtCuotasDesde.Text = "0"
		Me.txtCuotasDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblDiasDesde
		'
		Me.lblDiasDesde.AutoSize = True
		Me.lblDiasDesde.LabelAsoc = Nothing
		Me.lblDiasDesde.Location = New System.Drawing.Point(28, 68)
		Me.lblDiasDesde.Name = "lblDiasDesde"
		Me.lblDiasDesde.Size = New System.Drawing.Size(69, 13)
		Me.lblDiasDesde.TabIndex = 4
		Me.lblDiasDesde.Text = "Cuota Desde"
		'
		'lblDiasHasta
		'
		Me.lblDiasHasta.AutoSize = True
		Me.lblDiasHasta.LabelAsoc = Nothing
		Me.lblDiasHasta.Location = New System.Drawing.Point(255, 69)
		Me.lblDiasHasta.Name = "lblDiasHasta"
		Me.lblDiasHasta.Size = New System.Drawing.Size(66, 13)
		Me.lblDiasHasta.TabIndex = 6
		Me.lblDiasHasta.Text = "Cuota Hasta"
		'
		'txtPorcDescRec
		'
		Me.txtPorcDescRec.BindearPropiedadControl = "Text"
		Me.txtPorcDescRec.BindearPropiedadEntidad = "PorcDescRec"
		Me.txtPorcDescRec.ForeColorFocus = System.Drawing.Color.Red
		Me.txtPorcDescRec.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtPorcDescRec.Formato = "##0.00"
		Me.txtPorcDescRec.IsDecimal = True
		Me.txtPorcDescRec.IsNumber = True
		Me.txtPorcDescRec.IsPK = False
		Me.txtPorcDescRec.IsRequired = False
		Me.txtPorcDescRec.Key = ""
		Me.txtPorcDescRec.LabelAsoc = Me.lblInteres
		Me.txtPorcDescRec.Location = New System.Drawing.Point(98, 90)
		Me.txtPorcDescRec.Name = "txtPorcDescRec"
		Me.txtPorcDescRec.Size = New System.Drawing.Size(95, 20)
		Me.txtPorcDescRec.TabIndex = 9
		Me.txtPorcDescRec.Text = "0.00"
		Me.txtPorcDescRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		'
		'lblInteres
		'
		Me.lblInteres.AutoSize = True
		Me.lblInteres.LabelAsoc = Nothing
		Me.lblInteres.Location = New System.Drawing.Point(28, 94)
		Me.lblInteres.Name = "lblInteres"
		Me.lblInteres.Size = New System.Drawing.Size(56, 13)
		Me.lblInteres.TabIndex = 8
		Me.lblInteres.Text = "Porc. D/R"
		'
		'txtCuotasHasta
		'
		Me.txtCuotasHasta.BindearPropiedadControl = "Text"
		Me.txtCuotasHasta.BindearPropiedadEntidad = "CuotasHasta"
		Me.txtCuotasHasta.ForeColorFocus = System.Drawing.Color.Red
		Me.txtCuotasHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.txtCuotasHasta.Formato = ""
		Me.txtCuotasHasta.IsDecimal = False
		Me.txtCuotasHasta.IsNumber = True
		Me.txtCuotasHasta.IsPK = False
		Me.txtCuotasHasta.IsRequired = False
		Me.txtCuotasHasta.Key = ""
		Me.txtCuotasHasta.LabelAsoc = Me.lblDiasHasta
		Me.txtCuotasHasta.Location = New System.Drawing.Point(325, 65)
		Me.txtCuotasHasta.Name = "txtCuotasHasta"
		Me.txtCuotasHasta.Size = New System.Drawing.Size(61, 20)
		Me.txtCuotasHasta.TabIndex = 7
		Me.txtCuotasHasta.Text = "0"
		Me.txtCuotasHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
		Me.chbActivo.LabelAsoc = Me.lblActivo
		Me.chbActivo.Location = New System.Drawing.Point(75, 232)
		Me.chbActivo.Name = "chbActivo"
		Me.chbActivo.Size = New System.Drawing.Size(15, 14)
		Me.chbActivo.TabIndex = 17
		Me.chbActivo.UseVisualStyleBackColor = True
		'
		'lblActivo
		'
		Me.lblActivo.AutoSize = True
		Me.lblActivo.LabelAsoc = Nothing
		Me.lblActivo.Location = New System.Drawing.Point(28, 232)
		Me.lblActivo.Name = "lblActivo"
		Me.lblActivo.Size = New System.Drawing.Size(37, 13)
		Me.lblActivo.TabIndex = 16
		Me.lblActivo.Text = "Activo"
		'
		'chbTarjeta
		'
		Me.chbTarjeta.AutoSize = True
		Me.chbTarjeta.BindearPropiedadControl = ""
		Me.chbTarjeta.BindearPropiedadEntidad = ""
		Me.chbTarjeta.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chbTarjeta.ForeColorFocus = System.Drawing.Color.Red
		Me.chbTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbTarjeta.IsPK = False
		Me.chbTarjeta.IsRequired = False
		Me.chbTarjeta.Key = Nothing
		Me.chbTarjeta.LabelAsoc = Me.lblTarjeta
		Me.chbTarjeta.Location = New System.Drawing.Point(75, 180)
		Me.chbTarjeta.Name = "chbTarjeta"
		Me.chbTarjeta.Size = New System.Drawing.Size(15, 14)
		Me.chbTarjeta.TabIndex = 11
		Me.chbTarjeta.UseVisualStyleBackColor = True
		'
		'lblTarjeta
		'
		Me.lblTarjeta.AutoSize = True
		Me.lblTarjeta.LabelAsoc = Nothing
		Me.lblTarjeta.Location = New System.Drawing.Point(28, 180)
		Me.lblTarjeta.Name = "lblTarjeta"
		Me.lblTarjeta.Size = New System.Drawing.Size(40, 13)
		Me.lblTarjeta.TabIndex = 10
		Me.lblTarjeta.Text = "Tarjeta"
		'
		'cmbTarjeta
		'
		Me.cmbTarjeta.BindearPropiedadControl = ""
		Me.cmbTarjeta.BindearPropiedadEntidad = ""
		Me.cmbTarjeta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTarjeta.ForeColorFocus = System.Drawing.Color.Red
		Me.cmbTarjeta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.cmbTarjeta.FormattingEnabled = True
		Me.cmbTarjeta.IsPK = False
		Me.cmbTarjeta.IsRequired = False
		Me.cmbTarjeta.Key = Nothing
		Me.cmbTarjeta.LabelAsoc = Me.lblTarjeta
		Me.cmbTarjeta.Location = New System.Drawing.Point(98, 177)
		Me.cmbTarjeta.Name = "cmbTarjeta"
		Me.cmbTarjeta.Size = New System.Drawing.Size(288, 21)
		Me.cmbTarjeta.TabIndex = 12
		'
		'bscBanco
		'
		Me.bscBanco.AyudaAncho = 608
		Me.bscBanco.BindearPropiedadControl = Nothing
		Me.bscBanco.BindearPropiedadEntidad = Nothing
		Me.bscBanco.ColumnasAlineacion = Nothing
		Me.bscBanco.ColumnasAncho = Nothing
		Me.bscBanco.ColumnasFormato = Nothing
		Me.bscBanco.ColumnasOcultas = Nothing
		Me.bscBanco.ColumnasTitulos = Nothing
		Me.bscBanco.Datos = Nothing
		Me.bscBanco.FilaDevuelta = Nothing
		Me.bscBanco.ForeColorFocus = System.Drawing.Color.Red
		Me.bscBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.bscBanco.IsDecimal = False
		Me.bscBanco.IsNumber = False
		Me.bscBanco.IsPK = False
		Me.bscBanco.IsRequired = False
		Me.bscBanco.Key = ""
		Me.bscBanco.LabelAsoc = Me.lblBanco
		Me.bscBanco.Location = New System.Drawing.Point(98, 204)
		Me.bscBanco.MaxLengh = "32767"
		Me.bscBanco.Name = "bscBanco"
		Me.bscBanco.Permitido = True
		Me.bscBanco.Selecciono = False
		Me.bscBanco.Size = New System.Drawing.Size(288, 20)
		Me.bscBanco.TabIndex = 15
		Me.bscBanco.Titulo = Nothing
		'
		'lblBanco
		'
		Me.lblBanco.AutoSize = True
		Me.lblBanco.LabelAsoc = Nothing
		Me.lblBanco.Location = New System.Drawing.Point(28, 207)
		Me.lblBanco.Name = "lblBanco"
		Me.lblBanco.Size = New System.Drawing.Size(38, 13)
		Me.lblBanco.TabIndex = 13
		Me.lblBanco.Text = "Banco"
		'
		'chbBanco
		'
		Me.chbBanco.AutoSize = True
		Me.chbBanco.BindearPropiedadControl = ""
		Me.chbBanco.BindearPropiedadEntidad = ""
		Me.chbBanco.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.chbBanco.ForeColorFocus = System.Drawing.Color.Red
		Me.chbBanco.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbBanco.IsPK = False
		Me.chbBanco.IsRequired = False
		Me.chbBanco.Key = Nothing
		Me.chbBanco.LabelAsoc = Me.lblBanco
		Me.chbBanco.Location = New System.Drawing.Point(75, 207)
		Me.chbBanco.Name = "chbBanco"
		Me.chbBanco.Size = New System.Drawing.Size(15, 14)
		Me.chbBanco.TabIndex = 14
		Me.chbBanco.UseVisualStyleBackColor = True
		'
		'gpbPorcentajeDRDias
		'
		Me.gpbPorcentajeDRDias.Controls.Add(Me.chbPDRViernes)
		Me.gpbPorcentajeDRDias.Controls.Add(Me.chbPDRSabado)
		Me.gpbPorcentajeDRDias.Controls.Add(Me.chbPDRDomingo)
		Me.gpbPorcentajeDRDias.Controls.Add(Me.chbPDRJueves)
		Me.gpbPorcentajeDRDias.Controls.Add(Me.chbPDRMiercoles)
		Me.gpbPorcentajeDRDias.Controls.Add(Me.chbPDRMartes)
		Me.gpbPorcentajeDRDias.Controls.Add(Me.chbPDRLunes)
		Me.gpbPorcentajeDRDias.Location = New System.Drawing.Point(31, 116)
		Me.gpbPorcentajeDRDias.Name = "gpbPorcentajeDRDias"
		Me.gpbPorcentajeDRDias.Size = New System.Drawing.Size(356, 55)
		Me.gpbPorcentajeDRDias.TabIndex = 21
		Me.gpbPorcentajeDRDias.TabStop = False
		Me.gpbPorcentajeDRDias.Text = "Porcentaje D/R Dias"
		'
		'chbPDRViernes
		'
		Me.chbPDRViernes.AutoSize = True
		Me.chbPDRViernes.BindearPropiedadControl = "Checked"
		Me.chbPDRViernes.BindearPropiedadEntidad = "PorcDescRecVie"
		Me.chbPDRViernes.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPDRViernes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPDRViernes.IsPK = False
		Me.chbPDRViernes.IsRequired = False
		Me.chbPDRViernes.Key = Nothing
		Me.chbPDRViernes.LabelAsoc = Nothing
		Me.chbPDRViernes.Location = New System.Drawing.Point(258, 23)
		Me.chbPDRViernes.Name = "chbPDRViernes"
		Me.chbPDRViernes.Size = New System.Drawing.Size(41, 17)
		Me.chbPDRViernes.TabIndex = 58
		Me.chbPDRViernes.Text = "Vie"
		Me.chbPDRViernes.UseVisualStyleBackColor = True
		'
		'chbPDRSabado
		'
		Me.chbPDRSabado.AutoSize = True
		Me.chbPDRSabado.BindearPropiedadControl = "Checked"
		Me.chbPDRSabado.BindearPropiedadEntidad = "PorcDescRecSab"
		Me.chbPDRSabado.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPDRSabado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPDRSabado.IsPK = False
		Me.chbPDRSabado.IsRequired = False
		Me.chbPDRSabado.Key = Nothing
		Me.chbPDRSabado.LabelAsoc = Nothing
		Me.chbPDRSabado.Location = New System.Drawing.Point(305, 23)
		Me.chbPDRSabado.Name = "chbPDRSabado"
		Me.chbPDRSabado.Size = New System.Drawing.Size(45, 17)
		Me.chbPDRSabado.TabIndex = 57
		Me.chbPDRSabado.Text = "Sab"
		Me.chbPDRSabado.UseVisualStyleBackColor = True
		'
		'chbPDRDomingo
		'
		Me.chbPDRDomingo.AutoSize = True
		Me.chbPDRDomingo.BindearPropiedadControl = "Checked"
		Me.chbPDRDomingo.BindearPropiedadEntidad = "PorcDescRecDom"
		Me.chbPDRDomingo.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPDRDomingo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPDRDomingo.IsPK = False
		Me.chbPDRDomingo.IsRequired = False
		Me.chbPDRDomingo.Key = Nothing
		Me.chbPDRDomingo.LabelAsoc = Nothing
		Me.chbPDRDomingo.Location = New System.Drawing.Point(6, 23)
		Me.chbPDRDomingo.Name = "chbPDRDomingo"
		Me.chbPDRDomingo.Size = New System.Drawing.Size(48, 17)
		Me.chbPDRDomingo.TabIndex = 56
		Me.chbPDRDomingo.Text = "Dom"
		Me.chbPDRDomingo.UseVisualStyleBackColor = True
		'
		'chbPDRJueves
		'
		Me.chbPDRJueves.AutoSize = True
		Me.chbPDRJueves.BindearPropiedadControl = "Checked"
		Me.chbPDRJueves.BindearPropiedadEntidad = "PorcDescRecJue"
		Me.chbPDRJueves.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPDRJueves.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPDRJueves.IsPK = False
		Me.chbPDRJueves.IsRequired = False
		Me.chbPDRJueves.Key = Nothing
		Me.chbPDRJueves.LabelAsoc = Nothing
		Me.chbPDRJueves.Location = New System.Drawing.Point(209, 23)
		Me.chbPDRJueves.Name = "chbPDRJueves"
		Me.chbPDRJueves.Size = New System.Drawing.Size(43, 17)
		Me.chbPDRJueves.TabIndex = 55
		Me.chbPDRJueves.Text = "Jue"
		Me.chbPDRJueves.UseVisualStyleBackColor = True
		'
		'chbPDRMiercoles
		'
		Me.chbPDRMiercoles.AutoSize = True
		Me.chbPDRMiercoles.BindearPropiedadControl = "Checked"
		Me.chbPDRMiercoles.BindearPropiedadEntidad = "PorcDescRecMie"
		Me.chbPDRMiercoles.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPDRMiercoles.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPDRMiercoles.IsPK = False
		Me.chbPDRMiercoles.IsRequired = False
		Me.chbPDRMiercoles.Key = Nothing
		Me.chbPDRMiercoles.LabelAsoc = Nothing
		Me.chbPDRMiercoles.Location = New System.Drawing.Point(160, 23)
		Me.chbPDRMiercoles.Name = "chbPDRMiercoles"
		Me.chbPDRMiercoles.Size = New System.Drawing.Size(43, 17)
		Me.chbPDRMiercoles.TabIndex = 54
		Me.chbPDRMiercoles.Text = "Mie"
		Me.chbPDRMiercoles.UseVisualStyleBackColor = True
		'
		'chbPDRMartes
		'
		Me.chbPDRMartes.AutoSize = True
		Me.chbPDRMartes.BindearPropiedadControl = "Checked"
		Me.chbPDRMartes.BindearPropiedadEntidad = "PorcDescRecMar"
		Me.chbPDRMartes.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPDRMartes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPDRMartes.IsPK = False
		Me.chbPDRMartes.IsRequired = False
		Me.chbPDRMartes.Key = Nothing
		Me.chbPDRMartes.LabelAsoc = Nothing
		Me.chbPDRMartes.Location = New System.Drawing.Point(110, 23)
		Me.chbPDRMartes.Name = "chbPDRMartes"
		Me.chbPDRMartes.Size = New System.Drawing.Size(44, 17)
		Me.chbPDRMartes.TabIndex = 53
		Me.chbPDRMartes.Text = "Mar"
		Me.chbPDRMartes.UseVisualStyleBackColor = True
		'
		'chbPDRLunes
		'
		Me.chbPDRLunes.AutoSize = True
		Me.chbPDRLunes.BindearPropiedadControl = "Checked"
		Me.chbPDRLunes.BindearPropiedadEntidad = "PorcDescRecLun"
		Me.chbPDRLunes.ForeColorFocus = System.Drawing.Color.Red
		Me.chbPDRLunes.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbPDRLunes.IsPK = False
		Me.chbPDRLunes.IsRequired = False
		Me.chbPDRLunes.Key = Nothing
		Me.chbPDRLunes.LabelAsoc = Nothing
		Me.chbPDRLunes.Location = New System.Drawing.Point(60, 23)
		Me.chbPDRLunes.Name = "chbPDRLunes"
		Me.chbPDRLunes.Size = New System.Drawing.Size(44, 17)
		Me.chbPDRLunes.TabIndex = 52
		Me.chbPDRLunes.Text = "Lun"
		Me.chbPDRLunes.UseVisualStyleBackColor = True
		'
		'PlanesTarjetasDetalle
		'
		Me.AcceptButton = Nothing
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(424, 308)
		Me.Controls.Add(Me.gpbPorcentajeDRDias)
		Me.Controls.Add(Me.cmbTarjeta)
		Me.Controls.Add(Me.bscBanco)
		Me.Controls.Add(Me.chbBanco)
		Me.Controls.Add(Me.chbTarjeta)
		Me.Controls.Add(Me.chbActivo)
		Me.Controls.Add(Me.txtCuotasDesde)
		Me.Controls.Add(Me.lblDiasDesde)
		Me.Controls.Add(Me.lblDiasHasta)
		Me.Controls.Add(Me.txtPorcDescRec)
		Me.Controls.Add(Me.lblInteres)
		Me.Controls.Add(Me.txtCuotasHasta)
		Me.Controls.Add(Me.txtNombrePlanTarjeta)
		Me.Controls.Add(Me.txtIdPlanTarjeta)
		Me.Controls.Add(Me.lblNombreInteres)
		Me.Controls.Add(Me.lblActivo)
		Me.Controls.Add(Me.lblBanco)
		Me.Controls.Add(Me.lblTarjeta)
		Me.Controls.Add(Me.lblIdInteres)
		Me.Name = "PlanesTarjetasDetalle"
		Me.Text = "Plan de Tarjeta"
		Me.Controls.SetChildIndex(Me.btnAplicar, 0)
		Me.Controls.SetChildIndex(Me.btnCancelar, 0)
		Me.Controls.SetChildIndex(Me.btnAceptar, 0)
		Me.Controls.SetChildIndex(Me.btnCopiar, 0)
		Me.Controls.SetChildIndex(Me.lblIdInteres, 0)
		Me.Controls.SetChildIndex(Me.lblTarjeta, 0)
		Me.Controls.SetChildIndex(Me.lblBanco, 0)
		Me.Controls.SetChildIndex(Me.lblActivo, 0)
		Me.Controls.SetChildIndex(Me.lblNombreInteres, 0)
		Me.Controls.SetChildIndex(Me.txtIdPlanTarjeta, 0)
		Me.Controls.SetChildIndex(Me.txtNombrePlanTarjeta, 0)
		Me.Controls.SetChildIndex(Me.txtCuotasHasta, 0)
		Me.Controls.SetChildIndex(Me.lblInteres, 0)
		Me.Controls.SetChildIndex(Me.txtPorcDescRec, 0)
		Me.Controls.SetChildIndex(Me.lblDiasHasta, 0)
		Me.Controls.SetChildIndex(Me.lblDiasDesde, 0)
		Me.Controls.SetChildIndex(Me.txtCuotasDesde, 0)
		Me.Controls.SetChildIndex(Me.chbActivo, 0)
		Me.Controls.SetChildIndex(Me.chbTarjeta, 0)
		Me.Controls.SetChildIndex(Me.chbBanco, 0)
		Me.Controls.SetChildIndex(Me.bscBanco, 0)
		Me.Controls.SetChildIndex(Me.cmbTarjeta, 0)
		Me.Controls.SetChildIndex(Me.gpbPorcentajeDRDias, 0)
		Me.gpbPorcentajeDRDias.ResumeLayout(False)
		Me.gpbPorcentajeDRDias.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txtNombrePlanTarjeta As Eniac.Controles.TextBox
   Friend WithEvents lblNombreInteres As Eniac.Controles.Label
   Friend WithEvents txtIdPlanTarjeta As Eniac.Controles.TextBox
   Friend WithEvents lblIdInteres As Eniac.Controles.Label
   Friend WithEvents txtCuotasDesde As Eniac.Controles.TextBox
   Friend WithEvents lblDiasDesde As Eniac.Controles.Label
   Friend WithEvents lblDiasHasta As Eniac.Controles.Label
   Friend WithEvents txtPorcDescRec As Eniac.Controles.TextBox
   Friend WithEvents lblInteres As Eniac.Controles.Label
   Friend WithEvents txtCuotasHasta As Eniac.Controles.TextBox
   Friend WithEvents chbActivo As Eniac.Controles.CheckBox
   Friend WithEvents chbTarjeta As Eniac.Controles.CheckBox
   Friend WithEvents cmbTarjeta As Eniac.Controles.ComboBox
   Friend WithEvents bscBanco As Eniac.Controles.Buscador
   Friend WithEvents chbBanco As Eniac.Controles.CheckBox
   Friend WithEvents lblActivo As Eniac.Controles.Label
   Friend WithEvents lblTarjeta As Eniac.Controles.Label
   Friend WithEvents lblBanco As Eniac.Controles.Label
	Friend WithEvents gpbPorcentajeDRDias As GroupBox
	Friend WithEvents chbPDRViernes As Controles.CheckBox
	Friend WithEvents chbPDRSabado As Controles.CheckBox
	Friend WithEvents chbPDRDomingo As Controles.CheckBox
	Friend WithEvents chbPDRJueves As Controles.CheckBox
	Friend WithEvents chbPDRMiercoles As Controles.CheckBox
	Friend WithEvents chbPDRMartes As Controles.CheckBox
	Friend WithEvents chbPDRLunes As Controles.CheckBox
End Class
