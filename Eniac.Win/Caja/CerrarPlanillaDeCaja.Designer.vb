<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CerrarPlanillaDeCaja
   Inherits Eniac.Win.BaseForm  'System.Windows.Forms.Form

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CerrarPlanillaDeCaja))
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbFinalizarPlanilla = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbCerrar = New System.Windows.Forms.ToolStripButton()
      Me.grbPlanillaActual = New System.Windows.Forms.GroupBox()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
      Me.txtCotizacionDolaresSaldoCierre = New Eniac.Controles.TextBox()
      Me.lblPesos = New Eniac.Controles.Label()
      Me.lblCheques = New Eniac.Controles.Label()
      Me.lblBancosDolares = New Eniac.Controles.Label()
      Me.lblTarjetas = New Eniac.Controles.Label()
      Me.lblTickets = New Eniac.Controles.Label()
      Me.lblBancos = New Eniac.Controles.Label()
      Me.lblDolares = New Eniac.Controles.Label()
      Me.lblSaldoActual = New Eniac.Controles.Label()
      Me.txtPesosSaldoActual = New Eniac.Controles.TextBox()
      Me.txtChequesSaldoActual = New Eniac.Controles.TextBox()
      Me.txtTarjetasSaldoActual = New Eniac.Controles.TextBox()
      Me.txtTicketsSaldoActual = New Eniac.Controles.TextBox()
      Me.txtBancosSaldoActual = New Eniac.Controles.TextBox()
      Me.txtDolaresSaldoActual = New Eniac.Controles.TextBox()
      Me.txtBancosDolaresSaldoActual = New Eniac.Controles.TextBox()
      Me.txtPesosSaldoCierre = New Eniac.Controles.TextBox()
      Me.lblSaldoCierre = New Eniac.Controles.Label()
      Me.lblValores = New Eniac.Controles.Label()
      Me.txtTicketsSaldoCierre = New Eniac.Controles.TextBox()
      Me.txtBancosSaldoCierre = New Eniac.Controles.TextBox()
      Me.txtDolaresSaldoCierre = New Eniac.Controles.TextBox()
      Me.txtBancosDolaresSaldoCierre = New Eniac.Controles.TextBox()
      Me.txtBancosDolares = New Eniac.Controles.TextBox()
      Me.txtDolares = New Eniac.Controles.TextBox()
      Me.txtBancos = New Eniac.Controles.TextBox()
      Me.txtTickets = New Eniac.Controles.TextBox()
      Me.txtTarjetas = New Eniac.Controles.TextBox()
      Me.txtCheques = New Eniac.Controles.TextBox()
      Me.txtPesos = New Eniac.Controles.TextBox()
      Me.chbEntregaCheques = New Eniac.Controles.CheckBox()
      Me.chbEntregaCupones = New Eniac.Controles.CheckBox()
      Me.txtPesosTransferir = New Eniac.Controles.TextBox()
      Me.lblSaldoFinal = New Eniac.Controles.Label()
      Me.txtChequesTransferir = New Eniac.Controles.TextBox()
      Me.txtTarjetasTransferir = New Eniac.Controles.TextBox()
      Me.txtTicketsTransferir = New Eniac.Controles.TextBox()
      Me.txtBancosTransferir = New Eniac.Controles.TextBox()
      Me.txtDolaresTransferir = New Eniac.Controles.TextBox()
      Me.txtBancosDolaresTransferir = New Eniac.Controles.TextBox()
      Me.lblCotizacionDolares = New Eniac.Controles.Label()
      Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
      Me.lblCaja = New Eniac.Controles.Label()
      Me.lblModoPantalla = New Eniac.Controles.Label()
      Me.cmbCajas = New Eniac.Controles.ComboBox()
      Me.cmbSucursalDestino = New Eniac.Controles.ComboBox()
      Me.lblSucursalDestino = New Eniac.Controles.Label()
      Me.txtNroPlanillaActual = New Eniac.Controles.MaskedTextBox()
      Me.Label21 = New Eniac.Controles.Label()
      Me.txtPACFecha = New Eniac.Controles.MaskedTextBox()
      Me.lblFechaPlaActual = New Eniac.Controles.Label()
      Me.cmbCajasDestino = New Eniac.Controles.ComboBox()
      Me.lblCajaDestino = New Eniac.Controles.Label()
        Me.tstBarra.SuspendLayout()
        Me.grbPlanillaActual.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbFinalizarPlanilla, Me.ToolStripSeparator3, Me.tsbCerrar})
        Me.tstBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.MinimumSize = New System.Drawing.Size(0, 29)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(515, 29)
        Me.tstBarra.TabIndex = 1
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbFinalizarPlanilla
        '
        Me.tsbFinalizarPlanilla.Image = Global.Eniac.Win.My.Resources.Resources.keys
        Me.tsbFinalizarPlanilla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFinalizarPlanilla.Name = "tsbFinalizarPlanilla"
        Me.tsbFinalizarPlanilla.Size = New System.Drawing.Size(140, 26)
        Me.tsbFinalizarPlanilla.Text = "&Finalizar Planilla (F4)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbCerrar
        '
        Me.tsbCerrar.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCerrar.Name = "tsbCerrar"
        Me.tsbCerrar.Size = New System.Drawing.Size(65, 26)
        Me.tsbCerrar.Text = "&Cerrar"
        '
        'grbPlanillaActual
        '
        Me.grbPlanillaActual.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPlanillaActual.BackColor = System.Drawing.SystemColors.Control
        Me.grbPlanillaActual.Controls.Add(Me.TableLayoutPanel1)
        Me.grbPlanillaActual.Controls.Add(Me.TableLayoutPanel2)
        Me.grbPlanillaActual.Location = New System.Drawing.Point(5, 31)
        Me.grbPlanillaActual.Name = "grbPlanillaActual"
        Me.grbPlanillaActual.Size = New System.Drawing.Size(504, 371)
        Me.grbPlanillaActual.TabIndex = 0
        Me.grbPlanillaActual.TabStop = False
        Me.grbPlanillaActual.Text = "Planilla Actual"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtCotizacionDolaresSaldoCierre, 3, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPesos, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCheques, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBancosDolares, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTarjetas, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTickets, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBancos, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDolares, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSaldoActual, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPesosSaldoActual, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtChequesSaldoActual, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTarjetasSaldoActual, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTicketsSaldoActual, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBancosSaldoActual, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDolaresSaldoActual, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBancosDolaresSaldoActual, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPesosSaldoCierre, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSaldoCierre, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblValores, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTicketsSaldoCierre, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBancosSaldoCierre, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDolaresSaldoCierre, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBancosDolaresSaldoCierre, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBancosDolares, 5, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDolares, 5, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBancos, 5, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTickets, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTarjetas, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCheques, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPesos, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.chbEntregaCheques, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.chbEntregaCupones, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtPesosTransferir, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSaldoFinal, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtChequesTransferir, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTarjetasTransferir, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTicketsTransferir, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBancosTransferir, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDolaresTransferir, 4, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBancosDolaresTransferir, 4, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCotizacionDolares, 1, 8)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 117)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 10
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(498, 251)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'txtCotizacionDolaresSaldoCierre
        '
        Me.txtCotizacionDolaresSaldoCierre.BindearPropiedadControl = Nothing
        Me.txtCotizacionDolaresSaldoCierre.BindearPropiedadEntidad = Nothing
        Me.txtCotizacionDolaresSaldoCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCotizacionDolaresSaldoCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCotizacionDolaresSaldoCierre.Formato = "N2"
        Me.txtCotizacionDolaresSaldoCierre.IsDecimal = True
        Me.txtCotizacionDolaresSaldoCierre.IsNumber = True
        Me.txtCotizacionDolaresSaldoCierre.IsPK = False
        Me.txtCotizacionDolaresSaldoCierre.IsRequired = False
        Me.txtCotizacionDolaresSaldoCierre.Key = ""
        Me.txtCotizacionDolaresSaldoCierre.LabelAsoc = Nothing
        Me.txtCotizacionDolaresSaldoCierre.Location = New System.Drawing.Point(191, 215)
        Me.txtCotizacionDolaresSaldoCierre.Name = "txtCotizacionDolaresSaldoCierre"
        Me.txtCotizacionDolaresSaldoCierre.Size = New System.Drawing.Size(62, 20)
        Me.txtCotizacionDolaresSaldoCierre.TabIndex = 25
        Me.txtCotizacionDolaresSaldoCierre.Text = "0.00"
        Me.txtCotizacionDolaresSaldoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPesos
        '
        Me.lblPesos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPesos.AutoSize = True
        Me.lblPesos.LabelAsoc = Nothing
        Me.lblPesos.Location = New System.Drawing.Point(7, 36)
        Me.lblPesos.Name = "lblPesos"
        Me.lblPesos.Size = New System.Drawing.Size(36, 13)
        Me.lblPesos.TabIndex = 4
        Me.lblPesos.Text = "Pesos"
        '
        'lblCheques
        '
        Me.lblCheques.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCheques.AutoSize = True
        Me.lblCheques.LabelAsoc = Nothing
        Me.lblCheques.Location = New System.Drawing.Point(7, 62)
        Me.lblCheques.Name = "lblCheques"
        Me.lblCheques.Size = New System.Drawing.Size(49, 13)
        Me.lblCheques.TabIndex = 5
        Me.lblCheques.Text = "Cheques"
        '
        'lblBancosDolares
        '
        Me.lblBancosDolares.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBancosDolares.AutoSize = True
        Me.lblBancosDolares.LabelAsoc = Nothing
        Me.lblBancosDolares.Location = New System.Drawing.Point(7, 192)
        Me.lblBancosDolares.Name = "lblBancosDolares"
        Me.lblBancosDolares.Size = New System.Drawing.Size(82, 13)
        Me.lblBancosDolares.TabIndex = 10
        Me.lblBancosDolares.Text = "Bancos Dolares"
        '
        'lblTarjetas
        '
        Me.lblTarjetas.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTarjetas.AutoSize = True
        Me.lblTarjetas.LabelAsoc = Nothing
        Me.lblTarjetas.Location = New System.Drawing.Point(7, 88)
        Me.lblTarjetas.Name = "lblTarjetas"
        Me.lblTarjetas.Size = New System.Drawing.Size(45, 13)
        Me.lblTarjetas.TabIndex = 6
        Me.lblTarjetas.Text = "Tarjetas"
        '
        'lblTickets
        '
        Me.lblTickets.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTickets.AutoSize = True
        Me.lblTickets.LabelAsoc = Nothing
        Me.lblTickets.Location = New System.Drawing.Point(7, 114)
        Me.lblTickets.Name = "lblTickets"
        Me.lblTickets.Size = New System.Drawing.Size(42, 13)
        Me.lblTickets.TabIndex = 7
        Me.lblTickets.Text = "Tickets"
        '
        'lblBancos
        '
        Me.lblBancos.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblBancos.AutoSize = True
        Me.lblBancos.LabelAsoc = Nothing
        Me.lblBancos.Location = New System.Drawing.Point(7, 140)
        Me.lblBancos.Name = "lblBancos"
        Me.lblBancos.Size = New System.Drawing.Size(43, 13)
        Me.lblBancos.TabIndex = 8
        Me.lblBancos.Text = "Bancos"
        '
        'lblDolares
        '
        Me.lblDolares.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblDolares.AutoSize = True
        Me.lblDolares.LabelAsoc = Nothing
        Me.lblDolares.Location = New System.Drawing.Point(7, 166)
        Me.lblDolares.Name = "lblDolares"
        Me.lblDolares.Size = New System.Drawing.Size(43, 13)
        Me.lblDolares.TabIndex = 9
        Me.lblDolares.Text = "Dolares"
        '
        'lblSaldoActual
        '
        Me.lblSaldoActual.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblSaldoActual.AutoSize = True
        Me.lblSaldoActual.LabelAsoc = Nothing
        Me.lblSaldoActual.Location = New System.Drawing.Point(96, 17)
        Me.lblSaldoActual.Name = "lblSaldoActual"
        Me.lblSaldoActual.Size = New System.Drawing.Size(88, 13)
        Me.lblSaldoActual.TabIndex = 0
        Me.lblSaldoActual.Text = "SALDO ACTUAL"
        '
        'txtPesosSaldoActual
        '
        Me.txtPesosSaldoActual.BindearPropiedadControl = ""
        Me.txtPesosSaldoActual.BindearPropiedadEntidad = ""
        Me.txtPesosSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPesosSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPesosSaldoActual.Formato = "N2"
        Me.txtPesosSaldoActual.IsDecimal = True
        Me.txtPesosSaldoActual.IsNumber = True
        Me.txtPesosSaldoActual.IsPK = False
        Me.txtPesosSaldoActual.IsRequired = False
        Me.txtPesosSaldoActual.Key = ""
        Me.txtPesosSaldoActual.LabelAsoc = Nothing
        Me.txtPesosSaldoActual.Location = New System.Drawing.Point(95, 33)
        Me.txtPesosSaldoActual.MaxLength = 20
        Me.txtPesosSaldoActual.Name = "txtPesosSaldoActual"
        Me.txtPesosSaldoActual.ReadOnly = True
        Me.txtPesosSaldoActual.Size = New System.Drawing.Size(90, 20)
        Me.txtPesosSaldoActual.TabIndex = 11
        Me.txtPesosSaldoActual.Text = "0.00"
        Me.txtPesosSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtChequesSaldoActual
        '
        Me.txtChequesSaldoActual.BindearPropiedadControl = ""
        Me.txtChequesSaldoActual.BindearPropiedadEntidad = ""
        Me.txtChequesSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtChequesSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtChequesSaldoActual.Formato = "N2"
        Me.txtChequesSaldoActual.IsDecimal = True
        Me.txtChequesSaldoActual.IsNumber = True
        Me.txtChequesSaldoActual.IsPK = False
        Me.txtChequesSaldoActual.IsRequired = False
        Me.txtChequesSaldoActual.Key = ""
        Me.txtChequesSaldoActual.LabelAsoc = Nothing
        Me.txtChequesSaldoActual.Location = New System.Drawing.Point(95, 59)
        Me.txtChequesSaldoActual.MaxLength = 20
        Me.txtChequesSaldoActual.Name = "txtChequesSaldoActual"
        Me.txtChequesSaldoActual.ReadOnly = True
        Me.txtChequesSaldoActual.Size = New System.Drawing.Size(90, 20)
        Me.txtChequesSaldoActual.TabIndex = 12
        Me.txtChequesSaldoActual.Text = "0.00"
        Me.txtChequesSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTarjetasSaldoActual
        '
        Me.txtTarjetasSaldoActual.BindearPropiedadControl = ""
        Me.txtTarjetasSaldoActual.BindearPropiedadEntidad = ""
        Me.txtTarjetasSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarjetasSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarjetasSaldoActual.Formato = "N2"
        Me.txtTarjetasSaldoActual.IsDecimal = True
        Me.txtTarjetasSaldoActual.IsNumber = True
        Me.txtTarjetasSaldoActual.IsPK = False
        Me.txtTarjetasSaldoActual.IsRequired = False
        Me.txtTarjetasSaldoActual.Key = ""
        Me.txtTarjetasSaldoActual.LabelAsoc = Nothing
        Me.txtTarjetasSaldoActual.Location = New System.Drawing.Point(95, 85)
        Me.txtTarjetasSaldoActual.MaxLength = 20
        Me.txtTarjetasSaldoActual.Name = "txtTarjetasSaldoActual"
        Me.txtTarjetasSaldoActual.ReadOnly = True
        Me.txtTarjetasSaldoActual.Size = New System.Drawing.Size(90, 20)
        Me.txtTarjetasSaldoActual.TabIndex = 13
        Me.txtTarjetasSaldoActual.Text = "0.00"
        Me.txtTarjetasSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTicketsSaldoActual
        '
        Me.txtTicketsSaldoActual.BindearPropiedadControl = ""
        Me.txtTicketsSaldoActual.BindearPropiedadEntidad = ""
        Me.txtTicketsSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTicketsSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTicketsSaldoActual.Formato = "N2"
        Me.txtTicketsSaldoActual.IsDecimal = True
        Me.txtTicketsSaldoActual.IsNumber = True
        Me.txtTicketsSaldoActual.IsPK = False
        Me.txtTicketsSaldoActual.IsRequired = False
        Me.txtTicketsSaldoActual.Key = ""
        Me.txtTicketsSaldoActual.LabelAsoc = Nothing
        Me.txtTicketsSaldoActual.Location = New System.Drawing.Point(95, 111)
        Me.txtTicketsSaldoActual.MaxLength = 20
        Me.txtTicketsSaldoActual.Name = "txtTicketsSaldoActual"
        Me.txtTicketsSaldoActual.ReadOnly = True
        Me.txtTicketsSaldoActual.Size = New System.Drawing.Size(90, 20)
        Me.txtTicketsSaldoActual.TabIndex = 14
        Me.txtTicketsSaldoActual.Text = "0.00"
        Me.txtTicketsSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBancosSaldoActual
        '
        Me.txtBancosSaldoActual.BindearPropiedadControl = ""
        Me.txtBancosSaldoActual.BindearPropiedadEntidad = ""
        Me.txtBancosSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancosSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancosSaldoActual.Formato = "N2"
        Me.txtBancosSaldoActual.IsDecimal = True
        Me.txtBancosSaldoActual.IsNumber = True
        Me.txtBancosSaldoActual.IsPK = False
        Me.txtBancosSaldoActual.IsRequired = False
        Me.txtBancosSaldoActual.Key = ""
        Me.txtBancosSaldoActual.LabelAsoc = Nothing
        Me.txtBancosSaldoActual.Location = New System.Drawing.Point(95, 137)
        Me.txtBancosSaldoActual.MaxLength = 20
        Me.txtBancosSaldoActual.Name = "txtBancosSaldoActual"
        Me.txtBancosSaldoActual.ReadOnly = True
        Me.txtBancosSaldoActual.Size = New System.Drawing.Size(90, 20)
        Me.txtBancosSaldoActual.TabIndex = 15
        Me.txtBancosSaldoActual.Text = "0.00"
        Me.txtBancosSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolaresSaldoActual
        '
        Me.txtDolaresSaldoActual.BindearPropiedadControl = ""
        Me.txtDolaresSaldoActual.BindearPropiedadEntidad = ""
        Me.txtDolaresSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDolaresSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDolaresSaldoActual.Formato = "N2"
        Me.txtDolaresSaldoActual.IsDecimal = True
        Me.txtDolaresSaldoActual.IsNumber = True
        Me.txtDolaresSaldoActual.IsPK = False
        Me.txtDolaresSaldoActual.IsRequired = False
        Me.txtDolaresSaldoActual.Key = ""
        Me.txtDolaresSaldoActual.LabelAsoc = Nothing
        Me.txtDolaresSaldoActual.Location = New System.Drawing.Point(95, 163)
        Me.txtDolaresSaldoActual.MaxLength = 20
        Me.txtDolaresSaldoActual.Name = "txtDolaresSaldoActual"
        Me.txtDolaresSaldoActual.ReadOnly = True
        Me.txtDolaresSaldoActual.Size = New System.Drawing.Size(90, 20)
        Me.txtDolaresSaldoActual.TabIndex = 16
        Me.txtDolaresSaldoActual.Text = "0.00"
        Me.txtDolaresSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBancosDolaresSaldoActual
        '
        Me.txtBancosDolaresSaldoActual.BindearPropiedadControl = ""
        Me.txtBancosDolaresSaldoActual.BindearPropiedadEntidad = ""
        Me.txtBancosDolaresSaldoActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancosDolaresSaldoActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancosDolaresSaldoActual.Formato = "N2"
        Me.txtBancosDolaresSaldoActual.IsDecimal = True
        Me.txtBancosDolaresSaldoActual.IsNumber = True
        Me.txtBancosDolaresSaldoActual.IsPK = False
        Me.txtBancosDolaresSaldoActual.IsRequired = False
        Me.txtBancosDolaresSaldoActual.Key = ""
        Me.txtBancosDolaresSaldoActual.LabelAsoc = Nothing
        Me.txtBancosDolaresSaldoActual.Location = New System.Drawing.Point(95, 189)
        Me.txtBancosDolaresSaldoActual.MaxLength = 20
        Me.txtBancosDolaresSaldoActual.Name = "txtBancosDolaresSaldoActual"
        Me.txtBancosDolaresSaldoActual.ReadOnly = True
        Me.txtBancosDolaresSaldoActual.Size = New System.Drawing.Size(90, 20)
        Me.txtBancosDolaresSaldoActual.TabIndex = 17
        Me.txtBancosDolaresSaldoActual.Text = "0.00"
        Me.txtBancosDolaresSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPesosSaldoCierre
        '
        Me.txtPesosSaldoCierre.BindearPropiedadControl = ""
        Me.txtPesosSaldoCierre.BindearPropiedadEntidad = ""
        Me.txtPesosSaldoCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPesosSaldoCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPesosSaldoCierre.Formato = "N2"
        Me.txtPesosSaldoCierre.IsDecimal = True
        Me.txtPesosSaldoCierre.IsNumber = True
        Me.txtPesosSaldoCierre.IsPK = False
        Me.txtPesosSaldoCierre.IsRequired = False
        Me.txtPesosSaldoCierre.Key = ""
        Me.txtPesosSaldoCierre.LabelAsoc = Me.lblPesos
        Me.txtPesosSaldoCierre.Location = New System.Drawing.Point(191, 33)
        Me.txtPesosSaldoCierre.MaxLength = 20
        Me.txtPesosSaldoCierre.Name = "txtPesosSaldoCierre"
        Me.txtPesosSaldoCierre.Size = New System.Drawing.Size(90, 20)
        Me.txtPesosSaldoCierre.TabIndex = 18
        Me.txtPesosSaldoCierre.Text = "0.00"
        Me.txtPesosSaldoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoCierre
        '
        Me.lblSaldoCierre.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblSaldoCierre.AutoSize = True
        Me.lblSaldoCierre.LabelAsoc = Nothing
        Me.lblSaldoCierre.Location = New System.Drawing.Point(194, 17)
        Me.lblSaldoCierre.Name = "lblSaldoCierre"
        Me.lblSaldoCierre.Size = New System.Drawing.Size(102, 13)
        Me.lblSaldoCierre.TabIndex = 1
        Me.lblSaldoCierre.Text = "SALDO AL CIERRE"
        '
        'lblValores
        '
        Me.lblValores.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblValores.AutoSize = True
        Me.lblValores.LabelAsoc = Nothing
        Me.lblValores.Location = New System.Drawing.Point(417, 17)
        Me.lblValores.Name = "lblValores"
        Me.lblValores.Size = New System.Drawing.Size(57, 13)
        Me.lblValores.TabIndex = 3
        Me.lblValores.Text = "VALORES"
        '
        'txtTicketsSaldoCierre
        '
        Me.txtTicketsSaldoCierre.BindearPropiedadControl = ""
        Me.txtTicketsSaldoCierre.BindearPropiedadEntidad = ""
        Me.txtTicketsSaldoCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTicketsSaldoCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTicketsSaldoCierre.Formato = "N2"
        Me.txtTicketsSaldoCierre.IsDecimal = True
        Me.txtTicketsSaldoCierre.IsNumber = True
        Me.txtTicketsSaldoCierre.IsPK = False
        Me.txtTicketsSaldoCierre.IsRequired = False
        Me.txtTicketsSaldoCierre.Key = ""
        Me.txtTicketsSaldoCierre.LabelAsoc = Nothing
        Me.txtTicketsSaldoCierre.Location = New System.Drawing.Point(191, 111)
        Me.txtTicketsSaldoCierre.MaxLength = 20
        Me.txtTicketsSaldoCierre.Name = "txtTicketsSaldoCierre"
        Me.txtTicketsSaldoCierre.Size = New System.Drawing.Size(90, 20)
        Me.txtTicketsSaldoCierre.TabIndex = 21
        Me.txtTicketsSaldoCierre.Text = "0.00"
        Me.txtTicketsSaldoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBancosSaldoCierre
        '
        Me.txtBancosSaldoCierre.BindearPropiedadControl = ""
        Me.txtBancosSaldoCierre.BindearPropiedadEntidad = ""
        Me.txtBancosSaldoCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancosSaldoCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancosSaldoCierre.Formato = "N2"
        Me.txtBancosSaldoCierre.IsDecimal = True
        Me.txtBancosSaldoCierre.IsNumber = True
        Me.txtBancosSaldoCierre.IsPK = False
        Me.txtBancosSaldoCierre.IsRequired = False
        Me.txtBancosSaldoCierre.Key = ""
        Me.txtBancosSaldoCierre.LabelAsoc = Nothing
        Me.txtBancosSaldoCierre.Location = New System.Drawing.Point(191, 137)
        Me.txtBancosSaldoCierre.MaxLength = 20
        Me.txtBancosSaldoCierre.Name = "txtBancosSaldoCierre"
        Me.txtBancosSaldoCierre.Size = New System.Drawing.Size(90, 20)
        Me.txtBancosSaldoCierre.TabIndex = 22
        Me.txtBancosSaldoCierre.Text = "0.00"
        Me.txtBancosSaldoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolaresSaldoCierre
        '
        Me.txtDolaresSaldoCierre.BindearPropiedadControl = ""
        Me.txtDolaresSaldoCierre.BindearPropiedadEntidad = ""
        Me.txtDolaresSaldoCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDolaresSaldoCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDolaresSaldoCierre.Formato = "N2"
        Me.txtDolaresSaldoCierre.IsDecimal = True
        Me.txtDolaresSaldoCierre.IsNumber = True
        Me.txtDolaresSaldoCierre.IsPK = False
        Me.txtDolaresSaldoCierre.IsRequired = False
        Me.txtDolaresSaldoCierre.Key = ""
        Me.txtDolaresSaldoCierre.LabelAsoc = Nothing
        Me.txtDolaresSaldoCierre.Location = New System.Drawing.Point(191, 163)
        Me.txtDolaresSaldoCierre.MaxLength = 20
        Me.txtDolaresSaldoCierre.Name = "txtDolaresSaldoCierre"
        Me.txtDolaresSaldoCierre.Size = New System.Drawing.Size(90, 20)
        Me.txtDolaresSaldoCierre.TabIndex = 23
        Me.txtDolaresSaldoCierre.Text = "0.00"
        Me.txtDolaresSaldoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBancosDolaresSaldoCierre
        '
        Me.txtBancosDolaresSaldoCierre.BindearPropiedadControl = ""
        Me.txtBancosDolaresSaldoCierre.BindearPropiedadEntidad = ""
        Me.txtBancosDolaresSaldoCierre.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancosDolaresSaldoCierre.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancosDolaresSaldoCierre.Formato = "N2"
        Me.txtBancosDolaresSaldoCierre.IsDecimal = True
        Me.txtBancosDolaresSaldoCierre.IsNumber = True
        Me.txtBancosDolaresSaldoCierre.IsPK = False
        Me.txtBancosDolaresSaldoCierre.IsRequired = False
        Me.txtBancosDolaresSaldoCierre.Key = ""
        Me.txtBancosDolaresSaldoCierre.LabelAsoc = Nothing
        Me.txtBancosDolaresSaldoCierre.Location = New System.Drawing.Point(191, 189)
        Me.txtBancosDolaresSaldoCierre.MaxLength = 20
        Me.txtBancosDolaresSaldoCierre.Name = "txtBancosDolaresSaldoCierre"
        Me.txtBancosDolaresSaldoCierre.Size = New System.Drawing.Size(90, 20)
        Me.txtBancosDolaresSaldoCierre.TabIndex = 24
        Me.txtBancosDolaresSaldoCierre.Text = "0.00"
        Me.txtBancosDolaresSaldoCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBancosDolares
        '
        Me.txtBancosDolares.BindearPropiedadControl = ""
        Me.txtBancosDolares.BindearPropiedadEntidad = ""
        Me.txtBancosDolares.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancosDolares.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancosDolares.Formato = "N2"
        Me.txtBancosDolares.IsDecimal = True
        Me.txtBancosDolares.IsNumber = True
        Me.txtBancosDolares.IsPK = False
        Me.txtBancosDolares.IsRequired = False
        Me.txtBancosDolares.Key = ""
        Me.txtBancosDolares.LabelAsoc = Me.lblBancosDolares
        Me.txtBancosDolares.Location = New System.Drawing.Point(401, 189)
        Me.txtBancosDolares.MaxLength = 20
        Me.txtBancosDolares.Name = "txtBancosDolares"
        Me.txtBancosDolares.Size = New System.Drawing.Size(90, 20)
        Me.txtBancosDolares.TabIndex = 39
        Me.txtBancosDolares.Text = "0.00"
        Me.txtBancosDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolares
        '
        Me.txtDolares.BindearPropiedadControl = ""
        Me.txtDolares.BindearPropiedadEntidad = ""
        Me.txtDolares.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDolares.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDolares.Formato = "N2"
        Me.txtDolares.IsDecimal = True
        Me.txtDolares.IsNumber = True
        Me.txtDolares.IsPK = False
        Me.txtDolares.IsRequired = False
        Me.txtDolares.Key = ""
        Me.txtDolares.LabelAsoc = Me.lblDolares
        Me.txtDolares.Location = New System.Drawing.Point(401, 163)
        Me.txtDolares.MaxLength = 20
        Me.txtDolares.Name = "txtDolares"
        Me.txtDolares.Size = New System.Drawing.Size(90, 20)
        Me.txtDolares.TabIndex = 38
        Me.txtDolares.Text = "0.00"
        Me.txtDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBancos
        '
        Me.txtBancos.BindearPropiedadControl = ""
        Me.txtBancos.BindearPropiedadEntidad = ""
        Me.txtBancos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancos.Formato = "N2"
        Me.txtBancos.IsDecimal = True
        Me.txtBancos.IsNumber = True
        Me.txtBancos.IsPK = False
        Me.txtBancos.IsRequired = False
        Me.txtBancos.Key = ""
        Me.txtBancos.LabelAsoc = Me.lblBancos
        Me.txtBancos.Location = New System.Drawing.Point(401, 137)
        Me.txtBancos.MaxLength = 20
        Me.txtBancos.Name = "txtBancos"
        Me.txtBancos.Size = New System.Drawing.Size(90, 20)
        Me.txtBancos.TabIndex = 37
        Me.txtBancos.Text = "0.00"
        Me.txtBancos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTickets
        '
        Me.txtTickets.BindearPropiedadControl = ""
        Me.txtTickets.BindearPropiedadEntidad = ""
        Me.txtTickets.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTickets.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTickets.Formato = "N2"
        Me.txtTickets.IsDecimal = True
        Me.txtTickets.IsNumber = True
        Me.txtTickets.IsPK = False
        Me.txtTickets.IsRequired = False
        Me.txtTickets.Key = ""
        Me.txtTickets.LabelAsoc = Me.lblTickets
        Me.txtTickets.Location = New System.Drawing.Point(401, 111)
        Me.txtTickets.MaxLength = 20
        Me.txtTickets.Name = "txtTickets"
        Me.txtTickets.Size = New System.Drawing.Size(90, 20)
        Me.txtTickets.TabIndex = 36
        Me.txtTickets.Text = "0.00"
        Me.txtTickets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTarjetas
        '
        Me.txtTarjetas.BindearPropiedadControl = ""
        Me.txtTarjetas.BindearPropiedadEntidad = ""
        Me.txtTarjetas.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarjetas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarjetas.Formato = "N2"
        Me.txtTarjetas.IsDecimal = True
        Me.txtTarjetas.IsNumber = True
        Me.txtTarjetas.IsPK = False
        Me.txtTarjetas.IsRequired = False
        Me.txtTarjetas.Key = ""
        Me.txtTarjetas.LabelAsoc = Me.lblTarjetas
        Me.txtTarjetas.Location = New System.Drawing.Point(401, 85)
        Me.txtTarjetas.MaxLength = 20
        Me.txtTarjetas.Name = "txtTarjetas"
        Me.txtTarjetas.Size = New System.Drawing.Size(90, 20)
        Me.txtTarjetas.TabIndex = 35
        Me.txtTarjetas.Text = "0.00"
        Me.txtTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCheques
        '
        Me.txtCheques.BindearPropiedadControl = ""
        Me.txtCheques.BindearPropiedadEntidad = ""
        Me.txtCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCheques.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCheques.Formato = "N2"
        Me.txtCheques.IsDecimal = True
        Me.txtCheques.IsNumber = True
        Me.txtCheques.IsPK = False
        Me.txtCheques.IsRequired = False
        Me.txtCheques.Key = ""
        Me.txtCheques.LabelAsoc = Me.lblCheques
        Me.txtCheques.Location = New System.Drawing.Point(401, 59)
        Me.txtCheques.MaxLength = 20
        Me.txtCheques.Name = "txtCheques"
        Me.txtCheques.Size = New System.Drawing.Size(90, 20)
        Me.txtCheques.TabIndex = 34
        Me.txtCheques.Text = "0.00"
        Me.txtCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPesos
        '
        Me.txtPesos.BindearPropiedadControl = ""
        Me.txtPesos.BindearPropiedadEntidad = ""
        Me.txtPesos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPesos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPesos.Formato = "N2"
        Me.txtPesos.IsDecimal = True
        Me.txtPesos.IsNumber = True
        Me.txtPesos.IsPK = False
        Me.txtPesos.IsRequired = False
        Me.txtPesos.Key = ""
        Me.txtPesos.LabelAsoc = Me.lblPesos
        Me.txtPesos.Location = New System.Drawing.Point(401, 33)
        Me.txtPesos.MaxLength = 20
        Me.txtPesos.Name = "txtPesos"
        Me.txtPesos.Size = New System.Drawing.Size(90, 20)
        Me.txtPesos.TabIndex = 33
        Me.txtPesos.Text = "0.00"
        Me.txtPesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbEntregaCheques
        '
        Me.chbEntregaCheques.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chbEntregaCheques.AutoSize = True
        Me.chbEntregaCheques.BindearPropiedadControl = Nothing
        Me.chbEntregaCheques.BindearPropiedadEntidad = Nothing
        Me.chbEntregaCheques.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEntregaCheques.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEntregaCheques.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbEntregaCheques.ImageIndex = 0
        Me.chbEntregaCheques.IsPK = False
        Me.chbEntregaCheques.IsRequired = False
        Me.chbEntregaCheques.Key = Nothing
        Me.chbEntregaCheques.LabelAsoc = Nothing
        Me.chbEntregaCheques.Location = New System.Drawing.Point(191, 60)
        Me.chbEntregaCheques.Name = "chbEntregaCheques"
        Me.chbEntregaCheques.Size = New System.Drawing.Size(108, 17)
        Me.chbEntregaCheques.TabIndex = 19
        Me.chbEntregaCheques.Text = "Entrega Cheques"
        Me.chbEntregaCheques.UseVisualStyleBackColor = True
        '
        'chbEntregaCupones
        '
        Me.chbEntregaCupones.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chbEntregaCupones.AutoSize = True
        Me.chbEntregaCupones.BindearPropiedadControl = Nothing
        Me.chbEntregaCupones.BindearPropiedadEntidad = Nothing
        Me.chbEntregaCupones.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEntregaCupones.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEntregaCupones.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbEntregaCupones.ImageIndex = 0
        Me.chbEntregaCupones.IsPK = False
        Me.chbEntregaCupones.IsRequired = False
        Me.chbEntregaCupones.Key = Nothing
        Me.chbEntregaCupones.LabelAsoc = Nothing
        Me.chbEntregaCupones.Location = New System.Drawing.Point(191, 86)
        Me.chbEntregaCupones.Name = "chbEntregaCupones"
        Me.chbEntregaCupones.Size = New System.Drawing.Size(108, 17)
        Me.chbEntregaCupones.TabIndex = 20
        Me.chbEntregaCupones.Text = "Entrega Cupones"
        Me.chbEntregaCupones.UseVisualStyleBackColor = True
        '
        'txtPesosTransferir
        '
        Me.txtPesosTransferir.BindearPropiedadControl = ""
        Me.txtPesosTransferir.BindearPropiedadEntidad = ""
        Me.txtPesosTransferir.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPesosTransferir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPesosTransferir.Formato = "N2"
        Me.txtPesosTransferir.IsDecimal = True
        Me.txtPesosTransferir.IsNumber = True
        Me.txtPesosTransferir.IsPK = False
        Me.txtPesosTransferir.IsRequired = False
        Me.txtPesosTransferir.Key = ""
        Me.txtPesosTransferir.LabelAsoc = Nothing
        Me.txtPesosTransferir.Location = New System.Drawing.Point(305, 33)
        Me.txtPesosTransferir.MaxLength = 20
        Me.txtPesosTransferir.Name = "txtPesosTransferir"
        Me.txtPesosTransferir.ReadOnly = True
        Me.txtPesosTransferir.Size = New System.Drawing.Size(90, 20)
        Me.txtPesosTransferir.TabIndex = 26
        Me.txtPesosTransferir.Text = "0.00"
        Me.txtPesosTransferir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblSaldoFinal.AutoSize = True
        Me.lblSaldoFinal.LabelAsoc = Nothing
        Me.lblSaldoFinal.Location = New System.Drawing.Point(312, 17)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(76, 13)
        Me.lblSaldoFinal.TabIndex = 2
        Me.lblSaldoFinal.Text = "TRANSFERIR"
        '
        'txtChequesTransferir
        '
        Me.txtChequesTransferir.BindearPropiedadControl = ""
        Me.txtChequesTransferir.BindearPropiedadEntidad = ""
        Me.txtChequesTransferir.ForeColorFocus = System.Drawing.Color.Red
        Me.txtChequesTransferir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtChequesTransferir.Formato = "N2"
        Me.txtChequesTransferir.IsDecimal = True
        Me.txtChequesTransferir.IsNumber = True
        Me.txtChequesTransferir.IsPK = False
        Me.txtChequesTransferir.IsRequired = False
        Me.txtChequesTransferir.Key = ""
        Me.txtChequesTransferir.LabelAsoc = Nothing
        Me.txtChequesTransferir.Location = New System.Drawing.Point(305, 59)
        Me.txtChequesTransferir.MaxLength = 20
        Me.txtChequesTransferir.Name = "txtChequesTransferir"
        Me.txtChequesTransferir.ReadOnly = True
        Me.txtChequesTransferir.Size = New System.Drawing.Size(90, 20)
        Me.txtChequesTransferir.TabIndex = 27
        Me.txtChequesTransferir.Text = "0.00"
        Me.txtChequesTransferir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTarjetasTransferir
        '
        Me.txtTarjetasTransferir.BindearPropiedadControl = ""
        Me.txtTarjetasTransferir.BindearPropiedadEntidad = ""
        Me.txtTarjetasTransferir.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTarjetasTransferir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTarjetasTransferir.Formato = "N2"
        Me.txtTarjetasTransferir.IsDecimal = True
        Me.txtTarjetasTransferir.IsNumber = True
        Me.txtTarjetasTransferir.IsPK = False
        Me.txtTarjetasTransferir.IsRequired = False
        Me.txtTarjetasTransferir.Key = ""
        Me.txtTarjetasTransferir.LabelAsoc = Nothing
        Me.txtTarjetasTransferir.Location = New System.Drawing.Point(305, 85)
        Me.txtTarjetasTransferir.MaxLength = 20
        Me.txtTarjetasTransferir.Name = "txtTarjetasTransferir"
        Me.txtTarjetasTransferir.ReadOnly = True
        Me.txtTarjetasTransferir.Size = New System.Drawing.Size(90, 20)
        Me.txtTarjetasTransferir.TabIndex = 28
        Me.txtTarjetasTransferir.Text = "0.00"
        Me.txtTarjetasTransferir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTicketsTransferir
        '
        Me.txtTicketsTransferir.BindearPropiedadControl = ""
        Me.txtTicketsTransferir.BindearPropiedadEntidad = ""
        Me.txtTicketsTransferir.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTicketsTransferir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTicketsTransferir.Formato = "N2"
        Me.txtTicketsTransferir.IsDecimal = True
        Me.txtTicketsTransferir.IsNumber = True
        Me.txtTicketsTransferir.IsPK = False
        Me.txtTicketsTransferir.IsRequired = False
        Me.txtTicketsTransferir.Key = ""
        Me.txtTicketsTransferir.LabelAsoc = Nothing
        Me.txtTicketsTransferir.Location = New System.Drawing.Point(305, 111)
        Me.txtTicketsTransferir.MaxLength = 20
        Me.txtTicketsTransferir.Name = "txtTicketsTransferir"
        Me.txtTicketsTransferir.ReadOnly = True
        Me.txtTicketsTransferir.Size = New System.Drawing.Size(90, 20)
        Me.txtTicketsTransferir.TabIndex = 29
        Me.txtTicketsTransferir.Text = "0.00"
        Me.txtTicketsTransferir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBancosTransferir
        '
        Me.txtBancosTransferir.BindearPropiedadControl = ""
        Me.txtBancosTransferir.BindearPropiedadEntidad = ""
        Me.txtBancosTransferir.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancosTransferir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancosTransferir.Formato = "N2"
        Me.txtBancosTransferir.IsDecimal = True
        Me.txtBancosTransferir.IsNumber = True
        Me.txtBancosTransferir.IsPK = False
        Me.txtBancosTransferir.IsRequired = False
        Me.txtBancosTransferir.Key = ""
        Me.txtBancosTransferir.LabelAsoc = Nothing
        Me.txtBancosTransferir.Location = New System.Drawing.Point(305, 137)
        Me.txtBancosTransferir.MaxLength = 20
        Me.txtBancosTransferir.Name = "txtBancosTransferir"
        Me.txtBancosTransferir.ReadOnly = True
        Me.txtBancosTransferir.Size = New System.Drawing.Size(90, 20)
        Me.txtBancosTransferir.TabIndex = 30
        Me.txtBancosTransferir.Text = "0.00"
        Me.txtBancosTransferir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolaresTransferir
        '
        Me.txtDolaresTransferir.BindearPropiedadControl = ""
        Me.txtDolaresTransferir.BindearPropiedadEntidad = ""
        Me.txtDolaresTransferir.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDolaresTransferir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDolaresTransferir.Formato = "N2"
        Me.txtDolaresTransferir.IsDecimal = True
        Me.txtDolaresTransferir.IsNumber = True
        Me.txtDolaresTransferir.IsPK = False
        Me.txtDolaresTransferir.IsRequired = False
        Me.txtDolaresTransferir.Key = ""
        Me.txtDolaresTransferir.LabelAsoc = Nothing
        Me.txtDolaresTransferir.Location = New System.Drawing.Point(305, 163)
        Me.txtDolaresTransferir.MaxLength = 20
        Me.txtDolaresTransferir.Name = "txtDolaresTransferir"
        Me.txtDolaresTransferir.ReadOnly = True
        Me.txtDolaresTransferir.Size = New System.Drawing.Size(90, 20)
        Me.txtDolaresTransferir.TabIndex = 31
        Me.txtDolaresTransferir.Text = "0.00"
        Me.txtDolaresTransferir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBancosDolaresTransferir
        '
        Me.txtBancosDolaresTransferir.BindearPropiedadControl = ""
        Me.txtBancosDolaresTransferir.BindearPropiedadEntidad = ""
        Me.txtBancosDolaresTransferir.ForeColorFocus = System.Drawing.Color.Red
        Me.txtBancosDolaresTransferir.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtBancosDolaresTransferir.Formato = "N2"
        Me.txtBancosDolaresTransferir.IsDecimal = True
        Me.txtBancosDolaresTransferir.IsNumber = True
        Me.txtBancosDolaresTransferir.IsPK = False
        Me.txtBancosDolaresTransferir.IsRequired = False
        Me.txtBancosDolaresTransferir.Key = ""
        Me.txtBancosDolaresTransferir.LabelAsoc = Nothing
        Me.txtBancosDolaresTransferir.Location = New System.Drawing.Point(305, 189)
        Me.txtBancosDolaresTransferir.MaxLength = 20
        Me.txtBancosDolaresTransferir.Name = "txtBancosDolaresTransferir"
        Me.txtBancosDolaresTransferir.ReadOnly = True
        Me.txtBancosDolaresTransferir.Size = New System.Drawing.Size(90, 20)
        Me.txtBancosDolaresTransferir.TabIndex = 32
        Me.txtBancosDolaresTransferir.Text = "0.00"
        Me.txtBancosDolaresTransferir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCotizacionDolares
        '
        Me.lblCotizacionDolares.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCotizacionDolares.AutoSize = True
        Me.lblCotizacionDolares.LabelAsoc = Nothing
        Me.lblCotizacionDolares.Location = New System.Drawing.Point(7, 218)
        Me.lblCotizacionDolares.Name = "lblCotizacionDolares"
        Me.lblCotizacionDolares.Size = New System.Drawing.Size(56, 13)
        Me.lblCotizacionDolares.TabIndex = 10
        Me.lblCotizacionDolares.Text = "Cotización"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblCaja, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblModoPantalla, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbCajas, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbSucursalDestino, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNroPlanillaActual, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSucursalDestino, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtPACFecha, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbCajasDestino, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCajaDestino, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblFechaPlaActual, 3, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(498, 101)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lblCaja
        '
        Me.lblCaja.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCaja.AutoSize = True
        Me.lblCaja.LabelAsoc = Nothing
        Me.lblCaja.Location = New System.Drawing.Point(57, 27)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(28, 13)
        Me.lblCaja.TabIndex = 0
        Me.lblCaja.Text = "Caja"
        '
        'lblModoPantalla
        '
        Me.lblModoPantalla.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblModoPantalla.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.lblModoPantalla, 6)
        Me.lblModoPantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModoPantalla.LabelAsoc = Nothing
        Me.lblModoPantalla.Location = New System.Drawing.Point(442, 2)
        Me.lblModoPantalla.Name = "lblModoPantalla"
        Me.lblModoPantalla.Size = New System.Drawing.Size(53, 16)
        Me.lblModoPantalla.TabIndex = 4
        Me.lblModoPantalla.Text = "MODO"
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
        Me.cmbCajas.Location = New System.Drawing.Point(150, 23)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(145, 21)
        Me.cmbCajas.TabIndex = 1
        '
        'cmbSucursalDestino
        '
        Me.cmbSucursalDestino.BindearPropiedadControl = Nothing
        Me.cmbSucursalDestino.BindearPropiedadEntidad = Nothing
        Me.cmbSucursalDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursalDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursalDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursalDestino.FormattingEnabled = True
        Me.cmbSucursalDestino.IsPK = False
        Me.cmbSucursalDestino.IsRequired = False
        Me.cmbSucursalDestino.Key = Nothing
        Me.cmbSucursalDestino.LabelAsoc = Me.lblSucursalDestino
        Me.cmbSucursalDestino.Location = New System.Drawing.Point(150, 50)
        Me.cmbSucursalDestino.Name = "cmbSucursalDestino"
        Me.cmbSucursalDestino.Size = New System.Drawing.Size(145, 21)
        Me.cmbSucursalDestino.TabIndex = 3
        '
        'lblSucursalDestino
        '
        Me.lblSucursalDestino.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblSucursalDestino.AutoSize = True
        Me.lblSucursalDestino.LabelAsoc = Nothing
        Me.lblSucursalDestino.Location = New System.Drawing.Point(57, 54)
        Me.lblSucursalDestino.Name = "lblSucursalDestino"
        Me.lblSucursalDestino.Size = New System.Drawing.Size(87, 13)
        Me.lblSucursalDestino.TabIndex = 2
        Me.lblSucursalDestino.Text = "Sucursal Destino"
        '
        'txtNroPlanillaActual
        '
        Me.txtNroPlanillaActual.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNroPlanillaActual.BindearPropiedadControl = Nothing
        Me.txtNroPlanillaActual.BindearPropiedadEntidad = Nothing
        Me.txtNroPlanillaActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroPlanillaActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroPlanillaActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroPlanillaActual.IsDecimal = False
        Me.txtNroPlanillaActual.IsNumber = False
        Me.txtNroPlanillaActual.IsPK = False
        Me.txtNroPlanillaActual.IsRequired = False
        Me.txtNroPlanillaActual.Key = ""
        Me.txtNroPlanillaActual.LabelAsoc = Nothing
        Me.txtNroPlanillaActual.Location = New System.Drawing.Point(370, 23)
        Me.txtNroPlanillaActual.Name = "txtNroPlanillaActual"
        Me.txtNroPlanillaActual.ReadOnly = True
        Me.txtNroPlanillaActual.Size = New System.Drawing.Size(70, 20)
        Me.txtNroPlanillaActual.TabIndex = 7
        Me.txtNroPlanillaActual.TabStop = False
        Me.txtNroPlanillaActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label21.AutoSize = True
        Me.Label21.LabelAsoc = Nothing
        Me.Label21.Location = New System.Drawing.Point(301, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Nro. Planilla"
        '
        'txtPACFecha
        '
        Me.txtPACFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPACFecha.BindearPropiedadControl = Nothing
        Me.txtPACFecha.BindearPropiedadEntidad = Nothing
        Me.txtPACFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPACFecha.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPACFecha.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPACFecha.IsDecimal = False
        Me.txtPACFecha.IsNumber = False
        Me.txtPACFecha.IsPK = False
        Me.txtPACFecha.IsRequired = False
        Me.txtPACFecha.Key = ""
        Me.txtPACFecha.LabelAsoc = Me.lblFechaPlaActual
        Me.txtPACFecha.Location = New System.Drawing.Point(370, 50)
        Me.txtPACFecha.Name = "txtPACFecha"
        Me.txtPACFecha.ReadOnly = True
        Me.txtPACFecha.Size = New System.Drawing.Size(70, 20)
        Me.txtPACFecha.TabIndex = 9
        Me.txtPACFecha.TabStop = False
        Me.txtPACFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFechaPlaActual
        '
        Me.lblFechaPlaActual.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFechaPlaActual.AutoSize = True
        Me.lblFechaPlaActual.LabelAsoc = Nothing
        Me.lblFechaPlaActual.Location = New System.Drawing.Point(301, 54)
        Me.lblFechaPlaActual.Name = "lblFechaPlaActual"
        Me.lblFechaPlaActual.Size = New System.Drawing.Size(37, 13)
        Me.lblFechaPlaActual.TabIndex = 8
        Me.lblFechaPlaActual.Text = "Fecha"
        '
        'cmbCajasDestino
        '
        Me.cmbCajasDestino.BindearPropiedadControl = ""
        Me.cmbCajasDestino.BindearPropiedadEntidad = ""
        Me.cmbCajasDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajasDestino.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajasDestino.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajasDestino.FormattingEnabled = True
        Me.cmbCajasDestino.IsPK = False
        Me.cmbCajasDestino.IsRequired = False
        Me.cmbCajasDestino.Key = Nothing
        Me.cmbCajasDestino.LabelAsoc = Me.lblCajaDestino
        Me.cmbCajasDestino.Location = New System.Drawing.Point(150, 77)
        Me.cmbCajasDestino.Name = "cmbCajasDestino"
        Me.cmbCajasDestino.Size = New System.Drawing.Size(145, 21)
        Me.cmbCajasDestino.TabIndex = 5
        '
        'lblCajaDestino
        '
        Me.lblCajaDestino.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCajaDestino.AutoSize = True
        Me.lblCajaDestino.LabelAsoc = Nothing
        Me.lblCajaDestino.Location = New System.Drawing.Point(57, 81)
        Me.lblCajaDestino.Name = "lblCajaDestino"
        Me.lblCajaDestino.Size = New System.Drawing.Size(67, 13)
        Me.lblCajaDestino.TabIndex = 4
        Me.lblCajaDestino.Text = "Caja Destino"
        '
        'CerrarPlanillaDeCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 409)
        Me.Controls.Add(Me.grbPlanillaActual)
        Me.Controls.Add(Me.tstBarra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "CerrarPlanillaDeCaja"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cerrar Planilla de Caja"
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.grbPlanillaActual.ResumeLayout(False)
        Me.grbPlanillaActual.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Friend WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbCerrar As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbPlanillaActual As System.Windows.Forms.GroupBox
   Friend WithEvents txtPACFecha As Eniac.Controles.MaskedTextBox
   Friend WithEvents lblCheques As Eniac.Controles.Label
   Friend WithEvents lblTarjetas As Eniac.Controles.Label
   Friend WithEvents lblTickets As Eniac.Controles.Label
   Friend WithEvents lblDolares As Eniac.Controles.Label
   Friend WithEvents lblPesos As Eniac.Controles.Label
   Friend WithEvents lblFechaPlaActual As Eniac.Controles.Label
   Friend WithEvents tsbFinalizarPlanilla As System.Windows.Forms.ToolStripButton
   Friend WithEvents txtNroPlanillaActual As Eniac.Controles.MaskedTextBox
   Friend WithEvents Label21 As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Controles.ComboBox
   Friend WithEvents lblCaja As Eniac.Controles.Label
   Friend WithEvents lblValores As Eniac.Controles.Label
   Friend WithEvents txtPesos As Eniac.Controles.TextBox
   Friend WithEvents txtDolares As Eniac.Controles.TextBox
   Friend WithEvents txtTickets As Eniac.Controles.TextBox
   Friend WithEvents txtTarjetas As Eniac.Controles.TextBox
   Friend WithEvents txtCheques As Eniac.Controles.TextBox
   Friend WithEvents txtBancos As Eniac.Controles.TextBox
   Friend WithEvents lblBancos As Eniac.Controles.Label
    Friend WithEvents txtBancosDolares As Controles.TextBox
    Friend WithEvents lblBancosDolares As Controles.Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtPesosSaldoCierre As Controles.TextBox
    Friend WithEvents txtTicketsSaldoCierre As Controles.TextBox
    Friend WithEvents txtBancosSaldoCierre As Controles.TextBox
    Friend WithEvents txtDolaresSaldoCierre As Controles.TextBox
    Friend WithEvents txtBancosDolaresSaldoCierre As Controles.TextBox
    Friend WithEvents lblSaldoCierre As Controles.Label
    Friend WithEvents lblSaldoActual As Controles.Label
    Friend WithEvents txtPesosSaldoActual As Controles.TextBox
    Friend WithEvents txtChequesSaldoActual As Controles.TextBox
    Friend WithEvents txtTarjetasSaldoActual As Controles.TextBox
    Friend WithEvents txtTicketsSaldoActual As Controles.TextBox
    Friend WithEvents txtBancosSaldoActual As Controles.TextBox
    Friend WithEvents txtDolaresSaldoActual As Controles.TextBox
    Friend WithEvents txtBancosDolaresSaldoActual As Controles.TextBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblCajaDestino As Controles.Label
    Friend WithEvents cmbSucursalDestino As Controles.ComboBox
    Friend WithEvents lblSucursalDestino As Controles.Label
    Friend WithEvents cmbCajasDestino As Controles.ComboBox
    Friend WithEvents chbEntregaCheques As Controles.CheckBox
    Friend WithEvents chbEntregaCupones As Controles.CheckBox
    Friend WithEvents txtPesosTransferir As Controles.TextBox
    Friend WithEvents lblSaldoFinal As Controles.Label
    Friend WithEvents txtChequesTransferir As Controles.TextBox
    Friend WithEvents txtTarjetasTransferir As Controles.TextBox
    Friend WithEvents txtTicketsTransferir As Controles.TextBox
    Friend WithEvents txtBancosTransferir As Controles.TextBox
    Friend WithEvents txtDolaresTransferir As Controles.TextBox
    Friend WithEvents txtBancosDolaresTransferir As Controles.TextBox
    Friend WithEvents txtCotizacionDolaresSaldoCierre As Controles.TextBox
    Friend WithEvents lblCotizacionDolares As Controles.Label
    Friend WithEvents lblModoPantalla As Controles.Label
End Class
