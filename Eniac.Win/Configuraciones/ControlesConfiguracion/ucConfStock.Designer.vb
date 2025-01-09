<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucConfStock
   Inherits ucConfBase

   'UserControl overrides dispose to clean up the component list.
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
		Me.chbUtilizaPrecioCostoPorLote = New Eniac.Controles.CheckBox()
		Me.chbVisualizaStockFuturoReservado = New Eniac.Controles.CheckBox()
		Me.chbVisualizaStockFuturo = New Eniac.Controles.CheckBox()
		Me.chbVisualizaStockDefectuoso = New Eniac.Controles.CheckBox()
		Me.chbVisualizaStockReservado = New Eniac.Controles.CheckBox()
		Me.chbVisualizaNrosSerie = New Eniac.Controles.CheckBox()
		Me.chbVizualizaLote = New Eniac.Controles.CheckBox()
		Me.grbFacturarSinStock = New System.Windows.Forms.GroupBox()
		Me.chbFacturarSinStockControlaNoAfectaStock = New Eniac.Controles.CheckBox()
		Me.rbtFacturarSinStockAvisarYPermitir = New System.Windows.Forms.RadioButton()
		Me.rbtFacturarSinStockNoPermitir = New System.Windows.Forms.RadioButton()
		Me.rbtFacturarSinStockPermitir = New System.Windows.Forms.RadioButton()
		Me.chbLoteSolicitaDespachoImportacion = New Eniac.Controles.CheckBox()
		Me.chbLoteSolicitaFechaVencimiento = New Eniac.Controles.CheckBox()
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino = New Eniac.Controles.CheckBox()
		Me.cmbClaveLoteDespachoImportacion = New Eniac.Controles.ComboBox()
		Me.grbMostrarPrecioListadoStock = New System.Windows.Forms.GroupBox()
		Me.rdbListadoStockPorNinguno = New Eniac.Controles.RadioButton()
		Me.rdbListadoStockPorPrecioDeCosto = New Eniac.Controles.RadioButton()
		Me.rdbListadoStockPorPrecioDeVenta = New Eniac.Controles.RadioButton()
		Me.gbListadPreciosArborea = New System.Windows.Forms.GroupBox()
		Me.chbTipoAtributo04 = New Eniac.Controles.CheckBox()
		Me.chbTipoAtributo03 = New Eniac.Controles.CheckBox()
		Me.chbTipoAtributo02 = New Eniac.Controles.CheckBox()
		Me.chbTipoAtributo01 = New Eniac.Controles.CheckBox()
		Me.cmbTipoAtributo04 = New Eniac.Controles.ComboBox()
		Me.cmbTipoAtributo03 = New Eniac.Controles.ComboBox()
		Me.cmbTipoAtributo02 = New Eniac.Controles.ComboBox()
		Me.cmbTipoAtributo01 = New Eniac.Controles.ComboBox()
		Me.grbFacturarSinStock.SuspendLayout()
		Me.grbMostrarPrecioListadoStock.SuspendLayout()
		Me.gbListadPreciosArborea.SuspendLayout()
		Me.SuspendLayout()
		'
		'chbUtilizaPrecioCostoPorLote
		'
		Me.chbUtilizaPrecioCostoPorLote.AutoSize = True
		Me.chbUtilizaPrecioCostoPorLote.BindearPropiedadControl = Nothing
		Me.chbUtilizaPrecioCostoPorLote.BindearPropiedadEntidad = Nothing
		Me.chbUtilizaPrecioCostoPorLote.ForeColorFocus = System.Drawing.Color.Red
		Me.chbUtilizaPrecioCostoPorLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbUtilizaPrecioCostoPorLote.IsPK = False
		Me.chbUtilizaPrecioCostoPorLote.IsRequired = False
		Me.chbUtilizaPrecioCostoPorLote.Key = Nothing
		Me.chbUtilizaPrecioCostoPorLote.LabelAsoc = Nothing
		Me.chbUtilizaPrecioCostoPorLote.Location = New System.Drawing.Point(32, 181)
		Me.chbUtilizaPrecioCostoPorLote.Name = "chbUtilizaPrecioCostoPorLote"
		Me.chbUtilizaPrecioCostoPorLote.Size = New System.Drawing.Size(174, 17)
		Me.chbUtilizaPrecioCostoPorLote.TabIndex = 4
		Me.chbUtilizaPrecioCostoPorLote.Text = "Utiliza Precio de Costo por Lote"
		Me.chbUtilizaPrecioCostoPorLote.UseVisualStyleBackColor = True
		'
		'chbVisualizaStockFuturoReservado
		'
		Me.chbVisualizaStockFuturoReservado.AutoSize = True
		Me.chbVisualizaStockFuturoReservado.BindearPropiedadControl = Nothing
		Me.chbVisualizaStockFuturoReservado.BindearPropiedadEntidad = Nothing
		Me.chbVisualizaStockFuturoReservado.ForeColorFocus = System.Drawing.Color.Red
		Me.chbVisualizaStockFuturoReservado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbVisualizaStockFuturoReservado.IsPK = False
		Me.chbVisualizaStockFuturoReservado.IsRequired = False
		Me.chbVisualizaStockFuturoReservado.Key = Nothing
		Me.chbVisualizaStockFuturoReservado.LabelAsoc = Nothing
		Me.chbVisualizaStockFuturoReservado.Location = New System.Drawing.Point(617, 181)
		Me.chbVisualizaStockFuturoReservado.Name = "chbVisualizaStockFuturoReservado"
		Me.chbVisualizaStockFuturoReservado.Size = New System.Drawing.Size(256, 17)
		Me.chbVisualizaStockFuturoReservado.TabIndex = 11
		Me.chbVisualizaStockFuturoReservado.Text = "Visualiza la cantidad de Stock Futuro Reservado"
		Me.chbVisualizaStockFuturoReservado.UseVisualStyleBackColor = True
		'
		'chbVisualizaStockFuturo
		'
		Me.chbVisualizaStockFuturo.AutoSize = True
		Me.chbVisualizaStockFuturo.BindearPropiedadControl = Nothing
		Me.chbVisualizaStockFuturo.BindearPropiedadEntidad = Nothing
		Me.chbVisualizaStockFuturo.ForeColorFocus = System.Drawing.Color.Red
		Me.chbVisualizaStockFuturo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbVisualizaStockFuturo.IsPK = False
		Me.chbVisualizaStockFuturo.IsRequired = False
		Me.chbVisualizaStockFuturo.Key = Nothing
		Me.chbVisualizaStockFuturo.LabelAsoc = Nothing
		Me.chbVisualizaStockFuturo.Location = New System.Drawing.Point(617, 158)
		Me.chbVisualizaStockFuturo.Name = "chbVisualizaStockFuturo"
		Me.chbVisualizaStockFuturo.Size = New System.Drawing.Size(201, 17)
		Me.chbVisualizaStockFuturo.TabIndex = 10
		Me.chbVisualizaStockFuturo.Text = "Visualiza la cantidad de Stock Futuro"
		Me.chbVisualizaStockFuturo.UseVisualStyleBackColor = True
		'
		'chbVisualizaStockDefectuoso
		'
		Me.chbVisualizaStockDefectuoso.AutoSize = True
		Me.chbVisualizaStockDefectuoso.BindearPropiedadControl = Nothing
		Me.chbVisualizaStockDefectuoso.BindearPropiedadEntidad = Nothing
		Me.chbVisualizaStockDefectuoso.ForeColorFocus = System.Drawing.Color.Red
		Me.chbVisualizaStockDefectuoso.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbVisualizaStockDefectuoso.IsPK = False
		Me.chbVisualizaStockDefectuoso.IsRequired = False
		Me.chbVisualizaStockDefectuoso.Key = Nothing
		Me.chbVisualizaStockDefectuoso.LabelAsoc = Nothing
		Me.chbVisualizaStockDefectuoso.Location = New System.Drawing.Point(617, 135)
		Me.chbVisualizaStockDefectuoso.Name = "chbVisualizaStockDefectuoso"
		Me.chbVisualizaStockDefectuoso.Size = New System.Drawing.Size(226, 17)
		Me.chbVisualizaStockDefectuoso.TabIndex = 9
		Me.chbVisualizaStockDefectuoso.Text = "Visualiza la cantidad de Stock Defectuoso"
		Me.chbVisualizaStockDefectuoso.UseVisualStyleBackColor = True
		'
		'chbVisualizaStockReservado
		'
		Me.chbVisualizaStockReservado.AutoSize = True
		Me.chbVisualizaStockReservado.BindearPropiedadControl = Nothing
		Me.chbVisualizaStockReservado.BindearPropiedadEntidad = Nothing
		Me.chbVisualizaStockReservado.ForeColorFocus = System.Drawing.Color.Red
		Me.chbVisualizaStockReservado.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbVisualizaStockReservado.IsPK = False
		Me.chbVisualizaStockReservado.IsRequired = False
		Me.chbVisualizaStockReservado.Key = Nothing
		Me.chbVisualizaStockReservado.LabelAsoc = Nothing
		Me.chbVisualizaStockReservado.Location = New System.Drawing.Point(617, 112)
		Me.chbVisualizaStockReservado.Name = "chbVisualizaStockReservado"
		Me.chbVisualizaStockReservado.Size = New System.Drawing.Size(223, 17)
		Me.chbVisualizaStockReservado.TabIndex = 8
		Me.chbVisualizaStockReservado.Text = "Visualiza la cantidad de Stock Reservado"
		Me.chbVisualizaStockReservado.UseVisualStyleBackColor = True
		'
		'chbVisualizaNrosSerie
		'
		Me.chbVisualizaNrosSerie.AutoSize = True
		Me.chbVisualizaNrosSerie.BindearPropiedadControl = Nothing
		Me.chbVisualizaNrosSerie.BindearPropiedadEntidad = Nothing
		Me.chbVisualizaNrosSerie.ForeColorFocus = System.Drawing.Color.Red
		Me.chbVisualizaNrosSerie.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbVisualizaNrosSerie.IsPK = False
		Me.chbVisualizaNrosSerie.IsRequired = False
		Me.chbVisualizaNrosSerie.Key = Nothing
		Me.chbVisualizaNrosSerie.LabelAsoc = Nothing
		Me.chbVisualizaNrosSerie.Location = New System.Drawing.Point(32, 135)
		Me.chbVisualizaNrosSerie.Name = "chbVisualizaNrosSerie"
		Me.chbVisualizaNrosSerie.Size = New System.Drawing.Size(210, 17)
		Me.chbVisualizaNrosSerie.TabIndex = 2
		Me.chbVisualizaNrosSerie.Tag = "VISUALIZANROSERIE"
		Me.chbVisualizaNrosSerie.Text = "Utiliza Numeros de Serie en Productos "
		Me.chbVisualizaNrosSerie.UseVisualStyleBackColor = True
		'
		'chbVizualizaLote
		'
		Me.chbVizualizaLote.AutoSize = True
		Me.chbVizualizaLote.BindearPropiedadControl = Nothing
		Me.chbVizualizaLote.BindearPropiedadEntidad = Nothing
		Me.chbVizualizaLote.ForeColorFocus = System.Drawing.Color.Red
		Me.chbVizualizaLote.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbVizualizaLote.IsPK = False
		Me.chbVizualizaLote.IsRequired = False
		Me.chbVizualizaLote.Key = Nothing
		Me.chbVizualizaLote.LabelAsoc = Nothing
		Me.chbVizualizaLote.Location = New System.Drawing.Point(32, 158)
		Me.chbVizualizaLote.Name = "chbVizualizaLote"
		Me.chbVizualizaLote.Size = New System.Drawing.Size(149, 17)
		Me.chbVizualizaLote.TabIndex = 3
		Me.chbVizualizaLote.Tag = "VISUALIZALOTE"
		Me.chbVizualizaLote.Text = "Utiliza Lotes en Productos"
		Me.chbVizualizaLote.UseVisualStyleBackColor = True
		'
		'grbFacturarSinStock
		'
		Me.grbFacturarSinStock.Controls.Add(Me.chbFacturarSinStockControlaNoAfectaStock)
		Me.grbFacturarSinStock.Controls.Add(Me.rbtFacturarSinStockAvisarYPermitir)
		Me.grbFacturarSinStock.Controls.Add(Me.rbtFacturarSinStockNoPermitir)
		Me.grbFacturarSinStock.Controls.Add(Me.rbtFacturarSinStockPermitir)
		Me.grbFacturarSinStock.Location = New System.Drawing.Point(32, 18)
		Me.grbFacturarSinStock.Name = "grbFacturarSinStock"
		Me.grbFacturarSinStock.Size = New System.Drawing.Size(319, 71)
		Me.grbFacturarSinStock.TabIndex = 0
		Me.grbFacturarSinStock.TabStop = False
		Me.grbFacturarSinStock.Tag = "FACTURARSINSTOCK"
		Me.grbFacturarSinStock.Text = "Facturar Sin Stock"
		'
		'chbFacturarSinStockControlaNoAfectaStock
		'
		Me.chbFacturarSinStockControlaNoAfectaStock.AutoSize = True
		Me.chbFacturarSinStockControlaNoAfectaStock.BindearPropiedadControl = Nothing
		Me.chbFacturarSinStockControlaNoAfectaStock.BindearPropiedadEntidad = Nothing
		Me.chbFacturarSinStockControlaNoAfectaStock.ForeColorFocus = System.Drawing.Color.Red
		Me.chbFacturarSinStockControlaNoAfectaStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbFacturarSinStockControlaNoAfectaStock.IsPK = False
		Me.chbFacturarSinStockControlaNoAfectaStock.IsRequired = False
		Me.chbFacturarSinStockControlaNoAfectaStock.Key = Nothing
		Me.chbFacturarSinStockControlaNoAfectaStock.LabelAsoc = Nothing
		Me.chbFacturarSinStockControlaNoAfectaStock.Location = New System.Drawing.Point(21, 47)
		Me.chbFacturarSinStockControlaNoAfectaStock.Name = "chbFacturarSinStockControlaNoAfectaStock"
		Me.chbFacturarSinStockControlaNoAfectaStock.Size = New System.Drawing.Size(276, 17)
		Me.chbFacturarSinStockControlaNoAfectaStock.TabIndex = 3
		Me.chbFacturarSinStockControlaNoAfectaStock.Text = "Aplicar control a comprobantes que no afectan stock"
		Me.chbFacturarSinStockControlaNoAfectaStock.UseVisualStyleBackColor = True
		'
		'rbtFacturarSinStockAvisarYPermitir
		'
		Me.rbtFacturarSinStockAvisarYPermitir.AutoSize = True
		Me.rbtFacturarSinStockAvisarYPermitir.Location = New System.Drawing.Point(201, 24)
		Me.rbtFacturarSinStockAvisarYPermitir.Name = "rbtFacturarSinStockAvisarYPermitir"
		Me.rbtFacturarSinStockAvisarYPermitir.Size = New System.Drawing.Size(99, 17)
		Me.rbtFacturarSinStockAvisarYPermitir.TabIndex = 2
		Me.rbtFacturarSinStockAvisarYPermitir.Tag = "AVISARYPERMITIR"
		Me.rbtFacturarSinStockAvisarYPermitir.Text = "Avisar y Permitir"
		Me.rbtFacturarSinStockAvisarYPermitir.UseVisualStyleBackColor = True
		'
		'rbtFacturarSinStockNoPermitir
		'
		Me.rbtFacturarSinStockNoPermitir.AutoSize = True
		Me.rbtFacturarSinStockNoPermitir.Location = New System.Drawing.Point(99, 24)
		Me.rbtFacturarSinStockNoPermitir.Name = "rbtFacturarSinStockNoPermitir"
		Me.rbtFacturarSinStockNoPermitir.Size = New System.Drawing.Size(76, 17)
		Me.rbtFacturarSinStockNoPermitir.TabIndex = 1
		Me.rbtFacturarSinStockNoPermitir.Tag = "NOPERMITIR"
		Me.rbtFacturarSinStockNoPermitir.Text = "No Permitir"
		Me.rbtFacturarSinStockNoPermitir.UseVisualStyleBackColor = True
		'
		'rbtFacturarSinStockPermitir
		'
		Me.rbtFacturarSinStockPermitir.AutoSize = True
		Me.rbtFacturarSinStockPermitir.Checked = True
		Me.rbtFacturarSinStockPermitir.Location = New System.Drawing.Point(21, 24)
		Me.rbtFacturarSinStockPermitir.Name = "rbtFacturarSinStockPermitir"
		Me.rbtFacturarSinStockPermitir.Size = New System.Drawing.Size(59, 17)
		Me.rbtFacturarSinStockPermitir.TabIndex = 0
		Me.rbtFacturarSinStockPermitir.TabStop = True
		Me.rbtFacturarSinStockPermitir.Tag = "PERMITIR"
		Me.rbtFacturarSinStockPermitir.Text = "Permitir"
		Me.rbtFacturarSinStockPermitir.UseVisualStyleBackColor = True
		'
		'chbLoteSolicitaDespachoImportacion
		'
		Me.chbLoteSolicitaDespachoImportacion.AutoSize = True
		Me.chbLoteSolicitaDespachoImportacion.BindearPropiedadControl = Nothing
		Me.chbLoteSolicitaDespachoImportacion.BindearPropiedadEntidad = Nothing
		Me.chbLoteSolicitaDespachoImportacion.ForeColorFocus = System.Drawing.Color.Red
		Me.chbLoteSolicitaDespachoImportacion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbLoteSolicitaDespachoImportacion.IsPK = False
		Me.chbLoteSolicitaDespachoImportacion.IsRequired = False
		Me.chbLoteSolicitaDespachoImportacion.Key = Nothing
		Me.chbLoteSolicitaDespachoImportacion.LabelAsoc = Nothing
		Me.chbLoteSolicitaDespachoImportacion.Location = New System.Drawing.Point(32, 227)
		Me.chbLoteSolicitaDespachoImportacion.Name = "chbLoteSolicitaDespachoImportacion"
		Me.chbLoteSolicitaDespachoImportacion.Size = New System.Drawing.Size(194, 17)
		Me.chbLoteSolicitaDespachoImportacion.TabIndex = 6
		Me.chbLoteSolicitaDespachoImportacion.Text = "Lote Solicita Despacho Importación"
		Me.chbLoteSolicitaDespachoImportacion.UseVisualStyleBackColor = True
		'
		'chbLoteSolicitaFechaVencimiento
		'
		Me.chbLoteSolicitaFechaVencimiento.AutoSize = True
		Me.chbLoteSolicitaFechaVencimiento.BindearPropiedadControl = Nothing
		Me.chbLoteSolicitaFechaVencimiento.BindearPropiedadEntidad = Nothing
		Me.chbLoteSolicitaFechaVencimiento.ForeColorFocus = System.Drawing.Color.Red
		Me.chbLoteSolicitaFechaVencimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbLoteSolicitaFechaVencimiento.IsPK = False
		Me.chbLoteSolicitaFechaVencimiento.IsRequired = False
		Me.chbLoteSolicitaFechaVencimiento.Key = Nothing
		Me.chbLoteSolicitaFechaVencimiento.LabelAsoc = Nothing
		Me.chbLoteSolicitaFechaVencimiento.Location = New System.Drawing.Point(32, 204)
		Me.chbLoteSolicitaFechaVencimiento.Name = "chbLoteSolicitaFechaVencimiento"
		Me.chbLoteSolicitaFechaVencimiento.Size = New System.Drawing.Size(178, 17)
		Me.chbLoteSolicitaFechaVencimiento.TabIndex = 5
		Me.chbLoteSolicitaFechaVencimiento.Text = "Lote Solicita Fecha Vencimiento"
		Me.chbLoteSolicitaFechaVencimiento.UseVisualStyleBackColor = True
		'
		'chbContraMovimientoEnvioRecepcionSucursalDestino
		'
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.AutoSize = True
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.BindearPropiedadControl = Nothing
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.BindearPropiedadEntidad = Nothing
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.ForeColorFocus = System.Drawing.Color.Red
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.IsPK = False
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.IsRequired = False
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.Key = Nothing
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.LabelAsoc = Nothing
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.Location = New System.Drawing.Point(32, 112)
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.Name = "chbContraMovimientoEnvioRecepcionSucursalDestino"
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.Size = New System.Drawing.Size(509, 17)
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.TabIndex = 1
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.Tag = "CONTRAMOVIMIENTOENVIORECEPCIONSUCURSAL"
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.Text = "Realiza automaticamente el contra-movimiento en sucursal destino para Envio/Recep" &
	"ción de Sucursal"
		Me.chbContraMovimientoEnvioRecepcionSucursalDestino.UseVisualStyleBackColor = True
		'
		'cmbClaveLoteDespachoImportacion
		'
		Me.cmbClaveLoteDespachoImportacion.BindearPropiedadControl = Nothing
		Me.cmbClaveLoteDespachoImportacion.BindearPropiedadEntidad = Nothing
		Me.cmbClaveLoteDespachoImportacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbClaveLoteDespachoImportacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbClaveLoteDespachoImportacion.ForeColorFocus = System.Drawing.Color.Red
		Me.cmbClaveLoteDespachoImportacion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.cmbClaveLoteDespachoImportacion.FormattingEnabled = True
		Me.cmbClaveLoteDespachoImportacion.IsPK = False
		Me.cmbClaveLoteDespachoImportacion.IsRequired = False
		Me.cmbClaveLoteDespachoImportacion.Items.AddRange(New Object() {"ACTUAL", "ULTIMO"})
		Me.cmbClaveLoteDespachoImportacion.Key = Nothing
		Me.cmbClaveLoteDespachoImportacion.LabelAsoc = Nothing
		Me.cmbClaveLoteDespachoImportacion.Location = New System.Drawing.Point(232, 225)
		Me.cmbClaveLoteDespachoImportacion.Name = "cmbClaveLoteDespachoImportacion"
		Me.cmbClaveLoteDespachoImportacion.Size = New System.Drawing.Size(166, 21)
		Me.cmbClaveLoteDespachoImportacion.TabIndex = 7
		'
		'grbMostrarPrecioListadoStock
		'
		Me.grbMostrarPrecioListadoStock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.grbMostrarPrecioListadoStock.Controls.Add(Me.rdbListadoStockPorNinguno)
		Me.grbMostrarPrecioListadoStock.Controls.Add(Me.rdbListadoStockPorPrecioDeCosto)
		Me.grbMostrarPrecioListadoStock.Controls.Add(Me.rdbListadoStockPorPrecioDeVenta)
		Me.grbMostrarPrecioListadoStock.Location = New System.Drawing.Point(32, 252)
		Me.grbMostrarPrecioListadoStock.Name = "grbMostrarPrecioListadoStock"
		Me.grbMostrarPrecioListadoStock.Size = New System.Drawing.Size(319, 53)
		Me.grbMostrarPrecioListadoStock.TabIndex = 59
		Me.grbMostrarPrecioListadoStock.TabStop = False
		Me.grbMostrarPrecioListadoStock.Text = "Informe de stock mostrar precio predeterminado"
		'
		'rdbListadoStockPorNinguno
		'
		Me.rdbListadoStockPorNinguno.AutoSize = True
		Me.rdbListadoStockPorNinguno.BindearPropiedadControl = Nothing
		Me.rdbListadoStockPorNinguno.BindearPropiedadEntidad = Nothing
		Me.rdbListadoStockPorNinguno.ForeColorFocus = System.Drawing.Color.Red
		Me.rdbListadoStockPorNinguno.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.rdbListadoStockPorNinguno.IsPK = False
		Me.rdbListadoStockPorNinguno.IsRequired = False
		Me.rdbListadoStockPorNinguno.Key = Nothing
		Me.rdbListadoStockPorNinguno.LabelAsoc = Nothing
		Me.rdbListadoStockPorNinguno.Location = New System.Drawing.Point(6, 19)
		Me.rdbListadoStockPorNinguno.Name = "rdbListadoStockPorNinguno"
		Me.rdbListadoStockPorNinguno.Size = New System.Drawing.Size(91, 17)
		Me.rdbListadoStockPorNinguno.TabIndex = 1
		Me.rdbListadoStockPorNinguno.Tag = "Ninguno"
		Me.rdbListadoStockPorNinguno.Text = "Ningún precio"
		Me.rdbListadoStockPorNinguno.UseVisualStyleBackColor = True
		'
		'rdbListadoStockPorPrecioDeCosto
		'
		Me.rdbListadoStockPorPrecioDeCosto.AutoSize = True
		Me.rdbListadoStockPorPrecioDeCosto.BindearPropiedadControl = Nothing
		Me.rdbListadoStockPorPrecioDeCosto.BindearPropiedadEntidad = Nothing
		Me.rdbListadoStockPorPrecioDeCosto.ForeColorFocus = System.Drawing.Color.Red
		Me.rdbListadoStockPorPrecioDeCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.rdbListadoStockPorPrecioDeCosto.IsPK = False
		Me.rdbListadoStockPorPrecioDeCosto.IsRequired = False
		Me.rdbListadoStockPorPrecioDeCosto.Key = Nothing
		Me.rdbListadoStockPorPrecioDeCosto.LabelAsoc = Nothing
		Me.rdbListadoStockPorPrecioDeCosto.Location = New System.Drawing.Point(210, 19)
		Me.rdbListadoStockPorPrecioDeCosto.Name = "rdbListadoStockPorPrecioDeCosto"
		Me.rdbListadoStockPorPrecioDeCosto.Size = New System.Drawing.Size(100, 17)
		Me.rdbListadoStockPorPrecioDeCosto.TabIndex = 3
		Me.rdbListadoStockPorPrecioDeCosto.Tag = "PrecioDeCosto"
		Me.rdbListadoStockPorPrecioDeCosto.Text = "Precio de Costo"
		Me.rdbListadoStockPorPrecioDeCosto.UseVisualStyleBackColor = True
		'
		'rdbListadoStockPorPrecioDeVenta
		'
		Me.rdbListadoStockPorPrecioDeVenta.AutoSize = True
		Me.rdbListadoStockPorPrecioDeVenta.BindearPropiedadControl = Nothing
		Me.rdbListadoStockPorPrecioDeVenta.BindearPropiedadEntidad = Nothing
		Me.rdbListadoStockPorPrecioDeVenta.Checked = True
		Me.rdbListadoStockPorPrecioDeVenta.ForeColorFocus = System.Drawing.Color.Red
		Me.rdbListadoStockPorPrecioDeVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.rdbListadoStockPorPrecioDeVenta.IsPK = False
		Me.rdbListadoStockPorPrecioDeVenta.IsRequired = False
		Me.rdbListadoStockPorPrecioDeVenta.Key = Nothing
		Me.rdbListadoStockPorPrecioDeVenta.LabelAsoc = Nothing
		Me.rdbListadoStockPorPrecioDeVenta.Location = New System.Drawing.Point(103, 19)
		Me.rdbListadoStockPorPrecioDeVenta.Name = "rdbListadoStockPorPrecioDeVenta"
		Me.rdbListadoStockPorPrecioDeVenta.Size = New System.Drawing.Size(101, 17)
		Me.rdbListadoStockPorPrecioDeVenta.TabIndex = 2
		Me.rdbListadoStockPorPrecioDeVenta.TabStop = True
		Me.rdbListadoStockPorPrecioDeVenta.Tag = "PrecioDeVenta"
		Me.rdbListadoStockPorPrecioDeVenta.Text = "Precio de Venta"
		Me.rdbListadoStockPorPrecioDeVenta.UseVisualStyleBackColor = True
		'
		'gbListadPreciosArborea
		'
		Me.gbListadPreciosArborea.Controls.Add(Me.chbTipoAtributo04)
		Me.gbListadPreciosArborea.Controls.Add(Me.chbTipoAtributo03)
		Me.gbListadPreciosArborea.Controls.Add(Me.chbTipoAtributo02)
		Me.gbListadPreciosArborea.Controls.Add(Me.chbTipoAtributo01)
		Me.gbListadPreciosArborea.Controls.Add(Me.cmbTipoAtributo04)
		Me.gbListadPreciosArborea.Controls.Add(Me.cmbTipoAtributo03)
		Me.gbListadPreciosArborea.Controls.Add(Me.cmbTipoAtributo02)
		Me.gbListadPreciosArborea.Controls.Add(Me.cmbTipoAtributo01)
		Me.gbListadPreciosArborea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.gbListadPreciosArborea.Location = New System.Drawing.Point(559, 215)
		Me.gbListadPreciosArborea.Name = "gbListadPreciosArborea"
		Me.gbListadPreciosArborea.Size = New System.Drawing.Size(314, 158)
		Me.gbListadPreciosArborea.TabIndex = 60
		Me.gbListadPreciosArborea.TabStop = False
		Me.gbListadPreciosArborea.Text = "Configuración Tipo de Atributo"
		'
		'chbTipoAtributo04
		'
		Me.chbTipoAtributo04.AutoSize = True
		Me.chbTipoAtributo04.BindearPropiedadControl = ""
		Me.chbTipoAtributo04.BindearPropiedadEntidad = ""
		Me.chbTipoAtributo04.ForeColorFocus = System.Drawing.Color.Red
		Me.chbTipoAtributo04.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbTipoAtributo04.IsPK = False
		Me.chbTipoAtributo04.IsRequired = False
		Me.chbTipoAtributo04.Key = Nothing
		Me.chbTipoAtributo04.LabelAsoc = Nothing
		Me.chbTipoAtributo04.Location = New System.Drawing.Point(16, 118)
		Me.chbTipoAtributo04.Name = "chbTipoAtributo04"
		Me.chbTipoAtributo04.Size = New System.Drawing.Size(95, 17)
		Me.chbTipoAtributo04.TabIndex = 6
		Me.chbTipoAtributo04.Text = "Tipo Atributo 4"
		Me.chbTipoAtributo04.UseVisualStyleBackColor = True
		'
		'chbTipoAtributo03
		'
		Me.chbTipoAtributo03.AutoSize = True
		Me.chbTipoAtributo03.BindearPropiedadControl = ""
		Me.chbTipoAtributo03.BindearPropiedadEntidad = ""
		Me.chbTipoAtributo03.ForeColorFocus = System.Drawing.Color.Red
		Me.chbTipoAtributo03.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbTipoAtributo03.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chbTipoAtributo03.IsPK = False
		Me.chbTipoAtributo03.IsRequired = False
		Me.chbTipoAtributo03.Key = Nothing
		Me.chbTipoAtributo03.LabelAsoc = Nothing
		Me.chbTipoAtributo03.Location = New System.Drawing.Point(16, 88)
		Me.chbTipoAtributo03.Name = "chbTipoAtributo03"
		Me.chbTipoAtributo03.Size = New System.Drawing.Size(95, 17)
		Me.chbTipoAtributo03.TabIndex = 4
		Me.chbTipoAtributo03.Text = "Tipo Atributo 3"
		Me.chbTipoAtributo03.UseVisualStyleBackColor = True
		'
		'chbTipoAtributo02
		'
		Me.chbTipoAtributo02.AutoSize = True
		Me.chbTipoAtributo02.BindearPropiedadControl = ""
		Me.chbTipoAtributo02.BindearPropiedadEntidad = ""
		Me.chbTipoAtributo02.ForeColorFocus = System.Drawing.Color.Red
		Me.chbTipoAtributo02.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbTipoAtributo02.IsPK = False
		Me.chbTipoAtributo02.IsRequired = False
		Me.chbTipoAtributo02.Key = Nothing
		Me.chbTipoAtributo02.LabelAsoc = Nothing
		Me.chbTipoAtributo02.Location = New System.Drawing.Point(16, 58)
		Me.chbTipoAtributo02.Name = "chbTipoAtributo02"
		Me.chbTipoAtributo02.Size = New System.Drawing.Size(95, 17)
		Me.chbTipoAtributo02.TabIndex = 2
		Me.chbTipoAtributo02.Text = "Tipo Atributo 2"
		Me.chbTipoAtributo02.UseVisualStyleBackColor = True
		'
		'chbTipoAtributo01
		'
		Me.chbTipoAtributo01.AutoSize = True
		Me.chbTipoAtributo01.BindearPropiedadControl = ""
		Me.chbTipoAtributo01.BindearPropiedadEntidad = ""
		Me.chbTipoAtributo01.ForeColorFocus = System.Drawing.Color.Red
		Me.chbTipoAtributo01.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
		Me.chbTipoAtributo01.IsPK = False
		Me.chbTipoAtributo01.IsRequired = False
		Me.chbTipoAtributo01.Key = Nothing
		Me.chbTipoAtributo01.LabelAsoc = Nothing
		Me.chbTipoAtributo01.Location = New System.Drawing.Point(16, 29)
		Me.chbTipoAtributo01.Name = "chbTipoAtributo01"
		Me.chbTipoAtributo01.Size = New System.Drawing.Size(95, 17)
		Me.chbTipoAtributo01.TabIndex = 0
		Me.chbTipoAtributo01.Text = "Tipo Atributo 1"
		Me.chbTipoAtributo01.UseVisualStyleBackColor = True
		'
		'cmbTipoAtributo04
		'
		Me.cmbTipoAtributo04.BindearPropiedadControl = Nothing
		Me.cmbTipoAtributo04.BindearPropiedadEntidad = Nothing
		Me.cmbTipoAtributo04.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTipoAtributo04.Enabled = False
		Me.cmbTipoAtributo04.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbTipoAtributo04.ForeColorFocus = System.Drawing.Color.Red
		Me.cmbTipoAtributo04.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.cmbTipoAtributo04.FormattingEnabled = True
		Me.cmbTipoAtributo04.IsPK = False
		Me.cmbTipoAtributo04.IsRequired = False
		Me.cmbTipoAtributo04.Key = Nothing
		Me.cmbTipoAtributo04.LabelAsoc = Nothing
		Me.cmbTipoAtributo04.Location = New System.Drawing.Point(125, 116)
		Me.cmbTipoAtributo04.Name = "cmbTipoAtributo04"
		Me.cmbTipoAtributo04.Size = New System.Drawing.Size(172, 21)
		Me.cmbTipoAtributo04.TabIndex = 7
		Me.cmbTipoAtributo04.Tag = "TURISMOCATEGORIARESPONSABLE"
		'
		'cmbTipoAtributo03
		'
		Me.cmbTipoAtributo03.BindearPropiedadControl = Nothing
		Me.cmbTipoAtributo03.BindearPropiedadEntidad = Nothing
		Me.cmbTipoAtributo03.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTipoAtributo03.Enabled = False
		Me.cmbTipoAtributo03.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbTipoAtributo03.ForeColorFocus = System.Drawing.Color.Red
		Me.cmbTipoAtributo03.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.cmbTipoAtributo03.FormattingEnabled = True
		Me.cmbTipoAtributo03.IsPK = False
		Me.cmbTipoAtributo03.IsRequired = False
		Me.cmbTipoAtributo03.Key = Nothing
		Me.cmbTipoAtributo03.LabelAsoc = Nothing
		Me.cmbTipoAtributo03.Location = New System.Drawing.Point(125, 86)
		Me.cmbTipoAtributo03.Name = "cmbTipoAtributo03"
		Me.cmbTipoAtributo03.Size = New System.Drawing.Size(172, 21)
		Me.cmbTipoAtributo03.TabIndex = 5
		Me.cmbTipoAtributo03.Tag = "TURISMOCATEGORIARESPONSABLE"
		'
		'cmbTipoAtributo02
		'
		Me.cmbTipoAtributo02.BindearPropiedadControl = Nothing
		Me.cmbTipoAtributo02.BindearPropiedadEntidad = Nothing
		Me.cmbTipoAtributo02.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTipoAtributo02.Enabled = False
		Me.cmbTipoAtributo02.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbTipoAtributo02.ForeColorFocus = System.Drawing.Color.Red
		Me.cmbTipoAtributo02.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.cmbTipoAtributo02.FormattingEnabled = True
		Me.cmbTipoAtributo02.IsPK = False
		Me.cmbTipoAtributo02.IsRequired = False
		Me.cmbTipoAtributo02.Key = Nothing
		Me.cmbTipoAtributo02.LabelAsoc = Nothing
		Me.cmbTipoAtributo02.Location = New System.Drawing.Point(125, 56)
		Me.cmbTipoAtributo02.Name = "cmbTipoAtributo02"
		Me.cmbTipoAtributo02.Size = New System.Drawing.Size(172, 21)
		Me.cmbTipoAtributo02.TabIndex = 3
		Me.cmbTipoAtributo02.Tag = "TURISMOCATEGORIARESPONSABLE"
		'
		'cmbTipoAtributo01
		'
		Me.cmbTipoAtributo01.BindearPropiedadControl = Nothing
		Me.cmbTipoAtributo01.BindearPropiedadEntidad = Nothing
		Me.cmbTipoAtributo01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbTipoAtributo01.Enabled = False
		Me.cmbTipoAtributo01.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbTipoAtributo01.ForeColorFocus = System.Drawing.Color.Red
		Me.cmbTipoAtributo01.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
		Me.cmbTipoAtributo01.FormattingEnabled = True
		Me.cmbTipoAtributo01.IsPK = False
		Me.cmbTipoAtributo01.IsRequired = False
		Me.cmbTipoAtributo01.Key = Nothing
		Me.cmbTipoAtributo01.LabelAsoc = Nothing
		Me.cmbTipoAtributo01.Location = New System.Drawing.Point(125, 27)
		Me.cmbTipoAtributo01.Name = "cmbTipoAtributo01"
		Me.cmbTipoAtributo01.Size = New System.Drawing.Size(172, 21)
		Me.cmbTipoAtributo01.TabIndex = 1
		Me.cmbTipoAtributo01.Tag = ""
		'
		'ucConfStock
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.gbListadPreciosArborea)
		Me.Controls.Add(Me.grbMostrarPrecioListadoStock)
		Me.Controls.Add(Me.chbUtilizaPrecioCostoPorLote)
		Me.Controls.Add(Me.chbVisualizaStockFuturoReservado)
		Me.Controls.Add(Me.chbVisualizaStockFuturo)
		Me.Controls.Add(Me.chbVisualizaStockDefectuoso)
		Me.Controls.Add(Me.chbVisualizaStockReservado)
		Me.Controls.Add(Me.chbVisualizaNrosSerie)
		Me.Controls.Add(Me.chbVizualizaLote)
		Me.Controls.Add(Me.grbFacturarSinStock)
		Me.Controls.Add(Me.chbLoteSolicitaDespachoImportacion)
		Me.Controls.Add(Me.chbLoteSolicitaFechaVencimiento)
		Me.Controls.Add(Me.chbContraMovimientoEnvioRecepcionSucursalDestino)
		Me.Controls.Add(Me.cmbClaveLoteDespachoImportacion)
		Me.Name = "ucConfStock"
		Me.Controls.SetChildIndex(Me.cmbClaveLoteDespachoImportacion, 0)
		Me.Controls.SetChildIndex(Me.chbContraMovimientoEnvioRecepcionSucursalDestino, 0)
		Me.Controls.SetChildIndex(Me.chbLoteSolicitaFechaVencimiento, 0)
		Me.Controls.SetChildIndex(Me.chbLoteSolicitaDespachoImportacion, 0)
		Me.Controls.SetChildIndex(Me.grbFacturarSinStock, 0)
		Me.Controls.SetChildIndex(Me.chbVizualizaLote, 0)
		Me.Controls.SetChildIndex(Me.chbVisualizaNrosSerie, 0)
		Me.Controls.SetChildIndex(Me.chbVisualizaStockReservado, 0)
		Me.Controls.SetChildIndex(Me.chbVisualizaStockDefectuoso, 0)
		Me.Controls.SetChildIndex(Me.chbVisualizaStockFuturo, 0)
		Me.Controls.SetChildIndex(Me.chbVisualizaStockFuturoReservado, 0)
		Me.Controls.SetChildIndex(Me.chbUtilizaPrecioCostoPorLote, 0)
		Me.Controls.SetChildIndex(Me.grbMostrarPrecioListadoStock, 0)
		Me.Controls.SetChildIndex(Me.gbListadPreciosArborea, 0)
		Me.grbFacturarSinStock.ResumeLayout(False)
		Me.grbFacturarSinStock.PerformLayout()
		Me.grbMostrarPrecioListadoStock.ResumeLayout(False)
		Me.grbMostrarPrecioListadoStock.PerformLayout()
		Me.gbListadPreciosArborea.ResumeLayout(False)
		Me.gbListadPreciosArborea.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents chbUtilizaPrecioCostoPorLote As Controles.CheckBox
   Friend WithEvents chbVisualizaStockFuturoReservado As Controles.CheckBox
   Friend WithEvents chbVisualizaStockFuturo As Controles.CheckBox
   Friend WithEvents chbVisualizaStockDefectuoso As Controles.CheckBox
   Friend WithEvents chbVisualizaStockReservado As Controles.CheckBox
   Friend WithEvents chbVisualizaNrosSerie As Controles.CheckBox
   Friend WithEvents chbVizualizaLote As Controles.CheckBox
   Friend WithEvents grbFacturarSinStock As GroupBox
   Friend WithEvents chbFacturarSinStockControlaNoAfectaStock As Controles.CheckBox
   Friend WithEvents rbtFacturarSinStockAvisarYPermitir As RadioButton
   Friend WithEvents rbtFacturarSinStockNoPermitir As RadioButton
   Friend WithEvents rbtFacturarSinStockPermitir As RadioButton
   Friend WithEvents chbLoteSolicitaDespachoImportacion As Controles.CheckBox
   Friend WithEvents chbLoteSolicitaFechaVencimiento As Controles.CheckBox
   Friend WithEvents chbContraMovimientoEnvioRecepcionSucursalDestino As Controles.CheckBox
   Friend WithEvents cmbClaveLoteDespachoImportacion As Controles.ComboBox
   Friend WithEvents grbMostrarPrecioListadoStock As GroupBox
   Friend WithEvents rdbListadoStockPorNinguno As Controles.RadioButton
   Friend WithEvents rdbListadoStockPorPrecioDeCosto As Controles.RadioButton
   Friend WithEvents rdbListadoStockPorPrecioDeVenta As Controles.RadioButton
    Friend WithEvents gbListadPreciosArborea As GroupBox
    Friend WithEvents chbTipoAtributo04 As Controles.CheckBox
    Friend WithEvents chbTipoAtributo03 As Controles.CheckBox
    Friend WithEvents chbTipoAtributo02 As Controles.CheckBox
    Friend WithEvents chbTipoAtributo01 As Controles.CheckBox
    Friend WithEvents cmbTipoAtributo04 As Controles.ComboBox
    Friend WithEvents cmbTipoAtributo03 As Controles.ComboBox
    Friend WithEvents cmbTipoAtributo02 As Controles.ComboBox
    Friend WithEvents cmbTipoAtributo01 As Controles.ComboBox
End Class
