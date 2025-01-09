<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OrdenesProduccionAdminV2Cambiar
   Inherits Eniac.Win.BaseForm

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
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Color")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("masivo")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenProduccion")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaOrdenProduccion")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCriticidad")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEntrega")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocumento")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocumento")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idProducto")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProducto")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tamano")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Orden")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cantidad")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEstado")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdEstado")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoEstado")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantEntregada")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantPendiente")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobanteFact")
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LetraFact")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisorFact")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobanteFact")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario")
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMarca")
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreRubro")
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUnidadDeMedida")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroOrdenCompra")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreResponsable")
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadNuevoEstado")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn79 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDepositoUbicacion")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("LoteSeleccionado")
        Dim UltraGridColumn81 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroSerieSeleccionado")
        Dim UltraGridColumn82 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdResponsable")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PlanMaestroNumero")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("PlanMaestroFecha")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrdenesProduccionAdminV2Cambiar))
        Me.cmbCriticidadEditor = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbResponsableEditor = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New Eniac.Controles.TextBox()
        Me.lblObservacion = New Eniac.Controles.Label()
        Me.cmbEstadoCambiar = New Eniac.Controles.ComboBox()
        Me.lblEstado = New Eniac.Controles.Label()
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.grpAplicarATodos = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCriticidad = New Eniac.Controles.Label()
        Me.btnAplicaCantidad = New Eniac.Controles.Button()
        Me.cmbCriticidad = New Eniac.Controles.ComboBox()
        Me.txtCantidad = New Eniac.Controles.TextBox()
        Me.lblCantidad = New Eniac.Controles.Label()
        Me.btnAplicaFechaEntrega = New Eniac.Controles.Button()
        Me.btnAplicaCriticidad = New Eniac.Controles.Button()
        Me.lblFechaEntrega = New Eniac.Controles.Label()
        Me.dtpFechaEntrega = New Eniac.Controles.DateTimePicker()
        Me.Label1 = New Eniac.Controles.Label()
        Me.cmbResponsable = New Eniac.Controles.ComboBox()
        Me.btnAplicaResponsable = New Eniac.Controles.Button()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.cmbCriticidadEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbResponsableEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.stsStado.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpAplicarATodos.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbCriticidadEditor
        '
        Me.cmbCriticidadEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbCriticidadEditor.Location = New System.Drawing.Point(1044, 17)
        Me.cmbCriticidadEditor.Name = "cmbCriticidadEditor"
        Me.cmbCriticidadEditor.Size = New System.Drawing.Size(74, 21)
        Me.cmbCriticidadEditor.TabIndex = 36
        Me.cmbCriticidadEditor.Visible = False
        '
        'cmbResponsableEditor
        '
        Me.cmbResponsableEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbResponsableEditor.Location = New System.Drawing.Point(964, 19)
        Me.cmbResponsableEditor.Name = "cmbResponsableEditor"
        Me.cmbResponsableEditor.Size = New System.Drawing.Size(74, 21)
        Me.cmbResponsableEditor.TabIndex = 37
        Me.cmbResponsableEditor.Visible = False
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        UltraGridColumn42.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn42.Header.Caption = ""
        UltraGridColumn42.Header.VisiblePosition = 5
        UltraGridColumn42.Hidden = True
        UltraGridColumn42.Width = 30
        UltraGridColumn43.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn43.Header.Appearance = Appearance2
        UltraGridColumn43.Header.Caption = "Masivo"
        UltraGridColumn43.Header.VisiblePosition = 6
        UltraGridColumn43.Hidden = True
        UltraGridColumn43.MaxWidth = 50
        UltraGridColumn43.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        UltraGridColumn43.Width = 50
        UltraGridColumn44.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn44.Header.VisiblePosition = 7
        UltraGridColumn44.Hidden = True
        UltraGridColumn45.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn45.Header.Caption = "Tipo"
        UltraGridColumn45.Header.VisiblePosition = 15
        UltraGridColumn45.Width = 111
        UltraGridColumn46.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn46.CellAppearance = Appearance3
        UltraGridColumn46.Header.Caption = "L."
        UltraGridColumn46.Header.VisiblePosition = 16
        UltraGridColumn46.Width = 25
        UltraGridColumn47.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn47.CellAppearance = Appearance4
        UltraGridColumn47.Header.Caption = "Emisor"
        UltraGridColumn47.Header.VisiblePosition = 17
        UltraGridColumn47.Width = 40
        UltraGridColumn48.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance5.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance5
        UltraGridColumn48.Header.Caption = "Numero"
        UltraGridColumn48.Header.VisiblePosition = 18
        UltraGridColumn48.Width = 83
        UltraGridColumn49.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn49.CellAppearance = Appearance6
        UltraGridColumn49.Header.Caption = "Fecha"
        UltraGridColumn49.Header.VisiblePosition = 19
        UltraGridColumn49.Width = 94
        Appearance7.BackColor = System.Drawing.Color.Cyan
        UltraGridColumn50.CellAppearance = Appearance7
        UltraGridColumn50.EditorComponent = Me.cmbCriticidadEditor
        UltraGridColumn50.Header.Caption = "Criticidad"
        UltraGridColumn50.Header.VisiblePosition = 11
        UltraGridColumn50.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        Appearance8.BackColor = System.Drawing.Color.Cyan
        UltraGridColumn51.CellAppearance = Appearance8
        UltraGridColumn51.Format = "dd/MM/yyyy"
        UltraGridColumn51.Header.Caption = "Fecha Entrega"
        UltraGridColumn51.Header.VisiblePosition = 12
        UltraGridColumn51.Width = 85
        UltraGridColumn52.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn52.Header.VisiblePosition = 21
        UltraGridColumn52.Hidden = True
        UltraGridColumn53.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn53.Header.VisiblePosition = 23
        UltraGridColumn53.Hidden = True
        UltraGridColumn54.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn54.Header.VisiblePosition = 20
        UltraGridColumn54.Hidden = True
        UltraGridColumn55.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn55.Header.VisiblePosition = 22
        UltraGridColumn55.Hidden = True
        UltraGridColumn56.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn56.Header.Caption = "Nombre Cliente"
        UltraGridColumn56.Header.VisiblePosition = 24
        UltraGridColumn56.Width = 150
        UltraGridColumn57.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn57.Header.Caption = "Código Producto"
        UltraGridColumn57.Header.VisiblePosition = 0
        UltraGridColumn57.Width = 80
        UltraGridColumn58.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn58.Header.Caption = "Nombre Producto"
        UltraGridColumn58.Header.VisiblePosition = 1
        UltraGridColumn58.Width = 200
        UltraGridColumn59.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn59.CellAppearance = Appearance9
        UltraGridColumn59.Format = "#,##0.00"
        UltraGridColumn59.Header.Caption = "Tamaño"
        UltraGridColumn59.Header.VisiblePosition = 25
        UltraGridColumn59.Width = 60
        UltraGridColumn60.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn60.Header.VisiblePosition = 27
        UltraGridColumn60.Hidden = True
        UltraGridColumn61.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn61.CellAppearance = Appearance10
        UltraGridColumn61.Format = "N2"
        UltraGridColumn61.Header.Caption = "Cant.Pedida"
        UltraGridColumn61.Header.VisiblePosition = 29
        UltraGridColumn61.Width = 70
        UltraGridColumn62.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance11.TextHAlignAsString = "Center"
        UltraGridColumn62.CellAppearance = Appearance11
        UltraGridColumn62.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn62.Header.Caption = "Fecha Estado"
        UltraGridColumn62.Header.VisiblePosition = 28
        UltraGridColumn62.Width = 100
        UltraGridColumn63.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn63.Header.Caption = "Estado"
        UltraGridColumn63.Header.VisiblePosition = 8
        UltraGridColumn63.Width = 90
        UltraGridColumn64.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn64.Header.VisiblePosition = 30
        UltraGridColumn64.Hidden = True
        UltraGridColumn65.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn65.CellAppearance = Appearance12
        UltraGridColumn65.Format = "N2"
        UltraGridColumn65.Header.Caption = "Cant. Involucrada"
        UltraGridColumn65.Header.VisiblePosition = 9
        UltraGridColumn65.Width = 70
        UltraGridColumn66.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance13.BackColor = System.Drawing.Color.LightCyan
        Appearance13.FontData.BoldAsString = "True"
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn66.CellAppearance = Appearance13
        UltraGridColumn66.Format = "N2"
        UltraGridColumn66.Header.Caption = "Cant.Pendiente"
        UltraGridColumn66.Header.VisiblePosition = 31
        UltraGridColumn66.Width = 70
        UltraGridColumn67.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn67.Header.Caption = "Comprobante"
        UltraGridColumn67.Header.VisiblePosition = 32
        UltraGridColumn67.Width = 90
        UltraGridColumn68.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance14.TextHAlignAsString = "Center"
        UltraGridColumn68.CellAppearance = Appearance14
        UltraGridColumn68.Header.Caption = "Let."
        UltraGridColumn68.Header.VisiblePosition = 33
        UltraGridColumn68.Width = 30
        UltraGridColumn69.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn69.CellAppearance = Appearance15
        UltraGridColumn69.Header.Caption = "Emisor"
        UltraGridColumn69.Header.VisiblePosition = 34
        UltraGridColumn69.Width = 40
        UltraGridColumn70.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn70.CellAppearance = Appearance16
        UltraGridColumn70.Header.Caption = "Nro.Comprobante"
        UltraGridColumn70.Header.VisiblePosition = 35
        UltraGridColumn70.Width = 70
        UltraGridColumn71.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn71.Header.Caption = "Usuario"
        UltraGridColumn71.Header.VisiblePosition = 37
        UltraGridColumn71.Width = 75
        UltraGridColumn72.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn72.Header.VisiblePosition = 36
        UltraGridColumn72.Width = 200
        UltraGridColumn73.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn73.Header.Caption = "Marca"
        UltraGridColumn73.Header.VisiblePosition = 38
        UltraGridColumn73.Width = 200
        UltraGridColumn74.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn74.Header.Caption = "Rubro"
        UltraGridColumn74.Header.VisiblePosition = 39
        UltraGridColumn74.Width = 200
        UltraGridColumn75.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance17.TextHAlignAsString = "Center"
        UltraGridColumn75.CellAppearance = Appearance17
        UltraGridColumn75.Header.Caption = "U. M."
        UltraGridColumn75.Header.VisiblePosition = 26
        UltraGridColumn75.Width = 40
        UltraGridColumn76.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn76.CellAppearance = Appearance18
        UltraGridColumn76.Header.Caption = "O. C."
        UltraGridColumn76.Header.VisiblePosition = 40
        UltraGridColumn76.Width = 80
        UltraGridColumn77.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn77.Header.Caption = "Nombre Responsable"
        UltraGridColumn77.Header.VisiblePosition = 14
        UltraGridColumn77.Hidden = True
        Appearance19.BackColor = System.Drawing.Color.Cyan
        Appearance19.FontData.BoldAsString = "True"
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn78.CellAppearance = Appearance19
        UltraGridColumn78.Format = "N2"
        UltraGridColumn78.Header.Caption = "Cant. Nuevo Estado"
        UltraGridColumn78.Header.VisiblePosition = 10
        UltraGridColumn78.MaskInput = "{double:-12.2}"
        UltraGridColumn78.Width = 73
        UltraGridColumn79.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn79.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn79.Header.Caption = "Depósito / Ubicación"
        UltraGridColumn79.Header.VisiblePosition = 2
        UltraGridColumn79.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn79.Width = 130
        UltraGridColumn80.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn80.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn80.Header.Caption = "Lotes"
        UltraGridColumn80.Header.VisiblePosition = 3
        UltraGridColumn80.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn80.Width = 90
        UltraGridColumn81.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        UltraGridColumn81.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn81.Header.Caption = "Nros. Serie"
        UltraGridColumn81.Header.VisiblePosition = 4
        UltraGridColumn81.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn81.Width = 90
        Appearance20.BackColor = System.Drawing.Color.Cyan
        UltraGridColumn82.CellAppearance = Appearance20
        UltraGridColumn82.EditorComponent = Me.cmbResponsableEditor
        UltraGridColumn82.Header.Caption = "Operario"
        UltraGridColumn82.Header.VisiblePosition = 13
        UltraGridColumn82.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn82.Width = 80
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn1.CellAppearance = Appearance21
        UltraGridColumn1.Header.Caption = "Nro. Plan Maestro"
        UltraGridColumn1.Header.VisiblePosition = 41
        UltraGridColumn1.Width = 102
        Appearance22.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance22
        UltraGridColumn2.Header.Caption = "Fecha/Hora Plan Maestro"
        UltraGridColumn2.Header.VisiblePosition = 42
        UltraGridColumn2.Width = 105
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn78, UltraGridColumn79, UltraGridColumn80, UltraGridColumn81, UltraGridColumn82, UltraGridColumn1, UltraGridColumn2})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance23.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance23.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance23
        Appearance24.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance24
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance25.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance25.BackColor2 = System.Drawing.SystemColors.Control
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance25
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Me.ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.[True]
        Appearance26.BackColor = System.Drawing.SystemColors.Window
        Appearance26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance26
        Appearance27.BackColor = System.Drawing.SystemColors.Highlight
        Appearance27.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance27
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance28
        Appearance29.BorderColor = System.Drawing.Color.Silver
        Appearance29.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance29
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance30.BackColor = System.Drawing.SystemColors.Control
        Appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance30.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance30.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance30
        Appearance31.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance31
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance32.BackColor = System.Drawing.SystemColors.Window
        Appearance32.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance32
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance33.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance33
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 126)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1130, 372)
        Me.ugDetalle.TabIndex = 2
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 531)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1130, 22)
        Me.stsStado.TabIndex = 3
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(1051, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance34.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance34.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance34
        Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Header.TextCenter = ""
        Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
        Me.UltraGridPrintDocument1.Page.Margins.Left = 2
        Me.UltraGridPrintDocument1.Page.Margins.Right = 2
        Me.UltraGridPrintDocument1.Page.Margins.Top = 2
        Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator4, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1130, 29)
        Me.tstBarra.TabIndex = 4
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbResponsableEditor)
        Me.GroupBox2.Controls.Add(Me.cmbCriticidadEditor)
        Me.GroupBox2.Controls.Add(Me.txtObservacion)
        Me.GroupBox2.Controls.Add(Me.lblObservacion)
        Me.GroupBox2.Controls.Add(Me.cmbEstadoCambiar)
        Me.GroupBox2.Controls.Add(Me.lblEstado)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1130, 50)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Operaciones"
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
        Me.txtObservacion.Location = New System.Drawing.Point(85, 23)
        Me.txtObservacion.MaxLength = 200
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(390, 20)
        Me.txtObservacion.TabIndex = 0
        '
        'lblObservacion
        '
        Me.lblObservacion.AutoSize = True
        Me.lblObservacion.LabelAsoc = Nothing
        Me.lblObservacion.Location = New System.Drawing.Point(10, 25)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(67, 13)
        Me.lblObservacion.TabIndex = 0
        Me.lblObservacion.Text = "Observacion"
        '
        'cmbEstadoCambiar
        '
        Me.cmbEstadoCambiar.BindearPropiedadControl = "SelectedValue"
        Me.cmbEstadoCambiar.BindearPropiedadEntidad = "estadoCambiar"
        Me.cmbEstadoCambiar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCambiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoCambiar.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEstadoCambiar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEstadoCambiar.FormattingEnabled = True
        Me.cmbEstadoCambiar.IsPK = False
        Me.cmbEstadoCambiar.IsRequired = True
        Me.cmbEstadoCambiar.Key = Nothing
        Me.cmbEstadoCambiar.LabelAsoc = Nothing
        Me.cmbEstadoCambiar.Location = New System.Drawing.Point(527, 22)
        Me.cmbEstadoCambiar.Name = "cmbEstadoCambiar"
        Me.cmbEstadoCambiar.Size = New System.Drawing.Size(106, 21)
        Me.cmbEstadoCambiar.TabIndex = 1
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.LabelAsoc = Nothing
        Me.lblEstado.Location = New System.Drawing.Point(481, 26)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(40, 13)
        Me.lblEstado.TabIndex = 3
        Me.lblEstado.Text = "Estado"
        '
        'grpAplicarATodos
        '
        Me.grpAplicarATodos.Controls.Add(Me.TableLayoutPanel1)
        Me.grpAplicarATodos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpAplicarATodos.Location = New System.Drawing.Point(0, 79)
        Me.grpAplicarATodos.Name = "grpAplicarATodos"
        Me.grpAplicarATodos.Size = New System.Drawing.Size(1130, 47)
        Me.grpAplicarATodos.TabIndex = 16
        Me.grpAplicarATodos.TabStop = False
        Me.grpAplicarATodos.Text = "Aplicar a todos"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 13
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 538.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblCriticidad, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAplicaCantidad, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbCriticidad, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCantidad, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCantidad, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAplicaFechaEntrega, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAplicaCriticidad, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFechaEntrega, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dtpFechaEntrega, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbResponsable, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAplicaResponsable, 11, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1124, 28)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblCriticidad
        '
        Me.lblCriticidad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCriticidad.AutoSize = True
        Me.lblCriticidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCriticidad.LabelAsoc = Nothing
        Me.lblCriticidad.Location = New System.Drawing.Point(3, 7)
        Me.lblCriticidad.Name = "lblCriticidad"
        Me.lblCriticidad.Size = New System.Drawing.Size(50, 13)
        Me.lblCriticidad.TabIndex = 0
        Me.lblCriticidad.Text = "Criticidad"
        '
        'btnAplicaCantidad
        '
        Me.btnAplicaCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAplicaCantidad.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnAplicaCantidad.Location = New System.Drawing.Point(561, 3)
        Me.btnAplicaCantidad.Name = "btnAplicaCantidad"
        Me.btnAplicaCantidad.Size = New System.Drawing.Size(22, 22)
        Me.btnAplicaCantidad.TabIndex = 8
        Me.btnAplicaCantidad.TabStop = False
        Me.btnAplicaCantidad.Tag = "DescuentoRecargoPorcNuevo1"
        Me.btnAplicaCantidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAplicaCantidad.UseVisualStyleBackColor = True
        '
        'cmbCriticidad
        '
        Me.cmbCriticidad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbCriticidad.BindearPropiedadControl = Nothing
        Me.cmbCriticidad.BindearPropiedadEntidad = Nothing
        Me.cmbCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCriticidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCriticidad.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCriticidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCriticidad.FormattingEnabled = True
        Me.cmbCriticidad.IsPK = False
        Me.cmbCriticidad.IsRequired = False
        Me.cmbCriticidad.Key = Nothing
        Me.cmbCriticidad.LabelAsoc = Me.lblCriticidad
        Me.cmbCriticidad.Location = New System.Drawing.Point(59, 3)
        Me.cmbCriticidad.Name = "cmbCriticidad"
        Me.cmbCriticidad.Size = New System.Drawing.Size(112, 21)
        Me.cmbCriticidad.TabIndex = 1
        '
        'txtCantidad
        '
        Me.txtCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtCantidad.BackColor = System.Drawing.SystemColors.Window
        Me.txtCantidad.BindearPropiedadControl = Nothing
        Me.txtCantidad.BindearPropiedadEntidad = Nothing
        Me.txtCantidad.ForeColorFocus = System.Drawing.Color.Red
        Me.txtCantidad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtCantidad.Formato = "##0.00"
        Me.txtCantidad.IsDecimal = True
        Me.txtCantidad.IsNumber = True
        Me.txtCantidad.IsPK = False
        Me.txtCantidad.IsRequired = False
        Me.txtCantidad.Key = ""
        Me.txtCantidad.LabelAsoc = Me.lblCantidad
        Me.txtCantidad.Location = New System.Drawing.Point(490, 4)
        Me.txtCantidad.MaxLength = 6
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(65, 20)
        Me.txtCantidad.TabIndex = 7
        Me.txtCantidad.Text = "0.00"
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCantidad
        '
        Me.lblCantidad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.LabelAsoc = Nothing
        Me.lblCantidad.Location = New System.Drawing.Point(435, 7)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 6
        Me.lblCantidad.Text = "Cantidad"
        '
        'btnAplicaFechaEntrega
        '
        Me.btnAplicaFechaEntrega.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAplicaFechaEntrega.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnAplicaFechaEntrega.Location = New System.Drawing.Point(407, 3)
        Me.btnAplicaFechaEntrega.Name = "btnAplicaFechaEntrega"
        Me.btnAplicaFechaEntrega.Size = New System.Drawing.Size(22, 22)
        Me.btnAplicaFechaEntrega.TabIndex = 5
        Me.btnAplicaFechaEntrega.TabStop = False
        Me.btnAplicaFechaEntrega.Tag = "DescuentoRecargoPorcNuevo1"
        Me.btnAplicaFechaEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAplicaFechaEntrega.UseVisualStyleBackColor = True
        '
        'btnAplicaCriticidad
        '
        Me.btnAplicaCriticidad.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAplicaCriticidad.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnAplicaCriticidad.Location = New System.Drawing.Point(177, 3)
        Me.btnAplicaCriticidad.Name = "btnAplicaCriticidad"
        Me.btnAplicaCriticidad.Size = New System.Drawing.Size(22, 22)
        Me.btnAplicaCriticidad.TabIndex = 2
        Me.btnAplicaCriticidad.TabStop = False
        Me.btnAplicaCriticidad.Tag = "DescuentoRecargoPorcNuevo1"
        Me.btnAplicaCriticidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAplicaCriticidad.UseVisualStyleBackColor = True
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFechaEntrega.AutoSize = True
        Me.lblFechaEntrega.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFechaEntrega.LabelAsoc = Nothing
        Me.lblFechaEntrega.Location = New System.Drawing.Point(205, 7)
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Size = New System.Drawing.Size(95, 13)
        Me.lblFechaEntrega.TabIndex = 3
        Me.lblFechaEntrega.Text = "Fecha de Entrega:"
        '
        'dtpFechaEntrega
        '
        Me.dtpFechaEntrega.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.dtpFechaEntrega.BindearPropiedadControl = Nothing
        Me.dtpFechaEntrega.BindearPropiedadEntidad = Nothing
        Me.dtpFechaEntrega.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaEntrega.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaEntrega.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaEntrega.IsPK = False
        Me.dtpFechaEntrega.IsRequired = False
        Me.dtpFechaEntrega.Key = ""
        Me.dtpFechaEntrega.LabelAsoc = Me.lblFechaEntrega
        Me.dtpFechaEntrega.Location = New System.Drawing.Point(306, 4)
        Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
        Me.dtpFechaEntrega.Size = New System.Drawing.Size(95, 20)
        Me.dtpFechaEntrega.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.LabelAsoc = Nothing
        Me.Label1.Location = New System.Drawing.Point(589, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Operario"
        '
        'cmbResponsable
        '
        Me.cmbResponsable.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.cmbResponsable.BindearPropiedadControl = Nothing
        Me.cmbResponsable.BindearPropiedadEntidad = Nothing
        Me.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbResponsable.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbResponsable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbResponsable.FormattingEnabled = True
        Me.cmbResponsable.IsPK = False
        Me.cmbResponsable.IsRequired = False
        Me.cmbResponsable.Key = Nothing
        Me.cmbResponsable.LabelAsoc = Nothing
        Me.cmbResponsable.Location = New System.Drawing.Point(642, 3)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(112, 21)
        Me.cmbResponsable.TabIndex = 10
        '
        'btnAplicaResponsable
        '
        Me.btnAplicaResponsable.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnAplicaResponsable.Image = Global.Eniac.Win.My.Resources.Resources.ok_16
        Me.btnAplicaResponsable.Location = New System.Drawing.Point(760, 3)
        Me.btnAplicaResponsable.Name = "btnAplicaResponsable"
        Me.btnAplicaResponsable.Size = New System.Drawing.Size(22, 22)
        Me.btnAplicaResponsable.TabIndex = 11
        Me.btnAplicaResponsable.TabStop = False
        Me.btnAplicaResponsable.Tag = "DescuentoRecargoPorcNuevo1"
        Me.btnAplicaResponsable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAplicaResponsable.UseVisualStyleBackColor = True
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "check2.ico")
        Me.imageList1.Images.SetKeyName(1, "delete2.ico")
        '
        'pnlAcciones
        '
        Me.pnlAcciones.AutoSize = True
        Me.pnlAcciones.Controls.Add(Me.btnAceptar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 498)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1130, 33)
        Me.pnlAcciones.TabIndex = 17
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imageList1
        Me.btnAceptar.Location = New System.Drawing.Point(941, 0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 30)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar (F4)"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imageList1
        Me.btnCancelar.Location = New System.Drawing.Point(1047, 0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'OrdenesProduccionAdminV2Cambiar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 553)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.grpAplicarATodos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.KeyPreview = True
        Me.Name = "OrdenesProduccionAdminV2Cambiar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de Ordenes de Producción"
        CType(Me.cmbCriticidadEditor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbResponsableEditor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpAplicarATodos.ResumeLayout(False)
        Me.grpAplicarATodos.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
    Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
    Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
    Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
    Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
    Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
    Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
    Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEstadoCambiar As Eniac.Controles.ComboBox
    Friend WithEvents lblEstado As Eniac.Controles.Label
    Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblObservacion As Eniac.Controles.Label
    Friend WithEvents txtObservacion As Eniac.Controles.TextBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpAplicarATodos As GroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblCriticidad As Controles.Label
    Friend WithEvents btnAplicaCantidad As Controles.Button
    Friend WithEvents cmbCriticidad As Controles.ComboBox
    Friend WithEvents txtCantidad As Controles.TextBox
    Friend WithEvents lblCantidad As Controles.Label
    Friend WithEvents btnAplicaFechaEntrega As Controles.Button
    Friend WithEvents btnAplicaCriticidad As Controles.Button
    Friend WithEvents lblFechaEntrega As Controles.Label
    Friend WithEvents dtpFechaEntrega As Controles.DateTimePicker
    Private WithEvents imageList1 As ImageList
    Friend WithEvents pnlAcciones As Panel
    Protected WithEvents btnAceptar As Button
    Protected WithEvents btnCancelar As Button
    Friend WithEvents cmbCriticidadEditor As UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbResponsableEditor As UltraWinEditors.UltraComboEditor
    Friend WithEvents Label1 As Controles.Label
    Friend WithEvents cmbResponsable As Controles.ComboBox
    Friend WithEvents btnAplicaResponsable As Controles.Button
End Class
