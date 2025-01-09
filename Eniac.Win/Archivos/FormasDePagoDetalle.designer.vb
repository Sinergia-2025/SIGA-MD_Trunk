<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormasDePagoDetalle
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormasDePagoDetalle))
      Me.txtIdFormasPago = New Eniac.Controles.TextBox()
      Me.lblIdFormasPago = New Eniac.Controles.Label()
      Me.lblDias = New Eniac.Controles.Label()
      Me.txtDias = New Eniac.Controles.TextBox()
      Me.lblNombreFormasPago = New Eniac.Controles.Label()
      Me.txtDescripcionFormasPago = New Eniac.Controles.TextBox()
      Me.lblOrdenVentas = New Eniac.Controles.Label()
      Me.txtOrdenVentas = New Eniac.Controles.TextBox()
      Me.lblOrdenCompras = New Eniac.Controles.Label()
      Me.txtOrdenCompras = New Eniac.Controles.TextBox()
      Me.lblOrdenFichas = New Eniac.Controles.Label()
      Me.txtOrdenFichas = New Eniac.Controles.TextBox()
      Me.lblCantidadCuotas = New Eniac.Controles.Label()
      Me.txtDiasPrimerCuota = New Eniac.Controles.TextBox()
      Me.txtCantidadCuotas = New Eniac.Controles.TextBox()
      Me.lblDiasPrimerCuota = New Eniac.Controles.Label()
        Me.lblFechaBaseProximaCuota = New Eniac.Controles.Label()
        Me.chbExcluyeSabados = New Eniac.Controles.CheckBox()
        Me.chbExcluyeDomingos = New Eniac.Controles.CheckBox()
        Me.chbExcluyeFeriados = New Eniac.Controles.CheckBox()
        Me.lblExcluye = New Eniac.Controles.Label()
        Me.lblPorcentaje = New Eniac.Controles.Label()
        Me.txtPorcentaje = New Eniac.Controles.TextBox()
        Me.lblPorcentaje2 = New Eniac.Controles.Label()
        Me.grpRequiere = New System.Windows.Forms.GroupBox()
        Me.chbRequiereTarjetaCredito1Pago = New Eniac.Controles.CheckBox()
        Me.chbRequiereTarjetaCredito = New Eniac.Controles.CheckBox()
        Me.chbRequiereTarjetaDebito = New Eniac.Controles.CheckBox()
        Me.chbRequiereCheques = New Eniac.Controles.CheckBox()
        Me.chbRequiereTransferencia = New Eniac.Controles.CheckBox()
        Me.chbRequiereTickets = New Eniac.Controles.CheckBox()
        Me.chbRequiereDolares = New Eniac.Controles.CheckBox()
        Me.chbRequierePesos = New Eniac.Controles.CheckBox()
        Me.chbListaDePrecios = New Eniac.Controles.CheckBox()
        Me.chbTipoComprobante = New Eniac.Controles.CheckBox()
        Me.chbTipoComprobanteFR = New Eniac.Controles.CheckBox()
        Me.bscCuentaBancariaTransfBanc = New Eniac.Controles.Buscador2()
        Me.chbCuentaBancaria = New Eniac.Controles.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chbArchivoComplementario = New Eniac.Controles.CheckBox()
        Me.bscCodigoCuentaBancariaTransfBanc = New Eniac.Controles.Buscador2()
        Me.txtArchivoComplementario = New Eniac.Controles.TextBox()
        Me.cmbTipoComprobantesFR = New Eniac.Controles.ComboBox()
        Me.cmbTipoComprobantes = New Eniac.Controles.ComboBox()
        Me.cmbListaDePrecios = New Eniac.Controles.ComboBox()
        Me.cmbFechaBaseProximaCuota = New Eniac.Controles.ComboBox()
        Me.chbArchivoEmbebido = New Eniac.Controles.CheckBox()
        Me.chbAplicanOfertas = New Eniac.Controles.CheckBox()
        Me.lblDescripcionFormaPago = New Eniac.Controles.Label()
        Me.txtFormaPago = New Eniac.Controles.TextBox()
        Me.grpRequiere.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(325, 455)
        Me.btnAceptar.TabIndex = 35
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(411, 455)
        Me.btnCancelar.TabIndex = 36
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(224, 455)
        Me.btnCopiar.TabIndex = 38
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(143, 455)
        Me.btnAplicar.TabIndex = 37
        '
        'txtIdFormasPago
        '
        Me.txtIdFormasPago.BindearPropiedadControl = "Text"
        Me.txtIdFormasPago.BindearPropiedadEntidad = "IdFormasPago"
        Me.txtIdFormasPago.ForeColorFocus = System.Drawing.Color.Red
        Me.txtIdFormasPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtIdFormasPago.Formato = ""
        Me.txtIdFormasPago.IsDecimal = False
        Me.txtIdFormasPago.IsNumber = True
        Me.txtIdFormasPago.IsPK = True
        Me.txtIdFormasPago.IsRequired = True
        Me.txtIdFormasPago.Key = ""
        Me.txtIdFormasPago.LabelAsoc = Me.lblIdFormasPago
        Me.txtIdFormasPago.Location = New System.Drawing.Point(149, 19)
        Me.txtIdFormasPago.MaxLength = 4
        Me.txtIdFormasPago.Name = "txtIdFormasPago"
        Me.txtIdFormasPago.Size = New System.Drawing.Size(46, 20)
        Me.txtIdFormasPago.TabIndex = 1
        Me.txtIdFormasPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIdFormasPago
        '
        Me.lblIdFormasPago.AutoSize = True
        Me.lblIdFormasPago.LabelAsoc = Nothing
        Me.lblIdFormasPago.Location = New System.Drawing.Point(10, 22)
        Me.lblIdFormasPago.Name = "lblIdFormasPago"
        Me.lblIdFormasPago.Size = New System.Drawing.Size(40, 13)
        Me.lblIdFormasPago.TabIndex = 0
        Me.lblIdFormasPago.Text = "Codigo"
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.LabelAsoc = Nothing
        Me.lblDias.Location = New System.Drawing.Point(10, 100)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(30, 13)
        Me.lblDias.TabIndex = 4
        Me.lblDias.Text = "Días"
        '
        'txtDias
        '
        Me.txtDias.BindearPropiedadControl = "Text"
        Me.txtDias.BindearPropiedadEntidad = "Dias"
        Me.txtDias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDias.Formato = ""
        Me.txtDias.IsDecimal = False
        Me.txtDias.IsNumber = True
        Me.txtDias.IsPK = False
        Me.txtDias.IsRequired = True
        Me.txtDias.Key = ""
        Me.txtDias.LabelAsoc = Me.lblDias
        Me.txtDias.Location = New System.Drawing.Point(149, 96)
        Me.txtDias.MaxLength = 4
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(46, 20)
        Me.txtDias.TabIndex = 5
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombreFormasPago
        '
        Me.lblNombreFormasPago.AutoSize = True
        Me.lblNombreFormasPago.LabelAsoc = Nothing
        Me.lblNombreFormasPago.Location = New System.Drawing.Point(10, 48)
        Me.lblNombreFormasPago.Name = "lblNombreFormasPago"
        Me.lblNombreFormasPago.Size = New System.Drawing.Size(119, 13)
        Me.lblNombreFormasPago.TabIndex = 2
        Me.lblNombreFormasPago.Text = "Nombre Forma de Pago"
        '
        'txtDescripcionFormasPago
        '
        Me.txtDescripcionFormasPago.BindearPropiedadControl = "Text"
        Me.txtDescripcionFormasPago.BindearPropiedadEntidad = "DescripcionFormasPago"
        Me.txtDescripcionFormasPago.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDescripcionFormasPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDescripcionFormasPago.Formato = ""
        Me.txtDescripcionFormasPago.IsDecimal = False
        Me.txtDescripcionFormasPago.IsNumber = False
        Me.txtDescripcionFormasPago.IsPK = False
        Me.txtDescripcionFormasPago.IsRequired = True
        Me.txtDescripcionFormasPago.Key = ""
        Me.txtDescripcionFormasPago.LabelAsoc = Me.lblNombreFormasPago
        Me.txtDescripcionFormasPago.Location = New System.Drawing.Point(149, 45)
        Me.txtDescripcionFormasPago.MaxLength = 50
        Me.txtDescripcionFormasPago.Name = "txtDescripcionFormasPago"
        Me.txtDescripcionFormasPago.Size = New System.Drawing.Size(263, 20)
        Me.txtDescripcionFormasPago.TabIndex = 3
        '
        'lblOrdenVentas
        '
        Me.lblOrdenVentas.AutoSize = True
        Me.lblOrdenVentas.LabelAsoc = Nothing
        Me.lblOrdenVentas.Location = New System.Drawing.Point(10, 126)
        Me.lblOrdenVentas.Name = "lblOrdenVentas"
        Me.lblOrdenVentas.Size = New System.Drawing.Size(87, 13)
        Me.lblOrdenVentas.TabIndex = 10
        Me.lblOrdenVentas.Text = "Orden de Ventas"
        '
        'txtOrdenVentas
        '
        Me.txtOrdenVentas.BindearPropiedadControl = "Text"
        Me.txtOrdenVentas.BindearPropiedadEntidad = "OrdenVentas"
        Me.txtOrdenVentas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenVentas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenVentas.Formato = ""
        Me.txtOrdenVentas.IsDecimal = False
        Me.txtOrdenVentas.IsNumber = True
        Me.txtOrdenVentas.IsPK = False
        Me.txtOrdenVentas.IsRequired = True
        Me.txtOrdenVentas.Key = ""
        Me.txtOrdenVentas.LabelAsoc = Me.lblOrdenVentas
        Me.txtOrdenVentas.Location = New System.Drawing.Point(149, 122)
        Me.txtOrdenVentas.MaxLength = 2
        Me.txtOrdenVentas.Name = "txtOrdenVentas"
        Me.txtOrdenVentas.Size = New System.Drawing.Size(29, 20)
        Me.txtOrdenVentas.TabIndex = 11
        Me.txtOrdenVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrdenCompras
        '
        Me.lblOrdenCompras.AutoSize = True
        Me.lblOrdenCompras.LabelAsoc = Nothing
        Me.lblOrdenCompras.Location = New System.Drawing.Point(210, 126)
        Me.lblOrdenCompras.Name = "lblOrdenCompras"
        Me.lblOrdenCompras.Size = New System.Drawing.Size(95, 13)
        Me.lblOrdenCompras.TabIndex = 12
        Me.lblOrdenCompras.Text = "Orden de Compras"
        '
        'txtOrdenCompras
        '
        Me.txtOrdenCompras.BindearPropiedadControl = "Text"
        Me.txtOrdenCompras.BindearPropiedadEntidad = "OrdenCompras"
        Me.txtOrdenCompras.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenCompras.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenCompras.Formato = ""
        Me.txtOrdenCompras.IsDecimal = False
        Me.txtOrdenCompras.IsNumber = True
        Me.txtOrdenCompras.IsPK = False
        Me.txtOrdenCompras.IsRequired = True
        Me.txtOrdenCompras.Key = ""
        Me.txtOrdenCompras.LabelAsoc = Me.lblOrdenCompras
        Me.txtOrdenCompras.Location = New System.Drawing.Point(311, 122)
        Me.txtOrdenCompras.MaxLength = 2
        Me.txtOrdenCompras.Name = "txtOrdenCompras"
        Me.txtOrdenCompras.Size = New System.Drawing.Size(29, 20)
        Me.txtOrdenCompras.TabIndex = 13
        Me.txtOrdenCompras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOrdenFichas
        '
        Me.lblOrdenFichas.AutoSize = True
        Me.lblOrdenFichas.LabelAsoc = Nothing
        Me.lblOrdenFichas.Location = New System.Drawing.Point(363, 126)
        Me.lblOrdenFichas.Name = "lblOrdenFichas"
        Me.lblOrdenFichas.Size = New System.Drawing.Size(85, 13)
        Me.lblOrdenFichas.TabIndex = 14
        Me.lblOrdenFichas.Text = "Orden de Fichas"
        '
        'txtOrdenFichas
        '
        Me.txtOrdenFichas.BindearPropiedadControl = "Text"
        Me.txtOrdenFichas.BindearPropiedadEntidad = "OrdenFichas"
        Me.txtOrdenFichas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrdenFichas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrdenFichas.Formato = ""
        Me.txtOrdenFichas.IsDecimal = False
        Me.txtOrdenFichas.IsNumber = True
        Me.txtOrdenFichas.IsPK = False
        Me.txtOrdenFichas.IsRequired = True
        Me.txtOrdenFichas.Key = ""
        Me.txtOrdenFichas.LabelAsoc = Me.lblOrdenFichas
        Me.txtOrdenFichas.Location = New System.Drawing.Point(456, 122)
        Me.txtOrdenFichas.MaxLength = 2
        Me.txtOrdenFichas.Name = "txtOrdenFichas"
        Me.txtOrdenFichas.Size = New System.Drawing.Size(29, 20)
        Me.txtOrdenFichas.TabIndex = 15
        Me.txtOrdenFichas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidadCuotas
        '
        Me.lblCantidadCuotas.AutoSize = True
        Me.lblCantidadCuotas.LabelAsoc = Nothing
        Me.lblCantidadCuotas.Location = New System.Drawing.Point(210, 100)
        Me.lblCantidadCuotas.Name = "lblCantidadCuotas"
        Me.lblCantidadCuotas.Size = New System.Drawing.Size(85, 13)
        Me.lblCantidadCuotas.TabIndex = 6
        Me.lblCantidadCuotas.Text = "Cantidad Cuotas"
        '
        'txtDiasPrimerCuota
        '
        Me.txtDiasPrimerCuota.BindearPropiedadControl = "Text"
        Me.txtDiasPrimerCuota.BindearPropiedadEntidad = "DiasPrimerCuota"
        Me.txtDiasPrimerCuota.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDiasPrimerCuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDiasPrimerCuota.Formato = ""
        Me.txtDiasPrimerCuota.IsDecimal = False
        Me.txtDiasPrimerCuota.IsNumber = True
        Me.txtDiasPrimerCuota.IsPK = False
        Me.txtDiasPrimerCuota.IsRequired = True
        Me.txtDiasPrimerCuota.Key = ""
        Me.txtDiasPrimerCuota.LabelAsoc = Me.lblOrdenFichas
        Me.txtDiasPrimerCuota.Location = New System.Drawing.Point(456, 96)
        Me.txtDiasPrimerCuota.MaxLength = 3
        Me.txtDiasPrimerCuota.Name = "txtDiasPrimerCuota"
        Me.txtDiasPrimerCuota.Size = New System.Drawing.Size(29, 20)
        Me.txtDiasPrimerCuota.TabIndex = 9
        Me.txtDiasPrimerCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCantidadCuotas
        '
        Me.txtCantidadCuotas.BindearPropiedadControl = "Text"
        Me.txtCantidadCuotas.BindearPropiedadEntidad = "CantidadCuotas"
        Me.txtCantidadCuotas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadCuotas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadCuotas.Formato = ""
        Me.txtCantidadCuotas.IsDecimal = False
        Me.txtCantidadCuotas.IsNumber = True
        Me.txtCantidadCuotas.IsPK = False
        Me.txtCantidadCuotas.IsRequired = True
        Me.txtCantidadCuotas.Key = ""
        Me.txtCantidadCuotas.LabelAsoc = Me.lblOrdenVentas
        Me.txtCantidadCuotas.Location = New System.Drawing.Point(311, 96)
        Me.txtCantidadCuotas.MaxLength = 4
        Me.txtCantidadCuotas.Name = "txtCantidadCuotas"
        Me.txtCantidadCuotas.Size = New System.Drawing.Size(29, 20)
        Me.txtCantidadCuotas.TabIndex = 7
        Me.txtCantidadCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDiasPrimerCuota
        '
        Me.lblDiasPrimerCuota.AutoSize = True
        Me.lblDiasPrimerCuota.LabelAsoc = Nothing
        Me.lblDiasPrimerCuota.Location = New System.Drawing.Point(363, 100)
        Me.lblDiasPrimerCuota.Name = "lblDiasPrimerCuota"
        Me.lblDiasPrimerCuota.Size = New System.Drawing.Size(89, 13)
        Me.lblDiasPrimerCuota.TabIndex = 8
        Me.lblDiasPrimerCuota.Text = "Dias primer cuota"
        '
        'lblFechaBaseProximaCuota
        '
        Me.lblFechaBaseProximaCuota.AutoSize = True
        Me.lblFechaBaseProximaCuota.LabelAsoc = Nothing
        Me.lblFechaBaseProximaCuota.Location = New System.Drawing.Point(10, 174)
        Me.lblFechaBaseProximaCuota.Name = "lblFechaBaseProximaCuota"
        Me.lblFechaBaseProximaCuota.Size = New System.Drawing.Size(135, 13)
        Me.lblFechaBaseProximaCuota.TabIndex = 20
        Me.lblFechaBaseProximaCuota.Text = "Fecha Base Próxima Cuota"
        '
        'chbExcluyeSabados
        '
        Me.chbExcluyeSabados.AutoSize = True
        Me.chbExcluyeSabados.BindearPropiedadControl = "Checked"
        Me.chbExcluyeSabados.BindearPropiedadEntidad = "ExcluyeSabados"
        Me.chbExcluyeSabados.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluyeSabados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluyeSabados.IsPK = False
        Me.chbExcluyeSabados.IsRequired = False
        Me.chbExcluyeSabados.Key = Nothing
        Me.chbExcluyeSabados.LabelAsoc = Nothing
        Me.chbExcluyeSabados.Location = New System.Drawing.Point(149, 148)
        Me.chbExcluyeSabados.Name = "chbExcluyeSabados"
        Me.chbExcluyeSabados.Size = New System.Drawing.Size(68, 17)
        Me.chbExcluyeSabados.TabIndex = 17
        Me.chbExcluyeSabados.Text = "Sábados"
        Me.chbExcluyeSabados.UseVisualStyleBackColor = True
        '
        'chbExcluyeDomingos
        '
        Me.chbExcluyeDomingos.AutoSize = True
        Me.chbExcluyeDomingos.BindearPropiedadControl = "Checked"
        Me.chbExcluyeDomingos.BindearPropiedadEntidad = "ExcluyeDomingos"
        Me.chbExcluyeDomingos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluyeDomingos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluyeDomingos.IsPK = False
        Me.chbExcluyeDomingos.IsRequired = False
        Me.chbExcluyeDomingos.Key = Nothing
        Me.chbExcluyeDomingos.LabelAsoc = Nothing
        Me.chbExcluyeDomingos.Location = New System.Drawing.Point(246, 148)
        Me.chbExcluyeDomingos.Name = "chbExcluyeDomingos"
        Me.chbExcluyeDomingos.Size = New System.Drawing.Size(73, 17)
        Me.chbExcluyeDomingos.TabIndex = 18
        Me.chbExcluyeDomingos.Text = "Domingos"
        Me.chbExcluyeDomingos.UseVisualStyleBackColor = True
        '
        'chbExcluyeFeriados
        '
        Me.chbExcluyeFeriados.AutoSize = True
        Me.chbExcluyeFeriados.BindearPropiedadControl = "Checked"
        Me.chbExcluyeFeriados.BindearPropiedadEntidad = "ExcluyeFeriados"
        Me.chbExcluyeFeriados.ForeColorFocus = System.Drawing.Color.Red
        Me.chbExcluyeFeriados.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbExcluyeFeriados.IsPK = False
        Me.chbExcluyeFeriados.IsRequired = False
        Me.chbExcluyeFeriados.Key = Nothing
        Me.chbExcluyeFeriados.LabelAsoc = Nothing
        Me.chbExcluyeFeriados.Location = New System.Drawing.Point(346, 148)
        Me.chbExcluyeFeriados.Name = "chbExcluyeFeriados"
        Me.chbExcluyeFeriados.Size = New System.Drawing.Size(66, 17)
        Me.chbExcluyeFeriados.TabIndex = 19
        Me.chbExcluyeFeriados.Text = "Feriados"
        Me.chbExcluyeFeriados.UseVisualStyleBackColor = True
        '
        'lblExcluye
        '
        Me.lblExcluye.AutoSize = True
        Me.lblExcluye.LabelAsoc = Nothing
        Me.lblExcluye.Location = New System.Drawing.Point(10, 149)
        Me.lblExcluye.Name = "lblExcluye"
        Me.lblExcluye.Size = New System.Drawing.Size(44, 13)
        Me.lblExcluye.TabIndex = 16
        Me.lblExcluye.Text = "Excluye"
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.LabelAsoc = Nothing
        Me.lblPorcentaje.Location = New System.Drawing.Point(10, 201)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(68, 13)
        Me.lblPorcentaje.TabIndex = 22
        Me.lblPorcentaje.Text = "D/R General"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BindearPropiedadControl = "Text"
        Me.txtPorcentaje.BindearPropiedadEntidad = "Porcentaje"
        Me.txtPorcentaje.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcentaje.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcentaje.Formato = ""
        Me.txtPorcentaje.IsDecimal = True
        Me.txtPorcentaje.IsNumber = True
        Me.txtPorcentaje.IsPK = False
        Me.txtPorcentaje.IsRequired = True
        Me.txtPorcentaje.Key = ""
        Me.txtPorcentaje.LabelAsoc = Me.lblPorcentaje
        Me.txtPorcentaje.Location = New System.Drawing.Point(149, 198)
        Me.txtPorcentaje.MaxLength = 4
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(46, 20)
        Me.txtPorcentaje.TabIndex = 23
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPorcentaje2
        '
        Me.lblPorcentaje2.AutoSize = True
        Me.lblPorcentaje2.LabelAsoc = Nothing
        Me.lblPorcentaje2.Location = New System.Drawing.Point(201, 203)
        Me.lblPorcentaje2.Name = "lblPorcentaje2"
        Me.lblPorcentaje2.Size = New System.Drawing.Size(15, 13)
        Me.lblPorcentaje2.TabIndex = 24
        Me.lblPorcentaje2.Text = "%"
        '
        'grpRequiere
        '
        Me.grpRequiere.Controls.Add(Me.chbRequiereTarjetaCredito1Pago)
        Me.grpRequiere.Controls.Add(Me.chbRequiereTarjetaCredito)
        Me.grpRequiere.Controls.Add(Me.chbRequiereTarjetaDebito)
        Me.grpRequiere.Controls.Add(Me.chbRequiereCheques)
        Me.grpRequiere.Controls.Add(Me.chbRequiereTransferencia)
        Me.grpRequiere.Controls.Add(Me.chbRequiereTickets)
        Me.grpRequiere.Controls.Add(Me.chbRequiereDolares)
        Me.grpRequiere.Controls.Add(Me.chbRequierePesos)
        Me.grpRequiere.Location = New System.Drawing.Point(14, 368)
        Me.grpRequiere.Name = "grpRequiere"
        Me.grpRequiere.Size = New System.Drawing.Size(475, 79)
        Me.grpRequiere.TabIndex = 34
        Me.grpRequiere.TabStop = False
        Me.grpRequiere.Text = "Requiere al menos uno de los siguientes Medios de Pago"
        '
        'chbRequiereTarjetaCredito1Pago
        '
        Me.chbRequiereTarjetaCredito1Pago.AutoSize = True
        Me.chbRequiereTarjetaCredito1Pago.BindearPropiedadControl = "Checked"
        Me.chbRequiereTarjetaCredito1Pago.BindearPropiedadEntidad = "RequiereTarjetaCredito1Pago"
        Me.chbRequiereTarjetaCredito1Pago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereTarjetaCredito1Pago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereTarjetaCredito1Pago.IsPK = False
        Me.chbRequiereTarjetaCredito1Pago.IsRequired = False
        Me.chbRequiereTarjetaCredito1Pago.Key = Nothing
        Me.chbRequiereTarjetaCredito1Pago.LabelAsoc = Nothing
        Me.chbRequiereTarjetaCredito1Pago.Location = New System.Drawing.Point(322, 50)
        Me.chbRequiereTarjetaCredito1Pago.Name = "chbRequiereTarjetaCredito1Pago"
        Me.chbRequiereTarjetaCredito1Pago.Size = New System.Drawing.Size(146, 17)
        Me.chbRequiereTarjetaCredito1Pago.TabIndex = 7
        Me.chbRequiereTarjetaCredito1Pago.Text = "Tarjeta de Crédito 1 pago"
        Me.chbRequiereTarjetaCredito1Pago.UseVisualStyleBackColor = True
        '
        'chbRequiereTarjetaCredito
        '
        Me.chbRequiereTarjetaCredito.AutoSize = True
        Me.chbRequiereTarjetaCredito.BindearPropiedadControl = "Checked"
        Me.chbRequiereTarjetaCredito.BindearPropiedadEntidad = "RequiereTarjetaCredito"
        Me.chbRequiereTarjetaCredito.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereTarjetaCredito.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereTarjetaCredito.IsPK = False
        Me.chbRequiereTarjetaCredito.IsRequired = False
        Me.chbRequiereTarjetaCredito.Key = Nothing
        Me.chbRequiereTarjetaCredito.LabelAsoc = Nothing
        Me.chbRequiereTarjetaCredito.Location = New System.Drawing.Point(210, 50)
        Me.chbRequiereTarjetaCredito.Name = "chbRequiereTarjetaCredito"
        Me.chbRequiereTarjetaCredito.Size = New System.Drawing.Size(110, 17)
        Me.chbRequiereTarjetaCredito.TabIndex = 6
        Me.chbRequiereTarjetaCredito.Text = "Tarjeta de Crédito"
        Me.chbRequiereTarjetaCredito.UseVisualStyleBackColor = True
        '
        'chbRequiereTarjetaDebito
        '
        Me.chbRequiereTarjetaDebito.AutoSize = True
        Me.chbRequiereTarjetaDebito.BindearPropiedadControl = "Checked"
        Me.chbRequiereTarjetaDebito.BindearPropiedadEntidad = "RequiereTarjetaDebito"
        Me.chbRequiereTarjetaDebito.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereTarjetaDebito.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereTarjetaDebito.IsPK = False
        Me.chbRequiereTarjetaDebito.IsRequired = False
        Me.chbRequiereTarjetaDebito.Key = Nothing
        Me.chbRequiereTarjetaDebito.LabelAsoc = Nothing
        Me.chbRequiereTarjetaDebito.Location = New System.Drawing.Point(89, 50)
        Me.chbRequiereTarjetaDebito.Name = "chbRequiereTarjetaDebito"
        Me.chbRequiereTarjetaDebito.Size = New System.Drawing.Size(108, 17)
        Me.chbRequiereTarjetaDebito.TabIndex = 5
        Me.chbRequiereTarjetaDebito.Text = "Tarjeta de Débito"
        Me.chbRequiereTarjetaDebito.UseVisualStyleBackColor = True
        '
        'chbRequiereCheques
        '
        Me.chbRequiereCheques.AutoSize = True
        Me.chbRequiereCheques.BindearPropiedadControl = "Checked"
        Me.chbRequiereCheques.BindearPropiedadEntidad = "RequiereCheques"
        Me.chbRequiereCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereCheques.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereCheques.IsPK = False
        Me.chbRequiereCheques.IsRequired = False
        Me.chbRequiereCheques.Key = Nothing
        Me.chbRequiereCheques.LabelAsoc = Nothing
        Me.chbRequiereCheques.Location = New System.Drawing.Point(14, 50)
        Me.chbRequiereCheques.Name = "chbRequiereCheques"
        Me.chbRequiereCheques.Size = New System.Drawing.Size(68, 17)
        Me.chbRequiereCheques.TabIndex = 4
        Me.chbRequiereCheques.Text = "Cheques"
        Me.chbRequiereCheques.UseVisualStyleBackColor = True
        '
        'chbRequiereTransferencia
        '
        Me.chbRequiereTransferencia.AutoSize = True
        Me.chbRequiereTransferencia.BindearPropiedadControl = "Checked"
        Me.chbRequiereTransferencia.BindearPropiedadEntidad = "RequiereTransferencia"
        Me.chbRequiereTransferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereTransferencia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereTransferencia.IsPK = False
        Me.chbRequiereTransferencia.IsRequired = False
        Me.chbRequiereTransferencia.Key = Nothing
        Me.chbRequiereTransferencia.LabelAsoc = Nothing
        Me.chbRequiereTransferencia.Location = New System.Drawing.Point(322, 24)
        Me.chbRequiereTransferencia.Name = "chbRequiereTransferencia"
        Me.chbRequiereTransferencia.Size = New System.Drawing.Size(91, 17)
        Me.chbRequiereTransferencia.TabIndex = 3
        Me.chbRequiereTransferencia.Text = "Transferencia"
        Me.chbRequiereTransferencia.UseVisualStyleBackColor = True
        '
        'chbRequiereTickets
        '
        Me.chbRequiereTickets.AutoSize = True
        Me.chbRequiereTickets.BindearPropiedadControl = "Checked"
        Me.chbRequiereTickets.BindearPropiedadEntidad = "RequiereTickets"
        Me.chbRequiereTickets.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereTickets.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereTickets.IsPK = False
        Me.chbRequiereTickets.IsRequired = False
        Me.chbRequiereTickets.Key = Nothing
        Me.chbRequiereTickets.LabelAsoc = Nothing
        Me.chbRequiereTickets.Location = New System.Drawing.Point(211, 24)
        Me.chbRequiereTickets.Name = "chbRequiereTickets"
        Me.chbRequiereTickets.Size = New System.Drawing.Size(61, 17)
        Me.chbRequiereTickets.TabIndex = 2
        Me.chbRequiereTickets.Text = "Tickets"
        Me.chbRequiereTickets.UseVisualStyleBackColor = True
        '
        'chbRequiereDolares
        '
        Me.chbRequiereDolares.AutoSize = True
        Me.chbRequiereDolares.BindearPropiedadControl = "Checked"
        Me.chbRequiereDolares.BindearPropiedadEntidad = "RequiereDolares"
        Me.chbRequiereDolares.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequiereDolares.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequiereDolares.IsPK = False
        Me.chbRequiereDolares.IsRequired = False
        Me.chbRequiereDolares.Key = Nothing
        Me.chbRequiereDolares.LabelAsoc = Nothing
        Me.chbRequiereDolares.Location = New System.Drawing.Point(89, 24)
        Me.chbRequiereDolares.Name = "chbRequiereDolares"
        Me.chbRequiereDolares.Size = New System.Drawing.Size(62, 17)
        Me.chbRequiereDolares.TabIndex = 1
        Me.chbRequiereDolares.Text = "Dólares"
        Me.chbRequiereDolares.UseVisualStyleBackColor = True
        Me.chbRequiereDolares.Visible = False
        '
        'chbRequierePesos
        '
        Me.chbRequierePesos.AutoSize = True
        Me.chbRequierePesos.BindearPropiedadControl = "Checked"
        Me.chbRequierePesos.BindearPropiedadEntidad = "RequierePesos"
        Me.chbRequierePesos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRequierePesos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRequierePesos.IsPK = False
        Me.chbRequierePesos.IsRequired = False
        Me.chbRequierePesos.Key = Nothing
        Me.chbRequierePesos.LabelAsoc = Nothing
        Me.chbRequierePesos.Location = New System.Drawing.Point(14, 24)
        Me.chbRequierePesos.Name = "chbRequierePesos"
        Me.chbRequierePesos.Size = New System.Drawing.Size(55, 17)
        Me.chbRequierePesos.TabIndex = 0
        Me.chbRequierePesos.Text = "Pesos"
        Me.chbRequierePesos.UseVisualStyleBackColor = True
        '
        'chbListaDePrecios
        '
        Me.chbListaDePrecios.AutoSize = True
        Me.chbListaDePrecios.BindearPropiedadControl = ""
        Me.chbListaDePrecios.BindearPropiedadEntidad = ""
        Me.chbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.chbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbListaDePrecios.IsPK = False
        Me.chbListaDePrecios.IsRequired = False
        Me.chbListaDePrecios.Key = Nothing
        Me.chbListaDePrecios.LabelAsoc = Nothing
        Me.chbListaDePrecios.Location = New System.Drawing.Point(13, 226)
        Me.chbListaDePrecios.Name = "chbListaDePrecios"
        Me.chbListaDePrecios.Size = New System.Drawing.Size(101, 17)
        Me.chbListaDePrecios.TabIndex = 25
        Me.chbListaDePrecios.Text = "Lista de Precios"
        Me.chbListaDePrecios.UseVisualStyleBackColor = True
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.BindearPropiedadControl = ""
        Me.chbTipoComprobante.BindearPropiedadEntidad = ""
        Me.chbTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobante.IsPK = False
        Me.chbTipoComprobante.IsRequired = False
        Me.chbTipoComprobante.Key = Nothing
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(13, 253)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(172, 17)
        Me.chbTipoComprobante.TabIndex = 27
        Me.chbTipoComprobante.Text = "Tipo Comprobante Facturacion"
        Me.chbTipoComprobante.UseVisualStyleBackColor = True
        '
        'chbTipoComprobanteFR
        '
        Me.chbTipoComprobanteFR.AutoSize = True
        Me.chbTipoComprobanteFR.BindearPropiedadControl = ""
        Me.chbTipoComprobanteFR.BindearPropiedadEntidad = ""
        Me.chbTipoComprobanteFR.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoComprobanteFR.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoComprobanteFR.IsPK = False
        Me.chbTipoComprobanteFR.IsRequired = False
        Me.chbTipoComprobanteFR.Key = Nothing
        Me.chbTipoComprobanteFR.LabelAsoc = Nothing
        Me.chbTipoComprobanteFR.Location = New System.Drawing.Point(13, 280)
        Me.chbTipoComprobanteFR.Name = "chbTipoComprobanteFR"
        Me.chbTipoComprobanteFR.Size = New System.Drawing.Size(209, 17)
        Me.chbTipoComprobanteFR.TabIndex = 29
        Me.chbTipoComprobanteFR.Text = "Tipo Comprobante Facturacion Rapida"
        Me.chbTipoComprobanteFR.UseVisualStyleBackColor = True
        '
        'bscCuentaBancariaTransfBanc
        '
        Me.bscCuentaBancariaTransfBanc.ActivarFiltroEnGrilla = True
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaTransfBanc.ConfigBuscador = Nothing
        Me.bscCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCuentaBancariaTransfBanc.IsPK = False
        Me.bscCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCuentaBancariaTransfBanc.Key = ""
        Me.bscCuentaBancariaTransfBanc.LabelAsoc = Me.chbCuentaBancaria
        Me.bscCuentaBancariaTransfBanc.Location = New System.Drawing.Point(246, 305)
        Me.bscCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCuentaBancariaTransfBanc.Name = "bscCuentaBancariaTransfBanc"
        Me.bscCuentaBancariaTransfBanc.Permitido = False
        Me.bscCuentaBancariaTransfBanc.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCuentaBancariaTransfBanc.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancariaTransfBanc.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCuentaBancariaTransfBanc.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCuentaBancariaTransfBanc.Size = New System.Drawing.Size(239, 20)
        Me.bscCuentaBancariaTransfBanc.TabIndex = 33
        '
        'chbCuentaBancaria
        '
        Me.chbCuentaBancaria.AutoSize = True
        Me.chbCuentaBancaria.BindearPropiedadControl = Nothing
        Me.chbCuentaBancaria.BindearPropiedadEntidad = Nothing
        Me.chbCuentaBancaria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCuentaBancaria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCuentaBancaria.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbCuentaBancaria.IsPK = False
        Me.chbCuentaBancaria.IsRequired = False
        Me.chbCuentaBancaria.Key = Nothing
        Me.chbCuentaBancaria.LabelAsoc = Nothing
        Me.chbCuentaBancaria.Location = New System.Drawing.Point(13, 309)
        Me.chbCuentaBancaria.Name = "chbCuentaBancaria"
        Me.chbCuentaBancaria.Size = New System.Drawing.Size(201, 17)
        Me.chbCuentaBancaria.TabIndex = 32
        Me.chbCuentaBancaria.Text = "Cuenta Bancaria para cobro contado"
        Me.ToolTip1.SetToolTip(Me.chbCuentaBancaria, resources.GetString("chbCuentaBancaria.ToolTip"))
        '
        'chbArchivoComplementario
        '
        Me.chbArchivoComplementario.AutoSize = True
        Me.chbArchivoComplementario.BindearPropiedadControl = Nothing
        Me.chbArchivoComplementario.BindearPropiedadEntidad = Nothing
        Me.chbArchivoComplementario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbArchivoComplementario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbArchivoComplementario.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbArchivoComplementario.IsPK = False
        Me.chbArchivoComplementario.IsRequired = False
        Me.chbArchivoComplementario.Key = Nothing
        Me.chbArchivoComplementario.LabelAsoc = Nothing
        Me.chbArchivoComplementario.Location = New System.Drawing.Point(13, 336)
        Me.chbArchivoComplementario.Name = "chbArchivoComplementario"
        Me.chbArchivoComplementario.Size = New System.Drawing.Size(187, 17)
        Me.chbArchivoComplementario.TabIndex = 39
        Me.chbArchivoComplementario.Text = "Archivo a Imprimir Complementario"
        Me.ToolTip1.SetToolTip(Me.chbArchivoComplementario, resources.GetString("chbArchivoComplementario.ToolTip"))
        '
        'bscCodigoCuentaBancariaTransfBanc
        '
        Me.bscCodigoCuentaBancariaTransfBanc.ActivarFiltroEnGrilla = True
        Me.bscCodigoCuentaBancariaTransfBanc.BindearPropiedadControl = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ConfigBuscador = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.Datos = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.FilaDevuelta = Nothing
        Me.bscCodigoCuentaBancariaTransfBanc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCuentaBancariaTransfBanc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCuentaBancariaTransfBanc.IsDecimal = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsNumber = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsPK = False
        Me.bscCodigoCuentaBancariaTransfBanc.IsRequired = False
        Me.bscCodigoCuentaBancariaTransfBanc.Key = ""
        Me.bscCodigoCuentaBancariaTransfBanc.LabelAsoc = Me.chbCuentaBancaria
        Me.bscCodigoCuentaBancariaTransfBanc.Location = New System.Drawing.Point(419, 280)
        Me.bscCodigoCuentaBancariaTransfBanc.MaxLengh = "32767"
        Me.bscCodigoCuentaBancariaTransfBanc.Name = "bscCodigoCuentaBancariaTransfBanc"
        Me.bscCodigoCuentaBancariaTransfBanc.Permitido = True
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCuentaBancariaTransfBanc.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCuentaBancariaTransfBanc.Selecciono = False
        Me.bscCodigoCuentaBancariaTransfBanc.Size = New System.Drawing.Size(66, 20)
        Me.bscCodigoCuentaBancariaTransfBanc.TabIndex = 31
        Me.bscCodigoCuentaBancariaTransfBanc.Visible = False
        '
        'txtArchivoComplementario
        '
        Me.txtArchivoComplementario.BindearPropiedadControl = "Text"
        Me.txtArchivoComplementario.BindearPropiedadEntidad = "ArchivoComplementario"
        Me.txtArchivoComplementario.Enabled = False
        Me.txtArchivoComplementario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtArchivoComplementario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtArchivoComplementario.Formato = ""
        Me.txtArchivoComplementario.IsDecimal = False
        Me.txtArchivoComplementario.IsNumber = False
        Me.txtArchivoComplementario.IsPK = False
        Me.txtArchivoComplementario.IsRequired = False
        Me.txtArchivoComplementario.Key = ""
        Me.txtArchivoComplementario.LabelAsoc = Me.chbArchivoComplementario
        Me.txtArchivoComplementario.Location = New System.Drawing.Point(204, 334)
        Me.txtArchivoComplementario.MaxLength = 50
        Me.txtArchivoComplementario.Name = "txtArchivoComplementario"
        Me.txtArchivoComplementario.Size = New System.Drawing.Size(208, 20)
        Me.txtArchivoComplementario.TabIndex = 40
        '
        'cmbTipoComprobantesFR
        '
        Me.cmbTipoComprobantesFR.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoComprobantesFR.BindearPropiedadEntidad = "IdTipoComprobantesFR"
        Me.cmbTipoComprobantesFR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobantesFR.Enabled = False
        Me.cmbTipoComprobantesFR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoComprobantesFR.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobantesFR.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobantesFR.FormattingEnabled = True
        Me.cmbTipoComprobantesFR.IsPK = False
        Me.cmbTipoComprobantesFR.IsRequired = False
        Me.cmbTipoComprobantesFR.Key = Nothing
        Me.cmbTipoComprobantesFR.LabelAsoc = Nothing
        Me.cmbTipoComprobantesFR.Location = New System.Drawing.Point(246, 278)
        Me.cmbTipoComprobantesFR.Name = "cmbTipoComprobantesFR"
        Me.cmbTipoComprobantesFR.Size = New System.Drawing.Size(160, 21)
        Me.cmbTipoComprobantesFR.TabIndex = 30
        '
        'cmbTipoComprobantes
        '
        Me.cmbTipoComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoComprobantes.BindearPropiedadEntidad = "IdTipoComprobantes"
        Me.cmbTipoComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobantes.Enabled = False
        Me.cmbTipoComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoComprobantes.FormattingEnabled = True
        Me.cmbTipoComprobantes.IsPK = False
        Me.cmbTipoComprobantes.IsRequired = False
        Me.cmbTipoComprobantes.Key = Nothing
        Me.cmbTipoComprobantes.LabelAsoc = Nothing
        Me.cmbTipoComprobantes.Location = New System.Drawing.Point(246, 251)
        Me.cmbTipoComprobantes.Name = "cmbTipoComprobantes"
        Me.cmbTipoComprobantes.Size = New System.Drawing.Size(160, 21)
        Me.cmbTipoComprobantes.TabIndex = 28
        '
        'cmbListaDePrecios
        '
        Me.cmbListaDePrecios.BindearPropiedadControl = "SelectedValue"
        Me.cmbListaDePrecios.BindearPropiedadEntidad = "IdListaPrecios"
        Me.cmbListaDePrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbListaDePrecios.Enabled = False
        Me.cmbListaDePrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbListaDePrecios.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbListaDePrecios.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbListaDePrecios.FormattingEnabled = True
        Me.cmbListaDePrecios.IsPK = False
        Me.cmbListaDePrecios.IsRequired = False
        Me.cmbListaDePrecios.Key = Nothing
        Me.cmbListaDePrecios.LabelAsoc = Nothing
        Me.cmbListaDePrecios.Location = New System.Drawing.Point(149, 224)
        Me.cmbListaDePrecios.Name = "cmbListaDePrecios"
        Me.cmbListaDePrecios.Size = New System.Drawing.Size(160, 21)
        Me.cmbListaDePrecios.TabIndex = 26
        '
        'cmbFechaBaseProximaCuota
        '
        Me.cmbFechaBaseProximaCuota.BindearPropiedadControl = "SelectedValue"
        Me.cmbFechaBaseProximaCuota.BindearPropiedadEntidad = "FechaBaseProximaCuota"
        Me.cmbFechaBaseProximaCuota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFechaBaseProximaCuota.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFechaBaseProximaCuota.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFechaBaseProximaCuota.FormattingEnabled = True
        Me.cmbFechaBaseProximaCuota.IsPK = False
        Me.cmbFechaBaseProximaCuota.IsRequired = True
        Me.cmbFechaBaseProximaCuota.Key = Nothing
        Me.cmbFechaBaseProximaCuota.LabelAsoc = Me.lblFechaBaseProximaCuota
        Me.cmbFechaBaseProximaCuota.Location = New System.Drawing.Point(149, 171)
        Me.cmbFechaBaseProximaCuota.Name = "cmbFechaBaseProximaCuota"
        Me.cmbFechaBaseProximaCuota.Size = New System.Drawing.Size(181, 21)
        Me.cmbFechaBaseProximaCuota.TabIndex = 21
        '
        'chbArchivoEmbebido
        '
        Me.chbArchivoEmbebido.AutoSize = True
        Me.chbArchivoEmbebido.BindearPropiedadControl = "Checked"
        Me.chbArchivoEmbebido.BindearPropiedadEntidad = "ArchivoAImprimirEmbebido"
        Me.chbArchivoEmbebido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbArchivoEmbebido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbArchivoEmbebido.IsPK = False
        Me.chbArchivoEmbebido.IsRequired = False
        Me.chbArchivoEmbebido.Key = Nothing
        Me.chbArchivoEmbebido.LabelAsoc = Nothing
        Me.chbArchivoEmbebido.Location = New System.Drawing.Point(419, 337)
        Me.chbArchivoEmbebido.Name = "chbArchivoEmbebido"
        Me.chbArchivoEmbebido.Size = New System.Drawing.Size(73, 17)
        Me.chbArchivoEmbebido.TabIndex = 41
        Me.chbArchivoEmbebido.Text = "Embebido"
        Me.chbArchivoEmbebido.UseVisualStyleBackColor = True
        '
        'chbAplicanOfertas
        '
        Me.chbAplicanOfertas.AutoSize = True
        Me.chbAplicanOfertas.BindearPropiedadControl = "Checked"
        Me.chbAplicanOfertas.BindearPropiedadEntidad = "AplicanOfertas"
        Me.chbAplicanOfertas.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAplicanOfertas.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAplicanOfertas.IsPK = False
        Me.chbAplicanOfertas.IsRequired = False
        Me.chbAplicanOfertas.Key = Nothing
        Me.chbAplicanOfertas.LabelAsoc = Nothing
        Me.chbAplicanOfertas.Location = New System.Drawing.Point(241, 200)
        Me.chbAplicanOfertas.Name = "chbAplicanOfertas"
        Me.chbAplicanOfertas.Size = New System.Drawing.Size(98, 17)
        Me.chbAplicanOfertas.TabIndex = 42
        Me.chbAplicanOfertas.Text = "Aplican Ofertas"
        Me.chbAplicanOfertas.UseVisualStyleBackColor = True
        '
        'lblDescripcionFormaPago
        '
        Me.lblDescripcionFormaPago.AutoSize = True
        Me.lblDescripcionFormaPago.LabelAsoc = Nothing
        Me.lblDescripcionFormaPago.Location = New System.Drawing.Point(10, 74)
        Me.lblDescripcionFormaPago.Name = "lblDescripcionFormaPago"
        Me.lblDescripcionFormaPago.Size = New System.Drawing.Size(113, 13)
        Me.lblDescripcionFormaPago.TabIndex = 42
        Me.lblDescripcionFormaPago.Text = "Descripción Extendida"
        '
        'txtFormaPago
        '
        Me.txtFormaPago.BindearPropiedadControl = "Text"
        Me.txtFormaPago.BindearPropiedadEntidad = "Descripcion"
        Me.txtFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFormaPago.Formato = ""
        Me.txtFormaPago.IsDecimal = False
        Me.txtFormaPago.IsNumber = False
        Me.txtFormaPago.IsPK = False
        Me.txtFormaPago.IsRequired = True
        Me.txtFormaPago.Key = ""
        Me.txtFormaPago.LabelAsoc = Me.lblDescripcionFormaPago
        Me.txtFormaPago.Location = New System.Drawing.Point(149, 71)
        Me.txtFormaPago.MaxLength = 240
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.Size = New System.Drawing.Size(336, 20)
        Me.txtFormaPago.TabIndex = 43
        '
        'FormasDePagoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 497)
        Me.Controls.Add(Me.lblDescripcionFormaPago)
        Me.Controls.Add(Me.txtFormaPago)
        Me.Controls.Add(Me.chbAplicanOfertas)
        Me.Controls.Add(Me.chbArchivoEmbebido)
        Me.Controls.Add(Me.txtArchivoComplementario)
        Me.Controls.Add(Me.chbArchivoComplementario)
        Me.Controls.Add(Me.bscCodigoCuentaBancariaTransfBanc)
        Me.Controls.Add(Me.bscCuentaBancariaTransfBanc)
        Me.Controls.Add(Me.chbCuentaBancaria)
        Me.Controls.Add(Me.chbTipoComprobanteFR)
        Me.Controls.Add(Me.cmbTipoComprobantesFR)
        Me.Controls.Add(Me.chbTipoComprobante)
        Me.Controls.Add(Me.cmbTipoComprobantes)
        Me.Controls.Add(Me.chbListaDePrecios)
        Me.Controls.Add(Me.cmbListaDePrecios)
        Me.Controls.Add(Me.grpRequiere)
        Me.Controls.Add(Me.lblPorcentaje2)
        Me.Controls.Add(Me.txtPorcentaje)
        Me.Controls.Add(Me.lblPorcentaje)
        Me.Controls.Add(Me.chbExcluyeFeriados)
        Me.Controls.Add(Me.chbExcluyeDomingos)
        Me.Controls.Add(Me.chbExcluyeSabados)
        Me.Controls.Add(Me.cmbFechaBaseProximaCuota)
        Me.Controls.Add(Me.lblExcluye)
        Me.Controls.Add(Me.lblFechaBaseProximaCuota)
        Me.Controls.Add(Me.lblDiasPrimerCuota)
        Me.Controls.Add(Me.txtDiasPrimerCuota)
        Me.Controls.Add(Me.txtCantidadCuotas)
        Me.Controls.Add(Me.lblCantidadCuotas)
        Me.Controls.Add(Me.lblOrdenFichas)
        Me.Controls.Add(Me.txtOrdenFichas)
        Me.Controls.Add(Me.lblOrdenCompras)
        Me.Controls.Add(Me.txtOrdenCompras)
        Me.Controls.Add(Me.lblOrdenVentas)
        Me.Controls.Add(Me.txtOrdenVentas)
        Me.Controls.Add(Me.txtIdFormasPago)
        Me.Controls.Add(Me.lblIdFormasPago)
        Me.Controls.Add(Me.lblDias)
        Me.Controls.Add(Me.txtDias)
        Me.Controls.Add(Me.lblNombreFormasPago)
        Me.Controls.Add(Me.txtDescripcionFormasPago)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormasDePagoDetalle"
        Me.Text = "Forma De Pago "
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.txtDescripcionFormasPago, 0)
        Me.Controls.SetChildIndex(Me.lblNombreFormasPago, 0)
        Me.Controls.SetChildIndex(Me.txtDias, 0)
        Me.Controls.SetChildIndex(Me.lblDias, 0)
        Me.Controls.SetChildIndex(Me.lblIdFormasPago, 0)
        Me.Controls.SetChildIndex(Me.txtIdFormasPago, 0)
        Me.Controls.SetChildIndex(Me.txtOrdenVentas, 0)
        Me.Controls.SetChildIndex(Me.lblOrdenVentas, 0)
        Me.Controls.SetChildIndex(Me.txtOrdenCompras, 0)
        Me.Controls.SetChildIndex(Me.lblOrdenCompras, 0)
        Me.Controls.SetChildIndex(Me.txtOrdenFichas, 0)
        Me.Controls.SetChildIndex(Me.lblOrdenFichas, 0)
        Me.Controls.SetChildIndex(Me.lblCantidadCuotas, 0)
        Me.Controls.SetChildIndex(Me.txtCantidadCuotas, 0)
        Me.Controls.SetChildIndex(Me.txtDiasPrimerCuota, 0)
        Me.Controls.SetChildIndex(Me.lblDiasPrimerCuota, 0)
        Me.Controls.SetChildIndex(Me.lblFechaBaseProximaCuota, 0)
        Me.Controls.SetChildIndex(Me.lblExcluye, 0)
        Me.Controls.SetChildIndex(Me.cmbFechaBaseProximaCuota, 0)
        Me.Controls.SetChildIndex(Me.chbExcluyeSabados, 0)
        Me.Controls.SetChildIndex(Me.chbExcluyeDomingos, 0)
        Me.Controls.SetChildIndex(Me.chbExcluyeFeriados, 0)
        Me.Controls.SetChildIndex(Me.lblPorcentaje, 0)
        Me.Controls.SetChildIndex(Me.txtPorcentaje, 0)
        Me.Controls.SetChildIndex(Me.lblPorcentaje2, 0)
        Me.Controls.SetChildIndex(Me.grpRequiere, 0)
        Me.Controls.SetChildIndex(Me.cmbListaDePrecios, 0)
        Me.Controls.SetChildIndex(Me.chbListaDePrecios, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoComprobantes, 0)
        Me.Controls.SetChildIndex(Me.chbTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoComprobantesFR, 0)
        Me.Controls.SetChildIndex(Me.chbTipoComprobanteFR, 0)
        Me.Controls.SetChildIndex(Me.chbCuentaBancaria, 0)
        Me.Controls.SetChildIndex(Me.bscCuentaBancariaTransfBanc, 0)
        Me.Controls.SetChildIndex(Me.bscCodigoCuentaBancariaTransfBanc, 0)
        Me.Controls.SetChildIndex(Me.chbArchivoComplementario, 0)
        Me.Controls.SetChildIndex(Me.txtArchivoComplementario, 0)
        Me.Controls.SetChildIndex(Me.chbArchivoEmbebido, 0)
        Me.Controls.SetChildIndex(Me.chbAplicanOfertas, 0)
        Me.Controls.SetChildIndex(Me.txtFormaPago, 0)
        Me.Controls.SetChildIndex(Me.lblDescripcionFormaPago, 0)
        Me.grpRequiere.ResumeLayout(False)
        Me.grpRequiere.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdFormasPago As Eniac.Controles.TextBox
   Friend WithEvents lblIdFormasPago As Eniac.Controles.Label
   Friend WithEvents lblDias As Eniac.Controles.Label
   Friend WithEvents txtDias As Eniac.Controles.TextBox
   Friend WithEvents lblNombreFormasPago As Eniac.Controles.Label
   Friend WithEvents txtDescripcionFormasPago As Eniac.Controles.TextBox
   Friend WithEvents lblOrdenVentas As Eniac.Controles.Label
   Friend WithEvents txtOrdenVentas As Eniac.Controles.TextBox
   Friend WithEvents lblOrdenCompras As Eniac.Controles.Label
   Friend WithEvents txtOrdenCompras As Eniac.Controles.TextBox
   Friend WithEvents lblOrdenFichas As Eniac.Controles.Label
   Friend WithEvents txtOrdenFichas As Eniac.Controles.TextBox
   Friend WithEvents lblCantidadCuotas As Eniac.Controles.Label
   Friend WithEvents txtDiasPrimerCuota As Eniac.Controles.TextBox
   Friend WithEvents txtCantidadCuotas As Eniac.Controles.TextBox
   Friend WithEvents lblDiasPrimerCuota As Eniac.Controles.Label
   Friend WithEvents cmbFechaBaseProximaCuota As Eniac.Controles.ComboBox
   Friend WithEvents lblFechaBaseProximaCuota As Eniac.Controles.Label
   Friend WithEvents chbExcluyeSabados As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluyeDomingos As Eniac.Controles.CheckBox
   Friend WithEvents chbExcluyeFeriados As Eniac.Controles.CheckBox
   Friend WithEvents lblExcluye As Eniac.Controles.Label
   Friend WithEvents lblPorcentaje As Eniac.Controles.Label
   Friend WithEvents txtPorcentaje As Eniac.Controles.TextBox
   Friend WithEvents lblPorcentaje2 As Eniac.Controles.Label
   Friend WithEvents grpRequiere As System.Windows.Forms.GroupBox
   Friend WithEvents chbRequiereTarjetaCredito1Pago As Eniac.Controles.CheckBox
   Friend WithEvents chbRequiereTarjetaCredito As Eniac.Controles.CheckBox
   Friend WithEvents chbRequiereTarjetaDebito As Eniac.Controles.CheckBox
   Friend WithEvents chbRequiereCheques As Eniac.Controles.CheckBox
   Friend WithEvents chbRequiereTransferencia As Eniac.Controles.CheckBox
   Friend WithEvents chbRequiereTickets As Eniac.Controles.CheckBox
   Friend WithEvents chbRequiereDolares As Eniac.Controles.CheckBox
   Friend WithEvents chbRequierePesos As Eniac.Controles.CheckBox
    Friend WithEvents chbListaDePrecios As Controles.CheckBox
    Friend WithEvents cmbListaDePrecios As Controles.ComboBox
    Friend WithEvents chbTipoComprobante As Controles.CheckBox
    Friend WithEvents cmbTipoComprobantes As Controles.ComboBox
    Friend WithEvents chbTipoComprobanteFR As Controles.CheckBox
    Friend WithEvents cmbTipoComprobantesFR As Controles.ComboBox
    Friend WithEvents bscCuentaBancariaTransfBanc As Controles.Buscador2
   Friend WithEvents chbCuentaBancaria As Controles.CheckBox
   Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents bscCodigoCuentaBancariaTransfBanc As Controles.Buscador2
    Friend WithEvents chbArchivoComplementario As Controles.CheckBox
    Friend WithEvents txtArchivoComplementario As Controles.TextBox
    Friend WithEvents chbArchivoEmbebido As Controles.CheckBox
    Friend WithEvents chbAplicanOfertas As Controles.CheckBox
    Friend WithEvents lblDescripcionFormaPago As Controles.Label
    Friend WithEvents txtFormaPago As Controles.TextBox
End Class
