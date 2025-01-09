<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehiculosDetalle
    Inherits BaseDetalle

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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocCliente")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocCliente")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PatenteVehiculo")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Password")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
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
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehiculosDetalle))
        Me.lblPatente = New Eniac.Controles.Label()
        Me.txtPatente = New Eniac.Controles.TextBox()
        Me.LnkMarcaVehiculo = New Eniac.Controles.LinkLabel()
        Me.LnkModeloVehiculo = New Eniac.Controles.LinkLabel()
        Me.txtColor = New Eniac.Controles.TextBox()
        Me.lblColor = New Eniac.Controles.Label()
        Me.lblVencSeguro = New Eniac.Controles.Label()
        Me.gbx_Clientes = New System.Windows.Forms.GroupBox()
        Me.ugClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnRefrescar = New Eniac.Controles.Button()
        Me.btnEliminar = New Eniac.Controles.Button()
        Me.btnInsertar = New Eniac.Controles.Button()
        Me.pnlCliente = New System.Windows.Forms.Panel()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.Label4 = New Eniac.Controles.Label()
        Me.Label2 = New Eniac.Controles.Label()
        Me.Label1 = New Eniac.Controles.Label()
        Me.Label3 = New Eniac.Controles.Label()
        Me.bscNombreCliente = New Eniac.Controles.Buscador2()
        Me.cmbTipoDoc = New Eniac.Controles.ComboBox()
        Me.bscNumeroDoc = New Eniac.Controles.Buscador2()
        Me.dtpRuta = New Eniac.Controles.DateTimePicker()
        Me.dtpVTV = New Eniac.Controles.DateTimePicker()
        Me.chbEsCtaOrden = New Eniac.Controles.CheckBox()
        Me.chbRuta = New Eniac.Controles.CheckBox()
        Me.chbVTV = New Eniac.Controles.CheckBox()
        Me.dtpVencimientoSeguro = New Eniac.Controles.DateTimePicker()
        Me.cmbModelo = New Eniac.Controles.ComboBox()
        Me.cmbMarca = New Eniac.Controles.ComboBox()
        Me.pnlVehiculo = New System.Windows.Forms.Panel()
        Me.cmbIdentificacionVehiculo = New Eniac.Controles.ComboBox()
        Me.lblIdentificacionVehiculo = New Eniac.Controles.Label()
        Me.cmbEstadoVehiculo = New Eniac.Controles.ComboBox()
        Me.lblEstadoVehiculo = New Eniac.Controles.Label()
        Me.cmbAuxilioVehiculo = New Eniac.Controles.ComboBox()
        Me.lblAuxilioVehiculo = New Eniac.Controles.Label()
        Me.cmbLlantasVehiculo = New Eniac.Controles.ComboBox()
        Me.lblLlantasVehiculo = New Eniac.Controles.Label()
        Me.txtObservacionesVehiculo = New Eniac.Controles.TextBox()
        Me.lblObservacionesVehiculo = New Eniac.Controles.Label()
        Me.txtOtrosVehiculo = New Eniac.Controles.TextBox()
        Me.lblOtrosVehiculo = New Eniac.Controles.Label()
        Me.txtNeumaticosVehiculo = New Eniac.Controles.TextBox()
        Me.lblNeumaticosVehiculo = New Eniac.Controles.Label()
        Me.txtMedidasVehiculo = New Eniac.Controles.TextBox()
        Me.lblMedidasVehiculo = New Eniac.Controles.Label()
        Me.txtAnioPatentamiento = New Eniac.Controles.TextBox()
        Me.lblAnioPatentamiento = New Eniac.Controles.Label()
        Me.txtLargo = New Eniac.Controles.TextBox()
        Me.lblLargo = New Eniac.Controles.Label()
        Me.cmbTipoUnidad = New Eniac.Controles.ComboBox()
        Me.lblTipoUnidad = New Eniac.Controles.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPrecios = New System.Windows.Forms.Panel()
        Me.txtCodigoOperacionIngreso = New Eniac.Controles.TextBox()
        Me.lblCodigoOperacionIngreso = New Eniac.Controles.Label()
        Me.pnlColorPrecioLista = New System.Windows.Forms.Panel()
        Me.txtMaximoActualizado = New Eniac.Controles.TextBox()
        Me.lblMaximoActualizado = New Eniac.Controles.Label()
        Me.txtMinimoActualizado = New Eniac.Controles.TextBox()
        Me.lblMinimoActualizado = New Eniac.Controles.Label()
        Me.txtPrecioReferenciaActual = New Eniac.Controles.TextBox()
        Me.lblPrecioReferenciaActual = New Eniac.Controles.Label()
        Me.txtPrecioReferencia = New Eniac.Controles.TextBox()
        Me.lblPrecioReferencia = New Eniac.Controles.Label()
        Me.bscProducto2 = New Eniac.Controles.Buscador2()
        Me.lblProducto = New Eniac.Controles.Label()
        Me.bscCodigoProducto2 = New Eniac.Controles.Buscador2()
        Me.txtPrecioLista = New Eniac.Controles.TextBox()
        Me.lblPrecioLista = New Eniac.Controles.Label()
        Me.txtPrecioCompra = New Eniac.Controles.TextBox()
        Me.lblPrecioCompra = New Eniac.Controles.Label()
        Me.gbx_Clientes.SuspendLayout()
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlCliente.SuspendLayout()
        Me.pnlVehiculo.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.pnlPrecios.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(634, 515)
        Me.btnAceptar.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(720, 515)
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(533, 515)
        Me.btnCopiar.TabIndex = 4
        '
        'btnAplicar
        '
        Me.btnAplicar.Location = New System.Drawing.Point(476, 515)
        Me.btnAplicar.TabIndex = 3
        '
        'lblPatente
        '
        Me.lblPatente.AutoSize = True
        Me.lblPatente.LabelAsoc = Nothing
        Me.lblPatente.Location = New System.Drawing.Point(21, 16)
        Me.lblPatente.Name = "lblPatente"
        Me.lblPatente.Size = New System.Drawing.Size(44, 13)
        Me.lblPatente.TabIndex = 0
        Me.lblPatente.Text = "Patente"
        '
        'txtPatente
        '
        Me.txtPatente.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtPatente.BindearPropiedadControl = "Text"
        Me.txtPatente.BindearPropiedadEntidad = "PatenteVehiculo"
        Me.txtPatente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPatente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPatente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPatente.Formato = ""
        Me.txtPatente.IsDecimal = False
        Me.txtPatente.IsNumber = False
        Me.txtPatente.IsPK = False
        Me.txtPatente.IsRequired = True
        Me.txtPatente.Key = ""
        Me.txtPatente.LabelAsoc = Me.lblPatente
        Me.txtPatente.Location = New System.Drawing.Point(105, 12)
        Me.txtPatente.MaxLength = 8
        Me.txtPatente.Name = "txtPatente"
        Me.txtPatente.Size = New System.Drawing.Size(92, 20)
        Me.txtPatente.TabIndex = 1
        Me.txtPatente.TabStop = False
        '
        'LnkMarcaVehiculo
        '
        Me.LnkMarcaVehiculo.AutoSize = True
        Me.LnkMarcaVehiculo.LabelAsoc = Nothing
        Me.LnkMarcaVehiculo.Location = New System.Drawing.Point(21, 69)
        Me.LnkMarcaVehiculo.Name = "LnkMarcaVehiculo"
        Me.LnkMarcaVehiculo.Size = New System.Drawing.Size(37, 13)
        Me.LnkMarcaVehiculo.TabIndex = 8
        Me.LnkMarcaVehiculo.TabStop = True
        Me.LnkMarcaVehiculo.Text = "Marca"
        Me.LnkMarcaVehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LnkModeloVehiculo
        '
        Me.LnkModeloVehiculo.AutoSize = True
        Me.LnkModeloVehiculo.LabelAsoc = Nothing
        Me.LnkModeloVehiculo.Location = New System.Drawing.Point(279, 69)
        Me.LnkModeloVehiculo.Name = "LnkModeloVehiculo"
        Me.LnkModeloVehiculo.Size = New System.Drawing.Size(42, 13)
        Me.LnkModeloVehiculo.TabIndex = 10
        Me.LnkModeloVehiculo.TabStop = True
        Me.LnkModeloVehiculo.Text = "Modelo"
        Me.LnkModeloVehiculo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtColor.BindearPropiedadControl = "Text"
        Me.txtColor.BindearPropiedadEntidad = "Color"
        Me.txtColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColor.ForeColorFocus = System.Drawing.Color.Red
        Me.txtColor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtColor.Formato = ""
        Me.txtColor.IsDecimal = False
        Me.txtColor.IsNumber = False
        Me.txtColor.IsPK = False
        Me.txtColor.IsRequired = True
        Me.txtColor.Key = ""
        Me.txtColor.LabelAsoc = Nothing
        Me.txtColor.Location = New System.Drawing.Point(105, 92)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(157, 20)
        Me.txtColor.TabIndex = 15
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.LabelAsoc = Nothing
        Me.lblColor.Location = New System.Drawing.Point(21, 96)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(31, 13)
        Me.lblColor.TabIndex = 14
        Me.lblColor.Text = "Color"
        '
        'lblVencSeguro
        '
        Me.lblVencSeguro.AutoSize = True
        Me.lblVencSeguro.LabelAsoc = Nothing
        Me.lblVencSeguro.Location = New System.Drawing.Point(572, 206)
        Me.lblVencSeguro.Name = "lblVencSeguro"
        Me.lblVencSeguro.Size = New System.Drawing.Size(72, 13)
        Me.lblVencSeguro.TabIndex = 34
        Me.lblVencSeguro.Text = "Venc. Seguro"
        '
        'gbx_Clientes
        '
        Me.gbx_Clientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbx_Clientes.Controls.Add(Me.ugClientes)
        Me.gbx_Clientes.Controls.Add(Me.TableLayoutPanel1)
        Me.gbx_Clientes.Location = New System.Drawing.Point(124, 326)
        Me.gbx_Clientes.Name = "gbx_Clientes"
        Me.gbx_Clientes.Size = New System.Drawing.Size(571, 180)
        Me.gbx_Clientes.TabIndex = 2
        Me.gbx_Clientes.TabStop = False
        Me.gbx_Clientes.Text = "Clientes"
        '
        'ugClientes
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugClientes.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Header.Caption = "Id"
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Header.Caption = "Código"
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 90
        UltraGridColumn3.Header.Caption = "Tipo"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 40
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance4
        UltraGridColumn4.Header.Caption = "Documento"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Width = 90
        UltraGridColumn5.Header.Caption = "Nombre"
        UltraGridColumn5.Header.VisiblePosition = 4
        UltraGridColumn5.Width = 315
        UltraGridColumn6.Header.VisiblePosition = 5
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.VisiblePosition = 6
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.Header.VisiblePosition = 7
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.VisiblePosition = 8
        UltraGridColumn9.Hidden = True
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9})
        Me.ugClientes.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugClientes.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugClientes.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance5.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.GroupByBox.Appearance = Appearance5
        Appearance6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance6
        Me.ugClientes.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance7.BackColor2 = System.Drawing.SystemColors.Control
        Appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugClientes.DisplayLayout.GroupByBox.PromptAppearance = Appearance7
        Me.ugClientes.DisplayLayout.MaxColScrollRegions = 1
        Me.ugClientes.DisplayLayout.MaxRowScrollRegions = 1
        Appearance8.BackColor = System.Drawing.SystemColors.Window
        Appearance8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugClientes.DisplayLayout.Override.ActiveCellAppearance = Appearance8
        Appearance9.BackColor = System.Drawing.SystemColors.Highlight
        Appearance9.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugClientes.DisplayLayout.Override.ActiveRowAppearance = Appearance9
        Me.ugClientes.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugClientes.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance10.BackColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.CardAreaAppearance = Appearance10
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Appearance11.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugClientes.DisplayLayout.Override.CellAppearance = Appearance11
        Me.ugClientes.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugClientes.DisplayLayout.Override.CellPadding = 0
        Appearance12.BackColor = System.Drawing.SystemColors.Control
        Appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance12.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.BorderColor = System.Drawing.SystemColors.Window
        Me.ugClientes.DisplayLayout.Override.GroupByRowAppearance = Appearance12
        Appearance13.TextHAlignAsString = "Left"
        Me.ugClientes.DisplayLayout.Override.HeaderAppearance = Appearance13
        Me.ugClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugClientes.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance14.BackColor = System.Drawing.SystemColors.Window
        Appearance14.BorderColor = System.Drawing.Color.Silver
        Me.ugClientes.DisplayLayout.Override.RowAppearance = Appearance14
        Me.ugClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugClientes.DisplayLayout.Override.TemplateAddRowAppearance = Appearance15
        Me.ugClientes.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugClientes.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugClientes.Location = New System.Drawing.Point(3, 76)
        Me.ugClientes.Name = "ugClientes"
        Me.ugClientes.Size = New System.Drawing.Size(565, 101)
        Me.ugClientes.TabIndex = 0
        Me.ugClientes.Text = "UltraGrid1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.btnRefrescar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEliminar, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnInsertar, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlCliente, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(565, 60)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnRefrescar
        '
        Me.btnRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.btnRefrescar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRefrescar.Location = New System.Drawing.Point(3, 3)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(37, 37)
        Me.btnRefrescar.TabIndex = 0
        Me.btnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminar.Location = New System.Drawing.Point(525, 20)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(37, 37)
        Me.btnEliminar.TabIndex = 3
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnInsertar
        '
        Me.btnInsertar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertar.Image = CType(resources.GetObject("btnInsertar.Image"), System.Drawing.Image)
        Me.btnInsertar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnInsertar.Location = New System.Drawing.Point(482, 20)
        Me.btnInsertar.Name = "btnInsertar"
        Me.btnInsertar.Size = New System.Drawing.Size(37, 37)
        Me.btnInsertar.TabIndex = 2
        Me.btnInsertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnInsertar.UseVisualStyleBackColor = True
        '
        'pnlCliente
        '
        Me.pnlCliente.Controls.Add(Me.bscCodigoCliente)
        Me.pnlCliente.Controls.Add(Me.Label4)
        Me.pnlCliente.Controls.Add(Me.Label2)
        Me.pnlCliente.Controls.Add(Me.Label1)
        Me.pnlCliente.Controls.Add(Me.Label3)
        Me.pnlCliente.Controls.Add(Me.bscNombreCliente)
        Me.pnlCliente.Controls.Add(Me.cmbTipoDoc)
        Me.pnlCliente.Controls.Add(Me.bscNumeroDoc)
        Me.pnlCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCliente.Location = New System.Drawing.Point(46, 3)
        Me.pnlCliente.Name = "pnlCliente"
        Me.pnlCliente.Size = New System.Drawing.Size(430, 54)
        Me.pnlCliente.TabIndex = 1
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = ""
        Me.bscCodigoCliente.BindearPropiedadEntidad = ""
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(57, 3)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = True
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(137, 20)
        Me.bscCodigoCliente.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.LabelAsoc = Nothing
        Me.Label4.Location = New System.Drawing.Point(262, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Nro. Doc"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(7, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(7, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.LabelAsoc = Nothing
        Me.Label3.Location = New System.Drawing.Point(146, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo Doc."
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.ActivarFiltroEnGrilla = True
        Me.bscNombreCliente.BindearPropiedadControl = ""
        Me.bscNombreCliente.BindearPropiedadEntidad = ""
        Me.bscNombreCliente.ConfigBuscador = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Nothing
        Me.bscNombreCliente.Location = New System.Drawing.Point(57, 29)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = True
        Me.bscNombreCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNombreCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNombreCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(366, 20)
        Me.bscNombreCliente.TabIndex = 7
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.BindearPropiedadControl = ""
        Me.cmbTipoDoc.BindearPropiedadEntidad = ""
        Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDoc.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDoc.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.IsPK = False
        Me.cmbTipoDoc.IsRequired = False
        Me.cmbTipoDoc.Key = Nothing
        Me.cmbTipoDoc.LabelAsoc = Nothing
        Me.cmbTipoDoc.Location = New System.Drawing.Point(206, 1)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(50, 21)
        Me.cmbTipoDoc.TabIndex = 3
        '
        'bscNumeroDoc
        '
        Me.bscNumeroDoc.ActivarFiltroEnGrilla = True
        Me.bscNumeroDoc.BindearPropiedadControl = ""
        Me.bscNumeroDoc.BindearPropiedadEntidad = ""
        Me.bscNumeroDoc.ConfigBuscador = Nothing
        Me.bscNumeroDoc.Datos = Nothing
        Me.bscNumeroDoc.FilaDevuelta = Nothing
        Me.bscNumeroDoc.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNumeroDoc.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNumeroDoc.IsDecimal = False
        Me.bscNumeroDoc.IsNumber = False
        Me.bscNumeroDoc.IsPK = False
        Me.bscNumeroDoc.IsRequired = False
        Me.bscNumeroDoc.Key = ""
        Me.bscNumeroDoc.LabelAsoc = Nothing
        Me.bscNumeroDoc.Location = New System.Drawing.Point(318, 2)
        Me.bscNumeroDoc.MaxLengh = "32767"
        Me.bscNumeroDoc.Name = "bscNumeroDoc"
        Me.bscNumeroDoc.Permitido = True
        Me.bscNumeroDoc.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscNumeroDoc.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscNumeroDoc.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscNumeroDoc.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscNumeroDoc.Selecciono = False
        Me.bscNumeroDoc.Size = New System.Drawing.Size(105, 20)
        Me.bscNumeroDoc.TabIndex = 5
        '
        'dtpRuta
        '
        Me.dtpRuta.BindearPropiedadControl = ""
        Me.dtpRuta.BindearPropiedadEntidad = ""
        Me.dtpRuta.CustomFormat = "dd/MM/yyyy"
        Me.dtpRuta.Enabled = False
        Me.dtpRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpRuta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpRuta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpRuta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRuta.IsPK = False
        Me.dtpRuta.IsRequired = False
        Me.dtpRuta.Key = ""
        Me.dtpRuta.LabelAsoc = Nothing
        Me.dtpRuta.Location = New System.Drawing.Point(650, 150)
        Me.dtpRuta.Name = "dtpRuta"
        Me.dtpRuta.Size = New System.Drawing.Size(106, 20)
        Me.dtpRuta.TabIndex = 31
        '
        'dtpVTV
        '
        Me.dtpVTV.BindearPropiedadControl = ""
        Me.dtpVTV.BindearPropiedadEntidad = ""
        Me.dtpVTV.CustomFormat = "dd/MM/yyyy"
        Me.dtpVTV.Enabled = False
        Me.dtpVTV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpVTV.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpVTV.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpVTV.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVTV.IsPK = False
        Me.dtpVTV.IsRequired = False
        Me.dtpVTV.Key = ""
        Me.dtpVTV.LabelAsoc = Nothing
        Me.dtpVTV.Location = New System.Drawing.Point(650, 176)
        Me.dtpVTV.Name = "dtpVTV"
        Me.dtpVTV.Size = New System.Drawing.Size(106, 20)
        Me.dtpVTV.TabIndex = 33
        '
        'chbEsCtaOrden
        '
        Me.chbEsCtaOrden.AutoSize = True
        Me.chbEsCtaOrden.BindearPropiedadControl = "Checked"
        Me.chbEsCtaOrden.BindearPropiedadEntidad = "Activo"
        Me.chbEsCtaOrden.Checked = True
        Me.chbEsCtaOrden.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbEsCtaOrden.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEsCtaOrden.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEsCtaOrden.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbEsCtaOrden.IsPK = False
        Me.chbEsCtaOrden.IsRequired = False
        Me.chbEsCtaOrden.Key = Nothing
        Me.chbEsCtaOrden.LabelAsoc = Nothing
        Me.chbEsCtaOrden.Location = New System.Drawing.Point(370, 14)
        Me.chbEsCtaOrden.Name = "chbEsCtaOrden"
        Me.chbEsCtaOrden.Size = New System.Drawing.Size(56, 17)
        Me.chbEsCtaOrden.TabIndex = 36
        Me.chbEsCtaOrden.Text = "Activo"
        Me.chbEsCtaOrden.UseVisualStyleBackColor = True
        '
        'chbRuta
        '
        Me.chbRuta.AutoSize = True
        Me.chbRuta.BindearPropiedadControl = Nothing
        Me.chbRuta.BindearPropiedadEntidad = Nothing
        Me.chbRuta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbRuta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbRuta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbRuta.IsPK = False
        Me.chbRuta.IsRequired = False
        Me.chbRuta.Key = Nothing
        Me.chbRuta.LabelAsoc = Nothing
        Me.chbRuta.Location = New System.Drawing.Point(572, 152)
        Me.chbRuta.Name = "chbRuta"
        Me.chbRuta.Size = New System.Drawing.Size(56, 17)
        Me.chbRuta.TabIndex = 30
        Me.chbRuta.Text = "RUTA"
        Me.chbRuta.UseVisualStyleBackColor = True
        '
        'chbVTV
        '
        Me.chbVTV.AutoSize = True
        Me.chbVTV.BindearPropiedadControl = Nothing
        Me.chbVTV.BindearPropiedadEntidad = Nothing
        Me.chbVTV.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVTV.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVTV.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbVTV.IsPK = False
        Me.chbVTV.IsRequired = False
        Me.chbVTV.Key = Nothing
        Me.chbVTV.LabelAsoc = Nothing
        Me.chbVTV.Location = New System.Drawing.Point(572, 178)
        Me.chbVTV.Name = "chbVTV"
        Me.chbVTV.Size = New System.Drawing.Size(47, 17)
        Me.chbVTV.TabIndex = 32
        Me.chbVTV.Text = "VTV"
        Me.chbVTV.UseVisualStyleBackColor = True
        '
        'dtpVencimientoSeguro
        '
        Me.dtpVencimientoSeguro.BindearPropiedadControl = "Value"
        Me.dtpVencimientoSeguro.BindearPropiedadEntidad = "VencimientoSeguro"
        Me.dtpVencimientoSeguro.CustomFormat = "dd/MM/yyyy"
        Me.dtpVencimientoSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpVencimientoSeguro.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpVencimientoSeguro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpVencimientoSeguro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpVencimientoSeguro.IsPK = False
        Me.dtpVencimientoSeguro.IsRequired = False
        Me.dtpVencimientoSeguro.Key = ""
        Me.dtpVencimientoSeguro.LabelAsoc = Nothing
        Me.dtpVencimientoSeguro.Location = New System.Drawing.Point(650, 202)
        Me.dtpVencimientoSeguro.Name = "dtpVencimientoSeguro"
        Me.dtpVencimientoSeguro.Size = New System.Drawing.Size(106, 20)
        Me.dtpVencimientoSeguro.TabIndex = 35
        '
        'cmbModelo
        '
        Me.cmbModelo.BindearPropiedadControl = "SelectedValue"
        Me.cmbModelo.BindearPropiedadEntidad = "idModeloVehiculo"
        Me.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModelo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbModelo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbModelo.FormattingEnabled = True
        Me.cmbModelo.IsPK = False
        Me.cmbModelo.IsRequired = True
        Me.cmbModelo.Key = Nothing
        Me.cmbModelo.LabelAsoc = Nothing
        Me.cmbModelo.Location = New System.Drawing.Point(370, 65)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.Size = New System.Drawing.Size(157, 21)
        Me.cmbModelo.TabIndex = 11
        '
        'cmbMarca
        '
        Me.cmbMarca.BindearPropiedadControl = "SelectedValue"
        Me.cmbMarca.BindearPropiedadEntidad = "idMarcaVehiculo"
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMarca.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.IsPK = False
        Me.cmbMarca.IsRequired = True
        Me.cmbMarca.Key = Nothing
        Me.cmbMarca.LabelAsoc = Nothing
        Me.cmbMarca.Location = New System.Drawing.Point(105, 65)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(157, 21)
        Me.cmbMarca.TabIndex = 9
        '
        'pnlVehiculo
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.pnlVehiculo, 3)
        Me.pnlVehiculo.Controls.Add(Me.cmbIdentificacionVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.lblIdentificacionVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.cmbEstadoVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.lblEstadoVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.cmbAuxilioVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.lblAuxilioVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.cmbLlantasVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.lblLlantasVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.dtpRuta)
        Me.pnlVehiculo.Controls.Add(Me.dtpVTV)
        Me.pnlVehiculo.Controls.Add(Me.txtObservacionesVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.lblVencSeguro)
        Me.pnlVehiculo.Controls.Add(Me.lblObservacionesVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.chbRuta)
        Me.pnlVehiculo.Controls.Add(Me.txtOtrosVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.chbVTV)
        Me.pnlVehiculo.Controls.Add(Me.lblOtrosVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.dtpVencimientoSeguro)
        Me.pnlVehiculo.Controls.Add(Me.txtNeumaticosVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.lblNeumaticosVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.txtMedidasVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.lblMedidasVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.txtAnioPatentamiento)
        Me.pnlVehiculo.Controls.Add(Me.lblAnioPatentamiento)
        Me.pnlVehiculo.Controls.Add(Me.txtLargo)
        Me.pnlVehiculo.Controls.Add(Me.lblLargo)
        Me.pnlVehiculo.Controls.Add(Me.cmbTipoUnidad)
        Me.pnlVehiculo.Controls.Add(Me.lblTipoUnidad)
        Me.pnlVehiculo.Controls.Add(Me.txtPatente)
        Me.pnlVehiculo.Controls.Add(Me.lblPatente)
        Me.pnlVehiculo.Controls.Add(Me.LnkMarcaVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.cmbMarca)
        Me.pnlVehiculo.Controls.Add(Me.LnkModeloVehiculo)
        Me.pnlVehiculo.Controls.Add(Me.cmbModelo)
        Me.pnlVehiculo.Controls.Add(Me.lblColor)
        Me.pnlVehiculo.Controls.Add(Me.txtColor)
        Me.pnlVehiculo.Controls.Add(Me.chbEsCtaOrden)
        Me.pnlVehiculo.Location = New System.Drawing.Point(3, 3)
        Me.pnlVehiculo.Name = "pnlVehiculo"
        Me.pnlVehiculo.Size = New System.Drawing.Size(815, 233)
        Me.pnlVehiculo.TabIndex = 0
        '
        'cmbIdentificacionVehiculo
        '
        Me.cmbIdentificacionVehiculo.BindearPropiedadControl = "SelectedValue"
        Me.cmbIdentificacionVehiculo.BindearPropiedadEntidad = "IdentificacionVehiculo"
        Me.cmbIdentificacionVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdentificacionVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbIdentificacionVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbIdentificacionVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbIdentificacionVehiculo.FormattingEnabled = True
        Me.cmbIdentificacionVehiculo.IsPK = False
        Me.cmbIdentificacionVehiculo.IsRequired = False
        Me.cmbIdentificacionVehiculo.Key = Nothing
        Me.cmbIdentificacionVehiculo.LabelAsoc = Me.lblIdentificacionVehiculo
        Me.cmbIdentificacionVehiculo.Location = New System.Drawing.Point(471, 146)
        Me.cmbIdentificacionVehiculo.Name = "cmbIdentificacionVehiculo"
        Me.cmbIdentificacionVehiculo.Size = New System.Drawing.Size(56, 21)
        Me.cmbIdentificacionVehiculo.TabIndex = 27
        '
        'lblIdentificacionVehiculo
        '
        Me.lblIdentificacionVehiculo.AutoSize = True
        Me.lblIdentificacionVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblIdentificacionVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIdentificacionVehiculo.LabelAsoc = Nothing
        Me.lblIdentificacionVehiculo.Location = New System.Drawing.Point(393, 150)
        Me.lblIdentificacionVehiculo.Name = "lblIdentificacionVehiculo"
        Me.lblIdentificacionVehiculo.Size = New System.Drawing.Size(67, 13)
        Me.lblIdentificacionVehiculo.TabIndex = 26
        Me.lblIdentificacionVehiculo.Text = "Idenificación"
        '
        'cmbEstadoVehiculo
        '
        Me.cmbEstadoVehiculo.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoVehiculo.BindearPropiedadEntidad = "EstadoVehiculo.IdEstadoVehiculo"
        Me.cmbEstadoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbEstadoVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoVehiculo.FormattingEnabled = True
        Me.cmbEstadoVehiculo.IsPK = False
        Me.cmbEstadoVehiculo.IsRequired = True
        Me.cmbEstadoVehiculo.Key = Nothing
        Me.cmbEstadoVehiculo.LabelAsoc = Me.lblEstadoVehiculo
        Me.cmbEstadoVehiculo.Location = New System.Drawing.Point(649, 39)
        Me.cmbEstadoVehiculo.Name = "cmbEstadoVehiculo"
        Me.cmbEstadoVehiculo.Size = New System.Drawing.Size(157, 21)
        Me.cmbEstadoVehiculo.TabIndex = 7
        '
        'lblEstadoVehiculo
        '
        Me.lblEstadoVehiculo.AutoSize = True
        Me.lblEstadoVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblEstadoVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEstadoVehiculo.LabelAsoc = Nothing
        Me.lblEstadoVehiculo.Location = New System.Drawing.Point(572, 43)
        Me.lblEstadoVehiculo.Name = "lblEstadoVehiculo"
        Me.lblEstadoVehiculo.Size = New System.Drawing.Size(40, 13)
        Me.lblEstadoVehiculo.TabIndex = 6
        Me.lblEstadoVehiculo.Text = "Estado"
        '
        'cmbAuxilioVehiculo
        '
        Me.cmbAuxilioVehiculo.BindearPropiedadControl = "SelectedValue"
        Me.cmbAuxilioVehiculo.BindearPropiedadEntidad = "AuxilioVehiculo"
        Me.cmbAuxilioVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAuxilioVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbAuxilioVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAuxilioVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAuxilioVehiculo.FormattingEnabled = True
        Me.cmbAuxilioVehiculo.IsPK = False
        Me.cmbAuxilioVehiculo.IsRequired = False
        Me.cmbAuxilioVehiculo.Key = Nothing
        Me.cmbAuxilioVehiculo.LabelAsoc = Me.lblAuxilioVehiculo
        Me.cmbAuxilioVehiculo.Location = New System.Drawing.Point(649, 117)
        Me.cmbAuxilioVehiculo.Name = "cmbAuxilioVehiculo"
        Me.cmbAuxilioVehiculo.Size = New System.Drawing.Size(56, 21)
        Me.cmbAuxilioVehiculo.TabIndex = 21
        '
        'lblAuxilioVehiculo
        '
        Me.lblAuxilioVehiculo.AutoSize = True
        Me.lblAuxilioVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAuxilioVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAuxilioVehiculo.LabelAsoc = Nothing
        Me.lblAuxilioVehiculo.Location = New System.Drawing.Point(572, 121)
        Me.lblAuxilioVehiculo.Name = "lblAuxilioVehiculo"
        Me.lblAuxilioVehiculo.Size = New System.Drawing.Size(37, 13)
        Me.lblAuxilioVehiculo.TabIndex = 20
        Me.lblAuxilioVehiculo.Text = "Auxilio"
        '
        'cmbLlantasVehiculo
        '
        Me.cmbLlantasVehiculo.BindearPropiedadControl = "SelectedValue"
        Me.cmbLlantasVehiculo.BindearPropiedadEntidad = "LlantasVehiculo"
        Me.cmbLlantasVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLlantasVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbLlantasVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLlantasVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLlantasVehiculo.FormattingEnabled = True
        Me.cmbLlantasVehiculo.IsPK = False
        Me.cmbLlantasVehiculo.IsRequired = True
        Me.cmbLlantasVehiculo.Key = Nothing
        Me.cmbLlantasVehiculo.LabelAsoc = Me.lblLlantasVehiculo
        Me.cmbLlantasVehiculo.Location = New System.Drawing.Point(105, 119)
        Me.cmbLlantasVehiculo.Name = "cmbLlantasVehiculo"
        Me.cmbLlantasVehiculo.Size = New System.Drawing.Size(157, 21)
        Me.cmbLlantasVehiculo.TabIndex = 19
        '
        'lblLlantasVehiculo
        '
        Me.lblLlantasVehiculo.AutoSize = True
        Me.lblLlantasVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblLlantasVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLlantasVehiculo.LabelAsoc = Nothing
        Me.lblLlantasVehiculo.Location = New System.Drawing.Point(21, 123)
        Me.lblLlantasVehiculo.Name = "lblLlantasVehiculo"
        Me.lblLlantasVehiculo.Size = New System.Drawing.Size(41, 13)
        Me.lblLlantasVehiculo.TabIndex = 18
        Me.lblLlantasVehiculo.Text = "Llantas"
        '
        'txtObservacionesVehiculo
        '
        Me.txtObservacionesVehiculo.BindearPropiedadControl = "Text"
        Me.txtObservacionesVehiculo.BindearPropiedadEntidad = "ObservacionesVehiculo"
        Me.txtObservacionesVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtObservacionesVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtObservacionesVehiculo.Formato = ""
        Me.txtObservacionesVehiculo.IsDecimal = False
        Me.txtObservacionesVehiculo.IsNumber = False
        Me.txtObservacionesVehiculo.IsPK = False
        Me.txtObservacionesVehiculo.IsRequired = False
        Me.txtObservacionesVehiculo.Key = ""
        Me.txtObservacionesVehiculo.LabelAsoc = Me.lblObservacionesVehiculo
        Me.txtObservacionesVehiculo.Location = New System.Drawing.Point(105, 172)
        Me.txtObservacionesVehiculo.Multiline = True
        Me.txtObservacionesVehiculo.Name = "txtObservacionesVehiculo"
        Me.txtObservacionesVehiculo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtObservacionesVehiculo.Size = New System.Drawing.Size(422, 50)
        Me.txtObservacionesVehiculo.TabIndex = 29
        '
        'lblObservacionesVehiculo
        '
        Me.lblObservacionesVehiculo.AutoSize = True
        Me.lblObservacionesVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblObservacionesVehiculo.LabelAsoc = Nothing
        Me.lblObservacionesVehiculo.Location = New System.Drawing.Point(21, 176)
        Me.lblObservacionesVehiculo.Name = "lblObservacionesVehiculo"
        Me.lblObservacionesVehiculo.Size = New System.Drawing.Size(78, 13)
        Me.lblObservacionesVehiculo.TabIndex = 28
        Me.lblObservacionesVehiculo.Text = "Observaciones"
        '
        'txtOtrosVehiculo
        '
        Me.txtOtrosVehiculo.BindearPropiedadControl = "Text"
        Me.txtOtrosVehiculo.BindearPropiedadEntidad = "OtrosVehiculo"
        Me.txtOtrosVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtOtrosVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtOtrosVehiculo.Formato = ""
        Me.txtOtrosVehiculo.IsDecimal = False
        Me.txtOtrosVehiculo.IsNumber = False
        Me.txtOtrosVehiculo.IsPK = False
        Me.txtOtrosVehiculo.IsRequired = False
        Me.txtOtrosVehiculo.Key = ""
        Me.txtOtrosVehiculo.LabelAsoc = Me.lblOtrosVehiculo
        Me.txtOtrosVehiculo.Location = New System.Drawing.Point(167, 146)
        Me.txtOtrosVehiculo.Name = "txtOtrosVehiculo"
        Me.txtOtrosVehiculo.Size = New System.Drawing.Size(203, 20)
        Me.txtOtrosVehiculo.TabIndex = 25
        '
        'lblOtrosVehiculo
        '
        Me.lblOtrosVehiculo.AutoSize = True
        Me.lblOtrosVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOtrosVehiculo.LabelAsoc = Nothing
        Me.lblOtrosVehiculo.Location = New System.Drawing.Point(21, 150)
        Me.lblOtrosVehiculo.Name = "lblOtrosVehiculo"
        Me.lblOtrosVehiculo.Size = New System.Drawing.Size(140, 13)
        Me.lblOtrosVehiculo.TabIndex = 24
        Me.lblOtrosVehiculo.Text = "Sapitos / Tornillos / Ruedas"
        '
        'txtNeumaticosVehiculo
        '
        Me.txtNeumaticosVehiculo.BindearPropiedadControl = "Text"
        Me.txtNeumaticosVehiculo.BindearPropiedadEntidad = "NeumaticosVehiculo"
        Me.txtNeumaticosVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNeumaticosVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNeumaticosVehiculo.Formato = ""
        Me.txtNeumaticosVehiculo.IsDecimal = False
        Me.txtNeumaticosVehiculo.IsNumber = False
        Me.txtNeumaticosVehiculo.IsPK = False
        Me.txtNeumaticosVehiculo.IsRequired = False
        Me.txtNeumaticosVehiculo.Key = ""
        Me.txtNeumaticosVehiculo.LabelAsoc = Me.lblNeumaticosVehiculo
        Me.txtNeumaticosVehiculo.Location = New System.Drawing.Point(370, 118)
        Me.txtNeumaticosVehiculo.Name = "txtNeumaticosVehiculo"
        Me.txtNeumaticosVehiculo.Size = New System.Drawing.Size(157, 20)
        Me.txtNeumaticosVehiculo.TabIndex = 23
        '
        'lblNeumaticosVehiculo
        '
        Me.lblNeumaticosVehiculo.AutoSize = True
        Me.lblNeumaticosVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNeumaticosVehiculo.LabelAsoc = Nothing
        Me.lblNeumaticosVehiculo.Location = New System.Drawing.Point(279, 122)
        Me.lblNeumaticosVehiculo.Name = "lblNeumaticosVehiculo"
        Me.lblNeumaticosVehiculo.Size = New System.Drawing.Size(63, 13)
        Me.lblNeumaticosVehiculo.TabIndex = 22
        Me.lblNeumaticosVehiculo.Text = "Neumáticos"
        '
        'txtMedidasVehiculo
        '
        Me.txtMedidasVehiculo.BindearPropiedadControl = "Text"
        Me.txtMedidasVehiculo.BindearPropiedadEntidad = "MedidasVehiculo"
        Me.txtMedidasVehiculo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMedidasVehiculo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMedidasVehiculo.Formato = ""
        Me.txtMedidasVehiculo.IsDecimal = False
        Me.txtMedidasVehiculo.IsNumber = False
        Me.txtMedidasVehiculo.IsPK = False
        Me.txtMedidasVehiculo.IsRequired = False
        Me.txtMedidasVehiculo.Key = ""
        Me.txtMedidasVehiculo.LabelAsoc = Me.lblMedidasVehiculo
        Me.txtMedidasVehiculo.Location = New System.Drawing.Point(370, 92)
        Me.txtMedidasVehiculo.Name = "txtMedidasVehiculo"
        Me.txtMedidasVehiculo.Size = New System.Drawing.Size(157, 20)
        Me.txtMedidasVehiculo.TabIndex = 17
        '
        'lblMedidasVehiculo
        '
        Me.lblMedidasVehiculo.AutoSize = True
        Me.lblMedidasVehiculo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMedidasVehiculo.LabelAsoc = Nothing
        Me.lblMedidasVehiculo.Location = New System.Drawing.Point(279, 96)
        Me.lblMedidasVehiculo.Name = "lblMedidasVehiculo"
        Me.lblMedidasVehiculo.Size = New System.Drawing.Size(47, 13)
        Me.lblMedidasVehiculo.TabIndex = 16
        Me.lblMedidasVehiculo.Text = "Medidas"
        '
        'txtAnioPatentamiento
        '
        Me.txtAnioPatentamiento.BindearPropiedadControl = "Text"
        Me.txtAnioPatentamiento.BindearPropiedadEntidad = "AnioPatentamiento"
        Me.txtAnioPatentamiento.ForeColorFocus = System.Drawing.Color.Red
        Me.txtAnioPatentamiento.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtAnioPatentamiento.Formato = ""
        Me.txtAnioPatentamiento.IsDecimal = False
        Me.txtAnioPatentamiento.IsNumber = False
        Me.txtAnioPatentamiento.IsPK = False
        Me.txtAnioPatentamiento.IsRequired = False
        Me.txtAnioPatentamiento.Key = ""
        Me.txtAnioPatentamiento.LabelAsoc = Me.lblAnioPatentamiento
        Me.txtAnioPatentamiento.Location = New System.Drawing.Point(650, 65)
        Me.txtAnioPatentamiento.Name = "txtAnioPatentamiento"
        Me.txtAnioPatentamiento.Size = New System.Drawing.Size(42, 20)
        Me.txtAnioPatentamiento.TabIndex = 13
        Me.txtAnioPatentamiento.Text = "0"
        Me.txtAnioPatentamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAnioPatentamiento
        '
        Me.lblAnioPatentamiento.AutoSize = True
        Me.lblAnioPatentamiento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAnioPatentamiento.LabelAsoc = Nothing
        Me.lblAnioPatentamiento.Location = New System.Drawing.Point(572, 69)
        Me.lblAnioPatentamiento.Name = "lblAnioPatentamiento"
        Me.lblAnioPatentamiento.Size = New System.Drawing.Size(26, 13)
        Me.lblAnioPatentamiento.TabIndex = 12
        Me.lblAnioPatentamiento.Text = "Año"
        '
        'txtLargo
        '
        Me.txtLargo.BindearPropiedadControl = "Text"
        Me.txtLargo.BindearPropiedadEntidad = "SubTipoUnidad"
        Me.txtLargo.Enabled = False
        Me.txtLargo.ForeColorFocus = System.Drawing.Color.Red
        Me.txtLargo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtLargo.Formato = ""
        Me.txtLargo.IsDecimal = False
        Me.txtLargo.IsNumber = False
        Me.txtLargo.IsPK = False
        Me.txtLargo.IsRequired = False
        Me.txtLargo.Key = ""
        Me.txtLargo.LabelAsoc = Me.lblLargo
        Me.txtLargo.Location = New System.Drawing.Point(370, 38)
        Me.txtLargo.Name = "txtLargo"
        Me.txtLargo.Size = New System.Drawing.Size(157, 20)
        Me.txtLargo.TabIndex = 5
        '
        'lblLargo
        '
        Me.lblLargo.AutoSize = True
        Me.lblLargo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLargo.LabelAsoc = Nothing
        Me.lblLargo.Location = New System.Drawing.Point(279, 42)
        Me.lblLargo.Name = "lblLargo"
        Me.lblLargo.Size = New System.Drawing.Size(87, 13)
        Me.lblLargo.TabIndex = 4
        Me.lblLargo.Text = "Sub Tipo Unidad"
        '
        'cmbTipoUnidad
        '
        Me.cmbTipoUnidad.BindearPropiedadControl = "SelectedValue"
        Me.cmbTipoUnidad.BindearPropiedadEntidad = "TipoUnidad.IdTipoUnidad"
        Me.cmbTipoUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTipoUnidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoUnidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoUnidad.FormattingEnabled = True
        Me.cmbTipoUnidad.IsPK = False
        Me.cmbTipoUnidad.IsRequired = True
        Me.cmbTipoUnidad.Key = Nothing
        Me.cmbTipoUnidad.LabelAsoc = Me.lblTipoUnidad
        Me.cmbTipoUnidad.Location = New System.Drawing.Point(105, 38)
        Me.cmbTipoUnidad.Name = "cmbTipoUnidad"
        Me.cmbTipoUnidad.Size = New System.Drawing.Size(157, 21)
        Me.cmbTipoUnidad.TabIndex = 3
        '
        'lblTipoUnidad
        '
        Me.lblTipoUnidad.AutoSize = True
        Me.lblTipoUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblTipoUnidad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTipoUnidad.LabelAsoc = Nothing
        Me.lblTipoUnidad.Location = New System.Drawing.Point(21, 42)
        Me.lblTipoUnidad.Name = "lblTipoUnidad"
        Me.lblTipoUnidad.Size = New System.Drawing.Size(65, 13)
        Me.lblTipoUnidad.TabIndex = 2
        Me.lblTipoUnidad.Text = "Tipo Unidad"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001!))
        Me.TableLayoutPanel2.Controls.Add(Me.pnlVehiculo, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.gbx_Clientes, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.pnlPrecios, 0, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(821, 509)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'pnlPrecios
        '
        Me.pnlPrecios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPrecios.AutoSize = True
        Me.pnlPrecios.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.SetColumnSpan(Me.pnlPrecios, 3)
        Me.pnlPrecios.Controls.Add(Me.txtCodigoOperacionIngreso)
        Me.pnlPrecios.Controls.Add(Me.lblCodigoOperacionIngreso)
        Me.pnlPrecios.Controls.Add(Me.pnlColorPrecioLista)
        Me.pnlPrecios.Controls.Add(Me.txtMaximoActualizado)
        Me.pnlPrecios.Controls.Add(Me.lblMaximoActualizado)
        Me.pnlPrecios.Controls.Add(Me.txtMinimoActualizado)
        Me.pnlPrecios.Controls.Add(Me.lblMinimoActualizado)
        Me.pnlPrecios.Controls.Add(Me.txtPrecioReferenciaActual)
        Me.pnlPrecios.Controls.Add(Me.lblPrecioReferenciaActual)
        Me.pnlPrecios.Controls.Add(Me.txtPrecioReferencia)
        Me.pnlPrecios.Controls.Add(Me.lblPrecioReferencia)
        Me.pnlPrecios.Controls.Add(Me.bscProducto2)
        Me.pnlPrecios.Controls.Add(Me.lblProducto)
        Me.pnlPrecios.Controls.Add(Me.bscCodigoProducto2)
        Me.pnlPrecios.Controls.Add(Me.txtPrecioLista)
        Me.pnlPrecios.Controls.Add(Me.lblPrecioLista)
        Me.pnlPrecios.Controls.Add(Me.txtPrecioCompra)
        Me.pnlPrecios.Controls.Add(Me.lblPrecioCompra)
        Me.pnlPrecios.Location = New System.Drawing.Point(3, 242)
        Me.pnlPrecios.Name = "pnlPrecios"
        Me.pnlPrecios.Size = New System.Drawing.Size(815, 78)
        Me.pnlPrecios.TabIndex = 1
        '
        'txtCodigoOperacionIngreso
        '
        Me.txtCodigoOperacionIngreso.BindearPropiedadControl = "Text"
        Me.txtCodigoOperacionIngreso.BindearPropiedadEntidad = "CodigoOperacionIngreso"
        Me.txtCodigoOperacionIngreso.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCodigoOperacionIngreso.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCodigoOperacionIngreso.Formato = ""
        Me.txtCodigoOperacionIngreso.IsDecimal = False
        Me.txtCodigoOperacionIngreso.IsNumber = False
        Me.txtCodigoOperacionIngreso.IsPK = False
        Me.txtCodigoOperacionIngreso.IsRequired = False
        Me.txtCodigoOperacionIngreso.Key = ""
        Me.txtCodigoOperacionIngreso.LabelAsoc = Me.lblCodigoOperacionIngreso
        Me.txtCodigoOperacionIngreso.Location = New System.Drawing.Point(262, 3)
        Me.txtCodigoOperacionIngreso.Name = "txtCodigoOperacionIngreso"
        Me.txtCodigoOperacionIngreso.ReadOnly = True
        Me.txtCodigoOperacionIngreso.Size = New System.Drawing.Size(265, 20)
        Me.txtCodigoOperacionIngreso.TabIndex = 17
        Me.txtCodigoOperacionIngreso.TabStop = False
        '
        'lblCodigoOperacionIngreso
        '
        Me.lblCodigoOperacionIngreso.AutoSize = True
        Me.lblCodigoOperacionIngreso.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCodigoOperacionIngreso.LabelAsoc = Nothing
        Me.lblCodigoOperacionIngreso.Location = New System.Drawing.Point(200, 7)
        Me.lblCodigoOperacionIngreso.Name = "lblCodigoOperacionIngreso"
        Me.lblCodigoOperacionIngreso.Size = New System.Drawing.Size(56, 13)
        Me.lblCodigoOperacionIngreso.TabIndex = 16
        Me.lblCodigoOperacionIngreso.Text = "Operación"
        '
        'pnlColorPrecioLista
        '
        Me.pnlColorPrecioLista.Location = New System.Drawing.Point(196, 55)
        Me.pnlColorPrecioLista.Name = "pnlColorPrecioLista"
        Me.pnlColorPrecioLista.Size = New System.Drawing.Size(20, 20)
        Me.pnlColorPrecioLista.TabIndex = 15
        '
        'txtMaximoActualizado
        '
        Me.txtMaximoActualizado.BindearPropiedadControl = ""
        Me.txtMaximoActualizado.BindearPropiedadEntidad = ""
        Me.txtMaximoActualizado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMaximoActualizado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMaximoActualizado.Formato = "N2"
        Me.txtMaximoActualizado.IsDecimal = True
        Me.txtMaximoActualizado.IsNumber = True
        Me.txtMaximoActualizado.IsPK = False
        Me.txtMaximoActualizado.IsRequired = False
        Me.txtMaximoActualizado.Key = ""
        Me.txtMaximoActualizado.LabelAsoc = Me.lblMaximoActualizado
        Me.txtMaximoActualizado.Location = New System.Drawing.Point(585, 55)
        Me.txtMaximoActualizado.Name = "txtMaximoActualizado"
        Me.txtMaximoActualizado.ReadOnly = True
        Me.txtMaximoActualizado.Size = New System.Drawing.Size(69, 20)
        Me.txtMaximoActualizado.TabIndex = 14
        Me.txtMaximoActualizado.Text = "0,00"
        Me.txtMaximoActualizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMaximoActualizado
        '
        Me.lblMaximoActualizado.AutoSize = True
        Me.lblMaximoActualizado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMaximoActualizado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMaximoActualizado.LabelAsoc = Nothing
        Me.lblMaximoActualizado.Location = New System.Drawing.Point(478, 58)
        Me.lblMaximoActualizado.Name = "lblMaximoActualizado"
        Me.lblMaximoActualizado.Size = New System.Drawing.Size(101, 13)
        Me.lblMaximoActualizado.TabIndex = 13
        Me.lblMaximoActualizado.Text = "Máximo Actualizado"
        '
        'txtMinimoActualizado
        '
        Me.txtMinimoActualizado.BindearPropiedadControl = ""
        Me.txtMinimoActualizado.BindearPropiedadEntidad = ""
        Me.txtMinimoActualizado.ForeColorFocus = System.Drawing.Color.Red
        Me.txtMinimoActualizado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtMinimoActualizado.Formato = "N2"
        Me.txtMinimoActualizado.IsDecimal = True
        Me.txtMinimoActualizado.IsNumber = True
        Me.txtMinimoActualizado.IsPK = False
        Me.txtMinimoActualizado.IsRequired = False
        Me.txtMinimoActualizado.Key = ""
        Me.txtMinimoActualizado.LabelAsoc = Me.lblMinimoActualizado
        Me.txtMinimoActualizado.Location = New System.Drawing.Point(393, 55)
        Me.txtMinimoActualizado.Name = "txtMinimoActualizado"
        Me.txtMinimoActualizado.ReadOnly = True
        Me.txtMinimoActualizado.Size = New System.Drawing.Size(69, 20)
        Me.txtMinimoActualizado.TabIndex = 12
        Me.txtMinimoActualizado.Text = "0,00"
        Me.txtMinimoActualizado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMinimoActualizado
        '
        Me.lblMinimoActualizado.AutoSize = True
        Me.lblMinimoActualizado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMinimoActualizado.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMinimoActualizado.LabelAsoc = Nothing
        Me.lblMinimoActualizado.Location = New System.Drawing.Point(287, 58)
        Me.lblMinimoActualizado.Name = "lblMinimoActualizado"
        Me.lblMinimoActualizado.Size = New System.Drawing.Size(100, 13)
        Me.lblMinimoActualizado.TabIndex = 11
        Me.lblMinimoActualizado.Text = "Mínimo Actualizado"
        '
        'txtPrecioReferenciaActual
        '
        Me.txtPrecioReferenciaActual.BindearPropiedadControl = ""
        Me.txtPrecioReferenciaActual.BindearPropiedadEntidad = ""
        Me.txtPrecioReferenciaActual.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioReferenciaActual.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioReferenciaActual.Formato = "N2"
        Me.txtPrecioReferenciaActual.IsDecimal = True
        Me.txtPrecioReferenciaActual.IsNumber = True
        Me.txtPrecioReferenciaActual.IsPK = False
        Me.txtPrecioReferenciaActual.IsRequired = False
        Me.txtPrecioReferenciaActual.Key = ""
        Me.txtPrecioReferenciaActual.LabelAsoc = Me.lblPrecioReferenciaActual
        Me.txtPrecioReferenciaActual.Location = New System.Drawing.Point(737, 30)
        Me.txtPrecioReferenciaActual.Name = "txtPrecioReferenciaActual"
        Me.txtPrecioReferenciaActual.ReadOnly = True
        Me.txtPrecioReferenciaActual.Size = New System.Drawing.Size(69, 20)
        Me.txtPrecioReferenciaActual.TabIndex = 10
        Me.txtPrecioReferenciaActual.Text = "0,00"
        Me.txtPrecioReferenciaActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioReferenciaActual
        '
        Me.lblPrecioReferenciaActual.AutoSize = True
        Me.lblPrecioReferenciaActual.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioReferenciaActual.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecioReferenciaActual.LabelAsoc = Nothing
        Me.lblPrecioReferenciaActual.Location = New System.Drawing.Point(639, 33)
        Me.lblPrecioReferenciaActual.Name = "lblPrecioReferenciaActual"
        Me.lblPrecioReferenciaActual.Size = New System.Drawing.Size(92, 13)
        Me.lblPrecioReferenciaActual.TabIndex = 9
        Me.lblPrecioReferenciaActual.Text = "Referencia Actual"
        '
        'txtPrecioReferencia
        '
        Me.txtPrecioReferencia.BindearPropiedadControl = "Text"
        Me.txtPrecioReferencia.BindearPropiedadEntidad = "PrecioReferencia"
        Me.txtPrecioReferencia.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioReferencia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioReferencia.Formato = "N2"
        Me.txtPrecioReferencia.IsDecimal = True
        Me.txtPrecioReferencia.IsNumber = True
        Me.txtPrecioReferencia.IsPK = False
        Me.txtPrecioReferencia.IsRequired = False
        Me.txtPrecioReferencia.Key = ""
        Me.txtPrecioReferencia.LabelAsoc = Me.lblPrecioReferencia
        Me.txtPrecioReferencia.Location = New System.Drawing.Point(121, 29)
        Me.txtPrecioReferencia.Name = "txtPrecioReferencia"
        Me.txtPrecioReferencia.ReadOnly = True
        Me.txtPrecioReferencia.Size = New System.Drawing.Size(69, 20)
        Me.txtPrecioReferencia.TabIndex = 3
        Me.txtPrecioReferencia.Text = "0,00"
        Me.txtPrecioReferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioReferencia
        '
        Me.lblPrecioReferencia.AutoSize = True
        Me.lblPrecioReferencia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioReferencia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecioReferencia.LabelAsoc = Nothing
        Me.lblPrecioReferencia.Location = New System.Drawing.Point(18, 32)
        Me.lblPrecioReferencia.Name = "lblPrecioReferencia"
        Me.lblPrecioReferencia.Size = New System.Drawing.Size(92, 13)
        Me.lblPrecioReferencia.TabIndex = 2
        Me.lblPrecioReferencia.Text = "Precio Referencia"
        '
        'bscProducto2
        '
        Me.bscProducto2.ActivarFiltroEnGrilla = True
        Me.bscProducto2.BindearPropiedadControl = Nothing
        Me.bscProducto2.BindearPropiedadEntidad = Nothing
        Me.bscProducto2.ConfigBuscador = Nothing
        Me.bscProducto2.Datos = Nothing
        Me.bscProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscProducto2.IsDecimal = False
        Me.bscProducto2.IsNumber = False
        Me.bscProducto2.IsPK = False
        Me.bscProducto2.IsRequired = False
        Me.bscProducto2.Key = ""
        Me.bscProducto2.LabelAsoc = Me.lblProducto
        Me.bscProducto2.Location = New System.Drawing.Point(393, 29)
        Me.bscProducto2.MaxLengh = "60"
        Me.bscProducto2.Name = "bscProducto2"
        Me.bscProducto2.Permitido = True
        Me.bscProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscProducto2.Selecciono = False
        Me.bscProducto2.Size = New System.Drawing.Size(240, 20)
        Me.bscProducto2.TabIndex = 6
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblProducto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProducto.LabelAsoc = Nothing
        Me.lblProducto.Location = New System.Drawing.Point(200, 33)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 4
        Me.lblProducto.Text = "Producto"
        '
        'bscCodigoProducto2
        '
        Me.bscCodigoProducto2.ActivarFiltroEnGrilla = True
        Me.bscCodigoProducto2.BindearPropiedadControl = "Text"
        Me.bscCodigoProducto2.BindearPropiedadEntidad = "IdProductoReferencia"
        Me.bscCodigoProducto2.ConfigBuscador = Nothing
        Me.bscCodigoProducto2.Datos = Nothing
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscCodigoProducto2.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoProducto2.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoProducto2.IsDecimal = False
        Me.bscCodigoProducto2.IsNumber = False
        Me.bscCodigoProducto2.IsPK = False
        Me.bscCodigoProducto2.IsRequired = False
        Me.bscCodigoProducto2.Key = ""
        Me.bscCodigoProducto2.LabelAsoc = Nothing
        Me.bscCodigoProducto2.Location = New System.Drawing.Point(262, 29)
        Me.bscCodigoProducto2.MaxLengh = "32767"
        Me.bscCodigoProducto2.Name = "bscCodigoProducto2"
        Me.bscCodigoProducto2.Permitido = True
        Me.bscCodigoProducto2.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoProducto2.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoProducto2.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoProducto2.Selecciono = False
        Me.bscCodigoProducto2.Size = New System.Drawing.Size(125, 20)
        Me.bscCodigoProducto2.TabIndex = 5
        '
        'txtPrecioLista
        '
        Me.txtPrecioLista.BindearPropiedadControl = "Text"
        Me.txtPrecioLista.BindearPropiedadEntidad = "PrecioLista"
        Me.txtPrecioLista.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioLista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioLista.Formato = "N2"
        Me.txtPrecioLista.IsDecimal = True
        Me.txtPrecioLista.IsNumber = True
        Me.txtPrecioLista.IsPK = False
        Me.txtPrecioLista.IsRequired = False
        Me.txtPrecioLista.Key = ""
        Me.txtPrecioLista.LabelAsoc = Me.lblPrecioLista
        Me.txtPrecioLista.Location = New System.Drawing.Point(121, 55)
        Me.txtPrecioLista.Name = "txtPrecioLista"
        Me.txtPrecioLista.Size = New System.Drawing.Size(69, 20)
        Me.txtPrecioLista.TabIndex = 8
        Me.txtPrecioLista.Text = "0,00"
        Me.txtPrecioLista.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioLista
        '
        Me.lblPrecioLista.AutoSize = True
        Me.lblPrecioLista.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioLista.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecioLista.LabelAsoc = Nothing
        Me.lblPrecioLista.Location = New System.Drawing.Point(18, 58)
        Me.lblPrecioLista.Name = "lblPrecioLista"
        Me.lblPrecioLista.Size = New System.Drawing.Size(62, 13)
        Me.lblPrecioLista.TabIndex = 7
        Me.lblPrecioLista.Text = "Precio Lista"
        '
        'txtPrecioCompra
        '
        Me.txtPrecioCompra.BindearPropiedadControl = "Text"
        Me.txtPrecioCompra.BindearPropiedadEntidad = "PrecioCompra"
        Me.txtPrecioCompra.ForeColorFocus = System.Drawing.Color.Red
        Me.txtPrecioCompra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtPrecioCompra.Formato = "N2"
        Me.txtPrecioCompra.IsDecimal = True
        Me.txtPrecioCompra.IsNumber = True
        Me.txtPrecioCompra.IsPK = False
        Me.txtPrecioCompra.IsRequired = False
        Me.txtPrecioCompra.Key = ""
        Me.txtPrecioCompra.LabelAsoc = Me.lblPrecioCompra
        Me.txtPrecioCompra.Location = New System.Drawing.Point(121, 3)
        Me.txtPrecioCompra.Name = "txtPrecioCompra"
        Me.txtPrecioCompra.Size = New System.Drawing.Size(69, 20)
        Me.txtPrecioCompra.TabIndex = 1
        Me.txtPrecioCompra.Text = "0,00"
        Me.txtPrecioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecioCompra
        '
        Me.lblPrecioCompra.AutoSize = True
        Me.lblPrecioCompra.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPrecioCompra.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPrecioCompra.LabelAsoc = Nothing
        Me.lblPrecioCompra.Location = New System.Drawing.Point(18, 6)
        Me.lblPrecioCompra.Name = "lblPrecioCompra"
        Me.lblPrecioCompra.Size = New System.Drawing.Size(76, 13)
        Me.lblPrecioCompra.TabIndex = 0
        Me.lblPrecioCompra.Text = "Precio Compra"
        '
        'VehiculosDetalle
        '
        Me.AcceptButton = Nothing
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 557)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "VehiculosDetalle"
        Me.Text = "Vehiculos"
        Me.Controls.SetChildIndex(Me.btnCancelar, 0)
        Me.Controls.SetChildIndex(Me.btnAceptar, 0)
        Me.Controls.SetChildIndex(Me.btnCopiar, 0)
        Me.Controls.SetChildIndex(Me.btnAplicar, 0)
        Me.Controls.SetChildIndex(Me.TableLayoutPanel2, 0)
        Me.gbx_Clientes.ResumeLayout(False)
        CType(Me.ugClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlCliente.ResumeLayout(False)
        Me.pnlCliente.PerformLayout()
        Me.pnlVehiculo.ResumeLayout(False)
        Me.pnlVehiculo.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.pnlPrecios.ResumeLayout(False)
        Me.pnlPrecios.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblPatente As Controles.Label
    Friend WithEvents txtPatente As Controles.TextBox
    Friend WithEvents LnkMarcaVehiculo As Controles.LinkLabel
    Friend WithEvents cmbMarca As Controles.ComboBox
    Friend WithEvents cmbModelo As Controles.ComboBox
    Friend WithEvents LnkModeloVehiculo As Controles.LinkLabel
    Friend WithEvents txtColor As Controles.TextBox
    Friend WithEvents lblColor As Controles.Label
    Friend WithEvents lblVencSeguro As Controles.Label
    Friend WithEvents gbx_Clientes As GroupBox
    Friend WithEvents dtpRuta As Controles.DateTimePicker
    Friend WithEvents dtpVTV As Controles.DateTimePicker
    Friend WithEvents chbEsCtaOrden As Controles.CheckBox
    Friend WithEvents chbRuta As Controles.CheckBox
    Friend WithEvents chbVTV As Controles.CheckBox
    Friend WithEvents Label2 As Controles.Label
    Friend WithEvents Label3 As Controles.Label
    Friend WithEvents dtpVencimientoSeguro As Controles.DateTimePicker
    Friend WithEvents bscCodigoCliente As Controles.Buscador2
    Friend WithEvents cmbTipoDoc As Controles.ComboBox
    Friend WithEvents bscNumeroDoc As Controles.Buscador2
    Friend WithEvents Label4 As Controles.Label
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents bscNombreCliente As Controles.Buscador2
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents pnlCliente As Panel
    Friend WithEvents ugClientes As UltraGrid
    Friend WithEvents pnlVehiculo As Panel
    Friend WithEvents btnInsertar As Controles.Button
    Friend WithEvents btnEliminar As Controles.Button
    Friend WithEvents btnRefrescar As Controles.Button
    Friend WithEvents cmbTipoUnidad As Controles.ComboBox
    Friend WithEvents lblTipoUnidad As Controles.Label
    Friend WithEvents txtLargo As Controles.TextBox
    Friend WithEvents lblLargo As Controles.Label
    Friend WithEvents txtMedidasVehiculo As Controles.TextBox
    Friend WithEvents lblMedidasVehiculo As Controles.Label
    Friend WithEvents txtAnioPatentamiento As Controles.TextBox
    Friend WithEvents lblAnioPatentamiento As Controles.Label
    Friend WithEvents cmbIdentificacionVehiculo As Controles.ComboBox
    Friend WithEvents lblIdentificacionVehiculo As Controles.Label
    Friend WithEvents cmbAuxilioVehiculo As Controles.ComboBox
    Friend WithEvents lblAuxilioVehiculo As Controles.Label
    Friend WithEvents cmbLlantasVehiculo As Controles.ComboBox
    Friend WithEvents lblLlantasVehiculo As Controles.Label
    Friend WithEvents txtObservacionesVehiculo As Controles.TextBox
    Friend WithEvents lblObservacionesVehiculo As Controles.Label
    Friend WithEvents txtOtrosVehiculo As Controles.TextBox
    Friend WithEvents lblOtrosVehiculo As Controles.Label
    Friend WithEvents txtNeumaticosVehiculo As Controles.TextBox
    Friend WithEvents lblNeumaticosVehiculo As Controles.Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents cmbEstadoVehiculo As Controles.ComboBox
    Friend WithEvents lblEstadoVehiculo As Controles.Label
    Friend WithEvents pnlPrecios As Panel
    Friend WithEvents txtPrecioCompra As Controles.TextBox
    Friend WithEvents lblPrecioCompra As Controles.Label
    Friend WithEvents txtPrecioReferencia As Controles.TextBox
    Friend WithEvents lblPrecioReferencia As Controles.Label
    Friend WithEvents bscProducto2 As Controles.Buscador2
    Friend WithEvents lblProducto As Controles.Label
    Friend WithEvents bscCodigoProducto2 As Controles.Buscador2
    Friend WithEvents txtPrecioLista As Controles.TextBox
    Friend WithEvents lblPrecioLista As Controles.Label
    Friend WithEvents txtPrecioReferenciaActual As Controles.TextBox
    Friend WithEvents lblPrecioReferenciaActual As Controles.Label
    Friend WithEvents txtMaximoActualizado As Controles.TextBox
    Friend WithEvents lblMaximoActualizado As Controles.Label
    Friend WithEvents txtMinimoActualizado As Controles.TextBox
    Friend WithEvents lblMinimoActualizado As Controles.Label
    Friend WithEvents pnlColorPrecioLista As Panel
    Friend WithEvents txtCodigoOperacionIngreso As Controles.TextBox
    Friend WithEvents lblCodigoOperacionIngreso As Controles.Label
End Class
