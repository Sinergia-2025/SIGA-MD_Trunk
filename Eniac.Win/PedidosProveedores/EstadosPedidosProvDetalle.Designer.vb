<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosPedidosProvDetalle
   Inherits Eniac.Win.BaseDetalle


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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdRol")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRol")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PermitirEscritura")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Id")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Nombre")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblTipoEstado = New Eniac.Controles.Label()
        Me.cmbTiposEstados = New Eniac.Controles.ComboBox()
        Me.lblComprobante = New Eniac.Controles.Label()
        Me.cmbComprobantes = New Eniac.Controles.ComboBox()
        Me.lblIdTipoEstado = New Eniac.Controles.Label()
        Me.txtidTipoEstado = New Eniac.Controles.TextBox()
        Me.btnLimpiarTamaño = New Eniac.Controles.Button()
        Me.lblOrden = New Eniac.Controles.Label()
        Me.txtOrden = New Eniac.Controles.TextBox()
        Me.txtColor = New Eniac.Controles.TextBox()
        Me.lblColorSemadoro = New Eniac.Controles.Label()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.btnIdEstadoPedido = New Eniac.Controles.Button()
        Me.lblIdEstadoPedido = New Eniac.Controles.Label()
        Me.cmbIdEstadoPedido = New Eniac.Controles.ComboBox()
        Me.cmbTipoMovimiento = New Eniac.Controles.ComboBox()
        Me.lblTipoMovimiento = New Eniac.Controles.Label()
        Me.btnTipoMovimiento = New Eniac.Controles.Button()
        Me.cmbStockAfectado = New Eniac.Controles.ComboBox()
        Me.lblStockAfectado = New Eniac.Controles.Label()
        Me.cmbIdEstadoDestino = New Eniac.Controles.ComboBox()
        Me.lblIdEstadoDestino = New Eniac.Controles.Label()
        Me.btnIdEstadoDestino = New Eniac.Controles.Button()
        Me.ugEstadosRoles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugRoles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ChbPermitirEscritura = New System.Windows.Forms.CheckBox()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.chbFecha = New Eniac.Controles.CheckBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmbIdEstadoFacturado = New Eniac.Controles.ComboBox()
        Me.lblIdEstadoFacturado = New Eniac.Controles.Label()
        Me.btnIdEstadoFacturado = New Eniac.Controles.Button()
        CType(Me.ugEstadosRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(484, 479)
        Me.btnAceptar.TabIndex = 28
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(576, 479)
        Me.btnCancelar.TabIndex = 29
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(383, 479)
        Me.btnCopiar.TabIndex = 31
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(323, 479)
        Me.btnAplicar.TabIndex = 30
        '
        'lblTipoEstado
        '
        Me.lblTipoEstado.AutoSize = True
        Me.lblTipoEstado.LabelAsoc = Nothing
        Me.lblTipoEstado.Location = New System.Drawing.Point(17, 69)
        Me.lblTipoEstado.Name = "lblTipoEstado"
        Me.lblTipoEstado.Size = New System.Drawing.Size(64, 13)
        Me.lblTipoEstado.TabIndex = 5
        Me.lblTipoEstado.Text = "Tipo Estado"
        '
        'cmbTiposEstados
        '
        Me.cmbTiposEstados.BindearPropiedadControl = "Text"
        Me.cmbTiposEstados.BindearPropiedadEntidad = "IdTipoEstado"
        Me.cmbTiposEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposEstados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiposEstados.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposEstados.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposEstados.FormattingEnabled = True
        Me.cmbTiposEstados.IsPK = False
        Me.cmbTiposEstados.IsRequired = True
        Me.cmbTiposEstados.Key = Nothing
        Me.cmbTiposEstados.LabelAsoc = Me.lblTipoEstado
        Me.cmbTiposEstados.Location = New System.Drawing.Point(101, 65)
        Me.cmbTiposEstados.Name = "cmbTiposEstados"
        Me.cmbTiposEstados.Size = New System.Drawing.Size(181, 21)
        Me.cmbTiposEstados.TabIndex = 6
        '
        'lblComprobante
        '
        Me.lblComprobante.AutoSize = True
        Me.lblComprobante.LabelAsoc = Nothing
        Me.lblComprobante.Location = New System.Drawing.Point(17, 42)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
        Me.lblComprobante.TabIndex = 2
        Me.lblComprobante.Text = "Comprobante"
        '
        'cmbComprobantes
        '
        Me.cmbComprobantes.BindearPropiedadControl = "SelectedValue"
        Me.cmbComprobantes.BindearPropiedadEntidad = "IdTipoComprobante"
        Me.cmbComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbComprobantes.FormattingEnabled = True
        Me.cmbComprobantes.IsPK = False
        Me.cmbComprobantes.IsRequired = False
        Me.cmbComprobantes.Key = Nothing
        Me.cmbComprobantes.LabelAsoc = Me.lblComprobante
        Me.cmbComprobantes.Location = New System.Drawing.Point(101, 38)
        Me.cmbComprobantes.Name = "cmbComprobantes"
        Me.cmbComprobantes.Size = New System.Drawing.Size(181, 21)
        Me.cmbComprobantes.TabIndex = 3
        '
        'lblIdTipoEstado
        '
        Me.lblIdTipoEstado.AutoSize = True
        Me.lblIdTipoEstado.LabelAsoc = Nothing
        Me.lblIdTipoEstado.Location = New System.Drawing.Point(17, 16)
        Me.lblIdTipoEstado.Name = "lblIdTipoEstado"
        Me.lblIdTipoEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblIdTipoEstado.TabIndex = 0
        Me.lblIdTipoEstado.Text = "Estado"
        '
        'txtidTipoEstado
        '
        Me.txtidTipoEstado.BindearPropiedadControl = "Text"
        Me.txtidTipoEstado.BindearPropiedadEntidad = "IdEstado"
        Me.txtidTipoEstado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtidTipoEstado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtidTipoEstado.Formato = ""
        Me.txtidTipoEstado.IsDecimal = False
        Me.txtidTipoEstado.IsNumber = False
        Me.txtidTipoEstado.IsPK = True
        Me.txtidTipoEstado.IsRequired = True
        Me.txtidTipoEstado.Key = ""
        Me.txtidTipoEstado.LabelAsoc = Me.lblIdTipoEstado
        Me.txtidTipoEstado.Location = New System.Drawing.Point(101, 12)
        Me.txtidTipoEstado.MaxLength = 10
        Me.txtidTipoEstado.Name = "txtidTipoEstado"
        Me.txtidTipoEstado.Size = New System.Drawing.Size(181, 20)
        Me.txtidTipoEstado.TabIndex = 1
        '
        'btnLimpiarTamaño
        '
        Me.btnLimpiarTamaño.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarTamaño.Location = New System.Drawing.Point(288, 33)
        Me.btnLimpiarTamaño.Name = "btnLimpiarTamaño"
        Me.btnLimpiarTamaño.Size = New System.Drawing.Size(30, 30)
        Me.btnLimpiarTamaño.TabIndex = 4
        Me.btnLimpiarTamaño.TabStop = False
        Me.btnLimpiarTamaño.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLimpiarTamaño.UseVisualStyleBackColor = True
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.LabelAsoc = Nothing
        Me.lblOrden.Location = New System.Drawing.Point(17, 96)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 7
        Me.lblOrden.Text = "Orden"
        '
        'txtOrden
        '
        Me.txtOrden.BindearPropiedadControl = "Text"
        Me.txtOrden.BindearPropiedadEntidad = "Orden"
        Me.txtOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrden.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrden.Formato = ""
        Me.txtOrden.IsDecimal = False
        Me.txtOrden.IsNumber = True
        Me.txtOrden.IsPK = False
        Me.txtOrden.IsRequired = True
        Me.txtOrden.Key = ""
        Me.txtOrden.LabelAsoc = Me.lblOrden
        Me.txtOrden.Location = New System.Drawing.Point(101, 92)
        Me.txtOrden.MaxLength = 2
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(29, 20)
        Me.txtOrden.TabIndex = 8
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtColor
        '
        Me.txtColor.BindearPropiedadControl = "Key"
        Me.txtColor.BindearPropiedadEntidad = "Color"
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = False
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Me.lblColorSemadoro
        Me.txtColor.Location = New System.Drawing.Point(173, 92)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(82, 20)
        Me.txtColor.TabIndex = 10
        '
        'lblColorSemadoro
        '
        Me.lblColorSemadoro.AutoSize = True
        Me.lblColorSemadoro.LabelAsoc = Nothing
        Me.lblColorSemadoro.Location = New System.Drawing.Point(136, 96)
        Me.lblColorSemadoro.Name = "lblColorSemadoro"
        Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
        Me.lblColorSemadoro.TabIndex = 9
        Me.lblColorSemadoro.Text = "Color"
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(261, 91)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(57, 23)
        Me.btnColor.TabIndex = 11
        Me.btnColor.Text = "Paleta"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'btnIdEstadoPedido
        '
        Me.btnIdEstadoPedido.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnIdEstadoPedido.Location = New System.Drawing.Point(624, 7)
        Me.btnIdEstadoPedido.Name = "btnIdEstadoPedido"
        Me.btnIdEstadoPedido.Size = New System.Drawing.Size(30, 30)
        Me.btnIdEstadoPedido.TabIndex = 15
        Me.btnIdEstadoPedido.TabStop = False
        Me.btnIdEstadoPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIdEstadoPedido.UseVisualStyleBackColor = True
        '
        'lblIdEstadoPedido
        '
        Me.lblIdEstadoPedido.AutoSize = True
        Me.lblIdEstadoPedido.LabelAsoc = Nothing
        Me.lblIdEstadoPedido.Location = New System.Drawing.Point(350, 16)
        Me.lblIdEstadoPedido.Name = "lblIdEstadoPedido"
        Me.lblIdEstadoPedido.Size = New System.Drawing.Size(126, 13)
        Me.lblIdEstadoPedido.TabIndex = 13
        Me.lblIdEstadoPedido.Text = "Estado Pedido de Cliente"
        '
        'cmbIdEstadoPedido
        '
        Me.cmbIdEstadoPedido.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdEstadoPedido.BindearPropiedadEntidad = "IdEstadoPedidoCliente"
        Me.cmbIdEstadoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdEstadoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdEstadoPedido.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdEstadoPedido.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdEstadoPedido.FormattingEnabled = True
        Me.cmbIdEstadoPedido.IsPK = False
        Me.cmbIdEstadoPedido.IsRequired = False
        Me.cmbIdEstadoPedido.Key = Nothing
        Me.cmbIdEstadoPedido.LabelAsoc = Me.lblIdEstadoPedido
        Me.cmbIdEstadoPedido.Location = New System.Drawing.Point(482, 12)
        Me.cmbIdEstadoPedido.Name = "cmbIdEstadoPedido"
        Me.cmbIdEstadoPedido.Size = New System.Drawing.Size(139, 21)
        Me.cmbIdEstadoPedido.TabIndex = 14
        '
        'cmbTipoMovimiento
        '
        Me.cmbTipoMovimiento.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoMovimiento.BindearPropiedadEntidad = "IdTipoMovimiento"
        Me.cmbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoMovimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoMovimiento.FormattingEnabled = True
        Me.cmbTipoMovimiento.IsPK = False
        Me.cmbTipoMovimiento.IsRequired = False
        Me.cmbTipoMovimiento.Key = Nothing
        Me.cmbTipoMovimiento.LabelAsoc = Me.lblTipoMovimiento
        Me.cmbTipoMovimiento.Location = New System.Drawing.Point(482, 38)
        Me.cmbTipoMovimiento.Name = "cmbTipoMovimiento"
        Me.cmbTipoMovimiento.Size = New System.Drawing.Size(139, 21)
        Me.cmbTipoMovimiento.TabIndex = 17
        '
        'lblTipoMovimiento
        '
        Me.lblTipoMovimiento.AutoSize = True
        Me.lblTipoMovimiento.LabelAsoc = Nothing
        Me.lblTipoMovimiento.Location = New System.Drawing.Point(350, 42)
        Me.lblTipoMovimiento.Name = "lblTipoMovimiento"
        Me.lblTipoMovimiento.Size = New System.Drawing.Size(107, 13)
        Me.lblTipoMovimiento.TabIndex = 16
        Me.lblTipoMovimiento.Text = "Movimiento de Stock"
        '
        'btnTipoMovimiento
        '
        Me.btnTipoMovimiento.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnTipoMovimiento.Location = New System.Drawing.Point(624, 33)
        Me.btnTipoMovimiento.Name = "btnTipoMovimiento"
        Me.btnTipoMovimiento.Size = New System.Drawing.Size(30, 30)
        Me.btnTipoMovimiento.TabIndex = 18
        Me.btnTipoMovimiento.TabStop = False
        Me.btnTipoMovimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnTipoMovimiento.UseVisualStyleBackColor = True
        '
        'cmbStockAfectado
        '
        Me.cmbStockAfectado.BindearPropiedadControl = "SelectedValue"
        Me.cmbStockAfectado.BindearPropiedadEntidad = "StockAfectado"
        Me.cmbStockAfectado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStockAfectado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStockAfectado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbStockAfectado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbStockAfectado.FormattingEnabled = True
        Me.cmbStockAfectado.IsPK = False
        Me.cmbStockAfectado.IsRequired = False
        Me.cmbStockAfectado.Key = Nothing
        Me.cmbStockAfectado.LabelAsoc = Me.lblStockAfectado
        Me.cmbStockAfectado.Location = New System.Drawing.Point(482, 65)
        Me.cmbStockAfectado.Name = "cmbStockAfectado"
        Me.cmbStockAfectado.Size = New System.Drawing.Size(139, 21)
        Me.cmbStockAfectado.TabIndex = 20
        '
        'lblStockAfectado
        '
        Me.lblStockAfectado.AutoSize = True
        Me.lblStockAfectado.LabelAsoc = Nothing
        Me.lblStockAfectado.Location = New System.Drawing.Point(350, 69)
        Me.lblStockAfectado.Name = "lblStockAfectado"
        Me.lblStockAfectado.Size = New System.Drawing.Size(81, 13)
        Me.lblStockAfectado.TabIndex = 19
        Me.lblStockAfectado.Text = "Stock Afectado"
        '
        'cmbIdEstadoDestino
        '
        Me.cmbIdEstadoDestino.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdEstadoDestino.BindearPropiedadEntidad = "IdEstadoDestino"
        Me.cmbIdEstadoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdEstadoDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdEstadoDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdEstadoDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdEstadoDestino.FormattingEnabled = True
        Me.cmbIdEstadoDestino.IsPK = False
        Me.cmbIdEstadoDestino.IsRequired = False
        Me.cmbIdEstadoDestino.Key = Nothing
        Me.cmbIdEstadoDestino.LabelAsoc = Me.lblIdEstadoDestino
        Me.cmbIdEstadoDestino.Location = New System.Drawing.Point(482, 92)
        Me.cmbIdEstadoDestino.Name = "cmbIdEstadoDestino"
        Me.cmbIdEstadoDestino.Size = New System.Drawing.Size(139, 21)
        Me.cmbIdEstadoDestino.TabIndex = 22
        '
        'lblIdEstadoDestino
        '
        Me.lblIdEstadoDestino.AutoSize = True
        Me.lblIdEstadoDestino.LabelAsoc = Nothing
        Me.lblIdEstadoDestino.Location = New System.Drawing.Point(350, 96)
        Me.lblIdEstadoDestino.Name = "lblIdEstadoDestino"
        Me.lblIdEstadoDestino.Size = New System.Drawing.Size(99, 13)
        Me.lblIdEstadoDestino.TabIndex = 21
        Me.lblIdEstadoDestino.Text = "Solo puede pasar a"
        '
        'btnIdEstadoDestino
        '
        Me.btnIdEstadoDestino.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnIdEstadoDestino.Location = New System.Drawing.Point(624, 87)
        Me.btnIdEstadoDestino.Name = "btnIdEstadoDestino"
        Me.btnIdEstadoDestino.Size = New System.Drawing.Size(30, 30)
        Me.btnIdEstadoDestino.TabIndex = 23
        Me.btnIdEstadoDestino.TabStop = False
        Me.btnIdEstadoDestino.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIdEstadoDestino.UseVisualStyleBackColor = True
        '
        'ugEstadosRoles
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugEstadosRoles.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.Header.Caption = "Id"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Width = 70
        UltraGridColumn2.Header.Caption = "Nombre"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 153
        UltraGridColumn5.Header.Caption = "Escritura"
        UltraGridColumn5.Header.VisiblePosition = 2
        UltraGridColumn5.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn5.Width = 60
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn5})
        Me.ugEstadosRoles.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugEstadosRoles.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEstadosRoles.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEstadosRoles.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.ugEstadosRoles.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugEstadosRoles.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.ugEstadosRoles.DisplayLayout.MaxColScrollRegions = 1
        Me.ugEstadosRoles.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugEstadosRoles.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugEstadosRoles.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.ugEstadosRoles.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugEstadosRoles.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugEstadosRoles.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.ugEstadosRoles.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugEstadosRoles.DisplayLayout.Override.CellAppearance = Appearance8
        Me.ugEstadosRoles.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugEstadosRoles.DisplayLayout.Override.CellPadding = 0
        Me.ugEstadosRoles.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugEstadosRoles.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Appearance9.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ugEstadosRoles.DisplayLayout.Override.FilterRowAppearance = Appearance9
        Me.ugEstadosRoles.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugEstadosRoles.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugEstadosRoles.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugEstadosRoles.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugEstadosRoles.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugEstadosRoles.DisplayLayout.Override.RowAppearance = Appearance12
        Me.ugEstadosRoles.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugEstadosRoles.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugEstadosRoles.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugEstadosRoles.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugEstadosRoles.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugEstadosRoles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugEstadosRoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugEstadosRoles.Location = New System.Drawing.Point(377, 3)
        Me.ugEstadosRoles.Name = "ugEstadosRoles"
        Me.TableLayoutPanel1.SetRowSpan(Me.ugEstadosRoles, 4)
        Me.ugEstadosRoles.Size = New System.Drawing.Size(259, 317)
        Me.ugEstadosRoles.TabIndex = 2
        Me.ugEstadosRoles.Text = "Roles de Estado"
        '
        'ugRoles
        '
        Me.ugRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugRoles.DisplayLayout.Appearance = Appearance14
        UltraGridColumn3.Header.VisiblePosition = 0
        UltraGridColumn3.Width = 68
        UltraGridColumn4.Header.VisiblePosition = 1
        UltraGridColumn4.Width = 146
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn3, UltraGridColumn4})
        Me.ugRoles.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.ugRoles.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance15.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRoles.DisplayLayout.GroupByBox.Appearance = Appearance15
        Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRoles.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance16
        Me.ugRoles.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance17.BackColor2 = System.Drawing.SystemColors.Control
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugRoles.DisplayLayout.GroupByBox.PromptAppearance = Appearance17
        Me.ugRoles.DisplayLayout.MaxColScrollRegions = 1
        Me.ugRoles.DisplayLayout.MaxRowScrollRegions = 1
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Appearance18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugRoles.DisplayLayout.Override.ActiveCellAppearance = Appearance18
        Appearance19.BackColor = System.Drawing.SystemColors.Highlight
        Appearance19.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugRoles.DisplayLayout.Override.ActiveRowAppearance = Appearance19
        Me.ugRoles.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugRoles.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugRoles.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance20.BackColor = System.Drawing.SystemColors.Window
        Me.ugRoles.DisplayLayout.Override.CardAreaAppearance = Appearance20
        Appearance21.BorderColor = System.Drawing.Color.Silver
        Appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugRoles.DisplayLayout.Override.CellAppearance = Appearance21
        Me.ugRoles.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugRoles.DisplayLayout.Override.CellPadding = 0
        Me.ugRoles.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugRoles.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Appearance22.BackColor = System.Drawing.Color.AntiqueWhite
        Me.ugRoles.DisplayLayout.Override.FilterRowAppearance = Appearance22
        Me.ugRoles.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance23.BackColor = System.Drawing.SystemColors.Control
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugRoles.DisplayLayout.Override.GroupByRowAppearance = Appearance23
        Appearance24.TextHAlignAsString = "Left"
        Me.ugRoles.DisplayLayout.Override.HeaderAppearance = Appearance24
        Me.ugRoles.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugRoles.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance25.BackColor = System.Drawing.SystemColors.Window
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Me.ugRoles.DisplayLayout.Override.RowAppearance = Appearance25
        Me.ugRoles.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance26.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugRoles.DisplayLayout.Override.TemplateAddRowAppearance = Appearance26
        Me.ugRoles.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugRoles.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugRoles.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugRoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugRoles.Location = New System.Drawing.Point(3, 3)
        Me.ugRoles.Name = "ugRoles"
        Me.TableLayoutPanel1.SetRowSpan(Me.ugRoles, 4)
        Me.ugRoles.Size = New System.Drawing.Size(258, 317)
        Me.ugRoles.TabIndex = 0
        Me.ugRoles.Text = "Roles"
        '
        'ChbPermitirEscritura
        '
        Me.ChbPermitirEscritura.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ChbPermitirEscritura.AutoSize = True
        Me.ChbPermitirEscritura.Checked = True
        Me.ChbPermitirEscritura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbPermitirEscritura.Location = New System.Drawing.Point(267, 3)
        Me.ChbPermitirEscritura.Name = "ChbPermitirEscritura"
        Me.ChbPermitirEscritura.Size = New System.Drawing.Size(104, 17)
        Me.ChbPermitirEscritura.TabIndex = 3
        Me.ChbPermitirEscritura.Text = "Permitir Escritura"
        Me.ChbPermitirEscritura.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuitar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.Location = New System.Drawing.Point(270, 73)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(98, 41)
        Me.btnQuitar.TabIndex = 4
        Me.btnQuitar.Text = "< Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.add_24
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.Location = New System.Drawing.Point(270, 26)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(98, 41)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "Agregar >"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'chbFecha
        '
        Me.chbFecha.AutoSize = True
        Me.chbFecha.BindearPropiedadControl = "Checked"
        Me.chbFecha.BindearPropiedadEntidad = "GeneraDeclaracionProduccion"
        Me.chbFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFecha.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFecha.IsPK = False
        Me.chbFecha.IsRequired = False
        Me.chbFecha.Key = Nothing
        Me.chbFecha.LabelAsoc = Nothing
        Me.chbFecha.Location = New System.Drawing.Point(101, 123)
        Me.chbFecha.Name = "chbFecha"
        Me.chbFecha.Size = New System.Drawing.Size(193, 17)
        Me.chbFecha.TabIndex = 12
        Me.chbFecha.Text = "Genera Declaración de Producción"
        Me.chbFecha.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001!))
        Me.TableLayoutPanel1.Controls.Add(Me.ChbPermitirEscritura, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAgregar, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ugEstadosRoles, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnQuitar, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ugRoles, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(15, 150)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(639, 323)
        Me.TableLayoutPanel1.TabIndex = 27
        '
        'cmbIdEstadoFacturado
        '
        Me.cmbIdEstadoFacturado.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdEstadoFacturado.BindearPropiedadEntidad = "IdEstadoFacturado"
        Me.cmbIdEstadoFacturado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdEstadoFacturado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdEstadoFacturado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdEstadoFacturado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdEstadoFacturado.FormattingEnabled = True
        Me.cmbIdEstadoFacturado.IsPK = False
        Me.cmbIdEstadoFacturado.IsRequired = False
        Me.cmbIdEstadoFacturado.Key = Nothing
        Me.cmbIdEstadoFacturado.LabelAsoc = Me.lblIdEstadoFacturado
        Me.cmbIdEstadoFacturado.Location = New System.Drawing.Point(482, 119)
        Me.cmbIdEstadoFacturado.Name = "cmbIdEstadoFacturado"
        Me.cmbIdEstadoFacturado.Size = New System.Drawing.Size(139, 21)
        Me.cmbIdEstadoFacturado.TabIndex = 25
        '
        'lblIdEstadoFacturado
        '
        Me.lblIdEstadoFacturado.AutoSize = True
        Me.lblIdEstadoFacturado.LabelAsoc = Nothing
        Me.lblIdEstadoFacturado.Location = New System.Drawing.Point(350, 123)
        Me.lblIdEstadoFacturado.Name = "lblIdEstadoFacturado"
        Me.lblIdEstadoFacturado.Size = New System.Drawing.Size(127, 13)
        Me.lblIdEstadoFacturado.TabIndex = 24
        Me.lblIdEstadoFacturado.Text = "Estado Pedido Facturado"
        '
        'btnIdEstadoFacturado
        '
        Me.btnIdEstadoFacturado.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnIdEstadoFacturado.Location = New System.Drawing.Point(624, 114)
        Me.btnIdEstadoFacturado.Name = "btnIdEstadoFacturado"
        Me.btnIdEstadoFacturado.Size = New System.Drawing.Size(30, 30)
        Me.btnIdEstadoFacturado.TabIndex = 26
        Me.btnIdEstadoFacturado.TabStop = False
        Me.btnIdEstadoFacturado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnIdEstadoFacturado.UseVisualStyleBackColor = True
        '
        'EstadosPedidosProvDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 519)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.chbFecha)
        Me.Controls.Add(Me.btnIdEstadoDestino)
        Me.Controls.Add(Me.btnTipoMovimiento)
        Me.Controls.Add(Me.btnIdEstadoFacturado)
        Me.Controls.Add(Me.btnIdEstadoPedido)
        Me.Controls.Add(Me.lblIdEstadoDestino)
        Me.Controls.Add(Me.lblStockAfectado)
        Me.Controls.Add(Me.lblTipoMovimiento)
        Me.Controls.Add(Me.lblIdEstadoFacturado)
        Me.Controls.Add(Me.lblIdEstadoPedido)
        Me.Controls.Add(Me.cmbIdEstadoDestino)
        Me.Controls.Add(Me.cmbStockAfectado)
        Me.Controls.Add(Me.cmbTipoMovimiento)
        Me.Controls.Add(Me.cmbIdEstadoFacturado)
        Me.Controls.Add(Me.cmbIdEstadoPedido)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblColorSemadoro)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.btnLimpiarTamaño)
        Me.Controls.Add(Me.lblIdTipoEstado)
        Me.Controls.Add(Me.txtidTipoEstado)
        Me.Controls.Add(Me.lblComprobante)
        Me.Controls.Add(Me.cmbComprobantes)
        Me.Controls.Add(Me.lblTipoEstado)
        Me.Controls.Add(Me.cmbTiposEstados)
        Me.Name = "EstadosPedidosProvDetalle"
        Me.Text = "Estado de Pedido a Proveedores"
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.cmbTiposEstados, 0)
        Me.Controls.SetChildIndex(Me.lblTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.cmbComprobantes, 0)
        Me.Controls.SetChildIndex(Me.lblComprobante, 0)
        Me.Controls.SetChildIndex(Me.txtidTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.lblIdTipoEstado, 0)
        Me.Controls.SetChildIndex(Me.btnLimpiarTamaño, 0)
        Me.Controls.SetChildIndex(Me.txtOrden, 0)
        Me.Controls.SetChildIndex(Me.lblOrden, 0)
        Me.Controls.SetChildIndex(Me.btnColor, 0)
        Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
        Me.Controls.SetChildIndex(Me.txtColor, 0)
        Me.Controls.SetChildIndex(Me.cmbIdEstadoPedido, 0)
        Me.Controls.SetChildIndex(Me.cmbIdEstadoFacturado, 0)
        Me.Controls.SetChildIndex(Me.cmbTipoMovimiento, 0)
        Me.Controls.SetChildIndex(Me.cmbStockAfectado, 0)
        Me.Controls.SetChildIndex(Me.cmbIdEstadoDestino, 0)
        Me.Controls.SetChildIndex(Me.lblIdEstadoPedido, 0)
        Me.Controls.SetChildIndex(Me.lblIdEstadoFacturado, 0)
        Me.Controls.SetChildIndex(Me.lblTipoMovimiento, 0)
        Me.Controls.SetChildIndex(Me.lblStockAfectado, 0)
        Me.Controls.SetChildIndex(Me.lblIdEstadoDestino, 0)
        Me.Controls.SetChildIndex(Me.btnIdEstadoPedido, 0)
        Me.Controls.SetChildIndex(Me.btnIdEstadoFacturado, 0)
        Me.Controls.SetChildIndex(Me.btnTipoMovimiento, 0)
        Me.Controls.SetChildIndex(Me.btnIdEstadoDestino, 0)
        Me.Controls.SetChildIndex(Me.chbFecha, 0)
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.ugEstadosRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugRoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTipoEstado As Eniac.Controles.Label
   Friend WithEvents cmbTiposEstados As Eniac.Controles.ComboBox
   Friend WithEvents lblComprobante As Eniac.Controles.Label
   Friend WithEvents cmbComprobantes As Eniac.Controles.ComboBox
   Friend WithEvents lblIdTipoEstado As Eniac.Controles.Label
   Friend WithEvents txtidTipoEstado As Eniac.Controles.TextBox
   Friend WithEvents btnLimpiarTamaño As Eniac.Controles.Button
   Friend WithEvents lblOrden As Eniac.Controles.Label
   Friend WithEvents txtOrden As Eniac.Controles.TextBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents btnIdEstadoPedido As Eniac.Controles.Button
   Friend WithEvents lblIdEstadoPedido As Eniac.Controles.Label
   Friend WithEvents cmbIdEstadoPedido As Eniac.Controles.ComboBox
   Friend WithEvents cmbTipoMovimiento As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoMovimiento As Eniac.Controles.Label
   Friend WithEvents btnTipoMovimiento As Eniac.Controles.Button
   Friend WithEvents cmbStockAfectado As Eniac.Controles.ComboBox
   Friend WithEvents lblStockAfectado As Eniac.Controles.Label
   Friend WithEvents cmbIdEstadoDestino As Eniac.Controles.ComboBox
   Friend WithEvents lblIdEstadoDestino As Eniac.Controles.Label
   Friend WithEvents btnIdEstadoDestino As Eniac.Controles.Button
    Friend WithEvents ugEstadosRoles As UltraGrid
    Friend WithEvents ugRoles As UltraGrid
    Friend WithEvents ChbPermitirEscritura As CheckBox
    Protected WithEvents btnQuitar As Button
    Protected WithEvents btnAgregar As Button
    Friend WithEvents chbFecha As Controles.CheckBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cmbIdEstadoFacturado As Controles.ComboBox
    Friend WithEvents lblIdEstadoFacturado As Controles.Label
    Friend WithEvents btnIdEstadoFacturado As Controles.Button
End Class
