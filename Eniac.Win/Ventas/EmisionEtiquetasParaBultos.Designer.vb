<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmisionEtiquetasParaBultos
   Inherits BaseForm

   'Form reemplaza a Dispose para limpiar la lista de componentes.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadBultos")
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadBultosDesde")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadBultosHasta")
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCategoria")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DireccionTransportista")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidadTransportista")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvinciaTransportista")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdVendedor")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidad")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLocalidadTransportista")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadBultosNuevo", 0)
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmisionEtiquetasParaBultos))
        Me.DialogoAbrirArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnTodos = New System.Windows.Forms.Button()
        Me.sspPie = New System.Windows.Forms.StatusStrip()
        Me.tslTexto = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ugDetalle = New Eniac.Win.UltraGridEditable()
        Me.grbFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbFormatos = New Eniac.Controles.ComboBox()
        Me.chbLetra = New Eniac.Controles.CheckBox()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbOrigenCategoria = New Eniac.Controles.ComboBox()
        Me.cmbOrigenVendedor = New Eniac.Controles.ComboBox()
        Me.cmbOrigenTransportista = New Eniac.Controles.ComboBox()
        Me.grpVentas = New System.Windows.Forms.GroupBox()
        Me.cmbEmisor = New Eniac.Controles.ComboBox()
        Me.chbEmisor = New Eniac.Controles.CheckBox()
        Me.cmbLetra = New Eniac.Controles.ComboBox()
        Me.txtNumeroCompDesde = New Eniac.Controles.TextBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.lblNumeroDesde = New Eniac.Controles.Label()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.lblNumeroHasta = New Eniac.Controles.Label()
        Me.txtNumeroCompHasta = New Eniac.Controles.TextBox()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.lblTiposComprobantes = New Eniac.Controles.Label()
        Me.chbClientesConVenta = New Eniac.Controles.CheckBox()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.chbMesCompleto = New Eniac.Controles.CheckBox()
        Me.chbTipoDireccion = New Eniac.Controles.CheckBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbTipoDireccion = New Eniac.Controles.ComboBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.lblComenzarPorNombreCliente = New Eniac.Controles.Label()
        Me.txtComenzarPorNombreCliente = New Eniac.Controles.TextBox()
        Me.chbTransportista = New Eniac.Controles.CheckBox()
        Me.chbCategoriaCliente = New Eniac.Controles.CheckBox()
        Me.cmbTransportista = New Eniac.Controles.ComboBox()
        Me.cmbCategoriasClientes = New Eniac.Controles.ComboBox()
        Me.bscNombreCliente = New Eniac.Controles.Buscador()
        Me.lblNombreCliente = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador()
        Me.lblCodigoCliente = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Controles.Button()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.txtCantidadBultos = New Eniac.Controles.TextBox()
        Me.cmbTodos = New Eniac.Controles.ComboBox()
        Me.chbReimpresion = New Eniac.Controles.CheckBox()
        Me.sspPie.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbFiltros.SuspendLayout()
        Me.grpVentas.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'DialogoAbrirArchivo
        '
        Me.DialogoAbrirArchivo.FileName = "OpenFileDialog1"
        Me.DialogoAbrirArchivo.Filter = "Adobe Reader (*.pdf)|*.pdf|Todos los Archivos (*.*)|*.*"
        Me.DialogoAbrirArchivo.RestoreDirectory = True
        '
        'btnTodos
        '
        Me.btnTodos.Image = Global.Eniac.Win.My.Resources.Resources.ok_24
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodos.Location = New System.Drawing.Point(187, 2)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(75, 23)
        Me.btnTodos.TabIndex = 2
        Me.btnTodos.Text = "Aplicar"
        Me.btnTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'sspPie
        '
        Me.sspPie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslTexto, Me.tspBarra, Me.tssRegistros})
        Me.sspPie.Location = New System.Drawing.Point(0, 539)
        Me.sspPie.Name = "sspPie"
        Me.sspPie.Size = New System.Drawing.Size(984, 22)
        Me.sspPie.TabIndex = 2
        Me.sspPie.Text = "StatusStrip1"
        '
        'tslTexto
        '
        Me.tslTexto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tslTexto.Name = "tslTexto"
        Me.tslTexto.Size = New System.Drawing.Size(905, 17)
        Me.tslTexto.Spring = True
        Me.tslTexto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Step = 1
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor3DBase = System.Drawing.Color.White
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn2.CellAppearance = Appearance2
        UltraGridColumn2.Format = "N0"
        UltraGridColumn2.Header.Caption = "Copias"
        UltraGridColumn2.Header.VisiblePosition = 0
        UltraGridColumn2.Width = 38
        Appearance3.TextHAlignAsString = "Right"
        UltraGridColumn3.CellAppearance = Appearance3
        UltraGridColumn3.Header.Caption = "Desde"
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Hidden = True
        UltraGridColumn3.Width = 50
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn4.CellAppearance = Appearance4
        UltraGridColumn4.Header.Caption = "Hasta"
        UltraGridColumn4.Header.VisiblePosition = 3
        UltraGridColumn4.Hidden = True
        UltraGridColumn4.Width = 50
        UltraGridColumn30.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance5
        UltraGridColumn30.Header.Caption = "Id Cliente"
        UltraGridColumn30.Header.VisiblePosition = 4
        UltraGridColumn30.Hidden = True
        UltraGridColumn31.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance6
        UltraGridColumn31.Format = ""
        UltraGridColumn31.Header.Caption = "Código"
        UltraGridColumn31.Header.VisiblePosition = 5
        UltraGridColumn31.Width = 60
        UltraGridColumn32.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn32.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        UltraGridColumn32.Header.Caption = "Nombre Cliente"
        UltraGridColumn32.Header.VisiblePosition = 6
        UltraGridColumn32.Width = 150
        UltraGridColumn33.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn33.Header.Caption = "Nombre Fantasia"
        UltraGridColumn33.Header.VisiblePosition = 7
        UltraGridColumn33.Width = 150
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.Header.Caption = "Dirección"
        UltraGridColumn5.Header.VisiblePosition = 9
        UltraGridColumn5.Width = 150
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.Header.Caption = "Localidad"
        UltraGridColumn6.Header.VisiblePosition = 11
        UltraGridColumn6.Width = 150
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.Header.Caption = "Provincia"
        UltraGridColumn7.Header.VisiblePosition = 12
        UltraGridColumn7.Width = 150
        UltraGridColumn35.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance7
        UltraGridColumn35.Header.Caption = "Código Categoría"
        UltraGridColumn35.Header.VisiblePosition = 13
        UltraGridColumn35.Hidden = True
        UltraGridColumn36.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn36.Header.Caption = "Categoría"
        UltraGridColumn36.Header.VisiblePosition = 8
        UltraGridColumn36.Width = 80
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance8
        UltraGridColumn8.Header.Caption = "Código Transportista"
        UltraGridColumn8.Header.VisiblePosition = 14
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.Header.Caption = "Transportista"
        UltraGridColumn9.Header.VisiblePosition = 15
        UltraGridColumn9.Width = 150
        UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn10.Header.Caption = "Dirección Transportista"
        UltraGridColumn10.Header.VisiblePosition = 16
        UltraGridColumn10.Width = 150
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.Header.Caption = "Localidad Transportista"
        UltraGridColumn11.Header.VisiblePosition = 18
        UltraGridColumn11.Width = 150
        UltraGridColumn12.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn12.Header.Caption = "Provincia Transportista"
        UltraGridColumn12.Header.VisiblePosition = 19
        UltraGridColumn12.Width = 150
        UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance9
        UltraGridColumn13.Header.Caption = "Código Vendedor"
        UltraGridColumn13.Header.VisiblePosition = 20
        UltraGridColumn13.Hidden = True
        UltraGridColumn51.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn51.Header.Caption = "Vendedor"
        UltraGridColumn51.Header.VisiblePosition = 22
        UltraGridColumn51.Width = 150
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn49.Header.Caption = "Observación"
        UltraGridColumn49.Header.VisiblePosition = 21
        UltraGridColumn49.Width = 320
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance10
        UltraGridColumn1.Header.Caption = "Código Postal"
        UltraGridColumn1.Header.VisiblePosition = 10
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance11
        UltraGridColumn14.Header.Caption = "Código Postal Transportista"
        UltraGridColumn14.Header.VisiblePosition = 17
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance12
        UltraGridColumn15.Format = "N0"
        UltraGridColumn15.Header.Caption = "Bultos"
        UltraGridColumn15.Header.VisiblePosition = 1
        UltraGridColumn15.Width = 49
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn35, UltraGridColumn36, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn51, UltraGridColumn49, UltraGridColumn1, UltraGridColumn14, UltraGridColumn15})
        UltraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        UltraGridBand1.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridBand1.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        UltraGridBand1.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        UltraGridBand1.SummaryFooterCaption = "Totales:"
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance13.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance13
        Appearance14.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance14
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Hidden = True
        Appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance15.BackColor2 = System.Drawing.SystemColors.Control
        Appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance15
        Me.ugDetalle.DisplayLayout.GroupByBox.ShowBandLabels = Infragistics.Win.UltraWinGrid.ShowBandLabels.None
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance16.BackColor = System.Drawing.SystemColors.Window
        Appearance16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance16
        Appearance17.BackColor = System.Drawing.SystemColors.Highlight
        Appearance17.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance17
        Me.ugDetalle.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance18.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance18
        Appearance19.BorderColor = System.Drawing.Color.Silver
        Appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance19
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Me.ugDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
        Me.ugDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
        Me.ugDetalle.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance20.BackColor = System.Drawing.Color.Tomato
        Appearance20.BackColor2 = System.Drawing.SystemColors.ButtonFace
        Appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance20.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance20
        Me.ugDetalle.DisplayLayout.Override.GroupBySummaryDisplayStyle = Infragistics.Win.UltraWinGrid.GroupBySummaryDisplayStyle.SummaryCells
        Appearance21.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance21
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance22
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.ugDetalle.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance23.BackColor = System.Drawing.Color.LimeGreen
        Appearance23.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance = Appearance23
        Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControlOnLastCell
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.EnterMueveACeldaDeAbajo = True
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 237)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(984, 302)
        Me.ugDetalle.TabIndex = 1
        Me.ugDetalle.Text = "UltraGrid1"
        '
        'grbFiltros
        '
        Me.grbFiltros.Controls.Add(Me.cmbFormatos)
        Me.grbFiltros.Controls.Add(Me.Label1)
        Me.grbFiltros.Controls.Add(Me.cmbOrigenCategoria)
        Me.grbFiltros.Controls.Add(Me.cmbOrigenVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbOrigenTransportista)
        Me.grbFiltros.Controls.Add(Me.grpVentas)
        Me.grbFiltros.Controls.Add(Me.chbTipoDireccion)
        Me.grbFiltros.Controls.Add(Me.chbVendedor)
        Me.grbFiltros.Controls.Add(Me.cmbTipoDireccion)
        Me.grbFiltros.Controls.Add(Me.cmbVendedor)
        Me.grbFiltros.Controls.Add(Me.lblComenzarPorNombreCliente)
        Me.grbFiltros.Controls.Add(Me.txtComenzarPorNombreCliente)
        Me.grbFiltros.Controls.Add(Me.chbTransportista)
        Me.grbFiltros.Controls.Add(Me.chbCategoriaCliente)
        Me.grbFiltros.Controls.Add(Me.cmbTransportista)
        Me.grbFiltros.Controls.Add(Me.cmbCategoriasClientes)
        Me.grbFiltros.Controls.Add(Me.bscNombreCliente)
        Me.grbFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.chbCliente)
        Me.grbFiltros.Controls.Add(Me.lblCodigoCliente)
        Me.grbFiltros.Controls.Add(Me.lblNombreCliente)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(984, 180)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'cmbFormatos
        '
        Me.cmbFormatos.BindearPropiedadControl = Nothing
        Me.cmbFormatos.BindearPropiedadEntidad = Nothing
        Me.cmbFormatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormatos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormatos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormatos.FormattingEnabled = True
        Me.cmbFormatos.IsPK = False
        Me.cmbFormatos.IsRequired = False
        Me.cmbFormatos.Key = Nothing
        Me.cmbFormatos.LabelAsoc = Me.chbLetra
        Me.cmbFormatos.Location = New System.Drawing.Point(656, 153)
        Me.cmbFormatos.Name = "cmbFormatos"
        Me.cmbFormatos.Size = New System.Drawing.Size(177, 21)
        Me.cmbFormatos.TabIndex = 21
        '
        'chbLetra
        '
        Me.chbLetra.AutoSize = True
        Me.chbLetra.BindearPropiedadControl = Nothing
        Me.chbLetra.BindearPropiedadEntidad = Nothing
        Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLetra.IsPK = False
        Me.chbLetra.IsRequired = False
        Me.chbLetra.Key = Nothing
        Me.chbLetra.LabelAsoc = Nothing
        Me.chbLetra.Location = New System.Drawing.Point(551, 46)
        Me.chbLetra.Name = "chbLetra"
        Me.chbLetra.Size = New System.Drawing.Size(50, 17)
        Me.chbLetra.TabIndex = 10
        Me.chbLetra.Text = "Letra"
        Me.chbLetra.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(605, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Formato"
        '
        'cmbOrigenCategoria
        '
        Me.cmbOrigenCategoria.BindearPropiedadControl = Nothing
        Me.cmbOrigenCategoria.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenCategoria.FormattingEnabled = True
        Me.cmbOrigenCategoria.IsPK = False
        Me.cmbOrigenCategoria.IsRequired = False
        Me.cmbOrigenCategoria.Key = Nothing
        Me.cmbOrigenCategoria.LabelAsoc = Nothing
        Me.cmbOrigenCategoria.Location = New System.Drawing.Point(265, 124)
        Me.cmbOrigenCategoria.Name = "cmbOrigenCategoria"
        Me.cmbOrigenCategoria.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenCategoria.TabIndex = 10
        '
        'cmbOrigenVendedor
        '
        Me.cmbOrigenVendedor.BindearPropiedadControl = Nothing
        Me.cmbOrigenVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenVendedor.FormattingEnabled = True
        Me.cmbOrigenVendedor.IsPK = False
        Me.cmbOrigenVendedor.IsRequired = False
        Me.cmbOrigenVendedor.Key = Nothing
        Me.cmbOrigenVendedor.LabelAsoc = Nothing
        Me.cmbOrigenVendedor.Location = New System.Drawing.Point(605, 122)
        Me.cmbOrigenVendedor.Name = "cmbOrigenVendedor"
        Me.cmbOrigenVendedor.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenVendedor.TabIndex = 13
        '
        'cmbOrigenTransportista
        '
        Me.cmbOrigenTransportista.BindearPropiedadControl = Nothing
        Me.cmbOrigenTransportista.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenTransportista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenTransportista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenTransportista.FormattingEnabled = True
        Me.cmbOrigenTransportista.IsPK = False
        Me.cmbOrigenTransportista.IsRequired = False
        Me.cmbOrigenTransportista.Key = Nothing
        Me.cmbOrigenTransportista.LabelAsoc = Nothing
        Me.cmbOrigenTransportista.Location = New System.Drawing.Point(265, 153)
        Me.cmbOrigenTransportista.Name = "cmbOrigenTransportista"
        Me.cmbOrigenTransportista.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenTransportista.TabIndex = 16
        '
        'grpVentas
        '
        Me.grpVentas.Controls.Add(Me.cmbEmisor)
        Me.grpVentas.Controls.Add(Me.cmbLetra)
        Me.grpVentas.Controls.Add(Me.txtNumeroCompDesde)
        Me.grpVentas.Controls.Add(Me.lblNumeroDesde)
        Me.grpVentas.Controls.Add(Me.lblNumeroHasta)
        Me.grpVentas.Controls.Add(Me.txtNumeroCompHasta)
        Me.grpVentas.Controls.Add(Me.chbLetra)
        Me.grpVentas.Controls.Add(Me.chbEmisor)
        Me.grpVentas.Controls.Add(Me.chbNumero)
        Me.grpVentas.Controls.Add(Me.cmbTiposComprobantes)
        Me.grpVentas.Controls.Add(Me.lblTiposComprobantes)
        Me.grpVentas.Controls.Add(Me.chbClientesConVenta)
        Me.grpVentas.Controls.Add(Me.cmbSucursal)
        Me.grpVentas.Controls.Add(Me.lblDesde)
        Me.grpVentas.Controls.Add(Me.lblSucursal)
        Me.grpVentas.Controls.Add(Me.lblHasta)
        Me.grpVentas.Controls.Add(Me.dtpDesde)
        Me.grpVentas.Controls.Add(Me.dtpHasta)
        Me.grpVentas.Controls.Add(Me.chbMesCompleto)
        Me.grpVentas.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpVentas.Location = New System.Drawing.Point(3, 16)
        Me.grpVentas.Name = "grpVentas"
        Me.grpVentas.Size = New System.Drawing.Size(978, 72)
        Me.grpVentas.TabIndex = 0
        Me.grpVentas.TabStop = False
        Me.grpVentas.Text = "Ventas"
        '
        'cmbEmisor
        '
        Me.cmbEmisor.BindearPropiedadControl = Nothing
        Me.cmbEmisor.BindearPropiedadEntidad = Nothing
        Me.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmisor.Enabled = False
        Me.cmbEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmisor.FormattingEnabled = True
        Me.cmbEmisor.IsPK = False
        Me.cmbEmisor.IsRequired = False
        Me.cmbEmisor.Key = Nothing
        Me.cmbEmisor.LabelAsoc = Me.chbEmisor
        Me.cmbEmisor.Location = New System.Drawing.Point(698, 44)
        Me.cmbEmisor.Name = "cmbEmisor"
        Me.cmbEmisor.Size = New System.Drawing.Size(40, 21)
        Me.cmbEmisor.TabIndex = 13
        '
        'chbEmisor
        '
        Me.chbEmisor.AutoSize = True
        Me.chbEmisor.BindearPropiedadControl = Nothing
        Me.chbEmisor.BindearPropiedadEntidad = Nothing
        Me.chbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmisor.IsPK = False
        Me.chbEmisor.IsRequired = False
        Me.chbEmisor.Key = Nothing
        Me.chbEmisor.LabelAsoc = Nothing
        Me.chbEmisor.Location = New System.Drawing.Point(642, 46)
        Me.chbEmisor.Name = "chbEmisor"
        Me.chbEmisor.Size = New System.Drawing.Size(57, 17)
        Me.chbEmisor.TabIndex = 12
        Me.chbEmisor.Text = "Emisor"
        Me.chbEmisor.UseVisualStyleBackColor = True
        '
        'cmbLetra
        '
        Me.cmbLetra.BindearPropiedadControl = Nothing
        Me.cmbLetra.BindearPropiedadEntidad = Nothing
        Me.cmbLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLetra.Enabled = False
        Me.cmbLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbLetra.FormattingEnabled = True
        Me.cmbLetra.IsPK = False
        Me.cmbLetra.IsRequired = False
        Me.cmbLetra.Key = Nothing
        Me.cmbLetra.LabelAsoc = Me.chbLetra
        Me.cmbLetra.Location = New System.Drawing.Point(599, 44)
        Me.cmbLetra.Name = "cmbLetra"
        Me.cmbLetra.Size = New System.Drawing.Size(38, 21)
        Me.cmbLetra.TabIndex = 11
        '
        'txtNumeroCompDesde
        '
        Me.txtNumeroCompDesde.BindearPropiedadControl = Nothing
        Me.txtNumeroCompDesde.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCompDesde.Enabled = False
        Me.txtNumeroCompDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCompDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCompDesde.Formato = "##0"
        Me.txtNumeroCompDesde.IsDecimal = False
        Me.txtNumeroCompDesde.IsNumber = True
        Me.txtNumeroCompDesde.IsPK = False
        Me.txtNumeroCompDesde.IsRequired = False
        Me.txtNumeroCompDesde.Key = ""
        Me.txtNumeroCompDesde.LabelAsoc = Me.chbNumero
        Me.txtNumeroCompDesde.Location = New System.Drawing.Point(813, 44)
        Me.txtNumeroCompDesde.MaxLength = 8
        Me.txtNumeroCompDesde.Name = "txtNumeroCompDesde"
        Me.txtNumeroCompDesde.Size = New System.Drawing.Size(55, 20)
        Me.txtNumeroCompDesde.TabIndex = 16
        Me.txtNumeroCompDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNumero
        '
        Me.chbNumero.AutoSize = True
        Me.chbNumero.BindearPropiedadControl = Nothing
        Me.chbNumero.BindearPropiedadEntidad = Nothing
        Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumero.IsPK = False
        Me.chbNumero.IsRequired = False
        Me.chbNumero.Key = Nothing
        Me.chbNumero.LabelAsoc = Nothing
        Me.chbNumero.Location = New System.Drawing.Point(749, 46)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 14
        Me.chbNumero.Text = "Numero"
        Me.chbNumero.UseVisualStyleBackColor = True
        '
        'lblNumeroDesde
        '
        Me.lblNumeroDesde.AutoSize = True
        Me.lblNumeroDesde.LabelAsoc = Me.chbCliente
        Me.lblNumeroDesde.Location = New System.Drawing.Point(810, 31)
        Me.lblNumeroDesde.Name = "lblNumeroDesde"
        Me.lblNumeroDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblNumeroDesde.TabIndex = 15
        Me.lblNumeroDesde.Text = "Desde"
        '
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(12, 98)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 1
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'lblNumeroHasta
        '
        Me.lblNumeroHasta.AutoSize = True
        Me.lblNumeroHasta.LabelAsoc = Me.chbCliente
        Me.lblNumeroHasta.Location = New System.Drawing.Point(870, 31)
        Me.lblNumeroHasta.Name = "lblNumeroHasta"
        Me.lblNumeroHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblNumeroHasta.TabIndex = 17
        Me.lblNumeroHasta.Text = "Hasta"
        '
        'txtNumeroCompHasta
        '
        Me.txtNumeroCompHasta.BindearPropiedadControl = Nothing
        Me.txtNumeroCompHasta.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCompHasta.Enabled = False
        Me.txtNumeroCompHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCompHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCompHasta.Formato = "##0"
        Me.txtNumeroCompHasta.IsDecimal = False
        Me.txtNumeroCompHasta.IsNumber = True
        Me.txtNumeroCompHasta.IsPK = False
        Me.txtNumeroCompHasta.IsRequired = False
        Me.txtNumeroCompHasta.Key = ""
        Me.txtNumeroCompHasta.LabelAsoc = Me.lblNumeroHasta
        Me.txtNumeroCompHasta.Location = New System.Drawing.Point(873, 44)
        Me.txtNumeroCompHasta.MaxLength = 8
        Me.txtNumeroCompHasta.Name = "txtNumeroCompHasta"
        Me.txtNumeroCompHasta.Size = New System.Drawing.Size(55, 20)
        Me.txtNumeroCompHasta.TabIndex = 18
        Me.txtNumeroCompHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.lblTiposComprobantes
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(415, 44)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
        Me.cmbTiposComprobantes.TabIndex = 9
        '
        'lblTiposComprobantes
        '
        Me.lblTiposComprobantes.AutoSize = True
        Me.lblTiposComprobantes.LabelAsoc = Nothing
        Me.lblTiposComprobantes.Location = New System.Drawing.Point(314, 46)
        Me.lblTiposComprobantes.Name = "lblTiposComprobantes"
        Me.lblTiposComprobantes.Size = New System.Drawing.Size(94, 13)
        Me.lblTiposComprobantes.TabIndex = 8
        Me.lblTiposComprobantes.Text = "Tipo Comprobante"
        '
        'chbClientesConVenta
        '
        Me.chbClientesConVenta.AutoSize = True
        Me.chbClientesConVenta.BindearPropiedadControl = Nothing
        Me.chbClientesConVenta.BindearPropiedadEntidad = Nothing
        Me.chbClientesConVenta.Checked = True
        Me.chbClientesConVenta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbClientesConVenta.ForeColorFocus = System.Drawing.Color.Red
        Me.chbClientesConVenta.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbClientesConVenta.IsPK = False
        Me.chbClientesConVenta.IsRequired = False
        Me.chbClientesConVenta.Key = Nothing
        Me.chbClientesConVenta.LabelAsoc = Nothing
        Me.chbClientesConVenta.Location = New System.Drawing.Point(9, 19)
        Me.chbClientesConVenta.Name = "chbClientesConVenta"
        Me.chbClientesConVenta.Size = New System.Drawing.Size(115, 17)
        Me.chbClientesConVenta.TabIndex = 0
        Me.chbClientesConVenta.Text = "Clientes con Venta"
        Me.chbClientesConVenta.UseVisualStyleBackColor = True
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(178, 43)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 7
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(127, 47)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 6
        Me.lblSucursal.Text = "Sucursal"
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(229, 21)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 2
        Me.lblDesde.Text = "Desde"
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(404, 21)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 4
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(273, 17)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 3
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(445, 17)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 5
        '
        'chbMesCompleto
        '
        Me.chbMesCompleto.AutoSize = True
        Me.chbMesCompleto.BindearPropiedadControl = Nothing
        Me.chbMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chbMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbMesCompleto.IsPK = False
        Me.chbMesCompleto.IsRequired = False
        Me.chbMesCompleto.Key = Nothing
        Me.chbMesCompleto.LabelAsoc = Nothing
        Me.chbMesCompleto.Location = New System.Drawing.Point(130, 19)
        Me.chbMesCompleto.Name = "chbMesCompleto"
        Me.chbMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chbMesCompleto.TabIndex = 1
        Me.chbMesCompleto.Text = "Mes Completo"
        Me.chbMesCompleto.UseVisualStyleBackColor = True
        '
        'chbTipoDireccion
        '
        Me.chbTipoDireccion.AutoSize = True
        Me.chbTipoDireccion.BindearPropiedadControl = Nothing
        Me.chbTipoDireccion.BindearPropiedadEntidad = Nothing
        Me.chbTipoDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTipoDireccion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTipoDireccion.IsPK = False
        Me.chbTipoDireccion.IsRequired = False
        Me.chbTipoDireccion.Key = Nothing
        Me.chbTipoDireccion.LabelAsoc = Nothing
        Me.chbTipoDireccion.Location = New System.Drawing.Point(358, 155)
        Me.chbTipoDireccion.Name = "chbTipoDireccion"
        Me.chbTipoDireccion.Size = New System.Drawing.Size(95, 17)
        Me.chbTipoDireccion.TabIndex = 17
        Me.chbTipoDireccion.Text = "Tipo Dirección"
        Me.chbTipoDireccion.UseVisualStyleBackColor = True
        '
        'chbVendedor
        '
        Me.chbVendedor.AutoSize = True
        Me.chbVendedor.BindearPropiedadControl = Nothing
        Me.chbVendedor.BindearPropiedadEntidad = Nothing
        Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVendedor.IsPK = False
        Me.chbVendedor.IsRequired = False
        Me.chbVendedor.Key = Nothing
        Me.chbVendedor.LabelAsoc = Nothing
        Me.chbVendedor.Location = New System.Drawing.Point(358, 124)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 11
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbTipoDireccion
        '
        Me.cmbTipoDireccion.BindearPropiedadControl = Nothing
        Me.cmbTipoDireccion.BindearPropiedadEntidad = Nothing
        Me.cmbTipoDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDireccion.Enabled = False
        Me.cmbTipoDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDireccion.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTipoDireccion.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTipoDireccion.FormattingEnabled = True
        Me.cmbTipoDireccion.IsPK = False
        Me.cmbTipoDireccion.IsRequired = False
        Me.cmbTipoDireccion.Key = Nothing
        Me.cmbTipoDireccion.LabelAsoc = Nothing
        Me.cmbTipoDireccion.Location = New System.Drawing.Point(459, 153)
        Me.cmbTipoDireccion.Name = "cmbTipoDireccion"
        Me.cmbTipoDireccion.Size = New System.Drawing.Size(140, 21)
        Me.cmbTipoDireccion.TabIndex = 18
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Enabled = False
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Nothing
        Me.cmbVendedor.Location = New System.Drawing.Point(459, 122)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(140, 21)
        Me.cmbVendedor.TabIndex = 12
        '
        'lblComenzarPorNombreCliente
        '
        Me.lblComenzarPorNombreCliente.AutoSize = True
        Me.lblComenzarPorNombreCliente.LabelAsoc = Nothing
        Me.lblComenzarPorNombreCliente.Location = New System.Drawing.Point(483, 98)
        Me.lblComenzarPorNombreCliente.Name = "lblComenzarPorNombreCliente"
        Me.lblComenzarPorNombreCliente.Size = New System.Drawing.Size(148, 13)
        Me.lblComenzarPorNombreCliente.TabIndex = 6
        Me.lblComenzarPorNombreCliente.Text = "Comenzar Por Nombre Cliente"
        '
        'txtComenzarPorNombreCliente
        '
        Me.txtComenzarPorNombreCliente.BindearPropiedadControl = ""
        Me.txtComenzarPorNombreCliente.BindearPropiedadEntidad = ""
        Me.txtComenzarPorNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.txtComenzarPorNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtComenzarPorNombreCliente.Formato = "N2"
        Me.txtComenzarPorNombreCliente.IsDecimal = False
        Me.txtComenzarPorNombreCliente.IsNumber = False
        Me.txtComenzarPorNombreCliente.IsPK = False
        Me.txtComenzarPorNombreCliente.IsRequired = False
        Me.txtComenzarPorNombreCliente.Key = ""
        Me.txtComenzarPorNombreCliente.LabelAsoc = Me.lblComenzarPorNombreCliente
        Me.txtComenzarPorNombreCliente.Location = New System.Drawing.Point(635, 94)
        Me.txtComenzarPorNombreCliente.MaxLength = 60
        Me.txtComenzarPorNombreCliente.Name = "txtComenzarPorNombreCliente"
        Me.txtComenzarPorNombreCliente.Size = New System.Drawing.Size(198, 20)
        Me.txtComenzarPorNombreCliente.TabIndex = 7
        '
        'chbTransportista
        '
        Me.chbTransportista.AutoSize = True
        Me.chbTransportista.BindearPropiedadControl = Nothing
        Me.chbTransportista.BindearPropiedadEntidad = Nothing
        Me.chbTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTransportista.IsPK = False
        Me.chbTransportista.IsRequired = False
        Me.chbTransportista.Key = Nothing
        Me.chbTransportista.LabelAsoc = Nothing
        Me.chbTransportista.Location = New System.Drawing.Point(12, 155)
        Me.chbTransportista.Name = "chbTransportista"
        Me.chbTransportista.Size = New System.Drawing.Size(87, 17)
        Me.chbTransportista.TabIndex = 14
        Me.chbTransportista.Text = "Transportista"
        Me.chbTransportista.UseVisualStyleBackColor = True
        '
        'chbCategoriaCliente
        '
        Me.chbCategoriaCliente.AutoSize = True
        Me.chbCategoriaCliente.BindearPropiedadControl = Nothing
        Me.chbCategoriaCliente.BindearPropiedadEntidad = Nothing
        Me.chbCategoriaCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoriaCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoriaCliente.IsPK = False
        Me.chbCategoriaCliente.IsRequired = False
        Me.chbCategoriaCliente.Key = Nothing
        Me.chbCategoriaCliente.LabelAsoc = Nothing
        Me.chbCategoriaCliente.Location = New System.Drawing.Point(12, 126)
        Me.chbCategoriaCliente.Name = "chbCategoriaCliente"
        Me.chbCategoriaCliente.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoriaCliente.TabIndex = 8
        Me.chbCategoriaCliente.Text = "Categoria"
        Me.chbCategoriaCliente.UseVisualStyleBackColor = True
        '
        'cmbTransportista
        '
        Me.cmbTransportista.BindearPropiedadControl = ""
        Me.cmbTransportista.BindearPropiedadEntidad = ""
        Me.cmbTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransportista.Enabled = False
        Me.cmbTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTransportista.FormattingEnabled = True
        Me.cmbTransportista.IsPK = False
        Me.cmbTransportista.IsRequired = True
        Me.cmbTransportista.Key = Nothing
        Me.cmbTransportista.LabelAsoc = Nothing
        Me.cmbTransportista.Location = New System.Drawing.Point(119, 153)
        Me.cmbTransportista.Name = "cmbTransportista"
        Me.cmbTransportista.Size = New System.Drawing.Size(140, 21)
        Me.cmbTransportista.TabIndex = 15
        '
        'cmbCategoriasClientes
        '
        Me.cmbCategoriasClientes.BindearPropiedadControl = ""
        Me.cmbCategoriasClientes.BindearPropiedadEntidad = ""
        Me.cmbCategoriasClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoriasClientes.Enabled = False
        Me.cmbCategoriasClientes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoriasClientes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoriasClientes.FormattingEnabled = True
        Me.cmbCategoriasClientes.IsPK = False
        Me.cmbCategoriasClientes.IsRequired = True
        Me.cmbCategoriasClientes.Key = Nothing
        Me.cmbCategoriasClientes.LabelAsoc = Nothing
        Me.cmbCategoriasClientes.Location = New System.Drawing.Point(119, 124)
        Me.cmbCategoriasClientes.Name = "cmbCategoriasClientes"
        Me.cmbCategoriasClientes.Size = New System.Drawing.Size(140, 21)
        Me.cmbCategoriasClientes.TabIndex = 9
        '
        'bscNombreCliente
        '
        Me.bscNombreCliente.AyudaAncho = 608
        Me.bscNombreCliente.BindearPropiedadControl = Nothing
        Me.bscNombreCliente.BindearPropiedadEntidad = Nothing
        Me.bscNombreCliente.ColumnasAlineacion = Nothing
        Me.bscNombreCliente.ColumnasAncho = Nothing
        Me.bscNombreCliente.ColumnasFormato = Nothing
        Me.bscNombreCliente.ColumnasOcultas = Nothing
        Me.bscNombreCliente.ColumnasTitulos = Nothing
        Me.bscNombreCliente.Datos = Nothing
        Me.bscNombreCliente.FilaDevuelta = Nothing
        Me.bscNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscNombreCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCliente.IsDecimal = False
        Me.bscNombreCliente.IsNumber = False
        Me.bscNombreCliente.IsPK = False
        Me.bscNombreCliente.IsRequired = False
        Me.bscNombreCliente.Key = ""
        Me.bscNombreCliente.LabelAsoc = Me.lblNombreCliente
        Me.bscNombreCliente.Location = New System.Drawing.Point(269, 95)
        Me.bscNombreCliente.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.bscNombreCliente.MaxLengh = "32767"
        Me.bscNombreCliente.Name = "bscNombreCliente"
        Me.bscNombreCliente.Permitido = False
        Me.bscNombreCliente.Selecciono = False
        Me.bscNombreCliente.Size = New System.Drawing.Size(206, 23)
        Me.bscNombreCliente.TabIndex = 5
        Me.bscNombreCliente.Titulo = Nothing
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.LabelAsoc = Nothing
        Me.lblNombreCliente.Location = New System.Drawing.Point(221, 99)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreCliente.TabIndex = 4
        Me.lblNombreCliente.Text = "Nombre"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.AyudaAncho = 608
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ColumnasAlineacion = Nothing
        Me.bscCodigoCliente.ColumnasAncho = Nothing
        Me.bscCodigoCliente.ColumnasFormato = Nothing
        Me.bscCodigoCliente.ColumnasOcultas = Nothing
        Me.bscCodigoCliente.ColumnasTitulos = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Me.lblCodigoCliente
        Me.bscCodigoCliente.Location = New System.Drawing.Point(119, 95)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(100, 23)
        Me.bscCodigoCliente.TabIndex = 3
        Me.bscCodigoCliente.Titulo = Nothing
        '
        'lblCodigoCliente
        '
        Me.lblCodigoCliente.AutoSize = True
        Me.lblCodigoCliente.LabelAsoc = Nothing
        Me.lblCodigoCliente.Location = New System.Drawing.Point(73, 99)
        Me.lblCodigoCliente.Name = "lblCodigoCliente"
        Me.lblCodigoCliente.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigoCliente.TabIndex = 2
        Me.lblCodigoCliente.Text = "Codigo"
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(866, 129)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(106, 45)
        Me.btnConsultar.TabIndex = 19
        Me.btnConsultar.Text = "&Consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator3, Me.tsbPreferencias, Me.ToolStripSeparator2, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(984, 29)
        Me.tstBarra.TabIndex = 3
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_24
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.AutoSize = True
        Me.pnlAcciones.Controls.Add(Me.txtCantidadBultos)
        Me.pnlAcciones.Controls.Add(Me.cmbTodos)
        Me.pnlAcciones.Controls.Add(Me.btnTodos)
        Me.pnlAcciones.Controls.Add(Me.chbReimpresion)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 209)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(984, 28)
        Me.pnlAcciones.TabIndex = 0
        '
        'txtCantidadBultos
        '
        Me.txtCantidadBultos.BindearPropiedadControl = Nothing
        Me.txtCantidadBultos.BindearPropiedadEntidad = Nothing
        Me.txtCantidadBultos.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidadBultos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidadBultos.Formato = "##0"
        Me.txtCantidadBultos.IsDecimal = False
        Me.txtCantidadBultos.IsNumber = True
        Me.txtCantidadBultos.IsPK = False
        Me.txtCantidadBultos.IsRequired = False
        Me.txtCantidadBultos.Key = ""
        Me.txtCantidadBultos.LabelAsoc = Me.chbNumero
        Me.txtCantidadBultos.Location = New System.Drawing.Point(128, 3)
        Me.txtCantidadBultos.MaxLength = 8
        Me.txtCantidadBultos.Name = "txtCantidadBultos"
        Me.txtCantidadBultos.Size = New System.Drawing.Size(55, 20)
        Me.txtCantidadBultos.TabIndex = 1
        Me.txtCantidadBultos.Text = "1"
        Me.txtCantidadBultos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbTodos
        '
        Me.cmbTodos.BindearPropiedadControl = Nothing
        Me.cmbTodos.BindearPropiedadEntidad = Nothing
        Me.cmbTodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTodos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTodos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTodos.FormattingEnabled = True
        Me.cmbTodos.IsPK = False
        Me.cmbTodos.IsRequired = False
        Me.cmbTodos.Key = Nothing
        Me.cmbTodos.LabelAsoc = Nothing
        Me.cmbTodos.Location = New System.Drawing.Point(3, 3)
        Me.cmbTodos.Name = "cmbTodos"
        Me.cmbTodos.Size = New System.Drawing.Size(121, 21)
        Me.cmbTodos.TabIndex = 0
        '
        'chbReimpresion
        '
        Me.chbReimpresion.AutoSize = True
        Me.chbReimpresion.BindearPropiedadControl = Nothing
        Me.chbReimpresion.BindearPropiedadEntidad = Nothing
        Me.chbReimpresion.ForeColorFocus = System.Drawing.Color.Red
        Me.chbReimpresion.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbReimpresion.IsPK = False
        Me.chbReimpresion.IsRequired = False
        Me.chbReimpresion.Key = Nothing
        Me.chbReimpresion.LabelAsoc = Nothing
        Me.chbReimpresion.Location = New System.Drawing.Point(276, 6)
        Me.chbReimpresion.Name = "chbReimpresion"
        Me.chbReimpresion.Size = New System.Drawing.Size(84, 17)
        Me.chbReimpresion.TabIndex = 3
        Me.chbReimpresion.Text = "Reimpresión"
        Me.chbReimpresion.UseVisualStyleBackColor = True
        '
        'EmisionEtiquetasParaBultos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.sspPie)
        Me.Controls.Add(Me.grbFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Name = "EmisionEtiquetasParaBultos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Emisión de Etiquetas para Bultos"
        Me.sspPie.ResumeLayout(False)
        Me.sspPie.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.grpVentas.ResumeLayout(False)
        Me.grpVentas.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Friend WithEvents ugDetalle As UltraGridEditable
   Friend WithEvents sspPie As System.Windows.Forms.StatusStrip
   Friend WithEvents tslTexto As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents bscNombreCliente As Eniac.Controles.Buscador
   Friend WithEvents lblNombreCliente As Eniac.Controles.Label
   Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador
   Friend WithEvents lblCodigoCliente As Eniac.Controles.Label
   Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents chbCategoriaCliente As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoriasClientes As Eniac.Controles.ComboBox
   Friend WithEvents lblComenzarPorNombreCliente As Eniac.Controles.Label
   Friend WithEvents txtComenzarPorNombreCliente As Eniac.Controles.TextBox
   Friend WithEvents chbTransportista As Eniac.Controles.CheckBox
   Friend WithEvents cmbTransportista As Eniac.Controles.ComboBox
   Friend WithEvents chbMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents DialogoAbrirArchivo As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnTodos As System.Windows.Forms.Button
   Friend WithEvents cmbTodos As Eniac.Controles.ComboBox
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
    Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
    Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents pnlAcciones As Panel
   Friend WithEvents chbClientesConVenta As Controles.CheckBox
   Friend WithEvents grpVentas As GroupBox
   Friend WithEvents cmbEmisor As Controles.ComboBox
   Friend WithEvents chbEmisor As Controles.CheckBox
   Friend WithEvents cmbLetra As Controles.ComboBox
   Friend WithEvents chbLetra As Controles.CheckBox
   Friend WithEvents txtNumeroCompDesde As Controles.TextBox
   Friend WithEvents chbNumero As Controles.CheckBox
   Friend WithEvents lblNumeroDesde As Controles.Label
   Friend WithEvents lblNumeroHasta As Controles.Label
   Friend WithEvents txtNumeroCompHasta As Controles.TextBox
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
   Friend WithEvents lblTiposComprobantes As Controles.Label
   Friend WithEvents cmbOrigenCategoria As Controles.ComboBox
   Friend WithEvents cmbOrigenVendedor As Controles.ComboBox
   Friend WithEvents cmbOrigenTransportista As Controles.ComboBox
    Friend WithEvents chbTipoDireccion As Controles.CheckBox
    Friend WithEvents cmbTipoDireccion As Controles.ComboBox
    Friend WithEvents txtCantidadBultos As Controles.TextBox
   Friend WithEvents chbReimpresion As Controles.CheckBox
   Protected WithEvents tssRegistros As ToolStripStatusLabel
    Friend WithEvents cmbFormatos As Controles.ComboBox
    Friend WithEvents Label1 As Controles.Label
End Class
