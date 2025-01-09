<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransferenciasEntreCuentas
   Inherits BaseForm

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
      Me.lblCuentaOrigen = New Eniac.Controles.Label()
      Me.bscCuentaBancariaOrigen = New Eniac.Controles.Buscador()
      Me.lblCuentaBancariaDestino = New Eniac.Controles.Label()
      Me.bscCuentaBancariaDestino = New Eniac.Controles.Buscador()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.lblObservacion = New Eniac.Controles.Label()
      Me.txtObservacion = New Eniac.Controles.TextBox()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.lblFechaAplicacion = New Eniac.Controles.Label()
      Me.dtpFechaAplicacion = New Eniac.Controles.DateTimePicker()
      Me.lblFechaTransferencia = New Eniac.Controles.Label()
      Me.dtpFecha = New Eniac.Controles.DateTimePicker()
      Me.txtImporte = New Eniac.Controles.TextBox()
      Me.lblImporte = New Eniac.Controles.Label()
        Me.lblSaldoConciliado = New Eniac.Controles.Label()
        Me.txtSaldoConciliadoOrigen = New Eniac.Controles.TextBox()
        Me.lblSaldoGeneral = New Eniac.Controles.Label()
        Me.txtSaldoGeneralOrigen = New Eniac.Controles.TextBox()
        Me.txtSaldoConciliadoDestino = New Eniac.Controles.TextBox()
        Me.txtSaldoGeneralDestino = New Eniac.Controles.TextBox()
        Me.tstBarra.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCuentaOrigen
        '
        Me.lblCuentaOrigen.AutoSize = True
        Me.lblCuentaOrigen.LabelAsoc = Nothing
        Me.lblCuentaOrigen.Location = New System.Drawing.Point(8, 89)
        Me.lblCuentaOrigen.Name = "lblCuentaOrigen"
        Me.lblCuentaOrigen.Size = New System.Drawing.Size(75, 13)
        Me.lblCuentaOrigen.TabIndex = 6
        Me.lblCuentaOrigen.Text = "Cuenta Origen"
        '
        'bscCuentaBancariaOrigen
        '
        Me.bscCuentaBancariaOrigen.AyudaAncho = 608
        Me.bscCuentaBancariaOrigen.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaOrigen.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaOrigen.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaOrigen.ColumnasAncho = Nothing
        Me.bscCuentaBancariaOrigen.ColumnasFormato = Nothing
        Me.bscCuentaBancariaOrigen.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaOrigen.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaOrigen.Datos = Nothing
        Me.bscCuentaBancariaOrigen.FilaDevuelta = Nothing
        Me.bscCuentaBancariaOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaOrigen.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaOrigen.IsDecimal = False
        Me.bscCuentaBancariaOrigen.IsNumber = False
        Me.bscCuentaBancariaOrigen.IsPK = False
        Me.bscCuentaBancariaOrigen.IsRequired = False
        Me.bscCuentaBancariaOrigen.Key = ""
        Me.bscCuentaBancariaOrigen.LabelAsoc = Me.lblCuentaOrigen
        Me.bscCuentaBancariaOrigen.Location = New System.Drawing.Point(93, 85)
        Me.bscCuentaBancariaOrigen.MaxLengh = "32767"
        Me.bscCuentaBancariaOrigen.Name = "bscCuentaBancariaOrigen"
        Me.bscCuentaBancariaOrigen.Permitido = True
        Me.bscCuentaBancariaOrigen.Selecciono = False
        Me.bscCuentaBancariaOrigen.Size = New System.Drawing.Size(387, 20)
        Me.bscCuentaBancariaOrigen.TabIndex = 7
        Me.bscCuentaBancariaOrigen.Titulo = "Clientes"
        '
        'lblCuentaBancariaDestino
        '
        Me.lblCuentaBancariaDestino.AutoSize = True
        Me.lblCuentaBancariaDestino.LabelAsoc = Nothing
        Me.lblCuentaBancariaDestino.Location = New System.Drawing.Point(8, 123)
        Me.lblCuentaBancariaDestino.Name = "lblCuentaBancariaDestino"
        Me.lblCuentaBancariaDestino.Size = New System.Drawing.Size(80, 13)
        Me.lblCuentaBancariaDestino.TabIndex = 8
        Me.lblCuentaBancariaDestino.Text = "Cuenta Destino"
        '
        'bscCuentaBancariaDestino
        '
        Me.bscCuentaBancariaDestino.AyudaAncho = 608
        Me.bscCuentaBancariaDestino.BindearPropiedadControl = Nothing
        Me.bscCuentaBancariaDestino.BindearPropiedadEntidad = Nothing
        Me.bscCuentaBancariaDestino.ColumnasAlineacion = Nothing
        Me.bscCuentaBancariaDestino.ColumnasAncho = Nothing
        Me.bscCuentaBancariaDestino.ColumnasFormato = Nothing
        Me.bscCuentaBancariaDestino.ColumnasOcultas = New String() {"IdLocalidad", "FechaNacimiento", "NroOperacion", "CorreoElectronico", "Celular", "NombreTrabajo", "DireccionTrabajo", "IdLocalidadTrabajo", "TelefonoTrabajo", "CorreoTrabajo", "FechaIngresoTrabajo", "FechaAlta", "SaldoPendiente", "TipoDocumentoGarante", "NroDocumentoGarante", "IdCategoria", "IdCategoriaFiscal", "NombreCategoriaFiscal", "LetraFiscal"}
        Me.bscCuentaBancariaDestino.ColumnasTitulos = New String() {"Tipo de Doc", "Documento", "Nombre", "Direccion", "IdLocalidad", "Localidad", "Teléfono", "Categoria Fiscal", "Letra Fiscal"}
        Me.bscCuentaBancariaDestino.Datos = Nothing
        Me.bscCuentaBancariaDestino.FilaDevuelta = Nothing
        Me.bscCuentaBancariaDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaBancariaDestino.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaBancariaDestino.IsDecimal = False
        Me.bscCuentaBancariaDestino.IsNumber = False
        Me.bscCuentaBancariaDestino.IsPK = False
        Me.bscCuentaBancariaDestino.IsRequired = False
        Me.bscCuentaBancariaDestino.Key = ""
        Me.bscCuentaBancariaDestino.LabelAsoc = Me.lblCuentaBancariaDestino
        Me.bscCuentaBancariaDestino.Location = New System.Drawing.Point(93, 119)
        Me.bscCuentaBancariaDestino.MaxLengh = "32767"
        Me.bscCuentaBancariaDestino.Name = "bscCuentaBancariaDestino"
        Me.bscCuentaBancariaDestino.Permitido = True
        Me.bscCuentaBancariaDestino.Selecciono = False
        Me.bscCuentaBancariaDestino.Size = New System.Drawing.Size(387, 20)
        Me.bscCuentaBancariaDestino.TabIndex = 9
        Me.bscCuentaBancariaDestino.Titulo = "Clientes"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.tsbGrabar, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(750, 25)
        Me.tstBarra.TabIndex = 17
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.document_add
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(84, 22)
        Me.tsbRefrescar.Text = "&Nueva (F5)"
        '
        'tsbGrabar
        '
        Me.tsbGrabar.Enabled = False
        Me.tsbGrabar.Image = Global.Eniac.Win.My.Resources.Resources.disk_blue
        Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbGrabar.Name = "tsbGrabar"
        Me.tsbGrabar.Size = New System.Drawing.Size(85, 22)
        Me.tsbGrabar.Text = "&Grabar (F4)"
        Me.tsbGrabar.ToolTipText = "Grabar e Imprimir (F4)"
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.redo
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(59, 22)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(8, 193)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 12
        Me.lblObservacion.Text = "Observación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtObservacion
        '
        Me.txtObservacion.BindearPropiedadControl = Nothing
        Me.txtObservacion.BindearPropiedadEntidad = Nothing
        Me.txtObservacion.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacion.Formato = ""
        Me.txtObservacion.IsDecimal = False
        Me.txtObservacion.IsNumber = False
        Me.txtObservacion.IsPK = False
        Me.txtObservacion.IsRequired = False
        Me.txtObservacion.Key = ""
        Me.txtObservacion.LabelAsoc = Me.lblObservacion
        Me.txtObservacion.Location = New System.Drawing.Point(93, 189)
        Me.txtObservacion.MaxLength = 100
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(387, 20)
        Me.txtObservacion.TabIndex = 13
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(340, 51)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 4
        Me.lblCaja.Text = "Caja"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = ""
        Me.cmbCajas.BindearPropiedadEntidad = ""
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCaja
        Me.cmbCajas.Location = New System.Drawing.Point(372, 48)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(125, 21)
        Me.cmbCajas.TabIndex = 5
        '
        'lblFechaAplicacion
        '
        Me.lblFechaAplicacion.AutoSize = True
        Me.lblFechaAplicacion.LabelAsoc = Nothing
        Me.lblFechaAplicacion.Location = New System.Drawing.Point(184, 51)
        Me.lblFechaAplicacion.Name = "lblFechaAplicacion"
        Me.lblFechaAplicacion.Size = New System.Drawing.Size(56, 13)
        Me.lblFechaAplicacion.TabIndex = 2
        Me.lblFechaAplicacion.Text = "Aplicación"
        '
        'dtpFechaAplicacion
        '
        Me.dtpFechaAplicacion.BindearPropiedadControl = Nothing
        Me.dtpFechaAplicacion.BindearPropiedadEntidad = Nothing
        Me.dtpFechaAplicacion.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaAplicacion.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaAplicacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaAplicacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaAplicacion.IsPK = False
        Me.dtpFechaAplicacion.IsRequired = False
        Me.dtpFechaAplicacion.Key = ""
        Me.dtpFechaAplicacion.LabelAsoc = Me.lblFechaAplicacion
        Me.dtpFechaAplicacion.Location = New System.Drawing.Point(245, 48)
        Me.dtpFechaAplicacion.Name = "dtpFechaAplicacion"
        Me.dtpFechaAplicacion.Size = New System.Drawing.Size(84, 20)
        Me.dtpFechaAplicacion.TabIndex = 3
        '
        'lblFechaTransferencia
        '
        Me.lblFechaTransferencia.AutoSize = True
        Me.lblFechaTransferencia.LabelAsoc = Nothing
        Me.lblFechaTransferencia.Location = New System.Drawing.Point(8, 51)
        Me.lblFechaTransferencia.Name = "lblFechaTransferencia"
        Me.lblFechaTransferencia.Size = New System.Drawing.Size(72, 13)
        Me.lblFechaTransferencia.TabIndex = 0
        Me.lblFechaTransferencia.Text = "Transferencia"
        '
        'dtpFecha
        '
        Me.dtpFecha.BindearPropiedadControl = Nothing
        Me.dtpFecha.BindearPropiedadEntidad = Nothing
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy"
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.IsPK = False
        Me.dtpFecha.IsRequired = False
        Me.dtpFecha.Key = ""
        Me.dtpFecha.LabelAsoc = Me.lblFechaTransferencia
        Me.dtpFecha.Location = New System.Drawing.Point(93, 48)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(84, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'txtImporte
        '
        Me.txtImporte.BindearPropiedadControl = Nothing
        Me.txtImporte.BindearPropiedadEntidad = Nothing
        Me.txtImporte.ForeColorFocus = System.Drawing.Color.Red
        Me.txtImporte.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtImporte.Formato = "N2"
        Me.txtImporte.IsDecimal = True
        Me.txtImporte.IsNumber = True
        Me.txtImporte.IsPK = False
        Me.txtImporte.IsRequired = False
        Me.txtImporte.Key = ""
        Me.txtImporte.LabelAsoc = Me.lblImporte
        Me.txtImporte.Location = New System.Drawing.Point(93, 154)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(70, 20)
        Me.txtImporte.TabIndex = 11
        Me.txtImporte.Text = "0.00"
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.LabelAsoc = Nothing
        Me.lblImporte.Location = New System.Drawing.Point(8, 158)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(42, 13)
        Me.lblImporte.TabIndex = 10
        Me.lblImporte.Text = "Importe"
        '
        'lblSaldoConciliado
        '
        Me.lblSaldoConciliado.AutoSize = True
        Me.lblSaldoConciliado.LabelAsoc = Nothing
        Me.lblSaldoConciliado.Location = New System.Drawing.Point(620, 64)
        Me.lblSaldoConciliado.Name = "lblSaldoConciliado"
        Me.lblSaldoConciliado.Size = New System.Drawing.Size(86, 13)
        Me.lblSaldoConciliado.TabIndex = 20
        Me.lblSaldoConciliado.Text = "Saldo Conciliado"
        '
        'txtSaldoConciliadoOrigen
        '
        Me.txtSaldoConciliadoOrigen.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtSaldoConciliadoOrigen.BindearPropiedadControl = Nothing
        Me.txtSaldoConciliadoOrigen.BindearPropiedadEntidad = Nothing
        Me.txtSaldoConciliadoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoConciliadoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoConciliadoOrigen.Formato = "##,##0.00"
        Me.txtSaldoConciliadoOrigen.IsDecimal = True
        Me.txtSaldoConciliadoOrigen.IsNumber = True
        Me.txtSaldoConciliadoOrigen.IsPK = False
        Me.txtSaldoConciliadoOrigen.IsRequired = False
        Me.txtSaldoConciliadoOrigen.Key = ""
        Me.txtSaldoConciliadoOrigen.LabelAsoc = Me.lblSaldoConciliado
        Me.txtSaldoConciliadoOrigen.Location = New System.Drawing.Point(616, 85)
        Me.txtSaldoConciliadoOrigen.Name = "txtSaldoConciliadoOrigen"
        Me.txtSaldoConciliadoOrigen.ReadOnly = True
        Me.txtSaldoConciliadoOrigen.Size = New System.Drawing.Size(90, 20)
        Me.txtSaldoConciliadoOrigen.TabIndex = 21
        Me.txtSaldoConciliadoOrigen.Text = "0.00"
        Me.txtSaldoConciliadoOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoGeneral
        '
        Me.lblSaldoGeneral.AutoSize = True
        Me.lblSaldoGeneral.LabelAsoc = Nothing
        Me.lblSaldoGeneral.Location = New System.Drawing.Point(510, 64)
        Me.lblSaldoGeneral.Name = "lblSaldoGeneral"
        Me.lblSaldoGeneral.Size = New System.Drawing.Size(74, 13)
        Me.lblSaldoGeneral.TabIndex = 18
        Me.lblSaldoGeneral.Text = "Saldo General"
        '
        'txtSaldoGeneralOrigen
        '
        Me.txtSaldoGeneralOrigen.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtSaldoGeneralOrigen.BindearPropiedadControl = Nothing
        Me.txtSaldoGeneralOrigen.BindearPropiedadEntidad = Nothing
        Me.txtSaldoGeneralOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoGeneralOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoGeneralOrigen.Formato = "##,##0.00"
        Me.txtSaldoGeneralOrigen.IsDecimal = True
        Me.txtSaldoGeneralOrigen.IsNumber = True
        Me.txtSaldoGeneralOrigen.IsPK = False
        Me.txtSaldoGeneralOrigen.IsRequired = False
        Me.txtSaldoGeneralOrigen.Key = ""
        Me.txtSaldoGeneralOrigen.LabelAsoc = Me.lblSaldoGeneral
        Me.txtSaldoGeneralOrigen.Location = New System.Drawing.Point(498, 85)
        Me.txtSaldoGeneralOrigen.Name = "txtSaldoGeneralOrigen"
        Me.txtSaldoGeneralOrigen.ReadOnly = True
        Me.txtSaldoGeneralOrigen.Size = New System.Drawing.Size(90, 20)
        Me.txtSaldoGeneralOrigen.TabIndex = 19
        Me.txtSaldoGeneralOrigen.Text = "0.00"
        Me.txtSaldoGeneralOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoConciliadoDestino
        '
        Me.txtSaldoConciliadoDestino.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtSaldoConciliadoDestino.BindearPropiedadControl = Nothing
        Me.txtSaldoConciliadoDestino.BindearPropiedadEntidad = Nothing
        Me.txtSaldoConciliadoDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoConciliadoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoConciliadoDestino.Formato = "##,##0.00"
        Me.txtSaldoConciliadoDestino.IsDecimal = True
        Me.txtSaldoConciliadoDestino.IsNumber = True
        Me.txtSaldoConciliadoDestino.IsPK = False
        Me.txtSaldoConciliadoDestino.IsRequired = False
        Me.txtSaldoConciliadoDestino.Key = ""
        Me.txtSaldoConciliadoDestino.LabelAsoc = Me.lblSaldoConciliado
        Me.txtSaldoConciliadoDestino.Location = New System.Drawing.Point(616, 119)
        Me.txtSaldoConciliadoDestino.Name = "txtSaldoConciliadoDestino"
        Me.txtSaldoConciliadoDestino.ReadOnly = True
        Me.txtSaldoConciliadoDestino.Size = New System.Drawing.Size(90, 20)
        Me.txtSaldoConciliadoDestino.TabIndex = 23
        Me.txtSaldoConciliadoDestino.Text = "0.00"
        Me.txtSaldoConciliadoDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoGeneralDestino
        '
        Me.txtSaldoGeneralDestino.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtSaldoGeneralDestino.BindearPropiedadControl = Nothing
        Me.txtSaldoGeneralDestino.BindearPropiedadEntidad = Nothing
        Me.txtSaldoGeneralDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.txtSaldoGeneralDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtSaldoGeneralDestino.Formato = "##,##0.00"
        Me.txtSaldoGeneralDestino.IsDecimal = True
        Me.txtSaldoGeneralDestino.IsNumber = True
        Me.txtSaldoGeneralDestino.IsPK = False
        Me.txtSaldoGeneralDestino.IsRequired = False
        Me.txtSaldoGeneralDestino.Key = ""
        Me.txtSaldoGeneralDestino.LabelAsoc = Me.lblSaldoGeneral
        Me.txtSaldoGeneralDestino.Location = New System.Drawing.Point(498, 119)
        Me.txtSaldoGeneralDestino.Name = "txtSaldoGeneralDestino"
        Me.txtSaldoGeneralDestino.ReadOnly = True
        Me.txtSaldoGeneralDestino.Size = New System.Drawing.Size(90, 20)
        Me.txtSaldoGeneralDestino.TabIndex = 22
        Me.txtSaldoGeneralDestino.Text = "0.00"
        Me.txtSaldoGeneralDestino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TransferenciasEntreCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 229)
        Me.Controls.Add(Me.txtSaldoConciliadoDestino)
        Me.Controls.Add(Me.txtSaldoGeneralDestino)
        Me.Controls.Add(Me.lblSaldoConciliado)
        Me.Controls.Add(Me.txtSaldoConciliadoOrigen)
        Me.Controls.Add(Me.lblSaldoGeneral)
        Me.Controls.Add(Me.txtSaldoGeneralOrigen)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.lblImporte)
        Me.Controls.Add(Me.lblCaja)
        Me.Controls.Add(Me.cmbCajas)
        Me.Controls.Add(Me.lblFechaAplicacion)
        Me.Controls.Add(Me.dtpFechaAplicacion)
        Me.Controls.Add(Me.lblFechaTransferencia)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lblObservacion)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.lblCuentaBancariaDestino)
        Me.Controls.Add(Me.bscCuentaBancariaDestino)
        Me.Controls.Add(Me.lblCuentaOrigen)
        Me.Controls.Add(Me.bscCuentaBancariaOrigen)
        Me.Name = "TransferenciasEntreCuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transferencias Entre Cuentas"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCuentaOrigen As Eniac.Controles.Label
   Friend WithEvents bscCuentaBancariaOrigen As Eniac.Controles.Buscador
   Friend WithEvents lblCuentaBancariaDestino As Eniac.Controles.Label
   Friend WithEvents bscCuentaBancariaDestino As Eniac.Controles.Buscador
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents lblObservacion As Eniac.Controles.Label
   Friend WithEvents txtObservacion As Eniac.Controles.TextBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblFechaAplicacion As Eniac.Controles.Label
   Friend WithEvents dtpFechaAplicacion As Eniac.Controles.DateTimePicker
   Friend WithEvents lblFechaTransferencia As Eniac.Controles.Label
   Friend WithEvents dtpFecha As Eniac.Controles.DateTimePicker
   Friend WithEvents txtImporte As Eniac.Controles.TextBox
   Friend WithEvents lblImporte As Eniac.Controles.Label
    Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSaldoConciliado As Controles.Label
    Friend WithEvents txtSaldoConciliadoOrigen As Controles.TextBox
    Friend WithEvents lblSaldoGeneral As Controles.Label
    Friend WithEvents txtSaldoGeneralOrigen As Controles.TextBox
    Friend WithEvents txtSaldoConciliadoDestino As Controles.TextBox
    Friend WithEvents txtSaldoGeneralDestino As Controles.TextBox
End Class
