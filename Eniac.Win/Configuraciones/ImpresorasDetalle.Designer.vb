<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresorasDetalle
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
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Selec")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tipo")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Descripcion")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsFiscal")
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Grupo")
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoComprobante")
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpresorasDetalle))
      Me.grbDatos = New System.Windows.Forms.GroupBox()
      Me.chbPorCtaOrden = New Eniac.Controles.CheckBox()
      Me.txtCentroEmisor = New Eniac.Controles.TextBox()
      Me.lblCentroEmisor = New Eniac.Controles.Label()
        Me.cmbTipoImpresora = New Eniac.Controles.ComboBox()
        Me.lblTipo = New Eniac.Controles.Label()
        Me.txtId = New Eniac.Controles.TextBox()
        Me.lblId = New Eniac.Controles.Label()
        Me.grbPCs = New System.Windows.Forms.GroupBox()
        Me.clbPCs = New System.Windows.Forms.ListBox()
        Me.btnEliminarPC = New Eniac.Controles.Button()
        Me.btnAgregarPC = New Eniac.Controles.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarPCActualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtPCs = New Eniac.Controles.TextBox()
        Me.lblModelo = New Eniac.Controles.Label()
        Me.grbComprobantes = New System.Windows.Forms.GroupBox()
        Me.ugComprobantes = New Eniac.Win.UltraGridEditable()
        Me.grbFiscal = New System.Windows.Forms.GroupBox()
        Me.txtMaximoCaracteresItem = New Eniac.Controles.TextBox()
        Me.lblMaximoCaracteresItem = New Eniac.Controles.Label()
        Me.chbImprimirLineaALinea = New Eniac.Controles.CheckBox()
        Me.chbCierreFiscalEstandar = New Eniac.Controles.CheckBox()
        Me.chbGrabarLOGs = New Eniac.Controles.CheckBox()
        Me.chbAbrirCajonDinero = New Eniac.Controles.CheckBox()
        Me.cboMetodo = New Eniac.Controles.ComboBox()
        Me.lblMetodo = New Eniac.Controles.Label()
        Me.cboMarca = New Eniac.Controles.ComboBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.lblTamanioLetra = New Eniac.Controles.Label()
        Me.txtTamanioLetra = New Eniac.Controles.TextBox()
        Me.txtTipoFormulario = New Eniac.Controles.TextBox()
        Me.lblTipoFormulario = New Eniac.Controles.Label()
        Me.lblCantidadCopias = New Eniac.Controles.Label()
        Me.txtCantidadCopias = New Eniac.Controles.TextBox()
        Me.txtOrigenPapel = New Eniac.Controles.TextBox()
        Me.lblOrigenPapel = New Eniac.Controles.Label()
        Me.txtModelo = New Eniac.Controles.TextBox()
        Me.chbProtocoloExtendido = New Eniac.Controles.CheckBox()
        Me.txtVelocidad = New Eniac.Controles.TextBox()
        Me.lblVelocidad = New Eniac.Controles.Label()
        Me.lblPuerto = New Eniac.Controles.Label()
        Me.txtPuerto = New Eniac.Controles.TextBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.txtDireccionCentroEmisor = New Eniac.Controles.TextBox()
        Me.Label3 = New Eniac.Controles.Label()
        Me.tltInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.tbcImpresora = New System.Windows.Forms.TabControl()
        Me.tbpGeneral = New System.Windows.Forms.TabPage()
        Me.tbpDireccion = New System.Windows.Forms.TabPage()
        Me.cmbLocalidadCentroEmisor = New Eniac.Controles.ComboBox()
        Me.tbpFiscal = New System.Windows.Forms.TabPage()
        Me.lblFiscalUltimaFechaExtraidaInforme = New Eniac.Controles.Label()
        Me.txtFiscalUltimaFechaExtraidaInforme = New Eniac.Controles.TextBox()
        Me.lblFiscalUltimoZetaExtraidoAuditoria = New Eniac.Controles.Label()
        Me.txtFiscalUltimoZetaExtraidoAuditoria = New Eniac.Controles.TextBox()
        Me.lblFiscalUltimaFechaExtraidaAuditoria = New Eniac.Controles.Label()
        Me.txtFiscalUltimaFechaExtraidaAuditoria = New Eniac.Controles.TextBox()
        Me.chbUtilizaBonosFiscalesElectronicos = New Eniac.Controles.CheckBox()
        Me.grbDatos.SuspendLayout()
        Me.grbPCs.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grbComprobantes.SuspendLayout()
        CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiscal.SuspendLayout()
        Me.tbcImpresora.SuspendLayout()
        Me.tbpGeneral.SuspendLayout()
        Me.tbpDireccion.SuspendLayout()
        Me.tbpFiscal.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(602, 455)
        Me.btnAceptar.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(688, 455)
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(501, 455)
        Me.btnCopiar.TabIndex = 4
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(438, 455)
        Me.btnAplicar.TabIndex = 3
        '
        'grbDatos
        '
        Me.grbDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbDatos.Controls.Add(Me.chbUtilizaBonosFiscalesElectronicos)
        Me.grbDatos.Controls.Add(Me.chbPorCtaOrden)
        Me.grbDatos.Controls.Add(Me.txtCentroEmisor)
        Me.grbDatos.Controls.Add(Me.lblCentroEmisor)
        Me.grbDatos.Controls.Add(Me.cmbTipoImpresora)
        Me.grbDatos.Controls.Add(Me.lblTipo)
        Me.grbDatos.Controls.Add(Me.txtId)
        Me.grbDatos.Controls.Add(Me.lblId)
        Me.grbDatos.Location = New System.Drawing.Point(6, 6)
        Me.grbDatos.Name = "grbDatos"
        Me.grbDatos.Size = New System.Drawing.Size(752, 56)
        Me.grbDatos.TabIndex = 0
        Me.grbDatos.TabStop = False
        Me.grbDatos.Text = "Datos"
        '
        'chbPorCtaOrden
        '
        Me.chbPorCtaOrden.AutoSize = True
        Me.chbPorCtaOrden.BindearPropiedadControl = "Checked"
        Me.chbPorCtaOrden.BindearPropiedadEntidad = "PorCtaOrden"
        Me.chbPorCtaOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPorCtaOrden.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPorCtaOrden.IsPK = False
        Me.chbPorCtaOrden.IsRequired = False
        Me.chbPorCtaOrden.Key = Nothing
        Me.chbPorCtaOrden.LabelAsoc = Nothing
        Me.chbPorCtaOrden.Location = New System.Drawing.Point(479, 24)
        Me.chbPorCtaOrden.Name = "chbPorCtaOrden"
        Me.chbPorCtaOrden.Size = New System.Drawing.Size(119, 17)
        Me.chbPorCtaOrden.TabIndex = 6
        Me.chbPorCtaOrden.Text = "Por Cuenta y Orden"
        Me.chbPorCtaOrden.UseVisualStyleBackColor = True
        '
        'txtCentroEmisor
        '
        Me.txtCentroEmisor.BindearPropiedadControl = "Text"
        Me.txtCentroEmisor.BindearPropiedadEntidad = "CentroEmisor"
        Me.txtCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCentroEmisor.Formato = ""
        Me.txtCentroEmisor.IsDecimal = False
        Me.txtCentroEmisor.IsNumber = True
        Me.txtCentroEmisor.IsPK = False
        Me.txtCentroEmisor.IsRequired = True
        Me.txtCentroEmisor.Key = ""
        Me.txtCentroEmisor.LabelAsoc = Me.lblCentroEmisor
        Me.txtCentroEmisor.Location = New System.Drawing.Point(412, 22)
        Me.txtCentroEmisor.MaxLength = 4
        Me.txtCentroEmisor.Name = "txtCentroEmisor"
        Me.txtCentroEmisor.Size = New System.Drawing.Size(44, 20)
        Me.txtCentroEmisor.TabIndex = 5
        Me.txtCentroEmisor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tltInfo.SetToolTip(Me.txtCentroEmisor, "Nro. entre 1 y 9999")
        '
        'lblCentroEmisor
        '
        Me.lblCentroEmisor.AutoSize = True
        Me.lblCentroEmisor.LabelAsoc = Nothing
        Me.lblCentroEmisor.Location = New System.Drawing.Point(338, 26)
        Me.lblCentroEmisor.Name = "lblCentroEmisor"
        Me.lblCentroEmisor.Size = New System.Drawing.Size(69, 13)
        Me.lblCentroEmisor.TabIndex = 4
        Me.lblCentroEmisor.Text = "Emisor / P.V."
        '
        'cmbTipoImpresora
        '
        Me.cmbTipoImpresora.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoImpresora.BindearPropiedadEntidad = "TipoImpresora"
        Me.cmbTipoImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoImpresora.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoImpresora.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoImpresora.FormattingEnabled = True
        Me.cmbTipoImpresora.IsPK = False
        Me.cmbTipoImpresora.IsRequired = True
        Me.cmbTipoImpresora.Key = Nothing
        Me.cmbTipoImpresora.LabelAsoc = Me.lblTipo
        Me.cmbTipoImpresora.Location = New System.Drawing.Point(212, 22)
        Me.cmbTipoImpresora.Name = "cmbTipoImpresora"
        Me.cmbTipoImpresora.Size = New System.Drawing.Size(100, 21)
        Me.cmbTipoImpresora.TabIndex = 3
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.LabelAsoc = Nothing
        Me.lblTipo.Location = New System.Drawing.Point(178, 26)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(28, 13)
        Me.lblTipo.TabIndex = 2
        Me.lblTipo.Text = "Tipo"
        '
        'txtId
        '
        Me.txtId.BindearPropiedadControl = "Text"
        Me.txtId.BindearPropiedadEntidad = "IdImpresora"
        Me.txtId.ForeColorFocus = System.Drawing.Color.Red
        Me.txtId.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtId.Formato = ""
        Me.txtId.IsDecimal = False
        Me.txtId.IsNumber = False
        Me.txtId.IsPK = True
        Me.txtId.IsRequired = True
        Me.txtId.Key = ""
        Me.txtId.LabelAsoc = Me.lblId
        Me.txtId.Location = New System.Drawing.Point(38, 22)
        Me.txtId.MaxLength = 15
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(124, 20)
        Me.txtId.TabIndex = 1
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.LabelAsoc = Nothing
        Me.lblId.Location = New System.Drawing.Point(16, 26)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(16, 13)
        Me.lblId.TabIndex = 0
        Me.lblId.Text = "Id"
        '
        'grbPCs
        '
        Me.grbPCs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbPCs.Controls.Add(Me.clbPCs)
        Me.grbPCs.Controls.Add(Me.btnEliminarPC)
        Me.grbPCs.Controls.Add(Me.btnAgregarPC)
        Me.grbPCs.Controls.Add(Me.txtPCs)
        Me.grbPCs.Location = New System.Drawing.Point(570, 72)
        Me.grbPCs.Name = "grbPCs"
        Me.grbPCs.Size = New System.Drawing.Size(188, 338)
        Me.grbPCs.TabIndex = 2
        Me.grbPCs.TabStop = False
        Me.grbPCs.Text = "PCs habilitadas"
        '
        'clbPCs
        '
        Me.clbPCs.FormattingEnabled = True
        Me.clbPCs.Location = New System.Drawing.Point(13, 49)
        Me.clbPCs.Name = "clbPCs"
        Me.clbPCs.Size = New System.Drawing.Size(166, 264)
        Me.clbPCs.TabIndex = 3
        '
        'btnEliminarPC
        '
        Me.btnEliminarPC.Image = Global.Eniac.Win.My.Resources.Resources.delete_16
        Me.btnEliminarPC.Location = New System.Drawing.Point(156, 19)
        Me.btnEliminarPC.Name = "btnEliminarPC"
        Me.btnEliminarPC.Size = New System.Drawing.Size(23, 23)
        Me.btnEliminarPC.TabIndex = 2
        Me.btnEliminarPC.UseVisualStyleBackColor = True
        '
        'btnAgregarPC
        '
        Me.btnAgregarPC.ContextMenuStrip = Me.ContextMenuStrip1
        Me.btnAgregarPC.Image = Global.Eniac.Win.My.Resources.Resources.add_16
        Me.btnAgregarPC.Location = New System.Drawing.Point(133, 19)
        Me.btnAgregarPC.Name = "btnAgregarPC"
        Me.btnAgregarPC.Size = New System.Drawing.Size(23, 23)
        Me.btnAgregarPC.TabIndex = 1
        Me.btnAgregarPC.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarPCActualToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(172, 26)
        '
        'AgregarPCActualToolStripMenuItem
        '
        Me.AgregarPCActualToolStripMenuItem.Name = "AgregarPCActualToolStripMenuItem"
        Me.AgregarPCActualToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.AgregarPCActualToolStripMenuItem.Text = "Agregar PC Actual"
        '
        'txtPCs
        '
        Me.txtPCs.BindearPropiedadControl = ""
        Me.txtPCs.BindearPropiedadEntidad = ""
        Me.txtPCs.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPCs.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPCs.Formato = ""
        Me.txtPCs.IsDecimal = False
        Me.txtPCs.IsNumber = False
        Me.txtPCs.IsPK = False
        Me.txtPCs.IsRequired = False
        Me.txtPCs.Key = ""
        Me.txtPCs.LabelAsoc = Me.lblModelo
        Me.txtPCs.Location = New System.Drawing.Point(13, 23)
        Me.txtPCs.MaxLength = 15
        Me.txtPCs.Name = "txtPCs"
        Me.txtPCs.Size = New System.Drawing.Size(116, 20)
        Me.txtPCs.TabIndex = 0
        '
        'lblModelo
        '
        Me.lblModelo.AutoSize = True
        Me.lblModelo.LabelAsoc = Nothing
        Me.lblModelo.Location = New System.Drawing.Point(163, 77)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(42, 13)
        Me.lblModelo.TabIndex = 16
        Me.lblModelo.Text = "Modelo"
        '
        'grbComprobantes
        '
        Me.grbComprobantes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbComprobantes.Controls.Add(Me.ugComprobantes)
        Me.grbComprobantes.Location = New System.Drawing.Point(6, 72)
        Me.grbComprobantes.Name = "grbComprobantes"
        Me.grbComprobantes.Size = New System.Drawing.Size(558, 338)
        Me.grbComprobantes.TabIndex = 1
        Me.grbComprobantes.TabStop = False
        Me.grbComprobantes.Text = "Comprobantes habilitados"
        '
        'ugComprobantes
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugComprobantes.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn8.CellAppearance = Appearance2
        UltraGridColumn8.Header.Caption = ""
        UltraGridColumn8.Header.VisiblePosition = 0
        UltraGridColumn8.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn8.Width = 30
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.VisiblePosition = 1
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.Caption = "Código"
        UltraGridColumn10.Header.VisiblePosition = 2
        UltraGridColumn10.Width = 100
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.Caption = "Descripción"
        UltraGridColumn11.Header.VisiblePosition = 3
        UltraGridColumn11.Width = 150
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.Caption = "Es Fiscal"
        UltraGridColumn12.Header.VisiblePosition = 4
        UltraGridColumn12.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn12.Width = 42
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn13.Header.VisiblePosition = 5
        UltraGridColumn13.Width = 92
        UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn14.Header.VisiblePosition = 6
        UltraGridColumn14.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14})
        Me.ugComprobantes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugComprobantes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugComprobantes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance3.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.GroupByBox.Appearance = Appearance3
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance4
        Me.ugComprobantes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BackColor2 = System.Drawing.SystemColors.Control
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugComprobantes.DisplayLayout.GroupByBox.PromptAppearance = Appearance5
        Me.ugComprobantes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugComprobantes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance6.BackColor = System.Drawing.SystemColors.Window
        Appearance6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugComprobantes.DisplayLayout.Override.ActiveCellAppearance = Appearance6
        Appearance7.BackColor = System.Drawing.SystemColors.Highlight
        Appearance7.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugComprobantes.DisplayLayout.Override.ActiveRowAppearance = Appearance7
        Me.ugComprobantes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugComprobantes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.Override.CardAreaAppearance = Appearance8
        Appearance9.BorderColor = System.Drawing.Color.Silver
        Appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugComprobantes.DisplayLayout.Override.CellAppearance = Appearance9
        Me.ugComprobantes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugComprobantes.DisplayLayout.Override.CellPadding = 0
        Appearance10.BackColor = System.Drawing.SystemColors.Control
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.ugComprobantes.DisplayLayout.Override.GroupByRowAppearance = Appearance10
        Appearance11.TextHAlignAsString = "Left"
        Me.ugComprobantes.DisplayLayout.Override.HeaderAppearance = Appearance11
        Me.ugComprobantes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugComprobantes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance12.BackColor = System.Drawing.SystemColors.Window
        Appearance12.BorderColor = System.Drawing.Color.Silver
        Me.ugComprobantes.DisplayLayout.Override.RowAppearance = Appearance12
        Appearance13.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugComprobantes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance13
        Me.ugComprobantes.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugComprobantes.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.Vertical
        Me.ugComprobantes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugComprobantes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugComprobantes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugComprobantes.Location = New System.Drawing.Point(3, 16)
        Me.ugComprobantes.Name = "ugComprobantes"
        Me.ugComprobantes.Size = New System.Drawing.Size(552, 319)
        Me.ugComprobantes.TabIndex = 0
        Me.ugComprobantes.Text = "UltraGrid1"
        '
        'grbFiscal
        '
        Me.grbFiscal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiscal.Controls.Add(Me.txtMaximoCaracteresItem)
        Me.grbFiscal.Controls.Add(Me.lblMaximoCaracteresItem)
        Me.grbFiscal.Controls.Add(Me.chbImprimirLineaALinea)
        Me.grbFiscal.Controls.Add(Me.chbCierreFiscalEstandar)
        Me.grbFiscal.Controls.Add(Me.chbGrabarLOGs)
        Me.grbFiscal.Controls.Add(Me.chbAbrirCajonDinero)
        Me.grbFiscal.Controls.Add(Me.cboMetodo)
        Me.grbFiscal.Controls.Add(Me.lblMetodo)
        Me.grbFiscal.Controls.Add(Me.cboMarca)
        Me.grbFiscal.Controls.Add(Me.Label1)
        Me.grbFiscal.Controls.Add(Me.lblTamanioLetra)
        Me.grbFiscal.Controls.Add(Me.txtTamanioLetra)
        Me.grbFiscal.Controls.Add(Me.txtTipoFormulario)
        Me.grbFiscal.Controls.Add(Me.lblTipoFormulario)
        Me.grbFiscal.Controls.Add(Me.lblCantidadCopias)
        Me.grbFiscal.Controls.Add(Me.txtCantidadCopias)
        Me.grbFiscal.Controls.Add(Me.txtOrigenPapel)
        Me.grbFiscal.Controls.Add(Me.lblOrigenPapel)
        Me.grbFiscal.Controls.Add(Me.txtModelo)
        Me.grbFiscal.Controls.Add(Me.lblModelo)
        Me.grbFiscal.Controls.Add(Me.chbProtocoloExtendido)
        Me.grbFiscal.Controls.Add(Me.txtVelocidad)
        Me.grbFiscal.Controls.Add(Me.lblVelocidad)
        Me.grbFiscal.Controls.Add(Me.lblPuerto)
        Me.grbFiscal.Controls.Add(Me.txtPuerto)
        Me.grbFiscal.Location = New System.Drawing.Point(59, 13)
        Me.grbFiscal.Name = "grbFiscal"
        Me.grbFiscal.Size = New System.Drawing.Size(635, 180)
        Me.grbFiscal.TabIndex = 0
        Me.grbFiscal.TabStop = False
        Me.grbFiscal.Text = "Datos Fiscales"
        '
        'txtMaximoCaracteresItem
        '
        Me.txtMaximoCaracteresItem.BindearPropiedadControl = "Text"
        Me.txtMaximoCaracteresItem.BindearPropiedadEntidad = "MaximoCaracteresItem"
        Me.txtMaximoCaracteresItem.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMaximoCaracteresItem.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMaximoCaracteresItem.Formato = ""
        Me.txtMaximoCaracteresItem.IsDecimal = False
        Me.txtMaximoCaracteresItem.IsNumber = True
        Me.txtMaximoCaracteresItem.IsPK = False
        Me.txtMaximoCaracteresItem.IsRequired = False
        Me.txtMaximoCaracteresItem.Key = ""
        Me.txtMaximoCaracteresItem.LabelAsoc = Me.lblMaximoCaracteresItem
        Me.txtMaximoCaracteresItem.Location = New System.Drawing.Point(392, 47)
        Me.txtMaximoCaracteresItem.MaxLength = 4
        Me.txtMaximoCaracteresItem.Name = "txtMaximoCaracteresItem"
        Me.txtMaximoCaracteresItem.Size = New System.Drawing.Size(33, 20)
        Me.txtMaximoCaracteresItem.TabIndex = 13
        Me.txtMaximoCaracteresItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMaximoCaracteresItem
        '
        Me.lblMaximoCaracteresItem.AutoSize = True
        Me.lblMaximoCaracteresItem.LabelAsoc = Nothing
        Me.lblMaximoCaracteresItem.Location = New System.Drawing.Point(233, 51)
        Me.lblMaximoCaracteresItem.Name = "lblMaximoCaracteresItem"
        Me.lblMaximoCaracteresItem.Size = New System.Drawing.Size(120, 13)
        Me.lblMaximoCaracteresItem.TabIndex = 12
        Me.lblMaximoCaracteresItem.Text = "Máximo Caracteres Item"
        Me.tltInfo.SetToolTip(Me.lblMaximoCaracteresItem, "F: Hoja Suelta / C: Continuo")
        '
        'chbImprimirLineaALinea
        '
        Me.chbImprimirLineaALinea.AutoSize = True
        Me.chbImprimirLineaALinea.BindearPropiedadControl = "Checked"
        Me.chbImprimirLineaALinea.BindearPropiedadEntidad = "ImprimirLineaALinea"
        Me.chbImprimirLineaALinea.ForeColorFocus = System.Drawing.Color.Red
        Me.chbImprimirLineaALinea.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbImprimirLineaALinea.IsPK = False
        Me.chbImprimirLineaALinea.IsRequired = False
        Me.chbImprimirLineaALinea.Key = Nothing
        Me.chbImprimirLineaALinea.LabelAsoc = Nothing
        Me.chbImprimirLineaALinea.Location = New System.Drawing.Point(326, 151)
        Me.chbImprimirLineaALinea.Name = "chbImprimirLineaALinea"
        Me.chbImprimirLineaALinea.Size = New System.Drawing.Size(129, 17)
        Me.chbImprimirLineaALinea.TabIndex = 24
        Me.chbImprimirLineaALinea.Text = "Imprimir Linea A Linea"
        Me.chbImprimirLineaALinea.UseVisualStyleBackColor = True
        '
        'chbCierreFiscalEstandar
        '
        Me.chbCierreFiscalEstandar.AutoSize = True
        Me.chbCierreFiscalEstandar.BindearPropiedadControl = "Checked"
        Me.chbCierreFiscalEstandar.BindearPropiedadEntidad = "CierreFiscalEstandar"
        Me.chbCierreFiscalEstandar.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCierreFiscalEstandar.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCierreFiscalEstandar.IsPK = False
        Me.chbCierreFiscalEstandar.IsRequired = False
        Me.chbCierreFiscalEstandar.Key = Nothing
        Me.chbCierreFiscalEstandar.LabelAsoc = Nothing
        Me.chbCierreFiscalEstandar.Location = New System.Drawing.Point(327, 128)
        Me.chbCierreFiscalEstandar.Name = "chbCierreFiscalEstandar"
        Me.chbCierreFiscalEstandar.Size = New System.Drawing.Size(128, 17)
        Me.chbCierreFiscalEstandar.TabIndex = 23
        Me.chbCierreFiscalEstandar.Text = "Cierre Fiscal Estandar"
        Me.chbCierreFiscalEstandar.UseVisualStyleBackColor = True
        '
        'chbGrabarLOGs
        '
        Me.chbGrabarLOGs.AutoSize = True
        Me.chbGrabarLOGs.BindearPropiedadControl = "Checked"
        Me.chbGrabarLOGs.BindearPropiedadEntidad = "GrabarLOGs"
        Me.chbGrabarLOGs.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrabarLOGs.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrabarLOGs.IsPK = False
        Me.chbGrabarLOGs.IsRequired = False
        Me.chbGrabarLOGs.Key = Nothing
        Me.chbGrabarLOGs.LabelAsoc = Nothing
        Me.chbGrabarLOGs.Location = New System.Drawing.Point(145, 151)
        Me.chbGrabarLOGs.Name = "chbGrabarLOGs"
        Me.chbGrabarLOGs.Size = New System.Drawing.Size(88, 17)
        Me.chbGrabarLOGs.TabIndex = 22
        Me.chbGrabarLOGs.Text = "Grabar LOGs"
        Me.chbGrabarLOGs.UseVisualStyleBackColor = True
        '
        'chbAbrirCajonDinero
        '
        Me.chbAbrirCajonDinero.AutoSize = True
        Me.chbAbrirCajonDinero.BindearPropiedadControl = "Checked"
        Me.chbAbrirCajonDinero.BindearPropiedadEntidad = "AbrirCajonDinero"
        Me.chbAbrirCajonDinero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbAbrirCajonDinero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbAbrirCajonDinero.IsPK = False
        Me.chbAbrirCajonDinero.IsRequired = False
        Me.chbAbrirCajonDinero.Key = Nothing
        Me.chbAbrirCajonDinero.LabelAsoc = Nothing
        Me.chbAbrirCajonDinero.Location = New System.Drawing.Point(145, 128)
        Me.chbAbrirCajonDinero.Name = "chbAbrirCajonDinero"
        Me.chbAbrirCajonDinero.Size = New System.Drawing.Size(128, 17)
        Me.chbAbrirCajonDinero.TabIndex = 21
        Me.chbAbrirCajonDinero.Text = "Abrir Cajon del Dinero"
        Me.chbAbrirCajonDinero.UseVisualStyleBackColor = True
        '
        'cboMetodo
        '
        Me.cboMetodo.BindearPropiedadControl = "SelectedValue"
        Me.cboMetodo.BindearPropiedadEntidad = "Metodo"
        Me.cboMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMetodo.ForeColorFocus = System.Drawing.Color.Red
        Me.cboMetodo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboMetodo.FormattingEnabled = True
        Me.cboMetodo.IsPK = False
        Me.cboMetodo.IsRequired = False
        Me.cboMetodo.Key = Nothing
        Me.cboMetodo.LabelAsoc = Me.lblTipo
        Me.cboMetodo.Location = New System.Drawing.Point(529, 73)
        Me.cboMetodo.Name = "cboMetodo"
        Me.cboMetodo.Size = New System.Drawing.Size(84, 21)
        Me.cboMetodo.TabIndex = 20
        '
        'lblMetodo
        '
        Me.lblMetodo.AutoSize = True
        Me.lblMetodo.LabelAsoc = Nothing
        Me.lblMetodo.Location = New System.Drawing.Point(433, 77)
        Me.lblMetodo.Name = "lblMetodo"
        Me.lblMetodo.Size = New System.Drawing.Size(91, 13)
        Me.lblMetodo.TabIndex = 19
        Me.lblMetodo.Text = "Metodo Impresion"
        '
        'cboMarca
        '
        Me.cboMarca.BindearPropiedadControl = "SelectedValue"
        Me.cboMarca.BindearPropiedadEntidad = "Marca"
        Me.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cboMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboMarca.FormattingEnabled = True
        Me.cboMarca.IsPK = False
        Me.cboMarca.IsRequired = False
        Me.cboMarca.Key = Nothing
        Me.cboMarca.LabelAsoc = Me.lblTipo
        Me.cboMarca.Location = New System.Drawing.Point(54, 73)
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(93, 21)
        Me.cboMarca.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(10, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Marca"
        '
        'lblTamanioLetra
        '
        Me.lblTamanioLetra.AutoSize = True
        Me.lblTamanioLetra.LabelAsoc = Nothing
        Me.lblTamanioLetra.Location = New System.Drawing.Point(7, 51)
        Me.lblTamanioLetra.Name = "lblTamanioLetra"
        Me.lblTamanioLetra.Size = New System.Drawing.Size(44, 13)
        Me.lblTamanioLetra.TabIndex = 8
        Me.lblTamanioLetra.Text = "T. Letra"
        '
        'txtTamanioLetra
        '
        Me.txtTamanioLetra.BindearPropiedadControl = "Text"
        Me.txtTamanioLetra.BindearPropiedadEntidad = "TamanioLetra"
        Me.txtTamanioLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTamanioLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTamanioLetra.Formato = ""
        Me.txtTamanioLetra.IsDecimal = False
        Me.txtTamanioLetra.IsNumber = True
        Me.txtTamanioLetra.IsPK = False
        Me.txtTamanioLetra.IsRequired = False
        Me.txtTamanioLetra.Key = ""
        Me.txtTamanioLetra.LabelAsoc = Me.lblTamanioLetra
        Me.txtTamanioLetra.Location = New System.Drawing.Point(53, 47)
        Me.txtTamanioLetra.MaxLength = 3
        Me.txtTamanioLetra.Name = "txtTamanioLetra"
        Me.txtTamanioLetra.Size = New System.Drawing.Size(33, 20)
        Me.txtTamanioLetra.TabIndex = 9
        Me.txtTamanioLetra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tltInfo.SetToolTip(Me.txtTamanioLetra, "Cantidad de copias a imprimir por la impresora")
        '
        'txtTipoFormulario
        '
        Me.txtTipoFormulario.BindearPropiedadControl = "Text"
        Me.txtTipoFormulario.BindearPropiedadEntidad = "TipoFormulario"
        Me.txtTipoFormulario.ForeColorFocus = System.Drawing.Color.Red
        Me.txtTipoFormulario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtTipoFormulario.Formato = ""
        Me.txtTipoFormulario.IsDecimal = False
        Me.txtTipoFormulario.IsNumber = False
        Me.txtTipoFormulario.IsPK = False
        Me.txtTipoFormulario.IsRequired = False
        Me.txtTipoFormulario.Key = ""
        Me.txtTipoFormulario.LabelAsoc = Me.lblTipoFormulario
        Me.txtTipoFormulario.Location = New System.Drawing.Point(306, 21)
        Me.txtTipoFormulario.MaxLength = 1
        Me.txtTipoFormulario.Name = "txtTipoFormulario"
        Me.txtTipoFormulario.Size = New System.Drawing.Size(33, 20)
        Me.txtTipoFormulario.TabIndex = 5
        Me.txtTipoFormulario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTipoFormulario
        '
        Me.lblTipoFormulario.AutoSize = True
        Me.lblTipoFormulario.LabelAsoc = Nothing
        Me.lblTipoFormulario.Location = New System.Drawing.Point(233, 25)
        Me.lblTipoFormulario.Name = "lblTipoFormulario"
        Me.lblTipoFormulario.Size = New System.Drawing.Size(68, 13)
        Me.lblTipoFormulario.TabIndex = 4
        Me.lblTipoFormulario.Text = "T. Formulario"
        Me.tltInfo.SetToolTip(Me.lblTipoFormulario, "F: prerimpreso / P: Dibuja impre / A: Autoimpreso")
        '
        'lblCantidadCopias
        '
        Me.lblCantidadCopias.AutoSize = True
        Me.lblCantidadCopias.LabelAsoc = Nothing
        Me.lblCantidadCopias.Location = New System.Drawing.Point(349, 25)
        Me.lblCantidadCopias.Name = "lblCantidadCopias"
        Me.lblCantidadCopias.Size = New System.Drawing.Size(39, 13)
        Me.lblCantidadCopias.TabIndex = 6
        Me.lblCantidadCopias.Text = "Copias"
        Me.tltInfo.SetToolTip(Me.lblCantidadCopias, "1 = Carbonico")
        '
        'txtCantidadCopias
        '
        Me.txtCantidadCopias.BindearPropiedadControl = "Text"
        Me.txtCantidadCopias.BindearPropiedadEntidad = "CantidadCopias"
        Me.txtCantidadCopias.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadCopias.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadCopias.Formato = ""
        Me.txtCantidadCopias.IsDecimal = False
        Me.txtCantidadCopias.IsNumber = True
        Me.txtCantidadCopias.IsPK = False
        Me.txtCantidadCopias.IsRequired = False
        Me.txtCantidadCopias.Key = ""
        Me.txtCantidadCopias.LabelAsoc = Me.lblCantidadCopias
        Me.txtCantidadCopias.Location = New System.Drawing.Point(392, 21)
        Me.txtCantidadCopias.MaxLength = 3
        Me.txtCantidadCopias.Name = "txtCantidadCopias"
        Me.txtCantidadCopias.Size = New System.Drawing.Size(33, 20)
        Me.txtCantidadCopias.TabIndex = 7
        Me.txtCantidadCopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tltInfo.SetToolTip(Me.txtCantidadCopias, "Cantidad de copias a imprimir por la impresora")
        '
        'txtOrigenPapel
        '
        Me.txtOrigenPapel.BindearPropiedadControl = "Text"
        Me.txtOrigenPapel.BindearPropiedadEntidad = "OrigenPapel"
        Me.txtOrigenPapel.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOrigenPapel.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOrigenPapel.Formato = ""
        Me.txtOrigenPapel.IsDecimal = False
        Me.txtOrigenPapel.IsNumber = False
        Me.txtOrigenPapel.IsPK = False
        Me.txtOrigenPapel.IsRequired = False
        Me.txtOrigenPapel.Key = ""
        Me.txtOrigenPapel.LabelAsoc = Me.lblOrigenPapel
        Me.txtOrigenPapel.Location = New System.Drawing.Point(166, 47)
        Me.txtOrigenPapel.MaxLength = 1
        Me.txtOrigenPapel.Name = "txtOrigenPapel"
        Me.txtOrigenPapel.Size = New System.Drawing.Size(31, 20)
        Me.txtOrigenPapel.TabIndex = 11
        Me.txtOrigenPapel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblOrigenPapel
        '
        Me.lblOrigenPapel.AutoSize = True
        Me.lblOrigenPapel.LabelAsoc = Nothing
        Me.lblOrigenPapel.Location = New System.Drawing.Point(104, 51)
        Me.lblOrigenPapel.Name = "lblOrigenPapel"
        Me.lblOrigenPapel.Size = New System.Drawing.Size(59, 13)
        Me.lblOrigenPapel.TabIndex = 10
        Me.lblOrigenPapel.Text = "Orig. Papel"
        Me.tltInfo.SetToolTip(Me.lblOrigenPapel, "F: Hoja Suelta / C: Continuo")
        '
        'txtModelo
        '
        Me.txtModelo.BindearPropiedadControl = "Text"
        Me.txtModelo.BindearPropiedadEntidad = "Modelo"
        Me.txtModelo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtModelo.Formato = ""
        Me.txtModelo.IsDecimal = False
        Me.txtModelo.IsNumber = False
        Me.txtModelo.IsPK = False
        Me.txtModelo.IsRequired = False
        Me.txtModelo.Key = ""
        Me.txtModelo.LabelAsoc = Me.lblModelo
        Me.txtModelo.Location = New System.Drawing.Point(207, 73)
        Me.txtModelo.MaxLength = 15
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(96, 20)
        Me.txtModelo.TabIndex = 17
        '
        'chbProtocoloExtendido
        '
        Me.chbProtocoloExtendido.AutoSize = True
        Me.chbProtocoloExtendido.BindearPropiedadControl = "Checked"
        Me.chbProtocoloExtendido.BindearPropiedadEntidad = "EsProtocoloExtendido"
        Me.chbProtocoloExtendido.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProtocoloExtendido.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProtocoloExtendido.IsPK = False
        Me.chbProtocoloExtendido.IsRequired = False
        Me.chbProtocoloExtendido.Key = Nothing
        Me.chbProtocoloExtendido.LabelAsoc = Nothing
        Me.chbProtocoloExtendido.Location = New System.Drawing.Point(325, 75)
        Me.chbProtocoloExtendido.Name = "chbProtocoloExtendido"
        Me.chbProtocoloExtendido.Size = New System.Drawing.Size(92, 17)
        Me.chbProtocoloExtendido.TabIndex = 18
        Me.chbProtocoloExtendido.Text = "Protocolo Ext."
        Me.chbProtocoloExtendido.UseVisualStyleBackColor = True
        '
        'txtVelocidad
        '
        Me.txtVelocidad.BindearPropiedadControl = "Text"
        Me.txtVelocidad.BindearPropiedadEntidad = "Velocidad"
        Me.txtVelocidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtVelocidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtVelocidad.Formato = ""
        Me.txtVelocidad.IsDecimal = False
        Me.txtVelocidad.IsNumber = True
        Me.txtVelocidad.IsPK = False
        Me.txtVelocidad.IsRequired = False
        Me.txtVelocidad.Key = ""
        Me.txtVelocidad.LabelAsoc = Me.lblVelocidad
        Me.txtVelocidad.Location = New System.Drawing.Point(165, 21)
        Me.txtVelocidad.MaxLength = 7
        Me.txtVelocidad.Name = "txtVelocidad"
        Me.txtVelocidad.Size = New System.Drawing.Size(52, 20)
        Me.txtVelocidad.TabIndex = 3
        Me.txtVelocidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tltInfo.SetToolTip(Me.txtVelocidad, "Es la velocidad de la impresora fiscal")
        '
        'lblVelocidad
        '
        Me.lblVelocidad.AutoSize = True
        Me.lblVelocidad.LabelAsoc = Nothing
        Me.lblVelocidad.Location = New System.Drawing.Point(108, 25)
        Me.lblVelocidad.Name = "lblVelocidad"
        Me.lblVelocidad.Size = New System.Drawing.Size(54, 13)
        Me.lblVelocidad.TabIndex = 2
        Me.lblVelocidad.Text = "Velocidad"
        '
        'lblPuerto
        '
        Me.lblPuerto.AutoSize = True
        Me.lblPuerto.LabelAsoc = Nothing
        Me.lblPuerto.Location = New System.Drawing.Point(10, 25)
        Me.lblPuerto.Name = "lblPuerto"
        Me.lblPuerto.Size = New System.Drawing.Size(38, 13)
        Me.lblPuerto.TabIndex = 0
        Me.lblPuerto.Text = "Puerto"
        '
        'txtPuerto
        '
        Me.txtPuerto.BindearPropiedadControl = "Text"
        Me.txtPuerto.BindearPropiedadEntidad = "Puerto"
        Me.txtPuerto.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPuerto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPuerto.Formato = ""
        Me.txtPuerto.IsDecimal = False
        Me.txtPuerto.IsNumber = False
        Me.txtPuerto.IsPK = False
        Me.txtPuerto.IsRequired = False
        Me.txtPuerto.Key = ""
        Me.txtPuerto.LabelAsoc = Me.lblPuerto
        Me.txtPuerto.Location = New System.Drawing.Point(54, 21)
        Me.txtPuerto.MaxLength = 5
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(44, 20)
        Me.txtPuerto.TabIndex = 1
        Me.txtPuerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.tltInfo.SetToolTip(Me.txtPuerto, "Es el puerto COM para las impresoras Fiscales, para las impresoras Normales se le" &
        " pone 0")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(163, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Dirección Centro Emisor"
        '
        'txtDireccionCentroEmisor
        '
        Me.txtDireccionCentroEmisor.BindearPropiedadControl = "Text"
        Me.txtDireccionCentroEmisor.BindearPropiedadEntidad = "DireccionCentroEmisor"
        Me.txtDireccionCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtDireccionCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtDireccionCentroEmisor.Formato = ""
        Me.txtDireccionCentroEmisor.IsDecimal = False
        Me.txtDireccionCentroEmisor.IsNumber = False
        Me.txtDireccionCentroEmisor.IsPK = False
        Me.txtDireccionCentroEmisor.IsRequired = False
        Me.txtDireccionCentroEmisor.Key = ""
        Me.txtDireccionCentroEmisor.LabelAsoc = Me.Label2
        Me.txtDireccionCentroEmisor.Location = New System.Drawing.Point(290, 24)
        Me.txtDireccionCentroEmisor.MaxLength = 50
        Me.txtDireccionCentroEmisor.Name = "txtDireccionCentroEmisor"
        Me.txtDireccionCentroEmisor.Size = New System.Drawing.Size(269, 20)
        Me.txtDireccionCentroEmisor.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(163, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Localidad Centro Emisor"
        '
        'tbcImpresora
        '
        Me.tbcImpresora.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcImpresora.Controls.Add(Me.tbpGeneral)
        Me.tbcImpresora.Controls.Add(Me.tbpDireccion)
        Me.tbcImpresora.Controls.Add(Me.tbpFiscal)
        Me.tbcImpresora.Location = New System.Drawing.Point(3, 7)
        Me.tbcImpresora.Name = "tbcImpresora"
        Me.tbcImpresora.SelectedIndex = 0
        Me.tbcImpresora.Size = New System.Drawing.Size(775, 442)
        Me.tbcImpresora.TabIndex = 0
        '
        'tbpGeneral
        '
        Me.tbpGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.tbpGeneral.Controls.Add(Me.grbPCs)
        Me.tbpGeneral.Controls.Add(Me.grbDatos)
        Me.tbpGeneral.Controls.Add(Me.grbComprobantes)
        Me.tbpGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tbpGeneral.Name = "tbpGeneral"
        Me.tbpGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpGeneral.Size = New System.Drawing.Size(767, 416)
        Me.tbpGeneral.TabIndex = 0
        Me.tbpGeneral.Text = "General"
        '
        'tbpDireccion
        '
        Me.tbpDireccion.BackColor = System.Drawing.SystemColors.Control
        Me.tbpDireccion.Controls.Add(Me.Label2)
        Me.tbpDireccion.Controls.Add(Me.txtDireccionCentroEmisor)
        Me.tbpDireccion.Controls.Add(Me.Label3)
        Me.tbpDireccion.Controls.Add(Me.cmbLocalidadCentroEmisor)
        Me.tbpDireccion.Location = New System.Drawing.Point(4, 22)
        Me.tbpDireccion.Name = "tbpDireccion"
        Me.tbpDireccion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpDireccion.Size = New System.Drawing.Size(767, 416)
        Me.tbpDireccion.TabIndex = 1
        Me.tbpDireccion.Text = "Dirección"
        '
        'cmbLocalidadCentroEmisor
        '
        Me.cmbLocalidadCentroEmisor.BindearPropiedadControl = "SelectedValue"
        Me.cmbLocalidadCentroEmisor.BindearPropiedadEntidad = "LocalidadCentroEmisor.IdLocalidad"
        Me.cmbLocalidadCentroEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocalidadCentroEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLocalidadCentroEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLocalidadCentroEmisor.FormattingEnabled = True
        Me.cmbLocalidadCentroEmisor.IsPK = False
        Me.cmbLocalidadCentroEmisor.IsRequired = False
        Me.cmbLocalidadCentroEmisor.Key = Nothing
        Me.cmbLocalidadCentroEmisor.LabelAsoc = Me.Label3
        Me.cmbLocalidadCentroEmisor.Location = New System.Drawing.Point(290, 50)
        Me.cmbLocalidadCentroEmisor.Name = "cmbLocalidadCentroEmisor"
        Me.cmbLocalidadCentroEmisor.Size = New System.Drawing.Size(185, 21)
        Me.cmbLocalidadCentroEmisor.TabIndex = 3
        '
        'tbpFiscal
        '
        Me.tbpFiscal.BackColor = System.Drawing.SystemColors.Control
        Me.tbpFiscal.Controls.Add(Me.lblFiscalUltimaFechaExtraidaInforme)
        Me.tbpFiscal.Controls.Add(Me.txtFiscalUltimaFechaExtraidaInforme)
        Me.tbpFiscal.Controls.Add(Me.lblFiscalUltimoZetaExtraidoAuditoria)
        Me.tbpFiscal.Controls.Add(Me.txtFiscalUltimoZetaExtraidoAuditoria)
        Me.tbpFiscal.Controls.Add(Me.lblFiscalUltimaFechaExtraidaAuditoria)
        Me.tbpFiscal.Controls.Add(Me.txtFiscalUltimaFechaExtraidaAuditoria)
        Me.tbpFiscal.Controls.Add(Me.grbFiscal)
        Me.tbpFiscal.Location = New System.Drawing.Point(4, 22)
        Me.tbpFiscal.Name = "tbpFiscal"
        Me.tbpFiscal.Size = New System.Drawing.Size(767, 416)
        Me.tbpFiscal.TabIndex = 2
        Me.tbpFiscal.Text = "Fiscal"
        '
        'lblFiscalUltimaFechaExtraidaInforme
        '
        Me.lblFiscalUltimaFechaExtraidaInforme.AutoSize = True
        Me.lblFiscalUltimaFechaExtraidaInforme.LabelAsoc = Nothing
        Me.lblFiscalUltimaFechaExtraidaInforme.Location = New System.Drawing.Point(96, 283)
        Me.lblFiscalUltimaFechaExtraidaInforme.Name = "lblFiscalUltimaFechaExtraidaInforme"
        Me.lblFiscalUltimaFechaExtraidaInforme.Size = New System.Drawing.Size(158, 13)
        Me.lblFiscalUltimaFechaExtraidaInforme.TabIndex = 5
        Me.lblFiscalUltimaFechaExtraidaInforme.Text = "Última fecha extraida de informe"
        '
        'txtFiscalUltimaFechaExtraidaInforme
        '
        Me.txtFiscalUltimaFechaExtraidaInforme.BindearPropiedadControl = "Text"
        Me.txtFiscalUltimaFechaExtraidaInforme.BindearPropiedadEntidad = "FiscalUltimaFechaExtraidaInforme"
        Me.txtFiscalUltimaFechaExtraidaInforme.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFiscalUltimaFechaExtraidaInforme.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFiscalUltimaFechaExtraidaInforme.Formato = ""
        Me.txtFiscalUltimaFechaExtraidaInforme.IsDecimal = False
        Me.txtFiscalUltimaFechaExtraidaInforme.IsNumber = False
        Me.txtFiscalUltimaFechaExtraidaInforme.IsPK = False
        Me.txtFiscalUltimaFechaExtraidaInforme.IsRequired = False
        Me.txtFiscalUltimaFechaExtraidaInforme.Key = ""
        Me.txtFiscalUltimaFechaExtraidaInforme.LabelAsoc = Me.lblFiscalUltimaFechaExtraidaInforme
        Me.txtFiscalUltimaFechaExtraidaInforme.Location = New System.Drawing.Point(266, 280)
        Me.txtFiscalUltimaFechaExtraidaInforme.MaxLength = 15
        Me.txtFiscalUltimaFechaExtraidaInforme.Name = "txtFiscalUltimaFechaExtraidaInforme"
        Me.txtFiscalUltimaFechaExtraidaInforme.ReadOnly = True
        Me.txtFiscalUltimaFechaExtraidaInforme.Size = New System.Drawing.Size(218, 20)
        Me.txtFiscalUltimaFechaExtraidaInforme.TabIndex = 6
        '
        'lblFiscalUltimoZetaExtraidoAuditoria
        '
        Me.lblFiscalUltimoZetaExtraidoAuditoria.AutoSize = True
        Me.lblFiscalUltimoZetaExtraidoAuditoria.LabelAsoc = Nothing
        Me.lblFiscalUltimoZetaExtraidoAuditoria.Location = New System.Drawing.Point(96, 257)
        Me.lblFiscalUltimoZetaExtraidoAuditoria.Name = "lblFiscalUltimoZetaExtraidoAuditoria"
        Me.lblFiscalUltimoZetaExtraidoAuditoria.Size = New System.Drawing.Size(157, 13)
        Me.lblFiscalUltimoZetaExtraidoAuditoria.TabIndex = 3
        Me.lblFiscalUltimoZetaExtraidoAuditoria.Text = "Último zeta extraido de auditoria"
        '
        'txtFiscalUltimoZetaExtraidoAuditoria
        '
        Me.txtFiscalUltimoZetaExtraidoAuditoria.BindearPropiedadControl = "Text"
        Me.txtFiscalUltimoZetaExtraidoAuditoria.BindearPropiedadEntidad = "FiscalUltimoZetaExtraidoAuditoria"
        Me.txtFiscalUltimoZetaExtraidoAuditoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFiscalUltimoZetaExtraidoAuditoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFiscalUltimoZetaExtraidoAuditoria.Formato = ""
        Me.txtFiscalUltimoZetaExtraidoAuditoria.IsDecimal = False
        Me.txtFiscalUltimoZetaExtraidoAuditoria.IsNumber = False
        Me.txtFiscalUltimoZetaExtraidoAuditoria.IsPK = False
        Me.txtFiscalUltimoZetaExtraidoAuditoria.IsRequired = False
        Me.txtFiscalUltimoZetaExtraidoAuditoria.Key = ""
        Me.txtFiscalUltimoZetaExtraidoAuditoria.LabelAsoc = Me.lblFiscalUltimoZetaExtraidoAuditoria
        Me.txtFiscalUltimoZetaExtraidoAuditoria.Location = New System.Drawing.Point(266, 254)
        Me.txtFiscalUltimoZetaExtraidoAuditoria.MaxLength = 15
        Me.txtFiscalUltimoZetaExtraidoAuditoria.Name = "txtFiscalUltimoZetaExtraidoAuditoria"
        Me.txtFiscalUltimoZetaExtraidoAuditoria.ReadOnly = True
        Me.txtFiscalUltimoZetaExtraidoAuditoria.Size = New System.Drawing.Size(218, 20)
        Me.txtFiscalUltimoZetaExtraidoAuditoria.TabIndex = 4
        '
        'lblFiscalUltimaFechaExtraidaAuditoria
        '
        Me.lblFiscalUltimaFechaExtraidaAuditoria.AutoSize = True
        Me.lblFiscalUltimaFechaExtraidaAuditoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFiscalUltimaFechaExtraidaAuditoria.LabelAsoc = Nothing
        Me.lblFiscalUltimaFechaExtraidaAuditoria.Location = New System.Drawing.Point(96, 231)
        Me.lblFiscalUltimaFechaExtraidaAuditoria.Name = "lblFiscalUltimaFechaExtraidaAuditoria"
        Me.lblFiscalUltimaFechaExtraidaAuditoria.Size = New System.Drawing.Size(164, 13)
        Me.lblFiscalUltimaFechaExtraidaAuditoria.TabIndex = 1
        Me.lblFiscalUltimaFechaExtraidaAuditoria.Text = "Última fecha extraida de auditoria"
        '
        'txtFiscalUltimaFechaExtraidaAuditoria
        '
        Me.txtFiscalUltimaFechaExtraidaAuditoria.BindearPropiedadControl = "Text"
        Me.txtFiscalUltimaFechaExtraidaAuditoria.BindearPropiedadEntidad = "FiscalUltimaFechaExtraidaAuditoria"
        Me.txtFiscalUltimaFechaExtraidaAuditoria.ForeColorFocus = System.Drawing.Color.Red
        Me.txtFiscalUltimaFechaExtraidaAuditoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtFiscalUltimaFechaExtraidaAuditoria.Formato = ""
        Me.txtFiscalUltimaFechaExtraidaAuditoria.IsDecimal = False
        Me.txtFiscalUltimaFechaExtraidaAuditoria.IsNumber = False
        Me.txtFiscalUltimaFechaExtraidaAuditoria.IsPK = False
        Me.txtFiscalUltimaFechaExtraidaAuditoria.IsRequired = False
        Me.txtFiscalUltimaFechaExtraidaAuditoria.Key = ""
        Me.txtFiscalUltimaFechaExtraidaAuditoria.LabelAsoc = Me.lblFiscalUltimaFechaExtraidaAuditoria
        Me.txtFiscalUltimaFechaExtraidaAuditoria.Location = New System.Drawing.Point(266, 228)
        Me.txtFiscalUltimaFechaExtraidaAuditoria.MaxLength = 15
        Me.txtFiscalUltimaFechaExtraidaAuditoria.Name = "txtFiscalUltimaFechaExtraidaAuditoria"
        Me.txtFiscalUltimaFechaExtraidaAuditoria.ReadOnly = True
        Me.txtFiscalUltimaFechaExtraidaAuditoria.Size = New System.Drawing.Size(218, 20)
        Me.txtFiscalUltimaFechaExtraidaAuditoria.TabIndex = 2
        '
        'chbUtilizaBonosFiscalesElectronicos
        '
        Me.chbUtilizaBonosFiscalesElectronicos.AutoSize = True
        Me.chbUtilizaBonosFiscalesElectronicos.BindearPropiedadControl = "Checked"
        Me.chbUtilizaBonosFiscalesElectronicos.BindearPropiedadEntidad = "UtilizaBonosFiscalesElectronicos"
        Me.chbUtilizaBonosFiscalesElectronicos.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUtilizaBonosFiscalesElectronicos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUtilizaBonosFiscalesElectronicos.IsPK = False
        Me.chbUtilizaBonosFiscalesElectronicos.IsRequired = False
        Me.chbUtilizaBonosFiscalesElectronicos.Key = Nothing
        Me.chbUtilizaBonosFiscalesElectronicos.LabelAsoc = Nothing
        Me.chbUtilizaBonosFiscalesElectronicos.Location = New System.Drawing.Point(622, 24)
        Me.chbUtilizaBonosFiscalesElectronicos.Name = "chbUtilizaBonosFiscalesElectronicos"
        Me.chbUtilizaBonosFiscalesElectronicos.Size = New System.Drawing.Size(112, 17)
        Me.chbUtilizaBonosFiscalesElectronicos.TabIndex = 7
        Me.chbUtilizaBonosFiscalesElectronicos.Text = "Utiliza Bono Fiscal"
        Me.chbUtilizaBonosFiscalesElectronicos.UseVisualStyleBackColor = True
        '
        'ImpresorasDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 490)
        Me.Controls.Add(Me.tbcImpresora)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImpresorasDetalle"
        Me.Text = "Impresora"
        Me.Controls.SetChildIndex(Me.tbcImpresora, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.grbDatos.ResumeLayout(False)
        Me.grbDatos.PerformLayout()
        Me.grbPCs.ResumeLayout(False)
        Me.grbPCs.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grbComprobantes.ResumeLayout(False)
        CType(Me.ugComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiscal.ResumeLayout(False)
        Me.grbFiscal.PerformLayout()
        Me.tbcImpresora.ResumeLayout(False)
        Me.tbpGeneral.ResumeLayout(False)
        Me.tbpDireccion.ResumeLayout(False)
        Me.tbpDireccion.PerformLayout()
        Me.tbpFiscal.ResumeLayout(False)
        Me.tbpFiscal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbDatos As System.Windows.Forms.GroupBox
   Friend WithEvents txtId As Eniac.Controles.TextBox
   Friend WithEvents lblId As Eniac.Controles.Label
   Friend WithEvents cmbTipoImpresora As Eniac.Controles.ComboBox
   Friend WithEvents lblTipo As Eniac.Controles.Label
   Friend WithEvents txtCentroEmisor As Eniac.Controles.TextBox
   Friend WithEvents lblCentroEmisor As Eniac.Controles.Label
   Friend WithEvents txtPuerto As Eniac.Controles.TextBox
   Friend WithEvents lblPuerto As Eniac.Controles.Label
   Friend WithEvents tltInfo As System.Windows.Forms.ToolTip
   Friend WithEvents txtVelocidad As Eniac.Controles.TextBox
   Friend WithEvents lblVelocidad As Eniac.Controles.Label
   Friend WithEvents grbFiscal As System.Windows.Forms.GroupBox
   Friend WithEvents grbComprobantes As System.Windows.Forms.GroupBox
   Friend WithEvents chbProtocoloExtendido As Eniac.Controles.CheckBox
   Friend WithEvents txtModelo As Eniac.Controles.TextBox
   Friend WithEvents lblModelo As Eniac.Controles.Label
   Friend WithEvents lblCantidadCopias As Eniac.Controles.Label
   Friend WithEvents txtCantidadCopias As Eniac.Controles.TextBox
   Friend WithEvents txtOrigenPapel As Eniac.Controles.TextBox
   Friend WithEvents lblOrigenPapel As Eniac.Controles.Label
   Friend WithEvents grbPCs As System.Windows.Forms.GroupBox
   Friend WithEvents btnAgregarPC As Eniac.Controles.Button
   Friend WithEvents txtPCs As Eniac.Controles.TextBox
   Friend WithEvents btnEliminarPC As Eniac.Controles.Button
   Friend WithEvents clbPCs As System.Windows.Forms.ListBox
   Friend WithEvents txtTipoFormulario As Eniac.Controles.TextBox
   Friend WithEvents lblTipoFormulario As Eniac.Controles.Label
   Friend WithEvents lblTamanioLetra As Eniac.Controles.Label
   Friend WithEvents txtTamanioLetra As Eniac.Controles.TextBox
   Friend WithEvents cboMarca As Eniac.Controles.ComboBox
   Friend WithEvents Label1 As Eniac.Controles.Label
   Friend WithEvents cboMetodo As Eniac.Controles.ComboBox
   Friend WithEvents lblMetodo As Eniac.Controles.Label
   Friend WithEvents chbGrabarLOGs As Eniac.Controles.CheckBox
   Friend WithEvents chbAbrirCajonDinero As Eniac.Controles.CheckBox
   Friend WithEvents chbCierreFiscalEstandar As Eniac.Controles.CheckBox
   Friend WithEvents chbImprimirLineaALinea As Eniac.Controles.CheckBox
   Friend WithEvents chbPorCtaOrden As Eniac.Controles.CheckBox
   Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents AgregarPCActualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents Label2 As Eniac.Controles.Label
   Friend WithEvents txtDireccionCentroEmisor As Eniac.Controles.TextBox
   Friend WithEvents Label3 As Eniac.Controles.Label
   Friend WithEvents cmbLocalidadCentroEmisor As Eniac.Controles.ComboBox
   Friend WithEvents tbcImpresora As System.Windows.Forms.TabControl
   Friend WithEvents tbpGeneral As System.Windows.Forms.TabPage
   Friend WithEvents tbpDireccion As System.Windows.Forms.TabPage
   Friend WithEvents tbpFiscal As System.Windows.Forms.TabPage
   Friend WithEvents txtMaximoCaracteresItem As Eniac.Controles.TextBox
   Friend WithEvents lblMaximoCaracteresItem As Eniac.Controles.Label
   Friend WithEvents ugComprobantes As UltraGridEditable
    Friend WithEvents lblFiscalUltimaFechaExtraidaAuditoria As Controles.Label
    Friend WithEvents txtFiscalUltimaFechaExtraidaAuditoria As Controles.TextBox
    Friend WithEvents lblFiscalUltimaFechaExtraidaInforme As Controles.Label
    Friend WithEvents txtFiscalUltimaFechaExtraidaInforme As Controles.TextBox
    Friend WithEvents lblFiscalUltimoZetaExtraidoAuditoria As Controles.Label
    Friend WithEvents txtFiscalUltimoZetaExtraidoAuditoria As Controles.TextBox
    Friend WithEvents chbUtilizaBonosFiscalesElectronicos As Controles.CheckBox
End Class
