<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EstadosPedidosDetalle
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
        Me.lblComprobante = New Eniac.Controles.Label()
        Me.lblIdTipoEstado = New Eniac.Controles.Label()
        Me.txtidTipoEstado = New Eniac.Controles.TextBox()
        Me.btnLimpiarTamaño = New Eniac.Controles.Button()
        Me.lblOrden = New Eniac.Controles.Label()
        Me.txtOrden = New Eniac.Controles.TextBox()
        Me.chbAfectaPendiente = New Eniac.Controles.CheckBox()
        Me.txtColor = New Eniac.Controles.TextBox()
        Me.lblColorSemadoro = New Eniac.Controles.Label()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.cdColor = New System.Windows.Forms.ColorDialog()
        Me.chbReservaStock = New Eniac.Controles.CheckBox()
        Me.grpDivide = New System.Windows.Forms.GroupBox()
        Me.lblPorcDivideB = New Eniac.Controles.Label()
        Me.lblPorcDivideA = New Eniac.Controles.Label()
        Me.txtPorcDivideB = New Eniac.Controles.TextBox()
        Me.txtPorcDivideA = New Eniac.Controles.TextBox()
        Me.cmbEstadoDivideB = New Eniac.Controles.ComboBox()
        Me.cmbEstadoDivideA = New Eniac.Controles.ComboBox()
        Me.chbDivide = New Eniac.Controles.CheckBox()
        Me.chbSolicitaSucursalParaTipoComprobante = New Eniac.Controles.CheckBox()
        Me.grpReservaStock = New System.Windows.Forms.GroupBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbDepositoOrigen = New Eniac.Controles.ComboBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.cmbUbicacionOrigen = New Eniac.Controles.ComboBox()
        Me.cmbComprobantes = New Eniac.Controles.ComboBox()
        Me.cmbTiposEstados = New Eniac.Controles.ComboBox()
        Me.ugEstadosRoles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ugRoles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ChbPermitirEscritura = New System.Windows.Forms.CheckBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.lblUsuarios = New Eniac.Controles.Label()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.grpDivide.SuspendLayout()
        Me.grpReservaStock.SuspendLayout()
        CType(Me.ugEstadosRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(501, 415)
        Me.btnAceptar.TabIndex = 19
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(593, 415)
        Me.btnCancelar.TabIndex = 0
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(400, 415)
        Me.btnCopiar.TabIndex = 18
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(340, 415)
        Me.btnAplicar.TabIndex = 17
        '
        'lblTipoEstado
        '
        Me.lblTipoEstado.AutoSize = True
        Me.lblTipoEstado.LabelAsoc = Nothing
        Me.lblTipoEstado.Location = New System.Drawing.Point(35, 95)
        Me.lblTipoEstado.Name = "lblTipoEstado"
        Me.lblTipoEstado.Size = New System.Drawing.Size(64, 13)
        Me.lblTipoEstado.TabIndex = 6
        Me.lblTipoEstado.Text = "Tipo Estado"
        '
        'lblComprobante
        '
        Me.lblComprobante.AutoSize = True
        Me.lblComprobante.LabelAsoc = Nothing
        Me.lblComprobante.Location = New System.Drawing.Point(35, 41)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(70, 13)
        Me.lblComprobante.TabIndex = 2
        Me.lblComprobante.Text = "Comprobante"
        '
        'lblIdTipoEstado
        '
        Me.lblIdTipoEstado.AutoSize = True
        Me.lblIdTipoEstado.LabelAsoc = Nothing
        Me.lblIdTipoEstado.Location = New System.Drawing.Point(35, 15)
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
        Me.txtidTipoEstado.Location = New System.Drawing.Point(119, 12)
        Me.txtidTipoEstado.MaxLength = 10
        Me.txtidTipoEstado.Name = "txtidTipoEstado"
        Me.txtidTipoEstado.Size = New System.Drawing.Size(139, 20)
        Me.txtidTipoEstado.TabIndex = 1
        '
        'btnLimpiarTamaño
        '
        Me.btnLimpiarTamaño.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.btnLimpiarTamaño.Location = New System.Drawing.Point(261, 33)
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
        Me.lblOrden.Location = New System.Drawing.Point(35, 123)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(36, 13)
        Me.lblOrden.TabIndex = 8
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
        Me.txtOrden.Location = New System.Drawing.Point(119, 119)
        Me.txtOrden.MaxLength = 2
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(29, 20)
        Me.txtOrden.TabIndex = 9
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbAfectaPendiente
        '
        Me.chbAfectaPendiente.AutoSize = True
        Me.chbAfectaPendiente.BindearPropiedadControl = "Checked"
        Me.chbAfectaPendiente.BindearPropiedadEntidad = "AfectaPendiente"
        Me.chbAfectaPendiente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAfectaPendiente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAfectaPendiente.IsPK = False
        Me.chbAfectaPendiente.IsRequired = False
        Me.chbAfectaPendiente.Key = Nothing
        Me.chbAfectaPendiente.LabelAsoc = Nothing
        Me.chbAfectaPendiente.Location = New System.Drawing.Point(119, 147)
        Me.chbAfectaPendiente.Name = "chbAfectaPendiente"
        Me.chbAfectaPendiente.Size = New System.Drawing.Size(108, 17)
        Me.chbAfectaPendiente.TabIndex = 13
        Me.chbAfectaPendiente.Tag = ""
        Me.chbAfectaPendiente.Text = "Afecta Pendiente"
        Me.chbAfectaPendiente.UseVisualStyleBackColor = True
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
        Me.txtColor.Location = New System.Drawing.Point(192, 119)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.ReadOnly = True
        Me.txtColor.Size = New System.Drawing.Size(82, 20)
        Me.txtColor.TabIndex = 11
        '
        'lblColorSemadoro
        '
        Me.lblColorSemadoro.AutoSize = True
        Me.lblColorSemadoro.LabelAsoc = Nothing
        Me.lblColorSemadoro.Location = New System.Drawing.Point(155, 123)
        Me.lblColorSemadoro.Name = "lblColorSemadoro"
        Me.lblColorSemadoro.Size = New System.Drawing.Size(31, 13)
        Me.lblColorSemadoro.TabIndex = 10
        Me.lblColorSemadoro.Text = "Color"
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(280, 118)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(57, 23)
        Me.btnColor.TabIndex = 12
        Me.btnColor.Text = "Paleta"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'chbReservaStock
        '
        Me.chbReservaStock.AutoSize = True
        Me.chbReservaStock.BindearPropiedadControl = "Checked"
        Me.chbReservaStock.BindearPropiedadEntidad = "ReservaStock"
        Me.chbReservaStock.ForeColorFocus = System.Drawing.Color.Red
        Me.chbReservaStock.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbReservaStock.IsPK = False
        Me.chbReservaStock.IsRequired = False
        Me.chbReservaStock.Key = Nothing
        Me.chbReservaStock.LabelAsoc = Nothing
        Me.chbReservaStock.Location = New System.Drawing.Point(9, 12)
        Me.chbReservaStock.Name = "chbReservaStock"
        Me.chbReservaStock.Size = New System.Drawing.Size(97, 17)
        Me.chbReservaStock.TabIndex = 0
        Me.chbReservaStock.Tag = ""
        Me.chbReservaStock.Text = "Reserva Stock"
        Me.chbReservaStock.UseVisualStyleBackColor = True
        '
        'grpDivide
        '
        Me.grpDivide.Controls.Add(Me.lblPorcDivideB)
        Me.grpDivide.Controls.Add(Me.lblPorcDivideA)
        Me.grpDivide.Controls.Add(Me.txtPorcDivideB)
        Me.grpDivide.Controls.Add(Me.txtPorcDivideA)
        Me.grpDivide.Controls.Add(Me.cmbEstadoDivideB)
        Me.grpDivide.Controls.Add(Me.cmbEstadoDivideA)
        Me.grpDivide.Controls.Add(Me.chbDivide)
        Me.grpDivide.Location = New System.Drawing.Point(416, 84)
        Me.grpDivide.Name = "grpDivide"
        Me.grpDivide.Size = New System.Drawing.Size(231, 89)
        Me.grpDivide.TabIndex = 16
        Me.grpDivide.TabStop = False
        '
        'lblPorcDivideB
        '
        Me.lblPorcDivideB.AutoSize = True
        Me.lblPorcDivideB.LabelAsoc = Nothing
        Me.lblPorcDivideB.Location = New System.Drawing.Point(206, 63)
        Me.lblPorcDivideB.Name = "lblPorcDivideB"
        Me.lblPorcDivideB.Size = New System.Drawing.Size(15, 13)
        Me.lblPorcDivideB.TabIndex = 0
        Me.lblPorcDivideB.Text = "%"
        '
        'lblPorcDivideA
        '
        Me.lblPorcDivideA.AutoSize = True
        Me.lblPorcDivideA.LabelAsoc = Nothing
        Me.lblPorcDivideA.Location = New System.Drawing.Point(206, 36)
        Me.lblPorcDivideA.Name = "lblPorcDivideA"
        Me.lblPorcDivideA.Size = New System.Drawing.Size(15, 13)
        Me.lblPorcDivideA.TabIndex = 3
        Me.lblPorcDivideA.Text = "%"
        '
        'txtPorcDivideB
        '
        Me.txtPorcDivideB.BindearPropiedadControl = "Text"
        Me.txtPorcDivideB.BindearPropiedadEntidad = "PorcDivideB"
        Me.txtPorcDivideB.Enabled = False
        Me.txtPorcDivideB.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcDivideB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcDivideB.Formato = ""
        Me.txtPorcDivideB.IsDecimal = False
        Me.txtPorcDivideB.IsNumber = True
        Me.txtPorcDivideB.IsPK = False
        Me.txtPorcDivideB.IsRequired = False
        Me.txtPorcDivideB.Key = ""
        Me.txtPorcDivideB.LabelAsoc = Nothing
        Me.txtPorcDivideB.Location = New System.Drawing.Point(171, 59)
        Me.txtPorcDivideB.MaxLength = 2
        Me.txtPorcDivideB.Name = "txtPorcDivideB"
        Me.txtPorcDivideB.Size = New System.Drawing.Size(29, 20)
        Me.txtPorcDivideB.TabIndex = 6
        Me.txtPorcDivideB.Text = "0"
        Me.txtPorcDivideB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPorcDivideA
        '
        Me.txtPorcDivideA.BindearPropiedadControl = "Text"
        Me.txtPorcDivideA.BindearPropiedadEntidad = "PorcDivideA"
        Me.txtPorcDivideA.Enabled = False
        Me.txtPorcDivideA.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPorcDivideA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPorcDivideA.Formato = ""
        Me.txtPorcDivideA.IsDecimal = False
        Me.txtPorcDivideA.IsNumber = True
        Me.txtPorcDivideA.IsPK = False
        Me.txtPorcDivideA.IsRequired = False
        Me.txtPorcDivideA.Key = ""
        Me.txtPorcDivideA.LabelAsoc = Me.lblOrden
        Me.txtPorcDivideA.Location = New System.Drawing.Point(171, 33)
        Me.txtPorcDivideA.MaxLength = 2
        Me.txtPorcDivideA.Name = "txtPorcDivideA"
        Me.txtPorcDivideA.Size = New System.Drawing.Size(29, 20)
        Me.txtPorcDivideA.TabIndex = 2
        Me.txtPorcDivideA.Text = "0"
        Me.txtPorcDivideA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbEstadoDivideB
        '
        Me.cmbEstadoDivideB.BindearPropiedadControl = "Text"
        Me.cmbEstadoDivideB.BindearPropiedadEntidad = "IdEstadoDivideB"
        Me.cmbEstadoDivideB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoDivideB.Enabled = False
        Me.cmbEstadoDivideB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoDivideB.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoDivideB.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoDivideB.FormattingEnabled = True
        Me.cmbEstadoDivideB.IsPK = False
        Me.cmbEstadoDivideB.IsRequired = False
        Me.cmbEstadoDivideB.Key = Nothing
        Me.cmbEstadoDivideB.LabelAsoc = Nothing
        Me.cmbEstadoDivideB.Location = New System.Drawing.Point(7, 60)
        Me.cmbEstadoDivideB.Name = "cmbEstadoDivideB"
        Me.cmbEstadoDivideB.Size = New System.Drawing.Size(158, 21)
        Me.cmbEstadoDivideB.TabIndex = 5
        '
        'cmbEstadoDivideA
        '
        Me.cmbEstadoDivideA.BindearPropiedadControl = "Text"
        Me.cmbEstadoDivideA.BindearPropiedadEntidad = "IdEstadoDivideA"
        Me.cmbEstadoDivideA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoDivideA.Enabled = False
        Me.cmbEstadoDivideA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoDivideA.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoDivideA.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoDivideA.FormattingEnabled = True
        Me.cmbEstadoDivideA.IsPK = False
        Me.cmbEstadoDivideA.IsRequired = False
        Me.cmbEstadoDivideA.Key = Nothing
        Me.cmbEstadoDivideA.LabelAsoc = Nothing
        Me.cmbEstadoDivideA.Location = New System.Drawing.Point(7, 33)
        Me.cmbEstadoDivideA.Name = "cmbEstadoDivideA"
        Me.cmbEstadoDivideA.Size = New System.Drawing.Size(158, 21)
        Me.cmbEstadoDivideA.TabIndex = 1
        '
        'chbDivide
        '
        Me.chbDivide.AutoSize = True
        Me.chbDivide.BindearPropiedadControl = "Checked"
        Me.chbDivide.BindearPropiedadEntidad = "Divide"
        Me.chbDivide.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDivide.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDivide.IsPK = False
        Me.chbDivide.IsRequired = False
        Me.chbDivide.Key = Nothing
        Me.chbDivide.LabelAsoc = Nothing
        Me.chbDivide.Location = New System.Drawing.Point(9, 10)
        Me.chbDivide.Name = "chbDivide"
        Me.chbDivide.Size = New System.Drawing.Size(56, 17)
        Me.chbDivide.TabIndex = 0
        Me.chbDivide.Tag = ""
        Me.chbDivide.Text = "Divide"
        Me.chbDivide.UseVisualStyleBackColor = True
        '
        'chbSolicitaSucursalParaTipoComprobante
        '
        Me.chbSolicitaSucursalParaTipoComprobante.AutoSize = True
        Me.chbSolicitaSucursalParaTipoComprobante.BindearPropiedadControl = "Checked"
        Me.chbSolicitaSucursalParaTipoComprobante.BindearPropiedadEntidad = "SolicitaSucursalParaTipoComprobante"
        Me.chbSolicitaSucursalParaTipoComprobante.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSolicitaSucursalParaTipoComprobante.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSolicitaSucursalParaTipoComprobante.IsPK = False
        Me.chbSolicitaSucursalParaTipoComprobante.IsRequired = False
        Me.chbSolicitaSucursalParaTipoComprobante.Key = Nothing
        Me.chbSolicitaSucursalParaTipoComprobante.LabelAsoc = Nothing
        Me.chbSolicitaSucursalParaTipoComprobante.Location = New System.Drawing.Point(119, 65)
        Me.chbSolicitaSucursalParaTipoComprobante.Name = "chbSolicitaSucursalParaTipoComprobante"
        Me.chbSolicitaSucursalParaTipoComprobante.Size = New System.Drawing.Size(104, 17)
        Me.chbSolicitaSucursalParaTipoComprobante.TabIndex = 5
        Me.chbSolicitaSucursalParaTipoComprobante.Tag = ""
        Me.chbSolicitaSucursalParaTipoComprobante.Text = "Solicita Sucursal"
        Me.chbSolicitaSucursalParaTipoComprobante.UseVisualStyleBackColor = True
        '
        'grpReservaStock
        '
        Me.grpReservaStock.Controls.Add(Me.Label1)
        Me.grpReservaStock.Controls.Add(Me.cmbDepositoOrigen)
        Me.grpReservaStock.Controls.Add(Me.Label2)
        Me.grpReservaStock.Controls.Add(Me.cmbUbicacionOrigen)
        Me.grpReservaStock.Controls.Add(Me.chbReservaStock)
        Me.grpReservaStock.Location = New System.Drawing.Point(416, -3)
        Me.grpReservaStock.Name = "grpReservaStock"
        Me.grpReservaStock.Size = New System.Drawing.Size(231, 87)
        Me.grpReservaStock.TabIndex = 15
        Me.grpReservaStock.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(10, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Depósito"
        '
        'cmbDepositoOrigen
        '
        Me.cmbDepositoOrigen.BindearPropiedadControl = "SelectedValue"
        Me.cmbDepositoOrigen.BindearPropiedadEntidad = "IdDeposito"
        Me.cmbDepositoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepositoOrigen.Enabled = False
        Me.cmbDepositoOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepositoOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbDepositoOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbDepositoOrigen.FormattingEnabled = True
        Me.cmbDepositoOrigen.IsPK = False
        Me.cmbDepositoOrigen.IsRequired = False
        Me.cmbDepositoOrigen.Key = Nothing
        Me.cmbDepositoOrigen.LabelAsoc = Me.Label1
        Me.cmbDepositoOrigen.Location = New System.Drawing.Point(70, 34)
        Me.cmbDepositoOrigen.Name = "cmbDepositoOrigen"
        Me.cmbDepositoOrigen.Size = New System.Drawing.Size(151, 21)
        Me.cmbDepositoOrigen.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(10, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ubicación"
        '
        'cmbUbicacionOrigen
        '
        Me.cmbUbicacionOrigen.BindearPropiedadControl = "SelectedValue"
        Me.cmbUbicacionOrigen.BindearPropiedadEntidad = "IdUbicacion"
        Me.cmbUbicacionOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUbicacionOrigen.Enabled = False
        Me.cmbUbicacionOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUbicacionOrigen.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUbicacionOrigen.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUbicacionOrigen.FormattingEnabled = True
        Me.cmbUbicacionOrigen.IsPK = False
        Me.cmbUbicacionOrigen.IsRequired = False
        Me.cmbUbicacionOrigen.Key = Nothing
        Me.cmbUbicacionOrigen.LabelAsoc = Me.Label2
        Me.cmbUbicacionOrigen.Location = New System.Drawing.Point(70, 61)
        Me.cmbUbicacionOrigen.Name = "cmbUbicacionOrigen"
        Me.cmbUbicacionOrigen.Size = New System.Drawing.Size(151, 21)
        Me.cmbUbicacionOrigen.TabIndex = 4
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
        Me.cmbComprobantes.Location = New System.Drawing.Point(119, 38)
        Me.cmbComprobantes.Name = "cmbComprobantes"
        Me.cmbComprobantes.Size = New System.Drawing.Size(139, 21)
        Me.cmbComprobantes.TabIndex = 3
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
        Me.cmbTiposEstados.Location = New System.Drawing.Point(119, 92)
        Me.cmbTiposEstados.Name = "cmbTiposEstados"
        Me.cmbTiposEstados.Size = New System.Drawing.Size(139, 21)
        Me.cmbTiposEstados.TabIndex = 7
        '
        'ugEstadosRoles
        '
        Me.ugEstadosRoles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.ugEstadosRoles.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
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
        Me.ugEstadosRoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugEstadosRoles.Location = New System.Drawing.Point(362, 194)
        Me.ugEstadosRoles.Name = "ugEstadosRoles"
        Me.ugEstadosRoles.Size = New System.Drawing.Size(306, 217)
        Me.ugEstadosRoles.TabIndex = 33
        Me.ugEstadosRoles.Text = "UltraGrid2"
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
        Me.ugRoles.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
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
        Me.ugRoles.Location = New System.Drawing.Point(14, 194)
        Me.ugRoles.Name = "ugRoles"
        Me.ugRoles.Size = New System.Drawing.Size(238, 217)
        Me.ugRoles.TabIndex = 31
        '
        'ChbPermitirEscritura
        '
        Me.ChbPermitirEscritura.AutoSize = True
        Me.ChbPermitirEscritura.Checked = True
        Me.ChbPermitirEscritura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChbPermitirEscritura.Location = New System.Drawing.Point(258, 245)
        Me.ChbPermitirEscritura.Name = "ChbPermitirEscritura"
        Me.ChbPermitirEscritura.Size = New System.Drawing.Size(104, 17)
        Me.ChbPermitirEscritura.TabIndex = 34
        Me.ChbPermitirEscritura.Text = "Permitir Escritura"
        Me.ChbPermitirEscritura.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(357, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Roles del Estado"
        '
        'lblUsuarios
        '
        Me.lblUsuarios.AutoSize = True
        Me.lblUsuarios.LabelAsoc = Nothing
        Me.lblUsuarios.Location = New System.Drawing.Point(11, 178)
        Me.lblUsuarios.Name = "lblUsuarios"
        Me.lblUsuarios.Size = New System.Drawing.Size(34, 13)
        Me.lblUsuarios.TabIndex = 30
        Me.lblUsuarios.Text = "Roles"
        '
        'btnQuitar
        '
        Me.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuitar.Image = Global.Eniac.Win.My.Resources.Resources.delete_24
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.Location = New System.Drawing.Point(258, 314)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(98, 41)
        Me.btnQuitar.TabIndex = 36
        Me.btnQuitar.Text = "< Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnAgregar.Image = Global.Eniac.Win.My.Resources.Resources.add_24
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.Location = New System.Drawing.Point(258, 268)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(98, 41)
        Me.btnAgregar.TabIndex = 35
        Me.btnAgregar.Text = "Agregar >"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'EstadosPedidosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 457)
        Me.Controls.Add(Me.ugEstadosRoles)
        Me.Controls.Add(Me.ugRoles)
        Me.Controls.Add(Me.ChbPermitirEscritura)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblUsuarios)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.grpReservaStock)
        Me.Controls.Add(Me.chbSolicitaSucursalParaTipoComprobante)
        Me.Controls.Add(Me.grpDivide)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblColorSemadoro)
        Me.Controls.Add(Me.btnColor)
        Me.Controls.Add(Me.chbAfectaPendiente)
        Me.Controls.Add(Me.lblOrden)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.btnLimpiarTamaño)
        Me.Controls.Add(Me.lblIdTipoEstado)
        Me.Controls.Add(Me.txtidTipoEstado)
        Me.Controls.Add(Me.lblComprobante)
        Me.Controls.Add(Me.cmbComprobantes)
        Me.Controls.Add(Me.lblTipoEstado)
        Me.Controls.Add(Me.cmbTiposEstados)
        Me.Name = "EstadosPedidosDetalle"
        Me.Text = "Estado de Pedido"
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
        Me.Controls.SetChildIndex(Me.chbAfectaPendiente, 0)
        Me.Controls.SetChildIndex(Me.btnColor, 0)
        Me.Controls.SetChildIndex(Me.lblColorSemadoro, 0)
        Me.Controls.SetChildIndex(Me.txtColor, 0)
        Me.Controls.SetChildIndex(Me.grpDivide, 0)
        Me.Controls.SetChildIndex(Me.chbSolicitaSucursalParaTipoComprobante, 0)
        Me.Controls.SetChildIndex(Me.grpReservaStock, 0)
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnQuitar, 0)
        Me.Controls.SetChildIndex(Me.lblUsuarios, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.ChbPermitirEscritura, 0)
        Me.Controls.SetChildIndex(Me.ugRoles, 0)
        Me.Controls.SetChildIndex(Me.ugEstadosRoles, 0)
        Me.grpDivide.ResumeLayout(False)
        Me.grpDivide.PerformLayout()
        Me.grpReservaStock.ResumeLayout(False)
        Me.grpReservaStock.PerformLayout()
        CType(Me.ugEstadosRoles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugRoles, System.ComponentModel.ISupportInitialize).EndInit()
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
   Friend WithEvents chbAfectaPendiente As Eniac.Controles.CheckBox
   Friend WithEvents txtColor As Eniac.Controles.TextBox
   Friend WithEvents lblColorSemadoro As Eniac.Controles.Label
   Friend WithEvents btnColor As System.Windows.Forms.Button
   Friend WithEvents cdColor As System.Windows.Forms.ColorDialog
   Friend WithEvents chbReservaStock As Eniac.Controles.CheckBox
   Friend WithEvents grpDivide As System.Windows.Forms.GroupBox
   Friend WithEvents lblPorcDivideB As Eniac.Controles.Label
   Friend WithEvents lblPorcDivideA As Eniac.Controles.Label
   Friend WithEvents txtPorcDivideB As Eniac.Controles.TextBox
   Friend WithEvents txtPorcDivideA As Eniac.Controles.TextBox
   Friend WithEvents cmbEstadoDivideB As Eniac.Controles.ComboBox
   Friend WithEvents cmbEstadoDivideA As Eniac.Controles.ComboBox
   Friend WithEvents chbDivide As Eniac.Controles.CheckBox
   Friend WithEvents chbSolicitaSucursalParaTipoComprobante As Eniac.Controles.CheckBox
    Friend WithEvents grpReservaStock As GroupBox
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents cmbDepositoOrigen As Controles.ComboBox
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents cmbUbicacionOrigen As Controles.ComboBox
    Friend WithEvents ugEstadosRoles As UltraGrid
    Friend WithEvents ugRoles As UltraGrid
    Friend WithEvents ChbPermitirEscritura As CheckBox
    Friend WithEvents Label3 As Controles.Label
    Friend WithEvents lblUsuarios As Controles.Label
    Protected WithEvents btnQuitar As Button
    Protected WithEvents btnAgregar As Button
End Class
